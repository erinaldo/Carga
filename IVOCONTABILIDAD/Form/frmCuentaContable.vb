Imports INTEGRACION_LN

Public Class frmCuentaContable
#Region "Grid"
    Sub Configurardgv()
        With dgv
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
            '.RowHeadersVisible = False
            .RowHeadersWidth = 20
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
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = False
            End With

            x += +1
            Dim col_venta As New DataGridViewTextBoxColumn
            With col_venta
                .Name = "venta" : .DataPropertyName = "venta" : .DisplayIndex = x : .Visible = True : .HeaderText = "Venta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_concepto As New DataGridViewTextBoxColumn
            With col_concepto
                .Name = "concepto" : .DataPropertyName = "concepto" : .DisplayIndex = x : .Visible = True : .HeaderText = "Concepto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo" : .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_subtipo As New DataGridViewTextBoxColumn
            With col_subtipo
                .Name = "subtipo" : .DataPropertyName = "subtipo" : .DisplayIndex = x : .Visible = True : .HeaderText = "Subtipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_tipo_afectacion As New DataGridViewTextBoxColumn
            With col_tipo_afectacion
                .Name = "tipo_afectacion" : .DataPropertyName = "tipo_afectacion" : .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Afectación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_moneda As New DataGridViewTextBoxColumn
            With col_moneda
                .Name = "moneda" : .DataPropertyName = "moneda"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Moneda"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_cuenta_cliente As New DataGridViewTextBoxColumn
            With col_cuenta_cliente
                .Name = "cuenta_cliente" : .DataPropertyName = "cuenta_cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cuenta Cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_cuenta_impuesto As New DataGridViewTextBoxColumn
            With col_cuenta_impuesto
                .Name = "cuenta_impuesto" : .DataPropertyName = "cuenta_impuesto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cuenta Impuesto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_cuenta_venta As New DataGridViewTextBoxColumn
            With col_cuenta_venta
                .Name = "cuenta_venta" : .DataPropertyName = "cuenta_venta"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cuenta Venta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_cuenta_costo As New DataGridViewTextBoxColumn
            With col_cuenta_costo
                .Name = "cuenta_costo" : .DataPropertyName = "cuenta_costo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Centro Costo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_actividad As New DataGridViewTextBoxColumn
            With col_actividad
                .Name = "actividad" : .DataPropertyName = "actividad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cuenta Actividad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_tipo_movimiento_cliente As New DataGridViewTextBoxColumn
            With col_tipo_movimiento_cliente
                .Name = "tipo_movimiento_cliente" : .DataPropertyName = "tipo_movimiento_cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Movimiento Cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_tipo_movimiento_impuesto As New DataGridViewTextBoxColumn
            With col_tipo_movimiento_impuesto
                .Name = "tipo_movimiento_impuesto" : .DataPropertyName = "tipo_movimiento_impuesto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Movimiento Impuesto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_tipo_movimiento_venta As New DataGridViewTextBoxColumn
            With col_tipo_movimiento_venta
                .Name = "tipo_movimiento_venta" : .DataPropertyName = "tipo_movimiento_venta"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Movimiento Venta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_id_concepto As New DataGridViewTextBoxColumn
            With col_id_concepto
                .Name = "id_concepto" : .DataPropertyName = "id_concepto" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_concepto"
            End With

            x += +1
            Dim col_id_tipo As New DataGridViewTextBoxColumn
            With col_id_tipo
                .Name = "id_tipo" : .DataPropertyName = "id_tipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_tipo"
            End With

            x += +1
            Dim col_idtipo_afectacion As New DataGridViewTextBoxColumn
            With col_idtipo_afectacion
                .Name = "idtipo_afectacion" : .DataPropertyName = "idtipo_afectacion" : .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo_afectacion"
            End With

            x += +1
            Dim col_id_moneda As New DataGridViewTextBoxColumn
            With col_id_moneda
                .Name = "id_moneda" : .DataPropertyName = "id_moneda" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_moneda"
            End With

            x += +1
            Dim col_id_subtipo As New DataGridViewTextBoxColumn
            With col_id_subtipo
                .Name = "id_subtipo" : .DataPropertyName = "id_subtipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_subtipo"
            End With

            x += +1
            Dim col_idtipo_movimiento_cliente As New DataGridViewTextBoxColumn
            With col_idtipo_movimiento_cliente
                .Name = "idtipo_movimiento_cliente" : .DataPropertyName = "idtipo_movimiento_cliente"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo_movimiento_cliente"
            End With

            x += +1
            Dim col_idtipo_movimiento_impuesto As New DataGridViewTextBoxColumn
            With col_idtipo_movimiento_impuesto
                .Name = "idtipo_movimiento_impuesto" : .DataPropertyName = "idtipo_movimiento_impuesto"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo_movimiento_impuesto"
            End With

            x += +1
            Dim col_idtipo_movimiento_venta As New DataGridViewTextBoxColumn
            With col_idtipo_movimiento_venta
                .Name = "idtipo_movimiento_venta" : .DataPropertyName = "idtipo_movimiento_venta"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo_movimiento_venta"
            End With

            x += +1
            Dim col_idventa As New DataGridViewTextBoxColumn
            With col_idventa
                .Name = "idventa" : .DataPropertyName = "idventa"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idventa"
            End With


            .Columns.AddRange(col_id, col_venta, col_concepto, col_tipo, col_subtipo, col_tipo_afectacion, col_moneda, col_cuenta_cliente, col_cuenta_impuesto, _
                              col_cuenta_venta, col_cuenta_costo, col_actividad, col_tipo_movimiento_cliente, col_tipo_movimiento_impuesto, col_tipo_movimiento_venta, _
                              col_id_concepto, col_id_tipo, col_idtipo_afectacion, col_id_moneda, col_id_subtipo, _
                              col_idtipo_movimiento_cliente, col_idtipo_movimiento_impuesto, col_idtipo_movimiento_venta, col_idventa)
        End With
    End Sub
#End Region

    Sub ListarTipoComprobante()
        Dim obj As New Cls_Contabilidad_LN
        Dim dt As DataTable = obj.ListarTipoComprobante(1, 0)
        With Me.cboTipoComprobante
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = dt
            .SelectedValue = 0
        End With
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Try
            Cursor = Cursors.WaitCursor
            ListarCuentaContable(Me.cboVenta.SelectedIndex, Me.cboConcepto.SelectedIndex, Me.cboTipoComprobante.SelectedValue, Me.cboTipoAfectacion.SelectedIndex, Me.cboMoneda.SelectedIndex)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarCuentaContable(ByVal venta As Integer, ByVal concepto As Integer, ByVal tipo_comprobante As Integer, ByVal tipo_afectacion As Integer, ByVal moneda As Integer)
        Dim obj As New Cls_Contabilidad_LN

        Dim dt As DataTable = obj.ListarCuentaContable(venta, concepto, tipo_comprobante, tipo_afectacion, moneda)
        Me.dgv.DataSource = dt

        If dt.Rows.Count = 0 Then
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
        End If
    End Sub

    Private Sub frmCuentaContable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Configurardgv()

        Me.ListarTipoComprobante()
        Me.cboVenta.SelectedIndex = 0
        Me.cboConcepto.SelectedIndex = 0
        Me.cboTipoAfectacion.SelectedIndex = 0
        Me.cboMoneda.SelectedIndex = 0
    End Sub

    Private Sub dgv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv.DoubleClick
        If Me.dgv.Rows.Count > 0 Then
            Me.tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub dgv_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.RowEnter
        If Me.dgv.Rows.Count > 0 Then
            Me.tsbEditar.Enabled = True
            Me.tsbAnular.Enabled = True
        End If
    End Sub

    Private Sub tsbAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAnular.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está seguro de anular la cuenta contable?", "Anular", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            Dim obj As New Cls_Contabilidad_LN
            obj.AnularCuentaContable(Me.dgv.CurrentRow.Cells("id").Value, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
            Me.btnConsultar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frm As New frmCuentaContableDetalle
            With Me.dgv
                frm.Id = .CurrentRow.Cells("id").Value
                frm.Venta = .CurrentRow.Cells("idventa").Value
                frm.Concepto = .CurrentRow.Cells("id_concepto").Value
                frm.TipoComprobante = .CurrentRow.Cells("id_tipo").Value
                frm.Subtipo = Val("" & .CurrentRow.Cells("id_subtipo").Value)
                frm.TipoAfectacion = .CurrentRow.Cells("idtipo_afectacion").Value
                frm.Moneda = .CurrentRow.Cells("id_moneda").Value
                frm.CuentaCliente = "" & .CurrentRow.Cells("cuenta_cliente").Value
                frm.CuentaImpuesto = "" & .CurrentRow.Cells("cuenta_impuesto").Value
                frm.CuentaVenta = "" & .CurrentRow.Cells("cuenta_venta").Value

                frm.CuentaCosto = "" & .CurrentRow.Cells("cuenta_costo").Value
                frm.CuentaActividad = "" & .CurrentRow.Cells("actividad").Value

                frm.MovimientoCliente = Val("" & .CurrentRow.Cells("idtipo_movimiento_cliente").Value)
                frm.MovimientoImpuesto = Val("" & .CurrentRow.Cells("idtipo_movimiento_impuesto").Value)
                frm.MovimientoVenta = Val("" & .CurrentRow.Cells("idtipo_movimiento_venta").Value)

                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    Me.btnConsultar_Click(Nothing, Nothing)
                End If
            End With
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Dim frm As New frmCuentaContableDetalle
        frm.Id = 0
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.btnConsultar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub
End Class