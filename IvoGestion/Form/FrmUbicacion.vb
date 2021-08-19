Public Class FrmUbicacion
    Public iComprobante As Integer
    Public iTipoComprobante As Integer
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Sub FORMAT_GRILLA1()
        Dim dv_SELEC_VENTA_UBICA As DataView

        dv_SELEC_VENTA_UBICA = New DataView

        dv_SELEC_VENTA_UBICA = ObjEntregaCarga.SP_SELEC_VENTA_UBICA(iTipoComprobante, iComprobante)

        dgv1.Columns.Clear()
        With dgv1
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .BackgroundColor = SystemColors.Window
            .DataSource = dv_SELEC_VENTA_UBICA
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersWidth = 10
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")

        End With

        Dim CODI_UBI As New DataGridViewTextBoxColumn
        With CODI_UBI
            .HeaderText = "Ubicación"
            .Name = "CODI_UBI"
            .DataPropertyName = "CODI_UBI"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim CODI_BARRA As New DataGridViewTextBoxColumn
        With CODI_BARRA
            .HeaderText = "Cód. Barra"
            .Name = "CODIGO_BARRA"
            .DataPropertyName = "CODIGO_BARRA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ALMA As New DataGridViewTextBoxColumn
        With ALMA
            .HeaderText = "Almacén"
            .Name = "ALMA"
            .DataPropertyName = "ALMA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim AREA As New DataGridViewTextBoxColumn
        With AREA
            .HeaderText = "Area"
            .Name = "AREA"
            .DataPropertyName = "AREA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ANA As New DataGridViewTextBoxColumn
        With ANA
            .HeaderText = "Anaquel"
            .Name = "ANA"
            .DataPropertyName = "ANA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim COLUM As New DataGridViewTextBoxColumn
        With COLUM
            .HeaderText = "Colum."
            .Name = "COLUM"
            .DataPropertyName = "COLUM"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
        End With
        Dim FILA As New DataGridViewTextBoxColumn
        With FILA
            .HeaderText = "Fila"
            .Name = "FILA"
            .DataPropertyName = "FILA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
        End With
        With dgv1
            .Columns.AddRange(CODI_UBI, CODI_BARRA, ALMA, AREA, ANA, COLUM, FILA)
        End With
    End Sub

    Private Sub FrmUbicacion_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmUbicacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmUbicacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            FORMAT_GRILLA1()
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub
End Class