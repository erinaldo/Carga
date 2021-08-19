Imports INTEGRACION_LN
Public Class frmBolsa
    Dim intUsuario As Integer, strUsuario As String, strLogin As String, strRol As String, intUnidad As Integer, intRol As Integer
    Dim intNivel As Integer

    Sub Formateardgv(Optional ByVal nivel As Integer = 1)
        With dgv
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
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha/Hora"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_agencia As New DataGridViewTextBoxColumn
            With col_agencia
                .Name = "agencia" : .DataPropertyName = "agencia"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_unidad As New DataGridViewTextBoxColumn
            With col_unidad
                .Name = "unidad" : .DataPropertyName = "unidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Unidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_moneda As New DataGridViewTextBoxColumn
            With col_moneda
                .Name = "moneda" : .DataPropertyName = "moneda"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Moneda"
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
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .Visible = nivel = 2 : .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id, col_fecha, col_codigo, col_agencia, col_unidad, col_moneda, col_monto, col_estado, col_usuario)
        End With
    End Sub
    Private Sub txtCodigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.GotFocus
        Me.txtCodigo.SelectAll()
    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtCodigo.SelectionStart = 0
            Me.txtCodigo.SelectionLength = Me.txtCodigo.Text.Length
        End If
    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        Try
            If e.KeyChar = Chr(Keys.Enter) Then
                If Val(Me.txtCodigo.Text) = 0 Then Return

                Dim frmUsuarioConfirmar As New frmUsuarioValor

                frmUsuarioConfirmar.lblAgencia.Text = dtoUSUARIOS.m_iNombreAgencia
                frmUsuarioConfirmar.txtUsuario.Text = strLogin
                frmUsuarioConfirmar.intLLamada = 1
                frmUsuarioConfirmar.txtContraseña.Focus()
                frmUsuarioConfirmar.ShowDialog()
                If frmUsuarioConfirmar.Resultado = 0 Then
                    Return
                End If
                intUsuario = frmUsuarioConfirmar.IDUsuario
                strLogin = frmUsuarioConfirmar.txtUsuario.Text.Trim
                strUsuario = frmUsuarioConfirmar.Usuario
                strRol = frmUsuarioConfirmar.cboRol.Text
                intRol = frmUsuarioConfirmar.cboRol.SelectedValue
                intUnidad = frmUsuarioConfirmar.Unidad

                Me.lblUsuario.Text = strUsuario
                Me.lblRol.Text = strRol
                Me.lblUnidad.Text = IIf(intUnidad = 1, "CARGA", "PASAJES")
                'Me.txtCodigo.Text = ""
                Me.txtCodigo.Focus()

                intNivel = ObtieneNivel(intRol)
                Formateardgv(intNivel)

                Cursor = Cursors.WaitCursor
                IngresarBolsa(Me.txtCodigo.Text.Trim)
                Cursor = Cursors.Default
            Else
                If Not ValidarNumero(e.KeyChar) Then
                    e.Handled = True
                End If
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Salida Bulto de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub IngresarBolsa(ByVal codigo As String)
        Dim obj As New Cls_LiquidacionValor_LN
        Dim ds As DataSet = obj.IngresarBolsa(codigo, Me.lblFecha.Text, dtoUSUARIOS.iIDAGENCIAS, _
                                              intUsuario, dtoUSUARIOS.IP, intRol, intNivel)

        Dim dtLista As DataTable = ds.Tables(0)
        Dim dtEstado As DataTable = ds.Tables(1)

        If dtEstado.Rows(0).Item("estado") <> 1 Then
            If dtEstado.Rows(0).Item("estado") = -1 Then
                MessageBox.Show("La Bolsa con Código " & codigo & " no existe", "Ingreso Bolsa a Cofre", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf dtEstado.Rows(0).Item("estado") = -2 Then
                MessageBox.Show("No está autorizado para ingresar la bolsa con código " & codigo & " al cofre", "Ingreso Bolsa a Cofre", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("El Bolsa con Código " & codigo & " no está disponible ", "Ingreso Bolsa a Cofre", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        Me.dgv.DataSource = dtLista
        Me.txtCodigo.Text = ""
    End Sub

    Private Sub frmBolsa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        intUsuario = dtoUSUARIOS.IdLogin
        strUsuario = dtoUSUARIOS.NameLogin
        strLogin = dtoUSUARIOS.iLOGIN
        strRol = G_Rol_descripcion
        intRol = dtoUSUARIOS.IdRol
        intUnidad = dtoUSUARIOS.Unidad

        Me.lblFecha.Text = CDate(FechaServidor()).ToShortDateString
        Me.lblAgencia.Text = dtoUSUARIOS.m_iNombreAgencia
        Me.lblUnidad.Text = IIf(dtoUSUARIOS.Unidad = 1, "CARGA", "PASAJES")
        Me.lblUsuario.Text = strUsuario
        Me.lblRol.Text = strRol

        intNivel = ObtieneNivel(intRol)

        Formateardgv(intNivel)
    End Sub

    Function ObtieneNivel(ByVal rol) As Integer
        If Acceso.SiRol(rol, Me, 1, 1) Then
            Return 1
        ElseIf Acceso.SiRol(rol, Me, 1, 2) Then
            Return 2
        ElseIf Acceso.SiRol(rol, Me, 1, 3) Then
            Return 3
        Else
            Return 0
        End If
    End Function

    Private Sub tsbCambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCambiar.Click
        Dim frmUsuarioConfirmar As New frmUsuarioValor

        frmUsuarioConfirmar.lblAgencia.Text = dtoUSUARIOS.m_iNombreAgencia
        frmUsuarioConfirmar.txtUsuario.Text = strLogin
        frmUsuarioConfirmar.intLLamada = 1
        frmUsuarioConfirmar.txtContraseña.Focus()
        frmUsuarioConfirmar.ShowDialog()
        If frmUsuarioConfirmar.Resultado = 0 Then
            Return
        End If
        intUsuario = frmUsuarioConfirmar.IDUsuario
        strLogin = frmUsuarioConfirmar.txtUsuario.Text.Trim
        strUsuario = frmUsuarioConfirmar.Usuario
        strRol = frmUsuarioConfirmar.cboRol.Text
        intRol = frmUsuarioConfirmar.cboRol.SelectedValue
        intUnidad = frmUsuarioConfirmar.Unidad

        Me.lblUsuario.Text = strUsuario
        Me.lblRol.Text = strRol
        Me.lblUnidad.Text = IIf(intUnidad = 1, "CARGA", "PASAJES")
        Me.txtCodigo.Text = ""
        Me.txtCodigo.Focus()

        intNivel = ObtieneNivel(intRol)
        Formateardgv(intNivel)
    End Sub

    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
        'Me.dgv.DataSource = Nothing
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub
End Class