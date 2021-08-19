Public Class FrmSubCuenta_Cliente

    Public NuevosRubros As New DataTable
    Public Ingresado As Integer
    Dim vAccionRegistro As Integer
    Dim dvNuevoRubros As New DataView
    Dim dtNuevoRubro As New DataTable
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub FrmSubCuenta_Cliente_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmClasificacion_Cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.lblTitulo.Text = "Nueva Sub Cuenta"
            'datahelper
            'Dim rstRubro As ADODB.Recordset
            'Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_LISTA_SUB_CUENTA", 0}
            'rstRubro = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
            'Dim da As New OleDbDataAdapter
            'Dim dtRubro As New DataTable
            'da.Fill(dtRubro, rstRubro)
            Dim obj As New dtoCliente_Subcuenta
            Dim dtRubro = obj.LISTA_SUB_CUENTA()
            dvNuevoRubros = dtRubro.DefaultView
            CargaRubros(dvNuevoRubros)
            vAccionRegistro = 1

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                    If Lista.Rows(i).Cells("CENTRO_COSTO").Value.ToString = txtRubro.Text Then
                        Count += 1
                    End If
                Next
                'MessageBox.Show(Count)
                If Count > 0 Then
                    MessageBox.Show("Ya existe una Sub Cuenta : " & txtRubro.Text, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Call NuevosRubrosEmpresariales()
                End If
            ElseIf Len(Trim(txtRubro.Text)) = 0 Then
                MessageBox.Show("Ingrese el Nombre de la Nueva Sub Cuenta.", "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Return True
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If

    End Function

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
            .Name = "IDCENTRO_COSTO"
            .HeaderText = "ID_SUB_CUENTA"
            .DataPropertyName = "IDCENTRO_COSTO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With
        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .Name = "CENTRO_COSTO"
            .HeaderText = "SUB_CUENTA"
            .DataPropertyName = "CENTRO_COSTO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Lista.Columns.AddRange(col0, col1)
    End Sub

    Private Sub txtRubro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRubro.TextChanged
        If Len(Trim(txtRubro.Text)) > 0 Then
            dvNuevoRubros.RowFilter = "CENTRO_COSTO LIKE '%" & txtRubro.Text & "%'"
        ElseIf Len(Trim(txtRubro.Text)) = 0 Then
            dvNuevoRubros.RowFilter = ""
        End If
    End Sub

    Private Sub NuevosRubrosEmpresariales2009_eliminarlo()
        'If vAccionRegistro = 1 Then
        '    Dim rstRubro As ADODB.Recordset
        '    Dim rstNuevaLista As ADODB.Recordset
        '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_INSUPD_SUBCUENTA", 8, vAccionRegistro, 1, txtRubro.Text, 2}
        '    rstRubro = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
        '    rstNuevaLista = rstRubro.NextRecordset
        '    Dim da As New OleDbDataAdapter

        '    da.Fill(dtNuevoRubro, rstNuevaLista)
        '    Me.DialogResult = Windows.Forms.DialogResult.OK
        '    Me.NuevosRubros = dtNuevoRubro.Copy
        '    dvNuevoRubros = dtNuevoRubro.DefaultView
        '    Lista.Columns.Clear()
        '    CargaRubros(dvNuevoRubros)
        '    For i As Integer = 0 To Lista.RowCount - 1
        '        If Lista.Rows(i).Cells("CENTRO_COSTO").Value.ToString = txtRubro.Text Then
        '            'MessageBox.Show(Lista.Rows(i).Cells("IDCENTRO_COSTO").Value.ToString)
        '            Me.Ingresado = CType(Lista.Rows(i).Cells("IDCENTRO_COSTO").Value, Integer)
        '        End If
        '    Next
        'End If
    End Sub

    Private Sub NuevosRubrosEmpresariales()
        Try
            If vAccionRegistro = 1 Then
                Dim obj As New dtoCliente_Subcuenta
                Dim ds As DataSet = obj.INSUPD_SUBCUENTA(vAccionRegistro, txtRubro.Text)
                dtNuevoRubro = ds.Tables(1)

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.NuevosRubros = dtNuevoRubro.Copy
                dvNuevoRubros = dtNuevoRubro.DefaultView
                Lista.Columns.Clear()
                CargaRubros(dvNuevoRubros)
                For i As Integer = 0 To Lista.RowCount - 1
                    If Lista.Rows(i).Cells("CENTRO_COSTO").Value.ToString = txtRubro.Text Then
                        Me.Ingresado = CType(Lista.Rows(i).Cells("IDCENTRO_COSTO").Value, Integer)
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
