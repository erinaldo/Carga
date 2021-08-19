'Imports System
'Imports System.Windows.Forms
'Imports System.Text.RegularExpressions
'Imports System.Data
'Imports System.Data.OleDb
'Imports System.Drawing
'Imports System.IO
'Imports ADOSERVERLib
Public Class frmrutasrecojoentrega
#Region "1 Variables y constantes"
    ' Generales  
    Dim MyClassruta As New dtoruta
    ' Cabecera 
    Dim myclaseruta As New dtoruta
    'datahelper
    'Dim rstruta, rstdepartamento, rstprovincia, rstdistrito, rsttiporecojo As New ADODB.Recordset
    Dim rstruta, rstdepartamento, rstprovincia, rstdistrito, rsttiporecojo As DataTable
    Dim dtruta, dtdepartamento, dtprovincia, dtdistrito, dttiporecojo As New DataTable
    Dim dvruta, dvdepartamento, dvprovincia, dvdistrito, dvtiporecojo As New DataView
    'Dim odda4 As New OleDb.OleDbDataAdapter
    Dim control_cab As Integer
    Dim idruta As Integer
    Dim bIngreso As Boolean
    Public hnd As Long
#End Region
#Region "2 Eventos"

    Private Sub frmrutasrecojoentrega_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frmrutasrecojoentrega_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frmrutas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            ' Seteando los botones 
            ToolStripMenuItem2.Visible = False
            ToolStripMenuItem3.Visible = False
            ToolStripMenuItem4.Visible = False
            ToolStripMenuItem5.Visible = False
            ToolStripMenuItem6.Visible = False
            ' 
            CancelarToolStripMenuItem.Enabled = False
            CancelarToolStripMenuItem.Visible = False
            '
            MenuTab.Items(0).Enabled = True
            ' 
            ShadowLabel1.Text = "Ruta"
            MenuTab.Items(0).Text = "Ruta"
            MenuTab.Items(1).Visible = True
            MenuTab.Items(1).Text = "Mantenimiento Ruta"
            MenuTab.Items(1).Enabled = False
            '
            ' Llenando las rutas del país 
            myclaseruta.idusuario = dtoUSUARIOS.IdLogin

            Dim ds As DataSet = myclaseruta.getiniciorutas()
            rstruta = ds.Tables(0)
            rstdepartamento = ds.Tables(1)
            rstprovincia = ds.Tables(2)
            rstdistrito = ds.Tables(3)
            rsttiporecojo = ds.Tables(4)

            dttiporecojo = rsttiporecojo
            dvtiporecojo = CargarCombo(cmboperacion, dttiporecojo, "operacion_carga", "idoperacion_carga", 2)
            '
            dtruta = rstruta
            dvruta = dtruta.DefaultView
            dvruta.AllowNew = True 'Averigua - 
            ' 
            dtdepartamento = rstdepartamento
            dvdepartamento = CargarCombo(cmbdepartamento, dtdepartamento, "departamento", "iddepartamento", 15) ' Por defecto el 15 dpto Lima
            ModSolRecojoCarga.idpais = CType(dtdepartamento.Rows(0).Item(2), Integer)  ' Recuperando el codigo del pais 
            '
            dtprovincia = rstprovincia
            dvprovincia = dtprovincia.DefaultView
            dvprovincia.AllowNew = True
            dvprovincia.RowFilter = "idpais = " & ModSolRecojoCarga.idpais & " and iddepartamento = 15"
            '
            dtdistrito = rstdistrito
            dvdistrito = dtdistrito.DefaultView
            dvdistrito.AllowNew = True

            ' Llenar los Departamentos   
            ModuUtil.LlenarTreeCtrl(rstdepartamento, Me.TreeLista, "departamento")
            Me.TreeLista.ExpandAll()
            grilla_ruta()

            'datahelper
            'rstruta = myclaseruta.getiniciorutas()
            'rstdepartamento = rstruta.NextRecordset
            'rstprovincia = rstruta.NextRecordset
            'rstdistrito = rstruta.NextRecordset()
            'rsttiporecojo = rstruta.NextRecordset()

            'odda4.Fill(dttiporecojo, rsttiporecojo)
            'dvtiporecojo = CargarCombo(cmboperacion, dttiporecojo, "operacion_carga", "idoperacion_carga", 2)
            ''
            'odda4.Fill(dtruta, rstruta)
            'dvruta = dtruta.DefaultView
            'dvruta.AllowNew = True 'Averigua - 
            '' 
            'odda4.Fill(dtdepartamento, rstdepartamento)
            'dvdepartamento = CargarCombo(cmbdepartamento, dtdepartamento, "departamento", "iddepartamento", 15) ' Por defecto el 15 dpto Lima
            'ModSolRecojoCarga.idpais = CType(dtdepartamento.Rows(0).Item(2), Integer)  ' Recuperando el codigo del pais 
            ''
            'odda4.Fill(dtprovincia, rstprovincia)
            'dvprovincia = dtprovincia.DefaultView
            'dvprovincia.AllowNew = True
            'dvprovincia.RowFilter = "idpais = " & ModSolRecojoCarga.idpais & " and iddepartamento = 15"
            ''
            'odda4.Fill(dtdistrito, rstdistrito)
            'dvdistrito = dtdistrito.DefaultView
            'dvdistrito.AllowNew = True

            '' Llenar los Departamentos   
            'rstdepartamento.MoveFirst()
            'ModuUtil.LlenarTreeCtrl(rstdepartamento, Me.TreeLista, "departamento")
            'Me.TreeLista.ExpandAll()
            'grilla_ruta()

            bIngreso = False
            Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub frmrutas_MenuCancelar() Handles Me.MenuCancelar
        SplitContainer2.Panel1Collapsed = False
    End Sub
    Private Sub frmrutas_MenuEditar() Handles Me.MenuEditar
        Dim dgvr As New DataGridViewRow
        Dim lb_regresa As Boolean = False
        ' No debe hacer nada 
        If DataGridViewPlt.Rows.Count < 1 Then
            Return
        End If
        ' Edicion  
        control_cab = 0
        MenuTab.Items(0).Enabled = False
        MenuTab.Items(1).Enabled = True
        MenuTab.Items(2).Enabled = True
        MenuTab.Items(3).Enabled = True
        MenuTab.Items(4).Enabled = True
        dgvr = DataGridViewPlt.CurrentRow
        idruta = dgvr.Cells(0).Value
        obteniendo_detalle()
    End Sub
    Private Sub frmrutas_MenuGrabar() Handles Me.MenuGrabar
        Try
            Dim MyObligatorios() As Object = {Me.txtruta}   ' Código para revisar         
            'datahelper
            'Dim rsmensaje, rsdatos As New ADODB.Recordset
            Dim rsmensaje, rsdatos As DataTable
            Dim idruta_entrega_recojo As Integer
            ''''''''''''''''''''''
            ' Grabar validar 
            ''''''''''''''''''''''    
            If dgvdetalle.Rows.Count < 1 Then
                MessageBox.Show("Falta ingresar el detalle de ruta", "Mantenimiento ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvdetalle.Focus()
                Return
            End If
            If ModuUtilom.Validaciones(MyObligatorios) = 0 Then 'Si todo esta bien... (funcion comun x Richard)
                MyClassruta.control = control_cab
                If IsDBNull(txtidruta.Text) Or txtidruta.Text = Nothing Or txtidruta.Text = "" Then
                    MyClassruta.idruta_entrega_recojo = -666
                Else
                    MyClassruta.idruta_entrega_recojo = txtidruta.Text
                End If
                MyClassruta.idoperacion_carga = CType(cmboperacion.SelectedValue, Integer)
                MyClassruta.nombre_ruta_entrega_recojo = txtruta.Text
                'Recuperando los valores de los combos 
                MyClassruta.departamento = CType(cmbdepartamento.SelectedValue, Integer)
                MyClassruta.pais = CType(txtidpais.Text, Integer)
                ' Propio del sistema 
                MyClassruta.usuario_personal = dtoUSUARIOS.IdLogin
                MyClassruta.rol_usuario = dtoUSUARIOS.IdRol
                MyClassruta.ip = dtoUSUARIOS.IP
                MyClassruta.estado_registro = 1 'Por ahora estara activo omendoza --> Proceso 
                ' 
                Dim respOracle As DataTable
                Dim ds As DataSet = MyClassruta.actualizacabecera
                rsmensaje = ds.Tables(0)
                rsdatos = ds.Tables(1)
                respOracle = ds.Tables(2)
                Try
                    If respOracle.Rows.Count > 0 Then
                        ' Recupera el id de la ruta 
                        If rsdatos.Rows.Count > 0 Then
                            idruta_entrega_recojo = rsdatos.Rows(0).Item(0)
                            txtidruta.Text = idruta_entrega_recojo
                        End If
                        If control_cab = 1 Then
                            Dim dtrow As DataRow
                            dtrow = dtruta.NewRow
                            dtrow("idruta_entrega_recojo") = CType(txtidruta.Text, Integer)
                            dtrow("nombre_ruta_entrega_recojo") = CType(txtruta.Text, String)
                            dtrow("operacion_carga") = CType(cmboperacion.Text, String)
                            dtrow("idpais") = CType(txtidpais.Text, Integer)
                            dtrow("iddepartamento") = CType(cmbdepartamento.SelectedValue, Integer)
                            dtruta.Rows.Add(dtrow)
                        End If
                        If Not Grabar_detalle() Then Return ' Si falta o existe un error no graba el detalle 
                    Else
                        If IsDBNull(respOracle.Rows(0).Item(0)) = False Then
                            MessageBox.Show("Descripción: " & CType(respOracle.Rows(0).Item(1), String), "ORACLE -> Error: " & CType(respOracle.Rows(0).Item(0), String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                Catch Qex As Exception
                    MessageBox.Show(Qex.Message, "Seguridad del Sistema")
                End Try

                'datahelper
                'Dim respOracle As ADODB.Recordset
                'rsmensaje = MyClassruta.actualizacabecera
                'rsdatos = rsmensaje.NextRecordset()
                'respOracle = rsmensaje.NextRecordset()
                'Try
                '    If respOracle.Fields.Count = 0 Then
                '        ' Recupera el id de la ruta 
                '        If rsdatos.Fields.Count > 0 Then
                '            idruta_entrega_recojo = rsdatos.Fields(0).Value
                '            txtidruta.Text = idruta_entrega_recojo
                '        End If
                '        If control_cab = 1 Then
                '            Dim dtrow As DataRow
                '            dtrow = dtruta.NewRow
                '            dtrow("idruta_entrega_recojo") = CType(txtidruta.Text, Integer)
                '            dtrow("nombre_ruta_entrega_recojo") = CType(txtruta.Text, String)
                '            dtrow("operacion_carga") = CType(cmboperacion.Text, String)
                '            dtrow("idpais") = CType(txtidpais.Text, Integer)
                '            dtrow("iddepartamento") = CType(cmbdepartamento.SelectedValue, Integer)
                '            dtruta.Rows.Add(dtrow)
                '        End If
                '        If Not Grabar_detalle() Then Return ' Si falta o existe un error no graba el detalle 
                '    Else
                '        If CType(respOracle.Fields(0).Value, Integer) <> 0 Then
                '            MessageBox.Show("Descripción: " & CType(respOracle.Fields(1).Value, String), "ORACLE -> Error: " & CType(respOracle.Fields(0).Value, String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                '        End If
                '    End If
                'Catch Qex As Exception
                '    MessageBox.Show(Qex.Message, "Seguridad del Sistema")
                'End Try
            End If
            EdicionToolStripMenuItem.Enabled = False
            CancelarToolStripMenuItem.Enabled = False
            CancelarToolStripMenuItem.Visible = False
            GrabarToolStripMenuItem.Enabled = False
            SplitContainer2.Panel1Collapsed = False
            SelectMenu(0)
            limpiar_mantdatos()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub frmrutas_MenuNuevo() Handles Me.MenuNuevo
        Try
            'Limpiando datos 
            limpiar_mantdatos()
            ' Inserta 
            control_cab = 1
            Me.SelectMenu(1)
            MenuTab.Items(0).Enabled = False
            MenuTab.Items(1).Enabled = True
            MenuTab.Items(2).Enabled = True
            MenuTab.Items(3).Enabled = True
            MenuTab.Items(4).Enabled = True
            ' Grilla detalle de acuerdo al departamento 
            cmbdepartamento.Enabled = True
            idruta = Nothing
            txtidpais.Text = ModSolRecojoCarga.idpais
            obteniendo_detalle()
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub cmbdepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdepartamento.SelectedIndexChanged
        Dim posicion As Integer
        Dim idpais, iddepartamento As Integer
        Dim drvdepartamento As DataRowView
        'Declarando Data row View 
        posicion = cmbdepartamento.SelectedIndex()
        If posicion >= 0 And dvdepartamento.Count > 0 Then
            drvdepartamento = dvdepartamento.Item(posicion)
            iddepartamento = IIf(IsDBNull(drvdepartamento("iddepartamento")) = True, "0", drvdepartamento("iddepartamento").ToString)
            cmbdepartamento.EndUpdate()
            ' 
            idpais = CType(txtidpais.Text, Integer)
            dvprovincia.RowFilter = "idpais = " & idpais & " and iddepartamento = " + Trim(iddepartamento)
        End If
    End Sub
    Private Sub TreeLista_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeLista.AfterSelect
        Dim iddepartamento As Integer
        Dim nivel As Integer
        nivel = e.Node().Level
        Select Case nivel
            Case 0  'Invocando a todas las agencias 
                dvruta.RowFilter = ""

            Case 1  'Selecciona la agencia que se encuentra ubicada 
                ModSolRecojoCarga.idpais = CType(dtdepartamento.Rows(0).Item(2), Integer)
                iddepartamento = e.Node().Tag   ' Valor primario  
                dvruta.RowFilter = "idpais = " & ModSolRecojoCarga.idpais & " and iddepartamento = " & iddepartamento
        End Select
        'TreeLista.BeginUpdate()
        'ActualizarCheck(e.Node, e.Node.Checked)
        'TreeLista.EndUpdate()
    End Sub
    Private Sub dgvdetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvdetalle.CellEndEdit
        'Select Case e.ColumnIndex
        '    Case 0
        '        dgvdetalle.Rows(e.RowIndex).Cells(1).Value
        'End Select

        'Dim idprovincia As Integer
        'Dim iddepartamento As Integer
        'Dim idpais As Integer
        'Select Case e.ColumnIndex
        '    Case 0
        '        dgvdetalle.EndEdit()
        '        'Recupera Departamento 
        '        idpais = CType(txtidpais.Text, Integer)
        '        iddepartamento = CType(cmbdepartamento.SelectedValue, Integer)
        '        'Recuperando Provincia 
        '        idprovincia = CType(dgvdetalle.Rows(e.RowIndex).Cells(0).Value, Integer)
        '        dvdistrito.RowFilter = "idpais = " & idpais & " and iddepartamento = " & iddepartamento & _
        '                               " and  idprovincia = " & idprovincia

        'End Select
    End Sub
    Private Sub dgvdetalle_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvdetalle.CellBeginEdit
        Dim idprovincia As Integer
        Dim iddepartamento As Integer
        Dim idpais As Integer
        Select Case e.ColumnIndex
            Case 2
                dgvdetalle.EndEdit()
                If IsDBNull(dgvdetalle.Rows(e.RowIndex).Cells(1).Value) = True Then
                    'Validando la provincia que halla ingresado 
                    MessageBox.Show("Falta ingresar la provincia", "Mantenimiento ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dgvdetalle.CurrentCell = dgvdetalle.Rows(e.RowIndex).Cells(1)
                    Return
                End If
                'Recupera Departamento 
                idpais = CType(txtidpais.Text, Integer)
                iddepartamento = CType(cmbdepartamento.SelectedValue, Integer)
                'Recuperando Provincia 
                idprovincia = CType(dgvdetalle.Rows(e.RowIndex).Cells(1).Value, Integer)
                dvdistrito.RowFilter = "idpais = " & idpais & " and iddepartamento = " & iddepartamento & _
                                       " and  idprovincia = " & idprovincia
        End Select
    End Sub
#End Region
#Region "3 Funciones y procedimientos "
    Private Sub grilla_ruta()
        'Configurando la grilla, sin asociarle un dataview  - Omendoza 
        'DataGridViewPlt.Columns.Clear()
        With DataGridViewPlt
            .AutoGenerateColumns = False
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .BackgroundColor = Color.White
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False  'Para que no incremente la fila
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            .RowHeadersVisible = False
            .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DataSource = dvruta
        End With
        '
        Dim idruta_entrega_recojo As New DataGridViewTextBoxColumn
        With idruta_entrega_recojo '0
            .DefaultCellStyle.BackColor = SystemColors.Info
            .DataPropertyName = "idruta_entrega_recojo"
            .Name = "idruta_entrega_recojo"
            .HeaderText = "Id."
            .ReadOnly = True
        End With
        DataGridViewPlt.Columns.Add(idruta_entrega_recojo)
        '
        Dim nombre_ruta_entrega_recojo As New DataGridViewTextBoxColumn
        With nombre_ruta_entrega_recojo '1
            .DataPropertyName = "nombre_ruta_entrega_recojo"
            .Name = "nombre_ruta_entrega_recojo"
            .HeaderText = "Ruta"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        DataGridViewPlt.Columns.Add(nombre_ruta_entrega_recojo)
        '
        Dim operacion_carga As New DataGridViewTextBoxColumn
        With operacion_carga   '2
            .DataPropertyName = "operacion_carga"
            .Name = "operacion_carga"
            .HeaderText = "Operación"
            .DefaultCellStyle.BackColor = SystemColors.Info
        End With
        DataGridViewPlt.Columns.Add(operacion_carga)
        ' 
        Dim iddepartamentocells As New DataGridViewTextBoxColumn
        With iddepartamentocells     '  3
            .DataPropertyName = "iddepartamento"
            .Name = "iddepartamento"
            .HeaderText = "Departamento"
            .DefaultCellStyle.BackColor = SystemColors.Info
            .Visible = False
        End With
        DataGridViewPlt.Columns.Add(iddepartamentocells)
        '
        Dim idpaiscells As New DataGridViewTextBoxColumn
        With idpaiscells   '4 
            .DataPropertyName = "idpais"
            .Name = "idpais"
            .HeaderText = "idpais"
            .DefaultCellStyle.BackColor = SystemColors.Info
            .Visible = False
        End With
        DataGridViewPlt.Columns.Add(idpaiscells)
    End Sub
    Private Sub grilla_detalle(ByVal ldvruta_deta As DataView)
        dgvdetalle.Columns.Clear()
        With dgvdetalle
            .AutoGenerateColumns = False
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .BackgroundColor = Color.White
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = True
            .AllowUserToAddRows = True   'Para que no incremente la fila
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            .RowHeadersVisible = False
            .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '
            .DataSource = ldvruta_deta
        End With
        '
        Dim idruta_entrega_recojo_det As New DataGridViewTextBoxColumn
        With idruta_entrega_recojo_det '0
            .Visible = False
            .DefaultCellStyle.BackColor = SystemColors.Info
            .DataPropertyName = "idruta_entrega_recojo_det"
            .Name = "idruta_entrega_recojo_det"
            .HeaderText = "Id."
            .ReadOnly = True
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        dgvdetalle.Columns.Add(idruta_entrega_recojo_det)
        '
        Dim idprovincia As New DataGridViewComboBoxColumn
        With idprovincia   '1
            .DataPropertyName = "idprovincia"
            .DataSource = dvprovincia
            .DisplayMember = "provincia"
            .ValueMember = "idprovincia"
            .HeaderText = "Provincia"
            ' .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        End With
        dgvdetalle.Columns.Add(idprovincia)
        '
        Dim iddistrito As New DataGridViewComboBoxColumn
        With iddistrito   '2  
            .DataPropertyName = "iddistrito"
            .DataSource = dvdistrito
            .DisplayMember = "dsitrito"
            .ValueMember = "iddistrito"
            .HeaderText = "Distrito"
            .Name = "iddistrito"
        End With
        dgvdetalle.Columns.Add(iddistrito)
    End Sub
    Private Sub obteniendo_detalle()
        Try
            ' Detalle
            'datahelper
            'Dim rstruta1, rstrutadet As New ADODB.Recordset
            Dim rstruta1, rstrutadet As DataTable
            Dim dtruta1, dtrutadet As New DataTable
            Dim dvruta1, dvrutadet As New DataView
            Dim traedatos As Boolean
            ' Recupera el detalle   
            If IsDBNull(idruta) = True Or idruta < 1 Then
                myclaseruta.idruta_entrega_recojo = -666 ' Recupera una fila nueva
                traedatos = False
            Else
                myclaseruta.idruta_entrega_recojo = idruta
                traedatos = True
            End If

            Dim ds As DataSet = myclaseruta.getrutasdetalle()
            rstruta1 = ds.Tables(0)
            dtruta1 = rstruta1
            dvruta1 = dtruta1.DefaultView
            '
            rstrutadet = ds.Tables(1)
            dtrutadet = rstrutadet
            dvrutadet = dtrutadet.DefaultView
            ' Recupera el detalle de la ruta de acuerdo a las caracteristicas  
            If traedatos Then
                txtidruta.Text = dtruta1.Rows(0).Item(0)
                cmboperacion.SelectedValue = dtruta1.Rows(0).Item(1)
                txtruta.Text = dtruta1.Rows(0).Item(2)
                txtidpais.Text = dtruta1.Rows(0).Item(4)
                cmbdepartamento.SelectedValue = dtruta1.Rows(0).Item(3)
                cmbdepartamento.Enabled = False
            End If
            grilla_detalle(dvrutadet)

            'datahelper
            'rstruta1 = myclaseruta.getrutasdetalle()
            'odda4.Fill(dtruta1, rstruta1)
            'dvruta1 = dtruta1.DefaultView
            ''
            'rstrutadet = rstruta1.NextRecordset()
            'odda4.Fill(dtrutadet, rstrutadet)
            'dvrutadet = dtrutadet.DefaultView
            '' Recupera el detalle de la ruta de acuerdo a las caracteristicas  
            'If traedatos Then
            '    txtidruta.Text = dtruta1.Rows(0).Item(0)
            '    cmboperacion.SelectedValue = dtruta1.Rows(0).Item(1)
            '    txtruta.Text = dtruta1.Rows(0).Item(2)
            '    txtidpais.Text = dtruta1.Rows(0).Item(4)
            '    cmbdepartamento.SelectedValue = dtruta1.Rows(0).Item(3)
            '    cmbdepartamento.Enabled = False
            'End If
            'grilla_detalle(dvrutadet)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Function Grabar_detalle() As Boolean
        Try
            Dim fila As Integer
            'datahelper
            'Dim rsmensaje, rsdatos, respOracle As New ADODB.Recordset
            Dim rsmensaje, rsdatos, respOracle As DataTable
            Dim myclaserutadet As New dtorutadet
            Dim dgvr As New DataGridViewRow
            Dim dtdatos As New DataTable
            Dim cmbdistrito As New DataGridViewComboBoxCell
            Dim distrito As New Integer
            '
            If Not validardatosrepetidos() Then Return validardatosrepetidos()
            '
            myclaserutadet.usuario_personal = dtoUSUARIOS.IdLogin
            myclaserutadet.rol_usuario = dtoUSUARIOS.IdRol
            myclaserutadet.ip = dtoUSUARIOS.IP
            myclaserutadet.estado_registro = 1 'Por ahora estara activo omendoza --> Proceso         
            ' Recuperando los datos de la cabecera 
            myclaserutadet.departamento = cmbdepartamento.SelectedValue
            myclaserutadet.pais = CType(txtidpais.Text, Integer)
            myclaserutadet.idruta_entrega_recojo = CType(txtidruta.Text, Integer)
            '
            dgvr = dgvdetalle.CurrentRow ' Recuperando la fila 
            If dgvdetalle.Rows(dgvr.Index).Cells(2).Selected = True Then  ' Verifica el distrito ha ingresado             
                dgvdetalle.EndEdit()
            End If
            '
            'idruta_entrega_recojo_det  - mendozita 

            For fila = 0 To dgvdetalle.Rows.Count - 1
                If IsDBNull(dgvdetalle.Rows(fila).Cells(0).Value) = True Then
                    myclaserutadet.control = 1
                    myclaserutadet.idruta_entrega_recojo_det = -666
                Else
                    myclaserutadet.control = 0
                    myclaserutadet.idruta_entrega_recojo_det = CType(dgvdetalle.Rows(fila).Cells(0).Value, Integer)
                End If
                If IsDBNull(dgvdetalle.Rows(fila).Cells(1).Value) = True Then ' Validando que ingrese la provincia 
                    MessageBox.Show("Falta ingresar la provincia", "Mantenimiento ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dgvdetalle.CurrentCell = dgvdetalle.Rows(fila).Cells(1)
                    Return False
                End If
                myclaserutadet.provincia = CType(dgvdetalle.Rows(fila).Cells(1).Value, Integer)
                '
                '   lidistrito = dgvdetalle.Rows(fila).Cells(2).Value
                If IsDBNull(dgvdetalle.Rows(fila).Cells(2).Value) = True Then ' Validando que ingrese el distrito                
                    MessageBox.Show("Falta ingresar el distrito", "Mantenimiento ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dgvdetalle.CurrentCell = dgvdetalle.Rows(fila).Cells(2)
                    Return False
                End If
                myclaserutadet.distrito = CType(dgvdetalle.Rows(fila).Cells(2).Value, Integer)
                ' Traendo los datos de la cabecera 
                myclaserutadet.idruta_entrega_recojo = CType(txtidruta.Text, Integer)

                Dim ds As DataSet = myclaserutadet.actualizadetalle
                rsmensaje = ds.Tables(0)
                rsdatos = ds.Tables(1)
                dtdatos = rsdatos
                respOracle = ds.Tables(2)
                Try
                    If respOracle.Rows.Count = 0 Then
                        If dtdatos.Rows.Count > 0 Then
                            If IsDBNull(dtdatos.Rows(0).Item(0)) = False Then
                                dgvdetalle.Rows(fila).Cells(0).Value = CType(dtdatos.Rows(0).Item(0), Integer)
                            End If
                        End If
                    Else
                        If IsDBNull(respOracle.Rows(0).Item(0)) = False Then
                            MessageBox.Show("Descripción: " & CType(respOracle.Rows(0).Item(1), String), "ORACLE -> Error: " & CType(respOracle.Rows(0).Item(0), String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return False
                        End If
                    End If
                Catch Qex As Exception
                    MessageBox.Show(Qex.Message, "Seguridad del Sistema")
                    Return False
                End Try

                'datahelper
                'rsmensaje = myclaserutadet.actualizadetalle
                'rsdatos = rsmensaje.NextRecordset()
                'odda4.Fill(dtdatos, rsdatos)
                'respOracle = rsmensaje.NextRecordset()
                'Try
                '    If respOracle.Fields.Count = 0 Then
                '        If dtdatos.Rows.Count > 0 Then
                '            If IsDBNull(dtdatos.Rows(0).Item(0)) = False Then
                '                dgvdetalle.Rows(fila).Cells(0).Value = CType(dtdatos.Rows(0).Item(0), Integer)
                '            End If
                '        End If
                '    Else
                '        If CType(respOracle.Fields(0).Value, Integer) <> 0 Then
                '            MessageBox.Show("Descripción: " & CType(respOracle.Fields(1).Value, String), "ORACLE -> Error: " & CType(respOracle.Fields(0).Value, String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                '            Return False
                '        End If
                '    End If
                'Catch Qex As Exception
                '    MessageBox.Show(Qex.Message, "Seguridad del Sistema")
                '    Return False
                'End Try
            Next
            ' 
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region
    Private Sub limpiar_mantdatos()
        txtidruta.Text = Nothing
        txtidpais.Text = Nothing
        ' cmboperacion.SelectedValue = Nothing
        txtruta.Text = Nothing
        cmbdepartamento.Text = Nothing
        dgvdetalle.Columns.Clear()
    End Sub
    Private Function validardatosrepetidos() As Boolean
        Dim dgvr As New DataGridViewRow
        Dim fila, filabuscada As New Integer
        Dim idprovincia, iddistrito As New Integer
        ' Validar datos repetidos 
        dgvr = dgvdetalle.CurrentRow
        dgvdetalle.EndEdit()
        filabuscada = dgvr.Index
        idprovincia = CType(dgvr.Cells(1).Value, Integer)
        iddistrito = CType(dgvr.Cells(2).Value, Integer)
        For fila = 0 To dgvdetalle.Rows.Count - 1
            If fila <> filabuscada Then
                If dgvdetalle.Rows(fila).Cells(1).Value = idprovincia And _
                   dgvdetalle.Rows(fila).Cells(2).Value = iddistrito Then
                    MessageBox.Show("El distrito ya sido ingresado", "Mantenimiento ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dgvdetalle.CurrentCell = dgvdetalle.Rows(filabuscada).Cells(2)
                    Return False
                End If
            End If
        Next
        Return True
    End Function
    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem1.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem1.EnabledChanged, CancelarToolStripMenuItem.EnabledChanged, GrabarToolStripMenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class
