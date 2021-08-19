Imports system.Data
Imports System.Data.OleDb
Imports AccesoDatos

Public Class FrmBusquedaClientes
    'Private rstFuncionarios As ADODB.Recordset
    'Private rstFuncionarios As DataTable
    Private MyDataAdapter As New OleDbDataAdapter
    Private dtFuncionarios As New DataTable
    Private dvFuncionario As New DataView
    Public NombreFuncionario As String
    Public CodigoFuncionario As String
    Public TipoFuncionario As Integer

    Public BuscaPor As Integer
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), ClientSize())
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#366AB3"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub FrmBusquedaClientes_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmBusquedaClientes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmBusquedaFuncionarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If CodigoFuncionario = "" Then
                CodigoFuncionario = "Ingrese un Valor..."
            End If
            If BuscaPor = 1 Then
                Me.chkRUC.Checked = True

                Dim db As New BaseDatos
                db.Conectar()
                db.CrearComando("PKG_IVOPERSONA.SP_BUSCA_CLIENTES", CommandType.StoredProcedure)
                db.AsignarParametro("iID_CODIGO_CLIENTE", CodigoFuncionario, OracleClient.OracleType.VarChar)
                db.AsignarParametro("OCURSOR_SALIDA", OracleClient.OracleType.Cursor)
                db.Desconectar()
                dtFuncionarios = db.EjecutarDataTable
                dvFuncionario = dtFuncionarios.DefaultView
                Call CargarLista()
                dvFuncionario.RowFilter = "CODIGO LIKE '" & CodigoFuncionario & "%'"

                'datahelper
                'Me.chkRUC.Checked = True
                'Dim Myobj As Object() = {"PKG_IVOPERSONA.SP_BUSCA_CLIENTES", 4, CodigoFuncionario, 2}
                'rstFuncionarios = VOCONTROLUSUARIO.fnSQLQuery(Myobj)
                'MyDataAdapter.Fill(dtFuncionarios, rstFuncionarios)
                'dvFuncionario = dtFuncionarios.DefaultView
                'Call CargarLista()
                'dvFuncionario.RowFilter = "CODIGO LIKE '" & CodigoFuncionario & "%'"
            ElseIf BuscaPor = 2 Then
                Me.chkNombre.Checked = True
                Dim db As New BaseDatos
                db.Conectar()
                db.CrearComando("PKG_IVOPERSONA.SP_BUSCA_CLIENTES_NOMBRE", CommandType.StoredProcedure)
                db.AsignarParametro("iID_CODIGO_CLIENTE", CodigoFuncionario, OracleClient.OracleType.VarChar)
                db.AsignarParametro("OCURSOR_SALIDA", OracleClient.OracleType.Cursor)
                db.Desconectar()
                dtFuncionarios = db.EjecutarDataTable
                dvFuncionario = dtFuncionarios.DefaultView
                Call CargarLista()
                dvFuncionario.RowFilter = "RAZON_SOCIAL LIKE '" & CodigoFuncionario & "%'"

                'datahelper
                'Me.chkNombre.Checked = True
                'Dim Myobj As Object() = {"PKG_IVOPERSONA.SP_BUSCA_CLIENTES_NOMBRE", 4, CodigoFuncionario, 2}
                'rstFuncionarios = VOCONTROLUSUARIO.fnSQLQuery(Myobj)
                'MyDataAdapter.Fill(dtFuncionarios, rstFuncionarios)
                'dvFuncionario = dtFuncionarios.DefaultView
                'Call CargarLista()
                'dvFuncionario.RowFilter = "RAZON_SOCIAL LIKE '" & CodigoFuncionario & "%'"
            End If
            Me.txtNombreFuncionario.Text = CodigoFuncionario

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me)
            bIngreso = True

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub CargarLista()
        Me.dgvFuncionarios.Columns.Clear()
        With Me.dgvFuncionarios
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .BackgroundColor = Color.White
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = dvFuncionario
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            .RowHeadersVisible = False
            .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .HeaderText = "CODIGO"
            .Name = "CODIGO"
            .DataPropertyName = "CODIGO"
            .ReadOnly = True
            .ToolTipText = "Codigo del Cliente"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            .Width = 90
        End With
        dgvFuncionarios.Columns.Add(col1)

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .HeaderText = "RAZON_SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .ToolTipText = "Razon Social del Cliente"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        dgvFuncionarios.Columns.Add(col2)

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRUC.CheckedChanged
        If sender.checked = True Then
            dvFuncionario.RowFilter = ""
            Me.txtNombreFuncionario.Text = ""
            txtNombreFuncionario.Focus()
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNombre.CheckedChanged
        If sender.checked = True Then
            dvFuncionario.RowFilter = ""
            Me.txtNombreFuncionario.Text = ""
            txtNombreFuncionario.Focus()
        End If
    End Sub

    Private Sub txtNombreFuncionario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombreFuncionario.TextChanged
        If chkRUC.Checked = True Then
            If txtNombreFuncionario.Text.Trim.Length = 0 Then
                dvFuncionario.RowFilter = ""
            Else
                dvFuncionario.RowFilter = "CODIGO LIKE '" & txtNombreFuncionario.Text & "%'"
            End If
        ElseIf chkNombre.Checked = True Then
            If txtNombreFuncionario.Text.Trim.Length = 0 Then
                dvFuncionario.RowFilter = ""
            Else
                dvFuncionario.RowFilter = "RAZON_SOCIAL LIKE '" & txtNombreFuncionario.Text & "%'"
            End If
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Escape) Then
            'SendKeys.Send("{Tab}")
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
            Return True
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If
        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            DevolucionFuncionario()
            Return True
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If
        'Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    'Private Sub dgvFuncionarios_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFuncionarios.CellClick
    'Para determinar los click por columna considerar el bucle If Then Else
    'If e.ColumnIndex = 0 Then
    'Dim dgvr As DataGridViewRow = Me.dgvFuncionarios.CurrentRow()
    'MessageBox.Show(dgvr.Cells("FUNCIONARIO").Value.ToString())
    'End If
    'End Sub

    Private Sub dgvFuncionarios_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFuncionarios.CellDoubleClick
        DevolucionFuncionario()
    End Sub

    Private Sub DevolucionFuncionario()
        If Me.chkRUC.Checked = True Then
            If Not Me.dgvFuncionarios.CurrentRow() Is Nothing Then
                Dim dgvr As DataGridViewRow = Me.dgvFuncionarios.CurrentRow()
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.NombreFuncionario = dgvr.Cells("RAZON_SOCIAL").Value.ToString()
                Me.CodigoFuncionario = CType(dgvr.Cells("CODIGO").Value, String)
            Else
                MessageBox.Show("No hay ningun registro filtrado por seleccionar.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        ElseIf Me.chkRUC.Checked = False Then
            If Not Me.dgvFuncionarios.CurrentRow() Is Nothing Then
                Dim dgvr As DataGridViewRow = Me.dgvFuncionarios.CurrentRow()
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.NombreFuncionario = dgvr.Cells("RAZON_SOCIAL").Value.ToString()
                Me.CodigoFuncionario = CType(dgvr.Cells("CODIGO").Value, String)
            Else
                MessageBox.Show("No hay ningun registro filtrado por seleccionar.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
        
    End Sub
End Class