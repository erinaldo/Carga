Imports INTEGRACION_LN
Imports INTEGRACION_EN
Public Class frmEntregaSalidaBulto
    Dim intTipoAlmacen As Integer
#Region "Propiedad"
    Private strUsuario As String
    Public Property Usuario() As String
        Get
            Return strUsuario
        End Get
        Set(ByVal value As String)
            strUsuario = value
        End Set
    End Property

#End Region
#Region "Configurar Grid"
    Sub FormatearDGV()
        With dgv
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvLista)
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
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .HeaderText = "Código Barra" : .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_leido As New DataGridViewTextBoxColumn
            With col_leido
                .Name = "leido" : .DataPropertyName = "leido"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Leido"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_codigo, col_fecha, col_usuario, col_leido)
        End With
    End Sub
#End Region

    Private Sub frmEntregaSalidaBulto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FormatearDGV()
        Me.Text = "Salida Bulto de Almacén" & Space(15) & "Agencia : " & dtoUSUARIOS.m_iNombreAgencia & Space(15) & "Usuario : " & Usuario

        Dim objEN As New Cls_EntregaCarga_EN
        objEN.IP = dtoUSUARIOS.IP

        Dim obj As New Cls_EntregaCarga_LN
        intTipoAlmacen = obj.TipoAlmacen(objEN).Rows(0).Item(0)

        Me.lblTipoAlmacen.Text = IIf(intTipoAlmacen = 1, "ALMACEN", "RAMPA")

        Me.txtCodigo.Focus()
    End Sub

    Private Sub txtCodigo_GotFocus(sender As Object, e As System.EventArgs) Handles txtCodigo.GotFocus
        Me.txtCodigo.SelectAll()
    End Sub

    Private Sub txtCodigo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtCodigo.SelectionStart = 0
            Me.txtCodigo.SelectionLength = Me.txtCodigo.Text.Length
        End If
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        Try
            If e.KeyChar = Chr(Keys.Enter) Then
                If Val(Me.txtCodigo.Text) = 0 Then Return

                Cursor = Cursors.WaitCursor
                LeerBulto(Me.txtCodigo.Text.Trim)
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

    Sub LeerBulto(codigo As String)
        Dim obj As New Cls_EntregaCarga_LN
        Dim ds As DataSet = obj.LeerBulto(codigo, dtoUSUARIOS.iIDAGENCIAS, intTipoAlmacen, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)

        Dim dtDocumento As DataTable = ds.Tables(0)
        Dim dtBultos As DataTable = ds.Tables(1)
        If dtDocumento.Rows.Count > 0 Then
            If dtDocumento.Rows(0).Item("codigo") >= 0 Then
                Me.lblFechaDocumento.Text = dtDocumento.Rows(0).Item("fecha")
                Me.lblTipoDocumento.Text = dtDocumento.Rows(0).Item("tipo")
                Me.lblNumeroDocumento.Text = dtDocumento.Rows(0).Item("comprobante")
                Me.lblCantidad.Text = dtDocumento.Rows(0).Item("cantidad")
                Me.lblPeso.Text = dtDocumento.Rows(0).Item("peso")
                Me.lblConsignado.Text = dtDocumento.Rows(0).Item("consignado")
                Me.lblEstado.Text = dtDocumento.Rows(0).Item("estado")
                Me.dgv.DataSource = dtBultos

                If dtDocumento.Rows(0).Item("codigo") = 1 Then
                    MessageBox.Show("El Bulto con Código " & codigo & " ya fue Leído", "Salida Bulto de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf dtDocumento.Rows(0).Item("codigo") = 2 Then
                    MessageBox.Show("El Bulto con Código " & codigo & " debe estar EN ATENCION", "Salida Bulto de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf dtDocumento.Rows(0).Item("codigo") = 3 Then
                    MessageBox.Show("El Bulto con Código " & codigo & " no está en Almacén", "Salida Bulto de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("El Bulto con Código " & codigo & " no está Disponible", "Salida Bulto de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtCodigo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCodigo.TextChanged
        'If Me.chkTeclado.Checked Then Return
        'Try
        '    Dim longitud As Integer = txtCodigo.Text.Trim.Length
        '    If longitud >= 13 Then
        '        Cursor = Cursors.WaitCursor
        '        LeerBulto(Me.txtCodigo.Text.Trim)
        '        Cursor = Cursors.Default
        '    End If
        'Catch ex As Exception
        '    Cursor = Cursors.Default
        '    MessageBox.Show(ex.Message, "Salida Bulto de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

    End Sub

    Private Sub lblEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEstado.Click

    End Sub
End Class