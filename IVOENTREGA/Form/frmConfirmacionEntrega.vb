Imports INTEGRACION_LN
Imports INTEGRACION_EN
Imports System.IO
Imports System.Text
Imports System.Drawing.Imaging

Public Class frmConfirmacionEntrega

#Region "Propiedad"
    Private intTipoComprobante As Integer
    Public Property TipoComprobante() As Integer
        Get
            Return intTipoComprobante
        End Get
        Set(ByVal value As Integer)
            intTipoComprobante = value
        End Set
    End Property
    Private intComprobante As Integer
    Public Property Comprobante() As Integer
        Get
            Return intComprobante
        End Get
        Set(ByVal value As Integer)
            intComprobante = value
        End Set
    End Property
    Private intModo As Integer
    Public Property Modo() As Integer
        Get
            Return intModo
        End Get
        Set(ByVal value As Integer)
            intModo = value
        End Set
    End Property
    Private intEstado As Integer
    Public Property Estado() As Integer
        Get
            Return intEstado
        End Get
        Set(ByVal value As Integer)
            intEstado = value
        End Set
    End Property
    Private intCliente As Integer
    Public Property Cliente() As Integer
        Get
            Return intCliente
        End Get
        Set(ByVal value As Integer)
            intCliente = value
        End Set
    End Property
    Private intCiudadDestino As Integer
    Public Property CiudadDestino() As Integer
        Get
            Return intCiudadDestino
        End Get
        Set(ByVal value As Integer)
            intCiudadDestino = value
        End Set
    End Property

    Private intLongitudRaw As Integer
    Public Property LongitudRaw() As Integer
        Get
            Return intLongitudRaw
        End Get
        Set(ByVal value As Integer)
            intLongitudRaw = value
        End Set
    End Property

#End Region

#Region "Variables Publicas"
    Dim dtConsignado As DataTable
    Dim intCantidadTotal As Integer
    Dim intEntregada As Integer
    Dim blnSalir As Boolean = True

    'Huella Dactilar
    Dim strArchivo As String
    Dim plantilla() As Byte, parametro() As String
    Dim intCalidad As Integer, intProblema As Integer, strMotivo As String

#End Region

#Region "Configurar Grid"
    Sub FormatearDGVDocumento()
        With dgvBulto
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvLista)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_serie As New DataGridViewTextBoxColumn
            With col_serie
                .Name = "serie" : .DataPropertyName = "serie"
                .DisplayIndex = x : .HeaderText = "Nº Serie" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_documento As New DataGridViewTextBoxColumn
            With col_documento
                .Name = "documento" : .DataPropertyName = "documento"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_serie, col_documento)
        End With
    End Sub
    Sub FormatearDGVBulto()
        With dgvDocumento
            '.Dock = DockStyle.Fill
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            '.RowsDefaultCellStyle.WrapMode =
            .AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
            '.BackgroundColor = SystemColors.Window
            .Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
            .ReadOnly = False
            .AutoGenerateColumns = False
            '.DataSource = dtable_Lista_Control_Comprobante
            .VirtualMode = False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .RowHeadersWidth = 14
            '.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
            '.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            '.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
        End With
        Dim col As New DataGridViewTextBoxColumn
        With col
            .DisplayIndex = 0
            .DataPropertyName = "var"
            .HeaderText = "ID"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .ReadOnly = True
            .Visible = False
        End With
        dgvDocumento.Columns.Add(col)
        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .DisplayIndex = 1
            .DataPropertyName = "TIPO PROCESO"
            .HeaderText = "Tipo"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .ReadOnly = True
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Width = 75
        End With
        dgvDocumento.Columns.Add(col0)

        Dim col2 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
        'Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .DisplayIndex = 2
            .DataPropertyName = "Cantidad"
            .HeaderText = "Bulto"
            .DefaultCellStyle.ForeColor = Color.Black
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Width = 90
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.NullValue = 0
            .Mask = "####0"
            .ReadOnly = True
        End With
        dgvDocumento.Columns.Add(col2)

        Dim col01 As New DataGridViewTextBoxColumn
        With col01
            .DisplayIndex = 3
            .DataPropertyName = "DESCRIPCION"
            .HeaderText = "DESCRIPCION"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .ReadOnly = True
            .Visible = False
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        dgvDocumento.Columns.Add(col01)

        'Dim col1 As New DataGridViewTextBoxColumn
        Dim col1 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
        'Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DisplayIndex = 4
            .DataPropertyName = "PESO_VOLUMEN"
            .HeaderText = "Peso/Volumen"
            .DefaultCellStyle.ForeColor = Color.Black
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            '.Mask = "####,###,###.000"
            .DefaultCellStyle.Format = "####,###,###0.00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
            .Width = 90
        End With
        dgvDocumento.Columns.Add(col1)
        '-------------------------------------------------------------------------------
        Dim col31 As New DataGridViewTextBoxColumn
        With col31
            .DisplayIndex = 5
            .DataPropertyName = "COSTO"
            .HeaderText = "Costo"
            .ReadOnly = True
            .DefaultCellStyle.ForeColor = Color.Black
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Mask = "99999999.999" 'Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
            .DefaultCellStyle.Format = "##,###,###0.00"
            .DefaultCellStyle.NullValue = "0.00"
            '.DefaultCellStyle.NullValue = Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
            .Width = 90
        End With
        dgvDocumento.Columns.Add(col31)
        '-------------------------------------------------------------------------

        'Dim col3 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .DisplayIndex = 6
            .DataPropertyName = "DESCUENTO"
            .HeaderText = "DESCUENTO"
            .ReadOnly = True
            .DefaultCellStyle.ForeColor = Color.Black
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Mask = "99999999.999" 'Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
            .DefaultCellStyle.Format = "##,###,###0.00"
            .DefaultCellStyle.NullValue = "0.00"
            '.DefaultCellStyle.NullValue = Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
            .Width = 100
            .Visible = False
        End With
        dgvDocumento.Columns.Add(col3)

        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .DisplayIndex = 7
            .DataPropertyName = "NETO"
            .HeaderText = "Subneto"
            .ReadOnly = True
            .DefaultCellStyle.ForeColor = Color.Black
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Mask = "99999999.999" 'Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
            .DefaultCellStyle.Format = "##,###,###0.00"
            .DefaultCellStyle.NullValue = "0.00"
            '.DefaultCellStyle.NullValue = Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
            .Width = 90
        End With
        dgvDocumento.Columns.Add(col4)

        Dim row0 As String() = {"", "PESO", "", "BULTOS", "", "0.00", "0.00", "0.00"}
        dgvDocumento.Rows().Add(row0)
        Dim row1 As String() = {"", "VOLUMEN", "", "BULTOS", "", "0.00", "0.00", "0.00"}
        dgvDocumento.Rows().Add(row1)
        Dim row2 As String() = {"", "SOBRE", "", "", "", "0.00", "0.00", "0.00"}
        dgvDocumento.Rows().Add(row2)
        Dim row3 As String() = {"", "BASE", "", "", "", "0.00", "0.00", "0.00"}
        dgvDocumento.Rows().Add(row3)
    End Sub
    Sub FormatearDGVArticulo()
        With dgvDocumento
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvLista)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_Nombre_Articulo As New DataGridViewTextBoxColumn
            With col_Nombre_Articulo
                .Name = "Nombre_Articulo" : .DataPropertyName = "Nombre_Articulo"
                .DisplayIndex = x : .HeaderText = "Artículo" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_Precio_x_Articulo As New DataGridViewTextBoxColumn
            With col_Precio_x_Articulo
                .Name = "Precio_x_Articulo" : .DataPropertyName = "Precio_x_Articulo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Precio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.Format = "####,###,###0.00"
            End With
            x += +1
            Dim col_Cantidad_Articulos As New DataGridViewTextBoxColumn
            With col_Cantidad_Articulos
                .Name = "Cantidad_Articulos" : .DataPropertyName = "Cantidad_Articulos"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_Total As New DataGridViewTextBoxColumn
            With col_Total
                .Name = "Total" : .DataPropertyName = "Total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.Format = "####,###,###0.00"
            End With
            .Columns.AddRange(col_Nombre_Articulo, col_Precio_x_Articulo, col_Cantidad_Articulos, col_Total)
        End With
    End Sub

#End Region

    Function ObtieneEstado(estado As Integer) As String
        Dim strEstado As String
        Select Case estado
            Case 20
                strEstado = "LLEGADA"
            Case 21
                strEstado = "EN ATENCION"
            Case 22
                strEstado = "DISPONIBLE"
            Case 23
                strEstado = "ENTREGADO"
        End Select
        Return strEstado
    End Function

    Private Sub frmConfirmacionEntrega_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmConfirmacionEntrega_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            Dim obj_EN As New Cls_EntregaCarga_EN
            Dim obj_LN As New Cls_EntregaCarga_LN

            obj_EN.TipoComprobante = TipoComprobante
            obj_EN.IdComprobante = Comprobante

            ListarConsignado(TipoComprobante, Comprobante)

            Dim ds As DataSet = obj_LN.ListarEntrega(obj_EN)
            Dim dt As DataTable = ds.Tables(0)
            Dim dtDocumento As DataTable = ds.Tables(1)
            Dim dtArticulo As DataTable = ds.Tables(2)

            With dt
                Me.txtNumeroComprobante.Text = dt.Rows(0).Item("NRODOC")
                Me.txtOrigen.Text = dt.Rows(0).Item("origen")
                Me.txtDestino.Text = dt.Rows(0).Item("destino")
                Me.txtFecha.Text = dt.Rows(0).Item("fecha")
                Me.txtAgenciaOrigen.Text = dt.Rows(0).Item("agencia_origen")
                Me.txtAgenciaDestino.Text = dt.Rows(0).Item("agencia_destino")
                Me.txtNumeroDocumento.Text = dt.Rows(0).Item("Nu_Docu_Suna")
                Me.txtCliente.Text = dt.Rows(0).Item("Razon_Social")
                Me.txtSubcuenta.Text = dt.Rows(0).Item("Centro_Costo")

                Me.txtCondicion.Text = dt.Rows(0).Item("Tipo_Pago")
                Me.txtDescuento.Text = IIf(dt.Rows(0).Item("Porcent_Descuento") = 0, "", dt.Rows(0).Item("Porcent_Descuento"))
                Me.txtAutorizado.Text = dt.Rows(0).Item("memo")
                Me.txtFormaPago.Text = dt.Rows(0).Item("forma_pago")
                Me.txtTarjeta.Text = dt.Rows(0).Item("Tarjeta")
                Me.txtNumeroTarjeta.Text = dt.Rows(0).Item("Nrotarjeta")

                Me.txtRemitente.Text = dt.Rows(0).Item("Remitente")
                Me.txtDireccionRemitente.Text = dt.Rows(0).Item("REM_Direccion")
                Me.txtDestinatario.Text = dt.Rows(0).Item("Destinatario")
                Me.txtDireccionDestinatario.Text = dt.Rows(0).Item("Des_Direccion")
                'Me.lblEstado.Text = ObtieneEstado(Estado)
                Me.txtObservaciones.Text = dt.Rows(0).Item("v_Obs")

                intCantidadTotal = dt.Rows(0).Item("cantidad_total")
                intEntregada = Val(dt.Rows(0).Item("tot_entregado"))

                If Estado = 23 Then
                    Me.cboConsignado.SelectedValue = dt.Rows(0).Item("consignado")
                    Me.dtpFechaEntrega.Value = IIf(IsDBNull(dt.Rows(0).Item("fecha_entrega")), FechaServidor, dt.Rows(0).Item("fecha_entrega"))
                    Me.dtpHoraEntrega.Text = IIf(IsDBNull(dt.Rows(0).Item("hora_entrega")), fnGetHora_(), dt.Rows(0).Item("hora_entrega"))
                    Me.txtCantidadEntregar.Text = intCantidadTotal - intEntregada
                    Me.txtCantidadEntregada.Text = IIf(IsDBNull(dt.Rows(0).Item("tot_entregado")), "", dt.Rows(0).Item("tot_entregado"))
                Else
                    Me.cboConsignado.SelectedValue = dt.Rows(0).Item("consignado")
                    Me.dtpFechaEntrega.Value = FechaServidor()
                    Me.dtpHoraEntrega.Value = fnGetHora_()
                    Me.txtCantidadEntregar.Text = intCantidadTotal - intEntregada
                    Me.txtCantidadEntregada.Text = dt.Rows(0).Item("tot_entregado")
                End If
            End With

            FormatearDGVDocumento()
            Me.dgvBulto.DataSource = dtDocumento

            If dt.Rows(0).Item("Cant_Art") > 0 Then
                FormatearDGVArticulo()
                dgvDocumento.DataSource = dtArticulo
            Else
                FormatearDGVBulto()
                dgvDocumento(2, 0).Value = IIf(dt.Rows(0).Item("Cantidad_x_Peso") > 0, dt.Rows(0).Item("Cantidad_x_Peso"), "")
                dgvDocumento(4, 0).Value = IIf(dt.Rows(0).Item("Total_Peso") > 0, dt.Rows(0).Item("Total_Peso"), "")
                dgvDocumento(5, 0).Value = dt.Rows(0).Item("Precio_x_Peso")
                dgvDocumento(6, 0).Value = "0.00"
                dgvDocumento(7, 0).Value = Format(dt.Rows(0).Item("Total_Peso") * dt.Rows(0).Item("Precio_x_Peso"), "###,###,###.00")
                '
                dgvDocumento(2, 1).Value = IIf(dt.Rows(0).Item("Cantidad_x_Volumen") > 0, dt.Rows(0).Item("Cantidad_x_Volumen"), "")
                dgvDocumento(4, 1).Value = IIf(dt.Rows(0).Item("Total_Volumen") > 0, dt.Rows(0).Item("Total_Volumen"), "")
                dgvDocumento(5, 1).Value = dt.Rows(0).Item("Precio_x_Volumen")
                dgvDocumento(6, 1).Value = "0.00"
                dgvDocumento(7, 1).Value = Format(dt.Rows(0).Item("Total_Volumen") * dt.Rows(0).Item("Precio_x_Volumen"), "###,###,###.00")
                '
                dgvDocumento(2, 2).Value = IIf(dt.Rows(0).Item("Cantidad_x_Sobre") > 0, dt.Rows(0).Item("Cantidad_x_Sobre"), "")
                dgvDocumento(4, 2).Value = " "
                dgvDocumento(5, 2).Value = dt.Rows(0).Item("Precio_x_Sobre")
                dgvDocumento(6, 2).Value = "0.00"
                dgvDocumento(7, 2).Value = Format(dt.Rows(0).Item("Cantidad_x_Sobre") * dt.Rows(0).Item("Precio_x_Sobre"), "###,###,###.00")
                '
                dgvDocumento(2, 3).Value = ""
                dgvDocumento(4, 3).Value = ""
                dgvDocumento(5, 3).Value = ""
                dgvDocumento(6, 3).Value = "0.00"
                dgvDocumento(7, 3).Value = IIf(dt.Rows(0).Item("Monto_Base") > 0, dt.Rows(0).Item("Monto_Base"), "")
            End If

            Me.lblTipoComprobante.Text = dt.Rows(0).Item("Tipo_Comprobante")
            Me.txtTotal.Text = Format(dt.Rows(0).Item("total_costo"), "###,###,###0.00")

            ActivarDesactivar()

            'huella
            If dtoUSUARIOS.huella = 1 Then
                Me.grbHuella.Visible = True
                Try
                    CargarHuella()
                Catch ex As Exception
                End Try
            Else
                Me.grbHuella.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Confirmación de Entrega", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtDNI_Enter(sender As Object, e As System.EventArgs) Handles txtDNI.Enter
        txtDNI.SelectAll()
    End Sub

    Private Sub txtNumeroDNI_GotFocus(sender As Object, e As System.EventArgs) Handles txtDNI.GotFocus
        txtDNI.SelectAll()
    End Sub

    Private Sub cboConsignado_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboConsignado.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboConsignado_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboConsignado.SelectedIndexChanged
        If Not IsReference(Me.cboConsignado.SelectedValue) Then
            If cboConsignado.SelectedValue = 0 Then
                Me.txtDNI.Text = ""
                Me.txtDNI.Enabled = False
                Me.btnAgregarHuella.Enabled = False
            Else
                Me.txtDNI.Text = dtConsignado.Rows(cboConsignado.SelectedIndex).Item(2).ToString.Trim
                Me.txtDNI.Enabled = True
            End If
        Else
            Me.txtDNI.Text = ""
        End If
    End Sub

    Sub ListarConsignado(tipo As Integer, comprobante As Integer)
        Dim objEN As New Cls_EntregaCarga_EN
        Dim objLN As New Cls_EntregaCarga_LN

        objEN.TipoComprobante = tipo
        objEN.IdComprobante = comprobante

        dtConsignado = objLN.ListarConsignado(objEN)
        With cboConsignado
            .ValueMember = "id"
            .DisplayMember = "nombres"
            .DataSource = dtConsignado
        End With
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs)
        Dim frm As New FrmConsignadoNuevo

        frm.IDPersona = Cliente
        frm.IDUnidadDestino = CiudadDestino

        frm.IDComprobante = Comprobante
        frm.IDTipoComprobante = TipoComprobante
        frm.ShowDialog()

        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            ListarConsignado(TipoComprobante, Comprobante)
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        'Valida si comprobante tiene alguna solicitud pendiente o aprobada
        Dim obj As New Cls_FacturaAdicional_LN
        Dim strTipoOperacion As String = obj.ComprobanteOperacion(Comprobante)
        If strTipoOperacion.Trim.Length > 0 Then
            If strTipoOperacion.Trim <> "x" Then
                MessageBox.Show("El Comprobante tiene una solicitud pendiente por " & Chr(13) & strTipoOperacion, "Confirmación Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information)
                blnSalir = False
                Return
            End If
        End If

        If Me.cboConsignado.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione el Consignado", "Confirmación Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboConsignado.Focus()
            blnSalir = False
            Return
        End If

        If Me.txtDNI.Text.Trim.Length < 8 Then
            MessageBox.Show("Ingrese Nº de Documento", "Confirmación Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtDNI.Text = ""
            Me.txtDNI.Focus()
            blnSalir = False
            Return
        End If

        'huella
        If dtoUSUARIOS.huella = 1 Then
            If Me.picHuella.Image Is Nothing Then
                MessageBox.Show("Ingrese Huella del Consignado", "Confirmación Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnAgregarHuella.Focus()
                blnSalir = False
                Return
            End If
        End If

        Dim intCantidadEntregar As Integer = Val(Me.txtCantidadEntregar.Text)
        If intCantidadEntregar <= 0 Then
            MessageBox.Show("Ingrese Cantidad a Entregar", "Confirmación Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtCantidadEntregar.Focus()
            blnSalir = False
            Return
        End If

        Dim intResultado As Integer = intEntregada + intCantidadEntregar
        If intResultado > intCantidadTotal Then
            MessageBox.Show("La Cantidad a Entregar no debe ser mayor a la Cantidad Total", "Confirmación Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtCantidadEntregar.Focus()
            blnSalir = False
            Return
        End If

        If intResultado < intCantidadTotal Then
            Dim strMensaje As String = "La Cantidad a Entregar es menor a la Cantidad Total" & Chr(13) & "El Comprobante tendrá el estado Entrega Parcial" & Chr(13) & Chr(13) & _
                "¿Está seguro de continuar?"
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show(strMensaje, "Confirmación Entrega", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.No Then
                blnSalir = False
                Return
            End If
        End If

        Dim lfrmusuario_entrega As New frmusuario_entrega
        lfrmusuario_entrega.Lab_tip_dcto.Text = Me.lblTipoComprobante.Text
        lfrmusuario_entrega.txt_dcto.Text = txtNumeroComprobante.Text
        lfrmusuario_entrega.txt_origen.Text = txtOrigen.Text
        lfrmusuario_entrega.txt_destino.Text = txtDestino.Text

        lfrmusuario_entrega.txtLogin.Text = dtoUSUARIOS.iLOGIN
        lfrmusuario_entrega.txtPasswor.Focus()

        lfrmusuario_entrega.ShowDialog()
        If lfrmusuario_entrega.pb_cancelar = True Then
            blnSalir = False
            Return
        End If
        dtoUSUARIOS.IdLogin = lfrmusuario_entrega.pl_idusuario_personal

        GrabarEntrega()
    End Sub

    Sub GrabarEntrega()
        Try
            Dim objLN As New Cls_EntregaCarga_LN
            Dim objEN As New Cls_EntregaCarga_EN

            objEN.TipoComprobante = TipoComprobante
            objEN.IdComprobante = Comprobante
            objEN.Consignado = Me.cboConsignado.SelectedValue
            objEN.Nombres = Me.cboConsignado.Text
            objEN.NumeroComprobante = Me.txtDNI.Text.Trim
            objEN.Observacion = Me.txtObservaciones.Text.Trim
            objEN.Agencia = dtoUSUARIOS.iIDAGENCIAS

            Dim intCantidadEntregar As Integer = Val(Me.txtCantidadEntregar.Text)
            Dim intResultado As Integer = intEntregada + intCantidadEntregar
            If intResultado < intCantidadTotal Then
                objEN.Cantidad = intResultado
                objEN.Estado = 68
            Else
                objEN.Cantidad = intCantidadTotal
                objEN.Estado = 21
            End If

            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP
            objLN.GrabarEntrega(objEN)
            MessageBox.Show("La Carga ha sido Entregada", "Confirmación Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'huella
            If dtoUSUARIOS.huella = 1 Then
                GrabarHuella()
            End If

            Try
                ObjWebService.fnWebService(TipoComprobante, Comprobante, Estado)
            Catch ex As Exception
            End Try
            Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Confirmación Entrega", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtDNI_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDNI.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtObservaciones_Enter(sender As Object, e As System.EventArgs) Handles txtObservaciones.Enter
        txtObservaciones.SelectAll()
    End Sub

    Sub ActivarDesactivar()
        If Modo = 1 Then
            Me.btnAgregarHuella.Visible = False
            Me.btnVerHuella.Left = 60
            Me.btnAceptar.Enabled = False
            'Me.lblCantidadEntregar.Visible = False
            'Me.txtCantidadEntregar.Visible = False
            'Me.grbEntrega.Enabled = False
        End If
    End Sub

    Private Sub frmConfirmacionEntrega_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        If Modo = 1 Then
            Me.btnCancelar.Focus()
        Else
            Me.txtDNI.Focus()
        End If
    End Sub

    Private Sub txtObservaciones_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservaciones.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtObservaciones_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtObservaciones.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCantidadEntregar_Enter(sender As Object, e As System.EventArgs) Handles txtCantidadEntregar.Enter
        Me.txtCantidadEntregar.SelectAll()
    End Sub

    Private Sub txtCantidadEntregar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidadEntregar.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCantidadEntregar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCantidadEntregar.TextChanged
        Dim intCantidadEntregar As Integer = Val(Me.txtCantidadEntregar.Text)

        Dim intResultado As Integer = intEntregada + intCantidadEntregar
        'Me.txtCantidadEntregada.Text = intResultado
    End Sub

    Private Sub btnHuella_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarHuella.Click
        Dim frm As New frmHuella
        frm.NumeroDocumento = Me.txtDNI.Text.Trim
        frm.Consignado = Me.cboConsignado.Text
        frm.Monto = Me.txtTotal.Text
        frm.Seguro = 0
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.picHuella.Image = frm.imagen2
            Me.picHuella.SizeMode = PictureBoxSizeMode.StretchImage
            Me.plantilla = frm.plantilla
            Me.parametro = frm.aParametro
            Me.intCalidad = frm.intCalidadHuella
            Me.intProblema = frm.intProblema
            Me.strMotivo = frm.strMotivo
            If Me.picHuella Is Nothing Then
                Me.btnVerHuella.Enabled = False
            Else
                Me.btnVerHuella.Enabled = True
            End If
        End If
    End Sub

    Public Shared Sub SaveJPGWithCompressionSetting(ByVal image As Image, ByVal szFileName As String, ByVal lCompression As Long)
        Dim eps As EncoderParameters = New EncoderParameters(1)

        eps.Param(0) = New EncoderParameter(Imaging.Encoder.Quality, lCompression)

        Dim ici As ImageCodecInfo = GetEncoderInfo("image/jpeg")
        Try
            image.Save(szFileName, ici, eps)
        Catch exc As Exception
            MessageBox.Show(exc, " Atención !", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Shared Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
        Dim j As Integer
        Dim encoders As ImageCodecInfo()

        encoders = ImageCodecInfo.GetImageEncoders()
        For j = 0 To encoders.Length
            If encoders(j).MimeType = mimeType Then
                Return encoders(j)
            End If
        Next j
        Return Nothing
    End Function

    Sub GrabarHuella()
        Dim huella As New Huella
        'Dim img As Image = Me.picHuella.Image
        'Dim ms As New MemoryStream
        'Dim img2 As Image = img.Clone
        'img2.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
        'img2.Dispose()
        'Dim m() As Byte
        'm = ms.ToArray
        'ms.Close()
        'ms.Dispose()

        'Dim strArchivo As String = parametro(10)
        'Dim intCompresion As Integer = parametro(11)
        'SaveJPGWithCompressionSetting(img, strArchivo, intCompresion)

        'Dim size As Long
        'size = New FileInfo(strArchivo).Length
        'Dim fs As FileStream
        'fs = New FileStream(strArchivo, FileMode.Open)
        'Dim imagen() As Byte
        'ReDim imagen(size)
        'fs.Read(imagen, 0, size)
        'fs.Close()
        'fs.Dispose()

        strMotivo = IIf(strMotivo Is Nothing, "", strMotivo)
        huella.GrabarHuella(TipoComprobante, Comprobante, Me.txtDNI.Text.Trim, plantilla, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, intCalidad, intProblema, strMotivo, 1)
    End Sub

    Sub CargarHuella()
        Dim imagen() As Byte
        Dim huella As New Huella

        huella.CargarHuella(TipoComprobante, Comprobante, imagen)
        If imagen Is Nothing Then
            Me.picHuella.Image = Nothing
            plantilla = Nothing
            Me.btnVerHuella.Enabled = False
        Else
            huella.MostrarHuella(imagen, Me.picHuella, 2, 120000)
        End If

        Me.picHuella.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub btnVerHuella_Click(sender As System.Object, e As System.EventArgs) Handles btnVerHuella.Click
        Try
            Dim frm As New frmVerHuella
            frm.imagen = picHuella.Image
            frm.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtDNI_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDNI.TextChanged
        'huella
        If dtoUSUARIOS.huella = 1 Then
            Dim intLongitud As Integer = Me.txtDNI.Text.Trim.Length
            If intLongitud = 8 Then
                Me.btnAgregarHuella.Enabled = True
            Else
                Me.btnAgregarHuella.Enabled = False
            End If
        End If
    End Sub
End Class