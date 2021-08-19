Public Class frm_act_cliente_contado_credito
#Region "Variables publicas"
    Public dtTipoFacturacion, dtRubro, dtClasPersona, dtPaisCombo, dtDepartamentoCombo, dtProvinciaCombo, dtDistritoCombo As New DataTable
    Public dvTipoFacturacion, dvRubro, dvClasPersona, dvPais, dvDepartamento, dvProvincia, dvDistrito As New DataView
    Public pi_control As Integer
    Public hnd As Long
#End Region
#Region "Variables Privadas"
    Dim bIngreso As Boolean = False
#End Region
#Region "Eventos"

    Private Sub frm_act_cliente_contado_credito_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    'load
    Private Sub frm_act_cliente_contado_credito_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.cmbRubroEmpresarial.SelectedValue = 2
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    'Panel
    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New System.Drawing.Point(965, 80))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#507EAF"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    'País
    Private Sub cmbPais_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPais.SelectedIndexChanged
        Try
            If dvPais Is Nothing Then
                'Esta Vacio.
            Else
                Dim filCb As Integer
                Dim drc As DataRowView
                Dim valor As String
                filCb = cmbPais.SelectedIndex
                If filCb >= 0 Then
                    drc = dvPais.Item(filCb)
                    valor = IIf(IsDBNull(drc("IDPAIS")) = True, "0", drc("IDPAIS").ToString)
                    dvDepartamento.RowFilter = "IDPAIS =" & valor
                Else
                    dvDepartamento.RowFilter = "IDPAIS = 0"
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    'Departamento
    Private Sub cmbDepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDepartamento.SelectedIndexChanged
        Try
            If dvDepartamento Is Nothing Then
                'Esta Vacio
            Else
                Dim filCb As Integer
                Dim drc As DataRowView
                Dim valor As String
                filCb = cmbDepartamento.SelectedIndex
                If filCb >= 0 Then
                    drc = dvDepartamento.Item(filCb)
                    valor = IIf(IsDBNull(drc("IDDEPARTAMENTO")) = True, "0", drc("IDDEPARTAMENTO").ToString)
                    dvProvincia.RowFilter = "IDDEPARTAMENTO =" & valor
                Else
                    dvProvincia.RowFilter = "IDDEPARTAMENTO = 0"
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    'Provincia
    Private Sub cmbProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProvincia.SelectedIndexChanged
        Try
            If dvProvincia Is Nothing Then
                'Esta Vacio
            Else
                Dim filCb As Integer
                Dim drc As DataRowView
                Dim valor As String
                filCb = cmbProvincia.SelectedIndex
                If filCb >= 0 Then
                    drc = dvProvincia.Item(filCb)
                    valor = IIf(IsDBNull(drc("IDPROVINCIA")) = True, "0", drc("IDPROVINCIA").ToString)
                    dvDistrito.RowFilter = "IDPROVINCIA =" & valor
                Else
                    dvDistrito.RowFilter = "IDPROVINCIA = 0"
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    'btn_cancelar
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        pi_control = 2
        MessageBox.Show("No actualizado los datos del cliente contado", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub
    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        ' Grabar solo los datos adicionales 
        Dim MyClassCliente As New dtoCLIENTES
        'Dim respOracle As New ADODB.Recordset
        '        
        Try
            MyClassCliente.s_MyIDPersona = Me.txt_idpersona.Text
            MyClassCliente._MyCodigoCliente = Me.txt_codigo_cliente.Text
            MyClassCliente._MyRazonSocial = Me.txt_trazon_social.Text
            MyClassCliente._MyRepresentanteLegal = Me.txt_representante_legal.Text
            MyClassCliente._MyGerenteGeneral = Me.txt_gerente_general.Text
            If Me.chkPostFacturacion.Checked = False Then
                MyClassCliente._MyPagoPostfacturacion = 0
            Else
                MyClassCliente._MyPagoPostfacturacion = 1
            End If
            If Me.chkAgenteRetencion.Checked = False Then
                MyClassCliente._MyAgenteRetencion = 0
            Else
                MyClassCliente._MyAgenteRetencion = 1
            End If
            MyClassCliente._MyClienteCorporativo = 1 'Siempre va a pasar a corporativo 12/07/2007  
            MyClassCliente._MyIDRubro = Me.cmbRubroEmpresarial.SelectedValue
            MyClassCliente._MyClasificacionPersona = Me.cmbClasPersona.SelectedValue
            MyClassCliente._MyIDPais = Me.cmbPais.SelectedValue
            MyClassCliente._MyIDDepartamento = Me.cmbDepartamento.SelectedValue
            MyClassCliente._MyIDProvincia = Me.cmbProvincia.SelectedValue
            MyClassCliente._MyIDDistrito = Me.cmbdistrito.SelectedValue
            MyClassCliente._MyTipoFacturacion = Me.cmbTipoFacturacion.SelectedValue
            MyClassCliente._MyUsuarioPersonal = dtoUSUARIOS.IdLogin
            MyClassCliente._MyIP = dtoUSUARIOS.IP
            'datahelper
            'respOracle = MyClassCliente.fn_grabadatos_adicional()
            Dim respOracle As DataTable = MyClassCliente.fn_grabadatos_adicional()
            If respOracle.Rows(0).Item("error").ToString <> 0 Then
                MessageBox.Show("Descripción: " & respOracle.Rows(0).Item("error").ToString & " ORACLE -> Error: " & CType(respOracle.Rows(0).Item("mensaje").ToString, String), "Sistema de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                pi_control = 2
            Else
                pi_control = 1
            End If

            'datahelper
            'If respOracle.Fields.Item("error").Value() <> 0 Then
            '    MessageBox.Show("Descripción: " & respOracle.Fields("error").Value & " ORACLE -> Error: " & CType(respOracle.Fields("mensaje").Value, String), "Sistema de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    pi_control = 2
            'Else
            '    pi_control = 1
            'End If
            '            
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "Procedimientos"
#End Region
End Class