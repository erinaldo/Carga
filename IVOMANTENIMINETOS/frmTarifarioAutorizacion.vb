Imports INTEGRACION_LN

Public Class frmTarifarioAutorizacion
    Dim utilData As New UtilData_LN
    Dim intOperacion As Operacion
    Dim intOpcion As Integer

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Close()
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

        If blnSolicitud2 Then
            blnSolicitud = Acceso.SiRol(G_Rol, Me, 1, 2)
            If blnSolicitud Then
                intOpcion2 = 1
            End If
        End If

        utilData.cargarCombos("t_unidadAgencia", Me.cboCiudad, True)
        FormateardgvLista()
        ConfigurarDGVTarifa(Me.dgvTarifa)
        ConfigurarDGVTarifa(Me.dgvTarifaAprobacion)

        If intOpcion = 1 Then
            Me.cboEstado.SelectedIndex = 1
            Me.tabTarifario.TabPages.Remove(Me.tabTarifario.TabPages("tabAprobacion"))
        ElseIf intOpcion = 2 Then
            Me.cboEstado.SelectedIndex = 1
            'Me.cboEstado.Enabled = False
            Me.tabTarifario.TabPages.Remove(Me.tabTarifario.TabPages("tabSolicitud"))
            Me.tsbNuevo.Enabled = False
        ElseIf intOpcion = 3 Then
            Me.cboEstado.SelectedIndex = 1
        Else
            Me.tabTarifario.TabPages.Remove(Me.tabTarifario.TabPages("tabSolicitud"))
            Me.tabTarifario.TabPages.Remove(Me.tabTarifario.TabPages("tabAprobacion"))
            Me.tabTarifario.TabPages.Remove(Me.tabTarifario.TabPages("tabLista"))
            Me.tsbNuevo.Enabled = False
            Return
        End If

        If intOpcion2 = 1 Then
            Me.cboCiudad.SelectedValue = dtoUSUARIOS.m_idciudad
            Me.cboCiudad.Enabled = False
        End If
        'Me.cboEstado.SelectedIndex = 1
    End Sub

    Private Sub frmTarifarioAutorizacion_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Inicio()
    End Sub

    Private Sub ConfigurarDGVTarifa(dgv As DataGridView)
        With dgv
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 7.0!, FontStyle.Regular)
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
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Nº Id" : .Visible = False
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_producto As New DataGridViewTextBoxColumn
            With col_producto
                .Name = "producto" : .DataPropertyName = "producto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Producto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_tipo_tarifa As New DataGridViewTextBoxColumn
            With col_tipo_tarifa
                .Name = "tipo_tarifa" : .DataPropertyName = "tipo_tarifa"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Tarifa"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_tipo_visibilidad As New DataGridViewTextBoxColumn
            With col_tipo_visibilidad
                .Name = "tipo_visibilidad" : .DataPropertyName = "tipo_visibilidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Visibilidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_volumen As New DataGridViewTextBoxColumn
            With col_volumen
                .Name = "volumen" : .DataPropertyName = "volumen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_sobre As New DataGridViewTextBoxColumn
            With col_sobre
                .Name = "sobre" : .DataPropertyName = "sobre"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Sobre"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_base As New DataGridViewTextBoxColumn
            With col_base
                .Name = "base" : .DataPropertyName = "base"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Base"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_peso_minimo As New DataGridViewTextBoxColumn
            With col_peso_minimo
                .Name = "peso_minimo" : .DataPropertyName = "peso_minimo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Peso Mínimo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_flete_minimo As New DataGridViewTextBoxColumn
            With col_flete_minimo
                .Name = "flete_minimo" : .DataPropertyName = "flete_minimo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Flete Mínimo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_volumen_minimo As New DataGridViewTextBoxColumn
            With col_volumen_minimo
                .Name = "volumen_minimo" : .DataPropertyName = "volumen_minimo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Volumen Mínimo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_flete_volumen_minimo As New DataGridViewTextBoxColumn
            With col_flete_volumen_minimo
                .Name = "flete_volumen_minimo" : .DataPropertyName = "flete_volumen_minimo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Flete Volumen Mínimo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_idorigen As New DataGridViewTextBoxColumn
            With col_idorigen
                .Name = "idorigen" : .DataPropertyName = "idorigen" : .DisplayIndex = x : .Visible = False : .HeaderText = "idorigen"
            End With
            x += +1
            Dim col_iddestino As New DataGridViewTextBoxColumn
            With col_iddestino
                .Name = "iddestino" : .DataPropertyName = "iddestino" : .DisplayIndex = x : .Visible = False : .HeaderText = "iddestino"
            End With
            x += +1
            Dim col_idproducto As New DataGridViewTextBoxColumn
            With col_idproducto
                .Name = "idproducto" : .DataPropertyName = "idproducto" : .DisplayIndex = x : .Visible = False : .HeaderText = "idproducto"
            End With
            x += +1
            Dim col_idtipo_tarifa As New DataGridViewTextBoxColumn
            With col_idtipo_tarifa
                .Name = "idtipo_tarifa" : .DataPropertyName = "idtipo_tarifa" : .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo_tarifa"
            End With
            x += +1
            Dim col_idtipo_visibilidad As New DataGridViewTextBoxColumn
            With col_idtipo_visibilidad
                .Name = "idtipo_visibilidad" : .DataPropertyName = "idtipo_visibilidad" : .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo_visibilidad"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "Estado"
            End With

            .Columns.AddRange(col_id, col_origen, col_destino, col_producto, col_tipo_tarifa, col_tipo_visibilidad, col_peso, col_volumen, col_sobre, _
                              col_base, col_peso_minimo, col_flete_minimo, col_volumen_minimo, col_flete_volumen_minimo, _
                              col_idorigen, col_iddestino, col_idproducto, col_idtipo_tarifa, col_idtipo_visibilidad, col_estado)
        End With
    End Sub

    Sub FormateardgvLista()
        With dgvLista
            'utilitario.FormatDataGridView(dgv1)
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
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With
            x += +1
            Dim col_fecha_solicitud As New DataGridViewTextBoxColumn
            With col_fecha_solicitud
                .Name = "fecha_solicitud" : .DataPropertyName = "fecha_solicitud" : .DisplayIndex = x : .Visible = True
                .HeaderText = "Fecha Solicitud"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero" : .DisplayIndex = x : .Visible = True : .HeaderText = "Nº"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_oficina As New DataGridViewTextBoxColumn
            With col_oficina
                .Name = "oficina" : .DataPropertyName = "oficina" : .DisplayIndex = x : .Visible = False : .HeaderText = "Oficina"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_solicitante As New DataGridViewTextBoxColumn
            With col_solicitante
                .Name = "solicitante" : .DataPropertyName = "solicitante" : .DisplayIndex = x : .Visible = False : .HeaderText = "Solicitante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_ciudad As New DataGridViewTextBoxColumn
            With col_ciudad
                .Name = "ciudad" : .DataPropertyName = "ciudad" : .DisplayIndex = x : .Visible = True : .HeaderText = "Ciudad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion"
                .DisplayIndex = x : .HeaderText = "Observacion" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_aprobacion As New DataGridViewTextBoxColumn
            With col_fecha_aprobacion
                .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aprobación" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_desaprobacion As New DataGridViewTextBoxColumn
            With col_fecha_desaprobacion
                .Name = "fecha_desaprobacion" : .DataPropertyName = "fecha_desaprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Desaprobación" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_anulacion As New DataGridViewTextBoxColumn
            With col_fecha_anulacion
                .Name = "fecha_anulacion" : .DataPropertyName = "fecha_anulacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Anulación" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado"
            End With

            .Columns.AddRange(col_id, col_fecha_solicitud, col_numero, col_oficina, col_solicitante, col_ciudad, col_observacion, col_estado, _
                              col_fecha_aprobacion, col_fecha_desaprobacion, col_fecha_anulacion, _
                              col_id_estado)
        End With
    End Sub

    Sub LimpiarSolicitud()
        Me.lblFecha.Text = Format(FechaServidor, "Short Date")
        Me.lblNumeroSolicitud.Text = ""
        Me.lblCiudad.Text = dtoUSUARIOS.m_iNombreAgencia
        Me.lblSolicitante.Text = ""
        Me.txtObservacion.Text = ""
        Me.txtObservacion.Enabled = True
        Me.btnAgregar.Enabled = True
        'Me.dgvTarifa.DataSource = Nothing
        Me.dgvTarifa.Rows.Clear()
    End Sub

    Function ExisteValorGrid(ByVal dgv As DataGridView, frm As frmTarifarioAutorizacionDetalle) As Boolean
        Dim blnExiste As Boolean
        For Each row As DataGridViewRow In dgv.Rows
            blnExiste = row.Cells("idorigen").Value = frm.cboOrigen.SelectedValue And row.Cells("iddestino").Value = frm.cboDestino.SelectedValue And _
                        row.Cells("idproducto").Value = frm.cboProducto.SelectedValue And row.Cells("idtipo_tarifa").Value = frm.cboTipoTarifa.SelectedValue And _
                        row.Cells("idtipo_visibilidad").Value = frm.cboTipoVisibilidad.SelectedIndex
            If blnExiste Then
                Return True
            End If
        Next
        Return False
    End Function

    Function AgregarTarifa(frm As frmTarifarioAutorizacionDetalle, Optional dgv As DataGridView = Nothing, _
                           Optional opcion As Integer = 1, Optional row As DataRow = Nothing) As Integer
        Dim intRegistros As Integer = 0
        If opcion = 1 Then
            If Not ExisteValorGrid(Me.dgvTarifa, frm) Then
                dgv.Rows.Add()
                dgv(0, dgv.Rows.Count - 1).Value = 0
                dgv(1, dgv.Rows.Count - 1).Value = frm.cboOrigen.Text
                dgv(2, dgv.Rows.Count - 1).Value = frm.cboDestino.Text
                dgv(3, dgv.Rows.Count - 1).Value = frm.cboProducto.Text
                dgv(4, dgv.Rows.Count - 1).Value = frm.cboTipoTarifa.Text
                dgv(5, dgv.Rows.Count - 1).Value = frm.cboTipoVisibilidad.Text
                dgv(6, dgv.Rows.Count - 1).Value = frm.txtPeso.Text
                dgv(7, dgv.Rows.Count - 1).Value = frm.txtVolumen.Text
                dgv(8, dgv.Rows.Count - 1).Value = frm.txtSobre.Text
                dgv(9, dgv.Rows.Count - 1).Value = frm.txtBase.Text
                dgv(10, dgv.Rows.Count - 1).Value = frm.txtPesoMinimo.Text
                dgv(11, dgv.Rows.Count - 1).Value = frm.txtFleteMinimoPeso.Text
                dgv(12, dgv.Rows.Count - 1).Value = frm.txtVolumenMinimo.Text
                dgv(13, dgv.Rows.Count - 1).Value = frm.txtFleteMinimoVolumen.Text
                dgv(14, dgv.Rows.Count - 1).Value = frm.cboOrigen.SelectedValue
                dgv(15, dgv.Rows.Count - 1).Value = frm.cboDestino.SelectedValue
                dgv(16, dgv.Rows.Count - 1).Value = frm.cboProducto.SelectedValue
                dgv(17, dgv.Rows.Count - 1).Value = frm.cboTipoTarifa.SelectedValue
                dgv(18, dgv.Rows.Count - 1).Value = frm.cboTipoVisibilidad.SelectedValue

                dgv(19, dgv.Rows.Count - 1).Value = 0
                intRegistros += 1
            End If
        ElseIf opcion = 2 Then
            'Me.dgvTarifa(0,dgv.CurrentCell.RowIndex).Value = 0
            dgv(1, dgv.CurrentCell.RowIndex).Value = frm.cboOrigen.Text
            dgv(2, dgv.CurrentCell.RowIndex).Value = IIf(frm.cboDestino.SelectedValue = -1, "TODOS", frm.cboDestino.Text)
            dgv(3, dgv.CurrentCell.RowIndex).Value = frm.cboProducto.Text
            dgv(4, dgv.CurrentCell.RowIndex).Value = frm.cboTipoTarifa.Text
            dgv(5, dgv.CurrentCell.RowIndex).Value = frm.cboTipoVisibilidad.Text
            dgv(6, dgv.CurrentCell.RowIndex).Value = IIf(frm.txtPeso.Text = "", "", frm.txtPeso.Text)
            dgv(7, dgv.CurrentCell.RowIndex).Value = IIf(frm.txtVolumen.Text = "", "", frm.txtVolumen.Text)
            dgv(8, dgv.CurrentCell.RowIndex).Value = IIf(frm.txtSobre.Text = "", "", frm.txtSobre.Text)
            dgv(9, dgv.CurrentCell.RowIndex).Value = IIf(frm.txtBase.Text = "", "", frm.txtBase.Text)
            dgv(10, dgv.CurrentCell.RowIndex).Value = IIf(frm.txtPesoMinimo.Text = "", "", frm.txtPesoMinimo.Text)
            dgv(11, dgv.CurrentCell.RowIndex).Value = IIf(frm.txtFleteMinimoPeso.Text = "", "", frm.txtFleteMinimoPeso.Text)
            dgv(12, dgv.CurrentCell.RowIndex).Value = IIf(frm.txtVolumenMinimo.Text = "", "", frm.txtVolumenMinimo.Text)
            dgv(13, dgv.CurrentCell.RowIndex).Value = IIf(frm.txtFleteMinimoVolumen.Text = "", "", frm.txtFleteMinimoVolumen.Text)
            dgv(14, dgv.CurrentCell.RowIndex).Value = frm.cboOrigen.SelectedValue
            dgv(15, dgv.CurrentCell.RowIndex).Value = frm.cboDestino.SelectedValue
            dgv(16, dgv.CurrentCell.RowIndex).Value = frm.cboProducto.SelectedValue
            dgv(17, dgv.CurrentCell.RowIndex).Value = frm.cboTipoTarifa.SelectedValue
            dgv(18, dgv.CurrentCell.RowIndex).Value = frm.cboTipoVisibilidad.SelectedValue
            'Me.dgvTarifa(19,dgv.CurrentCell.RowIndex).Value = 0
            intRegistros += 1
        Else
            dgv.Rows.Add()
            dgv(0, dgv.Rows.Count - 1).Value = row("id")
            dgv(1, dgv.Rows.Count - 1).Value = row("origen")
            dgv(2, dgv.Rows.Count - 1).Value = IIf(row("iddestino") = -1, "TODOS", row("destino"))
            dgv(3, dgv.Rows.Count - 1).Value = row("producto")
            dgv(4, dgv.Rows.Count - 1).Value = row("tipo_tarifa")
            dgv(5, dgv.Rows.Count - 1).Value = row("tipo_visibilidad")
            dgv(6, dgv.Rows.Count - 1).Value = IIf(row("peso") > 0, Format(row("peso"), "###,###,###0.00"), "")
            dgv(7, dgv.Rows.Count - 1).Value = IIf(row("volumen") > 0, Format(row("volumen"), "###,###,###0.00"), "")
            dgv(8, dgv.Rows.Count - 1).Value = IIf(row("sobre") > 0, Format(row("sobre"), "###,###,###0.00"), "")
            dgv(9, dgv.Rows.Count - 1).Value = IIf(row("base") > 0, Format(row("base"), "###,###,###0.00"), "")
            dgv(10, dgv.Rows.Count - 1).Value = IIf(row("peso_minimo") > 0, Format(row("peso_minimo"), "###,###,###0.00"), "")
            dgv(11, dgv.Rows.Count - 1).Value = IIf(row("flete_minimo") > 0, Format(row("flete_minimo"), "###,###,###0.00"), "")
            dgv(12, dgv.Rows.Count - 1).Value = IIf(row("volumen_minimo") > 0, Format(row("volumen_minimo"), "###,###,###0.00"), "")
            dgv(13, dgv.Rows.Count - 1).Value = IIf(row("flete_volumen_minimo") > 0, Format(row("flete_volumen_minimo"), "###,###,###0.00"), "")
            dgv(14, dgv.Rows.Count - 1).Value = row("idorigen")
            dgv(15, dgv.Rows.Count - 1).Value = row("iddestino")
            dgv(16, dgv.Rows.Count - 1).Value = row("idproducto")
            dgv(17, dgv.Rows.Count - 1).Value = row("idtipo_tarifa")
            dgv(18, dgv.Rows.Count - 1).Value = row("idtipo_visibilidad")
            dgv(19, dgv.Rows.Count - 1).Value = row("id_estado")
            intRegistros += 1
        End If
        Return intRegistros
    End Function

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Dim frm As New frmTarifarioAutorizacionDetalle
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            If AgregarTarifa(frm, Me.dgvTarifa) = 0 Then
                MessageBox.Show("La Tarifa ya existe en la Lista", "Agregar Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnAgregar.Focus()
            End If
        End If
    End Sub

    Private Sub tsbNuevo_Click(sender As System.Object, e As System.EventArgs) Handles tsbNuevo.Click
        LimpiarSolicitud()
        intOperacion = Operacion.Nuevo
        Me.lblSolicitante.Text = dtoUSUARIOS.NameLogin

        Me.tsbNuevo.Enabled = False
        Me.tsbEditar.Enabled = False
        Me.tsbGrabar.Enabled = True
        Me.tsbAnular.Enabled = False

        RemoveHandler tabTarifario.SelectedIndexChanged, AddressOf tabTarifario_SelectedIndexChanged
        Me.tabTarifario.SelectedTab = Me.tabTarifario.TabPages("tabSolicitud")
        AddHandler tabTarifario.SelectedIndexChanged, AddressOf tabTarifario_SelectedIndexChanged
        Me.btnAgregar.Focus()
    End Sub

    Sub LimpiarAprobacion()
        Me.lblFechaAprobacion.Text = ""
        Me.lblCiudadAprobacion.Text = ""
        Me.lblAprobarAprobacion.Text = ""
        Me.lblSolicitanteAprobacion.Text = ""
        Me.rbtSiAprobacion.Checked = True
        Me.lblObservacionAprobacion.Text = ""
        Me.btnAceptarAprobacion.Enabled = False
    End Sub

    Private Sub tabTarifario_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabTarifario.SelectedIndexChanged
        If tabTarifario.SelectedTab Is tabTarifario.TabPages("tabSolicitud") Then
            LimpiarSolicitud()
            Me.tsbNuevo.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
            If Me.dgvLista.Rows.Count > 0 Then
                tsbEditar_Click(Nothing, Nothing)
            Else
                tsbNuevo_Click(Nothing, Nothing)
            End If
        ElseIf tabTarifario.SelectedTab Is tabTarifario.TabPages("tabLista") Then
            If (intOpcion = 2 Or intOpcion = 3) Then 'tabTarifario.TabPages.IndexOf(tabAprobacion) > -1
                If intOpcion = 3 Then
                    Me.tsbNuevo.Enabled = True
                Else
                    Me.tsbNuevo.Enabled = False
                End If
                Me.tsbEditar.Enabled = Me.dgvLista.Rows.Count > 0
                Me.tsbGrabar.Enabled = False
                Me.tsbAnular.Enabled = False
            Else
                Me.tsbNuevo.Enabled = True
                Me.tsbEditar.Enabled = Me.dgvLista.Rows.Count > 0
                Me.tsbGrabar.Enabled = False
                Me.tsbAnular.Enabled = Me.dgvLista.Rows.Count > 0
            End If
        Else
            Me.tsbNuevo.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbGrabar.Enabled = False
            Me.tsbAnular.Enabled = False

            Me.LimpiarAprobacion()
            Me.dgvTarifaAprobacion.Rows.Clear()
            If Me.dgvLista.Rows.Count > 0 Then
                Me.btnAceptarAprobacion.Enabled = Me.dgvLista.CurrentRow.Cells("id_estado").Value = 1

                Me.lblFechaAprobacion.Text = Me.dgvLista.CurrentRow.Cells("fecha_solicitud").Value
                Me.lblCiudadAprobacion.Text = Me.dgvLista.CurrentRow.Cells("ciudad").Value
                Me.lblObservacionAprobacion.Text = Me.dgvLista.CurrentRow.Cells("observacion").Value
                Me.lblSolicitanteAprobacion.Text = Me.dgvLista.CurrentRow.Cells("solicitante").Value

                Dim intID As Integer = Me.dgvLista.CurrentRow.Cells("id").Value
                Me.ListarTarifa(intID, Me.dgvTarifaAprobacion, 3)
            End If
            End If
    End Sub

    Sub MostrarSolicitud(row As Integer)
        With dgvLista
            Me.lblNumeroSolicitud.Text = .Rows(row).Cells("numero").Value
            Me.lblFecha.Text = .Rows(row).Cells("fecha_solicitud").Value
            Me.lblCiudad.Text = .Rows(row).Cells("ciudad").Value
            Me.lblSolicitante.Text = .Rows(row).Cells("solicitante").Value

            Me.txtObservacion.Text = IIf(IsDBNull(.Rows(row).Cells("observacion").Value), "", .Rows(row).Cells("observacion").Value)
        End With
    End Sub

    Sub ListarTarifa(id As Integer, dgv As DataGridView, opcion As Integer)
        Try
            Cursor = Cursors.WaitCursor

            Dim obj As New Cls_TarifaPublica_LN
            Dim dt As DataTable = obj.ListarSolicitud(id)
            For Each row As DataRow In dt.Rows
                AgregarTarifa(Nothing, dgv, opcion, row)
            Next
            'Me.dgvTarifa.DataSource = dt
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbEditar_Click(sender As System.Object, e As System.EventArgs) Handles tsbEditar.Click
        If tabTarifario.TabPages.IndexOf(tabSolicitud) > -1 Then
            intOperacion = Operacion.Modificar

            Me.tsbNuevo.Enabled = False : Me.tsbEditar.Enabled = False : Me.tsbGrabar.Enabled = Me.dgvLista.CurrentRow.Cells("id_estado").Value = 1
            Me.tsbAnular.Enabled = False

            Dim intID As Integer = Me.dgvLista.CurrentRow.Cells("id").Value
            ListarTarifa(intID, Me.dgvTarifa, 3)

            MostrarSolicitud(dgvLista.CurrentCell.RowIndex)

            If Me.dgvLista.CurrentRow.Cells("id_estado").Value = 1 Then
                Me.txtObservacion.Enabled = True
                Me.btnAgregar.Enabled = True
            Else
                Me.txtObservacion.Enabled = False
                Me.btnAgregar.Enabled = False
                Me.btnEliminar.Enabled = False
            End If

            Me.tabTarifario.SelectedTab = Me.tabTarifario.TabPages("tabSolicitud")
            Me.btnAgregar.Focus()
        Else
            Me.tabTarifario.SelectedTab = Me.tabTarifario.TabPages("tabAprobacion")
        End If

    End Sub

    Private Sub tsbGrabar_Click(sender As System.Object, e As System.EventArgs) Handles tsbGrabar.Click
        If Me.txtObservacion.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese la Observación", "Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtObservacion.Text = ""
            Me.txtObservacion.Focus()
            Return
        End If

        If ObtieneItemActivo(Me.dgvTarifa) = 0 Then
            MessageBox.Show("Ingrese la Tarifa", "Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.btnAgregar.Focus()
            Return
        End If
        'If Me.dgvTarifa.Rows.Count = 0 Then
        '    MessageBox.Show("Ingrese la Tarifa", "Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Me.btnAgregar.Focus()
        '    Return
        'End If

        Try
            Cursor = Cursors.WaitCursor
            Grabar()
            ListarSolicitud()

            Dim intID As Integer = Me.dgvLista.CurrentRow.Cells("id").Value
            'ListarGuiaEnvio(intID, Me.dgvGuiaEnvio)

            If Me.dgvLista.Rows.Count > 0 Then
                Me.tsbEditar.Enabled = True
                'If intNivel = 1 Or intNivel = 4 Then
                Me.tsbAnular.Enabled = True
                'Else
                'Me.tsbAnular.Enabled = False
                'End If
            Else
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            End If
            Me.tabTarifario.SelectedTab = Me.tabTarifario.TabPages("tabLista")

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Sub Grabar()
        Try
            Dim obj As New Cls_TarifaPublica_LN
            Dim intId As Integer, intIdCab As Integer
            Dim intCiudad As Integer, intAgencia As Integer
            Dim strObservacion As String

            If intOperacion = Operacion.Nuevo Then
                intId = 0
            Else
                intId = dgvLista.CurrentRow.Cells("id").Value
            End If
            intCiudad = dtoUSUARIOS.m_iIdUnidadAgenciaReal
            intAgencia = dtoUSUARIOS.iIDAGENCIAS
            strObservacion = Me.txtObservacion.Text.Trim

            intIdCab = obj.GrabarSolicitud(intId, intAgencia, intCiudad, strObservacion, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)

            'Detalle Tarifas
            With Me.dgvTarifa
                For Each row As DataGridViewRow In .Rows
                    intId = IIf(IsDBNull(row.Cells("id").Value), 0, row.Cells("id").Value)
                    Dim intOrigen As Integer = row.Cells("idorigen").Value
                    Dim intDestino As Integer = row.Cells("iddestino").Value
                    Dim intProducto As Integer = row.Cells("idproducto").Value
                    Dim intTipoTarifa As Integer = row.Cells("idtipo_tarifa").Value
                    Dim intTipoVisibilidad As Integer = row.Cells("idtipo_visibilidad").Value
                    Dim dblPeso As Double = IIf(row.Cells("peso").Value = "", 0, row.Cells("peso").Value)
                    Dim dblVolumen As Double = IIf(row.Cells("volumen").Value = "", 0, row.Cells("volumen").Value)
                    Dim dblSobre As Double = IIf(row.Cells("sobre").Value = "", 0, row.Cells("sobre").Value)
                    Dim dblBase As Double = IIf(row.Cells("base").Value = "", 0, row.Cells("base").Value)

                    Dim dblPesoMinimo As Double = IIf(row.Cells("peso_minimo").Value = "", 0, row.Cells("peso_minimo").Value)
                    Dim dblFlete_Minimo As Double = IIf(row.Cells("flete_minimo").Value = "", 0, row.Cells("flete_minimo").Value)
                    Dim dblVolumen_Minimo As Double = IIf(row.Cells("volumen_minimo").Value = "", 0, row.Cells("volumen_minimo").Value)
                    Dim dblFlete_Volumen_Minimo As Double = IIf(row.Cells("flete_volumen_minimo").Value = "", 0, row.Cells("flete_volumen_minimo").Value)

                    Dim intEstado As Integer=row.Cells("estado").Value

                    obj.GrabarSolicitudDetalle(intId, intIdCab, intOrigen, intDestino, intProducto, intTipoTarifa, intTipoVisibilidad, dblPeso, dblVolumen, _
                                               dblSobre, dblBase, dblPesoMinimo, dblFlete_Minimo, dblVolumen_Minimo, dblFlete_Volumen_Minimo, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, intEstado)
                Next
            End With


        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub txtObservacion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtObservacion_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
        ListarSolicitud()
        If Me.dgvLista.Rows.Count > 0 Then
            Me.tsbEditar.Enabled = True
            If intOpcion = 2 Or intOpcion = 3 Then
                Me.tsbAnular.Enabled = False
            Else
                If Me.dgvLista.CurrentRow.Cells("id_estado").Value = 1 Then
                    Me.tsbAnular.Enabled = True
                    Me.tsbEditar.Enabled = True
                Else
                    Me.tsbAnular.Enabled = False
                End If
            End If
        Else
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
        End If
    End Sub

    Sub ListarSolicitud()
        Try
            Dim intNivel As Integer
            Dim obj As New Cls_TarifaPublica_LN
            Dim intCiudad As Integer = Me.cboCiudad.SelectedValue 'IIf(intNivel = 1 Or intNivel = 4, dtoUSUARIOS.m_idciudad, Me.cboCiudad.SelectedValue)
            Dim intEstado As Integer = Me.cboEstado.SelectedIndex

            Dim strFechaInicio As String = Me.dtpInicio.Value.ToShortDateString
            Dim strFechaFin As String = Me.dtpFin.Value.ToShortDateString

            Dim dt As DataTable = obj.ListarSolicitud(strFechaInicio, strFechaFin, intCiudad, intEstado)
            Me.dgvLista.DataSource = dt
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Gasto", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Anular()
        Try
            Dim objLN As New Cls_TarifaPublica_LN

            Dim intID As Integer = dgvLista.CurrentRow.Cells("id").Value
            objLN.AnularSolicitud(intID, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbAnular_Click(sender As Object, e As System.EventArgs) Handles tsbAnular.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está Seguro de Anular la Solicitud Nº " & dgvLista.CurrentRow.Cells("numero").Value & "?", "Anular Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = vbYes Then
            Anular()
            ListarSolicitud()
        End If
    End Sub

    Private Sub dgvLista_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvLista.DoubleClick
        If Me.dgvLista.Rows.Count > 0 Then
            tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub dgvTarifa_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvTarifa.DoubleClick
        With Me.dgvTarifa
            If .Rows.Count > 0 Then
                Dim frm As New frmTarifarioAutorizacionDetalle
                frm.intModo = 2
                frm.Origen = .CurrentRow.Cells("idorigen").Value
                frm.Destino = .CurrentRow.Cells("iddestino").Value
                frm.Producto = .CurrentRow.Cells("idproducto").Value
                frm.TipoTarifa = .CurrentRow.Cells("idtipo_tarifa").Value
                frm.TipoVisibilidad = .CurrentRow.Cells("idtipo_visibilidad").Value

                frm.Peso = IIf(.CurrentRow.Cells("peso").Value = "", 0, .CurrentRow.Cells("peso").Value)
                frm.Volumen = IIf(.CurrentRow.Cells("volumen").Value = "", 0, .CurrentRow.Cells("volumen").Value)
                frm.Sobre = IIf(.CurrentRow.Cells("sobre").Value = "", 0, .CurrentRow.Cells("sobre").Value)
                frm.Base = IIf(.CurrentRow.Cells("base").Value = "", 0, .CurrentRow.Cells("base").Value)

                frm.PesoMinimo = IIf(.CurrentRow.Cells("peso_minimo").Value = "", 0, .CurrentRow.Cells("peso_minimo").Value)
                frm.FleteMinimoPeso = IIf(.CurrentRow.Cells("flete_minimo").Value = "", 0, .CurrentRow.Cells("flete_minimo").Value)
                frm.VolumenMinimo = IIf(.CurrentRow.Cells("volumen_minimo").Value = "", 0, .CurrentRow.Cells("volumen_minimo").Value)
                frm.FleteVolumenMinimo = IIf(.CurrentRow.Cells("flete_volumen_minimo").Value = "", 0, .CurrentRow.Cells("flete_volumen_minimo").Value)
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    If AgregarTarifa(frm, Me.dgvTarifa, 2) = 0 Then
                        MessageBox.Show("La Tarifa ya existe en la Lista", "Agregar Tarifa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.btnAgregar.Focus()
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub dgvTarifa_RowsAdded(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvTarifa.RowsAdded
        Me.btnEliminar.Enabled = True
    End Sub

    Private Sub dgvTarifa_RowsRemoved(sender As Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvTarifa.RowsRemoved
        If Me.dgvTarifa.Rows.Count = 0 Then
            Me.btnEliminar.Enabled = False
        End If
    End Sub

    Private Sub btnAceptarAprobacion_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptarAprobacion.Click
        If Me.rbtNoAprobacion.Checked Then
            If Me.txtObservacionAprobacion.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese el Motivo", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtObservacionAprobacion.Text = ""
                Me.txtObservacionAprobacion.Focus()
                Return
            End If
        End If
        Aprobar()
    End Sub

    Sub Aprobar()
        Try
            If Me.rbtSiAprobacion.Checked Then 'aprueba
                Dim strMensaje As String = "¿Está Seguro de Aprobar la Solicitud?"
                Dim intRespuesta As DialogResult = MessageBox.Show(strMensaje, "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If intRespuesta = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    AprobarSolicitud(2)
                    MessageBox.Show("Solicitud Aprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitud()
                    tabTarifario.SelectedTab = tabTarifario.TabPages("tabLista")
                    Cursor = Cursors.Default
                End If
            ElseIf Me.rbtNoAprobacion.Checked Then 'no aprueba
                If MessageBox.Show("¿Está Seguro de Desaprobar la Solicitud?", "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    AprobarSolicitud(3)
                    MessageBox.Show("Solicitud Desaprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitud()
                    tabTarifario.SelectedTab = tabTarifario.TabPages("tabLista")
                    Cursor = Cursors.Default
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AprobarSolicitud(estado As Integer)
        Cursor = Cursors.WaitCursor
        Try
            Dim objLN As New Cls_TarifaPublica_LN
            Dim intID As Integer = Me.dgvLista.CurrentRow.Cells("id").Value
            Dim dblPrecio As Double, strObservacion As String
            Dim dblPeso As Double, dblVolumen As Double, dblPesoMinimo As Double, dblFleteMinimo As Double, dblVolumenMinimo As Double, dblFleteVolumenMinimo As Double
            Dim dblSobre As Double, dblBase As Double

            If estado = 2 Then
                strObservacion = ""
            ElseIf estado = 3 Then
                strObservacion = Me.txtObservacionAprobacion.Text.Trim
            End If
            objLN.AprobarSolicitud(intID, strObservacion, estado, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)

            If estado = 2 Then 'aprobado
                With Me.dgvTarifaAprobacion
                    Dim obj As New Cls_TarifaPublica_LN
                    For Each row As DataGridViewRow In .Rows
                        dblPeso = IIf(Val(row.Cells("peso").Value) = 0, 0, row.Cells("peso").Value)
                        dblVolumen = IIf(Val(row.Cells("volumen").Value) = 0, 0, row.Cells("volumen").Value)
                        dblSobre = IIf(Val(row.Cells("sobre").Value) = 0, 0, row.Cells("sobre").Value)
                        dblBase = IIf(Val(row.Cells("base").Value) = 0, 0, row.Cells("base").Value)
                        dblPesoMinimo = IIf(Val(row.Cells("peso_minimo").Value) = 0, 0, row.Cells("peso_minimo").Value)
                        dblFleteMinimo = IIf(Val(row.Cells("flete_minimo").Value) = 0, 0, row.Cells("flete_minimo").Value)
                        dblVolumenMinimo = IIf(Val(row.Cells("volumen_minimo").Value) = 0, 0, row.Cells("volumen_minimo").Value)
                        dblFleteVolumenMinimo = IIf(Val(row.Cells("flete_volumen_minimo").Value) = 0, 0, row.Cells("flete_volumen_minimo").Value)

                        obj.GrabarTarifa(row.Cells("idorigen").Value, row.Cells("idorigen").Value, row.Cells("iddestino").Value, _
                                         row.Cells("idproducto").Value, row.Cells("idtipo_tarifa").Value, row.Cells("idtipo_visibilidad").Value, _
                                         dblPeso, dblVolumen, dblSobre, dblBase, _
                                         dblPesoMinimo, dblFleteMinimo, dblVolumenMinimo, _
                                         dblFleteVolumenMinimo, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                    Next
                End With
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub dgvLista_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.RowEnter
        If intOpcion = 2 Or intOpcion = 3 Then
            Me.tsbAnular.Enabled = False
        Else
            If Me.dgvLista.Rows.Count > 0 Then
                If Me.dgvLista.Rows(e.RowIndex).Cells("id_estado").Value = 1 Then
                    Me.tsbAnular.Enabled = True
                Else
                    Me.tsbAnular.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub rbtNoAprobacion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtNoAprobacion.CheckedChanged
        Me.txtObservacionAprobacion.Enabled = True
        Me.txtObservacionAprobacion.Focus()
    End Sub

    Private Sub rbtSiAprobacion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtSiAprobacion.CheckedChanged
        Me.txtObservacionAprobacion.Enabled = False
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If Me.dgvTarifa.Rows.Count > 0 Then
            Quitar()
        End If
    End Sub

    Function ObtieneItemActivo(dgv As DataGridView) As Integer
        Dim i As Integer = 0
        For Each row As DataGridViewRow In dgv.Rows
            If row.Cells("estado").Value < 2 Then
                i += 1
            End If
        Next
        Return i
    End Function

    Sub Quitar()
        With dgvTarifa
            If .Rows.Count > 0 Then
                Dim dlgRespuesta As DialogResult = MessageBox.Show("¿Está Seguro de Desactivar la Tarifa?", "Desactivar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                    If dgvTarifa.CurrentRow.Cells("estado").Value = 0 Then 'Comprobante no grabado
                        .Rows.Remove(.CurrentRow)
                    Else 'Comprobante grabado
                        dgvTarifa.CurrentRow.Cells("estado").Value = 2
                        dgvTarifa.CurrentRow.Visible = False
                    End If
                    'TotalizarRecojo()

                    Dim i As Integer = 0
                    If ObtieneItemActivo(Me.dgvTarifa) > 0 Then
                        For Each row As DataGridViewRow In .Rows
                            If row.Cells("estado").Value < 2 Then
                                i += 1
                                Exit For
                            End If
                        Next
                        .Rows(i).Selected = True
                        .CurrentCell = .Rows(i).Cells(2)
                    End If
                End If
            End If
        End With
    End Sub

End Class