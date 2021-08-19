Imports INTEGRACION_LN
Imports INTEGRACION_EN

Public Class frmGestionClienteNoCorporativo
    Dim intOperacion As Operacion
    Dim blnInicioCliente As Boolean = False, blnInicioContacto As Boolean = False, blnInicioDireccion As Boolean = False
    Dim intSituacion As Integer = 0, intPerfil As Integer = 0

    Private Sub ConfigurarDGVContactos()
        With dgvContactos
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
            Dim col_idsubcuenta As New DataGridViewTextBoxColumn
            With col_idsubcuenta
                .Name = "idsubcuenta" : .DataPropertyName = "idsubcuenta"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idsubcuenta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_subcuenta As New DataGridViewTextBoxColumn
            With col_subcuenta
                .Name = "subcuenta" : .DataPropertyName = "subcuenta"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subcuenta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_nombres As New DataGridViewTextBoxColumn
            With col_nombres
                .Name = "nombres" : .DataPropertyName = "nombres"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nombres/Razón Social"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_idcargo As New DataGridViewTextBoxColumn
            With col_idcargo
                .Name = "idcargo" : .DataPropertyName = "idcargo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcargo"
            End With
            x += +1
            Dim col_cargo As New DataGridViewTextBoxColumn
            With col_cargo
                .Name = "cargo" : .DataPropertyName = "cargo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cargo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                '.Width = 220
            End With
            x += +1
            Dim col_nombre As New DataGridViewTextBoxColumn
            With col_nombre
                .Name = "nombre" : .DataPropertyName = "nombre"
                .DisplayIndex = x : .Visible = False : .HeaderText = "nombre"
            End With
            x += +1
            Dim col_ap As New DataGridViewTextBoxColumn
            With col_ap
                .Name = "ap" : .DataPropertyName = "ap"
                .DisplayIndex = x : .Visible = False : .HeaderText = "ap"
            End With
            x += +1
            Dim col_am As New DataGridViewTextBoxColumn
            With col_am
                .Name = "am" : .DataPropertyName = "am"
                .DisplayIndex = x : .Visible = False : .HeaderText = "am"
            End With
            x += +1
            Dim col_idtipo_documento As New DataGridViewTextBoxColumn
            With col_idtipo_documento
                .Name = "idtipo_documento" : .DataPropertyName = "idtipo_documento"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo_documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_tipo_documento As New DataGridViewTextBoxColumn
            With col_tipo_documento
                .Name = "tipo_documento" : .DataPropertyName = "tipo_documento"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_numero_documento As New DataGridViewTextBoxColumn
            With col_numero_documento
                .Name = "numero_documento" : .DataPropertyName = "numero_documento"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Documento"
            End With
            x += +1
            Dim col_email As New DataGridViewTextBoxColumn
            With col_email
                .Name = "email" : .DataPropertyName = "email"
                .DisplayIndex = x : .Visible = False : .HeaderText = "email"
            End With
            x += +1
            Dim col_sexo As New DataGridViewTextBoxColumn
            With col_sexo
                .Name = "sexo" : .DataPropertyName = "sexo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "sexo"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
            End With
            x += +1
            Dim col_idestado As New DataGridViewTextBoxColumn
            With col_idestado
                .Name = "idestado" : .DataPropertyName = "idestado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idestado"
            End With
            x += +1
            Dim col_fecha_ingreso As New DataGridViewTextBoxColumn
            With col_fecha_ingreso
                .Name = "fecha_ingreso" : .DataPropertyName = "fecha_ingreso"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fecha_ingreso"
            End With
            .Columns.AddRange(col_id, col_idsubcuenta, col_subcuenta, col_nombres, col_idcargo, col_cargo, col_nombre, col_ap, col_am, _
                              col_idtipo_documento, col_tipo_documento, col_numero_documento, col_email, col_sexo, col_estado, col_idestado, _
                              col_fecha_ingreso)
        End With
    End Sub
    Private Sub ConfigurarDGVDirecciones()
        With dgvDirecciones
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
            Dim col_idtipo As New DataGridViewTextBoxColumn
            With col_idtipo
                .Name = "idtipo" : .DataPropertyName = "idtipo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo de Dirección"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_iddepartamento As New DataGridViewTextBoxColumn
            With col_iddepartamento
                .Name = "iddepartamento" : .DataPropertyName = "iddepartamento"
                .DisplayIndex = x : .Visible = False : .HeaderText = "iddepartamento"
            End With
            x += +1
            Dim col_idprovincia As New DataGridViewTextBoxColumn
            With col_idprovincia
                .Name = "idprovincia" : .DataPropertyName = "idprovincia"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idprovincia"
            End With
            x += +1
            Dim col_iddistrito As New DataGridViewTextBoxColumn
            With col_iddistrito
                .Name = "iddistrito" : .DataPropertyName = "iddistrito"
                .DisplayIndex = x : .Visible = False : .HeaderText = "iddistrito"
            End With
            x += +1
            Dim col_id_via As New DataGridViewTextBoxColumn
            With col_id_via
                .Name = "id_via" : .DataPropertyName = "id_via"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id_via"
            End With
            x += +1
            Dim col_via As New DataGridViewTextBoxColumn
            With col_via
                .Name = "via" : .DataPropertyName = "via"
                .DisplayIndex = x : .Visible = False : .HeaderText = "via"
            End With
            x += +1
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero"
                .DisplayIndex = x : .Visible = False : .HeaderText = "numero"
            End With
            x += +1
            Dim col_manzana As New DataGridViewTextBoxColumn
            With col_manzana
                .Name = "manzana" : .DataPropertyName = "manzana"
                .DisplayIndex = x : .Visible = False : .HeaderText = "manzana"
            End With
            x += +1
            Dim col_lote As New DataGridViewTextBoxColumn
            With col_lote
                .Name = "lote" : .DataPropertyName = "lote"
                .DisplayIndex = x : .Visible = False : .HeaderText = "lote"
            End With
            x += +1
            Dim col_id_nivel As New DataGridViewTextBoxColumn
            With col_id_nivel
                .Name = "id_nivel" : .DataPropertyName = "id_nivel"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id_nivel"
            End With
            x += +1
            Dim col_nivel As New DataGridViewTextBoxColumn
            With col_nivel
                .Name = "nivel" : .DataPropertyName = "nivel"
                .DisplayIndex = x : .Visible = False : .HeaderText = "nivel"
            End With
            x += +1
            Dim col_id_zona As New DataGridViewTextBoxColumn
            With col_id_zona
                .Name = "id_zona" : .DataPropertyName = "id_zona"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id_zona"
            End With
            x += +1
            Dim col_zona As New DataGridViewTextBoxColumn
            With col_zona
                .Name = "zona" : .DataPropertyName = "zona"
                .DisplayIndex = x : .Visible = False : .HeaderText = "zona"
            End With
            x += +1
            Dim col_id_clasificacion As New DataGridViewTextBoxColumn
            With col_id_clasificacion
                .Name = "id_clasificacion" : .DataPropertyName = "id_clasificacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id_clasificacion"
            End With
            x += +1
            Dim col_clasificacion As New DataGridViewTextBoxColumn
            With col_clasificacion
                .Name = "clasificacion" : .DataPropertyName = "clasificacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "clasificacion"
            End With
            x += +1
            Dim col_de_referencia As New DataGridViewTextBoxColumn
            With col_de_referencia
                .Name = "de_referencia" : .DataPropertyName = "de_referencia"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Referencia"
            End With
            x += +1
            Dim col_idestado_registro As New DataGridViewTextBoxColumn
            With col_idestado_registro
                .Name = "idestado" : .DataPropertyName = "idestado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idestado"
            End With
            x += +1
            Dim col_direccion As New DataGridViewTextBoxColumn
            With col_direccion
                .Name = "direccion" : .DataPropertyName = "direccion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Dirección"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_direccion_facturacion As New DataGridViewTextBoxColumn
            With col_direccion_facturacion
                .Name = "direccion_facturacion" : .DataPropertyName = "direccion_facturacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "direccion_facturacion"
            End With
            x += +1
            Dim col_facturacion As New DataGridViewTextBoxColumn
            With col_facturacion
                .Name = "facturacion" : .DataPropertyName = "facturacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Dirección de Facturación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            .Columns.AddRange(col_id, col_idtipo, col_tipo, col_iddepartamento, col_idprovincia, col_iddistrito, col_id_via, col_via, _
                              col_numero, col_manzana, col_lote, col_id_nivel, col_nivel, col_id_zona, col_zona, _
                              col_id_clasificacion, col_clasificacion, col_de_referencia, col_idestado_registro, _
                              col_direccion, col_direccion_facturacion, col_facturacion, col_estado)
        End With
    End Sub
    Private Sub ConfigurarDGVComunicacionContacto()
        With dgvComunicacionContacto
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
            Dim col_idtipo As New DataGridViewTextBoxColumn
            With col_idtipo
                .Name = "idtipo" : .DataPropertyName = "idtipo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo"
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Comunicación"
            End With

            'x += +1
            'Dim col_tipo As New DataGridViewComboBoxColumn
            'With col_tipo
            '    .Name = "tipo" : .DataPropertyName = "idtipo"
            '    .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Comunicación"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            '    Dim objLN As New Cls_Contacto_LN
            '    .DataSource = objLN.ListarComunicacion
            '    .DisplayMember = "tipo"
            '    .ValueMember = "id"
            '    .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            '    .Width = 130
            'End With
            x += +1
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Comunicación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.NullValue = 0
            End With
            .Columns.AddRange(col_id, col_idtipo, col_tipo, col_numero, col_estado)
        End With
    End Sub
    Private Sub ConfigurarDGVContactoDireccion()
        With dgvContactoDireccion
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
            Dim col_cargo As New DataGridViewTextBoxColumn
            With col_cargo
                .Name = "cargo" : .DataPropertyName = "cargo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cargo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_contacto As New DataGridViewTextBoxColumn
            With col_contacto
                .Name = "contacto" : .DataPropertyName = "contacto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Contacto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
            End With
            .Columns.AddRange(col_id, col_cargo, col_contacto, col_estado)
        End With
    End Sub

    Private Sub ConfigurarDGVClientes()
        With dgvClientes
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
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
                .Width = 220
            End With
            x += +1
            Dim col_descuento As New DataGridViewTextBoxColumn
            With col_descuento
                .Name = "descuento" : .DataPropertyName = "descuento"
                .DisplayIndex = x : .Visible = False : .HeaderText = "descuento"
            End With
            x += +1
            Dim col_serie As New DataGridViewTextBoxColumn
            With col_serie
                .Name = "serie" : .DataPropertyName = "serie"
                .DisplayIndex = x : .Visible = False : .HeaderText = "serie"
            End With
            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .Visible = False : .HeaderText = "usuario"
            End With
            x += +1
            Dim col_password As New DataGridViewTextBoxColumn
            With col_password
                .Name = "password" : .DataPropertyName = "password"
                .DisplayIndex = x : .Visible = False : .HeaderText = "password"
            End With
            x += +1
            Dim col_funcionario As New DataGridViewTextBoxColumn
            With col_funcionario
                .Name = "funcionario" : .DataPropertyName = "funcionario"
                .DisplayIndex = x : .Visible = False : .HeaderText = "funcionario"
            End With
            .Columns.AddRange(col_id, col_codigo, col_cliente, col_descuento, col_serie, col_usuario, col_password, col_funcionario)
        End With
    End Sub

    Private Sub BuscarCliente(cliente As String, opcion As Integer, Optional usuario As Integer = 0)
        Try
            If opcion = 1 Then
                If cliente.Trim.Length > 0 Then
                    If cliente.Trim.Length = 11 Then
                        If Not fnValidarRUC(cliente) Then
                            MessageBox.Show("El RUC no es Válido", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.txtNumeroDocumento.Focus()
                            Me.txtNumeroDocumento.SelectAll()
                            Return
                        ElseIf cliente.Trim.Length <> 8 And cliente.Trim.Length <> 11 Then
                            MessageBox.Show("El Nº de Documento no es Válido", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.txtNumeroDocumento.Focus()
                            Me.txtNumeroDocumento.SelectAll()
                            Return
                        End If
                    End If
                Else
                    MessageBox.Show("Ingrese Nº de Documento para realizar la búsqueda", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtNumeroDocumento.Focus()
                    Me.txtNumeroDocumento.SelectAll()
                    Return
                End If
            End If
            If Me.txtRazonSocial.Focused Then
                If Me.txtRazonSocial.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Razón Social para realizar la búsqueda", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtRazonSocial.Focus()
                    Me.txtRazonSocial.SelectAll()
                    Return
                End If
            End If

            Cursor = Cursors.AppStarting
            Dim obj As New Cls_Cliente_LN
            Dim dt As DataTable = obj.BuscarClienteNoCorporativo(cliente, opcion, usuario)
            If usuario = 0 Then
                Cursor = Cursors.Default
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("No se encontraron coincidencias", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Me.cboFuncionario.SelectedValue = 0
                    Me.dgvClientes.DataSource = dt

                    intSituacion = ObtieneSituacionCliente(Me.dgvClientes.CurrentRow.Cells("id").Value, dtoUSUARIOS.IdLogin)
                End If
            Else
                Cursor = Cursors.Default
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("No se encontraron coincidencias", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Me.dgvClientes.DataSource = dt
                    intSituacion = ObtieneSituacionCliente(Me.dgvClientes.CurrentRow.Cells("id").Value, dtoUSUARIOS.IdLogin)
                End If
            End If
            If Me.txtNumeroDocumento.Focused Then
                Me.txtNumeroDocumento.Focus()
                Me.txtNumeroDocumento.SelectAll()
            ElseIf Me.txtRazonSocial.Focused Then
                Me.txtRazonSocial.Focus()
                Me.txtRazonSocial.SelectAll()
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim flat As Boolean = True
        If msg.WParam.ToInt32 = Keys.Enter Then
            If tabGestionCliente.SelectedTab Is tabGestionCliente.TabPages("tabficha") Then
                If Me.cboTipoPersona.Focused Or Me.txtCliente.Focused Or Me.txtAPCliente.Focused Or Me.txtAMCliente.Focused Or Me.cboTipoDocumento.Focused Or _
                    Me.txtNumero.Focused Or Me.txtGerenteGeneral.Focused Or Me.txtRepresentanteLegal.Focused Or Me.txtPaginaWeb.Focused Or _
                    Me.dtpFechaNacimiento.Focused Or Me.rbtMasculino.Focused Or Me.rbtFemenino.Focused Or Me.txtEmail.Focused Or _
                    Me.dtpFechaIngreso.Focused Or Me.chkAgenteRetencion.Focused Or Me.chkPagoPostfacturacion.Focused Or Me.cboRubroCliente.Focused Or Me.cboClasificacionCliente.Focused Or _
                    Me.txtDescuento.Focused Or Me.txtSerieDocumento.Focused Or Me.txtUsuarioWeb.Focused Or Me.txtContraseñaWeb.Focused Then
                    SendKeys.Send(vbTab)
                ElseIf Me.txtNumeroDocumento.Focused Or Me.txtRazonSocial.Focused Then
                    Dim intOpcion As Integer = IIf(Me.txtNumeroDocumento.Focused, 1, 2)
                    Dim strCliente As String = IIf(Me.txtNumeroDocumento.Focused, Me.txtNumeroDocumento.Text.Trim, Me.txtRazonSocial.Text.Trim)
                    Dim intUsuario As Integer = 0
                    If Me.cboFuncionario.Tag = "*" Then
                        intUsuario = dtoUSUARIOS.IdLogin
                    End If
                    blnInicioCliente = False
                    BuscarCliente(strCliente.Trim, intOpcion, intUsuario)
                Else
                    flat = MyBase.ProcessCmdKey(msg, KeyData)
                End If
            ElseIf tabGestionCliente.SelectedTab Is tabGestionCliente.TabPages("tabcontacto") Then
                If Me.cboSubcuentaContacto.Focused Or Me.cboCargoContacto.Focused Or Me.cboTipoDocumentoContacto.Focused Or Me.txtNumeroContacto.Focused Or _
                   Me.txtNombresContacto.Focused Or Me.txtAPContacto.Focused Or Me.txtAMContacto.Focused Or Me.txtEmailContacto.Focused Or _
                   Me.rbtMasculinoContacto.Focused Or Me.rbtFemeninoContacto.Focused Or Me.chkActivoContacto.Focused Or Me.dtpFechaIngresoContacto.Focused Then
                    SendKeys.Send(vbTab)
                Else
                    flat = MyBase.ProcessCmdKey(msg, KeyData)
                End If
            ElseIf tabGestionCliente.SelectedTab Is tabGestionCliente.TabPages("tabdireccion") Then
                If Me.cboTipoDireccion.Focused Or Me.CboDepartamento.Focused Or Me.CboProvincia.Focused Or Me.CboDistrito.Focused Or Me.CboVia.Focused Or _
                    Me.TxtVia.Focused Or Me.TxtNumero2.Focused Or Me.TxtManzana.Focused Or Me.TxtLote.Focused Or Me.CboNivel.Focused Or Me.TxtNivel.Focused Or _
                    Me.CboZona.Focused Or Me.TxtZona.Focused Or Me.CboClasificacion.Focused Or Me.TxtClasificacion.Focused Or Me.TxtReferencia.Focused Or _
                    Me.chkDireccionFacturacion.Focused Or Me.chkActivoDireccion.Focused Then
                    SendKeys.Send(vbTab)
                Else
                    flat = MyBase.ProcessCmdKey(msg, KeyData)
                End If
            End If
        Else
            flat = MyBase.ProcessCmdKey(msg, KeyData)
        End If
        Return flat
    End Function

    Sub LimpiarContacto()
        Me.cboSubcuentaContacto.SelectedValue = 999
        Me.cboCargoContacto.SelectedValue = 0
        Me.cboTipoDocumentoContacto.SelectedValue = 0
        Me.txtNumeroContacto.Text = ""
        Me.txtNombresContacto.Text = ""
        Me.txtAPContacto.Text = ""
        Me.txtAMContacto.Text = ""
        Me.txtEmailContacto.Text = ""
        Me.dtpFechaIngresoContacto.Value = FechaServidor()
        Me.rbtMasculinoContacto.Checked = False
        Me.rbtFemeninoContacto.Checked = False
        Me.chkActivoContacto.Checked = True
        Me.cboEstadoContacto.SelectedIndex = 1
        Me.dgvComunicacionContacto.Rows.Clear()
        'Me.dgvComunicacionContacto.DataSource = Nothing
        'Me.dgvComunicacionContacto.Rows.Add()
    End Sub

    Sub ListarContactoCliente(cliente As Integer, estado As Integer)
        Dim objLN As New Cls_Contacto_LN
        Dim dt As DataTable = objLN.ListarContacto(cliente, estado)
        dgvContactos.DataSource = dt
    End Sub

    Sub ActivaDesactivaContacto(estado As Integer, registros As Integer)
        Dim blnEstado As Boolean
        If estado = 1 Then
            blnEstado = True
        ElseIf estado = 0 Then
            blnEstado = False
        End If
        If estado = -1 Then
            Me.grbContacto.Enabled = False
            Me.grbComunicacionContacto.Enabled = False
            Me.btnNuevoContacto.Enabled = True
            If registros = 0 Then
                Me.btnModificarContacto.Enabled = False
            Else
                Me.btnModificarContacto.Enabled = True
            End If
            Me.btnGrabarContacto.Enabled = False
            Me.btnCancelarContacto.Enabled = False
        Else
            blnEstado = estado
            Me.grbContacto.Enabled = blnEstado
            Me.grbComunicacionContacto.Enabled = blnEstado
            Me.btnNuevoContacto.Enabled = Not blnEstado
            If registros = 0 Then
                Me.btnModificarContacto.Enabled = False
            Else
                Me.btnModificarContacto.Enabled = Not blnEstado
            End If
            Me.btnGrabarContacto.Enabled = blnEstado
            Me.btnCancelarContacto.Enabled = blnEstado
            If registros = 0 Then
            Else
            End If
        End If

        If Me.btnGrabarContacto.Enabled Then
            Me.dgvContactos.Enabled = False
            Me.cboEstadoContacto.Enabled = False
        Else
            Me.dgvContactos.Enabled = True
            Me.cboEstadoContacto.Enabled = True
        End If
    End Sub

    Sub LimpiarDireccion()
        Me.cboTipoDireccion.SelectedValue = 0
        Me.CboDepartamento.SelectedValue = 0
        Me.CboProvincia.SelectedValue = 0
        Me.CboDistrito.SelectedValue = 0
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
        Me.TxtReferencia.Text = ""
        Me.chkDireccionFacturacion.Checked = False
        Me.chkActivoDireccion.Checked = True
        Me.cboEstadoDireccion.SelectedIndex = 1
        Me.dgvContactoDireccion.Rows.Clear()
    End Sub

    Sub ActivaDesactivaDireccion(estado As Integer, registros As Integer)
        Dim blnEstado As Boolean
        If estado = 1 Then
            blnEstado = True
        ElseIf estado = 0 Then
            blnEstado = False
        End If
        If estado = -1 Then
            Me.grbDireccion.Enabled = False
            Me.grbContactoDireccion.Enabled = False
            Me.btnNuevoDireccion.Enabled = True
            If registros = 0 Then
                Me.btnModificarDireccion.Enabled = False
            Else
                Me.btnModificarDireccion.Enabled = True
            End If
            Me.btnGrabarDireccion.Enabled = False
            Me.btnCancelarDireccion.Enabled = False
        Else
            blnEstado = estado
            Me.grbDireccion.Enabled = blnEstado
            Me.grbContactoDireccion.Enabled = blnEstado
            Me.btnNuevoDireccion.Enabled = Not blnEstado
            If registros = 0 Then
                Me.btnModificarDireccion.Enabled = False
            Else
                Me.btnModificarDireccion.Enabled = Not blnEstado
            End If
            Me.btnGrabarDireccion.Enabled = blnEstado
            Me.btnCancelarDireccion.Enabled = blnEstado
            If registros = 0 Then
            Else
            End If
        End If

        If Me.btnGrabarDireccion.Enabled Then
            Me.dgvDirecciones.Enabled = False
            Me.cboEstadoDireccion.Enabled = False
        Else
            Me.dgvDirecciones.Enabled = True
            Me.cboEstadoDireccion.Enabled = True
        End If
    End Sub

    Private Sub tabGestionCliente_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabGestionCliente.SelectedIndexChanged
        If tabGestionCliente.SelectedTab Is tabGestionCliente.TabPages("tabFicha") Then
            'InicioCliente()
        ElseIf tabGestionCliente.SelectedTab Is tabGestionCliente.TabPages("tabContacto") Then
            If Me.dgvClientes.Rows.Count = 0 Then Return
            Me.LimpiarContacto()
            Dim intCliente As Integer = Me.dgvClientes.CurrentRow.Cells("id").Value
            Me.lblCodigoCliente.Text = Me.dgvClientes.CurrentRow.Cells("codigo").Value
            Me.lblRazonSocialCliente.Text = Me.dgvClientes.CurrentRow.Cells("cliente").Value
            'InicioContacto()
            Dim obj2 As New Cls_SubCuenta_LN
            With cboSubcuentaContacto
                .DataSource = obj2.ListarSubcuentaCliente(intCliente)
                .DisplayMember = "subcuenta"
                .ValueMember = "id"
                .SelectedValue = 999
            End With
            ListarContactoCliente(intCliente, Me.cboEstadoContacto.SelectedIndex)
            'ConfigurarDGVComunicacionContacto()
            ActivaDesactivaContacto(-1, Me.dgvContactos.Rows.Count)
            SituacionCliente()
        ElseIf tabGestionCliente.SelectedTab Is tabGestionCliente.TabPages("tabDireccion") Then
            If Me.dgvClientes.Rows.Count = 0 Then Return
            Me.LimpiarDireccion()
            Me.lblCodigoClienteDireccion.Text = Me.dgvClientes.CurrentRow.Cells("codigo").Value
            Me.lblrazonSocialClienteDireccion.Text = Me.dgvClientes.CurrentRow.Cells("cliente").Value

            Dim intCliente As Integer = Me.dgvClientes.CurrentRow.Cells("id").Value
            ListarDireccionCliente(intCliente, Me.cboEstadoDireccion.SelectedIndex)
            ActivaDesactivaDireccion(-1, Me.dgvDirecciones.Rows.Count)
            SituacionCliente()
        End If
    End Sub

    Sub ActivaDesactivaCliente(estado As Integer, registros As Integer)
        Dim blnEstado As Boolean
        If estado = 1 Then
            blnEstado = True
        ElseIf estado = 0 Then
            blnEstado = False
        End If
        If estado = -1 Then
            Me.GrbCliente.Enabled = False
            Me.grbClienteCorporativo.Enabled = False
            Me.grbDescuento.Enabled = False
            Me.grbSerieDocumento.Enabled = False
            Me.grbAccesoWeb.Enabled = False
            Me.grbProducto.Enabled = False
            Me.btnNuevoCliente.Enabled = True
            If registros = 0 Then
                Me.btnModificarCliente.Enabled = False
            Else
                Me.btnModificarCliente.Enabled = True
            End If
            Me.btnGrabarCliente.Enabled = False
            Me.btnCancelarCliente.Enabled = False
        Else
            blnEstado = estado
            Me.GrbCliente.Enabled = blnEstado
            Me.grbClienteCorporativo.Enabled = blnEstado
            If Me.grbDescuento.Tag = "*" Then
                Me.grbDescuento.Enabled = blnEstado
                Me.grbProducto.Enabled = blnEstado
            Else
                Me.grbDescuento.Enabled = False
                Me.grbProducto.Enabled = False
            End If
            Me.grbSerieDocumento.Enabled = blnEstado
            Me.grbAccesoWeb.Enabled = blnEstado
            Me.btnNuevoCliente.Enabled = Not blnEstado
            Me.btnGrabarCliente.Enabled = blnEstado
            Me.btnCancelarCliente.Enabled = blnEstado
            If registros = 0 Then
                Me.btnModificarCliente.Enabled = False
            Else
                Me.btnModificarCliente.Enabled = Not blnEstado
            End If
        End If
    End Sub

    Sub GrabarCliente()
        Dim objLN As New Cls_Cliente_LN
        Dim objEN As New Cls_Cliente_EN

        Try
            With objEN
                If intOperacion = Operacion.Nuevo Then
                    .ID = 0
                Else
                    .ID = Me.dgvClientes.CurrentRow.Cells("id").Value
                End If
                .TipoPersona = IIf(Me.cboTipoPersona.SelectedIndex = TipoPersona.JURIDICA, 1, 2)
                .TipoDocumento = Me.cboTipoDocumento.SelectedValue
                .NumeroDocumento = Me.txtNumero.Text.Trim
                If Me.cboTipoPersona.SelectedIndex = TipoPersona.JURIDICA Then
                    .RazonSocial = Me.txtCliente.Text.Trim
                    .GerenteGeneral = Me.txtGerenteGeneral.Text.Trim
                    .RepresentanteLegal = Me.txtRepresentanteLegal.Text.Trim
                    .PaginaWeb = Me.txtPaginaWeb.Text.Trim
                    .PagoPostFacturacion = IIf(Me.chkPagoPostfacturacion.Checked, 1, 0)
                Else
                    .Nombres = Me.txtCliente.Text.Trim
                    .ApellidoPaterno = Me.txtAPCliente.Text.Trim
                    .ApellidoMaterno = Me.txtAMCliente.Text.Trim
                    .FechaNacimiento = Me.dtpFechaNacimiento.Value.Date.ToShortDateString
                    .Sexo = IIf(Me.rbtMasculino.Checked, "M", "F")
                    .Email = Me.txtEmail.Text.Trim
                End If
                .FechaIngreso = Me.dtpFechaIngreso.Value.Date.ToShortDateString
                .AgenteRetencion = IIf(Me.chkAgenteRetencion.Checked, 1, 0)
                .ClasificacionEmpresa = Me.cboClasificacionCliente.SelectedValue
                .RubroEmpresarial = Me.cboRubroCliente.SelectedValue
                .Descuento = IIf(Me.txtDescuento.Text.Trim.Length = 0, 0, Me.txtDescuento.Text)
                .DigitosSerie = IIf(Me.txtSerieDocumento.Text.Trim.Length = 0, 3, Me.txtSerieDocumento.Text)
                .UsuarioWeb = IIf(Me.txtUsuarioWeb.Text.Trim.Length = 0, "", Me.txtUsuarioWeb.Text.Trim)
                .Contraseña = IIf(Me.txtContraseñaWeb.Text.Trim.Length = 0, "", Me.txtContraseñaWeb.Text.Trim)
                .Producto = Me.cboProducto.SelectedValue

                .Usuario = dtoUSUARIOS.IdLogin
                .IP = dtoUSUARIOS.IP

                objLN.Grabar(objEN)

                'Actualiza Cartera y Producto
                '.ID = Me.dgvClientes.CurrentRow.Cells("id").Value
                'objLN.AsociarCliente(.ID, Me.cboProducto.SelectedValue, .Usuario, .Usuario, .IP)

                Dim strMensaje As String = IIf(intOperacion = Operacion.Nuevo, "Cliente Registrado", "Cliente Actualizado")
                MessageBox.Show(strMensaje, "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cboFuncionario_SelectedIndexChanged(Nothing, Nothing)
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNuevoCliente_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevoCliente.Click
        intOperacion = Operacion.Nuevo
        Me.LimpiarCliente()
        ActivaDesactivaCliente(1, dgvClientes.Rows.Count)
        If intPerfil = 1 Or intPerfil = 2 Then
            Me.grbProducto.Enabled = True
        Else
            Me.grbProducto.Enabled = False
        End If
        Me.txtCliente.Focus()
    End Sub

    Sub MostrarCliente(cliente As Integer)
        Try
            Dim objLN As New Cls_Cliente_LN
            Dim dt As DataTable = objLN.ObtieneCliente(cliente)
            Me.cboTipoPersona.SelectedIndex = CType(dt.Rows(0).Item("idtipo_persona").ToString, Integer) - 1
            If Me.cboTipoPersona.SelectedIndex = TipoPersona.JURIDICA Then
                Me.txtCliente.Text = dt.Rows(0).Item("razon_social").ToString
                Me.txtGerenteGeneral.Text = dt.Rows(0).Item("gerente_general").ToString
                Me.txtRepresentanteLegal.Text = dt.Rows(0).Item("representante_legal").ToString
                Me.txtPaginaWeb.Text = dt.Rows(0).Item("email").ToString
            Else
                Me.txtCliente.Text = dt.Rows(0).Item("nompre_persona").ToString
                Me.txtAPCliente.Text = dt.Rows(0).Item("apellido_paterno").ToString
                Me.txtAMCliente.Text = dt.Rows(0).Item("apellido_materno").ToString
                Me.dtpFechaNacimiento.Value = IIf(dt.Rows(0).Item("fecha_nacimiento").ToString.Trim = "", Now, dt.Rows(0).Item("fecha_nacimiento").ToString)
                If dt.Rows(0).Item("fecha_nacimiento").ToString = "M" Then
                    Me.rbtMasculino.Checked = True
                Else
                    Me.rbtFemenino.Checked = True
                End If
                Me.txtEmail.Text = dt.Rows(0).Item("email").ToString
            End If
            Me.cboTipoDocumento.SelectedValue = dt.Rows(0).Item("idtipo_doc_identidad").ToString
            Me.txtNumero.Text = dt.Rows(0).Item("nu_docu_suna").ToString
            Me.dtpFechaIngreso.Value = dt.Rows(0).Item("fecha_ingreso").ToString
            Me.chkAgenteRetencion.Checked = CType(dt.Rows(0).Item("agente_retencion").ToString, Boolean)
            Me.chkPagoPostfacturacion.Checked = CType(dt.Rows(0).Item("pago_post_facturacion").ToString, Boolean)
            Me.cboRubroCliente.SelectedValue = CType(dt.Rows(0).Item("idrubro").ToString, Integer)
            Me.cboClasificacionCliente.SelectedValue = CType(dt.Rows(0).Item("idclasificacion_persona").ToString, Integer)
            Dim dblDescuento As Double = dt.Rows(0).Item("descuento").ToString
            Me.txtDescuento.Text = Format(dblDescuento, "0.00")
            Me.txtSerieDocumento.Text = dt.Rows(0).Item("serie").ToString
            Me.txtUsuarioWeb.Text = dt.Rows(0).Item("usuario").ToString.Trim
            Me.txtContraseñaWeb.Text = dt.Rows(0).Item("password").ToString.Trim
            If Me.cboFuncionario.SelectedValue = 0 Then
                Me.lblFuncionarioCliente.Text = dt.Rows(0).Item("funcionario").ToString.Trim
            Else
                Me.lblFuncionarioCliente.Text = ""
            End If
            Me.cboProducto.SelectedValue = IIf(IsDBNull(dt.Rows(0).Item("producto")), 0, dt.Rows(0).Item("producto"))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mostrar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub LimpiarCliente()
        Me.cboTipoPersona.SelectedIndex = 0
        Me.txtCliente.Text = ""
        Me.txtAPCliente.Text = ""
        Me.txtAMCliente.Text = ""
        Me.cboTipoDocumento.SelectedValue = 1
        Me.txtNumero.Text = ""
        Me.txtGerenteGeneral.Text = ""
        Me.txtRepresentanteLegal.Text = ""
        Me.txtPaginaWeb.Text = ""
        Me.dtpFechaNacimiento.Value = Now
        Me.rbtMasculino.Checked = False
        Me.rbtFemenino.Checked = False
        Me.txtEmail.Text = ""
        Me.dtpFechaIngreso.Value = Now
        Me.chkAgenteRetencion.Checked = False
        Me.chkPagoPostfacturacion.Checked = False
        Me.cboRubroCliente.SelectedValue = 0
        Me.cboClasificacionCliente.SelectedValue = 2
        Me.txtDescuento.Text = ""
        Me.txtSerieDocumento.Text = ""
        Me.txtUsuarioWeb.Text = ""
        Me.txtContraseñaWeb.Text = ""
        Me.cboTipoPersona.Enabled = True
        'intSituacion = 0
    End Sub

    Sub CargarCartera(funcionario As Integer, dgv As DataGridView, Optional credito As Integer = 0)
        Dim obj As New Cls_ClienteCarteraFuncionario_LN
        Dim dt As DataTable = obj.ListarCarteraNoCorporativo(funcionario)
        dgv.DataSource = dt
    End Sub

    Private Sub cboFuncionario_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboFuncionario.SelectedIndexChanged
        If IsReference(cboFuncionario.SelectedValue) Then Return
        blnInicioCliente = True
        CargarCartera(Me.cboFuncionario.SelectedValue, dgvClientes)
        If Me.dgvClientes.Rows.Count > 0 Then
            Me.txtNumeroDocumento.Text = ""
            Me.txtRazonSocial.Text = ""
        Else
            Me.LimpiarCliente()
            ActivaDesactivaCliente(-1, Me.dgvClientes.Rows.Count)
        End If
        dgvClientes_RowEnter(Nothing, Nothing)
    End Sub

    Private Sub dgvClientes_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClientes.RowEnter
        If blnInicioCliente Then
            blnInicioCliente = False
            Return
        End If
        Dim intCliente As Integer
        Try
            intCliente = Me.dgvClientes.Rows(e.RowIndex).Cells("id").Value
        Catch ex As Exception
            intCliente = Me.dgvClientes.Rows(Me.dgvClientes.CurrentCell.RowIndex).Cells("id").Value
        End Try
        MostrarCliente(intCliente)

        intSituacion = ObtieneSituacionCliente(intCliente, dtoUSUARIOS.IdLogin)
        ActivaDesactivaCliente(0, dgvClientes.Rows.Count)
    End Sub

    Private Sub btnGrabarCliente_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabarCliente.Click
        If Me.cboTipoPersona.SelectedIndex = TipoPersona.JURIDICA Then
            If Me.txtCliente.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Razón Social del Cliente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCliente.Text = txtCliente.Text.Trim()
                txtCliente.Focus()
                Return
            End If
        Else
            If Me.txtCliente.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nombres del Cliente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCliente.Text = txtCliente.Text.Trim()
                txtCliente.Focus()
                Return
            End If

            If Me.txtAPCliente.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Apellido Paterno", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtAPCliente.Text = txtAPCliente.Text.Trim
                txtAPCliente.Focus()
                Return
            End If
        End If

        If Me.cboTipoDocumento.SelectedValue = 1 Then
            If Not fnValidarRUC(txtNumero.Text) Then
                MessageBox.Show("El RUC no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNumero.Focus()
                Return
            End If

            Dim obj As New Cls_ClienteCarteraFuncionario_LN
            Dim dt As DataTable = obj.ObtieneCliente(txtNumero.Text.Trim)
            If dt.Rows.Count > 0 Then
                If CType(dt.Rows(0).Item("idresponsable").ToString, Integer) > 0 Then
                    Dim intResponsable = IIf(dt.Rows(0).Item("idresponsable").ToString.Trim.Length = 0, 0, dt.Rows(0).Item("idresponsable"))
                    If dtoUSUARIOS.IdLogin <> intResponsable Then
                        MessageBox.Show("El Nº de Documento " & Me.txtNumero.Text.Trim & " del cliente " & dt.Rows(0).Item("razon_social").ToString.Trim & " pertenece a la Cartera de " & dt.Rows(0).Item("funcionario").ToString.Trim, "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtNumero.Focus()
                        Return
                    End If
                End If
            End If
        ElseIf Me.cboTipoDocumento.SelectedValue = 3 Then
            If txtNumero.Text.Trim.Length <> 8 Then
                MessageBox.Show("El DNI no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNumero.Text = txtNumero.Text.Trim
                txtNumero.Focus()
                Return
            End If
        Else
            If Me.cboTipoDocumento.SelectedValue <> 9 AndAlso txtNumero.Text.Trim.Length < 6 Then
                MessageBox.Show("El Nº de Documento no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNumero.Text = txtNumero.Text.Trim
                txtNumero.Focus()
                Return
            End If
        End If

        If intOperacion = Operacion.Nuevo Then
            Dim obj As New dtrecojo
            Dim snum As String = Me.txtNumero.Text
            Dim ds As DataSet = obj.Listar_cli(snum)
            Dim resp As Integer = ds.Tables(0).Rows.Count
            If resp = 1 Then
                MessageBox.Show("EL Nº de Documento ya Existe", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNumero.Focus()
                Return
            End If
        End If

        If Me.cboRubroCliente.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Rubro del Cliente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboRubroCliente.Focus()
            Return
        End If

        If Me.cboClasificacionCliente.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Clasificación del Cliente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboClasificacionCliente.Focus()
            Return
        End If

        'Valida descuento
        Dim intDescuento As Integer = Val(IIf(txtDescuento.Text = "", 0, txtDescuento.Text))
        If intDescuento > 0 Then      'descuento
            If Not (intDescuento >= 1 And intDescuento <= 100) Then
                MessageBox.Show("El % de Descuento debe estar entre 1.00 y 100.00", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDescuento.Focus()
                Exit Sub
            End If
        ElseIf intDescuento < 0 Then  'incremento
            If Not (Abs(intDescuento) >= 1 And Abs(intDescuento) <= 999) Then
                MessageBox.Show("El % de Incremento debe estar entre 1.00 y 999.00", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDescuento.Focus()
                Exit Sub
            End If
        End If

        'Valida acceso a la web
        If Me.txtUsuarioWeb.Text.Trim.Length > 0 And Me.txtContraseñaWeb.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Contraseña", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtContraseñaWeb.Focus()
            Return
        End If
        If Me.txtUsuarioWeb.Text.Trim.Length = 0 And Me.txtContraseñaWeb.Text.Trim.Length > 0 Then
            MessageBox.Show("Ingrese Contraseña", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUsuarioWeb.Focus()
            Return
        End If

        Cursor = Cursors.WaitCursor
        GrabarCliente()
        ActivaDesactivaCliente(0, dgvClientes.Rows.Count)
        Cursor = Cursors.Default
        Me.btnNuevoCliente.Focus()

    End Sub

    Private Sub btnCancelarCliente_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelarCliente.Click
        LimpiarCliente()
        ActivaDesactivaCliente(0, dgvClientes.Rows.Count)
        If Me.dgvClientes.Rows.Count > 0 Then
            Dim intCliente As Integer = Me.dgvClientes.CurrentRow.Cells("id").Value
            MostrarCliente(intCliente)
        End If
        If intOperacion = Operacion.Nuevo Then
            btnNuevoCliente.Focus()
        Else
            btnModificarCliente.Focus()
        End If
    End Sub

    Sub InicioCliente()
        ConfigurarDGVClientes()
        Dim intUsuario As Integer = 0
        If Me.cboFuncionario.Tag = "*" Then
            intUsuario = dtoUSUARIOS.IdLogin
        End If
        ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.cboFuncionario, "", "", 8, " (SELECCIONE)", intUsuario)

        Dim obj As New Cls_Cliente_LN
        With cboTipoDocumento
            .DataSource = obj.ListarDocumentoIdentidad
            .DisplayMember = "tipo"
            .ValueMember = "id"
            .SelectedValue = 1
        End With
        With cboRubroCliente
            .DataSource = obj.ListarRubro
            .DisplayMember = "rubro"
            .ValueMember = "id"
            .SelectedValue = 0
        End With
        With cboClasificacionCliente
            .DataSource = obj.ListarClasificacion
            .DisplayMember = "clasificacion"
            .ValueMember = "id"
            .SelectedValue = 0
        End With

        Dim obj2 As New UtilData_LN
        Dim dt As DataTable = obj2.ListarProducto(1)
        With cboProducto
            .DataSource = Nothing
            .DataSource = dt
            .DisplayMember = "procesos"
            .ValueMember = "idprocesos"
        End With

        Me.cboTipoPersona.SelectedIndex = 0
        Me.LimpiarCliente()
        ActivaDesactivaCliente(-1, Me.dgvClientes.Rows.Count)

        blnInicioCliente = True
        Me.btnNuevoCliente.Focus()
    End Sub

    Sub MostrarDireccion(fila As Integer)
        Me.cboTipoDireccion.SelectedValue = Me.dgvDirecciones.Rows(fila).Cells("idtipo").Value

        Me.CboDepartamento.SelectedValue = Me.dgvDirecciones.Rows(fila).Cells("iddepartamento").Value
        Me.CboProvincia.SelectedValue = Me.dgvDirecciones.Rows(fila).Cells("idprovincia").Value
        Me.CboDistrito.SelectedValue = Me.dgvDirecciones.Rows(fila).Cells("iddistrito").Value

        Me.CboVia.SelectedValue = CType(Me.dgvDirecciones.Rows(fila).Cells("id_via").Value, Integer)
        Me.TxtVia.Text = CType(Me.dgvDirecciones.Rows(fila).Cells("via").Value, String).Trim
        Me.TxtNumero2.Text = CType(Me.dgvDirecciones.Rows(fila).Cells("numero").Value, String).Trim
        Me.TxtManzana.Text = CType(Me.dgvDirecciones.Rows(fila).Cells("manzana").Value, String).Trim
        Me.TxtLote.Text = CType(Me.dgvDirecciones.Rows(fila).Cells("lote").Value, String).Trim
        Me.CboNivel.SelectedValue = CType(Me.dgvDirecciones.Rows(fila).Cells("id_nivel").Value, Integer)
        Me.TxtNivel.Text = CType(Me.dgvDirecciones.Rows(fila).Cells("nivel").Value, String).Trim
        Me.CboZona.SelectedValue = CType(Me.dgvDirecciones.Rows(fila).Cells("id_zona").Value, Integer)
        Me.TxtZona.Text = CType(Me.dgvDirecciones.Rows(fila).Cells("zona").Value, String).Trim
        Me.CboClasificacion.SelectedValue = CType(Me.dgvDirecciones.Rows(fila).Cells("id_clasificacion").Value, Integer)
        Me.TxtClasificacion.Text = CType(Me.dgvDirecciones.Rows(fila).Cells("clasificacion").Value, String).Trim
        Me.TxtReferencia.Text = CType(Me.dgvDirecciones.Rows(fila).Cells("de_referencia").Value, String).Trim

        Me.chkDireccionFacturacion.Checked = IIf(Me.dgvDirecciones.Rows(fila).Cells("direccion_facturacion").Value = 1, True, False)
        Me.chkActivoDireccion.Checked = IIf(Me.dgvDirecciones.Rows(fila).Cells("idestado").Value = 1, True, False)

        Me.ListarContactoDireccion(Me.dgvDirecciones.Rows(fila).Cells("id").Value)
    End Sub
    Sub ListarDireccionCliente(cliente As Integer, estado As Integer)
        Dim objLN As New Cls_Direccion_LN
        Dim dt As DataTable = objLN.ListarDireccion(cliente, estado)
        dgvDirecciones.DataSource = dt
    End Sub
    Sub ListarTipoDireccion()
        Dim obj As New Cls_Direccion_LN
        With cboTipoDireccion
            .DataSource = obj.ListarTipo
            .DisplayMember = "tipo"
            .ValueMember = "id"
            .SelectedValue = 0
        End With
    End Sub
    Sub ListarVia()
        Dim obj As New Cls_Direccion_LN
        With CboVia
            .DataSource = obj.ListarVia
            .DisplayMember = "via"
            .ValueMember = "id"
            .SelectedValue = 0
        End With
    End Sub
    Sub ListarZona()
        Dim obj As New Cls_Direccion_LN
        With CboZona
            .DataSource = obj.ListarZona
            .DisplayMember = "zona"
            .ValueMember = "id"
            .SelectedValue = 0
        End With
    End Sub
    Sub ListarNivel()
        Dim obj As New Cls_Direccion_LN
        With CboNivel
            .DataSource = obj.ListarNivel
            .DisplayMember = "nivel"
            .ValueMember = "id"
            .SelectedValue = 0
        End With
    End Sub
    Sub ListarClasificacion()
        Dim obj As New Cls_Direccion_LN
        With CboClasificacion
            .DataSource = obj.ListarClasificacion
            .DisplayMember = "clasificacion"
            .ValueMember = "id"
            .SelectedValue = 0
        End With
    End Sub
    Sub ListarDepartamento()
        Dim obj As New Cls_Direccion_LN
        With CboDepartamento
            .DataSource = obj.ListarDepartamento
            .DisplayMember = "departamento"
            .ValueMember = "id"
            .SelectedValue = 0
        End With
    End Sub
    Sub ListarProvincia(departamento As Integer)
        Dim obj As New Cls_Direccion_LN
        With CboProvincia
            .DataSource = obj.ListarProvincia(departamento)
            .DisplayMember = "provincia"
            .ValueMember = "id"
            .SelectedValue = 0
        End With
    End Sub
    Sub ListarDistrito(departamento As Integer, provincia As Integer)
        Dim obj As New Cls_Direccion_LN
        With CboDistrito
            .DataSource = obj.ListarDistrito(departamento, provincia)
            .DisplayMember = "distrito"
            .ValueMember = "id"
            .SelectedValue = 0
        End With
    End Sub

    Sub InicioDireccion()
        ListarTipoDireccion()
        ListarDepartamento()
        ListarProvincia(0)
        ListarDistrito(0, 0)
        ListarVia()
        ListarZona()
        ListarNivel()
        ListarClasificacion()
        ConfigurarDGVDirecciones()
        ConfigurarDGVContactoDireccion()
        'ConfigurarDGVComunicacionContacto()
        Me.chkActivoDireccion.Checked = True
        Me.cboEstadoDireccion.SelectedIndex = 1
        ActivaDesactivaDireccion(-1, Me.dgvDirecciones.Rows.Count)
    End Sub

    Sub InicioContacto()
        Dim obj As New Cls_Cliente_LN
        With cboTipoDocumentoContacto
            .DataSource = obj.ListarDocumentoIdentidad
            .DisplayMember = "tipo"
            .ValueMember = "id"
            .SelectedValue = 0
        End With
        Dim obj1 As New Cls_Contacto_LN
        With cboCargoContacto
            .DataSource = obj1.ListarTipo
            .DisplayMember = "tipo"
            .ValueMember = "id"
            .SelectedValue = 0
        End With
        ConfigurarDGVContactos()
        ConfigurarDGVComunicacionContacto()
        Me.chkActivoContacto.Checked = True
        Me.cboEstadoContacto.SelectedIndex = 1
        ActivaDesactivaContacto(-1, Me.dgvContactos.Rows.Count)
    End Sub

    Sub ListarContactoDireccion(direccion As Integer)
        Dim objLN As New Cls_Direccion_LN()
        Dim dt As DataTable = objLN.ListarContactoDireccion(direccion)
        With Me.dgvContactoDireccion
            .Rows.Clear()
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .Rows.Add()
                    Me.dgvContactoDireccion(0, .Rows.Count - 1).Value = row.Item("id")
                    Me.dgvContactoDireccion(1, .Rows.Count - 1).Value = row.Item("cargo")
                    Me.dgvContactoDireccion(2, .Rows.Count - 1).Value = row.Item("contacto")
                    Me.dgvContactoDireccion(3, .Rows.Count - 1).Value = row.Item("estado")
                Next
            End If
        End With
    End Sub

    Sub ControlaAcceso()
        'If Not Acceso.SiRol(G_Rol, Me, 2) Then 'ficha cliente
        '    Me.tabGestionCliente.TabPages.Remove(tabGestionCliente.TabPages("tabficha"))
        'End If
        'If Not Acceso.SiRol(G_Rol, Me, 3) Then 'ficha cliente
        '    Me.tabGestionCliente.TabPages.Remove(tabGestionCliente.TabPages("tabcontacto"))
        'End If
        'If Not Acceso.SiRol(G_Rol, Me, 4) Then 'ficha cliente
        '    Me.tabGestionCliente.TabPages.Remove(tabGestionCliente.TabPages("tabdireccion"))
        'End If

        If Acceso.SiRol(G_Rol, Me, 1, 1) Then 'ficha cliente
            intPerfil = 1
        End If
        If Acceso.SiRol(G_Rol, Me, 1, 2) Then 'ficha cliente
            intPerfil = 2
        End If
        If Acceso.SiRol(G_Rol, Me, 1, 3) Then 'ficha cliente
            intPerfil = 3
        End If
        If intPerfil = 0 Then
            intPerfil = 4
        End If

        'Dim blnResponsable As Boolean = Acceso.SiRol(G_Rol, Me, 27, 1)
        Dim blnResponsable As Boolean = intPerfil = 1
        If blnResponsable Then 'responsable
            Me.cboFuncionario.SelectedValue = dtoUSUARIOS.IdLogin
            Me.cboFuncionario.Tag = "*"
        Else
            Me.cboFuncionario.Tag = ""
        End If

        If Acceso.SiRol(G_Rol, Me, 28, 1) Then 'descuento
            Me.grbDescuento.Tag = "*"
        Else
            Me.grbDescuento.Tag = ""
        End If

        InicioCliente()
        If Me.cboFuncionario.Tag = "*" Then
            Me.cboFuncionario_SelectedIndexChanged(Nothing, Nothing)
        End If
        blnInicioContacto = True
        blnInicioDireccion = True
        InicioContacto()
        InicioDireccion()
        blnInicioContacto = False
        blnInicioDireccion = False
    End Sub

    Private Sub btnModificarCliente_Click(sender As System.Object, e As System.EventArgs) Handles btnModificarCliente.Click
        intOperacion = Operacion.Modificar
        Me.cboTipoPersona.Enabled = False
        ActivaDesactivaCliente(1, dgvClientes.Rows.Count)
        SituacionCliente()
        Me.txtCliente.Focus()
    End Sub

    Private Sub frmGestionClienteNoCorporativo_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ControlaAcceso()
    End Sub

    Private Sub btnNuevoContacto_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevoContacto.Click
        intOperacion = Operacion.Nuevo
        Me.LimpiarContacto()
        Me.chkActivoContacto.Enabled = False
        ActivaDesactivaContacto(1, dgvContactos.Rows.Count)
        Me.cboSubcuentaContacto.Focus()
        'Me.cboSubcuentaContacto.DroppedDown = True
    End Sub

    Private Sub btnModificarContacto_Click(sender As System.Object, e As System.EventArgs) Handles btnModificarContacto.Click
        intOperacion = Operacion.Modificar
        Me.chkActivoContacto.Enabled = True
        ActivaDesactivaContacto(1, dgvContactos.Rows.Count)
        Me.txtNombresContacto.Focus()
    End Sub

    Sub GrabarContacto()
        Dim objLN As New Cls_Contacto_LN
        Dim objEN As New Cls_Contacto_EN

        Try
            With objEN
                If intOperacion = Operacion.Nuevo Then
                    .ID = 0
                Else
                    .ID = Me.dgvContactos.CurrentRow.Cells("id").Value
                End If
                .TipoPersona = IIf(Me.cboTipoDocumentoContacto.SelectedValue = 1, 1, 2)
                .Cliente = Me.dgvClientes.CurrentRow.Cells("id").Value
                .TipoDocumento = Me.cboTipoDocumentoContacto.SelectedValue
                .NumeroDocumento = Me.txtNumeroContacto.Text.Trim
                .Cargo = Me.cboCargoContacto.SelectedValue
                If .TipoPersona = 1 Then
                    .Nombres = Me.txtNombresContacto.Text.Trim
                Else
                    .Nombres = Me.txtNombresContacto.Text.Trim
                    .ApellidoPaterno = Me.txtAPContacto.Text.Trim
                    .ApellidoMaterno = Me.txtAMContacto.Text.Trim
                    .Sexo = IIf(Me.rbtMasculinoContacto.Checked, "M", "F")
                End If
                .Email = Me.txtEmailContacto.Text.Trim
                .FechaIngreso = Me.dtpFechaIngresoContacto.Value.ToShortDateString
                .Subcuenta = Me.cboSubcuentaContacto.SelectedValue
                .Estado = IIf(Me.chkActivoContacto.Checked, 1, 2)
                .Usuario = dtoUSUARIOS.IdLogin
                .IP = dtoUSUARIOS.IP

                Dim intContacto As Integer = objLN.Grabar(objEN)
                'Actualizar comunicacion
                With Me.dgvComunicacionContacto
                    Dim intID As Integer, strNumero As String, intTipo As Integer, intEstado As Integer
                    For Each row As DataGridViewRow In Me.dgvComunicacionContacto.Rows
                        intID = IIf(IsDBNull(row.Cells("id").Value), 0, row.Cells("id").Value)
                        strNumero = row.Cells("numero").Value.ToString.Trim
                        intTipo = IIf(IsDBNull(row.Cells("idtipo").Value), 0, row.Cells("idtipo").Value)
                        intEstado = IIf(IsDBNull(row.Cells("estado").Value), 0, row.Cells("estado").Value)
                        objLN.GrabarComunicacion(intID, strNumero, intTipo, intContacto, intEstado)
                    Next
                End With

                MessageBox.Show("Contacto Actualizado", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ListarContactoCliente(.Cliente, Me.cboEstadoContacto.SelectedIndex)
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGrabarContacto_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabarContacto.Click
        If Me.cboSubcuentaContacto.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione Subcuenta del Contacto", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboSubcuentaContacto.Focus()
            Return
        End If
        If Me.cboCargoContacto.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Cargo del Contacto", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboCargoContacto.Focus()
            Return
        End If
        If Me.cboTipoDocumentoContacto.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Tipo de Documento del Contacto", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboTipoDocumentoContacto.Focus()
            Return
        End If
        If Me.txtNumeroContacto.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Nº de Documento", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumeroContacto.Text = ""
            Me.txtNumeroContacto.Focus()
            Return
        End If

        If Me.cboTipoDocumentoContacto.SelectedValue = 1 Then
            If Not fnValidarRUC(txtNumeroContacto.Text) Then
                MessageBox.Show("El RUC no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNumeroContacto.Focus()
                Return
            End If
        ElseIf Me.cboTipoDocumentoContacto.SelectedValue = 3 Then
            If txtNumeroContacto.Text.Trim.Length <> 8 Then
                MessageBox.Show("El DNI no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNumeroContacto.Text = txtNumeroContacto.Text.Trim
                txtNumeroContacto.Focus()
                Return
            End If
        Else
            If Me.cboTipoDocumentoContacto.SelectedValue <> 9 AndAlso txtNumeroContacto.Text.Trim.Length < 6 Then
                MessageBox.Show("El Nº de Documento no es Válido", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNumeroContacto.Text = txtNumeroContacto.Text.Trim
                txtNumeroContacto.Focus()
                Return
            End If
        End If

        If Me.cboTipoDocumentoContacto.SelectedValue = 1 Then 'ruc
            If Me.txtNombresContacto.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Razón Social del Contacto", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNombresContacto.Text = txtNombresContacto.Text.Trim()
                txtNombresContacto.Focus()
                Return
            End If
            If Me.txtEmailContacto.Text.Trim.Length > 0 Then
                If Not ValidarEMail(Me.txtEmailContacto.Text.Trim) Then
                    MessageBox.Show("Ingrese Email Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtEmailContacto.Focus()
                    Return
                End If
            End If
        Else
            If Me.txtNombresContacto.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nombres del Contacto", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNombresContacto.Text = txtNombresContacto.Text.Trim()
                txtNombresContacto.Focus()
                Return
            End If
            If Me.txtAPContacto.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Apellido Paterno", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtAPContacto.Text = txtAPCliente.Text.Trim
                txtAPContacto.Focus()
                Return
            End If
            If Me.txtEmailContacto.Text.Trim.Length > 0 Then
                If Not ValidarEMail(Me.txtEmailContacto.Text.Trim) Then
                    MessageBox.Show("Ingrese Email Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtEmailContacto.Focus()
                    Return
                End If
            End If
            If Me.rbtMasculinoContacto.Checked = False And Me.rbtFemeninoContacto.Checked = False Then
                MessageBox.Show("Seleccione Sexo del Contacto", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.rbtMasculinoContacto.Focus()
                Me.rbtMasculinoContacto.Checked = False
                Return
            End If
        End If
        Cursor = Cursors.WaitCursor
        GrabarContacto()
        ActivaDesactivaContacto(0, dgvContactos.Rows.Count)
        Cursor = Cursors.Default
        Me.btnNuevoContacto.Focus()
    End Sub

    Private Sub btnCancelarContacto_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelarContacto.Click
        LimpiarContacto()
        ActivaDesactivaContacto(0, dgvContactos.Rows.Count)
        If Me.dgvContactos.Rows.Count > 0 Then
            Dim intFila As Integer = Me.dgvContactos.CurrentCell.RowIndex
            MostrarContacto(intFila)
        End If
        If intOperacion = Operacion.Nuevo Then
            btnNuevoContacto.Focus()
        Else
            btnModificarContacto.Focus()
        End If
    End Sub

    Sub MostrarContacto(fila As Integer)
        Dim intTipoDocumento As Integer
        intTipoDocumento = Me.dgvContactos.Rows(fila).Cells("idtipo_documento").Value
        Me.cboTipoDocumentoContacto.SelectedValue = intTipoDocumento
        If intTipoDocumento = 1 Then
            Me.txtNombresContacto.Text = Me.dgvContactos.Rows(fila).Cells("nombres").Value.ToString.Trim
        Else
            Me.txtNombresContacto.Text = Me.dgvContactos.Rows(fila).Cells("nombre").Value.ToString.Trim
            Me.txtAPContacto.Text = Me.dgvContactos.Rows(fila).Cells("ap").Value.ToString.Trim
            Me.txtAMContacto.Text = Me.dgvContactos.Rows(fila).Cells("am").Value.ToString.Trim
        End If
        Me.txtNumeroContacto.Text = Trim(Me.dgvContactos.Rows(fila).Cells("numero_documento").Value)
        Me.cboCargoContacto.SelectedValue = Me.dgvContactos.Rows(fila).Cells("idcargo").Value
        Me.cboSubcuentaContacto.SelectedValue = Me.dgvContactos.Rows(fila).Cells("idsubcuenta").Value
        Me.txtEmailContacto.Text = Trim(Me.dgvContactos.Rows(fila).Cells("email").Value)
        If Not IsDBNull(Me.dgvContactos.Rows(fila).Cells("fecha_ingreso").Value) Then
            Me.dtpFechaIngresoContacto.Value = Me.dgvContactos.Rows(fila).Cells("fecha_ingreso").Value
        Else
            Me.dtpFechaIngresoContacto.Value = FechaServidor()
        End If
        If Me.dgvContactos.Rows(fila).Cells("sexo").Value = "M" Then
            Me.rbtMasculinoContacto.Checked = True
        ElseIf Me.dgvContactos.Rows(fila).Cells("sexo").Value = "F" Then
            Me.rbtFemeninoContacto.Checked = True
        Else
            Me.rbtMasculinoContacto.Checked = False
            Me.rbtFemeninoContacto.Checked = False
        End If
        Me.chkActivoContacto.Checked = IIf(Me.dgvContactos.Rows(fila).Cells("idestado").Value = 1, True, False)
        Me.ListarContactoComunicacion(Me.dgvContactos.Rows(fila).Cells("id").Value)
    End Sub

    Sub ListarContactoComunicacion(contacto As Integer)
        Dim objLN As New Cls_Contacto_LN()
        Dim dt As DataTable = objLN.ListarComunicacion(contacto)
        With Me.dgvComunicacionContacto
            .Rows.Clear()
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .Rows.Add()
                    Me.dgvComunicacionContacto(0, .Rows.Count - 1).Value = row.Item("id")
                    Me.dgvComunicacionContacto(1, .Rows.Count - 1).Value = row.Item("idtipo")
                    Me.dgvComunicacionContacto(2, .Rows.Count - 1).Value = row.Item("tipo")
                    Me.dgvComunicacionContacto(3, .Rows.Count - 1).Value = row.Item("numero")
                    Me.dgvComunicacionContacto(4, .Rows.Count - 1).Value = row.Item("estado")
                Next
            End If
        End With
    End Sub

    Private Sub dgvContactos_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvContactos.RowEnter
        If IsReference(dgvContactos.Rows(e.RowIndex).Cells("id").Value) Then Return
        Dim intFila As Integer = e.RowIndex
        MostrarContacto(intFila)
        Dim intContacto As Integer = Me.dgvContactos.Rows(intFila).Cells("id").Value
        ListarContactoComunicacion(intContacto)
    End Sub

    Private Sub CboDepartamento_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CboDepartamento.SelectedIndexChanged
        If IsReference(CboDepartamento.SelectedValue) Then Return
        Dim intDepartamento As Integer = CboDepartamento.SelectedValue
        ListarProvincia(intDepartamento)
    End Sub

    Private Sub CboProvincia_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles CboProvincia.SelectedIndexChanged
        If IsReference(CboProvincia.SelectedValue) Then Return
        Dim intDepartamento As Integer = CboDepartamento.SelectedValue
        Dim intProvincia As Integer = CboProvincia.SelectedValue
        ListarDistrito(intDepartamento, intProvincia)
    End Sub

    Private Sub dgvDirecciones_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDirecciones.RowEnter
        If IsReference(dgvDirecciones.Rows(e.RowIndex).Cells("id").Value) Then Return
        Dim intFila As Integer = e.RowIndex
        MostrarDireccion(intFila)
        Dim intDireccion As Integer = Me.dgvDirecciones.Rows(intFila).Cells("id").Value
        ListarContactoDireccion(intDireccion)
    End Sub

    Private Sub btnNuevoDireccion_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevoDireccion.Click
        intOperacion = Operacion.Nuevo
        Me.LimpiarDireccion()
        Me.chkActivoDireccion.Enabled = False
        ActivaDesactivaDireccion(1, dgvDirecciones.Rows.Count)
        Me.cboTipoDireccion.Focus()
        Me.cboTipoDireccion.DroppedDown = True
    End Sub

    Private Sub btnModificarDireccion_Click(sender As Object, e As System.EventArgs) Handles btnModificarDireccion.Click
        intOperacion = Operacion.Modificar
        Me.chkActivoDireccion.Enabled = True
        ActivaDesactivaDireccion(1, dgvDirecciones.Rows.Count)
        Me.cboTipoDireccion.Focus()
    End Sub

    Private Sub btnCancelarDireccion_Click(sender As Object, e As System.EventArgs) Handles btnCancelarDireccion.Click
        LimpiarDireccion()
        ActivaDesactivaDireccion(0, dgvDirecciones.Rows.Count)
        If Me.dgvDirecciones.Rows.Count > 0 Then
            Dim intFila As Integer = Me.dgvDirecciones.CurrentCell.RowIndex
            MostrarDireccion(intFila)
        End If
        If intOperacion = Operacion.Nuevo Then
            btnNuevoDireccion.Focus()
        Else
            btnModificarDireccion.Focus()
        End If
    End Sub

    Private Sub btnGrabarDireccion_Click(sender As Object, e As System.EventArgs) Handles btnGrabarDireccion.Click
        If Me.cboTipoDireccion.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Tipo de Dirección", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboTipoDireccion.Focus()
            Return
        End If
        If Me.CboDepartamento.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Departamento de la Dirección", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.CboDepartamento.Focus()
            Return
        End If
        If Me.CboProvincia.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Provincia de la Dirección", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.CboProvincia.Focus()
            Return
        End If
        If Me.CboDistrito.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Distrito de la Dirección", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboTipoDireccion.Focus()
            Return
        End If

        If Me.CboVia.SelectedValue = 0 And CboZona.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Tipo de Vía", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.CboVia.Focus()
            Return
        End If
        If Me.TxtVia.Text.Trim.Length = 0 And CboZona.SelectedValue = 0 Then
            MessageBox.Show("Ingrese Nombre de la Vía", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtVia.Text = ""
            Me.TxtVia.Focus()
            Return
        End If

        If Me.TxtNumero2.Text.Trim.Length = 0 And Me.TxtManzana.Text.Trim.Length = 0 And Me.TxtLote.Text.Trim.Length = 0 Then
            Dim sMje As String = ""
            Dim i As Integer
            If Me.TxtNumero2.Text.Trim.Length = 0 And CboVia.SelectedValue > 0 Then
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
            MessageBox.Show("Ingrese " & sMje, "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            MessageBox.Show("Ingrese Nombre del Nivel", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtNivel.Text = ""
            Me.TxtNivel.Focus()
            Return
        End If

        If Me.CboZona.SelectedValue > 0 AndAlso Me.TxtZona.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Nombre de la Zona", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtZona.Text = ""
            Me.TxtZona.Focus()
            Return
        End If

        If Me.CboClasificacion.SelectedValue > 0 AndAlso Me.TxtClasificacion.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Nombre de la Clasificación", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtClasificacion.Text = ""
            Me.TxtClasificacion.Focus()
            Return
        End If

        Cursor = Cursors.WaitCursor
        GrabarDireccion()
        ActivaDesactivaDireccion(0, dgvDirecciones.Rows.Count)
        Cursor = Cursors.Default
        Me.btnNuevoDireccion.Focus()
    End Sub

    Private Sub cboEstadoDireccion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstadoDireccion.SelectedIndexChanged
        If blnInicioDireccion Then Return
        If Me.dgvClientes.Rows.Count <= 0 Then Return
        Dim intCliente As Integer = Me.dgvClientes.CurrentRow.Cells("id").Value
        ListarDireccionCliente(intCliente, Me.cboEstadoDireccion.SelectedIndex)
        Me.btnModificarDireccion.Enabled = Me.dgvDirecciones.Rows.Count > 0
    End Sub

    Private Sub btnAgregarContacto_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarContacto.Click
        Dim frm As New FrmAgregarContacto
        frm.Cliente = Me.dgvClientes.CurrentRow.Cells("id").Value
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            AgregarContacto(frm)
        End If
    End Sub

    Private Sub btnEliminarContacto_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarContacto.Click
        With dgvContactoDireccion
            If .Rows.Count > 0 Then
                Dim dlgRespuesta As DialogResult = MessageBox.Show("¿Está Seguro de Desactivar el Contacto Seleccionado?", "Desactivar Contacto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                    If dgvContactoDireccion.CurrentRow.Cells("estado").Value = 0 Then
                        .Rows.Remove(.CurrentRow)
                    Else
                        dgvContactoDireccion.CurrentRow.Cells("estado").Value = 2
                        dgvContactoDireccion.CurrentRow.Visible = False
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub btnAgregarComunicacion_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarComunicacion.Click
        Dim frm As New FrmAgregarComunicacion
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            AgregarComunicacion(frm)
        End If
    End Sub

    Private Sub dgvComunicacionContacto_RowsAdded(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvComunicacionContacto.RowsAdded
        Me.btnEliminarComunicacion.Enabled = Me.dgvComunicacionContacto.Rows.Count > 0
    End Sub

    Private Sub dgvComunicacionContacto_RowsRemoved(sender As Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvComunicacionContacto.RowsRemoved
        Me.btnEliminarComunicacion.Enabled = Me.dgvComunicacionContacto.Rows.Count > 0
    End Sub

    Private Sub btnEliminarComunicacion_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarComunicacion.Click
        With dgvComunicacionContacto
            If .Rows.Count > 0 Then
                Dim dlgRespuesta As DialogResult = MessageBox.Show("¿Está Seguro de Desactivar el Tipo de Comunicación Seleccionado?", "Desactivar Tipo de Comunicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                    If dgvComunicacionContacto.CurrentRow.Cells("estado").Value = 0 Then
                        .Rows.Remove(.CurrentRow)
                    Else
                        dgvComunicacionContacto.CurrentRow.Cells("estado").Value = 2
                        dgvComunicacionContacto.CurrentRow.Visible = False
                    End If
                End If
            End If
        End With
    End Sub

    Sub AgregarComunicacion(frm As FrmAgregarComunicacion, Optional opcion As Integer = 1)
        If opcion = 1 Then
            Me.dgvComunicacionContacto.Rows.Add()
            Me.dgvComunicacionContacto(0, Me.dgvComunicacionContacto.Rows.Count - 1).Value = 0
            Me.dgvComunicacionContacto(1, Me.dgvComunicacionContacto.Rows.Count - 1).Value = frm.cboTipoComunicacion.SelectedValue
            Me.dgvComunicacionContacto(2, Me.dgvComunicacionContacto.Rows.Count - 1).Value = frm.cboTipoComunicacion.Text
            Me.dgvComunicacionContacto(3, Me.dgvComunicacionContacto.Rows.Count - 1).Value = frm.txtNumeroComunicacion.Text.Trim
            Me.dgvComunicacionContacto(4, Me.dgvComunicacionContacto.Rows.Count - 1).Value = 0
        Else
            Me.dgvComunicacionContacto.CurrentRow.Cells(1).Value = frm.cboTipoComunicacion.SelectedValue
            Me.dgvComunicacionContacto.CurrentRow.Cells(2).Value = frm.cboTipoComunicacion.Text
            Me.dgvComunicacionContacto.CurrentRow.Cells(3).Value = frm.txtNumeroComunicacion.Text.Trim
        End If
    End Sub
    Sub GrabarDireccion()
        Dim objLN As New Cls_Direccion_LN
        Dim objEN As New Cls_Direccion_EN

        Try
            With objEN
                If intOperacion = Operacion.Nuevo Then
                    .ID = 0
                Else
                    .ID = Me.dgvDirecciones.CurrentRow.Cells("id").Value
                End If
                .Tipo = Me.cboTipoDireccion.SelectedValue
                .Cliente = Me.dgvClientes.CurrentRow.Cells("id").Value

                'Dirección
                Dim sDireccion As String = IIf(CboVia.SelectedValue = 0, "", CboVia.Text) & " " & TxtVia.Text.Trim & " "
                If TxtNumero2.Text.Trim.Length > 0 Then
                    sDireccion &= TxtNumero2.Text.Trim & " "
                End If

                If TxtManzana.Text.Trim.Length > 0 Then
                    sDireccion &= "MZ " & TxtManzana.Text.Trim & " LT " & TxtLote.Text.Trim & " "
                End If

                If CboNivel.SelectedValue > 0 Then
                    sDireccion &= CboNivel.Text & " " & TxtNivel.Text.Trim & " "
                End If

                If CboZona.SelectedValue > 0 Then
                    sDireccion &= CboZona.Text & " " & TxtZona.Text.Trim & " "
                End If

                If CboClasificacion.SelectedValue > 0 Then
                    sDireccion &= CboClasificacion.Text & " " & TxtClasificacion.Text.Trim & " "
                End If

                If CboDistrito.SelectedValue > 0 Then
                    sDireccion &= CboDistrito.Text
                End If

                .Direccion = sDireccion
                .Referencia = Me.TxtReferencia.Text.Trim
                .DireccionFacturacion = IIf(Me.chkDireccionFacturacion.Checked, 1, 0)
                .Departamento = Me.CboDepartamento.SelectedValue
                .Provincia = Me.CboProvincia.SelectedValue
                .Distrito = Me.CboDistrito.SelectedValue
                .TipoVia = Me.CboVia.SelectedValue
                .Via = Me.TxtVia.Text.Trim
                .Numero = Me.TxtNumero2.Text.Trim
                .Manzana = Me.TxtManzana.Text.Trim
                .Lote = Me.TxtLote.Text.Trim
                .TipoNivel = Me.CboNivel.SelectedValue
                .Nivel = Me.TxtNivel.Text.Trim
                .TipoZona = Me.CboZona.SelectedValue
                .Zona = Me.TxtZona.Text.Trim
                .TipoClasificacion = Me.CboClasificacion.SelectedValue
                .Clasificacion = Me.TxtClasificacion.Text.Trim
                .Estado = IIf(Me.chkActivoDireccion.Checked, 1, 2)
                .Usuario = dtoUSUARIOS.IdLogin
                .IP = dtoUSUARIOS.IP

                Dim intDireccion As Integer = objLN.Grabar(objEN)
                'Actualizar contactos
                With Me.dgvContactoDireccion
                    Dim intID As Integer, strCentroCosto As String, intContacto As Integer, intEstado As Integer
                    For Each row As DataGridViewRow In Me.dgvContactoDireccion.Rows
                        intID = intDireccion
                        strCentroCosto = 999
                        intContacto = IIf(IsDBNull(row.Cells("id").Value), 0, row.Cells("id").Value)
                        intEstado = IIf(IsDBNull(row.Cells("estado").Value), 0, row.Cells("estado").Value)
                        objLN.GrabarContacto(intID, strCentroCosto, intContacto, intEstado)
                    Next
                End With

                MessageBox.Show("Dirección Actualizada", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ListarDireccionCliente(.Cliente, Me.cboEstadoDireccion.SelectedIndex)
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub AgregarContacto(frm As FrmAgregarContacto)
        Me.dgvContactoDireccion.Rows.Add()
        Me.dgvContactoDireccion(0, Me.dgvContactoDireccion.Rows.Count - 1).Value = frm.dgvContactos.CurrentRow.Cells("id").Value
        Me.dgvContactoDireccion(1, Me.dgvContactoDireccion.Rows.Count - 1).Value = frm.dgvContactos.CurrentRow.Cells("cargo").Value
        Me.dgvContactoDireccion(2, Me.dgvContactoDireccion.Rows.Count - 1).Value = frm.dgvContactos.CurrentRow.Cells("nombres").Value
        Me.dgvContactoDireccion(3, Me.dgvContactoDireccion.Rows.Count - 1).Value = 0
    End Sub

    Private Sub cboEstadoContacto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstadoContacto.SelectedIndexChanged
        If blnInicioContacto Then Return
        If Me.dgvClientes.Rows.Count <= 0 Then Return
        Dim intCliente As Integer = Me.dgvClientes.CurrentRow.Cells("id").Value
        ListarContactoCliente(intCliente, Me.cboEstadoContacto.SelectedIndex)
        Me.btnModificarContacto.Enabled = Me.dgvContactos.Rows.Count > 0
    End Sub

    Private Sub txtNumeroDocumento_Enter(sender As Object, e As System.EventArgs) Handles txtNumeroDocumento.Enter
        Me.txtNumeroDocumento.SelectAll()
    End Sub

    Private Sub txtNumeroDocumento_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumeroDocumento.TextChanged
        RemoveHandler txtRazonSocial.TextChanged, AddressOf txtRazonSocial_TextChanged
        Me.txtRazonSocial.Text = ""
        AddHandler txtRazonSocial.TextChanged, AddressOf txtRazonSocial_TextChanged
    End Sub

    Private Sub txtRazonSocial_Enter(sender As Object, e As System.EventArgs) Handles txtRazonSocial.Enter
        Me.txtRazonSocial.SelectAll()
    End Sub

    Private Sub txtRazonSocial_TextChanged(sender As Object, e As System.EventArgs) Handles txtRazonSocial.TextChanged
        RemoveHandler txtNumeroDocumento.TextChanged, AddressOf txtNumeroDocumento_TextChanged
        Me.txtNumeroDocumento.Text = ""
        AddHandler txtNumeroDocumento.TextChanged, AddressOf txtNumeroDocumento_TextChanged
    End Sub

    Private Sub cboTipoPersona_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoPersona.SelectedIndexChanged
        Me.txtNumero.Enabled = True
        Me.cboTipoDocumento.Enabled = False
        If Me.cboTipoPersona.SelectedIndex = TipoPersona.JURIDICA Then
            Me.cboTipoDocumento.SelectedValue = 1
            Me.cboTipoDocumento.Enabled = False
            Me.txtNumero.MaxLength = 11
            Me.LblCliente.Text = "Raz. Soc."
            Me.LblApep.Visible = False
            Me.LblApeM.Visible = False
            Me.txtAPCliente.Visible = False
            Me.txtAMCliente.Visible = False
            'Me.LblCliente.Top = 68
            'Me.txtCliente.Top = 65
            Me.lblTipoDocumento.Top = 75
            Me.cboTipoDocumento.Top = 72
            Me.lblNumero.Top = 75
            Me.txtNumero.Top = 72

            Me.txtAPCliente.Text = ""
            Me.txtAMCliente.Text = ""
            pnlClienteJuridico.Visible = True
            pnlClienteNatural.Visible = False
            pnlClienteJuridico.Top = 97
            GrbCliente.Height = 181
        Else
            Me.cboTipoDocumento.SelectedValue = 1
            Me.LblCliente.Text = "Nombres"
            'Me.LblCliente.Top = 54
            'Me.txtCliente.Top = 51
            Me.lblTipoDocumento.Top = 102
            Me.cboTipoDocumento.Top = 98
            Me.lblNumero.Top = 102
            Me.txtNumero.Top = 98

            Me.LblApep.Visible = True
            Me.LblApeM.Visible = True
            Me.txtAPCliente.Visible = True
            Me.txtAMCliente.Visible = True
            pnlClienteJuridico.Visible = False
            pnlClienteNatural.Visible = True
            GrbCliente.Height = 209
        End If
        Me.txtCliente.Text = Me.txtCliente.Text.Trim
        Me.txtCliente.Focus()
    End Sub

    Private Sub txtCliente_Enter(sender As Object, e As System.EventArgs) Handles txtCliente.Enter, txtEmail.Enter
        txtCliente.SelectAll()
    End Sub
    Private Sub txtCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente.KeyPress, txtEmail.KeyPress
        If Me.cboTipoPersona.SelectedIndex = TipoPersona.JURIDICA Then
            If Not ValidarLetraNumero(e.KeyChar) Then
                e.Handled = True
            End If
        Else
            If Not ValidarLetra(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtAPCliente_Enter(sender As Object, e As System.EventArgs) Handles txtAPCliente.Enter
        txtAPCliente.SelectAll()
    End Sub
    Private Sub txtAPCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAPCliente.KeyPress
        If Not ValidarLetra(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtAMCliente_Enter(sender As Object, e As System.EventArgs) Handles txtAMCliente.Enter
        txtAMCliente.SelectAll()
    End Sub
    Private Sub txtAMCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAMCliente.KeyPress
        If Not ValidarLetra(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNumero_Enter(sender As Object, e As System.EventArgs) Handles txtNumero.Enter
        txtNumero.SelectAll()
    End Sub

    Private Sub txtNumero_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        If Me.cboTipoDocumento.SelectedValue = 1 Then
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        Else
            If Not ValidarLetraNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtDescuento_Enter(sender As Object, e As System.EventArgs) Handles txtDescuento.Enter
        Me.txtDescuento.SelectAll()
    End Sub

    Private Sub txtDescuento_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescuento.KeyPress
        Dim tb As TextBox = CType(sender, TextBox)
        Dim chr As Char = e.KeyChar
        If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
            e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
        ElseIf e.KeyChar = "." Then
            If Not (tb.SelectedText = ".") Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            End If
        ElseIf e.KeyChar = "-" Then
            If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
                e.Handled = True
            End If
        ElseIf Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDescuento_LostFocus(sender As Object, e As System.EventArgs) Handles txtDescuento.LostFocus
        Dim dblDescuento As Double = IIf(Me.txtDescuento.Text.Trim.Length = 0, 0, Me.txtDescuento.Text.Trim)
        Me.txtDescuento.Text = Format(dblDescuento, "0.00")
    End Sub

    Private Sub txtSerieDocumento_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerieDocumento.KeyPress
        If Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtUsuarioWeb_Enter(sender As Object, e As System.EventArgs) Handles txtUsuarioWeb.Enter
        Me.txtUsuarioWeb.SelectAll()
    End Sub

    Private Sub txtContraseñaWeb_Enter(sender As Object, e As System.EventArgs) Handles txtContraseñaWeb.Enter
        Me.txtContraseñaWeb.SelectAll()
    End Sub

    Private Sub cboTipoDocumentoContacto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoDocumentoContacto.SelectedIndexChanged
        If IsReference(Me.cboTipoDocumentoContacto.SelectedValue) Then Return
        If cboTipoDocumentoContacto.SelectedValue = 0 Then
            Me.txtNumeroContacto.Text = ""
            Me.txtNumeroContacto.Enabled = False
        Else
            Me.txtNumeroContacto.Text = ""
            Me.txtNumeroContacto.Enabled = True
        End If
        If Me.cboTipoDocumentoContacto.SelectedValue = 1 Then 'ruc
            Me.lblAPContacto.Visible = False : Me.lblAMContacto.Visible = False
            Me.txtAPContacto.Visible = False : Me.txtAMContacto.Visible = False
            Me.txtAPContacto.Text = "" : Me.txtAMContacto.Text = ""
            Me.rbtMasculinoContacto.Visible = False : Me.rbtFemeninoContacto.Visible = False : Me.lblSexoContacto.Visible = False
            Me.lblEmailContacto.Top = 104 : Me.txtEmailContacto.Top = 101
            Me.txtNumeroContacto.MaxLength = 11
        Else
            Me.lblAPContacto.Visible = True : Me.lblAMContacto.Visible = True
            Me.txtAPContacto.Visible = True : Me.txtAMContacto.Visible = True
            Me.rbtMasculinoContacto.Visible = True : Me.rbtFemeninoContacto.Visible = True : Me.lblSexoContacto.Visible = True
            Me.rbtMasculinoContacto.Checked = False : Me.rbtFemeninoContacto.Checked = False
            Me.lblEmailContacto.Top = 130 : Me.txtEmailContacto.Top = 127
            Me.txtNumeroContacto.MaxLength = 15
        End If
    End Sub

    Private Sub txtNumeroContacto_Enter(sender As Object, e As System.EventArgs) Handles txtNumeroContacto.Enter
        txtNumeroContacto.SelectAll()
    End Sub

    Private Sub txtNumeroContacto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroContacto.KeyPress
        If Me.cboTipoDocumentoContacto.SelectedValue = 1 Then
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        Else
            If Not ValidarLetraNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtEmailContacto_Enter(sender As Object, e As System.EventArgs) Handles txtEmailContacto.Enter
        Me.txtEmailContacto.SelectAll()
    End Sub

    Private Sub dgvComunicacionContacto_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvComunicacionContacto.DoubleClick
        If Me.dgvComunicacionContacto.Rows.Count > 0 Then
            Dim frm As New FrmAgregarComunicacion
            frm.intOpcion = 2
            frm.TipoComunicacion = Me.dgvComunicacionContacto.CurrentRow.Cells("idtipo").Value
            frm.NumeroComunicacion = Me.dgvComunicacionContacto.CurrentRow.Cells("numero").Value
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                AgregarComunicacion(frm, 2)
            End If
        End If
    End Sub

    Private Sub dgvContactoDireccion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvContactoDireccion.KeyDown
        If e.KeyCode = Keys.Delete Then
            If dgvContactoDireccion.Rows.Count > 0 Then
                btnEliminarContacto_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub dgvContactoDireccion_RowsAdded(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvContactoDireccion.RowsAdded
        Me.btnEliminarContacto.Enabled = Me.dgvContactoDireccion.Rows.Count > 0
    End Sub

    Private Sub dgvContactoDireccion_RowsRemoved(sender As Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvContactoDireccion.RowsRemoved
        Me.btnEliminarContacto.Enabled = Me.dgvContactoDireccion.Rows.Count > 0
    End Sub

    Function ObtieneSituacionCliente(cliente As Integer, funcionario As Integer) As Integer
        Dim obj As New Cls_Cliente_LN
        Return obj.ObtieneSituacionCliente(cliente, funcionario)
    End Function

    Sub SituacionCliente()
        Dim intFicha As Integer
        If tabGestionCliente.SelectedTab Is tabGestionCliente.TabPages("tabFicha") Then
            intFicha = 1
        ElseIf tabGestionCliente.SelectedTab Is tabGestionCliente.TabPages("tabContacto") Then
            intFicha = 2
        ElseIf tabGestionCliente.SelectedTab Is tabGestionCliente.TabPages("tabDireccion") Then
            intFicha = 3
        End If

        If intFicha = 1 Then
            Me.GrbCliente.Enabled = False
            Me.grbClienteCorporativo.Enabled = False
            Me.grbDescuento.Enabled = False
            Me.grbSerieDocumento.Enabled = False
            Me.grbAccesoWeb.Enabled = False
            Me.grbProducto.Enabled = False
        ElseIf intFicha = 2 Then
            Me.btnNuevoContacto.Enabled = False
            Me.btnModificarContacto.Enabled = False
        Else
            Me.btnNuevoDireccion.Enabled = False
            Me.btnModificarDireccion.Enabled = False
        End If

        If intPerfil = 1 Then 'cartera,lectura,escritura y asignacion jefe producto
            If intSituacion = 1 Then 'cliente no tiene asignacion
                If intFicha = 1 Then
                    Me.grbProducto.Enabled = True
                End If
            ElseIf intSituacion = 2 Then 'cliente esta asignado a funcionario
                If intFicha = 1 Then
                    Me.GrbCliente.Enabled = True
                    Me.grbClienteCorporativo.Enabled = True
                    Me.grbDescuento.Enabled = True
                    Me.grbSerieDocumento.Enabled = True
                    Me.grbAccesoWeb.Enabled = True
                    Me.grbProducto.Enabled = True
                ElseIf intFicha = 2 Then
                    Me.btnNuevoContacto.Enabled = True
                    Me.btnModificarContacto.Enabled = Me.dgvContactos.Rows.Count > 0
                ElseIf intFicha = 3 Then
                    Me.btnNuevoDireccion.Enabled = True
                    Me.btnModificarDireccion.Enabled = Me.dgvDirecciones.Rows.Count > 0
                End If
            Else 'cliente esta asignado a otro funcionario
                'no hace nada
            End If
        ElseIf intPerfil = 2 Then 'cartera,lectura,escritura y asignacion sistemas
            If intFicha = 1 Then
                Me.GrbCliente.Enabled = True
                Me.grbClienteCorporativo.Enabled = True
                Me.grbDescuento.Enabled = True
                Me.grbSerieDocumento.Enabled = True
                Me.grbAccesoWeb.Enabled = True
                Me.grbProducto.Enabled = True
            ElseIf intFicha = 2 Then
                Me.btnNuevoContacto.Enabled = True
                Me.btnModificarContacto.Enabled = Me.dgvContactos.Rows.Count > 0
            ElseIf intFicha = 3 Then
                Me.btnNuevoDireccion.Enabled = True
                Me.btnModificarDireccion.Enabled = Me.dgvDirecciones.Rows.Count > 0
            End If
        ElseIf intPerfil = 3 Then 'lectura,escritura fiscalizacion
            If intSituacion = 1 Or intSituacion = 2 Then 'cliente no tiene asignacion
                If intFicha = 1 Then
                    Me.GrbCliente.Enabled = True
                    Me.grbClienteCorporativo.Enabled = True
                    Me.grbDescuento.Enabled = True
                    Me.grbSerieDocumento.Enabled = True
                    Me.grbAccesoWeb.Enabled = True
                ElseIf intFicha = 2 Then
                    Me.btnNuevoContacto.Enabled = True
                    Me.btnModificarContacto.Enabled = Me.dgvContactos.Rows.Count > 0
                ElseIf intFicha = 3 Then
                    Me.btnNuevoDireccion.Enabled = True
                    Me.btnModificarDireccion.Enabled = Me.dgvDirecciones.Rows.Count > 0
                End If
            Else 'cliente esta asignado a otro funcionario
                'no hace nada
            End If
        Else 'lectura el resto
        End If
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtNombresContacto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombresContacto.KeyPress
        If Me.cboTipoDocumentoContacto.SelectedValue = 1 Then
            If Not ValidarLetraNumero(e.KeyChar) Then
                e.Handled = True
            End If
        Else
            If Not ValidarLetra(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtNombresContacto_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNombresContacto.TextChanged

    End Sub

    Private Sub txtAPContacto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAPContacto.KeyPress
        If Me.cboTipoDocumentoContacto.SelectedValue = 1 Then
            If Not ValidarLetraNumero(e.KeyChar) Then
                e.Handled = True
            End If
        Else
            If Not ValidarLetra(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtAPContacto_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAPContacto.TextChanged

    End Sub

    Private Sub txtAMContacto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAMContacto.KeyPress
        If Me.cboTipoDocumentoContacto.SelectedValue = 1 Then
            If Not ValidarLetraNumero(e.KeyChar) Then
                e.Handled = True
            End If
        Else
            If Not ValidarLetra(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtAMContacto_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAMContacto.TextChanged

    End Sub
End Class