Imports INTEGRACION_LN
Public Class frmAgregarGuiaEnvio
    Dim blnSalir As Boolean = True

#Region "Propiedades"
    Private intIDCliente As Integer
    Public Property IDCliente() As Integer
        Get
            Return intIDCliente
        End Get
        Set(ByVal value As Integer)
            intIDCliente = value
        End Set
    End Property

    Private strCliente As String
    Public Property Cliente() As String
        Get
            Return strCliente
        End Get
        Set(ByVal value As String)
            strCliente = value
        End Set
    End Property

    Private intAgenciaDestino As Integer
    Public Property AgenciaDestino() As Integer
        Get
            Return intAgenciaDestino
        End Get
        Set(ByVal value As Integer)
            intAgenciaDestino = value
        End Set
    End Property

    Private strAgenciaDestino As String
    Public Property NombreAgenciaDestino() As String
        Get
            Return strAgenciaDestino
        End Get
        Set(ByVal value As String)
            strAgenciaDestino = value
        End Set
    End Property

    Private intTipo As Integer
    Public Property Tipo() As Integer
        Get
            Return intTipo
        End Get
        Set(ByVal value As Integer)
            intTipo = value
        End Set
    End Property

    Private operacion As Integer
    Public Property getOperacion() As Integer
        Get
            Return operacion
        End Get
        Set(ByVal value As Integer)
            operacion = value
        End Set
    End Property


#End Region

    Sub FormatearGrid()

        With dgvResultado
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvSalida)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = False
            '.EditMode = DataGridViewEditMode.EditOnEnter
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black
            .EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2

            Dim x As Integer = 0
            Dim col_sel As New DataGridViewCheckBoxColumn
            With col_sel
                .HeaderText = "Sel"
                .Name = "sel"
                '.DataPropertyName = "IDESTADO_REGISTRO"
                .Width = 100
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
                .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_idtipo As New DataGridViewTextBoxColumn
            With col_idtipo
                .Name = "idtipo" : .DataPropertyName = "idtipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo"
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Comprobante"
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
                .DisplayIndex = x : .Visible = True : .HeaderText = "Bultos"
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
            Dim col_idagencia_origen As New DataGridViewTextBoxColumn
            With col_idagencia_origen
                .Name = "idagencia_origen" : .DataPropertyName = "idagencia_origen"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idagencia_origen"
            End With
            x += +1
            Dim col_idagencia_destino As New DataGridViewTextBoxColumn
            With col_idagencia_destino
                .Name = "idagencia_destino" : .DataPropertyName = "idagencia_destino"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idagencia_destino"
            End With
            x += +1
            Dim col_idcliente As New DataGridViewTextBoxColumn
            With col_idcliente
                .Name = "idcliente" : .DataPropertyName = "idcliente"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcliente"
            End With
            .Columns.AddRange(col_sel, col_id, col_fecha, col_idtipo, col_tipo, col_comprobante, col_origen, col_destino, col_agencia_origen, col_agencia_destino, _
                              col_total, col_cantidad, col_peso, col_direccion, col_idagencia_origen, col_idagencia_destino, col_idcliente)
        End With
    End Sub

    Private Sub frmAgregarGuiaEnvio_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmAgregarGuiaEnvio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.cboTipo.SelectedIndex = 0
        FormatearGrid()
        Me.lblCliente.Text = Cliente
        Me.lblOficina.Text = NombreAgenciaDestino
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Aceptar()
    End Sub

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        Try
            Cursor = Cursors.AppStarting
            Me.Text = Me.Text & Space(10) & "Buscando..."
            Dim obj As New dtoFueraZona
            'hlamas 03-05-2016
            Tipo = Me.cboTipo.SelectedIndex
            Dim dt As DataTable
            If operacion = 0 Then
                dt = obj.ListarComprobante(IDCliente, AgenciaDestino, Tipo)
            Else
                dt = obj.ListarComprobanteEmbalaje(IDCliente, AgenciaDestino, Tipo)
            End If
            'Dim dt As DataTable = obj.ListarGuiaEnvio(IDCliente, AgenciaDestino)
            Me.dgvResultado.DataSource = dt
            FormatearGrid()
            Cursor = Cursors.Default
            Me.Text = "Agregar Comprobante"

            If dt.Rows.Count > 0 Then
                Me.dgvResultado.CurrentCell = Me.dgvResultado.Rows(0).Cells(0)
            Else
                Me.btnAceptar.Enabled = False
                FormatearGrid()
                MessageBox.Show("No se encontraron Coincidencias", "Agregar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnCancelar.Focus()
            End If
        Catch ex As Exception
            Me.Text = "Agregar Comprobante"
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvResultado_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvResultado.CellContentClick
        If e.ColumnIndex <> 0 Then Return
        Activar()
    End Sub

    Private Sub dgvResultado_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles dgvResultado.CurrentCellDirtyStateChanged
        dgvResultado.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Function NumeroCheck(ByVal dgv As DataGridView) As Integer
        Dim intNumero As Integer = 0
        For Each row As DataGridViewRow In dgv.Rows
            If Not IsNothing(row.Cells(0).Value) Then
                If row.Cells(0).Value = 1 Then
                    intNumero += 1
                End If
            End If
        Next
        Return intNumero
    End Function

    Sub Activar()
        If NumeroCheck(dgvResultado) = 0 Then
            Me.btnAceptar.Enabled = False
        Else
            Me.btnAceptar.Enabled = True
        End If
    End Sub

    Sub Aceptar()

    End Sub

    Private Sub frmAgregarGuiaEnvio_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.btnActualizar.Focus()
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        Me.btnActualizar.Enabled = Me.cboTipo.SelectedIndex > 0
    End Sub
End Class