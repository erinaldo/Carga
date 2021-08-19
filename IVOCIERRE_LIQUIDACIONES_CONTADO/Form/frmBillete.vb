Imports INTEGRACION_LN
Public Class frmBillete
    Public dt As DataTable
    Public dtBillete As DataTable
    Public dtAux As DataTable
    Private intMoneda As Integer
    Dim blnSalir As Boolean
    Public Property Moneda() As Integer
        Get
            Return intMoneda
        End Get
        Set(ByVal value As Integer)
            intMoneda = value
        End Set
    End Property

    Private dblMontoCaja As Double
    Public Property MontoCaja() As Double
        Get
            Return dblMontoCaja
        End Get
        Set(ByVal value As Double)
            dblMontoCaja = value
        End Set
    End Property

    Private dblTipoCambio As Double
    Public Property TipoCambio() As Double
        Get
            Return dblTipoCambio
        End Get
        Set(ByVal value As Double)
            dblTipoCambio = value
        End Set
    End Property

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
            Dim col_valor As New DataGridViewTextBoxColumn
            With col_valor
                .Name = "valor" : .DataPropertyName = "valor"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Billete" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            .Columns.AddRange(col_id, col_valor, col_cantidad, col_monto)
        End With
    End Sub

    Private Sub frmBillete_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.txtCantidad.Focus()
        Me.txtCantidad.SelectAll()
    End Sub

    Private Sub frmBillete_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmBillete_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        blnSalir = True
        FormateardgvBillete()
        Me.txtCaja.Text = Format(MontoCaja, "###,###,###0.00")
        ListarBillete()
        Total()
    End Sub

    Sub ListarBillete()
        Dim obj As New Cls_LiquidacionValor_LN
        If Not IsNothing(dt) Then
            dtBillete = dt
        Else
            dtBillete = obj.ListarBillete(Moneda)
        End If
        dtAux = dtBillete.Copy
        With Me.cboBillete
            .ValueMember = "id"
            .DisplayMember = "valor2"
            .DataSource = dtBillete
        End With

        RemoveHandler dgvBillete.RowEnter, AddressOf dgvBillete_RowEnter
        Me.dgvBillete.DataSource = dtBillete
        AddHandler dgvBillete.RowEnter, AddressOf dgvBillete_RowEnter
    End Sub

    Private Sub cboBillete_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillete.SelectedIndexChanged
        Me.txtCantidad.Focus()
    End Sub

    Private Sub txtCantidad_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad.Enter
        Me.txtCantidad.SelectAll()
    End Sub

    Private Sub txtCantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
        Dim intPosicion As Integer = Me.cboBillete.SelectedIndex
        If e.KeyCode = Keys.Up Then
            If intPosicion > 0 Then
                intPosicion -= 1
                Me.cboBillete.SelectedIndex = intPosicion
            End If
            Me.tiempo.Enabled = True
        ElseIf e.KeyCode = Keys.Down Then
            If intPosicion < Me.cboBillete.Items.Count - 1 Then
                intPosicion += 1
                Me.cboBillete.SelectedIndex = intPosicion
            End If
            Me.tiempo.Enabled = True
        End If
    End Sub

    Private Sub dgvBillete_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvBillete.CurrentCellDirtyStateChanged
        dgvBillete.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub dgvBillete_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBillete.RowEnter
        Dim intCantidad As Integer = 0
        If Not IsDBNull(Me.dgvBillete.Rows(e.RowIndex).Cells("cantidad").Value) Then
            If Not Me.dgvBillete.Rows(e.RowIndex).Cells("cantidad").Value = "" Then
                intCantidad = Me.dgvBillete.Rows(e.RowIndex).Cells("cantidad").Value
            End If
        End If
        Me.txtCantidad.Text = IIf(intCantidad = 0, "", intCantidad)
    End Sub

    Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.btnAgregar_Click(Nothing, Nothing)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim intCantidad As Integer, dblMonto As Double, dblBillete As Double
        intCantidad = IIf(Val(Me.txtCantidad.Text) = 0, 0, Val(Me.txtCantidad.Text))
        dblBillete = Me.dgvBillete.CurrentRow.Cells("valor").Value
        dblMonto = dblBillete * intCantidad

        If intCantidad = 0 Then
            Me.dgvBillete.CurrentRow.Cells("cantidad").Value = ""
            Me.dgvBillete.CurrentRow.Cells("monto").Value = ""
        Else
            Me.dgvBillete.CurrentRow.Cells("cantidad").Value = intCantidad
            Me.dgvBillete.CurrentRow.Cells("monto").Value = Format(dblMonto, "###,###,###0.00")
        End If
        Total()
        dtBillete.AcceptChanges()
    End Sub

    Sub Total()
        Dim dblBillete As Double = 0
        Dim dblCaja As Double, dblDiferencia As Double
        For Each row As DataGridViewRow In Me.dgvBillete.Rows
            If Not IsDBNull(row.Cells("monto").Value) Then
                If Not row.Cells("monto").Value = "" Then
                    dblBillete += row.Cells("monto").Value
                End If
            End If
        Next
        dblCaja = CType(Me.txtCaja.Text, Double)
        Me.txtBillete.Text = Format(dblBillete, "###,###,###0.00")
        Me.txtDiferencia.Text = Format(dblCaja - dblBillete, "###,###,###0.00")

        dblDiferencia = IIf(Val(Me.txtDiferencia.Text) = 0, 0, CDbl(Me.txtDiferencia.Text))
        If dblDiferencia < 0 Then
            Me.txtDiferencia.ForeColor = Color.Red
            'Me.btnAceptar.Enabled = False
        Else
            Me.txtDiferencia.ForeColor = Color.Black
            Me.txtDiferencia.Font = New Font(Me.Font, FontStyle.Bold)
            'Me.btnAceptar.Enabled = True
        End If
    End Sub

    Private Sub txtCaja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCaja.KeyPress, txtBillete.KeyPress, txtDiferencia.KeyPress
        e.Handled = True
    End Sub

    Private Sub tiempo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tiempo.Tick
        Me.txtCantidad.SelectAll()
        Me.tiempo.Enabled = False
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        dtBillete = dtAux.Copy
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim dblDiferencia As Double
        dblDiferencia = IIf(Val(Me.txtDiferencia.Text) = 0, 0, CDbl(Me.txtDiferencia.Text))
        If dblDiferencia < 0 Then
            MessageBox.Show("No puede retirar un monto mayor al de la caja", "Retirar", MessageBoxButtons.OK)
            Me.txtCantidad.Focus()
            blnSalir = False
        End If
    End Sub
End Class