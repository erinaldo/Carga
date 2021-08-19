Public Class FrmDireccion
#Region "variables"
    Public departamento As Integer
    Public provincia As Integer
    Public distrito As Integer
    Public pais As Integer

    Public nomdepa As Integer
    Public nomprov As Integer
    Public nomdist As Integer

    Public dtDepartamento As DataTable
    Public dtProvincia As DataTable
    Public dtDistrito As DataTable

    'Public dtDocContacto As DataTable
    'Public dtTipoComunicacion As DataTable
    'Public DocContacto As Integer
    'Public tipoComunicacion As Integer

    Public nrodocumento As String
    Public nrodoc As String
    Public bNuevo As Boolean
    Dim bSalir As Boolean = True

    Dim lista(8) As String

    Public dtDireccion As DataTable

    Dim dtVia As DataTable
    Dim dtZona As DataTable
    Dim dtNivel As DataTable
    Dim dtClasificacion As DataTable

    Public intDireccion As Integer
    Public strDireccion As String

    Public Url As String
    Public latitud As String
    Public longitud As String
#End Region

#Region "Formato"
    Sub FormatoDireccion()
        With Me.DtgDireccion
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            '.AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            '.RowHeadersVisible = True
            .RowHeadersWidth = 30
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.ScrollBars = ScrollBars.Both
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black
            .ReadOnly = True 'readonly cuando este false se puede editar
            '.Focus()
            Dim Departamento As New DataGridViewTextBoxColumn
            With Departamento
                .HeaderText = "Departamento"
                .Name = "Departamento"
                .DataPropertyName = "departamento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                '.Visible = False
                '.ReadOnly = True
            End With
            Dim Provincia As New DataGridViewTextBoxColumn
            With Provincia
                .HeaderText = "Provincia"
                .Name = "Provincia"
                .DataPropertyName = "provincia"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.Width = 120
            End With
            Dim Distrito As New DataGridViewTextBoxColumn
            With Distrito
                .HeaderText = "Distrito"
                .Name = "distrito"
                .DataPropertyName = "distrito"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.Width = 120
            End With

            Dim iddireccion_consignado As New DataGridViewTextBoxColumn
            With iddireccion_consignado
                .HeaderText = "iddireccion_consignado"
                .Name = "iddireccion_consignado"
                .DataPropertyName = "iddireccion_consignado"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.DefaultCellStyle.WrapMode = DataGridViewTriState.False
                '.Width = 220
                .Visible = False
            End With

            'agregar columna al grid
            Dim direccion As New DataGridViewTextBoxColumn
            With direccion
                .HeaderText = "Dirección"
                .Name = "direccion"
                .DataPropertyName = "direccion"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.WrapMode = DataGridViewTriState.False
                '.Width = 220
            End With
            ' fin de agregado  
            'agregar columna al grid
            Dim Referencia As New DataGridViewTextBoxColumn
            With Referencia
                .HeaderText = "Referencia"
                .Name = "referencia"
                .DataPropertyName = "referencia"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Visible = False
                '.Width = 160
            End With
            ' fin de agregado  
            .Columns.AddRange(Departamento, Provincia, Distrito, direccion, Referencia, iddireccion_consignado)
        End With
    End Sub
#End Region

#Region "Validaciones"
    Public Function Valida(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[0-9\b]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            Valida = True
        Else
            Valida = False
        End If
    End Function
    'valida email
    Public Function Validaremail(ByRef txtemail As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$")
        If re.IsMatch(txtemail.ToString()) Then
            Validaremail = True
        Else
            Validaremail = False
        End If
    End Function
    Public Function ValidarNumero(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[A-ZñÑa-z0-9\b]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            ValidarNumero = True
        Else
            ValidarNumero = False
        End If
    End Function
#End Region
    Private Sub CboDepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDepartamento.SelectedIndexChanged
        If Not CboDepartamento.SelectedValue Is Nothing And Not IsReference(CboDepartamento.SelectedValue) Then
            Try
                Dim ipais As Integer = CboPais.SelectedValue
                Dim iDepartamento As Integer = CboDepartamento.SelectedValue
                Dim sFiltro As String = "(iddepartamento=" & iDepartamento & " Or iddepartamento=0) and (idpais=" & ipais & " or idpais=0)"
                dtProvincia.DefaultView.RowFilter = sFiltro
                CboProvincia_SelectedIndexChanged(sender, e)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub CboProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboProvincia.SelectedIndexChanged
        If Not CboProvincia.SelectedValue Is Nothing And Not IsReference(CboProvincia.SelectedValue) Then
            Try
                Dim iprovincia As Integer = CboProvincia.SelectedValue
                Dim iDepartamento As Integer = CboDepartamento.SelectedValue
                Dim iPais As Integer = CboPais.SelectedValue
                Dim sFiltro As String = "(idPais=" & iPais & " or idpais=0) and (iddepartamento=" & iDepartamento & " or iddepartamento=0) and (idprovincia=" & iprovincia & " Or idprovincia=0)"
                dtDistrito.DefaultView.RowFilter = sFiltro
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Public numero As String
    Public cliente As String
    Public nroCliente As String

    Private Sub FrmDireccion_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub FrmDatosCliente_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not bSalir Then
            bSalir = True
            e.Cancel = True
        End If
    End Sub
    Private Sub FrmDatosCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub FrmDatosCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FormatoDireccion()
            Dim obj As New dtrecojo
            Dim ds As New DataSet
            ds = obj.ListarDireccion
            dtDepartamento = ds.Tables(1)
            dtProvincia = ds.Tables(2)
            dtDistrito = ds.Tables(3)

            dtVia = ds.Tables(4)
            dtZona = ds.Tables(5)
            dtNivel = ds.Tables(6)
            dtClasificacion = ds.Tables(7)

            'llena Pais
            CboPais.DataSource = ds.Tables(0).DefaultView
            CboPais.DisplayMember = "pais"
            CboPais.ValueMember = "idpais"

            CboDepartamento.DataSource = dtDepartamento
            CboDepartamento.DisplayMember = "departamento"
            CboDepartamento.ValueMember = "iddepartamento"

            CboProvincia.DataSource = dtProvincia
            CboProvincia.DisplayMember = "provincia"
            CboProvincia.ValueMember = "idprovincia"

            CboDistrito.DataSource = dtDistrito
            CboDistrito.DisplayMember = "dsitrito"
            CboDistrito.ValueMember = "iddistrito"

            cboVia.DisplayMember = "via"
            cboVia.ValueMember = "id_via"
            cboVia.DataSource = dtVia

            cboZona.DisplayMember = "zona"
            cboZona.ValueMember = "id_zona"
            cboZona.DataSource = dtZona

            cboNivel.DisplayMember = "nivel"
            cboNivel.ValueMember = "id_nivel"
            cboNivel.DataSource = dtNivel

            cboClasificacion.DisplayMember = "clasificacion"
            cboClasificacion.ValueMember = "id_clasificacion"
            cboClasificacion.DataSource = dtClasificacion

            Me.CboPais.SelectedValue = pais
            Me.CboDepartamento.SelectedValue = departamento
            Me.CboProvincia.SelectedValue = provincia
            Me.CboDistrito.SelectedValue = distrito
            Me.CboDepartamento.SelectedValue = nomdepa
            Me.CboProvincia.SelectedValue = nomprov
            Me.CboDistrito.SelectedValue = nomdist

            If Not IsNothing(dtDireccion) Then
                If dtDireccion.Rows.Count > 0 Then
                    Me.cboVia.SelectedValue = dtDireccion.Rows(0).Item("id_via")
                    Me.cboZona.SelectedValue = dtDireccion.Rows(0).Item("id_zona")
                    Me.cboNivel.SelectedValue = dtDireccion.Rows(0).Item("id_nivel")
                    Me.cboClasificacion.SelectedValue = dtDireccion.Rows(0).Item("id_clasificacion")

                    Me.txtVia.Text = "" & dtDireccion.Rows(0).Item("via")
                    Me.txtNumero.Text = "" & dtDireccion.Rows(0).Item("numero")
                    Me.txtManzana.Text = "" & dtDireccion.Rows(0).Item("manzana")
                    Me.txtLote.Text = "" & dtDireccion.Rows(0).Item("lote")
                    Me.txtNivel.Text = "" & dtDireccion.Rows(0).Item("nivel")
                    Me.txtZona.Text = "" & dtDireccion.Rows(0).Item("zona")
                    Me.txtClasificacion.Text = "" & dtDireccion.Rows(0).Item("clasificacion")

                    'hlamas 24-01-2020
                    Me.lblUrl.Text = "" & dtDireccion.Rows(0).Item("url")
                    Me.lblLatitud.Text = "" & dtDireccion.Rows(0).Item("latitud")
                    Me.lblLongitud.Text = "" & dtDireccion.Rows(0).Item("longitud")
                End If
            End If

            lista(1) = Me.CboPais.SelectedValue
            lista(2) = Me.CboDepartamento.SelectedValue
            lista(3) = Me.CboProvincia.SelectedValue
            lista(4) = Me.CboDistrito.SelectedValue
            lista(5) = strDireccion 'Me.TxtDireccion.Text.Trim
            lista(6) = Me.TxtReferencia.Text.Trim
            lista(7) = Me.lblLatitud.Text.Trim
            lista(8) = Me.lblLongitud.Text.Trim

            If bNuevo Then
                Me.TabDatos.SelectedIndex = 1
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Listacontactos()
        Try
            Dim varcontacto As Object
            Dim obj As New dtgrabarecojo
            Dim dt As New DataTable
            dt = obj.listar_grabar.Tables(0)
            varcontacto = dt.DefaultView
            obj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Listadirecciones()
        Try
            Dim vardireccion As Object
            Dim obj As New dtgrabarecojo
            Dim dt As New DataTable
            dt = obj.listar_grabar.Tables(1)
            vardireccion = dt.DefaultView
            obj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        bSalir = True
    End Sub
    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If Me.TabDatos.SelectedIndex = 0 Then
            Me.DtgDireccion_CellDoubleClick(Nothing, Nothing)
        End If
        If Me.CboDistrito.SelectedValue = 0 Then
            MessageBox.Show("Seleccione el Distrito", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bSalir = False
            Me.CboDistrito.Focus()
            Return
        End If
        If Me.CboDistrito.SelectedValue > 0 Then
            If Me.CboDepartamento.SelectedValue = 0 Then
                MessageBox.Show("Seleccione el Departamento", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                Me.CboDepartamento.Focus()
                Return
            End If

            If Me.CboProvincia.SelectedValue = 0 Then
                MessageBox.Show("Seleccione la Provincia", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                Me.CboProvincia.Focus()
                Return
            End If

            If Me.CboDistrito.SelectedValue = 0 Then
                MessageBox.Show("Seleccione el Distrito", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                Me.CboDistrito.Focus()
                Return
            End If

            'If Me.CboVia.SelectedValue = 0 Then
            If Me.cboVia.SelectedValue = 0 And cboZona.SelectedValue = 0 Then 'cambio 03102011
                MessageBox.Show("Seleccione Tipo de Vía", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                Me.cboVia.Focus()
                Return
            End If

            'If Me.TxtVia.Text.Trim.Length = 0 Then
            If Me.txtVia.Text.Trim.Length = 0 And cboZona.SelectedValue = 0 Then 'cambio 03102011
                MessageBox.Show("Ingrese Nombre de la Vía", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                Me.txtVia.Text = ""
                Me.txtVia.Focus()
                Return
            End If

            If Me.txtNumero.Text.Trim.Length = 0 And Me.txtManzana.Text.Trim.Length = 0 And Me.txtLote.Text.Trim.Length = 0 Then
                Dim sMje As String = ""
                Dim i As Integer
                'If Me.TxtNumero2.Text.Trim.Length = 0 Then
                If Me.txtNumero.Text.Trim.Length = 0 And cboVia.SelectedValue > 0 Then 'cambio 03102011
                    sMje = "Nº de la Vía"
                    i = 1
                ElseIf Me.txtManzana.Text.Trim.Length = 0 Then
                    sMje = "Manzana de la Vía"
                    i = 2
                Else
                    sMje = "Lote de la Vía"
                    i = 3
                End If
                MessageBox.Show("Ingrese " & sMje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                If Me.txtManzana.Text.Trim.Length = 0 Then Me.txtManzana.Text = ""
                If Me.txtLote.Text.Trim.Length = 0 Then Me.txtLote.Text = ""

                If i = 1 Then
                    Me.txtNumero.Focus()
                ElseIf i = 2 Then
                    Me.txtManzana.Focus()
                Else
                    Me.txtLote.Focus()
                End If
                Return
            End If

            If Me.txtNumero.Text.Trim.Length = 0 And (Me.txtManzana.Text.Trim.Length = 0 Or Me.txtLote.Text.Trim.Length = 0) Then
                Dim sMje As String = ""
                Dim i As Integer
                If Me.txtManzana.Text.Trim.Length = 0 Then
                    sMje = "Manzana de la Vía"
                    i = 1
                Else
                    sMje = "Lote de la Vía"
                    i = 2
                End If
                MessageBox.Show("Ingrese " & sMje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                If Me.txtManzana.Text.Trim.Length = 0 Then Me.txtManzana.Text = ""
                If Me.txtLote.Text.Trim.Length = 0 Then Me.txtLote.Text = ""
                If i = 1 Then
                    Me.txtManzana.Focus()
                Else
                    Me.txtLote.Focus()
                End If
                Return
            End If

            If Me.cboNivel.SelectedValue > 0 AndAlso Me.txtNivel.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nombre del Nivel", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                Me.txtNivel.Text = ""
                Me.txtNivel.Focus()
                Return
            End If

            If Me.cboZona.SelectedValue > 0 AndAlso Me.txtZona.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nombre de la Zona", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                Me.txtZona.Text = ""
                Me.txtZona.Focus()
                Return
            End If

            If Me.cboClasificacion.SelectedValue > 0 AndAlso Me.txtClasificacion.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nombre de la Clasificación", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                Me.txtClasificacion.Text = ""
                Me.txtClasificacion.Focus()
                Return
            End If

            'If Me.lblLatitud.Text.Trim.Length = 0 Or Me.lblLongitud.Text.Trim.Length = 0 Then
            '    MessageBox.Show("Ubique la dirección en Google Maps", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.btnGoogle.Focus()
            '    bSalir = False
            '    Return
            'End If
        End If

        Dim sDireccion As String = IIf(cboVia.SelectedValue = 0, "", cboVia.Text) & " " & IIf(cboVia.SelectedValue = 0, "", txtVia.Text.Trim) & " "
        If cboVia.SelectedValue > 0 And txtNumero.Text.Trim.Length > 0 Then
            sDireccion &= txtNumero.Text.Trim & " "
        End If
        If txtManzana.Text.Trim.Length > 0 Then
            sDireccion &= "MZ " & txtManzana.Text.Trim & " LT " & txtLote.Text.Trim & " "
        End If
        If cboNivel.SelectedValue > 0 Then
            sDireccion &= cboNivel.Text & " " & txtNivel.Text.Trim & " "
        End If
        If cboZona.SelectedValue > 0 Then
            sDireccion &= cboZona.Text & " " & txtZona.Text.Trim & " "
        End If
        If cboClasificacion.SelectedValue > 0 Then
            sDireccion &= cboClasificacion.Text & " " & txtClasificacion.Text.Trim & " "
        End If
        If CboDistrito.SelectedValue > 0 Then
            sDireccion &= CboDistrito.Text
        End If
        strDireccion = sDireccion

        'Me.TxtDireccion.Text.Trim And _
        bNoCambioDireccion = lista(1) = Me.CboPais.SelectedValue And _
        lista(2) = Me.CboDepartamento.SelectedValue And _
        lista(3) = Me.CboProvincia.SelectedValue And _
        lista(4) = Me.CboDistrito.SelectedValue And _
        lista(5) = strDireccion.Trim And _
        lista(6) = Me.TxtReferencia.Text.Trim And _
        lista(7) = Me.lblLatitud.Text.Trim And _
        lista(8) = Me.lblLongitud.Text.Trim

        If Not bNoCambioDireccion And Not IsNothing(dtDireccion) Then
            'dtDireccion = Nothing
            If dtDireccion.Rows.Count = 0 Then
                dtDireccion.Rows.Add()
                dtDireccion.Rows(0).Item(0) = 0
            End If
            dtDireccion.Rows(0).Item(0) = intDireccion
            dtDireccion.Rows(0).Item(1) = strDireccion
            dtDireccion.Rows(0).Item(2) = Me.TxtReferencia.Text.Trim
            dtDireccion.Rows(0).Item(3) = Me.CboDepartamento.SelectedValue
            dtDireccion.Rows(0).Item(4) = Me.CboProvincia.SelectedValue
            dtDireccion.Rows(0).Item(5) = Me.CboDistrito.SelectedValue
            dtDireccion.Rows(0).Item(6) = Me.CboDepartamento.Text
            dtDireccion.Rows(0).Item(7) = Me.CboProvincia.Text
            dtDireccion.Rows(0).Item(8) = Me.CboDistrito.Text
            dtDireccion.Rows(0).Item(9) = Me.cboVia.SelectedValue
            dtDireccion.Rows(0).Item(10) = Me.txtVia.Text.Trim
            dtDireccion.Rows(0).Item(11) = Me.txtNumero.Text.Trim
            dtDireccion.Rows(0).Item(12) = Me.txtManzana.Text.Trim
            dtDireccion.Rows(0).Item(13) = Me.txtLote.Text.Trim
            dtDireccion.Rows(0).Item(14) = Me.cboNivel.SelectedValue
            dtDireccion.Rows(0).Item(15) = Me.txtNivel.Text.Trim
            dtDireccion.Rows(0).Item(16) = Me.cboZona.SelectedValue
            dtDireccion.Rows(0).Item(17) = Me.txtZona.Text.Trim
            dtDireccion.Rows(0).Item(18) = Me.cboClasificacion.SelectedValue
            dtDireccion.Rows(0).Item(19) = Me.txtClasificacion.Text.Trim

            'hlamas 24-01-2020
            dtDireccion.Rows(0).Item(20) = Me.lblUrl.Text.Trim
            dtDireccion.Rows(0).Item(21) = Me.lblLatitud.Text.Trim
            dtDireccion.Rows(0).Item(22) = Me.lblLongitud.Text.Trim
        End If

        bSalir = True
    End Sub
    Private Sub txtdir_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdir.TextChanged
        'Me.BtnBuscarDir.Enabled = Me.txtdir.Text.Trim.Length > 0
        'Dim obj As New dtrecojo
        'Dim busdir As String = Me.txtdir.Text
        'Dim ds As DataSet = obj.busca_dir(busdir)
        'Me.DtgDireccion.DataSource = ds.Tables(0)
    End Sub
    Private Sub BtnBuscarDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarDir.Click
        Me.Cursor = Cursors.AppStarting
        Dim obj As New dtrecojo
        Dim nro As String
        nro = nrodocumento
        Try
            If txtdir.Text.Trim.Length = 0 Then
                Dim ds As DataSet = obj.ListarDireccion(nro, dtoUSUARIOS.m_idciudad)
                Dim razon As Integer
                razon = ds.Tables(0).Rows.Count
                If razon = 0 Then
                    MessageBox.Show("No se Encontraron Datos", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtdir.Text = ""
                    Me.txtdir.Focus()
                Else
                    Me.DtgDireccion.DataSource = ds.Tables(0).DefaultView
                    obj = Nothing
                End If
            Else
                Dim busdir As String = Me.txtdir.Text
                Dim ds As DataSet = obj.ListarDireccion(busdir, nro, dtoUSUARIOS.m_idciudad)
                Me.DtgDireccion.DataSource = ds.Tables(0)
            End If
            Me.Cursor = Cursors.Default
            Me.txtdir.Focus()
            'Formato()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CboPais_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboPais.SelectedIndexChanged
        If Not CboPais.SelectedValue Is Nothing And Not IsReference(CboPais.SelectedValue) Then
            Try
                Dim ipais As Integer = CboPais.SelectedValue
                Dim sFiltro As String = "idpais=" & ipais & " Or idpais = 0"
                dtDepartamento.DefaultView.RowFilter = sFiltro
                CboDepartamento_SelectedIndexChanged(sender, e)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub TabDatos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabDatos.SelectedIndexChanged
        If Me.TabDatos.SelectedIndex = 0 Then
            Me.btnNuevo.Visible = False
            Me.AcceptButton = Me.BtnBuscarDir
            Me.txtdir.Focus()
        Else
            Me.btnNuevo.Visible = True
            Me.AcceptButton = Nothing
        End If
    End Sub

    Private Sub CboDistrito_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDistrito.SelectedIndexChanged
        If Not IsReference(Me.CboDistrito.SelectedValue) Then
            If Me.CboDistrito.SelectedValue = 0 Then
                Me.cboVia.SelectedValue = 0
                Me.txtVia.Text = ""
                Me.txtNumero.Text = ""
                Me.txtManzana.Text = ""
                Me.txtLote.Text = ""
                Me.cboNivel.SelectedValue = 0
                Me.txtNivel.Text = ""
                Me.cboZona.SelectedValue = 0
                Me.txtZona.Text = ""
                Me.cboClasificacion.SelectedValue = 0
                Me.txtClasificacion.Text = ""

                Me.cboVia.Enabled = False
                Me.txtVia.ReadOnly = True
                Me.txtNumero.ReadOnly = True
                Me.txtManzana.ReadOnly = True
                Me.txtLote.ReadOnly = True
                Me.cboNivel.Enabled = False
                Me.txtNivel.ReadOnly = True
                Me.cboZona.Enabled = False
                Me.txtZona.ReadOnly = True
                Me.cboClasificacion.Enabled = False
                Me.txtClasificacion.ReadOnly = True
            Else
                Me.cboVia.Enabled = True
                Me.txtVia.ReadOnly = False
                Me.txtNumero.ReadOnly = False
                Me.txtManzana.ReadOnly = False
                Me.txtLote.ReadOnly = False
                Me.cboNivel.Enabled = True
                Me.txtNivel.ReadOnly = False
                Me.cboZona.Enabled = True
                Me.txtZona.ReadOnly = False
                Me.cboClasificacion.Enabled = True
                Me.txtClasificacion.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub DtgDireccion_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DtgDireccion.CellDoubleClick
        'TxtDireccion.Text = DtgDireccion.Item("direccion", DtgDireccion.CurrentRow.Index()).Value.ToString()
        TxtReferencia.Text = DtgDireccion.Item("referencia", DtgDireccion.CurrentRow.Index()).Value.ToString()
        CboDepartamento.Text = DtgDireccion.Item("departamento", DtgDireccion.CurrentRow.Index()).Value.ToString()
        CboProvincia.Text = DtgDireccion.Item("provincia", DtgDireccion.CurrentRow.Index()).Value.ToString()
        CboDistrito.Text = DtgDireccion.Item("distrito", DtgDireccion.CurrentRow.Index()).Value.ToString()

        Me.cboVia.SelectedValue = DtgDireccion.CurrentRow.Cells("id_via").Value
        Me.cboZona.SelectedValue = DtgDireccion.CurrentRow.Cells("id_zona").Value
        Me.cboNivel.SelectedValue = DtgDireccion.CurrentRow.Cells("id_nivel").Value
        Me.cboClasificacion.SelectedValue = DtgDireccion.CurrentRow.Cells("id_clasificacion").Value

        Me.txtVia.Text = "" & DtgDireccion.CurrentRow.Cells("via").Value
        Me.txtNumero.Text = "" & DtgDireccion.CurrentRow.Cells("numero").Value
        Me.txtManzana.Text = "" & DtgDireccion.CurrentRow.Cells("manzana").Value
        Me.txtLote.Text = "" & DtgDireccion.CurrentRow.Cells("lote").Value
        Me.txtNivel.Text = "" & DtgDireccion.CurrentRow.Cells("nivel").Value
        Me.txtZona.Text = "" & DtgDireccion.CurrentRow.Cells("zona").Value
        Me.txtClasificacion.Text = "" & DtgDireccion.CurrentRow.Cells("clasificacion").Value

        'hlamas 24-01-2020
        Me.lblUrl.Text = "" & DtgDireccion.CurrentRow.Cells("url").Value
        Me.lblLatitud.Text = "" & DtgDireccion.CurrentRow.Cells("latitud").Value
        Me.lblLongitud.Text = "" & DtgDireccion.CurrentRow.Cells("longitud").Value

        intDireccion = DtgDireccion.CurrentRow.Cells("iddireccion_consignado").Value

        Me.TabDatos.SelectedIndex = 1
        Me.BtnAceptar.Focus()
    End Sub

    Sub Limpiar()
        intDireccion = 0
        Me.CboPais.SelectedValue = 4
        Me.CboDepartamento.SelectedValue = 15
        Me.CboProvincia.SelectedValue = 17
        Me.CboDistrito.SelectedValue = 0
        Me.cboVia.SelectedValue = 0
        Me.txtVia.Text = ""
        Me.txtNumero.Text = ""
        Me.txtManzana.Text = ""
        Me.txtLote.Text = ""
        Me.cboNivel.SelectedValue = 0
        Me.txtNivel.Text = ""
        Me.cboZona.SelectedValue = 0
        Me.txtZona.Text = ""
        Me.cboClasificacion.SelectedValue = 0
        Me.txtClasificacion.Text = ""
        Me.TxtReferencia.Text = ""
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Me.Limpiar()
        Me.CboDistrito.Focus()
        Me.CboDistrito.DroppedDown = True
        bSalir = False
    End Sub

    Private Sub btnGoogle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoogle.Click
        Dim frm As New frmGoogleMaps
        frm.Direccion = strDireccion
        frm.Url = Me.lblUrl.Text.Trim
        frm.ShowDialog()
        If frm.Latitud.Trim.Length > 0 Then
            Me.lblUrl.Text = frm.Url.Trim
            Me.lblLatitud.Text = frm.Latitud.Trim
            Me.lblLongitud.Text = frm.Longitud.Trim
        End If
    End Sub
End Class