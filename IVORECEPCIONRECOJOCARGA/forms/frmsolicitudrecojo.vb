Imports System
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.IO
Imports ADOSERVERLib
'Imports Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn [mendoza] 
'---------------------------------------------------------------
Public Class frmsolicitudrecojo
    Inherits FrmPlantillasolrecojocarga
    Dim ClaseSolReco As New dtoSolicitudRecojoCarga
    Dim clasesolcomun As New dtosolicitudcomun
    Dim ClaseSolAsignamovil As New dtoSolAsignamovil
    Dim ClaseSolatendida As New dtoSolatendida
    Dim iconos As New uUtils
    '
    Dim dtAgenciaRVC As New DataTable
    'Dim rstagenciamilo As New Recordset
    '
    Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    Const KEYEVENTF_KEYUP As Short = &H2S
    '
    Private bcancelar As Boolean
    Dim bIngreso As Boolean
    Public hnd As Long
    '**********************************************************************************************
    'Dim WithEvents WinSockServer As New WinSockServer()
    'Private Sub Servidor_Load()
    '    With WinSockServer
    '        .PuertoDeEscucha = 8050
    '        .Escuchar()
    '    End With
    'End Sub
    'Private Sub WinSockServer_NuevaConexion(ByVal IDTerminal As System.Net.IPEndPoint) Handles WinSockServer.NuevaConexion
    '    'Muestro quien se conecto 
    '    MsgBox("Se ha conectado un nuevo cliente desde la IP= " & IDTerminal.Address.ToString & _
    '                                                            ",Puerto = " & IDTerminal.Port)
    'End Sub
    'Private Sub WinSockServer_ConexionTerminada(ByVal IDTerminal As System.Net.IPEndPoint) Handles WinSockServer.ConexionTerminada
    '    'Muestro con quien se termino la conexion 
    '    MsgBox("Se ha desconectado el cliente desde la IP= " & IDTerminal.Address.ToString & _
    '                                                         ",Puerto = " & IDTerminal.Port)
    'End Sub
    'Private Sub WinSockServer_DatosRecibidos(ByVal IDTerminal As System.Net.IPEndPoint) Handles WinSockServer.DatosRecibidos
    '    MsgBox("Nuevo mensaje desde el cliente de la IP= " & IDTerminal.Address.ToString & _
    '                                               ",Puerto = " & IDTerminal.Port)
    '    Call MsgBox(WinSockServer.ObtenerDatos(IDTerminal))
    'End Sub
    '**********************************************************************************************
#Region "Constantes"
    Public Const dNULO As Double = -666
    Public Const sNULO As String = "null"
    Public Const iNULO As Integer = -666
#End Region
#Region "DECLARACION VARIABLES TAB 0"
    'Declarando la variable, para que el datagridview se manejen los eventos  
    'Declarando el usuario 
    Dim usuario As Integer
    'Declaracion de Recordset
    'Dim rstAgencia, rstSolCarga, rstestadorecojo As New ADODB.Recordset
    'Declaracion de Data Adapters
    Dim dr4 As New OleDb.OleDbDataAdapter
    'Private DataAdapterGenerics As New OleDbDataAdapter
    'Declaracion de DataTables
    Dim dtAgencia, dtSolCarga, dtestadorecojo As New System.Data.DataTable
    ' Declarando Data View 
    Dim dvAgencia, dvSolCarga, dvestadorecojo As New DataView
    ' Declarando variables de uso general 
    Dim filtro As String = ""
    Dim idagencia As Integer
    Dim fec_solicitud As Date
    Dim fila As Integer   
    ' Declare a variable of type BindingManagerBase named bindingManager.
    Dim bindingManager As BindingManagerBase
    'probando la variable 
    Dim drg As DataRowView
    Dim controltab As Integer
    Dim solounavez0 As Boolean
    'Dim solounavezGrilla0 As Boolean
    Dim actualizardatos As Boolean
    'Para conversión de Mayúsculas  
    Dim datollamada As String
    Dim datorazonsocial As String
    Dim datodireccion As String
    Dim tab0_control As Boolean
    ' Control de los campos 
    Dim dgvsolicitafila As Integer
    Dim dgvsolicitactrl As Boolean
    ' Parametros de nuevos valores que van a ser insertado 
    Dim tipodireccion, idubigeo, idpais, iddpto, idprov As Integer    
    Dim sdireccion, srefllegada, snrodcto As String
    Dim idsucuenta As Integer
    Dim idcargo, idtipdcto, idsexo As Integer
    ' para saber si va a guardar los datos 
    Dim bguardardireccion As Boolean = False
    Dim shora As String
    Dim iidpais_tab0, iiddepartamento_tab0, iidprovincia_tab0, iiddistrito_tab0 As Integer
#End Region
#Region "DECLARACION VARIABLES TAB 1"
    'Dim rstagenciaasigna, rstrutaasigna, rstunitransasigna, rsttipoobsasigna, rstSolCargaasigna, rsteerecojoasigna As New ADODB.Recordset
    'Dim dttipoobsasigna, dtagenciaasigna, dtrutaasigna, dtunitransasigna, dtRutasasignaClon, dtSolCargaasigna, dteerecojo As New DataTable
    'Dim dvtipoobsasigna, dvAgenciaasigna, dvrutaasigna, dvunitransasigna, dvSolCargaasigna, dveerecojoasigna As New DataView
    'Dim drvtipoobs, drvAgenciaasigna, drvrutasasigna As DataRowView
    Dim rstagenciaasigna, rstrutaasigna, rstunitransasigna, rsttipoobsasigna, rsteerecojoasigna As New ADODB.Recordset
    Dim dttipoobsasigna, dtagenciaasigna, dtrutaasigna, dtunitransasigna, dtRutasasignaClon, dtSolCargaasigna, dteerecojo As New DataTable
    Dim dvtipoobsasigna, dvAgenciaasigna, dvrutaasigna, dvunitransasigna, dvSolCargaasigna, dveerecojoasigna As New DataView
    Dim drvtipoobs, drvAgenciaasigna, drvrutasasigna As DataRowView
    Dim rstSolCargaasigna As DataTable

    ' Recupera agencia 
    Dim idagenciaasigna As Integer
    Dim tab1_control As Boolean
    Dim iidpais_tab1, iiddepartamento_tab1, iidprovincia_tab1, iiddistrito_tab1 As Integer
#End Region
#Region "DECLARACION VARIABLES TAB 2"
    'datahelper
    'Dim rsttipoobsresumen, rstagenciaresumen, rstrutaresumen, rstunitransresumen, rstSolCargaresumen, rsteerecojoresumen As New ADODB.Recordset
    Dim rsttipoobsresumen, rstagenciaresumen, rstrutaresumen, rstunitransresumen, rsteerecojoresumen As New ADODB.Recordset
    Dim rstSolCargaresumen As DataTable
    Dim dttipoobsresumen, dtAgenciaresumen, dtrutaresumen, dtunitransresumen, dtRutasresumenClon, dtSolCargaresumen, dteerecojoresumen As New DataTable
    Dim dvtipoobsresumen, dvAgenciaresumen, dvrutaresumen, dvunitransresumen, dvSolCargaresumen, dveerecojoresumen As New DataView
    Dim drvtipoobsresumen, drvAgenciaresumen, drvrutasresumen As DataRowView
    ' Recupera agencia     
    Dim idagenciaresumen As Integer
    Dim valorecojo As String
    Dim tab2_control As Boolean
    Dim iidpais_tab2, iiddepartamento_tab2, iidprovincia_tab2, iiddistrito_tab2 As Integer
#End Region
#Region "Principal"
    Public Sub DGVSolicita_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVSolicita.CellClick
        Dim FILA As Integer
        FILA = e.RowIndex
        ' Para activar el click 
    End Sub

    Private Sub frmsolicitudrecojo_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frmsolicitudrecojo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frmsolicitudrecojo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try            
            ' Desactivando 
            MenuTab.Items(3).Enabled = False
            MenuTab.Items(3).Visible = False
            MenuTab.Items(4).Enabled = False
            MenuTab.Items(4).Visible = False
            MenuTab.Items(5).Enabled = False
            MenuTab.Items(5).Visible = False
            'Menu del datawievgrid 
            ToolStripMenuItem2.Visible = False
            ToolStripMenuItem2.Enabled = False
            'Activando el nuevo
            NuevoToolStripMenuItem1.Enabled = True
            NuevoToolStripMenuItem1.Visible = True
            'Desactivando Cancelar
            CancelarToolStripMenuItem.Enabled = False
            'CancelarToolStripMenuItem.Visible = False
            'Configurando suspendido 
            EliminarToolStripMenuItem.Text = "Suspender"
            EdicionToolStripMenuItem.Text = "Refrescar"
            ' No se trabaja con la datagridview de la plantilla 
            DataGridViewPlt.Enabled = False
            DataGridViewPlt.Visible = False
            '
            MenuTab.Items(0).Text = "Ingreso llamada"
            MenuTab.Items(1).Enabled = True
            MenuTab.Items(1).Visible = True
            MenuTab.Items(1).Text = "Asigna móvil"
            MenuTab.Items(2).Enabled = True
            MenuTab.Items(2).Visible = True
            MenuTab.Items(2).Text = "Estado recojo"
            ' Creando la fecha por defecto de la pc
            Dim today As DateTime = System.DateTime.Today
            ShadowLabel1.Text = "Carga - Solicitud Recojo "
            ' Recuperando el combo a la agencia  
            usuario = dtoUSUARIOS.IdLogin
            ' Ocultando label del padre  
            LabeloSCAR.Visible = False
            'Ocultando los datagridview 
            DGVCliente.Visible = False
            DGVDireccion.Visible = False
            DGVContacto.Visible = False
            'Activando mayusculas 
            CapsOn()
            'Para validar el cmb de recojo
            solounavez0 = True
            bcancelar = False
            '
            iconos.IniciarImagenes()
            '
            tab0_control = True
            tab1_control = False
            tab2_control = False
            limpiando_tab1()
            limpiando_tab2()
            Call call_invocatab0()
            '
            'DGVSolicita.Focus()
            '            
            'DGVSolicita.EditingControl            
            ' Fin de los comentarios 
            'Contrae el árbol 
            SplitContainer2.Panel1Collapsed = True
            'Servidor_Load()
            '            
            'Dim irows As Integer = Me.DGVSolicita.NewRowIndex
            ''Me.DGVSolicita.CurrentCell = Me.DGVSolicita.Rows(irows).Cells(1)
            'Me.DGVSolicita.Rows(irows).Cells(1).Selected = True

            bIngreso = False
            Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)
            bIngreso = True

        Catch exc As Exception
            MsgBox(exc.Message(), MsgBoxStyle.Critical, "Asignando él valor ")
        End Try
    End Sub
    Private Sub DTimePickersol_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTimePickersol.TextChanged
        '  bcancelar = True
        Call recupera_solcitud()
        '  bcancelar = False
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
        If msg.WParam.ToInt32() = CInt(Keys.Down) Then
            If DGVCliente.Visible = False And DGVDireccion.Visible = False And DGVContacto.Visible = False Then
                labayuda.Visible = False
                SendKeys.Send("{Tab}")
                Return True
            End If
        End If
        'If msg.WParam.ToInt32 = 40 Then ' Tecla abajo (Down) 
        '    SendKeys.Send("{Esc}")
        '    ' Debo preguntar que si ha sido ingresado totalmente la fila.
        '    Return True
        'End If
        If msg.WParam.ToInt32() = CInt(Keys.F12) Then
            ' Saliendos de la ventana 
            limpiando_tab0()
            limpiando_tab1()
            limpiando_tab2()
            Me.Close()
            Return True
        End If
        ' Ingresando una nueva solicitud   
        If msg.WParam.ToInt32() = CInt(Keys.F1) And tab0_control Then
            Call nuevo()
            Return True
        End If
        ' Editando la solicitud creado 
        If msg.WParam.ToInt32() = CInt(Keys.F2) Then
            Call editar()
            Return True
        End If
        ' Suspendiendo la solicitud 
        If msg.WParam.ToInt32() = CInt(Keys.F3) Then
            Call suspender()
            Return True
        End If

        'If msg.WParam.ToInt32() = CInt(Keys.Escape) Then
        'labayuda.Visible = False
        'If DGVCliente.Visible = True Then
        '    DGVCliente.Visible = False
        '    'Volviendo a la posicion que me quedado 
        '    bcancelar = True
        '    DGVSolicita.Focus()
        '    DGVSolicita.CurrentCell = DGVSolicita.Rows(ModSolRecojoCarga.frmfilapadre).Cells(5)
        '    bcancelar = False
        '    'ModSolRecojoCarga.frmfilapadre = Nothing
        'End If
        'If DGVDireccion.Visible = True Then
        '    DGVDireccion.Visible = False
        '    bcancelar = True
        '    Dim llfilita As Integer
        '    llfilita = ModSolRecojoCarga.frmfilapadre
        '    DGVSolicita.CurrentCell = DGVSolicita.Rows(ModSolRecojoCarga.frmfilapadre).Cells(7)
        '    bcancelar = False
        '    'ModSolRecojoCarga.frmfilapadre = Nothing
        'End If
        'If DGVContacto.Visible = True Then
        '    DGVContacto.Visible = False
        '    bcancelar = False
        '    DGVSolicita.CurrentCell = DGVSolicita.Rows(ModSolRecojoCarga.frmfilapadre).Cells(9)
        '    bcancelar = True
        'End If
        ''No es necesario por ahora desahabilitar - Omendoza 
        ''DGVSolicita.Enabled = True
        ''ModSolRecojoCarga.frmfilapadre = Nothing
        'Return True
        'End If
        'If msg.WParam.ToInt32() = CInt(Keys.F1) Then
        '    If tab0_control Then
        '        Dim dgvr As New DataGridViewRow
        '        Dim fila As New Integer
        '        Dim idcliente As New Integer
        '        Dim cadena As String
        '        Dim mensaje As String
        '        dgvr = Me.DGVSolicita.CurrentRow
        '        fila = dgvr.Index
        '        ModSolRecojoCarga.frmfilapadre = fila
        '        If DGVSolicita.Rows(fila).Cells(5).Selected = True Then  ' Verifica el ingreso de clientes 
        '            cadena = "%"
        '            bcancelar = True
        '            buscarcliente(cadena, fila)
        '            bcancelar = False
        '        End If
        '        If DGVSolicita.Rows(fila).Cells(7).Selected = True Then  ' Verifica el ingreso direcciones
        '            Dim paso As Boolean = True
        '            If IsDBNull(DGVSolicita.Rows(fila).Cells(5).Value) = True Then
        '                paso = False
        '            Else
        '                If DGVSolicita.Rows(fila).Cells(5).Value = "" Then
        '                    paso = False
        '                Else
        '                    idcliente = DGVSolicita.Rows(fila).Cells(4).Value
        '                End If
        '            End If
        '            If Not paso Then
        '                mensaje = "Falta ingresar el cliente"
        '                MessageBox.Show(mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                DGVSolicita.CurrentCell = DGVSolicita.Rows(fila).Cells(5)
        '                Return True
        '            End If
        '            bcancelar = True
        '            buscardireccion(idcliente, fila)
        '            bcancelar = False
        '        End If
        '        If DGVSolicita.Rows(fila).Cells(9).Selected = True Then  ' Valida los contactos
        '            Dim paso As Boolean = True
        '            Dim idirecciont As Integer = -1
        '            If IsDBNull(DGVSolicita.Rows(fila).Cells(5).Value) = True Then
        '                paso = False
        '            Else
        '                If DGVSolicita.Rows(fila).Cells(5).Value = "" Then
        '                    paso = False
        '                Else
        '                    idcliente = DGVSolicita.Rows(fila).Cells(4).Value
        '                End If
        '            End If
        '            If IsDBNull(DGVSolicita.Rows(fila).Cells(7).Value) = True Then
        '                paso = False
        '            Else
        '                If DGVSolicita.Rows(fila).Cells(7).Value = "" Then
        '                    paso = False
        '                Else
        '                    idirecciont = DGVSolicita.Rows(fila).Cells(6).Value
        '                End If
        '            End If
        '            If Not paso Then
        '                If idirecciont <> -1 Then
        '                    mensaje = "Falta ingresar el cliente"
        '                    MessageBox.Show(mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                    DGVSolicita.CurrentCell = DGVSolicita.Rows(fila).Cells(5)
        '                    Return True
        '                Else
        '                    mensaje = "Falta ingresar la dirección"
        '                    MessageBox.Show(mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                    DGVSolicita.CurrentCell = DGVSolicita.Rows(fila).Cells(7)
        '                    Return True
        '                End If
        '                bcancelar = True
        '                buscarcontacto(idcliente, idirecciont, fila)
        '                bcancelar = False
        '            End If
        '            Return True
        '        End If
        '    End If
        'End If
        'Exit Function
        'Return True
        'Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub frmsolicitudrecojo_MenuSalir() Handles Me.MenuSalir
        bcancelar = True        
    End Sub
    Private Sub TabMante_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabMante.Selecting
        Select Case e.TabPageIndex
            Case 0  ' Genera las solicitudes 
                limpiando_tab1()
                limpiando_tab2()
                inicializa_tab0()
                call_invocatab0()
                NuevoToolStripMenuItem1.Enabled = True
            Case 1  ' Asigna el responsable 
                limpiando_tab0()
                limpiando_tab2()
                inicializa_tab1()
                call_invocatab1()
                NuevoToolStripMenuItem1.Enabled = False
            Case 2  ' Resumen el recojo 
                limpiando_tab0()
                limpiando_tab1()
                inicializa_tab2()
                call_invocatab2()
                NuevoToolStripMenuItem1.Enabled = False
        End Select
    End Sub
    Private Function GetCurrentDataRow() As DataRow
        ' Declara el tipo de variable DataRow a sourceTableDataRow
        Dim sourceTableDataRow As DataRow
        ' Cast the BindingManagerBase's Current(row) as a DataRowView.
        ' Cast the DataRowView as a DataRow.
        ' Assign the resulting reference to the sourceTableDataRow variable
        ' which is now a pointer to the original row the source table.
        sourceTableDataRow = CType(CType(bindingManager.Current, DataRowView).Row, DataRow)
        ' Return a reference (pointer) to the source DataRow.
        Return sourceTableDataRow
    End Function
    Public Sub CapsOn()
        Dim keyboard1 As New Microsoft.VisualBasic.Devices.Keyboard
        If keyboard1.CapsLock = False Then
            keybd_event(&H14, &H45, &H1 Or 0, 0)
            keybd_event(&H14, &H45, &H1 Or &H2, 0)
        End If
    End Sub
    Private Sub frmsolicitudrecojo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        '    'Dim keyboard1 As New Microsoft.VisualBasic.Devices.Keyboard
        '    'If keyboard1.CapsLock = False Then
        CapsOn()
        '    'End If
    End Sub
    Private Sub limpiando_tab0()
        'datahelper
        'rstAgencia = Nothing
        'rstSolCarga = Nothing
        dtAgencia = Nothing
        dtSolCarga = Nothing
        dvAgencia = Nothing
        dvSolCarga = Nothing

        DGVSolicita.ClearSelection()
    End Sub
    Private Sub inicializa_tab0()
        'datahelper
        'rstAgencia = New ADODB.Recordset
        'rstSolCarga = New ADODB.Recordset
        dtAgencia = New DataTable
        dtSolCarga = New DataTable
        dvAgencia = New DataView
        dvSolCarga = New DataView
        'drvAgencia = New DataRowView
        'dtestadorecojo = New DataTable
        'rstestadorecojo = New Recordset
        'dvestadorecojo = New DataView
        '
        tab0_control = True
        tab1_control = False
        tab2_control = False
        'DGVSolicita.ClearSelection()
    End Sub
    Private Sub limpiando_tab1()
        rstagenciaasigna = Nothing
        rstrutaasigna = Nothing
        rstunitransasigna = Nothing
        rstSolCargaasigna = Nothing
        dtagenciaasigna = Nothing
        dtrutaasigna = Nothing
        dtunitransasigna = Nothing
        dtRutasasignaClon = Nothing
        dtSolCargaasigna = Nothing
        dvAgenciaasigna = Nothing
        dvrutaasigna = Nothing
        dvunitransasigna = Nothing
        dvSolCargaasigna = Nothing
        drvAgenciaasigna = Nothing
        drvrutasasigna = Nothing
        DGVAsigna.ClearSelection()
        '
    End Sub
    Private Sub inicializa_tab1()
        rstagenciaasigna = New ADODB.Recordset
        rstrutaasigna = New ADODB.Recordset
        rstunitransasigna = New ADODB.Recordset
        'rstSolCargaasigna = New ADODB.Recordset
        dtagenciaasigna = New DataTable
        dtrutaasigna = New DataTable
        dtunitransasigna = New DataTable
        dtRutasasignaClon = New DataTable
        dtSolCargaasigna = New DataTable
        dvAgenciaasigna = New DataView
        dvrutaasigna = New DataView
        dvunitransasigna = New DataView
        dvSolCargaasigna = New DataView
        tab0_control = False
        tab1_control = True
        tab2_control = False
    End Sub
    Private Sub limpiando_tab2()
        rstagenciaresumen = Nothing
        rstrutaresumen = Nothing
        rstunitransresumen = Nothing
        rstSolCargaresumen = Nothing
        dtAgenciaresumen = Nothing
        dtrutaresumen = Nothing
        dtunitransresumen = Nothing
        dtRutasresumenClon = Nothing
        dtSolCargaresumen = Nothing
        dvAgenciaresumen = Nothing
        dvrutaresumen = Nothing
        dvunitransresumen = Nothing
        dvSolCargaresumen = Nothing
        drvAgenciaresumen = Nothing
        drvrutasresumen = Nothing
        DGVResumen.ClearSelection()
    End Sub
    Private Sub inicializa_tab2()
        rstagenciaresumen = New ADODB.Recordset
        rstrutaresumen = New ADODB.Recordset
        rstunitransresumen = New ADODB.Recordset
        'datahelper
        'rstSolCargaresumen = New ADODB.Recordset
        dtAgenciaresumen = New DataTable
        dtrutaresumen = New DataTable
        dtunitransresumen = New DataTable
        dtRutasresumenClon = New DataTable
        dtSolCargaresumen = New DataTable
        dvAgenciaresumen = New DataView
        dvrutaresumen = New DataView
        dvunitransresumen = New DataView
        dvSolCargaresumen = New DataView
        'drvAgenciaresumen = Nothing
        'drvrutasresumen = Nothing
        tab0_control = False
        tab1_control = False
        tab2_control = True
    End Sub
    Private Sub FrmSolicitaRecojoCarga_new_MenuCancelar() Handles Me.MenuCancelar
        Try
            limpiardatos()
            CancelarToolStripMenuItem.Enabled = False
            GrabarToolStripMenuItem.Enabled = False
            DGVCliente.Visible = False
            DGVDireccion.Visible = False
            DGVContacto.Visible = False
        Catch exc As Exception
            MsgBox(exc.Message(), MsgBoxStyle.Critical, "Asignando él valor ")
        End Try
    End Sub
    Private Sub FrmSolicitaRecojoCarga_new_MenuGrabar() Handles Me.MenuGrabar
        Dim dgrv0 As New DataGridViewRow
        '
        If tab0_control Then
            dgrv0 = Me.DGVSolicita.CurrentRow
            If validar_campos_tab0(dgrv0.Index) Then
                grabarsolicitud(dgrv0.Index)
                TabMante.SelectedIndex = 0
            End If
            GrabarToolStripMenuItem.Enabled = False
            CancelarToolStripMenuItem.Enabled = False
            bcancelar = False
        End If
    End Sub
    Private Sub frmsolicitudrecojo_MenuEliminar() Handles Me.MenuEliminar
        Try
            Dim nro_solicitud As Integer
            ' Dim aprobado As Integer 
            Dim cerrado As Integer
            Dim mensaje As String
            Dim rpta As New DialogResult
            Dim dgrv0, dgrv1, dgrv2 As DataGridViewRow
            'datahelper
            'Dim rstdatos, rstoracle As New ADODB.Recordset
            Dim rstdatos, rstoracle As DataTable
            mensaje = "Se va a suspender la solicitud Nº "
            '
            clasesolcomun.idrol_usuariomod = dtoUSUARIOS.IdRol
            clasesolcomun.idusurio_personalmod = dtoUSUARIOS.IdLogin
            clasesolcomun.ipmod = dtoUSUARIOS.IP
            If tab0_control Then
                dgrv0 = Me.DGVSolicita.CurrentRow()
                If Not puedeactualizar(1) Then
                    Return
                End If
                nro_solicitud = dgrv0.Cells(2).Value
                'Recuperar los datos verificar que no este cerrado ni aprobado 
                mensaje = mensaje + nro_solicitud.ToString
                rpta = MessageBox.Show(Me, mensaje, "Solicitud de Carga", MessageBoxButtons.YesNo, _
                       MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)
                If rpta = DialogResult.Yes Then
                    'Grabando información   
                    clasesolcomun.idnro_solicitud = nro_solicitud
                    Dim ds As DataSet = clasesolcomun.suspender_solicitud
                    rstdatos = ds.Tables(0)
                    rstoracle = ds.Tables(1)
                    If rstdatos.Rows(0).Item(0) <> 0 Then
                        MessageBox.Show("Descripción: " & CType(rstoracle.Rows(0).Item(1), String), "ORACLE -> Error: " & CType(rstoracle.Rows(0).Item(0), String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                    dgrv0.Cells(15).Value = CType(rstdatos.Rows(0).Item(2), Integer)
                    dgrv0.Cells(14).Value = CType(rstdatos.Rows(0).Item(1), Integer)

                    'datahelper
                    'rstdatos = clasesolcomun.suspender_solicitud
                    'rstoracle = rstdatos.NextRecordset
                    'If rstdatos.Fields(0).Value <> 0 Then
                    '    MessageBox.Show("Descripción: " & CType(rstoracle.Fields(1).Value, String), "ORACLE -> Error: " & CType(rstoracle.Fields(0).Value, String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    Return
                    'End If
                    'dgrv0.Cells(15).Value = CType(rstdatos.Fields(2).Value, Integer)
                    'dgrv0.Cells(14).Value = CType(rstdatos.Fields(1).Value, Integer)
                End If
                ' Refrescando 
                recupera_solcitud()
            End If
            '
            If tab1_control Then
                dgrv1 = Me.DGVAsigna.CurrentRow()
                nro_solicitud = dgrv1.Cells(0).Value
                mensaje = mensaje + nro_solicitud.ToString
                cerrado = dgrv1.Cells(14).Value
                If cerrado = 1 Then
                    mensaje = "No puede suspender la solicitud, por estar cerrada "
                    MessageBox.Show(mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                'Recuperar los datos verificar que no este cerrado ni aprobado 
                mensaje = mensaje + nro_solicitud.ToString
                rpta = MessageBox.Show(Me, mensaje, "Solicitud de Carga", MessageBoxButtons.YesNo, _
                       MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)
                If rpta = DialogResult.Yes Then
                    'Grabando información   
                    clasesolcomun.idnro_solicitud = nro_solicitud
                    Dim ds As DataSet = clasesolcomun.suspender_solicitud
                    rstdatos = ds.Tables(0)
                    rstoracle = ds.Tables(1)
                    If rstdatos.Rows(0).Item(0) <> 0 Then
                        MessageBox.Show("Descripción: " & CType(rstoracle.Rows(0).Item(1), String), "ORACLE -> Error: " & CType(rstoracle.Rows(0).Item(0), String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                    dgrv1.Cells(14).Value = CType(rstdatos.Rows(0).Item(2), Integer)
                    dgrv1.Cells(13).Value = CType(rstdatos.Rows(0).Item(1), Integer)

                    'datahelper
                    'rstdatos = clasesolcomun.suspender_solicitud
                    'rstoracle = rstdatos.NextRecordset
                    'If rstdatos.Fields(0).Value <> 0 Then
                    '    MessageBox.Show("Descripción: " & CType(rstoracle.Fields(1).Value, String), "ORACLE -> Error: " & CType(rstoracle.Fields(0).Value, String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    Return
                    'End If
                    'dgrv1.Cells(14).Value = CType(rstdatos.Fields(2).Value, Integer)
                    'dgrv1.Cells(13).Value = CType(rstdatos.Fields(1).Value, Integer)
                End If
            End If
            '
            If tab2_control Then
                dgrv2 = Me.DGVResumen.CurrentRow()
                nro_solicitud = dgrv2.Cells(0).Value
                mensaje = mensaje + nro_solicitud.ToString
                cerrado = dgrv2.Cells(10).Value
                If cerrado = 1 Then
                    mensaje = "No puede suspender la solicitud, por estar cerrada "
                    MessageBox.Show(mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                'Recuperar los datos verificar que no este cerrado ni aprobado 
                mensaje = mensaje + nro_solicitud.ToString
                rpta = MessageBox.Show(Me, mensaje, "Solicitud de Carga", MessageBoxButtons.YesNo, _
                       MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)
                If rpta = DialogResult.Yes Then
                    'Grabando información   
                    clasesolcomun.idnro_solicitud = nro_solicitud
                    Dim ds As DataSet = clasesolcomun.suspender_solicitud
                    rstdatos = ds.Tables(0)
                    rstoracle = ds.Tables(1)
                    If rstdatos.Rows(0).Item(0) <> 0 Then
                        MessageBox.Show("Descripción: " & CType(rstoracle.Rows(0).Item(1), String), "ORACLE -> Error: " & CType(rstoracle.Rows(0).Item(0), String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                    dgrv2.Cells(10).Value = CType(rstdatos.Rows(0).Item(2), Integer)
                    dgrv2.Cells(9).Value = CType(rstdatos.Rows(0).Item(1), Integer)
                    dgrv2.Cells(11).Value = rstdatos.Rows(0).Item(3)

                    'datahelper
                    'rstdatos = clasesolcomun.suspender_solicitud
                    'rstoracle = rstdatos.NextRecordset
                    'If rstdatos.Fields(0).Value <> 0 Then
                    '    MessageBox.Show("Descripción: " & CType(rstoracle.Fields(1).Value, String), "ORACLE -> Error: " & CType(rstoracle.Fields(0).Value, String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    Return
                    'End If
                    'dgrv2.Cells(10).Value = CType(rstdatos.Fields(2).Value, Integer)
                    'dgrv2.Cells(9).Value = CType(rstdatos.Fields(1).Value, Integer)
                    'dgrv2.Cells(11).Value = rstdatos.Fields(3).Value
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub frmsolicitudrecojo_MenuNuevo() Handles Me.MenuNuevo
        ' Dim frmingresosol As New Frmingresosolicitud
        Try
            If tab0_control Then
                Call nuevo()
                ''frmingresosol.MdiParent = Me
                'frmingresosol.Location = New Point(10, 10)
                'frmingresosol.piidagencia = CType(cmbagencia.SelectedValue, Integer)
                'frmingresosol.piidprovincia = iidprovincia_tab0
                'frmingresosol.sfecha = CType(DTimePickersol.Value, String)
                'frmingresosol.control = 1 'Ingreso nuevo 
                'frmingresosol.ShowDialog()
                ''Recupera los datos 
                'recupera_solcitud()
            End If
            '
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub frmsolicitudrecojo_MenuEditar() Handles Me.MenuEditar
        If tab0_control Then
            'bcancelar = True
            'recupera_agencia()
            recupera_solcitud()
            'bcancelar = False
            'inicializa_tab0()
            'call_invocatab0()            
        End If
        If tab1_control Then
            recupera_agencia_asigna()
            'inicializa_tab1()
            'call_invocatab1()
        End If
        '
        If tab2_control Then
            recupera_agencia_resumen()
            'inicializa_tab2()
            'call_invocatab2()
        End If
    End Sub
    Private Sub limpiardatos()
        Dim dgvr0l As New DataGridViewRow
        Dim posicion As Integer
        bcancelar = True
        ''''''''''
        'DataGridViewSelectionMode.FullRowSelect()
        ''''''''''
        If tab0_control Then
            Try
                DGVSolicita.EndEdit()
                If Me.DGVSolicita.RowCount <= 1 Then 'En vez de cero (0), se puso 1 
                    Exit Sub
                End If
                dgvr0l = Me.DGVSolicita.CurrentRow
                posicion = dgvr0l.Index

                dvSolCarga.Delete(dgvr0l.Index)
                'Me.DGVSolicita.Rows.GetFirstRow = DataGridViewSelectionMode.FullRowSelect
            Catch exp As Exception
                Dim mensaje1 As String
                mensaje1 = "No debe hacer nada"
            End Try
        End If
        actualizardatos = False
        'Para poder recuperar la nueva fila (Tips)
        If tab0_control Then
            dvSolCarga.RowFilter = ""
        End If
        '
        GrabarToolStripMenuItem.Enabled = False
        CancelarToolStripMenuItem.Enabled = False
        bcancelar = False
    End Sub
    Private Function puedeactualizar(ByVal astipomensaje As Integer) As Boolean
        Dim mensaje As String
        Dim cerrado, aprobado As Integer
        Dim dgvr0 As DataGridViewRow
        '
        If tab0_control Then
            dgvr0 = Me.DGVSolicita.CurrentRow()
            If IsDBNull(dgvr0.Cells(16).Value) Then
                cerrado = iNulo
            Else
                cerrado = CType(dgvr0.Cells(16).Value, Integer)
            End If
            '
            If cerrado = 1 Then
                If astipomensaje = 1 Then
                    mensaje = "No puede suspender la solicitud, por estar cerrada "
                Else
                    mensaje = "No puede grabar la solicitud, por estar cerrada "
                End If
                MessageBox.Show(mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dvSolCarga.RowFilter = ""
                Return False
            End If
            If IsDBNull(dgvr0.Cells(16).Value) Then
                aprobado = iNulo
            Else
                aprobado = CType(dgvr0.Cells(16).Value, Integer)
            End If
            If aprobado = 1 Then
                If astipomensaje = 1 Then
                    mensaje = "No puede suspender la solicitud, por estar asignado a una móvil "
                Else
                    mensaje = "No puede grabar la solicitud, por estar asignado a una móvil "
                End If
                MessageBox.Show(mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dvSolCarga.RowFilter = ""
                Return False
            End If
        End If
        Return True
    End Function
#End Region
#Region "TAB 0"
    Sub call_invocatab0()
        Dim lagenciaxdefecto As Integer
        Dim dtAgenciamilo As New DataTable        
        Try
            actualizardatos = False
            dr4 = Nothing
            dr4 = New OleDbDataAdapter
            ' Recupera el combo de agencias, usando una clase   
            clasesolcomun.idusurio_personalmod = dtoUSUARIOS.IdLogin
            'datahelper
            'rstAgencia = clasesolcomun.ListaAgencia()
            'dr4.Fill(dtAgencia, rstAgencia)
            Dim ds As DataSet = clasesolcomun.ListaAgencia()
            dtAgencia = ds.Tables(0)
            lagenciaxdefecto = dtAgencia.Rows(0).Item(0)
            'Recuperando las ubicacion geografica de la fecha 
            iidpais_tab0 = dtAgencia.Rows(0).Item(4)
            iiddepartamento_tab0 = dtAgencia.Rows(0).Item(3)
            iidprovincia_tab0 = dtAgencia.Rows(0).Item(5)
            iidprovincia_tab1 = iidprovincia_tab0  ' Primera vez la provincia se recupera por el usuario 
            iidprovincia_tab2 = iidprovincia_tab0
            iiddistrito_tab0 = dtAgencia.Rows(0).Item(6)
            '
            dvAgencia = CargarCombo(cmbagencia, dtAgencia, "nombre_agencia", "idagencias", lagenciaxdefecto)
            '            
            'datahelper
            'rstestadorecojo = rstAgencia.NextRecordset            ' 
            dtestadorecojo = ds.Tables(1)
            If solounavez0 Then
                'datahelper
                'dr4.Fill(dtestadorecojo, rstestadorecojo)
                dvestadorecojo = dtestadorecojo.DefaultView
                dvestadorecojo.AllowNew = False
                solounavez0 = False
            End If
            DTimePickersol.Value = Today.ToString("dd/MM/yyyy")
            'Recuperando valor del combo, y lo coloca en idagencia  
            '
            recupera_agencia()
            '
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Asignando él valor ")
        End Try
    End Sub
    Sub GrillaMante()
        'Creando una variable temporal 
        'Dim TempColumn As DataGridTextBoxColumn
        ' Llena una grilla una vez insertado el dataview(dw)
        'Configurando la grilla 
        With DGVSolicita
            .AutoGenerateColumns = False 'Las filas no se generen automaticamente de la bd
            .BackColor = SystemColors.Info
            .BackgroundColor = SystemColors.Info
            .RowHeadersVisible = False
            .BorderStyle = BorderStyle.Fixed3D
            .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)            
            '.Visible = False
            ' Pintando la linea 
            '.CurrentRow.DefaultCellStyle.BackColor = Color.White
            '.CurrentRow.DefaultCellStyle.ForeColor = Color.Black
            'Ancho del data grid
            .Width = 705
            ' aplicando las coordenadas respectivas 
            .Location = New Point(.Location.X, 18)
            .Location = New Point(.Location.Y, 60)
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            '' Creando el data source 
            .DataSource = dvSolCarga
            .ReadOnly = True
        End With
        ' 
        Dim idEstadoImage As New DataGridViewImageColumn '0
        With idEstadoImage
            .DataPropertyName = "imagen"
            .HeaderText = "CT"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DisplayIndex = 0
            .Visible = True
            .Image = iconos.bmActivo
            .Frozen = False
        End With
        DGVSolicita.Columns.Add(idEstadoImage)
        '
        Dim tbnombcltecall0 As New DataGridViewTextBoxColumn
        With tbnombcltecall0 '1      
            'Dim objmaske As New MaskedTextBoxColumn            
            'Dim objmaske As New DataGridViewTextBoxCell
            .DataPropertyName = "nombre_cliente_llamada"
            .HeaderText = "Nombre solicitante"
            '.DefaultCellStyle.Format = CharacterCasing.Upper
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Resizable = DataGridViewTriState.True
        End With
        DGVSolicita.Columns.Add(tbnombcltecall0)
        '
        Dim tbNrosolicitud0 As New DataGridViewTextBoxColumn
        With tbNrosolicitud0  '2 
            .DataPropertyName = "idsolicitud_recojo_carga"
            .HeaderText = "Nº solicitud"
            .Visible = False
        End With
        DGVSolicita.Columns.Add(tbNrosolicitud0)
        ' 
        Dim tbidagencia0 As New DataGridViewTextBoxColumn
        With tbidagencia0 '3
            .DataPropertyName = "idagencias"
            .HeaderText = "Agencia"
            .Visible = False
            .ReadOnly = True
        End With
        DGVSolicita.Columns.Add(tbidagencia0)
        '        
        Dim tbidpersona0 As New DataGridViewTextBoxColumn
        With tbidpersona0 '4
            .DataPropertyName = "idpersona"
            .HeaderText = "Código cliente"
            .Width = 0
            .Visible = False
            .ReadOnly = True
        End With
        DGVSolicita.Columns.Add(tbidpersona0)
        ' 
        Dim tbrazonsocial0 As New DataGridViewTextBoxColumn
        With tbrazonsocial0 '5
            .DataPropertyName = "razon_social"
            .HeaderText = "Cliente"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.Resizable = DataGridViewTriState.True
        End With
        DGVSolicita.Columns.Add(tbrazonsocial0)
        '
        Dim tbidirecosignado0 As New DataGridViewTextBoxColumn
        With tbidirecosignado0 '6
            .DataPropertyName = "iddireccion_consignado"
            .HeaderText = "Código dirección"
            .Visible = False
            .ReadOnly = True
        End With
        DGVSolicita.Columns.Add(tbidirecosignado0)
        '
        Dim tbdireccion0 As New DataGridViewTextBoxColumn
        With tbdireccion0 '7
            .DataPropertyName = "direccion"
            .HeaderText = "Dirección"
            .Resizable = DataGridViewTriState.True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        End With
        DGVSolicita.Columns.Add(tbdireccion0)
        '
        Dim tidcontacto As New DataGridViewTextBoxColumn
        With tidcontacto   '8 
            .HeaderText = "IdContacto"
            .Name = "idcontacto_persona"
            .DataPropertyName = "idcontacto_persona"
            .Visible = False
        End With
        DGVSolicita.Columns.Add(tidcontacto)
        '
        Dim tcontacto As New DataGridViewTextBoxColumn
        With tcontacto   '9 
            .HeaderText = "Nombre Contacto"
            .Name = "nombre_contacto"
            .DataPropertyName = "nombre_contacto"
            .Visible = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        End With
        DGVSolicita.Columns.Add(tcontacto)
        '
        Dim tbhoraini0 As New DataGridViewTextBoxColumn
        'Dim tbhoraini0 As New MaskedTextBox
        With tbhoraini0 '10
            ''    .Name = "hora_ini"
            ''   .Mask = "##:##"
            '.MaskFull = False
            .MaxInputLength = 5
            .DefaultCellStyle.Format = "HH:mm"
            .HeaderText = "Hora Listo"
            .DataPropertyName = "hora_ini"
            .HeaderText = "Hora Listo"
            .DefaultCellStyle.Alignment = HorizontalAlignment.Center
            .Width = 60
        End With
        DGVSolicita.Columns.Add(tbhoraini0)

        Dim tbhorafin0 As New DataGridViewTextBoxColumn
        With tbhorafin0 '11
            .DataPropertyName = "hora_fin"
            .HeaderText = "Hora Cierre"
            .DefaultCellStyle.Format = "HH:mm"
            .MaxInputLength = 5
            .DefaultCellStyle.Alignment = HorizontalAlignment.Center
            .Width = 60
        End With
        DGVSolicita.Columns.Add(tbhorafin0)
        '
        Dim tbnropaquetes0 As New DataGridViewTextBoxColumn
        With tbnropaquetes0  '12 
            .DataPropertyName = "nro_paquetes"
            .HeaderText = "Nº paquetes"
            .Width = 70
            .DefaultCellStyle.Format = "###,###,##0"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        DGVSolicita.Columns.Add(tbnropaquetes0)
        '
        Dim tbpesokg0 As New DataGridViewTextBoxColumn
        With tbpesokg0  '13
            .DataPropertyName = "peso_kg"
            .HeaderText = "Peso"
            .Width = 70
            .DefaultCellStyle.Format = "###,###,###.00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        DGVSolicita.Columns.Add(tbpesokg0)
        '
        Dim tbvolumen0 As New DataGridViewTextBoxColumn
        With tbvolumen0   '14
            .DataPropertyName = "volumen"
            .HeaderText = "Volumen"
            .Width = 70
            .DefaultCellStyle.Format = "###,###,###.00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        DGVSolicita.Columns.Add(tbvolumen0)

        Dim tbobservacion0 As New DataGridViewTextBoxColumn
        With tbobservacion0   '15
            .DataPropertyName = "observacion"
            .Name = "observacion"
            .HeaderText = "Destino"
            '.Width = 120
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        End With
        DGVSolicita.Columns.Add(tbobservacion0)
        '
        Dim tbidestadorecogo0 As New DataGridViewComboBoxColumn
        With tbidestadorecogo0   '16 
            .DataPropertyName = "idestado_recojo"
            .DataSource = dvestadorecojo
            .DisplayMember = "estado_registro"
            .ValueMember = "idestado_registro"
            .HeaderText = "Estado"
            .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            .ReadOnly = True
            .Visible = False
        End With
        DGVSolicita.Columns.Add(tbidestadorecogo0)
        '
        Dim tbcierreso As New DataGridViewCheckBoxColumn
        With tbcierreso   '17 
            .HeaderText = "Cerrado"
            .Name = "cierre_solicitud"
            .DataPropertyName = "cierre_solicitud"
            '.Width = 62
            .ThreeState = False
            .TrueValue = 1   'Cerrado
            .FalseValue = 0
            .ReadOnly = False
            .Visible = False
        End With
        DGVSolicita.Columns.Add(tbcierreso)
        Dim tbaprobado As New DataGridViewCheckBoxColumn
        With tbaprobado   '18 
            .HeaderText = "Asignado"
            .Name = "aprobado"
            .DataPropertyName = "aprobado"
            .ThreeState = False
            .TrueValue = 1   'Aprobado  
            .FalseValue = 0
            .ReadOnly = True
            .Visible = False
        End With
        DGVSolicita.Columns.Add(tbaprobado)
        '
        Dim dgvt_destino As New DataGridViewTextBoxColumn
        With dgvt_destino '19
            .DataPropertyName = "destino"
            .Name = "destino"
            .HeaderText = "destino"                        
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight            
        End With
        DGVSolicita.Columns.Add(dgvt_destino)
    End Sub
    Private Sub LlenaCombo(ByVal dva As DataView, ByVal Cba As ComboBox, ByVal ncampo As String)
        dva.AllowNew = False
        Cba.DataSource = dva
        Cba.DisplayMember = ncampo
        Cba.ValueMember = ncampo
    End Sub
    Private Sub chksol_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chksol.CheckedChanged
        Try
            Dim rstagencialocal As New ADODB.Recordset
            Dim idagencialocal As Integer
            '''' Limpiando el datatable y el dataview  
            dtAgencia = Nothing
            dvAgencia = Nothing
            ' filtro = ""
            Dim ds As DataSet
            If chksol.Checked = False Then 'Llenar el combo para la agencia que esta asociado al usuario .
                clasesolcomun.idusurio_personalmod = usuario ' Solo al usuario que le corresponde 
                'datahelper
                'rstagencialocal = clasesolcomun.ListaAgencia()
                ds = clasesolcomun.ListaAgencia()
                '
                'filtro = "idusuario_personal = " & Trim(usuario)
                'dvAgencia.RowFilter = filtro
            End If
            If chksol.Checked = True Then 'Llenar el combo para todos las agencias            
                clasesolcomun.idusurio_personalmod = iNULO  ' Invocando a todos 
                'datahelper
                'rstagencialocal = clasesolcomun.ListaAgencia()
                ds = clasesolcomun.ListaAgencia()
                'Recupera solo las agencias 
                'dvAgencia.RowFilter = filtro
            End If
            '
            dtAgencia = New DataTable
            dvAgencia = New DataView
            ' 
            'datahelper
            'dr4.Fill(dtAgencia, rstagencialocal)
            dtAgencia = ds.Tables(0)
            dvAgencia = dtAgencia.DefaultView
            dvAgencia.AllowNew = False
            ' Procedimiento de la agencia  
            idagencialocal = dtAgencia.Rows(0).Item(0)
            dvAgencia = CargarCombo(cmbagencia, dtAgencia, "nombre_agencia", "idagencias", idagencialocal)
            recupera_agencia()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub cmbagencia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbagencia.SelectedIndexChanged
        recupera_agencia()
    End Sub
    Private Sub recupera_agencia()
        Dim posicion As Integer
        'Declarando Data row View 
        Dim drvAgencia As DataRowView
        '
        posicion = cmbagencia.SelectedIndex()
        If posicion >= 0 And dvAgencia.Count > 0 Then
            drvAgencia = dvAgencia.Item(posicion)
            idagencia = IIf(IsDBNull(drvAgencia("idagencias")) = True, "0", drvAgencia("idagencias").ToString)
            iidprovincia_tab0 = dvAgencia.Table.Rows(posicion).Item(5)
            Call recupera_solcitud()
        End If
        'Call GrillaMante() 
    End Sub
    'Private Sub DGVSolicita_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVSolicita.CellEnter
    '    Try
    '        Select Case e.ColumnIndex
    '            Case 5
    '                labayuda.Visible = True
    '            Case 7
    '                labayuda.Visible = True
    '            Case 9
    '                labayuda.Visible = True
    '            Case Else
    '                labayuda.Visible = False
    '        End Select
    '    Catch exc As Exception
    '        MsgBox(exc.Message(), MsgBoxStyle.Critical, "Asignando él valor ")
    '    End Try
    'End Sub    
    'Private Sub DGVSolicita_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DGVSolicita.CellBeginEdit
    '    Dim shora As String
    '    '
    '    bcancelar = False
    '    If puedeactualizar(0) Then
    '        'Activa el menu de grabar
    '        actualizardatos = True
    '        GrabarToolStripMenuItem.Enabled = True
    '        CancelarToolStripMenuItem.Enabled = True
    '        'CancelarToolStripMenuItem.Visible = True
    '        If IsDBNull(idagencia) Or idagencia < 1 Then
    '            MessageBox.Show("Debe seleccionar la agencia")
    '            limpiardatos()
    '            Exit Sub
    '        End If
    '    End If
    '    Try
    '        Select Case e.ColumnIndex
    '            Case 7
    '                If IsDBNull(DGVSolicita.Rows(e.RowIndex).Cells(5).Value) = True Then
    '                    MsgBox("No a ingresado el cliente")
    '                    DGVSolicita.CurrentCell = DGVSolicita.Rows(e.RowIndex).Cells(5)
    '                    Exit Sub
    '                End If
    '            Case 9
    '                If IsDBNull(DGVSolicita.Rows(e.RowIndex).Cells(4).Value) Then
    '                    MsgBox("No a ingresado el cliente")
    '                    DGVSolicita.TabIndex = 5
    '                    Me.DGVSolicita.SelectedCells(5).Selected = True
    '                    'Me.DGVSolicita.SelectedRows.Item(4).Index
    '                    Exit Sub
    '                End If
    '                If IsDBNull(DGVSolicita.Rows(e.RowIndex).Cells(7).Value) Then
    '                    MsgBox("No a ingresado la dirección del cliente")
    '                    Me.DGVSolicita.TabIndex = 7
    '                    Me.DGVSolicita.SelectedCells(7).Selected = True
    '                    'Me.DGVSolicita.SelectedRows.Item(4).Index
    '                    Exit Sub
    '                End If
    '            Case 11
    '                Try
    '                    If IsDBNull(DGVSolicita.Rows(e.RowIndex).Cells(10).Value) = True Then
    '                        MsgBox("No ingresado la hora listo")
    '                        Me.DGVSolicita.CurrentCell = DGVSolicita.Rows(e.RowIndex).Cells(10)
    '                        Me.DGVSolicita.SelectedCells(10).Selected = True
    '                        Exit Sub
    '                    Else
    '                        shora = DGVSolicita.Rows(e.RowIndex).Cells(10).Value
    '                        If shora = "" Then
    '                            If DGVSolicita.Rows(e.RowIndex).Cells(10).Value = "" Then
    '                                MsgBox("No ingresado la hora listo")
    '                                Me.DGVSolicita.SelectedCells(10).Selected = True
    '                                Exit Sub
    '                            End If
    '                        End If
    '                    End If
    '                Catch exc As Exception
    '                    MsgBox(exc.Message(), MsgBoxStyle.Critical, "Asignando él valor ")
    '                End Try
    '        End Select
    '    Catch exc As Exception
    '        'DGVSolicita.Focus()
    '        MsgBox(exc.Message(), MsgBoxStyle.Critical, "Asignando él valor ")
    '    End Try
    'End Sub
    'Private Sub DGVSolicita_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVSolicita.CellEndEdit
    '    Try
    '        If Not bcancelar Then
    '            'Dim a As New frmbuscacliente ' Creando una variable         
    '            Dim cadena As String
    '            Dim idclientelocal, iddireccion As Integer
    '            'Dim shora As String
    '            'Dim dhora, dhora_inicio As Date
    '            fila = e.RowIndex
    '            cadena = ""
    '            Select Case e.ColumnIndex
    '                Case 1 'Llamada a cliente convertir lo ingresado a mayusculas     
    '                    DGVSolicita.Rows(e.RowIndex).Cells(1).Value = datollamada
    '                Case 5 ' Cliente
    '                    'DGVSolicita.Rows(e.RowIndex).Cells(5).Value = datorazonsocial                                        
    '                    If IsDBNull(DGVSolicita.Rows(e.RowIndex).Cells(5).Value) Then
    '                        cadena = "%"
    '                    Else
    '                        If DGVSolicita.Rows(e.RowIndex).Cells(5).Value = "" Then
    '                            cadena = "%"
    '                        End If
    '                    End If
    '                    If cadena <> "%" Then
    '                        cadena = UCase(DGVSolicita.Rows(e.RowIndex).Cells(5).Value)
    '                        DGVSolicita.Rows(e.RowIndex).Cells(5).Value = cadena
    '                    End If
    '                    buscarcliente(cadena, e.RowIndex)
    '                Case 7 ' Dirección 
    '                    'DGVSolicita.Rows(e.RowIndex).Cells(7).Value = datodireccion
    '                    DGVSolicita.Rows(e.RowIndex).Cells(7).Value = UCase(DGVSolicita.Rows(e.RowIndex).Cells(7).Value)
    '                    'Recupera el cliente a buscar                                     
    '                    idclientelocal = CType(DGVSolicita.Rows(e.RowIndex).Cells(4).Value, Integer)
    '                    'buscar direccion 
    '                    buscardireccion(idclientelocal, e.RowIndex)
    '                Case 9  'Recupera, los datos consignados (encargado del almacén del cliente) 
    '                    idclientelocal = CType(DGVSolicita.Rows(e.RowIndex).Cells(4).Value, Integer)
    '                    iddireccion = CType(DGVSolicita.Rows(e.RowIndex).Cells(6).Value, Integer)
    '                    buscarcontacto(idclientelocal, iddireccion, fila)
    '                Case 10
    '                    DGVSolicita.Rows(e.RowIndex).Cells(10).Value = shora
    '                    '    shora = CType(DGVSolicita.Rows(e.RowIndex).Cells(10).Value, String)
    '                    '    shora = validar_hora(shora)
    '                    '    If shora = "" Then

    '                    '        DGVSolicita.Rows(e.RowIndex).Cells(10).Value = shora
    '                    '        DGVSolicita.Columns(10).Selected = True
    '                    '        DGVSolicita.CurrentCell = DGVSolicita.Rows(e.RowIndex).Cells(10)
    '                    '        Exit Sub
    '                    '    End If
    '                    '    DGVSolicita.Rows(e.RowIndex).Cells(10).Value = shora
    '                Case 11
    '                    DGVSolicita.Rows(e.RowIndex).Cells(11).Value = shora
    '                    '    shora = CType(DGVSolicita.Rows(e.RowIndex).Cells(11).Value, String)
    '                    '    shora = validar_hora(shora)
    '                    '    If shora = "" Then
    '                    '        DGVSolicita.Rows(e.RowIndex).Cells(11).Value = shora
    '                    '        Exit Sub
    '                    '    End If
    '                    '    Try
    '                    '        dhora = CType(shora, Date)
    '                    '        dhora_inicio = CType(DGVSolicita.Rows(e.RowIndex).Cells(10).Value, Date)
    '                    '        If dhora < dhora_inicio Then
    '                    '            MessageBox.Show("La hora cierre debe ser mayor a la hora listo ")
    '                    '            DGVSolicita.Rows(e.RowIndex).Cells(11).Value = ""

    '                    '            Exit Sub
    '                    '        End If
    '                    '    Catch ex As Exception
    '                    '        shora = ""
    '                    '    End Try
    '                    '    DGVSolicita.Rows(e.RowIndex).Cells(11).Value = shora
    '            End Select
    '        End If
    '    Catch exc As Exception
    '        MsgBox(exc.Message(), MsgBoxStyle.Critical, "Asignando él valor ")
    '    End Try

    'End Sub
    Private Sub DGVSolicita_CellErrorTextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVSolicita.CellErrorTextChanged
        'Select Case e.ColumnIndex
        '    Case 5
        '        Try
        '            If IsDBNull(DGVSolicita.Rows(e.RowIndex).Cells(5).Value) = True Then
        '                DGVSolicita.CurrentCell = DGVSolicita.Rows(e.RowIndex).Cells(e.ColumnIndex - 1)
        '            End If
        '        Catch exp As Exception
        '            '
        '        End Try
        'End Select
    End Sub
    Private Sub grabarsolicitud(ByVal afila As Integer)
        'Dim drpais, drdepa, drprov, drdist, drund As DataRowView
        'dim ls_obs As String
        Dim ll_row, ll_rows As Long
        Dim ls_fecha_recojo As String
        'datahelper
        'Dim rstnrosolicitud, rsteterrado As ADODB.Recordset
        Dim rstnrosolicitud, rsteterrado As DataTable
        Dim nrosolicitud As Long
        Dim lvolumen, lpeso_kg As Double
        Dim lnro_paquetes As Long
        Dim estadorecojo As Integer
        'Recupera la agencia 
        If IsDBNull(idagencia) Then
            'valida la agencia tiene que ser ingresada 
        End If
        DGVSolicita.EndEdit()
        ' Recupera el maximo nro de filas a insertar (datagridview) 
        ll_rows = DGVSolicita.Rows.Count
        'Verifica que no el datagirdview no este vacio 
        '
        'Recupera la fecha 
        ls_fecha_recojo = DTimePickersol.Value.ToString()
        'For ll_row = 0 To ll_rows - 1
        ll_row = afila
        Try
            If IsDBNull(DGVSolicita.Rows(ll_row).Cells(6).Value) = True Then
                ClaseSolReco.Iddireccion = iNulo  ' No tiene direccion
            Else
                ClaseSolReco.Iddireccion = DGVSolicita.Rows(ll_row).Cells(6).Value
            End If
            If IsDBNull(DGVSolicita.Rows(ll_row).Cells(8).Value) = True Then
                ClaseSolReco.contacto_persona = dNULO  ' No tiene contacto 
            Else
                ClaseSolReco.contacto_persona = DGVSolicita.Rows(ll_row).Cells(8).Value
            End If
            If bguardardireccion Then
                ClaseSolReco.tipodireccion = tipodireccion
                ClaseSolReco.idubigeo = idubigeo
                ClaseSolReco.idpais = idpais
                ClaseSolReco.iddpto = iddpto
                ClaseSolReco.idprov = idprov
                ClaseSolReco.iddistrito = ModSolRecojoCarga.iddistrito
                ClaseSolReco.sdireccion = sdireccion
                ClaseSolReco.srefllegada = srefllegada
                ClaseSolReco.snrodcto = snrodcto
                ClaseSolReco.apellido_y_nombres = sapellidos_nombres
                'ClaseSolReco.snombre = snombre
                'ClaseSolReco.sapepaterno = sapepaterno
                'ClaseSolReco.sapematerno = sapematerno
                ClaseSolReco.idsucuenta = idsucuenta
                ClaseSolReco.idcargo = idcargo
                ClaseSolReco.idtipdcto = idtipdcto
                ClaseSolReco.idsexo = idsexo
            End If
            If IsDBNull(DGVSolicita.Rows(ll_row).Cells(2).Value) Then
                ClaseSolReco.control = 1   '-- Inserta 
                ClaseSolReco.nrosolicitud = iNulo
            Else
                ClaseSolReco.control = 0   '-- Actualiza
                ClaseSolReco.nrosolicitud = CType(DGVSolicita.Rows(ll_row).Cells(2).Value, Integer)
            End If
            ClaseSolReco.clientellamada = DGVSolicita.Rows(ll_row).Cells(1).Value
            'Verifica el campo de la agencia
            ClaseSolReco.idagencia = idagencia
            ClaseSolReco.fecharecojo = ls_fecha_recojo
            ClaseSolReco.Idcliente = DGVSolicita.Rows(ll_row).Cells(4).Value
            'ClaseSolReco.Iddireccion = DGVSolicita.Rows(ll_row).Cells(6).Value
            'ClaseSolReco.contacto_persona = DGVSolicita.Rows(ll_row).Cells(8).Value
            '
            ClaseSolReco.hora_ini = DGVSolicita.Rows(ll_row).Cells(10).Value
            ClaseSolReco.hora_fin = DGVSolicita.Rows(ll_row).Cells(11).Value
            lnro_paquetes = IIf(IsDBNull(DGVSolicita.Rows(ll_row).Cells(12).Value), 0, DGVSolicita.Rows(ll_row).Cells(12).Value)
            ClaseSolReco.nropaquetes = IIf(lnro_paquetes.ToString() <> "", lnro_paquetes, iNulo)
            'ClaseSolReco.nropaquetes = DGVSolicita.Rows(ll_row).Cells(10).Value
            lpeso_kg = IIf(IsDBNull(DGVSolicita.Rows(ll_row).Cells(13).Value), 0, DGVSolicita.Rows(ll_row).Cells(13).Value)
            ClaseSolReco.peso_kg = IIf(lpeso_kg.ToString() <> "", lpeso_kg, dNULO)
            lvolumen = IIf(IsDBNull(DGVSolicita.Rows(ll_row).Cells(14).Value), 0, DGVSolicita.Rows(ll_row).Cells(14).Value)
            ClaseSolReco.volumen = IIf(lvolumen.ToString() <> "", lvolumen, dNULO)
            'lvolumen = DGVSolicita.Rows(ll_row).Cells(12).Value
            'ls_obs = IIf(IsDBNull(DGVSolicita.Rows(ll_row).Cells(15).Value), "null", DGVSolicita.Rows(ll_row).Cells(15).Value)
            '
            If IsDBNull(DGVSolicita.Rows(ll_row).Cells(15).Value) = True Then
                ClaseSolReco.observacion = sNULO
            Else
                ClaseSolReco.observacion = CType(DGVSolicita.Rows(ll_row).Cells(15).Value, String)
            End If
            '
            'ClaseSolReco.estadorecojo= DGVSolicita.Rows(ll_row).Cells(14).Value
            If IsDBNull(DGVSolicita.Rows(ll_row).Cells(16).Value) Then
                ClaseSolReco.estadorecojo = iNulo
            Else
                ClaseSolReco.estadorecojo = DGVSolicita.Rows(ll_row).Cells(16).Value
            End If
            If IsDBNull(DGVSolicita.Rows(ll_row).Cells(19).Value) Then
                ClaseSolReco.destino = sNULO
            Else
                ClaseSolReco.destino = DGVSolicita.Rows(ll_row).Cells(19).Value
            End If
            'Variables globales -- 
            ClaseSolReco.ip = dtoUSUARIOS.IP
            'ClaseSolReco.ip = "192.168.50.196"
            ClaseSolReco.idrol_usuario = dtoUSUARIOS.IdRol
            'ClaseSolReco.idrol_usuario = 7 ' temporal el usuario de carga 
            ClaseSolReco.idusuario = dtoUSUARIOS.IdLogin
            ClaseSolReco.estadorecojo = 1
            'ClaseSolReco.idusuario = 1
            'Insertando la fila 
            Try
                Dim ds As DataSet = ClaseSolReco.actualizar()
                rstnrosolicitud = ds.Tables(0)
                If rstnrosolicitud.Rows.Count > 0 Then
                    nrosolicitud = rstnrosolicitud.Rows(0).Item(0)
                    estadorecojo = rstnrosolicitud.Rows(0).Item(1)
                    DGVSolicita.Rows(ll_row).Cells(2).Value = nrosolicitud
                    DGVSolicita.Rows(ll_row).Cells(16).Value = estadorecojo
                End If
                ' Recuperando el cursor de errores 
                rsteterrado = ds.Tables(1)
                If rsteterrado.Rows.Count = 0 Then
                Else
                    If CType(rsteterrado.Rows(0).Item(0), Integer) <> 0 Then
                        MessageBox.Show("Descripción: " & CType(rsteterrado.Rows(0).Item(1), String), "ORACLE -> Error: " & CType(rsteterrado.Rows(0).Item(0), String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If

                'datahelper
                'rstnrosolicitud = ClaseSolReco.actualizar()
                'If rstnrosolicitud.Fields.Count > 0 Then
                '    nrosolicitud = rstnrosolicitud.Fields(0).Value
                '    estadorecojo = rstnrosolicitud.Fields(1).Value
                '    DGVSolicita.Rows(ll_row).Cells(2).Value = nrosolicitud
                '    DGVSolicita.Rows(ll_row).Cells(16).Value = estadorecojo
                'End If
                '' Recuperando el cursor de errores 
                'rsteterrado = rstnrosolicitud.NextRecordset
                'If rsteterrado.Fields.Count = 0 Then
                'Else
                '    If CType(rsteterrado.Fields(0).Value, Integer) <> 0 Then
                '        MessageBox.Show("Descripción: " & CType(rsteterrado.Fields(1).Value, String), "ORACLE -> Error: " & CType(rsteterrado.Fields(0).Value, String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    End If
                'End If
            Catch Qex As Exception
                MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch qex As Exception
            MessageBox.Show(qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        actualizardatos = False
        bguardardireccion = False
        'Limpiar los datos nuevos (Mantenimiento de clientes) 
        Limpiarmodulo_datosnuevos()
        CancelarToolStripMenuItem.Enabled = False
        GrabarToolStripMenuItem.Enabled = False
    End Sub
    Private Sub DGVSolicita_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        CapsOn()
    End Sub
    Private Function validar_campos_tab0(ByVal afilas As Integer) As Boolean
        If Not bcancelar Then
            If IsDBNull(DGVSolicita.Rows(afilas).Cells(0).Value) Then
                MessageBox.Show("No registrado la llamada")
                Return False
            End If
            If IsDBNull(DGVSolicita.Rows(afilas).Cells(5).Value) Then
                MessageBox.Show("No registrado al cliente")
                DGVSolicita.CurrentCell = DGVSolicita.Rows(afilas).Cells(5)
                Return False
            End If
            If IsDBNull(DGVSolicita.Rows(afilas).Cells(7).Value) Then
                MessageBox.Show("No registrado la direccion del cliente")
                DGVSolicita.CurrentCell = DGVSolicita.Rows(afilas).Cells(7)
                Return False
            End If
            If IsDBNull(DGVSolicita.Rows(afilas).Cells(9).Value) Then
                MessageBox.Show("No registrado al contacto")
                DGVSolicita.CurrentCell = DGVSolicita.Rows(afilas).Cells(9)
                Return False
            End If
            If IsDBNull(DGVSolicita.Rows(afilas).Cells(10).Value) Then
                MessageBox.Show("No registrado la hora listo del cliente")
                DGVSolicita.CurrentCell = DGVSolicita.Rows(afilas).Cells(10)
                Return False
            End If
            If IsDBNull(DGVSolicita.Rows(afilas).Cells(11).Value) Then
                MessageBox.Show("No registrado la hora cierre del cliente")
                DGVSolicita.CurrentCell = DGVSolicita.Rows(afilas).Cells(11)
                Return False
            End If
            actualizardatos = True
            Return True
        End If
    End Function
    Private Sub DGVSolicita_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGVSolicita.CellFormatting
        Dim strvar As String = ""
        Try
            If Not bcancelar Then
                strvar = e.RowIndex.ToString()
                If e.ColumnIndex = 16 Then
                    Dim IdEstado As Integer
                    'IdEstado = DGVSolicita.Rows().Count
                    If e.RowIndex > 0 And DGVSolicita.Rows().Count - 1 >= e.RowIndex Then
                        If IsDBNull(DGVSolicita.Rows(e.RowIndex - 1).Cells(16).Value) = False Then
                            IdEstado = DGVSolicita.Rows(e.RowIndex - 1).Cells(16).Value
                        Else
                            IdEstado = 0
                        End If
                        'IdEstado = IIf(IsNothing(DataGridViewUser.Rows(e.RowIndex).Cells(7).Value), 0, DataGridViewUser.Rows(e.RowIndex).Cells(7).Value)
                        Select Case IdEstado
                            Case 11  ' Por recoger 
                                DGVSolicita.Rows(e.RowIndex - 1).Cells(0).Value = iconos.bmActivo
                                'e.Value = iconos.bmActivo
                            Case 10
                                'e.Value = iconos.bmPendiente
                                DGVSolicita.Rows(e.RowIndex - 1).Cells(0).Value = iconos.bmPendiente
                            Case 16
                                DGVSolicita.Rows(e.RowIndex - 1).Cells(0).Value = iconos.bmEliminado
                                'e.Value = iconos.bmEliminado
                            Case Else
                                DGVSolicita.Rows(e.RowIndex - 1).Cells(0).Value = iconos.bmActivo
                                'e.Value = iconos.bmActivo
                        End Select
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema" & strvar)
        End Try
    End Sub
    'Private Sub DGVSolicita_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DGVSolicita.CellValidating
    '    'Dim shora As String
    '    Dim dhora, dhora_inicio As Date
    '    Dim snumero As String
    '    ' Formateando a mayusculas el campo 
    '    Try
    '        If Not bcancelar Then
    '            Select Case e.ColumnIndex
    '                Case 1
    '                    datollamada = UCase(e.FormattedValue)
    '                    '        Case 5
    '                    '            'datorazonsocial = UCase(e.FormattedValue)
    '                    '            '  If IsDBNull(DGVSolicita.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) = True Then
    '                    '            If IsDBNull(e.FormattedValue) = True Then
    '                    '                e.Cancel = True
    '                    '                Return
    '                    '            Else
    '                    '                If e.FormattedValue = "" Then
    '                    '                    e.Cancel = True
    '                    '                    Return
    '                    '                End If
    '                    '            End If
    '                    '            e.Cancel = False
    '                    '            Return
    '                    '        Case 7
    '                    '            datodireccion = UCase(e.FormattedValue)                   
    '                    '        Case 10 ' Formateando los campos Hora listo    
    '                    '            'Dim longitud As Integer
    '                    '            'longitud = Len(e.FormattedValue)
    '                    '            'Dim KeyAscii As Short = CInt(Keys.F1) ' 
    '                    '            'KeyAscii = CShort(SoloNumeros(KeyAscii))
    '                    '            'If KeyAscii = 0 Then
    '                    '            '    e.Cancel = True
    '                    '            '    Return
    '                    '            'End If
    '                    '            'If longitud < 4 Then
    '                    '            '    ' se debe rellenar de 0 
    '                    '            'End If
    '                    '        Case 11 ' Formateando los campos Hora Cierre 
    '                Case 10
    '                    shora = e.FormattedValue
    '                    shora = validar_hora(shora)
    '                    If shora = "" Then
    '                        e.Cancel = True
    '                        DGVSolicita.Rows(e.RowIndex).Cells(10).Value = ""
    '                        Exit Sub
    '                    End If
    '                    e.Cancel = False
    '                    Exit Sub
    '                Case 11
    '                    shora = e.FormattedValue
    '                    shora = validar_hora(shora)
    '                    If shora = "" Then
    '                        e.Cancel = True
    '                        DGVSolicita.Rows(e.RowIndex).Cells(11).Value = ""
    '                        Exit Sub
    '                    End If
    '                    Try
    '                        dhora = CType(shora, Date)
    '                        dhora_inicio = CType(DGVSolicita.Rows(e.RowIndex).Cells(10).Value, Date)
    '                        If dhora < dhora_inicio Then
    '                            MessageBox.Show("La hora cierre debe ser mayor a la hora listo ")
    '                            DGVSolicita.Rows(e.RowIndex).Cells(11).Value = ""
    '                            e.Cancel = True
    '                            Exit Sub
    '                        End If
    '                    Catch ex As Exception
    '                        shora = ""
    '                    End Try
    '                    DGVSolicita.Rows(e.RowIndex).Cells(11).Value = shora
    '                    e.Cancel = False
    '                Case 12 ' Enteros  
    '                    snumero = e.FormattedValue
    '                    If Not valida_numeroentero(snumero) Then
    '                        e.Cancel = True
    '                    Else
    '                        e.Cancel = False
    '                    End If
    '                    Exit Sub
    '                Case 13 ' 
    '                    snumero = e.FormattedValue
    '                    If Not valida_numerodouble(snumero) Then
    '                        '                            DGVSolicita.Rows(e.RowIndex).Cells(13).Value = 0
    '                        e.Cancel = True
    '                    Else
    '                        e.Cancel = False
    '                    End If
    '                    Exit Sub
    '                Case 14
    '                    snumero = e.FormattedValue
    '                    If Not valida_numerodouble(snumero) Then
    '                        '                           DGVSolicita.Rows(e.RowIndex).Cells(14).Value = 0
    '                        e.Cancel = True
    '                    Else
    '                        e.Cancel = False
    '                    End If
    '                    Exit Sub
    '            End Select
    '        End If
    '    Catch exc As Exception
    '        MsgBox(exc.ToString, MsgBoxStyle.Exclamation, "Seguridad Sistema")
    '    End Try
    'End Sub
    'Private Sub DGVSolicita_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVSolicita.RowValidated
    ' Modificado por mendoza 11/08/2006 
    ' Dim a As System.Windows.Forms.DataGridViewCellCancelEventArgs        
    'Try
    '    If Not bcancelar Then
    '        If IsDBNull(DGVSolicita.Rows(e.RowIndex).Cells(1).Value) Then
    '            DGVSolicita.TabIndex = 1
    '            DGVSolicita.GetCellDisplayRectangle(1, e.RowIndex, True)
    '        Else
    '            If LTrim(RTrim(DGVSolicita.Rows(e.RowIndex).Cells(1).Value)) = "" Then
    '                DGVSolicita.TabIndex = 1
    '                DGVSolicita.GetCellDisplayRectangle(1, e.RowIndex, True)
    '            End If
    '        End If
    '        'Valida los campos necesarios para generar una solicitud 
    '        'DGVResumen.Rows(e.RowIndex).Cells(10).Value
    '        If actualizardatos Then
    '            'validando los campos 
    '            If validar_campos_tab0(e.RowIndex) Then
    '                ' Listo para grabar 
    '                grabarsolicitud(e.RowIndex)
    '            End If
    '        End If
    '    End If
    'Catch exc As Exception
    '    MsgBox(exc.Message(), MsgBoxStyle.Critical, "Asignando él valor ")
    'End Try
    'End Sub
    'Private Sub DGVSolicita_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DGVSolicita.RowValidating
    '    Dim dgvr As New DataGridViewRow
    '    Dim fila As New Integer
    '    Dim mensaje As String
    '    Dim cancela As Boolean
    '    dgvr = Me.DGVSolicita.CurrentRow()
    '    fila = dgvr.Index
    '    '''''''''''''
    '    Try
    '        If Not bcancelar Then
    '            cancela = False
    '            'Valida Cuando no haga nada 
    '            If DGVDireccion.Visible = True Or _
    '                DGVCliente.Visible = True Or DGVContacto.Visible = True Then
    '                e.Cancel = False
    '                Return
    '            End If
    '            '
    '            If Not cancela Then
    '                mensaje = "Registrar al solicitante"
    '                If IsDBNull(DGVSolicita.Rows(fila).Cells(1).Value) = True Then ' Valida el cliente 
    '                    MessageBox.Show(Me, mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    DGVSolicita.CurrentCell = DGVSolicita.Rows(fila).Cells(1)  'Ubica en la posicion señalada
    '                    cancela = True
    '                Else
    '                    If DGVSolicita.Rows(fila).Cells(1).Value = "" Then  'Verifica el nombre que hace la llamada 
    '                        MessageBox.Show(Me, mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                        DGVSolicita.CurrentCell = DGVSolicita.Rows(fila).Cells(1)  'Ubica en la posicion señalada                
    '                        cancela = True
    '                    End If
    '                End If
    '            End If
    '            ' 
    '            If Not cancela Then
    '                mensaje = "Registrar al cliente"
    '                If IsDBNull(DGVSolicita.Rows(fila).Cells(5).Value) = True Then ' Verifica la razon social 
    '                    MessageBox.Show(Me, mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    DGVSolicita.CurrentCell = DGVSolicita.Rows(fila).Cells(5)  'Ubica en la posicion señalada                
    '                    cancela = True
    '                Else
    '                    If DGVSolicita.Rows(fila).Cells(5).Value = "" Then  'Verifica el nombre que hace la llamada 
    '                        MessageBox.Show(Me, mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                        DGVSolicita.CurrentCell = DGVSolicita.Rows(fila).Cells(5)  'Ubica en la posicion señalada                
    '                        cancela = True
    '                    End If
    '                End If
    '            End If
    '            '
    '            If Not cancela Then
    '                mensaje = "Registrar la dirección"
    '                If IsDBNull(DGVSolicita.Rows(fila).Cells(7).Value) = True Then ' Verifica la direccion 
    '                    MessageBox.Show(Me, mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    DGVSolicita.CurrentCell = DGVSolicita.Rows(fila).Cells(7)  'Ubica en la posicion señalada                
    '                    cancela = True
    '                Else
    '                    If DGVSolicita.Rows(fila).Cells(7).Value = "" Then  'Verifica la direccion 
    '                        MessageBox.Show(Me, mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                        DGVSolicita.CurrentCell = DGVSolicita.Rows(fila).Cells(7)  'Ubica en la posicion señalada                
    '                        cancela = True
    '                    End If
    '                End If
    '            End If
    '            '
    '            If Not cancela Then
    '                mensaje = "Registrar al contacto"
    '                If IsDBNull(DGVSolicita.Rows(fila).Cells(9).Value) = True Then ' Verifica la direccion 
    '                    MessageBox.Show(Me, mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    DGVSolicita.CurrentCell = DGVSolicita.Rows(fila).Cells(9)  'Ubica en la posicion señalada                
    '                    cancela = True
    '                Else
    '                    If DGVSolicita.Rows(fila).Cells(9).Value = "" Then  'Verifica al contacto 
    '                        MessageBox.Show(Me, mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                        DGVSolicita.CurrentCell = DGVSolicita.Rows(fila).Cells(9)  'Ubica en la posicion señalada                
    '                        cancela = True
    '                    End If
    '                End If
    '            End If
    '            '
    '            If Not cancela Then
    '                mensaje = "Registrar la hora listo"
    '                If IsDBNull(DGVSolicita.Rows(fila).Cells(10).Value) = True Then ' Verifica la direccion             
    '                    MessageBox.Show(Me, mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    DGVSolicita.CurrentCell = DGVSolicita.Rows(fila).Cells(10)  'Ubica en la posicion señalada                
    '                    cancela = True
    '                Else
    '                    If DGVSolicita.Rows(fila).Cells(10).Value = "" Then  'Verifica la direccion 
    '                        MessageBox.Show(Me, mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                        DGVSolicita.CurrentCell = DGVSolicita.Rows(fila).Cells(10)  'Ubica en la posicion señalada                
    '                        cancela = True
    '                    End If
    '                End If
    '            End If
    '            '
    '            If Not cancela Then
    '                mensaje = "Registrar la hora cierre"
    '                If IsDBNull(DGVSolicita.Rows(fila).Cells(11).Value) = True Then ' Verifica la direccion             
    '                    MessageBox.Show(Me, mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    DGVSolicita.CurrentCell = DGVSolicita.Rows(fila).Cells(11)  'Ubica en la posicion señalada                
    '                    cancela = True
    '                Else
    '                    If DGVSolicita.Rows(fila).Cells(11).Value = "" Then  'Verifica la direccion 
    '                        MessageBox.Show(Me, mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                        DGVSolicita.CurrentCell = DGVSolicita.Rows(fila).Cells(11)  'Ubica en la posicion señalada                
    '                        cancela = True
    '                    End If
    '                End If
    '            End If
    '            '
    '            e.Cancel = cancela
    '        End If 'bcancelar
    '    Catch ex As Exception
    '        ' no debe hacer nada  
    '        e.Cancel = False
    '    End Try
    'End Sub
    Sub recupera_solcitud()
        Dim ls_fecha_recojo As String
        'Dim rsteterrado As Recordset
        'If IsDBNull(idagencia) Or idagencia < 1 Then
        '    MessageBox.Show("Ninguna agencia a sido seleccionada", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If
        If Not bcancelar Then
            ls_fecha_recojo = DTimePickersol.Value.ToString()
            'Recuperando la nueva solicitud 
            'datahelper
            'rstSolCarga = Nothing
            dtSolCarga.Clear()
            dvSolCarga = Nothing
            '
            bcancelar = True
            DGVSolicita.Columns.Clear()
            bcancelar = False
            ClaseSolReco.idagencia = idagencia
            ClaseSolReco.fecharecojo = ls_fecha_recojo
            'datahelper
            'rstSolCarga = ClaseSolReco.get_solicitud
            'If rstSolCarga.Fields.Count >= 0 Then
            'dr4.Fill(dtSolCarga, rstSolCarga)
            dtSolCarga = ClaseSolReco.get_solicitud
            'datahelper
            'If dtSolCarga.Fields.Count >= 0 Then
            If dtSolCarga.Rows.Count >= 0 Then
                dvSolCarga = dtSolCarga.DefaultView
                dvSolCarga.AllowNew = True
            End If
            '
            GrillaMante()
            'DGVSolicita.CurrentCell = DGVSolicita.Rows(DGVSolicita.Rows.Count).Cells(1)
        End If
    End Sub
    Sub buscarcliente(ByVal cadbusqueda As String, ByVal fila As Integer)
        Dim rstcliente As New ADODB.Recordset
        Dim dtcliente As New DataTable
        Dim dvcliente As New DataView
        Dim clasebusqueda As New dtoSolRecojoBusqueda
        Dim mensaje As String
        '
        clasebusqueda.busquedacondicicionclte = cadbusqueda
        rstcliente = clasebusqueda.BusquedaCliente
        dr4.Fill(dtcliente, rstcliente)
        dvcliente = dtcliente.DefaultView
        dvcliente.AllowNew = False
        grilla_cliente(dvcliente)
        If dvcliente.Count = 0 Then  'No existe el cliente  
            mensaje = "Cliente no está registrado"
            ModSolRecojoCarga.frmfilapadre = fila
            DGVSolicita.Rows(fila).Cells(5).Value = Nothing
            MessageBox.Show(Me, mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DGVSolicita.EndEdit()
            DGVSolicita.CurrentCell = DGVSolicita.Rows(fila).Cells(5)
            Return
        End If
        If dvcliente.Count = 1 Then  'Si encuentra 1 solo registro traer la direccion
            ModSolRecojoCarga.frmfilapadre = fila
            trae_cliente(fila) 'Omendoza se debe trae el cliente 
            Return
        End If
        If dvcliente.Count > 1 Then
            'DGVSolicita.Enabled = False  'Por ahora no desahabilita omendoza 
            ModSolRecojoCarga.frmfilapadre = fila
            bcancelar = True
            DGVCliente.Visible = True
            DGVCliente.Focus()
            bcancelar = False
        End If
    End Sub
    Private Sub buscardireccion(ByVal lidcliente As Integer, ByVal fila As Integer)
        'datahelper
        'Dim rstdireccionl As New ADODB.Recordset
        Dim rstdireccionl As DataTable
        Dim dtdireccionl As New DataTable
        Dim dvdireccionl As New DataView
        Dim clasebusquedal As New dtoSolRecojoBusqueda
        ' Buscar direccion 
        'clasebusquedal.busquedacondicicionclte = cadbusqueda
        clasebusquedal.Idcliente = lidcliente
        clasebusquedal.Idprovincia = iidprovincia_tab0
        '
        'datahelper
        'rstdireccionl = clasebusquedal.BusquedaDireccion
        'dr4.Fill(dtdireccionl, rstdireccionl)
        rstdireccionl = clasebusquedal.BusquedaDireccion
        dtdireccionl = rstdireccionl
        dvdireccionl = dtdireccionl.DefaultView
        dvdireccionl.AllowNew = False
        grilla_direccion(dvdireccionl)
        If dvdireccionl.Count = 0 Then
            Dim a As New FrmMantClteCarga
            Dim resultado As DialogResult
            '
            DGVDireccion.Visible = False
            ModSolRecojoCarga.idagencia = idagencia
            ModSolRecojoCarga.frmfilapadre = fila
            ModSolRecojoCarga.iddireccion_consignado = iNULO   'Valor nulo 
            bcancelar = True  'Desactivando el control 

            'resultado = a.ShowDialog()
            Acceso.Asignar(a, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                resultado = a.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If


            'Recuperando los valores para actualizar en lo que es la dirección y consignado 
            If Not ModSolRecojoCarga.bcancelar Then
                Recuperadireccionnueva()
            End If
            'Debe retorna a la fila que se ha quedado 
            bcancelar = False  'Activando el control  
            ' MsgBox("llamar a una ventanita para llenar la direccion y contacto")            
            DGVSolicita.Focus()
            DGVSolicita.CurrentCell = DGVSolicita.Rows(fila).Cells(10)
            '
        End If
        If dvdireccionl.Count = 1 Then  'Si encuentra 1 solo registro traer la direccion
            DGVCliente.Visible = False
            bcancelar = True
            ModSolRecojoCarga.frmfilapadre = fila
            trae_direccion(fila) 'Omendoza se debe traer el cliente 
            bcancelar = False
        End If
        If dvdireccionl.Count > 1 Then
            'DGVSolicita.Enabled = False
            bcancelar = True
            ModSolRecojoCarga.frmfilapadre = fila
            DGVCliente.Visible = False
            DGVDireccion.Visible = True
            DGVDireccion.Focus()
            bcancelar = False
        End If
    End Sub
    Private Sub trae_direccion(ByVal alfila As Integer)
        Dim dgvr As DataGridViewRow
        Dim li_iddireccion, lidcliente As Integer
        Dim ls_direccion As String
        'Recuperando el valor del cliente 
        dgvr = Me.DGVDireccion.CurrentRow()
        li_iddireccion = CType(dgvr.Cells(1).Value, Integer)
        ls_direccion = dgvr.Cells(0).Value.ToString()
        ' Pasando valor al datawindow padre          
        DGVDireccion.Visible = False
        DGVSolicita.Rows(alfila).Cells(6).Value = li_iddireccion
        DGVSolicita.Rows(alfila).Cells(7).Value = ls_direccion
        lidcliente = DGVSolicita.Rows(alfila).Cells(4).Value          'Recupera la direccion del cliente 
        DGVSolicita.CurrentCell = DGVSolicita.Rows(alfila).Cells(9)   'Coloco la nueva posición  
        ModSolRecojoCarga.frmfilapadre = alfila
        buscarcontacto(lidcliente, li_iddireccion, alfila)
    End Sub
    'Private Sub DGVCliente_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGVCliente.DoubleClick
    '    ' Debe regresar 
    '    'DGVCliente.Visible = False
    '    'DGVSolicita.Enabled = True
    'End Sub
    Private Sub trae_cliente(ByVal alfila As Integer)
        Dim dgvr As DataGridViewRow
        Dim li_idcliente As Integer
        Dim ls_cliente, ls_clte_concatenado As String
        Dim ls_cadena As String
        'Recuperando el valor del cliente 
        dgvr = Me.DGVCliente.CurrentRow()
        li_idcliente = CType(dgvr.Cells(1).Value, Integer)
        ls_cliente = dgvr.Cells(0).Value.ToString()
        ls_cadena = dgvr.Cells(3).Value.ToString()
        ls_cadena = ls_cadena + " - " + dgvr.Cells(4).Value.ToString()
        ls_clte_concatenado = ls_cliente + " (" + ls_cadena + ")"
        ' Pasando valor al datawindow padre  
        DGVSolicita.Rows(alfila).Cells(4).Value = li_idcliente
        DGVSolicita.Rows(alfila).Cells(5).Value = ls_clte_concatenado
        'Como trajo se debe colocar en la siguiente posicion 
        'DGVSolicita.Focus()
        'DGVSolicita.CurrentCell = DGVSolicita.Rows(alfila).Cells(7)  'Coloco la nueva posición  
        'DGVCliente.Visible = False
        'Busca Direccion 
        buscardireccion(li_idcliente, alfila)
    End Sub
    Sub grilla_cliente(ByVal adataview As DataView)
        DGVCliente.Columns.Clear()
        DGVCliente.Width = Me.DGVSolicita.Width
        With DGVCliente
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .BackgroundColor = Color.White
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False  'Para que no incremente la fila
            .AutoGenerateColumns = False ''Las filas no se generen automaticamente de la bd
            .DataSource = adataview
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            .RowHeadersVisible = False
            .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '
            .Location = New Point(Me.DGVSolicita.Location.X, Me.DGVSolicita.Location.Y + 70)
        End With
        'Creando los campos del tipo DataGridViewTextBoxColumn
        Dim dgvtbcrazonsocial As New DataGridViewTextBoxColumn
        With dgvtbcrazonsocial '0
            .DataPropertyName = "RAZON_SOCIAL"
            .HeaderText = "Razon Social"
            .ToolTipText = "Razón Social"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DGVCliente.Columns.Add(dgvtbcrazonsocial)
        '
        Dim dgvtbcidcliente As New DataGridViewTextBoxColumn
        With dgvtbcidcliente '1
            .HeaderText = "Código"
            .Name = "IDPERSONA"
            .DataPropertyName = "idpersona"
            .ReadOnly = True
            .Visible = False
        End With
        DGVCliente.Columns.Add(dgvtbcidcliente)
        '
        Dim dgvtbcapellido_paterno As New DataGridViewTextBoxColumn
        With dgvtbcapellido_paterno '2
            .DataPropertyName = "apellidos_y_nombres"
            .Name = "apellidos_y_nombres"
            .HeaderText = "Apellidos y Nombres"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DGVCliente.Columns.Add(dgvtbcapellido_paterno)
        '
        'Dim dgvtbcapellido_materno As New DataGridViewTextBoxColumn
        'With dgvtbcapellido_materno '
        '    .DataPropertyName = "apellido_materno"
        '    .HeaderText = "Apellido materno"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '    .ReadOnly = True
        'End With
        'DGVCliente.Columns.Add(dgvtbcapellido_materno)
        '
        'Dim dgvtbcnombre As New DataGridViewTextBoxColumn
        'With dgvtbcnombre '4
        '    .DataPropertyName = "nompre_persona"
        '    .HeaderText = "Nombre"
        '    .ReadOnly = True
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'End With
        'DGVCliente.Columns.Add(dgvtbcnombre)
        '
        Dim dgvtbctipoidentidad As New DataGridViewTextBoxColumn
        With dgvtbctipoidentidad '3
            .DataPropertyName = "tipo_doc_identidad"
            .HeaderText = "Documento identidad"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DGVCliente.Columns.Add(dgvtbctipoidentidad)
        '
        Dim dgvtbcnu_docusuna As New DataGridViewTextBoxColumn
        With dgvtbcnu_docusuna '4
            .DataPropertyName = "nu_docu_suna"
            .HeaderText = "Número documento"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DGVCliente.Columns.Add(dgvtbcnu_docusuna)
    End Sub
    Sub grilla_direccion(ByVal asdataview As DataView)
        DGVDireccion.Columns.Clear()
        DGVDireccion.Width = Me.DGVSolicita.Width
        With DGVDireccion
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .BackgroundColor = Color.White
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False  'Para que no incremente la fila
            .AutoGenerateColumns = False ''Las filas no se generen automaticamente de la bd
            .DataSource = asdataview
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            .RowHeadersVisible = False
            .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoResizeColumns()
            '
            .Location = New Point(Me.DGVSolicita.Location.X, Me.DGVSolicita.Location.Y + 70)
        End With
        Dim dgvtbcdireccion As New DataGridViewTextBoxColumn
        With dgvtbcdireccion  '0
            .DataPropertyName = "direccion"
            .HeaderText = "Dirección"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Resizable = DataGridViewTriState.True
        End With
        DGVDireccion.Columns.Add(dgvtbcdireccion)
        '
        Dim dgvtbciddireccion_consignado As New DataGridViewTextBoxColumn
        With dgvtbciddireccion_consignado  '1
            .Visible = False
            .DataPropertyName = "iddireccion_consignado"
            .HeaderText = "Direccion consignado"
            .ReadOnly = True
        End With
        DGVDireccion.Columns.Add(dgvtbciddireccion_consignado)
        '       
        Dim dgvtbcnom_contacto As New DataGridViewTextBoxColumn
        With dgvtbcnom_contacto   '2  DIRECCION 
            .DataPropertyName = "nom_contacto"
            .HeaderText = "Nombres y Apellidos"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DGVDireccion.Columns.Add(dgvtbcnom_contacto)
        '
        Dim dgvtbcidcontacto As New DataGridViewTextBoxColumn
        With dgvtbcidcontacto  '3 
            .Visible = False
            .Width = 0
            .DataPropertyName = "idcontacto_persona"
            .HeaderText = "Código contacto"
        End With
        DGVDireccion.Columns.Add(dgvtbcidcontacto)
        '
    End Sub
    Private Sub recupera_direccion(ByVal alfila As Integer)
        Dim dgvr As DataGridViewRow
        Dim li_iddireccion, li_idcontacto As Integer
        Dim ls_contacto, ls_direccion As String
        '
        dgvr = Me.DGVDireccion.CurrentRow
        li_idcontacto = dgvr.Cells(0).Value
        ls_contacto = dgvr.Cells(1).Value
        li_iddireccion = dgvr.Cells(2).Value
        ls_direccion = dgvr.Cells(3).Value
        ' Devolviendo la direccion 
        DGVSolicita.Rows(alfila).Cells(6).Value = li_iddireccion
        DGVSolicita.Rows(alfila).Cells(7).Value = ls_direccion
        'Devolviendo el contacto 
        ''''''''''''''''''''''''''''''
        ''Recuperando el valor del cliente 
        'dgvr = Me.DGVDireccion.CurrentRow()
        'li_idcliente = CType(dgvr.Cells(1).Value, Integer)
        'ls_cliente = dgvr.Cells(0).Value.ToString()
        'ls_cadena = dgvr.Cells(5).Value.ToString()
        'ls_cadena = ls_cadena + " - " + dgvr.Cells(6).Value.ToString()
        'ls_clte_concatenado = ls_cliente + " (" + ls_cadena + ")"
        '' Pasando valor al datawindow padre  
        'DGVSolicita.Rows(alfila).Cells(4).Value = li_idcliente
        'DGVSolicita.Rows(alfila).Cells(5).Value = ls_clte_concatenado
        'DGVSolicita.Focus()
        'DGVSolicita.TabIndex = 7   'Coloco la nueva posición  
        'DGVCliente.Visible = False
    End Sub
    Sub buscarcontacto(ByVal lidcliente As Integer, ByVal liddireccion As Integer, ByVal fila As Integer)
        'datahelper
        'Dim rstcontacto As New ADODB.Recordset
        Dim rstcontacto As DataTable
        Dim dtcontacto As New DataTable
        Dim dvcontacto As New DataView
        Dim clasebusqueda As New dtoSolRecojoBusqueda
        Dim dvrg As New DataGridViewRow
        '
        clasebusqueda.Idcliente = lidcliente
        clasebusqueda.Iddireccion = liddireccion
        'datahelper
        'rstcontacto = clasebusqueda.Busquedacontacto
        'dr4.Fill(dtcontacto, rstcontacto)
        rstcontacto = clasebusqueda.Busquedacontacto
        dtcontacto = rstcontacto
        dvcontacto = dtcontacto.DefaultView
        dvcontacto.AllowNew = False
        'Creando la grilla de la direccion
        grilla_contacto(dvcontacto)
        'Ubicando la posicion 
        If dvcontacto.Count = 0 Then
            Dim a As New FrmMantClteCarga
            Dim resultado As DialogResult
            '
            DGVDireccion.Visible = False
            ModSolRecojoCarga.idagencia = idagencia
            ModSolRecojoCarga.iddireccion_consignado = liddireccion
            ModSolRecojoCarga.frmfilapadre = fila
            bcancelar = True  'Desactivando el control 

            'resultado = a.ShowDialog()

            Acceso.Asignar(a, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                resultado = a.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            'Recuperando los valores para actualizar en lo que es la dirección y consignado 
            If Not ModSolRecojoCarga.bcancelar Then
                Recuperadireccionnueva()
            End If
            'Debe retorna a la fila que se ha quedado 
            bcancelar = False  'Activando el control  
            '''''''''''''''''''''''
            DGVContacto.Visible = False
            DGVSolicita.Focus()
            DGVSolicita.CurrentCell = DGVSolicita.Rows(fila).Cells(10)
            '
        End If
        If dvcontacto.Count() = 1 Then
            'Recupera direccion del cliente      
            ModSolRecojoCarga.frmfilapadre = fila
            dvrg = DGVContacto.CurrentRow
            DGVSolicita.Rows(fila).Cells(8).Value = dvrg.Cells(0).Value
            DGVSolicita.Rows(fila).Cells(9).Value = dvrg.Cells(1).Value
            DGVSolicita.CurrentCell = DGVSolicita.Rows(fila).Cells(10)
        End If
        If dvcontacto.Count() > 1 Then
            ' Escondiendo los objetos 
            DGVCliente.Visible = False
            DGVDireccion.Visible = False
            '
            ModSolRecojoCarga.frmfilapadre = fila
            DGVDireccion.Visible = False
            '
            DGVContacto.Visible = True
            bcancelar = True
            DGVContacto.Focus()
            bcancelar = False
        End If
    End Sub
    Sub grilla_contacto(ByVal asdataview As DataView)
        DGVContacto.Columns.Clear()
        With DGVContacto
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .BackgroundColor = Color.White
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False  'Para que no incremente la fila
            .AutoGenerateColumns = False ''Las filas no se generen automaticamente de la bd
            .DataSource = asdataview
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            .RowHeadersVisible = False
            .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoResizeColumns()
            '
            .Location = New Point(Me.DGVSolicita.Location.X, Me.DGVSolicita.Location.Y + 70)
        End With
        '
        Dim dgvtbcidcontacto As New DataGridViewTextBoxColumn
        With dgvtbcidcontacto   '0 
            .Visible = False
            .Width = 0
            .DataPropertyName = "idcontacto_persona"
            .HeaderText = "Código contacto"
            .ReadOnly = True
            .Visible = False
        End With
        DGVContacto.Columns.Add(dgvtbcidcontacto)
        '
        Dim dgvnom_contacto As New DataGridViewTextBoxColumn
        With dgvnom_contacto   '1
            .DataPropertyName = "nom_contacto"
            .HeaderText = "Encargado"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Resizable = DataGridViewTriState.True
        End With
        DGVContacto.Columns.Add(dgvnom_contacto)
    End Sub
    Private Sub trae_contacto(ByVal alfila As Integer) 'Omendoza se debe trae la direccion 
        Dim dgvr As DataGridViewRow
        Dim li_contacto As Integer
        Dim ls_contacto As String
        'Recuperando el valor del cliente 
        dgvr = Me.DGVContacto.CurrentRow()
        li_contacto = CType(dgvr.Cells(0).Value, Integer)
        ls_contacto = dgvr.Cells(1).Value.ToString()
        ' Pasando valor al datawindow padre  
        DGVContacto.Visible = False
        DGVSolicita.Rows(alfila).Cells(8).Value = li_contacto
        DGVSolicita.Rows(alfila).Cells(9).Value = ls_contacto
        DGVSolicita.EndEdit()
        DGVSolicita.CurrentCell = DGVSolicita.Rows(alfila).Cells(10)
    End Sub
    Private Sub DGVDireccion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGVDireccion.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                Dim dgvr As New DataGridViewRow
                Dim row As Integer = Me.DGVDireccion.SelectedRows.Item(0).Index
                'Cliente
                DGVCliente.Visible = False
                '
                If DGVDireccion.Visible = True Then
                    ''''''''''''''''''
                    Dim fila As Integer = Me.DGVDireccion.SelectedRows.Item(0).Index
                    dgvr = Me.DGVSolicita.CurrentRow
                    'fila = dgvr.Index
                    trae_direccion(dgvr.Index)
                    DGVDireccion.Visible = False
                    ' DGVSolicita.Focus() 
                    'DGVSolicita.CurrentCell = DGVSolicita.Rows(row).Cells(9) Coloca la posición 
                    '''''' 
                    'DataGridView(7, row).Value = DGVDireccion.Rows(row).DataGridView(4, row).Value
                    'DGVSolicita.UpdateCellValue(7, row)
                    'DGVSolicita.Focus()
                    'DGVSolicita.TabIndex = 8   'Coloco la nueva posición  
                    'DGVCliente.Visible = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub DGVCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGVCliente.KeyDown
        Dim dgvr As New DataGridViewRow
        Try
            'Devolviendo el valor 
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                Dim fila As Integer = Me.DGVCliente.SelectedRows.Item(0).Index
                dgvr = Me.DGVSolicita.CurrentRow
                'fila = dgvr.Index
                trae_cliente(dgvr.Index)
            End If
        Catch exp As Exception
            MsgBox(exp.ToString, MsgBoxStyle.Exclamation, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub DGVContacto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGVContacto.KeyDown
        Dim dgvr As New DataGridViewRow
        Try
            'Devolviendo el valor 
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                Dim fila As Integer = Me.DGVContacto.SelectedRows.Item(0).Index
                dgvr = Me.DGVSolicita.CurrentRow
                'fila = dgvr.Index
                'busqueda_contacto(lidcliente, lidireccion, fila)
                trae_contacto(dgvr.Index)
                DGVContacto.Visible = False
            End If
        Catch exp As Exception
            MsgBox(exp.ToString, MsgBoxStyle.Exclamation, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub DGVSolicita_RowStateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles DGVSolicita.RowStateChanged
        Try
            Dim dgvr As New DataGridViewRow
            Dim fila As New Integer
            dgvr = Me.DGVSolicita.CurrentRow()
            If Not (dgvr Is Nothing) Then
                ' Capturo la fila actual 
                dgvsolicitafila = dgvr.Index
                dgvsolicitactrl = True
            End If
        Catch exc As Exception
            MsgBox(exc.ToString, MsgBoxStyle.Exclamation, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub Recuperadireccionnueva()
        Dim fila As New Integer
        '
        Try
            fila = ModSolRecojoCarga.frmfilapadre
            DGVSolicita.Rows(fila).Cells(7).Value = ModSolRecojoCarga.sdireccion
            DGVSolicita.Rows(fila).Cells(9).Value = ModSolRecojoCarga.sapellidos_nombres
            'ModSolRecojoCarga.sapepaterno(+" " + _
            '                                        ModSolRecojoCarga.sapematerno + " " + ModSolRecojoCarga.snombre)
            ' ModSolRecojoCarga.iddireccion_consignado()   ' No es necesario por que no existe
            tipodireccion = ModSolRecojoCarga.tipodireccion
            idubigeo = ModSolRecojoCarga.idubigeo
            idpais = ModSolRecojoCarga.idpais
            iddpto = ModSolRecojoCarga.iddpto
            idprov = ModSolRecojoCarga.idprov
            ModSolRecojoCarga.iddistrito = ModSolRecojoCarga.iddistrito
            sdireccion = ModSolRecojoCarga.sdireccion
            srefllegada = ModSolRecojoCarga.srefllegada
            snrodcto = ModSolRecojoCarga.snrodcto
            sapellidos_nombres = ModSolRecojoCarga.sapellidos_nombres
            'snombre = ModSolRecojoCarga.snombre
            'sapepaterno = ModSolRecojoCarga.sapepaterno
            'sapematerno = ModSolRecojoCarga.sapematerno
            idsucuenta = ModSolRecojoCarga.idsucuenta
            idcargo = ModSolRecojoCarga.idcargo
            idtipdcto = ModSolRecojoCarga.idtipdcto
            idsexo = ModSolRecojoCarga.idsexo
        Catch Exp As Exception
            MsgBox(Exp.ToString, MsgBoxStyle.Exclamation, "Seguridad Sistema")
        End Try
        bguardardireccion = True
    End Sub
    Private Sub Limpiarmodulo_datosnuevos()
        tipodireccion = Nothing
        idubigeo = Nothing
        idpais = Nothing
        iddpto = Nothing
        idprov = Nothing
        ModSolRecojoCarga.iddistrito = Nothing
        sdireccion = Nothing
        srefllegada = Nothing
        snrodcto = Nothing
        sapellidos_nombres = Nothing
        'snombre = Nothing 
        'sapepaterno = Nothing
        'sapematerno = Nothing
        idsucuenta = Nothing
        idcargo = Nothing
        idtipdcto = Nothing
        idsexo = Nothing
    End Sub

#End Region
#Region "TAB 1" 'Invocando Asigna personal 
    Private Sub call_invocatab1()
        Try
            ' Recupera el combo de agencias, usando una clase               
            clasesolcomun.idusurio_personalmod = dtoUSUARIOS.IdLogin
            clasesolcomun.idprovincia = iidprovincia_tab1
            '
            'datahelper
            'rstagenciaasigna = clasesolcomun.get_combo()
            'dr4.Fill(dtagenciaasigna, rstagenciaasigna)
            'dvAgenciaasigna = dtagenciaasigna.DefaultView
            'dvAgenciaasigna.AllowNew = False
            ''recuperando la ruta 
            'rstrutaasigna = rstagenciaasigna.NextRecordset
            'dr4.Fill(dtrutaasigna, rstrutaasigna)
            ''Recupera la unidad de transporte 
            'rstunitransasigna = rstagenciaasigna.NextRecordset
            'dr4.Fill(dtunitransasigna, rstunitransasigna)
            'dvunitransasigna = dtunitransasigna.DefaultView
            'dvunitransasigna.AllowNew = False
            '' dvunitransasignaclon            
            'filtro = "idusuario_personal = " & Trim(usuario)
            'dvAgenciaasigna.RowFilter = filtro
            ''Asignando tipo de observación, no es necesario el tipo de observación para este tab 
            'rsttipoobsasigna = rstagenciaasigna.NextRecordset
            'dr4.Fill(dttipoobsasigna, rsttipoobsasigna)
            'dvtipoobsasigna = dttipoobsasigna.DefaultView
            ''----------
            'Dim lagenciaxdefecto As Integer
            'lagenciaxdefecto = dtagenciaasigna.Rows(0).Item(0)
            ''----------------
            'dvAgenciaasigna = CargarCombo(Cmbagenciaasigna, dtagenciaasigna, "nombre_agencia", "idagencias", lagenciaxdefecto)
            ''Recupera Ruta
            'dvrutaasigna = CargarCombo(cmbrutaasigna, dtrutaasigna, "nombre_ruta_entrega_recojo", "idruta_entrega_recojo", 0)
            ''Recupera la grilla en función de la agencia y la fecha 
            '' Configurando la fecha 
            'DTimePickerAsigna.Value = Today.ToString("dd/MM/yyyy")
            ''Recuperando valor del combo, y lo coloca en idagencia  
            'recupera_agencia_asigna()

            Dim ds As DataSet = clasesolcomun.get_combo()
            dtagenciaasigna = ds.Tables(0)
            dvAgenciaasigna = dtagenciaasigna.DefaultView
            dvAgenciaasigna.AllowNew = False

            'recuperando la ruta 
            dtrutaasigna = ds.Tables(1)

            'Recupera la unidad de transporte 
            dtunitransasigna = ds.Tables(2)
            dvunitransasigna = dtunitransasigna.DefaultView
            dvunitransasigna.AllowNew = False

            filtro = "idusuario_personal = " & Trim(usuario)
            dvAgenciaasigna.RowFilter = filtro

            'Asignando tipo de observación, no es necesario el tipo de observación para este tab 
            dttipoobsasigna = ds.Tables(3)
            dvtipoobsasigna = dttipoobsasigna.DefaultView
            '----------
            Dim lagenciaxdefecto As Integer
            lagenciaxdefecto = dtagenciaasigna.Rows(0).Item(0)
            '----------------
            dvAgenciaasigna = CargarCombo(Cmbagenciaasigna, dtagenciaasigna, "nombre_agencia", "idagencias", lagenciaxdefecto)
            'Recupera Ruta
            dvrutaasigna = CargarCombo(cmbrutaasigna, dtrutaasigna, "nombre_ruta_entrega_recojo", "idruta_entrega_recojo", 0)
            'Recupera la grilla en función de la agencia y la fecha 
            ' Configurando la fecha 
            DTimePickerAsigna.Value = Today.ToString("dd/MM/yyyy")
            'Recuperando valor del combo, y lo coloca en idagencia  
            recupera_agencia_asigna()

        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Asignando él valor ")
        End Try
        '
    End Sub
    Sub GrillaMante_Asigna()
        Dim gmdtrutaasigna As New System.Data.DataTable
        Dim gmdvrutaasigna As New DataView
        Try
            'Copiando la ruta 
            gmdvrutaasigna = dtRutasasignaClon.DefaultView
            'Recupera las rutas disponibles 
            gmdvrutaasigna.RowFilter = "idruta_entrega_recojo <> 0"
            dvrutaasigna.RowFilter = ""
            'Configurando la grilla 
            With DGVAsigna
                .AutoGenerateColumns = False 'Las filas no se generen automaticamente de la bd
                ' Creando el data source 
                .DataSource = dvSolCargaasigna
                .BackColor = SystemColors.Info
                .BackgroundColor = SystemColors.Info
                .RowHeadersVisible = False
                .BorderStyle = BorderStyle.Fixed3D
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                '.Visible = False
                ' Pintando la linea 
                '.CurrentRow.DefaultCellStyle.BackColor = Color.White
                '.CurrentRow.DefaultCellStyle.ForeColor = Color.Black
                'Ancho del data grid
                .Width = 705
                ' aplicando las coordenadas respectivas 
                .Location = New Point(.Location.X, 18)
                .Location = New Point(.Location.Y, 60)
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                '.GridLineStyle = DataGridLineStyle.Solid
                '.ParentRowsVisible = False
                '.AllowNavigation = True
                '.ReadOnly = False
                '.AllowSorting = True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End With
            Dim tbNrosolicitud1 As New DataGridViewTextBoxColumn '0
            With tbNrosolicitud1
                .DataPropertyName = "idsolicitud_recojo_carga"
                .HeaderText = "Nº solicitud"
                .DefaultCellStyle.BackColor = SystemColors.Info
                .Width = 80
                ' .ReadOnly = True
                '.Frozen = True
                .Visible = False
            End With
            DGVAsigna.Columns.Add(tbNrosolicitud1)
            '
            Dim Colaprobado1 As New DataGridViewCheckBoxColumn '1
            With Colaprobado1
                .HeaderText = "¿Aprobado?"
                .Name = "APROBADO"
                .DataPropertyName = "APROBADO"
                .Width = 62
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            DGVAsigna.Columns.Add(Colaprobado1)
            '
            Dim tbunidadtransporte1 As New DataGridViewComboBoxColumn '2
            With tbunidadtransporte1  '2
                .DataSource = dvunitransasigna
                .Name = "idunidad_transporte"
                .DataPropertyName = "idunidad_transporte"
                .DisplayMember = "nro_unidad_transporte"
                .ValueMember = "idunidad_transporte"
                .HeaderText = "Móvil"
                '  .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            End With
            DGVAsigna.Columns.Add(tbunidadtransporte1)
            '
            Dim tbrutaentrega1 As New DataGridViewComboBoxColumn   '3
            With tbrutaentrega1
                .DataPropertyName = "idruta_entrega_recojo"
                .HeaderText = "Ruta"
                .DataSource = gmdvrutaasigna
                .DisplayMember = "nombre_ruta_entrega_recojo"
                .ValueMember = "idruta_entrega_recojo"
                .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            End With
            DGVAsigna.Columns.Add(tbrutaentrega1)
            '
            Dim tbidpersona1 As New DataGridViewTextBoxColumn '4
            With tbidpersona1
                .DataPropertyName = "idpersona"
                .HeaderText = "Código cliente"
                .Width = 0
                .Visible = False
                .ReadOnly = True
            End With
            DGVAsigna.Columns.Add(tbidpersona1)
            '
            Dim tbrazonsocial1 As New DataGridViewTextBoxColumn '5
            With tbrazonsocial1
                .DataPropertyName = "razon_social"
                .HeaderText = "Cliente"
                .Width = 120
                .Resizable = DataGridViewTriState.True
                .ReadOnly = False
            End With
            DGVAsigna.Columns.Add(tbrazonsocial1)
            '
            Dim tbidirecosignado1 As New DataGridViewTextBoxColumn  '6
            With tbidirecosignado1
                .DataPropertyName = "iddireccion_consignado"
                .HeaderText = "Código dirección"
                .Visible = False
                .ReadOnly = True
            End With
            DGVAsigna.Columns.Add(tbidirecosignado1)
            '
            Dim tbdireccion1 As New DataGridViewTextBoxColumn   '7
            With tbdireccion1
                .DataPropertyName = "direccion"
                .HeaderText = "Dirección"
                .Resizable = DataGridViewTriState.True
                '.Width = 120
                .ReadOnly = True
            End With
            DGVAsigna.Columns.Add(tbdireccion1)
            '
            Dim tbhoraini1 As New DataGridViewTextBoxColumn     '8 
            With tbhoraini1
                .DataPropertyName = "hora_ini"
                .HeaderText = "Hora listo"
                .DefaultCellStyle.Format = "HH:mm"
                .DefaultCellStyle.Alignment = HorizontalAlignment.Center
                '.Width = 60
                .ReadOnly = True
            End With
            DGVAsigna.Columns.Add(tbhoraini1)
            '
            Dim tbhorafin1 As New DataGridViewTextBoxColumn     '9
            With tbhorafin1
                .DataPropertyName = "hora_fin"
                .HeaderText = "Hora cierre"
                .DefaultCellStyle.Format = "HH:mm"
                .DefaultCellStyle.Alignment = HorizontalAlignment.Center
                '.ReadOnly = False
            End With
            DGVAsigna.Columns.Add(tbhorafin1)
            '
            Dim tbnropaquetes1 As New DataGridViewTextBoxColumn   '10
            With tbnropaquetes1
                .DataPropertyName = "nro_paquetes"
                .HeaderText = "Nº paquetes"
                .Width = 70
                .DefaultCellStyle.Format = "###,###,##0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            DGVAsigna.Columns.Add(tbnropaquetes1)
            '
            Dim tbpesokg1 As New DataGridViewTextBoxColumn    '11
            With tbpesokg1
                .DataPropertyName = "peso_kg"
                .HeaderText = "Peso"
                .Width = 70
                .DefaultCellStyle.Format = "###,###,###.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            DGVAsigna.Columns.Add(tbpesokg1)
            '
            Dim tbvolumen1 As New DataGridViewTextBoxColumn   '12
            With tbvolumen1
                .DataPropertyName = "volumen"
                .HeaderText = "Volumen"
                .Name = "volumen"
                '.Width = 70
                .DefaultCellStyle.Format = "###,###,###.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            DGVAsigna.Columns.Add(tbvolumen1)
            '
            Dim tbidestadorecogo1 As New DataGridViewComboBoxColumn
            With tbidestadorecogo1   '13 
                .DataPropertyName = "idestado_recojo"
                .DataSource = dvestadorecojo
                .DisplayMember = "estado_registro"
                .ValueMember = "idestado_registro"
                .HeaderText = "Estado"
                .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            End With
            DGVAsigna.Columns.Add(tbidestadorecogo1)
            Dim tbcierreso1 As New DataGridViewCheckBoxColumn
            With tbcierreso1   '14 
                .HeaderText = "Cerrado"
                .Name = "cierre_solicitud"
                .DataPropertyName = "cierre_solicitud"
                .ThreeState = False
                .TrueValue = 1   'Aprobado  
                .FalseValue = 0
                .ReadOnly = False
            End With
            DGVAsigna.Columns.Add(tbcierreso1)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub chk_asigna_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_asigna.CheckedChanged
        Try
            'datahelper
            'Dim rstagencialocal As New ADODB.Recordset
            Dim idagencialocal As Integer
            dtagenciaasigna = Nothing
            dvAgenciaasigna = Nothing
            '--------
            Dim ds As DataSet
            If chk_asigna.Checked = False Then 'Llenar el combo para la agencia que esta asociado al usuario .
                clasesolcomun.idusurio_personalmod = usuario ' Solo al usuario que le corresponde 
                'datahelper
                'rstagencialocal = clasesolcomun.ListaAgencia()
                ds = clasesolcomun.ListaAgencia()
            End If
            If chk_asigna.Checked = True Then 'Llenar el combo para todos las agencias            
                clasesolcomun.idusurio_personalmod = iNULO ' Invocando a todos 
                ds = clasesolcomun.ListaAgencia()
            End If
            '
            dtagenciaasigna = New DataTable
            dvAgenciaasigna = New DataView
            ' 
            'datahelper
            'dr4.Fill(dtagenciaasigna, rstagencialocal)
            dtagenciaasigna = ds.Tables(0)
            dvAgenciaasigna = dtagenciaasigna.DefaultView
            dvAgenciaasigna.AllowNew = False
            idagencialocal = dtagenciaasigna.Rows(0).Item(0)
            dvAgenciaasigna = CargarCombo(Cmbagenciaasigna, dtagenciaasigna, "nombre_agencia", "idagencias", idagencialocal)
            recupera_agencia_asigna()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Sub recupera_agencia_asigna()
        Try
            Dim posicion As Integer
            posicion = Cmbagenciaasigna.SelectedIndex()
            If posicion >= 0 Then
                drvAgenciaasigna = dvAgenciaasigna.Item(posicion)
                ' Recuperando la provincia 
                iidprovincia_tab1 = dvAgenciaasigna.Table.Rows(posicion).Item(5)
                idagenciaasigna = IIf(IsDBNull(drvAgenciaasigna("idagencias")) = True, "0", drvAgenciaasigna("idagencias").ToString)
            End If
            ' Recupera la ruta 
            recupera_ruta_asigna()
            '
            recupera_solcitud_asigna()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub
    Sub recupera_solcitud_asigna()
        Dim ls_fecha_recojo As String
        ls_fecha_recojo = DTimePickerAsigna.Value.ToString()
        'Recuperando la nueva solicitud 
        rstSolCargaasigna = Nothing
        dtSolCargaasigna.Clear()
        dvSolCargaasigna = Nothing
        ' Limpiando y volviendo a crear 
        DGVAsigna.Columns.Clear()
        '
        Try
            ClaseSolAsignamovil.idagencia = idagenciaasigna
            ClaseSolAsignamovil.fecharecojo = ls_fecha_recojo
            'datahelper
            rstSolCargaasigna = ClaseSolAsignamovil.Get_solicitud_movil
            If rstSolCargaasigna.Rows.Count >= 0 Then
                dtSolCargaasigna = rstSolCargaasigna
                dvSolCargaasigna = dtSolCargaasigna.DefaultView
                dvSolCargaasigna.AllowNew = True
            End If

            'datahelper
            'If rstSolCargaasigna.Fields.Count >= 0 Then
            '    dr4.Fill(dtSolCargaasigna, rstSolCargaasigna)
            '    dvSolCargaasigna = dtSolCargaasigna.DefaultView
            '    dvSolCargaasigna.AllowNew = True
            'End If
            '
            GrillaMante_Asigna()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad de sistema")
        End Try
    End Sub
    Sub recupera_ruta_asigna()
        Dim rstruta_xagencia As New ADODB.Recordset
        Try
            dtrutaasigna = Nothing
            dtrutaasigna = New DataTable
            dvrutaasigna = Nothing
            dvrutaasigna = New DataView
            '
            dtRutasasignaClon = Nothing
            dtRutasasignaClon = New DataTable
            '
            clasesolcomun.idprovincia = iidprovincia_tab1
            'datahelper
            'rstruta_xagencia = clasesolcomun.get_ruta_xagencia()
            'dr4.Fill(dtrutaasigna, rstruta_xagencia)
            dtrutaasigna = clasesolcomun.get_ruta_xagencia()
            '
            dvrutaasigna = dtrutaasigna.DefaultView
            dtRutasasignaClon = dtrutaasigna.Copy   ''Para q' no afecte nada se copia el parametro.  
            dvrutaasigna.AllowNew = True
            'End If
            'llenando el combo 
            'LlenaComboE(rstrutaasigna, dtrutaasigna, dvrutaasigna, cmbrutaasigna, "nombre_ruta_entrega_recojo")
            dvrutaasigna = CargarCombo(cmbrutaasigna, dtrutaasigna, "nombre_ruta_entrega_recojo", "idruta_entrega_recojo", 0)
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Asignando él valor ")
        End Try
    End Sub
    Private Sub DTimePickerAsigna_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTimePickerAsigna.TextChanged
        Call recupera_solcitud_asigna()
    End Sub
    Private Sub Cmbagenciaasigna_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbagenciaasigna.SelectedIndexChanged
        recupera_agencia_asigna()
    End Sub
    Private Sub cmbrutaasigna_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbrutaasigna.SelectedIndexChanged
        Dim liruta, posicion As Integer
        posicion = cmbrutaasigna.SelectedIndex()
        If posicion >= 0 Then
            drvrutasasigna = dvrutaasigna.Item(posicion)
            liruta = IIf(IsDBNull(drvrutasasigna("idruta_entrega_recojo")) = True, "0", drvrutasasigna("idruta_entrega_recojo").ToString)
        End If
        If liruta = 0 Then
            dvSolCargaasigna.RowFilter = ""
        Else
            dvSolCargaasigna.RowFilter = "idruta_entrega_recojo = " & Trim(liruta)
        End If
    End Sub
    Private Sub DGVAsigna_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DGVAsigna.CellBeginEdit
        'Dim lidruta As Integer
        'Dim lidunidadtrasnporte As Integer
        Dim isolocontrol As Integer
        Dim lidunidadtrasnporte As Integer
        'Dim rstdatos, rstcontrol As Recordset
        'Dim actulizatab1 As Integer
        'Dim mensajetab1 As String
        ''Dim salirdelfoco As System.Windows.Forms.DataGridViewCellEventArgs
        ''Recuperando la fila 
        Dim dgvr As DataGridViewRow = Me.DGVAsigna.CurrentRow()
        Try
            Select Case e.ColumnIndex
                Case 1
                    If dgvr.Cells(1).Value = 0 Then
                        isolocontrol = 1
                    Else
                        isolocontrol = 0
                    End If

                    If IsDBNull(DGVAsigna.Rows(e.RowIndex).Cells(2).Value) = True Then
                        lidunidadtrasnporte = -1
                    Else
                        lidunidadtrasnporte = CType(DGVAsigna.Rows(e.RowIndex).Cells(2).Value, Integer)
                    End If
                    If lidunidadtrasnporte < 1 Then
                        MessageBox.Show("Falta ingresar la unidad de transporte")
                        Exit Sub
                    End If
                    graba_DGVAsigna(isolocontrol, e.RowIndex, lidunidadtrasnporte)
                Case 2
                    'isolocontrol = CType(dgvr.Cells(1).Value, Integer)
                    'graba_DGVAsigna(isolocontrol, e.RowIndex)
                    'Try

                    '    ' solocontrol = CType(e.ColumnIndex.ToString, Integer)
                    '    If dgvr.Cells(1).Value = 0 Then
                    '        solocontrol = 1
                    '    Else
                    '        solocontrol = 0
                    '    End If
                    '    'Para aprobar, necesita ingresar la ruta y la unidad de transporte     
                    '    If IsDBNull(DGVAsigna.Rows(e.RowIndex).Cells(3).Value) Then
                    '        lidruta = -1
                    '    Else
                    '        lidruta = CType(DGVAsigna.Rows(e.RowIndex).Cells(3).Value, Integer)
                    '    End If
                    '    If IsDBNull(lidruta) Or lidruta < 1 Then
                    '        MessageBox.Show("Falta registrar la ruta")
                    '        Exit Sub
                    '    End If
                    '    If IsDBNull(DGVAsigna.Rows(e.RowIndex).Cells(2).Value) Then
                    '        lidunidadtrasnporte = -1
                    '    Else
                    '        lidunidadtrasnporte = CType(DGVAsigna.Rows(e.RowIndex).Cells(2).Value, Integer)
                    '    End If
                    '    If IsDBNull(lidunidadtrasnporte) Or lidunidadtrasnporte < 1 Then
                    '        MessageBox.Show("Falta ingresar la unidad de transporte")
                    '        Exit Sub
                    '    End If
                    '    ' Recuperando adicionales
                    '    ClaseSolAsignamovil.fecharecojo = DTimePickerAsigna.Text
                    '    ClaseSolAsignamovil.hora_ini = DGVAsigna.Rows(e.RowIndex).Cells(8).Value
                    '    ClaseSolAsignamovil.hora_fin = DGVAsigna.Rows(e.RowIndex).Cells(9).Value
                    '    ClaseSolAsignamovil.nro_paquetes = CType(DGVAsigna.Rows(e.RowIndex).Cells(10).Value, Integer)
                    '    ClaseSolAsignamovil.peso_kg = CType(DGVAsigna.Rows(e.RowIndex).Cells(11).Value, Double)
                    '    ClaseSolAsignamovil.volumen = CType(DGVAsigna.Rows(e.RowIndex).Cells(12).Value, Double)
                    '    '
                    '    ClaseSolAsignamovil.control = solocontrol
                    '    '' Grabar en la solicitud y cambiar de estado 
                    '    ClaseSolAsignamovil.idsolicitudrecojocarga = CType(DGVAsigna.Rows(e.RowIndex).Cells(0).Value, Integer) 'Nro solicitud
                    '    ClaseSolAsignamovil.idruta_entrega_recojo = CType(DGVAsigna.Rows(e.RowIndex).Cells(3).Value, Integer)
                    '    ClaseSolAsignamovil.idunidad_transporte = CType(DGVAsigna.Rows(e.RowIndex).Cells(2).Value, Integer)
                    '    '
                    '    ClaseSolAsignamovil.aprobado = solocontrol
                    '    'solocontrol = CType(dgvr.Cells(1).Value, Integer)
                    '    '
                    '    ClaseSolAsignamovil.idrol_usuariomod = dtoUSUARIOS.IdRol
                    '    ClaseSolAsignamovil.idusuario_personalmod = dtoUSUARIOS.IdLogin
                    '    ClaseSolAsignamovil.ipmod = dtoUSUARIOS.IP
                    '    ' Grabando y devolviendo  
                    '    rstdatos = ClaseSolAsignamovil.actualiza_aprobacion
                    '    rstcontrol = rstdatos.NextRecordset
                    '    If rstdatos.Fields.Count > 0 Then
                    '        actulizatab1 = rstdatos.Fields(0).Value
                    '        If actulizatab1 = 1 Then
                    '            mensajetab1 = rstdatos.Fields(2).Value
                    '            MessageBox.Show(mensajetab1, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '        Else
                    '            DGVAsigna.Rows(e.RowIndex).Cells(13).Value = CType(rstdatos.Fields(1).Value, Integer)
                    '        End If
                    '    End If
                    '    '
                    '    If rstcontrol.Fields.Count > 0 Then
                    '        If CType(rstcontrol.Fields(0).Value, Integer) <> 0 Then
                    '            MessageBox.Show("Descripción: " & CType(rstcontrol.Fields(1).Value, String), "ORACLE -> Error: " & CType(rstcontrol.Fields(0).Value, String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '        End If
                    '    End If
                    'Catch exp As Exception
                    '    MessageBox.Show(exp.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'End Try
            End Select
            DGVAsigna.EndEdit()
            DGVAsigna.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub DGVAsigna_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DGVAsigna.CellValidating
        'Try
        '    Dim isolocontrol As Integer
        '    ''Recuperando la fila 
        '    Dim dgvr As DataGridViewRow = Me.DGVAsigna.CurrentRow()
        '    Select Case e.ColumnIndex
        '        Case 2
        '            isolocontrol = CType(dgvr.Cells(1).Value, Integer)
        '            graba_DGVAsigna(isolocontrol, e.RowIndex, e.FormattedValue)
        '    End Select
        'Catch ex As Exception    
        '    MessageBox.Show(ex.ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub
    Private Sub DGVAsigna_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DGVAsigna.DataBindingComplete
        Dim dgvr As New DataGridViewRow
        Dim filas As Integer
        Dim cerrado As Integer
        filas = DGVAsigna.RowCount - 1
        'Configurando la fila  
        For fila = 0 To filas
            If Not IsDBNull(DGVAsigna.Rows(fila).Cells("cierre_solicitud").Value) Then
                cerrado = CType(DGVAsigna.Rows(fila).Cells("cierre_solicitud").Value, Integer)
                If cerrado = 1 Then
                    DGVAsigna.Rows(fila).ReadOnly = True
                Else
                    DGVAsigna.Rows(fila).ReadOnly = False
                End If
            End If
        Next
    End Sub
    Public Sub graba_DGVAsigna(ByVal ssolocontrol As String, ByVal ifila As Integer, ByVal iidunidad_transporte As Integer)
        Dim lidruta As Integer
        Dim lidunidadtrasnporte As Integer
        Dim solocontrol As Integer
        'datahelper
        'Dim rstdatos, rstcontrol As ADODB.Recordset
        Dim rstdatos, rstcontrol As DataTable

        Dim actulizatab1 As Integer
        Dim mensajetab1 As String
        'Dim salirdelfoco As System.Windows.Forms.DataGridViewCellEventArgs
        'Recuperando la fila 
        Dim dgvr As DataGridViewRow = Me.DGVAsigna.CurrentRow()
        Try
            solocontrol = ssolocontrol
            ' solocontrol = CType(e.ColumnIndex.ToString, Integer)
            'If dgvr.Cells(1).Value = 0 Then
            '    solocontrol = 1
            'Else
            '    solocontrol = 0
            'End If
            'Para aprobar, necesita ingresar la ruta y la unidad de transporte     
            If IsDBNull(DGVAsigna.Rows(ifila).Cells(3).Value) Then
                lidruta = -1
            Else
                lidruta = CType(DGVAsigna.Rows(ifila).Cells(3).Value, Integer)
            End If
            If IsDBNull(lidruta) Or lidruta < 1 Then
                MessageBox.Show("Falta registrar la ruta")
                Exit Sub
            End If
            'If IsDBNull(DGVAsigna.Rows(ifila).Cells(2).Value) Then
            '    lidunidadtrasnporte = -1
            'Else
            '    lidunidadtrasnporte = CType(DGVAsigna.Rows(ifila).Cells(2).Value, Integer)
            'End If

            'If IsDBNull(lidunidadtrasnporte) Or lidunidadtrasnporte < 1 Then
            '    MessageBox.Show("Falta ingresar la unidad de transporte")
            '    Exit Sub
            'End If
            lidunidadtrasnporte = iidunidad_transporte
            ' Recuperando adicionales
            ClaseSolAsignamovil.fecharecojo = DTimePickerAsigna.Text
            ClaseSolAsignamovil.hora_ini = DGVAsigna.Rows(ifila).Cells(8).Value
            ClaseSolAsignamovil.hora_fin = DGVAsigna.Rows(ifila).Cells(9).Value
            ClaseSolAsignamovil.nro_paquetes = CType(DGVAsigna.Rows(ifila).Cells(10).Value, Integer)
            ClaseSolAsignamovil.peso_kg = CType(DGVAsigna.Rows(ifila).Cells(11).Value, Double)
            ClaseSolAsignamovil.volumen = CType(DGVAsigna.Rows(ifila).Cells(12).Value, Double)
            '
            ClaseSolAsignamovil.control = solocontrol
            '' Grabar en la solicitud y cambiar de estado 
            ClaseSolAsignamovil.idsolicitudrecojocarga = CType(DGVAsigna.Rows(ifila).Cells(0).Value, Integer) 'Nro solicitud
            ClaseSolAsignamovil.idruta_entrega_recojo = CType(DGVAsigna.Rows(ifila).Cells(3).Value, Integer)
            ClaseSolAsignamovil.idunidad_transporte = CType(DGVAsigna.Rows(ifila).Cells(2).Value, Integer)
            '
            ClaseSolAsignamovil.aprobado = solocontrol
            'solocontrol = CType(dgvr.Cells(1).Value, Integer)
            '
            ClaseSolAsignamovil.idrol_usuariomod = dtoUSUARIOS.IdRol
            ClaseSolAsignamovil.idusuario_personalmod = dtoUSUARIOS.IdLogin
            ClaseSolAsignamovil.ipmod = dtoUSUARIOS.IP
            ' Grabando y devolviendo  
            Dim ds As DataSet = ClaseSolAsignamovil.actualiza_aprobacion
            rstdatos = ds.Tables(0)
            rstcontrol = ds.Tables(1)
            If rstdatos.Rows.Count > 0 Then
                actulizatab1 = rstdatos.Rows(0).Item(0)
                If actulizatab1 = 1 Then
                    mensajetab1 = rstdatos.Rows(0).Item(2)
                    MessageBox.Show(mensajetab1, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    DGVAsigna.Rows(ifila).Cells(13).Value = CType(rstdatos.Rows(0).Item(1), Integer)
                End If
            End If
            '
            If rstcontrol.Rows.Count > 0 Then
                If CType(rstcontrol.Rows(0).Item(0), Integer) <> 0 Then
                    MessageBox.Show("Descripción: " & CType(rstcontrol.Rows(0).Item(1), String), "ORACLE -> Error: " & CType(rstcontrol.Rows(0).Item(0), String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            'datahelper
            'rstdatos = ClaseSolAsignamovil.actualiza_aprobacion
            'rstcontrol = rstdatos.NextRecordset
            'If rstdatos.Fields.Count > 0 Then
            '    actulizatab1 = rstdatos.Fields(0).Value
            '    If actulizatab1 = 1 Then
            '        mensajetab1 = rstdatos.Fields(2).Value
            '        MessageBox.Show(mensajetab1, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Else
            '        DGVAsigna.Rows(ifila).Cells(13).Value = CType(rstdatos.Fields(1).Value, Integer)
            '    End If
            'End If
            ''
            'If rstcontrol.Fields.Count > 0 Then
            '    If CType(rstcontrol.Fields(0).Value, Integer) <> 0 Then
            '        MessageBox.Show("Descripción: " & CType(rstcontrol.Fields(1).Value, String), "ORACLE -> Error: " & CType(rstcontrol.Fields(0).Value, String), MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    End If
            'End If
        Catch exp As Exception
            MessageBox.Show(exp.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
#Region "TAB 2"
    'Invocando Resumen del recojo 
    Sub call_invocatab2()
        Try
            dtAgenciaresumen = Nothing
            dtAgenciaresumen = New DataTable
            dtunitransresumen = Nothing
            dtunitransresumen = New DataTable
            'Configurando que no se vea, la fecha de la nueva programación 
            'GBoxproxfecha.Visible = False
            ' Recupera el combo de agencias, usando una clase   
            rstagenciaresumen = Nothing
            rstagenciaresumen = New ADODB.Recordset
            clasesolcomun.idusurio_personalmod = dtoUSUARIOS.IdLogin

            Dim ds As DataSet = clasesolcomun.get_combo()
            dtAgenciaresumen = ds.Tables(0)
            dvAgenciaresumen = dtAgenciaresumen.DefaultView
            dvAgenciaresumen.AllowNew = False

            'recuperando la ruta 
            dtrutaresumen = ds.Tables(1)

            'Recupera la unidad de transporte 
            dtunitransresumen = ds.Tables(2)
            dvunitransresumen = dtunitransresumen.DefaultView
            dvunitransresumen.AllowNew = False

            'Asignando tipo de observación 
            dttipoobsresumen = ds.Tables(2)
            dvtipoobsresumen = dttipoobsresumen.DefaultView

            ' Recupera agencia  
            Dim lagenciaxdefecto As Integer
            lagenciaxdefecto = dtAgenciaresumen.Rows(0).Item(0)
            dvAgenciaresumen = CargarCombo(cmbagenciaresumen, dtAgenciaresumen, "nombre_agencia", "idagencias", lagenciaxdefecto)
            ' Recupera Ruta
            dvrutaresumen = CargarCombo(cmbrutaresumen, dtrutaresumen, "nombre_ruta_entrega_recojo", "idruta_entrega_recojo", 0)
            'Recupera la grilla en función de la agencia y la fecha 
            DTimePickerresumen.Value = Today.ToString("dd/MM/yyyy")
            'Recuperando valor del combo, y lo coloca en idagencia  
            recupera_agencia_resumen()

            'datahelper
            'rstagenciaresumen = clasesolcomun.get_combo()
            'dr4.Fill(dtAgenciaresumen, rstagenciaresumen)
            'dvAgenciaresumen = dtAgenciaresumen.DefaultView
            'dvAgenciaresumen.AllowNew = False
            ''recuperando la ruta 
            'rstrutaresumen = rstagenciaresumen.NextRecordset
            'dr4.Fill(dtrutaresumen, rstrutaresumen)
            ''Recupera la unidad de transporte 
            'rstunitransresumen = rstagenciaresumen.NextRecordset
            'dr4.Fill(dtunitransresumen, rstunitransresumen)
            'dvunitransresumen = dtunitransresumen.DefaultView
            'dvunitransresumen.AllowNew = False
            ''Asignando tipo de observación 
            'rsttipoobsresumen = rstagenciaresumen.NextRecordset
            'dr4.Fill(dttipoobsresumen, rsttipoobsresumen)
            'dvtipoobsresumen = dttipoobsresumen.DefaultView
            '' Recupera agencia  
            'Dim lagenciaxdefecto As Integer
            'lagenciaxdefecto = dtAgenciaresumen.Rows(0).Item(0)
            'dvAgenciaresumen = CargarCombo(cmbagenciaresumen, dtAgenciaresumen, "nombre_agencia", "idagencias", lagenciaxdefecto)
            '' Recupera Ruta
            'dvrutaresumen = CargarCombo(cmbrutaresumen, dtrutaresumen, "nombre_ruta_entrega_recojo", "idruta_entrega_recojo", 0)
            ''Recupera la grilla en función de la agencia y la fecha 
            'DTimePickerresumen.Value = Today.ToString("dd/MM/yyyy")
            ''Recuperando valor del combo, y lo coloca en idagencia  
            'recupera_agencia_resumen()
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Asignando él valor ")
        End Try
    End Sub
    Sub GrillaMante_resumen()
        Dim gmdtrutaresumen As New System.Data.DataTable
        Dim gmdvrutaresumen As New DataView
        'Copiando la ruta 
        gmdvrutaresumen = dtRutasresumenClon.DefaultView
        'Recupera las rutas disponibles 
        gmdvrutaresumen.RowFilter = "idruta_entrega_recojo <> 0"
        dvrutaresumen.RowFilter = ""
        'Creando una variable temporal 
        'Dim TempColumn As DataGridTextBoxColumn
        ' Llena una grilla una vez insertado el dataview(dw)
        'Configurando la grilla 
        With DGVResumen
            .AutoGenerateColumns = False 'Las filas no se generen automaticamente de la bd
            ' Creando el data source 
            .DataSource = dvSolCargaresumen
            .BackColor = SystemColors.Info
            .BackgroundColor = SystemColors.Info
            .RowHeadersVisible = False
            .BorderStyle = BorderStyle.Fixed3D
            .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            '.Visible = False
            ' Pintando la linea 
            '.CurrentRow.DefaultCellStyle.BackColor = Color.White
            '.CurrentRow.DefaultCellStyle.ForeColor = Color.Black
            'Ancho del data grid
            .Width = 705
            ' aplicando las coordenadas respectivas 
            .Location = New Point(.Location.X, 18)
            .Location = New Point(.Location.Y, 60)
            '.GridLineStyle = DataGridLineStyle.Solid
            '.ParentRowsVisible = False
            '.AllowNavigation = True
            '.ReadOnly = False
            '.AllowSorting = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
        Dim tbNrosolicitud2 As New DataGridViewTextBoxColumn
        With tbNrosolicitud2  '0
            .DataPropertyName = "idsolicitud_recojo_carga"
            .HeaderText = "Nº solicitud"
            .DefaultCellStyle.BackColor = SystemColors.Info
            .Name = "idsolicitud_recojo_carga"
            '.Width = 80
            '.ReadOnly = True
            '.Frozen = True
            .Visible = False
        End With
        DGVResumen.Columns.Add(tbNrosolicitud2)
        '
        Dim tbunidadtransporte2 As New DataGridViewComboBoxColumn
        With tbunidadtransporte2  '1
            .DataPropertyName = "idunidad_transporte"
            .Name = "idsolicitud_recojo_carga"
            .HeaderText = "Ruta"
            .DefaultCellStyle.Format.ToString.ToUpper()
            .Width = 120
            .Visible = False
            .ReadOnly = True
        End With
        DGVResumen.Columns.Add(tbunidadtransporte2)
        '
        Dim tbidpersona2 As New DataGridViewTextBoxColumn
        With tbidpersona2 '2
            .DataPropertyName = "idpersona"
            .HeaderText = "Código cliente"
            .Name = "idpersona"
            .Width = 0
            .Visible = False
            .ReadOnly = True
        End With
        DGVResumen.Columns.Add(tbidpersona2)
        '
        Dim tbrazonsocial2 As New DataGridViewTextBoxColumn
        With tbrazonsocial2 '3
            .DataPropertyName = "razon_social"
            .HeaderText = "Cliente"
            '.Width = 120
            .Resizable = DataGridViewTriState.True
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        End With
        DGVResumen.Columns.Add(tbrazonsocial2)
        '
        Dim tbnropaqrecogido2 As New DataGridViewTextBoxColumn
        With tbnropaqrecogido2 '4
            .DataPropertyName = "nro_paquetes_recojidos"
            .Name = "nro_paquetes_recojidos"
            .HeaderText = "Nº Paq. recogidos"
            '.Width = 70
            .DefaultCellStyle.Format = "###,###,##0"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Visible = False
        End With
        DGVResumen.Columns.Add(tbnropaqrecogido2)
        '
        Dim tbpesokgrecogido2 As New DataGridViewTextBoxColumn
        With tbpesokgrecogido2 '5
            .DataPropertyName = "peso_kg_recojidos"
            .HeaderText = "Peso recogido"
            .Width = 70
            .DefaultCellStyle.Format = "###,###,###.00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Visible = False
        End With
        DGVResumen.Columns.Add(tbpesokgrecogido2)
        '
        Dim tbvolumenrecogido2 As New DataGridViewTextBoxColumn
        With tbvolumenrecogido2 '6
            .DataPropertyName = "volumen_recogido"
            .HeaderText = "Volumen recogido"
            .Width = 70
            .DefaultCellStyle.Format = "###,###,###.00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Visible = False
        End With
        DGVResumen.Columns.Add(tbvolumenrecogido2)
        '
        Dim tbtipo_observacion2 As New DataGridViewComboBoxColumn
        With tbtipo_observacion2 '7
            .DataPropertyName = "idtipo_observacion"
            .Name = "idtipo_observacion"
            .HeaderText = "Observado por"
            .DataSource = dvtipoobsresumen
            .DisplayMember = "observacion"
            .ValueMember = "idtipo_observacion"
            If .DefaultCellStyle.IsNullValueDefault Then
                .DefaultCellStyle.DataSourceNullValue = dvtipoobsresumen.Item(0).Row(0)
            End If
            '.DisplayIndex = 1 
            .Visible = True
        End With
        DGVResumen.Columns.Add(tbtipo_observacion2)
        '
        Dim tbobservacion2 As New DataGridViewTextBoxColumn
        With tbobservacion2  '8
            .DataPropertyName = "observacion"
            .Name = "observacion"
            .HeaderText = "Observación"
            .Width = 120
            .Visible = False
        End With
        DGVResumen.Columns.Add(tbobservacion2)
        '
        Dim tbidestadorecogo2 As New DataGridViewComboBoxColumn
        With tbidestadorecogo2   '9 
            .DataPropertyName = "idestado_recojo"
            .DataSource = dvestadorecojo
            .DisplayMember = "estado_registro"
            .ValueMember = "idestado_registro"
            .HeaderText = "Estado"
            .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            'Valor por defecto    
            .Visible = False
        End With
        DGVResumen.Columns.Add(tbidestadorecogo2)
        '
        Dim tbcierresol2 As New DataGridViewCheckBoxColumn
        With tbcierresol2   '10 
            .HeaderText = "Cerrado"
            .Name = "cierre_solicitud"
            .DataPropertyName = "cierre_solicitud"
            '.Width = 62
            .ThreeState = False
            .TrueValue = 1   'Aprobado  
            .FalseValue = 0
            '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        DGVResumen.Columns.Add(tbcierresol2)
        '
        Dim tbfechacierre2 As New DataGridViewTextBoxColumn
        With tbfechacierre2   '11
            .DataPropertyName = "fecha_cierre"
            .Name = "fecha_cierre"
            .HeaderText = "Fecha recepcion"
            '.Width = 60
            .ReadOnly = True
            .DefaultCellStyle.BackColor = SystemColors.Info
            .Visible = True
        End With
        DGVResumen.Columns.Add(tbfechacierre2)
        'invocando la llamada para grabar
        Dim llamada2 As New DataGridViewTextBoxColumn
        With llamada2  '12
            .DataPropertyName = "nombre_cliente_llamada"
            .Name = "nombre_cliente_llamada"
            .HeaderText = "Llamada"
            '.Width = 60
            .ReadOnly = True
            .Visible = False
            .DefaultCellStyle.BackColor = SystemColors.Info
        End With
        DGVResumen.Columns.Add(llamada2)
        Dim direccion2 As New DataGridViewTextBoxColumn
        With direccion2 '13
            .DataPropertyName = "iddireccion_consignado"
            .Name = "iddireccion_consignado"
            .HeaderText = "Dirección"
            '.Width = 60
            .ReadOnly = True
            .Visible = False
            .DefaultCellStyle.BackColor = SystemColors.Info
        End With
        DGVResumen.Columns.Add(direccion2)
        '
        Dim horaini2 As New DataGridViewTextBoxColumn
        With horaini2 '14
            .DataPropertyName = "hora_ini"
            .Name = "hora_ini"
            .HeaderText = "Hora listo"
            '.Width = 60
            .ReadOnly = True
            .Visible = False
            .DefaultCellStyle.BackColor = SystemColors.Info
        End With
        DGVResumen.Columns.Add(horaini2)
        '
        Dim horafin2 As New DataGridViewTextBoxColumn
        With horafin2 '15
            .DataPropertyName = "hora_fin"
            .Name = "hora_fin"
            .HeaderText = "Hora final"
            '.Width = 60
            .ReadOnly = True
            .Visible = False
            .DefaultCellStyle.BackColor = SystemColors.Info
        End With
        DGVResumen.Columns.Add(horafin2)
        '
        Dim tbrutaentrega1 As New DataGridViewTextBoxColumn '16
        With tbrutaentrega1
            .DataPropertyName = "idruta_entrega_recojo"
            .Name = "idruta_entrega_recojo"
            .HeaderText = "Ruta Entrega"
            .Visible = False
            .ReadOnly = False
        End With
        DGVResumen.Columns.Add(tbrutaentrega1)
    End Sub
    Private Sub chkresumen_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkresumen.CheckedChanged
        Try
            'Dim rstagencialocal As New ADODB.Recordset
            Dim idagencialocal As Integer
            dtAgenciaresumen = Nothing
            dvAgenciaresumen = Nothing
            Dim ds As DataSet
            If chkresumen.Checked = False Then 'Llenar el combo para la agencia que esta asociado al usuario .
                clasesolcomun.idusurio_personalmod = usuario ' Solo al usuario que le corresponde 
                'datahelper
                'rstagencialocal = clasesolcomun.ListaAgencia()
                ds = clasesolcomun.ListaAgencia()
                'filtro = "idusuario_personal = " & Trim(usuario)
                'dvAgenciaasigna.RowFilter = filtro
            End If
            If chkresumen.Checked = True Then 'Llenar el combo para todos las agencias            
                clasesolcomun.idusurio_personalmod = iNULO ' Invocando a todos 
                'datahelper
                'rstagencialocal = clasesolcomun.ListaAgencia()
                ds = clasesolcomun.ListaAgencia()
            End If
            '        
            dtAgenciaresumen = New DataTable
            dvAgenciaresumen = New DataView
            ' 
            'datahelper
            'dr4.Fill(dtAgenciaresumen, rstagencialocal)
            dtAgenciaresumen = ds.Tables(0)
            dvAgenciaresumen = dtAgenciaresumen.DefaultView
            dvAgenciaresumen.AllowNew = False
            '
            idagencialocal = dtAgenciaresumen.Rows(0).Item(0)
            dvAgenciaresumen = CargarCombo(cmbagenciaresumen, dtAgenciaresumen, "nombre_agencia", "idagencias", idagencialocal)
            '
            recupera_agencia_resumen()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Sub recupera_agencia_resumen()
        Dim posi As New Integer
        posi = cmbagenciaresumen.SelectedIndex()
        If posi >= 0 Then
            drvAgenciaresumen = dvAgenciaresumen.Item(posi)
            ' Recuperando la provincia 
            iidprovincia_tab2 = dvAgenciaresumen.Table.Rows(posi).Item(5)
            idagenciaresumen = IIf(IsDBNull(drvAgenciaresumen("idagencias")) = True, "0", drvAgenciaresumen("idagencias").ToString)
        Else
            Return
        End If
        ' Recupera unidad de transportes en funcion de la agencia 
        recupera_ruta_resumen()
        'recupera_unidad_trans_agencia()
        '
        recupera_solcitud_resumen()
    End Sub
    Sub recupera_solcitud_resumen()
        Dim ls_fecha_recojo As String
        ls_fecha_recojo = DTimePickerresumen.Value.ToString()
        'Recuperando la nueva solicitud 
        rstSolCargaresumen = Nothing
        dtSolCargaresumen.Clear()
        dvSolCargaresumen = Nothing
        '
        DGVResumen.Columns.Clear()
        '
        ClaseSolatendida.idagencia = idagenciaresumen
        ClaseSolatendida.fecharecojo = ls_fecha_recojo
        rstSolCargaresumen = ClaseSolatendida.Get_movil_recoge
        If rstSolCargaresumen.Rows.Count >= 0 Then
            'datahelper
            'dr4.Fill(dtSolCargaresumen, rstSolCargaresumen)
            dtSolCargaresumen = rstSolCargaresumen
            dvSolCargaresumen = dtSolCargaresumen.DefaultView
            dvSolCargaresumen.AllowNew = True
        End If

        'datahelper
        'rstSolCargaresumen = ClaseSolatendida.Get_movil_recoge
        'If rstSolCargaresumen.Fields.Count >= 0 Then
        '    dr4.Fill(dtSolCargaresumen, rstSolCargaresumen)
        '    dvSolCargaresumen = dtSolCargaresumen.DefaultView
        '    dvSolCargaresumen.AllowNew = True
        'End If
        '
        GrillaMante_resumen()
    End Sub
    Private Sub DTimePickerresumen_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTimePickerresumen.TextChanged
        Call recupera_solcitud_resumen()
    End Sub
    'Sub recupera_unidad_trans_agencia()
    '    Try
    '        rstunitransresumen = Nothing
    '        dtunitransresumen.Clear()
    '        'clasesolcomun.idagencia = idagenciaresumen
    '        rstunitransresumen = clasesolcomun.get_combo
    '        'rstunitransresumen = clasesolcomun.get_unidad_trans_x_agencia
    '        If rstunitransresumen.Fields.Count >= 0 Then
    '            dr4.Fill(dtunitransresumen, rstunitransresumen)
    '            dvunitransresumen = dtunitransresumen.DefaultView
    '            dvunitransresumen.AllowNew = True
    '        End If
    '        'llenando el combo 
    '        LlenaComboE(rstunitransresumen, dtunitransresumen, dvunitransresumen, cmbagenciaresumen, "nro_unidad_transporte")
    '    Catch ex As Exception
    '        MsgBox(ex.Message(), MsgBoxStyle.Critical, "Asignando él valor ")
    '    End Try
    'End Sub
    Private Sub cmbagenciaresumen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbagenciaresumen.SelectedIndexChanged
        recupera_agencia_resumen()
    End Sub
    Private Sub cmbrutaresumen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbrutaresumen.SelectedIndexChanged
        Dim idrutaresumen, posicion As Integer
        Try
            posicion = cmbrutaresumen.SelectedIndex()
            If posicion >= 0 Then
                drvrutasresumen = dvrutaresumen.Item(posicion)
                idrutaresumen = IIf(IsDBNull(drvrutasresumen("idruta_entrega_recojo")) = True, "0", drvrutasresumen("idruta_entrega_recojo").ToString)
            Else
                Return
            End If
            If idrutaresumen = 0 Then
                dvSolCargaresumen.RowFilter = ""
            Else
                dvSolCargaresumen.RowFilter = "idruta_entrega_recojo= " & Trim(idrutaresumen)
            End If
        Catch exp As Exception
            MsgBox(exp.Message(), MsgBoxStyle.Critical, "Asignando él valor ")
        End Try
    End Sub
    Sub recupera_ruta_resumen()
        'datahelper
        'Dim rstruta_xagencia As New ADODB.Recordset
        Try
            '''''''''''''''''''
            dtrutaresumen = Nothing
            dtrutaresumen = New DataTable
            dvrutaresumen = Nothing
            dvrutaresumen = New DataView

            clasesolcomun.idprovincia = iidprovincia_tab2
            dtrutaresumen = clasesolcomun.get_ruta_xagencia()

            'datahelper
            'dr4.Fill(dtrutaresumen, rstruta_xagencia)
            dvrutaresumen = dtrutaresumen.DefaultView

            dtRutasresumenClon = dtrutaresumen.Copy
            dvrutaresumen.AllowNew = True

            dvrutaresumen = CargarCombo(cmbrutaresumen, dtrutaresumen, "nombre_ruta_entrega_recojo", "idruta_entrega_recojo", 0)
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Asignando él valor ")
        End Try
    End Sub
    Private Sub DGVResumen_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DGVResumen.CellBeginEdit
        Dim nropaquetes As Integer
        Dim pesokg, volumen As Double
        Dim solocontrol As Integer
        ' Dim rstdatos, rstcontrol As Recordset
        'Dim actulizatab1 As Integer
        Dim registro As Boolean
        'Dim mensajetab1 As String
        Dim dgvr As DataGridViewRow = Me.DGVResumen.CurrentRow()
        ''Recuperando la fila 
        registro = False
        Select Case e.ColumnIndex
            Case 10    'Cerrar el pedido cerrado  
                Try
                    If IsDBNull(dgvr.Cells(10).Value) Then
                        solocontrol = 1
                    Else
                        If CType(dgvr.Cells(10).Value, Integer) = 0 Then
                            solocontrol = 1
                        Else
                            solocontrol = 0
                        End If
                    End If
                    'Debe ingresar los campos que ha traido la unidad de transportes 
                    If IsDBNull(DGVResumen.Rows(e.RowIndex).Cells(4).Value) Then    'Nro paquetes
                        nropaquetes = -1
                    Else
                        nropaquetes = CType(DGVResumen.Rows(e.RowIndex).Cells(4).Value, Integer)
                        registro = True
                    End If
                    If IsDBNull(DGVResumen.Rows(e.RowIndex).Cells(5).Value) Then    'Peso Kg
                        pesokg = -1
                    Else
                        pesokg = CType(DGVResumen.Rows(e.RowIndex).Cells(5).Value, Double)
                        registro = True
                    End If
                    If IsDBNull(DGVResumen.Rows(e.RowIndex).Cells(6).Value) Then    'Volumen 
                        pesokg = -1
                    Else
                        volumen = CType(DGVResumen.Rows(e.RowIndex).Cells(6).Value, Double)
                        registro = True
                    End If

                    If Not registro Then
                        MessageBox.Show("No se a registrado la carga")
                        Return
                    End If
                    ''
                    If nropaquetes < 0 Then
                        nropaquetes = iNULO
                    End If
                    If pesokg < 0 Then
                        pesokg = dNULO
                    End If
                    If volumen < 0 Then
                        volumen = dNULO
                    End If
                    ClaseSolatendida.control = solocontrol
                    ClaseSolatendida.cierre_solicitud = solocontrol
                    graba_dgvresumen()
                Catch exp As Exception
                    MessageBox.Show(exp.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                'dvSolCargaresumen.RowFilter = ""
                'DGVResumen.Rows(e.RowIndex).ReadOnly = True
                ''Salir del campo  --> Omendoza               
                ''salirdelfoco = CType(salirdelfoco.ColumnIndex,  System.Windows.Forms.DataGridViewCellEventArgs)
                ''DGVAsigna_CellEndEdit(sender, salirdelfoco)
        End Select
    End Sub
    Private Sub DGVResumen_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGVResumen.CellFormatting
        ''  MsgBox("Formateando los campos2")  --> Campo por campo - Omendoza 
        Dim filas, fila As Integer
        Select Case e.ColumnIndex
            Case 7
                filas = DGVResumen.RowCount - 1
                For fila = 0 To filas
                    If IsDBNull(DGVResumen.Rows(e.RowIndex).Cells(7).Value) Then
                        ' Por defecto se coloca conforme 
                        DGVResumen.Rows(fila).Cells(7).Value = dvtipoobsresumen.Item(0).Row(0)
                    End If
                Next
        End Select
        'MsgBox("Prueba fila " + e.RowIndex.ToString + "  " + DGVResumen.Rows(e.RowIndex).Cells(10).Value.ToString)
    End Sub
    Private Sub DGVResumen_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DGVResumen.DataBindingComplete
        'Dim dgvr As New DataGridViewRow
        Dim filas As Integer
        Dim cerrado As Integer
        filas = DGVResumen.RowCount - 1
        'Configurando la fila  
        For fila = 0 To filas
            If Not IsDBNull(DGVResumen.Rows(fila).Cells(10).Value) Then
                cerrado = CType(DGVResumen.Rows(fila).Cells(10).Value, Integer)
                If cerrado = 1 Then
                    DGVResumen.Rows(fila).ReadOnly = True
                Else
                    DGVResumen.Rows(fila).ReadOnly = False
                End If
            End If
            'Busca los valores 
            'Si el campo tipo observado es nulo, displayar por defecto Conforme 
            'If IsDBNull(DGVResumen.Rows(fila).Cells(7).Value) Then
            '    DGVResumen.Rows(fila).Cells(7).Value = 1
            'End If
        Next
    End Sub
    Private Sub DGVResumen_NewRowNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DGVResumen.NewRowNeeded
        Dim dgvr As New DataGridViewRow
        '  dgvr = Me.DGVResumen.CurrentRow()
        'If Not (dgvr Is Nothing) Then
        'MsgBox(dgvr.Cells(7).Value.ToString(), "fila => " + DGVResumen.CurrentRow.ToString())
        'End If
    End Sub
    'Private Sub DGVResumen_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVResumen.CellLeave
    'End Sub
    'Private Sub DGVResumen_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGVResumen.Leave
    '    Dim dgvr As New DataGridViewRow
    '    MsgBox("Leave" + DGVResumen.Rows.Count.ToString)
    '    If Not (dgvr Is Nothing) Then
    '        dgvr = Me.DGVResumen.CurrentRow()
    '        MsgBox(dgvr.Cells(0).Value.ToString())
    '        MsgBox(dgvr.Cells(7).Value.ToString(), "fila => " + DGVResumen.CurrentRow.ToString())
    '    End If
    'End Sub
    'Private Sub DGVResumen_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVResumen.RowLeave
    '    'MsgBox("RowLeave " + DGVResumen.Rows.Count.ToString)
    'End Sub
    'Private Sub DGVResumen_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DGVResumen.RowPrePaint
    '    MsgBox("RowPrePaint" + DGVResumen.Rows.Count.ToString)
    'End Sub
    'Private Sub DGVResumen_RowStateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles DGVResumen.RowStateChanged
    '    MsgBox("RowStateChanged " + DGVResumen.Rows.Count.ToString)
    'End Sub
    Private Sub DGVResumen_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVResumen.CellEndEdit
        'Dim posi As New Integer
        'Select Case e.ColumnIndex
        '    Case 7  'Recuperando el valor del combo 
        '        posi = DGVResumen.Rows(fila).Cells(7).Value
        '        'valor = dvtipoobsresumen.Item(e.RowIndex).Row(1) '
        '        valorecojo = dvtipoobsresumen.Item(posi - 1).Row(1)
        '        Select Case valorecojo
        '            Case "REPROGRAMADO", "RECOJO PARCIAL"
        '                Nuevafecha()
        '        End Select
        'End Select
    End Sub
    'Private Sub Nuevafecha()
    '    'visuliza el control de la fecha 
    '    GBoxproxfecha.Visible = True
    '    GBoxproxfecha.BringToFront()
    'End Sub
    'Private Sub DTimePickerfecprox_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTimePickerfecprox.ValueChanged
    '    Dim dgvr As New DataGridViewRow   'Recuperando la nueva fila
    '    Dim lsnuevafec As String
    '    Dim rstinserta, rstoracle As New ADODB.Recordset
    '    dgvr = Me.DGVResumen.CurrentRow()
    '    '
    '    'lsnuevafec = DTimePickerfecprox.Value.ToString()
    '    If Not (dgvr Is Nothing) Then
    '        'Insertando nueva fecha
    '        '''''''''''''''''''''''''''''
    '        Try
    '            ClaseSolReco.control = 1   '-- Inserta 
    '            ClaseSolReco.nrosolicitud = iNULO
    '            'Lo mismo para el caso de la asignación
    '            ClaseSolReco.clientellamada = dgvr.Cells(12).Value.ToString() + " (Reprogramado)"
    '            'Verifica el campo de la agencia
    '            ClaseSolReco.idagencia = idagenciaresumen
    '            ClaseSolReco.fecharecojo = lsnuevafec
    '            'Cliente  
    '            ClaseSolReco.Idcliente = dgvr.Cells(2).Value.ToString()
    '            ' Recoje direccion pasala 
    '            ClaseSolReco.Iddireccion = dgvr.Cells(13).Value.ToString
    '            '
    '            ClaseSolReco.hora_ini = dgvr.Cells(14).Value.ToString
    '            ClaseSolReco.hora_fin = dgvr.Cells(15).Value.ToString
    '            ''''
    '            ClaseSolReco.nropaquetes = dgvr.Cells(4).Value.ToString
    '            ClaseSolReco.peso_kg = dgvr.Cells(5).Value.ToString
    '            ClaseSolReco.volumen = dgvr.Cells(6).Value.ToString
    '            ''''
    '            ClaseSolReco.observacion = "Recojo Repro. del día " + DTimePickerresumen.Value.ToString()
    '            ClaseSolReco.estadorecojo = iNULO
    '            'Variables globales -- 
    '            ClaseSolReco.ip = dtoUSUARIOS.IP
    '            'ClaseSolReco.ip = "192.168.50.196"
    '            ClaseSolReco.idrol_usuario = dtoUSUARIOS.IdRol
    '            'ClaseSolReco.idrol_usuario = 7 ' temporal el usuario de carga 
    '            ClaseSolReco.idusuario = dtoUSUARIOS.IdLogin
    '            'ClaseSolReco.idusuario = 1
    '            'Insertando la fila 
    '            Try
    '                'Insertando y recupera el nro de solicitud 
    '                rstinserta = ClaseSolReco.actualizar
    '                ' Recuperando el cursor de errores 
    '                rstoracle = rstinserta.NextRecordset
    '                If rstoracle.Fields.Count = 0 Then
    '                    'MessageBox.Show("Guardado Satisfactoriamente","Seguridad del Sistema", MessageBoxButtons.OK,MessageBoxIcon.Error)
    '                Else
    '                    If CType(rstoracle.Fields(0).Value, Integer) <> 0 Then
    '                        '    'vIDPersona = CType(rsteterrado.Fields(1).Value, Integer)
    '                        '    MessageBox.Show("Guardado Satisfactoriamente", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                        'Else
    '                        MessageBox.Show("Descripción: " & CType(rstoracle.Fields(1).Value, String), "ORACLE -> Error: " & CType(rstoracle.Fields(0).Value, String), MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    End If
    '                End If
    '            Catch Qex As Exception
    '                MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            End Try
    '        Catch qex As Exception
    '            MessageBox.Show(qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try
    '        '''''''''''''''''''''''''''
    '        'MsgBox(dgvr.Cells(0).Value.ToString())
    '        'MsgBox(dgvr.Cells(7).Value.ToString(), "fila => " + DGVResumen.CurrentRow.ToString())
    '    End If
    '    ' Cerrando la fila 
    '    ClaseSolReco.control = 1
    '    '
    '    dgvr.Cells(10).Value = 1   ' Cierra 
    '    If IsDBNull(dgvr.Cells(8).Value) Then
    '        dgvr.Cells(8).Value = ""
    '    End If
    '    'dgvr.Cells(8).Value = " Reprog. para el día " + DTimePickerfecprox.Value.ToString() + " " + dgvr.Cells(8).Value    ' Observación   
    '    ClaseSolatendida.cierre_solicitud = 1
    '    '
    '    graba_dgvresumen()
    '    'Ocultando ...
    '    'GBoxproxfecha.Visible = False
    'End Sub
    Private Sub graba_dgvresumen()
        'datahelper
        'Dim rstdatos, rstcontrol As ADODB.Recordset
        Dim rstdatos, rstcontrol As DataTable
        Dim actulizatab1 As Integer
        Dim registro As Boolean
        Dim mensajetab1 As String
        Dim dgvr As DataGridViewRow = Me.DGVResumen.CurrentRow()
        ''Recuperando la fila 
        registro = False
        Try
            ' Grabar en la solicitud y cambiar de estado 
            ClaseSolatendida.idsolicitudrecojocarga = CType(dgvr.Cells(0).Value, Integer) 'Nro solicitud
            ClaseSolatendida.nro_paquete_recojidos = CType(dgvr.Cells(4).Value, Integer)
            ClaseSolatendida.peso_kg_recojidos = CType(dgvr.Cells(5).Value, Double)
            ClaseSolatendida.volumen_recogido = dgvr.Cells(6).Value
            If IsDBNull(dgvr.Cells(7).Value) = True Then  'Tipo observacion 
                ClaseSolatendida.idtipoobservacion = iNULO
            Else
                ClaseSolatendida.idtipoobservacion = dgvr.Cells(7).Value
            End If
            '--- 
            If IsDBNull(dgvr.Cells(8).Value) Then
                ClaseSolatendida.observacion = sNULO
            Else
                ClaseSolatendida.observacion = dgvr.Cells(8).Value
            End If
            ClaseSolatendida.idrol_usuariomod = dtoUSUARIOS.IdRol
            ClaseSolatendida.idusurio_personalmod = dtoUSUARIOS.IdLogin
            ClaseSolatendida.ipmod = dtoUSUARIOS.IP
            '' Grabando y devolviendo  
            Dim ds As DataSet = ClaseSolatendida.actualiza_resumenrecogido()
            rstdatos = ds.Tables(0)
            rstcontrol = ds.Tables(1)
            If rstdatos.Rows.Count > 0 Then
                actulizatab1 = rstdatos.Rows(0).Item(0)
                If actulizatab1 = 1 Then
                    mensajetab1 = rstdatos.Rows(0).Item(2)
                    MessageBox.Show(mensajetab1, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                Else
                    If Not IsDBNull(rstdatos.Rows(0).Item(1)) Then
                        dgvr.Cells(9).Value = CType(rstdatos.Rows(0).Item(1), Integer) 'Actualiza el estado de recojo 
                    End If
                End If
            End If
            If rstcontrol.Rows.Count > 0 Then
                If CType(rstcontrol.Rows(0).Item(0), Integer) <> 0 Then
                    MessageBox.Show("Descripción: " & CType(rstcontrol.Rows(0).Item(1), String), "ORACLE -> Error: " & CType(rstcontrol.Rows(0).Item(0), String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            End If


            'datahelper
            'rstdatos = ClaseSolatendida.actualiza_resumenrecogido()
            'rstcontrol = rstdatos.NextRecordset
            'If rstdatos.Fields.Count > 0 Then
            '    actulizatab1 = rstdatos.Fields(0).Value
            '    If actulizatab1 = 1 Then
            '        mensajetab1 = rstdatos.Fields(2).Value
            '        MessageBox.Show(mensajetab1, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        Return
            '    Else
            '        If Not IsDBNull(rstdatos.Fields(1).Value) Then
            '            dgvr.Cells(9).Value = CType(rstdatos.Fields(1).Value, Integer) 'Actualiza el estado de recojo 
            '        End If
            '    End If
            'End If
            'If rstcontrol.Fields.Count > 0 Then
            '    If CType(rstcontrol.Fields(0).Value, Integer) <> 0 Then
            '        MessageBox.Show("Descripción: " & CType(rstcontrol.Fields(1).Value, String), "ORACLE -> Error: " & CType(rstcontrol.Fields(0).Value, String), MessageBoxButtons.OK, MessageBoxIcon.Error)
            '        Return
            '    End If
            'End If
        Catch exp As Exception
            MessageBox.Show(exp.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try
        DGVResumen.Rows(dgvr.Index).ReadOnly = True
    End Sub
    Private Sub DGVResumen_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVResumen.CellValidated
        'Dim posi As New Integer
        'Select Case e.ColumnIndex
        '    Case 7  'Recuperando el valor del combo 
        '        GBoxproxfecha.Visible = False
        '        If Not IsDBNull(DGVResumen.Rows(e.RowIndex).Cells(7).Value) Then
        '            posi = DGVResumen.Rows(e.RowIndex).Cells(7).Value
        '            'valor = dvtipoobsresumen.Item(e.RowIndex).Row(1) '
        '            'valorecojo = dvtipoobsresumen.Item(posi - 1).Row(1)
        '            valorecojo = dvtipoobsresumen.Item(e.RowIndex).Row(1)
        '            Select Case valorecojo
        '                Case "REPROGRAMADO", "RECOJO PARCIAL"
        '                    Nuevafecha()
        '            End Select
        '        End If
        'End Select
    End Sub
    Private Sub FrmClientes_MenuImprimir() Handles Me.MenuImprimir
        Dim a As New ClsPrint
        Dim MyReport As New Reportes
        If tab0_control Then
            a.Titulo = "Solicita"
            a.DGV = Me.DGVSolicita
            '
            'MyReport.MdiParent = Menuintegrado  'MDITEMPLATE   [mendoza]
            MyReport.pd.Document = a
            MyReport.pd.Dock = DockStyle.Fill
            MyReport.WindowState = FormWindowState.Maximized
            MyReport.Show()
            MyReport.BringToFront()
        End If
        If tab1_control Then
            a.Titulo = "Asignación de la móvil"
            a.DGV = Me.DGVAsigna
            '
            'MyReport.MdiParent = MDITEMPLATE   [MENDOZA]
            MyReport.pd.Document = a
            MyReport.pd.Dock = DockStyle.Fill
            MyReport.WindowState = FormWindowState.Maximized
            MyReport.Show()
            MyReport.BringToFront()
        End If
        If tab2_control Then
            a.Titulo = "Recojo por la móvil"
            a.DGV = Me.DGVResumen
            '
            'MyReport.MdiParent = MDITEMPLATE   [MENDOZA] 
            MyReport.pd.Document = a
            MyReport.pd.Dock = DockStyle.Fill
            MyReport.WindowState = FormWindowState.Maximized
            MyReport.Show()
            MyReport.BringToFront()
        End If
    End Sub
#End Region
    Private Sub DGVSolicita_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGVSolicita.DoubleClick
        Dim dgvr As DataGridViewRow
        Dim iidnro_solicitud As Integer
        '
        'Dim frmingresosol As New Frmingresosolicitud   ' Trae la solicitud  
        '''''''''''''''''''''''''''''''''''''''''
        ''Try
        ''    If tab0_control Then
        ''        frmingresosol.Location = New Point(10, 10)
        ''        frmingresosol.piidagencia = CType(cmbagencia.SelectedValue, Integer)
        ''        frmingresosol.piidprovincia = iidprovincia_tab0
        ''        frmingresosol.DPMFechaatencion._MyFecha = CType(DTimePickersol.Value, String)
        ''        frmingresosol.ShowDialog()
        ''        'Recupera los datos 
        ''        recupera_solcitud()
        ''    End If
        '''''''''''''''''''''''''''''''''''''''''
        'Try
        '    dgvr = DGVSolicita.CurrentRow
        '    If IsDBNull(dgvr) = False Then
        '        If IsDBNull(dgvr.Cells(2).Value) = False Then
        '            iidnro_solicitud = CType(dgvr.Cells(2).Value, Integer)
        '            ' Traendo la solicitud  
        '            frmingresosol.Location = New Point(10, 10)
        '            frmingresosol.piidagencia = CType(cmbagencia.SelectedValue, Integer)
        '            frmingresosol.piidprovincia = iidprovincia_tab0
        '            frmingresosol.DPMFechaatencion._MyFecha = CType(DTimePickersol.Value, String)
        '            frmingresosol.control = 0 'Ingreso nuevo 
        '            frmingresosol.piidnrosolicitud_recojo_carga = iidnro_solicitud
        '            frmingresosol.ShowDialog()
        '            'Recupera los datos 
        '            recupera_solcitud()
        '        End If
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub
    Sub nuevo()  'Por ahora está comentado hasta que se retome la solución recojo 
        'Dim frmingresosol As New Frmingresosolicitud
        'Try
        '    'frmingresosol.MdiParent = Me
        '    frmingresosol.Location = New Point(10, 10)
        '    frmingresosol.piidagencia = CType(cmbagencia.SelectedValue, Integer)
        '    frmingresosol.piidprovincia = iidprovincia_tab0
        '    frmingresosol.sfecha = CType(DTimePickersol.Value, String)
        '    frmingresosol.control = 1 'Ingreso nuevo 
        '    frmingresosol.ShowDialog()
        '    'Recupera los datos 
        '    recupera_solcitud()
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Sistema de Seguridad")
        'End Try
    End Sub
    Sub editar() 'Por ahora está comentado hasta que se retome la solución recojo 
        'Dim dgvr As DataGridViewRow
        'Dim iidnro_solicitud As Integer
        'Dim frmingresosol As New Frmingresosolicitud   ' Trae la solicitud  
        'Dim liidagencia, lidprovincia As Integer
        'Dim lsfecha As String
        '''''''''''''''''''''''''''''''''''''''''
        ''Try
        ''    If tab0_control Then
        ''        frmingresosol.Location = New Point(10, 10)
        ''        frmingresosol.piidagencia = CType(cmbagencia.SelectedValue, Integer)
        ''        frmingresosol.piidprovincia = iidprovincia_tab0
        ''        frmingresosol.DPMFechaatencion._MyFecha = CType(DTimePickersol.Value, String)
        ''        frmingresosol.ShowDialog()
        ''        'Recupera los datos 
        ''        recupera_solcitud()
        ''    End If
        '''''''''''''''''''''''''''''''''''''''''
        'Try
        '    If tab0_control Then
        '        dgvr = DGVSolicita.CurrentRow
        '        If IsDBNull(dgvr) = False Then
        '            If IsDBNull(dgvr.Cells(2).Value) = False Then
        '                iidnro_solicitud = CType(dgvr.Cells(2).Value, Integer)
        '                liidagencia = CType(cmbagencia.SelectedValue, Integer)
        '                lidprovincia = iidprovincia_tab0
        '                lsfecha = CType(DTimePickersol.Value, String)
        '            End If
        '        End If
        '    End If
        '    ' 
        '    If tab1_control Then
        '        dgvr = DGVAsigna.CurrentRow
        '        If IsDBNull(dgvr) = False Then
        '            If IsDBNull(dgvr.Cells(0).Value) = False Then
        '                iidnro_solicitud = CType(dgvr.Cells(0).Value, Integer)
        '                ' Traendo la solicitud                          
        '                liidagencia = CType(Cmbagenciaasigna.SelectedValue, Integer)
        '                lidprovincia = iidprovincia_tab1
        '                lsfecha = CType(DTimePickerAsigna.Value, String)
        '            End If
        '        End If
        '    End If
        '    ' 
        '    If tab2_control Then
        '        dgvr = DGVResumen.CurrentRow
        '        If IsDBNull(dgvr) = False Then
        '            If IsDBNull(dgvr.Cells(0).Value) = False Then
        '                iidnro_solicitud = CType(dgvr.Cells(0).Value, Integer)
        '                ' Traendo la solicitud                          
        '                liidagencia = CType(cmbagenciaresumen.SelectedValue, Integer)
        '                lidprovincia = iidprovincia_tab2
        '                lsfecha = CType(DTimePickerAsigna.Value, String)
        '            End If
        '        End If
        '    End If
        '    ' Traendo la solicitud  
        '    frmingresosol.Location = New Point(10, 10)
        '    frmingresosol.piidagencia = liidagencia
        '    frmingresosol.piidprovincia = lidprovincia
        '    frmingresosol.DPMFechaatencion._MyFecha = lsfecha
        '    frmingresosol.control = 0 'Ingreso consulta 
        '    frmingresosol.piidnrosolicitud_recojo_carga = iidnro_solicitud
        '    frmingresosol.ShowDialog()
        '    'Recupera los datos 
        '    If tab0_control Then
        '        recupera_solcitud()
        '    End If
        '    If tab1_control Then
        '        recupera_agencia_asigna()
        '    End If
        '    '
        '    If tab2_control Then
        '        recupera_agencia_resumen()
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad de Sistema")
        'End Try
    End Sub
    Sub suspender()
        Try
            Dim nro_solicitud As Integer
            ' Dim aprobado As Integer 
            Dim cerrado As Integer
            Dim mensaje As String
            Dim rpta As New DialogResult
            Dim dgrv0, dgrv1, dgrv2 As DataGridViewRow
            'Dim rstdatos, rstoracle As New ADODB.Recordset
            Dim rstdatos, rstoracle As DataTable
            mensaje = "Se va a suspender la solicitud Nº "
            '
            clasesolcomun.idrol_usuariomod = dtoUSUARIOS.IdRol
            clasesolcomun.idusurio_personalmod = dtoUSUARIOS.IdLogin
            clasesolcomun.ipmod = dtoUSUARIOS.IP
            If tab0_control Then
                dgrv0 = Me.DGVSolicita.CurrentRow()
                If Not puedeactualizar(1) Then
                    Return
                End If
                nro_solicitud = dgrv0.Cells(2).Value
                'Recuperar los datos verificar que no este cerrado ni aprobado 
                mensaje = mensaje + nro_solicitud.ToString
                rpta = MessageBox.Show(Me, mensaje, "Solicitud de Carga", MessageBoxButtons.YesNo, _
                       MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)
                If rpta = DialogResult.Yes Then
                    'Grabando información   
                    clasesolcomun.idnro_solicitud = nro_solicitud
                    Dim ds As DataSet = clasesolcomun.suspender_solicitud
                    rstdatos = ds.Tables(0)
                    rstoracle = ds.Tables(1)
                    If rstdatos.Rows(0).Item(0) <> 0 Then
                        MessageBox.Show("Descripción: " & CType(rstoracle.Rows(0).Item(1), String), "ORACLE -> Error: " & CType(rstoracle.Rows(0).Item(0), String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                    dgrv0.Cells(15).Value = CType(rstdatos.Rows(0).Item(2), Integer)
                    dgrv0.Cells(14).Value = CType(rstdatos.Rows(0).Item(1), Integer)

                    'datahelper
                    'rstdatos = clasesolcomun.suspender_solicitud
                    'rstoracle = rstdatos.NextRecordset
                    'If rstdatos.Fields(0).Value <> 0 Then
                    '    MessageBox.Show("Descripción: " & CType(rstoracle.Fields(1).Value, String), "ORACLE -> Error: " & CType(rstoracle.Fields(0).Value, String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    Return
                    'End If
                    'dgrv0.Cells(15).Value = CType(rstdatos.Fields(2).Value, Integer)
                    'dgrv0.Cells(14).Value = CType(rstdatos.Fields(1).Value, Integer)
                End If
                ' Refrescando 
                recupera_solcitud()
            End If
            '
            If tab1_control Then
                dgrv1 = Me.DGVAsigna.CurrentRow()
                nro_solicitud = dgrv1.Cells(0).Value
                mensaje = mensaje + nro_solicitud.ToString
                cerrado = dgrv1.Cells(14).Value
                If cerrado = 1 Then
                    mensaje = "No puede suspender la solicitud, por estar cerrada "
                    MessageBox.Show(mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                'Recuperar los datos verificar que no este cerrado ni aprobado 
                mensaje = mensaje + nro_solicitud.ToString
                rpta = MessageBox.Show(Me, mensaje, "Solicitud de Carga", MessageBoxButtons.YesNo, _
                       MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)
                If rpta = DialogResult.Yes Then
                    'Grabando información   
                    clasesolcomun.idnro_solicitud = nro_solicitud
                    Dim ds As DataSet = clasesolcomun.suspender_solicitud
                    rstdatos = ds.Tables(0)
                    rstoracle = ds.Tables(1)
                    If rstdatos.Rows(0).Item(0) <> 0 Then
                        MessageBox.Show("Descripción: " & CType(rstoracle.Rows(0).Item(1), String), "ORACLE -> Error: " & CType(rstoracle.Rows(0).Item(0), String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                    dgrv1.Cells(14).Value = CType(rstdatos.Rows(0).Item(2), Integer)
                    dgrv1.Cells(13).Value = CType(rstdatos.Rows(0).Item(1), Integer)

                    'datahelper
                    'rstdatos = clasesolcomun.suspender_solicitud
                    'rstoracle = rstdatos.NextRecordset
                    'If rstdatos.Fields(0).Value <> 0 Then
                    '    MessageBox.Show("Descripción: " & CType(rstoracle.Fields(1).Value, String), "ORACLE -> Error: " & CType(rstoracle.Fields(0).Value, String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    Return
                    'End If
                    'dgrv1.Cells(14).Value = CType(rstdatos.Fields(2).Value, Integer)
                    'dgrv1.Cells(13).Value = CType(rstdatos.Fields(1).Value, Integer)
                End If
            End If
            '
            If tab2_control Then
                dgrv2 = Me.DGVResumen.CurrentRow()
                nro_solicitud = dgrv2.Cells(0).Value
                mensaje = mensaje + nro_solicitud.ToString
                cerrado = dgrv2.Cells(10).Value
                If cerrado = 1 Then
                    mensaje = "No puede suspender la solicitud, por estar cerrada "
                    MessageBox.Show(mensaje, "Solicitud de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                'Recuperar los datos verificar que no este cerrado ni aprobado 
                mensaje = mensaje + nro_solicitud.ToString
                rpta = MessageBox.Show(Me, mensaje, "Solicitud de Carga", MessageBoxButtons.YesNo, _
                       MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)
                If rpta = DialogResult.Yes Then
                    'Grabando información   
                    clasesolcomun.idnro_solicitud = nro_solicitud
                    Dim ds As DataSet = clasesolcomun.suspender_solicitud
                    rstdatos = ds.Tables(0)
                    rstoracle = ds.Tables(1)
                    If rstdatos.Rows(0).Item(0) <> 0 Then
                        MessageBox.Show("Descripción: " & CType(rstoracle.Rows(0).Item(1), String), "ORACLE -> Error: " & CType(rstoracle.Rows(0).Item(0), String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                    dgrv2.Cells(10).Value = CType(rstdatos.Rows(0).Item(2), Integer)
                    dgrv2.Cells(9).Value = CType(rstdatos.Rows(0).Item(1), Integer)
                    dgrv2.Cells(11).Value = rstdatos.Rows(0).Item(3)

                    'datahelper
                    'rstdatos = clasesolcomun.suspender_solicitud
                    'rstoracle = rstdatos.NextRecordset
                    'If rstdatos.Fields(0).Value <> 0 Then
                    '    MessageBox.Show("Descripción: " & CType(rstoracle.Fields(1).Value, String), "ORACLE -> Error: " & CType(rstoracle.Fields(0).Value, String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    Return
                    'End If
                    'dgrv2.Cells(10).Value = CType(rstdatos.Fields(2).Value, Integer)
                    'dgrv2.Cells(9).Value = CType(rstdatos.Fields(1).Value, Integer)
                    'dgrv2.Cells(11).Value = rstdatos.Fields(3).Value
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    'Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem1.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem1.EnabledChanged, CancelarToolStripMenuItem.EnabledChanged, GrabarToolStripMenuItem.EnabledChanged
    '    If bIngreso Then
    '        Acceso.VerificaCambio(sender, e)
    '    End If
    'End Sub
End Class
