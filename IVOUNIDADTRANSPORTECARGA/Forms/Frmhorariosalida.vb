'Imports System.Data
'Imports System.Data.OleDb
Public Class Frmhorariosalida
#Region "Variables"
    'Dim odbahorariosalida As New OleDb.OleDbDataAdapter
    'Dim rstunidad_agencia, rsthorariosalida, rstrutas As New ADODB.Recordset
    Dim dtunidad_agencia, dthorariosalida, dtrutas As New DataTable
    Dim dvunidad_agencia, dvhorariosalida, dvrutas As New DataView
    '
    Dim myclase As New dtoHorarioSalida
    Dim icontrol As Integer
    '
    Dim bIngreso As Boolean
    Public hnd As Long
#End Region

#Region "Propiedades"

#End Region

#Region "Eventos"
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub Frmhorariosalida_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub Frmhorariosalida_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub Frmhorariosalida_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Llenando los objetos  
        Try
            Me.ShadowLabel1.Text = "Horario de Salidas"
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False
            ' 
            MenuTab.Items(0).Text = "Lista Horario"
            MenuTab.Items(1).Text = "Mantenimiento"
            '
            MenuTab.Items(1).Enabled = False
            MenuTab.Items(1).Visible = False
            MenuTab.Items(2).Enabled = False
            MenuTab.Items(2).Visible = False
            MenuTab.Items(3).Enabled = False
            MenuTab.Items(3).Visible = False
            MenuTab.Items(4).Enabled = False
            MenuTab.Items(4).Visible = False
            MenuTab.Items(5).Enabled = False
            MenuTab.Items(5).Visible = False
            ' Recuperando los botones 
            NuevoToolStripMenuItem.Enabled = True
            NuevoToolStripMenuItem.Visible = True
            EdicionToolStripMenuItem.Enabled = True
            EdicionToolStripMenuItem.Visible = True
            '
            SalirToolStripMenuItem.Enabled = True
            SalirToolStripMenuItem.Visible = True
            '
            ' Cargando los combos, que corresponden, para seleccionar el funcionario  
            'rstunidad_agencia = myclase.fn_getcmb_horariosalidas
            Dim lds_tmp As New DataSet
            lds_tmp = myclase.fn_getcmb_horariosalidas

            'Recuperando los otros record set
            'rsthorariosalida = rstunidad_agencia.NextRecordset
            'rstrutas = rstunidad_agencia.NextRecordset
            'odbahorariosalida.Fill(dtunidad_agencia, rstunidad_agencia)
            'odbahorariosalida.Fill(dthorariosalida, rsthorariosalida)
            'odbahorariosalida.Fill(dtrutas, rstrutas)
            '

            dtunidad_agencia = lds_tmp.Tables(0)
            dthorariosalida = lds_tmp.Tables(1)
            dtrutas = lds_tmp.Tables(2)
            ' Llenando trevieew 
            Funciones.LlenarTreeView(dtunidad_agencia, 1, Me.MyTreeView, "Unidades Agencia")
            Me.MyTreeView.CheckBoxes = False
            Me.MyTreeView.ExpandAll()
            '
            'ModuUtil.LlenarTreeCtrl(rstunidad_agencia, Me.MyTreeView, "Unidades Agencia") Verificar. 
            '
            dvhorariosalida = dthorariosalida.DefaultView

            ' Cargando combo 
            dvrutas = CargarCombo(cmbruta, dtrutas, "nombre_ruta", "idrutas", 9999)
            ' Debe cargar toda la grilla. 
            grillaformato()

            bIngreso = False
            Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)
            bIngreso = True


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub Frmhorariosalida_MenuCancelar() Handles Me.MenuCancelar
        limpiardatos()
        Me.SelectMenu(0)
        MenuTab.Items(1).Enabled = False
        SplitContainer2.Panel1Collapsed = False
        GrabarToolStripMenuItem.Visible = False
        GrabarToolStripMenuItem.Enabled = False
        CancelarToolStripmenuItem.Visible = False
        CancelarToolStripmenuItem.Enabled = False
    End Sub
    Private Sub Frmhorariosalida_MenuEditar() Handles Me.MenuEditar
        Dim dgvr As DataGridViewRow = Me.Dgvrutahorario.CurrentRow()
        ' ---
        Me.SelectMenu(1)
        MenuTab.Items(1).Enabled = True
        SplitContainer2.Panel1Collapsed = True
        GrabarToolStripMenuItem.Visible = True
        GrabarToolStripMenuItem.Enabled = True
        CancelarToolStripmenuItem.Visible = True
        CancelarToolStripmenuItem.Enabled = True
        ' Cuando se cree, siempre va a estar en vigencia 
        chkvigente.Checked = True
        'Control 
        icontrol = 0 ' Es actualizacion 
        'Recuperando los valores 
        Dim dgrvrutahorario As DataGridViewRow
        Dim filarow As Integer
        '
        Try
            filarow = Dgvrutahorario.CurrentRow.Index
            If filarow < 0 Then
                Exit Sub
            End If
            dgrvrutahorario = Dgvrutahorario.CurrentRow
            Me.txtidrutahorario.Text = CType(dgrvrutahorario.Cells("idruta_horario").Value, String)
            cmbruta.SelectedValue = CType(dgrvrutahorario.Cells("idrutas").Value, Long)
            txthorasalida.Text = CType(dgrvrutahorario.Cells("hora").Value, String)
            If CType(dgrvrutahorario.Cells("estado").Value, Integer) = 1 Then
                chkvigente.Checked = True
            Else
                chkvigente.Checked = False
            End If
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub Frmhorariosalida_MenuGrabar() Handles Me.MenuGrabar
        ' Grabando 
        Dim rstactualiza As New ADODB.Recordset
        Dim smensaje As String
        Dim icodigo As Integer

        If CType(cmbruta.SelectedValue, Integer) = 9999 Then
            MessageBox.Show("No ha seleccionado ninguna ruta.", "Horario Salida", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbruta.Focus()
            Exit Sub
        End If
        Dim MyObligatorios() As Object = {Me.txthorasalida}
        Try
            ' 
            If Funciones.Validaciones(MyObligatorios) = 0 Then 'Si todo esta bien...
                If asignar_hora() = False Then
                    Exit Sub
                End If
                myclase.control = icontrol
                If icontrol = 1 Then
                    myclase.idruta_horario = -666  ' Es nulo p'q' recien esta ingresando 
                Else
                    myclase.idruta_horario = CType(txtidrutahorario.Text, Integer)
                End If
                myclase.idrutas = CType(cmbruta.SelectedValue, Integer)
                myclase.hora = txthorasalida.Text
                If chkvigente.Checked = True Then
                    myclase.estado = 1
                End If

                If chkvigente.Checked = False Then
                    myclase.estado = 2  ' Estado 4 -> Inactivo 
                End If
                myclase.ip = dtoUSUARIOS.IP
                myclase.idusuario_personal = dtoUSUARIOS.IdLogin
                myclase.iidrol_usuario = dtoUSUARIOS.IdRol
                'Mod.09/10/2009 -->Omendoza - Pasando al datahelper -  
                'rstactualiza = myclase.fn_actualiza_rutahorario()
                'icodigo = CType(rstactualiza.Fields(0).Value, Integer)
                'smensaje = CType(rstactualiza.Fields(1).Value, String)
                Dim ldt_tmp As New DataTable
                ldt_tmp = myclase.fn_actualiza_rutahorario()
                icodigo = CType(ldt_tmp.Rows(0).Item(0), Integer)
                smensaje = CType(ldt_tmp.Rows(0).Item(1), String)
                '
                MessageBox.Show(smensaje, "Horario Salida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '
                If icodigo <> 0 Then
                    Exit Sub
                Else
                    'Grabando correctamente 
                    Me.SelectMenu(0)
                    MenuTab.Items(1).Enabled = False
                    SplitContainer2.Panel1Collapsed = False
                    GrabarToolStripMenuItem.Visible = False
                    GrabarToolStripMenuItem.Enabled = False
                    CancelarToolStripmenuItem.Visible = False
                    CancelarToolStripmenuItem.Enabled = False
                    ' Debe recuperar el nuevo ingreso  
                    'rsthorariosalida = Nothing
                    'rsthorariosalida = myclase.fn_refresca_rutahorario()
                    'odbahorariosalida.Fill(dthorariosalida, rsthorariosalida)
                    'Mod.09/10/2009 -->Omendoza - Pasando al datahelper -  
                    dthorariosalida = Nothing
                    dthorariosalida = New DataTable
                    '
                    dthorariosalida = myclase.fn_refresca_rutahorario()
                    '
                    dvhorariosalida = Nothing
                    dvhorariosalida = New DataView
                    dvhorariosalida = dthorariosalida.DefaultView
                    Dgvrutahorario.Columns.Clear()
                    '
                    ' Refresca la grilla 
                    '
                    grillaformato()
                    ' 
                    dvrutas.RowFilter = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub Frmhorariosalida_MenuNuevo() Handles Me.MenuNuevo
        Try
            '    dvTipoDireccion.RowFilter = "TIPO_DIRECCION='LEGAL'" 'Para Obligar al Usuario a Ingresar por lo menos una direccion Legal.
            '    btnTipoDireccion.Enabled = False
            '    Me.chkDireccionFacturacion.Checked = True
            '    Me.chkDireccionFacturacion.Enabled = False
            '    Me.txtNumDoctoContacto.ReadOnly = False
            '    Me.txtNumDoctoContacto.BackColor = Color.White

            Me.SelectMenu(1)
            MenuTab.Items(1).Enabled = True
            SplitContainer2.Panel1Collapsed = True
            GrabarToolStripMenuItem.Visible = True
            GrabarToolStripMenuItem.Enabled = True
            CancelarToolStripmenuItem.Visible = True
            CancelarToolStripmenuItem.Enabled = True
            dvrutas.RowFilter = "idestado_registro = 1 "
            ' Cuando se cree, siempre va a estar en vigencia 
            chkvigente.Checked = True
            'Control 
            icontrol = 1 ' Cuando es nuevo 
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub Frmhorariosalida_MenuSalir() Handles Me.MenuSalir
        Me.Close()
    End Sub
    Private Sub txthorasalida_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txthorasalida.Validating
        'Dim shora As String
        'shora = CType(txthorasalida.Text, String)
        'shora = validar_hora_salida(shora)
        'If shora = "" Then
        '    txthorasalida.Text = shora
        '    txthorasalida.Focus()
        '    Exit Sub
        'End If
        'txthorasalida.Text = shora
        If asignar_hora() = False Then
            txthorasalida.Focus()
        End If
    End Sub
    Private Sub txthorasalida_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txthorasalida.Leave
        If asignar_hora() = False Then
            txthorasalida.Focus()
        End If        
    End Sub
    Private Sub cmbruta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbruta.SelectedIndexChanged
        Dim posicion As Integer
        Dim unidadagenciaorigen, unidadagenciadestino As String
        Dim drvruta As DataRowView
        Try
            posicion = cmbruta.SelectedIndex()
            If dvrutas.Count > 0 Then
                If posicion >= 0 Then
                    If IsDBNull(dvrutas.Item(posicion)) = True Then
                        Exit Sub
                    End If
                    drvruta = dvrutas.Item(posicion)
                    txtorigen.Text = ""
                    txtDestino.Text = ""
                    unidadagenciaorigen = IIf(IsDBNull(drvruta("origen")) = True, "", drvruta("origen").ToString)
                    unidadagenciadestino = IIf(IsDBNull(drvruta("destino")) = True, "", drvruta("destino").ToString)
                    txtorigen.Text = unidadagenciaorigen
                    txtDestino.Text = unidadagenciadestino
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub MyTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles MyTreeView.AfterSelect
        Dim iidunidad_agencia As Integer
        Dim filtro As String = ""
        iidunidad_agencia = e.Node().Tag
        If iidunidad_agencia <> "0" Then
            filtro = "idunidad_agencia = " & Trim(iidunidad_agencia)
        Else
            filtro = ""
        End If
        dvhorariosalida.RowFilter = filtro
    End Sub
#End Region
#Region "Funciones y procedimientos"
    Sub grillaformato()
        With Dgvrutahorario
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ReadOnly = True
            .DataSource = dvhorariosalida
        End With
        '
        ' Formato despues que funcione - Omendoza 
        '
        'Dim usuario As New DataGridViewTextBoxColumn
        'With usuario '0                
        '    .DataPropertyName = "usuario"
        '    .Name = "usuario"
        '    .HeaderText = "Usuario"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        'End With
        'DGVFuncionario_x_clte.Columns.Add(usuario)
        ''
        'Dim razonsocial As New DataGridViewTextBoxColumn
        'With razonsocial '1                
        '    .DataPropertyName = "razon_social"
        '    .Name = "razon_social"
        '    .HeaderText = "Razón Social"
        '    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '    '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        'End With
        'DGVFuncionario_x_clte.Columns.Add(razonsocial)
        ''
        'Dim Tipocliente As New DataGridViewTextBoxColumn
        'With Tipocliente '2                 
        '    .DataPropertyName = "cliente_corporativo"
        '    .Name = "cliente_corporativo"
        '    .HeaderText = "Tipo Cliente"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'End With
        'DGVFuncionario_x_clte.Columns.Add(Tipocliente)
        ''
        'Dim destino As New DataGridViewTextBoxColumn
        'With destino '3
        '    .DataPropertyName = "nu_docu_suna"
        '    .Name = "nu_docu_suna"
        '    .HeaderText = "RUC"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'End With
        'DGVFuncionario_x_clte.Columns.Add(destino)
        ''
        'Dim tipo_facturacion As New DataGridViewTextBoxColumn
        'With tipo_facturacion '4
        '    .DataPropertyName = "tipo_facturacion"
        '    .Name = "tipo_facturacion"
        '    .HeaderText = "Tipo Facturación"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'End With
        'DGVFuncionario_x_clte.Columns.Add(tipo_facturacion)
        ''
        'Dim nro_guia As New DataGridViewTextBoxColumn
        'With nro_guia   '5 
        '    .DataPropertyName = "linea_credito"
        '    .Name = "linea_credito"
        '    .HeaderText = "Línea Crédito"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'End With
        'DGVFuncionario_x_clte.Columns.Add(nro_guia)
        '' 
        'Dim condicionpago As New DataGridViewTextBoxColumn
        'With condicionpago '  6
        '    .DataPropertyName = "condicion"
        '    .Name = "condicion"
        '    .HeaderText = "Condición Pago"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        'End With
        'DGVFuncionario_x_clte.Columns.Add(condicionpago)
        '
    End Sub
    Sub limpiardatos()
        cmbruta.SelectedValue = 9999
        txtDestino.Text = ""
        txtorigen.Text = ""
        txthorasalida.Text = ""
    End Sub
    Function asignar_hora() As Boolean
        Dim shora As String
        shora = CType(txthorasalida.Text, String)
        shora = validar_hora_salida(shora)
        If shora = "" Then
            txthorasalida.Text = shora
            txthorasalida.Focus()
            Return False
        End If
        txthorasalida.Text = shora
        Return True
    End Function
#End Region

    Sub VerificaCambio(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, GrabarToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged, AyudaToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

End Class
