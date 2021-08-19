Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data.OleDb
Public Class frmsalidamovil
#Region "Variables"
    'Para connectar a la bd 
    'Dim oldaSalidamovil As New OleDb.OleDbDataAdapter
    '
    'Dim rstagencias, rstmovil, rstusuario, rstestado, rstsalida_movil As New ADODB.Recordset
    Dim dtagencias, dtmovil, dtusuario, dtestado, dtsalida_movil As New DataTable
    Dim dvagencias, dvmovil, dvusuario, dvestado, dvsalida_movil As New DataView
    '
    'Declarando la variable de control 
    Dim icontrol As Integer = 0
    ' Control de lectura7
    Dim lee_salida_movil As Boolean = True
    ' Variable de lectura de los estados 
    Dim lb_lee_estado As Boolean = True
    Dim N_errores As Long = 0
    Dim bIngreso As Boolean = False
    Public hnd As Long
    '
#End Region
#Region "Eventos del formulario"
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub frmsalidamovil_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frmsalidavehiculo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim lidagencias As Integer
            'Cargando valores inciales al formulario 
            DTPFechaSeleccion.Value = dtoUSUARIOS.dfecha_sistema
            '-- objsalidamovilreparto.fnLoad_salida_vehiculo()
            Me.ShadowLabel1.Text = "Lista de Salida Móvil - Reparto "
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False
            ' 
            MenuTab.Items(0).Text = "Lista Salida Móvil"
            MenuTab.Items(1).Text = "Mantenimiento"
            '
            MenuTab.Items(1).Enabled = False
            MenuTab.Items(1).Visible = True
            '
            MenuTab.Items(2).Enabled = False
            MenuTab.Items(2).Visible = False
            MenuTab.Items(3).Enabled = False
            MenuTab.Items(3).Visible = False
            MenuTab.Items(4).Enabled = False
            MenuTab.Items(4).Visible = False
            MenuTab.Items(5).Enabled = False
            MenuTab.Items(5).Visible = False
            ' Recuperando los botones 
            NuevoToolStripMenuItem1.Enabled = True
            NuevoToolStripMenuItem1.Visible = True
            EdicionToolStripMenuItem.Enabled = True
            EdicionToolStripMenuItem.Visible = True
            '
            SalirToolStripMenuItem.Enabled = True
            SalirToolStripMenuItem.Visible = True
            ' Cargando los combos, que corresponden  
            lee_salida_movil = False
            'objsalidamovilreparto.idunidad_agencia_origen = dtoUSUARIOS.m_idciudad
            objsalidamovilreparto.fecha = dtoUSUARIOS.dfecha_sistema
            objsalidamovilreparto.idagencias = dtoUSUARIOS.iIDAGENCIAS
            'Mod.09/10/2009 -->Omendoza - Pasando al datahelper -  
            'If objsalidamovilreparto.fnLoad_salida_movil() Then
            'rstagencias = objsalidamovilreparto.cur_agencias
            'rstmovil = objsalidamovilreparto.cur_movil
            'rstusuario = objsalidamovilreparto.cur_usuario_personal
            'rstestado = objsalidamovilreparto.cur_estado
            'rstsalida_movil = objsalidamovilreparto.cur_salida_movil
            'End If
            'oldaSalidamovil.Fill(dtagencias, rstagencias)
            'oldaSalidamovil.Fill(dtmovil, rstmovil)
            'oldaSalidamovil.Fill(dtusuario, rstusuario)
            'oldaSalidaMOVIL.Fill(dtestado, rstestado)
            'oldaSalidamovil.Fill(dtsalida_movil, rstsalida_movil)
            '
            objsalidamovilreparto.fnLoad_salida_movil()
            dtagencias = objsalidamovilreparto.dt_cur_agencias
            dtmovil = objsalidamovilreparto.dt_cur_movil
            dtusuario = objsalidamovilreparto.dt_cur_usuario_personal
            dtestado = objsalidamovilreparto.dt_cur_estado
            dtsalida_movil = objsalidamovilreparto.dt_cur_salida_movil
            '
            dvmovil = dtmovil.DefaultView
            'dvusuario = dtusuario.DefaultView
            dvsalida_movil = dtsalida_movil.DefaultView
            ' Cargando combo 
            lidagencias = dtoUSUARIOS.iIDAGENCIAS 'Recupera la unidad agencia 
            ' dtoUSUARIOS.iIDAGENCIAS() ' Agencia con la q' a ingresado del sistema 
            If lidagencias < 1 Then
                lidagencias = 9999   'En caso no ingrese 
            End If
            '
            dvagencias = CargarCombo(Me.cmbagencia, dtagencias, "nombre_agencia", "idagencias", lidagencias)
            dvmovil = CargarCombo(Me.cmbmovil, dtmovil, "NRO_UNIDAD_TRANSPORTE", "IDUNIDAD_TRANSPORTE", 0)  ' Por defecto 0 No debe aparecer nada 
            dvusuario = CargarCombo(cmbchoferusuario, dtusuario, "reponsable", "idusuario_personal", 0)  ' Por defecto 0 No debe aparecer nada 
            dvestado = CargarCombo(cmbestado, dtestado, "ESTADO_REGISTRO", "IDESTADO_REGISTRO", 51)  ' Por defecto 0 No debe aparecer nada 
            grillaformato()
            DataGridView1.DataSource = dvsalida_movil
            '
            lee_salida_movil = True

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
#End Region
#Region "Funciones y Procedimientos"
    Sub grillaformato()
        Try
            lb_lee_estado = False
            DataGridView1.Columns.Clear()
            With DataGridView1
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                ' .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .VirtualMode = True
                '.RowHeadersVisible = True
                '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
                '.DataSource = dvsalida_movil
            End With
            '
            ' Formato despues que funcione - Omendoza 
            '
            Dim iidnro_salida As New DataGridViewTextBoxColumn
            With iidnro_salida '0                
                .DataPropertyName = "nro_salida"
                .Name = "nro_salida"
                .HeaderText = "Nº Salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(iidnro_salida)
            '
            Dim sfecha_salida As New DataGridViewTextBoxColumn
            With sfecha_salida  ' 1
                .DataPropertyName = "fecha_salida"
                .Name = "fecha_salida"
                .HeaderText = "Fecha Salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            DataGridView1.Columns.Add(sfecha_salida)
            '
            Dim shora As New DataGridViewTextBoxColumn
            With shora '2                
                .DataPropertyName = "hora_salida"
                .Name = "hora_salida"
                .HeaderText = "Hora"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            DataGridView1.Columns.Add(shora)
            '
            Dim iinro_movil As New DataGridViewTextBoxColumn
            With iinro_movil '3
                .DataPropertyName = "nro_unidad_transporte"
                .Name = "nro_unidad_transporte"
                .HeaderText = "Móvil"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            DataGridView1.Columns.Add(iinro_movil)
            ' 
            Dim sestado As New DataGridViewTextBoxColumn
            With sestado   '4
                .DataPropertyName = "estado_registro"
                .Name = "estado_registro"
                .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            DataGridView1.Columns.Add(sestado)
            '' 
            Dim idestado As New DataGridViewTextBoxColumn
            With idestado '  5
                .DataPropertyName = "estado"
                .Name = "estado"
                .HeaderText = "Idestado"
                .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(idestado)
            '
            Dim responsable_movil As New DataGridViewTextBoxColumn
            With responsable_movil '  6
                '.DataPropertyName = "usuario_chofer"
                '.Name = "usuario_chofer"
                .Name = "responsable_movil"
                .DataPropertyName = "responsable_movil"
                .HeaderText = "Conductor"
                .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(responsable_movil)
            ' 
            Dim sfecha_cierre As New DataGridViewTextBoxColumn
            With sfecha_cierre '  7
                .Name = "Fecha_Cierre"
                .DataPropertyName = "Fecha_Cierre"
                .HeaderText = "Fecha cierre"
                .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(sfecha_cierre)
            '
            Dim susuario_chofer As New DataGridViewTextBoxColumn
            With susuario_chofer '  
                .DataPropertyName = "usuario_chofer"
                .Name = "usuario_chofer"
                .HeaderText = "IdResponsable"
                .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(susuario_chofer)
            '
            Dim nidusuario_reponsable As New DataGridViewTextBoxColumn
            With nidusuario_reponsable '  7
                .DataPropertyName = "idusuario_piloto"
                .Name = "idusuario_piloto"
                .HeaderText = "IdResponsable"
                .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(nidusuario_reponsable)
            '
            Dim iidunidad_transporte As New DataGridViewTextBoxColumn
            With iidunidad_transporte '  8
                .DataPropertyName = "idunidad_transporte"
                .Name = "idunidad_transporte"
                .HeaderText = "Idunidad_transporte"
                .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(iidunidad_transporte)
            '
            Dim iidagencias As New DataGridViewTextBoxColumn
            With iidagencias ' 9
                .DataPropertyName = "idagencias"
                .Name = "idagencias"
                .HeaderText = "Agencia"
                .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(iidagencias)
            '
            Dim snro_licencia As New DataGridViewTextBoxColumn
            With snro_licencia '  10
                .DataPropertyName = "nro_licencia"
                .Name = "nro_licencia"
                .HeaderText = "Licencia"
                .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(snro_licencia)
            ' 
            Dim smarca_bus As New DataGridViewTextBoxColumn
            With smarca_bus '  11
                .DataPropertyName = "marca_bus"
                .Name = "marca_bus"
                .HeaderText = "Marca Bus"
                .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(smarca_bus)
            '
            Dim splaca_bus As New DataGridViewTextBoxColumn
            With splaca_bus '  12
                .DataPropertyName = "placa_bus"
                .Name = "placa_bus"
                .HeaderText = "Placa"
                .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(splaca_bus)
            '
            lb_lee_estado = True
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
#End Region
    Private Sub frmsalidavehiculo_MenuCancelar() Handles Me.MenuCancelar
        Me.cmbagencia.Enabled = True
        configurando_estados()
    End Sub
    'Sub grilla_ciudad_destino()
    '    Try
    '        DataGridView2.Columns.Clear()
    '        '
    '        With DataGridView2
    '            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    '            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
    '            .AllowUserToOrderColumns = True
    '            .AllowUserToDeleteRows = False
    '            .AllowUserToAddRows = False
    '            .AutoGenerateColumns = True
    '            ' .DefaultCellStyle.WrapMode = DataGridViewTriState.True
    '            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '            .VirtualMode = True
    '            '.RowHeadersVisible = True
    '            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '            .ReadOnly = True
    '            .DataSource = dvciudad_destino
    '        End With
    '        '
    '        ' Formato despues que funcione - Omendoza 
    '        '
    '    Catch ex As Exception
    '        '
    '    End Try
    'End Sub
    Private Sub frmsalidavehiculo_MenuEditar() Handles Me.MenuEditar
        Dim filarow As Integer        
        Dim dgrvsalidamovil As DataGridViewRow
        '
        Dim l_estado As Long
        '
        Try
            icontrol = 0
            filarow = DataGridView1.CurrentRow.Index
            If filarow < 0 Then
                Exit Sub
            End If
            dgrvsalidamovil = DataGridView1.CurrentRow
            Me.txtidnrosalida.Text = CType(dgrvsalidamovil.Cells("nro_salida").Value, String)
            l_estado = CType(dgrvsalidamovil.Cells("estado").Value, Long)
            If l_estado = 52 Then
                MsgBox("No se puede modificar los datos de la móvil, está cerrado", MsgBoxStyle.Information, "Sistema Salida Móvil")
                desactiva()
            Else
                activa()
            End If
            '
            Me.dtpfec_salida.Value = CType(dgrvsalidamovil.Cells("fecha_salida").Value, String)
            Me.txthorasalida.Text = CType(dgrvsalidamovil.Cells("hora_salida").Value, String)
            Me.cmbmovil.SelectedValue = CType(dgrvsalidamovil.Cells("idunidad_transporte").Value, Long)
            If CType(dgrvsalidamovil.Cells("usuario_chofer").Value, Long) = -666 Then
                Me.cmbchoferusuario.SelectedValue = -666
            Else
                Me.cmbchoferusuario.SelectedValue = CType(dgrvsalidamovil.Cells("usuario_chofer").Value, Long)
            End If
            '
            cmbestado.SelectedValue = CType(dgrvsalidamovil.Cells("estado").Value, Long)
            ' Configuracion de iconos en general
            'GrabarToolStripMenuItem.Enabled = True
            'GrabarToolStripMenuItem.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de seguridad")
        End Try
    End Sub
    Private Sub frmsalidamovil_MenuGrabar() Handles Me.MenuGrabar
        Dim rstcontrol As New ADODB.Recordset
        Dim icodigo As Integer
        'rstciudad_destino = Nothing
        'rstciudad_destino = New ADODB.Recordset
        'dtciudad_destino = Nothing
        'dvciudad_destino = Nothing
        Try
            Dim MyObligatorios() As Object = {Me.txthorasalida, Me.cmbmovil, Me.Btnmovil, Me.cmbchoferusuario, Me.btnchoferusuario}
            If Funciones.Validaciones(MyObligatorios) <> 0 Then 'Si todo esta bien (0)...
                Exit Sub
            End If
            '
            valida_hora()
            ' 
            If n_errores = 1 Then
                Exit Sub
            End If
            '
            objsalidamovilreparto.control = icontrol
            If icontrol = 1 Then
                objsalidamovilreparto.idnro_salida = -666
            Else
                objsalidamovilreparto.idnro_salida = txtidnrosalida.Text  'El nro de salida que se muestra.
            End If
            '
            If CType(cmbmovil.SelectedValue, Long) < 1 Then
                objsalidamovilreparto.idunidad_transporte = -666
            Else
                objsalidamovilreparto.idunidad_transporte = CType(cmbmovil.SelectedValue, Long)
            End If
            '
            objsalidamovilreparto.fecha_salida = CType(dtpfec_salida.Value, String)
            objsalidamovilreparto.hora_salida = txthorasalida.Text
            '
            If CType(cmbchoferusuario.SelectedValue, Long) < 1 Then
                objsalidamovilreparto.usuario_chofer = -666
            Else
                objsalidamovilreparto.usuario_chofer = CType(cmbchoferusuario.SelectedValue, Long)
            End If
            If txtlicencia.Text = "" Then
                objsalidamovilreparto.nro_licencia = "null"
            Else
                objsalidamovilreparto.nro_licencia = txtlicencia.Text
            End If
            If txtmarcabus.Text = "" Then
                objsalidamovilreparto.marca_bus = "null"
            Else
                objsalidamovilreparto.marca_bus = txtmarcabus.Text
            End If
            If txtplacabus.Text = "" Then
                objsalidamovilreparto.placa_bus = "null"
            Else
                objsalidamovilreparto.placa_bus = txtplacabus.Text
            End If
            objsalidamovilreparto.estado = CType(cmbestado.SelectedValue, Long)
            objsalidamovilreparto.idagencias = dtoUSUARIOS.iIDAGENCIAS
            '
            objsalidamovilreparto.ip = dtoUSUARIOS.IP
            objsalidamovilreparto.idusuario_personal = dtoUSUARIOS.IdLogin
            objsalidamovilreparto.idrol_usuario = dtoUSUARIOS.IdRol
            'Mod.09/10/2009 -->Omendoza - Pasando al datahelper -  
            If objsalidamovilreparto.fnLoad_graba_salida_movil() Then
                'rstcontrol = objsalidamovilreparto.cur_graba
                Dim dt_tmp As New DataTable
                dt_tmp = objsalidamovilreparto.dt_cur_graba
                icodigo = CType(dt_tmp.Rows(0).Item(0), Integer)
                ModSolRecojoCarga.smensaje = CType(dt_tmp.Rows(0).Item(1), String)
                'Recuperando los destinos por donde va el bus 'Modificado 27/01/2007               
                'rstciudad_destino = objsalidamovilreparto.cur_recupera_ciudad_destino
                'dtciudad_destino = New DataTable
                'dvciudad_destino = New DataView
                'oldaSalidamovil.Fill(dtciudad_destino, rstciudad_destino)
                'dvciudad_destino = dtciudad_destino.DefaultView
                '' Recupera la ciudad por donde pasa el bus 
                'grilla_ciudad_destino()
                '
                MessageBox.Show(ModSolRecojoCarga.smensaje, "Salida Vehículo Despacho", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '
                If icodigo <> 0 Then
                    Exit Sub
                Else
                    'Cuando Graba correctamente, se vuelve a configurar  
                    Me.SelectMenu(0)
                    MenuTab.Items(0).Enabled = True
                    MenuTab.Items(1).Enabled = False
                    SplitContainer2.Panel1Collapsed = True
                    'Recuperando el nuevo ingreso 
                    recupera_salida_movil()
                    configurando_estados()
                    '
                    'objsalidamovilreparto.iduni_agencia_origen = cmborigen.SelectedValue
                    'objsalidamovilreparto.fecha = CType(DTPFechaSeleccion.Value, String)
                    'If objsalidamovilreparto.fnrecupera_salida_vehiculo = True Then
                    '    rstsalida_vehiculo = objsalidamovilreparto.cur_salida_vehiculo
                    '    ' Limpiando los valores 
                    '    limpia_tabdatos()
                    '    '
                    '    DataGridView1.Columns.Clear()
                    '    dtsalida_vehiculo = Nothing
                    '    dvsalida_vehiculo = Nothing
                    '    dtsalida_vehiculo = New DataTable
                    '    dvsalida_vehiculo = New DataView
                    '    '
                    '    oldaSalidaMOVIL.Fill(dtsalida_vehiculo, rstsalida_vehiculo)
                    '    dvsalida_vehiculo = dtsalida_vehiculo.DefaultView
                    '    grillaformato()
                End If
            End If
            '    Me.cmbaddciudad.Enabled = False
        Catch EX As Exception
            MsgBox(EX.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub frmsalidavehiculo_MenuNuevo() Handles Me.MenuNuevo
        Try
            ' Configuracion de iconos en general
            GrabarToolStripMenuItem.Enabled = True
            GrabarToolStripMenuItem.Visible = True
            MenuTab.Items(0).Enabled = False
            '
            ' Debe recuperar la rutas vigentes cuando ingresa uno nuevo  
            '
            cmbchoferusuario.SelectedValue = -1 'Un valor por defecto q' y obligue a elegir
            '
            'dvorigenreal.RowFilter = "idestado_registro = 1 "
            'dvdestinoreal.RowFilter = "idestado_registro = 1 "
            '
            ' El estado sera creado por defecto  
            icontrol = 1
            Me.cmbestado.SelectedValue = 51 ' Activo 
            '
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub cmbtiposervicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''Dim posicion As Integer
        ''Dim unidadagenciaorigen, unidadagenciadestino As String
        ''Dim drvruta As DataRowView
        'Try
        '    Select Case CType(cmbtiposervicio.SelectedValue, Integer)
        '        Case 1 'Tepsa 
        '            TxtRucTerc.ReadOnly = True
        '            TxtRucTerc.BackColor = System.Drawing.SystemColors.Info
        '            txtnomtercero.ReadOnly = True
        '            txtnomtercero.BackColor = System.Drawing.SystemColors.Info
        '            txtlicencia.ReadOnly = True
        '            txtlicencia.BackColor = System.Drawing.SystemColors.Info
        '            txtmarcabus.ReadOnly = True
        '            txtplacabus.ReadOnly = True
        '            cmbOrigenreal.BackColor = System.Drawing.SystemColors.Info
        '            cmbOrigenreal.Enabled = False
        '            cmbDestinoreal.BackColor = System.Drawing.SystemColors.Info
        '            cmbDestinoreal.Enabled = False
        '            '
        '            cmbrutahorario.BackColor = Color.White
        '            cmbrutahorario.Enabled = True
        '            cmbchoferusuario.Enabled = True
        '            '
        '        Case 2 'Carguero 
        '            TxtRucTerc.ReadOnly = True
        '            TxtRucTerc.BackColor = System.Drawing.SystemColors.Info
        '            txtnomtercero.ReadOnly = True
        '            txtnomtercero.BackColor = System.Drawing.SystemColors.Info
        '            txtlicencia.ReadOnly = True
        '            txtlicencia.BackColor = System.Drawing.SystemColors.Info
        '            txtmarcabus.ReadOnly = True
        '            txtplacabus.ReadOnly = True
        '            '
        '            cmbOrigenreal.Enabled = True
        '            cmbOrigenreal.BackColor = Color.White
        '            cmbDestinoreal.Enabled = True
        '            cmbDestinoreal.BackColor = Color.White
        '            cmbchoferusuario.Enabled = True
        '            '
        '            cmbrutahorario.Enabled = False
        '            ' Por no encontrarse en un ruta establecida
        '            cmbrutahorario.SelectedValue = -666
        '            cmbrutahorario.Enabled = False
        '            cmbrutahorario.BackColor = System.Drawing.SystemColors.Info
        '            '
        '            Me.cmbOrigenreal.SelectedValue = dtoUSUARIOS.iIDAGENCIAS
        '        Case 3 ' Por empresa de tercero 
        '            'TxtRucTerc.ReadOnly = False
        '            'txtnomtercero.ReadOnly = False
        '            'txtlicencia.ReadOnly = False
        '            'txtmarcabus.ReadOnly = False
        '            'txtplacabus.ReadOnly = False
        '            cmbOrigenreal.Enabled = True
        '            cmbOrigenreal.BackColor = Color.White
        '            cmbDestinoreal.Enabled = True
        '            cmbDestinoreal.BackColor = Color.White
        '            cmbrutahorario.Enabled = False
        '            ' Por no encontrarse en un ruta establecida Por el carguero.
        '            cmbrutahorario.SelectedValue = -666
        '            cmbrutahorario.Enabled = False
        '            ' El chofer no es de la empresa. 
        '            cmbchoferusuario.Enabled = False
        '            cmbchoferusuario.SelectedValue = -666
        '            '
        '            TxtRucTerc.ReadOnly = False
        '            TxtRucTerc.Enabled = True
        '            TxtRucTerc.BackColor = Color.White
        '            txtnomtercero.ReadOnly = False
        '            txtnomtercero.Enabled = True
        '            txtnomtercero.BackColor = Color.White
        '            txtlicencia.ReadOnly = False
        '            txtlicencia.Enabled = True
        '            txtlicencia.BackColor = Color.White
        '    End Select
        '    'posicion = cmbtiposervicio.SelectedIndex()
        '    'If dvrutas.Count > 0 Then
        '    '    If posicion >= 0 Then
        '    '        If IsDBNull(dvrutas.Item(posicion)) = True Then
        '    '            Exit Sub
        '    '        End If
        '    '        drvruta = dvrutas.Item(posicion)
        '    '        txtorigen.Text = ""
        '    '        txtDestino.Text = ""
        '    '        unidadagenciaorigen = IIf(IsDBNull(drvruta("origen")) = True, "", drvruta("origen").ToString)
        '    '        unidadagenciadestino = IIf(IsDBNull(drvruta("destino")) = True, "", drvruta("destino").ToString)
        '    '        txtorigen.Text = unidadagenciaorigen
        '    '        txtDestino.Text = unidadagenciadestino
        '    '    End If
        '    'End If
        'Catch ex As Exception
        '    ' MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        'End Try

        ''If CbTipoServ.Text = "TEPSA" Then
        ''    TxtNroSalida.Enabled = True
        ''    TxtNroSalida.BackColor = Color.White
        ''    CbItinerarios.Enabled = True
        ''    CbItinerarios.BackColor = Color.White
        ''    TxtBus.Enabled = True
        ''    TxtBus.BackColor = Color.White
        ''    CbBus.Enabled = True
        ''    CbBus.BackColor = Color.White
        ''    CbChofer.Enabled = True
        ''    CbChofer.BackColor = Color.White
        ''    TxtMarca.Enabled = False
        ''    TxtMarca.BackColor = System.Drawing.SystemColors.Info
        ''    TxtPlaca.Enabled = False
        ''    TxtPlaca.BackColor = System.Drawing.SystemColors.Info
        ''    TxtLicencia.Enabled = False
        ''    TxtLicencia.BackColor = System.Drawing.SystemColors.Info
        ''    TxtRucTerc.Enabled = False
        ''    TxtRucTerc.BackColor = System.Drawing.SystemColors.Info
        ''    TxtTercero.Enabled = False
        ''    TxtTercero.BackColor = System.Drawing.SystemColors.Info
        ''ElseIf CbTipoServ.Text = "CARGUERO" Then
        ''    TxtNroSalida.Enabled = False
        ''    TxtNroSalida.BackColor = System.Drawing.SystemColors.Info
        ''    CbItinerarios.Enabled = False
        ''    CbItinerarios.BackColor = System.Drawing.SystemColors.Info
        ''    TxtBus.Enabled = True
        ''    TxtBus.BackColor = Color.White
        ''    CbBus.Enabled = True
        ''    CbBus.BackColor = Color.White
        ''    CbChofer.Enabled = True
        ''    CbChofer.BackColor = Color.White
        ''    TxtMarca.Enabled = False
        ''    TxtMarca.BackColor = System.Drawing.SystemColors.Info
        ''    TxtPlaca.Enabled = False
        ''    TxtPlaca.BackColor = System.Drawing.SystemColors.Info
        ''    TxtLicencia.Enabled = False
        ''    TxtLicencia.BackColor = System.Drawing.SystemColors.Info
        ''    TxtRucTerc.Enabled = False
        ''    TxtRucTerc.BackColor = System.Drawing.SystemColors.Info
        ''    TxtTercero.Enabled = False
        ''    TxtTercero.BackColor = System.Drawing.SystemColors.Info
        ''Else
        ''    TxtNroSalida.Enabled = False
        ''    TxtNroSalida.BackColor = System.Drawing.SystemColors.Info
        ''    CbItinerarios.Enabled = False
        ''    CbItinerarios.BackColor = System.Drawing.SystemColors.Info
        ''    TxtBus.Enabled = False
        ''    TxtBus.BackColor = System.Drawing.SystemColors.Info
        ''    CbBus.Enabled = False
        ''    CbBus.BackColor = System.Drawing.SystemColors.Info
        ''    CbChofer.Enabled = False
        ''    CbChofer.BackColor = System.Drawing.SystemColors.Info
        ''    TxtMarca.Enabled = True
        ''    TxtMarca.BackColor = Color.White
        ''    TxtPlaca.Enabled = True
        ''    TxtPlaca.BackColor = Color.White
        ''    TxtLicencia.Enabled = True
        ''    TxtLicencia.BackColor = Color.White
        ''    TxtRucTerc.Enabled = True
        ''    TxtRucTerc.BackColor = Color.White
        ''    TxtTercero.Enabled = True
        ''    TxtTercero.BackColor = Color.White
        ''End If

    End Sub
    Private Sub cmbruta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim posicion As Integer
        'Dim idunidadagenciaorigen, idunidadagenciadestino As Integer
        'Dim shora As String
        'Dim drvruta As DataRowView
        'Try
        '    posicion = cmbrutahorario.SelectedIndex
        '    If dvruta.Count > 0 Then
        '        If posicion >= 0 Then
        '            If IsDBNull(dvruta.Item(posicion)) = True Then
        '                Exit Sub
        '            End If
        '            '
        '            drvruta = dvruta.Item(posicion)
        '            '--
        '            idunidadagenciaorigen = CType(IIf(IsDBNull(drvruta("idunidad_agencia")) = True, 0, drvruta("idunidad_agencia")), Integer)
        '            idunidadagenciadestino = CType(IIf(IsDBNull(drvruta("idunidad_agencia_destino")) = True, 0, drvruta("idunidad_agencia_destino")), Integer)
        '            shora = IIf(IsDBNull(drvruta("hora")) = True, "00:00", drvruta("hora").ToString)
        '            '--
        '            cmbOrigenreal.SelectedValue = idunidadagenciaorigen
        '            cmbDestinoreal.SelectedValue = idunidadagenciadestino
        '            txthorasalida.Text = shora
        '            '
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        'End Try
    End Sub
    Private Sub cmbbus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbmovil.SelectedIndexChanged
        Dim posicion As Integer
        Dim splaca, smodelo As String
        Dim drvbus As DataRowView
        Try
            posicion = cmbmovil.SelectedIndex
            If dvmovil.Count > 0 Then
                If posicion >= 0 Then
                    If IsDBNull(dvmovil.Item(posicion)) = True Then
                        Exit Sub
                    End If
                    '
                    txtmarcabus.Text = ""
                    txtplacabus.Text = ""
                    drvbus = dvmovil.Item(posicion)
                    '--
                    splaca = IIf(IsDBNull(drvbus("PLACA")) = True, "", drvbus("PLACA").ToString)
                    smodelo = IIf(IsDBNull(drvbus("MODELO_MOVIL")) = True, "", drvbus("MODELO_MOVIL").ToString)
                    '--
                    txtmarcabus.Text = smodelo
                    txtplacabus.Text = splaca
                    '--
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub cmbchoferusuario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbchoferusuario.SelectedIndexChanged
        Dim posicion As Integer
        Dim snombre, slicencia As String
        Dim drvusuario As DataRowView
        Try
            'dtusuario
            posicion = cmbchoferusuario.SelectedIndex
            If dvusuario.Count > 0 Then
                If posicion >= 0 Then
                    If IsDBNull(dvusuario.Item(posicion)) = True Then
                        Exit Sub
                    End If
                    '--
                    drvusuario = dvusuario.Item(posicion)
                    txtlicencia.Text = ""
                    '--
                    'snombre = IIf(IsDBNull(drvusuario("nombre")) = True, "", drvusuario("nombre").ToString)
                    slicencia = IIf(IsDBNull(drvusuario("nro_licencia")) = True, "", drvusuario("nro_licencia").ToString)
                    '--
                    txtlicencia.Text = slicencia
                    '--
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub txthorasalida_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txthorasalida.Validating
        valida_hora()
        'Dim shora As String
        'shora = CType(txthorasalida.Text, String)
        'shora = validar_hora_salida(shora)
        'If shora = "" Then
        '    txthorasalida.Text = shora
        '    txthorasalida.Focus()
        '    Exit Sub
        'End If
        'txthorasalida.Text = shora
    End Sub
    'Function valida_ruta() As Boolean

    '    Try
    '        If CType(cmbOrigenreal.SelectedValue, Long) = 0 Then
    '            MessageBox.Show("Debe elegir la ciudad origen", "Salida Vehículo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            cmbOrigenreal.Focus()
    '            Return False
    '        End If
    '        If CType(cmbDestinoreal.SelectedValue, Long) = 0 Then
    '            MessageBox.Show("Debe elegir el destino", "Salida Vehículo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            cmbDestinoreal.Focus()
    '            Return False
    '        End If
    '        Return True
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
    '        Return False
    '    End Try
    'End Function
    Sub limpia_tabdatos()
        txtidnrosalida.Text = ""
        'cmbtiposervicio.SelectedValue = 1
        'cmbrutahorario.SelectedValue = -666
        txthorasalida.Text = ""
        cmbmovil.SelectedValue = -666
        cmbchoferusuario.SelectedValue = -666
        'cmbOrigenreal.SelectedValue = -666
        'cmbDestinoreal.SelectedValue = -666
        'TxtRucTerc.Text = ""
        txtlicencia.Text = ""
        'txtnomtercero.Text = ""
        txtmarcabus.Text = ""
        txtplacabus.Text = ""
    End Sub
    Private Sub CreadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreadoToolStripMenuItem.Click


    End Sub
    Private Sub ActivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActivoToolStripMenuItem.Click
        Dim sIDNRO_SALIDA As String
        Dim dgrvsalidavehiculo As DataGridViewRow
        Dim filarow As Integer
        Dim lestado, lnro_salida As Long
        Dim rstcontrol As New ADODB.Recordset
        Dim lcodigo As Long
        '
        Try
            icontrol = 0
            filarow = DataGridView1.CurrentRow.Index
            If filarow < 0 Then
                MessageBox.Show("No seleccionado ningún registro", "Salida Vehículo Despacho", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            '
            dgrvsalidavehiculo = DataGridView1.CurrentRow
            lnro_salida = CType(dgrvsalidavehiculo.Cells("nro_salida").Value, String)
            lestado = 51 'Activado, solo activa los buses q' esten creado   
            objsalidamovilreparto.idnro_salida = lnro_salida
            objsalidamovilreparto.estado = lestado

            If objsalidamovilreparto.fnactualiza_estado_salida_movil() Then
                'Mod.09/10/2009 -->Omendoza - Pasando al datahelper -  
                'rstcontrol = objsalidamovilreparto.cur_actualiza_estado
                'lcodigo = CType(rstcontrol.Fields(0).Value, Integer)
                'ModSolRecojoCarga.smensaje = CType(rstcontrol.Fields(1).Value, String)
                lcodigo = CType(objsalidamovilreparto.dt_cur_actualiza_estado.Rows(0).Item(0), Integer)
                ModSolRecojoCarga.smensaje = CType(objsalidamovilreparto.dt_cur_actualiza_estado.Rows(0).Item(1), String)
                'MsgBox(smensaje, MsgBoxStyle.Information, "Seguridad del Sistema")
                MessageBox.Show(ModSolRecojoCarga.smensaje, "Salida Vehículo Despacho", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            '
            recupera_salida_movil()
            configurando_estados()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub RepartoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepartoToolStripMenuItem.Click
        Dim sIDNRO_SALIDA As String
        Dim dgrvsalidamovil As DataGridViewRow
        Dim filarow As Integer
        Dim lestado, lnro_salida As Long
        Dim rstcontrol As New ADODB.Recordset
        Dim lcodigo As Long
        '
        Try
            icontrol = 0
            filarow = DataGridView1.CurrentRow.Index
            If filarow < 0 Then
                MessageBox.Show("No seleccionado ningún registro", "Salida Vehículo Despacho", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            '
            dgrvsalidamovil = DataGridView1.CurrentRow
            lnro_salida = CType(dgrvsalidamovil.Cells("nro_salida").Value, String)
            lestado = 54 'La móvil está en reparto 
            objsalidamovilreparto.idnro_salida = lnro_salida
            objsalidamovilreparto.estado = lestado
            If objsalidamovilreparto.fnactualiza_estado_salida_movil() Then
                'Mod.09/10/2009 -->Omendoza - Pasando al datahelper -  
                'rstcontrol = objsalidamovilreparto.cur_actualiza_estado
                'lcodigo = CType(rstcontrol.Fields(0).Value, Integer)
                'ModSolRecojoCarga.smensaje = CType(rstcontrol.Fields(1).Value, String)
                lcodigo = CType(objsalidamovilreparto.dt_cur_actualiza_estado.Rows(0).Item(0), Integer)
                ModSolRecojoCarga.smensaje = CType(objsalidamovilreparto.dt_cur_actualiza_estado.Rows(0).Item(1), String)
                '
                'MsgBox(smensaje, MsgBoxStyle.Information, "Seguridad del Sistema")
                MessageBox.Show(ModSolRecojoCarga.smensaje, "Salida Móvil ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            '
            recupera_salida_movil()
            configurando_estados()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub CerradoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerradoToolStripMenuItem.Click
        Dim sIDNRO_SALIDA As String
        Dim dgrvsalidamovil As DataGridViewRow
        Dim filarow As Integer
        Dim lestado, lnro_salida As Long
        Dim rstcontrol As ADODB.Recordset
        Dim lcodigo As Long
        '
        Dim resp As DialogResult
        Dim responsable As String
        ' 
        Try
            icontrol = 0
            filarow = DataGridView1.CurrentRow.Index
            If filarow < 0 Then
                MessageBox.Show("No seleccionado ningún registro", "Salida Vehículo Despacho", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            '
            dgrvsalidamovil = DataGridView1.CurrentRow
            lnro_salida = CType(dgrvsalidamovil.Cells("nro_salida").Value, String)
            responsable = CType(dgrvsalidamovil.Cells("responsable_movil").Value, String)
            ' 
            resp = MessageBox.Show("¿Está seguro de cerrar, para el responsable " + responsable + " ?", "Seguridad del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
            ' 
            If resp = Windows.Forms.DialogResult.Yes Then
                lestado = 52 ' Cerrado 
                objsalidamovilreparto.idnro_salida = lnro_salida
                objsalidamovilreparto.estado = lestado
                If objsalidamovilreparto.fnactualiza_estado_salida_movil() Then
                    'Mod.09/10/2009 -->Omendoza - Pasando al datahelper -  
                    'rstcontrol = objsalidamovilreparto.cur_actualiza_estado
                    'lcodigo = CType(rstcontrol.Fields(0).Value, Integer)
                    'ModSolRecojoCarga.smensaje = CType(rstcontrol.Fields(1).Value, String)                    
                    lcodigo = CType(objsalidamovilreparto.dt_cur_actualiza_estado.Rows(0).Item(0), Integer)
                    ModSolRecojoCarga.smensaje = CType(objsalidamovilreparto.dt_cur_actualiza_estado.Rows(0).Item(1), String)
                    '
                    'MsgBox(smensaje, MsgBoxStyle.Information, "Seguridad del Sistema")
                    MessageBox.Show(ModSolRecojoCarga.smensaje, "Salida Vehículo Despacho", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                '
                recupera_salida_movil()
                configurando_estados()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
        '
    End Sub
    Private Sub AnuladoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnuladoToolStripMenuItem.Click
        Dim sIDNRO_SALIDA As String
        Dim dgrvsalidamovil As DataGridViewRow
        Dim filarow As Integer
        Dim lestado, lnro_salida As Long
        Dim rstcontrol As ADODB.Recordset
        Dim lcodigo As Long
        '
        Try
            icontrol = 0
            filarow = DataGridView1.CurrentRow.Index
            If filarow < 0 Then
                MessageBox.Show("No seleccionado ningún registro", "Salida Vehículo Despacho", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            '
            dgrvsalidamovil = DataGridView1.CurrentRow
            lnro_salida = CType(dgrvsalidamovil.Cells("nro_salida").Value, String)
            lestado = 53 'ANULADO 
            objsalidamovilreparto.idnro_salida = lnro_salida
            objsalidamovilreparto.estado = lestado
            If objsalidamovilreparto.fnactualiza_estado_salida_movil() Then
                'Mod.09/10/2009 -->Omendoza - Pasando al datahelper -  
                'rstcontrol = objsalidamovilreparto.cur_actualiza_estado
                'lcodigo = CType(rstcontrol.Fields(0).Value, Integer)
                'ModSolRecojoCarga.smensaje = CType(rstcontrol.Fields(1).Value, String)
                lcodigo = CType(objsalidamovilreparto.dt_cur_actualiza_estado.Rows(0).Item(0), Integer)
                ModSolRecojoCarga.smensaje = CType(objsalidamovilreparto.dt_cur_actualiza_estado.Rows(0).Item(1), String)
                '
                MessageBox.Show(ModSolRecojoCarga.smensaje, "Salida Vehículo Despacho", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            '
            recupera_salida_movil()
            configurando_estados()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'Dim sIDNRO_SALIDA As String
        'Dim dgrvsalidavehiculo As DataGridViewRow
        'Dim filarow As Integer
        'Dim lestado, lnro_salida As Long
        'Dim rstcontrol As ADODB.Recordset
        'Dim lcodigo As Long
        ''----
        'dgrvsalidavehiculo = DataGridView1.CurrentRow
        'lnro_salida = CType(dgrvsalidavehiculo.Cells("nro_salida").Value, String)
        'lestado = CType(dgrvsalidavehiculo.Cells("estado").Value, Long)
        ''---
        'Select Case lestado
        '    Case 32 'Creado pasa a Activo pasa a anulado 
        '        CreadoToolStripMenuItem.Enabled = False
        '        ActivoToolStripMenuItem.Enabled = True
        '        DespachadoToolStripMenuItem.Enabled = False
        '        RecepciónToolStripMenuItem.Enabled = False
        '        FinalizarToolStripMenuItem.Enabled = False
        '        '
        '        AnuladoToolStripMenuItem.Enabled = True
        '    Case 33 'Activo 
        '        CreadoToolStripMenuItem.Enabled = False
        '        ActivoToolStripMenuItem.Enabled = False
        '        DespachadoToolStripMenuItem.Enabled = True
        '        RecepciónToolStripMenuItem.Enabled = False
        '        FinalizarToolStripMenuItem.Enabled = False
        '        ' Puede anularse siempre y cuando no se halla anulado 
        '        AnuladoToolStripMenuItem.Enabled = True
        '    Case 34 ' Despachado
        '        CreadoToolStripMenuItem.Enabled = False
        '        ActivoToolStripMenuItem.Enabled = True
        '        DespachadoToolStripMenuItem.Enabled = False
        '        RecepciónToolStripMenuItem.Enabled = True
        '        '
        '        FinalizarToolStripMenuItem.Enabled = False
        '        ' Puede anularse 
        '        AnuladoToolStripMenuItem.Enabled = False
        '    Case 35 'RECEPCION CARGA
        '        CreadoToolStripMenuItem.Enabled = False
        '        ActivoToolStripMenuItem.Enabled = False
        '        DespachadoToolStripMenuItem.Enabled = False
        '        RecepciónToolStripMenuItem.Enabled = False
        '        FinalizarToolStripMenuItem.Enabled = True
        '        ' Puede anularse 
        '        AnuladoToolStripMenuItem.Enabled = False
        '    Case 36 'DESTINO FINAL
        '        CreadoToolStripMenuItem.Enabled = False
        '        ActivoToolStripMenuItem.Enabled = False
        '        DespachadoToolStripMenuItem.Enabled = False
        '        RecepciónToolStripMenuItem.Enabled = False
        '        FinalizarToolStripMenuItem.Enabled = False
        '        ' Puede anularse 
        '        AnuladoToolStripMenuItem.Enabled = False
        '    Case 37 'ANULADO
        '        CreadoToolStripMenuItem.Enabled = False
        '        ActivoToolStripMenuItem.Enabled = False
        '        DespachadoToolStripMenuItem.Enabled = False
        '        RecepciónToolStripMenuItem.Enabled = False
        '        FinalizarToolStripMenuItem.Enabled = False
        '        ' Puede anularse 
        '        AnuladoToolStripMenuItem.Enabled = False
        'End Select
        configurando_estados()
    End Sub
    Sub recupera_salida_movil()
        Dim sfecha As String
        Dim lidagencia As Long
        Dim rstsalidamovil As New ADODB.Recordset
        Try
            If lee_salida_movil Then
                lidagencia = CType(cmbagencia.SelectedValue, Long)
                sfecha = CType(DTPFechaSeleccion.Value, String)
                '
                objsalidamovilreparto.idagencias = lidagencia
                objsalidamovilreparto.fecha_salida = CType(DTPFechaSeleccion.Value, String)
                '
                If objsalidamovilreparto.fnrecupera_salida_movil() Then
                    'Mod.09/10/2009 -->Omendoza - Pasando al datahelper -  
                    'rstsalidamovil = objsalidamovilreparto.dt_cur_salida_movil
                    ' Limpiando los valores 
                    limpia_tabdatos()
                    '                    
                    dtsalida_movil = Nothing
                    dvsalida_movil = Nothing
                    dtsalida_movil = New DataTable
                    dvsalida_movil = New DataView
                    '
                    DataGridView1.Columns.Clear()
                    '
                    'oldaSalidamovil.Fill(dtsalida_movil, rstsalidamovil)
                    dtsalida_movil = objsalidamovilreparto.dt_cur_salida_movil
                    grillaformato()
                    dvsalida_movil = dtsalida_movil.DefaultView
                    DataGridView1.DataSource = dvsalida_movil
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub cmborigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbagencia.SelectedIndexChanged
        recupera_salida_movil()
    End Sub
    Private Sub DTPFechaSeleccion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFechaSeleccion.ValueChanged
        recupera_salida_movil()
    End Sub

    Private Sub DataGridView1_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellLeave
        If e.RowIndex = 0 Then
            configurando_estados()
        End If
        'OK
    End Sub
    Sub configurando_estados()
        Try
            If lb_lee_estado Then
                Dim sIDNRO_SALIDA As String
                Dim dgrvsalidamovil As DataGridViewRow
                Dim filarow As Integer
                Dim lestado, lnro_salida As Long
                Dim rstcontrol As ADODB.Recordset
                Dim lcodigo As Long
                ''----
                If DataGridView1.CurrentRow Is Nothing Then
                    Exit Sub
                End If
                dgrvsalidamovil = DataGridView1.CurrentRow
                If IsDBNull(dgrvsalidamovil.Cells("nro_salida").Value) = True Then
                    Exit Sub
                End If
                '---
                lnro_salida = CType(dgrvsalidamovil.Cells("nro_salida").Value, String)
                lestado = CType(dgrvsalidamovil.Cells("estado").Value, Long)
                '---
                Select Case lestado
                    Case 51 'C Activo pasa a anulado o reparto 
                        CreadoToolStripMenuItem.Enabled = False
                        ActivoToolStripMenuItem.Enabled = False
                        RepartoToolStripMenuItem.Enabled = True
                        CerradoToolStripMenuItem.Enabled = False
                        '
                        AnuladoToolStripMenuItem.Enabled = True
                    Case 52 'Cerrado - No pasa a ningún estado 
                        CreadoToolStripMenuItem.Enabled = False
                        ActivoToolStripMenuItem.Enabled = False
                        RepartoToolStripMenuItem.Enabled = False
                        CerradoToolStripMenuItem.Enabled = False
                        ' Puede anularse siempre y cuando no se halla anulado 
                        AnuladoToolStripMenuItem.Enabled = False
                    Case 54 'Reparto pasa a Activo u anulado 
                        CreadoToolStripMenuItem.Enabled = False
                        ActivoToolStripMenuItem.Enabled = True
                        RepartoToolStripMenuItem.Enabled = False
                        CerradoToolStripMenuItem.Enabled = True
                        ' Puede anularse siempre y cuando no se halla anulado 
                        AnuladoToolStripMenuItem.Enabled = True
                    Case 53 ' Anulado 
                        CreadoToolStripMenuItem.Enabled = False
                        ActivoToolStripMenuItem.Enabled = False
                        RepartoToolStripMenuItem.Enabled = False
                        CerradoToolStripMenuItem.Enabled = False
                        ' Puede anularse 
                        AnuladoToolStripMenuItem.Enabled = False
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub TxtRucTerc_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If TxtRucTerc.Text <> "" Then
        '    If fnValidarRUC(TxtRucTerc.Text) = False Then
        '        MsgBox("El RUC no válido para la SUNAT, Revise el RUC", MsgBoxStyle.Information, "Seguridad Sistema")
        '    End If
        'End If
    End Sub
    '    Sub recupera_ciudad_destino()
    'objsalidamovilreparto.idnro_salida = CType(Me.txtidnrosalida.Text, Long)
    'If objsalidamovilreparto.fnget_ciudad_destino = True Then
    '    rstciudad_destino = Nothing
    '    dtciudad_destino = Nothing
    '    dvciudad_destino = Nothing
    '    dtciudad_destino = New DataTable
    '    dvciudad_destino = New DataView
    '    '
    '    rstciudad_destino = New ADODB.Recordset
    '    rstciudad_destino = objsalidamovilreparto.cur_recupera_ciudad_destino
    '    oldaSalidaMOVIL.Fill(dtciudad_destino, rstciudad_destino)
    '    dvciudad_destino = dtciudad_destino.DefaultView
    'End If
    ''
    'grilla_ciudad_destino()
    'End Sub

    'Private Sub cmbaddciudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim fila, lciudad As Long
    '    Try
    '        ' Añade una ciudad, si no está
    '        If cmbaddciudad.SelectedValue > 0 Then
    '            For fila = 0 To DataGridView2.Rows.Count - 1
    '                lciudad = CType(DataGridView2.Rows(fila).Cells("Idunidad_Agencia").Value, Long)
    '                If CType(cmbaddciudad.SelectedValue, Long) = lciudad Then
    '                    ' Mensaje mejor  
    '                    MsgBox("La ciudad, ya existe", MsgBoxStyle.Information, "Adiciona ciudad")
    '                    cmbaddciudad.SelectedValue = 0
    '                    Exit Sub
    '                End If
    '            Next
    '            ' Grabando la ciudad 
    '            objsalidamovilreparto.idnro_salida = CType(Me.txtidnrosalida.Text, Long)
    '            objsalidamovilreparto.iduni_agencia_destino = CType(cmbaddciudad.SelectedValue, Long)
    '            If objsalidamovilreparto.fninserta_ciudad_destino = True Then
    '                rstciudad_destino = Nothing
    '                dtciudad_destino = Nothing
    '                dvciudad_destino = Nothing
    '                dtciudad_destino = New DataTable
    '                dvciudad_destino = New DataView
    '                '
    '                rstciudad_destino = New ADODB.Recordset
    '                rstciudad_destino = objsalidamovilreparto.cur_recupera_ciudad_destino
    '                oldaSalidamovil.Fill(dtciudad_destino, rstciudad_destino)
    '                dvciudad_destino = dtciudad_destino.DefaultView
    '                grilla_ciudad_destino()
    '            End If
    '        End If
    '        cmbaddciudad.SelectedValue = 0 ' Poniendo a su posición original 
    '        ' Falta eliminar 
    '    Catch ex As Exception
    '    End Try
    'End Sub
    Private Sub DataGridView2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'Try
        '    Dim dgrv_ciudad As DataGridViewRow
        '    Dim lidunidad_agencia As Long
        '    Dim lidnro_salida As Long
        '    dgrv_ciudad = Me.DataGridView2.CurrentRow()
        '    '''''''''''''
        '    If e.KeyCode = Keys.Delete Then
        '        lidunidad_agencia = CType(dgrv_ciudad.Cells("Idunidad_Agencia").Value, Long)
        '        If lidunidad_agencia = CType(Me.cmbDestinoreal.SelectedValue, Long) Then 'Validando la ciudad que no se fin el recorrido  
        '            MsgBox("No puede eliminar la está ciudad, por ser el destino final del bus", MsgBoxStyle.Information, "Salida de Bus")
        '            Exit Sub
        '        End If
        '        ' Eliminando la ciudad 
        '        objsalidamovilreparto.idnro_salida = CType(Me.txtidnrosalida.Text, Long)
        '        objsalidamovilreparto.iduni_agencia_destino = lidunidad_agencia
        '        If objsalidamovilreparto.fnelimina_ciudad_destino = True Then
        '            rstciudad_destino = Nothing
        '            dtciudad_destino = Nothing
        '            dvciudad_destino = Nothing
        '            dtciudad_destino = New DataTable
        '            dvciudad_destino = New DataView
        '            '
        '            rstciudad_destino = New ADODB.Recordset
        '            rstciudad_destino = objsalidamovilreparto.cur_recupera_ciudad_destino
        '            oldaSalidamovil.Fill(dtciudad_destino, rstciudad_destino)
        '            dvciudad_destino = dtciudad_destino.DefaultView
        '            grilla_ciudad_destino()
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de seguridad")
        'End Try
    End Sub
    Sub valida_hora()
        Dim shora As String
        N_errores = 0
        shora = CType(txthorasalida.Text, String)
        shora = validar_hora_salida(shora)
        If shora = "" Then
            txthorasalida.Text = shora
            txthorasalida.Focus()
            N_errores = 1
            Exit Sub
        End If
        txthorasalida.Text = shora
    End Sub
    Sub desactiva()
        Me.dtpfec_salida.Enabled = False
        Me.txthorasalida.Enabled = False
        Me.cmbmovil.Enabled = False
        Me.cmbchoferusuario.Enabled = False
        Me.cmbestado.Enabled = False
        ' Configuracion de iconos en general
        GrabarToolStripMenuItem.Visible = True
        GrabarToolStripMenuItem.Enabled = False
    End Sub
    Sub activa()
        Me.dtpfec_salida.Enabled = True
        Me.txthorasalida.Enabled = True
        Me.cmbmovil.Enabled = True
        Me.cmbchoferusuario.Enabled = True
        Me.cmbestado.Enabled = True
        ' Configuracion de iconos en general
        GrabarToolStripMenuItem.Visible = True
        GrabarToolStripMenuItem.Enabled = True
    End Sub
    Private Sub trefresco_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trefresco.Tick
        Try
            objsalidamovilreparto.idagencias = CType(Me.cmbagencia.SelectedValue, Long)
            If objsalidamovilreparto.fn_refresca_movil() Then
                'Mod.09/10/2009 -->Omendoza - Pasando al datahelper -  
                'If CType(objsalidamovilreparto.cur_refresca_salida_movil.Fields(0).Value, Long) = 1 Then
                If CType(objsalidamovilreparto.dt_cur_refresca_salida_movil.Rows(0).Item(0), Long) = 1 Then
                    recupera_salida_movil()
                    configurando_estados()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema salida móvil")
        End Try
    End Sub

    Private Sub btnrefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefrescar.Click
        Try
            objsalidamovilreparto.idagencias = CType(Me.cmbagencia.SelectedValue, Long)
            If objsalidamovilreparto.fn_refresca_movil() Then
                'Mod.09/10/2009 -->Omendoza - Pasando al datahelper -  
                'If CType(objsalidamovilreparto.cur_refresca_salida_movil.Fields(0).Value, Long) = 1 Then
                If CType(objsalidamovilreparto.dt_cur_refresca_salida_movil.Rows(0).Item(0), Long) = 1 Then
                    recupera_salida_movil()
                    configurando_estados()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema salida móvil")
        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem1.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem1.EnabledChanged, CancelarToolStripMenuItem7.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class
