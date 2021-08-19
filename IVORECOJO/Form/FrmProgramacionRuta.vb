Public Class FrmProgramacionRuta
    Public hnd As Long
    Dim bNuevo As Boolean
    Dim bInicio As Boolean
    Dim ds As DataSet
    Dim sFechaInicial As String
    Dim iChofer As Integer
    Dim bIngreso As Boolean = False
#Region "Formato"
    Sub FormatoDgvAyudante()
        With DgvAyudante
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim col_ayudante As New DataGridViewTextBoxColumn
            With col_ayudante
                .HeaderText = "id_ayudante"
                .Name = "id_ayudante"
                .DataPropertyName = "id_ayudante"
                .Visible = False
            End With

            Dim col_nombres As New DataGridViewTextBoxColumn
            With col_nombres
                .HeaderText = "Nombres"
                .Name = "nombres"
                .DataPropertyName = "nombres"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 350
            End With

            .Columns.AddRange(col_ayudante, col_nombres)
        End With
    End Sub

    Sub FormatoDgvLista()
        With DgvLista
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .RowHeadersWidth = 20
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .HeaderText = "Fecha Salida"
                .Name = "fecha"
                .DataPropertyName = "fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Visible = True
            End With

            Dim col_hora As New DataGridViewTextBoxColumn
            With col_hora
                .HeaderText = "Hora Salida"
                .Name = "hora"
                .DataPropertyName = "hora"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Visible = True
            End With

            Dim col_ciudad As New DataGridViewTextBoxColumn
            With col_ciudad
                .HeaderText = "Ciudad"
                .Name = "ciudad"
                .DataPropertyName = "ciudad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Visible = True
            End With

            Dim col_ruta As New DataGridViewTextBoxColumn
            With col_ruta
                .HeaderText = "Ruta"
                .Name = "ruta"
                .DataPropertyName = "ruta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_movil As New DataGridViewTextBoxColumn
            With col_movil
                .HeaderText = "Móvil"
                .Name = "movil"
                .DataPropertyName = "movil"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Visible = True
            End With

            Dim col_chofer As New DataGridViewTextBoxColumn
            With col_chofer
                .HeaderText = "Chofer"
                .Name = "chofer"
                .DataPropertyName = "chofer"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Visible = True
            End With

            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .HeaderText = "Tipo"
                .Name = "tipo"
                .DataPropertyName = "tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Visible = False
            End With

            Dim col_programacion As New DataGridViewTextBoxColumn
            With col_programacion
                .HeaderText = "programacion"
                .Name = "programacion"
                .DataPropertyName = "programacion"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Visible = False
            End With

            Dim col_id_ruta As New DataGridViewTextBoxColumn
            With col_id_ruta
                .HeaderText = "id_ruta"
                .Name = "id_ruta"
                .DataPropertyName = "id_ruta"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Visible = False
            End With

            Dim col_id_movil As New DataGridViewTextBoxColumn
            With col_id_movil
                .HeaderText = "id_movil"
                .Name = "id_movil"
                .DataPropertyName = "id_movil"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Visible = False
            End With

            Dim col_id_chofer As New DataGridViewTextBoxColumn
            With col_id_chofer
                .HeaderText = "id_chofer"
                .Name = "id_chofer"
                .DataPropertyName = "id_chofer"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Visible = False
            End With

            Dim col_id_tipo As New DataGridViewTextBoxColumn
            With col_id_tipo
                .HeaderText = "id tipo"
                .Name = "id_tipo"
                .DataPropertyName = "id_tipo"
                .Visible = False
            End With

            .Columns.AddRange(col_fecha, col_hora, col_ciudad, col_ruta, col_movil, col_chofer, col_tipo, col_programacion, _
            col_id_ruta, col_id_movil, col_id_chofer, col_id_tipo)
        End With
    End Sub

#End Region
    Private Sub FrmProgramacionRuta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmProgramacionRuta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FrmProgramacionRuta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            bNuevo = True
            FormatoDgvLista()
            FormatoDgvAyudante()

            'hlamas 04-01-2019
            'ListarTipo()
            Listar()
            'CargarCombos()

            Me.Estado(Me.DgvLista, 0)
            Me.btnVerRuta.Enabled = False

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Programación de Ruta", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolNuevo.Click
        Nuevo()
        Refrescar(bNuevo)
        Me.Estado(Me.DgvLista, 1)
    End Sub

    Sub Nuevo()
        bNuevo = True
        'Me.lblFechaProgramacion.Text = Format(FechaServidor(), "Short Date")
        Me.dtpFechaProgramacion.Value = Format(FechaServidor(), "Short Date")
        Me.dtpFechaProgramacion.Enabled = True
        CargarCombos()

        'hlamas 04-01-2018
        'Me.CboTipoRuta.Enabled = True
        Me.CboRuta.Enabled = True
        Me.cboProveedor.Enabled = True

        'Me.DtpHora.Text = Format(FechaServidor(), "Short Date")

        bInicio = True

        Me.TabProgramacion.SelectedIndex = 1
        bInicio = False

        'hlamas 04-01-2018
        'Me.CboTipoRuta.SelectedValue = 0

        Me.CboRuta.SelectedValue = 0
        Me.CboMovil.SelectedValue = 0
        Me.CboChofer.SelectedValue = 0
        Me.CboAyudante.SelectedValue = 0
        Me.DgvAyudante.Rows.Clear()

        'hlamas 04-01-2018
        'Me.CboTipoRuta.Focus()
    End Sub

    Private Sub ToolSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolSalir.Click
        Close()
    End Sub

    Private Sub CboAyudante_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAyudante.SelectedIndexChanged
        If Not (IsReference(Me.CboAyudante.SelectedValue)) Then
            If Me.CboAyudante.SelectedValue = 0 Then
                Me.BtnAgregar.Enabled = False
            Else
                Me.BtnAgregar.Enabled = True
                Me.BtnAgregar.Focus()
            End If
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        AgregarAyudante()
    End Sub

    Sub AgregarAyudante()
        With Me.DgvAyudante
            If Not Agregado(Me.CboAyudante.SelectedValue, Me.DgvAyudante) Then
                .Rows.Add()
                .Rows(.Rows.Count - 1).Cells(0).Value = Me.CboAyudante.SelectedValue
                .Rows(.Rows.Count - 1).Cells(1).Value = Me.CboAyudante.Text
                Me.DgvAyudante.Focus()
            Else
                MessageBox.Show("El ayudante ya existe en la lista", "Programación de Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.CboAyudante.Focus()
            End If
        End With
    End Sub

    Function Agregado(ByVal ayudante As Integer, ByVal dgv As DataGridView) As Boolean
        For Each row As DataGridViewRow In dgv.Rows
            If row.Cells("id_ayudante").Value = ayudante Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub DgvAyudante_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DgvAyudante.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            'ToolGrabar_Click(sender, e)
        End If
    End Sub

    Private Sub DgvAyudante_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DgvAyudante.RowsAdded
        If Me.DgvAyudante.Rows.Count = 0 Then
            Me.BtnEliminar.Enabled = False
        Else
            Me.BtnEliminar.Enabled = True
        End If
    End Sub

    Private Sub DgvAyudante_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DgvAyudante.RowsRemoved
        If Me.DgvAyudante.Rows.Count = 0 Then
            Me.BtnEliminar.Enabled = False
        Else
            Me.BtnEliminar.Enabled = True
        End If
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        EliminarAyudante()
    End Sub

    Sub EliminarAyudante()
        With Me.DgvAyudante
            .Rows.Remove(.CurrentRow)
        End With
    End Sub

    Function Grabar() As Integer
        Try
            Dim obj As New DtoProgramacion
            If Not bNuevo Then
                obj.id = Me.DgvLista.CurrentRow.Cells("programacion").Value
            End If
            'obj.Fecha = Me.lblFechaProgramacion.Text
            obj.Fecha = Me.dtpFechaProgramacion.Text
            'obj.Hora = Me.lblFechaProgramacion.Text & " " & Me.DtpHora.Text.ToString.Substring(0, 5) & IIf(Me.DtpHora.Text.ToString.Substring(6, 1).ToUpper = "A", " am", " pm")
            obj.Hora = Me.dtpFechaProgramacion.Text & " " & Me.DtpHora.Text.ToString.Substring(0, 5) & IIf(Me.DtpHora.Text.ToString.Substring(6, 1).ToUpper = "A", " am", " pm")
            obj.Usuario = dtoUSUARIOS.IdLogin
            obj.Ip = dtoUSUARIOS.IP '"192.168.50.52"
            obj.Ruta = Me.CboRuta.SelectedValue
            obj.Movil = Me.CboMovil.SelectedValue
            obj.Chofer = Me.CboChofer.SelectedValue
            obj.Proveedor = Me.cboProveedor.SelectedValue
            obj.NumeroMovil = Me.txtNumeroMovil.Text
            Dim i As Integer = obj.Grabar(IIf(bNuevo, 1, 2))
            Return i

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Sub Listar()
        Try
            Dim obj As New DtoProgramacion
            'hlamas 04-01-2019
            'Dim dt As DataTable = obj.Listar(Me.DtpFecha.Text, Me.CboTipo.SelectedValue)
            Dim dt As DataTable = obj.Listar(Me.dtpInicio.Value.ToShortDateString, Me.dtpFin.Value.ToShortDateString, 0, dtoUSUARIOS.m_idciudad)
            Me.DgvLista.DataSource = dt
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub GrabarAyudante(ByVal programacion As Integer)
        Try
            For Each row As DataGridViewRow In Me.DgvAyudante.Rows
                Dim obj As New DtoProgramacion
                obj.Usuario = dtoUSUARIOS.IdLogin
                obj.Ip = dtoUSUARIOS.IP '"192.168.50.52"
                obj.Ayudante = row.Cells("id_ayudante").Value
                obj.id = programacion
                obj.GrabarAyudante()
            Next

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub ToolGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolGrabar.Click
        Try
            'hlamas 04-01-2018
            'If Me.CboTipoRuta.SelectedValue = 0 Then
            '    MessageBox.Show("Seleccione Tipo de la Ruta.", "Programación de Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.CboTipoRuta.Focus()
            '    Return
            'End If

            If Me.CboRuta.SelectedValue = 0 Then
                MessageBox.Show("Seleccione una Ruta", "Programación de Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.CboRuta.Focus()
                Me.CboRuta.DroppedDown = True
                Return
            End If

            If Me.CboMovil.SelectedValue = 0 Then
                MessageBox.Show("Seleccione una Móvil", "Programación de Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.CboMovil.Focus()
                Me.CboMovil.DroppedDown = True
                Return
            End If

            If Me.CboChofer.SelectedValue = 0 Then
                MessageBox.Show("Seleccione un Chofer", "Programación de Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.CboChofer.Focus()
                Me.CboChofer.DroppedDown = True
                Return
            End If

            If Me.txtNumeroMovil.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nº de Dispositivo Móvil", "Programación de Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtNumeroMovil.Focus()
                Return
            End If

            'If Me.DgvAyudante.Rows.Count = 0 Then
            '    MessageBox.Show("Seleccione al menos un Ayudante", "Programación de Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    If CboAyudante.SelectedValue = 0 Then
            '        Me.CboAyudante.Focus()
            '        Me.CboAyudante.DroppedDown = True
            '    Else
            '        Me.BtnAgregar.Focus()
            '    End If
            '    Return
            'End If
            Dim iProgramacion As Integer = Grabar()
            If iProgramacion > 0 Then   'actualizar ayudantes
                If Me.DgvAyudante.Rows.Count > 0 Then
                    Me.GrabarAyudante(iProgramacion)
                End If
            End If

            MessageBox.Show("Programación actualizada", "Programación de Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim iFila As Integer
            If Me.DgvLista.Rows.Count > 0 Then
                iFila = Me.DgvLista.CurrentCell.RowIndex
            End If
            Listar()
            If Me.DgvLista.Rows.Count > 0 Then
                Me.DgvLista.CurrentCell = Me.DgvLista.Rows(iFila).Cells(0)
            End If
            Me.TabProgramacion.SelectedIndex = 0
            Me.btnConsultar.Focus()

            'If bNuevo Then
            '    CargarCombos()
            '    Refrescar(bNuevo)
            '    Nuevo()
            'Else
            'iChofer = Me.CboChofer.SelectedValue
            'CargarCombos()
            'Refrescar(bNuevo)
            'ToolEditar_Click(sender, e)
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Programación de Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub ToolEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolEditar.Click
        Try
            bNuevo = False
            CargarCombos()
            'Dim iTipo As Integer = Me.DgvLista.CurrentRow.Cells("id_tipo").Value
            Dim iProgramacion As Integer = Me.DgvLista.CurrentRow.Cells("programacion").Value
            'Dim iRuta As Integer = Me.DgvLista.CurrentRow.Cells("id_ruta").Value
            'Dim iMovil As Integer = Me.DgvLista.CurrentRow.Cells("id_movil").Value
            'Dim iChofer As Integer = Me.DgvLista.CurrentRow.Cells("id_chofer").Value

            'Refrescar(bNuevo, iRuta, iMovil, iChofer)

            Editar(iProgramacion)
            Me.TabProgramacion.SelectedIndex = 1

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Programación de Ruta", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Editar(ByVal id As Integer)
        Try
            Me.Cursor = Cursors.AppStarting
            Dim obj As New DtoProgramacion
            Dim ds As DataSet = obj.Listar(id)
            Dim dt As DataTable = ds.Tables(0)
            Dim dt1 As DataTable = ds.Tables(1)

            If dt.Rows.Count > 0 Then
                'hlamas 04-01-2018
                'Me.CboTipoRuta.SelectedValue = dt.Rows(0).Item("id_tipo")
                'Me.lblFechaProgramacion.Text = dt.Rows(0).Item("fecha")
                Me.dtpFechaProgramacion.Value = dt.Rows(0).Item("fecha")
                Me.dtpFechaProgramacion.Enabled = False

                Me.DtpHora.Text = dt.Rows(0).Item("hora")
                Me.CboRuta.SelectedValue = dt.Rows(0).Item("ruta")

                Me.cboProveedor.SelectedValue = dt.Rows(0).Item("proveedor")

                Me.CboMovil.SelectedValue = dt.Rows(0).Item("movil")
                Me.CboChofer.SelectedValue = dt.Rows(0).Item("chofer")
                iChofer = dt.Rows(0).Item("chofer")

                Me.txtNumeroMovil.Text = "" + dt.Rows(0).Item("numero_movil")

                Me.DgvAyudante.Rows.Clear()
                If dt1.Rows.Count > 0 Then
                    For Each row As DataRow In dt1.Rows
                        With Me.DgvAyudante
                            .Rows.Add()
                            .Rows(.Rows.Count - 1).Cells(0).Value = row("id_ayudante")
                            .Rows(.Rows.Count - 1).Cells(1).Value = row("nombres")
                        End With
                    Next
                End If

                'hlamas 04-01-2018
                'Me.CboTipoRuta.Enabled = False
                Me.CboRuta.Enabled = False
                Me.cboProveedor.Enabled = False
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub ToolAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolAnular.Click
        Try
            Dim dlgRespuesta As DialogResult
            Dim iProgramacion As Integer = Me.DgvLista.CurrentRow.Cells("programacion").Value
            Dim sMensaje As String = "¿Está Seguro de Anular la Programación del día " & Me.dtpInicio.Text & vbCrLf & " para la Ruta " & Me.DgvLista.CurrentRow.Cells("ruta").Value & "?"
            dlgRespuesta = MessageBox.Show(sMensaje, "Programación de Ruta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Anular(iProgramacion)
                sMensaje = "La Programación del día " & Me.dtpInicio.Text & vbCrLf & " para la Ruta " & Me.DgvLista.CurrentRow.Cells("ruta").Value & " ha sido Anulada."
                MessageBox.Show(sMensaje, "Programación de Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Listar()
                CargarCombos()
                Refrescar(bNuevo)
                Me.Estado(Me.DgvLista, 0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Programación de Ruta", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarTipo()
        'hlamas 04-01-2019
        'Try
        '    Dim obj As New DtoProgramacion
        '    Dim ds As DataSet = obj.ListarTipo
        '    Me.CboTipo.DataSource = ds.Tables(0)
        '    Me.CboTipo.DisplayMember = "procesos"
        '    Me.CboTipo.ValueMember = "idprocesos"
        'Catch ex As Exception
        '    Throw New Exception(ex.Message)
        'End Try
    End Sub

    'hlamas 04-01-2019
    'Private Sub CboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipo.SelectedIndexChanged
    '    If Not IsReference(Me.CboTipo.SelectedValue) Then
    '        Me.Listar()
    '        Me.Estado(Me.DgvLista, 0)
    '    End If
    'End Sub

    Sub Estado(ByVal dgv As DataGridView, ByVal tab As Integer)
        If tab = 0 Then
            If dgv.Rows.Count = 0 Then
                Me.ToolEditar.Enabled = False
                Me.ToolAnular.Enabled = False
            Else
                Me.ToolEditar.Enabled = True
                Me.ToolAnular.Enabled = True
            End If
            Me.ToolGrabar.Enabled = False
        ElseIf tab = 1 Then
            If bNuevo Then
                Me.ToolGrabar.Enabled = True
                Me.DtpHora.Enabled = True
                Me.CboMovil.Enabled = True
                Me.CboChofer.Enabled = True
                Me.CboAyudante.Enabled = True
                Me.BtnAgregar.Enabled = False
                Me.BtnEliminar.Enabled = False
            Else
                If Me.DgvLista.CurrentRow.Cells("fecha").Value = Format(FechaServidor, "Short Date") Then
                    Me.ToolGrabar.Enabled = True
                    Me.DtpHora.Enabled = True
                    Me.CboMovil.Enabled = True
                    Me.CboChofer.Enabled = True
                    Me.CboAyudante.Enabled = True
                    Me.BtnEliminar.Enabled = True
                Else
                    Me.ToolGrabar.Enabled = False
                    Me.DtpHora.Enabled = False
                    Me.CboMovil.Enabled = False
                    Me.CboChofer.Enabled = False
                    Me.CboAyudante.Enabled = False
                    Me.BtnEliminar.Enabled = False
                End If
            End If
            Me.ToolEditar.Enabled = False
            Me.ToolAnular.Enabled = False
            End If
    End Sub

    Sub Anular(ByVal programacion As Integer)
        Try
            Dim obj As New DtoProgramacion
            obj.Usuario = dtoUSUARIOS.IdLogin
            obj.Ip = dtoUSUARIOS.IP '"192.168.50.52"
            obj.Anular(programacion)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub TabProgramacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabProgramacion.SelectedIndexChanged
        Try
            If bInicio Then Return
            If TabProgramacion.SelectedIndex = 1 Then
                If Me.DgvLista.Rows.Count > 0 Then
                    Me.Cursor = Cursors.AppStarting
                    Me.ToolEditar_Click(sender, e)
                    Me.Cursor = Cursors.Default
                Else
                    Me.Nuevo()
                End If
            End If
            Estado(Me.DgvLista, Me.TabProgramacion.SelectedIndex)
            FormatoDgvLista()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Programación de Ruta", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CargarCombos(ByVal proveedor As Integer)
        Dim obj As New DtoProgramacion
        ds = obj.Inicio2(dtoUSUARIOS.m_idciudad, proveedor)
        With CboMovil
            .DataSource = ds.Tables(0)
            .DisplayMember = "movil"
            .ValueMember = "id_movil"
        End With

        With CboChofer
            .DataSource = ds.Tables(1)
            .DisplayMember = "nombres"
            .ValueMember = "id_chofer"
        End With

        With CboAyudante
            .DataSource = ds.Tables(2)
            .DisplayMember = "nombres"
            .ValueMember = "id_ayudante"
        End With
    End Sub

    Sub CargarCombos()
        Dim obj As New DtoProgramacion
        If bNuevo Then
            'obj.Fecha = Me.lblFechaProgramacion.Text
            obj.Fecha = Me.dtpFechaProgramacion.Value.ToShortDateString
        Else
            obj.Fecha = Me.DgvLista.CurrentRow.Cells("fecha").Value
        End If

        ds = obj.Inicio(dtoUSUARIOS.m_idciudad)
        With CboRuta
            .DataSource = ds.Tables(0)
            .DisplayMember = "ruta"
            .ValueMember = "id_ruta"
        End With

        With cboProveedor
            .DisplayMember = "nombres"
            .ValueMember = "id_proveedor"
            .DataSource = ds.Tables(1)
            .SelectedValue = 0
        End With
    End Sub

    Private Sub DgvLista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvLista.DoubleClick
        If DgvLista.Rows.Count > 0 Then
            ToolEditar_Click(sender, e)
        End If
    End Sub

    Sub Refrescar(ByVal estado As Boolean, Optional ByVal ruta As Integer = 0, _
    Optional ByVal movil As Integer = 0, Optional ByVal chofer As Integer = 0)
        Return
        If estado Then
            'hlamas 04-01-2018
            'ds.Tables(0).DefaultView.RowFilter = "programacion<=0 and tipo=" & Me.CboTipoRuta.SelectedValue
            'ds.Tables(0).DefaultView.RowFilter = "programacion<=0"
            'ds.Tables(1).DefaultView.RowFilter = "programacion<=0"
            'ds.Tables(2).DefaultView.RowFilter = "programacion<=0"
            ds.Tables(0).DefaultView.RowFilter = "programacion=0"
            ds.Tables(1).DefaultView.RowFilter = "programacion=0"
            ds.Tables(2).DefaultView.RowFilter = "programacion=0"
        Else
            'hlamas 04-01-2018
            'ds.Tables(0).DefaultView.RowFilter = "programacion<=0 or id_ruta=" & ruta & " "
            'ds.Tables(1).DefaultView.RowFilter = "programacion<=0 or id_movil=" & movil & " "
            'ds.Tables(2).DefaultView.RowFilter = "programacion<=0 or id_chofer=" & chofer & " "
            ds.Tables(0).DefaultView.RowFilter = "programacion=0 or id_ruta=" & ruta & " "
            ds.Tables(1).DefaultView.RowFilter = "programacion=0 or id_movil=" & movil & " "
            ds.Tables(2).DefaultView.RowFilter = "programacion=0 or id_chofer=" & chofer & " "
        End If
    End Sub

    Private Sub CboMovil_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMovil.SelectedIndexChanged
        Return
        If Not IsReference(Me.CboMovil.SelectedValue) Then
            Dim i As Integer = Me.CboMovil.SelectedValue
            Dim iTipo As Integer = BuscarTipoMovil(i, ds.Tables(1))
            If iTipo = 83 Then
                If bNuevo Then
                    ds.Tables(2).DefaultView.RowFilter = "(tipo=" & iTipo & " and programacion=0) or id_chofer=0"
                Else
                    ds.Tables(2).DefaultView.RowFilter = "(tipo=" & iTipo & "and (programacion=0 or id_chofer=" & iChofer & ")) or id_chofer=0"
                End If
            Else
                If bNuevo Then
                    ds.Tables(2).DefaultView.RowFilter = "(tipo<>" & iTipo & " and programacion=0) or id_chofer=0 "
                Else
                    ds.Tables(2).DefaultView.RowFilter = "(tipo<>" & iTipo & " and (programacion=0 or id_chofer=" & iChofer & ")) or id_chofer=0 "
                    If Me.CboMovil.SelectedValue > 0 And Me.CboChofer.Items.Count > 0 Then
                        Me.CboChofer.SelectedValue = iChofer
                    End If
                End If
            End If
        End If
    End Sub

    Function BuscarTipoMovil(ByVal movil As Integer, ByVal dt As DataTable) As Integer
        For Each row As DataRow In dt.Rows
            If row.Item("id_movil") = movil Then
                Return row.Item("tipo")
            End If
        Next
        Return 0
    End Function

    'hlamas 04-01-2018
    'Private Sub CboTipoRuta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoRuta.SelectedIndexChanged
    '    If Not IsReference(Me.CboTipoRuta.SelectedValue) Then
    '        ds.Tables(0).DefaultView.RowFilter = "programacion<=0 and tipo=" & Me.CboTipoRuta.SelectedValue & " or tipo=0"
    '    End If
    'End Sub

    Private Sub CboRuta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboRuta.SelectedIndexChanged
        Me.btnVerRuta.Enabled = Me.CboRuta.SelectedIndex > 0
    End Sub

    Private Sub btnVerRuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerRuta.Click
        Dim frm As New frmRutaDetalle
        frm.Ruta = Me.CboRuta.SelectedValue
        frm.RutaDescripcion = Me.CboRuta.Text
        frm.ShowDialog()
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Try
            Cursor = Cursors.AppStarting
            Me.Listar()
            Me.Estado(Me.DgvLista, 0)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Programación de Ruta", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProveedor.SelectedIndexChanged
        If IsReference(Me.cboProveedor.SelectedValue) Then Return
        CargarCombos(Me.cboProveedor.SelectedValue)
        Me.DgvAyudante.Rows.Clear()
    End Sub

    Private Sub dtpFechaProgramacion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaProgramacion.ValueChanged
        CargarCombos()
    End Sub

    Private Sub CboChofer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboChofer.SelectedIndexChanged
        If IsReference(Me.CboChofer.SelectedValue) Then Return
        Dim obj As New DtoProgramacion
        Dim dt As DataTable = obj.SugerirNmeroMovil(Me.CboChofer.SelectedValue)
        If dt.Rows.Count > 0 Then
            Me.txtNumeroMovil.Text = "" & dt.Rows(0).Item(0)
        Else
            Me.txtNumeroMovil.Text = ""
        End If
    End Sub

    Private Sub txtNumeroMovil_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroMovil.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.CboAyudante.Focus()
        Else
            e.Handled = Not ValidarNumero(e.KeyChar)
        End If

    End Sub
End Class