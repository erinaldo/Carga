Public Class frmClienteVarios
    Sub Formato()
        With Me.dgvCliente
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            '.AutoGenerateColumns = False
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.ScrollBars = ScrollBars.Both
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .ReadOnly = True

            Dim idpersona As New DataGridViewTextBoxColumn
            With idpersona
                .HeaderText = "idpersona"
                .Name = "idpersona"
                .DataPropertyName = "idpersona"
                .Visible = False
            End With

            Dim razon_social As New DataGridViewTextBoxColumn
            With razon_social
                .HeaderText = "Razón Social"
                .Name = "razon_social"
                .DataPropertyName = "razon_social"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            Dim idtipo_doc_identidad As New DataGridViewTextBoxColumn
            With idtipo_doc_identidad
                .HeaderText = "Tipo Documento"
                .Name = "tipo"
                .DataPropertyName = "tipo"
                .Visible = False
            End With

            Dim tipo_doc_identidad As New DataGridViewTextBoxColumn
            With tipo_doc_identidad
                .HeaderText = "Tipo Documento"
                .Name = "tipo_doc_identidad"
                .DataPropertyName = "tipo_doc_identidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            Dim nu_docu_suna As New DataGridViewTextBoxColumn
            With nu_docu_suna
                .HeaderText = "Nº Documento"
                .Name = "nu_docu_suna"
                .DataPropertyName = "nu_docu_suna"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With

            .Columns.AddRange(tipo_doc_identidad, nu_docu_suna, razon_social, idpersona, idtipo_doc_identidad)
        End With
    End Sub

    Private Sub frmClienteVarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formato()
    End Sub
End Class