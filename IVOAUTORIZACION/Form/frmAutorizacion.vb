Imports INTEGRACION_LN
Imports INTEGRACION_EN
Public Class frmAutorizacion
    Structure Datos
        Public operacion As Integer
        Public texto As String
        Public id As Integer
    End Structure
    Dim elista As Datos
    Dim alista As New ArrayList

    Dim intModo As Operacion
    Dim blnBloquea As Boolean = False

    Dim dtComprobante As DataTable 'cursor con datos del comprobante original

    Dim intOpcion As Integer

#Region "Grid"
    Sub FormatearDGVLista()
        With dgvLista
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvLista)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.7!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = False
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
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .HeaderText = "Fecha" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero"
                .DisplayIndex = x : .HeaderText = "Número" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "tipo"
            End With
            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante" : .DisplayIndex = x : .Visible = False : .HeaderText = "comprobante"
            End With
            x += +1
            Dim col_tipo_comprobante As New DataGridViewTextBoxColumn
            With col_tipo_comprobante
                .Name = "tipo_comprobante" : .DataPropertyName = "tipo_comprobante"
                .DisplayIndex = x : .HeaderText = "Tipo Comprobante" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_numero_comprobante As New DataGridViewTextBoxColumn
            With col_numero_comprobante
                .Name = "numero_comprobante" : .DataPropertyName = "numero_comprobante"
                .DisplayIndex = x : .HeaderText = "Nº Comprobante" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .HeaderText = "Total" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .HeaderText = "Estado" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_idestado As New DataGridViewTextBoxColumn
            With col_idestado
                .Name = "idestado" : .DataPropertyName = "idestado" : .DisplayIndex = x : .Visible = False : .HeaderText = "idestado"
            End With
            x += +1
            Dim col_solicitante As New DataGridViewTextBoxColumn
            With col_solicitante
                .Name = "solicitante" : .DataPropertyName = "solicitante" : .DisplayIndex = x : .Visible = False : .HeaderText = "solicitante"
            End With
            x += +1
            Dim col_agencia As New DataGridViewTextBoxColumn
            With col_agencia
                .Name = "agencia" : .DataPropertyName = "agencia" : .DisplayIndex = x : .Visible = False : .HeaderText = "agencia"
            End With
            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion" : .DisplayIndex = x : .HeaderText = "observacion" : .Visible = False
            End With
            x += +1
            Dim col_facturado As New DataGridViewTextBoxColumn
            With col_facturado
                .Name = "facturado" : .DataPropertyName = "facturado"
                .DisplayIndex = x : .HeaderText = "Facturado" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_nombre_tipo_operacion As New DataGridViewTextBoxColumn
            With col_nombre_tipo_operacion
                .Name = "nombre_tipo_operacion" : .DataPropertyName = "nombre_tipo_operacion" : .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Operación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_aprobacion As New DataGridViewTextBoxColumn
            With col_fecha_aprobacion
                .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion"
                .DisplayIndex = x : .HeaderText = "Fecha Aprobación" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_desaprobacion As New DataGridViewTextBoxColumn
            With col_fecha_desaprobacion
                .Name = "fecha_desaprobacion" : .DataPropertyName = "fecha_desaprobacion"
                .DisplayIndex = x : .HeaderText = "Fecha Desaprobación" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_anulacion As New DataGridViewTextBoxColumn
            With col_fecha_anulacion
                .Name = "fecha_anulacion" : .DataPropertyName = "fecha_anulacion"
                .DisplayIndex = x : .HeaderText = "Fecha Anulación" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo_operacion As New DataGridViewTextBoxColumn
            With col_tipo_operacion
                .Name = "tipo_operacion" : .DataPropertyName = "tipo_operacion" : .DisplayIndex = x : .Visible = False : .HeaderText = "tipo_operacion"
            End With
            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario" : .DisplayIndex = x : .Visible = False : .HeaderText = "usuario"
            End With
            x += +1
            Dim col_idagencia As New DataGridViewTextBoxColumn
            With col_idagencia
                .Name = "idagencia" : .DataPropertyName = "idagencia" : .DisplayIndex = x : .Visible = False : .HeaderText = "idagencia"
            End With
            x += +1
            Dim col_ip As New DataGridViewTextBoxColumn
            With col_ip
                .Name = "ip" : .DataPropertyName = "ip" : .DisplayIndex = x : .Visible = False : .HeaderText = "ip"
            End With
            x += +1
            Dim col_usuario_liquidacion As New DataGridViewTextBoxColumn
            With col_usuario_liquidacion
                .Name = "usuario_liquidacion" : .DataPropertyName = "usuario_liquidacion" : .DisplayIndex = x : .Visible = False : .HeaderText = "usuario_liquidacion"
            End With

            .Columns.AddRange(col_id, col_fecha, col_numero, col_tipo, col_comprobante, col_tipo_comprobante, col_numero_comprobante, col_total, col_estado, col_idestado, _
                              col_solicitante, col_agencia, col_observacion, col_facturado, col_nombre_tipo_operacion, col_fecha_aprobacion, _
                              col_fecha_desaprobacion, col_fecha_anulacion, col_tipo_operacion, col_usuario, col_idagencia, col_ip, col_usuario_liquidacion)
        End With
    End Sub
    Sub FormatearDGVOperacion(dgv As DataGridView)
        With dgv
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvLista)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.7!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = False
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
            Dim col_operacion As New DataGridViewTextBoxColumn
            With col_operacion
                .Name = "operacion" : .DataPropertyName = "operacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Operación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .HeaderText = "Monto" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_idoperacion As New DataGridViewTextBoxColumn
            With col_idoperacion
                .Name = "idoperacion" : .DataPropertyName = "idoperacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idoperacion"
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Estado"
            End With
            x += +1
            Dim col_tipo_operacion As New DataGridViewTextBoxColumn
            With col_tipo_operacion
                .Name = "tipo_operacion" : .DataPropertyName = "tipo_operacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "tipo_operacion"
            End With
            x += +1
            Dim col_tipo_comprobante_final As New DataGridViewTextBoxColumn
            With col_tipo_comprobante_final
                .Name = "tipo_comprobante_final" : .DataPropertyName = "tipo_comprobante_final"
                .DisplayIndex = x : .Visible = False : .HeaderText = "tipo_comprobante_final"
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "tipo"
            End With
            x += +1
            Dim col_cuenta_corriente As New DataGridViewTextBoxColumn
            With col_cuenta_corriente
                .Name = "cuenta_corriente" : .DataPropertyName = "cuenta_corriente"
                .DisplayIndex = x : .Visible = False : .HeaderText = "cuenta_corriente"
            End With
            'hlamas 16-05-2017 visible mientras esté en desarrollo y prueba
            x += +1
            Dim col_monto_devolucion As New DataGridViewTextBoxColumn
            With col_monto_devolucion
                .Name = "monto_devolucion" : .DataPropertyName = "monto_devolucion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "monto_devolucion"
            End With

            .Columns.AddRange(col_operacion, col_monto, col_idoperacion, col_id, col_estado, col_tipo_operacion, col_tipo_comprobante_final, col_tipo, col_cuenta_corriente, col_monto_devolucion)
        End With
    End Sub
#End Region

    Private Sub frmAutorizacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Inicio()
    End Sub

    Sub Inicio()
        Dim blnSolicitud As Boolean = Acceso.SiRol(G_Rol, Me, 1, 1)
        Dim blnSolicitud2 As Boolean = Acceso.SiRol(G_Rol, Me, 1, 2)

        Dim blnAprobacion As Boolean = Acceso.SiRol(G_Rol, Me, 2, 1)
        Dim intOpcion2 As Integer

        If (blnSolicitud Or blnSolicitud2) And Not blnAprobacion Then
            intOpcion = 1
        ElseIf blnSolicitud = False And blnSolicitud2 = False And blnAprobacion Then
            intOpcion = 2
        ElseIf (blnSolicitud Or blnSolicitud2) And blnAprobacion Then
            intOpcion = 3
        Else
            intOpcion = 4
        End If

        If Not blnSolicitud Then
            blnSolicitud = Acceso.SiRol(G_Rol, Me, 1, 2)
            If blnSolicitud Then
                intOpcion2 = 1
            End If
        End If

        Dim obj As New Cls_Autorizacion_LN
        With Me.cboCiudad
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = obj.ListarCiudad()
            .SelectedValue = 0
        End With

        If intOpcion = 1 Then
            Me.cboEstado.SelectedIndex = 1
            Me.tabAutorizacion.TabPages.Remove(Me.tabAutorizacion.TabPages("tabAprobacion"))
        ElseIf intOpcion = 2 Then
            Me.cboEstado.SelectedIndex = 1
            Me.cboEstado.Enabled = False
            Me.tabAutorizacion.TabPages.Remove(Me.tabAutorizacion.TabPages("tabSolicitud"))
        ElseIf intOpcion = 3 Then
            Me.cboEstado.SelectedIndex = 1
        Else
            Me.tabAutorizacion.TabPages.Remove(Me.tabAutorizacion.TabPages("tabSolicitud"))
            Me.tabAutorizacion.TabPages.Remove(Me.tabAutorizacion.TabPages("tabAprobacion"))
            Me.tabAutorizacion.TabPages.Remove(Me.tabAutorizacion.TabPages("tabLista"))
            Me.tsbNuevo.Enabled = False
            Return
        End If

        If intOpcion2 = 1 Then
            Me.cboCiudad.SelectedValue = dtoUSUARIOS.m_idciudad
            Me.cboCiudad.Enabled = False
        End If

        FormatearDGVOperacion(Me.dgvOperacion)
        Limpiar()
        tabAutorizacion_SelectedIndexChanged(Nothing, Nothing)


        'If intOpcion = 1 Then
        '    Me.tabAutorizacion.TabPages.Remove(Me.tabAutorizacion.TabPages("tabAprobacion"))
        'ElseIf intOpcion = 2 Then
        '    Me.tabAutorizacion.TabPages.Remove(Me.tabAutorizacion.TabPages("tabSolicitud"))
        'ElseIf intOpcion = 3 Then

        'End If

        Me.dtpFin.Value = Format(FechaServidor, "Short Date")
        Dim fecha As Date = DateAdd(DateInterval.Day, -7, Me.dtpFin.Value)
        Me.dtpInicio.Value = fecha
    End Sub

    Function ExisteOperacion(id As Integer) As Boolean
        For Each row As DataGridViewRow In Me.dgvOperacion.Rows
            If Convert.ToInt32(row.Cells("estado").Value) >= 0 Then
                If id = Convert.ToInt32(row.Cells("idoperacion").Value) Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Function ObtieneCargos(dgv As DataGridView) As String
        Dim s As String = ""
        Dim strSerie As String, strNumero As String, strCargo As String
        For Each row As DataGridViewRow In dgv.Rows
            strSerie = row.Cells("serie").Value
            strNumero = row.Cells("numero").Value
            strCargo = strSerie & "-" & strNumero & ","
            s = s & strCargo
        Next
        'If s.Trim.Length > 0 Then
        's = s.Remove(s.Trim.Length - 1, 1)
        'End If
        Return s
    End Function

    Sub Limpiar()
        Me.lblNumero.Text = ""
        Me.lblAgencia.Text = dtoUSUARIOS.m_iNombreUnidadAgencia
        Me.lblFecha.Text = Format(FechaServidor, "Short Date")
        Me.lblSolicitante.Text = dtoUSUARIOS.NameLogin

        Me.lblTipoComprobante.Text = ""
        Me.lblNumeroComprobante.Text = ""
        Me.lblOrigen.Text = ""
        Me.lblOrigen.Tag = Nothing
        Me.lblDestino.Text = ""
        Me.lblNumeroDocumento.Text = ""
        Me.lblCliente.Text = ""
        Me.lblCliente.Tag = Nothing
        Me.lblTotal.Text = ""
        Me.lblPeso.Text = ""
        Me.lblCantidad.Text = ""
        Me.lblfechaComprobante.Text = ""
        'Me.lblUsuarioLiquidacion.Text = ""
        Me.cboTipoOperacion.SelectedIndex = 0
        Me.cboTipoOperacion.Enabled = False
        Me.btnAgregar.Enabled = False
        Me.btnEliminar.Enabled = False

        Me.grbBuscarComprobante.Enabled = True
        'Me.txtComprobante.Enabled = True
        'Me.cboTipoOperacion.Enabled = True
        Me.txtMotivo.Text = ""
        Me.txtMotivo.Enabled = True
        alista = New ArrayList
        'dtComprobante = Nothing

        Me.dgvOperacion.Rows.Clear()
        FormatearDGVOperacion(Me.dgvOperacion)
    End Sub

    Sub LimpiarAprobacion()
        Me.lblNumeroAprobacion.Text = ""
        Me.lblAgenciaAprobacion.Text = dtoUSUARIOS.m_iNombreUnidadAgencia
        Me.lblFechaAprobacion.Text = Format(FechaServidor, "Short Date")
        Me.lblSolicitanteAprobacion.Text = dtoUSUARIOS.NameLogin

        Me.lblTipoComprobanteAprobacion.Text = ""
        Me.lblNumeroComprobanteAprobacion.Text = ""
        Me.lblOrigenAprobacion.Text = ""
        Me.lblDestinoAprobacion.Text = ""
        Me.lblNumeroDocumentoAprobacion.Text = ""
        Me.lblClienteAprobacion.Text = ""
        Me.lblTotalSolicitudAprobacion.Text = ""
        Me.lblObservacionAprobacion.Text = ""
        Me.rbtSi.Checked = True
        Me.lblEstado.Text = ""

        Me.dgvOperacionAprobacion.Rows.Clear()
        FormatearDGVOperacion(Me.dgvOperacionAprobacion)
    End Sub

    Sub Mostrar(dt As DataTable, opcion As Integer)
        Try
            With dt.Rows(0)
                If opcion = 1 Then
                    Me.txtComprobante.Text = .Item("numero").ToString
                    Me.lblTipoComprobante.Text = .Item("tipo").ToString
                    Me.lblNumeroComprobante.Text = .Item("numero").ToString
                    Me.lblOrigen.Text = .Item("origen").ToString
                    Me.lblDestino.Text = .Item("destino").ToString
                    Me.lblNumeroDocumento.Text = .Item("documento").ToString
                    Me.lblCliente.Text = .Item("cliente").ToString
                    Me.lblCliente.Tag = .Item("idcliente").ToString
                    Me.lblTotal.Text = Format(CType(.Item("total").ToString, Double), "###,####,###0.00")
                    Me.lblPeso.Text = Format(CType(.Item("peso").ToString, Double), "###,####,###0.00")
                    Me.lblCantidad.Text = CType(.Item("cantidad").ToString, Double)
                    Me.lblfechaComprobante.Text = .Item("fecha").ToString

                    Me.lblNumeroComprobante.Tag = .Item("id").ToString
                    Me.lblTipoComprobante.Tag = .Item("idtipo_comprobante").ToString

                    'Me.lblUsuarioLiquidacion.Text = .Item("usuario_liquidacion").ToString
                    Me.lblOrigen.Tag = .Item("n_emife").ToString
                Else
                    Me.lblTipoComprobanteAprobacion.Text = .Item("tipo").ToString
                    Me.lblNumeroComprobanteAprobacion.Text = .Item("numero").ToString
                    Me.lblOrigenAprobacion.Text = .Item("origen").ToString
                    Me.lblDestinoAprobacion.Text = .Item("destino").ToString
                    Me.lblNumeroDocumentoAprobacion.Text = .Item("documento").ToString
                    Me.lblClienteAprobacion.Text = .Item("cliente").ToString
                    Me.lblTotalAprobacion.Text = Format(CType(.Item("total").ToString, Double), "###,####,###0.00")
                    Me.lblPesoAprobacion.Text = Format(CType(.Item("peso").ToString, Double), "###,####,###0.00")
                    Me.lblCantidadAprobacion.Text = CType(.Item("cantidad").ToString, Double)
                    Me.lblFechaComprobanteAprobacion.Text = Format(.Item("fecha"), "dd/MM/yyyy")

                    Me.lblNumeroComprobanteAprobacion.Tag = .Item("id").ToString
                    Me.lblTipoComprobanteAprobacion.Tag = .Item("idtipo_comprobante").ToString
                    Me.lblClienteAprobacion.Tag = .Item("idcliente").ToString

                    'Me.lblUsuarioLiquidacion.Text = .Item("usuario_liquidacion").ToString
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtComprobante_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtComprobante.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If Me.txtComprobante.Text.Trim.Length > 0 Then
                Cursor = Cursors.WaitCursor
                Dim intOpcion As Integer = 0
                If intModo = Operacion.Modificar Then
                    intOpcion = 1
                End If
                Dim intTipo As Integer
                If Me.cboTipoComprobante.SelectedIndex = 0 Then
                    intTipo = 1
                ElseIf Me.cboTipoComprobante.SelectedIndex = 1 Then
                    intTipo = 2
                Else
                    intTipo = 85
                End If
                Dim obj As New Cls_Autorizacion_LN
                dtComprobante = obj.ListarComprobante(Me.txtComprobante.Text.Trim, intTipo, intOpcion)
                If dtComprobante.Rows.Count > 0 Then
                    Mostrar(dtComprobante, 1)
                    Me.cboTipoOperacion.Enabled = True
                    If intModo = Operacion.Nuevo Then
                        Me.cboTipoOperacion.DroppedDown = True
                    End If
                    Me.cboTipoOperacion.Focus()
                Else
                    Me.cboTipoOperacion.Enabled = False
                    Cursor = Cursors.Default
                    MessageBox.Show("El Comprobante no existe o no está Disponible", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtComprobante.Focus()
                    Me.txtComprobante.SelectAll()
                End If
                Cursor = Cursors.Default
            End If
        Else
            If ValidaNumero2(e.KeyChar) Then
                e.Handled = False
            ElseIf e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtComprobante_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtComprobante.TextChanged
        Limpiar()
    End Sub

    Private Sub tabAutorizacion_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabAutorizacion.SelectedIndexChanged
        Me.tsbNuevo.Enabled = True
        If tabAutorizacion.SelectedTab Is tabAutorizacion.TabPages("tabLista") Then
            intModo = 0
            FormatearDGVLista()
            Me.tsbEditar.Enabled = Me.dgvLista.Rows.Count > 0
            If Me.dgvLista.Rows.Count > 0 Then
                If Me.dgvLista.CurrentRow.Cells("idestado").Value = 1 Then
                    Me.tsbAnular.Enabled = True
                Else
                    Me.tsbAnular.Enabled = False
                End If
            Else
                Me.tsbAnular.Enabled = False
            End If
            Me.tsbGrabar.Enabled = False

        ElseIf tabAutorizacion.SelectedTab Is tabAutorizacion.TabPages("tabSolicitud") Then
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False

            Me.tsbGrabar.Enabled = True

            If intModo = 0 Then
                tsbNuevo_Click(Nothing, Nothing)
            End If
            Me.txtComprobante.Focus()
            Me.txtComprobante.SelectAll()
        ElseIf tabAutorizacion.SelectedTab Is tabAutorizacion.TabPages("tabAprobacion") Then
            Cursor = Cursors.WaitCursor
            Me.tsbNuevo.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
            Me.tsbGrabar.Enabled = False
            LimpiarAprobacion()
            If Me.dgvLista.Rows.Count > 0 Then
                Dim obj As New Cls_Autorizacion_LN
                With Me.dgvLista.Rows(Me.dgvLista.CurrentCell.RowIndex)
                    Me.lblNumeroAprobacion.Text = .Cells("numero").Value
                    Me.lblFechaAprobacion.Text = .Cells("fecha").Value
                    Me.lblAgenciaAprobacion.Text = .Cells("agencia").Value
                    Me.lblSolicitanteAprobacion.Text = .Cells("solicitante").Value
                    Me.lblObservacionAprobacion.Text = IIf(IsDBNull(.Cells("observacion").Value), "", .Cells("observacion").Value)
                    Me.ListarOperacion(.Cells("id").Value, Me.dgvOperacionAprobacion)
                End With

                Dim dt As DataTable = obj.ListarComprobante(Me.dgvLista.CurrentRow.Cells("numero_comprobante").Value, Me.dgvLista.CurrentRow.Cells("tipo").Value, 1)
                If dt.Rows.Count > 0 Then
                    Mostrar(dt, 2)
                End If
                Dim dblMonto As Double = MontoSolicitudAprobacion(Me.dgvOperacionAprobacion)
                Me.lblTotalSolicitudAprobacion.Text = Format(dblMonto, "###,###,###0.00")

                Me.lblEstado.Text = Me.dgvLista.CurrentRow.Cells("estado").Value
                If Me.dgvLista.CurrentRow.Cells("idestado").Value = 1 Then
                    Me.btnAceptar.Enabled = True
                Else
                    Me.btnAceptar.Enabled = False
                    Me.rbtSi.Enabled = False
                    Me.rbtNo.Enabled = False
                    Me.txtObservacionAprobacion.Enabled = False
                End If
            Else
                Me.btnAceptar.Enabled = False
                Me.rbtSi.Enabled = False
                Me.rbtNo.Enabled = False
                Me.txtObservacionAprobacion.Enabled = False
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Function MontoSolicitudAprobacion(dgv As DataGridView) As Double
        Dim dblMonto As Double = 0
        For Each row As DataGridViewRow In dgv.Rows
            If row.Cells("id").Value >= 0 Then
                dblMonto += CType(row.Cells(1).Value, Double)
            End If
        Next
        Return dblMonto
    End Function

    Function MontoSolicitud(dgv As DataGridView) As Double
        Dim dblMonto As Double = 0
        For Each row As DataGridViewRow In dgv.Rows
            If row.Cells("estado").Value >= 0 Then
                dblMonto += CType(row.Cells(1).Value, Double)
            End If
        Next
        Return dblMonto
    End Function

    Function ObtienePrimerItemAactivo(dgv As DataGridView) As Integer
        Dim i As Integer = 0
        Dim blnEntra As Boolean = False
        For Each row As DataGridViewRow In dgv.Rows
            If row.Cells("estado").Value >= 0 Then
                blnEntra = True
                Return i
            End If
            i += 1
        Next
        Return 0
    End Function

    Function ObtieneItemActivo(dgv As DataGridView) As Integer
        Dim i As Integer = 0
        For Each row As DataGridViewRow In dgv.Rows
            If row.Cells("estado").Value >= 0 Then
                i += 1
            End If
        Next
        Return i
    End Function

    Function ObtieneTipoOperacion(dgv As DataGridView) As Integer
        If dgv.Rows.Count > 0 Then
            Return dgv.Rows(0).Cells("tipo").Value
        Else
            Return -1
        End If
    End Function

    Private Sub dgvOperacion_RowsRemoved(sender As Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvOperacion.RowsRemoved
        If Me.cboTipoOperacion.SelectedIndex = 2 Then
            Me.btnAgregar.Enabled = ObtieneItemActivo(Me.dgvOperacion) <= 0
        End If
        Dim dblMonto As Double
        dblMonto = MontoSolicitud(dgvOperacion)
        Me.lblTotalSolicitud.Text = Format(dblMonto, "###,###,###0.00")
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If Me.dgvOperacion.Rows.Count > 0 Then
            Dim dlgRespuesta As DialogResult = MessageBox.Show("¿Está seguro de eliminar la Operación?", "Agregar Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                With Me.dgvOperacion
                    LimpiarLista(alista, .CurrentRow.Cells("idoperacion").Value)
                    If .CurrentRow.Cells("estado").Value = 0 Then 'no grabado
                        .Rows.Remove(.CurrentRow)
                    Else 'grabado
                        .CurrentRow.Cells("estado").Value = -1
                        .CurrentRow.Visible = False
                    End If
                    If ObtieneItemActivo(Me.dgvOperacion) = 0 Then
                        Me.btnEliminar.Enabled = False
                    End If

                    Dim intItem As Integer = ObtienePrimerItemAactivo(Me.dgvOperacion)
                    If intItem > 0 Then
                        dgvOperacion.Rows(intItem).Selected = True
                        .CurrentCell = dgvOperacion.Rows(intItem).Cells(0)
                    Else
                        Me.btnAgregar.Focus()
                    End If
                End With
                If Me.cboTipoOperacion.SelectedIndex = 2 Then
                    Me.btnAgregar.Enabled = ObtieneItemActivo(Me.dgvOperacion) <= 0
                End If
            End If
        End If
        Dim dblMonto As Double
        dblMonto = MontoSolicitud(Me.dgvOperacion)
        Me.lblTotalSolicitud.Text = Format(dblMonto, "###,###,###0.00")
    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub tsbNuevo_Click(sender As System.Object, e As System.EventArgs) Handles tsbNuevo.Click
        Nuevo()
    End Sub

    Sub Nuevo()
        intModo = Operacion.Nuevo
        Me.Limpiar()
        tabAutorizacion.SelectedTab = tabAutorizacion.TabPages("tabSolicitud")
        cboTipoComprobante.SelectedIndex = 0
        Me.txtComprobante.Text = ""
        Me.txtComprobante.Focus()
        Me.txtComprobante.SelectAll()
    End Sub

    Private Sub tsbGrabar_Click(sender As System.Object, e As System.EventArgs) Handles tsbGrabar.Click
        If ObtieneItemActivo(Me.dgvOperacion) = 0 Then
            MessageBox.Show("Ingrese la Operación", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If Me.btnAgregar.Enabled Then
                Me.btnAgregar.Focus()
            Else
                Me.txtComprobante.Focus()
                Me.txtComprobante.SelectAll()
            End If
            Return
        End If

        If Me.txtMotivo.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese el Motivo", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtMotivo.Text = Me.txtMotivo.Text.Trim
            Me.txtMotivo.Focus()
            Return
        End If

        Grabar()
    End Sub

    Private Sub tsbEditar_Click(sender As System.Object, e As System.EventArgs) Handles tsbEditar.Click
        If tabAutorizacion.TabPages.IndexOf(tabSolicitud) > -1 Then
            intModo = Operacion.Modificar
            tabAutorizacion.SelectedTab = tabAutorizacion.TabPages("tabSolicitud")
            MostrarSolicitud(Me.dgvLista.CurrentCell.RowIndex)
            Me.grbBuscarComprobante.Enabled = False
            'Me.txtComprobante.Enabled = False
            Me.cboTipoOperacion.Enabled = False

            If Me.dgvLista.CurrentRow.Cells("idestado").Value = 1 Then
                Me.btnAgregar.Enabled = True
                Me.btnEliminar.Enabled = True
            Else
                Me.tsbGrabar.Enabled = False
                Me.cboTipoOperacion.Enabled = False
                Me.btnAgregar.Enabled = False
                Me.btnEliminar.Enabled = False
                Me.txtMotivo.Enabled = False
            End If

            If Me.cboTipoOperacion.SelectedIndex = 2 Then
                Me.btnAgregar.Enabled = ObtieneItemActivo(Me.dgvOperacion) <= 0
            End If

            Dim dblMonto As Double
            dblMonto = MontoSolicitud(dgvOperacion)
            Me.lblTotalSolicitud.Text = Format(dblMonto, "###,###,###0.00")
        ElseIf tabAutorizacion.TabPages.IndexOf(tabAprobacion) > -1 Then
            tabAutorizacion.SelectedTab = tabAutorizacion.TabPages("tabAprobacion")
        End If
    End Sub

    Sub MostrarSolicitud(fila As Integer)
        With Me.dgvLista.Rows(fila)
            If Me.dgvLista.Rows(fila).Cells("tipo").Value = 1 Then
                Me.cboTipoComprobante.SelectedIndex = 0
            ElseIf .Cells("tipo").Value = 2 Then
                Me.cboTipoComprobante.SelectedIndex = 1
            Else
                Me.cboTipoComprobante.SelectedIndex = 2
            End If

            Me.txtComprobante.Text = .Cells("numero_comprobante").Value
            Me.lblNumero.Text = .Cells("numero").Value
            Me.lblFecha.Text = .Cells("fecha").Value
            Me.lblAgencia.Text = .Cells("agencia").Value
            Me.lblSolicitante.Text = .Cells("solicitante").Value
            Me.txtMotivo.Text = IIf(IsDBNull(.Cells("observacion").Value), "", .Cells("observacion").Value)

            Me.cboTipoOperacion.SelectedIndex = .Cells("tipo_operacion").Value
            Dim e As New KeyPressEventArgs(Chr(13))
            Me.txtComprobante_KeyPress(Nothing, e)

            Me.ListarOperacion(.Cells("id").Value, Me.dgvOperacion)
        End With
    End Sub

    Sub ListarSolicitud(ByVal ciudad As Integer, ByVal agencia As Integer, ByVal estado As Integer, ByVal opcion As Integer, ByVal rol As Integer, ByVal inicio As String, ByVal fin As String)
        Dim obj As New Cls_Autorizacion_LN
        Me.dgvLista.DataSource = obj.ListarSolicitud(ciudad, agencia, estado, opcion, rol, inicio, fin)
        If Me.dgvLista.Rows.Count = 0 Then
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
        Else
            Me.tsbEditar.Enabled = True
        End If
    End Sub

    Sub ListarDatos(id As Integer, operacion As Integer)
        Dim obj As New Cls_Autorizacion_LN
        Dim dt As DataTable = obj.ListarDatos(id, operacion)
        If dt.Rows.Count > 0 Then
            'alista = New ArrayList
            LimpiarLista(alista, operacion)
            For Each row As DataRow In dt.Rows
                AgregarDato(operacion, row.Item("dato").ToString, row.Item("id").ToString)
            Next
        End If
    End Sub

    Sub ListarOperacion(solicitud As Integer, dgv As DataGridView)
        Dim obj As New Cls_Autorizacion_LN
        Dim dt As DataTable = obj.ListarOperacion(solicitud)
        With dgv
            .Rows.Clear()
            If dt.Rows.Count > 0 Then
                Dim intFila As Integer = 0
                For Each row As DataRow In dt.Rows
                    .Rows.Add()
                    intFila = .Rows.Count - 1
                    .Rows(intFila).Cells("operacion").Value = row.Item("operacion").ToString
                    .Rows(intFila).Cells("monto").Value = CType(row.Item("monto").ToString, Double)
                    .Rows(intFila).Cells("idoperacion").Value = CType(row.Item("idoperacion").ToString, Integer)
                    .Rows(intFila).Cells("id").Value = CType(row.Item("id").ToString, Integer)
                    .Rows(intFila).Cells("estado").Value = CType(row.Item("estado").ToString, Integer)
                    .Rows(intFila).Cells("tipo_operacion").Value = CType(row.Item("tipo_operacion").ToString, Integer)
                    .Rows(intFila).Cells("tipo_comprobante_final").Value = CType(row.Item("tipo_comprobante_final").ToString, Integer)
                    .Rows(intFila).Cells("tipo").Value = CType(row.Item("tipo").ToString, Integer)
                    .Rows(intFila).Cells("cuenta_corriente").Value = CType(row.Item("cuenta_corriente").ToString, Integer)
                    ListarDatos(CType(row.Item("id").ToString, Integer), CType(row.Item("idoperacion").ToString, Integer))

                    '-->Jabanto - 08/06/2016 - FE
                    .Rows(intFila).Tag = row
                Next
            End If
        End With
    End Sub

    Sub Grabar()
        Cursor = Cursors.WaitCursor
        Try
            Dim objEN As New Cls_Autorizacion_EN
            If intModo = Operacion.Nuevo Then
                objEN.ID = 0
            Else
                objEN.ID = Me.dgvLista.CurrentRow.Cells("id").Value
            End If
            objEN.Tipo = Me.lblTipoComprobante.Tag
            objEN.Comprobante = Me.lblNumeroComprobante.Tag
            objEN.Total = CType(Me.lblTotalSolicitud.Text, Double)
            objEN.Solicitante = dtoUSUARIOS.IdLogin
            objEN.Agencia = dtoUSUARIOS.iIDAGENCIAS
            objEN.Observacion = Me.txtMotivo.Text.Trim
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP
            objEN.TipoOperacion = Me.cboTipoOperacion.SelectedIndex
            'objEN.UsuarioLiquidacion = Me.lblUsuarioLiquidacion.Text
            objEN.CuentaCorriente = Me.dgvOperacion.CurrentRow.Cells("cuenta_corriente").Value()

            Dim objLN As New Cls_Autorizacion_LN
            Dim intId As Integer = objLN.GrabarSolicitud(objEN)
            If intId > 0 Then
                Dim objEN2 As New Cls_Autorizacion_EN
                Dim objLN2 As New Cls_Autorizacion_LN
                For Each row As DataGridViewRow In Me.dgvOperacion.Rows
                    'If row.Cells("estado").Value >= 0 Then
                    objEN2.ID2 = intId
                    objEN2.ID = row.Cells("id").Value
                    objEN2.Operacion = row.Cells("idoperacion").Value
                    objEN2.Total = row.Cells("monto").Value
                    objEN2.Estado = row.Cells("estado").Value
                    objEN2.Usuario = dtoUSUARIOS.IdLogin
                    objEN2.IP = dtoUSUARIOS.IP()

                    Dim intId2 = objLN2.GrabarSolicitudDetalle(objEN2)
                    If intId2 > 0 Then
                        Dim intContador As Integer = 0
                        Dim objEN3 As New Cls_Autorizacion_EN
                        Dim objLN3 As New Cls_Autorizacion_LN
                        objEN3.ID2 = intId2
                        objEN3.Operacion = objEN2.Operacion
                        objEN3.Usuario = dtoUSUARIOS.IdLogin
                        objEN3.IP = dtoUSUARIOS.IP
                        For Each obj As Datos In alista
                            If obj.operacion = objEN3.Operacion Then
                                intContador += 1
                                objEN3.Dato = obj.texto
                                objEN3.ID = obj.id
                                objEN3.Opcion = IIf(objEN2.Estado >= 0, intContador, 0)
                                objLN3.GrabarDato(objEN3)
                            End If
                        Next
                    End If
                    'End If
                Next
            End If
            Cursor = Cursors.Default
            tabAutorizacion.SelectedTab = tabAutorizacion.TabPages("tabLista")
            Me.ListarSolicitud(Me.cboCiudad.SelectedValue, Me.cboAgencia.SelectedValue, Me.cboEstado.SelectedIndex, intOpcion, dtoUSUARIOS.IdRol, Me.dtpInicio.Value.ToShortDateString, Me.dtpFin.Value.ToShortDateString)

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboAgencia_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboAgencia.SelectedValueChanged
        'Me.ListarSolicitud(Me.cboCiudad.SelectedValue, Me.cboAgencia.SelectedValue, Me.cboEstado.SelectedIndex, intOpcion, dtoUSUARIOS.IdRol)
    End Sub

    Private Sub dgvLista_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvLista.DoubleClick
        If Me.dgvLista.Rows.Count > 0 Then
            Me.tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cboCiudad_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCiudad.SelectedIndexChanged
        ListarAgencia(cboCiudad.SelectedValue)
        'Me.ListarSolicitud(Me.cboCiudad.SelectedValue, Me.cboAgencia.SelectedValue, Me.cboEstado.SelectedIndex, intOpcion, dtoUSUARIOS.IdRol)
    End Sub

    Private Sub tsbAnular_Click(sender As System.Object, e As System.EventArgs) Handles tsbAnular.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está seguro de anular la solicitud?", "Anular Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            Anular()
        End If
    End Sub

    Sub Anular()
        Try
            Dim objEN As New Cls_Autorizacion_EN
            objEN.ID = Me.dgvLista.CurrentRow.Cells("id").Value
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP

            Dim obj As New Cls_Autorizacion_LN
            obj.AnularSolicitud(objEN)
            Me.ListarSolicitud(Me.cboCiudad.SelectedValue, Me.cboAgencia.SelectedValue, Me.cboEstado.SelectedIndex, intOpcion, dtoUSUARIOS.IdRol, Me.dtpInicio.Value.ToShortDateString, Me.dtpFin.Value.ToShortDateString)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtObservacion_Enter(sender As Object, e As System.EventArgs) Handles txtMotivo.Enter
        txtMotivo.SelectAll()
    End Sub

    Private Sub txtObservacion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMotivo.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            Me.tsbGrabar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtObservacion_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtMotivo.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = Keys.Enter Then
                e.Handled = True
            End If
        End If
    End Sub

    Function ObtieneFila(dgv As DataGridView, operacion As Integer) As Integer
        With dgvOperacion
            For Each row As DataGridViewRow In dgv.Rows
                If row.Cells("idoperacion").Value = operacion Then
                    Return row.Index
                End If
            Next
        End With
    End Function

    Sub LimpiarLista(ByRef lista As ArrayList, operacion As Integer)
        Dim item As Object
        Dim lista2 As New ArrayList
        For i As Integer = 0 To lista.Count - 1
            If lista(i).operacion <> operacion Then
                lista2.Add(lista(i))
            End If
        Next
        lista = lista2
    End Sub

    Sub Agregar(frm As frmAgregarOperacion, opcion As Integer)
        With Me.dgvOperacion
            Dim intFila As Integer
            If opcion = 1 Then
                .Rows.Add()
                intFila = .Rows.Count - 1
            Else
                intFila = ObtieneFila(Me.dgvOperacion, frm.cboOperacion.SelectedValue)
            End If

            .Rows(intFila).Cells(0).Value = frm.cboOperacion.Text
            If frm.cboOperacion.SelectedValue = 12 Then
                .Rows(intFila).Cells(1).Value = IIf(frm.cboDevolucionDinero.SelectedIndex = 1, frm.txtMonto.Text, frm.lblTotal12.Text) 'frm.lblTotal12.Text
                .Rows(intFila).Cells(8).Value = frm.cboDevolucionDinero.SelectedIndex
                .Rows(intFila).Cells(9).Value = IIf(frm.cboDevolucionDinero.SelectedIndex = 1, frm.txtMonto.Text, 0)
                If frm.cboDevolucionDinero.SelectedIndex = 1 And CType(frm.lblTotal12.Text, Double) > CType(frm.txtMonto.Text, Double) Then
                    .Rows(intFila).Cells(8).Value = 4
                End If
            ElseIf frm.cboOperacion.SelectedValue = 14 Then
                .Rows(intFila).Cells(1).Value = CType(frm.lblMonto14.Text, Double)
            ElseIf frm.cboOperacion.SelectedValue = 15 Then
                .Rows(intFila).Cells(1).Value = CType(frm.lblMontoDevolucionCargo.Text, Double)
            ElseIf frm.cboOperacion.SelectedValue = 16 Then
                .Rows(intFila).Cells(1).Value = CType(frm.lblMontoEntregaDomicilio.Text, Double)
            ElseIf frm.cboOperacion.SelectedValue = 11 Then
                .Rows(intFila).Cells(1).Value = CType(frm.lblTotal11.Text, Double)
            ElseIf frm.cboOperacion.SelectedValue = 6 Then
                .Rows(intFila).Cells(1).Value = CType(frm.lblTotal6.Text, Double)

            ElseIf frm.cboOperacion.SelectedValue = 7 Or frm.cboOperacion.SelectedValue = 10 Or frm.cboOperacion.SelectedValue = 13 Or frm.cboOperacion.SelectedValue = 8 Then
                Dim blnDevolucion As Boolean
                .Rows(intFila).Cells(1).Value = IIf(CType(frm.lblTotalNC.Text, Double) = 0, CType(frm.lblTotalActual.Text, Double), CType(frm.lblTotalNC.Text, Double))
                blnDevolucion = CType(frm.lblTotalNC.Text, Double) > 0

                .Rows(intFila).Cells(8).Value = IIf(blnDevolucion, 1, 2) 'frm.cboDevolucionDinero.SelectedIndex
                .Rows(intFila).Cells(9).Value = IIf(blnDevolucion, frm.lblTotalNC.Text, 0)
                If blnDevolucion And CType(frm.lblTotalNC.Text, Double) < CType(frm.lblTotalActual.Text, Double) Then
                    .Rows(intFila).Cells(8).Value = 4
                End If
                'ElseIf frm.cboOperacion.SelectedValue = 8 Or frm.cboOperacion.SelectedValue = 10 Or frm.cboOperacion.SelectedValue = 13 Then
                '.Rows(intFila).Cells(1).Value = CType(frm.lblTotalActual.Text, Double)
            ElseIf frm.cboOperacion.SelectedValue = 8 Then
                .Rows(intFila).Cells(1).Value = CType(frm.lblTotalActual.Text, Double)
            End If
            .Rows(intFila).Cells(2).Value = frm.cboOperacion.SelectedValue
            If opcion = 1 Then
                .Rows(intFila).Cells(3).Value = 0
                .Rows(intFila).Cells(4).Value = 0
            End If
        End With

        Dim intOperacion As Integer = frm.cboOperacion.SelectedValue
        LimpiarLista(alista, intOperacion)
        If intOperacion = 6 Then
            AgregarDato(intOperacion, frm.lblRazonSocialActual.Text.Trim, frm.lblRazonSocialActual.Tag)
            AgregarDato(intOperacion, frm.txtRazonSocial6.Text.Trim, frm.lblRazonSocialActual.Tag)
            AgregarDato(intOperacion, frm.lblTotal6.Text)
        ElseIf intOperacion = 7 Or intOperacion = 8 Or intOperacion = 10 Or intOperacion = 13 Then
            AgregarDato(intOperacion, frm.lblTotalActual.Text)
            AgregarDato(intOperacion, frm.lblTotalNC.Text)
            AgregarDato(intOperacion, frm.lblTotalNuevoComprobante.Text)
            AgregarDato(intOperacion, frm.txtComprobante.Text.Trim, frm.txtComprobante.Tag)
        ElseIf intOperacion = 88 Then
            AgregarDato(intOperacion, frm.lblCantidadTotal.Text)
            AgregarDato(intOperacion, frm.lblBase8.Text)
            AgregarDato(intOperacion, frm.lblEntrega8.Text)
            AgregarDato(intOperacion, frm.lblSeguro8.Text)
            AgregarDato(intOperacion, frm.lblDevolucionCargo8.Text)
            AgregarDato(intOperacion, frm.lblDescuento8.Text)
            AgregarDato(intOperacion, frm.lblSobre8.Text)

            If frm.lblProducto8.Tag <> 81 Then
                With frm.dgvCantidad
                    Dim strArticulo As String = "", strId As String = "", strCantidad As String = "", strPrecio As String = "", strSubtotal As String = ""
                    For Each row As DataGridViewRow In .Rows
                        strArticulo = strArticulo & row.Cells("articulo").Value & ","
                        strId = strId & row.Cells("id").Value & ","
                        strCantidad = strCantidad & row.Cells("cantidad").Value & ","
                        strPrecio = strPrecio & row.Cells("precio").Value & ","
                        strSubtotal = strSubtotal & row.Cells("subtotal").Value & ","
                    Next
                    AgregarDato(intOperacion, strId)
                    AgregarDato(intOperacion, strArticulo)
                    AgregarDato(intOperacion, strCantidad)
                    AgregarDato(intOperacion, strPrecio)
                    AgregarDato(intOperacion, strSubtotal)
                End With
            Else
                With frm.dgvPeso8
                    Dim strCantidad As String = "", strSubtotal As String = ""
                    strCantidad = .Rows(0).Cells("bulto").Value & "," & .Rows(1).Cells("bulto").Value & ","
                    strSubtotal = .Rows(0).Cells("subtotal").Value & "," & .Rows(1).Cells("subtotal").Value & ","
                    AgregarDato(intOperacion, strCantidad)
                    AgregarDato(intOperacion, strSubtotal)
                End With
            End If
        ElseIf intOperacion = 11 Then
            AgregarDato(intOperacion, frm.lblDireccionActual.Text.Trim)
            AgregarDato(intOperacion, frm.txtDir11.Text.Trim)
            AgregarDato(intOperacion, frm.txtRef11.Text.Trim)
            AgregarDato(intOperacion, frm.txtDepar11.Text.Trim, frm.txtDepar11.Tag)
            AgregarDato(intOperacion, frm.txtPro11.Text.Trim, frm.txtPro11.Tag)
            AgregarDato(intOperacion, frm.txtDist11.Text.Trim, frm.txtDist11.Tag)
            AgregarDato(intOperacion, frm.lblTotal11.Text)
            AgregarDato(intOperacion, Me.lblCliente.Tag)
        ElseIf intOperacion = 12 Then
            AgregarDato(intOperacion, frm.lblTotal12.Text)
            AgregarDato(intOperacion, frm.cboDevolucionDinero.SelectedIndex)
            AgregarDato(intOperacion, IIf(frm.cboDevolucionDinero.SelectedIndex = 1, frm.txtMonto.Text, 0))
        ElseIf intOperacion = 14 Then
            AgregarDato(intOperacion, CType(frm.lblMonto14.Text, Double))
            AgregarDato(intOperacion, frm.txtDescuento14.Text)
        ElseIf intOperacion = 15 Then
            AgregarDato(intOperacion, frm.lblMontoDevolucionCargo.Text)
            AgregarDato(intOperacion, IIf(frm.chkCargo.Checked, 1, 0))
            AgregarDato(intOperacion, IIf(frm.chkCargo.Checked, ObtieneCargos(frm.dgvCargo), frm.txtMotivo.Text.Trim))
            AgregarDato(intOperacion, Me.lblCliente.Tag)
        ElseIf intOperacion = 16 Then
            AgregarDato(intOperacion, frm.lblMontoEntregaDomicilio.Text)
            AgregarDato(intOperacion, frm.txtdir16.Text.Trim)
            AgregarDato(intOperacion, frm.txtref16.Text.Trim)
            AgregarDato(intOperacion, frm.txtdepar16.Text.Trim, frm.txtdepar16.Tag)
            AgregarDato(intOperacion, frm.txtpro16.Text.Trim, frm.txtpro16.Tag)
            AgregarDato(intOperacion, frm.txtdist16.Text.Trim, frm.txtdist16.Tag)

            AgregarDato(intOperacion, frm.txtTipoDocumento.Text, frm.txtTipoDocumento.Tag)
            AgregarDato(intOperacion, frm.txtNumeroDocumento.Text.Trim)
            AgregarDato(intOperacion, frm.txtNombres.Text.Trim)
            AgregarDato(intOperacion, frm.txtApellidoPaterno.Text.Trim)
            AgregarDato(intOperacion, frm.txtApellidoMaterno.Text.Trim)
            AgregarDato(intOperacion, Me.lblCliente.Tag)
        End If
    End Sub

    Sub AgregarDato(operacion As Integer, texto As String, Optional id As Integer = 0)
        elista.operacion = operacion
        elista.texto = texto
        elista.id = id
        alista.Add(elista)
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        'If Me.cboTipoOperacion.SelectedIndex = 1 Then
        'If CType(Me.dtComprobante.Rows(0).Item("idestado_envio"), Integer) = 21 Then
        '    MessageBox.Show("El Comprobante está entregado", "Agregar Operación", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Me.txtComprobante.Focus()
        '    Return
        'End If
        'End If
        If Me.cboTipoOperacion.SelectedIndex = 2 Then 'solo anulacion
            If Me.cboTipoComprobante.SelectedIndex = 2 Then 'pce
                MessageBox.Show("Un PCE no puede ser aplicado por una Nota de Crédito ", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtComprobante.Focus()
                Return
            End If

            'Dim strFecha As String = DateAdd(DateInterval.Day, 1, dtComprobante.Rows(0).Item("fecha"))
            'Dim strFechaServidor As String = FechaServidor(1)
            'Dim dias As Long = DateDiff(DateInterval.Day, CType(strFecha, Date), CType(strFechaServidor, Date))
            'If dias <= 3 Then
            '    MessageBox.Show("La Nota de Crédito debe Emitirse después de 3 dias, según la fecha de Comprobante", "Agregar Operación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.txtComprobante.Focus()
            '    Return
            'End If
            If dtComprobante.Rows(0).Item("n_emife") = 0 Then 'si no esta dentro de los 10 dias habiles no se emite nc ni anulacion
                MessageBox.Show("El Comprobante debe ser enviado a SUNAT", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtComprobante.Focus()
                Return
            End If
            'If dtComprobante.Rows(0).Item("emite_nc") = 0 Then 'si no esta dentro de los 10 dias habiles no se emite nc ni anulacion
            'MessageBox.Show("El Comprobante excede Plazo para ser Anulado" & Chr(13) & "No está dentro de los 10 dia hábiles", "Agregar Operación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Me.txtComprobante.Focus()
            'Return
            'End If
        End If

        Dim frm As New frmAgregarOperacion
        frm.Comprobante = Me.lblNumeroComprobante.Tag
        Dim intTipo As Integer = Me.cboTipoOperacion.SelectedIndex 'ObtieneTipoOperacion(Me.dgvOperacion)
        frm.TipoOperacion = intTipo
        frm.TipoComprobante = Me.lblTipoComprobante.Tag
        frm.Cliente = Me.lblCliente.Tag
        frm.Producto = dtComprobante.Rows(0).Item("producto")
        frm.Nuevo = True
        'frm.intUsuario = Me.lblUsuarioLiquidacion.Text
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            If ExisteOperacion(frm.cboOperacion.SelectedValue) Then
                MessageBox.Show("La Operación ya existe", "Agregar Operación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnAgregar.Focus()
                Return
            End If
            Agregar(frm, 1)
            'If intTipo = 2 Then
            '    Me.lblUsuarioLiquidacion.Text = frm.cboUsuario.SelectedValue
            'Else
            '    Me.lblUsuarioLiquidacion.Text = 0
            'End If
            Me.btnEliminar.Enabled = True
            If Me.cboTipoOperacion.SelectedIndex = 2 Then
                Me.btnAgregar.Enabled = ObtieneItemActivo(Me.dgvOperacion) <= 0
            End If

            Dim dblMonto As Double
            dblMonto = MontoSolicitud(dgvOperacion)
            Me.lblTotalSolicitud.Text = Format(dblMonto, "###,###,###0.00")
        End If
    End Sub

    Private Sub dgvOperacion_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvOperacion.DoubleClick
        With Me.dgvOperacion
            If .Rows.Count > 0 Then
                Dim frm As New frmAgregarOperacion
                frm.Cargar(alista, Me.dgvOperacion.CurrentRow.Cells("idoperacion").Value, Me.cboTipoOperacion.SelectedIndex)
                frm.Comprobante = Me.lblNumeroComprobante.Tag
                frm.cboOperacion.Enabled = False
                frm.TipoComprobante = Me.lblTipoComprobante.Tag
                frm.Cliente = Me.lblCliente.Tag
                If Me.dgvOperacion.Rows.Count > 0 Then
                    frm.NC = Me.dgvOperacion.CurrentRow.Cells("monto").Value
                Else
                    frm.NC = 0
                End If
                'frm.cboTipoOperacion.Enabled = False
                If Not Me.tsbGrabar.Enabled Then
                    frm.tabOperacion.Enabled = False
                End If
                frm.Nuevo = False
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    Agregar(frm, 2)
                End If
            End If
        End With
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If Me.rbtNo.Checked Then
            If Me.txtObservacionAprobacion.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese el Motivo", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtObservacionAprobacion.Text = ""
                Me.txtObservacionAprobacion.Focus()
                Return
            End If
        Else
            'If Me.dgvLista.CurrentRow.Cells("tipo_operacion").Value = 2 Then 'solo nc / anulacion
            '    'Verifica si se puede emitir Nota de credito o baja
            '    'If dtComprobante.Rows(0).Item("emite_nc") = 0 Then 'si no esta dentro de los 10 dias habiles no se emite nc ni anulacion
            '    Dim strFecha As String = Me.lblFechaComprobanteAprobacion.Text 'DateAdd(DateInterval.Day, 1, dtComprobante.Rows(0).Item("fecha"))
            '    Dim strFechaServidor As String = FechaServidor(1)
            '    Dim obj As New Cls_NotaCredito_LN
            '    Dim intEmite As Integer = obj.EmiteComprobante(strFecha, strFechaServidor)
            '    If intEmite = 0 Then
            '        MessageBox.Show("El Comprobante excede Plazo para ser Anulado" & Chr(13) & "No está dentro de los 10 dias hábiles", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        Me.btnAceptar.Focus()
            '        Return
            '    End If
            'End If
        End If
        Aprobar()
    End Sub

    Private Sub rbtSi_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtSi.CheckedChanged
        Me.txtObservacionAprobacion.Enabled = False
        Me.txtObservacionAprobacion.Text = ""
        Me.txtObservacionAprobacion.Focus()
    End Sub

    Private Sub rbtNo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtNo.CheckedChanged
        Me.txtObservacionAprobacion.Enabled = True
        Me.txtObservacionAprobacion.Focus()
    End Sub

    Private Sub dgvLista_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.RowEnter
        With Me.dgvLista
            If dgvLista.Rows(e.RowIndex).Cells("idestado").Value = 1 Then
                Me.tsbAnular.Enabled = True
            Else
                Me.tsbAnular.Enabled = False
            End If
        End With
    End Sub

    Private Sub cboTipoOperacion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoOperacion.SelectedIndexChanged
        Static intOpcion As Integer

        If blnBloquea Then Return

        If Me.cboTipoOperacion.SelectedIndex > 0 Then
            If Me.cboTipoOperacion.SelectedIndex = 2 Then
                Me.btnAgregar.Enabled = ObtieneItemActivo(Me.dgvOperacion) <= 0
            Else
                Me.btnAgregar.Enabled = True
            End If
            Me.btnAgregar.Focus()
        Else
            Me.btnAgregar.Enabled = False
        End If

        If Me.dgvOperacion.Rows.Count > 0 Then
            If Me.cboTipoOperacion.SelectedIndex > 0 And Me.cboTipoOperacion.SelectedIndex <> intOpcion Then
                Dim dlgRespuesta As DialogResult
                dlgRespuesta = MessageBox.Show("Ha Seleccionado otro Tipo de Operación" & Chr(13) & "Se limpiará la Lista de Operaciones" & Chr(13) & Chr(13) & "¿Desea Continuar?", "Autorización", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                    FormatearDGVOperacion(dgvOperacion)
                Else
                    blnBloquea = True
                    Me.cboTipoOperacion.SelectedIndex = intOpcion
                    If Me.cboTipoOperacion.SelectedIndex = 2 Then
                        Me.btnAgregar.Enabled = ObtieneItemActivo(Me.dgvOperacion) <= 0
                    End If
                    blnBloquea = False
                    End If
            ElseIf Me.cboTipoOperacion.SelectedIndex = 0 Then
                    FormatearDGVOperacion(dgvOperacion)
            End If
        End If
        intOpcion = Me.cboTipoOperacion.SelectedIndex
    End Sub

    Sub ListarAgencia(ciudad As Integer)
        With Me.cboAgencia
            Dim obj As New Cls_Autorizacion_LN
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = obj.ListarAgencia(ciudad)
            .SelectedValue = 0
        End With
    End Sub

    Private Sub cboAgencia_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAgencia.SelectedIndexChanged
        'Me.ListarSolicitud(Me.cboCiudad.SelectedValue, Me.cboAgencia.SelectedValue, Me.cboEstado.SelectedIndex, intOpcion, dtoUSUARIOS.IdRol, Me.dtpInicio.Value.ToShortDateString, Me.dtpFin.Value.ToShortDateString)
    End Sub

    Private Sub cboEstado_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstado.SelectedIndexChanged
        'Me.ListarSolicitud(Me.cboCiudad.SelectedValue, Me.cboAgencia.SelectedValue, Me.cboEstado.SelectedIndex, intOpcion, dtoUSUARIOS.IdRol)
    End Sub

    Sub Aprobar()
        Try
            If Me.rbtSi.Checked Then 'aprueba
                Dim strMensaje As String = "¿Está Seguro de Aprobar la Solicitud?"
                Dim intRespuesta As DialogResult = MessageBox.Show(strMensaje, "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If intRespuesta = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    'genera comprobantes si tipo de operacion es por nota de credito o baja
                    If Me.dgvLista.CurrentRow.Cells("tipo_operacion").Value = 2 Then
                        AprobarSolicitud(2)
                        'GenerarComprobantes()
                    Else 'facturacion adicional
                        AprobarSolicitud(2)
                    End If

                    Cursor = Cursors.Default
                    MessageBox.Show("Solicitud Aprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitud(0, 0, 1, intOpcion, dtoUSUARIOS.IdRol, Me.dtpInicio.Value.ToShortDateString, Me.dtpFin.Value.ToShortDateString)
                    Me.cboEstado.SelectedIndex = 1
                    tabAutorizacion.SelectedTab = tabAutorizacion.TabPages("tabLista")
                End If
            ElseIf Me.rbtNo.Checked Then 'no aprueba
                If MessageBox.Show("¿Está Seguro de Desaprobar la Solicitud?", "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    AprobarSolicitud(3)
                    MessageBox.Show("Solicitud Desaprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cboEstado.SelectedIndex = 1
                    Me.ListarSolicitud(0, 0, 1, intOpcion, dtoUSUARIOS.IdRol, Me.dtpInicio.Value.ToShortDateString, Me.dtpFin.Value.ToShortDateString)
                    tabAutorizacion.SelectedTab = tabAutorizacion.TabPages("tabLista")
                    Cursor = Cursors.Default
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AprobarSolicitud(estado As Integer, Optional opcion As Integer = 0)
        Cursor = Cursors.WaitCursor
        Try
            Dim objLN As New Cls_Autorizacion_LN
            Dim intID As Integer = Me.dgvLista.CurrentRow.Cells("id").Value
            Dim dblPrecio As Double, strObservacion As String
            If estado = 2 Then
                strObservacion = ""
            ElseIf estado = 3 Then
                strObservacion = Me.txtObservacionAprobacion.Text.Trim
            End If

            Dim objEN As New Cls_Autorizacion_EN
            objEN.ID = intID
            objEN.Observacion = strObservacion
            objEN.Estado = estado
            objEN.Opcion = opcion
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP
            objEN.Operacion = Me.dgvOperacionAprobacion.Rows(0).Cells("idoperacion").Value

            objLN.AprobarSolicitud(objEN)

        Catch ex As Exception
            Cursor = Cursors.Default
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Function ListarDetalle(id As Integer, operacion As Integer) As DataTable
        Try
            Dim obj As New Cls_Autorizacion_LN
            Return obj.ListarDatos(id, operacion)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Sub GenerarComprobantes()
        Try
            Dim intComprobante As Integer, strFecha As String, intOperacion As Integer, strGlosa As String
            Dim dblSubtotal As Double, dblImpuesto As Double, dblTotal As Double
            Dim obj As New Cls_NotaCredito_LN
            Dim dataRowNota
            Dim noteTotal As Double
            Dim noteSubTotal As Double
            Dim noteImpuesto As Double
            Dim intUsuario As Integer, intAgencia As Integer, strIp As String
            intUsuario = Me.dgvLista.CurrentRow.Cells("usuario_liquidacion").Value
            intAgencia = Me.dgvLista.CurrentRow.Cells("idagencia").Value
            strIp = Me.dgvLista.CurrentRow.Cells("ip").Value

            'Determina si se emite Nota de Credito o Baja segun fecha de comprobante
            'Si fecha del servidor-fecha de comprobante es menor o igual a 3 dias baja si no nota de credito
            Dim strFechaComprobante As String = Me.lblFechaComprobanteAprobacion.Text 'DateAdd(DateInterval.Day, 1, CType(Me.lblFechaComprobanteAprobacion.Text, Date))
            Dim strFechaServidor As String = FechaServidor(1)
            Dim dias As Long = DateDiff(DateInterval.Day, CType(strFechaComprobante, Date), CType(strFechaServidor, Date))
            Dim intOrigen As Integer = IIf(dias > 3, 2, 1) '1=baja 2=nc
            Dim strMotivo As String = ""
            If intOrigen = 2 Then 'Nota de Credito
                'Genera Nota de credito
                intComprobante = Me.dgvLista.CurrentRow.Cells("comprobante").Value
                strFecha = Format(Now, "dd/MM/yyyy")
                intOperacion = Me.dgvOperacionAprobacion.Rows(0).Cells("idoperacion").Value
                strGlosa = Me.dgvOperacionAprobacion.Rows(0).Cells("operacion").Value

                dblTotal = Me.dgvOperacionAprobacion.Rows(0).Cells("monto").Value
                dblSubtotal = dblTotal / (1 + (dtoUSUARIOS.iIGV / 100))
                dblImpuesto = dblTotal - dblSubtotal
                dblTotal = Format(dblTotal * -1, "0.00")
                dblSubtotal = Format(dblSubtotal * -1, "0.00")
                dblImpuesto = Format(dblImpuesto * -1, "0.00")

                noteTotal = dblTotal * -1
                noteSubTotal = dblSubtotal * -1
                noteImpuesto = dblImpuesto * -1
                dataRowNota = obj.GrabarNotaCredito(30, intComprobante, strFecha, intOperacion, _
                                      strGlosa, intAgencia, dblSubtotal, dblImpuesto, dblTotal, _
                                      intUsuario, strIp)
            ElseIf intOrigen = 1 Then 'Baja
                'hlamas 01-06-2016
                'Valida si comprobante puede ser anulado
                strMotivo = Me.dgvOperacionAprobacion.Rows(0).Cells("operacion").Value
                Dim strComprobante As String = Me.dgvLista.CurrentRow.Cells("numero_comprobante").Value
                Dim intPosicion As Integer = InStr(strComprobante, "-")
                'Dim strSerie As String = IIf(iTipo = 1, "F", "B") & strComprobante.Substring(0, intPosicion - 1)
                Dim strSerie As String = strComprobante.Substring(0, intPosicion - 1)
                Dim strNumero As String = strComprobante.Substring(intPosicion)
                strNumero = strNumero.PadLeft(8, "0")
                Dim intTipo As Integer = Me.dgvLista.CurrentRow.Cells("tipo").Value
                Dim strTipo As String = IIf(intTipo = 1, "01", "03")
                Dim blnAnulable As Boolean = FEManager.isAvoidable(strTipo, strFechaComprobante, strSerie, strNumero, strMotivo)
                If Not blnAnulable Then
                    Cursor = Cursors.Default
                    'MessageBox.Show("El Comprobante no puede ser Anulado F.E.", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Throw New Exception("El Comprobante no puede ser Anulado F.E.")
                    Return
                End If
            End If

            'Genera Comprobante adicional
            Dim dataRowFactura As DataRow
            With Me.dgvOperacionAprobacion
                If dgvOperacionAprobacion.Rows(0).Cells("tipo_operacion").Value = 3 Then 'para operaciones que generan refacturacion
                    If dgvOperacionAprobacion.Rows(0).Cells("tipo_comprobante_final").Value > 0 Then 'si operacion aun no genera comprobante adicional
                        Dim dt As DataTable = ListarDetalle(.Rows(0).Cells("id").Value, .Rows(0).Cells("idoperacion").Value)
                        If dt.Rows.Count > 0 Then
                            intComprobante = Me.dgvLista.CurrentRow.Cells("comprobante").Value
                            intOperacion = Me.dgvOperacionAprobacion.Rows(0).Cells("idoperacion").Value
                            dblTotal = Me.dgvOperacionAprobacion.Rows(0).Cells("monto").Value
                            dblSubtotal = dblTotal / (1 + (dtoUSUARIOS.iIGV / 100))
                            dblImpuesto = dblTotal - dblSubtotal
                            dblTotal = Format(dblTotal, "0.00")
                            dblSubtotal = Format(dblSubtotal, "0.00")
                            dblImpuesto = Format(dblImpuesto, "0.00")
                            If dgvOperacionAprobacion.Rows(0).Cells("idoperacion").Value = 6 Then 'cambio razon social
                                dataRowFactura = obj.GrabarFactura(Me.dgvLista.CurrentRow.Cells("tipo").Value, Me.dgvLista.CurrentRow.Cells("comprobante").Value, Format(Now, "dd/MM/yyyy"), "", _
                                dt.Rows(1).Item("id"), 0, "", "", "", "", dt.Rows(1).Item("dato"), "", "", _
                                0, "", 0, "", "", "", "", 0, "", 0, "", 0, "", 0, 0, 0, "", intAgencia, dblSubtotal, dblImpuesto, dblTotal, _
                                .Rows(0).Cells("idoperacion").Value, intOrigen, intUsuario, strIp)
                            ElseIf dgvOperacionAprobacion.Rows(0).Cells("idoperacion").Value = 11 Then 'cambio direccion cliente
                                dataRowFactura = obj.GrabarFactura(Me.dgvLista.CurrentRow.Cells("tipo").Value, Me.dgvLista.CurrentRow.Cells("comprobante").Value, Format(Now, "dd/MM/yyyy"), "", _
                                0, 0, "", "", "", "", "", "", "", _
                                -1, dt.Rows(1).Item("dato"), 0, "", "", "", "", 0, "", 0, "", 0, "", dt.Rows(3).Item("id"), dt.Rows(4).Item("id"), dt.Rows(5).Item("id"), _
                                dt.Rows(2).Item("dato"), intAgencia, dblSubtotal, dblImpuesto, dblTotal, _
                                .Rows(0).Cells("idoperacion").Value, intOrigen, intUsuario, strIp)
                            End If
                        End If
                    Else 'operacion con comprobante adicional ya generado
                        intComprobante = Me.dgvLista.CurrentRow.Cells("comprobante").Value
                        intOperacion = Me.dgvOperacionAprobacion.Rows(0).Cells("idoperacion").Value
                        Dim dt As DataTable = ListarDetalle(.Rows(0).Cells("id").Value, .Rows(0).Cells("idoperacion").Value)
                        If dt.Rows.Count > 0 Then
                            Dim intComprobanteRef As Integer
                            intComprobanteRef = CType(dt.Rows(3).Item("id"), Integer)
                            obj.AmarrarComprobante(intComprobante, intComprobanteRef, intOperacion)
                        End If
                    End If
                End If
            End With

            If intOrigen = 1 Then 'Genera Baja
                intComprobante = Me.dgvLista.CurrentRow.Cells("comprobante").Value
                'obj.AnularComprobante(intComprobante, intUsuario, strIp)
                AnularComprobante(intComprobante, strMotivo, intUsuario, dtoUSUARIOS.m_iIdRol, dtoUSUARIOS.IP)
            End If

            AprobarSolicitud(2, 1)

            'Return
            If dtoUSUARIOS.IP = "192.168.50.47" Then
                Return
            End If

            '========================================================================================
            '-->GENERA LA NOTA DE CREDITO Y LA FACTURA Y/O BOLETA ELECTRONICA - jabanto - 07/06/2016
            '========================================================================================
            'Busca el Comprobante original
            Dim comprobanteReferenciaID As String = dgvLista.CurrentRow.Cells("tipo").Value
            Dim comprobanteReferenciaNumero As String = dgvLista.CurrentRow.Cells("numero_comprobante").Value
            Dim comprobanteReferenciaFecha As String = dgvLista.CurrentRow.Cells("fecha").Value

            '-->Nota de credito
            '******************************
            Dim fenote As FENota = Nothing
            If Not (dataRowNota Is Nothing) Then
                Dim fecliente As New FECliente
                fecliente.tipoDocumentoID = dataRowNota(3).ToString
                fecliente.numeroDocumento = dataRowNota(4).ToString
                fecliente.nombres = dataRowNota(5).ToString
                If Not (IsDBNull(dataRowNota(6))) Then _
                    fecliente.direccion = dataRowNota(6).ToString

                Dim documentoReferencia As New FEDocumentoReferencia
                documentoReferencia.tipoDocumentoID = comprobanteReferenciaID
                documentoReferencia.numeroDocumento = comprobanteReferenciaNumero
                documentoReferencia.fechaEmision = comprobanteReferenciaFecha

                fenote = New FENota
                fenote.numeroSerie = dataRowNota(0).ToString()
                fenote.numeroCorrelativo = dataRowNota(1).ToString()
                fenote.cliente = fecliente
                fenote.documentoReferencia = documentoReferencia
                fenote.fechaEmison = FechaServidor()
                fenote.igv = noteImpuesto
                fenote.subTotal = noteSubTotal
                fenote.total = noteTotal
                fenote.tipoNota = DirectCast(dgvOperacionAprobacion.CurrentRow.Tag, DataRow)("codigo_sunat")
                fenote.descripcionTipoNota = DirectCast(dgvOperacionAprobacion.CurrentRow.Tag, DataRow)("descripcion_sunat")
                fenote.totalLentras = ConvercionNroEnLetras(fenote.total)
                fenote.descripcionSustento = strGlosa.Trim.ToUpper()
                fenote.id = dataRowNota(2)
                fenote.tabla = "T_FACTURA_CONTADO"
            End If

            '-->Valida si solamente debe aplicar una nota de credito, mas no un nuevo comprobante
            If (dataRowFactura Is Nothing AndAlso Not fenote Is Nothing) Then
                Try
                    '-->Aplica Solamente una nota de credito
                    Dim result = FEManager.sendNota(fenote, True)
                    If (result.isCorrect) Then
                        Dim idNotaCredito As Long = dataRowNota(2)
                        Dim objFac As New ClsLbTepsa.dtoFACTURA
                        objFac.actualizarEmisonFE(idNotaCredito, "T_FACTURA_CONTADO")
                    End If
                    MessageBox.Show(result.Message, "Respuesta WSSunat", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("La Nota de Crédito Electrónica no pudo ser registrada, por favor comuníquese con el Area de Sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                Try
                    '-->Aplica la Nota de credito y el nuevo comprobante (Factura/Boleta)
                    '**********************************************************************
                    Dim feventa As FEVenta = Nothing
                    If Not (dataRowFactura Is Nothing) Then
                        Dim FECliente As New FECliente
                        FECliente.tipoDocumentoID = dataRowFactura(3).ToString()
                        FECliente.numeroDocumento = dataRowFactura(4).ToString()
                        FECliente.nombres = dataRowFactura(5).ToString()
                        If Not (IsDBNull(dataRowFactura(6))) Then _
                            FECliente.direccion = dataRowFactura(6).ToString()

                        feventa = New FEVenta
                        feventa.cliente = FECliente
                        feventa.isCredito = False
                        feventa.numeroSerie = dataRowFactura(0).ToString()
                        feventa.numeroCorrelativo = dataRowFactura(1).ToString()
                        feventa.isMonedaSoles = True
                        feventa.fechaEmision = FechaServidor()
                        feventa.tipoComprobanteID = dataRowFactura(7).ToString()
                        feventa.opGravada = Convert.ToDouble(dblTotal)
                        feventa.igv = Convert.ToDouble(dblImpuesto)
                        feventa.total = Convert.ToDouble(dblTotal)
                        feventa.totalLetras = ConvercionNroEnLetras(feventa.total)
                        feventa.id = dataRowNota(2)
                        feventa.tabla = "T_FACTURA_CONTADO"

                        'Este documento permite al servcio web, buscar el detalle y la informacion adicional del documento en referencia para 
                        'copiar el detalle a este nuevo comprobante
                        Dim documentoReferenciaVenta As New FEDocumentoReferencia
                        documentoReferenciaVenta.tipoDocumentoID = comprobanteReferenciaID
                        documentoReferenciaVenta.numeroDocumento = comprobanteReferenciaNumero
                        feventa.documentoReferencia = documentoReferenciaVenta
                    End If

                    '-->Valida si debe emitir la nota de credito y el nuevo comprobante
                    Dim result = Nothing
                    If Not fenote Is Nothing AndAlso Not feventa Is Nothing Then
                        '-->Emite ambos comprobantes
                        result = FEManager.sendNotaVenta(fenote, True, feventa, Nothing)
                    ElseIf Not feventa Is Nothing Then
                        '-->Emite solamente la factura
                        result = FEManager.sendVentaSunat(feventa, Nothing)
                    End If

                    If Not result Is Nothing Then
                        If (result.IsCorrect) Then
                            '-->Actualiza la nota de credito como emitido electronicamente
                            If Not dataRowNota Is Nothing Then
                                Dim idNotaCredito As Long = dataRowNota(2)
                                Dim objFac As New ClsLbTepsa.dtoFACTURA
                                objFac.actualizarEmisonFE(idNotaCredito, "T_FACTURA_CONTADO")
                            End If

                            If Not dataRowFactura Is Nothing Then
                                Dim objFac As New ClsLbTepsa.dtoFACTURA
                                '-->Actualiza la factura/boleta como emitido electronicamente
                                Dim idFactura As Long = dataRowFactura(2)
                                objFac.actualizarEmisonFE(idFactura, "T_FACTURA_CONTADO")
                            End If
                        End If
                        MessageBox.Show(result.Message, "Respuesta WSSunat", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Catch ex As Exception
                    MessageBox.Show("No se pudierón Generar los comprobantes electrónicos, por favor comuníquese con el Area de Sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub AnularComprobante(ByVal comprobante As String, motivo As String, ByVal usuario As Integer, ByVal rol As Integer, ip As String)
        Try
            Dim obj As New dtoGuia
            obj.AnularComprobante(comprobante, motivo, usuario, rol, ip)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub dgvOperacionAprobacion_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvOperacionAprobacion.DoubleClick
        With Me.dgvOperacionAprobacion
            If .Rows.Count > 0 Then
                Dim intOperacion As Integer = Me.dgvOperacionAprobacion.CurrentRow.Cells("idoperacion").Value
                Dim frm As New frmAgregarOperacion
                frm.Cargar(alista, intOperacion, Me.dgvOperacionAprobacion.CurrentRow.Cells("tipo").Value)
                frm.Comprobante = Me.lblNumeroComprobanteAprobacion.Tag
                frm.cboOperacion.Enabled = False
                frm.TipoComprobante = Me.lblTipoComprobanteAprobacion.Tag
                frm.Cliente = Me.lblClienteAprobacion.Tag
                frm.txtComprobante.Enabled = False
                frm.btnAceptar.Enabled = False
                If intOperacion = 7 Or intOperacion = 8 Or intOperacion = 10 Or intOperacion = 13 Then
                    frm.tabOperacion.Enabled = True
                    frm.intOpcion = 1
                Else
                    frm.tabOperacion.Enabled = False
                    frm.intOpcion = 0
                End If
                frm.ShowDialog()
            End If
        End With
    End Sub

    Private Sub cboTipoComprobante_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoComprobante.SelectedIndexChanged
        Me.txtComprobante.Text = ""
        Me.txtComprobante.Focus()
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Try
            Cursor = Cursors.WaitCursor
            Me.ListarSolicitud(Me.cboCiudad.SelectedValue, Me.cboAgencia.SelectedValue, Me.cboEstado.SelectedIndex, intOpcion, dtoUSUARIOS.IdRol, Me.dtpInicio.Value.ToShortDateString, Me.dtpFin.Value.ToShortDateString)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class