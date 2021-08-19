Imports INTEGRACION_LN
Public Class frmrefacturacion
#Region "Variables"
    'Dim odba As New OleDb.OleDbDataAdapter
    Dim dtusuario, dtrefactura As New DataTable
    Dim dvusuario, dvrefactura As New DataView
    Dim ObjFactura As New ClsLbTepsa.dtoFACTURA
    Dim bIngreso As Boolean = False
    Dim dtOperacion As DataTable
    Public hnd As Long
#End Region
#Region "Variables de Control"
    Dim control As Long = 0
    Dim digv As Double = dtoUSUARIOS.iIGV  ' Pasar el parámetro de IGV
    '
    Dim li_esrefacturado As Integer
    Dim lbusqueda As Integer = 0
    Dim b_nolee_campo As Boolean = True

    Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL

#End Region

#Region "Procedimientos y Funciones"
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            ' Return True
        End If
        ' Salir del sistema 
        If msg.WParam.ToInt32() = CInt(Keys.Escape) Then
            limpia_variables()
            SelectMenu(0)
            ToolStripMenuItem1.Enabled = True
            ToolStripMenuItem2.Enabled = False
            control = 0
        End If
        If msg.WParam.ToInt32() = CInt(Keys.F5) Then
            ' Grabar 
            'cambio tecla funcion
            If Me.btngrabar.Enabled Then
                fn_grabar_refactura()
            End If
        End If
    End Function

    Private Sub frmrefacturacion_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frmrefacturacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frmrefacturacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            dtoUSUARIOS.m_iNombreUnidadAgencia = fnGetCiudad(dtoUSUARIOS.m_idciudad.ToString)
            dtoUSUARIOS.m_iNombreAgencia = fnGetAGENCIA(dtoUSUARIOS.m_iIdAgencia.ToString)
            Me.Text = "REFACTURACION..." & dtoUSUARIOS.iLOGIN & " Ag. Nro " & dtoUSUARIOS.m_iIdAgencia & " [ " & dtoUSUARIOS.m_iNombreAgencia & " ][ " & dtoUSUARIOS.m_iNombreUnidadAgencia & "] "
            ToolStripMenuItem1.Text = "&BUSCAR"
            ToolStripMenuItem2.Text = "&REFACTURACION"
            ToolStripMenuItem2.Enabled = False
            ToolStripMenuItem3.Enabled = False
            ToolStripMenuItem4.Enabled = False
            ToolStripMenuItem5.Enabled = False
            ToolStripMenuItem6.Enabled = False
            SelectMenu(0)
            control = 0
            'Recupera los usuarios del sistema 
            If Objrefacturacion.fnLISTA_INICIAL_refacturacion = True Then
                dtusuario = Objrefacturacion.rst_usuarios
                dvusuario = CargarCombo(Me.cmbUsuarios, dtusuario, "apellidos", "Idusuario_Personal", 9999)
                Objrefacturacion.rst_usuarios = Nothing ' Ya no se usara             

                dtrefactura = Objrefacturacion.rst_refactura
                dvrefactura = dtrefactura.DefaultView

                fn_generagrilla()

                'datahelper
                'odba.Fill(dtusuario, Objrefacturacion.rst_usuarios)
                ''
                'dvusuario = CargarCombo(Me.cmbUsuarios, dtusuario, "apellidos", "Idusuario_Personal", 9999)
                'Objrefacturacion.rst_usuarios = Nothing ' Ya no se usara             
                ''
                'odba.Fill(dtrefactura, Objrefacturacion.rst_refactura)
                'dvrefactura = dtrefactura.DefaultView
                ''
                'fn_generagrilla()
            End If
            'datahelper
            'ObjGeneral.sp_listar_tipo_nota_credito(Me.CBIDTIPO_NOTA_CREDI, VOCONTROLUSUARIO)
            ObjGeneral.sp_listar_tipo_nota_credito(Me.CBIDTIPO_NOTA_CREDI)

            ListarOperacion(1, 0, 2, 3, 3, dtoUSUARIOS.IdRol)

            Me.CBIDTIPO_NOTA_CREDI.SelectedIndex = -1

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Sub ListarOperacion(tipo_registro As Integer, tipo As Integer, tipo_servicio As Integer, tipo_comprobante As Integer, modo As Integer, rol As Integer)
        Dim obj As New Cls_NotaCredito_LN
        dtOperacion = obj.ListarOperacion(tipo_registro, tipo, tipo_servicio, tipo_comprobante, 2, modo, rol)
        With Me.cboOperacion
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = dtOperacion
            .SelectedValue = 0
        End With
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        SelectMenu(1)
        b_nolee_campo = True
        ToolStripMenuItem2.Enabled = True
        ToolStripMenuItem1.Enabled = False
        control = 1
        limpia_variables()
        Me.txtserfactura_act.Focus()
    End Sub
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Sub fn_generagrilla()
        Try
            dtGridViewControl_refactura.Columns.Clear()
            With dtGridViewControl_refactura
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AutoGenerateColumns = False
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                .DataSource = dvrefactura
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            'dtGridViewControl_FACBOL.Columns.Add(idEstadoImage)


            Dim SI_REFACTURA As New DataGridViewTextBoxColumn
            With SI_REFACTURA '2
                .DisplayIndex = 0
                .DataPropertyName = "SI_REFACTURA"
                .Name = "SI_REFACTURA"
                .HeaderText = "¿Refactura?"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_refactura.Columns.Add(SI_REFACTURA)

            Dim tipo_comprobante As New DataGridViewTextBoxColumn
            With tipo_comprobante  '2
                .DisplayIndex = 1
                .DataPropertyName = "tipo_comprobante"
                .Name = "tipo_comprobante"
                .HeaderText = "tipo Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_refactura.Columns.Add(tipo_comprobante)




            Dim srefactura As New DataGridViewTextBoxColumn
            With srefactura '0
                .DisplayIndex = 2
                .DataPropertyName = "refactura"
                .Name = "refactura"
                .HeaderText = "Nro. Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_refactura.Columns.Add(srefactura)
            '
            Dim sfecha_refactura As New DataGridViewTextBoxColumn
            With sfecha_refactura '1
                .DisplayIndex = 3
                .DataPropertyName = "fecha_refactura"
                .Name = "fecha_refactura"
                .HeaderText = "Fecha Refactura"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_refactura.Columns.Add(sfecha_refactura)
            '
            Dim slogin As New DataGridViewTextBoxColumn
            With slogin '2
                .DisplayIndex = 4
                .DataPropertyName = "login"
                .Name = "login"
                .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_refactura.Columns.Add(slogin)
            '
            Dim sfacturaoriginal As New DataGridViewTextBoxColumn
            With sfacturaoriginal ' 3
                .DisplayIndex = 5
                .DataPropertyName = "factura_original"
                .Name = "factura_original"
                .HeaderText = "Factura Original"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_refactura.Columns.Add(sfacturaoriginal)
            '
            Dim sfecha_original As New DataGridViewTextBoxColumn
            With sfecha_original ' 4
                .DisplayIndex = 6
                .DataPropertyName = "fecha_original"
                .Name = "sfecha_original"
                .HeaderText = "Fecha Original"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_refactura.Columns.Add(sfecha_original)
            '
            Dim nsub_total As New DataGridViewTextBoxColumn
            With nsub_total ' 5
                .DisplayIndex = 7
                .DataPropertyName = "sub_total"
                .Name = "nsub_total"
                .HeaderText = "Sub Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_refactura.Columns.Add(nsub_total)
            '
            Dim nmonto_impuesto As New DataGridViewTextBoxColumn
            With nmonto_impuesto '6 
                .DisplayIndex = 8
                .DataPropertyName = "monto_impuesto"
                .Name = "monto_impuesto"
                .HeaderText = "Impuesto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_refactura.Columns.Add(nmonto_impuesto)
            '
            Dim ntotal_costo As New DataGridViewTextBoxColumn
            With ntotal_costo '7
                .DisplayIndex = 9
                .DataPropertyName = "total_costo"
                .Name = "total_costo"
                .HeaderText = "Total Costo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
            End With

            dtGridViewControl_refactura.Columns.Add(ntotal_costo)


            Dim estado_registro As New DataGridViewTextBoxColumn
            With estado_registro  '2
                .DisplayIndex = 10
                .DataPropertyName = "estado_registro"
                .Name = "estado_registro"
                .HeaderText = "Etado Registro"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_refactura.Columns.Add(estado_registro)



            Dim TIPO_NOTA_CREDITO As New DataGridViewTextBoxColumn
            With TIPO_NOTA_CREDITO  '2
                .DisplayIndex = 11
                .DataPropertyName = "TIPO_NOTA_CREDITO"
                .Name = "TIPO_NOTA_CREDITO"
                .HeaderText = "Tipo Nota Crédito"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = True

            End With
            dtGridViewControl_refactura.Columns.Add(TIPO_NOTA_CREDITO)


            '
            Dim idtipo_comprobante As New DataGridViewTextBoxColumn
            With idtipo_comprobante '7
                .DisplayIndex = 12
                .DataPropertyName = "idtipo_comprobante"
                .Name = "idtipo_comprobante"
                .HeaderText = "idtipo_comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
                .Width = 0
            End With
            dtGridViewControl_refactura.Columns.Add(idtipo_comprobante)

            Dim idfactura As New DataGridViewTextBoxColumn
            With idfactura '7
                .DisplayIndex = 13
                .DataPropertyName = "idfactura"
                .Name = "idfactura"
                .HeaderText = "idfactura"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
                .Width = 0
            End With
            dtGridViewControl_refactura.Columns.Add(idfactura)

            Dim es_refactura As New DataGridViewTextBoxColumn
            With es_refactura '7
                .DisplayIndex = 14
                .DataPropertyName = "es_refactura"
                .Name = "es_refactura"
                .HeaderText = "es_refactura"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
                .Width = 0
            End With
            dtGridViewControl_refactura.Columns.Add(es_refactura)


            Dim idestado_factura As New DataGridViewTextBoxColumn
            With idestado_factura '7
                .DisplayIndex = 15
                .DataPropertyName = "idestado_factura"
                .Name = "idestado_factura"
                .HeaderText = "idestado_factura"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
                .Width = 0
            End With
            dtGridViewControl_refactura.Columns.Add(idestado_factura)

            Dim idproceso As New DataGridViewTextBoxColumn
            With idproceso
                .DisplayIndex = 16
                .DataPropertyName = "idproceso"
                .Name = "idproceso"
                .HeaderText = "idproceso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_refactura.Columns.Add(idproceso)

            Dim col_n_emife As New DataGridViewTextBoxColumn
            With col_n_emife
                .DisplayIndex = 17
                .DataPropertyName = "n_emife"
                .Name = "n_emife"
                .HeaderText = "n_emife"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_refactura.Columns.Add(col_n_emife)

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Sub limpia_variables()
        Me.txtserfactura_act.Text = ""
        Me.txtnrofactura_actual.Text = ""
        Me.txtnrofactura_actual.Tag = Nothing
        Me.txtserfactura_act.Tag = Nothing
        Me.txtsub_total.Text = "0.00"
        Me.txtigv.Text = "0.00"
        Me.txttotal.Text = "0.00"
        Me.txtrazon_social.Text = ""
        Me.txtruc.Text = ""
        Me.txtserie_nota_cred.Text = ""
        Me.txtnro_nota_cred.Text = ""
        Me.txtserie_factura_new.Text = ""
        Me.txtnro_factura_new.Text = ""
        Me.txtidfactura.Text = ""
        Me.txtsubtotal_new.Text = "0.00"
        Me.txtigv_new.Text = "0.00"
        Me.txttotal_new.Text = "0.00"
        rtb.Text = ""
        '
        li_esrefacturado = 0
    End Sub
    Private Sub txtnrofactura_actual_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtserie_nota_cred.KeyPress, txtserie_factura_new.KeyPress, txtnrofactura_actual.KeyPress, txtnro_factura_new.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        limpia_variables()
        SelectMenu(0)
        ToolStripMenuItem2.Enabled = False
        ToolStripMenuItem1.Enabled = True
        control = 0
    End Sub

    Private Sub txtnrofactura_actual_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnrofactura_actual.Leave
        If Me.txtserfactura_act.Text = "" Then
            MsgBox("Falta ingresar la serie de la factura a refacturar", MsgBoxStyle.Information, "Refacturación")
            Me.txtserfactura_act.Focus()
            b_nolee_campo = False
            Exit Sub
        End If
        If txtnrofactura_actual.Text = "" Then
            b_nolee_campo = False
            Exit Sub
        End If
        Me.txtnrofactura_actual.Text = RellenoRight(7, Me.txtnrofactura_actual.Text)
    End Sub
    Private Sub txtnrofactura_actual_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtnrofactura_actual.Validating
        Dim li_mes_actual, li_mes_factura As Integer
        Dim strReferencia As String
        Try
            If b_nolee_campo Then
                Objrefacturacion.sserie_factura = Me.txtserfactura_act.Text
                Objrefacturacion.snro_factura = Me.txtnrofactura_actual.Text
                Dim intOpcion As Integer = IIf(Me.rbtCredito.Checked, 1, 2)
                If Objrefacturacion.fnverifica_factura_actual(intOpcion) = True Then
                    If Objrefacturacion.iesfactura = 2 Then
                        MsgBox("La factura : " & Me.txtserfactura_act.Text & " - " & Me.txtnrofactura_actual.Text & " se encuentra anulada, no es aplicable de nota de crédito", MsgBoxStyle.Information, "Refacturación")
                        Me.txtnrofactura_actual.Text = ""
                        e.Cancel = True
                        Exit Sub
                    ElseIf Objrefacturacion.iesfactura = 3 Then
                        MsgBox("La factura: " & Me.txtserfactura_act.Text & " - " & Me.txtnrofactura_actual.Text & " se encuentra eliminada, no es aplicable de nota de crédito", MsgBoxStyle.Information, "Refacturación")
                        Me.txtnrofactura_actual.Text = ""
                        e.Cancel = True
                        Exit Sub
                        'ElseIf Objrefacturacion.iesfactura = 30 Then
                        '    MsgBox("La factura: " & Me.txtserfactura_act.Text & " - " & Me.txtnrofactura_actual.Text & " se encuentra cancelada, no es aplicable de nota de crédito", MsgBoxStyle.Information, "Refacturación")
                        '    Me.txtnrofactura_actual.Text = ""
                        '    e.Cancel = True
                        '    Exit Sub
                    End If

                    li_esrefacturado = Objrefacturacion.iesrefacturado
                    If li_esrefacturado = 1 Then ' Es una factura que ha sido refacturada 
                        MsgBox("La factura ha sido refacturada", MsgBoxStyle.Information, "Refacturación")
                        Me.txtnrofactura_actual.Text = ""
                        e.Cancel = True
                        Exit Sub
                    End If
                    '
                    li_mes_factura = Objrefacturacion.imes_factura
                    li_mes_actual = Objrefacturacion.imes_sistema
                    If li_mes_factura = li_mes_actual Then
                        MsgBox("No se puede refacturar, facturas que se encuentren en el mismo mes", MsgBoxStyle.Information, "Refacturación")
                        Me.txtnrofactura_actual.Text = ""
                        e.Cancel = True
                        Exit Sub
                    End If
                    '
                    Me.txtidfactura.Text = Objrefacturacion.sidfactura
                    Me.txtnrofactura_actual.Tag = Objrefacturacion.intTipoComprobante

                    Me.dtp_fecha_emision.Text = Objrefacturacion.sfecha_factura
                    Me.txtsub_total.Text = Objrefacturacion.dsubtotal
                    Me.txtigv.Text = Objrefacturacion.dimpuesto
                    Me.txttotal.Text = Objrefacturacion.dtotal_costo
                    Me.txtrazon_social.Text = Objrefacturacion.srazon_social
                    Me.txtruc.Text = Objrefacturacion.sruc

                    If Me.rbrefac.Checked = True Or Me.CBIDTIPO_NOTA_CREDI.SelectedValue = 1 Then
                        Me.txtsub_total_nc.Text = Me.txtsub_total.Text
                        Me.txtigv_nc.Text = Me.txtigv.Text
                        Me.txttotal_nc.Text = Me.txttotal.Text

                        Me.txtsub_total_nc.ReadOnly = True
                        Me.txtigv_nc.ReadOnly = True
                        Me.txttotal_nc.ReadOnly = True
                    Else
                        Me.txtsub_total_nc.Text = "0.00"
                        Me.txtigv_nc.Text = "0.00"
                        Me.txttotal_nc.Text = "0.00"

                        Me.txtsub_total_nc.ReadOnly = False
                        Me.txtigv_nc.ReadOnly = False
                        Me.txttotal_nc.ReadOnly = False
                    End If

                    Me.txtsubtotal_new.Text = Me.txtsub_total.Text
                    Me.txtigv_new.Text = Me.txtigv.Text
                    Me.txttotal_new.Text = Me.txttotal.Text

                    Dim dtorefacturacionClone As New dtorefacturacion
                    dtorefacturacionClone.sserie_factura = Objrefacturacion.sserie_factura
                    dtorefacturacionClone.snro_factura = Objrefacturacion.snro_factura
                    dtorefacturacionClone.sfecha_factura = Objrefacturacion.sfecha_factura
                    Me.txtnrofactura_actual.Tag = dtorefacturacionClone

                    'Dim strPrefijo As String
                    'If Objrefacturacion.intTipoComprobante = 1 Then
                    '    strPrefijo = "F"
                    'Else
                    '    strPrefijo = "B"
                    'End If
                    txtserfactura_act.Tag = Objrefacturacion.sserie_factura & "-" & RellenoRight(8, Objrefacturacion.snro_factura)
                Else
                    txtserfactura_act.Tag = Nothing
                    MsgBox("No se encontró la Factura", MsgBoxStyle.Exclamation, "Refacturación")
                    Me.txtnrofactura_actual.Text = ""
                    Me.txtnrofactura_actual.Tag = Nothing
                    Me.txtnrofactura_actual.Focus()
                    e.Cancel = True
                    Exit Sub
                End If
                e.Cancel = False
                Me.txtserie_nota_cred.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub txtnro_nota_cred_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnro_nota_cred.Leave
        'If Me.txtserie_nota_cred.Text = "" Then
        '    MsgBox("Falta ingresar la serie de la nota crédito", MsgBoxStyle.Information, "Refacturación")
        '    Me.txtserie_nota_cred.Focus()
        '    Exit Sub
        'End If
        'Me.txtnro_nota_cred.Text = RellenoRight(7, Me.txtnro_nota_cred.Text)
    End Sub
    Private Sub txtnro_nota_cred_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtnro_nota_cred.Validating
        'Try
        '    Objrefacturacion.sserie_factura = Me.txtserie_nota_cred.Text
        '    Objrefacturacion.snro_factura = Me.txtnro_nota_cred.Text
        '    If Objrefacturacion.fnLISTA_verifica_dcto(1) = True Then
        '        If Objrefacturacion.s_cod_mensaje <> 1 Then
        '            MsgBox(Objrefacturacion.s_mensaje, MsgBoxStyle.Exclamation, "Refacturación")
        '            Me.txtnro_nota_cred.Text = ""
        '            Me.txtnro_nota_cred.Focus()
        '            e.Cancel = True
        '            Exit Sub
        '        End If
        '    End If
        '    e.Cancel = False
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        'End Try
    End Sub
    Private Sub txtnro_factura_new_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnro_factura_new.Leave
        'If Me.txtserie_factura_new.Text = "" Then
        '    MsgBox("Falta ingresar la serie de la nueva factura", MsgBoxStyle.Information, "Refacturación")
        '    Me.txtserie_factura_new.Focus()
        '    Exit Sub
        'End If
        'Me.txtnro_factura_new.Text = RellenoRight(7, Me.txtnro_factura_new.Text)
    End Sub
    Private Sub txtnro_factura_new_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtnro_factura_new.Validating
        'Try
        '    '
        '    Objrefacturacion.sserie_factura = Me.txtserie_factura_new.Text
        '    Objrefacturacion.snro_factura = Me.txtnro_factura_new.Text
        '    '
        '    If Objrefacturacion.fnLISTA_verifica_dcto(0) = True Then
        '        If Objrefacturacion.s_cod_mensaje <> 1 Then
        '            MsgBox(Objrefacturacion.s_mensaje, MsgBoxStyle.Exclamation, "Refacturación")
        '            Me.txtnro_factura_new.Text = ""
        '            Me.txtnro_factura_new.Focus()
        '            e.Cancel = True
        '            Exit Sub
        '        End If
        '    End If
        '    e.Cancel = False
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        'End Try
    End Sub
    Sub fn_grabar_refactura()
        Try
            If Me.txtserfactura_act.Text = "" Then
                MsgBox("Falta ingresar la serie de la factura a refacturar", MsgBoxStyle.Information, "Refacturación")
                Me.txtserfactura_act.Focus()
                Exit Sub
            End If
            If Me.txtnrofactura_actual.Text = "" Then
                MsgBox("Falta ingresar el número de la factura a refacturar", MsgBoxStyle.Information, "Refacturación")
                Me.txtnrofactura_actual.Focus()
                b_nolee_campo = True
                Exit Sub
            End If

            If Me.rtb.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese la Glosa", "Refacturación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.rtb.Text = Me.rtb.Text.Trim
                Me.rtb.Focus()
                Exit Sub
            End If

            Dim chCar As Char = Me.rtb.Text.Substring(0)
            Dim intCar As Integer = Asc(chCar)
            If Not ((intCar >= 97 And intCar <= 122) Or (intCar >= 65 And intCar <= 90)) Then
                MessageBox.Show("El 1er Caracter debe ser un caracter válido (A..Z a..z)", "Refacturación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.rtb.Focus()
                Return
            End If

            '-->Valida la configuarcion de la impresora - jabanto
            Dim dtImpresora As DataTable = Nothing
            If Not Me.rbdife.Checked Then
                dtImpresora = FEManager.buscarPrint()
                If dtImpresora Is Nothing Then
                    MessageBox.Show(FEManager.MESSAGE_NO_PRINT, "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If

            'Valida si Nota de Credito puede emitirse
            'Segun la fecha de comprobante, debe ser mayor a 3 dias
            Dim strFecha As String = DateAdd(DateInterval.Day, 1, CType(dtp_fecha_emision.Value.ToShortDateString, Date))
            Dim strFechaServidor As String = dtpfecha_notacredito.Value.ToShortDateString 'FechaServidor(1)
            Dim dias As Long = DateDiff(DateInterval.Day, CType(strFecha, Date), CType(strFechaServidor, Date))

            'If dias <= 3 Then 'si no esta dentro de los 10 dias habiles
            'Cursor = Cursors.Default
            'MessageBox.Show("La Nota de Crédito debe Emitirse después de 3 dias, según la fecha de Comprobante", "Refacturación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Return
            'End If

            If Objrefacturacion.emite_nc = 0 Then 'si no esta dentro de los 10 dias habiles
                Cursor = Cursors.Default
                MessageBox.Show("La Nota de Crédito excede Plazo de Emisión. No está dentro de los 10 dia hábiles", "Refacturación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If Me.cboOperacion.SelectedValue = 0 Then
                MessageBox.Show("Seleccione Tipo de Operación", "Refacturación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboOperacion.Focus()
                Exit Sub
            End If

            'If Me.txtserie_nota_cred.Text = "" Then
            '    MsgBox("Falta ingresar la serie de la nota crédito", MsgBoxStyle.Information, "Refacturación")
            '    Me.txtserie_nota_cred.Focus()
            '    Exit Sub
            'End If
            'If Me.txtnro_nota_cred.Text = "" Then
            '    MsgBox("Falta ingresar el número de la nota crédito", MsgBoxStyle.Information, "Refacturación")
            '    Me.txtnro_nota_cred.Focus()
            '    Exit Sub
            'End If

            If Me.CBIDTIPO_NOTA_CREDI.SelectedIndex = -1 Then
                MsgBox("Seleccione el tipo de nota de crédito", MsgBoxStyle.Information, "Refacturación")
                Me.CBIDTIPO_NOTA_CREDI.Focus()
                Exit Sub
            End If

            If Me.txtsub_total_nc.Text <= 0.0 Or Me.txtsub_total_nc.Text = "" Then
                MessageBox.Show("Ingrese el Monto", "Refacturación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtsub_total_nc.Focus()
                Exit Sub
            End If

            'If Me.rbrefac.Checked = True Then
            '    If Me.txtserie_factura_new.Text = "" Then
            '        MsgBox("Falta ingresar la serie de la nueva factura", MsgBoxStyle.Information, "Refacturación")
            '        Me.txtserie_factura_new.Focus()
            '        Exit Sub
            '    End If
            '    If Me.txtnro_factura_new.Text = "" Then
            '        MsgBox("Falta ingresar el número de la factura", MsgBoxStyle.Information, "Refacturación")
            '        Me.txtnro_factura_new.Focus()
            '        Exit Sub
            '    End If
            'End If
            ' 
            Objrefacturacion.sidfactura = Me.txtidfactura.Text
            Objrefacturacion.sserie_nota_cred = Me.txtserie_nota_cred.Text
            Objrefacturacion.snro_nota_cred = Me.txtnro_nota_cred.Text
            Objrefacturacion.sfecha_nota_credito = Me.dtpfecha_notacredito.Text

            'nuevos datos del a nota de credito
            Objrefacturacion.smonto_impuesto_nota_cred = CDbl(Me.txtigv_nc.Text)
            Objrefacturacion.stotal_costo_nota_cred = CDbl(Me.txttotal_nc.Text)
            Objrefacturacion.smemo_nota_credito = Me.rtb.Text
            'Objrefacturacion.IDTIPO_NOTA_CREDI = 

            If Me.rbdife.Checked = True Then
                Objrefacturacion.ses_refactura = 0
            Else
                Objrefacturacion.ses_refactura = 1
            End If

            '
            Objrefacturacion.sserie_factura = Me.txtserie_factura_new.Text
            Objrefacturacion.snro_factura = Me.txtnro_factura_new.Text
            Objrefacturacion.sfecha_factura = Me.dtpfecha_factura_new.Text
            Objrefacturacion.dimpuesto = CType(Me.txtigv_new.Text, Double)
            Objrefacturacion.dtotal_costo = CType(Me.txttotal_new.Text, Double)
            '
            Objrefacturacion.lidusuario_personal = dtoUSUARIOS.IdLogin
            Objrefacturacion.sip = dtoUSUARIOS.IP
            Objrefacturacion.iidrol = dtoUSUARIOS.IdRol
            Objrefacturacion.intAgencia = dtoUSUARIOS.iIDAGENCIAS
            Dim intOpcion As Integer = 0
            If Val(Me.txtsub_total.Text) = Val(Me.txtsub_total_nc.Text) Then
                intOpcion = 1
            End If

            Dim blnExito As Boolean
            Dim dataTableFactura, dataTableNota As DataTable

            If Me.rbtCredito.Checked Then 'Credito
                dataTableNota = Objrefacturacion.GrabarNC(intOpcion, Me.cboOperacion.SelectedValue)
                blnExito = Not (dataTableNota Is Nothing) And Objrefacturacion.s_cod_mensaje = 0
                If blnExito Then
                    If Objrefacturacion.ses_refactura = 1 Then
                        dataTableFactura = Objrefacturacion.GrabarRefacturacionCredito(intOpcion, Me.cboOperacion.SelectedValue)
                        blnExito = Not (dataTableFactura Is Nothing) And Objrefacturacion.s_cod_mensaje = 0
                    End If
                End If
            Else 'Otros
                dataTableNota = Objrefacturacion.GrabarNotaCredito(intOpcion, Me.cboOperacion.SelectedValue)
                blnExito = Not (dataTableNota Is Nothing) And Objrefacturacion.s_cod_mensaje = 0
                If blnExito Then
                    If Objrefacturacion.ses_refactura = 1 Then
                        If blnExito Then
                            dataTableFactura = Objrefacturacion.GrabarRefacturacion(intOpcion, Me.cboOperacion.SelectedValue)
                            blnExito = Not (dataTableFactura Is Nothing) And Objrefacturacion.s_cod_mensaje = 0
                        End If
                    End If
                End If
            End If
            'com



            'Dim dd = dtOperacion.Rows(cboOperacion.SelectedIndex).Item("codigo")
            '*****************************************************************
            '-->Emicion del comprobante electronico
            '*****************************************************************
            'If Not (dataTableNota Is Nothing) Then
            '    Dim dataRowNota As DataRow = dataTableNota.Rows(0)
            '    'NOTA DE CREDITO
            '    '******************************
            '    Dim fecliente As New FECliente
            '    fecliente.tipoDocumentoID = Objrefacturacion.stipoDcoumentoIdentidad
            '    fecliente.numeroDocumento = Objrefacturacion.sruc 'Objrefacturacion.sserie_factura & "-" & Objrefacturacion.snro_factura
            '    fecliente.nombres = Objrefacturacion.srazon_social
            '    fecliente.direccion = Objrefacturacion.direccion

            '    Dim dtorefacturacion_ As dtorefacturacion = txtnrofactura_actual.Tag

            '    Dim documentoReferencia As New FEDocumentoReferencia
            '    If Me.txtserfactura_act.Text.Trim.Substring(0, 1) = "F" Or Me.txtserfactura_act.Text.Trim.Substring(0, 1) = "9" Then
            '        documentoReferencia.tipoDocumentoID = FEManager.TITAN_ID_TIPCOM_FACTURA
            '    Else
            '        documentoReferencia.tipoDocumentoID = FEManager.TITAN_ID_TIPCOM_BOLETA
            '    End If
            '    documentoReferencia.numeroDocumento = Me.txtserfactura_act.Tag 'dtorefacturacion_.sserie_factura & "-" & dtorefacturacion_.snro_factura
            '    documentoReferencia.fechaEmision = dtorefacturacion_.sfecha_factura

            '    Dim fenote As New FENota
            '    fenote.numeroSerie = dataRowNota.Item("serie").ToString()
            '    fenote.numeroCorrelativo = dataRowNota.Item("correlativo").ToString()
            '    fenote.cliente = fecliente
            '    fenote.documentoReferencia = documentoReferencia
            '    fenote.fechaEmison = dataRowNota.Item("fechaNota")
            '    fenote.igv = Convert.ToDouble(txtigv_nc.Text)
            '    fenote.subTotal = Convert.ToDouble(txtsub_total_nc.Text)
            '    fenote.total = Convert.ToDouble(txttotal_nc.Text)
            '    fenote.tipoNota = dtOperacion.Rows(cboOperacion.SelectedIndex).Item("codigo")
            '    fenote.descripcionTipoNota = dtOperacion.Rows(cboOperacion.SelectedIndex).Item("descripcion_sunat")
            '    fenote.totalLentras = ConvercionNroEnLetras(fenote.total, Objrefacturacion.moneda)
            '    fenote.descripcionSustento = rtb.Text.Trim.ToUpper()
            '    'hlamas 12-04-2017
            '    fenote.agenciaId = dtoUSUARIOS.iIDAGENCIAS
            '    fenote.usuarioID = dtoUSUARIOS.IdLogin
            '    fenote.usuarioInsercion = dtoUSUARIOS.IdLogin
            '    fenote.usuarioModificacion = dtoUSUARIOS.IdLogin

            '    If Me.rbtCredito.Checked Then
            '        fenote.tipoVenta = FEManager.TIPO_VENTA_CREDITO
            '    Else
            '        fenote.tipoVenta = FEManager.TIPO_VENTA_ESPECIAL
            '    End If

            '    'hlamas 07-10-2016
            '    fenote.isMonedaSoles = Objrefacturacion.moneda = 1

            '    '-->Valida si solamente debe aplicar una nota de credito, mas no un nuevo comprobante
            '    If (dataTableFactura Is Nothing) Then
            '        Try
            '            '-->Aplica Solamente una nota de credito
            '            Dim result = FEManager.sendNota(fenote, True, Objrefacturacion.afectacion)
            '            If (result.isCorrect) Then
            '                Dim idNotaCredito As Long = dataRowNota.Item("notaCreditoID")
            '                Dim objFac As New ClsLbTepsa.dtoFACTURA
            '                If Me.rbtCredito.Checked Then
            '                    objFac.actualizarEmisonFE(idNotaCredito, "T_FACTURA")
            '                Else
            '                    objFac.actualizarEmisonFE(idNotaCredito, "T_FACTURA_OTRO")
            '                End If
            '            End If
            '            MessageBox.Show(result.Message, "Respuesta WSSunat", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        Catch ex As Exception
            '            MessageBox.Show("La Nota de Crédito Electrónica no pudo ser registrada, por favor comuníquese con el Area de Sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '        End Try
            '    Else
            '        Try
            '            '-->Aplica la Nota de credito y el nuevo comprobante (Factura/Boleta)
            '            '******************************
            '            Dim datarowFactura As DataRow = dataTableFactura.Rows(0)

            '            fecliente = New FECliente
            '            fecliente.tipoDocumentoID = Objrefacturacion.stipoDcoumentoIdentidad
            '            fecliente.numeroDocumento = Objrefacturacion.sruc
            '            fecliente.nombres = Objrefacturacion.srazon_social
            '            'fecliente.direccion = IIf(cboDireccionNuevo.SelectedIndex > 0, cboDireccionNuevo.Text.Trim(), Nothing)
            '            fecliente.direccion = Objrefacturacion.direccion

            '            Dim feventa As New FEVenta
            '            feventa.cliente = fecliente
            '            feventa.isCredito = False
            '            feventa.numeroSerie = datarowFactura.Item("serie").ToString()
            '            feventa.numeroCorrelativo = datarowFactura.Item("correlativo").ToString()
            '            feventa.isMonedaSoles = IIf(datarowFactura.Item("idtipo_moneda").ToString.Equals("1"), True, False)
            '            feventa.fechaEmision = datarowFactura.Item("fecha_factura")
            '            feventa.tipoComprobanteID = FEManager.TITAN_ID_TIPCOM_FACTURA
            '            feventa.opGravada = datarowFactura.Item("monto_subtotal")
            '            feventa.igv = datarowFactura.Item("monto_impuesto")
            '            feventa.total = datarowFactura.Item("total_costo")
            '            feventa.totalLetras = ConvercionNroEnLetras(feventa.total)
            '            If Me.rbtCredito.Checked Then
            '                feventa.tipoVenta = FEManager.TIPO_VENTA_CREDITO
            '            Else
            '                feventa.tipoVenta = FEManager.TIPO_VENTA_ESPECIAL
            '            End If

            '            'Este documento permite al servcio web, buscar el detalle y la informacion adicional del documento en referencia para 
            '            'copiar el detalle a este nuevo comprobante
            '            Dim documentoReferenciaVenta As New FEDocumentoReferencia
            '            documentoReferenciaVenta.tipoDocumentoID = FEManager.TITAN_ID_TIPCOM_FACTURA
            '            documentoReferenciaVenta.numeroDocumento = dtorefacturacion_.sserie_factura & "-" & dtorefacturacion_.snro_factura
            '            feventa.documentoReferencia = documentoReferenciaVenta

            '            Dim result = FEManager.sendNotaVenta(fenote, True, feventa, dtImpresora)
            '            If (result.IsCorrect) Then
            '                '-->Actualiza la nota de credito como emitido electronicamente
            '                Dim idNotaCredito As Long = dataRowNota(0)
            '                Dim objFac As New ClsLbTepsa.dtoFACTURA
            '                If Me.rbtCredito.Checked Then
            '                    objFac.actualizarEmisonFE(idNotaCredito, "T_FACTURA")
            '                Else
            '                    objFac.actualizarEmisonFE(idNotaCredito, "T_FACTURA_OTRO")
            '                End If


            '                '-->Actualiza la factura/boleta como emitido electronicamente
            '                Dim idFactura As Long = datarowFactura.Item(0)
            '                If Me.rbtCredito.Checked Then
            '                    objFac.actualizarEmisonFE(idFactura, "T_FACTURA")
            '                Else
            '                    objFac.actualizarEmisonFE(idFactura, "T_FACTURA_OTRO")
            '                End If

            '            End If
            '            MessageBox.Show(result.Message, "Respuesta WSSunat", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        Catch ex As Exception
            '            MessageBox.Show("No se pudierón Generar los comprobantes electrónicos, por favor comuníquese con el Area de Sistemas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '        End Try
            '    End If
            'End If

                If Not blnExito Then
                    MsgBox(Objrefacturacion.s_mensaje, MsgBoxStyle.Exclamation, "Refacturación")
                    Exit Sub
                Else
                    MsgBox(Objrefacturacion.s_mensaje, MsgBoxStyle.Information, "Refacturación")
                    limpia_variables()
                    SelectMenu(0)
                    ToolStripMenuItem1.Enabled = True
                    ToolStripMenuItem2.Enabled = False
                    control = 0
                    ' Recuperar datos 
                    lbusqueda = 1
                    recupera_grilla()
                End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Sub recupera_grilla()
        Try
            Objrefacturacion.lidusuario_personal = Me.cmbUsuarios.SelectedValue
            If Objrefacturacion.lidusuario_personal = 9999 Then
                Objrefacturacion.lidusuario_personal = -666
            End If
            ' 
            Objrefacturacion.sfecha_inicio = Me.dtFechaInicio.Text
            Objrefacturacion.sfecha_final = Me.dtFechaFin.Text
            '--
            Dim strNroDoc As String() = Split(txtNroSerieDoc.Text, "-")
            If strNroDoc.Length > 1 Then
                If strNroDoc(0).Length > 1 And Val(strNroDoc(1).Length) > 0 Then
                    Objrefacturacion.sserie_factura = strNroDoc(0).Trim 'RellenoRight(3, strNroDoc(0))
                    Objrefacturacion.snro_factura = RellenoRight(7, strNroDoc(1))
                Else
                    ObjVentaPasaje.Serie = "0"
                    ObjVentaPasaje.NroDoc = "0"
                End If
            End If
            '-- 
            If Objrefacturacion.fnbusqueda_refactura = True Then
                dtrefactura = Nothing
                dtrefactura = New DataTable
                dvrefactura = Nothing
                dvrefactura = New DataView
                'datahelper
                'odba.Fill(dtrefactura, Objrefacturacion.rst_busqueda_refacturacion)
                dtrefactura = Objrefacturacion.rst_busqueda_refacturacion
                dvrefactura = dtrefactura.DefaultView
                '
                fn_generagrilla()
                '
                lbNroRegistro.Text = dvrefactura.Count
                '
                If dvrefactura.Count = 0 Then
                    MsgBox("No se ha encontrado ningún resultado para esta busqueda...", MsgBoxStyle.Information, "Seguridad Sistema")
                End If
                ' bformatImage = True
            Else
                MsgBox("No se ha encontrado ningún resultado para esta busqueda...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub txtNroSerieDoc_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroSerieDoc.KeyPress
        If ValidaNumero2(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtNroSerieDoc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNroSerieDoc.Leave
        Objrefacturacion.l_control = 2
        recupera_grilla()
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Objrefacturacion.l_control = 1
        recupera_grilla()
    End Sub
    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        fn_grabar_refactura()
    End Sub
#End Region

    Private Sub txtserfactura_act_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtserfactura_act.KeyPress
        If ValidaNumero2(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtserfactura_act_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtserfactura_act.TextChanged
        b_nolee_campo = True
    End Sub
    Private Sub txtsubtotal_new_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsubtotal_new.Leave
        Try
            If Me.txtsubtotal_new.Text <= 0.0 Or Me.txtsubtotal_new.Text = "" Then
                MessageBox.Show("Debe ingresar el monto a facturar", "Refacturación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtsubtotal_new.Focus()
                Exit Sub
            End If
            '
            Me.txtigv_new.Text = FormatNumber(Me.txtsubtotal_new.Text * digv / 100, 2)
            Me.txttotal_new.Text = FormatNumber(CType(txtsubtotal_new.Text, Double) + CType(Me.txtigv_new.Text, Double), 2)
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub rbdife_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdife.CheckedChanged
        GroupBox4.Visible = False
        Me.txtsub_total_nc.Text = 0
        Me.txtigv_nc.Text = 0
        Me.txttotal_nc.Text = 0


        Me.txtsub_total_nc.ReadOnly = False
        Me.txtigv_nc.ReadOnly = False
        Me.txttotal_nc.ReadOnly = False

    End Sub

    Private Sub rbrefac_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbrefac.CheckedChanged
        GroupBox4.Visible = True
        Me.txtsub_total_nc.Text = Me.txtsub_total.Text
        Me.txtigv_nc.Text = Me.txtigv.Text
        Me.txttotal_nc.Text = Me.txttotal.Text

        Me.txtsub_total_nc.ReadOnly = True
        Me.txtigv_nc.ReadOnly = True
        Me.txttotal_nc.ReadOnly = True

    End Sub

    Private Sub txtnrofactura_actual_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnrofactura_actual.TextChanged

    End Sub

    Private Sub txtsub_total_nc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsub_total_nc.Leave
        'Try
        '    If Me.txtsub_total_nc.Text <= 0.0 Or Me.txtsub_total_nc.Text = "" Then
        '        MessageBox.Show("Debe ingresar el monto a facturar", "Refacturación", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Me.txtsub_total_nc.Focus()
        '        Exit Sub
        '    End If
        '    '
        If Val(Me.txtigv.Text) > 0 Then
            Me.txtigv_nc.Text = FormatNumber(Me.txtsub_total_nc.Text * digv / 100, 2)
            Me.txttotal_nc.Text = FormatNumber(CType(txtsub_total_nc.Text, Double) + CType(Me.txtigv_nc.Text, Double), 2)
        Else
            Me.txtigv_nc.Text = "0.00"
            Me.txttotal_nc.Text = FormatNumber(txtsub_total_nc.Text, 2)
        End If
        '    '
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
        'End Try

    End Sub

    Private Sub txtsub_total_nc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsub_total_nc.TextChanged

    End Sub

    Function ValidarAnulacion(ByVal comprobante As String, ByVal usuario As Integer, ByVal opcion As Integer) As DataTable
        Try
            Dim obj As New dtoGuia
            Return obj.ValidarAnulacion(comprobante, usuario, opcion)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Sub AnularToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnularToolStripMenuItem.Click, EliminarToolStripMenuItem.Click
        Try
            If dtGridViewControl_refactura.RowCount <= 0 Then
                MsgBox("Selecciona un elemento de la lista", MsgBoxStyle.Exclamation, "Seguridad del Sistema...")
                Exit Sub
            End If


            ObjFactura.IDTIPO_COMPROBANTE = Me.dtGridViewControl_refactura.CurrentRow.Cells("idtipo_comprobante").Value
            ObjFactura.es_refactura = Me.dtGridViewControl_refactura.CurrentRow.Cells("es_refactura").Value
            ObjFactura.IDFACTURA = Me.dtGridViewControl_refactura.CurrentRow.Cells("idfactura").Value
            'datahelper
            'ObjFactura.sp_anula_refactura(cnn)

            If MessageBox.Show("¿Está Seguro de Anular la Nota de Crédito?", "Anular", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Dim frm As New frmMotivoAnulacion
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    Dim strMotivo As String = frm.txtMotivo.Text.Trim
                    Dim strTipo As String = "07"
                    If Me.dtGridViewControl_refactura.CurrentRow.Cells("n_emife").Value = 1 Then
                        'hlamas 01-06-2016
                        'Valida si comprobante puede ser anulado
                        Dim strFecha As String = Me.dtGridViewControl_refactura.CurrentRow.Cells("fecha_refactura").Value
                        Dim strComprobante As String = Me.dtGridViewControl_refactura.CurrentRow.Cells("refactura").Value
                        Dim intPosicion As Integer = InStr(strComprobante, "-")
                        'Dim strSerie As String = IIf(iTipo = 1, "F", "B") & strComprobante.Substring(0, intPosicion - 1)
                        Dim strSerie As String = strComprobante.Substring(0, intPosicion - 1)
                        Dim strNumero As String = strComprobante.Substring(intPosicion)
                        strNumero = strNumero.PadLeft(8, "0")
                        Dim blnAnulable As Boolean = FEManager.isAvoidable(strTipo, strFecha, strSerie, strNumero, strMotivo)
                        If Not blnAnulable Then
                            Cursor = Cursors.Default
                            MessageBox.Show("El Comprobante no puede ser Anulado F.E.", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            ObjFactura.Motivo = strMotivo
                            ObjFactura.sp_anula_refactura()
                            MessageBox.Show(ObjFactura.mensaje)
                            lbusqueda = 1
                            recupera_grilla()

                            'AnularComprobante(iComprobante, strMotivo, dtoUSUARIOS.IdLogin, dtoUSUARIOS.Rol, dtoUSUARIOS.IP)
                            Cursor = Cursors.Default
                            'MessageBox.Show("La " & IIf(iTipo = 1, "Factura", "Boleta") & " Nº " & sComprobante & " ha sido Anulada.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            'Me.fnBuscarFacturas()
                        End If
                    Else
                        Cursor = Cursors.Default
                        MessageBox.Show("El Comprobante no puede ser Anulado, F.E." & Chr(13) & "Antes de Anularlo, envielo a SUNAT", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    'ObjFactura.sp_anula_refactura()
                    'MessageBox.Show(ObjFactura.mensaje)
                    'lbusqueda = 1
                    'recupera_grilla()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub


    Private Sub AnularToolStripMenuItem_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles AnularToolStripMenuItem.Paint

    End Sub


    Private Sub ContextMenuStrip1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ContextMenuStrip1.Paint
        If dtGridViewControl_refactura.RowCount <= 0 Then
            Exit Sub
        End If

        If Me.dtGridViewControl_refactura.CurrentRow.Cells("idtipo_comprobante").Value = 30 Then
            If Me.dtGridViewControl_refactura.CurrentRow.Cells("idestado_factura").Value = 2 Then
                ContextMenuStrip1.Items(0).Enabled = False
                ContextMenuStrip1.Items(1).Enabled = True
                ObjFactura.IDESTADO_FACTURA = 3
            Else
                ContextMenuStrip1.Items(0).Enabled = True
                ContextMenuStrip1.Items(1).Enabled = False
                ObjFactura.IDESTADO_FACTURA = 2
            End If
        Else
            ContextMenuStrip1.Items(0).Enabled = False
            ContextMenuStrip1.Items(1).Enabled = False
        End If


    End Sub

    Private Sub txtnro_factura_new_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnro_factura_new.TextChanged

    End Sub

    Private Sub btnTipoDocumentoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTipoDocumentoCliente.Click
        Try
            Dim FrmNuevaClasificacion As FrmTipoNotaCredito = New FrmTipoNotaCredito
            'Dim resultado As DialogResult = FrmNuevaClasificacion.ShowDialog()

            Acceso.Asignar(FrmNuevaClasificacion, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                Dim resultado As DialogResult = FrmNuevaClasificacion.ShowDialog()
                If resultado = Windows.Forms.DialogResult.OK Then
                    'datahelper
                    'ObjGeneral.sp_listar_tipo_nota_credito(Me.CBIDTIPO_NOTA_CREDI, VOCONTROLUSUARIO)
                    ObjGeneral.sp_listar_tipo_nota_credito(Me.CBIDTIPO_NOTA_CREDI)
                    Me.CBIDTIPO_NOTA_CREDI.SelectedIndex = -1
                End If
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub btnVerData_Click(sender As System.Object, e As System.EventArgs) Handles btnVerData.Click

    End Sub

    Private Sub txtnro_nota_cred_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtnro_nota_cred.TextChanged

    End Sub

    Private Sub CBIDTIPO_NOTA_CREDI_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CBIDTIPO_NOTA_CREDI.SelectedIndexChanged
        Try
            If Me.CBIDTIPO_NOTA_CREDI.SelectedValue = 1 Then 'NC por anulación
                Me.txtsub_total_nc.Text = Me.txtsub_total.Text
                Me.txtigv_nc.Text = Me.txtigv.Text
                Me.txttotal_nc.Text = Me.txttotal.Text

                Me.txtsub_total_nc.ReadOnly = True
                Me.txtigv_nc.ReadOnly = True
                Me.txttotal_nc.ReadOnly = True
            Else
                Me.txtsub_total_nc.Text = "0.00"
                Me.txtigv_nc.Text = "0.00"
                Me.txttotal_nc.Text = "0.00"

                Me.txtsub_total_nc.ReadOnly = False
                Me.txtigv_nc.ReadOnly = False
                Me.txttotal_nc.ReadOnly = False

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbtCredito_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtCredito.CheckedChanged
        b_nolee_campo = True
        Me.txtserfactura_act.Text = ""
        Me.txtnrofactura_actual.Text = ""
        Me.txtserfactura_act.Focus()
    End Sub

    Private Sub rbtEspecial_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtEspecial.CheckedChanged
        b_nolee_campo = True
        Me.txtserfactura_act.Text = ""
        Me.txtnrofactura_actual.Text = ""
        Me.txtserfactura_act.Focus()
    End Sub

    Private Sub dtGridViewControl_refactura_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtGridViewControl_refactura.CellContentClick

    End Sub

    Private Sub txtserie_nota_cred_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtserie_nota_cred.TextChanged

    End Sub

    Private Sub txtserie_factura_new_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtserie_factura_new.TextChanged

    End Sub

    Private Sub txtsubtotal_new_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsubtotal_new.TextChanged

    End Sub
End Class
