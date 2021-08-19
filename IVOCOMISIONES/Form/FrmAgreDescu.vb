Public Class FrmAgreDescu
    Dim ObjValida As New ClsLbTepsa.dtoValida
    Dim bIngreso As Boolean = False
    Public hnd As Long
    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Not ObjValida.NO_BLANCO(TxtOtrosDescu, Me) Then Exit Sub
        If Not ObjValida.NUMERO_NO_CERO(TxtMontoOtrosDescu, Me) Then Exit Sub
        If Not ObjValida.NUMERO_NO_NEGATIVO(TxtMontoOtrosDescu, Me) Then Exit Sub

        Dim MyDataRowTotal As DataRow
        MyDataRowTotal = Dt_Otros_Gastos.NewRow
        MyDataRowTotal("fecha") = Me.dtpFecha.Value.ToShortDateString
        MyDataRowTotal("concep") = Me.TxtOtrosDescu.Text.ToString.ToUpper
        MyDataRowTotal("valor") = CType(Me.TxtMontoOtrosDescu.Text, Double)
        Dt_Otros_Gastos.Rows.Add(MyDataRowTotal)
        Me.TxtOtrosDescu.Text = ""
        Me.TxtMontoOtrosDescu.Text = ""
        TxtOtrosDescu.Focus()
        format1()
    End Sub

    Private Sub FrmAgreDescu_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmAgreDescu_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmAgreDescu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            format1()
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dt_Otros_Gastos.Rows.Remove(Dt_Otros_Gastos.Rows(dgv1.CurrentRow.Index))
        Catch
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Close()
    End Sub

    Private Sub BCance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCance.Click
        Dt_Otros_Gastos.Clear()
    End Sub
    Private Sub format1()
        dgv1.Columns.Clear()

        With dgv1
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = Dt_Otros_Gastos
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim concep As New DataGridViewTextBoxColumn
        With concep
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "Concepto"
            .Name = "concep"
            .DataPropertyName = "concep"
            .Width = 250
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FECHA As New DataGridViewTextBoxColumn
        With FECHA
            .HeaderText = "FECHA"
            .Name = "FECHA"
            .DataPropertyName = "FECHA"
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim valor As New DataGridViewTextBoxColumn
        With valor
            .HeaderText = "Monto"
            .Name = "valor"
            .DataPropertyName = "valor"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        With dgv1
            .Columns.AddRange(FECHA, concep, valor)
        End With
    End Sub

End Class