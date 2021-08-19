Imports INTEGRACION_LN
Public Class frmConfirmarEntregas
    Public v_idSolicitud_Entrega As Integer
    Public v_idTipo_Comprobante As Long
    Public v_idComprobante As Long
    '
    Dim bIngreso As Boolean = False
    Public hnd As Long
    Public rows As DataGridViewSelectedRowCollection
    Dim dtConsignado As DataTable

    Private Sub frmConfirmarEntregas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frmConfirmarEntregas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            dtConsignado = ObjEntrega_Recojo.fnBUSCAR_DATOS_SOLICITUD_2(v_idSolicitud_Entrega)
            txtCliente.Text = ObjEntrega_Recojo.x_Cliente
            txtConsignado.Text = ObjEntrega_Recojo.x_Consignado
            txtNroDocumento.Text = ObjEntrega_Recojo.x_NroDoc
            txtOrigen.Text = ObjEntrega_Recojo.x_Origen
            txtDestino.Text = ObjEntrega_Recojo.x_Destino
            lbTipoComprobante.Text = ObjEntrega_Recojo.x_Tipo_comprobante
            txtDireccion.Text = ObjEntrega_Recojo.x_Direccion
            txtEntregado.Text = ObjEntrega_Recojo.x_Nombres_Entrega
            txtDNIEntrega.Text = ObjEntrega_Recojo.x_DNI_Entrega.Trim
            txtEstado.Text = ObjEntrega_Recojo.x_Estado
            txtFecha_Entrega.Text = dtoUSUARIOS.m_sFecha '22/05/2008 - Omendoza ObjEntrega_Recojo.x_Fecha
            dtHoraEntrega.Text = ObjEntrega_Recojo.x_Hora_Entrega
            txtFecha_Doc.Text = ObjEntrega_Recojo.x_Fecha
            ' Valores Predeterminados'
            Dim ldt_tmp As New DataTable
            ldt_tmp = ObjEntrega_Recojo.fnSP_LISTAR_MOTIVOS()
            'Mod.02/10/2009 -->Omendoza - Pasando al datahelper -  
            'ModuUtil.LlenarComboIDs(ObjEntrega_Recojo.cur_datos, cmbTipoNoAtencion, ObjEntrega_Recojo.coll_Lista_Motivos, ObjEntrega_Recojo.x_Idmotivos_No_Atencion)
            ModuUtil.LlenarComboIDs_dt(ldt_tmp, cmbTipoNoAtencion, ObjEntrega_Recojo.coll_Lista_Motivos, ObjEntrega_Recojo.x_Idmotivos_No_Atencion)
            Me.cmbTipoNoAtencion.SelectedIndex = 0
            '
            txtObsNoAtencion.Text = ObjEntrega_Recojo.x_obs
            '
            CargarConsignado(dtConsignado)

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub fnGrabar()
        Try
            ObjEntrega_Recojo.fnClearEntrega()
            ObjEntrega_Recojo.R_CodigoUsuario = ObjEntrega_Recojo.x_Idpersona_Recojo
            ObjEntrega_Recojo.R_NumeroSolicitud = v_idSolicitud_Entrega.ToString
            '
            If ChkAtendido.Checked = True Then
                ObjEntrega_Recojo.R_EstadoFinal = "A"
            Else
                ObjEntrega_Recojo.R_EstadoFinal = "N"
            End If
            '
            'ObjEntrega_Recojo.R_NumeroBultos = IIf(ObjEntrega_Recojo.x_Cantidad <> " " Or ObjEntrega_Recojo.x_Cantidad <> "", Int(ObjEntrega_Recojo.x_Cantidad.ToString()), 0)
            ObjEntrega_Recojo.R_NumeroBultos = 0
            ObjEntrega_Recojo.R_DniCliente = IIf(txtDNIEntrega.Text.Trim <> "" Or txtDNIEntrega.Text <> " ", txtDNIEntrega.Text.Trim, "NULL")
            ObjEntrega_Recojo.R_NombreCliente = IIf(txtEntregado.Text <> "" Or txtEntregado.Text <> " ", txtEntregado.Text, "NULL")
            ObjEntrega_Recojo.R_Fecha_Atencion = IIf(txtFecha_Entrega.Text <> "" Or txtFecha_Entrega.Text <> " ", txtFecha_Entrega.Text, "NULL")
            ObjEntrega_Recojo.R_hora_Atencion = dtHoraEntrega.Text
            ObjEntrega_Recojo.R_Direccion_Entrega = IIf(txtDireccion.Text <> "" Or txtDireccion.Text <> " ", txtDireccion.Text, "NULL")
            ObjEntrega_Recojo.R_Observación = IIf(txtObsNoAtencion.Text <> "" Or txtObsNoAtencion.Text <> " ", txtObsNoAtencion.Text, "NULL")
            ObjEntrega_Recojo.R_CodigoMotNoAtencion = ObjEntrega_Recojo.coll_Lista_Motivos.Item(cmbTipoNoAtencion.SelectedIndex.ToString)
            'Mod : 23/05/2008 - Omendoza. Objetivo validando que sea ingresado el código del incidente
            'If ObjEntrega_Recojo.R_EstadoFinal = "N" Then
            '    If ObjEntrega_Recojo.R_CodigoMotNoAtencion = 999 Then
            '        MsgBox("Falta ingresar el código de no atención", MsgBoxStyle.Exclamation, "Confirmar Entregas Operaciones Moviles")
            '        Me.cmbTipoNoAtencion.Focus()
            '        Exit Sub
            '    End If
            'End If
            '
            ObjEntrega_Recojo.fnRegistrarEstado()
            '
            'ObjWebService.fnWebService(v_idTipo_Comprobante, v_idComprobante, 56)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub checkAtendido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAtendido.CheckedChanged
        If ChkAtendido.Checked = True Then
            ChkAtendido.Text = "ATENDIDO"
            Me.cmbTipoNoAtencion.Enabled = False
            Me.cmbTipoNoAtencion.SelectedIndex = 0
            Me.CboConsignado.Enabled = True
            Me.BtnNuevo.Enabled = txtEstado.Text = "REPARTO"
        Else
            ChkAtendido.Text = "NO ATENDIDO"
            Me.cmbTipoNoAtencion.Enabled = True
            Me.cmbTipoNoAtencion.SelectedIndex = 0
            Me.CboConsignado.SelectedValue = 0
            Me.txtEntregado.Text = ""
            Me.CboConsignado.Enabled = False
            Me.txtDNIEntrega.Enabled = False
            Me.txtDNIEntrega.Text = ""
            Me.BtnNuevo.Enabled = False
        End If
    End Sub
    Private Sub fnEditar()
        Try

        Catch ex As Exception

        End Try
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean = True
        Dim flat As Boolean = True
        Try
            Dim var As Integer = msg.WParam.ToInt32

            If msg.WParam.ToInt32 = Keys.Enter Then
                If Me.txtDireccion.Focused = True Then
                    txtEntregado.Focus()
                    txtEntregado.SelectAll()
                ElseIf Me.txtEntregado.Focused = True Then
                    txtDNIEntrega.SelectAll()
                    txtDNIEntrega.Focus()
                ElseIf Me.txtDNIEntrega.Focused = True Then
                    txtFecha_Entrega.Focus()
                    txtFecha_Entrega.SelectAll()
                ElseIf txtFecha_Entrega.Focused = True Then
                    dtHoraEntrega.Focus()
                ElseIf dtHoraEntrega.Focused = True Then
                    ChkAtendido.Focus()
                ElseIf cmbTipoNoAtencion.Focused = True Then
                    txtObsNoAtencion.Focus()
                    txtObsNoAtencion.SelectAll()
                ElseIf txtObsNoAtencion.Focused = True Then
                    btnAceptar.Focus()
                Else
                    SendKeys.Send("{Tab}")
                End If

            ElseIf msg.WParam.ToInt32 = Keys.F2 Then
                If Me.btnAgregar.Enabled Then
                    fnEditar()
                End If
            ElseIf msg.WParam.ToInt32 = Keys.Escape Then
                If MsgBox("Esta Seguro que Quiere cancelar y Salir de esta Operacion...?", MsgBoxStyle.YesNoCancel, "Seguridad Sistema") = MsgBoxResult.Yes Then
                    Close()
                End If
            ElseIf msg.WParam.ToInt32 = Keys.F3 Then
                txtDireccion.SelectAll()
                txtDireccion.Focus()
            ElseIf msg.WParam.ToInt32 = Keys.F4 Then
                txtEntregado.SelectAll()
                txtEntregado.Focus()
            ElseIf msg.WParam.ToInt32 = Keys.F5 Then
                'cambio tecla funcion
                If Me.btnAceptar.Enabled Then
                    fnGrabar()
                End If
            ElseIf msg.WParam.ToInt32 = Keys.F6 Then
                txtDNIEntrega.SelectAll()
                txtDNIEntrega.Focus()
            ElseIf msg.WParam.ToInt32 = Keys.F7 Then
                txtFecha_Entrega.SelectAll()
                txtFecha_Entrega.Focus()
            ElseIf msg.WParam.ToInt32 = Keys.F7 Then
                dtHoraEntrega.Focus()
            ElseIf msg.WParam.ToInt32 = Keys.F12 Then
                If MsgBox("Esta Seguro que quiere salir de ventas al contado ", MsgBoxStyle.YesNoCancel, "Seguridad Sistema") = MsgBoxResult.Yes Then
                    Close()
                End If
            Else
                flat = MyBase.ProcessCmdKey(msg, KeyData)
            End If
FINAL:
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flat
    End Function

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub
    Sub limpiar_campos()
        Try
            '
            txtDNIEntrega.Text = ""
            txtEntregado.Text = ""
            dtHoraEntrega.Text = ""
            txtDireccion.Text = ""
            txtObsNoAtencion.Text = ""
            cmbTipoNoAtencion.Text = ""
            ChkAtendido.Checked = False
            txtFecha_Entrega.Text = dtoUSUARIOS.dfecha_sistema
            Me.CboConsignado.SelectedValue = 0
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If Not Validar() Then
                Return
            End If

            If rows.Count > 1 Then      'se confirmará mas de un comprobante
                For i As Integer = 0 To rows.Count - 1
                    fnGrabar(rows.Item(i).Cells(2).Value, rows.Item(i).Cells("idcomprobante").Value, rows.Item(i).Cells("idtipo_comprobante").Value)
                Next i
                MessageBox.Show("ACTUALIZADO CORRECTAMENTE", "Seguridad Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                limpiar_campos()
                Close()
            Else
                fnGrabar()
                limpiar_campos()
                Close()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Function Validar() As Boolean
        If Me.txtDireccion.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese la Direccion", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtDireccion.Text = ""
            Me.txtDireccion.Focus()
            Return False
        End If

        If Me.ChkAtendido.Checked Then
            If Me.CboConsignado.SelectedIndex = 0 Then
                MessageBox.Show("Seleccione el Consignado", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.CboConsignado.Focus()
                Return False
            End If
            If Me.txtDNIEntrega.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nº de Documento", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtDNIEntrega.Text = ""
                Me.txtDNIEntrega.Focus()
                Return False
            End If


            'Valida si comprobante tiene alguna solicitud pendiente o aprobada
            Dim obj As New Cls_FacturaAdicional_LN
            Dim strTipoOperacion As String = obj.ComprobanteOperacion(v_idComprobante)
            If strTipoOperacion.Trim.Length > 0 Then
                If strTipoOperacion.Trim <> "x" Then
                    MessageBox.Show("El Comprobante tiene una solicitud pendiente por " & Chr(13) & strTipoOperacion, "Confirmación Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If

        Else
            If Me.cmbTipoNoAtencion.SelectedIndex = 0 Then
                MessageBox.Show("Seleccione el Motivo de No Atención", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cmbTipoNoAtencion.Focus()
                Return False
            End If
            'If ObjEntrega_Recojo.R_EstadoFinal = "N" Then
            '    If ObjEntrega_Recojo.R_CodigoMotNoAtencion = 999 Then
            '        MsgBox("Falta ingresar el código de no atención", MsgBoxStyle.Exclamation, "Confirmar Entregas Operaciones Moviles")
            '        Me.cmbTipoNoAtencion.Focus()
            '        Exit Function
            '    End If
            'End If
        End If
        Return True
    End Function

    Private Sub fnGrabar(ByVal solicitud As Integer, ByVal id As Integer, ByVal tipo As Integer)
        Try
            ObjEntrega_Recojo.fnClearEntrega()
            ObjEntrega_Recojo.R_CodigoUsuario = ObjEntrega_Recojo.x_Idpersona_Recojo
            ObjEntrega_Recojo.R_NumeroSolicitud = solicitud.ToString
            '
            If ChkAtendido.Checked = True Then
                ObjEntrega_Recojo.R_EstadoFinal = "A"
            Else
                ObjEntrega_Recojo.R_EstadoFinal = "N"
            End If
            '
            'ObjEntrega_Recojo.R_NumeroBultos = IIf(ObjEntrega_Recojo.x_Cantidad <> " " Or ObjEntrega_Recojo.x_Cantidad <> "", Int(ObjEntrega_Recojo.x_Cantidad.ToString()), 0)
            ObjEntrega_Recojo.R_NumeroBultos = 0
            ObjEntrega_Recojo.R_DniCliente = IIf(txtDNIEntrega.Text.Trim <> "" Or txtDNIEntrega.Text <> " ", txtDNIEntrega.Text.Trim, "NULL")
            ObjEntrega_Recojo.R_NombreCliente = IIf(txtEntregado.Text <> "" Or txtEntregado.Text <> " ", txtEntregado.Text, "NULL")
            ObjEntrega_Recojo.R_Fecha_Atencion = IIf(txtFecha_Entrega.Text <> "" Or txtFecha_Entrega.Text <> " ", txtFecha_Entrega.Text, "NULL")
            ObjEntrega_Recojo.R_hora_Atencion = dtHoraEntrega.Text
            ObjEntrega_Recojo.R_Direccion_Entrega = IIf(txtDireccion.Text <> "" Or txtDireccion.Text <> " ", txtDireccion.Text, "NULL")
            ObjEntrega_Recojo.R_Observación = IIf(txtObsNoAtencion.Text <> "" Or txtObsNoAtencion.Text <> " ", txtObsNoAtencion.Text, "NULL")
            ObjEntrega_Recojo.R_CodigoMotNoAtencion = ObjEntrega_Recojo.coll_Lista_Motivos.Item(cmbTipoNoAtencion.SelectedIndex.ToString)
            'Mod : 23/05/2008 - Omendoza. Objetivo validando que sea ingresado el código del incidente
            If ObjEntrega_Recojo.R_EstadoFinal = "N" Then
                If ObjEntrega_Recojo.R_CodigoMotNoAtencion = 999 Then
                    MsgBox("Falta ingresar el código de no atención", MsgBoxStyle.Exclamation, "Confirmar Entregas Operaciones Moviles")
                    Me.cmbTipoNoAtencion.Focus()
                    Exit Sub
                End If
            End If
            '
            ObjEntrega_Recojo.fnRegistrarEstado(1)
            '
            ObjWebService.fnWebService(tipo, id, 56)
            'limpiar_campos()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Sub CargarConsignado(ByVal dt As DataTable)
        With Me.CboConsignado
            .DataSource = dt
            .ValueMember = "id_consignado"
            .DisplayMember = "nombres"
            .SelectedValue = 0
        End With
    End Sub

    Private Sub CboConsignado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboConsignado.SelectedIndexChanged
        If Not IsReference(Me.CboConsignado.SelectedValue) Then
            If CboConsignado.SelectedValue = 0 Then
                Me.txtEntregado.Text = ""
                Me.txtDNIEntrega.Text = ""
                Me.txtDNIEntrega.Enabled = False
            Else
                Me.txtEntregado.Text = CboConsignado.Text
                Me.txtDNIEntrega.Text = dtConsignado.Rows(CboConsignado.SelectedIndex).Item(2).ToString.Trim
                Me.txtDNIEntrega.Enabled = True
            End If
        Else
            Me.txtEntregado.Text = ""
            Me.txtDNIEntrega.Text = ""
        End If
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Dim frm As New FrmConsignadoNuevo
        Acceso.Asignar(frm, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then

            '***CambioR*****************************************
            Dim IDConsignado As String = ""
            'dtConsignado = ObjEntregaCarga.dtConsignado

            frm.IDPersona = ObjEntrega_Recojo.x_Idpersona
            frm.IDUnidadDestino = ObjEntrega_Recojo.x_idagencia_destino
            'frm.IDConsignado = IDConsignado
            frm.IDComprobante = ObjEntrega_Recojo.x_idComprobante
            frm.IDTipoComprobante = ObjEntrega_Recojo.x_Idtipo_Comprobante
            '***Fin Cambio***************************************
            frm.ShowDialog()

            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                Dim dt As DataTable = ObjEntrega_Recojo.ListaConsignado(v_idSolicitud_Entrega)
                dtConsignado = dt
                With CboConsignado
                    .DataSource = dt
                    .DisplayMember = "nombres"
                    .ValueMember = "id_consignado"
                End With
            End If

            'If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            '    dtConsignado.AcceptChanges()
            'End If
        Else
            MessageBox.Show(G_Mje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class