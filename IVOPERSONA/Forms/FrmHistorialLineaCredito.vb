Public Class FrmHistorialLineaCredito
    Private iCliente As Integer
    Public Property Cliente() As Integer
        Get
            Return iCliente
        End Get
        Set(ByVal value As Integer)
            iCliente = value
        End Set
    End Property

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Close()
    End Sub

    Private Sub FrmHistorialLineaCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.FormatoDgv()
            CargarHistorial()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub FormatoDgv()
        With dgv
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            .DefaultCellStyle.SelectionForeColor = Color.Black

            Dim fecha_aprobacion As New DataGridViewTextBoxColumn
            With fecha_aprobacion
                .HeaderText = "Fecha Aprobación"
                .Name = "fecha_aprobacion"
                .DataPropertyName = "fecha_aprobacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
            End With

            Dim linea_solicitada As New DataGridViewTextBoxColumn
            With linea_solicitada
                .HeaderText = "Monto Aprobado"
                .Name = "linea_solicitada"
                .DataPropertyName = "linea_solicitada"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .DefaultCellStyle.Format = "N2"
            End With

            Dim sobregiro As New DataGridViewTextBoxColumn
            With sobregiro
                .HeaderText = "Sobregiro"
                .Name = "sobregiro"
                .DataPropertyName = "sobregiro"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .DefaultCellStyle.Format = "N2"
            End With

            Dim total_asignado As New DataGridViewTextBoxColumn
            With total_asignado
                .HeaderText = "Línea Crédito"
                .Name = "total_asignado"
                .DataPropertyName = "total_asignado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            .Columns.AddRange(fecha_aprobacion, linea_solicitada, sobregiro, total_asignado)
        End With
    End Sub

    Sub CargarHistorial()
        Dim obj As New dtoAprobacion
        dgv.DataSource = obj.HistorialCredito(iCliente)
    End Sub

End Class