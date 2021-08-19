'Imports System.Data
'Imports System.Data.OleDb
'Imports AccesoDatos

Public Class FrmClientesPasajes
    Dim ContactoClass As New dtoCONTACTO_CLIENTE
    Dim vAccionRegistro As Integer
    Dim bIngreso As Boolean = False
    Public hnd As Long

#Region " DECLARACION VARIABLES "
    'Para el Ingreso de Solo Numeros
    Public KeyAscii As Short
    'Declaracion de Data Adapters
    'Private DataAdapterGenerics As New OleDbDataAdapter
    'Declaracion de DataTables
    Private dtTipoPersona As New System.Data.DataTable
    Private dtTipoDocPersona As New System.Data.DataTable
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
    Dim vIDPersona As Integer

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
    '
#Region "Funcion Adicional"
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
#End Region
    '
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
                If dgvContactosDirecciones.Rows(i).Cells("SELECCIONAR").Value = 1 Then

                    DireccionesClass._IDContacto = dgvContactosDirecciones.Rows(i).Cells("IDCONTACTO_PERSONA").Value
                    DireccionesClass._IDCentroCosto = dgvContactosDirecciones.Rows(i).Cells("IDTIPO_CONTACTO").Value

                    DireccionesClass._IDContacto = dgvContactosDirecciones.Rows(i).Cells("IDCONTACTO_PERSONA").Value
                    DireccionesClass._IDCentroCosto = dgvContactosDirecciones.Rows(i).Cells("IDTIPO_CONTACTO").Value

                    'datahelper
                    'Dim respTripode As ADODB.Recordset
                    'respTripode = DireccionesClass.AsociaTripodePasajes_RGT()
                    Dim respTripode As DataTable = DireccionesClass.AsociaTripodePasajes_RGT()
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
        '        If dgvContactosDirecciones.Rows(i).Cells("SELECCIONAR").Value = 1 Then

        '            DireccionesClass._IDContacto = dgvContactosDirecciones.Rows(i).Cells("IDCONTACTO_PERSONA").Value
        '            DireccionesClass._IDCentroCosto = dgvContactosDirecciones.Rows(i).Cells("IDTIPO_CONTACTO").Value

        '            DireccionesClass._IDContacto = dgvContactosDirecciones.Rows(i).Cells("IDCONTACTO_PERSONA").Value
        '            DireccionesClass._IDCentroCosto = dgvContactosDirecciones.Rows(i).Cells("IDTIPO_CONTACTO").Value

        '            Dim respTripode As ADODB.Recordset
        '            respTripode = DireccionesClass.AsociaTripodePasajes_RGT()
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
                                ContadorInsercionTelefeonos += 1
                                Paso2 = 1
                            ElseIf respComunicacion.Rows.Count = 2 And Len(Trim(respComunicacion.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                            End If

                            'datahelper
                            'If respComunicacion.Fields.Count = 1 Then 'Se realizo Correctamente.
                            '    ContadorInsercionTelefeonos += 1
                            '    Paso2 = 1
                            'ElseIf respComunicacion.Fields.Count = 2 And Len(Trim(respComunicacion.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                            'End If
                        End If
                    End If
                Next

                'If ContadorInsercionTelefeonos = dgvTelefonosContacto.Rows.Count - 1 Or ContadorInsercionTelefeonos = 1 Then
                '    'MessageBox.Show("Insercion de Telefonos Correctos", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Paso2 = 1
                'End If
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
                        'If Not dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value Is Nothing Then
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
                                    'MessageBox.Show(respComunicacion.Fields(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    ContadorInsercionTelefeonos += 1
                                    Paso2 = 1
                                ElseIf respComunicacion.Rows.Count = 2 And Len(Trim(respComunicacion.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                                    'MessageBox.Show("Descripción: " & respComunicacion.Fields(1).Value, "ORACLE -> Error: " & respComunicacion.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End If
                        End If
                    Next
                ElseIf respComunicacionDeleted.Rows.Count = 2 And Len(Trim(respComunicacionDeleted.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                    MessageBox.Show("Descripción: " & respComunicacionDeleted.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respComunicacionDeleted.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                'If respComunicacionDeleted.Fields.Count = 1 Then 'Se realizo Correctamente.
                '    Dim ContadorInsercionTelefeonos As Integer = 0
                '    For i As Integer = 0 To dgvTelefonosContacto.Rows.Count - 1
                '        'If Not dgvTelefonosContacto.Rows(i).Cells("COMUNICACION").Value Is Nothing Then
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
                '                    'MessageBox.Show(respComunicacion.Fields(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '                    ContadorInsercionTelefeonos += 1
                '                    Paso2 = 1
                '                ElseIf respComunicacion.Fields.Count = 2 And Len(Trim(respComunicacion.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
                '                    'MessageBox.Show("Descripción: " & respComunicacion.Fields(1).Value, "ORACLE -> Error: " & respComunicacion.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
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

        ''If MyGrillaTelefonos.DataSource Is Nothing Then
        'Try
        '    Dim rstGrillaTelefonos As ADODB.Recordset = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
        '    Dim rstComboGrilla As ADODB.Recordset = rstGrillaTelefonos.NextRecordset
        '    'Dim daTelefonos As New OleDbDataAdapter
        '    'Dim dtGrillaTelefonos As New DataTable
        '    'Dim dtComboGrilla As New DataTable

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
        '        '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
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

        ''End If
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
            ElseIf restContacto.Rows.Count = 2 And Len(Trim(restContacto.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                MessageBox.Show("Descripción: " & restContacto.Rows(0).Item(1).ToString, "ORACLE -> Error: " & restContacto.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
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

                'Dim ContactoClass As New dtoCONTACTO_CLIENTE

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

                'Dim ContactoClass As New dtoCONTACTO_CLIENTE

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
    '''  Private Sub AsignacionFuncionario(ByVal MyCodigoClienteFuncionario As String)
    ''' 
    Private Sub AsignacionFuncionarioPasa(ByVal MyCodigoClienteFuncionario As String)
        If txtFuncionarioCuenta.Text <> "No Asignado..." Then
            '            If vAccionRegistro = 1 Then 'Asignando Funcionario a Nuevo Cliente.       (TEPSA)
            Dim AsociaClass As New dtoASOCIAFUNCIONARIO_CLIENTE
            AsociaClass.Control = vAccionRegistro
            ''''''''''''''''''''''''''''''''''''''''''''
            'If MyRol = 11 Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 1) Then
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
            'datahelper
            'respAsocia = AsociaClass.AsociaFuncionarioJuridicoPasa()
            Dim respAsocia As DataTable = AsociaClass.AsociaFuncionarioJuridicoPasa()
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
    Private Sub AsignacionFuncionario_eliminarlo(ByVal MyCodigoClienteFuncionario As String)
        'If txtFuncionarioCuenta.Text <> "No Asignado..." Then
        '    '            If vAccionRegistro = 1 Then 'Asignando Funcionario a Nuevo Cliente.       (TEPSA)
        '    Dim AsociaClass As New dtoASOCIAFUNCIONARIO_CLIENTE
        '    AsociaClass.Control = vAccionRegistro
        '    ''''''''''''''''''''''''''''''''''''''''''''
        '    If MyRol = 11 Then
        '        AsociaClass.IDFuncionario = ModIVOPERSONA.MyUsuario
        '        If AsociaClass.Control = 1 Then   ' Tepsa 
        '            AsociaClass.IDFuncionarioActual = ModIVOPERSONA.MyUsuario
        '        Else
        '            AsociaClass.IDFuncionarioActual = CodFuncionarioNegocio     ' Tepsa 
        '        End If
        '        AsociaClass.TipoFuncionario = ModIVOPERSONA.MyRol
        '    Else
        '        AsociaClass.IDFuncionario = CodFuncionarioNegocio
        '        AsociaClass.IDFuncionarioActual = CodFuncionarioNegocio
        '        AsociaClass.TipoFuncionario = TipoFuncionarioNegocio
        '    End If
        '    ''''''''''''''''''''''''''''''''''''''''''''
        '    'AsociaClass.IDFuncionario = CodFuncionarioNegocio
        '    'AsociaClass.IDFuncionarioActual = CodFuncionarioNegocio
        '    'AsociaClass.TipoFuncionario = TipoFuncionarioNegocio
        '    AsociaClass.IDPersona = MyCodigoClienteFuncionario
        '    AsociaClass.IDUsuarioPersona = MyUsuario
        '    AsociaClass.RolUsuario = MyRol
        '    AsociaClass.IP = MyIP '"192.168.50.47"
        '    AsociaClass.IDEstadoRegistro = 1

        '    respAsocia = AsociaClass.AsociaFuncionarioJuridico()
        '    If respAsocia.Fields.Count = 1 Then 'Se realizo Correctamente.
        '        Paso1 = 1
        '        AccionesJuridica()
        '    ElseIf respAsocia.Fields.Count = 2 And Len(Trim(respAsocia.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
        '        MessageBox.Show("Descripción: " & respAsocia.Fields(1).Value, "ORACLE -> Error: " & respAsocia.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End If
        'Else
        '    Paso1 = 1
        '    AccionesJuridica()
        '    'MessageBox.Show("LAS REASIGNACIONES DE FUNCIONARIOS Y RESPONSABLES DE CTACTE," & vbCrLf & "SE REALIZAN EN LOS MODULOS DE ACUERDOS COMERCIALES Y CTACTE.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
        ''ElseIf txtFuncionarioCuenta.Text = "No Asignado..." Then

        ''End If
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
        MyClassCliente._MyFechaNacimiento = Me.txtFechaNacimiento.GetMyFecha
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
        MyClassCliente._Mytipocredito = Me.cmb_tipo_cred_pasaje.SelectedIndex

        'datahelper
        'respOracle = MyClassCliente.GrabaClienteNatural()
        Dim respOracle As DataTable = MyClassCliente.GrabaClienteNatural()

        If respOracle.Rows.Count = 1 Then 'Se realizo Correctamente.
            MessageBox.Show(respOracle.Rows(0).Item(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Para tener el codigo cliente en la insercion de Contactos y Direcciones.
            MyCodigoCliente = MyClassCliente._MyCodigoCliente 'MessageBox.Show(MyCodigoCliente)
            If Me.chkContadoCredito.Checked = False Then
                MessageBox.Show("AsignacionFuncionario EXCLUSIVE DE nATURAL TE FALTA")
            Else
                Paso1 = 1
                AccionesNatural()
            End If
        ElseIf respOracle.Rows.Count = 2 And Len(Trim(respOracle.Rows.Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
            MessageBox.Show("Descripción: " & respOracle.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respOracle.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        'datahelper
        'If respOracle.Fields.Count = 1 Then 'Se realizo Correctamente.
        '    MessageBox.Show(respOracle.Fields(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    'Para tener el codigo cliente en la insercion de Contactos y Direcciones.
        '    MyCodigoCliente = MyClassCliente._MyCodigoCliente 'MessageBox.Show(MyCodigoCliente)
        '    If Me.chkContadoCredito.Checked = False Then
        '        MessageBox.Show("AsignacionFuncionario EXCLUSIVE DE nATURAL TE FALTA")
        '    Else
        '        Paso1 = 1
        '        AccionesNatural()
        '    End If
        'ElseIf respOracle.Fields.Count = 2 And Len(Trim(respOracle.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
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
            '27/08/2010
            MyClassCliente._Mytipocredito = Me.cmb_tipo_cred_pasaje.SelectedIndex
            'Dim respOracle As ADODB.Recordset
            'datahelper
            'respOracle = MyClassCliente.GrabaClienteJuridico()
            Dim respOracle As DataTable = MyClassCliente.GrabaClienteJuridico()
            'datahelper
            'If respOracle.Fields.Count = 1 Then 'Se realizo Correctamente.
            If respOracle.Rows.Count = 1 Then 'Se realizo Correctamente.
                'Para tener el codigo cliente en la insercion de Contactos y Direcciones.
                MyCodigoCliente = MyClassCliente._MyCodigoCliente 'MessageBox.Show(MyCodigoCliente)
                AsignacionFuncionarioPasa(MyCodigoCliente)
                'If Me.chkContadoCredito.Checked = False Then TEPSA 29/09/2006 
                If Me.chkContadoCredito.Checked = True Then
                    'AsignacionFuncionario(MyCodigoCliente)
                    'Else
                    Paso1 = 1
                    AccionesJuridica()
                End If
                'datahelper
                'ElseIf respOracle.Fields.Count = 2 And Len(Trim(respOracle.Fields(0).Value)) <= 6 Then 'Si se producjo algun error.
            ElseIf respOracle.Rows.Count = 2 And Len(Trim(respOracle.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                'datahelper
                'MessageBox.Show("Descripción: " & respOracle.Fields(1).Value, "ORACLE -> Error: " & respOracle.Fields(0).Value, MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show("Descripción: " & respOracle.Rows(0).Item(1).ToString, "ORACLE -> Error: " & respOracle.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            ' Refrescar los datos
            Dim dgvr As DataGridViewRow = Me.DataGridLista.CurrentRow()
            dgvr.Cells("IDFUNCIONARIO_ACTUAL").Value = CodFuncionarioNegocio
        Catch ex As Exception
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
    Private Sub CargarListaContactos2009_eliminarlo()
        'Dim rstContactos As ADODB.Recordset
        ''Dim daContactos As New OleDbDataAdapter
        ''Dim dtContactos As New DataTable
        ''MessageBox.Show(MyCodigoCliente)
        'Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTACONTACTO", 4, MyCodigoCliente, 2}
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

        '    dgvContactos.Columns.AddRange(col1, col2, col3, col4, col5, col6, col7, col8, _
        '                                  col9, col10, col11, col12, col13, col14, col15)
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
    End Sub


    ''' <summary>
    ''' Carga la Lista de Telefonos del Contacto seleccionado en la Grilla.
    ''' </summary>
    ''' <param name="IDContacto"></param>
    ''' <remarks></remarks>
    Private Sub CargarListaTelefonos2009_eliminarlo(ByVal IDContacto As Integer, ByVal MyGrillaConData As DataGridView)
        'Dim rstTipoComunicacion As ADODB.Recordset
        'Dim rstTelefonos As ADODB.Recordset
        ''Dim daTelefonos As New OleDbDataAdapter
        'Dim dtTipoComunicacion As New DataTable
        'Dim dtTelefonos As New DataTable
        'Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTATELEFONOCONTACTO", 4, IDContacto, 1}
        'Try
        '    rstTipoComunicacion = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
        '    rstTelefonos = rstTipoComunicacion.NextRecordset
        '    daTelefonos.Fill(dtTipoComunicacion, rstTipoComunicacion)
        '    daTelefonos.Fill(dtTelefonos, rstTelefonos)


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

    End Sub

    Private Sub LimpiaPersona()
        Try
            For Each MyObj As Object In TabDatos.Controls
                If TypeOf MyObj Is TextBox Then
                    CType(MyObj, TextBox).Text = ""
                End If
            Next
            '
            If vAccionRegistro = 1 Then   'Tepsa Cuando es nuevo solo debe limpiar (línea agregada solo el if) 'Tepsa 30/09/2006
                Call Funciones.LimpiaCheckBox(Me.chkCorporativo, Me.chkPostFacturacion, Me.chkAgenteRetencion, Me.chkContadoCredito)
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

    Private Sub FrmClientesPasajes_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmClientes_ClickTabPage3() Handles Me.ClickTabPage3
        ' Tepsa 02/10/2006 
        'If lb_editar = False Then
        '    Paso1 = 1
        'End If
        '
        If Paso1 = 0 Then
            'Me.MenuTab.Items(2).PerformClick()
            MessageBox.Show("Ingrese el Cliente y luego sus Contactos...", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        If Paso1 = 1 And Paso2 = 0 Then
            SelectMenu(2)
        End If
        If Paso1 = 1 And Paso2 = 1 Then
            SelectMenu(2)
        End If
    End Sub

    Private Sub FrmClientes_ClickTabPage4() Handles Me.ClickTabPage4

        Me.txtCodigoUbigeo.Text = "00000"

        If vAccionRegistro = 1 Then
            If Paso1 = 0 Then
                MessageBox.Show("Ingrese el Cliente, sus Contactos y luego las Direcciones...", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If Paso1 = 1 And Paso2 = 0 Then
                MessageBox.Show("Ingrese los Contactos y luego las Direcciones...", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If Paso1 = 1 And Paso2 = 1 Then
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
                'Dim dtContactos As New DataTable

                'Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTA_CONTACTOS", 4, MyCodigoCliente, 2}
                'Try
                '    rstContactos = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
                '    daContactos.Fill(dtContactos, rstContactos)
                '    cmbContactoDireccion.DataSource = dtContactos.DefaultView
                '    cmbContactoDireccion.DisplayMember = "NOMBRE_APELLIDO"
                '    cmbContactoDireccion.ValueMember = "IDCONTACTO_PERSONA"
                'Catch Qex As Exception
                '    MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End Try

                Dim dtContactos As New DataTable
                Try
                    Dim objcliente As New dtoCLIENTES
                    dtContactos = objcliente.LISTA_CONTACTOS(MyCodigoCliente)
                    cmbContactoDireccion.DataSource = dtContactos.DefaultView
                    cmbContactoDireccion.DisplayMember = "NOMBRE_APELLIDO"
                    cmbContactoDireccion.ValueMember = "IDCONTACTO_PERSONA"
                Catch Qex As Exception
                    MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End If
        End If
        If vAccionRegistro = 2 Then
            If Paso1 = 0 Then
                MessageBox.Show("Guarde las actualizaciones del Cliente, sus Contactos y luego las Direcciones...", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If Paso1 = 1 And Paso2 = 0 Then
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
                'Dim dtContactos As New DataTable

                'Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTA_CONTACTOS", 4, MyCodigoCliente, 2}
                'Try
                '    rstContactos = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
                '    daContactos.Fill(dtContactos, rstContactos)
                '    cmbContactoDireccion.DataSource = dtContactos.DefaultView
                '    cmbContactoDireccion.DisplayMember = "NOMBRE_APELLIDO"
                '    cmbContactoDireccion.ValueMember = "IDCONTACTO_PERSONA"
                'Catch Qex As Exception
                '    MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End Try
                Dim dtContactos As New DataTable
                Try
                    Dim objcliente As New dtoCLIENTES
                    dtContactos = objcliente.LISTA_CONTACTOS(MyCodigoCliente)
                    cmbContactoDireccion.DataSource = dtContactos.DefaultView
                    cmbContactoDireccion.DisplayMember = "NOMBRE_APELLIDO"
                    cmbContactoDireccion.ValueMember = "IDCONTACTO_PERSONA"
                Catch Qex As Exception
                    MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End If

            If Paso1 = 1 And Paso2 = 1 And cmbTipoPersona.SelectedValue = 1 Then
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
                'Dim dtContactos As New DataTable
                'Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTA_CONTACTOS", 4, MyCodigoCliente, 2}
                'Try
                '    rstContactos = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
                '    daContactos.Fill(dtContactos, rstContactos)
                '    cmbContactoDireccion.DataSource = dtContactos.DefaultView
                '    cmbContactoDireccion.DisplayMember = "NOMBRE_APELLIDO"
                '    cmbContactoDireccion.ValueMember = "IDCONTACTO_PERSONA"
                'Catch Qex As Exception
                '    MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End Try
                Dim dtContactos As New DataTable
                Try
                    Dim obj As New dtoCLIENTES
                    dtContactos = obj.LISTA_CONTACTOS(MyCodigoCliente)
                    cmbContactoDireccion.DataSource = dtContactos.DefaultView
                    cmbContactoDireccion.DisplayMember = "NOMBRE_APELLIDO"
                    cmbContactoDireccion.ValueMember = "IDCONTACTO_PERSONA"
                Catch Qex As Exception
                    MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End If

            If Paso1 = 1 And Paso2 = 1 And cmbTipoPersona.SelectedValue = 2 Then
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
                'Dim dtContactos As New DataTable
                'Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTA_CONTACTOS", 4, MyCodigoCliente, 2}
                'Try
                '    rstContactos = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
                '    daContactos.Fill(dtContactos, rstContactos)
                '    cmbContactoDireccion.DataSource = dtContactos.DefaultView
                '    cmbContactoDireccion.DisplayMember = "NOMBRE_APELLIDO"
                '    cmbContactoDireccion.ValueMember = "IDCONTACTO_PERSONA"
                'Catch Qex As Exception
                '    MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End Try
                Dim dtContactos As New DataTable
                Try
                    Dim obj As New dtoCLIENTES
                    dtContactos = obj.LISTA_CONTACTOS(MyCodigoCliente)
                    cmbContactoDireccion.DataSource = dtContactos.DefaultView
                    cmbContactoDireccion.DisplayMember = "NOMBRE_APELLIDO"
                    cmbContactoDireccion.ValueMember = "IDCONTACTO_PERSONA"
                Catch Qex As Exception
                    MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End If
        End If
    End Sub

    Private Sub FrmClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        ShadowLabel1.Text = "Mantenimiento de Clientes Pasajes"
        MenuTab.Items(0).Text = "LISTA CLIENTES"
        MenuTab.Items(1).Text = "MANTENIMIENTO"
        MenuTab.Items(2).Text = "CONTACTOS"
        MenuTab.Items(3).Text = "DIRECCIONES"
        'MenuTab.Items(4).Text = "AVAL"
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

        vAccionRegistro = 0
        vIDPersona = 0
        Try
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

            Dim obj As New dtoCLIENTES
            Dim ds As DataSet = obj.fn_COMBOSPERSONA

            dtTipoPersona = ds.Tables(0)
            dtTipoDocPersona = ds.Tables(1)
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

            Call Funciones.LlenaTreeFuncionariosPasajes(MyTreeView)

            dvTipoPersona = Funciones.CargarCombo(cmbTipoPersona, dtTipoPersona, "TIPO_PERSONA", "IDTIPO_PERSONA", 2)
            dvTipoDocPersona = Funciones.CargarCombo(cmbTipoDocIdent, dtTipoDocPersona, "TIPO_DOC_IDENTIDAD", "IDTIPO_DOC_IDENTIDAD", 1)
            dvRubro = Funciones.CargarCombo(cmbRubroEmpresarial, dtRubro, "RUBRO", "IDRUBRO", 2)
            dvClasPersona = Funciones.CargarCombo(cmbClasPersona, dtClasPersona, "CLASIFICACION_PERSONA", "IDCLASIFICACION_PERSONA", 6)
            dvTipoContacto = Funciones.CargarCombo(cmbTipoContacto, dtTipoContacto, "TIPO_CONTACTO", "IDTIPO_CONTACTO", 2)
            dvTipoDocPersona = Funciones.CargarCombo(cmbTipoDoctoContacto, dtTipoDocPersona, "TIPO_DOC_IDENTIDAD", "IDTIPO_DOC_IDENTIDAD", 1)
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
            '
            ' 27/08/2010 - loco de mierda
            Me.cmb_tipo_cred_pasaje.Items.Add(" -NINGUNO-")
            Me.cmb_tipo_cred_pasaje.Items.Add("AGENCIA")
            Me.cmb_tipo_cred_pasaje.Items.Add("CREDITO")
            '
            Me.cmb_tipo_cred_pasaje.SelectedIndex = 0
            '
            rdbJuridicos.Checked = True 'Para la Grilla Inicial.

            Call CargaCombosDirecciones()

            Me.btnAgregar.Enabled = True
            Me.btnActualizar.Enabled = False

            Me.btnAgregarDireccion.Enabled = True
            Me.btnActualizarDireccion.Enabled = False

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

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
            If Acceso.SiRol(G_Rol, Me, 2) Then
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
                    MessageBox.Show("Ya existe un Contacto con Docto. Identidad: " & txtNumDoctoContacto.Text, "Seguridad Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch Qex As Exception

                    MessageBox.Show(Qex.Message, "Seguridad Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Try
            'Dim MyObligatorios() As Object = {Me.txtNumDoctoContacto, Me.txtNombrePCont, Me.txtApellidoPCont, Me.txtApellidoMCont, Me.lblSexoContacto, Me.rbtMasculino, Me.rbtFemenino}
            Dim MyObligatorios() As Object = {Me.txtNumDoctoContacto, Me.txtNombrePCont, Me.lblSexoContacto, Me.rbtMasculino, Me.rbtFemenino}
            If Funciones.Validaciones(MyObligatorios) = 0 Then
                Dim dgvr As DataGridViewRow = Me.dgvContactos.CurrentRow
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

                For Each MyObj As Object In TabPage1.Controls
                    If TypeOf MyObj Is TextBox Then
                        CType(MyObj, TextBox).Text = ""
                    End If
                Next
                dtComunicacionContac.Clear()

                Me.txtNumDoctoContacto.ReadOnly = False
                Me.txtNumDoctoContacto.BackColor = Color.White

            Else
                MessageBox.Show("Seleccione un contacto")
            End If

            Me.btnAgregar.Enabled = True
            Me.btnActualizar.Enabled = False

        Catch Pex As System.Data.ConstraintException
            MessageBox.Show("Ya existe un Contacto con Docto. Identidad: " & txtNumDoctoContacto.Text, "Seguridad Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad Del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub FrmClientes_MenuGrabar() Handles Me.MenuGrabar
        Try

            If vAccionRegistro = 1 Then 'Se trata de una Insercion.
                If cmbTipoPersona.SelectedValue = 1 Then '"JURIDICA"
                    'Dim MyObligatorios() As Object = {Me.txtRazonSocial, Me.txtRUC, Me.txtGG, Me.txtRepLegal, Me.cmbRubroEmpresarial, Me.btnRubroEmpresarial, Me.cmbClasPersona, Me.btnClasPersona, Me.txtFuncionarioCuenta, Me.btnFuncionarioCta, Me.txtRespFacturacion, Me.btnRespFactura, Me.cmbPais, Me.btnPais, Me.cmbDepartamento, Me.btnDepartamento, Me.cmbProvincia, Me.btnProvincia, Me.cmbDistrito, Me.btnDistrito}
                    Dim MyObligatorios() As Object = {Me.txtRazonSocial, Me.txtRUC, Me.txtGG, Me.txtRepLegal, Me.cmbRubroEmpresarial, Me.btnRubroEmpresarial, Me.cmbClasPersona, Me.btnClasPersona, Me.txtFuncionarioCuenta, Me.btnFuncionarioCta, Me.cmbPais, Me.btnPais, Me.cmbDepartamento, Me.btnDepartamento, Me.cmbProvincia, Me.btnProvincia, Me.cmbDistrito, Me.btnDistrito}
                    If Funciones.Validaciones(MyObligatorios) = 0 Then 'Si todo esta bien...
                        GrabaJuridica()
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
                    'Dim MyObligatorios() As Object = {Me.txtRazonSocial, Me.txtRUC, Me.txtGG, Me.txtRepLegal, Me.cmbRubroEmpresarial, Me.btnRubroEmpresarial, Me.cmbClasPersona, Me.btnClasPersona, Me.txtFuncionarioCuenta, Me.btnFuncionarioCta, Me.cmbPais, Me.btnPais, Me.cmbDepartamento, Me.btnDepartamento, Me.cmbProvincia, Me.btnProvincia, Me.cmbDistrito, Me.btnDistrito}
                    '
                    '05/11/2008
                    '
                    Dim MyObligatorios() As Object = {Me.txtRazonSocial, Me.txtRUC, Me.txtGG, Me.txtRepLegal, Me.cmbRubroEmpresarial, Me.btnRubroEmpresarial, Me.cmbClasPersona, Me.btnClasPersona, Me.btnFuncionarioCta, Me.cmbPais, Me.btnPais, Me.cmbDepartamento, Me.btnDepartamento, Me.cmbProvincia, Me.btnProvincia, Me.cmbDistrito, Me.btnDistrito}
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

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Private Sub CancelaIngreso2009_eliminarlo(ByVal CodigoCliente As String)
    '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_CANCELA_INS_PERSONA", 4, CodigoCliente, 2}
    '    VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Sub
    Private Sub FrmClientes_MenuCancelar() Handles Me.MenuCancelar
        Try
            MenuStrip1.Items(2).Text = "&Cancelar"
            If vAccionRegistro = 1 And Paso1 = 0 And Paso2 = 0 And Paso3 = 0 Then
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

            If vAccionRegistro = 1 And Paso1 = 1 And Paso2 = 0 And Paso3 = 0 Then
                'OBLIGAR A QUE INGRESE UN CONTACTO Y UNA DIRECCION
                Dim resp As DialogResult = MessageBox.Show("Tiene que ingresar al menos un Contacto y una Dirección," & vbCrLf & "¿Desea cancelar el Registro de este nuevo Cliente?", "Seguridad del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resp = Windows.Forms.DialogResult.Yes Then
                    'MessageBox.Show("Procedimiento de Eliminacion de Cliente y todos los foreing Keys")
                    If cmbTipoPersona.Text = "JURIDICA" Then
                        Call CancelaIngreso(Me.txtRUC.Text)
                        Paso1 = 0
                        Paso2 = 0
                        Paso3 = 0
                    ElseIf cmbTipoPersona.Text = "NATURAL" Then
                        Call CancelaIngreso(Me.txtNumeroDocto.Text)
                        Paso1 = 0
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
            End If

            If vAccionRegistro = 1 And Paso1 = 1 And Paso2 = 1 And Paso3 = 0 Then
                'OBLIGAR A QUE INGRESE UNA DIRECCION
                Dim resp As DialogResult = MessageBox.Show("Tiene que ingresar al menos una Dirección," & vbCrLf & "¿Desea cancelar el Registro de este nuevo Cliente?", "Seguridad del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resp = Windows.Forms.DialogResult.Yes Then
                    'MessageBox.Show("Procedimiento de Eliminacion de Cliente y todos los foreing Keys")
                    If cmbTipoPersona.Text = "JURIDICA" Then
                        Call CancelaIngreso(Me.txtRUC.Text)
                        Paso1 = 0
                        Paso2 = 0
                        Paso3 = 0
                    ElseIf cmbTipoPersona.Text = "NATURAL" Then
                        Call CancelaIngreso(Me.txtNumeroDocto.Text)
                        Paso1 = 0
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
            End If

            If vAccionRegistro = 1 And Paso1 = 1 And Paso2 = 1 And Paso3 = 1 Then
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

        Catch Qex As Exception
        End Try

    End Sub

    Private Sub FrmClientes_MenuEditar() Handles Me.MenuEditar
        Try
            If Me.DataGridLista.RowCount > 0 Then
                Dim dgvr As DataGridViewRow = Me.DataGridLista.CurrentRow()
                If Not dgvr Is Nothing Then
                    'MessageBox.Show("No esta nulo")
                    vAccionRegistro = 2

                    'dgvContactosActualiza.Visible = True
                    dgvContactos.Visible = True

                    'dgvActualizaTelefonosContacto.Visible = False
                    dgvTelefonosContacto.Visible = True

                    If CType(dgvr.Cells("JURIDICAONATURAL").Value, Integer) = 1 Then '"JURIDICA"
                        DeshabilitaControlesEdicion()

                        Me.cmbTipoPersona.SelectedValue = CType(dgvr.Cells("JURIDICAONATURAL").Value, Integer)
                        vIDPersona = CType(dgvr.Cells("ID").Value, Integer)
                        Me.txtCodigo.Text = CType(dgvr.Cells("CODIGO").Value, String)
                        Me.txtRazonSocial.Text = CType(dgvr.Cells("RAZONSOCIAL").Value, String)
                        Me.txtRUC.Text = CType(dgvr.Cells("DOCUMENTO").Value, String)
                        Me.txtGG.Text = CType(dgvr.Cells("GERENTE_GENERAL").Value, String)
                        Me.txtRepLegal.Text = CType(dgvr.Cells("REPRESENTANTE_LEGAL").Value, String)
                        If IsDBNull(dgvr.Cells("EMAIL").Value) Then
                            Me.txtWebSite.Text = ""
                        Else
                            Me.txtWebSite.Text = CType(dgvr.Cells("EMAIL").Value, String)
                        End If

                        Me.txtFechaRegistro._MyFecha = CType(dgvr.Cells("FECHA_INGRESO").Value, String)
                        Me.chkCorporativo.Checked = CType(dgvr.Cells("CLIENTE_CORPORATIVO").Value, Boolean)
                        If Me.chkCorporativo.Checked = False Then 'Tepsa si no es corporativo, va hacer contado 
                            If dgvr.Cells("CLIENTE_CORPORATIVO").Value <> 1 Then
                                Me.chkContadoCredito.Checked = True
                            ElseIf dgvr.Cells("CLIENTE_CORPORATIVO").Value = 1 Then
                                Me.chkCorporativo.Checked = True
                            End If
                        End If
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
                        'Como se Implemento al final, algunos clientes no tienen esta data  no es error de codigo sino conceptual.
                        Me.cmbTipoFacturacion.SelectedValue = CType(dgvr.Cells("IDTIPO_FACTURACION").Value, Integer)

                        If Len(Trim(txtFuncionarioCuenta.Text)) = 0 Then
                            txtFuncionarioCuenta.Text = "No Asignado..."
                        End If

                        If Len(Trim(txtRespFacturacion.Text)) = 0 Then
                            txtRespFacturacion.Text = "No Asignado..."
                        End If
                    End If

                    If CType(dgvr.Cells("JURIDICAONATURAL").Value, Integer) = 2 Then '"NATURAL" 
                        DeshabilitaControlesEdicion()
                        Me.cmbTipoPersona.SelectedValue = CType(dgvr.Cells("JURIDICAONATURAL").Value, Integer)
                        vIDPersona = CType(dgvr.Cells("ID").Value, Integer)
                        Me.txtCodigo.Text = CType(dgvr.Cells("CODIGO").Value, String)
                        Me.txtNombreP.Text = CType(dgvr.Cells("NOMPRE_PERSONA").Value, String)
                        If dgvr.Cells("NOMPRE_PERSONA1") Is Nothing Then
                            Me.txtNombreS.Text = CType(dgvr.Cells("NOMPRE_PERSONA1").Value, String)
                        Else
                            Me.txtNombreS.Text = ""
                        End If
                        Me.txtApellidoP.Text = CType(dgvr.Cells("APELLIDO_PATERNO").Value, String)
                        Me.txtApellidoM.Text = CType(dgvr.Cells("APELLIDO_MATERNO").Value, String)
                        Me.txtNumeroDocto.Text = CType(dgvr.Cells("DOCUMENTO").Value, String)
                        Me.txtFechaNacimiento._MyFecha = CType(dgvr.Cells("FECHA_NACIMIENTO").Value, String)
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
                    '
                    '27/08/2010  -  Crédito 
                    '
                    If IsDBNull(dgvr.Cells("TIPO_CREDITO").Value) = True Then
                        Me.cmb_tipo_cred_pasaje.SelectedIndex = 0
                    Else
                        Me.cmb_tipo_cred_pasaje.SelectedIndex = CType(dgvr.Cells("TIPO_CREDITO").Value, Integer)
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
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

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
                dvListaPersona.RowFilter = FiltroLista
            End If
        End If
    End Sub

    Private Sub rdbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbTodos.CheckedChanged
        If sender.checked = True Then
            If DataGridLista.Columns.Count > 0 Then
                DataGridLista.Columns(5).Visible = True
                DataGridLista.Columns(4).Visible = True
                Dim FiltroLista As String = ""
                dvListaPersona.RowFilter = FiltroLista
            End If
        End If
    End Sub

    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusqueda.TextChanged
        If rdbJuridicos.Checked = True Then
            Dim FiltroLista As String = "IDTIPO_PERSONA = 1 and RAZON_SOCIAL LIKE '%" & Me.txtBusqueda.Text & "%'"
            dvListaPersona.RowFilter = FiltroLista
        End If
        If rdbnaturales.Checked = True Then
            Dim FiltroLista As String = "IDTIPO_PERSONA = 2 and NOMNRES_APELLIDOS LIKE '%" & Me.txtBusqueda.Text & "%'"
            dvListaPersona.RowFilter = FiltroLista
        End If
        If rdbTodos.Checked = True Then
            Dim FiltroLista As String = "(IDTIPO_PERSONA = 1 or IDTIPO_PERSONA = 2) and CODIGO_CLIENTE LIKE '%" & Me.txtBusqueda.Text & "%'"
            dvListaPersona.RowFilter = FiltroLista
        End If
    End Sub

    Private Sub btnFuncionarioCta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFuncionarioCta.Click
        ' Creado por Tepsa chkCorporativo.Checked = True 
        'If txtFuncionarioCuenta.Text = "" Or txtFuncionarioCuenta.Text <> "No Asignado..." Or chkCorporativo.Checked = True Then
        Dim FrmBusFuncionario As FrmBusquedaFuncionariosPasajes = New FrmBusquedaFuncionariosPasajes
        FrmBusFuncionario.txtNombreFuncionario.Text = Me.txtFuncionarioCuenta.Text
        Dim resultado As DialogResult
        'resultado = FrmBusFuncionario.ShowDialog()

        Acceso.Asignar(FrmBusFuncionario, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = FrmBusFuncionario.ShowDialog()
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim FuncionarioNegocio As String = FrmBusFuncionario.NombreFuncionario
        CodFuncionarioNegocio = FrmBusFuncionario.CodigoFuncionario
        TipoFuncionarioNegocio = FrmBusFuncionario.TipoFuncionario
        Me.txtFuncionarioCuenta.Text = FuncionarioNegocio
        'ElseIf txtFuncionarioCuenta.Text = "No Asignado..." Then
        'MessageBox.Show("Para agilizar el ingreso no Asigne Funcionarios a Clientes Contado.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else
        'MessageBox.Show("Esta actualización realizala en el Modulo de Reasignacion de Funcionarios", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
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
        'Dim resultado As DialogResult = a.ShowDialog()

        Dim resultado As DialogResult
        Acceso.Asignar(a, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = a.ShowDialog()
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

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

    End Sub

    Private Sub btnDepartamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDepartamento.Click
        Dim Parametros() As String = {"Mantenimiento de Geográfico", "PKG_IVOPERSONA.SP_GRILLASUBICACION", "PKG_IVOPERSONA.SP_INSUPD_PAIS", "IDPAIS", "PAIS", "IDDEPARTAMENTO", "PAIS", "DEPARTAMENTO", "IDPROVINCIA", "PAIS", "DEPARTAMENTO", "PROVINCIA", "IDDISTRITO", "PAIS", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "ID PAIS", "NOMBRE DEL PAIS", "ID DEPARTAMENTO", "NOMBRE DEPARTAMENTO", "ID PROVINCIA", "NOMBRE PROVINCIA", "ID DISTRITO", "NOMBRE DISTRITO", "2", "MANT. PAISES", "MANT. DEPARTAMENTOS", "MANT. PROVINCIAS", "MANT. DISTRITOS"}

        Dim a As FrmDosCampos = New FrmDosCampos(Parametros)
        'Dim resultado As DialogResult = a.ShowDialog()

        Dim resultado As DialogResult
        Acceso.Asignar(a, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = a.ShowDialog()
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

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

    End Sub

    Private Sub btnProvincia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProvincia.Click
        Dim Parametros() As String = {"Mantenimiento de Geográfico", "PKG_IVOPERSONA.SP_GRILLASUBICACION", "PKG_IVOPERSONA.SP_INSUPD_PAIS", "IDPAIS", "PAIS", "IDDEPARTAMENTO", "PAIS", "DEPARTAMENTO", "IDPROVINCIA", "PAIS", "DEPARTAMENTO", "PROVINCIA", "IDDISTRITO", "PAIS", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "ID PAIS", "NOMBRE DEL PAIS", "ID DEPARTAMENTO", "NOMBRE DEPARTAMENTO", "ID PROVINCIA", "NOMBRE PROVINCIA", "ID DISTRITO", "NOMBRE DISTRITO", "3", "MANT. PAISES", "MANT. DEPARTAMENTOS", "MANT. PROVINCIAS", "MANT. DISTRITOS"}

        Dim a As FrmDosCampos = New FrmDosCampos(Parametros)
        'Dim resultado As DialogResult = a.ShowDialog()

        Dim resultado As DialogResult
        Acceso.Asignar(a, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = a.ShowDialog()
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

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
    End Sub

    Private Sub btnDistrito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDistrito.Click
        Dim Parametros() As String = {"Mantenimiento de Geográfico", "PKG_IVOPERSONA.SP_GRILLASUBICACION", "PKG_IVOPERSONA.SP_INSUPD_PAIS", "IDPAIS", "PAIS", "IDDEPARTAMENTO", "PAIS", "DEPARTAMENTO", "IDPROVINCIA", "PAIS", "DEPARTAMENTO", "PROVINCIA", "IDDISTRITO", "PAIS", "DEPARTAMENTO", "PROVINCIA", "DSITRITO", "ID PAIS", "NOMBRE DEL PAIS", "ID DEPARTAMENTO", "NOMBRE DEPARTAMENTO", "ID PROVINCIA", "NOMBRE PROVINCIA", "ID DISTRITO", "NOMBRE DISTRITO", "4", "MANT. PAISES", "MANT. DEPARTAMENTOS", "MANT. PROVINCIAS", "MANT. DISTRITOS"}
        Dim a As FrmDosCampos = New FrmDosCampos(Parametros)
        'Dim resultado As DialogResult = a.ShowDialog()

        Dim resultado As DialogResult
        Acceso.Asignar(a, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = a.ShowDialog()
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

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
                If Acceso.SiRol(G_Rol, Me, 3) Then
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
                Me.btnFuncionarioCta.Enabled = True 'Siempre debe ser activo 
                'Me.txtRespFacturacion.Text = "No Asignado..."
                '
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
                If Acceso.SiRol(G_Rol, Me, 4) Then
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
            Me.txtNumDoctoContacto.Text = CType(dgvr.Cells("NRODOCUMENTO").Value, String)
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

            Me.cmbAreaEmpresa.Enabled = True   'false Tepsa 22/11/2006 
            Me.cmbTipoContacto.Enabled = False
            Me.btnAreaEmpresa.Enabled = False
            Me.btnTipoContacto.Enabled = False

            Call CargarListaTelefonos(CType(dgvr.Cells("IDCONTACTO_PERSONA").Value, Long), Me.dgvTelefonosContacto)
            ContactoClass.sIDContactoPersona = CType(dgvr.Cells("IDCONTACTO_PERSONA").Value, Long)

            'End If
            Me.btnAgregar.Enabled = False
            Me.btnActualizar.Enabled = True

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

    Private Sub FrmClientes_MenuSalir() Handles Me.MenuSalir
        'SALDRA
        If vAccionRegistro = 0 And Paso1 = 0 And Paso2 = 0 And Paso3 = 0 Then
            Me.Close()
        End If

        If vAccionRegistro = 1 Then
            If Paso1 = 1 And Paso2 = 1 And Paso3 = 1 Then
                Me.Close()
            ElseIf Paso1 = 1 And Paso2 = 0 And Paso3 = 0 Then
                MessageBox.Show("Ingrese por lo menos un Contacto", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCodigoClienteContacto.Text = txtCodigo.Text
                txtNombreClienteContacto.Text = txtRazonSocial.Text
                SelectMenu(2)
            ElseIf Paso1 = 1 And Paso2 = 1 And Paso3 = 0 Then
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
                'Dim dtContactos As New DataTable
                'Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTA_CONTACTOS", 4, MyCodigoCliente, 2}
                'Try
                '    rstContactos = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
                '    daContactos.Fill(dtContactos, rstContactos)
                '    cmbContactoDireccion.DataSource = dtContactos.DefaultView
                '    cmbContactoDireccion.DisplayMember = "NOMBRE_APELLIDO"
                '    cmbContactoDireccion.ValueMember = "IDCONTACTO_PERSONA"
                'Catch Qex As Exception
                '    MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End Try
                Dim dtContactos As New DataTable
                Try
                    Dim obj As New dtoCLIENTES
                    dtContactos = obj.fn_LISTACONTACTO(MyCodigoCliente)
                    cmbContactoDireccion.DataSource = dtContactos.DefaultView
                    cmbContactoDireccion.DisplayMember = "NOMBRE_APELLIDO"
                    cmbContactoDireccion.ValueMember = "IDCONTACTO_PERSONA"
                Catch Qex As Exception
                    MessageBox.Show(Qex.Message, "Seguridad del SIstema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


            ElseIf Paso1 = 0 And Paso2 = 0 And Paso3 = 0 Then
                Me.Close()
            End If
        End If
        If vAccionRegistro = 2 Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCargarClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarClientes.Click
        Try
            If MyTreeView.Nodes(0).Checked = True Then
                'MessageBox.Show("Cargar Todos")
                DataGridLista.Columns.Clear()
                dvListaPersona = Funciones.CargarGrillaClientesPasajes(Me.DataGridLista)
                Dim FiltroLista As String = "IDTIPO_PERSONA ='" & 1 & "'"
                dvListaPersona.RowFilter = FiltroLista
                DataGridLista.Columns(4).Visible = True
                DataGridLista.Columns(5).Visible = False
                DataGridLista.Columns(40).Visible = False
                lb_principal = True
            ElseIf MyTreeView.Nodes(0).Checked = False Then
                'MessageBox.Show("Cargar por Funcionario")
                For i As Integer = 0 To MyTreeView.Nodes(0).Nodes.Count - 1
                    If MyTreeView.Nodes(0).Nodes(i).Checked = True Then
                        DataGridLista.Columns.Clear()
                        dvListaPersona = Funciones.CargarGrillaClientesPasajes(Me.DataGridLista, MyTreeView.Nodes(0).Nodes(i).Tag)
                        'Dim FiltroLista As String = "IDTIPO_PERSONA = 1 AND FUNCIONARIO ='" & MyTreeView.Nodes(0).Nodes(i).Text & "'"
                        'dvListaPersona.RowFilter = FiltroLista
                        DataGridLista.Columns(4).Visible = True
                        DataGridLista.Columns(5).Visible = False
                        DataGridLista.Columns(40).Visible = False
                    End If
                Next
                lb_principal = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MyTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles MyTreeView.AfterSelect
        For i As Integer = 0 To MyTreeView.Nodes(0).Nodes.Count - 1
            MyTreeView.Nodes(0).Nodes(i).Checked = False
        Next
        e.Node.Checked = True
    End Sub

    Private Sub txtRUC_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRUC.Leave
        If Me.txtCodigo.Visible = True Then
            Me.txtCodigo.Text = txtRUC.Text
        End If
    End Sub
    Private Sub txtRUC_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRUC.Validating
        Try
            If Len(Trim(txtRUC.Text)) <> 0 Then
                'Validando el  el 
                If fnValidarRUC(txtRUC.Text) = False Then
                    MessageBox.Show("RUC no válido por SUNAT", "CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtRUC.Text = ""
                    txtCodigo.Text = ""
                    txtRUC.Focus()
                    Exit Sub
                End If
                Dim Mybusqueda As DataTable
                Dim ldt_recupera_datos As New DataTable
                '
                Mybusqueda = BuscaCliente_datos(txtRUC.Text)
                ldt_recupera_datos = Mybusqueda
                recupera_datos(ldt_recupera_datos)
                'Se comenta en la busqueda - 04/11/2008
                'If Mybusqueda.Fields.Count > 0 Then
                '    If Mybusqueda.Fields.Item(0).Value = "EL CLIENTE YA EXISTE" Then
                '        MessageBox.Show(Mybusqueda.Fields.Item(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '        Call LimpiaPersona()
                '        Me.txtRazonSocial.Focus()
                '    End If
                'End If

                'datahelper
                'Dim Mybusqueda As ADODB.Recordset
                'Dim ldt_recupera_datos As New DataTable
                ''
                'Mybusqueda = BuscaCliente_datos(txtRUC.Text)
                'DataAdapterGenerics.Fill(ldt_recupera_datos, Mybusqueda)
                'recupera_datos(ldt_recupera_datos)
                ''Se comenta en la busqueda - 04/11/2008
                ''If Mybusqueda.Fields.Count > 0 Then
                ''    If Mybusqueda.Fields.Item(0).Value = "EL CLIENTE YA EXISTE" Then
                ''        MessageBox.Show(Mybusqueda.Fields.Item(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ''        Call LimpiaPersona()
                ''        Me.txtRazonSocial.Focus()
                ''    End If
                ''End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub txtNumeroDocto_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumeroDocto.Leave
        If Me.txtCodigo.Visible = True Then
            Me.txtCodigo.Text = txtNumeroDocto.Text
        End If
    End Sub

    Private Sub txtNumeroDocto_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNumeroDocto.Validating
        'datahelper
        'Dim Mybusqueda As ADODB.Recordset
        'Mybusqueda = BuscaCliente(txtNumeroDocto.Text)
        'If Mybusqueda.Fields.Count > 0 Then
        '    If Mybusqueda.Fields.Item(0).Value = "EL CLIENTE YA EXISTE" Then
        '        MessageBox.Show(Mybusqueda.Fields.Item(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Call LimpiaPersona()
        '        Me.txtNombreP.Focus()
        '    End If
        'End If
        Try
            Dim Mybusqueda As DataTable
            Mybusqueda = BuscarCliente(txtNumeroDocto.Text)
            If Mybusqueda.Rows.Count > 0 Then
                If Mybusqueda.Rows(0).Item(0).ToString = "EL CLIENTE YA EXISTE" Then
                    MessageBox.Show(Mybusqueda.Rows(0).Item(0).ToString, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Call LimpiaPersona()
                    Me.txtNombreP.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

        Dim resultado As DialogResult
        Acceso.Asignar(FrmNuevoRubro, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = FrmNuevoRubro.ShowDialog()
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If resultado = Windows.Forms.DialogResult.OK Then
            dtRubro.Clear()
            dtRubro = FrmNuevoRubro.NuevosRubros.Copy
            Dim ElIngresadoEs As Integer = FrmNuevoRubro.Ingresado
            dvRubro = Funciones.CargarCombo(cmbRubroEmpresarial, dtRubro, "RUBRO", "IDRUBRO", ElIngresadoEs)
        End If
    End Sub

    Private Sub btnClasPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClasPersona.Click
        Dim FrmNuevaClasificacion As FrmClasificacion_Cliente = New FrmClasificacion_Cliente
        'Dim resultado As DialogResult = FrmNuevaClasificacion.ShowDialog()

        Dim resultado As DialogResult
        Acceso.Asignar(FrmNuevaClasificacion, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = FrmNuevaClasificacion.ShowDialog()
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If resultado = Windows.Forms.DialogResult.OK Then
            dtClasPersona.Clear()
            dtClasPersona = FrmNuevaClasificacion.NuevosRubros.Copy
            Dim ElIngresadoEs As Integer = FrmNuevaClasificacion.Ingresado
            dvClasPersona = Funciones.CargarCombo(cmbClasPersona, dtClasPersona, "CLASIFICACION_PERSONA", "IDCLASIFICACION_PERSONA", ElIngresadoEs)
        End If
    End Sub

    Private Sub btnAreaEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAreaEmpresa.Click
        Dim FrmNuevaClasificacion As FrmSubCuenta_Cliente = New FrmSubCuenta_Cliente
        Dim resultado As DialogResult
        Acceso.Asignar(FrmNuevaClasificacion, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = FrmNuevaClasificacion.ShowDialog()
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If resultado = Windows.Forms.DialogResult.OK Then
            dtAreaEmpresa.Clear()
            dtAreaEmpresa = FrmNuevaClasificacion.NuevosRubros.Copy
            Dim ElIngresadoEs As Integer = FrmNuevaClasificacion.Ingresado
            dvAreaEmpresa = Funciones.CargarCombo(cmbAreaEmpresa, dtAreaEmpresa, "CENTRO_COSTO", "IDCENTRO_COSTO", ElIngresadoEs)
        End If
    End Sub

    Private Sub btnTipoContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipoContacto.Click
        Dim FrmNuevaClasificacion As FrmTipoContacto_Cliente = New FrmTipoContacto_Cliente
        Dim resultado As DialogResult
        Acceso.Asignar(FrmNuevaClasificacion, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = FrmNuevaClasificacion.ShowDialog()
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If resultado = Windows.Forms.DialogResult.OK Then
            dtTipoContacto.Clear()
            dtTipoContacto = FrmNuevaClasificacion.NuevosRubros.Copy
            Dim ElIngresadoEs As Integer = FrmNuevaClasificacion.Ingresado
            dvTipoContacto = Funciones.CargarCombo(cmbTipoContacto, dtTipoContacto, "TIPO_CONTACTO", "IDTIPO_CONTACTO", ElIngresadoEs)
        End If
    End Sub

    Private Sub btnTipoDireccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipoDireccion.Click
        Dim FrmNuevaClasificacion As FrmTipoDireccion_Cliente = New FrmTipoDireccion_Cliente
        Dim resultado As DialogResult
        Acceso.Asignar(FrmNuevaClasificacion, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = FrmNuevaClasificacion.ShowDialog()
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If resultado = Windows.Forms.DialogResult.OK Then
            dtTipoDireccion.Clear()
            dtTipoDireccion = FrmNuevaClasificacion.NuevosRubros.Copy
            Dim ElIngresadoEs As Integer = FrmNuevaClasificacion.Ingresado
            dvTipoDireccion = Funciones.CargarCombo(cmbTipoDireccion, dtTipoDireccion, "TIPO_DIRECCION", "IDTIPO_DIRECCION", ElIngresadoEs)
            dvTipoDireccion.RowFilter = "TIPO_DIRECCION<>'LEGAL'"
        End If
    End Sub

    Private Sub ActualizaContactoJuridico(ByVal Accion As Integer)
        If vAccionRegistro = 1 Then 'Si 

            'Dim ContactoClass As New dtoCONTACTO_CLIENTE

            With ContactoClass
                .Control = Accion 'vAccionRegistro
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

                'Dim ContactoClass As New dtoCONTACTO_CLIENTE

                With ContactoClass
                    .Control = Accion
                    '.IDContactoPersona = 1 'Momentaneamente pero cambiar en actualizaciones
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

            If vActualizaContacto = 1 Then 'No carga Datos en la Grilla de Contactos

                'Dim ContactoClass As New dtoCONTACTO_CLIENTE

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
                    MessageBox.Show(restContacto.Rows(0).Item(0).Value, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    AgregarTelefonosContacto(2)
                    Paso2 = 1
                ElseIf restContacto.Rows.Count = 2 And Len(Trim(restContacto.Rows(0).Item(0).ToString)) <= 6 Then 'Si se producjo algun error.
                    MessageBox.Show("Descripción: " & restContacto.Rows(0).Item(1).ToString, "ORACLE -> Error: " & restContacto.Rows(0).Item(0).ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If

    End Sub

    Private Sub CargaDirecciones(ByVal MyCodigoCliente As String, ByVal MyGrillaConData As DataGridView)
        Try
            'datahelper
            'Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_CARGA_DIRECCIONES", 4, MyCodigoCliente, 2}
            'Dim rstDireccionesCliente As ADODB.Recordset = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
            'Dim daDireccionesCliente As New OleDbDataAdapter

            'daDireccionesCliente.Fill(dtDireccionesCliente, rstDireccionesCliente)

            Dim obj As New dtoCLIENTES
            dtDireccionesCliente = obj.fn_carga_direcciones(MyCodigoCliente)
            Dim dvDireccionesCliente As DataView
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

            End If
            Me.btnAgregarDireccion.Enabled = False
            Me.btnActualizarDireccion.Enabled = True

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnActualizarDireccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnActualizarDireccion.Click
        Try
            If SeleccionoContacto() = 0 Then
                MessageBox.Show("Seleccione los Contactos de esta Dirección", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnSeleccionarContactos.PerformClick()
            ElseIf SeleccionoContacto() > 0 Then
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
                End If
            End If

            Me.btnAgregarDireccion.Enabled = True
            Me.btnActualizarDireccion.Enabled = False
            Me.chkDireccionFacturacion.Enabled = False
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

    Private Sub CargaContactosDirecciones()
        'datahelper
        'Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_LISTA_CONTACTOS", 4, Me.txtCodigoClienteContacto.Text, 2}
        'Dim rstContactos As ADODB.Recordset = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
        'Dim da As New OleDbDataAdapter
        'Dim dtContactosDirecciones As New DataTable
        'dtContactosDirecciones.Clear()
        'dgvContactosDirecciones.Columns.Clear()
        'da.Fill(dtContactosDirecciones, rstContactos)

        Dim dtContactosDirecciones As New DataTable
        dtContactosDirecciones.Clear()
        dgvContactosDirecciones.Columns.Clear()
        Dim obj As New dtoCLIENTES
        dtContactosDirecciones = obj.LISTA_CONTACTOS(Me.txtCodigoClienteContacto.Text)
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

    End Sub

    Private Sub btnSeleccionarContactos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionarContactos.Click
        If Me.dgvContactosDirecciones.Size.Height = 169 Then 'Cierra
            Me.dgvContactosDirecciones.Size = New Size(265, 20)
            btnSeleccionarContactos.Location = New Point(474, 220)
            btnAgregarDireccion.Enabled = True
            'btnActualizarDireccion.Enabled = True
            dgvDirecciones.Enabled = True
            dtpHoraEntregaInicio.Enabled = True
            dtpHoraEntregaFinal.Enabled = True
            dtpHoraRecojoInicio.Enabled = True
            dtpHoraRecojoFinal.Enabled = True
        ElseIf Me.dgvContactosDirecciones.Size.Height = 20 Then 'Abre
            Me.dgvContactosDirecciones.Size = New Size(463, 169)
            btnSeleccionarContactos.Location = New Point(673, 220)
            btnAgregarDireccion.Enabled = False
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
            If dgvContactosDirecciones.Rows(i).Cells("SELECCIONAR").Value = 1 Then
                cont += 1
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
        Dim resultado As DialogResult
        Acceso.Asignar(FrmNuevoDocumento, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = FrmNuevoDocumento.ShowDialog()
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If resultado = Windows.Forms.DialogResult.OK Then
            dtTipoDocPersona.Clear()
            dtTipoDocPersona = FrmNuevoDocumento.NuevosRubros.Copy
            Dim ElIngresadoEs As Integer = FrmNuevoDocumento.Ingresado
            dvTipoDocPersona = Funciones.CargarCombo(cmbTipoDoctoContacto, dtTipoDocPersona, "TIPO_DOC_IDENTIDAD", "IDTIPO_DOC_IDENTIDAD", ElIngresadoEs)
            dvTipoDocPersona = Funciones.CargarCombo(cmbTipoDocIdent, dtTipoDocPersona, "TIPO_DOC_IDENTIDAD", "IDTIPO_DOC_IDENTIDAD", ElIngresadoEs)
            'dvTipoDocPersona = Funciones.CargarCombo(cmbTipoDocIdent, dtTipoDocPersona, "TIPO_DOC_IDENTIDAD", "IDTIPO_DOC_IDENTIDAD", ElIngresadoEs)
        End If
    End Sub

    Private Sub btnPaisDirecciones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPaisDirecciones.Click
        Dim Parametros() As String = {"Mantenimiento de Geográfico", "PKG_IVOPERSONA.SP_GRILLASUBICACION", "PKG_IVOPERSONA.SP_INSUPD_PAIS", "IDPAIS", "PAIS", "IDDEPARTAMENTO", "PAIS", "DEPARTAMENTO", "IDPROVINCIA", "PAIS", "DEPARTAMENTO", "PROVINCIA", "IDDISTRITO", "PAIS", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "ID PAIS", "NOMBRE DEL PAIS", "ID DEPARTAMENTO", "NOMBRE DEPARTAMENTO", "ID PROVINCIA", "NOMBRE PROVINCIA", "ID DISTRITO", "NOMBRE DISTRITO", "1", "MANT. PAISES", "MANT. DEPARTAMENTOS", "MANT. PROVINCIAS", "MANT. DISTRITOS"}
        Dim a As FrmDosCampos = New FrmDosCampos(Parametros)
        Dim resultado As DialogResult
        Acceso.Asignar(a, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = a.ShowDialog()
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

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
    End Sub

    Private Sub btnDepartamentoDirecciones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDepartamentoDirecciones.Click
        Dim Parametros() As String = {"Mantenimiento de Geográfico", "PKG_IVOPERSONA.SP_GRILLASUBICACION", "PKG_IVOPERSONA.SP_INSUPD_PAIS", "IDPAIS", "PAIS", "IDDEPARTAMENTO", "PAIS", "DEPARTAMENTO", "IDPROVINCIA", "PAIS", "DEPARTAMENTO", "PROVINCIA", "IDDISTRITO", "PAIS", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "ID PAIS", "NOMBRE DEL PAIS", "ID DEPARTAMENTO", "NOMBRE DEPARTAMENTO", "ID PROVINCIA", "NOMBRE PROVINCIA", "ID DISTRITO", "NOMBRE DISTRITO", "2", "MANT. PAISES", "MANT. DEPARTAMENTOS", "MANT. PROVINCIAS", "MANT. DISTRITOS"}

        Dim a As FrmDosCampos = New FrmDosCampos(Parametros)
        Dim resultado As DialogResult

        Acceso.Asignar(a, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = a.ShowDialog()
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If


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
    End Sub

    Private Sub btnProvinciaDirecciones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProvinciaDirecciones.Click
        Dim Parametros() As String = {"Mantenimiento de Geográfico", "PKG_IVOPERSONA.SP_GRILLASUBICACION", "PKG_IVOPERSONA.SP_INSUPD_PAIS", "IDPAIS", "PAIS", "IDDEPARTAMENTO", "PAIS", "DEPARTAMENTO", "IDPROVINCIA", "PAIS", "DEPARTAMENTO", "PROVINCIA", "IDDISTRITO", "PAIS", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "ID PAIS", "NOMBRE DEL PAIS", "ID DEPARTAMENTO", "NOMBRE DEPARTAMENTO", "ID PROVINCIA", "NOMBRE PROVINCIA", "ID DISTRITO", "NOMBRE DISTRITO", "3", "MANT. PAISES", "MANT. DEPARTAMENTOS", "MANT. PROVINCIAS", "MANT. DISTRITOS"}

        Dim a As FrmDosCampos = New FrmDosCampos(Parametros)
        Dim resultado As DialogResult

        Acceso.Asignar(a, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = a.ShowDialog()
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If


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
    End Sub

    Private Sub btnDistritoDirecciones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDistritoDirecciones.Click
        Dim Parametros() As String = {"Mantenimiento de Geográfico", "PKG_IVOPERSONA.SP_GRILLASUBICACION", "PKG_IVOPERSONA.SP_INSUPD_PAIS", "IDPAIS", "PAIS", "IDDEPARTAMENTO", "PAIS", "DEPARTAMENTO", "IDPROVINCIA", "PAIS", "DEPARTAMENTO", "PROVINCIA", "IDDISTRITO", "PAIS", "DEPARTAMENTO", "PROVINCIA", "DSITRITO", "ID PAIS", "NOMBRE DEL PAIS", "ID DEPARTAMENTO", "NOMBRE DEPARTAMENTO", "ID PROVINCIA", "NOMBRE PROVINCIA", "ID DISTRITO", "NOMBRE DISTRITO", "4", "MANT. PAISES", "MANT. DEPARTAMENTOS", "MANT. PROVINCIAS", "MANT. DISTRITOS"}
        Dim a As FrmDosCampos = New FrmDosCampos(Parametros)
        Dim resultado As DialogResult

        Acceso.Asignar(a, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            resultado = a.ShowDialog()
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

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
            dvTipoDireccion.RowFilter = "TIPO_DIRECCION='LEGAL'"
            Me.btnTipoDireccion.Enabled = False
            Me.chkDireccionFacturacion.Enabled = False
        Else
            dvTipoDireccion.RowFilter = "TIPO_DIRECCION <>'LEGAL'"
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

    Private Sub dgvContactos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvContactos.CellContentClick

    End Sub
    Sub recupera_datos(ByVal as_data_table As DataTable)
        Dim ls_mensaje, ls_razon_social, ls_funcionario As String
        Dim lb_paso As Boolean
        Try '
            If as_data_table.Rows.Count = 0 Then ' No existe datos 
                Exit Sub
            End If
            '
            If IsDBNull(as_data_table.Rows(0).Item("funcionario")) = True Then  ' No encontro y no esta asociado a ningún funcionario deisponible
                lb_paso = False
            Else
                If as_data_table.Rows(0).Item("funcionario") = "" Then
                    lb_paso = False
                Else
                    ls_razon_social = as_data_table.Rows(0).Item("razon_social")
                    ls_funcionario = as_data_table.Rows(0).Item("funcionario")
                    ls_mensaje = "El cliente " + ls_razon_social + " está asociado al funcionario " + ls_funcionario
                    MessageBox.Show(ls_mensaje, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Call LimpiaPersona()
                    Me.txtRazonSocial.Focus()
                    Exit Sub
                End If
            End If
            If IsDBNull(as_data_table.Rows(0).Item("idpersona")) = True Then
                Exit Sub
            End If

            vIDPersona = CType(as_data_table.Rows(0).Item("idpersona"), Integer)
            Me.txtRazonSocial.Text = as_data_table.Rows(0).Item("razon_social")
            '
            If IsDBNull(as_data_table.Rows(0).Item("representante_legal")) = True Then
                Me.txtRepLegal.Text = "."
            Else
                Me.txtRepLegal.Text = as_data_table.Rows(0).Item("representante_legal")
            End If
            '
            If IsDBNull(as_data_table.Rows(0).Item("gerente_general")) = True Then
                Me.txtGG.Text = "."
            Else
                Me.txtGG.Text = as_data_table.Rows(0).Item("gerente_general")
            End If
            '
            If as_data_table.Rows(0).Item("cliente_corporativo") = 1 Then
                Me.chkCorporativo.Checked = True
                Me.chkContadoCredito.Checked = False
            Else
                Me.chkCorporativo.Checked = False
                Me.chkContadoCredito.Checked = True
            End If
            '
            If as_data_table.Rows(0).Item("post_facturacion") = 1 Then
                Me.chkPostFacturacion.Checked = True
            Else
                Me.chkPostFacturacion.Checked = False
            End If
            '
            If as_data_table.Rows(0).Item("agente_retencion") = 1 Then
                Me.chkAgenteRetencion.Checked = True
            Else
                Me.chkAgenteRetencion.Checked = False
            End If
            '
            Me.cmbRubroEmpresarial.SelectedValue = as_data_table.Rows(0).Item("rubro")
            Me.cmbClasPersona.SelectedValue = as_data_table.Rows(0).Item("idclasificacion_persona")
            Me.cmbTipoFacturacion.SelectedValue = as_data_table.Rows(0).Item("idtipo_facturacion")
            ' Recupera como si estuviera editado 
            vAccionRegistro = 2
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
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


            Dim obj As New dtoCLIENTES
            Dim ds As DataSet = obj.fn_GRILLA_TELEFONOS
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
        'Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTACONTACTO", 4, MyCodigoCliente, 2}
        Try
            dtContactos.Clear()
            'rstContactos = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
            'daContactos.Fill(dtContactos, rstContactos)
            dgvContactos.Columns.Clear()


            Dim obj As New dtoCLIENTES
            dtContactos = obj.fn_LISTACONTACTO(MyCodigoCliente)

            'With dgvContactosActualiza
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

            dgvContactos.Columns.AddRange(col1, col2, col3, col4, col5, col6, col7, col8, _
                                          col9, col10, col11, col12, col13, col14, col15)
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
        'Dim MyContactos As Object() = {"PKG_IVOPERSONA.SP_LISTATELEFONOCONTACTO", 4, IDContacto, 1}
        Try
            'rstTipoComunicacion = VOCONTROLUSUARIO.fnSQLQuery(MyContactos)
            'rstTelefonos = rstTipoComunicacion.NextRecordset
            'daTelefonos.Fill(dtTipoComunicacion, rstTipoComunicacion)
            'daTelefonos.Fill(dtTelefonos, rstTelefonos)

            Dim obj As New dtoCLIENTES
            Dim ds As DataSet = obj.fn_LISTATELEFONOCONTACTO(IDContacto)
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

    Private Sub CancelaIngreso(ByVal CodigoCliente As String)
        Try
            'Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_CANCELA_INS_PERSONA", 4, CodigoCliente, 2}
            'VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
            Dim obj As New dtoCLIENTES
            obj.CANCELA_INS_PERSONA(CodigoCliente)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub FrmClientesPasajes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged, GrabarToolStripMenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class

