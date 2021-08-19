Imports INTEGRACION_LN

Public Class frmCierreProvision
    Dim dtProvision As DataTable
    Sub FormateardgvConsulta()
        With dgvConsulta
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
            Dim col_id_provision As New DataGridViewTextBoxColumn
            With col_id_provision
                .Name = "id_provision" : .DataPropertyName = "id_provision" : .DisplayIndex = x : .Visible = True : .HeaderText = "Id"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            x += +1
            Dim col_fecha_registro As New DataGridViewTextBoxColumn
            With col_fecha_registro
                .Name = "fecha_registro" : .DataPropertyName = "fecha_registro"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Período"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_cierre As New DataGridViewTextBoxColumn
            With col_fecha_cierre
                .Name = "fecha_cierre" : .DataPropertyName = "fecha_cierre"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Cierre"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Anulación"
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
            Dim col_idestado As New DataGridViewTextBoxColumn
            With col_idestado
                .Name = "idestado" : .DataPropertyName = "idestado" : .DisplayIndex = x : .Visible = True : .HeaderText = "idestado" : .Visible = False
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id_provision, col_fecha_registro, col_fecha_cierre, col_fecha, col_idestado, col_estado)
        End With
    End Sub

    Sub FormateardgvConsultaDetalle()
        With dgvConsultaDetalle
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
            Dim col_funcionario As New DataGridViewTextBoxColumn
            With col_funcionario
                .Name = "funcionario" : .DataPropertyName = "funcionario"
                .DisplayIndex = x : .HeaderText = "Funcionario" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_razon_social As New DataGridViewTextBoxColumn
            With col_razon_social
                .Name = "razon_social" : .DataPropertyName = "razon_social"
                .DisplayIndex = x : .HeaderText = "Razón Social" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_centro_costo As New DataGridViewTextBoxColumn
            With col_centro_costo
                .Name = "centro_costo" : .DataPropertyName = "centro_costo"
                .DisplayIndex = x : .HeaderText = "Subcuenta" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
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
            Dim col_nro_prefactura As New DataGridViewTextBoxColumn
            With col_nro_prefactura
                .Name = "nro_prefactura" : .DataPropertyName = "nro_prefactura"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Prefactura"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_nro_guia As New DataGridViewTextBoxColumn
            With col_nro_guia
                .Name = "nro_guia" : .DataPropertyName = "nro_guia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Guía"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_guia As New DataGridViewTextBoxColumn
            With col_fecha_guia
                .Name = "fecha_guia" : .DataPropertyName = "fecha_guia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Guía"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad Peso" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_cantidad_x_unidad_volumen As New DataGridViewTextBoxColumn
            With col_cantidad_x_unidad_volumen
                .Name = "cantidad_x_unidad_volumen" : .DataPropertyName = "cantidad_x_unidad_volumen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad Volumen" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_cantidad_x_unidad_arti As New DataGridViewTextBoxColumn
            With col_cantidad_x_unidad_arti
                .Name = "cantidad_x_unidad_arti" : .DataPropertyName = "cantidad_x_unidad_arti"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad Articulo" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_cantidad_sobres As New DataGridViewTextBoxColumn
            With col_cantidad_sobres
                .Name = "cantidad_sobres" : .DataPropertyName = "cantidad_sobres"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad Sobres" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total_peso As New DataGridViewTextBoxColumn
            With col_total_peso
                .Name = "total_peso" : .DataPropertyName = "total_peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total Peso" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total_volumen As New DataGridViewTextBoxColumn
            With col_total_volumen
                .Name = "total_volumen" : .DataPropertyName = "total_volumen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total Volumen" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_subtotal As New DataGridViewTextBoxColumn
            With col_subtotal
                .Name = "subtotal" : .DataPropertyName = "subtotal"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subtotal" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_monto_impuesto As New DataGridViewTextBoxColumn
            With col_monto_impuesto
                .Name = "monto_impuesto" : .DataPropertyName = "monto_impuesto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Impuesto" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total_costo As New DataGridViewTextBoxColumn
            With col_total_costo
                .Name = "total_costo" : .DataPropertyName = "total_costo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_producto As New DataGridViewTextBoxColumn
            With col_producto
                .Name = "producto" : .DataPropertyName = "producto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Producto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo_facturacion As New DataGridViewTextBoxColumn
            With col_tipo_facturacion
                .Name = "tipo_facturacion" : .DataPropertyName = "tipo_facturacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Facturacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_situacion As New DataGridViewTextBoxColumn
            With col_situacion
                .Name = "situacion" : .DataPropertyName = "situacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Situación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_entrega As New DataGridViewTextBoxColumn
            With col_entrega
                .Name = "entrega" : .DataPropertyName = "entrega"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Entrega"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_idtipo_facturacion As New DataGridViewTextBoxColumn
            With col_idtipo_facturacion
                .Name = "idtipo_facturacion" : .DataPropertyName = "idtipo_facturacion" : .DisplayIndex = x : .Visible = True : .HeaderText = "idtipo_facturacion" : .Visible = False
            End With
            x += +1
            Dim col_id_producto As New DataGridViewTextBoxColumn
            With col_id_producto
                .Name = "id_producto" : .DataPropertyName = "id_producto" : .DisplayIndex = x : .Visible = True : .HeaderText = "id_producto" : .Visible = False
            End With
            x += +1
            Dim col_idtipo_comprobante As New DataGridViewTextBoxColumn
            With col_idtipo_comprobante
                .Name = "idtipo_comprobante" : .DataPropertyName = "idtipo_comprobante" : .DisplayIndex = x : .Visible = True : .HeaderText = "idtipo_comprobante" : .Visible = False
            End With
            x += +1
            Dim col_idguias_envio As New DataGridViewTextBoxColumn
            With col_idguias_envio
                .Name = "idguias_envio" : .DataPropertyName = "idguias_envio" : .DisplayIndex = x : .Visible = True : .HeaderText = "idguias_envio" : .Visible = False
            End With

            .Columns.AddRange(col_funcionario, col_razon_social, col_centro_costo, col_origen, col_destino, col_nro_prefactura, col_nro_guia, col_fecha_guia, _
                              col_cantidad, col_cantidad_x_unidad_volumen, col_cantidad_x_unidad_arti, col_cantidad_sobres, _
                              col_total_peso, col_total_volumen, col_subtotal, col_monto_impuesto, col_total_costo, col_producto, col_tipo_facturacion, col_estado, col_situacion, _
                              col_entrega, col_idtipo_facturacion, col_id_producto, col_idtipo_comprobante, col_idguias_envio)
        End With
    End Sub


    Private Sub frmCierreProvision_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FormateardgvConsulta()
        FormateardgvConsultaDetalle()

        Me.tsbGrabar.Enabled = False
        Me.tsbAnular.Enabled = False
        Me.tsbExportar.Enabled = False

        Me.cboEstado.SelectedIndex = 1

        ActualizaEstadoProvision()
    End Sub

    Sub GenerarProvision()
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_CierreProvision_LN
            Dim strFecha As String, strInicio As String, strFin As String

            strFecha = Me.dtpPeriodo.Value.ToShortDateString
            strInicio = "01/" & Format(CDate(strFecha), "MM/yyyy")
            strFin = "01/" + Format(CDate(strFecha), "MM/yyyy")
            strFin = DateAdd(DateInterval.Month, 1, CDate(strFin))
            strFin = DateAdd(DateInterval.Day, -1, CDate(strFin))

            obj.GenerarProvision(strInicio, strFin, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
            'Me.btnConsultarProvision_Click(Nothing, Nothing)
            Me.tsbConsultar_Click(Nothing, Nothing)

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Provisión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbGrabar_Click(sender As System.Object, e As System.EventArgs) Handles tsbGrabar.Click
        Dim strFechaServidor = FechaServidor()
        Dim dlgRespuesta As Integer
        dlgRespuesta = MessageBox.Show("Está seguro de cerrar la Provisión" & Chr(13) & Chr(13) & _
                                       "Período : " & Me.dtpPeriodo.Text & Chr(13) & _
                                       "Fecha y Hora : " & strFechaServidor & "?", "Cierre de Provisión", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = vbYes Then
            CerrarProvision()
        End If

    End Sub

    Sub CerrarProvision()
        Cursor = Cursors.WaitCursor
        Try
            Dim obj As New Cls_CierreProvision_LN
            Dim dt As DataTable
            Dim strFecha As String = Me.dtpPeriodo.Value.ToShortDateString
            Dim intId As Integer = Me.dgvConsulta.CurrentRow.Cells("id_provision").Value
            Dim strCadena As String = ""

            'strFecha = "01/" & Format(CDate(strFecha), "MM/yyyy")
            dt = obj.CerrarProvision(intId, FechaServidor, strFecha, dtoUSUARIOS.m_iIdAgencia, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)

            For Each row As DataRow In dt.Rows
                strCadena &= strCadena & row.Item(0).ToString & Chr(13)
            Next

            Me.tsbGrabar.Enabled = False
            Me.tsbAnular.Enabled = False
            Me.tsbGenerar.Enabled = False
            Me.tsbExportar.Enabled = False

            lblMensajeProvision.Text = "CERRADO"
            'Me.btnConsultarProvision_Click(Nothing, Nothing)
            Me.tsbConsultar_Click(Nothing, Nothing)
            Cursor = Cursors.Default
            'MessageBox.Show("Provisión Cerrada", "Gasto", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MessageBox.Show("Se Generaron las Facturas" & Chr(13) & Chr(13) & strCadena, "Provisión Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Provisión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Sub ActualizaEstadoProvision()
        Dim obj As New Cls_CierreProvision_LN
        Dim strFecha As String, strInicio As String

        strFecha = Me.dtpPeriodo.Value.ToShortDateString
        strInicio = "01/" & Format(CDate(strFecha), "MM/yyyy")
        Dim dt As DataTable = obj.EstadoProvision(strInicio)

        Me.lblMensajeProvision.Text = IIf(Val(dt.Rows(0).Item(0)) = 0, "", "CERRADO")
        Me.tsbGenerar.Enabled = Val(dt.Rows(0).Item(1)) = 0
    End Sub

    Private Sub btnConsultarProvision_Click(sender As System.Object, e As System.EventArgs)
        'ConsultarProvisionHistorico()
    End Sub

    Sub ConsultarProvisionHistorico()
        Cursor = Cursors.WaitCursor
        Try
            Dim obj As New Cls_CierreProvision_LN
            Dim strFecha As String, strInicio As String

            strFecha = Me.dtpPeriodo.Value.ToShortDateString
            strInicio = "01/" & Format(CDate(strFecha), "MM/yyyy")
            Dim dt As DataTable = obj.ConsultarProvision(strInicio, cboEstado.SelectedIndex)
            Me.dgvConsulta.DataSource = dt
            If Me.dgvConsulta.Rows.Count = 0 Then
                Me.dgvConsultaDetalle.DataSource = Nothing
                Limpiar()
            End If
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Provisión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Limpiar()
        Me.lblSubtotal.Text = "0.00" : Me.lblImpuesto.Text = "0.00" : Me.lblTotal.Text = "0.00" : Me.lblRegistros.Text = "0"
    End Sub

    Private Sub dgvConsulta_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsulta.RowEnter
        Dim intId As Integer = dgvConsulta.Rows(e.RowIndex).Cells("id_provision").Value
        ConsultarProvisionHistorico(intId)

        Me.tsbGrabar.Enabled = dgvConsulta.Rows(e.RowIndex).Cells("idestado").Value = 1 And Not IsDate(dgvConsulta.Rows(e.RowIndex).Cells("fecha_cierre").Value)
        Me.tsbAnular.Enabled = dgvConsulta.Rows(e.RowIndex).Cells("idestado").Value = 1
        Me.tsbExportar.Enabled = dgvConsulta.Rows(e.RowIndex).Cells("idestado").Value = 1 And IsDate(dgvConsulta.Rows(e.RowIndex).Cells("fecha_cierre").Value)

        Me.btnRetirar.Enabled = dgvConsulta.Rows(e.RowIndex).Cells("idestado").Value = 1 And Not IsDate(dgvConsulta.Rows(e.RowIndex).Cells("fecha_cierre").Value)
    End Sub

    Sub ConsultarProvisionHistorico(id As Integer)
        Cursor = Cursors.WaitCursor
        Try
            Dim obj As New Cls_CierreProvision_LN

            dtProvision = obj.ConsultarProvision(id)
            Me.dgvConsultaDetalle.DataSource = dtProvision

            'Calcula totales
            Dim dblSubtotal As Double = IIf(IsDBNull(dtProvision.Compute("sum(subtotal)", "")), 0, dtProvision.Compute("sum(subtotal)", ""))
            Dim dblImpuesto As Double = IIf(IsDBNull(dtProvision.Compute("sum(monto_impuesto)", "")), 0, dtProvision.Compute("sum(monto_impuesto)", ""))
            Dim dblTotal As Double = IIf(IsDBNull(dtProvision.Compute("sum(total_costo)", "")), 0, dtProvision.Compute("sum(total_costo)", ""))

            Me.lblSubtotal.Text = dblSubtotal.ToString("#,###,###0.00")
            Me.lblImpuesto.Text = dblImpuesto.ToString("#,###,###0.00")
            Me.lblTotal.Text = dblTotal.ToString("#,###,###0.00")
            Me.lblRegistros.Text = Format(Me.dgvConsultaDetalle.Rows.Count, "#,###,###0")

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Provisión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvConsulta_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsulta.CellContentClick

    End Sub

    Sub AnularComprobante(id As Integer, tipo As Integer, comprobante As Integer)
        Dim obj As New Cls_CierreProvision_LN
        obj.AnularComprobante(id, tipo, comprobante, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
    End Sub

    Sub AnularProvision(id As Integer)
        Dim obj As New Cls_CierreProvision_LN
        obj.AnularProvision(id, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
    End Sub

    Private Sub tsbAnular_Click(sender As System.Object, e As System.EventArgs) Handles tsbAnular.Click
        Dim dlgRespuesta As DialogResult

        Try
            'If tabProvision.SelectedTab Is tabProvision.TabPages("tabCierre") Then
            '    dlgRespuesta = MessageBox.Show("¿Está Seguro de Retirar el Comprobante Nº " & Me.dgvCierre.CurrentRow.Cells("nro_guia").Value & "?", "Cierre de Provisión", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            '    If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            '        Cursor = Cursors.WaitCursor
            '        AnularComprobante(Me.dgvCierre.CurrentRow.Cells("idtipo_comprobante").Value, Me.dgvCierre.CurrentRow.Cells("idguias_envio").Value)
            '    End If
            'Else
            dlgRespuesta = MessageBox.Show("¿Está Seguro de Anular la Provisión Nº " & Me.dgvConsulta.CurrentRow.Cells("id_provision").Value & "?", "Cierre de Provisión", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Me.tsbGrabar.Enabled = False
                Me.tsbAnular.Enabled = False
                Me.tsbGenerar.Enabled = False
                Me.tsbExportar.Enabled = False

                AnularProvision(Me.dgvConsulta.CurrentRow.Cells("id_provision").Value)
                ConsultarProvisionHistorico()
                ActualizaEstadoProvision()
            End If
            'End If
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Cierre de Provisión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dtpPeriodo_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpPeriodo.ValueChanged
        Me.lblMensajeProvision.Text = ""

        ActualizaEstadoProvision()

        Me.tsbGrabar.Enabled = False
        Me.tsbAnular.Enabled = False
        Me.tsbExportar.Enabled = False
        Me.tsbExportar.Enabled = False

        Me.dgvConsulta.DataSource = Nothing
        Me.dgvConsultaDetalle.DataSource = Nothing

        Limpiar()
    End Sub

    Private Sub tsbGenerar_Click(sender As System.Object, e As System.EventArgs) Handles tsbGenerar.Click
        GenerarProvision()
        ActualizaEstadoProvision()
    End Sub

    Private Sub btnRetirar_Click(sender As System.Object, e As System.EventArgs) Handles btnRetirar.Click
        Dim dlgRespuesta As DialogResult

        Try
            If tabProvision.SelectedTab Is tabProvision.TabPages("tabCierre") Then
                dlgRespuesta = MessageBox.Show("¿Está Seguro de Retirar el Comprobante Nº " & Me.dgvConsultaDetalle.CurrentRow.Cells("nro_guia").Value & "?", "Cierre de Provisión", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    AnularComprobante(Me.dgvConsulta.CurrentRow.Cells("id_provision").Value, Me.dgvConsultaDetalle.CurrentRow.Cells("idtipo_comprobante").Value, Me.dgvConsultaDetalle.CurrentRow.Cells("idguias_envio").Value)
                    ConsultarProvisionHistorico()
                End If
            End If
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Cierre de Provisión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function TipoFacturacion(tipo As Integer) As String
        Select Case tipo
            Case 1
                Return "TIPO I SF"
            Case 2
                Return "TIPO II SPF"
            Case 3
                Return "TIPO II PF"
            Case 4
                Return "TIPO III SPF"
            Case 5
                Return "TIPO III PF"
        End Select
    End Function

    Private Sub tsbExportar_Click(sender As System.Object, e As System.EventArgs) Handles tsbExportar.Click
        Exportar()
    End Sub

    Sub Exportar()
        Dim xlApp As New Excel.Application()
        Dim xlBook As Excel.Workbook
        Dim xlSheet As Excel.Worksheet
        Dim rowIndex, colIndex, i, j As Integer
        Dim intHoja As Integer = 0
        Dim strSuma As String
        Dim aLista(6) As Integer
        Try
            Cursor = Cursors.AppStarting
            Dim intId As Integer = Me.dgvConsulta.CurrentRow.Cells("id_provision").Value
            Dim obj As New Cls_CierreProvision_LN
            Dim ds As DataSet = obj.ExportarProvision(intId)
            Dim dsFinal As DataSet = ds.Clone
            rowIndex = 1
            colIndex = 0
            xlBook = xlApp.Workbooks().Add
            'xlSheet = xlBook.Worksheets("hoja1")

            'Recorrer el dataset
            For Each tbl As DataTable In ds.Tables
                If tbl.Rows.Count > 0 And tbl.Columns.Count > 3 Then
                    intHoja += 1
                    If intHoja >= 7 Then Exit For
                    If intHoja > 3 Then
                        xlBook.Worksheets.Add(After:=xlBook.Worksheets(intHoja - 1))
                    End If
                    xlSheet = xlBook.Worksheets("hoja" & intHoja)

                    'Genera Cabecera
                    colIndex = 0
                    For j = 0 To tbl.Columns.Count - 1
                        colIndex = colIndex + 1
                        If intHoja = 1 Then
                            If j > 0 Then
                                xlSheet.Range(xlSheet.Cells(1, colIndex), xlSheet.Cells(1, colIndex)).Value = tbl.Columns(j).ColumnName
                            End If
                        Else
                            xlSheet.Range(xlSheet.Cells(1, colIndex), xlSheet.Cells(1, colIndex)).Value = tbl.Columns(j).ColumnName
                        End If
                    Next

                    rowIndex = 0
                    For Each row As DataRow In tbl.Rows
                        rowIndex += 1 : colIndex = 0
                        aLista(intHoja) = 1
                        For j = 0 To tbl.Columns.Count - 1
                            colIndex = colIndex + 1
                            If intHoja = 1 Then
                                If j = 0 Then
                                    xlSheet.Range(xlSheet.Cells(rowIndex + 1, colIndex), xlSheet.Cells(rowIndex + 1, colIndex)).Value = TipoFacturacion(tbl.Rows(rowIndex - 1).Item(j))
                                Else
                                    xlSheet.Range(xlSheet.Cells(rowIndex + 1, colIndex), xlSheet.Cells(rowIndex + 1, colIndex)).Value = tbl.Rows(rowIndex - 1).Item(j)
                                    xlSheet.Range(xlSheet.Cells(rowIndex + 1, colIndex), xlSheet.Cells(rowIndex + 1, colIndex)).NumberFormat = "###,###,###0.00"
                                End If
                            Else
                                xlSheet.Range(xlSheet.Cells(rowIndex + 1, colIndex), xlSheet.Cells(rowIndex + 1, colIndex)).Value = tbl.Rows(rowIndex - 1).Item(j)
                            End If
                        Next
                    Next
                    If rowIndex = 0 Then 'cursor no devuelve filas
                        xlSheet.Delete()
                    End If
                    'Totales
                    With xlSheet
                        If intHoja > 1 Then
                            strSuma = "=sum(m2:m" & rowIndex + 1 & ")" : .Cells(rowIndex + 2, 13).Formula = strSuma
                            strSuma = "=sum(n2:n" & rowIndex + 1 & ")" : .Cells(rowIndex + 2, 14).Formula = strSuma
                            strSuma = "=sum(o2:o" & rowIndex + 1 & ")" : .Cells(rowIndex + 2, 15).Formula = strSuma
                            .Range(.Cells(rowIndex + 2, 13), .Cells(rowIndex + 2, 15)).Font.Bold = True
                            .Range(.Cells(rowIndex + 2, 13), .Cells(rowIndex + 2, 15)).NumberFormat = "###,###,###0.00"
                        Else
                            strSuma = "=sum(b2:b" & rowIndex + 1 & ")" : .Cells(rowIndex + 2, 2).Formula = strSuma
                            strSuma = "=sum(c2:c" & rowIndex + 1 & ")" : .Cells(rowIndex + 2, 3).Formula = strSuma
                            strSuma = "=sum(d2:d" & rowIndex + 1 & ")" : .Cells(rowIndex + 2, 4).Formula = strSuma
                            .Range(.Cells(rowIndex + 2, 2), .Cells(rowIndex + 2, 4)).Font.Bold = True
                            .Range(.Cells(rowIndex + 2, 2), .Cells(rowIndex + 2, 4)).NumberFormat = "###,###,###0.00"
                            .Range(.Cells(rowIndex + 2, 2), .Cells(rowIndex + 2, 4)).Font.Size = 14
                        End If
                    End With

                    'Formato
                    With xlSheet
                        '.Range(.Cells(1, 1), .Cells(1, colIndex)).Font.Name = "Arial"
                        .Range(.Cells(1, 1), .Cells(1, colIndex)).Font.Bold = True
                        .Columns.AutoFit()
                        '.Range(.Cells(1, 1), .Cells(rowIndex, colIndex)).Borders.LineStyle = 1
                    End With
                End If
            Next
            xlSheet = xlBook.Worksheets("hoja1")
            xlSheet.Select()

            'Recorrer Hojas de calculo
            Dim indice As Integer = 0, tipo As Integer = 0
            Dim sheet As Excel.Worksheet
            For Each tbl As DataTable In ds.Tables
                tipo += 1
                If tbl.Rows.Count > 0 And tbl.Columns.Count > 3 Then
                    indice += 1
                    sheet = xlBook.Worksheets("hoja" & indice)
                    If indice = 1 Then
                        sheet.Name = "RESUMEN"
                    Else
                        sheet.Name = TipoFacturacion(tipo - 1)
                    End If
                End If
            Next

            'For contador As Integer = 1 To aLista.Length - 1
            '    indice += 1
            '    If aLista(contador) = 1 Then
            '        sheet = xlBook.Worksheets("hoja" & indice)
            '        If indice = 1 Then
            '            sheet.Name = "RESUMEN"
            '        Else
            '            sheet.Name = TipoFacturacion(indice - 1)
            '        End If
            '    End If
            'Next

            ''Dim sheet As Excel.Worksheet
            'Dim intI As Integer = 0
            ''For Each sheet In xlBook.Worksheets
            'For Each tbl As DataTable In ds.Tables
            '    If intI = 0 Then
            '        sheet.Name = "RESUMEN"
            '    Else
            '        intI += 1
            '        If tbl.Rows.Count > 0 Then 'aLista(sheet.Index - 1) = 1 Then
            '            'sheet.Name = TipoFacturacion(sheet.Index - 1)
            '            sheet.Name = TipoFacturacion(intI)
            '        End If
            '    End If
            'Next

            Cursor = Cursors.Default
            xlApp.Visible = True
            xlApp.UserControl = False

            xlSheet = Nothing
            xlBook = Nothing
            'xlApp.Quit()
            xlApp = Nothing

        Catch ex As Exception
            Cursor = Cursors.Default
            xlSheet = Nothing
            xlBook = Nothing
            'xlApp.Quit()
            xlApp = Nothing
            MessageBox.Show(ex.Message, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbConsultar_Click(sender As System.Object, e As System.EventArgs) Handles tsbConsultar.Click
        ConsultarProvisionHistorico()
    End Sub
End Class