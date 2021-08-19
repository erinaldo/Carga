Imports INTEGRACION_LN

Public Class FrmAgregarContacto
    Private intCliente As Integer
    Public Property Cliente() As Integer
        Get
            Return intCliente
        End Get
        Set(ByVal value As Integer)
            intCliente = value
        End Set
    End Property


    Private Sub ConfigurarDGVContactos()
        With dgvContactos
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 7.0!, FontStyle.Regular)
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
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Nº Id" : .Visible = False
            End With
            x += +1
            Dim col_cargo As New DataGridViewTextBoxColumn
            With col_cargo
                .Name = "cargo" : .DataPropertyName = "cargo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cargo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_nombres As New DataGridViewTextBoxColumn
            With col_nombres
                .Name = "nombres" : .DataPropertyName = "nombres"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Contacto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            .Columns.AddRange(col_id, col_nombres, col_cargo)
        End With
    End Sub

    Private Sub FrmAgregarContacto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim objLN As New Cls_Contacto_LN
        Dim dt As DataTable = objLN.ListarContacto(intCliente, 1)
        dgvContactos.DataSource = dt
        ConfigurarDGVContactos()
    End Sub

    Private Sub dgvContactos_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvContactos.DoubleClick
        If dgvContactos.Rows.Count > 0 Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub
End Class