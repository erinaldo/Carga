'Imports System.Data
'Imports System.Data.OleDb
'Imports AccesoDatos

Public Class FrmTipoContacto_Cliente

    Public NuevosRubros As New DataTable
    Public Ingresado As Integer
    Dim vAccionRegistro As Integer
    Dim dvNuevoRubros As New DataView
    Dim dtNuevoRubro As New DataTable
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub FrmTipoContacto_Cliente_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmClasificacion_Cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.lblTitulo.Text = "Nuevo Cargo Contacto"
            'datahelper
            'Dim rstRubro As ADODB.Recordset
            'Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_LISTA_TIPO_CONTACTO", 0}
            'rstRubro = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
            'Dim da As New OleDbDataAdapter
            'Dim dtRubro As New DataTable
            'da.Fill(dtRubro, rstRubro)
            Dim obj As New dtoCONTACTO_CLIENTE
            Dim dtrubro As DataTable = obj.LISTA_TIPO_CONTACTO()
            dvNuevoRubros = dtrubro.DefaultView
            CargaRubros(dvNuevoRubros)
            vAccionRegistro = 1

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                    If Lista.Rows(i).Cells("TIPO_CONTACTO").Value.ToString = txtRubro.Text Then
                        Count += 1
                    End If
                Next
                'MessageBox.Show(Count)
                If Count > 0 Then
                    MessageBox.Show("Ya existe un Cargo con ese Nombre : " & txtRubro.Text, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Call NuevosRubrosEmpresariales()
                End If
            ElseIf Len(Trim(txtRubro.Text)) = 0 Then
                MessageBox.Show("Ingrese el Nombre del Cargo del Contacto.", "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Return True
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If

    End Function

    Private Sub NuevosRubrosEmpresariales2009()
        'If vAccionRegistro = 1 Then
        '    Dim rstRubro As ADODB.Recordset
        '    Dim rstNuevaLista As ADODB.Recordset
        '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_INSUPD_CARGO_CONTACTO", 8, vAccionRegistro, 1, txtRubro.Text, 2}
        '    rstRubro = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
        '    rstNuevaLista = rstRubro.NextRecordset
        '    'Dim da As New OleDbDataAdapter

        '    da.Fill(dtNuevoRubro, rstNuevaLista)
        '    Me.DialogResult = Windows.Forms.DialogResult.OK
        '    Me.NuevosRubros = dtNuevoRubro.Copy
        '    dvNuevoRubros = dtNuevoRubro.DefaultView
        '    Lista.Columns.Clear()
        '    CargaRubros(dvNuevoRubros)
        '    For i As Integer = 0 To Lista.RowCount - 1
        '        If Lista.Rows(i).Cells("TIPO_CONTACTO").Value.ToString = txtRubro.Text Then
        '            MessageBox.Show(Lista.Rows(i).Cells("IDTIPO_CONTACTO").Value.ToString)
        '            Me.Ingresado = CType(Lista.Rows(i).Cells("IDTIPO_CONTACTO").Value, Integer)
        '        End If
        '    Next
        'End If

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
            .Name = "IDTIPO_CONTACTO"
            .HeaderText = "ID_TIPO_CONTACTO"
            .DataPropertyName = "IDTIPO_CONTACTO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With
        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .Name = "TIPO_CONTACTO"
            .HeaderText = "TIPO_CONTACTO"
            .DataPropertyName = "TIPO_CONTACTO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Lista.Columns.AddRange(col0, col1)
    End Sub

    Private Sub txtRubro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRubro.TextChanged
        If Len(Trim(txtRubro.Text)) > 0 Then
            dvNuevoRubros.RowFilter = "TIPO_CONTACTO LIKE '%" & txtRubro.Text & "%'"
        ElseIf Len(Trim(txtRubro.Text)) = 0 Then
            dvNuevoRubros.RowFilter = ""
        End If
    End Sub

    Private Sub NuevosRubrosEmpresariales()
        Try
            If vAccionRegistro = 1 Then
                'Dim rstRubro As ADODB.Recordset
                'Dim rstNuevaLista As ADODB.Recordset
                'Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_INSUPD_CARGO_CONTACTO", 8, vAccionRegistro, 1, txtRubro.Text, 2}
                'rstRubro = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
                'rstNuevaLista = rstRubro.NextRecordset
                'Dim da As New OleDbDataAdapter

                'da.Fill(dtNuevoRubro, rstNuevaLista)
                Dim obj As New dtoCONTACTO_CLIENTE
                Dim ds As DataSet = obj.INSUPD_CARGO_CONTACTO(vAccionRegistro, txtRubro.Text)
                dtNuevoRubro = ds.Tables(1)

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.NuevosRubros = dtNuevoRubro.Copy
                dvNuevoRubros = dtNuevoRubro.DefaultView
                Lista.Columns.Clear()
                CargaRubros(dvNuevoRubros)
                For i As Integer = 0 To Lista.RowCount - 1
                    If Lista.Rows(i).Cells("TIPO_CONTACTO").Value.ToString = txtRubro.Text Then
                        MessageBox.Show(Lista.Rows(i).Cells("IDTIPO_CONTACTO").Value.ToString)
                        Me.Ingresado = CType(Lista.Rows(i).Cells("IDTIPO_CONTACTO").Value, Integer)
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class
