Imports INTEGRACION_LN
Imports INTEGRACION_EN

Public Class frmEntrega
    Enum Operacion
        ATENCION = 1
        DISPONIBLE = 2
        ENTREGADO = 3
    End Enum
#Region "Variables Publicas"
    Dim blnImplementa As Boolean
#End Region
#Region "Configurar Grid"
    Sub FormatearDGVLista()
        With dgvLista
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvLista)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Microsoft Sans Serif", 6.7!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
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
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .HeaderText = "Nº Doc." : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo_comprobante As New DataGridViewTextBoxColumn
            With col_tipo_comprobante
                .Name = "tipo_comprobante" : .DataPropertyName = "tipo_comprobante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Width = 35
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_comprobante As New DataGridViewTextBoxColumn
            With col_fecha_comprobante
                .Name = "fecha_comprobante" : .DataPropertyName = "fecha_comprobante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_numero_documento As New DataGridViewTextBoxColumn
            With col_numero_documento
                .Name = "numero_documento" : .DataPropertyName = "numero_documento"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Ruc/Dni"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_razon_social As New DataGridViewTextBoxColumn
            With col_razon_social
                .Name = "razon_social" : .DataPropertyName = "razon_social"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Razón Social"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Width = 235 '280 '325
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_consignado As New DataGridViewTextBoxColumn
            With col_consignado
                .Name = "consignado" : .DataPropertyName = "consignado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Consignado"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells : 
                .Width = 235 '280 '325
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_cantidad_total As New DataGridViewTextBoxColumn
            With col_cantidad_total
                .Name = "cantidad_total" : .DataPropertyName = "cantidad_total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_peso_total As New DataGridViewTextBoxColumn
            With col_peso_total
                .Name = "peso_total" : .DataPropertyName = "peso_total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_forma_pago As New DataGridViewTextBoxColumn
            With col_forma_pago
                .Name = "forma_pago" : .DataPropertyName = "forma_pago"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Forma Pago"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_agencia_origen As New DataGridViewTextBoxColumn
            With col_agencia_origen
                .Name = "agencia_origen" : .DataPropertyName = "agencia_origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Ag. Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_agencia_destino As New DataGridViewTextBoxColumn
            With col_agencia_destino
                .Name = "agencia_destino" : .DataPropertyName = "agencia_destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Ag. Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_cantidad_x_peso As New DataGridViewTextBoxColumn
            With col_cantidad_x_peso
                .Name = "cantidad_x_peso" : .DataPropertyName = "cantidad_x_peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cant. Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###"
            End With
            x += +1
            Dim col_cantidad_x_volumen As New DataGridViewTextBoxColumn
            With col_cantidad_x_volumen
                .Name = "cantidad_x_volumen" : .DataPropertyName = "cantidad_x_volumen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cant. Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###"
            End With
            x += +1
            Dim col_cantidad_x_sobre As New DataGridViewTextBoxColumn
            With col_cantidad_x_sobre
                .Name = "cantidad_x_sobre" : .DataPropertyName = "cantidad_x_sobre"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cant. Sobre"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###"
            End With
            x += +1
            Dim col_cantidad_articulo As New DataGridViewTextBoxColumn
            With col_cantidad_articulo
                .Name = "cantidad_articulo" : .DataPropertyName = "cantidad_articulo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cant. Articulo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###"
            End With
            x += +1
            Dim col_total_peso As New DataGridViewTextBoxColumn
            With col_total_peso
                .Name = "total_peso" : .DataPropertyName = "total_peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total_volumen As New DataGridViewTextBoxColumn
            With col_total_volumen
                .Name = "total_volumen" : .DataPropertyName = "total_volumen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_subtotal As New DataGridViewTextBoxColumn
            With col_subtotal
                .Name = "subtotal" : .DataPropertyName = "subtotal"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subtotal"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total_impuesto As New DataGridViewTextBoxColumn
            With col_total_impuesto
                .Name = "total_impuesto" : .DataPropertyName = "total_impuesto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total Impuesto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total_costo As New DataGridViewTextBoxColumn
            With col_total_costo
                .Name = "total_costo" : .DataPropertyName = "total_costo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_factura As New DataGridViewTextBoxColumn
            With col_factura
                .Name = "factura" : .DataPropertyName = "factura"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fac/Bol"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_idtipo_comprobante As New DataGridViewTextBoxColumn
            With col_idtipo_comprobante
                .Name = "idtipo_comprobante" : .DataPropertyName = "idtipo_comprobante"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo_comprobante"
            End With
            x += +1
            Dim col_id_comprobante As New DataGridViewTextBoxColumn
            With col_id_comprobante
                .Name = "id_comprobante" : .DataPropertyName = "id_comprobante"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id_comprobante"
            End With
            x += +1
            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .Name = "id_estado" : .DataPropertyName = "id_estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado"
            End With
            x += +1
            Dim col_id_cliente As New DataGridViewTextBoxColumn
            With col_id_cliente
                .Name = "id_cliente" : .DataPropertyName = "id_cliente"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id_cliente"
            End With
            x += +1
            Dim col_id_destino As New DataGridViewTextBoxColumn
            With col_id_destino
                .Name = "id_destino" : .DataPropertyName = "id_destino"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id_destino"
            End With

            .Columns.AddRange(col_comprobante, col_tipo_comprobante, col_fecha_comprobante, col_numero_documento, col_razon_social, col_consignado, _
                              col_estado, col_cantidad_total, col_peso_total, _
                              col_origen, col_destino, col_agencia_origen, col_agencia_destino, col_factura, _
                              col_idtipo_comprobante, col_id_comprobante, col_id_estado, col_total_costo, col_id_cliente, col_id_destino)
        End With
    End Sub
    Sub FormatearDGVAlmacen()
        With dgvAlmacen
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvLista)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
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
            Dim col_ubicacion As New DataGridViewTextBoxColumn
            With col_ubicacion
                .Name = "ubicacion" : .DataPropertyName = "ubicacion"
                .DisplayIndex = x : .HeaderText = "Ubicación" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_codigo_barra As New DataGridViewTextBoxColumn
            With col_codigo_barra
                .Name = "codigo_barra" : .DataPropertyName = "codigo_barra"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código Barra"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_almacen As New DataGridViewTextBoxColumn
            With col_almacen
                .Name = "almacen" : .DataPropertyName = "almacen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Almacén"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_area As New DataGridViewTextBoxColumn
            With col_area
                .Name = "area" : .DataPropertyName = "area"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Area"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_anaquel As New DataGridViewTextBoxColumn
            With col_anaquel
                .Name = "anaquel" : .DataPropertyName = "anaquel"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Anaquel"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_columna As New DataGridViewTextBoxColumn
            With col_columna
                .Name = "columna" : .DataPropertyName = "columna"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Columna"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fila As New DataGridViewTextBoxColumn
            With col_fila
                .Name = "fila" : .DataPropertyName = "fila"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fila"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_ubicacion, col_codigo_barra, col_almacen, col_area, col_anaquel, col_columna, col_fila)
        End With
    End Sub
#End Region

    Sub Inicio()
        Dim obj As New Cls_EntregaCarga_LN
        Dim obj_EN As New Cls_EntregaCarga_EN

        Me.cboTipoComprobante.SelectedIndex = 0
        Dim ds As DataSet = obj.Inicio(dtoUSUARIOS.m_idciudad, dtoUSUARIOS.iIDAGENCIAS)

        With Me.cboOrigen
            .DisplayMember = "ciudad"
            .ValueMember = "id"
            .DataSource = ds.Tables(0)
            .SelectedIndex = 0
        End With

        Me.dtpInicio.Value = DateAdd(DateInterval.Day, -3, Me.dtpFin.Value)
        Me.cboEstado.SelectedIndex = 0

        blnImplementa = ds.Tables(1).Rows(0).Item(0) = 1
        If Not blnImplementa Then
            Me.lblEstado.Enabled = False
            Me.cboEstado.Enabled = False
            Me.btnAtender.Visible = False
            Me.btnAnular.Visible = False
            'Me.btnEntregar.Location = New Point(4, 14)
        End If
        Me.btnAtender.Enabled = False
        Me.btnEntregar.Enabled = False
        Me.btnMostrar.Enabled = False
        Me.btnAnular.Enabled = False
        Me.btnIncidencia.Enabled = False
    End Sub

    Sub ListarCarga()
        Dim obj_AD As New Cls_EntregaCarga_LN
        Dim obj_EN As New Cls_EntregaCarga_EN

        If Me.txtNumeroComprobante.Text.Trim.Length > 0 Then 'usuario escribio comprobante
            Dim strNumeroComprobante As String() = Split(txtNumeroComprobante.Text, "-")
            If strNumeroComprobante.Length > 1 Then
                If strNumeroComprobante(0).ToString.Length > 1 And strNumeroComprobante(1).ToString.Length > 1 Then
                    obj_EN.SerieComprobante = strNumeroComprobante(0)
                    obj_EN.NumeroComprobante = strNumeroComprobante(1)
                Else
                    obj_EN.SerieComprobante = "0"
                    obj_EN.NumeroComprobante = "0"
                End If
            Else
                If strNumeroComprobante.Length = 1 Then
                    obj_EN.SerieComprobante = "0"
                    obj_EN.NumeroComprobante = strNumeroComprobante(0)
                Else
                    obj_EN.SerieComprobante = "0"
                    obj_EN.NumeroComprobante = "0"
                End If
            End If
        Else
            obj_EN.SerieComprobante = "0"
            obj_EN.NumeroComprobante = "0"
        End If

        'opcion de busqueda
        Dim intOpcion As Integer = 1
        If Me.txtNumeroComprobante.Text.Trim.Length > 0 Then
            intOpcion = 2
        Else
            If Me.txtBuscar.Text.Trim.Length > 0 Then
                If Me.rbtCliente.Checked Then
                    intOpcion = 3
                Else
                    intOpcion = 4
                End If
                obj_EN.Nombres = Me.txtBuscar.Text.Trim
            End If
        End If
        obj_EN.Opcion = intOpcion

        obj_EN.FechaInicio = Me.dtpInicio.Value.ToShortDateString
        obj_EN.FechaFin = Me.dtpFin.Value.ToShortDateString

        obj_EN.Origen = Me.cboOrigen.SelectedValue
        obj_EN.Destino = dtoUSUARIOS.m_iIdUnidadAgenciaReal
        obj_EN.Agencia = dtoUSUARIOS.iIDAGENCIAS

        If Me.txtNumeroDocumento.Text.Length >= 0 Then
            obj_EN.NumeroDocumento = Me.txtNumeroDocumento.Text
        Else
            obj_EN.NumeroDocumento = ""
        End If

        If Me.cboEstado.SelectedIndex > 0 Then
            obj_EN.Estado = Me.cboEstado.SelectedIndex + 19
        Else
            obj_EN.Estado = 0
        End If

        obj_EN.Usuario = dtoUSUARIOS.IdLogin
        obj_EN.IP = dtoUSUARIOS.IP
        obj_EN.Tipo = Me.cboTipoComprobante.SelectedIndex

        Me.dgvLista.DataSource = obj_AD.ListarCarga(obj_EN)
        Me.lblRegistros.Text = Me.dgvLista.Rows.Count

        If dgvLista.Rows.Count = 0 Then
            Me.dgvAlmacen.DataSource = Nothing
            Me.btnEntregar.Enabled = False
            Me.btnAtender.Enabled = False
            Me.btnMostrar.Enabled = False
            Me.btnAnular.Enabled = False
            Me.btnIncidencia.Enabled = False
            Me.btnConsultaDocumento.Enabled = False
            If Not blnImplementa Then
                Me.btnEntregar.Enabled = Me.dgvLista.Rows.Count > 0
            End If
        Else
            Me.btnMostrar.Enabled = True
            Me.btnConsultaDocumento.Enabled = True
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Try
            Cursor = Cursors.WaitCursor
            ListarCarga()
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Entrega de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmEntrega_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    End Sub

    Private Sub frmEntrega_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Inicio()
        FormatearDGVLista()
        FormatearDGVAlmacen()
    End Sub

    Private Sub dgvLista_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.RowEnter
        Try
            Dim obj_EN As New Cls_EntregaCarga_EN
            Dim obj_LN As New Cls_EntregaCarga_LN

            Dim intTipoComprobante As Integer = Me.dgvLista.Rows(e.RowIndex).Cells("idtipo_comprobante").Value
            Dim intComprobante As Integer = Me.dgvLista.Rows(e.RowIndex).Cells("id_comprobante").Value

            obj_EN.TipoComprobante = intTipoComprobante
            obj_EN.IdComprobante = intComprobante
            Me.dgvAlmacen.DataSource = obj_LN.ListarBultoAnaquel(obj_EN)

            If blnImplementa Then
                Me.btnAtender.Enabled = Me.dgvLista.Rows(e.RowIndex).Cells("id_estado").Value = 20 And Me.dgvAlmacen.Rows.Count > 0
                'hlamas temporal 0-01-2015
                Me.btnEntregar.Enabled = Me.dgvLista.Rows(e.RowIndex).Cells("id_estado").Value = 22
                If Me.btnEntregar.Enabled Then
                    If Me.dgvLista.Rows(e.RowIndex).Cells("idtipo_comprobante").Value = 85 Then
                        If Me.dgvLista.Rows(e.RowIndex).Cells("factura").Value.ToString.Trim.Length = 0 Then
                            Me.btnEntregar.Enabled = False
                        End If
                    End If
                End If
                Me.btnIncidencia.Enabled = Me.dgvLista.Rows(e.RowIndex).Cells("id_estado").Value <> 23
                If Acceso.SiRol(G_Rol, Me, 1, 1) Then
                    Me.btnAnular.Enabled = Me.dgvLista.Rows(e.RowIndex).Cells("id_estado").Value = 21 Or Me.dgvLista.Rows(e.RowIndex).Cells("id_estado").Value = 22
                Else
                    Me.btnAnular.Enabled = False
                End If
            Else
                Me.btnEntregar.Enabled = Me.dgvLista.Rows(e.RowIndex).Cells("id_estado").Value = 20
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtNumeroComprobante_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroComprobante.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If Me.txtNumeroComprobante.Text.Trim.Length > 0 Then
                Me.btnBuscar_Click(Nothing, Nothing)
            End If
        Else
            If ValidarNumero(e.KeyChar) Or e.KeyChar = "-" Then
                e.Handled = False
            ElseIf e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtNumeroDocumento_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroDocumento.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If Me.txtNumeroDocumento.Text.Trim.Length >= 0 Then
                Me.btnBuscar_Click(Nothing, Nothing)
            End If
        Else
            If (Not ValidarNumero(e.KeyChar)) Or Not (Me.rbtCliente.Checked) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnEntregar_Click(sender As System.Object, e As System.EventArgs) Handles btnEntregar.Click
        Cursor = Cursors.WaitCursor
        Dim frm As New frmConfirmacionEntrega
        frm.Cliente = Me.dgvLista.CurrentRow.Cells("id_cliente").Value
        frm.CiudadDestino = Me.dgvLista.CurrentRow.Cells("id_destino").Value

        frm.TipoComprobante = Me.dgvLista.CurrentRow.Cells("idtipo_comprobante").Value
        frm.Comprobante = Me.dgvLista.CurrentRow.Cells("id_comprobante").Value
        frm.Estado = Me.dgvLista.CurrentRow.Cells("id_estado").Value
        frm.Modo = 2
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.ListarCarga()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnAtender_Click(sender As System.Object, e As System.EventArgs) Handles btnAtender.Click
        With dgvLista
            Dim intAdicional As Integer = 0
            Dim intTipoComprobante As Integer = .CurrentRow.Cells("idtipo_comprobante").Value
            If intTipoComprobante = 85 Then
                Dim strFactura As String = IIf(IsDBNull(.CurrentRow.Cells("factura").Value), "", .CurrentRow.Cells("factura").Value)
                If strFactura.Trim.Length = 0 Then 'pce no esta cancelado
                    Dim dlgRespuesta As DialogResult
                    dlgRespuesta = MessageBox.Show("El PCE " & .CurrentRow.Cells("comprobante").Value & " no está CANCELADO" & Chr(13) & _
                    "El Monto a Cancelar es S/." & .CurrentRow.Cells("total_costo").Value & Chr(13) & Chr(13) & _
                    "¿Está seguro de continuar?", "Atender", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If dlgRespuesta = Windows.Forms.DialogResult.No Then
                        Return
                    End If
                    intAdicional = 1
                End If
            End If

            Atender(intAdicional)
        End With
    End Sub

    Sub Atender(adicional)
        Try
            Dim frm As New frmAtenderEntrega
            frm.Documento = Me.dgvLista.CurrentRow.Cells("tipo_comprobante").Value & " " & Me.dgvLista.CurrentRow.Cells("comprobante").Value
            frm.Consignado = Me.dgvLista.CurrentRow.Cells("consignado").Value
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.Yes Then
                Dim objEN As New Cls_EntregaCarga_EN
                Dim objLN As New Cls_EntregaCarga_LN

                objEN.TipoComprobante = Me.dgvLista.CurrentRow.Cells("idtipo_comprobante").Value
                objEN.IdComprobante = Me.dgvLista.CurrentRow.Cells("id_comprobante").Value
                objEN.Usuario = dtoUSUARIOS.IdLogin
                objEN.Agencia = dtoUSUARIOS.m_iIdAgencia
                objEN.Operacion = Operacion.ATENCION
                objEN.Nombres = Me.dgvLista.CurrentRow.Cells("consignado").Value
                objEN.Adicional = adicional
                objEN.IP = dtoUSUARIOS.IP

                objLN.Atender(objEN)
                ListarCarga()

                'Dim form As New frmEntregaAtencionCliente
                'form.Actualizar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atender", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnMostrar_Click(sender As System.Object, e As System.EventArgs) Handles btnMostrar.Click
        Cursor = Cursors.WaitCursor
        Dim frm As New frmConfirmacionEntrega

        frm.TipoComprobante = Me.dgvLista.CurrentRow.Cells("idtipo_comprobante").Value
        frm.Comprobante = Me.dgvLista.CurrentRow.Cells("id_comprobante").Value
        frm.Modo = 1
        frm.Estado = Me.dgvLista.CurrentRow.Cells("id_estado").Value
        frm.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnAnular_Click(sender As System.Object, e As System.EventArgs) Handles btnAnular.Click
        Dim frm As New frmEntregaAnulacion
        frm.Documento = Me.dgvLista.CurrentRow.Cells("tipo_comprobante").Value & " " & Me.dgvLista.CurrentRow.Cells("comprobante").Value
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Anular(frm)
            ListarCarga()
        End If
    End Sub

    Sub Anular(frm As frmEntregaAnulacion)
        Try
            Dim objEN As New Cls_EntregaCarga_EN
            Dim objLN As New Cls_EntregaCarga_LN

            objEN.TipoComprobante = Me.dgvLista.CurrentRow.Cells("idtipo_comprobante").Value
            objEN.IdComprobante = Me.dgvLista.CurrentRow.Cells("id_comprobante").Value
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP
            objEN.Observacion = frm.txtMotivo.Text.Trim

            objLN.Anular(objEN)
            Me.btnBuscar_Click(Nothing, Nothing)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Anular", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If Me.txtBuscar.Text.Trim.Length > 0 Then
                Me.btnBuscar_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub btnConsultaDocumento_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultaDocumento.Click
        Try
            Dim frm As New frmConsultaDocumento
            frm.StartPosition = FormStartPosition.Manual
            frm.Width = 1043 '990 '1330
            frm.Height = 641 '620 '685
            frm.ControlBox = True
            frm.Text = "Consulta de Documento"
            Acceso.Asignar(frm)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.MdiParent = Principal
                'frm.hnd = Hnd
                frm.Show()
            Else
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Titan")
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub dgvLista_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.CellContentClick

    End Sub

    Private Sub rbtCliente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtCliente.CheckedChanged
        If Me.rbtCliente.Checked Then
            Me.txtNumeroDocumento.Focus()
        End If
    End Sub

    Private Sub btnIncidencia_Click(sender As System.Object, e As System.EventArgs) Handles btnIncidencia.Click
        Dim frm As New frmEntregaIncidencia
        frm.Tipo = Me.dgvLista.CurrentRow.Cells("idtipo_comprobante").Value
        frm.Comprobante = Me.dgvLista.CurrentRow.Cells("id_comprobante").Value
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            btnBuscar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtNumeroComprobante_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumeroComprobante.TextChanged

    End Sub

    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscar.TextChanged

    End Sub

    Private Sub txtNumeroDocumento_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumeroDocumento.TextChanged

    End Sub
End Class