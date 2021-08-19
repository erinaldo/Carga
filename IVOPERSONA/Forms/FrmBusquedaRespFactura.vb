Imports System.Data
Imports System.Data.OleDb
Imports AccesoDatos

Public Class FrmBusquedaRespFactura

    'Private rstRespFactura As ADODB.Recordset
    Private rstRespFactura As DataTable
    Private MyDataAdapter As New OleDbDataAdapter
    Private dtRespFactura As New DataTable
    Private dvRespFactura As New DataView
    Public NombreRespFactura As String

    Private Sub FrmBusquedaRespFactura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'datahelper
            'Dim Myobj As Object() = {"PKG_IVOPERSONA.SP_LISTARESPFACTURA", 0}
            'rstRespFactura = VOCONTROLUSUARIO.fnSQLQuery(Myobj)
            'MyDataAdapter.Fill(dtRespFactura, rstRespFactura)
            'dvRespFactura = dtRespFactura.DefaultView
            'Me.lblTitulo.Text = "Busqueda de Responsables de Facturación"
            'Call CargarLista()
            'dvRespFactura.RowFilter = "NOMBRE_USUARIO LIKE '%" & txtNombreRespfactura.Text & "%'"

            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTARESPFACTURA", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_RESPFACTURA", OracleClient.OracleType.Cursor)
            db.Desconectar()
            rstRespFactura = db.EjecutarDataTable()
            dvRespFactura = rstRespFactura.DefaultView
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            Call DevolucionFuncionario()
            Return True
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If
        'Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Public Sub CargarLista()
        With Me.dgvRespFactura
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .BackgroundColor = Color.White
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = dvRespFactura
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
        dgvRespFactura.Columns.Add(col1)

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .HeaderText = "NOMBRE Y APELLIDOS"
            .Name = "FUNCIONARIO"
            .DataPropertyName = "NOMBRE_USUARIO"
            .ToolTipText = "Código del Cliente"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        dgvRespFactura.Columns.Add(col2)

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .HeaderText = "ROLES"
            .Name = "IDROL"
            .DataPropertyName = "IDROL"
            .ReadOnly = True
            .ToolTipText = "Identificador del cliente en la Base de Datos"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        End With
        'dgvFuncionarios.Columns.Add(col3)

    End Sub

    Private Sub txtNombreRespfactura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombreRespfactura.TextChanged
        dvRespFactura.RowFilter = "NOMBRE_USUARIO LIKE '%" & txtNombreRespfactura.Text & "%'"
    End Sub

    Private Sub DevolucionFuncionario()
        If Not Me.dgvRespFactura.CurrentRow() Is Nothing Then
            Dim dgvr As DataGridViewRow = Me.dgvRespFactura.CurrentRow()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.NombreRespFactura = dgvr.Cells("FUNCIONARIO").Value.ToString()
        Else
            MessageBox.Show("No hay ningun registro filtrado por seleccionar.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub dgvRespFactura_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRespFactura.CellDoubleClick
        Call DevolucionFuncionario()
    End Sub


End Class
