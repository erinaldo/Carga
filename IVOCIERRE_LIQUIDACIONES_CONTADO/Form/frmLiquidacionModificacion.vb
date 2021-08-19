Public Class frmLiquidacionModificacion
    Dim intTipoPago As Integer, intTipoTarjeta As Integer, intTarjeta As Integer

#Region "Propiedades"
    Private strInicio As String
    Public Property Inicio() As String
        Get
            Return strInicio
        End Get
        Set(ByVal value As String)
            strInicio = value
        End Set
    End Property

    Private strFin As String
    Public Property Fin() As String
        Get
            Return strFin
        End Get
        Set(ByVal value As String)
            strFin = value
        End Set
    End Property

    Private intAgencia As Integer
    Public Property Agencia() As Integer
        Get
            Return intAgencia
        End Get
        Set(ByVal value As Integer)
            intAgencia = value
        End Set
    End Property

    Private intUsuario As Integer
    Public Property Usuario() As Integer
        Get
            Return intUsuario
        End Get
        Set(ByVal value As Integer)
            intUsuario = value
        End Set
    End Property

#End Region

    Sub FormatearDgv()
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
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .HeaderText = "Fecha" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Comprobante" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_tipo_pago As New DataGridViewTextBoxColumn
            With col_tipo_pago
                .Name = "tipo_pago" : .DataPropertyName = "tipo_pago"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Pago" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .Visible = False
            End With
            x += +1
            Dim col_tipo_tarjeta As New DataGridViewTextBoxColumn
            With col_tipo_tarjeta
                .Name = "tipo_tarjeta" : .DataPropertyName = "tipo_tarjeta"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Tarjeta" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .Visible = False
            End With
            x += +1
            Dim col_numero_tarjeta As New DataGridViewTextBoxColumn
            With col_numero_tarjeta
                .Name = "numero_tarjeta" : .DataPropertyName = "numero_tarjeta"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Tarjeta" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .Visible = False
            End With
            x += +1
            Dim col_idtipo_pago As New DataGridViewTextBoxColumn
            With col_idtipo_pago
                .Name = "idtipo_pago" : .DataPropertyName = "idtipo_pago" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_id_tipo_tarjeta As New DataGridViewTextBoxColumn
            With col_id_tipo_tarjeta
                .Name = "id_tipo_tarjeta" : .DataPropertyName = "id_tipo_tarjeta" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_idtipo_comprobante As New DataGridViewTextBoxColumn
            With col_idtipo_comprobante
                .Name = "idtipo_comprobante" : .DataPropertyName = "idtipo_comprobante" : .DisplayIndex = x : .Visible = False
            End With
            x += +1
            Dim col_idfactura As New DataGridViewTextBoxColumn
            With col_idfactura
                .Name = "idfactura" : .DataPropertyName = "idfactura" : .DisplayIndex = x : .Visible = False
            End With
            .Columns.AddRange(col_fecha, col_destino, col_tipo, col_comprobante, col_total, col_tipo_pago, col_tipo_tarjeta, col_numero_tarjeta, _
                              col_idtipo_pago, col_id_tipo_tarjeta, col_idtipo_comprobante, col_idfactura)
        End With
    End Sub

    Sub FormatearDgvPago()
        With dgvPago
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
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .HeaderText = "id" : .Visible = False
            End With
            x += +1
            Dim col_tipo_pago As New DataGridViewTextBoxColumn
            With col_tipo_pago
                .Name = "tipo_pago" : .DataPropertyName = "tipo_pago"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Pago" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_idtipo_pago As New DataGridViewTextBoxColumn
            With col_idtipo_pago
                .Name = "idtipo_pago" : .DataPropertyName = "idtipo_pago"
                .DisplayIndex = x : .Visible = True : .HeaderText = "idtipo_pago" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Visible = False
            End With
            x += +1
            Dim col_tipo_tarjeta As New DataGridViewTextBoxColumn
            With col_tipo_tarjeta
                .Name = "tipo_tarjeta" : .DataPropertyName = "tipo_tarjeta"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Tarjeta" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_idtipo_tarjeta As New DataGridViewTextBoxColumn
            With col_idtipo_tarjeta
                .Name = "idtipo_tarjeta" : .DataPropertyName = "idtipo_tarjeta"
                .DisplayIndex = x : .Visible = True : .HeaderText = "idTipo_tarjeta" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Visible = False
            End With
            x += +1
            Dim col_tarjeta As New DataGridViewTextBoxColumn
            With col_tarjeta
                .Name = "tarjeta" : .DataPropertyName = "tarjeta"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tarjeta" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_idtarjeta As New DataGridViewTextBoxColumn
            With col_idtarjeta
                .Name = "idtarjeta" : .DataPropertyName = "idtarjeta"
                .DisplayIndex = x : .Visible = True : .HeaderText = "idtarjeta" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Visible = False
            End With
            x += +1
            Dim col_pago As New DataGridViewTextBoxColumn
            With col_pago
                .Name = "pago" : .DataPropertyName = "pago"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Pago" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            .Columns.AddRange(col_id, col_tipo_pago, col_idtipo_pago, col_tipo_tarjeta, col_idtipo_tarjeta, col_tarjeta, col_idtarjeta, col_pago)
        End With
    End Sub

    Sub Listar()
        Dim obj As New dtoCIERRE_LIQUIDACIONES
        Dim dt As DataTable = obj.ListarLiquidacion(Inicio, Fin, Agencia, Usuario)
        Me.dgv.DataSource = dt
        If dt.Rows.Count = 0 Then
            Me.btnGrabar.Enabled = False
        End If
    End Sub

    Private Sub frmLiquidacionModificacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Dim obj As New dtoCIERRE_LIQUIDACIONES

            Listar()

            With Me.cboTipoPago
                .DisplayMember = "descripcion"
                .ValueMember = "id"
                .DataSource = obj.ListarTipoPago
                .SelectedValue = 0
            End With

            With Me.cboTipoTarjeta
                .DisplayMember = "descripcion"
                .ValueMember = "id"
                .DataSource = obj.Listar_Tipo_Tarjeta
                .SelectedValue = 0
            End With

            FormatearDgv()
            FormatearDgvPago()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Liquidación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tabLiquidacion_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabLiquidacion.SelectedIndexChanged
        If tabLiquidacion.SelectedTab Is tabLiquidacion.TabPages("tabMantenimiento") Then
            With Me.dgvPago
                If .Rows.Count > 0 Then
                    Me.cboTipoPago.SelectedValue = .CurrentRow.Cells("idtipo_pago").Value
                    Me.cboTipoTarjeta.SelectedValue = .CurrentRow.Cells("idtipo_tarjeta").Value
                    Me.cboTarjeta.SelectedValue = .CurrentRow.Cells("idtarjeta").Value
                    intTipoPago = Me.cboTipoPago.SelectedValue
                    intTipoTarjeta = Me.cboTipoTarjeta.SelectedValue
                    intTarjeta = Me.cboTarjeta.SelectedValue
                End If
            End With
        End If
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick, dgvPago.CellContentClick

    End Sub

    Private Sub dgv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv.DoubleClick, dgvPago.DoubleClick
        If Me.dgv.Rows.Count > 0 Then
            tabLiquidacion.SelectedTab = tabLiquidacion.TabPages("tabMantenimiento")
            Me.cboTipoPago.Focus()
        End If
    End Sub

    Private Sub cboTipoPago_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoPago.SelectedIndexChanged

    End Sub

    Private Sub cboTipoPago_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboTipoPago.SelectedValueChanged
        If Me.cboTipoPago.SelectedValue = 2 Then
            Me.cboTipoTarjeta.SelectedValue = 0
            Me.cboTipoTarjeta.Enabled = True
            Me.cboTarjeta.SelectedValue = 0
            Me.cboTarjeta.Enabled = True
            Me.cboTipoTarjeta.Focus()
            Me.cboTipoTarjeta.DroppedDown = True
        Else
            Me.cboTipoTarjeta.SelectedValue = 0
            Me.cboTipoTarjeta.Enabled = False
            Me.cboTarjeta.SelectedValue = 0
            Me.cboTarjeta.Enabled = False
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        tabLiquidacion.SelectedTab = tabLiquidacion.TabPages("tabLista")
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If Me.cboTipoPago.SelectedValue = 6 Then
            MessageBox.Show("El tipo de pago Nota de crédito no está disponible", "Liquidación Detalle", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboTipoPago.Focus()
            Me.cboTipoPago.DroppedDown = True
            Return
            Return
        End If
        If Me.cboTipoPago.SelectedValue = 1 Then
            If intTipoPago = Me.cboTipoPago.SelectedValue Then
                MessageBox.Show("Seleccione un nuevo tipo de pago", "Liquidación Detalle", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboTipoPago.Focus()
                Me.cboTipoPago.DroppedDown = True
                Return
            End If
        ElseIf Me.cboTipoPago.SelectedValue = 2 Then
            If intTipoPago = Me.cboTipoPago.SelectedValue And intTipoTarjeta = Me.cboTipoTarjeta.SelectedValue And intTarjeta = Me.cboTarjeta.SelectedValue Then
                MessageBox.Show("Seleccione una tarjeta nueva", "Liquidación Detalle", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboTipoTarjeta.Focus()
                Me.cboTipoTarjeta.DroppedDown = True
                Return
            End If
        End If

        If Me.cboTipoPago.SelectedValue = 2 Then
            If Me.cboTipoTarjeta.SelectedValue = 0 Then
                MessageBox.Show("Seleccione tipo de tarjeta", "Liquidación Detalle", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboTipoTarjeta.Focus()
                Me.cboTipoTarjeta.DroppedDown = True
                Return
            End If
            If Me.cboTarjeta.SelectedValue = 0 Then
                MessageBox.Show("Seleccione tarjeta", "Liquidación Detalle", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboTarjeta.Focus()
                Me.cboTarjeta.DroppedDown = True
                Return
            End If

        End If

        Grabar()

    End Sub

    Sub Grabar()
        Try
            Dim obj As New dtoCIERRE_LIQUIDACIONES
            obj.ActualizarComprobante(Me.dgv.CurrentRow.Cells("idfactura").Value, Me.dgvPago.CurrentRow.Cells("id").Value, _
                                      Me.cboTipoPago.SelectedValue, Me.cboTipoTarjeta.SelectedValue, Me.cboTarjeta.SelectedValue)
            Listar()
            tabLiquidacion.SelectedTab = tabLiquidacion.TabPages("tabLista")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Liquidación Detalle", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgv_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.RowEnter
        Try
            If IsReference(dgv.Rows(e.RowIndex).Cells("idfactura").Value) Then Return
            Dim obj As New dtoVentaCargaContado
            Dim intComprobante As Integer = dgv.Rows(e.RowIndex).Cells("idfactura").Value
            Dim dt As DataTable = obj.ListarPago(intComprobante, 1)
            dgvPago.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Liquidación Detalle", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboTipoTarjeta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoTarjeta.SelectedIndexChanged
        Dim obj As New dtoVentaCargaContado
        Dim intTipoTarjeta As Integer = Me.cboTipoTarjeta.SelectedValue
        Dim dt As DataTable
        dt = obj.ListarTarjeta(intTipoTarjeta)
        With Me.cboTarjeta
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = dt
            If Me.btnGrabar.Enabled Then
                Me.cboTarjeta.SelectedValue = IIf(IsDBNull(dgvPago.CurrentRow.Cells("idtarjeta").Value), 0, dgvPago.CurrentRow.Cells("idtarjeta").Value)
            End If
        End With
    End Sub
End Class

