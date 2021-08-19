Public Class FrmOpciones
    Dim ObjOpciones As New ClsLbTepsa.dtoOpciones
    Dim ObjValida As New ClsLbTepsa.dtoValida
    Dim DV_consul_montos_ca As DataView
    Dim DV_consul_montos_ca_PERSO As DataView
    Dim DV_ca_PERSO As DataView
    Dim bInicio As Boolean
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub FrmOpciones_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    End Sub

    Private Sub FrmOpciones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmOpciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            bInicio = True
            Me.MenuTab.Items(0).Text = "Monto Mínimo de PCE"
            Me.MenuTab.Items(0).Visible = False
            Me.MenuTab.Items(1).Text = "Rangos Tarifas Carga Asegurada"
            Me.MenuTab.Items(2).Text = "Rangos Tarifas Carga Asegurada Personalizada"
            '
            Me.ShadowLabel1.Text = "Opciones"
            '
            Me.MenuStrip1.Items(0).Visible = False 'nuevo
            Me.MenuStrip1.Items(1).Visible = False 'edicion 
            Me.MenuStrip1.Items(2).Visible = False 'cancelar
            Me.MenuStrip1.Items(3).Visible = True  'grabar
            Me.MenuStrip1.Items(3).Enabled = True  'grabar
            Me.MenuStrip1.Items(4).Visible = False 'eliminar
            Me.MenuStrip1.Items(5).Visible = False 'exportar
            Me.MenuStrip1.Items(6).Visible = False 'imprimir
            Me.MenuStrip1.Items(7).Visible = False 'ayuda
            Me.MenuStrip1.Items(8).Visible = True 'salir
            'Datahelper
            ObjOpciones.SP_RECUPERA_MONTO_MINIMO_PCE()
            Me.txtMONTO_MINIMO_PCE.Text = Format(ObjOpciones.MONTO_MINIMO_PCE, "######.00")

            DV_consul_montos_ca = New DataView
            'Datahelper
            DV_consul_montos_ca = ObjOpciones.sp_consul_montos_ca()
            txtMONTO_MINIMO.Text = Format(ObjOpciones.MONTO_MINIMO, "######.00")
            FORMAT_GRILLA3()

            'Actualiza Grid de Clientes con tarifa de carga asegurada
            DV_ca_PERSO = New DataView
            'Datahelper
            DV_ca_PERSO = ObjOpciones.SP_CLIENTE_TARIFA_ASEGURADA()
            FORMAT_GRILLA5()

            If TabMante.SelectedIndex = 0 Or TabMante.SelectedIndex = 1 Then
                TabMante.SelectedIndex = 1
            End If

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtMONTO_MINIMO_PCE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMONTO_MINIMO_PCE.KeyPress, txtMONTO_MINIMO.KeyPress, txtMONTO_MINIMO_PERSO.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar


            If chr.IsDigit(chr) Then
                e.Handled = False
            ElseIf chr.IsControl(chr) Then
                e.Handled = False
            ElseIf chr = "." And Not tb.Text.IndexOf(".") = -1 Then
                e.Handled = True
            ElseIf e.KeyChar = "." Then
                e.Handled = False
            Else
                e.Handled = True
            End If


        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try

    End Sub

    Private Sub txtMONTO_MINIMO_PCE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMONTO_MINIMO_PCE.TextChanged

    End Sub

    Private Function valida() As Boolean
        With ObjValida

            If .NO_BLANCO(Me.txtMONTO_MINIMO_PCE, Me) = False Then Return False
            'If .NUMERO_CERO(Me.txtMONTO_MINIMO_PCE) = False Then Return False
            If .NUMERO_NO_NEGATIVO(Me.txtMONTO_MINIMO_PCE, Me) = False Then Return False
            If Not DV_consul_montos_ca Is Nothing Then
                If Me.DV_consul_montos_ca.Table.Rows.Count > 0 Then

                    If .NUMERO_NO_CERO(Me.txtMONTO_MINIMO, Me) = False Then
                        TabMante.SelectedIndex = 1
                        Return False
                    End If



                End If
            End If
            If Not DV_consul_montos_ca_PERSO Is Nothing Then
                If Me.DV_consul_montos_ca_PERSO.Table.Rows.Count > 0 Then

                    'If .NUMERO_NO_CERO(Me.txtMONTO_MINIMO_PERSO, Me) = False Then
                    TabMante.SelectedIndex = 2
                    'Return False
                    'End If



                End If
            End If
            Return True
        End With
    End Function
    Private Sub FrmOpciones_MenuGrabar() Handles Me.MenuGrabar

        If valida() = False Then Exit Sub

        With ObjOpciones
            .MONTO_MINIMO_PCE = Me.txtMONTO_MINIMO_PCE.Text
            .IP = dtoUSUARIOS.IP
            .IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            .IDROL_USUARIO = dtoUSUARIOS.m_iIdRol
            ''Datahelper
            If .SP_UP_CONFIGURACION_TITAN() = True And guardar_rangos() = True And guardar_rangos_perso() = True Then
                MsgBox("Se guardó correctamente", MsgBoxStyle.Information, "Seguridad del sistema...")
            End If

        End With
    End Sub
    Private Function guardar_rangos() As Boolean
        Try
            'Datahelper
            ObjOpciones.SP_de_confi_carga_ase()
            For J As Integer = 0 To DV_consul_montos_ca.Table.Rows.Count - 1
                ObjOpciones.RANGO_MAXIMO = DV_consul_montos_ca.Table.Rows(J)("RANGO_MAXIMO")
                ObjOpciones.RANGO_MINIMO = DV_consul_montos_ca.Table.Rows(J)("RANGO_MINIMO")
                ObjOpciones.PORCEN = DV_consul_montos_ca.Table.Rows(J)("PORCEN")
                ObjOpciones.MONTO_MINIMO = Me.txtMONTO_MINIMO.Text
                'Datahelper
                ObjOpciones.SP_INUP_confi_carga_ase()
            Next

            Return True
        Catch
            Return False
        End Try
    End Function
    Private Function guardar_rangos_perso() As Boolean
        Try

            If Me.Txtrazon_social.Tag Is Nothing Then Return True

            If Me.Txtrazon_social.Tag.ToString = "" Then Return True

            ObjOpciones.IDPERSONA = Me.Txtrazon_social.Tag
            'Datahelper
            ObjOpciones.SP_de_confi_carga_ase_perso()
            For J As Integer = 0 To DV_consul_montos_ca_PERSO.Table.Rows.Count - 1

                ObjOpciones.RANGO_MAXIMO = DV_consul_montos_ca_PERSO.Table.Rows(J)("RANGO_MAXIMO")
                ObjOpciones.RANGO_MINIMO = DV_consul_montos_ca_PERSO.Table.Rows(J)("RANGO_MINIMO")
                ObjOpciones.PORCEN = DV_consul_montos_ca_PERSO.Table.Rows(J)("PORCEN")
                ObjOpciones.MONTO_MINIMO = Me.txtMONTO_MINIMO_PERSO.Text
                'Datahelper
                ObjOpciones.SP_INUP_confi_carga_ase_perso()
            Next
            'Actualiza Grid de Clientes con tarifa de carga asegurada
            DV_ca_PERSO = New DataView
            'Datahelper
            DV_ca_PERSO = ObjOpciones.SP_CLIENTE_TARIFA_ASEGURADA()
            FORMAT_GRILLA5()
            Return True
        Catch
            Return False
        End Try
    End Function
    Sub FORMAT_GRILLA3()
        DGV.Columns.Clear()
        With DGV
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = DV_consul_montos_ca
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With


        Dim RANGO_MINIMO As New DataGridViewTextBoxColumn
        With RANGO_MINIMO
            .HeaderText = "RANGO_MINIMO"
            .Name = "RANGO_MINIMO"
            .DataPropertyName = "RANGO_MINIMO"
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
        End With

        Dim RANGO_MAXIMO As New DataGridViewTextBoxColumn
        With RANGO_MAXIMO
            .HeaderText = "RANGO_MAXIMO"
            .Name = "RANGO_MAXIMO"
            .DataPropertyName = "RANGO_MAXIMO"
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
        End With

        Dim PORCEN As New DataGridViewTextBoxColumn
        With PORCEN
            .HeaderText = "PORCEN"
            .Name = "PORCEN"
            .DataPropertyName = "PORCEN"
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
            .DefaultCellStyle.Format = "0.00"
        End With


        With DGV
            .Columns.AddRange(RANGO_MINIMO, RANGO_MAXIMO, PORCEN)
        End With
    End Sub

    Private Sub txtMONTO_MINIMO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRANGO_MINIMO.KeyPress, TXTRANGO_MAXIMO.KeyPress, TXTRANGO_MINIMO_PERSO.KeyPress, TXTRANGO_MAXIMO_PERSO.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar


            If chr.IsDigit(chr) Then
                e.Handled = False
            ElseIf chr.IsControl(chr) Then
                e.Handled = False
                'ElseIf chr = "." And Not tb.Text.IndexOf(".") = -1 Then
                '    e.Handled = True
                'ElseIf e.KeyChar = "." Then
                '    e.Handled = False
            Else
                e.Handled = True
            End If


        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try

    End Sub

    Private Sub txtMONTO_MINIMO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BtnAge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAge.Click

        If validando_ingreso_rango() = False Then Exit Sub

        Dim rowView As DataRowView = DV_consul_montos_ca.AddNew

        rowView("RANGO_MINIMO") = TXTRANGO_MINIMO.Text
        rowView("RANGO_MAXIMO") = TXTRANGO_MAXIMO.Text
        rowView("PORCEN") = Val(TXTPORCEN.Text)


        rowView.EndEdit()


        TXTRANGO_MINIMO.Text = ""
        TXTRANGO_MAXIMO.Text = ""
        TXTPORCEN.Text = ""
        chkInfinito.Checked = False
        DGV.Refresh()

    End Sub

    Private Sub TXTPORCEN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPORCEN.KeyPress, TXTPORCEN_PERSO.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar


            If chr.IsDigit(chr) Then
                e.Handled = False
            ElseIf chr.IsControl(chr) Then
                e.Handled = False
            ElseIf chr = "." And Not tb.Text.IndexOf(".") = -1 Then
                e.Handled = True
            ElseIf e.KeyChar = "." Then
                e.Handled = False
            Else
                e.Handled = True
            End If


        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try

    End Sub
    Private Function validando_ingreso_rango() As Boolean
        If chkInfinito.Checked = False Then
            If Val(Me.TXTRANGO_MINIMO.Text) >= Val(Me.TXTRANGO_MAXIMO.Text) Then
                MsgBox("El rango minimo no puede ser mayor o igual que el maximo", MsgBoxStyle.Critical, "Seguridad del Sistema")
                Return False
            End If
        End If

        If Val(Me.TXTPORCEN.Text) < 0 Then
            MsgBox("El porcentaje no puede ser menor que cero", MsgBoxStyle.Critical, "Seguridad del Sistema")
            Return False
        End If

        If chkInfinito.Checked = True Then
            'ObjOpciones.SP_RECUPERA_MONTO_MINIMO_PCE(cnn)
            'Me.txtMONTO_MINIMO_PCE.Text = Format(ObjOpciones.MONTO_MINIMO_PCE, "######.00")
            'ObjOpciones.SP_BUSCA_INFINITO(cnn)
            ObjOpciones.SP_BUSCA_INFINITO(DGV)
            If ObjOpciones.ExisteInfinito Then
                MessageBox.Show("Ya ha definido un rango máximo como infinito.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
        End If

        If Not DV_consul_montos_ca.Table.Rows.Count = 0 Then
            If Val(Me.TXTRANGO_MINIMO.Text) <= 0 Then
                MsgBox("El rango minimo no puede ser menor o igual que cero", MsgBoxStyle.Critical, "Seguridad del Sistema")
                Return False
            End If
            If chkInfinito.Checked = False Then
                If Val(Me.TXTRANGO_MAXIMO.Text) <= 0 Then
                    MsgBox("El rango máximo no puede ser menor o igual que cero", MsgBoxStyle.Critical, "Seguridad del Sistema")
                    Return False
                End If
            End If

            If Val(Me.TXTRANGO_MINIMO.Text) <= Val(DV_consul_montos_ca.Table.Rows(DV_consul_montos_ca.Table.Rows.Count - 1)("RANGO_MAXIMO")) Then
                MsgBox("El rango minimo no puede ser menor o igual que el maximo del ultimo ingresado", MsgBoxStyle.Critical, "Seguridad del Sistema")
                Return False
            End If

            If Not (Val(Me.TXTRANGO_MINIMO.Text) - 1 = DV_consul_montos_ca.Table.Rows(DV_consul_montos_ca.Table.Rows.Count - 1)("RANGO_MAXIMO")) Then
                MsgBox("El siguiente rango tiene que ser correlativo del rango maximo anterior", MsgBoxStyle.Critical, "Seguridad del Sistema")
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub btnEli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEli.Click
        If DV_consul_montos_ca.Table.Rows.Count <= 0 Then Exit Sub

        Dim myDataRow As DataRow = DV_consul_montos_ca.Table.Rows.Item(DV_consul_montos_ca.Table.Rows.Count - 1)
        DV_consul_montos_ca.Table.Rows.Remove(myDataRow)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Try
            If msg.WParam.ToInt32 = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try

    End Function
    Private Sub BtnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarCliente.Click
        Dim a As New FrmBuscaClienca
        a.ShowDialog(Me)

        If Me.Txtrazon_social.Tag Is Nothing Then
            Me.Txtrazon_social.Tag = ""
        End If
        If Me.Txtrazon_social.Tag.ToString <> "" Then
            DGV4.DataSource = Nothing
            DV_consul_montos_ca_PERSO = New DataView
            ObjOpciones.IDPERSONA = Me.Txtrazon_social.Tag.ToString
            'Datahelper
            DV_consul_montos_ca_PERSO = ObjOpciones.sp_consul_montos_ca_perso()

            txtMONTO_MINIMO_PERSO.Text = Format(ObjOpciones.MONTO_MINIMO, "######.00")
            FORMAT_GRILLA4()
        Else
            DGV4.DataSource = Nothing
        End If
    End Sub
    Sub FORMAT_GRILLA4()
        DGV4.Columns.Clear()

        With DGV4
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = DV_consul_montos_ca_PERSO
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With


        Dim RANGO_MINIMO As New DataGridViewTextBoxColumn
        With RANGO_MINIMO
            .HeaderText = "RANGO_MINIMO"
            .Name = "RANGO_MINIMO"
            .DataPropertyName = "RANGO_MINIMO"
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
        End With

        Dim RANGO_MAXIMO As New DataGridViewTextBoxColumn
        With RANGO_MAXIMO
            .HeaderText = "RANGO_MAXIMO"
            .Name = "RANGO_MAXIMO"
            .DataPropertyName = "RANGO_MAXIMO"
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
        End With

        Dim PORCEN As New DataGridViewTextBoxColumn
        With PORCEN
            .HeaderText = "PORCEN"
            .Name = "PORCEN"
            .DataPropertyName = "PORCEN"
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
            .DefaultCellStyle.Format = "0.00"
        End With


        With DGV4
            .Columns.AddRange(RANGO_MINIMO, RANGO_MAXIMO, PORCEN)
        End With
    End Sub
    Private Sub btnEli_perso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEli_PERSO.Click
        If DV_consul_montos_ca_PERSO.Table.Rows.Count <= 0 Then Exit Sub

        Dim myDataRow As DataRow = DV_consul_montos_ca_PERSO.Table.Rows.Item(DV_consul_montos_ca_PERSO.Table.Rows.Count - 1)
        DV_consul_montos_ca_PERSO.Table.Rows.Remove(myDataRow)
    End Sub
    Private Function validando_ingreso_rango_perso() As Boolean
        If Txtrazon_social.Tag Is Nothing Then
            MessageBox.Show("Debe seleccionar un cliente.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnBuscarCliente.Focus()
            Return False
        End If

        If Txtrazon_social.Tag.ToString.Trim.Length = 0 Then
            MessageBox.Show("Debe seleccionar un cliente.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BtnBuscarCliente.Focus()
            Return False
        End If

        If chkInfinito2.Checked = False Then
            If Val(Me.TXTRANGO_MINIMO_PERSO.Text) >= Val(Me.TXTRANGO_MAXIMO_PERSO.Text) Then
                MsgBox("El rango minimo no puede ser mayor o igual que el maximo", MsgBoxStyle.Critical, "Seguridad del Sistema")
                Return False
            End If
        End If

        If chkInfinito2.Checked = True Then
            'ObjOpciones.SP_RECUPERA_MONTO_MINIMO_PCE(cnn)
            'Me.txtMONTO_MINIMO_PCE.Text = Format(ObjOpciones.MONTO_MINIMO_PCE, "######.00")
            ObjOpciones.SP_BUSCA_INFINITO_CLIENTE(DGV4)
            If ObjOpciones.ExisteInfinito Then
                MessageBox.Show("Ya ha definido un rango máximo como infinito.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
        End If

        If Val(Me.TXTPORCEN_PERSO.Text) < 0 Then
            MsgBox("El porcentaje no puede ser menor que cero", MsgBoxStyle.Critical, "Seguridad del Sistema")
            Return False
        End If

        If Not DV_consul_montos_ca_PERSO.Table.Rows.Count = 0 Then

            If Val(Me.TXTRANGO_MINIMO_PERSO.Text) <= 0 Then
                MsgBox("El rango minimo no puede ser menor o igual que cero", MsgBoxStyle.Critical, "Seguridad del Sistema")
                Return False
            End If
            If chkInfinito2.Checked = False Then
                If Val(Me.TXTRANGO_MAXIMO_PERSO.Text) <= 0 Then
                    MsgBox("El rango máximo no puede ser menor o igual que cero", MsgBoxStyle.Critical, "Seguridad del Sistema")
                    Return False
                End If
            End If

            If Val(Me.TXTRANGO_MINIMO_PERSO.Text) <= Val(DV_consul_montos_ca_PERSO.Table.Rows(DV_consul_montos_ca_PERSO.Table.Rows.Count - 1)("RANGO_MAXIMO")) Then
                MsgBox("El rango minimo no puede ser menor o igual que el maximo del ultimo ingresado", MsgBoxStyle.Critical, "Seguridad del Sistema")
                Return False
            End If

            If Not (Val(Me.TXTRANGO_MINIMO_PERSO.Text) - 1 = DV_consul_montos_ca_PERSO.Table.Rows(DV_consul_montos_ca_PERSO.Table.Rows.Count - 1)("RANGO_MAXIMO")) Then
                MsgBox("El siguiente rango tiene que ser correlativo del rango maximo anterior", MsgBoxStyle.Critical, "Seguridad del Sistema")
                Return False
            End If

        End If

        Return True

    End Function
    Private Sub BtnAge_perso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAge_PERSO.Click
        If validando_ingreso_rango_perso() = False Then Exit Sub
        Dim rowView As DataRowView = DV_consul_montos_ca_PERSO.AddNew

        If Val(TXTRANGO_MINIMO_PERSO.Text) = 0 Then TXTRANGO_MINIMO_PERSO.Text = "0"

        rowView("RANGO_MINIMO") = TXTRANGO_MINIMO_PERSO.Text
        rowView("RANGO_MAXIMO") = TXTRANGO_MAXIMO_PERSO.Text
        rowView("PORCEN") = Val(TXTPORCEN_PERSO.Text)
        rowView.EndEdit()

        TXTRANGO_MINIMO_PERSO.Text = ""
        TXTRANGO_MAXIMO_PERSO.Text = ""
        TXTPORCEN_PERSO.Text = ""
        chkInfinito2.Checked = False

        DGV.Refresh()
    End Sub

    Private Sub chkInfinito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInfinito.CheckedChanged
        If chkInfinito.Checked = True Then
            TXTRANGO_MAXIMO.Text = "0"
            TXTRANGO_MAXIMO.Enabled = False
        Else
            TXTRANGO_MAXIMO.Text = ""
            TXTRANGO_MAXIMO.Enabled = True
        End If
    End Sub

    Sub FORMAT_GRILLA5()
        dgvClienteTarifa.Columns.Clear()
        With dgvClienteTarifa
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = DV_ca_PERSO
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .HeaderText = "IDPERSONA"
            .Name = "IDPERSONA"
            .DataPropertyName = "IDPERSONA"
            .Width = 100
            .Visible = False
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            '.DefaultCellStyle.Format = "N0"
            '.DefaultCellStyle.NullValue = "0"
            '.ReadOnly = True
        End With

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .HeaderText = "CODIGO"
            .Name = "CODIGO_CLIENTE"
            .DataPropertyName = "CODIGO_CLIENTE"
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            '.DefaultCellStyle.Format = "N0"
            '.DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
        End With

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .HeaderText = "NOMBRES"
            .Name = "NOMBRES"
            .DataPropertyName = "NOMBRES"
            .Width = 300
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            '.DefaultCellStyle.Format = "N0"
            '.DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
        End With


        With dgvClienteTarifa
            .Columns.AddRange(col1, col2, col3)
        End With
    End Sub

    Private Sub dgvClienteTarifa_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClienteTarifa.CellClick
    End Sub

    Private Sub dgvClienteTarifa_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClienteTarifa.CellContentClick

    End Sub

    Private Sub Txtnu_docu_suna_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtnu_docu_suna.TextChanged

    End Sub

    Private Sub dgvClienteTarifa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvClienteTarifa.Click
        With dgvClienteTarifa
            'grdAsegurado.CurrentCell = grdAsegurado.Rows(indice).Cells(0)
            Txtrazon_social.Tag = dgvClienteTarifa(0, .CurrentCell.RowIndex).Value
            DV_consul_montos_ca_PERSO = New DataView
            ObjOpciones.IDPERSONA = Txtrazon_social.Tag
            'Datahelper
            DV_consul_montos_ca_PERSO = ObjOpciones.sp_consul_montos_ca_perso()
            Txtnu_docu_suna.Text = dgvClienteTarifa(1, .CurrentCell.RowIndex).Value
            Txtrazon_social.Text = dgvClienteTarifa(2, .CurrentCell.RowIndex).Value
            txtMONTO_MINIMO_PERSO.Text = Format(ObjOpciones.MONTO_MINIMO, "######.00")
            FORMAT_GRILLA4()
            bInicio = False
        End With
    End Sub

    Private Sub dgvClienteTarifa_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvClienteTarifa.DoubleClick
    End Sub

    Private Sub chkInfinito2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInfinito2.CheckedChanged
        If chkInfinito2.Checked = True Then
            TXTRANGO_MAXIMO_PERSO.Text = "0"
            TXTRANGO_MAXIMO_PERSO.Enabled = False
        Else
            TXTRANGO_MAXIMO_PERSO.Text = ""
            TXTRANGO_MAXIMO_PERSO.Enabled = True
        End If
    End Sub

    Private Sub dgvClienteTarifa_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClienteTarifa.RowEnter
        With dgvClienteTarifa
            Txtrazon_social.Tag = dgvClienteTarifa(0, e.RowIndex).Value
            DV_consul_montos_ca_PERSO = New DataView
            ObjOpciones.IDPERSONA = Txtrazon_social.Tag
            'Datahelper
            DV_consul_montos_ca_PERSO = ObjOpciones.sp_consul_montos_ca_perso()
            Txtnu_docu_suna.Text = dgvClienteTarifa(1, e.RowIndex).Value
            Txtrazon_social.Text = dgvClienteTarifa(2, e.RowIndex).Value
            txtMONTO_MINIMO_PERSO.Text = Format(ObjOpciones.MONTO_MINIMO, "######.00")
            FORMAT_GRILLA4()
            bInicio = False
        End With

        'If bInicio = False Then
        '    dgvClienteTarifa_Click(sender, e)
        '    bInicio = False
        'End If
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class
