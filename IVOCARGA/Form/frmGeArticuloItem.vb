Public Class frmGeArticuloItem
    Dim blnSalir As Boolean

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
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.ReadOnly = True
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
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código SKU"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            .Columns.AddRange(col_id, col_codigo)
        End With
    End Sub

    Public lista As New List(Of String)

    Private intCantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return intCantidad
        End Get
        Set(ByVal value As Integer)
            intCantidad = value
        End Set
    End Property

    Private strArticulo As String
    Public Property Articulo() As String
        Get
            Return strArticulo
        End Get
        Set(ByVal value As String)
            strArticulo = value
        End Set
    End Property


    Private Sub frmGeArticuloItem_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmGeArticuloItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        blnSalir = True
        Configurardgv()
        Me.Text = "Agregar " & intCantidad & " Código(s) SKU al artículo " & strArticulo

        If lista.Count > 0 Then
            For i As Integer = 0 To lista.Count - 1
                AgregarItem(lista(i))
            Next
        End If
    End Sub

    Private Sub txtItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItem.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            e.Handled = Not ValidarNumero(e.KeyChar)
        End If
    End Sub

    Private Sub txtItem_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItem.TextChanged
        Me.btnAgregar.Enabled = Me.txtItem.Text.Trim.Length > 0
    End Sub

    Private Sub dgv_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv.RowsAdded
        Me.btnAceptar.Enabled = True
        Me.btnEliminar.Enabled = True
        Me.btnAgregar.Enabled = Not (Me.dgv.Rows.Count = intCantidad)
        Me.txtItem.Enabled = Not (Me.dgv.Rows.Count = intCantidad)
    End Sub

    Private Sub dgv_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgv.RowsRemoved
        Me.btnAceptar.Enabled = Me.dgv.RowCount > 0
        Me.btnEliminar.Enabled = Me.dgv.RowCount > 0
        Me.txtItem.Enabled = True
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        AgregarItem(Me.txtItem.Text.Trim)
    End Sub

    Sub AgregarItem(ByVal item As String)
        With Me.dgv
            .Rows.Add()
            .Rows(.Rows.Count - 1).Cells(1).Value = item
            Me.txtItem.Text = ""
            If Me.dgv.Rows.Count = intCantidad Then
                Me.btnAceptar.Focus()
            Else
                Me.txtItem.Focus()
            End If
        End With
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.dgv.Rows.Count < intCantidad Then
            MessageBox.Show("Debe ingresar " & Cantidad & " códigos SKU", "Agregar Código SKU", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtItem.Focus()
            blnSalir = False
        End If

        lista = New List(Of String)
        For Each row As DataGridViewRow In dgv.Rows
            lista.Add(row.Cells("codigo").Value)
        Next
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Me.dgv.Rows.RemoveAt(Me.dgv.CurrentCell.RowIndex)
        If Me.dgv.Rows.Count = 0 Then
            lista.Clear()
        End If
        Me.txtItem.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
    End Sub

    Private Sub rbtLista_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtLista.CheckedChanged, rbtManual.CheckedChanged
        If rbtLista.Checked Then
            Me.pnlLista.Visible = True
            Me.pnlManual.Visible = False
        Else
            Me.pnlManual.Visible = True
            Me.pnlLista.Visible = False
        End If
    End Sub
End Class