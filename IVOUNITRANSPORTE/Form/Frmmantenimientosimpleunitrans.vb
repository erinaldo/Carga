'Imports System.Windows.Forms
'Imports System.Data
'Imports System.Data.OleDb
'Imports System.Drawing
Public Class Frmmantenimientosimpleunitrans
    Public Nuevostipounidadtransporte As New DataTable
    Public Nuevosmodelomovil As New DataTable
    Public Ingresado As Integer
    Dim vAccionRegistro As Integer
    Dim dvNuevotipounidadtransporte, dvNuevomodelotransporte As New DataView
    Dim dtNuevoRubro As New DataTable
    Dim dtunidad_transporte As New DataTable
    Dim dtmodelo_movil As New DataTable
    Dim dvmodelo_movil As New DataView
    Public hnd As Long

    Private Sub Frmmantenimientosimpleunitrans_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub Frmmantenimientosimpleunitrans_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    'Dim odda4 As New OleDbDataAdapter
    Private Sub Frmmantenimientosimple_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Modunitransporte.inumerocontrol = 0 Then
                Me.lblTitulo.Text = "Nuevo tipo unidad"
                If objbusqunidadtransporte.fn_LISTA_TIPOUNIDAD Then
                    'datahelper
                    'odda4.Fill(dtunidad_transporte, objbusqunidadtransporte.rst_lista_tipounidad)
                    dtunidad_transporte = objbusqunidadtransporte.rst_lista_tipounidad
                    dvNuevotipounidadtransporte = dtunidad_transporte.DefaultView
                    CargaTipoUnidadTransporte(dvNuevotipounidadtransporte)
                    vAccionRegistro = 1
                    LabMANTENIMIENTO.Text = "Tipo Unidad Transporte"
                End If
            ElseIf Modunitransporte.inumerocontrol = 1 Then
                Me.lblTitulo.Text = "Nuevo Modelo Unidad"
                If objbusqunidadtransporte.fn_LISTA_MODELO_MOVIL Then
                    'datahelper
                    'odda4.Fill(dtmodelo_movil, objbusqunidadtransporte.rst_lista_modelounidad)
                    dtmodelo_movil = objbusqunidadtransporte.rst_lista_modelounidad
                    dvmodelo_movil = dtmodelo_movil.DefaultView
                    Cargamodelomovil(dvmodelo_movil)
                    vAccionRegistro = 1
                    LabMANTENIMIENTO.Text = "Modelo Movil"
                End If
            End If

            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)

        Catch exp As Exception
            MessageBox.Show(exp.Message, "Seguridad del Sistema")
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
            Select Case Modunitransporte.inumerocontrol
                Case 0
                    If Len(Trim(txtMANTENIMIENTO.Text)) <> 0 Then
                        Dim Count As Integer = 0
                        For i As Integer = 0 To Lista.RowCount - 1
                            If Lista.Rows(i).Cells("TIPO_UNIDAD_TRANSPORTE").Value.ToString = txtMANTENIMIENTO.Text Then
                                Count += 1
                            End If
                        Next
                        'MessageBox.Show(Count)
                        If Count > 0 Then
                            MessageBox.Show("Ya existe el tipo de unidad de transporte : " & txtMANTENIMIENTO.Text, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            Call Nuevodatos()
                        End If
                    ElseIf Len(Trim(txtMANTENIMIENTO.Text)) = 0 Then
                        MessageBox.Show("Ingrese el Nombre del tipo de unidad del transporte ", "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    Return True
                    Return MyBase.ProcessCmdKey(msg, keyData)
                Case 1
                    If Len(Trim(txtMANTENIMIENTO.Text)) <> 0 Then
                        Dim Count As Integer = 0
                        For i As Integer = 0 To Lista.RowCount - 1
                            If Lista.Rows(i).Cells("MODELO_MOVIL").Value.ToString = txtMANTENIMIENTO.Text Then
                                Count += 1
                            End If
                        Next
                        'MessageBox.Show(Count)
                        If Count > 0 Then
                            MessageBox.Show("Ya existe el modelo de movil : " & txtMANTENIMIENTO.Text, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            Call Nuevodatos()
                        End If
                    ElseIf Len(Trim(txtMANTENIMIENTO.Text)) = 0 Then
                        MessageBox.Show("Ingrese el Nombre del modelo de movil  ", "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    Return True
                    Return MyBase.ProcessCmdKey(msg, keyData)
            End Select
        End If
    End Function
    Private Sub Nuevodatos()
        If vAccionRegistro = 1 Then
            'Dim rstRubro As ADODB.Recordset
            'Dim rstNuevaLista As ADODB.Recordset
            'Dim ObjUnd2 As Object() = {"PKG_IVOUNIDADTRANSPORTE.SP_INSUPD_tipo_uni_trans", 20, vAccionRegistro, 1, 1, 1, txtRubro.Text, 2}
            Select Case Modunitransporte.inumerocontrol
                Case 0
                    objbusqunidadtransporte.control = vAccionRegistro
                    objbusqunidadtransporte.IDTIPOUNIDAD_TRANSPORTE = -666
                    objbusqunidadtransporte.TIPO_UNIDAD_TRANSPORTE = txtMANTENIMIENTO.Text
                    ' txtRubro.Text
                    If objbusqunidadtransporte.fn_INSUPD_tipo_uni_trans Then
                        'datahelper
                        'odda4.Fill(dtunidad_transporte, objbusqunidadtransporte.rst_lista_tipounidad)
                        dtunidad_transporte = objbusqunidadtransporte.rst_lista_tipounidad
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Nuevostipounidadtransporte = dtunidad_transporte.Copy
                        dvNuevotipounidadtransporte = dtunidad_transporte.DefaultView
                        vAccionRegistro = 1
                        Lista.Columns.Clear()
                        CargaTipoUnidadTransporte(dvNuevotipounidadtransporte)
                        For i As Integer = 0 To Lista.RowCount - 1
                            If Lista.Rows(i).Cells("TIPO_UNIDAD_TRANSPORTE").Value.ToString = txtMANTENIMIENTO.Text Then
                                Me.Ingresado = CType(Lista.Rows(i).Cells("IDTIPO_UNIDAD_TRANSPORTE").Value, Integer)
                            End If
                        Next
                    End If
                Case 1
                    objbusqunidadtransporte.control = vAccionRegistro
                    objbusqunidadtransporte.IDMODELO_MOVIL = -666
                    objbusqunidadtransporte.MODELO_MOVIL = txtMANTENIMIENTO.Text
                    objbusqunidadtransporte.IDROL_USUARIO = dtoUSUARIOS.IdRol
                    objbusqunidadtransporte.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                    objbusqunidadtransporte.IDESTADO_REGISTRO = 1  'Estado registro 

                    If objbusqunidadtransporte.fn_INSUPD_modelo_movil Then
                        'datahelper
                        'odda4.Fill(dtmodelo_movil, objbusqunidadtransporte.rst_lista_modelounidad)
                        dtmodelo_movil = objbusqunidadtransporte.rst_lista_modelounidad
                        '
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Nuevosmodelomovil = dtmodelo_movil.Copy
                        dvmodelo_movil = dtmodelo_movil.DefaultView
                        vAccionRegistro = 1
                        Lista.Columns.Clear()
                        Cargamodelomovil(dvmodelo_movil)
                        For i As Integer = 0 To Lista.RowCount - 1
                            If Lista.Rows(i).Cells("MODELO_MOVIL").Value.ToString = txtMANTENIMIENTO.Text Then
                                'MessageBox.Show(Lista.Rows(i).Cells("IDRUBRO").Value.ToString)
                                Me.Ingresado = CType(Lista.Rows(i).Cells("IDMODELO_MOVIL").Value, Integer)
                            End If
                        Next
                    End If
            End Select
        End If
    End Sub
    Private Sub CargaTipoUnidadTransporte(ByVal MyDataView As DataView)
        With Lista
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            .DataSource = MyDataView
            .RowHeadersVisible = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .Name = "IDTIPO_UNIDAD_TRANSPORTE"
            .HeaderText = "Id. "
            .DataPropertyName = "IDTIPO_UNIDAD_TRANSPORTE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With
        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .Name = "TIPO_UNIDAD_TRANSPORTE"
            .HeaderText = "Unidad transporte"
            .DataPropertyName = "TIPO_UNIDAD_TRANSPORTE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Lista.Columns.AddRange(col0, col1)
    End Sub
    Private Sub Cargamodelomovil(ByVal MyDataView As DataView)
        With Lista
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            .DataSource = MyDataView
            .RowHeadersVisible = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .Name = "IDMODELO_MOVIL"
            .HeaderText = "Id. "
            .DataPropertyName = "IDMODELO_MOVIL"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With
        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .Name = "MODELO_MOVIL"
            .HeaderText = "Modelo"
            .DataPropertyName = "MODELO_MOVIL"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Lista.Columns.AddRange(col0, col1)
    End Sub
    Private Sub txtMANTENIMIENTO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMANTENIMIENTO.TextChanged
        Select Case Modunitransporte.inumerocontrol
            Case 0
                If Len(Trim(txtMANTENIMIENTO.Text)) > 0 Then
                    dvNuevotipounidadtransporte.RowFilter = "TIPO_UNIDAD_TRANSPORTE LIKE '%" & txtMANTENIMIENTO.Text & "%'"
                ElseIf Len(Trim(txtMANTENIMIENTO.Text)) = 0 Then
                    dvNuevotipounidadtransporte.RowFilter = ""
                End If
            Case 1
                If Len(Trim(txtMANTENIMIENTO.Text)) > 0 Then
                    dvNuevomodelotransporte.RowFilter = "MODELO_MOVIL LIKE '%" & txtMANTENIMIENTO.Text & "%'"
                ElseIf Len(Trim(txtMANTENIMIENTO.Text)) = 0 Then
                    dvNuevomodelotransporte.RowFilter = ""
                End If
        End Select
    End Sub
End Class
