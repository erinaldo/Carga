Public Class FrmCliente
#Region "Variables"
    Public dtDepartamento As DataTable
    Public dtProvincia As DataTable
    Public dtDistrito As DataTable
    Public dtTipoDocumento As DataTable
    Public dtComunicacion As DataTable
    Public departamento As Integer
    Public iCliente As String
    Public iApePaterno As String
    Public iApeMaterno As String
    Public provincia As Integer
    Public distrito As Integer
    Public pais As Integer
    Public itipodocumento As Integer
    Public iDocContacto As Integer
    Public iTipoMovil As Integer
    Public bNuevo As Boolean
    Dim bSalir As Boolean = True

    Public strDireccion As String
    Dim dtVia As DataTable
    Dim dtZona As DataTable
    Dim dtNivel As DataTable
    Dim dtClasificacion As DataTable
#End Region

#Region "FORMATO"
    Sub FormatoCliente()
        With Me.Dtgcliente
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
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.ScrollBars = ScrollBars.Both
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black
            .ReadOnly = True 'readonly cuando este false se puede editar
            '.Focus()
            Dim idpersona As New DataGridViewTextBoxColumn
            With idpersona
                .HeaderText = "idpersona"
                .Name = ""
                .DataPropertyName = "idpersona"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .Visible = False
                '.ReadOnly = True
            End With

            Dim razon_social As New DataGridViewTextBoxColumn
            With razon_social
                .HeaderText = "RazÛn Social"
                .Name = ""
                .DataPropertyName = "razon_social"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                '.Visible = False
                '.ReadOnly = True
            End With
            Dim idtipo_doc_identidad As New DataGridViewTextBoxColumn
            With idtipo_doc_identidad
                .HeaderText = "Tipo Documento"
                .Name = ""
                .DataPropertyName = "idtipo_doc_identidad"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Visible = False
                '.Width = 120
            End With
            Dim tipo_doc_identidad As New DataGridViewTextBoxColumn
            With tipo_doc_identidad
                .HeaderText = "Tipo Documento"
                .Name = ""
                .DataPropertyName = "tipo_doc_identidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
            End With

            Dim nu_docu_suna As New DataGridViewTextBoxColumn
            With nu_docu_suna
                .HeaderText = "N∫ Documento"
                .Name = ""
                .DataPropertyName = "nu_docu_suna"
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.Width = 120
            End With

            Dim nompre_persona As New DataGridViewTextBoxColumn
            With nompre_persona
                .HeaderText = "nompre_persona"
                .Name = ""
                .DataPropertyName = "nompre_persona"
                .Visible = False
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
            End With

            Dim apellido_paterno As New DataGridViewTextBoxColumn
            With apellido_paterno
                .HeaderText = "apellido_paterno"
                .Name = ""
                .DataPropertyName = "apellido_paterno"
                .Visible = False
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
            End With

            Dim apellido_materno As New DataGridViewTextBoxColumn
            With apellido_materno
                .HeaderText = "apellido_materno"
                .Name = ""
                .DataPropertyName = "apellido_materno"
                .Visible = False
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
            End With

            'agregar columna al grid
            ' fin de agregado  
            .Columns.AddRange(idpersona, razon_social, idtipo_doc_identidad, tipo_doc_identidad, nu_docu_suna, _
                              nompre_persona, apellido_paterno, apellido_materno)
        End With
    End Sub
#End Region

#Region "Validaciones"
    Public Function ValidarNumero(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[A-ZÒ—a-z0-9\b]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            ValidarNumero = True
        Else
            ValidarNumero = False
        End If
    End Function
    Public Function Validarcliente(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[A-ZÒ—a-z0-9\b\s]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            Validarcliente = True
        Else
            Validarcliente = False
        End If
    End Function
    Public Function ValidarLetra(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[A-ZÒ—a-z\b\s]")
        If re.IsMatch(txtStr.ToString()) Then
            ValidarLetra = True
        Else
            ValidarLetra = False
        End If
    End Function
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
#End Region

    Private Sub TxtNumero_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNumero.Enter
        TxtNumero.SelectAll()
    End Sub
    Private Sub TxtNumero_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNumero.GotFocus
        TxtNumero.SelectAll()
    End Sub
    'pasando la validacion al numero de documento
    Private Sub TxtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumero.KeyPress
        If Not Me.Valida(e.KeyChar) Then
            e.Handled = True
        End If
        'TxtNumero.SelectAll()
    End Sub
    Private Sub TxtCliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCliente.GotFocus
        TxtCliente.SelectAll()
    End Sub
    Private Sub TxtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCliente.KeyPress
        If Not Me.Validarcliente(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtapep_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtapep.GotFocus
        txtapep.SelectAll()
    End Sub
    Private Sub txtapep_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtapep.KeyPress
        If Not Me.ValidarLetra(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtapem_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtapem.GotFocus
        txtapem.SelectAll()
    End Sub
    Private Sub txtapem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtapem.KeyPress
        If Not Me.ValidarLetra(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtnom_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnom.GotFocus
        txtnom.SelectAll()
    End Sub
    Private Sub txtnom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnom.KeyPress
        If Not Me.ValidarLetra(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Sub mostrarcombos()
        Try
            Dim obj As New dtrecojo
            Dim ds As New DataSet
            ds = obj.InicioCliente

            dtTipoDocumento = ds.Tables(5)
            dtComunicacion = ds.Tables(4)

            'Llena Tipo de Cliente
            CboTipoCliente.DataSource = ds.Tables(6)
            CboTipoCliente.DisplayMember = "Procesos"
            CboTipoCliente.ValueMember = "idprocesos"
            CboTipoCliente.SelectedValue = 0 'itipoCliente

            'llena tipo de documento
            CboTipoDocumento.DataSource = dtTipoDocumento
            CboTipoDocumento.DisplayMember = "tipo_doc_identidad"
            CboTipoDocumento.ValueMember = "idtipo_doc_identidad"
            CboTipoDocumento.SelectedValue = itipodocumento

            CboDocContacto.DataSource = ds.Tables(5) 'dtd.DefaultView
            CboDocContacto.DisplayMember = "tipo_doc_identidad"
            CboDocContacto.ValueMember = "idtipo_doc_identidad"
            CboDocContacto.SelectedValue = iDocContacto

            CboMovil.DataSource = dtComunicacion
            CboMovil.DisplayMember = "tipo_comunicacion"
            CboMovil.ValueMember = "id"

            CboMovil.SelectedValue = iTipoMovil

            dtDepartamento = ds.Tables(1)
            dtProvincia = ds.Tables(2)
            dtDistrito = ds.Tables(3)
            'llena Pais
            CboPais.DataSource = ds.Tables(0).DefaultView
            CboPais.DisplayMember = "pais"
            CboPais.ValueMember = "idpais"

            CboPais.SelectedValue = pais
            CboDepartamento.DataSource = dtDepartamento
            CboDepartamento.DisplayMember = "departamento"
            CboDepartamento.ValueMember = "iddepartamento"

            CboDepartamento.SelectedValue = departamento

            CboProvincia.DataSource = dtProvincia
            CboProvincia.DisplayMember = "provincia"
            CboProvincia.ValueMember = "idprovincia"

            CboProvincia.SelectedValue = provincia

            CboDistrito.DataSource = dtDistrito
            CboDistrito.DisplayMember = "dsitrito"
            CboDistrito.ValueMember = "iddistrito"

            CboDistrito.SelectedValue = distrito
            obj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ChkCliente_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkCliente.CheckStateChanged
        If ChkCliente.Checked = True Then
            If TxtNumero.Text = "" And txtapep.Text = "" And txtapem.Text = "" Then
                MessageBox.Show("Ingrese Datos.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ChkCliente.Checked = False
                TxtNumero.Focus()
            Else
                CboDocContacto.SelectedValue = CboTipoDocumento.SelectedValue
                txtnrodocumento.Text = TxtNumero.Text
                txtnom.Text = TxtCliente.Text & " " & txtapep.Text & " " & txtapem.Text
                'desactivamos los textbox
                txtnrodocumento.Enabled = False
                txtnom.Enabled = False
                CboDocContacto.Enabled = False
                txtemail.Focus()
            End If
        Else
            CboDocContacto.Enabled = True
            CboDocContacto.SelectedValue = 3
            txtnrodocumento.Enabled = True
            txtnom.Enabled = True
            'limpia
            txtnrodocumento.Text = ""
            txtnom.Text = ""
            txtnrodocumento.Focus()
        End If
    End Sub
    Sub Limpiar()
        For Each obj As Control In Me.Controls
            If TypeOf obj Is TextBox Or TypeOf obj Is ComboBox Then
                obj.Text = ""
            End If
        Next
    End Sub
    Private Sub cmdpais_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboPais.SelectedIndexChanged
        If Not CboPais.SelectedValue Is Nothing And Not IsReference(CboPais.SelectedValue) Then
            Try
                Dim ipais As Integer = CboPais.SelectedValue
                Dim sFiltro As String = "idpais=" & ipais & " Or idpais = 0"
                dtDepartamento.DefaultView.RowFilter = sFiltro
                cmddepa_SelectedIndexChanged(sender, e)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub cmddepa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDepartamento.SelectedIndexChanged
        If Not CboDepartamento.SelectedValue Is Nothing And Not IsReference(CboDepartamento.SelectedValue) Then
            Try
                Dim ipais As Integer = CboPais.SelectedValue
                Dim iDepartamento As Integer = CboDepartamento.SelectedValue
                Dim sFiltro As String = "(iddepartamento=" & iDepartamento & " Or iddepartamento = 0)" & " and (idpais=" & ipais & " Or idpais = 0)"
                dtProvincia.DefaultView.RowFilter = sFiltro
                cmdprovi_SelectedIndexChanged(sender, e)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub cmdprovi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboProvincia.SelectedIndexChanged
        If Not CboProvincia.SelectedValue Is Nothing And Not IsReference(CboProvincia.SelectedValue) Then
            Try
                'llena distrito
                Dim iprovincia As Integer = CboProvincia.SelectedValue
                Dim iDepartamento As Integer = CboDepartamento.SelectedValue
                Dim iPais As Integer = CboPais.SelectedValue
                Dim sFiltro As String = "(idPais=" & iPais & " Or idpais = 0) and (iddepartamento=" & iDepartamento & " Or iddepartamento = 0) And (idprovincia = " & iprovincia & " Or idprovincia = 0)"
                dtDistrito.DefaultView.RowFilter = sFiltro
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    'Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dtgcliente.CellClick
    '    Dim frm1 As New FrmSolicitudRecojo
    '    Dim frm2 As New FrmCliente
    '    frm1.TxtCliente.Text = Dtgcliente.Item(1, Dtgcliente.CurrentRow.Index()).Value.ToString()
    '    frm1.TxtNumero.Text = Dtgcliente.Item(0, Dtgcliente.CurrentRow.Index()).Value.ToString()
    '    Me.Close()
    '    frm1.ShowDialog()
    '    frm1.Dispose()
    'End Sub
    Dim vAccionRecojo As Integer
    Private Sub FrmCliente_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Cursor = Cursors.Default
        If bNuevo Then
            Me.CboTipoDocumento.Focus()
        End If
    End Sub
    Private Sub FrmCliente_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not bSalir Then
            bSalir = True
            e.Cancel = True
        End If
    End Sub
    Private Sub FrmCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub FrmCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormatoCliente()
        mostrarcombos()

        Dim obj As New dtrecojo
        Dim ds As New DataSet
        ds = obj.ListarDireccion
        dtVia = ds.Tables(4)
        dtZona = ds.Tables(5)
        dtNivel = ds.Tables(6)
        dtClasificacion = ds.Tables(7)

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

        If Me.CboTipoDocumento.SelectedValue = 1 Then
            Me.LblApep.Visible = False
            Me.LblApeM.Visible = False
            Me.txtapep.Visible = False
            Me.txtapem.Visible = False
            Me.LblCliente.Top = 47
            Me.TxtCliente.Top = 47
        End If
        If bNuevo Then
            Me.TabCliente.SelectedIndex = 1
        End If
        For Each obj1 As Control In Me.TabCliente.TabPages(0).Controls
            If TypeOf obj1 Is TextBox Then
                txtrazon.Focus()
                txtrazon.Refresh()
            End If
        Next
        txtrazon.Focus()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtrazon.Focus()
    End Sub

    Private Sub txtrazon_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrazon.GotFocus
        Me.txtrazon.SelectAll()
    End Sub
    Private Sub txtrazon_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrazon.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.BtnBuscar.Focus()
        End If
    End Sub
    Private Sub txtfijo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfijo.GotFocus
        txtfijo.SelectAll()
    End Sub
    Private Sub txtfijo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfijo.KeyPress
        If Not Me.Valida(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub CboTipoDocumento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboTipoDocumento.GotFocus
        CboTipoDocumento.SelectAll()
    End Sub
    Private Sub CboTipoDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoDocumento.SelectedIndexChanged
        If Not IsReference(Me.CboTipoDocumento.SelectedValue) Then
            If Me.CboTipoDocumento.SelectedValue = 1 Then
                Me.TxtNumero.MaxLength = 11
                Me.LblCliente.Text = "RazÛn Soc."
                Me.LblApep.Visible = False
                Me.LblApeM.Visible = False
                Me.txtapep.Visible = False
                Me.txtapem.Visible = False
                Me.LblCliente.Top = 47
                Me.TxtCliente.Top = 47
                Me.txtapep.Text = ""
                Me.txtapem.Text = ""
            ElseIf Me.CboTipoDocumento.SelectedValue = 3 Then
                Me.TxtNumero.MaxLength = 8
                Me.LblCliente.Text = "Nombres"
                Me.LblCliente.Top = 38
                Me.TxtCliente.Top = 36
                Me.LblApep.Visible = True
                Me.LblApeM.Visible = True
                Me.txtapep.Visible = True
                Me.txtapem.Visible = True
            Else
                Me.TxtNumero.MaxLength = 20
                Me.LblCliente.Text = "Nombres"
                Me.LblCliente.Top = 37
                Me.TxtCliente.Top = 37
                Me.LblApep.Visible = True
                Me.LblApeM.Visible = True
                Me.txtapep.Visible = True
                Me.txtapem.Visible = True
            End If
        End If
    End Sub
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        bSalir = True
    End Sub
    Private Sub txtmovil_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmovil.GotFocus
        txtmovil.SelectAll()
    End Sub
    Private Sub txtmovil_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmovil.KeyPress
        If Not Me.Valida(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtnrodocumento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnrodocumento.GotFocus
        txtnrodocumento.SelectAll()
    End Sub
    Private Sub txtnrodocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnrodocumento.KeyPress
        If Not Me.Valida(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub CboDocContacto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDocContacto.SelectedIndexChanged
        If Not IsReference(Me.CboDocContacto.SelectedValue) Then
            If Me.CboDocContacto.SelectedValue = 1 Then
                Me.txtnrodocumento.MaxLength = 11
            ElseIf Me.CboDocContacto.SelectedValue = 3 Then
                Me.txtnrodocumento.MaxLength = 8
            Else
                Me.txtnrodocumento.MaxLength = 20
            End If
        End If
    End Sub
    Public itipoCliente As String
    'Private Sub txtrazon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrazon.TextChanged
    '    Dim obj As New dtrecojo
    '    Dim buscli As String = Me.txtrazon.Text
    '    Dim ds As DataSet = obj.busca_cli(buscli)
    '    Dim razon As String = ds.Tables(0).Rows.Count
    '    If razon = 0 Then
    '        MessageBox.Show("No existe el Cliente.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    Else
    '        FormatoCliente()
    '        Me.Dtgcliente.DataSource = ds.Tables(0)
    '        txtrazon.Focus()
    '        obj = Nothing
    '    End If
    'End Sub
    Private Sub CboTipoCliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboTipoCliente.GotFocus
        CboTipoCliente.SelectAll()
    End Sub
    Private Sub CboDistrito_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboDistrito.GotFocus
        CboDistrito.SelectAll()
    End Sub
    Private Sub CboMovil_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMovil.SelectedIndexChanged
        If Not IsReference(Me.CboMovil.SelectedValue) Then
            If Me.CboMovil.SelectedValue = 0 Then
                Me.txtmovil.Text = ""
                Me.txtmovil.Enabled = False
            Else
                Me.txtmovil.Enabled = True
            End If
        End If
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Try
            Me.Cursor = Cursors.AppStarting
            Dim obj As New dtrecojo
            Dim buscli As String = Me.txtrazon.Text.Trim
            Dim ds As DataSet = obj.busca_cli(buscli)
            Dim razon As String = ds.Tables(0).Rows.Count
            If razon = 0 Then
                Me.Dtgcliente.DataSource = Nothing
                Me.Cursor = Cursors.Default
                MessageBox.Show("No se Encontraron Coincidencias.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.BtnGrabar.Enabled = False
                Me.txtrazon.Focus()
                'mostrarcombos()
            Else
                FormatoCliente()
                Me.Dtgcliente.DataSource = ds.Tables(0)
                Me.BtnGrabar.Enabled = True
            End If
            obj = Nothing
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If Me.TabCliente.SelectedIndex = 0 Then
            TxtNumero.Text = Me.Dtgcliente.CurrentRow.Cells(1).Value
            bSalir = True
            Return
        End If

        Dim obj As New dtrecojo
        Dim snum As String = Me.TxtNumero.Text
        If CboTipoDocumento.SelectedValue = 1 Then
            If Not fnValidarRUC(TxtNumero.Text) Then
                MessageBox.Show("El RUC no es V·lido.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                TxtNumero.Focus()
                Return
            End If

            Dim ds As DataSet = obj.Listar_cli(snum)
            Dim resp As Integer = ds.Tables(0).Rows.Count
            If resp = 1 Then
                MessageBox.Show("EL N∫ de Documento ya Existe.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                TxtNumero.Focus()
                Return
            End If

        ElseIf CboTipoDocumento.SelectedValue = 3 Then
            If TxtNumero.Text.Length <> 8 Then
                MessageBox.Show("El DNI no es V·lido.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                TxtNumero.Focus()
                Return
            End If
            Dim ds As DataSet = obj.Listar_cli(snum)
            Dim resp As Integer = ds.Tables(0).Rows.Count
            If resp = 1 Then
                MessageBox.Show("EL N∫ de Documento ya Existe.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                TxtNumero.Focus()
                Return
            End If

            If Me.TxtCliente.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nombres Del Cliente.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                TxtCliente.Text = TxtCliente.Text.Trim()
                TxtCliente.Focus()
                Return
            End If
            If Me.txtapep.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Apellido Paterno.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                txtapep.Text = txtapep.Text.Trim()
                txtapep.Focus()
                Return
            End If

            If Me.txtapem.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Apellido Materno.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                txtapem.Text = txtapem.Text.Trim()
                txtapem.Focus()
                Return
            End If

        Else
            If TxtNumero.Text.Length < 6 Then
                MessageBox.Show("El N∫ de Documento no es V·lido.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                TxtNumero.Focus()
                Return
            End If
        End If
        If Me.TxtCliente.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese " & IIf(CboTipoDocumento.SelectedValue = 1, "RazÛn Social del Cliente", "Nombres del Cliente"), "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bSalir = False
            TxtCliente.Text = TxtCliente.Text.Trim()
            TxtCliente.Focus()
            Return
        End If
        If CboDocContacto.SelectedValue = 1 Then
            If Not fnValidarRUC(txtnrodocumento.Text) Then
                MessageBox.Show("El RUC no es V·lido.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                txtnrodocumento.Focus()
                Return
            End If
        ElseIf CboDocContacto.SelectedValue = 3 Then
            If txtnrodocumento.Text.Length <> 8 Then
                MessageBox.Show("El DNI no es V·lido.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                txtnrodocumento.Text = txtnrodocumento.Text.Trim()
                txtnrodocumento.Focus()
                Return
            End If
        Else
            If txtnrodocumento.Text.Length < 6 Then
                MessageBox.Show("El N∫ de Documento no es V·lido.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                txtnrodocumento.Text = txtnrodocumento.Text.Trim()
                txtnrodocumento.Focus()
                Return
            End If
        End If

        If Me.txtnrodocumento.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese N∫ de Documento del Contacto", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bSalir = False
            txtnrodocumento.Text = txtnrodocumento.Text.Trim()
            txtnrodocumento.Focus()
            Return
        End If
        If Me.txtnom.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Nombres del Contacto", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bSalir = False
            txtnom.Text = txtnom.Text.Trim()
            txtnom.Focus()
            Return
        End If
        'Dim cadena As Integer
        'IIf((CboTipoDocumento.SelectedValue = 1), TxtCliente.Text, Str(TxtCliente.Text)) '
        TxtCliente.Tag = TxtCliente.Text
        iCliente = TxtCliente.Tag 'IIf((CboTipoDocumento.SelectedValue = 1), TxtCliente.Text, 
        txtapep.Tag = txtapep.Text
        iApePaterno = txtapep.Tag 'IIf((CboTipoDocumento.SelectedValue = 1), txtapep.Text = "", 
        txtapem.Tag = txtapem.Text
        iApeMaterno = txtapem.Tag 'IIf((CboTipoDocumento.SelectedValue = 1), txtapem.Text = "", 
        txtnrodocumento.Tag = txtnrodocumento.Text
        If Me.txtemail.Text.Trim.Length > 0 Then
            If Not Me.Validaremail(txtemail.Text) Then
                MessageBox.Show("Ingrese Email V·lido.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                txtemail.Text = txtemail.Text.Trim()
                txtemail.Focus()
                Return
            Else
                txtemail.Text = txtemail.Text.Trim()
                txtfijo.Focus()
            End If
        End If

        If Me.txtfijo.Text.Trim.Length = 0 And Me.txtmovil.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese un N∫ de TelÈfono Fijo o Movil", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bSalir = False
            txtfijo.Text = txtfijo.Text.Trim()
            txtfijo.Focus()
            Return
        End If

        If Me.txtfijo.Text.Trim.Length > 0 Then
            If Me.txtfijo.Text.Trim.Length < 6 Then
                MessageBox.Show("Ingrese N∫ TelÈfono Fijo V·lido.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                Me.txtfijo.Focus()
                Return
            End If
        End If

        If Me.CboMovil.SelectedValue > 0 Then
            If Me.txtmovil.Text.Trim.Length < 9 Then
                MessageBox.Show("Ingrese N∫ TelÈfono MÛvil V·lido.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                Me.txtmovil.Focus()
                Return
            End If
            If Val(Me.txtmovil.Text.Trim.Substring(0, 1)) < 2 Then
                MessageBox.Show("Ingrese N∫ TelÈfono MÛvil V·lido.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                Me.txtmovil.Focus()
                Return
            End If
        End If

        If Me.CboPais.SelectedValue = 0 Then
            MessageBox.Show("Seleccione PaÌs de la DirecciÛn de Recojo", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bSalir = False
            Me.CboPais.Focus()
            Return
        End If

        If Me.CboDepartamento.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Departamento de la DirecciÛn de Recojo", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bSalir = False
            Me.CboDepartamento.Focus()
            Return
        End If

        If Me.CboProvincia.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Provincia de la DirecciÛn de Recojo", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bSalir = False
            Me.CboProvincia.Focus()
            Return
        End If

        If Me.CboDistrito.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Distrito de la DirecciÛn de Recojo", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bSalir = False
            Me.CboDistrito.Focus()
            Return
        End If

        If Me.cboVia.SelectedValue = 0 And cboZona.SelectedValue = 0 Then 'cambio 03102011
            MessageBox.Show("Seleccione Tipo de VÌa", "Tit·n", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bSalir = False
            Me.cboVia.Focus()
            Return
        End If

        'If Me.TxtVia.Text.Trim.Length = 0 Then
        If Me.txtVia.Text.Trim.Length = 0 And cboZona.SelectedValue = 0 Then 'cambio 03102011
            MessageBox.Show("Ingrese Nombre de la VÌa", "Tit·n", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bSalir = False
            Me.txtVia.Text = ""
            Me.txtVia.Focus()
            Return
        End If

        If Me.txtNumero2.Text.Trim.Length = 0 And Me.txtManzana.Text.Trim.Length = 0 And Me.txtLote.Text.Trim.Length = 0 Then
            Dim sMje As String = ""
            Dim i As Integer
            'If Me.TxtNumero2.Text.Trim.Length = 0 Then
            If Me.txtNumero2.Text.Trim.Length = 0 And cboVia.SelectedValue > 0 Then 'cambio 03102011
                sMje = "N∫ de la VÌa"
                i = 1
            ElseIf Me.txtManzana.Text.Trim.Length = 0 Then
                sMje = "Manzana de la VÌa"
                i = 2
            Else
                sMje = "Lote de la VÌa"
                i = 3
            End If
            MessageBox.Show("Ingrese " & sMje, "Tit·n", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bSalir = False
            If Me.txtManzana.Text.Trim.Length = 0 Then Me.txtManzana.Text = ""
            If Me.txtLote.Text.Trim.Length = 0 Then Me.txtLote.Text = ""

            If i = 1 Then
                Me.txtNumero2.Focus()
            ElseIf i = 2 Then
                Me.txtManzana.Focus()
            Else
                Me.txtLote.Focus()
            End If
            Return
        End If

        If Me.txtNumero2.Text.Trim.Length = 0 And (Me.txtManzana.Text.Trim.Length = 0 Or Me.txtLote.Text.Trim.Length = 0) Then
            Dim sMje As String = ""
            Dim i As Integer
            If Me.txtManzana.Text.Trim.Length = 0 Then
                sMje = "Manzana de la VÌa"
                i = 1
            Else
                sMje = "Lote de la VÌa"
                i = 2
            End If
            MessageBox.Show("Ingrese " & sMje, "Tit·n", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            MessageBox.Show("Ingrese Nombre del Nivel", "Tit·n", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bSalir = False
            Me.txtNivel.Text = ""
            Me.txtNivel.Focus()
            Return
        End If

        If Me.cboZona.SelectedValue > 0 AndAlso Me.txtZona.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Nombre de la Zona", "Tit·n", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bSalir = False
            Me.txtZona.Text = ""
            Me.txtZona.Focus()
            Return
        End If

        If Me.cboClasificacion.SelectedValue > 0 AndAlso Me.txtClasificacion.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Nombre de la ClasificaciÛn", "Tit·n", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bSalir = False
            Me.txtClasificacion.Text = ""
            Me.txtClasificacion.Focus()
            Return
        End If

        Dim sDireccion As String = IIf(cboVia.SelectedValue = 0, "", cboVia.Text) & " " & IIf(cboVia.SelectedValue = 0, "", txtVia.Text.Trim) & " "
        If cboVia.SelectedValue > 0 And txtNumero2.Text.Trim.Length > 0 Then
            sDireccion &= txtNumero2.Text.Trim & " "
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

        'If Me.txtdireccion.Text.Trim.Length = 0 Then
        '    MessageBox.Show("Ingrese DirecciÛn de Recojo", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    bSalir = False
        '    txtdireccion.Text = txtdireccion.Text.Trim()
        '    txtdireccion.Focus()
        '    Return
        'End If
        bSalir = True
    End Sub
    Private Sub TabCliente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabCliente.SelectedIndexChanged
        If TabCliente.SelectedIndex = 0 Then
            Me.AcceptButton = BtnBuscar
            If Me.Dtgcliente.Rows.Count = 0 Then
                Me.BtnGrabar.Enabled = False
            Else
                Me.BtnGrabar.Enabled = True
            End If
            Me.txtrazon.Focus()
        Else
            Me.AcceptButton = Nothing
            Me.BtnGrabar.Enabled = True
            Me.CboTipoDocumento.Focus()
        End If
    End Sub

    Private Sub Dtgcliente_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtgcliente.DoubleClick
        ''Pasa al Otro Formulario
        ''Dim frm As New FrmSolicitudRecojo
        ''frm.itipodocumento = Dtgcliente.Item(2, Dtgcliente.CurrentRow.Index()).Value.ToString()
        ''frm.TxtCliente.Text = Dtgcliente.Item(1, Dtgcliente.CurrentRow.Index()).Value.ToString()
        ''frm.TxtNumero.Text = Dtgcliente.Item(3, Dtgcliente.CurrentRow.Index()).Value.ToString()
        ' '' frm.Codigopersona = Dtgcliente.Item(0, Dtgcliente.CurrentRow.Index()).Value.ToString().ToString
        ''Me.Hide()
        ''Pasa al Mismo Formulario
        'CboTipoDocumento.SelectedValue = Dtgcliente.Item(1, Dtgcliente.CurrentRow.Index()).Value.ToString()
        'TxtCliente.Text = Dtgcliente.Item(0, Dtgcliente.CurrentRow.Index()).Value.ToString()
        'TxtNumero.Text = Dtgcliente.Item(2, Dtgcliente.CurrentRow.Index()).Value.ToString()
        'Me.TabCliente.SelectedIndex = 1
        'Me.CboDocContacto.Focus()
        If Dtgcliente.Rows.Count > 0 Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.BtnGrabar_Click(sender, e)
        End If
    End Sub

    Private Sub txtrazon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrazon.TextChanged
        Me.BtnBuscar.Enabled = txtrazon.Text.Trim.Length > 0
    End Sub

    Private Sub CboDistrito_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDistrito.SelectedIndexChanged
        If Not IsReference(Me.CboDistrito.SelectedValue) Then
            If Me.CboDistrito.SelectedValue = 0 Then
                Me.cboVia.SelectedValue = 0
                Me.txtVia.Text = ""
                Me.txtNumero2.Text = ""
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
                Me.txtNumero2.ReadOnly = True
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
                Me.txtNumero2.ReadOnly = False
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
End Class