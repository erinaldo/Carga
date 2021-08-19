Public Class FrmConsignado
    Public dtDepartamento, dtDepartamento2 As DataTable
    Public dtProvincia, dtProvincia2 As DataTable
    Public dtDistrito, dtDistrito2 As DataTable

    Public bConsignadoNuevo As Boolean
    Public bConsignadoModificado As Boolean
    Public bDirecConsigMod As Boolean

    Dim sNombreCli, sApePatCli, sApeMatCli, sTelfCli As String
    Dim sNumero, sCliente, sNombres, sApePConsig, sApeMConsig, sTelfConsig As String
    Public iTipoDoc As Integer
    Public sNumeroDoc As String = ""
    Public snombre As String = ""

    Dim iTipo As Integer
    Dim iDepartamento, iProvincia, iDistrito, iId_via, iId_nivel, iId_Zona, iId_Clasificacion As Integer
    Dim sVia, sNumero2, sManzana, sLote, sNivel, sClasificacion, sZona As String
    Dim sNumero3, sConsignado, sNombresConsig As String
    Dim sReferencia As String
    Dim iTipo2 As Integer
    Dim bEsCliente As Boolean
    Dim iIDConsignado As Integer

    Public iFicha As Integer
    Public iTipoEntrega As Integer
    Public idUnidadAgencias As Integer
    Dim iOpcion As Integer

    'Public sNumero, sCliente, sNombres, sAp, sAm As String
    Dim bSalir As Boolean = True

    Private Sub FrmConsignado_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Cursor = Cursors.Default
        If iFicha = 0 Then
            bConsignadoNuevo = True
            BtnNuevo.Visible = False
            Me.txtrazon.Focus()
        ElseIf iFicha = 1 Then
            BtnNuevo.Visible = True
            If bConsignadoNuevo Then
                Me.CboTipoDocumento.Focus()
            Else
                Me.txtTelefono.Focus()
            End If
        End If
    End Sub

    Private Sub FrmConsignado_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not bSalir Then
            bSalir = True
            e.Cancel = True            
        End If
    End Sub

    Private Sub FrmConsignado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Formato()
        Me.Inicio()
        If sNumero Is Nothing Then sNumero = ""
        If iTipo > 0 Then
            Me.Mostrar()
        End If
        If iTipoEntrega = TipoEntrega.Agencia Then
            Me.GrbDireccion.Enabled = False
        ElseIf iTipoEntrega = TipoEntrega.Domicilio Then
            Me.GrbDireccion.Enabled = True
        Else
            Me.GrbDireccion.Enabled = False
        End If
        ToolTip.SetToolTip(Me.BtnNuevo, "Nuevo Consignado")
        Me.TabConsignado.SelectedIndex = iFicha
    End Sub

    Sub Inicio()
        Try
            Dim obj As New dtoVentaCargaContado
            Dim ds As New DataSet
            If idUnidadAgencias < 1 Then
                ds = obj.Inicio(dtoUSUARIOS.iIDAGENCIAS) 'dtoUSUARIOS.iIDAGENCIAS
            Else
                ds = obj.Inicio(idUnidadAgencias, 1) 'dtoUSUARIOS.iIDAGENCIAS
            End If

            With CboTipoDocumento
                .DataSource = ds.Tables(8)
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
                CboProvincia.DataSource = dtProvincia.DefaultView
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

                'CboProvincia.SelectedValue = ds.Tables(7).Rows(0).Item("prov")
                'If CboProvincia.SelectedIndex < 0 Then CboProvincia.SelectedValue = 0
                CboProvincia.SelectedValue = 0
                CboDepartamento_SelectedIndexChanged(sender, e)
                'CboProvincia_SelectedIndexChanged(sender, e)
                CboDistrito.SelectedValue = 0
            Else
                CboDepartamento_SelectedIndexChanged(sender, e)
                'CboProvincia_SelectedIndexChanged(sender, e)
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

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

            Dim idcontacto_persona As New DataGridViewTextBoxColumn
            With idcontacto_persona
                .HeaderText = "idcontacto_persona"
                .Name = "idcontacto_persona"
                .DataPropertyName = "idcontacto_persona"
                .Visible = False
            End With

            Dim idtipo_documento_contacto As New DataGridViewTextBoxColumn
            With idtipo_documento_contacto
                .HeaderText = "Tipo"
                .Name = "Tipo"
                .DataPropertyName = "Tipo"
                .Visible = False
            End With

            Dim tipo_doc_identidad As New DataGridViewTextBoxColumn
            With tipo_doc_identidad
                .HeaderText = "Tipo Documento"
                .Name = "Tipo2"
                .DataPropertyName = "Tipo2"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            Dim nrodocumento As New DataGridViewTextBoxColumn
            With nrodocumento
                .HeaderText = "Nº Documento"
                .Name = "nrodocumento"
                .DataPropertyName = "nrodocumento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            Dim nombres As New DataGridViewTextBoxColumn
            With nombres
                .HeaderText = "Nombres"
                .Name = "nombres"
                .DataPropertyName = "nombres"
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

            Dim apepat As New DataGridViewTextBoxColumn
            With apepat
                .HeaderText = "apepat"
                .Name = "apepat"
                .DataPropertyName = "apepat"
                .Visible = False
            End With

            Dim apemat As New DataGridViewTextBoxColumn
            With apemat
                .HeaderText = "apemat"
                .Name = "apemat"
                .DataPropertyName = "apemat"
                .Visible = False
            End With

            .Columns.AddRange(idcontacto_persona, idtipo_documento_contacto, tipo_doc_identidad, nrodocumento, nombres, telefono, apepat, apemat)
        End With
    End Sub

    Sub cargar(ByVal dt As DataTable, ByVal opcion As Integer)
        dt = dt
        For i As Integer = 0 To dt.Rows.Count() - 1
            Dim val As String = dt.Rows(i)(1).ToString
        Next
        Me.dgvBuscar.DataSource = dt

        iOpcion = opcion
        Me.txtrazon.Focus()
    End Sub

    Private Sub CboDepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDepartamento.SelectedIndexChanged
        If Not IsReference(CboDepartamento.SelectedValue) Then
            Dim sFiltro As String = "iddepartamento=" & CboDepartamento.SelectedValue & " or iddepartamento=0"
            dtProvincia.DefaultView.RowFilter = sFiltro

            sFiltro = "iddepartamento=" & CboDepartamento.SelectedValue & " or iddepartamento=0"
            dtDistrito.DefaultView.RowFilter = sFiltro
        End If
    End Sub

    Private Sub CboProvincia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboProvincia.SelectedIndexChanged
        If Not IsReference(CboProvincia.SelectedValue) Then
            Dim sFiltro As String = ""
            If CboProvincia.SelectedValue > 0 Then
                sFiltro = "(iddepartamento=" & CboDepartamento.SelectedValue & " or iddepartamento=0) and (idprovincia=" & CboProvincia.SelectedValue & " or idprovincia=0)"
            Else
                sFiltro = "iddepartamento=" & CboDepartamento.SelectedValue & " or iddepartamento=0"
            End If
            dtDistrito.DefaultView.RowFilter = sFiltro
            CboDistrito.SelectedValue = 0
        End If
    End Sub

    Private Sub CboTipoDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoDocumento.SelectedIndexChanged
        If Not IsReference(Me.CboTipoDocumento.SelectedValue) Then
            Me.TxtNumero.Enabled = True
            If Me.CboTipoDocumento.SelectedValue = 1 Then
                Me.TxtNumero.MaxLength = 11
                Me.LblConsignado.Text = "Raz. Soc."
                Me.LblApePat.Visible = False
                Me.lblApeMat.Visible = False
                Me.txtapePConsig.Visible = False
                Me.txtapeMConsig.Visible = False
                Me.LblConsignado.Top = 50
                Me.TxtConsignado.Top = 47
                Me.txtapePConsig.Text = ""
                Me.txtapeMConsig.Text = ""
                Me.GrbConsignado.Enabled = True
            Else
                Me.LblConsignado.Text = "Nombres"
                Me.LblConsignado.Top = 39
                Me.TxtConsignado.Top = 37
                Me.LblApePat.Visible = True
                Me.lblApeMat.Visible = True
                Me.txtapePConsig.Visible = True
                Me.txtapeMConsig.Visible = True

                If Me.CboTipoDocumento.SelectedValue = 3 Then
                    Me.TxtNumero.MaxLength = 8
                ElseIf Me.CboTipoDocumento.SelectedValue = 9 Then
                    Me.TxtNumero.Text = ""
                    Me.TxtNumero.Enabled = False
                    Me.txtTelefono.Focus()
                Else
                    Me.TxtNumero.MaxLength = 20
                End If
                Me.ChkCliente.Checked = False
            End If
            Me.TxtConsignado.Text = Me.TxtConsignado.Text.Trim
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

    Private Sub TxtConsignado_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtConsignado.Enter
        TxtConsignado.SelectAll()
    End Sub

    Private Sub TxtConsignado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtConsignado.KeyPress
        'If Not ValidarLetraNumero(e.KeyChar) Then
        '    e.Handled = True
        'End If
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

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If Me.TabConsignado.SelectedIndex = 0 Then
            'TxtNumero.Text = Me.dgvBuscar.CurrentRow.Cells("nrodocumento").Value
            If IsDBNull(Me.dgvBuscar.CurrentRow.Cells("nrodocumento").Value) Then
                TxtNumero.Text = ""
            Else
                TxtNumero.Text = Me.dgvBuscar.CurrentRow.Cells("nrodocumento").Value
            End If
            TxtNumero.Tag = Me.dgvBuscar.CurrentRow.Cells("idcontacto_persona").Value
            TxtConsignado.Text = Me.dgvBuscar.CurrentRow.Cells("nombres").Value
            bConsignadoNuevo = False
        Else
            Dim obj As New dtrecojo
            Dim snum As String = Me.TxtNumero.Text
            If CboTipoDocumento.SelectedValue = 1 Then
                If Not fnValidarRUC(TxtNumero.Text) Then
                    MessageBox.Show("El RUC no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtNumero.Focus()
                    Return
                End If

                If bConsignadoNuevo AndAlso Not ChkCliente.Checked Then
                    Dim objContacto As New dtoVentaCargaContado
                    Dim dt As DataTable = objContacto.BuscarContacto(TxtNumero.Text.Trim)
                    Dim resp As Integer = dt.Rows.Count
                    If resp >= 1 Then
                        MessageBox.Show("EL Nº de Documento ya Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        bSalir = False
                        TxtNumero.Focus()
                        Return
                    End If

                    If TxtNumero.Text.Trim.Length > 0 AndAlso TxtNumero.Text.Trim = sNumeroDoc.ToString.Trim Then
                        Me.ChkCliente.Checked = True
                    End If
                End If
            ElseIf CboTipoDocumento.SelectedValue = 3 Then
                If TxtNumero.Text.Length <> 8 Then
                    MessageBox.Show("El DNI no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtNumero.Focus()
                    Return
                End If

                If bConsignadoNuevo AndAlso Not ChkCliente.Checked Then
                    Dim objContacto As New dtoVentaCargaContado
                    Dim dt As DataTable = objContacto.BuscarContacto(TxtNumero.Text.Trim)
                    Dim resp As Integer = dt.Rows.Count
                    If resp >= 1 Then
                        MessageBox.Show("EL Nº de Documento ya Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        bSalir = False
                        TxtNumero.Focus()
                        Return
                    End If

                    If TxtNumero.Text.Trim = sNumeroDoc.ToString.Trim Then
                        Me.ChkCliente.Checked = True
                    End If
                End If
            ElseIf Me.CboTipoDocumento.SelectedValue > 0 Then
                If Me.CboTipoDocumento.SelectedValue <> 9 AndAlso TxtNumero.Text.Length < 6 Then
                    MessageBox.Show("El Nº de Documento no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    TxtNumero.Focus()
                    Return
                Else
                    If bConsignadoNuevo AndAlso Not ChkCliente.Checked Then
                        Dim objContacto As New dtoVentaCargaContado
                        Dim dt As DataTable = objContacto.BuscarContacto(TxtNumero.Text.Trim)
                        Dim resp As Integer = dt.Rows.Count
                        If resp >= 1 Then
                            MessageBox.Show("EL Nº de Documento ya Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            bSalir = False
                            TxtNumero.Focus()
                            Return
                        End If

                        If TxtNumero.Text.Trim.Length > 0 AndAlso TxtNumero.Text.Trim = sNumeroDoc.ToString.Trim Then
                            Me.ChkCliente.Checked = True
                        End If
                    End If
                End If
            Else
                MessageBox.Show("Seleccione el Tipo de Documento.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                CboTipoDocumento.Focus()
                Return
            End If

            If Me.txtTelefono.Text.Trim.Length > 0 Then
                If Me.txtTelefono.Text.Trim.Length < 6 Or Val(Me.txtTelefono.Text.Trim.Substring(0, 1)) < 2 Then
                    MessageBox.Show("Ingrese un Número de Teléfono Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    txtTelefono.Text = txtTelefono.Text.Trim()
                    txtTelefono.Focus()
                    Return
                End If
            End If

            If Me.TxtConsignado.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese " & IIf(CboTipoDocumento.SelectedValue = 1, "Razón Social del Cliente", "Nombres del Cliente"), "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                TxtConsignado.Text = TxtConsignado.Text.Trim()
                TxtConsignado.Focus()
                Return
            End If

            If CboTipoDocumento.SelectedValue <> 1 Then
                If Me.txtapePConsig.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Apellido Paterno.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    txtapePConsig.Text = txtapePConsig.Text.Trim()
                    txtapePConsig.Focus()
                    Return
                End If
            End If

            If iTipoEntrega = TipoEntrega.Domicilio Then '==> Entrega es "AGENCIA"
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

            '============Verifica si el consignado ha sido modificada==============
            If Me.TxtConsignado.Text = Me.TxtConsignado.Tag AndAlso _
                Me.txtapePConsig.Text = Me.txtapePConsig.Tag AndAlso _
                Me.txtapeMConsig.Text = Me.txtapeMConsig.Tag AndAlso _
                Me.txtTelefono.Text = Me.txtTelefono.Tag Then
                bConsignadoModificado = False
            Else
                bConsignadoModificado = True
            End If
            '============Verifica si la direccion ha sido modificada==============
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
                Me.TxtClasificacion.Text = Me.TxtClasificacion.Tag AndAlso _
                Me.TxtReferencia.Text = Me.TxtReferencia.Tag Then '09092011
                bDirecConsigMod = False
            Else
                bDirecConsigMod = True
            End If
        End If
            bSalir = True
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

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Try
            If Me.txtrazon.Text.Trim.Length > 0 Then
                Me.Cursor = Cursors.AppStarting
                Dim sItem As String = Me.txtrazon.Text.Trim
                Dim obj As New dtoVentaCargaContado
                Dim ds As New DataSet
                ds = obj.BuscarConsignado(sItem, 2, idUnidadAgencias)
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

    Sub cargar(ByVal tipo As Integer, ByVal numero As String, ByVal Cliente As String, ByVal consignado As String, ByVal NombresConsig As String, ByVal escliente As Boolean, _
           ByVal departamento As Integer, ByVal provincia As Integer, ByVal distrito As Integer, _
           ByVal id_via As Integer, ByVal via As String, ByVal numero2 As String, ByVal manzana As String, _
           ByVal lote As String, ByVal id_nivel As Integer, ByVal nivel As String, ByVal id_zona As Integer, _
           ByVal zona As String, ByVal id_clasificacion As Integer, ByVal clasificacion As String, ByVal ApePConsig As String, ByVal ApeMConsig As String, ByVal TelfConsig As String,
           ByVal NombreCli As String, ByVal ApePatCli As String, ByVal ApeMatCli As String, ByVal TelfCli As String, ByVal Referencia As String, ByVal IDConsignado As Integer)
        sNumero = numero
        iTipo = tipo
        sCliente = Cliente
        sConsignado = consignado
        sNombresConsig = NombresConsig
        bEsCliente = escliente
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
        sApePConsig = ApePConsig
        sApeMConsig = ApeMConsig
        sTelfConsig = TelfConsig
        sNombreCli = NombreCli
        sApePatCli = ApePatCli
        sApeMatCli = ApeMatCli
        sTelfCli = TelfCli
        sReferencia = Referencia
        iIDConsignado = IDConsignado
    End Sub


    Private Sub TabCliente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabConsignado.SelectedIndexChanged
        'If TabConsignado.SelectedIndex = 0 Then
        '    Me.txtrazon.Focus()
        'Else
        '    Me.CboTipoDocumento.Focus()
        'End If
        If TabConsignado.SelectedIndex = 0 Then
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

    Private Sub dgvBuscar_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvBuscar.DoubleClick
        If Me.dgvBuscar.Rows.Count > 0 Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            BtnAceptar_Click(sender, e)
        End If
    End Sub

    Private Sub FrmConsignado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If Me.txtapeMConsig.Focused Then
                If GrbDireccion.Enabled Then
                    Me.CboDistrito.Focus()
                Else
                    Me.BtnAceptar.Focus()
                End If
            Else
                SendKeys.Send("{TAB}")
            End If
            End If
    End Sub

    Sub Mostrar()
        'consignado
        Me.CboTipoDocumento.SelectedValue = IIf(iTipo <= 0, 3, iTipo)
        Me.TxtNumero.Text = sNumero
        'Me.TxtConsignado.Text = sConsignado
        If Me.CboTipoDocumento.SelectedValue = 1 Then
            Me.TxtConsignado.Text = sConsignado
        Else
            Me.TxtConsignado.Text = sNombresConsig
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

        Me.TxtReferencia.Text = sReferencia
        Me.TxtReferencia.Tag = TxtReferencia.Text.Trim

        '---dato consignado--
        Me.TxtConsignado.Tag = Me.TxtConsignado.Text
        'Me.TxtNumero.Text = sNumero2
        Me.TxtNumero.Tag = Me.TxtNumero.Text
        Me.txtapePConsig.Text = sApePConsig
        Me.txtapePConsig.Tag = Me.txtapePConsig.Text
        Me.txtapeMConsig.Text = sApeMConsig
        Me.txtapeMConsig.Tag = Me.txtapeMConsig.Text
        Me.txtTelefono.Text = sTelfConsig
        Me.txtTelefono.Tag = Me.txtTelefono.Text

        '--
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


        'RemoveHandler Me.ChkCliente.CheckedChanged, AddressOf ChkCliente_CheckedChanged
        Me.ChkCliente.Checked = bEsCliente
        'AddHandler Me.ChkCliente.CheckedChanged, AddressOf ChkCliente_CheckedChanged

        If Not bEsCliente Then
            If bConsignadoNuevo Then
                Me.CboTipoDocumento.Enabled = True
                Me.TxtNumero.Enabled = True
            ElseIf iIDConsignado = 0 Then
                Me.CboTipoDocumento.Enabled = True
                Me.TxtNumero.Enabled = True
            Else
                Me.CboTipoDocumento.Enabled = False
                Me.TxtNumero.Enabled = False
            End If

            If Me.CboTipoDocumento.SelectedValue = 9 AndAlso Me.TxtNumero.Text.Trim.Length = 0 Then
                Me.TxtNumero.Enabled = False
            End If
        End If
    End Sub

    Private Sub ChkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCliente.CheckedChanged
        Try
            If ChkCliente.Checked = True Then
                Dim sMje As String = ""
                Dim i As Integer = 0
                If sNumeroDoc.Trim.Length = 0 And CboTipoDocumento.SelectedValue <> 9 Then
                    sMje = "Nº de Documento."
                    i = 1
                End If

                If i > 0 Then
                    MessageBox.Show("Ingrese " & sMje & " ", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ChkCliente.Checked = False

                    If i = 1 Then
                        TxtNumero.Text = ""
                        TxtNumero.Focus()
                    End If
                Else
                    'RemoveHandler Me.CboTipoDocumento.SelectedIndexChanged, AddressOf CboTipoDocumento_SelectedIndexChanged
                    CboTipoDocumento.SelectedValue = iTipoDoc
                    'RemoveHandler Me.ChkCliente.CheckedChanged, AddressOf ChkCliente_CheckedChanged

                    txtTelefono.Text = sTelfCli
                    TxtNumero.Text = sNumeroDoc

                    If iTipoDoc = 1 Then
                        TxtConsignado.Text = sCliente
                        txtapePConsig.Visible = False
                        txtapeMConsig.Visible = False
                        lblApeMat.Visible = False
                        LblApePat.Visible = False
                    Else
                        TxtConsignado.Text = sNombreCli
                        txtapePConsig.Text = sApePatCli
                        txtapeMConsig.Text = sApeMatCli
                        txtapePConsig.Visible = True
                        txtapeMConsig.Visible = True
                        lblApeMat.Visible = True
                        LblApePat.Visible = True
                    End If

                    'desactivamos los textbox
                    TxtNumero.Enabled = False
                    CboTipoDocumento.Enabled = False
                    TxtConsignado.Enabled = False
                    txtapePConsig.Enabled = False
                    txtapeMConsig.Enabled = False
                    txtTelefono.Enabled = False
                End If
            Else
                'activamos los textbox                            
                CboTipoDocumento.Enabled = True
                TxtNumero.Enabled = True
                txtTelefono.Enabled = True
                TxtConsignado.Enabled = True
                txtapePConsig.Enabled = True
                txtapeMConsig.Enabled = True
                txtTelefono.Enabled = True
                txtapePConsig.Visible = True
                txtapeMConsig.Visible = True
                lblApeMat.Visible = True
                LblApePat.Visible = True

                CboTipoDocumento.SelectedValue = 3

                sNumero = ""
                sConsignado = ""
                sApePConsig = ""
                sApeMConsig = ""
                sTelfConsig = ""

                TxtNumero.Text = sNumero
                TxtConsignado.Text = sConsignado
                txtapePConsig.Text = sApePConsig
                txtapeMConsig.Text = sApeMConsig
                txtTelefono.Text = sTelfConsig

                'TxtNumero.Text = ""
                'TxtConsignado.Text = ""
                'txtapePConsig.Text = ""
                'txtapeMConsig.Text = ""
                'txtTelefono.Text = ""
                TxtNumero.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtTelefono_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono.KeyPress
        If Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Me.ConsignadoNuevo()
    End Sub

    Sub ConsignadoNuevo()
        bConsignadoNuevo = True
        bConsignadoModificado = False
        Me.CboTipoDocumento.SelectedValue = 3
        Me.TxtNumero.Text = ""
        Me.txtTelefono.Text = ""
        Me.TxtConsignado.Text = ""
        Me.txtapePConsig.Text = ""
        Me.txtapeMConsig.Text = ""
        Me.ChkCliente.Checked = False

        Me.CboTipoDocumento.Enabled = True
        Me.TxtNumero.Enabled = True
        txtTelefono.Enabled = True
        TxtConsignado.Enabled = True
        txtapePConsig.Enabled = True
        txtapeMConsig.Enabled = True
        txtTelefono.Enabled = True

        Me.CboTipoDocumento.Focus()
    End Sub

    Private Sub CboDistrito_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDistrito.SelectedIndexChanged
        If Not IsReference(CboDistrito.SelectedValue) Then
            Dim iId As Integer = CboDistrito.SelectedValue
            Dim filas() As DataRow = dtDistrito.Select("iddistrito=" & iId)
            RemoveHandler CboProvincia.SelectedIndexChanged, AddressOf CboProvincia_SelectedIndexChanged
            Me.CboProvincia.SelectedValue = filas(0).Item("idprovincia")
            AddHandler CboProvincia.SelectedIndexChanged, AddressOf CboProvincia_SelectedIndexChanged
        End If
    End Sub

    Private Sub GrbDireccion_EnabledChanged(sender As Object, e As System.EventArgs) Handles GrbDireccion.EnabledChanged
        If GrbDireccion.Enabled Then
            Me.lblLlamada1.Visible = True
            Me.lblLlamada2.Visible = True
            Me.lblLlamada3.Visible = True
            Me.lblLlamada4.Visible = True
            Me.lblMensajeLlamada.Visible = True
        Else
            Me.lblLlamada1.Visible = False
            Me.lblLlamada2.Visible = False
            Me.lblLlamada3.Visible = False
            Me.lblLlamada4.Visible = False
            Me.lblMensajeLlamada.Visible = False
        End If
    End Sub

    Private Sub TxtConsignado_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtConsignado.TextChanged

    End Sub

    Private Sub txtapePConsig_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtapePConsig.KeyPress
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

    Private Sub txtapePConsig_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtapePConsig.TextChanged

    End Sub

    Private Sub txtapeMConsig_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtapeMConsig.KeyPress
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

    Private Sub txtapeMConsig_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtapeMConsig.TextChanged

    End Sub
End Class