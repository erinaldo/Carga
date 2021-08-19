Public Class frmrecuperaguias_transportista
#Region "Variables publicas"
    Public dt_gt As New DataTable
    Public ls_idguia_transportista As String
    Public lb_cancela As Boolean = False
    Public hnd As Long
#End Region
#Region "Variables"
    Dim dv_gt1 As New DataView
    Dim bIngreso As Boolean = False
#End Region
#Region "Adicional"
    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize)
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If
    End Function
#End Region
#Region "Eventos"

    Private Sub frmrecuperaguias_transportista_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frmrecuperaguias_transportista_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frmrecuperaguias_transportista_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            dv_gt1 = dt_gt.DefaultView
            fnload_grilla()
            DGV_GT.DataSource = dv_gt1

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

#End Region
    Sub fnload_grilla()
        Try
            DGV_GT.Columns.Clear()
            With DGV_GT
                .AllowUserToAddRows = False
                '.AllowUserToDeleteRows = False
                '.AllowUserToOrderColumns = True
                .AutoGenerateColumns = False
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = False
                '    '.DataSource = dtable_Lista_Control_Comprobante
                '    .VirtualMode = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            '
            Dim documento As New DataGridViewTextBoxColumn
            With documento '0
                .DisplayIndex = 0
                .DataPropertyName = "documento"
                .Name = "documento"
                .HeaderText = "Guia Transportista"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_GT.Columns.Add(documento)
            '
            Dim fecha_salida As New DataGridViewTextBoxColumn
            With fecha_salida '1
                .DisplayIndex = 1
                .DataPropertyName = "fecha_salida"
                .Name = "fecha_salida"
                .HeaderText = "Fecha salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_GT.Columns.Add(fecha_salida)
            '
            Dim hora_salida As New DataGridViewTextBoxColumn
            With hora_salida  '2
                .DisplayIndex = 2
                .DataPropertyName = "hora_salida"
                .Name = "hora_salida"
                .HeaderText = "Hora salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_GT.Columns.Add(hora_salida)
            '
            Dim ciudad_origen As New DataGridViewTextBoxColumn
            With ciudad_origen ' 3
                .DisplayIndex = 3
                .DataPropertyName = "ciudad_origen"
                .Name = "ciudad_origen"
                .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DGV_GT.Columns.Add(ciudad_origen)
            '
            Dim agencia_origen As New DataGridViewTextBoxColumn
            With agencia_origen ' 4
                .DisplayIndex = 4
                .DataPropertyName = "agencia_origen"
                .Name = "agencia_origen"
                .HeaderText = "Ag. Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = False
                .Visible = True
                .MaxInputLength = 12
            End With
            DGV_GT.Columns.Add(agencia_origen)
            '
            Dim idguia_transportista As New DataGridViewTextBoxColumn
            With idguia_transportista ' 5
                .DisplayIndex = 5
                .DataPropertyName = "idguia_transportista"
                .Name = "idguia_transportista"
                .HeaderText = "Id guia transportista"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            DGV_GT.Columns.Add(idguia_transportista)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub DGV_GT_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGV_GT.DoubleClick
        Dim dgrv0 As DataGridViewRow
        '
        Try
            If Me.DGV_GT.Rows.Count < 1 Then
                MsgBox("No se encontro ningún registro", MsgBoxStyle.Information, "Bajar bultos")
                Exit Sub
            End If
            '
            dgrv0 = Me.DGV_GT.CurrentRow()
            ls_idguia_transportista = CType(dgrv0.Cells("documento").Value, String)
            lb_cancela = False
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        lb_cancela = True
        Me.Close()
    End Sub
End Class