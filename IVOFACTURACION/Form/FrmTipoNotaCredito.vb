'Imports System.Data
'Imports System.Data.OleDb
'Imports AccesoDatos

Public Class FrmTipoNotaCredito

    Public NuevosRubros As New DataTable
    Public Ingresado As Integer
    Dim vAccionRegistro As Integer
    Dim dvNuevoTIPO_NOTA_CREDI As New DataView
    Dim dtNuevoTIPO_NOTA_CREDI As New DataTable
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub FrmTipoNotaCredito_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmTipoNotaCredito_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmClasificacion_Cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Dim db As New BaseDatos
            'db.Conectar()
            'db.CrearComando("PKG_IVOGENERAL.SP_LISTA_TIPO_NORA_CREDI", CommandType.StoredProcedure)
            'db.AsignarParametro("CUR_LISTA_TIPO_NORA_CREDI", OracleClient.OracleType.Cursor)
            'db.Desconectar()
            Dim obj As New dtorefacturacion
            dvNuevoTIPO_NOTA_CREDI = obj.LISTA_TIPO_NORA_CREDI()
            CargaRubros(dvNuevoTIPO_NOTA_CREDI)
            vAccionRegistro = 1

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        'datahelper
        'Me.lblTitulo.Text = "Nueva tipo nota crédito"
        'Dim rstTIPO_NOTA_CREDITO As ADODB.Recordset
        'Dim ObjUnd2 As Object() = {"PKG_IVOGENERAL.SP_LISTA_TIPO_NORA_CREDI", 0}
        'rstTIPO_NOTA_CREDITO = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
        'Dim da As New OleDbDataAdapter
        'Dim dtRubro As New DataTable
        'da.Fill(dtRubro, rstTIPO_NOTA_CREDITO)
        'dvNuevoTIPO_NOTA_CREDI = dtRubro.DefaultView
        'CargaRubros(dvNuevoTIPO_NOTA_CREDI)
        'vAccionRegistro = 1
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
                    If Lista.Rows(i).Cells("TIPO_NOTA_CREDI").Value.ToString = txtRubro.Text Then
                        Count += 1
                    End If
                Next
                'MessageBox.Show(Count)
                If Count > 0 Then
                    MessageBox.Show("Ya existe un tipo de nota de crédito: " & txtRubro.Text, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Call NuevosRubrosEmpresariales()
                End If
            ElseIf Len(Trim(txtRubro.Text)) = 0 Then
                MessageBox.Show("Ingrese el Nombre de la Nueva nota de crédito", "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Return True
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If

    End Function

    Private Sub NuevosRubrosEmpresariales()
        Try
            If vAccionRegistro = 1 Then
                'Dim db As New BaseDatos
                'db.Conectar()
                'db.CrearComando("PKG_IVOREFACTURACION.SP_INSUPD_TIPO_NOTA_CREDI", CommandType.StoredProcedure)
                'db.AsignarParametro("iCONTROL", vAccionRegistro, OracleClient.OracleType.Int32)
                'db.AsignarParametro("iTIPO_NOTA_CREDI", txtRubro.Text, OracleClient.OracleType.VarChar)
                'db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
                'db.AsignarParametro("oCUR_LISTA", OracleClient.OracleType.Cursor)
                'db.Desconectar()
                Dim obj As New dtorefacturacion
                Dim ds As DataSet = obj.INSUPD_TIPO_NOTA_CREDI(vAccionRegistro, txtRubro.Text)
                Dim rstRubro As DataTable = ds.Tables(0)
                Dim rstNuevaLista As DataTable = ds.Tables(1)
                Me.DialogResult = Windows.Forms.DialogResult.OK

                dtNuevoTIPO_NOTA_CREDI = rstNuevaLista
                Me.NuevosRubros = dtNuevoTIPO_NOTA_CREDI.Copy
                dvNuevoTIPO_NOTA_CREDI = dtNuevoTIPO_NOTA_CREDI.DefaultView
                Lista.Columns.Clear()
                CargaRubros(dvNuevoTIPO_NOTA_CREDI)
                For i As Integer = 0 To Lista.RowCount - 1
                    If Lista.Rows(i).Cells("TIPO_NOTA_CREDI").Value.ToString = txtRubro.Text Then
                        Me.Ingresado = CType(Lista.Rows(i).Cells("IDTIPO_NOTA_CREDI").Value, Integer)
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        'datahelper
        'If vAccionRegistro = 1 Then
        '    Dim rstRubro As ADODB.Recordset
        '    Dim rstNuevaLista As ADODB.Recordset
        '    Dim ObjUnd2 As Object() = {"PKG_IVOREFACTURACION.SP_INSUPD_TIPO_NOTA_CREDI", 8, vAccionRegistro, 1, txtRubro.Text, 2}
        '    rstRubro = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
        '    rstNuevaLista = rstRubro.NextRecordset
        '    Dim da As New OleDbDataAdapter

        '    da.Fill(dtNuevoTIPO_NOTA_CREDI, rstNuevaLista)
        '    Me.DialogResult = Windows.Forms.DialogResult.OK
        '    Me.NuevosRubros = dtNuevoTIPO_NOTA_CREDI.Copy
        '    dvNuevoTIPO_NOTA_CREDI = dtNuevoTIPO_NOTA_CREDI.DefaultView
        '    Lista.Columns.Clear()
        '    CargaRubros(dvNuevoTIPO_NOTA_CREDI)
        '    For i As Integer = 0 To Lista.RowCount - 1
        '        If Lista.Rows(i).Cells("TIPO_NOTA_CREDI").Value.ToString = txtRubro.Text Then
        '            'MessageBox.Show(Lista.Rows(i).Cells("IDCENTRO_COSTO").Value.ToString)
        '            Me.Ingresado = CType(Lista.Rows(i).Cells("IDTIPO_NOTA_CREDI").Value, Integer)
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
            .Name = "IDTIPO_NOTA_CREDI"
            .HeaderText = "IDTIPO_NOTA_CREDI"
            .DataPropertyName = "IDTIPO_NOTA_CREDI"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With
        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .Name = "TIPO_NOTA_CREDI"
            .HeaderText = "TIPO_NOTA_CREDI"
            .DataPropertyName = "TIPO_NOTA_CREDI"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Lista.Columns.AddRange(col0, col1)
    End Sub

    Private Sub txtRubro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRubro.TextChanged
        If Len(Trim(txtRubro.Text)) > 0 Then
            dvNuevoTIPO_NOTA_CREDI.RowFilter = "TIPO_NOTA_CREDI LIKE '%" & txtRubro.Text & "%'"
        ElseIf Len(Trim(txtRubro.Text)) = 0 Then
            dvNuevoTIPO_NOTA_CREDI.RowFilter = ""
        End If
    End Sub

    Private Sub lblTitulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTitulo.Click

    End Sub
End Class
