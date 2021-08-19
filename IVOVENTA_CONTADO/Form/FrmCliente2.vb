Public Class FrmCliente2
    Public dtDepartamento, dtDepartamento2 As DataTable
    Public dtProvincia, dtProvincia2 As DataTable
    Public dtDistrito, dtDistrito2 As DataTable

    '----
    Public bClienteNuevo, bClienteModificado As Boolean
    Public bDireccionModificada As Boolean
    Public bContactoNuevo, bContactoModificado As Boolean
    '---

    Dim sNumero, sCliente, sNombres, sAp, sAm, sApCont, sAmCont, sTelfCliente, sEmail As String
    Dim bClienteCredito As Boolean
    Dim iTipo As Integer
    Dim iDepartamento, iProvincia, iDistrito, iId_via, iId_nivel, iId_Zona, iId_Clasificacion As Integer
    Dim sVia, sNumero2, sManzana, sLote, sNivel, sClasificacion, sZona As String
    Dim sNumero3, sContacto, sNombresCont As String
    Dim iTipo2 As Integer
    Dim bEsCliente As Boolean

    Public iFicha As Integer
    Public iTipoEntrega As Integer
    Public iProducto As Integer

    Dim dt As DataTable
    Dim iOpcion As Integer

    Public intOpcion As Integer
    Dim bSalir As Boolean = True

#Region "Propiedades"
    Private intTipoDocumento As Integer
    Public Property TipoDocumento() As Integer
        Get
            Return intTipoDocumento
        End Get
        Set(ByVal value As Integer)
            intTipoDocumento = value
        End Set
    End Property

#End Region

    Sub Formato()
        With Me.dgvBuscar
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            '.AutoGenerateColumns = False
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.ScrollBars = ScrollBars.Both
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .ReadOnly = True

            Dim idpersona As New DataGridViewTextBoxColumn
            With idpersona
                .HeaderText = "idpersona"
                .Name = "idpersona"
                .DataPropertyName = "idpersona"
                .Visible = False
            End With

            Dim razon_social As New DataGridViewTextBoxColumn
            With razon_social
                .HeaderText = "Razón Social"
                .Name = "razon_social"
                .DataPropertyName = "razon_social"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            Dim telefono As New DataGridViewTextBoxColumn
            With telefono
                .HeaderText = "Teléfono"
                .Name = "telefono"
                .DataPropertyName = "telefono"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            Dim monto_base As New DataGridViewTextBoxColumn
            With monto_base
                .HeaderText = "monto_base"
                .Name = "monto_base"
                .DataPropertyName = "monto_base"
                .Visible = False
            End With

            Dim porcentage_descuento As New DataGridViewTextBoxColumn
            With porcentage_descuento
                .HeaderText = "porcentage_descuento"
                .Name = "porcentage_descuento"
                .DataPropertyName = "porcentage_descuento"
                .Visible = False
            End With

            Dim idtipo_doc_identidad As New DataGridViewTextBoxColumn
            With idtipo_doc_identidad
                .HeaderText = "Tipo Documento"
                .Name = "tipo"
                .DataPropertyName = "tipo"
                .Visible = False
            End With

            Dim tipo_doc_identidad As New DataGridViewTextBoxColumn
            With tipo_doc_identidad
                .HeaderText = "Tipo Documento"
                .Name = "tipo_doc_identidad"
                .DataPropertyName = "tipo_doc_identidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            Dim nu_docu_suna As New DataGridViewTextBoxColumn
            With nu_docu_suna
                .HeaderText = "Nº Documento"
                .Name = "nu_docu_suna"
                .DataPropertyName = "nu_docu_suna"
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With

            Dim id_proceso As New DataGridViewTextBoxColumn
            With id_proceso
                .HeaderText = "id_proceso"
                .Name = "id_proceso"
                .DataPropertyName = "id_proceso"
                .Visible = False
            End With
            .Columns.AddRange(tipo_doc_identidad, nu_docu_suna, razon_social, idpersona, telefono, monto_base, porcentage_descuento, idtipo_doc_identidad, id_proceso)
        End With
    End Sub

    Private Sub FrmIngresoContado_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Cursor = Cursors.Default
        If iFicha = 0 Then
            BtnNuevo.Visible = False
            bClienteNuevo = True
            Me.txtrazon.Focus()
        ElseIf iFicha = 1 Then
            BtnNuevo.Visible = True
            Me.LblBuscar.Text = "Cliente"
            If bClienteNuevo Then
                Me.CboTipoDocumento.Focus()
            Else
                Me.txtTelefono.Focus()
            End If
        End If
    End Sub

    Private Sub FrmIngresoContado_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not bSalir Then
            bSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmIngresoContado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Sub Inicio()
        Try
            RemoveHandler CboTipoDocumento.SelectedIndexChanged, AddressOf CboTipoDocumento_SelectedIndexChanged
            Dim obj As New dtoVentaCargaContado
            Dim ds As DataSet = obj.Inicio(dtoUSUARIOS.iIDAGENCIAS, 0, 1)

            With CboTipoDocumento
                .DataSource = ds.Tables(8)
                .DisplayMember = "tipo_doc_identidad"
                .ValueMember = "idtipo_doc_identidad"
                If intOpcion = 0 Then
                    .SelectedValue = 3
                Else
                    .SelectedValue = TipoDocumento
                    CboTipoDocumento_SelectedIndexChanged(Nothing, Nothing)
                End If
            End With

            Dim dtTipoDocumento As DataTable = ds.Tables(8).Copy
            With CboDocContacto
                .DataSource = dtTipoDocumento
                .DisplayMember = "tipo_doc_identidad"
                .ValueMember = "idtipo_doc_identidad"
                .SelectedValue = 0
            End With

            AddHandler CboTipoDocumento.SelectedIndexChanged, AddressOf CboTipoDocumento_SelectedIndexChanged

            With Me.CboVia
                .DataSource = ds.Tables(0)
                .DisplayMember = "via"
                .ValueMember = "id_via"
            End With

            With Me.CboZona
                .DataSource = ds.Tables(1)
                .DisplayMember = "zona"
                .ValueMember = "id_zona"
            End With

            With Me.CboNivel
                .DataSource = ds.Tables(2)
                .DisplayMember = "nivel"
                .ValueMember = "id_nivel"
            End With
            With Me.CboClasificacion
                .DataSource = ds.Tables(3)
                .DisplayMember = "clasificacion"
                .ValueMember = "id_clasificacion"
            End With
            dtDepartamento = ds.Tables(4)
            With Me.CboDepartamento
                .DataSource = dtDepartamento
                .DisplayMember = "departamento"
                .ValueMember = "iddepartamento"
            End With

            dtProvincia = ds.Tables(5)
            With Me.CboProvincia
                CboProvincia.DataSource = dtProvincia
                CboProvincia.DisplayMember = "provincia"
                CboProvincia.ValueMember = "idprovincia"
            End With

            dtDistrito = ds.Tables(6)
            With Me.CboDistrito
                CboDistrito.DataSource = dtDistrito
                CboDistrito.DisplayMember = "dsitrito"
                CboDistrito.ValueMember = "iddistrito"
            End With

            Dim sender As Object
            Dim e As New EventArgs
            If ds.Tables(7).Rows.Count > 0 And iProducto <> 6 Then
                CboDepartamento.SelectedValue = ds.Tables(7).Rows(0).Item("dpto")
                If CboDepartamento.SelectedIndex < 0 Then CboDepartamento.SelectedValue = 0

                CboProvincia.SelectedValue = ds.Tables(7).Rows(0).Item("prov")
                If CboProvincia.SelectedIndex < 0 Then CboProvincia.SelectedValue = 0

                CboDepartamento_SelectedIndexChanged(sender, e)
                CboProvincia_SelectedIndexChanged(sender, e)
            Else
                CboDepartamento_SelectedIndexChanged(sender, e)
                CboProvincia_SelectedIndexChanged(sender, e)
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub CboDepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDepartamento.SelectedIndexChanged
        If Not IsReference(CboDepartamento.SelectedValue) Then
            Dim sFiltro As String = "iddepartamento=" & CboDepartamento.SelectedValue & " or iddepartamento=0"
            dtProvincia.DefaultView.RowFilter = sFiltro
        End If
    End Sub

    Private Sub CboProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboProvincia.SelectedIndexChanged
        If Not IsReference(CboProvincia.SelectedValue) Then
            Dim sFiltro As String = "(iddepartamento=" & CboDepartamento.SelectedValue & " or iddepartamento=0) and (idprovincia=" & CboProvincia.SelectedValue & " or idprovincia=0)"
            dtDistrito.DefaultView.RowFilter = sFiltro
        End If
    End Sub

    Private Sub CboTipoDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoDocumento.SelectedIndexChanged
        If Not IsReference(Me.CboTipoDocumento.SelectedValue) Then
            Me.TxtNumero.Enabled = True
            If Me.CboTipoDocumento.SelectedValue = 1 Then
                Me.TxtNumero.MaxLength = 11
                Me.TxtCliente.Text = ""
                Me.LblCliente.Text = "Raz. Soc."
                Me.LblAPCliente.Visible = False
                Me.LblAMCliente.Visible = False
                Me.TxtAPCliente.Visible = False
                Me.TxtAMCliente.Visible = False
                Me.LblCliente.Top = 50
                Me.TxtCliente.Top = 47
                Me.TxtAPCliente.Text = ""
                Me.TxtAMCliente.Text = ""
                If intOpcion = 0 Then
                    Me.GrbContacto.Enabled = True
                End If
                Me.CboDocContacto.SelectedValue = 0
            Else
                Me.LblCliente.Text = "Nombres"
                Me.LblCliente.Top = 37
                Me.TxtCliente.Top = 34
                Me.LblAPCliente.Visible = True
                Me.LblAMCliente.Visible = True
                Me.TxtAPCliente.Visible = True
                Me.TxtAMCliente.Visible = True

                If Me.CboTipoDocumento.SelectedValue = 3 Then
                    Me.TxtNumero.MaxLength = 8
                ElseIf Me.CboTipoDocumento.SelectedValue = 9 Then
                    Me.TxtNumero.Text = ""
                    Me.TxtNumero.Enabled = False
                    Me.txtTelefono.Focus()
                Else
                    Me.TxtNumero.MaxLength = 20
                End If
                Me.GrbContacto.Enabled = False
                Me.CboDocContacto.SelectedValue = 0
                sNumero3 = ""
                sContacto = ""
                sApCont = ""
                sAmCont = ""
                Me.ChkCliente.Checked = False
            End If
            Me.TxtCliente.Text = Me.TxtCliente.Text.Trim
        End If
    End Sub

    Private Sub TxtNumero_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNumero.Enter
        TxtNumero.SelectAll()
    End Sub

    Private Sub TxtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumero.KeyPress
        If Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtCliente_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCliente.Enter
        TxtCliente.SelectAll()
    End Sub

    Private Sub TxtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCliente.KeyPress
        If Me.CboTipoDocumento.SelectedValue = 1 Then
            'hlamas 15-11-2016
            If Me.TxtNumero.Text.Trim.Length>0 andalso Me.TxtNumero.Text.Trim.Substring(0, 1) = "1" Then
                If ValidarNumero(e.KeyChar) Then
                    e.Handled = True
                End If
            Else
                If Not ValidarLetraNumero(e.KeyChar) Then
                    e.Handled = True
                End If
            End If
        Else
            If Not ValidarLetra(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtapep_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAPCliente.Enter
        TxtAPCliente.SelectAll()
    End Sub

    Private Sub TextBox1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEmail.Enter
        TxtEmail.SelectAll()
    End Sub

    Private Sub txtapep_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAPCliente.KeyPress
        If Not ValidarLetra(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtapem_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAMCliente.Enter
        TxtAMCliente.SelectAll()
    End Sub

    Private Sub txtapem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAMCliente.KeyPress
        If Not ValidarLetra(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtVia_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVia.Enter
        TxtVia.SelectAll()
    End Sub

    Private Sub TxtNumero2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNumero2.Enter
        TxtNumero2.SelectAll()
    End Sub

    Private Sub TxtManzana_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtManzana.Enter
        TxtManzana.SelectAll()
    End Sub

    Private Sub TxtLote_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtLote.Enter
        TxtLote.SelectAll()
    End Sub

    Private Sub TxtNivel_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNivel.Enter
        TxtNivel.SelectAll()
    End Sub

    Private Sub TxtZona_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtZona.Enter
        TxtZona.SelectAll()
    End Sub

    Private Sub TxtClasificacion_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtClasificacion.Enter
        TxtClasificacion.SelectAll()
    End Sub

    Private Sub txtnrodocumento_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnrodocumento.Enter
        txtnrodocumento.SelectAll()
    End Sub

    Private Sub txtnrodocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnrodocumento.KeyPress
        If Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtnom_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtContacto.Enter
        TxtContacto.SelectAll()
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Try
            If Me.txtrazon.Text.Trim.Length > 0 Then
                Me.Cursor = Cursors.AppStarting
                Dim sItem As String = Me.txtrazon.Text.Trim
                Dim obj As New dtoVentaCargaContado
                Dim ds As New DataSet
                ds = obj.BuscarCliente(sItem, 2)
                Me.dgvBuscar.DataSource = ds.Tables(0)
                Me.Cursor = Cursors.Default

                If Me.dgvBuscar.Rows.Count = 0 Then
                    MessageBox.Show("No se Encontraron Coincidencias.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.BtnAceptar.Enabled = False
                Else
                    Me.BtnAceptar.Enabled = True
                End If
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtrazon_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrazon.Enter
        txtrazon.SelectAll()
    End Sub

    Private Sub txtrazon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrazon.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            BtnBuscar_Click(sender, e)
        End If
    End Sub

    Private Sub txtrazon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrazon.TextChanged
        Me.BtnBuscar.Enabled = txtrazon.Text.Trim.Length > 0
    End Sub

    Private Sub FrmIngresoContado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Formato()
            Me.Inicio()
            If sNumero Is Nothing Then sNumero = ""
            If iTipo > 0 Then
                Me.Mostrar()
            Else
                Me.Inicializar()
            End If
            If intOpcion = 0 Then
                If Me.CboTipoDocumento.SelectedValue = 1 Then
                    Me.GrbContacto.Enabled = True
                Else
                    Me.GrbContacto.Enabled = False
                End If
            End If

            Me.TabCliente.SelectedIndex = iFicha
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TabCliente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabCliente.SelectedIndexChanged
        If TabCliente.SelectedIndex = 0 Then
            If Me.dgvBuscar.Rows.Count = 0 Then
                Me.BtnAceptar.Enabled = False
            Else
                Me.BtnAceptar.Enabled = True
            End If
            Me.BtnNuevo.Visible = False
            Me.txtrazon.Focus()
        Else
            Me.BtnAceptar.Enabled = True
            Me.BtnNuevo.Visible = True
            Me.CboTipoDocumento.Focus()
        End If
    End Sub

    Private Sub ChkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCliente.CheckedChanged
        If ChkCliente.Checked = True Then
            Dim sMje As String = ""
            Dim i As Integer = 0
            If TxtNumero.Text.Trim.Length = 0 And CboTipoDocumento.SelectedValue <> 9 Then
                sMje = "Nº de Documento."
                i = 1
            ElseIf TxtCliente.Text.Trim.Length = 0 Then
                sMje = "Nombre o Razón Social."
                i = 2
            ElseIf TxtAPCliente.Text.Trim.Length = 0 And CboTipoDocumento.SelectedValue <> 1 Then
                sMje = "Apellido Paterno."
                i = 3
            ElseIf TxtAMCliente.Text.Trim.Length = 0 And CboTipoDocumento.SelectedValue = 3 Then
                sMje = "Apellido Materno."
                i = 4
            End If

            If i > 0 Then
                MessageBox.Show("Ingrese " & sMje & " ", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ChkCliente.Checked = False

                If TxtAMCliente.Text.Trim.Length = 0 Then TxtAMCliente.Text = ""
                If i = 1 Then
                    TxtNumero.Text = ""
                    TxtNumero.Focus()
                ElseIf i = 2 Then
                    TxtCliente.Text = ""
                    TxtCliente.Focus()
                ElseIf i = 3 Then
                    TxtAPCliente.Text = ""
                    TxtAPCliente.Focus()
                ElseIf i = 4 Then
                    TxtAMCliente.Text = ""
                    TxtAMCliente.Focus()
                End If
            Else
                CboDocContacto.SelectedValue = CboTipoDocumento.SelectedValue
                txtnrodocumento.Text = TxtNumero.Text
                TxtContacto.Text = TxtCliente.Text.Trim
                'desactivamos los textbox
                txtnrodocumento.Enabled = False
                TxtContacto.Enabled = False
                CboDocContacto.Enabled = False
                If CboTipoDocumento.SelectedValue = 1 Then
                    LblAPContacto.Visible = False
                    LblAMContacto.Visible = False
                    TxtAPContacto.Visible = False
                    TxtAMContacto.Visible = False
                    TxtAPContacto.Text = ""
                    TxtAMContacto.Text = ""
                End If

            End If
        Else
            CboDocContacto.Enabled = True
            CboDocContacto.SelectedValue = IIf(Me.CboTipoDocumento.SelectedValue = 1, 0, 0)
            txtnrodocumento.Enabled = True
            TxtContacto.Enabled = True
            '-------
            sNumero3 = ""
            sContacto = ""
            sApCont = ""
            sAmCont = ""
            sTelfCliente = ""

            txtnrodocumento.Text = sNumero3
            TxtContacto.Text = sContacto
            TxtAPContacto.Text = sApCont.Trim
            TxtAMContacto.Text = sAmCont.Trim
            TxtAPContacto.Visible = True
            TxtAMContacto.Visible = True
            LblAMContacto.Visible = True
            LblAPContacto.Visible = True

            'txtnrodocumento.Text = ""
            'txtnomContacto.Text = ""
            txtnrodocumento.Focus()
        End If
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If Me.TabCliente.SelectedIndex = 0 Then
            If IsDBNull(Me.dgvBuscar.CurrentRow.Cells("nu_docu_suna").Value) Then
                TxtNumero.Text = ""
            Else
                TxtNumero.Text = Me.dgvBuscar.CurrentRow.Cells("nu_docu_suna").Value
            End If
            TxtNumero.Tag = Me.dgvBuscar.CurrentRow.Cells("idpersona").Value
            TxtCliente.Text = Me.dgvBuscar.CurrentRow.Cells("razon_social").Value
            bClienteNuevo = False
        Else
            Dim obj As New dtrecojo
            Dim snum As String = Me.TxtNumero.Text
            If CboTipoDocumento.SelectedValue = 1 Then '==> RUC
                If Not fnValidarRUC(TxtNumero.Text) Then
                    MessageBox.Show("El RUC no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtNumero.Focus()
                    Return
                End If

                If bClienteNuevo Then
                    Dim ds As DataSet = obj.Listar_cli(snum)
                    Dim resp As Integer = ds.Tables(0).Rows.Count
                    If resp = 1 Then
                        MessageBox.Show("EL Nº de Documento ya Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        bSalir = False
                        TxtNumero.Focus()
                        Return
                    End If
                End If

                'hlamas 15-11-2016
                If Me.TxtNumero.Text.Trim.Substring(0, 1) = "1" Then
                    If TieneNumero(Me.TxtCliente.Text.Trim) Then
                        MessageBox.Show("EL RUC no puede contener números en la Razón social", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        bSalir = False
                        TxtNumero.Focus()
                        Return
                    End If
                End If

                If Me.txtTelefono.Text.Trim.Length < 6 And ChkTelefono.Checked Then 'CambioR 08112011
                    MessageBox.Show("Ingrese un Número de Teléfono Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    txtTelefono.Text = txtTelefono.Text.Trim()
                    txtTelefono.Focus()
                    Return
                End If

                If ChkTelefono.Checked AndAlso Val(Me.txtTelefono.Text.Trim.Substring(0, 1)) < 2 Then 'CambioR 08112011
                    MessageBox.Show("Ingrese un Número de Teléfono Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    txtTelefono.Text = txtTelefono.Text.Trim()
                    txtTelefono.Focus()
                    Return
                End If

            ElseIf CboTipoDocumento.SelectedValue = 3 Then '==> DNI
                If TxtNumero.Text.Length <> 8 Then
                    MessageBox.Show("El DNI no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtNumero.Focus()
                    Return
                End If

                If bClienteNuevo Then
                    Dim ds As DataSet = obj.Listar_cli(snum, Me.CboTipoDocumento.SelectedValue)
                    Dim resp As Integer = ds.Tables(0).Rows.Count
                    If resp = 1 Then
                        MessageBox.Show("EL Nº de Documento ya Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        bSalir = False
                        TxtNumero.Focus()
                        Return
                    End If
                End If

                If Me.txtTelefono.Text.Trim.Length < 6 And ChkTelefono.Checked Then 'CambioR 08112011
                    MessageBox.Show("Ingrese un Número de Teléfono Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    txtTelefono.Text = txtTelefono.Text.Trim()
                    txtTelefono.Focus()
                    Return
                End If

                If ChkTelefono.Checked AndAlso Val(Me.txtTelefono.Text.Trim.Substring(0, 1)) < 2 Then 'CambioR 08112011
                    MessageBox.Show("Ingrese un Número de Teléfono Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    txtTelefono.Text = txtTelefono.Text.Trim()
                    txtTelefono.Focus()
                    Return
                End If

                If Me.TxtCliente.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Nombres Del Cliente.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtCliente.Text = TxtCliente.Text.Trim()
                    TxtCliente.Focus()
                    Return
                End If
                If Me.TxtAPCliente.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Apellido Paterno.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtAPCliente.Text = TxtAPCliente.Text.Trim()
                    TxtAPCliente.Focus()
                    Return
                End If
                If CboTipoDocumento.SelectedValue = 3 Then
                    If Me.TxtAMCliente.Text.Trim.Length = 0 Then
                        MessageBox.Show("Ingrese Apellido Materno.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        bSalir = False
                        TxtAMCliente.Text = TxtAMCliente.Text.Trim()
                        TxtAMCliente.Focus()
                        Return
                    End If
                End If
            ElseIf Me.CboTipoDocumento.SelectedValue > 0 Then
                If Me.CboTipoDocumento.SelectedValue <> 9 AndAlso (TxtNumero.Text.Length < 6 Or TxtNumero.Text.Length = 11) Then
                    MessageBox.Show("El Nº de Documento no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtNumero.Focus()
                    Return
                End If

                If bClienteNuevo Then
                    Dim ds As DataSet = obj.Listar_cli(snum, Me.CboTipoDocumento.SelectedValue)
                    Dim resp As Integer = ds.Tables(0).Rows.Count
                    If resp = 1 Then
                        MessageBox.Show("EL Nº de Documento ya Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        bSalir = False
                        TxtNumero.Focus()
                        Return
                    End If
                End If


                If Me.txtTelefono.Text.Trim.Length < 6 And ChkTelefono.Checked Then 'CambioR 08112011
                    MessageBox.Show("Ingrese un Número de Teléfono Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    txtTelefono.Text = txtTelefono.Text.Trim()
                    txtTelefono.Focus()
                    Return
                End If

                If ChkTelefono.Checked AndAlso Val(Me.txtTelefono.Text.Trim.Substring(0, 1)) < 2 Then 'CambioR 08112011
                    MessageBox.Show("Ingrese un Número de Teléfono Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    txtTelefono.Text = txtTelefono.Text.Trim()
                    txtTelefono.Focus()
                    Return
                End If

                If Me.TxtCliente.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Nombres Del Cliente.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtCliente.Text = TxtCliente.Text.Trim()
                    TxtCliente.Focus()
                    Return
                End If
                If Me.TxtAPCliente.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Apellido Paterno.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtAPCliente.Text = TxtAPCliente.Text.Trim()
                    TxtAPCliente.Focus()
                    Return
                End If
                If CboTipoDocumento.SelectedValue = 3 Then
                    If Me.TxtAMCliente.Text.Trim.Length = 0 Then
                        MessageBox.Show("Ingrese Apellido Materno.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        bSalir = False
                        TxtAMCliente.Text = TxtAMCliente.Text.Trim()
                        TxtAMCliente.Focus()
                        Return
                    End If
                End If
            Else
                MessageBox.Show("Seleccione el Tipo de Documento.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                CboTipoDocumento.Focus()
                Return
            End If

            If Me.TxtCliente.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese " & IIf(CboTipoDocumento.SelectedValue = 1, "Razón Social del Cliente", "Nombres del Cliente"), "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                TxtCliente.Text = TxtCliente.Text.Trim()
                TxtCliente.Focus()
                Return
            End If

            If Me.TxtEmail.Text.Trim.Length > 0 Then
                If Not ValidarEMail(Me.TxtEmail.Text.Trim) Then
                    MessageBox.Show("Ingrese Email Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    Me.TxtEmail.Focus()
                    Return
                End If
            End If

            'If iProducto <> 6 Or Me.CboDepartamento.SelectedValue <> 0 Or Me.CboProvincia.SelectedValue <> 0 Or Me.CboDistrito.SelectedValue <> 0 Or Me.CboVia.SelectedValue <> 0 Then
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
                If Me.CboVia.SelectedValue = 0 And CboZona.SelectedValue = 0 Then 'cambio 03102011
                    MessageBox.Show("Seleccione Tipo de Vía", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    Me.CboVia.Focus()
                    Return
                End If

                'If Me.TxtVia.Text.Trim.Length = 0 Then
                If Me.TxtVia.Text.Trim.Length = 0 And CboZona.SelectedValue = 0 Then 'cambio 03102011
                    MessageBox.Show("Ingrese Nombre de la Vía", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    Me.TxtVia.Text = ""
                    Me.TxtVia.Focus()
                    Return
                End If

                If Me.TxtNumero2.Text.Trim.Length = 0 And Me.TxtManzana.Text.Trim.Length = 0 And Me.TxtLote.Text.Trim.Length = 0 Then
                    Dim sMje As String = ""
                    Dim i As Integer
                    'If Me.TxtNumero2.Text.Trim.Length = 0 Then
                    If Me.TxtNumero2.Text.Trim.Length = 0 And CboVia.SelectedValue > 0 Then 'cambio 03102011
                        sMje = "Nº de la Vía"
                        i = 1
                    ElseIf Me.TxtManzana.Text.Trim.Length = 0 Then
                        sMje = "Manzana de la Vía"
                        i = 2
                    Else
                        sMje = "Lote de la Vía"
                        i = 3
                    End If
                    MessageBox.Show("Ingrese " & sMje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    If Me.TxtManzana.Text.Trim.Length = 0 Then Me.TxtManzana.Text = ""
                    If Me.TxtLote.Text.Trim.Length = 0 Then Me.TxtLote.Text = ""

                    If i = 1 Then
                        Me.TxtNumero2.Focus()
                    ElseIf i = 2 Then
                        Me.TxtManzana.Focus()
                    Else
                        Me.TxtLote.Focus()
                    End If
                    Return
                End If

                If Me.TxtNumero2.Text.Trim.Length = 0 And (Me.TxtManzana.Text.Trim.Length = 0 Or Me.TxtLote.Text.Trim.Length = 0) Then
                    Dim sMje As String = ""
                    Dim i As Integer
                    If Me.TxtManzana.Text.Trim.Length = 0 Then
                        sMje = "Manzana de la Vía"
                        i = 1
                    Else
                        sMje = "Lote de la Vía"
                        i = 2
                    End If
                    MessageBox.Show("Ingrese " & sMje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    If Me.TxtManzana.Text.Trim.Length = 0 Then Me.TxtManzana.Text = ""
                    If Me.TxtLote.Text.Trim.Length = 0 Then Me.TxtLote.Text = ""
                    If i = 1 Then
                        Me.TxtManzana.Focus()
                    Else
                        Me.TxtLote.Focus()
                    End If
                    Return
                End If

                If Me.CboNivel.SelectedValue > 0 AndAlso Me.TxtNivel.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Nombre del Nivel", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    Me.TxtNivel.Text = ""
                    Me.TxtNivel.Focus()
                    Return
                End If

                If Me.CboZona.SelectedValue > 0 AndAlso Me.TxtZona.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Nombre de la Zona", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    Me.TxtZona.Text = ""
                    Me.TxtZona.Focus()
                    Return
                End If

                If Me.CboClasificacion.SelectedValue > 0 AndAlso Me.TxtClasificacion.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Nombre de la Clasificación", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    Me.TxtClasificacion.Text = ""
                    Me.TxtClasificacion.Focus()
                    Return
                End If
            End If

            If CboDocContacto.SelectedValue <> 0 Then
                If CboDocContacto.SelectedValue = 1 Then
                    If Not fnValidarRUC(txtnrodocumento.Text) Then
                        MessageBox.Show("El RUC no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        bSalir = False
                        txtnrodocumento.Focus()
                        Return
                    End If

                    If bContactoNuevo AndAlso Not ChkCliente.Checked Then
                        Dim objContacto As New dtoVentaCargaContado
                        Dim dt As DataTable = objContacto.BuscarContacto(TxtNumero.Text.Trim, txtnrodocumento.Text.Trim)
                        Dim resp As Integer = dt.Rows.Count
                        If resp >= 1 Then
                            MessageBox.Show("EL Nº de Documento ya Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            bSalir = False
                            txtnrodocumento.Focus()
                            Return
                        End If

                        If txtnrodocumento.Text.Trim = TxtNumero.Text.Trim Then
                            Me.ChkCliente.Checked = True
                        End If
                    End If

                    If Me.TxtContacto.Text.Trim.Length = 0 And Me.GrbContacto.Enabled Then
                        MessageBox.Show("Ingrese Razón Social del Contacto", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        bSalir = False
                        TxtContacto.Text = TxtContacto.Text.Trim()
                        TxtContacto.Focus()
                        Return
                    End If

                ElseIf CboDocContacto.SelectedValue = 3 Then
                    If txtnrodocumento.Text.Length <> 8 And Me.GrbContacto.Enabled Then
                        MessageBox.Show("El DNI no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        bSalir = False
                        txtnrodocumento.Text = txtnrodocumento.Text.Trim()
                        txtnrodocumento.Focus()
                        Return
                    End If

                    If bContactoNuevo AndAlso Not ChkCliente.Checked Then
                        Dim objContacto As New dtoVentaCargaContado
                        Dim dt As DataTable = objContacto.BuscarContacto(TxtNumero.Text.Trim, txtnrodocumento.Text.Trim)
                        Dim resp As Integer = dt.Rows.Count
                        If resp >= 1 Then
                            MessageBox.Show("EL Nº de Documento ya Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            bSalir = False
                            txtnrodocumento.Focus()
                            Return
                        End If

                        If txtnrodocumento.Text.Trim = TxtNumero.Text.Trim Then
                            Me.ChkCliente.Checked = True
                        End If
                    End If
                Else
                    If Me.CboDocContacto.SelectedValue <> 9 AndAlso txtnrodocumento.Text.Length < 6 AndAlso Me.GrbContacto.Enabled Then
                        MessageBox.Show("El Nº de Documento no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        bSalir = False
                        txtnrodocumento.Text = txtnrodocumento.Text.Trim()
                        txtnrodocumento.Focus()
                        Return
                    Else
                        If bContactoNuevo AndAlso Not ChkCliente.Checked Then
                            Dim objContacto As New dtoVentaCargaContado
                            Dim dt As DataTable = objContacto.BuscarContacto(TxtNumero.Text.Trim, txtnrodocumento.Text.Trim)
                            Dim resp As Integer = dt.Rows.Count
                            If resp >= 1 Then
                                MessageBox.Show("EL Nº de Documento ya Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                bSalir = False
                                txtnrodocumento.Focus()
                                Return
                            End If

                            If txtnrodocumento.Text.Trim = TxtNumero.Text.Trim Then
                                Me.ChkCliente.Checked = True
                            End If
                        End If
                    End If
                End If

                If CboDocContacto.SelectedValue <> 1 Then
                    If Me.TxtContacto.Text.Trim.Length = 0 And Me.GrbContacto.Enabled Then
                        MessageBox.Show("Ingrese Nombres del Contacto", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        bSalir = False
                        TxtContacto.Text = TxtContacto.Text.Trim()
                        TxtContacto.Focus()
                        Return
                    End If

                    If Me.TxtAPContacto.Text.Trim.Length = 0 And Me.GrbContacto.Enabled Then
                        MessageBox.Show("Ingrese Apellido Paterno del Contacto", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        bSalir = False
                        TxtAPContacto.Text = TxtAPContacto.Text.Trim()
                        TxtAPContacto.Focus()
                        Return
                    End If
                End If
            End If

            Me.TxtCliente.Text = Me.TxtCliente.Text.Trim
            Me.TxtAPCliente.Text = Me.TxtAPCliente.Text.Trim
            Me.TxtAMCliente.Text = Me.TxtAMCliente.Text.Trim
            Me.TxtContacto.Text = Me.TxtContacto.Text.Trim
            TxtAPContacto.Text = TxtAPContacto.Text.Trim
            TxtAMContacto.Text = TxtAMContacto.Text.Trim

            'Verifica si Contacto
            If Me.ChkCliente.Checked Then
                If Me.CboTipoDocumento.SelectedValue <> Me.CboDocContacto.SelectedValue Then
                    Me.CboDocContacto.SelectedValue = Me.CboTipoDocumento.SelectedValue
                End If

                If Me.TxtNumero.Text <> Me.txtnrodocumento.Text Then
                    Me.txtnrodocumento.Text = Me.TxtNumero.Text
                End If

                If Me.TxtCliente.Text <> Me.TxtContacto.Text Then
                    Me.TxtContacto.Text = Me.TxtCliente.Text
                End If

                If Me.CboTipoDocumento.SelectedValue <> 1 Then
                    If Me.TxtAPCliente.Text <> Me.TxtAPContacto.Text Then
                        Me.TxtAPContacto.Text = Me.TxtAPCliente.Text
                    End If

                    If Me.TxtAMCliente.Text <> Me.TxtAMContacto.Text Then
                        Me.TxtAMContacto.Text = Me.TxtAMCliente.Text
                    End If
                End If
            End If

            '*********Verifica si el Cliente ha sido modificado******
            If Me.TxtCliente.Text = Me.TxtCliente.Tag AndAlso _
                Me.TxtAPCliente.Text = Me.TxtAPCliente.Tag AndAlso _
                Me.TxtAMCliente.Text = Me.TxtAMCliente.Tag AndAlso _
                Me.txtTelefono.Text = Me.txtTelefono.Tag AndAlso _
                Me.TxtEmail.Text = Me.TxtEmail.Tag Then
                bClienteModificado = False
            Else
                bClienteModificado = True
            End If

            '*********Verifica si la direccion ha sido modificada******
            If Me.CboDepartamento.SelectedValue = Me.CboDepartamento.Tag AndAlso _
               Me.CboProvincia.SelectedValue = Me.CboProvincia.Tag AndAlso _
                Me.CboDistrito.SelectedValue = Me.CboDistrito.Tag AndAlso _
                Me.CboVia.SelectedValue = Me.CboVia.Tag AndAlso _
                Me.TxtVia.Text = Me.TxtVia.Tag AndAlso _
                Me.TxtNumero2.Text = Me.TxtNumero2.Tag AndAlso _
                Me.TxtManzana.Text = Me.TxtManzana.Tag AndAlso _
                Me.TxtLote.Text = Me.TxtLote.Tag AndAlso _
                Me.CboNivel.SelectedValue = Me.CboNivel.Tag AndAlso _
                Me.TxtNivel.Text = Me.TxtNivel.Tag AndAlso _
                Me.CboZona.SelectedValue = Me.CboZona.Tag AndAlso _
                Me.TxtZona.Text = Me.TxtZona.Tag AndAlso _
                Me.CboClasificacion.SelectedValue = Me.CboClasificacion.Tag AndAlso _
                Me.TxtClasificacion.Text = Me.TxtClasificacion.Tag Then
                bDireccionModificada = False
            Else
                'If Me.CboDistrito.SelectedValue > 0 Then
                bDireccionModificada = True
                'Else
                'bDireccionModificada = False
                'End If
            End If

            '*******Verifica si el contacto ha sido modificado************
            If Me.CboDocContacto.SelectedValue = Me.CboDocContacto.Tag AndAlso _
                Me.txtnrodocumento.Text = Me.txtnrodocumento.Tag AndAlso _
                Me.TxtContacto.Text = Me.TxtContacto.Tag AndAlso _
                Me.TxtAPContacto.Text = Me.TxtAPContacto.Tag AndAlso _
                Me.TxtAMContacto.Text = Me.TxtAMContacto.Tag Then
                bContactoModificado = False
            Else
                bContactoModificado = True
            End If
            End If


            bSalir = True
    End Sub

    Private Sub CboDocContacto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDocContacto.SelectedIndexChanged
        If Not IsReference(Me.CboDocContacto.SelectedValue) Then
            Me.txtnrodocumento.Text = ""
            Me.txtnrodocumento.Enabled = True
            If Me.CboDocContacto.SelectedValue = 1 Then
                Me.txtnrodocumento.MaxLength = 11
                Me.LblContacto.Text = "Raz. Soc."
                Me.LblAPContacto.Visible = False
                Me.LblAMContacto.Visible = False
                Me.TxtAPContacto.Visible = False
                Me.TxtAMContacto.Visible = False
                Me.LblContacto.Top = 50
                Me.TxtContacto.Top = 47
                Me.TxtAPContacto.Text = ""
                Me.TxtAMContacto.Text = ""
                Me.GrbContacto.Enabled = True
            Else
                Me.LblContacto.Text = "Nombres"
                Me.LblContacto.Top = 41
                Me.TxtContacto.Top = 38
                Me.LblAPContacto.Visible = True
                Me.LblAMContacto.Visible = True
                Me.TxtAPContacto.Visible = True
                Me.TxtAMContacto.Visible = True

                If Me.CboDocContacto.SelectedValue = 3 Then
                    Me.txtnrodocumento.MaxLength = 8
                ElseIf Me.CboDocContacto.SelectedValue = 9 Then
                    Me.txtnrodocumento.Text = ""
                    Me.txtnrodocumento.Enabled = False
                    Me.TxtContacto.Focus()
                Else
                    Me.txtnrodocumento.MaxLength = 20
                End If
            End If
        End If
        Me.TxtContacto.Text = Me.TxtContacto.Text.Trim
    End Sub

    Private Sub dgvBuscar_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvBuscar.DoubleClick
        If Me.dgvBuscar.Rows.Count > 0 Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            BtnAceptar_Click(sender, e)
        End If
    End Sub

    Sub cargar(ByVal dt As DataTable, ByVal opcion As Integer)
        dt = dt
        Me.dgvBuscar.DataSource = dt
        iOpcion = opcion
        Me.txtrazon.Focus()
    End Sub

    'Private Sub txtnrodocumento2_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txtnrodocumento2.SelectAll()
    'End Sub

    'Private Sub txtnrodocumento2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumero2.KeyPress
    '    If Not ValidarNumero(e.KeyChar) Then
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub TxtNom2_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
    '    TxtNom2.SelectAll()
    'End Sub

    'Private Sub CboDocConsignado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Not IsReference(Me.CboDocConsignado.SelectedValue) Then
    '        Me.txtnrodocumento2.Text = ""
    '        Me.txtnrodocumento2.ReadOnly = False
    '        If Me.CboDocConsignado.SelectedValue = 1 Then
    '            Me.txtnrodocumento2.MaxLength = 11
    '        ElseIf Me.CboDocConsignado.SelectedValue = 3 Then
    '            Me.txtnrodocumento2.MaxLength = 8
    '        ElseIf Me.CboDocConsignado.SelectedValue = 9 Then
    '            Me.txtnrodocumento2.ReadOnly = True
    '            Me.TxtNom2.Focus()
    '        Else
    '            Me.txtnrodocumento2.MaxLength = 20
    '        End If
    '    End If
    'End Sub

    'Private Sub ChkCliente2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If ChkCliente2.Checked = True Then
    '        Dim sMje As String
    '        Dim i As Integer = 0
    '        If TxtNumero.Text.Trim.Length = 0 And CboTipoDocumento.SelectedValue <> 9 Then
    '            sMje = "Nº de Documento."
    '            i = 1
    '        ElseIf TxtCliente.Text.Trim.Length = 0 Then
    '            sMje = "Nombre o Razón Social."
    '            i = 2
    '        ElseIf txtapep.Text.Trim.Length = 0 And CboTipoDocumento.SelectedValue <> 1 Then
    '            sMje = "Apellido Paterno."
    '            i = 3
    '        End If

    '        If i > 0 Then
    '            MessageBox.Show("Ingrese " & sMje & " ", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            ChkCliente2.Checked = False

    '            If txtapem.Text.Trim.Length = 0 Then txtapem.Text = ""
    '            If i = 1 Then
    '                TxtNumero.Text = ""
    '                TxtNumero.Focus()
    '            ElseIf i = 2 Then
    '                TxtCliente.Text = ""
    '                TxtCliente.Focus()
    '            ElseIf i = 3 Then
    '                txtapep.Text = ""
    '                txtapep.Focus()
    '            End If
    '        Else
    '            CboDocConsignado.SelectedValue = CboTipoDocumento.SelectedValue
    '            txtnrodocumento2.Text = TxtNumero.Text
    '            TxtNom2.Text = TxtCliente.Text.Trim & " " & txtapep.Text.Trim & " " & txtapem.Text.Trim
    '            'desactivamos los textbox
    '            txtnrodocumento2.Enabled = False
    '            TxtNom2.Enabled = False
    '            CboDocConsignado.Enabled = False
    '        End If
    '    Else
    '        CboDocConsignado.Enabled = True
    '        CboDocConsignado.SelectedValue = 3
    '        txtnrodocumento2.Enabled = True
    '        TxtNom2.Enabled = True
    '        txtnrodocumento2.Text = ""
    '        TxtNom2.Text = ""
    '        txtnrodocumento2.Focus()
    '    End If
    'End Sub

    'Private Sub CboDepartamento2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Not IsReference(CboDepartamento2.SelectedValue) Then
    '        Dim sFiltro As String = "iddepartamento=" & CboDepartamento2.SelectedValue & " or iddepartamento=0"
    '        dtProvincia2.DefaultView.RowFilter = sFiltro
    '    End If
    'End Sub

    'Private Sub CboProvincia2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Not IsReference(CboProvincia2.SelectedValue) Then
    '        Dim sFiltro As String = "(iddepartamento=" & CboDepartamento2.SelectedValue & " or iddepartamento=0) and (idprovincia=" & CboProvincia2.SelectedValue & " or idprovincia=0)"
    '        dtDistrito2.DefaultView.RowFilter = sFiltro
    '    End If
    'End Sub

    'Private Sub TxtVia2_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
    '    TxtVia2.SelectAll()
    'End Sub

    'Private Sub TxtNumero3_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
    '    TxtNumero3.SelectAll()
    'End Sub

    'Private Sub TxtManzana2_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
    '    TxtManzana2.SelectAll()
    'End Sub

    'Private Sub TxtLote2_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
    '    TxtLote2.SelectAll()
    'End Sub

    'Private Sub TxtNivel2_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
    '    TxtNivel2.SelectAll()
    'End Sub

    'Private Sub TxtZona2_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
    '    TxtZona2.SelectAll()
    'End Sub

    'Private Sub TxtClasificacion2_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
    '    TxtClasificacion2.SelectAll()
    'End Sub

    Sub cargar(ByVal numero As String, ByVal cliente As String, ByVal tipo As Integer, ByVal nombres As String, ByVal ap As String, ByVal am As String, _
               ByVal departamento As Integer, ByVal provincia As Integer, ByVal distrito As Integer, _
               ByVal id_via As Integer, ByVal via As String, ByVal numero2 As String, ByVal manzana As String, _
               ByVal lote As String, ByVal id_nivel As Integer, ByVal nivel As String, ByVal id_zona As Integer, _
               ByVal zona As String, ByVal id_clasificacion As Integer, ByVal clasificacion As String, _
               ByVal tipo2 As Integer, ByVal numero3 As String, ByVal contacto As String, ByVal NombresCont As String, _
               ByVal AppCont As String, ByVal ApmCont As String, ByVal TelfCliente As String, ByVal escliente As Boolean, ByVal email As String, ByVal ClienteCredito As Boolean)
        sNumero = numero
        sCliente = cliente
        iTipo = tipo
        sNombres = nombres
        sAp = ap
        sAm = am
        iDepartamento = departamento
        iProvincia = provincia
        iDistrito = distrito
        iId_via = id_via
        sVia = via
        sNumero2 = numero2
        sManzana = manzana
        sLote = lote
        iId_nivel = id_nivel
        sNivel = nivel
        iId_Zona = id_zona
        sZona = zona
        iId_Clasificacion = id_clasificacion
        sClasificacion = clasificacion
        iTipo2 = tipo2
        sNumero3 = numero3
        sContacto = contacto
        sNombresCont = NombresCont
        sApCont = AppCont
        sAmCont = ApmCont
        sTelfCliente = TelfCliente
        bEsCliente = escliente
        sEmail = email
        bClienteCredito = ClienteCredito
    End Sub

    Sub Mostrar()
        'cliente
        If Me.CboTipoDocumento.SelectedValue <> 1 AndAlso fnValidarRUC(sNumero.Trim) Then
            iTipo = 1
        End If
        Me.CboTipoDocumento.SelectedValue = IIf(iTipo <= 0, 3, iTipo)
        Me.TxtNumero.Text = sNumero.Trim
        Me.txtTelefono.Text = sTelfCliente.Trim
        Me.TxtEmail.Text = sEmail.Trim
        If iTipo = 1 Then
            'cliente
            Me.TxtCliente.Text = sCliente.Trim
            Me.TxtAPCliente.Text = ""
            Me.TxtAMCliente.Text = ""
            'contacto
            'Me.txtnomContacto.Text = sContacto.Trim
            Me.TxtContacto.Text = sNombresCont.Trim 'new
            Me.TxtAPContacto.Text = sApCont.Trim
            Me.TxtAMContacto.Text = sAmCont.Trim
            Me.CboDocContacto.SelectedValue = iTipo2
        Else
            'cliente
            Me.TxtCliente.Text = sNombres.Trim
            Me.TxtAPCliente.Text = sAp.Trim
            Me.TxtAMCliente.Text = sAm.Trim
            'contacto
            Me.TxtContacto.Text = ""
            Me.TxtAPContacto.Text = ""
            Me.TxtAMContacto.Text = ""
            Me.CboDocContacto.SelectedValue = iTipo2
        End If

        'direccion
        Me.CboDepartamento.SelectedValue = IIf(iDepartamento > 0, iDepartamento, Me.CboDepartamento.SelectedValue)
        Me.CboDepartamento.Tag = Me.CboDepartamento.SelectedValue

        Me.CboProvincia.SelectedValue = IIf(iProvincia > 0, iProvincia, Me.CboProvincia.SelectedValue)
        Me.CboProvincia.Tag = Me.CboProvincia.SelectedValue

        Me.CboDistrito.SelectedValue = IIf(iDistrito > 0, iDistrito, Me.CboDistrito.SelectedValue)
        Me.CboDistrito.Tag = Me.CboDistrito.SelectedValue

        Me.CboVia.SelectedValue = iId_via
        Me.CboVia.Tag = Me.CboVia.SelectedValue

        Me.TxtVia.Text = sVia
        Me.TxtVia.Tag = Me.TxtVia.Text

        Me.TxtNumero2.Text = sNumero2
        Me.TxtNumero2.Tag = Me.TxtNumero2.Text

        Me.TxtManzana.Text = sManzana
        Me.TxtManzana.Tag = Me.TxtManzana.Text

        Me.TxtLote.Text = sLote
        Me.TxtLote.Tag = Me.TxtLote.Text

        Me.CboNivel.SelectedValue = iId_nivel
        Me.CboNivel.Tag = Me.CboNivel.SelectedValue

        Me.TxtNivel.Text = sNivel
        Me.TxtNivel.Tag = Me.TxtNivel.Text

        Me.CboZona.SelectedValue = iId_Zona
        Me.CboZona.Tag = Me.CboZona.SelectedValue

        Me.TxtZona.Text = sZona
        Me.TxtZona.Tag = Me.TxtZona.Text

        Me.CboClasificacion.SelectedValue = iId_Clasificacion
        Me.CboClasificacion.Tag = Me.CboClasificacion.SelectedValue

        Me.TxtClasificacion.Text = sClasificacion
        Me.TxtClasificacion.Tag = Me.TxtClasificacion.Text

        '--contacto
        If iProducto = 6 Then
            If iTipo2 <= 0 Then
                'Me.CboDocContacto.SelectedValue = IIf(iTipo2 <= 0, 3, iTipo2)
                If Me.CboTipoDocumento.SelectedValue <> 3 Then
                    Me.CboDocContacto.SelectedValue = 0
                Else
                    Me.CboDocContacto.SelectedValue = 3
                End If
            Else
                Me.CboDocContacto.SelectedValue = iTipo2
            End If
        Else
            Me.CboDocContacto.SelectedValue = iTipo2
        End If
        Me.CboDocContacto.Tag = Me.CboDocContacto.SelectedValue

        Me.txtnrodocumento.Text = sNumero3
        Me.txtnrodocumento.Tag = Me.txtnrodocumento.Text

        Me.TxtContacto.Tag = Me.TxtContacto.Text
        Me.TxtAPContacto.Tag = Me.TxtAPContacto.Text
        Me.TxtAMContacto.Tag = Me.TxtAMContacto.Text
        '---
        Me.txtTelefono.Tag = Me.txtTelefono.Text
        Me.TxtEmail.Tag = Me.TxtEmail.Text

        Me.TxtCliente.Tag = Me.TxtCliente.Text
        Me.TxtAPCliente.Tag = Me.TxtAPCliente.Text
        Me.TxtAMCliente.Tag = Me.TxtAMCliente.Text

        'RemoveHandler Me.ChkCliente.CheckedChanged, AddressOf ChkCliente_CheckedChanged
        Me.ChkCliente.Checked = bEsCliente
        'AddHandler Me.ChkCliente.CheckedChanged, AddressOf ChkCliente_CheckedChanged

        If bClienteNuevo Then
            Me.CboTipoDocumento.Enabled = True
            Me.TxtNumero.Enabled = True
        Else
            If iTipo <> 9 Then
                Me.CboTipoDocumento.Enabled = False
                Me.TxtNumero.Enabled = False
            Else
                Me.CboTipoDocumento.Enabled = True
                Me.TxtNumero.Enabled = True
            End If
        End If

        If Me.CboTipoDocumento.SelectedValue = 9 AndAlso Me.TxtNumero.Text.Trim.Length = 0 Then
            Me.TxtNumero.Enabled = False
        End If

        If intOpcion = 0 Then
            If Me.CboTipoDocumento.SelectedValue = 1 Then
                Me.GrbContacto.Enabled = True
            Else
                Me.GrbContacto.Enabled = False
            End If
        End If


        If bClienteCredito Then
            Me.TxtCliente.Enabled = False
            Me.TxtAMCliente.Enabled = False
            Me.TxtAPCliente.Enabled = False
            Me.TxtEmail.Enabled = False
        Else
            Me.TxtCliente.Enabled = False
            Me.TxtAMCliente.Enabled = False
            Me.TxtAPCliente.Enabled = False
            Me.TxtEmail.Enabled = True
        End If
    End Sub

    Private Sub txtapem_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAMCliente.KeyPress
        If Not ValidarLetra(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtnom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtContacto.KeyPress
        'If Not ValidarLetra(e.KeyChar) Then
        '    e.Handled = True
        'End If
        If Me.CboDocContacto.SelectedValue = 1 Then
            If Not ValidarLetraNumero(e.KeyChar) Then
                e.Handled = True
            End If
        Else
            If Not ValidarLetra(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtTelefono_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono.KeyPress
        If Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtapePCont_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAPContacto.Enter
        TxtAPContacto.SelectAll()
    End Sub

    Private Sub txtapePCont_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAPContacto.KeyPress
        If Not ValidarLetra(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtapeMCont_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAMContacto.Enter
        TxtAMContacto.SelectAll()
    End Sub

    Private Sub txtapeMCont_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAMContacto.KeyPress
        If Not ValidarLetra(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Sub Inicializar()
        Me.CboDepartamento.Tag = Me.CboDepartamento.SelectedValue
        Me.CboProvincia.Tag = Me.CboProvincia.SelectedValue
        Me.CboDistrito.Tag = Me.CboDistrito.SelectedValue
        Me.CboVia.Tag = Me.CboVia.SelectedValue
        Me.TxtVia.Tag = Me.TxtVia.Text
        Me.TxtNumero2.Tag = Me.TxtNumero2.Text
        Me.TxtManzana.Tag = Me.TxtManzana.Text
        Me.TxtLote.Tag = Me.TxtLote.Text
        Me.CboNivel.Tag = Me.CboNivel.SelectedValue
        Me.TxtNivel.Tag = Me.TxtNivel.Text
        Me.CboZona.Tag = Me.CboZona.SelectedValue
        Me.TxtZona.Tag = Me.TxtZona.Text
        Me.CboClasificacion.Tag = Me.CboClasificacion.SelectedValue
        Me.TxtClasificacion.Tag = Me.TxtClasificacion.Text
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Me.ClienteNuevo()
    End Sub

    Sub ClienteNuevo()
        bClienteNuevo = True
        bClienteModificado = False
        Me.CboTipoDocumento.SelectedValue = 3
        Me.TxtNumero.Text = ""
        Me.txtTelefono.Text = ""
        Me.TxtCliente.Text = ""
        Me.TxtAPCliente.Text = ""
        Me.TxtAMCliente.Text = ""
        Me.ChkCliente.Checked = False
        Me.TxtEmail.Text = ""
        Me.CboTipoDocumento.Enabled = True
        Me.TxtNumero.Enabled = True

        '------
        Me.TxtCliente.Enabled = True
        Me.TxtAPCliente.Enabled = True
        Me.TxtAMCliente.Enabled = True
        Me.TxtEmail.Enabled = True

        Me.CboTipoDocumento.Focus()
    End Sub

    Private Sub CboDistrito_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDistrito.SelectedIndexChanged
        If Not IsReference(Me.CboDistrito.SelectedValue) Then
            If Me.CboDistrito.SelectedValue = 0 Then
                Me.CboVia.SelectedValue = 0
                Me.TxtVia.Text = ""
                Me.TxtNumero2.Text = ""
                Me.TxtManzana.Text = ""
                Me.TxtLote.Text = ""
                Me.CboNivel.SelectedValue = 0
                Me.TxtNivel.Text = ""
                Me.CboZona.SelectedValue = 0
                Me.TxtZona.Text = ""
                Me.CboClasificacion.SelectedValue = 0
                Me.TxtClasificacion.Text = ""

                Me.CboVia.Enabled = False
                Me.TxtVia.ReadOnly = True
                Me.TxtNumero2.ReadOnly = True
                Me.TxtManzana.ReadOnly = True
                Me.TxtLote.ReadOnly = True
                Me.CboNivel.Enabled = False
                Me.TxtNivel.ReadOnly = True
                Me.CboZona.Enabled = False
                Me.TxtZona.ReadOnly = True
                Me.CboClasificacion.Enabled = False
                Me.TxtClasificacion.ReadOnly = True
            Else
                Me.CboVia.Enabled = True
                Me.TxtVia.ReadOnly = False
                Me.TxtNumero2.ReadOnly = False
                Me.TxtManzana.ReadOnly = False
                Me.TxtLote.ReadOnly = False
                Me.CboNivel.Enabled = True
                Me.TxtNivel.ReadOnly = False
                Me.CboZona.Enabled = True
                Me.TxtZona.ReadOnly = False
                Me.CboClasificacion.Enabled = True
                Me.TxtClasificacion.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub ChkTelefono_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTelefono.CheckedChanged
        Try
            If ChkTelefono.Checked Then
                txtTelefono.Enabled = True
                txtTelefono.Focus()
            Else
                txtTelefono.Enabled = False
                TxtCliente.Focus()
                txtTelefono.Text = ""
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TxtNumero_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtNumero.TextChanged

    End Sub

    Private Sub TxtCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCliente.TextChanged
    End Sub
End Class