Imports INTEGRACION_LN
Imports INTEGRACION_EN

Public Class frmDevolucionCargo
    Public hnd As Long

    Sub FormatearDGVLista()
        With dgvLista
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvLista)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.7!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = False
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
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 35
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .HeaderText = "Nº Doc." : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_numero_documento As New DataGridViewTextBoxColumn
            With col_numero_documento
                .Name = "numero_documento" : .DataPropertyName = "numero_documento"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Ruc/Dni"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Razón Social"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Width = 235 '280 '325
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo_facturacion As New DataGridViewTextBoxColumn
            With col_tipo_facturacion
                .Name = "tipo_facturacion" : .DataPropertyName = "tipo_facturacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Fac."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.Width = 235 '280 '325
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,##                #0.00"
            End With
            x += +1
            Dim col_idtipo_comprobante As New DataGridViewTextBoxColumn
            With col_idtipo_comprobante
                .Name = "idtipo_comprobante" : .DataPropertyName = "idtipo_comprobante"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo_comprobante"
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With
            x += +1
            Dim col_idpersona As New DataGridViewTextBoxColumn
            With col_idpersona
                .Name = "idpersona" : .DataPropertyName = "idpersona"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idpersona"
            End With

            x += +1
            Dim col_liquidacion_cargo As New DataGridViewTextBoxColumn
            With col_liquidacion_cargo
                .Name = "liquidacion_cargo" : .DataPropertyName = "liquidacion_cargo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Liquidación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_devolucion As New DataGridViewTextBoxColumn
            With col_fecha_devolucion
                .Name = "fecha_devolucion" : .DataPropertyName = "fecha_devolucion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Devolución"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_usuario_devolucion As New DataGridViewTextBoxColumn
            With col_usuario_devolucion
                .Name = "usuario_devolucion" : .DataPropertyName = "usuario_devolucion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario Devolución"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_recepcion As New DataGridViewTextBoxColumn
            With col_fecha_recepcion
                .Name = "fecha_recepcion" : .DataPropertyName = "fecha_recepcion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Recepción"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_usuario_recepcion As New DataGridViewTextBoxColumn
            With col_usuario_recepcion
                .Name = "usuario_recepcion" : .DataPropertyName = "usuario_recepcion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario Recepción"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_estado_cargo As New DataGridViewTextBoxColumn
            With col_estado_cargo
                .Name = "estado_cargo" : .DataPropertyName = "estado_cargo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado Cargo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_tipo, col_comprobante, col_fecha, col_numero_documento, col_cliente, col_tipo_facturacion, _
                              col_estado, col_cantidad, col_peso, _
                              col_origen, col_destino, col_idtipo_comprobante, col_id, col_total, col_idpersona, _
                              col_liquidacion_cargo, col_fecha_devolucion, col_usuario_devolucion, col_fecha_recepcion, _
                              col_usuario_recepcion, col_estado_cargo)
        End With
    End Sub
    Sub FormatearDGVCargo()
        With dgvCargo
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvLista)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.7!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = False
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
            Dim col_serie As New DataGridViewTextBoxColumn
            With col_serie
                .Name = "serie" : .DataPropertyName = "serie"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Serie"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero"
                .DisplayIndex = x : .HeaderText = "Nº Documento" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With

            .Columns.AddRange(col_serie, col_numero, col_id)
        End With
    End Sub
    Sub Inicio()
        Dim obj As New Cls_DevolucionCargo_LN
        Dim dt As DataTable = obj.Inicio.Tables(0)

        With Me.cboOrigen
            .DisplayMember = "ciudad"
            .ValueMember = "id"
            .DataSource = dt
            .SelectedIndex = 0
        End With

        With Me.cboDestino
            .DisplayMember = "ciudad"
            .ValueMember = "id"
            .DataSource = dt.Copy
            .SelectedIndex = 0
        End With

        FormatearDGVLista()
        FormatearDGVCargo()
    End Sub

    Private Sub frmDevolucionCargo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Inicio()
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Try
            Cursor = Cursors.WaitCursor
            ListarCarga()
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarCarga()
        Dim obj_AD As New Cls_DevolucionCargo_LN
        Dim obj_EN As New Cls_EntregaCarga_EN

        If Val(Me.txtNumeroCargo.Text) > 0 Then
            Dim intSerie As Integer, intNumero As Integer

            intSerie = Val(Me.txtSerieCargo.Text)
            intNumero = Val(Me.txtNumeroCargo.Text)
            Me.dgvLista.DataSource = obj_AD.ListarCarga(intSerie, intNumero, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
        Else
            If Me.txtNumeroDocumento.Text.Trim.Length > 0 Then
                obj_EN.SerieComprobante = "0"
                obj_EN.NumeroComprobante = "0"
                obj_EN.Nombres = ""
                obj_EN.NumeroDocumento = Me.txtNumeroDocumento.Text.Trim
            ElseIf Me.txtCliente.Text.Trim.Length > 0 Then
                obj_EN.SerieComprobante = "0"
                obj_EN.NumeroComprobante = "0"
                obj_EN.NumeroDocumento = ""
                obj_EN.Nombres = Me.txtCliente.Text.Trim
            ElseIf Me.txtNumeroComprobante.Text.Trim.Length > 0 Then
                obj_EN.NumeroDocumento = ""
                obj_EN.Nombres = ""

                Dim strNumeroComprobante As String() = Split(txtNumeroComprobante.Text, "-")
                If strNumeroComprobante.Length > 1 Then
                    If Val(strNumeroComprobante(0)) > 0 And Val(strNumeroComprobante(1)) > 0 Then
                        obj_EN.SerieComprobante = strNumeroComprobante(0)
                        obj_EN.NumeroComprobante = strNumeroComprobante(1)
                    Else
                        obj_EN.SerieComprobante = "0"
                        obj_EN.NumeroComprobante = "0"
                    End If
                Else
                    If strNumeroComprobante.Length = 1 Then
                        obj_EN.SerieComprobante = "0"
                        obj_EN.NumeroComprobante = strNumeroComprobante(0)
                    Else
                        obj_EN.SerieComprobante = "0"
                        obj_EN.NumeroComprobante = "0"
                    End If
                End If
            Else
                obj_EN.SerieComprobante = "0"
                obj_EN.NumeroComprobante = "0"
                obj_EN.NumeroDocumento = ""
                obj_EN.Nombres = ""
            End If

            obj_EN.FechaInicio = Me.dtpInicio.Value.ToShortDateString
            obj_EN.FechaFin = Me.dtpFin.Value.ToShortDateString

            obj_EN.Origen = Me.cboOrigen.SelectedValue
            obj_EN.Destino = Me.cboDestino.SelectedValue

            Me.dgvLista.DataSource = obj_AD.ListarCarga(obj_EN.FechaInicio, obj_EN.FechaFin, obj_EN.Origen, obj_EN.Destino, _
                                     obj_EN.NumeroDocumento, obj_EN.SerieComprobante, obj_EN.NumeroComprobante, obj_EN.Nombres)

        End If
        'Me.lblRegistros.Text = Me.dgvLista.Rows.Count
        If dgvLista.Rows.Count = 0 Then
            Me.dgvCargo.DataSource = Nothing
            Me.btnNuevo.Enabled = False
            Me.btnModificar.Enabled = False
            Me.btnAnular.Enabled = False
        Else
            Me.btnNuevo.Enabled = True
        End If
    End Sub

    Private Sub dgvLista_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.RowEnter
        ListarCargo(e.RowIndex)
    End Sub

    Sub ListarCargo(fila As Integer)
        Dim intTipo As Integer, intComprobante As Integer

        intTipo = Me.dgvLista.Rows(fila).Cells("idtipo_comprobante").Value
        intComprobante = Me.dgvLista.Rows(fila).Cells("id").Value

        Dim obj As New Cls_DevolucionCargo_LN
        Me.dgvCargo.DataSource = obj.ListarCargo(intTipo, intComprobante)

        Me.btnModificar.Enabled = Me.dgvCargo.Rows.Count > 0
        Me.btnAnular.Enabled = Me.dgvCargo.Rows.Count > 0
    End Sub

    Private Sub btnAnular_Click(sender As System.Object, e As System.EventArgs) Handles btnAnular.Click
        Try
            Dim dlgRespuesta As DialogResult

            Dim intTipo As Integer = Me.dgvLista.CurrentRow.Cells("idtipo_comprobante").Value
            Dim intComprobante As Integer = Me.dgvLista.CurrentRow.Cells("id").Value

            Dim strSerie As String = Me.dgvCargo.CurrentRow.Cells("serie").Value
            Dim strNumero As String = Me.dgvCargo.CurrentRow.Cells("numero").Value
            Dim strCargo As String

            strCargo = strSerie & "-" & strNumero

            dlgRespuesta = MessageBox.Show("¿Está seguro de Anular el Cargo " & strCargo & "?", "Anular Cargo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                AnularCargo(intTipo, intComprobante, strSerie, strNumero)
                ListarCargo(Me.dgvLista.CurrentCell.RowIndex)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Anular Cargo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub AnularCargo(tipo As Integer, comprobante As Integer, serie As String, numero As String)
        Dim strSerie As String = Me.dgvCargo.CurrentRow.Cells("serie").Value
        Dim strNumero As String = Me.dgvCargo.CurrentRow.Cells("numero").Value

        Dim obj As New Cls_DevolucionCargo_LN
        obj.AnularCargo(tipo, comprobante, serie, numero, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        Dim frm As New frmDevolucionCargoDetalle
        frm.ID = Me.dgvCargo.CurrentRow.Cells("id").Value
        frm.Tipo = Me.dgvLista.CurrentRow.Cells("tipo").Value
        frm.Comprobante = Me.dgvLista.CurrentRow.Cells("comprobante").Value
        frm.IdTipo = Me.dgvLista.CurrentRow.Cells("idtipo_comprobante").Value
        frm.IdComprobante = Me.dgvLista.CurrentRow.Cells("id").Value
        frm.Serie = Me.dgvCargo.CurrentRow.Cells("serie").Value.ToString.Trim
        frm.Numero = Me.dgvCargo.CurrentRow.Cells("numero").Value.ToString.Trim
        frm.Cliente = Me.dgvLista.CurrentRow.Cells("idpersona").Value

        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            ListarCargo(Me.dgvLista.CurrentCell.RowIndex)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        Dim frm As New frmDevolucionCargoDetalle
        frm.ID = 0
        frm.Tipo = Me.dgvLista.CurrentRow.Cells("tipo").Value
        frm.Comprobante = Me.dgvLista.CurrentRow.Cells("comprobante").Value
        frm.IdTipo = Me.dgvLista.CurrentRow.Cells("idtipo_comprobante").Value
        frm.IdComprobante = Me.dgvLista.CurrentRow.Cells("id").Value
        frm.Serie = ""
        frm.Numero = ""
        frm.Cliente = Me.dgvLista.CurrentRow.Cells("idpersona").Value

        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            ListarCargo(Me.dgvLista.CurrentCell.RowIndex)
        End If
    End Sub

    Private Sub dgvCargo_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvCargo.DoubleClick
        If Me.dgvCargo.Rows.Count > 0 Then
            btnModificar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtNumeroDocumento_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroDocumento.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If Me.txtNumeroDocumento.Text.Trim.Length >= 0 Then
                Me.btnBuscar_Click(Nothing, Nothing)
            End If
        Else
            If (Not ValidarNumero(e.KeyChar)) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If Me.txtCliente.Text.Trim.Length > 0 Then
                Me.btnBuscar_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub txtNumeroComprobante_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroComprobante.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If Me.txtNumeroComprobante.Text.Trim.Length > 0 Then
                Me.btnBuscar_Click(Nothing, Nothing)
            End If
        Else
            If Not (ValidarNumero(e.KeyChar) Or e.KeyChar = "-") Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtNumeroCargo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroCargo.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Dim intSerie As Integer = Val(Me.txtSerieCargo.Text)
            Dim intNumero As Integer = Val(Me.txtNumeroCargo.Text)

            If intNumero > 0 Then
                Me.btnBuscar_Click(Nothing, Nothing)
            End If
        Else
            If Not (ValidarNumero(e.KeyChar)) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtSerieCargo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerieCargo.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Dim intSerie As Integer = Val(Me.txtSerieCargo.Text)
            Dim intNumero As Integer = Val(Me.txtNumeroCargo.Text)

            If intSerie > 0 And intNumero > 0 Then
                Me.btnBuscar_Click(Nothing, Nothing)
            End If
        Else
            If Not (ValidarNumero(e.KeyChar)) Then
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub txtSerieCargo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerieCargo.TextChanged

    End Sub
End Class