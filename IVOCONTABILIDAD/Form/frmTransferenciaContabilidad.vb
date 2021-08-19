Imports INTEGRACION_LN
Imports System.Data.SqlClient

Public Class frmTransferenciaContabilidad

#Region "Grid"
    Sub ConfigurardgvVenta()
        With dgvVenta
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
                .DisplayIndex = x : .Visible = True : .HeaderText = "Id"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_concepto As New DataGridViewTextBoxColumn
            With col_concepto
                .Name = "concepto" : .DataPropertyName = "concepto" : .DisplayIndex = x : .Visible = False : .HeaderText = "Concepto"
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
            Dim col_codigo_cliente As New DataGridViewTextBoxColumn
            With col_codigo_cliente
                .Name = "codigo_cliente" : .DataPropertyName = "codigo_cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_tipo_documento As New DataGridViewTextBoxColumn
            With col_tipo_documento
                .Name = "tipo_documento" : .DataPropertyName = "tipo_documento"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_serie As New DataGridViewTextBoxColumn
            With col_serie
                .Name = "serie" : .DataPropertyName = "serie"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Serie"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Número"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_fecha_vencimiento As New DataGridViewTextBoxColumn
            With col_fecha_vencimiento
                .Name = "fecha_vencimiento" : .DataPropertyName = "fecha_vencimiento" : .DisplayIndex = x : .Visible = False : .HeaderText = "fecha_vencimiento"
            End With

            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Observación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_impuesto As New DataGridViewTextBoxColumn
            With col_impuesto
                .Name = "impuesto" : .DataPropertyName = "impuesto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Impuesto" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "0.00"
                .ReadOnly = True
                .ValueType = Type.GetType("System.Double")
            End With

            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "0.00"
                .ReadOnly = True
                .ValueType = Type.GetType("System.Double")
            End With

            x += +1
            Dim col_tipo_afectacion As New DataGridViewTextBoxColumn
            With col_tipo_afectacion
                .Name = "tipo_afectacion" : .DataPropertyName = "tipo_afectacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Afectación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_codigo_cuenta As New DataGridViewTextBoxColumn
            With col_codigo_cuenta
                .Name = "codigo_cuenta" : .DataPropertyName = "codigo_cuenta"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código Cuenta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "tipo"
            End With

            x += +1
            Dim col_subtipo As New DataGridViewTextBoxColumn
            With col_subtipo
                .Name = "subtipo" : .DataPropertyName = "subtipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "subtipo"
            End With

            x += +1
            Dim col_centro_costo As New DataGridViewTextBoxColumn
            With col_centro_costo
                .Name = "centro_costo" : .DataPropertyName = "centro_costo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Centro Costo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_impuesto_ca As New DataGridViewTextBoxColumn
            With col_impuesto_ca
                .Name = "impuesto_ca" : .DataPropertyName = "impuesto_ca"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Impuesto CA" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "0.00"
                .ReadOnly = True
                .ValueType = Type.GetType("System.Double")
            End With

            x += +1
            Dim col_total_ca As New DataGridViewTextBoxColumn
            With col_total_ca
                .Name = "total_ca" : .DataPropertyName = "total_ca"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total CA" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "0.00"
                .ReadOnly = True
                .ValueType = Type.GetType("System.Double")
            End With

            x += +1
            Dim col_subdiario As New DataGridViewTextBoxColumn
            With col_subdiario
                .Name = "subdiario" : .DataPropertyName = "subdiario"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subdiario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_tipo_comprobante As New DataGridViewTextBoxColumn
            With col_tipo_comprobante
                .Name = "tipo_comprobante" : .DataPropertyName = "tipo_comprobante" : .DisplayIndex = x : .Visible = False : .HeaderText = "tipo_comprobante"
            End With

            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Id Cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_agencia As New DataGridViewTextBoxColumn
            With col_agencia
                .Name = "agencia" : .DataPropertyName = "agencia" : .DisplayIndex = x : .Visible = False : .HeaderText = "agencia"
            End With

            x += +1
            Dim col_id_agencia As New DataGridViewTextBoxColumn
            With col_id_agencia
                .Name = "id_agencia" : .DataPropertyName = "id_agencia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Id Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_venta As New DataGridViewTextBoxColumn
            With col_venta
                .Name = "venta" : .DataPropertyName = "venta" : .DisplayIndex = x : .Visible = False : .HeaderText = "venta"
            End With

            x += +1
            Dim col_transferido As New DataGridViewTextBoxColumn
            With col_transferido
                .Name = "transferido" : .DataPropertyName = "transferido" : .DisplayIndex = x : .Visible = False : .HeaderText = "transferido"
            End With

            x += +1
            Dim col_ventac As New DataGridViewTextBoxColumn
            With col_ventac
                .Name = "ventac" : .DataPropertyName = "ventac"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Venta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_transferidoc As New DataGridViewTextBoxColumn
            With col_transferidoc
                .Name = "transferidoc" : .DataPropertyName = "transferidoc"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Transferido"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_fecha_transferencia As New DataGridViewTextBoxColumn
            With col_fecha_transferencia
                .Name = "fecha_transferencia" : .DataPropertyName = "fecha_transferencia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Transferencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            .Columns.AddRange(col_id, col_concepto, col_moneda, col_codigo_cliente, col_tipo_documento, col_serie, col_numero, col_fecha, col_fecha_vencimiento, _
                              col_observacion, col_impuesto, col_total, col_tipo_afectacion, col_estado, col_codigo_cuenta, col_tipo, col_subtipo, _
                              col_centro_costo, col_impuesto_ca, col_total_ca, col_subdiario, col_tipo_comprobante, col_origen, col_cliente, _
                              col_agencia, col_id_agencia, col_venta, col_transferido, col_ventac, col_transferidoc, col_fecha_transferencia)
        End With
    End Sub

    Sub ConfigurardgvLog()
        With dgvLog
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
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_error As New DataGridViewTextBoxColumn
            With col_error
                .Name = "error_descripcion" : .DataPropertyName = "error_descripcion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Error"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_fecha_registro As New DataGridViewTextBoxColumn
            With col_fecha_registro
                .Name = "fecha_registro" : .DataPropertyName = "fecha_registro"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Transferencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_id_comprobante As New DataGridViewTextBoxColumn
            With col_id_comprobante
                .Name = "id_comprobante" : .DataPropertyName = "id_comprobante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Id Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_id_cliente As New DataGridViewTextBoxColumn
            With col_id_cliente
                .Name = "id_cliente" : .DataPropertyName = "id_cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Id Cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            .Columns.AddRange(col_fecha, col_error, col_origen, col_cliente, col_fecha_registro, col_tipo, col_numero, col_id_comprobante, col_id_cliente)
        End With
    End Sub
#End Region

    Private Sub frmTransferenciaContabilidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ConfigurardgvVenta()
        Me.ConfigurardgvLog()
        Me.cboTipoVenta.SelectedIndex = 0
        Me.cboTipoTransferencia.SelectedIndex = 0
    End Sub

    Sub Limpiar()
        Me.dgvVenta.DataSource = Nothing
        Me.dgvLog.DataSource = Nothing

        Me.lblNumero.Text = "0"
        Me.lblTotalVenta.Text = "0.00"
        Me.lblContado.Text = "0.00"
        Me.lblCredito.Text = "0.00"
        Me.lblTransferido.Text = "0.00"
        Me.lblNoTransferido.Text = "0.00"

        Me.btnTransferir.Enabled = False
        Me.btnAnular.Enabled = False
    End Sub

    Sub ListarVenta(ByVal inicio As String, ByVal fin As String, ByVal venta As Integer, ByVal transferido As Integer)
        Dim obj As New Cls_Contabilidad_LN
        Dim dt As DataTable = obj.ListarVenta(inicio, fin, venta, transferido)
        Me.dgvVenta.DataSource = dt

        'IIf(IsDBNull(dt.Compute("sum(monto)", "")), 0, dt.Compute("sum(monto)", ""))
        Dim intRegistros As Integer = IIf(IsDBNull(dt.Compute("count(id)", "")), 0, dt.Compute("count(id)", ""))
        Dim dblTotalVenta As Double = IIf(IsDBNull(dt.Compute("sum(total)", "tipo_comprobante<>30")), 0, dt.Compute("sum(total)", "tipo_comprobante<>30"))
        Dim dblContado As Double = IIf(IsDBNull(dt.Compute("sum(total)", "venta=1 and tipo_comprobante<>30")), 0, dt.Compute("sum(total)", "venta=1 and tipo_comprobante<>30"))
        Dim dblCredito As Double = IIf(IsDBNull(dt.Compute("sum(total)", "venta=2 and tipo_comprobante<>30")), 0, dt.Compute("sum(total)", "venta=2 and tipo_comprobante<>30"))
        Dim dblTransferido As Double = IIf(IsDBNull(dt.Compute("sum(total)", "transferido=1")), 0, dt.Compute("sum(total)", "transferido=1"))
        Dim dblNoTransferido As Double = IIf(IsDBNull(dt.Compute("sum(total)", "transferido=0")), 0, dt.Compute("sum(total)", "transferido=0"))
        Dim intNoTransferido As Integer = IIf(IsDBNull(dt.Compute("count(transferido)", "transferido=0")), 0, dt.Compute("count(transferido)", "transferido=0"))

        Dim dblTotalVentanc As Double = IIf(IsDBNull(dt.Compute("sum(total)", "tipo_comprobante=30")), 0, dt.Compute("sum(total)", "tipo_comprobante=30"))
        Dim dblContadonc As Double = IIf(IsDBNull(dt.Compute("sum(total)", "venta=1 and tipo_comprobante=30")), 0, dt.Compute("sum(total)", "venta=1 and tipo_comprobante=30"))
        Dim dblCreditonc As Double = IIf(IsDBNull(dt.Compute("sum(total)", "venta=2 and tipo_comprobante=30")), 0, dt.Compute("sum(total)", "venta=2 and tipo_comprobante=30"))

        Me.lblNumero.Text = Format(intRegistros, "###,###,###0")
        Me.lblTotalVenta.Text = Format(dblTotalVenta - dblTotalVentanc, "###,###,###,###0.00")
        Me.lblContado.Text = Format(dblContado - dblContadonc, "###,###,###,###0.00")
        Me.lblCredito.Text = Format(dblCredito - dblCreditonc, "###,###,###,###0.00")
        Me.lblTransferido.Text = Format(dblTransferido, "###,###,###,###0.00")
        Me.lblNoTransferido.Text = Format(dblNoTransferido, "###,###,###,###0.00")

        Me.btnTransferir.Enabled = intNoTransferido > 0

        If Me.dgvVenta.Rows.Count = 0 Then
            Me.dgvLog.DataSource = Nothing
        End If
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim intVenta As Integer, intTransferido As Integer

            If Me.cboTipoVenta.SelectedIndex = 0 Then
                intVenta = 3
            Else
                intVenta = Me.cboTipoVenta.SelectedIndex
            End If

            If Me.cboTipoTransferencia.SelectedIndex = 0 Then
                intTransferido = 3
            ElseIf Me.cboTipoTransferencia.SelectedIndex = 1 Then
                intTransferido = 1
            Else
                intTransferido = 0
            End If

            ListarVenta(Me.dtpInicio.Value.ToShortDateString, Me.dtpFin.Value.ToShortDateString, intVenta, intTransferido)
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpInicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInicio.ValueChanged
        Limpiar()
    End Sub

    Private Sub dtpFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFin.ValueChanged
        Limpiar()
    End Sub

    Private Sub cboTipoVenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoVenta.SelectedIndexChanged
        Limpiar()
    End Sub

    Private Sub cboTipoTransferencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoTransferencia.SelectedIndexChanged
        Limpiar()
    End Sub

    Private Sub btnTransferir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransferir.Click
        Try
            Dim dlgRespuesta As DialogResult
            Dim strMensaje As String
            Dim intVenta As Integer

            strMensaje = "Fecha Del : " & Me.dtpInicio.Value.ToShortDateString & " Al : " & Me.dtpFin.Value.ToShortDateString & Chr(13)
            strMensaje = strMensaje & "Tipo Venta : " & Me.cboTipoVenta.Text & Chr(13) & Chr(13)
            strMensaje = strMensaje & "¿Está seguro de realizar la transferencia?"
            dlgRespuesta = MessageBox.Show(strMensaje, "Transferencia a Contabilidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                If Me.cboTipoVenta.SelectedIndex = 0 Then
                    intVenta = 3
                Else
                    intVenta = Me.cboTipoVenta.SelectedIndex
                End If
                Cursor = Cursors.WaitCursor
                Me.TransferirComprobante(Me.dtpInicio.Value.ToShortDateString, Me.dtpFin.Value.ToShortDateString, intVenta)
                Me.btnConsultar_Click(Nothing, Nothing)
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvVenta_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVenta.RowEnter
        With Me.dgvVenta
            Me.btnAnular.Enabled = dgvVenta.Rows(e.RowIndex).Cells("transferido").Value = 1
            ListarLog(dgvVenta.Rows(e.RowIndex).Cells("id").Value)
        End With
    End Sub

    Sub ListarLog(ByVal comprobante As Integer)
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_Contabilidad_LN
            Dim dt As DataTable = obj.ListarLog(comprobante)
            Me.dgvLog.DataSource = dt
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está seguro de anular la transferencia?", "Anular Transferencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            AnularTransferencia(Me.dgvVenta.CurrentRow.Cells("id").Value, Me.dgvVenta.CurrentRow.Cells("origen").Value, _
                                Me.dgvVenta.CurrentRow.Cells("serie").Value, Me.dgvVenta.CurrentRow.Cells("numero").Value, _
                                Me.dgvVenta.CurrentRow.Cells("tipo_documento").Value, Me.dgvVenta.CurrentRow.Cells("fecha").Value)
        End If
    End Sub

    Sub AnularTransferencia(ByVal id As Integer, ByVal origen As Integer, ByVal serie As String, ByVal comprobante As String, ByVal tipo As String, ByVal fecha As String)
        Try
            Dim strComprobante As String = serie & "-" & comprobante.PadLeft(10, "0")
            If ExisteComprobante(strComprobante, tipo) Then
                If CDate(fecha) >= "01/11/2019" Then
                    AnularTransferencia(strComprobante, tipo)
                End If
                Dim obj As New Cls_Contabilidad_LN
                obj.AnularTransferencia(id, origen)
                Me.btnConsultar_Click(Nothing, Nothing)
            Else
                MessageBox.Show("El Comprobante no está en contabilidad", "Anular Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Anular Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Sub AnularTransferencia(ByVal comprobante As String, ByVal tipo As String)
        'Usa una conexión con el ofisis 
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.CommandTimeout = 0
        cmd.Connection = cnnSQL
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "PR_A_ANULAR_TRANSFERENCIA"
        If cnnSQL.State = ConnectionState.Closed Then cnnSQL.Open()
        cmd.Parameters.Add(New SqlClient.SqlParameter("@P_COMPROBANTE", SqlDbType.VarChar)).Value = comprobante
        cmd.Parameters.Add(New SqlClient.SqlParameter("@P_TIPO", SqlDbType.VarChar)).Value = tipo
        cmd.ExecuteNonQuery()
    End Sub

    Function ExisteComprobante(ByVal comprobante As String, ByVal tipo As String) As Boolean
        'Usa una conexión con el pys
        Using cnn As New SqlConnection()
            Try
                If cnnSQL.State = ConnectionState.Closed Then cnnSQL.Open()
                Using cmd As New SqlCommand("SELECT dbo.FN_COMPROBANTE(@P_COMPROBANTE,@P_TIPO)", cnnSQL)
                    cmd.Parameters.AddWithValue("@P_COMPROBANTE", comprobante)
                    cmd.Parameters.AddWithValue("@P_TIPO", tipo)
                    Dim i As Integer = cmd.ExecuteScalar
                    Return If(i = 1, True, False)
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Using
    End Function

    Sub TransferirComprobante(ByVal inicio As String, ByVal fin As String, ByVal venta As Integer)
        ' Usa una conexión con el ofisis 
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.CommandTimeout = 0
        cmd.Connection = cnnSQL
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "PR_A_CONTA"
        If cnnSQL.State = ConnectionState.Closed Then cnnSQL.Open()
        cmd.Parameters.Add(New SqlClient.SqlParameter("@P_INICIO", SqlDbType.VarChar)).Value = inicio
        cmd.Parameters.Add(New SqlClient.SqlParameter("@P_FIN", SqlDbType.VarChar)).Value = fin
        cmd.Parameters.Add(New SqlClient.SqlParameter("@P_VENTA", SqlDbType.Int)).Value = venta
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub dgvVenta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVenta.CellContentClick

    End Sub
End Class