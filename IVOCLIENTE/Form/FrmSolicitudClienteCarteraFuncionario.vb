Imports INTEGRACION_LN
Imports INTEGRACION_EN
'Enum Operacion
'    Nuevo = 1
'    Modificar = 2
'End Enum

Public Class FrmSolicitudClienteCarteraFuncionario
    Dim intOperacion As Operacion
    Dim bInicio As Boolean

    Shared strNumero As String = ""

    Public hnd As Long

#Region "Configurar Grid"
    Private Sub ConfigurarDGVSolicitud()
        With dgvSolicitud
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
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
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
            Dim col_sustento As New DataGridViewTextBoxColumn
            With col_sustento
                .Name = "sustento" : .DataPropertyName = "sustento"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Sustento"
            End With
            x += +1
            Dim col_ruc As New DataGridViewTextBoxColumn
            With col_ruc
                .Name = "ruc" : .DataPropertyName = "ruc"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Ruc"
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
            .Columns.AddRange(col_solicitud, col_fecha, col_cliente, col_estado, col_aprobacion, col_desaprobacion, col_anulacion, _
                              col_sustento, col_ruc, col_id, col_idestado)
        End With
    End Sub
#End Region

    Private Sub FrmSolicitudClienteCarteraFuncionario_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        ActivaDesactiva(-1, dgvSolicitud.Rows.Count)
        Me.btnNuevo.Focus()
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnNuevo_Cick(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        Limpiar()
        Me.lblNumeroSolicitud.Text = ObtieneNumeroSolicitud()
        intOperacion = Operacion.Nuevo
        ActivaDesactiva(1, dgvSolicitud.Rows.Count)
        Me.txtRuc.Enabled = True
        Me.txtRuc.Focus()
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        intOperacion = Operacion.Modificar
        ActivaDesactiva(1, dgvSolicitud.Rows.Count)
        Me.txtRuc.Enabled = False
        Me.txtSustento.Focus()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        ActivaDesactiva(0, dgvSolicitud.Rows.Count)
        Limpiar()
        If Me.dgvSolicitud.Rows.Count > 0 Then
            MostrarSolicitud(dgvSolicitud.CurrentCell.RowIndex)
        End If
        If intOperacion = Operacion.Nuevo Then
            btnNuevo.Focus()
        Else
            btnModificar.Focus()
        End If
    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        Try
            If Me.lblRazonSocial.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese el Cliente", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtRuc.Focus()
                Return
            End If

            If intOperacion = Operacion.Nuevo Then
                Dim objLN As New Cls_ClienteCarteraFuncionario_LN
                Dim objEN As New Cls_ClienteCarteraFuncionario_EN
                objEN.Cliente = Me.lblRazonSocial.Tag
                objEN.Estado = 1
                If objLN.ExisteSolicitud(objEN) Then
                    MessageBox.Show("El Cliente " & Me.lblRazonSocial.Text & Chr(13) & " ya cuenta con una Solicitud Activa", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtRuc.Focus()
                    Return
                End If
            End If

            If Me.txtSustento.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Sustento de la Solicitud", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtSustento.Text = ""
                Me.txtSustento.Focus()
                Return
            End If

            'Dim dlgRespuesta As DialogResult
            'dlgRespuesta = MessageBox.Show("¿Está seguro de Realizar la Solicitud?", "Grabar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            'If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            Grabar()

            ListarSolicitudes()
            ActivaDesactiva(0, dgvSolicitud.Rows.Count)
            Me.lblFuncionarioActual.Text = ""
            Me.btnNuevo.Focus()
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAnular_Click(sender As System.Object, e As System.EventArgs) Handles btnAnular.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está Seguro de Anular la Solicitud Nº " & dgvSolicitud.CurrentRow.Cells("numero_solicitud").Value & "?", "Anular Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = vbYes Then
            Anular()
            ListarSolicitudes()
        End If
    End Sub

#Region "Metodos"
    Sub Anular()
        Try
            Dim objEN As New Cls_ClienteCarteraFuncionario_EN
            Dim objLN As New Cls_ClienteCarteraFuncionario_LN

            objEN.ID = dgvSolicitud.CurrentRow.Cells("id").Value
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP

            objLN.AnularSolicitud(objEN)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Grabar()
        Try
            Dim objEN As New Cls_ClienteCarteraFuncionario_EN
            Dim objLN As New Cls_ClienteCarteraFuncionario_LN

            If intOperacion = Operacion.Nuevo Then
                objEN.ID = 0
            Else
                objEN.ID = dgvSolicitud.CurrentRow.Cells("id").Value
            End If
            objEN.NumeroSolicitud = Me.lblNumeroSolicitud.Text
            objEN.Fecha = Me.lblFecha.Text
            objEN.Cliente = Me.lblRazonSocial.Tag
            objEN.Sustento = Me.txtSustento.Text.Trim
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP
            If Me.lblFuncionarioActual.Tag.ToString.Trim.Length = 0 Then
                objEN.ResponsableActual = 0
                objEN.ResponsableFechaInicio = ""
            Else
                Dim intPosicion As Integer = InStr(Me.lblFuncionarioActual.Tag.ToString.Trim, "*")
                objEN.ResponsableActual = Me.lblFuncionarioActual.Tag.ToString.Trim.Substring(0, intPosicion - 1)
                objEN.ResponsableFechaInicio = Me.lblFuncionarioActual.Tag.ToString.Trim.Substring(intPosicion)
            End If

            objLN.GrabarSolicitud(objEN)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region

    Sub ActivaDesactiva(estado As Integer, registros As Integer)
        Dim blnEstado As Boolean
        If estado = 1 Then
            blnEstado = True
        ElseIf estado = 0 Then
            blnEstado = False
        End If
        If estado = -1 Then
            Me.grbSolicitud.Enabled = False
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
            Me.dgvSolicitud.Enabled = False
            Me.cmbEstado.Enabled = False
        Else
            Me.dgvSolicitud.Enabled = True
            Me.cmbEstado.Enabled = True
        End If
    End Sub

    Private Sub txtSustento_Enter(sender As Object, e As System.EventArgs) Handles txtSustento.Enter
        Me.txtSustento.SelectAll()
    End Sub

    Private Sub txtSustento_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSustento.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim flat As Boolean = True
        If msg.WParam.ToInt32 = Keys.Enter Then
            If Me.txtSustento.Focused Then
                SendKeys.Send(vbTab)
            ElseIf Me.txtRuc.Focused Then
                If Me.txtRuc.Text.Trim.Length > 0 Then
                    ObtieneCliente(Me.txtRuc.Text.Trim)
                Else
                    SendKeys.Send(vbTab)
                End If
            Else
                flat = MyBase.ProcessCmdKey(msg, KeyData)
            End If
        Else
            flat = MyBase.ProcessCmdKey(msg, KeyData)
        End If
        Return flat
    End Function

    Private Sub txtRuc_Enter(sender As Object, e As System.EventArgs) Handles txtRuc.Enter
        Me.txtRuc.SelectAll()
    End Sub

    Private Sub txtRuc_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRuc.KeyPress
        If Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Sub ListarSolicitudes()
        Try
            Dim obj As New Cls_ClienteCarteraFuncionario_LN
            Dim objEN As New Cls_ClienteCarteraFuncionario_EN

            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.Estado = Me.cmbEstado.SelectedIndex
            dgvSolicitud.DataSource = obj.ListarSolicitud(objEN.Usuario, objEN.Estado)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function ObtieneNumeroSolicitud() As Integer
        Try
            Dim obj As New Cls_ClienteCarteraFuncionario_LN
            Dim objEN As New Cls_ClienteCarteraFuncionario_EN

            objEN.Usuario = dtoUSUARIOS.IdLogin
            Return obj.ObtieneNumeroSolicitud(objEN)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Sub MostrarSolicitud(row As Integer)
        With dgvSolicitud
            Me.lblNumeroSolicitud.Text = .Rows(row).Cells("numero_solicitud").Value
            Me.lblFecha.Text = .Rows(row).Cells("fecha_solicitud").Value
            Me.txtRuc.Text = .Rows(row).Cells("ruc").Value
            Me.lblRazonSocial.Text = .Rows(row).Cells("cliente").Value
            Me.txtSustento.Text = .Rows(row).Cells("sustento").Value
        End With
    End Sub

    Private Sub dgvSolicitud_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvSolicitud.DoubleClick
        If dgvSolicitud.Rows.Count > 0 And Me.btnGrabar.Enabled = False And dgvSolicitud.CurrentRow.Cells("idestado").Value = 1 Then
            btnModificar_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub dgvSolicitud_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSolicitud.RowEnter
        If bInicio Then Return
        MostrarSolicitud(e.RowIndex)
        Me.btnModificar.Enabled = dgvSolicitud.Rows(e.RowIndex).Cells("idestado").Value = 1
        Me.btnAnular.Enabled = dgvSolicitud.Rows(e.RowIndex).Cells("idestado").Value = 1
    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbEstado.SelectedIndexChanged
        Me.ListarSolicitudes()
    End Sub

    Public Sub Cargar(numero As String)
        strNumero = numero
    End Sub

    Private Sub ObtieneCliente(numero_documento As String)
        Try
            If Not fnValidarRUC(numero_documento) Then
                MessageBox.Show("El RUC no es Válido", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtRuc.Focus()
                Me.txtRuc.SelectAll()
                Return
            End If

            Dim obj As New Cls_ClienteCarteraFuncionario_LN
            Dim dt As DataTable = obj.ObtieneCliente(numero_documento)

            If dt.Rows.Count > 0 Then
                Dim intResponsable = IIf(dt.Rows(0).Item("idresponsable").ToString.Trim.Length = 0, 0, dt.Rows(0).Item("idresponsable"))
                If dtoUSUARIOS.IdLogin <> intResponsable Then
                    Me.lblRazonSocial.Text = dt.Rows(0).Item("razon_social")
                    Me.lblRazonSocial.Tag = dt.Rows(0).Item("cliente")
                    Me.lblFuncionarioActual.Text = IIf(dt.Rows(0).Item("funcionario").ToString.Trim.Length = 0, "SIN FUNCIONARIO", dt.Rows(0).Item("funcionario"))
                    Me.lblFuncionarioActual.Tag = IIf(dt.Rows(0).Item("idresponsable").ToString.Trim.Length = 0, "", dt.Rows(0).Item("idresponsable"))
                    If Me.lblFuncionarioActual.Tag.ToString.Trim.Length > 0 Then
                        Me.lblFuncionarioActual.Tag &= "*" & IIf(dt.Rows(0).Item("fecha_inicio").ToString.Trim.Length = 0, Nothing, dt.Rows(0).Item("fecha_inicio"))
                    End If
                    SendKeys.Send(vbTab)
                Else
                    MessageBox.Show("El Cliente ya pertenece a esta Cuenta", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Limpiar(1)
                    Me.btnSalir.Focus()
                    Me.txtRuc.Focus()
                End If
            Else
                MessageBox.Show("El Cliente no Existe", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Limpiar(1)

                Dim frm As New frmRegistrarCliente
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    Me.txtRuc.Text = strNumero
                    'Me.txtRuc_KeyPress(Nothing, Nothing)
                    Me.txtRuc.Focus()
                    ObtieneCliente(Me.txtRuc.Text.Trim)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtRuc_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRuc.TextChanged
        Limpiar(1)
    End Sub

    Sub Limpiar(Optional opcion As Integer = 0)
        If opcion = 0 Then
            Me.txtRuc.Text = ""
        End If
        Me.lblRazonSocial.Text = ""
        Me.lblFuncionarioActual.Text = ""
        Me.txtSustento.Text = ""
        Me.lblFuncionarioActual.Tag = Nothing
        Me.lblRazonSocial.Tag = Nothing
    End Sub
End Class