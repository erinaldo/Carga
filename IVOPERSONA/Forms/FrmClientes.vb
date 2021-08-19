'Imports System.Data
'Imports System.Data.OleDb
'Imports AccesoDatos
Public Class FrmClientes
    Dim vAccionRegistro As Integer
    Dim bClienteActualizado As Boolean
    Dim sCliente As String
    Dim sDocumento As String
    Dim iId As String
    Dim sAccion As String
    Dim bMontoBase As Boolean
    Dim iDescuento As Double
    Public Shared bActualizado As Boolean
    Dim iLinea As Integer
    Dim b_cancelo As Boolean = False
    Dim bIngreso As Boolean = False
    Public Hnd As Integer

    Dim iCliente As Integer
    'Dim sCliente2 As String
    Dim sCodigo As String
    Dim sRepresentanteLegal As String

    Dim dtSolicitud As DataTable
    Dim iOpcion As Integer
    Dim bInicio As Boolean


#Region " DECLARACION VARIABLES "
    'Para el Ingreso de Solo Numeros
    Public KeyAscii As Short
    'Declaracion de Data Adapters
    'Private DataAdapterGenerics As New OleDbDataAdapter
    'Declaracion de DataTables
    Private dtTipoPersona As New System.Data.DataTable
    Private dtTipoDocPersona As New System.Data.DataTable
    Private dtTipoDocPersona2 As New System.Data.DataTable
    Private dtRubro As New System.Data.DataTable
    Private dtClasPersona As New System.Data.DataTable
    Private dtPaisCombo As New System.Data.DataTable
    Private dtDepartamentoCombo As New System.Data.DataTable
    Private dtProvinciaCombo As New System.Data.DataTable
    Private dtDistritoCombo As New System.Data.DataTable
    Private dtTipoContacto As New System.Data.DataTable
    Private dtAreaEmpresa As New System.Data.DataTable
    Private dtContacto As New System.Data.DataTable("DETALLE")
    Private dtContactos As New System.Data.DataTable
    Private dtDirecciones As New System.Data.DataTable("DETALLE")
    Private dtTelefonos As New System.Data.DataTable("TELEFONOS")
    Private dtTipoComunicacion As New System.Data.DataTable
    Private dtComunicacionContac As New System.Data.DataTable
    Private dtRoles As New System.Data.DataTable
    Private dtUsuarioRoles As New System.Data.DataTable
    Private dtListaPersona As New System.Data.DataTable
    Private dtTipoDireccion As New System.Data.DataTable
    Private dtTipoFacturacion As New System.Data.DataTable

    Private dsContacto As New DataSet
    Private dsDirecciones As New DataSet
    Private dsTelefonos As New DataSet

    'Declaramos el DataRow
    Dim drwContactos As DataRow
    Dim drwDirecciones As DataRow

    'Declaracion de DataViews
    Dim dvTipoPersona As DataView
    Dim dvTipoDocPersona As DataView
    Dim dvTipoDocPersona2 As DataView
    Dim dvRubro As DataView
    Dim dvClasPersona As DataView
    Dim dvAreaEmpresa As DataView
    Dim dvPais As DataView
    Dim dvDepartamento As DataView
    Dim dvProvincia As DataView
    Dim dvDistrito As DataView
    Dim dvTipoContacto As DataView
    Dim dvTipoComunicacion As DataView
    Dim dvComunicacionContac As DataView
    Dim dvRoles As DataView
    Dim dvUsuarioRoles As DataView
    Dim dvListaPersona As DataView
    Dim dvTipoDireccion As DataView
    Dim dvTipoFacturacion As DataView

    'Declaracion de Recordset
    'Dim rstTipoPersona As ADODB.Recordset = Nothing
    'Dim rstTipoDocto As ADODB.Recordset = Nothing
    'Dim rstRubro As ADODB.Recordset = Nothing
    'Dim rstClasPersona As ADODB.Recordset = Nothing
    'Dim rstPaisCombo As ADODB.Recordset = Nothing
    'Dim rstDepartamentoCombo As ADODB.Recordset = Nothing
    'Dim rstProvinciaCombo As ADODB.Recordset = Nothing
    'Dim rstDistritoCombo As ADODB.Recordset = Nothing
    'Dim rstTipoContactoCombo As ADODB.Recordset = Nothing
    'Dim rstAreaEmpresaCombo As ADODB.Recordset = Nothing
    'Dim rstTipoComunicacion As ADODB.Recordset = Nothing
    'Dim rstComunicacionContac As ADODB.Recordset = Nothing
    'Dim rstRoles As ADODB.Recordset = Nothing
    'Dim rstUsuarioRoles As ADODB.Recordset = Nothing
    'Dim rstListaPersona As ADODB.Recordset = Nothing
    'Dim rstIDPersona As ADODB.Recordset = Nothing
    'Dim respOracle As ADODB.Recordset
    'Dim respAsocia As ADODB.Recordset
    'Dim rstTipoDireccion As ADODB.Recordset = Nothing

    'Controlador para control de Enter en Formularios
    Dim EsBoton As Boolean
    Dim vIDPersona As Long 'Integer

    'Para Direcciones del CLiente.
    Dim dtPaisDireciones As New System.Data.DataTable
    Dim dtDepartDirecciones As New System.Data.DataTable
    Dim dtProvDirecciones As New System.Data.DataTable
    Dim dtDistDirecciones As New System.Data.DataTable
    Dim dvPaisDireciones As DataView
    Dim dvDepartDirecciones As DataView
    Dim dvProvDirecciones As DataView
    Dim dvDistDirecciones As DataView

    'Codigos de los Funcionarios
    Dim CodFuncionarioNegocio As Integer
    Dim TipoFuncionarioNegocio As Integer

    'Para Grilla de Ingreso de Telefonos.
    Dim dtGrillaTelefonos As New DataTable
    Dim dtComboGrilla As New DataTable
    Dim dtDireccionesCliente As New DataTable

    'Estados de Inserciones dentro del formulario.
    Dim Paso1 As Integer
    Dim Paso2 As Integer
    Dim Paso3 As Integer
    ' Guardando el ùltimo valor 
    Dim iidtipo_facturacion As Integer = 0
    '    Dim lb_editar As Boolean = False        ' Verificar si se a modificado  TEMPORALMENTE
    Dim lb_principal As Boolean = False     ' Donde ingresa 
#End Region

#Region " FUNCIONES A NIVEL DEL FORMULARIO "

    ''' <summary>
    ''' Devuelve un DataTable a partir de un Objeto Oracle de ADOServer.
    ''' </summary>
    ''' <param name="ObjOracle"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    ''' <summary>
    ''' Agrega la dirección ingresada al cliente directamente a Oracle.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AgregaDireccion(ByVal AccionDireccion As Integer)

        Dim DireccionesClass As New dtoDIRECCIONES_CLIENTE
        With DireccionesClass
            .Control = AccionDireccion ' vAccionRegistro '1
            .IDDireccion = Me.lblIDDireccion.Text '1 'Momentaneamente porque para actualizacion cambiaremos
            .IDTipoDireccion = Me.cmbTipoDireccion.SelectedValue
            .CodigoPersona = MyCodigoCliente
            .Direccion = Me.txtDireccion.Text
            .Referencia = IIf(Len(Trim(Me.txtReferencia.Text)) = 0, "Ninguna...", Me.txtReferencia.Text)
            .CodigoUbicGeografica = Me.txtCodigoUbigeo.Text
            If chkDireccionFacturacion.Checked = True Then
                .DireccionFacturacion = 1
            Else
                .DireccionFacturacion = 0
            End If
            .CodigoUbigeio = Me.txtCodigoUbigeo.Text
            .HoraRecojoIni = Me.dtpHoraRecojoInicio.Text
            .HoraRecojoFin = Me.dtpHoraRecojoFinal.Text
            .HoraEntregaIni = Me.dtpHoraEntregaInicio.Text
            .HoraEntregaFin = Me.dtpHoraEntregaFinal.Text
            .UsuarioPersonal = MyUsuario ' 6
            .RolUsuario = MyRol '2
            .IP = MyIP ' "192.168.50.47"
            .Pais = Me.cmbPaisDirecciones.SelectedValue '4
            .Departamento = Me.cmbDepartamentoDirecciones.SelectedValue '15
            .Provincia = Me.cmbProvinciaDirecciones.SelectedValue '17
            .Distrito = Me.cmbDistritoDirecciones.SelectedValue '18
        End With
        'datahelper
        'Dim respDirecciones As ADODB.Recordset
        'respDirecciones = DireccionesClass.GrabaDireccion()
        Dim respDirecciones As DataTable = DireccionesClass.GrabaDireccion()
        If respDirecciones.Rows.Count = 1 Then 'Se realizo Correctamente.
            MessageBox.Show(respDirecciones.Rows(0).Item(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            For i As Integer = 0 To Me.dgvContactosDirecciones.RowCount - 1
                If Not dgvContactosDirecciones.Rows(i).Cells(0).Value Is Nothing Then
                    DireccionesClass._SIDContacto = CType(dgvContactosDirecciones.Rows(i).Cells("IDCONTACTO_PERSONA").Value, String)
                    DireccionesClass._IDCentroCosto = dgvContactosDirecciones.Rows(i).Cells("IDTIPO_CONTACTO").Value
                    DireccionesClass._IDDireccionConsignado = lblIDDireccion.Text
                    DireccionesClass._Seleccionado = IIf(IsDBNull(dgvContactosDirecciones.Rows(i).Cells("SELECCIONAR").Value), 0, dgvContactosDirecciones.Rows(i).Cells("SELECCIONAR").Value)

                    'datahelper
                    'Dim respTripode As ADODB.Recordset
                    'respTripode = DireccionesClass.AsociaTripode()
                    Dim respTripode As DataTable = DireccionesClass.AsociaTripode()
                    If respTripode.Rows.Count = 1 Then 'Se realizo Correctamente.
                        Paso3 = 1
                        MenuStrip1.Items(2).Text = "&Volver"
                    ElseIf respTripode.Rows.Count = 2 And Len(Trim(respTripode.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                        MessageBox.Show("Descripción: " & respTripode.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respTripode.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    'If respTripode.Fields.Count = 1 Then 'Se realizo Correctamente.
                    '    Paso3 = 1
                    '    MenuStrip1.Items(2).Text = "&Volver"
                    'ElseIf respTripode.Fields.Count = 2 And Len(Trim(respTripode.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                    '    MessageBox.Show("Descripción: " & respTripode.Fields(1).Value, "ORACLE -> Error: " & respTripode.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'End If
                End If
            Next

        ElseIf respDirecciones.Rows.Count = 2 And Len(Trim(respDirecciones.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
            MessageBox.Show("Descripción: " & respDirecciones.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respDirecciones.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        'datahelper
        'If respDirecciones.Fields.Count = 1 Then 'Se realizo Correctamente.
        '    MessageBox.Show(respDirecciones.Fields(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    For i As Integer = 0 To Me.dgvContactosDirecciones.RowCount - 1
        '        If Not dgvContactosDirecciones.Rows(i).Cells(0).Value Is Nothing Then
        '            DireccionesClass._SIDContacto = CType(dgvContactosDirecciones.Rows(i).Cells("IDCONTACTO_PERSONA").Value, String)
        '            DireccionesClass._IDCentroCosto = dgvContactosDirecciones.Rows(i).Cells("IDTIPO_CONTACTO").Value
        '            DireccionesClass._IDDireccionConsignado = lblIDDireccion.Text
        '            DireccionesClass._Seleccionado = IIf(IsDBNull(dgvContactosDirecciones.Rows(i).Cells("SELECCIONAR").Value), 0, dgvContactosDirecciones.Rows(i).Cells("SELECCIONAR").Value)

        '            Dim respTripode As ADODB.Recordset
        '            respTripode = DireccionesClass.AsociaTripode()
        '            If respTripode.Fields.Count = 1 Then 'Se realizo Correctamente.
        '                Paso3 = 1
        '                MenuStrip1.Items(2).Text = "&Volver"
        '            ElseIf respTripode.Fields.Count = 2 And Len(Trim(respTripode.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
        '                MessageBox.Show("Descripción: " & respTripode.Fields(1).Value, "ORACLE -> Error: " & respTripode.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            End If
        '        End If
        '    Next

        'ElseIf respDirecciones.Fields.Count = 2 And Len(Trim(respDirecciones.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
        '    MessageBox.Show("Descripción: " & respDirecciones.Fields(1).Value, "ORACLE -> Error: " & respDirecciones.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If

    End Sub

    ''' <summary>
    ''' Crea la Grilla donde se plasmaran las Direcciones Ingresadas.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GeneraDireccion()
        Try
            dtDirecciones = dsDirecciones.Tables.Add
            With dtDirecciones
                .Columns.Add("ORDEN", Type.GetType("System.Int16"))
                .Columns.Add("¿ACTIVO?", Type.GetType("System.Boolean"))
                .Columns.Add("TIPO DIRECCION", Type.GetType("System.String"))
                .Columns.Add("DIRECCION", Type.GetType("System.String"))
                .Columns.Add("FACTURACION", Type.GetType("System.Boolean"))
                .Columns.Add("CONTACTO", Type.GetType("System.String"))
                .Columns.Add("PAIS", Type.GetType("System.String"))
                .Columns.Add("DEPARTAMENTO", Type.GetType("System.String"))
                .Columns.Add("PROVINCIA", Type.GetType("System.String"))
                .Columns.Add("DISTRITO", Type.GetType("System.String"))
            End With
            With dsDirecciones.Tables(0)
                '.PrimaryKey = New DataColumn() {.Columns("CONTACTO")}
            End With
            dgvDirecciones.DataSource = dtDirecciones.DefaultView
            With dgvDirecciones
                '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = True
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .DataSource = dtDirecciones.DefaultView
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .Font = New System.Drawing.Font("Arial", 8.0!, FontStyle.Regular)
                .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                .VirtualMode = True
                .RowHeadersVisible = False
            End With

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Agrega Telefonos de Contacto a directamente a Oracle.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AgregarTelefonosContacto(ByVal ActualizaTelefono As Integer)

        '''''''''VALIDACIONES''''''''''''
        'For i As Integer = 0 To Me.dgvTelefonosContacto.RowCount - 1
        '    If Not Me.dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value Is Nothing And Not Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value Is Nothing Then
        '        If Me.dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value.ToString.Trim <> "" And Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value.ToString.Trim <> "" Then
        '            MessageBox.Show(i & "  " & Me.dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value & "   " & Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value)
        '        Else
        '            MessageBox.Show("NOOOOOOOOOOO Guarda TipoComunicacion y Numero")
        '        End If
        '    Else
        '        MessageBox.Show("NOOOOOOOOOOO Guarda TipoComunicacion y Numero")
        '    End If
        'Next
        '''''''''''''''''''''''''''''''''

        Try
            'If vAccionRegistro = 1 Then
            If ActualizaTelefono = 1 Then
                Dim ContadorInsercionTelefeonos As Integer = 0
                For i As Integer = 0 To dgvTelefonosContacto.Rows.Count - 1
                    'If Not dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value Is Nothing Then
                    If Not dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value Is Nothing And Not Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value Is Nothing Then
                        If Me.dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value.ToString.Trim <> "" And Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value.ToString.Trim <> "" And IsNumeric(Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value.ToString.Trim) Then
                            Dim ComunicacionClass As New dtoCOMUNICACION_CONTACTO
                            With ComunicacionClass
                                .Control = ActualizaTelefono 'vAccionRegistro 'vAccionRegistro
                                .IDComunicacionContacto = 1 'Momentaneamente pero cambiar en actualizaciones
                                .NumeroComunicacion = dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value
                                .TipoComunicacion = dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value
                                .CodigoPersona = MyCodigoCliente
                                .MyNumDoctoContacto = MyNumeroDoctoContacto
                            End With
                            'datahelper
                            'Dim respComunicacion As ADODB.Recordset
                            'respComunicacion = ComunicacionClass.GrabaComunicacion()
                            Dim respComunicacion As DataTable = ComunicacionClass.GrabaComunicacion()
                            If respComunicacion.Rows.Count = 1 Then 'Se realizo Correctamente.
                                'MessageBox.Show(respComunicacion.Fields(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                ContadorInsercionTelefeonos += 1
                                Paso2 = 1
                            ElseIf respComunicacion.Rows.Count = 2 And Len(Trim(respComunicacion.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                                'MessageBox.Show("Descripción: " & respComunicacion.Fields(1).Value, "ORACLE -> Error: " & respComunicacion.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If

                            'datahelper
                            'If respComunicacion.Fields.Count = 1 Then 'Se realizo Correctamente.
                            '    'MessageBox.Show(respComunicacion.Fields(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            '    ContadorInsercionTelefeonos += 1
                            '    Paso2 = 1
                            'ElseIf respComunicacion.Fields.Count = 2 And Len(Trim(respComunicacion.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                            '    'MessageBox.Show("Descripción: " & respComunicacion.Fields(1).Value, "ORACLE -> Error: " & respComunicacion.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            'End If
                        End If
                    End If
                Next
            End If

            If ActualizaTelefono = 2 Then

                Dim ComunicacionDeleted As New dtoCOMUNICACION_CONTACTO
                With ComunicacionDeleted
                    .Control = 2 'vAccionRegistro 'vAccionRegistro
                    .IDComunicacionContacto = 1 'Momentaneamente pero cambiar en actualizaciones
                    .NumeroComunicacion = "1" 'dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value
                    .TipoComunicacion = "TELEFONO" 'dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value
                    .CodigoPersona = MyCodigoCliente
                    .MyNumDoctoContacto = MyNumeroDoctoContacto
                End With
                'datahelper
                'Dim respComunicacionDeleted As ADODB.Recordset
                'respComunicacionDeleted = ComunicacionDeleted.GrabaComunicacion()
                Dim respComunicacionDeleted As DataTable = ComunicacionDeleted.GrabaComunicacion()
                If respComunicacionDeleted.Rows.Count = 1 Then 'Se realizo Correctamente.
                    Dim ContadorInsercionTelefeonos As Integer = 0
                    For i As Integer = 0 To dgvTelefonosContacto.Rows.Count - 1
                        If Not dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value Is Nothing And Not Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value Is Nothing Then
                            If Me.dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value.ToString.Trim <> "" And Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value.ToString.Trim <> "" And IsNumeric(Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value.ToString.Trim) Then
                                Dim ComunicacionClass As New dtoCOMUNICACION_CONTACTO
                                With ComunicacionClass
                                    .Control = 1 'vAccionRegistro 'vAccionRegistro
                                    .IDComunicacionContacto = 1 'Momentaneamente pero cambiar en actualizaciones
                                    .NumeroComunicacion = dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value
                                    .TipoComunicacion = dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value
                                    .CodigoPersona = MyCodigoCliente
                                    .MyNumDoctoContacto = MyNumeroDoctoContacto
                                End With
                                'datahelper
                                'Dim respComunicacion As ADODB.Recordset
                                'respComunicacion = ComunicacionClass.GrabaComunicacion()
                                Dim respComunicacion As DataTable = ComunicacionClass.GrabaComunicacion()
                                If respComunicacion.Rows.Count = 1 Then 'Se realizo Correctamente.
                                    ContadorInsercionTelefeonos += 1
                                    Paso2 = 1
                                ElseIf respComunicacion.Rows.Count = 2 And Len(Trim(respComunicacion.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                                End If
                            End If
                        End If
                    Next
                ElseIf respComunicacionDeleted.Rows.Count = 2 And Len(Trim(respComunicacionDeleted.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                    MessageBox.Show("Descripción: " & respComunicacionDeleted.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respComunicacionDeleted.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                'datahelper
                'If respComunicacionDeleted.Fields.Count = 1 Then 'Se realizo Correctamente.
                '    Dim ContadorInsercionTelefeonos As Integer = 0
                '    For i As Integer = 0 To dgvTelefonosContacto.Rows.Count - 1
                '        If Not dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value Is Nothing And Not Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value Is Nothing Then
                '            If Me.dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value.ToString.Trim <> "" And Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value.ToString.Trim <> "" And IsNumeric(Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value.ToString.Trim) Then
                '                Dim ComunicacionClass As New dtoCOMUNICACION_CONTACTO
                '                With ComunicacionClass
                '                    .Control = 1 'vAccionRegistro 'vAccionRegistro
                '                    .IDComunicacionContacto = 1 'Momentaneamente pero cambiar en actualizaciones
                '                    .NumeroComunicacion = dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value
                '                    .TipoComunicacion = dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value
                '                    .CodigoPersona = MyCodigoCliente
                '                    .MyNumDoctoContacto = MyNumeroDoctoContacto
                '                End With
                '                Dim respComunicacion As ADODB.Recordset
                '                respComunicacion = ComunicacionClass.GrabaComunicacion()
                '                If respComunicacion.Fields.Count = 1 Then 'Se realizo Correctamente.
                '                    ContadorInsercionTelefeonos += 1
                '                    Paso2 = 1
                '                ElseIf respComunicacion.Fields.Count = 2 And Len(Trim(respComunicacion.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                '                End If
                '            End If
                '        End If
                '    Next
                'ElseIf respComunicacionDeleted.Fields.Count = 2 And Len(Trim(respComunicacionDeleted.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                '    MessageBox.Show("Descripción: " & respComunicacionDeleted.Fields(1).Value, "ORACLE -> Error: " & respComunicacionDeleted.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End If
            End If
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Crea la Grilla para el Ingreso de Telefonos.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GeneraDetalleTelefonos2009_eliminarlo(ByVal MyGrillaTelefonos As DataGridView)
        'Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_GRILLA_TELEFONOS", 0}
        'Try
        '    Dim rstGrillaTelefonos As ADODB.Recordset = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
        '    Dim rstComboGrilla As ADODB.Recordset = rstGrillaTelefonos.NextRecordset
        '    'Dim daTelefonos As New OleDbDataAdapter

        '    dtGrillaTelefonos.Clear()
        '    dtComboGrilla.Clear()
        '    daTelefonos.Fill(dtGrillaTelefonos, rstGrillaTelefonos)
        '    daTelefonos.Fill(dtComboGrilla, rstComboGrilla)

        '    Dim dvGrillaTelefonos As DataView = dtGrillaTelefonos.DefaultView
        '    Dim dvComboGrilla As DataView = dtComboGrilla.DefaultView

        '    MyGrillaTelefonos.Columns.Clear()
        '    With MyGrillaTelefonos
        '        .AllowUserToOrderColumns = True
        '        .AllowUserToDeleteRows = True
        '        .AllowUserToAddRows = True
        '        .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
        '        .AutoGenerateColumns = False
        '        .DataSource = dtGrillaTelefonos.DefaultView
        '        .Font = New System.Drawing.Font("Arial", 8.0!, FontStyle.Regular)
        '        .RowHeadersVisible = True
        '        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '    End With

        '    Dim ColTipoComunicacion As New DataGridViewComboBoxColumn
        '    With ColTipoComunicacion
        '        .Name = "COMUNICACION"
        '        .DataPropertyName = "COMUNICACION"
        '        .HeaderText = "COMUNICACION"
        '        .DataSource = dvComboGrilla
        '        .DisplayMember = "COMUNICACION"
        '        .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        '        .Width = 130
        '    End With
        '    MyGrillaTelefonos.Columns.Add(ColTipoComunicacion)

        '    Dim ColNumero As New DataGridViewTextBoxColumn
        '    With ColNumero
        '        .Name = "NUMERO"
        '        .DataPropertyName = "NROCOMUNICACION_CONTACTO"
        '        .HeaderText = "NUMERO"
        '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '    End With
        '    MyGrillaTelefonos.Columns.Add(ColNumero)

        'Catch Qex As Exception
        '    MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    ''' <summary>
    ''' Crea la Grilla para el Ingreso de Contactos.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GeneraDetalleContactos()
        Try
            dtContacto = dsContacto.Tables.Add
            With dtContacto
                .Columns.Add("ORDEN", Type.GetType("System.Int16"))
                .Columns.Add("TIPO CONTACTO", Type.GetType("System.String"))
                .Columns.Add("TIPO DOCTO", Type.GetType("System.String"))
                .Columns.Add("DOCUMENTO", Type.GetType("System.String"))
                .Columns.Add("NOMBRES y APELLIDOS", Type.GetType("System.String"))
                .Columns.Add("¿ACTIVO?", Type.GetType("System.Boolean"))
                .Columns.Add("IDCONTACTO_PERSONA", Type.GetType("System.Boolean"))
            End With
            With dsContacto.Tables(0)
                .PrimaryKey = New DataColumn() {.Columns("DOCUMENTO")}
            End With
            dgvContactos.DataSource = dtContacto.DefaultView
            With dgvContactos
                '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = True
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .DataSource = dtContacto.DefaultView
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .Font = New System.Drawing.Font("Arial", 8.0!, FontStyle.Regular)
                .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                .VirtualMode = True
                .RowHeadersVisible = False
                .Columns("ORDEN").Width = 45
                .Columns("TIPO CONTACTO").Width = 120
                .Columns("TIPO DOCTO").Width = 93
                .Columns("DOCUMENTO").Width = 80
                .Columns("NOMBRES y APELLIDOS").Width = 220
                .Columns("¿ACTIVO?").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns("IDCONTACTO_PERSONA").Visible = False
            End With
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' Agrega el Contacto de la Persona Juridica Directamente a Oracle.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AgregarContactoJuridico(ByVal Accion As Integer)
        If vAccionRegistro = 1 Then 'Si 
            Dim ContactoClass As New dtoCONTACTO_CLIENTE
            With ContactoClass
                .Control = Accion 'vAccionRegistro
                .IDContactoPersona = 1 'Momentaneamente pero cambiar en actualizaciones
                .IDTipoContacto = cmbTipoContacto.SelectedValue
                .IDPersona = MyCodigoCliente
                .CentroCosto = cmbAreaEmpresa.SelectedValue
                .Nombres = txtNombrePCont.Text
                .Apepat = "NULL" 'txtApellidoPCont.Text
                .Apemat = "NULL" 'txtApellidoMCont.Text
                .IDTipoDocumentoContacto = cmbTipoDoctoContacto.SelectedValue
                .NumeroDoctumento = txtNumDoctoContacto.Text
                .EmailContacto = IIf(Len(Trim(txtEmailContacto.Text)) = 0, "NULL", txtEmailContacto.Text)
                If Me.TXT_IDCONTACTO_PERSONA.Text = "" Or IsDBNull(Me.TXT_IDCONTACTO_PERSONA.Text) = True Then
                    .sIDContactoPersona = "NULL" ' Como es nuevo no Existe el contacto de Persona 
                Else
                    .sIDContactoPersona = Me.TXT_IDCONTACTO_PERSONA.Text
                End If
                MyNumeroDoctoContacto = txtNumDoctoContacto.Text
                'MessageBox.Show(MyNumeroDoctoContacto)
                If rbtMasculino.Checked = True Then
                    .Sexo = "M"
                End If
                If rbtFemenino.Checked = True Then
                    .Sexo = "F"
                End If
                If chkActivoContacto.Checked = True Then
                    .EstadoRegistro = 1
                Else
                    .EstadoRegistro = 0
                End If
                .IDUsuariPersonal = MyUsuario
                .IDRolUsuario = MyRol
                .IP = MyIP '"192.168.50.47"
            End With

            'datahelper
            'Dim restContacto As ADODB.Recordset
            'restContacto = ContactoClass.GrabaContacto()
            Dim restContacto As DataTable = ContactoClass.GrabaContacto()
            If restContacto.Rows.Count = 1 Then 'Se realizo Correctamente.
                AgregarTelefonosContacto(1)
                Paso2 = 1
            ElseIf restContacto.Rows.Count = 2 And Len(Trim(restContacto.Rows(0).Item(0).Value)) <= 6 Then 'Si se producjo algun error.
                MessageBox.Show("Descripción: " & restContacto.Rows(0).Item(1).Value, "ORACLE -> Error: " & restContacto.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            'datahelper
            'If restContacto.Fields.Count = 1 Then 'Se realizo Correctamente.
            '    AgregarTelefonosContacto(1)
            '    Paso2 = 1
            'ElseIf restContacto.Fields.Count = 2 And Len(Trim(restContacto.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
            '    MessageBox.Show("Descripción: " & restContacto.Fields(1).Value, "ORACLE -> Error: " & restContacto.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If

        End If

        If vAccionRegistro = 2 Then
            If vActualizaContacto = 0 Then 'Si se carga Datos en la Grilla de Contactos
                'MessageBox.Show("Seleccione un Contacto de la Lista y de DobleClik.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim ContactoClass As New dtoCONTACTO_CLIENTE
                With ContactoClass
                    .Control = Accion
                    '.IDContactoPersona = 1 'Momentaneamente pero cambiar en actualizaciones
                    .IDTipoContacto = cmbTipoContacto.SelectedValue '  cmbAreaEmpresa.SelectedValue   Tepsa
                    .IDPersona = MyCodigoCliente
                    .CentroCosto = cmbAreaEmpresa.SelectedValue
                    .Nombres = txtNombrePCont.Text
                    .Apepat = txtApellidoPCont.Text
                    .Apemat = txtApellidoMCont.Text
                    .IDTipoDocumentoContacto = cmbTipoDoctoContacto.SelectedValue
                    .NumeroDoctumento = txtNumDoctoContacto.Text
                    .EmailContacto = IIf(Len(Trim(txtEmailContacto.Text)) = 0, "NULL", txtEmailContacto.Text)
                    MyNumeroDoctoContacto = txtNumDoctoContacto.Text
                    'MessageBox.Show(MyNumeroDoctoContacto)
                    If rbtMasculino.Checked = True Then
                        .Sexo = "M"
                    End If
                    If rbtFemenino.Checked = True Then
                        .Sexo = "F"
                    End If
                    If chkActivoContacto.Checked = True Then
                        .EstadoRegistro = 1
                    Else
                        .EstadoRegistro = 0
                    End If
                    .IDUsuariPersonal = MyUsuario
                    .IDRolUsuario = MyRol
                    .IP = MyIP '"192.168.50.47"
                End With

                'datahelper
                'Dim restContacto As ADODB.Recordset
                'restContacto = ContactoClass.GrabaContacto()
                Dim restContacto As DataTable = ContactoClass.GrabaContacto()
                If restContacto.Rows.Count = 1 Then 'Se realizo Correctamente.
                    MessageBox.Show(restContacto.Rows(0).Item(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    AgregarTelefonosContacto(1)
                    Paso2 = 1
                ElseIf restContacto.Rows.Count = 2 And Len(Trim(restContacto.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                    MessageBox.Show("Descripción: " & restContacto.Rows(0).Item(1).ToString, "ORACLE -> Error: " & restContacto.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                'datahelper
                'If restContacto.Fields.Count = 1 Then 'Se realizo Correctamente.
                '    MessageBox.Show(restContacto.Fields(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    AgregarTelefonosContacto(1)
                '    Paso2 = 1
                'ElseIf restContacto.Fields.Count = 2 And Len(Trim(restContacto.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                '    MessageBox.Show("Descripción: " & restContacto.Fields(1).Value, "ORACLE -> Error: " & restContacto.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End If
            End If

            If vActualizaContacto = 1 Then 'No carga Datos en la Grilla de Contactos
                Dim ContactoClass As New dtoCONTACTO_CLIENTE
                With ContactoClass
                    .Control = Accion
                    .IDContactoPersona = 1 'Momentaneamente pero cambiar en actualizaciones
                    .IDTipoContacto = cmbAreaEmpresa.SelectedValue
                    .IDPersona = MyCodigoCliente
                    .CentroCosto = cmbAreaEmpresa.SelectedValue
                    .Nombres = txtNombrePCont.Text
                    .Apepat = txtApellidoPCont.Text
                    .Apemat = txtApellidoMCont.Text
                    .IDTipoDocumentoContacto = cmbTipoDoctoContacto.SelectedValue
                    .NumeroDoctumento = txtNumDoctoContacto.Text
                    .EmailContacto = IIf(Len(Trim(txtEmailContacto.Text)) = 0, "NULL", txtEmailContacto.Text)
                    MyNumeroDoctoContacto = txtNumDoctoContacto.Text
                    'Modificado 05/07/2007 
                    If Me.TXT_IDCONTACTO_PERSONA.Text = "" Or IsDBNull(txtNumDoctoContacto.Text) = True Then
                        .sIDContactoPersona = "NULL"
                    Else
                        .sIDContactoPersona = Me.TXT_IDCONTACTO_PERSONA.Text
                    End If
                    '
                    'MessageBox.Show(MyNumeroDoctoContacto)
                    If rbtMasculino.Checked = True Then
                        .Sexo = "M"
                    End If
                    If rbtFemenino.Checked = True Then
                        .Sexo = "F"
                    End If
                    If chkActivoContacto.Checked = True Then
                        .EstadoRegistro = 1
                    Else
                        .EstadoRegistro = 0
                    End If
                    .IDUsuariPersonal = MyUsuario
                    .IDRolUsuario = MyRol
                    .IP = MyIP '"192.168.50.47"
                End With

                'datahelper
                'Dim restContacto As ADODB.Recordset
                'restContacto = ContactoClass.GrabaContacto()
                Dim restContacto As DataTable = ContactoClass.GrabaContacto()
                If restContacto.Rows.Count = 1 Then 'Se realizo Correctamente.
                    MessageBox.Show(restContacto.Rows(0).Item(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    AgregarTelefonosContacto(1)
                    Paso2 = 1
                ElseIf restContacto.Rows.Count = 2 And Len(Trim(restContacto.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                    MessageBox.Show("Descripción: " & restContacto.Rows(0).Item(1).ToString, "ORACLE -> Error: " & restContacto.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                'datahelper
                'If restContacto.Fields.Count = 1 Then 'Se realizo Correctamente.
                '    MessageBox.Show(restContacto.Fields(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    AgregarTelefonosContacto(1)
                '    Paso2 = 1
                'ElseIf restContacto.Fields.Count = 2 And Len(Trim(restContacto.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                '    MessageBox.Show("Descripción: " & restContacto.Fields(1).Value, "ORACLE -> Error: " & restContacto.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End If
            End If
        End If

    End Sub

    ''' <summary>
    ''' Realiza la relación entre un funcionario de negocio con un Cliente en Oracle.
    ''' </summary>
    ''' <param name="MyCodigoClienteFuncionario"></param>
    ''' <remarks></remarks>
    Private Sub AsignacionFuncionario(ByVal MyCodigoClienteFuncionario As String)
        If txtFuncionarioCuenta.Text <> "No Asignado..." Then
            '            If vAccionRegistro = 1 Then 'Asignando Funcionario a Nuevo Cliente.       (TEPSA)
            Dim AsociaClass As New dtoASOCIAFUNCIONARIO_CLIENTE
            AsociaClass.Control = vAccionRegistro
            ''''''''''''''''''''''''''''''''''''''''''''
            If MyRol = 11 Then
                AsociaClass.IDFuncionario = ModIVOPERSONA.MyUsuario
                If AsociaClass.Control = 1 Then   ' Tepsa 
                    AsociaClass.IDFuncionarioActual = ModIVOPERSONA.MyUsuario
                Else
                    AsociaClass.IDFuncionarioActual = CodFuncionarioNegocio     ' Tepsa 
                End If
                AsociaClass.TipoFuncionario = ModIVOPERSONA.MyRol
            Else
                AsociaClass.IDFuncionario = CodFuncionarioNegocio
                AsociaClass.IDFuncionarioActual = CodFuncionarioNegocio
                AsociaClass.TipoFuncionario = TipoFuncionarioNegocio
            End If
            ''''''''''''''''''''''''''''''''''''''''''''
            'AsociaClass.IDFuncionario = CodFuncionarioNegocio
            'AsociaClass.IDFuncionarioActual = CodFuncionarioNegocio
            'AsociaClass.TipoFuncionario = TipoFuncionarioNegocio
            AsociaClass.IDPersona = MyCodigoClienteFuncionario
            AsociaClass.IDUsuarioPersona = MyUsuario
            AsociaClass.RolUsuario = MyRol
            AsociaClass.IP = MyIP '"192.168.50.47"
            AsociaClass.IDEstadoRegistro = 1
            '
            'datahelper
            'respAsocia = AsociaClass.AsociaFuncionarioJuridico()
            Dim respAsocia As DataTable = AsociaClass.AsociaFuncionarioJuridico()

            If respAsocia.Rows.Count = 1 Then 'Se realizo Correctamente.
                Paso1 = 1
                AccionesJuridica()
            ElseIf respAsocia.Rows.Count = 2 And Len(Trim(respAsocia.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                MessageBox.Show("Descripción: " & respAsocia.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respAsocia.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            'datahelper
            'If respAsocia.Fields.Count = 1 Then 'Se realizo Correctamente.
            '    Paso1 = 1
            '    AccionesJuridica()
            'ElseIf respAsocia.Fields.Count = 2 And Len(Trim(respAsocia.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
            '    MessageBox.Show("Descripción: " & respAsocia.Fields(1).Value, "ORACLE -> Error: " & respAsocia.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
        Else
            Paso1 = 1
            AccionesJuridica()
            'MessageBox.Show("LAS REASIGNACIONES DE FUNCIONARIOS Y RESPONSABLES DE CTACTE," & vbCrLf & "SE REALIZAN EN LOS MODULOS DE ACUERDOS COMERCIALES Y CTACTE.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        'ElseIf txtFuncionarioCuenta.Text = "No Asignado..." Then

        'End If
    End Sub

    ''' <summary>
    ''' Inserta la Persona Natural en Oracle.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GrabaNatural()
        Dim MyClassCliente As New dtoCLIENTES
        MyClassCliente._MyControl = vAccionRegistro
        MyClassCliente._MyIDPersona = vIDPersona
        MyClassCliente._MyTipoPersona = Me.cmbTipoPersona.SelectedValue
        MyClassCliente._MyCodigoCliente = Me.txtCodigo.Text
        MyClassCliente._MyFechaIngreso = Me.txtFechaRegistro._MyFecha

        If Me.chkPostFacturacion.Checked = True Then
            MyClassCliente._MyPagoPostfacturacion = 1
        Else
            MyClassCliente._MyPagoPostfacturacion = 0
        End If
        MyClassCliente._MyEmail = IIf(Len(Trim(Me.txtCorreoElectronico.Text)) = 0, "NULL", Me.txtCorreoElectronico.Text)
        MyClassCliente._MyApellidoPaterno = Me.txtApellidoP.Text
        MyClassCliente._MyApellidoMaterno = Me.txtApellidoM.Text
        MyClassCliente._MyNombreP = Me.txtNombreP.Text
        MyClassCliente._MyNombreS = IIf(Me.txtNombreS.Text.Trim = "", "NULL", Me.txtNombreS.Text)
        '
        If Not IsDate(Me.txtFechaNacimiento.GetMyFecha) Then
            MyClassCliente._MyFechaNacimiento = "null"
        Else
            MyClassCliente._MyFechaNacimiento = Me.txtFechaNacimiento.GetMyFecha
        End If
        '
        If rdbSexoFemCliente.Checked = True Then
            MyClassCliente._MySexoPersona = "F"
        End If
        If rdbSexoMasCliente.Checked = True Then
            MyClassCliente._MySexoPersona = "M"
        End If

        MyClassCliente._MyEsMenorEdad = 0 'No es menor de edad.
        If Me.chkAgenteRetencion.Checked = True Then
            MyClassCliente._MyAgenteRetencion = 1
        Else
            MyClassCliente._MyAgenteRetencion = 0
        End If

        If Me.chkBase.Checked = True Then
            MyClassCliente._MyMontoBase = 1
        Else
            MyClassCliente._MyMontoBase = 0
        End If

        MyClassCliente._MyTipoDoctoIdentidad = Me.cmbTipoDocIdent.SelectedValue
        MyClassCliente._MyNuDoctoSunat = Me.txtNumeroDocto.Text
        MyClassCliente._MyNuRetenSunat = Me.txtNumeroDocto.Text '"2121" 'Nothing
        MyClassCliente._MyIDRubro = Me.cmbRubroEmpresarial.SelectedValue
        MyClassCliente._MyClasificacionPersona = Me.cmbClasPersona.SelectedValue
        MyClassCliente._MyEstadoRegistro = 1
        MyClassCliente._MyUsuarioPersonal = MyUsuario
        MyClassCliente._MyIDRolUsuario = MyRol
        MyClassCliente._MyIP = MyIP '"192.168.50.47"
        MyClassCliente._MyIDPais = Me.cmbPais.SelectedValue
        MyClassCliente._MyIDDepartamento = Me.cmbDepartamento.SelectedValue
        MyClassCliente._MyIDProvincia = Me.cmbProvincia.SelectedValue
        MyClassCliente._MyIDDistrito = Me.cmbDistrito.SelectedValue
        MyClassCliente._MyTipoFacturacion = Me.cmbTipoFacturacion.SelectedValue

        'datahelper
        'respOracle = MyClassCliente.GrabaClienteNatural()

        Dim respOracle As DataTable = MyClassCliente.GrabaClienteNatural()
        If respOracle.Rows.Count = 1 Then 'Se realizo Correctamente.
            bClienteActualizado = True
            MessageBox.Show(respOracle.Rows(0).Item(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Para tener el codigo cliente en la insercion de Contactos y Direcciones.
            MyCodigoCliente = MyClassCliente._MyCodigoCliente 'MessageBox.Show(MyCodigoCliente)
            '29/04/2008  - Selecciona al funcionario de negocio 
            AsignacionFuncionario(MyCodigoCliente)
            If Me.chkContadoCredito.Checked = False Then
                'AsignacionFuncionario(MyCodigoCliente)
                MessageBox.Show("AsignacionFuncionario EXCLUSIVE DE nATURAL TE FALTA")
            Else
                Paso1 = 1
                AccionesNatural()
            End If
        ElseIf respOracle.Rows.Count = 2 And Len(Trim(respOracle.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
            bClienteActualizado = False
            MessageBox.Show("Descripción: " & respOracle.Rows(1).Item(0).ToString, "ORACLE -> Error: " & respOracle.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


        'datahelper
        'If respOracle.Fields.Count = 1 Then 'Se realizo Correctamente.
        '    bClienteActualizado = True
        '    MessageBox.Show(respOracle.Fields(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    'Para tener el codigo cliente en la insercion de Contactos y Direcciones.
        '    MyCodigoCliente = MyClassCliente._MyCodigoCliente 'MessageBox.Show(MyCodigoCliente)
        '    '29/04/2008  - Selecciona al funcionario de negocio 
        '    AsignacionFuncionario(MyCodigoCliente)
        '    If Me.chkContadoCredito.Checked = False Then
        '        MessageBox.Show("AsignacionFuncionario EXCLUSIVE DE nATURAL TE FALTA")
        '    Else
        '        Paso1 = 1
        '        AccionesNatural()
        '    End If
        'ElseIf respOracle.Fields.Count = 2 And Len(Trim(respOracle.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
        '    bClienteActualizado = False
        '    MessageBox.Show("Descripción: " & respOracle.Fields(1).Value, "ORACLE -> Error: " & respOracle.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If
    End Sub

    ''' <summary>
    ''' Inserta la Persona Juridica en Oracle.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GrabaJuridica()
        Dim MyClassCliente As New dtoCLIENTES
        Try
            If Me.chkBase.Checked = True Then
                MyClassCliente._MyMontoBase = 1
            Else
                MyClassCliente._MyMontoBase = 0
            End If

            MyClassCliente._MyControl = vAccionRegistro
            MyClassCliente._MyIDPersona = vIDPersona
            MyClassCliente._MyTipoPersona = Me.cmbTipoPersona.SelectedValue
            MyClassCliente._MyCodigoCliente = Me.txtCodigo.Text
            If Me.chkCorporativo.Checked = True Then
                MyClassCliente._MyClienteCorporativo = 1
            Else
                MyClassCliente._MyClienteCorporativo = 0
            End If
            MyClassCliente._MyRazonSocial = Me.txtRazonSocial.Text
            MyClassCliente._MyGerenteGeneral = Me.txtGG.Text
            MyClassCliente._MyRepresentanteLegal = Me.txtRepLegal.Text
            MyClassCliente._MyFechaIngreso = Me.txtFechaRegistro._MyFecha
            If Me.chkPostFacturacion.Checked = True Then
                MyClassCliente._MyPagoPostfacturacion = 1
            Else
                MyClassCliente._MyPagoPostfacturacion = 0
            End If
            MyClassCliente._MyEmail = IIf(Len(Trim(Me.txtWebSite.Text)) = 0, "NULL", Me.txtWebSite.Text)
            If Me.chkAgenteRetencion.Checked = True Then
                MyClassCliente._MyAgenteRetencion = 1
            Else
                MyClassCliente._MyAgenteRetencion = 0
            End If
            MyClassCliente._MyTipoDoctoIdentidad = Me.cmbTipoDocIdent.SelectedValue
            MyClassCliente._MyNuDoctoSunat = Me.txtRUC.Text
            MyClassCliente._MyNuRetenSunat = Me.txtRUC.Text '"2121" 'Nothing
            MyClassCliente._MyIDRubro = Me.cmbRubroEmpresarial.SelectedValue
            MyClassCliente._MyClasificacionPersona = Me.cmbClasPersona.SelectedValue
            MyClassCliente._MyEstadoRegistro = 1
            MyClassCliente._MyUsuarioPersonal = MyUsuario
            MyClassCliente._MyIDRolUsuario = MyRol
            MyClassCliente._MyIP = MyIP '"192.168.50.47"
            MyClassCliente._MyIDPais = Me.cmbPais.SelectedValue
            MyClassCliente._MyIDDepartamento = Me.cmbDepartamento.SelectedValue
            MyClassCliente._MyIDProvincia = Me.cmbProvincia.SelectedValue
            MyClassCliente._MyIDDistrito = Me.cmbDistrito.SelectedValue
            MyClassCliente._MyTipoFacturacion = Me.cmbTipoFacturacion.SelectedValue
            'Datahelper
            'respOracle = MyClassCliente.GrabaClienteJuridico()

            Dim respOracle As DataTable = MyClassCliente.GrabaClienteJuridico()
            'datahelper
            'If respOracle.Fields.Count = 1 Then 'Se realizo Correctamente.  26/06/2007
            If respOracle.Columns.Count = 1 Then
                'If respOracle.Rows.Count = 1 Then 'Se realizo Correctamente.  26/06/2007
                bClienteActualizado = True
                'datahelper
                'MessageBox.Show(respOracle.Fields(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MessageBox.Show(respOracle.Rows(0).Item(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'Para tener el codigo cliente en la insercion de Contactos y Direcciones.
                MyCodigoCliente = MyClassCliente._MyCodigoCliente 'MessageBox.Show(MyCodigoCliente)
                AsignacionFuncionario(MyCodigoCliente)
                If Me.chkContadoCredito.Checked = True Then
                    'AsignacionFuncionario(MyCodigoCliente)
                    'Else
                    Paso1 = 1
                    AccionesJuridica()
                End If
                'datahelper
                'ElseIf respOracle.Fields.Count = 2 And Len(Trim(respOracle.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                'If CType(respOracle.Fields(0).Value, Long) = 10 Then
                '
                'ElseIf respOracle.Rows.Count = 2 And Len(Trim(respOracle.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
            ElseIf respOracle.Columns.Count = 2 And Len(Trim(respOracle.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                'datahelper
                'If CType(respOracle.Fields(0).Value, Long) = 10 Then
                If CType(respOracle.Rows(0).Item(0).ToString, Long) = 10 Then
                    registra_datos_adicionales()
                Else
                    bClienteActualizado = False
                    'datahelper
                    'MessageBox.Show("Descripción: " & respOracle.Fields(1).Value, "ORACLE -> Error: " & CType(respOracle.Fields(0).Value, String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    MessageBox.Show("Descripción: " & respOracle.Rows(0).Item(1).ToString, "ORACLE -> Error: " & CType(respOracle.Rows(0).Item(0).ToString, String), MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
            ' Refrescar los datos
            Dim dgvr As DataGridViewRow = Me.DataGridLista.CurrentRow()
            dgvr.Cells("IDFUNCIONARIO_ACTUAL").Value = CodFuncionarioNegocio
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    ''' <summary>
    ''' Desahabilita los controles necesarios para la edicion de un Cliente ya existente.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeshabilitaControlesEdicion()
        MenuTab.Items(0).Enabled = False
        MenuTab.Items(1).Enabled = True
        MenuTab.Items(2).Enabled = True
        MenuTab.Items(3).Enabled = True
        MenuTab.Items(4).Enabled = True
        txtFuncionarioCuenta.ReadOnly = True
        txtRespFacturacion.ReadOnly = True
        cmbTipoPersona.Enabled = False
        cmbTipoPersona.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
        txtFuncionarioCuenta.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
        txtRespFacturacion.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
        '
        btnFuncionarioCta.Enabled = True
        '
        btnRespFactura.Enabled = False
        chkContadoCredito.Enabled = False
    End Sub

    ''' <summary>
    ''' Establece propiedades de Controles tras la Insercion o actualizacion de Clientes Juridicos.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AccionesJuridica()
        'Actualizacion de Paneles despues de Guardar los Cambios.
        SelectMenu(2)
        NuevoToolStripMenuItem.Enabled = False
        EdicionToolStripMenuItem.Enabled = False
        CancelarToolStripmenuItem.Enabled = True
        GrabarToolStripMenuItem.Enabled = False
        EliminarToolStripMenuItem.Enabled = True
        ExportarToolStripMenuItem.Enabled = False
        ImprimirToolStripMenuItem.Enabled = False
        Me.txtCodigoClienteContacto.Text = Me.txtCodigo.Text
        Me.txtNombreClienteContacto.Text = Me.txtRazonSocial.Text
        cmbAreaEmpresa.SelectedValue = 2
        cmbTipoContacto.SelectedValue = 2
        cmbTipoDoctoContacto.SelectedValue = 3
        cmbAreaEmpresa.Enabled = True
        cmbTipoContacto.Enabled = True
        cmbAreaEmpresa.BackColor = Color.White
        cmbTipoContacto.BackColor = Color.White
        btnAreaEmpresa.Enabled = True
        btnTipoContacto.Enabled = True
    End Sub

    ''' <summary>
    ''' Establece propiedades de Controles tras la Insercion o actualizacion de Clientes Naturales.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AccionesNatural()
        'Actualizacion de Paneles despues de Guardar los Cambios.
        SelectMenu(2)
        NuevoToolStripMenuItem.Enabled = False
        EdicionToolStripMenuItem.Enabled = False
        CancelarToolStripmenuItem.Enabled = True
        GrabarToolStripMenuItem.Enabled = False
        EliminarToolStripMenuItem.Enabled = True
        ExportarToolStripMenuItem.Enabled = False
        ImprimirToolStripMenuItem.Enabled = False
        Me.txtCodigoClienteContacto.Text = Me.txtCodigo.Text
        Me.txtNombreClienteContacto.Text = Me.txtNombreP.Text & " " & Me.txtApellidoP.Text & " " & Me.txtApellidoM.Text
        cmbAreaEmpresa.SelectedValue = 1
        cmbTipoContacto.SelectedValue = 6
        cmbTipoDoctoContacto.SelectedValue = 3
        cmbAreaEmpresa.Enabled = False
        cmbTipoContacto.Enabled = False
        cmbAreaEmpresa.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
        cmbTipoContacto.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
        btnAreaEmpresa.Enabled = False
        btnTipoContacto.Enabled = False
    End Sub

    ''' <summary>
    ''' Carga con datos de Contactos a la Grilla para poder Actualizarlos.
    ''' </summary>
    ''' <remarks></remarks>
    'Private Sub CargarListaContactos2009_eliminarlo()
    'Dim rstContactos As ADODB.Recordset
    ''Dim daContactos As New OleDbDataAdapter
    ''Dim dtContactos As New DataTable
    ''MessageBox.Show(MyCodigoCliente)
    'Dim scodigo_cliente As String
    'If MyCodigoCliente = Nothing Or IsDBNull(MyCodigoCliente) = True Or MyCodigoCliente = "" Then
    '    scodigo_cliente = "null"
    'Else
    '    scodigo_cliente = MyCodigoCliente
    'End If
    ''Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTACONTACTO", 4, MyCodigoCliente, 2}
    'Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTACONTACTO", 4, scodigo_cliente, 2}
    'Try
    '    dtContactos.Clear()
    '    rstContactos = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
    '    daContactos.Fill(dtContactos, rstContactos)

    '    dgvContactos.Columns.Clear()

    '    'With dgvContactosActualiza
    '    With dgvContactos
    '        .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
    '        .AllowUserToOrderColumns = True
    '        .AllowUserToDeleteRows = True
    '        .AllowUserToAddRows = True
    '        .AutoGenerateColumns = False
    '        .DataSource = dtContactos.DefaultView
    '        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
    '        .SelectionMode = DataGridViewSelectionMode.CellSelect
    '        .Font = New System.Drawing.Font("Arial", 8.0!, FontStyle.Regular)
    '        .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
    '        .VirtualMode = True
    '        .RowHeadersVisible = False
    '        .ReadOnly = True
    '        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '    End With
    '    Dim col1 As New DataGridViewTextBoxColumn
    '    With col1
    '        .Name = "ORDEN"
    '        .DataPropertyName = "ORDEN"
    '        .HeaderText = "ORDEN"
    '        .Width = 45
    '    End With
    '    Dim col2 As New DataGridViewTextBoxColumn
    '    With col2
    '        .Name = "TIPO_CONTACTO"
    '        .DataPropertyName = "TIPO_CONTACTO"
    '        .HeaderText = "TIPO CONTACTO"
    '        .Width = 120
    '    End With
    '    Dim col3 As New DataGridViewTextBoxColumn
    '    With col3
    '        .Name = "TIPO_DOC_IDENTIDAD"
    '        .DataPropertyName = "TIPO_DOC_IDENTIDAD"
    '        .HeaderText = "TIPO DOCTO"
    '        .Width = 93
    '    End With
    '    Dim col4 As New DataGridViewTextBoxColumn
    '    With col4
    '        .Name = "NRODOCUMENTO"
    '        .DataPropertyName = "NRODOCUMENTO"
    '        .HeaderText = "DOCUMENTO"
    '        .Width = 80
    '    End With
    '    Dim col5 As New DataGridViewTextBoxColumn
    '    With col5
    '        .Name = "NOMBRE_APELLIDOS"
    '        .DataPropertyName = "NOMBRE_APELLIDOS"
    '        .HeaderText = "NOMBRES Y APELLIDOS"
    '        .Width = 220
    '    End With
    '    Dim col6 As New DataGridViewCheckBoxColumn
    '    With col6
    '        .Name = "ESTADO_REGISTRO"
    '        .DataPropertyName = "ESTADO_REGISTRO"
    '        .HeaderText = "¿ACTIVO?"
    '        .ThreeState = False
    '        .TrueValue = 1
    '        .FalseValue = 0
    '        .Width = 60
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '        .ReadOnly = True
    '    End With
    '    Dim col7 As New DataGridViewTextBoxColumn
    '    With col7
    '        .Name = "IDCONTACTO_PERSONA"
    '        .DataPropertyName = "IDCONTACTO_PERSONA"
    '        .HeaderText = "IDCONTACTO PERSONA"
    '    End With
    '    Dim col8 As New DataGridViewTextBoxColumn
    '    With col8
    '        .Name = "IDTIPO_CONTACTO"
    '        .DataPropertyName = "IDTIPO_CONTACTO"
    '        .HeaderText = "IDTIPO CONTACTO"
    '    End With
    '    Dim col9 As New DataGridViewTextBoxColumn
    '    With col9
    '        .Name = "IDPERSONA"
    '        .DataPropertyName = "IDPERSONA"
    '        .HeaderText = "IDPERSONA"
    '    End With
    '    Dim col10 As New DataGridViewTextBoxColumn
    '    With col10
    '        .Name = "NOMBRES"
    '        .DataPropertyName = "NOMBRES"
    '        .HeaderText = "NOMBRES"
    '    End With
    '    Dim col11 As New DataGridViewTextBoxColumn
    '    With col11
    '        .Name = "APEPAT"
    '        .DataPropertyName = "APEPAT"
    '        .HeaderText = "APEPAT"
    '    End With
    '    Dim col12 As New DataGridViewTextBoxColumn
    '    With col12
    '        .Name = "APEMAT"
    '        .DataPropertyName = "APEMAT"
    '        .HeaderText = "APEMAT"
    '    End With
    '    Dim col13 As New DataGridViewTextBoxColumn
    '    With col13
    '        .Name = "IDTIPO_DOCUMENTO_CONTACTO"
    '        .DataPropertyName = "IDTIPO_DOCUMENTO_CONTACTO"
    '        .HeaderText = "IDTIPO_DOCUMENTO_CONTACTO"
    '    End With
    '    Dim col14 As New DataGridViewTextBoxColumn
    '    With col14
    '        .Name = "EMAIL_CONTACTO"
    '        .DataPropertyName = "EMAIL_CONTACTO"
    '        .HeaderText = "EMAIL_CONTACTO"
    '    End With
    '    Dim col15 As New DataGridViewTextBoxColumn
    '    With col15
    '        .Name = "SEXO"
    '        .DataPropertyName = "SEXO"
    '        .HeaderText = "SEXO"
    '    End With
    '    Dim col16 As New DataGridViewTextBoxColumn
    '    With col16
    '        .Name = "CENTRO_COSTO"
    '        .DataPropertyName = "CENTRO_COSTO"
    '        .HeaderText = "CENTRO_COSTO"
    '    End With

    '    dgvContactos.Columns.AddRange(col1, col2, col3, col4, col5, col6, col7, col8, _
    '                                  col9, col10, col11, col12, col13, col14, col15, col16)
    '    For j As Integer = 6 To 14
    '        dgvContactos.Columns(j).Visible = False
    '    Next

    '    vActualizaContacto = 0

    '    If dgvContactos.RowCount = 0 Then
    '        dgvContactos.Visible = True
    '        Call GeneraDetalleContactos()
    '        vActualizaContacto = 1
    '    End If

    'Catch Qex As Exception
    '    MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
    'End Try
    'End Sub


    ''' <summary>
    ''' Carga la Lista de Telefonos del Contacto seleccionado en la Grilla.
    ''' </summary>
    ''' <param name="IDContacto"></param>
    ''' <remarks></remarks>
    'Private Sub CargarListaTelefonos2009_eliminarlo(ByVal IDContacto As Integer, ByVal MyGrillaConData As DataGridView)
    'Dim rstTipoComunicacion As ADODB.Recordset
    'Dim rstTelefonos As ADODB.Recordset
    ''Dim daTelefonos As New OleDbDataAdapter
    'Dim dtTipoComunicacion As New DataTable
    'Dim dtTelefonos As New DataTable
    'Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTATELEFONOCONTACTO", 4, IDContacto.ToString, 2}
    'Try
    '    rstTipoComunicacion = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
    '    rstTelefonos = rstTipoComunicacion.NextRecordset
    '    'daTelefonos.Fill(dtTipoComunicacion, rstTipoComunicacion)
    '    'daTelefonos.Fill(dtTelefonos, rstTelefonos)
    '    MyGrillaConData.Columns.Clear()

    '    With MyGrillaConData
    '        .AllowUserToOrderColumns = True
    '        .AllowUserToDeleteRows = True
    '        .AllowUserToAddRows = True
    '        .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    '        .AutoGenerateColumns = False

    '        .DataSource = dtTelefonos.DefaultView
    '        '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        .Font = New System.Drawing.Font("Arial", 8.0!, FontStyle.Regular)
    '        .RowHeadersVisible = True
    '        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    End With

    '    Dim Col1 As New DataGridViewTextBoxColumn
    '    With Col1
    '        .Name = "IDCOMUNICACION_CONTACTO"
    '        .DataPropertyName = "IDCOMUNICACION_CONTACTO"
    '        .HeaderText = "IDCOMUNICACION_CONTACTO"
    '    End With

    '    Dim Col2 As New DataGridViewTextBoxColumn
    '    With Col2
    '        .Name = "IDCONTACTO_PERSONA"
    '        .DataPropertyName = "IDCONTACTO_PERSONA"
    '        .HeaderText = "IDCONTACTO_PERSONA"
    '    End With

    '    Dim Col4 As New DataGridViewComboBoxColumn
    '    With Col4
    '        .Name = "COMUNICACION"
    '        .HeaderText = "COMUNICACION"
    '        .DataPropertyName = "COMUNICACION"
    '        .DataSource = dtTipoComunicacion.DefaultView
    '        .DisplayMember = "COMUNICACION"
    '        .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
    '        .Width = 130
    '    End With

    '    Dim Col5 As New DataGridViewTextBoxColumn
    '    With Col5
    '        .Name = "NUMERO"
    '        .DataPropertyName = "NROCOMUNICACION_CONTACTO"
    '        .HeaderText = "NUMERO"
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '    End With

    '    MyGrillaConData.Columns.AddRange(Col1, Col2, Col4, Col5)
    '    For i As Integer = 0 To 3
    '        MyGrillaConData.Columns(i).Visible = False
    '    Next
    '    MyGrillaConData.Columns(2).Visible = True
    '    MyGrillaConData.Columns(3).Visible = True


    'Catch Qex As Exception
    '    MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
    'End Try

    'End Sub

    Private Sub LimpiaPersona()
        Try
            For Each MyObj As Object In TabDatos.Controls
                If TypeOf MyObj Is TextBox Then
                    CType(MyObj, TextBox).Text = ""
                End If
            Next
            '
            If vAccionRegistro = 1 Then   'Tepsa Cuando es nuevo solo debe limpiar (línea agregada solo el if) 'Tepsa 30/09/2006
                Call Funciones.LimpiaCheckBox(Me.chkCorporativo, Me.chkPostFacturacion, Me.chkAgenteRetencion, Me.chkContadoCredito, Me.chkBase)
            End If
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LimpiaContactos()
        Try
            For Each MyObj As Object In TabPage1.Controls
                If TypeOf MyObj Is TextBox Then
                    CType(MyObj, TextBox).Text = ""
                End If
            Next
            dgvContactos.DataSource = Nothing
            dgvTelefonosContacto.DataSource = Nothing
        Catch Qex As Exception

        End Try
    End Sub

    Private Sub LimpiaDirecciones()
        Try
            For Each MyObj As Object In TabPage2.Controls
                If TypeOf MyObj Is TextBox Then
                    CType(MyObj, TextBox).Text = ""
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " EVENTOS DEL FORMULARIO "

    Private Sub FrmClientes_ClickTabPage3() Handles Me.ClickTabPage3
        'hlamas
        'If Paso1 = 0 Then
        MyCodigoCliente = txtCodigo.Text
        If Not bClienteActualizado Then
            MessageBox.Show("Ingrese el Cliente y luego sus Contactos...", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            SelectMenu(2)
            CargarListaContactos()
            GeneraDetalleTelefonos(Me.dgvTelefonosContacto) 'Cuestiones Visuales Nada Mas.
            If txtRazonSocial.Text.Trim.Length = 0 Then
                txtNombreClienteContacto.Text = Me.txtNombreP.Text.Trim & " " & Me.txtNombreS.Text.Trim & " " & Me.txtApellidoP.Text.Trim & " " & Me.txtApellidoM.Text.Trim
            Else
                txtNombreClienteContacto.Text = txtRazonSocial.Text
            End If
            txtCodigoClienteContacto.Text = txtCodigo.Text
            btnAgregar.Visible = True
            btnActualizar.Visible = True
        End If
        If Paso1 = 1 And Paso2 = 0 Then
            'SelectMenu(2)
        End If
        If Paso1 = 1 And Paso2 = 1 Then
            'SelectMenu(2)
        End If
    End Sub

    'Private Sub FrmClientes_ClickTabPage42009_eliminarlo() Handles Me.ClickTabPage4

    'Me.txtCodigoUbigeo.Text = "00000"
    ''hlamas
    'MyCodigoCliente = txtCodigo.Text
    'If vAccionRegistro = 1 Then
    '    'If Paso1 = 0 Then
    '    If Not bClienteActualizado Then
    '        MessageBox.Show("Ingrese el Cliente, sus Contactos y luego las Direcciones...", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If
    '    'If Paso1 = 1 And Paso2 = 0 Then
    '    'MessageBox.Show("Ingrese los Contactos y luego las Direcciones...", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    'End If
    '    'If Paso1 = 1 And Paso2 = 1 Then
    '    If bClienteActualizado Then
    '        cmbPaisDirecciones.SelectedValue = 4
    '        cmbDepartamentoDirecciones.SelectedValue = 15
    '        cmbProvinciaDirecciones.SelectedValue = 17
    '        cmbDistritoDirecciones.SelectedValue = 2
    '        txtCodigoClienteDirecciones.Text = txtCodigo.Text
    '        txtDireccionesCliente.Text = txtRazonSocial.Text
    '        SelectMenu(3)

    '        dtDireccionesCliente.Clear()
    '        Call CargaDirecciones(txtCodigoClienteDirecciones.Text, dgvDirecciones)
    '        Call CargaContactosDirecciones()

    '        Dim rstContactos As ADODB.Recordset
    '        'Dim daContactos As New OleDbDataAdapter
    '        Dim dtContactos As New DataTable

    '        Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTA_CONTACTOS", 4, MyCodigoCliente, 2}
    '        Try
    '            rstContactos = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
    '            daContactos.Fill(dtContactos, rstContactos)
    '            cmbContactoDireccion.DataSource = dtContactos.DefaultView
    '            cmbContactoDireccion.DisplayMember = "NOMBRE_APELLIDO"
    '            cmbContactoDireccion.ValueMember = "IDCONTACTO_PERSONA"
    '        Catch Qex As Exception
    '            MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try
    '    End If
    'End If


    'If vAccionRegistro = 2 Then
    '    'If Paso1 = 0 Then
    '    If Not bClienteActualizado Then
    '        MessageBox.Show("Guarde las actualizaciones del Cliente, sus Contactos y luego las Direcciones...", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If
    '    'If Paso1 = 1 And Paso2 = 0 Then
    '    'If bClienteActualizado Then
    '    '    cmbPaisDirecciones.SelectedValue = 4
    '    '    cmbDepartamentoDirecciones.SelectedValue = 15
    '    '    cmbProvinciaDirecciones.SelectedValue = 17
    '    '    cmbDistritoDirecciones.SelectedValue = 2
    '    '    txtCodigoClienteDirecciones.Text = txtCodigo.Text
    '    '    txtDireccionesCliente.Text = txtRazonSocial.Text
    '    '    SelectMenu(3)

    '    '    dtDireccionesCliente.Clear()
    '    '    Call CargaDirecciones(txtCodigoClienteDirecciones.Text, dgvDirecciones)
    '    '    Call CargaContactosDirecciones()

    '    '    Dim rstContactos As ADODB.Recordset
    '    '    Dim daContactos As New OleDbDataAdapter
    '    '    Dim dtContactos As New DataTable

    '    '    Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTA_CONTACTOS", 4, MyCodigoCliente, 2}
    '    '    Try
    '    '        rstContactos = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
    '    '        daContactos.Fill(dtContactos, rstContactos)
    '    '        cmbContactoDireccion.DataSource = dtContactos.DefaultView
    '    '        cmbContactoDireccion.DisplayMember = "NOMBRE_APELLIDO"
    '    '        cmbContactoDireccion.ValueMember = "IDCONTACTO_PERSONA"
    '    '    Catch Qex As Exception
    '    '        MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    '    End Try

    '    'End If

    '    'If Paso1 = 1 And Paso2 = 1 And cmbTipoPersona.SelectedValue = 1 Then
    '    If bClienteActualizado And cmbTipoPersona.SelectedValue = 1 Then
    '        cmbPaisDirecciones.SelectedValue = 4
    '        cmbDepartamentoDirecciones.SelectedValue = 15
    '        cmbProvinciaDirecciones.SelectedValue = 17
    '        cmbDistritoDirecciones.SelectedValue = 2

    '        txtCodigoClienteDirecciones.Text = txtCodigo.Text
    '        txtDireccionesCliente.Text = txtRazonSocial.Text 'txtNombreP.Text & " " & txtApellidoP.Text & " " & txtApellidoM.Text
    '        SelectMenu(3)

    '        dtDireccionesCliente.Clear()
    '        Call CargaDirecciones(txtCodigoClienteDirecciones.Text, Me.dgvDirecciones)
    '        Call CargaContactosDirecciones()

    '        Dim rstContactos As ADODB.Recordset
    '        'Dim daContactos As New OleDbDataAdapter
    '        Dim dtContactos As New DataTable

    '        Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTA_CONTACTOS", 4, MyCodigoCliente, 2}
    '        Try
    '            rstContactos = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
    '            'daContactos.Fill(dtContactos, rstContactos)
    '            cmbContactoDireccion.DataSource = dtContactos.DefaultView
    '            cmbContactoDireccion.DisplayMember = "NOMBRE_APELLIDO"
    '            cmbContactoDireccion.ValueMember = "IDCONTACTO_PERSONA"
    '        Catch Qex As Exception
    '            MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try

    '        'End If

    '        'If Paso1 = 1 And Paso2 = 1 And cmbTipoPersona.SelectedValue = 2 Then
    '    ElseIf bClienteActualizado And cmbTipoPersona.SelectedValue = 2 Then
    '        cmbPaisDirecciones.SelectedValue = 4
    '        cmbDepartamentoDirecciones.SelectedValue = 15
    '        cmbProvinciaDirecciones.SelectedValue = 17
    '        cmbDistritoDirecciones.SelectedValue = 2

    '        txtCodigoClienteDirecciones.Text = txtCodigo.Text
    '        txtDireccionesCliente.Text = txtNombreP.Text & " " & txtApellidoP.Text & " " & txtApellidoM.Text
    '        SelectMenu(3)

    '        dtDireccionesCliente.Clear()
    '        Call CargaDirecciones(txtCodigoClienteDirecciones.Text, Me.dgvDirecciones)
    '        Call CargaContactosDirecciones()

    '        Dim rstContactos As ADODB.Recordset
    '        'Dim daContactos As New OleDbDataAdapter
    '        Dim dtContactos As New DataTable

    '        Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTA_CONTACTOS", 4, MyCodigoCliente, 2}
    '        Try
    '            rstContactos = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
    '            daContactos.Fill(dtContactos, rstContactos)
    '            cmbContactoDireccion.DataSource = dtContactos.DefaultView
    '            cmbContactoDireccion.DisplayMember = "NOMBRE_APELLIDO"
    '            cmbContactoDireccion.ValueMember = "IDCONTACTO_PERSONA"
    '        Catch Qex As Exception
    '            MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try

    '    End If
    'End If
    'End Sub

    Private Sub CargaCombosDirecciones()
        dtPaisDireciones = dtPaisCombo.Copy
        dtDepartDirecciones = dtDepartamentoCombo.Copy
        dtProvDirecciones = dtProvinciaCombo.Copy
        dtDistDirecciones = dtDistritoCombo.Copy

        dvPaisDireciones = dtPaisDireciones.DefaultView
        dvDepartDirecciones = dtDepartDirecciones.DefaultView
        dvProvDirecciones = dtProvDirecciones.DefaultView
        dvDistDirecciones = dtDistDirecciones.DefaultView

        cmbPaisDirecciones.DataSource = dvPaisDireciones
        cmbPaisDirecciones.DisplayMember = "PAIS"
        cmbPaisDirecciones.ValueMember = "IDPAIS"

        Dim FiltroDepart As String = ""
        Dim MyParmD As Integer = cmbPaisDirecciones.SelectedValue
        FiltroDepart = "IDPAIS = '" & MyParmD & "'"
        dvDepartDirecciones.RowFilter = FiltroDepart
        cmbDepartamentoDirecciones.DataSource = dvDepartDirecciones
        cmbDepartamentoDirecciones.DisplayMember = "DEPARTAMENTO"
        cmbDepartamentoDirecciones.ValueMember = "IDDEPARTAMENTO"

        Dim FiltroProv As String = ""
        Dim MyParmP As Integer = cmbProvinciaDirecciones.SelectedValue
        FiltroProv = "IDDEPARTAMENTO = '" & MyParmP & "'"
        dvProvDirecciones.RowFilter = FiltroProv
        cmbProvinciaDirecciones.DataSource = dvProvDirecciones
        cmbProvinciaDirecciones.DisplayMember = "PROVINCIA"
        cmbProvinciaDirecciones.ValueMember = "IDPROVINCIA"

        Dim FiltroDist As String = ""
        Dim MyParmDs As Integer = cmbDistritoDirecciones.SelectedValue
        FiltroDist = "IDPROVINCIA = '" & MyParmDs & "'"
        dvDistDirecciones.RowFilter = FiltroDist
        cmbDistritoDirecciones.DataSource = dvDistDirecciones
        cmbDistritoDirecciones.DisplayMember = "DSITRITO"
        cmbDistritoDirecciones.ValueMember = "IDDISTRITO"
    End Sub


    Private Sub FrmClientes_MenuNuevo() Handles Me.MenuNuevo
        Try
            chkBase.Checked = True
            chkLinea.Checked = False
            txtDescuento.Text = "0.00"
            TxtSobregiro.Text = ""
            txtLinea.Text = ""
            TxtTotalAsignado.Text = ""

            bClienteActualizado = False
            dvTipoDireccion.RowFilter = "TIPO_DIRECCION='LEGAL'" 'Para Obligar al Usuario a Ingresar por lo menos una direccion Legal.
            btnTipoDireccion.Enabled = False
            Me.chkDireccionFacturacion.Checked = True
            Me.chkDireccionFacturacion.Enabled = False
            Me.txtNumDoctoContacto.ReadOnly = False
            Me.txtNumDoctoContacto.BackColor = Color.White

            Me.SelectMenu(1)
            MenuTab.Items(0).Enabled = False
            MenuTab.Items(1).Enabled = True
            MenuTab.Items(2).Enabled = True
            MenuTab.Items(3).Enabled = True
            MenuTab.Items(4).Enabled = True
            cmbTipoPersona.SelectedIndex = 0
            vAccionRegistro = 1
            Paso1 = 0
            txtFuncionarioCuenta.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
            txtRespFacturacion.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
            txtFuncionarioCuenta.Text = ""
            txtRespFacturacion.Text = ""
            btnFuncionarioCta.Enabled = True
            btnRespFactura.Enabled = True
            chkContadoCredito.Enabled = True
            chkContadoCredito.Checked = False

            dgvContactos.Visible = True

            dgvTelefonosContacto.Visible = True

            SplitContainer2.Panel1Collapsed = True
            NuevoToolStripMenuItem.Enabled = False
            EdicionToolStripMenuItem.Enabled = False
            CancelarToolStripmenuItem.Enabled = True
            CancelarToolStripmenuItem.Visible = True
            GrabarToolStripMenuItem.Enabled = True
            EliminarToolStripMenuItem.Enabled = False
            ExportarToolStripMenuItem.Enabled = False
            ImprimirToolStripMenuItem.Enabled = False

            ''''''''''''''''''''''''''''''''''''''''''''

            'If MyRol = 11 Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 1) Then
                Me.btnFuncionarioCta.Enabled = False
                Me.txtFuncionarioCuenta.Text = "Funcionario Sesion Activa."
            Else
                Me.btnFuncionarioCta.Enabled = True
                Me.txtFuncionarioCuenta.Text = ""
            End If
            ''''''''''''''''''''''''''''''''''''''''''''

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema")
        End Try

    End Sub

    Private Sub cmbTipoPersona_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoPersona.SelectedIndexChanged
        If cmbTipoPersona.SelectedIndex = 0 Then '"JURIDICA"
            EstableceTabIndexJuridica(GroupBoxDatosPersonales, txtNombreP, txtNombreS, txtApellidoP, txtApellidoM, cmbTipoDocIdent, txtNumeroDocto, _
                                      txtFechaNacimiento, txtCorreoElectronico, btnTipoDocumentoCliente, lblNombreP, lblNombreS, lblApellidoP, _
                                      lblApellidoM, lblDocumentotoIdentidad, lblFechaNacimiento, lblEmail, txtRazonSocial, txtRUC, txtGG, txtRepLegal, _
                                      txtWebSite, lblRazonSocial, lblRUC, lblGG, lblRepLegal, lblEBusiness, lblSexo, rdbSexoMasCliente, rdbSexoFemCliente)

            cmbClasPersona.SelectedValue = 6
            chkCorporativo.Checked = False
            chkCorporativo.Enabled = True
            chkPostFacturacion.Checked = False
            chkPostFacturacion.Enabled = True
            chkContadoCredito.Checked = False
            chkContadoCredito.Enabled = True

            If Not dvRubro Is Nothing Then
                dvRubro.RowFilter = "IDRUBRO <> 1"
            End If
            cmbRubroEmpresarial.SelectedValue = 2
            btnRubroEmpresarial.Enabled = True

        End If

        If cmbTipoPersona.SelectedIndex = 1 Then '"NATURAL"
            EstableceTabIndexNatural(GroupBoxDatosPersonales, txtNombreP, txtNombreS, txtApellidoP, txtApellidoM, cmbTipoDocIdent, txtNumeroDocto, _
                                      txtFechaNacimiento, txtCorreoElectronico, btnTipoDocumentoCliente, lblNombreP, lblNombreS, lblApellidoP, _
                                      lblApellidoM, lblDocumentotoIdentidad, lblFechaNacimiento, lblEmail, txtRazonSocial, txtRUC, txtGG, txtRepLegal, _
                                      txtWebSite, lblRazonSocial, lblRUC, lblGG, lblRepLegal, lblEBusiness, lblSexo, rdbSexoMasCliente, rdbSexoFemCliente)

            cmbTipoDocIdent.SelectedValue = 3
            cmbClasPersona.SelectedValue = 6
            chkCorporativo.Checked = False
            chkCorporativo.Enabled = False
            chkPostFacturacion.Checked = False
            chkPostFacturacion.Enabled = False
            chkContadoCredito.Checked = False
            chkContadoCredito.Enabled = True

            If Not dvRubro Is Nothing Then
                dvRubro.RowFilter = "IDRUBRO = 1" '& cmbRubroEmpresarial.SelectedValue
            End If
            cmbRubroEmpresarial.SelectedValue = 1
            btnRubroEmpresarial.Enabled = False
        End If
    End Sub
    Private Sub cmbPais_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPais.SelectedIndexChanged
        If dvPais Is Nothing Then
            'Esta Vacio.
        Else
            Dim filCb As Integer
            Dim drc As DataRowView
            Dim valor As String
            filCb = cmbPais.SelectedIndex
            If filCb >= 0 Then
                drc = dvPais.Item(filCb)
                valor = IIf(IsDBNull(drc("IDPAIS")) = True, "0", drc("IDPAIS").ToString)
                dvDepartamento.RowFilter = "IDPAIS =" & valor
            Else
                dvDepartamento.RowFilter = "IDPAIS = 0"
            End If
        End If
    End Sub
    Private Sub cmbDepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDepartamento.SelectedIndexChanged
        If dvDepartamento Is Nothing Then
            'Esta Vacio
        Else
            Dim filCb As Integer
            Dim drc As DataRowView
            Dim valor As String
            filCb = cmbDepartamento.SelectedIndex
            If filCb >= 0 Then
                drc = dvDepartamento.Item(filCb)
                valor = IIf(IsDBNull(drc("IDDEPARTAMENTO")) = True, "0", drc("IDDEPARTAMENTO").ToString)
                dvProvincia.RowFilter = "IDDEPARTAMENTO =" & valor
            Else
                dvProvincia.RowFilter = "IDDEPARTAMENTO = 0"
            End If

        End If
    End Sub

    Private Sub cmbProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProvincia.SelectedIndexChanged
        If dvProvincia Is Nothing Then
            'Esta Vacio
        Else
            Dim filCb As Integer
            Dim drc As DataRowView
            Dim valor As String
            filCb = cmbProvincia.SelectedIndex
            If filCb >= 0 Then
                drc = dvProvincia.Item(filCb)
                valor = IIf(IsDBNull(drc("IDPROVINCIA")) = True, "0", drc("IDPROVINCIA").ToString)
                dvDistrito.RowFilter = "IDPROVINCIA =" & valor
            Else
                dvDistrito.RowFilter = "IDPROVINCIA = 0"
            End If
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Try

            'Dim MyObligatorios() As Object = {Me.txtNumDoctoContacto, Me.txtNombrePCont, Me.txtApellidoPCont, Me.txtApellidoMCont, Me.lblSexoContacto, Me.rbtMasculino, Me.rbtFemenino, Me.dgvTelefonosContacto}
            Me.TXT_IDCONTACTO_PERSONA.Text = ""  'Modificado el día 05/07/2007 
            Dim MyObligatorios() As Object = {Me.txtNumDoctoContacto, Me.txtNombrePCont, Me.lblSexoContacto, Me.rbtMasculino, Me.rbtFemenino, Me.dgvTelefonosContacto}
            If Funciones.Validaciones(MyObligatorios) = 0 Then
                Try
                    drwContactos = dtContactos.NewRow
                    drwContactos("ORDEN") = dgvContactos.RowCount
                    drwContactos("TIPO_CONTACTO") = cmbTipoContacto.Text '"Empleado"
                    drwContactos("TIPO_DOC_IDENTIDAD") = cmbTipoDoctoContacto.Text '"DNI"
                    drwContactos("NRODOCUMENTO") = txtNumDoctoContacto.Text '"42276653"
                    drwContactos("NOMBRE_APELLIDOS") = txtNombrePCont.Text & ", " & txtApellidoPCont.Text & " " & txtApellidoMCont.Text '"Richard Vasquez Cuyotupac"

                    If chkActivoContacto.Checked = True Then
                        drwContactos("ESTADO_REGISTRO") = True
                    Else
                        drwContactos("ESTADO_REGISTRO") = False
                    End If
                    ' Debe agregar el campo idcontacto_persona - Omendoza

                    dtContactos.Rows.Add(drwContactos)

                    Call AgregarContactoJuridico(1)

                    Call CargarListaContactos()

                    dtGrillaTelefonos.Clear()
                    dtComboGrilla.Clear()
                    Call GeneraDetalleTelefonos(Me.dgvTelefonosContacto)

                    Try 'Limpieza de TextBox
                        For Each MyObj As Object In TabPage1.Controls
                            If TypeOf MyObj Is TextBox Then
                                CType(MyObj, TextBox).Text = ""
                            End If
                        Next
                        dtComunicacionContac.Clear()
                    Catch Qex As Exception
                        MessageBox.Show(Qex.Message, "Seguridad Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Catch Pex As System.Data.ConstraintException
                    MessageBox.Show("Ya existe un Contacto con Dcto. Identidad: " & txtNumDoctoContacto.Text, "Seguridad Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch Qex As Exception

                    MessageBox.Show(Qex.Message, "Seguridad Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Dim iContactoPersona As Integer
        Try
            'Dim MyObligatorios() As Object = {Me.txtNumDoctoContacto, Me.txtNombrePCont, Me.txtApellidoPCont, Me.txtApellidoMCont, Me.lblSexoContacto, Me.rbtMasculino, Me.rbtFemenino}
            Dim MyObligatorios() As Object = {Me.txtNumDoctoContacto, Me.txtNombrePCont, Me.lblSexoContacto, Me.rbtMasculino, Me.rbtFemenino}
            If Funciones.Validaciones(MyObligatorios) = 0 Then
                Dim dgvr As DataGridViewRow = Me.dgvContactos.CurrentRow
                iContactoPersona = CType(dgvr.Cells("IDCONTACTO_PERSONA").Value, Integer)
                dgvr.Cells("TIPO_CONTACTO").Value = cmbTipoContacto.Text
                dgvr.Cells("TIPO_DOC_IDENTIDAD").Value = cmbTipoDoctoContacto.Text
                dgvr.Cells("NOMBRE_APELLIDOS").Value = txtNombrePCont.Text & ", " & txtApellidoPCont.Text & " " & txtApellidoMCont.Text '"Richard Vasquez Cuyotupac"
                If chkActivoContacto.Checked = True Then
                    dgvr.Cells("ESTADO_REGISTRO").Value = True
                Else
                    dgvr.Cells("ESTADO_REGISTRO").Value = False
                End If

                Call ActualizaContactoJuridico(2)

                Call CargarListaContactos() 'Para refrescar la Grilla de COntactos

                Me.cmbAreaEmpresa.Enabled = True
                Me.cmbTipoContacto.Enabled = True
                Me.btnAreaEmpresa.Enabled = True
                Me.btnTipoContacto.Enabled = True

                dtGrillaTelefonos.Clear()
                dtComboGrilla.Clear()
                Call GeneraDetalleTelefonos(Me.dgvTelefonosContacto)
                Call CargarListaTelefonos(iContactoPersona, Me.dgvTelefonosContacto)
                For Each MyObj As Object In TabPage1.Controls
                    If TypeOf MyObj Is TextBox Then
                        CType(MyObj, TextBox).Text = ""
                    End If
                Next
                dtComunicacionContac.Clear()

                Me.txtNumDoctoContacto.ReadOnly = False
                Me.txtNumDoctoContacto.BackColor = Color.White
                '
                Me.btnAgregar.Enabled = True
                Me.btnActualizar.Enabled = False
            Else
                MessageBox.Show("Seleccione un contacto")
            End If
        Catch Pex As System.Data.ConstraintException
            MessageBox.Show("Ya existe un Contacto con Docto. Identidad: " & txtNumDoctoContacto.Text, "Seguridad Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub FrmClientes_MenuGrabar() Handles Me.MenuGrabar

        If vAccionRegistro = 1 Then 'Se trata de una Insercion.
            If cmbTipoPersona.SelectedValue = 1 Then '"JURIDICA"
                'Dim MyObligatorios() As Object = {Me.txtRazonSocial, Me.txtRUC, Me.txtGG, Me.txtRepLegal, Me.cmbRubroEmpresarial, Me.btnRubroEmpresarial, Me.cmbClasPersona, Me.btnClasPersona, Me.txtFuncionarioCuenta, Me.btnFuncionarioCta, Me.txtRespFacturacion, Me.btnRespFactura, Me.cmbPais, Me.btnPais, Me.cmbDepartamento, Me.btnDepartamento, Me.cmbProvincia, Me.btnProvincia, Me.cmbDistrito, Me.btnDistrito}
                Dim MyObligatorios() As Object = {Me.txtRazonSocial, Me.txtRUC, Me.txtGG, Me.txtRepLegal, Me.cmbRubroEmpresarial, Me.btnRubroEmpresarial, Me.cmbClasPersona, Me.btnClasPersona, Me.txtFuncionarioCuenta, Me.btnFuncionarioCta, Me.cmbPais, Me.btnPais, Me.cmbDepartamento, Me.btnDepartamento, Me.cmbProvincia, Me.btnProvincia, Me.cmbDistrito, Me.btnDistrito}
                If Funciones.Validaciones(MyObligatorios) = 0 Then 'Si todo esta bien...
                    GrabaJuridica()
                    If b_cancelo = True Then
                        b_cancelo = False
                        Exit Sub
                    End If
                    'Omendoza - 20/06/2007 
                    'Si cliente existe traer la pantalla con los datos necesarios
                    '  Para actualizar los datos, siempre que el cliente sea contado 
                    'Fsi
                    '
                    'GeneraDetalleContactos()
                    CargarListaContactos()
                    GeneraDetalleTelefonos(Me.dgvTelefonosContacto)
                    'CargarListaTelefonos(0)
                    btnAgregar.Visible = True
                    btnActualizar.Visible = True
                End If
            End If

            If cmbTipoPersona.SelectedValue = 2 Then '"NATURAL"
                'Dim MyObligatorios() As Object = {Me.txtNombreP, Me.txtNombreS, Me.txtApellidoP, Me.txtApellidoM, Me.txtNumeroDocto, Me.txtFechaNacimiento, Me.cmbRubroEmpresarial, Me.btnRubroEmpresarial, Me.cmbClasPersona, Me.btnClasPersona, Me.txtFuncionarioCuenta, Me.btnFuncionarioCta, Me.txtRespFacturacion, Me.btnRespFactura, Me.lblSexo, Me.rdbSexoFemCliente, Me.rdbSexoMasCliente, Me.cmbPais, Me.btnPais, Me.cmbDepartamento, Me.btnDepartamento, Me.cmbProvincia, Me.btnProvincia, Me.cmbDistrito, Me.btnDistrito}
                'Dim MyObligatorios() As Object = {Me.txtNombreP, Me.txtNombreS, Me.txtApellidoP, Me.txtApellidoM, Me.txtNumeroDocto, Me.txtFechaNacimiento, Me.cmbRubroEmpresarial, Me.btnRubroEmpresarial, Me.cmbClasPersona, Me.btnClasPersona, Me.txtFuncionarioCuenta, Me.btnFuncionarioCta, Me.lblSexo, Me.rdbSexoFemCliente, Me.rdbSexoMasCliente, Me.cmbPais, Me.btnPais, Me.cmbDepartamento, Me.btnDepartamento, Me.cmbProvincia, Me.btnProvincia, Me.cmbDistrito, Me.btnDistrito}
                Dim MyObligatorios() As Object = {Me.txtNombreP, Me.txtApellidoP, Me.txtApellidoM, Me.txtNumeroDocto, Me.txtFechaNacimiento, Me.cmbRubroEmpresarial, Me.btnRubroEmpresarial, Me.cmbClasPersona, Me.btnClasPersona, Me.txtFuncionarioCuenta, Me.btnFuncionarioCta, Me.lblSexo, Me.rdbSexoFemCliente, Me.rdbSexoMasCliente, Me.cmbPais, Me.btnPais, Me.cmbDepartamento, Me.btnDepartamento, Me.cmbProvincia, Me.btnProvincia, Me.cmbDistrito, Me.btnDistrito}
                If Funciones.Validaciones(MyObligatorios) = 0 Then 'Si todo esta bien...
                    GrabaNatural()
                    'GeneraDetalleContactos()
                    CargarListaContactos()
                    GeneraDetalleTelefonos(Me.dgvTelefonosContacto)
                    'GeneraDetalleTelefonos()
                    btnAgregar.Visible = True
                    btnActualizar.Visible = True
                End If
            End If
        End If

        If vAccionRegistro = 2 Then 'Edicion es decir Actualizaciones.
            If cmbTipoPersona.SelectedValue = 1 Then '"JURIDICA"
                'Dim MyObligatorios() As Object = {Me.txtRazonSocial, Me.txtRUC, Me.txtGG, Me.txtRepLegal, Me.cmbRubroEmpresarial, Me.btnRubroEmpresarial, Me.cmbClasPersona, Me.btnClasPersona, Me.txtFuncionarioCuenta, Me.btnFuncionarioCta, Me.txtRespFacturacion, Me.btnRespFactura, Me.cmbPais, Me.btnPais, Me.cmbDepartamento, Me.btnDepartamento, Me.cmbProvincia, Me.btnProvincia, Me.cmbDistrito, Me.btnDistrito}
                Dim MyObligatorios() As Object = {Me.txtRazonSocial, Me.txtRUC, Me.txtGG, Me.txtRepLegal, Me.cmbRubroEmpresarial, Me.btnRubroEmpresarial, Me.cmbClasPersona, Me.btnClasPersona, btnFuncionarioCta, Me.cmbPais, Me.btnPais, Me.cmbDepartamento, Me.btnDepartamento, Me.cmbProvincia, Me.btnProvincia, Me.cmbDistrito, Me.btnDistrito}
                If Funciones.Validaciones(MyObligatorios) = 0 Then 'Si todo esta bien...
                    GrabaJuridica()
                    CargarListaContactos()
                    GeneraDetalleTelefonos(Me.dgvTelefonosContacto) 'Cuestiones Visuales Nada Mas.
                    btnAgregar.Visible = True
                    btnActualizar.Visible = True
                End If
            End If

            If cmbTipoPersona.SelectedValue = 2 Then '"NATURAL"
                'Dim MyObligatorios() As Object = {Me.txtNombreP, Me.txtNombreS, Me.txtApellidoP, Me.txtApellidoM, Me.txtNumeroDocto, Me.txtFechaNacimiento, Me.cmbRubroEmpresarial, Me.btnRubroEmpresarial, Me.cmbClasPersona, Me.btnClasPersona, Me.txtFuncionarioCuenta, Me.btnFuncionarioCta, Me.txtRespFacturacion, Me.btnRespFactura, Me.lblSexo, Me.rdbSexoFemCliente, Me.rdbSexoMasCliente, Me.cmbPais, Me.btnPais, Me.cmbDepartamento, Me.btnDepartamento, Me.cmbProvincia, Me.btnProvincia, Me.cmbDistrito, Me.btnDistrito}
                'Dim MyObligatorios() As Object = {Me.txtNombreP, Me.txtNombreS, Me.txtApellidoP, Me.txtApellidoM, Me.txtNumeroDocto, Me.txtFechaNacimiento, Me.cmbRubroEmpresarial, Me.btnRubroEmpresarial, Me.cmbClasPersona, Me.btnClasPersona, Me.txtFuncionarioCuenta, Me.btnFuncionarioCta, Me.lblSexo, Me.rdbSexoFemCliente, Me.rdbSexoMasCliente, Me.cmbPais, Me.btnPais, Me.cmbDepartamento, Me.btnDepartamento, Me.cmbProvincia, Me.btnProvincia, Me.cmbDistrito, Me.btnDistrito}
                Dim MyObligatorios() As Object = {Me.txtNombreP, Me.txtApellidoP, Me.txtApellidoM, Me.txtNumeroDocto, Me.txtFechaNacimiento, Me.cmbRubroEmpresarial, Me.btnRubroEmpresarial, Me.cmbClasPersona, Me.btnClasPersona, Me.txtFuncionarioCuenta, Me.btnFuncionarioCta, Me.lblSexo, Me.rdbSexoFemCliente, Me.rdbSexoMasCliente, Me.cmbPais, Me.btnPais, Me.cmbDepartamento, Me.btnDepartamento, Me.cmbProvincia, Me.btnProvincia, Me.cmbDistrito, Me.btnDistrito}
                If Funciones.Validaciones(MyObligatorios) = 0 Then 'Si todo esta bien...
                    GrabaNatural()
                    'GeneraDetalleContactos()
                    CargarListaContactos()
                    GeneraDetalleTelefonos(Me.dgvTelefonosContacto)
                    'GeneraDetalleTelefonos()
                    btnAgregar.Visible = True
                    btnActualizar.Visible = True
                End If
            End If
        End If
        ' Refrescando los datos en la grilla 
        If lb_principal = True Then
            DataGridLista.Columns.Clear()
            dvListaPersona = Funciones.CargarGrillaClientes(Me.DataGridLista)
            Dim FiltroLista As String = "IDTIPO_PERSONA ='" & 1 & "'"
            dvListaPersona.RowFilter = FiltroLista
            DataGridLista.Columns(4).Visible = True  'Modificado por Tepsa
            DataGridLista.Columns(5).Visible = False
            DataGridLista.Columns(40).Visible = False
        Else
            'MessageBox.Show("Cargar por Funcionario")
            For i As Integer = 0 To MyTreeView.Nodes(0).Nodes.Count - 1
                If MyTreeView.Nodes(0).Nodes(i).Checked = True Then
                    DataGridLista.Columns.Clear()
                    dvListaPersona = Funciones.CargarGrillaClientes(Me.DataGridLista, MyTreeView.Nodes(0).Nodes(i).Text)
                    'Dim FiltroLista As String = "IDTIPO_PERSONA = 1 AND FUNCIONARIO ='" & MyTreeView.Nodes(0).Nodes(i).Text & "'"
                    ''dvListaPersona.RowFilter = FiltroLista
                    DataGridLista.Columns(4).Visible = True  'Modificado por Tepsa
                    DataGridLista.Columns(5).Visible = False
                    DataGridLista.Columns(40).Visible = False
                End If
            Next
        End If
    End Sub

    Private Sub CancelaIngreso_eliminarlo(ByVal CodigoCliente As String)
        'Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_CANCELA_INS_PERSONA", 4, CodigoCliente, 2}
        'VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    End Sub

    Private Sub FrmClientes_MenuCancelar() Handles Me.MenuCancelar
        Try
            MenuStrip1.Items(2).Text = "&Cancelar"
            'If vAccionRegistro = 1 And Paso1 = 0 And Paso2 = 0 And Paso3 = 0 Then
            If vAccionRegistro = 1 And Not (bClienteActualizado) And Paso2 = 0 And Paso3 = 0 Then
                SelectMenu(0)
                SplitContainer2.Panel1Collapsed = False
                NuevoToolStripMenuItem.Enabled = True
                EdicionToolStripMenuItem.Enabled = True
                CancelarToolStripmenuItem.Enabled = False
                CancelarToolStripmenuItem.Visible = False
                GrabarToolStripMenuItem.Enabled = False
                EliminarToolStripMenuItem.Enabled = True
                ExportarToolStripMenuItem.Enabled = True
                ImprimirToolStripMenuItem.Enabled = True
            End If

            'If vAccionRegistro = 1 And Paso1 = 1 And Paso2 = 0 And Paso3 = 0 Then
            If vAccionRegistro = 1 And bClienteActualizado And Paso2 = 0 And Paso3 = 0 Then
                'OBLIGAR A QUE INGRESE UN CONTACTO Y UNA DIRECCION
                'Dim resp As DialogResult = MessageBox.Show("Tiene que ingresar al menos un Contacto y una Dirección," & vbCrLf & "¿Desea cancelar el Registro de este nuevo Cliente?", "Seguridad del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                'If resp = Windows.Forms.DialogResult.Yes Then
                'MessageBox.Show("Procedimiento de Eliminacion de Cliente y todos los foreing Keys")
                If cmbTipoPersona.Text = "JURIDICA" Then
                    'Call CancelaIngreso(Me.txtRUC.Text)
                    Paso1 = 0
                    bClienteActualizado = False
                    Paso2 = 0
                    Paso3 = 0
                ElseIf cmbTipoPersona.Text = "NATURAL" Then
                    'Call CancelaIngreso(Me.txtNumeroDocto.Text)
                    Paso1 = 0
                    bClienteActualizado = False
                    Paso2 = 0
                    Paso3 = 0
                End If
                SelectMenu(0)
                SplitContainer2.Panel1Collapsed = False
                NuevoToolStripMenuItem.Enabled = True
                EdicionToolStripMenuItem.Enabled = True
                CancelarToolStripmenuItem.Enabled = False
                CancelarToolStripmenuItem.Visible = False
                GrabarToolStripMenuItem.Enabled = False
                EliminarToolStripMenuItem.Enabled = True
                ExportarToolStripMenuItem.Enabled = True
                ImprimirToolStripMenuItem.Enabled = True

                Call LimpiaPersona()
                Call LimpiaContactos()
                Call LimpiaDirecciones()
                'Call LimpiaCheckBox()  'Tepsa - 30092006
            End If
            'End If

            'If vAccionRegistro = 1 And Paso1 = 1 And Paso2 = 1 And Paso3 = 0 Then
            If vAccionRegistro = 1 And bClienteActualizado And Paso2 = 1 And Paso3 = 0 Then
                'OBLIGAR A QUE INGRESE UNA DIRECCION
                'Dim resp As DialogResult = MessageBox.Show("Tiene que ingresar al menos una Dirección," & vbCrLf & "¿Desea cancelar el Registro de este nuevo Cliente?", "Seguridad del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                'If resp = Windows.Forms.DialogResult.Yes Then
                'MessageBox.Show("Procedimiento de Eliminacion de Cliente y todos los foreing Keys")
                If cmbTipoPersona.Text = "JURIDICA" Then
                    'Call CancelaIngreso(Me.txtRUC.Text)
                    Paso1 = 0
                    bClienteActualizado = False
                    Paso2 = 0
                    Paso3 = 0
                ElseIf cmbTipoPersona.Text = "NATURAL" Then
                    'Call CancelaIngreso(Me.txtNumeroDocto.Text)
                    Paso1 = 0
                    bClienteActualizado = False
                    Paso2 = 0
                    Paso3 = 0
                End If
                SelectMenu(0)
                SplitContainer2.Panel1Collapsed = False
                NuevoToolStripMenuItem.Enabled = True
                EdicionToolStripMenuItem.Enabled = True
                CancelarToolStripmenuItem.Enabled = False
                CancelarToolStripmenuItem.Visible = False
                GrabarToolStripMenuItem.Enabled = False
                EliminarToolStripMenuItem.Enabled = True
                ExportarToolStripMenuItem.Enabled = True
                ImprimirToolStripMenuItem.Enabled = True

                Call LimpiaPersona()
                Call LimpiaContactos()
                Call LimpiaDirecciones()
                'Call LimpiaCheckBox()  'Tepsa - 30092006
            End If
            'End If

            'If vAccionRegistro = 1 And Paso1 = 1 And Paso2 = 1 And Paso3 = 1 Then
            If vAccionRegistro = 1 And bClienteActualizado And Paso2 = 1 And Paso3 = 1 Then
                DataGridLista.Columns.Clear()
                MyTreeView.Nodes(0).Checked = False

                SelectMenu(0)
                SplitContainer2.Panel1Collapsed = False
                NuevoToolStripMenuItem.Enabled = True
                EdicionToolStripMenuItem.Enabled = True
                CancelarToolStripmenuItem.Enabled = False
                CancelarToolStripmenuItem.Visible = False
                GrabarToolStripMenuItem.Enabled = False
                EliminarToolStripMenuItem.Enabled = True
                ExportarToolStripMenuItem.Enabled = True
                ImprimirToolStripMenuItem.Enabled = True

                Call LimpiaPersona()
                Call LimpiaContactos()
                Call LimpiaDirecciones()
                Call LimpiaCheckBox()
            End If

            If vAccionRegistro = 2 Then
                'dvTipoDireccion.RowFilter = "TIPO_DIRECCION ='LEGAL'"
                dvTipoDireccion.RowFilter = "" 'Para Obligar al Usuario a Ingresar por lo menos una direccion Legal.
                btnTipoDireccion.Enabled = True

                Me.txtNumDoctoContacto.ReadOnly = False
                Me.txtNumDoctoContacto.BackColor = Color.White

                MenuTab.Items(0).Enabled = True
                MenuTab.Items(1).Enabled = False
                MenuTab.Items(2).Enabled = False
                MenuTab.Items(3).Enabled = False
                MenuTab.Items(4).Enabled = False

                txtFuncionarioCuenta.ReadOnly = False
                txtRespFacturacion.ReadOnly = False
                cmbTipoPersona.Enabled = True
                cmbTipoPersona.BackColor = Color.White
                txtFuncionarioCuenta.BackColor = Color.White
                txtRespFacturacion.BackColor = Color.White

                Paso1 = 0
                bClienteActualizado = False
                Paso2 = 0
                Paso3 = 0
                vAccionRegistro = 0

                Call LimpiaPersona()
                Call LimpiaContactos()
                Call LimpiaDirecciones()
                Call LimpiaCheckBox()

                SelectMenu(0)
                SplitContainer2.Panel1Collapsed = False
                NuevoToolStripMenuItem.Enabled = True
                EdicionToolStripMenuItem.Enabled = True
                CancelarToolStripmenuItem.Enabled = False
                CancelarToolStripmenuItem.Visible = False
                GrabarToolStripMenuItem.Enabled = False
                EliminarToolStripMenuItem.Enabled = True
                ExportarToolStripMenuItem.Enabled = True
                ImprimirToolStripMenuItem.Enabled = True
            End If

            Me.btnAgregar.Enabled = True
            Me.btnActualizar.Enabled = False
            Me.btnAgregarDireccion.Enabled = True
            Me.btnActualizarDireccion.Enabled = False

            MenuTab.Items(0).Enabled = True
            MenuTab.Items(1).Enabled = False
            MenuTab.Items(2).Enabled = False
            MenuTab.Items(3).Enabled = False
            MenuTab.Items(4).Enabled = False
            'Modifcado - 06/07/2007 
            If MyRol = 11 Then  ' Solo el funcionario de negocio 
                'dvListaPersona = CargarGrillaClientes_x_funcionario(MyUsuario, Me.DataGridLista)
                'DataGridLista.Columns(4).Visible = True
                'DataGridLista.Columns(5).Visible = False
                'DataGridLista.Columns(40).Visible = False
                'Me.btnCargarClientes.Enabled = False
                'Me.MyTreeView.ExpandAll()
            End If
            '

            bClienteActualizado = False
        Catch Qex As Exception
        End Try

    End Sub

    Private Sub FrmClientes_MenuEditar() Handles Me.MenuEditar
        Try
            If Me.DataGridLista.RowCount > 0 Then
                Dim dgvr As DataGridViewRow = Me.DataGridLista.CurrentRow()
                If Not dgvr Is Nothing Then
                    'Línea de Crédito
                    iId = CType(dgvr.Cells("ID").Value, Integer)

                    'datahelper
                    'Dim rst As ADODB.Recordset
                    'If Not rst.BOF And Not rst.EOF Then
                    'If CType(rst("ES_ACTIVO").Value, Boolean) Then
                    Dim rst As DataTable
                    rst = sp_linea_credito()

                    If rst.Rows.Count > 0 Then
                        If CType(rst.Rows(0).Item("ES_ACTIVO"), Boolean) Then
                            chkLinea.Checked = True
                        Else
                            chkLinea.Checked = False
                        End If
                    Else
                        chkLinea.Checked = False
                    End If
                    txtDescuento.Text = Format(CType(dgvr.Cells("DESCUENTO").Value, Double), "0.00")

                    'datahelper
                    'rst = New ADODB.Recordset
                    'rst = sp_linea_credito()
                    'If Not rst.BOF And Not rst.EOF Then
                    'txtLinea.Text = FormatNumber(rst("linea_solicitada").Value, 2)
                    'TxtTotalAsignado.Text = FormatNumber(rst("total").Value, 2)
                    'TxtSobregiro.Text = FormatNumber(rst("sobregiro").Value, 2)
                    rst = sp_linea_credito()
                    If rst.Rows.Count > 0 Then
                        txtLinea.Text = FormatNumber(rst.Rows(0).Item("linea_solicitada").ToString, 2)
                        TxtTotalAsignado.Text = FormatNumber(rst.Rows(0).Item("total").ToString, 2)
                        TxtSobregiro.Text = FormatNumber(rst.Rows(0).Item("sobregiro").ToString, 2)
                    Else
                        txtLinea.Text = ""
                        TxtTotalAsignado.Text = ""
                        TxtSobregiro.Text = ""
                    End If

                    bClienteActualizado = True

                    'MessageBox.Show("No esta nulo")
                    vAccionRegistro = 2

                    'dgvContactosActualiza.Visible = True
                    dgvContactos.Visible = True

                    'dgvActualizaTelefonosContacto.Visible = False
                    dgvTelefonosContacto.Visible = True

                    If CType(dgvr.Cells("JURIDICAONATURAL").Value, Integer) = 1 Then '"JURIDICA"
                        DeshabilitaControlesEdicion()

                        'iContactoPersona = dgvr.Cells("idContacto_Persona").Value
                        Me.cmbTipoPersona.SelectedValue = CType(dgvr.Cells("JURIDICAONATURAL").Value, Integer)
                        vIDPersona = CType(dgvr.Cells("ID").Value, Integer)
                        Me.txtCodigo.Text = CType(dgvr.Cells("CODIGO").Value, String)
                        Me.txtRazonSocial.Text = CType(dgvr.Cells("RAZONSOCIAL").Value, String)
                        Me.txtRUC.Text = CType(dgvr.Cells("DOCUMENTO").Value, String)
                        Me.txtGG.Text = IIf(IsDBNull(dgvr.Cells("GERENTE_GENERAL").Value) = True, "", dgvr.Cells("GERENTE_GENERAL").Value)
                        Me.txtRepLegal.Text = IIf(IsDBNull(dgvr.Cells("REPRESENTANTE_LEGAL").Value) = True, "", dgvr.Cells("REPRESENTANTE_LEGAL").Value)
                        If IsDBNull(dgvr.Cells("EMAIL").Value) Then
                            Me.txtWebSite.Text = ""
                        Else
                            Me.txtWebSite.Text = CType(dgvr.Cells("EMAIL").Value, String)
                        End If

                        Me.txtFechaRegistro._MyFecha = CType(dgvr.Cells("FECHA_INGRESO").Value, String)
                        Me.chkCorporativo.Checked = CType(dgvr.Cells("CLIENTE_CORPORATIVO").Value, Boolean)
                        If Me.chkCorporativo.Checked = False Then 'Tepsa si no es corporativo, va hacer contado 
                            Me.chkContadoCredito.Checked = True
                        End If
                        Me.chkPostFacturacion.Checked = CType(dgvr.Cells("PAGO_POST_FACTURACION").Value, Boolean)
                        Me.chkAgenteRetencion.Checked = CType(dgvr.Cells("AGENTE_RETENCION").Value, Boolean)
                        Me.cmbRubroEmpresarial.SelectedValue = CType(dgvr.Cells("IDRUBRO").Value, Integer)
                        Me.cmbClasPersona.SelectedValue = CType(IIf(IsDBNull(dgvr.Cells("IDCLASIFICACION_PERSONA").Value), -1, dgvr.Cells("IDCLASIFICACION_PERSONA").Value), Integer)
                        Me.txtFuncionarioCuenta.Text = CType(dgvr.Cells("FUNCIONARIO").Value, String)
                        If IsDBNull(dgvr.Cells("IDFUNCIONARIO_ACTUAL").Value) Then
                            CodFuncionarioNegocio = 0
                        Else
                            CodFuncionarioNegocio = CType(dgvr.Cells("IDFUNCIONARIO_ACTUAL").Value, Integer)
                        End If
                        Me.cmbPais.SelectedValue = CType(dgvr.Cells("IDPAIS").Value, String)
                        Me.cmbDepartamento.SelectedValue = CType(dgvr.Cells("IDDEPARTAMENTO").Value, String)
                        Me.cmbProvincia.SelectedValue = CType(dgvr.Cells("IDPROVINCIA").Value, String)
                        Me.cmbDistrito.SelectedValue = CType(dgvr.Cells("IDDISTRITO").Value, String)
                        'Como se Implemento al final, algunos clientes no tienen esta data  no es error de codigo sino conceptual.
                        Me.cmbTipoFacturacion.SelectedValue = CType(dgvr.Cells("IDTIPO_FACTURACION").Value, Integer)

                        If Len(Trim(txtFuncionarioCuenta.Text)) = 0 Then
                            txtFuncionarioCuenta.Text = "No Asignado..."
                        End If

                        If Len(Trim(txtRespFacturacion.Text)) = 0 Then
                            txtRespFacturacion.Text = "No Asignado..."
                        End If

                        'hlamas
                        Me.chkBase.Checked = IIf(IsDBNull(dgvr.Cells("MONTO_BASE").Value), 0, dgvr.Cells("MONTO_BASE").Value)

                        ' 
                        ' Aqui deberia cambiar y reasignar el funcionario 
                        '
                        '  Omendoza comentado 
                        '
                        'If txtRespFacturacion.Text = "No Asignado..." And txtFuncionarioCuenta.Text = "No Asignado..." Then
                        '    chkContadoCredito.Checked = True                        
                        'End If
                    End If

                    If CType(dgvr.Cells("JURIDICAONATURAL").Value, Integer) = 2 Then '"NATURAL" 
                        DeshabilitaControlesEdicion()
                        Me.cmbTipoPersona.SelectedValue = CType(dgvr.Cells("JURIDICAONATURAL").Value, Integer)
                        vIDPersona = CType(dgvr.Cells("ID").Value, Integer)
                        Me.txtCodigo.Text = CType(dgvr.Cells("CODIGO").Value, String)
                        Me.txtNombreP.Text = CType(dgvr.Cells("NOMPRE_PERSONA").Value, String)
                        If Not IsDBNull(dgvr.Cells("NOMPRE_PERSONA1").Value) Then
                            Me.txtNombreS.Text = CType(dgvr.Cells("NOMPRE_PERSONA1").Value, String)
                        Else
                            Me.txtNombreS.Text = ""
                        End If
                        Me.txtApellidoP.Text = CType(dgvr.Cells("APELLIDO_PATERNO").Value, String)
                        Me.txtApellidoM.Text = CType(dgvr.Cells("APELLIDO_MATERNO").Value, String)
                        Me.txtNumeroDocto.Text = CType(dgvr.Cells("DOCUMENTO").Value, String)
                        If IsDate(dgvr.Cells("FECHA_NACIMIENTO").Value) Then
                            Me.txtFechaNacimiento._MyFecha = CType(dgvr.Cells("FECHA_NACIMIENTO").Value, String)
                        Else
                            Me.txtFechaNacimiento._MyFecha = "null"
                        End If

                        If CType(dgvr.Cells("SEXO_PERSONA").Value, String) = "M" Then
                            Me.rdbSexoMasCliente.Checked = True
                        ElseIf CType(dgvr.Cells("SEXO_PERSONA").Value, String) = "F" Then
                            Me.rdbSexoMasCliente.Checked = True
                        End If
                        If IsDBNull(dgvr.Cells("EMAIL").Value) Then
                            Me.txtCorreoElectronico.Text = ""
                        Else
                            Me.txtCorreoElectronico.Text = CType(dgvr.Cells("EMAIL").Value, String)
                        End If
                        Me.txtFechaRegistro._MyFecha = CType(dgvr.Cells("FECHA_INGRESO").Value, String)
                        Me.chkCorporativo.Checked = CType(dgvr.Cells("CLIENTE_CORPORATIVO").Value, Boolean)
                        Me.chkBase.Checked = IIf(IsDBNull(dgvr.Cells("MONTO_BASE").Value), 0, dgvr.Cells("MONTO_BASE").Value)
                        Me.chkPostFacturacion.Checked = CType(dgvr.Cells("PAGO_POST_FACTURACION").Value, Boolean)
                        Me.chkAgenteRetencion.Checked = CType(dgvr.Cells("AGENTE_RETENCION").Value, Boolean)
                        Me.cmbRubroEmpresarial.SelectedValue = CType(dgvr.Cells("IDRUBRO").Value, Integer)
                        Me.cmbClasPersona.SelectedValue = CType(dgvr.Cells("IDCLASIFICACION_PERSONA").Value, Integer)
                        Me.txtFuncionarioCuenta.Text = CType(dgvr.Cells("FUNCIONARIO").Value, String)
                        If IsDBNull(dgvr.Cells("IDFUNCIONARIO_ACTUAL").Value) Then
                            CodFuncionarioNegocio = 0
                        Else
                            CodFuncionarioNegocio = CType(dgvr.Cells("IDFUNCIONARIO_ACTUAL").Value, Integer)
                        End If
                        Me.cmbPais.SelectedValue = CType(dgvr.Cells("IDPAIS").Value, String)
                        Me.cmbDepartamento.SelectedValue = CType(dgvr.Cells("IDDEPARTAMENTO").Value, String)
                        Me.cmbProvincia.SelectedValue = CType(dgvr.Cells("IDPROVINCIA").Value, String)
                        Me.cmbDistrito.SelectedValue = CType(dgvr.Cells("IDDISTRITO").Value, String)
                        Me.cmbTipoFacturacion.SelectedValue = CType(dgvr.Cells("IDTIPO_FACTURACION").Value, Integer)

                        If Len(Trim(txtFuncionarioCuenta.Text)) = 0 Then
                            txtFuncionarioCuenta.Text = "No Asignado..."
                        End If

                        If Len(Trim(txtRespFacturacion.Text)) = 0 Then
                            txtRespFacturacion.Text = "No Asignado..."
                        End If

                        If txtRespFacturacion.Text = "No Asignado..." And txtFuncionarioCuenta.Text = "No Asignado..." Then
                            chkContadoCredito.Checked = True
                        End If
                    End If

                    'Codigo del Edicion de la Plantilla
                    SelectMenu(1)
                    SplitContainer2.Panel1Collapsed = True
                    NuevoToolStripMenuItem.Enabled = False
                    EdicionToolStripMenuItem.Enabled = False
                    CancelarToolStripmenuItem.Enabled = True
                    CancelarToolStripmenuItem.Visible = True
                    GrabarToolStripMenuItem.Enabled = True 'Colocar en todos los formualrios esto, luego de dshabilitarlos.
                    EliminarToolStripMenuItem.Enabled = False
                    ExportarToolStripMenuItem.Enabled = False
                    ImprimirToolStripMenuItem.Enabled = False

                Else
                    MessageBox.Show("Elija el Cliente a Editar", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Seleccione a un Funcionario y Elija el Cliente a Editar", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            '
            ' Habilita los chkbox del primer tab 
            '
            chkCorporativo.Enabled = True
            chkContadoCredito.Enabled = True
            chkPostFacturacion.Enabled = True
            'Me.chkBase.Enabled = True
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function RecureparIDPERSONA_eliminarlo(ByVal MyRst As ADODB.Recordset) As Integer
        Return CType(MyRst.Fields(1).Value, Integer)
    End Function

    Private Sub DataGridLista_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridLista.CellClick
        'If e.ColumnIndex = 2 Then
        '    Dim dgvr As DataGridViewRow = Me.DataGridLista.CurrentRow()
        '    MessageBox.Show(dgvr.Cells("CODIGO").Value.ToString())
        'End If
    End Sub

    Private Sub rdbJuridicos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbJuridicos.CheckedChanged
        If sender.checked = True Then
            If DataGridLista.Columns.Count > 0 Then
                DataGridLista.Columns(5).Visible = False
                DataGridLista.Columns(4).Visible = True
                Dim FiltroLista As String = "IDTIPO_PERSONA ='" & 1 & "'"
                If iLinea <> 9 Then
                    FiltroLista = FiltroLista & " and linea=" & iLinea & " "
                End If
                dvListaPersona.RowFilter = FiltroLista
            End If
        End If
    End Sub

    Private Sub rdbnaturales_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbnaturales.CheckedChanged
        If sender.checked = True Then
            If DataGridLista.Columns.Count > 0 Then
                DataGridLista.Columns(5).Visible = True
                DataGridLista.Columns(4).Visible = False
                Dim FiltroLista As String = "IDTIPO_PERSONA ='" & 2 & "'"

                If iLinea <> 9 Then
                    FiltroLista = FiltroLista & " and linea=" & iLinea & " "
                End If

                dvListaPersona.RowFilter = FiltroLista
            End If
        End If
    End Sub

    Private Sub rdbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbTodos.CheckedChanged
        If sender.checked = True Then
            If DataGridLista.Columns.Count > 0 Then
                DataGridLista.Columns(5).Visible = False
                DataGridLista.Columns(4).Visible = True
                Dim FiltroLista As String = ""
                If iLinea <> 9 Then
                    FiltroLista = FiltroLista & " linea=" & iLinea & " "
                End If
                dvListaPersona.RowFilter = FiltroLista
            End If
        End If
    End Sub

    Private Sub btnFuncionarioCta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFuncionarioCta.Click
        ' Creado por Tepsa chkCorporativo.Checked = True 
        If txtFuncionarioCuenta.Text = "" Or txtFuncionarioCuenta.Text <> "No Asignado..." Or chkCorporativo.Checked = True Then
            Dim FrmBusFuncionario As FrmBusquedaFuncionarios = New FrmBusquedaFuncionarios
            FrmBusFuncionario.txtNombreFuncionario.Text = Me.txtFuncionarioCuenta.Text
            Dim resultado As DialogResult
            resultado = FrmBusFuncionario.ShowDialog()
            Dim FuncionarioNegocio As String = FrmBusFuncionario.NombreFuncionario
            CodFuncionarioNegocio = FrmBusFuncionario.CodigoFuncionario
            TipoFuncionarioNegocio = FrmBusFuncionario.TipoFuncionario
            Me.txtFuncionarioCuenta.Text = FuncionarioNegocio
        ElseIf txtFuncionarioCuenta.Text = "No Asignado..." Then
            MessageBox.Show("Para agilizar el ingreso no Asigne Funcionarios a Clientes Contado.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Esta actualización realizala en el Modulo de Reasignacion de Funcionarios", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub txtFuncionarioCuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFuncionarioCuenta.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        'KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 13 Then
            'btnFuncionarioCta_Click(sender, e)
            Me.btnFuncionarioCta.PerformClick()
        End If
    End Sub

    Private Sub btnRespFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRespFactura.Click
        'If txtRespFacturacion.Text = "" Or txtRespFacturacion.Text <> "No Asignado..." Then
        '    Dim FrmBusRespFactura As FrmBusquedaRespFactura = New FrmBusquedaRespFactura
        '    FrmBusRespFactura.txtNombreRespfactura.Text = Me.txtRespFacturacion.Text
        '    Dim resultado As DialogResult
        '    resultado = FrmBusRespFactura.ShowDialog()
        '    Dim Valor As String = FrmBusRespFactura.NombreRespFactura
        '    Me.txtRespFacturacion.Text = Valor
        'ElseIf txtFuncionarioCuenta.Text = "No Asignado..." Then
        '    MessageBox.Show("Para agilizar el ingreso no Asigne Funcionarios a Clientes Contado.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else
        '    MessageBox.Show("Esta actualización realizala en el Modulo de Reasignacion de Responsables de CtaCte.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
    End Sub

    Private Sub txtRespFacturacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRespFacturacion.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        'KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 13 Then
            'btnFuncionarioCta_Click(sender, e)
            Me.btnRespFactura.PerformClick()
        End If
    End Sub

    Private Sub btnPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPais.Click
        Dim Parametros() As String = {"Mantenimiento de Geográfico", "PKG_IVOPERSONA.SP_GRILLASUBICACION", "PKG_IVOPERSONA.SP_INSUPD_PAIS", "IDPAIS", "PAIS", "IDDEPARTAMENTO", "PAIS", "DEPARTAMENTO", "IDPROVINCIA", "PAIS", "DEPARTAMENTO", "PROVINCIA", "IDDISTRITO", "PAIS", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "ID PAIS", "NOMBRE DEL PAIS", "ID DEPARTAMENTO", "NOMBRE DEPARTAMENTO", "ID PROVINCIA", "NOMBRE PROVINCIA", "ID DISTRITO", "NOMBRE DISTRITO", "1", "MANT. PAISES", "MANT. DEPARTAMENTOS", "MANT. PROVINCIAS", "MANT. DISTRITOS"}
        Dim a As FrmDosCampos = New FrmDosCampos(Parametros)
        Dim resultado As DialogResult

        Acceso.Asignar(a, Me.Hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = a.ShowDialog()
            If resultado = Windows.Forms.DialogResult.OK Then
                dtPaisCombo.Clear()
                dtDepartamentoCombo.Clear()
                dtProvinciaCombo.Clear()
                dtDistritoCombo.Clear()

                dtPaisCombo = a.dtPaisFinal.Copy
                dtDepartamentoCombo = a.dtDepartamentoFinal.Copy
                dtProvinciaCombo = a.dtProvinciaFinal.Copy
                dtDistritoCombo = a.dtDistritoFinal.Copy

                dvPais = dtPaisCombo.DefaultView
                dvDepartamento = dtDepartamentoCombo.DefaultView
                dvProvincia = dtProvinciaCombo.DefaultView
                dvDistrito = dtDistritoCombo.DefaultView

                Call CargaCombosDirecciones()

                cmbPais.DataSource = dvPais
                cmbPais.DisplayMember = "PAIS"
                cmbPais.ValueMember = "IDPAIS"

                Dim FiltroDepartamento As String = ""
                Dim MyParametroD As Integer = cmbPais.SelectedValue
                FiltroDepartamento = "IDPAIS = '" & MyParametroD & "'"
                dvDepartamento.RowFilter = FiltroDepartamento
                cmbDepartamento.DataSource = dvDepartamento
                cmbDepartamento.DisplayMember = "DEPARTAMENTO"
                cmbDepartamento.ValueMember = "IDDEPARTAMENTO"

                Dim FiltroProvincia As String = ""
                Dim MyParametroP As Integer = cmbDepartamento.SelectedValue
                FiltroProvincia = "IDDEPARTAMENTO = '" & MyParametroP & "'"
                dvProvincia.RowFilter = FiltroProvincia
                cmbProvincia.DataSource = dvProvincia
                cmbProvincia.DisplayMember = "PROVINCIA"
                cmbProvincia.ValueMember = "IDPROVINCIA"

                Dim FiltroDistrito As String = ""
                Dim MyParametroDs As Integer = cmbProvincia.SelectedValue
                FiltroDistrito = "IDPROVINCIA = '" & MyParametroDs & "'"
                dvDistrito.RowFilter = FiltroDistrito
                cmbDistrito.DataSource = dvDistrito
                cmbDistrito.DisplayMember = "DSITRITO"
                cmbDistrito.ValueMember = "IDDISTRITO"
                cmbPais.SelectedValue = a.PaisSeleccionado
            End If
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnDepartamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDepartamento.Click
        Dim Parametros() As String = {"Mantenimiento de Geográfico", "PKG_IVOPERSONA.SP_GRILLASUBICACION", "PKG_IVOPERSONA.SP_INSUPD_PAIS", "IDPAIS", "PAIS", "IDDEPARTAMENTO", "PAIS", "DEPARTAMENTO", "IDPROVINCIA", "PAIS", "DEPARTAMENTO", "PROVINCIA", "IDDISTRITO", "PAIS", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "ID PAIS", "NOMBRE DEL PAIS", "ID DEPARTAMENTO", "NOMBRE DEPARTAMENTO", "ID PROVINCIA", "NOMBRE PROVINCIA", "ID DISTRITO", "NOMBRE DISTRITO", "2", "MANT. PAISES", "MANT. DEPARTAMENTOS", "MANT. PROVINCIAS", "MANT. DISTRITOS"}

        Dim a As FrmDosCampos = New FrmDosCampos(Parametros)
        'Dim resultado As DialogResult = a.ShowDialog()

        Dim resultado As DialogResult
        Acceso.Asignar(a, Me.Hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = a.ShowDialog()
            If resultado = Windows.Forms.DialogResult.OK Then
                dtPaisCombo.Clear()
                dtDepartamentoCombo.Clear()
                dtProvinciaCombo.Clear()
                dtDistritoCombo.Clear()

                dtPaisCombo = a.dtPaisFinal.Copy
                dtDepartamentoCombo = a.dtDepartamentoFinal.Copy
                dtProvinciaCombo = a.dtProvinciaFinal.Copy
                dtDistritoCombo = a.dtDistritoFinal.Copy

                dvPais = dtPaisCombo.DefaultView
                dvDepartamento = dtDepartamentoCombo.DefaultView
                dvProvincia = dtProvinciaCombo.DefaultView
                dvDistrito = dtDistritoCombo.DefaultView

                Call CargaCombosDirecciones()

                cmbPais.DataSource = dvPais
                cmbPais.DisplayMember = "PAIS"
                cmbPais.ValueMember = "IDPAIS"

                Dim FiltroDepartamento As String = ""
                Dim MyParametroD As Integer = cmbPais.SelectedValue
                FiltroDepartamento = "IDPAIS = '" & MyParametroD & "'"
                dvDepartamento.RowFilter = FiltroDepartamento
                cmbDepartamento.DataSource = dvDepartamento
                cmbDepartamento.DisplayMember = "DEPARTAMENTO"
                cmbDepartamento.ValueMember = "IDDEPARTAMENTO"

                Dim FiltroProvincia As String = ""
                Dim MyParametroP As Integer = cmbDepartamento.SelectedValue
                FiltroProvincia = "IDDEPARTAMENTO = '" & MyParametroP & "'"
                dvProvincia.RowFilter = FiltroProvincia
                cmbProvincia.DataSource = dvProvincia
                cmbProvincia.DisplayMember = "PROVINCIA"
                cmbProvincia.ValueMember = "IDPROVINCIA"

                Dim FiltroDistrito As String = ""
                Dim MyParametroDs As Integer = cmbProvincia.SelectedValue
                FiltroDistrito = "IDPROVINCIA = '" & MyParametroDs & "'"
                dvDistrito.RowFilter = FiltroDistrito
                cmbDistrito.DataSource = dvDistrito
                cmbDistrito.DisplayMember = "DSITRITO"
                cmbDistrito.ValueMember = "IDDISTRITO"

                cmbPais.SelectedValue = a.PaisSeleccionado
                cmbDepartamento.SelectedValue = a.DepartamentoSeleccionado
            End If
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnProvincia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProvincia.Click
        Dim Parametros() As String = {"Mantenimiento de Geográfico", "PKG_IVOPERSONA.SP_GRILLASUBICACION", "PKG_IVOPERSONA.SP_INSUPD_PAIS", "IDPAIS", "PAIS", "IDDEPARTAMENTO", "PAIS", "DEPARTAMENTO", "IDPROVINCIA", "PAIS", "DEPARTAMENTO", "PROVINCIA", "IDDISTRITO", "PAIS", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "ID PAIS", "NOMBRE DEL PAIS", "ID DEPARTAMENTO", "NOMBRE DEPARTAMENTO", "ID PROVINCIA", "NOMBRE PROVINCIA", "ID DISTRITO", "NOMBRE DISTRITO", "3", "MANT. PAISES", "MANT. DEPARTAMENTOS", "MANT. PROVINCIAS", "MANT. DISTRITOS"}

        Dim a As FrmDosCampos = New FrmDosCampos(Parametros)
        'Dim resultado As DialogResult = a.ShowDialog()
        Dim resultado As DialogResult
        Acceso.Asignar(a, Me.Hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = a.ShowDialog()
            If resultado = Windows.Forms.DialogResult.OK Then
                dtPaisCombo.Clear()
                dtDepartamentoCombo.Clear()
                dtProvinciaCombo.Clear()
                dtDistritoCombo.Clear()

                dtPaisCombo = a.dtPaisFinal.Copy
                dtDepartamentoCombo = a.dtDepartamentoFinal.Copy
                dtProvinciaCombo = a.dtProvinciaFinal.Copy
                dtDistritoCombo = a.dtDistritoFinal.Copy

                dvPais = dtPaisCombo.DefaultView
                dvDepartamento = dtDepartamentoCombo.DefaultView
                dvProvincia = dtProvinciaCombo.DefaultView
                dvDistrito = dtDistritoCombo.DefaultView

                Call CargaCombosDirecciones()

                cmbPais.DataSource = dvPais
                cmbPais.DisplayMember = "PAIS"
                cmbPais.ValueMember = "IDPAIS"

                Dim FiltroDepartamento As String = ""
                Dim MyParametroD As Integer = cmbPais.SelectedValue
                FiltroDepartamento = "IDPAIS = '" & MyParametroD & "'"
                dvDepartamento.RowFilter = FiltroDepartamento
                cmbDepartamento.DataSource = dvDepartamento
                cmbDepartamento.DisplayMember = "DEPARTAMENTO"
                cmbDepartamento.ValueMember = "IDDEPARTAMENTO"

                Dim FiltroProvincia As String = ""
                Dim MyParametroP As Integer = cmbDepartamento.SelectedValue
                FiltroProvincia = "IDDEPARTAMENTO = '" & MyParametroP & "'"
                dvProvincia.RowFilter = FiltroProvincia
                cmbProvincia.DataSource = dvProvincia
                cmbProvincia.DisplayMember = "PROVINCIA"
                cmbProvincia.ValueMember = "IDPROVINCIA"

                Dim FiltroDistrito As String = ""
                Dim MyParametroDs As Integer = cmbProvincia.SelectedValue
                FiltroDistrito = "IDPROVINCIA = '" & MyParametroDs & "'"
                dvDistrito.RowFilter = FiltroDistrito
                cmbDistrito.DataSource = dvDistrito
                cmbDistrito.DisplayMember = "DSITRITO"
                cmbDistrito.ValueMember = "IDDISTRITO"

                cmbPais.SelectedValue = a.PaisSeleccionado
                cmbDepartamento.SelectedValue = a.DepartamentoSeleccionado
                cmbProvincia.SelectedValue = a.ProvinciaSeleccionado
            End If
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnDistrito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDistrito.Click
        Dim Parametros() As String = {"Mantenimiento de Geográfico", "PKG_IVOPERSONA.SP_GRILLASUBICACION", "PKG_IVOPERSONA.SP_INSUPD_PAIS", "IDPAIS", "PAIS", "IDDEPARTAMENTO", "PAIS", "DEPARTAMENTO", "IDPROVINCIA", "PAIS", "DEPARTAMENTO", "PROVINCIA", "IDDISTRITO", "PAIS", "DEPARTAMENTO", "PROVINCIA", "DSITRITO", "ID PAIS", "NOMBRE DEL PAIS", "ID DEPARTAMENTO", "NOMBRE DEPARTAMENTO", "ID PROVINCIA", "NOMBRE PROVINCIA", "ID DISTRITO", "NOMBRE DISTRITO", "4", "MANT. PAISES", "MANT. DEPARTAMENTOS", "MANT. PROVINCIAS", "MANT. DISTRITOS"}
        Dim a As FrmDosCampos = New FrmDosCampos(Parametros)
        'Dim resultado As DialogResult = a.ShowDialog()

        Dim resultado As DialogResult
        Acceso.Asignar(a, Me.Hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = a.ShowDialog()
            If resultado = Windows.Forms.DialogResult.OK Then
                dtPaisCombo.Clear()
                dtDepartamentoCombo.Clear()
                dtProvinciaCombo.Clear()
                dtDistritoCombo.Clear()

                dtPaisCombo = a.dtPaisFinal.Copy
                dtDepartamentoCombo = a.dtDepartamentoFinal.Copy
                dtProvinciaCombo = a.dtProvinciaFinal.Copy
                dtDistritoCombo = a.dtDistritoFinal.Copy

                dvPais = dtPaisCombo.DefaultView
                dvDepartamento = dtDepartamentoCombo.DefaultView
                dvProvincia = dtProvinciaCombo.DefaultView
                dvDistrito = dtDistritoCombo.DefaultView

                Call CargaCombosDirecciones()

                cmbPais.DataSource = dvPais
                cmbPais.DisplayMember = "PAIS"
                cmbPais.ValueMember = "IDPAIS"

                Dim FiltroDepartamento As String = ""
                Dim MyParametroD As Integer = cmbPais.SelectedValue
                FiltroDepartamento = "IDPAIS = '" & MyParametroD & "'"
                dvDepartamento.RowFilter = FiltroDepartamento
                cmbDepartamento.DataSource = dvDepartamento
                cmbDepartamento.DisplayMember = "DEPARTAMENTO"
                cmbDepartamento.ValueMember = "IDDEPARTAMENTO"

                Dim FiltroProvincia As String = ""
                Dim MyParametroP As Integer = cmbDepartamento.SelectedValue
                FiltroProvincia = "IDDEPARTAMENTO = '" & MyParametroP & "'"
                dvProvincia.RowFilter = FiltroProvincia
                cmbProvincia.DataSource = dvProvincia
                cmbProvincia.DisplayMember = "PROVINCIA"
                cmbProvincia.ValueMember = "IDPROVINCIA"

                Dim FiltroDistrito As String = ""
                Dim MyParametroDs As Integer = cmbProvincia.SelectedValue
                FiltroDistrito = "IDPROVINCIA = '" & MyParametroDs & "'"
                dvDistrito.RowFilter = FiltroDistrito
                cmbDistrito.DataSource = dvDistrito
                cmbDistrito.DisplayMember = "DSITRITO"
                cmbDistrito.ValueMember = "IDDISTRITO"

                cmbPais.SelectedValue = a.PaisSeleccionado
                cmbDepartamento.SelectedValue = a.DepartamentoSeleccionado
                cmbProvincia.SelectedValue = a.ProvinciaSeleccionado
                cmbDistrito.SelectedValue = a.DistritoSeleccionado
            End If
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtNumDoctoContacto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoctoContacto.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRUC_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRUC.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNumeroDocto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroDocto.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cmbPaisDirecciones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPaisDirecciones.SelectedIndexChanged
        Dim filCb As Integer
        Dim drc As DataRowView
        Dim valor As String
        filCb = cmbPaisDirecciones.SelectedIndex
        If filCb >= 0 Then
            drc = dvPaisDireciones.Item(filCb)
            valor = IIf(IsDBNull(drc("IDPAIS")) = True, "0", drc("IDPAIS").ToString)
            dvDepartDirecciones.RowFilter = "IDPAIS =" & valor
        Else
            dvDepartDirecciones.RowFilter = "IDPAIS = 0"
        End If
    End Sub

    Private Sub cmbDepartamentoDirecciones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDepartamentoDirecciones.SelectedIndexChanged
        Dim filCb As Integer
        Dim drc As DataRowView
        Dim valor As String
        filCb = cmbDepartamentoDirecciones.SelectedIndex
        If filCb >= 0 Then
            drc = dvDepartDirecciones.Item(filCb)
            valor = IIf(IsDBNull(drc("IDDEPARTAMENTO")) = True, "0", drc("IDDEPARTAMENTO").ToString)
            dvProvDirecciones.RowFilter = "IDDEPARTAMENTO =" & valor
        Else
            dvProvDirecciones.RowFilter = "IDDEPARTAMENTO = 0"
        End If
    End Sub

    Private Sub cmbProvinciaDirecciones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProvinciaDirecciones.SelectedIndexChanged
        Dim filCb As Integer
        Dim drc As DataRowView
        Dim valor As String
        filCb = cmbProvinciaDirecciones.SelectedIndex
        If filCb >= 0 Then
            drc = dvProvDirecciones.Item(filCb)
            valor = IIf(IsDBNull(drc("IDPROVINCIA")) = True, "0", drc("IDPROVINCIA").ToString)
            dvDistDirecciones.RowFilter = "IDPROVINCIA =" & valor
        Else
            dvDistDirecciones.RowFilter = "IDPROVINCIA = 0"
        End If
    End Sub

    Private Sub btnAgregarDireccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarDireccion.Click
        If SeleccionoContacto() = 0 Then
            MessageBox.Show("Seleccione los Contactos de esta Dirección", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSeleccionarContactos.PerformClick()
        ElseIf SeleccionoContacto() > 0 Then
            Dim MyObligatorios() As Object = {Me.txtCodigoUbigeo, Me.txtDireccion, Me.cmbPaisDirecciones, Me.btnPaisDirecciones, Me.cmbDepartamentoDirecciones, Me.btnDepartamentoDirecciones, Me.cmbProvinciaDirecciones, Me.btnProvinciaDirecciones, Me.cmbDistritoDirecciones, Me.btnDistritoDirecciones}
            If Funciones.Validaciones(MyObligatorios) = 0 Then

                Try
                    drwDirecciones = dtDireccionesCliente.NewRow

                    drwDirecciones("ORDEN") = Me.dgvDirecciones.RowCount  'ORDEN
                    'drwDirecciones("TIPO_DIRECCION") = True 'ACTIVO
                    drwDirecciones("TIPO_DIRECCION") = Me.cmbTipoDireccion.Text 'TIPO DIRECCION
                    drwDirecciones("DIRECCION") = Me.txtDireccion.Text 'DIRECCION
                    If Me.chkDireccionFacturacion.Checked = True Then
                        drwDirecciones("DIRECCION_FACTURACION") = True
                    Else
                        drwDirecciones("DIRECCION_FACTURACION") = False
                    End If
                    'drwDirecciones(5) = Me.cmbContactoDireccion.Text 'CONTACTO
                    drwDirecciones("PAIS") = Me.cmbPaisDirecciones.Text 'PAIS
                    drwDirecciones("DEPARTAMENTO") = Me.cmbDepartamentoDirecciones.Text 'DEPARTAMENTO
                    drwDirecciones("PROVINCIA") = Me.cmbProvinciaDirecciones.Text 'PROVINCIA
                    drwDirecciones("DSITRITO") = Me.cmbDistritoDirecciones.Text 'DISTRITO

                    dtDireccionesCliente.Rows.Add(drwDirecciones)

                    Call AgregaDireccion(1)
                    dtDireccionesCliente.Clear()
                    Call CargaDirecciones(txtCodigoClienteDirecciones.Text, dgvDirecciones)

                    dvTipoDireccion.RowFilter = "TIPO_DIRECCION<>'LEGAL'"
                    btnTipoDireccion.Enabled = True
                    Me.chkDireccionFacturacion.Checked = False
                    Me.chkDireccionFacturacion.Enabled = False

                    Try 'Limpieza de TextBox
                        For Each MyObj As Object In TabPage2.Controls
                            If TypeOf MyObj Is TextBox Then
                                CType(MyObj, TextBox).Text = ""
                            End If
                        Next
                    Catch Qex As Exception
                        MessageBox.Show(Qex.Message, "Seguridad Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Catch Pex As System.Data.ConstraintException
                    MessageBox.Show("Este Contacto ya esta asociado a una Dirección.", "Seguridad Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch Qex As Exception
                    MessageBox.Show(Qex.Message, "Seguridad Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
        Me.txtCodigoUbigeo.Text = "00000"
    End Sub

    Private Sub txtRUC_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRUC.KeyUp
        Me.txtCodigo.Text = txtRUC.Text
    End Sub

    Private Sub chkContadoCredito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkContadoCredito.CheckedChanged
        If vAccionRegistro = 1 Then
            If sender.checked = True Then
                Me.btnFuncionarioCta.Enabled = False
                Me.btnRespFactura.Enabled = False
                '28/04/2008 - Debe tomar en cuenta al funcionario de negocio
                Me.btnFuncionarioCta.Enabled = True
                'Me.txtFuncionarioCuenta.Text = "No Asignado..."
                'Me.txtRespFacturacion.Text = "No Asignado..."
                Me.chkPostFacturacion.Checked = False
                Me.chkPostFacturacion.Enabled = False
                Me.chkCorporativo.Checked = False
                Me.chkCorporativo.Enabled = False

            Else
                Me.btnFuncionarioCta.Enabled = True
                Me.btnRespFactura.Enabled = True
                'If MyRol = 11 Then
                'bloque
                If Acceso.SiRol(G_Rol, Me, 2) Then
                    '   Me.txtFuncionarioCuenta.Text = "Funcionario Sesion Activa."    Tepsa 30/09/2006
                    Me.txtRespFacturacion.Text = ""
                    Me.btnFuncionarioCta.Enabled = False
                Else
                    Me.txtFuncionarioCuenta.Text = ""
                    Me.txtRespFacturacion.Text = ""
                    Me.btnFuncionarioCta.Enabled = True
                End If
                'Me.txtFuncionarioCuenta.Text = ""
                'Me.txtRespFacturacion.Text = ""
                If cmbTipoPersona.Text = "JURIDICA" Then
                    Me.chkPostFacturacion.Checked = False
                    Me.chkPostFacturacion.Enabled = True
                    Me.chkCorporativo.Checked = False
                    Me.chkCorporativo.Enabled = True
                End If
            End If

        ElseIf vAccionRegistro = 2 Then
            If sender.checked = True Then
                Me.btnFuncionarioCta.Enabled = False
                Me.btnRespFactura.Enabled = False
                '                Me.txtFuncionarioCuenta.Text = "No Asignado..."      Tepsa - 30/09/2006
                Me.txtRespFacturacion.Text = "No Asignado..."
                Me.chkPostFacturacion.Checked = False
                Me.chkPostFacturacion.Enabled = False
                Me.chkCorporativo.Checked = False
                Me.chkCorporativo.Enabled = False
                ' Tepsa 04/09/2006 
                iidtipo_facturacion = cmbTipoFacturacion.SelectedValue
                dvTipoFacturacion.RowFilter = "TIPO_FACTURACION = 'CONTADO'"  ' Contado =  0, en el tipo de facturación   
                cmbTipoFacturacion.SelectedValue = 0   ' Contado =  0
                cmbTipoFacturacion.Enabled = False
                btnTipoFacturacion.Enabled = False
            Else
                Me.btnFuncionarioCta.Enabled = True
                Me.btnRespFactura.Enabled = True
                'If MyRol = 11 Then
                'bloque
                If Acceso.SiRol(G_Rol, Me, 3) Then
                    'Me.txtFuncionarioCuenta.Text = "Funcionario Sesion Activa."   Tepsa - 30/09/2006
                    Me.txtRespFacturacion.Text = ""
                    Me.btnFuncionarioCta.Enabled = False
                Else
                    Me.txtFuncionarioCuenta.Text = ""
                    Me.txtRespFacturacion.Text = ""
                    Me.btnFuncionarioCta.Enabled = True
                End If
                'Me.txtFuncionarioCuenta.Text = ""
                'Me.txtRespFacturacion.Text = ""
                If cmbTipoPersona.Text = "JURIDICA" Then
                    Me.chkPostFacturacion.Checked = False
                    Me.chkPostFacturacion.Enabled = True
                    Me.chkCorporativo.Checked = False
                    Me.chkCorporativo.Enabled = True
                End If
                cmbTipoFacturacion.Enabled = True
                btnTipoFacturacion.Enabled = True
            End If
        End If
    End Sub

    Private Sub txtNumeroDocto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumeroDocto.KeyUp
        Me.txtCodigo.Text = txtNumeroDocto.Text
    End Sub

    Private Sub dgvContactos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvContactos.DoubleClick ', dgvContactosActualiza.DoubleClick
        Try
            'If vAccionRegistro = 2 Then
            Me.txtNumDoctoContacto.ReadOnly = True
            Me.txtNumDoctoContacto.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")

            'Dim dgvr As DataGridViewRow = Me.dgvContactosActualiza.CurrentRow()
            Dim dgvr As DataGridViewRow = Me.dgvContactos.CurrentRow()
            Me.cmbTipoDoctoContacto.SelectedValue = CType(dgvr.Cells("IDTIPO_DOCUMENTO_CONTACTO").Value, Integer)
            If IsDBNull(dgvr.Cells("NRODOCUMENTO").Value) = True Then
                Me.txtNumDoctoContacto.Text = ""
                Me.txtNumDoctoContacto.ReadOnly = False
            Else
                Me.txtNumDoctoContacto.Text = CType(dgvr.Cells("NRODOCUMENTO").Value, String)
                Me.txtNumDoctoContacto.ReadOnly = True
            End If

            Me.txtNombrePCont.Text = CType(dgvr.Cells("NOMBRES").Value, String)
            Me.txtApellidoPCont.Text = "NULL" 'CType(dgvr.Cells("APEPAT").Value, String)
            Me.txtApellidoMCont.Text = "NULL" 'CType(dgvr.Cells("APEMAT").Value, String)
            '
            If IsDBNull(dgvr.Cells("SEXO").Value) = True Then
                Me.rbtMasculino.Checked = True
            Else
                If CType(dgvr.Cells("SEXO").Value, String) = "M" Then
                    Me.rbtMasculino.Checked = True
                ElseIf CType(dgvr.Cells("SEXO").Value, String) = "F" Then
                    Me.rbtFemenino.Checked = True
                End If
            End If
            '
            If IsDBNull(dgvr.Cells("EMAIL_CONTACTO").Value) Then
                'MessageBox.Show("NULO")
                Me.txtEmailContacto.Text = ""
            Else
                'MessageBox.Show("NO NULO")
                Me.txtEmailContacto.Text = CType(dgvr.Cells("EMAIL_CONTACTO").Value, String)
            End If

            If CType(dgvr.Cells("ESTADO_REGISTRO").Value, Integer) = 1 Then
                Me.chkActivoContacto.Checked = True
            ElseIf CType(dgvr.Cells("ESTADO_REGISTRO").Value, Integer) = 0 Then
                Me.chkActivoContacto.Checked = False
            End If
            'Modificado por 05/07/2007 - Contacto
            TXT_IDCONTACTO_PERSONA.Text = CType(dgvr.Cells("IDCONTACTO_PERSONA").Value, Integer)
            '
            Me.cmbAreaEmpresa.Enabled = True   'false Tepsa 22/11/2006 
            Me.cmbAreaEmpresa.SelectedValue = IIf(dgvr.Cells("CENTRO_COSTO").Value Is Nothing, 2, dgvr.Cells("CENTRO_COSTO").Value)
            Me.cmbTipoContacto.SelectedValue = IIf(dgvr.Cells("IDTIPO_CONTACTO").Value Is Nothing, 2, dgvr.Cells("IDTIPO_CONTACTO").Value)

            'Me.cmbTipoContacto.Enabled = False
            'Me.btnAreaEmpresa.Enabled = False
            'Me.btnTipoContacto.Enabled = False

            Call CargarListaTelefonos(CType(dgvr.Cells("IDCONTACTO_PERSONA").Value, Integer), Me.dgvTelefonosContacto)

            'End If
            Me.btnAgregar.Enabled = False
            Me.btnActualizar.Enabled = True

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

    Private Sub FrmClientes_MenuSalir2009_eliminarlo() Handles Me.MenuSalir
        'Me.Close()
        'Exit Sub
        ''SALDRA
        ''If vAccionRegistro = 0 And Paso1 = 0 And Paso2 = 0 And Paso3 = 0 Then
        'If vAccionRegistro = 0 And Not bClienteActualizado Then
        '    Me.Close()
        'End If

        'If vAccionRegistro = 1 Then
        '    'If Paso1 = 1 And Paso2 = 1 And Paso3 = 1 Then
        '    If bClienteActualizado Then
        '        Me.Close()
        '        'ElseIf Paso1 = 1 And Paso2 = 0 And Paso3 = 0 Then
        '    ElseIf bClienteActualizado And Paso2 = 0 And Paso3 = 0 Then
        '        MessageBox.Show("Ingrese por lo menos un Contacto", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        txtCodigoClienteContacto.Text = txtCodigo.Text
        '        txtNombreClienteContacto.Text = txtRazonSocial.Text
        '        SelectMenu(2)
        '        'ElseIf Paso1 = 1 And Paso2 = 1 And Paso3 = 0 Then
        '    ElseIf bClienteActualizado And Paso2 = 1 And Paso3 = 0 Then
        '        MessageBox.Show("Ingrese una Direccion Legal", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)

        '        cmbPaisDirecciones.SelectedValue = 4
        '        cmbDepartamentoDirecciones.SelectedValue = 15
        '        cmbProvinciaDirecciones.SelectedValue = 17
        '        cmbDistritoDirecciones.SelectedValue = 2
        '        txtCodigoClienteDirecciones.Text = txtCodigo.Text

        '        If cmbTipoPersona.SelectedValue = 1 Then
        '            txtDireccionesCliente.Text = txtRazonSocial.Text
        '        ElseIf cmbTipoPersona.SelectedValue = 2 Then
        '            txtDireccionesCliente.Text = txtNombreP.Text & " " & txtApellidoP.Text & " " & txtApellidoM.Text
        '        End If

        '        SelectMenu(3)

        '        dtDireccionesCliente.Clear()
        '        Call CargaDirecciones(txtCodigoClienteDirecciones.Text, dgvDirecciones)

        '        Dim rstContactos As ADODB.Recordset
        '        'Dim daContactos As New OleDbDataAdapter
        '        Dim dtContactos As New DataTable

        '        Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTA_CONTACTOS", 4, MyCodigoCliente, 2}
        '        Try
        '            rstContactos = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
        '            daContactos.Fill(dtContactos, rstContactos)
        '            cmbContactoDireccion.DataSource = dtContactos.DefaultView
        '            cmbContactoDireccion.DisplayMember = "NOMBRE_APELLIDO"
        '            cmbContactoDireccion.ValueMember = "IDCONTACTO_PERSONA"
        '        Catch Qex As Exception
        '            MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        End Try

        '        'ElseIf Paso1 = 0 And Paso2 = 0 And Paso3 = 0 Then
        '    ElseIf Not bClienteActualizado And Paso2 = 0 And Paso3 = 0 Then
        '        Me.Close()
        '    Else
        '        Me.Close()
        '    End If
        'End If
        'If vAccionRegistro = 2 Then
        '    Me.Close()
        'End If
    End Sub

    Public Sub btnCargarClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarClientes.Click
        Try
            'If MyRol = 32 Then ' Modifica por Omendoza - 25/06/2007 
            'bloque
            If Acceso.SiRol(G_Rol, Me, 4) Then
                If MyTreeView.Nodes(0).Checked = True Then
                    'MessageBox.Show("Cargar Todos")
                    DataGridLista.Columns.Clear()
                    dvListaPersona = Funciones.CargarGrillaClientes(Me.DataGridLista)
                    Dim FiltroLista As String
                    If rdbJuridicos.Checked Then
                        FiltroLista = "IDTIPO_PERSONA ='" & 1 & "' "
                        If iLinea <> 9 Then
                            FiltroLista = FiltroLista & "and linea=" & iLinea & ""
                        End If
                        DataGridLista.Columns(5).Visible = False
                        DataGridLista.Columns(4).Visible = True
                    ElseIf rdbnaturales.Checked Then
                        FiltroLista = "IDTIPO_PERSONA ='" & 2 & "'"
                        If iLinea <> 9 Then
                            FiltroLista = FiltroLista & "and linea=" & iLinea & ""
                        End If
                        DataGridLista.Columns(5).Visible = True
                        DataGridLista.Columns(4).Visible = False
                    Else
                        FiltroLista = ""
                        DataGridLista.Columns(5).Visible = False
                        DataGridLista.Columns(4).Visible = True
                    End If
                    dvListaPersona.RowFilter = FiltroLista
                    'DataGridLista.Columns(4).Visible = True
                    'DataGridLista.Columns(5).Visible = False
                    DataGridLista.Columns(40).Visible = False
                    lb_principal = True
                ElseIf MyTreeView.Nodes(0).Checked = False Then
                    'MessageBox.Show("Cargar por Funcionario")
                    For i As Integer = 0 To MyTreeView.Nodes(0).Nodes.Count - 1
                        If MyTreeView.Nodes(0).Nodes(i).Checked = True Then
                            DataGridLista.Columns.Clear()
                            dvListaPersona = Funciones.CargarGrillaClientes(Me.DataGridLista, MyTreeView.Nodes(0).Nodes(i).Text)
                            'Dim FiltroLista As String = "IDTIPO_PERSONA = 1 AND FUNCIONARIO ='" & MyTreeView.Nodes(0).Nodes(i).Text & "'"
                            'dvListaPersona.RowFilter = FiltroLista

                            'DataGridLista.Columns(4).Visible = True
                            'DataGridLista.Columns(5).Visible = False
                            DataGridLista.Columns(40).Visible = False
                        End If
                    Next
                    Dim FiltroLista As String
                    If rdbJuridicos.Checked Then
                        FiltroLista = "IDTIPO_PERSONA ='" & 1 & "'"
                        If iLinea <> 9 Then
                            FiltroLista = FiltroLista & "and linea=" & iLinea & ""
                        End If

                        DataGridLista.Columns(5).Visible = False
                        DataGridLista.Columns(4).Visible = True
                    ElseIf rdbnaturales.Checked Then
                        FiltroLista = "IDTIPO_PERSONA ='" & 2 & "'"
                        If iLinea <> 9 Then
                            FiltroLista = FiltroLista & "and linea=" & iLinea & ""
                        End If
                        DataGridLista.Columns(5).Visible = True
                        DataGridLista.Columns(4).Visible = False
                    Else
                        FiltroLista = ""
                        If iLinea <> 9 Then
                            FiltroLista = FiltroLista & "linea=" & iLinea & ""
                        End If
                        DataGridLista.Columns(5).Visible = True
                        DataGridLista.Columns(4).Visible = True
                    End If
                    dvListaPersona.RowFilter = FiltroLista

                    lb_principal = False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub MyTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles MyTreeView.AfterSelect
        For i As Integer = 0 To MyTreeView.Nodes(0).Nodes.Count - 1
            MyTreeView.Nodes(0).Nodes(i).Checked = False
        Next
        e.Node.Checked = True
    End Sub

    Private Sub txtRUC_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRUC.Validating
        Try
            If Len(Trim(txtRUC.Text)) <> 0 Then
                'Validando el  el 
                If fnValidarRUC(txtRUC.Text) = False Then
                    MessageBox.Show("RUC no válido por SUNAT", "CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtRUC.Text = ""
                    Exit Sub
                End If

                'datahelper
                'Dim Mybusqueda As ADODB.Recordset
                Dim Mybusqueda As DataTable
                Mybusqueda = BuscarCliente(txtRUC.Text)
                'If Mybusqueda.Fields.Count > 0 Then
                If Mybusqueda.Rows.Count > 0 Then
                    'datahelper
                    'Dim rstFuncionarioCliente As ADODB.Recordset
                    Dim rstFuncionarioCliente As DataTable
                    rstFuncionarioCliente = BuscaFuncionarioCliente(txtRUC.Text)
                    'If rstFuncionarioCliente.Fields.Item(0).Value = 1 Then
                    If rstFuncionarioCliente.Rows(0).Item(0).ToString = 1 Then
                        'If Mybusqueda.Fields.Item(0).Value = "EL CLIENTE YA EXISTE" Then
                        If Mybusqueda.Rows(0).Item(0).ToString = "EL CLIENTE YA EXISTE" Then
                            'MessageBox.Show(Mybusqueda.Fields.Item(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            MessageBox.Show(Mybusqueda.Rows(0).Item(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Call LimpiaPersona()
                            Me.txtRazonSocial.Focus()
                        End If
                    Else
                        bClienteActualizado = True
                        dgvContactos.Visible = True
                        dgvTelefonosContacto.Visible = True

                        Dim rstCliente As DataTable
                        rstCliente = CargarCliente(txtRUC.Text)
                        If rstCliente.Rows.Count > 0 Then
                            If CType(rstCliente.Rows(0).Item("idtipo_persona").ToString, Integer) = 1 Then     'Juridico
                                DeshabilitaControlesEdicion()
                                Me.cmbTipoPersona.SelectedValue = CType(rstCliente.Rows(0)("idtipo_persona").ToString, Integer)
                                vIDPersona = CType(rstCliente.Rows(0)("idpersona").ToString, Integer)
                                Me.txtCodigo.Text = CType(rstCliente.Rows(0)("codigo_cliente").ToString, String)
                                Me.txtRazonSocial.Text = CType(rstCliente.Rows(0)("RAZON_SOCIAL").ToString, String)
                                Me.txtRUC.Text = CType(rstCliente.Rows(0)("NU_DOCU_SUNA").ToString, String)
                                Me.txtGG.Text = CType(rstCliente.Rows(0)("GERENTE_GENERAL").ToString, String)
                                Me.txtRepLegal.Text = CType(rstCliente.Rows(0)("REPRESENTANTE_LEGAL").ToString, String)
                                If IsDBNull(rstCliente.Rows(0)("EMAIL").ToString) Then
                                    Me.txtWebSite.Text = ""
                                Else
                                    Me.txtWebSite.Text = CType(rstCliente.Rows(0)("EMAIL").ToString, String)
                                End If
                                Me.txtFechaRegistro._MyFecha = CType(rstCliente.Rows(0)("FECHA_INGRESO").ToString, String)
                                Me.chkCorporativo.Checked = CType(rstCliente.Rows(0)("CLIENTE_CORPORATIVO").ToString, Boolean)
                                If Me.chkCorporativo.Checked = False Then 'Tepsa si no es corporativo, va hacer contado 
                                    Me.chkContadoCredito.Checked = True
                                End If
                                Me.chkPostFacturacion.Checked = CType(rstCliente.Rows(0)("PAGO_POST_FACTURACION").ToString, Boolean)
                                Me.chkAgenteRetencion.Checked = CType(rstCliente.Rows(0)("AGENTE_RETENCION").ToString, Boolean)
                                Me.cmbRubroEmpresarial.SelectedValue = CType(rstCliente.Rows(0)("IDRUBRO").ToString, Integer)
                                Me.cmbClasPersona.SelectedValue = CType(rstCliente.Rows(0)("IDCLASIFICACION_PERSONA").ToString, Integer)
                                Me.txtFuncionarioCuenta.Text = CType(rstCliente.Rows(0)("FUNCIONARIO").ToString, String)
                                If IsDBNull(rstCliente.Rows(0)("IDFUNCIONARIO_ACTUAL")) Then
                                    CodFuncionarioNegocio = 0
                                Else
                                    CodFuncionarioNegocio = CType(rstCliente.Rows(0)("IDFUNCIONARIO_ACTUAL").ToString, Integer)
                                End If
                                Me.cmbPais.SelectedValue = CType(rstCliente.Rows(0)("IDPAIS").ToString, String)
                                Me.cmbDepartamento.SelectedValue = CType(rstCliente.Rows(0)("IDDEPARTAMENTO").ToString, String)
                                Me.cmbProvincia.SelectedValue = CType(rstCliente.Rows(0)("IDPROVINCIA").ToString, String)
                                Me.cmbDistrito.SelectedValue = CType(rstCliente.Rows(0)("IDDISTRITO").ToString, String)
                                Me.cmbTipoFacturacion.SelectedValue = CType(rstCliente.Rows(0)("IDTIPO_FACTURACION").ToString, Integer)

                                If Len(Trim(txtFuncionarioCuenta.Text)) = 0 Then
                                    txtFuncionarioCuenta.Text = "No Asignado..."
                                End If

                                If Len(Trim(txtRespFacturacion.Text)) = 0 Then
                                    txtRespFacturacion.Text = "No Asignado..."
                                End If

                                'hlamas
                                Me.chkBase.Checked = IIf(IsDBNull(rstCliente.Rows(0)("MONTO_BASE").ToString), 0, rstCliente.Rows(0)("MONTO_BASE").ToString)                            ' 
                            End If

                            If CType(rstCliente.Rows(0).Item("idtipo_persona").ToString, Integer) = 2 Then     'Natural
                                DeshabilitaControlesEdicion()
                                Me.cmbTipoPersona.SelectedValue = CType(rstCliente.Rows(0)("idtipo_persona").ToString, Integer)
                                vIDPersona = CType(rstCliente.Rows(0)("idpersona").ToString, Integer)
                                Me.txtCodigo.Text = CType(rstCliente.Rows(0)("CODIGO").ToString, String)
                                Me.txtNombreP.Text = CType(rstCliente.Rows(0)("NOMPRE_PERSONA").ToString, String)
                                If Not IsDBNull(rstCliente.Rows(0)("NOMPRE_PERSONA1").ToString) Then
                                    Me.txtNombreS.Text = CType(rstCliente.Rows(0)("NOMPRE_PERSONA1").ToString, String)
                                Else
                                    Me.txtNombreS.Text = ""
                                End If
                                Me.txtApellidoP.Text = CType(rstCliente.Rows(0)("APELLIDO_PATERNO").ToString, String)
                                Me.txtApellidoM.Text = CType(rstCliente.Rows(0)("APELLIDO_MATERNO").ToString, String)
                                Me.txtNumeroDocto.Text = CType(rstCliente.Rows(0)("DOCUMENTO").ToString, String)
                                If IsDate(rstCliente.Rows(0)("FECHA_NACIMIENTO").ToString) Then
                                    Me.txtFechaNacimiento._MyFecha = CType(rstCliente.Rows(0)("FECHA_NACIMIENTO").ToString, String)
                                Else
                                    Me.txtFechaNacimiento._MyFecha = "null"
                                End If

                                If CType(rstCliente.Rows(0)("SEXO_PERSONA").ToString, String) = "M" Then
                                    Me.rdbSexoMasCliente.Checked = True
                                ElseIf CType(rstCliente.Rows(0)("SEXO_PERSONA").ToString, String) = "F" Then
                                    Me.rdbSexoMasCliente.Checked = True
                                End If
                                If IsDBNull(rstCliente.Rows(0)("EMAIL").ToString) Then
                                    Me.txtCorreoElectronico.Text = ""
                                Else
                                    Me.txtCorreoElectronico.Text = CType(rstCliente.Rows(0)("EMAIL").ToString, String)
                                End If
                                Me.txtFechaRegistro._MyFecha = CType(rstCliente.Rows(0)("FECHA_INGRESO").ToString, String)
                                Me.chkCorporativo.Checked = CType(rstCliente.Rows(0)("CLIENTE_CORPORATIVO").ToString, Boolean)
                                Me.chkBase.Checked = IIf(IsDBNull(rstCliente.Rows(0)("MONTO_BASE").ToString), 0, rstCliente.Rows(0)("MONTO_BASE").ToString)
                                Me.chkPostFacturacion.Checked = CType(rstCliente.Rows(0)("PAGO_POST_FACTURACION").ToString, Boolean)
                                Me.chkAgenteRetencion.Checked = CType(rstCliente.Rows(0)("AGENTE_RETENCION").ToString, Boolean)
                                Me.cmbRubroEmpresarial.SelectedValue = CType(rstCliente.Rows(0)("IDRUBRO").ToString, Integer)
                                Me.cmbClasPersona.SelectedValue = CType(rstCliente.Rows(0)("IDCLASIFICACION_PERSONA").ToString, Integer)
                                Me.txtFuncionarioCuenta.Text = CType(rstCliente.Rows(0)("FUNCIONARIO").ToString, String)
                                If IsDBNull(rstCliente.Rows(0)("IDFUNCIONARIO_ACTUAL").ToString) Then
                                    CodFuncionarioNegocio = 0
                                Else
                                    CodFuncionarioNegocio = CType(rstCliente.Rows(0)("IDFUNCIONARIO_ACTUAL").ToString, Integer)
                                End If
                                Me.cmbPais.SelectedValue = CType(rstCliente.Rows(0)("IDPAIS").ToString, String)
                                Me.cmbDepartamento.SelectedValue = CType(rstCliente.Rows(0)("IDDEPARTAMENTO").ToString, String)
                                Me.cmbProvincia.SelectedValue = CType(rstCliente.Rows(0)("IDPROVINCIA").ToString, String)
                                Me.cmbDistrito.SelectedValue = CType(rstCliente.Rows(0)("IDDISTRITO").ToString, String)
                                Me.cmbTipoFacturacion.SelectedValue = CType(rstCliente.Rows(0)("IDTIPO_FACTURACION").ToString, Integer)

                                If Len(Trim(txtFuncionarioCuenta.Text)) = 0 Then
                                    txtFuncionarioCuenta.Text = "No Asignado..."
                                End If

                                If Len(Trim(txtRespFacturacion.Text)) = 0 Then
                                    txtRespFacturacion.Text = "No Asignado..."
                                End If

                                If txtRespFacturacion.Text = "No Asignado..." And txtFuncionarioCuenta.Text = "No Asignado..." Then
                                    chkContadoCredito.Checked = True
                                End If
                            End If
                        End If
                        'datahelper
                        'Dim rstCliente As ADODB.Recordset
                        'rstCliente = CargarCliente(txtRUC.Text)
                        'If CType(rstCliente.Fields("idtipo_persona").Value, Integer) = 1 Then     'Juridico
                        '    DeshabilitaControlesEdicion()
                        '    Me.cmbTipoPersona.SelectedValue = CType(rstCliente("idtipo_persona").Value, Integer)
                        '    vIDPersona = CType(rstCliente("idpersona").Value, Integer)
                        '    Me.txtCodigo.Text = CType(rstCliente("codigo_cliente").Value, String)
                        '    Me.txtRazonSocial.Text = CType(rstCliente("RAZON_SOCIAL").Value, String)
                        '    Me.txtRUC.Text = CType(rstCliente("NU_DOCU_SUNA").Value, String)
                        '    Me.txtGG.Text = CType(rstCliente("GERENTE_GENERAL").Value, String)
                        '    Me.txtRepLegal.Text = CType(rstCliente("REPRESENTANTE_LEGAL").Value, String)
                        '    If IsDBNull(rstCliente("EMAIL").Value) Then
                        '        Me.txtWebSite.Text = ""
                        '    Else
                        '        Me.txtWebSite.Text = CType(rstCliente("EMAIL").Value, String)
                        '    End If
                        '    Me.txtFechaRegistro._MyFecha = CType(rstCliente("FECHA_INGRESO").Value, String)
                        '    Me.chkCorporativo.Checked = CType(rstCliente("CLIENTE_CORPORATIVO").Value, Boolean)
                        '    If Me.chkCorporativo.Checked = False Then 'Tepsa si no es corporativo, va hacer contado 
                        '        Me.chkContadoCredito.Checked = True
                        '    End If
                        '    Me.chkPostFacturacion.Checked = CType(rstCliente("PAGO_POST_FACTURACION").Value, Boolean)
                        '    Me.chkAgenteRetencion.Checked = CType(rstCliente("AGENTE_RETENCION").Value, Boolean)
                        '    Me.cmbRubroEmpresarial.SelectedValue = CType(rstCliente("IDRUBRO").Value, Integer)
                        '    Me.cmbClasPersona.SelectedValue = CType(rstCliente("IDCLASIFICACION_PERSONA").Value, Integer)
                        '    Me.txtFuncionarioCuenta.Text = CType(rstCliente("FUNCIONARIO").Value, String)
                        '    If IsDBNull(rstCliente("IDFUNCIONARIO_ACTUAL").Value) Then
                        '        CodFuncionarioNegocio = 0
                        '    Else
                        '        CodFuncionarioNegocio = CType(rstCliente("IDFUNCIONARIO_ACTUAL").Value, Integer)
                        '    End If
                        '    Me.cmbPais.SelectedValue = CType(rstCliente("IDPAIS").Value, String)
                        '    Me.cmbDepartamento.SelectedValue = CType(rstCliente("IDDEPARTAMENTO").Value, String)
                        '    Me.cmbProvincia.SelectedValue = CType(rstCliente("IDPROVINCIA").Value, String)
                        '    Me.cmbDistrito.SelectedValue = CType(rstCliente("IDDISTRITO").Value, String)
                        '    Me.cmbTipoFacturacion.SelectedValue = CType(rstCliente("IDTIPO_FACTURACION").Value, Integer)

                        '    If Len(Trim(txtFuncionarioCuenta.Text)) = 0 Then
                        '        txtFuncionarioCuenta.Text = "No Asignado..."
                        '    End If

                        '    If Len(Trim(txtRespFacturacion.Text)) = 0 Then
                        '        txtRespFacturacion.Text = "No Asignado..."
                        '    End If

                        '    'hlamas
                        '    Me.chkBase.Checked = IIf(IsDBNull(rstCliente("MONTO_BASE").Value), 0, rstCliente("MONTO_BASE").Value)                            ' 
                        'End If

                        'If CType(rstCliente.Fields("idtipo_persona").Value, Integer) = 2 Then     'Natural
                        '    DeshabilitaControlesEdicion()
                        '    Me.cmbTipoPersona.SelectedValue = CType(rstCliente("idtipo_persona").Value, Integer)
                        '    vIDPersona = CType(rstCliente("idpersona").Value, Integer)
                        '    Me.txtCodigo.Text = CType(rstCliente("CODIGO").Value, String)
                        '    Me.txtNombreP.Text = CType(rstCliente("NOMPRE_PERSONA").Value, String)
                        '    If Not IsDBNull(rstCliente("NOMPRE_PERSONA1").Value) Then
                        '        Me.txtNombreS.Text = CType(rstCliente("NOMPRE_PERSONA1").Value, String)
                        '    Else
                        '        Me.txtNombreS.Text = ""
                        '    End If
                        '    Me.txtApellidoP.Text = CType(rstCliente("APELLIDO_PATERNO").Value, String)
                        '    Me.txtApellidoM.Text = CType(rstCliente("APELLIDO_MATERNO").Value, String)
                        '    Me.txtNumeroDocto.Text = CType(rstCliente("DOCUMENTO").Value, String)
                        '    If IsDate(rstCliente("FECHA_NACIMIENTO").Value) Then
                        '        Me.txtFechaNacimiento._MyFecha = CType(rstCliente("FECHA_NACIMIENTO").Value, String)
                        '    Else
                        '        Me.txtFechaNacimiento._MyFecha = "null"
                        '    End If

                        '    If CType(rstCliente("SEXO_PERSONA").Value, String) = "M" Then
                        '        Me.rdbSexoMasCliente.Checked = True
                        '    ElseIf CType(rstCliente("SEXO_PERSONA").Value, String) = "F" Then
                        '        Me.rdbSexoMasCliente.Checked = True
                        '    End If
                        '    If IsDBNull(rstCliente("EMAIL").Value) Then
                        '        Me.txtCorreoElectronico.Text = ""
                        '    Else
                        '        Me.txtCorreoElectronico.Text = CType(rstCliente("EMAIL").Value, String)
                        '    End If
                        '    Me.txtFechaRegistro._MyFecha = CType(rstCliente("FECHA_INGRESO").Value, String)
                        '    Me.chkCorporativo.Checked = CType(rstCliente("CLIENTE_CORPORATIVO").Value, Boolean)
                        '    Me.chkBase.Checked = IIf(IsDBNull(rstCliente("MONTO_BASE").Value), 0, rstCliente("MONTO_BASE").Value)
                        '    Me.chkPostFacturacion.Checked = CType(rstCliente("PAGO_POST_FACTURACION").Value, Boolean)
                        '    Me.chkAgenteRetencion.Checked = CType(rstCliente("AGENTE_RETENCION").Value, Boolean)
                        '    Me.cmbRubroEmpresarial.SelectedValue = CType(rstCliente("IDRUBRO").Value, Integer)
                        '    Me.cmbClasPersona.SelectedValue = CType(rstCliente("IDCLASIFICACION_PERSONA").Value, Integer)
                        '    Me.txtFuncionarioCuenta.Text = CType(rstCliente("FUNCIONARIO").Value, String)
                        '    If IsDBNull(rstCliente("IDFUNCIONARIO_ACTUAL").Value) Then
                        '        CodFuncionarioNegocio = 0
                        '    Else
                        '        CodFuncionarioNegocio = CType(rstCliente("IDFUNCIONARIO_ACTUAL").Value, Integer)
                        '    End If
                        '    Me.cmbPais.SelectedValue = CType(rstCliente("IDPAIS").Value, String)
                        '    Me.cmbDepartamento.SelectedValue = CType(rstCliente("IDDEPARTAMENTO").Value, String)
                        '    Me.cmbProvincia.SelectedValue = CType(rstCliente("IDPROVINCIA").Value, String)
                        '    Me.cmbDistrito.SelectedValue = CType(rstCliente("IDDISTRITO").Value, String)
                        '    Me.cmbTipoFacturacion.SelectedValue = CType(rstCliente("IDTIPO_FACTURACION").Value, Integer)

                        '    If Len(Trim(txtFuncionarioCuenta.Text)) = 0 Then
                        '        txtFuncionarioCuenta.Text = "No Asignado..."
                        '    End If

                        '    If Len(Trim(txtRespFacturacion.Text)) = 0 Then
                        '        txtRespFacturacion.Text = "No Asignado..."
                        '    End If

                        '    If txtRespFacturacion.Text = "No Asignado..." And txtFuncionarioCuenta.Text = "No Asignado..." Then
                        '        chkContadoCredito.Checked = True
                        '    End If
                        'End If

                        'Codigo del Edicion de la Plantilla
                        SelectMenu(1)
                        SplitContainer2.Panel1Collapsed = True
                        NuevoToolStripMenuItem.Enabled = False
                        EdicionToolStripMenuItem.Enabled = False
                        CancelarToolStripmenuItem.Enabled = True
                        CancelarToolStripmenuItem.Visible = True
                        GrabarToolStripMenuItem.Enabled = True 'Colocar en todos los formualrios esto, luego de dshabilitarlos.
                        EliminarToolStripMenuItem.Enabled = False
                        ExportarToolStripMenuItem.Enabled = False
                        ImprimirToolStripMenuItem.Enabled = False

                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtNumeroDocto_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNumeroDocto.Validating
        Try
            If txtNumeroDocto.Text.Trim.Length > 0 Then
                'datahelper
                'Dim Mybusqueda As ADODB.Recordset
                Dim Mybusqueda As DataTable
                Mybusqueda = BuscarCliente(txtNumeroDocto.Text)
                'If Mybusqueda.Fields.Count > 0 Then
                If Mybusqueda.Rows.Count > 0 Then
                    'If Mybusqueda.Fields.Item(0).Value = "EL CLIENTE YA EXISTE" Then
                    If Mybusqueda.Rows(0).Item(0).ToString = "EL CLIENTE YA EXISTE" Then
                        'MessageBox.Show(Mybusqueda.Fields.Item(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        MessageBox.Show(Mybusqueda.Rows(0).Item(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call LimpiaPersona()
                        Me.txtNombreP.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkCorporativo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCorporativo.CheckedChanged
        If sender.checked = True Then
            Me.btnFuncionarioCta.Enabled = True
            Me.chkContadoCredito.Checked = False
            Me.chkContadoCredito.Enabled = False
            'Tepsa 04/09/2006
            dvTipoFacturacion.RowFilter = "TIPO_FACTURACION <> 'CONTADO'"  ' Contado =  0, en el tipo de facturación  
            If iidtipo_facturacion <> 0 Then
                cmbTipoFacturacion.SelectedValue = iidtipo_facturacion
            Else
                cmbTipoFacturacion.SelectedValue = 1  ' Por defecto debe ser del tipo 1
            End If
        Else
            Me.chkContadoCredito.Checked = False
            Me.chkContadoCredito.Enabled = True
        End If
        cmbTipoFacturacion.Enabled = True
        btnTipoFacturacion.Enabled = True
    End Sub

    Private Sub btnRubroEmpresarial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRubroEmpresarial.Click
        Dim FrmNuevoRubro As FrmRubro_Cliente = New FrmRubro_Cliente
        'Dim resultado As DialogResult = FrmNuevoRubro.ShowDialog()
        Dim resultado As DialogResult
        Acceso.Asignar(FrmNuevoRubro, Me.Hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = FrmNuevoRubro.ShowDialog()
            If resultado = Windows.Forms.DialogResult.OK Then
                dtRubro.Clear()
                dtRubro = FrmNuevoRubro.NuevosRubros.Copy
                Dim ElIngresadoEs As Integer = FrmNuevoRubro.Ingresado
                dvRubro = Funciones.CargarCombo(cmbRubroEmpresarial, dtRubro, "RUBRO", "IDRUBRO", ElIngresadoEs)
            End If
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnClasPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClasPersona.Click
        Dim FrmNuevaClasificacion As FrmClasificacion_Cliente = New FrmClasificacion_Cliente
        'Dim resultado As DialogResult = FrmNuevaClasificacion.ShowDialog()
        Dim resultado As DialogResult
        Acceso.Asignar(FrmNuevaClasificacion, Me.Hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = FrmNuevaClasificacion.ShowDialog()
            If resultado = Windows.Forms.DialogResult.OK Then
                dtClasPersona.Clear()
                dtClasPersona = FrmNuevaClasificacion.NuevosRubros.Copy
                Dim ElIngresadoEs As Integer = FrmNuevaClasificacion.Ingresado
                dvClasPersona = Funciones.CargarCombo(cmbClasPersona, dtClasPersona, "CLASIFICACION_PERSONA", "IDCLASIFICACION_PERSONA", ElIngresadoEs)
            End If
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnAreaEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAreaEmpresa.Click
        Dim FrmNuevaClasificacion As FrmSubCuenta_Cliente = New FrmSubCuenta_Cliente
        'Dim resultado As DialogResult = FrmNuevaClasificacion.ShowDialog()
        Dim resultado As DialogResult
        Acceso.Asignar(FrmNuevaClasificacion, Me.Hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = FrmNuevaClasificacion.ShowDialog()
            If resultado = Windows.Forms.DialogResult.OK Then
                dtAreaEmpresa.Clear()
                dtAreaEmpresa = FrmNuevaClasificacion.NuevosRubros.Copy
                Dim ElIngresadoEs As Integer = FrmNuevaClasificacion.Ingresado
                dvAreaEmpresa = Funciones.CargarCombo(cmbAreaEmpresa, dtAreaEmpresa, "CENTRO_COSTO", "IDCENTRO_COSTO", ElIngresadoEs)
            End If
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnTipoContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipoContacto.Click
        Dim FrmNuevaClasificacion As FrmTipoContacto_Cliente = New FrmTipoContacto_Cliente
        'Dim resultado As DialogResult = FrmNuevaClasificacion.ShowDialog()
        Dim resultado As DialogResult
        Acceso.Asignar(FrmNuevaClasificacion, Me.Hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = FrmNuevaClasificacion.ShowDialog()
            If resultado = Windows.Forms.DialogResult.OK Then
                dtTipoContacto.Clear()
                dtTipoContacto = FrmNuevaClasificacion.NuevosRubros.Copy
                Dim ElIngresadoEs As Integer = FrmNuevaClasificacion.Ingresado
                dvTipoContacto = Funciones.CargarCombo(cmbTipoContacto, dtTipoContacto, "TIPO_CONTACTO", "IDTIPO_CONTACTO", ElIngresadoEs)
            End If
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnTipoDireccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipoDireccion.Click
        Dim FrmNuevaClasificacion As FrmTipoDireccion_Cliente = New FrmTipoDireccion_Cliente
        'Dim resultado As DialogResult = FrmNuevaClasificacion.ShowDialog()
        Dim resultado As DialogResult
        Acceso.Asignar(FrmNuevaClasificacion, Me.Hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = FrmNuevaClasificacion.ShowDialog()
            If resultado = Windows.Forms.DialogResult.OK Then
                dtTipoDireccion.Clear()
                dtTipoDireccion = FrmNuevaClasificacion.NuevosRubros.Copy
                Dim ElIngresadoEs As Integer = FrmNuevaClasificacion.Ingresado
                dvTipoDireccion = Funciones.CargarCombo(cmbTipoDireccion, dtTipoDireccion, "TIPO_DIRECCION", "IDTIPO_DIRECCION", ElIngresadoEs)
                dvTipoDireccion.RowFilter = "TIPO_DIRECCION<>'LEGAL'"
            End If
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ActualizaContactoJuridico(ByVal Accion As Integer)
        If vAccionRegistro = 1 Then 'Si 
            Dim ContactoClass As New dtoCONTACTO_CLIENTE
            With ContactoClass
                .Control = Accion 'vAccionRegistro
                .IDContactoPersona = 1 'Momentaneamente pero cambiar en actualizaciones
                .IDTipoContacto = cmbTipoContacto.SelectedValue
                .IDPersona = MyCodigoCliente
                .CentroCosto = cmbAreaEmpresa.SelectedValue
                .Nombres = txtNombrePCont.Text
                .Apepat = txtApellidoPCont.Text
                .Apemat = txtApellidoMCont.Text
                .IDTipoDocumentoContacto = cmbTipoDoctoContacto.SelectedValue
                .NumeroDoctumento = txtNumDoctoContacto.Text
                .EmailContacto = IIf(Len(Trim(txtEmailContacto.Text)) = 0, "NULL", txtEmailContacto.Text)
                MyNumeroDoctoContacto = txtNumDoctoContacto.Text
                If Me.TXT_IDCONTACTO_PERSONA.Text = "" Or IsDBNull(Me.TXT_IDCONTACTO_PERSONA.Text) = True Then
                    .sIDContactoPersona = "NULL"
                Else
                    .sIDContactoPersona = Me.TXT_IDCONTACTO_PERSONA.Text
                End If
                'MessageBox.Show(MyNumeroDoctoContacto)
                If rbtMasculino.Checked = True Then
                    .Sexo = "M"
                End If
                If rbtFemenino.Checked = True Then
                    .Sexo = "F"
                End If
                If chkActivoContacto.Checked = True Then
                    .EstadoRegistro = 1
                Else
                    .EstadoRegistro = 0
                End If
                .IDUsuariPersonal = MyUsuario
                .IDRolUsuario = MyRol
                .IP = MyIP '"192.168.50.47"
            End With

            'datahelper
            'Dim restContacto As ADODB.Recordset
            'restContacto = ContactoClass.GrabaContacto()
            Dim restContacto As DataTable = ContactoClass.GrabaContacto()
            If restContacto.Rows.Count = 1 Then 'Se realizo Correctamente.
                AgregarTelefonosContacto(2)
                Paso2 = 1
            ElseIf restContacto.Rows.Count = 2 And Len(Trim(restContacto.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                MessageBox.Show("Descripción: " & restContacto.Rows(0).Item(1).ToString, "ORACLE -> Error: " & restContacto.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            'datahelper
            'If restContacto.Fields.Count = 1 Then 'Se realizo Correctamente.
            '    AgregarTelefonosContacto(2)
            '    Paso2 = 1
            'ElseIf restContacto.Fields.Count = 2 And Len(Trim(restContacto.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
            '    MessageBox.Show("Descripción: " & restContacto.Fields(1).Value, "ORACLE -> Error: " & restContacto.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If

        End If

        If vAccionRegistro = 2 Then
            If vActualizaContacto = 0 Then 'Si se carga Datos en la Grilla de Contactos
                'MessageBox.Show("Seleccione un Contacto de la Lista y de DobleClik.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim ContactoClass As New dtoCONTACTO_CLIENTE
                With ContactoClass
                    .Control = Accion
                    '.IDContactoPersona = 1 'Momentaneamente pero cambiar en actualizaciones
                    .IDTipoContacto = cmbTipoContacto.SelectedValue
                    .IDPersona = MyCodigoCliente
                    .CentroCosto = cmbAreaEmpresa.SelectedValue
                    .Nombres = txtNombrePCont.Text
                    .Apepat = txtApellidoPCont.Text
                    .Apemat = txtApellidoMCont.Text
                    .IDTipoDocumentoContacto = cmbTipoDoctoContacto.SelectedValue
                    .NumeroDoctumento = txtNumDoctoContacto.Text
                    .EmailContacto = IIf(Len(Trim(txtEmailContacto.Text)) = 0, "NULL", txtEmailContacto.Text)
                    MyNumeroDoctoContacto = txtNumDoctoContacto.Text
                    'MessageBox.Show(MyNumeroDoctoContacto)
                    If Me.TXT_IDCONTACTO_PERSONA.Text = "" Or IsDBNull(Me.TXT_IDCONTACTO_PERSONA.Text) = True Then
                        .sIDContactoPersona = "NULL"
                    Else
                        .sIDContactoPersona = Me.TXT_IDCONTACTO_PERSONA.Text
                    End If
                    If rbtMasculino.Checked = True Then
                        .Sexo = "M"
                    End If
                    If rbtFemenino.Checked = True Then
                        .Sexo = "F"
                    End If
                    If chkActivoContacto.Checked = True Then
                        .EstadoRegistro = 1
                    Else
                        .EstadoRegistro = 0
                    End If
                    .IDUsuariPersonal = MyUsuario
                    .IDRolUsuario = MyRol
                    .IP = MyIP '"192.168.50.47"
                End With

                'datahelper
                'Dim restContacto As ADODB.Recordset
                'restContacto = ContactoClass.GrabaContacto()
                Dim restContacto As DataTable = ContactoClass.GrabaContacto()

                If restContacto.Rows.Count = 1 Then 'Se realizo Correctamente.
                    MessageBox.Show(restContacto.Rows(0).Item(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    AgregarTelefonosContacto(2)
                    Paso2 = 1
                ElseIf restContacto.Rows.Count = 2 And Len(Trim(restContacto.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                    MessageBox.Show("Descripción: " & restContacto.Rows(0).Item(1).ToString, "ORACLE -> Error: " & restContacto.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                'datahelper
                'If restContacto.Fields.Count = 1 Then 'Se realizo Correctamente.
                '    MessageBox.Show(restContacto.Fields(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    AgregarTelefonosContacto(2)
                '    Paso2 = 1
                'ElseIf restContacto.Fields.Count = 2 And Len(Trim(restContacto.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                '    MessageBox.Show("Descripción: " & restContacto.Fields(1).Value, "ORACLE -> Error: " & restContacto.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End If
            End If

            If vActualizaContacto = 1 Then 'No carga Datos en la Grilla de Contactos
                Dim ContactoClass As New dtoCONTACTO_CLIENTE
                With ContactoClass
                    .Control = Accion
                    .IDContactoPersona = 1 'Momentaneamente pero cambiar en actualizaciones
                    .IDTipoContacto = cmbAreaEmpresa.SelectedValue
                    .IDPersona = MyCodigoCliente
                    .CentroCosto = cmbAreaEmpresa.SelectedValue
                    .Nombres = txtNombrePCont.Text
                    .Apepat = txtApellidoPCont.Text
                    .Apemat = txtApellidoMCont.Text
                    .IDTipoDocumentoContacto = cmbTipoDoctoContacto.SelectedValue
                    .NumeroDoctumento = txtNumDoctoContacto.Text
                    .EmailContacto = IIf(Len(Trim(txtEmailContacto.Text)) = 0, "NULL", txtEmailContacto.Text)
                    MyNumeroDoctoContacto = txtNumDoctoContacto.Text
                    'MessageBox.Show(MyNumeroDoctoContacto)
                    If rbtMasculino.Checked = True Then
                        .Sexo = "M"
                    End If
                    If rbtFemenino.Checked = True Then
                        .Sexo = "F"
                    End If
                    If chkActivoContacto.Checked = True Then
                        .EstadoRegistro = 1
                    Else
                        .EstadoRegistro = 0
                    End If
                    .IDUsuariPersonal = MyUsuario
                    .IDRolUsuario = MyRol
                    .IP = MyIP '"192.168.50.47"
                End With

                'datahelper
                'Dim restContacto As ADODB.Recordset
                'restContacto = ContactoClass.GrabaContacto()
                Dim restContacto As DataTable = ContactoClass.GrabaContacto()
                If restContacto.Rows.Count = 1 Then 'Se realizo Correctamente.
                    MessageBox.Show(restContacto.Rows(0).Item(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    AgregarTelefonosContacto(2)
                    Paso2 = 1
                ElseIf restContacto.Rows.Count = 2 And Len(Trim(restContacto.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                    MessageBox.Show("Descripción: " & restContacto.Rows(0).Item(1).ToString, "ORACLE -> Error: " & restContacto.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                'datahelper
                'If restContacto.Fields.Count = 1 Then 'Se realizo Correctamente.
                '    MessageBox.Show(restContacto.Fields(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    AgregarTelefonosContacto(2)
                '    Paso2 = 1
                'ElseIf restContacto.Fields.Count = 2 And Len(Trim(restContacto.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                '    MessageBox.Show("Descripción: " & restContacto.Fields(1).Value, "ORACLE -> Error: " & restContacto.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End If
            End If
        End If

    End Sub

    Private Sub CargaDirecciones(ByVal MyCodigoCliente As String, ByVal MyGrillaConData As DataGridView)
        Try
            'Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_CARGA_DIRECCIONES", 4, MyCodigoCliente, 2}
            'Dim rstDireccionesCliente As ADODB.Recordset = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
            'Dim daDireccionesCliente As New OleDbDataAdapter

            'daDireccionesCliente.Fill(dtDireccionesCliente, rstDireccionesCliente)
            Dim dvDireccionesCliente As DataView
            Dim objCliente As New dtoCLIENTES
            dtDireccionesCliente = objCliente.fn_carga_direcciones(MyCodigoCliente)
            dvDireccionesCliente = dtDireccionesCliente.DefaultView

            MyGrillaConData.Columns.Clear()
            With MyGrillaConData
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = True
                .AllowUserToAddRows = True
                .AutoGenerateColumns = False
                .DataSource = dtDireccionesCliente.DefaultView
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .Font = New System.Drawing.Font("Arial", 8.0!, FontStyle.Regular)
                .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                .VirtualMode = True
                .RowHeadersVisible = False
                .ReadOnly = True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End With

            Dim Col0 As New DataGridViewTextBoxColumn
            With Col0
                .Name = "ORDEN"
                .DataPropertyName = "ORDEN"
                .HeaderText = "ORDEN"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '.Frozen = True
            End With
            Dim Col1 As New DataGridViewTextBoxColumn
            With Col1
                .Name = "IDDIRECCION_CONSIGNADO"
                .DataPropertyName = "IDDIRECCION_CONSIGNADO"
                .HeaderText = "IDDIRECCION_CONSIGNADO"
            End With
            Dim Col2 As New DataGridViewTextBoxColumn
            With Col2
                .Name = "IDTIPO_DIRECCION"
                .DataPropertyName = "IDTIPO_DIRECCION"
                .HeaderText = "IDTIPO_DIRECCION"
            End With
            Dim Col3 As New DataGridViewTextBoxColumn
            With Col3
                .Name = "TIPO_DIRECCION"
                .DataPropertyName = "TIPO_DIRECCION"
                .HeaderText = "TIPO_DIRECCION"
                '.Frozen = True
            End With
            Dim Col4 As New DataGridViewTextBoxColumn
            With Col4
                .Name = "IDPERSONA"
                .DataPropertyName = "IDPERSONA"
                .HeaderText = "IDPERSONA"
            End With
            Dim Col5 As New DataGridViewTextBoxColumn
            With Col5
                .Name = "DIRECCION"
                .DataPropertyName = "DIRECCION"
                .HeaderText = "DIRECCION"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                '.Frozen = True
            End With
            Dim Col6 As New DataGridViewTextBoxColumn
            With Col6
                .Name = "DE_REFERENCIA"
                .DataPropertyName = "DE_REFERENCIA"
                .HeaderText = "DE_REFERENCIA"
            End With
            Dim Col7 As New DataGridViewTextBoxColumn
            With Col7
                .Name = "CO_UBIC_GEOG"
                .DataPropertyName = "CO_UBIC_GEOG"
                .HeaderText = "UBIGEO"
            End With
            Dim Col8 As New DataGridViewCheckBoxColumn
            With Col8
                .Name = "DIRECCION_FACTURACION"
                .DataPropertyName = "DIRECCION_FACTURACION"
                .HeaderText = "¿FACTURACION?"
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
            End With
            Dim Col9 As New DataGridViewTextBoxColumn
            With Col9
                .Name = "CODIGO_UBIGEO"
                .DataPropertyName = "CODIGO_UBIGEO"
                .HeaderText = "CODIGO_UBIGEO"
            End With
            Dim Col10 As New DataGridViewTextBoxColumn
            With Col10
                .Name = "HORA_RECOJO_INICIO"
                .DataPropertyName = "HORA_RECOJO_INICIO"
                .HeaderText = "HORA_RECOJO_INICIO"
            End With
            Dim Col11 As New DataGridViewTextBoxColumn
            With Col11
                .Name = "HORA_RECOJO_FIN"
                .DataPropertyName = "HORA_RECOJO_FIN"
                .HeaderText = "HORA_RECOJO_FIN"
            End With
            Dim Col12 As New DataGridViewTextBoxColumn
            With Col12
                .Name = "HORA_ENTREGA_INICIO"
                .DataPropertyName = "HORA_ENTREGA_INICIO"
                .HeaderText = "HORA_ENTREGA_INICIO"
            End With
            Dim Col13 As New DataGridViewTextBoxColumn
            With Col13
                .Name = "HORA_ENTREGA_FIN"
                .DataPropertyName = "HORA_ENTREGA_FIN"
                .HeaderText = "HORA_ENTREGA_FIN"
            End With
            Dim Col14 As New DataGridViewTextBoxColumn
            With Col14
                .Name = "IDPAIS"
                .DataPropertyName = "IDPAIS"
                .HeaderText = "IDPAIS"
            End With
            Dim Col15 As New DataGridViewTextBoxColumn
            With Col15
                .Name = "IDDEPARTAMENTO"
                .DataPropertyName = "IDDEPARTAMENTO"
                .HeaderText = "IDDEPARTAMENTO"
            End With
            Dim Col16 As New DataGridViewTextBoxColumn
            With Col16
                .Name = "IDPROVINCIA"
                .DataPropertyName = "IDPROVINCIA"
                .HeaderText = "IDPROVINCIA"
            End With
            Dim Col17 As New DataGridViewTextBoxColumn
            With Col17
                .Name = "IDDISTRITO"
                .DataPropertyName = "IDDISTRITO"
                .HeaderText = "IDDISTRITO"
            End With
            Dim Col18 As New DataGridViewTextBoxColumn
            With Col18
                .Name = "PAIS"
                .DataPropertyName = "PAIS"
                .HeaderText = "PAIS"
            End With
            Dim Col19 As New DataGridViewTextBoxColumn
            With Col19
                .Name = "DEPARTAMENTO"
                .DataPropertyName = "DEPARTAMENTO"
                .HeaderText = "DEPARTAMENTO"
            End With
            Dim Col20 As New DataGridViewTextBoxColumn
            With Col20
                .Name = "PROVINCIA"
                .DataPropertyName = "PROVINCIA"
                .HeaderText = "PROVINCIA"
            End With
            Dim Col21 As New DataGridViewTextBoxColumn
            With Col21
                .Name = "DISTRITO"
                .DataPropertyName = "DSITRITO"
                .HeaderText = "DISTRITO"
            End With
            MyGrillaConData.Columns.AddRange(Col0, Col1, Col2, Col3, Col4, Col5, Col6, Col7, Col8, Col9, Col10, Col11, Col12, Col13, Col14, Col15, Col16, Col17, Col18, Col19, Col20, Col21)

            For i As Integer = 0 To 20
                MyGrillaConData.Columns(i).Visible = False
            Next

            MyGrillaConData.Columns(0).Visible = True
            MyGrillaConData.Columns(3).Visible = True
            MyGrillaConData.Columns(5).Visible = True
            MyGrillaConData.Columns(8).Visible = True
            MyGrillaConData.Columns(18).Visible = True
            MyGrillaConData.Columns(19).Visible = True
            MyGrillaConData.Columns(20).Visible = True
            MyGrillaConData.Columns(21).Visible = True

            MyGrillaConData.Columns(8).Frozen = True

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgvDirecciones_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDirecciones.DoubleClick
        Try
            Dim dgvr As DataGridViewRow = Me.dgvDirecciones.CurrentRow
            If Not dgvr Is Nothing Then
                Me.cmbTipoDireccion.SelectedValue = dgvr.Cells("IDTIPO_DIRECCION").Value
                Me.txtDireccion.Text = dgvr.Cells("DIRECCION").Value
                Me.txtReferencia.Text = dgvr.Cells("DE_REFERENCIA").Value
                Me.txtCodigoUbigeo.Text = dgvr.Cells("CO_UBIC_GEOG").Value
                If dgvr.Cells("DIRECCION_FACTURACION").Value = 1 Then
                    chkDireccionFacturacion.Checked = True
                Else
                    chkDireccionFacturacion.Checked = False
                End If

                'MessageBox.Show(CType(dgvr.Cells("HORA_RECOJO_INICIO").Value, Date))
                Me.dtpHoraRecojoInicio.Text = CType(dgvr.Cells("HORA_RECOJO_INICIO").Value, Date)
                Me.dtpHoraRecojoFinal.Text = CType(dgvr.Cells("HORA_RECOJO_FIN").Value, Date)
                Me.dtpHoraEntregaInicio.Text = CType(dgvr.Cells("HORA_ENTREGA_INICIO").Value, Date)
                Me.dtpHoraEntregaFinal.Text = CType(dgvr.Cells("HORA_ENTREGA_FIN").Value, Date)

                Me.cmbPaisDirecciones.SelectedValue = dgvr.Cells("IDPAIS").Value
                Me.cmbDepartamentoDirecciones.SelectedValue = dgvr.Cells("IDDEPARTAMENTO").Value
                Me.cmbProvinciaDirecciones.SelectedValue = dgvr.Cells("IDPROVINCIA").Value
                Me.cmbDistritoDirecciones.SelectedValue = dgvr.Cells("IDDISTRITO").Value

                lblIDDireccion.Text = dgvr.Cells("IDDIRECCION_CONSIGNADO").Value

                'datahelper
                'Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_LISTA_CONTACTOS_1", 6, Me.txtCodigo.Text, 2, lblIDDireccion.Text, 2}
                'Dim rstContactos As ADODB.Recordset = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
                'Dim da As New OleDbDataAdapter
                Dim dtContactosDirecciones As New DataTable
                dtContactosDirecciones.Clear()
                dgvContactosDirecciones.Columns.Clear()
                'da.Fill(dtContactosDirecciones, rstContactos)

                Dim objcliente As New dtoCLIENTES
                dtContactosDirecciones = objcliente.fn_LISTA_CONTACTOS_1(Me.txtCodigo.Text, lblIDDireccion.Text)

                With Me.dgvContactosDirecciones
                    .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
                    .AllowUserToOrderColumns = True
                    .AllowUserToDeleteRows = False
                    .AllowUserToAddRows = True
                    .AutoGenerateColumns = False
                    .DataSource = dtContactosDirecciones.DefaultView
                    .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    .SelectionMode = DataGridViewSelectionMode.CellSelect
                    .Font = New System.Drawing.Font("Arial", 8.0!, FontStyle.Regular)
                    .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                    .VirtualMode = True
                    .RowHeadersVisible = True
                    .ReadOnly = False
                    .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                End With
                Dim col0 As New DataGridViewTextBoxColumn
                With col0
                    .Name = "IDCONTACTO_PERSONA"
                    .DataPropertyName = "IDCONTACTO_PERSONA"
                    .HeaderText = "IDCONTACTO_PERSONA"
                End With
                Dim col1 As New DataGridViewTextBoxColumn
                With col1
                    .Name = "IDTIPO_CONTACTO"
                    .DataPropertyName = "IDCENTRO_COSTO"
                    .HeaderText = "IDTIPO_CONTACTO"
                End With
                Dim col2 As New DataGridViewTextBoxColumn
                With col2
                    .Name = "TIPO_CONTACTO"
                    .DataPropertyName = "TIPO_CONTACTO"
                    .HeaderText = "TIPO_CONTACTO"
                End With
                Dim col3 As New DataGridViewCheckBoxColumn
                With col3
                    .Name = "SELECCIONAR"
                    .DataPropertyName = "SELECCIONAR"
                    .HeaderText = "SELECCIONAR"
                    .ThreeState = False
                    .TrueValue = 1
                    .FalseValue = 0
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                End With
                Dim col4 As New DataGridViewTextBoxColumn
                With col4
                    .Name = "NOMBRE_APELLIDO"
                    .DataPropertyName = "NOMBRE_APELLIDO"
                    .HeaderText = "NOMBRE_APELLIDO"
                    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .Width = 400
                End With
                dgvContactosDirecciones.Columns.AddRange(col0, col1, col2, col3, col4)
                dgvContactosDirecciones.Columns(0).Visible = False
                dgvContactosDirecciones.Columns(1).Visible = False
                dgvContactosDirecciones.Columns(3).Frozen = True
            End If
            Me.btnAgregarDireccion.Enabled = False
            Me.btnActualizarDireccion.Enabled = True

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnActualizarDireccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnActualizarDireccion.Click
        Try
            'If SeleccionoContacto() = 0 Then
            'MessageBox.Show("Seleccione los Contactos de esta Dirección", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'btnSeleccionarContactos.PerformClick()
            'ElseIf SeleccionoContacto() > 0 Then
            Dim MyObligatorios() As Object = {Me.txtCodigoUbigeo, Me.txtDireccion, Me.cmbPaisDirecciones, Me.btnPaisDirecciones, Me.cmbDepartamentoDirecciones, Me.btnDepartamentoDirecciones, Me.cmbProvinciaDirecciones, Me.btnProvinciaDirecciones, Me.cmbDistritoDirecciones, Me.btnDistritoDirecciones}
            If Funciones.Validaciones(MyObligatorios) = 0 Then

                Try
                    Dim dgvr As DataGridViewRow = Me.dgvDirecciones.CurrentRow

                    dgvr.Cells("ORDEN").Value = Me.dgvDirecciones.RowCount  'ORDEN
                    'drwDirecciones("TIPO_DIRECCION") = True 'ACTIVO
                    dgvr.Cells("TIPO_DIRECCION").Value = Me.cmbTipoDireccion.Text 'TIPO DIRECCION
                    dgvr.Cells("DIRECCION").Value = Me.txtDireccion.Text 'DIRECCION
                    If Me.chkDireccionFacturacion.Checked = True Then
                        dgvr.Cells("DIRECCION_FACTURACION").Value = True
                    Else
                        dgvr.Cells("DIRECCION_FACTURACION").Value = False
                    End If
                    'drwDirecciones(5) = Me.cmbContactoDireccion.Text 'CONTACTO
                    dgvr.Cells("PAIS").Value = Me.cmbPaisDirecciones.Text 'PAIS
                    dgvr.Cells("DEPARTAMENTO").Value = Me.cmbDepartamentoDirecciones.Text 'DEPARTAMENTO
                    dgvr.Cells("PROVINCIA").Value = Me.cmbProvinciaDirecciones.Text 'PROVINCIA
                    dgvr.Cells("DISTRITO").Value = Me.cmbDistritoDirecciones.Text 'DISTRITO

                    Call AgregaDireccion(2)
                    dtDireccionesCliente.Clear()
                    Call CargaDirecciones(txtCodigoClienteDirecciones.Text, dgvDirecciones)

                    dvTipoDireccion.RowFilter = "TIPO_DIRECCION<>'LEGAL'"
                    btnTipoDireccion.Enabled = True
                    chkDireccionFacturacion.Checked = False

                    Try 'Limpieza de TextBox
                        For Each MyObj As Object In TabPage2.Controls
                            If TypeOf MyObj Is TextBox Then
                                CType(MyObj, TextBox).Text = ""
                            End If
                        Next
                    Catch Qex As Exception
                        MessageBox.Show(Qex.Message, "Seguridad Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Catch Pex As System.Data.ConstraintException
                    MessageBox.Show("Este Contacto ya esta asociado a una Dirección.", "Seguridad Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch Qex As Exception
                    MessageBox.Show(Qex.Message, "Seguridad Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                Me.btnActualizarDireccion.Enabled = False
                Me.btnAgregarDireccion.Enabled = True
                Me.chkDireccionFacturacion.Enabled = False
            Else
                Me.btnActualizarDireccion.Enabled = True
                Me.btnAgregarDireccion.Enabled = False
                Me.chkDireccionFacturacion.Enabled = True
            End If
            'End If

            txtCodigoUbigeo.Text = "00000"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmClientes_MenuImprimir() Handles Me.MenuImprimir
        Dim a As New ClsPrint
        a.Titulo = "CLIENTES CARGA"
        a.DGV = Me.DataGridLista
        Dim MyReport As New Reportes
        'MyReport.MdiParent = FrmContenedor    tepsa 
        MyReport.MdiParent = Principal
        MyReport.pd.Document = a
        MyReport.pd.Dock = DockStyle.Fill
        MyReport.WindowState = FormWindowState.Maximized
        '
        'FrmContenedor.SplitContainer1.Panel2.Controls.Add(MyReport) tepsa 
        'Principal.Panel1.Controls.Add(MyReport)
        '
        MyReport.Show()
        MyReport.BringToFront()
    End Sub

    Private Sub CargaAsociacionContacto()

    End Sub

    Private Sub CargaContactosDirecciones2009_eliminarlo()
        'Try
        '    'hlamas
        '    'Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_LISTA_CONTACTOS", 4, Me.txtCodigoClienteContacto.Text, 2}
        '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_LISTA_CONTACTOS", 4, Me.txtCodigo.Text, 2}
        '    Dim rstContactos As ADODB.Recordset = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
        '    'Dim da As New OleDbDataAdapter
        '    Dim dtContactosDirecciones As New DataTable
        '    dtContactosDirecciones.Clear()
        '    dgvContactosDirecciones.Columns.Clear()
        '    da.Fill(dtContactosDirecciones, rstContactos)

        '    With Me.dgvContactosDirecciones
        '        .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
        '        .AllowUserToOrderColumns = True
        '        .AllowUserToDeleteRows = False
        '        .AllowUserToAddRows = True
        '        .AutoGenerateColumns = False
        '        .DataSource = dtContactosDirecciones.DefaultView
        '        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
        '        .SelectionMode = DataGridViewSelectionMode.CellSelect
        '        .Font = New System.Drawing.Font("Arial", 8.0!, FontStyle.Regular)
        '        .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        '        .VirtualMode = True
        '        .RowHeadersVisible = True
        '        .ReadOnly = False
        '        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        '    End With

        '    Dim col0 As New DataGridViewTextBoxColumn
        '    With col0
        '        .Name = "IDCONTACTO_PERSONA"
        '        .DataPropertyName = "IDCONTACTO_PERSONA"
        '        .HeaderText = "IDCONTACTO_PERSONA"
        '    End With
        '    Dim col1 As New DataGridViewTextBoxColumn
        '    With col1
        '        .Name = "IDTIPO_CONTACTO"
        '        .DataPropertyName = "IDCENTRO_COSTO"
        '        .HeaderText = "IDTIPO_CONTACTO"
        '    End With
        '    Dim col2 As New DataGridViewTextBoxColumn
        '    With col2
        '        .Name = "TIPO_CONTACTO"
        '        .DataPropertyName = "TIPO_CONTACTO"
        '        .HeaderText = "TIPO_CONTACTO"
        '    End With
        '    Dim col3 As New DataGridViewCheckBoxColumn
        '    With col3
        '        .Name = "SELECCIONAR"
        '        .DataPropertyName = "SELECCIONAR"
        '        .HeaderText = "SELECCIONAR"
        '        .ThreeState = False
        '        .TrueValue = 1
        '        .FalseValue = 0
        '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        '    End With
        '    Dim col4 As New DataGridViewTextBoxColumn
        '    With col4
        '        .Name = "NOMBRE_APELLIDO"
        '        .DataPropertyName = "NOMBRE_APELLIDO"
        '        .HeaderText = "NOMBRE_APELLIDO"
        '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '        .Width = 400
        '    End With
        '    dgvContactosDirecciones.Columns.AddRange(col0, col1, col2, col3, col4)
        '    dgvContactosDirecciones.Columns(0).Visible = False
        '    dgvContactosDirecciones.Columns(1).Visible = False
        '    dgvContactosDirecciones.Columns(3).Frozen = True
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub btnSeleccionarContactos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionarContactos.Click
        If Me.dgvContactosDirecciones.Size.Height = 169 Then 'Cierra
            Me.dgvContactosDirecciones.Size = New Size(265, 20)
            btnSeleccionarContactos.Location = New Point(474, 220)
            'btnAgregarDireccion.Enabled = True
            'btnActualizarDireccion.Enabled = True
            dgvDirecciones.Enabled = True
            dtpHoraEntregaInicio.Enabled = True
            dtpHoraEntregaFinal.Enabled = True
            dtpHoraRecojoInicio.Enabled = True
            dtpHoraRecojoFinal.Enabled = True
        ElseIf Me.dgvContactosDirecciones.Size.Height = 20 Then 'Abre
            Me.dgvContactosDirecciones.Size = New Size(463, 169)
            btnSeleccionarContactos.Location = New Point(673, 220)
            'btnAgregarDireccion.Enabled = False
            'btnActualizarDireccion.Enabled = False
            dgvDirecciones.Enabled = False
            dtpHoraEntregaInicio.Enabled = False
            dtpHoraEntregaFinal.Enabled = False
            dtpHoraRecojoInicio.Enabled = False
            dtpHoraRecojoFinal.Enabled = False
        End If


    End Sub

    Private Function SeleccionoContacto() As Integer
        Dim cont As Integer = 0
        For i As Integer = 0 To dgvContactosDirecciones.RowCount - 1
            If Not IsDBNull(dgvContactosDirecciones.Rows(i).Cells("SELECCIONAR").Value) Then
                If dgvContactosDirecciones.Rows(i).Cells("SELECCIONAR").Value = 1 Then
                    cont += 1
                End If
            End If
        Next
        Return cont
    End Function

    Private Sub FrmClientes_MenuExWord() Handles Me.MenuExWord
        Call GeneraArchivo(Me.DataGridLista, ".\RVCSoft.txt")
        'Shell("C:\WINDOWS\system32\notepad.exe", AppWinStyle.MaximizedFocus)

        Dim proceso As Process = New Process()
        'Indicamos el Programa
        proceso.StartInfo.FileName = "Notepad.exe"
        'proceso.StartInfo.FileName = "Winword.exe"
        'Indicamos la ruta del archivo
        proceso.StartInfo.Arguments = ".\RVCSoft.txt"
        'Ejecutamos el proceso
        proceso.Start()
    End Sub
    Private Sub FrmClientes_MenuExExcel() Handles Me.MenuExExcel
        Try
            Dim objcliente As New dtoCLIENTES
            Me.DGV_tmp.DataSource = objcliente.fn_Excel
            fnEXCELGrid(Me.DGV_tmp)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try

        'datahelper
        'Dim dtgview As New DataGridView
        'Dim rstfuncionario_cliente As New ADODB.Recordset
        'Dim dt_funcionario_cliente As New DataTable
        'Try
        '    Dim varSP_OBJECT() As Object = {"PKG_IVOPERSONA.sp_get_cliente_x_funcionario", 2}
        '    rstfuncionario_cliente = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        '    doledbda.Fill(dt_funcionario_cliente, rstfuncionario_cliente)
        '    Me.DGV_tmp.DataSource = dt_funcionario_cliente.DefaultView
        '    fnEXCELGrid(Me.DGV_tmp)  ' Nuevo 
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        'End Try
    End Sub
    Private Sub FrmClientes_MenuExEMail() Handles Me.MenuExEMail
        Try
            Call GeneraArchivo(Me.DataGridLista, ".\RVCSoft.txt")

            Dim MyMail As New Net.Mail.MailMessage
            Dim File As Net.Mail.Attachment
            Dim smtp As New System.Net.Mail.SmtpClient
            MyMail.From = New System.Net.Mail.MailAddress("evizcarra@tepsa.com.pe")
            MyMail.To.Add("rvasquez@tepsa.com.pe")
            'MyMail.To.Add("evizcarra@tepsa.com.pe")
            MyMail.Subject = "Prueba de Correo"
            MyMail.Body = "Prueba de Correo RVC"
            File = New Net.Mail.Attachment(".\RVCSoft.txt")
            MyMail.Attachments.Add(File)
            smtp.Host = "192.168.200.2"
            'SmtpMail.SmtpServer = "192.168.50.1"
            smtp.Send(MyMail)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    Private Sub btnTipoDocumentoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipoDocumentoCliente.Click
        Dim FrmNuevoDocumento As FrmTipoDocumentoIdentidad = New FrmTipoDocumentoIdentidad
        'Dim resultado As DialogResult = FrmNuevoDocumento.ShowDialog()
        Dim resultado As DialogResult
        Acceso.Asignar(FrmNuevoDocumento, Me.Hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = FrmNuevoDocumento.ShowDialog()
            If resultado = Windows.Forms.DialogResult.OK Then
                dtTipoDocPersona.Clear()
                dtTipoDocPersona2.Clear()
                dtTipoDocPersona = FrmNuevoDocumento.NuevosRubros.Copy
                dtTipoDocPersona2 = FrmNuevoDocumento.NuevosRubros.Copy
                Dim ElIngresadoEs As Integer = FrmNuevoDocumento.Ingresado
                dvTipoDocPersona2 = Funciones.CargarCombo(cmbTipoDoctoContacto, dtTipoDocPersona2, "TIPO_DOC_IDENTIDAD", "IDTIPO_DOC_IDENTIDAD", ElIngresadoEs)
                dvTipoDocPersona = Funciones.CargarCombo(cmbTipoDocIdent, dtTipoDocPersona, "TIPO_DOC_IDENTIDAD", "IDTIPO_DOC_IDENTIDAD", ElIngresadoEs)
                'dvTipoDocPersona = Funciones.CargarCombo(cmbTipoDocIdent, dtTipoDocPersona, "TIPO_DOC_IDENTIDAD", "IDTIPO_DOC_IDENTIDAD", ElIngresadoEs)
            End If
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnPaisDirecciones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPaisDirecciones.Click
        Dim Parametros() As String = {"Mantenimiento de Geográfico", "PKG_IVOPERSONA.SP_GRILLASUBICACION", "PKG_IVOPERSONA.SP_INSUPD_PAIS", "IDPAIS", "PAIS", "IDDEPARTAMENTO", "PAIS", "DEPARTAMENTO", "IDPROVINCIA", "PAIS", "DEPARTAMENTO", "PROVINCIA", "IDDISTRITO", "PAIS", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "ID PAIS", "NOMBRE DEL PAIS", "ID DEPARTAMENTO", "NOMBRE DEPARTAMENTO", "ID PROVINCIA", "NOMBRE PROVINCIA", "ID DISTRITO", "NOMBRE DISTRITO", "1", "MANT. PAISES", "MANT. DEPARTAMENTOS", "MANT. PROVINCIAS", "MANT. DISTRITOS"}
        Dim a As FrmDosCampos = New FrmDosCampos(Parametros)
        'Dim resultado As DialogResult = a.ShowDialog()

        Dim resultado As DialogResult
        Acceso.Asignar(a, Me.Hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = a.ShowDialog()
            If resultado = Windows.Forms.DialogResult.OK Then
                dtPaisCombo.Clear()
                dtDepartamentoCombo.Clear()
                dtProvinciaCombo.Clear()
                dtDistritoCombo.Clear()

                dtPaisCombo = a.dtPaisFinal.Copy
                dtDepartamentoCombo = a.dtDepartamentoFinal.Copy
                dtProvinciaCombo = a.dtProvinciaFinal.Copy
                dtDistritoCombo = a.dtDistritoFinal.Copy

                dvPais = dtPaisCombo.DefaultView
                dvDepartamento = dtDepartamentoCombo.DefaultView
                dvProvincia = dtProvinciaCombo.DefaultView
                dvDistrito = dtDistritoCombo.DefaultView

                Call CargaCombosDirecciones()

                cmbPais.DataSource = dvPais
                cmbPais.DisplayMember = "PAIS"
                cmbPais.ValueMember = "IDPAIS"

                Dim FiltroDepartamento As String = ""
                Dim MyParametroD As Integer = cmbPais.SelectedValue
                FiltroDepartamento = "IDPAIS = '" & MyParametroD & "'"
                dvDepartamento.RowFilter = FiltroDepartamento
                cmbDepartamento.DataSource = dvDepartamento
                cmbDepartamento.DisplayMember = "DEPARTAMENTO"
                cmbDepartamento.ValueMember = "IDDEPARTAMENTO"

                Dim FiltroProvincia As String = ""
                Dim MyParametroP As Integer = cmbDepartamento.SelectedValue
                FiltroProvincia = "IDDEPARTAMENTO = '" & MyParametroP & "'"
                dvProvincia.RowFilter = FiltroProvincia
                cmbProvincia.DataSource = dvProvincia
                cmbProvincia.DisplayMember = "PROVINCIA"
                cmbProvincia.ValueMember = "IDPROVINCIA"

                Dim FiltroDistrito As String = ""
                Dim MyParametroDs As Integer = cmbProvincia.SelectedValue
                FiltroDistrito = "IDPROVINCIA = '" & MyParametroDs & "'"
                dvDistrito.RowFilter = FiltroDistrito
                cmbDistrito.DataSource = dvDistrito
                cmbDistrito.DisplayMember = "DSITRITO"
                cmbDistrito.ValueMember = "IDDISTRITO"

                'cmbPaisDirecciones.SelectedValue = a.PaisSeleccionado
                cmbPaisDirecciones.SelectedValue = a.PaisSeleccionado
            End If
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnDepartamentoDirecciones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDepartamentoDirecciones.Click
        Dim Parametros() As String = {"Mantenimiento de Geográfico", "PKG_IVOPERSONA.SP_GRILLASUBICACION", "PKG_IVOPERSONA.SP_INSUPD_PAIS", "IDPAIS", "PAIS", "IDDEPARTAMENTO", "PAIS", "DEPARTAMENTO", "IDPROVINCIA", "PAIS", "DEPARTAMENTO", "PROVINCIA", "IDDISTRITO", "PAIS", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "ID PAIS", "NOMBRE DEL PAIS", "ID DEPARTAMENTO", "NOMBRE DEPARTAMENTO", "ID PROVINCIA", "NOMBRE PROVINCIA", "ID DISTRITO", "NOMBRE DISTRITO", "2", "MANT. PAISES", "MANT. DEPARTAMENTOS", "MANT. PROVINCIAS", "MANT. DISTRITOS"}

        Dim a As FrmDosCampos = New FrmDosCampos(Parametros)
        'Dim resultado As DialogResult = a.ShowDialog()

        Dim resultado As DialogResult = a.ShowDialog()
        Acceso.Asignar(a, Me.Hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = a.ShowDialog()
            If resultado = Windows.Forms.DialogResult.OK Then
                dtPaisCombo.Clear()
                dtDepartamentoCombo.Clear()
                dtProvinciaCombo.Clear()
                dtDistritoCombo.Clear()

                dtPaisCombo = a.dtPaisFinal.Copy
                dtDepartamentoCombo = a.dtDepartamentoFinal.Copy
                dtProvinciaCombo = a.dtProvinciaFinal.Copy
                dtDistritoCombo = a.dtDistritoFinal.Copy

                dvPais = dtPaisCombo.DefaultView
                dvDepartamento = dtDepartamentoCombo.DefaultView
                dvProvincia = dtProvinciaCombo.DefaultView
                dvDistrito = dtDistritoCombo.DefaultView

                Call CargaCombosDirecciones()

                cmbPais.DataSource = dvPais
                cmbPais.DisplayMember = "PAIS"
                cmbPais.ValueMember = "IDPAIS"

                Dim FiltroDepartamento As String = ""
                Dim MyParametroD As Integer = cmbPais.SelectedValue
                FiltroDepartamento = "IDPAIS = '" & MyParametroD & "'"
                dvDepartamento.RowFilter = FiltroDepartamento
                cmbDepartamento.DataSource = dvDepartamento
                cmbDepartamento.DisplayMember = "DEPARTAMENTO"
                cmbDepartamento.ValueMember = "IDDEPARTAMENTO"

                Dim FiltroProvincia As String = ""
                Dim MyParametroP As Integer = cmbDepartamento.SelectedValue
                FiltroProvincia = "IDDEPARTAMENTO = '" & MyParametroP & "'"
                dvProvincia.RowFilter = FiltroProvincia
                cmbProvincia.DataSource = dvProvincia
                cmbProvincia.DisplayMember = "PROVINCIA"
                cmbProvincia.ValueMember = "IDPROVINCIA"

                Dim FiltroDistrito As String = ""
                Dim MyParametroDs As Integer = cmbProvincia.SelectedValue
                FiltroDistrito = "IDPROVINCIA = '" & MyParametroDs & "'"
                dvDistrito.RowFilter = FiltroDistrito
                cmbDistrito.DataSource = dvDistrito
                cmbDistrito.DisplayMember = "DSITRITO"
                cmbDistrito.ValueMember = "IDDISTRITO"

                cmbPaisDirecciones.SelectedValue = a.PaisSeleccionado
                cmbDepartamentoDirecciones.SelectedValue = a.DepartamentoSeleccionado
            End If
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnProvinciaDirecciones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProvinciaDirecciones.Click
        Dim Parametros() As String = {"Mantenimiento de Geográfico", "PKG_IVOPERSONA.SP_GRILLASUBICACION", "PKG_IVOPERSONA.SP_INSUPD_PAIS", "IDPAIS", "PAIS", "IDDEPARTAMENTO", "PAIS", "DEPARTAMENTO", "IDPROVINCIA", "PAIS", "DEPARTAMENTO", "PROVINCIA", "IDDISTRITO", "PAIS", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "ID PAIS", "NOMBRE DEL PAIS", "ID DEPARTAMENTO", "NOMBRE DEPARTAMENTO", "ID PROVINCIA", "NOMBRE PROVINCIA", "ID DISTRITO", "NOMBRE DISTRITO", "3", "MANT. PAISES", "MANT. DEPARTAMENTOS", "MANT. PROVINCIAS", "MANT. DISTRITOS"}

        Dim a As FrmDosCampos = New FrmDosCampos(Parametros)
        'Dim resultado As DialogResult = a.ShowDialog()

        Dim resultado As DialogResult
        Acceso.Asignar(a, Me.Hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = a.ShowDialog()
            If resultado = Windows.Forms.DialogResult.OK Then
                dtPaisCombo.Clear()
                dtDepartamentoCombo.Clear()
                dtProvinciaCombo.Clear()
                dtDistritoCombo.Clear()

                dtPaisCombo = a.dtPaisFinal.Copy
                dtDepartamentoCombo = a.dtDepartamentoFinal.Copy
                dtProvinciaCombo = a.dtProvinciaFinal.Copy
                dtDistritoCombo = a.dtDistritoFinal.Copy

                dvPais = dtPaisCombo.DefaultView
                dvDepartamento = dtDepartamentoCombo.DefaultView
                dvProvincia = dtProvinciaCombo.DefaultView
                dvDistrito = dtDistritoCombo.DefaultView

                Call CargaCombosDirecciones()

                cmbPais.DataSource = dvPais
                cmbPais.DisplayMember = "PAIS"
                cmbPais.ValueMember = "IDPAIS"

                Dim FiltroDepartamento As String = ""
                Dim MyParametroD As Integer = cmbPais.SelectedValue
                FiltroDepartamento = "IDPAIS = '" & MyParametroD & "'"
                dvDepartamento.RowFilter = FiltroDepartamento
                cmbDepartamento.DataSource = dvDepartamento
                cmbDepartamento.DisplayMember = "DEPARTAMENTO"
                cmbDepartamento.ValueMember = "IDDEPARTAMENTO"

                Dim FiltroProvincia As String = ""
                Dim MyParametroP As Integer = cmbDepartamento.SelectedValue
                FiltroProvincia = "IDDEPARTAMENTO = '" & MyParametroP & "'"
                dvProvincia.RowFilter = FiltroProvincia
                cmbProvincia.DataSource = dvProvincia
                cmbProvincia.DisplayMember = "PROVINCIA"
                cmbProvincia.ValueMember = "IDPROVINCIA"

                Dim FiltroDistrito As String = ""
                Dim MyParametroDs As Integer = cmbProvincia.SelectedValue
                FiltroDistrito = "IDPROVINCIA = '" & MyParametroDs & "'"
                dvDistrito.RowFilter = FiltroDistrito
                cmbDistrito.DataSource = dvDistrito
                cmbDistrito.DisplayMember = "DSITRITO"
                cmbDistrito.ValueMember = "IDDISTRITO"

                cmbPaisDirecciones.SelectedValue = a.PaisSeleccionado
                cmbDepartamentoDirecciones.SelectedValue = a.DepartamentoSeleccionado
                cmbProvinciaDirecciones.SelectedValue = a.ProvinciaSeleccionado
            End If
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnDistritoDirecciones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDistritoDirecciones.Click
        Dim Parametros() As String = {"Mantenimiento de Geográfico", "PKG_IVOPERSONA.SP_GRILLASUBICACION", "PKG_IVOPERSONA.SP_INSUPD_PAIS", "IDPAIS", "PAIS", "IDDEPARTAMENTO", "PAIS", "DEPARTAMENTO", "IDPROVINCIA", "PAIS", "DEPARTAMENTO", "PROVINCIA", "IDDISTRITO", "PAIS", "DEPARTAMENTO", "PROVINCIA", "DSITRITO", "ID PAIS", "NOMBRE DEL PAIS", "ID DEPARTAMENTO", "NOMBRE DEPARTAMENTO", "ID PROVINCIA", "NOMBRE PROVINCIA", "ID DISTRITO", "NOMBRE DISTRITO", "4", "MANT. PAISES", "MANT. DEPARTAMENTOS", "MANT. PROVINCIAS", "MANT. DISTRITOS"}
        Dim a As FrmDosCampos = New FrmDosCampos(Parametros)
        'Dim resultado As DialogResult = a.ShowDialog()

        Dim resultado As DialogResult
        Acceso.Asignar(a, Me.Hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = a.ShowDialog()
            If resultado = Windows.Forms.DialogResult.OK Then
                dtPaisCombo.Clear()
                dtDepartamentoCombo.Clear()
                dtProvinciaCombo.Clear()
                dtDistritoCombo.Clear()

                dtPaisCombo = a.dtPaisFinal.Copy
                dtDepartamentoCombo = a.dtDepartamentoFinal.Copy
                dtProvinciaCombo = a.dtProvinciaFinal.Copy
                dtDistritoCombo = a.dtDistritoFinal.Copy

                dvPais = dtPaisCombo.DefaultView
                dvDepartamento = dtDepartamentoCombo.DefaultView
                dvProvincia = dtProvinciaCombo.DefaultView
                dvDistrito = dtDistritoCombo.DefaultView

                Call CargaCombosDirecciones()

                cmbPais.DataSource = dvPais
                cmbPais.DisplayMember = "PAIS"
                cmbPais.ValueMember = "IDPAIS"

                Dim FiltroDepartamento As String = ""
                Dim MyParametroD As Integer = cmbPais.SelectedValue
                FiltroDepartamento = "IDPAIS = '" & MyParametroD & "'"
                dvDepartamento.RowFilter = FiltroDepartamento
                cmbDepartamento.DataSource = dvDepartamento
                cmbDepartamento.DisplayMember = "DEPARTAMENTO"
                cmbDepartamento.ValueMember = "IDDEPARTAMENTO"

                Dim FiltroProvincia As String = ""
                Dim MyParametroP As Integer = cmbDepartamento.SelectedValue
                FiltroProvincia = "IDDEPARTAMENTO = '" & MyParametroP & "'"
                dvProvincia.RowFilter = FiltroProvincia
                cmbProvincia.DataSource = dvProvincia
                cmbProvincia.DisplayMember = "PROVINCIA"
                cmbProvincia.ValueMember = "IDPROVINCIA"

                Dim FiltroDistrito As String = ""
                Dim MyParametroDs As Integer = cmbProvincia.SelectedValue
                FiltroDistrito = "IDPROVINCIA = '" & MyParametroDs & "'"
                dvDistrito.RowFilter = FiltroDistrito
                cmbDistrito.DataSource = dvDistrito
                cmbDistrito.DisplayMember = "DSITRITO"
                cmbDistrito.ValueMember = "IDDISTRITO"

                cmbPaisDirecciones.SelectedValue = a.PaisSeleccionado
                cmbDepartamentoDirecciones.SelectedValue = a.DepartamentoSeleccionado
                cmbProvinciaDirecciones.SelectedValue = a.ProvinciaSeleccionado
                cmbDistritoDirecciones.SelectedValue = a.DistritoSeleccionado
            End If
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cmbTipoDireccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoDireccion.SelectedIndexChanged
        Try
            If Me.cmbTipoDireccion.SelectedValue = 1 Then
                chkDireccionFacturacion.Enabled = True
                chkDireccionFacturacion.Checked = True
                Me.btnTipoDireccion.Enabled = False
            Else
                chkDireccionFacturacion.Enabled = False
                chkDireccionFacturacion.Checked = False
                Me.btnTipoDireccion.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub chkDireccionFacturacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDireccionFacturacion.CheckedChanged
        If sender.checked = True Then
            'dvTipoDireccion.RowFilter = "TIPO_DIRECCION='LEGAL'"
            Me.btnTipoDireccion.Enabled = False
            Me.chkDireccionFacturacion.Enabled = False
        Else
            'dvTipoDireccion.RowFilter = "TIPO_DIRECCION <>'LEGAL'"
            Me.btnTipoDireccion.Enabled = True
            Me.chkDireccionFacturacion.Enabled = False
        End If
    End Sub

    Private Sub dgvTelefonosContacto_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTelefonosContacto.CellEndEdit
        dgvTelefonosContacto.Rows(e.RowIndex).ErrorText = String.Empty
    End Sub

    Dim EligioTipoComunicacion As Integer

    Private Sub dgvTelefonosContacto_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvTelefonosContacto.CellValidating
        'If dgvTelefonosContacto.Columns(e.ColumnIndex).Name = "NUMERO" Then
        '    If Not Me.dgvTelefonosContacto.Rows(e.RowIndex).Cells("NUMERO").Value Is Nothing Then
        '        MessageBox.Show("Aplica Formato")
        '    Else
        '        MessageBox.Show("Noooooooo Aplica Formato")
        '    End If
        'End If

        'Try
        '    If Not Me.dgvTelefonosContacto.Rows(e.RowIndex).Cells("NUMERO").Value Is Nothing Then
        '        If dgvTelefonosContacto.Columns(e.ColumnIndex).Name = "COMUNICACION" Then
        '            If Not IsDBNull(dgvTelefonosContacto.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
        '                EligioTipoComunicacion = 1
        '            Else
        '                dgvTelefonosContacto.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "Debe de elegir un tipo de Comunicación para asignar un Número."
        '                EligioTipoComunicacion = 0
        '            End If
        '        ElseIf dgvTelefonosContacto.Columns(e.ColumnIndex).Name = "NUMERO" Then
        '            If EligioTipoComunicacion = 1 Then
        '                If IsNumeric((e.FormattedValue.ToString())) Then
        '                    dgvTelefonosContacto.Rows(e.RowIndex).ErrorText = ""
        '                    EligioTipoComunicacion = 0
        '                Else
        '                    dgvTelefonosContacto.Rows(e.RowIndex).ErrorText = "Ingrese Solo Numericos"
        '                    e.Cancel = True
        '                End If
        '            End If
        '            If EligioTipoComunicacion = 0 Then
        '                If e.FormattedValue.ToString().Trim <> "" Then
        '                    If IsNumeric((e.FormattedValue.ToString())) Then
        '                        dgvTelefonosContacto.Rows(e.RowIndex).ErrorText = ""
        '                        EligioTipoComunicacion = 0
        '                    Else
        '                        dgvTelefonosContacto.Rows(e.RowIndex).ErrorText = "Ingrese Solo Numericos"
        '                        e.Cancel = True
        '                    End If
        '                End If
        '            End If
        '        End If

        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub

    Private Sub dgvTelefonosContacto_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTelefonosContacto.CellValueChanged
        'If dgvTelefonosContacto.Columns(e.ColumnIndex).Name = "COMUNICACION" Then
        '    dgvTelefonosContacto.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = ""
        '    'MessageBox.Show("Cambio")
        'End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Try
        '    ''''''''VALIDACIONES''''''''''''
        '    'MessageBox.Show(Me.dgvTelefonosContacto.RowCount)
        '    For i As Integer = 0 To Me.dgvTelefonosContacto.RowCount - 1
        '        'If Not Me.dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value Is Nothing Then
        '        '    MessageBox.Show("Guarda TipoComunicacion")
        '        'End If
        '        'If Not Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value Is Nothing Then
        '        '    MessageBox.Show("Guarda Numero")
        '        'End If
        '        If Not Me.dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value Is Nothing And Not Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value Is Nothing Then
        '            'MessageBox.Show("Guarda TipoComunicacion y Numero")
        '            'MessageBox.Show("*" & Me.dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value.ToString & "*   -   *" & Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value.ToString & "*")
        '            If Me.dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value.ToString.Trim <> "" And Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value.ToString.Trim <> "" Then
        '                'Else
        '                MessageBox.Show(i & "  " & Me.dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value & "   " & Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value)
        '            Else
        '                MessageBox.Show("NOOOOOOOOOOO Guarda TipoComunicacion y Numero")
        '            End If
        '        Else
        '            MessageBox.Show("NOOOOOOOOOOO Guarda TipoComunicacion y Numero")
        '        End If

        '        ''If IsDBNull(Me.dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value) Then
        '        'If Me.dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value.ToString.Trim = "" And Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value.ToString.Trim = "" Then
        '        'Else
        '        '    MessageBox.Show(i & "  " & Me.dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value & "   " & Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value)
        '        'End If
        '    Next
        '    ''''''''''''''''''''''''''''''''
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        ''''''''VALIDACIONES''''''''''''
        For i As Integer = 0 To Me.dgvTelefonosContacto.RowCount - 1
            If Not Me.dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value Is Nothing And Not Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value Is Nothing Then
                If Me.dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value.ToString.Trim <> "" And Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value.ToString.Trim <> "" And IsNumeric(Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value.ToString.Trim) Then
                    MessageBox.Show(i & "  " & Me.dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value & "   " & Me.dgvTelefonosContacto.Rows(i).Cells("NUMERO").Value)
                End If
            End If
        Next
        ''''''''''''''''''''''''''''''''
    End Sub
    Private Sub rdbSexoFemCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbSexoFemCliente.Click
        ' lb_editar = True
    End Sub
    Private Sub rdbSexoMasCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbSexoMasCliente.Click
        'lb_editar = True
    End Sub
    'Private Sub cmbClasPersona_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClasPersona.TextChanged
    '    lb_editar = True
    'End Sub
    'Private Sub chkAgenteRetencion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAgenteRetencion.CheckedChanged
    '    lb_editar = True
    'End Sub
    'Private Sub chkPostFacturacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPostFacturacion.CheckedChanged
    '    lb_editar = True
    'End Sub
    'Private Sub txtNombreP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombreP.TextChanged
    '    lb_editar = True
    'End Sub
    'Private Sub txtRazonSocial_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRazonSocial.TextChanged
    '    lb_editar = True
    'End Sub
    'Private Sub txtApellidoP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApellidoP.TextChanged
    '    lb_editar = True
    'End Sub
    'Private Sub cmbTipoFacturacion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoFacturacion.TextChanged
    '    lb_editar = True
    'End Sub
    'Private Sub cmbRubroEmpresarial_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRubroEmpresarial.TextChanged
    '    lb_editar = True
    'End Sub
    'Private Sub cmbDistrito_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDistrito.TextChanged
    '    lb_editar = True
    'End Sub
    'Private Sub txtCorreoElectronico_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCorreoElectronico.TextChanged
    '    lb_editar = True
    'End Sub
    'Private Sub txtNombreS_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombreS.TextChanged
    '    lb_editar = True
    'End Sub
    'Private Sub txtWebSite_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWebSite.TextChanged
    '    lb_editar = True
    'End Sub
    'Private Sub txtRepLegal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRepLegal.TextChanged
    '    lb_editar = True
    'End Sub
    'Private Sub txtApellidoM_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApellidoM.TextChanged
    '    lb_editar = True
    'End Sub
    'Private Sub cmbTipoDocIdent_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoDocIdent.TextChanged
    '    lb_editar = True
    'End Sub
    'Private Sub txtGG_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGG.TextChanged
    '    lb_editar = True
    'End Sub
    Sub registra_datos_adicionales()
        Try
            Dim MyClassCliente As New dtoCLIENTES
            'Dim rst_dato_adicional As New ADODB.Recordset
            Dim ll_pago_post_fact, ll_agente_retencion As Long
            'Creado por omendoza - 26/06/2007  Actualiza los datos del contado 
            Dim obj As New frm_act_cliente_contado_credito
            'Control de operación             
            obj.pi_control = 0
            '
            obj.txt_codigo_cliente.Text = Me.txtCodigo.Text
            obj.chkContadoCredito.Checked = False
            obj.chkCorporativo.Checked = True
            obj.chkPostFacturacion.Checked = False
            obj.chkAgenteRetencion.Checked = False
            ' Cargando los combobox
            obj.dtTipoFacturacion = Me.dtTipoFacturacion.Copy
            obj.dtRubro = Me.dtRubro.Copy
            obj.dtClasPersona = Me.dtClasPersona.Copy
            obj.dtPaisCombo = dtPaisCombo.Copy
            obj.dtDepartamentoCombo = dtDepartamentoCombo.Copy
            obj.dtProvinciaCombo = dtProvinciaCombo.Copy
            obj.dtDistritoCombo = dtDistritoCombo.Copy
            '
            obj.dvTipoFacturacion = Funciones.CargarCombo(obj.cmbTipoFacturacion, obj.dtTipoFacturacion, "TIPO_FACTURACION", "IDTIPO_FACTURACION", 1)
            obj.dvRubro = Funciones.CargarCombo(obj.cmbRubroEmpresarial, obj.dtRubro, "RUBRO", "IDRUBRO", 2)
            obj.dvClasPersona = Funciones.CargarCombo(obj.cmbClasPersona, obj.dtClasPersona, "CLASIFICACION_PERSONA", "IDCLASIFICACION_PERSONA", 6)
            obj.dvPais = Funciones.CargarCombo(obj.cmbPais, obj.dtPaisCombo, "PAIS", "IDPAIS", 4)
            obj.dvDepartamento = Funciones.CargarCombo(obj.cmbDepartamento, obj.dtDepartamentoCombo, "DEPARTAMENTO", "IDDEPARTAMENTO", 15)
            obj.dvProvincia = Funciones.CargarCombo(obj.cmbProvincia, obj.dtProvinciaCombo, "PROVINCIA", "IDPROVINCIA", 17)
            obj.dvDistrito = Funciones.CargarCombo(obj.cmbdistrito, obj.dtDistritoCombo, "DSITRITO", "IDDISTRITO", 2)
            ' Invocando al Procedimiento 
            MyClassCliente._MyNuDoctoSunat = Me.txtCodigo.Text

            'datahelper
            'rst_dato_adicional = MyClassCliente.fn_getdatos_adicional()

            Dim rst_dato_adicional As DataTable = MyClassCliente.fn_getdatos_adicional()
            ' Recuperando los datos 
            If rst_dato_adicional.Rows.Count >= 1 Then
                'If rst_dato_adicional.Fields.Item("idpersona").Value = -666 Then
                If rst_dato_adicional.Rows(0).Item("idpersona").ToString = -666 Then
                    Exit Sub
                Else
                    obj.txt_idpersona.Text = rst_dato_adicional.Rows(0).Item("idpersona").ToString
                End If
                If IsDBNull(rst_dato_adicional.Rows(0).Item("codigo_cliente").ToString) = True Or (rst_dato_adicional.Rows(0).Item("codigo_cliente").ToString Is Nothing) Then
                    Exit Sub
                Else
                    obj.txt_codigo_cliente.Text = CType(rst_dato_adicional.Rows(0).Item("codigo_cliente").ToString, String)
                End If
                obj.txt_trazon_social.Text = CType(rst_dato_adicional.Rows(0).Item("razon_social").ToString, String)
                If IsDBNull(rst_dato_adicional.Rows(0).Item("gerente_general").ToString) = True Or rst_dato_adicional.Rows(0).Item("gerente_general").ToString Is Nothing Then
                    obj.txt_gerente_general.Text = IIf(Me.txtGG.Text = "", ".", Me.txtGG.Text)
                Else
                    obj.txt_gerente_general.Text = CType(rst_dato_adicional.Rows(0).Item("gerente_general").ToString, String)
                    If obj.txt_gerente_general.Text = "." Then
                        obj.txt_gerente_general.Text = IIf(Me.txtGG.Text = "", ".", Me.txtGG.Text)
                    End If
                End If
                '
                If IsDBNull(rst_dato_adicional.Rows(0).Item("representante_legal").ToString) = True Or rst_dato_adicional.Rows(0).Item("representante_legal").ToString Is Nothing Then
                    obj.txt_representante_legal.Text = IIf(Me.txtRepLegal.Text = "", ".", Me.txtRepLegal.Text)
                Else
                    obj.txt_representante_legal.Text = CType(rst_dato_adicional.Rows(0).Item("representante_legal").ToString, String)
                    If obj.txt_representante_legal.Text = "." Then
                        obj.txt_representante_legal.Text = IIf(Me.txtRepLegal.Text = "", ".", Me.txtRepLegal.Text)
                    End If
                End If
                obj.chkContadoCredito.Checked = False
                ll_pago_post_fact = CType(rst_dato_adicional.Rows(0).Item("pago_post_facturacion").ToString, Long)
                If ll_pago_post_fact = 0 Then
                    obj.chkPostFacturacion.Checked = False
                Else
                    obj.chkPostFacturacion.Checked = True
                End If
                '
                ll_agente_retencion = CType(rst_dato_adicional.Rows(0).Item("agente_retencion").ToString, Long)
                If ll_agente_retencion = 0 Then
                    obj.chkAgenteRetencion.Checked = False
                Else
                    obj.chkAgenteRetencion.Checked = True
                End If
                ' Por defecto debe ser corporativo 
                obj.chkCorporativo.Checked = True
                If IsDBNull(rst_dato_adicional.Rows(0).Item("idrubro").ToString) = True Then
                    obj.cmbRubroEmpresarial.SelectedValue = True
                Else
                    obj.cmbRubroEmpresarial.SelectedValue = CType(rst_dato_adicional.Rows(0).Item("idrubro").ToString, Long)
                End If
                '
                obj.cmbClasPersona.SelectedValue = CType(rst_dato_adicional.Rows(0).Item("idclasificacion_persona").ToString, Long)
                obj.cmbPais.SelectedValue = CType(rst_dato_adicional.Rows(0).Item("idpais").ToString, Long)
                obj.cmbDepartamento.SelectedValue = CType(rst_dato_adicional.Rows(0).Item("iddepartamento").ToString, Long)
                obj.cmbProvincia.SelectedValue = CType(rst_dato_adicional.Rows(0).Item("idprovincia").ToString, Long)
                obj.cmbdistrito.SelectedValue = CType(rst_dato_adicional.Rows(0).Item("iddistrito").ToString, Long)
                obj.cmbTipoFacturacion.SelectedValue = CType(rst_dato_adicional.Rows(0).Item("idtipo_facturacion").ToString, Long)


                'datahelper
                '' Recuperando los datos 
                'If rst_dato_adicional.State = 1 Then
                '    If rst_dato_adicional.Fields.Item("idpersona").Value = -666 Then
                '        Exit Sub
                '    Else
                '        obj.txt_idpersona.Text = rst_dato_adicional.Fields.Item("idpersona").Value
                '    End If
                '    If IsDBNull(rst_dato_adicional.Fields.Item("codigo_cliente")) = True Or (rst_dato_adicional.Fields.Item("codigo_cliente") Is Nothing) Then
                '        Exit Sub
                '    Else
                '        obj.txt_codigo_cliente.Text = CType(rst_dato_adicional.Fields.Item("codigo_cliente").Value, String)
                '    End If
                '    obj.txt_trazon_social.Text = CType(rst_dato_adicional.Fields.Item("razon_social").Value, String)
                '    If IsDBNull(rst_dato_adicional.Fields.Item("gerente_general").Value) = True Or rst_dato_adicional.Fields.Item("gerente_general").Value Is Nothing Then
                '        obj.txt_gerente_general.Text = IIf(Me.txtGG.Text = "", ".", Me.txtGG.Text)
                '    Else
                '        obj.txt_gerente_general.Text = CType(rst_dato_adicional.Fields.Item("gerente_general").Value, String)
                '        If obj.txt_gerente_general.Text = "." Then
                '            obj.txt_gerente_general.Text = IIf(Me.txtGG.Text = "", ".", Me.txtGG.Text)
                '        End If
                '    End If
                '    '
                '    If IsDBNull(rst_dato_adicional.Fields.Item("representante_legal").Value) = True Or rst_dato_adicional.Fields.Item("representante_legal").Value Is Nothing Then
                '        obj.txt_representante_legal.Text = IIf(Me.txtRepLegal.Text = "", ".", Me.txtRepLegal.Text)
                '    Else
                '        obj.txt_representante_legal.Text = CType(rst_dato_adicional.Fields.Item("representante_legal").Value, String)
                '        If obj.txt_representante_legal.Text = "." Then
                '            obj.txt_representante_legal.Text = IIf(Me.txtRepLegal.Text = "", ".", Me.txtRepLegal.Text)
                '        End If
                '    End If
                '    obj.chkContadoCredito.Checked = False
                '    ll_pago_post_fact = CType(rst_dato_adicional.Fields.Item("pago_post_facturacion").Value, Long)
                '    If ll_pago_post_fact = 0 Then
                '        obj.chkPostFacturacion.Checked = False
                '    Else
                '        obj.chkPostFacturacion.Checked = True
                '    End If
                '    '
                '    ll_agente_retencion = CType(rst_dato_adicional.Fields.Item("agente_retencion").Value, Long)
                '    If ll_agente_retencion = 0 Then
                '        obj.chkAgenteRetencion.Checked = False
                '    Else
                '        obj.chkAgenteRetencion.Checked = True
                '    End If
                '    ' Por defecto debe ser corporativo 
                '    obj.chkCorporativo.Checked = True
                '    If IsDBNull(rst_dato_adicional.Fields.Item("idrubro")) = True Then
                '        obj.cmbRubroEmpresarial.SelectedValue = True
                '    Else
                '        obj.cmbRubroEmpresarial.SelectedValue = CType(rst_dato_adicional.Fields.Item("idrubro").Value, Long)
                '    End If
                '    '
                '    obj.cmbClasPersona.SelectedValue = CType(rst_dato_adicional.Fields.Item("idclasificacion_persona").Value, Long)
                '    obj.cmbPais.SelectedValue = CType(rst_dato_adicional.Fields.Item("idpais").Value, Long)
                '    obj.cmbDepartamento.SelectedValue = CType(rst_dato_adicional.Fields.Item("iddepartamento").Value, Long)
                '    obj.cmbProvincia.SelectedValue = CType(rst_dato_adicional.Fields.Item("idprovincia").Value, Long)
                '    obj.cmbdistrito.SelectedValue = CType(rst_dato_adicional.Fields.Item("iddistrito").Value, Long)
                '    obj.cmbTipoFacturacion.SelectedValue = CType(rst_dato_adicional.Fields.Item("idtipo_facturacion").Value, Long)
                '
                'obj.ShowDialog()
                Acceso.Asignar(obj, Me.Hnd)
                If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                    obj.ShowDialog()
                    If obj.pi_control = 1 Then 'Grabo satisfactoriamente 
                        bClienteActualizado = True
                        Me.txtRUC.Text = obj.txt_codigo_cliente.Text
                        Me.chkCorporativo.Checked = obj.chkCorporativo.Checked
                        Me.chkAgenteRetencion.Checked = obj.chkAgenteRetencion.Checked
                        Me.chkContadoCredito.Checked = obj.chkContadoCredito.Checked
                        Me.chkPostFacturacion.Checked = obj.chkPostFacturacion.Checked
                        Me.cmbTipoFacturacion.SelectedValue = obj.cmbTipoFacturacion.SelectedValue
                        Me.cmbRubroEmpresarial.SelectedValue = obj.cmbRubroEmpresarial.SelectedValue
                        Me.cmbClasPersona.SelectedValue = obj.cmbClasPersona.SelectedValue
                        Me.cmbPais.SelectedValue = obj.cmbPais.SelectedValue
                        Me.cmbDepartamento.SelectedValue = obj.cmbDepartamento.SelectedValue
                        Me.cmbProvincia.SelectedValue = obj.cmbProvincia.SelectedValue
                        Me.cmbDistrito.SelectedValue = obj.cmbdistrito.SelectedValue
                        MyClassCliente._MyCodigoCliente = obj.txt_codigo_cliente.Text
                        MyCodigoCliente = obj.txt_codigo_cliente.Text 'MessageBox.Show(MyCodigoCliente)
                        '
                        'Continua con el proceso de creación del cliente 
                        AsignacionFuncionario(obj.txt_codigo_cliente.Text)  'MyCodigoCliente)

                        'If Me.chkContadoCredito.Checked = False Then TEPSA 29/09/2006 
                        If Me.chkContadoCredito.Checked = True Then
                            'AsignacionFuncionario(MyCodigoCliente)
                            'Else
                            Paso1 = 1
                            AccionesJuridica()
                        End If
                    Else
                        b_cancelo = True
                    End If
                Else
                    MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    b_cancelo = True
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvContactosDirecciones_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvContactosDirecciones.CellContentClick

    End Sub

    Private Sub txtNumDoctoContacto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumDoctoContacto.TextChanged

    End Sub

    Private Sub txtApellidoM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtApellidoM.TextChanged

    End Sub

    Private Sub DataGridLista_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridLista.MouseDown
        Dim iCorporativo As Integer
        Dim blnOk As Boolean = False
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                If Me.DataGridLista.RowCount > 0 Then
                    Dim dgvr As DataGridViewRow = Me.DataGridLista.CurrentRow()
                    If Not dgvr Is Nothing Then
                        sCliente = CType(dgvr.Cells("RAZONSOCIAL").Value, String)
                        sDocumento = CType(dgvr.Cells("DOCUMENTO").Value, String)
                        iId = CType(dgvr.Cells("ID").Value, Integer)
                        iCorporativo = CType(dgvr.Cells("CLIENTE_CORPORATIVO").Value, Integer)
                        bMontoBase = CType(dgvr.Cells("MONTO_BASE").Value, Boolean)
                        iDescuento = CType(dgvr.Cells("DESCUENTO").Value, Double)

                        'Dim rstRol As DataTable = sp_existe_rol()
                        'If rstRol.Rows(0).Item(0).ToString = 38 Or MyRol = 11 Then
                        'bloque
                        If Acceso.SiRol(G_Rol, Me, 5) Then
                            Dim rst As DataTable
                            rst = sp_linea_credito()

                            If rst.Rows.Count > 0 Then

                                blnOk = False
                                For index As Integer = 0 To rst.Rows.Count - 1
                                    If Convert.ToInt32(rst.Rows(index).Item("ES_ACTIVO").ToString) = 1 Then
                                        blnOk = True
                                        Exit For
                                    End If
                                Next

                                ContextMenuStrip.Items(0).Visible = True
                                If blnOk = True Then
                                    sAccion = "D"
                                    ContextMenuStrip.Items(0).Text = "Desactivar Línea de Crédito"
                                Else
                                    sAccion = "A"
                                    ContextMenuStrip.Items(0).Text = "Activar Línea de Crédito"
                                End If
                            Else
                                ContextMenuStrip.Items(0).Visible = False
                            End If
                        Else
                            ContextMenuStrip.Items(0).Visible = False
                        End If

                        'If rstRol.Rows(0).Item(0).ToString = 38 Then
                        'bloque
                        If Acceso.SiRol(G_Rol, Me, 6) Then
                            ContextMenuStrip.Items(1).Visible = True
                            ContextMenuStrip.Items(2).Visible = True
                        Else
                            ContextMenuStrip.Items(1).Visible = False
                            ContextMenuStrip.Items(2).Visible = False
                        End If
                        ContextMenuStrip.Show(sender, e.X, e.Y)

                        'datahelper
                        'rstRol = New ADODB.Recordset
                        'rstRol = sp_existe_rol()

                        'If rstRol(0).Value = 38 Or MyRol = 11 Then
                        '    Dim rst As ADODB.Recordset
                        '    rst = sp_linea_credito()
                        '    If Not rst.BOF And Not rst.EOF Then
                        '        ContextMenuStrip.Items(0).Visible = True
                        '        If CType(rst("ES_ACTIVO").Value, Boolean) Then
                        '            sAccion = "D"
                        '            ContextMenuStrip.Items(0).Text = "Desactivar Línea de Crédito"
                        '        Else
                        '            sAccion = "A"
                        '            ContextMenuStrip.Items(0).Text = "Activar Línea de Crédito"
                        '        End If
                        '    Else
                        '        ContextMenuStrip.Items(0).Visible = False
                        '    End If
                        'Else
                        '    ContextMenuStrip.Items(0).Visible = False
                        'End If

                        'If rstRol(0).Value = 38 Then
                        '    ContextMenuStrip.Items(1).Visible = True
                        '    ContextMenuStrip.Items(2).Visible = True
                        'Else
                        '    ContextMenuStrip.Items(1).Visible = False
                        '    ContextMenuStrip.Items(2).Visible = False
                        'End If
                        'ContextMenuStrip.Show(sender, e.X, e.Y)
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try

    End Sub

    Private Sub uno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uno.Click
        Dim frm As New FrmLineaCredito
        Dim objcliente As New dtoCLIENTES
        Dim dt As DataTable

        dt = objcliente.VerificaSolicitud(iId)

        If sAccion = "A" Then
            If dt.Rows.Count = 1 Then
                If Convert.ToInt32(dt.Rows(0).Item("Activo").ToString) = 1 Then
                    If Convert.ToInt32(dt.Rows(0).Item("Estado1").ToString) = 1 Or Convert.ToInt32(dt.Rows(0).Item("Estado1").ToString) = 2 Then
                        MessageBox.Show("Existe una solicitud de crédito por el monto de " & dt.Rows(0).Item("Monto_Solicitado").ToString & " en estado " & dt.Rows(0).Item("Estado").ToString & ", debe de continuar con el proceso normal de aprobación de línea de crédito", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Return
                    ElseIf Convert.ToInt32(dt.Rows(0).Item("Estado1").ToString) = 3 Then
                        frm.iSolicitud = Convert.ToInt32(dt.Rows(0).Item("IdSolicitud_Credito").ToString)
                    Else
                        frm.iSolicitud = 0
                    End If
                End If
            Else
                frm.iSolicitud = 0
            End If
        ElseIf sAccion = "D" Then
            If Convert.ToInt32(dt.Rows(0).Item("Estado1").ToString) = 3 Then
                frm.iSolicitud = Convert.ToInt32(dt.Rows(0).Item("IdSolicitud_Credito").ToString)
            Else
                MessageBox.Show("No existe solicitud de crédito asociada a una línea de crédito", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
        Else
            frm.iSolicitud = 0
        End If

        frm.sDocumento = sDocumento
        frm.sCliente = sCliente
        frm.iId = iId
        frm.sAccion = sAccion
        frm.rsTipoFacturacion = Me.dtTipoFacturacion.Copy

        Acceso.Asignar(frm, Me.Hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            frm.ShowDialog()
            If bActualizado Then

                If Acceso.SiRol(G_Rol, Me, 7) Then
                    btnCargarClientes_Click(sender, e)
                Else
                    Me.DataGridLista.Columns.Clear()
                    dvListaPersona = CargarGrillaClientes_x_funcionario(MyUsuario, Me.DataGridLista)
                End If
                bActualizado = False
            End If
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    'Public Function sp_linea_credito2009_eliminarlo() As ADODB.Recordset
    '    Try
    '        Dim Obj As Object() = {"sp_linea_credito", 4, iId, 2}
    '        Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
    '        Return Nothing
    '    End Try
    'End Function
    'Public Function sp_existe_rol2009_eliminarlo() As ADODB.Recordset
    '    Try
    '        Dim Obj As Object() = {"sp_existe_rol", 6, MyUsuario, 1, 38, 1}
    '        Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
    '        Return Nothing
    '    End Try
    'End Function
    Private Sub tres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tres.Click
        Dim frm As New FrmBase
        '
        frm.sDocumento = sDocumento
        frm.sCliente = sCliente
        frm.iId = iId
        frm.bMontoBase = bMontoBase
        'frm.ShowDialog()
        Acceso.Asignar(frm, Me.Hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            frm.ShowDialog()
            If bActualizado Then
                'If MyRol = 32 Then
                'bloque
                If Acceso.SiRol(G_Rol, Me, 8) Then
                    btnCargarClientes_Click(sender, e)
                Else
                    'Call Funciones.LlenaTreeFuncionarios(MyTreeView)
                    Me.DataGridLista.Columns.Clear()
                    dvListaPersona = CargarGrillaClientes_x_funcionario(MyUsuario, Me.DataGridLista)
                End If
                bActualizado = False
            End If
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub dos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dos.Click
        Dim frm As New frmDescuento
        '
        frm.sDocumento = sDocumento
        frm.sCliente = sCliente
        frm.iId = iId
        frm.iDescuento = iDescuento
        'frm.ShowDialog()
        Acceso.Asignar(frm, Me.Hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            frm.ShowDialog()
            If bActualizado Then
                'If MyRol = 32 Then
                'bloque
                If Acceso.SiRol(G_Rol, Me, 9) Then
                    btnCargarClientes_Click(sender, e)
                Else
                    'Call Funciones.LlenaTreeFuncionarios(MyTreeView)
                    Me.DataGridLista.Columns.Clear()
                    dvListaPersona = CargarGrillaClientes_x_funcionario(MyUsuario, Me.DataGridLista)
                End If
                bActualizado = False
            End If
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub cuatro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cuatro.Click
        Try 'Creado 23/07/2009 - Para configurar detalles propio del cliente 
            Dim lfrm_config_clte As New Frm_configura_cliente
            '
            lfrm_config_clte.txt_razon_social.Text = sCliente
            lfrm_config_clte.txt_dcto_identidad_cliente.Text = sDocumento
            lfrm_config_clte.pl_idusuario_personal = CType(iId, Long)
            'lfrm_config_clte.ShowDialog()
            Acceso.Asignar(lfrm_config_clte, Me.Hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                lfrm_config_clte.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub cmbLinea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLinea.SelectedIndexChanged
        Dim FiltroLista As String

        iLinea = cmbLinea.SelectedIndex
        iLinea = LineaCredito(iLinea)

        If DataGridLista.Columns.Count > 0 Then
            If iLinea <> 9 Then
                FiltroLista = ""
                If rdbJuridicos.Checked Then
                    FiltroLista = "IDTIPO_PERSONA ='" & 1 & "'"
                ElseIf rdbnaturales.Checked Then
                    FiltroLista = "IDTIPO_PERSONA ='" & 2 & "'"
                End If

                If FiltroLista = "" Then
                    FiltroLista = FiltroLista & " linea=" & iLinea & " "
                Else
                    FiltroLista = FiltroLista & " and linea=" & iLinea & " "
                End If
                dvListaPersona.RowFilter = FiltroLista
            Else
                FiltroLista = dvListaPersona.RowFilter
                Dim iPos As Integer = InStr(FiltroLista, "and")
                If iPos > 0 Then
                    FiltroLista = FiltroLista.Substring(0, iPos - 1).Trim
                    dvListaPersona.RowFilter = FiltroLista
                End If
            End If
        End If
    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        Try
            iLinea = cmbLinea.SelectedIndex
            iLinea = LineaCredito(iLinea)

            If rdbJuridicos.Checked = True Then
                Dim FiltroLista As String
                FiltroLista = "IDTIPO_PERSONA = 1 and RAZON_SOCIAL LIKE '%" & Me.txtBusqueda.Text & "%' "
                If iLinea <> 9 Then
                    FiltroLista = FiltroLista & " and linea=" & iLinea & " "
                End If
                dvListaPersona.RowFilter = FiltroLista
            End If
            If rdbnaturales.Checked = True Then
                Dim FiltroLista As String
                FiltroLista = "IDTIPO_PERSONA = 2 and NOMNRES_APELLIDOS LIKE '%" & Me.txtBusqueda.Text & "%'"
                If iLinea <> 9 Then
                    FiltroLista = FiltroLista & " and linea=" & iLinea & " "
                End If

                dvListaPersona.RowFilter = FiltroLista
            End If
            If rdbTodos.Checked = True Then
                'Dim FiltroLista As String = "(IDTIPO_PERSONA = 1 or IDTIPO_PERSONA = 2) and (RAZON_SOCIAL LIKE '%" & Me.txtBusqueda.Text & "%')"
                Dim FiltroLista As String
                FiltroLista = "RAZON_SOCIAL LIKE '%" & Me.txtBusqueda.Text & "%'"
                If iLinea <> 9 Then
                    FiltroLista = FiltroLista & " and linea=" & iLinea & " "
                End If
                dvListaPersona.RowFilter = FiltroLista
            End If
        Catch ex As Exception
            MessageBox.Show("")
        End Try
    End Sub

    Private Function LineaCredito(ByVal i As Integer) As Integer
        Select Case i
            Case 0
                LineaCredito = 9
            Case 1
                LineaCredito = 1
            Case 2
                LineaCredito = 0
            Case 3
                LineaCredito = -1
        End Select
    End Function

    Private Sub FrmClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbLinea.SelectedIndex = 0
        bClienteActualizado = False

        Paso1 = 0
        Paso2 = 0
        Paso3 = 0
        ' Tepsa 
        MyUsuario = dtoUSUARIOS.IdLogin
        MyRol = dtoUSUARIOS.IdRol
        MyIP = dtoUSUARIOS.IP          '"192.168.50.47"
        '
        Dim MyGroupsParam() As Object = {Me.GroupBox1, Me.GroupBox2, Me.GroupBox3, Me.GroupBox4, Me.GroupBox5, Me.GroupBox6, Me.GroupBoxConsideraciones, Me.GroupBoxDatosPersonales, Me.GroupBoxUbicacion}
        Call Funciones.TamanoGroupBox(MyGroupsParam)
        TimerCodigo.Start()
        ShadowLabel1.Text = "Mantenimiento de Clientes"
        MenuTab.Items(0).Text = "LISTA CLIENTES"
        MenuTab.Items(1).Text = "MANTENIMIENTO"
        MenuTab.Items(2).Text = "CONTACTOS"
        MenuTab.Items(3).Text = "DIRECCIONES"
        MenuTab.Items(4).Text = "SOLICITUD DE CREDITO"
        HabilitarMenu(MenuTab)
        MenuTab.Items(0).Enabled = True
        MenuTab.Items(1).Enabled = False
        MenuTab.Items(2).Enabled = False
        MenuTab.Items(3).Enabled = False
        MenuTab.Items(4).Enabled = False

        CodFuncionarioNegocio = 0 'Porque la casilla esta en blanco

        txtFechaRegistro._MyFecha = Format(Today(), "dd/MM/yyyy")
        txtFechaNacimiento._MyFecha = ""

        txtCodigo.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
        txtCodigoUbigeo.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
        txtCodigoClienteContacto.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
        txtNombreClienteContacto.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
        txtCodigoClienteDirecciones.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
        txtDireccionesCliente.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
        txtCodigoClienteDirecciones.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
        txtDescuento.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
        txtLinea.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
        TxtTotalAsignado.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")
        TxtSobregiro.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE2")


        'Inicializamos la variable que maneja  si es Insercion o Actualizacion.
        vAccionRegistro = 0
        vIDPersona = 0
        'Esta variable contiene el IDPersona para guardar es 0 y para actualizacions 
        'se le asigna el valor que contiene la grilla Inicial.

        Try

            'Llenar los RecordSets
            'Para la recuperacion total de data (Ojo que rstTipoPersona, posee
            'el primer cursor de los argumentos del SP)...

            'datahelper
            'Dim Myobj As Object() = {"PKG_IVOPERSONA.SP_COMBOSPERSONA", 0}
            'rstTipoPersona = VOCONTROLUSUARIO.fnSQLQuery(Myobj)
            'rstTipoDocto = rstTipoPersona.NextRecordset
            'rstRubro = rstTipoPersona.NextRecordset
            'rstClasPersona = rstTipoPersona.NextRecordset
            'rstPaisCombo = rstTipoPersona.NextRecordset
            'rstDepartamentoCombo = rstTipoPersona.NextRecordset
            'rstProvinciaCombo = rstTipoPersona.NextRecordset
            'rstDistritoCombo = rstTipoPersona.NextRecordset
            'rstTipoContactoCombo = rstTipoPersona.NextRecordset
            'rstAreaEmpresaCombo = rstTipoPersona.NextRecordset
            'rstTipoComunicacion = rstTipoPersona.NextRecordset
            'rstComunicacionContac = rstTipoPersona.NextRecordset
            'rstRoles = rstTipoPersona.NextRecordset
            'rstUsuarioRoles = rstTipoPersona.NextRecordset
            'rstListaPersona = rstTipoPersona.NextRecordset
            'rstIDPersona = rstTipoPersona.NextRecordset
            'rstTipoDireccion = rstTipoPersona.NextRecordset

            ''Llenar Datatables con los Recordsets
            'DataAdapterGenerics.Fill(dtTipoPersona, rstTipoPersona)
            'DataAdapterGenerics.Fill(dtTipoDocPersona, rstTipoDocto)
            'rstTipoDocto.MoveFirst()
            'DataAdapterGenerics.Fill(dtTipoDocPersona2, rstTipoDocto)
            'DataAdapterGenerics.Fill(dtRubro, rstRubro)
            'DataAdapterGenerics.Fill(dtClasPersona, rstClasPersona)
            'DataAdapterGenerics.Fill(dtPaisCombo, rstPaisCombo)
            'DataAdapterGenerics.Fill(dtDepartamentoCombo, rstDepartamentoCombo)
            'DataAdapterGenerics.Fill(dtProvinciaCombo, rstProvinciaCombo)
            'DataAdapterGenerics.Fill(dtDistritoCombo, rstDistritoCombo)
            'DataAdapterGenerics.Fill(dtTipoContacto, rstTipoContactoCombo)
            'DataAdapterGenerics.Fill(dtAreaEmpresa, rstAreaEmpresaCombo)
            'DataAdapterGenerics.Fill(dtTipoComunicacion, rstTipoComunicacion)
            'DataAdapterGenerics.Fill(dtTipoFacturacion, rstComunicacionContac)
            'DataAdapterGenerics.Fill(dtRoles, rstRoles)
            'DataAdapterGenerics.Fill(dtUsuarioRoles, rstUsuarioRoles)
            'DataAdapterGenerics.Fill(dtListaPersona, rstListaPersona)
            'DataAdapterGenerics.Fill(dtTipoDireccion, rstTipoDireccion)

            'Dim Myobj As Object() = {"PKG_IVOPERSONA.SP_COMBOSPERSONA", 0}
            'rstTipoPersona = VOCONTROLUSUARIO.fnSQLQuery(Myobj)

            Dim objcliente As New dtoCLIENTES
            Dim ds As DataSet = objcliente.fn_COMBOSPERSONA

            'datahelper
            'rstTipoDocto = rstTipoPersona.NextRecordset
            'rstRubro = rstTipoPersona.NextRecordset
            'rstClasPersona = rstTipoPersona.NextRecordset
            'rstPaisCombo = rstTipoPersona.NextRecordset
            'rstDepartamentoCombo = rstTipoPersona.NextRecordset
            'rstProvinciaCombo = rstTipoPersona.NextRecordset
            'rstDistritoCombo = rstTipoPersona.NextRecordset
            'rstTipoContactoCombo = rstTipoPersona.NextRecordset
            'rstAreaEmpresaCombo = rstTipoPersona.NextRecordset
            'rstTipoComunicacion = rstTipoPersona.NextRecordset
            'rstComunicacionContac = rstTipoPersona.NextRecordset
            'rstRoles = rstTipoPersona.NextRecordset
            'rstUsuarioRoles = rstTipoPersona.NextRecordset
            'rstListaPersona = rstTipoPersona.NextRecordset
            'rstIDPersona = rstTipoPersona.NextRecordset
            'rstTipoDireccion = rstTipoPersona.NextRecordset

            'Llenar Datatables con los Recordsets
            'DataAdapterGenerics.Fill(dtTipoPersona, rstTipoPersona)
            'DataAdapterGenerics.Fill(dtTipoDocPersona, rstTipoDocto)
            'rstTipoDocto.MoveFirst()
            'DataAdapterGenerics.Fill(dtTipoDocPersona2, rstTipoDocto)
            'DataAdapterGenerics.Fill(dtRubro, rstRubro)
            'DataAdapterGenerics.Fill(dtClasPersona, rstClasPersona)
            'DataAdapterGenerics.Fill(dtPaisCombo, rstPaisCombo)
            'DataAdapterGenerics.Fill(dtDepartamentoCombo, rstDepartamentoCombo)
            'DataAdapterGenerics.Fill(dtProvinciaCombo, rstProvinciaCombo)
            'DataAdapterGenerics.Fill(dtDistritoCombo, rstDistritoCombo)
            'DataAdapterGenerics.Fill(dtTipoContacto, rstTipoContactoCombo)
            'DataAdapterGenerics.Fill(dtAreaEmpresa, rstAreaEmpresaCombo)
            'DataAdapterGenerics.Fill(dtTipoComunicacion, rstTipoComunicacion)
            'DataAdapterGenerics.Fill(dtTipoFacturacion, rstComunicacionContac)
            'DataAdapterGenerics.Fill(dtRoles, rstRoles)
            'DataAdapterGenerics.Fill(dtUsuarioRoles, rstUsuarioRoles)
            'DataAdapterGenerics.Fill(dtListaPersona, rstListaPersona)
            'DataAdapterGenerics.Fill(dtTipoDireccion, rstTipoDireccion)
            dtTipoPersona = ds.Tables(0)
            dtTipoDocPersona = ds.Tables(1)
            dtTipoDocPersona2 = ds.Tables(1)
            dtRubro = ds.Tables(2)
            dtClasPersona = ds.Tables(3)
            dtPaisCombo = ds.Tables(4)
            dtDepartamentoCombo = ds.Tables(5)
            dtProvinciaCombo = ds.Tables(6)
            dtDistritoCombo = ds.Tables(7)
            dtTipoContacto = ds.Tables(8)
            dtAreaEmpresa = ds.Tables(9)
            dtTipoComunicacion = ds.Tables(10)
            dtTipoFacturacion = ds.Tables(11)
            dtRoles = ds.Tables(12)
            dtUsuarioRoles = ds.Tables(13)
            dtListaPersona = ds.Tables(14)
            dtTipoDireccion = ds.Tables(16)

            If Acceso.SiRol(G_Rol, Me, 10) Then
                'If MyRol = 32 Then '(32) Supervisor de funcionario de negocios 
                Call Funciones.LlenaTreeFuncionarios(MyTreeView)
                Me.btnCargarClientes.Enabled = True
            Else
                ' Modificado el dia 25/06/2007 - Omendoza, se puso 
                Call Funciones.LlenaTreeSoloFuncionarios(MyUsuario, MyTreeView)
                dvListaPersona = CargarGrillaClientes_x_funcionario(MyUsuario, Me.DataGridLista)
                DataGridLista.Columns(4).Visible = True
                DataGridLista.Columns(5).Visible = False
                DataGridLista.Columns(40).Visible = False
                Me.btnCargarClientes.Enabled = False
                'Me.MyTreeView.ImageIndex = 1
                Me.MyTreeView.ExpandAll()
            End If

            dvTipoPersona = Funciones.CargarCombo(cmbTipoPersona, dtTipoPersona, "TIPO_PERSONA", "IDTIPO_PERSONA", 2)
            dvTipoDocPersona = Funciones.CargarCombo(cmbTipoDocIdent, dtTipoDocPersona, "TIPO_DOC_IDENTIDAD", "IDTIPO_DOC_IDENTIDAD", 1)
            dvRubro = Funciones.CargarCombo(cmbRubroEmpresarial, dtRubro, "RUBRO", "IDRUBRO", 2)
            dvClasPersona = Funciones.CargarCombo(cmbClasPersona, dtClasPersona, "CLASIFICACION_PERSONA", "IDCLASIFICACION_PERSONA", 6)
            dvTipoContacto = Funciones.CargarCombo(cmbTipoContacto, dtTipoContacto, "TIPO_CONTACTO", "IDTIPO_CONTACTO", 2)
            dvTipoDocPersona2 = Funciones.CargarCombo(cmbTipoDoctoContacto, dtTipoDocPersona2, "TIPO_DOC_IDENTIDAD", "IDTIPO_DOC_IDENTIDAD", 1)
            dvAreaEmpresa = Funciones.CargarCombo(cmbAreaEmpresa, dtAreaEmpresa, "CENTRO_COSTO", "IDCENTRO_COSTO", 2)
            dvTipoFacturacion = Funciones.CargarCombo(cmbTipoFacturacion, dtTipoFacturacion, "TIPO_FACTURACION", "IDTIPO_FACTURACION", 1)


            'Llenando los Combos a treves de DataViews
            dvPais = dtPaisCombo.DefaultView
            dvDepartamento = dtDepartamentoCombo.DefaultView
            dvProvincia = dtProvinciaCombo.DefaultView
            dvDistrito = dtDistritoCombo.DefaultView

            dvTipoDireccion = Funciones.CargarCombo(cmbTipoDireccion, dtTipoDireccion, "TIPO_DIRECCION", "IDTIPO_DIRECCION", 2)

            cmbPais.DataSource = dvPais
            cmbPais.DisplayMember = "PAIS"
            cmbPais.ValueMember = "IDPAIS"

            Dim FiltroDepartamento As String = ""
            Dim MyParametroD As Integer = cmbPais.SelectedValue
            FiltroDepartamento = "IDPAIS = '" & MyParametroD & "'"
            dvDepartamento.RowFilter = FiltroDepartamento
            cmbDepartamento.DataSource = dvDepartamento
            cmbDepartamento.DisplayMember = "DEPARTAMENTO"
            cmbDepartamento.ValueMember = "IDDEPARTAMENTO"

            Dim FiltroProvincia As String = ""
            Dim MyParametroP As Integer = cmbDepartamento.SelectedValue
            FiltroProvincia = "IDDEPARTAMENTO = '" & MyParametroP & "'"
            dvProvincia.RowFilter = FiltroProvincia
            cmbProvincia.DataSource = dvProvincia
            cmbProvincia.DisplayMember = "PROVINCIA"
            cmbProvincia.ValueMember = "IDPROVINCIA"

            Dim FiltroDistrito As String = ""
            Dim MyParametroDs As Integer = cmbProvincia.SelectedValue
            FiltroDistrito = "IDPROVINCIA = '" & MyParametroDs & "'"
            dvDistrito.RowFilter = FiltroDistrito
            cmbDistrito.DataSource = dvDistrito
            cmbDistrito.DisplayMember = "DSITRITO"
            cmbDistrito.ValueMember = "IDDISTRITO"

            cmbPais.SelectedValue = 4
            cmbDepartamento.SelectedValue = 15
            cmbProvincia.SelectedValue = 17
            cmbDistrito.SelectedValue = 2


            rdbJuridicos.Checked = True 'Para la Grilla Inicial.

            Call CargaCombosDirecciones()

            Me.btnAgregar.Enabled = True
            Me.btnActualizar.Enabled = False

            Me.btnAgregarDireccion.Enabled = True
            Me.btnActualizarDireccion.Enabled = False

            FormatoDgvSolicitud()
            CargarCondicionPago(Me.CboCondicion)
            ActiVarDesactivar(False)

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub GeneraDetalleTelefonos(ByVal MyGrillaTelefonos As DataGridView)
        'Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_GRILLA_TELEFONOS", 0}
        Try
            'Dim rstGrillaTelefonos As ADODB.Recordset = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
            'Dim rstComboGrilla As ADODB.Recordset = rstGrillaTelefonos.NextRecordset
            'Dim daTelefonos As New OleDbDataAdapter

            dtGrillaTelefonos.Clear()
            dtComboGrilla.Clear()
            'daTelefonos.Fill(dtGrillaTelefonos, rstGrillaTelefonos)
            'daTelefonos.Fill(dtComboGrilla, rstComboGrilla)

            Dim objcliente As New dtoCLIENTES
            Dim ds As DataSet = objcliente.fn_GRILLA_TELEFONOS
            dtGrillaTelefonos = ds.Tables(0)
            dtComboGrilla = ds.Tables(1)

            Dim dvGrillaTelefonos As DataView = dtGrillaTelefonos.DefaultView
            Dim dvComboGrilla As DataView = dtComboGrilla.DefaultView

            MyGrillaTelefonos.Columns.Clear()
            With MyGrillaTelefonos
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = True
                .AllowUserToAddRows = True
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .AutoGenerateColumns = False
                .DataSource = dtGrillaTelefonos.DefaultView
                .Font = New System.Drawing.Font("Arial", 8.0!, FontStyle.Regular)
                .RowHeadersVisible = True
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            Dim ColTipoComunicacion As New DataGridViewComboBoxColumn
            With ColTipoComunicacion
                .Name = "COMUNICACION"
                .DataPropertyName = "COMUNICACION"
                .HeaderText = "COMUNICACION"
                .DataSource = dvComboGrilla
                .DisplayMember = "COMUNICACION"
                .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                .Width = 130
            End With
            MyGrillaTelefonos.Columns.Add(ColTipoComunicacion)

            Dim ColNumero As New DataGridViewTextBoxColumn
            With ColNumero
                .Name = "NUMERO"
                .DataPropertyName = "NROCOMUNICACION_CONTACTO"
                .HeaderText = "NUMERO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            MyGrillaTelefonos.Columns.Add(ColNumero)

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CargarListaContactos()
        'Dim rstContactos As ADODB.Recordset
        'Dim daContactos As New OleDbDataAdapter
        Dim scodigo_cliente As String
        If MyCodigoCliente = Nothing Or IsDBNull(MyCodigoCliente) = True Or MyCodigoCliente = "" Then
            scodigo_cliente = "null"
        Else
            scodigo_cliente = MyCodigoCliente
        End If
        'Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTACONTACTO", 4, scodigo_cliente, 2}
        Try
            dtContactos.Clear()
            'rstContactos = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
            'daContactos.Fill(dtContactos, rstContactos)
            dgvContactos.Columns.Clear()
            Dim objcliente As New dtoCLIENTES
            dtContactos = objcliente.fn_LISTACONTACTO(scodigo_cliente)

            With dgvContactos
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = True
                .AllowUserToAddRows = True
                .AutoGenerateColumns = False
                .DataSource = dtContactos.DefaultView
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .Font = New System.Drawing.Font("Arial", 8.0!, FontStyle.Regular)
                .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                .VirtualMode = True
                .RowHeadersVisible = False
                .ReadOnly = True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End With
            Dim col1 As New DataGridViewTextBoxColumn
            With col1
                .Name = "ORDEN"
                .DataPropertyName = "ORDEN"
                .HeaderText = "ORDEN"
                .Width = 45
            End With
            Dim col2 As New DataGridViewTextBoxColumn
            With col2
                .Name = "TIPO_CONTACTO"
                .DataPropertyName = "TIPO_CONTACTO"
                .HeaderText = "TIPO CONTACTO"
                .Width = 120
            End With
            Dim col3 As New DataGridViewTextBoxColumn
            With col3
                .Name = "TIPO_DOC_IDENTIDAD"
                .DataPropertyName = "TIPO_DOC_IDENTIDAD"
                .HeaderText = "TIPO DOCTO"
                .Width = 93
            End With
            Dim col4 As New DataGridViewTextBoxColumn
            With col4
                .Name = "NRODOCUMENTO"
                .DataPropertyName = "NRODOCUMENTO"
                .HeaderText = "DOCUMENTO"
                .Width = 80
            End With
            Dim col5 As New DataGridViewTextBoxColumn
            With col5
                .Name = "NOMBRE_APELLIDOS"
                .DataPropertyName = "NOMBRE_APELLIDOS"
                .HeaderText = "NOMBRES Y APELLIDOS"
                .Width = 220
            End With
            Dim col6 As New DataGridViewCheckBoxColumn
            With col6
                .Name = "ESTADO_REGISTRO"
                .DataPropertyName = "ESTADO_REGISTRO"
                .HeaderText = "¿ACTIVO?"
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .Width = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .ReadOnly = True
            End With
            Dim col7 As New DataGridViewTextBoxColumn
            With col7
                .Name = "IDCONTACTO_PERSONA"
                .DataPropertyName = "IDCONTACTO_PERSONA"
                .HeaderText = "IDCONTACTO PERSONA"
            End With
            Dim col8 As New DataGridViewTextBoxColumn
            With col8
                .Name = "IDTIPO_CONTACTO"
                .DataPropertyName = "IDTIPO_CONTACTO"
                .HeaderText = "IDTIPO CONTACTO"
            End With
            Dim col9 As New DataGridViewTextBoxColumn
            With col9
                .Name = "IDPERSONA"
                .DataPropertyName = "IDPERSONA"
                .HeaderText = "IDPERSONA"
            End With
            Dim col10 As New DataGridViewTextBoxColumn
            With col10
                .Name = "NOMBRES"
                .DataPropertyName = "NOMBRES"
                .HeaderText = "NOMBRES"
            End With
            Dim col11 As New DataGridViewTextBoxColumn
            With col11
                .Name = "APEPAT"
                .DataPropertyName = "APEPAT"
                .HeaderText = "APEPAT"
            End With
            Dim col12 As New DataGridViewTextBoxColumn
            With col12
                .Name = "APEMAT"
                .DataPropertyName = "APEMAT"
                .HeaderText = "APEMAT"
            End With
            Dim col13 As New DataGridViewTextBoxColumn
            With col13
                .Name = "IDTIPO_DOCUMENTO_CONTACTO"
                .DataPropertyName = "IDTIPO_DOCUMENTO_CONTACTO"
                .HeaderText = "IDTIPO_DOCUMENTO_CONTACTO"
            End With
            Dim col14 As New DataGridViewTextBoxColumn
            With col14
                .Name = "EMAIL_CONTACTO"
                .DataPropertyName = "EMAIL_CONTACTO"
                .HeaderText = "EMAIL_CONTACTO"
            End With
            Dim col15 As New DataGridViewTextBoxColumn
            With col15
                .Name = "SEXO"
                .DataPropertyName = "SEXO"
                .HeaderText = "SEXO"
            End With
            Dim col16 As New DataGridViewTextBoxColumn
            With col16
                .Name = "CENTRO_COSTO"
                .DataPropertyName = "CENTRO_COSTO"
                .HeaderText = "CENTRO_COSTO"
            End With

            dgvContactos.Columns.AddRange(col1, col2, col3, col4, col5, col6, col7, col8, _
                                          col9, col10, col11, col12, col13, col14, col15, col16)
            For j As Integer = 6 To 14
                dgvContactos.Columns(j).Visible = False
            Next

            vActualizaContacto = 0

            If dgvContactos.RowCount = 0 Then
                dgvContactos.Visible = True
                Call GeneraDetalleContactos()
                vActualizaContacto = 1
            End If

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarListaTelefonos(ByVal IDContacto As Integer, ByVal MyGrillaConData As DataGridView)
        'Dim rstTipoComunicacion As ADODB.Recordset
        'Dim rstTelefonos As ADODB.Recordset
        'Dim daTelefonos As New OleDbDataAdapter
        Dim dtTipoComunicacion As New DataTable
        Dim dtTelefonos As New DataTable
        'Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTATELEFONOCONTACTO", 4, IDContacto.ToString, 2}
        Try
            'rstTipoComunicacion = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
            'rstTelefonos = rstTipoComunicacion.NextRecordset
            'daTelefonos.Fill(dtTipoComunicacion, rstTipoComunicacion)
            'daTelefonos.Fill(dtTelefonos, rstTelefonos)

            Dim objcliente As New dtoCLIENTES
            Dim ds As DataSet = objcliente.fn_LISTATELEFONOCONTACTO(IDContacto.ToString)
            dtTipoComunicacion = ds.Tables(0)
            dtTelefonos = ds.Tables(1)

            MyGrillaConData.Columns.Clear()
            With MyGrillaConData
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = True
                .AllowUserToAddRows = True
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .AutoGenerateColumns = False

                .DataSource = dtTelefonos.DefaultView
                '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .Font = New System.Drawing.Font("Arial", 8.0!, FontStyle.Regular)
                .RowHeadersVisible = True
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            Dim Col1 As New DataGridViewTextBoxColumn
            With Col1
                .Name = "IDCOMUNICACION_CONTACTO"
                .DataPropertyName = "IDCOMUNICACION_CONTACTO"
                .HeaderText = "IDCOMUNICACION_CONTACTO"
            End With

            Dim Col2 As New DataGridViewTextBoxColumn
            With Col2
                .Name = "IDCONTACTO_PERSONA"
                .DataPropertyName = "IDCONTACTO_PERSONA"
                .HeaderText = "IDCONTACTO_PERSONA"
            End With

            Dim Col4 As New DataGridViewComboBoxColumn
            With Col4
                .Name = "COMUNICACION"
                .HeaderText = "COMUNICACION"
                .DataPropertyName = "COMUNICACION"
                .DataSource = dtTipoComunicacion.DefaultView
                .DisplayMember = "COMUNICACION"
                .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
                .Width = 130
            End With

            Dim Col5 As New DataGridViewTextBoxColumn
            With Col5
                .Name = "NUMERO"
                .DataPropertyName = "NROCOMUNICACION_CONTACTO"
                .HeaderText = "NUMERO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With

            MyGrillaConData.Columns.AddRange(Col1, Col2, Col4, Col5)
            For i As Integer = 0 To 3
                MyGrillaConData.Columns(i).Visible = False
            Next
            MyGrillaConData.Columns(2).Visible = True
            MyGrillaConData.Columns(3).Visible = True


        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub FrmClientes_ClickTabPage4() Handles Me.ClickTabPage4

        Me.txtCodigoUbigeo.Text = "00000"
        'hlamas
        MyCodigoCliente = txtCodigo.Text
        If vAccionRegistro = 1 Then
            If Not bClienteActualizado Then
                MessageBox.Show("Ingrese el Cliente, sus Contactos y luego las Direcciones...", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If bClienteActualizado Then
                cmbPaisDirecciones.SelectedValue = 4
                cmbDepartamentoDirecciones.SelectedValue = 15
                cmbProvinciaDirecciones.SelectedValue = 17
                cmbDistritoDirecciones.SelectedValue = 2
                txtCodigoClienteDirecciones.Text = txtCodigo.Text
                txtDireccionesCliente.Text = txtRazonSocial.Text
                SelectMenu(3)

                dtDireccionesCliente.Clear()
                Call CargaDirecciones(txtCodigoClienteDirecciones.Text, dgvDirecciones)
                Call CargaContactosDirecciones()

                'datahelper
                'Dim rstContactos As ADODB.Recordset
                'Dim daContactos As New OleDbDataAdapter
                Dim dtContactos As New DataTable

                'Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTA_CONTACTOS", 4, MyCodigoCliente, 2}
                Try
                    'rstContactos = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
                    'daContactos.Fill(dtContactos, rstContactos)
                    'Dim db As New BaseDatos
                    'db.Conectar()
                    'db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CONTACTOS", CommandType.StoredProcedure)
                    'db.AsignarParametro("iCODIGO_CLIENTE", MyCodigoCliente, OracleClient.OracleType.VarChar)
                    'db.AsignarParametro("iCUR_LISTACONTACTOS", OracleClient.OracleType.Cursor)
                    'db.Desconectar()
                    Dim objcliente As New dtoCLIENTES
                    dtContactos = objcliente.fn_LISTACONTACTO(MyCodigoCliente)

                    cmbContactoDireccion.DataSource = dtContactos.DefaultView
                    cmbContactoDireccion.DisplayMember = "NOMBRE_APELLIDO"
                    cmbContactoDireccion.ValueMember = "IDCONTACTO_PERSONA"
                Catch Qex As Exception
                    MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
        If vAccionRegistro = 2 Then
            If Not bClienteActualizado Then
                MessageBox.Show("Guarde las actualizaciones del Cliente, sus Contactos y luego las Direcciones...", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If bClienteActualizado And cmbTipoPersona.SelectedValue = 1 Then
                cmbPaisDirecciones.SelectedValue = 4
                cmbDepartamentoDirecciones.SelectedValue = 15
                cmbProvinciaDirecciones.SelectedValue = 17
                cmbDistritoDirecciones.SelectedValue = 2

                txtCodigoClienteDirecciones.Text = txtCodigo.Text
                txtDireccionesCliente.Text = txtRazonSocial.Text 'txtNombreP.Text & " " & txtApellidoP.Text & " " & txtApellidoM.Text
                SelectMenu(3)

                dtDireccionesCliente.Clear()
                Call CargaDirecciones(txtCodigoClienteDirecciones.Text, Me.dgvDirecciones)
                Call CargaContactosDirecciones()

                'datahelper
                'Dim rstContactos As ADODB.Recordset
                'Dim daContactos As New OleDbDataAdapter
                Dim dtContactos As New DataTable

                'Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTA_CONTACTOS", 4, MyCodigoCliente, 2}
                Try
                    'rstContactos = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
                    'daContactos.Fill(dtContactos, rstContactos)
                    'Dim db As New BaseDatos
                    'db.Conectar()
                    'db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CONTACTOS", CommandType.StoredProcedure)
                    'db.AsignarParametro("iCODIGO_CLIENTE", MyCodigoCliente, OracleClient.OracleType.VarChar)
                    'db.AsignarParametro("iCUR_LISTACONTACTOS", OracleClient.OracleType.Cursor)
                    'db.Desconectar()
                    Dim objcliente As New dtoCLIENTES
                    dtContactos = objcliente.fn_LISTACONTACTO(MyCodigoCliente)

                    cmbContactoDireccion.DataSource = dtContactos.DefaultView
                    cmbContactoDireccion.DisplayMember = "NOMBRE_APELLIDO"
                    cmbContactoDireccion.ValueMember = "IDCONTACTO_PERSONA"
                Catch Qex As Exception
                    MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            ElseIf bClienteActualizado And cmbTipoPersona.SelectedValue = 2 Then
                cmbPaisDirecciones.SelectedValue = 4
                cmbDepartamentoDirecciones.SelectedValue = 15
                cmbProvinciaDirecciones.SelectedValue = 17
                cmbDistritoDirecciones.SelectedValue = 2

                txtCodigoClienteDirecciones.Text = txtCodigo.Text
                txtDireccionesCliente.Text = txtNombreP.Text & " " & txtApellidoP.Text & " " & txtApellidoM.Text
                SelectMenu(3)

                dtDireccionesCliente.Clear()
                Call CargaDirecciones(txtCodigoClienteDirecciones.Text, Me.dgvDirecciones)
                Call CargaContactosDirecciones()

                'datahelper
                'Dim rstContactos As ADODB.Recordset
                'Dim daContactos As New OleDbDataAdapter
                Dim dtContactos As New DataTable

                'Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTA_CONTACTOS", 4, MyCodigoCliente, 2}
                Try
                    'rstContactos = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
                    'daContactos.Fill(dtContactos, rstContactos)
                    'Dim db As New BaseDatos
                    'db.Conectar()
                    'db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CONTACTOS", CommandType.StoredProcedure)
                    'db.AsignarParametro("iCODIGO_CLIENTE", MyCodigoCliente, OracleClient.OracleType.VarChar)
                    'db.AsignarParametro("iCUR_LISTACONTACTOS", OracleClient.OracleType.Cursor)
                    'db.Desconectar()
                    Dim objcliente As New dtoCLIENTES
                    dtContactos = objcliente.fn_LISTACONTACTO(MyCodigoCliente)

                    cmbContactoDireccion.DataSource = dtContactos.DefaultView
                    cmbContactoDireccion.DisplayMember = "NOMBRE_APELLIDO"
                    cmbContactoDireccion.ValueMember = "IDCONTACTO_PERSONA"
                Catch Qex As Exception
                    MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Private Sub CargaContactosDirecciones()
        Try
            'hlamas
            'Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_LISTA_CONTACTOS", 4, Me.txtCodigo.Text, 2}
            'Dim rstContactos As ADODB.Recordset = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
            'Dim da As New OleDbDataAdapter
            Dim dtContactosDirecciones As New DataTable
            dtContactosDirecciones.Clear()
            dgvContactosDirecciones.Columns.Clear()
            'da.Fill(dtContactosDirecciones, rstContactos)

            'Dim db As New BaseDatos
            'db.Conectar()
            'db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CONTACTOS", CommandType.StoredProcedure)
            'db.AsignarParametro("iCODIGO_CLIENTE", Me.txtCodigo.Text, OracleClient.OracleType.VarChar)
            'db.AsignarParametro("iCUR_LISTACONTACTOS", OracleClient.OracleType.Cursor)
            'db.Desconectar()
            Dim objcliente As New dtoCLIENTES
            'dtContactosDirecciones = objcliente.fn_LISTACONTACTO(Me.txtCodigo.Text)
            dtContactosDirecciones = objcliente.LISTA_CONTACTOS(Me.txtCodigo.Text)
            '
            With Me.dgvContactosDirecciones
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = True
                .AutoGenerateColumns = False
                .DataSource = dtContactosDirecciones.DefaultView
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .Font = New System.Drawing.Font("Arial", 8.0!, FontStyle.Regular)
                .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                .VirtualMode = True
                .RowHeadersVisible = True
                .ReadOnly = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End With

            Dim col0 As New DataGridViewTextBoxColumn
            With col0
                .Name = "IDCONTACTO_PERSONA"
                .DataPropertyName = "IDCONTACTO_PERSONA"
                .HeaderText = "IDCONTACTO_PERSONA"
            End With
            Dim col1 As New DataGridViewTextBoxColumn
            With col1
                .Name = "IDTIPO_CONTACTO"
                .DataPropertyName = "IDCENTRO_COSTO"
                .HeaderText = "IDTIPO_CONTACTO"
            End With
            Dim col2 As New DataGridViewTextBoxColumn
            With col2
                .Name = "TIPO_CONTACTO"
                .DataPropertyName = "TIPO_CONTACTO"
                .HeaderText = "TIPO_CONTACTO"
            End With
            Dim col3 As New DataGridViewCheckBoxColumn
            With col3
                .Name = "SELECCIONAR"
                .DataPropertyName = "SELECCIONAR"
                .HeaderText = "SELECCIONAR"
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            Dim col4 As New DataGridViewTextBoxColumn
            With col4
                .Name = "NOMBRE_APELLIDO"
                .DataPropertyName = "NOMBRE_APELLIDO"
                .HeaderText = "NOMBRE_APELLIDO"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Width = 400
            End With
            dgvContactosDirecciones.Columns.AddRange(col0, col1, col2, col3, col4)
            dgvContactosDirecciones.Columns(0).Visible = False
            dgvContactosDirecciones.Columns(1).Visible = False
            dgvContactosDirecciones.Columns(3).Frozen = True
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub FrmClientes_MenuSalir() Handles Me.MenuSalir
        Me.Close()
        Exit Sub
        If vAccionRegistro = 0 And Not bClienteActualizado Then
            Me.Close()
        End If

        If vAccionRegistro = 1 Then
            If bClienteActualizado Then
                Me.Close()
            ElseIf bClienteActualizado And Paso2 = 0 And Paso3 = 0 Then
                MessageBox.Show("Ingrese por lo menos un Contacto", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCodigoClienteContacto.Text = txtCodigo.Text
                txtNombreClienteContacto.Text = txtRazonSocial.Text
                SelectMenu(2)
            ElseIf bClienteActualizado And Paso2 = 1 And Paso3 = 0 Then
                MessageBox.Show("Ingrese una Direccion Legal", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)

                cmbPaisDirecciones.SelectedValue = 4
                cmbDepartamentoDirecciones.SelectedValue = 15
                cmbProvinciaDirecciones.SelectedValue = 17
                cmbDistritoDirecciones.SelectedValue = 2
                txtCodigoClienteDirecciones.Text = txtCodigo.Text

                If cmbTipoPersona.SelectedValue = 1 Then
                    txtDireccionesCliente.Text = txtRazonSocial.Text
                ElseIf cmbTipoPersona.SelectedValue = 2 Then
                    txtDireccionesCliente.Text = txtNombreP.Text & " " & txtApellidoP.Text & " " & txtApellidoM.Text
                End If

                SelectMenu(3)

                dtDireccionesCliente.Clear()
                Call CargaDirecciones(txtCodigoClienteDirecciones.Text, dgvDirecciones)

                'datahelper
                'Dim rstContactos As ADODB.Recordset
                'Dim daContactos As New OleDbDataAdapter
                Dim dtContactos As New DataTable

                'Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTA_CONTACTOS", 4, MyCodigoCliente, 2}
                Try
                    'rstContactos = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
                    'daContactos.Fill(dtContactos, rstContactos)
                    'Dim db As New BaseDatos
                    'db.Conectar()
                    'db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CONTACTOS", CommandType.StoredProcedure)
                    'db.AsignarParametro("iCODIGO_CLIENTE", OracleClient.OracleType.VarChar)
                    'db.AsignarParametro("iCUR_LISTACONTACTOS", OracleClient.OracleType.Cursor)
                    'db.Desconectar()
                    Dim objcliente As New dtoCLIENTES
                    dtContactos = objcliente.fn_LISTACONTACTO(MyCodigoCliente)

                    cmbContactoDireccion.DataSource = dtContactos.DefaultView
                    cmbContactoDireccion.DisplayMember = "NOMBRE_APELLIDO"
                    cmbContactoDireccion.ValueMember = "IDCONTACTO_PERSONA"
                Catch Qex As Exception
                    MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            ElseIf Not bClienteActualizado And Paso2 = 0 And Paso3 = 0 Then
                Me.Close()
            Else
                Me.Close()
            End If
        End If
        If vAccionRegistro = 2 Then
            Me.Close()
        End If
    End Sub
    Public Function sp_existe_rol() As DataTable
        Try
            'datahelper
            'Dim Obj As Object() = {"sp_existe_rol", 6, MyUsuario, 1, 38, 1}
            'Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
            Dim objcliente As New dtoCLIENTES
            Return objcliente.fn_existe_rol(MyUsuario, 38)
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
            'Return Nothing
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function sp_linea_credito() As DataTable
        Try
            'Dim Obj As Object() = {"sp_linea_credito", 4, iId, 2}
            'Return VOCONTROLUSUARIO.fnSQLQuery(Obj)
            Dim objcliente As New dtoCLIENTES
            Return objcliente.fn_linea_credito(iId)
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
            'Return Nothing
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Sub FrmClientes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.Hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    'Sub FormatoDgvCliente()
    '    With DgvCliente
    '        .Columns.Clear()
    '        '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    '        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
    '        .AllowUserToOrderColumns = True
    '        .AllowUserToDeleteRows = False
    '        .AllowUserToAddRows = False
    '        .AutoGenerateColumns = False
    '        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
    '        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        .VirtualMode = True
    '        .RowHeadersVisible = True
    '        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        .ScrollBars = ScrollBars.Both
    '        .DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
    '        .DefaultCellStyle.SelectionForeColor = Color.Black


    '        Dim idpersona As New DataGridViewTextBoxColumn
    '        With idpersona
    '            .HeaderText = "Id"
    '            .Name = "id"
    '            .DataPropertyName = "idpersona"
    '            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '            .SortMode = DataGridViewColumnSortMode.NotSortable
    '            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '            .Visible = False
    '            .ReadOnly = True
    '        End With

    '        Dim codigo_cliente As New DataGridViewTextBoxColumn
    '        With codigo_cliente
    '            .HeaderText = "Código"
    '            .Name = ""
    '            .DataPropertyName = "codigo_cliente"
    '            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '            .SortMode = DataGridViewColumnSortMode.NotSortable
    '            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '            .ReadOnly = True
    '        End With

    '        Dim razon_social As New DataGridViewTextBoxColumn
    '        With razon_social
    '            .HeaderText = "Cliente"
    '            .Name = ""
    '            .DataPropertyName = "razon_social"
    '            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '            .SortMode = DataGridViewColumnSortMode.NotSortable
    '            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '            .ReadOnly = True
    '        End With

    '        Dim representante_legal As New DataGridViewTextBoxColumn
    '        With representante_legal
    '            .HeaderText = "Representante Legal"
    '            .Name = "representante_legal"
    '            .DataPropertyName = "representante_legal"
    '            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '            .SortMode = DataGridViewColumnSortMode.NotSortable
    '            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '            .ReadOnly = True
    '            .Visible = False
    '        End With

    '        .Columns.AddRange(idpersona, codigo_cliente, razon_social, representante_legal)
    '    End With
    'End Sub

    Sub FormatoDgvSolicitud()
        With DgvSolicitud
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            .DefaultCellStyle.SelectionForeColor = Color.Black

            Dim idsolicitud_credito As New DataGridViewTextBoxColumn
            With idsolicitud_credito
                .HeaderText = "Id"
                .Name = "idsolicitud_credito"
                .DataPropertyName = "idsolicitud_credito"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Visible = False
                .ReadOnly = True
            End With

            Dim nro_solicitud As New DataGridViewTextBoxColumn
            With nro_solicitud
                .HeaderText = "Nº Solicitud"
                .Name = "nro_solicitud"
                .DataPropertyName = "nro_solicitud"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
            End With

            Dim fecha As New DataGridViewTextBoxColumn
            With fecha
                .HeaderText = "Fecha Solicitud"
                .Name = "fecha"
                .DataPropertyName = "fecha"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
            End With

            Dim monto_solicitado As New DataGridViewTextBoxColumn
            With monto_solicitado
                .HeaderText = "Monto Solicitado"
                .Name = "monto_solicitado"
                .DataPropertyName = "monto_solicitado"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim linea_solicitada As New DataGridViewTextBoxColumn
            With linea_solicitada
                .HeaderText = "Monto Aprobado"
                .Name = "linea_solicitada"
                .DataPropertyName = "linea_solicitada"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
                .Visible = False
            End With

            Dim sobregiro As New DataGridViewTextBoxColumn
            With sobregiro
                .HeaderText = "Sobregiro Aprobado"
                .Name = "sobregiro"
                .DataPropertyName = "sobregiro"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
                .Visible = False
            End With

            Dim total_asignado As New DataGridViewTextBoxColumn
            With total_asignado
                .HeaderText = "Línea Final Aprobada"
                .Name = "total_asignado"
                .DataPropertyName = "total_asignado"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
                .Visible = False
            End With

            Dim activo As New DataGridViewTextBoxColumn
            With activo
                .HeaderText = "¿Solicitud Activa?"
                .Name = "activo"
                .DataPropertyName = "activo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
            End With

            Dim estado As New DataGridViewTextBoxColumn
            With estado
                .HeaderText = "Estado"
                .Name = "estado"
                .DataPropertyName = "estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim estado1 As New DataGridViewTextBoxColumn
            With estado1
                .HeaderText = "Id Estado"
                .Name = "estado1"
                .DataPropertyName = "estado1"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim codigo_persona As New DataGridViewTextBoxColumn
            With codigo_persona
                .HeaderText = "Código"
                .Name = "codigo_persona"
                .DataPropertyName = "codigo_persona"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim nombre_persona As New DataGridViewTextBoxColumn
            With nombre_persona
                .HeaderText = "Razón Social"
                .Name = "nombre_persona"
                .DataPropertyName = "nombre_persona"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim telefono_direccion As New DataGridViewTextBoxColumn
            With telefono_direccion
                .HeaderText = "Teléfono"
                .Name = "telefono_direccion"
                .DataPropertyName = "telefono_direccion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim fax_direccion As New DataGridViewTextBoxColumn
            With fax_direccion
                .HeaderText = "Fax"
                .Name = "fax_direccion"
                .DataPropertyName = "fax_direccion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim rep_legal As New DataGridViewTextBoxColumn
            With rep_legal
                .HeaderText = "Representante Legal"
                .Name = "rep_legal"
                .DataPropertyName = "rep_legal"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim email_rep_legal As New DataGridViewTextBoxColumn
            With email_rep_legal
                .HeaderText = "Email Representante Legal"
                .Name = "email_rep_legal"
                .DataPropertyName = "email_rep_legal"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim telefono_rep_legal As New DataGridViewTextBoxColumn
            With telefono_rep_legal
                .HeaderText = "Teléfono Representante Legal"
                .Name = "telefono_rep_legal"
                .DataPropertyName = "telefono_rep_legal"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim movil_rep_legal As New DataGridViewTextBoxColumn
            With movil_rep_legal
                .HeaderText = "Móvil Representante Legal"
                .Name = "movil_rep_legal"
                .DataPropertyName = "movil_rep_legal"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim encargado_pagos As New DataGridViewTextBoxColumn
            With encargado_pagos
                .HeaderText = "Encargado Pagos"
                .Name = "encargado_pagos"
                .DataPropertyName = "encargado_pagos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim email_encargado_pagos As New DataGridViewTextBoxColumn
            With email_encargado_pagos
                .HeaderText = "Email Encargado Pagos"
                .Name = "email_encargado_pagos"
                .DataPropertyName = "email_encargado_pagos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim telefono_encargado_pagos As New DataGridViewTextBoxColumn
            With telefono_encargado_pagos
                .HeaderText = "Teléfono Encargado Pagos"
                .Name = "telefono_encargado_pagos"
                .DataPropertyName = "telefono_encargado_pagos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim movil_encargado_pagos As New DataGridViewTextBoxColumn
            With movil_encargado_pagos
                .HeaderText = "Móvil Encargado Pagos"
                .Name = "movil_encargado_pagos"
                .DataPropertyName = "movil_encargado_pagos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim periodo_pago As New DataGridViewTextBoxColumn
            With periodo_pago
                .HeaderText = "Tipo Pago"
                .Name = "periodo_pago"
                .DataPropertyName = "periodo_pago"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim dia_pago As New DataGridViewTextBoxColumn
            With dia_pago
                .HeaderText = "Día Pago"
                .Name = "dia_pago"
                .DataPropertyName = "dia_pago"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim fecha1 As New DataGridViewTextBoxColumn
            With fecha1
                .HeaderText = "Fecha1"
                .Name = "fecha1"
                .DataPropertyName = "fecha1"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim fecha2 As New DataGridViewTextBoxColumn
            With fecha2
                .HeaderText = "Fecha2"
                .Name = "fecha2"
                .DataPropertyName = "fecha2"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With
            Dim fecha3 As New DataGridViewTextBoxColumn
            With fecha3
                .HeaderText = "Fecha3"
                .Name = "fecha3"
                .DataPropertyName = "fecha3"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With
            Dim fecha4 As New DataGridViewTextBoxColumn
            With fecha4
                .HeaderText = "Fecha4"
                .Name = "fecha4"
                .DataPropertyName = "fecha4"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim horario_pago_ini As New DataGridViewTextBoxColumn
            With horario_pago_ini
                .HeaderText = "Horario Pago Inicio"
                .Name = "horario_pago_ini"
                .DataPropertyName = "horario_pago_ini"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim horario_pago_fin As New DataGridViewTextBoxColumn
            With horario_pago_fin
                .HeaderText = "Horario Pago Fin"
                .Name = "horario_pago_fin"
                .DataPropertyName = "horario_pago_fin"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim tipo_pago As New DataGridViewTextBoxColumn
            With tipo_pago
                .HeaderText = "Tipo Pago"
                .Name = "tipo_pago"
                .DataPropertyName = "tipo_pago"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim es_activo As New DataGridViewTextBoxColumn
            With es_activo
                .HeaderText = "¿Línea Crédito Activa?"
                .Name = "es_activo"
                .DataPropertyName = "es_activo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
            End With

            Dim dia1 As New DataGridViewTextBoxColumn
            With dia1
                .HeaderText = "Lunes"
                .Name = "dia1"
                .DataPropertyName = "dia1"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With
            Dim dia2 As New DataGridViewTextBoxColumn
            With dia2
                .HeaderText = "Martes"
                .Name = "dia2"
                .DataPropertyName = "dia2"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With
            Dim dia3 As New DataGridViewTextBoxColumn
            With dia3
                .HeaderText = "Miércoles"
                .Name = "dia3"
                .DataPropertyName = "dia3"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With
            Dim dia4 As New DataGridViewTextBoxColumn
            With dia4
                .HeaderText = "Jueves"
                .Name = "dia4"
                .DataPropertyName = "dia4"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With
            Dim dia5 As New DataGridViewTextBoxColumn
            With dia5
                .HeaderText = "Viernes"
                .Name = "dia5"
                .DataPropertyName = "dia5"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With
            Dim dia6 As New DataGridViewTextBoxColumn
            With dia6
                .HeaderText = "Sábado"
                .Name = "dia6"
                .DataPropertyName = "dia6"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With
            Dim dia7 As New DataGridViewTextBoxColumn
            With dia7
                .HeaderText = "Domingo"
                .Name = "dia7"
                .DataPropertyName = "dia7"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim email_persona_contacto As New DataGridViewTextBoxColumn
            With email_persona_contacto
                .HeaderText = "Email Contacto"
                .Name = "email_persona_contacto"
                .DataPropertyName = "email_persona_contacto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim telefono_persona_contacto As New DataGridViewTextBoxColumn
            With telefono_persona_contacto
                .HeaderText = "Teléfono Contacto"
                .Name = "telefono_persona_contacto"
                .DataPropertyName = "telefono_persona_contacto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim movil_persona_contacto As New DataGridViewTextBoxColumn
            With movil_persona_contacto
                .HeaderText = "Móvil Contacto"
                .Name = "movil_persona_contacto"
                .DataPropertyName = "movil_persona_contacto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim idcontacto_persona As New DataGridViewTextBoxColumn
            With idcontacto_persona
                .HeaderText = "Id Contacto"
                .Name = "idcontacto_persona"
                .DataPropertyName = "idcontacto_persona"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim contacto As New DataGridViewTextBoxColumn
            With contacto
                .HeaderText = "Contacto"
                .Name = "contacto"
                .DataPropertyName = "contacto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            .Columns.AddRange(idsolicitud_credito, nro_solicitud, fecha, monto_solicitado, activo, _
            linea_solicitada, sobregiro, total_asignado, estado, _
            estado1, codigo_persona, nombre_persona, telefono_direccion, fax_direccion, rep_legal, _
            email_rep_legal, telefono_rep_legal, movil_rep_legal, encargado_pagos, _
            email_encargado_pagos, telefono_encargado_pagos, movil_encargado_pagos, periodo_pago, dia_pago, _
            fecha1, fecha2, fecha3, fecha4, horario_pago_ini, horario_pago_fin, tipo_pago, es_activo, _
            dia1, dia2, dia3, dia4, dia5, dia6, dia7, email_persona_contacto, telefono_persona_contacto, _
            movil_persona_contacto, idcontacto_persona, contacto)
        End With
    End Sub
    Sub ActiVarDesactivar(ByVal estado As Boolean)
        GrbSolicitud.Enabled = estado
        GrbEmpresa.Enabled = estado
        GrbContacto.Enabled = estado
        GrbConsideracion.Enabled = estado

        Me.BtnNuevo.Enabled = Not estado
        If DgvSolicitud.Rows.Count > 0 Then
            If Not IsNothing(DgvSolicitud.CurrentRow) Then
                If DgvSolicitud.CurrentRow.Cells("activo").Value = "No" Or DgvSolicitud.CurrentRow.Cells("estado1").Value > 1 Then
                    Me.BtnModificar.Enabled = False
                Else
                    Me.BtnModificar.Enabled = Not estado
                End If
                If DgvSolicitud.CurrentRow.Cells("activo").Value = "No" Or DgvSolicitud.CurrentRow.Cells("estado1").Value = 3 Then
                    Me.BtnAnular.Enabled = False
                Else
                    Me.BtnAnular.Enabled = Not estado
                End If
            Else
                Me.BtnModificar.Enabled = Not estado
                Me.BtnAnular.Enabled = Not estado
            End If

        Else
            Me.BtnModificar.Enabled = False
            Me.BtnAnular.Enabled = False
        End If
        Me.BtnGrabar.Enabled = estado
        Me.BtnCancelar.Enabled = estado
    End Sub

    Sub CargarFuncionarios()
        Dim obj As New dtoCLIENTES
        Dim dt As DataTable = obj.Funcionarios
        With MyTreeView
            LlenarTreeView_3(dt, 2, MyTreeView, "Funcionarios", False, True)
        End With
    End Sub

    Sub CargarSolicitudes(ByVal cliente As Integer)
        Try
            Dim obj As New dtoCLIENTES
            dtSolicitud = New DataTable
            dtSolicitud = obj.Solicitud(cliente)

            DgvSolicitud.DataSource = dtSolicitud

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub Limpiar()
        Me.LblSolicitud.Text = ""
        Me.LblSolicitud.Tag = ""
        If vAccionRegistro = 2 Then
            Me.LblFecha.Text = Date.Now.ToShortDateString
        Else
            Me.LblFecha.Text = ""
        End If
        Me.TxtCredito.Text = ""
        'Me.LblFuncionario.Text = ""
        Me.LblEstado.Text = ""
        If vAccionRegistro <> 2 Then
            sCodigo = ""
            sCliente = ""
        End If
        Me.LblCodigo.Text = sCodigo
        Me.LblCliente.Text = sCliente

        Me.TxtTelefonoE.Text = ""
        Me.TxtFaxE.Text = ""
        'Me.LblRepresentante.Text = sRepresentanteLegal
        'Me.TxtEmailR.Text = ""
        'Me.TxtTelefonoR.Text = ""
        'Me.TxtMovilR.Text = ""
        Me.TxtPago.Text = ""
        Me.TxtEmailC.Text = ""
        Me.TxtTelefonoC.Text = ""
        Me.TxtMovilC.Text = ""

        Me.CboCondicion.SelectedValue = -1
        'CboDia.SelectedIndex = Date.Now.DayOfWeek - 1
        
        Me.RbtSemanal.Checked = True
        Me.DtpDia1.Value = ("01" & "/01/1900 00:00:00 a.m.")
        Me.DtpDia2.Value = ("01" & "/01/1900 00:00:00 a.m.")
        Me.DtpDia3.Value = ("01" & "/01/1900 00:00:00 a.m.")
        Me.DtpDia4.Value = ("01" & "/01/1900 00:00:00 a.m.")
        Me.ChkDia1.Checked = False
        Me.ChkDia2.Checked = False
        Me.ChkDia3.Checked = False
        'Me.ChkDia4.Checked = False

        Me.DtpDia1.Enabled = False
        Me.DtpDia2.Enabled = False
        Me.DtpDia3.Enabled = False
        Me.DtpDia4.Enabled = False

        Me.DtpHora1.Checked = False
        Me.DtpHora2.Checked = False

        Me.CboComercial.SelectedIndex = -1
        Me.lblEmail.Text = ""
        Me.LblTelefono.Text = ""
        Me.LblMovil.Text = ""

        Me.TxtAprobado.Text = ""
        Me.TxtSobregiro2.Text = ""
        Me.TxtLinea2.Text = ""

        Me.LimpiarDias()

        Me.BtnNuevo.Focus()
    End Sub

    Sub CargarContactoComercial(ByVal cbo As ComboBox, ByVal cliente As Integer)
        Try
            Dim obj As New dtoCLIENTES
            obj.Cliente = cliente
            Dim dt As DataTable = obj.ContactoComercial
            CargarCombo(cbo, dt, "contacto", "idcontacto_persona", -1)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub LimpiarDias()
        For i As Integer = 0 To Me.LstDia.Items.Count - 1
            Me.LstDia.SetItemChecked(i, False)
        Next
    End Sub

    Sub Grabar()
        Try
            Dim obj As New dtoCLIENTES
            obj.Id = IIf(Val(Me.LblSolicitud.Tag) = 0, 0, Me.LblSolicitud.Tag)
            obj.Cliente = iCliente
            obj.Codigo = Me.LblCodigo.Text
            obj.Nombre = Me.LblCliente.Text
            obj.TelefonoCliente = Me.TxtTelefonoE.Text
            obj.Fax = Me.TxtFaxE.Text
            obj.EmailRepresentante = "" 'Me.TxtEmailR.Text
            obj.TelefonoRepresentante = "" 'Me.TxtTelefonoR.Text
            obj.MovilRepresentante = "" 'Me.TxtMovilR.Text
            obj.Encargado = Me.TxtPago.Text
            obj.EmailEncargado = Me.TxtEmailC.Text
            obj.TelefonoEncargado = Me.TxtTelefonoC.Text
            obj.MovilEncargado = Me.TxtMovilC.Text
            obj.MontoSolicitado = CDbl(Me.TxtCredito.Text)
            obj.EmailContacto = Me.lblEmail.Text
            obj.TelefonoContacto = Me.LblTelefono.Text
            obj.MovilContacto = Me.LblMovil.Text
            obj.Contacto = Me.CboComercial.SelectedValue

            obj.PeriodoPago = Me.CboCondicion.SelectedValue
            obj.DiaPago = "LUNES" 'Me.CboDia.SelectedItem
            'Días de Cobranza
            For Each i As Integer In Me.LstDia.CheckedIndices
                Select Case i
                    Case 0
                        obj.Dia1 = 1
                    Case 1
                        obj.Dia2 = 1
                    Case 2
                        obj.Dia3 = 1
                    Case 3
                        obj.Dia4 = 1
                    Case 4
                        obj.Dia5 = 1
                    Case 5
                        obj.Dia6 = 1
                    Case 6
                        obj.Dia7 = 1
                End Select
            Next

            If Me.RbtMensual.Checked Then
                obj.Fecha1 = IIf(Me.DtpDia1.Enabled, Me.DtpDia1.Value.Day, 0)
                obj.Fecha2 = IIf(Me.DtpDia2.Enabled, Me.DtpDia2.Value.Day, 0)
                obj.Fecha3 = IIf(Me.DtpDia3.Enabled, Me.DtpDia3.Value.Day, 0)
                obj.Fecha4 = IIf(Me.DtpDia4.Enabled, Me.DtpDia4.Value.Day, 0)
            Else
                obj.Fecha1 = 0
                obj.Fecha2 = 0
                obj.Fecha3 = 0
                obj.Fecha4 = 0
            End If

            obj.HorarioPagoInicio = IIf(Me.DtpHora1.Checked, Me.DtpHora1.Text, "NULL")
            obj.HorarioPagoFin = IIf(Me.DtpHora2.Checked, Me.DtpHora2.Text, "NULL")

            obj.Fecha = Me.LblFecha.Text

            Dim dt As DataTable = obj.Grabar(iOpcion)
            DgvSolicitud.DataSource = dt

            MessageBox.Show("Solicitud Actualizada", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CargarSolicitud(ByVal row As DataGridViewRow)
        If row Is Nothing Then Return
        Me.LblSolicitud.Text = row.Cells("nro_solicitud").Value
        Me.LblSolicitud.Tag = row.Cells("idsolicitud_credito").Value
        Me.LblFecha.Text = row.Cells("fecha").Value

        Me.TxtCredito.Text = Format(row.Cells("monto_solicitado").Value, "##,###,###0.00")
        Me.TxtAprobado.Text = Format(row.Cells("linea_solicitada").Value, "##,###,###0.00")
        Me.TxtSobregiro2.Text = Format(row.Cells("sobregiro").Value, "##,###,###0.00")
        Me.TxtLinea2.Text = Format(row.Cells("total_asignado").Value, "##,###,###0.00")

        Me.LblEstado.Text = row.Cells("estado").Value
        Me.LblEstado.Tag = row.Cells("estado1").Value

        Me.LblCodigo.Text = IIf(IsDBNull(row.Cells("codigo_persona").Value), "", row.Cells("codigo_persona").Value)
        Me.LblCliente.Text = IIf(IsDBNull(row.Cells("nombre_persona").Value), "", row.Cells("nombre_persona").Value)

        Me.TxtTelefonoE.Text = IIf(IsDBNull(row.Cells("telefono_direccion").Value), "", row.Cells("telefono_direccion").Value)
        Me.TxtFaxE.Text = IIf(IsDBNull(row.Cells("fax_direccion").Value), "", row.Cells("fax_direccion").Value)

        'Me.LblRepresentante.Text = IIf(IsDBNull(row.Cells("rep_legal").Value), "", row.Cells("rep_legal").Value)
        'Me.TxtEmailR.Text = IIf(IsDBNull(row.Cells("email_rep_legal").Value), "", row.Cells("email_rep_legal").Value)
        'Me.TxtTelefonoR.Text = IIf(IsDBNull(row.Cells("telefono_rep_legal").Value), "", row.Cells("telefono_rep_legal").Value)
        'Me.TxtMovilR.Text = IIf(IsDBNull(row.Cells("movil_rep_legal").Value), "", row.Cells("movil_rep_legal").Value)

        Me.TxtPago.Text = IIf(IsDBNull(row.Cells("encargado_pagos").Value), "", row.Cells("encargado_pagos").Value)
        Me.TxtEmailC.Text = IIf(IsDBNull(row.Cells("email_encargado_pagos").Value), "", row.Cells("email_encargado_pagos").Value)
        Me.TxtTelefonoC.Text = IIf(IsDBNull(row.Cells("telefono_encargado_pagos").Value), "", row.Cells("telefono_encargado_pagos").Value)
        Me.TxtMovilC.Text = IIf(IsDBNull(row.Cells("movil_encargado_pagos").Value), "", row.Cells("movil_encargado_pagos").Value)

        Me.CboCondicion.SelectedValue = row.Cells("periodo_pago").Value
        'Me.CboDia.SelectedItem = row.Cells("dia_pago").Value

        If row.Cells("fecha1").Value > 0 Then
            Me.DtpDia1.Value = row.Cells("fecha1").Value & "/01/1900 00:00:00 a.m."
            Me.DtpDia1.Enabled = True
            Me.ChkDia1.Enabled = True
        Else
            Me.DtpDia1.Enabled = False
            Me.ChkDia1.Checked = False
        End If
        If row.Cells("fecha2").Value > 0 Then
            Me.DtpDia2.Value = row.Cells("fecha2").Value & "/01/1900 00:00:00 a.m."
            Me.DtpDia2.Enabled = True
            Me.ChkDia2.Enabled = True
            Me.ChkDia1.Checked = True
        Else
            Me.DtpDia2.Enabled = False
            Me.ChkDia2.Checked = False
        End If
        If row.Cells("fecha3").Value > 0 Then
            Me.DtpDia3.Value = row.Cells("fecha3").Value & "/01/1900 00:00:00 a.m."
            Me.DtpDia3.Enabled = True
            Me.ChkDia3.Enabled = True
            Me.ChkDia2.Checked = True
        Else
            Me.DtpDia3.Enabled = False
            Me.ChkDia3.Checked = False
        End If
        If row.Cells("fecha4").Value > 0 Then
            Me.DtpDia4.Value = row.Cells("fecha4").Value & "/01/1900 00:00:00 a.m."
            Me.DtpDia4.Enabled = True
            Me.ChkDia3.Checked = True
        Else
            Me.DtpDia4.Enabled = False
        End If

        If row.Cells("fecha1").Value > 0 Then
            Me.RbtMensual.Checked = True
        Else
            Me.RbtSemanal.Checked = True
        End If

        If IsDBNull(row.Cells("horario_pago_ini").Value) Or IsDBNull(row.Cells("horario_pago_fin").Value) Then
            Me.DtpHora1.Checked = False
            Me.DtpHora2.Checked = False
        Else
            Me.DtpHora1.Text = Format(CType(row.Cells("horario_pago_ini").Value, Date), "HH:mm tt").ToString
            Me.DtpHora2.Text = Format(CType(row.Cells("horario_pago_fin").Value, Date), "HH:mm tt").ToString
            Me.DtpHora1.Checked = True
            Me.DtpHora2.Checked = True
        End If

        Me.LstDia.SetItemChecked(0, row.Cells("dia1").Value)
        Me.LstDia.SetItemChecked(1, row.Cells("dia2").Value)
        Me.LstDia.SetItemChecked(2, row.Cells("dia3").Value)
        Me.LstDia.SetItemChecked(3, row.Cells("dia4").Value)
        Me.LstDia.SetItemChecked(4, row.Cells("dia5").Value)
        Me.LstDia.SetItemChecked(5, row.Cells("dia6").Value)
        Me.LstDia.SetItemChecked(6, row.Cells("dia7").Value)

        Me.CboComercial.SelectedValue = row.Cells("idcontacto_persona").Value
        Me.lblEmail.Text = IIf(IsDBNull(row.Cells("email_persona_contacto").Value), "", row.Cells("email_persona_contacto").Value)
        Me.LblTelefono.Text = IIf(IsDBNull(row.Cells("telefono_persona_contacto").Value), "", row.Cells("telefono_persona_contacto").Value)
        Me.LblMovil.Text = IIf(IsDBNull(row.Cells("movil_persona_contacto").Value), "", row.Cells("movil_persona_contacto").Value)
    End Sub
    Sub Eleccion(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click, BtnModificar.Click, BtnGrabar.Click, BtnCancelar.Click, BtnCancelar.Click
        Select Case CType(sender, Button).Text.Substring(1, 1)
            Case "N"
                Me.ActiVarDesactivar(True)
                iOpcion = 1
                Me.DgvSolicitud.Enabled = False
                Me.Limpiar()
                Me.TxtCredito.Focus()
            Case "M"
                Me.ActiVarDesactivar(True)
                iOpcion = 2
                Me.DgvSolicitud.Enabled = False
                Me.TxtCredito.Focus()
            Case "G"
                If Val(Me.TxtCredito.Text) <= 0 Then
                    MessageBox.Show("Ingrese el Monto Solicitado.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtCredito.Focus()
                    Return
                End If
                If Me.CboComercial.SelectedIndex = -1 Then
                    MessageBox.Show("Seleccione el Contacto Comercial.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.CboComercial.Focus()
                    Return
                End If
                If Me.TxtPago.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese el Nombre del Encargado de Pagos.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtPago.Text = ""
                    Me.TxtPago.Focus()
                    Return
                End If
                If Not ValiadarEXP_REG_Mail(Me.TxtEmailC.Text.Trim) Then
                    MessageBox.Show("Ingrese Un Correo Electrónico Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtEmailC.Focus()
                    Return
                Else
                    Me.TxtEmailC.Text = Me.TxtEmailC.Text.Trim
                End If
                If Me.TxtTelefonoC.Text.Trim.Length = 0 And Me.TxtMovilC.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Teléfono o Móvil del Encargado de Pagos.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtMovilC.Text = ""
                    Me.TxtTelefonoC.Text = ""
                    Me.TxtTelefonoC.Focus()
                    Return
                End If
                If Me.CboCondicion.SelectedIndex = -1 Then
                    MessageBox.Show("Debe Seleccionar la Condición de Cobranza.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.CboCondicion.Focus()
                    Return
                End If
                If Me.RbtSemanal.Checked Then
                    Dim j As Integer = 0
                    For Each i As Integer In Me.LstDia.CheckedIndices
                        j = 1
                    Next
                    If j = 0 Then
                        MessageBox.Show("Debe Seleccionar al menos un día.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.LstDia.Focus()
                        Me.LstDia.SetSelected(0, True)
                        Return
                    End If
                End If

                If Not (Me.DtpHora1.Checked) Then
                    MessageBox.Show("Seleccione Hora de Cobranza de Inicio", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DtpHora1.Focus()
                    Return
                End If

                If Not (Me.DtpHora2.Checked) Then
                    MessageBox.Show("Seleccione Hora de Cobranza Final", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DtpHora2.Focus()
                    Return
                End If

                Me.Grabar()
                Me.DgvSolicitud.ReadOnly = False
                Me.ActiVarDesactivar(False)
                Me.DgvSolicitud.Enabled = True
                Me.BtnNuevo.Focus()
            Case "C"
                Me.ActiVarDesactivar(False)
                Me.CargarSolicitud(DgvSolicitud.CurrentRow)
                Me.DgvSolicitud.Enabled = True
                Me.BtnNuevo.Focus()
            Case "A"
        End Select
    End Sub

    Private Sub TxtCredito_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCredito.Enter
        Dim iValor As Double = 0
        If Me.TxtCredito.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.TxtCredito.Text
        End If
        Me.TxtCredito.Text = Format(CDbl(iValor), "########0.00")

    End Sub

    Private Sub TxtCredito_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCredito.GotFocus
        Me.TxtCredito.SelectAll()
    End Sub

    Private Sub TxtCredito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCredito.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.TxtTelefonoE.Focus()
        Else
            e.Handled = Numero(e, TxtCredito)
        End If

    End Sub

    Private Sub TxtCredito_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCredito.LostFocus
        Dim iValor As Double = 0
        If Me.TxtCredito.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.TxtCredito.Text
        End If
        Me.TxtCredito.Text = Format(CDbl(iValor), "##,###,###0.00")

    End Sub

    Private Sub TxtTelefonoE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTelefonoE.GotFocus
        Me.TxtTelefonoE.SelectAll()
    End Sub

    Private Sub TxtTelefonoE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTelefonoE.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.TxtFaxE.Focus()
        End If
    End Sub

    Private Sub TxtFaxE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFaxE.GotFocus
        Me.TxtFaxE.SelectAll()
    End Sub

    Private Sub TxtFaxE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFaxE.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.CboComercial.Focus()
            'Me.TxtEmailR.Focus()
        End If
    End Sub

    Private Sub CboComercial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboComercial.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.TxtPago.Focus()
        End If
    End Sub

    Private Sub CboComercial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboComercial.SelectedIndexChanged
        If bInicio Then Return
        If Not (Me.CboComercial.SelectedValue Is Nothing) Then
            Me.ContactoDatos(CboComercial.SelectedValue)
        End If
    End Sub
    Sub ContactoDatos(ByVal id As Integer)
        Dim obj As New dtoCLIENTES
        obj.Contacto = id
        Dim dt As DataTable = obj.ContactoDatos()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Select Case dt.Rows(i).Item(0)
                    Case 1
                        Me.LblTelefono.Text = IIf(IsDBNull(dt.Rows(i).Item(1)), "", dt.Rows(i).Item(1))
                    Case 2
                        Me.LblMovil.Text = IIf(IsDBNull(dt.Rows(i).Item(1)), "", dt.Rows(i).Item(1))
                    Case 3
                        Me.lblEmail.Text = IIf(IsDBNull(dt.Rows(i).Item(1)), "", dt.Rows(i).Item(1))
                End Select
            Next
        Else
            Me.lblEmail.Text = ""
            Me.LblTelefono.Text = ""
            Me.LblMovil.Text = ""
        End If
    End Sub

    Private Sub TxtPago_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPago.GotFocus
        Me.TxtPago.SelectAll()
    End Sub

    Private Sub TxtPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPago.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.TxtEmailC.Focus()
        End If
    End Sub

    Private Sub TxtEmailC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEmailC.GotFocus
        Me.TxtEmailC.SelectAll()
    End Sub

    Private Sub TxtEmailC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEmailC.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.TxtTelefonoC.Focus()
        End If
    End Sub

    Private Sub TxtTelefonoC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTelefonoC.GotFocus
        Me.TxtTelefonoC.SelectAll()
    End Sub

    Private Sub TxtTelefonoC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTelefonoC.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.TxtMovilC.Focus()
        End If
    End Sub

    Private Sub TxtMovilC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMovilC.GotFocus
        Me.TxtMovilC.SelectAll()
    End Sub

    Private Sub TxtMovilC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMovilC.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.CboCondicion.Focus()
        End If
    End Sub

    Private Sub RbtSemanal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtSemanal.CheckedChanged
        Me.DtpDia1.Enabled = False
        Me.ChkDia1.Enabled = False
        Me.DtpDia2.Enabled = False
        Me.ChkDia2.Enabled = False
        Me.DtpDia3.Enabled = False
        Me.ChkDia3.Enabled = False
        Me.DtpDia4.Enabled = False

        Me.ChkDia1.Checked = False
        Me.ChkDia2.Checked = False
        Me.ChkDia3.Checked = False

        Me.LstDia.Enabled = True
        'Me.ChkDia4.Enabled = False
        'Me.CboDia.Focus()
    End Sub

    Private Sub RbtSemanal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RbtSemanal.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.LstDia.Focus()
        End If
    End Sub

    Private Sub RbtMensual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtMensual.CheckedChanged
        Me.DtpDia1.Enabled = True
        Me.ChkDia1.Enabled = True
        Me.LstDia.Enabled = False
        LimpiarDias()
        'Me.DtpDia2.Enabled = True
        'Me.ChkDia2.Enabled = True
        'Me.DtpDia3.Enabled = True
        'Me.ChkDia3.Enabled = True
        'Me.DtpDia4.Enabled = True
        'Me.ChkDia4.Enabled = True
        'Me.CboDia.Focus()
    End Sub

    Private Sub RbtMensual_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RbtMensual.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.DtpDia1.Focus()
        End If
    End Sub

    Private Sub LstDia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles LstDia.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If Me.DtpDia1.Enabled Then
                Me.DtpDia1.Focus()
            Else
                Me.DtpHora1.Focus()
            End If
        End If
    End Sub

    Private Sub DtpDia1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpDia1.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.ChkDia1.Focus()
        End If
    End Sub

    Private Sub ChkDia1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkDia1.CheckedChanged
        Me.DtpDia2.Enabled = Me.ChkDia1.Checked
        Me.ChkDia2.Enabled = Me.ChkDia1.Checked
        If Not Me.ChkDia1.Checked Then
            Me.DtpDia3.Enabled = Me.ChkDia1.Checked
            Me.ChkDia3.Enabled = Me.ChkDia1.Checked
            Me.DtpDia4.Enabled = Me.ChkDia1.Checked
        End If
        Me.ChkDia2.Checked = False
        Me.ChkDia3.Checked = False
    End Sub

    Private Sub DtpDia2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpDia2.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.ChkDia2.Focus()
        End If
    End Sub

    Private Sub ChkDia2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkDia2.CheckedChanged
        Me.DtpDia3.Enabled = Me.ChkDia2.Checked
        Me.ChkDia3.Enabled = Me.ChkDia2.Checked
        If Not Me.ChkDia2.Checked Then
            Me.DtpDia3.Enabled = Me.ChkDia2.Checked
            Me.ChkDia3.Enabled = Me.ChkDia2.Checked
            Me.ChkDia3.Checked = Me.ChkDia2.Checked
            Me.DtpDia4.Enabled = Me.ChkDia2.Checked
        End If
        Me.ChkDia3.Checked = False
    End Sub

    Private Sub ChkDia2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ChkDia2.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If Me.DtpDia3.Enabled Then
                Me.DtpDia3.Focus()
            Else
                Me.DtpHora1.Focus()
            End If
        End If
    End Sub

    Private Sub DtpDia3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpDia3.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.ChkDia3.Focus()
        End If
    End Sub

    Private Sub ChkDia3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkDia3.CheckedChanged
        Me.DtpDia4.Enabled = Me.ChkDia3.Checked
    End Sub

    Private Sub ChkDia3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ChkDia3.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If Me.DtpDia4.Enabled Then
                Me.DtpDia4.Focus()
            Else
                Me.DtpHora1.Focus()
            End If
        End If
    End Sub

    Private Sub DtpDia4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpDia4.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.DtpHora1.Focus()
        End If
    End Sub

    Private Sub DtpHora1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpHora1.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.DtpHora2.Focus()
        End If
    End Sub

    Private Sub DtpHora2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DtpHora2.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.BtnGrabar.Focus()
        End If
    End Sub

    Private Sub DgvSolicitud_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvSolicitud.CellClick
        If DgvSolicitud.Rows.Count > 0 Then
            CargarSolicitud(DgvSolicitud.CurrentRow)
        Else
            Limpiar()
        End If
    End Sub

    Private Sub FrmClientes_ClickTabPage5() Handles Me.ClickTabPage5
        SelectMenu(5)
        'FormatoDgvSolicitud()
        'CargarCondicionPago(Me.CboCondicion)
        'ActiVarDesactivar(False)
        'Valida si Cliente tiene una dirección legal
        With DataGridLista
            If .Rows.Count > 0 Then
                bInicio = True
                If vAccionRegistro = 1 Then
                    Me.Limpiar()
                    Me.DgvSolicitud.Enabled = False
                    Me.LblEstado.Text = "El Cliente aún no está Registrado"
                    Me.BtnNuevo.Enabled = False
                    Return
                End If
                iCliente = .CurrentRow.Cells(1).Value
                If DireccionLegal(iCliente) = 0 Then
                    Me.Limpiar()
                    Me.DgvSolicitud.Enabled = False
                    Me.LblEstado.Text = "El Cliente no tiene definido una Dirección Legal"
                    Me.BtnNuevo.Enabled = False
                    Return
                End If
                Me.DgvSolicitud.Enabled = True
                sCodigo = .CurrentRow.Cells(2).Value
                sCliente = .CurrentRow.Cells(4).Value
                sRepresentanteLegal = Me.txtRepLegal.Text.Trim 'IIf(IsDBNull(.CurrentRow.Cells(3).Value), "", .CurrentRow.Cells(3).Value)
                Limpiar()
                CargarContactoComercial(Me.CboComercial, iCliente)
                Me.CargarSolicitudes(iCliente)
                bInicio = False
            Else
                iCliente = 0
                sCliente = ""
                sCodigo = ""
                Me.CboComercial.SelectedIndex = -1
                sRepresentanteLegal = ""
            End If
            Me.ActiVarDesactivar(False)
        End With
    End Sub

    Private Sub CboCondicion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboCondicion.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.RbtSemanal.Focus()
        End If
    End Sub

    Private Sub DgvSolicitud_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvSolicitud.RowEnter
        If DgvSolicitud.Rows.Count > 0 Then
            CargarSolicitud(DgvSolicitud.Rows(e.RowIndex))
            If DgvSolicitud.Rows(e.RowIndex).Cells("activo").Value = "No" Or _
            DgvSolicitud.Rows(e.RowIndex).Cells("estado1").Value > 1 Then
                Me.BtnModificar.Enabled = False
            Else
                Me.BtnModificar.Enabled = True
            End If
            If DgvSolicitud.Rows(e.RowIndex).Cells("activo").Value = "No" Or _
            DgvSolicitud.Rows(e.RowIndex).Cells("estado1").Value = 3 Then
                Me.BtnAnular.Enabled = False
            Else
                Me.BtnAnular.Enabled = True
            End If
        Else
            Limpiar()
        End If
    End Sub

    Private Sub BtnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnular.Click
        Dim iResp As DialogResult
        iResp = MessageBox.Show("¿Está Seguro de Desactivar la Solicitud?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If iResp = Windows.Forms.DialogResult.Yes Then
            Desactivar()
        End If
    End Sub

    Sub Desactivar()
        Try
            Dim obj As New dtoCLIENTES
            Dim id As Integer = Me.LblSolicitud.Tag
            Dim dt As DataTable = obj.Desactivar(id, iCliente)
            DgvSolicitud.DataSource = dt

            MessageBox.Show("La Solicitud ha sido Desactivada.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    

    
End Class

