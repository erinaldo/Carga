Imports INTEGRACION_LN
Public Class frmPrecierre
    Dim strFechaServidor As String 'Fecha del servidor

    Dim intNivel As Integer
    Dim dblTipoCambio As Double
    Dim dtSoles As DataTable, dtDolares As DataTable
    Dim dblSaldo As Double = 0
    Dim xImpresora As Integer

#Region "Configurar Grid"
    Sub FormateardgvMovimiento()
        With dgvMovimiento
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
            .RowHeadersVisible = False
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
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha/Hora"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_unidad As New DataGridViewTextBoxColumn
            With col_unidad
                .Name = "unidad" : .DataPropertyName = "unidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Unidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_soles As New DataGridViewTextBoxColumn
            With col_soles
                .Name = "soles" : .DataPropertyName = "soles"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Retiro Soles" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_dolar As New DataGridViewTextBoxColumn
            With col_dolar
                .Name = "dolar" : .DataPropertyName = "dolar"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Retiro Dólar" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_tc As New DataGridViewTextBoxColumn
            With col_tc
                .Name = "tipo_cambio" : .DataPropertyName = "tipo_cambio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "T.C." : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            .Columns.AddRange(col_id, col_fecha, col_unidad, col_usuario, col_monto, col_soles, col_dolar, col_tc, col_total)
        End With
    End Sub
    Sub FormateardgvRetiro()
        With dgvRetiro
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
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With

            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_moneda As New DataGridViewTextBoxColumn
            With col_moneda
                .Name = "moneda" : .DataPropertyName = "moneda"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Moneda"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_cambio As New DataGridViewTextBoxColumn
            With col_cambio
                .Name = "cambio" : .DataPropertyName = "cambio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Cambio" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_idestado As New DataGridViewTextBoxColumn
            With col_idestado
                .Name = "idestado" : .DataPropertyName = "idestado" : .DisplayIndex = x : .Visible = False : .HeaderText = "idestado"
            End With

            .Columns.AddRange(col_id, col_codigo, col_moneda, col_monto, col_cambio, col_total, col_estado, col_idestado)
        End With
    End Sub
    Sub FormateardgvBillete()
        With dgvBillete
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
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With

            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_moneda As New DataGridViewTextBoxColumn
            With col_moneda
                .Name = "moneda" : .DataPropertyName = "moneda"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Moneda"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_valor As New DataGridViewTextBoxColumn
            With col_valor
                .Name = "valor" : .DataPropertyName = "valor"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Valor" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            .Columns.AddRange(col_id, col_tipo, col_moneda, col_valor, col_cantidad)
        End With
    End Sub
    Sub FormateardgvComprobante()
        With dgvComprobante
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
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With

            x += +1
            Dim col_unidad As New DataGridViewTextBoxColumn
            With col_unidad
                .Name = "unidad" : .DataPropertyName = "unidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Unidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            .Columns.AddRange(col_id, col_unidad, col_comprobante, col_monto)
        End With
    End Sub
    Sub FormateardgvComprobanteCierre()
        With dgvComprobanteCierre
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
                .DisplayIndex = x : .Visible = False : .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Total" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_efectivo As New DataGridViewTextBoxColumn
            With col_efectivo
                .Name = "efectivo" : .DataPropertyName = "efectivo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Efectivo" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "id" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_id_usuario As New DataGridViewTextBoxColumn
            With col_id_usuario
                .Name = "id_usuario" : .DataPropertyName = "id_usuario"
                .DisplayIndex = x : .HeaderText = "id_usuario" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_usuario, col_tipo, col_comprobante, col_total, col_efectivo, col_id_usuario, col_id)
        End With
    End Sub
#End Region

    Private Sub frmPrecierre_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Acceso.SiRol(G_Rol, Me, 1, 1) Then
            intNivel = 1
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 2) Then
            intNivel = 2
        Else
            intNivel = 0
        End If

        FormateardgvMovimiento()
        FormateardgvComprobanteCierre()
        FormateardgvRetiro()
        FormateardgvBillete()
        FormateardgvComprobante()
        strFechaServidor = CDate(FechaServidor()).ToShortDateString
        Me.dtpFecha.Value = strFechaServidor
        xImpresora = fnSeleccionImpresion()

        If intNivel = 1 Then
            Me.cboUnidad.SelectedIndex = dtoUSUARIOS.Unidad
            Me.cboUsuario.SelectedValue = dtoUSUARIOS.IdLogin
            If IsNothing(Me.cboUsuario.SelectedValue) Then
                Me.cboUsuario.SelectedValue = 0
            End If
            Me.cboUnidad.Enabled = False
            Me.cboUsuario.Enabled = False
        ElseIf intNivel = 2 Then
            Me.cboUnidad.SelectedIndex = 0
            Me.cboUsuario.SelectedValue = 0
            Me.cboUnidad.Enabled = True
            Me.cboUsuario.Enabled = True
        Else
            Me.cboUnidad.SelectedIndex = -1
            Me.cboUsuario.SelectedValue = -1
            Me.cboUnidad.Enabled = False
            Me.cboUsuario.Enabled = False
        End If
    End Sub

    Private Sub tabCabecera_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabCabecera.SelectedIndexChanged
        If tabCabecera.SelectedTab Is tabCabecera.TabPages("tabConsulta") Then
            If Me.dgvMovimiento.Rows.Count = 0 Then
                Me.tsbAnular.Enabled = False
            Else
                tabDetalle_SelectedIndexChanged(Nothing, Nothing)
            End If
        Else
            Me.tsbAnular.Enabled = False
            LimpiarCerrar()
            Dim strFecha As String = FechaServidor()
            dblTipoCambio = Cls_LiquidacionValor_LN.ObtieneTipoCambio(CDate(strFecha).ToShortDateString)

            Me.lblFechaCierre.Text = CDate(strFecha).ToShortDateString
            Me.lblHoraCierre.Text = CDate(strFecha).ToShortTimeString
            Me.lblUnidadCierre.Text = IIf(dtoUSUARIOS.Unidad = 1, "CARGA", "PASAJES")
            Me.lblUsuarioCierre.Text = dtoUSUARIOS.NameLogin

            Me.lblTipoCambioCierre.Text = Format(dblTipoCambio, "0.00")
            Me.btnRetiroDolarCierre.Enabled = dblTipoCambio > 0
        End If
    End Sub

    Function TotalEfectivo(ByVal dgv As DataGridView) As Double
        Dim dblMonto As Double = 0
        For Each row As DataGridViewRow In dgv.Rows
            dblMonto += row.Cells("efectivo").Value
        Next
        Return dblMonto
    End Function

    Sub ActualizarComprobante()
        Try
            Dim obj As New Cls_LiquidacionValor_LN
            Dim ds As DataSet = obj.ListarComprobante(dtoUSUARIOS.iIDAGENCIAS, Me.lblFechaCierre.Text, dtoUSUARIOS.IdLogin, dtoUSUARIOS.Unidad)
            Me.dgvComprobanteCierre.DataSource = ds.Tables(0)
            Me.lblTotalEfectivoCierre.Text = Format(TotalEfectivo(Me.dgvComprobanteCierre), "###,###,###0.00")
            Me.btnRetiroSolesCierre.Enabled = Me.dgvComprobanteCierre.Rows.Count > 0
            Me.btnRetiroDolarCierre.Enabled = Me.dgvComprobanteCierre.Rows.Count > 0 And dblTipoCambio > 0

            dblSaldo = ds.Tables(1).Rows(0).Item("saldo")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub btnActualizarCierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarCierre.Click
        Try
            Cursor = Cursors.WaitCursor
            ActualizarComprobante()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function MontoCaja(ByVal moneda As Integer) As Double
        Dim dblSoles As Double, dblDolares As Double, dblTC As Double, dblRetiroSoles As Double, dblRetiroDolares As Double

        dblSoles = CDbl(IIf(Val(Me.lblTotalEfectivoCierre.Text) = 0, 0, Me.lblTotalEfectivoCierre.Text)) + dblSaldo
        dblDolares = CDbl(IIf(Val(Me.lblTotalEfectivoCierre.Text) = 0, 0, Me.lblTotalEfectivoCierre.Text))
        dblTC = CDbl(Me.lblTipoCambioCierre.Text)
        dblRetiroSoles = CDbl(IIf(Val(Me.txtRetiroSolesCierre.Text) = 0, 0, Me.txtRetiroSolesCierre.Text))
        dblRetiroDolares = CDbl(IIf(Val(Me.txtRetiroDolarCierre.Text) = 0, 0, Me.txtRetiroDolarCierre.Text))
        If moneda = 1 Then 'soles
            Return dblSoles - (dblRetiroDolares * dblTC)
        Else
            Return (dblSoles - dblRetiroSoles) / dblTC
        End If
    End Function

    Private Sub btnRetiroSolesCierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetiroSolesCierre.Click
        Dim frm As New frmBillete
        frm.Moneda = 1
        frm.MontoCaja = MontoCaja(1) 'Me.lblTotalEfectivoCierre.Text
        frm.Text = "Billetes en Soles"
        frm.dt = dtSoles
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtRetiroSolesCierre.Text = frm.txtBillete.Text
            dtSoles = frm.dgvBillete.DataSource
        Else
            dtSoles = frm.dtBillete
        End If
    End Sub

    Private Sub txtRetiroSolesCierre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetiroSolesCierre.TextChanged, txtRetiroDolarCierre.TextChanged
        'Me.btnCerrar.Enabled = Val(Me.txtRetiroSolesCierre.Text) + Val(Me.txtRetiroDolarCierre.Text) > 0
    End Sub

    Private Sub btnRetiroDolarCierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetiroDolarCierre.Click
        Dim frm As New frmBillete
        frm.Moneda = 2
        frm.MontoCaja = MontoCaja(2) 'CDbl(Me.lblTotalEfectivoCierre.Text) / CDbl(Me.lblTipoCambioCierre.Text)
        frm.TipoCambio = CDbl(Me.lblTipoCambioCierre.Text)
        frm.Text = "Billetes en Dólares - Tipo de Cambio : " & Me.lblTipoCambioCierre.Text
        frm.dt = dtDolares
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtRetiroDolarCierre.Text = frm.txtBillete.Text
            dtDolares = frm.dgvBillete.DataSource
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        If Me.dgvComprobanteCierre.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron comprobantes", "Cerrar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.btnActualizarCierre.Focus()
            Return
        End If

        If Val(Me.txtRetiroSolesCierre.Text) + Val(Me.txtRetiroDolarCierre.Text) = 0 Then
            MessageBox.Show("Ingrese monto a Retirar", "Cerrar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.btnRetiroSolesCierre.Focus()
            Return
        End If

        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está seguro de realizar el pre-cierre?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            Cerrar()
        End If
    End Sub

    Sub ImprimirTicket(ByVal impresora As Integer, ByVal codigo As String, ByVal monto As Double, ByVal moneda As Integer)
        Dim strCadena As String = ""
        Dim prn As New PrinterTxt.PrintTxt
        prn.Nombre_impresora = NOMBRE_IMPRESORA
        Dim EXISTE As Boolean = prn.SetearImpresora()

        If impresora = 1 Or impresora = 4 Then
            prn.EscribeLinea("^XA")
            prn.EscribeLinea("^PW400")

            prn.EscribeLinea("^FT14,39^A0N,28,28^FH\^FD" & dtoUSUARIOS.NameLogin & "^FS")
            prn.EscribeLinea("^FT14,79^A0N,28,28^FH\^FD " & fnGetAGENCIA(dtoUSUARIOS.iIDAGENCIAS) & "^FS")

            strCadena = FechaServidor() & "   " & IIf(dtoUSUARIOS.Unidad = 1, "CARGA", "PASAJES")
            prn.EscribeLinea("^FT14,119^A0N,28,28^FH\^FD " & strCadena & "^FS")

            strCadena = IIf(moneda = 1, "S/.", "US$") & " " & Format(monto, "###,###,###0.00")
            prn.EscribeLinea("^FT14,159^A0N,28,28^FH\^FD " & strCadena & "^FS")

            prn.EscribeLinea("^BY2,2,46^FT190,114^BEN,,Y,N^FD" & codigo & "^FS")

            prn.EscribeLinea("^PQ1,0,1,Y")
            prn.EscribeLinea("^XZ")
            prn.FinDoc()
        Else
            prn.EscribeLinea("N")
            prn.EscribeLinea("N")

            prn.EscribeLinea("A30,9,0,4,1,1,N,""" & dtoUSUARIOS.NameLogin & """")
            prn.EscribeLinea("A30,39,0,4,1,1,N,""" & fnGetAGENCIA(dtoUSUARIOS.iIDAGENCIAS) & """")

            strCadena = FechaServidor() & "   " & IIf(dtoUSUARIOS.Unidad = 1, "CARGA", "PASAJES")
            prn.EscribeLinea("A30,69,0,4,1,1,N,""" & strCadena & """")

            strCadena = IIf(moneda = 1, "S/.", "US$") & " " & Format(monto, "###,###,###0.00")
            prn.EscribeLinea("A30,99,0,4,1,1,N,""" & strCadena & """")

            prn.EscribeLinea("B132,129,0,E30,2,2,59,B,""" & codigo & """")

            prn.EscribeLinea("P1")
            prn.EscribeLinea("N")
            prn.FinDoc()
        End If
    End Sub
    Sub LimpiarCerrar()
        Me.dgvComprobanteCierre.DataSource = Nothing
        Me.txtRetiroSolesCierre.Text = "0.00"
        Me.txtRetiroDolarCierre.Text = "0.00"
        btnRetiroSolesCierre.Enabled = False
        btnRetiroDolarCierre.Enabled = False
        Me.lblTotalEfectivoCierre.Text = "0.00"
        dtSoles = Nothing
        dtDolares = Nothing
        dblSaldo = 0
        Me.tsbAnular.Enabled = False
    End Sub

    Sub Cerrar()
        Try
            Cursor = Cursors.WaitCursor
            Dim strFecha As String, dblTotalEfectivo As Double, dblTC As Double, dblRetiroSoles As Double, dblRetiroDolar As Double
            Dim obj As New Cls_LiquidacionValor_LN
            Dim intComprobante As Integer, intId As Integer, intIdSoles As Integer, intIdDolar As Integer
            Dim strComprobante As String, dblMonto As Double
            Dim strCodigoSoles As String, strCodigoDolar As String

            strFecha = CDate(FechaServidor()).ToShortDateString
            dblTotalEfectivo = CType(Me.lblTotalEfectivoCierre.Text, Double)
            dblTC = CType(Me.lblTipoCambioCierre.Text, Double)
            dblRetiroSoles = IIf(Val(Me.txtRetiroSolesCierre.Text) = 0, 0, CType(Me.txtRetiroSolesCierre.Text, Double))
            dblRetiroDolar = IIf(Val(Me.txtRetiroDolarCierre.Text) = 0, 0, CType(Me.txtRetiroDolarCierre.Text, Double))

            Dim dt As DataTable = obj.CerrarCaja(strFecha, dtoUSUARIOS.iIDAGENCIAS,  dtoUSUARIOS.IdLogin, dblTotalEfectivo, dblTC, _
                           dblRetiroSoles, dblRetiroDolar, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
            If dt.Rows.Count > 0 Then
                intId = CType(dt.Rows(0).Item("id").ToString, Integer)
                For Each row As DataGridViewRow In Me.dgvComprobanteCierre.Rows
                    intComprobante = row.Cells("id").Value
                    strComprobante = row.Cells("comprobante").Value
                    dblMonto = row.Cells("total").Value
                    obj.GrabarComprobante(intId, intComprobante, strComprobante, dblMonto, dtoUSUARIOS.Unidad, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                Next
                If dblRetiroSoles > 0 Then
                    intIdSoles = CType(dt.Rows(0).Item("soles").ToString, Integer)
                    For Each row As DataRow In dtSoles.Rows
                        If Not IsDBNull(row.Item("cantidad")) Then
                            obj.GrabarBillete(intIdSoles, row.Item("id"), row.Item("cantidad"), dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                        End If
                    Next
                End If
                If dblRetiroDolar > 0 Then
                    intIdDolar = CType(dt.Rows(0).Item("dolar").ToString, Integer)
                    For Each row As DataRow In dtDolares.Rows
                        If Not IsDBNull(row.Item("cantidad")) Then
                            obj.GrabarBillete(intIdDolar, row.Item("id"), row.Item("cantidad"), dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                        End If
                    Next
                End If

                'Imprimir ticket con codigo de barras
                If dblRetiroSoles > 0 Then
                    strCodigoSoles = dt.Rows(0).Item("codigo_soles")
                    ImprimirTicket(xImpresora, strCodigoSoles, dblRetiroSoles, 1)
                End If
                If dblRetiroDolar > 0 Then
                    strCodigoDolar = dt.Rows(0).Item("codigo_dolar")
                    ImprimirTicket(xImpresora, strCodigoDolar, dblRetiroDolar, 2)
                End If

                Cursor = Cursors.Default
                MessageBox.Show("Se realizó el Pre-Cierre", "Cerrar Pre-Cierre", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'dtSoles = Nothing
                'dtDolares = Nothing
                'dblSaldo = 0
                LimpiarCerrar()
                Me.tabCabecera.SelectedTab = Me.tabCabecera.TabPages("tabConsulta")
                Me.btnConsultar_Click(Nothing, Nothing)
                Me.btnConsultar.Focus()
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Cerrar Pre-Cierre", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub cboUnidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUnidad.SelectedIndexChanged
        Try
            Limpiar()
            Dim obj As New Cls_LiquidacionValor_LN
            Dim dt As DataTable = obj.ListarUsuario(Me.dtpFecha.Value.ToShortDateString, dtoUSUARIOS.iIDAGENCIAS, intNivel, dtoUSUARIOS.IdLogin)
            With Me.cboUsuario
                .DisplayMember = "descripcion"
                .ValueMember = "id"
                .DataSource = dt
                .SelectedValue = 0
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Listar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Try
            Cursor = Cursors.WaitCursor
            ListarCierre()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Consultar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Sub ListarCierre()
        Try
            Dim obj As New Cls_LiquidacionValor_LN
            Dim dt As DataTable = obj.ListarCierre(Me.dtpFecha.Value.ToShortDateString, dtoUSUARIOS.iIDAGENCIAS, Me.cboUsuario.SelectedValue)
            Me.dgvMovimiento.DataSource = dt
            Total()
            If Me.dgvMovimiento.Rows.Count = 0 Then
                Me.tsbAnular.Enabled = False
                Me.dgvRetiro.DataSource = Nothing
                Me.dgvBillete.DataSource = Nothing
                Me.dgvComprobante.DataSource = Nothing
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub dgvMovimiento_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMovimiento.RowEnter
        Try
            Dim intID As Integer
            Dim obj As New Cls_LiquidacionValor_LN

            intID = Me.dgvMovimiento.Rows(e.RowIndex).Cells("id").Value
            Dim dt As DataTable = obj.ListarRetiro(intID)
            Me.dgvRetiro.DataSource = dt

            dt = obj.ListarComprobante(intID)
            Me.dgvComprobante.DataSource = dt

            'Activa anular si algun retiros del pre-cierre tienen el estado en bolsa
            Dim blnAnular As Boolean = True
            If Me.dgvRetiro.Rows.Count > 0 Then
                For Each row As DataGridViewRow In Me.dgvRetiro.Rows
                    If row.Cells("idestado").Value <> 1 Then
                        blnAnular = False
                    End If
                Next
            Else
                blnAnular = False
            End If
            Me.tsbAnular.Enabled = blnAnular

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Consultar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvRetiro_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRetiro.RowEnter
        Try
            Dim intID As Integer
            Dim obj As New Cls_LiquidacionValor_LN

            intID = Me.dgvRetiro.Rows(e.RowIndex).Cells("id").Value
            Dim dt As DataTable = obj.ListarBilletes(intID)
            Me.dgvBillete.DataSource = dt

            ''Activa anular si retiro tiene el estado en bolsa
            'Dim blnAnular As Boolean = Me.dgvRetiro.Rows(e.RowIndex).Cells("idestado").Value = 1
            'Me.tsbAnular.Enabled = blnAnular

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Consultar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Sub Limpiar()
        Me.dgvMovimiento.DataSource = Nothing
        Me.dgvRetiro.DataSource = Nothing
        Me.dgvBillete.DataSource = Nothing
        Me.dgvComprobante.DataSource = Nothing

        Me.lblMonto.Text = "0.00"
        Me.lblRetiroSoles.Text = "0.00"
        Me.lblRetiroDolar.Text = "0.00"
        Me.lblRetiroTotal.Text = "0.00"
        Me.lblSaldo.Text = "0.00"

        Me.tsbAnular.Enabled = False
    End Sub

    Sub Total()
        Dim dt As DataTable
        Dim dblMonto As Double, dblRetiroSoles As Double, dblRetiroDolar As Double, dblRetiroTotal As Double, dblSaldo As Double, dblTC As Double
        Dim intMoneda As Integer

        If Me.dgvMovimiento.Rows.Count > 0 Then
            dt = Me.dgvMovimiento.DataSource
            dblMonto = IIf(IsDBNull(dt.Compute("sum(monto)", "")), 0, dt.Compute("sum(monto)", ""))
            dblRetiroSoles = IIf(IsDBNull(dt.Compute("sum(soles)", "")), 0, dt.Compute("sum(soles)", ""))
            dblRetiroDolar = IIf(IsDBNull(dt.Compute("sum(dolar)", "")), 0, dt.Compute("sum(dolar)", ""))
            dblRetiroTotal = IIf(IsDBNull(dt.Compute("sum(total)", "")), 0, dt.Compute("sum(total)", ""))
            dblSaldo = dblMonto - dblRetiroTotal
        End If
        Me.lblMonto.Text = Format(dblMonto, "###,###,###0.00")
        Me.lblRetiroSoles.Text = Format(dblRetiroSoles, "###,###,###0.00")
        Me.lblRetiroDolar.Text = Format(dblRetiroDolar, "###,###,###0.00")
        Me.lblRetiroTotal.Text = Format(dblRetiroTotal, "###,###,###0.00")
        Me.lblSaldo.Text = Format(dblSaldo, "###,###,###0.00")
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        Limpiar()
        If intNivel = 2 Then
            Try
                Dim obj As New Cls_LiquidacionValor_LN
                Dim dt As DataTable = obj.ListarUsuario(Me.dtpFecha.Value.ToShortDateString, dtoUSUARIOS.iIDAGENCIAS, intNivel, dtoUSUARIOS.IdLogin)
                With Me.cboUsuario
                    .DisplayMember = "descripcion"
                    .ValueMember = "id"
                    .DataSource = dt
                    .SelectedValue = 0
                End With

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Listar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Private Sub cboUsuario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUsuario.SelectedIndexChanged
        Limpiar()
    End Sub

    Private Sub tabDetalle_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabDetalle.SelectedIndexChanged
        If Me.tabDetalle.SelectedTab Is Me.tabDetalle.TabPages("tabCierre") Then
            If Me.dgvMovimiento.Rows.Count = 0 Then
                Me.tsbAnular.Enabled = False
            Else
                'Activa anular si algun retiros del pre-cierre tienen el estado en bolsa
                Dim blnAnular As Boolean = True
                If Me.dgvRetiro.Rows.Count > 0 Then
                    For Each row As DataGridViewRow In Me.dgvRetiro.Rows
                        If row.Cells("idestado").Value <> 1 Then
                            blnAnular = False
                        End If
                    Next
                Else
                    blnAnular = False
                End If
                Me.tsbAnular.Enabled = blnAnular
            End If
        Else
            Me.tsbAnular.Enabled = False
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub tsbAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAnular.Click
        Try
            Dim dlgRespuesta As DialogResult

            If Me.tabDetalle.SelectedTab Is Me.tabDetalle.TabPages("tabCierre") Then
                dlgRespuesta = MessageBox.Show("¿Está seguro de anular el pre-cierre?", "Anular Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                    AnularCierre()
                    ListarCierre()
                    Me.btnConsultar.Focus()
                End If
            ElseIf Me.tabDetalle.SelectedTab Is Me.tabDetalle.TabPages("tabRetiro") Then
                dlgRespuesta = MessageBox.Show("¿Está seguro de anular el Retiro?", "Anular Retiro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                    AnularRetiro()

                    Dim obj As New Cls_LiquidacionValor_LN
                    Dim dt As DataTable = obj.ListarRetiro(Me.dgvMovimiento.CurrentRow.Cells("id").Value)
                    Me.dgvRetiro.DataSource = dt

                    Me.btnConsultar.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Anular Cierre", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub AnularRetiro()
        Try
            Dim intID As Integer = Me.dgvRetiro.CurrentRow.Cells("id").Value
            Dim obj As New Cls_LiquidacionValor_LN
            obj.AnularRetiro(intID, Me.dgvMovimiento.CurrentRow.Cells("id").Value, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub AnularCierre()
        Try
            Dim intID As Integer = Me.dgvMovimiento.CurrentRow.Cells("id").Value
            Dim obj As New Cls_LiquidacionValor_LN
            obj.AnularCierre(intID, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class