Public Class frmMovimientoCaja

#Region "Propiedad"

    Private strEstado As String
    Public Property Estado() As String
        Get
            Return strEstado
        End Get
        Set(ByVal value As String)
            strEstado = value
        End Set
    End Property

    Private strFecha As String
    Public Property Fecha() As String
        Get
            Return strFecha
        End Get
        Set(ByVal value As String)
            strFecha = value
        End Set
    End Property

    Private intNivel As Integer
    Public Property Nivel() As Integer
        Get
            Return intNivel
        End Get
        Set(ByVal value As Integer)
            intNivel = value
        End Set
    End Property

    Private intUsuario As Integer
    Public Property Usuario() As Integer
        Get
            Return intUsuario
        End Get
        Set(ByVal value As Integer)
            intUsuario = value
        End Set
    End Property

    Private intAgencia As Integer
    Public Property Agencia() As Integer
        Get
            Return intAgencia
        End Get
        Set(ByVal value As Integer)
            intAgencia = value
        End Set
    End Property

#End Region

    Dim blnEditar As Boolean

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
            .RowHeadersVisible = False
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
            Dim col_agencia As New DataGridViewTextBoxColumn
            With col_agencia
                .Name = "agencia" : .DataPropertyName = "agencia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_monto As New DataGridViewTextBoxColumn
            With col_monto
                .Name = "monto" : .DataPropertyName = "monto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            x += +1
            Dim col_idagencia As New DataGridViewTextBoxColumn
            With col_idagencia
                .Name = "idagencia" : .DataPropertyName = "idagencia" : .DisplayIndex = x : .Visible = False : .HeaderText = "idagencia"
            End With
            x += +1
            Dim col_idusuario As New DataGridViewTextBoxColumn
            With col_idusuario
                .Name = "idusuario" : .DataPropertyName = "idusuario" : .DisplayIndex = x : .Visible = False : .HeaderText = "idusuario"
            End With
            x += +1
            Dim col_idtipo As New DataGridViewTextBoxColumn
            With col_idtipo
                .Name = "idtipo" : .DataPropertyName = "idtipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo"
            End With

            .Columns.AddRange(col_id, col_fecha, col_agencia, col_usuario, col_tipo, col_monto, col_idagencia, col_idusuario, col_idtipo)
        End With
    End Sub

    Private Sub frmMovimientoCaja_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Estado = "A" Then
            Me.tsbNuevo.Enabled = True
        Else
            Me.tsbNuevo.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbGrabar.Enabled = False
            Me.tsbAnular.Enabled = False
        End If

        Dim obj As New dtoCierreOficina
        Dim ds As DataSet = obj.Inicio(dtoUSUARIOS.IdLogin, dtoUSUARIOS.iIDAGENCIAS, dtoUSUARIOS.m_sFecha)
        Me.lblFecha.Text = CType(Fecha, Date).ToShortDateString
        FormateardgvLista()

        With Me.CboTipoMovimiento
            .DataSource = ds.Tables(1)
            .DisplayMember = "Movimiento"
            .ValueMember = "IDTipoMovimiento"
            .SelectedValue = 0
        End With

        With Me.CboDestino
            .DataSource = ds.Tables(2)
            .DisplayMember = "NOMBRE_UNIDAD"
            .ValueMember = "IDUNIDAD_AGENCIA"
            .SelectedValue = 0
        End With

        With Me.CboPiloto
            .DataSource = ds.Tables(3)
            .DisplayMember = "nombre"
            .ValueMember = "idusuario_personal"
            .SelectedValue = 0
        End With

        If intNivel <> 3 Or Estado = "C" Then
            Me.tsbNuevo.Enabled = False
        End If
    End Sub

    Private Sub TxtNroDocumento_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNroDocumento.Enter
        Me.TxtNroDocumento.SelectAll()
    End Sub

    Private Sub TxtNroDocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroDocumento.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub CboTipoMovimiento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboTipoMovimiento.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub TxtNroOperacion_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNroOperacion.Enter
        Me.TxtNroOperacion.SelectAll()
    End Sub

    Private Sub TxtNroOperacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroOperacion.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtNroOperacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNroOperacion.TextChanged

    End Sub

    Private Sub TxtCodigoPeaje_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCodigoPeaje.Enter
        Me.TxtCodigoPeaje.SelectAll()
    End Sub

    Private Sub TxtCodigoPeaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoPeaje.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtCodigoPeaje_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoPeaje.TextChanged

    End Sub

    Private Sub TxtMonto_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMonto.Enter
        Me.TxtMonto.SelectAll()
    End Sub

    Private Sub TxtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMonto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumeroReal(e.KeyChar, TxtMonto.Text) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtMonto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMonto.LostFocus
        Dim dblMonto As Double
        If Val(TxtMonto.Text) = 0 Then
            dblMonto = 0
        Else
            dblMonto = Me.TxtMonto.Text
        End If
        Me.TxtMonto.Text = Format(dblMonto, "0.00")
    End Sub

    Private Sub CboDestino_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboDestino.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub CboDestino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDestino.SelectedIndexChanged

    End Sub

    Private Sub TxtNroBus_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNroBus.Enter
        Me.TxtNroBus.SelectAll()
    End Sub

    Private Sub TxtNroBus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroBus.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtNroBus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNroBus.TextChanged

    End Sub

    Private Sub CboPiloto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboPiloto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If

    End Sub

    Private Sub TxtDepositante_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDepositante.Enter
        Me.TxtDepositante.SelectAll()
    End Sub

    Private Sub TxtDesositante_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDepositante.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub TxtContacto_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtContacto.Enter
        Me.TxtContacto.SelectAll()
    End Sub

    Private Sub TxtContacto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtContacto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub TxtObservaciones_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtObservaciones.Enter
        Me.TxtObservaciones.SelectAll()
    End Sub

    Private Sub TxtObservaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtObservaciones.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.tsbGrabar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TxtObservaciones_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtObservaciones.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub

    Sub Limpiar()
        For Each obj As Control In Me.tabMovimientoCaja.TabPages(1).Controls
            If TypeOf obj Is TextBox Then
                obj.Text = ""
                obj.Enabled = False
            End If
        Next
        CboDestino.SelectedValue = 0
        CboPiloto.SelectedValue = 0
    End Sub

    Sub Enabilitar(ByVal Control1 As String, ByVal Control2 As String, ByVal Control3 As String, ByVal Control4 As String, ByVal Control5 As String, ByVal Control6 As String)
        For Each obj As Control In Me.tabMovimientoCaja.TabPages(1).Controls
            If TypeOf obj Is TextBox Or TypeOf obj Is ComboBox Then
                If obj.Name <> Control1 And obj.Name <> Control2 And obj.Name <> Control3 And obj.Name <> Control4 And obj.Name <> Control5 And obj.Name <> Control6 And obj.Name <> "CboTipoMovimiento" Then
                    obj.Enabled = False
                End If
            End If
        Next
    End Sub

    Private Sub CboTipoMovimiento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoMovimiento.SelectedIndexChanged
        If intNivel <> 3 or Estado="C" Then Return
        Try
            If Not IsReference(CboTipoMovimiento.SelectedValue) Then
                If Not blnEditar Then Me.Limpiar()
                If CboTipoMovimiento.SelectedValue = 1 Then
                    TxtCodigoPeaje.Enabled = True
                    TxtMonto.Enabled = True
                    If blnEditar Then
                        Me.CboDestino.Enabled = False
                        Me.CboPiloto.Enabled = False
                    Else
                        Me.CboDestino.Enabled = True
                        Me.CboPiloto.Enabled = True
                    End If
                    Me.TxtNroBus.Enabled = True
                    Me.TxtObservaciones.Enabled = True
                    Me.Enabilitar("TxtCodigoPeaje", "TxtMonto", "CboDestino", "TxtNroBus", "CboPiloto", "TxtObservaciones") 'Diferente Del Texto Ingresado
                    Me.TxtCodigoPeaje.Focus()
                ElseIf CboTipoMovimiento.SelectedValue = 2 Then
                    TxtNroDocumento.Enabled = True
                    TxtMonto.Enabled = True
                    TxtObservaciones.Enabled = True
                    Me.Enabilitar("TxtNroDocumento", "TxtMonto", "TxtObservaciones", "", "", "")
                    TxtNroDocumento.Focus()

                ElseIf CboTipoMovimiento.SelectedValue = 3 Then
                    TxtMonto.Enabled = True
                    TxtContacto.Enabled = True
                    TxtObservaciones.Enabled = True
                    Me.Enabilitar("TxtMonto", "TxtContacto", "TxtObservaciones", "", "", "")
                    TxtMonto.Focus()

                ElseIf CboTipoMovimiento.SelectedValue = 4 Then
                    TxtMonto.Enabled = True
                    TxtContacto.Enabled = True
                    TxtObservaciones.Enabled = True
                    Me.Enabilitar("TxtMonto", "TxtContacto", "TxtObservaciones", "", "", "")
                    TxtMonto.Focus()

                ElseIf CboTipoMovimiento.SelectedValue = 6 Then
                    TxtNroDocumento.Enabled = True
                    TxtMonto.Enabled = True
                    TxtContacto.Enabled = True
                    TxtObservaciones.Enabled = True
                    Me.Enabilitar("TxtMonto", "TxtContacto", "TxtObservaciones", "TxtNroDocumento", "", "")
                    TxtNroDocumento.Focus()

                ElseIf CboTipoMovimiento.SelectedValue = 7 Then
                    Me.TxtNroOperacion.Enabled = True
                    Me.TxtMonto.Enabled = True
                    Me.TxtDepositante.Enabled = True
                    Me.TxtContacto.Enabled = True
                    Me.TxtObservaciones.Enabled = True
                    Me.Enabilitar("TxtNroOperacion", "TxtMonto", "TxtDepositante", "TxtContacto", "TxtObservaciones", "")
                    Me.TxtNroOperacion.Focus()

                ElseIf CboTipoMovimiento.SelectedValue = 8 Then
                    Me.TxtNroDocumento.Enabled = True
                    Me.TxtMonto.Enabled = True
                    Me.TxtObservaciones.Enabled = True
                    Me.Enabilitar("TxtNroDocumento", "TxtMonto", "", "", "", "TxtObservaciones")
                    Me.TxtNroDocumento.Focus()

                ElseIf CboTipoMovimiento.SelectedValue = 9 Then
                    Me.TxtMonto.Enabled = True
                    Me.TxtObservaciones.Enabled = True
                    Me.Enabilitar("", "TxtMonto", "", "", "", "TxtObservaciones")
                    Me.TxtMonto.Focus()

                ElseIf CboTipoMovimiento.SelectedValue = 10 Then
                    Me.TxtNroDocumento.Enabled = True
                    Me.TxtMonto.Enabled = True
                    Me.TxtObservaciones.Enabled = True
                    Me.Enabilitar("TxtNroDocumento", "TxtMonto", "", "", "", "TxtObservaciones")
                    Me.TxtNroDocumento.Focus()

                ElseIf CboTipoMovimiento.SelectedValue = 0 Then
                    Me.Limpiar()
                Else
                    TxtNroOperacion.Enabled = True
                    TxtMonto.Enabled = True
                    TxtDepositante.Enabled = True
                    TxtContacto.Enabled = True
                    TxtObservaciones.Enabled = True
                    Me.Enabilitar("TxtNroOperacion", "TxtMonto", "TxtDepositante", "TxtContacto", "TxtObservaciones", "")
                    TxtNroOperacion.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Function validar() As Boolean
        If CboTipoMovimiento.SelectedValue = 0 Then
            MessageBox.Show("Seleccione tipo de movimiento", "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CboTipoMovimiento.Focus()
            CboTipoMovimiento.DroppedDown = True
            Return False
        End If

        If CboTipoMovimiento.SelectedValue = 1 Then
            If Val(TxtCodigoPeaje.Text.Trim) = 0 Then
                MessageBox.Show("Ingrese codigo de peaje", "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtCodigoPeaje.Focus()
                Return False
            End If

            If Val(TxtMonto.Text.Trim) = 0 Then
                MessageBox.Show("Ingrese monto de peaje", "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtMonto.Focus()
                Return False
            End If

            If CboDestino.SelectedValue = 0 Then
                MessageBox.Show("Seleccionar destino de peaje", "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CboDestino.Focus()
                CboDestino.DroppedDown = True
                Return False
            End If

            If Val(TxtNroBus.Text.Trim) = 0 Then
                MessageBox.Show("Ingrese Nº de bus al que se asigno el peaje", "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtNroBus.Focus()
                Return False
            End If

            If CboPiloto.SelectedValue = 0 Then
                MessageBox.Show("Seleccione piloto a quien se pago el peaje", "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CboPiloto.Focus()
                CboPiloto.DroppedDown = True
                Return False
            End If
            Return True

        ElseIf CboTipoMovimiento.SelectedValue = 2 Then
            If Val(TxtNroDocumento.Text.Trim) = 0 Then
                MessageBox.Show("Ingrese número de la boleta/factura que se está devolviendo", "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtNroDocumento.Focus()
                Return False
            End If

            If Val(TxtMonto.Text.Trim) = 0 Then
                MessageBox.Show("Ingrese monto al que asciende el ingreso adicional a la caja de la liquidacion", "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtMonto.Focus()
                Return False
            End If
            Return True
        ElseIf CboTipoMovimiento.SelectedValue = 3 Then
            If Val(TxtMonto.Text.Trim) = 0 Then
                MessageBox.Show("Ingrese monto al que asciende el gasto con recibo de caja", "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtMonto.Focus()
                Return False
            End If

            If TxtContacto.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese la persona que autorizó el gasto", "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtContacto.Focus()
                Return False
            End If
            Return True

        ElseIf CboTipoMovimiento.SelectedValue = 6 Then
            If Val(TxtNroDocumento.Text.Trim) = 0 Then
                MessageBox.Show("Ingrese número de Documento ", "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtNroOperacion.Focus()
                Return False
            End If

            If Val(TxtMonto.Text.Trim) = 0 Then
                MessageBox.Show("Ingrese el Monto", "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtMonto.Focus()
                Return False
            End If
            Return True
        ElseIf CboTipoMovimiento.SelectedValue = 7 Then
            If Val(TxtNroOperacion.Text.Trim) = 0 Then
                MessageBox.Show("Ingrese número de la operacion bancaria o transferencia ", "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtNroOperacion.Focus()
                Return False
            End If

            If Val(TxtMonto.Text.Trim) = 0 Then
                MessageBox.Show("Ingrese Monto al que asciende la Transferencia", "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtMonto.Focus()
                Return False
            End If

            If TxtDepositante.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese los datos de la persona y/o empresa que realizo el depósito", "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtDepositante.Focus()
                Return False
            End If
            Return True
        ElseIf CboTipoMovimiento.SelectedValue = 8 Then
            If Val(TxtNroDocumento.Text.Trim) = 0 Then
                MessageBox.Show("Ingrese número de la boleta/factura que se esté devolviendo", "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtNroDocumento.Focus()
                Return False
            End If

            If Val(TxtMonto.Text.Trim) = 0 Then
                MessageBox.Show("Ingrese monto al que asciende la carga devuelta", "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtMonto.Focus()
                Return False
            End If
            Return True
        Else
            If Val(TxtMonto.Text.Trim) = 0 Then
                MessageBox.Show("Ingrese el monto", "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtMonto.Focus()
                Return False
            End If
            Return True
        End If
        Return True
    End Function

    Sub desactivar()
        For Each obj As Control In Me.tabMovimientoCaja.TabPages(1).Controls
            If TypeOf obj Is TextBox Then
                obj.Enabled = False
            End If
        Next
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        Dim intID As Integer, intOpcion As Integer
        Try
            Me.Cursor = Cursors.AppStarting
            Dim obj As New dtoCierreOficina
            If Not validar() Then
                Me.Cursor = Cursors.Default
                Return
            End If

            If Not blnEditar Then
                intID = 0
                intOpcion = 1
            Else
                intID = Me.dgvLista.CurrentRow.Cells("id").Value
                intOpcion = 2
            End If

            If obj.GrabacionGastosLiquidacion(intID, 0, CboTipoMovimiento.SelectedValue, intOpcion, _
                                  TxtNroDocumento.Text.Trim, TxtCodigoPeaje.Text.Trim, _
                                  TxtNroOperacion.Text.Trim, Val(TxtMonto.Text.Trim), TxtNroBus.Text.Trim, _
                                  CboDestino.SelectedValue, CboPiloto.SelectedValue, TxtDepositante.Text.Trim, _
                                  TxtContacto.Text.Trim, TxtObservaciones.Text.Trim, _
                                  lblFecha.Text, Usuario, 0, 0, Agencia, 2) = True Then

                MessageBox.Show("Registrado Correctamente", "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.desactivar()
                Me.CboTipoMovimiento.Enabled = False
                Me.tabMovimientoCaja.SelectedIndex = 0
                Me.btnConsultar_Click(Nothing, Nothing)
                Me.btnConsultar.Focus()
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Me.tabMovimientoCaja.SelectedIndex = 1
        Nuevo()
    End Sub

    Sub Nuevo()
        Me.tsbNuevo.Enabled = False
        Me.tsbEditar.Enabled = False
        Me.tsbAnular.Enabled = False
        Me.tsbGrabar.Enabled = True
        blnEditar = False

        Me.Limpiar()
        CboTipoMovimiento.Enabled = True
        CboTipoMovimiento.SelectedValue = 0
        Me.CboTipoMovimiento.Focus()
    End Sub

    Sub Editar()
        Limpiar()
        If intNivel = 3 And Estado = "A" Then
            Me.tsbNuevo.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
            Me.tsbGrabar.Enabled = True
            CboTipoMovimiento.Enabled = False
            blnEditar = True
        End If
        Dim obj As New dtoCierreOficina
        Dim dt As DataTable = obj.ListarMovimiento(Me.dgvLista.CurrentRow.Cells("id").Value)
        If dt.Rows.Count > 0 Then
            Me.lblFecha.Text = dt.Rows(0).Item("fecha")
            Me.CboTipoMovimiento.SelectedValue = dt.Rows(0).Item("tipo")
            Me.TxtNroDocumento.Text = dt.Rows(0).Item("nro_documento").ToString.Trim
            Me.TxtNroOperacion.Text = dt.Rows(0).Item("cuenta_bancaria").ToString.Trim
            Me.TxtCodigoPeaje.Text = dt.Rows(0).Item("codigo_peaje").ToString.Trim
            Me.TxtMonto.Text = Format(dt.Rows(0).Item("monto"), "0.00")
            Me.CboDestino.SelectedValue = dt.Rows(0).Item("destino").ToString.Trim
            Me.TxtNroBus.Text = dt.Rows(0).Item("nro_bus").ToString.Trim
            Me.CboPiloto.SelectedValue = dt.Rows(0).Item("piloto").ToString.Trim
            Me.TxtDepositante.Text = dt.Rows(0).Item("depositante").ToString.Trim
            Me.TxtContacto.Text = dt.Rows(0).Item("contacto").ToString.Trim
            Me.TxtObservaciones.Text = dt.Rows(0).Item("observaciones").ToString.Trim
        End If
        Me.TxtMonto.Focus()
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Me.tabMovimientoCaja.SelectedIndex = 1
        Editar()
    End Sub

    Private Sub tabMovimientoCaja_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabMovimientoCaja.SelectedIndexChanged
        If intNivel <> 3 Or Estado = "C" Then Return
        If Me.tabMovimientoCaja.SelectedTab Is tabMovimientoCaja.TabPages("tabLista") Then
            Me.tsbNuevo.Enabled = True
            If Me.dgvLista.Rows.Count > 0 Then
                Me.tsbEditar.Enabled = True
                Me.tsbAnular.Enabled = True
            Else
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            End If
            Me.tsbGrabar.Enabled = False
        Else
            Nuevo()
        End If
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Try
            Cursor = Cursors.AppStarting
            Dim obj As New dtoCierreOficina
            Me.dgvLista.DataSource = obj.ListarMovimiento(Me.dtpInicio.Value.ToShortDateString, Me.dtpFin.Value.ToShortDateString, Agencia, Usuario)

            If intNivel = 3 And Estado = "A" Then
                If Me.dgvLista.Rows.Count > 0 Then
                    Me.tsbEditar.Enabled = True
                    Me.tsbAnular.Enabled = True
                Else
                    Me.tsbEditar.Enabled = False
                    Me.tsbAnular.Enabled = False
                End If
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvLista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLista.DoubleClick
        If Me.dgvLista.Rows.Count > 0 Then
            Me.tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Sub AnularMovimiento()
        Try
            Cursor = Cursors.AppStarting
            Dim obj As New dtoCierreOficina
            obj.AnularMovimiento(Me.dgvLista.CurrentRow.Cells("id").Value)
            Me.btnConsultar_Click(Nothing, Nothing)
            Me.btnConsultar.Focus()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Movimiento de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub tsbAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAnular.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está seguro de anular el movimiento?", "Movimiento de Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            AnularMovimiento()
        End If
    End Sub
End Class