'Imports System.Windows.Forms
'Imports System.Text.RegularExpressions
'Imports System
'Imports System.Drawing
Imports System.IO
'Imports AccesoDatos
Public Class frmControlUsuarios
    'Dim da, darol As New OleDb.OleDbDataAdapter
    Dim dt, dtrol As New System.Data.DataTable
    Dim dv, dvrol As System.Data.DataView
    Public List As Collection
    'Public ListRoles As Collection
    Dim varControl As Integer
    Dim pathImage As String
    Dim bformatImage As Boolean
    Dim posX, posY As Integer
    Dim l_dtoUSUARIOS As New dtoCONTROLUSUARIOS
    Dim ds As New DataSet
    Dim bAgencias As Boolean
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub frmControlUsuarios_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TreeLista.ExpandAll()
        TreeLista.Select()
    End Sub

    Private Sub frmControlUsuarios_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub frmControlUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            MenuStrip1.Items(4).Enabled = False
            bformatImage = False
            Call Config_Grid()
            'Dim cimage As Image()
            'cimage = System.Drawing.Image.FromFile("C:\icon\plus1.bmp.bmp")

            'menuTab.ToolStripMenuItem1.
            Tab_Control3(MenuTab, 1)
            Dim obj1 As New ValidacionTextBox(Me.txtAPEPATERNO)
            Dim obj2 As New ValidacionTextBox(Me.txtAPEMATERNO)
            Dim obj3 As New ValidacionTextBox(Me.txtNOMBRES)
            DataGridLista.Visible = False
            TxtBusca.Visible = False
            Dim var As String
            var = MenuStrip1.Items(0).Name
            var = MenuStrip1.Items(1).Name
            'DataGridViewUser.AlternatingRowsDefaultCellStyle.BackColor = RGB(E5, FF, E5)
            ShadowLabel1.Text = "Control Usuarios"
            MenuTab.Items(0).Text = "Busqueda"
            MenuTab.Items(1).Text = "Mantenimiento"
            MenuTab.Items(2).Text = "Roles"
            '
            'datahelper
            'rst = Nothing
            'rst = VOCONTROLUSUARIO.ListarAgencias(-1)
            '
            Dim obj As New dtoCONTROLUSUARIOS
            Dim dt As DataTable = obj.GET_AGENCIA()
            ModuUtil.LlenarTreeCtrl(dt, Me.TreeLista, "AGENCIAS", False)
            'TreeLista.ExpandAll()
            TreeLista.Nodes(0).SelectedImageIndex = 0
            'TreeLista.Focus()

            'datahelper
            'ModVOCONTROLUSUARIO.ListaDatosUsuarios(1, -1)
            Dim objA As New dtoCONTROLUSUARIOS
            ds = objA.Lista_Datos_Usuarios(-1) 'dtoUSUARIOS.IdLogin
            ModuUtil.LlenarCombo2(ds.Tables(0), cmbESTADOCIVIL, ModVOCONTROLUSUARIO.coll_EstadoCivil, 1)
            ModuUtil.LlenarCombo2(ds.Tables(1), cmbTIPODOC, ModVOCONTROLUSUARIO.coll_TipoDocIndentiadad, 2)
            ModuUtil.LlenarCombo2(ds.Tables(2), cmbSEXO, ModVOCONTROLUSUARIO.coll_Sexo, 1)

            ModuUtil.LlenarCombo2(ds.Tables(3), cmbPAIS, ModVOCONTROLUSUARIO.coll_Pais, 4)
            ModuUtil.LlenarCombo2(ds.Tables(4), cmbDEPARTAMENTO, ModVOCONTROLUSUARIO.coll_Departamento, 15)
            ModuUtil.LlenarCombo2(ds.Tables(5), cmbPROVINCIA, ModVOCONTROLUSUARIO.coll_Provincia, 17)
            ModuUtil.LlenarCombo2(ds.Tables(6), cmbDISTRITO, ModVOCONTROLUSUARIO.coll_Distrito, 2)

            ModuUtil.LlenarCombo2(ds.Tables(7), cmbciudad, ModVOCONTROLUSUARIO.coll_TipoUsuario, 5100)
            ModuUtil.LlenarCombo2(ds.Tables(8), cmbTurno, ModVOCONTROLUSUARIO.coll_Turnos_Agencia, 1)
            ModuUtil.LlenarCombo2(ds.Tables(9), cboRol, ModVOCONTROLUSUARIO.coll_Roles_Defecto, 1)

            'datahelper
            'ModuUtil.LlenarComboIDs(ModVOCONTROLUSUARIO.rst_EstadoCivil, cmbESTADOCIVIL, ModVOCONTROLUSUARIO.coll_EstadoCivil, 1)
            'ModuUtil.LlenarComboIDs(ModVOCONTROLUSUARIO.rst_TipoDocIndentiadad, cmbTIPODOC, ModVOCONTROLUSUARIO.coll_TipoDocIndentiadad, 2)
            'ModuUtil.LlenarComboIDs(ModVOCONTROLUSUARIO.rst_Sexo, cmbSEXO, ModVOCONTROLUSUARIO.coll_Sexo, 1)

            'ModuUtil.LlenarComboIDs(ModVOCONTROLUSUARIO.rst_Pais, cmbPAIS, ModVOCONTROLUSUARIO.coll_Pais, 4)
            'ModuUtil.LlenarComboIDs(ModVOCONTROLUSUARIO.rst_Departamento, cmbDEPARTAMENTO, ModVOCONTROLUSUARIO.coll_Departamento, 15)
            'ModuUtil.LlenarComboIDs(ModVOCONTROLUSUARIO.rst_Provincia, cmbPROVINCIA, ModVOCONTROLUSUARIO.coll_Provincia, 17)
            'ModuUtil.LlenarComboIDs(ModVOCONTROLUSUARIO.rst_Distrito, cmbDISTRITO, ModVOCONTROLUSUARIO.coll_Distrito, 2)

            'ModuUtil.LlenarComboIDs(ModVOCONTROLUSUARIO.rst_TipoUsuario, cmbciudad, ModVOCONTROLUSUARIO.coll_TipoUsuario, 5100)
            'ModuUtil.LlenarComboIDs(ModVOCONTROLUSUARIO.rst_Turnos_Agencia, cmbTurno, ModVOCONTROLUSUARIO.coll_Turnos_Agencia, 1)

            'Dim varSP_OBJECT As Object() = {"PKG_IVOCONTROLUSUARIO.SP_LISTA_ROL_USUARIO", 4, 1, 1}
            'Call Config_Grid()
            EliminarToolStripMenuItem.Enabled = True

            ConfiguraGridRoles()

            bIngreso = False
            Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    '08/11/2008 - 
    'Private Sub frmControlUsuarios_Nuevo()
    '    Try
    '        If dtoUSUARIOS.iIDAGENCIAS <= 0 Then
    '            NuevoToolStripMenuItem1.Enabled = True
    '            EdicionToolStripMenuItem.Enabled = True
    '            GrabarToolStripMenuItem.Enabled = False
    '            TabMante.SelectedIndex = 0
    '            MsgBox("Debe Elegir una Agencia Valida", MsgBoxStyle.Exclamation, "Seguridad Sistema")
    '            GroupDatos.Enabled = False
    '        Else
    '            GroupDatos.Enabled = True
    '            Tab_Control3(MenuTab, 2)
    '            varControl = 1 ' Para el control Nuevo registro
    '            'CancelarToolStripMenuItem.Visible = True
    '            SplitContainer2.Panel1Collapsed = True
    '            dtoUSUARIOS.iIDUSUARIO_PERSONAL = -1
    '            'TabUsuarios.SelectedIndex = 1
    '            LimpiarGrid(DataGridViewRoles)

    '            Me.txtAPEMATERNO.Text = ""
    '            Me.txtAPEPATERNO.Text = ""
    '            Me.txtNOMBRES.Text = ""
    '            Me.txtCELULAR.Text = ""
    '            Me.txtTELEFONO.Text = ""
    '            Me.txtDIRECCION.Text = ""08
    '            Me.txtE_MAIL.Text = ""
    '            Me.txtE_MAIL_EMP.Text = ""
    '            Me.txtFAX.Text = ""
    '            Me.txtLOGIN.Text = ""
    '            Me.txtCONFPASSWORD.Text = ""
    '            Me.txtPASSWORD.Text = ""
    '            Me.txtNRODOC.Text = ""
    '            Me.txtRPM.Text = ""
    '            ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_TipoUsuario, cmbciudad, dtoUSUARIOS.iIDTIPO_USUARIO_PERSONAL)
    '            ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_EstadoCivil, cmbESTADOCIVIL, 1)
    '            ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_TipoDocIndentiadad, cmbTIPODOC, 2)
    '            ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_Sexo, cmbSEXO, 1)
    '            ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_Pais, cmbPAIS, 4)
    '            ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_Departamento, cmbDEPARTAMENTO, 15)
    '            ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_Provincia, cmbPROVINCIA, 17)
    '            ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_Distrito, cmbDISTRITO, 2)
    '            ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_TipoUsuario, cmbciudad, 11)
    '            ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_Turnos_Agencia, cmbTurno, 1)
    '            chkOtrasAgencias.Checked = False
    '            Me.chk_entrega_sin_verificacion.Checked = False

    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
    '    End Try
    'End Sub
    Private Sub frmControlUsuarios_Nuevo()
        Try
            If l_dtoUSUARIOS.iIDAGENCIAS < 0 Then
                NuevoToolStripMenuItem1.Enabled = True
                EdicionToolStripMenuItem.Enabled = True
                GrabarToolStripMenuItem.Enabled = False
                TabMante.SelectedIndex = 0
                MsgBox("Debe Elegir una Agencia Valida", MsgBoxStyle.Exclamation, "Seguridad Sistema")
                GroupDatos.Enabled = False
            Else
                GroupDatos.Enabled = True
                Tab_Control3(MenuTab, 2)
                varControl = 1 ' Para el control Nuevo registro
                'CancelarToolStripMenuItem.Visible = True
                SplitContainer2.Panel1Collapsed = True
                dtoUSUARIOS.iIDUSUARIO_PERSONAL = -1
                'TabUsuarios.SelectedIndex = 1
                LimpiarGrid(DataGridViewRoles)

                Me.txtAPEMATERNO.Text = ""
                Me.txtAPEPATERNO.Text = ""
                Me.txtNOMBRES.Text = ""
                Me.txtCELULAR.Text = ""
                Me.txtTELEFONO.Text = ""
                Me.txtDIRECCION.Text = ""
                Me.txtE_MAIL.Text = ""
                Me.txtE_MAIL_EMP.Text = ""
                Me.txtFAX.Text = ""
                Me.txtLOGIN.Text = ""
                Me.txtCONFPASSWORD.Text = ""
                Me.txtPASSWORD.Text = ""
                Me.txtNRODOC.Text = ""
                Me.txtRPM.Text = ""
                Me.cboRol.DataSource = Nothing
                Me.cboRol.SelectedIndex = 0
                'datahelper
                'ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_TipoUsuario, cmbciudad, dtoUSUARIOS.iIDTIPO_USUARIO_PERSONAL)
                'ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_EstadoCivil, cmbESTADOCIVIL, 1)
                'ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_TipoDocIndentiadad, cmbTIPODOC, 2)
                'ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_Sexo, cmbSEXO, 1)
                'ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_Pais, cmbPAIS, 4)
                'ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_Departamento, cmbDEPARTAMENTO, 15)
                'ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_Provincia, cmbPROVINCIA, 17)
                'ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_Distrito, cmbDISTRITO, 2)
                'ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_TipoUsuario, cmbciudad, 11)
                'ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_Turnos_Agencia, cmbTurno, 1)

                'ModuUtil.BuscarItemCM(ds.Tables(0), cmbESTADOCIVIL, dtoUSUARIOS.iIDTIPO_USUARIO_PERSONAL)
                ModuUtil.BuscarItemCM(ds.Tables(0), cmbESTADOCIVIL, 1)
                ModuUtil.BuscarItemCM(ds.Tables(1), cmbTIPODOC, 2)
                ModuUtil.BuscarItemCM(ds.Tables(2), cmbSEXO, 1)
                ModuUtil.BuscarItemCM(ds.Tables(3), cmbPAIS, 4)
                ModuUtil.BuscarItemCM(ds.Tables(4), cmbDEPARTAMENTO, 15)
                ModuUtil.BuscarItemCM(ds.Tables(5), cmbPROVINCIA, 17)
                ModuUtil.BuscarItemCM(ds.Tables(6), cmbDISTRITO, 2)
                ModuUtil.BuscarItemCM(ds.Tables(7), cmbciudad, 11)
                ModuUtil.BuscarItemCM(ds.Tables(8), cmbTurno, 1)

                chkOtrasAgencias.Checked = False
                Me.chk_entrega_sin_verificacion.Checked = False

            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub Config_Grid()
        Try

            Dim idEstadoImage As New DataGridViewImageColumn
            With idEstadoImage
                .DataPropertyName = "imagen"
                .HeaderText = "ESTADO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DisplayIndex = 0
                .Visible = True
                '.ValuesAreIcons = True
                '.InheritedStyle.BackColor = Color.Transparent
                .Image = bmActivo
            End With
            DataGridViewUser.Columns.Add(idEstadoImage)

            Dim IDUSUARIO_PERSONAL As New DataGridViewTextBoxColumn
            With IDUSUARIO_PERSONAL
                .DataPropertyName = "IDUSUARIO_PERSONAL"
                .HeaderText = "IDUSUARIO_PERSONAL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DisplayIndex = 1
                '.ReadOnly = True
                .Visible = False
                '.Frozen = True
            End With
            DataGridViewUser.Columns.Add(IDUSUARIO_PERSONAL)

            Dim IDAGENCIAS As New DataGridViewTextBoxColumn
            With IDAGENCIAS
                .DataPropertyName = "IDAGENCIAS"
                .HeaderText = "IDAGENCIAS"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DisplayIndex = 2
                '.ReadOnly = True
                .Visible = False
                '.Frozen = True
            End With
            DataGridViewUser.Columns.Add(IDAGENCIAS)

            Dim AGENCIA As New DataGridViewTextBoxColumn
            With AGENCIA
                .DataPropertyName = "AGENCIA"
                .HeaderText = "AGENCIA(S)"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DisplayIndex = 3
                .ReadOnly = True
                '.Frozen = True
            End With
            DataGridViewUser.Columns.Add(AGENCIA)


            Dim Nombres As New DataGridViewTextBoxColumn
            With Nombres
                .DataPropertyName = "NOMBRES"
                .HeaderText = "NOMBRES"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DisplayIndex = 4
                .ReadOnly = True
                '.Frozen = True
            End With
            DataGridViewUser.Columns.Add(Nombres)
            Dim E_MAIL As New DataGridViewTextBoxColumn
            With E_MAIL
                .DataPropertyName = "E_MAIL"
                .HeaderText = "E_MAIL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DisplayIndex = 5
                .ReadOnly = True
                '.Frozen = True
            End With
            DataGridViewUser.Columns.Add(E_MAIL)

            Dim COMUNICACION As New DataGridViewTextBoxColumn
            With COMUNICACION
                .DataPropertyName = "COMUNICACION"
                .HeaderText = "COMUNICACION"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DisplayIndex = 6
                .ReadOnly = True
                '.Frozen = True
            End With
            DataGridViewUser.Columns.Add(COMUNICACION)

            Dim IDESTADO_REGISTRO As New DataGridViewTextBoxColumn
            With IDESTADO_REGISTRO
                .DataPropertyName = "IDESTADO_REGISTRO"
                .HeaderText = "IDESTADO_REGISTRO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DisplayIndex = 7
                .ReadOnly = True
                .Visible = False
                '.Frozen = True
            End With
            DataGridViewUser.Columns.Add(IDESTADO_REGISTRO)

        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub frmControlUsuarios_MenuCancelar() Handles Me.MenuCancelar
        Try
            Tab_Control3(MenuTab, 1)
            SplitContainer2.Panel1Collapsed = False
            SelectMenu(0)
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    '08/11/2008 - 
    'Private Sub frmControlUsuarios_MenuGrabar() Handles Me.MenuGrabar
    '    Try
    '        If LTrim(txtAPEMATERNO.Text) <> "" Then
    '            Me.ErrorProviderControl.SetError(Me.txtAPEMATERNO, "")
    '        Else
    '            Me.ErrorProviderControl.SetError(Me.txtAPEMATERNO, "Ingrese Apellido Materno")
    '        End If

    '        If LTrim(txtAPEPATERNO.Text) <> "" Then
    '            Me.ErrorProviderControl.SetError(Me.txtAPEPATERNO, "")
    '        Else
    '            Me.ErrorProviderControl.SetError(Me.txtAPEPATERNO, "Ingrese Apellido Paterno")
    '        End If

    '        If LTrim(Me.txtNOMBRES.Text) <> "" Then
    '            Me.ErrorProviderControl.SetError(Me.txtNOMBRES, "")
    '        Else
    '            Me.ErrorProviderControl.SetError(Me.txtNOMBRES, "Ingrese Sus Nombres")
    '        End If

    '        If LTrim(Me.txtLOGIN.Text) <> "" Then
    '            Me.ErrorProviderControl.SetError(Me.txtLOGIN, "")
    '        Else
    '            Me.ErrorProviderControl.SetError(Me.txtLOGIN, "Ingrese su Login de Usuario")
    '        End If

    '        If LTrim(Me.txtPASSWORD.Text) <> "" Then
    '            Me.ErrorProviderControl.SetError(Me.txtPASSWORD, "")
    '        Else
    '            Me.ErrorProviderControl.SetError(Me.txtPASSWORD, "Ingrese Pasword")
    '        End If
    '        If LTrim(Me.txtCONFPASSWORD.Text) <> "" Then
    '            Me.ErrorProviderControl.SetError(Me.txtCONFPASSWORD, "")
    '        Else
    '            Me.ErrorProviderControl.SetError(Me.txtCONFPASSWORD, "Ingrese Confirmacion de su Pasword")
    '        End If

    '        dtoUSUARIOS.iCONTROL = varControl
    '        dtoUSUARIOS.iIDTURNOS_AGENCIA = 1
    '        'dtoUSUARIOS.iIDAGENCIAS = 1
    '        If dtoUSUARIOS.iIDUSUARIO_PERSONAL < 0 Then
    '            dtoUSUARIOS.iIDUSUARIO_PERSONAL = 0
    '        End If

    '        dtoUSUARIOS.iLOGIN = 2
    '        'iIP in T_AGENCIA_USUARIOS.IP%type,                      
    '        'Public iIDROL_USUARIO As Integer
    '        dtoUSUARIOS.iNOMPER = IIf(Me.txtNOMBRES.Text <> "", Me.txtNOMBRES.Text, "NULL")
    '        dtoUSUARIOS.iAPEMAT = IIf(Me.txtAPEMATERNO.Text <> "", txtAPEMATERNO.Text, "NULL")
    '        dtoUSUARIOS.iAPEPAT = IIf(Me.txtAPEPATERNO.Text.ToString() <> "", txtAPEPATERNO.Text, "NULL")

    '        dtoUSUARIOS.iIDTIPO_DOC_IDENTIDAD = Int(coll_TipoDocIndentiadad(cmbTIPODOC.SelectedIndex.ToString()))
    '        'Int(IDcmbRol(Me.cmbRol.SelectedIndex.ToString()))
    '        dtoUSUARIOS.iNRODOC = IIf(Me.txtNRODOC.Text.ToString() <> "", txtNRODOC.Text, "NULL")
    '        'dtoUSUARIOS.iFECHA_NACIMIENTO = Format("##/##/####", txtFechaNacimiento.Text.ToString())
    '        dtoUSUARIOS.iFECHA_NACIMIENTO = Format("##/##/####", DateTimePicker1.Text.ToString())
    '        dtoUSUARIOS.iIDTIPO_USUARIO_PERSONAL = Int(coll_TipoUsuario(cmbciudad.SelectedIndex.ToString()))
    '        dtoUSUARIOS.iLOGIN = IIf(Me.txtLOGIN.Text.ToString() <> "", txtLOGIN.Text, "NULL")
    '        dtoUSUARIOS.iPASSWORD = IIf(Me.txtPASSWORD.Text.ToString() <> "", txtPASSWORD.Text, "NULL")
    '        dtoUSUARIOS.iE_MAIL = IIf(Me.txtE_MAIL.Text.ToString() <> "", txtE_MAIL.Text, "NULL")
    '        dtoUSUARIOS.iTELEFONO = IIf(Me.txtTELEFONO.Text.ToString() <> "", txtTELEFONO.Text, "NULL")
    '        dtoUSUARIOS.iCELULAR = IIf(Me.txtCELULAR.Text.ToString() <> "", txtCELULAR.Text, "NULL")
    '        dtoUSUARIOS.iDIRECCION = IIf(Me.txtDIRECCION.Text.ToString() <> "", txtDIRECCION.Text, "NULL")
    '        dtoUSUARIOS.iIDUSUARIO_CREADOR = dtoUSUARIOS.IdLogin
    '        dtoUSUARIOS.iIDAREA_SISTEMA = 1
    '        dtoUSUARIOS.iIDROL_CREADOR = dtoUSUARIOS.IdRol
    '        dtoUSUARIOS.iIDSEXO = Int(coll_Sexo(cmbSEXO.SelectedIndex.ToString()))
    '        If CheckActivo.Checked = True Then
    '            dtoUSUARIOS.iIDESTADO_REGISTRO = 1
    '        Else
    '            dtoUSUARIOS.iIDESTADO_REGISTRO = 9 ' Estado de Registro inactivo
    '        End If
    '        '02/11/2008 
    '        dtoUSUARIOS.iIDOTRAS_AGENCIAS = IIf(chkOtrasAgencias.Checked, 1, 0)
    '        dtoUSUARIOS.iind_autoriza_entrega = IIf(Me.chk_entrega_sin_verificacion.Checked, 1, 0)
    '        '
    '        dtoUSUARIOS.iIDDISTRITO = IIf(cmbDISTRITO.SelectedIndex.ToString() <> "", Int(ModVOCONTROLUSUARIO.coll_Distrito(cmbDISTRITO.SelectedIndex.ToString())), -666)
    '        dtoUSUARIOS.iIDPROVINCIA = IIf(cmbPROVINCIA.SelectedIndex.ToString() <> "", Int(ModVOCONTROLUSUARIO.coll_Provincia(cmbPROVINCIA.SelectedIndex.ToString())), -666)
    '        dtoUSUARIOS.iIDDEPARTAMENTO = IIf(cmbDEPARTAMENTO.SelectedIndex.ToString() <> "", Int(ModVOCONTROLUSUARIO.coll_Departamento(cmbDEPARTAMENTO.SelectedIndex.ToString())), -666)
    '        dtoUSUARIOS.iIDPAIS = IIf(cmbPAIS.SelectedIndex.ToString() <> "", Int(ModVOCONTROLUSUARIO.coll_Pais(cmbPAIS.SelectedIndex.ToString())), -666)
    '        'dtoUSUARIOS.iFOTO = pathImage
    '        '
    '        dtoUSUARIOS.iFOTO = IIf(dlgOpen.FileName <> "OpenFileDialog", dlgOpen.FileName, "NULL")
    '        dtoUSUARIOS.iIDESTADO_CIVIL = IIf(cmbESTADOCIVIL.SelectedIndex.ToString() <> "", Int(coll_EstadoCivil(cmbESTADOCIVIL.SelectedIndex.ToString())), -666)
    '        dtoUSUARIOS.iIDUBIGEO = 7895    ' Esta fijo Tepsa 
    '        dtoUSUARIOS.iFAX = IIf(txtFAX.Text.ToString() <> "", txtFAX.Text.ToString(), "NULL")
    '        dtoUSUARIOS.iRPM = IIf(txtRPM.Text.ToString() <> "", txtRPM.Text.ToString(), "NULL")
    '        dtoUSUARIOS.m_sPassword = IIf(dtoUSUARIOS.iPASSWORD <> "", dtoUSUARIOS.iPASSWORD, "NULL")
    '        '
    '        dtoUSUARIOS.snro_licencia = IIf(txtNroLicencia.Text = "", 0, txtNroLicencia.Text)  ' Ingresado por Tepsa 22/11/2006
    '        '
    '        If dtoUSUARIOS.iPASSWORD = Me.txtCONFPASSWORD.Text.ToString() Then
    '            rst = Nothing
    '            If txtE_MAIL.Text.ToString() = "" Then
    '                Dim i As Integer
    '                dtoUSUARIOS.idListRoles = ""
    '                For i = 0 To DataGridViewRoles.Rows().Count - 2
    '                    If i = DataGridViewRoles.Rows().Count - 2 Then
    '                        dtoUSUARIOS.idListRoles = dtoUSUARIOS.idListRoles & DataGridViewRoles.Rows().Item(i).DataGridView(0, i).Value.ToString()
    '                    Else
    '                        dtoUSUARIOS.idListRoles = dtoUSUARIOS.idListRoles & DataGridViewRoles.Rows().Item(i).DataGridView(0, i).Value.ToString() & ","
    '                    End If
    '                Next i
    '                If dtoUSUARIOS.idListRoles <> "" Then

    '                    If dtoUSUARIOS.Grabar() = False Then
    '                        Return
    '                    End If

    '                    SplitContainer2.Panel1Collapsed = False
    '                    SelectMenu(0)
    '                    Tab_Control3(MenuTab, 1)
    '                Else
    '                    MsgBox("Debe Seleccionar el Item para la Carga de Roles a Usuarios", MsgBoxStyle.Exclamation, "Seguridad Sistema")
    '                End If
    '            Else
    '                If ValiadarEXP_REG_Mail(txtE_MAIL.Text) Then
    '                    If DataGridViewRoles.Rows().Count > 1 Then
    '                        Dim i As Integer
    '                        dtoUSUARIOS.idListRoles = ""
    '                        For i = 0 To DataGridViewRoles.Rows().Count - 2
    '                            If i = DataGridViewRoles.Rows().Count - 2 Then
    '                                dtoUSUARIOS.idListRoles = dtoUSUARIOS.idListRoles & DataGridViewRoles.Rows().Item(i).DataGridView(0, i).Value.ToString()
    '                            Else
    '                                dtoUSUARIOS.idListRoles = dtoUSUARIOS.idListRoles & DataGridViewRoles.Rows().Item(i).DataGridView(0, i).Value.ToString() & ","
    '                            End If
    '                        Next i
    '                        'End If

    '                        If dtoUSUARIOS.Grabar() = False Then
    '                            Return
    '                        End If

    '                        If varControl = 1 Then 'Caso de Insertcion
    '                            Dim row0 As String() = {dtoLista_Usuario.iIDUSUARIO_PERSONAL, dtoLista_Usuario.iIDAGENCIAS, dtoLista_Usuario.iNOMBRE_AGENCIA, dtoLista_Usuario.iNombres, dtoLista_Usuario.iE_MAIL, dtoLista_Usuario.iCOMUNICACION, dtoLista_Usuario.iIDESTADO_REGISTRO}
    '                            DataGridViewRoles.Rows().Add(row0)
    '                        Else  ' 'Caso de Modificacion

    '                        End If
    '                        Tab_Control3(MenuTab, 1)
    '                        SplitContainer2.Panel1Collapsed = False
    '                        SelectMenu(0)

    '                    Else
    '                        MsgBox("No puede Registrar al usuario no Tiene Asociado nin gun Rol", MsgBoxStyle.Critical, "Seguridad Sistema")
    '                    End If

    '                Else
    '                    MsgBox("La Descripcion Mail NO ES VALIDO", MsgBoxStyle.Critical, "Seguridad Sistema")
    '                End If
    '            End If
    '        Else
    '            MsgBox("Su password no está bien escrito", MsgBoxStyle.Critical, "Seguridad Sistema")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad del Sistema")
    '    End Try
    'End Sub

    Private Sub frmControlUsuarios_MenuNuevo() Handles Me.MenuNuevo
        Try
            Call frmControlUsuarios_Nuevo()
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    '08/11/2008
    'Private Sub TreeLista_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeLista.AfterSelect
    '    Try
    '        dtoUSUARIOS.iIDAGENCIAS = e.Node().Tag
    '        lbAgencias.Text = e.Node().Text.ToString()
    '        txtAgencia.Text = e.Node().Text.ToString()
    '        If dtoUSUARIOS.iIDAGENCIAS > 0 Then


    '            dt.Clear()
    '            'LimpiarGrid(DataGridViewUser)
    '            'Me.DataGridLista.DataSource = dt
    '            rst = Nothing
    '            rst = VOCONTROLUSUARIO.ListaUsuariosAgencias(e.Node().Tag, 1)
    '            da.Fill(dt, rst)
    '            dv = dt.DefaultView
    '            DataGridViewUser.DataSource = dv
    '            DataGridViewUser.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    '            'DataGridViewUser.Columns(0).Visible = False
    '            'DataGridViewUser.Columns(1).Visible = False

    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
    '    End Try
    'End Sub
    '08/11/2008 
    'Private Sub btnFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltro.Click
    '    Try
    '        Dim vfrm As New frmFiltroRoles()
    '        vfrm.ShowDialog()
    '        Dim item As Integer
    '        item = 0
    '        If ListRoles.Count > 0 Then
    '            dtoUSUARIOS.idListRoles = ""
    '            For Each thisObject As dtoCONTROLUSUARIOS In ListRoles
    '                item = item + 1
    '                Dim row0 As String() = {thisObject.IdRol.ToString(), thisObject.Rol.ToString()}
    '                If item = ListRoles.Count Then
    '                    dtoUSUARIOS.idListRoles = dtoUSUARIOS.idListRoles & thisObject.IdRol.ToString()
    '                Else
    '                    dtoUSUARIOS.idListRoles = dtoUSUARIOS.idListRoles & thisObject.IdRol.ToString() & ","
    '                End If
    '                DataGridViewRoles.Rows().Add(row0)
    '            Next thisObject
    '        End If
    '        DataGridViewRoles.Columns(0).ReadOnly = True
    '        DataGridViewRoles.Columns(1).ReadOnly = True
    '        DataGridViewRoles.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '        DataGridViewRoles.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '        DataGridViewRoles.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")


    '    Catch ex As Exception
    '        MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema...")
    '    End Try
    'End Sub

    Private Sub btnCargaImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargaImagen.Click
        Try
            dlgOpen.Filter = "Fotos Usuarios (*.jpg)|*.jpg"
            If dlgOpen.ShowDialog() = Windows.Forms.DialogResult.OK Then
                PBImagen.Image = New Bitmap(dlgOpen.FileName)
                pathImage = dlgOpen.FileName
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema...")
        End Try
    End Sub

    Private Sub txtDIRECCION_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIRECCION.KeyPress, txtAgencia.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            If IsNumeric(e.KeyChar) Or Char.IsLetter(e.KeyChar) Or e.KeyChar = "#" Or e.KeyChar = "-" Then
                'e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                e.Handled = False
            ElseIf e.KeyChar = " " Then
                If tb.Text.Substring(tb.Text.Length() - 1) = " " Then
                    e.Handled = True
                Else
                    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "'" Then
                e.Handled = True
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub
    Private Sub numericTextboxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNRODOC.KeyPress, txtTELEFONO.KeyPress, txtCELULAR.KeyPress, txtFAX.KeyPress, txtRPM.KeyPress, txtNroLicencia.KeyPress
        'Try
        '    Dim tb As TextBox = CType(sender, TextBox)
        '    Dim chr As Char = e.KeyChar
        '    If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
        '        e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
        '        'ElseIf e.KeyChar = "." Then
        '        'If Not (tb.SelectedText = "." Or IsNumeric(tb.Text & e.KeyChar)) Then
        '        'e.Handled = True
        '        'End If
        '        'ElseIf e.KeyChar = "-" Then
        '        'If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
        '        'e.Handled = True
        '        'End If
        '    ElseIf Not Char.IsControl(e.KeyChar) Then
        '        e.Handled = True
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        'End Try
    End Sub
    Private Sub DatosPersonalesboxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAPEPATERNO.KeyPress, txtAPEMATERNO.KeyPress, txtNOMBRES.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            If Not IsNumeric(e.KeyChar) And Char.IsLetter(e.KeyChar) Then
                e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
            ElseIf e.KeyChar = " " Then
                If tb.Text.Substring(tb.Text.Length() - 1) = " " Then
                    e.Handled = True
                Else
                    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "'" Then
                e.Handled = True
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub
    Private Sub DataGridViewUser_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewUser.DoubleClick
        Try
            'Dim col As Integer = DataGridViewUser.Item(2, DataGridViewUser.CurrentRow.Index).Value
            'Dim col As Integer = DataGridViewUser.CurrentRow.Cells.Item(1).Value

            Dim row As Integer = DataGridViewUser.SelectedRows.Item(0).Index
            If DataGridViewUser.Rows().Count - 1 = row Then
                Return
            End If

            If row >= 0 Then
                Dim col As Integer = DataGridViewUser.CurrentCell.ColumnIndex
                If col = 2 Then
                    Dim frm As New FrmListaAgencias
                    frm.Usuario = DataGridViewUser.Item(1, DataGridViewUser.CurrentRow.Index).Value
                    frm.ShowDialog()
                Else
                    If IsNothing(DataGridViewUser.Rows(row).Cells(1).Value) = False Then 'If var <> Nothing Then                
                        Call Load_Edicion()
                    Else
                        MsgBox("No Puede Editar el Registro No existe...", MsgBoxStyle.Information, "Seguridad Sistema")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub frmControlUsuarios_MenuEditar() Handles Me.MenuEditar
        Try
            Dim row As Integer = DataGridViewUser.SelectedRows.Item(0).Index
            If DataGridViewUser.Rows().Count - 1 = row Then
                Return
            End If
            If row >= 0 Then
                Call Load_Edicion()
                GroupDatos.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema...")
        End Try
    End Sub
    '08/11/2008 - 
    'Private Sub Load_Edicion()
    '    Try
    '        GrabarToolStripMenuItem.Enabled = True
    '        'SplitContainer2.Panel1Collapsed = True
    '        'SplitContainer2.Panel1Collapsed = True
    '        varControl = 0 ' Para el control y la modifacion del registro.......
    '        Dim row As Integer = DataGridViewUser.SelectedRows.Item(0).Index
    '        If row >= 0 Then
    '            Dim var As Object = DataGridViewUser.Rows(row).Cells(7).Value
    '            If var = Nothing Then
    '                MsgBox("No Puede Realizar esta Operacion", MsgBoxStyle.Information, "Seguridad Sistema")
    '                GroupDatos.Enabled = False
    '                Return
    '            End If

    '            SplitContainer2.Panel1Collapsed = True
    '            NuevoToolStripMenuItem1.Enabled = False
    '            EdicionToolStripMenuItem.Enabled = False
    '            GrabarToolStripMenuItem.Enabled = True
    '            TabMante.SelectedIndex = 1
    '            Tab_Control3(MenuTab, 2)
    '            varControl = 0 ' Para el control y la modifacion del registro.......


    '            dtoUSUARIOS.iIDUSUARIO_PERSONAL = Int(DataGridViewUser.Rows(row).DataGridView(1, row).Value.ToString)
    '            dtoUSUARIOS.iIDAGENCIAS = Int(DataGridViewUser.Rows(row).DataGridView(2, row).Value.ToString)

    '            If (dtoUSUARIOS.GetUsuario() = True) Then
    '                txtNOMBRES.Text = dtoUSUARIOS.iNOMPER
    '                txtAPEMATERNO.Text = dtoUSUARIOS.iAPEMAT
    '                txtAPEPATERNO.Text = dtoUSUARIOS.iAPEPAT
    '                ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_TipoDocIndentiadad, cmbTIPODOC, dtoUSUARIOS.iIDTIPO_DOC_IDENTIDAD)

    '                txtNRODOC.Text = dtoUSUARIOS.iNRODOC
    '                DateTimePicker1.Text = dtoUSUARIOS.iFECHA_NACIMIENTO
    '                'DateTimePicker1.Value = CDate(dtoUSUARIOS.iFECHA_NACIMIENTO)
    '                ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_TipoUsuario, cmbciudad, dtoUSUARIOS.iIDTIPO_USUARIO_PERSONAL)
    '                txtLOGIN.Text = dtoUSUARIOS.iLOGIN
    '                txtPASSWORD.Text = dtoUSUARIOS.iPASSWORD
    '                txtE_MAIL.Text = dtoUSUARIOS.iE_MAIL
    '                txtTELEFONO.Text = dtoUSUARIOS.iTELEFONO
    '                txtCELULAR.Text = dtoUSUARIOS.iCELULAR
    '                txtDIRECCION.Text = dtoUSUARIOS.iDIRECCION
    '                ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_Sexo, cmbSEXO, dtoUSUARIOS.iIDSEXO)
    '                If dtoUSUARIOS.iIDESTADO_REGISTRO = 1 Then
    '                    CheckActivo.Checked = True
    '                Else
    '                    CheckActivo.Checked = False
    '                End If

    '                If dtoUSUARIOS.iIDOTRAS_AGENCIAS = 1 Then
    '                    chkOtrasAgencias.Checked = True
    '                Else
    '                    chkOtrasAgencias.Checked = False
    '                End If
    '                '
    '                If dtoUSUARIOS.iind_autoriza_entrega = 1 Then
    '                    Me.chk_entrega_sin_verificacion.Checked = True
    '                Else
    '                    Me.chk_entrega_sin_verificacion.Checked = False
    '                End If
    '                '
    '                'Int(coll_Distrito(cmbDISTRITO.SelectedIndex.ToString()))=dtoUSUARIOS.iIDDISTRITO 
    '                'Int(coll_Provincia(cmbPROVINCIA.SelectedIndex.ToString()))=dtoUSUARIOS.iIDPROVINCIA 
    '                'Int(coll_Departamento(cmbDEPARTAMENTO.SelectedIndex.ToString()))=dtoUSUARIOS.iIDDEPARTAMENTO 
    '                'Int(coll_Pais(cmbPAIS.SelectedIndex.ToString()))=dtoUSUARIOS.iIDPAIS 

    '                'dtoUSUARIOS.iFOTO = pathImage
    '                'dtoUSUARIOS.iFOTO = dlgOpen.FileName
    '                ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_EstadoCivil, cmbESTADOCIVIL, dtoUSUARIOS.iIDESTADO_CIVIL)
    '                'dtoUSUARIOS.iIDUBIGEO = 7895
    '                txtFAX.Text = dtoUSUARIOS.iFAX
    '                txtRPM.Text = dtoUSUARIOS.iRPM
    '                txtPASSWORD.Text = dtoUSUARIOS.iPASSWORD
    '                txtCONFPASSWORD.Text = dtoUSUARIOS.iPASSWORD
    '                '
    '                txtNroLicencia.Text = dtoUSUARIOS.snro_licencia


    '                'dtoUSUARIOS.iBlobFoto = rst_usuario_Personal.Fields(2).Value
    '                If IsNothing(dtoUSUARIOS.iBlobFoto) = False Then
    '                    PBImagen.Image = Image.FromStream(New MemoryStream(dtoUSUARIOS.iBlobFoto))
    '                Else
    '                    PBImagen.Image = bmNoImagen
    '                End If
    '                'Cargando los datos del Item Roles
    '                'dtrol.Clear()
    '                'DataGridViewRoles.Rows().Remove(DataGridViewRoles.Rows().Item(0))
    '                CargarDataGrid(dtoUSUARIOS.rst_Rol_Usuario, DataGridViewRoles, 2)
    '                'darol.Fill(dtrol, dtoUSUARIOS.rst_Rol_Usuario)
    '                'DataGridViewRoles.DataSource = dtrol.DefaultView
    '                DataGridViewRoles.Columns(0).Visible = False
    '                DataGridViewRoles.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
    '    End Try
    'End Sub
    Private Sub Load_Edicion()
        Try
            GrabarToolStripMenuItem.Enabled = True
            'SplitContainer2.Panel1Collapsed = True
            'SplitContainer2.Panel1Collapsed = True
            varControl = 0 ' Para el control y la modifacion del registro.......
            Dim row As Integer = DataGridViewUser.SelectedRows.Item(0).Index
            If row >= 0 Then
                Dim var As Object = DataGridViewUser.Rows(row).Cells(7).Value
                If var = Nothing Then
                    MsgBox("No Puede Realizar esta Operacion", MsgBoxStyle.Information, "Seguridad Sistema")
                    GroupDatos.Enabled = False
                    Return
                End If

                SplitContainer2.Panel1Collapsed = True
                NuevoToolStripMenuItem1.Enabled = False
                EdicionToolStripMenuItem.Enabled = False
                GrabarToolStripMenuItem.Enabled = True
                TabMante.SelectedIndex = 1
                Tab_Control3(MenuTab, 2)
                varControl = 0 ' Para el control y la modifacion del registro.......

                l_dtoUSUARIOS.iIDUSUARIO_PERSONAL = Int(DataGridViewUser.Rows(row).DataGridView(1, row).Value.ToString)
                l_dtoUSUARIOS.iIDAGENCIAS = Int(DataGridViewUser.Rows(row).DataGridView(2, row).Value.ToString)

                If (l_dtoUSUARIOS.GetUsuario() = True) Then
                    txtNOMBRES.Text = l_dtoUSUARIOS.iNOMPER
                    txtAPEMATERNO.Text = l_dtoUSUARIOS.iAPEMAT
                    txtAPEPATERNO.Text = l_dtoUSUARIOS.iAPEPAT
                    'datahelper
                    'ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_TipoDocIndentiadad, cmbTIPODOC, l_dtoUSUARIOS.iIDTIPO_DOC_IDENTIDAD)
                    ModuUtil.BuscarItemCM(ds.Tables(1), cmbTIPODOC, l_dtoUSUARIOS.iIDTIPO_DOC_IDENTIDAD)

                    txtNRODOC.Text = l_dtoUSUARIOS.iNRODOC
                    DateTimePicker1.Text = l_dtoUSUARIOS.iFECHA_NACIMIENTO
                    'DateTimePicker1.Value = CDate(dtoUSUARIOS.iFECHA_NACIMIENTO)
                    'datahelper
                    'ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_TipoUsuario, cmbciudad, l_dtoUSUARIOS.iIDTIPO_USUARIO_PERSONAL)

                    ModuUtil.BuscarItemCM(ds.Tables(7), cmbciudad, l_dtoUSUARIOS.iIDTIPO_USUARIO_PERSONAL)
                    txtLOGIN.Text = l_dtoUSUARIOS.iLOGIN
                    txtPASSWORD.Text = l_dtoUSUARIOS.iPASSWORD
                    txtE_MAIL.Text = l_dtoUSUARIOS.iE_MAIL
                    txtTELEFONO.Text = l_dtoUSUARIOS.iTELEFONO
                    txtCELULAR.Text = l_dtoUSUARIOS.iCELULAR
                    txtDIRECCION.Text = l_dtoUSUARIOS.iDIRECCION
                    'cboRol.SelectedItem = l_dtoUSUARIOS.RolDefecto
                    ModuUtil.LlenarCombo2(l_dtoUSUARIOS.dt_Rol_Usuario, cboRol, ModVOCONTROLUSUARIO.coll_Roles_Defecto, 1)
                    ModuUtil.BuscarItemCM(l_dtoUSUARIOS.dt_Rol_Usuario, cboRol, l_dtoUSUARIOS.RolDefecto)
                    'datahelper
                    'ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_Sexo, cmbSEXO, l_dtoUSUARIOS.iIDSEXO)
                    ModuUtil.BuscarItemCM(ds.Tables(2), cmbSEXO, l_dtoUSUARIOS.iIDSEXO)
                    If l_dtoUSUARIOS.iIDESTADO_REGISTRO = 1 Then
                        CheckActivo.Checked = True
                    Else
                        CheckActivo.Checked = False
                    End If

                    If l_dtoUSUARIOS.iIDOTRAS_AGENCIAS = 1 Then
                        chkOtrasAgencias.Checked = True
                    Else
                        chkOtrasAgencias.Checked = False
                    End If
                    '
                    If l_dtoUSUARIOS.iind_autoriza_entrega = 1 Then
                        Me.chk_entrega_sin_verificacion.Checked = True
                    Else
                        Me.chk_entrega_sin_verificacion.Checked = False
                    End If
                    '
                    'Int(coll_Distrito(cmbDISTRITO.SelectedIndex.ToString()))=dtoUSUARIOS.iIDDISTRITO 
                    'Int(coll_Provincia(cmbPROVINCIA.SelectedIndex.ToString()))=dtoUSUARIOS.iIDPROVINCIA 
                    'Int(coll_Departamento(cmbDEPARTAMENTO.SelectedIndex.ToString()))=dtoUSUARIOS.iIDDEPARTAMENTO 
                    'Int(coll_Pais(cmbPAIS.SelectedIndex.ToString()))=dtoUSUARIOS.iIDPAIS 

                    'dtoUSUARIOS.iFOTO = pathImage
                    'dtoUSUARIOS.iFOTO = dlgOpen.FileName
                    'datahelper
                    'ModuUtil.BuscarItemCM(ModVOCONTROLUSUARIO.rst_EstadoCivil, cmbESTADOCIVIL, l_dtoUSUARIOS.iIDESTADO_CIVIL)
                    ModuUtil.BuscarItemCM(ds.Tables(0), cmbESTADOCIVIL, l_dtoUSUARIOS.iIDESTADO_CIVIL)
                    'dtoUSUARIOS.iIDUBIGEO = 7895
                    txtFAX.Text = l_dtoUSUARIOS.iFAX
                    txtRPM.Text = l_dtoUSUARIOS.iRPM
                    txtPASSWORD.Text = l_dtoUSUARIOS.iPASSWORD
                    txtCONFPASSWORD.Text = l_dtoUSUARIOS.iPASSWORD
                    '
                    txtNroLicencia.Text = l_dtoUSUARIOS.snro_licencia


                    'dtoUSUARIOS.iBlobFoto = rst_usuario_Personal.Fields(2).Value
                    If IsNothing(l_dtoUSUARIOS.iBlobFoto) = False Then
                        PBImagen.Image = Image.FromStream(New MemoryStream(dtoUSUARIOS.iBlobFoto))
                    Else
                        PBImagen.Image = bmNoImagen
                    End If
                    'Cargando los datos del Item Roles
                    'dtrol.Clear()
                    'DataGridViewRoles.Rows().Remove(DataGridViewRoles.Rows().Item(0))
                    'datahelper
                    DataGridViewRoles.Rows.Clear()
                    CargarDataGrid(l_dtoUSUARIOS.dt_Rol_Usuario2, DataGridViewRoles, 2)
                    'darol.Fill(dtrol, dtoUSUARIOS.rst_Rol_Usuario)
                    'DataGridViewRoles.DataSource = dtrol.DefaultView
                    'DataGridViewRoles.Columns(0).Visible = False
                    DataGridViewRoles.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub txtBuscarDatos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarDatos.KeyUp
        Try
            Me.Cursor = Cursors.AppStarting
            Dim str As String = txtBuscarDatos.Text.ToString
            If Trim(str) = "" Then
                str = "%"
            End If
            'ErrorProviderControl.SetError(txtBuscarDatos, "")
            If e.KeyData.ToString() = Keys.Enter.ToString() Then
                DataGridViewUser.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                If IsNumeric(Trim(txtBuscarDatos.Text.ToString())) Then
                    dtoLista_Usuario.CONTROLFILTRO = 2
                    dtoLista_Usuario.FILTROBUSQUEDA = str
                    dtoLista_Usuario.GetFiltrodatos()
                    dt.Clear()
                    'datahelper
                    'rst = Nothing
                    'rst = dtoLista_Usuario.rst_List_User_Agencias
                    'da.Fill(dt, rst)
                    dt = dtoLista_Usuario.rst_List_User_Agencias
                    dv = dt.DefaultView
                    bformatImage = True
                    DataGridViewUser.DataSource = dv
                    bAgencias = True
                Else
                    dtoLista_Usuario.CONTROLFILTRO = 1
                    dtoLista_Usuario.FILTROBUSQUEDA = "%" & str & "%"
                    dtoLista_Usuario.GetFiltrodatos()
                    dt.Clear()
                    'datahelper
                    'rst = Nothing
                    'rst = dtoLista_Usuario.rst_List_User_Agencias
                    'da.Fill(dt, rst)
                    dt = dtoLista_Usuario.rst_List_User_Agencias
                    dv = dt.DefaultView
                    bformatImage = True
                    DataGridViewUser.DataSource = dv
                    bAgencias = True
                End If
            End If
            'Else
            'ErrorProviderControl.SetError(txtBuscarDatos, "Ingrese Patron de Busqueda(DNI,APEPAT,APEMAT,NOMPER")
            'MsgBox("Debe consistenciar Texto Vacio", MsgBoxStyle.Critical, "Seguridad Sistema")
            'End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub DataGridViewUser_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridViewUser.CellFormatting
        Dim strvar As String = ""
        Try
            strvar = e.RowIndex.ToString()
            If bformatImage = True Then
                If e.ColumnIndex = 0 Then
                    Dim IdEstado As Integer
                    If e.RowIndex >= 0 And DataGridViewUser.Rows().Count - 1 >= e.RowIndex Then
                        If IsDBNull(DataGridViewUser.Rows(e.RowIndex).Cells(7).Value) = False Then
                            IdEstado = DataGridViewUser.Rows(e.RowIndex).Cells(7).Value
                            DataGridViewUser.Rows(e.RowIndex).Cells(1).Tag = 1
                        Else
                            IdEstado = 0
                        End If
                        'IdEstado = IIf(IsNothing(DataGridViewUser.Rows(e.RowIndex).Cells(7).Value), 0, DataGridViewUser.Rows(e.RowIndex).Cells(7).Value)
                        Select Case IdEstado
                            Case 1
                                e.Value = bmActivo
                            Case 9
                                e.Value = bmEliminado
                            Case Else
                                e.Value = bmpNoImagen
                        End Select
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema" & strvar)
        End Try
    End Sub

    Private Sub DataGridViewUser_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridViewUser.KeyDown
        Try
            Dim var As Object = e.KeyValue
            Dim row As Integer = DataGridViewUser.SelectedRows.Item(0).Index
            'Dim col As Integer = DataGridViewUser.SelectedColumns.Item(0).Index
            If DataGridViewUser.Rows().Count - 1 = row Then
                Return
            End If
            If var = 93 Then
                MnuControlUsuario.Show(sender, posX, posY)
            End If
            If e.KeyCode = Keys.F1 Then
                Try
                    'Dim row As Integer = DataGridViewUser.SelectedRows.Item(0).Index
                    If DataGridViewUser.Rows().Count - 1 = row Then
                        MsgBox("Debe Elegir un Item Valido", MsgBoxStyle.Information, "Seguridad Sistema")
                        GroupDatos.Enabled = False
                        Return
                    End If
                    If row >= 0 Then
                        Call Load_Edicion()
                    End If

                Catch ex As Exception
                    MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema...")
                End Try
            End If
            If var = 40 Then
                If DataGridViewUser.Rows().Count - 1 = row Then
                    Return
                Else
                    DataGridViewUser.Rows(row).DataGridView(2, row).Style.BackColor = Color.Azure
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub mnuEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ControlEstadosUsuario(9)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    ' 08/11/2008 - 
    'Private Sub ControlEstadosUsuario(ByVal idEstado As Integer)
    '    Try
    '        Dim row As Integer = DataGridViewUser.SelectedRows.Item(0).Index
    '        If DataGridViewUser.Rows().Count - 1 = row Then
    '            MsgBox("Debe Elegir un Item Valido", MsgBoxStyle.Information, "Seguridad Sistema")
    '            Return
    '        Else
    '            If row >= 0 Then
    '                dtoUSUARIOS.iIDUSUARIO_PERSONAL = Int(DataGridViewUser.Rows(row).DataGridView(1, row).Value.ToString)
    '                dtoUSUARIOS.iIDAGENCIAS = Int(DataGridViewUser.Rows(row).DataGridView(2, row).Value.ToString)
    '                dtoUSUARIOS.iIDESTADO_REGISTRO = idEstado 'para eliminar el registro
    '                If dtoUSUARIOS.SetEliminar() = True Then
    '                    DataGridViewUser.Rows(row).DataGridView(7, row).Value = dtoUSUARIOS.iIDESTADO_REGISTRO
    '                    DataGridViewUser.UpdateCellValue(0, row)
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Seguridad Sistema")
    '    End Try
    'End Sub
    Private Sub cmbPAIS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPAIS.SelectedIndexChanged
        Try
            Dim idpais As Integer
            idpais = cmbPAIS.SelectedIndex
            If idpais >= 0 Then
                idpais = IIf(cmbPAIS.SelectedIndex.ToString() <> "", Int(ModVOCONTROLUSUARIO.coll_Pais(cmbPAIS.SelectedIndex.ToString())), 0)
                If ModuUtil.SP_CONTROL_UBIGEO(2, idpais) = True Then
                    'datahelper
                    'ModuUtil.LlenarComboIDs(ModuUtil.rst_cur_datos, cmbDEPARTAMENTO, ModVOCONTROLUSUARIO.coll_Departamento, Int(ModuUtil.rst_cur_datos.Fields.Item(0).Value))
                    ModuUtil.LlenarCombo2(ModuUtil.dt_rst_cur_datos, cmbDEPARTAMENTO, ModVOCONTROLUSUARIO.coll_Departamento, Int(ModuUtil.dt_rst_cur_datos.Rows(0).Item(0)))
                Else
                    NingunoComboIDs(cmbDEPARTAMENTO, ModVOCONTROLUSUARIO.coll_Departamento)
                    NingunoComboIDs(cmbPROVINCIA, ModVOCONTROLUSUARIO.coll_Provincia)
                    NingunoComboIDs(cmbDISTRITO, ModVOCONTROLUSUARIO.coll_Distrito)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub cmbDEPARTAMENTO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDEPARTAMENTO.SelectedIndexChanged
        Try
            Dim idDepartamento As Integer
            idDepartamento = cmbDEPARTAMENTO.SelectedIndex
            If idDepartamento >= 0 Then
                idDepartamento = IIf(cmbDEPARTAMENTO.SelectedIndex.ToString() <> "", Int(ModVOCONTROLUSUARIO.coll_Departamento(cmbDEPARTAMENTO.SelectedIndex.ToString())), 0)
                If ModuUtil.SP_CONTROL_UBIGEO(3, idDepartamento) = True Then
                    'datahelper
                    'ModuUtil.LlenarComboIDs(ModuUtil.rst_cur_datos, cmbPROVINCIA, ModVOCONTROLUSUARIO.coll_Provincia, Int(ModuUtil.rst_cur_datos.Fields.Item(0).Value))
                    ModuUtil.LlenarCombo2(ModuUtil.dt_rst_cur_datos, cmbPROVINCIA, ModVOCONTROLUSUARIO.coll_Provincia, Int(ModuUtil.dt_rst_cur_datos.Rows(0).Item(0)))
                Else
                    NingunoComboIDs(cmbPROVINCIA, ModVOCONTROLUSUARIO.coll_Provincia)
                    NingunoComboIDs(cmbDISTRITO, ModVOCONTROLUSUARIO.coll_Distrito)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub cmbPROVINCIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPROVINCIA.SelectedIndexChanged
        Try
            Dim idProvicnia As Integer
            idProvicnia = cmbPROVINCIA.SelectedIndex
            If idProvicnia >= 0 Then
                idProvicnia = IIf(cmbPROVINCIA.SelectedIndex.ToString() <> "", Int(ModVOCONTROLUSUARIO.coll_Provincia(cmbPROVINCIA.SelectedIndex.ToString())), 0)
                If ModuUtil.SP_CONTROL_UBIGEO(4, idProvicnia) = True Then
                    'datahelper
                    'ModuUtil.LlenarComboIDs(ModuUtil.rst_cur_datos, cmbDISTRITO, ModVOCONTROLUSUARIO.coll_Distrito, Int(ModuUtil.rst_cur_datos.Fields.Item(0).Value))
                    ModuUtil.LlenarCombo2(ModuUtil.dt_rst_cur_datos, cmbDISTRITO, ModVOCONTROLUSUARIO.coll_Distrito, Int(ModuUtil.dt_rst_cur_datos.Rows(0).Item(0)))
                Else
                    NingunoComboIDs(cmbDISTRITO, ModVOCONTROLUSUARIO.coll_Distrito)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub DataGridViewUser_CellToolTipTextNeeded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellToolTipTextNeededEventArgs) Handles DataGridViewUser.CellToolTipTextNeeded
        Try
            If e.ColumnIndex = 0 And e.RowIndex >= 0 Then
                Dim ide As New Object
                ide = DataGridViewUser.Rows(e.RowIndex).DataGridView(7, e.RowIndex).Value
                If IsNothing(ide) = False Or Len(DataGridViewUser.Rows(e.RowIndex).DataGridView(7, e.RowIndex).Value.ToString) > 0 Then
                    'Dim var As String = CargaTxtCmb(Me.cmbEstadoRegistro, ModVOESPECIESVALORADAS.IDEstadoRegistro, ide)
                    If ide = 1 Then
                        e.ToolTipText = "ACTIVO"
                    Else
                        If ide = 9 Then
                            e.ToolTipText = "INACTIVADO"
                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        '
        MyBase.Finalize()
        '
    End Sub

    Private Sub frmControlUsuarios_MenuSalir() Handles Me.MenuSalir

    End Sub
    Private Sub frmControlUsuarios_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        
    End Sub

    Private Sub DesactivarAgencia()
        Try
            Dim row As Integer = DataGridViewUser.SelectedRows.Item(0).Index
            If DataGridViewUser.Rows().Count - 1 = row Then
                MsgBox("Debe Elegir un Item Valido", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            Else
                If row >= 0 Then
                    l_dtoUSUARIOS.iIDUSUARIO_PERSONAL = Int(DataGridViewUser.Rows(row).DataGridView(1, row).Value.ToString)
                    l_dtoUSUARIOS.iIDAGENCIAS = l_dtoUSUARIOS.iIDAGENCIAS
                    If l_dtoUSUARIOS.DesactivarAgencia = True Then
                        'DataGridViewUser.Rows(row).DataGridView(7, row).Value = l_dtoUSUARIOS.iIDESTADO_REGISTRO
                        'DataGridViewUser.UpdateCellValue(0, row)

                        Dim obj As New dtoCONTROLUSUARIOS
                        dt = obj.LISTA_USUARIOS_AGENCIAS(l_dtoUSUARIOS.iIDAGENCIAS)
                        dv = dt.DefaultView
                        DataGridViewUser.DataSource = dv
                        DataGridViewUser.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                        bformatImage = True
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub mnuDesactivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDesactivar.Click
        Dim sUsuario As String = DataGridViewUser.SelectedRows.Item(0).Cells(4).Value
        Dim sAgencia As String = DataGridViewUser.SelectedRows.Item(0).Cells(3).Value
        If MessageBox.Show("¿Está seguro de desactivar al Usuario " & sUsuario & " de la Agencia " & sAgencia & "?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            DesactivarAgencia()
        End If
    End Sub

    Private Sub mnuActivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuActivar.Click
        Try
            Dim sCadena As String = IIf(mnuActivar.Text.Substring(0, 1) = "A", "Activar", "Desactivar")
            If MessageBox.Show("¿Está seguro de " & sCadena & " al Usuario?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                If sCadena.Substring(0, 1) = "A" Then
                    ControlEstadosUsuario(1)
                Else
                    ControlEstadosUsuario(9)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub DataGridViewUser_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridViewUser.MouseDown
        '13-01-2010 hlamas
        Try
            Dim row As Integer = DataGridViewUser.SelectedRows.Item(0).Index
            If DataGridViewUser.Rows().Count - 1 = row Then
                Return
            End If

            If row >= 0 Then
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    'MnuControlUsuario.Show(sender, e.X, e.Y)
                    'grdAsegurado.SelectedRows.Item(0).Index
                    'Dim a As String = CType(sender, DataGridView).SelectedRows.Item(0).Index.ToString
                    Dim iEstado As Byte = DataGridViewUser.SelectedRows.Item(0).Cells(7).Value
                    'If l_dtoUSUARIOS.iIDAGENCIAS > 0 Then
                    If bAgencias = False Then
                        mnuAgencia.Show(sender, e.X, e.Y)
                    Else
                        Dim iEst As Byte = CType(sender, DataGridView).SelectedRows.Item(0).Cells(7).Value
                        If iEst = 1 Then
                            mnuActivar.Text = "Desactivar Usuario"
                        Else
                            mnuActivar.Text = "Activar Usuario"
                        End If
                        MnuControlUsuario.Show(sender, e.X, e.Y)
                    End If
                End If
            End If

        Catch ex As Exception
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub ControlEstadosUsuario(ByVal idEstado As Integer)
        Try
            Dim row As Integer = DataGridViewUser.SelectedRows.Item(0).Index
            If DataGridViewUser.Rows().Count - 1 = row Then
                MsgBox("Debe Elegir un Item Valido", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            Else
                If row >= 0 Then
                    l_dtoUSUARIOS.iIDUSUARIO_PERSONAL = Int(DataGridViewUser.Rows(row).DataGridView(1, row).Value.ToString)
                    l_dtoUSUARIOS.iIDAGENCIAS = Int(DataGridViewUser.Rows(row).DataGridView(2, row).Value.ToString)
                    l_dtoUSUARIOS.iIDESTADO_REGISTRO = idEstado 'para eliminar el registro
                    If l_dtoUSUARIOS.SetEliminar() = True Then
                        MenuStrip1.Items(4).Enabled = IIf(idEstado = 9, True, False)
                        DataGridViewUser.Rows(row).DataGridView(7, row).Value = l_dtoUSUARIOS.iIDESTADO_REGISTRO
                        DataGridViewUser.UpdateCellValue(0, row)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub frmControlUsuarios_MenuGrabar() Handles Me.MenuGrabar
        Try
            If LTrim(txtAPEMATERNO.Text) <> "" Then
                Me.ErrorProviderControl.SetError(Me.txtAPEMATERNO, "")
            Else
                Me.ErrorProviderControl.SetError(Me.txtAPEMATERNO, "Ingrese Apellido Materno")
            End If

            If LTrim(txtAPEPATERNO.Text) <> "" Then
                Me.ErrorProviderControl.SetError(Me.txtAPEPATERNO, "")
            Else
                Me.ErrorProviderControl.SetError(Me.txtAPEPATERNO, "Ingrese Apellido Paterno")
            End If

            If LTrim(Me.txtNOMBRES.Text) <> "" Then
                Me.ErrorProviderControl.SetError(Me.txtNOMBRES, "")
            Else
                Me.ErrorProviderControl.SetError(Me.txtNOMBRES, "Ingrese Sus Nombres")
            End If

            If LTrim(Me.txtLOGIN.Text) <> "" Then
                Me.ErrorProviderControl.SetError(Me.txtLOGIN, "")
            Else
                Me.ErrorProviderControl.SetError(Me.txtLOGIN, "Ingrese su Login de Usuario")
            End If

            If LTrim(Me.txtPASSWORD.Text) <> "" Then
                Me.ErrorProviderControl.SetError(Me.txtPASSWORD, "")
            Else
                Me.ErrorProviderControl.SetError(Me.txtPASSWORD, "Ingrese Pasword")
            End If
            If LTrim(Me.txtCONFPASSWORD.Text) <> "" Then
                Me.ErrorProviderControl.SetError(Me.txtCONFPASSWORD, "")
            Else
                Me.ErrorProviderControl.SetError(Me.txtCONFPASSWORD, "Ingrese Confirmacion de su Pasword")
            End If

            l_dtoUSUARIOS.iCONTROL = varControl
            l_dtoUSUARIOS.iIDTURNOS_AGENCIA = 1
            'dtoUSUARIOS.iIDAGENCIAS = 1
            If l_dtoUSUARIOS.iIDUSUARIO_PERSONAL < 0 Then
                l_dtoUSUARIOS.iIDUSUARIO_PERSONAL = 0
            End If

            l_dtoUSUARIOS.iLOGIN = 2
            'iIP in T_AGENCIA_USUARIOS.IP%type,                      
            'Public iIDROL_USUARIO As Integer
            l_dtoUSUARIOS.iNOMPER = IIf(Me.txtNOMBRES.Text <> "", Me.txtNOMBRES.Text, "NULL")
            l_dtoUSUARIOS.iAPEMAT = IIf(Me.txtAPEMATERNO.Text <> "", txtAPEMATERNO.Text, "NULL")
            l_dtoUSUARIOS.iAPEPAT = IIf(Me.txtAPEPATERNO.Text.ToString() <> "", txtAPEPATERNO.Text, "NULL")

            l_dtoUSUARIOS.iIDTIPO_DOC_IDENTIDAD = Int(coll_TipoDocIndentiadad(cmbTIPODOC.SelectedIndex.ToString()))
            'Int(IDcmbRol(Me.cmbRol.SelectedIndex.ToString()))
            l_dtoUSUARIOS.iNRODOC = IIf(Me.txtNRODOC.Text.ToString() <> "", txtNRODOC.Text, "NULL")
            'dtoUSUARIOS.iFECHA_NACIMIENTO = Format("##/##/####", txtFechaNacimiento.Text.ToString())
            l_dtoUSUARIOS.iFECHA_NACIMIENTO = Format("##/##/####", DateTimePicker1.Text.ToString())
            l_dtoUSUARIOS.iIDTIPO_USUARIO_PERSONAL = Int(coll_TipoUsuario(cmbciudad.SelectedIndex.ToString()))
            l_dtoUSUARIOS.iLOGIN = IIf(Me.txtLOGIN.Text.ToString() <> "", txtLOGIN.Text, "NULL")
            l_dtoUSUARIOS.iPASSWORD = IIf(Me.txtPASSWORD.Text.ToString() <> "", txtPASSWORD.Text, "NULL")
            l_dtoUSUARIOS.iE_MAIL = IIf(Me.txtE_MAIL.Text.ToString() <> "", txtE_MAIL.Text, "NULL")
            l_dtoUSUARIOS.iTELEFONO = IIf(Me.txtTELEFONO.Text.ToString() <> "", txtTELEFONO.Text, "NULL")
            l_dtoUSUARIOS.iCELULAR = IIf(Me.txtCELULAR.Text.ToString() <> "", txtCELULAR.Text, "NULL")
            l_dtoUSUARIOS.iDIRECCION = IIf(Me.txtDIRECCION.Text.ToString() <> "", txtDIRECCION.Text, "NULL")
            l_dtoUSUARIOS.iIDUSUARIO_CREADOR = dtoUSUARIOS.IdLogin
            l_dtoUSUARIOS.iIDAREA_SISTEMA = 1
            l_dtoUSUARIOS.iIDROL_CREADOR = dtoUSUARIOS.IdRol
            l_dtoUSUARIOS.iIDSEXO = Int(coll_Sexo(cmbSEXO.SelectedIndex.ToString()))
            If CheckActivo.Checked = True Then
                l_dtoUSUARIOS.iIDESTADO_REGISTRO = 1
            Else
                l_dtoUSUARIOS.iIDESTADO_REGISTRO = 9 ' Estado de Registro inactivo
            End If
            '02/11/2008 
            l_dtoUSUARIOS.iIDOTRAS_AGENCIAS = IIf(chkOtrasAgencias.Checked, 1, 0)
            l_dtoUSUARIOS.iind_autoriza_entrega = IIf(Me.chk_entrega_sin_verificacion.Checked, 1, 0)
            '
            l_dtoUSUARIOS.iIDDISTRITO = IIf(cmbDISTRITO.SelectedIndex.ToString() <> "", Int(ModVOCONTROLUSUARIO.coll_Distrito(cmbDISTRITO.SelectedIndex.ToString())), -666)
            l_dtoUSUARIOS.iIDPROVINCIA = IIf(cmbPROVINCIA.SelectedIndex.ToString() <> "", Int(ModVOCONTROLUSUARIO.coll_Provincia(cmbPROVINCIA.SelectedIndex.ToString())), -666)
            l_dtoUSUARIOS.iIDDEPARTAMENTO = IIf(cmbDEPARTAMENTO.SelectedIndex.ToString() <> "", Int(ModVOCONTROLUSUARIO.coll_Departamento(cmbDEPARTAMENTO.SelectedIndex.ToString())), -666)
            l_dtoUSUARIOS.iIDPAIS = IIf(cmbPAIS.SelectedIndex.ToString() <> "", Int(ModVOCONTROLUSUARIO.coll_Pais(cmbPAIS.SelectedIndex.ToString())), -666)
            'dtoUSUARIOS.iFOTO = pathImage
            '
            l_dtoUSUARIOS.iFOTO = IIf(dlgOpen.FileName <> "OpenFileDialog", dlgOpen.FileName, "NULL")
            l_dtoUSUARIOS.iIDESTADO_CIVIL = IIf(cmbESTADOCIVIL.SelectedIndex.ToString() <> "", Int(coll_EstadoCivil(cmbESTADOCIVIL.SelectedIndex.ToString())), -666)
            l_dtoUSUARIOS.iIDUBIGEO = 7895    ' Esta fijo Tepsa 
            l_dtoUSUARIOS.iFAX = IIf(txtFAX.Text.ToString() <> "", txtFAX.Text.ToString(), "NULL")
            l_dtoUSUARIOS.iRPM = IIf(txtRPM.Text.ToString() <> "", txtRPM.Text.ToString(), "NULL")
            l_dtoUSUARIOS.m_sPassword = IIf(dtoUSUARIOS.iPASSWORD <> "", dtoUSUARIOS.iPASSWORD, "NULL")
            '
            l_dtoUSUARIOS.snro_licencia = IIf(txtNroLicencia.Text = "", 0, txtNroLicencia.Text)  ' Ingresado por Tepsa 22/11/2006
            l_dtoUSUARIOS.RolDefecto = IIf(cboRol.SelectedIndex > 0, Int(ModVOCONTROLUSUARIO.coll_Roles_Defecto(cboRol.SelectedIndex.ToString())), -666)
            '
            If l_dtoUSUARIOS.iPASSWORD = Me.txtCONFPASSWORD.Text.ToString() Then
                'rst = Nothing
                If txtE_MAIL.Text.ToString() = "" Then
                    Dim i As Integer
                    l_dtoUSUARIOS.idListRoles = ""
                    For i = 0 To DataGridViewRoles.Rows().Count - 1
                        If i = DataGridViewRoles.Rows().Count - 1 Then
                            l_dtoUSUARIOS.idListRoles = l_dtoUSUARIOS.idListRoles & DataGridViewRoles.Rows().Item(i).DataGridView(0, i).Value.ToString()
                        Else
                            l_dtoUSUARIOS.idListRoles = l_dtoUSUARIOS.idListRoles & DataGridViewRoles.Rows().Item(i).DataGridView(0, i).Value.ToString() & ","
                        End If
                    Next i
                    If l_dtoUSUARIOS.idListRoles <> "" Then
                        If l_dtoUSUARIOS.Grabar() = False Then
                            Return
                        End If
                        bformatImage = True
                        If Me.DataGridViewUser.Rows.Count > 1 Then
                            Dim row As Integer = DataGridViewUser.SelectedRows.Item(0).Index
                            DataGridViewUser.Rows(row).DataGridView(7, row).Value = l_dtoUSUARIOS.iIDESTADO_REGISTRO
                            DataGridViewUser.UpdateCellValue(0, row)
                        End If
                        MenuStrip1.Items(4).Enabled = IIf(l_dtoUSUARIOS.iIDESTADO_REGISTRO = 9, True, False)

                        If bAgencias = False Then
                            MenuStrip1.Items(4).Enabled = False
                        End If

                        SplitContainer2.Panel1Collapsed = False
                        SelectMenu(0)
                        Tab_Control3(MenuTab, 1)
                    Else
                        MsgBox("Debe Seleccionar el Item para la Carga de Roles a Usuarios", MsgBoxStyle.Exclamation, "Seguridad Sistema")
                    End If
                Else
                    If ValiadarEXP_REG_Mail(txtE_MAIL.Text) Then
                        If DataGridViewRoles.Rows().Count > 0 Then
                            Dim i As Integer
                            l_dtoUSUARIOS.idListRoles = ""
                            For i = 0 To DataGridViewRoles.Rows().Count - 1
                                If i = DataGridViewRoles.Rows().Count - 1 Then
                                    l_dtoUSUARIOS.idListRoles = l_dtoUSUARIOS.idListRoles & DataGridViewRoles.Rows().Item(i).DataGridView(0, i).Value.ToString()
                                Else
                                    l_dtoUSUARIOS.idListRoles = l_dtoUSUARIOS.idListRoles & DataGridViewRoles.Rows().Item(i).DataGridView(0, i).Value.ToString() & ","
                                End If
                            Next i
                            'End If


                            If l_dtoUSUARIOS.Grabar() = False Then
                                Return
                            End If
                            bformatImage = True
                            Dim row As Integer = DataGridViewUser.SelectedRows.Item(row).Index
                            DataGridViewUser.Rows(0).DataGridView(7, row).Value = l_dtoUSUARIOS.iIDESTADO_REGISTRO
                            DataGridViewUser.UpdateCellValue(0, row)
                            MenuStrip1.Items(4).Enabled = IIf(l_dtoUSUARIOS.iIDESTADO_REGISTRO = 9, True, False)
                            If bAgencias = False Then
                                MenuStrip1.Items(4).Enabled = False
                            End If

                            If varControl = 1 Then 'Caso de Insertcion
                                Dim row0 As String() = {dtoLista_Usuario.iIDUSUARIO_PERSONAL, dtoLista_Usuario.iIDAGENCIAS, dtoLista_Usuario.iNOMBRE_AGENCIA, dtoLista_Usuario.iNombres, dtoLista_Usuario.iE_MAIL, dtoLista_Usuario.iCOMUNICACION, dtoLista_Usuario.iIDESTADO_REGISTRO}
                                DataGridViewRoles.Rows().Add(row0)
                            Else  ' 'Caso de Modificacion

                            End If
                            Tab_Control3(MenuTab, 1)
                            SplitContainer2.Panel1Collapsed = False
                            SelectMenu(0)

                        Else
                            MsgBox("No puede Registrar al usuario. No tiene Asociado ningún Rol", MsgBoxStyle.Critical, "Seguridad Sistema")
                        End If

                    Else
                        MsgBox("El Email no es válido.", MsgBoxStyle.Critical, "Seguridad Sistema")
                    End If
                End If
            Else
                MsgBox("Su password no está bien escrito", MsgBoxStyle.Critical, "Seguridad Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub TreeLista_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeLista.AfterSelect
        Try
            MenuStrip1.Items(4).Enabled = False
            Me.Cursor = Cursors.AppStarting
            l_dtoUSUARIOS.iIDAGENCIAS = e.Node().Tag
            If e.Node().Tag > 0 Then
                bAgencias = False
            Else
                bAgencias = True
            End If
            lbAgencias.Text = e.Node().Text.ToString()

            '16-01-2010 hlamas
            'txtAgencia.Text = e.Node().Text.ToString()

            If l_dtoUSUARIOS.iIDAGENCIAS > 0 Then
                'datahelper
                'dt.Clear()
                'rst = Nothing
                'rst = VOCONTROLUSUARIO.ListaUsuariosAgencias(e.Node().Tag, 1)
                'da.Fill(dt, rst)

                Dim obj As New dtoCONTROLUSUARIOS
                dt = obj.LISTA_USUARIOS_AGENCIAS(e.Node().Tag)
                dv = dt.DefaultView
                DataGridViewUser.DataSource = dv
                DataGridViewUser.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                bformatImage = True
            Else
                Dim obj As New dtoCONTROLUSUARIOS
                dt = obj.LISTA_USUARIOS_AGENCIAS_TODO()
                dv = dt.DefaultView
                DataGridViewUser.DataSource = dv
                DataGridViewUser.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                bformatImage = True
                'bformatImage = False
            End If

            Dim row As Integer = 0
            If row >= 0 Then
                Dim iEstado As Integer = DataGridViewUser.Rows(row).DataGridView(7, row).Value
                MenuStrip1.Items(4).Enabled = IIf(iEstado = 9, True, False)
            End If

            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub DataGridViewUser_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewUser.CellClick
        If bAgencias = False Then
            MenuStrip1.Items(4).Enabled = False
            Return
        End If

        Dim row As Integer = DataGridViewUser.SelectedRows.Item(0).Index
        If DataGridViewUser.Rows().Count - 1 = row Then
            Return
        End If
        If row >= 0 Then
            Dim iEstado As Integer = DataGridViewUser.Rows(row).DataGridView(7, row).Value
            MenuStrip1.Items(4).Enabled = IIf(iEstado = 9, True, False)
        End If
    End Sub
    Private Sub frmControlUsuarios_MenuEliminar() Handles Me.MenuEliminar
        Dim sUsuario As String = DataGridViewUser.SelectedRows.Item(0).Cells(4).Value
        If MessageBox.Show("¿Está seguro de eliminar al Usuario " & sUsuario & "?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            EliminarUsuario()
        End If
    End Sub
    Private Sub EliminarUsuario()
        Try
            Dim row As Integer = DataGridViewUser.SelectedRows.Item(0).Index
            If DataGridViewUser.Rows().Count - 1 = row Then
                MsgBox("Debe Elegir un Item Valido", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            Else
                If row >= 0 Then
                    l_dtoUSUARIOS.iIDUSUARIO_PERSONAL = Int(DataGridViewUser.Rows(row).DataGridView(1, row).Value.ToString)

                    DataGridViewUser.DataSource = l_dtoUSUARIOS.EliminarUsuario()
                    DataGridViewUser.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                    bformatImage = True
                    'DataGridViewUser.Rows(row).DataGridView(7, row).Value = l_dtoUSUARIOS.iIDESTADO_REGISTRO
                    'DataGridViewUser.UpdateCellValue(0, row)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Seguridad Sistema")
        End Try
    End Sub

    Sub ConfiguraGridRoles()
        With DataGridViewRoles
            .AllowUserToAddRows = False
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(0).HeaderText = "Nº ROL"
            .Columns(1).HeaderText = "ROL"
        End With
    End Sub

    Private Sub btnFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltro.Click
        Try
            Dim vfrm As New frmFiltroRoles()
            'vfrm.ShowDialog()

            Acceso.Asignar(vfrm, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                If DataGridViewUser.Rows.Count > 1 Then
                    vfrm.usuario = DataGridViewUser.CurrentRow.Cells(1).Value
                Else
                    vfrm.usuario = -1
                End If
                vfrm.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

                Dim item As Integer
                item = 0
                If ListRoles.Count > 0 Then
                    l_dtoUSUARIOS.idListRoles = ""
                    For Each thisObject As dtoCONTROLUSUARIOS In ListRoles
                        If Not Existe(thisObject.IdRol) Then
                            item = item + 1
                            Dim row0 As String() = {thisObject.IdRol.ToString(), thisObject.Rol.ToString()}
                            If item = ListRoles.Count Then
                                l_dtoUSUARIOS.idListRoles = l_dtoUSUARIOS.idListRoles & thisObject.IdRol.ToString()
                            Else
                                l_dtoUSUARIOS.idListRoles = l_dtoUSUARIOS.idListRoles & thisObject.IdRol.ToString() & ","
                            End If
                            DataGridViewRoles.Rows().Add(row0)
                        End If
                    Next thisObject
                End If
                'DataGridViewRoles.Columns(0).ReadOnly = True
                'DataGridViewRoles.Columns(1).ReadOnly = True
                'DataGridViewRoles.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                'DataGridViewRoles.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DataGridViewRoles.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")


        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema...")
        End Try
    End Sub

    Function Existe(ByVal rol As Integer) As Boolean
        For Each row As DataGridViewRow In DataGridViewRoles.Rows
            If row.Cells(0).Value = rol Then
                Return True
            End If
        Next
        Return False
    End Function

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs)
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class