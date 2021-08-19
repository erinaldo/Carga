Public Class FrmVentaGiros
    Dim objGiros As ClsLbTepsa.dtoGiros = New ClsLbTepsa.dtoGiros
    Dim operacion_data_base As Integer = 1
    Dim tipo_bole_impre As String
    Dim tipo_factu_impre As String
    Dim dv_l_condiciones_giros As New DataView
    Dim dv_l_tipos_giros As New DataView
    Dim ObjfrmBuscarCliente As New frmBuscarCliente
    Dim DlgManteClienteContado As New frmManteClienteContado
    Dim DlgfrmManteClienteContado As New frmManteClienteContado
    'Dim rstDatos As New ADODB.Recordset
    Dim coll_iDestino As New Collection
    Public iWinDestino As New AutoCompleteStringCollection
    Private ObjProcesosVentaContado As New FrmProcesosVentaContado
    Dim bFAC_Bol As Boolean = False  '" FACTURA true    --- -Boleta False
    Dim bControl_Tarifas As Boolean = False
    Dim tarifa_Peso As Double = 0
    Dim tarifa_Volumen As Double = 0
    Dim tarifa_Articulo As Double = 0
    Dim tarifa_Sobre As Double = 0
    Dim Monto_Base As Double = 0
    Dim iControlMonto_Base As Double = 1
    Dim iControlFacturacion As Double = 0
    Dim Mro_Digitos_Ventas As Integer = 7
    Dim Mro_Digitos_SerieVentas As Integer = 3
    Dim TipoComprobante As Integer = 2
    Dim TipoComprobante_new As Integer = 14 ' 2 Modificado por Omendoza 18/06/2007
    Dim varIdCondicion As Integer = 0
    Dim iROW_ACTUAL As Integer = 0
    Dim iCOL_ACTUAL As Integer = 0
    Dim iROW As Integer = 0
    Dim iCOL As Integer = 0
    'Dim daControl_FAC As New OleDb.OleDbDataAdapter
    'Dim dtControl_FAC As New System.Data.DataTable
    Dim dvControl_FAC As System.Data.DataView
    Dim bformatImage As Boolean = False
    Dim IDGRIESTADO_REG As Integer = 27
    Dim control_venta As Boolean
    Dim CONTROL As Integer = 1
    Dim coll_Direccion_Remitente As New Collection
    Dim coll_Direccion_Destinatario As New Collection
    Dim coll_Nombres_Remitente As New Collection
    Dim coll_Nombres_Destinatario As New Collection
    Dim ObjIMPRESIONFACT_BOL As New dtoIMPRESIONFACT_BOL
    Dim xCiudadOrigen As String
    Dim xAgenciaLocal As String
    Dim xIMPRESORA As Integer
    Public bControlFiscalizacion As Boolean = False
    Private ObjReport As ClsLbTepsa.dtoFrmReport '
    Dim bIngreso As Boolean = False

    Dim bOtrasAgencias As Boolean
    Dim iAgenciaOrigen As Integer
    Dim iUnidadOrigen As Integer
    Public hnd As Long

#Region "VARIABLES DE FILTRO"

    Public iWinContacto_Remitente As New AutoCompleteStringCollection
    Public iWinDireccion_Remitente As New AutoCompleteStringCollection
    Public iWinPerosaDNI_Remite As New AutoCompleteStringCollection


    Public iWinContacto_Destinatario As New AutoCompleteStringCollection
    Public iWinDireccion_Destinatario As New AutoCompleteStringCollection
    Public iWinPerosaDNI_Destino As New AutoCompleteStringCollection

#End Region

    Private Sub FrmVentaGiros_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If bOtrasAgencias Then
            Me.cmbAgenciaOrigen.Focus()
        Else
            Me.txtiWinDestino.Focus()
        End If
    End Sub

    Private Sub FrmVentaGiros_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    'Private Sub btnEnditarOrigen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnditarOrigen.Click
    '    Try
    '        If DlgManteClienteContado.ShowDialog() = Windows.Forms.DialogResult.OK Then

    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    'End Sub

    Private Sub cmbTipoPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbidcondi_giro.SelectedIndexChanged
        Try

            ' '' ''    varIdCondicion = Int(ObjVentaGiroContado.coll_Tipo_Pago.Item(cbidcondi_giro.SelectedIndex.ToString))
            ' '' ''    If varIdCondicion = 2 Then
            ' '' ''        lbTargeta.Visible = True
            ' '' ''        cmbTargeta.Visible = True
            ' '' ''        txtNroTarjeta.Visible = True
            ' '' ''    Else
            ' '' ''        lbTargeta.Visible = False
            ' '' ''        cmbTargeta.Visible = False
            ' '' ''        txtNroTarjeta.Visible = False
            ' '' ''    End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean = True
        Dim flat As Boolean = True
        Try
            Dim var As Integer = msg.WParam.ToInt32

            If msg.WParam.ToInt32 = Keys.Enter Then


                '' ''If Me.dtGridViewBultos.Focused = True Then
                '' ''    'fnTarifario()
                '' ''    SendKeys.Send("{Tab}")
                '''''If Me.txtMontoBase.Focused = True Then

                If txtNroSerieDoc.Focused = True Then
                    objControlFacturasBol.iControl = 2
                    fnBuscarFacturas()
                ElseIf txtClienteDNIRUC.Focused = True Then
                    If txtClienteDNIRUC.Text <> "" Then
                        objControlFacturasBol.iControl = 3
                        fnBuscarFacturas()
                    Else
                        SendKeys.Send("{Tab}")
                    End If

                ElseIf txtDocCliente_Remitente.Focused = True Then
                    If txtDocCliente_Remitente.Text <> "" Then
                        CONTROL = 2
                        objGuiaEnvio.iIDPERSONA = 0
                        If fnBuscarCliente() = True Then
                            txtCliente_Destinatario.Focus()
                            txtCliente_Destinatario.SelectAll()
                        Else
                            SendKeys.Send("{Tab}")
                        End If
                    Else
                        SendKeys.Send("{Tab}")
                    End If
                    'If BuscarClientesGuia_Envio() = True Then
                    '    SendKeys.Send("{Tab}")
                    'End If
                    '' '' ''ElseIf txtContactoRemitente.Focused = True Then
                    '' '' ''    'MsgBox("Exe...")
                    '' '' ''    Dim indexof As Integer = 0
                    '' '' ''    txtDNIContacto.Text = ""
                    '' '' ''    indexof = IIf(iWinContacto_Remitente.IndexOf(txtContactoRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtContactoRemitente.Text), -1)
                    '' '' ''    ObjVentaGiroContado.v_IDPERSONA_ORIGEN = -1
                    '' '' ''    If indexof >= 0 Then
                    '' '' ''        ObjVentaGiroContado.v_IDPERSONA_ORIGEN = Int(coll_Nombres_Remitente(indexof.ToString))
                    '' '' ''        If indexof <= iWinPerosaDNI_Remite.Count Then
                    '' '' ''            txtDNIContacto.Text = iWinPerosaDNI_Remite.Item(indexof)
                    '' '' ''        End If
                    '' '' ''    End If
                    '' '' ''    SendKeys.Send("{Tab}")
                    '--------------------------------------------------------------------------
                ElseIf txtCliente_Destinatario.Focused = True Then
                    'MsgBox("Exe...")
                    Dim indexof As Integer = 0
                    'txtDNIDestinatario.Text = ""
                    indexof = IIf(iWinContacto_Destinatario.IndexOf(txtCliente_Destinatario.Text) >= 0, iWinContacto_Destinatario.IndexOf(txtCliente_Destinatario.Text), -1)
                    ObjVentagiroContado.v_IDCONTACTO_DESTINO = -1
                    If indexof >= 0 Then
                        ObjVentagiroContado.v_IDCONTACTO_DESTINO = Int(coll_Nombres_Destinatario(indexof.ToString))
                        If indexof <= iWinPerosaDNI_Destino.Count Then
                            txtDNIDestinatario.Text = iWinPerosaDNI_Destino.Item(indexof)
                        End If
                    End If
                    SendKeys.Send("{Tab}")
                Else
                    SendKeys.Send("{Tab}")
                End If

            ElseIf msg.WParam.ToInt32 = Keys.F1 Then
                cmbTipo_Entrega.Focus()
            ElseIf msg.WParam.ToInt32 = Keys.F2 Then
                txtDocCliente_Remitente.Focus()
            ElseIf msg.WParam.ToInt32 = Keys.Escape Then
                If MsgBox("Esta Seguro que Quiere cancelar esta Operacion...?", MsgBoxStyle.YesNoCancel, "Seguridad Sistema") = MsgBoxResult.Yes Then
                    fnNUEVO()
                End If
            ElseIf msg.WParam.ToInt32 = Keys.F3 Then
                'cambio tecla funcion
                If btnNuevo.Enabled Then
                    fnNUEVO()
                    SelectMenu(1)
                End If
            ElseIf msg.WParam.ToInt32 = Keys.F4 Then
                txtCliente_Destinatario.Focus()
                txtCliente_Destinatario.SelectAll()

                'txtDNIDestinatario.Focus()
                'txtDNIDestinatario.SelectAll()

            ElseIf msg.WParam.ToInt32 = Keys.F5 Then
                'cambio tecla funcion
                If btnGrabar.Enabled Then
                    Grabar()
                End If
                'If TabMante.SelectedIndex = 0 Then
                '    SendKeys.Send("{Tab}")
                '    GoTo FINAL
                'End If
                'If control_venta = True Then
                '    fnNUEVO()
                'End If
                'If TipoComprobante = 1 Then
                '    If txtDocCliente_Remitente.Text.ToString.Length = 11 Then
                '        If fnValidarRUC(txtDocCliente_Remitente.Text.ToString) = False Then
                '            MsgBox("No puede realizar esta Operacion de Factura, el Nro de Docuemnto es Invalido")
                '        End If
                '    Else
                '        MsgBox("No puede realizar esta Operacion de Factura, el Nro de Docuemnto es Invalido", MsgBoxStyle.Information, "Seguriadad Sistema")
                '    End If
                'End If
                'If txtCliente_Remitente.Text = "" Then
                '    MsgBox("No Puede Realizar esta Operacion no tiene Cliente remitente ...", MsgBoxStyle.Information, "Seguridad Sistema")
                '    txtCliente_Remitente.Focus()
                '    Return False
                'End If
                'If txtCliente_Destinatario.Text = "" Then
                '    MsgBox("No Puede Realizar esta Operacion no tiene Cliente Destinatario ...", MsgBoxStyle.Information, "Seguridad Sistema")
                '    txtCliente_Destinatario.Focus()
                '    Return False
                'End If

                ''Dim varDescuento As Integer = IIf(txtPorcernt_Descuento.Text <> "", txtPorcernt_Descuento.Text, 0)

                ''If Val(txtCosto_Total.Text) <= 0 And varDescuento <> 100 Then
                ''    MsgBox("No Puede Realizar esta Operacion no tiene monto afecto...,No Tiene el Descuento Apropiado", MsgBoxStyle.Information, "Seguridad Sistema")
                ''    Return False
                ''End If

                'If fnGrabar() = True Then
                '    ObjVentagiroContado.fnIncrementarNroDoc(TipoComprobante_new)
                '    '
                '    'If ObjVentagiroContado.fnNroDocuemnto(2) = True Then  --> Comentado por Omendoza 18/06/2007
                '    '
                '    'datahelper
                '    'If ObjVentagiroContado.fnNroDocuemnto(TipoComprobante_new) = True Then
                '    If ObjVentagiroContado.fnNroDocuemnto2(TipoComprobante_new) = True Then
                '        txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentagiroContado.Serie)
                '        txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentagiroContado.NroDoc)
                '    Else
                '        MsgBox("No podrá realizar está operación el Nº de giro no está configurado")
                '    End If
                'End If
            ElseIf msg.WParam.ToInt32 = Keys.F7 Then
                'dtGridViewBultos.Focus()
                'dtGridViewBultos.CurrentCell = dtGridViewBultos.Rows(0).Cells(2)
                'dtGridViewBultos.Rows(0).Cells(2).Selected = True
            ElseIf msg.WParam.ToInt32 = Keys.F6 Then
                'cambio tecla funcion
                If btnEdicion.Enabled Then
                    Edicion()
                End If
                'If txtDocCliente_Remitente.Focused = True Or txtCliente_Remitente.Focused = True Then
                '    If txtCliente_Remitente.Text <> "" Then
                '        If fnMantenimienteCliente(1, txtDocCliente_Remitente, txtCliente_Remitente, txtDireccionRemitente, 1, 1) = True Then

                '        End If
                '    End If
                'End If

                '' '' ''If txtContactoRemitente.Focused = True Or txtDNIContacto.Focused = True Then
                '' '' ''    If txtContactoRemitente.Text <> "" Then
                '' '' ''        If fnMantenimienteCliente(2, txtDNIContacto, txtContactoRemitente, txtDireccionRemitente, 1, 2) = True Then

                '' '' ''        End If
                '' '' ''    End If
                '' '' ''End If
                'If txtCliente_Destinatario.Focused = True Or txtDNIDestinatario.Focused = True Then
                '    If txtCliente_Destinatario.Text <> "" Then
                '        If fnMantenimienteCliente(3, txtDNIDestinatario, txtCliente_Destinatario, txtDireccionDestinatario, 1, 2) = True Then

                '        End If
                '    End If
                'End If
                ''    txtCantidad_Peso.Focus()
                ''txtCantidad_Peso.SelectAll()

            ElseIf msg.WParam.ToInt32 = Keys.F8 Then
                txtPorcernt_Descuento.Focus()
                txtPorcernt_Descuento.SelectAll()
            ElseIf msg.WParam.ToInt32 = Keys.F9 Then
                'txtNroDocFACBOL.Focus()
                'txtNroDocFACBOL.SelectAll()

                txtCosto_Total.Focus()
                txtCosto_Total.SelectAll()
            ElseIf msg.WParam.ToInt32 = Keys.F10 Then
                txtiWinDestino.Focus()
                txtiWinDestino.SelectAll()
            ElseIf msg.WParam.ToInt32 = Keys.F11 Then
                cbidcondi_giro.Focus()
                cbidcondi_giro.SelectAll()
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

    Public Function fnLoadGrid() As Boolean
        Try
            With dtGridViewControl_FACBOL
                '    .AllowUserToAddRows = False
                '    .AllowUserToDeleteRows = False
                '    .AllowUserToOrderColumns = True
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                '    .AutoGenerateColumns = False
                '    '.DataSource = dtable_Lista_Control_Comprobante
                '    .VirtualMode = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 10
                .AllowUserToAddRows = False
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            Dim idEstadoImage As New DataGridViewImageColumn
            With idEstadoImage
                .DataPropertyName = "imagen"
                .HeaderText = "CL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DisplayIndex = 0
                .Visible = True
                '.ValuesAreIcons = True
                '.InheritedStyle.BackColor = Color.Transparent
                .Image = bmActivo
            End With
            dtGridViewControl_FACBOL.Columns.Add(idEstadoImage)

            Dim colID As New DataGridViewTextBoxColumn
            With colID
                .DisplayIndex = 1
                .DataPropertyName = "Idfactura"
                .HeaderText = "Idfactura"
                .Name = "idfactura"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(colID)

            Dim colIDESTADO As New DataGridViewTextBoxColumn
            With colIDESTADO
                .DisplayIndex = 2
                .DataPropertyName = "Idestado_Factura"
                .HeaderText = "Idestado_Factura"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(colIDESTADO)


            Dim FAC_BOL As New DataGridViewTextBoxColumn
            With FAC_BOL
                .DisplayIndex = 3
                .DataPropertyName = "FAC_BOL"
                .HeaderText = "FAC/BOL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(FAC_BOL)

            Dim TIPO As New DataGridViewTextBoxColumn
            With TIPO
                .DisplayIndex = 4
                .DataPropertyName = "Tipo"
                .HeaderText = "TIPO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(TIPO)

            Dim Fecha_Factura As New DataGridViewTextBoxColumn
            With Fecha_Factura
                .DisplayIndex = 5
                .DataPropertyName = "Fecha_Factura"
                .HeaderText = "FECHA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Fecha_Factura)


            Dim Origen As New DataGridViewTextBoxColumn
            With Origen
                .DisplayIndex = 6
                .DataPropertyName = "Origen"
                .HeaderText = "ORIGEN"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Origen)

            Dim Destino As New DataGridViewTextBoxColumn
            With Destino
                .DisplayIndex = 7
                .DataPropertyName = "Destino"
                .HeaderText = "DESTNO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Destino)
            '
            ' Comentado por Omendoza - 18/06/2007
            '
            'Dim Trancito As New DataGridViewTextBoxColumn
            'With Trancito
            '    .DisplayIndex = 8
            '    .DataPropertyName = "Trancito"
            '    .HeaderText = "TRANSITO"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .ReadOnly = True
            '    .Visible = True
            'End With
            'dtGridViewControl_FACBOL.Columns.Add(Trancito)

            Dim DNI_RUC As New DataGridViewTextBoxColumn
            With DNI_RUC
                .DisplayIndex = 8
                .DataPropertyName = "DNI_RUC"
                .Name = "DNI_RUC"
                .HeaderText = "DNI/RUC"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(DNI_RUC)

            Dim razon_social As New DataGridViewTextBoxColumn
            With razon_social
                .DisplayIndex = 9
                .DataPropertyName = "razon_social"
                .Name = "razon_social"
                .HeaderText = "RAZON SOCIAL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(razon_social)


            Dim Tipo_Pago As New DataGridViewTextBoxColumn
            With Tipo_Pago
                .DisplayIndex = 10
                .DataPropertyName = "Tipo_Pago"
                .HeaderText = "TIPO PAGO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Tipo_Pago)


            Dim forma_pago As New DataGridViewTextBoxColumn
            With forma_pago
                .DisplayIndex = 11
                .DataPropertyName = "forma_pago"
                .HeaderText = "FORMA PAGO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(forma_pago)



            Dim cantidad As New DataGridViewTextBoxColumn
            With cantidad
                .DisplayIndex = 12
                .DataPropertyName = "cantidad"
                .HeaderText = "CANTIDAD"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(cantidad)

            Dim Total_Peso As New DataGridViewTextBoxColumn
            With Total_Peso
                .DisplayIndex = 13
                .DataPropertyName = "Total_Peso"
                .HeaderText = "TOT. PESO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(Total_Peso)

            Dim Total_Volumen As New DataGridViewTextBoxColumn
            With Total_Volumen
                .DisplayIndex = 14
                .DataPropertyName = "Total_Volumen"
                .HeaderText = "TOT. VOL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(Total_Volumen)

            Dim Precio_x_Peso As New DataGridViewTextBoxColumn
            With Precio_x_Peso
                .DisplayIndex = 15
                .DataPropertyName = "Precio_x_Peso"
                .HeaderText = "P. PESO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(Precio_x_Peso)

            Dim Precio_x_Volumen As New DataGridViewTextBoxColumn
            With Precio_x_Volumen
                .DisplayIndex = 16
                .DataPropertyName = "Precio_x_Volumen"
                .HeaderText = "P. VOL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(Precio_x_Volumen)

            Dim Precio_x_Sobre As New DataGridViewTextBoxColumn
            With Precio_x_Sobre
                .DisplayIndex = 17
                .DataPropertyName = "Precio_x_Sobre"
                .HeaderText = "P. SOBRE"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(Precio_x_Sobre)

            Dim Monto_Base As New DataGridViewTextBoxColumn
            With Monto_Base
                .DisplayIndex = 18
                .DataPropertyName = "Monto_Base"
                .HeaderText = "BASE"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(Monto_Base)

            Dim Porcent_Descuento As New DataGridViewTextBoxColumn
            With Porcent_Descuento
                .DisplayIndex = 19
                .DataPropertyName = "Porcent_Descuento"
                .HeaderText = "% DESC"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(Porcent_Descuento)


            Dim Monto_Impuesto As New DataGridViewTextBoxColumn
            With Monto_Impuesto
                .DisplayIndex = 20
                .DataPropertyName = "Monto_Impuesto"
                .HeaderText = "IGV"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(Monto_Impuesto)

            Dim Monto_Sub_Total As New DataGridViewTextBoxColumn
            With Monto_Sub_Total
                .DisplayIndex = 21
                .DataPropertyName = "Monto_Sub_Total"
                .HeaderText = "SUB TOTAL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(Monto_Sub_Total)
            'dtGridViewControl_FACBOL.Rows(0).Visible = False

            Dim Total_Costo As New DataGridViewTextBoxColumn
            With Total_Costo
                .DisplayIndex = 22
                .DataPropertyName = "Total_Costo"
                .HeaderText = "TOTAL COSTO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Total_Costo)

            Dim login_creacion As New DataGridViewTextBoxColumn
            With login_creacion
                .DisplayIndex = 23
                .DataPropertyName = "login_creacion"
                .HeaderText = "USUARIO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(login_creacion)

            Dim Estado_Doc As New DataGridViewTextBoxColumn
            With Estado_Doc
                .DisplayIndex = 24
                .DataPropertyName = "Estado_Doc"
                .HeaderText = "ESTADO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Estado_Doc)

            Dim Estado_Envio As New DataGridViewTextBoxColumn
            With Estado_Envio
                .DisplayIndex = 25
                .DataPropertyName = "Estado_Envio"
                .HeaderText = "EST. ENVIO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Estado_Envio)

            Dim Idestado_Factura As New DataGridViewTextBoxColumn
            With Idestado_Factura
                .DisplayIndex = 26
                .DataPropertyName = "Idestado_Factura"
                .Name = "Idestado_Factura"
                .HeaderText = "EST. ENVIO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(Idestado_Factura)

            Dim monto_girado As New DataGridViewTextBoxColumn
            With monto_girado
                .DisplayIndex = 27
                .DataPropertyName = "monto_girado"
                .HeaderText = "Girado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(monto_girado)


            Dim monto_descuento As New DataGridViewTextBoxColumn
            With monto_descuento
                .DisplayIndex = 28
                .DataPropertyName = "monto_descuento"
                .HeaderText = "Descuento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(monto_descuento)





            ' '' '' ''With dtGridViewBultos
            ' '' '' ''    '.Dock = DockStyle.Fill
            ' '' '' ''    .AllowUserToAddRows = False
            ' '' '' ''    .AllowUserToDeleteRows = False
            ' '' '' ''    .AllowUserToOrderColumns = False
            ' '' '' ''    '.RowsDefaultCellStyle.WrapMode =
            ' '' '' ''    .AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
            ' '' '' ''    .BackgroundColor = SystemColors.Window
            ' '' '' ''    .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
            ' '' '' ''    .ReadOnly = False
            ' '' '' ''    .AutoGenerateColumns = False
            ' '' '' ''    '.DataSource = dtable_Lista_Control_Comprobante
            ' '' '' ''    .VirtualMode = False
            ' '' '' ''    .SelectionMode = DataGridViewSelectionMode.CellSelect
            ' '' '' ''    .RowHeadersWidth = 14
            ' '' '' ''    .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
            ' '' '' ''    .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            ' '' '' ''    .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            ' '' '' ''    .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            ' '' '' ''End With
            ' '' '' ''Dim col As New DataGridViewTextBoxColumn
            ' '' '' ''With col
            ' '' '' ''    .DisplayIndex = 0
            ' '' '' ''    .DataPropertyName = "var"
            ' '' '' ''    .HeaderText = "ID"
            ' '' '' ''    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            ' '' '' ''    .DefaultCellStyle.ForeColor = Color.Black
            ' '' '' ''    .ReadOnly = True
            ' '' '' ''    .Visible = False
            ' '' '' ''End With
            ' '' '' ''dtGridViewBultos.Columns.Add(col)
            ' '' '' ''Dim col0 As New DataGridViewTextBoxColumn
            ' '' '' ''With col0
            ' '' '' ''    .DisplayIndex = 1
            ' '' '' ''    .DataPropertyName = "TIPO PROCESO"
            ' '' '' ''    .HeaderText = "TIPO"
            ' '' '' ''    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            ' '' '' ''    .DefaultCellStyle.ForeColor = Color.Black
            ' '' '' ''    .ReadOnly = True
            ' '' '' ''    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' '' '' ''End With
            ' '' '' ''dtGridViewBultos.Columns.Add(col0)

            ' '' '' ''Dim col2 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            '' '' '' ''Dim col2 As New DataGridViewTextBoxColumn
            ' '' '' ''With col2
            ' '' '' ''    .DisplayIndex = 2
            ' '' '' ''    .DataPropertyName = "Cantidad"
            ' '' '' ''    .HeaderText = "PIEZAS"
            ' '' '' ''    .DefaultCellStyle.ForeColor = Color.Black
            ' '' '' ''    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            ' '' '' ''    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' '' '' ''    .Mask = "####0"
            ' '' '' ''    .ReadOnly = False
            ' '' '' ''End With
            ' '' '' ''dtGridViewBultos.Columns.Add(col2)

            ' '' '' ''Dim col01 As New DataGridViewTextBoxColumn
            ' '' '' ''With col01
            ' '' '' ''    .DisplayIndex = 3
            ' '' '' ''    .DataPropertyName = "DESCRIPCION"
            ' '' '' ''    .HeaderText = "DESCRIPCION"
            ' '' '' ''    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            ' '' '' ''    .DefaultCellStyle.ForeColor = Color.Black
            ' '' '' ''    .ReadOnly = True
            ' '' '' ''    .Visible = False
            ' '' '' ''    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' '' '' ''End With
            ' '' '' ''dtGridViewBultos.Columns.Add(col01)

            '' '' '' ''Dim col1 As New DataGridViewTextBoxColumn
            ' '' '' ''Dim col1 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            '' '' '' ''Dim col1 As New DataGridViewTextBoxColumn
            ' '' '' ''With col1
            ' '' '' ''    .DisplayIndex = 4
            ' '' '' ''    .DataPropertyName = "PESO_VOLUMEN"
            ' '' '' ''    .HeaderText = "PESO/VOLUMEN"
            ' '' '' ''    .DefaultCellStyle.ForeColor = Color.Black
            ' '' '' ''    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            ' '' '' ''    '.Mask = "####,###,###.000"
            ' '' '' ''    .DefaultCellStyle.Format = "####,###,###.00"
            ' '' '' ''    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' '' '' ''    .ReadOnly = False
            ' '' '' ''End With
            ' '' '' ''dtGridViewBultos.Columns.Add(col1)
            '' '' '' ''-------------------------------------------------------------------------------
            ' '' '' ''Dim col31 As New DataGridViewTextBoxColumn
            ' '' '' ''With col31
            ' '' '' ''    .DisplayIndex = 5
            ' '' '' ''    .DataPropertyName = "COSTO"
            ' '' '' ''    .HeaderText = "COSTO"
            ' '' '' ''    .ReadOnly = True
            ' '' '' ''    .DefaultCellStyle.ForeColor = Color.Black
            ' '' '' ''    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' '' '' ''    '.Mask = "99999999.999" 'Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
            ' '' '' ''    .DefaultCellStyle.Format = "##,###,###.00"
            ' '' '' ''    .DefaultCellStyle.NullValue = "0.00"
            ' '' '' ''    '.DefaultCellStyle.NullValue = Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
            ' '' '' ''    .Width = 100
            ' '' '' ''End With
            ' '' '' ''dtGridViewBultos.Columns.Add(col31)
            '' '' '' ''-------------------------------------------------------------------------

            '' '' '' ''Dim col3 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            ' '' '' ''Dim col3 As New DataGridViewTextBoxColumn
            ' '' '' ''With col3
            ' '' '' ''    .DisplayIndex = 6
            ' '' '' ''    .DataPropertyName = "DESCUENTO"
            ' '' '' ''    .HeaderText = "DESCUENTO"
            ' '' '' ''    .ReadOnly = True
            ' '' '' ''    .DefaultCellStyle.ForeColor = Color.Black
            ' '' '' ''    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' '' '' ''    '.Mask = "99999999.999" 'Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
            ' '' '' ''    .DefaultCellStyle.Format = "##,###,###.00"
            ' '' '' ''    .DefaultCellStyle.NullValue = "0.00"
            ' '' '' ''    '.DefaultCellStyle.NullValue = Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
            ' '' '' ''    .Width = 100
            ' '' '' ''End With
            ' '' '' ''dtGridViewBultos.Columns.Add(col3)

            ' '' '' ''Dim col4 As New DataGridViewTextBoxColumn
            ' '' '' ''With col4
            ' '' '' ''    .DisplayIndex = 7
            ' '' '' ''    .DataPropertyName = "NETO"
            ' '' '' ''    .HeaderText = "SUB_NETO"
            ' '' '' ''    .ReadOnly = True
            ' '' '' ''    .DefaultCellStyle.ForeColor = Color.Black
            ' '' '' ''    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' '' '' ''    '.Mask = "99999999.999" 'Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
            ' '' '' ''    .DefaultCellStyle.Format = "##,###,###.00"
            ' '' '' ''    .DefaultCellStyle.NullValue = "0.00"
            ' '' '' ''    '.DefaultCellStyle.NullValue = Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
            ' '' '' ''    .Width = 100
            ' '' '' ''End With
            ' '' '' ''dtGridViewBultos.Columns.Add(col4)

            ' '' '' ''Dim row0 As String() = {"", "PESO", "", "BULTOS", "", "0.00", "0.00", "0.00"}
            ' '' '' ''dtGridViewBultos.Rows().Add(row0)
            ' '' '' ''Dim row1 As String() = {"", "VOLUMEN", "", "BULTOS", "", "0.00", "0.00", "0.00"}
            ' '' '' ''dtGridViewBultos.Rows().Add(row1)
            ' '' '' ''Dim row2 As String() = {"", "SOBRE", "", "", "", "0.00", "0.00", "0.00"}
            ' '' '' ''dtGridViewBultos.Rows().Add(row2)
            ' '' '' ''Dim row3 As String() = {"", "BASE", "", "", "", "0.00", "0.00", "0.00"}
            ' '' '' ''dtGridViewBultos.Rows().Add(row3)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Function

    ' '' ''Private Sub cmbFACBOL_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFACBOL.SelectedIndexChanged, cmbAgenciaVenta.SelectedIndexChanged
    ' '' ''    Try
    ' '' ''        lbFactBoleta.Text = "BOLETA VENTA"
    ' '' ''        TipoComprobante = 2
    ' '' ''    Catch ex As Exception
    ' '' ''        lbFactBoleta.Text = "ERROR...."
    ' '' ''    End Try
    ' '' ''End Sub
    Private Sub numericTextboxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClienteDNIRUC.KeyPress, txtDNIDestinatario.KeyPress, txtTelefonoDestinatario.KeyPress, txtClienteDNIRUC.KeyPress, txtSERIE.KeyPress, txtNroDocFACBOL.KeyPress, txtDocCliente_Remitente.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
                'ElseIf e.KeyChar = "." Then
                'If Not (tb.SelectedText = "." Or IsNumeric(tb.Text & e.KeyChar)) Then
                'e.Handled = True
                'End If
                'ElseIf e.KeyChar = "-" Then
                'If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
                'e.Handled = True
                'End If
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub txtiWinDestino_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtiWinDestino.Validating
        Try
            Dim idUnidadAgencias As Integer = iWinDestino.IndexOf(txtiWinDestino.Text)
            If idUnidadAgencias >= 0 Then
                idUnidadAgencias = Int(coll_iDestino.Item(idUnidadAgencias.ToString))

                If idUnidadAgencias > 0 Then
                    'datahelper
                    'ObjVentagiroContado.fnGetAgencias(idUnidadAgencias)
                    ObjVentagiroContado.fnGetAgencias_dt(idUnidadAgencias)
                    'datahelper
                    'ModuUtil.LlenarComboIDs(ObjVentaGiroContado.rstVarAgencias, cmbAgenciaVenta, ObjVentaGiroContado.coll_AgenciasVenta, Int(ObjVentaGiroContado.rstVarAgencias.Fields(0).Value))
                    ModuUtil.LlenarCombo2(ObjVentagiroContado.rstVarAgencias_dt, cmbAgenciaVenta, ObjVentagiroContado.coll_AgenciasVenta, Int(ObjVentagiroContado.rstVarAgencias_dt.Rows(0).Item(0)))
                    fnTarifario()
                Else
                    cmbAgenciaVenta.Controls.Clear()
                    cmbAgenciaVenta.Items.Clear()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub txtDocCliente_Remitente_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDocCliente_Remitente.Validating
        ' '' ''fnVALIDARDOCUMENTOS()
    End Sub
    '' '' ''Private Function fnVALIDARDOCUMENTOS() As Boolean
    '' '' ''    Try
    '' '' ''        If txtDocCliente_Remitente.Text.Length = 11 Then
    '' '' ''            If fnValidarRUC(txtDocCliente_Remitente.Text.ToString) Then
    '' '' ''                lbFactBoleta.Text = "FACTURA"
    '' '' ''                bFAC_Bol = True
    '' '' ''                TipoComprobante = 1
    '' '' ''                fnTarifario()
    '' '' ''                If ObjVentaGiroContado.fnNroDocuemnto(TipoComprobante) = True Then
    '' '' ''                    txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaGiroContado.Serie)
    '' '' ''                    txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaGiroContado.NroDoc)
    '' '' ''                Else
    '' '' ''                    MsgBox("No podra Realizar esta Operacion El Nro de Factura/Boleta no esta configurado")
    '' '' ''                End If
    '' '' ''            Else
    '' '' ''                MsgBox("El Valor del Nro de RUC es Invalido para la SUNAT, Revice su Nro de RUC", MsgBoxStyle.Information, "Seguridad Sistema")
    '' '' ''                fnTarifario()
    '' '' ''                lbFactBoleta.Text = "BOLETA VENTA"
    '' '' ''                bFAC_Bol = False
    '' '' ''                txtDocCliente_Remitente.SelectAll()
    '' '' ''                txtDocCliente_Remitente.Focus()
    '' '' ''                TipoComprobante = 2
    '' '' ''                If ObjVentaGiroContado.fnNroDocuemnto(TipoComprobante) = True Then
    '' '' ''                    txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaGiroContado.Serie)
    '' '' ''                    txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaGiroContado.NroDoc)
    '' '' ''                Else
    '' '' ''                    MsgBox("No podra Realizar esta Operacion El Nro de Factura/Boleta no esta configurado")
    '' '' ''                End If
    '' '' ''            End If

    '' '' ''            ' '' ''ElseIf txtDocCliente_Remitente.Text.Length = 8 Then
    '' '' ''            ' '' ''    fnTarifario()
    '' '' ''            ' '' ''    lbFactBoleta.Text = "BOLETA VENTA"
    '' '' ''            ' '' ''    bFAC_Bol = False
    '' '' ''            ' '' ''    TipoComprobante = 2
    '' '' ''            ' '' ''    If ObjVentaGiroContado.fnNroDocuemnto(TipoComprobante) = True Then
    '' '' ''            ' '' ''        txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaGiroContado.Serie)
    '' '' ''            ' '' ''        txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaGiroContado.NroDoc)
    '' '' ''            ' '' ''    Else
    '' '' ''            ' '' ''        MsgBox("No podra Realizar esta Operacion El Nro de Factura/Boleta no esta configurado")
    '' '' ''            ' '' ''    End If
    '' '' ''            ' '' ''Else
    '' '' ''            ' '' ''    MsgBox("El Valor del Nro de Documento es Invalido para la SUNAT ", MsgBoxStyle.Information, "Seguridad Sistema")
    '' '' ''            ' '' ''    lbFactBoleta.Text = "BOLETA VENTA"
    '' '' ''            ' '' ''    fnTarifario()
    '' '' ''            ' '' ''    'txtDocCliente_Remitente.Text = ""
    '' '' ''            ' '' ''    'txtDocCliente_Remitente.Focus()
    '' '' ''            ' '' ''    bFAC_Bol = False
    '' '' ''            ' '' ''    TipoComprobante = 2
    '' '' ''            ' '' ''    If ObjVentaGiroContado.fnNroDocuemnto(TipoComprobante) = True Then
    '' '' ''            ' '' ''        txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaGiroContado.Serie)
    '' '' ''            ' '' ''        txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaGiroContado.NroDoc)
    '' '' ''            ' '' ''    Else
    '' '' ''            ' '' ''        MsgBox("No podra Realizar esta Operacion El Nro de Factura/Boleta no esta configurado")
    '' '' ''            ' '' ''    End If
    '' '' ''            ' '' ''End If
    '' '' ''    Catch ex As Exception

    '' '' ''    End Try
    '' '' ''    Return False
    '' '' ''End Function
    Private Sub DatosPersonalesboxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente_Remitente.KeyPress, txtCliente_Destinatario.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            If Not IsNumeric(e.KeyChar) And Char.IsLetter(e.KeyChar) Then
                e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
            ElseIf e.KeyChar = " " Then
                If tb.Text.Substring(tb.Text.Length() - 1) = " " Then
                    e.Handled = True
                Else
                    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "." Then
                If tb.Text.Substring(tb.Text.Length() - 1) = "." Then
                    e.Handled = True
                Else
                    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "," Then
                If tb.Text.Substring(tb.Text.Length() - 1) = "," Then
                    e.Handled = True
                Else
                    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "@" Then
                If tb.Text.Substring(tb.Text.Length() - 1) = "@" Then
                    e.Handled = True
                Else
                    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "&" Then
                If tb.Text.Substring(tb.Text.Length() - 1) = "&" Then
                    e.Handled = True
                Else
                    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "-" Then
                If tb.Text.Substring(tb.Text.Length() - 1) = "-" Then
                    e.Handled = True
                Else
                    e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "'" Then
                e.Handled = True
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub
    Public Function fnNUEVO() As Boolean
        Try
            Me.TxtMontoGirar.Text = ""
            txtiWinDestino.Text = ""
            txtNroDocFACBOL.Text = ""
            txtDocCliente_Remitente.Text = ""
            txtCliente_Remitente.Text = ""
            txtDireccionRemitente.Text = ""
            txtPorcernt_Descuento.Text = ""
            txtDNIDestinatario.Text = ""
            txtCliente_Destinatario.Text = ""
            txtDireccionDestinatario.Text = ""
            txtTelefonoDestinatario.Text = ""
            txtCosto_Total.Text = ""

            txtMemo.Visible = False
            lbMemo.Visible = False
            txtMemo.Text = ""

            'datahelper
            'ObjVentaGiroContado.cur_t_Tipo_Entrega.MoveFirst()
            'ModuUtil.LlenarComboIDs(ObjVentagiroContado.cur_t_Tipo_Entrega, cmbTipo_Entrega, ObjVentagiroContado.coll_t_Tipo_Entrega, 1)
            'ObjVentaGiroContado.cur_T_TARJETAS.MoveFirst()
            'ModuUtil.LlenarComboIDs(ObjVentaGiroContado.cur_T_TARJETAS, cmbTargeta, ObjVentaGiroContado.coll_T_TARJETAS, 1)

            ModuUtil.LlenarCombo2(ObjVentagiroContado.cur_t_Tipo_Entrega_dt, cmbTipo_Entrega, ObjVentagiroContado.coll_t_Tipo_Entrega, 1)
            ModuUtil.LlenarCombo2(ObjVentagiroContado.cur_T_TARJETAS_dt, cmbTargeta, ObjVentagiroContado.coll_T_TARJETAS, 1)

            cmbAgenciaVenta.DropDownStyle = ComboBoxStyle.DropDownList
            cmbAgenciaVenta.Controls.Clear()
            cmbAgenciaVenta.Items.Clear()
            Me.cbidcondi_giro.SelectedValue = "SEFE"
            Me.cbidtipo_giro.SelectedValue = "NORM"
            '' '' ''lbFactBoleta.Text = "..."
            txtiWinDestino.Focus()
            fnEnableStadoControl(False)

            lbTargeta.Visible = False
            cmbTargeta.Visible = False
            '''''lbNrotarjeta.Visible = False
            '''''txtNroTarjeta.Visible = False
            Me.Text = "VENTAS CARGA....." & dtoUSUARIOS.iLOGIN & " Ag. Nro " & dtoUSUARIOS.m_iIdAgencia & " [ " & dtoUSUARIOS.m_iNombreAgencia & " ] ** [ " & dtoUSUARIOS.m_iNombreUnidadAgencia & " ]"
            ObjVentagiroContado.fnClearOBJ()


            '' '' ''lbFactBoleta.Text = "BOLETA VENTA"
            bFAC_Bol = False
            'TipoComprobante = 2
            'If ObjVentagiroContado.fnNroDocuemnto(TipoComprobante) = True Then  --> Comentado por Omendoza 18/06/2007
            'datahelper
            'If ObjVentagiroContado.fnNroDocuemnto(TipoComprobante_new) = True Then
            If ObjVentagiroContado.fnNroDocuemnto2(TipoComprobante_new) = True Then
                If IsDBNull(ObjVentagiroContado.Serie) = True Or RellenoRight(Mro_Digitos_SerieVentas, ObjVentagiroContado.Serie) = "000" Then
                    MsgBox("No ha configurado la serie del giro")
                    Me.Close()
                    Exit Function
                End If
                '---> 
                txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentagiroContado.Serie)
                txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentagiroContado.NroDoc)
            Else
                MsgBox("No podrá realizar está operación, el Nº de giro no está configurado")
            End If
            '
            operacion_data_base = 1
            '
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Function
    Private Function RellenoRight(ByVal Nro As Integer, ByVal texto As String) As String
        Dim cCount As Integer = Len(texto)
        Dim sNewCadena As String = texto
        If Nro = cCount Then
            Return texto
        End If
        Try
            Dim i As Integer
            For i = 1 To Nro - cCount
                sNewCadena = "0" & sNewCadena
            Next
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return sNewCadena
    End Function
    Public Function fnGrabar() As Boolean
        Dim validar As ClsLbTepsa.dtoValida = New ClsLbTepsa.dtoValida

        If validar.NO_BLANCO(Me.txtSERIE, Me) = False Then Exit Function
        'If validar.NUMERO_NO_NEGATIVO(Me.txtSERIE, Me) = False Then Exit Function

        If validar.NO_BLANCO(Me.txtNroDocFACBOL, Me) = False Then Exit Function
        'If validar.NUMERO_NO_NEGATIVO(Me.txtNroDocFACBOL, Me) = False Then Exit Function

        If validar.NO_BLANCO(Me.txtPorcernt_Descuento, Me) = False Then Exit Function
        If validar.NUMERO_NO_NEGATIVO(Me.txtPorcernt_Descuento, Me) = False Then Exit Function

        If validar.NO_BLANCO(Me.TxtMontoGirar, Me) = False Then Exit Function
        If validar.NUMERO_NO_NEGATIVO(Me.TxtMontoGirar, Me) = False Then Exit Function

        If validar.NO_BLANCO(Me.txtCosto_Total, Me) = False Then Exit Function
        If validar.NUMERO_NO_NEGATIVO(Me.txtCosto_Total, Me) = False Then Exit Function

        If Not IsDate(Me.txtFecha.Text) Then
            MsgBox("La fecha no es valida", MsgBoxStyle.Information)
            Me.txtFecha.Focus()
            Exit Function
        End If

        Dim flat As Boolean = False
        Try
            If bOtrasAgencias Then
                ObjVentagiroContado.v_IDUNIDAD_ORIGEN = iUnidadOrigen
            Else
                ObjVentagiroContado.v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad
            End If
            If Val(txtPorcernt_Descuento.Text) > 0 Then
                If Me.txtMemo.Text = "" Then
                    MsgBox("Debe tener autorizacion...", MsgBoxStyle.Information, "Seguridad Sistema")
                    ErrorProvider.SetError(txtMemo, "Escriba Nombre que Autoriza el Descuento....")
                    txtMemo.Focus()
                    txtMemo.SelectAll()
                    Return False
                End If
            End If
            With objGiros
                .OPE = operacion_data_base
                Try
                    .IDFACTURA = dtGridViewControl_FACBOL.Rows(dtGridViewControl_FACBOL.SelectedRows.Item(0).Index).Cells("idfactura").Value
                Catch ex As Exception
                    .IDFACTURA = 0
                End Try
                'If fnTarifario() = False Then
                'MsgBox("Error de Carga de Tarifa", MsgBoxStyle.Information, "Seguridad Sistema")
                'Return False
                'End If

                '' '' ''If TipoComprobante = 1 Or TipoComprobante = 2 Then
                '' '' ''    ObjVentaGiroContado.v_IDTIPO_COMPROBANTE = TipoComprobante
                '' '' ''Else
                '' '' ''    MsgBox("Debe definir un Tipo de Comprobante...", MsgBoxStyle.Information, "Seguridad Sistema")
                '' '' ''    Return False
                '' '' ''End If
                .IDTIPO_COMPROBANTE = 2
                ''''''ObjVentaGiroContado.v_SERIE_FACTURA = Int(txtSERIE.Text)
                .SERIE_FACTURA = Int(txtSERIE.Text)

                '' '' ''If txtCliente_Remitente.Text <> "" Then
                '' '' ''    ObjVentaGiroContado.v_NRO_FACTURA = RellenoRight(Mro_Digitos_Ventas, txtNroDocFACBOL.Text)
                '' '' ''    txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, txtNroDocFACBOL.Text)
                '' '' ''End If
                .NRO_FACTURA = txtNroDocFACBOL.Text

                '' '' ''ObjVentaGiroContado.v_FECHA_FACTURA = dtoUSUARIOS.m_sFecha
                '' '' ''ObjVentaGiroContado.v_FECHA_FACTURA = Format("DD/MM/YYYY", Me.txtFecha.Text)
                .FECHA_FACTURA = Me.txtFecha.Text

                ' '' '' ''ObjVentaGiroContado.v_IDTIPO_PAGO = Int(ObjVentaGiroContado.coll_Tipo_Pago(cbidcondi_giro.SelectedIndex.ToString))
                ' '' '' ''ObjVentaGiroContado.v_IDFORMA_PAGO = Int(ObjVentaGiroContado.coll_t_Forma_Pago(cbidtipo_giro.SelectedIndex.ToString))
                .IDFORMA_PAGO = 1
                .IDTIPO_PAGO = 1
                .IDTIPO_MONEDA = 1

                'If ObjVentaGiroContado.v_IDFORMA_PAGO = 3 Then
                '    If fnValidarRUC(txtDocCliente_Remitente.Text.ToString) = False Then
                '        ErrorProvider.SetError(txtDocCliente_Remitente, "Debe Ingresar Un RUC VALIDO")
                '        txtDocCliente_Remitente.Focus()
                '        txtDocCliente_Remitente.SelectAll()
                '        Return False
                '    End If

                '    If fnValidarRUC(txtDNIDestinatario.Text.ToString) = False Then
                '        ErrorProvider.SetError(txtDNIDestinatario, "Debe Ingresar Un RUC VALIDO")
                '        txtDNIDestinatario.Focus()
                '        txtDNIDestinatario.SelectAll()
                '        Return False
                '    End If
                'End If

                '''''ObjVentaGiroContado.v_IDTIPO_ENTREGA = Int(ObjVentaGiroContado.coll_t_Tipo_Entrega(cmbTipo_Entrega.SelectedIndex.ToString))
                .IDTIPO_ENTREGA = Int(ObjVentagiroContado.coll_t_Tipo_Entrega(cmbTipo_Entrega.SelectedIndex.ToString))

                '' '' '' ''ObjVentaGiroContado.v_IDTARJETAS = 0
                '' '' '' ''ObjVentaGiroContado.v_NROTARJETA = "@"
                '' '' '' ''If ObjVentaGiroContado.v_IDTIPO_PAGO = 2 Then
                '' '' '' ''    ObjVentaGiroContado.v_IDTARJETAS = Int(ObjVentaGiroContado.coll_Tipo_Pago(cbidcondi_giro.SelectedIndex.ToString))
                '' '' '' ''    If txtNroTarjeta.Text = "" Then
                '' '' '' ''        MsgBox("Debe Escribir el Nro de Tarjeta", MsgBoxStyle.Information, "Seguridad Sistema")
                '' '' '' ''        ErrorProvider.SetError(txtNroTarjeta, "Nro de Tarjeta No valido")
                '' '' '' ''        txtNroTarjeta.Focus()
                '' '' '' ''        txtNroTarjeta.SelectAll()
                '' '' '' ''        Return False
                '' '' '' ''    End If
                '' '' '' ''    ObjVentaGiroContado.v_NROTARJETA = IIf(txtNroTarjeta.Text <> "", txtNroTarjeta.Text, "@")
                '' '' '' ''End If

                ''''''ObjVentaGiroContado.v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad
                If bOtrasAgencias Then
                    .IDUNIDAD_ORIGEN = iUnidadOrigen
                    .IDAGENCIAS = iAgenciaOrigen
                Else
                    .IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad
                    '''''ObjVentaGiroContado.v_IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
                    .IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
                    '' ''Dim idUnidadAgencias As Integer = iWinDestino.IndexOf(txtiWinDestino.Text)
                    '' ''idUnidadAgencias = Int(coll_iDestino.Item(idUnidadAgencias.ToString))

                End If
                .IDUNIDAD_DESTINO = iWinDestino.IndexOf(txtiWinDestino.Text)

                .IDUNIDAD_DESTINO = Int(coll_iDestino.Item(.IDUNIDAD_DESTINO.ToString))
                .IDAGENCIAS_DESTINO = Int(ObjVentagiroContado.coll_AgenciasVenta(cmbAgenciaVenta.SelectedIndex.ToString))

                .IP = dtoUSUARIOS.m_sIP

                .IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin

                .IDROL_USUARIO = dtoUSUARIOS.IdRol
                .IDTIPO_GIRO = Me.cbidtipo_giro.SelectedValue
                .IDCONDI_GIRO = Me.cbidcondi_giro.SelectedValue


                '' '' ''If idUnidadAgencias > 0 Then
                '' '' ''    ObjVentaGiroContado.v_IDUNIDAD_DESTINO = idUnidadAgencias
                '' '' ''    ObjVentaGiroContado.v_IDAGENCIAS_DESTINO = Int(ObjVentaGiroContado.coll_AgenciasVenta(cmbAgenciaVenta.SelectedIndex.ToString))
                '' '' ''Else
                '' '' ''    MsgBox("No es Correcto la Ciudad Destino...", MsgBoxStyle.Information, "Seguridad Sistema")
                '' '' ''    Return False
                '' '' ''End If


                ' '' ''If idUnidadAgencias > 0 Then
                ' '' ''    .IDUNIDAD_DESTINO = idUnidadAgencias
                ' '' ''    .IDAGENCIAS_DESTINO = Int(ObjVentaGiroContado.coll_AgenciasVenta(cmbAgenciaVenta.SelectedIndex.ToString))
                ' '' ''Else
                ' '' ''    MsgBox("No es Correcto la Ciudad Destino...", MsgBoxStyle.Information, "Seguridad Sistema")
                ' '' ''    Return False
                ' '' ''End If





                Dim indexof As Integer = 0


                '''''ObjVentaGiroContado.v_IDPERSONA = 0
                '''''ObjVentaGiroContado.v_NOMBRES_RASONSOCIAL = IIf(txtCliente_Remitente.Text <> "", txtCliente_Remitente.Text, "@")
                '''''ObjVentaGiroContado.v_NRO_DNI_RUC = IIf(txtDocCliente_Remitente.Text <> "", txtDocCliente_Remitente.Text, "@")
                .NU_DOCU_SUNA = IIf(txtDocCliente_Remitente.Text <> "", txtDocCliente_Remitente.Text, "@")
                indexof = Me.iWinContacto_Remitente.IndexOf(txtDireccionRemitente.Text)
                If Not ObjVentagiroContado.v_IDPERSONA = 0 Then
                    .IDPERSONA = ObjVentagiroContado.v_IDPERSONA
                Else
                    .IDPERSONA = 0

                End If
                .NRO_DOCU_IDEN_REMI = IIf(txtDocCliente_Remitente.Text <> "", txtDocCliente_Remitente.Text, "@")
                .RAZON_SOCIAL = IIf(txtCliente_Remitente.Text <> "", txtCliente_Remitente.Text, "@")



                '''''ObjVentaGiroContado.v_IDPERSONA_ORIGEN = 0            '
                '' '' ''ObjVentaGiroContado.v_NRO_DOC_REMITENTE = IIf(txtDNIContacto.Text <> "", txtDNIContacto.Text, "@")
                '' '' ''ObjVentaGiroContado.v_NOMBRES_REMITENTE = IIf(txtContactoRemitente.Text <> "", txtContactoRemitente.Text, "@")

                ' '' '' ''If iWinContacto_Remitente.Count > 0 And coll_Nombres_Remitente.Count > 0 Then
                ' '' '' ''    '' '' ''indexof = IIf(iWinContacto_Remitente.IndexOf(txtContactoRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtContactoRemitente.Text), -1)
                ' '' '' ''    ObjVentaGiroContado.v_IDPERSONA_ORIGEN = 0
                ' '' '' ''    If indexof >= 0 Then
                ' '' '' ''        ObjVentaGiroContado.v_IDPERSONA_ORIGEN = Int(coll_Nombres_Remitente.Item(indexof.ToString))
                ' '' '' ''    Else
                ' '' '' ''        ObjVentaGiroContado.v_IDPERSONA_ORIGEN = 0
                ' '' '' ''        ' ObjVentaGiroContado.v_NOMBRES_REMITENTE = "@"
                ' '' '' ''    End If
                ' '' '' ''End If

                ' '' '' ''ObjVentaGiroContado.v_DIRECCION_REMITENTE = IIf(txtDireccionRemitente.Text <> "", txtDireccionRemitente.Text, "@")
                ' '' '' ''If ObjVentaGiroContado.v_DIRECCION_REMITENTE = "@" Then
                ' '' '' ''    ObjVentaGiroContado.v_IDDIREECION_ORIGEN = 0
                ' '' '' ''Else
                ' '' '' ''    If iWinDireccion_Remitente.Count > 0 Then
                ' '' '' ''        indexof = iWinDireccion_Remitente.IndexOf(txtDireccionRemitente.Text)
                ' '' '' ''        ObjVentaGiroContado.v_IDDIREECION_ORIGEN = 0
                ' '' '' ''        If indexof >= 0 Then
                ' '' '' ''            ObjVentaGiroContado.v_IDDIREECION_ORIGEN = Int(coll_Direccion_Remitente.Item(indexof.ToString))
                ' '' '' ''        Else
                ' '' '' ''            ObjVentaGiroContado.v_IDDIREECION_ORIGEN = 0
                ' '' '' ''            'ObjVentaGiroContado.v_DIRECCION_REMITENTE = "@"
                ' '' '' ''        End If
                ' '' '' ''    End If
                ' '' '' ''End If




                .DIRECCION_REMI = IIf(txtDireccionRemitente.Text <> "", txtDireccionRemitente.Text, "@")
                If .DIRECCION_REMI = "@" Then
                    .IDDIRECCION_CONSIGNADO_REMI = 0
                Else
                    If iWinDireccion_Remitente.Count > 0 Then
                        indexof = iWinDireccion_Remitente.IndexOf(txtDireccionRemitente.Text)
                        .IDDIRECCION_CONSIGNADO_REMI = 0
                        If indexof >= 0 Then
                            .IDDIRECCION_CONSIGNADO_REMI = Int(coll_Direccion_Remitente.Item(indexof.ToString))
                        Else
                            .IDDIRECCION_CONSIGNADO_REMI = 0
                            'ObjVentaGiroContado.v_DIRECCION_REMITENTE = "@"
                        End If
                    End If
                End If




                '' '' ''ObjVentaGiroContado.v_TELEFONO_REMITENTE = IIf(txtTelefonoRemitente.Text <> "", txtTelefonoRemitente.Text, "@")
                ''''''ObjVentaGiroContado.v_IDCONTACTO_DESTINO = 0
                .IDCONTACTO_DESTINO = 0


                ''''''ObjVentaGiroContado.v_NRO_DOC_DESTINATARIO = IIf(txtDNIDestinatario.Text <> "", txtDNIDestinatario.Text, "@")
                .NRODOCUMENTO = IIf(txtDNIDestinatario.Text <> "", txtDNIDestinatario.Text, "@")

                '''''ObjVentaGiroContado.v_NOMBRES_DESTINATARIO = IIf(txtCliente_Destinatario.Text <> "", txtCliente_Destinatario.Text, "@")
                .NOMBRES_DESTI = IIf(txtCliente_Destinatario.Text <> "", txtCliente_Destinatario.Text, "@")


                If iWinContacto_Destinatario.Count > 0 And coll_Nombres_Destinatario.Count > 0 Then
                    indexof = IIf(iWinContacto_Destinatario.IndexOf(txtCliente_Destinatario.Text) >= 0, iWinContacto_Destinatario.IndexOf(txtCliente_Destinatario.Text), -1)
                    '''''ObjVentaGiroContado.v_IDCONTACTO_DESTINO = 0
                    .IDCONTACTO_DESTINO = 0

                    If indexof >= 0 Then
                        '''''  ObjVentaGiroContado.v_IDCONTACTO_DESTINO = Int(coll_Nombres_Destinatario.Item(indexof.ToString))
                        .IDCONTACTO_DESTINO = Int(coll_Nombres_Destinatario.Item(indexof.ToString))
                    Else
                        '''''ObjVentaGiroContado.v_IDCONTACTO_DESTINO = 0
                        .IDCONTACTO_DESTINO = 0
                        'txtCliente_Destinatario.Text = "@"
                    End If
                End If

                '''''ObjVentaGiroContado.v_DIRECCION_DESTINATARIO = IIf(txtDireccionDestinatario.Text <> "", txtDireccionDestinatario.Text, "@")
                .DIRECCION_DESTI = IIf(txtDireccionDestinatario.Text <> "", txtDireccionDestinatario.Text, "@")
                '' '' ''If ObjVentaGiroContado.v_DIRECCION_DESTINATARIO = "@" Then
                '' '' ''    ObjVentaGiroContado.v_IDDIREECION_DESTINO = 0
                '' '' ''Else
                '' '' ''    If iWinDireccion_Destinatario.Count > 0 Then
                '' '' ''        indexof = iWinDireccion_Destinatario.IndexOf(txtDireccionDestinatario.Text)
                '' '' ''        ObjVentaGiroContado.v_IDDIREECION_DESTINO = 0
                '' '' ''        If indexof >= 0 Then
                '' '' ''            ObjVentaGiroContado.v_IDDIREECION_DESTINO = Int(coll_Direccion_Destinatario.Item(indexof.ToString))
                '' '' ''        Else
                '' '' ''            ObjVentaGiroContado.v_IDDIREECION_DESTINO = 0
                '' '' ''            'ObjVentaGiroContado.v_DIRECCION_DESTINATARIO = "@"
                '' '' ''        End If
                '' '' ''    End If
                '' '' ''End If

                If .DIRECCION_DESTI = "@" Then
                    .DIRECCION_DESTI = 0
                Else
                    If iWinDireccion_Destinatario.Count > 0 Then
                        indexof = iWinDireccion_Destinatario.IndexOf(txtDireccionDestinatario.Text)
                        .IDDIRECCION_CONSIGNADO_DESTI = 0
                        If indexof >= 0 Then
                            .IDDIRECCION_CONSIGNADO_DESTI = Int(coll_Direccion_Destinatario.Item(indexof.ToString))
                        Else
                            .IDDIRECCION_CONSIGNADO_DESTI = 0
                            'ObjVentaGiroContado.v_DIRECCION_DESTINATARIO = "@"
                        End If
                    End If
                End If


                .TELEFONO_DESTI = IIf(txtTelefonoDestinatario.Text <> "", txtTelefonoDestinatario.Text, "@")
                '' '' ''ObjVentaGiroContado.v_MEMO = IIf(txtMemo.Text <> "", txtMemo.Text, "@")
                '' '' ''ObjVentaGiroContado.v_MONTO_DESCUENTO = IIf(txtPorcernt_Descuento.Text <> "", txtPorcernt_Descuento.Text, 0)

                .MEMO = IIf(txtMemo.Text <> "", txtMemo.Text, "@")
                .MONTO_DESCUENTO = IIf(txtPorcernt_Descuento.Text <> "", txtPorcernt_Descuento.Text, 0)


                Dim totalCosto As Double = 0
                Dim valor1 As Double = 0
                Dim valor2 As Double = 0

                ObjVentagiroContado.v_CANTIDAD_X_PESO = 0
                ObjVentagiroContado.v_CANTIDAD_X_VOLUMEN = 0
                ObjVentagiroContado.v_CANTIDAD_X_SOBRE = 0

                ObjVentagiroContado.v_TOTAL_PESO = 0
                ObjVentagiroContado.v_TOTAL_VOLUMEN = 0

                .MONTO_GIRADO = CDbl(Me.TxtMontoGirar.Text)
                .TOTAL_COSTO = CDbl(Me.txtCosto_Total.Text)
                .MONTO_DESCUENTO = CDbl(Me.txtPorcernt_Descuento.Text)

                'PESO
                ' '' ''If IsDBNull(dtGridViewBultos.Rows(0).Cells(2)) = False Then
                ' '' ''    valor1 = Format(Val(dtGridViewBultos(2, 0).Value), "##,###,####.00")
                ' '' ''    valor2 = Format(Val(dtGridViewBultos(4, 0).Value), "##,###,####.00")

                ' '' ''    ObjVentaGiroContado.v_CANTIDAD_X_PESO = valor1
                ' '' ''    ObjVentaGiroContado.v_TOTAL_PESO = valor2
                ' '' ''    totalCosto = valor2 * tarifa_Peso
                ' '' ''End If

                '' '' ''VOLUMEN
                ' '' ''If IsDBNull(dtGridViewBultos.Rows(1).Cells(2)) = False Then
                ' '' ''    valor1 = Format(Val(dtGridViewBultos(2, 1).Value), "##,###,###.00")
                ' '' ''    valor2 = Format(Val(dtGridViewBultos(4, 1).Value), "##,###,###.00")
                ' '' ''    ObjVentaGiroContado.v_CANTIDAD_X_VOLUMEN = valor1
                ' '' ''    ObjVentaGiroContado.v_TOTAL_VOLUMEN = valor2
                ' '' ''    totalCosto = totalCosto + valor2 * tarifa_Volumen
                ' '' ''End If

                '' '' ''SOBRE
                ' '' ''If IsDBNull(dtGridViewBultos.Rows(2).Cells(2)) = False Then
                ' '' ''    valor1 = Format(Val(dtGridViewBultos(2, 2).Value), "##,###,###.00")
                ' '' ''    ObjVentaGiroContado.v_CANTIDAD_X_SOBRE = valor1
                ' '' ''    totalCosto = totalCosto + valor1 * tarifa_Sobre
                ' '' ''End If
                'txtSub_Total.Text = Format(Monto_Base + totalCosto - Val(Me.txtPorcernt_Descuento.Text) * totalCosto / 100, "##,###,###.00")
                'txtMonto_IGV.Text = Format((Monto_Base + totalCosto - Val(Me.txtPorcernt_Descuento.Text) * totalCosto / 100) * (0.01 * dtoUSUARIOS.iIGV), "##,###,###.00")
                'txtCosto_Total.Text = Format((Monto_Base + totalCosto - Val(Me.txtPorcernt_Descuento.Text) * totalCosto / 100) * (1 + 0.01 * dtoUSUARIOS.iIGV), "##,###,###.00")

                ObjVentagiroContado.v_PRECIO_X_PESO = tarifa_Peso
                ObjVentagiroContado.v_PRECIO_X_VOLUMEN = tarifa_Volumen
                ObjVentagiroContado.v_PRECIO_X_SOBRE = tarifa_Sobre

                '' '' ''ObjVentaGiroContado.v_MONTO_SUB_TOTAL = txtSub_Total.Text
                '' '' ''ObjVentaGiroContado.v_MONTO_IMPUESTO = txtMonto_IGV.Text
                ObjVentagiroContado.v_TOTAL_COSTO = txtCosto_Total.Text

                ObjVentagiroContado.v_IDTIPO_MONEDA = 1 'Soles

                ObjVentagiroContado.v_IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                ObjVentagiroContado.v_IP = dtoUSUARIOS.IP
                ObjVentagiroContado.v_IDROL_USUARIO = dtoUSUARIOS.IdRol

                ObjVentagiroContado.v_MONTO_PENALIDAD = 0
                ObjVentagiroContado.v_IDFUNCIONARIO_AUTORIZACION = 0

                ObjVentagiroContado.v_IGV = dtoUSUARIOS.iIGV
                ObjVentagiroContado.v_PORCENT_DEVOLUCION = 0
                ObjVentagiroContado.v_PORCENT_DESCUENTO = Format(Val(txtPorcernt_Descuento.Text), "###.00")
                ObjVentagiroContado.v_MONTO_RECARGO = 0
                '----------------------------------------------------------------------------------------------------------------------------
                ObjVentagiroContado.v_MONTO_BASE = Monto_Base

                'If iControlFacturacion > 0 Then
                '    ObjVentaGiroContado.v_MONTO_BASE = Monto_Base
                'Else
                '    If iControlMonto_Base = 0 Then
                '        ObjVentaGiroContado.v_MONTO_BASE = 0
                '    Else
                '        ObjVentaGiroContado.v_MONTO_BASE = Monto_Base
                '    End If
                'End If
                '----------------------------------------------------------------------------------------------------------------------------
                Dim iUnidad As Integer
                If bOtrasAgencias Then
                    iUnidad = iUnidadOrigen
                Else
                    iUnidad = ObjVentagiroContado.v_IDUNIDAD_ORIGEN
                End If
                'If ObjVentagiroContado.v_IDUNIDAD_ORIGEN = ObjVentagiroContado.v_IDUNIDAD_DESTINO Then
                If iUnidad = ObjVentagiroContado.v_IDUNIDAD_DESTINO Then
                    MsgBox("No pueden ser iguales el Origen y el Destino...", MsgBoxStyle.Information, "Seguridad Sistema")
                    Return False
                End If
                If txtiWinDestino.Text = "" Then
                    MsgBox("Debe definir un detino Para esta OPeracion...", MsgBoxStyle.Information, "Seguridad Sistema")
                    Return False
                End If

                If ObjVentagiroContado.v_IDTIPO_ENTREGA = 2 Then
                    If txtDireccionDestinatario.Text = "" Then
                        ErrorProvider.SetError(txtDireccionDestinatario, "Debe Ingresar la Direccion es Obligatoria...")
                        txtDireccionDestinatario.Focus()
                        Return False
                    End If
                End If

                ' '' ''If ObjVentaGiroContado.v_CANTIDAD_X_PESO + ObjVentaGiroContado.v_CANTIDAD_X_SOBRE + ObjVentaGiroContado.v_CANTIDAD_X_VOLUMEN <= 0 Then
                ' '' ''    MsgBox("No Puede Realizar esta operacion debe enviar como minimo un Paquete...", MsgBoxStyle.Information, "Seguridad Sistema")
                ' '' ''    Return False
                ' '' ''End If
                'cmbTipo_Entrega
                'ObjIMPRESIONFACT_BOL.fnClear()
                ' '' ''Try
                ' '' ''    ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso = Val(dtGridViewBultos(7, 0).Value)
                ' '' ''    ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol = Val(dtGridViewBultos(7, 1).Value)
                ' '' ''    ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Val(dtGridViewBultos(7, 2).Value)
                ' '' ''Catch ex As Exception

                ' '' ''End Try
                ' '' ''ObjIMPRESIONFACT_BOL.xCantidad_Peso = ObjVentaGiroContado.v_CANTIDAD_X_PESO
                ' '' ''ObjIMPRESIONFACT_BOL.xCantidad_Sobre = ObjVentaGiroContado.v_CANTIDAD_X_SOBRE
                ' '' ''ObjIMPRESIONFACT_BOL.xCantidad_Vol = ObjVentaGiroContado.v_CANTIDAD_X_VOLUMEN

                ' '' ''ObjCODIGOBARRA.clinte = ObjVentaGiroContado.v_NOMBRES_RASONSOCIAL
                ' '' ''ObjCODIGOBARRA.NroDOC = ObjVentaGiroContado.v_SERIE_FACTURA & "-" & ObjVentaGiroContado.v_NRO_FACTURA
                ' '' ''ObjCODIGOBARRA.AGEDOM = Mid(cmbTipo_Entrega.Text, 1, 3)

                ' '' ''ObjIMPRESIONFACT_BOL.xOrigen = dtoUSUARIOS.m_iNombreUnidadAgencia
                ' '' ''ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA = Me.cmbTipo_Entrega.Text
                ' '' ''ObjIMPRESIONFACT_BOL.xDestino = txtiWinDestino.Text
                ' '' ''ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL = Me.txtSERIE.Text & "-" & Me.txtNroDocFACBOL.Text
                ' '' ''ObjIMPRESIONFACT_BOL.xRazonSocial = Me.txtCliente_Remitente.Text
                ' '' ''ObjIMPRESIONFACT_BOL.xDireccionRemitente = Me.txtDireccionRemitente.Text
                ' '' ''ObjIMPRESIONFACT_BOL.xRuc = txtDocCliente_Remitente.Text
                ' '' '' '' '' ''ObjIMPRESIONFACT_BOL.xRemitente = Me.txtContactoRemitente.Text
                ' '' ''ObjIMPRESIONFACT_BOL.xConsignado = Me.txtCliente_Destinatario.Text
                ' '' ''ObjIMPRESIONFACT_BOL.xDireccionConsignado = Me.txtDireccionDestinatario.Text
                ' '' ''ObjIMPRESIONFACT_BOL.xfecha_factura = Me.txtFecha.Text
                ' '' ''ObjIMPRESIONFACT_BOL.xTotalPeso = ObjVentaGiroContado.v_TOTAL_PESO
                ' '' ''ObjIMPRESIONFACT_BOL.xTotalVolumen = ObjVentaGiroContado.v_TOTAL_VOLUMEN
                ' '' ''ObjIMPRESIONFACT_BOL.xTotalSobres = 0
                ' '' ''ObjIMPRESIONFACT_BOL.xFormaPago = cbidtipo_giro.Text
                ' '' ''ObjIMPRESIONFACT_BOL.xNroRef = Me.txtSERIE.Text & "-" & Me.txtNroDocFACBOL.Text
                ' '' ''ObjIMPRESIONFACT_BOL.xMemo = Me.txtMemo.Text
                ' '' '' '' '' ''ObjIMPRESIONFACT_BOL.xMonto_Sub_Total = Me.txtSub_Total.Text
                ' '' '' '' '' ''ObjIMPRESIONFACT_BOL.xMonto_Impuesto = txtMonto_IGV.Text
                ' '' ''ObjIMPRESIONFACT_BOL.xTotal_Costo = ObjVentaGiroContado.v_TOTAL_COSTO
                ' '' ''ObjIMPRESIONFACT_BOL.xDescuento = IIf(txtPorcernt_Descuento.Text <> "", txtPorcernt_Descuento.Text, "")
                ' '' ''ObjIMPRESIONFACT_BOL.xAgenciaDestino = IIf(cmbAgenciaVenta.Text <> "", cmbAgenciaVenta.Text, "")
                ' '' ''ObjVentaGiroContado.v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad
                ' '' '' ''If varIdCondicion = 2 Then
                ' '' '' ''    If ObjVentaGiroContado.Grabar() = True Then
                ' '' '' ''        ObjIMPRESIONFACT_BOL.xIdFactura = ObjVentaGiroContado.v_IDFACTURA.ToString
                ' '' '' ''        'if msgbox "Esta Seguro de Imprimir etiquetas ?",MsgBoxStyle.YesNoCancel,"Seguridad Sistema" =MsgBoxResult.Yes then

                ' '' '' ''        'End If
                ' '' '' ''        'ObjCODIGOBARRA.Cantidad = "5"

                ' '' '' ''        If bControlFiscalizacion = False Then
                ' '' '' ''            MsgBox("Verifique su Impresora...que este conectado", MsgBoxStyle.Exclamation, "Seguridad Sistema")
                ' '' '' ''            If ObjVentaGiroContado.v_IDTIPO_COMPROBANTE = 1 Then
                ' '' '' ''                fnImprimirFACTURA()
                ' '' '' ''            Else
                ' '' '' ''                fnImprimirBOLETA()
                ' '' '' ''            End If
                ' '' '' ''        End If

                ' '' '' ''        If MsgBox("Esta Seguro de Imprimir Etiquetas..?", MsgBoxStyle.YesNo, "Seguridad Sistemas") = MsgBoxResult.Yes Then
                ' '' '' ''            If xIMPRESORA = 1 Then
                ' '' '' ''                fnImprimirEtiquetas()
                ' '' '' ''            Else
                ' '' '' ''                fnImprimirEtiquetasFAC_II()
                ' '' '' ''            End If

                ' '' '' ''        End If
                ' '' '' ''        fnNUEVO()
                ' '' '' ''        flat = True
                ' '' '' ''    Else
                ' '' '' ''        MsgBox("Operacion Cancelada....Verifique su Configuracion Documentaria", MsgBoxStyle.Information, "Seguridad Sistema")
                ' '' '' ''    End If

                ' '' '' ''ElseIf varIdCondicion = 1 Then

                ' '' '' ''    If ObjVentaGiroContado.v_IDFORMA_PAGO = 1 And bControlFiscalizacion = False Then
                ' '' '' ''        Dim varDlgPagos As New frmPagosContado
                ' '' '' ''        If varDlgPagos.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ' '' '' ''            If ObjVentaGiroContado.Grabar() = True Then
                ' '' '' ''                ObjPagosSoles.v_idfactura_contado = ObjVentaGiroContado.v_IDFACTURA
                ' '' '' ''                ObjPagosDolares.v_idfactura_contado = ObjVentaGiroContado.v_IDFACTURA
                ' '' '' ''                ObjIMPRESIONFACT_BOL.xIdFactura = ObjVentaGiroContado.v_IDFACTURA.ToString

                ' '' '' ''                If bControlFiscalizacion = False Then
                ' '' '' ''                    MsgBox("Verifique su Impresora, que este conectado...", MsgBoxStyle.Exclamation, "Seguridad Sistema")
                ' '' '' ''                    If ObjVentaGiroContado.v_IDTIPO_COMPROBANTE = 1 Then
                ' '' '' ''                        fnImprimirFACTURA()
                ' '' '' ''                    Else
                ' '' '' ''                        fnImprimirBOLETA()
                ' '' '' ''                    End If
                ' '' '' ''                End If

                ' '' '' ''                If MsgBox("Esta Seguro de Imprimir Etiquetas..?", MsgBoxStyle.YesNo, "Seguridad Sistemas") = MsgBoxResult.Yes Then
                ' '' '' ''                    If xIMPRESORA = 1 Then
                ' '' '' ''                        fnImprimirEtiquetas()
                ' '' '' ''                    Else
                ' '' '' ''                        fnImprimirEtiquetasFAC_II()
                ' '' '' ''                    End If
                ' '' '' ''                End If
                ' '' '' ''                If ObjPagosSoles.fnGrabarPagos() = True Then

                ' '' '' ''                End If
                ' '' '' ''                If ObjPagosDolares.fnGrabarPagos() = True Then

                ' '' '' ''                End If
                ' '' '' ''                fnNUEVO()
                ' '' '' ''                flat = True
                ' '' '' ''            Else
                ' '' '' ''                MsgBox("Operacion Cancelada....Verifique su Configuracion Documentaria", MsgBoxStyle.Information, "Seguridad Sistema")
                ' '' '' ''            End If
                ' '' '' ''        Else
                ' '' '' ''            MsgBox("Cancelo Operacion Puede Intentar el Pago de Nuevo", MsgBoxStyle.Information, "Seguridad Sistema")
                ' '' '' ''        End If
                ' '' '' ''    Else
                ' '' '' ''        If ObjVentaGiroContado.Grabar() = True Then
                ' '' '' ''            If bControlFiscalizacion = False Then
                ' '' '' ''                MsgBox("Verifique su Impresora, que este conectado...", MsgBoxStyle.Exclamation, "Seguridad Sistema")
                ' '' '' ''                If ObjVentaGiroContado.v_IDTIPO_COMPROBANTE = 1 Then
                ' '' '' ''                    fnImprimirFACTURA()
                ' '' '' ''                Else
                ' '' '' ''                    fnImprimirBOLETA()
                ' '' '' ''                End If
                ' '' '' ''            End If

                ' '' '' ''            If MsgBox("Esta Seguro de Imprimir Etiquetas..?", MsgBoxStyle.YesNo, "Seguridad Sistemas") = MsgBoxResult.Yes Then
                ' '' '' ''                fnImprimirEtiquetas()
                ' '' '' ''            End If
                ' '' '' ''            fnNUEVO()
                ' '' '' ''            flat = True
                ' '' '' ''        End If
                ' '' '' ''    End If
                ' '' '' ''End If
                'datahelper
                '.InUpDe_factura_giro(cnn)
                .InUpDe_factura_giro()
                fnNUEVO()
                flat = True
            End With
        Catch ex As Exception
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            flat = False
            Throw New Exception(ex.Message)
        End Try
        Return flat
    End Function
    Public Function fnTarifario() As Boolean
        Dim flag As Boolean = False
        Try
            'Para Traer en una sola la tarifa Origen Destino
            bControl_Tarifas = False
            tarifa_Peso = 0
            tarifa_Volumen = 0
            tarifa_Articulo = 0
            Monto_Base = 0

            'objGuiaEnvio.sNU_DOCU_SUNAT = IIf(TxtRuc.Text <> "", TxtRuc.Text, "@")
            ''objGuiaEnvio.iIDUNIDAD_AGENCIA = 100
            ''objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = 575
            'Dim idOrigenvar As Integer = iWinDestino.IndexOf(txtiWinOrigen.Text) + 1
            'Dim idDestinovar As Integer = iWinDestino.IndexOf(txtiWinDestino.Text) + 1

            ''MsgBox(objGuiaEnvio.iIDUNIDAD_AGENCIA)
            ''MsgBox(objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO)

            ''objGuiaEnvio.iIDUNIDAD_AGENCIA = Int(coll_iOrigen.Item(idOrigenvar.ToString))
            ''objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = Int(coll_iOrigen.Item(idDestinovar.ToString))
            'If txtiWinOrigen.Text <> "" And txtiWinDestino.Text <> "" And txtiWinOrigen.Text <> txtiWinDestino.Text Then
            '    objGuiaEnvio.iIDUNIDAD_AGENCIA = Int(coll_iOrigen.Item(iWinDestino.IndexOf(txtiWinOrigen.Text) + 1))
            '    objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = Int(coll_iDestino.Item(iWinDestino.IndexOf(txtiWinDestino.Text) + 1))
            'Else
            '    objGuiaEnvio.iIDUNIDAD_AGENCIA = 999
            '    objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = 999
            'End If

            'If objGuiaEnvio.fnLISTA_TARIFA_CLIENTE() = True Then
            'tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
            'tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
            'tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
            'Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base
            'tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Base_Xpostal
            'dtGridViewBultos(4, 2).Value = Monto_Base
            'flag = True
            'bControl_Tarifas = True
            'MsgBox(Monto_Base + objGuiaEnvio.iTarifa_Publica_Monto_Peso + objGuiaEnvio.iTarifa_Publica_Monto_Volumen + 100000)

            objGuiaEnvio.iIDUNIDAD_AGENCIA = dtoUSUARIOS.m_idciudad

            Dim idUnidadAgencias As Integer = iWinDestino.IndexOf(txtiWinDestino.Text)
            idUnidadAgencias = Int(coll_iDestino.Item(idUnidadAgencias.ToString))
            If idUnidadAgencias > 0 Then
                ObjVentagiroContado.v_IDUNIDAD_DESTINO = idUnidadAgencias
                ObjVentagiroContado.v_IDAGENCIAS_DESTINO = Int(ObjVentagiroContado.coll_AgenciasVenta(cmbAgenciaVenta.SelectedIndex.ToString))
                objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = idUnidadAgencias
            Else
                MsgBox("No es Correcto la Ciudad Destino...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return False
            End If

            objGuiaEnvio.sNU_DOCU_SUNAT = IIf(Me.txtDocCliente_Remitente.Text <> "", Me.txtDocCliente_Remitente.Text, "@")
            'Mod. 27/08/2009 -->Omendoza - Pasando al datahelper   
            If objGuiaEnvio.fnLISTA_TARIFA_CLIENTE() = True Then
                tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
                tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
                tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
                Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base
                'tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Base_Xpostal
                tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Sobre

                ' '' ''dtGridViewBultos(5, 0).Value = tarifa_Peso
                ' '' ''dtGridViewBultos(5, 1).Value = tarifa_Volumen
                ' '' ''dtGridViewBultos(5, 2).Value = tarifa_Sobre
                ' '' ''dtGridViewBultos(5, 3).Value = Monto_Base
                ' '' ''dtGridViewBultos(7, 3).Value = Monto_Base

                flag = True
                bControl_Tarifas = True

            ElseIf objGuiaEnvio.fnTARIFA_PUBLICA_CARGA() = True Then 'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper   

                tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
                tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
                tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
                Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base
                tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Base_Xpostal

                ' '' ''dtGridViewBultos(5, 0).Value = tarifa_Peso
                ' '' ''dtGridViewBultos(5, 1).Value = tarifa_Volumen
                ' '' ''dtGridViewBultos(5, 2).Value = tarifa_Sobre

                ' '' ''dtGridViewBultos(5, 3).Value = Monto_Base
                ' '' ''dtGridViewBultos(7, 3).Value = Monto_Base


                flag = True
                bControl_Tarifas = True
                'MsgBox(Monto_Base + objGuiaEnvio.iTarifa_Publica_Monto_Peso + objGuiaEnvio.iTarifa_Publica_Monto_Volumen)
            Else
                flag = False
                MsgBox("NO EXISTE TARIFA PARA ESTE ORIGEN Y DESTINO, NI ASOCIADO A UNA TARIFA DEL CLIENTE", MsgBoxStyle.Information, "REVICE SUS DATOS")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flag
    End Function
    Public Function fnTotalPago() As Boolean
        Dim flag As Boolean = False
        Try
            Dim PorcentajeDesc As Double = Val(txtPorcernt_Descuento.Text.ToString) / 100
            ' '' ''Dim Peso_Peso As Double = Val(dtGridViewBultos(4, 0).Value.ToString)
            ' '' ''Dim Peso_Volumen As Double = Val(dtGridViewBultos(4, 1).Value.ToString)
            ' '' ''Dim Nor_Sobres As Double = Val(dtGridViewBultos(4, 2).Value.ToString)
            Dim IGV As Double = dtoUSUARIOS.iIGV / 100

            Dim SubTotal_Costo As Double = 0

            ' '' ''Dim ivol As Double = 0
            ' '' ''If dtGridViewBultos(2, 1).Value <> Nothing And dtGridViewBultos(4, 1).Value <> Nothing And dtGridViewBultos(4, 1).Value <> Nothing Then
            ' '' ''    ivol = Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(2, 1).Value.ToString) * Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(4, 1).Value.ToString)
            ' '' ''End If

            ' '' ''Dim ipes As Double = 0
            ' '' ''If dtGridViewBultos(2, 0).Value <> Nothing And dtGridViewBultos(4, 0).Value <> Nothing Then
            ' '' ''    ipes = Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(2, 0).Value.ToString) * Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(4, 0).Value.ToString)
            ' '' ''End If

            ' '' ''dtGridViewBultos(5, 0).Value = Peso_Peso * tarifa_Peso * PorcentajeDesc
            ' '' ''dtGridViewBultos(5, 1).Value = Peso_Volumen * tarifa_Volumen * PorcentajeDesc
            ' '' ''dtGridViewBultos(5, 2).Value = tarifa_Sobre * Nor_Sobres * PorcentajeDesc

            ' '' ''dtGridViewBultos(6, 0).Value = Peso_Peso * tarifa_Peso * (1 - PorcentajeDesc)
            ' '' ''dtGridViewBultos(6, 1).Value = Peso_Volumen * tarifa_Volumen * (1 - PorcentajeDesc)
            ' '' ''dtGridViewBultos(6, 2).Value = tarifa_Sobre * Nor_Sobres * (1 - PorcentajeDesc)

            '----------------------------------------------------------------------------------------------------------------------------
            ObjVentagiroContado.v_MONTO_BASE = Monto_Base
            'If iControlFacturacion > 0 Then
            '    ObjVentaGiroContado.v_MONTO_BASE = Monto_Base
            'Else
            '    If iControlMonto_Base = 0 Then
            '        ObjVentaGiroContado.v_MONTO_BASE = 0
            '        Monto_Base = 0
            '    Else
            '        ObjVentaGiroContado.v_MONTO_BASE = Monto_Base
            '    End If
            'End If
            '----------------------------------------------------------------------------------------------------------------------------


            ' '' ''If Peso_Peso * tarifa_Peso + Peso_Volumen * tarifa_Volumen > 0 Then
            ' '' ''    If iControlMonto_Base = 1 Then
            ' '' ''        SubTotal_Costo = Monto_Base + (Peso_Peso * tarifa_Peso + Peso_Volumen * tarifa_Volumen + tarifa_Sobre * Nor_Sobres) * (1 - PorcentajeDesc)
            ' '' ''    Else
            ' '' ''        SubTotal_Costo = (Peso_Peso * tarifa_Peso + Peso_Volumen * tarifa_Volumen + tarifa_Sobre * Nor_Sobres) * (1 - PorcentajeDesc)
            ' '' ''    End If

            ' '' ''Else
            ' '' ''    SubTotal_Costo = (Peso_Peso * tarifa_Peso + Peso_Volumen * tarifa_Volumen + tarifa_Sobre * Nor_Sobres) * (1 - PorcentajeDesc)
            ' '' ''End If


            '  Dim SUB_TOTAL_GENERAL As Double = fnTECHO(Format((1 + IGV) * SubTotal_Costo, "###,###,###.00"))

            ' Dim IGV As Double = dtoUSUARIOS.iIGV / 100

            Dim SUB_TOTAL_GENERAL As Double = 0
            If (1 - Val(Me.txtPorcernt_Descuento.Text) / 100) > 0 Then
                SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SubTotal_Costo * (1 - Val(Me.txtPorcernt_Descuento.Text) / 100), "###,###,###.00"))
            Else
                If (1 - Val(Me.txtPorcernt_Descuento.Text) / 100) = 0 Then
                    SUB_TOTAL_GENERAL = 0
                End If
            End If

            '' '' ''txtSub_Total.Text = Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.0")
            '' '' ''txtMonto_IGV.Text = Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.0")
            '' '' ''txtCosto_Total.Text = Format(SUB_TOTAL_GENERAL, "###,###,###.0")

            'txtSub_Total.Text = Format(SubTotal_Costo, "000,000,000.00")
            'txtMonto_IGV.Text = Format(IGV * SubTotal_Costo, "000,000,000.00")
            'txtCosto_Total.Text = Format((1 + IGV) * SubTotal_Costo, "000,000,000.0")

        Catch ex As Exception
            '' '' ''txtSub_Total.Text = "0.00"
            '' '' ''txtMonto_IGV.Text = "0.00"
            '' '' ''txtCosto_Total.Text = "0.00"
            flag = False
        End Try

        Return flag
    End Function

    Private Sub dtGridViewBultos_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            fnTotalPago()
            Dim row As Short = e.RowIndex
            Dim col As Short = e.ColumnIndex
            iROW_ACTUAL = e.RowIndex
            iCOL_ACTUAL = e.ColumnIndex
            iROW = e.RowIndex
            iCOL = e.ColumnIndex

            'Dim valor1 As Double = Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(4, row).Value.ToString))
            'Dim valor2 As Double = Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(2, row).Value.ToString))

            ' '' ''Dim valor1 As Double = Val(dtGridViewBultos(4, row).Value)
            ' '' ''Dim valor2 As Double = Val(dtGridViewBultos(2, row).Value)
            ' '' ''fnCalcularCosto(row, valor1, valor2)
            'If row = 0 Then
            '    dtGridViewBultos(6, row).Value = Format((valor1 * tarifa_Peso) * Val(Me.txtPorcernt_Descuento.Text) / 100, "###,###,###.00")
            '    dtGridViewBultos(7, row).Value = Format((valor1 * tarifa_Peso) * (1 - Val(Me.txtPorcernt_Descuento.Text) / 100), "###,###,###.00")
            'ElseIf row = 1 Then
            '    dtGridViewBultos(6, row).Value = Format((valor1 * tarifa_Volumen) * Val(Me.txtPorcernt_Descuento.Text) / 100, "###,###,###.00")
            '    dtGridViewBultos(7, row).Value = Format((valor1 * tarifa_Volumen) * (1 - Val(Me.txtPorcernt_Descuento.Text) / 100), "###,###,###.00")
            'ElseIf row = 2 Then
            '    dtGridViewBultos(6, row).Value = Format((valor2 * tarifa_Sobre), "###,###,###.00")
            '    dtGridViewBultos(7, row).Value = Format((valor2 * tarifa_Sobre), "###,###,###.00")
            'End If
            'Dim SubTotal As Double = Val(dtGridViewBultos(7, 0).Value) + Val(dtGridViewBultos(7, 1).Value) + Val(dtGridViewBultos(7, 2).Value)
            'txtSub_Total.Text = SubTotal
            'txtMonto_IGV.Text = Format(SubTotal * dtoUSUARIOS.iIGV / 100, "###,###,###.00")
            'txtCosto_Total.Text = Format(SubTotal * (1 + dtoUSUARIOS.iIGV / 100), "###,###,###.00")

        Catch ex As Exception

        End Try
    End Sub
    Private Sub fnCalcularCosto(ByVal row As Integer, ByVal valor1 As Double, ByVal valor2 As Double)
        Try

            ' '' ''If row = 0 Then
            ' '' ''    If valor2 = 0 Then
            ' '' ''        'dtGridViewBultos(6, row).Value = Format((valor2 * valor1 * tarifa_Peso) * Val(Me.txtPorcernt_Descuento.Text) / 100, "###,###,###.00")
            ' '' ''        'dtGridViewBultos(7, row).Value = Format((valor2 * valor1 * tarifa_Peso) * (1 - Val(Me.txtPorcernt_Descuento.Text) / 100), "###,###,###.00")

            ' '' ''        dtGridViewBultos(6, row).Value = "0.00"
            ' '' ''        dtGridViewBultos(7, row).Value = Format((valor2 * valor1 * tarifa_Peso), "###,###,###.00")
            ' '' ''    Else
            ' '' ''        If objGuiaEnvio.iPeso_Minimo <= valor1 And valor1 <= objGuiaEnvio.iPeso_Maximo Then
            ' '' ''            dtGridViewBultos(6, row).Value = "0.00"
            ' '' ''            dtGridViewBultos(7, row).Value = Format(objGuiaEnvio.iPrecio_cond_Peso, "###,###,###.00")
            ' '' ''        Else
            ' '' ''            'dtGridViewBultos(6, row).Value = Format((valor1 * tarifa_Peso) * Val(Me.txtPorcernt_Descuento.Text) / 100, "###,###,###.00")
            ' '' ''            'dtGridViewBultos(7, row).Value = Format((valor1 * tarifa_Peso) * (1 - Val(Me.txtPorcernt_Descuento.Text) / 100), "###,###,###.00")
            ' '' ''            dtGridViewBultos(6, row).Value = "0.00"
            ' '' ''            dtGridViewBultos(7, row).Value = Format((valor1 * tarifa_Peso), "###,###,###.00")
            ' '' ''        End If
            ' '' ''    End If

            ' '' ''    'dtGridViewBultos(6, row).Value = Format((valor1 * tarifa_Peso) * Val(Me.txtPorcernt_Descuento.Text) / 100, "###,###,###.00")
            ' '' ''    'dtGridViewBultos(7, row).Value = Format((valor1 * tarifa_Peso) * (1 - Val(Me.txtPorcernt_Descuento.Text) / 100), "###,###,###.00")

            ' '' ''ElseIf row = 1 Then
            ' '' ''    'dtGridViewBultos(6, row).Value = Format((valor1 * tarifa_Volumen) * Val(Me.txtPorcernt_Descuento.Text) / 100, "###,###,###.00")
            ' '' ''    'dtGridViewBultos(7, row).Value = Format((valor1 * tarifa_Volumen) * (1 - Val(Me.txtPorcernt_Descuento.Text) / 100), "###,###,###.00")

            ' '' ''    dtGridViewBultos(6, row).Value = "0.00"
            ' '' ''    dtGridViewBultos(7, row).Value = Format((valor1 * tarifa_Volumen), "###,###,###.00")
            ' '' ''ElseIf row = 2 Then
            ' '' ''    '  dtGridViewBultos(6, row).Value = Format((valor2 * tarifa_Sobre), "###,###,###.00")
            ' '' ''    dtGridViewBultos(7, row).Value = Format((valor2 * tarifa_Sobre), "###,###,###.00")
            ' '' ''End If

            '' '' ''----------------------------------------------------------------------------------------------------------------------------
            ' '' ''If iControlFacturacion > 0 Then
            ' '' ''    ObjVentaGiroContado.v_MONTO_BASE = Monto_Base
            ' '' ''Else
            ' '' ''    ObjVentaGiroContado.v_MONTO_BASE = Monto_Base
            ' '' ''    'If iControlMonto_Base = 0 Then
            ' '' ''    '    ObjVentaGiroContado.v_MONTO_BASE = 0
            ' '' ''    '    Monto_Base = 0
            ' '' ''    'Else
            ' '' ''    '    ObjVentaGiroContado.v_MONTO_BASE = Monto_Base
            ' '' ''    'End If
            ' '' ''End If
            '' '' ''----------------------------------------------------------------------------------------------------------------------------

            Dim SubTotal As Double = 0

            ' '' ''If Val(dtGridViewBultos(7, 0).Value) + Val(dtGridViewBultos(7, 1).Value) > 0 Then
            ' '' ''    'SubTotal = Monto_Base + Val(dtGridViewBultos(7, 0).Value.ToString) + Val(dtGridViewBultos(7, 1).Value) + Val(dtGridViewBultos(7, 2).Value)
            ' '' ''    'SubTotal = Monto_Base + Val(Format(dtGridViewBultos(7, 0).Value, "####.00")) + Val(Format(dtGridViewBultos(7, 1).Value, "####.00")) + Val(Format(dtGridViewBultos(7, 2).Value, "####.00"))
            ' '' ''    If iControlMonto_Base = 1 Then
            ' '' ''        SubTotal = Monto_Base + fnNumeroDecimal(dtGridViewBultos(7, 0).Value.ToString) + fnNumeroDecimal(dtGridViewBultos(7, 1).Value.ToString) + fnNumeroDecimal(dtGridViewBultos(7, 2).Value.ToString)
            ' '' ''    Else
            ' '' ''        SubTotal = fnNumeroDecimal(dtGridViewBultos(7, 0).Value.ToString) + fnNumeroDecimal(dtGridViewBultos(7, 1).Value.ToString) + fnNumeroDecimal(dtGridViewBultos(7, 2).Value.ToString)
            ' '' ''    End If

            ' '' ''Else
            ' '' ''    ' SubTotal = Val(Format(dtGridViewBultos(7, 0).Value, "####.00")) + Val(Format(dtGridViewBultos(7, 1).Value, "####.00")) + Val(Format(dtGridViewBultos(7, 2).Value, "####.00"))
            ' '' ''    'SubTotal = dtGridViewBultos(7, 0).Value + dtGridViewBultos(7, 1).Value + dtGridViewBultos(7, 2).Value
            ' '' ''    SubTotal = fnNumeroDecimal(dtGridViewBultos(7, 0).Value.ToString) + fnNumeroDecimal(dtGridViewBultos(7, 1).Value.ToString) + fnNumeroDecimal(dtGridViewBultos(7, 2).Value.ToString)
            ' '' ''End If
            Dim Total_Costo As Double = 0
            Dim Sub_Total As Double = 0

            '' '' ''If SubTotal > 0 Then
            '' '' ''    Total_Costo = fnTECHO(SubTotal * (1 + (dtoUSUARIOS.iIGV / 100)))
            '' '' ''    Sub_Total = Total_Costo / (1 + (dtoUSUARIOS.iIGV / 100))
            '' '' ''End If


            Dim SUB_TOTAL_GENERAL As Double = 0
            If (1 - Val(Me.txtPorcernt_Descuento.Text) / 100) > 0 Then
                SUB_TOTAL_GENERAL = fnTECHO(Format(SubTotal * (1 + (dtoUSUARIOS.iIGV / 100)) * (1 - Val(Me.txtPorcernt_Descuento.Text) / 100), "###,###,###.00"))
                Total_Costo = SUB_TOTAL_GENERAL
                Sub_Total = SUB_TOTAL_GENERAL / (1 + (dtoUSUARIOS.iIGV / 100))
            Else
                If (1 - Val(Me.txtPorcernt_Descuento.Text) / 100) = 0 Then
                    SUB_TOTAL_GENERAL = 0
                End If
            End If

            ' '' ''txtSub_Total.Text = Format(Sub_Total, "###,###,###.00")
            ' '' ''txtMonto_IGV.Text = Format(Total_Costo - Sub_Total, "###,###,###.00")
            '''''txtCosto_Total.Text = Format(Total_Costo, "###,###,###.00")

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub fnCalcularCostoDescuento()
        Try
            ' '' ''Dim valor1 As Double = Val(dtGridViewBultos(4, 0).Value)
            ' '' ''Dim valor2 As Double = Val(dtGridViewBultos(2, 0).Value)

            '' '' ''dtGridViewBultos(6, 0).Value = Format((valor1 * tarifa_Peso) * Val(Me.txtPorcernt_Descuento.Text) / 100, "###,###,###.00")
            '' '' ''dtGridViewBultos(7, 0).Value = Format((valor1 * tarifa_Peso) * (1 - Val(Me.txtPorcernt_Descuento.Text) / 100), "###,###,###.00")

            ' '' ''dtGridViewBultos(6, 0).Value = "0.00"
            ' '' ''dtGridViewBultos(7, 0).Value = Format((valor1 * tarifa_Peso), "###,###,###.00")

            ' '' ''valor1 = Val(dtGridViewBultos(4, 1).Value)
            ' '' ''valor2 = Val(dtGridViewBultos(2, 1).Value)
            '' '' ''dtGridViewBultos(6, 1).Value = Format((valor1 * tarifa_Volumen) * Val(Me.txtPorcernt_Descuento.Text) / 100, "###,###,###.00")
            '' '' ''dtGridViewBultos(7, 1).Value = Format((valor1 * tarifa_Volumen) * (1 - Val(Me.txtPorcernt_Descuento.Text) / 100), "###,###,###.00")
            ' '' ''dtGridViewBultos(6, 1).Value = "0.00"
            ' '' ''dtGridViewBultos(7, 1).Value = Format((valor1 * tarifa_Volumen), "###,###,###.00")

            ' '' ''valor1 = Val(dtGridViewBultos(4, 2).Value)
            ' '' ''valor2 = Val(dtGridViewBultos(2, 2).Value)

            '' '' ''dtGridViewBultos(6, 2).Value = Format((valor2 * tarifa_Sobre), "###,###,###.00")
            ' '' ''dtGridViewBultos(7, 2).Value = Format((valor2 * tarifa_Sobre), "###,###,###.00")


            '----------------------------------------------------------------------------------------------------------------------------
            ' '' ''If iControlFacturacion > 0 Then
            ' '' ''    ObjVentaGiroContado.v_MONTO_BASE = Monto_Base
            ' '' ''Else
            ' '' ''    If iControlMonto_Base = 0 Then
            ' '' ''        ObjVentaGiroContado.v_MONTO_BASE = 0
            ' '' ''        Monto_Base = 0
            ' '' ''    Else
            ' '' ''        ObjVentaGiroContado.v_MONTO_BASE = Monto_Base
            ' '' ''    End If
            ' '' ''End If
            '----------------------------------------------------------------------------------------------------------------------------

            '' '' ''ObjVentaGiroContado.v_MONTO_BASE = Me.txtMontoBase.Text


            Dim SubTotal As Double = 0
            ' '' ''If Val(dtGridViewBultos(7, 0).Value) + Val(dtGridViewBultos(7, 1).Value) > 0 Then
            ' '' ''    If iControlMonto_Base = 1 Then
            ' '' ''        SubTotal = Monto_Base + fnNumeroDecimal(dtGridViewBultos(7, 0).Value) + fnNumeroDecimal(dtGridViewBultos(7, 1).Value) + fnNumeroDecimal(dtGridViewBultos(7, 2).Value)
            ' '' ''    Else
            ' '' ''        SubTotal = fnNumeroDecimal(dtGridViewBultos(7, 0).Value) + fnNumeroDecimal(dtGridViewBultos(7, 1).Value) + fnNumeroDecimal(dtGridViewBultos(7, 2).Value)
            ' '' ''    End If

            ' '' ''Else
            ' '' ''    SubTotal = fnNumeroDecimal(dtGridViewBultos(7, 0).Value) + fnNumeroDecimal(dtGridViewBultos(7, 1).Value) + fnNumeroDecimal(dtGridViewBultos(7, 2).Value)
            ' '' ''End If

            '' '' ''SubTotal = CDbl(Me.txtMontoBase.Text) + CDbl(Me.TxtCargo.Text)


            Dim IGV As Double = dtoUSUARIOS.iIGV / 100
            Dim SUB_TOTAL_GENERAL As Double = 0
            If (1 - Val(Me.txtPorcernt_Descuento.Text) / 100) > 0 Then
                SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SubTotal * (1 - Val(Me.txtPorcernt_Descuento.Text) / 100), "###,###,###.00"))
            Else
                If (1 - Val(Me.txtPorcernt_Descuento.Text) / 100) = 0 Then
                    SUB_TOTAL_GENERAL = 0
                End If
            End If

            'Dim SUB_TOTAL_GENERAL As Double = fnTECHO(Format((1 + IGV) * SubTotal, "###,###,###.00"))

            'Dim TotalCosto As Double = ((1 + IGV) * SubTotal) * (1 - Val(Me.txtPorcernt_Descuento.Text) / 100)

            '' '' ''txtSub_Total.Text = Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00")
            '' '' ''txtMonto_IGV.Text = Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00")
            '''''''''txtCosto_Total.Text = Format(SUB_TOTAL_GENERAL, "###,###,###.00")


            'txtSub_Total.Text = SubTotal
            'txtMonto_IGV.Text = Format(SubTotal * dtoUSUARIOS.iIGV / 100, "###,###,###.00")
            'txtCosto_Total.Text = Format(SubTotal * (1 + dtoUSUARIOS.iIGV / 100), "###,###,###.00")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmbAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectedIndexChanged
        Try
            Dim idAgencia As Integer
            idAgencia = Int(cmbAgencia.SelectedIndex)
            If idAgencia >= 0 Then
                idAgencia = IIf(cmbAgencia.SelectedIndex.ToString() <> "", Int(objGuiaEnvio.coll_Lista_Agencias(cmbAgencia.SelectedIndex.ToString())), 0)
                'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper   
                If objGuiaEnvio.fnFILTRO_USUARIO_X_AGENCIA(idAgencia) = True Then
                    '01/09/2009 - Mod. x datahelper x datatable 
                    'ModuUtil.LlenarComboIDs(objGuiaEnvio.rst_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, 0)
                    ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, 0)
                Else
                    NingunoComboIDs(cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Try
            SelectMenu(1)
            fnNUEVO()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPorcernt_Descuento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPorcernt_Descuento.TextChanged
        Try
            If Val(txtPorcernt_Descuento.Text) > 0 Then
                txtMemo.Visible = True
                lbMemo.Visible = True

                'txtMemo.Text = ""
            Else
                txtMemo.Visible = False
                lbMemo.Visible = False
                'txtMemo.Text = ""
            End If
            fnCalcularCostoDescuento()
        Catch ex As Exception

        End Try

    End Sub

    Public Function fnBuscarFacturas() As Boolean
        Try
            objControlFacturasBol.origen = Int(objGuiaEnvio.coll_Lista_Origen(cmbOrigen.SelectedIndex.ToString))
            objControlFacturasBol.destino = Int(objGuiaEnvio.coll_Lista_Destino(cmbDestino.SelectedIndex.ToString))
            If objControlFacturasBol.iControl = 5 Then
                objControlFacturasBol.idUsuario = ObjBusquedaClientes.idPersona
            Else
                objControlFacturasBol.idUsuario = Int(objGuiaEnvio.coll_Lista_Usuarios(cmbUsuarios.SelectedIndex.ToString))
            End If


            Dim strNroDoc As String() = Split(txtNroSerieDoc.Text, "-")
            If strNroDoc.Length > 1 Then
                If Val(strNroDoc(0)) > 0 And Val(strNroDoc(1)) > 0 Then
                    objControlFacturasBol.serie = strNroDoc(0)
                    objControlFacturasBol.nrodoc = strNroDoc(1)
                Else
                    objControlFacturasBol.serie = "0"
                    objControlFacturasBol.nrodoc = "0"
                End If

            Else
                objControlFacturasBol.serie = "0"
                objControlFacturasBol.nrodoc = "0"
            End If
            objControlFacturasBol.RucRazonSocial = IIf(txtClienteDNIRUC.Text <> "", txtClienteDNIRUC.Text, "0")
            objControlFacturasBol.estadoFactura = Int(objGuiaEnvio.coll_Lista_Estados(cmbEstados.SelectedIndex.ToString))
            objControlFacturasBol.fecha_inicio = dtFechaInicio.Text
            objControlFacturasBol.fecha_final = dtFechaFin.Text
            If objControlFacturasBol.fnControlfacturasBol_() = True Then
                dtGridViewControl_FACBOL.Refresh()
                'dtControl_FAC.Clear()
                'daControl_FAC.Fill(dtControl_FAC, objControlFacturasBol.rstFacturasBol)
                dvControl_FAC = objControlFacturasBol.dt_rstFacturasBol.DefaultView
                bformatImage = True
                dtGridViewControl_FACBOL.DataSource = dvControl_FAC
                dtGridViewControl_FACBOL.Refresh()
                lbNroRegistro.Text = dvControl_FAC.Count
                If dvControl_FAC.Count = 0 Then
                    MsgBox("No Se han Encontrado Ninguna Resultado para esta busqueda..., en toda la Base de datos", MsgBoxStyle.Information, "Seguridad Sistema")
                End If
                bformatImage = True
            Else
                MsgBox("No Se han Encontrado Ninguna Resultado para esta busqueda..., en toda la Base de datos", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return False
    End Function

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        objControlFacturasBol.iControl = 1
        fnBuscarFacturas()
    End Sub

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        Try
            'objLOG.fnLog("ANULACION DE UN DOCUMENTO....")
            If dtGridViewControl_FACBOL.Rows().Count = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            If dtGridViewControl_FACBOL.Rows().Count = row Then
                Return
            End If
            ObjProcesosVentaContado.iControl = 1
            ObjProcesosVentaContado.idFacturaBoleta = dtGridViewControl_FACBOL.CurrentRow.Cells("idfactura").Value
            'datahelper
            'If ObjVentaGiroContado.fnValidarProceso(ObjProcesosVentaContado.idFacturaBoleta) = False Then
            If ObjVentagiroContado.fnValidarProceso_dt(ObjProcesosVentaContado.idFacturaBoleta) = False Then
                MsgBox("No puede Realizar esta Operacion, Ya Esta Anulada...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If

            If ObjProcesosVentaContado.ShowDialog() = Windows.Forms.DialogResult.Yes Then
                'datahelper
                'If ObjVentagiroContado.fnANULDEVVENAS(ObjProcesosVentaContado.iControl, ObjProcesosVentaContado.idFacturaBoleta, 0) = True Then
                If ObjVentagiroContado.fnANULDEVVENAS_dt(ObjProcesosVentaContado.iControl, ObjProcesosVentaContado.idFacturaBoleta, 0) = True Then
                    If ObjVentagiroContado.v_CONTROL_ANUDEV = 1 Then
                        dtGridViewControl_FACBOL.CurrentRow.Cells("idestado_factura").Value = 2
                        dtGridViewControl_FACBOL.UpdateCellValue(0, row)
                        'objLOG.fnLog("ANULACION CORRECTA....")
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub btnDevolucion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDevolucion.Click
        Try
            'objLOG.fnLog("INICIO DE UNA DEVOLUCION....")
            If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                Return
            End If
            ObjProcesosVentaContado.iControl = 2
            ObjProcesosVentaContado.idFacturaBoleta = dtGridViewControl_FACBOL.Rows(row).Cells(1).Value
            'datahelper
            'If ObjVentaGiroContado.fnValidarProceso(ObjProcesosVentaContado.idFacturaBoleta) = False Then
            If ObjVentagiroContado.fnValidarProceso_dt(ObjProcesosVentaContado.idFacturaBoleta) = False Then
                MsgBox("No puede Realizar esta Operacion, Ya se realizo la Devolucion...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            If ObjProcesosVentaContado.ShowDialog() = Windows.Forms.DialogResult.Yes Then
                Dim x_PORCENT_DEVOLUCION As Double = ObjProcesosVentaContado.x_PORCENT_DEVOLUCION
                'datahelper
                'If ObjVentaGiroContado.fnANULDEVVENAS(ObjProcesosVentaContado.iControl, ObjProcesosVentaContado.idFacturaBoleta, ObjProcesosVentaContado.x_PORCENT_DEVOLUCION) = True Then
                If ObjVentagiroContado.fnANULDEVVENAS_dt(ObjProcesosVentaContado.iControl, ObjProcesosVentaContado.idFacturaBoleta, ObjProcesosVentaContado.x_PORCENT_DEVOLUCION) = True Then
                    dtGridViewControl_FACBOL.Rows(row).DataGridView(IDGRIESTADO_REG, row).Value = 29
                    dtGridViewControl_FACBOL.UpdateCellValue(0, row)
                    'objLOG.fnLog("DEVOLUCION REALIZADA CORRECTAMENTE....")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub dtGridViewControl_FACBOL_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtGridViewControl_FACBOL.CellFormatting
        Dim strvar As String = ""
        Dim mrg As String
        Try
            strvar = e.RowIndex.ToString()
            If bformatImage = True Then
                If e.ColumnIndex = 0 Then
                    Dim IdEstado As Integer
                    If e.RowIndex >= 0 And dtGridViewControl_FACBOL.Rows().Count - 1 >= e.RowIndex Then
                        'MsgBox(dtGridViewControl_FACBOL.Rows(e.RowIndex).Cells(28).Value)

                        If IsDBNull(dtGridViewControl_FACBOL.CurrentRow.Cells("Idestado_Factura").Value) = False Then
                            'IdEstado = dtGridViewControl_FACBOL.CurrentRow.Cells("Idestado_Factura").Value
                            IdEstado = dtGridViewControl_FACBOL.Rows(e.RowIndex).Cells("Idestado_Factura").Value
                            'dtGridViewControl_FACBOL.CurrentRow.Cells("Idestado_Factura").Value.Tag = 1
                            'mrg = dtGridViewControl_FACBOL.CurrentRow.Cells("nro_factura").Value
                        Else
                            IdEstado = 0
                        End If
                        'IdEstado = IIf(IsNothing(DataGridViewUser.Rows(e.RowIndex).Cells(7).Value), 0, DataGridViewUser.Rows(e.RowIndex).Cells(7).Value)
                        Select Case IdEstado
                            Case 27
                                e.Value = bmpFACTURA_EMITIDA
                            Case 2
                                e.Value = bmpFACTURA_ANULADA
                            Case 29
                                e.Value = bmpFACTURA_DEVUELTA
                            Case Else
                                e.Value = bmpNoImagen
                        End Select
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema" & strvar)
        End Try
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub cmbTipo_Entrega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo_Entrega.SelectedIndexChanged
        Try
            Dim iidTipo As Integer = ObjVentagiroContado.coll_t_Tipo_Entrega(cmbTipo_Entrega.SelectedIndex.ToString)
            If iidTipo = 1 Then
                txtDireccionDestinatario.Text = "AGENCIA"
                txtDireccionDestinatario.Enabled = False
            Else
                txtDireccionDestinatario.Text = ""
                txtDireccionDestinatario.Enabled = True
            End If

        Catch ex As Exception

        End Try
    End Sub
    'Public Function fnImprimirEtiquetasFAC_II2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim prn As New PrinterTxt.PrintTxt
    '        Dim cadena As String = ""
    '        Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
    '        prn.Nombre_impresora = "PRNZEBRA"
    '        Dim EXISTE As Boolean = prn.SetearImpresora()

    '        ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentagiroContado.v_IDUNIDAD_ORIGEN)
    '        ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentagiroContado.v_IDUNIDAD_DESTINO)
    '        ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
    '        ObjCODIGOBARRA.Cantidad = ObjVentagiroContado.v_CANTIDAD_ETIQUETAS

    '        Dim I As Int16 = 1
    '        'While objGuiaEnvio.cur_codBarras.EOF = False And objGuiaEnvio.cur_codBarras.BOF = False
    '        While ObjVentagiroContado.Cur_CODIGOBARRAS.EOF = False And ObjVentagiroContado.Cur_CODIGOBARRAS.BOF = False
    '            ObjCODIGOBARRA.CodigoBarra = ObjVentagiroContado.Cur_CODIGOBARRAS.Fields.Item(0).Value

    '            'prn.EscribeLinea("^XA")
    '            'prn.EscribeLinea("^PW400")
    '            'prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD " & ObjCODIGOBARRA.NroDOC & "          " & I.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & "^FS")
    '            ''prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD " & Me.TextBox1.Text & "^FS")
    '            ''prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & Me.TextBox2.Text & I & "^FS")
    '            'prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.clinte & "^FS")
    '            'prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & ObjCODIGOBARRA.CodigoBarra & "^FS")
    '            'prn.EscribeLinea("^FT17,141^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
    '            'prn.EscribeLinea("^FT96,142^A0N,39,45^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")
    '            'prn.EscribeLinea("^FT305,188^AAN,18,10^FH\^FDTEPSAC^FS")
    '            'prn.EscribeLinea("^FT183,188^AAN,18,10^FH\^FD" & HoraActual & "^FS")
    '            'prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & ObjCODIGOBARRA.Fecha & "^FS")
    '            'prn.EscribeLinea("^PQ1,0,1,Y")
    '            'prn.EscribeLinea("^XZ")

    '            prn.EscribeLinea("<STX><ESC>C0<ETX>")
    '            prn.EscribeLinea("<STX><ESC>k<ETX>")
    '            prn.EscribeLinea("<STX><SI>N60<ETX>")
    '            prn.EscribeLinea("<STX><SI>L197<ETX>")
    '            prn.EscribeLinea("<STX><SI>S20<ETX>")
    '            prn.EscribeLinea("<STX><SI>d0<ETX>")
    '            prn.EscribeLinea("<STX><SI>h0,0;<ETX>")
    '            prn.EscribeLinea("<STX><SI>l8<ETX>")
    '            prn.EscribeLinea("<STX><SI>I3<ETX>")
    '            prn.EscribeLinea("<STX><SI>F20<ETX>")
    '            prn.EscribeLinea("<STX><SI>D0<ETX>")
    '            prn.EscribeLinea("<STX><SI>t0<ETX>")
    '            prn.EscribeLinea("<STX><SI>W394<ETX>")
    '            prn.EscribeLinea("<STX><SI>g1,567<ETX>")
    '            prn.EscribeLinea("<STX><ESC>P<ETX>")
    '            prn.EscribeLinea("<STX>E*;F*;<ETX>")
    '            prn.EscribeLinea("<STX>L1;<ETX>")
    '            prn.EscribeLinea("<STX>D0;<ETX>")
    '            prn.EscribeLinea("<STX>H0;o165,12;f3;c25;h15;w15;d3," & ObjCODIGOBARRA.clinte & ";<ETX>")
    '            prn.EscribeLinea("<STX>D1;<ETX>")
    '            prn.EscribeLinea("<STX>H1;o130,13;f3;c25;h9;w15;d3," & ObjCODIGOBARRA.NroDOC & " -" & I.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & ";<ETX>")
    '            prn.EscribeLinea("<STX>H2;o88,11;f3;c25;h11;w11;d3," & ObjCODIGOBARRA.Origen & " / ;<ETX>")
    '            'Modificado por Omendoza 24/01/2007 
    '            'prn.EscribeLinea("<STX>B3;o96,180;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
    '            prn.EscribeLinea("<STX>B3;o96,160;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
    '            prn.EscribeLinea("<STX>H4;o14,13;f3;c25;h7;w7;d3," & ObjCODIGOBARRA.Fecha & ";<ETX>")
    '            prn.EscribeLinea("<STX>H5;o14,200;f3;c25;h7;w7;d3," & HoraActual & ";<ETX>")
    '            prn.EscribeLinea("<STX>H6;o14,300;f3;c25;h7;w7;d3,TEPSAC;<ETX>")
    '            prn.EscribeLinea("<STX>H7;o102,96;f3;c25;h17;w16;d3," & ObjCODIGOBARRA.Destino & ";<ETX>")
    '            prn.EscribeLinea("<STX>R<ETX>")
    '            prn.EscribeLinea("<STX><ESC>E*<CAN><ETX>")
    '            prn.EscribeLinea("<STX><RS>1<US>1<ETB><ETX>")


    '            prn.EscribeLinea(cadena)
    '            ObjVentagiroContado.Cur_CODIGOBARRAS.MoveNext()
    '            I = I + 1
    '        End While
    '        prn.FinDoc()
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    'Public Function fnImprimirEtiquetas2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim prn As New PrinterTxt.PrintTxt
    '        Dim cadena As String = ""
    '        Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
    '        prn.Nombre_impresora = "PRNZEBRA"
    '        Dim EXISTE As Boolean = prn.SetearImpresora()

    '        ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentagiroContado.v_IDUNIDAD_ORIGEN)
    '        ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentagiroContado.v_IDUNIDAD_DESTINO)
    '        ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
    '        ObjCODIGOBARRA.Cantidad = ObjVentagiroContado.v_CANTIDAD_ETIQUETAS

    '        Dim I As Int16 = 1
    '        While ObjVentagiroContado.Cur_CODIGOBARRAS.EOF = False And ObjVentagiroContado.Cur_CODIGOBARRAS.BOF = False
    '            ObjCODIGOBARRA.CodigoBarra = ObjVentagiroContado.Cur_CODIGOBARRAS.Fields.Item(0).Value
    '            prn.EscribeLinea("^XA")
    '            prn.EscribeLinea("^PW400")
    '            prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD " & ObjCODIGOBARRA.NroDOC & "          " & I.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & "^FS")
    '            'prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD " & Me.TextBox1.Text & "^FS")
    '            'prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & Me.TextBox2.Text & I & "^FS")
    '            prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.clinte & "^FS")
    '            prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & ObjCODIGOBARRA.CodigoBarra & "^FS")
    '            prn.EscribeLinea("^FT17,141^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
    '            prn.EscribeLinea("^FT96,142^A0N,39,45^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")
    '            prn.EscribeLinea("^FT305,188^AAN,18,10^FH\^FDTEPSAC^FS")
    '            prn.EscribeLinea("^FT183,188^AAN,18,10^FH\^FD" & HoraActual & "^FS")
    '            prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & ObjCODIGOBARRA.Fecha & "^FS")
    '            prn.EscribeLinea("^PQ1,0,1,Y")
    '            prn.EscribeLinea("^XZ")
    '            prn.EscribeLinea(cadena)
    '            ObjVentagiroContado.Cur_CODIGOBARRAS.MoveNext()
    '            I = I + 1
    '        End While
    '        prn.FinDoc()
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Private Sub btnVerData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerData.Click
        Try
            If dtGridViewControl_FACBOL.Rows().Count = 0 Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            If dtGridViewControl_FACBOL.Rows().Count = row Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            Dim v_idFacura As Integer = dtGridViewControl_FACBOL.Rows(row).Cells("idfactura").Value
            'datahelper
            'If ObjVentaGiroContado.fnVERDATA(v_idFacura) = True Then
            If ObjVentagiroContado.fnVERDATA_dt(v_idFacura) = True Then
                operacion_data_base = 2
                SelectMenu(1)
                fnVERDATOSVENTACONTADO()
                ObjVentagiroContado.fnClearOBJ()
            Else
                MsgBox("No puede cargar esta data, faltan datos...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub
    Private Function fnVERDATOSVENTACONTADO() As Boolean
        Try
            If fnBuscarCliente() = True Then
                txtCliente_Destinatario.Focus()
                txtCliente_Destinatario.SelectAll()
            End If
            'datahelper
            'ObjVentagiroContado.fnGetAgencias(ObjVentagiroContado.v_IDUNIDAD_DESTINO)
            ObjVentagiroContado.fnGetAgencias_dt(ObjVentagiroContado.v_IDUNIDAD_DESTINO)

            'datahelper
            'ModuUtil.LlenarComboIDs(ObjVentaGiroContado.rstVarAgencias, cmbAgenciaVenta, ObjVentaGiroContado.coll_AgenciasVenta, ObjVentaGiroContado.v_IDAGENCIAS_DESTINO)
            ModuUtil.LlenarCombo2(ObjVentagiroContado.rstVarAgencias_dt, cmbAgenciaVenta, ObjVentagiroContado.coll_AgenciasVenta, ObjVentagiroContado.v_IDAGENCIAS_DESTINO)

            'datahelper
            'ObjVentagiroContado.cur_t_tipo_comprobante.MoveFirst()
            'ObjVentagiroContado.cur_t_Tipo_Entrega.MoveFirst()
            'ModuUtil.LlenarComboIDs(ObjVentagiroContado.cur_t_Tipo_Entrega, cmbTipo_Entrega, ObjVentagiroContado.coll_t_Tipo_Entrega, ObjVentagiroContado.v_IDTIPO_ENTREGA)
            'ObjVentagiroContado.cur_Tipo_Pago.MoveFirst()
            'ObjVentagiroContado.cur_t_Forma_Pago.MoveFirst()

            ModuUtil.LlenarCombo2(ObjVentagiroContado.cur_t_Tipo_Entrega_dt, cmbTipo_Entrega, ObjVentagiroContado.coll_t_Tipo_Entrega, ObjVentagiroContado.v_IDTIPO_ENTREGA)

            txtSERIE.Text = ObjVentagiroContado.v_SERIE_FACTURA
            txtNroDocFACBOL.Text = ObjVentagiroContado.v_NRO_FACTURA
            Me.Text = " CIUDAD ORIGEN : " & ObjVentagiroContado.v_UNIDAD_ORIGEN
            txtiWinDestino.Text = ObjVentagiroContado.v_UNIDAD_DESTINO
            txtFecha.Text = ObjVentagiroContado.v_FECHA_FACTURA

            Me.cbidcondi_giro.SelectedValue = ObjVentagiroContado.v_IDCONDI_GIRO
            Me.cbidtipo_giro.SelectedValue = ObjVentagiroContado.v_IDTIPO_GIRO


            txtDocCliente_Remitente.Text = ObjVentagiroContado.v_NRO_DNI_RUC
            txtCliente_Remitente.Text = ObjVentagiroContado.v_NOMBRES_RASONSOCIAL
            txtDireccionRemitente.Text = ObjVentagiroContado.v_DIRECCION_REMITENTE
            txtPorcernt_Descuento.Text = ObjVentagiroContado.v_MONTO_DESCUENTO


            txtDNIDestinatario.Text = ObjVentagiroContado.v_NRO_DOC_DESTINATARIO


            txtCliente_Destinatario.Text = ObjVentagiroContado.v_NOMBRES_DESTINATARIO


            txtDireccionDestinatario.Text = ObjVentagiroContado.v_DIRECCION_DESTINATARIO



            txtTelefonoDestinatario.Text = ObjVentagiroContado.v_TELE_DESTI
            txtMemo.Text = ObjVentagiroContado.v_MEMO
            txtCosto_Total.Text = Format(ObjVentagiroContado.v_TOTAL_COSTO, "###,###,###.00")
            TxtMontoGirar.Text = Format(ObjVentagiroContado.v_MONTO_GIRADO, "###,###,###.00")

            If ObjVentagiroContado.v_IDTIPO_PAGO = 2 Then

                lbTargeta.Visible = True
                cmbTargeta.Visible = True
                'datahelper
                'ObjVentagiroContado.cur_T_TARJETAS.MoveFirst()
                'ModuUtil.LlenarComboIDs(ObjVentagiroContado.cur_T_TARJETAS, cmbTargeta, ObjVentagiroContado.coll_T_TARJETAS, ObjVentagiroContado.v_IDTARJETAS)
                ModuUtil.LlenarCombo2(ObjVentagiroContado.cur_T_TARJETAS_dt, cmbTargeta, ObjVentagiroContado.coll_T_TARJETAS, ObjVentagiroContado.v_IDTARJETAS)
            Else
                lbTargeta.Visible = False
                cmbTargeta.Visible = False
            End If
            fnEnableStadoControl(False)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return False
    End Function
    Private Function fnPISO(ByVal monto As String, ByVal PISOTECHO As Boolean, ByVal nroDigito As Integer) As String

        Dim strPISOTECHO As String = ""
        Try
            Dim ArrayStr() As String = Split(monto, ".")
            If ArrayStr.Length > 1 Then
                Dim var As Integer = Int(ArrayStr(0))
                If Len(var) = 1 Then

                End If
                If Len(var) = 2 Then

                End If
                If Len(var) = 3 Then

                End If

                If PISOTECHO = True Then

                Else

                End If
                strPISOTECHO = ArrayStr(1) & ArrayStr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return strPISOTECHO
    End Function
    Public Function fnEnableStadoControl(ByVal control As Boolean) As Boolean
        Dim flag As Boolean = False
        Try
            txtiWinDestino.ReadOnly = control
            txtSERIE.ReadOnly = control
            txtNroDocFACBOL.ReadOnly = control

            cbidtipo_giro.Enabled = IIf(control = False, True, False)
            cmbAgenciaVenta.Enabled = IIf(control = False, True, False)
            cmbTipo_Entrega.Enabled = IIf(control = False, True, False)
            cbidcondi_giro.Enabled = IIf(control = False, True, False)
            cmbTargeta.Enabled = IIf(control = False, True, False)

            ' txtFecha.ReadOnly = control
            '''''xtNroTarjeta.ReadOnly = control
            txtDocCliente_Remitente.ReadOnly = control
            txtCliente_Remitente.ReadOnly = control
            txtDireccionRemitente.ReadOnly = control
            '' '' ''txtContactoRemitente.ReadOnly = control

            '' '' ''txtDNIContacto.ReadOnly = control

            '' '' ''txtTelefonoRemitente.ReadOnly = control
            txtPorcernt_Descuento.ReadOnly = control
            txtMemo.ReadOnly = control
            txtDNIDestinatario.ReadOnly = control
            txtCliente_Destinatario.ReadOnly = control
            txtDireccionDestinatario.ReadOnly = control
            txtTelefonoDestinatario.ReadOnly = control
            ' '' ''dtGridViewBultos.ReadOnly = control
        Catch ex As Exception

        End Try
    End Function
    Private Function fnBuscarCliente() As Boolean
        Dim flag As Boolean = False
        Try
            Dim valor_nro_documento As Long
            Dim valor_razon_social As String
            If operacion_data_base = 2 Then
                If IsNumeric(dtGridViewControl_FACBOL.Rows(dtGridViewControl_FACBOL.SelectedRows.Item(0).Index).Cells("dni_ruc").Value) Then
                    'MsgBox("-" + (dtGridViewControl_FACBOL.Rows(dtGridViewControl_FACBOL.SelectedRows.Item(0).Index).Cells("dni_ruc").Value) + "-")
                    valor_nro_documento = dtGridViewControl_FACBOL.Rows(dtGridViewControl_FACBOL.SelectedRows.Item(0).Index).Cells("dni_ruc").Value
                Else
                    valor_nro_documento = 0
                End If
                valor_razon_social = dtGridViewControl_FACBOL.Rows(dtGridViewControl_FACBOL.SelectedRows.Item(0).Index).Cells("razon_social").Value
            Else
                valor_nro_documento = Me.txtDocCliente_Remitente.Text
                valor_razon_social = Me.txtCliente_Remitente.Text
            End If
            'datahelper
            'If ObjVentaGiroContado.fnBuscarCliente(1, valor_nro_documento, IIf(Len(valor_razon_social.Trim) = 0, "@", valor_razon_social), dtoUSUARIOS.m_idciudad, ObjVentaGiroContado.v_IDUNIDAD_DESTINO) = True Then
            If ObjVentagiroContado.fnBuscarCliente_dt(1, valor_nro_documento, IIf(Len(valor_razon_social.Trim) = 0, "@", valor_razon_social), dtoUSUARIOS.m_idciudad, ObjVentagiroContado.v_IDUNIDAD_DESTINO) = True Then
                flag = True
                ObjVentagiroContado.v_IDPERSONA = ObjVentagiroContado.cur_persona_dt.Rows(0).Item(0)
                txtCliente_Remitente.Text = ObjVentagiroContado.cur_persona_dt.Rows(0).Item(1)
                iControlMonto_Base = ObjVentagiroContado.cur_persona_dt.Rows(0).Item(3)
                txtPorcernt_Descuento.Text = IIf(ObjVentagiroContado.cur_persona_dt.Rows(0).Item(4) <> 0, ObjVentagiroContado.cur_persona_dt.Rows(0).Item(4), "")

                '//CONTACTO REMITENTE
                If ObjVentagiroContado.cur_cont_origen_dt.Rows.Count > 0 Then
                    ObjVentagiroContado.v_IDPERSONA_ORIGEN = Int(ObjVentagiroContado.cur_cont_origen_dt.Rows(0).Item(0).ToString)
                Else
                    ObjVentagiroContado.v_IDPERSONA_ORIGEN = 0
                End If

                '//CONTACTO DIRECCIONES REMITENTE
                If ObjVentagiroContado.cur_dire_origen_dt.Rows.Count > 0 Then
                    ObjVentagiroContado.v_IDDIREECION_ORIGEN = Int(ObjVentagiroContado.cur_dire_origen_dt.Rows(0).Item(0).ToString)
                    txtDireccionRemitente.Text = ObjVentagiroContado.cur_dire_origen_dt.Rows(0).Item(1).ToString
                    fnCargar_iWin_dt(txtDireccionRemitente, ObjVentagiroContado.cur_dire_origen_dt, coll_Direccion_Remitente, iWinDireccion_Remitente, ObjVentagiroContado.v_IDDIREECION_ORIGEN)
                Else
                    txtDireccionRemitente.Text = ""
                    ObjVentagiroContado.v_IDDIREECION_ORIGEN = 0
                End If

                '//CONTACTO DESTINATARIO
                If ObjVentagiroContado.cur_cont_destino_dt.Rows.Count > 0 Then
                    ObjVentagiroContado.v_IDCONTACTO_DESTINO = Int(ObjVentagiroContado.cur_cont_destino_dt.Rows(0).Item(0).ToString)
                    txtCliente_Destinatario.Text = ObjVentagiroContado.cur_cont_destino_dt.Rows(0).Item(1).ToString
                    txtDNIDestinatario.Text = ObjVentagiroContado.cur_cont_destino_dt.Rows(0).Item(2).ToString
                    fnCargar_iWin2_dt2(txtCliente_Destinatario, ObjVentagiroContado.cur_cont_destino_dt, coll_Nombres_Destinatario, iWinContacto_Destinatario, ObjVentagiroContado.v_IDCONTACTO_DESTINO, iWinPerosaDNI_Destino)
                Else
                    ObjVentagiroContado.v_IDCONTACTO_DESTINO = 0
                    txtCliente_Destinatario.Text = ""
                    txtDNIDestinatario.Text = ""
                End If

                '//CONTACTO DIRECCIONES DESTINATARIO
                If ObjVentagiroContado.cur_dire_destino_dt.Rows.Count > 0 Then
                    ObjVentagiroContado.v_IDDIREECION_DESTINO = Int(ObjVentagiroContado.cur_dire_destino_dt.Rows(0).Item(0).ToString)
                    txtDireccionDestinatario.Text = ObjVentagiroContado.cur_dire_destino_dt.Rows(0).Item(1).ToString
                    fnCargar_iWin_dt(txtDireccionDestinatario, ObjVentagiroContado.cur_dire_destino_dt, coll_Direccion_Destinatario, iWinDireccion_Destinatario, ObjVentagiroContado.v_IDDIREECION_DESTINO)
                Else
                    txtDireccionDestinatario.Text = ""
                    ObjVentagiroContado.v_IDDIREECION_DESTINO = 0
                End If


                Dim tmpTipoEntrega As Integer = ObjVentagiroContado.coll_t_Tipo_Entrega(Me.cmbTipo_Entrega.SelectedIndex.ToString)
                If tmpTipoEntrega = 1 Then
                    txtDireccionDestinatario.Text = "AGENCIA"
                Else
                    If txtDireccionDestinatario.Text = "AGENCIA" Then
                        txtDireccionDestinatario.Text = ""
                    End If
                End If

                'datahelper
                'flag = True
                'ObjVentagiroContado.v_IDPERSONA = ObjVentagiroContado.cur_persona.Fields.Item(0).Value
                'txtCliente_Remitente.Text = ObjVentagiroContado.cur_persona.Fields.Item(1).Value
                'iControlMonto_Base = ObjVentagiroContado.cur_persona.Fields.Item(3).Value
                'txtPorcernt_Descuento.Text = IIf(ObjVentagiroContado.cur_persona.Fields.Item(4).Value <> 0, ObjVentagiroContado.cur_persona.Fields.Item(4).Value, "")

                ''//CONTACTO REMITENTE
                'If ObjVentagiroContado.cur_cont_origen.BOF = False And ObjVentagiroContado.cur_cont_origen.EOF = False Then
                '    ObjVentagiroContado.v_IDPERSONA_ORIGEN = Int(ObjVentagiroContado.cur_cont_origen.Fields.Item(0).Value.ToString)
                'Else
                '    ObjVentagiroContado.v_IDPERSONA_ORIGEN = 0
                'End If

                ''//CONTACTO DIRECCIONES REMITENTE
                'If ObjVentagiroContado.cur_dire_origen.BOF = False And ObjVentagiroContado.cur_dire_origen.EOF = False Then
                '    ObjVentagiroContado.v_IDDIREECION_ORIGEN = Int(ObjVentagiroContado.cur_dire_origen.Fields.Item(0).Value.ToString)
                '    txtDireccionRemitente.Text = ObjVentagiroContado.cur_dire_origen.Fields.Item(1).Value.ToString
                '    fnCargar_iWin(txtDireccionRemitente, ObjVentagiroContado.cur_dire_origen, coll_Direccion_Remitente, iWinDireccion_Remitente, ObjVentagiroContado.v_IDDIREECION_ORIGEN)
                'Else
                '    txtDireccionRemitente.Text = ""
                '    ObjVentagiroContado.v_IDDIREECION_ORIGEN = 0
                'End If

                ''//CONTACTO DESTINATARIO
                'If ObjVentagiroContado.cur_cont_destino.BOF = False And ObjVentagiroContado.cur_cont_destino.EOF = False Then
                '    ObjVentagiroContado.v_IDCONTACTO_DESTINO = Int(ObjVentagiroContado.cur_cont_destino.Fields.Item(0).Value.ToString)
                '    txtCliente_Destinatario.Text = ObjVentagiroContado.cur_cont_destino.Fields.Item(1).Value.ToString
                '    txtDNIDestinatario.Text = ObjVentagiroContado.cur_cont_destino.Fields.Item(2).Value.ToString
                '    fnCargar_iWin2(txtCliente_Destinatario, ObjVentagiroContado.cur_cont_destino, coll_Nombres_Destinatario, iWinContacto_Destinatario, ObjVentagiroContado.v_IDCONTACTO_DESTINO, iWinPerosaDNI_Destino)
                'Else
                '    ObjVentagiroContado.v_IDCONTACTO_DESTINO = 0
                '    txtCliente_Destinatario.Text = ""
                '    txtDNIDestinatario.Text = ""
                'End If

                ''//CONTACTO DIRECCIONES DESTINATARIO
                'If ObjVentagiroContado.cur_dire_destino.BOF = False And ObjVentagiroContado.cur_dire_destino.EOF = False Then
                '    ObjVentagiroContado.v_IDDIREECION_DESTINO = Int(ObjVentagiroContado.cur_dire_destino.Fields.Item(0).Value.ToString)
                '    txtDireccionDestinatario.Text = ObjVentagiroContado.cur_dire_destino.Fields.Item(1).Value.ToString
                '    fnCargar_iWin(txtDireccionDestinatario, ObjVentagiroContado.cur_dire_destino, coll_Direccion_Destinatario, iWinDireccion_Destinatario, ObjVentagiroContado.v_IDDIREECION_DESTINO)
                'Else
                '    txtDireccionDestinatario.Text = ""
                '    ObjVentagiroContado.v_IDDIREECION_DESTINO = 0
                'End If


                'Dim tmpTipoEntrega As Integer = ObjVentagiroContado.coll_t_Tipo_Entrega(Me.cmbTipo_Entrega.SelectedIndex.ToString)
                'If tmpTipoEntrega = 1 Then
                '    txtDireccionDestinatario.Text = "AGENCIA"
                'Else
                '    If txtDireccionDestinatario.Text = "AGENCIA" Then
                '        txtDireccionDestinatario.Text = ""
                '    End If
                'End If
            Else
                ObjVentagiroContado.v_IDPERSONA = 0
                txtCliente_Remitente.Text = ""
                ObjVentagiroContado.v_IDPERSONA_ORIGEN = 0
                ObjVentagiroContado.v_IDCONTACTO_DESTINO = 0
                txtCliente_Destinatario.Text = ""
                txtDNIDestinatario.Text = ""

                txtDireccionRemitente.Text = ""
                ObjVentagiroContado.v_IDDIREECION_ORIGEN = 0
                txtDireccionDestinatario.Text = ""
                ObjVentagiroContado.v_IDDIREECION_DESTINO = 0
            End If
            Dim i As Integer = 0

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            flag = False
        End Try
        Return flag
    End Function
    Public Function fnMantenimienteCliente(ByVal OgirenDestino As Integer, ByVal iNRODOC As TextBox, ByVal iNOMBRES As TextBox, ByVal iDireccion As TextBox, ByVal iCONTROLINSUP As Integer, ByVal iCONTROTABLAS As Integer) As Boolean
        Try

            ObjManteClienteContado.iCONTROLINSUP = iCONTROLINSUP
            ObjManteClienteContado.iCONTROTABLAS = iCONTROTABLAS
            ObjManteClienteContado.v_Rason_Social = iNOMBRES.Text
            ObjManteClienteContado.v_NroDoc = iNRODOC.Text
            ObjManteClienteContado.v_Direccion = iDireccion.Text

            Dim indexof As Integer = -1
            ObjManteClienteContado.v_idContacto = 0
            ObjManteClienteContado.v_idDireccion = 0
            If OgirenDestino = 1 Then
                If ObjVentagiroContado.v_IDPERSONA <= 0 Then
                    MsgBox("No puede realizar esta Operacion de Modificacion No existe el Cliente...", MsgBoxStyle.Information, "Seguridad Sistema")
                    Return False
                End If
                ObjManteClienteContado.v_idContacto = ObjVentagiroContado.v_IDPERSONA
                ObjManteClienteContado.v_idpersona = ObjVentagiroContado.v_IDPERSONA
                If iWinDireccion_Remitente.Count > 0 Then
                    indexof = iWinDireccion_Remitente.IndexOf(iDireccion.Text)
                    ObjManteClienteContado.v_idDireccion = -1
                    If indexof >= 0 Then
                        ObjManteClienteContado.v_idDireccion = Int(coll_Direccion_Remitente.Item(indexof.ToString))
                    End If
                End If
            End If
            If OgirenDestino = 2 Then
                If iWinContacto_Remitente.Count > 0 And coll_Nombres_Remitente.Count > 0 Then
                    indexof = IIf(iWinContacto_Remitente.IndexOf(iNOMBRES.Text) >= 0, iWinContacto_Remitente.IndexOf(iNOMBRES.Text), -1)
                    ObjManteClienteContado.v_idContacto = -1
                    If indexof >= 0 Then
                        ObjManteClienteContado.v_idContacto = Int(coll_Nombres_Remitente.Item(indexof.ToString))
                    End If
                End If
                If iWinDireccion_Remitente.Count > 0 Then
                    indexof = iWinDireccion_Remitente.IndexOf(iDireccion.Text)
                    ObjManteClienteContado.v_idDireccion = -1
                    If indexof >= 0 Then
                        ObjManteClienteContado.v_idDireccion = Int(coll_Direccion_Remitente.Item(indexof.ToString))
                    End If
                End If
            End If

            If OgirenDestino = 3 Then
                If iWinContacto_Destinatario.Count > 0 And coll_Nombres_Destinatario.Count > 0 Then
                    indexof = IIf(iWinContacto_Destinatario.IndexOf(iNOMBRES.Text) >= 0, iWinContacto_Destinatario.IndexOf(iNOMBRES.Text), -1)
                    ObjManteClienteContado.v_idContacto = 0
                    If indexof >= 0 Then
                        ObjManteClienteContado.v_idContacto = Int(coll_Nombres_Destinatario.Item(indexof.ToString))
                    End If
                End If
                If iWinDireccion_Destinatario.Count > 0 Then
                    indexof = iWinDireccion_Destinatario.IndexOf(iDireccion.Text)
                    ObjManteClienteContado.v_idDireccion = 0
                    If indexof >= 0 Then
                        ObjManteClienteContado.v_idDireccion = Int(coll_Direccion_Destinatario.Item(indexof.ToString))
                    End If
                End If
            End If
            If ObjManteClienteContado.v_idContacto <= 0 Then
                MsgBox("No puede realizar esta Operacion de Modificacion No existe el Cliente/Contacto...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return False
            End If
            DlgfrmManteClienteContado.iPersonaContacto = OgirenDestino

            Acceso.Asignar(DlgfrmManteClienteContado, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                If DlgfrmManteClienteContado.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    iNRODOC.Text = ObjManteClienteContado.v_NroDoc
                    iNOMBRES.Text = ObjManteClienteContado.v_Rason_Social
                    iDireccion.Text = ObjManteClienteContado.v_Direccion
                    txtPorcernt_Descuento.Text = ObjManteClienteContado.v_porcentage_descuento
                    iControlMonto_Base = ObjManteClienteContado.v_base
                End If
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            'If DlgfrmManteClienteContado.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '    iNRODOC.Text = ObjManteClienteContado.v_NroDoc
            '    iNOMBRES.Text = ObjManteClienteContado.v_Rason_Social
            '    iDireccion.Text = ObjManteClienteContado.v_Direccion
            '    txtPorcernt_Descuento.Text = ObjManteClienteContado.v_porcentage_descuento
            '    iControlMonto_Base = ObjManteClienteContado.v_base
            'End If
        Catch ex As Exception
        End Try
        Return False
    End Function
    Private Function fnImprimirFACTURA() As Boolean
        Try
            ObjReport.Dispose()
        Catch
        End Try
        ObjReport = New ClsLbTepsa.dtoFrmReport
        Try
            Dim montoLetras As String = ConvercionNroEnLetras(ObjIMPRESIONFACT_BOL.xTotal_Costo)
            Dim fecha_Systema As String() = Split(dtoUSUARIOS.m_sFecha, "/")
            Dim dia As String = fecha_Systema(0)
            Dim Mes As String = fecha_Systema(1)
            Dim Anio As String = fecha_Systema(2)

            Dim GLOSA2 As String = ""
            Dim PESO As String = ""
            Dim PARCIAL As String = ""
            Dim CANTIDAD As String = ""




            If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso) = 0 Then
                CANTIDAD = ObjIMPRESIONFACT_BOL.xCantidad_Peso & Chr(13)
                GLOSA2 = "BULTOS" & Chr(13)
                PESO = ObjIMPRESIONFACT_BOL.xTotalPeso & Chr(13)
                PARCIAL = Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso), "####,###,###.00") & Chr(13)
            End If

            If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol) = 0 Then
                CANTIDAD = CANTIDAD & ObjIMPRESIONFACT_BOL.xCantidad_Vol & "" & Chr(13)
                GLOSA2 = GLOSA2 & "BULTOS (V.)" & Chr(13)
                PESO = PESO & ObjIMPRESIONFACT_BOL.xTotalVolumen & Chr(13)
                PARCIAL = PARCIAL & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol), "####,###,###.00") & Chr(13)
            End If

            If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre) = 0 Then
                CANTIDAD = CANTIDAD & ObjIMPRESIONFACT_BOL.xCantidad_Sobre & ""
                GLOSA2 = GLOSA2 & "SOBRES"
                PESO = PESO & ""
                PARCIAL = PARCIAL & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre), "####,###,###.00")
            End If


            '' '' ''ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Val(dtGridViewBultos(7, 2).Value)

            ObjReport.rutaRpt = PathFrmReport


            'ObjIMPRESIONFACT_BOL.xDireccionRemitente, _

            Select Case tipo_factu_impre
                Case "A"
                    ObjReport.printrptlpt(True, "", "FAC006.RPT", _
                    "P_MONTO_LETRAS;" & montoLetras, _
                    "P_MENSAJE;" & "...", _
                    "P_GLOSA02;" & GLOSA2, _
                    "P_NRO_FACTURA;" & ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL, _
                    "P_CODIGO_CLIENTE;" & ObjIMPRESIONFACT_BOL.xRuc, _
                    "P_RAZON_SOCIAL;" & ObjIMPRESIONFACT_BOL.xRazonSocial, _
                    "P_DIRECCION_PERSONA;" & ObjIMPRESIONFACT_BOL.xDireccionRemitente, _
                    "P_REMITENTE;" & ObjIMPRESIONFACT_BOL.xRemitente, _
                    "P_DESTINATARIO;" & ObjIMPRESIONFACT_BOL.xConsignado, _
                    "P_DIRECCION_REMI;" & " ", _
                    "P_DIRECCION_DESTI;" & ObjIMPRESIONFACT_BOL.xDireccionConsignado, _
                    "P_LOGIN;" & dtoUSUARIOS.iLOGIN, _
                    "P_REFE;" & ObjIMPRESIONFACT_BOL.xNroRef, _
                    "P_MEMO;" & ObjIMPRESIONFACT_BOL.xMemo, _
                    "P_FORMA_PAGO;" & ObjIMPRESIONFACT_BOL.xFormaPago, _
                    "P_SUB_TOTAL;" & ObjIMPRESIONFACT_BOL.xMonto_Sub_Total, _
                    "P_MONTO_IMPUESTO;" & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Impuesto), "####,###,###.00"), _
                    "P_TOTAL_COSTO;" & Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString), "####,###,###.00"), _
                    "P_DIA_FACTURA;" & dia, _
                    "P_MES_FACTURA;" & Mes, _
                    "P_ANIO_FACTURA;" & Anio, _
                    "P_GLOSA;" & " ", _
                    "P_ORIGEN;" & ObjIMPRESIONFACT_BOL.xOrigen, _
                    "P_DESTINO;" & ObjIMPRESIONFACT_BOL.xDestino, _
                    "P_PESO;" & PESO, _
                    "P_PARCIAL;" & PARCIAL, _
                    "P_CANTIDAD;" & CANTIDAD, _
                   "P_HORA;" & fnGetHora(), _
                    "P_DESCUENTO;" & ObjIMPRESIONFACT_BOL.xDescuento, _
                    "P_AGENCIA;" & ObjIMPRESIONFACT_BOL.xAgenciaDestino _
                    )
                Case "N"
                    ObjReport.printrptlpt(True, "", "FAC006_PROV.RPT", _
                                        "P_MONTO_LETRAS;" & montoLetras, _
                                        "P_MENSAJE;" & "...", _
                                        "P_GLOSA02;" & GLOSA2, _
                                        "P_NRO_FACTURA;" & ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL, _
                                        "P_CODIGO_CLIENTE;" & ObjIMPRESIONFACT_BOL.xRuc, _
                                        "P_RAZON_SOCIAL;" & ObjIMPRESIONFACT_BOL.xRazonSocial, _
                                        "P_DIRECCION_PERSONA;" & ObjIMPRESIONFACT_BOL.xDireccionRemitente, _
                                        "P_REMITENTE;" & ObjIMPRESIONFACT_BOL.xRemitente, _
                                        "P_DESTINATARIO;" & ObjIMPRESIONFACT_BOL.xConsignado, _
                                        "P_DIRECCION_REMI;" & " ", _
                                        "P_DIRECCION_DESTI;" & ObjIMPRESIONFACT_BOL.xDireccionConsignado, _
                                        "P_LOGIN;" & dtoUSUARIOS.iLOGIN, _
                                        "P_REFE;" & ObjIMPRESIONFACT_BOL.xNroRef, _
                                        "P_MEMO;" & ObjIMPRESIONFACT_BOL.xMemo, _
                                        "P_FORMA_PAGO;" & ObjIMPRESIONFACT_BOL.xFormaPago, _
                                        "P_SUB_TOTAL;" & ObjIMPRESIONFACT_BOL.xMonto_Sub_Total, _
                                        "P_MONTO_IMPUESTO;" & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Impuesto), "####,###,###.00"), _
                                        "P_TOTAL_COSTO;" & Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString), "####,###,###.00"), _
                                        "P_DIA_FACTURA;" & dia, _
                                        "P_MES_FACTURA;" & Mes, _
                                        "P_ANIO_FACTURA;" & Anio, _
                                        "P_GLOSA;" & " ", _
                                        "P_ORIGEN;" & ObjIMPRESIONFACT_BOL.xOrigen, _
                                        "P_DESTINO;" & ObjIMPRESIONFACT_BOL.xDestino, _
                                        "P_PESO;" & PESO, _
                                        "P_PARCIAL;" & PARCIAL, _
                                        "P_CANTIDAD;" & CANTIDAD, _
                                       "P_HORA;" & fnGetHora(), _
                                        "P_DESCUENTO;" & ObjIMPRESIONFACT_BOL.xDescuento, _
                                        "P_AGENCIA;" & ObjIMPRESIONFACT_BOL.xAgenciaDestino, _
                                        "P_TIPO_ENTREGA;" & ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA _
                                        )
            End Select
            'Tepsa. 
            'P_GLOSA;" & " " POR NUESTRO SERVICIO DE TRANSPORTE DE CARGA EN ATENCIÓN A SUS ORDENES, SEGÚN RELACIÓN ADJUNTA", _

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return False
    End Function
    Public Function fnImprimirBOLETA() As Boolean
        Try
            ObjReport.Dispose()
        Catch
        End Try
        ObjReport = New ClsLbTepsa.dtoFrmReport
        Try
            Dim HoraSistema As String = fnGetHora()



            Dim GLOSA2 As String = ""
            Dim PESO As String = ""
            Dim PARCIAL As String = ""
            Dim CANTIDAD As String = ""


            If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso) = 0 Then
                CANTIDAD = ObjIMPRESIONFACT_BOL.xCantidad_Peso & Chr(13)
                GLOSA2 = "BULTOS" & Chr(13)
                PESO = ObjIMPRESIONFACT_BOL.xTotalPeso & Chr(13)
                PARCIAL = Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso), "####,###,###.00") & Chr(13)
            End If

            If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol) = 0 Then
                CANTIDAD = CANTIDAD & ObjIMPRESIONFACT_BOL.xCantidad_Vol & "" & Chr(13)
                GLOSA2 = GLOSA2 & "BULTOS (V.)" & Chr(13)
                PESO = PESO & ObjIMPRESIONFACT_BOL.xTotalVolumen & Chr(13)
                PARCIAL = PARCIAL & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol), "####,###,###.00") & Chr(13)
            End If

            If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre) = 0 Then
                CANTIDAD = CANTIDAD & ObjIMPRESIONFACT_BOL.xCantidad_Sobre & ""
                GLOSA2 = GLOSA2 & "SOBRES"
                PESO = PESO & ""
                PARCIAL = PARCIAL & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre), "####,###,###.00")
            End If

            Dim Detalle As String = CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Vol)
            Detalle = Detalle & "  SOBRE'S: " & CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString
            GLOSA2 = "BULTOS   " & Val(Val(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + Val(ObjIMPRESIONFACT_BOL.xCantidad_Vol)).ToString & Chr(13) & "SOBRES   " & Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString
            '"P_DETALLE;" & "CANTIDAD: " & CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Sobre) + CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Vol), _
            ' '' ''ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Val(dtGridViewBultos(7, 2).Value)
            ObjReport.rutaRpt = PathFrmReport
            Select Case tipo_bole_impre
                Case "A"
                    ObjReport.printrptlpt(False, "", "FAC007.RPT", _
                    "P_SERVICIO;" & "ENCOMIENDAS", _
                    "P_ORIGEN;" & ObjIMPRESIONFACT_BOL.xOrigen, _
                    "P_DESTINO;" & ObjIMPRESIONFACT_BOL.xDestino, _
                    "P_FECHA_EMISION;" & ObjIMPRESIONFACT_BOL.xfecha_factura, _
                    "P_FORMA_PAGO;" & ObjIMPRESIONFACT_BOL.xFormaPago, _
                    "P_REMITENTE;" & ObjIMPRESIONFACT_BOL.xRazonSocial, _
                    "P_OPERACION_DESTINO;" & "...", _
                    "P_TIPO_SERVICIO;" & "ENCOMIENDA", _
                    "P_CONSIGNADO;" & ObjIMPRESIONFACT_BOL.xConsignado, _
                    "P_DIRECCION;" & ObjIMPRESIONFACT_BOL.xDireccionConsignado, _
                    "P_PESO;" & ObjIMPRESIONFACT_BOL.xTotalPeso, _
                    "P_VOLUMEN;" & ObjIMPRESIONFACT_BOL.xTotalVolumen, _
                    "P_FLETE;" & Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"), _
                    "P_DETALLE;" & GLOSA2, _
                    "P_NUMERO_BOLETA;" & ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL, _
                    "P_HORA_GUIA;" & "HORA : " & HoraSistema, _
                    "P_TOTAL;" & Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString), "###,###,###.00"), _
                    "P_LOGIN;" & dtoUSUARIOS.iLOGIN, _
                    "P_INTERNO;" & ObjIMPRESIONFACT_BOL.xIdFactura, _
                    "P_AGENCIA;" & ObjIMPRESIONFACT_BOL.xAgenciaDestino _
                    )
                Case "N"
                    ObjReport.printrptlpt(False, "", "FAC007_PROV.RPT", _
                    "P_SERVICIO;" & "ENCOMIENDAS", _
                    "P_ORIGEN;" & ObjIMPRESIONFACT_BOL.xOrigen, _
                    "P_DESTINO;" & ObjIMPRESIONFACT_BOL.xDestino, _
                    "P_FECHA_EMISION;" & ObjIMPRESIONFACT_BOL.xfecha_factura, _
                    "P_FORMA_PAGO;" & ObjIMPRESIONFACT_BOL.xFormaPago, _
                    "P_REMITENTE;" & ObjIMPRESIONFACT_BOL.xRazonSocial, _
                    "P_OPERACION_DESTINO;" & "...", _
                    "P_TIPO_SERVICIO;" & "ENCOMIENDA", _
                    "P_CONSIGNADO;" & ObjIMPRESIONFACT_BOL.xConsignado, _
                    "P_DIRECCION;" & ObjIMPRESIONFACT_BOL.xDireccionConsignado, _
                    "P_PESO;" & ObjIMPRESIONFACT_BOL.xTotalPeso, _
                    "P_VOLUMEN;" & ObjIMPRESIONFACT_BOL.xTotalVolumen, _
                    "P_FLETE;" & Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"), _
                    "P_DETALLE;" & GLOSA2, _
                    "P_NUMERO_BOLETA;" & ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL, _
                    "P_HORA_GUIA;" & "HORA : " & HoraSistema, _
                    "P_TOTAL;" & Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString), "###,###,###.00"), _
                    "P_LOGIN;" & dtoUSUARIOS.iLOGIN, _
                    "P_INTERNO;" & ObjIMPRESIONFACT_BOL.xIdFactura, _
                    "P_AGENCIA;" & ObjIMPRESIONFACT_BOL.xAgenciaDestino, _
                    "P_TIPO_ENTREGA;" & ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA _
                    )
            End Select


        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return False
    End Function
    Public Function fnTECHO(ByVal monto As String) As String
        Dim monto_total As String = monto
        Try
            Dim varMonto() As String = Split(monto_total, ".")
            If varMonto.Length > 1 Then
                If Val(varMonto(1).ToString) < 50 Then
                    monto_total = varMonto(0) & ".50"
                Else
                    Dim Entero As String() = Split(varMonto(0).ToString, ",")
                    Dim i As Integer = 0
                    monto_total = varMonto(0).ToString
                    If Entero.Length >= 1 Then
                        monto_total = ""
                    End If
                    For i = 0 To Entero.Length - 1
                        monto_total = monto_total & Entero(i).ToString
                    Next
                    monto_total = Val(monto_total) + 1
                    monto_total = monto_total.ToString & ".00"
                End If
            End If
        Catch ex As Exception

        End Try
        Return monto_total
    End Function

    Private Sub NuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        Try
            SelectMenu(1)
            fnNUEVO()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AnularToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnularToolStripMenuItem.Click
        Try
            'objLOG.fnLog("ANULACION DE UN DOCUMENTO....")
            If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                Return
            End If
            ObjProcesosVentaContado.iControl = 1
            ObjProcesosVentaContado.idFacturaBoleta = dtGridViewControl_FACBOL.Rows(row).Cells(1).Value
            'datahelper
            'If ObjVentaGiroContado.fnValidarProceso(ObjProcesosVentaContado.idFacturaBoleta) = False Then
            If ObjVentagiroContado.fnValidarProceso_dt(ObjProcesosVentaContado.idFacturaBoleta) = False Then
                MsgBox("No puede Realizar esta Operacion, Ya Esta Anulada...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If

            If ObjProcesosVentaContado.ShowDialog() = Windows.Forms.DialogResult.Yes Then
                'datahelper
                'If ObjVentagiroContado.fnANULDEVVENAS(ObjProcesosVentaContado.iControl, ObjProcesosVentaContado.idFacturaBoleta, 0) = True Then
                If ObjVentagiroContado.fnANULDEVVENAS_dt(ObjProcesosVentaContado.iControl, ObjProcesosVentaContado.idFacturaBoleta, 0) = True Then
                    If ObjVentagiroContado.v_CONTROL_ANUDEV = 1 Then
                        dtGridViewControl_FACBOL.Rows(row).DataGridView(IDGRIESTADO_REG, row).Value = 2
                        dtGridViewControl_FACBOL.UpdateCellValue(0, row)
                        'objLOG.fnLog("ANULACION CORRECTA....")
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub DevolucionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DevolucionToolStripMenuItem.Click
        Try
            'objLOG.fnLog("INICIO DE UNA DEVOLUCION....")
            If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                Return
            End If
            ObjProcesosVentaContado.iControl = 2
            ObjProcesosVentaContado.idFacturaBoleta = dtGridViewControl_FACBOL.Rows(row).Cells(1).Value
            'datahelper
            'If ObjVentaGiroContado.fnValidarProceso(ObjProcesosVentaContado.idFacturaBoleta) = False Then
            If ObjVentagiroContado.fnValidarProceso_dt(ObjProcesosVentaContado.idFacturaBoleta) = False Then
                MsgBox("No puede Realizar esta Operacion, Ya se realizo la Devolucion...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            If ObjProcesosVentaContado.ShowDialog() = Windows.Forms.DialogResult.Yes Then
                Dim x_PORCENT_DEVOLUCION As Double = ObjProcesosVentaContado.x_PORCENT_DEVOLUCION
                'datahelper
                'If ObjVentagiroContado.fnANULDEVVENAS(ObjProcesosVentaContado.iControl, ObjProcesosVentaContado.idFacturaBoleta, ObjProcesosVentaContado.x_PORCENT_DEVOLUCION) = True Then
                If ObjVentagiroContado.fnANULDEVVENAS_dt(ObjProcesosVentaContado.iControl, ObjProcesosVentaContado.idFacturaBoleta, ObjProcesosVentaContado.x_PORCENT_DEVOLUCION) = True Then
                    dtGridViewControl_FACBOL.Rows(row).DataGridView(IDGRIESTADO_REG, row).Value = 29
                    dtGridViewControl_FACBOL.UpdateCellValue(0, row)
                    'objLOG.fnLog("DEVOLUCION REALIZADA CORRECTAMENTE....")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub VerDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerDataToolStripMenuItem.Click
        Try
            If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            Dim v_idFacura As Integer = dtGridViewControl_FACBOL.Rows(row).Cells(1).Value
            'datahelper
            'If ObjVentaGiroContado.fnVERDATA(v_idFacura) = True Then
            If ObjVentagiroContado.fnVERDATA_dt(v_idFacura) = True Then
                SelectMenu(1)
                fnVERDATOSVENTACONTADO()
                ObjVentagiroContado.fnClearOBJ()
            Else
                MsgBox("No puede cargar esta data, faltan datos...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub
    'Private Sub txtCliente_Remitente_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCliente_Remitente.Validating
    '    fnVALIDARDOCUMENTOS()
    'End Sub
    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Acceso.Asignar(ObjfrmBuscarCliente, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                If ObjfrmBuscarCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    objControlFacturasBol.iControl = 5
                    fnBuscarFacturas()
                    ObjBusquedaClientes.idPersona = 0
                    objControlFacturasBol.iControl = 0
                End If
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            'If ObjfrmBuscarCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '    objControlFacturasBol.iControl = 5
            '    fnBuscarFacturas()
            '    ObjBusquedaClientes.idPersona = 0
            '    objControlFacturasBol.iControl = 0
            'End If
        Catch ex As Exception
            ObjBusquedaClientes.idPersona = 0
        End Try
    End Sub

    Private Sub txtCosto_Total_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCosto_Total.TextChanged
        Try
            If bControlFiscalizacion = True Then
                '' '' ''txtSub_Total.Text = Format(Val(txtCosto_Total.Text) * (1 - (dtoUSUARIOS.iIGV) / 100), "##,###,###.00")
                '' '' ''txtMonto_IGV.Text = Format(Val(txtCosto_Total.Text) - Val(txtSub_Total.Text), "###,###,###.00")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnTIKET_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTIKET.Click
        Try
            If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            Dim v_idFacura As Integer = dtGridViewControl_FACBOL.Rows(row).Cells(1).Value
            'datahelper
            'If ObjVentaGiroContado.fnREIMPRESIONCODIGOS(1, v_idFacura) = True Then
            If ObjVentagiroContado.fnREIMPRESIONCODIGOS_dt(1, v_idFacura) = True Then
                If MsgBox("Esta Seguro de Imprimir Etiquetas..?", MsgBoxStyle.YesNo, "Seguridad Sistemas") = MsgBoxResult.Yes Then
                    '
                    '01/11/2009 - Funcioanlidad de impresión de etiquetas no tiene actaulamente funcionalidad
                    '
                    'If xIMPRESORA = 1 Then
                    '    fnImprimirEtiquetasN95()
                    'Else
                    '    fnImprimirEtiquetasFAC_IIN95()
                    'End If
                End If

            Else
                MsgBox("No puede cargar esta data, faltan datos...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Exception
            MsgBox("revizar datos....", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    'Public Function fnImprimirEtiquetasN95() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim prn As New PrinterTxt.PrintTxt
    '        Dim cadena As String = ""
    '        Dim HoraActual As String = ObjCODIGOBARRA.HoraImpresion
    '        prn.Nombre_impresora = "PRNZEBRA"
    '        Dim EXISTE As Boolean = prn.SetearImpresora()

    '        'ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaGiroContado.v_IDUNIDAD_ORIGEN)
    '        'ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaGiroContado.v_IDUNIDAD_DESTINO)
    '        'ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
    '        'ObjCODIGOBARRA.Cantidad = ObjVentaGiroContado.v_CANTIDAD_ETIQUETAS

    '        Dim I As Int16 = 1
    '        While ObjVentaGiroContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaGiroContado.Cur_CODIGOBARRAS.BOF = False
    '            ObjCODIGOBARRA.CodigoBarra = ObjVentaGiroContado.Cur_CODIGOBARRAS.Fields.Item(0).Value
    '            prn.EscribeLinea("^XA")
    '            prn.EscribeLinea("^PW400")
    '            prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD " & ObjCODIGOBARRA.NroDOC & "          " & I.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & "^FS")
    '            'prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD " & Me.TextBox1.Text & "^FS")
    '            'prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & Me.TextBox2.Text & I & "^FS")
    '            prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.clinte & "^FS")
    '            prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & ObjCODIGOBARRA.CodigoBarra & "^FS")
    '            prn.EscribeLinea("^FT17,141^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
    '            prn.EscribeLinea("^FT96,142^A0N,39,45^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")
    '            prn.EscribeLinea("^FT305,188^AAN,18,10^FH\^FDTEPSAC^FS")
    '            prn.EscribeLinea("^FT183,188^AAN,18,10^FH\^FD" & HoraActual & "^FS")
    '            prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & ObjCODIGOBARRA.Fecha & "^FS")
    '            prn.EscribeLinea("^PQ1,0,1,Y")
    '            prn.EscribeLinea("^XZ")
    '            prn.EscribeLinea(cadena)
    '            ObjVentaGiroContado.Cur_CODIGOBARRAS.MoveNext()
    '            I = I + 1
    '        End While
    '        prn.FinDoc()
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    'Public Function fnImprimirEtiquetasFAC_IIN95_2009() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim prn As New PrinterTxt.PrintTxt
    '        Dim cadena As String = ""
    '        Dim HoraActual As String = ObjCODIGOBARRA.HoraImpresion
    '        prn.Nombre_impresora = "PRNZEBRA"
    '        Dim EXISTE As Boolean = prn.SetearImpresora()

    '        'ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaGiroContado.v_IDUNIDAD_ORIGEN)
    '        'ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaGiroContado.v_IDUNIDAD_DESTINO)
    '        'ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
    '        'ObjCODIGOBARRA.Cantidad = ObjVentaGiroContado.v_CANTIDAD_ETIQUETAS

    '        Dim I As Int16 = 1
    '        'While objGuiaEnvio.cur_codBarras.EOF = False And objGuiaEnvio.cur_codBarras.BOF = False
    '        While ObjVentagiroContado.Cur_CODIGOBARRAS.EOF = False And ObjVentagiroContado.Cur_CODIGOBARRAS.BOF = False
    '            ObjCODIGOBARRA.CodigoBarra = ObjVentagiroContado.Cur_CODIGOBARRAS.Fields.Item(0).Value
    '            prn.EscribeLinea("<STX><ESC>C0<ETX>")
    '            prn.EscribeLinea("<STX><ESC>k<ETX>")
    '            prn.EscribeLinea("<STX><SI>N60<ETX>")
    '            prn.EscribeLinea("<STX><SI>L197<ETX>")
    '            prn.EscribeLinea("<STX><SI>S20<ETX>")
    '            prn.EscribeLinea("<STX><SI>d0<ETX>")
    '            prn.EscribeLinea("<STX><SI>h0,0;<ETX>")
    '            prn.EscribeLinea("<STX><SI>l8<ETX>")
    '            prn.EscribeLinea("<STX><SI>I3<ETX>")
    '            prn.EscribeLinea("<STX><SI>F20<ETX>")
    '            prn.EscribeLinea("<STX><SI>D0<ETX>")
    '            prn.EscribeLinea("<STX><SI>t0<ETX>")
    '            prn.EscribeLinea("<STX><SI>W394<ETX>")
    '            prn.EscribeLinea("<STX><SI>g1,567<ETX>")
    '            prn.EscribeLinea("<STX><ESC>P<ETX>")
    '            prn.EscribeLinea("<STX>E*;F*;<ETX>")
    '            prn.EscribeLinea("<STX>L1;<ETX>")
    '            prn.EscribeLinea("<STX>D0;<ETX>")
    '            prn.EscribeLinea("<STX>H0;o165,12;f3;c25;h15;w15;d3," & ObjCODIGOBARRA.clinte & ";<ETX>")
    '            prn.EscribeLinea("<STX>D1;<ETX>")
    '            prn.EscribeLinea("<STX>H1;o130,13;f3;c25;h9;w15;d3," & ObjCODIGOBARRA.NroDOC & " -" & I.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & ";<ETX>")
    '            prn.EscribeLinea("<STX>H2;o88,11;f3;c25;h11;w11;d3," & ObjCODIGOBARRA.Origen & " / ;<ETX>")
    '            prn.EscribeLinea("<STX>B3;o96,160;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
    '            prn.EscribeLinea("<STX>H4;o14,13;f3;c25;h7;w7;d3," & ObjCODIGOBARRA.Fecha & ";<ETX>")
    '            prn.EscribeLinea("<STX>H5;o14,200;f3;c25;h7;w7;d3," & HoraActual & ";<ETX>")
    '            prn.EscribeLinea("<STX>H6;o14,300;f3;c25;h7;w7;d3,TEPSAC;<ETX>")
    '            prn.EscribeLinea("<STX>H7;o102,96;f3;c25;h17;w16;d3," & ObjCODIGOBARRA.Destino & ";<ETX>")
    '            prn.EscribeLinea("<STX>R<ETX>")
    '            prn.EscribeLinea("<STX><ESC>E*<CAN><ETX>")
    '            prn.EscribeLinea("<STX><RS>1<US>1<ETB><ETX>")


    '            prn.EscribeLinea(cadena)
    '            ObjVentagiroContado.Cur_CODIGOBARRAS.MoveNext()
    '            I = I + 1
    '        End While
    '        prn.FinDoc()
    '    Catch ex As Exception
    '        flag = False
    '    End Try
    '    Return flag
    'End Function

    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem.Click
        Try

            'If fnValidar_Rol("24") = False Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 4) Then
                MsgBox("Usted no Tiene Acceso...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            'objLOG.fnLog("INICIO DE UNA ELIMIANCION....")
            If dtGridViewControl_FACBOL.Rows().Count = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            If dtGridViewControl_FACBOL.Rows().Count = row Then
                Return
            End If
            Dim idFacturaBoleta As String = dtGridViewControl_FACBOL.Rows(row).Cells(1).Value
            If MsgBox("Esta Seguro que quiere Eliminar este documento" & dtGridViewControl_FACBOL.Rows(row).Cells(2).Value.ToString, MsgBoxStyle.YesNoCancel, "") = MsgBoxResult.Yes Then
                'datahelper
                'If ObjVentagiroContado.fnELIMINAR_DOCUMENTO(idFacturaBoleta) = False Then
                If ObjVentagiroContado.fnELIMINAR_DOCUMENTO_dt(idFacturaBoleta) = False Then
                    dtGridViewControl_FACBOL.Rows.RemoveAt(row)
                    MessageBox.Show("El Registro ha sido Anulado.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("El Registro no ha sido Anulado.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub


    Private Sub dtGridViewControl_FACBOL_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtGridViewControl_FACBOL.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                ContextMenuStrip.Show(sender, e.X, e.Y)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub ExportExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportExcelToolStripMenuItem.Click
        Try
            fnEXCELGrid(dtGridViewControl_FACBOL)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub txtNroSerieDoc_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtNroSerieDoc.MaskInputRejected

    End Sub

    Private Sub dtGridViewControl_FACBOL_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtGridViewControl_FACBOL.CellContentClick

    End Sub
    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles btnNuevo.EnabledChanged, btnAnular.EnabledChanged, btnDevolucion.EnabledChanged, btnVerData.EnabledChanged, btnImprimir.EnabledChanged, btnTIKET.EnabledChanged, btnCerrar.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Grabar()
    End Sub

    Sub Grabar()
        Try
            If TabMante.SelectedIndex = 0 Then
                SendKeys.Send("{Tab}")
                GoTo FINAL
            End If
            If control_venta = True Then
                fnNUEVO()
            End If
            If TipoComprobante = 1 Then
                If txtDocCliente_Remitente.Text.ToString.Length = 11 Then
                    If fnValidarRUC(txtDocCliente_Remitente.Text.ToString) = False Then
                        MsgBox("No puede realizar esta Operacion de Factura, el Nro de Docuemnto es Invalido")
                    End If
                Else
                    MsgBox("No puede realizar esta Operacion de Factura, el Nro de Docuemnto es Invalido", MsgBoxStyle.Information, "Seguriadad Sistema")
                End If
            End If
            If txtCliente_Remitente.Text = "" Then
                MsgBox("No Puede Realizar esta Operacion no tiene Cliente remitente ...", MsgBoxStyle.Information, "Seguridad Sistema")
                txtCliente_Remitente.Focus()
                Return
            End If
            If txtCliente_Destinatario.Text = "" Then
                MsgBox("No Puede Realizar esta Operacion no tiene Cliente Destinatario ...", MsgBoxStyle.Information, "Seguridad Sistema")
                txtCliente_Destinatario.Focus()
                Return
            End If

            'Dim varDescuento As Integer = IIf(txtPorcernt_Descuento.Text <> "", txtPorcernt_Descuento.Text, 0)

            'If Val(txtCosto_Total.Text) <= 0 And varDescuento <> 100 Then
            '    MsgBox("No Puede Realizar esta Operacion no tiene monto afecto...,No Tiene el Descuento Apropiado", MsgBoxStyle.Information, "Seguridad Sistema")
            '    Return False
            'End If

            If fnGrabar() = True Then
                ObjVentagiroContado.fnIncrementarNroDoc(TipoComprobante_new)
                '
                'If ObjVentagiroContado.fnNroDocuemnto(2) = True Then  --> Comentado por Omendoza 18/06/2007
                '
                'datahelper
                'If ObjVentagiroContado.fnNroDocuemnto(TipoComprobante_new) = True Then
                If ObjVentagiroContado.fnNroDocuemnto2(TipoComprobante_new) = True Then
                    txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentagiroContado.Serie)
                    txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentagiroContado.NroDoc)
                Else
                    MsgBox("No podrá realizar está operación el Nº de giro no está configurado")
                End If
            End If
FINAL:
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub btnEdicion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdicion.Click
        Edicion()
    End Sub

    Sub Edicion()
        Try
            If txtDocCliente_Remitente.Focused = True Or txtCliente_Remitente.Focused = True Then
                If txtCliente_Remitente.Text <> "" Then
                    If fnMantenimienteCliente(1, txtDocCliente_Remitente, txtCliente_Remitente, txtDireccionRemitente, 1, 1) = True Then

                    End If
                End If
            End If
            If txtCliente_Destinatario.Focused = True Or txtDNIDestinatario.Focused = True Then
                If txtCliente_Destinatario.Text <> "" Then
                    If fnMantenimienteCliente(3, txtDNIDestinatario, txtCliente_Destinatario, txtDireccionDestinatario, 1, 2) = True Then

                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub FrmVentaCargaContado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Verifica si el usuario puede trabajar otras agencias
            Dim objOtrasAgencias As New dtoCONTROLUSUARIOS
            'iOrigen2 = -1
            objOtrasAgencias.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            If objOtrasAgencias.GetOtrasAgencias() Then
                If objOtrasAgencias.iIDOTRAS_AGENCIAS = 1 Then
                    bOtrasAgencias = True
                Else
                    bOtrasAgencias = False
                End If
            Else
                bOtrasAgencias = False
            End If

            ObjVentaCargaContado.fnGetAgencias_1()
            ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_rstVarAgencias_1, cmbAgenciaOrigen, ObjVentaCargaContado.coll_AgenciasOrigen, Int(dtoUSUARIOS.m_iIdAgencia.ToString))
            If bOtrasAgencias Then
                Me.cmbAgenciaOrigen.Enabled = True
            Else
                Me.cmbAgenciaOrigen.Enabled = False
            End If

            Dim dv As New DataView
            Dim objVENTA_CONTADO As New ClsLbTepsa.dtoVENTA_CONTADO
            If bOtrasAgencias Then
                iAgenciaOrigen = Int(ObjVentaCargaContado.coll_AgenciasOrigen(cmbAgenciaOrigen.SelectedIndex.ToString))
                ObjVentaCargaContado.fnGetUnidadAgencia(iAgenciaOrigen)
                iUnidadOrigen = ObjVentaCargaContado.dt_rstAgencias.Rows(0).Item(0)
                objVENTA_CONTADO.IDAGENCIAS = iAgenciaOrigen
            Else
                objVENTA_CONTADO.IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
            End If
            'datahelper
            'dv = objVENTA_CONTADO.sp_tipo_format_impre(cnn)
            dv = objVENTA_CONTADO.sp_tipo_format_impre()
            tipo_bole_impre = dv.Table.Rows(0)("tipo_bole_impre")
            tipo_factu_impre = dv.Table.Rows(0)("tipo_factu_impre")
            dv.Dispose()
            objVENTA_CONTADO.Dispose()
            dtoUSUARIOS.m_iNombreUnidadAgencia = fnGetCiudad(dtoUSUARIOS.m_idciudad.ToString)
            dtoUSUARIOS.m_iNombreAgencia = fnGetAGENCIA(dtoUSUARIOS.m_iIdAgencia.ToString)
            Me.Text = "VENTAS CARGA....." & dtoUSUARIOS.iLOGIN & " Ag. Nro " & dtoUSUARIOS.m_iIdAgencia & " [ " & dtoUSUARIOS.m_iNombreAgencia & " ][ " & dtoUSUARIOS.m_iNombreUnidadAgencia & "] "
            'objLOG.fnLog("LOAD MAIN FACTURA")
            ToolStripMenuItem1.Text = "&BUSCAR"
            ToolStripMenuItem2.Text = "&FACTURAS Y/O BOLETAS "
            If ObjVentagiroContado.fnLoadVentaCarga() = True Then
                'datahelper
                'fnCargar_iWin(txtiWinDestino, ObjVentagiroContado.cur_UNIDAD_AGENCIAS, coll_iDestino, iWinDestino, 0)
                fnCargar_iWin_dt(txtiWinDestino, ObjVentagiroContado.cur_UNIDAD_AGENCIAS_dt, coll_iDestino, iWinDestino, 0)

                'datahelper
                'ModuUtil.LlenarComboIDs(ObjVentagiroContado.cur_t_Tipo_Entrega, cmbTipo_Entrega, ObjVentagiroContado.coll_t_Tipo_Entrega, 1)
                ModuUtil.LlenarCombo2(ObjVentagiroContado.cur_t_Tipo_Entrega_dt, cmbTipo_Entrega, ObjVentagiroContado.coll_t_Tipo_Entrega, 1)

                Dim ObjGeneral As ClsLbTepsa.dtoGENERAL = New ClsLbTepsa.dtoGENERAL
                'datahelper
                'If ObjGeneral.FN_L_tipos_giros_CB(dv_l_tipos_giros, Me.cbidtipo_giro, VOCONTROLUSUARIO) Then
                If ObjGeneral.FN_L_tipos_giros_CB(dv_l_tipos_giros, Me.cbidtipo_giro) Then

                End If
                'datahelper
                'If ObjGeneral.fn_L_condiciones_giros_CB(dv_l_condiciones_giros, Me.cbidcondi_giro, VOCONTROLUSUARIO) Then
                If ObjGeneral.fn_L_condiciones_giros_CB(dv_l_condiciones_giros, Me.cbidcondi_giro) Then
                End If

                'datahelper
                'ModuUtil.LlenarComboIDs(ObjVentagiroContado.cur_T_TARJETAS, cmbTargeta, ObjVentagiroContado.coll_T_TARJETAS, 1)
                ModuUtil.LlenarCombo2(ObjVentagiroContado.cur_T_TARJETAS_dt, cmbTargeta, ObjVentagiroContado.coll_T_TARJETAS, 1)
            End If
            'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper   
            If objGuiaEnvio.fnLISTA_AGENCIAS_UNIDADES() = True Then
                'datahelper
                'ModuUtil.LlenarComboIDs2(objGuiaEnvio.rst_Lista_Unidades_Agencia, cmbOrigen, objGuiaEnvio.coll_Lista_Origen, 9999, cmbDestino, objGuiaEnvio.coll_Lista_Destino, 9999)
                ModuUtil.LlenarComboIDs2(objGuiaEnvio.dt_Lista_Unidades_Agencia, cmbOrigen, objGuiaEnvio.coll_Lista_Origen, 9999, cmbDestino, objGuiaEnvio.coll_Lista_Destino, 9999)
            End If
            'datahelper
            'rst = New ADODB.Recordset
            'rst = VOCONTROLUSUARIO.ListarAgencias(-1)
            'ModuUtil.LlenarComboIDs(rst, cmbAgencia, objGuiaEnvio.coll_Lista_Agencias, dtoUSUARIOS.m_iIdAgencia)
            Dim dt As DataTable = ObjVentagiroContado.fnGetAgencias_dt()
            ModuUtil.LlenarCombo2(dt, cmbAgencia, objGuiaEnvio.coll_Lista_Agencias, dtoUSUARIOS.m_iIdAgencia)

            'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper   
            If objGuiaEnvio.fnFILTRO_USUARIO_X_AGENCIA(dtoUSUARIOS.m_iIdAgencia) = True Then
                '01/09/2009 - Mod x datahelper a datatable 
                'ModuUtil.LlenarComboIDs(objGuiaEnvio.rst_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, dtoUSUARIOS.IdLogin)
                ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, dtoUSUARIOS.IdLogin)
            Else
                NingunoComboIDs(cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios)
            End If
            'datahelper
            'rst = Nothing
            'rst = ObjVentagiroContado.fnListarEstadoFactura()
            dt.Clear()
            dt = ObjVentagiroContado.fnListarEstadoFactura()
            'datahelper
            'ModuUtil.LlenarComboIDs(rst, cmbEstados, objGuiaEnvio.coll_Lista_Estados, 999)
            ModuUtil.LlenarCombo2(dt, cmbEstados, objGuiaEnvio.coll_Lista_Estados, 999)
            fnLoadGrid()
            ',              'txtAgenDestino
            txtFecha.Text = dtoUSUARIOS.m_sFecha
            txtiWinDestino.Focus()
            txtiWinDestino.SelectAll()

            'datahelper
            'If ObjVentagiroContado.fnNroDocuemnto(TipoComprobante_new) = True Then
            If ObjVentagiroContado.fnNroDocuemnto2(TipoComprobante_new) = True Then
                If IsDBNull(ObjVentagiroContado.Serie) = True Or RellenoRight(Mro_Digitos_SerieVentas, ObjVentagiroContado.Serie) = "000" Then
                    MsgBox("No ha configurado la serie del giro")
                    Me.Close()
                    Exit Sub
                End If
                txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentagiroContado.Serie)
                txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentagiroContado.NroDoc)
            Else
                MsgBox("No podrá realizar está operación, el Nº del giro no está configurado")
                Me.Close()
                Exit Sub
            End If
            'cmbCondicionPago
            'cmbFormaPago
            'cmbTargeta
            SelectMenu(1)

            txtiWinDestino.SelectAll()
            txtiWinDestino.Focus()
            dtFechaInicio.Text = dtoUSUARIOS.m_sFecha
            dtFechaFin.Text = dtoUSUARIOS.m_sFecha

            'If fnValidar_Rol("18") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 1) Then
                cmbAgencia.Enabled = False
                cmbUsuarios.Enabled = False
                btnNuevo.Enabled = False
                btnAnular.Enabled = False
                btnDevolucion.Enabled = False
            End If

            'If fnValidar_Rol("23") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 2) Then
                cmbAgencia.Enabled = False
                cmbUsuarios.Enabled = False
                btnNuevo.Enabled = True
                btnAnular.Enabled = True
                btnDevolucion.Enabled = True
            End If

            'If fnValidar_Rol("14") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 3) Then
                cmbAgencia.Enabled = True
                cmbUsuarios.Enabled = True
                btnNuevo.Enabled = True
                btnAnular.Enabled = True
                btnDevolucion.Enabled = True
            End If


            ' '' ''lbFactBoleta.Text = "BOLETA VENTA"
            bFAC_Bol = False
            TipoComprobante = 2
            'datahelper
            'If ObjVentagiroContado.fnNroDocuemnto(TipoComprobante_new) = True Then
            If ObjVentagiroContado.fnNroDocuemnto2(TipoComprobante_new) = True Then
                If IsDBNull(ObjVentagiroContado.Serie) = True Or RellenoRight(Mro_Digitos_SerieVentas, ObjVentagiroContado.Serie) = "000" Then
                    MsgBox("No ha configurado la serie del giro")
                    Me.Close()
                    Exit Sub
                End If
                txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentagiroContado.Serie)
                txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentagiroContado.NroDoc)
            Else
                MsgBox("No podra Realizar esta Operacion El Nro de Factura/Boleta no esta configurado")
            End If
            xIMPRESORA = fnSeleccionImpresion()

            Me.cbidcondi_giro.SelectedValue = "SEFE"
            Me.cbidtipo_giro.SelectedValue = "NORM"

            bIngreso = False
            Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            'objLOG.fnLogErr(ex.ToString)
            dtFechaInicio.Text = dtoUSUARIOS.m_sFecha
            dtFechaFin.Text = dtoUSUARIOS.m_sFecha

            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub cmbAgenciaOrigen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAgenciaOrigen.Click
    End Sub

    Private Sub cmbAgenciaOrigen_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmbAgenciaOrigen.MouseClick
    End Sub

    Private Sub cmbAgenciaOrigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgenciaOrigen.SelectedIndexChanged
        If bOtrasAgencias Then
            Dim objVENTA_CONTADO As New ClsLbTepsa.dtoVENTA_CONTADO
            iAgenciaOrigen = Int(ObjVentaCargaContado.coll_AgenciasOrigen(cmbAgenciaOrigen.SelectedIndex.ToString))
            ObjVentaCargaContado.fnGetUnidadAgencia(iAgenciaOrigen)
            iUnidadOrigen = ObjVentaCargaContado.dt_rstAgencias.Rows(0).Item(0)
            objVENTA_CONTADO.IDAGENCIAS = iAgenciaOrigen
            Me.Text = "VENTAS CARGA....." & dtoUSUARIOS.iLOGIN & " Ag. Nro " & iAgenciaOrigen & " [ " & fnGetAGENCIA(iAgenciaOrigen) & " ][ " & fnGetCiudad(iUnidadOrigen) & "] "
            'MessageBox.Show(fnGetAGENCIA(iAgenciaOrigen))
        End If
    End Sub
End Class
