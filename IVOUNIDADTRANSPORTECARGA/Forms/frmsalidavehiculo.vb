'Imports System.Drawing
'Imports System.Drawing.Drawing2D
'Imports System.Data.OleDb
Public Class frmsalidavehiculo


#Region "Variables"
    'Para connectar a la bd 
    'Dim oldaSalidaVehiculo As New OleDb.OleDbDataAdapter
    '
    'Dim rstorigen, rsttipo_servicio, rstruta, rstbus, rstusuario, rstestado, rstsalida_vehiculo As New ADODB.Recordset
    Dim dtorigen, dttipo_servicio, dtruta, dtbus, dtusuario, dtestado, dtsalida_vehiculo As New DataTable
    Dim dvorigen, dvruta, dvtipo_servicio, dvbus, dvusuario, dvestado, dvsalida_vehiculo As New DataView
    '
    Dim dtorigenreal, dtdestinoreal, dtciudad_add As New DataTable
    Dim dvorigenreal, dvdestinoreal, dvciudad_add As New DataView
    ' Recuperando las ciudades destino 
    '
    'Dim rstciudad_destino As New ADODB.Recordset
    '
    Dim dtciudad_destino As DataTable
    Dim dvciudad_destino As DataView
    '
    'Declarando la variable de control 
    Dim icontrol As Integer = 0
    ' Control de lectura
    Dim lee_salida_vehiculo As Boolean = True
    '26/03/2008 - Valida que pasa a la pantalla de mantenimiento 
    Dim lb_pasa As Boolean = False
    Dim iTotalKilometros As Double = 0
    Dim bInicio As Boolean
    Dim iDestino As Integer

    Public iLlamada As Integer = 0
    Dim bIngreso As Boolean
    Public hnd As Long
#End Region

#Region "Eventos del formulario"
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub frmsalidavehiculo_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frmsalidavehiculo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub frmsalidavehiculo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Dim lidunidad_agencia As Integer
            lee_salida_vehiculo = False

            'Cargando valores inciales al formulario 
            DTPFechaSeleccion.Value = dtoUSUARIOS.dfecha_sistema

            bInicio = True
            iDestino = 0
            If iLlamada = 1 Then
                Me.ShadowLabel1.Text = "Lista de Salida Despacho - Simulación"
            Else
                Me.ShadowLabel1.Text = "Lista de Salida Despacho"
            End If
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False
            ' 
            MenuTab.Items(0).Text = "Lista Salida"
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
            objsalidavehiculodespacho.idunidad_agencia_origen = dtoUSUARIOS.m_idciudad
            objsalidavehiculodespacho.fecha = dtoUSUARIOS.dfecha_sistema
            objsalidavehiculodespacho.simulado = IIf(iLlamada = 1, 1, 0)

            objsalidavehiculodespacho.fnLoad_salida_vehiculo()

            dtorigen = objsalidavehiculodespacho.dtOrigen
            dttipo_servicio = objsalidavehiculodespacho.dtTipoServicio
            dtruta = objsalidavehiculodespacho.dtRuta
            dtbus = objsalidavehiculodespacho.dtBus
            dtusuario = objsalidavehiculodespacho.dtUsuarioPersonal
            dtestado = objsalidavehiculodespacho.dtEstado
            dtsalida_vehiculo = objsalidavehiculodespacho.dtSalidaVehiculo

            'Copiando las unidades de agencia 
            dtorigenreal = dtorigen.Copy
            dtdestinoreal = dtorigen.Copy

            'Copia a la ciudad a insertar 
            dtciudad_add = dtorigen.Copy

            cmborigen.DataSource = dtorigen.DefaultView
            cmborigen.DisplayMember = "nombre_unidad"
            cmborigen.ValueMember = "idunidad_agencia"
            cmborigen.SelectedValue = dtoUSUARIOS.m_idciudad

            cmbtiposervicio.DataSource = dttipo_servicio.DefaultView
            cmbtiposervicio.DisplayMember = "tipo_servicio"
            cmbtiposervicio.ValueMember = "idtipo_servicio"
            cmbtiposervicio.SelectedValue = 0

            cmbrutahorario.DataSource = dtruta.DefaultView
            cmbrutahorario.DisplayMember = "nombre_ruta"
            cmbrutahorario.ValueMember = "idrutas"
            cmbrutahorario.SelectedValue = -1

            cmbbus.DataSource = dtbus.DefaultView
            cmbbus.DisplayMember = "NRO_UNIDAD_TRANSPORTE"
            cmbbus.ValueMember = "IDUNIDAD_TRANSPORTE"
            cmbbus.SelectedValue = 0

            cmbchoferusuario.DataSource = dtusuario.DefaultView
            cmbchoferusuario.DisplayMember = "nombre"
            cmbchoferusuario.ValueMember = "idusuario_personal"
            cmbchoferusuario.SelectedValue = 0

            cmbestado.DataSource = dtestado.DefaultView
            cmbestado.DisplayMember = "ESTADO_REGISTRO"
            cmbestado.ValueMember = "IDESTADO_REGISTRO"
            cmbestado.SelectedValue = 0

            cmbOrigenreal.DataSource = dtorigenreal.DefaultView
            cmbOrigenreal.DisplayMember = "nombre_unidad"
            cmbOrigenreal.ValueMember = "idunidad_agencia"
            cmbOrigenreal.SelectedValue = 0

            cmbDestinoreal.DataSource = dtdestinoreal.DefaultView
            cmbDestinoreal.DisplayMember = "nombre_unidad"
            cmbDestinoreal.ValueMember = "idunidad_agencia"
            cmbDestinoreal.SelectedValue = 0

            cmbaddciudad.DataSource = dtciudad_add.DefaultView
            cmbaddciudad.DisplayMember = "nombre_unidad"
            cmbaddciudad.ValueMember = "idunidad_agencia"
            cmbaddciudad.SelectedValue = 0

            grillaformato()

            Me.cmbtiposervicio.Enabled = False
            lee_salida_vehiculo = True

            bInicio = False

            bIngreso = False
            Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub
#End Region

#Region "Ficha Lista"
    Private Sub DTPFechaSeleccion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFechaSeleccion.ValueChanged
        If lee_salida_vehiculo Then
            recupera_salida_vehiculo()
        End If
    End Sub

    Private Sub cmborigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmborigen.SelectedIndexChanged
        If lee_salida_vehiculo Then
            bInicio = True
            recupera_salida_vehiculo()
        End If
    End Sub

    Sub recupera_salida_vehiculo()
        Try
            If lee_salida_vehiculo Then

                objsalidavehiculodespacho.iduni_agencia_origen = cmborigen.SelectedValue
                objsalidavehiculodespacho.fecha_salida = CType(DTPFechaSeleccion.Value, String)
                objsalidavehiculodespacho.simulado = IIf(iLlamada = 1, 1, 0)
                '
                If objsalidavehiculodespacho.fnrecupera_salida_vehiculo() Then
                    dtsalida_vehiculo = Nothing
                    dtsalida_vehiculo = New DataTable

                    dtruta = Nothing
                    dtruta = New DataTable

                    dtsalida_vehiculo = objsalidavehiculodespacho.dtSalidaVehiculo
                    dtruta = objsalidavehiculodespacho.dtRuta

                    cmbrutahorario.DataSource = dtruta.DefaultView
                    cmbrutahorario.DisplayMember = "nombre_ruta"
                    cmbrutahorario.ValueMember = "idrutas"
                    cmbrutahorario.SelectedValue = 0

                    ' Limpiando los valores 
                    'limpia_tabdatos()

                    grillaformato()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    'Sub limpia_tabdatos()
    '    txtidnrosalida.Text = ""
    '    cmbtiposervicio.SelectedValue = 1
    '    cmbrutahorario.SelectedValue = -666
    '    txthorasalida.Text = ""
    '    cmbbus.SelectedValue = -666
    '    cmbchoferusuario.SelectedValue = -666
    '    cmbOrigenreal.SelectedValue = -666
    '    cmbDestinoreal.SelectedValue = -666
    '    TxtRucTerc.Text = ""
    '    txtlicencia.Text = ""
    '    txtnomtercero.Text = ""
    '    txtmarcabus.Text = ""
    '    txtplacabus.Text = ""
    'End Sub

    Sub grillaformato()
        Try
            lee_salida_vehiculo = False

            DataGridView1.Columns.Clear()
            With DataGridView1
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .VirtualMode = True
                .ReadOnly = True
                .DataSource = dtsalida_vehiculo
                '.DataSource = dvsalida_vehiculo
            End With

            Dim iidnro_salida As New DataGridViewTextBoxColumn
            With iidnro_salida '0                
                .DataPropertyName = "nro_salida"
                .Name = "nro_salida"
                .HeaderText = "Nº Salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(iidnro_salida)

            Dim stipo_servicio As New DataGridViewTextBoxColumn
            With stipo_servicio '1                
                .DataPropertyName = "tipo_servicio"
                .Name = "tipo_servicio"
                .HeaderText = "Servicio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            DataGridView1.Columns.Add(stipo_servicio)

            Dim iinro_bus As New DataGridViewTextBoxColumn
            With iinro_bus '2                
                .DataPropertyName = "nro_unidad_transporte"
                .Name = "nro_unidad_transporte"
                .HeaderText = "Bus"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            DataGridView1.Columns.Add(iinro_bus)

            Dim sdestino As New DataGridViewTextBoxColumn
            With sdestino '3                 
                .DataPropertyName = "destino"
                .Name = "destino"
                .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(sdestino)

            Dim sfecha_salida As New DataGridViewTextBoxColumn
            With sfecha_salida  ' 4
                .DataPropertyName = "fecha_salida"
                .Name = "fecha_salida"
                .HeaderText = "Fecha Salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            DataGridView1.Columns.Add(sfecha_salida)

            Dim shora_salida As New DataGridViewTextBoxColumn
            With shora_salida '5
                .DataPropertyName = "hora_salida"
                .Name = "hora_salida"
                .HeaderText = "Hora Salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            DataGridView1.Columns.Add(shora_salida)

            Dim sestado As New DataGridViewTextBoxColumn
            With sestado   '6
                .DataPropertyName = "estado_registro"
                .Name = "estado_registro"
                .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            DataGridView1.Columns.Add(sestado)

            Dim idestado As New DataGridViewTextBoxColumn
            With idestado '  7
                .DataPropertyName = "estado"
                .Name = "estado"
                .HeaderText = "Idestado"
                .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(idestado)

            Dim iidrutahorario As New DataGridViewTextBoxColumn
            With iidrutahorario '  8
                .DataPropertyName = "Ruta_horario"
                .Name = "Ruta_horario"
                .HeaderText = "IdRutaHorario"
                .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(iidrutahorario)

            Dim iidtipo_servicio As New DataGridViewTextBoxColumn
            With iidtipo_servicio '  9
                .DataPropertyName = "idtipo_servicio"
                .Name = "idtipo_servicio"
                .HeaderText = "Idtiposervicio"
                .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(iidtipo_servicio)

            Dim iidunidad_transporte As New DataGridViewTextBoxColumn
            With iidunidad_transporte '  10
                .DataPropertyName = "idunidad_transporte"
                .Name = "idunidad_transporte"
                .HeaderText = "Idunidad_transporte"
                .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(iidunidad_transporte)

            Dim iidpiloto As New DataGridViewTextBoxColumn
            With iidpiloto '  11
                .DataPropertyName = "usuario_chofer"
                .Name = "usuario_chofer"
                .HeaderText = "idusuario_chofer"
                .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(iidpiloto)

            Dim iidunidad_agencia_origen As New DataGridViewTextBoxColumn
            With iidunidad_agencia_origen '  12
                .DataPropertyName = "idunidad_agencia_origen"
                .Name = "idunidad_agencia_origen"
                .HeaderText = "Agencia Origen"
                .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(iidunidad_agencia_origen)

            Dim iidunidad_agencia_destino As New DataGridViewTextBoxColumn
            With iidunidad_agencia_destino '  13
                .DataPropertyName = "idunidad_agencia_destino"
                .Name = "idunidad_agencia_destino"
                .HeaderText = "Agencia Destino"
                .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(iidunidad_agencia_destino)

            Dim sruc_tercero As New DataGridViewTextBoxColumn
            With sruc_tercero '  14
                .DataPropertyName = "ruc_tercero"
                .Name = "ruc_tercero"
                .HeaderText = "RUC"
                .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(sruc_tercero)

            Dim snom_tercero As New DataGridViewTextBoxColumn
            With snom_tercero '  15
                .DataPropertyName = "nom_tercero"
                .Name = "nom_tercero"
                .HeaderText = "Nombre Tercero"
                .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(snom_tercero)

            Dim snro_licencia As New DataGridViewTextBoxColumn
            With snro_licencia '  16
                .DataPropertyName = "nro_licencia"
                .Name = "nro_licencia"
                .HeaderText = "Licencia"
                .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(snro_licencia)

            Dim smarca_bus As New DataGridViewTextBoxColumn
            With smarca_bus '  17
                .DataPropertyName = "marca_bus"
                .Name = "marca_bus"
                .HeaderText = "Marca Bus"
                .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(smarca_bus)

            Dim splaca_bus As New DataGridViewTextBoxColumn
            With splaca_bus '  17
                .DataPropertyName = "placa_bus"
                .Name = "placa_bus"
                .HeaderText = "Placa"
                .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(splaca_bus)

            Dim smargen As New DataGridViewTextBoxColumn
            With smargen '  17
                .DataPropertyName = "margen"
                .Name = "margen"
                .HeaderText = "Margen"
                .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            DataGridView1.Columns.Add(smargen)

            lee_salida_vehiculo = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    '--------------------- Nuevo --------------------------
    Private Sub frmsalidavehiculo_MenuNuevo() Handles Me.MenuNuevo
        Try
            MenuTab.Items(0).Enabled = False
            MenuTab.Items(1).Enabled = True

            'Configuracion de iconos en general
            GrabarToolStripMenuItem.Enabled = True
            GrabarToolStripMenuItem.Visible = True

            Me.cmbaddciudad.Enabled = False

            'Un valor por defecto q' y obligue a elegir
            cmbrutahorario.SelectedValue = -1
            cmbtiposervicio.SelectedValue = 0
            cmbrutahorario.SelectedValue = -1
            cmbbus.SelectedValue = 0
            cmbchoferusuario.SelectedValue = 0

            'El estado sera creado por defecto
            cmbestado.SelectedValue = 33

            cmbOrigenreal.Enabled = False
            cmbOrigenreal.BackColor = System.Drawing.SystemColors.Info
            cmbOrigenreal.SelectedValue = 0

            cmbDestinoreal.Enabled = False
            cmbDestinoreal.BackColor = System.Drawing.SystemColors.Info
            cmbDestinoreal.SelectedValue = 0

            cmbaddciudad.SelectedValue = 0

            txthorasalida.Text = "00:00"
            TxtTimeHor.Text = "00:00"

            TxtRucTerc.ReadOnly = True
            TxtRucTerc.BackColor = System.Drawing.SystemColors.Info
            TxtRucTerc.Text = ""

            txtnomtercero.ReadOnly = True
            txtnomtercero.BackColor = System.Drawing.SystemColors.Info
            txtnomtercero.Text = ""

            txtlicencia.ReadOnly = True
            txtlicencia.BackColor = System.Drawing.SystemColors.Info
            txtlicencia.Text = ""

            txtmarcabus.ReadOnly = True
            txtmarcabus.BackColor = System.Drawing.SystemColors.Info
            txtmarcabus.Text = ""

            txtplacabus.ReadOnly = True
            txtplacabus.BackColor = System.Drawing.SystemColors.Info
            txtplacabus.Text = ""

            txtKilometraje.ReadOnly = True
            txtKilometraje.BackColor = System.Drawing.SystemColors.Info
            txtKilometraje.Text = 0

            Labnrosalida.Visible = False
            txtidnrosalida.Visible = False
            DataGridView2.DataSource = Nothing

            icontrol = 1

            'Me.SelectMenu(1)
            'MenuTab.Items(1).Enabled = True
            'SplitContainer2.Panel1Collapsed = True

            'GrabarToolStripMenuItem.Visible = True
            'GrabarToolStripMenuItem.Enabled = True



            '' Cuando se cree, siempre va a estar en vigencia 
            'chkvigente.Checked = True
            ''Control  

            'If objsalidavehiculodespacho.fnget_ciudad_destino_vacio_2 = True Then
            '    'rstciudad_destino = Nothing
            '    dtciudad_destino = Nothing
            '    dvciudad_destino = Nothing
            '    dtciudad_destino = New DataTable
            '    dvciudad_destino = New DataView

            '    dtciudad_destino = objsalidavehiculodespacho.dt_cur_recupera_ciudad_destino
            '    dvciudad_destino = dtciudad_destino.DefaultView
            'End If
            ''
            'grilla_ciudad_destino()

            '

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema")
        End Try
    End Sub
    '------------------------------------------------------

    '--------------------- Editar -------------------------
    Private Sub frmsalidavehiculo_MenuEditar() Handles Me.MenuEditar
        Dim filarow As Integer
        Dim dgrvsalidavehiculo As DataGridViewRow
        Dim ll_codigo As Long
        Dim ls_mensaje As String
        Try
            MenuTab.Items(0).Enabled = False
            MenuTab.Items(1).Enabled = True

            icontrol = 0
            filarow = DataGridView1.CurrentRow.Index
            If filarow < 0 Then
                Exit Sub
            End If
            dgrvsalidavehiculo = DataGridView1.CurrentRow

            Labnrosalida.Visible = True
            txtidnrosalida.Visible = True
            txtidnrosalida.ReadOnly = True

            Me.txtidnrosalida.Text = CType(dgrvsalidavehiculo.Cells("nro_salida").Value, String)

            objsalidavehiculodespacho.idnro_salida = CType(Me.txtidnrosalida.Text, Long)
            objsalidavehiculodespacho.fecha_salida = dtoUSUARIOS.dfecha_sistema

            If objsalidavehiculodespacho.fn_verifica_salida() = True Then
                ll_codigo = CType(objsalidavehiculodespacho.dt_cur_datos.Rows(0).Item(0), Long)
                ls_mensaje = CType(objsalidavehiculodespacho.dt_cur_datos.Rows(0).Item(1), String)
                If ll_codigo <> 0 Then
                    MsgBox(ls_mensaje, MsgBoxStyle.Information, "Salida Vehículo Despacho")
                    Me.txtidnrosalida.Text = ""
                    lb_pasa = True
                    Exit Sub
                End If
            End If

            Me.cmbbus.SelectedValue = CType(dgrvsalidavehiculo.Cells("idunidad_transporte").Value, Long)
            cmbtiposervicio.SelectedValue = CType(dgrvsalidavehiculo.Cells("idtipo_servicio").Value, String)

            If "SIN RUTA" = CType(dgrvsalidavehiculo.Cells("Ruta_horario").Value, String) Then
                Me.cmbrutahorario.SelectedValue = 0
            Else
                Me.cmbrutahorario.SelectedValue = CType(dgrvsalidavehiculo.Cells("Ruta_horario").Value, String)
            End If

            If CType(dgrvsalidavehiculo.Cells("usuario_chofer").Value, Long) = -666 Then
                Me.cmbchoferusuario.SelectedValue = 0
            Else
                Me.cmbchoferusuario.SelectedValue = CType(dgrvsalidavehiculo.Cells("usuario_chofer").Value, Long)
            End If

            Me.dtpfec_salida.Value = CType(dgrvsalidavehiculo.Cells("fecha_salida").Value, String)
            Me.txthorasalida.Text = CType(dgrvsalidavehiculo.Cells("hora_salida").Value, String)

            cmbestado.SelectedValue = CType(dgrvsalidavehiculo.Cells("estado").Value, Long)
            cmbOrigenreal.SelectedValue = CType(dgrvsalidavehiculo.Cells("idunidad_agencia_origen").Value, Long)
            cmbDestinoreal.SelectedValue = CType(dgrvsalidavehiculo.Cells("idunidad_agencia_destino").Value, Long)

            TxtTimeHor.Text = IIf(IsDBNull(dgrvsalidavehiculo.Cells("margen").Value) = True, "00:00", dgrvsalidavehiculo.Cells("margen").Value)

            TxtRucTerc.Text = IIf(IsDBNull(dgrvsalidavehiculo.Cells("ruc_tercero").Value) = True, "", dgrvsalidavehiculo.Cells("ruc_tercero").Value)
            txtnomtercero.Text = IIf(IsDBNull(dgrvsalidavehiculo.Cells("nom_tercero").Value) = True, "", dgrvsalidavehiculo.Cells("nom_tercero").Value)

            If txtlicencia.Text = "" Then
                txtlicencia.Text = IIf(IsDBNull(dgrvsalidavehiculo.Cells("nro_licencia").Value) = True, "", dgrvsalidavehiculo.Cells("nro_licencia").Value)
            End If

            txtmarcabus.Text = IIf(IsDBNull(dgrvsalidavehiculo.Cells("marca_bus").Value) = True, "", dgrvsalidavehiculo.Cells("marca_bus").Value)
            txtplacabus.Text = IIf(IsDBNull(dgrvsalidavehiculo.Cells("placa_bus").Value) = True, "", dgrvsalidavehiculo.Cells("placa_bus").Value)

            'Recupera la ciudad del destino 
            recupera_ciudad_destino()

            'Configuracion de iconos en general
            GrabarToolStripMenuItem.Enabled = True
            GrabarToolStripMenuItem.Visible = True

            'Desahabilita la ciudad destino 
            Me.cmbaddciudad.Enabled = True

            bInicio = False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de seguridad")
        End Try
    End Sub

    Sub recupera_ciudad_destino()
        objsalidavehiculodespacho.idnro_salida = CType(Me.txtidnrosalida.Text, Long)
        objsalidavehiculodespacho.idunidad_agencia_origen = cmborigen.SelectedValue

        If objsalidavehiculodespacho.fnget_ciudad_destino_2 = True Then
            grilla_ciudad_destino()
        End If

        If DataGridView2.Rows.Count > 0 Then
            GeneraKilometros()
        End If
    End Sub

    Sub grilla_ciudad_destino()
        Try
            DataGridView2.Columns.Clear()

            With DataGridView2
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .VirtualMode = True
                .ReadOnly = True
                .DataSource = objsalidavehiculodespacho.dt_cur_recupera_ciudad_destino
                .Columns(1).Visible = False
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Catch ex As Exception
            '
        End Try
    End Sub

    Private Sub GeneraKilometros()
        Dim origen As Integer = 0
        Dim destino As Integer = 0
        Dim agencia As Integer = 0
        Dim s As String

        With DataGridView2
            For i As Integer = -1 To .Rows.Count - 1
                If i = -1 Then
                    origen = cmborigen.SelectedValue
                Else
                    agencia = .Rows(i).Cells(1).Value
                    If origen = 0 Then
                        origen = agencia
                    ElseIf destino = 0 Then
                        destino = agencia
                    End If
                End If
                If origen > 0 And destino > 0 Then
                    s = s & "(t_rutas.idunidad_agencia=" & origen & " and t_rutas.idunidad_agencia_destino=" & destino & ") or "
                    origen = destino
                    destino = 0
                End If
            Next
            If s.Length > 0 Then
                s = s.Substring(0, s.Length - 4)
                s = "(" & s & ")"
            End If

            LimpiarKilometros()
            iTotalKilometros = 0

            Dim objKilometros As New dtosalidavehiculo
            If objKilometros.fnget_kilometros(s) Then
                'Mod.09/10/2009 -->Omendoza - Pasando al datahelper -  
                'Dim rs As ADODB.Recordset
                Dim ldt_tmp As New DataTable
                'rs = New ADODB.Recordset
                'rs = objKilometros.cur_kilometros
                'If rs.BOF = False And rs.EOF = False Then
                ldt_tmp = objKilometros.dt_cur_kilometros
                If ldt_tmp.Rows.Count > 0 Then
                    'Do While rs.BOF = False And rs.EOF = False
                    For Each fila As DataRow In ldt_tmp.Rows
                        'BuscaDestino(rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value)
                        BuscaDestino(fila.Item(0), fila.Item(1), fila.Item(2))
                        iTotalKilometros += fila.Item(1)
                        'rs.MoveNext()
                    Next
                    'actualizar tiempos entre origen y destino
                    Dim i As Integer
                    Dim sDias As Date
                    Dim iHoras As Integer
                    Dim iMinutos As Integer

                    Dim sDia As Date
                    Dim iHora As Integer
                    Dim iMinuto As Integer

                    With DataGridView2
                        sDia = DTPicfecllegada.Value.Now
                        iHora = Val(txthorasalida.Text.Substring(0, 2))
                        iMinuto = Val(txthorasalida.Text.Substring(3, 2))
                        For i = 0 To .Rows.Count - 1
                            If Val(.Rows(i).Cells(5).Value) > 0 Then
                                iHoras = .Rows(i).Cells(5).Value.ToString.Substring(0, 2)
                                iMinutos = .Rows(i).Cells(5).Value.ToString.Substring(3, 2)
                            Else
                                iHoras = 0
                                iMinutos = 0
                            End If
                            If iMinutos + iMinuto >= 60 Then
                                iHoras += 1
                                iMinutos = ((iMinutos + iMinuto) - 60)
                                iHoras += iHora
                                If iHoras >= 24 Then
                                    sDia = DateAdd(DateInterval.Day, 1, sDia)
                                    iHoras = iHoras - 24
                                End If
                            Else
                                iMinutos += iMinuto
                                iHoras += iHora
                                If iHoras >= 24 Then
                                    sDia = DateAdd(DateInterval.Day, 1, sDia)
                                    iHoras = iHoras - 24
                                End If
                            End If
                            If Val(TxtTimeHor.Text) > 0 Then
                                Dim iHoras2 As Integer
                                Dim iMinutos2 As Integer

                                iHoras2 = TxtTimeHor.Text.ToString.Substring(0, 2)
                                iMinutos2 = TxtTimeHor.Text.ToString.Substring(3, 2)
                                If iMinutos2 + iMinutos >= 60 Then
                                    iHoras += 1
                                    iMinutos = ((iMinutos + iMinutos2) - 60)
                                    iHoras += iHoras2
                                    If iHoras >= 24 Then
                                        sDia = DateAdd(DateInterval.Day, 1, sDia)
                                        iHoras = iHoras - 24
                                    End If
                                Else
                                    iMinutos += iMinutos2
                                    iHoras += iHoras2
                                    If iHoras >= 24 Then
                                        sDia = DateAdd(DateInterval.Day, 1, sDia)
                                        iHoras = iHoras - 24
                                    End If
                                End If
                            Else
                                'TxtTimeHor.Text = "00:00"
                            End If

                            .Rows(i).Cells(3).Value = sDia.ToShortDateString
                            .Rows(i).Cells(4).Value = Format(iHoras, "00") & ":" & Format(iMinutos, "00")
                            iHora = iHoras
                            iMinuto = iMinutos
                        Next
                    End With
                End If
                txtKilometraje.Text = FormatNumber(iTotalKilometros, 2)
            End If
        End With
        DTPicfecllegada.Value = IIf(IsDate(DataGridView2.Rows(DataGridView2.Rows.Count - 1).Cells(3).Value), DataGridView2.Rows(DataGridView2.Rows.Count - 1).Cells(3).Value, DTPicfecllegada.Value)
    End Sub

    Private Sub LimpiarKilometros()
        Dim i As Integer

        With DataGridView2
            For i = 0 To .Rows.Count - 1
                .Rows(i).Cells(2).Value = "0.00"
            Next
        End With
    End Sub

    Private Sub BuscaDestino(ByVal destino As Integer, ByVal kilometros As Double, ByVal horas As String)
        Dim i As Integer
        With DataGridView2
            For i = 0 To .Rows.Count - 1
                If .Rows(i).Cells(1).Value = destino Then
                    .Rows(i).Cells(2).Value = Format(kilometros, "0.00")
                    .Rows(i).Cells(5).Value = horas
                    Exit Sub
                End If
            Next
        End With
    End Sub
    '------------------------------------------------------

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        If iLlamada = 1 Then
            Dim iDocumento As Integer = DataGridView1.SelectedRows.Item(0).Index()

            Dim iBus As Integer = DataGridView1.Rows(iDocumento).Cells(2).Value
            Dim iSalida As Integer = DataGridView1.Rows(iDocumento).Cells(0).Value
            Dim sEstado As String = DataGridView1.Rows(iDocumento).Cells(6).Value

            If Not (sEstado.ToString.Trim = "CREADO" Or sEstado.Trim = "ACTIVO" Or sEstado.Trim = "CIERRE BODEGA") Then
                MessageBox.Show("El Bus no se encuentra creado,activo ni con cierre de bodega en salida.", "Titán", MessageBoxButtons.OK)
                Return
            End If
            FrmSimuladorCarga.iBus = iBus
            FrmSimuladorCarga.iSalida = iSalida
            Me.Close()
        End If
    End Sub

    '--------------------- Actualización de Estados de la Salida de los Buses -------------------------
    Private Sub ActivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActivoToolStripMenuItem.Click
        Dim sIDNRO_SALIDA As String
        Dim dgrvsalidavehiculo As DataGridViewRow
        Dim filarow As Integer
        Dim lestado, lnro_salida As Long
        Dim rstcontrol As New ADODB.Recordset
        Dim lcodigo As Long
        Try
            icontrol = 0
            filarow = DataGridView1.CurrentRow.Index
            If filarow < 0 Then
                MessageBox.Show("No seleccionado ningún registro", "Salida Vehículo Despacho", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            dgrvsalidavehiculo = DataGridView1.CurrentRow
            lnro_salida = CType(dgrvsalidavehiculo.Cells("nro_salida").Value, String)
            lestado = 34 'Activado, solo activa los buses q' esten creado
            objsalidavehiculodespacho.idnro_salida = lnro_salida
            objsalidavehiculodespacho.estado = lestado

            If objsalidavehiculodespacho.fnactualiza_estado_salida_vehiculo(dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP) Then
                bInicio = True
                lcodigo = CType(objsalidavehiculodespacho.dt_cur_actualiza_estado.Rows(0).Item(0), Integer)

                ModSolRecojoCarga.smensaje = CType(objsalidavehiculodespacho.dt_cur_actualiza_estado.Rows(0).Item(1), String)
                MessageBox.Show(ModSolRecojoCarga.smensaje, "Salida Vehículo Despacho", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            recupera_salida_vehiculo()
            configurando_estados()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub CierreBodegaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CierreBodegaToolStripMenuItem.Click
        Dim sIDNRO_SALIDA As String
        Dim dgrvsalidavehiculo As DataGridViewRow
        Dim filarow As Integer
        Dim lestado, lnro_salida As Long
        Dim rstcontrol As New ADODB.Recordset
        Dim lcodigo As Long
        Try
            icontrol = 0
            filarow = DataGridView1.CurrentRow.Index
            If filarow < 0 Then
                MessageBox.Show("No seleccionado ningún registro", "Salida Vehículo Despacho", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            dgrvsalidavehiculo = DataGridView1.CurrentRow
            lnro_salida = CType(dgrvsalidavehiculo.Cells("nro_salida").Value, String)
            lestado = 39 'Cierre de la bodega para que se pueda generar la guia de transportista 
            objsalidavehiculodespacho.idnro_salida = lnro_salida
            objsalidavehiculodespacho.estado = lestado

            If objsalidavehiculodespacho.fnactualiza_estado_salida_vehiculo(dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP) Then
                bInicio = True
                lcodigo = CType(objsalidavehiculodespacho.dt_cur_actualiza_estado.Rows(0).Item(0), Integer)

                ModSolRecojoCarga.smensaje = CType(objsalidavehiculodespacho.dt_cur_actualiza_estado.Rows(0).Item(1), String)
                MessageBox.Show(ModSolRecojoCarga.smensaje, "Salida Vehículo Despacho", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            recupera_salida_vehiculo()
            configurando_estados()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub DespachadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DespachadoToolStripMenuItem.Click
        Dim sIDNRO_SALIDA As String
        Dim dgrvsalidavehiculo As DataGridViewRow
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

            dgrvsalidavehiculo = DataGridView1.CurrentRow
            lnro_salida = CType(dgrvsalidavehiculo.Cells("nro_salida").Value, String)
            lestado = 35 ' Despachado
            objsalidavehiculodespacho.idnro_salida = lnro_salida
            objsalidavehiculodespacho.estado = lestado

            If objsalidavehiculodespacho.fnactualiza_estado_salida_vehiculo(dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP) Then
                bInicio = True
                lcodigo = CType(objsalidavehiculodespacho.dt_cur_actualiza_estado.Rows(0).Item(0), Integer)

                ModSolRecojoCarga.smensaje = CType(objsalidavehiculodespacho.dt_cur_actualiza_estado.Rows(0).Item(1), String)
                MessageBox.Show(ModSolRecojoCarga.smensaje, "Salida Vehículo Despacho", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            recupera_salida_vehiculo()
            configurando_estados()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
        '
    End Sub

    Private Sub RecepciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecepciónToolStripMenuItem.Click
        Dim sIDNRO_SALIDA As String
        Dim dgrvsalidavehiculo As DataGridViewRow
        Dim filarow As Integer
        Dim lestado, lnro_salida As Long
        Dim rstcontrol As ADODB.Recordset
        Dim lcodigo As Long
        Try
            icontrol = 0
            filarow = DataGridView1.CurrentRow.Index
            If filarow < 0 Then
                MessageBox.Show("No seleccionado ningún registro", "Salida Vehículo Despacho", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            dgrvsalidavehiculo = DataGridView1.CurrentRow
            lnro_salida = CType(dgrvsalidavehiculo.Cells("nro_salida").Value, String)
            lestado = 36 'RECEPCION CARGA 
            objsalidavehiculodespacho.idnro_salida = lnro_salida
            objsalidavehiculodespacho.estado = lestado

            If objsalidavehiculodespacho.fnactualiza_estado_salida_vehiculo(dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP) Then
                bInicio = True
                lcodigo = CType(objsalidavehiculodespacho.dt_cur_actualiza_estado.Rows(0).Item(0), Integer)

                ModSolRecojoCarga.smensaje = CType(objsalidavehiculodespacho.dt_cur_actualiza_estado.Rows(0).Item(1), String)
                MessageBox.Show(ModSolRecojoCarga.smensaje, "Salida Vehículo Despacho", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            recupera_salida_vehiculo()
            configurando_estados()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub FinalizarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FinalizarToolStripMenuItem.Click
        Dim sIDNRO_SALIDA As String
        Dim dgrvsalidavehiculo As DataGridViewRow
        Dim filarow As Integer
        Dim lestado, lnro_salida As Long
        Dim rstcontrol As ADODB.Recordset
        Dim lcodigo As Long
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
            lestado = 37 'DESTINO FINAL 
            objsalidavehiculodespacho.idnro_salida = lnro_salida
            objsalidavehiculodespacho.estado = lestado

            If objsalidavehiculodespacho.fnactualiza_estado_salida_vehiculo(dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP) Then
                bInicio = True
                lcodigo = CType(objsalidavehiculodespacho.dt_cur_actualiza_estado.Rows(0).Item(0), Integer)

                ModSolRecojoCarga.smensaje = CType(objsalidavehiculodespacho.dt_cur_actualiza_estado.Rows(0).Item(1), String)
                MessageBox.Show(ModSolRecojoCarga.smensaje, "Salida Vehículo Despacho", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            recupera_salida_vehiculo()
            configurando_estados()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub AnuladoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnuladoToolStripMenuItem.Click
        Dim sIDNRO_SALIDA As String
        Dim dgrvsalidavehiculo As DataGridViewRow
        Dim filarow As Integer
        Dim lestado, lnro_salida As Long
        Dim rstcontrol As ADODB.Recordset
        Dim lcodigo As Long
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
            lestado = 38 'ANULADO 
            objsalidavehiculodespacho.idnro_salida = lnro_salida
            objsalidavehiculodespacho.estado = lestado
            If objsalidavehiculodespacho.fnactualiza_estado_salida_vehiculo(dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP) Then
                bInicio = True
                lcodigo = CType(objsalidavehiculodespacho.dt_cur_actualiza_estado.Rows(0).Item(0), Integer)

                ModSolRecojoCarga.smensaje = CType(objsalidavehiculodespacho.dt_cur_actualiza_estado.Rows(0).Item(1), String)
                MessageBox.Show(ModSolRecojoCarga.smensaje, "Salida Vehículo Despacho", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            recupera_salida_vehiculo()
            configurando_estados()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    '--------------------------------------------------------------------------------------------------
#End Region

#Region "Ficha Mantenimiento"
    Private Sub cmbbus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbus.SelectedIndexChanged
        Dim Indice As Integer = 0
        Dim IdTipoServicio As Integer = 0
        Try
            If lee_salida_vehiculo = True Then
                Indice = cmbbus.SelectedIndex
                IdTipoServicio = IIf(IsDBNull(dtbus.Rows(Indice).Item("IdTipo_Servicio")) = True, 0, Convert.ToInt32(dtbus.Rows(Indice).Item("IdTipo_Servicio").ToString))

                If Not IsDBNull(dttipo_servicio) Then
                    If dttipo_servicio.Rows.Count > 0 Then
                        cmbtiposervicio.SelectedValue = IdTipoServicio
                    End If

                    txtplacabus.Text = IIf(IsDBNull(dtbus.Rows(Indice).Item("Placa")) = True, "", dtbus.Rows(Indice).Item("Placa").ToString)
                    txtmarcabus.Text = IIf(IsDBNull(dtbus.Rows(Indice).Item("MODELO_MOVIL")) = True, "", dtbus.Rows(Indice).Item("MODELO_MOVIL").ToString)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub cmbtiposervicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtiposervicio.SelectedIndexChanged
        Try
            If lee_salida_vehiculo = True Then
                Select Case CType(cmbtiposervicio.SelectedValue, Integer)
                    Case 4, 5, 6, 9, 10, 11 'Tepsa  '4 = Presidencial, 5 = Premier, 6 = Clasico, 9 = Presidencial Cama, 10 = Presidencial 40
                        cmbrutahorario.BackColor = Color.White
                        cmbrutahorario.SelectedValue = -1
                        cmbrutahorario.Enabled = True

                        cmbOrigenreal.BackColor = System.Drawing.SystemColors.Info
                        cmbOrigenreal.SelectedValue = 0
                        cmbOrigenreal.Enabled = False

                        cmbDestinoreal.BackColor = System.Drawing.SystemColors.Info
                        cmbDestinoreal.SelectedValue = 0
                        cmbDestinoreal.Enabled = False

                        cmbchoferusuario.Enabled = True

                        TxtRucTerc.ReadOnly = True
                        TxtRucTerc.BackColor = System.Drawing.SystemColors.Info
                        TxtRucTerc.Text = ""

                        txtnomtercero.ReadOnly = True
                        txtnomtercero.BackColor = System.Drawing.SystemColors.Info
                        txtnomtercero.Text = ""

                        txtlicencia.ReadOnly = True
                        txtlicencia.BackColor = System.Drawing.SystemColors.Info

                        txtmarcabus.ReadOnly = True
                        txtplacabus.ReadOnly = True
                    Case 2 'Carguero 
                        'Por no encontrarse en un ruta establecida
                        cmbrutahorario.Enabled = False
                        cmbrutahorario.BackColor = System.Drawing.SystemColors.Info
                        cmbrutahorario.SelectedValue = 0

                        cmbOrigenreal.Enabled = True
                        cmbOrigenreal.BackColor = Color.White
                        cmbOrigenreal.SelectedValue = dtoUSUARIOS.m_idciudad

                        cmbDestinoreal.Enabled = True
                        cmbDestinoreal.BackColor = Color.White
                        cmbDestinoreal.SelectedValue = 0

                        cmbchoferusuario.Enabled = True

                        TxtRucTerc.ReadOnly = True
                        TxtRucTerc.BackColor = System.Drawing.SystemColors.Info
                        TxtRucTerc.Text = ""

                        txtnomtercero.ReadOnly = True
                        txtnomtercero.BackColor = System.Drawing.SystemColors.Info
                        txtnomtercero.Text = ""

                        txtlicencia.ReadOnly = True
                        txtlicencia.BackColor = System.Drawing.SystemColors.Info

                        txtmarcabus.ReadOnly = True
                        txtplacabus.ReadOnly = True
                    Case 3 'Por empresa de tercero 
                        'Por no encontrarse en un ruta establecida Por el carguero.
                        cmbrutahorario.Enabled = False
                        cmbrutahorario.BackColor = System.Drawing.SystemColors.Info
                        cmbrutahorario.SelectedValue = 0

                        cmbOrigenreal.Enabled = True
                        cmbOrigenreal.BackColor = Color.White
                        cmbOrigenreal.SelectedValue = dtoUSUARIOS.m_idciudad

                        cmbDestinoreal.Enabled = True
                        cmbDestinoreal.BackColor = Color.White
                        cmbDestinoreal.SelectedValue = 0

                        'El chofer no es de la empresa.
                        cmbchoferusuario.SelectedValue = 0
                        cmbchoferusuario.Enabled = False

                        TxtRucTerc.ReadOnly = False
                        TxtRucTerc.Enabled = True
                        TxtRucTerc.BackColor = Color.White

                        txtnomtercero.ReadOnly = False
                        txtnomtercero.Enabled = True
                        txtnomtercero.BackColor = Color.White

                        txtlicencia.ReadOnly = False
                        txtlicencia.Enabled = True
                        txtlicencia.BackColor = Color.White
                        txtlicencia.Text = ""
                    Case 8 'transferencia zonal
                        cmbrutahorario.SelectedValue = 0
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub cmbruta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbrutahorario.SelectedIndexChanged
        Dim Indice As Integer
        Try
            If lee_salida_vehiculo = True Then
                Indice = cmbrutahorario.SelectedIndex

                If Not IsDBNull(dtruta) Then
                    If dtruta.Rows.Count > 0 Then
                        cmbOrigenreal.SelectedValue = IIf(IsDBNull(dtruta.Rows(Indice).Item("idunidad_agencia")) = True, 0, Convert.ToInt32(dtruta.Rows(Indice).Item("idunidad_agencia").ToString))
                        cmbDestinoreal.SelectedValue = IIf(IsDBNull(dtruta.Rows(Indice).Item("idunidad_agencia_destino")) = True, 0, Convert.ToInt32(dtruta.Rows(Indice).Item("idunidad_agencia_destino").ToString))
                        txthorasalida.Text = IIf(IsDBNull(dtruta.Rows(Indice).Item("hora")) = True, "00:00", dtruta.Rows(Indice).Item("hora").ToString)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub cmbchoferusuario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbchoferusuario.SelectedIndexChanged
        Dim Indice As Integer
        Dim snombre, slicencia As String
        Dim drvusuario As DataRowView
        Try
            If lee_salida_vehiculo = True Then
                Indice = cmbchoferusuario.SelectedIndex

                If Not IsDBNull(dtusuario) Then
                    If dtusuario.Rows.Count > 0 Then
                        txtlicencia.Text = IIf(IsDBNull(dtusuario.Rows(Indice).Item("nro_licencia")) = True, "", dtusuario.Rows(Indice).Item("nro_licencia").ToString)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub TxtRucTerc_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRucTerc.Validated
        If TxtRucTerc.Text.Length = 11 Then
            If TxtRucTerc.Text.Trim.Substring(0, 2) = "20" Or TxtRucTerc.Text.Trim.Substring(0, 2) = "10" Then
                If fnValidarRUC(TxtRucTerc.Text) = False Then
                    MsgBox("El RUC no válido para la SUNAT, Revise el RUC", MsgBoxStyle.Information, "Seguridad Sistema")
                End If
            Else
                MessageBox.Show("El RUC no válido para la SUNAT, Revise el RUC", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Else
            MessageBox.Show("El Nro. RUC no es válido debe de tener 11 dígitos, Revise el RUC", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub txthorasalida_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthorasalida.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
        Else
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = ":" And InStr(tb.Text, ":") = 0) Then
                e.Handled = False
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txthorasalida_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txthorasalida.Validating
        Dim shora As String
        shora = CType(txthorasalida.Text, String)
        shora = validar_hora_salida(shora)
        If shora = "" Then
            txthorasalida.Text = "00:00"
            txthorasalida.Focus()
            Exit Sub
        End If
        txthorasalida.Text = shora
    End Sub

    Private Sub TxtTimeHor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTimeHor.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
        Else
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = ":" And InStr(tb.Text, ":") = 0) Then
                e.Handled = False
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtTimeHor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtTimeHor.Validating
        Dim shora As String
        shora = CType(TxtTimeHor.Text, String)
        shora = validar_hora_salida(shora)
        If shora = "" Then
            TxtTimeHor.Text = "00:00"
            TxtTimeHor.Focus()
            Exit Sub
        End If
        TxtTimeHor.Text = shora
    End Sub

    '--------------------- Grabar -------------------------
    Private Sub frmsalidavehiculo_MenuGrabar() Handles Me.MenuGrabar
        Dim icodigo As Integer
        dtciudad_destino = Nothing
        dvciudad_destino = Nothing
        Try
            ' Verificar que campos son importantes
            bInicio = True

            If cmbbus.Text.Trim.ToUpper = "(SELECCIONE)" Then
                MessageBox.Show("Seleccione el bus para generar la salida del bus", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                cmbbus.Focus()
                Return
            End If

            If cmbtiposervicio.Text.Trim.ToUpper = "(SELECCIONE)" Then
                MessageBox.Show("El Bus seleccionado no tiene tipo de servicio, verifique el tipo de servicio", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                cmbbus.Focus()
                Return
            End If

            Select Case CType(cmbtiposervicio.SelectedValue, Integer)
                Case 1, 4, 5, 6, 9, 10 'Tepsa, Presidencial, Premier, Clásico
                    If cmbrutahorario.Text.Trim.ToUpper = "(SELECCIONE)" Then
                        MessageBox.Show("Seleccione la ruta para generar la salida del bus", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        cmbrutahorario.Focus()
                        Return
                    ElseIf cmbrutahorario.Text.Trim.ToUpper = "RUTA NO ESTABLECIDA" Then
                        MessageBox.Show("Seleccione la ruta para generar la salida del bus", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        cmbrutahorario.Focus()
                        Return
                    ElseIf cmbchoferusuario.Text.Trim.ToUpper = "(SELECCIONE)" Or Me.cmbchoferusuario.SelectedValue = -1 Or IsNothing(Me.cmbchoferusuario.SelectedValue) Then
                        MessageBox.Show("Seleccione el chofer para generar la salida del bus", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        cmbchoferusuario.Focus()
                        Return
                    End If

                    If Me.txtmarcabus.Text.Trim.Length = 0 Then
                        MessageBox.Show("Ingrese Marca del Bus", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If Me.txtplacabus.Text.Trim.Length = 0 Then
                        MessageBox.Show("Ingrese Placa del Bus", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If Me.cmbchoferusuario.SelectedValue < 0 Then
                        MessageBox.Show("Seleccione Piloto", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.cmbchoferusuario.Focus()
                        Exit Sub
                    End If
                    If Me.txtlicencia.Text.Trim.Length < 9 Then
                        MessageBox.Show("Ingrese Nº de Licencia", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtlicencia.Focus()
                        Exit Sub
                    End If
                Case 2 'Carguero
                    If cmbchoferusuario.Text.Trim.ToUpper = "(SELECCIONE)" Or Me.cmbchoferusuario.SelectedValue = -1 Or IsNothing(Me.cmbchoferusuario.SelectedValue) Then
                        MessageBox.Show("Seleccione el chofer para generar la salida del bus", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        cmbchoferusuario.Focus()
                        Return
                    ElseIf cmbOrigenreal.Text.Trim.ToUpper = "(SELECCIONE)" Then
                        MessageBox.Show("Debe elegir la ciudad origen para generar la salida del bus", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        cmbOrigenreal.Focus()
                        Return
                    ElseIf cmbDestinoreal.Text.Trim.ToUpper = "(SELECCIONE)" Then
                        MessageBox.Show("Debe elegir la ciudad destino para generar la salida del bus", "Salida Vehículo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        cmbDestinoreal.Focus()
                        Return
                    ElseIf cmbOrigenreal.SelectedValue = cmbDestinoreal.SelectedValue Then
                        MessageBox.Show("La ciudad de origen y destino no pueden ser la misma", "Salida Vehículo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        cmbDestinoreal.Focus()
                        Return
                    End If

                    If Me.txtmarcabus.Text.Trim.Length = 0 Then
                        MessageBox.Show("Ingrese Marca del Bus", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If Me.txtplacabus.Text.Trim.Length = 0 Then
                        MessageBox.Show("Ingrese Placa del Bus", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    If Me.cmbchoferusuario.SelectedValue < 0 Then
                        MessageBox.Show("Seleccione Piloto", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.cmbchoferusuario.Focus()
                        Exit Sub
                    End If
                    If Me.txtlicencia.Text.Trim.Length = 0 Then
                        MessageBox.Show("Ingrese Nº de Licencia", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtlicencia.Focus()
                        Exit Sub
                    End If
                Case 3 'Por empresa de tercero
                    If cmbOrigenreal.Text.Trim.ToUpper = "(SELECCIONE)" Then
                        MessageBox.Show("Debe elegir la ciudad origen para generar la salida del bus", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        cmbOrigenreal.Focus()
                        Return
                    ElseIf cmbDestinoreal.Text.Trim.ToUpper = "(SELECCIONE)" Then
                        MessageBox.Show("Debe elegir la ciudad destino para generar la salida del bus", "Salida Vehículo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        cmbDestinoreal.Focus()
                        Return
                    ElseIf cmbOrigenreal.SelectedValue = cmbDestinoreal.SelectedValue Then
                        MessageBox.Show("La ciudad de origen y destino no pueden ser la misma", "Salida Vehículo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        cmbDestinoreal.Focus()
                        Return
                    End If
                    If fnValidarRUC(Me.TxtRucTerc.Text.Trim) = False Then
                        MessageBox.Show("Ingrese Ruc Válido", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.TxtRucTerc.Text = ""
                        Me.TxtRucTerc.Focus()
                        Exit Sub
                    End If
                    If Me.txtnomtercero.Text.Trim.Length = 0 Then
                        MessageBox.Show("Ingrese Razón Social del Proveedor", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtnomtercero.Text = ""
                        Me.txtnomtercero.Focus()
                        Exit Sub
                    End If
            End Select

            'Validación de la hora de partida de los buses
            If Mid(Trim(txthorasalida.Text), 1, 2) > "23" Or Mid(Trim(txthorasalida.Text), 4, 2) > "59" Then
                MessageBox.Show("Hora Incorrecta.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txthorasalida.Focus()
                Exit Sub
            ElseIf Mid(Trim(txthorasalida.Text), 1, 2) > "23" Or Mid(Trim(txthorasalida.Text), 4, 2) = "" Then
                MessageBox.Show("Hora Incorrecta.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txthorasalida.Focus()
                Exit Sub
            ElseIf Val(Mid(Trim(txthorasalida.Text), 1, 2)) & Val(Mid(Trim(txthorasalida.Text), 4, 2)) = 0 Then
                txthorasalida.Text = "00:00"
            Else
                txthorasalida.Text = Long.Parse(Mid(Trim(txthorasalida.Text), 1, 2)).ToString("00") & ":" & Long.Parse(Mid(Trim(txthorasalida.Text), 4, 2)).ToString("00")
            End If

            'Validación de la hora de partida de los buses
            If Mid(Trim(TxtTimeHor.Text), 1, 2) > "23" Or Mid(Trim(TxtTimeHor.Text), 4, 2) > "59" Then
                MessageBox.Show("Hora Incorrecta.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TxtTimeHor.Focus()
                Exit Sub
            ElseIf Mid(Trim(TxtTimeHor.Text), 1, 2) = "23" Or Mid(Trim(TxtTimeHor.Text), 4, 2) = "" Then
                MessageBox.Show("Hora Incorrecta.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TxtTimeHor.Focus()
                Exit Sub
            ElseIf Val(Mid(Trim(TxtTimeHor.Text), 1, 2)) & Val(Mid(Trim(TxtTimeHor.Text), 4, 2)) = 0 Then
                TxtTimeHor.Text = "00:00"
            Else
                TxtTimeHor.Text = Long.Parse(Mid(Trim(TxtTimeHor.Text), 1, 2)).ToString("00") & ":" & Long.Parse(Mid(Trim(TxtTimeHor.Text), 4, 2)).ToString("00")
            End If


            'Asiganción de valores para grabar la salida del bus
            objsalidavehiculodespacho.control = icontrol

            If icontrol = 1 Then
                objsalidavehiculodespacho.idnro_salida = -666 'Creacion de Nuevo bus
            Else
                objsalidavehiculodespacho.idnro_salida = txtidnrosalida.Text  'Modificación del Bus Creado.
            End If

            If CType(cmbrutahorario.SelectedValue, Long) = 0 Then
                objsalidavehiculodespacho.idrutahorario = -666 'Cuando no Existe una ruta horario
            Else
                objsalidavehiculodespacho.idrutahorario = CType(cmbrutahorario.SelectedValue, Long) 'Cuando se selecciona una ruta horario
            End If

            If CType(cmbbus.SelectedValue, Long) < 1 Then
                objsalidavehiculodespacho.idunidad_transporte = -666
            Else
                objsalidavehiculodespacho.idunidad_transporte = CType(cmbbus.SelectedValue, Long)
            End If

            objsalidavehiculodespacho.fecha_salida = CType(dtpfec_salida.Value, String)
            objsalidavehiculodespacho.hora_salida = txthorasalida.Text

            objsalidavehiculodespacho.tipo_servicio = CType(cmbtiposervicio.SelectedValue, Long)

            If CType(cmbOrigenreal.SelectedValue, Long) < 1 Then
                objsalidavehiculodespacho.iduni_agencia_origen = -666
            Else
                objsalidavehiculodespacho.iduni_agencia_origen = CType(cmbOrigenreal.SelectedValue, Long)
            End If

            If CType(cmbDestinoreal.SelectedValue, Long) < 1 Then
                objsalidavehiculodespacho.iduni_agencia_destino = -666
            Else
                objsalidavehiculodespacho.iduni_agencia_destino = CType(cmbDestinoreal.SelectedValue, Long)
            End If

            If CType(cmbchoferusuario.SelectedValue, Long) < 1 Then
                objsalidavehiculodespacho.usuario_chofer = -666
            Else
                objsalidavehiculodespacho.usuario_chofer = CType(cmbchoferusuario.SelectedValue, Long)
            End If

            If txtnomtercero.Text = "" Then
                objsalidavehiculodespacho.nombre_tercero = "null"
            Else
                objsalidavehiculodespacho.nombre_tercero = txtnomtercero.Text
            End If

            If TxtRucTerc.Text = "" Then
                objsalidavehiculodespacho.ruc = "null"
            Else
                objsalidavehiculodespacho.ruc = TxtRucTerc.Text
            End If

            If txtlicencia.Text = "" Then
                objsalidavehiculodespacho.nro_licencia = "null"
            Else
                objsalidavehiculodespacho.nro_licencia = txtlicencia.Text
            End If

            If txtmarcabus.Text = "" Then
                objsalidavehiculodespacho.marca_bus = "null"
            Else
                objsalidavehiculodespacho.marca_bus = txtmarcabus.Text
            End If

            If txtplacabus.Text = "" Then
                objsalidavehiculodespacho.placa_bus = "null"
            Else
                objsalidavehiculodespacho.placa_bus = txtplacabus.Text
            End If

            objsalidavehiculodespacho.estado = CType(cmbestado.SelectedValue, Long)
            objsalidavehiculodespacho.fecha_llegada = CType(DTPicfecllegada.Value, String)
            '
            objsalidavehiculodespacho.ip = dtoUSUARIOS.IP
            objsalidavehiculodespacho.idusuario_personal = dtoUSUARIOS.IdLogin
            objsalidavehiculodespacho.idrol_usuario = dtoUSUARIOS.IdRol
            objsalidavehiculodespacho.margen = TxtTimeHor.Text
            objsalidavehiculodespacho.kilometros = Convert.ToDouble(IIf(Val(txtKilometraje.Text) = 0, 0, txtKilometraje.Text))
            objsalidavehiculodespacho.simulado = IIf(iLlamada = 1, 1, 0)
            If objsalidavehiculodespacho.fnLoad_graba_salida_vehiculo() Then ' 19/05/2009 - Graba temporalmente 
                icodigo = CType(objsalidavehiculodespacho.dt_cur_graba.Rows(0).Item(0), Integer)
                ModSolRecojoCarga.smensaje = CType(objsalidavehiculodespacho.dt_cur_graba.Rows(0).Item(1), String)

                'Recuperando los destinos por donde va el bus 'Modificado 27/01/2007
                dtciudad_destino = New DataTable
                dtciudad_destino = objsalidavehiculodespacho.dt_cur_recupera_ciudad_destino

                ' Recupera la ciudad por donde pasa el bus
                grilla_ciudad_destino()
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
                    recupera_salida_vehiculo()
                    configurando_estados()
                    '
                    'objsalidavehiculodespacho.iduni_agencia_origen = cmborigen.SelectedValue
                    'objsalidavehiculodespacho.fecha = CType(DTPFechaSeleccion.Value, String)
                    'If objsalidavehiculodespacho.fnrecupera_salida_vehiculo = True Then
                    '    rstsalida_vehiculo = objsalidavehiculodespacho.cur_salida_vehiculo
                    '    ' Limpiando los valores 
                    '    limpia_tabdatos()
                    '    '
                    '    DataGridView1.Columns.Clear()
                    '    dtsalida_vehiculo = Nothing
                    '    dvsalida_vehiculo = Nothing
                    '    dtsalida_vehiculo = New DataTable
                    '    dvsalida_vehiculo = New DataView
                    '    '
                    '    oldaSalidaVehiculo.Fill(dtsalida_vehiculo, rstsalida_vehiculo)
                    '    dvsalida_vehiculo = dtsalida_vehiculo.DefaultView
                    '    grillaformato()
                End If
            End If
            Me.cmbaddciudad.Enabled = False

        Catch EX As Exception
            MsgBox(EX.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Sub configurando_estados()
        Dim sIDNRO_SALIDA As String
        Dim dgrvsalidavehiculo As DataGridViewRow
        Dim filarow As Integer
        Dim lestado, lnro_salida As Long
        Dim rstcontrol As ADODB.Recordset
        Dim lcodigo As Long
        '----
        If DataGridView1.CurrentRow Is Nothing Then
            Exit Sub
        End If
        dgrvsalidavehiculo = DataGridView1.CurrentRow
        If IsDBNull(dgrvsalidavehiculo.Cells("nro_salida").Value) = True Then
            Exit Sub
        End If
        '---
        lnro_salida = CType(dgrvsalidavehiculo.Cells("nro_salida").Value, String)
        lestado = CType(dgrvsalidavehiculo.Cells("estado").Value, Long)
        '---
        Select Case lestado
            Case 33 'Creado pasa a Activo pasa a anulado 
                CreadoToolStripMenuItem.Enabled = False
                ActivoToolStripMenuItem.Enabled = True
                CierreBodegaToolStripMenuItem.Enabled = False
                DespachadoToolStripMenuItem.Enabled = False
                RecepciónToolStripMenuItem.Enabled = False
                FinalizarToolStripMenuItem.Enabled = False
                RutaAsociaCiudadToolStripMenuItem.Enabled = True
                '
                AnuladoToolStripMenuItem.Enabled = True
            Case 34 'Activo 
                CreadoToolStripMenuItem.Enabled = False
                ActivoToolStripMenuItem.Enabled = False
                CierreBodegaToolStripMenuItem.Enabled = True
                DespachadoToolStripMenuItem.Enabled = False
                RecepciónToolStripMenuItem.Enabled = False
                FinalizarToolStripMenuItem.Enabled = False
                ' Puede anularse siempre y cuando no se halla anulado 
                AnuladoToolStripMenuItem.Enabled = True
                RutaAsociaCiudadToolStripMenuItem.Enabled = True
            Case 39 'CIERRE BODEGA
                CreadoToolStripMenuItem.Enabled = False
                ActivoToolStripMenuItem.Enabled = True
                CierreBodegaToolStripMenuItem.Enabled = False
                DespachadoToolStripMenuItem.Enabled = True
                RecepciónToolStripMenuItem.Enabled = False
                FinalizarToolStripMenuItem.Enabled = False
                ' Puede anularse siempre y cuando no se halla anulado 
                AnuladoToolStripMenuItem.Enabled = True
                RutaAsociaCiudadToolStripMenuItem.Enabled = True
            Case 35 ' Despachado
                CreadoToolStripMenuItem.Enabled = False
                ActivoToolStripMenuItem.Enabled = False
                CierreBodegaToolStripMenuItem.Enabled = True
                DespachadoToolStripMenuItem.Enabled = False
                RecepciónToolStripMenuItem.Enabled = True
                FinalizarToolStripMenuItem.Enabled = False
                RutaAsociaCiudadToolStripMenuItem.Enabled = False
                ' Puede anularse 
                AnuladoToolStripMenuItem.Enabled = False
            Case 36 'RECEPCION CARGA
                CreadoToolStripMenuItem.Enabled = False
                ActivoToolStripMenuItem.Enabled = False
                DespachadoToolStripMenuItem.Enabled = False
                RecepciónToolStripMenuItem.Enabled = False
                FinalizarToolStripMenuItem.Enabled = True
                RutaAsociaCiudadToolStripMenuItem.Enabled = False
                ' Puede anularse 
                AnuladoToolStripMenuItem.Enabled = False
            Case 37 'DESTINO FINAL
                CreadoToolStripMenuItem.Enabled = False
                ActivoToolStripMenuItem.Enabled = False
                DespachadoToolStripMenuItem.Enabled = False
                RecepciónToolStripMenuItem.Enabled = False
                FinalizarToolStripMenuItem.Enabled = False
                RutaAsociaCiudadToolStripMenuItem.Enabled = False
                ' Puede anularse 
                AnuladoToolStripMenuItem.Enabled = False
            Case 38 'ANULADO
                CreadoToolStripMenuItem.Enabled = False
                ActivoToolStripMenuItem.Enabled = False
                DespachadoToolStripMenuItem.Enabled = False
                RecepciónToolStripMenuItem.Enabled = False
                FinalizarToolStripMenuItem.Enabled = False
                RutaAsociaCiudadToolStripMenuItem.Enabled = False
                ' Puede anularse 
                AnuladoToolStripMenuItem.Enabled = False
        End Select
    End Sub
    '------------------------------------------------------

    '--------------------- Cancelar -----------------------
    Private Sub frmsalidavehiculo_MenuCancelar() Handles Me.MenuCancelar
        Me.bInicio = True
        MenuTab.Items(0).Enabled = True
        MenuTab.Items(1).Enabled = False

        Me.cmbaddciudad.Enabled = False

        configurando_estados()
    End Sub
    '------------------------------------------------------

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

#End Region



    

    Private Sub frmsalidavehiculo_MenuEliminar() Handles Me.MenuEliminar

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

        bInicio = True
        configurando_estados()
    End Sub

    Private Sub DataGridView1_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellLeave
        If lee_salida_vehiculo Then
            If e.RowIndex = 0 Then
                configurando_estados()
            End If
        End If
        'OK
    End Sub

    Private Sub cmbaddciudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbaddciudad.SelectedIndexChanged
        Dim fila, lciudad As Long
        Try
            ' Añade una ciudad, si no está
            If cmbaddciudad.SelectedValue > 0 Then
                For fila = 0 To DataGridView2.Rows.Count - 1
                    lciudad = CType(DataGridView2.Rows(fila).Cells("Idunidad_Agencia").Value, Long)
                    If CType(cmbaddciudad.SelectedValue, Long) = lciudad Then
                        ' Mensaje mejor  
                        MsgBox("La ciudad, ya existe", MsgBoxStyle.Information, "Adiciona ciudad")
                        cmbaddciudad.SelectedValue = 0
                        Exit Sub
                    End If
                Next
                ' Grabando la ciudad 
                objsalidavehiculodespacho.idnro_salida = CType(Me.txtidnrosalida.Text, Long)
                objsalidavehiculodespacho.iduni_agencia_destino = CType(cmbaddciudad.SelectedValue, Long)
                ' Verifica que la ciudad no se encuentre asociada a una ruta del bus 
                Try
                    Dim ldt_valida As New DataTable
                    Dim ls_mensaje As String
                    'Mod.10/10/2009 -->Omendoza - Pasando al datahelper -  
                    'ldt_valida = objsalidavehiculodespacho.sp_valida_ciudad_asocia(cnn)
                    ldt_valida = objsalidavehiculodespacho.sp_valida_ciudad_asocia()
                    If ldt_valida.Rows.Count > 0 Then
                        ls_mensaje = "La ciudad se encuentra asociada a la ciudad de " + CType(ldt_valida.Rows(0).Item(0), String)
                        MsgBox(ls_mensaje, MsgBoxStyle.Information, "Adiciona ciudad")
                        cmbaddciudad.SelectedValue = 0
                        Exit Sub
                    End If
                Catch ex As Exception
                    'Sin níngun mensaje 
                End Try
                '
                objsalidavehiculodespacho.iduni_agencia_origen = cmborigen.SelectedValue
                If objsalidavehiculodespacho.fninserta_ciudad_destino_2 = True Then
                    'If objsalidavehiculodespacho.fninserta_ciudad_destino = True Then
                    'Mod.09/10/2009 -->Omendoza - Pasando al datahelper -  
                    ' rstciudad_destino = Nothing
                    dtciudad_destino = Nothing
                    dvciudad_destino = Nothing
                    dtciudad_destino = New DataTable
                    dvciudad_destino = New DataView
                    '
                    'rstciudad_destino = New ADODB.Recordset
                    'rstciudad_destino = objsalidavehiculodespacho.cur_recupera_ciudad_destino
                    'oldaSalidaVehiculo.Fill(dtciudad_destino, rstciudad_destino)
                    '
                    dtciudad_destino = objsalidavehiculodespacho.dt_cur_recupera_ciudad_destino
                    dvciudad_destino = dtciudad_destino.DefaultView
                    '
                    grilla_ciudad_destino()
                End If
            End If
            If DataGridView2.Rows.Count > 0 Then
                GeneraKilometros()
            End If

            cmbaddciudad.SelectedValue = 0 ' Poniendo a su posición original 
            ' Falta eliminar 
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView2.KeyDown
        Try
            Dim dgrv_ciudad As DataGridViewRow
            Dim lidunidad_agencia As Long
            Dim lidnro_salida As Long
            dgrv_ciudad = Me.DataGridView2.CurrentRow()
            '''''''''''''
            If e.KeyCode = Keys.Delete Then
                Dim iResp As Integer
                iResp = MessageBox.Show("¿Está seguro de eliminar el destino?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If iResp = vbNo Then Exit Sub
                lidunidad_agencia = CType(dgrv_ciudad.Cells("Idunidad_Agencia").Value, Long)
                If lidunidad_agencia = CType(Me.cmbDestinoreal.SelectedValue, Long) Then 'Validando la ciudad que no se fin el recorrido  
                    MsgBox("No puede eliminar la ciudad, por ser el destino final del bus.", MsgBoxStyle.Information, "Salida de Bus")
                    Exit Sub
                End If
                ' Eliminando la ciudad 
                objsalidavehiculodespacho.idnro_salida = CType(Me.txtidnrosalida.Text, Long)
                objsalidavehiculodespacho.iduni_agencia_destino = lidunidad_agencia
                objsalidavehiculodespacho.idunidad_agencia_origen = cmborigen.SelectedValue
                If objsalidavehiculodespacho.fnelimina_ciudad_destino_2 = True Then
                    'rstciudad_destino = Nothing
                    dtciudad_destino = Nothing
                    dvciudad_destino = Nothing
                    dtciudad_destino = New DataTable
                    dvciudad_destino = New DataView
                    '
                    'rstciudad_destino = New ADODB.Recordset                   
                    'rstciudad_destino = objsalidavehiculodespacho.cur_recupera_ciudad_destino
                    '
                    dtciudad_destino = objsalidavehiculodespacho.dt_cur_recupera_ciudad_destino
                    '
                    dvciudad_destino = dtciudad_destino.DefaultView
                    grilla_ciudad_destino()
                End If
                If DataGridView2.Rows.Count > 0 Then
                    GeneraKilometros()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de seguridad")
        End Try
    End Sub

    Private Sub TabDatos_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabDatos.Enter
        Try
            If lb_pasa = True Then
                NuevoToolStripMenuItem1.Enabled = True
                EdicionToolStripMenuItem.Enabled = True
                NuevoToolStripMenuItem1.Enabled = True
                NuevoToolStripMenuItem1.Visible = True
                EdicionToolStripMenuItem.Enabled = True
                EdicionToolStripMenuItem.Visible = True
                GrabarToolStripMenuItem.Enabled = False
                GrabarToolStripMenuItem.Visible = False
                CancelarToolStripMenuItem7.Visible = False
                ImprimirToolStripMenuItem.Enabled = True
                ImprimirToolStripMenuItem.Visible = True
                '
                SalirToolStripMenuItem.Enabled = True
                SalirToolStripMenuItem.Visible = True
                '
                TabMante.SelectedIndex = 0
                TxtMensaje.Text = ""
                lb_pasa = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de seguridad")
        End Try
    End Sub

    'Private Sub cmbDestinoreal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDestinoreal.SelectedIndexChanged
    '    If DataGridView2.Rows.Count > 0 And bInicio = False And iDestino <> cmbDestinoreal.SelectedIndex Then
    '        Dim iResp As Integer
    '        iResp = MessageBox.Show("¿Está seguro de modificar el destino?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '        If iResp = vbYes Then
    '            ' Eliminando la ciudad 
    '            objsalidavehiculodespacho.idnro_salida = CType(Me.txtidnrosalida.Text, Long)
    '            objsalidavehiculodespacho.iduni_agencia_destino = cmbDestinoreal.SelectedValue
    '            objsalidavehiculodespacho.idunidad_agencia_origen = cmborigen.SelectedValue

    '            If objsalidavehiculodespacho.fnelimina_ciudad_3 = True Then

    '                dtciudad_destino = Nothing
    '                dvciudad_destino = Nothing
    '                dtciudad_destino = New DataTable
    '                dvciudad_destino = New DataView
    '                dtciudad_destino = objsalidavehiculodespacho.dt_cur_recupera_ciudad_destino
    '                '
    '                dvciudad_destino = dtciudad_destino.DefaultView
    '                grilla_ciudad_destino()
    '            End If

    '        Else
    '            cmbDestinoreal.SelectedIndex = iDestino
    '        End If
    '    End If
    '    iDestino = cmbDestinoreal.SelectedIndex
    'End Sub

    'Private Sub cmbOrigenreal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOrigenreal.SelectedIndexChanged
    '    If DataGridView2.Rows.Count > 0 And bInicio = False Then
    '        Dim iResp As Integer
    '        iResp = MessageBox.Show("¿Está seguro de modificar el orígen?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '        If iResp = vbYes Then
    '            ' Eliminando la ciudad 
    '            objsalidavehiculodespacho.idnro_salida = CType(Me.txtidnrosalida.Text, Long)
    '            objsalidavehiculodespacho.iduni_agencia_destino = cmbDestinoreal.SelectedValue
    '            objsalidavehiculodespacho.idunidad_agencia_origen = cmborigen.SelectedValue

    '            If objsalidavehiculodespacho.fnelimina_ciudad_4 = True Then

    '                dtciudad_destino = Nothing
    '                dvciudad_destino = Nothing
    '                dtciudad_destino = New DataTable
    '                dvciudad_destino = New DataView

    '                dtciudad_destino = objsalidavehiculodespacho.dt_cur_recupera_ciudad_destino
    '                dvciudad_destino = dtciudad_destino.DefaultView
    '                grilla_ciudad_destino()
    '            End If
    '        End If
    '    End If
    'End Sub

    Private Sub RutaAsociaCiudadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RutaAsociaCiudadToolStripMenuItem.Click
        Try 'Add el 07/07/2009 - Asociando las ciudades 
            Dim sIDNRO_SALIDA As String
            Dim dgrvsalidavehiculo As DataGridViewRow
            Dim filarow As Integer
            Dim ll_idunidad_agencia As Long
            Dim lestado, lnro_salida As Long
            'Dim rstcontrol As ADODB.Recordset
            Dim lcodigo As Long
            '----
            If DataGridView1.CurrentRow Is Nothing Then
                Exit Sub
            End If
            dgrvsalidavehiculo = DataGridView1.CurrentRow
            If IsDBNull(dgrvsalidavehiculo.Cells("nro_salida").Value) = True Then
                Exit Sub
            End If
            '---
            lnro_salida = CType(dgrvsalidavehiculo.Cells("nro_salida").Value, Long)
            ll_idunidad_agencia = CType(dgrvsalidavehiculo.Cells("idunidad_agencia_destino").Value, Long)
            '--- 
            Dim lobjfrm_frm_asocia_ruta_salida As New frm_asocia_ruta_salida
            '
            lobjfrm_frm_asocia_ruta_salida.pl_idnro_salida_vehiculo = lnro_salida
            lobjfrm_frm_asocia_ruta_salida.pl_idunidad_origen = Me.cmborigen.SelectedValue
            lobjfrm_frm_asocia_ruta_salida.pl_idunidad_destino = ll_idunidad_agencia
            '
            lobjfrm_frm_asocia_ruta_salida.pdt_origen = dtorigen.Copy   ' Solo copia las ciudades 
            lobjfrm_frm_asocia_ruta_salida.pdt_destino = dtorigen.Copy
            '
            'lobjfrm_frm_asocia_ruta_salida.ShowDialog()
            Acceso.Asignar(lobjfrm_frm_asocia_ruta_salida, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                lobjfrm_frm_asocia_ruta_salida.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Sub VerificaCambio(ByVal sender As Object, ByVal e As EventArgs) Handles CancelarToolStripMenuItem7.EnabledChanged, AyudaToolStripMenuItem1.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class
