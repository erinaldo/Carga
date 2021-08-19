Public Class frmPagos

    Private intComprobante As Integer
    Public Property Comprobante() As Integer
        Get
            Return intComprobante
        End Get
        Set(ByVal value As Integer)
            intComprobante = value
        End Set
    End Property

    Sub FormatoGrid()
        'Dim dv_SELEC_VENTA_UBICA As DataView
        'dv_SELEC_VENTA_UBICA = New DataView
        'dv_SELEC_VENTA_UBICA = ObjEntregaCarga.SP_SELEC_VENTA_UBICA(iTipoComprobante, iComprobante)

        dgvPago.Columns.Clear()
        With dgvPago
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            '.BackgroundColor = SystemColors.Window
            '.DataSource = dv_SELEC_VENTA_UBICA
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersWidth = 10
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
            '.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            '.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")

        End With

        Dim tipo_pago As New DataGridViewTextBoxColumn
        With tipo_pago
            .HeaderText = "Tipo Pago"
            .Name = "tipo_pago"
            .DataPropertyName = "tipo_pago"
            '.Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim pago As New DataGridViewTextBoxColumn
        With pago
            .HeaderText = "Monto"
            .Name = "pago"
            .DataPropertyName = "pago"
            '.Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
        End With

        With dgvPago
            .Columns.AddRange(tipo_pago, pago)
        End With
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Close()
    End Sub

    Private Sub frmPagos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormatoGrid()
        Dim obj As New dtoVentaCargaContado
        dgvPago.DataSource = obj.ListarPago(Comprobante)
    End Sub
End Class