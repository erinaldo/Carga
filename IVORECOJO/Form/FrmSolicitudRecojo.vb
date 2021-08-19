Public Class FrmSolicitudRecojo
#Region "Variables Declaradas"
    Public hnd As Long
    Dim vAccionRecojo As Integer
    Dim dsTipo As DataSet
    Dim ds As DataSet

    Public VarDireccion, VarContacto, VarDireccioncod, VarContactocod, Codigopersona As Integer
    Public bNuevo As Boolean
    Dim bsalir As Boolean = True
    Dim bInicio As Boolean = True
    Dim itipocomunicacion As Integer 'viene del otro formulario cte
    Dim apep, apem, nom As String
    Public itipodocumento As Integer 'viene del otro formulario cte
    Public iDocContacto As Integer 'variable del otro formualrio contacto
    Public departamento, provincia, distrito As Integer
    Public indocumento As String 'viene del otro formulario cte
    Public iApePaterno, iApeMaterno, iNombres As String
    Dim bIngreso As Boolean = False
#End Region

#Region "Funciones"
    Public ndocumento As String
    Public itipoDoc As Integer
    Public iComunicacion As Integer
    Public nrodocumento As String
    Public itipodocumentoCliente As String
    Dim nombre As String

    Public iddepartamento, idprovincia, iddistrito As Integer
    Public dtDireccion As New DataTable

    Dim intPerfil As Integer
    Dim intFuncionario As Integer = 0

    Sub FormatoDgvDestino()
        With dgvDestino
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            '.RowHeadersVisible = True
            .RowHeadersWidth = 30
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .HeaderText = "id"
                .Name = "id"
                .DataPropertyName = "id"
                .Visible = False
            End With

            Dim col_nombres As New DataGridViewTextBoxColumn
            With col_nombres
                .HeaderText = "Nombres"
                .Name = "nombres"
                .DataPropertyName = "nombres"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 350
            End With

            .Columns.AddRange(col_id, col_nombres)
        End With
    End Sub
    Sub Formato()
        With Me.DgvLista
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .AllowUserToResizeColumns = False
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            '.RowHeadersVisible = True
            .RowHeadersWidth = 20
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            '.ScrollBars = ScrollBars.Both
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black
            .ReadOnly = True 'readonly cuando este false se puede editar
            '.Focus()
            Dim fecha As New DataGridViewTextBoxColumn
            With fecha
                .HeaderText = "Fecha"
                .Name = "fecha"
                .DataPropertyName = "fecha"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Visible = True
                '.ReadOnly = True
            End With
            Dim cliente As New DataGridViewTextBoxColumn
            With cliente
                .HeaderText = "Cliente"
                .Name = ""
                .DataPropertyName = "cliente"
                '.SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 150
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            Dim id_recojo As New DataGridViewTextBoxColumn
            With id_recojo
                .HeaderText = "Nº"
                .Name = "id_recojo"
                .DataPropertyName = "id_recojo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            End With
            'agregar columna al grid
            Dim direccion As New DataGridViewTextBoxColumn
            With direccion
                .HeaderText = "Dirección"
                .Name = "direccion"
                .DataPropertyName = "direccion"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.Width = 150
            End With
            ' fin de agregado  
            'agregar columna al grid
            Dim Contacto As New DataGridViewTextBoxColumn
            With Contacto
                .HeaderText = "Contacto"
                .Name = ""
                .DataPropertyName = "contacto"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            Dim idtipodocumento As New DataGridViewTextBoxColumn
            With idtipodocumento
                .HeaderText = "idtipodocumento"
                .Name = ""
                .DataPropertyName = "idtipodocumento"
                .Visible = False
            End With
            ' fin de agregado  
            'agregar columna al grid
            Dim hlisto As New DataGridViewTextBoxColumn
            With hlisto
                .HeaderText = "Hora Listo"
                .Name = ""
                .DataPropertyName = "hora_listo"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Width = 60
            End With
            ' fin de agregado  
            'agregar columna al grid
            Dim hcierre As New DataGridViewTextBoxColumn
            With hcierre
                .HeaderText = "Hora Cierre"
                .Name = ""
                .DataPropertyName = "hora_cierre"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Width = 60
            End With
            ' fin de agregado  
            'agregar columna al grid
            Dim distrito As New DataGridViewTextBoxColumn
            With distrito
                .HeaderText = "Distrito"
                .Name = ""
                .DataPropertyName = "distrito"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.Width = 160
            End With
            ' fin de agregado  
            'agregar columna al grid
            Dim Estado As New DataGridViewTextBoxColumn
            With Estado
                .HeaderText = "Estado"
                .Name = ""
                .DataPropertyName = "estado"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.Width = 70
            End With

            Dim idEstado As New DataGridViewTextBoxColumn
            With idEstado
                .HeaderText = "id Estado"
                .Name = "id_estado"
                .DataPropertyName = "id_estado"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.Width = 70
                .Visible = False
            End With

            Dim solicitante As New DataGridViewTextBoxColumn
            With solicitante
                .HeaderText = "Solicitante"
                .Name = ""
                .DataPropertyName = "solicitante"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Width = 120
                .Visible = False
            End With
            Dim observacion As New DataGridViewTextBoxColumn
            With observacion
                .HeaderText = "Observacion"
                .Name = ""
                .DataPropertyName = "observacion"
                .Visible = False
            End With
            Dim id_ciudad_destino As New DataGridViewTextBoxColumn
            With id_ciudad_destino
                .HeaderText = "id_ciudad_destino"
                .Name = ""
                .DataPropertyName = "id_ciudad_destino"
                .Visible = False
            End With
            Dim cantidad As New DataGridViewTextBoxColumn
            With cantidad
                .HeaderText = "Cantidad"
                .Name = ""
                .DataPropertyName = "cantidad"
                .Visible = False
            End With
            Dim peso As New DataGridViewTextBoxColumn
            With peso
                .HeaderText = "Peso"
                .Name = ""
                .DataPropertyName = "peso"
                .Visible = False
            End With
            Dim volumen As New DataGridViewTextBoxColumn
            With volumen
                .HeaderText = "volumen"
                .Name = ""
                .DataPropertyName = "volumen"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .Visible = False
            End With
            Dim id_tipo_cliente As New DataGridViewTextBoxColumn
            With id_tipo_cliente
                .HeaderText = "id_tipo_cliente"
                .Name = "id_tipo_cliente"
                .DataPropertyName = "id_tipo_cliente"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .Visible = False
            End With
            Dim documento2 As New DataGridViewTextBoxColumn
            With documento2
                .HeaderText = "documento2"
                .Name = ""
                .DataPropertyName = "documento2"
                .Visible = False
            End With
            Dim iddepartamento As New DataGridViewTextBoxColumn
            With iddepartamento
                .HeaderText = "iddepartamento"
                .Name = ""
                .DataPropertyName = "iddepartamento"
                .Visible = False
            End With
            Dim idprovincia As New DataGridViewTextBoxColumn
            With idprovincia
                .HeaderText = "idprovincia"
                .Name = ""
                .DataPropertyName = "idprovincia"
                .Visible = False
            End With
            Dim iddistrito As New DataGridViewTextBoxColumn
            With iddistrito
                .HeaderText = "iddistrito"
                .Name = ""
                .DataPropertyName = "iddistrito"
                .Visible = False
            End With
            Dim idfijo As New DataGridViewTextBoxColumn
            With idfijo
                .HeaderText = "idfijo"
                .Name = ""
                .DataPropertyName = "idfijo"
                .Visible = False
            End With
            Dim idmovil As New DataGridViewTextBoxColumn
            With idmovil
                .HeaderText = "idmovil"
                .Name = ""
                .DataPropertyName = "idmovil"
                .Visible = False
            End With

            Dim usuario As New DataGridViewTextBoxColumn
            With usuario
                .HeaderText = "Usuario"
                .Name = "usuario"
                .DataPropertyName = "usuario"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.Width = 60
                '.Visible = False
            End With

            Dim idusuario As New DataGridViewTextBoxColumn
            With idusuario
                .HeaderText = "idusuario"
                .Name = "idusuario"
                .DataPropertyName = "idusuario"
                .Visible = False
            End With

            Dim producto As New DataGridViewTextBoxColumn
            With producto
                .HeaderText = "producto"
                .Name = "producto"
                .DataPropertyName = "producto"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .Visible = False
            End With

            Dim tipo_recojo As New DataGridViewTextBoxColumn
            With tipo_recojo
                .HeaderText = "Tipo Recojo"
                .Name = "tipo_recojo"
                .DataPropertyName = "tipo_recojo"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .Visible = True
            End With

            Dim url As New DataGridViewTextBoxColumn
            With url
                .HeaderText = "Url"
                .Name = "url"
                .DataPropertyName = "url"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .Visible = True
            End With

            Dim latitud As New DataGridViewTextBoxColumn
            With latitud
                .HeaderText = "Latitud"
                .Name = "latitud"
                .DataPropertyName = "latitud"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .Visible = True
            End With

            Dim longitud As New DataGridViewTextBoxColumn
            With longitud
                .HeaderText = "Longitud"
                .Name = "longitud"
                .DataPropertyName = "longitud"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .Visible = True
            End With

            Dim id_direccion As New DataGridViewTextBoxColumn
            With id_direccion
                .HeaderText = "id_direccion"
                .Name = "id_direccion"
                .DataPropertyName = "id_direccion"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .Visible = False
            End With

            ' fin de agregado  
            .Columns.AddRange(id_recojo, fecha, cliente, direccion, hlisto, hcierre, distrito, _
            Contacto, Estado, solicitante, observacion, id_ciudad_destino, cantidad, peso, volumen, _
            id_tipo_cliente, idtipodocumento, documento2, iddepartamento, idprovincia, _
            iddistrito, idfijo, idmovil, idEstado, usuario, idusuario, producto, tipo_recojo, url, latitud, longitud, id_direccion)
        End With
    End Sub
    Public iSaldoCtaCte As String
    Public iTipoCliente As Integer
    Public iIdContacto As Integer
    Public iIdDireccion As Integer
    'Dim razon As Integer
    Sub cargadatos_cliente(ByVal numero As String)
        Dim obj As New dtrecojo
        Dim ds As New DataSet
        ds = obj.listar_Cliente(numero, dtoUSUARIOS.m_idciudad)
        If IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
            txtnom.Text = ""
            txtemail.Text = ""
            txtdir.Text = ""
            txtref.Text = ""
            txtdepar.Text = ""
            txtpro.Text = ""
            txtdist.Text = ""
            Me.txttel.Text = ""
            Me.itipoDoc = 0
            TxtCliente.Text = ""
            Me.lblFuncionario.Text = ""
        Else
            Me.Codigopersona = ds.Tables(0).Rows(0).Item("idpersona").ToString
            Me.TxtNumero.Text = ds.Tables(0).Rows(0).Item("nu_docu_suna").ToString.Trim
            Me.TxtCliente.Text = ds.Tables(0).Rows(0).Item("razon_social")
            Me.itipodocumentoCliente = ds.Tables(0).Rows(0).Item("idtipo_doc_identidad").ToString
            Me.iSaldoCtaCte = ds.Tables(0).Rows(0).Item("credito").ToString
            Me.iTipoCliente = ds.Tables(0).Rows(0).Item("tipo_cliente")
            Me.lblFuncionario.Text = ds.Tables(0).Rows(0).Item("funcionario")
            If ds.Tables(1).Rows.Count > 0 Then
                Me.itipoDoc = ds.Tables(1).Rows(0).Item("idtipo_documento_contacto").ToString
            End If

            If ds.Tables(1).Rows.Count = 0 Then
                txtnom.Text = ""
                txtemail.Text = ""
                nrodocumento = ""
                iIdContacto = 0
            Else
                Me.txtnom.Text = ds.Tables(1).Rows(0).Item("Nombres").ToString.Trim
                Me.txtemail.Text = ds.Tables(1).Rows(0).Item("email").ToString.Trim
                Me.nrodocumento = ds.Tables(1).Rows(0).Item("nrodocumento").ToString.Trim
                Me.iIdContacto = ds.Tables(1).Rows(0).Item("idcontacto_persona").ToString.Trim
            End If

            dtDireccion = ds.Tables(3)
            If ds.Tables(3).Rows.Count > 0 Then
                Me.iIdDireccion = ds.Tables(3).Rows(0).Item("iddireccion_consignado").ToString.Trim
                Me.txtdir.Text = ds.Tables(3).Rows(0).Item("direccion").ToString.Trim
                Me.txtref.Text = ds.Tables(3).Rows(0).Item("referencia").ToString.Trim
                Me.txtdepar.Text = ds.Tables(3).Rows(0).Item("departamento").ToString.Trim
                Me.txtdepar.Tag = ds.Tables(3).Rows(0).Item("iddepartamento").ToString.Trim
                Me.txtpro.Tag = ds.Tables(3).Rows(0).Item("idprovincia").ToString.Trim
                Me.txtpro.Text = ds.Tables(3).Rows(0).Item("provincia").ToString.Trim
                Me.txtdist.Text = ds.Tables(3).Rows(0).Item("distrito").ToString.Trim
                Me.txtdist.Tag = ds.Tables(3).Rows(0).Item("iddistrito").ToString.Trim
            End If

            If ds.Tables(2).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(2).Rows(0).Item(0)) Then
                    Me.txttel.Text = ds.Tables(2).Rows(0).Item("fijo").ToString.Trim
                    codcomunicacion_t = ds.Tables(2).Rows(0).Item("idcomunicacion_contacto").ToString.Trim
                Else
                    Me.txttel.Text = ""
                    codcomunicacion_t = 0
                End If
            Else
                Me.txttel.Text = ""
                codcomunicacion_t = 0
            End If

            If ds.Tables(5).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(5).Rows(0).Item(0)) Then
                    Me.txtmovil.Text = ds.Tables(5).Rows(0).Item("movil").ToString.Trim
                    codcomunicacion_m = ds.Tables(5).Rows(0).Item("idcomunicacion_contacto").ToString.Trim
                    Me.iComunicacion = ds.Tables(5).Rows(0).Item("tipo").ToString.Trim
                Else
                    Me.txtmovil.Text = ""
                    codcomunicacion_m = 0
                    Me.iComunicacion = 0
                End If
            Else
                Me.txtmovil.Text = ""
                codcomunicacion_m = 0
                Me.iComunicacion = 0
            End If
        End If
    End Sub
    'Sub lista_item(ByVal cliente As Integer)
    '    Try
    '        Dim obj As New dtrecojo
    '        Dim ds As DataSet = obj.Lista_Item(cliente)
    '        Me.txtitem.Text = ds.Tables(0).Rows(0).Item(0)
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try
    'End Sub
    Public Function ValidarNumero(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        're = New System.Text.RegularExpressions.Regex("[A-ZñÑa-z0-9\b]") '("^\d+$")
        re = New System.Text.RegularExpressions.Regex("[0-9\b]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            ValidarNumero = True
        Else
            ValidarNumero = False
        End If
    End Function
    Public Function Validarcliente(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[Pp0-9\b]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            Validarcliente = True
        Else
            Validarcliente = False
        End If
    End Function
    Public Function ValidarReal(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[0-9.\b]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            ValidarReal = True
        Else
            ValidarReal = False
        End If
    End Function
    Public Function ValidarBorrar(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[\b]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            ValidarBorrar = True
        Else
            ValidarBorrar = False
        End If
    End Function
    Public Function ValidarLimpiar(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[\b]")
        If re.IsMatch(txtStr.ToString()) Then
            ValidarLimpiar = True
        Else
            ValidarLimpiar = False
        End If
    End Function
    Sub Limpiarrecojo()
        For Each obj As Control In Me.Grpcliente.Controls
            If TypeOf obj Is TextBox Or TypeOf obj Is ComboBox Then
                obj.Text = ""
            End If
        Next
        For Each obj As Control In Me.grpcontacto.Controls()
            If TypeOf obj Is TextBox Or TypeOf obj Is ComboBox Then
                obj.Text = ""
            End If
        Next
        For Each obj As Control In Me.grpdatos.Controls
            If TypeOf obj Is TextBox Or TypeOf obj Is ComboBox Then
                obj.Text = ""
            End If
        Next
        For Each obj As Control In Me.grpdireccion.Controls
            If TypeOf obj Is TextBox Or TypeOf obj Is ComboBox Then
                obj.Text = ""
            End If
        Next
        lblfecha.Text = Date.Now.ToShortDateString
        TxtNumero.Enabled = True
        DtpHora1.Value = DateTime.Now
        DtpHora2.Value = DateTime.Now
        Me.TxtNumero.Focus()
        Tsbeditar.Enabled = False
        Tsbanular.Enabled = False
        Tsbactualizar.Enabled = False
        tsbGeocodificar.Enabled = False
        TSBGrabar.Enabled = True
        BtnCliente.Enabled = True
        Me.BtnContacto.Enabled = False
        Me.BtnDireccion.Enabled = False
        Me.lblFuncionario.Text = ""
        Me.LblSobregiro.Text = ""
        For Each obj As Control In Me.grpnom.Controls
            If TypeOf obj Is TextBox Or TypeOf obj Is ComboBox Then
                obj.Text = ""
            End If
        Next
        For Each obj As Control In Me.GrpEnvio.Controls
            If TypeOf obj Is TextBox Or TypeOf obj Is ComboBox Then
                obj.Text = ""
            End If
        Next
        txtPeso.Text = ""
        itipocomunicacion = 0
        apep = ""
        apem = ""
        nom = ""
        itipodocumento = 0
        itipoDoc = 0
        itipoCliente = 0
        iDocContacto = 0
        departamento = 0
        provincia = 0
        distrito = 0
        indocumento = ""
        iApePaterno = ""
        iApeMaterno = ""
        iNombres = ""
        DtpHora1.Value = DateTime.Now
        DtpHora2.Value = DateTime.Now
        CboDestino.SelectedValue = 0
        VarContactocod = 0
        VarDireccioncod = 0
        codcomunicacion_t = 0
        codcomunicacion_m = 0
        txtdepar.Tag = 0
        txtpro.Tag = 0
        txtdist.Tag = 0
        'hlamas 01-01-2018
        cboProducto.SelectedValue = 0
        cboProducto.Enabled = False

        Codigopersona = 0
        Me.TxtNumero.Enabled = True
        iddepartamento = 0
        idprovincia = 0
        iddistrito = 0
        txtitem.Text = ""
        Me.LblSobregiro.Text = ""
        Me.LblSobregiro.Visible = False
        Me.dgvDestino.Rows.Clear()

        Me.cboTipoCliente.Enabled = False
        Me.cboTipoCliente.SelectedIndex = 0

        Me.cboProducto.Enabled=False
        Me.cboProducto.SelectedValue = 0

        Me.DtpFecha.Enabled = True
        Me.DtpFecha.Value = FechaServidor()
    End Sub
    Sub filtradir()
        Try
            Dim obj As New dtrecojo
            Dim busdir As String = Me.txtdir.Text
            Dim ds As DataSet = obj.busca_dir(busdir)
            VarDireccion = ds.Tables(0).Rows(0)(0).ToString()
            obj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Sub filtracontacto()
    '    Try
    '        Dim obj As New dtrecojo
    '        Dim contactnom As String = Me.txtnom.Text
    '        Dim ds As DataSet = obj.ListarContactonom(contactnom, 0)
    '        VarContacto = ds.Tables(0).Rows(0)(0).ToString()
    '        obj = Nothing
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    Sub filtracoddir(ByVal VarDireccioncod As Integer)
        Try
            Dim obj As New dtrecojo
            Dim codigo As Integer = Me.Codigopersona
            Dim ds As DataSet = obj.busca_dirxcod(codigo)
            VarDireccioncod = ds.Tables(0).Rows(0)(0).ToString()
            obj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub filtracodcontacto(ByVal VarContactocod As Integer)
        Try
            Dim obj As New dtrecojo
            Dim codigo As Integer = Me.Codigopersona
            Dim ds As DataSet = obj.busca_contxcod(codigo)
            VarContactocod = ds.Tables(0).Rows(0)(0).ToString()
            obj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
    Private Sub BtnContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnContacto.Click
        If Me.TxtNumero.Text.Trim.Length = 0 Then
            BtnContacto.Enabled = False
            TxtNumero.Focus()
        Else
            'Me.Cursor = Cursors.AppStarting
            Me.cargacontactos()
            'Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub BtnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCliente.Click
        Try
            Me.Cursor = Cursors.AppStarting
            Me.cargaclientes()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBCalaculadora.Click
        Dim frm As New FrmCalculadora
        frm.Show()
    End Sub
    Private Sub FrmSolicitudRecojo_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.TxtNumero.Focus()
        bInicio = False
    End Sub

    Private Sub FrmSolicitudRecojo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmSolicitudRecojo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not bsalir Then
            bsalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmSolicitudRecojo_ImeModeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ImeModeChanged

    End Sub
    Private Sub FrmSolicitudRecojo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub DtpInicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInicio.ValueChanged, dtpFin.ValueChanged
    End Sub
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbSalir.Click
        Me.Close()
    End Sub

    Private Sub TxtNumero_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNumero.Enter
        Me.TxtNumero.SelectAll()
    End Sub
    Private Sub TxtNumero_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNumero.GotFocus
        TxtNumero.SelectAll()
    End Sub

    Function ClienteExiste(ByVal cliente As String) As Boolean
        Try
            Dim obj As New dtrecojo
            Dim ds As DataSet = obj.Listar_cli(cliente, 0, intFuncionario)
            Return IIf(ds.Tables(0).Rows.Count = 0, False, True)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Sub BuscaCliente(ByVal numero As String)
        bNuevo = True
        TxtNumero.Tag = numero
        Dim frm As New FrmCliente

        Dim sCli As String = numero
        If sCli.Trim.Length > 0 Then
            Me.Cursor = Cursors.AppStarting
            If Not Me.ClienteExiste(sCli) Then
                Me.Cursor = Cursors.Default
                MessageBox.Show("El Cliente no Existe", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Me.Cursor = Cursors.AppStarting
                'Me.cargaclientes()
                'Me.Cursor = Cursors.Default
            Else
                BtnCliente.Enabled = False
                BtnContacto.Enabled = True
                BtnDireccion.Enabled = True
                cargadatos_cliente(sCli)
                'hlamas 01-01-2018
                Me.cboTipoCliente.Enabled = False
                Me.cboProducto.Enabled = False
                If iSaldoCtaCte = -1 Then 'cliente contado
                    Me.cboTipoCliente.SelectedIndex = 1
                Else 'cliente credito
                    If iTipoCliente = 0 Then '
                        Me.cboTipoCliente.SelectedIndex = 2
                    Else
                        Me.cboTipoCliente.SelectedIndex = 2
                        Me.cboTipoCliente.Enabled = True
                    End If
                End If
                Me.ListarProducto()

                'If iTipoCliente = 0 Then
                '    Me.ds.Tables(1).DefaultView.RowFilter = ""
                '    If iSaldoCtaCte <> -1 Then
                '        iTipoCliente = TipoCliente.CREDITO
                '        If iSaldoCtaCte < 0 Then   'cliente credito con sobregiro
                '            Me.LblSobregiro.Text = "Cliente con Sobregiro de S/. " & Format(Math.Abs(CDbl(iSaldoCtaCte.ToString)), "###,###,###0.00")
                '            Me.LblSobregiro.Visible = True
                '        End If
                '    ElseIf 1 = 1 Then
                '        iTipoCliente = TipoCliente.ENCOMIENDA
                '        Dim sFiltro As String = "idprocesos=" & TipoCliente.ACOMPAÑADA & " or idprocesos=" & TipoCliente.COURIER & " or idprocesos=" & TipoCliente.SOBRE & " or idprocesos=" & TipoCliente.TEPSABOX & "or idprocesos=" & TipoCliente.ENCOMIENDA
                '        Me.ds.Tables(1).DefaultView.RowFilter = sFiltro
                '        'hlamas 01-01-2018
                '        Me.cboProducto.Enabled = True
                '    End If
                'Else
                '    Me.ds.Tables(1).DefaultView.RowFilter = ""
                'End If
                'hlamas 01-01-2018
                'Me.cboProducto.SelectedValue = iTipoCliente
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub
    Private Sub TxtNumero_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumero.KeyPress
        Try
            If e.KeyChar = Chr(Keys.Enter) Then
                Me.BuscaCliente(Me.TxtNumero.Text)
            Else
                If Not ValidarNumero(e.KeyChar) Then
                    e.Handled = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TxtCliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCliente.GotFocus
        Me.TxtCliente.SelectAll()
    End Sub
    Private Sub TxtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCliente.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.BtnContacto.Focus()
        End If
    End Sub
    Private Sub txtnom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnom.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.txtnom.Focus()
        End If
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbNuevo.Click
        bNuevo = True
        Me.TabRecojo.SelectedIndex = 1
        Limpiarrecojo()
        Me.TxtNumero.Focus()
    End Sub
    Sub Graba_Proceso()
        Dim nrodocumento As String = indocumento
        Dim tipoComunicacion As Integer = itipocomunicacion
        Dim DocContacto As Integer = iDocContacto
        Dim hora1, hora2 As String
        'hlamas 09-05-2019
        'hora1 = DtpHora1.Text.Substring(0, 5) & IIf(DtpHora1.Text.Substring(6, 1).ToUpper = "A", " am", " pm")
        'hora2 = DtpHora2.Text.Substring(0, 5) & IIf(DtpHora2.Text.Substring(6, 1).ToUpper = "A", " am", " pm")
        hora1 = Me.DtpHora1.Text.Substring(0, 5)
        hora2 = Me.DtpHora2.Text.Substring(0, 5)
        Try
            Dim obj As New dtgrabarecojo
            obj.idtipo_persona = IIf(itipodocumento = 1, 1, 2)
            obj.razon_social = Me.TxtCliente.Text
            obj.apellido_paterno = iApePaterno
            obj.apellido_materno = iApeMaterno
            obj.nombre = nom
            obj.tipo_doc_identidad = itipodocumento
            obj.nu_docu_suna = Me.TxtNumero.Text

            obj.nombres = Me.txtnom.Text
            obj.idtipo_documento_contacto = DocContacto
            obj.nrodocumento = nrodocumento
            obj.email_contacto = Me.txtemail.Text

            obj.nrocomunicacion_contacto_t = Me.txttel.Text
            obj.idtipo_comunicacion_t = 1

            obj.nrocomunicacion_contacto_m = Me.txtmovil.Text
            obj.idtipo_comunicacion_m = tipoComunicacion

            obj.direccion = Me.txtdir.Text
            obj.referencia = Me.txtref.Text
            obj.idpais = 4
            obj.iddepartamento = iddepartamento
            obj.idprovincia = idprovincia
            obj.iddistrito = iddistrito

            obj.solicitante = Me.TxtSolicitante.Text
            obj.fecha = DtpFecha.Text 'Me.lblfecha.Text
            obj.fecharecojo = DtpFecha.Text
            'obj.item = Val(txtitem.Text)
            obj.hora_listo = hora1
            obj.hora_cierre = hora2
            obj.observacion = Me.TxtObservacion.Text
            obj.tipo_recojo = 1
            'hlamas 01-01-2018
            obj.id_tipo_cliente = Me.cboTipoCliente.SelectedIndex
            obj.Producto = Me.cboProducto.SelectedValue
            'obj.id_ciudad_destino = Me.CboDestino.SelectedValue

            obj.Bultos = Me.txtBultos.Text
            If Val(txtPeso.Text) = 0 Then
                obj.Peso = 0
            Else
                obj.Peso = CType(Me.txtPeso.Text, Double)
            End If
            If Val(txtVolumen.Text) = 0 Then
                obj.Volumen = 0
            Else
                obj.Volumen = CType(Me.txtVolumen.Text, Double)
            End If

            obj.Agencia = dtoUSUARIOS.iIDAGENCIAS
            obj.Ciudad = dtoUSUARIOS.m_idciudad
            obj.Usuario = dtoUSUARIOS.IdLogin
            obj.Ip = dtoUSUARIOS.IP '"192.168.50.52"

            Dim dt As DataTable = obj.Fn_Grabar()
            Me.txtitem.Text = dt.Rows(0).Item(0).ToString
            Me.txtitem.Refresh()
            'MessageBox.Show("Recojo Actualizado.", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)

            '-----------------------------------------------------------------------------------------
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TSBGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBGrabar.Click
        Try
            'If Me.LblSobregiro.Visible Then
            'MessageBox.Show("El Cliente tiene un Saldo Deudor." & Chr(13) & "No Podrá Solicitar el Servicio de Recojo de Carga.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'TxtNumero.Focus()
            'Return
            'End If

            If Me.TxtNumero.Text.Trim.Length > 0 AndAlso Me.TxtCliente.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nº de Documento Válido.", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtNumero.Focus()
                Return
            End If
            If Me.TxtCliente.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nº de Documento.", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtNumero.Focus()
                Return
            End If

            If Me.cboProducto.SelectedIndex = 0 Then
                MessageBox.Show("Seleccione el Producto", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtNumero.Focus()
                Return
            End If

            If Me.txtnom.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nombres del Contacto.", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.BtnContacto.Focus()
                Return
            End If

            If Me.txttel.Text.Trim.Length = 0 And Me.txtmovil.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese un Nº de Teléfono Fijo o Movil.", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.BtnContacto.Focus()
                Return
            End If

            If Me.txttel.Text.Trim.Length > 0 Then
                If Me.txttel.Text.Trim.Length < 6 Then
                    MessageBox.Show("Ingrese Nº Teléfono Fijo Válido.", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.BtnContacto.Focus()
                    Return
                End If
            End If

            If Me.txtmovil.Text.Trim.Length > 0 Then
                If Me.txtmovil.Text.Trim.Length < 9 Then
                    MessageBox.Show("Ingrese Nº Teléfono Móvil Válido.", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bsalir = False
                    Me.txtmovil.Focus()
                    Return
                End If
                If Val(Me.txtmovil.Text.Trim.Substring(0, 1)) < 2 Then
                    MessageBox.Show("Ingrese Nº Teléfono Móvil Válido.", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bsalir = False
                    Me.txtmovil.Focus()
                    Return
                End If
            End If

            If Me.txtemail.Text.Trim.Length > 0 Then
                If Not ValidarEMail(Me.txtemail.Text.Trim) Then
                    MessageBox.Show("Ingrese Email Válido.", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.BtnContacto.Focus()
                    Return
                End If
            End If

            If Me.txtdir.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Dirección de Recojo.", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.BtnDireccion.Focus()
                Return
            End If

            'hlamas 24-01-2020
            If dtDireccion.Rows.Count > 0 Then
                If dtDireccion.Rows(0).Item("url").ToString.Trim.Length = 0 Then
                    MessageBox.Show("Ubique la dirección en Google Maps", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.BtnDireccion.Focus()
                    Return
                End If
            End If

            If Convert.ToDateTime(DtpHora2.Text) <= Convert.ToDateTime(DtpHora1.Text) Then
                MessageBox.Show("La Hora Listo debe ser menor a la Hora Cierre.", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DtpHora1.Focus()
                Return
            End If

            Dim iTiempo As Integer = dtrecojo.TiempoListoCierre
            Dim tTiempo As TimeSpan = Convert.ToDateTime(Me.DtpHora2.Text) - Convert.ToDateTime(Me.DtpHora1.Text)
            Dim iDiferencia As Integer = tTiempo.Minutes + (tTiempo.Hours * 60)

            If iDiferencia < iTiempo Then
                MessageBox.Show("La Diferencia entre la Hora Listo y Cierre " & vbCrLf & "Debe ser Mayor o Igual a " & iTiempo & " Minutos.", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DtpHora1.Focus()
                Return
            End If

            'If CboDestino.SelectedValue = 0 Then
            '    MessageBox.Show("Seleccione Ciudad de Envío de la Carga.", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    CboDestino.Focus()
            '    Return
            'End If
            If Val(txtPeso.Text) = 0 And Val(txtVolumen.Text) = 0 Then
                If Val(txtPeso.Text) = 0 Then
                    MessageBox.Show("Ingrese Peso de la Carga.", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtPeso.Focus()
                    Return
                End If
            End If

            If Val(txtBultos.Text) = 0 Then
                MessageBox.Show("Ingrese Nº de Bultos.", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtBultos.Focus()
                Return
            End If

            If DtpFecha.Value.Date < Date.Now.Today Then
                MessageBox.Show("La fecha de recojo debe ser mayor o igual a al fecha actual.", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DtpFecha.Focus()
                Return
            End If

            Me.Cursor = Cursors.AppStarting
            Dim obj As New dtrecojo
            Dim ds As DataSet = obj.Listar_cli(Me.TxtNumero.Text)
            Dim razon As String = ds.Tables(0).Rows.Count
            If razon = 0 Then
                Graba_Proceso()
            Else
                Graba_Existente()
            End If

            'Graba destinos
            Dim obj1 As New dtgrabarecojo
            Dim intOpcion As Integer = 0
            For Each row As DataGridViewRow In Me.dgvDestino.Rows
                obj1.GrabarDestino(Me.txtitem.Text, row.Cells("id").Value, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, intOpcion)
                intOpcion = 1
            Next

            Limpiarrecojo()
            Me.mostrarDatos()
            Me.TxtNumero.Focus()

            Me.TabRecojo.SelectedIndex = 0
            Me.btnConsultar.Focus()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public codcomunicacion_t, codcomunicacion_m As Integer
    Sub Graba_Existente()
        Dim tipo As Integer = itipocomunicacion
        Dim hora1, hora2 As String
        Dim iModificado As Integer = 0
        'hlamas 09-05-2019
        'hora1 = DtpHora1.Text.Substring(0, 5) & IIf(DtpHora1.Text.Substring(6, 1).ToUpper = "A", " am", " pm")
        'hora2 = DtpHora2.Text.Substring(0, 5) & IIf(DtpHora2.Text.Substring(6, 1).ToUpper = "A", " am", " pm")
        hora1 = Me.DtpHora1.Text.Substring(0, 5)
        hora2 = Me.DtpHora2.Text.Substring(0, 5)
        Try
            Dim obj As New dtgrabarecojo
            obj.idpersona_p = Codigopersona
            obj.idcontacto_persona_c = iIdContacto
            obj.nombres = txtnom.Text
            obj.idtipo_documento_contacto = itipoDoc
            obj.nrodocumento = indocumento
            obj.email_contacto = Me.txtemail.Text

            obj.idcomunicacion_contacto_t = codcomunicacion_t
            obj.nrocomunicacion_contacto_t = Me.txttel.Text
            obj.idtipo_comunicacion_t = 1

            obj.idcomunicacion_contacto_m = codcomunicacion_m
            obj.nrocomunicacion_contacto_m = Me.txtmovil.Text
            obj.idtipo_comunicacion_m = iComunicacion

            obj.iddireccio_consignado_d = iIdDireccion
            obj.direccion = Me.txtdir.Text
            obj.referencia = Me.txtref.Text
            obj.idpais = 4
            obj.iddepartamento = IIf((departamento = 0), txtdepar.Tag, departamento)
            obj.idprovincia = IIf((provincia = 0), txtpro.Tag, provincia)
            obj.iddistrito = IIf((distrito = 0), txtdist.Tag, distrito)

            obj.IdVia = dtDireccion.Rows(0).Item("id_via")
            obj.Via = "" & dtDireccion.Rows(0).Item("via").ToString.Trim
            obj.IdNivel = dtDireccion.Rows(0).Item("id_nivel")
            obj.Nivel = "" & dtDireccion.Rows(0).Item("nivel")
            obj.IdZona = dtDireccion.Rows(0).Item("id_zona")
            obj.Zona = "" & dtDireccion.Rows(0).Item("zona").ToString.Trim
            obj.IdClasificacion = dtDireccion.Rows(0).Item("id_clasificacion")
            obj.Clasificacion = "" & dtDireccion.Rows(0).Item("clasificacion")

            obj.Numero = "" & dtDireccion.Rows(0).Item("numero")
            obj.Manzana = "" & dtDireccion.Rows(0).Item("manzana")
            obj.Lote = "" & dtDireccion.Rows(0).Item("lote")

            'hlamas 24-01-2020
            obj.Url = "" & dtDireccion.Rows(0).Item("url")
            obj.Longitud = "" & dtDireccion.Rows(0).Item("longitud")
            obj.Latitud = "" & dtDireccion.Rows(0).Item("latitud")

            obj.estado = RECOJO.PENDIENTE
            obj.solicitante = Me.TxtSolicitante.Text
            obj.fecha = DtpFecha.Text 'Me.lblfecha.Text
            obj.fecharecojo = DtpFecha.Value.Date

            obj.hora_listo = hora1
            obj.hora_cierre = hora2

            obj.observacion = Me.TxtObservacion.Text
            obj.tipo_recojo = 1

            'hlamas 01-01-2018
            obj.id_tipo_cliente = cboTipoCliente.SelectedIndex
            obj.Producto = cboProducto.SelectedValue

            obj.id_ciudad_destino = Me.CboDestino.Tag
            obj.Bultos = Me.txtBultos.Text
            obj.Usuario = dtoUSUARIOS.IdLogin
            obj.Ip = dtoUSUARIOS.IP '"192.168.50.52"

            If Val(txtPeso.Text) = 0 Then
                obj.Peso = 0
            Else
                obj.Peso = CType(Me.txtPeso.Text, Double)
            End If
            If Val(txtVolumen.Text) = 0 Then
                obj.Volumen = 0
            Else
                obj.Volumen = CType(Me.txtVolumen.Text, Double)
            End If
            obj.Ciudad = dtoUSUARIOS.m_idciudad
            obj.Agencia = dtoUSUARIOS.iIDAGENCIAS

            Dim dt As New DataTable
            If bNuevo Then
                dt = obj.Fn_Grabar_Existente()
            Else
                obj.Fn_Grabar_Existente(DgvLista.CurrentRow.Cells("id_recojo").Value)
            End If
            If bNuevo Then
                Me.txtitem.Text = dt.Rows(0).Item(0).ToString
                Me.txtitem.Refresh()
            End If
            'MessageBox.Show("Recojo Actualizado", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'If bNuevo Then
            'Limpiarrecojo()
            'bNuevo = False
            'End If
            'Me.mostrarDatos()
            'Me.TxtNumero.Focus()

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Tsbeditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tsbeditar.Click
        Try
            Me.Cursor = Cursors.AppStarting
            Me.TabRecojo.SelectedIndex = 1
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Dim index As Integer

    Private Sub TxtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNumero.TextChanged
        If Me.TxtCliente.Text.Trim.Length > 0 Then
            Dim sNumero As String = Me.TxtNumero.Text.Trim
            Dim iPos As Integer = Me.TxtNumero.SelectionStart
            Limpiarrecojo()
            Me.TxtNumero.Text = sNumero
            Me.TxtNumero.SelectionStart = iPos
        End If
    End Sub
    Dim punto As Integer

    Private Sub TxtBultos_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBultos.Enter
        Dim iValor As Double = 0
        If Me.txtBultos.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.txtBultos.Text
        End If
        Me.txtBultos.Text = Format(CDbl(iValor), "########0")
        If Val(txtBultos.Text) = 0 Then
            txtBultos.Text = ""
        End If
    End Sub

    Private Sub TxtBultos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBultos.GotFocus
        Me.txtBultos.SelectAll()
    End Sub
    Private Sub TxtBultos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBultos.KeyPress
        If Not ValidarN(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TxtPeso_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPeso.Enter
        Dim iValor As Double = 0
        If Me.txtPeso.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.txtPeso.Text
        End If
        Me.txtPeso.Text = Format(CDbl(iValor), "########0.00")
        If Val(txtPeso.Text) = 0 Then
            txtPeso.Text = ""
        End If
    End Sub
    Private Sub TxtPeso_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPeso.GotFocus
        txtPeso.SelectAll()
    End Sub
    Private Sub TxtPeso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPeso.KeyPress
        If Not ValidarN(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = Numero(e, txtPeso)
    End Sub
    Private Sub TxtVolumen_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVolumen.Enter
        Dim iValor As Double = 0
        If Me.txtVolumen.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.txtVolumen.Text
        End If
        Me.txtVolumen.Text = Format(CDbl(iValor), "########0.00")
        If Val(txtVolumen.Text) = 0 Then
            txtVolumen.Text = ""
        End If
    End Sub
    Private Sub TxtVolumen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVolumen.GotFocus
        txtVolumen.SelectAll()
    End Sub
    Private Sub CboDestino_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboDestino.GotFocus
        CboDestino.SelectAll()
    End Sub
    Private Sub CboDestino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDestino.SelectedIndexChanged
        'CboDestino.Tag = CboDestino.SelectedValue
        If Not (IsReference(Me.CboDestino.SelectedValue)) Then
            If Me.CboDestino.SelectedValue = 0 Then
                Me.btnAgregar.Enabled = False
            Else
                Me.btnAgregar.Enabled = True
                Me.btnAgregar.Focus()
            End If
        End If
    End Sub
    Private Sub TxtPeso_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPeso.LostFocus
        Dim iValor As Double = 0
        If Me.txtPeso.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.txtPeso.Text
        End If
        Me.txtPeso.Text = Format(CDbl(iValor), "##,###,###0.00")
        If Val(txtPeso.Text) = 0 Then
            txtPeso.Text = ""
        End If
    End Sub
    Private Sub TxtVolumen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVolumen.LostFocus
        Dim iValor As Double = 0
        If Me.txtVolumen.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.txtVolumen.Text
        End If
        Me.txtVolumen.Text = Format(CDbl(iValor), "##,###,###0.00")
        If Val(txtVolumen.Text) = 0 Then
            txtVolumen.Text = ""
        End If
    End Sub

    Private Sub TxtObservacion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtObservacion.GotFocus
        Me.TxtObservacion.SelectAll()
    End Sub

    Private Sub TxtSolicitante_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSolicitante.GotFocus
        Me.TxtSolicitante.SelectAll()
    End Sub

    Private Sub TxtBultos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBultos.LostFocus
        Dim iValor As Double = 0
        If Me.txtBultos.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.txtBultos.Text
        End If
        Me.txtBultos.Text = Format(CDbl(iValor), "##,###,###0")
        If Val(txtBultos.Text) = 0 Then
            txtBultos.Text = ""
        End If
    End Sub

    Private Sub BtnDireccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDireccion.Click
        If Me.TxtNumero.Text.Trim.Length = 0 Then
            BtnDireccion.Enabled = False
            TxtNumero.Focus()
        Else
            'Me.Cursor = Cursors.AppStarting
            Me.CargarDireccion()
            'Me.Cursor = Cursors.Default
        End If
    End Sub

    Sub CargarDireccion()
        Dim obj As New dtrecojo
        Dim frm As New FrmDireccion
        Dim nro As String
        nro = Me.TxtNumero.Text
        frm.bNuevo = True
        Dim direccion, ref As String
        direccion = Me.txtdir.Text
        ref = Me.txtref.Text
        frm.nrodocumento = nro
        'frm.TxtDireccion.Text = direccion
        frm.strDireccion = direccion
        frm.TxtReferencia.Text = ref

        frm.departamento = departamento
        frm.provincia = provincia
        frm.distrito = distrito

        If txtdepar.Tag = 0 Or txtpro.Tag = 0 Or txtdist.Tag = 0 Then
            frm.pais = 4
            frm.nomdepa = 15
            frm.nomprov = 17
            frm.nomdist = 2
        Else
            frm.pais = 4
            frm.nomdepa = txtdepar.Tag
            frm.nomprov = txtpro.Tag
            frm.nomdist = txtdist.Tag 'Pasando TipoComunicacion
        End If
        frm.dtDireccion = dtDireccion
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            'Me.txtdir.Text = frm.TxtDireccion.Text
            Me.txtdir.Text = frm.strDireccion
            Me.txtref.Text = frm.TxtReferencia.Text
            Me.txtdepar.Text = frm.CboDepartamento.Text
            Me.txtpro.Text = frm.CboProvincia.Text
            Me.txtdist.Text = frm.CboDistrito.Text
            Me.txtdepar.Tag = frm.CboDepartamento.SelectedValue
            Me.txtpro.Tag = frm.CboProvincia.SelectedValue
            Me.txtdist.Tag = frm.CboDistrito.SelectedValue
            departamento = frm.CboDepartamento.SelectedValue
            provincia = frm.CboProvincia.SelectedValue
            distrito = frm.CboDistrito.SelectedValue

            If Not bNoCambioDireccion Then
                iIdDireccion = 0
            End If

            bsalir = True

            Me.DtpHora1.Focus()
        End If
    End Sub

    Sub ActualizarContacto(ByVal a As Boolean, ByVal b As Boolean, ByVal c As Boolean)
        bNoCambioContacto = a
        bNoCambioFijo = b
        bNoCambioMovil = c
    End Sub

    Sub cargaclientes()
        Dim frm As New FrmCliente
        frm.bNuevo = True
        frm.TxtCliente.Text = iNombres
        If Me.TxtNumero.Text.Trim.Length = 0 Then
            frm.TxtNumero.Text = ""
        Else
            frm.TxtNumero.Text = Me.TxtNumero.Text
        End If
        frm.txtnom.Text = Me.txtnom.Text  'NOMBRES DE CONTACTO
        frm.txtapep.Text = iApePaterno
        frm.txtapem.Text = iApeMaterno
        frm.txtnrodocumento.Text = indocumento 'Pasando Nº Documento del Contacto
        'frm.iDocContacto = iDocContacto
        frm.txtemail.Text = Me.txtemail.Text  'EMAIL
        frm.txtfijo.Text = Me.txttel.Text 'TELEFONO FIJO
        frm.txtmovil.Text = Me.txtmovil.Text 'MOVIL
        'frm.txtdireccion.Text = Me.txtdir.Text
        frm.strDireccion = Me.txtdir.Text
        frm.txtrefllegada.Text = Me.txtref.Text
        If itipodocumento <> 0 Or iDocContacto <> 0 Or itipocomunicacion < 0 Then
            frm.itipodocumento = itipodocumento  'Pasando tipo Doc Cte
            frm.iDocContacto = iDocContacto    'Pasando Tipo Documento
            frm.iTipoMovil = itipocomunicacion 'Pasando TipoComunicacion
        Else
            frm.itipodocumento = 1
            frm.iDocContacto = 3
            frm.iTipoMovil = 0
        End If
        'hlamas 04/01/2018
        'If iddepartamento <> 0 Or idprovincia <> 0 Or iddistrito <> 0 Or CboTipoCliente.SelectedValue <> 0 Then
        If iddepartamento <> 0 Or idprovincia <> 0 Or iddistrito <> 0 Then
            frm.pais = 4
            frm.departamento = iddepartamento 'Pasando Departamento
            frm.provincia = idprovincia
            frm.distrito = iddistrito
            'hlamas 04/01/2018
            frm.itipoCliente = cboProducto.SelectedValue
        Else
            frm.pais = 4
            frm.departamento = 15 'Pasando Departamento
            frm.provincia = 17
            frm.distrito = 0 '627
            frm.itipoCliente = 8
        End If
        frm.TabCliente.TabPages.RemoveAt(1)
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            If frm.TabCliente.SelectedIndex = 0 Then
                Me.TxtNumero.Text = frm.TxtNumero.Text.Trim
                Me.BuscaCliente(Me.TxtNumero.Text)
                Return
            End If
            Me.TxtNumero.Text = frm.TxtNumero.Text 'PASO NUMERO DE DOCUMENTO
            Me.TxtCliente.Text = frm.TxtCliente.Text & " " & frm.txtapep.Text & " " & frm.txtapem.Text 'razon social
            apep = frm.txtapep.Text
            apem = frm.txtapem.Text
            'nom = IIf(frm.CboTipoDocumento.SelectedValue = 1, frm.TxtCliente.Text, "")
            nom = frm.TxtCliente.Text
            iddepartamento = frm.CboDepartamento.SelectedValue
            idprovincia = frm.CboProvincia.SelectedValue
            iddistrito = frm.CboDistrito.SelectedValue
            'tabla t_contactopersona
            Me.txtnom.Text = frm.txtnom.Text  'NOMBRES DE CONTACTO
            iNombres = frm.iCliente
            iApePaterno = frm.txtapep.Text ' IIf((frm.CboTipoDocumento.SelectedValue = 1), frm.txtapep.Text = "",
            iApeMaterno = frm.txtapem.Text 'IIf((frm.CboTipoDocumento.SelectedValue = 1), frm.txtapem.Text = "", 
            'Tipo de Doc del Contacto
            indocumento = frm.txtnrodocumento.Text 'Numero de Documento del Contacto
            'idtipoComunicacion
            Me.BtnCliente.Enabled = True
            Me.txtemail.Text = frm.txtemail.Text  'EMAIL
            Me.txttel.Text = frm.txtfijo.Text 'TELEFONO FIJO
            Me.txtmovil.Text = frm.txtmovil.Text  'MOVIL
            'Me.txtdir.Text = frm.txtdireccion.Text
            Me.txtdir.Text = frm.strDireccion
            Me.txtref.Text = frm.txtrefllegada.Text
            'pasa datos de combo seleccionado al formulario
            Me.txtdepar.Text = frm.CboDepartamento.Text
            Me.txtpro.Text = frm.CboProvincia.Text
            Me.txtdist.Text = frm.CboDistrito.Text
            'capturando los Id de Ubigeo

            'hlamas 04/01/2018
            Me.cboProducto.SelectedValue = frm.CboTipoCliente.SelectedValue

            itipodocumento = frm.CboTipoDocumento.SelectedValue
            iDocContacto = frm.CboDocContacto.SelectedValue
            itipocomunicacion = frm.CboMovil.SelectedValue
            Me.DtpHora1.Focus()
            BtnContacto.Enabled = False
            BtnDireccion.Enabled = False
            'lista_item(Me.TxtNumero.Text)
        End If
    End Sub

    Private Sub FrmSolicitudRecojo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            bInicio = True
            If Acceso.SiRol(G_Rol, Me, 1, 2) Then
                intFuncionario = dtoUSUARIOS.IdLogin
                intPerfil = 2
            End If
            If Acceso.SiRol(G_Rol, Me, 1, 1) Then
                intPerfil = 1
            End If
            If Acceso.SiRol(G_Rol, Me, 1, 3) Then
                intPerfil = 3
            End If
            If Acceso.SiRol(G_Rol, Me, 1, 4) Then
                intPerfil = 4
            End If

            Me.Limpiarrecojo()
            lblfecha.Text = CDate(FechaServidor()).ToShortDateString
            Inicio()
            Formato()
            FormatoDgvDestino()
            mostrarDatos()
            Me.TabRecojo.SelectedIndex = 1

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabRecojo.SelectedIndexChanged
        Try
            If bInicio Then
                Me.Tsbeditar.Enabled = False
                Me.Tsbanular.Enabled = False
                Me.tsbGeocodificar.Enabled = False
                Return
            End If
            If Me.TabRecojo.SelectedIndex = 1 Then
                If Me.Tsbeditar.Text.Substring(0, 1) = "E" Then
                    Me.TSBGrabar.Enabled = True
                Else
                    Me.TSBGrabar.Enabled = False
                End If
                Me.TxtNumero.Focus()

                Tsbeditar.Enabled = False
                Tsbactualizar.Enabled = False
                Tsbanular.Enabled = False
                tsbGeocodificar.Enabled = False
                If DgvLista.Rows.Count = 0 Then
                    Limpiarrecojo()
                Else
                    Me.Cursor = Cursors.AppStarting
                    dtDireccion = Nothing
                    Detalle(DgvLista.CurrentRow.Cells("id_recojo").Value)
                    BtnCliente.Enabled = False
                    BtnContacto.Enabled = True
                    BtnDireccion.Enabled = True
                    Me.Cursor = Cursors.Default
                End If
            ElseIf Me.TabRecojo.SelectedIndex = 0 Then
                Formato()
                Tsbactualizar.Enabled = True
                If Me.DgvLista.Rows.Count = 0 Then
                    Tsbeditar.Enabled = False
                    tsbGeocodificar.Enabled = False
                Else
                    Tsbeditar.Enabled = True
                    tsbGeocodificar.Enabled = True
                End If
                TSBGrabar.Enabled = False
            Else
                TSBGrabar.Enabled = True
                Tsbeditar.Enabled = True
                tsbGeocodificar.Enabled = True
            End If
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DgvLista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvLista.DoubleClick
        Try
            If DgvLista.Rows.Count > 0 Then
                Me.Cursor = Cursors.AppStarting
                Me.TabRecojo.SelectedIndex = 1
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Anular(ByVal recojo As Integer)
        Try
            Dim obj As New dtrecojo
            obj.Usuario = dtoUSUARIOS.IdLogin
            obj.Ip = dtoUSUARIOS.IP '"192.168.50.52"
            obj.Anular(recojo)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub CambiarEstado(ByVal recojo As Integer, ByVal estado As Integer, ByVal observacion As String)
        Try
            Dim obj As New DtoRecojo
            obj.Recojo = recojo
            obj.Observacion = observacion
            obj.Estado = estado
            obj.Usuario = dtoUSUARIOS.IdLogin
            obj.Ip = dtoUSUARIOS.IP '"192.168.50.52"
            obj.CambiarEstado(1)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub Tsbanular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tsbanular.Click
        Try
            Dim frm As New FrmEstadoRecojo
            frm.iNum = 1
            frm.iEstado = RECOJO.CANCELADO
            frm.Text = "Cancelar"
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.Yes Then
                'Me.Cursor = Cursors.AppStarting
                CambiarEstado(Me.DgvLista.CurrentRow.Cells("id_recojo").Value, RECOJO.CANCELADO, frm.TxtObservacion.Text.Trim)
                MessageBox.Show("Recojo Cancelado.", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.mostrarDatos()
                'Me.Cursor = Cursors.Default
            End If

        Catch ex As Exception When -1
            Me.Cursor = Cursors.Default
            MessageBox.Show("El Recojo Nº " & Me.DgvLista.CurrentRow.Cells("id_recojo").Value & " " & _
                            "no ha sido Cancelado." & vbCrLf & "El Recojo no se encuentra en estado Pendiente.", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.mostrarDatos()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Try
    '    Dim dlgRespuesta As DialogResult = MessageBox.Show("¿Está Seguro de Cancelar el Recojo?", "Recojos", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '    If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
    '        Me.Cursor = Cursors.AppStarting
    '        Anular(Me.DgvLista.CurrentRow.Cells("id_recojo").Value)
    '        Me.Cursor = Cursors.Default
    '        MessageBox.Show("Recojo Cancelado.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Me.mostrarDatos()
    '    End If
    'Catch ex As Exception
    '    Me.Cursor = Cursors.Default
    '    MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
    'End Try
    'End Sub

    Private Sub TxtVolumen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVolumen.KeyPress
        If Not ValidarN(e.KeyChar) Then
            e.Handled = True
        End If
        e.Handled = Numero(e, txtVolumen)
    End Sub

    Private Sub TxtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtObservacion.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            Me.TxtSolicitante.Focus()
        End If
    End Sub

    Private Sub TxtObservacion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtObservacion.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtObservacion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtObservacion.LostFocus
        Me.TxtObservacion.Text = Me.TxtObservacion.Text.Trim
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frm As New Form1
    '    frm.ShowDialog()
    'End Sub

    Sub Inicio()
        Try
            Dim obj As New dtrecojo
            ds = obj.InicioRecojo()
            Me.CboDestino.DataSource = ds.Tables(0)
            Me.CboDestino.DisplayMember = "nombre_unidad"
            Me.CboDestino.ValueMember = "Id"
            Me.CboDestino.SelectedValue = 0
            Me.dgvDestino.Rows.Clear()
            'hlamas 04/01/2018
            'Me.cboProducto.DataSource = ds.Tables(1)
            'Me.cboProducto.DisplayMember = "Procesos"
            'Me.cboProducto.ValueMember = "idprocesos"
            'Me.cboProducto.SelectedValue = 0
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub cargacontactos()
        Dim frm As New FrmContacto
        Dim obj As New dtrecojo

        frm.bNuevo = True
        Dim correo As String
        Dim fijo As String
        Dim nro As String
        nro = Me.TxtNumero.Text.Trim
        frm.bNuevo = True
        frm.nrodoc = nro
        correo = Me.txtemail.Text.Trim
        fijo = Me.txttel.Text.Trim
        frm.nrodocumento = indocumento
        frm.txtnrodocumento.Text = IIf((indocumento = ""), nrodocumento, indocumento)
        'frm.txtnrodocumento.Tag = frm.txtnrodocumento.Text
        frm.nroCliente = itipodocumentoCliente.Trim
        If itipoDoc <> 0 Or iComunicacion < 0 Then
            frm.DocContacto = itipoDoc
            frm.tipoComunicacion = iComunicacion 'pasando datos combo    
        Else
            frm.DocContacto = 3
            frm.tipoComunicacion = 0
        End If
        frm.txtnomc.Text = Me.txtnom.Text.Trim
        frm.txtemail.Text = correo.Trim
        frm.txtfijo.Text = fijo 'IIf((fijo = ""), frm.txtfijo.Text = "", fijo)
        frm.txtmovil.Text = txtmovil.Text.Trim
        frm.numero = Me.TxtNumero.Text.Trim
        frm.cliente = Me.TxtCliente.Text.Trim
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtnom.Text = frm.txtnomc.Text.Trim
            Me.txtemail.Text = frm.txtemail.Text.Trim
            Me.txttel.Text = frm.txtfijo.Text.Trim
            Me.txtmovil.Text = frm.txtmovil.Text.Trim
            indocumento = frm.txtnrodocumento.Text.Trim
            Me.iComunicacion = frm.CboMovil.SelectedValue
            itipoDoc = frm.CboDocContacto.SelectedValue

            If Not bNoCambioContacto Then
                iIdContacto = 0
            End If

            If Not bNoCambioFijo Then
                codcomunicacion_t = 0
            End If

            If Not bNoCambioMovil Then
                codcomunicacion_m = 0
            End If

            Me.BtnDireccion.Focus()
        End If
    End Sub

    Sub Detalle(ByVal id As Integer)
        Try
            Dim obj As New dtrecojo
            obj.Recojo = id
            Dim dt As DataTable = obj.ListarRecojo2
            If dt.Rows.Count > 0 Then
                bNuevo = False
                Dim row As DataRow = dt.Rows(0)
                Me.Codigopersona = row.Item("id_persona")
                Me.TxtNumero.Text = row.Item("documento")
                Me.TxtCliente.Text = row.Item("cliente")
                Me.txtdir.Text = row.Item("direccion")
                Me.txtref.Text = row.Item("referencia").ToString.Trim
                Me.txtdepar.Text = row.Item("departamento")
                Me.txtpro.Text = row.Item("provincia")
                Me.txtdist.Text = row.Item("distrito")
                Me.txtdepar.Tag = row.Item("iddepartamento")
                Me.txtpro.Tag = row.Item("idprovincia")
                Me.txtdist.Tag = row.Item("iddistrito")
                Me.indocumento = row.Item("documento2")
                Me.itipodocumentoCliente = row.Item("idtipodocumento")
                Me.itipoDoc = row.Item("idtipodocumento")
                Me.iIdContacto = row.Item("id_contacto")
                Me.iIdDireccion = row.Item("id_direccion")

                Me.codcomunicacion_t = row.Item("idfijo").ToString.Trim
                Me.codcomunicacion_m = row.Item("idmovil").ToString.Trim
                Me.iComunicacion = row.Item("idtipocomunicacion").ToString.Trim
                Me.txtnom.Text = row.Item("contacto")
                Me.txtemail.Text = row.Item("email")
                Me.txttel.Text = row.Item("fijo")
                Me.txtmovil.Text = row.Item("movil")

                Me.DtpHora1.Text = row.Item("hora_listo")
                Me.DtpHora1.Tag = row.Item("hora_listo")
                Me.DtpHora2.Text = row.Item("hora_cierre")
                Me.DtpHora2.Tag = row.Item("hora_cierre")
                Me.DtpFecha.Value = row("fecha")
                'Me.DtpFecha.Enabled = False

                'hlamas 04/01/2018
                Me.cboTipoCliente.SelectedIndex = row.Item("id_tipo_cliente")
                Me.cboProducto.SelectedValue = row.Item("producto")

                Me.TxtSolicitante.Text = row.Item("solicitante").ToString.Trim
                Me.TxtObservacion.Text = row.Item("observacion").ToString.Trim
                'Me.CboDestino.SelectedValue = row.Item("id_ciudad_destino")
                Me.txtBultos.Text = IIf(Val(row.Item("cantidad")) = 0, "", Format(CDbl(row.Item("cantidad")), "##,###,###0"))
                Me.txtPeso.Text = IIf(Val(row.Item("peso")) = 0, "", Format(CDbl(row.Item("peso")), "##,###,###0.00"))
                Me.txtVolumen.Text = IIf(Val(row.Item("volumen")) = 0, "", Format(CDbl(row.Item("volumen")), "##,###,###0.00"))
                Me.txtitem.Text = row.Item("id_recojo")
                Me.lblFuncionario.Text = row.Item("funcionario")

                Me.dgvDestino.Rows.Clear()
                Dim dt1 As DataTable
                dt1 = obj.ListarRecojoDestino(row.Item("id_recojo"))
                If dt1.Rows.Count > 0 Then
                    For Each rowi As DataRow In dt1.Rows
                        With Me.dgvDestino
                            .Rows.Add()
                            .Rows(.Rows.Count - 1).Cells(0).Value = rowi("id")
                            .Rows(.Rows.Count - 1).Cells(1).Value = rowi("nombres")
                        End With
                    Next
                End If

                dtDireccion = obj.ListarDireccion(Me.iIdDireccion)
            End If
            Me.TabRecojo.SelectedIndex = 1
            Me.TxtNumero.Enabled = False
            DtpHora1.Focus()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub Tsbactualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tsbactualizar.Click
        DtpInicio_ValueChanged(sender, e)
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles TsbNuevo.EnabledChanged, Tsbeditar.EnabledChanged, TSBGrabar.EnabledChanged, Tsbanular.EnabledChanged, Tsbactualizar.EnabledChanged, TSBCalaculadora.EnabledChanged, TsbSalir.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Sub mostrarDatos()
        Try
            Dim obj As New dtrecojo
            Dim strInicio As String = Me.dtpInicio.Text
            Dim strFin As String = Me.dtpFin.Text

            dsTipo = obj.Listar_recojoxfec(strInicio, strFin, intPerfil, intFuncionario, dtoUSUARIOS.m_idciudad)

            'If Acceso.SiRol(G_Rol, Me, 1) Then
            '    dsTipo = obj.Listar_recojoxfec(sfecha)
            '    Me.DgvLista.Columns("usuario").Visible = True
            'Else
            '    dsTipo = obj.Listar_recojoxfec(sfecha, dtoUSUARIOS.IdLogin)
            '    Me.DgvLista.Columns("usuario").Visible = False
            'End If

            Me.DgvLista.DataSource = dsTipo.Tables(0)
            If Me.DgvLista.Rows.Count = 0 Then
                Me.Tsbeditar.Enabled = False
                Me.tsbGeocodificar.Enabled = False
            Else
                Me.Tsbeditar.Enabled = True
                Me.tsbGeocodificar.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DgvLista_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvLista.RowEnter
        If bInicio Then Return
        If Me.DgvLista.Rows.Count > 0 Then
            Me.Tsbeditar.Enabled = True
            Me.tsbGeocodificar.Enabled = True
            If Me.DgvLista.Rows(e.RowIndex).Cells("id_estado").Value = RECOJO.PENDIENTE Or Me.DgvLista.Rows(e.RowIndex).Cells("id_estado").Value = RECOJO.ENCURSO Then
                Me.Tsbanular.Enabled = True
                Me.Tsbeditar.Text = "Editar"

                If Acceso.SiRol(G_Rol, Me, 1) Then
                    If Me.DgvLista.Rows(e.RowIndex).Cells("idusuario").Value = dtoUSUARIOS.IdLogin Then
                        Me.Tsbanular.Enabled = True
                        Me.Tsbeditar.Text = "Editar"
                        'Me.TSBGrabar.Enabled = True
                    Else
                        Me.Tsbanular.Enabled = False
                        Me.Tsbeditar.Text = "Consultar"
                    End If
                End If
            Else
                Me.Tsbanular.Enabled = False
                Me.Tsbeditar.Text = "Consultar"
                'Me.TSBGrabar.Enabled = False
            End If
        Else
            Me.Tsbeditar.Enabled = False
            Me.tsbGeocodificar.Enabled = False
        End If
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Try
            Cursor = Cursors.AppStarting
            Dim obj As New dtrecojo
            Dim strInicio As String = Me.dtpInicio.Value.Date
            Dim strFin As String = Me.dtpFin.Value.Date

            Dim ds As DataSet = obj.Listar_recojoxfec(strInicio, strFin, intPerfil, intFuncionario, dtoUSUARIOS.m_idciudad)
            Me.DgvLista.DataSource = ds.Tables(0)
            If Me.DgvLista.Rows.Count = 0 Then
                Me.Tsbeditar.Enabled = False
                Me.tsbGeocodificar.Enabled = False
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function Agregado(ByVal ciudad As Integer, ByVal dgv As DataGridView) As Boolean
        For Each row As DataGridViewRow In dgv.Rows
            If row.Cells("id").Value = ciudad Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        With Me.dgvDestino
            If Not Agregado(Me.CboDestino.SelectedValue, Me.dgvDestino) Then
                .Rows.Add()
                .Rows(.Rows.Count - 1).Cells(0).Value = Me.CboDestino.SelectedValue
                .Rows(.Rows.Count - 1).Cells(1).Value = Me.CboDestino.Text
                Me.dgvDestino.Focus()
            Else
                MessageBox.Show("La ciudad ya existe en la lista", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.CboDestino.Focus()
            End If
        End With
    End Sub

    Private Sub dgvDestino_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvDestino.RowsAdded
        If Me.dgvDestino.Rows.Count = 0 Then
            Me.btnEliminar.Enabled = False
        Else
            Me.btnEliminar.Enabled = True
        End If
    End Sub

    Private Sub dgvDestino_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvDestino.RowsRemoved
        If Me.dgvDestino.Rows.Count = 0 Then
            Me.btnEliminar.Enabled = False
        Else
            Me.btnEliminar.Enabled = True
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        With Me.dgvDestino
            .Rows.Remove(.CurrentRow)
        End With
    End Sub

    Sub ListarProducto()
        Dim intProducto As Integer
        Dim obj As New dtrecojo
        intProducto = IIf(iSaldoCtaCte = -1, iTipoCliente, 8)
        Dim dt As DataTable = obj.ListarProducto(intProducto, Me.cboTipoCliente.SelectedIndex)
        With Me.cboProducto
            .DisplayMember = "proceso"
            .ValueMember = "id"
            .DataSource = dt
            .SelectedIndex = IIf(dt.Rows.Count > 1, 1, 0)
        End With
    End Sub

    Private Sub cboTipoCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoCliente.SelectedIndexChanged
        Me.ListarProducto()
        Me.LblSobregiro.Visible = False
        If Me.cboTipoCliente.SelectedIndex = 2 AndAlso iSaldoCtaCte <> -1 Then
            If iSaldoCtaCte < 0 Then   'cliente credito con sobregiro
                Me.LblSobregiro.Text = "Cliente con Sobregiro de S/. " & Format(Math.Abs(CDbl(iSaldoCtaCte.ToString)), "###,###,###0.00")
                Me.LblSobregiro.Visible = True
            End If
        End If
    End Sub

    Private Sub tsbGeocodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGeocodificar.Click
        Dim intFila As Integer = Me.DgvLista.CurrentRow.Index
        Dim frm As New frmGoogleMaps
        frm.Direccion = "" & Me.DgvLista.CurrentRow.Cells("direccion").Value
        frm.Url = "" & Me.DgvLista.CurrentRow.Cells("url").Value
        frm.ShowDialog()
        If frm.Latitud.Trim.Length > 0 Then
            Dim obj As New dtgrabarecojo
            obj.GrabarDireccionGps(Me.DgvLista.CurrentRow.Cells("id_direccion").Value, frm.Url.Trim, frm.Latitud.Trim, frm.Longitud.Trim, _
                                   dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
            Me.btnConsultar_Click(Nothing, Nothing)
            Me.DgvLista.CurrentCell = Me.DgvLista(0, intFila)
        End If
    End Sub

    Private Sub DgvLista_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvLista.CellContentClick

    End Sub
End Class