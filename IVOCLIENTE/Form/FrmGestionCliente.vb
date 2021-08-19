Imports INTEGRACION_LN
Imports INTEGRACION_EN

Public Class FrmGestionCliente
    Dim intOperacion As Operacion                   'solicitud cliente a cartera

    Dim blnInicioProducto As Boolean = False, blnInicioCliente As Boolean = False, blnInicioContacto As Boolean = False, blnInicioDireccion As Boolean = False
    Dim blnInicioCargo As Boolean = False
    Dim intFilaDGVClienteProducto As Integer = 0, intFilaDGVClienteCargo As Integer = 0

    'linea de credito
    Dim colClienteCredito As New Collection
    Dim autoClienteCredito As New AutoCompleteStringCollection

    Shared strNumero As String = ""
    Public hnd As Long              'gestion de clientes

#Region "Cliente"
#Region "Configurar Grid"
    Private Sub ConfigurarDGVAcuerdoCliente()
        With dgvAcuerdoCliente
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
            Dim col_idproducto As New DataGridViewTextBoxColumn
            With col_idproducto
                .Name = "idproducto" : .DataPropertyName = "idproducto"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idproducto"
            End With
            x += +1
            Dim col_producto As New DataGridViewTextBoxColumn
            With col_producto
                .Name = "producto" : .DataPropertyName = "producto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Producto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_idsubcuenta As New DataGridViewTextBoxColumn
            With col_idsubcuenta
                .Name = "idsubcuenta" : .DataPropertyName = "idsubcuenta"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idsubcuenta"
            End With
            x += +1
            Dim col_subcuenta As New DataGridViewTextBoxColumn
            With col_subcuenta
                .Name = "subcuenta" : .DataPropertyName = "subcuenta"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subcuenta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_idorigen As New DataGridViewTextBoxColumn
            With col_idorigen
                .Name = "idorigen" : .DataPropertyName = "idorigen"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idorigen"
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Orígen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_iddestino As New DataGridViewTextBoxColumn
            With col_iddestino
                .Name = "iddestino" : .DataPropertyName = "iddestino"
                .DisplayIndex = x : .Visible = False : .HeaderText = "iddestino"
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_idtipo_tarifa As New DataGridViewTextBoxColumn
            With col_idtipo_tarifa
                .Name = "idtipo_tarifa" : .DataPropertyName = "idtipo_tarifa"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo_tarifa"
            End With
            x += +1
            Dim col_tipo_tarifa As New DataGridViewTextBoxColumn
            With col_tipo_tarifa
                .Name = "tipo_tarifa" : .DataPropertyName = "tipo_tarifa"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Tarifa"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_retorno As New DataGridViewTextBoxColumn
            With col_retorno
                .Name = "retorno" : .DataPropertyName = "retorno"
                .DisplayIndex = x : .Visible = False : .HeaderText = "retorno"
            End With
            x += +1
            Dim col_tiempo As New DataGridViewTextBoxColumn
            With col_tiempo
                .Name = "tiempo" : .DataPropertyName = "tiempo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Días Tránsito"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
            End With

            .Columns.AddRange(col_id, col_idproducto, col_producto, col_idsubcuenta, col_subcuenta, col_idorigen, col_origen, col_iddestino, _
                              col_destino, col_idtipo_tarifa, col_tipo_tarifa, col_retorno, col_tiempo, col_estado)
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
            .Columns.AddRange(col_id, col_idsubcuenta, col_subcuenta, col_nombres, col_idcargo, col_cargo, col_nombre, col_ap, col_am, _
                              col_idtipo_documento, col_tipo_documento, col_numero_documento, col_email, col_sexo, col_estado, col_idestado)
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
#End Region
#Region "Ficha"
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
                Me.dtpFechaNacimiento.Value = dt.Rows(0).Item("fecha_nacimiento").ToString
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
            Me.chkBaseArticulo.Checked = CType(dt.Rows(0).Item("base_articulo").ToString, Boolean)
            Me.chkPagoPostfacturacion.Checked = CType(dt.Rows(0).Item("pago_post_facturacion").ToString, Boolean)
            Me.chkConsignado.Checked = CType(dt.Rows(0).Item("consignado").ToString, Boolean)
            Me.cboRubroCliente.SelectedValue = CType(dt.Rows(0).Item("idrubro").ToString, Integer)
            Me.cboClasificacionCliente.SelectedValue = CType(dt.Rows(0).Item("idclasificacion_persona").ToString, Integer)
            Me.cboFuente.SelectedValue = CType(dt.Rows(0).Item("fuente").ToString, Integer)

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
        Me.chkBaseArticulo.Checked = False
        Me.chkPagoPostfacturacion.Checked = False
        Me.chkConsignado.Checked = False
        Me.cboRubroCliente.SelectedValue = 0
        Me.cboClasificacionCliente.SelectedValue = 2
        Me.cboFuente.SelectedValue = 0
        Me.txtDescuento.Text = ""
        Me.txtSerieDocumento.Text = ""
        Me.txtUsuarioWeb.Text = ""
        Me.txtContraseñaWeb.Text = ""
        Me.cboTipoPersona.Enabled = True
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
            Else
                Me.grbDescuento.Enabled = False
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

        ActivaDesactivaCliente(0, dgvClientes.Rows.Count)
    End Sub

    Private Sub btnNuevoCliente_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevoCliente.Click
        intOperacion = Operacion.Nuevo
        Me.LimpiarCliente()
        ActivaDesactivaCliente(1, dgvClientes.Rows.Count)
        Me.txtCliente.Focus()
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
    Private Sub btnModificarCliente_Click(sender As Object, e As System.EventArgs) Handles btnModificarCliente.Click
        intOperacion = Operacion.Modificar
        Me.cboTipoPersona.Enabled = False
        ActivaDesactivaCliente(1, dgvClientes.Rows.Count)
        Me.txtCliente.Focus()
    End Sub

#End Region
#Region "Contacto"
    Sub InicioDatoAdicional()
        Dim obj As New UtilData_LN
        Dim dt As DataTable = obj.ListarProducto
        With cboProductoCliente
            .DataSource = Nothing
            .DataSource = dt
            .DisplayMember = "procesos"
            .ValueMember = "idprocesos"
        End With
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
    Sub LimpiarContacto()
        Me.cboSubcuentaContacto.SelectedValue = 999
        Me.cboCargoContacto.SelectedValue = 0
        Me.cboTipoDocumentoContacto.SelectedValue = 0
        Me.txtNumeroContacto.Text = ""
        Me.txtNombresContacto.Text = ""
        Me.txtAPContacto.Text = ""
        Me.txtAMContacto.Text = ""
        Me.txtEmailContacto.Text = ""
        Me.rbtMasculinoContacto.Checked = False
        Me.rbtFemeninoContacto.Checked = False
        Me.chkActivoContacto.Checked = True
        Me.cboEstadoContacto.SelectedIndex = 1
        Me.dgvComunicacionContacto.Rows.Clear()
        'Me.dgvComunicacionContacto.DataSource = Nothing
        'Me.dgvComunicacionContacto.Rows.Add()
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
            Me.btnNuevoContacto.Enabled = Me.dgvClientes.Rows.Count > 0
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
    Sub ListarContactoCliente(cliente As Integer, estado As Integer)
        Dim objLN As New Cls_Contacto_LN
        Dim dt As DataTable = objLN.ListarContacto(cliente, estado)
        dgvContactos.DataSource = dt
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
        If Me.dgvContactos.Rows(fila).Cells("sexo").Value = "M" Then
            Me.rbtMasculinoContacto.Checked = True
        ElseIf Me.dgvContactos.Rows(fila).Cells("sexo").Value = "F" Then
            Me.rbtFemeninoContacto.Checked = True
        Else
            Me.rbtMasculinoContacto.Checked = False
            Me.rbtFemeninoContacto.Checked = False
        End If
        Me.chkActivoContacto.Checked = IIf(Me.dgvContactos.Rows(fila).Cells("idestado").Value = 1, True, False)
        Me.ListarContactoComunicacion(Me.dgvContactos.Rows(fila).Cells("id").Value, Me.dgvComunicacionContacto)
    End Sub
    Sub ListarContactoComunicacion(contacto As Integer, dgv As DataGridView)
        Dim objLN As New Cls_Contacto_LN()
        Dim dt As DataTable = objLN.ListarComunicacion(contacto)
        With dgv
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
        ListarContactoComunicacion(intContacto, Me.dgvComunicacionContacto)
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
#End Region
#Region "Direccion"
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
    Sub AgregarContacto(frm As FrmAgregarContacto)
        Me.dgvContactoDireccion.Rows.Add()
        Me.dgvContactoDireccion(0, Me.dgvContactoDireccion.Rows.Count - 1).Value = frm.dgvContactos.CurrentRow.Cells("id").Value
        Me.dgvContactoDireccion(1, Me.dgvContactoDireccion.Rows.Count - 1).Value = frm.dgvContactos.CurrentRow.Cells("cargo").Value
        Me.dgvContactoDireccion(2, Me.dgvContactoDireccion.Rows.Count - 1).Value = frm.dgvContactos.CurrentRow.Cells("nombres").Value
        Me.dgvContactoDireccion(3, Me.dgvContactoDireccion.Rows.Count - 1).Value = 0
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
            Me.btnNuevoDireccion.Enabled = Me.dgvClientes.Rows.Count > 0
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
#End Region
#Region "Administrador"
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
                    .Consignado = IIf(Me.chkConsignado.Checked, 1, 0)
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
                .BaseArticulo = IIf(Me.chkBaseArticulo.Checked, 1, 0)
                .ClasificacionEmpresa = Me.cboClasificacionCliente.SelectedValue
                .Fuente = Me.cboFuente.SelectedValue

                .RubroEmpresarial = Me.cboRubroCliente.SelectedValue
                .Descuento = IIf(Me.txtDescuento.Text.Trim.Length = 0, 0, Me.txtDescuento.Text)
                .DigitosSerie = IIf(Me.txtSerieDocumento.Text.Trim.Length = 0, 3, Me.txtSerieDocumento.Text)
                .UsuarioWeb = IIf(Me.txtUsuarioWeb.Text.Trim.Length = 0, "", Me.txtUsuarioWeb.Text.Trim)
                .Contraseña = IIf(Me.txtContraseñaWeb.Text.Trim.Length = 0, "", Me.txtContraseñaWeb.Text.Trim)

                .Usuario = dtoUSUARIOS.IdLogin
                .IP = dtoUSUARIOS.IP

                objLN.Grabar(objEN)

                Dim strMensaje As String = IIf(intOperacion = Operacion.Nuevo, "Cliente Registrado", "Cliente Actualizado")
                MessageBox.Show(strMensaje, "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnGrabarCliente_Click(sender As Object, e As System.EventArgs) Handles btnGrabarCliente.Click
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

        If Me.cboFuente.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Fuente del Cliente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboFuente.Focus()
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
    Sub InicioCliente()
        ConfigurarDGVClientes()
        ConfigurarDGVAcuerdoCliente()
        Dim intUsuario As Integer = 0
        If Me.cboFuncionario.Tag = "*" Then
            intUsuario = dtoUSUARIOS.IdLogin
        End If
        ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.cboFuncionario, "", "", 3, " (SELECCIONE)", intUsuario)

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

        Dim obj1 As New Cls_Televenta_LN
        With cboFuente
            .DisplayMember = "nombre"
            .ValueMember = "id"
            .DataSource = obj1.ListarFuente
            .SelectedValue = 0
        End With

        Me.cboTipoPersona.SelectedIndex = 0
        Me.LimpiarCliente()
        ActivaDesactivaCliente(-1, Me.dgvClientes.Rows.Count)

        blnInicioCliente = True
        Me.btnNuevoCliente.Focus()
    End Sub
    Private Sub tabClientes_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabClientes.SelectedIndexChanged
        If tabClientes.SelectedTab Is tabClientes.TabPages("tabFicha") Then
            'InicioCliente()
        ElseIf tabClientes.SelectedTab Is tabClientes.TabPages("tabContacto") Then
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
        ElseIf tabClientes.SelectedTab Is tabClientes.TabPages("tabDireccion") Then
            If Me.dgvClientes.Rows.Count = 0 Then Return
            Me.LimpiarDireccion()
            Me.lblCodigoClienteDireccion.Text = Me.dgvClientes.CurrentRow.Cells("codigo").Value
            Me.lblrazonSocialClienteDireccion.Text = Me.dgvClientes.CurrentRow.Cells("cliente").Value

            Dim intCliente As Integer = Me.dgvClientes.CurrentRow.Cells("id").Value
            ListarDireccionCliente(intCliente, Me.cboEstadoDireccion.SelectedIndex)
            ActivaDesactivaDireccion(-1, Me.dgvDirecciones.Rows.Count)
        ElseIf tabClientes.SelectedTab Is tabClientes.TabPages("tabDatoAdicional") Then
            InicioDatoAdicional()
        End If
    End Sub
#End Region
#End Region

#Region "Consulta"
#Region "Configurar Grid"
    Private Sub ConfigurarDGVCargoConsulta()
        With dgvCargoConsulta
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
            End With
            x += +1
            Dim col_subcuenta As New DataGridViewTextBoxColumn
            With col_subcuenta
                .Name = "subcuenta" : .DataPropertyName = "subcuenta"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subcuenta"
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
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
            End With

            .Columns.AddRange(col_id, col_idsubcuenta, col_subcuenta, col_idcargo, col_cargo, col_estado)
        End With
    End Sub
    Private Sub ConfigurarDGVClientesConsulta()
        With dgvClientesConsulta
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
    Private Sub ConfigurarDGVContactoConsulta()
        With dgvContactoConsulta
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
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            x += +1
            Dim col_cargo As New DataGridViewTextBoxColumn
            With col_cargo
                .Name = "cargo" : .DataPropertyName = "cargo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_nombres As New DataGridViewTextBoxColumn
            With col_nombres
                .Name = "nombres" : .DataPropertyName = "nombres"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Contacto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_documento As New DataGridViewTextBoxColumn
            With col_documento
                .Name = "documento" : .DataPropertyName = "documento"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_email As New DataGridViewTextBoxColumn
            With col_email
                .Name = "email" : .DataPropertyName = "email"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Correo Electrónico"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            .Columns.AddRange(col_cargo, col_nombres, col_documento, col_email)
        End With
    End Sub
    Private Sub ConfigurarDGVDireccionConsulta()
        With dgvDireccionConsulta
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
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_facturacion As New DataGridViewTextBoxColumn
            With col_facturacion
                .Name = "facturacion" : .DataPropertyName = "facturacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "¿Facturación?"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            x += +1
            Dim col_direccion As New DataGridViewTextBoxColumn
            With col_direccion
                .Name = "direccion" : .DataPropertyName = "direccion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Dirección"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            .Columns.AddRange(col_tipo, col_direccion, col_facturacion)
        End With
    End Sub
    Private Sub ConfigurarDGVCarteraConsulta()
        With dgvCarteraConsulta
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
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_responsable As New DataGridViewTextBoxColumn
            With col_responsable
                .Name = "responsable" : .DataPropertyName = "responsable"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Funcionario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_fecha_inicio As New DataGridViewTextBoxColumn
            With col_fecha_inicio
                .Name = "fecha_inicio" : .DataPropertyName = "fecha_inicio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Inicio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            x += +1
            Dim col_fecha_fin As New DataGridViewTextBoxColumn
            With col_fecha_fin
                .Name = "fecha_fin" : .DataPropertyName = "fecha_fin"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Fin"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            .Columns.AddRange(col_responsable, col_fecha_inicio, col_fecha_fin, col_estado)
        End With
    End Sub
    Private Sub ConfigurarDGVProductoConsulta()
        With dgvProductoConsulta
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
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_subcuenta As New DataGridViewTextBoxColumn
            With col_subcuenta
                .Name = "subcuenta" : .DataPropertyName = "subcuenta"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subcuenta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Orígen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            x += +1
            Dim col_producto As New DataGridViewTextBoxColumn
            With col_producto
                .Name = "producto" : .DataPropertyName = "producto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Producto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_fecha_inicio As New DataGridViewTextBoxColumn
            With col_fecha_inicio
                .Name = "fecha_inicio" : .DataPropertyName = "fecha_inicio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Inicio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_fecha_fin As New DataGridViewTextBoxColumn
            With col_fecha_fin
                .Name = "fecha_fin" : .DataPropertyName = "fecha_fin"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Fin"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            .Columns.AddRange(col_subcuenta, col_origen, col_destino, col_producto, col_fecha_inicio, col_fecha_fin, col_estado)
        End With
    End Sub
    Private Sub ConfigurarDGVCreditoConsulta()
        With dgvCreditoConsulta
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
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_fecha_aprobacion As New DataGridViewTextBoxColumn
            With col_fecha_aprobacion
                .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aprobación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "dd/MM/yyyy"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_linea_credito As New DataGridViewTextBoxColumn
            With col_linea_credito
                .Name = "linea_credito" : .DataPropertyName = "linea_credito"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Linea Crédito"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "#,###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_sobregiro As New DataGridViewTextBoxColumn
            With col_sobregiro
                .Name = "sobregiro" : .DataPropertyName = "sobregiro"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Sobregiro"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "#,###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_saldo As New DataGridViewTextBoxColumn
            With col_saldo
                .Name = "saldo" : .DataPropertyName = "saldo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Saldo Actual"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "#,###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_fecha_desactivacion As New DataGridViewTextBoxColumn
            With col_fecha_desactivacion
                .Name = "fecha_desactivacion" : .DataPropertyName = "fecha_desactivacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Desactivación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            x += +1
            Dim col_fecha_cancelacion As New DataGridViewTextBoxColumn
            With col_fecha_cancelacion
                .Name = "fecha_cancelacion" : .DataPropertyName = "fecha_cancelacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Cancelación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            x += +1
            Dim col_fecha_activacion As New DataGridViewTextBoxColumn
            With col_fecha_activacion
                .Name = "fecha_activacion" : .DataPropertyName = "fecha_activacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Activación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With

            .Columns.AddRange(col_fecha_aprobacion, col_fecha_desactivacion, col_fecha_cancelacion, col_fecha_activacion, _
                              col_linea_credito, col_sobregiro, col_saldo, col_estado)
        End With
    End Sub
    Private Sub ConfigurarDGVTipofacturacionConsulta()
        With dgvTipoFacturacionConsulta
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
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_inicio As New DataGridViewTextBoxColumn
            With col_fecha_inicio
                .Name = "fecha_inicio" : .DataPropertyName = "fecha_inicio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Inicio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ': .DefaultCellStyle.Format = "dd/mm/yyyy
            End With
            x += +1
            Dim col_fecha_fin As New DataGridViewTextBoxColumn
            With col_fecha_fin
                .Name = "fecha_fin" : .DataPropertyName = "fecha_fin"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Fin"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft ': .DefaultCellStyle.Format = "dd/mm/yyyy"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            .Columns.AddRange(col_tipo, col_fecha_inicio, col_fecha_fin, col_estado)
        End With
    End Sub
    Private Sub ConfigurarDGVCreditoDetalleConsulta()
        With dgvCreditoDetalleConsulta
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
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_guia As New DataGridViewTextBoxColumn
            With col_guia
                .Name = "guia" : .DataPropertyName = "monto_total_ge"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Total G.E."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "#,###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_prefactura As New DataGridViewTextBoxColumn
            With col_prefactura
                .Name = "prefactura" : .DataPropertyName = "monto_total_pre"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Total Prefactura"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "#,###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_factura As New DataGridViewTextBoxColumn
            With col_factura
                .Name = "factura" : .DataPropertyName = "total_factura_pend"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Total Factura"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "#,###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            .Columns.AddRange(col_guia, col_prefactura, col_factura)
        End With
    End Sub
#End Region
    Sub InicioConsulta()
        ConfigurarDGVClientesConsulta()
        ConfigurarDGVContactoConsulta()
        ConfigurarDGVDireccionConsulta()
        ConfigurarDGVCarteraConsulta()
        ConfigurarDGVProductoConsulta()
        ConfigurarDGVCreditoConsulta()
        ConfigurarDGVTipofacturacionConsulta()
        ConfigurarDGVCargoConsulta()
        ConfigurarDGVCreditoDetalleConsulta()

        Me.cboEstadoCreditoConsulta.SelectedIndex = 1
        Me.cboEstadoCarteraConsulta.SelectedIndex = 1
        Me.cboEstadoProductoConsulta.SelectedIndex = 1
        Me.cboEstadoTipoFacturacionConsulta.SelectedIndex = 1

        Dim intUsuario As Integer = 0
        Dim blnResponsable As Boolean = Acceso.SiRol(G_Rol, Me, 27, 1)
        If blnResponsable Then 'responsable
            Me.cboFuncionarioConsulta.SelectedValue = dtoUSUARIOS.IdLogin
            Me.cboFuncionarioConsulta.Tag = "*"
            intUsuario = dtoUSUARIOS.IdLogin
        Else
            Me.cboFuncionarioConsulta.Tag = ""
        End If
        ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.cboFuncionarioConsulta, "", "", 3, " (SELECCIONE)", intUsuario)
        If blnResponsable Then
            Me.cboFuncionarioConsulta_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub
    Private Sub BuscarClienteConsulta(cliente As String, opcion As Integer, Optional usuario As Integer = 0)
        Try
            If opcion = 1 Then
                If Not fnValidarRUC(cliente) Then
                    MessageBox.Show("El RUC no es Válido", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtNumeroDocumentoConsulta.Focus()
                    Me.txtNumeroDocumentoConsulta.SelectAll()
                    Return
                End If
            End If

            Cursor = Cursors.AppStarting
            Dim obj As New Cls_Cliente_LN
            Dim dt As DataTable = obj.BuscarCliente(cliente, opcion, usuario)

            If usuario = 0 Then
                Cursor = Cursors.Default
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("No se encontraron coincidencias", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Me.cboFuncionarioConsulta.SelectedValue = 0
                    Me.dgvClientesConsulta.DataSource = dt
                End If
            Else
                Cursor = Cursors.Default
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("No se encontraron coincidencias", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Me.dgvClientesConsulta.DataSource = dt
                End If
            End If
            If Me.txtNumeroDocumentoConsulta.Focused Then
                Me.txtNumeroDocumentoConsulta.Focus()
                Me.txtNumeroDocumentoConsulta.SelectAll()
            ElseIf Me.txtRazonSocialConsulta.Focused Then
                Me.txtRazonSocialConsulta.Focus()
                Me.txtRazonSocialConsulta.SelectAll()
            End If
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Gestion de Cartera"
#Region "Configurar Grid"
    Private Sub ConfigurarDGVSolicitudCartera()
        With dgvSolicitudCartera
            'utilitario.FormatDataGridView(dgvLista)
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
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
            End With
            x += +1
            Dim col_aprobacion As New DataGridViewTextBoxColumn
            With col_aprobacion
                .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aprobación"
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
            Dim col_sustento As New DataGridViewTextBoxColumn
            With col_sustento
                .Name = "sustento" : .DataPropertyName = "sustento"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Sustento"
            End With
            x += +1
            Dim col_ruc As New DataGridViewTextBoxColumn
            With col_ruc
                .Name = "ruc" : .DataPropertyName = "ruc"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Ruc"
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id"
            End With
            x += +1
            Dim col_idestado As New DataGridViewTextBoxColumn
            With col_idestado
                .Name = "idestado" : .DataPropertyName = "idestado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id estado"
            End With
            x += +1
            Dim col_tipo_cuenta As New DataGridViewTextBoxColumn
            With col_tipo_cuenta
                .Name = "tipo_cuenta" : .DataPropertyName = "tipo_cuenta"
                .DisplayIndex = x : .Visible = False : .HeaderText = "tipo_cuenta"
            End With

            .Columns.AddRange(col_solicitud, col_fecha, col_cliente, col_estado, col_aprobacion, col_desaprobacion, col_anulacion, _
                              col_sustento, col_ruc, col_id, col_idestado, col_tipo_cuenta)
        End With
    End Sub

    Private Sub ConfigurarDGVTFCargo()
        With dgvTFCargo
            'utilitario.FormatDataGridView(dgvLista)
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
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .HeaderText = "id" : .Visible = False
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
            End With
            x += +1
            Dim col_idsubcuenta As New DataGridViewTextBoxColumn
            With col_idsubcuenta
                .Name = "idsubcuenta" : .DataPropertyName = "idsubcuenta" : .DisplayIndex = x : .Visible = False : .HeaderText = "idsubcuenta"
            End With
            x += +1
            Dim col_subcuenta As New DataGridViewTextBoxColumn
            With col_subcuenta
                .Name = "subcuenta" : .DataPropertyName = "subcuenta" : .DisplayIndex = x : .Visible = False : .HeaderText = "Subcuenta"
            End With
            x += +1
            Dim col_idcargo As New DataGridViewTextBoxColumn
            With col_idcargo
                .Name = "idcargo" : .DataPropertyName = "idcargo" : .DisplayIndex = x : .Visible = False : .HeaderText = "idcargo"
            End With
            x += +1
            Dim col_cargo As New DataGridViewTextBoxColumn
            With col_cargo
                .Name = "cargo" : .DataPropertyName = "cargo" : .DisplayIndex = x : .Visible = True : .HeaderText = "Cargo"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
            End With
            .Columns.AddRange(col_id, col_cliente, col_idsubcuenta, col_subcuenta, col_idcargo, col_cargo, col_estado)
        End With
    End Sub

#End Region
#Region "Solicitud"
    Private Sub btnNuevo_Cick(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        LimpiarSolicitud()
        Me.lblNumeroSolicitud.Text = dtoUtilitario.ObtieneNumeroSolicitud(dtoUSUARIOS.IdLogin, 0)
        intOperacion = Operacion.Nuevo
        ActivaDesactiva(1, dgvSolicitudCartera.Rows.Count)
        Me.txtRuc.Enabled = True
        Me.txtRuc.Focus()
    End Sub

    Private Sub btnModificar_Click(sender As System.Object, e As System.EventArgs) Handles btnModificar.Click
        intOperacion = Operacion.Modificar
        ActivaDesactiva(1, dgvSolicitudCartera.Rows.Count)
        Me.txtRuc.Enabled = False
        Me.txtSustento.Focus()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        ActivaDesactiva(0, dgvSolicitudCartera.Rows.Count)
        LimpiarSolicitud()
        If Me.dgvSolicitudCartera.Rows.Count > 0 Then
            MostrarSolicitud(dgvSolicitudCartera.CurrentCell.RowIndex)
        End If
        If intOperacion = Operacion.Nuevo Then
            btnNuevo.Focus()
        Else
            btnModificar.Focus()
        End If
    End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        Try
            If Me.lblRazonSocial.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese el Cliente", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtRuc.Focus()
                Return
            End If

            If Me.cboTipoCartera.SelectedValue = 0 Then
                MessageBox.Show("Seleccione Tipo de Cartera", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboTipoCartera.DroppedDown = True
                Return
            End If

            If intOperacion = Operacion.Nuevo Then
                Dim objLN As New Cls_ClienteCarteraFuncionario_LN
                Dim objEN As New Cls_ClienteCarteraFuncionario_EN
                objEN.Cliente = Me.lblRazonSocial.Tag
                objEN.Estado = 1
                If objLN.ExisteSolicitud(objEN) Then
                    MessageBox.Show("El Cliente " & Me.lblRazonSocial.Text & Chr(13) & " ya cuenta con una Solicitud Activa", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtRuc.Focus()
                    Return
                End If
            End If

            If Me.txtSustento.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Sustento de la Solicitud", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtSustento.Text = ""
                Me.txtSustento.Focus()
                Return
            End If
            Grabar()

            ListarSolicitudes()
            ActivaDesactiva(0, dgvSolicitudCartera.Rows.Count)
            Me.lblFuncionarioActual.Text = ""
            Me.btnNuevo.Focus()
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAnular_Click(sender As System.Object, e As System.EventArgs) Handles btnAnular.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está Seguro de Anular la Solicitud Nº " & dgvSolicitudCartera.CurrentRow.Cells("numero_solicitud").Value & "?", "Anular Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = vbYes Then
            Anular()
            ListarSolicitudes()
        End If
    End Sub

    Sub Anular()
        Try
            Dim objEN As New Cls_ClienteCarteraFuncionario_EN
            Dim objLN As New Cls_ClienteCarteraFuncionario_LN

            objEN.ID = dgvSolicitudCartera.CurrentRow.Cells("id").Value
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP

            objLN.AnularSolicitud(objEN)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Grabar()
        Try
            Dim objEN As New Cls_ClienteCarteraFuncionario_EN
            Dim objLN As New Cls_ClienteCarteraFuncionario_LN

            If intOperacion = Operacion.Nuevo Then
                objEN.ID = 0
            Else
                objEN.ID = dgvSolicitudCartera.CurrentRow.Cells("id").Value
            End If
            objEN.NumeroSolicitud = Me.lblNumeroSolicitud.Text
            objEN.Fecha = Me.lblFecha.Text
            objEN.Cliente = Me.lblRazonSocial.Tag
            objEN.TipoCuenta = Me.cboTipoCartera.SelectedValue
            objEN.Sustento = Me.txtSustento.Text.Trim
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP
            If IsNothing(Me.lblFuncionarioActual.Tag) Then
                objEN.ResponsableActual = 0
                objEN.ResponsableFechaInicio = ""
            Else
                Dim intPosicion As Integer = InStr(Me.lblFuncionarioActual.Tag.ToString.Trim, "*")
                objEN.ResponsableActual = Me.lblFuncionarioActual.Tag.ToString.Trim.Substring(0, intPosicion - 1)
                objEN.ResponsableFechaInicio = Me.lblFuncionarioActual.Tag.ToString.Trim.Substring(intPosicion)
            End If

            objLN.GrabarSolicitud(objEN)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub ActivaDesactiva(estado As Integer, registros As Integer)
        Dim blnEstado As Boolean
        If estado = 1 Then
            blnEstado = True
        ElseIf estado = 0 Then
            blnEstado = False
        End If
        If estado = -1 Then
            Me.grbSolicitudCartera.Enabled = False
            Me.btnNuevo.Enabled = True
            If registros = 0 Then
                Me.btnModificar.Enabled = False
                Me.btnAnular.Enabled = False
            Else
                Me.btnModificar.Enabled = True
                Me.btnAnular.Enabled = True
            End If
            Me.btnGrabar.Enabled = False
            Me.btnCancelar.Enabled = False
        Else
            blnEstado = estado
            Me.grbSolicitudCartera.Enabled = blnEstado
            Me.btnNuevo.Enabled = Not blnEstado
            If registros = 0 Then
                Me.btnModificar.Enabled = False
            Else
                Me.btnModificar.Enabled = Not blnEstado
            End If
            Me.btnGrabar.Enabled = blnEstado
            Me.btnCancelar.Enabled = blnEstado
            If registros = 0 Then
                Me.btnAnular.Enabled = False
            Else
                Me.btnAnular.Enabled = Not blnEstado
            End If
        End If

        If Me.btnGrabar.Enabled Then
            Me.dgvSolicitudCartera.Enabled = False
            Me.cboEstado.Enabled = False
        Else
            Me.dgvSolicitudCartera.Enabled = True
            Me.cboEstado.Enabled = True
        End If
    End Sub

    Private Sub txtSustento_Enter(sender As Object, e As System.EventArgs) Handles txtSustento.Enter
        Me.txtSustento.SelectAll()
    End Sub

    Private Sub txtSustento_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSustento.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub txtRuc_Enter(sender As Object, e As System.EventArgs) Handles txtRuc.Enter
        Me.txtRuc.SelectAll()
    End Sub

    Private Sub txtRuc_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRuc.KeyPress
        If Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Sub ListarSolicitudes()
        Try
            Dim obj As New Cls_ClienteCarteraFuncionario_LN
            Dim objEN As New Cls_ClienteCarteraFuncionario_EN

            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.Estado = Me.cboEstado.SelectedIndex
            dgvSolicitudCartera.DataSource = obj.ListarSolicitud(objEN.Usuario, objEN.Estado)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub MostrarSolicitud(row As Integer)
        With dgvSolicitudCartera
            Me.lblNumeroSolicitud.Text = .Rows(row).Cells("numero_solicitud").Value
            Me.lblFecha.Text = .Rows(row).Cells("fecha_solicitud").Value
            Me.txtRuc.Text = .Rows(row).Cells("ruc").Value
            Me.lblRazonSocial.Text = .Rows(row).Cells("cliente").Value
            Me.cboTipoCartera.SelectedValue = .Rows(row).Cells("tipo_cuenta").Value
            Me.txtSustento.Text = .Rows(row).Cells("sustento").Value
        End With
    End Sub

    Private Sub dgvSolicitud_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvSolicitudCartera.DoubleClick
        If dgvSolicitudCartera.Rows.Count > 0 And Me.btnGrabar.Enabled = False Then
            If dgvSolicitudCartera.CurrentRow.Cells("idestado").Value = 1 Then
                btnModificar_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub dgvSolicitud_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSolicitudCartera.RowEnter
        'If bInicio Then Return
        If intOperacion = Operacion.Nuevo Then Return
        MostrarSolicitud(e.RowIndex)
        If Me.btnNuevo.Enabled And Me.btnModificar.Enabled Then
            Me.btnModificar.Enabled = dgvSolicitudCartera.Rows(e.RowIndex).Cells("idestado").Value = 1
            Me.btnAnular.Enabled = dgvSolicitudCartera.Rows(e.RowIndex).Cells("idestado").Value = 1
        End If
    End Sub

    Private Sub cboEstado_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstado.SelectedIndexChanged
        Me.LimpiarSolicitud()
        Me.ListarSolicitudes()
        Me.ActivaDesactiva(0, Me.dgvSolicitudCartera.Rows.Count)
    End Sub

    Public Sub Cargar(numero As String)
        strNumero = numero
    End Sub

    Private Sub ObtieneCliente(numero_documento As String)
        Try
            If numero_documento.Trim.Length = 11 Then
                If Not fnValidarRUC(numero_documento) Then
                    MessageBox.Show("El RUC no es Válido", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtRuc.Focus()
                    Me.txtRuc.SelectAll()
                    Return
                End If
            ElseIf numero_documento.Trim.Length <> 8 Then
                MessageBox.Show("El DNI no es Válido", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtRuc.Focus()
                Me.txtRuc.SelectAll()
                Return
            End If

            Dim obj As New Cls_ClienteCarteraFuncionario_LN
            Dim dt As DataTable = obj.ObtieneCliente(numero_documento)

            If dt.Rows.Count > 0 Then
                Dim intResponsable = IIf(dt.Rows(0).Item("idresponsable").ToString.Trim.Length = 0, 0, dt.Rows(0).Item("idresponsable"))
                If dtoUSUARIOS.IdLogin <> intResponsable Then
                    Me.lblRazonSocial.Text = dt.Rows(0).Item("razon_social")
                    Me.lblRazonSocial.Tag = dt.Rows(0).Item("cliente")
                    Me.lblFuncionarioActual.Text = IIf(dt.Rows(0).Item("funcionario").ToString.Trim.Length = 0, "SIN FUNCIONARIO", dt.Rows(0).Item("funcionario"))
                    Me.lblFuncionarioActual.Tag = IIf(dt.Rows(0).Item("idresponsable").ToString.Trim.Length = 0, "", dt.Rows(0).Item("idresponsable"))
                    If Me.lblFuncionarioActual.Tag.ToString.Trim.Length > 0 Then
                        Me.lblFuncionarioActual.Tag &= "*" & IIf(dt.Rows(0).Item("fecha_inicio").ToString.Trim.Length = 0, Nothing, dt.Rows(0).Item("fecha_inicio"))
                    End If
                    SendKeys.Send(vbTab)
                Else
                    MessageBox.Show("El Cliente ya pertenece a esta Cuenta", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LimpiarSolicitud(1)
                    Me.btnSalir.Focus()
                    Me.txtRuc.Focus()
                End If
            Else
                MessageBox.Show("El Cliente no Existe", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiarSolicitud(1)

                Dim frm As New frmRegistrarCliente
                frm.strRuc = Me.txtRuc.Text
                frm.intTipoDocumento = IIf(Me.txtRuc.Text.Trim.Length = 11, 1, 3)
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    Me.txtRuc.Text = strNumero
                    'Me.txtRuc_KeyPress(Nothing, Nothing)
                    Me.txtRuc.Focus()
                    ObtieneCliente(Me.txtRuc.Text.Trim)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtRuc_MarginChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRuc.MarginChanged

    End Sub

    Private Sub txtRuc_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRuc.TextChanged
        LimpiarSolicitud(1)
    End Sub

    Sub LimpiarSolicitud(Optional opcion As Integer = 0)
        If opcion = 0 Then
            Me.txtRuc.Text = ""
        End If
        Me.lblRazonSocial.Text = ""
        Me.lblFuncionarioActual.Text = ""
        Me.txtSustento.Text = ""
        Me.lblFuncionarioActual.Tag = Nothing
        Me.lblRazonSocial.Tag = Nothing
        Me.cboTipoCartera.SelectedValue = 0
    End Sub

    Private Sub ConfigurarDGVListaCartera()
        With dgvListaCartera
            'utilitario.FormatDataGridView(dgvLista)
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
            .VirtualMode = False
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = False
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_sel As New DataGridViewCheckBoxColumn
            With col_sel
                .HeaderText = "Sel"
                .Name = "sel"
                '.DataPropertyName = "IDESTADO_REGISTRO"
                .Width = 50
                '.ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                '.Frozen = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DisplayIndex = x
            End With

            x += +1
            Dim col_solicitud As New DataGridViewTextBoxColumn
            With col_solicitud
                .Name = "numero_solicitud" : .DataPropertyName = "numero_solicitud"
                .DisplayIndex = x : .HeaderText = "Nº Solicitud" : .ReadOnly = True
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha_solicitud" : .DataPropertyName = "fecha_solicitud"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha" : .ReadOnly = True
            End With
            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código" : .ReadOnly = True
            End With

            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .ReadOnly = True
            End With
            x += +1
            Dim col_idcliente As New DataGridViewTextBoxColumn
            With col_idcliente
                .Name = "idcliente" : .DataPropertyName = "idcliente"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id Cliente" : .ReadOnly = True
            End With

            x += +1
            Dim col_solicitante As New DataGridViewTextBoxColumn
            With col_solicitante
                .Name = "solicitante" : .DataPropertyName = "solicitante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Solicitante" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .ReadOnly = True
            End With
            x += +1
            Dim col_usuario_solicitud As New DataGridViewTextBoxColumn
            With col_usuario_solicitud
                .Name = "usuario_solicitud" : .DataPropertyName = "usuario_solicitud"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id Usuario Solicitud" : .ReadOnly = True
            End With
            x += +1
            Dim col_sustento As New DataGridViewTextBoxColumn
            With col_sustento
                .Name = "sustento" : .DataPropertyName = "sustento"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Sustento" : .ReadOnly = True
            End With

            x += +1
            Dim col_responsable As New DataGridViewTextBoxColumn
            With col_responsable
                .Name = "responsable_actual" : .DataPropertyName = "responsable_actual"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Responsable Actual" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .ReadOnly = True
            End With
            x += +1
            Dim col_idresponsable As New DataGridViewTextBoxColumn
            With col_idresponsable
                .Name = "idresponsable" : .DataPropertyName = "idresponsable"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id Responsable" : .ReadOnly = True
            End With
            x += +1
            Dim col_fechainicio As New DataGridViewTextBoxColumn
            With col_fechainicio
                .Name = "fecha_inicio" : .DataPropertyName = "fecha_inicio"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Fecha Inicio" : .DefaultCellStyle.NullValue = "" : .ReadOnly = True
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "ID"
            End With
            x += +1
            Dim col_idtipo_cuenta As New DataGridViewTextBoxColumn
            With col_idtipo_cuenta
                .Name = "idtipo_cuenta" : .DataPropertyName = "idtipo_cuenta"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo_cuenta"
            End With
            x += +1
            Dim col_tipo_cuenta As New DataGridViewTextBoxColumn
            With col_tipo_cuenta
                .Name = "tipo_cuenta" : .DataPropertyName = "tipo_cuenta"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Cuenta" : .ReadOnly = True
            End With

            .Columns.AddRange(col_sel, col_solicitud, col_fecha, col_codigo, col_cliente, col_idcliente, col_solicitante, _
                              col_usuario_solicitud, col_sustento, col_responsable, col_idresponsable, col_fechainicio, _
                              col_id, col_idtipo_cuenta, col_tipo_cuenta)
        End With
    End Sub
#End Region
#Region "Lista"

    Private Sub dgvListaGestionCartera_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvListaCartera.DoubleClick
        If Me.dgvListaCartera.Rows.Count > 0 Then
            Me.tabGestionCartera.SelectedTab = Me.tabGestionCartera.TabPages("tabAprobacionCartera")
            Me.tabGestionCartera_SelectedIndexChanged(sender, e)
        End If
    End Sub
    Sub ListarSolicitudesPendientes()
        Try
            Dim obj As New Cls_ClienteCarteraFuncionario_LN
            Dim objEN As New Cls_ClienteCarteraFuncionario_EN

            objEN.Estado = Estado.Pendiente
            dgvListaCartera.DataSource = obj.ListarSolicitud(objEN.Estado)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgvListaGestionCartera_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaCartera.RowEnter
        With dgvListaCartera
            If .Rows.Count > 0 Then
                BtnAceptar.Enabled = True

                Dim row As DataGridViewRow = .Rows(e.RowIndex)

                Me.lblCodigo.Text = row.Cells("codigo").Value
                Me.lblRazonSocialA.Text = row.Cells("cliente").Value

                Me.lblFuncionarioActualA.Text = row.Cells("responsable_actual").Value
                Me.lblFechaInicio.Text = IIf(IsDBNull(row.Cells("fecha_inicio").Value), "", row.Cells("fecha_inicio").Value)

                Me.lblFuncionarioNuevo.Text = row.Cells("solicitante").Value
                Me.lblSustento.Text = row.Cells("sustento").Value
                Me.lblTipoCuenta.Text = row.Cells("tipo_cuenta").Value

                If Me.lblFuncionarioActualA.Text = "SIN FUNCIONARIO" Then
                    Me.dtpFechaFin.Text = ""
                End If
            End If
        End With
    End Sub
#End Region
#Region "Aprobacion"
    Private Sub dtpFechaActivacion_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaActivacion.ValueChanged
        Me.lblFechaActivacion.Text = dtpFechaActivacion.Value.ToShortDateString
    End Sub
    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        Try
            Dim sAprobar As String
            If Me.RbtSi.Checked Then
                sAprobar = Me.LblAprobar.Text
            Else
                sAprobar = "Desaprobar"
            End If

            If Me.RbtSi.Checked Then
                If Me.dtpFechaFin.Enabled Then
                    If Date.Compare(Me.lblFechaInicio.Text, Me.dtpFechaFin.Value.ToShortDateString) > 0 Then
                        MessageBox.Show("La Fecha Fin " & Format(Me.dtpFechaFin.Value, "short date") & " de Cuenta Actual debe ser mayor o igual a la " & Chr(13) & "Fecha Inicio " & Format(Me.lblFechaInicio.Text, "short date") & " de Cuenta Actual", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.dtpFechaFin.Focus()
                        Return
                    End If
                End If
                If Me.dtpFechaFin.Enabled Then
                    If Date.Compare(Me.dtpFechaFin.Value.ToShortDateString, Me.dtpFechaActivacion.Text) >= 0 Then
                        MessageBox.Show("La Fecha Inicio " & Format(Me.dtpFechaActivacion.Value, "short date") & " de Nueva Cuenta debe ser mayor a la " & Chr(13) & "Fecha Fin " & Format(Me.dtpFechaFin.Value, "short date") & " de Cuenta Actual", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.dtpFechaFin.Focus()
                        Return
                    End If
                End If
            Else
                If Me.TxtObservacion.Text.Trim.Length = 0 Then
                    MessageBox.Show("Debe Ingresar Motivo de la Desaprobación.", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtObservacion.Text = ""
                    Me.TxtObservacion.Focus()
                    Return
                End If
            End If

            Dim iRespuesta As DialogResult
            Dim strMensaje As String = "Nuevo Responsable : " & Me.lblFuncionarioNuevo.Text & Chr(13) & "Fecha Ingreso a Cartera : " & Me.dtpFechaActivacion.Value.ToShortDateString & "?"
            iRespuesta = MessageBox.Show("¿Está Seguro de " & sAprobar & " la Solicitud con:" & Chr(13) & Chr(13) & strMensaje, "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If iRespuesta = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim intOpcion As Integer = IIf(Me.RbtSi.Checked, 1, 2)
                Aceptar(intOpcion)
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Aceptar(opcion As Integer)
        Try
            Dim objEN As New Cls_ClienteCarteraFuncionario_EN
            Dim objLN As New Cls_ClienteCarteraFuncionario_LN

            objEN.ID = Me.dgvListaCartera.CurrentRow.Cells("id").Value
            objEN.Cliente = Me.dgvListaCartera.CurrentRow.Cells("idcliente").Value
            objEN.Responsable = Me.dgvListaCartera.CurrentRow.Cells("usuario_solicitud").Value
            objEN.Fecha = Me.dtpFechaActivacion.Value.Date.ToShortDateString
            objEN.Observaciones = Me.TxtObservacion.Text.Trim
            objEN.TipoCuenta = Me.dgvListaCartera.CurrentRow.Cells("idtipo_cuenta").Value

            objEN.ResponsableActual = Me.dgvListaCartera.CurrentRow.Cells("idresponsable").Value
            objEN.ResponsableFechaFin = Me.dtpFechaFin.Text

            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP

            objLN.AprobarSolicitud(objEN, opcion)

            MessageBox.Show("Solicitud " & IIf(opcion = 1, "Aprobada", "Desaprobada"), "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ListarSolicitudes()
            tabGestionCartera.SelectedTab = tabGestionCartera.TabPages("tabListaCartera")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Sub LimpiarAprobacion()
        Me.lblCodigo.Text = ""
        Me.lblRazonSocialA.Text = ""
        Me.lblFuncionarioActual.Text = ""
        Me.lblFechaInicio.Text = ""
        Me.dtpFechaFin.Text = ""
        Me.lblFuncionarioNuevo.Text = ""
        Me.lblTipoCuenta.Text = ""
        Me.lblSustento.Text = ""
        Me.RbtSi.Checked = True
        Me.TxtObservacion.Text = ""
        Me.lblFechaActivacion.Text = Me.dtpFechaActivacion.Value.ToShortDateString
    End Sub
    Private Sub RbtSi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtSi.CheckedChanged
        Me.TxtObservacion.Enabled = False
        Me.TxtObservacion.Text = ""
        Me.BtnAceptar.Text = "&Aprobar"
        Me.TxtObservacion.Focus()
    End Sub
    Private Sub RbtNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtNo.CheckedChanged
        Me.TxtObservacion.Enabled = True
        Me.BtnAceptar.Text = "&Desaprobar"
        Me.TxtObservacion.Focus()
    End Sub
#End Region
#Region "Transferencia"
    Private Sub ConfigurarDGV1()
        With dgv1
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 8.0!, FontStyle.Regular)
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
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            .ReadOnly = False

            Dim x As Integer = 0
            Dim col_sel As New DataGridViewCheckBoxColumn
            With col_sel
                .HeaderText = "Sel"
                .Name = "sel"
                '.DataPropertyName = "IDESTADO_REGISTRO"
                .Width = 50
                '.ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                '.Frozen = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DisplayIndex = x
            End With
            x += +1
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
            Dim col_FechaInicio As New DataGridViewTextBoxColumn
            With col_FechaInicio
                .Name = "fecha_inicio" : .DataPropertyName = "fecha_inicio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Ini."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            .Columns.AddRange(col_sel, col_id, col_codigo, col_cliente, col_FechaInicio)
        End With
    End Sub
    Private Sub ConfigurarDGV2()
        With dgv2
            'utilitario.FormatDataGridView(dgvLista)
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
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black
            '.RowHeadersWidth = 1

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
            Dim col_FechaInicio As New DataGridViewTextBoxColumn
            With col_FechaInicio
                .Name = "fecha_inicio" : .DataPropertyName = "fecha_inicio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Ini."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With

            .Columns.AddRange(col_id, col_codigo, col_cliente, col_FechaInicio)
        End With
    End Sub
    Sub CargarCombosTransferencia()
        ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.cboFuncionario1, "", "", 3, " (SELECCIONE)")
        ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.cboFuncionario2, "", "", 3, " (SELECCIONE)")
    End Sub
    Private Sub dgv1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellContentClick
        If e.ColumnIndex <> 0 Then Return
        Activar()
    End Sub

    Private Sub dgv1_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles dgv1.CurrentCellDirtyStateChanged
        dgv1.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Function ExisteCheck(ByVal dgv As DataGridView) As Boolean
        For Each row As DataGridViewRow In dgv.Rows
            If Not IsNothing(row.Cells(0).Value) Then
                If row.Cells(0).Value = 1 Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Sub SeleccionarCheckDgv(ByVal dgv As DataGridView, ByVal col As Integer, ByVal estado As Integer)
        For Each row As DataGridViewRow In dgv.Rows
            row.Cells(col).Value = estado
        Next
    End Sub

    Sub SeleccionarCheckDgv(ByVal dgv As DataGridView, ByVal col As Integer, ByVal estado As Integer, cartera As Integer)
        For Each row As DataGridViewRow In dgv.Rows
            If estado = 1 Then
                If cartera = 1 Then
                    row.Cells(col).Value = row.Cells("responsable_actual").Value = "SIN FUNCIONARIO"
                Else
                    row.Cells(col).Value = row.Cells("responsable_actual").Value <> "SIN FUNCIONARIO"
                End If
            Else
                row.Cells(col).Value = estado
            End If
        Next
    End Sub

    Sub Controla(sender As Object, e As EventArgs) Handles cboFuncionario1.SelectedIndexChanged, cboFuncionario2.SelectedIndexChanged
        If IsReference(Me.cboFuncionario1.SelectedValue) Or IsReference(Me.cboFuncionario2.SelectedValue) Then Return
        Dim strNombre As String = CType(sender, ComboBox).Name
        If strNombre = "cboFuncionario1" Then
            CargarCartera(Me.cboFuncionario1.SelectedValue, dgv1)
            Me.LblNumero1.Text = "0/" & Me.dgv1.Rows.Count
        Else
            CargarCartera(Me.cboFuncionario2.SelectedValue, dgv2)
            Me.lblNumero2.Text = Me.dgv2.Rows.Count
        End If

        Activar()
    End Sub

    Private Sub btnSeleccionarTodo_Click(sender As System.Object, e As System.EventArgs) Handles btnSeleccionarTodo.Click
        SeleccionarCheckDgv(Me.dgv1, 0, 1)
        Activar()
    End Sub

    Private Sub btnEliminarSeleccion_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarSeleccion.Click
        SeleccionarCheckDgv(Me.dgv1, 0, 0)
        Activar()
    End Sub

    Sub Transferir()
        Dim objEN As New Cls_ClienteCarteraFuncionario_EN
        Dim objLN As New Cls_ClienteCarteraFuncionario_LN
        For Each row As DataGridViewRow In dgv1.Rows
            If Not IsNothing(row.Cells(0).Value) Then
                If row.Cells(0).Value = 1 Then
                    objEN.Cliente = Me.dgv1.CurrentRow.Cells("idcliente").Value
                    objEN.ResponsableActual = Me.cboFuncionario1.SelectedValue 'Me.dgv.CurrentRow.Cells("responsable_actual").Value
                    objEN.Responsable = Me.cboFuncionario2.SelectedValue
                    'objEN.Fecha = row.Cells("fecha").Value

                    'objLN.TransferirCuenta(objEN)
                    'MessageBox.Show(row.Cells(1).Value)
                End If
            End If
        Next
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Dim lista As List(Of DataGridViewRow) = ObtenerListaCheck(dgv1, "sel")
        Dim frm As New frmTransferenciaCartera
        frm.Cargar(Me.cboFuncionario1.SelectedValue, Me.cboFuncionario1.Text, Me.cboFuncionario2.SelectedValue, Me.cboFuncionario2.Text, lista)
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            'Transferir()
            CargarCartera(Me.cboFuncionario1.SelectedValue, dgv1)
            Me.LblNumero1.Text = "0/" & Me.dgv1.Rows.Count

            CargarCartera(Me.cboFuncionario2.SelectedValue, dgv2)
            Me.lblNumero2.Text = Me.dgv2.Rows.Count

            Activar()
        End If
    End Sub

    Private Sub btnRetirar_Click(sender As System.Object, e As System.EventArgs) Handles btnRetirar.Click
        Dim lista As List(Of DataGridViewRow) = ObtenerListaCheck(dgv1, "sel")
        Dim frm As New frmRetirarClienteCartera
        frm.Cargar(Me.cboFuncionario1.SelectedValue, lista)
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            CargarCartera(Me.cboFuncionario1.SelectedValue, dgv1)
            Me.LblNumero1.Text = "0/" & Me.dgv1.Rows.Count

            CargarCartera(Me.cboFuncionario2.SelectedValue, dgv2)
            Me.lblNumero2.Text = Me.dgv2.Rows.Count

            Activar()
        End If
    End Sub

    Sub Activar()
        Dim intNumero As Integer = NumeroCheck(dgv1)
        If intNumero > 0 And Me.cboFuncionario2.SelectedValue > 0 And Me.cboFuncionario1.SelectedValue <> Me.cboFuncionario2.SelectedValue Then
            Me.btnAgregar.Enabled = True
        Else
            Me.btnAgregar.Enabled = False
        End If

        If intNumero > 0 Then
            Me.btnRetirar.Enabled = True
        Else
            Me.btnRetirar.Enabled = False
        End If

        Me.LblNumero1.Text = intNumero & "/" & dgv1.Rows.Count
    End Sub

    Function NumeroCheck(ByVal dgv As DataGridView) As Integer
        Dim intNumero As Integer = 0
        For Each row As DataGridViewRow In dgv.Rows
            If Not IsNothing(row.Cells(0).Value) Then
                If row.Cells(0).Value = 1 Or row.Cells(0).Value Then
                    intNumero += 1
                End If
            End If
        Next
        Return intNumero
    End Function

    Private Sub dgv1_DoubleClick(sender As Object, e As System.EventArgs) Handles dgv1.DoubleClick
        If dgv1.Rows.Count > 0 Then

        End If
    End Sub
#End Region
#Region "Administrador"
    Private Sub tabGestionCartera_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabGestionCartera.SelectedIndexChanged
        If tabGestionCartera.SelectedTab Is tabGestionCartera.TabPages("tabSolicitudCartera") Then
            Cls_Utilitarios.FormatDataGridView(dgvSolicitudCartera)
            ConfigurarDGVSolicitudCartera()
            LlenarComboCartera()

            intOperacion = Operacion.Nuevo

            Me.lblFecha.Text = Format(Now, "Short Date")
            Me.lblFuncionario.Text = dtoUSUARIOS.NameLogin
            Me.cboEstado.SelectedIndex = 1

            ListarSolicitudes()

            ActivaDesactiva(-1, dgvSolicitudCartera.Rows.Count)
            Me.btnNuevo.Focus()

        ElseIf tabGestionCartera.SelectedTab Is tabGestionCartera.TabPages("tabListaCartera") Then
            Cls_Utilitarios.FormatDataGridView(dgvListaCartera)
            ConfigurarDGVListaCartera()
            ListarSolicitudesPendientes()
            If Me.dgvListaCartera.Rows.Count = 0 Then
                'Me.tabGestionCartera.TabPages.Remove(tabGestionCartera.TabPages("tabListaCartera"))
                'Me.tabGestionCartera.TabPages.Remove(tabGestionCartera.TabPages("tabAprobacionCartera"))
            End If

        ElseIf tabGestionCartera.SelectedTab Is tabGestionCartera.TabPages("tabAprobacionCartera") Then
            If dgvListaCartera.Rows.Count > 0 Then
                BtnAceptar.Enabled = True
                Me.dtpFechaActivacion.Enabled = True

                If lblFuncionarioActualA.Text = "SIN FUNCIONARIO" Then
                    Me.dtpFechaFin.Enabled = False
                Else
                    Me.dtpFechaFin.Enabled = True
                End If

                Me.RbtSi.Enabled = True
                Me.RbtNo.Enabled = True

                'hlamas 13-08-2015
                If lblFuncionarioActualA.Text = "SIN FUNCIONARIO" Then
                    Me.dtpFechaActivacion.Value = Me.dgvListaCartera.CurrentRow.Cells("fecha_solicitud").Value 'DateAdd("d", 1, Now).ToString("dd/MM/yyyy")
                Else
                    Me.dtpFechaActivacion.Value = DateAdd("d", 1, Now).ToString("dd/MM/yyyy")
                End If

                Me.dtpFechaActivacion.Focus()
            Else
                LimpiarAprobacion()
                Me.dtpFechaActivacion.Enabled = False
                Me.dtpFechaFin.Enabled = False
                BtnAceptar.Enabled = False
                Me.RbtSi.Enabled = False
                Me.RbtNo.Enabled = False
            End If

        ElseIf tabGestionCartera.SelectedTab Is tabGestionCartera.TabPages("tabTransferenciaCartera") Then
            ConfigurarDGV1()
            ConfigurarDGV2()
            Me.CargarCombosTransferencia()
        End If
    End Sub
#End Region
#End Region

#Region "Linea de Credito"
#Region "Configurar Grid"
    Private Sub ConfigurarDGVDocumentoCliente()
        With dgvDocumentoCliente
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
            End With
            x += +1
            Dim col_subcuenta As New DataGridViewTextBoxColumn
            With col_subcuenta
                .Name = "subcuenta" : .DataPropertyName = "subcuenta"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subcuenta"
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
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
            End With

            .Columns.AddRange(col_id, col_idsubcuenta, col_subcuenta, col_idcargo, col_cargo, col_estado)
        End With
    End Sub
    Private Sub ConfigurarDGVFacturacion3Credito()
        With dgvFacturacion3Credito
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
            End With
            x += +1
            Dim col_subcuenta As New DataGridViewTextBoxColumn
            With col_subcuenta
                .Name = "subcuenta" : .DataPropertyName = "subcuenta"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subcuenta"
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
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
            End With

            .Columns.AddRange(col_id, col_idsubcuenta, col_subcuenta, col_idcargo, col_cargo, col_estado)
        End With
    End Sub
    Private Sub ConfigurarDGVLineaCredito()
        With dgvLineaCredito
            Cls_Utilitarios.FormatDataGridView(dgvClienteCreditoDetalle)
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
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_fecha_inicio As New DataGridViewTextBoxColumn
            With col_fecha_inicio
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .HeaderText = "Fecha inicio" : .Visible = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader : .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            x += +1
            Dim col_fecha_fin As New DataGridViewTextBoxColumn
            With col_fecha_fin
                .Name = "fecha_fin" : .DataPropertyName = "fecha_fin"
                .DisplayIndex = x : .HeaderText = "Fecha fin" : .Visible = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader : .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            x += +1
            Dim col_linea As New DataGridViewTextBoxColumn
            With col_linea
                .Name = "linea" : .DataPropertyName = "linea"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Línea de Crédito"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight : .DefaultCellStyle.Format = "#,###,###,###0.00"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            x += +1
            Dim col_sobregiro As New DataGridViewTextBoxColumn
            With col_sobregiro
                .Name = "sobregiro" : .DataPropertyName = "sobregiro"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Sobregiro"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight : .DefaultCellStyle.Format = "#,###,###,###0.00"
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total Asignado"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight : .DefaultCellStyle.Format = "#,###,###,###0.00"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            x += +1
            Dim col_saldo As New DataGridViewTextBoxColumn
            With col_saldo
                .Name = "saldo" : .DataPropertyName = "saldo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Saldo"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight : .DefaultCellStyle.Format = "#,###,###,###0.00"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .HeaderText = "Estado" : .Visible = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            .Columns.AddRange(col_fecha_inicio, col_fecha_fin, col_linea, col_sobregiro, col_total, col_saldo, col_estado)
        End With
    End Sub
    Private Sub ConfigurarDGVCarteraCredito()
        With dgvCarteraCredito
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 8.0!, FontStyle.Regular)
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
            Dim col_funcionario As New DataGridViewTextBoxColumn
            With col_funcionario
                .Name = "funcionario" : .DataPropertyName = "funcionario"
                .DisplayIndex = x : .Visible = False : .HeaderText = "funcionario"
            End With
            .Columns.AddRange(col_id, col_codigo, col_cliente, col_funcionario)
        End With
    End Sub
    Private Sub ConfigurarDGVListaCreditoRechazadas()
        With dgvListaCredito
            RemoveHandler Me.dgvListaCredito.RowEnter, AddressOf Me.dgvListaCredito_RowEnter
            Cls_Utilitarios.FormatDataGridView(dgvListaCredito)
            AddHandler Me.dgvListaCredito.RowEnter, AddressOf Me.dgvListaCredito_RowEnter
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
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id Solicitud"
            End With
            x += +1
            Dim col_nro_solicitud As New DataGridViewTextBoxColumn
            With col_nro_solicitud
                .Name = "nro_solicitud" : .DataPropertyName = "nro_solicitud"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Solicitud" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_fecha_solicitud As New DataGridViewTextBoxColumn
            With col_fecha_solicitud
                .Name = "fecha_solicitud" : .DataPropertyName = "fecha_solicitud"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Solicitud" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            x += +1
            Dim col_fecha_preaprobacion As New DataGridViewTextBoxColumn
            With col_fecha_preaprobacion
                .Name = "fecha_preaprobacion" : .DataPropertyName = "fecha_preaprobacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Fecha Preaprobación" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            x += +1
            Dim col_fecha_aprobacion As New DataGridViewTextBoxColumn
            With col_fecha_aprobacion
                .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Fecha Aprobación" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            x += +1
            Dim col_fecha_rechazo_pre_aprobacion As New DataGridViewTextBoxColumn
            With col_fecha_rechazo_pre_aprobacion
                .Name = "fecha_rechazo_pre_aprobacion" : .DataPropertyName = "fecha_rechazo_pre_aprobacion"
                .DisplayIndex = x : .Visible = IIf(Me.cboPorCredito.SelectedIndex = 0, True, False) : .HeaderText = "Fecha Rechazo Preaprobación" : .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            x += +1
            Dim col_fecha_rechazo_aprobacion As New DataGridViewTextBoxColumn
            With col_fecha_rechazo_aprobacion
                .Name = "fecha_rechazo_aprobacion" : .DataPropertyName = "fecha_rechazo_aprobacion"
                .DisplayIndex = x : .Visible = IIf(Me.cboPorCredito.SelectedIndex = 1, True, False) : .HeaderText = "Fecha Rechazo Aprobación" : .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_idcliente As New DataGridViewTextBoxColumn
            With col_idcliente
                .Name = "idcliente" : .DataPropertyName = "idcliente" : .DisplayIndex = x : .Visible = True : .HeaderText = "idcliente"
            End With
            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto_solicitado" : .DataPropertyName = "monto_solicitado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Solicitado" : .DefaultCellStyle.Format = "#,###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
            x += +1
            Dim col_monto_preaprobado As New DataGridViewTextBoxColumn
            With col_monto_preaprobado
                .Name = "monto_preaprobado" : .DataPropertyName = "monto_preaprobado"
                .DisplayIndex = x : .Visible = IIf(Me.cboPorCredito.SelectedIndex = 0, False, True) : .HeaderText = "Monto Preaprobado" : .DefaultCellStyle.Format = "#,###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
            x += +1
            Dim col_monto_aprobado As New DataGridViewTextBoxColumn
            With col_monto_aprobado
                .Name = "monto_aprobado" : .DataPropertyName = "monto_aprobado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Monto Aprobado" : .DefaultCellStyle.Format = "#,###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
            x += +1
            Dim col_periodo_pago As New DataGridViewTextBoxColumn
            With col_periodo_pago
                .Name = "periodo_pago" : .DataPropertyName = "periodo_pago"
                .DisplayIndex = x : .Visible = False : .HeaderText = "periodo_pago"
            End With
            x += +1
            Dim col_dia_pago As New DataGridViewTextBoxColumn
            With col_dia_pago
                .Name = "dia_pago" : .DataPropertyName = "dia_pago"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia_pago"
            End With
            x += +1
            Dim col_fecha1 As New DataGridViewTextBoxColumn
            With col_fecha1
                .Name = "fecha1" : .DataPropertyName = "fecha1"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fecha1"
            End With
            x += +1
            Dim col_fecha2 As New DataGridViewTextBoxColumn
            With col_fecha2
                .Name = "fecha2" : .DataPropertyName = "fecha2"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fecha2"
            End With
            x += +1
            Dim col_fecha3 As New DataGridViewTextBoxColumn
            With col_fecha3
                .Name = "fecha3" : .DataPropertyName = "fecha3"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fecha3"
            End With
            x += +1
            Dim col_fecha4 As New DataGridViewTextBoxColumn
            With col_fecha4
                .Name = "fecha4" : .DataPropertyName = "fecha4"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fecha4"
            End With
            x += +1
            Dim col_dia1 As New DataGridViewTextBoxColumn
            With col_dia1
                .Name = "dia1" : .DataPropertyName = "dia1"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia1"
            End With
            x += +1
            Dim col_dia2 As New DataGridViewTextBoxColumn
            With col_dia2
                .Name = "dia2" : .DataPropertyName = "dia2"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia2"
            End With
            x += +1
            Dim col_dia3 As New DataGridViewTextBoxColumn
            With col_dia3
                .Name = "dia3" : .DataPropertyName = "dia3"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia3"
            End With
            x += +1
            Dim col_dia4 As New DataGridViewTextBoxColumn
            With col_dia4
                .Name = "dia4" : .DataPropertyName = "dia4"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia4"
            End With
            x += +1
            Dim col_dia5 As New DataGridViewTextBoxColumn
            With col_dia5
                .Name = "dia5" : .DataPropertyName = "dia5"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia5"
            End With
            x += +1
            Dim col_dia6 As New DataGridViewTextBoxColumn
            With col_dia6
                .Name = "dia6" : .DataPropertyName = "dia6"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia6"
            End With
            x += +1
            Dim col_dia7 As New DataGridViewTextBoxColumn
            With col_dia7
                .Name = "dia7" : .DataPropertyName = "dia7"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia7"
            End With
            x += +1
            Dim col_horario_pago_ini As New DataGridViewTextBoxColumn
            With col_horario_pago_ini
                .Name = "horario_pago_ini" : .DataPropertyName = "horario_pago_ini"
                .DisplayIndex = x : .Visible = False : .HeaderText = "horario_pago_ini"
            End With
            x += +1
            Dim col_horario_pago_fin As New DataGridViewTextBoxColumn
            With col_horario_pago_fin
                .Name = "horario_pago_fin" : .DataPropertyName = "horario_pago_fin"
                .DisplayIndex = x : .Visible = False : .HeaderText = "horario_pago_fin"
            End With
            x += +1
            Dim col_tipo_pago As New DataGridViewTextBoxColumn
            With col_tipo_pago
                .Name = "tipo_pago" : .DataPropertyName = "tipo_pago"
                .DisplayIndex = x : .Visible = False : .HeaderText = "tipo_pago"
            End With
            x += +1
            Dim col_sobregiro As New DataGridViewTextBoxColumn
            With col_sobregiro
                .Name = "sobregiro" : .DataPropertyName = "sobregiro"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Sobregiro" : .DefaultCellStyle.Format = "#,###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
            x += +1
            Dim col_total_asignado As New DataGridViewTextBoxColumn
            With col_total_asignado
                .Name = "total_asignado" : .DataPropertyName = "total_asignado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Total Asignado" : .DefaultCellStyle.Format = "#,###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
            x += +1
            Dim col_porcentaje_sobregiro As New DataGridViewTextBoxColumn
            With col_porcentaje_sobregiro
                .Name = "porcentaje_sobregiro" : .DataPropertyName = "porcentaje_sobregiro"
                .DisplayIndex = x : .Visible = False : .HeaderText = "porcentaje_sobregiro" : .DefaultCellStyle.Format = "#,###,###,###0.00"
            End With
            x += +1
            Dim col_idusuario_personal As New DataGridViewTextBoxColumn
            With col_idusuario_personal
                .Name = "idusuario_personal" : .DataPropertyName = "idusuario_personal"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idusuario_personal"
            End With
            x += +1
            Dim col_idusuario_personalmod As New DataGridViewTextBoxColumn
            With col_idusuario_personalmod
                .Name = "idusuario_personalmod" : .DataPropertyName = "idusuario_personalmod"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idusuario_personalmod"
            End With
            x += +1
            Dim col_usuario_pre_aprobacion As New DataGridViewTextBoxColumn
            With col_usuario_pre_aprobacion
                .Name = "usuario_pre_aprobacion" : .DataPropertyName = "usuario_pre_aprobacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Usuario Preaprobación"
            End With
            x += +1
            Dim col_usuario_aprobacion As New DataGridViewTextBoxColumn
            With col_usuario_aprobacion
                .Name = "usuario_aprobacion" : .DataPropertyName = "usuario_aprobacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Usuario Aprobación"
            End With
            x += +1
            Dim col_usuario_rechazo_pre_aprobacion As New DataGridViewTextBoxColumn
            With col_usuario_rechazo_pre_aprobacion
                .Name = "usuario_rechazo_pre_aprobacion" : .DataPropertyName = "usuario_rechazo_pre_aprobacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Usuario Rechazo Preaprobación"
            End With
            x += +1
            Dim col_usuario_rechazo_aprobacion As New DataGridViewTextBoxColumn
            With col_usuario_rechazo_aprobacion
                .Name = "usuario_rechazo_aprobacion" : .DataPropertyName = "usuario_rechazo_aprobacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Usuario Rechazo Aprobación"
            End With
            x += +1
            Dim col_funcionario As New DataGridViewTextBoxColumn
            With col_funcionario
                .Name = "funcionario" : .DataPropertyName = "funcionario"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Funcionario"
            End With
            x += +1
            Dim col_solicitante As New DataGridViewTextBoxColumn
            With col_solicitante
                .Name = "solicitante" : .DataPropertyName = "solicitante"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Solicitante" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_producto As New DataGridViewTextBoxColumn
            With col_producto
                .Name = "producto" : .DataPropertyName = "producto"
                .DisplayIndex = x : .Visible = False : .HeaderText = "producto"
            End With
            x += +1
            Dim col_tipo_facturacion As New DataGridViewTextBoxColumn
            With col_tipo_facturacion
                .Name = "tipo_facturacion" : .DataPropertyName = "tipo_facturacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "tipo_facturacion"
            End With
            x += +1
            Dim col_contado As New DataGridViewTextBoxColumn
            With col_contado
                .Name = "contado" : .DataPropertyName = "contado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "contado"
            End With


            x += +1
            Dim col_idcontacto_comercial As New DataGridViewTextBoxColumn
            With col_idcontacto_comercial
                .Name = "idcontacto_comercial" : .DataPropertyName = "idcontacto_comercial"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcontacto_comercial" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_idcontacto_pago As New DataGridViewTextBoxColumn
            With col_idcontacto_pago
                .Name = "idcontacto_pago" : .DataPropertyName = "idcontacto_pago"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcontacto_pago" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_nombre_comercial As New DataGridViewTextBoxColumn
            With col_nombre_comercial
                .Name = "nombre_comercial" : .DataPropertyName = "nombre_comercial"
                .DisplayIndex = x : .Visible = False : .HeaderText = "nombre_comercial" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_nombre_pagos As New DataGridViewTextBoxColumn
            With col_nombre_pagos
                .Name = "nombre_pagos" : .DataPropertyName = "nombre_pagos"
                .DisplayIndex = x : .Visible = False : .HeaderText = "nombre_pagos" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_cargo_comercial As New DataGridViewTextBoxColumn
            With col_cargo_comercial
                .Name = "cargo_comercial" : .DataPropertyName = "cargo_comercial"
                .DisplayIndex = x : .Visible = False : .HeaderText = "cargo_comercial" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_cargo_pagos As New DataGridViewTextBoxColumn
            With col_cargo_pagos
                .Name = "cargo_pagos" : .DataPropertyName = "cargo_pagos"
                .DisplayIndex = x : .Visible = False : .HeaderText = "cargo_pagos" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_email_comercial As New DataGridViewTextBoxColumn
            With col_email_comercial
                .Name = "email_comercial" : .DataPropertyName = "email_comercial"
                .DisplayIndex = x : .Visible = False : .HeaderText = "email_comercial" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_email_pagos As New DataGridViewTextBoxColumn
            With col_email_pagos
                .Name = "email_pagos" : .DataPropertyName = "email_pagos"
                .DisplayIndex = x : .Visible = False : .HeaderText = "email_pagos" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_forma_pago As New DataGridViewTextBoxColumn
            With col_forma_pago
                .Name = "forma_pago" : .DataPropertyName = "forma_pago"
                .DisplayIndex = x : .Visible = False : .HeaderText = "forma_pago" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_direccion_facturacion As New DataGridViewTextBoxColumn
            With col_direccion_facturacion
                .Name = "direccion_facturacion" : .DataPropertyName = "direccion_facturacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "direccion_facturacion" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_fecha_corte As New DataGridViewTextBoxColumn
            With col_fecha_corte
                .Name = "fecha_corte" : .DataPropertyName = "fecha_corte"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fecha_corte" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_periodo_facturacion As New DataGridViewTextBoxColumn
            With col_periodo_facturacion
                .Name = "periodo_facturacion" : .DataPropertyName = "periodo_facturacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "periodo_facturacion" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_fechaf1 As New DataGridViewTextBoxColumn
            With col_fechaf1
                .Name = "fechaf1" : .DataPropertyName = "fechaf1"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fechaf1"
            End With
            x += +1
            Dim col_fechaf2 As New DataGridViewTextBoxColumn
            With col_fechaf2
                .Name = "fechaf2" : .DataPropertyName = "fechaf2"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fechaf2"
            End With
            x += +1
            Dim col_fechaf3 As New DataGridViewTextBoxColumn
            With col_fechaf3
                .Name = "fechaf3" : .DataPropertyName = "fechaf3"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fechaf3"
            End With
            x += +1
            Dim col_fechaf4 As New DataGridViewTextBoxColumn
            With col_fechaf4
                .Name = "fechaf4" : .DataPropertyName = "fechaf4"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fechaf4"
            End With
            x += +1
            Dim col_diaf1 As New DataGridViewTextBoxColumn
            With col_diaf1
                .Name = "diaf1" : .DataPropertyName = "diaf1"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf1"
            End With
            x += +1
            Dim col_diaf2 As New DataGridViewTextBoxColumn
            With col_diaf2
                .Name = "diaf2" : .DataPropertyName = "diaf2"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf2"
            End With
            x += +1
            Dim col_diaf3 As New DataGridViewTextBoxColumn
            With col_diaf3
                .Name = "diaf3" : .DataPropertyName = "diaf3"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf3"
            End With
            x += +1
            Dim col_diaf4 As New DataGridViewTextBoxColumn
            With col_diaf4
                .Name = "diaf4" : .DataPropertyName = "diaf4"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf4"
            End With
            x += +1
            Dim col_diaf5 As New DataGridViewTextBoxColumn
            With col_diaf5
                .Name = "diaf5" : .DataPropertyName = "diaf5"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia5"
            End With
            x += +1
            Dim col_diaf6 As New DataGridViewTextBoxColumn
            With col_diaf6
                .Name = "diaf6" : .DataPropertyName = "diaf6"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf6"
            End With
            x += +1
            Dim col_diaf7 As New DataGridViewTextBoxColumn
            With col_diaf7
                .Name = "diaf7" : .DataPropertyName = "diaf7"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf7"
            End With
            x += +1
            Dim col_horario_facturacion_ini As New DataGridViewTextBoxColumn
            With col_horario_facturacion_ini
                .Name = "horario_facturacion_ini" : .DataPropertyName = "horario_facturacion_ini"
                .DisplayIndex = x : .Visible = False : .HeaderText = "horario_facturacion_ini"
            End With
            x += +1
            Dim col_horario_facturacion_fin As New DataGridViewTextBoxColumn
            With col_horario_facturacion_fin
                .Name = "horario_facturacion_fin" : .DataPropertyName = "horario_facturacion_fin"
                .DisplayIndex = x : .Visible = False : .HeaderText = "horario_facturacion_fin"
            End With
            x += +1
            Dim col_orden_compra As New DataGridViewTextBoxColumn
            With col_orden_compra
                .Name = "orden_compra" : .DataPropertyName = "orden_compra"
                .DisplayIndex = x : .Visible = False : .HeaderText = "orden_compra"
            End With
            .Columns.AddRange(col_nro_solicitud, col_fecha_solicitud, col_fecha_preaprobacion, col_fecha_aprobacion, _
                              col_fecha_rechazo_pre_aprobacion, col_fecha_rechazo_aprobacion, col_codigo, col_cliente, _
                              col_monto, col_monto_preaprobado, col_monto_aprobado, col_sobregiro, col_total_asignado, col_funcionario, _
                              col_usuario_aprobacion, col_usuario_pre_aprobacion, col_usuario_rechazo_aprobacion, col_usuario_rechazo_pre_aprobacion,
                              col_periodo_pago, col_dia_pago, col_horario_pago_ini, col_horario_pago_fin, _
                              col_fecha1, col_fecha2, col_fecha3, col_fecha4, col_dia1, col_dia2, col_dia3, col_dia4, col_dia5, col_dia6, col_dia7, _
                              col_solicitante, col_producto, col_tipo_facturacion, col_contado, _
                              col_idcontacto_comercial, col_idcontacto_pago, _
                              col_nombre_comercial, col_nombre_pagos, _
                              col_cargo_comercial, col_email_comercial, col_cargo_pagos, col_email_pagos, _
                              col_forma_pago, col_direccion_facturacion, col_fecha_corte, col_periodo_facturacion, _
                              col_fechaf1, col_fechaf2, col_fechaf3, col_fechaf4, col_diaf1, col_diaf2, col_diaf3, col_diaf4, col_diaf5, col_diaf6, col_diaf7, _
                              col_horario_facturacion_ini, col_horario_facturacion_fin, col_orden_compra, col_idcliente)

        End With
    End Sub
    Private Sub ConfigurarDGVListaCreditoAprobadas()
        With dgvListaCredito
            RemoveHandler Me.dgvListaCredito.RowEnter, AddressOf Me.dgvListaCredito_RowEnter
            Cls_Utilitarios.FormatDataGridView(dgvListaCredito)
            AddHandler Me.dgvListaCredito.RowEnter, AddressOf Me.dgvListaCredito_RowEnter
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
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id Solicitud"
            End With
            x += +1
            Dim col_nro_solicitud As New DataGridViewTextBoxColumn
            With col_nro_solicitud
                .Name = "nro_solicitud" : .DataPropertyName = "nro_solicitud"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Solicitud" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_fecha_solicitud As New DataGridViewTextBoxColumn
            With col_fecha_solicitud
                .Name = "fecha_solicitud" : .DataPropertyName = "fecha_solicitud"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Solicitud" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            x += +1
            Dim col_fecha_preaprobacion As New DataGridViewTextBoxColumn
            With col_fecha_preaprobacion
                .Name = "fecha_preaprobacion" : .DataPropertyName = "fecha_preaprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Preaprobación" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            x += +1
            Dim col_fecha_aprobacion As New DataGridViewTextBoxColumn
            With col_fecha_aprobacion
                .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aprobación" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            x += +1
            Dim col_fecha_rechazo_pre_aprobacion As New DataGridViewTextBoxColumn
            With col_fecha_rechazo_pre_aprobacion
                .Name = "fecha_rechazo_pre_aprobacion" : .DataPropertyName = "fecha_rechazo_pre_aprobacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Fecha Rechazo Preaprobación" : .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            x += +1
            Dim col_fecha_rechazo_aprobacion As New DataGridViewTextBoxColumn
            With col_fecha_rechazo_aprobacion
                .Name = "fecha_rechazo_aprobacion" : .DataPropertyName = "fecha_rechazo_aprobacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Fecha Rechazo Aprobación" : .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_idcliente As New DataGridViewTextBoxColumn
            With col_idcliente
                .Name = "idcliente" : .DataPropertyName = "idcliente" : .DisplayIndex = x : .Visible = True : .HeaderText = "idcliente"
            End With
            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto_solicitado" : .DataPropertyName = "monto_solicitado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Solicitado" : .DefaultCellStyle.Format = "#,###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
            x += +1
            Dim col_monto_preaprobado As New DataGridViewTextBoxColumn
            With col_monto_preaprobado
                .Name = "monto_preaprobado" : .DataPropertyName = "monto_preaprobado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Preaprobado" : .DefaultCellStyle.Format = "#,###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
            x += +1
            Dim col_monto_aprobado As New DataGridViewTextBoxColumn
            With col_monto_aprobado
                .Name = "monto_aprobado" : .DataPropertyName = "monto_aprobado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Aprobado" : .DefaultCellStyle.Format = "#,###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
            x += +1
            Dim col_periodo_pago As New DataGridViewTextBoxColumn
            With col_periodo_pago
                .Name = "periodo_pago" : .DataPropertyName = "periodo_pago"
                .DisplayIndex = x : .Visible = False : .HeaderText = "periodo_pago"
            End With
            x += +1
            Dim col_dia_pago As New DataGridViewTextBoxColumn
            With col_dia_pago
                .Name = "dia_pago" : .DataPropertyName = "dia_pago"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia_pago"
            End With
            x += +1
            Dim col_fecha1 As New DataGridViewTextBoxColumn
            With col_fecha1
                .Name = "fecha1" : .DataPropertyName = "fecha1"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fecha1"
            End With
            x += +1
            Dim col_fecha2 As New DataGridViewTextBoxColumn
            With col_fecha2
                .Name = "fecha2" : .DataPropertyName = "fecha2"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fecha2"
            End With
            x += +1
            Dim col_fecha3 As New DataGridViewTextBoxColumn
            With col_fecha3
                .Name = "fecha3" : .DataPropertyName = "fecha3"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fecha3"
            End With
            x += +1
            Dim col_fecha4 As New DataGridViewTextBoxColumn
            With col_fecha4
                .Name = "fecha4" : .DataPropertyName = "fecha4"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fecha4"
            End With
            x += +1
            Dim col_dia1 As New DataGridViewTextBoxColumn
            With col_dia1
                .Name = "dia1" : .DataPropertyName = "dia1"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia1"
            End With
            x += +1
            Dim col_dia2 As New DataGridViewTextBoxColumn
            With col_dia2
                .Name = "dia2" : .DataPropertyName = "dia2"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia2"
            End With
            x += +1
            Dim col_dia3 As New DataGridViewTextBoxColumn
            With col_dia3
                .Name = "dia3" : .DataPropertyName = "dia3"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia3"
            End With
            x += +1
            Dim col_dia4 As New DataGridViewTextBoxColumn
            With col_dia4
                .Name = "dia4" : .DataPropertyName = "dia4"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia4"
            End With
            x += +1
            Dim col_dia5 As New DataGridViewTextBoxColumn
            With col_dia5
                .Name = "dia5" : .DataPropertyName = "dia5"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia5"
            End With
            x += +1
            Dim col_dia6 As New DataGridViewTextBoxColumn
            With col_dia6
                .Name = "dia6" : .DataPropertyName = "dia6"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia6"
            End With
            x += +1
            Dim col_dia7 As New DataGridViewTextBoxColumn
            With col_dia7
                .Name = "dia7" : .DataPropertyName = "dia7"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia7"
            End With
            x += +1
            Dim col_horario_pago_ini As New DataGridViewTextBoxColumn
            With col_horario_pago_ini
                .Name = "horario_pago_ini" : .DataPropertyName = "horario_pago_ini"
                .DisplayIndex = x : .Visible = False : .HeaderText = "horario_pago_ini"
            End With
            x += +1
            Dim col_horario_pago_fin As New DataGridViewTextBoxColumn
            With col_horario_pago_fin
                .Name = "horario_pago_fin" : .DataPropertyName = "horario_pago_fin"
                .DisplayIndex = x : .Visible = False : .HeaderText = "horario_pago_fin"
            End With
            x += +1
            Dim col_tipo_pago As New DataGridViewTextBoxColumn
            With col_tipo_pago
                .Name = "tipo_pago" : .DataPropertyName = "tipo_pago"
                .DisplayIndex = x : .Visible = False : .HeaderText = "tipo_pago"
            End With
            x += +1
            Dim col_sobregiro As New DataGridViewTextBoxColumn
            With col_sobregiro
                .Name = "sobregiro" : .DataPropertyName = "sobregiro"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Sobregiro" : .DefaultCellStyle.Format = "#,###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
            x += +1
            Dim col_total_asignado As New DataGridViewTextBoxColumn
            With col_total_asignado
                .Name = "total_asignado" : .DataPropertyName = "total_asignado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total Asignado" : .DefaultCellStyle.Format = "#,###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
            x += +1
            Dim col_porcentaje_sobregiro As New DataGridViewTextBoxColumn
            With col_porcentaje_sobregiro
                .Name = "porcentaje_sobregiro" : .DataPropertyName = "porcentaje_sobregiro"
                .DisplayIndex = x : .Visible = False : .HeaderText = "porcentaje_sobregiro" : .DefaultCellStyle.Format = "#,###,###,###0.00"
            End With
            x += +1
            Dim col_idusuario_personal As New DataGridViewTextBoxColumn
            With col_idusuario_personal
                .Name = "idusuario_personal" : .DataPropertyName = "idusuario_personal"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idusuario_personal"
            End With
            x += +1
            Dim col_idusuario_personalmod As New DataGridViewTextBoxColumn
            With col_idusuario_personalmod
                .Name = "idusuario_personalmod" : .DataPropertyName = "idusuario_personalmod"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idusuario_personalmod"
            End With
            x += +1
            Dim col_usuario_pre_aprobacion As New DataGridViewTextBoxColumn
            With col_usuario_pre_aprobacion
                .Name = "usuario_pre_aprobacion" : .DataPropertyName = "usuario_pre_aprobacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Usuario Preaprobación"
            End With
            x += +1
            Dim col_usuario_aprobacion As New DataGridViewTextBoxColumn
            With col_usuario_aprobacion
                .Name = "usuario_aprobacion" : .DataPropertyName = "usuario_aprobacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Usuario Aprobación"
            End With
            x += +1
            Dim col_usuario_rechazo_pre_aprobacion As New DataGridViewTextBoxColumn
            With col_usuario_rechazo_pre_aprobacion
                .Name = "usuario_rechazo_pre_aprobacion" : .DataPropertyName = "usuario_rechazo_pre_aprobacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Usuario Rechazo Preaprobación"
            End With
            x += +1
            Dim col_usuario_rechazo_aprobacion As New DataGridViewTextBoxColumn
            With col_usuario_rechazo_aprobacion
                .Name = "usuario_rechazo_aprobacion" : .DataPropertyName = "usuario_rechazo_aprobacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Usuario Rechazo Aprobación"
            End With
            x += +1
            Dim col_funcionario As New DataGridViewTextBoxColumn
            With col_funcionario
                .Name = "funcionario" : .DataPropertyName = "funcionario"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Funcionario"
            End With
            x += +1
            Dim col_solicitante As New DataGridViewTextBoxColumn
            With col_solicitante
                .Name = "solicitante" : .DataPropertyName = "solicitante"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Solicitante" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_producto As New DataGridViewTextBoxColumn
            With col_producto
                .Name = "producto" : .DataPropertyName = "producto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "producto"
            End With
            x += +1
            Dim col_tipo_facturacion As New DataGridViewTextBoxColumn
            With col_tipo_facturacion
                .Name = "tipo_facturacion" : .DataPropertyName = "tipo_facturacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "tipo_facturacion"
            End With
            x += +1
            Dim col_contado As New DataGridViewTextBoxColumn
            With col_contado
                .Name = "contado" : .DataPropertyName = "contado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "contado"
            End With


            x += +1
            Dim col_idcontacto_comercial As New DataGridViewTextBoxColumn
            With col_idcontacto_comercial
                .Name = "idcontacto_comercial" : .DataPropertyName = "idcontacto_comercial"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcontacto_comercial" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_idcontacto_pago As New DataGridViewTextBoxColumn
            With col_idcontacto_pago
                .Name = "idcontacto_pago" : .DataPropertyName = "idcontacto_pago"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcontacto_pago" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_nombre_comercial As New DataGridViewTextBoxColumn
            With col_nombre_comercial
                .Name = "nombre_comercial" : .DataPropertyName = "nombre_comercial"
                .DisplayIndex = x : .Visible = False : .HeaderText = "nombre_comercial" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_nombre_pagos As New DataGridViewTextBoxColumn
            With col_nombre_pagos
                .Name = "nombre_pagos" : .DataPropertyName = "nombre_pagos"
                .DisplayIndex = x : .Visible = False : .HeaderText = "nombre_pagos" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_cargo_comercial As New DataGridViewTextBoxColumn
            With col_cargo_comercial
                .Name = "cargo_comercial" : .DataPropertyName = "cargo_comercial"
                .DisplayIndex = x : .Visible = False : .HeaderText = "cargo_comercial" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_cargo_pagos As New DataGridViewTextBoxColumn
            With col_cargo_pagos
                .Name = "cargo_pagos" : .DataPropertyName = "cargo_pagos"
                .DisplayIndex = x : .Visible = False : .HeaderText = "cargo_pagos" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_email_comercial As New DataGridViewTextBoxColumn
            With col_email_comercial
                .Name = "email_comercial" : .DataPropertyName = "email_comercial"
                .DisplayIndex = x : .Visible = False : .HeaderText = "email_comercial" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_email_pagos As New DataGridViewTextBoxColumn
            With col_email_pagos
                .Name = "email_pagos" : .DataPropertyName = "email_pagos"
                .DisplayIndex = x : .Visible = False : .HeaderText = "email_pagos" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_forma_pago As New DataGridViewTextBoxColumn
            With col_forma_pago
                .Name = "forma_pago" : .DataPropertyName = "forma_pago"
                .DisplayIndex = x : .Visible = False : .HeaderText = "forma_pago" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_direccion_facturacion As New DataGridViewTextBoxColumn
            With col_direccion_facturacion
                .Name = "direccion_facturacion" : .DataPropertyName = "direccion_facturacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "direccion_facturacion" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_fecha_corte As New DataGridViewTextBoxColumn
            With col_fecha_corte
                .Name = "fecha_corte" : .DataPropertyName = "fecha_corte"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fecha_corte" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_periodo_facturacion As New DataGridViewTextBoxColumn
            With col_periodo_facturacion
                .Name = "periodo_facturacion" : .DataPropertyName = "periodo_facturacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "periodo_facturacion" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_fechaf1 As New DataGridViewTextBoxColumn
            With col_fechaf1
                .Name = "fechaf1" : .DataPropertyName = "fechaf1"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fechaf1"
            End With
            x += +1
            Dim col_fechaf2 As New DataGridViewTextBoxColumn
            With col_fechaf2
                .Name = "fechaf2" : .DataPropertyName = "fechaf2"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fechaf2"
            End With
            x += +1
            Dim col_fechaf3 As New DataGridViewTextBoxColumn
            With col_fechaf3
                .Name = "fechaf3" : .DataPropertyName = "fechaf3"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fechaf3"
            End With
            x += +1
            Dim col_fechaf4 As New DataGridViewTextBoxColumn
            With col_fechaf4
                .Name = "fechaf4" : .DataPropertyName = "fechaf4"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fechaf4"
            End With
            x += +1
            Dim col_diaf1 As New DataGridViewTextBoxColumn
            With col_diaf1
                .Name = "diaf1" : .DataPropertyName = "diaf1"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf1"
            End With
            x += +1
            Dim col_diaf2 As New DataGridViewTextBoxColumn
            With col_diaf2
                .Name = "diaf2" : .DataPropertyName = "diaf2"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf2"
            End With
            x += +1
            Dim col_diaf3 As New DataGridViewTextBoxColumn
            With col_diaf3
                .Name = "diaf3" : .DataPropertyName = "diaf3"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf3"
            End With
            x += +1
            Dim col_diaf4 As New DataGridViewTextBoxColumn
            With col_diaf4
                .Name = "diaf4" : .DataPropertyName = "diaf4"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf4"
            End With
            x += +1
            Dim col_diaf5 As New DataGridViewTextBoxColumn
            With col_diaf5
                .Name = "diaf5" : .DataPropertyName = "diaf5"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia5"
            End With
            x += +1
            Dim col_diaf6 As New DataGridViewTextBoxColumn
            With col_diaf6
                .Name = "diaf6" : .DataPropertyName = "diaf6"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf6"
            End With
            x += +1
            Dim col_diaf7 As New DataGridViewTextBoxColumn
            With col_diaf7
                .Name = "diaf7" : .DataPropertyName = "diaf7"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf7"
            End With
            x += +1
            Dim col_horario_facturacion_ini As New DataGridViewTextBoxColumn
            With col_horario_facturacion_ini
                .Name = "horario_facturacion_ini" : .DataPropertyName = "horario_facturacion_ini"
                .DisplayIndex = x : .Visible = False : .HeaderText = "horario_facturacion_ini"
            End With
            x += +1
            Dim col_horario_facturacion_fin As New DataGridViewTextBoxColumn
            With col_horario_facturacion_fin
                .Name = "horario_facturacion_fin" : .DataPropertyName = "horario_facturacion_fin"
                .DisplayIndex = x : .Visible = False : .HeaderText = "horario_facturacion_fin"
            End With
            x += +1
            Dim col_orden_compra As New DataGridViewTextBoxColumn
            With col_orden_compra
                .Name = "orden_compra" : .DataPropertyName = "orden_compra"
                .DisplayIndex = x : .Visible = False : .HeaderText = "orden_compra"
            End With

            .Columns.AddRange(col_nro_solicitud, col_fecha_solicitud, col_fecha_preaprobacion, col_fecha_aprobacion, col_codigo, col_cliente, _
                              col_monto, col_monto_preaprobado, col_monto_aprobado, col_sobregiro, col_total_asignado, col_funcionario, _
                              col_periodo_pago, col_dia_pago, col_horario_pago_ini, col_horario_pago_fin, _
                              col_usuario_aprobacion, col_usuario_pre_aprobacion, _
                              col_fecha1, col_fecha2, col_fecha3, col_fecha4, col_dia1, col_dia2, col_dia3, col_dia4, col_dia5, col_dia6, col_dia7, _
                              col_solicitante, col_producto, col_tipo_facturacion, col_contado, _
                              col_idcontacto_comercial, col_idcontacto_pago, _
                              col_nombre_comercial, col_nombre_pagos, _
                              col_cargo_comercial, col_email_comercial, col_cargo_pagos, col_email_pagos, _
                              col_forma_pago, col_direccion_facturacion, col_fecha_corte, col_periodo_facturacion, _
                              col_fechaf1, col_fechaf2, col_fechaf3, col_fechaf4, col_diaf1, col_diaf2, col_diaf3, col_diaf4, col_diaf5, col_diaf6, col_diaf7, _
                              col_horario_facturacion_ini, col_horario_facturacion_fin, col_orden_compra, col_idcliente)

        End With
    End Sub
    Private Sub ConfigurarDGVListaCredito(estado As Integer)
        With dgvListaCredito
            RemoveHandler Me.dgvListaCredito.RowEnter, AddressOf Me.dgvListaCredito_RowEnter
            Cls_Utilitarios.FormatDataGridView(dgvListaCredito)
            AddHandler Me.dgvListaCredito.RowEnter, AddressOf Me.dgvListaCredito_RowEnter
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
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id Solicitud"
            End With
            x += +1
            Dim col_fecha_solicitud As New DataGridViewTextBoxColumn
            With col_fecha_solicitud
                .Name = "fecha_solicitud" : .DataPropertyName = "fecha_solicitud"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Solicitud" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            Dim col_fecha_preaprobacion As New DataGridViewTextBoxColumn
            col_fecha_preaprobacion.Visible = False
            If estado = 2 Then
                x += +1
                With col_fecha_preaprobacion
                    .Name = "fecha_preaprobacion" : .DataPropertyName = "fecha_preaprobacion"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Preaprobación" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .DefaultCellStyle.Format = "dd/MM/yyyy"
                End With
            End If
            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_idcliente As New DataGridViewTextBoxColumn
            With col_idcliente
                .Name = "idcliente" : .DataPropertyName = "idcliente"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcliente"
            End With
            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto_solicitado" : .DataPropertyName = "monto_solicitado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Solicitado" : .DefaultCellStyle.Format = "#,###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
            Dim col_monto_preaprobado As New DataGridViewTextBoxColumn
            col_monto_preaprobado.Visible = False
            If estado = 2 Then
                x += +1
                With col_monto_preaprobado
                    .Name = "monto_preaprobado" : .DataPropertyName = "monto_preaprobado"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Preaprobado" : .DefaultCellStyle.Format = "#,###,###,###0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                End With
            End If
            x += +1
            Dim col_solicitante As New DataGridViewTextBoxColumn
            With col_solicitante
                .Name = "solicitante" : .DataPropertyName = "solicitante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Solicitante" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_periodo_pago As New DataGridViewTextBoxColumn
            With col_periodo_pago
                .Name = "periodo_pago" : .DataPropertyName = "periodo_pago"
                .DisplayIndex = x : .Visible = False : .HeaderText = "periodo_pago"
            End With
            x += +1
            Dim col_fecha1 As New DataGridViewTextBoxColumn
            With col_fecha1
                .Name = "fecha1" : .DataPropertyName = "fecha1"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fecha1"
            End With
            x += +1
            Dim col_fecha2 As New DataGridViewTextBoxColumn
            With col_fecha2
                .Name = "fecha2" : .DataPropertyName = "fecha2"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fecha2"
            End With
            x += +1
            Dim col_fecha3 As New DataGridViewTextBoxColumn
            With col_fecha3
                .Name = "fecha3" : .DataPropertyName = "fecha3"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fecha3"
            End With
            x += +1
            Dim col_fecha4 As New DataGridViewTextBoxColumn
            With col_fecha4
                .Name = "fecha4" : .DataPropertyName = "fecha4"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fecha4"
            End With
            x += +1
            Dim col_dia1 As New DataGridViewTextBoxColumn
            With col_dia1
                .Name = "dia1" : .DataPropertyName = "dia1"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia1"
            End With
            x += +1
            Dim col_dia2 As New DataGridViewTextBoxColumn
            With col_dia2
                .Name = "dia2" : .DataPropertyName = "dia2"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia2"
            End With
            x += +1
            Dim col_dia3 As New DataGridViewTextBoxColumn
            With col_dia3
                .Name = "dia3" : .DataPropertyName = "dia3"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia3"
            End With
            x += +1
            Dim col_dia4 As New DataGridViewTextBoxColumn
            With col_dia4
                .Name = "dia4" : .DataPropertyName = "dia4"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia4"
            End With
            x += +1
            Dim col_dia5 As New DataGridViewTextBoxColumn
            With col_dia5
                .Name = "dia5" : .DataPropertyName = "dia5"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia5"
            End With
            x += +1
            Dim col_dia6 As New DataGridViewTextBoxColumn
            With col_dia6
                .Name = "dia6" : .DataPropertyName = "dia6"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia6"
            End With
            x += +1
            Dim col_dia7 As New DataGridViewTextBoxColumn
            With col_dia7
                .Name = "dia7" : .DataPropertyName = "dia7"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia7"
            End With
            x += +1
            Dim col_horario_pago_ini As New DataGridViewTextBoxColumn
            With col_horario_pago_ini
                .Name = "horario_pago_ini" : .DataPropertyName = "horario_pago_ini"
                .DisplayIndex = x : .Visible = False : .HeaderText = "horario_pago_ini"
            End With
            x += +1
            Dim col_horario_pago_fin As New DataGridViewTextBoxColumn
            With col_horario_pago_fin
                .Name = "horario_pago_fin" : .DataPropertyName = "horario_pago_fin"
                .DisplayIndex = x : .Visible = False : .HeaderText = "horario_pago_fin"
            End With
            x += +1
            Dim col_producto As New DataGridViewTextBoxColumn
            With col_producto
                .Name = "producto" : .DataPropertyName = "producto"
                .DisplayIndex = x : .Visible = False : .HeaderText = "producto"
            End With
            x += +1
            Dim col_tipo_facturacion As New DataGridViewTextBoxColumn
            With col_tipo_facturacion
                .Name = "tipo_facturacion" : .DataPropertyName = "tipo_facturacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "tipo_facturacion"
            End With
            x += +1
            Dim col_contado As New DataGridViewTextBoxColumn
            With col_contado
                .Name = "contado" : .DataPropertyName = "contado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "contado"
            End With
            x += +1
            Dim col_idusuario_personal As New DataGridViewTextBoxColumn
            With col_idusuario_personal
                .Name = "idusuario_personal" : .DataPropertyName = "idusuario_personal"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idusuario_personal"
            End With
            x += +1
            Dim col_usuario_pre_aprobacion As New DataGridViewTextBoxColumn
            With col_usuario_pre_aprobacion
                .Name = "usuario_pre_aprobacion" : .DataPropertyName = "usuario_pre_aprobacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Usuario Preaprobación"
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            x += +1
            Dim col_idcontacto_comercial As New DataGridViewTextBoxColumn
            With col_idcontacto_comercial
                .Name = "idcontacto_comercial" : .DataPropertyName = "idcontacto_comercial"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcontacto_comercial" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_idcontacto_pago As New DataGridViewTextBoxColumn
            With col_idcontacto_pago
                .Name = "idcontacto_pago" : .DataPropertyName = "idcontacto_pago"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcontacto_pago" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_nombre_comercial As New DataGridViewTextBoxColumn
            With col_nombre_comercial
                .Name = "nombre_comercial" : .DataPropertyName = "nombre_comercial"
                .DisplayIndex = x : .Visible = False : .HeaderText = "nombre_comercial" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_nombre_pagos As New DataGridViewTextBoxColumn
            With col_nombre_pagos
                .Name = "nombre_pagos" : .DataPropertyName = "nombre_pagos"
                .DisplayIndex = x : .Visible = False : .HeaderText = "nombre_pagos" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_cargo_comercial As New DataGridViewTextBoxColumn
            With col_cargo_comercial
                .Name = "cargo_comercial" : .DataPropertyName = "cargo_comercial"
                .DisplayIndex = x : .Visible = False : .HeaderText = "cargo_comercial" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_cargo_pagos As New DataGridViewTextBoxColumn
            With col_cargo_pagos
                .Name = "cargo_pagos" : .DataPropertyName = "cargo_pagos"
                .DisplayIndex = x : .Visible = False : .HeaderText = "cargo_pagos" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_email_comercial As New DataGridViewTextBoxColumn
            With col_email_comercial
                .Name = "email_comercial" : .DataPropertyName = "email_comercial"
                .DisplayIndex = x : .Visible = False : .HeaderText = "email_comercial" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_email_pagos As New DataGridViewTextBoxColumn
            With col_email_pagos
                .Name = "email_pagos" : .DataPropertyName = "email_pagos"
                .DisplayIndex = x : .Visible = False : .HeaderText = "email_pagos" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_forma_pago As New DataGridViewTextBoxColumn
            With col_forma_pago
                .Name = "forma_pago" : .DataPropertyName = "forma_pago"
                .DisplayIndex = x : .Visible = False : .HeaderText = "forma_pago" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_direccion_facturacion As New DataGridViewTextBoxColumn
            With col_direccion_facturacion
                .Name = "direccion_facturacion" : .DataPropertyName = "direccion_facturacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "direccion_facturacion" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_fecha_corte As New DataGridViewTextBoxColumn
            With col_fecha_corte
                .Name = "fecha_corte" : .DataPropertyName = "fecha_corte"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fecha_corte" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_periodo_facturacion As New DataGridViewTextBoxColumn
            With col_periodo_facturacion
                .Name = "periodo_facturacion" : .DataPropertyName = "periodo_facturacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "periodo_facturacion" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_fechaf1 As New DataGridViewTextBoxColumn
            With col_fechaf1
                .Name = "fechaf1" : .DataPropertyName = "fechaf1"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fechaf1"
            End With
            x += +1
            Dim col_fechaf2 As New DataGridViewTextBoxColumn
            With col_fechaf2
                .Name = "fechaf2" : .DataPropertyName = "fechaf2"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fechaf2"
            End With
            x += +1
            Dim col_fechaf3 As New DataGridViewTextBoxColumn
            With col_fechaf3
                .Name = "fechaf3" : .DataPropertyName = "fechaf3"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fechaf3"
            End With
            x += +1
            Dim col_fechaf4 As New DataGridViewTextBoxColumn
            With col_fechaf4
                .Name = "fechaf4" : .DataPropertyName = "fechaf4"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fechaf4"
            End With
            x += +1
            Dim col_diaf1 As New DataGridViewTextBoxColumn
            With col_diaf1
                .Name = "diaf1" : .DataPropertyName = "diaf1"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf1"
            End With
            x += +1
            Dim col_diaf2 As New DataGridViewTextBoxColumn
            With col_diaf2
                .Name = "diaf2" : .DataPropertyName = "diaf2"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf2"
            End With
            x += +1
            Dim col_diaf3 As New DataGridViewTextBoxColumn
            With col_diaf3
                .Name = "diaf3" : .DataPropertyName = "diaf3"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf3"
            End With
            x += +1
            Dim col_diaf4 As New DataGridViewTextBoxColumn
            With col_diaf4
                .Name = "diaf4" : .DataPropertyName = "diaf4"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf4"
            End With
            x += +1
            Dim col_diaf5 As New DataGridViewTextBoxColumn
            With col_diaf5
                .Name = "diaf5" : .DataPropertyName = "diaf5"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia5"
            End With
            x += +1
            Dim col_diaf6 As New DataGridViewTextBoxColumn
            With col_diaf6
                .Name = "diaf6" : .DataPropertyName = "diaf6"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf6"
            End With
            x += +1
            Dim col_diaf7 As New DataGridViewTextBoxColumn
            With col_diaf7
                .Name = "diaf7" : .DataPropertyName = "diaf7"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf7"
            End With
            x += +1
            Dim col_horario_facturacion_ini As New DataGridViewTextBoxColumn
            With col_horario_facturacion_ini
                .Name = "horario_facturacion_ini" : .DataPropertyName = "horario_facturacion_ini"
                .DisplayIndex = x : .Visible = False : .HeaderText = "horario_facturacion_ini"
            End With
            x += +1
            Dim col_horario_facturacion_fin As New DataGridViewTextBoxColumn
            With col_horario_facturacion_fin
                .Name = "horario_facturacion_fin" : .DataPropertyName = "horario_facturacion_fin"
                .DisplayIndex = x : .Visible = False : .HeaderText = "horario_facturacion_fin"
            End With
            x += +1
            Dim col_orden_compra As New DataGridViewTextBoxColumn
            With col_orden_compra
                .Name = "orden_compra" : .DataPropertyName = "orden_compra"
                .DisplayIndex = x : .Visible = False : .HeaderText = "orden_compra"
            End With

            .Columns.AddRange(col_id, col_fecha_solicitud, col_fecha_preaprobacion, col_codigo, col_cliente, col_idcliente, col_monto, col_monto_preaprobado, col_solicitante, col_periodo_pago, _
                                  col_fecha1, col_fecha2, col_fecha3, col_fecha4, col_dia1, col_dia2, col_dia3, col_dia4, col_dia5, col_dia6, col_dia7, _
                                  col_horario_pago_ini, col_horario_pago_fin, col_producto, col_tipo_facturacion, col_contado, _
                                  col_idusuario_personal, col_usuario_pre_aprobacion, col_tipo, col_idcontacto_comercial, col_idcontacto_pago, _
                                  col_nombre_comercial, col_nombre_pagos, _
                                  col_cargo_comercial, col_email_comercial, col_cargo_pagos, col_email_pagos, _
                                  col_forma_pago, col_direccion_facturacion, col_fecha_corte, col_periodo_facturacion, _
                                  col_fechaf1, col_fechaf2, col_fechaf3, col_fechaf4, col_diaf1, col_diaf2, col_diaf3, col_diaf4, col_diaf5, col_diaf6, col_diaf7, _
                                  col_horario_facturacion_ini, col_horario_facturacion_fin, col_orden_compra)
        End With
    End Sub
    Private Sub ConfigurarDGVSolicitudCredito()
        With dgvSolicitudCredito
            Cls_Utilitarios.FormatDataGridView(dgvSolicitudCredito)
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
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha" : .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
            End With
            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto_solicitado" : .DataPropertyName = "monto_solicitado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Solicitado" : .DefaultCellStyle.Format = "#,###,###,###0.00"
            End With
            x += +1
            Dim col_monto_preaprobacion As New DataGridViewTextBoxColumn
            With col_monto_preaprobacion
                .Name = "monto_preaprobacion" : .DataPropertyName = "monto_preaprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Preaprobación" : .DefaultCellStyle.Format = "#,###,###,###0.00"
            End With
            x += +1
            Dim col_monto_aprobacion As New DataGridViewTextBoxColumn
            With col_monto_aprobacion
                .Name = "monto_aprobacion" : .DataPropertyName = "monto_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Aprobación" : .DefaultCellStyle.Format = "#,###,###,###0.00"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
            End With
            x += +1
            Dim col_preaprobacion As New DataGridViewTextBoxColumn
            With col_preaprobacion
                .Name = "fecha_preaprobacion" : .DataPropertyName = "fecha_preaprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Preaprobación" : .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            x += +1
            Dim col_usuario_preaprobacion As New DataGridViewTextBoxColumn
            With col_usuario_preaprobacion
                .Name = "usuario_preaprobacion" : .DataPropertyName = "usuario_preaprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario Preaprobación"
            End With
            x += +1
            Dim col_aprobacion As New DataGridViewTextBoxColumn
            With col_aprobacion
                .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aprobación" : .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            x += +1
            Dim col_usuario_aprobacion As New DataGridViewTextBoxColumn
            With col_usuario_aprobacion
                .Name = "usuario_aprobacion" : .DataPropertyName = "usuario_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario Aprobación"
            End With
            x += +1
            Dim col_rechazo_pre_aprobacion As New DataGridViewTextBoxColumn
            With col_rechazo_pre_aprobacion
                .Name = "fecha_rechazo_preaprobacion" : .DataPropertyName = "fecha_rechazo_preaprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Rechazo Preaprobación" : .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            x += +1
            Dim col_usuario_rechazo_preaprobacion As New DataGridViewTextBoxColumn
            With col_usuario_rechazo_preaprobacion
                .Name = "usuario_rechazo_preaprobacion" : .DataPropertyName = "usuario_rechazo_preaprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario Rechazo Preaprobación"
            End With
            x += +1
            Dim col_rechazo_aprobacion As New DataGridViewTextBoxColumn
            With col_rechazo_aprobacion
                .Name = "fecha_rechazo_aprobacion" : .DataPropertyName = "fecha_rechazo_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Rechazo Aprobación" : .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            x += +1
            Dim col_usuario_rechazo_aprobacion As New DataGridViewTextBoxColumn
            With col_usuario_rechazo_aprobacion
                .Name = "usuario_rechazo_aprobacion" : .DataPropertyName = "usuario_rechazo_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario Rechazo Aprobación"
            End With
            x += +1
            Dim col_anulacion As New DataGridViewTextBoxColumn
            With col_anulacion
                .Name = "fecha_anulacion" : .DataPropertyName = "fecha_anulacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Anulación" : .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            x += +1
            Dim col_usuario_anulacion As New DataGridViewTextBoxColumn
            With col_usuario_anulacion
                .Name = "usuario_anulacion" : .DataPropertyName = "usuario_anulacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario Anulación"
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id"
            End With
            x += +1
            Dim col_idestado As New DataGridViewTextBoxColumn
            With col_idestado
                .Name = "idestado" : .DataPropertyName = "idestado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id estado"
            End With
            x += +1
            Dim col_comercial As New DataGridViewTextBoxColumn
            With col_comercial
                .Name = "comercial" : .DataPropertyName = "comercial"
                .DisplayIndex = x : .Visible = False : .HeaderText = "comercial"
            End With
            x += +1
            Dim col_pagos As New DataGridViewTextBoxColumn
            With col_pagos
                .Name = "pagos" : .DataPropertyName = "pagos"
                .DisplayIndex = x : .Visible = False : .HeaderText = "pagos"
            End With
            x += +1
            Dim col_condicion As New DataGridViewTextBoxColumn
            With col_condicion
                .Name = "condicion" : .DataPropertyName = "condicion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "condicion"
            End With
            x += +1
            Dim col_fecha1 As New DataGridViewTextBoxColumn
            With col_fecha1
                .Name = "fecha1" : .DataPropertyName = "fecha1"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fecha1"
            End With
            x += +1
            Dim col_fecha2 As New DataGridViewTextBoxColumn
            With col_fecha2
                .Name = "fecha2" : .DataPropertyName = "fecha2"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fecha2"
            End With
            x += +1
            Dim col_fecha3 As New DataGridViewTextBoxColumn
            With col_fecha3
                .Name = "fecha3" : .DataPropertyName = "fecha3"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fecha3"
            End With
            x += +1
            Dim col_fecha4 As New DataGridViewTextBoxColumn
            With col_fecha4
                .Name = "fecha4" : .DataPropertyName = "fecha4"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fecha4"
            End With
            x += +1
            Dim col_dia1 As New DataGridViewTextBoxColumn
            With col_dia1
                .Name = "dia1" : .DataPropertyName = "dia1"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia1"
            End With
            x += +1
            Dim col_dia2 As New DataGridViewTextBoxColumn
            With col_dia2
                .Name = "dia2" : .DataPropertyName = "dia2"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia2"
            End With
            x += +1
            Dim col_dia3 As New DataGridViewTextBoxColumn
            With col_dia3
                .Name = "dia3" : .DataPropertyName = "dia3"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia3"
            End With
            x += +1
            Dim col_dia4 As New DataGridViewTextBoxColumn
            With col_dia4
                .Name = "dia4" : .DataPropertyName = "dia4"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia4"
            End With
            x += +1
            Dim col_dia5 As New DataGridViewTextBoxColumn
            With col_dia5
                .Name = "dia5" : .DataPropertyName = "dia5"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia5"
            End With
            x += +1
            Dim col_dia6 As New DataGridViewTextBoxColumn
            With col_dia6
                .Name = "dia6" : .DataPropertyName = "dia6"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia6"
            End With
            x += +1
            Dim col_dia7 As New DataGridViewTextBoxColumn
            With col_dia7
                .Name = "dia7" : .DataPropertyName = "dia7"
                .DisplayIndex = x : .Visible = False : .HeaderText = "dia7"
            End With
            x += +1
            Dim col_horario_pago_ini As New DataGridViewTextBoxColumn
            With col_horario_pago_ini
                .Name = "horario_pago_ini" : .DataPropertyName = "horario_pago_ini"
                .DisplayIndex = x : .Visible = False : .HeaderText = "horario_pago_ini"
            End With
            x += +1
            Dim col_horario_pago_fin As New DataGridViewTextBoxColumn
            With col_horario_pago_fin
                .Name = "horario_pago_fin" : .DataPropertyName = "horario_pago_fin"
                .DisplayIndex = x : .Visible = False : .HeaderText = "horario_pago_fin"
            End With
            x += +1
            Dim col_producto As New DataGridViewTextBoxColumn
            With col_producto
                .Name = "producto" : .DataPropertyName = "producto"
                .DisplayIndex = x : .Visible = False : .HeaderText = "producto"
            End With
            x += +1
            Dim col_tipo_facturacion As New DataGridViewTextBoxColumn
            With col_tipo_facturacion
                .Name = "tipo_facturacion" : .DataPropertyName = "tipo_facturacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "tipo_facturacion"
            End With
            x += +1
            Dim col_idsolicitud_producto As New DataGridViewTextBoxColumn
            With col_idsolicitud_producto
                .Name = "idsolicitud_producto" : .DataPropertyName = "idsolicitud_producto"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idsolicitud_producto"
            End With
            x += +1
            Dim col_idsolicitud_tipo_facturacion As New DataGridViewTextBoxColumn
            With col_idsolicitud_tipo_facturacion
                .Name = "idsolicitud_tipo_facturacion" : .DataPropertyName = "idsolicitud_tipo_facturacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idsolicitud_tipo_facturacion"
            End With
            x += +1
            Dim col_contado As New DataGridViewTextBoxColumn
            With col_contado
                .Name = "contado" : .DataPropertyName = "contado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "contado"
            End With
            x += +1
            Dim col_contacto_facturacion As New DataGridViewTextBoxColumn
            With col_contacto_facturacion
                .Name = "contacto_facturacion" : .DataPropertyName = "contacto_facturacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "contacto_facturacion"
            End With
            x += +1
            Dim col_orden_compra As New DataGridViewTextBoxColumn
            With col_orden_compra
                .Name = "orden_compra" : .DataPropertyName = "orden_compra"
                .DisplayIndex = x : .Visible = False : .HeaderText = "orden_compra"
            End With
            x += +1
            Dim col_liquidacion_documento As New DataGridViewTextBoxColumn
            With col_liquidacion_documento
                .Name = "liquidacion_documento" : .DataPropertyName = "liquidacion_documento"
                .DisplayIndex = x : .Visible = False : .HeaderText = "liquidacion_documento"
            End With
            x += +1
            Dim col_forma_facturacion As New DataGridViewTextBoxColumn
            With col_forma_facturacion
                .Name = "forma_facturacion" : .DataPropertyName = "forma_facturacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "forma_facturacion"
            End With
            x += +1
            Dim col_concepto_credito As New DataGridViewTextBoxColumn
            With col_concepto_credito
                .Name = "concepto" : .DataPropertyName = "concepto"
                .DisplayIndex = x : .Visible = False : .HeaderText = "concepto"
            End With

            'hlamas 08-04-2016
            x += +1
            Dim col_forma_pago As New DataGridViewTextBoxColumn
            With col_forma_pago
                .Name = "forma_pago" : .DataPropertyName = "forma_pago" : .DisplayIndex = x : .Visible = False : .HeaderText = "forma_pago"
            End With
            x += +1
            Dim col_fecha_corte As New DataGridViewTextBoxColumn
            With col_fecha_corte
                .Name = "fecha_corte" : .DataPropertyName = "fecha_corte" : .DisplayIndex = x : .Visible = False : .HeaderText = "fecha_corte"
            End With
            x += +1
            Dim col_periodo_facturacion As New DataGridViewTextBoxColumn
            With col_periodo_facturacion
                .Name = "periodo_facturacion" : .DataPropertyName = "periodo_facturacion" : .DisplayIndex = x : .Visible = False : .HeaderText = "periodo_facturacion"
            End With
            x += +1
            Dim col_fechaf1 As New DataGridViewTextBoxColumn
            With col_fechaf1
                .Name = "fechaf1" : .DataPropertyName = "fechaf1"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fechaf1"
            End With
            x += +1
            Dim col_fechaf2 As New DataGridViewTextBoxColumn
            With col_fechaf2
                .Name = "fechaf2" : .DataPropertyName = "fechaf2"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fechaf2"
            End With
            x += +1
            Dim col_fechaf3 As New DataGridViewTextBoxColumn
            With col_fechaf3
                .Name = "fechaf3" : .DataPropertyName = "fechaf3"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fechaf3"
            End With
            x += +1
            Dim col_fechaf4 As New DataGridViewTextBoxColumn
            With col_fechaf4
                .Name = "fechaf4" : .DataPropertyName = "fechaf4"
                .DisplayIndex = x : .Visible = False : .HeaderText = "fechaf4"
            End With
            x += +1
            Dim col_diaf1 As New DataGridViewTextBoxColumn
            With col_diaf1
                .Name = "diaf1" : .DataPropertyName = "diaf1"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf1"
            End With
            x += +1
            Dim col_diaf2 As New DataGridViewTextBoxColumn
            With col_diaf2
                .Name = "diaf2" : .DataPropertyName = "diaf2"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf2"
            End With
            x += +1
            Dim col_diaf3 As New DataGridViewTextBoxColumn
            With col_diaf3
                .Name = "diaf3" : .DataPropertyName = "diaf3"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf3"
            End With
            x += +1
            Dim col_diaf4 As New DataGridViewTextBoxColumn
            With col_diaf4
                .Name = "diaf4" : .DataPropertyName = "diaf4"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf4"
            End With
            x += +1
            Dim col_diaf5 As New DataGridViewTextBoxColumn
            With col_diaf5
                .Name = "diaf5" : .DataPropertyName = "diaf5"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf5"
            End With
            x += +1
            Dim col_diaf6 As New DataGridViewTextBoxColumn
            With col_diaf6
                .Name = "diaf6" : .DataPropertyName = "diaf6"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf6"
            End With
            x += +1
            Dim col_diaf7 As New DataGridViewTextBoxColumn
            With col_diaf7
                .Name = "diaf7" : .DataPropertyName = "diaf7"
                .DisplayIndex = x : .Visible = False : .HeaderText = "diaf7"
            End With
            x += +1
            Dim col_horario_facturacion_ini As New DataGridViewTextBoxColumn
            With col_horario_facturacion_ini
                .Name = "horario_facturacion_ini" : .DataPropertyName = "horario_facturacion_ini"
                .DisplayIndex = x : .Visible = False : .HeaderText = "horario_facturacion_ini"
            End With
            x += +1
            Dim col_horario_facturacion_fin As New DataGridViewTextBoxColumn
            With col_horario_facturacion_fin
                .Name = "horario_facturacion_fin" : .DataPropertyName = "horario_facturacion_fin"
                .DisplayIndex = x : .Visible = False : .HeaderText = "horario_facturacion_fin"
            End With

            .Columns.AddRange(col_solicitud, col_fecha, col_cliente, col_monto, col_monto_preaprobacion, col_monto_aprobacion, col_estado, _
                              col_preaprobacion, col_usuario_preaprobacion, col_aprobacion, col_usuario_aprobacion, col_rechazo_pre_aprobacion, col_usuario_rechazo_preaprobacion, _
                              col_rechazo_aprobacion, col_usuario_rechazo_aprobacion, col_anulacion, col_usuario_anulacion, col_id, col_idestado, col_comercial, col_pagos, col_condicion, _
                              col_fecha1, col_fecha2, col_fecha3, col_fecha4, _
                              col_dia1, col_dia2, col_dia3, col_dia4, col_dia5, col_dia6, col_dia7, _
                              col_horario_pago_ini, col_horario_pago_fin, col_producto, col_tipo_facturacion, _
                              col_idsolicitud_producto, col_idsolicitud_tipo_facturacion, col_contado, col_contacto_facturacion, col_orden_compra, col_liquidacion_documento, col_forma_facturacion, col_concepto_credito, _
                              col_forma_pago, col_fecha_corte, col_periodo_facturacion, _
                              col_fechaf1, col_fechaf2, col_fechaf3, col_fechaf4, _
                              col_diaf1, col_diaf2, col_diaf3, col_diaf4, col_diaf5, col_diaf6, col_diaf7, _
                              col_horario_facturacion_ini, col_horario_facturacion_fin)
        End With
    End Sub
    Private Sub ConfigurarDGVClienteCredito()
        With dgvClienteCredito
            Cls_Utilitarios.FormatDataGridView(dgvClienteCredito)
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
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
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
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            x += +1
            .Columns.AddRange(col_id, col_codigo, col_cliente)
        End With
    End Sub
    Private Sub ConfigurarDGVClienteCreditoDetalle()
        With dgvClienteCreditoDetalle
            Cls_Utilitarios.FormatDataGridView(dgvClienteCreditoDetalle)
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
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .HeaderText = "Fecha Inicio" : .Visible = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_linea As New DataGridViewTextBoxColumn
            With col_linea
                .Name = "linea" : .DataPropertyName = "linea"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Línea de Crédito"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight : .DefaultCellStyle.Format = "#,###,###,###0.00"
            End With
            x += +1
            Dim col_sobregiro As New DataGridViewTextBoxColumn
            With col_sobregiro
                .Name = "sobregiro" : .DataPropertyName = "sobregiro"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Sobregiro"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight : .DefaultCellStyle.Format = "#,###,###,###0.00"
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total Asignado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight : .DefaultCellStyle.Format = "#,###,###,###0.00"
            End With
            x += +1
            Dim col_saldo As New DataGridViewTextBoxColumn
            With col_saldo
                .Name = "saldo" : .DataPropertyName = "saldo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Saldo"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight : .DefaultCellStyle.Format = "#,###,###,###0.00"
            End With
            .Columns.AddRange(col_fecha, col_linea, col_sobregiro, col_total, col_saldo)
        End With
    End Sub
#End Region
#Region "Cliente"
    Sub ListarLineaCredito(cliente As Integer, dgv As DataGridView)
        Dim obj As New Cls_LineaCredito_LN
        Dim dt As DataTable = obj.ListarLineaCredito(cliente, 1)
        dgv.DataSource = dt
    End Sub
    Sub ListarLineaCredito(cliente As Integer, dgv As DataGridView, estado As Integer)
        Dim obj As New Cls_LineaCredito_LN
        Dim dt As DataTable = obj.ListarLineaCredito(cliente, estado)
        dgv.DataSource = dt
        If dgv.Rows.Count = 0 Then
            Me.btnActivarLineaCredito.Enabled = False
            Me.btnActualizarLineaCredito.Enabled = False
            Me.btnDesactivarLineaCredito.Enabled = False
            Me.btnCancelarLineaCredito.Enabled = False
            'Me.lblEstadoCredito.Text = ""
        End If
        Dim intIDEstado As Integer, strEstado As String, intCtaCte As Integer
        EstadoActualLineaCredito(cliente, intIDEstado, strEstado, intCtaCte)
        Me.lblEstadoCredito.Text = strEstado
        Me.lblEstadoCredito.Tag = intCtaCte

        If intIDEstado = 2 Then 'no existe cancelado
            Me.btnActivarLineaCredito.Enabled = False
            Me.btnActualizarLineaCredito.Enabled = False
            Me.btnDesactivarLineaCredito.Enabled = False
            Me.btnCancelarLineaCredito.Enabled = False
        ElseIf intIDEstado = 1 Then 'activo
            Me.btnActivarLineaCredito.Enabled = False
            Me.btnActualizarLineaCredito.Enabled = True
            Me.btnDesactivarLineaCredito.Enabled = True
            Me.btnCancelarLineaCredito.Enabled = True
        ElseIf intIDEstado = 0 Then 'desactivado
            Me.btnActivarLineaCredito.Enabled = True
            Me.btnActualizarLineaCredito.Enabled = False
            Me.btnDesactivarLineaCredito.Enabled = False
            Me.btnCancelarLineaCredito.Enabled = True
        Else
            Me.btnActivarLineaCredito.Enabled = False
            Me.btnActualizarLineaCredito.Enabled = False
            Me.btnDesactivarLineaCredito.Enabled = False
            Me.btnCancelarLineaCredito.Enabled = False
        End If
    End Sub
    Private Sub dgvClienteCredito_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClienteCredito.RowEnter
        'If blnInicioProducto = False Then Return
        Dim intCliente As Integer = dgvClienteCredito(0, e.RowIndex).Value
        ListarLineaCredito(intCliente, Me.dgvClienteCreditoDetalle)
    End Sub
    Private Sub dgvClienteCredito_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvClienteCredito.DoubleClick
        With dgvClienteCredito
            If .Rows.Count > 0 Then
                Me.tabLineaCredito.SelectedTab = Me.tabLineaCredito.TabPages("tabSolicitudCredito")
            End If
        End With
    End Sub
#End Region
#Region "Solicitud"
    Private Sub btnCancelarCredito_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelarCredito.Click
        LimpiarSolicitudCredito()
        ActivaDesactivaCredito(0, dgvSolicitudCredito.Rows.Count)

        If Me.dgvSolicitudCredito.Rows.Count > 0 Then
            MostrarSolicitudCredito(dgvSolicitudCredito.CurrentCell.RowIndex)
            Me.btnModificarCredito.Enabled = dgvSolicitudCredito.CurrentRow.Cells("idestado").Value = 1
            Me.btnAnularCredito.Enabled = dgvSolicitudCredito.CurrentRow.Cells("idestado").Value = 1
        End If
        If intOperacion = Operacion.Nuevo Then
            btnNuevoCredito.Focus()
        Else
            btnModificarCredito.Focus()
        End If
    End Sub
    Private Sub txtMontoSolicitadoCredito_Enter(sender As Object, e As System.EventArgs) Handles txtMontoSolicitadoCredito.Enter
        If Val(txtMontoSolicitadoCredito.Text) > 0 Then
            Me.txtMontoSolicitadoCredito.Text = Replace(Me.txtMontoSolicitadoCredito.Text, ",", "")
        Else
            Me.txtMontoSolicitadoCredito.Text = ""
        End If
    End Sub
    Private Sub txtMontoSolicitadoCredito_GotFocus(sender As Object, e As System.EventArgs) Handles txtMontoSolicitadoCredito.GotFocus
        Me.txtMontoSolicitadoCredito.SelectAll()
    End Sub
    Private Sub txtMontoSolicitadoCredito_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoSolicitadoCredito.KeyPress
        If Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtMontoSolicitadoCredito_LostFocus(sender As Object, e As System.EventArgs) Handles txtMontoSolicitadoCredito.LostFocus
        If Val(Me.txtMontoSolicitadoCredito.Text) > 0 Then
            Dim dblMonto As Double
            dblMonto = CDbl(Me.txtMontoSolicitadoCredito.Text)
            Me.txtMontoSolicitadoCredito.Text = Format(dblMonto, "#,###,###0.00")
        Else
            Me.txtMontoSolicitadoCredito.Text = ""
        End If
    End Sub
    Private Sub btnGrabarCredito_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabarCredito.Click
        Try
            If intOperacion = Operacion.Nuevo Then
                Dim objLN As New Cls_LineaCredito_LN
                Dim objEN As New Cls_LineaCredito_EN
                objEN.Cliente = Me.dgvClienteCredito.CurrentRow.Cells("id").Value
                objEN.Estado = 1
                If objLN.ExisteSolicitud(objEN) Then
                    MessageBox.Show("El Cliente " & Me.lblClienteCredito.Text & Chr(13) & " ya cuenta con una Solicitud Activa", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.btnCancelarCredito.Focus()
                    Return
                End If
            End If

            If Me.lblDireccionCredito.Text.Trim.Length = 0 Then
                MessageBox.Show("Asigne una Dirección Legal al Cliente", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnCancelarCredito.Focus()
                Return
            End If

            If Val(Me.txtMontoSolicitadoCredito.Text) = 0 Then
                MessageBox.Show("Ingrese Monto a Solicitar", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtMontoSolicitadoCredito.Focus()
                Return
            End If

            If Me.cboConceptoCredito.SelectedIndex = 0 Then
                MessageBox.Show("Seleccione Concepto del Crédito", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboConceptoCredito.DroppedDown = True
                Me.cboConceptoCredito.Focus()
                Return
            End If

            If Me.cboComercialCredito.SelectedValue = 0 Then
                MessageBox.Show("Seleccione Contacto Comercial", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboComercialCredito.Focus()
                Return
            End If

            If Me.cboPagoCredito.SelectedValue = 0 Then
                MessageBox.Show("Seleccione Contacto de Pagos", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboPagoCredito.Focus()
                Return
            End If

            If Me.cboCondicionCredito.SelectedValue = 0 Then
                MessageBox.Show("Seleccione Condición del Crédito", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboCondicionCredito.Focus()
                Return
            End If

            If Me.rbtDiaSemana.Checked Then
                Dim j As Integer = 0
                For Each i As Integer In Me.lstDia.CheckedIndices
                    j = 1
                Next
                If j = 0 Then
                    MessageBox.Show("Seleccione al menos un día", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.lstDia.Focus()
                    Me.lstDia.SetSelected(0, True)
                    Return
                End If
            End If

            If Not (Me.dtpHora1.Checked) Then
                MessageBox.Show("Ingrese hora inicial de Cobranza", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dtpHora1.Focus()
                Return
            End If

            If Not (Me.dtpHora2.Checked) Then
                MessageBox.Show("Ingrese hora final de Cobranza", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dtpHora2.Focus()
                Return
            End If

            'hlamas 08-04-2016
            If Me.cboFormaPago.SelectedValue = 0 Then
                MessageBox.Show("Seleccione Forma de Pago", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboFormaPago.DroppedDown = True
                Me.cboFormaPago.Focus()
                Return
            End If
            If Me.rbtDiaSemanaFacturacion.Checked Then
                Dim j As Integer = 0
                For Each i As Integer In Me.lstDiaFacturacion.CheckedIndices
                    j = 1
                Next
                If j = 0 Then
                    MessageBox.Show("Seleccione al menos un día", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.lstDiaFacturacion.Focus()
                    Me.lstDiaFacturacion.SetSelected(0, True)
                    Return
                End If
            End If

            If Not (Me.dtpHora1Facturacion.Checked) Then
                MessageBox.Show("Ingrese hora inicial de Facturación", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dtpHora1Facturacion.Focus()
                Return
            End If

            If Not (Me.dtpHora2Facturacion.Checked) Then
                MessageBox.Show("Ingrese hora final de Facturación", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dtpHora2Facturacion.Focus()
                Return
            End If

            '--------------------------------------------------------------------

            If Me.grbSolicitudProductoCredito.Enabled Then 'solicitud de producto
                If Me.cboProductoCredito.SelectedValue = 0 Then
                    MessageBox.Show("Seleccione Producto", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cboProductoCredito.Focus()
                    Return
                End If
            End If

            If Me.grbSolicitudFacturacionCredito.Enabled Then 'solicitud de tipo de facturacion
                If Me.cboTipoFacturacionCredito.SelectedValue = 0 Then
                    MessageBox.Show("Seleccione Tipo de Facturación", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cboTipoFacturacionCredito.Focus()
                    Return
                End If
                If Me.cboContactoFacturacionCredito.SelectedValue = 0 Then
                    MessageBox.Show("Seleccione Contacto", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cboContactoFacturacionCredito.Focus()
                    Return
                End If
                If Me.cboTipoFacturacionCredito.SelectedValue = 3 Then
                    If Me.dgvFacturacion3Credito.Rows.Count = 0 Then
                        MessageBox.Show("Ingrese Documentos necesarios para Facturar", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.btnAgregarCargoCredito.Focus()
                        Return
                    End If
                Else
                    If Me.dgvFacturacion3Credito.Rows.Count = 0 Then
                        MessageBox.Show("Ingrese Documentos necesarios para Facturar", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.btnAgregarCargoCredito.Focus()
                        Return
                    End If
                End If
            End If

            Dim intSolicitud As Integer = IIf(Me.grbSolicitudProductoCredito.Enabled And Me.grbSolicitudFacturacionCredito.Enabled, 1, 0)

            'graba solicitud linea de credito
            Cursor = Cursors.WaitCursor
            GrabarCredito(intSolicitud)
            ListarSolicitudCredito()
            ActivaDesactivaCredito(0, dgvSolicitudCredito.Rows.Count)
            If Me.dgvSolicitudCredito.Rows.Count > 0 Then
                MostrarSolicitudCredito(dgvSolicitudCredito.CurrentCell.RowIndex)
                Me.btnModificarCredito.Enabled = dgvSolicitudCredito.CurrentRow.Cells("idestado").Value = 1
                Me.btnAnularCredito.Enabled = dgvSolicitudCredito.CurrentRow.Cells("idestado").Value = 1
            End If
            If intOperacion = Operacion.Nuevo Then
                btnNuevoCredito.Focus()
            Else
                btnModificarCredito.Focus()
            End If
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub rbtDiaSemana_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtDiaSemana.CheckedChanged
        Me.dtpDia1.Enabled = False
        Me.chkDia1.Enabled = False
        Me.dtpDia2.Enabled = False
        Me.chkDia2.Enabled = False
        Me.dtpDia3.Enabled = False
        Me.chkDia3.Enabled = False
        Me.dtpDia4.Enabled = False
        Me.chkDia1.Checked = False
        Me.chkDia2.Checked = False
        Me.chkDia3.Checked = False
        Me.lstDia.Enabled = True
    End Sub
    Private Sub rbtDiaMes_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtDiaMes.CheckedChanged
        Me.dtpDia1.Enabled = True
        Me.chkDia1.Enabled = True
        Me.lstDia.Enabled = False
        LimpiarDias(lstDia)
    End Sub
    Private Sub btnAnularCredito_Click(sender As System.Object, e As System.EventArgs) Handles btnAnularCredito.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está Seguro de Anular la Solicitud Nº " & dgvSolicitudCredito.CurrentRow.Cells("numero_solicitud").Value & "?", "Anular Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = vbYes Then
            AnularCredito()
            LimpiarSolicitudCredito()
            ListarSolicitudCredito()
            ActivaDesactivaCredito(0, dgvSolicitudCredito.Rows.Count)
        End If
    End Sub
    Private Sub chkDia1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDia1.CheckedChanged
        Me.dtpDia2.Enabled = Me.chkDia1.Checked
        Me.chkDia2.Enabled = Me.chkDia1.Checked
        If Not Me.chkDia1.Checked Then
            Me.dtpDia3.Enabled = Me.chkDia1.Checked
            Me.chkDia3.Enabled = Me.chkDia1.Checked
            Me.dtpDia4.Enabled = Me.chkDia1.Checked
        End If
        Me.chkDia2.Checked = False
        Me.chkDia3.Checked = False
    End Sub
    Private Sub chkDia2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDia2.CheckedChanged
        Me.dtpDia3.Enabled = Me.chkDia2.Checked
        Me.chkDia3.Enabled = Me.chkDia2.Checked
        If Not Me.chkDia2.Checked Then
            Me.dtpDia3.Enabled = Me.chkDia2.Checked
            Me.chkDia3.Enabled = Me.chkDia2.Checked
            Me.chkDia3.Checked = Me.chkDia2.Checked
            Me.dtpDia4.Enabled = Me.chkDia2.Checked
        End If
        Me.chkDia3.Checked = False
    End Sub
    Private Sub chkDia3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDia3.CheckedChanged
        Me.dtpDia4.Enabled = Me.chkDia3.Checked
    End Sub
    Private Sub cboEstadoCredito_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstadoCredito.SelectedIndexChanged
        Me.LimpiarSolicitudCredito()
        ListarSolicitudCredito()
        'Me.ActivaDesactivaCredito(0, Me.dgvSolicitudCredito.Rows.Count)
        If Me.dgvSolicitudCredito.Rows.Count > 0 AndAlso btnNuevoCredito.Enabled Then
            Me.btnModificarCredito.Enabled = dgvSolicitudCredito.CurrentRow.Cells("idestado").Value = 1
            Me.btnAnularCredito.Enabled = dgvSolicitudCredito.CurrentRow.Cells("idestado").Value = 1
        ElseIf Me.dgvSolicitudCredito.Rows.Count = 0 Then
            Me.ActivaDesactivaCredito(-1, 0)
        End If
    End Sub
    Private Sub dgvSolicitudCredito_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvSolicitudCredito.DoubleClick
        If dgvSolicitudCredito.Rows.Count > 0 Then
            If Me.btnGrabarCredito.Enabled = False And dgvSolicitudCredito.CurrentRow.Cells("idestado").Value = 1 Then
                btnModificarCredito_Click(Nothing, Nothing)
            End If
        End If
    End Sub
    Private Sub btnModificarCredito_Click(sender As System.Object, e As System.EventArgs) Handles btnModificarCredito.Click
        intOperacion = Operacion.Modificar
        ActivaDesactivaCredito(1, dgvSolicitudCredito.Rows.Count)
        Me.grbSolicitudProductoCredito.Enabled = True
        Me.grbSolicitudFacturacionCredito.Enabled = True
        Me.txtMontoSolicitadoCredito.Focus()
    End Sub
    Private Sub dgvSolicitudCredito_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSolicitudCredito.RowEnter
        If Me.btnNuevoCredito.Enabled Then
            MostrarSolicitudCredito(e.RowIndex)
            'Dim intCliente As Integer = Me.dgvClienteCredito.CurrentRow.Cells(0).Value
            Dim intCliente As Integer = Me.dgvClienteCredito.CurrentRow.Cells("id").Value
            ListarClienteCargo(intCliente, dgvFacturacion3Credito)
        End If
        If btnNuevoCredito.Enabled Then
            Me.btnModificarCredito.Enabled = dgvSolicitudCredito.Rows(e.RowIndex).Cells("idestado").Value = 1
            Me.btnAnularCredito.Enabled = dgvSolicitudCredito.Rows(e.RowIndex).Cells("idestado").Value = 1
        End If
    End Sub
    Sub MostrarSolicitudCredito(row As Integer)
        With dgvSolicitudCredito
            Me.lblNumeroSolicitudCredito.Text = .Rows(row).Cells("numero_solicitud").Value
            Me.lblFechaCredito.Text = .Rows(row).Cells("fecha_solicitud").Value
            Me.lblClienteCredito.Text = .Rows(row).Cells("cliente").Value

            Me.txtMontoSolicitadoCredito.Text = Format(.Rows(row).Cells("monto_solicitado").Value, "#,###,###,###0.00")

            Me.cboComercialCredito.SelectedValue = .Rows(row).Cells("comercial").Value
            Me.cboPagoCredito.SelectedValue = .Rows(row).Cells("pagos").Value
            Me.cboCondicionCredito.SelectedValue = .Rows(row).Cells("condicion").Value
            Me.cboConceptoCredito.SelectedValue = .Rows(row).Cells("concepto").Value

            If .Rows(row).Cells("fecha1").Value > 0 Then
                Me.rbtDiaMes.Checked = True
            Else
                Me.rbtDiaSemana.Checked = True
            End If
            If .Rows(row).Cells("fecha1").Value > 0 Then
                Me.dtpDia1.Value = dgvSolicitudCredito.Rows(row).Cells("fecha1").Value & "/01/1900"
                'Me.dtpDia1.Value = "01/01/1900 00:00:00 a.m."
                Me.dtpDia1.Enabled = True
                Me.chkDia1.Enabled = True
            Else
                Me.dtpDia1.Enabled = False
                Me.chkDia1.Checked = False
            End If
            If .Rows(row).Cells("fecha2").Value > 0 Then
                Me.dtpDia2.Value = .Rows(row).Cells("fecha2").Value & "/01/1900"
                Me.dtpDia2.Enabled = True
                Me.chkDia2.Enabled = True
                Me.chkDia1.Checked = True
            Else
                Me.dtpDia2.Enabled = False
                Me.chkDia2.Checked = False
            End If
            If .Rows(row).Cells("fecha3").Value > 0 Then
                Me.dtpDia3.Value = .Rows(row).Cells("fecha3").Value & "/01/1900"
                Me.dtpDia3.Enabled = True
                Me.chkDia3.Enabled = True
                Me.chkDia2.Checked = True
            Else
                Me.dtpDia3.Enabled = False
                Me.chkDia3.Checked = False
            End If
            If .Rows(row).Cells("fecha4").Value > 0 Then
                Me.dtpDia4.Value = .Rows(row).Cells("fecha4").Value & "/01/1900"
                Me.dtpDia4.Enabled = True
                Me.chkDia3.Checked = True
            Else
                Me.dtpDia4.Enabled = False
            End If

            If IsDBNull(.Rows(row).Cells("horario_pago_ini").Value) Or IsDBNull(.Rows(row).Cells("horario_pago_fin").Value) Then
                Me.dtpHora1.Checked = False
                Me.dtpHora2.Checked = False
            Else
                Me.dtpHora1.Text = dtpHora1.Value.ToShortDateString & " " & Format(CType(dgvSolicitudCredito.Rows(row).Cells("horario_pago_ini").Value, Date), "HH:mm tt").ToString
                Me.dtpHora2.Text = Format(CType(.Rows(row).Cells("horario_pago_fin").Value, Date), "HH:mm tt").ToString
                Me.dtpHora1.Checked = True
                Me.dtpHora2.Checked = True
            End If

            Me.lstDia.SetItemChecked(0, .Rows(row).Cells("dia1").Value)
            Me.lstDia.SetItemChecked(1, .Rows(row).Cells("dia2").Value)
            Me.lstDia.SetItemChecked(2, .Rows(row).Cells("dia3").Value)
            Me.lstDia.SetItemChecked(3, .Rows(row).Cells("dia4").Value)
            Me.lstDia.SetItemChecked(4, .Rows(row).Cells("dia5").Value)
            Me.lstDia.SetItemChecked(5, .Rows(row).Cells("dia6").Value)
            Me.lstDia.SetItemChecked(6, .Rows(row).Cells("dia7").Value)

            'hlamas 08-04-2016
            Me.cboFormaPago.SelectedValue = .Rows(row).Cells("forma_pago").Value
            If Not IsDBNull(.Rows(row).Cells("fecha_corte").Value) Then
                Me.dtpFechaCorte.Value = .Rows(row).Cells("fecha_corte").Value
            End If

            If dgvSolicitudCredito.Rows(row).Cells("fechaf1").Value > 0 Then
                Me.rbtDiaMesFacturacion.Checked = True
            Else
                Me.rbtDiaSemanaFacturacion.Checked = True
            End If
            If dgvSolicitudCredito.Rows(row).Cells("fechaf1").Value > 0 Then
                Me.dtpDia1Facturacion.Value = .Rows(row).Cells("fechaf1").Value & "/01/1900"
                Me.dtpDia1Facturacion.Enabled = True
                Me.chkDia1Facturacion.Enabled = True
            Else
                Me.dtpDia1Facturacion.Enabled = False
                Me.chkDia1Facturacion.Checked = False
            End If
            If dgvSolicitudCredito.Rows(row).Cells("fechaf2").Value > 0 Then
                Me.dtpDia2Facturacion.Value = .Rows(row).Cells("fechaf2").Value & "/01/1900"
                Me.dtpDia2Facturacion.Enabled = True
                Me.chkDia2Facturacion.Enabled = True
                Me.chkDia1Facturacion.Checked = True
            Else
                Me.dtpDia2Facturacion.Enabled = False
                Me.chkDia2Facturacion.Checked = False
            End If
            If dgvSolicitudCredito.Rows(row).Cells("fechaf3").Value > 0 Then
                Me.dtpDia3Facturacion.Value = .Rows(row).Cells("fechaf3").Value & "/01/1900"
                Me.dtpDia3Facturacion.Enabled = True
                Me.chkDia3Facturacion.Enabled = True
                Me.chkDia2Facturacion.Checked = True
            Else
                Me.dtpDia3Facturacion.Enabled = False
                Me.chkDia3Facturacion.Checked = False
            End If
            If dgvSolicitudCredito.Rows(row).Cells("fechaf4").Value > 0 Then
                Me.dtpDia4Facturacion.Value = .Rows(row).Cells("fechaf4").Value & "/01/1900"
                Me.dtpDia4Facturacion.Enabled = True
                Me.chkDia3Facturacion.Checked = True
            Else
                Me.dtpDia4Facturacion.Enabled = False
            End If

            If IsDBNull(.Rows(row).Cells("horario_facturacion_ini").Value) Or IsDBNull(.Rows(row).Cells("horario_facturacion_fin").Value) Then
                Me.dtpHora1Facturacion.Checked = False
                Me.dtpHora2Facturacion.Checked = False
            Else
                Me.dtpHora1Facturacion.Text = Format(CType(.Rows(row).Cells("horario_facturacion_ini").Value, Date), "HH:mm tt").ToString
                Me.dtpHora2Facturacion.Text = Format(CType(.Rows(row).Cells("horario_facturacion_fin").Value, Date), "HH:mm tt").ToString
                Me.dtpHora1Facturacion.Checked = True
                Me.dtpHora2Facturacion.Checked = True
            End If

            Me.lstDiaFacturacion.SetItemChecked(0, .Rows(row).Cells("diaf1").Value)
            Me.lstDiaFacturacion.SetItemChecked(1, .Rows(row).Cells("diaf2").Value)
            Me.lstDiaFacturacion.SetItemChecked(2, .Rows(row).Cells("diaf3").Value)
            Me.lstDiaFacturacion.SetItemChecked(3, .Rows(row).Cells("diaf4").Value)
            Me.lstDiaFacturacion.SetItemChecked(4, .Rows(row).Cells("diaf5").Value)
            Me.lstDiaFacturacion.SetItemChecked(5, .Rows(row).Cells("diaf6").Value)
            Me.lstDiaFacturacion.SetItemChecked(6, .Rows(row).Cells("diaf7").Value)

            '-------------------------------------------------------------------

            If dgvSolicitudCredito.Rows(row).Cells("producto").Value > 0 Then
                Me.LlenarComboCredito()
                Me.cboProductoCredito.SelectedValue = .Rows(row).Cells("producto").Value
                Me.cboTipoFacturacionCredito.SelectedValue = .Rows(row).Cells("tipo_facturacion").Value

                Me.chkContadoCredito.Checked = IIf(.Rows(row).Cells("contado").Value = 1, True, False)
                Me.cboContactoFacturacionCredito.SelectedValue = .Rows(row).Cells("contacto_facturacion").Value
                Me.chkOrdenCompraCredito.Checked = IIf(.Rows(row).Cells("orden_compra").Value = 1, True, False)
                Me.chkLiquidacionDocumentoCredito.Checked = IIf(.Rows(row).Cells("liquidacion_documento").Value = 1, True, False)
                'Me.cboFormaFacturacionCredito.SelectedValue = .Rows(row).Cells("forma_facturacion").Value

                Dim intCliente As Integer = Me.dgvClienteCredito.CurrentRow.Cells("id").Value
                ListarClienteCargo(intCliente, dgvFacturacion3Credito)
            End If
        End With
    End Sub
    Sub AnularCredito()
        Try
            Dim objEN As New Cls_LineaCredito_EN
            Dim objLN As New Cls_LineaCredito_LN

            objEN.ID = dgvSolicitudCredito.CurrentRow.Cells("id").Value
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP

            objLN.AnularSolicitud(objEN)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub GrabarCredito(solicitud As Integer)
        Try
            Dim objEN As New Cls_LineaCredito_EN
            Dim objLN As New Cls_LineaCredito_LN

            If intOperacion = Operacion.Nuevo Then
                objEN.ID = 0
            Else
                objEN.ID = dgvSolicitudCredito.CurrentRow.Cells("id").Value
            End If
            objEN.NumeroSolicitud = Me.lblNumeroSolicitudCredito.Text
            objEN.Fecha = Me.lblFechaCredito.Text
            objEN.Cliente = Me.dgvClienteCredito.CurrentRow.Cells(0).Value
            objEN.Direccion = Me.lblDireccionCredito.Text.Trim

            objEN.ContactoComercial = Me.cboComercialCredito.SelectedValue
            objEN.ContactoPagos = Me.cboPagoCredito.SelectedValue
            objEN.ConceptoCredito = Me.cboConceptoCredito.SelectedValue

            objEN.MontoSolicitado = Double.Parse(Me.txtMontoSolicitadoCredito.Text)
            objEN.CondicionCobranza = Me.cboCondicionCredito.SelectedValue
            'objEN.DiaPago = "LUNES"
            If Me.rbtDiaMes.Checked Then
                If Me.dtpDia1.Enabled Then
                    objEN.Fecha1 = Me.dtpDia1.Value.Day
                Else
                    objEN.Fecha1 = 0
                End If
                If Me.dtpDia2.Enabled Then
                    objEN.Fecha2 = Me.dtpDia2.Value.Day
                Else
                    objEN.Fecha2 = 0
                End If
                If Me.dtpDia3.Enabled Then
                    objEN.Fecha3 = Me.dtpDia3.Value.Day
                Else
                    objEN.Fecha3 = 0
                End If
                If Me.dtpDia4.Enabled Then
                    objEN.Fecha4 = Me.dtpDia4.Value.Day
                Else
                    objEN.Fecha4 = 0
                End If
            Else
                objEN.Fecha1 = 0 : objEN.Fecha2 = 0 : objEN.Fecha3 = 0 : objEN.Fecha4 = 0
                For Each i As Integer In Me.lstDia.CheckedIndices
                    Select Case i
                        Case 0
                            objEN.Dia1 = 1
                        Case 1
                            objEN.Dia2 = 1
                        Case 2
                            objEN.Dia3 = 1
                        Case 3
                            objEN.Dia4 = 1
                        Case 4
                            objEN.Dia5 = 1
                        Case 5
                            objEN.Dia6 = 1
                        Case 6
                            objEN.Dia7 = 1
                    End Select
                Next
            End If
            If Me.dtpHora1.Checked Then
                objEN.HorarioPagoInicio = Me.dtpHora1.Text
            End If
            If Me.dtpHora2.Checked Then
                objEN.HorarioPagoFin = Me.dtpHora2.Text
            End If
            'objEN.TipoPago=3

            'hlamas 08-04-2016
            objEN.FormaPago = Me.cboFormaPago.SelectedValue
            objEN.FechaCorte = Me.dtpFechaCorte.Value.ToShortDateString
            objEN.PeriodoFacturacion = IIf(Me.rbtDiaSemanaFacturacion.Checked, 1, 2)
            If Me.rbtDiaMesFacturacion.Checked Then
                If Me.dtpDia1Facturacion.Enabled Then
                    objEN.Fecha1Facturacion = Me.dtpDia1Facturacion.Value.Day
                Else
                    objEN.Fecha1Facturacion = 0
                End If
                If Me.dtpDia2Facturacion.Enabled Then
                    objEN.Fecha2Facturacion = Me.dtpDia2Facturacion.Value.Day
                Else
                    objEN.Fecha2Facturacion = 0
                End If
                If Me.dtpDia3Facturacion.Enabled Then
                    objEN.Fecha3Facturacion = Me.dtpDia3Facturacion.Value.Day
                Else
                    objEN.Fecha3Facturacion = 0
                End If
                If Me.dtpDia4Facturacion.Enabled Then
                    objEN.Fecha4Facturacion = Me.dtpDia4Facturacion.Value.Day
                Else
                    objEN.Fecha4Facturacion = 0
                End If
            Else
                objEN.Fecha1Facturacion = 0 : objEN.Fecha2Facturacion = 0 : objEN.Fecha3Facturacion = 0 : objEN.Fecha4Facturacion = 0
                For Each i As Integer In Me.lstDiaFacturacion.CheckedIndices
                    Select Case i
                        Case 0
                            objEN.Dia1Facturacion = 1
                        Case 1
                            objEN.Dia2Facturacion = 1
                        Case 2
                            objEN.Dia3Facturacion = 1
                        Case 3
                            objEN.Dia4Facturacion = 1
                        Case 4
                            objEN.Dia5Facturacion = 1
                        Case 5
                            objEN.Dia6Facturacion = 1
                        Case 6
                            objEN.Dia7Facturacion = 1
                    End Select
                Next
            End If
            If Me.dtpHora1Facturacion.Checked Then
                objEN.HorarioFacturacionInicio = Me.dtpHora1Facturacion.Text
            End If
            If Me.dtpHora2Facturacion.Checked Then
                objEN.HorarioFacturacionFin = Me.dtpHora2Facturacion.Text
            End If
            '-----------------------------------------------

            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP

            If Me.grbSolicitudProductoCredito.Enabled Then
                objEN.Producto = Me.cboProductoCredito.SelectedValue
                If intOperacion = Operacion.Modificar Then
                    objEN.SolicitudProducto = Me.dgvSolicitudCredito.CurrentRow.Cells("idsolicitud_producto").Value
                Else
                    objEN.SolicitudProducto = 0
                End If
                objEN.Contado = IIf(Me.chkContadoCredito.Checked, 1, 0)
            End If
            If Me.grbSolicitudFacturacionCredito.Enabled Then
                objEN.TipoFacturacion = Me.cboTipoFacturacionCredito.SelectedValue
                If intOperacion = Operacion.Modificar Then
                    objEN.SolicitudTipoFacturacion = Me.dgvSolicitudCredito.CurrentRow.Cells("idsolicitud_tipo_facturacion").Value
                Else
                    objEN.SolicitudTipoFacturacion = 0
                End If
                objEN.Contacto = Me.cboContactoFacturacionCredito.SelectedValue
                objEN.OrdenCompra = IIf(Me.chkOrdenCompraCredito.Checked, 1, 0)
                objEN.LiquidacionDocumento = IIf(Me.chkLiquidacionDocumentoCredito.Checked, 1, 0)
                'objEN.FormaFacturacion = Me.cboFormaFacturacionCredito.SelectedValue
            End If

            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP
            objLN.GrabarSolicitud(objEN, solicitud)

            'Actualizar cargos del cliente
            If grbSolicitudFacturacionCredito.Enabled Then
                Dim objLN3 As New Cls_ClienteTipoFacturacion_LN
                With Me.dgvFacturacion3Credito
                    For Each row As DataGridViewRow In Me.dgvFacturacion3Credito.Rows
                        Dim intID As Integer = IIf(IsDBNull(row.Cells("id").Value), 0, row.Cells("id").Value)
                        Dim intCliente As Integer = Me.dgvClienteCredito.CurrentRow.Cells(0).Value
                        Dim intSubcuenta As Integer = row.Cells("idsubcuenta").Value
                        Dim intCargo As Integer = row.Cells("idcargo").Value
                        Dim intEstado As Integer = row.Cells("estado").Value
                        Dim intUsuario As Integer = dtoUSUARIOS.IdLogin
                        Dim strIP As String = dtoUSUARIOS.IP
                        objLN3.GrabarCargo(intID, intCliente, intSubcuenta, intCargo, intEstado, intUsuario, strIP)
                    Next
                End With
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Sub ListarDireccionCredito(cliente As Integer, tipo As Integer)
        Try
            Dim obj As New UtilData_LN
            Dim dt As DataTable = obj.ListarDireccion(cliente, tipo)
            If dt.Rows.Count > 0 Then
                Me.lblDireccionCredito.Text = dt.Rows(0).Item("direccion").ToString
            Else
                Me.lblDireccionCredito.Text = ""
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Sub ListarSolicitudCredito()
        Try
            Dim obj As New Cls_LineaCredito_LN
            Dim objEN As New Cls_LineaCredito_EN

            Me.LimpiarSolicitudCredito()
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.Estado = Me.cboEstadoCredito.SelectedIndex
            objEN.Cliente = dgvClienteCredito.CurrentRow.Cells(0).Value
            dgvSolicitudCredito.DataSource = obj.ListarSolicitud(objEN.Usuario, objEN.Cliente, objEN.Estado)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub LlenarComboCredito()
        Dim obj As New UtilData_LN
        With cboProductoCredito
            .DataSource = Nothing
            .DataSource = obj.ListarProducto
            .DisplayMember = "procesos"
            .ValueMember = "idprocesos"
        End With

        With cboTipoFacturacionCredito
            .DataSource = Nothing
            .DataSource = obj.ListarTipoFacturacion
            .DisplayMember = "tipo"
            .ValueMember = "id"
        End With
        'cboEstadoCredito.SelectedIndex = 1
    End Sub
    Private Sub btnNuevoCredito_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevoCredito.Click
        LimpiarSolicitudCredito()
        'If Me.cboComercialCredito.Items.Count = 2 Then
        'Me.cboComercialCredito.SelectedIndex = 1
        'End If
        'If cboPagoCredito.Items.Count = 2 Then
        'Me.cboPagoCredito.SelectedIndex = 1
        'End If
        Me.lblNumeroSolicitudCredito.Text = dtoUtilitario.ObtieneNumeroSolicitud(dtoUSUARIOS.IdLogin, 1)
        intOperacion = Operacion.Nuevo
        ActivaDesactivaCredito(1, dgvSolicitudCredito.Rows.Count)

        Dim intLineaCredito = Cls_LineaCredito_LN.LineaCredito(dgvClienteCredito.CurrentRow.Cells("id").Value)
        If intLineaCredito = -1 Or intLineaCredito = 2 Then 'LC= -1nueva,2cancelada 
            LlenarComboCredito()
            Me.grbSolicitudProductoCredito.Enabled = True
            Me.grbSolicitudFacturacionCredito.Enabled = True
            Me.cboProductoCredito.SelectedValue = 0
            Me.cboTipoFacturacionCredito.SelectedValue = 0
        Else '1activo 0desactivada
            Me.grbSolicitudProductoCredito.Enabled = False
            Me.grbSolicitudFacturacionCredito.Enabled = False
        End If

        Me.txtMontoSolicitadoCredito.Focus()
    End Sub
    Sub LimpiarSolicitudCredito()
        Me.lblNumeroSolicitudCredito.Text = ""
        Me.txtMontoSolicitadoCredito.Text = ""

        Me.cboComercialCredito.SelectedIndex = 0
        Me.cboPagoCredito.SelectedIndex = 0
        Me.cboConceptoCredito.SelectedValue = 1

        'Me.lblEmailComercial.Text = ""
        'Me.lblEmailPago.Text = ""
        'Me.lblTelefonoComercial.Text = ""
        'Me.lblTelefonoPago.Text = ""
        'Me.lblMovilComercial.Text = ""
        'Me.lblMovilPago.Text = ""

        Me.cboCondicionCredito.SelectedIndex = 0
        Me.rbtDiaSemana.Checked = True
        Me.dtpDia1.Value = "01/01/1900" '("01" & "/01/1900 00:00:00 a.m.")
        Me.dtpDia2.Value = "01/01/1900" '("01" & "/01/1900 00:00:00 a.m.")
        Me.dtpDia3.Value = "01/01/1900" '("01" & "/01/1900 00:00:00 a.m.")
        Me.dtpDia4.Value = "01/01/1900" '("01" & "/01/1900 00:00:00 a.m.")
        Me.chkDia1.Checked = False
        Me.chkDia2.Checked = False
        Me.chkDia3.Checked = False
        'Me.ChkDia4.Checked = False

        Me.dtpDia1.Enabled = False
        Me.dtpDia2.Enabled = False
        Me.dtpDia3.Enabled = False
        Me.dtpDia4.Enabled = False

        Me.dtpHora1.Text = Now.ToLongTimeString
        Me.dtpHora2.Text = Now.ToShortTimeString
        Me.dtpHora1.Checked = False
        Me.dtpHora2.Checked = False
        Me.LimpiarDias(lstDia)

        Me.cboProductoCredito.SelectedValue = 0
        Me.chkContadoCredito.Enabled = False
        Me.chkContadoCredito.Checked = False

        Me.cboTipoFacturacionCredito.SelectedValue = 0
        Me.cboContactoFacturacionCredito.SelectedValue = 0
        Me.dgvFacturacion3Credito.Rows.Clear()
        Me.chkOrdenCompraCredito.Checked = False
        Me.chkLiquidacionDocumentoCredito.Checked = False
        'Me.cboFormaFacturacionCredito.SelectedValue = 0

        'hlamas 08-04-2016
        Me.cboFormaPago.SelectedValue = 0
        Me.dtpFechaCorte.Value = Now.ToShortDateString

        Me.rbtDiaSemanaFacturacion.Checked = True
        Me.dtpDia1Facturacion.Value = "01/01/1900" '("01" & "/01/1900 00:00:00 a.m.")
        Me.dtpDia2Facturacion.Value = "01/01/1900" ' ("01" & "/01/1900 00:00:00 a.m.")
        Me.dtpDia3Facturacion.Value = "01/01/1900" ' ("01" & "/01/1900 00:00:00 a.m.")
        Me.dtpDia4Facturacion.Value = "01/01/1900" ' ("01" & "/01/1900 00:00:00 a.m.")
        Me.chkDia1Facturacion.Checked = False
        Me.chkDia2Facturacion.Checked = False
        Me.chkDia3Facturacion.Checked = False
        'Me.ChkDia4.Checked = False

        Me.dtpDia1Facturacion.Enabled = False
        Me.dtpDia2Facturacion.Enabled = False
        Me.dtpDia3Facturacion.Enabled = False
        Me.dtpDia4Facturacion.Enabled = False

        Me.dtpHora1Facturacion.Text = Now.ToLongTimeString
        Me.dtpHora2Facturacion.Text = Now.ToShortTimeString
        Me.dtpHora1Facturacion.Checked = False
        Me.dtpHora2Facturacion.Checked = False
        Me.LimpiarDias(lstDiaFacturacion)
        '-------------------------------------------------------

        Me.dgvAcuerdoCliente.Rows.Clear()
    End Sub
    Sub ActivaDesactivaCredito(estado As Integer, registros As Integer)
        Dim blnEstado As Boolean
        If estado = 1 Then
            blnEstado = True
        ElseIf estado = 0 Then
            blnEstado = False
        End If
        If estado = -1 Then
            Me.grbSolicitudCredito.Enabled = False
            Me.grbSolicitudProductoCredito.Enabled = False
            Me.grbSolicitudFacturacionCredito.Enabled = False
            Me.pnlDocumento.Enabled = False

            Me.btnNuevoCredito.Enabled = Me.dgvClienteCredito.Rows.Count > 0
            If registros = 0 Then
                Me.btnModificarCredito.Enabled = False
                Me.btnAnularCredito.Enabled = False
            Else
                Me.btnModificarCredito.Enabled = True
                Me.btnAnularCredito.Enabled = True
            End If
            Me.btnGrabarCredito.Enabled = False
            Me.btnCancelarCredito.Enabled = False
        Else
            blnEstado = estado
            Me.grbSolicitudCredito.Enabled = blnEstado
            Me.grbSolicitudProductoCredito.Enabled = False
            Me.grbSolicitudFacturacionCredito.Enabled = False
            Me.pnlDocumento.Enabled = blnEstado

            Me.btnNuevoCredito.Enabled = Not blnEstado
            If registros = 0 Then
                Me.btnModificarCredito.Enabled = False
            Else
                Me.btnModificarCredito.Enabled = Not blnEstado
            End If
            Me.btnGrabarCredito.Enabled = blnEstado
            Me.btnCancelarCredito.Enabled = blnEstado
            If registros = 0 Then
                Me.btnAnularCredito.Enabled = False
            Else
                Me.btnAnularCredito.Enabled = Not blnEstado
            End If
        End If

        If Me.btnGrabarCredito.Enabled Then
            Me.dgvSolicitudCredito.Enabled = False
            Me.cboEstadoCredito.Enabled = False
        Else
            Me.dgvSolicitudCredito.Enabled = True
            Me.cboEstadoCredito.Enabled = True
        End If
    End Sub
    Sub CargarContactoCredito(cliente As Integer)
        Try
            Dim objLN As New Cls_LineaCredito_LN
            With cboComercialCredito
                .DataSource = Nothing
                .DataSource = objLN.ListarContactoCredito(cliente, "(267,307)")
                .DisplayMember = "CONTACTO"
                .ValueMember = "ID"
                .SelectedValue = 0
            End With

            With cboPagoCredito
                .DataSource = Nothing
                .DataSource = objLN.ListarContactoCredito(cliente, "(728)")
                .DisplayMember = "CONTACTO"
                .ValueMember = "ID"
                .SelectedValue = 0
            End With

            With cboContactoFacturacionCredito
                .DataSource = Nothing
                .DataSource = objLN.ListarContactoCredito(cliente, "") '"(728)"
                .DisplayMember = "CONTACTO"
                .ValueMember = "ID"
                .SelectedValue = 0
            End With

            'Dim objLN2 As New Cls_ClienteTipoFacturacion_LN
            'With cboFormaFacturacionCredito
            '    .DataSource = Nothing
            '    .DataSource = objLN2.ListarFormaFacturacion
            '    .DisplayMember = "FORMA"
            '    .ValueMember = "ID"
            '    .SelectedValue = 0
            'End With
            'Me.cboFormaFacturacionCredito.SelectedIndex = 1

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub CargarCondicionCredito()
        Try
            Dim objLN As New Cls_LineaCredito_LN
            Dim dt As DataTable = objLN.ListarCondicionCredito()
            With cboCondicionCredito
                .DataSource = Nothing
                .DataSource = dt
                .DisplayMember = "CONDICION"
                .ValueMember = "ID"
            End With

            dt = objLN.ListarConceptoCredito()
            With cboConceptoCredito
                .DataSource = Nothing
                .DataSource = dt
                .DisplayMember = "CONCEPTO"
                .ValueMember = "ID"
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Sub ListarContactoDatos(sender As Object, e As EventArgs) Handles cboComercialCredito.SelectedIndexChanged, cboPagoCredito.SelectedIndexChanged
    'If IsReference(CType(sender, ComboBox).SelectedValue) Then Return

    'Dim intOpcion As Integer = IIf(CType(sender, ComboBox).Name = "cboComercialCredito", 0, 1)
    'Dim intContacto As Integer = CType(sender, ComboBox).SelectedValue

    'Dim objLN As New Cls_LineaCredito_LN()
    'Dim dt As DataTable = objLN.ListarContactoDatos(intContacto)

    'If intOpcion = 0 Then
    'Me.lblEmailComercial.Text = ""
    'Me.lblTelefonoComercial.Text = ""
    'Me.lblMovilComercial.Text = ""
    'If dt.Rows.Count > 0 Then
    'For i As Integer = 0 To dt.Rows.Count - 1
    'Select Case dt.Rows(i).Item(0)
    'Case 1
    'Me.lblTelefonoComercial.Text = IIf(IsDBNull(dt.Rows(i).Item(1)), "", dt.Rows(i).Item(1))
    'Case 2
    'Me.lblMovilComercial.Text = IIf(IsDBNull(dt.Rows(i).Item(1)), "", dt.Rows(i).Item(1))
    'Case 3
    'Me.lblEmailComercial.Text = IIf(IsDBNull(dt.Rows(i).Item(1)), "", dt.Rows(i).Item(1))
    'End Select
    'Next
    'End If
    'Else
    'Me.lblEmailPago.Text = ""
    'Me.lblTelefonoPago.Text = ""
    'Me.lblMovilPago.Text = ""
    'If dt.Rows.Count > 0 Then
    'For i As Integer = 0 To dt.Rows.Count - 1
    'Select Case dt.Rows(i).Item(0)
    'Case 1
    'Me.lblTelefonoPago.Text = IIf(IsDBNull(dt.Rows(i).Item(1)), "", dt.Rows(i).Item(1))
    'Case 2
    'Me.lblMovilPago.Text = IIf(IsDBNull(dt.Rows(i).Item(1)), "", dt.Rows(i).Item(1))
    'Case 3
    'Me.lblEmailPago.Text = IIf(IsDBNull(dt.Rows(i).Item(1)), "", dt.Rows(i).Item(1))
    'End Select
    'Next
    'End If
    'End If
    'End Sub
#End Region
#Region "Lista"
    Sub ListarSolicitudCredito(estado As Integer, Optional inicio As String = "", Optional fin As String = "")
        Try
            Dim objLN As New Cls_LineaCredito_LN
            Dim objEN As New Cls_LineaCredito_EN

            Cursor = Cursors.WaitCursor
            objEN.Estado = estado
            Me.dgvListaCredito.DataSource = objLN.ListarSolicitud(objEN, inicio, fin)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Listar Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
#End Region
#Region "Preaprobar"

#End Region
#Region "Aprobar"
    Private Sub BuscarClienteCredito(cliente As String, opcion As Integer, Optional usuario As Integer = 0)
        Try
            If opcion = 1 Then
                If Not fnValidarRUC(cliente) Then
                    MessageBox.Show("El RUC no es Válido", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtNumeroDocumentoCredito.Focus()
                    Me.txtNumeroDocumentoCredito.SelectAll()
                    Return
                End If
            End If

            Cursor = Cursors.AppStarting
            Dim obj As New Cls_Cliente_LN
            'Dim intUsuario As Integer = 0
            'If Me.cboFuncionarioCredito.Tag = "*" Then
            '    intUsuario = dtoUSUARIOS.IdLogin
            'End If
            Dim dt As DataTable = obj.BuscarCliente(cliente, opcion, usuario)

            If usuario = 0 Then
                Cursor = Cursors.Default
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("No se encontraron coincidencias", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Me.cboFuncionarioCredito.SelectedValue = 0
                    Me.dgvCarteraCredito.DataSource = dt
                    lblNumeroClienteCredito.Text = Me.dgvCarteraCredito.Rows.Count
                End If
            Else
                Cursor = Cursors.Default
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("No se encontraron coincidencias", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Me.dgvCarteraCredito.DataSource = dt
                    lblNumeroClienteCredito.Text = Me.dgvCarteraCredito.Rows.Count
                End If
            End If
            If Me.txtNumeroDocumentoCredito.Focused Then
                Me.txtNumeroDocumentoCredito.Focus()
                Me.txtNumeroDocumento.SelectAll()
            ElseIf Me.txtRazonSocialCredito.Focused Then
                Me.txtRazonSocialCredito.Focus()
                Me.txtRazonSocialCredito.SelectAll()
            End If
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region
#Region "Administrador"
    Sub LimpiarAprobacionCredito()
        Me.lblCodigoCredito.Text = ""
        Me.lblRazonSocialCredito.Text = ""
        Me.lblFuncionarioCreditoAprobacion.Text = ""
        Me.lblProductoCredito.Text = ""
        Me.lblContadoCredito.Text = ""
        Me.lblTipoFacturacionCredito.Text = ""
        Me.LblCondicion.Text = ""
        Me.LblPeriodo.Text = ""
        Me.LblDia.Text = ""
        Me.LblInicio.Text = ""
        Me.LblFin.Text = ""

        'hlamas 08-04-2016
        Me.grbContactoComercial.Text = "Contacto Comercial"
        Me.grbContactoPagos.Text = "Contacto Pagos"
        Me.lblCargoComercial.Text = ""
        Me.lblTelefonoComercial.Text = ""
        Me.lblEmailComercial.Text = ""

        Me.lblCargoPagos.Text = ""
        Me.lblTelefonoPagos.Text = ""
        Me.lblEmailPagos.Text = ""

        Me.lblCondicionFacturacion.Text = ""
        Me.lblDireccionEntrega.Text = ""
        Me.lblFechaCorte.Text = ""
        Me.lblPeriodoFacturacion.Text = ""
        Me.lblDiaFacturacion.Text = ""
        Me.lblInicioFacturacion.Text = ""
        Me.lblFinFacturacion.Text = ""
        Me.lblOrdenCompra.Text = ""
        dgvDocumentoCliente.DataSource = Nothing
        '---------------------------------

        Me.txtMontoOtorgado.Text = "0.00"
        Me.lblMontoAprobado.Text = "0.00"
        Me.lblSobregiroAprobado.Text = "0.00"
        Me.lblLineaFinalAprobada.Text = "0.00"
        Me.rbtSiCredito.Checked = True
        Me.txtObservacionCredito.Text = ""
        Me.txtMontoOtorgado.Enabled = False
    End Sub

    Sub ListarFormaPago()
        With Me.cboFormaPago
            .DataSource = ListarTipoControl(10, 2)
            .DisplayMember = "descripcion"
            .ValueMember = "codigo"
            .SelectedValue = 0
        End With
    End Sub

    Public Sub tabLineaCredito_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabLineaCredito.SelectedIndexChanged
        If tabLineaCredito.SelectedTab Is tabLineaCredito.TabPages("tabClienteCredito") Then
            ConfigurarDGVClienteCredito()
            ConfigurarDGVClienteCreditoDetalle()
            CargarCartera(dtoUSUARIOS.IdLogin, Me.dgvClienteCredito)
        ElseIf tabLineaCredito.SelectedTab Is tabLineaCredito.TabPages("tabSolicitudCredito") Then
            If Me.dgvClienteCredito.Rows.Count = 0 Then
                ActivaDesactivaCredito(-1, dgvSolicitudCredito.Rows.Count)
                Return
            End If
            intOperacion = Operacion.Nuevo
            Me.ListarFormaPago()
            Me.lblFechaCredito.Text = Format(Now, "Short Date")
            Me.lblFuncionarioCredito.Text = dtoUSUARIOS.NameLogin
            Dim strCliente As String = dgvClienteCredito.CurrentRow.Cells("codigo").Value & "  " & dgvClienteCredito.CurrentRow.Cells("cliente").Value
            Me.lblFuncionarioCredito.Text = dtoUSUARIOS.NameLogin
            Me.lblClienteCredito.Text = strCliente.Trim
            Me.ListarDireccionCredito(dgvClienteCredito.CurrentRow.Cells("id").Value, 1)
            CargarContactoCredito(dgvClienteCredito.CurrentRow.Cells("id").Value)
            CargarCondicionCredito()
            ConfigurarDGVSolicitudCredito()
            ConfigurarDGVFacturacion3Credito()
            Me.LimpiarSolicitudCredito()
            ListarSolicitudCredito()
            cboEstadoCredito.SelectedIndex = 1
            ActivaDesactivaCredito(-1, dgvSolicitudCredito.Rows.Count)
            Me.btnNuevoCredito.Focus()
        ElseIf tabLineaCredito.SelectedTab Is tabLineaCredito.TabPages("tabListaCredito") Then
            If Me.dgvListaCredito.Rows.Count = 0 Then
                'Me.tabLineaCredito.TabPages.Remove(tabLineaCredito.TabPages("tabListaCredito"))
                'Me.tabLineaCredito.TabPages.Remove(tabLineaCredito.TabPages("tabAprobacionCredito"))
            End If
        ElseIf tabLineaCredito.SelectedTab Is tabLineaCredito.TabPages("tabAprobacionCredito") Then
            If dgvListaCredito.Rows.Count > 0 Then
                btnAceptarCredito.Enabled = True
                Me.txtMontoOtorgado.Enabled = True
                Me.rbtSiCredito.Enabled = True
                Me.rbtNoCredito.Enabled = True
                Me.rbtSiCredito.Checked = True
                Me.txtObservacionCredito.Text = ""

                'hlamas 08-04-2016
                'documentos del cliente
                ConfigurarDGVDocumentoCliente()
                Dim obj As New Cls_ClienteTipoFacturacion_LN
                Me.dgvDocumentoCliente.DataSource = obj.ListarClienteCargos(Me.dgvListaCredito.CurrentRow.Cells("idcliente").Value)

                'comunicacion con contacto
                Dim s As String = ""
                Dim obj2 As New Cls_Contacto_LN
                Dim dt As DataTable = obj2.ListarComunicacion(Me.dgvListaCredito.CurrentRow.Cells("idcontacto_comercial").Value)
                If dt.Rows.Count > 0 Then
                    For Each row As DataRow In dt.Rows
                        s &= row("tipo").ToString & " " & row("numero").ToString & Chr(13)
                    Next
                End If
                Me.lblTelefonoComercial.Text = s

                s = ""
                dt = obj2.ListarComunicacion(Me.dgvListaCredito.CurrentRow.Cells("idcontacto_pago").Value)
                If dt.Rows.Count > 0 Then
                    For Each row As DataRow In dt.Rows
                        s &= row("tipo").ToString & " " & row("numero").ToString & Chr(13)
                    Next
                End If
                Me.lblTelefonoPagos.Text = s
            Else
                LimpiarAprobacionCredito()
                btnAceptarCredito.Enabled = False
                Me.rbtSiCredito.Enabled = False
                Me.rbtNoCredito.Enabled = False
            End If
            Dim intOpcion As Integer
            If Me.rbtPorPreaprobar.Checked Then
                intOpcion = 1
            ElseIf Me.rbtPorAprobar.Checked Then
                intOpcion = 2
            ElseIf Me.rbtAprobadas.Checked Then
                intOpcion = 3
            Else
                intOpcion = 4
            End If
            ControlaAprobacion(intOpcion)
        ElseIf tabLineaCredito.SelectedTab Is tabLineaCredito.TabPages("tabOperacionCredito") Then
            ConfigurarDGVCarteraCredito()
            ConfigurarDGVLineaCredito()
            ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.cboFuncionarioCredito, "", "", 3, " (SELECCIONE)")
            'Me.CargarClienteCredito()
            Me.cboEstadoOperacionCredito.SelectedIndex = 1
        End If
    End Sub
#End Region
#End Region

#Region "Asignar Producto"
#Region "Configurar Grid"
    Private Sub ConfigurarDGVClienteProducto()
        With dgvClienteProducto
            Cls_Utilitarios.FormatDataGridView(dgvClienteProducto)
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
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
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
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            x += +1
            Dim col_linea_credito As New DataGridViewTextBoxColumn
            With col_linea_credito
                .Name = "linea_credito" : .DataPropertyName = "linea_credito"
                .DisplayIndex = x : .HeaderText = "Línea Crédito" : .Visible = True
            End With

            .Columns.AddRange(col_id, col_codigo, col_cliente, col_linea_credito)
        End With
    End Sub
    Private Sub ConfigurarDGVClienteProductoDetalle()
        With dgvClienteProductoDetalle
            'utilitario.FormatDataGridView(dgvLista)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_subcuenta As New DataGridViewTextBoxColumn
            With col_subcuenta
                .Name = "subcuenta" : .DataPropertyName = "subcuenta"
                .DisplayIndex = x : .HeaderText = "Subcuenta" : .Visible = True
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Orígen"
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
            End With
            x += +1
            Dim col_producto As New DataGridViewTextBoxColumn
            With col_producto
                .Name = "producto" : .DataPropertyName = "producto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Producto"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_contado As New DataGridViewTextBoxColumn
            With col_contado
                .Name = "contado" : .DataPropertyName = "contado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Contado"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            x += +1
            Dim col_idcontado As New DataGridViewTextBoxColumn
            With col_idcontado
                .Name = "idcontado" : .DataPropertyName = "idcontado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcontado"
            End With
            x += +1
            Dim col_fecha_inicio As New DataGridViewTextBoxColumn
            With col_fecha_inicio
                .Name = "fecha_inicio" : .DataPropertyName = "fecha_inicio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Inicio"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_fin As New DataGridViewTextBoxColumn
            With col_fecha_fin
                .Name = "fecha_fin" : .DataPropertyName = "fecha_fin"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Fin"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.AddRange(col_subcuenta, col_origen, col_destino, col_producto, col_contado, col_idcontado, col_fecha_inicio, col_fecha_fin)
        End With
    End Sub
    Private Sub ConfigurarDGVSolicitudProducto()
        With dgvSolicitudProducto
            Cls_Utilitarios.FormatDataGridView(dgvSolicitudProducto)
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
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
            End With
            x += +1
            Dim col_subcuenta1 As New DataGridViewTextBoxColumn
            With col_subcuenta1
                .Name = "subcuenta1" : .DataPropertyName = "subcuenta1"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subcuenta"
            End With
            x += +1
            Dim col_origen1 As New DataGridViewTextBoxColumn
            With col_origen1
                .Name = "origen1" : .DataPropertyName = "origen1"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
            End With
            x += +1
            Dim col_destino1 As New DataGridViewTextBoxColumn
            With col_destino1
                .Name = "destino1" : .DataPropertyName = "destino1"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
            End With
            x += +1
            Dim col_producto1 As New DataGridViewTextBoxColumn
            With col_producto1
                .Name = "producto1" : .DataPropertyName = "producto1"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Producto"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
            End With
            x += +1
            Dim col_idcontado As New DataGridViewTextBoxColumn
            With col_idcontado
                .Name = "idcontado" : .DataPropertyName = "idcontado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcontado"
            End With
            Dim col_contado As New DataGridViewTextBoxColumn
            With col_contado
                .Name = "contado" : .DataPropertyName = "contado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Contado"
            End With
            x += +1
            Dim col_aprobacion As New DataGridViewTextBoxColumn
            With col_aprobacion
                .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aprobación"
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
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Observacion"
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id"
            End With
            x += +1
            Dim col_idestado As New DataGridViewTextBoxColumn
            With col_idestado
                .Name = "idestado" : .DataPropertyName = "idestado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id estado"
            End With
            x += +1
            Dim col_subcuenta As New DataGridViewTextBoxColumn
            With col_subcuenta
                .Name = "idsubcuenta" : .DataPropertyName = "idsubcuenta"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Subcuenta"
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Origen"
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Destino"
            End With
            x += +1
            Dim col_producto As New DataGridViewTextBoxColumn
            With col_producto
                .Name = "producto" : .DataPropertyName = "producto"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Producto"
            End With
            x += +1
            Dim col_pendiente As New DataGridViewTextBoxColumn
            With col_pendiente
                .Name = "pendiente" : .DataPropertyName = "pendiente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Pendiente"
            End With

            .Columns.AddRange(col_solicitud, col_fecha, col_cliente, col_subcuenta1, col_origen1, col_destino1, col_producto1, col_estado, col_idcontado, _
                              col_contado, col_aprobacion, col_desaprobacion, col_anulacion, _
                              col_observacion, col_id, col_idestado, col_subcuenta, col_origen, col_destino, col_producto)
        End With
    End Sub
    Private Sub ConfigurarDGVListaProducto()
        With dgvListaProducto
            Cls_Utilitarios.FormatDataGridView(dgvListaProducto)
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
            Dim col_idcliente As New DataGridViewTextBoxColumn
            With col_idcliente
                .Name = "idcliente" : .DataPropertyName = "idcliente"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id Cliente"
            End With

            x += +1
            Dim col_solicitante As New DataGridViewTextBoxColumn
            With col_solicitante
                .Name = "solicitante" : .DataPropertyName = "solicitante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Solicitante"
            End With
            x += +1
            Dim col_usuario_solicitud As New DataGridViewTextBoxColumn
            With col_usuario_solicitud
                .Name = "usuario_solicitud" : .DataPropertyName = "usuario_solicitud"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id Usuario Solicitud"
            End With
            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Observación"
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "ID"
            End With
            x += +1
            Dim col_subcuenta As New DataGridViewTextBoxColumn
            With col_subcuenta
                .Name = "subcuenta" : .DataPropertyName = "subcuenta"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subcuenta"
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Orígen"
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
            End With

            x += +1
            Dim col_idproducto As New DataGridViewTextBoxColumn
            With col_idproducto
                .Name = "idproducto" : .DataPropertyName = "idproducto"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idproducto"
            End With
            x += +1
            Dim col_idsubcuenta As New DataGridViewTextBoxColumn
            With col_idsubcuenta
                .Name = "idsubcuenta" : .DataPropertyName = "idsubcuenta"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idSubcuenta"
            End With
            x += +1
            Dim col_idorigen As New DataGridViewTextBoxColumn
            With col_idorigen
                .Name = "idorigen" : .DataPropertyName = "idorigen"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idOrigen"
            End With
            x += +1
            Dim col_iddestino As New DataGridViewTextBoxColumn
            With col_iddestino
                .Name = "iddestino" : .DataPropertyName = "iddestino"
                .DisplayIndex = x : .Visible = False : .HeaderText = "iddestino"
            End With
            x += +1
            Dim col_producto As New DataGridViewTextBoxColumn
            With col_producto
                .Name = "producto" : .DataPropertyName = "producto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Producto"
            End With
            x += +1
            Dim col_idcontado As New DataGridViewTextBoxColumn
            With col_idcontado
                .Name = "idcontado" : .DataPropertyName = "idcontado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcontado"
            End With
            x += +1
            Dim col_contado As New DataGridViewTextBoxColumn
            With col_contado
                .Name = "contado" : .DataPropertyName = "contado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Contado"
            End With
            .Columns.AddRange(col_solicitud, col_fecha, col_codigo, col_cliente, col_idcliente, col_solicitante, _
                              col_usuario_solicitud, col_observacion, col_id, col_subcuenta, col_origen, col_destino, _
                              col_idsubcuenta, col_idorigen, col_iddestino, col_producto, col_idproducto, col_idcontado, col_contado)
        End With
    End Sub
    Private Sub ConfigurarDGVClienteProductoDesactivar()
        With dgvClienteProductoDesactivar
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(Me.dgvClienteProductoDesactivar)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 8.0!, FontStyle.Regular)
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
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2

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
            Dim col_FechaInicio As New DataGridViewTextBoxColumn
            With col_FechaInicio
                .Name = "fecha_inicio" : .DataPropertyName = "fecha_inicio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Inicio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            .Columns.AddRange(col_id, col_codigo, col_cliente, col_FechaInicio)
        End With
    End Sub
    Private Sub ConfigurarDGVClienteProductoDetalleDesactivar()
        With dgvClienteProductoDetalleDesactivar
            'Cls_Utilitarios.FormatDataGridView(dgvClienteProductoDetalleDesactivar)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False

            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_subcuenta As New DataGridViewTextBoxColumn
            With col_subcuenta
                .Name = "subcuenta" : .DataPropertyName = "subcuenta"
                .DisplayIndex = x : .HeaderText = "Subcuenta" : .Visible = True
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Orígen"
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
            End With
            x += +1
            Dim col_producto As New DataGridViewTextBoxColumn
            With col_producto
                .Name = "producto" : .DataPropertyName = "producto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Producto"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_idcontado As New DataGridViewTextBoxColumn
            With col_idcontado
                .Name = "idcontado" : .DataPropertyName = "idcontado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcontado"
            End With
            x += +1
            Dim col_contado As New DataGridViewTextBoxColumn
            With col_contado
                .Name = "contado" : .DataPropertyName = "contado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Contado"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            x += +1
            Dim col_fecha_inicio As New DataGridViewTextBoxColumn
            With col_fecha_inicio
                .Name = "fecha_inicio" : .DataPropertyName = "fecha_inicio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Inicio"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_fin As New DataGridViewTextBoxColumn
            With col_fecha_fin
                .Name = "fecha_fin" : .DataPropertyName = "fecha_fin"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Fin"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_idproducto As New DataGridViewTextBoxColumn
            With col_idproducto
                .Name = "idproducto" : .DataPropertyName = "idproducto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Id Producto"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = False
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Id"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = False
            End With
            .Columns.AddRange(col_subcuenta, col_origen, col_destino, col_producto, col_idcontado, col_contado, col_fecha_inicio, col_fecha_fin, col_idproducto, col_id)
        End With
    End Sub
#End Region
#Region "Clientes"
    Sub ListarProducto(cliente As Integer, dgv As DataGridView)
        Dim obj As New Cls_ClienteProducto_LN
        Dim dt As DataTable = obj.ListarProducto(cliente)
        dgv.DataSource = dt
    End Sub
    Private Sub dgvClienteProducto_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvClienteProducto.DoubleClick
        intFilaDGVClienteProducto = 0
        With dgvClienteProducto
            If .Rows.Count > 0 Then
                intFilaDGVClienteProducto = .CurrentRow.Index
                Me.tabAsignarProducto.SelectedTab = Me.tabAsignarProducto.TabPages("tabSolicitudProducto")
            End If
        End With
    End Sub
    Private Sub dgvClienteProducto_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClienteProducto.RowEnter
        If blnInicioProducto = False Then Return
        Dim intCliente As Integer = dgvClienteProducto.Rows(e.RowIndex).Cells("id").Value
        ListarProducto(intCliente, Me.dgvClienteProductoDetalle)
    End Sub
#End Region
#Region "Solicitud"
    Sub AnularProducto()
        Try
            Dim objEN As New Cls_ClienteProducto_EN
            Dim objLN As New Cls_ClienteProducto_LN

            objEN.ID = dgvSolicitudProducto.CurrentRow.Cells("id").Value
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP

            objLN.AnularSolicitud(objEN)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAnularProducto_Click(sender As System.Object, e As System.EventArgs) Handles btnAnularProducto.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está Seguro de Anular la Solicitud Nº " & dgvSolicitudProducto.CurrentRow.Cells("numero_solicitud").Value & "?", "Anular Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = vbYes Then
            AnularProducto()
            ListarSolicitudProducto()
        End If
    End Sub

    Sub MostrarSolicitudProducto(row As Integer)
        With dgvSolicitudProducto
            Me.lblNumeroSolicitudProducto.Text = .Rows(row).Cells("numero_solicitud").Value
            Me.lblFechaProducto.Text = .Rows(row).Cells("fecha_solicitud").Value
            Me.lblClienteProducto.Text = .Rows(row).Cells("cliente").Value
            'Dim s As String = dgvSolicitudProducto.Rows(1).Cells("cliente").Value

            Me.cboSubcuentaProducto.SelectedValue = .Rows(row).Cells("idsubcuenta").Value
            Me.cboOrigenProducto.SelectedValue = .Rows(row).Cells("origen").Value
            Me.cboDestinoProducto.SelectedValue = .Rows(row).Cells("destino").Value
            Me.cboPProducto.SelectedValue = .Rows(row).Cells("producto").Value
            Me.chkContadoProducto.Checked = IIf(.Rows(row).Cells("idcontado").Value = 1, True, False)

            Me.txtSustentoProducto.Text = .Rows(row).Cells("observacion").Value
        End With
    End Sub

    Private Sub dgvSolicitudProducto_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvSolicitudProducto.DoubleClick
        If dgvSolicitudProducto.Rows.Count > 0 Then
            If Me.btnGrabarProducto.Enabled = False And dgvSolicitudProducto.CurrentRow.Cells("idestado").Value = 1 Then
                btnModificarProducto_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub dgvSolicitudProducto_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSolicitudProducto.RowEnter
        If Me.btnNuevoProducto.Enabled Then
            MostrarSolicitudProducto(e.RowIndex)
            Me.btnModificarProducto.Enabled = dgvSolicitudProducto.Rows(e.RowIndex).Cells("idestado").Value = 1
            Me.btnAnularProducto.Enabled = dgvSolicitudProducto.Rows(e.RowIndex).Cells("idestado").Value = 1
        End If
    End Sub

    Private Sub txtObservacionProducto_Enter(sender As Object, e As System.EventArgs) Handles txtSustentoProducto.Enter
        txtSustentoProducto.SelectAll()
    End Sub

    Private Sub cboEstadoProducto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstadoProducto.SelectedIndexChanged
        Me.LimpiarSolicitudProducto()
        ListarSolicitudProducto()
        'Me.ActivaDesactivaProducto(0, Me.dgvSolicitudProducto.Rows.Count)
        If Me.dgvSolicitudProducto.Rows.Count > 0 AndAlso btnNuevoProducto.Enabled Then
            Me.btnModificarProducto.Enabled = dgvSolicitudProducto.CurrentRow.Cells("idestado").Value = 1
            Me.btnAnularProducto.Enabled = dgvSolicitudProducto.CurrentRow.Cells("idestado").Value = 1
        ElseIf Me.dgvSolicitudProducto.Rows.Count = 0 Then
            Me.ActivaDesactivaProducto(-1, 0)
        End If
    End Sub

    Sub ListarSolicitudProducto()
        Try
            'If Me.dgvSolicitudProducto.Rows.Count = 0 Then Return
            Dim obj As New Cls_ClienteProducto_LN
            Dim objEN As New Cls_ClienteProducto_EN

            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.Estado = Me.cboEstadoProducto.SelectedIndex
            objEN.Cliente = dgvClienteProducto.CurrentRow.Cells(0).Value
            dgvSolicitudProducto.DataSource = obj.ListarSolicitud(objEN.Usuario, objEN.Cliente, objEN.Estado)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActivaDesactivaProducto(estado As Integer, registros As Integer)
        Dim blnEstado As Boolean
        If estado = 1 Then
            blnEstado = True
        ElseIf estado = 0 Then
            blnEstado = False
        End If
        If estado = -1 Then
            Me.grbSolicitudProducto.Enabled = False
            Me.btnNuevoProducto.Enabled = Me.dgvClienteProducto.Rows.Count > 0
            If registros = 0 Then
                Me.btnModificarProducto.Enabled = False
                Me.btnAnularProducto.Enabled = False
            Else
                Me.btnModificarProducto.Enabled = True
                Me.btnAnularProducto.Enabled = True
            End If
            Me.btnGrabarProducto.Enabled = False
            Me.btnCancelarProducto.Enabled = False
        Else
            blnEstado = estado
            Me.grbSolicitudProducto.Enabled = blnEstado
            Me.btnNuevoProducto.Enabled = Not blnEstado
            If registros = 0 Then
                Me.btnModificarProducto.Enabled = False
            Else
                Me.btnModificarProducto.Enabled = Not blnEstado
            End If
            Me.btnGrabarProducto.Enabled = blnEstado
            Me.btnCancelarProducto.Enabled = blnEstado
            If registros = 0 Then
                Me.btnAnularProducto.Enabled = False
            Else
                Me.btnAnularProducto.Enabled = Not blnEstado
            End If
        End If

        If Me.btnGrabarProducto.Enabled Then
            Me.dgvSolicitudProducto.Enabled = False
            Me.cboEstadoProducto.Enabled = False
        Else
            Me.dgvSolicitudProducto.Enabled = True
            Me.cboEstadoProducto.Enabled = True
        End If
    End Sub

    Sub LimpiarSolicitudProducto()
        Me.lblNumeroSolicitudProducto.Text = ""
        Me.cboSubcuentaProducto.SelectedValue = 0
        Me.cboOrigenProducto.SelectedValue = 0
        Me.cboDestinoProducto.SelectedValue = 0
        Me.cboPProducto.SelectedValue = 0
        Me.chkContadoProducto.Checked = False
        Me.chkContadoProducto.Enabled = False
        Me.txtSustentoProducto.Text = ""
        'Me.lblMensajeProducto.Text = ""
    End Sub

    Private Sub btnNuevoProducto_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevoProducto.Click
        LimpiarSolicitudProducto()
        Me.lblNumeroSolicitudProducto.Text = dtoUtilitario.ObtieneNumeroSolicitud(dtoUSUARIOS.IdLogin, 1)
        intOperacion = Operacion.Nuevo
        ActivaDesactivaProducto(1, dgvSolicitudProducto.Rows.Count)
        Me.cboSubcuentaProducto.DroppedDown = True
        Me.cboSubcuentaProducto.Focus()
    End Sub

    Private Sub btnModificarProducto_Click(sender As Object, e As System.EventArgs) Handles btnModificarProducto.Click
        intOperacion = Operacion.Modificar
        ActivaDesactivaProducto(1, dgvSolicitudProducto.Rows.Count)
        Me.cboSubcuentaProducto.Focus()
    End Sub

    Private Sub btnCancelarProducto_Click(sender As Object, e As System.EventArgs) Handles btnCancelarProducto.Click
        LimpiarSolicitudProducto()
        ActivaDesactivaProducto(0, dgvSolicitudProducto.Rows.Count)

        If Me.dgvSolicitudProducto.Rows.Count > 0 Then
            MostrarSolicitudProducto(dgvSolicitudProducto.CurrentCell.RowIndex)

        End If
        If intOperacion = Operacion.Nuevo Then
            btnNuevoProducto.Focus()
        Else
            btnModificarProducto.Focus()
        End If
    End Sub

    Function ValidarProducto(cliente As Integer, solicitud As Integer, subcuenta As Integer, origen As Integer, destino As Integer, producto As Integer, contado As Integer) As Integer
        Dim objLN As New Cls_ClienteProducto_LN
        Dim objEN As New Cls_ClienteProducto_EN

        objEN.Cliente = cliente
        objEN.NumeroSolicitud = solicitud
        objEN.Subcuenta = subcuenta
        objEN.Origen = origen
        objEN.Destino = destino
        objEN.Producto = producto
        objEN.Contado = contado

        Return objLN.ValidarProducto(objEN)
    End Function

    Private Sub btnGrabarProducto_Click(sender As Object, e As System.EventArgs) Handles btnGrabarProducto.Click
        Try
            If Me.cboSubcuentaProducto.SelectedValue = 0 Then
                MessageBox.Show("Seleccione Subcuenta", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboSubcuentaProducto.DroppedDown = True
                Me.cboSubcuentaProducto.Focus()
                Return
            End If

            If Me.cboPProducto.SelectedValue = 0 Then
                MessageBox.Show("Seleccione Producto", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboPProducto.DroppedDown = True
                Me.cboPProducto.Focus()
                Return
            End If

            If Me.txtSustentoProducto.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Observación de la Solicitud", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtSustentoProducto.Text = ""
                Me.txtSustentoProducto.Focus()
                Return
            End If

            Dim intCliente As Integer = Me.dgvClienteProducto.CurrentRow.Cells(0).Value
            Dim intContado As Integer = IIf(Me.chkContadoProducto.Checked, 1, 0)

            If Me.lblMensajeProducto.Text.Trim.Substring(0, 2) = "NO" Then 'no tiene linea de credito
                If intContado = 0 Then ' no seleccion contado
                    MessageBox.Show("El cliente " & Me.lblClienteProducto.Text.Trim & " no cuenta con Línea de Crédito Activa" & Chr(13) & Chr(13) & _
                                    "Sólo puede realizar solicitudes de Producto para envíos Contado", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.chkContadoProducto.Focus()
                    Return
                End If
            End If
            Dim intSolicitud As Integer = 0
            If intOperacion = Operacion.Modificar Then
                intSolicitud = Me.dgvSolicitudProducto.CurrentRow.Cells("numero_solicitud").Value
            End If
            Dim intValor As Integer = ValidarProducto(intCliente, intSolicitud, Me.cboSubcuentaProducto.SelectedValue, Me.cboOrigenProducto.SelectedValue, Me.cboDestinoProducto.SelectedValue, Me.cboPProducto.SelectedValue, intContado)
            If intValor = -1 Then
                MessageBox.Show("Existe una solicitud pendiente", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnCancelarProducto_Click(Nothing, Nothing)
                Return
            ElseIf intValor = -2 Then
                MessageBox.Show("La Asignación establecida para el cliente " & Me.lblClienteProducto.Text & " ya existe", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboSubcuentaProducto.Focus()
                Me.cboSubcuentaProducto.DroppedDown = True
                Return
            ElseIf intValor = -3 Then
                If MessageBox.Show("Se encontraron asignaciones Padres, que podrian ser reemplazadas" & Chr(13) & Chr(13) & "¿Desea Continuar?", "Grabar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Me.cboSubcuentaProducto.Focus()
                    Me.cboSubcuentaProducto.DroppedDown = True
                    Return
                End If
            ElseIf intValor = -4 Then
                If MessageBox.Show("Se encontraron asignaciones Hijas, que podrian ser reemplazadas" & Chr(13) & Chr(13) & "¿Desea Continuar?", "Grabar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Me.cboSubcuentaProducto.Focus()
                    Me.cboSubcuentaProducto.DroppedDown = True
                    Return
                End If
            End If
            'graba solicitud de producto
            Cursor = Cursors.WaitCursor
            GrabarProducto()
            ListarSolicitudProducto()
            ActivaDesactivaProducto(0, dgvSolicitudProducto.Rows.Count)
            Cursor = Cursors.Default
            Me.btnNuevoProducto.Focus()

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub GrabarProducto()
        Try
            Dim objEN As New Cls_ClienteProducto_EN
            Dim objLN As New Cls_ClienteProducto_LN

            If intOperacion = Operacion.Nuevo Then
                objEN.ID = 0
            Else
                objEN.ID = dgvSolicitudProducto.CurrentRow.Cells("id").Value
            End If
            objEN.NumeroSolicitud = Me.lblNumeroSolicitudProducto.Text
            objEN.Fecha = Me.lblFechaProducto.Text
            objEN.Cliente = Me.dgvClienteProducto.CurrentRow.Cells(0).Value
            objEN.Subcuenta = Me.cboSubcuentaProducto.SelectedValue
            objEN.Origen = Me.cboOrigenProducto.SelectedValue
            objEN.Destino = Me.cboDestinoProducto.SelectedValue
            objEN.Producto = Me.cboPProducto.SelectedValue
            objEN.Observacion = Me.txtSustentoProducto.Text.Trim
            objEN.Contado = IIf(Me.chkContadoProducto.Checked, 1, 0)
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP
            objLN.GrabarSolicitud(objEN)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

#End Region
#Region "Lista"
    Sub ListarSolicitudesPendientesProducto()
        Try
            Dim obj As New Cls_ClienteProducto_LN
            Dim objEN As New Cls_ClienteProducto_EN

            objEN.Estado = Estado.Pendiente
            dgvListaProducto.DataSource = obj.ListarSolicitud(objEN.Estado)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgvListaProducto_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvListaProducto.DoubleClick
        If Me.dgvListaProducto.Rows.Count > 0 Then
            Me.tabAsignarProducto.SelectedTab = Me.tabAsignarProducto.TabPages("tabAprobacionProducto")
            Me.tabAsignarProducto_SelectedIndexChanged(sender, e)
        End If
    End Sub
    Private Sub dgvListaProducto_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaProducto.RowEnter
        With dgvListaProducto
            If .Rows.Count > 0 Then
                'BtnAceptar.Enabled = True

                Dim row As DataGridViewRow = .Rows(e.RowIndex)

                Me.lblCodigoProducto.Text = row.Cells("codigo").Value
                Me.lblRazonSocialProducto.Text = row.Cells("cliente").Value

                Me.lblFuncionarioProductoAprobacion.Text = row.Cells("solicitante").Value

                Me.lblProductoAprobacion.Text = row.Cells("producto").Value
                Me.lblContadoAprobacion.Text = row.Cells("contado").Value
                Me.lblSubcuentaAprobacion.Text = row.Cells("subcuenta").Value
                Me.lblOrigenAprobacion.Text = row.Cells("origen").Value
                Me.lblDestinoAprobacion.Text = row.Cells("destino").Value

                'Me.lblFechaInicio.Text = IIf(IsDBNull(row.Cells("fecha_inicio").Value), "", row.Cells("fecha_inicio").Value)

                'Me.lblFuncionarioNuevo.Text = row.Cells("solicitante").Value
                Me.lblObservacionProducto.Text = row.Cells("observacion").Value

                'If Me.lblFuncionarioActualA.Text = "SIN FUNCIONARIO" Then
                'Me.dtpFechaFin.Text = ""
                'End If
            End If
        End With
    End Sub
#End Region
#Region "Aprobacion"
    Sub DesaprobarSolicitudProducto()
        Dim objEN As New Cls_ClienteProducto_EN
        Dim objLN As New Cls_ClienteProducto_LN

        objEN.ID = Me.dgvListaProducto.CurrentRow.Cells("id").Value
        objEN.Observacion = Me.txtObservacionProducto.Text.Trim
        objEN.Usuario = dtoUSUARIOS.IdLogin
        objEN.IP = dtoUSUARIOS.IP

        objLN.DesaprobarSolicitud(objEN)
    End Sub
    Private Sub rbtSiProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiProducto.CheckedChanged
        Me.txtObservacionProducto.Enabled = False
        Me.txtObservacionProducto.Text = ""
        Me.btnAceptarProducto.Text = "&Aprobar"
        Me.dtpFechaActivacionProducto.Enabled = True
        Me.txtObservacionProducto.Focus()
    End Sub
    Private Sub rbtNoProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoProducto.CheckedChanged
        Me.txtObservacionProducto.Enabled = True
        Me.btnAceptarProducto.Text = "&Desaprobar"
        Me.dtpFechaActivacionProducto.Enabled = False
        Me.txtObservacionProducto.Focus()
    End Sub
    Private Sub btnAceptarProducto_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptarProducto.Click
        Try
            If Me.rbtSiProducto.Checked Then
                Dim strFechaActual As Date = FechaServidor()
                If Date.Compare(strFechaActual.Date.ToShortDateString, Me.dtpFechaActivacionProducto.Text) >= 1 Then
                    MessageBox.Show("La Fecha de Activación " & Format(Me.dtpFechaActivacionProducto.Value, "short date") & " debe ser mayor o igual a la " & Chr(13) & "Fecha Actual " & Format(strFechaActual, "short date"), "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.dtpFechaActivacionProducto.Focus()
                    Return
                End If
            Else
                If Me.txtObservacionProducto.Text.Trim.Length = 0 Then
                    MessageBox.Show("Debe Ingresar Motivo de la Desaprobación.", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtObservacionProducto.Text = ""
                    Me.txtObservacionProducto.Focus()
                    Return
                End If
            End If

            If Me.rbtSiProducto.Checked Then 'aprueba
                Dim strMensaje As String = "¿Está Seguro de Aprobar la Solicitud con:" & Chr(13) & Chr(13) & "Fecha de Activación : " & Me.dtpFechaActivacionProducto.Value.ToShortDateString & "?"
                Dim frm As New frmAprobarProducto
                frm.Cargar(strMensaje, Me.dtpFechaActivacionProducto.Value.ToShortDateString, Me.dgvListaProducto.CurrentRow.Cells("id").Value, _
                           Me.dgvListaProducto.CurrentRow.Cells("idcliente").Value, Me.dgvListaProducto.CurrentRow.Cells("idsubcuenta").Value, _
                           Me.dgvListaProducto.CurrentRow.Cells("idorigen").Value, Me.dgvListaProducto.CurrentRow.Cells("iddestino").Value, _
                           Me.dgvListaProducto.CurrentRow.Cells("idproducto").Value, Me.dgvListaProducto.CurrentRow.Cells("idcontado").Value)
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    Me.ListarSolicitudesPendientesProducto()
                    tabAsignarProducto.SelectedTab = tabAsignarProducto.TabPages("tabListaProducto")
                End If
            Else 'desaprueba
                If MessageBox.Show("¿Está Seguro de Desaprobar la Solicitud?", "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    DesaprobarSolicitudProducto()
                    MessageBox.Show("Solicitud Desaprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitudesPendientesProducto()
                    tabAsignarProducto.SelectedTab = tabAsignarProducto.TabPages("tabListaProducto")
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
#Region "Desactivar Producto"
    Sub ActualizardgvClienteProductoDesactivar(fila As Integer)
        Dim intCliente As Integer = dgvClienteProductoDesactivar.Rows(fila).Cells("id").Value
        ListarProducto(intCliente, Me.dgvClienteProductoDetalleDesactivar)
        Me.btnDesactivarProducto.Enabled = dgvClienteProductoDesactivar.Rows.Count > 0
        Me.btnDesactivarProducto.Enabled = dgvClienteProductoDetalleDesactivar.Rows.Count > 0
        Me.btnDesactivarPoductoContado.Enabled = dgvClienteProductoDesactivar.Rows.Count > 0
        Me.btnDesactivarPoductoContado.Enabled = dgvClienteProductoDetalleDesactivar.Rows.Count > 0
        If dgvClienteProductoDetalleDesactivar.Rows.Count > 0 Then
            Me.btnDesactivarProducto.Enabled = Me.dgvClienteProductoDetalleDesactivar.Rows(0).Cells("idcontado").Value <> 1
            Me.btnDesactivarPoductoContado.Enabled = Me.dgvClienteProductoDetalleDesactivar.Rows(0).Cells("idcontado").Value = 1
        End If
    End Sub
    Private Sub dgvClienteProductoDesactivar_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClienteProductoDesactivar.RowEnter
        ActualizardgvClienteProductoDesactivar(e.RowIndex)
        If Me.dgvClienteProductoDetalleDesactivar.Rows.Count > 0 Then
            Dim intFila As Integer = 0
            Dim intEstado As Integer = dgvClienteProductoDetalleDesactivar.Rows(intFila).Cells("idcontado").Value
            If intEstado = 0 Then
                Me.btnDesactivarProducto.Enabled = True
                Me.btnDesactivarPoductoContado.Enabled = False
            Else
                Me.btnDesactivarProducto.Enabled = False
                Me.btnDesactivarPoductoContado.Enabled = True
            End If
        End If
    End Sub
    Private Sub cboFuncionarioProducto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboFuncionarioProducto.SelectedIndexChanged
        If IsReference(cboFuncionarioProducto.SelectedValue) Then Return
        RemoveHandler dgvClienteProductoDesactivar.RowEnter, AddressOf dgvClienteProductoDesactivar_RowEnter
        CargarCartera(Me.cboFuncionarioProducto.SelectedValue, dgvClienteProductoDesactivar, 1)
        AddHandler dgvClienteProductoDesactivar.RowEnter, AddressOf dgvClienteProductoDesactivar_RowEnter
        If dgvClienteProductoDesactivar.Rows.Count = 0 Then
            Me.btnDesactivarProducto.Enabled = False
            Me.btnDesactivarPoductoContado.Enabled = False
            dgvClienteProductoDetalleDesactivar.DataSource = Nothing
        Else
            ActualizardgvClienteProductoDesactivar(0)
        End If
    End Sub
    Private Sub btnDesactivarProductoDesactivar_Click(sender As System.Object, e As System.EventArgs) Handles btnDesactivarProducto.Click
        Dim frm As New FrmDesactivarProducto
        With dgvClienteProductoDesactivar
            Dim intCliente As Integer = .CurrentRow.Cells("id").Value
            Dim intProducto As Integer = dgvClienteProductoDetalleDesactivar.CurrentRow.Cells("idproducto").Value
            Dim strCliente As String = .CurrentRow.Cells("cliente").Value
            Dim strProducto As String
            Dim blnProductoCuenta As Boolean
            Dim intID As Integer

            With dgvClienteProductoDetalleDesactivar.CurrentRow
                strProducto = .Cells("producto").Value
                blnProductoCuenta = .Cells("subcuenta").Value = "GENERICO" And .Cells("origen").Value.ToString.Trim.Length = 0 And _
                .Cells("destino").Value.ToString.Trim.Length = 0
                intID = .Cells("id").Value
            End With

            frm.Cargar(intCliente, intProducto, strCliente, strProducto, blnProductoCuenta, intID)
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                If dgvClienteProductoDetalleDesactivar.Rows.Count > 0 Then
                    'dgvClienteProductoDesactivar_RowEnter(Nothing, Nothing)
                    ActualizardgvClienteProductoDesactivar(dgvClienteProductoDesactivar.CurrentCell.RowIndex)
                End If
            End If
        End With
    End Sub
#End Region
#Region "Administrador"
    Sub LLenarComboProducto()
        Dim obj As New UtilData_LN
        Dim dt As DataTable

        Dim intCliente As Integer = Me.dgvClienteProducto.CurrentRow.Cells(0).Value
        dt = obj.ListarSubcuenta(intCliente)

        With cboSubcuentaProducto
            .DataSource = Nothing
            .DataSource = dt
            .DisplayMember = "CENTRO_COSTO"
            .ValueMember = "IDCENTRO_COSTO"
        End With

        dt = obj.ListarCiudad()
        With cboOrigenProducto
            .DataSource = Nothing
            .DataSource = dt
            .DisplayMember = "nombre_unidad"
            .ValueMember = "idunidad_agencia"
        End With

        With cboDestinoProducto
            .DataSource = Nothing
            .DataSource = dt.Copy
            .DisplayMember = "nombre_unidad"
            .ValueMember = "idunidad_agencia"
        End With

        dt = obj.ListarProducto
        With cboPProducto
            .DataSource = Nothing
            .DataSource = dt
            .DisplayMember = "procesos"
            .ValueMember = "idprocesos"
        End With

        Me.cboEstadoProducto.SelectedIndex = 1
    End Sub
    Sub LimpiarAprobacionProducto()
        Me.lblCodigoProducto.Text = ""
        Me.lblRazonSocialProducto.Text = ""
        Me.lblFuncionarioProductoAprobacion.Text = ""
        Me.lblObservacionProducto.Text = ""
        Me.rbtSiProducto.Checked = True
        Me.lblProductoAprobacion.Text = ""
        Me.lblSubcuentaAprobacion.Text = ""
        Me.lblOrigenAprobacion.Text = ""
        Me.lblDestinoAprobacion.Text = ""
        Me.lblFechaActivacion.Text = Me.dtpFechaActivacion.Value.ToShortDateString
    End Sub
    Private Sub tabAsignarProducto_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabAsignarProducto.SelectedIndexChanged
        If tabAsignarProducto.SelectedTab Is tabAsignarProducto.TabPages("tabClienteProducto") Then
            blnInicioProducto = False
            ConfigurarDGVClienteProducto()
            ConfigurarDGVClienteProductoDetalle()

            intOperacion = Operacion.Nuevo
            blnInicioProducto = True
            CargarCartera(dtoUSUARIOS.IdLogin, Me.dgvClienteProducto, 1)

        ElseIf tabAsignarProducto.SelectedTab Is tabAsignarProducto.TabPages("tabSolicitudProducto") Then
            intOperacion = Operacion.Nuevo
            Me.lblFechaProducto.Text = Format(Now, "Short Date")
            Me.lblFuncionarioProducto.Text = dtoUSUARIOS.NameLogin

            If Me.dgvClienteProducto.Rows.Count > 0 Then
                Dim strCliente As String = dgvClienteProducto.CurrentRow.Cells("codigo").Value & "  " & dgvClienteProducto.CurrentRow.Cells("cliente").Value
                Me.lblClienteProducto.Text = strCliente.Trim
                If dgvClienteProducto.CurrentRow.Cells("linea_credito").Value = "SI" Then
                    Me.lblMensajeProducto.Text = "LINEA DE CREDITO ACTIVA"
                Else
                    Me.lblMensajeProducto.Text = "NO TIENE LINEA DE CREDITO"
                End If
            End If

            LimpiarSolicitudProducto()
            ConfigurarDGVSolicitudProducto()
            If Me.dgvClienteProducto.Rows.Count > 0 Then
                LLenarComboProducto()
                ListarSolicitudProducto()
            End If
            ActivaDesactivaProducto(-1, dgvSolicitudProducto.Rows.Count)
            Me.btnNuevoProducto.Focus()

        ElseIf tabAsignarProducto.SelectedTab Is tabAsignarProducto.TabPages("tabListaProducto") Then
            ConfigurarDGVListaProducto()
            ListarSolicitudesPendientesProducto()
            If Me.dgvListaProducto.Rows.Count = 0 Then
                'Me.tabAsignarProducto.TabPages.Remove(tabAsignarProducto.TabPages("tabListaProducto"))
                'Me.tabAsignarProducto.TabPages.Remove(tabAsignarProducto.TabPages("tabAprobacionProducto"))
            End If

        ElseIf tabAsignarProducto.SelectedTab Is tabAsignarProducto.TabPages("tabAprobacionProducto") Then
            If dgvListaProducto.Rows.Count > 0 Then
                btnAceptarProducto.Enabled = True
                Me.dtpFechaActivacionProducto.Enabled = True

                Me.rbtSiProducto.Enabled = True
                Me.rbtNoProducto.Enabled = True

                Me.dtpFechaActivacionProducto.Focus()
            Else
                LimpiarAprobacionProducto()
                Me.dtpFechaActivacionProducto.Enabled = False
                btnAceptarProducto.Enabled = False
                Me.rbtSiProducto.Enabled = False
                Me.rbtNoProducto.Enabled = False
            End If

        ElseIf tabAsignarProducto.SelectedTab Is tabAsignarProducto.TabPages("tabDesactivarProducto") Then
            RemoveHandler dgvClienteProductoDesactivar.RowEnter, AddressOf dgvClienteProductoDesactivar_RowEnter
            ConfigurarDGVClienteProductoDesactivar()
            AddHandler dgvClienteProductoDesactivar.RowEnter, AddressOf dgvClienteProductoDesactivar_RowEnter
            ConfigurarDGVClienteProductoDetalleDesactivar()
            ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.cboFuncionarioProducto, "", "", 3, " (SELECCIONE)")
        End If
    End Sub
#End Region
#End Region

#Region "Tipo de Facturacion"
#Region "Configurar Grid"
    Private Sub ConfigurarDGVFacturacion3Aprobacion()
        With dgvFacturacion3Aprobacion
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
            End With
            x += +1
            Dim col_subcuenta As New DataGridViewTextBoxColumn
            With col_subcuenta
                .Name = "subcuenta" : .DataPropertyName = "subcuenta"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subcuenta"
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
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
            End With

            .Columns.AddRange(col_id, col_idsubcuenta, col_subcuenta, col_idcargo, col_cargo, col_estado)
        End With
    End Sub
    Private Sub ConfigurarDGVClienteFacturacionDetalle()
        With dgvClienteFacturacionDetalle
            'utilitario.FormatDataGridView(dgvLista)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_tipo_facturacion As New DataGridViewTextBoxColumn
            With col_tipo_facturacion
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Facturacion"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_inicio As New DataGridViewTextBoxColumn
            With col_fecha_inicio
                .Name = "fecha_inicio" : .DataPropertyName = "fecha_inicio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Inicio"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_fin As New DataGridViewTextBoxColumn
            With col_fecha_fin
                .Name = "fecha_fin" : .DataPropertyName = "fecha_fin"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Fin"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            .Columns.AddRange(col_tipo_facturacion, col_fecha_inicio, col_fecha_fin)
        End With
    End Sub
    Private Sub ConfigurarDGVClienteFacturacion()
        With dgvClienteFacturacion
            Cls_Utilitarios.FormatDataGridView(dgvClienteFacturacion)
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
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
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
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            x += +1
            .Columns.AddRange(col_id, col_codigo, col_cliente)
        End With
    End Sub
    Private Sub ConfigurarDGVSolicitudFacturacion()
        With dgvSolicitudFacturacion
            Cls_Utilitarios.FormatDataGridView(dgvSolicitudFacturacion)
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
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
            End With
            x += +1
            Dim col_tipo_facturacion1 As New DataGridViewTextBoxColumn
            With col_tipo_facturacion1
                .Name = "tipo_facturacion1" : .DataPropertyName = "tipo_facturacion1"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Facturacion"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
            End With
            x += +1
            Dim col_aprobacion As New DataGridViewTextBoxColumn
            With col_aprobacion
                .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aprobación"
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
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Observacion"
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id"
            End With
            x += +1
            Dim col_idestado As New DataGridViewTextBoxColumn
            With col_idestado
                .Name = "idestado" : .DataPropertyName = "idestado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id estado"
            End With
            x += +1
            Dim col_tipo_facturacion As New DataGridViewTextBoxColumn
            With col_tipo_facturacion
                .Name = "tipo_facturacion" : .DataPropertyName = "tipo_facturacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "tipo_facturacion"
            End With
            x += +1
            Dim col_contacto As New DataGridViewTextBoxColumn
            With col_contacto
                .Name = "contacto" : .DataPropertyName = "contacto"
                .DisplayIndex = x : .Visible = False : .HeaderText = "contacto"
            End With
            x += +1
            Dim col_pendiente As New DataGridViewTextBoxColumn
            With col_pendiente
                .Name = "pendiente" : .DataPropertyName = "pendiente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Pendiente"
            End With
            x += +1
            Dim col_orden_compra As New DataGridViewTextBoxColumn
            With col_orden_compra
                .Name = "orden_compra" : .DataPropertyName = "orden_compra"
                .DisplayIndex = x : .Visible = False : .HeaderText = "orden_compra"
            End With
            x += +1
            Dim col_liquidacion_documento As New DataGridViewTextBoxColumn
            With col_liquidacion_documento
                .Name = "liquidacion_documento" : .DataPropertyName = "liquidacion_documento"
                .DisplayIndex = x : .Visible = False : .HeaderText = "liquidacion_documento"
            End With
            x += +1
            Dim col_forma_facturacion As New DataGridViewTextBoxColumn
            With col_forma_facturacion
                .Name = "forma_facturacion" : .DataPropertyName = "forma_facturacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "forma_facturacion"
            End With

            .Columns.AddRange(col_solicitud, col_fecha, col_cliente, col_tipo_facturacion1, col_estado, col_aprobacion, col_desaprobacion, col_anulacion, _
                              col_observacion, col_id, col_idestado, col_tipo_facturacion, col_contacto, col_orden_compra, col_liquidacion_documento, col_forma_facturacion)
        End With
    End Sub
    Private Sub ConfigurarDGVListaFacturacion()
        With dgvListaFacturacion
            Cls_Utilitarios.FormatDataGridView(dgvListaFacturacion)
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
            Dim col_idcliente As New DataGridViewTextBoxColumn
            With col_idcliente
                .Name = "idcliente" : .DataPropertyName = "idcliente"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id Cliente"
            End With

            x += +1
            Dim col_solicitante As New DataGridViewTextBoxColumn
            With col_solicitante
                .Name = "solicitante" : .DataPropertyName = "solicitante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Solicitante"
            End With
            x += +1
            Dim col_usuario_solicitud As New DataGridViewTextBoxColumn
            With col_usuario_solicitud
                .Name = "usuario_solicitud" : .DataPropertyName = "usuario_solicitud"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id Usuario Solicitud"
            End With
            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Observación"
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "ID"
            End With
            x += +1
            Dim col_idtipo_facturacion As New DataGridViewTextBoxColumn
            With col_idtipo_facturacion
                .Name = "idtipo_facturacion" : .DataPropertyName = "idtipo_facturacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo_facturacion"
            End With
            x += +1
            Dim col_tipo_facturacion As New DataGridViewTextBoxColumn
            With col_tipo_facturacion
                .Name = "tipo_facturacion" : .DataPropertyName = "tipo_facturacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Facturación"
            End With
            x += +1
            Dim col_contacto As New DataGridViewTextBoxColumn
            With col_contacto
                .Name = "contacto" : .DataPropertyName = "contacto"
                .DisplayIndex = x : .Visible = False : .HeaderText = "contacto"
            End With
            x += +1
            Dim col_orden_compra As New DataGridViewTextBoxColumn
            With col_orden_compra
                .Name = "orden_compra" : .DataPropertyName = "orden_compra"
                .DisplayIndex = x : .Visible = False : .HeaderText = "orden_compra"
            End With
            x += +1
            Dim col_liquidacion_documento As New DataGridViewTextBoxColumn
            With col_liquidacion_documento
                .Name = "liquidacion_documento" : .DataPropertyName = "liquidacion_documento"
                .DisplayIndex = x : .Visible = False : .HeaderText = "liquidacion_documento"
            End With
            x += +1
            Dim col_idcontacto As New DataGridViewTextBoxColumn
            With col_idcontacto
                .Name = "idcontacto" : .DataPropertyName = "idcontacto"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcontacto"
            End With

            .Columns.AddRange(col_solicitud, col_fecha, col_codigo, col_cliente, col_idcliente, col_solicitante, _
                              col_usuario_solicitud, col_observacion, col_id, col_tipo_facturacion, col_idtipo_facturacion, _
                              col_contacto, col_orden_compra, col_liquidacion_documento, col_idcontacto)
        End With
    End Sub
    Private Sub ConfigurarDGVFacturacion3()
        With dgvFacturacion3
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
            End With
            x += +1
            Dim col_subcuenta As New DataGridViewTextBoxColumn
            With col_subcuenta
                .Name = "subcuenta" : .DataPropertyName = "subcuenta"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Subcuenta"
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
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "estado"
            End With

            .Columns.AddRange(col_id, col_idsubcuenta, col_subcuenta, col_idcargo, col_cargo, col_estado)
        End With
    End Sub
#End Region
#Region "Clientes"
    Sub ListarTipoFacturacion(cliente As Integer, dgv As DataGridView)
        Dim obj As New Cls_ClienteTipoFacturacion_LN
        Dim dt As DataTable = obj.ListarTipoFacturacion(cliente)
        dgv.DataSource = dt
    End Sub
#End Region
#End Region

#Region "Condicion Credito"
    Private Sub ConfigurarDGVListaCondicion()
        With dgvListaCondicion
            Cls_Utilitarios.FormatDataGridView(dgvListaCondicion)
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
            Dim col_idcliente As New DataGridViewTextBoxColumn
            With col_idcliente
                .Name = "idcliente" : .DataPropertyName = "idcliente"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id Cliente"
            End With

            x += +1
            Dim col_solicitante As New DataGridViewTextBoxColumn
            With col_solicitante
                .Name = "solicitante" : .DataPropertyName = "solicitante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Solicitante"
            End With
            x += +1
            Dim col_usuario_solicitud As New DataGridViewTextBoxColumn
            With col_usuario_solicitud
                .Name = "usuario_solicitud" : .DataPropertyName = "usuario_solicitud"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id Usuario Solicitud"
            End With
            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Observación"
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "ID"
            End With
            x += +1
            Dim col_idcondicion As New DataGridViewTextBoxColumn
            With col_idcondicion
                .Name = "idcondicion" : .DataPropertyName = "idcondicion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcondicion"
            End With
            x += +1
            Dim col_condicion As New DataGridViewTextBoxColumn
            With col_condicion
                .Name = "condicion" : .DataPropertyName = "condicion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Condición Crédito"
            End With

            .Columns.AddRange(col_solicitud, col_fecha, col_codigo, col_cliente, col_idcliente, col_solicitante, _
                              col_usuario_solicitud, col_observacion, col_id, col_condicion, col_idcondicion)
        End With
    End Sub
    Sub ListarSolicitudesPendientesCondicion()
        Try
            Dim obj As New Cls_LineaCredito_LN
            Dim objEN As New Cls_LineaCredito_EN

            objEN.Estado = Estado.Pendiente
            dgvListaCondicion.DataSource = obj.ListarSolicitudCondicionCredito(objEN.Estado)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Fuera de Zona"
#Region "Configurar Grid"

#End Region
#Region "Clientes"
#End Region
#Region "Solicitud"
#End Region
#Region "Lista"

#End Region
#Region "Aprobacion"
#End Region
#Region "Administrador"
#End Region
#End Region

#Region "Gestion de Clientes"
#Region "Administrador"
    Sub ControlaAcceso()
        'Me.tabGestionCliente.TabPages.Remove(tabGestionCliente.TabPages("tabcliente")) 'maestro de clientes
        'Me.tabGestionCliente.TabPages.Remove(tabGestionCliente.TabPages("tabzona"))
        If Not Acceso.SiRol(G_Rol, Me, 26) Then 'cliente
            Me.tabGestionCliente.TabPages.Remove(tabGestionCliente.TabPages("tabcliente"))
        Else
            If Not Acceso.SiRol(G_Rol, Me, 23) Then 'ficha cliente
                Me.tabClientes.TabPages.Remove(tabClientes.TabPages("tabficha"))
            End If
            If Not Acceso.SiRol(G_Rol, Me, 24) Then 'ficha cliente
                Me.tabClientes.TabPages.Remove(tabClientes.TabPages("tabcontacto"))
            End If
            If Not Acceso.SiRol(G_Rol, Me, 25) Then 'ficha cliente
                Me.tabClientes.TabPages.Remove(tabClientes.TabPages("tabdireccion"))
            End If
        End If
        If Not Acceso.SiRol(G_Rol, Me, 2) Then 'cartera
            Me.tabGestionCliente.TabPages.Remove(tabGestionCliente.TabPages("tabcartera"))
        Else
            If Not Acceso.SiRol(G_Rol, Me, 3) Then 'solicitud cartera
                Me.tabGestionCartera.TabPages.Remove(tabGestionCartera.TabPages("tabSolicitudCartera"))
            End If
            If Not Acceso.SiRol(G_Rol, Me, 4) Then 'lista cartera
                Me.tabGestionCartera.TabPages.Remove(tabGestionCartera.TabPages("tabListaCartera"))
            End If
            If Not Acceso.SiRol(G_Rol, Me, 5) Then 'aprobacion cartera
                Me.tabGestionCartera.TabPages.Remove(tabGestionCartera.TabPages("tabAprobacionCartera"))
            End If
            If Not Acceso.SiRol(G_Rol, Me, 6) Then 'transferencia cartera
                Me.tabGestionCartera.TabPages.Remove(tabGestionCartera.TabPages("tabTransferenciaCartera"))
            End If
        End If
        If Not Acceso.SiRol(G_Rol, Me, 7) Then 'credito
            Me.tabGestionCliente.TabPages.Remove(tabGestionCliente.TabPages("tabcredito"))
        Else
            If Not Acceso.SiRol(G_Rol, Me, 8) Then 'cliente credito
                RemoveHandler tabLineaCredito.SelectedIndexChanged, AddressOf tabLineaCredito_SelectedIndexChanged
                Me.tabLineaCredito.TabPages.Remove(tabLineaCredito.TabPages("tabClienteCredito"))
                AddHandler tabLineaCredito.SelectedIndexChanged, AddressOf tabLineaCredito_SelectedIndexChanged
            End If
            If Not Acceso.SiRol(G_Rol, Me, 9) Then 'solicitud credito
                Me.tabLineaCredito.TabPages.Remove(tabLineaCredito.TabPages("tabSolicitudCredito"))
            End If

            If Acceso.SiRol(G_Rol, Me, 10, 1) Then 'lista credito
                Me.rbtPorPreaprobar.Checked = True
                Me.rbtPorPreaprobar.Visible = True : Me.rbtPorAprobar.Visible = True : Me.rbtAprobadas.Visible = True : Me.rbtRechazadas.Visible = True
                Me.lblTituloCredito.Text = "Solicitudes Pendientes de Aprobación"
            ElseIf Acceso.SiRol(G_Rol, Me, 10, 2) Then 'lista credito
                ConfigurarDGVListaCredito(1)
                Me.rbtPorAprobar.Visible = False : Me.rbtAprobadas.Visible = False : Me.rbtRechazadas.Visible = False
                Me.rbtPorPreaprobar.Checked = True
                Me.lblTituloCredito.Text = "Solicitudes Pendientes de Preaprobación"
            ElseIf Acceso.SiRol(G_Rol, Me, 10, 3) Then 'lista credito
                ConfigurarDGVListaCredito(2)
                Me.rbtPorAprobar.Checked = True
                Me.rbtPorPreaprobar.Visible = True : Me.rbtPorAprobar.Visible = True : Me.rbtAprobadas.Visible = True : Me.rbtRechazadas.Visible = True
                Me.lblTituloCredito.Text = "Solicitudes Pendientes de Aprobación"
            Else
                Me.tabLineaCredito.TabPages.Remove(tabLineaCredito.TabPages("tabListaCredito"))
            End If

            If Not Acceso.SiRol(G_Rol, Me, 11) Then 'aprobacion credito
                Me.tabLineaCredito.TabPages.Remove(tabLineaCredito.TabPages("tabAprobacionCredito"))
            End If
            If Not Acceso.SiRol(G_Rol, Me, 29) Then 'aprobacion credito
                Me.tabLineaCredito.TabPages.Remove(tabLineaCredito.TabPages("tabOperacionCredito"))
            End If
        End If
        If Not Acceso.SiRol(G_Rol, Me, 12) Then 'producto
            Me.tabGestionCliente.TabPages.Remove(tabGestionCliente.TabPages("tabproducto"))
        Else
            If Not Acceso.SiRol(G_Rol, Me, 13) Then 'cliente producto
                Me.tabAsignarProducto.TabPages.Remove(tabAsignarProducto.TabPages("tabClienteProducto"))
            End If
            If Not Acceso.SiRol(G_Rol, Me, 14) Then 'solicitud producto
                Me.tabAsignarProducto.TabPages.Remove(tabAsignarProducto.TabPages("tabSolicitudProducto"))
            End If
            If Not Acceso.SiRol(G_Rol, Me, 15) Then 'lista producto
                Me.tabAsignarProducto.TabPages.Remove(tabAsignarProducto.TabPages("tabListaProducto"))
            End If
            If Not Acceso.SiRol(G_Rol, Me, 16) Then 'aprobacion producto
                Me.tabAsignarProducto.TabPages.Remove(tabAsignarProducto.TabPages("tabAprobacionProducto"))
            End If
            If Not Acceso.SiRol(G_Rol, Me, 17) Then 'desactivar producto
                Me.tabAsignarProducto.TabPages.Remove(tabAsignarProducto.TabPages("tabDesactivarProducto"))
            End If
        End If
        If Not Acceso.SiRol(G_Rol, Me, 18) Then 'tipo de facturacion
            Me.tabGestionCliente.TabPages.Remove(tabGestionCliente.TabPages("tabfacturacion"))
        Else
            If Not Acceso.SiRol(G_Rol, Me, 19) Then 'cliente facturacion
                Me.tabTipoFacturacion.TabPages.Remove(tabTipoFacturacion.TabPages("tabClienteFacturacion"))
            End If
            If Not Acceso.SiRol(G_Rol, Me, 20) Then 'solicitud facturacion
                Me.tabTipoFacturacion.TabPages.Remove(tabTipoFacturacion.TabPages("tabSolicitudFacturacion"))
            End If
            If Not Acceso.SiRol(G_Rol, Me, 21) Then 'lista facturacion
                Me.tabTipoFacturacion.TabPages.Remove(tabTipoFacturacion.TabPages("tabListaFacturacion"))
            End If
            If Not Acceso.SiRol(G_Rol, Me, 22) Then 'aprobacion facturacion
                Me.tabTipoFacturacion.TabPages.Remove(tabTipoFacturacion.TabPages("tabAprobacionFacturacion"))
            End If
        End If
        If Not Acceso.SiRol(G_Rol, Me, 30) Then 'condicion credito
            Me.tabGestionCliente.TabPages.Remove(tabGestionCliente.TabPages("tabcondicion"))
        Else
            If Not Acceso.SiRol(G_Rol, Me, 31) Then 'lista facturacion
                Me.tabCondicionCredito.TabPages.Remove(tabCondicionCredito.TabPages("tabListaCondicion"))
            End If
            If Not Acceso.SiRol(G_Rol, Me, 32) Then 'aprobacion facturacion
                Me.tabCondicionCredito.TabPages.Remove(tabTipoFacturacion.TabPages("tabAprobacionCondicion"))
            End If
        End If
        If Not Acceso.SiRol(G_Rol, Me, 39) Then 'cargo
            Me.tabGestionCliente.TabPages.Remove(tabGestionCliente.TabPages("tabcargo"))
        Else
            If Not Acceso.SiRol(G_Rol, Me, 40) Then 'cliente producto
                Me.tabCargos.TabPages.Remove(tabCargos.TabPages("tabClienteCargo"))
            End If
            If Not Acceso.SiRol(G_Rol, Me, 43) Then 'solicitud producto
                Me.tabCargos.TabPages.Remove(tabCargos.TabPages("tabSolicitudCargo"))
            End If
            If Not Acceso.SiRol(G_Rol, Me, 41) Then 'lista producto
                Me.tabCargos.TabPages.Remove(tabCargos.TabPages("tabListaCargo"))
            End If
            If Not Acceso.SiRol(G_Rol, Me, 42) Then 'aprobacion producto
                Me.tabCargos.TabPages.Remove(tabCargos.TabPages("tabAprobacionCargo"))
            End If
        End If

        Dim blnResponsable As Boolean = Acceso.SiRol(G_Rol, Me, 27, 1)
        If Not blnResponsable Then
            Me.ListarSolicitudesPendientesCondicion()
            If Me.dgvListaCondicion.Rows.Count <= 1 Then
                Me.tabGestionCliente.TabPages.Remove(tabGestionCliente.TabPages("tabcondicion"))
            End If
        End If

        Dim strFicha As String = tabGestionCliente.TabPages(0).Name
        If strFicha = "tabCliente" Then
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
        Else
            tabGestionCartera_SelectedIndexChanged(Nothing, Nothing)
        End If


        Return
        If Not Acceso.SiRol(G_Rol, Me, 1) Then
            Me.tabGestionCliente.TabPages.Remove(tabGestionCliente.TabPages("tabcliente"))
            Me.tabGestionCliente.TabPages.Remove(tabGestionCliente.TabPages("tabcredito"))
            Me.tabGestionCliente.TabPages.Remove(tabGestionCliente.TabPages("tabproducto"))
            Me.tabGestionCliente.TabPages.Remove(tabGestionCliente.TabPages("tabfacturacion"))
            Me.tabGestionCliente.TabPages.Remove(tabGestionCliente.TabPages("tabconsulta"))
        End If

        If Acceso.SiRol(G_Rol, Me, 1, 3) Then
            Me.tabGestionCartera.TabPages.Remove(tabGestionCartera.TabPages("tabListaCartera"))
            Me.tabGestionCartera.TabPages.Remove(tabGestionCartera.TabPages("tabAprobacionCartera"))
            Me.tabGestionCartera.TabPages.Remove(tabGestionCartera.TabPages("tabTransferenciaCartera"))

            Me.tabAsignarProducto.TabPages.Remove(tabAsignarProducto.TabPages("tabListaProducto"))
            Me.tabAsignarProducto.TabPages.Remove(tabAsignarProducto.TabPages("tabAprobacionProducto"))
            Me.tabAsignarProducto.TabPages.Remove(tabAsignarProducto.TabPages("tabDesactivarProducto"))

            Me.tabLineaCredito.TabPages.Remove(tabLineaCredito.TabPages("tabListaCredito"))
            Me.tabLineaCredito.TabPages.Remove(tabLineaCredito.TabPages("tabAprobacionCredito"))

            tabGestionCartera_SelectedIndexChanged(Nothing, Nothing)

        ElseIf Acceso.SiRol(G_Rol, Me, 1, 2) Then
            Me.tabGestionCartera.TabPages.Remove(tabGestionCartera.TabPages("tabSolicitudCartera"))

            Me.tabAsignarProducto.TabPages.Remove(tabAsignarProducto.TabPages("tabClienteProducto"))
            Me.tabAsignarProducto.TabPages.Remove(tabAsignarProducto.TabPages("tabSolicitudProducto"))

            Me.tabLineaCredito.TabPages.Remove(tabLineaCredito.TabPages("tabClienteCredito"))
            Me.tabLineaCredito.TabPages.Remove(tabLineaCredito.TabPages("tabSolicitudCredito"))

            tabGestionCartera_SelectedIndexChanged(Nothing, Nothing)
        End If

    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim flat As Boolean = True
        If MyClass.ModifierKeys And Keys.Control Then
            If msg.WParam.ToInt32 = Keys.Enter Then
                If Me.txtSustentoProducto.Focused Then
                    flat = MyBase.ProcessCmdKey(msg, KeyData)
                End If
            ElseIf msg.WParam.ToInt32 = Keys.C Then
                flat = MyBase.ProcessCmdKey(msg, KeyData)
            End If
        ElseIf msg.WParam.ToInt32 = Keys.Enter Then
            If tabGestionCliente.SelectedTab Is tabGestionCliente.TabPages("tabcliente") Then 'cliente
                If tabClientes.SelectedTab Is tabClientes.TabPages("tabficha") Then
                    If Me.cboTipoPersona.Focused Or Me.txtCliente.Focused Or Me.txtAPCliente.Focused Or Me.txtAMCliente.Focused Or Me.cboTipoDocumento.Focused Or _
                        Me.txtNumero.Focused Or Me.txtGerenteGeneral.Focused Or Me.txtRepresentanteLegal.Focused Or Me.txtPaginaWeb.Focused Or _
                        Me.dtpFechaNacimiento.Focused Or Me.rbtMasculino.Focused Or Me.rbtFemenino.Focused Or Me.txtEmail.Focused Or _
                        Me.dtpFechaIngreso.Focused Or Me.chkAgenteRetencion.Focused Or Me.chkBaseArticulo.Focused Or Me.chkPagoPostfacturacion.Focused Or Me.chkConsignado.Focused Or Me.cboRubroCliente.Focused Or Me.cboClasificacionCliente.Focused Or Me.cboFuente.Focused Or _
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
                ElseIf tabClientes.SelectedTab Is tabClientes.TabPages("tabcontacto") Then
                    If Me.cboSubcuentaContacto.Focused Or Me.cboCargoContacto.Focused Or Me.cboTipoDocumentoContacto.Focused Or Me.txtNumeroContacto.Focused Or _
                       Me.txtNombresContacto.Focused Or Me.txtAPContacto.Focused Or Me.txtAMContacto.Focused Or Me.txtEmailContacto.Focused Or _
                       Me.rbtMasculinoContacto.Focused Or Me.rbtFemeninoContacto.Focused Or Me.chkActivoContacto.Focused Then
                        SendKeys.Send(vbTab)
                    Else
                        flat = MyBase.ProcessCmdKey(msg, KeyData)
                    End If
                ElseIf tabClientes.SelectedTab Is tabClientes.TabPages("tabdireccion") Then
                    If Me.cboTipoDireccion.Focused Or Me.CboDepartamento.Focused Or Me.CboProvincia.Focused Or Me.CboDistrito.Focused Or Me.CboVia.Focused Or _
                        Me.TxtVia.Focused Or Me.TxtNumero2.Focused Or Me.TxtManzana.Focused Or Me.TxtLote.Focused Or Me.CboNivel.Focused Or Me.TxtNivel.Focused Or _
                        Me.CboZona.Focused Or Me.TxtZona.Focused Or Me.CboClasificacion.Focused Or Me.TxtClasificacion.Focused Or Me.TxtReferencia.Focused Or _
                        Me.chkDireccionFacturacion.Focused Or Me.chkActivoDireccion.Focused Then
                        SendKeys.Send(vbTab)
                    Else
                        flat = MyBase.ProcessCmdKey(msg, KeyData)
                    End If
                End If
            ElseIf tabGestionCliente.SelectedTab Is tabGestionCliente.TabPages("tabcartera") Then 'cartera
                If tabGestionCartera.SelectedTab Is tabGestionCartera.TabPages("tabsolicitudcartera") Then
                    If Me.txtSustento.Focused Then
                        SendKeys.Send(vbTab)
                    ElseIf Me.txtRuc.Focused Then
                        If Me.txtRuc.Text.Trim.Length > 0 Then
                            ObtieneCliente(Me.txtRuc.Text.Trim)
                        Else
                            SendKeys.Send(vbTab)
                        End If
                    Else
                        flat = MyBase.ProcessCmdKey(msg, KeyData)
                    End If
                End If
            ElseIf tabGestionCliente.SelectedTab Is tabGestionCliente.TabPages("tabcredito") Then 'credito
                If tabLineaCredito.SelectedTab Is tabLineaCredito.TabPages("tabsolicitudcredito") Then
                    If Me.txtMontoSolicitadoCredito.Focused Or cboComercialCredito.Focused Or cboConceptoCredito.Focused Or cboConceptoCredito.Focused Or cboCondicionCredito.Focused Or _
                    Me.rbtDiaSemana.Focused Or Me.rbtDiaMes.Focused Or Me.lstDia.Focused Or Me.dtpDia1.Focused Or Me.chkDia1.Focused Or _
                    Me.dtpDia2.Focused Or Me.chkDia2.Focused Or Me.dtpDia3.Focused Or Me.chkDia3.Focused Or Me.dtpHora1.Focused Or Me.dtpHora2.Focused Or _
                    Me.cboProductoCredito.Focused Or Me.cboTipoFacturacionCredito.Focused Or cboPagoCredito.Focused Or cboContactoFacturacionCredito.Focused Or _
                    chkOrdenCompraCredito.Focused Or chkLiquidacionDocumentoCredito.Focused Or _
                    Me.cboFormaPago.Focused Or Me.dtpFechaCorte.Focused Or _
                    Me.rbtDiaSemanaFacturacion.Focused Or Me.rbtDiaMesFacturacion.Focused Or Me.lstDiaFacturacion.Focused Or Me.dtpDia1Facturacion.Focused Or Me.chkDia1Facturacion.Focused Or _
                    Me.dtpDia2Facturacion.Focused Or Me.chkDia2Facturacion.Focused Or Me.dtpDia3Facturacion.Focused Or Me.chkDia3Facturacion.Focused Or Me.dtpHora1Facturacion.Focused Or Me.dtpHora2Facturacion.Focused Then
                        SendKeys.Send(vbTab)
                    Else
                        flat = MyBase.ProcessCmdKey(msg, KeyData)
                    End If
                ElseIf tabLineaCredito.SelectedTab Is tabLineaCredito.TabPages("tabaprobacioncredito") Then
                    If Me.txtMontoPreaprobado.Focused Or Me.txtMontoOtorgado.Focused Then
                        Me.btnAceptarCredito.Focus()
                    Else
                        flat = MyBase.ProcessCmdKey(msg, KeyData)
                    End If
                ElseIf tabLineaCredito.SelectedTab Is tabLineaCredito.TabPages("taboperacioncredito") Then
                    If Me.txtNumeroDocumentoCredito.Focused Or Me.txtRazonSocialCredito.Focused Then
                        Dim intOpcion As Integer = IIf(Me.txtNumeroDocumentoCredito.Focused, 1, 2)
                        Dim strCliente As String = IIf(Me.txtNumeroDocumentoCredito.Focused, Me.txtNumeroDocumentoCredito.Text.Trim, Me.txtRazonSocialCredito.Text.Trim)
                        Dim intUsuario As Integer = 0
                        If Me.cboFuncionarioCredito.Tag = "*" Then
                            intUsuario = dtoUSUARIOS.IdLogin
                        End If
                        BuscarClienteCredito(strCliente.Trim, intOpcion, intUsuario)
                    End If
                End If
            ElseIf tabGestionCliente.SelectedTab Is tabGestionCliente.TabPages("tabproducto") Then 'producto
                If tabAsignarProducto.SelectedTab Is tabAsignarProducto.TabPages("tabsolicitudproducto") Then
                    If Me.cboSubcuentaProducto.Focused Or Me.cboOrigenProducto.Focused Or Me.cboDestinoProducto.Focused Or Me.cboPProducto.Focused Or _
                       Me.chkContadoProducto.Focused Or Me.txtSustentoProducto.Focused Then
                        SendKeys.Send(vbTab)
                    Else
                        flat = MyBase.ProcessCmdKey(msg, KeyData)
                    End If
                End If
            ElseIf tabGestionCliente.SelectedTab Is tabGestionCliente.TabPages("tabfacturacion") Then 'tipo de facturacion
                If tabTipoFacturacion.SelectedTab Is tabTipoFacturacion.TabPages("tabsolicitudfacturacion") Then
                    If Me.cboTipoFacturacionSolicitud.Focused Or Me.txtObservacionFacturacion.Focused Then
                        SendKeys.Send(vbTab)
                    Else
                        flat = MyBase.ProcessCmdKey(msg, KeyData)
                    End If
                End If
            ElseIf tabGestionCliente.SelectedTab Is tabGestionCliente.TabPages("tabconsulta") Then 'consulta
                If Me.txtNumeroDocumentoConsulta.Focused Or Me.txtRazonSocialConsulta.Focused Then
                    Dim intOpcion As Integer = IIf(Me.txtNumeroDocumentoConsulta.Focused, 1, 2)
                    Dim strCliente As String = IIf(Me.txtNumeroDocumentoConsulta.Focused, Me.txtNumeroDocumentoConsulta.Text.Trim, Me.txtRazonSocialConsulta.Text.Trim)
                    Dim intUsuario As Integer = 0
                    If Me.cboFuncionarioConsulta.Tag = "*" Then
                        intUsuario = dtoUSUARIOS.IdLogin
                    End If
                    BuscarClienteConsulta(strCliente.Trim, intOpcion, intUsuario)
                End If
            End If
        Else
            flat = MyBase.ProcessCmdKey(msg, KeyData)
        End If
        Return flat
    End Function
    Private Sub FrmgestionCliente_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        intOperacion = Operacion.Nuevo
        Dim tip As New ToolTip
        tip.ShowAlways = True
        tip.SetToolTip(Me.btnCondicionCredito, "Condición de Crédito")
        ControlaAcceso()
    End Sub
    Private Sub tabGestionCliente_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabGestionCliente.SelectedIndexChanged
        If tabGestionCliente.SelectedTab.Name.ToLower = "tabcliente" Then
            Me.LimpiarContacto()
            Me.dgvContactos.DataSource = Nothing
            Me.ActivaDesactivaContacto(-1, 0)
            Me.LimpiarDireccion()
            Me.dgvDirecciones.DataSource = Nothing
            Me.ActivaDesactivaDireccion(-1, 0)
            tabClientes_SelectedIndexChanged(Nothing, Nothing)
        ElseIf tabGestionCliente.SelectedTab.Name.ToLower = "tabcartera" Then
            tabGestionCartera_SelectedIndexChanged(Nothing, Nothing)
        ElseIf tabGestionCliente.SelectedTab.Name.ToLower = "tabproducto" Then
            tabAsignarProducto_SelectedIndexChanged(Nothing, Nothing)
        ElseIf tabGestionCliente.SelectedTab.Name.ToLower = "tabcredito" Then
            tabLineaCredito_SelectedIndexChanged(Nothing, Nothing)
        ElseIf tabGestionCliente.SelectedTab.Name.ToLower = "tabfacturacion" Then
            tabTipoFacturacion_SelectedIndexChanged(Nothing, Nothing)
        ElseIf tabGestionCliente.SelectedTab.Name.ToLower = "tabcondicion" Then
            tabCondicionCredito_SelectedIndexChanged(Nothing, Nothing)
        ElseIf tabGestionCliente.SelectedTab.Name.ToLower = "tabcargo" Then
            Me.cboTipoSolicitudCargo.SelectedIndex = 0
            tabCargos_SelectedIndexChanged(Nothing, Nothing)
        ElseIf tabGestionCliente.SelectedTab.Name.ToLower = "tabconsulta" Then
            InicioConsulta()
        ElseIf tabGestionCliente.SelectedTab.Name.ToLower = "tabreporte" Then
            ConfigurarDGVTFCargo()
            ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.cboResponsableReporte, "", "", 3, " (SELECCIONE)")
            Dim blnResponsable As Boolean = Acceso.SiRol(G_Rol, Me, 27, 1)
            If blnResponsable Then
                Me.cboResponsableReporte.SelectedValue = dtoUSUARIOS.IdLogin
                Me.cboResponsableReporte.Enabled = False
            Else
                Me.cboResponsableReporte.SelectedValue = 0
                Me.cboResponsableReporte.Enabled = True
            End If
        End If
    End Sub
    Sub CargarCartera(funcionario As Integer, dgv As DataGridView, Optional credito As Integer = 0)
        Dim obj As New Cls_ClienteCarteraFuncionario_LN
        Dim dt As DataTable = obj.ListarCartera(funcionario, credito)
        dgv.DataSource = dt
    End Sub
#End Region
#End Region

    Private Sub dgvListaCredito_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvListaCredito.DoubleClick
        If Me.dgvListaCredito.Rows.Count > 0 Then
            Me.tabLineaCredito.SelectedTab = Me.tabLineaCredito.TabPages("tabAprobacionCredito")
            Me.tabLineaCredito_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Sub ControlaAprobacion(opcion As Integer)
        If dgvListaCredito.Rows.Count > 0 Then
            pnlAprobacionCredito.Visible = True
            Me.txtMontoOtorgado.ReadOnly = False
            If Me.rbtPorAprobar.Checked Then
                If Acceso.SiRol(G_Rol, Me, 38, 2) Then 'aprobacion credito
                    btnAceptarCredito.Enabled = True
                Else
                    btnAceptarCredito.Enabled = False
                End If
            Else
                btnAceptarCredito.Enabled = True
            End If

            'btnAceptarCredito.Enabled = True
            Me.rbtSiCredito.Enabled = True
            Me.rbtNoCredito.Enabled = True
            If opcion = 1 Then
                LblAprobar.Text = "Preaprobar"
                pnlPreaprobacion.Visible = True
                pnlAprobacion.Visible = False
                pnlSituacionFinal.Visible = False
                Me.txtMontoPreaprobado.Focus()
            ElseIf opcion = 2 Then
                LblAprobar.Text = "Aprobar"
                pnlAprobacion.Visible = True
                pnlSituacionFinal.Visible = True
                pnlPreaprobacion.Visible = False
                Me.txtMontoOtorgado.Focus()
            ElseIf opcion = 3 Then
                pnlAprobacionCredito.Visible = False
                Me.txtMontoOtorgado.ReadOnly = True
            ElseIf opcion = 4 Then
                pnlAprobacionCredito.Visible = False
                Me.txtMontoOtorgado.ReadOnly = True
            End If
        End If
    End Sub

    Private Sub dgvListaCredito_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaCredito.RowEnter
        With dgvListaCredito
            'Dim intEstado As Integer = IIf(Me.rbtPorPreaprobar.Checked, 1, 2)
            Dim intEstado As Integer
            If Me.rbtPorPreaprobar.Checked Then
                intEstado = 1
            ElseIf Me.rbtPorAprobar.Checked Then
                intEstado = 2
            ElseIf Me.rbtAprobadas.Checked Then
                intEstado = 3
            Else
                intEstado = 4
            End If
            If .Rows.Count > 0 Then
                Dim row As DataGridViewRow = .Rows(e.RowIndex)
                Me.lblCodigoCredito.Text = row.Cells("codigo").Value
                Me.lblRazonSocialCredito.Text = row.Cells("cliente").Value
                lblFuncionarioCreditoAprobacion.Text = row.Cells("solicitante").Value

                Me.lblProductoCredito.Text = row.Cells("producto").Value
                Me.lblContadoCredito.Text = IIf(row.Cells("contado").Value = 0, "NO", "SI")

                Me.lblTipoFacturacionCredito.Text = row.Cells("tipo_facturacion").Value

                Me.LblCondicion.Text = dtoAprobacion.CondicionPago(row.Cells("periodo_pago").Value)
                Dim s As String = ""
                If row.Cells("fecha1").Value > 0 Then
                    Me.LblPeriodo.Text = "Día de Mes"
                    If row.Cells("fecha1").Value > 1 Then
                        s &= row.Cells("fecha1").Value & ","
                    End If
                    If row.Cells("fecha2").Value > 1 Then
                        s &= row.Cells("fecha2").Value & ","
                    End If
                    If row.Cells("fecha3").Value > 1 Then
                        s &= row.Cells("fecha3").Value & ","
                    End If
                    If row.Cells("fecha4").Value > 1 Then
                        s &= row.Cells("fecha4").Value & ","
                    End If
                Else
                    Me.LblPeriodo.Text = "Día de Semana"
                    If row.Cells("dia1").Value = 1 Then
                        s &= "Lunes,"
                    End If
                    If row.Cells("dia2").Value = 1 Then
                        s &= "Martes,"
                    End If
                    If row.Cells("dia3").Value = 1 Then
                        s &= "Miércoles,"
                    End If
                    If row.Cells("dia4").Value = 1 Then
                        s &= "Jueves,"
                    End If
                    If row.Cells("dia5").Value = 1 Then
                        s &= "Viernes,"
                    End If
                    If row.Cells("dia6").Value = 1 Then
                        s &= "Sábado,"
                    End If
                    If row.Cells("dia7").Value = 1 Then
                        s &= "Domingo,"
                    End If
                End If
                If s.Trim.Length > 0 Then
                    s = s.Trim.Substring(0, s.Trim.Length - 1)
                End If
                Me.LblDia.Text = s

                If IsDBNull(row.Cells("horario_pago_ini").Value) Or IsDBNull(row.Cells("horario_pago_fin").Value) Then
                    Me.LblInicio.Text = ""
                    Me.LblFin.Text = ""
                Else
                    Me.LblInicio.Text = row.Cells("horario_pago_ini").Value
                    Me.LblFin.Text = row.Cells("horario_pago_fin").Value
                End If

                'hlamas 08-04-2016
                Me.grbContactoComercial.Text = "Contacto Comercial : " & row.Cells("nombre_comercial").Value
                Me.grbContactoPagos.Text = "Contacto Pagos : " & row.Cells("nombre_pagos").Value

                Me.lblCargoComercial.Text = row.Cells("cargo_comercial").Value
                Me.lblEmailComercial.Text = IIf(IsDBNull(row.Cells("email_comercial").Value), "", row.Cells("email_comercial").Value)

                Me.lblCargoPagos.Text = row.Cells("cargo_pagos").Value
                Me.lblEmailPagos.Text = IIf(IsDBNull(row.Cells("email_pagos").Value), "", row.Cells("email_pagos").Value)

                Me.lblCondicionFacturacion.Text = IIf(IsDBNull(row.Cells("forma_pago").Value), "", row.Cells("forma_pago").Value)
                Me.lblDireccionEntrega.Text = IIf(IsDBNull(row.Cells("direccion_facturacion").Value), "", row.Cells("direccion_facturacion").Value)
                If Not IsDBNull(row.Cells("fecha_corte").Value) Then
                    Me.lblFechaCorte.Text = row.Cells("fecha_corte").Value
                Else
                    Me.lblFechaCorte.Text = ""
                End If
                s = ""
                lblPeriodoFacturacion.Text = ""
                If row.Cells("fechaf1").Value > 0 Then
                    Me.lblPeriodoFacturacion.Text = "Día de Mes"
                    If row.Cells("fechaf1").Value > 1 Then
                        s &= row.Cells("fechaf1").Value & ","
                    End If
                    If row.Cells("fechaf2").Value > 1 Then
                        s &= row.Cells("fechaf2").Value & ","
                    End If
                    If row.Cells("fechaf3").Value > 1 Then
                        s &= row.Cells("fechaf3").Value & ","
                    End If
                    If row.Cells("fechaf4").Value > 1 Then
                        s &= row.Cells("fechaf4").Value & ","
                    End If
                Else 'If row.Cells("diaf1").Value > 0 Then
                    Me.lblPeriodoFacturacion.Text = "Día de Semana"
                    If row.Cells("diaf1").Value = 1 Then
                        s &= "Lunes,"
                    End If
                    If row.Cells("diaf2").Value = 1 Then
                        s &= "Martes,"
                    End If
                    If row.Cells("diaf3").Value = 1 Then
                        s &= "Miércoles,"
                    End If
                    If row.Cells("diaf4").Value = 1 Then
                        s &= "Jueves,"
                    End If
                    If row.Cells("diaf5").Value = 1 Then
                        s &= "Viernes,"
                    End If
                    If row.Cells("diaf6").Value = 1 Then
                        s &= "Sábado,"
                    End If
                    If row.Cells("diaf7").Value = 1 Then
                        s &= "Domingo,"
                    End If
                End If
                If s.Trim.Length > 0 Then
                    s = s.Trim.Substring(0, s.Trim.Length - 1)
                End If
                Me.lblDiaFacturacion.Text = s

                If IsDBNull(row.Cells("horario_facturacion_ini").Value) Or IsDBNull(row.Cells("horario_facturacion_fin").Value) Then
                    Me.lblInicioFacturacion.Text = ""
                    Me.lblFinFacturacion.Text = ""
                Else
                    Me.lblInicioFacturacion.Text = row.Cells("horario_facturacion_ini").Value
                    Me.lblFinFacturacion.Text = row.Cells("horario_facturacion_fin").Value
                End If
                Me.lblOrdenCompra.Text = row.Cells("orden_compra").Value

                '--------------------------------------------------------------------------------------------------
                Me.txtMontoOtorgado.Text = ""
                If intEstado = 1 Then
                    Me.lblMontoSolicitado.Text = Format(row.Cells("monto_solicitado").Value, "###,###,###,###0.00")
                    Me.txtMontoPreaprobado.Text = Format(row.Cells("monto_solicitado").Value, "###,###,###,###0.00")
                    Me.lblUsuarioCredito.Text = IIf(IsDBNull(row.Cells("idusuario_personal").Value), "", row.Cells("idusuario_personal").Value)
                    Me.lblUsuario2Credito.Text = "Usuario Solicitud Línea de Crédito"
                ElseIf intEstado = 2 Then
                    Me.lblMontoSolicitado2.Text = Format(row.Cells("monto_solicitado").Value, "###,###,###,###0.00")
                    Me.lblMontoPreaprobado.Text = Format(row.Cells("monto_preaprobado").Value, "###,###,###,###0.00")
                    Me.lblUsuarioCredito.Text = IIf(IsDBNull(row.Cells("usuario_pre_aprobacion").Value), "", row.Cells("usuario_pre_aprobacion").Value)
                    Me.lblUsuario2Credito.Text = "Usuario Pre Aprobación"
                ElseIf intEstado = 3 Then
                    Me.lblMontoSolicitado2.Text = Format(row.Cells("monto_solicitado").Value, "###,###,###,###0.00")
                    Me.lblMontoPreaprobado.Text = Format(row.Cells("monto_preaprobado").Value, "###,###,###,###0.00")
                    Me.txtMontoOtorgado.Text = Format(row.Cells("monto_aprobado").Value, "###,###,###,###0.00")
                    Me.lblUsuarioCredito.Text = IIf(IsDBNull(row.Cells("usuario_aprobacion").Value), "", row.Cells("usuario_aprobacion").Value)
                    Me.lblUsuario2Credito.Text = "Usuario Aprobación"
                ElseIf intEstado = 4 Then
                    Me.lblMontoSolicitado2.Text = Format(row.Cells("monto_solicitado").Value, "###,###,###,###0.00")
                    Me.lblMontoPreaprobado.Text = Format(row.Cells("monto_preaprobado").Value, "###,###,###,###0.00")
                    Me.txtMontoOtorgado.Text = Format(row.Cells("monto_aprobado").Value, "###,###,###,###0.00")

                    Dim intEstado2 As Integer = Me.cboPorCredito.SelectedIndex
                    If intEstado2 = 0 Then
                        Me.lblUsuarioCredito.Text = IIf(IsDBNull(row.Cells("usuario_rechazo_pre_aprobacion").Value), "", row.Cells("usuario_rechazo_pre_aprobacion").Value)
                    Else
                        Me.lblUsuarioCredito.Text = IIf(IsDBNull(row.Cells("usuario_rechazo_aprobacion").Value), "", row.Cells("usuario_rechazo_aprobacion").Value)
                    End If
                    Me.lblUsuario2Credito.Text = IIf(intEstado2 = 0, "Usuario Rechazo Preaprobación", "Usuario Rechazo Aprobación")
                End If
            End If
        End With
    End Sub

    Private Sub txtMontoPreaprobado_Enter(sender As Object, e As System.EventArgs) Handles txtMontoPreaprobado.Enter
        Dim dblValor As Double
        If txtMontoPreaprobado.Text.Trim.Length > 0 Then
            dblValor = Me.txtMontoPreaprobado.Text
            txtMontoPreaprobado.Text = Format(dblValor, "0.00")
        End If
        txtMontoPreaprobado.SelectAll()
    End Sub

    Private Sub txtMontoPreaprobado_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoPreaprobado.KeyPress
        If Not ValidarNumeroReal(e.KeyChar, txtMontoPreaprobado.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMontoPreaprobado_LostFocus(sender As Object, e As System.EventArgs) Handles txtMontoPreaprobado.LostFocus
        Dim iValor As Double = 0
        If Me.txtMontoPreaprobado.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.txtMontoPreaprobado.Text
        End If
        Me.txtMontoPreaprobado.Text = Format(CDbl(iValor), "###,###,###0.00")
    End Sub

    Private Sub btnAceptarCredito_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptarCredito.Click
        Dim strMensaje As String, strAprobar As String
        Dim dblMonto As Double
        If Me.rbtPorPreaprobar.Checked Then 'preaprobar
            strMensaje = "Preaprobar Línea de Crédito"
            If Me.rbtSiCredito.Checked Then
                strAprobar = "Preaprobar"
                If Val(Me.txtMontoPreaprobado.Text) = 0 Then
                    MessageBox.Show("Ingrese Monto Preaprobado", strMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtMontoPreaprobado.Text = ""
                    Me.txtMontoPreaprobado.Focus()
                    Return
                End If
            Else
                strAprobar = "Desaprobar"
                If Me.txtObservacionCredito.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Motivo de la Desaprobación", strMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtObservacionCredito.Text = ""
                    Me.txtObservacionCredito.Focus()
                    Return
                End If
            End If
        Else 'aprobar
            strMensaje = "Aprobar Línea de Crédito"
            If Me.rbtSiCredito.Checked Then
                strAprobar = "Aprobar"
                If Val(Me.txtMontoOtorgado.Text) = 0 Then
                    MessageBox.Show("Ingrese Monto Aprobado", strMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtMontoOtorgado.Text = ""
                    Me.txtMontoOtorgado.Focus()
                    Return
                End If
            Else
                strAprobar = "Desaprobar"
                If Me.txtObservacionCredito.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Motivo de la Desaprobación", strMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtObservacionCredito.Text = ""
                    Me.txtObservacionCredito.Focus()
                    Return
                End If
            End If
        End If

        Dim iRespuesta As DialogResult
        iRespuesta = MessageBox.Show("¿Está Seguro de " & strAprobar & " la Solicitud?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If iRespuesta = Windows.Forms.DialogResult.Yes Then
            Dim intSolicitud As Integer = dgvListaCredito.CurrentRow.Cells("id").Value
            Dim intEstado As Integer
            Dim strObservacion As String = IIf(Me.rbtSiCredito.Checked, "", Me.txtObservacionCredito.Text.Trim)
            If Me.rbtPorPreaprobar.Checked Then
                intEstado = IIf(Me.rbtSiCredito.Checked, 2, 4)
                dblMonto = CDbl(Me.txtMontoPreaprobado.Text)
                PreaprobarCredito(intSolicitud, intEstado, dblMonto, strObservacion, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
            Else
                Dim intCliente As Integer = Me.dgvListaCredito.CurrentRow.Cells("idcliente").Value
                Dim strNumeroDocumento As String = Me.lblCodigoCredito.Text.Trim
                intEstado = IIf(Me.rbtSiCredito.Checked, 3, 5)
                dblMonto = CDbl(Me.txtMontoOtorgado.Text)
                Dim dblSobregiro As Double = Me.lblSobregiroAprobado.Text
                Dim dblTotal As Double = Me.lblLineaFinalAprobada.Text
                Dim dblPorcentajeSobregiro As Double = Me.TxtSobregiro.Text
                AprobarCredito(intSolicitud, intCliente, strNumeroDocumento, intEstado, _
                               dblMonto, dblSobregiro, dblTotal, dblPorcentajeSobregiro, _
                               dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, strObservacion)
            End If
        End If
    End Sub

    Private Sub rbtSiCredito_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtSiCredito.CheckedChanged
        Me.txtObservacionCredito.Enabled = False
        Me.txtObservacionCredito.Text = ""
        Me.txtObservacionCredito.Focus()
    End Sub

    Private Sub rbtNoCredito_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtNoCredito.CheckedChanged
        Me.txtObservacionCredito.Enabled = True
        Me.txtObservacionCredito.Focus()
    End Sub

    Sub AprobarCredito(solicitud As Integer, cliente As Integer, numero_documento As String, estado As Integer, _
                       monto As Double, sobregiro As Double, total As Double, porcentaje_sobregiro As Double, _
                       usuario As Integer, ip As String, observacion As String)
        Try
            Dim objLN As New Cls_LineaCredito_LN
            objLN.Aprobar(solicitud, cliente, numero_documento, estado, monto, sobregiro, total, porcentaje_sobregiro, usuario, ip, observacion)
            MessageBox.Show("Solicitud " & IIf(estado = 3, "Aprobada", "Desaprobada"), "Aprobar Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.tabLineaCredito.SelectedTab = Me.tabLineaCredito.TabPages("tabListaCredito")
            ListarSolicitudCredito(2)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Aprobar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub PreaprobarCredito(solicitud As Integer, estado As Integer, monto As Double, observacion As String, usuario As Integer, ip As String)
        Try
            Dim objLN As New Cls_LineaCredito_LN
            objLN.Preaprobar(solicitud, estado, monto, usuario, ip, observacion)
            MessageBox.Show("Solicitud " & IIf(estado = 2, "Preaprobada", "Desaprobada"), "Preaprobar Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.tabLineaCredito.SelectedTab = Me.tabLineaCredito.TabPages("tabListaCredito")
            ListarSolicitudCredito(1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Preaprobar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtMontoOtorgado_Enter(sender As Object, e As System.EventArgs) Handles txtMontoOtorgado.Enter
        Dim dblValor As Double = 0
        If Me.txtMontoOtorgado.Text.Trim.Length = 0 Then
            dblValor = 0
        Else
            dblValor = Me.txtMontoOtorgado.Text
        End If
        Me.txtMontoOtorgado.Text = Format(CDbl(dblValor), "########0.00")
    End Sub

    Private Sub txtMontoOtorgado_GotFocus(sender As Object, e As System.EventArgs) Handles txtMontoOtorgado.GotFocus
        txtMontoOtorgado.SelectAll()
    End Sub

    Private Sub txtMontoOtorgado_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoOtorgado.KeyPress
        If Not ValidarNumeroReal(e.KeyChar, txtMontoOtorgado.Text) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMontoOtorgado_LostFocus(sender As Object, e As System.EventArgs) Handles txtMontoOtorgado.LostFocus
        Dim dblValor As Double = 0
        If Me.txtMontoOtorgado.Text.Trim.Length = 0 Then
            dblValor = 0
        Else
            dblValor = Me.txtMontoOtorgado.Text
        End If
        Me.txtMontoOtorgado.Text = Format(CDbl(dblValor), "##,###,###0.00")
    End Sub

    Private Sub txtMontoOtorgado_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMontoOtorgado.TextChanged
        Dim dblMontoOtorgado As Double = 0
        Dim dblMontoAprobado As Double = 0
        Dim dblSobregiroAprobado As Double = 0
        Dim dblSobregiro As Double = 10

        Dim dblLineaFinalAprobada As Double = 0

        dblMontoOtorgado = CDbl(IIf(Me.txtMontoOtorgado.Text.Trim.Length = 0, 0, Me.txtMontoOtorgado.Text))
        dblMontoAprobado = dblMontoOtorgado

        If Me.ChkSobregiro.Checked Then
            dblSobregiroAprobado = dblMontoAprobado * (dblSobregiro / 100)
        Else
            dblSobregiroAprobado = 0
        End If
        dblLineaFinalAprobada = dblMontoAprobado + dblSobregiroAprobado

        Me.lblMontoAprobado.Text = Format(dblMontoAprobado, "#,###,###,###0.00")
        Me.lblSobregiroAprobado.Text = Format(dblSobregiroAprobado, "#,###,###,###0.00")
        Me.lblLineaFinalAprobada.Text = Format(dblLineaFinalAprobada, "#,###,###,###0.00")
    End Sub

    Private Sub cboFuncionarioCredito_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboFuncionarioCredito.SelectedIndexChanged
        If IsReference(cboFuncionarioCredito.SelectedValue) Then Return
        CargarCartera(Me.cboFuncionarioCredito.SelectedValue, dgvCarteraCredito)
        lblNumeroClienteCredito.Text = Me.dgvCarteraCredito.Rows.Count
        If Me.dgvCarteraCredito.Rows.Count > 0 Then
            Me.txtNumeroDocumentoCredito.Text = ""
            Me.txtRazonSocialCredito.Text = ""
        Else
            Me.lblEstadoCredito.Text = ""
            Me.btnActivarLineaCredito.Enabled = False
            Me.btnActualizarLineaCredito.Enabled = False
            Me.btnDesactivarLineaCredito.Enabled = False
            Me.btnCancelarLineaCredito.Enabled = False
            Me.dgvLineaCredito.DataSource = Nothing
        End If
        'dgvCarteraCredito_RowEnter(Nothing, Nothing)
        'dgvClientes_RowEnter(Nothing, Nothing)

    End Sub

    Function EstadoLineaCredito(estado As Integer) As Integer
        Select Case estado
            Case 0
                Return -1
            Case 1
                Return 1
            Case 2
                Return 0
            Case 3
                Return 2
        End Select
    End Function

    Private Sub dgvCarteraCredito_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCarteraCredito.RowEnter
        Dim intCliente As Integer = dgvCarteraCredito(0, e.RowIndex).Value
        ListarLineaCredito(intCliente, Me.dgvLineaCredito, EstadoLineaCredito(Me.cboEstadoOperacionCredito.SelectedIndex))

        If Me.cboFuncionarioCredito.SelectedValue = 0 Then
            Me.lblFuncionarioCreditoOperacion.Text = dgvCarteraCredito.Rows(e.RowIndex).Cells("funcionario").Value
        Else
            Me.lblFuncionarioCreditoOperacion.Text = ""
        End If
    End Sub

    Private Sub cboEstadoOperacionCredito_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstadoOperacionCredito.SelectedIndexChanged
        If Me.dgvCarteraCredito.Rows.Count > 0 Then
            Dim intCliente As Integer = dgvCarteraCredito.CurrentRow.Cells("id").Value
            ListarLineaCredito(intCliente, Me.dgvLineaCredito, EstadoLineaCredito(Me.cboEstadoOperacionCredito.SelectedIndex))
        End If
    End Sub

    Sub EstadoActualLineaCredito(cliente As Integer, ByRef id As Integer, ByRef estado As String, ByRef ctacte As Integer)
        Dim objLN As New Cls_LineaCredito_LN
        Dim dt As DataTable = objLN.EstadoActual(cliente)
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows(0).Item(0)) Then
                id = 0
                estado = ""
                ctacte = 0
            Else
                id = dt.Rows(0).Item(0)
                estado = dt.Rows(0).Item(1)
                ctacte = dt.Rows(0).Item(2)
            End If
        Else
            id = 2
            estado = ""
            ctacte = 0
        End If
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Close() 'Salir de gestion de clientes
    End Sub

    Sub CargarClienteCredito()
        Dim objLN As New Cls_LineaCredito_LN
        Dim dt As New DataTable

        dt = objLN.ListarClienteCredito()
        Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
        ObjProcesos.fnCargar_iWin_r(Me.txtRazonSocialCredito, dt.DefaultView, colClienteCredito, autoClienteCredito, 0)
    End Sub

    Private Sub txtCodigoClienteCredito_Enter(sender As Object, e As System.EventArgs) Handles txtNumeroDocumentoCredito.Enter
        txtNumeroDocumentoCredito.SelectAll()
    End Sub

    Private Sub txtCodigoClienteCredito_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroDocumentoCredito.KeyPress
        If Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Sub ListarCliente(documento As String)
        Dim obj As New UtilData_LN
        Dim strCodigoCliente As String = Me.txtNumeroDocumentoCredito.Text.Trim
        Dim dt As DataTable = obj.ListarCliente(strCodigoCliente)
        If dt.Rows.Count > 0 Then
            Me.txtRazonSocialCredito.Text = dt.Rows(0).Item("cliente").ToString
            Me.ListarLineaCredito(dt.Rows(0).Item("id").ToString, Me.dgvLineaCredito, EstadoLineaCredito(Me.cboEstadoOperacionCredito.SelectedIndex))
        Else
            MessageBox.Show("El Cliente no Existe", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Sub ActivarDesactivarCredito(sender As Object, e As EventArgs) Handles btnDesactivarLineaCredito.Click, btnActivarLineaCredito.Click, btnCancelarLineaCredito.Click
        Try
            Dim intEstado As Integer, strEstado As String, strEstado2 As String
            Dim strNombre As String = CType(sender, Button).Name.ToLower
            If strNombre = "btndesactivarlineacredito" Then
                intEstado = 0
                strEstado = "Desactivar"
                strEstado2 = "Desactivada"
            ElseIf strNombre = "btnactivarlineacredito" Then
                intEstado = 1
                strEstado = "Activar"
                strEstado2 = "Activada"
            Else
                intEstado = 2
                strEstado = "Cancelar"
                strEstado2 = "Cancelada"
            End If

            Dim intCliente As Integer
            If intEstado = 1 Then
                Dim frm As New frmActivarLineaCredito
                intCliente = Me.dgvCarteraCredito.CurrentRow.Cells("id").Value
                frm.Cliente = intCliente
                frm.Ruc = Me.dgvCarteraCredito.CurrentRow.Cells("codigo").Value
                frm.RazonSocial = Me.dgvCarteraCredito.CurrentRow.Cells("cliente").Value
                frm.ID = Me.lblEstadoCredito.Tag
                frm.Llamada = 1
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    MessageBox.Show("Línea de Crédito " & strEstado2, strEstado, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ListarLineaCredito(intCliente, Me.dgvLineaCredito, EstadoLineaCredito(Me.cboEstadoOperacionCredito.SelectedIndex))
                End If
            Else
                Dim dlgRespuesta As DialogResult = MessageBox.Show("¿Está seguro de " & strEstado & " la Línea de Crédito?", strEstado, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.No Then Return

                If Me.dgvCarteraCredito.Rows.Count > 0 Then
                    intCliente = Me.dgvCarteraCredito.CurrentRow.Cells("id").Value
                Else
                    intCliente = Int(colClienteCredito.Item(autoClienteCredito.IndexOf(Me.txtRazonSocialCredito.Text).ToString))
                End If
                Dim objLN As New Cls_LineaCredito_LN
                objLN.ActivarDesactivar(Me.lblEstadoCredito.Tag, intCliente, intEstado, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                MessageBox.Show("Línea de Crédito " & strEstado2, strEstado, MessageBoxButtons.OK, MessageBoxIcon.Information)
                ListarLineaCredito(intCliente, Me.dgvLineaCredito, EstadoLineaCredito(Me.cboEstadoOperacionCredito.SelectedIndex))
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Línea de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvClienteFacturacion_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvClienteFacturacion.DoubleClick
        'intFilaDGVClienteProducto = 0
        With dgvClienteFacturacion
            If .Rows.Count > 0 Then
                'intFilaDGVClienteProducto = .CurrentRow.Index
                Me.tabTipoFacturacion.SelectedTab = Me.tabTipoFacturacion.TabPages("tabSolicitudFacturacion")
            End If
        End With
    End Sub

    Private Sub dgvClienteFacturacion_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClienteFacturacion.RowEnter
        'If blnInicioProducto = False Then Return
        Dim intCliente As Integer = dgvClienteFacturacion(0, e.RowIndex).Value
        ListarTipoFacturacion(intCliente, Me.dgvClienteFacturacionDetalle)
    End Sub

    Sub ListarSolicitudTipoFacturacion()
        Try
            If Me.dgvClienteFacturacion.Rows.Count = 0 Then Return
            Dim obj As New Cls_ClienteTipoFacturacion_LN
            Dim objEN As New Cls_ClienteTipoFacturacion_EN

            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.Estado = Me.cboEstadoFacturacion.SelectedIndex
            objEN.Cliente = dgvClienteFacturacion.CurrentRow.Cells(0).Value
            dgvSolicitudFacturacion.DataSource = obj.ListarSolicitud(objEN.Usuario, objEN.Cliente, objEN.Estado)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGrabarFacturacion_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabarFacturacion.Click
        Try
            If Me.cboTipoFacturacionSolicitud.SelectedValue = 0 Then
                MessageBox.Show("Seleccione Tipo de Facturación", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboTipoFacturacionSolicitud.DroppedDown = True
                Me.cboTipoFacturacionSolicitud.Focus()
                Return
            End If

            If Me.cboContactoFacturacion.SelectedValue = 0 Then
                MessageBox.Show("Seleccione Contacto", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboContactoFacturacion.Focus()
                Return
            End If

            If Me.txtObservacionFacturacion.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Observación", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtObservacionFacturacion.Text = ""
                Me.txtObservacionFacturacion.Focus()
                Return
            End If

            If Me.cboTipoFacturacionSolicitud.SelectedValue = 3 Then
                'If Me.cboFormaFacturacionConsulta.SelectedValue = 0 Then
                '    MessageBox.Show("Seleccione Forma de Facturación", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Me.cboFormaFacturacionConsulta.Focus()
                '    Return
                'End If
                If Me.dgvFacturacion3.Rows.Count = 0 Then
                    MessageBox.Show("Ingrese Cargos a Retornar", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.btnAgregarCargo.Focus()
                    Return
                End If
            End If

            Dim intCliente As Integer = Me.dgvClienteFacturacion.CurrentRow.Cells(0).Value
            Dim intSolicitud As Integer = 0
            If intOperacion = Operacion.Modificar Then
                intSolicitud = Me.dgvSolicitudFacturacion.CurrentRow.Cells("numero_solicitud").Value
            End If
            If intOperacion = Operacion.Nuevo Then
                Dim objLN As New Cls_ClienteTipoFacturacion_LN
                Dim objEN As New Cls_ClienteTipoFacturacion_EN
                objEN.Cliente = intCliente
                objEN.Estado = 1
                If objLN.ExisteSolicitud(objEN) Then
                    MessageBox.Show("El Cliente " & Me.lblClienteFacturacion.Text & Chr(13) & " ya cuenta con una Solicitud Activa", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.btnCancelarFacturacion.Focus()
                    Return
                End If

                objEN.TipoFacturacion = Me.cboTipoFacturacionSolicitud.SelectedValue
                If objLN.ExisteTipoFacturacion(objEN) Then
                    MessageBox.Show("El Cliente " & Me.lblClienteFacturacion.Text & Chr(13) & " ya cuenta con el " & Me.cboTipoFacturacionSolicitud.Text, "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cboTipoFacturacionSolicitud.Focus()
                    Return
                End If
            End If

            'graba solicitud tipo de facturacion
            Cursor = Cursors.WaitCursor
            GrabarTipoFacturacion()
            ListarSolicitudTipoFacturacion()
            ActivaDesactivaTipoFacturacion(0, dgvSolicitudFacturacion.Rows.Count)
            Cursor = Cursors.Default
            Me.btnNuevoFacturacion.Focus()

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub GrabarTipoFacturacion()
        Try
            Dim objEN As New Cls_ClienteTipoFacturacion_EN
            Dim objLN As New Cls_ClienteTipoFacturacion_LN

            If intOperacion = Operacion.Nuevo Then
                objEN.ID = 0
            Else
                objEN.ID = dgvSolicitudFacturacion.CurrentRow.Cells("id").Value
            End If
            objEN.NumeroSolicitud = Me.lblNumeroSolicitudFacturacion.Text
            objEN.Fecha = Me.lblFechaFacturacion.Text
            objEN.Cliente = Me.dgvClienteFacturacion.CurrentRow.Cells(0).Value
            objEN.TipoFacturacion = Me.cboTipoFacturacionSolicitud.SelectedValue
            objEN.Contacto = Me.cboContactoFacturacion.SelectedValue
            objEN.Observacion = Me.txtObservacionFacturacion.Text.Trim
            objEN.OrdenCompra = IIf(Me.chkOrdenCompra.Checked, 1, 0)
            objEN.LiquidacionDocumento = IIf(Me.chkLiquidacionDocumento.Checked, 1, 0)
            'objEN.FormaFacturacion = Me.cboFormaFacturacionConsulta.SelectedValue

            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP
            objLN.GrabarSolicitud(objEN)

            'Actualizar cargos del cliente
            With Me.dgvFacturacion3
                For Each row As DataGridViewRow In Me.dgvFacturacion3.Rows
                    Dim intID As Integer = IIf(IsDBNull(row.Cells("id").Value), 0, row.Cells("id").Value)
                    Dim intCliente As Integer = Me.dgvClienteFacturacion.CurrentRow.Cells(0).Value
                    Dim intSubcuenta As Integer = row.Cells("idsubcuenta").Value
                    Dim intCargo As Integer = row.Cells("idcargo").Value
                    Dim intEstado As Integer = row.Cells("estado").Value
                    Dim intUsuario As Integer = dtoUSUARIOS.IdLogin
                    Dim strIP As String = dtoUSUARIOS.IP
                    objLN.GrabarCargo(intID, intCliente, intSubcuenta, intCargo, intEstado, intUsuario, strIP)
                Next
            End With

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub LimpiarSolicitudTipoFacturacion()
        Me.lblNumeroSolicitudFacturacion.Text = ""
        Me.cboTipoFacturacionSolicitud.SelectedValue = 0
        Me.cboContactoFacturacion.SelectedValue = 0
        Me.txtObservacionFacturacion.Text = ""
        Me.chkOrdenCompra.Checked = False
        Me.chkLiquidacionDocumento.Checked = False
        'Me.cboFormaFacturacionConsulta.SelectedValue = 0
    End Sub

    Sub LLenarComboTipoFacturacion()
        Dim obj As New UtilData_LN
        Dim dt As DataTable

        dt = obj.ListarTipoFacturacion
        With cboTipoFacturacionSolicitud
            .DataSource = Nothing
            .DataSource = dt
            .DisplayMember = "tipo"
            .ValueMember = "id"
        End With

        Dim intCliente As Integer = Me.dgvClienteFacturacion.CurrentRow.Cells(0).Value
        Dim objLN As New Cls_LineaCredito_LN
        With cboContactoFacturacion
            .DataSource = Nothing
            .DataSource = objLN.ListarContactoCredito(intCliente, "") '"267,307)"
            .DisplayMember = "CONTACTO"
            .ValueMember = "ID"
            .SelectedValue = 0
        End With
        Me.cboEstadoFacturacion.SelectedIndex = 1

        'Dim objLN2 As New Cls_ClienteTipoFacturacion_LN
        'With cboFormaFacturacionConsulta
        '    .DataSource = Nothing
        '    .DataSource = objLN2.ListarFormaFacturacion
        '    .DisplayMember = "FORMA"
        '    .ValueMember = "ID"
        '    .SelectedValue = 0
        'End With
        'Me.cboFormaFacturacionConsulta.SelectedIndex = 1
    End Sub

    Sub ActivaDesactivaTipoFacturacion(estado As Integer, registros As Integer)
        Dim blnEstado As Boolean
        If estado = 1 Then
            blnEstado = True
        ElseIf estado = 0 Then
            blnEstado = False
        End If
        If estado = -1 Then
            Me.grbSolicitudFacturacion.Enabled = False
            Me.btnNuevoFacturacion.Enabled = Me.dgvClienteFacturacion.Rows.Count > 0
            If registros = 0 Then
                Me.btnModificarFacturacion.Enabled = False
                Me.btnAnularFacturacion.Enabled = False
            Else
                Me.btnModificarFacturacion.Enabled = True
                Me.btnAnularFacturacion.Enabled = True
            End If
            Me.btnGrabarFacturacion.Enabled = False
            Me.btnCancelarFacturacion.Enabled = False
        Else
            blnEstado = estado
            Me.grbSolicitudFacturacion.Enabled = blnEstado
            Me.btnNuevoFacturacion.Enabled = Not blnEstado
            If registros = 0 Then
                Me.btnModificarFacturacion.Enabled = False
            Else
                Me.btnModificarFacturacion.Enabled = Not blnEstado
            End If
            Me.btnGrabarFacturacion.Enabled = blnEstado
            Me.btnCancelarFacturacion.Enabled = blnEstado
            If registros = 0 Then
                Me.btnAnularFacturacion.Enabled = False
            Else
                Me.btnAnularFacturacion.Enabled = Not blnEstado
            End If
        End If

        If Me.btnGrabarFacturacion.Enabled Then
            Me.dgvSolicitudFacturacion.Enabled = False
            Me.cboEstadoFacturacion.Enabled = False
        Else
            Me.dgvSolicitudFacturacion.Enabled = True
            Me.cboEstadoFacturacion.Enabled = True
        End If
    End Sub

    Sub ListarSolicitudesPendientesFacturacion()
        Try
            Dim obj As New Cls_ClienteTipoFacturacion_LN
            Dim objEN As New Cls_ClienteTipoFacturacion_EN

            objEN.Estado = Estado.Pendiente
            dgvListaFacturacion.DataSource = obj.ListarSolicitud(objEN.Estado)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub LimpiarAprobacionTipoFacturacion()
        Me.lblCodigoFacturacion.Text = ""
        Me.lblRazonSocialFacturacion.Text = ""
        Me.lblFuncionarioFacturacionAprobacion.Text = ""
        Me.lblObservacionTipoFacturacion.Text = ""
        Me.rbtSiTipoFacturacion.Checked = True
        Me.lblFacturacionAprobacion.Text = ""
        Me.lblContactoFacturacion.Text = ""
        Me.dgvFacturacion3Aprobacion.Rows.Clear()
        Me.grbFacturacion3Aprobacion.Visible = False
        Me.lblMensajeTipoFacturacion.Text = ""
        Me.lblFechaActivacion.Text = Now.ToShortDateString
    End Sub

    Sub AnularTipoFacturacion()
        Try
            Dim objEN As New Cls_ClienteTipoFacturacion_EN
            Dim objLN As New Cls_ClienteTipoFacturacion_LN

            objEN.ID = dgvSolicitudFacturacion.CurrentRow.Cells("id").Value
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP

            objLN.AnularSolicitud(objEN)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tabTipoFacturacion_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabTipoFacturacion.SelectedIndexChanged
        If tabTipoFacturacion.SelectedTab Is tabTipoFacturacion.TabPages("tabClienteFacturacion") Then
            'blnInicioProducto = False
            ConfigurarDGVClienteFacturacion()
            ConfigurarDGVClienteFacturacionDetalle()

            intOperacion = Operacion.Nuevo
            'blnInicioProducto = True
            CargarCartera(dtoUSUARIOS.IdLogin, Me.dgvClienteFacturacion, 2)

        ElseIf tabTipoFacturacion.SelectedTab Is tabTipoFacturacion.TabPages("tabSolicitudFacturacion") Then
            intOperacion = Operacion.Nuevo
            ConfigurarDGVFacturacion3()
            Me.lblFechaFacturacion.Text = Format(Now, "Short Date")
            Me.lblFuncionarioFacturacion.Text = dtoUSUARIOS.NameLogin

            If dgvClienteFacturacion.Rows.Count > 0 Then
                Dim strCliente As String = dgvClienteFacturacion.CurrentRow.Cells("codigo").Value & "  " & dgvClienteFacturacion.CurrentRow.Cells("cliente").Value
                Me.lblClienteFacturacion.Text = strCliente.Trim
            End If

            LimpiarSolicitudTipoFacturacion()
            ConfigurarDGVSolicitudFacturacion()
            If Me.dgvClienteFacturacion.Rows.Count > 0 Then
                LLenarComboTipoFacturacion()
                ListarSolicitudTipoFacturacion()
            End If
            ActivaDesactivaTipoFacturacion(-1, dgvSolicitudFacturacion.Rows.Count)
            Me.btnNuevoFacturacion.Focus()

        ElseIf tabTipoFacturacion.SelectedTab Is tabTipoFacturacion.TabPages("tabListaFacturacion") Then
            ConfigurarDGVListaFacturacion()
            ConfigurarDGVFacturacion3Aprobacion()
            ListarSolicitudesPendientesFacturacion()
            If Me.dgvListaFacturacion.Rows.Count = 0 Then
                'Me.tabTipoFacturacion.TabPages.Remove(tabTipoFacturacion.TabPages("tabListaFacturacion"))
                'Me.tabTipoFacturacion.TabPages.Remove(tabTipoFacturacion.TabPages("tabAprobacionfacturacion"))
            End If

        ElseIf tabTipoFacturacion.SelectedTab Is tabTipoFacturacion.TabPages("tabAprobacionFacturacion") Then
            If dgvListaFacturacion.Rows.Count > 0 Then
                Me.dtpFechaActivacionFacturacion.Text = Now.ToShortDateString
                btnAceptarTipoFacturacion.Enabled = True
                Me.dtpFechaActivacionFacturacion.Enabled = True

                Me.rbtSiTipoFacturacion.Enabled = True
                Me.rbtNoTipoFacturacion.Enabled = True

                Me.dtpFechaActivacionFacturacion.Focus()
            Else
                LimpiarAprobacionTipoFacturacion()
                Me.dtpFechaActivacionFacturacion.Enabled = False
                btnAceptarTipoFacturacion.Enabled = False
                Me.rbtSiTipoFacturacion.Enabled = False
                Me.rbtNoTipoFacturacion.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnNuevoFacturacion_Click(sender As Object, e As System.EventArgs) Handles btnNuevoFacturacion.Click
        LimpiarSolicitudTipoFacturacion()
        Me.lblNumeroSolicitudFacturacion.Text = dtoUtilitario.ObtieneNumeroSolicitud(dtoUSUARIOS.IdLogin, 3)
        intOperacion = Operacion.Nuevo
        ActivaDesactivaTipoFacturacion(1, dgvSolicitudFacturacion.Rows.Count)
        Me.cboTipoFacturacionSolicitud.DroppedDown = True
        Me.cboTipoFacturacionSolicitud.Focus()
    End Sub

    Private Sub btnModificarFacturacion_Click(sender As Object, e As System.EventArgs) Handles btnModificarFacturacion.Click
        intOperacion = Operacion.Modificar
        ActivaDesactivaTipoFacturacion(1, dgvSolicitudFacturacion.Rows.Count)
        Me.cboTipoFacturacionSolicitud.Focus()
    End Sub

    Private Sub btnAnularFacturacion_Click(sender As Object, e As System.EventArgs) Handles btnAnularFacturacion.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está Seguro de Anular la Solicitud Nº " & dgvSolicitudFacturacion.CurrentRow.Cells("numero_solicitud").Value & "?", "Anular Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = vbYes Then
            AnularTipoFacturacion()
            LimpiarSolicitudTipoFacturacion()
            ListarSolicitudTipoFacturacion()
            ActivaDesactivaTipoFacturacion(0, dgvSolicitudFacturacion.Rows.Count)
            If Me.dgvSolicitudFacturacion.Rows.Count > 0 Then
                MostrarSolicitudTipoFacturacion(Me.dgvSolicitudFacturacion.CurrentCell.RowIndex)
                Me.btnModificarFacturacion.Enabled = dgvSolicitudFacturacion.Rows(Me.dgvSolicitudFacturacion.CurrentCell.RowIndex).Cells("idestado").Value = 1
                Me.btnAnularFacturacion.Enabled = dgvSolicitudFacturacion.Rows(Me.dgvSolicitudFacturacion.CurrentCell.RowIndex).Cells("idestado").Value = 1

                Dim intCliente As Integer = Me.dgvClienteFacturacion.CurrentRow.Cells("id").Value
                ListarClienteCargo(intCliente, dgvFacturacion3)
            End If
        End If
    End Sub

    Sub MostrarSolicitudTipoFacturacion(row As Integer)
        With dgvSolicitudFacturacion
            Me.lblNumeroSolicitudFacturacion.Text = .Rows(row).Cells("numero_solicitud").Value
            Me.lblFechaFacturacion.Text = .Rows(row).Cells("fecha_solicitud").Value
            Me.lblClienteFacturacion.Text = .Rows(row).Cells("cliente").Value
            'Dim s As String = dgvSolicitudProducto.Rows(1).Cells("cliente").Value

            Me.cboTipoFacturacionSolicitud.SelectedValue = .Rows(row).Cells("tipo_facturacion").Value
            Me.cboContactoFacturacion.SelectedValue = .Rows(row).Cells("contacto").Value
            Me.txtObservacionFacturacion.Text = .Rows(row).Cells("observacion").Value
            Me.chkOrdenCompra.Checked = .Rows(row).Cells("orden_compra").Value
            Me.chkLiquidacionDocumento.Checked = .Rows(row).Cells("liquidacion_documento").Value
            'Me.cboFormaFacturacionConsulta.SelectedValue = .Rows(row).Cells("forma_facturacion").Value
        End With
    End Sub

    Private Sub btnCancelarFacturacion_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelarFacturacion.Click
        LimpiarSolicitudTipoFacturacion()
        ActivaDesactivaTipoFacturacion(0, dgvSolicitudFacturacion.Rows.Count)

        If Me.dgvSolicitudFacturacion.Rows.Count > 0 Then
            MostrarSolicitudTipoFacturacion(dgvSolicitudFacturacion.CurrentCell.RowIndex)

            Dim intCliente As Integer = Me.dgvClienteFacturacion.CurrentRow.Cells("id").Value
            ListarClienteCargo(intCliente, dgvFacturacion3)
        End If
        If intOperacion = Operacion.Nuevo Then
            btnNuevoFacturacion.Focus()
        Else
            btnModificarFacturacion.Focus()
        End If
    End Sub

    Private Sub txtObservacionFacturacion_Enter(sender As Object, e As System.EventArgs) Handles txtObservacionFacturacion.Enter
        txtObservacionFacturacion.SelectAll()
    End Sub

    Private Sub cboEstadoFacturacion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstadoFacturacion.SelectedIndexChanged
        Me.LimpiarSolicitudTipoFacturacion()
        ListarSolicitudTipoFacturacion()
        'Me.ActivaDesactivaTipoFacturacion(0, Me.dgvSolicitudFacturacion.Rows.Count)
        If Me.dgvSolicitudFacturacion.Rows.Count > 0 AndAlso btnNuevoFacturacion.Enabled Then
            Me.btnModificarFacturacion.Enabled = dgvSolicitudFacturacion.CurrentRow.Cells("idestado").Value = 1
            Me.btnAnularFacturacion.Enabled = dgvSolicitudFacturacion.CurrentRow.Cells("idestado").Value = 1
        ElseIf Me.dgvSolicitudFacturacion.Rows.Count = 0 Then
            Me.ActivaDesactivaTipoFacturacion(-1, 0)
        End If
    End Sub

    Private Sub dgvSolicitudFacturacion_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvSolicitudFacturacion.DoubleClick
        If dgvSolicitudFacturacion.Rows.Count > 0 Then
            If Me.btnGrabarFacturacion.Enabled = False And dgvSolicitudFacturacion.CurrentRow.Cells("idestado").Value = 1 Then
                btnModificarFacturacion_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Sub ListarClienteCargo(cliente As Integer, dgv As DataGridView, Optional opcion As Integer = 0)
        'If Me.cboTipoFacturacionSolicitud.SelectedValue <> 3 Then Return
        Dim objLN As New Cls_ClienteTipoFacturacion_LN()
        Dim dt As DataTable = objLN.ListarClienteCargos(cliente)
        With dgv
            .Rows.Clear()
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .Rows.Add()
                    dgv(0, .Rows.Count - 1).Value = row.Item("id")
                    dgv(1, .Rows.Count - 1).Value = row.Item("idsubcuenta")
                    dgv(2, .Rows.Count - 1).Value = row.Item("subcuenta")
                    dgv(3, .Rows.Count - 1).Value = row.Item("idcargo")
                    dgv(4, .Rows.Count - 1).Value = row.Item("cargo")
                    dgv(5, .Rows.Count - 1).Value = row.Item("estado")
                Next
            End If
        End With
    End Sub

    Private Sub dgvSolicitudFacturacion_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSolicitudFacturacion.RowEnter
        If Me.btnNuevoFacturacion.Enabled Then
            MostrarSolicitudTipoFacturacion(e.RowIndex)
            Me.btnModificarFacturacion.Enabled = dgvSolicitudFacturacion.Rows(e.RowIndex).Cells("idestado").Value = 1
            Me.btnAnularFacturacion.Enabled = dgvSolicitudFacturacion.Rows(e.RowIndex).Cells("idestado").Value = 1
        End If

        Dim intCliente As Integer = Me.dgvClienteFacturacion.CurrentRow.Cells("id").Value
        ListarClienteCargo(intCliente, dgvFacturacion3)
    End Sub

    Private Sub dgvListaFacturacion_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvListaFacturacion.DoubleClick
        If Me.dgvListaFacturacion.Rows.Count > 0 Then
            Me.tabTipoFacturacion.SelectedTab = Me.tabTipoFacturacion.TabPages("tabAprobacionFacturacion")
            Me.tabTipoFacturacion_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub dgvListaFacturacion_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaFacturacion.RowEnter
        With dgvListaFacturacion
            If .Rows.Count > 0 Then
                'BtnAceptar.Enabled = True

                Dim row As DataGridViewRow = .Rows(e.RowIndex)

                Me.lblCodigoFacturacion.Text = row.Cells("codigo").Value
                Me.lblRazonSocialFacturacion.Text = row.Cells("cliente").Value

                Me.lblFuncionarioFacturacionAprobacion.Text = row.Cells("solicitante").Value

                Me.lblFacturacionAprobacion.Text = row.Cells("tipo_facturacion").Value
                Me.lblContactoFacturacion.Text = row.Cells("contacto").Value
                Me.chkOrdenCompraAprobacion.Checked = IIf(row.Cells("orden_compra").Value = 1, True, False)
                Me.chkLiquidacionDocumentoAprobacion.Checked = IIf(row.Cells("liquidacion_documento").Value = 1, True, False)

                Me.lblObservacionTipoFacturacion.Text = row.Cells("observacion").Value

                If row.Cells("idtipo_facturacion").Value = 3 Then
                    Dim intCliente As Integer = Me.dgvListaFacturacion.Rows(e.RowIndex).Cells("idcliente").Value
                    ListarClienteCargo(intCliente, dgvFacturacion3Aprobacion)
                    Me.grbFacturacion3Aprobacion.Visible = True
                Else
                    Me.grbFacturacion3Aprobacion.Visible = False
                End If
            End If
        End With
    End Sub

    Private Sub AprobarSolicitudTipoFacturacion()
        Cursor = Cursors.WaitCursor
        Try
            Dim objEN As New Cls_ClienteTipoFacturacion_EN
            Dim objLN As New Cls_ClienteTipoFacturacion_LN

            Dim intID As Integer = Me.dgvListaFacturacion.CurrentRow.Cells("id").Value
            Dim intCliente As Integer = Me.dgvListaFacturacion.CurrentRow.Cells("idcliente").Value
            Dim intTipoFacturacion As Integer = Me.dgvListaFacturacion.CurrentRow.Cells("idtipo_facturacion").Value
            Dim strFecha As String = Me.dtpFechaActivacionFacturacion.Value.ToShortDateString

            Dim intContacto As Integer = Me.dgvListaFacturacion.CurrentRow.Cells("idcontacto").Value
            Dim intOrdenCompra As Integer = IIf(intTipoFacturacion = 3, Me.dgvListaFacturacion.CurrentRow.Cells("orden_compra").Value, 0)
            Dim intLiquidacionDocumento As Integer = IIf(intTipoFacturacion = 3, Me.dgvListaFacturacion.CurrentRow.Cells("liquidacion_documento").Value, 0)

            objEN.ID = intID
            objEN.Cliente = intCliente
            objEN.TipoFacturacion = intTipoFacturacion
            objEN.Fecha = strFecha
            objEN.Contacto = intContacto
            objEN.OrdenCompra = intOrdenCompra
            objEN.LiquidacionDocumento = intLiquidacionDocumento

            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP

            objLN.AprobarSolicitud(objEN)
            MessageBox.Show("Solicitud Aprobada", "Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub DesaprobarSolicitudTipoFacturacion()
        Dim objEN As New Cls_ClienteTipoFacturacion_EN
        Dim objLN As New Cls_ClienteTipoFacturacion_LN

        objEN.ID = Me.dgvListaFacturacion.CurrentRow.Cells("id").Value
        objEN.Observacion = Me.txtObservacionFacturacion.Text.Trim
        objEN.Usuario = dtoUSUARIOS.IdLogin
        objEN.IP = dtoUSUARIOS.IP

        objLN.DesaprobarSolicitud(objEN)
    End Sub

    Private Sub btnAceptarTipoFacturacion_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptarTipoFacturacion.Click
        Try
            If Me.rbtSiTipoFacturacion.Checked Then
                Dim strFechaActual As Date = FechaServidor()
                'If Date.Compare(strFechaActual.Date.ToShortDateString, Me.dtpFechaActivacionFacturacion.Text) >= 1 Then
                If Month(dtpFechaActivacionFacturacion.Value) <> Month(Now) Then
                    MessageBox.Show("La Fecha de Corte " & Format(Me.dtpFechaActivacionFacturacion.Value, "short date") & " debe estar en el mismo mes de la " & Chr(13) & "Fecha Actual " & Format(strFechaActual, "short date"), "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.dtpFechaActivacionProducto.Focus()
                    Return
                End If
            Else
                If Me.txtObservacionFacturacion.Text.Trim.Length = 0 Then
                    MessageBox.Show("Debe Ingresar Motivo de la Desaprobación", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtObservacionFacturacion.Text = ""
                    Me.txtObservacionFacturacion.Focus()
                    Return
                End If
            End If

            If Me.rbtSiTipoFacturacion.Checked Then 'aprueba
                Dim strMensaje As String = "¿Está Seguro de Aprobar la Solicitud con:" & Chr(13) & Chr(13) & "Fecha de Corte : " & Me.dtpFechaActivacionFacturacion.Value.ToShortDateString & "?"
                Dim intRespuesta As DialogResult = MessageBox.Show(strMensaje, "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If intRespuesta = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    'Dim intOpcion As Integer = IIf(Me.RbtSi.Checked, 1, 2)
                    AprobarSolicitudTipoFacturacion()
                    Me.ListarSolicitudesPendientesFacturacion()
                    tabTipoFacturacion.SelectedTab = tabTipoFacturacion.TabPages("tabListaFacturacion")
                    Cursor = Cursors.Default
                End If
            Else 'desaprueba
                If MessageBox.Show("¿Está Seguro de Desaprobar la Solicitud?", "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    DesaprobarSolicitudTipoFacturacion()
                    MessageBox.Show("Solicitud Desaprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitudesPendientesFacturacion()
                    tabTipoFacturacion.SelectedTab = tabTipoFacturacion.TabPages("tabListaFacturacion")
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtSiTipoFacturacion_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtSiTipoFacturacion.CheckedChanged
        Me.txtObservacionTipoFacturacion.Enabled = False
        Me.txtObservacionTipoFacturacion.Text = ""
        Me.btnAceptarTipoFacturacion.Text = "&Aprobar"
        Me.dtpFechaActivacionFacturacion.Enabled = True
        Me.txtObservacionTipoFacturacion.Focus()
    End Sub

    Private Sub btnNuevoContacto_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevoContacto.Click
        intOperacion = Operacion.Nuevo
        Me.LimpiarContacto()
        Me.chkActivoContacto.Enabled = False
        ActivaDesactivaContacto(1, dgvContactos.Rows.Count)
        Me.cboSubcuentaContacto.Focus()
        'Me.cboSubcuentaContacto.DroppedDown = True
    End Sub

    Private Sub btnCancelarContacto_Click(sender As Object, e As System.EventArgs) Handles btnCancelarContacto.Click
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

    Private Sub btnModificarContacto_Click(sender As Object, e As System.EventArgs) Handles btnModificarContacto.Click
        intOperacion = Operacion.Modificar
        Me.chkActivoContacto.Enabled = True
        ActivaDesactivaContacto(1, dgvContactos.Rows.Count)
        Me.txtNombresContacto.Focus()
    End Sub

    Private Sub btnGrabarContacto_Click(sender As Object, e As System.EventArgs) Handles btnGrabarContacto.Click
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

    Private Sub cboEstadoContacto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstadoContacto.SelectedIndexChanged
        If blnInicioContacto Then Return
        If Me.dgvClientes.Rows.Count <= 0 Then Return
        Dim intCliente As Integer = Me.dgvClientes.CurrentRow.Cells("id").Value
        ListarContactoCliente(intCliente, Me.cboEstadoContacto.SelectedIndex)
        Me.btnModificarContacto.Enabled = Me.dgvContactos.Rows.Count > 0
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

    Private Sub dgvComunicacionContacto_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvComunicacionContacto.KeyDown
        If e.KeyCode = Keys.Delete Then
            If dgvComunicacionContacto.Rows.Count > 0 Then
                Me.btnEliminarComunicacion_Click(Nothing, Nothing)
            End If
        End If
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

    Private Sub dgvComunicacionContacto_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub dgvClienteProductoDetalleDesactivar_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClienteProductoDetalleDesactivar.RowEnter
        With dgvClienteProductoDetalleDesactivar
            If .Rows.Count > 0 Then
                Dim intFila As Integer = e.RowIndex
                Dim intEstado As Integer = .Rows(intFila).Cells("idcontado").Value
                If intEstado = 0 Then
                    Me.btnDesactivarPoductoContado.Enabled = False
                    Me.btnDesactivarProducto.Enabled = True
                Else
                    Me.btnDesactivarPoductoContado.Enabled = True
                    Me.btnDesactivarProducto.Enabled = False
                End If
            End If
        End With
    End Sub

    Sub DesactivarProductoContado(id As Integer, cliente As Integer, producto As Integer)
        Try
            Dim objLN As New Cls_ClienteProducto_LN
            Dim objEN As New Cls_ClienteProducto_EN

            objEN.ID = id
            objEN.Cliente = cliente
            objEN.Producto = producto
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP
            objLN.DesactivarProducto(objEN)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDesactivarPoductoContado_Click(sender As System.Object, e As System.EventArgs) Handles btnDesactivarPoductoContado.Click
        Dim dlgRespuesta As DialogResult = MessageBox.Show("¿Está Seguro de Desactivar el Producto para la Venta Contado?", "Desactivar Producto Contado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = vbYes Then
            Dim intID As Integer = Me.dgvClienteProductoDetalleDesactivar.CurrentRow.Cells("id").Value
            Dim intCliente As Integer = Me.dgvClienteProductoDesactivar.CurrentRow.Cells("id").Value
            Dim intProducto As Integer = Me.dgvClienteProductoDetalleDesactivar.CurrentRow.Cells("idproducto").Value
            Me.DesactivarProductoContado(intID, intCliente, intProducto)
            ActualizardgvClienteProductoDesactivar(dgvClienteProductoDesactivar.CurrentCell.RowIndex)
            MessageBox.Show("Producto Desactivado", "Desactivar Producto Contado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cboSubcuentaProducto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSubcuentaProducto.SelectedIndexChanged
    End Sub

    Sub AgregarAcuerdo(frm As FrmAgregarAcuerdoCliente, Optional opcion As Integer = 1)
        If opcion = 1 Then
            Me.dgvAcuerdoCliente.Rows.Add()
            Me.dgvAcuerdoCliente(0, Me.dgvAcuerdoCliente.Rows.Count - 1).Value = 0
            Me.dgvAcuerdoCliente(1, Me.dgvAcuerdoCliente.Rows.Count - 1).Value = cboProductoCliente.SelectedValue
            Me.dgvAcuerdoCliente(2, Me.dgvAcuerdoCliente.Rows.Count - 1).Value = cboProductoCliente.Text
            Me.dgvAcuerdoCliente(3, Me.dgvAcuerdoCliente.Rows.Count - 1).Value = frm.cboSubcuenta.SelectedValue
            Me.dgvAcuerdoCliente(4, Me.dgvAcuerdoCliente.Rows.Count - 1).Value = frm.cboSubcuenta.Text
            Me.dgvAcuerdoCliente(5, Me.dgvAcuerdoCliente.Rows.Count - 1).Value = frm.cboOrigen.SelectedValue
            Me.dgvAcuerdoCliente(6, Me.dgvAcuerdoCliente.Rows.Count - 1).Value = frm.cboOrigen.Text
            Me.dgvAcuerdoCliente(7, Me.dgvAcuerdoCliente.Rows.Count - 1).Value = frm.cboDestino.SelectedValue
            Me.dgvAcuerdoCliente(8, Me.dgvAcuerdoCliente.Rows.Count - 1).Value = frm.cboDestino.Text
            Me.dgvAcuerdoCliente(9, Me.dgvAcuerdoCliente.Rows.Count - 1).Value = frm.cboTipoTarifa.SelectedValue
            Me.dgvAcuerdoCliente(10, Me.dgvAcuerdoCliente.Rows.Count - 1).Value = frm.cboTipoTarifa.Text
            Me.dgvAcuerdoCliente(11, Me.dgvAcuerdoCliente.Rows.Count - 1).Value = IIf(frm.chkRetorno.Checked, 1, 0)
            Me.dgvAcuerdoCliente(12, Me.dgvAcuerdoCliente.Rows.Count - 1).Value = frm.txtDiasTransito.Text.Trim
            Me.dgvAcuerdoCliente(13, Me.dgvAcuerdoCliente.Rows.Count - 1).Value = 0
        Else
            Me.dgvAcuerdoCliente.CurrentRow.Cells(1).Value = cboProductoCliente.SelectedValue
            Me.dgvAcuerdoCliente.CurrentRow.Cells(2).Value = cboProductoCliente.Text
            Me.dgvAcuerdoCliente.CurrentRow.Cells(3).Value = frm.cboSubcuenta.SelectedValue
            Me.dgvAcuerdoCliente.CurrentRow.Cells(4).Value = frm.cboSubcuenta.Text
            Me.dgvAcuerdoCliente.CurrentRow.Cells(5).Value = frm.cboOrigen.SelectedValue
            Me.dgvAcuerdoCliente.CurrentRow.Cells(6).Value = frm.cboOrigen.Text
            Me.dgvAcuerdoCliente.CurrentRow.Cells(7).Value = frm.cboDestino.SelectedValue
            Me.dgvAcuerdoCliente.CurrentRow.Cells(8).Value = frm.cboDestino.Text
            Me.dgvAcuerdoCliente.CurrentRow.Cells(9).Value = frm.cboTipoTarifa.SelectedValue
            Me.dgvAcuerdoCliente.CurrentRow.Cells(10).Value = frm.cboTipoTarifa.Text
            Me.dgvAcuerdoCliente.CurrentRow.Cells(11).Value = IIf(frm.chkRetorno.Checked, 1, 0)
            Me.dgvAcuerdoCliente.CurrentRow.Cells(12).Value = frm.txtDiasTransito.Text.Trim
        End If
    End Sub

    Private Sub dgvAcuerdoCliente_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvAcuerdoCliente.DoubleClick
        If Me.dgvAcuerdoCliente.Rows.Count > 0 Then
            Dim frm As New FrmAgregarAcuerdoCliente
            frm.Opcion = 2
            frm.IDCliente = Me.dgvClientes.CurrentRow.Cells("id").Value
            frm.Cliente = Me.dgvClientes.CurrentRow.Cells("cliente").Value
            frm.IDProducto = Me.cboProductoCliente.SelectedValue
            frm.Producto = Me.cboProductoCliente.Text
            frm.Subcuenta = Me.dgvAcuerdoCliente.CurrentRow.Cells("idsubcuenta").Value
            frm.Origen = Me.dgvAcuerdoCliente.CurrentRow.Cells("idorigen").Value
            frm.Destino = Me.dgvAcuerdoCliente.CurrentRow.Cells("iddestino").Value
            frm.TipoTarifa = Me.dgvAcuerdoCliente.CurrentRow.Cells("idtipo_tarifa").Value
            frm.Retorno = Me.dgvAcuerdoCliente.CurrentRow.Cells("retorno").Value
            frm.Tiempo = Me.dgvAcuerdoCliente.CurrentRow.Cells("tiempo").Value
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                AgregarAcuerdo(frm, 2)
            End If
        End If
    End Sub

    Private Sub dgvAcuerdoCliente_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvAcuerdoCliente.KeyDown
        If e.KeyCode = Keys.Delete Then
            If dgvAcuerdoCliente.Rows.Count > 0 Then
                Me.btnEliminarAcuerdoCliente_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub dgvAcuerdoCliente_RowsAdded(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvAcuerdoCliente.RowsAdded
        Me.btnEliminarAcuerdoCliente.Enabled = Me.dgvAcuerdoCliente.Rows.Count > 0
        Me.btnGrabarAcuerdoCliente.Enabled = Me.dgvAcuerdoCliente.Rows.Count > 0
    End Sub

    Private Sub dgvAcuerdoCliente_RowsRemoved(sender As Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvAcuerdoCliente.RowsRemoved
        Me.btnEliminarAcuerdoCliente.Enabled = Me.dgvAcuerdoCliente.Rows.Count > 0
        Me.btnGrabarAcuerdoCliente.Enabled = Me.dgvAcuerdoCliente.Rows.Count > 0
    End Sub

    Sub ListarClienteAcuerdo(cliente As Integer, producto As Integer)
        Dim objLN As New Cls_ClienteProducto_LN()
        Dim dt As DataTable = objLN.ListarClienteAcuerdo(cliente, producto)
        With Me.dgvAcuerdoCliente
            .Rows.Clear()
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .Rows.Add()
                    Me.dgvAcuerdoCliente(0, .Rows.Count - 1).Value = row.Item("id")
                    Me.dgvAcuerdoCliente(1, .Rows.Count - 1).Value = row.Item("idproducto")
                    Me.dgvAcuerdoCliente(2, .Rows.Count - 1).Value = row.Item("producto")
                    Me.dgvAcuerdoCliente(3, .Rows.Count - 1).Value = row.Item("idsubcuenta")
                    Me.dgvAcuerdoCliente(4, .Rows.Count - 1).Value = row.Item("subcuenta")
                    Me.dgvAcuerdoCliente(5, .Rows.Count - 1).Value = row.Item("idorigen")
                    Me.dgvAcuerdoCliente(6, .Rows.Count - 1).Value = row.Item("origen")
                    Me.dgvAcuerdoCliente(7, .Rows.Count - 1).Value = row.Item("iddestino")
                    Me.dgvAcuerdoCliente(8, .Rows.Count - 1).Value = row.Item("destino")
                    Me.dgvAcuerdoCliente(9, .Rows.Count - 1).Value = row.Item("idtipo_tarifa")
                    Me.dgvAcuerdoCliente(10, .Rows.Count - 1).Value = row.Item("tipo_tarifa")
                    Me.dgvAcuerdoCliente(11, .Rows.Count - 1).Value = row.Item("retorno")
                    Me.dgvAcuerdoCliente(12, .Rows.Count - 1).Value = row.Item("tiempo")
                    Me.dgvAcuerdoCliente(13, .Rows.Count - 1).Value = row.Item("estado")
                Next
            End If
        End With
    End Sub

    Private Sub BuscarCliente(cliente As String, opcion As Integer, Optional usuario As Integer = 0)
        Try
            If opcion = 1 Then
                If Me.txtNumeroDocumento.Text.Trim.Length = 11 Then
                    If Not fnValidarRUC(cliente) Then
                        MessageBox.Show("El RUC no es Válido", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtNumeroDocumento.Focus()
                        Me.txtNumeroDocumento.SelectAll()
                        Return
                    End If
                ElseIf Me.txtNumeroDocumento.Text.Trim.Length <> 8 Then
                    MessageBox.Show("El DNI no es Válido", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            Dim dt As DataTable = obj.BuscarCliente(cliente, opcion, usuario)

            If usuario = 0 Then
                Cursor = Cursors.Default
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("No se encontraron coincidencias", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Me.cboFuncionario.SelectedValue = 0
                    Me.dgvClientes.DataSource = dt
                End If
            Else
                Cursor = Cursors.Default
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("No se encontraron coincidencias", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Me.dgvClientes.DataSource = dt
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

    Private Sub txtUsuarioWeb_Enter(sender As Object, e As System.EventArgs) Handles txtUsuarioWeb.Enter
        Me.txtUsuarioWeb.SelectAll()
    End Sub

    Private Sub txtContraseñaWeb_Enter(sender As Object, e As System.EventArgs) Handles txtContraseñaWeb.Enter
        Me.txtContraseñaWeb.SelectAll()
    End Sub

    Private Sub txtSerieDocumento_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerieDocumento.KeyPress
        If Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDescuento_LostFocus(sender As Object, e As System.EventArgs) Handles txtDescuento.LostFocus
        Dim dblDescuento As Double = IIf(Me.txtDescuento.Text.Trim.Length = 0, 0, Me.txtDescuento.Text.Trim)
        Me.txtDescuento.Text = Format(dblDescuento, "0.00")
    End Sub

    Private Sub cboFuncionarioConsulta_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboFuncionarioConsulta.SelectedIndexChanged
        If IsReference(cboFuncionarioConsulta.SelectedValue) Then Return
        'blnInicioCliente = True
        LimpiarGeneralConsulta()
        LimpiarDetalleConsulta()
        LimpiarLineaCreditoConsulta()
        CargarCartera(Me.cboFuncionarioConsulta.SelectedValue, dgvClientesConsulta)
        If Me.dgvClientesConsulta.Rows.Count > 0 Then
            Me.txtNumeroDocumentoConsulta.Text = ""
            Me.txtRazonSocialConsulta.Text = ""
        End If
        'dgvClientes_RowEnter(Nothing, Nothing)
    End Sub

    Private Sub txtNumeroDocumentoConsulta_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumeroDocumentoConsulta.TextChanged
        RemoveHandler txtRazonSocialConsulta.TextChanged, AddressOf txtRazonSocialConsulta_TextChanged
        Me.txtRazonSocialConsulta.Text = ""
        AddHandler txtRazonSocialConsulta.TextChanged, AddressOf txtRazonSocialConsulta_TextChanged
    End Sub

    Private Sub txtRazonSocialConsulta_Enter(sender As Object, e As System.EventArgs) Handles txtRazonSocialConsulta.Enter
        Me.txtRazonSocialConsulta.SelectAll()
    End Sub

    Private Sub txtRazonSocialConsulta_TextChanged(sender As Object, e As System.EventArgs) Handles txtRazonSocialConsulta.TextChanged
        RemoveHandler txtNumeroDocumentoConsulta.TextChanged, AddressOf txtNumeroDocumentoConsulta_TextChanged
        Me.txtNumeroDocumentoConsulta.Text = ""
        AddHandler txtNumeroDocumentoConsulta.TextChanged, AddressOf txtNumeroDocumentoConsulta_TextChanged
    End Sub

    Private Sub dgvClientesConsulta_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClientesConsulta.RowEnter
        'If blnInicioCliente Then
        '    blnInicioCliente = False
        '    Return
        'End If
        Dim intCliente As Integer
        Try
            intCliente = Me.dgvClientesConsulta.Rows(e.RowIndex).Cells("id").Value
            If tabConsulta2.SelectedTab.Name.ToLower = "tabgeneralconsulta" Then
                MostrarClienteConsulta(intCliente, 0)
            ElseIf tabConsulta2.SelectedTab.Name.ToLower = "tablineacreditoconsulta" Then
                MostrarClienteConsulta(intCliente, 1)
            ElseIf tabConsulta2.SelectedTab.Name.ToLower = "tabdetalleconsulta" Then
                MostrarClienteConsulta(intCliente, 2)
            End If

            If Me.cboFuncionarioConsulta.SelectedValue = 0 Then
                Me.lblFuncionarioConsulta.Text = dgvClientesConsulta.Rows(e.RowIndex).Cells("funcionario").Value
            Else
                Me.lblFuncionarioConsulta.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub MostrarClienteConsulta(cliente As Integer, opcion As Integer, Optional item As Integer = 0)
        Try
            Dim objLN As New Cls_Cliente_LN
            If opcion = 0 Then 'general
                Me.LimpiarGeneralConsulta()
                Dim ds As DataSet = objLN.ConsultaCliente(cliente)

                Me.lblTipoPersonaConsulta.Text = ds.Tables(0).Rows(0).Item("tipo_persona").ToString
                Me.lblClienteConsulta.Text = ds.Tables(0).Rows(0).Item("cliente").ToString
                Me.lblDocumentoConsulta.Text = ds.Tables(0).Rows(0).Item("documento").ToString
                Me.lblFechaIngresoConsulta.Text = Format(CType(ds.Tables(0).Rows(0).Item("fecha_ingreso").ToString, Date), "short date")
                Me.lblDescuentoConsulta.Text = Format(CType(ds.Tables(0).Rows(0).Item("descuento").ToString, Double), "0.00")

                Me.dgvContactoConsulta.DataSource = ds.Tables(1)
                Me.dgvDireccionConsulta.DataSource = ds.Tables(2)
            ElseIf opcion = 1 Then 'linea de credito
                LimpiarLineaCreditoConsulta()
                Dim intIDEstado As Integer, strEstado As String, intCtaCte As Integer
                EstadoActualLineaCredito(cliente, intIDEstado, strEstado, intCtaCte)
                Me.lblEstadoCreditoConsulta.Text = strEstado
                Me.lblEstadoCreditoConsulta.Tag = intCtaCte

                Dim ds As DataSet = objLN.ConsultaCliente(cliente)
                ds = objLN.ConsultaClienteDetalle(cliente, 2, EstadoLineaCredito(cboEstadoCreditoConsulta.SelectedIndex))
                Me.dgvCreditoConsulta.DataSource = ds.Tables(1)

                Dim ObjFactura As New ClsLbTepsa.dtoFACTURA
                ObjFactura.IDPERSONA = cliente
                Me.dgvCreditoDetalleConsulta.DataSource = ObjFactura.sp_get_linea_credito_resumen.Tables(0).DefaultView

            Else 'detalle
                Me.LimpiarDetalleConsulta()
                Dim ds As DataSet = objLN.ConsultaClienteDetalle(cliente, 0, 0, Me.cboEstadoCarteraConsulta.SelectedIndex, Me.cboEstadoProductoConsulta.SelectedIndex, Me.cboEstadoTipoFacturacionConsulta.SelectedIndex)
                Me.dgvCarteraConsulta.DataSource = ds.Tables(0)
                Me.dgvProductoConsulta.DataSource = ds.Tables(2)
                Me.dgvTipoFacturacionConsulta.DataSource = ds.Tables(3)

                If ds.Tables(3).Rows.Count > 0 Then
                    Me.chkOrdenCompraConsulta.Checked = IIf(ds.Tables(3).Rows(0).Item("orden_compra") = 1, True, False)
                    Me.chkLiquidacionDocumentoConsulta.Checked = IIf(ds.Tables(3).Rows(0).Item("liquidacion_documento") = 1, True, False)
                    ListarClienteCargo(cliente, dgvCargoConsulta)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tabConsulta2_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabConsulta2.SelectedIndexChanged
        If Me.dgvClientesConsulta.Rows.Count > 0 Then
            Dim intCliente As Integer
            Try
                intCliente = Me.dgvClientesConsulta.CurrentRow.Cells("id").Value
                If tabConsulta2.SelectedTab.Name.ToLower = "tabgeneralconsulta" Then
                    MostrarClienteConsulta(intCliente, 0)
                ElseIf tabConsulta2.SelectedTab.Name.ToLower = "tablineacreditoconsulta" Then
                    MostrarClienteConsulta(intCliente, 1)
                ElseIf tabConsulta2.SelectedTab.Name.ToLower = "tabdetalleconsulta" Then
                    MostrarClienteConsulta(intCliente, 2)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Sub LimpiarGeneralConsulta()
        Me.lblTipoPersonaConsulta.Text = ""
        Me.lblClienteConsulta.Text = ""
        Me.lblDocumentoConsulta.Text = ""
        Me.lblFechaIngresoConsulta.Text = ""
        Me.lblDescuentoConsulta.Text = ""
        Me.dgvContactoConsulta.DataSource = Nothing
        Me.dgvDireccionConsulta.DataSource = Nothing
    End Sub

    Sub LimpiarLineaCreditoConsulta()
        Me.dgvCreditoConsulta.DataSource = Nothing
        Me.dgvCreditoDetalleConsulta.DataSource = Nothing
        lblEstadoCreditoConsulta.Text = ""
    End Sub

    Sub LimpiarDetalleConsulta()
        Me.dgvCarteraConsulta.DataSource = Nothing
        Me.dgvProductoConsulta.DataSource = Nothing
        Me.dgvTipoFacturacionConsulta.DataSource = Nothing
        Me.dgvCargoConsulta.DataSource = Nothing
        Me.chkOrdenCompraConsulta.Checked = False
        Me.chkLiquidacionDocumentoConsulta.Checked = False
    End Sub

    Private Sub dgvClientes_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub dgvClienteProducto_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub cboTipoFacturacionSolicitud_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoFacturacionSolicitud.SelectedIndexChanged
        If IsReference(Me.cboTipoFacturacionSolicitud.SelectedValue) Then Return
        If Me.cboTipoFacturacionSolicitud.SelectedValue = 3 Then
            Me.grbFacturacion3.Enabled = True
            Me.dgvFacturacion3.Rows.Clear()
            Dim intCliente As Integer = Me.dgvClienteFacturacion.CurrentRow.Cells("id").Value
            ListarClienteCargo(intCliente, dgvFacturacion3)
        Else
            Me.grbFacturacion3.Enabled = False
            Me.dgvFacturacion3.Rows.Clear()
        End If
    End Sub

    Private Sub btnAgregarCargo_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarCargo.Click
        Dim frm As New FrmAgregarCargo
        frm.IDCliente = Me.dgvClienteFacturacion.CurrentRow.Cells(0).Value
        frm.Cliente = Me.lblClienteFacturacion.Text.Trim
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            If Not dtoUtilitario.ExisteValorGrid(Me.dgvFacturacion3, frm.cboCargo.SelectedValue, 3) Then
                AgregarCargo(frm)
            Else
                MessageBox.Show("El Cargo " & frm.cboCargo.Text & " ya existe en la lista", "Agregar Cargo a Retornar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnAgregarCargo.Focus()
            End If
        End If
    End Sub

    Sub AgregarCargo(frm As FrmAgregarCargo, Optional opcion As Integer = 1)
        If opcion = 1 Then
            Me.dgvFacturacion3.Rows.Add()
            Me.dgvFacturacion3(0, Me.dgvFacturacion3.Rows.Count - 1).Value = 0
            Me.dgvFacturacion3(1, Me.dgvFacturacion3.Rows.Count - 1).Value = frm.cboSubcuenta.SelectedValue
            Me.dgvFacturacion3(2, Me.dgvFacturacion3.Rows.Count - 1).Value = frm.cboSubcuenta.Text
            Me.dgvFacturacion3(3, Me.dgvFacturacion3.Rows.Count - 1).Value = frm.cboCargo.SelectedValue
            Me.dgvFacturacion3(4, Me.dgvFacturacion3.Rows.Count - 1).Value = frm.cboCargo.Text
            Me.dgvFacturacion3(5, Me.dgvFacturacion3.Rows.Count - 1).Value = 0
        Else
            Me.dgvFacturacion3.CurrentRow.Cells(1).Value = frm.cboSubcuenta.SelectedValue
            Me.dgvFacturacion3.CurrentRow.Cells(2).Value = frm.cboSubcuenta.Text
            Me.dgvFacturacion3.CurrentRow.Cells(3).Value = frm.cboCargo.SelectedValue
            Me.dgvFacturacion3.CurrentRow.Cells(4).Value = frm.cboCargo.Text
        End If
    End Sub

    Private Sub btnEliminarCargo_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarCargo.Click
        With dgvFacturacion3
            If .Rows.Count > 0 Then
                Dim dlgRespuesta As DialogResult = MessageBox.Show("¿Está Seguro de Desactivar el Cargo Seleccionado?", "Desactivar Cargo del Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                    If dgvFacturacion3.CurrentRow.Cells("estado").Value = 0 Then
                        .Rows.Remove(.CurrentRow)
                    Else
                        dgvFacturacion3.CurrentRow.Cells("estado").Value = 2
                        dgvFacturacion3.CurrentRow.Visible = False
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub dgvFacturacion3_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvFacturacion3.KeyDown
        If e.KeyCode = Keys.Delete Then
            If dgvFacturacion3.Rows.Count > 0 Then
                Me.btnEliminarCargo_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub dgvFacturacion3_RowsAdded(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvFacturacion3.RowsAdded
        Me.btnEliminarCargo.Enabled = Me.dgvFacturacion3.Rows.Count > 0
    End Sub

    Private Sub dgvFacturacion3_RowsRemoved(sender As Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvFacturacion3.RowsRemoved
        Me.btnEliminarCargo.Enabled = Me.dgvFacturacion3.Rows.Count > 0
    End Sub

    Private Sub dgvSolicitudCartera_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub dgvClienteCredito_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub dgvSolicitudCredito_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Sub AgregarCargoCredito(frm As FrmAgregarCargo, Optional opcion As Integer = 1)
        If opcion = 1 Then
            Me.dgvFacturacion3Credito.Rows.Add()
            Me.dgvFacturacion3Credito(0, Me.dgvFacturacion3Credito.Rows.Count - 1).Value = 0
            Me.dgvFacturacion3Credito(1, Me.dgvFacturacion3Credito.Rows.Count - 1).Value = frm.cboSubcuenta.SelectedValue
            Me.dgvFacturacion3Credito(2, Me.dgvFacturacion3Credito.Rows.Count - 1).Value = frm.cboSubcuenta.Text
            Me.dgvFacturacion3Credito(3, Me.dgvFacturacion3Credito.Rows.Count - 1).Value = frm.cboCargo.SelectedValue
            Me.dgvFacturacion3Credito(4, Me.dgvFacturacion3Credito.Rows.Count - 1).Value = frm.cboCargo.Text
            Me.dgvFacturacion3Credito(5, Me.dgvFacturacion3Credito.Rows.Count - 1).Value = 0
        Else
            Me.dgvFacturacion3Credito.CurrentRow.Cells(1).Value = frm.cboSubcuenta.SelectedValue
            Me.dgvFacturacion3Credito.CurrentRow.Cells(2).Value = frm.cboSubcuenta.Text
            Me.dgvFacturacion3Credito.CurrentRow.Cells(3).Value = frm.cboCargo.SelectedValue
            Me.dgvFacturacion3Credito.CurrentRow.Cells(4).Value = frm.cboCargo.Text
        End If
    End Sub

    Private Sub btnAgregarCargoCredito_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarCargoCredito.Click
        Dim frm As New FrmAgregarCargo
        frm.IDCliente = Me.dgvClienteCredito.CurrentRow.Cells(0).Value
        frm.Cliente = Me.lblClienteCredito.Text.Trim
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            If Not dtoUtilitario.ExisteValorGrid(Me.dgvFacturacion3Credito, frm.cboCargo.SelectedValue, 3) Then
                AgregarCargoCredito(frm)
            Else
                MessageBox.Show("El Cargo " & frm.cboCargo.Text & " ya existe en la lista", "Agregar Cargo a Retornar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnAgregarCargoCredito.Focus()
            End If
        End If
    End Sub

    Private Sub cboTipoFacturacionCredito_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoFacturacionCredito.SelectedIndexChanged
        If IsReference(Me.cboTipoFacturacionCredito.SelectedValue) Then Return
        If Me.cboTipoFacturacionCredito.SelectedValue <> 33 Then
            Me.btnAgregarCargoCredito.Enabled = True
            Me.btnEliminarCargoCredito.Enabled = True
            'hlamas 08-04-2016
            'Me.chkOrdenCompraCredito.Enabled = True
            'Me.chkLiquidacionDocumentoCredito.Enabled = True
            Me.dgvFacturacion3Credito.Rows.Clear()
            Dim intCliente As Integer = Me.dgvClienteCredito.CurrentRow.Cells("id").Value
            ListarClienteCargo(intCliente, dgvFacturacion3Credito)
        Else
            Me.btnAgregarCargoCredito.Enabled = False
            Me.btnEliminarCargoCredito.Enabled = False
            'hlamas 08-04-2016
            'Me.chkOrdenCompraCredito.Enabled = False
            'Me.chkLiquidacionDocumentoCredito.Enabled = False
            Me.dgvFacturacion3Credito.Rows.Clear()
        End If
    End Sub

    Private Sub btnEliminarCargoCredito_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarCargoCredito.Click
        With dgvFacturacion3Credito
            If .Rows.Count > 0 Then
                Dim dlgRespuesta As DialogResult = MessageBox.Show("¿Está Seguro de Desactivar el Cargo Seleccionado?", "Desactivar Cargo del Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                    If dgvFacturacion3Credito.CurrentRow.Cells("estado").Value = 0 Then
                        .Rows.Remove(.CurrentRow)
                    Else
                        dgvFacturacion3Credito.CurrentRow.Cells("estado").Value = 2
                        dgvFacturacion3Credito.CurrentRow.Visible = False
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub dgvFacturacion3Credito_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvFacturacion3Credito.KeyDown
        If e.KeyCode = Keys.Delete Then
            If dgvFacturacion3Credito.Rows.Count > 0 Then
                Me.btnEliminarCargoCredito_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub btnAgregarAcuerdoCliente_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarAcuerdoCliente.Click
        Dim frm As New FrmAgregarAcuerdoCliente
        frm.IDCliente = Me.dgvClientes.CurrentRow.Cells("id").Value
        frm.Cliente = Me.dgvClientes.CurrentRow.Cells("cliente").Value
        frm.IDProducto = Me.cboProductoCliente.SelectedValue
        frm.Producto = Me.cboProductoCliente.Text
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim blnExiste As Boolean = False
            For Each row As DataGridViewRow In Me.dgvAcuerdoCliente.Rows
                blnExiste = frm.cboSubcuenta.SelectedValue = row.Cells(3).Value.ToString And frm.cboOrigen.SelectedValue = row.Cells(5).Value.ToString And _
                frm.cboDestino.SelectedValue = row.Cells(7).Value.ToString And frm.cboTipoTarifa.SelectedValue = row.Cells(9).Value.ToString
                If blnExiste Then
                    Exit For
                End If
            Next
            If Not blnExiste Then
                AgregarAcuerdo(frm)
            Else
                MessageBox.Show("El Acuerdo ya existe en la lista", "Agregar Acuerdo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnAgregarAcuerdoCliente.Focus()
            End If
        End If
    End Sub

    Private Sub btnEliminarAcuerdoCliente_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarAcuerdoCliente.Click
        With dgvAcuerdoCliente
            If .Rows.Count > 0 Then
                Dim dlgRespuesta As DialogResult = MessageBox.Show("¿Está Seguro de Desactivar el Acuerdo Seleccionado?", "Desactivar Acuerdo con el Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                    If dgvAcuerdoCliente.CurrentRow.Cells("estado").Value = 0 Then
                        .Rows.Remove(.CurrentRow)
                    Else
                        dgvAcuerdoCliente.CurrentRow.Cells("estado").Value = 2
                        dgvAcuerdoCliente.CurrentRow.Visible = False
                        If .Rows.Count = 1 Then
                            Me.GrabarAcuerdoCliente()
                        End If
                    End If
                End If
            End If
        End With
    End Sub

    Sub GrabarAcuerdoCliente()
        'Actualizar acuerdos con el cliente
        With Me.dgvAcuerdoCliente
            Dim objLN As New Cls_ClienteProducto_LN
            Dim objEN2 As New Cls_ClienteProducto_EN
            Dim intTiempo As Integer
            For Each row As DataGridViewRow In Me.dgvAcuerdoCliente.Rows
                objEN2.ID = IIf(IsDBNull(row.Cells("id").Value), 0, row.Cells("id").Value)
                objEN2.Cliente = Me.dgvClientes.CurrentRow.Cells("id").Value
                objEN2.Producto = row.Cells("idproducto").Value
                objEN2.Subcuenta = row.Cells("idsubcuenta").Value
                objEN2.Origen = row.Cells("idorigen").Value
                objEN2.Destino = row.Cells("iddestino").Value
                objEN2.TipoTarifa = row.Cells("idtipo_tarifa").Value
                objEN2.Retorno = row.Cells("retorno").Value
                intTiempo = row.Cells("tiempo").Value
                objEN2.Estado = row.Cells("estado").Value
                objEN2.Usuario = dtoUSUARIOS.IdLogin
                objEN2.IP = dtoUSUARIOS.IP
                objLN.GrabarAcuerdoCliente(objEN2, intTiempo)
            Next

            Dim intCliente As Integer = Me.dgvClientes.CurrentRow.Cells("id").Value
            Dim intProducto As Integer = Me.cboProductoCliente.SelectedValue
            Me.ListarClienteAcuerdo(intCliente, intProducto)
        End With
    End Sub
    Private Sub btnGrabarAcuerdoCliente_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabarAcuerdoCliente.Click
        GrabarAcuerdoCliente()
        Dim intCliente As Integer = Me.dgvClientes.CurrentRow.Cells("id").Value
        Dim intProducto As Integer = Me.cboProductoCliente.SelectedValue
        Me.ListarClienteAcuerdo(intCliente, intProducto)
        MessageBox.Show("Acuerdo Actualizado", "Grabar Acuerdo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub cboProductoCliente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboProductoCliente.SelectedIndexChanged
        If IsReference(Me.cboProductoCliente.SelectedValue) Then Return
        If Me.dgvClientes.Rows.Count = 0 Then Return
        Dim intCliente As Integer = Me.dgvClientes.CurrentRow.Cells("id").Value
        Dim intProducto As Integer = Me.cboProductoCliente.SelectedValue
        ListarClienteAcuerdo(intCliente, intProducto)

        If Me.cboProductoCliente.SelectedValue = 0 Then
            Me.btnAgregarAcuerdoCliente.Enabled = False
        Else
            Me.btnAgregarAcuerdoCliente.Enabled = True
        End If
    End Sub

    Private Sub cboProductoCredito_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboProductoCredito.SelectedIndexChanged
        If IsReference(cboProductoCredito.SelectedValue) Then Return
        If Me.cboProductoCredito.SelectedValue = 0 Or Me.cboProductoCredito.SelectedValue = 5 Then
            Me.chkContadoCredito.Checked = False
            Me.chkContadoCredito.Enabled = False
        Else
            Me.chkContadoCredito.Enabled = True
        End If
    End Sub

    Private Sub dtpFechaActivacionFacturacion_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaActivacionFacturacion.ValueChanged
        Me.lblMensajeTipoFacturacion.Text = "Los envíos sin facturar ni prefacturar con fecha similar o posterior a " & Me.dtpFechaActivacionFacturacion.Value.ToShortDateString & _
            " se actualizarán a " & Me.lblFacturacionAprobacion.Text
    End Sub

    Private Sub txtRazonSocialCredito_Enter(sender As Object, e As System.EventArgs) Handles txtRazonSocialCredito.Enter
        Me.txtRazonSocialCredito.SelectAll()
    End Sub


    Private Sub cboEstadoCreditoConsulta_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstadoCreditoConsulta.SelectedIndexChanged
        If Me.dgvClientesConsulta.Rows.Count = 0 Then Return
        Dim objLN As New Cls_Cliente_LN
        Dim intCliente As Integer = Me.dgvClientesConsulta.CurrentRow.Cells("id").Value
        Dim ds As DataSet = objLN.ConsultaClienteDetalle(intCliente, 2, EstadoLineaCredito(cboEstadoCreditoConsulta.SelectedIndex))
        Me.dgvCreditoConsulta.DataSource = ds.Tables(1)
    End Sub

    Private Sub cboEstadoCarteraConsulta_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstadoCarteraConsulta.SelectedIndexChanged
        If Me.dgvClientesConsulta.Rows.Count = 0 Then Return
        Dim objLN As New Cls_Cliente_LN
        Dim intCliente As Integer = Me.dgvClientesConsulta.CurrentRow.Cells("id").Value
        Dim ds As DataSet = objLN.ConsultaClienteDetalle(intCliente, 1, cboEstadoCarteraConsulta.SelectedIndex)
        Me.dgvCarteraConsulta.DataSource = ds.Tables(0)
    End Sub

    Private Sub cboEstadoProductoConsulta_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstadoProductoConsulta.SelectedIndexChanged
        If Me.dgvClientesConsulta.Rows.Count = 0 Then Return
        Dim objLN As New Cls_Cliente_LN
        Dim intCliente As Integer = Me.dgvClientesConsulta.CurrentRow.Cells("id").Value
        Dim ds As DataSet = objLN.ConsultaClienteDetalle(intCliente, 3, cboEstadoProductoConsulta.SelectedIndex)
        Me.dgvProductoConsulta.DataSource = ds.Tables(2)
    End Sub

    Private Sub cboEstadoTipoFacturacionConsulta_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstadoTipoFacturacionConsulta.SelectedIndexChanged
        If Me.dgvClientesConsulta.Rows.Count = 0 Then Return
        Dim objLN As New Cls_Cliente_LN
        Dim intCliente As Integer = Me.dgvClientesConsulta.CurrentRow.Cells("id").Value
        Dim ds As DataSet = objLN.ConsultaClienteDetalle(intCliente, 4, cboEstadoTipoFacturacionConsulta.SelectedIndex)
        Me.dgvTipoFacturacionConsulta.DataSource = ds.Tables(3)
    End Sub

    Private Sub btnCondicionCredito_Click(sender As System.Object, e As System.EventArgs) Handles btnCondicionCredito.Click
        Dim frm As New frmCondicionCredito
        frm.IDCliente = Me.dgvClienteCredito.CurrentRow.Cells("id").Value
        frm.Cliente = Me.dgvClienteCredito.CurrentRow.Cells("cliente").Value
        frm.ShowDialog()
    End Sub

    Private Sub txtSustento_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSustento.TextChanged

    End Sub

    Private Sub txtSustentoProducto_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSustentoProducto.TextChanged

    End Sub

    Private Sub AprobarSolicitudCondicionCredito()
        Cursor = Cursors.WaitCursor
        Try
            Dim objEN As New Cls_LineaCredito_EN
            Dim objLN As New Cls_LineaCredito_LN

            Dim intID As Integer = Me.dgvListaCondicion.CurrentRow.Cells("id").Value
            Dim intCliente As Integer = Me.dgvListaCondicion.CurrentRow.Cells("idcliente").Value
            Dim intCondicionCredito As Integer = Me.dgvListaCondicion.CurrentRow.Cells("idcondicion").Value
            Dim strFecha As String = Me.dtpFechaActivacionCondicion.Value.ToShortDateString

            objEN.ID = intID
            objEN.Cliente = intCliente
            objEN.CondicionCobranza = intCondicionCredito
            objEN.Fecha = strFecha
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP

            objLN.AprobarSolicitudCondicionCredito(objEN)
            MessageBox.Show("Solicitud Aprobada", "Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub DesaprobarSolicitudCondicionCredito()
        Dim objEN As New Cls_ClienteFueraZona_EN
        Dim objLN As New Cls_ClienteFueraZona_LN

        objEN.ID = Me.dgvListaZona.CurrentRow.Cells("id").Value
        objEN.Observacion = Me.txtObservacionCondicion.Text.Trim
        objEN.Usuario = dtoUSUARIOS.IdLogin
        objEN.IP = dtoUSUARIOS.IP

        objLN.DesaprobarSolicitud(objEN)
    End Sub

    Sub LimpiarAprobacionCondicionCredito()
        Me.lblCodigoCondicion.Text = ""
        Me.lblRazonSocialCondicion.Text = ""
        Me.lblFuncionarioCondicion.Text = ""
        Me.lblObservacionCondicion.Text = ""
        Me.rbtSiCondicion.Checked = True
        Me.lblCondicionCredito.Text = ""
    End Sub


    Private Sub tabCondicionCredito_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabCondicionCredito.SelectedIndexChanged
        If tabCondicionCredito.SelectedTab Is tabCondicionCredito.TabPages("tabListaCondicion") Then
            ConfigurarDGVListaCondicion()
            Me.ListarSolicitudesPendientesCondicion()
            'ConfigurarDGVClienteFacturacionDetalle()
            intOperacion = Operacion.Nuevo
        ElseIf tabCondicionCredito.SelectedTab Is tabCondicionCredito.TabPages("tabAprobacionCondicion") Then
            If dgvListaCondicion.Rows.Count > 0 Then
                Me.dtpFechaActivacionCondicion.Text = Now.ToShortDateString
                btnAceptarCondicion.Enabled = True
                Me.dtpFechaActivacionCondicion.Enabled = True

                Me.rbtSiCondicion.Enabled = True
                Me.rbtNoCondicion.Enabled = True

                Me.dtpFechaActivacionCondicion.Focus()
            Else
                LimpiarAprobacionCondicionCredito()
                Me.dtpFechaActivacionCondicion.Enabled = False
                btnAceptarCondicion.Enabled = False
                Me.rbtSiCondicion.Enabled = False
                Me.rbtNoCondicion.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnAceptarCondicion_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptarCondicion.Click
        Try
            If Me.rbtSiCondicion.Checked Then
                Dim strFechaActual As Date = FechaServidor()
                If Date.Compare(strFechaActual.Date.ToShortDateString, Me.dtpFechaActivacionCondicion.Text) >= 1 Then
                    MessageBox.Show("La Fecha de Activación " & Format(Me.dtpFechaActivacionCondicion.Value, "short date") & " debe ser mayor o igual a la " & Chr(13) & "Fecha Actual " & Format(strFechaActual, "short date"), "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.dtpFechaActivacionCondicion.Focus()
                    Return
                End If
            Else
                If Me.txtObservacionCondicion.Text.Trim.Length = 0 Then
                    MessageBox.Show("Debe Ingresar Motivo de la Desaprobación.", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtObservacionCondicion.Text = ""
                    Me.txtObservacionCondicion.Focus()
                    Return
                End If
            End If

            If Me.rbtSiCondicion.Checked Then 'aprueba
                Dim strMensaje As String = "¿Está Seguro de Aprobar la Solicitud con:" & Chr(13) & Chr(13) & "Fecha de Activación : " & Me.dtpFechaActivacionCondicion.Value.ToShortDateString & "?"
                Dim intRespuesta As DialogResult = MessageBox.Show(strMensaje, "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If intRespuesta = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    'Dim intOpcion As Integer = IIf(Me.RbtSi.Checked, 1, 2)
                    AprobarSolicitudCondicionCredito()
                    Me.ListarSolicitudesPendientesCondicion()
                    tabCondicionCredito.SelectedTab = tabCondicionCredito.TabPages("tabListaCondicion")
                    Cursor = Cursors.Default
                End If
            Else 'desaprueba
                If MessageBox.Show("¿Está Seguro de Desaprobar la Solicitud?", "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    DesaprobarSolicitudCondicionCredito()
                    MessageBox.Show("Solicitud Desaprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitudesPendientesCondicion()
                    tabCondicionCredito.SelectedTab = tabCondicionCredito.TabPages("tabListaCondicion")
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvListaCondicion_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvListaCondicion.DoubleClick
        If Me.dgvListaCondicion.Rows.Count > 0 Then
            Me.tabCondicionCredito.SelectedTab = Me.tabCondicionCredito.TabPages("tabAprobacionCondicion")
            Me.tabCondicionCredito_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub dgvListaCondicion_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaCondicion.RowEnter
        With dgvListaCondicion
            If .Rows.Count > 0 Then
                'BtnAceptar.Enabled = True

                Dim row As DataGridViewRow = .Rows(e.RowIndex)

                Me.lblCodigoCondicion.Text = row.Cells("codigo").Value
                Me.lblRazonSocialCondicion.Text = row.Cells("cliente").Value

                Me.lblFuncionarioCondicion.Text = row.Cells("solicitante").Value

                Me.lblCondicionCredito.Text = row.Cells("condicion").Value

                'Me.lblFechaInicio.Text = IIf(IsDBNull(row.Cells("fecha_inicio").Value), "", row.Cells("fecha_inicio").Value)

                'Me.lblFuncionarioNuevo.Text = row.Cells("solicitante").Value
                Me.lblObservacionCondicion.Text = row.Cells("observacion").Value

                'If Me.lblFuncionarioActualA.Text = "SIN FUNCIONARIO" Then
                'Me.dtpFechaFin.Text = ""
                'End If
            End If
        End With
    End Sub

    Private Sub rbtSiCondicion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtSiCondicion.CheckedChanged
        Me.txtObservacionCondicion.Enabled = False
        Me.txtObservacionCondicion.Text = ""
        Me.btnAceptarCondicion.Text = "&Aprobar"
        Me.dtpFechaActivacionCondicion.Enabled = True
        Me.txtObservacionCondicion.Focus()
    End Sub

    Private Sub rbtNoCondicion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtNoCondicion.CheckedChanged
        Me.txtObservacionCondicion.Enabled = True
        Me.btnAceptarCondicion.Text = "&Desaprobar"
        Me.dtpFechaActivacionCondicion.Enabled = False
        Me.txtObservacionCondicion.Focus()
    End Sub

    Private Sub rbtNoTipoFacturacion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtNoTipoFacturacion.CheckedChanged
        Me.txtObservacionTipoFacturacion.Enabled = True
        Me.btnAceptarTipoFacturacion.Text = "&Desaprobar"
        Me.dtpFechaActivacionFacturacion.Enabled = False
        Me.txtObservacionTipoFacturacion.Focus()
    End Sub


    Private Sub btnActualizarLineaCredito_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizarLineaCredito.Click
        Dim frm As New frmActivarLineaCredito
        Dim intCliente As Integer = Me.dgvCarteraCredito.CurrentRow.Cells("id").Value
        frm.Cliente = intCliente
        frm.Ruc = Me.dgvCarteraCredito.CurrentRow.Cells("codigo").Value
        frm.RazonSocial = Me.dgvCarteraCredito.CurrentRow.Cells("cliente").Value
        frm.ID = Me.lblEstadoCredito.Tag
        frm.Llamada = 2
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            MessageBox.Show("Línea de Crédito Actualizada", "Actualizar Línea de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ListarLineaCredito(intCliente, Me.dgvLineaCredito, EstadoLineaCredito(Me.cboEstadoOperacionCredito.SelectedIndex))
        End If

    End Sub

    Private Sub cboPProducto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPProducto.SelectedIndexChanged
        If IsReference(cboPProducto.SelectedValue) Then Return
        If cboPProducto.SelectedValue = 8 Then
            Me.chkContadoProducto.Enabled = True
        Else
            Me.chkContadoProducto.Checked = False
            Me.chkContadoProducto.Enabled = False
        End If
    End Sub

    Private Sub rbtPorPreaprobar_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtPorPreaprobar.CheckedChanged, rbtPorAprobar.CheckedChanged, rbtAprobadas.CheckedChanged, rbtRechazadas.CheckedChanged
        flowFechaCredito.Visible = False
        flowPorCredito.Visible = False
        Me.lblUsuarioCredito.Text = ""
        Me.lblUsuario2Credito.Text = ""
        If Me.rbtPorPreaprobar.Checked Then
            lblTituloCredito.Text = "Solicitudes Pendientes de Preaprobación"
            ConfigurarDGVListaCredito(1)
            ListarSolicitudCredito(1)
        ElseIf Me.rbtPorAprobar.Checked Then 'CType(sender, RadioButton).Name.ToLower = "rbtporaprobar" Then
            lblTituloCredito.Text = "Solicitudes Pendientes de Aprobación"
            ConfigurarDGVListaCredito(2)
            ListarSolicitudCredito(2)
        ElseIf Me.rbtAprobadas.Checked Then
            lblTituloCredito.Text = "Solicitudes Aprobadas"
            flowFechaCredito.Visible = True
            ConfigurarDGVListaCreditoAprobadas()
            Me.dtpInicio.Value = DateAdd("d", -7, Now)
            ListarSolicitudCredito(3, Me.dtpInicio.Text, Me.dtpFin.Text)
        Else
            lblTituloCredito.Text = "Solicitudes Rechazadas"
            Me.cboPorCredito.SelectedIndex = 1
            flowFechaCredito.Visible = True
            flowPorCredito.Visible = True
            ConfigurarDGVListaCreditoRechazadas()
            Me.dtpInicio.Value = DateAdd("d", -7, Now)
            ListarSolicitudCredito(IIf(Me.cboPorCredito.SelectedIndex = 0, 4, 5), Me.dtpInicio.Text, Me.dtpFin.Text)
        End If
    End Sub

    Private Sub dtpInicio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpInicio.ValueChanged, dtpFin.ValueChanged
        If Me.rbtAprobadas.Checked Then
            ConfigurarDGVListaCreditoAprobadas()
            ListarSolicitudCredito(3, Me.dtpInicio.Text, Me.dtpFin.Text)
        ElseIf Me.rbtRechazadas.Checked Then
            ConfigurarDGVListaCreditoRechazadas()
            ListarSolicitudCredito(IIf(Me.cboPorCredito.SelectedIndex = 0, 4, 5), Me.dtpInicio.Text, Me.dtpFin.Text)
        End If
    End Sub

    Private Sub cboPorCredito_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPorCredito.SelectedIndexChanged
        ConfigurarDGVListaCreditoRechazadas()
        ListarSolicitudCredito(IIf(Me.cboPorCredito.SelectedIndex = 0, 4, 5), Me.dtpInicio.Text, Me.dtpFin.Text)
    End Sub

    Private Sub dgvListaCartera_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles dgvListaCartera.CurrentCellDirtyStateChanged
        dgvListaCartera.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub dgvListaCartera_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaCartera.CellContentClick
        If e.ColumnIndex <> 0 Then Return
        If Me.rbtSiAprobacion.Checked Then
            If Not (Me.dgvListaCartera.Rows(e.RowIndex).Cells("responsable_actual").Value = "SIN FUNCIONARIO") Then
                Me.dgvListaCartera.Rows(e.RowIndex).Cells(0).Value = 0
                dgvListaCartera.RefreshEdit()
                Return
            End If
        End If
        If Me.rbtNoAprobacion.Checked Then
            If Not (Me.dgvListaCartera.Rows(e.RowIndex).Cells("responsable_actual").Value <> "SIN FUNCIONARIO") Then
                Me.dgvListaCartera.Rows(e.RowIndex).Cells(0).Value = 0
                dgvListaCartera.RefreshEdit()
                Return
            End If
        End If

        ActivarAprobacion()
    End Sub

    Sub ActivarAprobacion()
        Dim intNumero As Integer = NumeroCheck(dgvListaCartera)
        If intNumero > 0 Then
            Me.btnAprobar.Enabled = True
        Else
            Me.btnAprobar.Enabled = False
        End If
    End Sub

    Private Sub btnSeleccionarTodoAprobacion_Click(sender As System.Object, e As System.EventArgs) Handles btnSeleccionarTodoAprobacion.Click
        SeleccionarCheckDgv(Me.dgvListaCartera, 0, 1, IIf(Me.rbtSiAprobacion.Checked, 1, 2))
        ActivarAprobacion()
    End Sub

    Private Sub btnEliminarSeleccionarAprobacion_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarSeleccionarAprobacion.Click
        SeleccionarCheckDgv(Me.dgvListaCartera, 0, 0, 0)
        ActivarAprobacion()
    End Sub

    Private Sub AceptarAprobacion(Optional fecha As String = "")
        Try
            Dim objEN As New Cls_ClienteCarteraFuncionario_EN
            Dim objLN As New Cls_ClienteCarteraFuncionario_LN

            With Me.dgvListaCartera
                Dim lista As List(Of DataGridViewRow) = ObtenerListaCheck(dgvListaCartera, "sel")
                For Each row As DataGridViewRow In lista
                    objEN.ID = row.Cells("id").Value
                    objEN.Cliente = row.Cells("idcliente").Value
                    objEN.Responsable = row.Cells("usuario_solicitud").Value
                    objEN.Observaciones = "" 'Me.TxtObservacion.Text.Trim
                    If fecha = "" Then
                        objEN.Fecha = row.Cells("fecha_solicitud").Value
                        objEN.ResponsableActual = 0
                        objEN.ResponsableFechaFin = ""
                    Else
                        objEN.Fecha = fecha
                        objEN.ResponsableActual = row.Cells("idresponsable").Value
                        objEN.ResponsableFechaFin = DateAdd("d", -1, fecha).ToString("dd/MM/yyyy")
                    End If

                    objEN.Usuario = dtoUSUARIOS.IdLogin
                    objEN.IP = dtoUSUARIOS.IP

                    objLN.AprobarSolicitud(objEN, 1)
                Next
            End With
            Cursor = Cursors.Default
            MessageBox.Show("Solicitudes Aprobadas", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ListarSolicitudes()
            ListarSolicitudesPendientes()

        Catch ex As Exception
            Cursor = Cursors.Default
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub btnAprobar_Click(sender As System.Object, e As System.EventArgs) Handles btnAprobar.Click
        If Me.rbtSiAprobacion.Checked Then 'aprobacion multiple para sin cartera previa
            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está seguro de realizar la Aprobación?", "Aprobar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                AceptarAprobacion()
            End If
        Else 'aprobacion multiple para cartera previa
            Dim frm As New frmAprobacionMultiple
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                AceptarAprobacion(frm.dtpFechaActivacion.Value.ToShortDateString)
            End If
        End If
    End Sub

    Private Sub rbtNoAprobacion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtNoAprobacion.CheckedChanged
        btnEliminarSeleccionarAprobacion_Click(Nothing, Nothing)
    End Sub

    Private Sub rbtSiAprobacion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtSiAprobacion.CheckedChanged
        btnEliminarSeleccionarAprobacion_Click(Nothing, Nothing)
    End Sub

    Private Sub btnMostrarTF_Click(sender As System.Object, e As System.EventArgs) Handles btnMostrarTF.Click
        Dim obj As New Cls_ClienteTipoFacturacion_LN
        Me.dgvTFCargo.DataSource = obj.ListarClienteCargo(0, 0)
    End Sub

    Sub LlenarComboCartera()
        With Me.cboTipoCartera
            Dim obj As New Cls_ClienteCarteraFuncionario_LN
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = obj.ListarTipoCartera(1)
            .SelectedValue = 1
        End With
    End Sub

    Private Sub cboTipoCartera_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoCartera.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Function dgvListaZona() As Object
        Throw New NotImplementedException
    End Function

    '-------------------------------- devolucion de cargos ------------------------------

    Private Sub ConfigurarDGVClienteCargo()
        With dgvClienteCargo
            Cls_Utilitarios.FormatDataGridView(dgvClienteCargo)
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
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
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
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            .Columns.AddRange(col_id, col_codigo, col_cliente)
        End With
    End Sub

    Private Sub ConfigurarDGVSolicitudCargo()
        With dgvSolicitudCargo
            Cls_Utilitarios.FormatDataGridView(dgvSolicitudCargo)
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
            Dim col_tipo1 As New DataGridViewTextBoxColumn
            With col_tipo1
                .Name = "tipo1" : .DataPropertyName = "tipo1"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Solicitud"
            End With
            x += +1
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
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
            End With
            x += +1
            Dim col_cargo As New DataGridViewTextBoxColumn
            With col_cargo
                .Name = "cargo" : .DataPropertyName = "cargo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Dev. Cargo"
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
            End With
            x += +1
            Dim col_aprobacion As New DataGridViewTextBoxColumn
            With col_aprobacion
                .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aprobación"
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
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Observacion"
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id"
            End With
            x += +1
            Dim col_idestado As New DataGridViewTextBoxColumn
            With col_idestado
                .Name = "idestado" : .DataPropertyName = "idestado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idestado"
            End With
            x += +1
            Dim col_idcargo As New DataGridViewTextBoxColumn
            With col_idcargo
                .Name = "idcargo" : .DataPropertyName = "idcargo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcargo"
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "tipo"
            End With

            .Columns.AddRange(col_tipo1, col_solicitud, col_fecha, col_cliente, col_cargo, col_estado, _
                              col_aprobacion, col_desaprobacion, col_anulacion, _
                              col_observacion, col_id, col_idestado, col_idcargo, col_tipo)
        End With
    End Sub

    Private Sub ConfigurarDGVListaCargo()
        With dgvListaCargo
            Cls_Utilitarios.FormatDataGridView(dgvListaProducto)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 8.0!, FontStyle.Regular)
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
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_tipo1 As New DataGridViewTextBoxColumn
            With col_tipo1
                .Name = "tipo1" : .DataPropertyName = "tipo1"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Solicitud"
            End With

            x += +1
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
            Dim col_idcliente As New DataGridViewTextBoxColumn
            With col_idcliente
                .Name = "idcliente" : .DataPropertyName = "idcliente"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id Cliente"
            End With

            x += +1
            Dim col_solicitante As New DataGridViewTextBoxColumn
            With col_solicitante
                .Name = "solicitante" : .DataPropertyName = "solicitante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Solicitante"
            End With
            x += +1
            Dim col_usuario_solicitud As New DataGridViewTextBoxColumn
            With col_usuario_solicitud
                .Name = "usuario_solicitud" : .DataPropertyName = "usuario_solicitud"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Id Usuario Solicitud"
            End With
            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Observación"
            End With
            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .Visible = False : .HeaderText = "ID"
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
                .DisplayIndex = x : .Visible = True : .HeaderText = "Dev. Cargo" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "tipo"
            End With

            .Columns.AddRange(col_tipo1, col_solicitud, col_fecha, col_codigo, col_cliente, col_idcliente, col_solicitante, _
                              col_usuario_solicitud, col_observacion, col_id, col_idcargo, col_cargo, col_tipo)
        End With
    End Sub

    Sub LimpiarSolicitudCargo()
        Me.lblNumeroSolicitudCargo.Text = ""
        Me.txtMotivoCargo.Text = ""
        Me.cboTipoSolicitudCargo.SelectedIndex = 0
        Me.chkDevolucionCargo.Checked = False

        Return
        'Dim obj As New Cls_ClienteCargo_LN
        'Dim intExonerado As Integer = obj.ExoneradoTarifa(dgvClienteCargo.CurrentRow.Cells("id").Value)
        'Me.chkExonerar.Checked = False
        'If intExonerado = 0 Then
        '    Me.chkExonerar.Text = "Si" '"Exonerar Cobro Devolución de Cargos"
        '    Me.chkExonerar.Tag = 1
        'Else
        '    Me.chkExonerar.Text = "No" '"No Exonerar Cobro Devolución de Cargos"
        '    Me.chkExonerar.Tag = 2
        'End If
    End Sub

    Sub LimpiarAprobacionCargo()
        Me.lblCodigoCargo.Text = ""
        Me.lblRazonSocialCargo.Text = ""
        Me.lblFuncionarioCargoAprobacion.Text = ""
        Me.lblObservacionCargo.Text = ""
        Me.rbtSiCargo.Checked = True
        Me.lblCargoAprobacion.Text = ""
    End Sub

    Sub ActivaDesactivaCargo(estado As Integer, registros As Integer)
        Dim blnEstado As Boolean
        If estado = 1 Then
            blnEstado = True
        ElseIf estado = 0 Then
            blnEstado = False
        End If
        If estado = -1 Then
            Me.grbSolicitudcargo.Enabled = False
            Me.btnNuevoCargo.Enabled = Me.dgvClienteCargo.Rows.Count > 0
            If registros = 0 Then
                Me.btnModificarCargo.Enabled = False
                Me.btnAnularCargo.Enabled = False
            Else
                Me.btnModificarCargo.Enabled = True
                Me.btnAnularCargo.Enabled = True
            End If
            Me.btnGrabarCargo.Enabled = False
            Me.btnCancelarCargo.Enabled = False
        Else
            blnEstado = estado
            Me.grbSolicitudcargo.Enabled = blnEstado
            Me.btnNuevoCargo.Enabled = Not blnEstado
            If registros = 0 Then
                Me.btnModificarCargo.Enabled = False
            Else
                Me.btnModificarCargo.Enabled = Not blnEstado
            End If
            Me.btnGrabarCargo.Enabled = blnEstado
            Me.btnCancelarCargo.Enabled = blnEstado
            If registros = 0 Then
                Me.btnAnularCargo.Enabled = False
            Else
                Me.btnAnularCargo.Enabled = Not blnEstado
            End If
        End If

        If Me.btnGrabarCargo.Enabled Then
            Me.dgvSolicitudCargo.Enabled = False
            Me.cboEstadoCargo.Enabled = False
        Else
            Me.dgvSolicitudCargo.Enabled = True
            Me.cboEstadoCargo.Enabled = True
        End If
    End Sub

    Sub ListarSolicitudCargo()
        Try
            'If Me.dgvSolicitudProducto.Rows.Count = 0 Then Return
            Dim obj As New Cls_ClienteCargo_LN
            Dim objEN As New Cls_ClienteCargo_EN

            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.Estado = Me.cboEstadoCargo.SelectedIndex
            objEN.Cliente = dgvClienteCargo.CurrentRow.Cells(0).Value
            dgvSolicitudCargo.DataSource = obj.ListarSolicitud(objEN.Usuario, objEN.Cliente, objEN.Estado)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarSolicitudesPendientesCargo()
        Try
            Dim obj As New Cls_ClienteCargo_LN
            Dim objEN As New Cls_ClienteCargo_EN

            objEN.Estado = Estado.Pendiente
            dgvListaCargo.DataSource = obj.ListarSolicitud(objEN.Estado)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tabCargos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabCargos.SelectedIndexChanged
        If tabCargos.SelectedTab Is tabCargos.TabPages("tabClienteCargo") Then
            blnInicioCargo = False
            ConfigurarDGVClienteCargo()

            intOperacion = Operacion.Nuevo
            blnInicioCargo = True
            CargarCartera(dtoUSUARIOS.IdLogin, Me.dgvClienteCargo, 1)

        ElseIf tabCargos.SelectedTab Is tabCargos.TabPages("tabSolicitudCargo") Then
            intOperacion = Operacion.Nuevo
            Me.lblFechaCargo.Text = Format(Now, "Short Date")
            Me.lblFuncionarioCargo.Text = dtoUSUARIOS.NameLogin

            If Me.dgvClienteCargo.Rows.Count > 0 Then
                Dim strCliente As String = dgvClienteCargo.CurrentRow.Cells("codigo").Value & "  " & dgvClienteCargo.CurrentRow.Cells("cliente").Value
                Me.lblClienteCargo.Text = strCliente.Trim

            End If
            LimpiarSolicitudCargo()
            Me.dgvSolicitudCargo.DataSource = Nothing
            ConfigurarDGVSolicitudCargo()
            If Me.dgvClienteCargo.Rows.Count > 0 Then
                Me.cboEstadoCargo.SelectedIndex = 1
                ListarSolicitudCargo()
            End If
            ActivaDesactivaCargo(-1, dgvSolicitudCargo.Rows.Count)
            Me.btnNuevoCargo.Focus()

        ElseIf tabCargos.SelectedTab Is tabCargos.TabPages("tabListaCargo") Then
            ConfigurarDGVListaCargo()
            ListarSolicitudesPendientesCargo()

        ElseIf tabCargos.SelectedTab Is tabCargos.TabPages("tabAprobacionCargo") Then
            If dgvListaCargo.Rows.Count > 0 Then
                btnAceptarCargo.Enabled = True
                Me.dtpFechaActivacionCargo.Enabled = True

                Me.rbtSiCargo.Enabled = True
                Me.rbtNoCargo.Enabled = True

                Me.dtpFechaActivacionCargo.Focus()
            Else
                LimpiarAprobacionCargo()
                Me.dtpFechaActivacionCargo.Enabled = False
                btnAceptarCargo.Enabled = False
                Me.rbtSiCargo.Enabled = False
                Me.rbtNoCargo.Enabled = False
            End If
        End If
    End Sub

    Private Sub dgvClienteCargo_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvClienteCargo.DoubleClick
        intFilaDGVClienteCargo = 0
        With dgvClienteCargo
            If .Rows.Count > 0 Then
                intFilaDGVClienteCargo = .CurrentRow.Index
                Me.tabCargos.SelectedTab = Me.tabCargos.TabPages("tabSolicitudCargo")
            End If
        End With
    End Sub

    Private Sub btnNuevoCargo_Click(sender As Object, e As System.EventArgs) Handles btnNuevoCargo.Click
        LimpiarSolicitudCargo()
        Me.lblNumeroSolicitudCargo.Text = "" 'dtoUtilitario.ObtieneNumeroSolicitud(Me.cboTipoSolicitudCargo.SelectedIndex, 6)
        intOperacion = Operacion.Nuevo
        ActivaDesactivaCargo(1, dgvSolicitudCargo.Rows.Count)
        Me.cboTipoSolicitudCargo.Enabled = True
        Me.chkDevolucionCargo.Enabled = True
        Me.chkDevolucionCargo.Focus()
    End Sub

    Private Sub btnModificarCargo_Click(sender As Object, e As System.EventArgs) Handles btnModificarCargo.Click
        intOperacion = Operacion.Modificar
        ActivaDesactivaCargo(1, dgvSolicitudCargo.Rows.Count)
        Me.cboTipoSolicitudCargo.Enabled = False
        Me.chkDevolucionCargo.Enabled = False
        Me.chkDevolucionCargo.Focus()
    End Sub

    Sub GrabarCargo()
        Try
            Dim objEN As New Cls_ClienteCargo_EN
            Dim objLN As New Cls_ClienteCargo_LN

            If intOperacion = Operacion.Nuevo Then
                objEN.ID = 0
            Else
                objEN.ID = dgvSolicitudCargo.CurrentRow.Cells("id").Value
            End If
            objEN.Numero = Me.lblNumeroSolicitudCargo.Text
            objEN.Fecha = Me.lblFechaCargo.Text
            objEN.Cliente = Me.dgvClienteCargo.CurrentRow.Cells(0).Value
            objEN.Observacion = Me.txtMotivoCargo.Text.Trim
            objEN.Exonerado = IIf(Me.chkDevolucionCargo.Tag = 1, 1, 0)
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP
            objEN.Tipo = Me.cboTipoSolicitudCargo.SelectedIndex
            objLN.GrabarSolicitud(objEN)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub


    Private Sub btnGrabarCargo_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabarCargo.Click
        Try
            If Me.cboTipoSolicitudCargo.SelectedIndex = 0 Then
                MessageBox.Show("Seleccione Tipo de Solicitud", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboTipoSolicitudCargo.Focus()
                Me.cboTipoSolicitudCargo.DroppedDown = True
                Return
            End If

            If Not Me.chkDevolucionCargo.Checked Then
                MessageBox.Show("Seleccione Opción", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.chkDevolucionCargo.Focus()
                Return
            End If

            If Me.txtMotivoCargo.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Observación de la Solicitud", "Grabar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtMotivoCargo.Text = ""
                Me.txtMotivoCargo.Focus()
                Return
            End If

            Dim intCliente As Integer = Me.dgvClienteCargo.CurrentRow.Cells(0).Value
            Dim intSolicitud As Integer = 0
            If intOperacion = Operacion.Modificar Then
                intSolicitud = Me.dgvSolicitudCargo.CurrentRow.Cells("numero_solicitud").Value
            End If

            'graba solicitud de cargo
            Cursor = Cursors.WaitCursor
            GrabarCargo()
            ListarSolicitudCargo()
            ActivaDesactivaCargo(0, dgvSolicitudCargo.Rows.Count)
            Cursor = Cursors.Default
            Me.btnNuevoCargo.Focus()

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelarCargo_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelarCargo.Click
        LimpiarSolicitudCargo()
        ActivaDesactivaCargo(0, dgvSolicitudCargo.Rows.Count)

        If Me.dgvSolicitudCargo.Rows.Count > 0 Then
            MostrarSolicitudCargo(dgvSolicitudCargo.CurrentCell.RowIndex)

        End If
        If intOperacion = Operacion.Nuevo Then
            btnNuevoCargo.Focus()
        Else
            btnModificarCargo.Focus()
        End If
    End Sub

    Private Sub btnAnularCargo_Click(sender As Object, e As System.EventArgs) Handles btnAnularCargo.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está Seguro de Anular la Solicitud Nº " & dgvSolicitudCargo.CurrentRow.Cells("numero_solicitud").Value & "?", "Anular Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = vbYes Then
            AnularCargo()
            ListarSolicitudCargo()
        End If
    End Sub

    Sub AnularCargo()
        Try
            Dim objEN As New Cls_ClienteCargo_EN
            Dim objLN As New Cls_ClienteCargo_LN

            objEN.ID = dgvSolicitudCargo.CurrentRow.Cells("id").Value
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP

            objLN.AnularSolicitud(objEN)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboEstadoCargo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstadoCargo.SelectedIndexChanged
        Me.LimpiarSolicitudCargo()
        ListarSolicitudCargo()
        If Me.dgvSolicitudCargo.Rows.Count > 0 AndAlso btnNuevoCargo.Enabled Then
            Me.btnModificarCargo.Enabled = dgvSolicitudCargo.CurrentRow.Cells("idestado").Value = 1
            Me.btnAnularCargo.Enabled = dgvSolicitudCargo.CurrentRow.Cells("idestado").Value = 1
        ElseIf Me.dgvSolicitudCargo.Rows.Count = 0 Then
            Me.ActivaDesactivaCargo(-1, 0)
        End If
    End Sub

    Private Sub dgvSolicitudCargo_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvSolicitudCargo.DoubleClick
        If dgvSolicitudCargo.Rows.Count > 0 Then
            If Me.btnGrabarCargo.Enabled = False And dgvSolicitudCargo.CurrentRow.Cells("idestado").Value = 1 Then
                btnModificarCargo_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub dgvSolicitudCargo_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSolicitudCargo.RowEnter
        If Me.btnNuevoCargo.Enabled Then
            MostrarSolicitudCargo(e.RowIndex)
            Me.btnModificarCargo.Enabled = dgvSolicitudCargo.Rows(e.RowIndex).Cells("idestado").Value = 1
            Me.btnAnularCargo.Enabled = dgvSolicitudCargo.Rows(e.RowIndex).Cells("idestado").Value = 1
        End If
    End Sub

    Sub MostrarSolicitudCargo(row As Integer)
        With dgvSolicitudCargo
            Me.lblNumeroSolicitudCargo.Text = .Rows(row).Cells("numero_solicitud").Value
            Me.lblFechaCargo.Text = .Rows(row).Cells("fecha_solicitud").Value
            Me.lblClienteCargo.Text = .Rows(row).Cells("cliente").Value

            Me.cboTipoSolicitudCargo.SelectedIndex = .Rows(row).Cells("tipo").Value
            Me.chkDevolucionCargo.Checked = IIf(.Rows(row).Cells("idcargo").Value = 1, True, False)
            Me.chkDevolucionCargo.Text = IIf(.Rows(row).Cells("idcargo").Value = 1, "Si", "No")
            'Me.chkDevolucionCargo.Text = IIf(.Rows(row).Cells("idcargo").Value = 1, "Exonerar Cobro Devolución de Cargos", "No Exonerar Cobro Devolución de Cargos")

            Me.txtMotivoCargo.Text = .Rows(row).Cells("observacion").Value
        End With
    End Sub

    Private Sub dgvListaCargo_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvListaCargo.DoubleClick
        If Me.dgvListaCargo.Rows.Count > 0 Then
            Me.tabCargos.SelectedTab = Me.tabCargos.TabPages("tabAprobacionCargo")
            Me.tabCargos_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub dgvListaCargo_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaCargo.RowEnter
        With dgvListaCargo
            If .Rows.Count > 0 Then
                'BtnAceptar.Enabled = True

                Dim row As DataGridViewRow = .Rows(e.RowIndex)

                Me.lblCodigoCargo.Text = row.Cells("codigo").Value
                Me.lblRazonSocialCargo.Text = row.Cells("cliente").Value
                Me.lblFuncionarioCargoAprobacion.Text = row.Cells("solicitante").Value

                Me.lblTipoSolicitud.Text = row.Cells("tipo1").Value
                Me.lblCargoAprobacion.Text = IIf(row.Cells("idcargo").Value = 1, "SI", "NO")
                'Me.lblFechaInicio.Text = IIf(IsDBNull(row.Cells("fecha_inicio").Value), "", row.Cells("fecha_inicio").Value)

                Me.lblObservacionCargo.Text = row.Cells("observacion").Value
            End If
        End With
    End Sub

    Sub DesaprobarSolicitudCargo()
        Dim objEN As New Cls_ClienteCargo_EN
        Dim objLN As New Cls_ClienteCargo_LN

        objEN.ID = Me.dgvListaCargo.CurrentRow.Cells("id").Value
        objEN.Observacion = Me.txtObservacionCargo.Text.Trim
        objEN.Usuario = dtoUSUARIOS.IdLogin
        objEN.IP = dtoUSUARIOS.IP

        objLN.DesaprobarSolicitud(objEN)
    End Sub

    Private Sub btnAceptarCargo_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptarCargo.Click
        Try
            If Me.rbtSiCargo.Checked Then
                Dim strFechaActual As Date = FechaServidor()
                If Date.Compare(strFechaActual.Date.ToShortDateString, Me.dtpFechaActivacionCargo.Text) >= 1 Then
                    MessageBox.Show("La Fecha de Activación " & Format(Me.dtpFechaActivacionCargo.Value, "short date") & " debe ser mayor o igual a la " & Chr(13) & "Fecha Actual " & Format(strFechaActual, "short date"), "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.dtpFechaActivacionCargo.Focus()
                    Return
                End If
            Else
                If Me.txtObservacionCargo.Text.Trim.Length = 0 Then
                    MessageBox.Show("Debe Ingresar Motivo de la Desaprobación.", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtObservacionCargo.Text = ""
                    Me.txtObservacionCargo.Focus()
                    Return
                End If
            End If

            If Me.rbtSiCargo.Checked Then 'aprueba
                Dim iRespuesta As DialogResult
                iRespuesta = MessageBox.Show("¿Está Seguro de Aprobar la Solicitud Nº " & Me.dgvListaCargo.CurrentRow.Cells("numero_solicitud").Value & "?", "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If iRespuesta = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Dim intOpcion As Integer = IIf(Me.rbtSiCargo.Checked, 1, 2)
                    AprobarSolicitudCargo()
                    tabCargos.SelectedTab = tabCargos.TabPages("tabListaCargo")
                    Cursor = Cursors.Default
                End If
            Else 'desaprueba
                If MessageBox.Show("¿Está Seguro de Desaprobar la Solicitud Nº " & Me.dgvListaCargo.CurrentRow.Cells("numero_solicitud").Value & "?", "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    DesaprobarSolicitudCargo()
                    MessageBox.Show("Solicitud Desaprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ListarSolicitudesPendientesCargo()
                    tabCargos.SelectedTab = tabCargos.TabPages("tabListaCargo")
                    Cursor = Cursors.Default
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtSiCargo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtSiCargo.CheckedChanged
        Me.txtObservacionCargo.Enabled = False
        Me.txtObservacionCargo.Text = ""
        Me.btnAceptarCargo.Text = "&Aprobar"
        Me.dtpFechaActivacionCargo.Enabled = True
        Me.txtObservacionCargo.Focus()
    End Sub

    Private Sub rbtNoCargo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtNoCargo.CheckedChanged
        Me.txtObservacionCargo.Enabled = True
        Me.btnAceptarCargo.Text = "&Desaprobar"
        Me.dtpFechaActivacionCargo.Enabled = False
        Me.txtObservacionCargo.Focus()
    End Sub

    Private Sub AprobarSolicitudCargo()
        Cursor = Cursors.WaitCursor
        Try
            Dim objEN As New Cls_ClienteCargo_EN
            Dim objLN As New Cls_ClienteCargo_LN

            Dim intID As Integer = Me.dgvListaCargo.CurrentRow.Cells("id").Value
            Dim intCliente As Integer = Me.dgvListaCargo.CurrentRow.Cells("idcliente").Value
            Dim intExonerado As Integer = Me.dgvListaCargo.CurrentRow.Cells("idcargo").Value
            Dim strFecha As String = Me.dtpFechaActivacionCargo.Value.ToShortDateString

            objEN.ID = intID
            objEN.Cliente = intCliente
            objEN.Exonerado = intExonerado
            objEN.Fecha = strFecha

            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP
            objEN.Tipo = Me.dgvListaCargo.CurrentRow.Cells("tipo").Value

            objLN.AprobarSolicitud(objEN)
            MessageBox.Show("Solicitud Aprobada", "Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub FormatearDgvGC1()
        With dgvGC1
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvSalida)
            '.Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            .ReadOnly = False
        End With
    End Sub
    Private Sub BtnFiltrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnFiltrar.Click
        If Me.cboResponsableReporte.SelectedValue = 0 Then
            MessageBox.Show("Seleccione Responsable", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboResponsableReporte.Focus()
            Me.cboResponsableReporte.DroppedDown = True
            Return
        End If

        ConsultarGC1()
    End Sub

    Sub ConsultarGC1()
        Try
            Cursor = Cursors.WaitCursor
            LimpiarGrid()
            Dim obj As New Cls_ClienteCarteraFuncionario_LN
            Dim strInicio As String, strFin As String
            Dim intCliente As Integer ', intEstado As Integer = EstadoLineaCredito(Me.cboEstado.SelectedIndex)
            strInicio = "01/" & Me.dtpFechaInicioGC.Value.Month.ToString.PadLeft(2, "0") & "/" & Me.dtpFechaInicioGC.Value.Year
            strFin = UltimoDiaMesAño(Me.dtpFechaFinGC.Value.Month, Me.dtpFechaFinGC.Value.Year).ToString.PadLeft(2, "0") & "/" & _
            Me.dtpFechaFinGC.Value.Month.ToString.PadLeft(2, "0") & "/" & Me.dtpFechaFinGC.Value.Year

            Dim intOpcion As Integer = 0 'IIf(Me.chkVenta.Checked, 1, 0)
            Dim dt As DataTable = obj.ListarGC1(dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, strInicio, strFin, _
                                                Me.cboResponsableReporte.SelectedValue, Me.dtpFechaIngreso.Value.ToShortDateString, intOpcion)
            Me.dgvGC1.DataSource = dt

            Cabecera()
            FormatearDgvGC1()
            If dgvGC1.Rows.Count = 0 Then
                LimpiarGrid()
            Else
                Me.btnExportar.Enabled = True
            End If
            Me.lblNumeroClientes.Text = Me.dgvGC1.Rows.Count
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub LimpiarGrid()
        dgvGC1.DataSource = Nothing
        dgvGC1.Columns.Clear()
        Me.btnExportar.Enabled = False
    End Sub

    Sub Cabecera()
        Dim i As Integer = 0
        Dim strMes As String = ""
        With dgvGC1
            For Each col As DataGridViewColumn In .Columns
                If i > 3 Then
                    strMes = NombreMes(Val(col.HeaderText.Substring(1, 2))).ToUpper
                    col.HeaderText = strMes & " " & 2000 + Val(col.HeaderText.Substring(3, 2))
                    '.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    '.Columns(i).DefaultCellStyle.Format = "0.00"
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    col.DefaultCellStyle.Format = "###,###,###0.00"
                    'Else
                    '    If i = 2 Then
                    '        col.HeaderText = "LINEA CREDITO"
                    '        '.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    '        '.Columns(i).DefaultCellStyle.Format = "0.00"
                    '        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    '        col.DefaultCellStyle.Format = "###,###,###0.00"
                    '    End If
                End If
                i += 1
            Next
        End With

    End Sub

    Private Sub btnExportar_Click(sender As System.Object, e As System.EventArgs) Handles btnExportar.Click
        Try
            Cursor = Cursors.AppStarting
            Dim xlApp As New Excel.Application()
            Dim xlBook As Excel.Workbook
            Dim xlSheet As Excel.Worksheet
            Dim rowIndex, colIndex, i, j As Integer
            rowIndex = 1
            colIndex = 0
            xlBook = xlApp.Workbooks().Add
            xlSheet = xlBook.Worksheets("hoja1")

            For i = 0 To dgvGC1.Columns().Count - 1
                If dgvGC1.Columns().Item(i).Visible = True Then
                    colIndex = colIndex + 1
                    'xlApp.Cells(1, colIndex) = dgvGC1.Columns().Item(i).DataPropertyName
                    If i > 3 Then
                        xlApp.Cells(1, colIndex) = " " & dgvGC1.Columns().Item(i).HeaderText
                    Else
                        xlApp.Cells(1, colIndex) = dgvGC1.Columns().Item(i).HeaderText
                    End If
                End If
            Next
            For i = 0 To dgvGC1.Rows().Count - 1
                rowIndex = rowIndex + 1
                colIndex = 0
                For j = 0 To dgvGC1.Columns().Count - 1

                    If dgvGC1.Columns().Item(j).Visible = True Then
                        colIndex = colIndex + 1
                        xlApp.Cells(rowIndex, colIndex) = dgvGC1.Rows(i).Cells(j).Value
                    End If
                Next
            Next
            With xlSheet
                '.Range(.Cells(1, 1), .Cells(1, colIndex)).Font.Name = "Arial"
                .Range(.Cells(1, 1), .Cells(1, colIndex)).Font.Bold = True
                .Columns.AutoFit()
                '.Range(.Cells(1, 1), .Cells(rowIndex, colIndex)).Borders.LineStyle = 1
            End With
            xlApp.Visible = True
            Cursor = Cursors.Default
            xlApp.UserControl = False

            xlSheet = Nothing
            xlBook = Nothing
            'xlApp.Quit()
            xlApp = Nothing

        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox("Verifique sus Datos..", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub chkVenta_CheckedChanged(sender As System.Object, e As System.EventArgs)
        'Me.grbVenta.Enabled = Me.chkVenta.Checked
    End Sub

    Private Sub cboResponsableReporte_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboResponsableReporte.SelectedIndexChanged
        Me.dgvGC1.DataSource = Nothing
        Me.btnExportar.Enabled = False
        Me.lblNumeroClientes.Text = "0"
    End Sub

    Private Sub dtpFechaInicioGC_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaInicioGC.ValueChanged
        Me.dgvGC1.DataSource = Nothing
        Me.btnExportar.Enabled = False
        Me.lblNumeroClientes.Text = "0"
    End Sub

    Private Sub dtpFechaFinGC_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaFinGC.ValueChanged
        Me.dgvGC1.DataSource = Nothing
        Me.btnExportar.Enabled = False
        Me.lblNumeroClientes.Text = "0"
    End Sub

    Private Sub cboTipoSolicitudCargo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoSolicitudCargo.SelectedIndexChanged
        If Me.cboTipoSolicitudCargo.SelectedIndex = 0 Then
            Me.chkDevolucionCargo.Enabled = False
            Me.chkDevolucionCargo.Checked = False
            Me.lblNumeroSolicitudCargo.Text = ""
        Else
            Dim obj As New Cls_ClienteCargo_LN
            Dim intTipo As Integer = Me.cboTipoSolicitudCargo.SelectedIndex
            Dim intDevCargo As Integer = obj.DevolucionCargo(intTipo, dgvClienteCargo.CurrentRow.Cells("id").Value)
            If intDevCargo = 0 Then
                Me.chkDevolucionCargo.Text = "Si" '"Exonerar Cobro Devolución de Cargos"
                Me.chkDevolucionCargo.Tag = 1
            Else
                Me.chkDevolucionCargo.Text = "No" '"No Exonerar Cobro Devolución de Cargos"
                Me.chkDevolucionCargo.Tag = 2
            End If
            Me.chkDevolucionCargo.Enabled = True
            Me.chkDevolucionCargo.Checked = False
            Me.lblNumeroSolicitudCargo.Text = dtoUtilitario.ObtieneNumeroSolicitud(Me.cboTipoSolicitudCargo.SelectedIndex, 6)
        End If
    End Sub

    Private Sub rbtDiaSemanaFacturacion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtDiaSemanaFacturacion.CheckedChanged
        Me.dtpDia1Facturacion.Enabled = False
        Me.chkDia1Facturacion.Enabled = False
        Me.dtpDia2Facturacion.Enabled = False
        Me.chkDia2Facturacion.Enabled = False
        Me.dtpDia3Facturacion.Enabled = False
        Me.chkDia3Facturacion.Enabled = False
        Me.dtpDia4Facturacion.Enabled = False
        Me.chkDia1Facturacion.Checked = False
        Me.chkDia2Facturacion.Checked = False
        Me.chkDia3Facturacion.Checked = False
        Me.lstDiaFacturacion.Enabled = True
    End Sub

    Private Sub rbtDiaMesFacturacion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtDiaMesFacturacion.CheckedChanged
        Me.dtpDia1Facturacion.Enabled = True
        Me.chkDia1Facturacion.Enabled = True
        Me.lstDiaFacturacion.Enabled = False
        LimpiarDias(lstDiaFacturacion)
    End Sub

    Sub LimpiarDias(lst As CheckedListBox)
        For i As Integer = 0 To lst.Items.Count - 1
            lst.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub chkDia1Facturacion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDia1Facturacion.CheckedChanged
        Me.dtpDia2Facturacion.Enabled = Me.chkDia1Facturacion.Checked
        Me.chkDia2Facturacion.Enabled = Me.chkDia1Facturacion.Checked
        If Not Me.chkDia1Facturacion.Checked Then
            Me.dtpDia3Facturacion.Enabled = Me.chkDia1Facturacion.Checked
            Me.chkDia3Facturacion.Enabled = Me.chkDia1Facturacion.Checked
            Me.dtpDia4Facturacion.Enabled = Me.chkDia1Facturacion.Checked
        End If
        Me.chkDia2Facturacion.Checked = False
        Me.chkDia3Facturacion.Checked = False
    End Sub

    Private Sub chkDia2Facturacion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDia2Facturacion.CheckedChanged
        Me.dtpDia3Facturacion.Enabled = Me.chkDia2Facturacion.Checked
        Me.chkDia3Facturacion.Enabled = Me.chkDia2Facturacion.Checked
        If Not Me.chkDia2Facturacion.Checked Then
            Me.dtpDia3Facturacion.Enabled = Me.chkDia2Facturacion.Checked
            Me.chkDia3Facturacion.Enabled = Me.chkDia2Facturacion.Checked
            Me.chkDia3Facturacion.Checked = Me.chkDia2Facturacion.Checked
            Me.dtpDia4Facturacion.Enabled = Me.chkDia2Facturacion.Checked
        End If
        Me.chkDia3Facturacion.Checked = False
    End Sub

    Private Sub chkDia3Facturacion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDia3Facturacion.CheckedChanged
        Me.dtpDia4Facturacion.Enabled = Me.chkDia3Facturacion.Checked
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

    Private Sub txtCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCliente.TextChanged

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
End Class