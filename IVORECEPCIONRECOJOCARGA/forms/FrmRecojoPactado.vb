'Imports System
'Imports System.Windows.Forms
'Imports System.Data
'Imports System.Data.OleDb
'Imports System.Text.RegularExpressions
'Imports System.Drawing
'Imports System.IO
'Imports ADOSERVERLib
Imports System.Globalization
'Imports RustemSoft.DataGridViewColumns
'Imports Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn
Public Class Frmrecojopactado
    Inherits FrmPlantillasolrecojocarga  
#Region "Variables "
    Dim myclaserecojopactado As New dtorecojopactado
    Dim myclaserecojopactadodet As New dtorecojopactadodet
    'Dim odda4 As New OleDbDataAdapter
    'datahelper
    'Dim rstinicio, rstAgencia, rstrecojopactado, rstrecojodiario, rstdiasemana, rsttipopacto As ADODB.Recordset
    'Dim rstAgencia, rstrecojopactado, rstrecojodiario, rstdiasemana, rsttipopacto As ADODB.Recordset
    Dim rstinicio As DataTable
    Dim dtinicio, dtAgencia, dtrecojopactado, dtrecojodiario, dtdiasemana, dttipopacto As New System.Data.DataTable
    Dim dvinicio, DvAgencia, Dvrecojopactado, Dvrecojodiario, dvdiasemana, dvtipopacto As New DataView
    'Dim Fact As Integer
    Dim control_cab As Integer
    Dim idrecojo_carga_pactado As New Integer
    Dim traedatos As New Boolean
    Dim ini_idpais, ini_iddepartamento, ini_idprovincia, ini_distrito, ini_agencia As Integer
    '' Detalle
    'datahelper
    'Dim rstrecojoacordado, rstrecojoacordadodia As New ADODB.Recordset
    'datahelper
    'Dim rstrecojoacordadodia As New ADODB.Recordset
    Dim dtrecojoacordado, dtrecojoacordadodia As New DataTable
    Dim dvrecojoacordado, dvrecojoacordadodia As New DataView
    ' 
    Dim dvgc As DataGridView
    ' Variables para generar nueva direccion del contacto 
    Dim gdireccion As String
    Dim gidpais As Integer
    Dim giddepartamento As Integer
    Dim gidprovincia As Integer
    Dim giddistrito As Integer
    Dim gtipodireccion As Integer
    Dim gidubigeo As Integer
    Dim grefllegada As String
    ' 
    Dim gnrodcto As String
    Dim gnombre As String
    Dim gapepaterno As String
    Dim gapematerno As String
    Dim gidsucuenta As Integer
    Dim gidcargo As Integer
    Dim gigdtipdcto As Integer
    Dim gidsexo As Integer
    '
    Private Const mDateFormat As String = "HH:mm"
    Private mLoHrCell As DataGridViewTextBoxCell
    Dim bIngreso As Boolean
    Public hnd As Long
#End Region
#Region "Eventos"

    Private Sub Frmrecojopactado_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub
    Private Sub Frmrecojopactado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            ' Titulo en el formulario 
            ShadowLabel1.Text = "Recojo de carga pactado"
            'Configurando seteando los botones 
            ToolStripMenuItem2.Visible = False
            ToolStripMenuItem3.Visible = False
            ToolStripMenuItem4.Visible = False
            ToolStripMenuItem5.Visible = False
            ToolStripMenuItem6.Visible = False

            ' 
            NuevoToolStripMenuItem1.Visible = True
            NuevoToolStripMenuItem1.Enabled = True
            '
            CancelarToolStripMenuItem.Enabled = False
            CancelarToolStripMenuItem.Visible = False
            '
            EliminarToolStripMenuItem.Enabled = False
            ExportarToolStripMenuItem.Enabled = False
            '
            MenuTab.Items(0).Enabled = True
            MenuTab.Items(0).Text = "Recojo carga"
            MenuTab.Items(1).Visible = True
            MenuTab.Items(1).Text = "Mantenimiento recojo carga"
            MenuTab.Items(1).Enabled = False
            ' Recupera Agencia pactado 
            myclaserecojopactado.idusuario_personal = dtoUSUARIOS.IdLogin
            myclaserecojopactado.idagencias = -666
            'datahelper
            'rstinicio = myclaserecojopactado.GetComborecojoacordado()
            'odda4.Fill(dtinicio, rstinicio)
            Dim ds As DataSet = myclaserecojopactado.GetComborecojoacordado()
            dtinicio = ds.Tables(0)
            '
            ini_idpais = dtinicio.Rows(0).Item(0)
            ini_iddepartamento = dtinicio.Rows(0).Item(1)
            ini_idprovincia = dtinicio.Rows(0).Item(2)
            ini_distrito = dtinicio.Rows(0).Item(3)
            ini_agencia = dtoUSUARIOS.iIDAGENCIAS 'dtinicio.Rows(0).Item(4)
            '
            ModSolRecojoCarga.iddistrito = ini_distrito
            ModSolRecojoCarga.idprov = ini_idprovincia
            ModSolRecojoCarga.iddpto = ini_iddepartamento
            ModSolRecojoCarga.idpais = ini_idpais
            '
            'datahelper
            'rstAgencia = rstinicio.NextRecordset
            'odda4.Fill(dtAgencia, rstAgencia)
            dtAgencia = ds.Tables(1)
            DvAgencia = CargarCombo(cmbagencia, dtAgencia, "nombre_agencia", "idagencias", ini_agencia)
            '
            'datahelper
            'rstrecojopactado = rstinicio.NextRecordset()
            'odda4.Fill(dtrecojopactado, rstrecojopactado)
            dtrecojopactado = ds.Tables(2)
            Dvrecojopactado = dtrecojopactado.DefaultView
            '
            'datahelper
            'rstdiasemana = rstinicio.NextRecordset()
            'odda4.Fill(dtdiasemana, rstdiasemana)
            dtdiasemana = ds.Tables(3)
            dvdiasemana = dtdiasemana.DefaultView

            'datahelper
            'rsttipopacto = rstinicio.NextRecordset()
            'odda4.Fill(dttipopacto, rsttipopacto)
            dttipopacto = ds.Tables(4)
            dvtipopacto = dttipopacto.DefaultView
            'Cargando las agencias al árbol 
            'datahelper
            'rstAgencia.MoveFirst()
            'ModuUtil.LlenarTreeCtrl(rstAgencia, Me.TreeLista, "Agencias")
            ModuUtil.LlenarTreeCtrl(dtAgencia, Me.TreeLista, "Agencias")
            Me.TreeLista.ExpandAll()
            '
            Call GrillaMante()

            bIngreso = False
            Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)
            bIngreso = True


        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub TreeLista_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeLista.AfterSelect
        Dim idagencia As Integer
        Dim filtro As String = ""
        idagencia = e.Node().Tag
        If idagencia <> 0 Then
            filtro = "idagencias =" & Trim(idagencia)
        Else
            filtro = ""
        End If
        Dvrecojopactado.RowFilter = filtro
    End Sub
    Private Sub frmrutas_MenuCancelar() Handles Me.MenuCancelar
        SplitContainer2.Panel1Collapsed = False
        limpiar_datos()
        ' -- 
        CancelarToolStripMenuItem.Enabled = False
        CancelarToolStripMenuItem.Visible = False
        ' --
        Me.SelectMenu(0)
        EliminarToolStripMenuItem.Enabled = False
        ' --
    End Sub
    Private Sub Frmrecojopactado_MenuNuevo() Handles Me.MenuNuevo
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
            ' 
            CancelarToolStripMenuItem.Enabled = True
            CancelarToolStripMenuItem.Visible = True
            ' 
            ' Recuperando el detalle 
            idrecojo_carga_pactado = Nothing
            If Not (TreeLista.SelectedNode Is Nothing) Then
                If CType(TreeLista.SelectedNode.Level, Integer) <> 0 Then
                    ini_agencia = TreeLista.SelectedNode.Tag
                End If
            End If
            cmbagencia.SelectedValue = ini_agencia
            asignaagencia()
            '             
            obteniendo_detalle()
            '
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub Frmrecojopactado_MenuEditar() Handles Me.MenuEditar
        Dim dgvr As New DataGridViewRow
        Dim lb_regresa As Boolean = False
        Try
            ' No debe hacer nada 
            If DataGridViewPlt.Rows.Count < 1 Then
                Return
            End If
            ' Edicion  
            control_cab = 0
            ' Desactivando             
            CancelarToolStripMenuItem.Enabled = True
            CancelarToolStripMenuItem.Visible = True
            GrabarToolStripMenuItem.Enabled = True
            GrabarToolStripMenuItem.Visible = True
            '
            MenuTab.Items(0).Enabled = False
            MenuTab.Items(1).Enabled = True
            MenuTab.Items(2).Enabled = True
            MenuTab.Items(3).Enabled = True
            MenuTab.Items(4).Enabled = True
            TabMante.SelectedIndex = 1
            dgvr = DataGridViewPlt.CurrentRow
            idrecojo_carga_pactado = dgvr.Cells(3).Value
            obteniendo_detalle()
        Catch qex As Exception
            MessageBox.Show(qex.Message, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub Frmrecojopactado_MenuGrabar() Handles Me.MenuGrabar
        Try
            Dim MyObligatorios() As Object = {Me.txtCliente, Me.txtCliente, Me.Txtdireccion, _
                                              Me.txtcontacto}   ' Ingresar los códigos 
            'datahelper
            'Dim rstmensaje, rstdatos As New ADODB.Recordset
            'Dim rstdatos As New ADODB.Recordset
            Dim dtmensaje, dtdatos As New DataTable
            ''''''''''''''''''''''
            ' Grabar validar 
            ''''''''''''''''''''''    
            If DGVdiarecojo.Rows.Count < 1 Then
                MessageBox.Show("Falta ingresar los días para el recojo", "Recojo Pactado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DGVdiarecojo.Focus()
                Return
            End If
            If ModuUtilom.Validaciones(MyObligatorios) = 0 Then 'Si todo esta bien... (funcion comun x Richard)
                myclaserecojopactado.control = control_cab
                If IsDBNull(txtidentregarecojo.Text) Or txtidentregarecojo.Text = Nothing Or txtidentregarecojo.Text = "" Then
                    myclaserecojopactado.idrecojo_carga_pactado = -666
                Else
                    myclaserecojopactado.idrecojo_carga_pactado = txtidentregarecojo.Text
                End If
                myclaserecojopactado.idagencias = CType(cmbagencia.SelectedValue, Integer)
                'Recuperando el id de la persona 
                myclaserecojopactado.idpersona = CType(txtidcliente.Text, Integer)
                If IsDBNull(txtiddireccion.Text) = True Or txtiddireccion.Text = "" Then
                    myclaserecojopactado.idireccion_consignado = -666
                Else
                    myclaserecojopactado.idireccion_consignado = CType(txtiddireccion.Text, Integer)
                End If
                If IsDBNull(txtidcontacto.Text) = True Or txtidcontacto.Text = "" Then
                    myclaserecojopactado.idcontacto_persona = -666
                Else
                    myclaserecojopactado.idcontacto_persona = CType(txtidcontacto.Text, Integer)
                End If
                myclaserecojopactado.fecha_inicio = CType(DTPFecinicial.Value, String)
                myclaserecojopactado.fecha_fin_pacto = CType(DTPfecfinal.Value, String)
                '' Propio del sistema 
                myclaserecojopactado.idusuario_personal = dtoUSUARIOS.IdLogin
                myclaserecojopactado.idrol_usuario = dtoUSUARIOS.IdRol
                myclaserecojopactado.ip = dtoUSUARIOS.IP
                myclaserecojopactado.idestado_registrado = 1 'Por ahora estara activo omendoza --> Proceso                          
                ' Trayendo los parametros 
                myclaserecojopactado.idtipodireccion = gtipodireccion
                myclaserecojopactado.direccion = gdireccion
                myclaserecojopactado.refllegada = grefllegada
                myclaserecojopactado.idubigeo = gidubigeo
                myclaserecojopactado.idpais = gidpais
                myclaserecojopactado.idepartamento = giddepartamento
                myclaserecojopactado.idprovincia = gidprovincia
                myclaserecojopactado.idistrito = giddistrito
                myclaserecojopactado.idcargo = gidcargo
                myclaserecojopactado.nombre = gnombre
                myclaserecojopactado.apepaterno = gapepaterno
                myclaserecojopactado.apematerno = gapematerno
                myclaserecojopactado.idtipdcto = gigdtipdcto
                myclaserecojopactado.nrodocumento = gnrodcto
                myclaserecojopactado.idsexo = gidsexo
                myclaserecojopactado.idsucuenta = gidsucuenta
                'datahelper
                'rstmensaje = myclaserecojopactado.actualizarecojo_pactado()
                'odda4.Fill(dtmensaje, rstmensaje)
                Dim ds As DataSet = myclaserecojopactado.actualizarecojo_pactado()
                dtmensaje = ds.Tables(0)
                ' Recupera el mensaje 
                'datahelper
                'rstdatos = rstmensaje.NextRecordset()
                'odda4.Fill(dtdatos, rstdatos)
                'rstdatos = ds.Tables(0)
                dtdatos = ds.Tables(1)
                '
                Try
                    If IsDBNull(dtmensaje.Rows(0).Item(0)) = False Then
                        If dtmensaje.Rows(0).Item(0) = 0 Then
                            ' Recupera el id de la ruta 
                            If dtdatos.Rows.Count > 0 Then
                                idrecojo_carga_pactado = CType(dtdatos.Rows(0).Item(0), Integer)
                                txtidentregarecojo.Text = CType(idrecojo_carga_pactado, String)
                            End If
                            ' Considerando los parametros 
                            ' Añadiendo los datos en el datagridview 
                            If control_cab = 1 Then
                                Dim dtrow As DataRow
                                dtrow = dtrecojopactado.NewRow
                                dtrow("idrecojo_carga_pactado") = CType(txtidentregarecojo.Text, Integer)
                                dtrow("razon_social") = CType(txtCliente.Text, String)
                                'dtrow("idpersona") = CType(txtidcliente.Text, Integer)
                                '
                                dtrow("direccion") = CType(Txtdireccion.Text, String)
                                'dtrow("iddireccion_consignado") = CType(txtiddireccion.Text, Integer)
                                '
                                'dtrow("idcontacto_persona") = CType(txtidcontacto.Text, Integer)
                                dtrow("contacto") = CType(txtcontacto.Text, String)
                                dtrow("idagencias") = CType(cmbagencia.SelectedValue, Integer)
                                ' 
                                dtrecojopactado.Rows.Add(dtrow)
                            End If
                            ' Grabando el detalle 
                            control_cab = 0
                            If Not Grabar_detalle() Then Return ' Si falta o existe un error no graba el detalle 
                        End If
                        'If control_cab = 1 Then
                        '    Dim dtrow As DataRow
                        '    dtrow = dtrecojopactado.NewRow
                        '    dtrow("razon_social") = CType(txtCliente.Text, String)
                        '    dtrow("direccion") = CType(Txtdireccion.Text, String)
                        '    dtrow("contacto") = CType(txtcontacto.Text, String)
                        '    dtrow("idrecojo_carga_pactado") = CType(txtidentregarecojo.Text, Integer)
                        '    dtrecojopactado.Rows.Add(dtrow)
                        'End If
                    Else
                        If CType(dtmensaje.Rows(0).Item(0), Integer) <> 0 Then
                            MessageBox.Show("Descripción: " & CType(dtmensaje.Rows(0).Item(1), String), "ORACLE -> Error: " & CType(dtmensaje.Rows(0).Item(0), String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If
                Catch Qex As Exception
                    MessageBox.Show(Qex.Message, "Seguridad del Sistema")
                End Try
            End If
            limpiar_datos()
            EdicionToolStripMenuItem.Enabled = False
            CancelarToolStripMenuItem.Enabled = False
            CancelarToolStripMenuItem.Visible = False
            GrabarToolStripMenuItem.Enabled = False
            SplitContainer2.Panel1Collapsed = False
            SelectMenu(0)
            ' Limpiar los datos del mantenimiento de datos        
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        'Dim dgvr As DataGridViewRow
        'Dim fila As Long
        'Recuperando el valor del cliente         
        'If FlgTre = 0 Then
        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If
        'If msg.WParam.ToInt32() = CInt(Keys.Escape) Then
        '    '    'Me.DGVCliente.Visible = True
        '    'Me.DGVCliente.Visible = False
        '    '    'ocultar_dvg()
        '    '    Return True
        'End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
#End Region
#Region "Funciones y Procedimientos"
    Sub GrillaMante()
        ' Llena una grilla una vez insertado el objeto. 
        'Configurando el objeto
        DataGridViewPlt.Columns.Clear()
        With DataGridViewPlt
            .AutoGenerateColumns = False
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.BackgroundColor = Color.White
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
            '
            .DataSource = Dvrecojopactado
        End With
        '
        Dim lrazonsocial As New DataGridViewTextBoxColumn
        With lrazonsocial '0
            .DefaultCellStyle.BackColor = SystemColors.Info
            .DataPropertyName = "razon_social"
            .Name = "razon_social"
            .HeaderText = "Razón social"
            .ReadOnly = True
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '.Resizable = DataGridViewTriState.True 
        End With
        DataGridViewPlt.Columns.Add(lrazonsocial)
        '
        Dim ldireccion As New DataGridViewTextBoxColumn
        With ldireccion '1
            .DefaultCellStyle.BackColor = SystemColors.Info
            .DataPropertyName = "direccion"
            .Name = "direccion"
            .HeaderText = "Dirección"
            .ReadOnly = True
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '.Resizable = DataGridViewTriState.True
        End With
        DataGridViewPlt.Columns.Add(ldireccion)
        '
        Dim lcontacto As New DataGridViewTextBoxColumn
        With lcontacto '2
            .DefaultCellStyle.BackColor = SystemColors.Info
            .DataPropertyName = "contacto"
            .Name = "contacto"
            .HeaderText = "Contacto"
            .ReadOnly = True
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '.Resizable = DataGridViewTriState.True
        End With
        DataGridViewPlt.Columns.Add(lcontacto)
        ' 
        Dim iidruta_entrega_recojo As New DataGridViewTextBoxColumn
        With iidruta_entrega_recojo '3
            .DefaultCellStyle.BackColor = SystemColors.Info
            .DataPropertyName = "idrecojo_carga_pactado"
            .Name = "idrecojo_carga_pactado"
            .HeaderText = "Id Recojo carga"
            .ReadOnly = True
            .Visible = False
        End With
        DataGridViewPlt.Columns.Add(iidruta_entrega_recojo)
        '
        'Dim DataGridTableStylew As New DataGridTableStyle()
        'With DataGridTableStylew
        '    .MappingName = Dv_cliente.Table.TableName
        '    .RowHeaderWidth = 5
        '    .AllowSorting = True
        'End With
        'Dim DataGridTableStyle1 As New DataGridTextBoxColumn()
        'With DataGridTableStyle1
        '    .MappingName = "IDPERSONA"
        '    .HeaderText = "Código"
        '    .Width = 85
        '    '.ReadOnly = True
        '    .NullText = ""
        '    .TextBox.Enabled = False
        'End With
        '    Dim DataGridTableStyle2 As New DataGridTextBoxColumn()
        '    With DataGridTableStyle2
        '        .MappingName = "RAZON_SOCIAL"
        '        .HeaderText = "Cliente"
        '        .Width = 300
        '        .NullText = ""
        '    End With
        '    DataGridTableStylew.GridColumnStyles.AddRange _
        '(New DataGridColumnStyle() _
        '     {DataGridTableStyle1, _
        '     DataGridTableStyle2})
        '    'DataGridLista.TableStyles.Add(DataGridTableStylew)
    End Sub
    Private Sub grilladetalle()
        Try
            DGVdiarecojo.Columns.Clear()
            With DGVdiarecojo
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .BackgroundColor = Color.White
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                '.VirtualMode = True
                '.RowHeadersVisible = False
                .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .AutoGenerateColumns = False
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = True
                .AllowUserToAddRows = True 'Para que no incremente la fila
                '
                .DataSource = dvrecojoacordadodia 'Dvrecojodiario
            End With
            '
            Dim ldia As New DataGridViewComboBoxColumn
            With ldia   '0
                .DataSource = dvdiasemana
                .DataPropertyName = "dia_semana"
                .DisplayMember = "nombre_dia"
                .ValueMember = "dia_semana"
                .HeaderText = "Día"
            End With
            DGVdiarecojo.Columns.Add(ldia)
            '
            Dim iidentrega_recojo_dia_hora As New DataGridViewTextBoxColumn
            With iidentrega_recojo_dia_hora '1
                .Visible = False
                ' .DefaultCellStyle.BackColor = SystemColors.Info
                .DataPropertyName = "identrega_recojo_dia_hora"
                .Name = "identrega_recojo_dia_hora"
                .HeaderText = "id recojo dia hora"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.True
            End With
            DGVdiarecojo.Columns.Add(iidentrega_recojo_dia_hora)
            '
            Dim lhorainicio As New DataGridViewTextBoxColumn
            Dim date_info As DateTimeFormatInfo = CultureInfo.CurrentCulture.DateTimeFormat()
            '----
            'Dim lhorainicio As New DataGridViewDateTimeColumn
            'Dim lhorainicio As New DataGridViewTextBoxCell
            'Dim lhorainicio As New MaskedTextBox
            '----
            With lhorainicio '2            
                .DefaultCellStyle.BackColor = SystemColors.Info
                .DataPropertyName = "hora_inicio"
                .Name = "hora_inicio"
                .DefaultCellStyle.Format = date_info.ShortTimePattern
                .HeaderText = "Hora Listo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.True
                ''''''''''''
                'mLoHrCell = New DataGridViewTextBoxCell
                'With mLoHrCell.Style
                '    .Font = New Font(DGV.Font, FontStyle.Italic)
                '    .BackColor = Color.FromArgb(255, 255, 180)
                '    .ForeColor = Color.Black
                '    .Padding = P
                '    .Format = mDateFormat
                'End With
                ''''''''''''
                '' Valores 
                '.box.AutoValidate = Windows.Forms.AutoValidate.EnableAllowFocusChange
                ' Identify selected cell's DateTime format to edit
                '.box.DateTimeFormat = DateTimeStencils.HHMM24
                ' Identify whole column DateTime format to display in each inactive column
                ' .DateTimeDisplayFormat = DateTimeStencils.HHMM24
                ' Specify Delimiter Character for the field
                '.box.DelimiterChar = ":"
                '.box.DefaultValue = New DateTime(2010, 5, 26, 11, 11, 11)
                '' Identify column selected cell back and foreground colors
                '.box.BackColor = Color.LightGray
                '.box.ForeColor = Color.DarkRed
                '' Define cell warning color
                '.box.ProblemColor = Color.LightPink
                '' Identify whole column back and fore colors
                '.CellTemplate.Style.BackColor = Color.Ivory
                '.CellTemplate.Style.ForeColor = Color.DarkBlue
                ' Define cell border style
                '.box.BorderStyle = BorderStyle.None
            End With
            DGVdiarecojo.Columns.Add(lhorainicio)
            '
            Dim lhorafinal As New DataGridViewTextBoxColumn
            With lhorafinal '3
                .DefaultCellStyle.BackColor = SystemColors.Info
                .DataPropertyName = "hora_final"
                .Name = "hora_final"
                .HeaderText = "Hora Cierre"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.True
            End With
            DGVdiarecojo.Columns.Add(lhorafinal)
            '        
            Dim tbpesokg0 As New DataGridViewTextBoxColumn
            With tbpesokg0  '4
                .DataPropertyName = "peso_kg"
                .HeaderText = "Peso"
                .DefaultCellStyle.Format = "###,###,###.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.True
            End With
            DGVdiarecojo.Columns.Add(tbpesokg0)
            '
            Dim tbvolumen0 As New DataGridViewTextBoxColumn
            With tbvolumen0   '5
                .DataPropertyName = "volumen"
                .HeaderText = "Volumen"
                .Width = 70
                .DefaultCellStyle.Format = "###,###,###.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.True
            End With
            DGVdiarecojo.Columns.Add(tbvolumen0)
            '
            Dim Colindactivo As New DataGridViewCheckBoxColumn
            With Colindactivo '6
                .HeaderText = "Activo"
                .Name = "dia_activo"
                .DataPropertyName = "dia_activo"
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Resizable = DataGridViewTriState.True
            End With
            DGVdiarecojo.Columns.Add(Colindactivo)
            '
            'Dim iidruta_entrega_recojo As New DataGridViewTextBoxColumn
            'With iidruta_entrega_recojo '7
            '    .DefaultCellStyle.BackColor = SystemColors.Info
            '    .DataPropertyName = "idrecojo_carga_pactado"
            '    .Name = "idrecojo_carga_pactado"
            '    .HeaderText = "Id Recojo carga"
            '    .ReadOnly = True
            '    .Visible = False
            'End With
            'DGVdiarecojo.Columns.Add(iidruta_entrega_recojo)
            '
        Catch exc As Exception
            MessageBox.Show(exc.Message, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub limpiar_mantdatos()
        cmbagencia.SelectedValue = 0
        txtCliente.Text = Nothing
        txtcontacto.Text = Nothing
        Txtdireccion.Text = Nothing
        'DTPfecfinal.Value = ""
        DGVdiarecojo.Columns.Clear()
    End Sub
    Private Sub obteniendo_detalle()
        Try
            '' Recupera el detalle   
            If IsDBNull(idrecojo_carga_pactado) = True Or idrecojo_carga_pactado < 1 Then
                myclaserecojopactadodet.idrecojo_carga_pactado = -666 ' Recupera una fila nueva
                traedatos = False
            Else
                myclaserecojopactadodet.idrecojo_carga_pactado = idrecojo_carga_pactado
                traedatos = True
            End If
            '
            dtrecojoacordado = Nothing
            dvrecojoacordado = Nothing
            dtrecojoacordado = New DataTable
            dvrecojoacordado = New DataView
            dtrecojoacordadodia = Nothing
            dvrecojoacordadodia = Nothing
            dtrecojoacordadodia = New DataTable
            dvrecojoacordado = New DataView
            '
            'datahelper
            'rstrecojoacordado = myclaserecojopactadodet.Getrecojoacordadodetalle()
            'odda4.Fill(dtrecojoacordado, rstrecojoacordado)
            Dim ds As DataSet = myclaserecojopactadodet.Getrecojoacordadodetalle()
            dtrecojoacordado = ds.Tables(0)
            dvrecojoacordado = dtrecojoacordado.DefaultView
            ' 
            'datahelper
            'rstrecojoacordadodia = rstrecojoacordado.NextRecordset
            'odda4.Fill(dtrecojoacordadodia, rstrecojoacordadodia)
            dtrecojoacordadodia = ds.Tables(1)
            dvrecojoacordadodia = dtrecojoacordadodia.DefaultView
            '' Recupera el detalle de la ruta de acuerdo a las caracteristicas  
            If traedatos Then
                Dim idcliente, iddireccion, idcontacto As Integer
                idcliente = dtrecojoacordado.Rows(0).Item(1)
                txtidcliente.Text = idcliente
                iddireccion = dtrecojoacordado.Rows(0).Item(3)
                txtiddireccion.Text = iddireccion
                idcontacto = dtrecojoacordado.Rows(0).Item(5)
                txtidcontacto.Text = idcontacto
                txtidentregarecojo.Text = dtrecojoacordado.Rows(0).Item(0)
                txtCliente.Text = dtrecojoacordado.Rows(0).Item(2)
                cmbagencia.SelectedValue = dtrecojoacordado.Rows(0).Item(7)
                Txtdireccion.Text = dtrecojoacordado.Rows(0).Item(4)
                txtcontacto.Text = dtrecojoacordado.Rows(0).Item(6)
                '---
            End If
            grilladetalle()
        Catch qex As Exception
            MessageBox.Show(qex.Message, "Seguridad del Sistema")
        End Try
    End Sub
    Private Function Grabar_detalle() As Boolean
        Dim fila As Integer
        'datahelper
        'Dim rstmensaje, rstdatos As New ADODB.Recordset
        'Dim rstdatos As New ADODB.Recordset
        Dim dtmensaje, dtdatos As New DataTable
        Dim myclaserutadet As New dtorutadet
        Dim dgvr As New DataGridViewRow
        Dim cmbdistrito As New DataGridViewComboBoxCell
        Dim distrito As New Integer
        '
        DGVdiarecojo.EndEdit()
        '
        myclaserecojopactadodet.idusuario_personal = dtoUSUARIOS.IdLogin
        myclaserecojopactadodet.idrol_usuario = dtoUSUARIOS.IdRol
        myclaserecojopactadodet.ip = dtoUSUARIOS.IP
        myclaserecojopactadodet.idestado_registrado = 1 'Por ahora estara activo omendoza --> Proceso         
        ' Recuperando los datos de la cabecera 
        myclaserecojopactadodet.idrecojo_carga_pactado = CType(txtidentregarecojo.Text, Integer)
        '
        For fila = 0 To DGVdiarecojo.Rows.Count - 2 'Prueba esto
            Try
                '  For fila = 0 To dtrecojoacordadodia.Rows.Count - 1
                If IsDBNull(DGVdiarecojo.Rows(fila).Cells(1).Value) = True Then
                    ' Ojo se debe grabar con el dataview y datarow --> Edu 
                    myclaserecojopactadodet.control = 1
                    myclaserecojopactadodet.identrega_recojo_dia_hora = -666
                Else
                    myclaserecojopactadodet.control = 0
                    myclaserecojopactadodet.identrega_recojo_dia_hora = CType(DGVdiarecojo.Rows(fila).Cells(1).Value, Integer)
                End If
                If IsDBNull(DGVdiarecojo.Rows(fila).Cells(0).Value) = True Then ' Validando el ingreso del día 
                    MessageBox.Show("Falta el día de la semana a recoger ", "Recojo pactado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGVdiarecojo.CurrentCell = DGVdiarecojo.Rows(fila).Cells(0)
                    Return False
                End If
                '
                myclaserecojopactadodet.dia_semana = CType(DGVdiarecojo.Rows(fila).Cells(0).Value, Integer)
                '   lidistrito = dgvdetalle.Rows(fila).Cells(2).Value
                If IsDBNull(DGVdiarecojo.Rows(fila).Cells(2).Value) = True Then ' Validando que ingrese la hora inicio 
                    MessageBox.Show("Falta ingresar hora listo", "Recojo pactado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGVdiarecojo.CurrentCell = DGVdiarecojo.Rows(fila).Cells(2)
                    Return False
                End If
                'Format(TestDateTime, "HH:mm:ss")
                myclaserecojopactadodet.hora_inicio = CType(Format(CType(DGVdiarecojo.Rows(fila).Cells(2).Value, Date), "hh:mm"), String)
                ' myclaserecojopactadodet.hora_inicio = DGVdiarecojo.Rows(fila).Cells(2).Value
                '
                If IsDBNull(DGVdiarecojo.Rows(fila).Cells(3).Value) = True Then ' Validando que ingrese la hora cierre
                    MessageBox.Show("Falta ingresar hora cierre", "Recojo pactado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DGVdiarecojo.CurrentCell = DGVdiarecojo.Rows(fila).Cells(3)
                    Return False
                End If
                myclaserecojopactadodet.hora_final = CType(DGVdiarecojo.Rows(fila).Cells(3).Value, String)

                If IsDBNull(myclaserecojopactadodet.dia_activo) = True Then
                    myclaserecojopactadodet.dia_activo = 1
                Else
                    myclaserecojopactadodet.dia_activo = CType(DGVdiarecojo.Rows(fila).Cells(6).Value, Integer)
                End If
                ' La cantidad de peso y volumen   
                If IsDBNull(DGVdiarecojo.Rows(fila).Cells(4).Value) = True Then
                    myclaserecojopactadodet.peso_kg = -666
                Else
                    myclaserecojopactadodet.peso_kg = CType(DGVdiarecojo.Rows(fila).Cells(4).Value, Double)
                End If
                '
                If IsDBNull(DGVdiarecojo.Rows(fila).Cells(5).Value) = True Then
                    myclaserecojopactadodet.volumen = -666
                Else
                    myclaserecojopactadodet.volumen = CType(DGVdiarecojo.Rows(fila).Cells(5).Value, Double)
                End If
                ' Recojo de cargo 
                myclaserecojopactadodet.idtipo_pacto = 2 ' Para este caso siempre va hacer de recojo 
                '
                'datahelper
                'rstmensaje = myclaserecojopactadodet.Actualizarecojoacordadodetalle
                'odda4.Fill(dtmensaje, rstmensaje)
                Dim ds As DataSet = myclaserecojopactadodet.Actualizarecojoacordadodetalle
                dtmensaje = ds.Tables(0)
                ' Recupera el mensaje 
                'datahelper
                'rstdatos = rstmensaje.NextRecordset()
                'odda4.Fill(dtdatos, rstdatos)
                dtdatos = ds.Tables(1)
                ' 
                If IsDBNull(dtmensaje.Rows(0).Item(0)) = False Then
                    If dtmensaje.Rows(0).Item(0) = 0 Then
                        ' Recupera el id de la ruta 
                        If dtdatos.Rows.Count > 0 Then
                            'Se debe recuperar los campos
                            If IsDBNull(dtdatos.Rows(0).Item(0)) = False Then
                                ' Adicionando valores al dataview 
                                DGVdiarecojo.Rows(fila).Cells(0).Value = CType(dtdatos.Rows(0).Item(0), Integer)
                            End If
                        End If
                    Else
                        If CType(dtmensaje.Rows(0).Item(0), Integer) <> 0 Then
                            MessageBox.Show("Descripción: " & CType(dtmensaje.Rows(0).Item(1), String), "ORACLE -> Error: " & CType(dtmensaje.Rows(0).Item(0), String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return False
                        End If
                    End If
                Else
                    If CType(dtmensaje.Rows(0).Item(0), Integer) <> 0 Then
                        MessageBox.Show("Descripción: " & CType(dtmensaje.Rows(0).Item(1), String), "ORACLE -> Error: " & CType(dtmensaje.Rows(0).Item(0), String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                End If
            Catch Qex As Exception
                MessageBox.Show(Qex.Message, "Seguridad del Sistema")
                Return False
            End Try
        Next
        ' 
        Return True
    End Function
#End Region
#Region " Busqueda Cliente Direccion y Contacto "
    Private Sub txtCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCliente.TextChanged
        'Verifica busqueda         
        Dim cadbusqueda As String
        cadbusqueda = CType(UCase(txtCliente.Text), String)
        If txtCliente.Text = "" Then
            txtidcliente.Text = ""
            ' txtCliente.Text = ""
            txtiddireccion.Text = ""
            Txtdireccion.Text = ""
            txtidcontacto.Text = ""
            txtcontacto.Text = ""
        End If
        'raiseevent btnBuscarcliente.Click()
        '  Call btnBuscarcliente_Click(btnBuscarcliente, e)
        'buscarcliente(cadbusqueda)
    End Sub
    'Sub buscarcliente(ByVal cadbusqueda As String)
    '    Dim rstcliente As New Recordset
    '    Dim dtcliente As New DataTable
    '    Dim dvcliente As New DataView
    '    Dim clasebusqueda As New dtoSolRecojoBusqueda
    '    Dim mensaje As String
    '    '
    '    clasebusqueda.busquedacondicicionclte = cadbusqueda
    '    rstcliente = clasebusqueda.BusquedaCliente
    '    odda4.Fill(dtcliente, rstcliente)
    '    dvcliente = dtcliente.DefaultView
    '    dvcliente.AllowNew = False
    '    grilla_cliente(dvcliente)
    '    If dvcliente.Count = 0 Then  'No existe el cliente  
    '        txtCliente.Text = ""
    '        mensaje = "Cliente no está registrado"
    '        MessageBox.Show(Me, mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        txtCliente.Focus()
    '        Exit Sub   ' Corta todo 
    '    End If
    '    If dvcliente.Count = 1 Then  'Si encuentra 1 solo registro traer la direccion
    '        trae_cliente() 'Omendoza se debe trae el cliente 
    '        Return
    '    End If
    '    If dvcliente.Count > 1 Then
    '        bcancelar = True
    '        dvgc = DGVCliente
    '        dvgc.Visible = True
    '        dvgc.Focus()
    '        bcancelar = False
    '    End If
    'End Sub
    'Sub grilla_cliente(ByVal adataview As DataView)
    '    DGVCliente.Columns.Clear()
    '    With DGVCliente
    '        .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    '        .BackgroundColor = Color.White
    '        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
    '        .AllowUserToOrderColumns = True
    '        .AllowUserToDeleteRows = False
    '        .AllowUserToAddRows = False  'Para que no incremente la fila
    '        .AutoGenerateColumns = False ''Las filas no se generen automaticamente de la bd
    '        .DataSource = adataview
    '        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
    '        .SelectionMode = DataGridViewSelectionMode.CellSelect
    '        .VirtualMode = True
    '        .RowHeadersVisible = False
    '        .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        '
    '        '.Location = New Point(Me.DGVSolicita.Location.X, Me.DGVSolicita.Location.Y + 70)
    '    End With
    '    'Creando los campos del tipo DataGridViewTextBoxColumn
    '    Dim dgvtbcrazonsocial As New DataGridViewTextBoxColumn
    '    With dgvtbcrazonsocial '0
    '        .DataPropertyName = "RAZON_SOCIAL"
    '        .HeaderText = "Razon Social"
    '        .ToolTipText = "Razón Social"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '    End With
    '    DGVCliente.Columns.Add(dgvtbcrazonsocial)
    '    '
    '    Dim dgvtbcidcliente As New DataGridViewTextBoxColumn
    '    With dgvtbcidcliente '1
    '        .HeaderText = "Código"
    '        .Name = "IDPERSONA"
    '        .DataPropertyName = "idpersona"
    '        .ReadOnly = True
    '        .Visible = False
    '    End With
    '    DGVCliente.Columns.Add(dgvtbcidcliente)
    '    '
    '    Dim dgvtbcapellido_paterno As New DataGridViewTextBoxColumn
    '    With dgvtbcapellido_paterno '2
    '        .DataPropertyName = "apellidos_y_nombres"
    '        .Name = "apellidos_y_nombres"
    '        .HeaderText = "Apellidos y Nombres"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '        .Visible = False
    '    End With
    '    DGVCliente.Columns.Add(dgvtbcapellido_paterno)
    '    '
    '    Dim dgvtbctipoidentidad As New DataGridViewTextBoxColumn
    '    With dgvtbctipoidentidad '3
    '        .DataPropertyName = "tipo_doc_identidad"
    '        .HeaderText = "Documento identidad"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '    End With
    '    DGVCliente.Columns.Add(dgvtbctipoidentidad)
    '    '
    '    Dim dgvtbcnu_docusuna As New DataGridViewTextBoxColumn
    '    With dgvtbcnu_docusuna '4
    '        .DataPropertyName = "nu_docu_suna"
    '        .HeaderText = "Número documento"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '    End With
    '    DGVCliente.Columns.Add(dgvtbcnu_docusuna)
    'End Sub
    'Private Sub trae_cliente()
    '    Dim dgvr As DataGridViewRow
    '    Dim li_idcliente As Integer
    '    Dim ls_cliente, ls_clte_concatenado As String
    '    Dim ls_cadena As String
    '    'Recuperando el valor del cliente 
    '    dgvr = Me.DGVCliente.CurrentRow()
    '    li_idcliente = CType(dgvr.Cells(1).Value, Integer)
    '    ls_cliente = dgvr.Cells(0).Value.ToString()
    '    ls_cadena = dgvr.Cells(3).Value.ToString()
    '    ls_cadena = ls_cadena + " - " + dgvr.Cells(4).Value.ToString()
    '    ls_clte_concatenado = ls_cliente + " (" + ls_cadena + ")"
    '    ' Pasando valor al datawindow padre  
    '    txtCliente.Text = ls_clte_concatenado
    '    txtidcliente.Text = li_idcliente
    '    DGVCliente.Visible = False  ' Termino y debe blanquear 
    '    'Busca Direccion 
    '    buscardireccion(li_idcliente)
    'End Sub
    'Private Sub buscardireccion(ByVal lidcliente As Integer)
    '    Dim rstdireccionl As New Recordset
    '    Dim dtdireccionl As New DataTable
    '    Dim dvdireccionl As New DataView
    '    Dim clasebusquedal As New dtoSolRecojoBusqueda
    '    ' Buscar direccion 
    '    clasebusquedal.Idcliente = lidcliente
    '    '
    '    rstdireccionl = clasebusquedal.BusquedaDireccion
    '    odda4.Fill(dtdireccionl, rstdireccionl)
    '    dvdireccionl = dtdireccionl.DefaultView
    '    dvdireccionl.AllowNew = False
    '    grilla_direccion(dvdireccionl)
    '    If dvdireccionl.Count = 0 Then
    '        MsgBox("LLamar a ventanita ya hecha")
    '        'Falta hacer esto mendozita  Apurimac
    '        '
    '        'Dim a As New FrmMantClteCarga
    '        'Dim resultado As DialogResult
    '        ''
    '        'DGVDireccion.Visible = False
    '        'ModSolRecojoCarga.idagencia = idagencia           
    '        'ModSolRecojoCarga.iddireccion_consignado = -666   'Valor nulo 
    '        'bcancelar = True  'Desactivando el control 
    '        'resultado = a.ShowDialog()
    '        ''Recuperando los valores para actualizar en lo que es la dirección y consignado 
    '        'If Not ModSolRecojoCarga.bcancelar Then
    '        '    Recuperadireccionnueva()
    '        'End If
    '        ''Debe retorna a la fila que se ha quedado 
    '        'bcancelar = False  'Activando el control  
    '        '' MsgBox("llamar a una ventanita para llenar la direccion y contacto")            
    '        'DGVSolicita.Focus()
    '        'DGVSolicita.CurrentCell = DGVSolicita.Rows(fila).Cells(10)
    '        ''
    '    End If
    '    If dvdireccionl.Count = 1 Then  'Si encuentra 1 solo registro traer la direccion
    '        dvgc.Visible = False
    '        bcancelar = True
    '        trae_direccion()
    '        bcancelar = False
    '    End If
    '    If dvdireccionl.Count > 1 Then
    '        'DGVSolicita.Enabled = False
    '        bcancelar = True
    '        dvgc.Visible = False
    '        DGVDireccion.Visible = True
    '        DGVDireccion.Focus()
    '        bcancelar = False
    '    End If
    'End Sub
    'Sub grilla_direccion(ByVal asdataview As DataView)
    '    DGVDireccion.Columns.Clear()
    '    With DGVDireccion
    '        .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    '        .BackgroundColor = Color.White
    '        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
    '        .AllowUserToOrderColumns = True
    '        .AllowUserToDeleteRows = False
    '        .AllowUserToAddRows = False  'Para que no incremente la fila
    '        .AutoGenerateColumns = False ''Las filas no se generen automaticamente de la bd
    '        .DataSource = asdataview
    '        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
    '        .SelectionMode = DataGridViewSelectionMode.CellSelect
    '        .VirtualMode = True
    '        .RowHeadersVisible = False
    '        .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        .AutoResizeColumns()
    '        '            
    '    End With
    '    Dim dgvtbcdireccion As New DataGridViewTextBoxColumn
    '    With dgvtbcdireccion  '0
    '        .DataPropertyName = "direccion"
    '        .HeaderText = "Dirección"
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '        .Resizable = DataGridViewTriState.True
    '    End With
    '    DGVDireccion.Columns.Add(dgvtbcdireccion)
    '    '
    '    Dim dgvtbciddireccion_consignado As New DataGridViewTextBoxColumn
    '    With dgvtbciddireccion_consignado  '1
    '        .Visible = False
    '        .DataPropertyName = "iddireccion_consignado"
    '        .HeaderText = "Direccion consignado"
    '        .ReadOnly = True
    '    End With
    '    DGVDireccion.Columns.Add(dgvtbciddireccion_consignado)
    '    '       
    '    Dim dgvtbcnom_contacto As New DataGridViewTextBoxColumn
    '    With dgvtbcnom_contacto   '2  DIRECCION 
    '        .DataPropertyName = "nom_contacto"
    '        .HeaderText = "Nombres y Apellidos"
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '    End With
    '    DGVDireccion.Columns.Add(dgvtbcnom_contacto)
    '    '
    '    Dim dgvtbcidcontacto As New DataGridViewTextBoxColumn
    '    With dgvtbcidcontacto  '3 
    '        .Visible = False
    '        .Width = 0
    '        .DataPropertyName = "idcontacto_persona"
    '        .HeaderText = "Código contacto"
    '    End With
    '    DGVDireccion.Columns.Add(dgvtbcidcontacto)
    '    '
    'End Sub
    'Private Sub trae_direccion()
    '    Dim dgvr As DataGridViewRow
    '    Dim li_iddireccion, lidcliente As Integer
    '    Dim ls_direccion As String
    '    'Recuperando el valor del cliente 
    '    dgvr = Me.DGVDireccion.CurrentRow()
    '    li_iddireccion = CType(dgvr.Cells(1).Value, Integer)
    '    ls_direccion = dgvr.Cells(0).Value.ToString()
    '    ' Pasando valor al datawindow padre          
    '    DGVDireccion.Visible = False
    '    Txtdireccion.Text = ls_direccion
    '    txtiddireccion.Text = li_iddireccion
    '    '
    '    lidcliente = CType(txtidcliente.Text, Integer)
    '    txtcontacto.Focus()
    '    buscarcontacto(lidcliente, li_iddireccion)
    'End Sub
    'Sub buscarcontacto(ByVal lidcliente As Integer, ByVal liddireccion As Integer)
    '    Dim rstcontacto As New Recordset
    '    Dim dtcontacto As New DataTable
    '    Dim dvcontacto As New DataView
    '    Dim clasebusqueda As New dtoSolRecojoBusqueda
    '    Dim dvrg As New DataGridViewRow
    '    '
    '    clasebusqueda.Idcliente = lidcliente
    '    clasebusqueda.Iddireccion = liddireccion
    '    rstcontacto = clasebusqueda.Busquedacontacto
    '    odda4.Fill(dtcontacto, rstcontacto)
    '    dvcontacto = dtcontacto.DefaultView
    '    dvcontacto.AllowNew = False
    '    'Creando la grilla de la direccion
    '    grilla_contacto(dvcontacto)
    '    'Ubicando la posicion 
    '    If dvcontacto.Count = 0 Then
    '        MessageBox.Show("Invocar ventanita ")
    '        'Dim a As New FrmMantClteCarga
    '        'Dim resultado As DialogResult
    '        ''
    '        'DGVDireccion.Visible = False
    '        'ModSolRecojoCarga.idagencia = idagencia
    '        'ModSolRecojoCarga.iddireccion_consignado = liddireccion
    '        'ModSolRecojoCarga.frmfilapadre = fila
    '        'bcancelar = True  'Desactivando el control 
    '        'resultado = a.ShowDialog()
    '        ''Recuperando los valores para actualizar en lo que es la dirección y consignado 
    '        'If Not ModSolRecojoCarga.bcancelar Then
    '        '    Recuperadireccionnueva()
    '        'End If
    '        ''Debe retorna a la fila que se ha quedado 
    '        'bcancelar = False  'Activando el control  
    '        ''''''''''''''''''''''''
    '        'DGVContacto.Visible = False
    '        'DGVSolicita.Focus()
    '        'DGVSolicita.CurrentCell = DGVSolicita.Rows(fila).Cells(10)
    '        ''
    '    End If
    '    If dvcontacto.Count() = 1 Then
    '        'Recupera direccion del cliente      
    '        dvrg = DGVContacto.CurrentRow
    '        txtcontacto.Text = dvrg.Cells(1).Value
    '        txtidcontacto.Text = dvrg.Cells(0).Value
    '    End If
    '    If dvcontacto.Count() > 1 Then
    '        ' Escondiendo los objetos 
    '        dvgc.Visible = False
    '        DGVDireccion.Visible = False
    '        '
    '        DGVDireccion.Visible = False
    '        '
    '        DGVContacto.Visible = True
    '        bcancelar = True
    '        DGVContacto.Focus() ' Estas seguro 
    '        bcancelar = False
    '    End If
    'End Sub
    'Sub grilla_contacto(ByVal asdataview As DataView)
    '    DGVContacto.Columns.Clear()
    '    With DGVContacto
    '        .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    '        .BackgroundColor = Color.White
    '        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
    '        .AllowUserToOrderColumns = True
    '        .AllowUserToDeleteRows = False
    '        .AllowUserToAddRows = False  'Para que no incremente la fila
    '        .AutoGenerateColumns = False ''Las filas no se generen automaticamente de la bd
    '        .DataSource = asdataview
    '        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
    '        .SelectionMode = DataGridViewSelectionMode.CellSelect
    '        .VirtualMode = True
    '        .RowHeadersVisible = False
    '        .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        .AutoResizeColumns()
    '        '           
    '    End With
    '    '
    '    Dim dgvtbcidcontacto As New DataGridViewTextBoxColumn
    '    With dgvtbcidcontacto   '0 
    '        .Visible = False
    '        .Width = 0
    '        .DataPropertyName = "idcontacto_persona"
    '        .HeaderText = "Código contacto"
    '        .ReadOnly = True
    '        .Visible = False
    '    End With
    '    DGVContacto.Columns.Add(dgvtbcidcontacto)
    '    '
    '    Dim dgvnom_contacto As New DataGridViewTextBoxColumn
    '    With dgvnom_contacto   '1
    '        .DataPropertyName = "nom_contacto"
    '        .HeaderText = "Encargado"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '        .Resizable = DataGridViewTriState.True
    '    End With
    '    DGVContacto.Columns.Add(dgvnom_contacto)
    'End Sub
#End Region
    'Private Sub txtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente.KeyPress
    '    MessageBox.Show(e.KeyChar.ToString)
    'End Sub
    'Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
    '    Select Case e.KeyCode
    '        Case Keys.Escape               ' Con la tecla escapa                 
    '            Try
    '                If Me.DGVCliente.Visible = True Then
    '                    Me.DGVCliente.Visible = False
    '                End If
    '                If DGVDireccion.Visible = True Then
    '                    DGVDireccion.Visible = False
    '                End If
    '                If DGVContacto.Visible = True Then
    '                    DGVContacto.Visible = False
    '                End If
    '            Catch exp As Exception
    '                MessageBox.Show(exp.Message, "Seguridad del Sistema")
    '            End Try
    '        Case Keys.F1  ' Invocnado con la tecla F1 
    '            Dim fila As New Integer
    '            Dim idcliente As New Integer
    '            Dim cadena As String
    '            Dim mensaje As String
    '            Dim paso As Boolean = True
    '            Dim idirecciont As Integer = 0
    '            ' 
    '            If txtCliente.Focus = True Then
    '                cadena = "%"
    '                bcancelar = True
    '                buscarcliente(cadena)
    '                bcancelar = False
    '            End If
    '            If Txtdireccion.Focus = True Then  ' Verifica el ingreso direcciones
    '                If txtCliente.SelectedText = "" Then
    '                    paso = False
    '                Else
    '                    idcliente = CType(txtidcliente.Text, Integer)
    '                End If
    '                If Not paso Then
    '                    mensaje = "Falta ingresar el cliente"
    '                    MessageBox.Show(mensaje, "Recojo pactado", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    txtCliente.Focus()
    '                    Exit Sub
    '                End If
    '                buscardireccion(idcliente)
    '            End If
    '            '
    '            If txtcontacto.Focus = True Then
    '                If txtCliente.Text = "" Then
    '                    paso = False
    '                    Exit Sub
    '                Else
    '                    idcliente = CType(txtCliente.Text, Integer)
    '                End If
    '                If Txtdireccion.Text = "" Then
    '                    paso = False
    '                    idirecciont = -1
    '                Else
    '                    idirecciont = txtiddireccion.Text
    '                End If
    '                If Not paso Then
    '                    If idirecciont <> -1 Then
    '                        mensaje = "Falta ingresar el cliente"
    '                        MessageBox.Show(mensaje, "Recojo Pactado", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                        txtCliente.Focus()
    '                        Exit Sub
    '                    Else
    '                        mensaje = "Falta ingresar la dirección"
    '                        MessageBox.Show(mensaje, "Recojo Pactado", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                        Txtdireccion.Focus()
    '                        Exit Sub
    '                    End If
    '                End If
    '                buscarcontacto(idcliente, idirecciont)
    '            End If
    '    End Select
    'End Sub
    'Private Sub DGVCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGVCliente.KeyDown
    '    Select Case e.KeyCode
    '        Case Keys.Escape
    '            DGVCliente.EndEdit()
    '            DGVCliente.Visible = False
    '        Case Keys.Tab
    '            Try
    '                'Devolviendo el valor 
    '                If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
    '                    trae_cliente()
    '                End If
    '            Catch exp As Exception
    '                MsgBox(exp.ToString, MsgBoxStyle.Exclamation, "Seguridad Sistema")
    '            End Try
    '    End Select
    'End Sub
    'Private Sub DGVCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGVCliente.KeyPress
    '    Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
    'End Sub
    'Private Sub DGVCliente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    Try
    '        Select Case e.KeyCode
    '            Case Keys.Escape
    '                DGVCliente.Visible = False
    '        End Select
    '    Catch exp As Exception
    '        MsgBox(exp.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
    '    End Try
    'End Sub
    Public Sub ocultar_dvg()
        ''
        'Dim mensaje As String
        'Try
        '    'Me.DGVDireccion.Visible = True
        '    'Me.DGVDireccion.Visible = False
        '    Me.DGVCliente.Visible = True
        '    Me.DGVCliente.Visible = False
        '    'Me.DGVContacto.Visible = False
        '    mensaje = "No hace nada"
        'Catch exp As Exception
        '    MsgBox(exp.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
        'End Try
    End Sub
    Private Sub btnBuscarcliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarcliente.Click
        Dim a As New frmbuscacliente
        Dim scadena As String
        '
        If asignaagencia() Then
            txtCliente.Text = ""
            Exit Sub
        End If
        ModSolRecojoCarga.busquedapor = 0
        If txtCliente.Text = "" Then
            scadena = ""
            Exit Sub
        Else
            scadena = txtCliente.Text
        End If
        '
        a.TextBox1.Text = scadena
        'a.ShowDialog()

        Acceso.Asignar(a, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            a.ShowDialog()
        Else
            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If IsDBNull(ModSolRecojoCarga.idcliente) = True Then
            txtidcliente.Text = ""
            txtCliente.Text = ""
            txtiddireccion.Text = ""
            Txtdireccion.Text = ""
            txtidcontacto.Text = ""
            txtcontacto.Text = ""
        Else
            'Recuperar el cliente 
            txtidcliente.Text = ModSolRecojoCarga.idcliente
            txtCliente.Text = ModSolRecojoCarga.scliente
            'If IsDBNull(ModSolRecojoCarga.iddireccion_consignado) = True Then
            recuperadireccion()
            'Else
            '    ' Recuperar la direccion 
            '    txtiddireccion.Text = ModSolRecojoCarga.idireccion
            '    Txtdireccion.Text = ModSolRecojoCarga.sdireccion
            'End If
            'If IsDBNull(ModSolRecojoCarga.idcontacto) = True Then
            '    recuperacontacto()
            'Else
            '    ' Recuperar el contacto 
            '    txtidcontacto.Text = ModSolRecojoCarga.idcontacto
            '    txtcontacto.Text = ModSolRecojoCarga.scontacto
            'End If
        End If
    End Sub
    Private Sub limpiar_datos()
        txtCliente.Text = ""
        txtidcliente.Text = ""
        txtiddireccion.Text = ""
        Txtdireccion.Text = ""
        txtidcontacto.Text = ""
        txtcontacto.Text = ""
        DGVdiarecojo.Columns.Clear()
    End Sub
    Private Sub txtCliente_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.Validated
        Dim scadena As String
        Dim cadbusqueda As String
        cadbusqueda = CType(UCase(txtCliente.Text), String)
        ModSolRecojoCarga.busquedapor = 0
        If txtCliente.Text = "" Then
            scadena = ""
            Exit Sub
        Else
            scadena = txtCliente.Text
        End If
        'Invocando a la ventana de cliente  
        Dim a As New frmbuscacliente
        If cmbagencia.SelectedValue < 1 Then
            MessageBox.Show("Seleccionar agencia", "Recojo Pactado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        ' Asignar la agencia con sus repectiva jerarquia  
        If asignaagencia() Then
            txtCliente.Text = ""
            Exit Sub
        End If
        '
        a.TextBox1.Text = scadena
        'a.ShowDialog()

        Acceso.Asignar(a, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            a.ShowDialog()
        Else
            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If IsDBNull(ModSolRecojoCarga.idcliente) = True Then
            txtidcliente.Text = ""
            txtCliente.Text = ""
            txtiddireccion.Text = ""
            Txtdireccion.Text = ""
            txtidcontacto.Text = ""
            txtcontacto.Text = ""
        Else
            'Recuperar el cliente 
            txtidcliente.Text = ModSolRecojoCarga.idcliente
            txtCliente.Text = ModSolRecojoCarga.scliente

            If IsDBNull(ModSolRecojoCarga.idireccion) = True Or ModSolRecojoCarga.idireccion < 1 Then
                recuperadireccion()
            Else
                ' Recuperar el direccion 
                txtiddireccion.Text = ModSolRecojoCarga.idireccion
                Txtdireccion.Text = ModSolRecojoCarga.sdireccion
                If IsDBNull(ModSolRecojoCarga.idcontacto) Or ModSolRecojoCarga.idireccion < 1 Then
                    recuperacontacto()
                Else
                    ' Recuperar el contacto 
                    txtidcontacto.Text = ModSolRecojoCarga.idcontacto
                    txtcontacto.Text = ModSolRecojoCarga.scontacto
                End If
            End If
        End If
    End Sub
    Function asignaagencia() As Boolean
        Dim fila As Integer
        Dim smensaje As String = ""
        Dim flag_control As Boolean = False
        ' Asignado la agencia con su respectiva jerarquia distrital 
        Try
            ModSolRecojoCarga.idagencia = CType(cmbagencia.SelectedValue, Integer)
            fila = cmbagencia.SelectedIndex
            '
            If IsDBNull(DvAgencia.Table.Rows(fila).Item(5)) = True Then
                smensaje = "La agencia no tiene asociado a ningún país, departamento, provincia y distrito "
                flag_control = True
            Else
                ModSolRecojoCarga.idpais = CType(DvAgencia.Table.Rows(fila).Item(5), Integer)
            End If

            '
            If ModSolRecojoCarga.idpais < 0 And Not flag_control Then
                smensaje = "La agencia no tiene asociado a ningún país, departamento, provincia y distrito"
                flag_control = True
            End If
            '
            If IsDBNull(DvAgencia.Table.Rows(fila).Item(4)) = True And Not flag_control Then
                smensaje = "La agencia no tiene asociado a ningún departamento, provincia y distrito"
                flag_control = True
            End If
            '
            If ModSolRecojoCarga.iddpto < 0 And Not flag_control Then
                smensaje = "La agencia no tiene asociado a ningún departamento, provincia y distrito"
                flag_control = True
            Else
                If Not flag_control Then
                    ModSolRecojoCarga.iddpto = CType(DvAgencia.Table.Rows(fila).Item(4), Integer)
                End If
            End If

            If IsDBNull(DvAgencia.Table.Rows(fila).Item(3)) = True And Not flag_control Then
                smensaje = "La agencia no tiene asociado a ninguna provincia y distrito"
                flag_control = True
            Else
                If Not flag_control Then
                    ModSolRecojoCarga.idprov = CType(DvAgencia.Table.Rows(fila).Item(3), Integer)
                End If
            End If
            If ModSolRecojoCarga.idprov < 0 And Not flag_control Then
                smensaje = "La agencia no tiene asociado a ninguna provincia y distrito"
                flag_control = True
            End If
            '
            If IsDBNull(DvAgencia.Table.Rows(fila).Item(2)) = True And Not flag_control Then
                smensaje = "La agencia no tiene asociado a ningún distrito"
                flag_control = True
            Else
                If Not flag_control Then
                    ModSolRecojoCarga.iddistrito = CType(DvAgencia.Table.Rows(fila).Item(2), Integer)
                End If
            End If
            '
            If ModSolRecojoCarga.iddistrito < 0 And Not flag_control Then
                smensaje = "La agencia no tiene asociado a ningún distrito"
                flag_control = True
            End If
            '
        Catch exc As Exception
            smensaje = exc.Message
            flag_control = True
        End Try
        If flag_control Then
            MessageBox.Show(smensaje, "Recojo Pactado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Return flag_control
    End Function
    Private Sub recuperadireccion()
        If IsDBNull(ModSolRecojoCarga.idireccion) = True Or ModSolRecojoCarga.idireccion < 1 Then
            gdireccion = True
            gidpais = ModSolRecojoCarga.idpais
            giddepartamento = ModSolRecojoCarga.iddpto
            gidprovincia = ModSolRecojoCarga.idprov
            giddistrito = ModSolRecojoCarga.iddistrito
            gtipodireccion = ModSolRecojoCarga.tipodireccion
            gidubigeo = ModSolRecojoCarga.idubigeo
            gdireccion = ModSolRecojoCarga.sdireccion
            grefllegada = ModSolRecojoCarga.srefllegada
            ' Pintando la direccion 
            Txtdireccion.Text = ModSolRecojoCarga.sdireccion
        Else
            ' Recuperar la direccion 
            txtiddireccion.Text = ModSolRecojoCarga.idireccion
            Txtdireccion.Text = ModSolRecojoCarga.sdireccion
        End If
        If IsDBNull(ModSolRecojoCarga.idcontacto) = True Or ModSolRecojoCarga.idcontacto < 1 Then
            recuperacontacto()
        Else
            ' Recuperar el contacto 
            txtidcontacto.Text = ModSolRecojoCarga.idcontacto
            txtcontacto.Text = ModSolRecojoCarga.scontacto
        End If
        'Recupera el contacto 
        'recuperacontacto()
    End Sub
    Private Sub recuperacontacto()
        gnrodcto = ModSolRecojoCarga.snrodcto
        gnombre = ModSolRecojoCarga.sapellidos_nombres
        'gnombre = ModSolRecojoCarga.snombre
        'gapepaterno = ModSolRecojoCarga.sapepaterno
        'gapematerno = ModSolRecojoCarga.sapematerno
        gidsucuenta = ModSolRecojoCarga.idsucuenta
        gidcargo = ModSolRecojoCarga.idcargo
        gigdtipdcto = ModSolRecojoCarga.idtipdcto
        gidsexo = ModSolRecojoCarga.idsexo
        ' Pintando el contacto  
        txtcontacto.Text = gapepaterno + " " + gapematerno + " " + gnombre
    End Sub
    Private Sub Txtdireccion_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtdireccion.Validated
        Dim a As New frmbuscacliente
        Dim cadbusqueda As String
        cadbusqueda = CType(UCase(Txtdireccion.Text), String)
        ModSolRecojoCarga.busquedapor = 1
        If cmbagencia.SelectedValue < 1 Then
            MessageBox.Show("Seleccionar agencia", "Recojo Pactado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbagencia.Focus()
            Exit Sub
        End If
        If asignaagencia() Then
            Txtdireccion.Text = ""
            Exit Sub
        End If
        '
        If txtCliente.Text = "" Then
            MessageBox.Show("Ingresar cliente", "Recojo Pactado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCliente.Focus()
            Exit Sub
        End If
        a.TextBox1.Text = ""
        'a.ShowDialog()

        Acceso.Asignar(a, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            a.ShowDialog()
        Else
            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Recuperar el direccion 
        If IsDBNull(ModSolRecojoCarga.iddireccion_consignado) = True Then
            recuperadireccion()
        Else
            txtiddireccion.Text = ModSolRecojoCarga.idireccion
            Txtdireccion.Text = ModSolRecojoCarga.sdireccion
            If IsDBNull(ModSolRecojoCarga.idcontacto) = True Or ModSolRecojoCarga.idireccion < 1 Then
                recuperacontacto()
            Else
                ' Recuperar el contacto 
                txtidcontacto.Text = ModSolRecojoCarga.idcontacto
                txtcontacto.Text = ModSolRecojoCarga.scontacto
            End If
        End If
    End Sub
    Private Sub txtcontacto_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcontacto.Validated
        Dim a As New frmbuscacliente
        Dim cadbusqueda As String
        cadbusqueda = CType(UCase(Txtdireccion.Text), String)
        ModSolRecojoCarga.busquedapor = 1
        If cmbagencia.SelectedValue < 1 Then
            MessageBox.Show("Seleccionar agencia", "Recojo Pactado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbagencia.Focus()
            Exit Sub
        End If
        ' Asignar la agencia con sus repectiva jerarquia  
        If asignaagencia() Then
            Exit Sub
        End If
        '
        If txtCliente.Text = "" Then
            MessageBox.Show("Ingresar cliente", "Recojo Pactado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCliente.Focus()
            Exit Sub
        End If
        If Txtdireccion.Text = "" Then
            MessageBox.Show("Ingresar direccion", "Recojo Pactado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Txtdireccion.Focus()
            Exit Sub
        End If
        a.TextBox1.Text = ""
        'a.ShowDialog()

        Acceso.Asignar(a, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            a.ShowDialog()
        Else
            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Recuperar el direccion 
        If IsDBNull(ModSolRecojoCarga.idcontacto) = True Then
            recuperacontacto()
        Else
            ' Recuperar el contacto 
            txtidcontacto.Text = ModSolRecojoCarga.idcontacto
            txtcontacto.Text = ModSolRecojoCarga.scontacto
        End If
    End Sub
    Private Sub btndireccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndireccion.Click
        Dim a As New frmbuscacliente
        Dim scadena As String
        '
        If cmbagencia.SelectedValue < 1 Then
            MessageBox.Show("Seleccionar agencia", "Recojo Pactado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbagencia.Focus()
            Exit Sub
        End If
        ' Asignar la agencia con sus repectiva jerarquia  
        asignaagencia()
        '
        If txtCliente.Text = "" Then
            MessageBox.Show("Ingresar cliente", "Recojo Pactado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCliente.Focus()
            Exit Sub
        End If
        ModSolRecojoCarga.busquedapor = 1
        ModSolRecojoCarga.idcliente = CType(txtidcliente.Text, Integer)
        If Txtdireccion.Text = "" Then
            scadena = ""
        Else
            scadena = Txtdireccion.Text
        End If
        a.TextBox1.Text = scadena
        'a.ShowDialog()

        Acceso.Asignar(a, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            a.ShowDialog()
        Else
            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If IsDBNull(ModSolRecojoCarga.sdireccion) = True Then
            recuperadireccion()
        Else
            txtiddireccion.Text = ModSolRecojoCarga.idireccion
            Txtdireccion.Text = ModSolRecojoCarga.sdireccion
            If IsDBNull(ModSolRecojoCarga.idcontacto) = True Then
                recuperacontacto()
            Else
                ' Recuperar el contacto 
                txtidcontacto.Text = ModSolRecojoCarga.idcontacto
                txtcontacto.Text = ModSolRecojoCarga.scontacto
            End If
        End If
    End Sub
    Private Sub btncontacto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncontacto.Click
        Dim a As New frmbuscacliente
        '       Dim scadena As String
        '
        If cmbagencia.SelectedValue < 1 Then
            MessageBox.Show("Seleccionar agencia", "Recojo Pactado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbagencia.Focus()
            Exit Sub
        End If
        ' Asignar la agencia con sus repectiva jerarquia  
        asignaagencia()
        '
        If txtCliente.Text = "" Then
            MessageBox.Show("Ingresar cliente", "Recojo Pactado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCliente.Focus()
            Exit Sub
        End If
        If Txtdireccion.Text = "" Then
            MessageBox.Show("Ingresar direccion", "Recojo Pactado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Txtdireccion.Focus()
            Exit Sub
        End If
        ModSolRecojoCarga.busquedapor = 1
        ModSolRecojoCarga.idcliente = txtidcliente.Text
        ModSolRecojoCarga.iddireccion_consignado = txtiddireccion.Text
        a.TextBox1.Text = ""
        'a.ShowDialog()
        Acceso.Asignar(a, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            a.ShowDialog()
        Else
            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If IsDBNull(ModSolRecojoCarga.scontacto) = True Then
            recuperacontacto()
        Else
            ' Recuperar el contacto 
            txtidcontacto.Text = ModSolRecojoCarga.idcontacto
            txtcontacto.Text = ModSolRecojoCarga.scontacto
        End If
    End Sub
    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        Dim claseeliminar As New dtorecojopactadodet
        Dim dgvrow As DataGridViewRow 'Recuperando la nueva fila
        Dim liidentrega_recojo_dia_hora As Integer
        'Dim rsteliminar As New ADODB.Recordset
        Dim dteliminar As New DataTable
        Try
            If DGVdiarecojo.Rows.Count < 1 Then
                Exit Sub
            End If
            dgvrow = Me.DGVdiarecojo.CurrentRow()
            If IsDBNull(dgvrow.Cells(1).Value) = False Then
                liidentrega_recojo_dia_hora = CType(dgvrow.Cells(1).Value, Integer)
                claseeliminar.identrega_recojo_dia_hora = liidentrega_recojo_dia_hora
                claseeliminar.idusuario_personal = dtoUSUARIOS.IdLogin
                claseeliminar.idrol_usuario = dtoUSUARIOS.IdRol
                claseeliminar.ip = dtoUSUARIOS.IP
                '
                'datahelper
                'rsteliminar = claseeliminar.Eliminarrecojoacordadodetalle()
                'odda4.Fill(dteliminar, rsteliminar)
                dteliminar = claseeliminar.Eliminarrecojoacordadodetalle()
                If CType(dteliminar.Rows(0).Item(0), Integer) <> 0 Then
                    MessageBox.Show("Descripción: " & CType(dteliminar.Rows(0).Item(1), String), "ORACLE -> Error: " & CType(dteliminar.Rows(0).Item(0), String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Descripción: " & CType(dteliminar.Rows(0).Item(1), String), "GRABANDO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
            dvrecojoacordadodia.Delete(dgvrow.Index)
            '
        Catch exp As Exception
            MessageBox.Show(exp.Message, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub DGVdiarecojo_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DGVdiarecojo.CellBeginEdit
        'Por defaul se va activar el día 

    End Sub
    'Private Sub TreeLista_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeLista.AfterSelect
    '    'Dim nivel As Integer
    '    'nivel = e.Node().Level
    '    'Select Case nivel
    '    '    Case 0  'Invocando a todas las agencias 
    '    'dvrecojoacordado.RowFilter = "" 
    '    '   Case 1  'Selecciona la agencia que se encuentra ubicada 
    '    idagencia = CType(dtAgencia.Rows(0).Item(2), Integer)
    '    'iddepartamento = e.Node().Tag   ' Valor primario  
    '    dvrecojoacordado.RowFilter = "idagencia = " & idagencia
    '    'End Select
    '    'TreeLista.BeginUpdate()
    '    'ActualizarCheck(e.Node, e.Node.Checked)
    '    'TreeLista.EndUpdate()
    'End Sub

    'Sub prueba()
    '    ' Dim date_info As DateTimeFormatInfo = CultureInfo.CurrentCulture.DateTimeFormat()
    'End Sub
    'Private Sub DGVdiarecojo_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGVdiarecojo.CellFormatting
    '    Select Case e.ColumnIndex
    '        Case 2
    '            Dim date_info As DateTimeFormatInfo = CultureInfo.CurrentCulture.DateTimeFormat()

    '    End Select
    'End Sub
    'Private Sub DGVdiarecojo_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVdiarecojo.CellEndEdit
    '    Dim valor As String
    '    Dim date_info As DateTimeFormatInfo = CultureInfo.CurrentCulture.DateTimeFormat()
    '    Select Case e.ColumnIndex
    '        Case 2
    '            Try
    '                valor = DGVdiarecojo.Rows(e.RowIndex).Cells(2).Value
    '                valor = date_info.TimeSeparator
    '                ' DGVdiarecojo.Rows(e.RowIndex).Cells(2).Value = 

    '            Catch exp As Exception
    '                MessageBox.Show(exp.Message, "Seguridad del Sistema")
    '            End Try
    '    End Select
    'End Sub
    Private Sub DGVdiarecojo_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVdiarecojo.CellEndEdit
        Dim shora As String
        Dim dhora, dhora_inicio As Date
        Select Case e.ColumnIndex
            Case 2
                shora = CType(DGVdiarecojo.Rows(e.RowIndex).Cells(2).Value, String)
                shora = validar_hora(shora)
                If shora = "" Then
                    DGVdiarecojo.Rows(e.RowIndex).Cells(2).Value = shora
                    DGVdiarecojo.Columns(2).Selected = True
                    DGVdiarecojo.CurrentCell = DGVdiarecojo.Rows(e.RowIndex).Cells(2)
                    Exit Sub
                End If
                DGVdiarecojo.Rows(e.RowIndex).Cells(2).Value = shora
            Case 3
                shora = CType(DGVdiarecojo.Rows(e.RowIndex).Cells(3).Value, String)
                shora = validar_hora(shora)
                If shora = "" Then
                    DGVdiarecojo.Rows(e.RowIndex).Cells(3).Value = shora
                    Exit Sub
                End If
                Try
                    dhora = CType(shora, Date)
                    dhora_inicio = CType(DGVdiarecojo.Rows(e.RowIndex).Cells(2).Value, Date)
                    If dhora < dhora_inicio Then
                        MessageBox.Show("La hora cierre debe ser mayor a la hora listo ")
                        DGVdiarecojo.Rows(e.RowIndex).Cells(3).Value = ""
                        Exit Sub
                    End If
                Catch ex As Exception
                    shora = ""
                End Try
                DGVdiarecojo.Rows(e.RowIndex).Cells(3).Value = shora
        End Select
    End Sub
    Private Sub TxtBusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBusca.TextChanged
        Dvrecojopactado.RowFilter = "trim(razon_social) like '%" & Trim(TxtBusca.Text) & "%'"
    End Sub

    Private Sub Frmrecojopactado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    'Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem1.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem1.EnabledChanged, CancelarToolStripMenuItem.EnabledChanged, GrabarToolStripMenuItem.EnabledChanged
    '    If bIngreso Then
    '        Acceso.VerificaCambio(sender, e)
    '    End If
    'End Sub
End Class