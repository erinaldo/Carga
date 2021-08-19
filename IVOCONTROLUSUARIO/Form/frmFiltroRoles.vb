'Imports AccesoDatos
Public Class frmFiltroRoles
    'Dim darol As New OleDb.OleDbDataAdapter
    Dim dtrol As New System.Data.DataTable
    Dim dvrol As System.Data.DataView
    Dim tControl As Boolean
    Dim bIngreso As Boolean = False
    Public usuario As Integer
    Public hnd As Long

    Private Sub frmFiltroRoles_Aceptar() Handles Me.Aceptar
        Try
            Dim i As Integer
            Dim ax As Object
            Dim col As New DataGridViewCheckBoxColumn
            'Dim dtoRoles As New dtoCONTROLUSUARIOS()
            ListRoles = Nothing
            ListRoles = New Collection()
            For i = 0 To DataGridViewFiltro.RowCount - 1
                If DataGridViewFiltro.Rows(i).DataGridView(0, i).Value = True Then
                    ax = DataGridViewFiltro.Rows(i).DataGridView(0, i).Value
                    Dim dtoRoles As New dtoCONTROLUSUARIOS()
                    dtoRoles.IdRol = Int(DataGridViewFiltro.Rows(i).DataGridView(1, i).Value.ToString)
                    dtoRoles.Rol = DataGridViewFiltro.Rows(i).DataGridView(2, i).Value.ToString
                    ListRoles.Add(dtoRoles)

                End If
            Next i
            Close()
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub frmFiltroRoles_Cancelar() Handles Me.Cancelar
        Try
            ListRoles = Nothing
            ListRoles = New Collection()
            Close()
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub frmFiltroRoles_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frmFiltroRoles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ShadowLabel1.Text = "Filtro Roles"
            'Dim db As New BaseDatos
            'db.Conectar()
            'db.CrearComando("PKG_IVOCONTROLUSUARIO.SP_LISTA_ROL_USUARIO", CommandType.StoredProcedure)
            'db.AsignarParametro("icontrol", 1, OracleClient.OracleType.Int32)
            'db.AsignarParametro("cur_control", OracleClient.OracleType.Cursor)
            'db.Desconectar()
            Dim obj As New dtoCONTROLUSUARIOS
            'dtrol = obj.LISTA_ROL_USUARIO(1)
            dtrol = obj.LISTA_ROL_USUARIO(usuario, 1)
            Dim col As New DataGridViewCheckBoxColumn
            With col
                .HeaderText = "ESTADO"
                .ThreeState = False
                .DataPropertyName = "ESTADO"
                .FlatStyle = FlatStyle.Standard
                .CellTemplate = New DataGridViewCheckBoxCell
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            DataGridViewFiltro.Columns.Add(col)
            Dim coltex As New DataGridViewTextBoxColumn
            With coltex
                .HeaderText = "ROL"
                .DataPropertyName = "Rol_Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .ReadOnly = True
            End With
            DataGridViewFiltro.AllowUserToAddRows = False
            DataGridViewFiltro.Columns.Add(coltex)
            DataGridViewFiltro.Columns(1).ReadOnly = True
            'dtrol = db.EjecutarDataTable
            'darol.Fill(dtrol, rst)
            DataGridViewFiltro.DataSource = dtrol.DefaultView
            DataGridViewFiltro.Columns(1).Visible = False
            DataGridViewFiltro.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        'datahelper
        'ShadowLabel1.Text = "Filtro Roles"
        'Dim varSP_OBJECT As Object() = {"PKG_IVOCONTROLUSUARIO.SP_LISTA_ROL_USUARIO", 4, 1, 1}
        'rst = Nothing
        'rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        'Dim col As New DataGridViewCheckBoxColumn
        'With col
        '    .HeaderText = "Estado"
        '    .ThreeState = False
        '    .DataPropertyName = "ESTADO"
        '    .FlatStyle = FlatStyle.Standard
        '    .CellTemplate = New DataGridViewCheckBoxCell
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'End With
        'DataGridViewFiltro.Columns.Add(col)
        'Dim coltex As New DataGridViewTextBoxColumn
        'With coltex
        '    .HeaderText = "Estado"
        '    .DataPropertyName = "Rol_Usuario"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'End With
        'DataGridViewFiltro.Columns.Add(coltex)
        'DataGridViewFiltro.Columns(1).ReadOnly = True
        'darol.Fill(dtrol, rst)
        'DataGridViewFiltro.DataSource = dtrol.DefaultView
        'DataGridViewFiltro.Columns(1).Visible = False
        'DataGridViewFiltro.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    End Sub
End Class

