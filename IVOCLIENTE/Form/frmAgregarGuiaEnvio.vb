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

#End Region

    Sub FormatearGrid()
        With dgvResultado
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvSalida)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
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
            .ReadOnly = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            .ReadOnly = False


            Dim x As Integer = 0
            Dim col_idguia As New DataGridViewTextBoxColumn
            With col_idguia
                .Name = "idguia" : .DataPropertyName = "idguia"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idguia"
            End With
            x += +1
            Dim col_guia As New DataGridViewTextBoxColumn
            With col_guia
                .Name = "guia" : .DataPropertyName = "guia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Guía"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente"
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
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
            x += +1
            Dim col_idagencias As New DataGridViewTextBoxColumn
            With col_idagencias
                .Name = "idagencias" : .DataPropertyName = "idagencias"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idagencias"
            End With
            x += +1
            Dim col_idagencias_destino As New DataGridViewTextBoxColumn
            With col_idagencias_destino
                .Name = "idagencias_destino" : .DataPropertyName = "idagencias_destino"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idagencias_destino"
            End With
            x += +1
            Dim col_idcliente As New DataGridViewTextBoxColumn
            With col_idcliente
                .Name = "idcliente" : .DataPropertyName = "idcliente"
                .DisplayIndex = x : .Visible = False : .HeaderText = "idcliente"
            End With
            .Columns.AddRange(col_idguia, col_guia, col_cliente, col_origen, col_destino, col_total, col_idagencias, col_idagencias_destino, _
                              col_idcliente)
        End With
    End Sub

    Private Sub frmAgregarGuiaEnvio_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub frmAgregarGuiaEnvio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FormatearGrid()
        Me.lblCliente.Text = Cliente
    End Sub

    Private Sub txtGuiaEnvio_Enter(sender As Object, e As System.EventArgs) Handles txtGuiaEnvio.Enter
        Me.txtGuiaEnvio.SelectAll()
    End Sub

    Private Sub txtGuiaEnvio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtGuiaEnvio.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Try
            If Val(Me.txtGuiaEnvio.Text) = 0 Then
                MessageBox.Show("Ingrese Nº de Guía de Envío", "Agregar Guía de Envío", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtGuiaEnvio.Focus()
                Return
            End If

            Cursor = Cursors.AppStarting
            Me.Text = Me.Text & Space(10) & "Buscando..."
            Dim intGuia As Integer = Val(Me.txtGuiaEnvio.Text)
            Dim obj As New Cls_ClienteFueraZona_LN
            Dim dt As DataTable = obj.BuscarGuiaEnvio(intGuia)
            Me.dgvResultado.DataSource = dt
            FormatearGrid()
            Cursor = Cursors.Default
            Me.Text = "Agregar Guía de Envío"

            If dt.Rows.Count > 0 Then
                Me.btnAceptar.Enabled = True
                Me.btnAceptar.Focus()
            Else
                Me.btnAceptar.Enabled = False
                FormatearGrid()
                MessageBox.Show("No se encontraron Coincidencias", "Agregar Guía de Envío", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtGuiaEnvio.Focus()
            End If
        Catch ex As Exception
            Me.Text = "Agregar Guía de Envío"
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtGuiaEnvio_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGuiaEnvio.TextChanged
        Me.btnAceptar.Enabled = False
        Me.dgvResultado.DataSource = Nothing
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If IDCliente <> Me.dgvResultado.CurrentRow.Cells("idcliente").Value Then
            MessageBox.Show("El Cliente no coincide", "Agregar Guía de Envío", MessageBoxButtons.OK, MessageBoxIcon.Information)
            blnSalir = False
            Return
        End If

        'If AgenciaDestino <> Me.dgvResultado.CurrentRow.Cells("idagencias_destino").Value Then
        '    MessageBox.Show("La Agencia Destino no coincide", "Agregar Guía de Envío", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    blnSalir = False
        '    Return
        'End If
    End Sub
End Class