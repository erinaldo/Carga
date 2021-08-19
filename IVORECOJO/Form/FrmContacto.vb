Public Class FrmContacto
#Region "variables"
    Public dtDocContacto As DataTable
    Public dtTipoComunicacion As DataTable
    Public DocContacto As Integer
    Public tipoComunicacion As Integer
    Public IdCliente

    Public intContacto As Integer
    Public nrodocumento As String
    Public nrodoc As String
    Public bNuevo As Boolean
    Dim bSalir As Boolean = True
    Dim lista(7) As String
#End Region

#Region "Formato"
    'formato para el grid de la Tabla Contacto
    Sub FormatoContacto()
        With Me.DtgContacto
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.ScrollBars = ScrollBars.Both
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black
            .ReadOnly = True 'readonly cuando este false se puede editar
            '.Focus()

            Dim idcontacto As New DataGridViewTextBoxColumn
            With idcontacto
                .HeaderText = "idcontacto"
                .Name = "idcontacto"
                .DataPropertyName = "idcontacto"
                .Visible = False
            End With

            Dim idtipo_documento_contacto As New DataGridViewTextBoxColumn
            With idtipo_documento_contacto
                .HeaderText = "idtipo_documento_contacto"
                .Name = "idtipo_documento_contacto"
                .DataPropertyName = "idtipo_documento_contacto"
                .Visible = False
            End With

            Dim tipo_doc_identidad As New DataGridViewTextBoxColumn
            With tipo_doc_identidad
                .HeaderText = "Tipo Documento"
                .Name = "tipo_doc_identidad"
                .DataPropertyName = "tipo_doc_identidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            Dim NroDocumento As New DataGridViewTextBoxColumn
            With NroDocumento
                .HeaderText = "N∫ Documento"
                .Name = "nrodocumento"
                .DataPropertyName = "nrodocumento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            Dim Contacto As New DataGridViewTextBoxColumn
            With Contacto
                .HeaderText = "Contacto"
                .Name = "nombres"
                .DataPropertyName = "nombres"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            Dim Email As New DataGridViewTextBoxColumn
            With Email
                .HeaderText = "Email"
                .Name = "email"
                .DataPropertyName = "email"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 130
                .Visible = False
            End With
            'agregar columna al grid
            Dim Fijo As New DataGridViewTextBoxColumn
            With Fijo
                .HeaderText = "Fijo"
                .Name = "fijo"
                .DataPropertyName = "fijo"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Visible = False
                '.Width = 100
            End With
            ' fin de agregado  
            'agregar columna al grid
            Dim Movil As New DataGridViewTextBoxColumn
            With Movil
                .HeaderText = "Movil"
                .Name = "movil"
                .DataPropertyName = "movil"
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .Visible = False
            End With
            ' fin de agregado  
            .Columns.AddRange(idcontacto, idtipo_documento_contacto, tipo_doc_identidad, NroDocumento, Contacto, Email, Fijo, Movil)
        End With
    End Sub
#End Region

#Region "Validaciones"
    Public Function Valida(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[0-9\b]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            Valida = True
        Else
            Valida = False
        End If
    End Function
    'valida email
    Public Function Validaremail(ByRef txtemail As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$")
        If re.IsMatch(txtemail.ToString()) Then
            Validaremail = True
        Else
            Validaremail = False
        End If
    End Function
    Public Function ValidarNumero(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[A-ZÒ—a-z0-9\b]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            ValidarNumero = True
        Else
            ValidarNumero = False
        End If
    End Function
#End Region
    Private Sub rdbdoc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbdoc.CheckedChanged
        If rdbdoc.Checked = True Then
            txtcontacto.Text = ""
            Me.txtcontacto.Focus()
        End If
    End Sub
    Public numero As String
    Public cliente As String
    Public nroCliente As String
    Private Sub ChkCliente_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkCliente.CheckStateChanged
        Dim frmsolicitud As New FrmSolicitudRecojo
        If ChkCliente.Checked = True Then
            Me.CboDocContacto.SelectedValue = nroCliente
            Me.txtnrodocumento.Text = numero
            Me.txtnomc.Text = cliente
            'desactivamos los textbox
            Me.CboDocContacto.Enabled = False
            txtnrodocumento.Enabled = False
            txtnomc.Enabled = False
            Me.txtemail.Focus()
        Else
            Me.CboDocContacto.Enabled = True
            Me.CboDocContacto.SelectedValue = 3
            txtnrodocumento.Enabled = True
            txtnomc.Enabled = True
            txtnrodocumento.Text = ""
            txtnomc.Text = ""
            txtnrodocumento.Focus()
        End If
    End Sub

    Private Sub txtnrodocumento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnrodocumento.GotFocus
        Me.txtnrodocumento.SelectAll()
    End Sub
    Private Sub txtnrodocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnrodocumento.KeyPress
        If Not Me.Valida(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtfijo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfijo.GotFocus
        Me.txtfijo.SelectAll()
    End Sub
    Private Sub txtfijo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfijo.KeyPress
        If Not Me.Valida(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub FrmDatosCliente_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.txtnrodocumento.Focus()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub FrmDatosCliente_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not bSalir Then
            bSalir = True
            e.Cancel = True
        End If
    End Sub
    Private Sub FrmDatosCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtmovil_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmovil.GotFocus
        Me.txtmovil.SelectAll()
    End Sub
    Private Sub txtmovil_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmovil.KeyPress
        If Not Me.Valida(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Sub Listacontactos()
        Try
            Dim varcontacto As Object
            Dim obj As New dtgrabarecojo
            Dim dt As New DataTable
            dt = obj.listar_grabar.Tables(0)
            varcontacto = dt.DefaultView
            obj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        bSalir = True
    End Sub
    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        'If Me.TabDatos.SelectedIndex = 1 Then
        If Me.TabDatos.SelectedIndex = 0 Then
            Me.DtgContacto_CellDoubleClick(Nothing, Nothing)
        End If

        If Me.CboDocContacto.SelectedValue = 1 Then
            If Not fnValidarRUC(Me.txtnrodocumento.Text) Then
                MessageBox.Show("El RUC no es V·lido.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                Me.txtnrodocumento.Focus()
                Return
            End If
        ElseIf Me.CboDocContacto.SelectedValue = 3 Then
            If Me.txtnrodocumento.Text.Length <> 8 Then
                MessageBox.Show("El DNI no es V·lido.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                Me.txtnrodocumento.Focus()
                Return
            End If
        ElseIf Me.CboDocContacto.SelectedValue <> 9 Then
            If Me.txtnrodocumento.Text.Length < 6 Then
                MessageBox.Show("El N∫ de Documento no es V·lido.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                Me.txtnrodocumento.Focus()
                Return
            End If
        End If

        If Me.txtnomc.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Nombres del Contacto.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bSalir = False
            Me.txtnomc.Text = ""
            Me.txtnomc.Focus()
            Return
        End If

        If Me.txtemail.Text.Trim.Length > 0 Then
            If Not Me.Validaremail(Me.txtemail.Text) Then
                MessageBox.Show("Ingrese Email V·lido.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                Me.txtemail.Focus()
                Return
            End If
        End If

        If Me.txtfijo.Text.Trim.Length = 0 And Me.txtmovil.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese un N∫ de TelÈfono Fijo o Movil", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bSalir = False
            Me.txtfijo.Focus()
            Return
        End If

        If Me.txtfijo.Text.Trim.Length > 0 Then
            If Me.txtfijo.Text.Trim.Length < 6 Then
                MessageBox.Show("Ingrese N∫ TelÈfono Fijo V·lido.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                Me.txtfijo.Focus()
                Return
            End If
        End If

        If Me.CboMovil.SelectedValue > 0 Then
            If Me.txtmovil.Text.Trim.Length < 9 Then
                MessageBox.Show("Ingrese N∫ TelÈfono MÛvil V·lido.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                Me.txtmovil.Focus()
                Return
            End If
            If Val(Me.txtmovil.Text.Trim.Substring(0, 1)) < 2 Then
                MessageBox.Show("Ingrese N∫ TelÈfono MÛvil V·lido.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                Me.txtmovil.Focus()
                Return
            End If
        Else
            If Me.txtmovil.Text.Trim.Length > 0 Then
                MessageBox.Show("Seleccione Tipo de TelÈfono MÛvil", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bSalir = False
                Me.txtmovil.Focus()
                Return
            End If
        End If
        'End If

        'Verificar si hubo alg˙n cambio
        bNoCambioContacto = lista(1) = Me.CboDocContacto.SelectedValue And _
        lista(2) = txtnrodocumento.Text.Trim And _
        lista(3) = Me.txtnomc.Text.Trim And lista(4) = Me.txtemail.Text.Trim

        bNoCambioFijo = lista(5) = Me.txtfijo.Text

        bNoCambioMovil = lista(6) = Me.CboMovil.SelectedValue And _
        lista(7) = Me.txtmovil.Text.Trim

        bSalir = True
    End Sub
    Private Sub txtcontacto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcontacto.TextChanged
        'Me.BtnBuscarCont.Enabled = Me.txtcontacto.Text.Trim.Length > 0

        'Dim obj As New dtrecojo
        'If rdbnom.Checked = True Then
        '    Try
        '        Dim contactnom As String = Me.txtcontacto.Text
        '        Dim ds As DataSet = obj.ListarContactonom(contactnom)
        '        Dim razon As String = ds.Tables(0).Rows.Count
        '        If razon = 0 Then
        '            MessageBox.Show("No existe el Cliente.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Else
        '            Me.DtgContacto.DataSource = ds.Tables(0)
        '            obj = Nothing
        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'ElseIf rdbdoc.Checked = True Then
        '    txtcontacto.Text = ""
        '    Try
        '        Dim contactdoc As String = Me.txtcontacto.Text
        '        Dim ds As DataSet = obj.ListarContactodoc(contactdoc)
        '        Dim razon As String = ds.Tables(0).Rows.Count
        '        If razon = 0 Then
        '            MessageBox.Show("No existe el Cliente.", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Else
        '            Me.DtgContacto.DataSource = ds.Tables(0)
        '            obj = Nothing
        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End If
    End Sub
    Private Sub BtnBuscarCont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarCont.Click
        Try
            Me.Cursor = Cursors.AppStarting
            Dim obj As New dtrecojo
            Dim nro As String
            nro = nrodoc
            If txtcontacto.Text = "" Then
                'Dim ds As DataSet = obj.Listar_aGrabar(nro, dtoUSUARIOS.m_idciudad)
                'Dim ds As DataSet = obj.ListarContactonom("", IdCliente, "")
                Dim dt As DataTable = obj.ListarContactos("", IdCliente, IIf(Me.rdbnom.Checked, 1, 2))
                Me.DtgContacto.DataSource = dt
                obj = Nothing
            Else
                If rdbnom.Checked = True Then
                    Try
                        Dim contactnom As String = Me.txtcontacto.Text
                        'Dim ds As DataSet = obj.ListarContactonom(contactnom, IdCliente, "")
                        Dim dt As DataTable = obj.ListarContactos(contactnom, IdCliente, 1)
                        Me.DtgContacto.DataSource = dt
                        obj = Nothing
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                ElseIf rdbdoc.Checked = True Then
                    'txtcontacto.Text = ""
                    Try
                        Dim contactdoc As String = Me.txtcontacto.Text
                        'Dim ds As DataSet = obj.ListarContactodoc(contactdoc)
                        'Dim ds As DataSet = obj.ListarContactonom("", 0, contactdoc)
                        Dim dt As DataTable = obj.ListarContactos(contactdoc, 0, 2)
                        Me.DtgContacto.DataSource = dt
                        obj = Nothing
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtnomc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnomc.GotFocus
        Me.txtnomc.Focus()
    End Sub

    Private Sub CboMovil_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMovil.SelectedIndexChanged
        If Not IsReference(Me.CboMovil.SelectedValue) Then
            If Me.CboMovil.SelectedValue = 0 Then
                Me.txtmovil.Text = ""
                Me.txtmovil.Enabled = False
            Else
                Me.txtmovil.Enabled = True
            End If
        End If
    End Sub

    Private Sub FrmDatosCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FormatoContacto()
            Dim obj As New dtrecojo
            Dim ds As New DataSet
            ds = obj.InicioContacto
            dtTipoComunicacion = ds.Tables(0)
            dtDocContacto = ds.Tables(1)

            CboMovil.DataSource = dtTipoComunicacion
            CboMovil.DisplayMember = "tipo_comunicacion"
            CboMovil.ValueMember = "id"
            Me.CboMovil.SelectedValue = tipoComunicacion

            CboDocContacto.DataSource = dtDocContacto
            CboDocContacto.DisplayMember = "tipo_doc_identidad"
            CboDocContacto.ValueMember = "idtipo_doc_identidad"
            Me.CboDocContacto.SelectedValue = DocContacto

            lista(1) = Me.CboDocContacto.SelectedValue
            lista(2) = txtnrodocumento.Text.Trim
            lista(3) = Me.txtnomc.Text.Trim
            lista(4) = Me.txtemail.Text.Trim
            lista(5) = Me.txtfijo.Text
            lista(6) = Me.CboMovil.SelectedValue
            lista(7) = Me.txtmovil.Text.Trim

            If bNuevo Then
                Me.TabDatos.SelectedIndex = 1
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TabDatos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabDatos.SelectedIndexChanged
        If TabDatos.SelectedIndex = 0 Then
            Me.btnNuevo.Visible = False
            Me.AcceptButton = Me.BtnBuscarCont
            Me.txtcontacto.Focus()
        Else
            Me.btnNuevo.Visible = True
            Me.AcceptButton = Nothing
        End If
    End Sub

    Private Sub DtgContacto_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DtgContacto.CellDoubleClick
        Me.CboDocContacto.SelectedValue = DtgContacto.Item("idtipo_documento_contacto", DtgContacto.CurrentRow.Index()).Value
        txtnrodocumento.Text = DtgContacto.Item("nrodocumento", DtgContacto.CurrentRow.Index()).Value.ToString()
        txtnomc.Text = DtgContacto.Item("nombres", DtgContacto.CurrentRow.Index()).Value.ToString()
        txtemail.Text = DtgContacto.Item("email", DtgContacto.CurrentRow.Index()).Value.ToString()
        txtfijo.Text = DtgContacto.Item("fijo", DtgContacto.CurrentRow.Index()).Value.ToString()
        txtmovil.Text = DtgContacto.Item("movil", DtgContacto.CurrentRow.Index()).Value.ToString()
        If IsNothing(DtgContacto.Item("idcontacto", DtgContacto.CurrentRow.Index()).Value) Then
            intContacto = 0
        Else
            intContacto = DtgContacto.Item("idcontacto", DtgContacto.CurrentRow.Index()).Value.ToString
        End If
        Me.TabDatos.SelectedIndex = 1
        Me.btnaceptar.Focus()
    End Sub

    Sub Limpiar()
        Me.CboDocContacto.SelectedValue = 3
        Me.txtnrodocumento.Text = ""
        Me.ChkCliente.Checked = False
        Me.txtnomc.Text = ""
        Me.txtemail.Text = ""
        Me.txtfijo.Text = ""
        Me.CboMovil.SelectedValue = 0
        Me.txtmovil.Text = ""
        intContacto = 0
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Me.Limpiar()
        Me.CboDocContacto.Focus()
        Me.txtnrodocumento.Focus()
        bSalir = False
    End Sub

    Private Sub ChkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCliente.CheckedChanged

    End Sub
End Class