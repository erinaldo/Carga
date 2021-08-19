Imports INTEGRACION_LN

Public Class frmRecojoAcordado
    Public indocumento As String 'viene del otro formulario cte
    Public iComunicacion As Integer
    Public itipoDoc As Integer
    Public iIdContacto As Integer
    Public codcomunicacion_t, codcomunicacion_m As Integer
    Public nrodocumento As String
    Public itipodocumentoCliente As String = ""

    Public departamento, provincia, distrito As Integer
    Public dtDireccion As New DataTable
    Public iIdDireccion As Integer

    Dim intFilaDGVCliente As Integer = 0

    Dim intOperacion As Operacion

    'hlamas 08
    Dim intPerfil As Integer

#Region "Grid"
    Private Sub ConfigurarDGVCliente()
        With dgvCliente
            Cls_Utilitarios.FormatDataGridView(dgvCliente)
            .Columns.Clear()
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
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
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            x += +1
            Dim col_linea_credito As New DataGridViewTextBoxColumn
            With col_linea_credito
                .Name = "linea_credito" : .DataPropertyName = "linea_credito"
                .DisplayIndex = x : .HeaderText = "Línea Crédito" : .Visible = True
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .HeaderText = "tipo" : .Visible = False
            End With
            x += +1
            Dim col_fecha_inicio As New DataGridViewTextBoxColumn
            With col_fecha_inicio
                .Name = "fecha_inicio" : .DataPropertyName = "fecha_inicio"
                .DisplayIndex = x : .HeaderText = "fecha_inicio" : .Visible = False
            End With
            x += +1
            Dim col_funcionario As New DataGridViewTextBoxColumn
            With col_funcionario
                .Name = "funcionario" : .DataPropertyName = "funcionario"
                .DisplayIndex = x : .HeaderText = "Funcionario" : .Visible = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id, col_codigo, col_cliente, col_linea_credito, col_tipo, col_fecha_inicio, col_funcionario)
        End With
    End Sub
    Private Sub ConfigurarDGVProgramacion()
        With dgvProgramacion
            Cls_Utilitarios.FormatDataGridView(dgvCliente)
            .Columns.Clear()
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            '.RowHeadersVisible = True
            .RowHeadersWidth = 20
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
            Dim col_dia As New DataGridViewTextBoxColumn
            With col_dia
                .Name = "dia" : .DataPropertyName = "dia" : .DisplayIndex = x : .Visible = True : .HeaderText = "Día"
            End With
            x += +1
            Dim col_hora_listo As New DataGridViewTextBoxColumn
            With col_hora_listo
                .Name = "hora_listo" : .DataPropertyName = "hora_listo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Hora Listo"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            x += +1
            Dim col_hora_cierre As New DataGridViewTextBoxColumn
            With col_hora_cierre
                .Name = "hora_cierre" : .DataPropertyName = "hora_cierre"
                .DisplayIndex = x : .HeaderText = "Hora Cierre" : .Visible = True
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DisplayIndex = x : .HeaderText = "Cantidad" : .Visible = True
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "peso" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DisplayIndex = x : .HeaderText = "Peso" : .Visible = True : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_volumen As New DataGridViewTextBoxColumn
            With col_volumen
                .Name = "volumen" : .DataPropertyName = "volumen" : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DisplayIndex = x : .HeaderText = "Volumen" : .Visible = True : .DefaultCellStyle.Format = "0.00"
            End With

            x += +1
            Dim col_id_det As New DataGridViewTextBoxColumn
            With col_id_det
                .Name = "id_det" : .DataPropertyName = "id_det"
                .DisplayIndex = x : .HeaderText = "id_det" : .Visible = False
            End With

            .Columns.AddRange(col_id, col_dia, col_hora_listo, col_hora_cierre, col_cantidad, col_peso, col_volumen, col_id_det)
        End With
    End Sub
    Private Sub ConfigurarDGVLista()
        With dgvLista
            'Cls_Utilitarios.FormatDataGridView(dgvLista)
            .Columns.Clear()
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            '.RowHeadersVisible = True
            .RowHeadersWidth = 20
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
            Dim col_contacto As New DataGridViewTextBoxColumn
            With col_contacto
                .Name = "contacto" : .DataPropertyName = "contacto" : .DisplayIndex = x : .HeaderText = "Contacto" : .Visible = True
            End With
            x += +1
            Dim col_iddireccion As New DataGridViewTextBoxColumn
            With col_iddireccion
                .Name = "iddireccion" : .DataPropertyName = "iddireccion" : .DisplayIndex = x : .Visible = False : .HeaderText = "iddireccion"
            End With
            x += +1
            Dim col_direccion As New DataGridViewTextBoxColumn
            With col_direccion
                .Name = "direccion" : .DataPropertyName = "direccion" : .DisplayIndex = x : .HeaderText = "Dirección" : .Visible = True
            End With
            x += +1
            Dim col_referencia As New DataGridViewTextBoxColumn
            With col_referencia
                .Name = "referencia" : .DataPropertyName = "referencia" : .DisplayIndex = x : .HeaderText = "Referencia" : .Visible = False
            End With
            x += +1
            Dim col_idpais As New DataGridViewTextBoxColumn
            With col_idpais
                .Name = "idpais" : .DataPropertyName = "idpais" : .DisplayIndex = x : .Visible = False : .HeaderText = "idpais"
            End With
            x += +1
            Dim col_iddepartamento As New DataGridViewTextBoxColumn
            With col_iddepartamento
                .Name = "iddepartamento" : .DataPropertyName = "iddepartamento" : .DisplayIndex = x : .Visible = False : .HeaderText = "iddepartamento"
            End With
            x += +1
            Dim col_idprovincia As New DataGridViewTextBoxColumn
            With col_idprovincia
                .Name = "idprovincia" : .DataPropertyName = "idprovincia" : .DisplayIndex = x : .Visible = False : .HeaderText = "idprovincia"
            End With
            x += +1
            Dim col_iddistrito As New DataGridViewTextBoxColumn
            With col_iddistrito
                .Name = "iddistrito" : .DataPropertyName = "iddistrito" : .DisplayIndex = x : .Visible = False : .HeaderText = "iddistrito"
            End With
            x += +1
            Dim col_departamento As New DataGridViewTextBoxColumn
            With col_departamento
                .Name = "departamento" : .DataPropertyName = "departamento" : .DisplayIndex = x : .Visible = False : .HeaderText = "departamento"
            End With
            x += +1
            Dim col_provincia As New DataGridViewTextBoxColumn
            With col_provincia
                .Name = "provincia" : .DataPropertyName = "provincia" : .DisplayIndex = x : .Visible = False : .HeaderText = "provincia"
            End With
            x += +1
            Dim col_distrito As New DataGridViewTextBoxColumn
            With col_distrito
                .Name = "distrito" : .DataPropertyName = "distrito" : .DisplayIndex = x : .Visible = False : .HeaderText = "distrito"
            End With


            x += +1
            Dim col_id_via As New DataGridViewTextBoxColumn
            With col_id_via
                .Name = "id_via" : .DataPropertyName = "id_via" : .DisplayIndex = x : .HeaderText = "id_via" : .Visible = False
            End With
            x += +1
            Dim col_via As New DataGridViewTextBoxColumn
            With col_via
                .Name = "via" : .DataPropertyName = "via" : .DisplayIndex = x : .HeaderText = "via" : .Visible = False
            End With
            x += +1
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero" : .DisplayIndex = x : .HeaderText = "Número" : .Visible = False
            End With
            x += +1
            Dim col_manzana As New DataGridViewTextBoxColumn
            With col_manzana
                .Name = "manzana" : .DataPropertyName = "manzana" : .DisplayIndex = x : .HeaderText = "Manzana" : .Visible = False
            End With
            x += +1
            Dim col_lote As New DataGridViewTextBoxColumn
            With col_lote
                .Name = "lote" : .DataPropertyName = "lote" : .DisplayIndex = x : .HeaderText = "lote" : .Visible = False
            End With

            x += +1
            Dim col_id_nivel As New DataGridViewTextBoxColumn
            With col_id_nivel
                .Name = "id_nivel" : .DataPropertyName = "id_nivel" : .DisplayIndex = x : .HeaderText = "id_nivel" : .Visible = False
            End With
            x += +1
            Dim col_nivel As New DataGridViewTextBoxColumn
            With col_nivel
                .Name = "nivel" : .DataPropertyName = "nivel" : .DisplayIndex = x : .HeaderText = "nivel" : .Visible = False
            End With
            x += +1
            Dim col_id_zona As New DataGridViewTextBoxColumn
            With col_id_zona
                .Name = "id_zona" : .DataPropertyName = "id_zona" : .DisplayIndex = x : .HeaderText = "id_zona" : .Visible = False
            End With
            x += +1
            Dim col_zona As New DataGridViewTextBoxColumn
            With col_zona
                .Name = "zona" : .DataPropertyName = "via" : .DisplayIndex = x : .HeaderText = "via" : .Visible = False
            End With
            x += +1
            Dim col_id_clasificacion As New DataGridViewTextBoxColumn
            With col_id_clasificacion
                .Name = "id_clasificacion" : .DataPropertyName = "id_clasificacion" : .DisplayIndex = x : .HeaderText = "id_clasificacion" : .Visible = False
            End With
            x += +1
            Dim col_clasificacion As New DataGridViewTextBoxColumn
            With col_clasificacion
                .Name = "clasificacion" : .DataPropertyName = "clasificacion" : .DisplayIndex = x : .HeaderText = "clasificacion" : .Visible = False
            End With
            x += +1
            Dim col_ciudad As New DataGridViewTextBoxColumn
            With col_ciudad
                .Name = "ciudad" : .DataPropertyName = "ciudad" : .DisplayIndex = x : .HeaderText = "ciudad" : .Visible = False
            End With

            x += +1
            Dim col_idcontacto As New DataGridViewTextBoxColumn
            With col_idcontacto
                .Name = "idcontacto" : .DataPropertyName = "idcontacto" : .DisplayIndex = x : .HeaderText = "idcontacto" : .Visible = False
            End With
            x += +1
            Dim col_tipo_documento As New DataGridViewTextBoxColumn
            With col_tipo_documento
                .Name = "tipo_documento" : .DataPropertyName = "tipo_documento" : .DisplayIndex = x : .HeaderText = "tipo_documento" : .Visible = False
            End With
            x += +1
            Dim col_numero_documento As New DataGridViewTextBoxColumn
            With col_numero_documento
                .Name = "numero_documento" : .DataPropertyName = "numero_documento" : .DisplayIndex = x : .HeaderText = "numero_documento" : .Visible = False
            End With
            x += +1
            Dim col_email As New DataGridViewTextBoxColumn
            With col_email
                .Name = "email" : .DataPropertyName = "email" : .DisplayIndex = x : .HeaderText = "email" : .Visible = False
            End With

            x += +1
            Dim col_id_comunicacion_t As New DataGridViewTextBoxColumn
            With col_id_comunicacion_t
                .Name = "id_comunicacion_t" : .DataPropertyName = "id_comunicacion_t" : .DisplayIndex = x : .HeaderText = "id_comunicacion_t" : .Visible = False
            End With
            x += +1
            Dim col_comunicacion_t As New DataGridViewTextBoxColumn
            With col_comunicacion_t
                .Name = "comunicacion_t" : .DataPropertyName = "comunicacion_t" : .DisplayIndex = x : .HeaderText = "comunicacion_t" : .Visible = False
            End With
            x += +1
            Dim col_tipo_comunicacion_t As New DataGridViewTextBoxColumn
            With col_tipo_comunicacion_t
                .Name = "tipo_comunicacion_t" : .DataPropertyName = "tipo_comunicacion_t" : .DisplayIndex = x : .HeaderText = "tipo_comunicacion_t" : .Visible = False
            End With
            x += +1
            Dim col_id_comunicacion_m As New DataGridViewTextBoxColumn
            With col_id_comunicacion_m
                .Name = "id_comunicacion_m" : .DataPropertyName = "id_comunicacion_m" : .DisplayIndex = x : .HeaderText = "id_comunicacion_m" : .Visible = False
            End With
            x += +1
            Dim col_comunicacion_m As New DataGridViewTextBoxColumn
            With col_comunicacion_m
                .Name = "comunicacion_m" : .DataPropertyName = "comunicacion_m" : .DisplayIndex = x : .HeaderText = "comunicacion_m" : .Visible = False
            End With
            x += +1
            Dim col_tipo_comunicacion_m As New DataGridViewTextBoxColumn
            With col_tipo_comunicacion_m
                .Name = "tipo_comunicacion_m" : .DataPropertyName = "tipo_comunicacion_m" : .DisplayIndex = x : .HeaderText = "tipo_comunicacion_m" : .Visible = False
            End With
            x += +1
            Dim col_fecha_inicio As New DataGridViewTextBoxColumn
            With col_fecha_inicio
                .Name = "fecha_inicio" : .DataPropertyName = "fecha_inicio" : .DisplayIndex = x : .HeaderText = "Fecha Inicio" : .Visible = True
            End With
            x += +1
            Dim col_fecha_fin As New DataGridViewTextBoxColumn
            With col_fecha_fin
                .Name = "fecha_fin" : .DataPropertyName = "fecha_fin" : .DisplayIndex = x : .HeaderText = "Fecha Fin" : .Visible = True
            End With
            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion" : .DisplayIndex = x : .HeaderText = "Observación" : .Visible = False
            End With
            x += +1
            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .Name = "idestado" : .DataPropertyName = "idestado" : .DisplayIndex = x : .HeaderText = "idestado" : .Visible = False
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado" : .DisplayIndex = x : .HeaderText = "Estado" : .Visible = True
            End With

            .Columns.AddRange(col_id, col_contacto, col_iddireccion, col_direccion, col_referencia, _
                              col_idpais, col_iddepartamento, col_idprovincia, col_iddistrito, col_departamento, col_provincia, col_distrito, _
                              col_id_via, col_via, col_numero, col_manzana, col_lote, col_id_nivel, col_nivel, col_id_zona, col_zona, col_id_clasificacion, col_clasificacion, col_ciudad, _
                              col_idcontacto, col_tipo_documento, col_numero_documento, col_email, _
                              col_id_comunicacion_t, col_comunicacion_t, col_tipo_comunicacion_t, _
                              col_id_comunicacion_m, col_comunicacion_m, col_tipo_comunicacion_m, _
                              col_fecha_inicio, col_fecha_fin, col_observacion, col_id_estado, col_estado)
        End With
    End Sub
#End Region

    Sub ListarCliente(ByVal funcionario As Integer, ByVal perfil As Integer, ByVal dgv As DataGridView)
        'Dim obj As New Cls_ClienteCarteraFuncionario_LN
        'Dim dt As DataTable = obj.ListarCartera(funcionario, credito)
        Dim obj As New DtoRecojo
        Dim dt As DataTable = obj.ListarCliente(funcionario, perfil)
        dgv.DataSource = dt
        Me.Tsbeditar.Enabled = Me.dgvCliente.Rows.Count > 0
    End Sub

    Private Sub frmRecojoAcordado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Acceso.SiRol(G_Rol, Me, 1, 1) Then
            intPerfil = 1
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 2) Then
            intPerfil = 2
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 3) Then
            intPerfil = 3
        Else
            intPerfil = 0
        End If

        Me.Limpiar()
        Me.ConfigurarDGVCliente()
        Me.ConfigurarDGVProgramacion()
        ConfigurarDGVLista()
        ListarCliente(dtoUSUARIOS.IdLogin, intPerfil, Me.dgvCliente)
        Me.cboEstado.SelectedIndex = 1
    End Sub

    Sub Mostrar()
        Dim strCliente As String = Me.dgvCliente.CurrentRow.Cells("codigo").Value & " " & Me.dgvCliente.CurrentRow.Cells("cliente").Value
        Me.lblCliente.Text = strCliente
        Me.ListarRecojoAcordado()
    End Sub

    Sub ListarRecojoAcordado()
        Dim obj As New dtrecojo
        Dim dt As DataTable = obj.ListarRecojoAcordado(Me.dgvCliente.CurrentRow.Cells("id").Value, Me.cboEstado.SelectedIndex)
        Me.dgvLista.DataSource = dt
        If Me.dgvLista.Rows.Count > 0 Then
            Me.btnModificar.Enabled = True
            Me.btnGrabar.Enabled = True
        Else
            Limpiar()
            MostrarEstado(0)
            Me.btnModificar.Enabled = False
            Me.btnGrabar.Enabled = False
            Me.btnCancelar.Enabled = False
        End If
    End Sub

    Private Sub dgvCliente_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCliente.DoubleClick
        Me.Tsbeditar_Click(Nothing, Nothing)
    End Sub

    Private Sub Tsbeditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tsbeditar.Click
        intFilaDGVCliente = 0
        With dgvCliente
            If .Rows.Count > 0 Then
                intFilaDGVCliente = .CurrentRow.Index
                Mostrar()
                Me.tabRecojoAcordado.SelectedTab = Me.tabRecojoAcordado.TabPages("tabRecojo")
            End If
        End With
    End Sub

    Private Sub btnContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContacto.Click
        'Me.Cursor = Cursors.AppStarting
        Me.CargarContacto()
        'Me.Cursor = Cursors.Default
    End Sub

    Sub CargarContacto()
        Dim frm As New FrmContacto
        Dim obj As New dtrecojo

        frm.bNuevo = False
        frm.btnNuevo.Visible = False
        Dim correo As String
        Dim fijo As String
        Dim nro As String
        nro = Me.TxtNumero.Text.Trim
        frm.bNuevo = True
        frm.nrodoc = nro
        correo = Me.txtemail.Text.Trim
        fijo = Me.txttel.Text.Trim

        itipodocumentoCliente = Me.dgvCliente.CurrentRow.Cells("tipo").Value

        frm.nrodocumento = indocumento
        frm.txtnrodocumento.Text = IIf((indocumento = ""), nrodocumento, indocumento)
        frm.txtnrodocumento.Tag = frm.txtnrodocumento.Text
        frm.nroCliente = itipodocumentoCliente.Trim
        If itipoDoc <> 0 Or iComunicacion < 0 Then
            frm.DocContacto = itipoDoc
            frm.tipoComunicacion = iComunicacion 'pasando datos combo    
        Else
            frm.DocContacto = 3
            frm.tipoComunicacion = 0
        End If
        frm.txtnomc.Text = Me.txtContacto.Text
        frm.txtemail.Text = correo.Trim
        frm.txtfijo.Text = fijo 'IIf((fijo = ""), frm.txtfijo.Text = "", fijo)
        frm.txtmovil.Text = txtmovil.Text.Trim
        frm.numero = Me.dgvCliente.CurrentRow.Cells("codigo").Value
        frm.IdCliente = Me.dgvCliente.CurrentRow.Cells("id").Value
        frm.cliente = Me.dgvCliente.CurrentRow.Cells("cliente").Value
        frm.TabDatos.SelectedIndex = 0
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            iIdContacto = frm.intContacto
            Me.txtContacto.Text = frm.txtnomc.Text.Trim
            Me.txtemail.Text = frm.txtemail.Text.Trim
            Me.txttel.Text = frm.txtfijo.Text.Trim
            Me.txtmovil.Text = frm.txtmovil.Text.Trim
            indocumento = frm.txtnrodocumento.Text.Trim
            Me.TxtNumero.Text = indocumento
            Me.iComunicacion = frm.CboMovil.SelectedValue
            itipoDoc = frm.CboDocContacto.SelectedValue

            'If Not bNoCambioContacto Then
            'iIdContacto = 0
            'End If

            If Not bNoCambioFijo Then
                codcomunicacion_t = 0
            End If

            If Not bNoCambioMovil Then
                codcomunicacion_m = 0
            End If

            Me.btnDireccion.Focus()
        End If
    End Sub

    Function ExisteValorGrid(ByVal dgv As DataGridView, ByVal columna As Integer, ByVal valor As String, ByVal columna1 As Integer, ByVal valor1 As String, ByVal columna2 As Integer, ByVal valor2 As String, Optional ByVal fila As Integer = -1) As Boolean
        Dim existe1 As Boolean = False
        Dim existe2 As Boolean = False
        Dim procesa As Boolean
        For Each row As DataGridViewRow In dgv.Rows
            existe1 = False : existe2 = False
            procesa = True
            If fila > -1 Then
                If fila = row.Index Then
                    procesa = False
                End If
            End If
            If procesa Then
                If row.Cells(columna).Value = valor Then
                    If Not (CDate(valor1) < CDate(row.Cells(columna1).Value) And CDate(valor2) < CDate(row.Cells(columna1).Value)) Then
                        existe1 = True
                    End If
                    If Not (CDate(valor1) > CDate(row.Cells(columna2).Value) And CDate(valor2) > CDate(row.Cells(columna2).Value)) Then
                        existe2 = True
                    End If
                End If
                If existe1 And existe2 Then
                    Exit For
                End If
            End If
        Next
        Return existe1 And existe2
    End Function

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim frm As New frmMantenimientoProgramacion
        frm.Opcion = 1
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            If ExisteValorGrid(Me.dgvProgramacion, 0, frm.cboDia.SelectedIndex, 2, frm.dtpHora1.Text, 3, frm.dtpHora2.Text) Then
                MessageBox.Show("El día y/o Horario programado ya existe en la lista", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnAgregar.Focus()
                Return
            End If
            Me.MostrarProgramacion(frm)
        End If
    End Sub

    Sub MostrarProgramacion(ByVal frm As frmMantenimientoProgramacion, Optional ByVal fila As Integer = -1)
        Dim intFila As Integer
        With Me.dgvProgramacion
            If fila = -1 Then
                .Rows.Add()
                intFila = .Rows.Count - 1
            Else
                intFila = fila
            End If
            If fila = -1 Then
                .Rows(intFila).Cells("id_det").Value = 0
            End If
            .Rows(intFila).Cells("id").Value = frm.cboDia.SelectedIndex
            .Rows(intFila).Cells("dia").Value = frm.cboDia.Text
            .Rows(intFila).Cells("hora_listo").Value = frm.dtpHora1.Text
            .Rows(intFila).Cells("hora_cierre").Value = frm.dtpHora2.Text
            If Val(frm.txtBultos.Text) = 0 Then
                .Rows(intFila).Cells("cantidad").Value = ""
            Else
                .Rows(intFila).Cells("cantidad").Value = CDbl(frm.txtBultos.Text)
            End If
            If Val(frm.txtPeso.Text) = 0 Then
                .Rows(intFila).Cells("peso").Value = ""
            Else
                .Rows(intFila).Cells("peso").Value = CDbl(frm.txtPeso.Text)
            End If
            If Val(frm.txtVolumen.Text) = 0 Then
                .Rows(intFila).Cells("volumen").Value = ""
            Else
                .Rows(intFila).Cells("volumen").Value = CDbl(frm.txtVolumen.Text)
            End If
        End With
    End Sub

    Private Sub dgvProgramacion_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvProgramacion.RowsAdded
        Me.btnEliminar.Enabled = Me.btnGrabar.Enabled
    End Sub

    Private Sub dgvProgramacion_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvProgramacion.RowsRemoved
        Me.btnEliminar.Enabled = Me.dgvProgramacion.Rows.Count > 0
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            Dim blnOk As Boolean = True
            Dim obj As New DtoRecojo

            Dim intDia As Integer, intId As Integer, intIdDet As Integer
            intDia = Me.dgvProgramacion.CurrentRow.Cells("id").Value
            intId = Me.dgvLista.CurrentRow.Cells("id").Value
            intIdDet = Me.dgvProgramacion.CurrentRow.Cells("id_det").Value

            If intIdDet > 0 Then
                Dim blnTiene As Boolean = obj.ProgramacionRecojo(intId, intIdDet, intDia)
                If blnTiene Then
                    Dim strMensaje As String
                    Dim dlgRespuesta As DialogResult
                    strMensaje = "El día programado ya generó un recojo. Si después de eliminarlo, crea el mismo día, se generará otro recojo."
                    strMensaje = strMensaje & Chr(13) & Chr(13) & "¿Está seguro de eliminar el día programado?"
                    dlgRespuesta = MessageBox.Show(strMensaje, "Eliminar Programación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If dlgRespuesta = Windows.Forms.DialogResult.No Then
                        blnOk = False
                    End If
                End If
            End If
            If blnOk Then
                With Me.dgvProgramacion
                    DtoRecojo.AnularDiaProgramado(intId, intIdDet, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
                    .Rows.Remove(.CurrentRow)
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CargarDireccion()
        Dim obj As New dtrecojo
        Dim frm As New FrmDireccion
        Dim nro As String
        nro = Me.dgvCliente.CurrentRow.Cells("codigo").Value
        frm.bNuevo = True
        Dim direccion, ref As String
        direccion = Me.txtDireccion.Text
        ref = Me.txtref.Text
        frm.nrodocumento = nro
        'frm.TxtDireccion.Text = direccion
        frm.strDireccion = direccion
        frm.TxtReferencia.Text = ref

        frm.departamento = departamento
        frm.provincia = provincia
        frm.distrito = distrito

        If txtdepar.Tag = 0 Or txtpro.Tag = 0 Or txtdist.Tag = 0 Then
            frm.pais = 4
            frm.nomdepa = 15
            frm.nomprov = 17
            frm.nomdist = 2
        Else
            frm.pais = 4
            frm.nomdepa = txtdepar.Tag
            frm.nomprov = txtpro.Tag
            frm.nomdist = txtdist.Tag 'Pasando TipoComunicacion
        End If
        If dtDireccion.Rows.Count = 0 Then
            dtDireccion = obj.ListarDireccion(-100)
        End If
        frm.dtDireccion = dtDireccion

        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            'Me.txtdir.Text = frm.TxtDireccion.Text
            iIdDireccion = frm.intDireccion
            Me.txtDireccion.Text = frm.strDireccion
            Me.txtref.Text = frm.TxtReferencia.Text
            Me.txtdepar.Text = frm.CboDepartamento.Text
            Me.txtpro.Text = frm.CboProvincia.Text
            Me.txtdist.Text = frm.CboDistrito.Text
            Me.txtdepar.Tag = frm.CboDepartamento.SelectedValue
            Me.txtpro.Tag = frm.CboProvincia.SelectedValue
            Me.txtdist.Tag = frm.CboDistrito.SelectedValue
            departamento = frm.CboDepartamento.SelectedValue
            provincia = frm.CboProvincia.SelectedValue
            distrito = frm.CboDistrito.SelectedValue

            'If Not bNoCambioDireccion Then
            'iIdDireccion = 0
            'End If
            'bsalir = True
            Me.dtpInicio.Focus()
        End If
    End Sub

    Private Sub btnDireccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDireccion.Click
        'Me.Cursor = Cursors.AppStarting
        Me.CargarDireccion()
        'Me.Cursor = Cursors.Default
    End Sub


    Private Sub dtpInicio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpInicio.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub dtpFin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            Me.btnGrabar.Focus()
        End If
    End Sub

    Private Sub txtObservacion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If Me.txtContacto.Text.Trim.Length = 0 Then
            MessageBox.Show("Seleccione el contacto", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.btnContacto.Focus()
            Return
        End If

        If Me.txtDireccion.Text.Trim.Length = 0 Then
            MessageBox.Show("Seleccione la dirección", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.btnDireccion.Focus()
            Return
        End If

        'hlamas 24-01-2020
        If dtDireccion.Rows.Count > 0 Then
            If dtDireccion.Rows(0).Item("url").ToString.Trim.Length = 0 Then
                MessageBox.Show("Ubique la dirección en Google Maps", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnDireccion.Focus()
                Return
            End If
        End If

        'If dtpInicio.Value.Date > dtpFin.Value.Date Then
        '    MessageBox.Show("La fecha inicio debe ser menor o igual a la fecha fin", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    dtpInicio.Focus()
        '    Return
        'End If

        If Me.dgvProgramacion.Rows.Count = 0 Then
            MessageBox.Show("Ingrese la programación", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.btnAgregar.Focus()
            Return
        End If

        Grabar()
    End Sub

    Sub Grabar()
        Dim obj As New dtgrabarecojo
        Dim intID As Integer

        If intOperacion = Operacion.Nuevo Then
            intID = 0
        Else
            intID = Me.dgvLista.CurrentRow.Cells("id").Value
        End If

        obj.idpers = Me.dgvCliente.CurrentRow.Cells("id").Value
        obj.iddir_consignado = iIdDireccion
        obj.direccion = Me.txtDireccion.Text.Trim
        obj.referencia = Me.txtref.Text.Trim
        obj.idpais = 4
        obj.iddepartamento = dtDireccion.Rows(0).Item("iddepartamento")
        obj.idprovincia = dtDireccion.Rows(0).Item("idprovincia")
        obj.iddistrito = dtDireccion.Rows(0).Item("iddistrito")
        obj.IdVia = dtDireccion.Rows(0).Item("id_via")
        obj.Via = "" & dtDireccion.Rows(0).Item("via")
        obj.Numero = "" & dtDireccion.Rows(0).Item("numero")
        obj.Manzana = "" & dtDireccion.Rows(0).Item("manzana")
        obj.Lote = "" & dtDireccion.Rows(0).Item("lote")
        obj.IdNivel = dtDireccion.Rows(0).Item("id_nivel")
        obj.Nivel = "" & dtDireccion.Rows(0).Item("nivel")
        obj.IdZona = dtDireccion.Rows(0).Item("id_zona")
        obj.Zona = "" & dtDireccion.Rows(0).Item("zona")
        obj.IdClasificacion = dtDireccion.Rows(0).Item("id_clasificacion")
        obj.Clasificacion = "" & dtDireccion.Rows(0).Item("clasificacion")
        obj.Ciudad = dtoUSUARIOS.m_idciudad
        obj.Agencia = dtoUSUARIOS.iIDAGENCIAS

        obj.Idcontacto_persona = iIdContacto
        obj.nombres = Me.txtContacto.Text.Trim
        obj.idtipo_documento_contacto = itipoDoc
        obj.nrodocumento = Me.TxtNumero.Text.Trim
        obj.email_contacto = Me.txtemail.Text.Trim

        obj.idcomunicacion_contacto_t = codcomunicacion_t
        obj.nrocomunicacion_contacto_t = Me.txttel.Text.Trim
        obj.idtipo_comunicacion_t = 1

        obj.idcomunicacion_contacto_m = codcomunicacion_m
        obj.nrocomunicacion_contacto_m = Me.txtmovil.Text.Trim
        obj.idtipo_comunicacion_m = iComunicacion

        obj.observacion = Me.txtObservacion.Text.Trim

        'hlamas 24-01-2020
        obj.Url = "" & dtDireccion.Rows(0).Item("url")
        obj.Longitud = "" & dtDireccion.Rows(0).Item("longitud")
        obj.Latitud = "" & dtDireccion.Rows(0).Item("latitud")

        obj.Usuario = dtoUSUARIOS.IdLogin
        obj.Ip = dtoUSUARIOS.IP
        obj.Rol = dtoUSUARIOS.IdRol

        intID = obj.GrabarRecojoAcordado(intID, Me.dtpInicio.Value.ToShortDateString)
        If Me.dgvProgramacion.Rows.Count > 0 Then
            Dim intOpcion As Integer = 0, intCantidad As Integer, dblPeso As Double, dblVolumen As Double
            Dim intIdDet As Integer = 0
            With Me.dgvProgramacion
                For Each row As DataGridViewRow In .Rows
                    intIdDet = IIf(Val(row.Cells("id_det").Value) = 0, 0, row.Cells("id_det").Value)
                    intCantidad = IIf(Val(row.Cells("cantidad").Value) = 0, 0, row.Cells("cantidad").Value)
                    dblPeso = IIf(Val(row.Cells("peso").Value) = 0, 0, row.Cells("peso").Value)
                    dblVolumen = IIf(Val(row.Cells("volumen").Value) = 0, 0, row.Cells("volumen").Value)
                    obj.GrabarRecojoAcordado(intID, row.Cells("id").Value, row.Cells("hora_listo").Value, row.Cells("hora_cierre").Value, _
                                             intCantidad, dblPeso, dblVolumen, _
                                             dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol, intOpcion, intIdDet)
                    intOpcion = 1
                Next
            End With
        End If
        Me.ListarRecojoAcordado()
        MostrarEstado(3)
        Me.btnNuevo.Focus()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        intOperacion = Operacion.Nuevo
        Limpiar()
        MostrarEstado(1)
        Me.btnContacto.Focus()
    End Sub

    Private Sub dgvLista_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.RowEnter
        MostrarRecojoProgramado(e.RowIndex)
        MostrarProgramacion(Me.dgvLista.Rows(e.RowIndex).Cells("id").Value)
        Me.btnModificar.Enabled = Me.dgvLista.Rows(e.RowIndex).Cells("idestado").Value = 1
        Me.Tsbanular.Enabled = Me.dgvLista.Rows(e.RowIndex).Cells("idestado").Value = 1
        Me.btnAgregar.Enabled = Me.dgvLista.Rows(e.RowIndex).Cells("idestado").Value = 1 And Me.btnGrabar.Enabled
        Me.btnEliminar.Enabled = Me.dgvLista.Rows(e.RowIndex).Cells("idestado").Value = 1 And Me.btnGrabar.Enabled
    End Sub

    Sub MostrarProgramacion(ByVal id As Integer)
        Dim obj As New dtrecojo
        Dim intFila As Integer

        With Me.dgvProgramacion
            .Rows.Clear()
            Dim dt As DataTable = obj.ListarProgramacion(id)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .Rows.Add()
                    intFila = .Rows.Count - 1
                    .Rows(intFila).Cells("id_det").Value = row("id_det")
                    .Rows(intFila).Cells("id").Value = row("iddia")
                    .Rows(intFila).Cells("dia").Value = row("dia")
                    .Rows(intFila).Cells("hora_listo").Value = row("hora_listo")
                    .Rows(intFila).Cells("hora_cierre").Value = row("hora_cierre")
                    If Val(row("cantidad")) = 0 Then
                        .Rows(intFila).Cells("cantidad").Value = ""
                    Else
                        .Rows(intFila).Cells("cantidad").Value = row("cantidad")
                    End If
                    If Val(row("peso")) = 0 Then
                        .Rows(intFila).Cells("peso").Value = ""
                    Else
                        .Rows(intFila).Cells("peso").Value = row("peso")
                    End If
                    If Val(row("volumen")) = 0 Then
                        .Rows(intFila).Cells("volumen").Value = ""
                    Else
                        .Rows(intFila).Cells("volumen").Value = row("volumen")
                    End If
                Next
            End If
        End With
    End Sub
    Sub MostrarRecojoProgramado(ByVal fila As Integer)
        With Me.dgvLista
            Me.txtContacto.Text = .Rows(fila).Cells("contacto").Value
            Me.TxtNumero.Text = "" & .Rows(fila).Cells("numero_documento").Value
            Me.txtemail.Text = "" & .Rows(fila).Cells("email").Value
            Me.txttel.Text = "" & .Rows(fila).Cells("comunicacion_t").Value
            Me.txtmovil.Text = "" & .Rows(fila).Cells("comunicacion_m").Value

            Me.txtDireccion.Text = .Rows(fila).Cells("direccion").Value
            Me.txtref.Text = "" & .Rows(fila).Cells("referencia").Value
            Me.txtdepar.Text = "" & .Rows(fila).Cells("departamento").Value
            Me.txtpro.Text = "" & .Rows(fila).Cells("provincia").Value
            Me.txtdist.Text = "" & .Rows(fila).Cells("distrito").Value

            Me.dtpInicio.Text = "" & .Rows(fila).Cells("fecha_inicio").Value

            indocumento = "" & .Rows(fila).Cells("numero_documento").Value
            itipoDoc = .Rows(fila).Cells("tipo_documento").Value
            iComunicacion = .Rows(fila).Cells("tipo_comunicacion_m").Value
            iIdDireccion = .Rows(fila).Cells("iddireccion").Value

            iIdContacto = .Rows(fila).Cells("idcontacto").Value
            codcomunicacion_m = .Rows(fila).Cells("id_comunicacion_m").Value
            codcomunicacion_t = .Rows(fila).Cells("id_comunicacion_t").Value

            Dim obj As New dtrecojo
            dtDireccion = obj.ListarDireccion(Me.dgvLista.Rows(fila).Cells("iddireccion").Value)
        End With
    End Sub

    Private Sub tabRecojoAcordado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabRecojoAcordado.SelectedIndexChanged
        If Me.tabRecojoAcordado.SelectedIndex = 0 Then
            Me.Tsbeditar.Enabled = Me.dgvCliente.Rows.Count > 0
            Me.Tsbanular.Enabled = False
        Else
            Me.Tsbeditar.Enabled = False
            Me.Tsbanular.Enabled = False
            MostrarEstado(0)
        End If
    End Sub

    Sub Limpiar()
        Me.txtContacto.Text = ""
        Me.TxtNumero.Text = ""
        Me.txtemail.Text = ""
        Me.txttel.Text = ""
        Me.txtmovil.Text = ""
        Me.txtref.Text = ""
        Me.txtdepar.Text = ""
        Me.txtpro.Text = ""
        Me.txtdist.Text = ""
        Me.dtpInicio.Value = Now
        Me.txtObservacion.Text = ""
        Me.txtDireccion.Text = ""

        Me.dgvLista.DataSource = Nothing
        Me.dgvProgramacion.Rows.Clear()

        indocumento = ""
        iComunicacion = 0
        itipoDoc = 0
        departamento = 0
        provincia = 0
        distrito = 0
        dtDireccion.Rows.Clear()

        Me.btnNuevo.Focus()
    End Sub

    Sub MostrarEstado(ByVal opcion As Integer)
        Me.dgvLista.Enabled = True
        Me.dgvProgramacion.Enabled = True
        Me.cboEstado.Enabled = True
        If opcion = 0 Then
            Me.btnNuevo.Enabled = True
            If Me.dgvLista.Rows.Count > 0 Then
                Me.btnModificar.Enabled = Me.dgvLista.CurrentRow.Cells("idestado").Value = 1
                Me.Tsbanular.Enabled = Me.dgvLista.CurrentRow.Cells("idestado").Value = 1
            Else
                Me.btnModificar.Enabled = False
                Me.Tsbanular.Enabled = False
            End If
            Me.btnGrabar.Enabled = False
            Me.btnCancelar.Enabled = False

            Me.btnContacto.Enabled = False
            Me.btnDireccion.Enabled = False
            Me.dtpInicio.Enabled = False
            Me.txtObservacion.Enabled = False
            Me.btnAgregar.Enabled = False
            Me.btnEliminar.Enabled = False
            Me.cboEstado.Enabled = True
        ElseIf opcion = 1 Then
            Me.btnNuevo.Enabled = False
            Me.btnModificar.Enabled = False
            Me.btnGrabar.Enabled = True
            Me.btnCancelar.Enabled = True

            Me.btnContacto.Enabled = True
            Me.btnDireccion.Enabled = True
            Me.dtpInicio.Enabled = True
            Me.txtObservacion.Enabled = True
            Me.btnAgregar.Enabled = True

            Me.Tsbanular.Enabled = False

            Me.dgvLista.Enabled = False
            Me.dgvProgramacion.Enabled = False
            Me.cboEstado.Enabled = True
        ElseIf opcion = 2 Then
            Me.btnNuevo.Enabled = False
            Me.btnModificar.Enabled = False
            Me.btnGrabar.Enabled = True
            Me.btnCancelar.Enabled = True

            Me.btnContacto.Enabled = False
            Me.btnDireccion.Enabled = True
            Me.dtpInicio.Enabled = True
            Me.txtObservacion.Enabled = True
            Me.btnAgregar.Enabled = True
            Me.btnEliminar.Enabled = Me.dgvProgramacion.Rows.Count > 0
            Me.Tsbanular.Enabled = False

            Me.dgvLista.Enabled = False
            Me.dgvProgramacion.Enabled = True
        ElseIf opcion = 3 Then
            Me.btnNuevo.Enabled = True
            If Me.dgvLista.Rows.Count > 0 Then
                Me.btnModificar.Enabled = Me.dgvLista.CurrentRow.Cells("idestado").Value = 1
                Me.Tsbanular.Enabled = Me.dgvLista.CurrentRow.Cells("idestado").Value = 1
            Else
                Me.btnModificar.Enabled = False
                Me.Tsbanular.Enabled = False
            End If
            Me.btnGrabar.Enabled = False
            Me.btnCancelar.Enabled = False

            Me.btnContacto.Enabled = False
            Me.btnDireccion.Enabled = False
            Me.dtpInicio.Enabled = False
            Me.txtObservacion.Enabled = False
            Me.btnAgregar.Enabled = False
            Me.btnEliminar.Enabled = False
        ElseIf opcion = 4 Then
            Me.btnNuevo.Enabled = True
            If Me.dgvLista.Rows.Count > 0 Then
                Me.btnModificar.Enabled = Me.dgvLista.CurrentRow.Cells("idestado").Value = 1
                Me.Tsbanular.Enabled = Me.dgvLista.CurrentRow.Cells("idestado").Value = 1
            Else
                Me.btnModificar.Enabled = False
                Me.Tsbanular.Enabled = False
            End If
            Me.btnGrabar.Enabled = False
            Me.btnCancelar.Enabled = False

            Me.btnContacto.Enabled = False
            Me.btnDireccion.Enabled = False
            Me.dtpInicio.Enabled = False
            Me.txtObservacion.Enabled = False
            Me.btnAgregar.Enabled = False
            Me.btnEliminar.Enabled = False
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar()
        If Me.dgvLista.Rows.Count > 0 Then
            MostrarRecojoProgramado(Me.dgvLista.CurrentCell.RowIndex)
            MostrarProgramacion(Me.dgvLista.Rows(Me.dgvLista.CurrentCell.RowIndex).Cells("id").Value)
            Me.btnModificar.Enabled = Me.dgvLista.Rows(Me.dgvLista.CurrentCell.RowIndex).Cells("idestado").Value = 1
        Else
            Me.cboEstado_SelectedIndexChanged(Nothing, Nothing)
        End If
        MostrarEstado(4)
        If intOperacion = Operacion.Nuevo Then
            Me.btnNuevo.Focus()
        Else
            Me.btnModificar.Focus()
        End If
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        intOperacion = Operacion.Modificar
        MostrarEstado(2)
        Me.dtpInicio.Focus()
    End Sub

    Sub DesactivarRecojo()
        Dim obj As New dtrecojo
        obj.DesactivarRecojo(Me.dgvLista.CurrentRow.Cells("id").Value, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
        ListarRecojoAcordado()
        MostrarEstado(0)
    End Sub

    Private Sub Tsbanular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tsbanular.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está seguro de desactivar la programación seleccionada?", "Recojo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            DesactivarRecojo()
        End If
    End Sub

    Private Sub cboEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstado.SelectedIndexChanged
        ListarRecojoAcordado()
        MostrarEstado(0)
    End Sub

    Private Sub TsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbSalir.Click
        Close()
    End Sub

    Private Sub dgvProgramacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvProgramacion.DoubleClick
        If Me.btnGrabar.Enabled = False Then Return
        If Me.dgvProgramacion.Rows.Count > 0 Then
            Dim frm As New frmMantenimientoProgramacion
            frm.Opcion = 2
            frm.cboDia.Enabled = False
            frm.Dia = Me.dgvProgramacion.CurrentRow.Cells("id").Value
            frm.HoraListo = Me.dgvProgramacion.CurrentRow.Cells("hora_listo").Value
            frm.HoraCierre = Me.dgvProgramacion.CurrentRow.Cells("hora_cierre").Value
            If Val(Me.dgvProgramacion.CurrentRow.Cells("cantidad").Value) = 0 Then
                frm.Cantidad = 0
            Else
                frm.Cantidad = Me.dgvProgramacion.CurrentRow.Cells("cantidad").Value
            End If
            If Val(Me.dgvProgramacion.CurrentRow.Cells("peso").Value) = 0 Then
                frm.Peso = 0
            Else
                frm.Peso = Me.dgvProgramacion.CurrentRow.Cells("peso").Value
            End If
            If Val(Me.dgvProgramacion.CurrentRow.Cells("volumen").Value) = 0 Then
                frm.Volumen = 0
            Else
                frm.Volumen = Me.dgvProgramacion.CurrentRow.Cells("volumen").Value
            End If
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                If ExisteValorGrid(Me.dgvProgramacion, 0, frm.cboDia.SelectedIndex, 2, frm.dtpHora1.Text, 3, frm.dtpHora2.Text, Me.dgvProgramacion.CurrentCell.RowIndex) Then
                    MessageBox.Show("El día y/o Horario programado ya existe en la lista", "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.btnAgregar.Focus()
                    Return
                End If
                Me.MostrarProgramacion(frm, Me.dgvProgramacion.CurrentCell.RowIndex)
            End If
        End If
    End Sub

    Private Sub dgvLista_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.CellContentClick

    End Sub
End Class