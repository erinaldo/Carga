Imports system.Data
Imports System.Data.OleDb
Imports AccesoDatos

Public Class FrmBusquedaFuncionariosPasajes
    Private rstFuncionarios As ADODB.Recordset
    Private MyDataAdapter As New OleDbDataAdapter
    Private dtFuncionarios As New DataTable
    Private dvFuncionario As New DataView
    Public NombreFuncionario As String
    Public CodigoFuncionario As Integer
    Public TipoFuncionario As Integer
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), ClientSize())
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#366AB3"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub FrmBusquedaFuncionariosPasajes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmBusquedaFuncionarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'datahelper
            'Dim Myobj As Object() = {"PKG_IVOPERSONA.SP_LISTAFUNCIONARIO_PASA", 0}
            'rstFuncionarios = VOCONTROLUSUARIO.fnSQLQuery(Myobj)
            'MyDataAdapter.Fill(dtFuncionarios, rstFuncionarios)
            'dvFuncionario = dtFuncionarios.DefaultView
            'Call CargarLista()

            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTAFUNCIONARIO_PASA", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_FUNCIONARIOS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            dtFuncionarios = db.EjecutarDataTable
            dvFuncionario = dtFuncionarios.DefaultView
            Call CargarLista()

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub CargarLista()
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
            .HeaderText = "ID"
            .Name = "ID"
            .DataPropertyName = "ID"
            .ReadOnly = True
            .ToolTipText = "Identificador del cliente en la Base de Datos"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        End With
        dgvFuncionarios.Columns.Add(col1)

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .HeaderText = "NOMBRE Y APELLIDOS"
            .Name = "FUNCIONARIO"
            .DataPropertyName = "NOMBRE_USUARIO"
            .ToolTipText = "Código del Cliente"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        dgvFuncionarios.Columns.Add(col2)

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .HeaderText = "ROLES"
            .Name = "IDROL"
            .DataPropertyName = "IDROL"
            .ReadOnly = True
            .ToolTipText = "Identificador del cliente en la Base de Datos"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        End With
        dgvFuncionarios.Columns.Add(col3)
        dgvFuncionarios.Columns(2).Visible = False

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.checked = True Then
            dvFuncionario.RowFilter = "IDROL = 11 AND NOMBRE_USUARIO LIKE '%" & txtNombreFuncionario.Text & "%'"
            txtNombreFuncionario.Focus()
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.checked = True Then
            dvFuncionario.RowFilter = "IDROL = 12 AND NOMBRE_USUARIO LIKE '%" & txtNombreFuncionario.Text & "%'"
            txtNombreFuncionario.Focus()
        End If
    End Sub

    Private Sub chkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.checked = True Then
            dvFuncionario.RowFilter = "(IDROL = 11 OR IDROL = 12) AND NOMBRE_USUARIO LIKE '%" & txtNombreFuncionario.Text & "%'"
            txtNombreFuncionario.Focus()
        End If
    End Sub

    'Private Sub txtNombreFuncionario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombreFuncionario.TextChanged
    '    If chkNegocio.Checked = True Then
    '        dvFuncionario.RowFilter = "IDROL = 11 AND NOMBRE_USUARIO LIKE '%" & txtNombreFuncionario.Text & "%'"
    '    End If
    '    If chkTeleventa.Checked = True Then
    '        dvFuncionario.RowFilter = "IDROL = 12 AND NOMBRE_USUARIO LIKE '%" & txtNombreFuncionario.Text & "%'"
    '    End If
    '    If chkTodos.Checked = True Then
    '        dvFuncionario.RowFilter = "(IDROL = 12 OR IDROL = 11) AND NOMBRE_USUARIO LIKE '%" & txtNombreFuncionario.Text & "%'"
    '    End If
    'End Sub

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
        If Not Me.dgvFuncionarios.CurrentRow() Is Nothing Then
            Dim dgvr As DataGridViewRow = Me.dgvFuncionarios.CurrentRow()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.NombreFuncionario = dgvr.Cells("FUNCIONARIO").Value.ToString()
            Me.CodigoFuncionario = CType(dgvr.Cells("ID").Value, Integer)
            Me.TipoFuncionario = CType(dgvr.Cells("IDROL").Value, Integer)
        Else
            MessageBox.Show("No hay ningun registro filtrado por seleccionar.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
End Class