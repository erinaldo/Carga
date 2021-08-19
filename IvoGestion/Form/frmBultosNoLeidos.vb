Public Class frmBultosNoLeidos
    Dim cur As New ADODB.Recordset
    Public iTipo As Integer
    Public sDocumento As String
    Public sDoc As String
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub frmBultosNoLeidos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frmBultosNoLeidos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frmBultosNoLeidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim lobj_gestion_carga As New ClsLbTepsa.dto_gestion_carga
            Dim ldt_tmp As New DataTable
            '
            Me.Text = sDoc
            '
            lobj_gestion_carga.idtipo_comprobante = iTipo
            lobj_gestion_carga.idcomprobante = CType(sDocumento, Int32)

            ldt_tmp = lobj_gestion_carga.sf_bultos_no_leidos()

            'Dim varSP_OBJECT() As Object = {"SP_BULTOS_NO_LEIDOS", 6, iTipo, 1, sDocumento, 2}
            'cur = Nothing
            'cur = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

            'DgvDetalle.Rows.Clear()
            'Do While cur.EOF = False And cur.BOF = False
            '    DgvDetalle.Rows.Add(1)
            '    DgvDetalle.Rows(DgvDetalle.Rows.Count - 1).Cells(0).Value = cur(0).Value
            '    DgvDetalle.Rows(DgvDetalle.Rows.Count - 1).Cells(1).Value = cur(1).Value
            '    cur.MoveNext()
            'Loop
            For Each fila As DataRow In ldt_tmp.Rows
                DgvDetalle.Rows.Add(1)
                DgvDetalle.Rows(DgvDetalle.Rows.Count - 1).Cells(0).Value = fila.Item(0)
                DgvDetalle.Rows(DgvDetalle.Rows.Count - 1).Cells(1).Value = fila.Item(1)
            Next

            DgvDetalle.Columns(0).Visible = False

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmBultosNoLeidos_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize)
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))

    End Sub
    Private Sub btnAceptar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Close()
    End Sub
End Class