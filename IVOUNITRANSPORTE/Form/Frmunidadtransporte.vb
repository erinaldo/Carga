'Imports System
'Imports System.Data
'Imports System.Data.OleDb
'Imports System.Windows.Forms
'Imports System.Text.RegularExpressions
'Imports System.Drawing
'Imports System.IO
'Imports ADOSERVERLib
Public Class Frmunidadtransporte
    Inherits FrmPlantillaunidadtransporte
    'Asociando las clases 
    Dim Claseunitransporte As New dtounitransporte
#Region " DECLARACION VARIABLES "
    'Declarando el usuario 
    Dim usuario As Integer
    'Declaracion de Recordset
    'datahelper
    'Dim rstAgencia, rstunitransporte, rstresponsable, rsttipounidad, rstcontrol, rstmodelo As ADODB.Recordset
    Dim rstAgencia, rstunitransporte, rstresponsable, rsttipounidad, rstcontrol, rstmodelo As DataTable

    'datahelper
    'Dim rsttipo_servicio As New ADODB.Recordset
    Dim rsttipo_servicio As DataTable

    'Declaracion de Data Adapters
    'Dim dr4 As New OleDb.OleDbDataAdapter
    'Declaracion de DataTables
    Dim dtAgencia, dtunitransporte, dtresponsable, dttipounidad, dtmodelo As New System.Data.DataTable
    Dim dttipo_servicio As New DataTable
    Dim gmdtagencia As New DataTable
    Dim dttipounitransClon As New DataTable
    ' Datatables  para tipo unidad y tipo modelo 
    Private dttipounidad_creado As New System.Data.DataTable
    Private dvtipounidad_creado As New DataView
    Private dvtipo_servicio As New DataView
    '
    ' Declarando Data View 
    Dim dvAgencia, dvunitransporte, dvtipounidad, dvmodelo, dvresponsable As New DataView
    Dim dvtipounidadclon As New DataView
    Dim gmdvagencia As New DataView
    'Declarando Data row View 
    Dim drvAgencia, drvunitransporte As DataRowView
    'Declarando variables independientes
    Dim control As Integer = 0
    Dim control_det As Integer = 0
    Dim dtageasociavirtual As New System.Data.DataTable("DETALLE")
    Dim dsagenciasociavirtual As New DataSet
    Dim idunidadtransporte As Integer
    Dim iniciando As Boolean
    Dim bIngreso As Boolean
    Public hnd As Long
#End Region
#Region "Eventos"

    Private Sub Frmunidadtransporte_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub Frmunidadtransporte_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub Frmunidadtransporte_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            LabeloSCAR.Visible = False
            ShadowLabel1.Text = "Mantenimiento Unidad Transporte"
            MenuTab.Items(0).Text = "Unidad Transporte"
            MenuTab.Items(1).Text = "Mantenimiento"
            MenuTab.Items(0).Enabled = False
            '
            CancelarToolStripMenuItem.Visible = False
            CancelarToolStripMenuItem.Enabled = True
            '
            iniciando = True
            ' Recuperando el combo a la agencia  
            usuario = dtoUSUARIOS.IdLogin


            'Se debe llenar el àrbol  con las agencias y aplicarlo a la grilla 
            Dim ds As DataSet = Claseunitransporte.getunidadtransporte
            rstAgencia = ds.Tables(0)
            rstunitransporte = ds.Tables(1)
            rstresponsable = ds.Tables(2)
            rsttipounidad = ds.Tables(3)
            rstmodelo = ds.Tables(4)
            rsttipo_servicio = ds.Tables(5)
            ' Llena las agencias  
            ModuUtil.LlenarTreeCtrl(rstAgencia, Me.TreeLista, "Agencias")
            Me.TreeLista.ExpandAll()
            'Verifica si existe un error 
            dtAgencia = rstAgencia
            dvAgencia = dtAgencia.DefaultView
            dvAgencia.AllowNew = True
            'Recuperando todos los record set 
            dtunitransporte = rstunitransporte
            dvunitransporte = dtunitransporte.DefaultView
            '
            dtresponsable = rstresponsable
            dvresponsable = dtresponsable.DefaultView
            '
            dttipounidad = rsttipounidad
            dvtipounidad = dttipounidad.DefaultView

            ' Copy el data table  
            dttipounitransClon = dttipounidad.Copy
            dvtipounidadclon = dttipounitransClon.DefaultView
            '            
            dtmodelo = rstmodelo
            dvmodelo = dtmodelo.DefaultView
            dttipo_servicio = rsttipo_servicio
            '
            dvtipo_servicio = CargarCombo(Me.cmbtipo_servicio, dttipo_servicio, "tipo_servicio", "idtipo_servicio", -666)  ' Por defecto 0 No debe aparecer nada 

            'datahelper
            ''Se debe llenar el àrbol  con las agencias y aplicarlo a la grilla 
            'rstAgencia = Claseunitransporte.getunidadtransporte
            'rstunitransporte = rstAgencia.NextRecordset
            'rstresponsable = rstAgencia.NextRecordset
            'rsttipounidad = rstAgencia.NextRecordset
            'rstmodelo = rstAgencia.NextRecordset
            'rsttipo_servicio = rstAgencia.NextRecordset
            'rstAgencia.MoveFirst()
            '' Llena las agencias  
            'ModuUtil.LlenarTreeCtrl(rstAgencia, Me.TreeLista, "Agencias")
            'Me.TreeLista.ExpandAll()
            ''Verifica si existe un error 
            'dr4.Fill(dtAgencia, rstAgencia)
            'dvAgencia = dtAgencia.DefaultView
            'dvAgencia.AllowNew = True
            ''Recuperando todos los record set 
            'dr4.Fill(dtunitransporte, rstunitransporte)
            'dvunitransporte = dtunitransporte.DefaultView
            ''
            'dr4.Fill(dtresponsable, rstresponsable)
            'dvresponsable = dtresponsable.DefaultView
            ''
            'dr4.Fill(dttipounidad, rsttipounidad)
            'dvtipounidad = dttipounidad.DefaultView

            '' Copy el data table  
            'dttipounitransClon = dttipounidad.Copy
            'dvtipounidadclon = dttipounitransClon.DefaultView
            ''            
            'dr4.Fill(dtmodelo, rstmodelo)
            'dvmodelo = dtmodelo.DefaultView
            'dr4.Fill(dttipo_servicio, rsttipo_servicio)
            ''
            'dvtipo_servicio = CargarCombo(Me.cmbtipo_servicio, dttipo_servicio, "tipo_servicio", "idtipo_servicio", -666)  ' Por defecto 0 No debe aparecer nada 


            '                        
            'Carga lo combox 
            ''Llenamos los Combos Responsable
            CmbResponsable.DataSource = dtresponsable.DefaultView
            CmbResponsable.DisplayMember = "NOMBRES"
            CmbResponsable.ValueMember = "IDUSUARIO_PERSONAL"

            'Tipo de unidad 
            CmbTipounidad.DataSource = dttipounidad.DefaultView
            CmbTipounidad.DisplayMember = "TIPO_UNIDAD_TRANSPORTE"
            CmbTipounidad.ValueMember = "IDTIPO_UNIDAD_TRANSPORTE"
            'Modelo de unidad 
            cmbmodelo.DataSource = dtmodelo.DefaultView
            cmbmodelo.DisplayMember = "MODELO_MOVIL"
            cmbmodelo.ValueMember = "IDMODELO_MOVIL"

            ''Modelo de unidad 
            Cmbtipounidadm.DataSource = dttipounitransClon.DefaultView
            Cmbtipounidadm.DisplayMember = "TIPO_UNIDAD_TRANSPORTE"
            Cmbtipounidadm.ValueMember = "IDTIPO_UNIDAD_TRANSPORTE"

            GrillaMante()
            'Inicializando los valores
            CmbResponsable.SelectedIndex = -1
            CmbTipounidad.SelectedIndex = -1
            cmbmodelo.SelectedIndex = -1
            Cmbtipounidadm.SelectedIndex = -1
            ' 
            Grilla_asocia_agencia()
            iniciando = False

            bIngreso = False
            Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Asignando él valor ")
        End Try
    End Sub
    Private Sub btnAgregaagencia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregaagencia.Click
        ''Invocar a la ventana de formularios para agregar las agencias ... 
        'Dim a As New Frmagenciaasociar ' Creando una variable  
        'a.ShowDialog()
        Dim a As New Frmagenciaasociar ' Creando una variable  
        Dim resultado As DialogResult
        Dim filaadd, filas As New Integer
        If Txtidunitransporte.Text = Nothing Then
            Modunitransporte.idunidadtrans = -666
        Else
            Modunitransporte.idunidadtrans = CType(Txtidunitransporte.Text, Integer)
        End If
        'resultado = a.ShowDialog()
        Acceso.Asignar(a, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = a.ShowDialog()
        Else
            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim mydv As New DataView
        Dim nuevarow As DataGridViewRow
        '    Dim refila As Integer
        '
        Try
            'mydataview
            mydv = a.dvseleccionado
            If DGVAsociaagencia.Rows.Count > 0 Then
                filas = mydv.Table.Rows.Count - 1
                For filaadd = 0 To filas
                    'refila = DGVAsociaagencia.Rows.Add()
                    '        refila = DGVAsociaagencia.Row
                    nuevarow = Me.DGVAsociaagencia.CurrentRow()
                    nuevarow.Cells(1).Value = mydv.Table.Rows(filaadd).Item(3)  ' Nombre de agencia 
                    nuevarow.Cells(2).Value = mydv.Table.Rows(filaadd).Item(4)  ' Idagencia 
                Next
            Else
                DGVAsociaagencia.DataSource = mydv
            End If
        Catch exp As Exception
            MessageBox.Show(exp.Message, "Seguridad del Sistema")
        End Try
        'configurar las columnas


        '    Dim tbasocia As New DataGridViewCheckBoxColumn
        '    With tbasocia  '0
        '        .HeaderText = "Principal"
        '        .Name = "ACTUAL"
        '        .DataPropertyName = "ACTUAL"
        '        .Width = 62
        '        .ThreeState = False
        '        .TrueValue = 1   'Asociar  
        '        .FalseValue = 0
        '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        '        .Visible = True
        '    End With
        '    DGVAsociaagencia.Columns.Add(tbasocia)
        '    '
        '    Dim dgvtagencia As New DataGridViewTextBoxColumn
        '    With dgvtagencia '1
        '        .DataPropertyName = "nombre_agencia"
        '        .HeaderText = "Agencia"
        '        '.DefaultCellStyle.BackColor = SystemColors.Info
        '        .ReadOnly = True
        '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        '    End With
        '    DGVAsociaagencia.Columns.Add(dgvtagencia)
        '    '
        '    Dim tbidagencia As New DataGridViewTextBoxColumn
        '    With tbidagencia  '2
        '        .DataPropertyName = "idagencias"
        '        .HeaderText = "id agencias"
        '        .DefaultCellStyle.BackColor = SystemColors.Info
        '        .ReadOnly = True
        '        .Visible = False
        '    End With
        '    ' 
        '    DGVAsociaagencia.Columns.Add(tbidagencia)
        '    Dim diagencia_und_trans As New DataGridViewTextBoxColumn
        '    With diagencia_und_trans  '3
        '        .DataPropertyName = "idagencia_unidad_transporte"
        '        .Name = "idagencia_unidad_transporte"
        '        .HeaderText = "id Agencia Unidad transporte"
        '        .DefaultCellStyle.BackColor = SystemColors.Info
        '        .ReadOnly = True
        '        .Visible = False
        '    End With
        '    DGVAsociaagencia.Columns.Add(diagencia_und_trans)
    End Sub
    Private Sub btnbus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbus.Click
        MsgBox("Por implementarse ...")
    End Sub
#End Region
#Region "Funciones"
    Sub GrillaMante()
        Dim gmdtruta As New System.Data.DataTable
        Dim gmdvruta As New DataView
        'Configurando la grilla 
        Try
            DataGridViewPlt.Columns.Clear()
            With DataGridViewPlt
                .AutoGenerateColumns = False 'Las filas no se generen automaticamente de la bd
                ' Creando el data source - Omendoza (Falta recupera el data source)                
                .BackColor = SystemColors.Info
                .BackgroundColor = SystemColors.Info
                .RowHeadersVisible = False
                .BorderStyle = BorderStyle.Fixed3D
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = False
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                '

                .DataSource = dvunitransporte
                .Refresh()
                .RefreshEdit()
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End With
            'Configura los campos
            Dim tbnrounidad_transporte As New DataGridViewTextBoxColumn
            With tbnrounidad_transporte   '0
                .DataPropertyName = "nro_unidad_transporte"
                .Name = "nro_unidad_transporte"
                .HeaderText = "Nº Unidad "
                '.DefaultCellStyle.BackColor = SystemColors.Info
                .ReadOnly = True
            End With
            DataGridViewPlt.Columns.Add(tbnrounidad_transporte)

            Dim tbidunidad_transporte As New DataGridViewTextBoxColumn
            With tbidunidad_transporte '1
                .DataPropertyName = "idunidad_transporte"
                .Name = "idunidad_transporte"
                .HeaderText = "código unidad transporte"
                .DefaultCellStyle.BackColor = SystemColors.Info
                .ReadOnly = True
                .Visible = False
            End With
            DataGridViewPlt.Columns.Add(tbidunidad_transporte)

            Dim tbplaca As New DataGridViewTextBoxColumn
            With tbplaca  '2
                .DataPropertyName = "placa"
                .HeaderText = "Placa"
                .Name = "placa"
                '.DefaultCellStyle.BackColor = SystemColors.Info
                .ReadOnly = True
            End With
            DataGridViewPlt.Columns.Add(tbplaca)

            Dim tbcapacidad As New DataGridViewTextBoxColumn
            With tbcapacidad
                .DataPropertyName = "capacidad"
                .HeaderText = "Capacidad"
                .Name = "capacidad"
                '.DefaultCellStyle.BackColor = SystemColors.Info
                .ReadOnly = True
            End With
            DataGridViewPlt.Columns.Add(tbcapacidad)

            Dim tbnroejes As New DataGridViewTextBoxColumn
            With tbnroejes
                .DataPropertyName = "nro_ejes"
                .HeaderText = "Nº Ejes"
                .Name = "nro_ejes"
                '.DefaultCellStyle.BackColor = SystemColors.Info
                .ReadOnly = True
            End With
            DataGridViewPlt.Columns.Add(tbnroejes)

            Dim tbnropisos As New DataGridViewTextBoxColumn
            With tbnropisos
                .DataPropertyName = "nro_pisos"
                .HeaderText = "Nº pisos"
                .Name = "nro_pisos"
                '.DefaultCellStyle.BackColor = SystemColors.Info
                .ReadOnly = True
                .Visible = False
            End With
            DataGridViewPlt.Columns.Add(tbnropisos)

            Dim tbnrotv As New DataGridViewTextBoxColumn
            With tbnrotv
                .DataPropertyName = "nro_televisores"
                .HeaderText = "Nº tv"
                .Name = "nro_televisores"
                '.DefaultCellStyle.BackColor = SystemColors.Info
                .ReadOnly = True
                .Visible = False
            End With
            DataGridViewPlt.Columns.Add(tbnrotv)
            '
            Dim tbnro_banios As New DataGridViewTextBoxColumn
            With tbnro_banios
                .DataPropertyName = "nro_banios"
                .HeaderText = "Nº Baños"
                .Name = "nro_banios"
                '.DefaultCellStyle.BackColor = SystemColors.Info
                .ReadOnly = True
                .Visible = False
            End With
            DataGridViewPlt.Columns.Add(tbnro_banios)
            '
            Dim tbpesovehiculotoneladas As New DataGridViewTextBoxColumn
            With tbpesovehiculotoneladas
                .DataPropertyName = "peso_vehiculo_toneladas"
                .HeaderText = "Peso vehículo"
                .Name = "peso_vehiculo_toneladas"
                '.DefaultCellStyle.BackColor = SystemColors.Info
                .ReadOnly = True
                .Visible = False
            End With
            DataGridViewPlt.Columns.Add(tbpesovehiculotoneladas)
            '
            Dim tbrepsonsable As New DataGridViewTextBoxColumn
            With tbrepsonsable
                .DataPropertyName = "idresponsable"
                .HeaderText = "idresponsable"
                .Name = "idresponsable"
                '.DefaultCellStyle.BackColor = SystemColors.Info
                .ReadOnly = True
                .Visible = False
            End With
            DataGridViewPlt.Columns.Add(tbrepsonsable)
            '
            Dim tbtipounidad As New DataGridViewTextBoxColumn
            With tbtipounidad
                .DataPropertyName = "idtipo_unidad_transporte"
                .HeaderText = "Tipo unidad"
                .Name = "idtipo_unidad_transporte"
                '.DefaultCellStyle.BackColor = SystemColors.Info
                .ReadOnly = True
                .Visible = False
            End With
            DataGridViewPlt.Columns.Add(tbtipounidad)
            '
            Dim tbmodelo As New DataGridViewTextBoxColumn
            With tbmodelo
                .DataPropertyName = "idmodelo_unidad "
                .HeaderText = "Modelo"
                .Name = "idmodelo_unidad "
                '.DefaultCellStyle.BackColor = SystemColors.Info
                .ReadOnly = True
                .Visible = False
            End With
            DataGridViewPlt.Columns.Add(tbmodelo)
            '
            Dim tbpesomaximocargakg As New DataGridViewTextBoxColumn
            With tbpesomaximocargakg
                .DataPropertyName = "peso_maximo_carga_kg"
                .HeaderText = "Max. Carga (kg)"
                '.DefaultCellStyle.BackColor = SystemColors.Info
                .ReadOnly = True
            End With
            DataGridViewPlt.Columns.Add(tbpesomaximocargakg)
            '
            '
            Dim tcertifica_habilita_veh As New DataGridViewTextBoxColumn
            With tcertifica_habilita_veh
                .DataPropertyName = "certifica_habilita_veh"
                .Name = "certifica_habilita_veh"
                .HeaderText = "Cert. Habilitación vehicular"
                '.DefaultCellStyle.BackColor = SystemColors.Info
                .ReadOnly = True
                .Visible = False
            End With
            DataGridViewPlt.Columns.Add(tcertifica_habilita_veh)

            Dim simulado As New DataGridViewTextBoxColumn
            With simulado
                .DataPropertyName = "simulado"
                .Name = "simulado"
                .HeaderText = "Simulado"
                '.DefaultCellStyle.BackColor = SystemColors.Info
                .ReadOnly = True
                .Visible = True
            End With
            DataGridViewPlt.Columns.Add(simulado)

            Dim recojo As New DataGridViewTextBoxColumn
            With recojo
                .DataPropertyName = "recojo"
                .Name = "recojo"
                .HeaderText = "recojo"
                '.DefaultCellStyle.BackColor = SystemColors.Info
                .ReadOnly = True
                .Visible = False
            End With
            DataGridViewPlt.Columns.Add(recojo)

        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Asignando él valor ")
        End Try
    End Sub
    Private Sub Grilla_asocia_agencia()
        'Configurando la grilla, sin asociarle un dataview  - Omendoza 
        'DGVAsociaagencia.DataSource = mydv
        'configurar da
        DGVAsociaagencia.Columns.Clear()
        With DGVAsociaagencia
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
            '.DataSource = mydv
        End With
        '
        Dim tbasocia As New DataGridViewCheckBoxColumn
        With tbasocia   '0
            .HeaderText = "Asocia"
            .Name = "ACTUAL"
            .DataPropertyName = "ACTUAL"
            .Width = 62
            .ThreeState = False
            .TrueValue = 1   'Asociar  
            .FalseValue = 0
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Visible = True
        End With
        DGVAsociaagencia.Columns.Add(tbasocia)
        '
        Dim dgvtagencia As New DataGridViewTextBoxColumn
        With dgvtagencia  '1
            .DataPropertyName = "nombre_agencia"
            .HeaderText = "Agencia"
            '.DefaultCellStyle.BackColor = SystemColors.Info
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DGVAsociaagencia.Columns.Add(dgvtagencia)

        Dim tbidagencia As New DataGridViewTextBoxColumn
        With tbidagencia   '2
            .DataPropertyName = "idagencias"
            .HeaderText = "id agencias"
            .DefaultCellStyle.BackColor = SystemColors.Info
            .ReadOnly = True
            .Visible = False
        End With
        DGVAsociaagencia.Columns.Add(tbidagencia)
        '
        Dim tbidageundtransp As New DataGridViewTextBoxColumn
        With tbidageundtransp   '3
            .DataPropertyName = "idagencia_unidad_transporte"
            .HeaderText = "ID agencia-transporte"
            .DefaultCellStyle.BackColor = SystemColors.Info
            .ReadOnly = True
            .Visible = False
        End With
        DGVAsociaagencia.Columns.Add(tbidageundtransp)
    End Sub
    Sub Grabar_agencia_asociadas()
        Dim fila, filas As Integer
        Dim MyClassUndidad As New dtounitransporte
        'datahelper
        'Dim rsmensaje, rsdatos As ADODB.Recordset
        Dim rsmensaje, rsdatos As DataTable
        Try
            'Verifica que no exista las agencias 
            filas = DGVAsociaagencia.RowCount - 1
            'Obtiene la agencia  
            MyClassUndidad.unitransporte = CType(Txtidunitransporte.Text, Integer)
            For fila = 0 To filas
                If IsDBNull(DGVAsociaagencia.Rows(fila).Cells(3).Value) Then
                    control_det = 1
                    MyClassUndidad.agencia_unidad_transporte = -666
                Else
                    control_det = 0
                    MyClassUndidad.agencia_unidad_transporte = CType(DGVAsociaagencia.Rows(fila).Cells(3).Value, Integer)
                End If
                MyClassUndidad.control = control_det
                '
                'If control_det = 1 Then 'Si es uno es de insercion y se tiene que pasar como nulo 
                '    MyClassUndidad.agencia_unidad_transporte = -666
                'Else
                '    MyClassUndidad.agencia_unidad_transporte = CType(DGVAsociaagencia.Rows(fila).Cells(3).Value, Integer)
                'End If
                '
                MyClassUndidad.actual = CType(DGVAsociaagencia.Rows(fila).Cells(0).Value, Integer)
                MyClassUndidad.agencia = CType(DGVAsociaagencia.Rows(fila).Cells(2).Value, Integer)
                '
                MyClassUndidad.usuario_personal = dtoUSUARIOS.IdLogin
                MyClassUndidad.rolusuario = dtoUSUARIOS.IdRol
                MyClassUndidad.ip = dtoUSUARIOS.IP
                MyClassUndidad.estado_registro = 1 'Por ahora estara activo omendoza --> Proceso                 
                'Grabar tipo de servicio 
                MyClassUndidad.idtipo_servicio = CType(Me.cmbtipo_servicio.SelectedValue, Long)
                ' 

                Dim respOracle As DataTable
                Dim ds As DataSet = MyClassUndidad.actualizaagencia_unidadtransporte()
                rsmensaje = ds.Tables(0)
                ' Recupera el mensaje 
                rsdatos = ds.Tables(1)
                respOracle = ds.Tables(2)
                Try
                    If respOracle.Rows.Count = 0 Then
                        ' Recupera el id de la unidad de transporte
                        If rsdatos.Rows.Count > 0 Then
                            'Repera la actualizacion 
                        End If
                    Else
                        If IsDBNull(respOracle.Rows(0).Item(0)) = False Then
                            MessageBox.Show("Descripción: " & CType(respOracle.Rows(0).Item(1), String), "ORACLE -> Error: " & CType(respOracle.Rows(0).Item(0), String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If
                    End If
                Catch exp As Exception
                    MessageBox.Show(exp.Message, "Seguridad del Sistema")
                End Try

                'datahelper
                'Dim respOracle As ADODB.Recordset
                'rsmensaje = MyClassUndidad.actualizaagencia_unidadtransporte()
                '' Recupera el mensaje 
                'rsdatos = rsmensaje.NextRecordset()
                'respOracle = rsmensaje.NextRecordset()
                'Try
                '    If respOracle.Fields.Count = 0 Then
                '        ' Recupera el id de la unidad de transporte
                '        If rsdatos.Fields.Count > 0 Then
                '            'Repera la actualizacion 
                '        End If
                '    Else
                '        If CType(respOracle.Fields(0).Value, Integer) <> 0 Then
                '            MessageBox.Show("Descripción: " & CType(respOracle.Fields(1).Value, String), "ORACLE -> Error: " & CType(respOracle.Fields(0).Value, String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                '            Return
                '        End If
                '    End If
                'Catch exp As Exception
                '    MessageBox.Show(exp.Message, "Seguridad del Sistema")
                'End Try
            Next
        Catch qex As Exception
            MessageBox.Show(qex.Message, "Seguridad del Sistema")
        End Try
    End Sub
#End Region
#Region "Eventos de control "
    Private Sub Frmunidadtransporte_MenuNuevo() Handles Me.MenuNuevo
        Try
            Me.SelectMenu(1)
            MenuTab.Items(0).Enabled = False
            MenuTab.Items(1).Enabled = True
            MenuTab.Items(2).Enabled = True
            MenuTab.Items(3).Enabled = True
            MenuTab.Items(4).Enabled = True
            control = 1    ' Inserta 
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub Frmunidadtransporte_MenuEditar() Handles Me.MenuEditar
        control = 2 'Modo de edición 
        Dim filarow As Integer
        Dim DrvUndtransporte As DataRowView
        'datahelper
        'Dim rstAgenciatmp, rst_oracle As New ADODB.Recordset
        Dim rstAgenciatmp, rst_oracle As DataTable
        Dim myasociaagencia As New dtounitransporte
        'Dim myodda As New OleDb.OleDbDataAdapter
        Dim mydt As New DataTable
        Dim mydataview As New DataView
        '
        'Recupera los datos necesarios
        filarow = DataGridViewPlt.CurrentRow.Index
        If filarow >= 0 Then
            Try
                iniciando = True
                TabMante.SelectedIndex = 1 'Tabla de mantenimientos  
                DrvUndtransporte = dvunitransporte.Item(DataGridViewPlt.CurrentRow.Index)
                'MsgBox(DrvUndtransporte("idunidad_transporte").ToString)
                Txtidunitransporte.Text = DrvUndtransporte("idunidad_transporte").ToString
                TxtUnidad.Text = DrvUndtransporte("nro_unidad_transporte").ToString
                Txtplaca.Text = DrvUndtransporte("placa").ToString
                txtcapacidad.Text = DrvUndtransporte("capacidad").ToString
                txteje.Text = DrvUndtransporte("nro_ejes").ToString
                txtpisos.Text = DrvUndtransporte("nro_pisos").ToString
                txttv.Text = DrvUndtransporte("nro_televisores").ToString
                txtbanios.Text = DrvUndtransporte("nro_banios").ToString
                txtpesounidad.Text = DrvUndtransporte("peso_vehiculo_toneladas".ToString)
                txtcargamaxima.Text = DrvUndtransporte("peso_maximo_carga_kg".ToString)
                'chkSimulado.Checked = IIf(DrvUndtransporte("simulado") = 1, True, False)
                Me.chkRecojo.Checked = DrvUndtransporte("recojo") = 1
                '
                If IsDBNull(DrvUndtransporte("certifica_habilita_veh".ToString)) = False Then
                    Me.txtcerhabilitavehicular.Text = DrvUndtransporte("certifica_habilita_veh".ToString)
                Else
                    Me.txtcerhabilitavehicular.Text = ""
                End If
                If IsDBNull(DrvUndtransporte("idtipo_servicio".ToString)) = False Then
                    Me.cmbtipo_servicio.SelectedValue = CType(DrvUndtransporte("idtipo_servicio".ToString), Long)
                Else
                    Me.cmbtipo_servicio.SelectedValue = -666
                End If


                'Debe cargar los combos 
                CmbResponsable.SelectedValue = CType(DrvUndtransporte("idresponsable"), Integer)
                Cmbtipounidadm.SelectedValue = CType(DrvUndtransporte("idtipo_unidad_transporte"), Integer)
                cmbmodelo.SelectedValue = CType(DrvUndtransporte("idmodelo_unidad"), Integer)
                'Recupera el datagridview   
                myasociaagencia.unitransporte = CType(Txtidunitransporte.Text, Integer)
                '
                rstAgenciatmp = Nothing
                '
                'datahelper
                rstAgenciatmp = myasociaagencia.sp_getagencias_asociadas
                '
                'rst_oracle = rstAgencia.NextRecordset  'Omendoza 
                'If Not (rst_oracle Is Nothing) Then
                '    If rst_oracle.Fields.Count > 1 Then   'Verifica que no habido errror
                '        If CType(rst_oracle.Fields(0).Value, Integer) <> 0 Then
                '            MessageBox.Show("Descripción: " & CType(rst_oracle.Fields(1).Value, String), "ORACLE -> Error: " & CType(rst_oracle.Fields(0).Value, String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                '        End If
                '    End If
                'End If

                If rstAgenciatmp.Rows.Count > 0 Then
                    mydt = rstAgenciatmp
                    mydataview = mydt.DefaultView
                    With DGVAsociaagencia
                        .DataSource = mydataview
                    End With
                End If
                If rstAgenciatmp.Rows.Count <= 1 Then
                    control_det = 1
                Else
                    control_det = 0
                End If
                iniciando = False

                'datahelper
                'If rstAgenciatmp.Fields.Count > 0 Then
                '    myodda.Fill(mydt, rstAgenciatmp)
                '    mydataview = mydt.DefaultView
                '    With DGVAsociaagencia
                '        .DataSource = mydataview
                '    End With
                'End If
                'If rstAgenciatmp.RecordCount < 1 Then
                '    control_det = 1
                'Else
                '    control_det = 0
                'End If
                'iniciando = False
            Catch exp As Exception
                MessageBox.Show(exp.Message, "Seguridad del Sistema")
            End Try
        End If
    End Sub
    Private Sub Frmunidadtransporte_MenuGrabar() Handles Me.MenuGrabar
        Try
            ' Grabando valores - Valida que los valores  
            Dim MyObligatorios() As Object = {Me.TxtUnidad, Me.Txtplaca, Me.cmbtipo_servicio.SelectedValue, Me.btntipo_servicio}
            Dim MyClassUndidad As New dtounitransporte
            'datahelper
            'Dim rsmensaje, rsdatos As ADODB.Recordset
            Dim rsmensaje, rsdatos As DataTable
            '
            ' 
            If ModuUtilom.Validaciones(MyObligatorios) = 0 Then 'Si todo esta bien... (funcion comun x Richard)
                MyClassUndidad.control = control
                If IsDBNull(Txtidunitransporte.Text) Or Txtidunitransporte.Text = Nothing Or Txtidunitransporte.Text = "" Then
                    MyClassUndidad.unitransporte = -666
                Else
                    MyClassUndidad.unitransporte = Txtidunitransporte.Text
                End If
                MyClassUndidad.nrounitransporte = TxtUnidad.Text
                MyClassUndidad.placa = Txtplaca.Text
                'Recuperando los valores de los combos 
                MyClassUndidad.tipo_unidad_transporte = CType(Cmbtipounidadm.SelectedValue, Integer)
                MyClassUndidad.responsable = CType(CmbResponsable.SelectedValue, Integer)
                MyClassUndidad.modelo_unidad = CType(cmbmodelo.SelectedValue, Integer)
                '
                MyClassUndidad.peso_maximo_carga = IIf(txtcargamaxima.Text = "", 0.0, CType(txtcargamaxima.Text, Double))
                MyClassUndidad.peso_vehiculo_toneladas = CType(txtpesounidad.Text, Double)
                MyClassUndidad.capacidad = IIf(txtcapacidad.Text = "", 0, CType(txtcapacidad.Text, Integer))
                MyClassUndidad.nro_banios = IIf(txtbanios.Text = "", 0, CType(txtbanios.Text, Integer))
                MyClassUndidad.nro_ejes = IIf(txteje.Text = "", 0, CType(txteje.Text, Integer))
                MyClassUndidad.nro_televisores = IIf(txttv.Text = "", 0, CType(txttv.Text, Integer))
                ' Propio del sistema 
                MyClassUndidad.usuario_personal = dtoUSUARIOS.IdLogin
                MyClassUndidad.rolusuario = dtoUSUARIOS.IdRol
                MyClassUndidad.ip = dtoUSUARIOS.IP
                MyClassUndidad.estado_registro = 1 'Por ahora estara activo omendoza --> Proceso 
                If Me.txtcerhabilitavehicular.Text = "" Then
                    MyClassUndidad.certificadohabilitavehicular = "null"
                Else
                    MyClassUndidad.certificadohabilitavehicular = Me.txtcerhabilitavehicular.Text
                End If
                MyClassUndidad.idtipo_servicio = CType(Me.cmbtipo_servicio.SelectedValue, Long)
                'MyClassUndidad.Simulado = IIf(chkSimulado.Checked, 1, 0)

                MyClassUndidad.Recojo = IIf(Me.chkRecojo.Checked, 1, 0)

                Dim respOracle As DataTable
                Dim ds1 As DataSet = MyClassUndidad.actualizaunitransporte2()
                rsmensaje = ds1.Tables(0)
                ' Recupera el mensaje 
                rsdatos = ds1.Tables(1)
                respOracle = ds1.Tables(2)
                Try
                    If respOracle.Rows.Count = 0 Then
                        ' Recupera el id de la unidad de transporte
                        If rsdatos.Rows.Count > 0 Then
                            idunidadtransporte = rsdatos.Rows(0).Item(0)
                            Txtidunitransporte.Text = idunidadtransporte
                        End If
                        ' Guarda las agencias las agencias asociadas   
                        Grabar_agencia_asociadas()
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
                'rsmensaje = MyClassUndidad.actualizaunitransporte2()
                '' Recupera el mensaje 
                'rsdatos = rsmensaje.NextRecordset()
                'respOracle = rsmensaje.NextRecordset()
                'Try
                '    If respOracle.Fields.Count = 0 Then
                '        ' Recupera el id de la unidad de transporte
                '        If rsdatos.Fields.Count > 0 Then
                '            idunidadtransporte = rsdatos.Fields(0).Value
                '            Txtidunitransporte.Text = idunidadtransporte
                '        End If
                '        ' Guarda las agencias las agencias asociadas   
                '        Grabar_agencia_asociadas()
                '    Else
                '        If CType(respOracle.Fields(0).Value, Integer) <> 0 Then
                '            MessageBox.Show("Descripción: " & CType(respOracle.Fields(1).Value, String), "ORACLE -> Error: " & CType(respOracle.Fields(0).Value, String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                '        End If
                '    End If
                'Catch Qex As Exception
                '    MessageBox.Show(Qex.Message, "Seguridad del Sistema")
                'End Try
            End If
            rstunitransporte = Nothing
            'datahelper
            'rstunitransporte = New ADODB.Recordset
            dtunitransporte = Nothing
            dtunitransporte = New DataTable
            dvunitransporte = Nothing
            dvunitransporte = New DataView
            ' 
            rstunitransporte = MyClassUndidad.sp_refresca_unidad_movil
            'datahelper
            'dr4.Fill(dtunitransporte, rstunitransporte)
            dtunitransporte = rstunitransporte
            dvunitransporte = dtunitransporte.DefaultView
            'sp_refresca_unidad_movil
            limpia_datos()
            SelectMenu(0)

            'datahelper
            'rstAgencia = Claseunitransporte.getunidadtransporte
            'rstunitransporte = rstAgencia.NextRecordset
            'rstresponsable = rstAgencia.NextRecordset
            'rsttipounidad = rstAgencia.NextRecordset
            'rstmodelo = rstAgencia.NextRecordset
            'rsttipo_servicio = rstAgencia.NextRecordset
            Dim ds As DataSet = Claseunitransporte.getunidadtransporte
            rstAgencia = ds.Tables(0)
            rstunitransporte = ds.Tables(1)
            rstresponsable = ds.Tables(2)
            rsttipounidad = ds.Tables(3)
            rstmodelo = ds.Tables(4)
            rsttipo_servicio = ds.Tables(5)

            'Recuperando todos los record set 
            'datahelper
            'dr4.Fill(dtunitransporte, rstunitransporte)
            dtunitransporte = rstunitransporte
            dvunitransporte = dtunitransporte.DefaultView

            GrillaMante()
            SplitContainer2.Panel1Collapsed = False
            NuevoToolStripMenuItem1.Enabled = True
            EdicionToolStripMenuItem.Enabled = True
            CancelarToolStripMenuItem.Enabled = False
            CancelarToolStripMenuItem.Visible = False
            GrabarToolStripMenuItem.Enabled = False
            EliminarToolStripMenuItem.Enabled = True
            ExportarToolStripMenuItem.Enabled = True
            ImprimirToolStripMenuItem.Enabled = True
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
#End Region
    Private Sub DGVAsociaagencia_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVAsociaagencia.CellClick
        Dim dgvr As DataGridViewRow = Me.DGVAsociaagencia.CurrentRow()
        Dim filas, fila As Integer
        filas = DGVAsociaagencia.Rows.Count - 1
        If e.ColumnIndex = 0 Then
            For fila = 0 To filas
                If fila = dgvr.Index Then
                    DGVAsociaagencia.Rows(fila).Cells("ACTUAL").Value = 1
                Else
                    DGVAsociaagencia.Rows(fila).Cells("ACTUAL").Value = 0
                End If
            Next
        End If
    End Sub
    Private Sub Txtplaca_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtplaca.Validated
        Dim cadena As String
        Dim filas, fila As Integer
        'Dim dgrv As DataGridViewRow = DataGridViewPlt.CurrentRow
        If Not iniciando Then
            cadena = CType(Txtplaca.Text, String)
            filas = DataGridViewPlt.RowCount - 1
            For fila = 0 To filas
                If CType(DataGridViewPlt.Rows(fila).Cells(2).Value, String) = cadena Then
                    MessageBox.Show("La placa ya existe", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Txtplaca.Text = Nothing
                    Txtplaca.Focus()
                    Return
                End If
            Next
        End If
    End Sub
    Private Sub TxtUnidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUnidad.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub TxtUnidad_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtUnidad.Validated
        Dim cadena As String
        Dim filas, fila As Integer
        '
        If Not iniciando Then
            ' Dim dgrv As DataGridViewRow = DataGridViewPlt.CurrentRow
            cadena = CType(TxtUnidad.Text, String)
            filas = DataGridViewPlt.RowCount - 1
            For fila = 0 To filas
                If CType(DataGridViewPlt.Rows(fila).Cells(0).Value, String) = cadena Then
                    MessageBox.Show("La unidad de transporte ya existe", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtUnidad.Text = Nothing
                    TxtUnidad.Focus()
                    Return
                End If
            Next
        End If
    End Sub
    Private Sub txtcapacidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcapacidad.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub txteje_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txteje.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtpisos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpisos.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub txttv_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttv.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtbanios_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbanios.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtpesounidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpesounidad.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    'Private Sub txtcargamaxima_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcargamaxima.KeyPress
    '    Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
    '    KeyAscii = CShort(SoloNumeros(KeyAscii))
    '    If KeyAscii = 0 Then
    '        e.Handled = True
    '    End If
    'End Sub
    Private Sub txtpesounidad_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpesounidad.Validating
        Try
            txtpesounidad.Text = Format(Math.Round(Convert.ToDouble(txtpesounidad.Text), 2), "####0.00")
        Catch ex As Exception
            MsgBox("Error en el Formato de Ingreso", MsgBoxStyle.Critical, "General Error")
            txtpesounidad.Text = "0.00"
            txtpesounidad.Focus()
            Exit Sub
        End Try
    End Sub
    Private Sub txtcargamaxima_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtcargamaxima.Validating
        Try
            txtcargamaxima.Text = Format(Math.Round(Convert.ToDouble(txtcargamaxima.Text), 2), "####0.00")
        Catch ex As Exception
            MsgBox("Error en el Formato de Ingreso", MsgBoxStyle.Critical, "General Error")
            txtcargamaxima.Text = "0.00"
            txtcargamaxima.Focus()
            Exit Sub
        End Try
    End Sub
    'Private Sub TreeLista_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeLista.AfterSelect
    '    Dim idagencia As Integer
    '    Dim nivel As Integer
    '    Dim classunitransporte As New dtounitransporte
    '    Dim rstoracle As ADODB.Recordset
    '    '
    '    nivel = e.Node().Level
    '    rstAgencia = Nothing
    '    dtunitransporte.Clear()
    '    Select Case nivel
    '        Case 0  'Invocando a todas las agencias 
    '            classunitransporte.control = 1
    '            classunitransporte.agencia = -666
    '            rstunitransporte = classunitransporte.get_unidad_xagencia()

    '        Case 1  'Selecciona la agencia que se encuentra ubicada 
    '            classunitransporte.control = 0
    '            idagencia = e.Node().Tag   ' Valor primario  
    '            classunitransporte.agencia = idagencia
    '            rstunitransporte = classunitransporte.get_unidad_xagencia()
    '    End Select
    '    Try
    '        rstoracle = rstunitransporte.NextRecordset()
    '        If rstoracle.Fields.Count <> 0 Then
    '            If CType(rstoracle.Fields(0).Value, Integer) <> 0 Then
    '                MessageBox.Show("Descripción: " & CType(rstoracle.Fields(1).Value, String), "ORACLE -> Error: " & CType(rstoracle.Fields(0).Value, String), MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Return
    '            End If
    '        End If
    '        ' Actualiza los nuevo cambio 
    '        dr4.Fill(dtunitransporte, rstunitransporte)
    '        dvunitransporte = dtunitransporte.DefaultView
    '    Catch QEX As Exception
    '        MessageBox.Show(QEX.Message, "Seguridad del Sistema")
    '    End Try
    '    'TreeLista.BeginUpdate()
    '    'ActualizarCheck(e.Node, e.Node.Checked)
    '    'TreeLista.EndUpdate()
    'End Sub
    Private Sub Frmunidadtransporte_MenuCancelar() Handles Me.MenuCancelar
        SplitContainer2.Panel1Collapsed = False
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub
    Private Sub Btntipounidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btntipounidad.Click
        Try
            Modunitransporte.inumerocontrol = 0
            Dim FrmNuevotipounidadtransporte As Frmmantenimientosimpleunitrans = New Frmmantenimientosimpleunitrans
            'Dim resultado As DialogResult = FrmNuevotipounidadtransporte.ShowDialog()

            Dim resultado As DialogResult
            Acceso.Asignar(FrmNuevotipounidadtransporte, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                resultado = FrmNuevotipounidadtransporte.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If resultado = Windows.Forms.DialogResult.OK Then
                dttipounidad.Clear()
                dttipounidad = FrmNuevotipounidadtransporte.Nuevostipounidadtransporte.Copy
                Dim ElIngresadoEs As Integer = FrmNuevotipounidadtransporte.Ingresado
                dvtipounidad_creado = Funciones.CargarCombo(Cmbtipounidadm, dttipounidad, "tipo_unidad_transporte", "idtipo_unidad_transporte", ElIngresadoEs)
            End If
        Catch qex As Exception
            MessageBox.Show(qex.Message, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub btnmodelo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodelo.Click
        Try
            Modunitransporte.inumerocontrol = 1
            Dim FrmNuevotipounidadtransporte As Frmmantenimientosimpleunitrans = New Frmmantenimientosimpleunitrans
            'Dim resultado As DialogResult = FrmNuevotipounidadtransporte.ShowDialog()
            Dim resultado As DialogResult

            Acceso.Asignar(FrmNuevotipounidadtransporte, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                resultado = FrmNuevotipounidadtransporte.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            If resultado = Windows.Forms.DialogResult.OK Then
                dtmodelo.Clear()
                dtmodelo = FrmNuevotipounidadtransporte.Nuevosmodelomovil.Copy
                Dim ElIngresadoEs As Integer = FrmNuevotipounidadtransporte.Ingresado
                dvtipounidad_creado = Funciones.CargarCombo(cmbmodelo, dtmodelo, "MODELO_MOVIL", "IDMODELO_MOVIL", ElIngresadoEs)
            End If
        Catch qex As Exception
            MessageBox.Show(qex.Message, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub BTNeliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNeliminar.Click
        'Dim claseeliminar As New dtorecojopactadodet
        'Dim dgvrow As DataGridViewRow 'Recuperando la nueva fila
        'Dim liidentrega_recojo_dia_hora As Integer
        'Dim rsteliminar As New Recordset
        'Dim dteliminar As New DataTable
        ''dvunitransporte
        'Try
        '    If DataGridViewPlt.Rows.Count < 1 Then
        '        Exit Sub
        '    End If
        '    dgvrow = Me.DataGridViewPlt.CurrentRow()
        '    If IsDBNull(dgvrow.Cells(1).Value) = False Then
        '        liidentrega_recojo_dia_hora = CType(dgvrow.Cells(1).Value, Integer)
        '        claseeliminar.identrega_recojo_dia_hora = liidentrega_recojo_dia_hora
        '        claseeliminar.idusuario_personal = dtoUSUARIOS.IdLogin
        '        claseeliminar.idrol_usuario = dtoUSUARIOS.IdRol
        '        claseeliminar.ip = dtoUSUARIOS.IP
        '        '
        '        rsteliminar = claseeliminar.Eliminarrecojoacordadodetalle()
        '        dr4.Fill(dteliminar, rsteliminar)
        '        If CType(dteliminar.Rows(0).Item(0), Integer) <> 0 Then
        '            MessageBox.Show("Descripción: " & CType(dteliminar.Rows(0).Item(1), String), "ORACLE -> Error: " & CType(dteliminar.Rows(0).Item(0), String), MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Else
        '            MessageBox.Show("Descripción: " & CType(dteliminar.Rows(0).Item(1), String), "GRABANDO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        End If
        '    End If
        '    dvrecojoacordadodia.Delete(dgvrow.Index)
        '    '
        'Catch exp As Exception
        '    MessageBox.Show(exp.Message, "Seguridad del Sistema")
        'End Try
    End Sub
    Sub limpia_datos()
        Try        
            'MsgBox(DrvUndtransporte("idunidad_transporte").ToString)
            Txtidunitransporte.Text = ""
            TxtUnidad.Text = ""
            Txtplaca.Text = ""
            txtcapacidad.Text = ""
            txteje.Text = ""
            txtpisos.Text = ""
            txttv.Text = ""
            txtbanios.Text = ""
            txtpesounidad.Text = ""
            txtcargamaxima.Text = ""
            Me.txtcerhabilitavehicular.Text = ""
            Me.cmbtipo_servicio.SelectedValue = -666
            ''Debe cargar los combos 
            CmbResponsable.SelectedValue = -666
            Cmbtipounidadm.SelectedValue = -666
            cmbmodelo.SelectedValue = -666
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem1.EnabledChanged, CancelarToolStripMenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class
