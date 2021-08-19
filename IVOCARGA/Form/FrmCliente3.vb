Imports INTEGRACION_LN
Imports INTEGRACION_EN


Public Class FrmCliente3
    Public dtDepartamento, dtDepartamento2 As DataTable
    Public dtProvincia, dtProvincia2 As DataTable
    Public dtDistrito, dtDistrito2 As DataTable

    '----
    Public bClienteNuevo As Boolean
    Public bClienteModificado As Boolean
    Public bDireccionModificada As Boolean
    Public bContactoNuevo, bContactoModificado As Boolean
    Public bRemitenteNuevo, bRemitenteModificado As Boolean
    '---

    Dim sNumero, sCliente, sNombres, sAp, sAm, sTelfCliente, sEmail As String

    Dim iTipo As Integer
    Dim iDepartamento, iProvincia, iDistrito, iId_via, iId_nivel, iId_Zona, iId_Clasificacion As Integer
    Dim sVia, sNumero2, sManzana, sLote, sNivel, sClasificacion, sZona As String
    Dim sNumero3, sContacto, sNombresCont, sApCont, sAmCont As String
    Dim sNroDocRemitente As String = "", sRemitente As String = "", sNombresRemitente As String = "", sApRemitente As String = "", sAmRemitente As String = ""

    Dim iTipo2 As Integer, iTipo3 As Integer
    Dim bEsCliente, bEsCliente2 As Boolean

    Public iFicha As Integer
    Public iTipoEntrega As Integer
    Public iProducto As Integer

    Dim dt As DataTable
    Dim iOpcion As Integer

    Public iTipoDoc As Integer
    Dim bClienteCredito As Boolean
    Dim sNombreCli, sApePatCli, sApeMatCli, sTelfCli As String

    Dim bSalir As Boolean = True

    Public iTipoVenta As Integer

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
            Me.txtrazon.Focus()
        ElseIf iFicha = 1 Then
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
                .SelectedValue = 3
            End With

            Dim dtTipoDocumento As DataTable = ds.Tables(8).Copy
            With CboDocContacto
                .DataSource = dtTipoDocumento
                .DisplayMember = "tipo_doc_identidad"
                .ValueMember = "idtipo_doc_identidad"
                .SelectedValue = 0
            End With

            Dim dtTipoDocumento2 As DataTable = ds.Tables(8).Copy
            With CboDocRemitente
                .DataSource = dtTipoDocumento2
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
                Me.LblCliente.Text = "Raz. Soc."
                Me.LblApep.Visible = False
                Me.LblApeM.Visible = False
                Me.TxtAPCliente.Visible = False
                Me.TxtAMCliente.Visible = False
                Me.LblCliente.Top = 50
                Me.TxtCliente.Top = 47
                Me.TxtAPCliente.Text = ""
                Me.TxtAMCliente.Text = ""
                Me.GrbContacto.Enabled = True
                Me.CboDocContacto.SelectedValue = 0
                Me.CboDocRemitente.SelectedValue = 0
            Else
                Me.LblCliente.Text = "Nombres"
                Me.LblCliente.Top = 37
                Me.TxtCliente.Top = 34
                Me.LblApep.Visible = True
                Me.LblApeM.Visible = True
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
                'Me.GrbContacto.Enabled = False
                'Me.CboDocContacto.SelectedValue = 0
                'Me.CboDocRemitente.SelectedValue = 0
                sNumero3 = "" : sContacto = "" : sApCont = "" : sAmCont = ""
                sNroDocRemitente = "" : sRemitente = "" : sNombresRemitente = "" : sApRemitente = "" : sAmRemitente = ""
                Me.ChkCliente.Checked = False
                Me.ChkCliente2.Checked = False
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
            If Not ValidarLetraNumero(e.KeyChar) Then
                e.Handled = True
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

                Dim ds As New DataSet
                If iTipoVenta = TipoVenta.Contado Then
                    Dim obj As New dtoVentaCargaContado
                    ds = obj.BuscarCliente(sItem, 2)
                Else
                    Dim obj As New dtoGuiaEnvio
                    ds = obj.BuscarClienteCredito(sItem)
                End If
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
            If Me.CboTipoDocumento.SelectedValue = 1 Then
                Me.GrbContacto.Enabled = True
            Else
                'Me.GrbContacto.Enabled = False
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
            Me.txtrazon.Focus()
        Else
            Me.BtnAceptar.Enabled = True
            Me.CboTipoDocumento.Focus()
        End If
    End Sub

    Private Sub ChkCliente2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCliente2.CheckedChanged
        If ChkCliente2.Checked = True Then
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
            End If

            If i > 0 Then
                MessageBox.Show("Ingrese " & sMje & " ", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ChkCliente2.Checked = False

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
                End If
            Else
                CboDocRemitente.SelectedValue = CboTipoDocumento.SelectedValue
                TxtNumeroRemitente.Text = TxtNumero.Text
                TxtRemitente.Text = TxtCliente.Text.Trim
                If CboDocRemitente.SelectedValue = 1 Then
                    sCliente = Me.TxtCliente.Text.Trim
                    TxtRemitente.Text = sCliente
                    TxtAPRemitente.Visible = False
                    TxtAMRemitente.Visible = False
                    LblAP.Visible = False
                    LblAM.Visible = False
                Else
                    sNombreCli = Me.TxtCliente.Text.Trim
                    sApePatCli = Me.TxtAPCliente.Text.Trim
                    sApeMatCli = Me.TxtAMCliente.Text.Trim

                    TxtRemitente.Text = sNombreCli
                    TxtAPRemitente.Text = sApePatCli
                    TxtAMRemitente.Text = sApeMatCli
                    TxtAPRemitente.Visible = True
                    TxtAMRemitente.Visible = True
                    LblAP.Visible = True
                    LblAM.Visible = True
                End If

                'desactivamos los textbox
                CboDocRemitente.Enabled = False
                TxtNumeroRemitente.Enabled = False
                TxtRemitente.Enabled = False
                TxtAPRemitente.Enabled = False
                TxtAMRemitente.Enabled = False
            End If
        Else
            CboDocRemitente.Enabled = True
            CboDocRemitente.SelectedValue = IIf(Me.CboTipoDocumento.SelectedValue = 1, 0, 0)
            TxtNumeroRemitente.Enabled = True
            TxtRemitente.Enabled = True
            '-------
            sNroDocRemitente = ""
            sRemitente = ""
            sApRemitente = ""
            sAmRemitente = ""
            'sTelfCliente = ""

            TxtNumeroRemitente.Text = sNroDocRemitente
            TxtRemitente.Text = sRemitente
            TxtAPRemitente.Text = sApRemitente.Trim
            TxtAMRemitente.Text = sAmRemitente.Trim
            TxtAPRemitente.Visible = True
            TxtAMRemitente.Visible = True
            LblAP.Visible = True
            LblAM.Visible = True
            TxtAPRemitente.Enabled = True
            TxtAMRemitente.Enabled = True
            TxtNumeroRemitente.Text = ""
            TxtRemitente.Text = ""
            TxtNumeroRemitente.Focus()
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
                End If
            Else
                CboDocContacto.SelectedValue = CboTipoDocumento.SelectedValue
                txtnrodocumento.Text = TxtNumero.Text
                TxtContacto.Text = TxtCliente.Text.Trim
                If CboDocContacto.SelectedValue = 1 Then
                    sCliente = Me.TxtCliente.Text.Trim
                    TxtContacto.Text = sCliente
                    TxtAPContacto.Visible = False
                    TxtAMContacto.Visible = False
                    lblApeMat.Visible = False
                    LblApellPat.Visible = False
                Else
                    sNombreCli = Me.TxtCliente.Text.Trim
                    sApePatCli = Me.TxtAPCliente.Text.Trim
                    sApeMatCli = Me.TxtAMCliente.Text.Trim

                    TxtContacto.Text = sNombreCli
                    TxtAPContacto.Text = sApePatCli
                    TxtAMContacto.Text = sApeMatCli
                    TxtAPContacto.Visible = True
                    TxtAMContacto.Visible = True
                    LblApellPat.Visible = True
                    lblApeMat.Visible = True
                End If

                'desactivamos los textbox
                CboDocContacto.Enabled = False
                txtnrodocumento.Enabled = False
                TxtContacto.Enabled = False
                TxtAPContacto.Enabled = False
                TxtAMContacto.Enabled = False

                ''desactivamos los textbox
                'txtnrodocumento.Enabled = False
                'txtnomContacto.Enabled = False
                'CboDocContacto.Enabled = False
                'If CboTipoDocumento.SelectedValue = 1 Then
                '    LblApellPat.Visible = False
                '    lblApeMat.Visible = False
                '    txtapePCont.Visible = False
                '    txtapeMCont.Visible = False
                '    txtapePCont.Text = ""
                '    txtapeMCont.Text = ""
                'End If

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
            lblApeMat.Visible = True
            LblApellPat.Visible = True
            TxtAPContacto.Enabled = True
            TxtAMContacto.Enabled = True
            txtnrodocumento.Text = ""
            TxtContacto.Text = ""
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

                If Me.txtTelefono.Text.Trim.Length < 6 Then
                    MessageBox.Show("Ingrese un Número de Teléfono Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    txtTelefono.Text = txtTelefono.Text.Trim()
                    txtTelefono.Focus()
                    Return
                End If

                If Val(Me.txtTelefono.Text.Trim.Substring(0, 1)) < 2 Then
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

                If Me.txtTelefono.Text.Trim.Length < 6 Then
                    MessageBox.Show("Ingrese un Número de Teléfono Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    txtTelefono.Text = txtTelefono.Text.Trim()
                    txtTelefono.Focus()
                    Return
                End If

                If Val(Me.txtTelefono.Text.Trim.Substring(0, 1)) < 2 Then
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

                If Me.txtTelefono.Text.Trim.Length < 6 Then
                    MessageBox.Show("Ingrese un Número de Teléfono Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    txtTelefono.Text = txtTelefono.Text.Trim()
                    txtTelefono.Focus()
                    Return
                End If

                If Val(Me.txtTelefono.Text.Trim.Substring(0, 1)) < 2 Then
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
                If Me.TxtVia.Text.Trim.Length = 0 And CboZona.SelectedValue = 0 Then 'cambio 03102010
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
                    If Me.TxtNumero2.Text.Trim.Length = 0 And CboVia.SelectedValue > 0 Then 'cambio 03102010
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

            'remitente
            If CboDocRemitente.SelectedValue = 0 Then
                MessageBox.Show("Seleccione Tipo de Documento.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                Me.CboDocRemitente.Focus()
                Return
            End If

            If CboDocRemitente.SelectedValue = 1 Then
                If Not fnValidarRUC(TxtNumeroRemitente.Text) Then
                    MessageBox.Show("El RUC no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtNumeroRemitente.Focus()
                    Return
                End If

                If bRemitenteNuevo AndAlso Not ChkCliente2.Checked Then
                    Dim objContacto As New dtoVentaCargaContado
                    Dim dt As DataTable = objContacto.BuscarContacto(TxtNumero.Text.Trim, TxtNumeroRemitente.Text.Trim)
                    Dim resp As Integer = dt.Rows.Count
                    If resp >= 1 Then
                        MessageBox.Show("EL Nº de Documento ya Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        bSalir = False
                        TxtNumeroRemitente.Focus()
                        Return
                    End If

                    If TxtNumeroRemitente.Text.Trim = TxtNumero.Text.Trim Then
                        Me.ChkCliente2.Checked = True
                    End If
                End If

                If Me.TxtRemitente.Text.Trim.Length = 0 And Me.GrbRemitente.Enabled Then
                    MessageBox.Show("Ingrese Razón Social del Remitente", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtRemitente.Text = TxtRemitente.Text.Trim()
                    TxtRemitente.Focus()
                    Return
                End If

            ElseIf CboDocRemitente.SelectedValue = 3 Then
                If TxtNumeroRemitente.Text.Length <> 8 And Me.GrbRemitente.Enabled Then
                    MessageBox.Show("El DNI no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtNumeroRemitente.Text = TxtNumeroRemitente.Text.Trim()
                    TxtNumeroRemitente.Focus()
                    Return
                End If

                If bRemitenteNuevo AndAlso Not ChkCliente2.Checked Then
                    Dim objContacto As New dtoVentaCargaContado
                    Dim dt As DataTable = objContacto.BuscarContacto(TxtNumero.Text.Trim, TxtNumeroRemitente.Text.Trim)
                    Dim resp As Integer = dt.Rows.Count
                    If resp >= 1 Then
                        MessageBox.Show("EL Nº de Documento ya Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        bSalir = False
                        TxtNumeroRemitente.Focus()
                        Return
                    End If

                    If TxtNumeroRemitente.Text.Trim = TxtNumero.Text.Trim Then
                        Me.ChkCliente2.Checked = True
                    End If
                End If
            Else
                If Me.CboDocRemitente.SelectedValue <> 9 AndAlso TxtNumeroRemitente.Text.Length < 6 AndAlso Me.GrbRemitente.Enabled Then
                    MessageBox.Show("El Nº de Documento no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtNumeroRemitente.Text = TxtNumeroRemitente.Text.Trim()
                    TxtNumeroRemitente.Focus()
                    Return
                Else
                    If bRemitenteNuevo AndAlso Not ChkCliente2.Checked Then
                        Dim objContacto As New dtoVentaCargaContado
                        Dim dt As DataTable = objContacto.BuscarContacto(TxtNumero.Text.Trim, TxtNumeroRemitente.Text.Trim)
                        Dim resp As Integer = dt.Rows.Count
                        If resp >= 1 Then
                            MessageBox.Show("EL Nº de Documento ya Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            bSalir = False
                            TxtNumeroRemitente.Focus()
                            Return
                        End If

                        If TxtNumeroRemitente.Text.Trim = TxtNumero.Text.Trim Then
                            Me.ChkCliente2.Checked = True
                        End If
                    End If
                End If
            End If
            If CboDocRemitente.SelectedValue <> 1 Then
                If Me.TxtRemitente.Text.Trim.Length = 0 And Me.GrbRemitente.Enabled Then
                    MessageBox.Show("Ingrese Nombres del Remitente", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtRemitente.Text = TxtRemitente.Text.Trim()
                    TxtRemitente.Focus()
                    Return
                End If

                If Me.TxtAPRemitente.Text.Trim.Length = 0 And Me.GrbRemitente.Enabled Then
                    MessageBox.Show("Ingrese Apellido Paterno del Remitente", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtAPRemitente.Text = TxtAPRemitente.Text.Trim()
                    TxtAPRemitente.Focus()
                    Return
                End If
            End If

            'contacto
            If CboDocContacto.SelectedValue = 0 Then
                MessageBox.Show("Seleccione Tipo de Documento.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                Me.CboDocContacto.Focus()
                Return
            End If

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

            'Verifica si Remitente
            If Me.ChkCliente2.Checked Then
                If Me.CboTipoDocumento.SelectedValue <> Me.CboDocRemitente.SelectedValue Then
                    Me.CboDocRemitente.SelectedValue = Me.CboTipoDocumento.SelectedValue
                End If

                If Me.TxtNumero.Text <> Me.TxtNumeroRemitente.Text Then
                    Me.TxtNumeroRemitente.Text = Me.TxtNumero.Text
                End If

                If Me.TxtCliente.Text <> Me.TxtRemitente.Text Then
                    Me.TxtRemitente.Text = Me.TxtCliente.Text
                End If

                If Me.CboTipoDocumento.SelectedValue <> 1 Then
                    If Me.TxtAPCliente.Text <> Me.TxtAPRemitente.Text Then
                        Me.TxtAPRemitente.Text = Me.TxtAPCliente.Text
                    End If

                    If Me.TxtAMCliente.Text <> Me.TxtAMRemitente.Text Then
                        Me.TxtAMRemitente.Text = Me.TxtAMCliente.Text
                    End If
                End If
            End If

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
                Me.TxtEmail.Text = Me.TxtEmail.Tag Then '07092011
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
                bDireccionModificada = True
            End If

            '*******Verifica si el remitente ha sido modificado************
            If Me.CboDocRemitente.SelectedValue = Me.CboDocRemitente.Tag AndAlso _
                Me.TxtNumeroRemitente.Text = Me.TxtNumeroRemitente.Tag AndAlso _
                Me.TxtRemitente.Text = Me.TxtRemitente.Tag AndAlso _
                Me.TxtAPRemitente.Text = Me.TxtAPRemitente.Tag AndAlso _
                Me.TxtAMRemitente.Text = Me.TxtAMRemitente.Tag Then
                bRemitenteModificado = False
            Else
                bRemitenteModificado = True
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
    ''******** se graba la direccion modificada******************
    'Private Function F_save() As Integer
    '    Dim Obj_InsDireccionCliente_LN As New Cls_InDireccionCliente_LN
    '    Dim Obj_InsDireccionCliente_EN As New Cls_InDireccionCliente_EN

    '    Dim lStr_MsgGuardar As String = ""
    '    Dim lInt_Resultado As Integer

    '    lInt_Resultado = MessageBox.Show("Está seguro de guardar el registro", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)


    '    If lInt_Resultado = Windows.Forms.DialogResult.No Then

    '        Return -1
    '    Else
    '        Windows.Forms.Cursor.Show()
    '        Windows.Forms.Cursor.Current = Cursors.WaitCursor

    '        If Me.TxtOperacion.Text = "NEW" Then

    '            With Obj_InsDireccionCliente_EN

    '                .IdDepartamento = CboDepartamento.Text
    '                .IdProvincia = CboProvincia.Text
    '                .IdDistrito = CboDistrito.Text
    '                .idVia = CboVia.Text
    '                .DesVia = TxtVia.Text
    '                .Numero = TxtNumero2.Text
    '                .Manzana = TxtManzana.Text
    '                .Lote = TxtLote.Text
    '                .IdNivel = CboNivel.Text
    '                .DesNivel = TxtNivel.Text
    '                .IdZona = CboZona.Text
    '                .DesZona = TxtZona.Text
    '                .IdClasificacion = CboClasificacion.Text
    '                .Clasificacion = TxtClasificacion.Text

    '            End With

    '            lStr_MsgGuardar = Obj_InsDireccionCliente_LN.F_InsDireccionRemitente_LN(Obj_InsDireccionCliente_EN)

    '            'If lStr_MsjSave.Length > 0 Then
    '            If Not IsNumeric(CInt(lStr_MsgGuardar)) Then
    '                MsgBox(lStr_MsgGuardar, MsgBoxStyle.Critical, "Error")
    '                Return -1
    '            Else
    '                MsgBox("La Direccion del Remitente se registró satisfactoriamente", MsgBoxStyle.Information, "Aviso")
    '            End If
    '        End If
    '    End If
    'End Function
    '' **************** fin de grabar *********


    Private Sub CboDocRemitente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDocRemitente.SelectedIndexChanged
        If Not IsReference(Me.CboDocRemitente.SelectedValue) Then
            Me.TxtNumeroRemitente.Text = ""
            Me.TxtNumeroRemitente.ReadOnly = False
            If Me.CboDocRemitente.SelectedValue = 1 Then
                Me.TxtNumeroRemitente.MaxLength = 11
                Me.LblNombreRemitente.Text = "Raz. Soc."
                Me.LblAP.Visible = False
                Me.LblAM.Visible = False
                Me.TxtAPRemitente.Visible = False
                Me.TxtAMRemitente.Visible = False
                Me.LblNombreRemitente.Top = 50
                Me.TxtRemitente.Top = 47
                Me.TxtAPRemitente.Text = ""
                Me.TxtAMRemitente.Text = ""
                Me.TxtNumeroRemitente.Enabled = True
            Else
                Me.LblNombreRemitente.Text = "Nombres"
                Me.LblNombreRemitente.Top = 39
                Me.TxtRemitente.Top = 37
                Me.LblAP.Visible = True
                Me.LblAM.Visible = True
                Me.TxtAPRemitente.Visible = True
                Me.TxtAMRemitente.Visible = True

                If Me.CboDocRemitente.SelectedValue = 3 Then
                    Me.TxtNumeroRemitente.MaxLength = 8
                    Me.TxtNumeroRemitente.Enabled = True
                ElseIf Me.CboDocRemitente.SelectedValue = 9 Then
                    Me.TxtNumeroRemitente.Text = ""
                    Me.TxtNumeroRemitente.Enabled = False
                    Me.TxtRemitente.Focus()
                Else
                    Me.TxtNumeroRemitente.MaxLength = 20
                    Me.TxtNumeroRemitente.Enabled = True
                End If
                'Me.ChkCliente.Checked = False
            End If
            Me.TxtRemitente.Text = Me.TxtRemitente.Text.Trim
        End If
    End Sub

    Private Sub CboDocContacto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDocContacto.SelectedIndexChanged
        If Not IsReference(Me.CboDocContacto.SelectedValue) Then
            Me.txtnrodocumento.Text = ""
            Me.txtnrodocumento.ReadOnly = False
            If Me.CboDocContacto.SelectedValue = 1 Then
                Me.txtnrodocumento.MaxLength = 11
                Me.LblContacto.Text = "Raz. Soc."
                Me.LblApellPat.Visible = False
                Me.lblApeMat.Visible = False
                Me.TxtAPContacto.Visible = False
                Me.TxtAMContacto.Visible = False
                Me.LblContacto.Top = 50
                Me.TxtContacto.Top = 47
                Me.TxtAPContacto.Text = ""
                Me.TxtAMContacto.Text = ""
                Me.GrbContacto.Enabled = True
                Me.txtnrodocumento.Enabled = True
            Else
                Me.LblContacto.Text = "Nombres"
                Me.LblContacto.Top = 39
                Me.TxtContacto.Top = 37
                Me.LblApellPat.Visible = True
                Me.lblApeMat.Visible = True
                Me.TxtAPContacto.Visible = True
                Me.TxtAMContacto.Visible = True

                If Me.CboDocContacto.SelectedValue = 3 Then
                    Me.txtnrodocumento.MaxLength = 8
                    Me.txtnrodocumento.Enabled = True
                ElseIf Me.CboDocContacto.SelectedValue = 9 Then
                    Me.txtnrodocumento.Text = ""
                    Me.txtnrodocumento.Enabled = False
                    Me.TxtContacto.Focus()
                Else
                    Me.txtnrodocumento.MaxLength = 20
                    Me.txtnrodocumento.Enabled = True
                End If
                'Me.ChkCliente.Checked = False
            End If
            Me.TxtContacto.Text = Me.TxtContacto.Text.Trim
        End If
        'If Not IsReference(Me.CboDocContacto.SelectedValue) Then
        '    Me.txtnrodocumento.Text = ""
        '    Me.txtnrodocumento.ReadOnly = False
        '    If Me.CboDocContacto.SelectedValue = 1 Then
        '        Me.txtnrodocumento.MaxLength = 11
        '    ElseIf Me.CboDocContacto.SelectedValue = 3 Then
        '        Me.txtnrodocumento.MaxLength = 8
        '    ElseIf Me.CboDocContacto.SelectedValue = 9 Then
        '        Me.txtnrodocumento.ReadOnly = True
        '        Me.txtnomContacto.Focus()
        '    Else
        '        Me.txtnrodocumento.MaxLength = 20
        '    End If
        'End If
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
               ByVal AppCont As String, ByVal ApmCont As String, ByVal TelfCliente As String, ByVal escliente As Boolean, ByVal EsCliente2 As Boolean, _
               ByVal NombreCli As String, ByVal ApePatCli As String, ByVal ApeMatCli As String, ByVal TelfCli As String, _
               ByVal tipo3 As Integer, ByVal NroDocRemitente As String, ByVal remitente As String, ByVal NombresRemitente As String, _
               ByVal ApRemitente As String, ByVal AmRemitente As String, ByVal Email As String, ByVal ClienteCredito As Boolean)
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
        bEsCliente2 = EsCliente2
        sNombreCli = NombreCli
        sApePatCli = ApePatCli
        sApeMatCli = ApeMatCli
        sTelfCli = TelfCli
        iTipo3 = tipo3
        sNroDocRemitente = NroDocRemitente
        sRemitente = remitente
        sNombresRemitente = NombresRemitente
        sApRemitente = ApRemitente
        sAmRemitente = AmRemitente
        sEmail = Email '07092011
        bClienteCredito = ClienteCredito
    End Sub

    Sub Mostrar()
        'cliente
        If Me.CboTipoDocumento.SelectedValue <> 1 AndAlso fnValidarRUC(sNumero.Trim) Then
            iTipo = 1
        End If
        Me.CboTipoDocumento.SelectedValue = IIf(iTipo <= 0, 3, iTipo)
        Me.TxtNumero.Text = sNumero
        Me.txtTelefono.Text = sTelfCliente.Trim
        Me.TxtEmail.Text = sEmail.Trim '07092011
        If iTipo = 1 Then
            'cliente
            Me.TxtCliente.Text = sCliente.Trim
            Me.TxtAPCliente.Text = ""
            Me.TxtAMCliente.Text = ""
            'Me.txtnomContacto.Text = sContacto.Trim
        Else
            'cliente
            Me.TxtCliente.Text = sNombres.Trim
            Me.TxtAPCliente.Text = sAp.Trim
            Me.TxtAMCliente.Text = sAm.Trim
        End If

        'remitente
        Me.TxtRemitente.Text = sNombresRemitente.Trim 'new
        Me.TxtAPRemitente.Text = sApRemitente.Trim
        Me.TxtAMRemitente.Text = sAmRemitente.Trim
        Me.CboDocRemitente.SelectedValue = iTipo3

        'contacto
        Me.TxtContacto.Text = sNombresCont.Trim 'new
        Me.TxtAPContacto.Text = sApCont.Trim
        Me.TxtAMContacto.Text = sAmCont.Trim
        Me.CboDocContacto.SelectedValue = iTipo2

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
        '--remitente
        If iProducto = 6 Then
            If iTipo3 <= 0 Then
                'Me.CboDocContacto.SelectedValue = IIf(iTipo2 <= 0, 3, iTipo2)
                If Me.CboTipoDocumento.SelectedValue <> 3 Then
                    Me.CboDocRemitente.SelectedValue = 0
                Else
                    Me.CboDocRemitente.SelectedValue = 3
                End If
            Else
                Me.CboDocRemitente.SelectedValue = iTipo3
            End If
        Else
            Me.CboDocRemitente.SelectedValue = iTipo3
        End If
        Me.CboDocRemitente.Tag = Me.CboDocRemitente.SelectedValue
        Me.TxtNumeroRemitente.Text = sNroDocRemitente
        Me.TxtNumeroRemitente.Tag = Me.TxtNumeroRemitente.Text
        Me.TxtRemitente.Tag = Me.TxtRemitente.Text
        Me.TxtAPRemitente.Tag = Me.TxtAPRemitente.Text
        Me.TxtAMRemitente.Tag = Me.TxtAMRemitente.Text
        '---
        Me.txtTelefono.Tag = Me.txtTelefono.Text
        Me.TxtEmail.Tag = Me.TxtEmail.Text.Trim
        Me.TxtCliente.Tag = Me.TxtCliente.Text
        Me.TxtAPCliente.Tag = Me.TxtAPCliente.Text
        Me.TxtAMCliente.Tag = Me.TxtAMCliente.Text

        'RemoveHandler Me.ChkCliente.CheckedChanged, AddressOf ChkCliente_CheckedChanged
        Me.ChkCliente2.Checked = bEsCliente2
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
            'Me.CboTipoDocumento.Enabled = False
            'Me.TxtNumero.Enabled = False
        End If

        If Me.CboTipoDocumento.SelectedValue = 9 AndAlso Me.TxtNumero.Text.Trim.Length = 0 Then
            Me.TxtNumero.Enabled = False
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
            Me.TxtEmail.Enabled = False
        End If
        'If Me.CboTipoDocumento.SelectedValue = 1 Then
        '    Me.GrbContacto.Enabled = True
        'Else
        '    'Me.GrbContacto.Enabled = False
        'End If
    End Sub

    Private Sub txtapem_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAMCliente.KeyPress
        If Not ValidarLetra(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtnom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtContacto.KeyPress
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

    Private Sub txtTelefono_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTelefono.Enter
        txtTelefono.SelectAll()
    End Sub

    Private Sub txtTelefono_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono.KeyPress
        If Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNumeroRemitente_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNumeroRemitente.Enter
        TxtNumeroRemitente.SelectAll()
    End Sub

    Private Sub TxtNumeroRemitente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumeroRemitente.KeyPress
        If Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtRemitente_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtRemitente.Enter
        TxtRemitente.SelectAll()
    End Sub

    Private Sub TxtRemitente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRemitente.KeyPress
        If Me.CboDocRemitente.SelectedValue = 1 Then
            If Not ValidarLetraNumero(e.KeyChar) Then
                e.Handled = True
            End If
        Else
            If Not ValidarLetra(e.KeyChar) Then
                e.Handled = True
            End If
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

    Private Sub TxtAP_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAPRemitente.Enter
        TxtAPRemitente.SelectAll()
    End Sub

    Private Sub TxtAM_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAMRemitente.Enter
        TxtAMRemitente.SelectAll()
    End Sub

    Private Sub TxtAP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAPRemitente.KeyPress
        If Not ValidarLetra(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtAM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAMRemitente.KeyPress
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


    Private Sub dgvBuscar_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBuscar.CellContentClick

    End Sub

    Private Sub TxtNumero_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtNumero.TextChanged

    End Sub

    Private Sub TxtCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCliente.TextChanged

    End Sub

    Private Sub TxtAPCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtAPCliente.TextChanged

    End Sub

    Private Sub TxtAMCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtAMCliente.TextChanged

    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click

    End Sub
End Class