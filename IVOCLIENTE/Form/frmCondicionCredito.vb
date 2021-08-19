Imports INTEGRACION_LN
Imports INTEGRACION_EN
Public Class frmCondicionCredito
    Dim intOperacion As Operacion
    Private intIDCliente As Integer
    Public Property IDCliente() As Integer
        Get
            Return intIDCliente
        End Get
        Set(ByVal value As Integer)
            intIDCliente = value
        End Set
    End Property

    Private strCliente As String
    Public Property Cliente() As String
        Get
            Return strCliente
        End Get
        Set(ByVal value As String)
            strCliente = value
        End Set
    End Property


    Private Sub ConfigurarDGVSolicitud()
        With dgvSolicitud
            Cls_Utilitarios.FormatDataGridView(dgvSolicitud)
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
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
            End With
            x += +1
            Dim col_condicion As New DataGridViewTextBoxColumn
            With col_condicion
                .Name = "condicion" : .DataPropertyName = "condicion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Condicion"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
            End With
            x += +1
            Dim col_aprobacion As New DataGridViewTextBoxColumn
            With col_aprobacion
                .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aprobación"
            End With
            x += +1
            Dim col_desaprobacion As New DataGridViewTextBoxColumn
            With col_desaprobacion
                .Name = "fecha_desaprobacion" : .DataPropertyName = "fecha_desaprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Desaprobación"
            End With
            x += +1
            Dim col_anulacion As New DataGridViewTextBoxColumn
            With col_anulacion
                .Name = "fecha_anulacion" : .DataPropertyName = "fecha_anulacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Anulación"
            End With
            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Observacion"
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id"
            End With
            x += +1
            Dim col_idestado As New DataGridViewTextBoxColumn
            With col_idestado
                .Name = "idestado" : .DataPropertyName = "idestado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id estado"
            End With
            x += +1
            Dim col_idcondicion As New DataGridViewTextBoxColumn
            With col_idcondicion
                .Name = "idcondicion" : .DataPropertyName = "idcondicion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcondicion"
            End With

            .Columns.AddRange(col_solicitud, col_fecha, col_cliente, col_condicion, col_estado, _
                              col_aprobacion, col_desaprobacion, col_anulacion, _
                              col_observacion, col_id, col_idestado, col_idcondicion)
        End With
    End Sub
    Private Sub frmCondicionCredito_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ConfigurarDGVSolicitud()
        CargarCondicionCredito()

        intOperacion = Operacion.Nuevo
        Me.lblFecha.Text = Format(Now, "Short Date")
        Me.lblFuncionario.Text = dtoUSUARIOS.NameLogin
        Me.lblCliente.Text = Cliente
        Me.cboEstado.SelectedIndex = 1

        If Me.dgvSolicitud.Rows.Count = 0 Then
            Me.ActivaDesactiva(-1, 0)
        Else
            Me.ActivaDesactiva(0, Me.dgvSolicitud.Rows.Count)
        End If
    End Sub

    Sub LimpiarSolicitud()
        Me.lblNumeroSolicitud.Text = ""
        Me.cboCondicionCredito.SelectedValue = 0
        Me.txtObservacion.Text = ""
    End Sub

    Sub ActivaDesactiva(estado As Integer, registros As Integer)
        Dim blnEstado As Boolean
        If estado = 1 Then
            blnEstado = True
        ElseIf estado = 0 Then
            blnEstado = False
        End If
        If estado = -1 Then
            Me.grbSolicitud.Enabled = False
            Me.grbSolicitudFacturacion.Enabled = False
            Me.btnNuevo.Enabled = True
            If registros = 0 Then
                Me.btnModificar.Enabled = False
                Me.btnAnular.Enabled = False
            Else
                Me.btnModificar.Enabled = True
                Me.btnAnular.Enabled = True
            End If
            Me.btnGrabar.Enabled = False
            Me.btnCancelar.Enabled = False
        Else
            blnEstado = estado
            Me.grbSolicitud.Enabled = blnEstado
            Me.grbSolicitudFacturacion.Enabled = blnEstado
            Me.btnNuevo.Enabled = Not blnEstado
            If registros = 0 Then
                Me.btnModificar.Enabled = False
            Else
                Me.btnModificar.Enabled = Not blnEstado
            End If
            Me.btnGrabar.Enabled = blnEstado
            Me.btnCancelar.Enabled = blnEstado
            If registros = 0 Then
                Me.btnAnular.Enabled = False
            Else
                Me.btnAnular.Enabled = Not blnEstado
            End If
        End If

        If Me.btnGrabar.Enabled Then
            Me.grbSolicitud.Enabled = False
            Me.cboEstado.Enabled = False
        Else
            Me.grbSolicitud.Enabled = True
            Me.cboEstado.Enabled = True
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        LimpiarSolicitud()
        Me.lblNumeroSolicitud.Text = dtoUtilitario.ObtieneNumeroSolicitud(dtoUSUARIOS.IdLogin, 4)
        intOperacion = Operacion.Nuevo
        ActivaDesactiva(1, dgvSolicitud.Rows.Count)
        Me.cboCondicionCredito.DroppedDown = True
        Me.cboCondicionCredito.Focus()
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        intOperacion = Operacion.Modificar
        ActivaDesactiva(1, dgvSolicitud.Rows.Count)
        Me.cboCondicionCredito.Focus()
    End Sub

    Sub MostrarSolicitud(row As Integer)
        With dgvSolicitud
            Me.lblNumeroSolicitud.Text = .Rows(row).Cells("numero_solicitud").Value
            Me.lblFecha.Text = .Rows(row).Cells("fecha_solicitud").Value
            Me.lblCliente.Text = .Rows(row).Cells("cliente").Value
            'Dim s As String = dgvSolicitudProducto.Rows(1).Cells("cliente").Value

            Me.cboCondicionCredito.SelectedValue = .Rows(row).Cells("idcondicion").Value
            Me.txtObservacion.Text = .Rows(row).Cells("observacion").Value
        End With
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        LimpiarSolicitud()
        ActivaDesactiva(0, dgvSolicitud.Rows.Count)

        If Me.dgvSolicitud.Rows.Count > 0 Then
            MostrarSolicitud(dgvSolicitud.CurrentCell.RowIndex)

        End If
        If intOperacion = Operacion.Nuevo Then
            btnNuevo.Focus()
        Else
            btnModificar.Focus()
        End If
    End Sub

    Sub AnularProducto()
        Try
            Dim objEN As New Cls_LineaCredito_EN
            Dim objLN As New Cls_LineaCredito_LN

            objEN.ID = dgvSolicitud.CurrentRow.Cells("id").Value
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP

            objLN.AnularSolicitudCondicionCredito(objEN)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarSolicitud()
        Try
            'If Me.dgvSolicitudProducto.Rows.Count = 0 Then Return
            Dim obj As New Cls_LineaCredito_LN
            Dim objEN As New Cls_LineaCredito_EN

            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.Estado = Me.cboEstado.SelectedIndex
            objEN.Cliente = intIDCliente
            dgvSolicitud.DataSource = obj.ListarSolicitudCondicionCredito(objEN.Usuario, objEN.Cliente, objEN.Estado)
            If dgvSolicitud.Rows.Count = 0 Then
                Me.ActivaDesactiva(-1, 0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAnular_Click(sender As System.Object, e As System.EventArgs) Handles btnAnular.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está Seguro de Anular la Solicitud Nº " & dgvSolicitud.CurrentRow.Cells("numero_solicitud").Value & "?", "Anular Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = vbYes Then
            AnularProducto()
            ListarSolicitud()
        End If
    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        Try
            If Me.cboCondicionCredito.SelectedValue = 0 Then
                MessageBox.Show("Seleccione Condición del Crédito", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboCondicionCredito.DroppedDown = True
                Me.cboCondicionCredito.Focus()
                Return
            End If

            If Me.txtObservacion.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Observación de la Solicitud", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtObservacion.Text = ""
                Me.txtObservacion.Focus()
                Return
            End If

            Dim intCliente As Integer = IDCliente
            If intOperacion = Operacion.Nuevo Then
                Dim objLN As New Cls_LineaCredito_LN
                Dim objEN As New Cls_LineaCredito_EN
                objEN.Cliente = intCliente
                objEN.Estado = 1
                If objLN.ExisteSolicitudCondicionCredito(objEN) Then
                    MessageBox.Show("El Cliente " & Me.lblCliente.Text & Chr(13) & " ya cuenta con una Solicitud Activa", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.btnCancelar.Focus()
                    Return
                End If
            End If

            'graba solicitud de producto
            Cursor = Cursors.WaitCursor
            Grabar()
            ListarSolicitud()
            ActivaDesactiva(0, dgvSolicitud.Rows.Count)
            Cursor = Cursors.Default
            Me.btnNuevo.Focus()

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Grabar()
        Try
            Dim objEN As New Cls_LineaCredito_EN
            Dim objLN As New Cls_LineaCredito_LN

            If intOperacion = Operacion.Nuevo Then
                objEN.ID = 0
            Else
                objEN.ID = dgvSolicitud.CurrentRow.Cells("id").Value
            End If
            objEN.NumeroSolicitud = Me.lblNumeroSolicitud.Text
            objEN.Fecha = Me.lblFecha.Text
            objEN.Cliente = IDCliente
            objEN.CondicionCobranza = Me.cboCondicionCredito.SelectedValue
            objEN.Observacion = Me.txtObservacion.Text.Trim
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP
            objLN.GrabarSolicitudCondicionCredito(objEN)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub cboEstado_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstado.SelectedIndexChanged
        Me.LimpiarSolicitud()
        ListarSolicitud()
        'Me.ActivaDesactivaCredito(0, Me.dgvSolicitudCredito.Rows.Count)
        If Me.dgvSolicitud.Rows.Count > 0 AndAlso btnNuevo.Enabled Then
            Me.btnModificar.Enabled = dgvSolicitud.CurrentRow.Cells("idestado").Value = 1
            Me.btnAnular.Enabled = dgvSolicitud.CurrentRow.Cells("idestado").Value = 1
        ElseIf Me.dgvSolicitud.Rows.Count = 0 Then
            Me.ActivaDesactiva(-1, 0)
        End If
    End Sub

    Sub CargarCondicionCredito()
        Try
            Dim objLN As New Cls_LineaCredito_LN
            Dim dt As DataTable = objLN.ListarCondicionCredito()
            With cboCondicionCredito
                .DataSource = Nothing
                .DataSource = dt
                .DisplayMember = "CONDICION"
                .ValueMember = "ID"
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub dgvSolicitud_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSolicitud.RowEnter
        If Me.btnNuevo.Enabled Then
            MostrarSolicitud(e.RowIndex)
        End If
        If btnNuevo.Enabled Then
            Me.btnModificar.Enabled = dgvSolicitud.Rows(e.RowIndex).Cells("idestado").Value = 1
            Me.btnAnular.Enabled = dgvSolicitud.Rows(e.RowIndex).Cells("idestado").Value = 1
        End If

    End Sub

    Private Sub cboCondicionCredito_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboCondicionCredito.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtObservacion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyDown
        If e.Control And e.KeyCode = Keys.Enter Then
            e.Handled = False
        ElseIf e.KeyCode = Keys.Enter Then
            txtObservacion.Text = txtObservacion.Text.Trim
            SendKeys.Send(vbTab)
        End If
    End Sub
End Class