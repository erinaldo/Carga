Public Class FrmCliente2
    Public dtDepartamento, dtDepartamento2 As DataTable
    Public dtProvincia, dtProvincia2 As DataTable
    Public dtDistrito, dtDistrito2 As DataTable

    Public iFicha As Integer
    Public iProceso As Integer
    Public iTipoEntrega As Integer

    Dim dt As DataTable
    Dim iOpcion As Integer

    Dim bSalir As Boolean = True

    Private Property CboClasificacion2 As Object

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

            If iProceso = 1 Then
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
                    .HeaderText = "telefono"
                    .Name = "telefono"
                    .DataPropertyName = "telefono"
                    .Visible = False
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

            ElseIf iProceso = 2 Or iProceso = 3 Then
                Dim idpersona As New DataGridViewTextBoxColumn
                With idpersona
                    .HeaderText = "idcontacto_persona"
                    .Name = "idpersona"
                    .DataPropertyName = "idpersona"
                    .Visible = False
                End With

                Dim idtipo_documento_contacto As New DataGridViewTextBoxColumn
                With idtipo_documento_contacto
                    .HeaderText = "idtipo_documento_contacto"
                    .Name = "idtipo_documento_contacto"
                    .DataPropertyName = "idtipo_documento_contacto"
                    .Visible = False
                End With

                Dim tipo_doc_identidad As New DataGridViewTextBoxColumn
                With tipo_doc_identidad
                    .HeaderText = "Tipo"
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

                Dim razon_social As New DataGridViewTextBoxColumn
                With razon_social
                    .HeaderText = "Nombres"
                    .Name = "razon_social"
                    .DataPropertyName = "razon_social"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With

                .Columns.AddRange(idpersona, idtipo_documento_contacto, tipo_doc_identidad, nu_docu_suna, razon_social)
            End If
        End With
    End Sub

    Private Sub FrmIngresoContado_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Cursor = Cursors.Default
        If iFicha = 0 Then
            Me.txtrazon.Focus()
        ElseIf iFicha = 1 Then
            Me.LblBuscar.Text = "Cliente"
            Me.CboTipoDocumento.Focus()
        Else
            Me.LblBuscar.Text = "Contacto"
            Me.CboDocContacto.Focus()
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
            Dim obj As New dtoVentaCargaContado
            Dim ds As DataSet = obj.Inicio(dtoUSUARIOS.iIDAGENCIAS)

            With CboTipoDocumento
                .DataSource = ds.Tables(8)
                .DisplayMember = "tipo_doc_identidad"
                .ValueMember = "idtipo_doc_identidad"
                .SelectedValue = 3
            End With

            Dim dtTipoDocumento As DataTable = ds.Tables(8).Copy
            With CboDocContacto
                .DataSource = dtTipoDocumento
                .DisplayMember = "tipo_doc_identidad"
                .ValueMember = "idtipo_doc_identidad"
                .SelectedValue = 3
            End With

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
            If ds.Tables(7).Rows.Count > 0 Then
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
            Me.TxtNumero.Text = ""
            Me.TxtNumero.ReadOnly = False
            If Me.CboTipoDocumento.SelectedValue = 1 Then
                Me.TxtNumero.MaxLength = 11
                Me.LblCliente.Text = "Raz. Soc."
                'Me.LblApep.Visible = False
                'Me.LblApeM.Visible = False
                'Me.txtapep.Visible = False
                'Me.txtapem.Visible = False
                Me.LblCliente.Top = 47
                Me.TxtCliente.Top = 47
                'Me.txtapep.Text = ""
                'Me.txtapem.Text = ""
            Else
                Me.LblCliente.Text = "Nombres"
                Me.LblCliente.Top = 39
                Me.TxtCliente.Top = 36
                'Me.LblApep.Visible = True
                'Me.LblApeM.Visible = True
                'Me.txtapep.Visible = True
                'Me.txtapem.Visible = True

                If Me.CboTipoDocumento.SelectedValue = 3 Then
                    Me.TxtNumero.MaxLength = 8
                ElseIf Me.CboTipoDocumento.SelectedValue = 9 Then
                    Me.TxtNumero.ReadOnly = True
                    Me.TxtCliente.Focus()
                Else
                    Me.TxtNumero.MaxLength = 20
                End If
            End If
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
        If Not ValidarLetra(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    'Private Sub txtapep_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txtapep.SelectAll()
    'End Sub

    Private Sub txtapep_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not ValidarLetra(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    'Private Sub txtapem_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
    '    txtapem.SelectAll()
    'End Sub

    Private Sub txtapem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub txtnrodocumento_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        txtnrodocumento.SelectAll()
    End Sub

    Private Sub txtnrodocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtnom_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        txtnom.SelectAll()
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Try
            Me.Cursor = Cursors.AppStarting
            Dim sItem As String = Me.txtrazon.Text.Trim
            Dim obj As New dtoVentaCargaContado
            Dim ds As New DataSet
            If iProceso = 1 Then
                'ds = obj.BuscarCliente(sItem, 2)
            ElseIf iProceso = 2 Or iProceso = 3 Then
                ds = obj.BuscarContacto(sItem, 2, dtoUSUARIOS.m_idciudad)
            End If
            Me.dgvBuscar.DataSource = ds.Tables(0)
            Me.Cursor = Cursors.Default

            If Me.dgvBuscar.Rows.Count = 0 Then
                If iProceso = 1 Then
                    MessageBox.Show("El Cliente no Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf iProceso = 2 Then
                    MessageBox.Show("El Contacto no Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf iProceso = 3 Then
                    MessageBox.Show("El Consignado no Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            Me.TabCliente.SelectedIndex = iFicha
            Me.GrbDireccion.Enabled = True
            If iProceso = 1 Or iProceso = 3 Then
                'Me.TabCliente.TabPages(1).Text = IIf(iProceso = 1, "Cliente", "Consignado")
                'Me.TabCliente.TabPages.RemoveAt(2)
                If iProceso = 3 And iTipoEntrega = 0 Then
                    Me.GrbDireccion.Enabled = False
                End If
            ElseIf iProceso = 2 Then
                Me.TabCliente.TabPages.RemoveAt(1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TabCliente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabCliente.SelectedIndexChanged
        If TabCliente.SelectedIndex = 0 Then
            Me.txtrazon.Focus()
        Else
            Me.CboTipoDocumento.Focus()
        End If
    End Sub

    Private Sub ChkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ChkCliente.Checked = True Then
            Dim sMje As String
            Dim i As Integer = 0
            If TxtNumero.Text.Trim.Length = 0 And CboTipoDocumento.SelectedValue <> 9 Then
                sMje = "Nº de Documento."
                i = 1
            ElseIf TxtCliente.Text.Trim.Length = 0 Then
                sMje = "Nombre o Razón Social."
                i = 2
                'ElseIf txtapep.Text.Trim.Length = 0 And CboTipoDocumento.SelectedValue <> 1 Then
                '    sMje = "Apellido Paterno."
                '    i = 3
            End If

            If i > 0 Then
                MessageBox.Show("Ingrese " & sMje & " ", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ChkCliente.Checked = False

                'If txtapem.Text.Trim.Length = 0 Then txtapem.Text = ""
                If i = 1 Then
                    TxtNumero.Text = ""
                    TxtNumero.Focus()
                ElseIf i = 2 Then
                    TxtCliente.Text = ""
                    TxtCliente.Focus()
                ElseIf i = 3 Then
                    'txtapep.Text = ""
                    'txtapep.Focus()
                End If
            Else
                CboDocContacto.SelectedValue = CboTipoDocumento.SelectedValue
                txtnrodocumento.Text = TxtNumero.Text
                txtnom.Text = TxtCliente.Text.Trim '& " " & txtapep.Text.Trim & " " & txtapem.Text.Trim
                'desactivamos los textbox
                txtnrodocumento.Enabled = False
                txtnom.Enabled = False
                CboDocContacto.Enabled = False
            End If
        Else
            CboDocContacto.Enabled = True
            CboDocContacto.SelectedValue = 3
            txtnrodocumento.Enabled = True
            txtnom.Enabled = True
            txtnrodocumento.Text = ""
            txtnom.Text = ""
            txtnrodocumento.Focus()
        End If
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If Me.TabCliente.SelectedIndex = 0 Then
            TxtNumero.Text = Me.dgvBuscar.CurrentRow.Cells("nu_docu_suna").Value
            TxtNumero.Tag = Me.dgvBuscar.CurrentRow.Cells("idpersona").Value
            TxtCliente.Text = Me.dgvBuscar.CurrentRow.Cells("razon_social").Value
        ElseIf iProceso = 1 Or iProceso = 3 Then 'Me.TabCliente.SelectedIndex = 1 Then
            Dim obj As New dtrecojo
            Dim snum As String = Me.TxtNumero.Text
            If CboTipoDocumento.SelectedValue = 1 Then
                If Not fnValidarRUC(TxtNumero.Text) Then
                    MessageBox.Show("El RUC no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtNumero.Focus()
                    Return
                End If

                Dim ds As DataSet = obj.Listar_cli(snum)
                Dim resp As Integer = ds.Tables(0).Rows.Count
                If resp = 1 Then
                    MessageBox.Show("EL Nº de Documento ya Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtNumero.Focus()
                    Return
                End If

            ElseIf CboTipoDocumento.SelectedValue = 3 Then
                If TxtNumero.Text.Length <> 8 Then
                    MessageBox.Show("El DNI no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtNumero.Focus()
                    Return
                End If
                Dim ds As DataSet = obj.Listar_cli(snum)
                Dim resp As Integer = ds.Tables(0).Rows.Count
                If resp = 1 Then
                    MessageBox.Show("EL Nº de Documento ya Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtNumero.Focus()
                    Return
                End If

                If Me.TxtCliente.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Nombres Del Cliente.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtCliente.Text = TxtCliente.Text.Trim()
                    TxtCliente.Focus()
                    Return
                End If
                'If Me.txtapep.Text.Trim.Length = 0 Then
                '    MessageBox.Show("Ingrese Apellido Paterno.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    bSalir = False
                '    txtapep.Text = txtapep.Text.Trim()
                '    txtapep.Focus()
                '    Return
                'End If
            Else
                If Me.CboTipoDocumento.SelectedValue <> 9 AndAlso TxtNumero.Text.Length < 6 Then
                    MessageBox.Show("El Nº de Documento no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtNumero.Focus()
                    Return
                End If

                If Me.TxtCliente.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Nombres Del Cliente.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtCliente.Text = TxtCliente.Text.Trim()
                    TxtCliente.Focus()
                    Return
                End If
                'If Me.txtapep.Text.Trim.Length = 0 Then
                '    MessageBox.Show("Ingrese Apellido Paterno.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    bSalir = False
                '    txtapep.Text = txtapep.Text.Trim()
                '    txtapep.Focus()
                '    Return
                'End If
            End If
            If Me.TxtCliente.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese " & IIf(CboTipoDocumento.SelectedValue = 1, "Razón Social del Cliente", "Nombres del Cliente"), "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                TxtCliente.Text = TxtCliente.Text.Trim()
                TxtCliente.Focus()
                Return
            End If


            If iProceso = 1 Or (iProceso = 3 And iTipoEntrega = 1) Then
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

                If Me.CboVia.SelectedValue = 0 Then
                    MessageBox.Show("Seleccione Tipo de Vía", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    Me.CboVia.Focus()
                    Return
                End If

                If Me.TxtVia.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Nombre de la Vía", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    Me.TxtVia.Text = ""
                    Me.TxtVia.Focus()
                    Return
                End If

                If Me.TxtNumero2.Text.Trim.Length = 0 And Me.TxtManzana.Text.Trim.Length = 0 And Me.TxtLote.Text.Trim.Length = 0 Then
                    Dim sMje As String = ""
                    Dim i As Integer
                    If Me.TxtNumero2.Text.Trim.Length = 0 Then
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
        Else
            If CboDocContacto.SelectedValue = 1 Then
                If Not fnValidarRUC(txtnrodocumento.Text) Then
                    MessageBox.Show("El RUC no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    txtnrodocumento.Focus()
                    Return
                End If
            ElseIf CboDocContacto.SelectedValue = 3 Then
                If txtnrodocumento.Text.Length <> 8 Then
                    MessageBox.Show("El DNI no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    txtnrodocumento.Text = txtnrodocumento.Text.Trim()
                    txtnrodocumento.Focus()
                    Return
                End If
            Else
                If Me.CboDocContacto.SelectedValue <> 9 AndAlso txtnrodocumento.Text.Length < 6 Then
                    MessageBox.Show("El Nº de Documento no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    txtnrodocumento.Text = txtnrodocumento.Text.Trim()
                    txtnrodocumento.Focus()
                    Return
                End If
            End If

            If Me.txtnom.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nombres del Contacto", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                txtnom.Text = txtnom.Text.Trim()
                txtnom.Focus()
                Return
            End If

            'TxtCliente.Tag = TxtCliente.Text
            ''iCliente = TxtCliente.Tag
            'txtapep.Tag = txtapep.Text
            ''iApePaterno = txtapep.Tag
            'txtapem.Tag = txtapem.Text
            ''iApeMaterno = txtapem.Tag
            'txtnrodocumento.Tag = txtnrodocumento.Text

            'Consignado
            'If CboDocConsignado.SelectedValue = 1 Then
            '    If Not fnValidarRUC(txtnrodocumento2.Text) Then
            '        MessageBox.Show("El RUC no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        bSalir = False
            '        txtnrodocumento2.Focus()
            '        Return
            '    End If
            'ElseIf CboDocConsignado.SelectedValue = 3 Then
            '    If txtnrodocumento2.Text.Length <> 8 Then
            '        MessageBox.Show("El DNI no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        bSalir = False
            '        txtnrodocumento2.Text = txtnrodocumento2.Text.Trim()
            '        txtnrodocumento2.Focus()
            '        Return
            '    End If
            'Else
            '    If Me.CboDocConsignado.SelectedValue <> 9 AndAlso txtnrodocumento2.Text.Length < 6 Then
            '        MessageBox.Show("El Nº de Documento no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        bSalir = False
            '        txtnrodocumento2.Text = txtnrodocumento2.Text.Trim()
            '        txtnrodocumento2.Focus()
            '        Return
            '    End If
            'End If

            'If Me.TxtNom2.Text.Trim.Length = 0 Then
            '    MessageBox.Show("Ingrese Nombres del Consignado", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    bSalir = False
            '    TxtNom2.Text = TxtNom2.Text.Trim()
            '    TxtNom2.Focus()
            '    Return
            'End If

            'TxtCliente.Tag = TxtCliente.Text
            ''iCliente = TxtCliente.Tag
            'txtapep.Tag = txtapep.Text
            ''iApePaterno = txtapep.Tag
            'txtapem.Tag = txtapem.Text
            ''iApeMaterno = txtapem.Tag
            'txtnrodocumento.Tag = txtnrodocumento.Text

            'If Me.CboDepartamento2.SelectedValue = 0 Then
            '    MessageBox.Show("Seleccione el Departamento", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    bSalir = False
            '    Me.CboDepartamento2.Focus()
            '    Return
            'End If

            'If Me.CboProvincia2.SelectedValue = 0 Then
            '    MessageBox.Show("Seleccione la Provincia", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    bSalir = False
            '    Me.CboProvincia2.Focus()
            '    Return
            'End If

            'If Me.CboDistrito2.SelectedValue = 0 Then
            '    MessageBox.Show("Seleccione el Distrito", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    bSalir = False
            '    Me.CboDistrito2.Focus()
            '    Return
            'End If

            'If Me.CboVia2.SelectedValue = 0 Then
            '    MessageBox.Show("Seleccione Tipo de Vía", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    bSalir = False
            '    Me.CboVia2.Focus()
            '    Return
            'End If

            'If Me.TxtVia2.Text.Trim.Length = 0 Then
            '    MessageBox.Show("Ingrese Nombre de la Vía", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    bSalir = False
            '    Me.TxtVia2.Text = ""
            '    Me.TxtVia2.Focus()
            '    Return
            'End If

            'If Me.TxtNumero3.Text.Trim.Length = 0 And Me.TxtManzana2.Text.Trim.Length = 0 And Me.TxtLote2.Text.Trim.Length = 0 Then
            '    Dim sMje As String = ""
            '    Dim i As Integer
            '    If Me.TxtNumero3.Text.Trim.Length = 0 Then
            '        sMje = "Nº de la Vía"
            '        i = 1
            '    ElseIf Me.TxtManzana2.Text.Trim.Length = 0 Then
            '        sMje = "Manzana de la Vía"
            '        i = 2
            '    Else
            '        sMje = "Lote de la Vía"
            '        i = 3
            '    End If
            '    MessageBox.Show("Ingrese " & sMje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    bSalir = False
            '    If Me.TxtManzana2.Text.Trim.Length = 0 Then Me.TxtManzana2.Text = ""
            '    If Me.TxtLote2.Text.Trim.Length = 0 Then Me.TxtLote2.Text = ""

            '    If i = 1 Then
            '        Me.TxtNumero3.Focus()
            '    ElseIf i = 2 Then
            '        Me.TxtManzana2.Focus()
            '    Else
            '        Me.TxtLote2.Focus()
            '    End If
            '    Return
            'End If

            'If Me.TxtNumero3.Text.Trim.Length = 0 And (Me.TxtManzana2.Text.Trim.Length = 0 Or Me.TxtLote2.Text.Trim.Length = 0) Then
            '    Dim sMje As String = ""
            '    Dim i As Integer
            '    If Me.TxtManzana2.Text.Trim.Length = 0 Then
            '        sMje = "Manzana de la Vía"
            '        i = 1
            '    Else
            '        sMje = "Lote de la Vía"
            '        i = 2
            '    End If
            '    MessageBox.Show("Ingrese " & sMje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    bSalir = False
            '    If Me.TxtManzana2.Text.Trim.Length = 0 Then Me.TxtManzana2.Text = ""
            '    If Me.TxtLote2.Text.Trim.Length = 0 Then Me.TxtLote2.Text = ""
            '    If i = 1 Then
            '        Me.TxtManzana2.Focus()
            '    Else
            '        Me.TxtLote2.Focus()
            '    End If
            '    Return
            'End If

            'If Me.CboNivel2.SelectedValue > 0 AndAlso Me.TxtNivel2.Text.Trim.Length = 0 Then
            '    MessageBox.Show("Ingrese Nombre del Nivel", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    bSalir = False
            '    Me.TxtNivel2.Text = ""
            '    Me.TxtNivel2.Focus()
            '    Return
            'End If

            'If Me.CboZona2.SelectedValue > 0 AndAlso Me.TxtZona2.Text.Trim.Length = 0 Then
            '    MessageBox.Show("Ingrese Nombre de la Zona", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    bSalir = False
            '    Me.TxtZona2.Text = ""
            '    Me.TxtZona2.Focus()
            '    Return
            'End If

            'If Me.CboClasificacion2.SelectedValue > 0 AndAlso Me.TxtClasificacion2.Text.Trim.Length = 0 Then
            '    MessageBox.Show("Ingrese Nombre de la Clasificación", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    bSalir = False
            '    Me.TxtClasificacion2.Text = ""
            '    Me.TxtClasificacion2.Focus()
            '    Return
            'End If
        End If

        bSalir = True
    End Sub

    Private Sub CboDocContacto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not IsReference(Me.CboDocContacto.SelectedValue) Then
            Me.txtnrodocumento.Text = ""
            Me.txtnrodocumento.ReadOnly = False
            If Me.CboDocContacto.SelectedValue = 1 Then
                Me.txtnrodocumento.MaxLength = 11
            ElseIf Me.CboDocContacto.SelectedValue = 3 Then
                Me.txtnrodocumento.MaxLength = 8
            ElseIf Me.CboDocContacto.SelectedValue = 9 Then
                Me.txtnrodocumento.ReadOnly = True
                Me.txtnom.Focus()
            Else
                Me.txtnrodocumento.MaxLength = 20
            End If
        End If
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

    Private Sub txtnrodocumento2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

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
End Class