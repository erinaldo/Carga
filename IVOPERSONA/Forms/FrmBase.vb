Imports AccesoDatos
Public Class FrmBase
    Public sDocumento As String
    Public sCliente As String
    Public iId As String
    Public bMontoBase As Boolean
    Dim iMontoBase As Integer
    Dim bIngreso As Boolean = False
    Public hnd As Long

#Region "Adicionales"
    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize)
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
#End Region

    Private Sub FrmBase_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            txtDocumento.Text = sDocumento
            txtCliente.Text = sCliente
            chkMontoBase.Checked = bMontoBase

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click
        Me.Close()
    End Sub

    Private Sub btnSi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSi.Click
        Dim iResp As Integer

        iResp = MessageBox.Show("¿Está Seguro de Realizar la Actualización?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If iResp = vbYes Then
            iMontoBase = IIf(chkMontoBase.Checked, 1, 0)
            'datahelper
            'Dim rst As ADODB.Recordset
            'rst = sp_upd_monto_base()
            Dim rst As DataTable
            rst = sp_upd_monto_base()

            'datahelper
            'If rst(0).Value = 0 Then
            If rst.Rows(0).Item(0) = 0 Then
                MessageBox.Show("Se Realizó la Actualización", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Dim frm As New FrmClientes
                Close()
                frm.bActualizado = True
            End If
        End If
    End Sub
    'Public Function sp_upd_monto_base2009() As ADODB.Recordset
    '    Try
    '        Dim Obj As Object() = {"sp_upd_monto_base", 6, iId, 2, iMontoBase, 1}
    '        Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
    '        Return Nothing
    '    End Try
    'End Function
    Public Function sp_upd_monto_base() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("sp_upd_monto_base", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idpersona", iId, OracleClient.OracleType.VarChar)
            db.AsignarParametro("base", iMontoBase, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
            Return Nothing
        End Try
    End Function

End Class