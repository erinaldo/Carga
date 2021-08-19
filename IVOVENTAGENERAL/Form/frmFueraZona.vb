Imports INTEGRACION_LN
Imports INTEGRACION_EN

Public Class frmFueraZona
    Dim colCliente As New Collection
    Dim autoCliente As New AutoCompleteStringCollection

    Dim tabSolicitud As TabPage, tabAceptacion As TabPage, tabAprobacion As TabPage, tabFacturar As TabPage
    Dim intNivel As Integer, intNivel2 As Integer

    Dim intOperacion As Operacion

#Region "Grid"
    Private Sub ConfigurarDGVListaSolicitud()
        With dgvListaSolicitud
            Cls_Utilitarios.FormatDataGridView(dgvListaSolicitud)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_solicitud As New DataGridViewTextBoxColumn
            With col_solicitud
                .Name = "numero_solicitud" : .DataPropertyName = "numero_solicitud"
                .DisplayIndex = x : .HeaderText = "Nº Solicitud"
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha_solicitud" : .DataPropertyName = "fecha_solicitud"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
            End With
            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
            End With
            x += +1
            Dim col_costo As New DataGridViewTextBoxColumn
            With col_costo
                .Name = "costo" : .DataPropertyName = "costo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Costo" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Precio Aceptado" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_precio_observacion As New DataGridViewTextBoxColumn
            With col_precio_observacion
                .Name = "precio_observacion" : .DataPropertyName = "precio_observacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Precio Observado" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_precio_aprobacion As New DataGridViewTextBoxColumn
            With col_precio_aprobacion
                .Name = "precio" : .DataPropertyName = "precio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Precio Aprobado" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
            End With
            x += +1
            Dim col_aceptacion As New DataGridViewTextBoxColumn
            With col_aceptacion
                .Name = "fecha_aceptacion" : .DataPropertyName = "fecha_aceptacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aceptación"
            End With
            x += +1
            Dim col_observado As New DataGridViewTextBoxColumn
            With col_observado
                .Name = "fecha_observacion" : .DataPropertyName = "fecha_observacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Observación"
            End With
            x += +1
            Dim col_aprobacion As New DataGridViewTextBoxColumn
            With col_aprobacion
                .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aprobación"
            End With
            x += +1
            Dim col_noaceptacion As New DataGridViewTextBoxColumn
            With col_noaceptacion
                .Name = "fecha_noaceptacion" : .DataPropertyName = "fecha_noaceptacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha no Aceptación"
            End With
            x += +1
            Dim col_desaprobacion As New DataGridViewTextBoxColumn
            With col_desaprobacion
                .Name = "fecha_desaprobacion" : .DataPropertyName = "fecha_desaprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Desaprobación"
            End With
            x += +1
            Dim col_anulacion As New DataGridViewTextBoxColumn
            With col_anulacion
                .Name = "fecha_anulacion" : .DataPropertyName = "fecha_anulacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Anulación"
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id"
            End With
            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Observación"
            End With
            x += +1
            Dim col_observacion_observacion As New DataGridViewTextBoxColumn
            With col_observacion_observacion
                .Name = "observacion_observacion" : .DataPropertyName = "observacion_observacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Observación"
            End With
            x += +1
            Dim col_idcliente As New DataGridViewTextBoxColumn
            With col_idcliente
                .Name = "idcliente" : .DataPropertyName = "idcliente"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcliente"
            End With
            x += +1
            Dim col_oficina As New DataGridViewTextBoxColumn
            With col_oficina
                .Name = "oficina" : .DataPropertyName = "oficina"
                .DisplayIndex = x : .Visible = False : .HeaderText = "oficina"
            End With
            x += +1
            Dim col_solicitante As New DataGridViewTextBoxColumn
            With col_solicitante
                .Name = "solicitante" : .DataPropertyName = "solicitante"
                .DisplayIndex = x : .Visible = False : .HeaderText = "solicitante"
            End With
            x += +1
            Dim col_contacto As New DataGridViewTextBoxColumn
            With col_contacto
                .Name = "contacto" : .DataPropertyName = "contacto"
                .DisplayIndex = x : .Visible = False : .HeaderText = "contacto"
            End With
            x += +1
            Dim col_funcionario As New DataGridViewTextBoxColumn
            With col_funcionario
                .Name = "funcionario" : .DataPropertyName = "funcionario"
                .DisplayIndex = x : .Visible = False : .HeaderText = "funcionario"
            End With
            x += +1
            Dim col_localidad As New DataGridViewTextBoxColumn
            With col_localidad
                .Name = "localidad" : .DataPropertyName = "localidad"
                .DisplayIndex = x : .Visible = False : .HeaderText = "localidad"
            End With
            x += +1
            Dim col_km As New DataGridViewTextBoxColumn
            With col_km
                .Name = "km" : .DataPropertyName = "km"
                .DisplayIndex = x : .Visible = False : .HeaderText = "km"
            End With
            x += +1
            Dim col_hora As New DataGridViewTextBoxColumn
            With col_hora
                .Name = "hora" : .DataPropertyName = "hora"
                .DisplayIndex = x : .Visible = False : .HeaderText = "hora"
            End With
            x += +1
            Dim col_idestado As New DataGridViewTextBoxColumn
            With col_idestado
                .Name = "idestado" : .DataPropertyName = "idestado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id estado"
            End With

            .Columns.AddRange(col_solicitud, col_fecha, col_codigo, col_cliente, col_costo, col_total, col_precio_observacion, col_precio_aprobacion, col_estado, _
                              col_aceptacion, col_observado, col_aprobacion, col_noaceptacion, col_desaprobacion, col_anulacion, _
                              col_observacion, col_observacion_observacion, col_id, col_idcliente, col_oficina, col_solicitante, col_contacto, _
                              col_funcionario, col_localidad, col_km, col_hora, col_idestado)
        End With
    End Sub
    Private Sub ConfigurarDGVGuiaEnvio()
        With dgvGuiaEnvio
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
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_guia As New DataGridViewTextBoxColumn
            With col_guia
                .Name = "guia" : .DataPropertyName = "guia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Guía"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Orígen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_agencia_origen As New DataGridViewTextBoxColumn
            With col_agencia_origen
                .Name = "agencia_origen" : .DataPropertyName = "agencia_origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_agencia_destino As New DataGridViewTextBoxColumn
            With col_agencia_destino
                .Name = "agencia_destino" : .DataPropertyName = "agencia_destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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
            Dim col_direccion As New DataGridViewTextBoxColumn
            With col_direccion
                .Name = "direccion" : .DataPropertyName = "direccion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Dirección"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            x += +1
            Dim col_idguia As New DataGridViewTextBoxColumn
            With col_idguia
                .Name = "idguia" : .DataPropertyName = "idguia"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idguia"
            End With
            x += +1
            Dim col_idagencias As New DataGridViewTextBoxColumn
            With col_idagencias
                .Name = "idagencia_origen" : .DataPropertyName = "idagencia_origen"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idagencia_origen"
            End With
            x += +1
            Dim col_idagencias_destino As New DataGridViewTextBoxColumn
            With col_idagencias_destino
                .Name = "idagencia_destino" : .DataPropertyName = "idagencia_destino"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idagencia_destino"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
            End With

            .Columns.AddRange(col_id, col_fecha, col_guia, col_origen, col_destino, col_agencia_origen, col_agencia_destino, col_total, _
                              col_cantidad, col_peso, col_direccion, _
                              col_idguia, col_idagencias, col_idagencias_destino, col_estado)
        End With
    End Sub
    Private Sub ConfigurarDGVGuiaEnvioAceptacion()
        With dgvGuiaEnvioAceptacion
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
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_guia As New DataGridViewTextBoxColumn
            With col_guia
                .Name = "guia" : .DataPropertyName = "guia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Guía"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Orígen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_agencia_origen As New DataGridViewTextBoxColumn
            With col_agencia_origen
                .Name = "agencia_origen" : .DataPropertyName = "agencia_origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_agencia_destino As New DataGridViewTextBoxColumn
            With col_agencia_destino
                .Name = "agencia_destino" : .DataPropertyName = "agencia_destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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
            Dim col_direccion As New DataGridViewTextBoxColumn
            With col_direccion
                .Name = "direccion" : .DataPropertyName = "direccion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Dirección"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_idguia As New DataGridViewTextBoxColumn
            With col_idguia
                .Name = "idguia" : .DataPropertyName = "idguia"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idguia"
            End With
            x += +1
            Dim col_idagencias As New DataGridViewTextBoxColumn
            With col_idagencias
                .Name = "idagencia_origen" : .DataPropertyName = "idagencia_origen"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idagencia_origen"
            End With
            x += +1
            Dim col_idagencias_destino As New DataGridViewTextBoxColumn
            With col_idagencias_destino
                .Name = "idagencia_destino" : .DataPropertyName = "idagencia_destino"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idagencia_destino"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
            End With

            .Columns.AddRange(col_id, col_fecha, col_guia, col_origen, col_destino, col_agencia_origen, col_agencia_destino, col_total, _
                              col_cantidad, col_peso, col_direccion, _
                              col_idguia, col_idagencias, col_idagencias_destino, col_estado)
        End With
    End Sub
    Private Sub ConfigurarDGVGuiaEnvioAprobacion()
        With dgvGuiaEnvioAprobacion
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
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
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Nº Id" : .Visible = False
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_guia As New DataGridViewTextBoxColumn
            With col_guia
                .Name = "guia" : .DataPropertyName = "guia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Guía"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Orígen"
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
            Dim col_agencia_origen As New DataGridViewTextBoxColumn
            With col_agencia_origen
                .Name = "agencia_origen" : .DataPropertyName = "agencia_origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_agencia_destino As New DataGridViewTextBoxColumn
            With col_agencia_destino
                .Name = "agencia_destino" : .DataPropertyName = "agencia_destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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
            Dim col_direccion As New DataGridViewTextBoxColumn
            With col_direccion
                .Name = "direccion" : .DataPropertyName = "direccion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Dirección"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_idguia As New DataGridViewTextBoxColumn
            With col_idguia
                .Name = "idguia" : .DataPropertyName = "idguia"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idguia"
            End With
            x += +1
            Dim col_idagencias As New DataGridViewTextBoxColumn
            With col_idagencias
                .Name = "idagencia_origen" : .DataPropertyName = "idagencia_origen"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idagencia_origen"
            End With
            x += +1
            Dim col_idagencias_destino As New DataGridViewTextBoxColumn
            With col_idagencias_destino
                .Name = "idagencia_destino" : .DataPropertyName = "idagencia_destino"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idagencia_destino"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
            End With

            .Columns.AddRange(col_id, col_fecha, col_guia, col_origen, col_destino, col_agencia_origen, col_agencia_destino, col_total, _
                              col_cantidad, col_peso, col_direccion, _
                              col_idguia, col_idagencias, col_idagencias_destino, col_estado)
        End With
    End Sub
    Private Sub ConfigurarDGVResultado()
        With dgvResultado
            Cls_Utilitarios.FormatDataGridView(dgvResultado)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .AutoGenerateColumns = False
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = False
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = False
            .EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_sel As New DataGridViewCheckBoxColumn
            With col_sel
                .HeaderText = "Seleccionar"
                .Name = "sel"
                '.DataPropertyName = "IDESTADO_REGISTRO"
                '.Width = 200
                '.ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                '.Frozen = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DisplayIndex = x
            End With
            x += 1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Id" : .Visible = False
            End With
            x += +1
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Solicitud"
            End With
            x += +1
            Dim col_oficina As New DataGridViewTextBoxColumn
            With col_oficina
                .Name = "oficina" : .DataPropertyName = "oficina"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Oficina"
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha" : .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
            End With
            x += +1
            Dim col_subtotal As New DataGridViewTextBoxColumn
            With col_subtotal
                .Name = "subtotal" : .DataPropertyName = "subtotal"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subtotal" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_impuesto As New DataGridViewTextBoxColumn
            With col_impuesto
                .Name = "impuesto" : .DataPropertyName = "impuesto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Impuesto" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_agencia As New DataGridViewTextBoxColumn
            With col_agencia
                .Name = "agencia" : .DataPropertyName = "agencia"
                .DisplayIndex = x : .Visible = False : .HeaderText = "agencia"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
            End With
            .Columns.AddRange(col_sel, col_id, col_numero, col_oficina, col_fecha, col_cliente, col_subtotal, col_impuesto, col_total, col_agencia, col_estado)
        End With
    End Sub
    Private Sub ConfigurarDGVFactura()
        With dgvFactura
            Cls_Utilitarios.FormatDataGridView(dgvFactura)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .AutoGenerateColumns = False
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = False
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            .EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Id" : .Visible = False
            End With
            x += +1
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Solicitud"
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
            End With
            x += +1
            Dim col_agencia As New DataGridViewTextBoxColumn
            With col_agencia
                .Name = "agencia" : .DataPropertyName = "agencia"
                .DisplayIndex = x : .Visible = False : .HeaderText = "agencia"
            End With
            x += +1
            Dim col_subtotal As New DataGridViewTextBoxColumn
            With col_subtotal
                .Name = "subtotal" : .DataPropertyName = "subtotal"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subtotal" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_impuesto As New DataGridViewTextBoxColumn
            With col_impuesto
                .Name = "impuesto" : .DataPropertyName = "impuesto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Impuesto" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            .Columns.AddRange(col_id, col_numero, col_cliente, col_agencia, col_subtotal, col_impuesto, col_total)
        End With
    End Sub
    Private Sub ConfigurarDGVImprimir()
        With dgvImprimir
            Cls_Utilitarios.FormatDataGridView(dgvImprimir)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .AutoGenerateColumns = False
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = False
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            .EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "Id" : .Visible = False
            End With
            x += +1
            Dim col_oficina As New DataGridViewTextBoxColumn
            With col_oficina
                .Name = "oficina" : .DataPropertyName = "oficina"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Oficina"
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
            End With
            x += +1
            Dim col_factura As New DataGridViewTextBoxColumn
            With col_factura
                .Name = "factura" : .DataPropertyName = "factura"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Factura"
            End With
            x += +1
            Dim col_ruc As New DataGridViewTextBoxColumn
            With col_ruc
                .Name = "ruc" : .DataPropertyName = "ruc"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Ruc"
            End With
            x += +1
            Dim col_razon_social As New DataGridViewTextBoxColumn
            With col_razon_social
                .Name = "razon_social" : .DataPropertyName = "razon_social"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Razon Social"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_subtotal As New DataGridViewTextBoxColumn
            With col_subtotal
                .Name = "subtotal" : .DataPropertyName = "subtotal"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subtotal" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_impuesto As New DataGridViewTextBoxColumn
            With col_impuesto
                .Name = "impuesto" : .DataPropertyName = "impuesto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Impuesto" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            .Columns.AddRange(col_id, col_oficina, col_fecha, col_factura, col_ruc, col_razon_social, col_subtotal, col_impuesto, col_total)
        End With
    End Sub

    Private Sub ConfigurarDGVDetalle()
        With dgvDetalle
            Cls_Utilitarios.FormatDataGridView(dgvDetalle)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .AutoGenerateColumns = False
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = False
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            .EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .HeaderText = "fecha" : .Visible = False
            End With
            x += +1
            Dim col_factura As New DataGridViewTextBoxColumn
            With col_factura
                .Name = "factura" : .DataPropertyName = "factura"
                .DisplayIndex = x : .Visible = False : .HeaderText = "factura"
            End With
            x += +1
            Dim col_ruc As New DataGridViewTextBoxColumn
            With col_ruc
                .Name = "ruc" : .DataPropertyName = "ruc"
                .DisplayIndex = x : .Visible = False : .HeaderText = "ruc"
            End With
            x += +1
            Dim col_razon_social As New DataGridViewTextBoxColumn
            With col_razon_social
                .Name = "razon_social" : .DataPropertyName = "razon_social"
                .DisplayIndex = x : .Visible = False : .HeaderText = "razon_social"
            End With
            x += +1
            Dim col_numero_solicitud As New DataGridViewTextBoxColumn
            With col_numero_solicitud
                .Name = "numero_solicitud" : .DataPropertyName = "numero_solicitud"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Solicitud"
            End With
            x += +1
            Dim col_fecha_aprobacion As New DataGridViewTextBoxColumn
            With col_fecha_aprobacion
                .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aprobación"
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
            End With
            x += +1
            Dim col_costo As New DataGridViewTextBoxColumn
            With col_costo
                .Name = "costo" : .DataPropertyName = "costo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Costo Envío" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            .Columns.AddRange(col_fecha, col_factura, col_ruc, col_razon_social, col_numero_solicitud, col_fecha_aprobacion, col_cliente, col_costo)
        End With
    End Sub
#End Region


#Region "Inicio"
    Private Sub frmFueraZona_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ControlaAcceso()
        inicio()
    End Sub
#End Region

#Region "Lista"
    Sub LlenarCombo(cliente As Integer)
        Dim objLN As New Cls_LineaCredito_LN
        With cboContactoAceptacion
            .DataSource = Nothing
            .DataSource = objLN.ListarContactoCredito(cliente, "")
            .DisplayMember = "CONTACTO"
            .ValueMember = "ID"
            .SelectedValue = 0
        End With
    End Sub

#End Region

#Region "Solicitud"
    Sub Inicio()
        Dim obj As New dtoFueraZona
        Dim dt As DataTable = obj.ListarCliente

        Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
        ObjProcesos.fnCargar_iWin_r(Me.txtCliente, dt.DefaultView, colCliente, autoCliente, 0)

        ConfigurarDGVGuiaEnvio()
        ConfigurarDGVListaSolicitud()

        If intNivel = 1 Then
            ActualizaCombo()
            Me.cboEstadoSolicitud.SelectedIndex = 1
        ElseIf intNivel = 2 Then
            ActualizaCombo(2)
            Me.cboEstadoSolicitud.SelectedIndex = 0
        ElseIf intNivel = 3 Then
            ActualizaCombo()
            Me.cboEstadoSolicitud.SelectedIndex = 1
        Else
            ActualizaCombo()
            Me.cboEstadoSolicitud.SelectedIndex = 1
        End If
    End Sub
    Private Sub txtCliente_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Not autoCliente.IndexOf(txtCliente.Text) = -1 Then
                Dim ObjPersona As New ClsLbTepsa.dtoPersona
                With ObjPersona
                    .IDPERSONA = Int(colCliente.Item(autoCliente.IndexOf(Me.txtCliente.Text).ToString))
                    .IDTIPO_PERSONA = 0
                    .CODIGO_CLIENTE = "NULL"
                    'Datahelper
                    ObjPersona.FNLISTAR_PERSONA(.IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                    Me.txtCodigoCliente.Text = .CODIGO_CLIENTE
                End With
                SendKeys.Send(vbTab)
            Else
                Me.txtCodigoCliente.Text = ""
            End If
        End If
    End Sub

    Private Sub txtCliente_LostFocus(sender As Object, e As System.EventArgs) Handles txtCliente.LostFocus
        If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
            Me.txtCliente.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub

    Private Sub txtCodigoCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCliente.KeyPress
        Try
            If Asc(e.KeyChar) = Keys.Enter Then
                If Me.txtCodigoCliente.Text.Trim.Length > 0 Then
                    Dim obj As New dtoCarga
                    Dim strCodigoCliente As String = Me.txtCodigoCliente.Text.Trim
                    Dim dt As DataTable = obj.ObtieneCliente(strCodigoCliente)
                    If dt.Rows.Count > 0 Then
                        Me.txtCliente.Text = dt.Rows(0).Item("cliente")
                        SendKeys.Send(vbTab)
                    Else
                        MessageBox.Show("El Cliente no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCodigoCliente_LostFocus(sender As Object, e As System.EventArgs) Handles txtCodigoCliente.LostFocus
        If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
            Me.txtCliente.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub
#End Region

#Region "Administrador"
    Sub ControlaAcceso()
        tabSolicitud = tabFueraZona.TabPages("tabSolicitudZona")
        tabAceptacion = tabFueraZona.TabPages("tabAceptacionZona")
        tabAprobacion = tabFueraZona.TabPages("tabAprobacionZona")
        tabFacturar = tabFueraZona.TabPages("tabImpresionZona")

        Me.tsbEditar.Enabled = False
        Me.tsbGrabar.Enabled = False
        Me.tsbAnular.Enabled = False

        If Acceso.SiRol(G_Rol, Me, 2, 1) Then
            intNivel2 = 1
        ElseIf Acceso.SiRol(G_Rol, Me, 2, 2) Then
            intNivel2 = 2

            Me.tabFacturacion.TabPages.Remove(tabFacturacion.TabPages("tabListaFactura"))
            Me.tabFacturacion.TabPages.Remove(tabFacturacion.TabPages("tabFactura"))

            ConfigurarDGVImprimir()
            ConfigurarDGVDetalle()
            If Me.dgvImprimir.Rows.Count > 0 Then
                Me.btnImprimir.Enabled = True
            Else
                Me.btnImprimir.Enabled = False
            End If
        Else
            intNivel2 = 3
            Me.tabFueraZona.TabPages.Remove(tabFueraZona.TabPages("tabImpresionZona"))
        End If

        If Acceso.SiRol(G_Rol, Me, 1, 1) Then
            intNivel = 1
            Me.tsbNuevo.Enabled = True
            Me.tsbEditar.Text = "Editar"

            Me.rbtSeguimiento.Checked = True
            Me.pnlOpcion.Visible = False
            Me.pnlEstado.Visible = True

        ElseIf Acceso.SiRol(G_Rol, Me, 1, 2) Then
            intNivel = 2
            'Me.tabFueraZona.TabPages.Remove(tabFueraZona.TabPages("tabImpresionZona"))
            Me.tsbNuevo.Enabled = False
            Me.tsbEditar.Text = "Aceptar"

            Me.rbtSeguimiento.Visible = True
            Me.rbtPorAceptar.Checked = True
            Me.rbtPorAprobar.Visible = False
            Me.pnlEstado.Visible = True
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 3) Then
            intNivel = 3
            'Me.tabFueraZona.TabPages.Remove(tabFueraZona.TabPages("tabImpresionZona"))
            Me.tsbNuevo.Enabled = False
            Me.tsbEditar.Text = "Aprobar"

            Me.rbtSeguimiento.Visible = True
            Me.rbtPorAprobar.Checked = True
            Me.rbtPorAceptar.Visible = False
            Me.pnlEstado.Visible = False
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 4) Then
            intNivel = 4
            Me.tsbNuevo.Enabled = True

            Me.rbtSeguimiento.Visible = True
            Me.rbtSeguimiento.Checked = True
            Me.pnlEstado.Visible = True
        Else
            Me.rbtSeguimiento.Checked = True
            Me.pnlOpcion.Visible = False
            Me.pnlEstado.Visible = True
        End If
    End Sub
#End Region

    Private Sub txtCosto_Enter(sender As Object, e As System.EventArgs) Handles txtCosto.Enter
        If Val(txtCosto.Text) > 0 Then
            Me.txtCosto.Text = Replace(Me.txtCosto.Text, ",", "")
        Else
            Me.txtCosto.Text = ""
        End If
    End Sub

    Private Sub txtCosto_GotFocus(sender As Object, e As System.EventArgs) Handles txtCosto.GotFocus
        txtCosto.SelectAll()
    End Sub

    Private Sub txtCosto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCosto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumeroReal(e.KeyChar, Me.txtCosto.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtKilometro_Enter(sender As Object, e As System.EventArgs) Handles txtKilometro.Enter
        If Val(txtKilometro.Text) > 0 Then
            Me.txtKilometro.Text = Replace(Me.txtKilometro.Text, ",", "")
        Else
            Me.txtKilometro.Text = ""
        End If
    End Sub

    Private Sub txtKilometro_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtKilometro.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCosto_LostFocus(sender As Object, e As System.EventArgs) Handles txtCosto.LostFocus
        If Val(Me.txtCosto.Text) > 0 Then
            Dim dblMonto As Double
            dblMonto = CDbl(Me.txtCosto.Text)
            Me.txtCosto.Text = Format(dblMonto, "#,###,###0.00")
        Else
            Me.txtCosto.Text = ""
        End If
    End Sub

    Private Sub btnAgregarGE_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarGE.Click
        Dim intCliente As Integer
        If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
            intCliente = 0
        Else
            intCliente = Int(colCliente.Item(autoCliente.IndexOf(Me.txtCliente.Text).ToString))
        End If

        Dim frm As New frmAgregarGuiaEnvio
        frm.IDCliente = intCliente
        frm.Cliente = Me.txtCliente.Text.Trim

        frm.AgenciaDestino = dtoUSUARIOS.iIDAGENCIAS
        frm.NombreAgenciaDestino = dtoUSUARIOS.m_iNombreAgencia

        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            If AgregarGuiaEnvio(frm) = 0 Then
                MessageBox.Show("Las Guías de Envío ya existen en la Lista", "Agregar Guía de Envío", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'MessageBox.Show("La Guía de Envío " & frm.dgvResultado.Rows(0).Cells("guia").Value & " ya existe en la lista", "Agregar Guía de Envío", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnAgregarGE.Focus()
            End If
        Else
            Me.btnAgregarGE.Focus()
        End If
    End Sub

    Function AgregarGuiaEnvio(frm As frmAgregarGuiaEnvio, Optional opcion As Integer = 1) As Integer
        Dim intRegistros As Integer = 0
        For Each row As DataGridViewRow In frm.dgvResultado.Rows
            If row.Cells(0).Value = 1 Then
                If opcion = 1 Then
                    If Not ExisteValorGrid(Me.dgvGuiaEnvio, 8, row.Cells("idguia").Value) Then
                        Me.dgvGuiaEnvio.Rows.Add()
                        Me.dgvGuiaEnvio(0, Me.dgvGuiaEnvio.Rows.Count - 1).Value = 0
                        Me.dgvGuiaEnvio(1, Me.dgvGuiaEnvio.Rows.Count - 1).Value = Format(row.Cells("fecha").Value, "dd/MM/yyyy")
                        Me.dgvGuiaEnvio(2, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("guia").Value
                        Me.dgvGuiaEnvio(3, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("origen").Value
                        Me.dgvGuiaEnvio(4, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("destino").Value
                        Me.dgvGuiaEnvio(5, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("agencia_origen").Value
                        Me.dgvGuiaEnvio(6, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("agencia_destino").Value
                        Me.dgvGuiaEnvio(7, Me.dgvGuiaEnvio.Rows.Count - 1).Value = Format(row.Cells("total").Value, "###,###,###0.00")
                        Me.dgvGuiaEnvio(8, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("cantidad").Value
                        Me.dgvGuiaEnvio(9, Me.dgvGuiaEnvio.Rows.Count - 1).Value = Format(row.Cells("peso").Value, "###,###,###0.00")
                        Me.dgvGuiaEnvio(10, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("direccion").Value
                        Me.dgvGuiaEnvio(11, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("idguia").Value
                        Me.dgvGuiaEnvio(12, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("idagencia_origen").Value
                        Me.dgvGuiaEnvio(13, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("idagencia_destino").Value
                        Me.dgvGuiaEnvio(14, Me.dgvGuiaEnvio.Rows.Count - 1).Value = 0
                        intRegistros += 1
                    End If
                Else
                    Me.dgvGuiaEnvio(1, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("fecha").Value
                    Me.dgvGuiaEnvio.CurrentRow.Cells(2).Value = row.Cells("guia").Value
                    Me.dgvGuiaEnvio(3, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("origen").Value
                    Me.dgvGuiaEnvio(4, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("destino").Value
                    Me.dgvGuiaEnvio(5, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("agencia_origen").Value
                    Me.dgvGuiaEnvio(6, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("agencia_destino").Value
                    Me.dgvGuiaEnvio(7, Me.dgvGuiaEnvio.Rows.Count - 1).Value = Format(row.Cells("total").Value, "###,###,###0.00")
                    Me.dgvGuiaEnvio(8, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("cantidad").Value
                    Me.dgvGuiaEnvio(9, Me.dgvGuiaEnvio.Rows.Count - 1).Value = Format(row.Cells("peso").Value, "###,###,###0.00")
                    Me.dgvGuiaEnvio(10, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("direccion").Value
                    Me.dgvGuiaEnvio(11, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("idguia").Value
                    Me.dgvGuiaEnvio(12, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("idagencias").Value
                    Me.dgvGuiaEnvio(13, Me.dgvGuiaEnvio.Rows.Count - 1).Value = row.Cells("idagencias_destino").Value
                    intRegistros += 1
                End If
            End If
        Next
        Return intRegistros
    End Function

    Sub GrabarSolicitud(cliente As Integer)
        Try
            Dim intID As Integer, intNumeroSolicitud As Integer, strFecha As String, strObservacion As String
            Dim dblCosto As Double, intUsuario As Integer, strIP As String, dblKm As Double, strHora As String, strLocalidad As String

            Dim objLN As New dtoFueraZona
            If intOperacion = Operacion.Nuevo Then
                intID = 0
            Else
                intID = dgvListaSolicitud.CurrentRow.Cells("id").Value
            End If
            intNumeroSolicitud = Me.lblNumeroSolicitud.Text
            strFecha = Me.lblFecha.Text
            strObservacion = Me.txtObservacion.Text.Trim
            dblCosto = CDbl(Me.txtCosto.Text)
            dblKm = CDbl(Me.txtKilometro.Text)
            strHora = Me.txtHora.Text
            strLocalidad = Me.txtLocalidad.Text.Trim

            intUsuario = dtoUSUARIOS.IdLogin
            strIP = dtoUSUARIOS.IP

            Dim intIDZona As Integer = objLN.GrabarSolicitud(intID, intNumeroSolicitud, cliente, strObservacion, dblCosto, _
                                                             dtoUSUARIOS.m_iIdUnidadAgenciaReal, dtoUSUARIOS.iIDAGENCIAS, _
                                                             dblKm, strHora, strLocalidad, _
                                                             strFecha, intUsuario, strIP)
            'Actualizar guias de envio
            With Me.dgvGuiaEnvio
                For Each row As DataGridViewRow In .Rows
                    intID = IIf(IsDBNull(row.Cells("id").Value), 0, row.Cells("id").Value)
                    Dim intIDFz As Integer = intIDZona
                    strFecha = row.Cells("fecha").Value
                    Dim intGuia As Integer = row.Cells("idguia").Value
                    Dim intEstado As Integer = row.Cells("estado").Value
                    Dim strOrigen As String = row.Cells("origen").Value
                    Dim strDestino As String = row.Cells("destino").Value
                    Dim dblTotal As Double = row.Cells("total").Value
                    Dim strGuia As String = row.Cells("guia").Value
                    Dim intAgenciaOrigen As Integer = row.Cells("idagencia_origen").Value
                    Dim intAgenciaDestino As Integer = row.Cells("idagencia_destino").Value
                    Dim intCantidad As Integer = row.Cells("cantidad").Value
                    Dim dblPeso As Double = row.Cells("peso").Value
                    Dim strDireccion As String = row.Cells("direccion").Value

                    objLN.GrabarGuiaEnvio(intID, intIDFz, strFecha, intGuia, intEstado, strOrigen, strDestino, dblTotal, strGuia, intAgenciaOrigen, intAgenciaDestino, _
                                          intCantidad, dblPeso, strDireccion, _
                                          intUsuario, strIP)
                Next
            End With

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub ListarSolicitud()
        Try
            Dim strEstado As String, intOpcion As Integer = 0
            If Me.rbtSeguimiento.Checked Then 'seguimiento
                strEstado = Me.cboEstadoSolicitud.SelectedIndex
            ElseIf Me.rbtPorAceptar.Checked Then
                If Me.cboEstadoSolicitud.SelectedIndex = 0 Then
                    strEstado = "1,3" 'pendientes y observados
                Else
                    strEstado = IIf(Me.cboEstadoSolicitud.SelectedIndex = 1, 1, 3)
                End If
            ElseIf Me.rbtPorAprobar.Checked Then
                strEstado = "2" 'aceptados
            End If
            Dim obj As New dtoFueraZona
            dgvListaSolicitud.DataSource = obj.ListarSolicitud(strEstado, dtoUSUARIOS.iIDAGENCIAS, dtoUSUARIOS.IdLogin, intNivel, intOpcion)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub MostrarSolicitud(row As Integer)
        With dgvListaSolicitud
            Me.lblNumeroSolicitud.Text = .Rows(row).Cells("numero_solicitud").Value
            Me.lblFecha.Text = .Rows(row).Cells("fecha_solicitud").Value
            Me.lblOficina.Text = .Rows(row).Cells("oficina").Value
            Me.lblSolicitante.Text = .Rows(row).Cells("solicitante").Value

            Me.txtCodigoCliente.Text = .Rows(row).Cells("codigo").Value
            Me.txtCliente.Text = .Rows(row).Cells("cliente").Value

            Me.txtCosto.Text = Format(.Rows(row).Cells("costo").Value, "###,###,###0.00")
            Me.txtKilometro.Text = IIf(IsDBNull(.Rows(row).Cells("km").Value), "", .Rows(row).Cells("km").Value)
            Me.txtHora.Text = IIf(IsDBNull(.Rows(row).Cells("hora").Value), "", .Rows(row).Cells("hora").Value)
            Me.txtLocalidad.Text = IIf(IsDBNull(.Rows(row).Cells("localidad").Value), "", .Rows(row).Cells("localidad").Value)

            Me.txtObservacion.Text = .Rows(row).Cells("observacion").Value

            If .Rows(row).Cells("idestado").Value = 1 And intNivel = 1 Then
                Me.txtCosto.Enabled = True
                Me.txtKilometro.Enabled = True
                Me.txtHora.Enabled = True
                Me.txtLocalidad.Enabled = True
                Me.txtObservacion.Enabled = True
                Me.btnAgregarGE.Enabled = True
                Me.btnEliminarGE.Enabled = True
                Me.dgvGuiaEnvio.Enabled = True
                Me.tsbGrabar.Enabled = True
            Else
                Me.txtCosto.Enabled = False
                Me.txtKilometro.Enabled = False
                Me.txtHora.Enabled = False
                Me.txtLocalidad.Enabled = False
                Me.txtObservacion.Enabled = False
                Me.btnAgregarGE.Enabled = False
                Me.btnEliminarGE.Enabled = False
                Me.dgvGuiaEnvio.Enabled = False
                Me.tsbGrabar.Enabled = False
            End If
        End With
    End Sub

    Private Sub tsbGrabar_Click(sender As System.Object, e As System.EventArgs) Handles tsbGrabar.Click
        Try
            Dim intCliente As Integer
            If intOperacion = Operacion.Nuevo Then
                If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
                    intCliente = 0
                Else
                    intCliente = Int(colCliente.Item(autoCliente.IndexOf(Me.txtCliente.Text).ToString))
                End If

                If intCliente = 0 Then
                    MessageBox.Show("Seleccione el Cliente", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtCliente.Focus()
                    Return
                End If
            End If

            If Val(Me.txtCosto.Text) = 0 Then
                MessageBox.Show("Ingrese Costo", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtCosto.Focus()
                Return
            End If

            If Me.txtLocalidad.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese la Localidad de Entrega", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtLocalidad.Text = ""
                Me.txtLocalidad.Focus()
                Return
            End If

            If Val(Me.txtKilometro.Text) = 0 Then
                MessageBox.Show("Ingrese la Distancia en Kilómetros", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtKilometro.Focus()
                Return
            End If

            txtHora_LostFocus(Nothing, Nothing)
            If Me.txtHora.Text = "00:00" Then
                MessageBox.Show("Ingrese la Distancia en Horas", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txtHora.Focus()
                Return
            End If

            If Mid(Trim(txtHora.Text), 1, 2) > "23" Or Mid(Trim(txtHora.Text), 4, 2) > "59" Then
                MessageBox.Show("Ingrese la Distancia correcta en Horas", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txtHora.Focus()
                Return
            End If

            If Me.txtObservacion.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese la Observación", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtObservacion.Text = ""
                Me.txtObservacion.Focus()
                Return
            End If

            If Me.dgvGuiaEnvio.Rows.Count = 0 Or Not dtoUtilitario.FilasGridVisible(Me.dgvGuiaEnvio) Then
                MessageBox.Show("Seleccione las Guías de Envío", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnAgregarGE.Focus()
                Return
            End If

            'graba solicitud fuera de zona
            Cursor = Cursors.WaitCursor
            GrabarSolicitud(intCliente)
            ListarSolicitud()

            Dim intID As Integer = Me.dgvListaSolicitud.CurrentRow.Cells("id").Value
            ListarGuiaEnvio(intID, Me.dgvGuiaEnvio)

            If Me.dgvListaSolicitud.Rows.Count > 0 Then
                Me.tsbEditar.Enabled = True
                If intNivel = 1 Then
                    Me.tsbAnular.Enabled = True
                Else
                    Me.tsbAnular.Enabled = False
                End If
            Else
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            End If
                Me.tabFueraZona.SelectedTab = Me.tabFueraZona.TabPages("tabListaZona")

                Cursor = Cursors.Default
                'Me.btnNuevoZona.Focus()

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbNuevo_Click(sender As System.Object, e As System.EventArgs) Handles tsbNuevo.Click
        intOperacion = Operacion.Nuevo
        LimpiarSolicitud()
        Me.lblNumeroSolicitud.Text = dtoFueraZona.ObtieneNumeroSolicitud(dtoUSUARIOS.iIDAGENCIAS)
        Me.lblSolicitante.Text = dtoUSUARIOS.NameLogin

        Me.txtCodigoCliente.Enabled = True
        Me.txtCliente.Enabled = True
        Me.tsbNuevo.Enabled = False
        Me.tsbEditar.Enabled = False
        Me.tsbGrabar.Enabled = True
        Me.tsbAnular.Enabled = False

        Me.txtCosto.Enabled = True
        Me.txtKilometro.Enabled = True
        Me.txtHora.Enabled = True
        Me.txtLocalidad.Enabled = True
        Me.txtObservacion.Enabled = True
        Me.btnAgregarGE.Enabled = True
        Me.btnEliminarGE.Enabled = False
        Me.dgvGuiaEnvio.Enabled = True
        Me.tsbGrabar.Enabled = True

        If intNivel <> 1 Then
            Me.txtCodigoCliente.Enabled = False
            Me.txtCliente.Enabled = False
            Me.txtCosto.Enabled = False
            Me.txtKilometro.Enabled = False
            Me.txtHora.Enabled = False
            Me.txtLocalidad.Enabled = False
            Me.txtObservacion.Enabled = False
            Me.btnAgregarGE.Enabled = False
            Me.btnEliminarGE.Enabled = False
            Me.dgvGuiaEnvio.Enabled = False
            Me.tsbGrabar.Enabled = False
        End If

        RemoveHandler tabFueraZona.SelectedIndexChanged, AddressOf tabFueraZona_SelectedIndexChanged
        Me.tabFueraZona.SelectedTab = Me.tabFueraZona.TabPages("tabSolicitudZona")
        AddHandler tabFueraZona.SelectedIndexChanged, AddressOf tabFueraZona_SelectedIndexChanged
        Me.txtCliente.Focus()
    End Sub

    Private Sub cboEstadoSolicitud_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstadoSolicitud.SelectedIndexChanged
        ListarSolicitud()
        If Me.dgvListaSolicitud.Rows.Count > 0 Then
            Me.tsbEditar.Enabled = True
            If Me.dgvListaSolicitud.CurrentRow.Cells("idestado").Value = 1 And intNivel = 1 Then
                Me.tsbAnular.Enabled = True
            Else
                Me.tsbAnular.Enabled = False
            End If
        Else
        Me.tsbEditar.Enabled = False
        Me.tsbAnular.Enabled = False
        End If
    End Sub

    Private Sub dgvListaSolicitud_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvListaSolicitud.DoubleClick
        If Me.dgvListaSolicitud.Rows.Count > 0 Then
            tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Sub ListarGuiaEnvio(id As Integer, dgv As DataGridView)
        Dim objLN As New dtoFueraZona
        Dim dt As DataTable = objLN.ListarGuiaEnvio(id)
        With dgv
            .Rows.Clear()
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .Rows.Add()
                    dgv(0, .Rows.Count - 1).Value = row.Item("id")
                    dgv(1, .Rows.Count - 1).Value = Format(row.Item("fecha"), "dd/MM/yyyy")
                    dgv(2, .Rows.Count - 1).Value = row.Item("guia")
                    dgv(3, .Rows.Count - 1).Value = row.Item("origen")
                    dgv(4, .Rows.Count - 1).Value = row.Item("destino")
                    dgv(5, .Rows.Count - 1).Value = row.Item("agencia_origen")
                    dgv(6, .Rows.Count - 1).Value = row.Item("agencia_destino")
                    dgv(7, .Rows.Count - 1).Value = row.Item("total")
                    dgv(8, .Rows.Count - 1).Value = row.Item("cantidad")
                    dgv(9, .Rows.Count - 1).Value = row.Item("peso")
                    dgv(10, .Rows.Count - 1).Value = row.Item("direccion")

                    dgv(11, .Rows.Count - 1).Value = row.Item("idguia")
                    dgv(12, .Rows.Count - 1).Value = row.Item("idagencia_origen")
                    dgv(13, .Rows.Count - 1).Value = row.Item("idagencia_destino")

                    dgv(14, .Rows.Count - 1).Value = row.Item("estado")
                Next
            End If
        End With
    End Sub

    Private Sub dgvGuiaEnvio_RowsAdded(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvGuiaEnvio.RowsAdded
        Me.btnEliminarGE.Enabled = Me.dgvGuiaEnvio.Rows.Count > 0 And Me.btnAgregarGE.Enabled
    End Sub

    Private Sub dgvGuiaEnvio_RowsRemoved(sender As Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvGuiaEnvio.RowsRemoved
        Me.btnEliminarGE.Enabled = Me.dgvGuiaEnvio.Rows.Count > 0
    End Sub

    Private Sub btnEliminarGE_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarGE.Click
        With dgvGuiaEnvio
            If .Rows.Count > 0 Then
                Dim dlgRespuesta As DialogResult = MessageBox.Show("¿Está Seguro de Desactivar la Guía de Envío Seleccionada?", "Desactivar Guía de Envío", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                    If dgvGuiaEnvio.CurrentRow.Cells("estado").Value = 0 Then
                        .Rows.Remove(.CurrentRow)
                    Else
                        dgvGuiaEnvio.CurrentRow.Cells("estado").Value = 2
                        dgvGuiaEnvio.CurrentRow.Visible = False
                    End If
                    If Not dtoUtilitario.FilasGridVisible(Me.dgvGuiaEnvio) Then
                        Me.btnEliminarGE.Enabled = False
                    End If
                    If Me.btnEliminarGE.Enabled Then
                        Dim intFila As Integer = dtoUtilitario.FilaGridVisiblePrimera(Me.dgvGuiaEnvio)
                        .Rows(intFila).Selected = True
                        .CurrentCell = .Rows(intFila).Cells(1)
                    End If
                End If
            End If
        End With
    End Sub

    Sub ControlaOpcion() Handles rbtSeguimiento.CheckedChanged, rbtPorAceptar.CheckedChanged, rbtPorAprobar.CheckedChanged
        If rbtSeguimiento.Checked Then
            Me.pnlEstado.Visible = True
            ActualizaCombo()
            If intNivel = 2 Or intNivel = 3 Then
                Me.cboEstadoSolicitud.SelectedIndex = 1
            End If

            If tabFueraZona.TabPages.IndexOf(tabAceptacion) > -1 Then
                Me.tabFueraZona.TabPages.Remove(tabFueraZona.TabPages("tabAceptacionZona"))
            End If
            If tabFueraZona.TabPages.IndexOf(tabSolicitud) = -1 Then
                Me.tabFueraZona.TabPages.Add(tabSolicitud)
            End If
            If tabFueraZona.TabPages.IndexOf(tabAprobacion) > -1 Then
                Me.tabFueraZona.TabPages.Remove(tabFueraZona.TabPages("tabAprobacionZona"))
            End If
            If intNivel2 = 2 Then
                If tabFueraZona.TabPages.IndexOf(tabFacturar) >= 1 Then
                    Me.tabFueraZona.TabPages.Remove(tabFueraZona.TabPages("tabImpresionZona"))
                End If
                If tabFueraZona.TabPages.IndexOf(tabFacturar) = -1 Then
                    Me.tabFueraZona.TabPages.Add(tabFacturar)
                End If
            End If
        ElseIf rbtPorAceptar.Checked Then
            Me.pnlEstado.Visible = True
            ActualizaCombo(2)

            RemoveHandler cboEstadoSolicitud.SelectedIndexChanged, AddressOf cboEstadoSolicitud_SelectedIndexChanged
            Me.cboEstadoSolicitud.SelectedIndex = 0
            AddHandler cboEstadoSolicitud.SelectedIndexChanged, AddressOf cboEstadoSolicitud_SelectedIndexChanged

            If tabFueraZona.TabPages.IndexOf(tabSolicitud) > -1 Then
                Me.tabFueraZona.TabPages.Remove(tabFueraZona.TabPages("tabSolicitudZona"))
            End If
            If tabFueraZona.TabPages.IndexOf(tabAceptacion) = -1 Then
                Me.tabFueraZona.TabPages.Add(tabAceptacion)
            End If
            If tabFueraZona.TabPages.IndexOf(tabAprobacion) > -1 Then
                Me.tabFueraZona.TabPages.Remove(tabFueraZona.TabPages("tabAprobacionZona"))
            End If
        ElseIf rbtPorAprobar.Checked Then
            Me.pnlEstado.Visible = False
            If tabFueraZona.TabPages.IndexOf(tabSolicitud) > -1 Then
                Me.tabFueraZona.TabPages.Remove(tabFueraZona.TabPages("tabSolicitudZona"))
            End If
            If tabFueraZona.TabPages.IndexOf(tabAprobacion) = -1 Then
                Me.tabFueraZona.TabPages.Add(tabAprobacion)
            End If
            If tabFueraZona.TabPages.IndexOf(tabAceptacion) > -1 Then
                Me.tabFueraZona.TabPages.Remove(tabFueraZona.TabPages("tabAceptacionZona"))
            End If
            If intNivel2 = 2 Then
                If tabFueraZona.TabPages.IndexOf(tabFacturar) >= 1 Then
                    Me.tabFueraZona.TabPages.Remove(tabFueraZona.TabPages("tabImpresionZona"))
                End If
                If tabFueraZona.TabPages.IndexOf(tabFacturar) = -1 Then
                    Me.tabFueraZona.TabPages.Add(tabFacturar)
                End If
            End If
        End If
        ListarSolicitud()
    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub txtPrecioAceptacion_Enter(sender As Object, e As System.EventArgs) Handles txtPrecioAceptacion.Enter
        If Val(txtPrecioAceptacion.Text) > 0 Then
            Me.txtPrecioAceptacion.Text = Replace(Me.txtPrecioAceptacion.Text, ",", "")
        Else
            Me.txtPrecioAceptacion.Text = "0.00"
        End If
    End Sub

    Private Sub txtPrecioAceptacion_GotFocus(sender As Object, e As System.EventArgs) Handles txtPrecioAceptacion.GotFocus
        txtPrecioAceptacion.SelectAll()
    End Sub

    Private Sub txtPrecioAceptacion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecioAceptacion.KeyPress
        If Not ValidarNumeroReal(e.KeyChar, Me.txtPrecioAceptacion.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrecioAceptacion_LostFocus(sender As Object, e As System.EventArgs) Handles txtPrecioAceptacion.LostFocus
        If Val(Me.txtPrecioAceptacion.Text) > 0 Then
            Dim dblMonto As Double
            dblMonto = CDbl(Me.txtPrecioAceptacion.Text)
            Me.txtPrecioAceptacion.Text = Format(dblMonto, "#,###,###0.00")
        Else
            Me.txtPrecioAceptacion.Text = "0.00"
        End If
    End Sub

    Private Sub btnAceptarAceptacion_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptarAceptacion.Click
        If Val(Me.txtPrecioAceptacion.Text) = 0 Then
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("El Precio es 0" & Chr(13) & Chr(13) & "¿Está seguro de Continuar?", "Aceptar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.No Then
                Me.txtPrecioAceptacion.Focus()
                Return
            End If
        End If

        If Me.cboContactoAceptacion.SelectedValue = 0 Then
            MessageBox.Show("Seleccione el Contacto", "Aceptar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboContactoAceptacion.Focus()
            Me.cboContactoAceptacion.DroppedDown = True
            Return
        End If

        If Me.rbtNoAceptacion.Checked AndAlso Me.txtObservacionAceptacion.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese el Motivo", "Aceptar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtObservacionAceptacion.Text = ""
            Me.txtObservacionAceptacion.Focus()
            Return
        End If

        Aceptar()
    End Sub

    Sub LimpiarAceptacion()
        Me.lblCodigoAceptacion.Text = ""
        Me.lblRazonSocialAceptacion.Text = ""
        Me.lblOficinaAceptacion.Text = ""
        Me.lblSolicitanteAceptacion.Text = ""
        Me.lblLocalidadAceptacion.Text = ""
        Me.lblKmAceptacion.Text = ""
        Me.lblHoraAceptacion.Text = ""
        Me.lblObservacionAceptacion.Text = ""
        Me.dgvGuiaEnvioAceptacion.Rows.Clear()
        Me.lblCostoAceptacion.Text = ""
        Me.txtPrecioAceptacion.Text = ""
        Me.cboContactoAceptacion.DataSource = Nothing
        Me.rbtSiAceptacion.Checked = True
        Me.txtObservacionAceptacion.Text = ""
    End Sub

    Private Sub tsbEditar_Click(sender As System.Object, e As System.EventArgs) Handles tsbEditar.Click
        If tabFueraZona.TabPages.IndexOf(tabSolicitud) > -1 Then
            intOperacion = Operacion.Modificar
            MostrarSolicitud(dgvListaSolicitud.CurrentCell.RowIndex)

            Dim intID As Integer = Me.dgvListaSolicitud.CurrentRow.Cells("id").Value
            ListarGuiaEnvio(intID, Me.dgvGuiaEnvio)

            Me.txtCodigoCliente.Enabled = False
            Me.txtCliente.Enabled = False

            Me.tabFueraZona.SelectedTab = Me.tabFueraZona.TabPages("tabSolicitudZona")
            Me.txtCosto.Focus()
        ElseIf tabFueraZona.TabPages.IndexOf(tabAceptacion) > -1 Then
            Me.tabFueraZona.SelectedTab = Me.tabFueraZona.TabPages("tabAceptacionZona")
        ElseIf tabFueraZona.TabPages.IndexOf(tabAprobacion) > -1 Then
            Me.tabFueraZona.SelectedTab = Me.tabFueraZona.TabPages("tabAprobacionZona")
        End If
    End Sub

    Private Sub tabFueraZona_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabFueraZona.SelectedIndexChanged
        Me.tsbImprimir.Enabled = False
        If tabFueraZona.SelectedTab Is tabFueraZona.TabPages("tabListaZona") Then
            If intNivel = 1 Then
                Me.tsbNuevo.Enabled = True
            Else
                Me.tsbNuevo.Enabled = False
            End If
            Me.tsbGrabar.Enabled = False
            If Me.dgvListaSolicitud.Rows.Count > 0 Then
                Me.tsbEditar.Enabled = True
                If Me.dgvListaSolicitud.CurrentRow.Cells("idestado").Value = 1 And intNivel = 1 Then
                    Me.tsbAnular.Enabled = True
                Else
                    Me.tsbAnular.Enabled = False
                End If
            Else
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            End If
            ConfigurarDGVGuiaEnvio()

        ElseIf tabFueraZona.SelectedTab Is tabFueraZona.TabPages("tabSolicitudZona") Then
            LimpiarSolicitud()
            Me.tsbNuevo.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
            If Me.dgvListaSolicitud.Rows.Count > 0 Then
                tsbEditar_Click(Nothing, Nothing)
            Else
                tsbNuevo_Click(Nothing, Nothing)
                'Me.tsbGrabar.Enabled = False
            End If

        ElseIf tabFueraZona.SelectedTab Is tabFueraZona.TabPages("tabImpresionZona") Then
            Me.tsbNuevo.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
            Me.tsbGrabar.Enabled = False
            ConfigurarDGVResultado()
            Me.dtpInicioImprimir.Value = "01/" & dtpInicioImprimir.Value.Month.ToString.PadLeft(2, "0") & "/" & dtpInicioImprimir.Value.Year
            Me.dtpInicioLista.Value = "01/" & dtpInicioLista.Value.Month.ToString.PadLeft(2, "0") & "/" & dtpInicioLista.Value.Year
            Me.dtpFinLista.Value = Now
            Me.cboEstadoFacturacion.SelectedIndex = 1

            If intNivel <> 3 Then
                Me.lblProveedor.Visible = False
                Me.cboProveedor.Visible = False
            End If

        ElseIf tabFueraZona.SelectedTab Is tabFueraZona.TabPages("tabaceptacionzona") Then
            LimpiarAceptacion()
            Me.tsbGrabar.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
            ConfigurarDGVGuiaEnvioAceptacion()
            If Me.dgvListaSolicitud.Rows.Count > 0 Then
                Dim intEstado As Integer = Me.dgvListaSolicitud.CurrentRow.Cells("idestado").Value
                If intEstado = 1 Then
                    Me.txtPrecioAceptacion.Enabled = True
                Else
                    Me.txtPrecioAceptacion.Enabled = False
                End If
                Me.cboContactoAceptacion.Enabled = True
                Me.rbtSiAceptacion.Enabled = True
                Me.rbtNoAceptacion.Enabled = True
                Me.txtObservacionAceptacion.Enabled = True
                Me.btnAceptarAceptacion.Enabled = True
                Me.grbGuiaEnvioAceptacion.Enabled = True

                Dim intCliente As Integer = dgvListaSolicitud.CurrentRow.Cells("idcliente").Value
                LlenarCombo(intCliente)

                Me.lblCodigoAceptacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("codigo").Value
                Me.lblRazonSocialAceptacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("cliente").Value
                Me.lblOficinaAceptacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("oficina").Value
                Me.lblSolicitanteAceptacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("solicitante").Value

                Me.lblLocalidadAceptacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("localidad").Value
                Me.lblKmAceptacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("km").Value
                Me.lblHoraAceptacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("hora").Value

                If IsDBNull(Me.dgvListaSolicitud.CurrentRow.Cells("observacion_observacion").Value) Then
                    Me.lblObservacionAceptacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("observacion").Value
                Else
                    Me.lblObservacionAceptacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("observacion_observacion").Value
                End If

                Me.lblCostoAceptacion.Text = Format(CDbl(Me.dgvListaSolicitud.CurrentRow.Cells("costo").Value), "###,###,###0.00")

                If intEstado = 1 Then
                    Me.txtPrecioAceptacion.Text = Format(CDbl(Me.lblCostoAceptacion.Text) * 2, "###,###,###0.00")
                Else
                    Me.txtPrecioAceptacion.Text = Format(Me.dgvListaSolicitud.CurrentRow.Cells("precio_observacion").Value, "###,###,###0.00")
                End If

                Dim intID As Integer = Me.dgvListaSolicitud.CurrentRow.Cells("id").Value
                ListarGuiaEnvio(intID, Me.dgvGuiaEnvioAceptacion)

                Me.cboContactoAceptacion.Focus()
                Me.txtPrecioAceptacion.Focus()
            Else
                Me.txtPrecioAceptacion.Enabled = False
                Me.cboContactoAceptacion.Enabled = False
                Me.rbtSiAceptacion.Enabled = False
                Me.rbtNoAceptacion.Enabled = False
                Me.txtObservacionAceptacion.Enabled = False
                Me.btnAceptarAceptacion.Enabled = False
                Me.grbGuiaEnvioAceptacion.Enabled = False
            End If

        ElseIf tabFueraZona.SelectedTab Is tabFueraZona.TabPages("tabaprobacionzona") Then
            LimpiarAprobacion()
            Me.tsbGrabar.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
            ConfigurarDGVGuiaEnvioAprobacion()
            If Me.dgvListaSolicitud.Rows.Count > 0 Then
                Me.rbtSiAprobacion.Enabled = True
                Me.rbtNoAprobacion.Enabled = True
                Me.txtObservacionAprobacion.Enabled = True
                Me.btnAceptarAprobacion.Enabled = True
                Me.grbGuiaEnvioAprobacion.Enabled = True

                Me.lblCodigoAprobacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("codigo").Value
                Me.lblRazonSocialAprobacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("cliente").Value
                Me.lblContactoAprobacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("contacto").Value

                Me.lblOficinaAprobacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("oficina").Value
                Me.lblSolicitanteAprobacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("solicitante").Value
                Me.lblFuncionarioAprobacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("funcionario").Value

                Me.lblLocalidadAprobacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("localidad").Value
                Me.lblKmAprobacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("km").Value
                Me.lblHoraAprobacion.Text = Me.dgvListaSolicitud.CurrentRow.Cells("hora").Value

                Me.lblCostoAprobacion.Text = Format(CDbl(Me.dgvListaSolicitud.CurrentRow.Cells("costo").Value), "###,###,###0.00")
                Me.lblPrecioAceptadoAprobacion.Text = Format(CDbl(Me.dgvListaSolicitud.CurrentRow.Cells("total").Value), "###,###,###0.00")
                Me.txtPrecioAprobacion.Text = Format(CDbl(Me.dgvListaSolicitud.CurrentRow.Cells("total").Value), "###,###,###0.00")

                Dim intID As Integer = Me.dgvListaSolicitud.CurrentRow.Cells("id").Value
                ListarGuiaEnvio(intID, Me.dgvGuiaEnvioAprobacion)

                Me.btnAceptarAprobacion.Focus()
            Else
                Me.rbtSiAprobacion.Enabled = False
                Me.rbtNoAprobacion.Enabled = False
                Me.txtObservacionAprobacion.Enabled = False
                Me.btnAceptarAprobacion.Enabled = False
                Me.grbGuiaEnvioAprobacion.Enabled = False
            End If
        End If
    End Sub

    Private Sub AceptarSolicitud(estado As Integer)
        Cursor = Cursors.WaitCursor
        Try
            Dim objLN As New dtoFueraZona
            Dim intID As Integer = Me.dgvListaSolicitud.CurrentRow.Cells("id").Value
            Dim dblPrecio As Double, strObservacion As String, intContacto As Integer
            If estado = 2 Or estado = 3 Then
                dblPrecio = CDbl(Me.txtPrecioAceptacion.Text)
                intContacto = Me.cboContactoAceptacion.SelectedValue
                strObservacion = ""
            Else
                strObservacion = Me.txtObservacionAceptacion.Text.Trim
                dblPrecio = 0
                intContacto = 0
            End If
            objLN.AceptarSolicitud(intID, estado, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dblPrecio, strObservacion, intContacto)

        Catch ex As Exception
            Cursor = Cursors.Default
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub LimpiarSolicitud()
        Me.lblNumeroSolicitud.Text = ""
        Me.lblFecha.Text = Format(FechaServidor, "Short Date")
        Me.lblOficina.Text = dtoUSUARIOS.m_iNombreAgencia
        Me.lblSolicitante.Text = ""
        Me.txtCodigoCliente.Text = ""
        Me.txtCliente.Text = ""
        Me.txtCosto.Text = ""
        Me.txtKilometro.Text = ""
        Me.txtHora.Text = ""
        Me.txtLocalidad.Text = ""
        Me.txtObservacion.Text = ""
        Me.dgvGuiaEnvio.Rows.Clear()
    End Sub

    Sub Aceptar()
        Try
            If Me.rbtSiAceptacion.Checked Then 'acepta
                Dim strMensaje As String = "¿Está Seguro de Aceptar la Solicitud?"
                Dim intRespuesta As DialogResult = MessageBox.Show(strMensaje, "Aceptar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If intRespuesta = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Dim intEstado As Integer = IIf(Me.dgvListaSolicitud.CurrentRow.Cells("idestado").Value = 1, 2, 3)
                    AceptarSolicitud(intEstado)
                    If intEstado = 2 Then
                        MessageBox.Show("Solicitud Aceptada", "Aceptar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Solicitud Aprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    Me.ListarSolicitud()
                    tabFueraZona.SelectedTab = tabFueraZona.TabPages("tabListaZona")
                    Cursor = Cursors.Default
                End If
            Else 'no acepta
                If MessageBox.Show("¿Está Seguro de No Aceptar la Solicitud?", "Aceptar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    AceptarSolicitud(5)
                    MessageBox.Show("Solicitud no Aceptada", "Aceptar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitud()
                    tabFueraZona.SelectedTab = tabFueraZona.TabPages("tabListaZona")
                    Cursor = Cursors.Default
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Aceptar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtSiAprobacion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtSiAprobacion.CheckedChanged
        Me.txtPrecioAprobacion.Text = Me.lblPrecioAceptadoAprobacion.Text
        Me.txtPrecioAprobacion.Enabled = False
        Me.txtObservacionAprobacion.Text = ""
        Me.txtObservacionAprobacion.Enabled = False
        Me.btnAceptarAprobacion.Focus()
    End Sub

    Private Sub rbtNoAprobacion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtNoAprobacion.CheckedChanged
        Me.txtPrecioAprobacion.Text = ""
        Me.txtPrecioAprobacion.Enabled = False
        Me.txtObservacionAprobacion.Text = ""
        Me.txtObservacionAprobacion.Enabled = True
        Me.txtObservacionAprobacion.Focus()
    End Sub

    Private Sub rbtPrecioAceptacion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtPrecioAceptacion.CheckedChanged
        Me.txtPrecioAprobacion.Enabled = True
        Me.txtPrecioAprobacion.Text = Me.lblPrecioAceptadoAprobacion.Text
        Me.txtObservacionAprobacion.Text = ""
        Me.txtObservacionAprobacion.Enabled = True
        Me.txtPrecioAprobacion.Focus()
    End Sub

    Private Sub txtObservacion_Enter(sender As Object, e As System.EventArgs) Handles txtObservacion.Enter
        txtObservacion.SelectAll()
    End Sub

    Private Sub txtObservacionAceptacion_Enter(sender As Object, e As System.EventArgs) Handles txtObservacionAceptacion.Enter
        txtObservacionAceptacion.SelectAll()
    End Sub

    Sub LimpiarAprobacion()
        Me.lblCodigoAprobacion.Text = ""
        Me.lblRazonSocialAprobacion.Text = ""
        Me.lblOficinaAprobacion.Text = ""
        Me.lblSolicitanteAprobacion.Text = ""
        Me.dgvGuiaEnvioAprobacion.Rows.Clear()
        Me.lblLocalidadAprobacion.Text = ""
        Me.lblKmAprobacion.Text = ""
        Me.lblHoraAprobacion.Text = ""
        Me.lblCostoAprobacion.Text = ""
        Me.txtPrecioAprobacion.Text = ""
        Me.lblContactoAprobacion.Text = ""
        Me.lblFuncionarioAprobacion.Text = ""
        Me.lblPrecioAceptadoAprobacion.Text = ""
        Me.rbtSiAprobacion.Checked = True
        Me.txtObservacionAprobacion.Text = ""
    End Sub

    Private Sub btnAceptarAprobacion_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptarAprobacion.Click
        If Not Me.rbtNoAprobacion.Checked Then
            If Val(Me.txtPrecioAprobacion.Text) = 0 Then
                Dim dlgRespuesta As DialogResult
                dlgRespuesta = MessageBox.Show("El Precio es 0" & Chr(13) & Chr(13) & "¿Está seguro de Continuar?", "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.No Then
                    Me.rbtPrecioAceptacion.Checked = True
                    Me.txtPrecioAceptacion.Enabled = True
                    Me.txtPrecioAceptacion.Focus()
                    Return
                End If
            End If
            If Me.rbtPrecioAceptacion.Checked Then
                If CDbl(Me.txtPrecioAprobacion.Text) = CDbl(Me.lblPrecioAceptadoAprobacion.Text) Then
                    MessageBox.Show("El Precio Modificado debe ser diferente al Precio Aceptado", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtPrecioAprobacion.Focus()
                    Return
                End If
            End If
        ElseIf Me.rbtNoAprobacion.Checked AndAlso Me.txtObservacionAprobacion.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese el Motivo", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtObservacionAprobacion.Text = ""
            Me.txtObservacionAprobacion.Focus()
            Return
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
                    AprobarSolicitud(4)
                    MessageBox.Show("Solicitud Aprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitud()
                    tabFueraZona.SelectedTab = tabFueraZona.TabPages("tabListaZona")
                    Cursor = Cursors.Default
                End If
            ElseIf Me.rbtNoAprobacion.Checked Then 'no aprueba
                If MessageBox.Show("¿Está Seguro de Desaprobar la Solicitud?", "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    AprobarSolicitud(6)
                    MessageBox.Show("Solicitud Desaprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitud()
                    tabFueraZona.SelectedTab = tabFueraZona.TabPages("tabListaZona")
                    Cursor = Cursors.Default
                End If
            Else 'solicitud observada con precio modificado
                Dim strMensaje As String = "¿Está Seguro de Modificar el Precio Aceptado por el Cliente?"
                Dim intRespuesta As DialogResult = MessageBox.Show(strMensaje, "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If intRespuesta = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    AprobarSolicitud(3)
                    MessageBox.Show("Solicitud Actualizada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitud()
                    tabFueraZona.SelectedTab = tabFueraZona.TabPages("tabListaZona")
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
            Dim objLN As New dtoFueraZona
            Dim intID As Integer = Me.dgvListaSolicitud.CurrentRow.Cells("id").Value
            Dim dblPrecio As Double, strObservacion As String
            If estado = 4 Then
                dblPrecio = CDbl(Me.txtPrecioAprobacion.Text)
                strObservacion = ""
            ElseIf estado = 6 Then
                strObservacion = Me.txtObservacionAprobacion.Text.Trim
                dblPrecio = 0
            Else 'estado=3
                dblPrecio = CDbl(Me.txtPrecioAprobacion.Text)
                If Me.txtObservacionAprobacion.Text.Trim.Length > 0 Then
                    strObservacion = Me.txtObservacionAprobacion.Text.Trim
                Else
                    txtObservacion.Text = ""
                End If
            End If
            objLN.AprobarSolicitud(intID, estado, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dblPrecio, strObservacion)

        Catch ex As Exception
            Cursor = Cursors.Default
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub tsbAnular_Click(sender As System.Object, e As System.EventArgs) Handles tsbAnular.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está Seguro de Anular la Solicitud Nº " & dgvListaSolicitud.CurrentRow.Cells("numero_solicitud").Value & "?", "Anular Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = vbYes Then
            Anular()
            ListarSolicitud()
            'If Me.dgvListaSolicitud.Rows.Count > 0 Then
            'Me.btnModificarZona.Enabled = dgvSolicitudZona.Rows(Me.dgvSolicitudZona.CurrentCell.RowIndex).Cells("idestado").Value = 1
            'Me.btnAnularZona.Enabled = dgvSolicitudZona.Rows(Me.dgvSolicitudZona.CurrentCell.RowIndex).Cells("idestado").Value = 1
            'End If
        End If
    End Sub

    Sub Anular()
        Try
            Dim objLN As New dtoFueraZona

            Dim intID As Integer = dgvListaSolicitud.CurrentRow.Cells("id").Value
            objLN.AnularSolicitud(intID, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub dgvListaSolicitud_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaSolicitud.RowEnter
        If Me.dgvListaSolicitud.Rows.Count > 0 Then
            If Me.dgvListaSolicitud.Rows(e.RowIndex).Cells("idestado").Value = 1 And intNivel = 1 Then
                Me.tsbAnular.Enabled = True
            Else
                Me.tsbAnular.Enabled = False
            End If
        End If
    End Sub

    Sub ActualizaCombo(Optional opcion As Integer = 1)
        Me.cboEstadoSolicitud.Items.Clear()
        If opcion = 1 Then
            Me.cboEstadoSolicitud.Items.Add("(TODOS)")
            Me.cboEstadoSolicitud.Items.Add("PENDIENTE")
            Me.cboEstadoSolicitud.Items.Add("ACEPTADO")
            Me.cboEstadoSolicitud.Items.Add("OBSERVADO")
            Me.cboEstadoSolicitud.Items.Add("APROBADO")
            Me.cboEstadoSolicitud.Items.Add("NO ACEPTADO")
            Me.cboEstadoSolicitud.Items.Add("DESAPROBADO")
            Me.cboEstadoSolicitud.Items.Add("ANULADO")
        Else
            Me.cboEstadoSolicitud.Items.Add("(TODOS)")
            Me.cboEstadoSolicitud.Items.Add("PENDIENTE")
            Me.cboEstadoSolicitud.Items.Add("OBSERVADO")
        End If
    End Sub

    Private Sub dtpInicio_ValueChanged(sender As System.Object, e As System.EventArgs)
        Me.dgvResultado.DataSource = Nothing
    End Sub

    Private Sub dtpFin_ValueChanged(sender As Object, e As System.EventArgs)
        Me.dgvResultado.DataSource = Nothing
    End Sub

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltrar.Click
        Try
            Cursor = Cursors.AppStarting
            Dim intEstado As Integer = -1
            If Me.cboEstadoFacturacion.SelectedIndex > 0 Then
                intEstado = IIf(Me.cboEstadoFacturacion.SelectedIndex = 1, 0, 1)
            End If

            Dim obj As New dtoFueraZona
            Dim dt As DataTable = obj.ListarFueraZonaAprobados(dtoUSUARIOS.iIDAGENCIAS, Me.dtpInicioLista.Value.ToShortDateString, Me.dtpFinLista.Value.ToShortDateString, intEstado)
            dgvResultado.DataSource = dt
            CalcularTotal()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCliente.TextChanged
        Me.dgvGuiaEnvio.Rows.Clear()
    End Sub

    Private Sub txtCodigoCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCodigoCliente.TextChanged
        Me.dgvGuiaEnvio.Rows.Clear()
    End Sub

    Private Sub dgvResultado_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvResultado.CellContentClick
        If e.ColumnIndex <> 0 Then Return
        CalcularTotal()
    End Sub

    Private Sub dgvResultado_CellMouseUp(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvResultado.CellMouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim strEstado As String = Me.dgvResultado.CurrentRow.Cells("estado").Value.ToString.Substring(0, 1)
            If strEstado = "F" Then
                Me.dgvResultado.CurrentRow.Cells(0).Value = 0
                dgvResultado.RefreshEdit()
                CalcularTotal()
                Return
            End If
        End If
    End Sub

    Private Sub dgvResultado_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles dgvResultado.CurrentCellDirtyStateChanged
        dgvResultado.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Sub SeleccionarCheckDgv(ByVal dgv As DataGridView, ByVal col As Integer, ByVal estado As Integer)
        Dim strEstado As String
        For Each row As DataGridViewRow In dgv.Rows
            If estado = 1 Then
                strEstado = row.Cells("estado").Value.ToString.Substring(0, 1)
                If strEstado <> "F" Then
                    row.Cells(col).Value = estado
                End If
            Else
                row.Cells(col).Value = estado
            End If
        Next
    End Sub

    Private Sub btnSeleccionarTodo_Click(sender As System.Object, e As System.EventArgs) Handles btnSeleccionarTodo.Click
        SeleccionarCheckDgv(Me.dgvResultado, 0, 1)
        CalcularTotal()
    End Sub

    Private Sub btnEliminarSeleccion_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarSeleccion.Click
        SeleccionarCheckDgv(Me.dgvResultado, 0, 0)
        CalcularTotal()
    End Sub

    Sub CargarPendientesFacturar()
        With dgvResultado
            Dim dblSubtotal_1 As Double = 0, dblImpuesto_1 As Double = 0, dblTotal_1 As Double = 0
            For Each row As DataGridViewRow In .Rows
                If row.Cells(0).Value = 1 Then
                    With dgvFactura
                        .Rows.Add()
                        .Rows(.Rows.Count - 1).Cells("id").Value = row.Cells("id").Value
                        .Rows(.Rows.Count - 1).Cells("numero").Value = row.Cells("numero").Value
                        .Rows(.Rows.Count - 1).Cells("cliente").Value = row.Cells("cliente").Value
                        .Rows(.Rows.Count - 1).Cells("agencia").Value = row.Cells("agencia").Value

                        Dim dblSubtotal As Double = row.Cells("subtotal").Value
                        Dim dblTotal As Double = dblSubtotal * (1 + (dtoUSUARIOS.iIGV / 100))
                        Dim dblImpuesto As Double = dblTotal - dblSubtotal
                        dblSubtotal_1 += dblSubtotal
                        dblImpuesto_1 += dblImpuesto
                        dblTotal_1 += dblTotal

                        .Rows(.Rows.Count - 1).Cells("subtotal").Value = Format(dblSubtotal, "###,###,###0.00")
                        .Rows(.Rows.Count - 1).Cells("impuesto").Value = Format(dblImpuesto, "###,###,###0.00")
                        .Rows(.Rows.Count - 1).Cells("total").Value = Format(dblTotal, "###,###,###0.00")
                    End With
                End If
            Next
            'Totales
            Me.lblSubtotal.Text = Format(dblSubtotal_1, "###,###,###0.00")
            Me.lblImpuesto.Text = Format(dblImpuesto_1, "###,###,###0.00")
            Me.lblTotal.Text = Format(dblTotal_1, "###,###,###0.00")
        End With
    End Sub

    Private Sub tabFacturacion_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabFacturacion.SelectedIndexChanged
        If tabFacturacion.SelectedTab Is tabFacturacion.TabPages("tabFactura") Then
            ConfigurarDGVFactura()
            CargarPendientesFacturar()
            Me.txtRuc.Focus()
        ElseIf tabFacturacion.SelectedTab Is tabFacturacion.TabPages("tabImprimirFactura") Then
            ConfigurarDGVImprimir()
            ConfigurarDGVDetalle()
            If Me.dgvImprimir.Rows.Count > 0 Then
                Me.btnImprimir.Enabled = True
            Else
                Me.btnImprimir.Enabled = False
            End If
        ElseIf tabFacturacion.SelectedTab Is tabFacturacion.TabPages("tabListaFactura") Then
            CalcularTotal()
        End If
    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If Not fnValidarRUC(txtRuc.Text) Then
            MessageBox.Show("El RUC no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRuc.Focus()
            Return
        End If

        If Me.txtRazonSocial.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Razón Social", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRazonSocial.Text = ""
            txtRazonSocial.Focus()
            Return
        End If

        If Me.txtSerieFactura.Text.Trim.Length <= 2 Then
            MessageBox.Show("Nº de Serie no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtSerieFactura.Text = ""
            txtSerieFactura.Focus()
            Return
        End If

        If Me.txtNumeroFactura.Text.Trim.Length = 0 Then
            MessageBox.Show("Nº de Factura no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNumeroFactura.Text = ""
            txtNumeroFactura.Focus()
            Return
        End If

        If Me.dgvFactura.Rows.Count = 0 Then
            MessageBox.Show("Nº de Factura no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        GrabarFactura()
    End Sub

    Private Sub txtRuc_Enter(sender As Object, e As System.EventArgs) Handles txtRuc.Enter
        txtRuc.SelectAll()
    End Sub

    Private Sub txtRazonSocial_Enter(sender As Object, e As System.EventArgs) Handles txtRazonSocial.Enter
        txtRazonSocial.SelectAll()
    End Sub

    Private Sub txtSerieFactura_Enter(sender As Object, e As System.EventArgs) Handles txtSerieFactura.Enter
        txtSerieFactura.SelectAll()
    End Sub

    Private Sub txtNumeroFactura_Enter(sender As Object, e As System.EventArgs) Handles txtNumeroFactura.Enter
        txtNumeroFactura.SelectAll()
    End Sub

    Private Sub txtRuc_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRuc.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNumeroFactura_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroFactura.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtSerieFactura_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerieFactura.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRazonSocial_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRazonSocial.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub dtpFechaFactura_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaFactura.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        ElseIf Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Sub GrabarFactura()
        Try
            Cursor = Cursors.AppStarting
            Dim obj As New dtoFueraZona
            With Me.dgvFactura
                Dim intId As Integer = 0
                For Each row As DataGridViewRow In .Rows
                    intId = obj.GrabarFactura(Me.dtpFechaFactura.Value.ToShortDateString, Me.txtSerieFactura.Text, Me.txtNumeroFactura.Text, Me.txtRuc.Text.Trim, _
                                      Me.txtRazonSocial.Text.Trim, row.Cells("agencia").Value, Me.lblSubtotal.Text, Me.lblImpuesto.Text, Me.lblTotal.Text, _
                                      intId, row.Cells("id").Value, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                Next
            End With
            Cursor = Cursors.Default
            MessageBox.Show("Factura Actualizada", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtRuc.Text = ""
            Me.txtRazonSocial.Text = ""
            Me.txtSerieFactura.Text = ""
            Me.txtNumeroFactura.Text = ""
            Me.dtpFechaFactura.Value = Now
            Me.dgvFactura.Rows.Clear()
            Me.lblSubtotal.Text = "0.00"
            Me.lblImpuesto.Text = "0.00"
            Me.lblTotal.Text = "0.00"
            Me.cboEstadoFacturacion.SelectedIndex = 1
            Me.btnActualizar_Click(Nothing, Nothing)
            tabFacturacion.SelectedTab = tabFacturacion.TabPages("tabImprimirFactura")
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.ToString, "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CalcularTotal()
        Dim dblSubtotal As Double = 0, dblImpuesto As Double = 0, dblTotal As Double = 0
        With dgvResultado
            For Each row As DataGridViewRow In .Rows
                If row.Cells(0).Value = 1 Then
                    dblSubtotal += row.Cells("subtotal").Value
                    dblImpuesto += row.Cells("impuesto").Value
                    dblTotal += row.Cells("total").Value
                End If
            Next
        End With
        Me.lblSubtotalLista.Text = Format(dblSubtotal, "###,###,###0.00")
        Me.lblImpuestoLista.Text = Format(dblImpuesto, "###,###,###0.00")
        Me.lblTotalLista.Text = Format(dblTotal, "###,###,###0.00")
    End Sub

    Private Sub cboEstadoFacturacion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstadoFacturacion.SelectedIndexChanged
        btnActualizar_Click(Nothing, Nothing)
    End Sub

    Private Sub dtpInicioLista_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpInicioLista.ValueChanged
        btnActualizar_Click(Nothing, Nothing)
    End Sub

    Private Sub dtpFinLista_ValueChanged(sender As Object, e As System.EventArgs) Handles dtpFinLista.ValueChanged
        btnActualizar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnFiltrarImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnFiltrarImprimir.Click
        Try
            Cursor = Cursors.AppStarting
            Dim dt As DataTable
            Dim obj As New dtoFueraZona
            If intNivel <> 3 Then
                dt = obj.ListarFactura(dtoUSUARIOS.iIDAGENCIAS, Me.dtpInicioImprimir.Value.ToShortDateString, Me.dtpFinImprimir.Value.ToShortDateString)
            Else
                Dim strRuc As String = Me.cboProveedor.SelectedValue
                dt = obj.ListarFactura(Me.dtpInicioImprimir.Value.ToShortDateString, Me.dtpFinImprimir.Value.ToShortDateString, strRuc)
            End If
            dgvImprimir.DataSource = dt
            If Me.dgvImprimir.Rows.Count > 0 Then
                Me.btnImprimir.Enabled = True
            Else
                dgvDetalle.DataSource = Nothing
                Me.btnImprimir.Enabled = False
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarProveedor(inicio As String, fin As String)
        Dim obj As New dtoFueraZona
        Dim dt As DataTable = obj.ListarProveedor(inicio, fin)
        With Me.cboProveedor
            .DisplayMember = "proveedor"
            .ValueMember = "ruc"
            .DataSource = dt
            .SelectedValue = 0
        End With
    End Sub

    Private Sub dtpInicioImprimir_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpInicioImprimir.ValueChanged
        If Me.cboProveedor.Visible Then
            ListarProveedor(Me.dtpInicioImprimir.Value.ToShortDateString, Me.dtpFinImprimir.Value.ToShortDateString)
        End If
        btnFiltrarImprimir_Click(Nothing, Nothing)
    End Sub

    Private Sub dtpFinImprimir_ValueChanged(sender As Object, e As System.EventArgs) Handles dtpFinImprimir.ValueChanged
        If Me.cboProveedor.Visible Then
            ListarProveedor(Me.dtpInicioImprimir.Value.ToShortDateString, Me.dtpFinImprimir.Value.ToShortDateString)
        End If
        btnFiltrarImprimir_Click(Nothing, Nothing)
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        Dim obj As New Imprimir
        Try
            Dim dblSubtotal As Double = 0, dblImpuesto As Double = 0, dblTotal As Double = 0
            Dim intID As Integer = Me.dgvImprimir.CurrentRow.Cells("id").Value

            Dim obj1 As New dtoFueraZona
            Dim dt As DataTable = obj1.ListarFactura(intID)

            Dim sImpresora As String
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0, iFila As Integer = 0
            Dim iLong As Long = 0

            obj.Inicializar()

            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim dt2 As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 37)
            If dt2.Rows.Count = 0 Then
                sImpresora = ""
            Else
                If IsDBNull(dt2.Rows(0).Item("impresora")) Then
                    sImpresora = ""
                Else
                    sImpresora = dt2.Rows(0).Item("impresora")
                    iTamaño = dt2.Rows(0).Item("tamano")
                    iSuperior = dt2.Rows(0).Item("superior")
                    Iizquierda = dt2.Rows(0).Item("izquierda")
                End If
            End If
            obj.Superior = iSuperior
            obj.Izquierda = Iizquierda

            obj.Impresora = sImpresora
            Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
            iLong = IIf(iTamaño = 0, 71, iTamaño)

            y = 2
            obj.EscribirLinea(y, 40, "SUSTENTO DE FACTURA")
            y = 5
            obj.EscribirLinea(y, 10, "OFICINA") ': obj.EscribirLinea(y, 50, "Nº LIQUIDACION")
            y = 6
            obj.EscribirLinea(y, 10, "PROVEEDOR")
            y = 7
            obj.EscribirLinea(y, 10, "FECHA") : obj.EscribirLinea(y, 40, "FACTURA")

            y = 12
            obj.EscribirLinea(y, 10, "Nº SOLICITUD") : obj.EscribirLinea(y, 30, "FECHA APROB.") : obj.EscribirLinea(y, 45, "CLIENTE") : obj.EscribirLinea(y, 70, "COSTO ENVIO")
            For Each row As DataRow In dt.Rows
                iFila += 1
                If iFila = 1 Then
                    obj.EscribirLinea(5, 22, row("agencia").ToString) : obj.EscribirLinea(6, 22, row("ruc").ToString) : obj.EscribirLinea(6, 35, row("razon_social").ToString)
                    'obj.EscribirLinea(5, 80, row("liquidacion").ToString)
                    obj.EscribirLinea(7, 22, row("fecha").ToString)
                    obj.EscribirLinea(7, 60, row("factura").ToString)
                End If
                obj.EscribirLinea(y + iFila, 12, row("numero_solicitud").ToString.Trim.PadRight(5, " ").Substring(0, 5))
                obj.EscribirLinea(y + iFila, 30, row("fecha").ToString.Trim.PadRight(10, " ").Substring(0, 10))
                obj.EscribirLinea(y + iFila, 45, row("cliente").ToString.Trim.PadRight(40, " ").Substring(0, 40))
                obj.EscribirLinea(y + iFila, 72, Format(row("costo"), "####,###,###0.00").PadLeft(8, " "))

                dblSubtotal = row("subtotal") : dblImpuesto = row("impuesto") : dblTotal = row("total")
            Next
            y = y + iFila + 2
            obj.EscribirLinea(y + 2, 60, "SUBTOTAL") : obj.EscribirLinea(y + 3, 60, "IMPUESTO") : obj.EscribirLinea(y + 4, 60, "TOTAL")
            obj.EscribirLinea(y + 2, 75, Format(dblSubtotal, "###,###,###0.00").PadLeft(10, " "))
            obj.EscribirLinea(y + 3, 75, Format(dblImpuesto, "###,###,###0.00").PadLeft(10, " "))
            obj.EscribirLinea(y + 4, 75, Format(dblTotal, "###,###,###0.00").PadLeft(10, " "))

            obj.Comprimido = True
            obj.Preliminar = True
            obj.Tamaño = iLong
            obj.Imprimir()
            obj.Finalizar()

            Dim frm As New FrmPreview
            frm.Documento = 37
            frm.Tamaño = 66
            frm.Text = "Sustento Factura"
            frm.ShowDialog()
        Catch ex As Exception
            obj.Finalizar()
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try


        'Dim ObjReport As ClsLbTepsa.dtoFrmReport '
        'Try
        '    Try
        '        ObjReport.Dispose()
        '    Catch
        '    End Try
        '    Dim intID As Integer = Me.dgvImprimir.CurrentRow.Cells("id").Value

        '    ObjReport = New ClsLbTepsa.dtoFrmReport
        '    ObjReport.rutaRpt = PathFrmReport
        '    ObjReport.conectar(rptservice, rptuser, rptpass) ' ("tepsa", "titan", "titan")
        '    ObjReport.printrptB(False, "", "rptFacturaFueraZona.rpt", _
        '    "NI_ID;" & intID)

        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        'End Try
    End Sub

    Private Sub txtKilometro_LostFocus(sender As Object, e As System.EventArgs) Handles txtKilometro.LostFocus
        If Val(Me.txtKilometro.Text) > 0 Then
            Dim dblMonto As Double
            dblMonto = CDbl(Me.txtKilometro.Text)
            Me.txtKilometro.Text = Format(dblMonto, "#,###,###0")
        Else
            Me.txtKilometro.Text = ""
        End If
    End Sub

    Private Sub txtHora_GotFocus(sender As Object, e As System.EventArgs) Handles txtHora.GotFocus
        txtHora.SelectAll()
    End Sub

    Private Sub txtHora_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtHora.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtHora_LostFocus(sender As Object, e As System.EventArgs) Handles txtHora.LostFocus
        Dim strHora As String, strMinuto As String, strTexto As String = "", intPosicion As Integer, intLongitud As Integer

        strTexto = Me.txtHora.Text.Trim
        intPosicion = strTexto.IndexOf(":")
        intPosicion += 1
        intLongitud = strTexto.Length

        strHora = txtHora.Text.Substring(0, 2)

        If intLongitud > intPosicion Then
            strMinuto = txtHora.Text.Trim.Substring(intPosicion, intLongitud - intPosicion)
        Else
            strMinuto = "0"
        End If

        If Val(strHora) = 0 Then strHora = "0"
        strHora = strHora.Trim.PadLeft(2, "0")
        strMinuto = strMinuto.Trim.PadLeft(2, "0")

        strTexto = strHora.Trim & ":" & strMinuto.Trim

        Me.txtHora.Mask = ""
        Me.txtHora.Text = strTexto
        Me.txtHora.Mask = "00:00"
        Me.txtHora.Refresh()
    End Sub

    Private Sub txtLocalidad_Enter(sender As Object, e As System.EventArgs) Handles txtLocalidad.Enter
        Me.txtLocalidad.SelectAll()
    End Sub

    Private Sub txtLocalidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtLocalidad.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub dgvImprimir_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvImprimir.RowEnter
        If Me.dgvImprimir.Rows.Count > 0 Then
            'Dim intID As Integer = Me.dgvImprimir.CurrentRow.Cells("id").Value
            Dim intID As Integer = Me.dgvImprimir.Rows(e.RowIndex).Cells("id").Value

            Dim obj1 As New dtoFueraZona
            Dim dt As DataTable = obj1.ListarFactura(intID)

            Me.dgvDetalle.DataSource = dt
        End If
    End Sub

    Private Sub cboProveedor_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboProveedor.SelectedIndexChanged
        btnFiltrarImprimir_Click(Nothing, Nothing)
    End Sub
End Class