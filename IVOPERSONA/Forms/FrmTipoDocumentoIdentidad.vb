'Imports System.Data.OleDb
Imports AccesoDatos

Public Class FrmTipoDocumentoIdentidad

    Public NuevosRubros As New DataTable
    Public Ingresado As Integer
    Dim vAccionRegistro As Integer
    Dim dvNuevoRubros As New DataView
    Dim dtNuevoRubro As New DataTable
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub FrmTipoDocumentoIdentidad_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmTipoDocumentoIdentidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.lblTitulo.Text = "Tipo Documento Identidad"
            'datahelper
            'Dim rstRubro As ADODB.Recordset
            'Dim rstTipoPersona As ADODB.Recordset
            'Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_LISTA_TIPO_DOCUMENTO", 0}
            'rstRubro = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
            'rstTipoPersona = rstRubro.NextRecordset
            'Dim da As New OleDbDataAdapter
            'Dim dtRubro As New DataTable
            'Dim dtTipoPersona As New DataTable
            'da.Fill(dtRubro, rstRubro)
            'da.Fill(dtTipoPersona, rstTipoPersona)
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_TIPO_DOCUMENTO", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_TIPO_DOCUMENTO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_TIPO_PERSONA", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Dim dtRubro As DataTable = ds.Tables(0)
            Dim dtTipoPersona As DataTable = ds.Tables(1)

            cmbTipoPersona.DataSource = dtTipoPersona.DefaultView
            cmbTipoPersona.DisplayMember = "TIPO_PERSONA"
            cmbTipoPersona.ValueMember = "IDTIPO_PERSONA"

            dvNuevoRubros = dtRubro.DefaultView
            CargaRubros(dvNuevoRubros)
            vAccionRegistro = 1

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Excepcion
            MessageBox.Show(ex.Excepcion, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Escape) Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
            Return True
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If

        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            If Len(Trim(txtRubro.Text)) <> 0 Then
                Dim Count As Integer = 0
                For i As Integer = 0 To Lista.RowCount - 1
                    If Lista.Rows(i).Cells("TIPO_DOC_IDENTIDAD").Value.ToString = txtRubro.Text Then
                        Count += 1
                    End If
                Next
                'MessageBox.Show(Count)
                If Count > 0 Then
                    MessageBox.Show("Ya existe un tipo de Documento con este Nombre : " & txtRubro.Text, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Call NuevosRubrosEmpresariales()
                End If
            ElseIf Len(Trim(txtRubro.Text)) = 0 Then
                MessageBox.Show("Ingrese el Nombre del tipo de Documento.", "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Return True
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If

    End Function

    Private Sub NuevosRubrosEmpresariales()
        Try
            If vAccionRegistro = 1 Then
                'datahelper
                'Dim rstRubro As ADODB.Recordset
                'Dim rstNuevaLista As ADODB.Recordset
                'Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_INSUPD_TIPO_DOCUMENTO", 15, vAccionRegistro, 1, txtRubro.Text, 2, MyUsuario, 1, MyRol, 1, MyIP, 2, cmbTipoPersona.SelectedValue, 1}
                'rstRubro = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
                'rstNuevaLista = rstRubro.NextRecordset
                'Dim da As New OleDbDataAdapter

                'da.Fill(dtNuevoRubro, rstNuevaLista)
                Dim db As New BaseDatos
                db.Conectar()
                db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_TIPO_DOCUMENTO", CommandType.StoredProcedure)
                db.AsignarParametro("iCONTROL", vAccionRegistro, OracleClient.OracleType.Int32)
                db.AsignarParametro("iNOMBRE_DOCUMENTO", txtRubro.Text, OracleClient.OracleType.VarChar)
                db.AsignarParametro("iIDUSUARIO_PERSONAL", MyUsuario, OracleClient.OracleType.Int32)
                db.AsignarParametro("iIDROL_USUARIO", MyRol, OracleClient.OracleType.Int32)
                db.AsignarParametro("iIP", MyIP, OracleClient.OracleType.VarChar)
                db.AsignarParametro("iIDTIPO_PERSONA", cmbTipoPersona.SelectedValue, OracleClient.OracleType.Int32)
                db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
                db.AsignarParametro("oCUR_LISTA", OracleClient.OracleType.Cursor)
                db.Desconectar()
                Dim ds As DataSet = db.EjecutarDataSet
                dtNuevoRubro = ds.Tables(1)

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.NuevosRubros = dtNuevoRubro.Copy
                dvNuevoRubros = dtNuevoRubro.DefaultView
                Lista.Columns.Clear()
                CargaRubros(dvNuevoRubros)
                For i As Integer = 0 To Lista.RowCount - 1
                    If Lista.Rows(i).Cells("TIPO_DOC_IDENTIDAD").Value.ToString = txtRubro.Text Then
                        MessageBox.Show(Lista.Rows(i).Cells("IDTIPO_DOC_IDENTIDAD").Value.ToString)
                        Me.Ingresado = CType(Lista.Rows(i).Cells("IDTIPO_DOC_IDENTIDAD").Value, Integer)
                    End If
                Next
            End If
        Catch ex As Excepcion
            MessageBox.Show(ex.Excepcion, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub CargaRubros(ByVal MyDataView As DataView)
        With Lista
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = MyDataView
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            .RowHeadersVisible = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .Name = "IDTIPO_DOC_IDENTIDAD"
            .HeaderText = "ID_DOCUMENTO"
            .DataPropertyName = "IDTIPO_DOC_IDENTIDAD"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With
        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .Name = "TIPO_DOC_IDENTIDAD"
            .HeaderText = "DOCUMENTO"
            .DataPropertyName = "TIPO_DOC_IDENTIDAD"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Lista.Columns.AddRange(col0, col1)
    End Sub

    Private Sub txtRubro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRubro.TextChanged
        If Len(Trim(txtRubro.Text)) > 0 Then
            dvNuevoRubros.RowFilter = "TIPO_DOC_IDENTIDAD LIKE '%" & txtRubro.Text & "%'"
        ElseIf Len(Trim(txtRubro.Text)) = 0 Then
            dvNuevoRubros.RowFilter = ""
        End If
    End Sub

End Class
