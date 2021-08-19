Public Class FrmConsulSolicitudMensajeria

    Dim dvidtipo_entrega As New DataView
    Dim dvidtipo_comunicacion As New DataView

    Dim dvfacturas_guias As New DataView
    Dim dvListar_facturas As New DataView

    Dim Colllistar_persona_todos As New Collection
    Dim Iwinlistar_persona_todos As New AutoCompleteStringCollection

    Dim ObjPersona As New ClsLbTepsa.dtoPersona
    Dim objgeneral As New ClsLbTepsa.dtoGENERAL

    Dim dvlistar_persona_todos As New DataView
    Dim dvlistar_tipo_moneda As New DataView

    Dim dvlistar_forma_pago As New DataView

    Private ObjReport As ClsLbTepsa.dtoFrmReport '

    Dim ObjMensajeria As New ClsLbTepsa.dtoMensajeria
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        listar_facturas()
    End Sub
    Private Sub listar_facturas()
        Cursor = Cursors.WaitCursor
        Try
            If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                ObjMensajeria.IDPERSONA = 0
            Else

                ObjMensajeria.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
            End If
            If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjMensajeria.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjMensajeria.FECHA_INICIO = "NULL"
            If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjMensajeria.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjMensajeria.FECHA_FINAL = "NULL"
            If Not IsNothing(Me.cbidtipo_comprobante.SelectedValue) Then
                ObjMensajeria.IDTIPO_COMPROBANTE = Me.cbidtipo_comprobante.SelectedValue
            Else
                ObjMensajeria.IDTIPO_COMPROBANTE = 0
            End If
            ObjMensajeria.IDTIPO_MONEDA = 0
            'If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
            '    ObjMensajeria.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
            'Else
            '    ObjMensajeria.IDUSUARIO_PERSONAL = 0
            'End If

            'If Len(Me.tbnro_factura.Text.Trim) = 0 Then
            '    ObjMensajeria.NRO_FACTURA = 0
            'Else
            '    ObjMensajeria.NRO_FACTURA = Me.tbnro_factura.Text.Trim
            'End If
            If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                ObjMensajeria.IDAGENCIAS = Me.cmbAgencia.SelectedValue
            Else
                ObjMensajeria.IDAGENCIAS = 0
            End If

            If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
                ObjMensajeria.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
            Else
                ObjMensajeria.IDFORMA_PAGO = 0
            End If
            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
                ObjMensajeria.IDUNIDAD_ORIGEN = Me.CBIDUNIDAD_AGENCIA.SelectedValue
            Else
                ObjMensajeria.IDUNIDAD_ORIGEN = 0
            End If

            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                ObjMensajeria.IDUNIDAD_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
            Else
                ObjMensajeria.IDUNIDAD_DESTINO = 0
            End If

            If Not IsNothing(Me.cbidtipo_entrega.SelectedValue) Then
                ObjMensajeria.IDTIPO_ENTREGA = Me.cbidtipo_entrega.SelectedValue
            Else
                ObjMensajeria.IDTIPO_ENTREGA = 0
            End If

            'If Not IsNothing(Me.CBIDTIPO_COMUNICACION.SelectedValue) Then
            '    ObjMensajeria.IDTIPO_COMUNICACION = Me.CBIDTIPO_COMUNICACION.SelectedValue
            'Else
            '    ObjMensajeria.IDTIPO_COMUNICACION = 0
            'End If


            'Dim P_ENTRE As String = 0
            'If Me.RBCONMSG.Checked = True Then
            '    ObjMensajeria.ConSinMsg = 1
            'ElseIf Me.RBSINMSG.Checked = True Then
            '    ObjMensajeria.ConSinMsg = 0
            'Else
            '    ObjMensajeria.ConSinMsg = 2
            'End If

            Dim P_ENTRE As String = 0
            If Me.RBCONMSG.Checked = True Then
                ObjMensajeria.ConSinMsg = 0
            ElseIf Me.RBSINMSG.Checked = True Then
                ObjMensajeria.ConSinMsg = 1
            Else
                ObjMensajeria.ConSinMsg = 2
            End If

            If Not IsNothing(Me.cboEstado.SelectedValue) Then
                ObjMensajeria.EstadoEnvio = Me.cboEstado.SelectedValue
            Else
                ObjMensajeria.EstadoEnvio = 0
            End If

            'hlamas 04-09-2015
            'dvListar_facturas = ObjMensajeria.SP_CONSUL_SOLICI_ENVIO_MENSA()
            dvListar_facturas = ObjMensajeria.Listar(ObjMensajeria.FECHA_INICIO, ObjMensajeria.FECHA_FINAL, ObjMensajeria.IDPERSONA, _
                                                     ObjMensajeria.IDTIPO_COMPROBANTE, ObjMensajeria.IDUNIDAD_ORIGEN, ObjMensajeria.IDAGENCIAS, _
                                                     ObjMensajeria.IDUNIDAD_DESTINO, ObjMensajeria.IDTIPO_ENTREGA, ObjMensajeria.IDFORMA_PAGO, ObjMensajeria.ConSinMsg, ObjMensajeria.EstadoEnvio).DefaultView

            Me.DGV3.DataSource = dvListar_facturas
            'If dvListar_facturas.Count <= 0 Then
            '    MsgBox("No existen registros", MsgBoxStyle.Information, "Seguridad del Sistema...")
            'End If


            Label9.Text = dvListar_facturas.Count
            'hlamas 04-09-2015
            'FORMAT_GRILLA3()

            Me.txtCONMSG.Text = 0
            Me.txtSINMSG.Text = 0
            Me.txtTOTALMSG.Text = 0

            For i As Integer = 0 To dvListar_facturas.Count - 1
                If dvListar_facturas.Table.Rows(i)("numero") Is DBNull.Value Then
                    Me.txtSINMSG.Text = Val(Me.txtSINMSG.Text) + 1
                Else
                    Me.txtCONMSG.Text = Val(Me.txtCONMSG.Text) + 1
                End If
            Next
            Me.txtTOTALMSG.Text = CLng(Me.txtSINMSG.Text) + CLng(Me.txtCONMSG.Text)
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Sub FORMAT_GRILLA3()
        DGV3.Columns.Clear()

        With DGV3
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = dvListar_facturas
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With


        Dim ANIO_FACTURA As New DataGridViewTextBoxColumn
        With ANIO_FACTURA
            .HeaderText = "ANIO_FACTURA"
            .Name = "ANIO_FACTURA"
            .DataPropertyName = "ANIO_FACTURA"
            .Width = 4
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim CODIGO_CLIENTE As New DataGridViewTextBoxColumn
        With CODIGO_CLIENTE
            .HeaderText = "CODIGO_CLIENTE"
            .Name = "CODIGO_CLIENTE"
            .DataPropertyName = "CODIGO_CLIENTE"
            .Width = 20
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DESTINATARIO As New DataGridViewTextBoxColumn
        With DESTINATARIO
            .HeaderText = "DESTINATARIO"
            .Name = "DESTINATARIO"
            .DataPropertyName = "DESTINATARIO"
            .Width = 182
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DESTINO As New DataGridViewTextBoxColumn
        With DESTINO
            .HeaderText = "DESTINO"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"

            .ReadOnly = True
        End With
        Dim DIA_FACTURA As New DataGridViewTextBoxColumn
        With DIA_FACTURA
            .HeaderText = "DIA_FACTURA"
            .Name = "DIA_FACTURA"
            .DataPropertyName = "DIA_FACTURA"
            .Width = 2
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DIRECCION_PERSONA As New DataGridViewTextBoxColumn
        With DIRECCION_PERSONA
            .HeaderText = "DIRECCION_PERSONA"
            .Name = "DIRECCION_PERSONA"
            .DataPropertyName = "DIRECCION_PERSONA"

            .ReadOnly = True
        End With
        Dim DIREC_DESTI As New DataGridViewTextBoxColumn
        With DIREC_DESTI
            .HeaderText = "DIREC_DESTI"
            .Name = "DIREC_DESTI"
            .DataPropertyName = "DIREC_DESTI"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DIREC_REMI As New DataGridViewTextBoxColumn
        With DIREC_REMI
            .HeaderText = "DIREC_REMI"
            .Name = "DIREC_REMI"
            .DataPropertyName = "DIREC_REMI"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DSCTO As New DataGridViewTextBoxColumn
        With DSCTO
            .HeaderText = "DSCTO"
            .Name = "DSCTO"
            .DataPropertyName = "DSCTO"

            .ReadOnly = True
        End With
        Dim FECHA_FACTURA As New DataGridViewTextBoxColumn
        With FECHA_FACTURA
            .HeaderText = "FECHA_FACTURA"
            .Name = "FECHA_FACTURA"
            .DataPropertyName = "FECHA_FACTURA"
            .Width = 60
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim FECHA_ENTREGA As New DataGridViewTextBoxColumn
        With FECHA_ENTREGA
            .HeaderText = "FECHA_ENTREGA"
            .Name = "FECHA_ENTREGA"
            .DataPropertyName = "FECHA_ENTREGA"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim FECHA_ACTUALIZACION As New DataGridViewTextBoxColumn
        With FECHA_ACTUALIZACION
            .HeaderText = "FECHA_ACTUALIZACION"
            .Name = "FECHA_ACTUALIZACION"
            .DataPropertyName = "FECHA_ACTUALIZACION"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With


        Dim TIPO_ENTREGA As New DataGridViewTextBoxColumn
        With TIPO_ENTREGA
            .HeaderText = "TIPO_ENTREGA"
            .Name = "TIPO_ENTREGA"
            .DataPropertyName = "TIPO_ENTREGA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim TIPO_COMPROBANTE As New DataGridViewTextBoxColumn
        With TIPO_COMPROBANTE
            .HeaderText = "TIPO_COMPROBANTE"
            .Name = "TIPO_COMPROBANTE"
            .DataPropertyName = "TIPO_COMPROBANTE"
            .Width = 40
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ESTADO_REGISTRO_ENVIO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO_ENVIO
            .HeaderText = "EST. ENVIO."
            .Name = "ESTADO_REGISTRO_ENVIO"
            .DataPropertyName = "ESTADO_REGISTRO_ENVIO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO
            .HeaderText = "EST. REG."
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim Nombre_Unidad_ORI As New DataGridViewTextBoxColumn
        With Nombre_Unidad_ORI
            .HeaderText = "Ori."
            .Name = "Nombre_Unidad_ORI"
            .DataPropertyName = "Nombre_Unidad_ORI"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim Nombre_Unidad_DESTI As New DataGridViewTextBoxColumn
        With Nombre_Unidad_DESTI
            .HeaderText = "Dest."
            .Name = "Nombre_Unidad_DESTI"
            .DataPropertyName = "Nombre_Unidad_DESTI"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
        With NOMBRE_AGENCIA
            .HeaderText = "NOMBRE_AGENCIA"
            .Name = "NOMBRE_AGENCIA"
            .DataPropertyName = "NOMBRE_AGENCIA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FORMA_PAGO As New DataGridViewTextBoxColumn
        With FORMA_PAGO
            .HeaderText = "FORMA_PAGO"
            .Name = "FORMA_PAGO"
            .DataPropertyName = "FORMA_PAGO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim IDAGENCIAS As New DataGridViewTextBoxColumn
        With IDAGENCIAS
            .HeaderText = "IDAGENCIAS"
            .Name = "IDAGENCIAS"
            .DataPropertyName = "IDAGENCIAS"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDFACTURA As New DataGridViewTextBoxColumn
        With IDFACTURA
            .HeaderText = "IDFACTURA"
            .Name = "IDFACTURA"
            .DataPropertyName = "IDFACTURA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim DIFERENCIA_DIAS As New DataGridViewTextBoxColumn
        With DIFERENCIA_DIAS
            .HeaderText = "Dias de Diferencia"
            .Name = "DIFERENCIA_DIAS"
            .DataPropertyName = "DIFERENCIA_DIAS"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            '.DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim IDFORMA_PAGO As New DataGridViewTextBoxColumn
        With IDFORMA_PAGO
            .HeaderText = "IDFORMA_PAGO"
            .Name = "IDFORMA_PAGO"
            .DataPropertyName = "IDFORMA_PAGO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDTIPO_MONEDA As New DataGridViewTextBoxColumn
        With IDTIPO_MONEDA
            .HeaderText = "IDTIPO_MONEDA"
            .Name = "IDTIPO_MONEDA"
            .DataPropertyName = "IDTIPO_MONEDA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDUSUARIO_PERSONAL As New DataGridViewTextBoxColumn
        With IDUSUARIO_PERSONAL
            .HeaderText = "IDUSUARIO_PERSONAL"
            .Name = "IDUSUARIO_PERSONAL"
            .DataPropertyName = "IDUSUARIO_PERSONAL"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim MEMO As New DataGridViewTextBoxColumn
        With MEMO
            .HeaderText = "MEMO"
            .Name = "MEMO"
            .DataPropertyName = "MEMO"
            .Width = 100
            .ReadOnly = True
        End With
        Dim MES_FACTURA As New DataGridViewTextBoxColumn
        With MES_FACTURA
            .HeaderText = "MES_FACTURA"
            .Name = "MES_FACTURA"
            .DataPropertyName = "MES_FACTURA"
            .Width = 10
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim MONTO_IMPUESTO As New DataGridViewTextBoxColumn
        With MONTO_IMPUESTO
            .HeaderText = "MONTO_IMPUESTO"
            .Name = "MONTO_IMPUESTO"
            .DataPropertyName = "MONTO_IMPUESTO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim NRO_FACTURA As New DataGridViewTextBoxColumn
        With NRO_FACTURA
            .HeaderText = "NRO_FACTURA"
            .Name = "NRO_FACTURA"
            .DataPropertyName = "NRO_FACTURA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ORIGEN As New DataGridViewTextBoxColumn
        With ORIGEN
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"

            .ReadOnly = True
        End With
        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .HeaderText = "RAZON_SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .Width = 175
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim REFE As New DataGridViewTextBoxColumn
        With REFE
            .HeaderText = "REFE"
            .Name = "REFE"
            .DataPropertyName = "REFE"

            .ReadOnly = True
        End With
        Dim REMITENTE As New DataGridViewTextBoxColumn
        With REMITENTE
            .HeaderText = "REMITENTE"
            .Name = "REMITENTE"
            .DataPropertyName = "REMITENTE"
            .Width = 182
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SERIE_FACTURA As New DataGridViewTextBoxColumn
        With SERIE_FACTURA
            .HeaderText = "SERIE_FACTURA"
            .Name = "SERIE_FACTURA"
            .DataPropertyName = "SERIE_FACTURA"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
        End With
        Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
        With SIMBOLO_MONEDA
            .HeaderText = "SIMBOLO_MONEDA"
            .Name = "SIMBOLO_MONEDA"
            .DataPropertyName = "SIMBOLO_MONEDA"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SUB_TOTAL As New DataGridViewTextBoxColumn
        With SUB_TOTAL
            .HeaderText = "SUB_TOTAL"
            .Name = "SUB_TOTAL"
            .DataPropertyName = "SUB_TOTAL"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim LOGIN As New DataGridViewTextBoxColumn
        With LOGIN
            .HeaderText = "USUARIO"
            .Name = "LOGIN"
            .DataPropertyName = "LOGIN"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
        With TOTAL_COSTO
            .HeaderText = "TOTAL_COSTO"
            .Name = "TOTAL_COSTO"
            .DataPropertyName = "TOTAL_COSTO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim NRO_PREFACTURA As New DataGridViewTextBoxColumn
        With NRO_PREFACTURA
            .HeaderText = "NRO_PREFACTURA"
            .Name = "NRO_PREFACTURA"
            .DataPropertyName = "NRO_PREFACTURA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim Monto_Descuento As New DataGridViewTextBoxColumn
        With Monto_Descuento
            .HeaderText = "Monto Dscto."
            .Name = "Monto_Descuento"
            .DataPropertyName = "Monto_Descuento"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim Porcent_Descuento As New DataGridViewTextBoxColumn
        With Porcent_Descuento
            .HeaderText = "Porcen Dscto."
            .Name = "Porcent_Descuento"
            .DataPropertyName = "Porcent_Descuento"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim TIPO_COMUNICACION As New DataGridViewTextBoxColumn
        With TIPO_COMUNICACION
            .HeaderText = "TIPO_COMUNICACION"
            .Name = "TIPO_COMUNICACION"
            .DataPropertyName = "TIPO_COMUNICACION"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NRO_MOVIL As New DataGridViewTextBoxColumn
        With NRO_MOVIL
            .HeaderText = "NRO_MOVIL"
            .Name = "NRO_MOVIL"
            .DataPropertyName = "NRO_MOVIL"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim E_MAIL As New DataGridViewTextBoxColumn
        With E_MAIL
            .HeaderText = "E_MAIL"
            .Name = "E_MAIL"
            .DataPropertyName = "E_MAIL"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim ESTADO As New DataGridViewTextBoxColumn
        With ESTADO
            .HeaderText = "Estado"
            .Name = "estado"
            .DataPropertyName = "estado"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        With DGV3
            .Columns.AddRange(RAZON_SOCIAL, TIPO_COMPROBANTE, SERIE_FACTURA, NRO_FACTURA, FORMA_PAGO, FECHA_FACTURA, FECHA_ENTREGA, SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, LOGIN, ESTADO_REGISTRO, ESTADO_REGISTRO_ENVIO, NOMBRE_AGENCIA, Nombre_Unidad_ORI, Nombre_Unidad_DESTI, TIPO_ENTREGA, TIPO_COMUNICACION, NRO_MOVIL, E_MAIL, ESTADO)

        End With
    End Sub

    Private Sub FrmConsulSolicitudMensajeria_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmConsulFactuEmiti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ConfigurarDGV3()
            Me.ShadowLabel1.Text = "Solicitud de envios de mensaje"

            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False
            Me.MenuStrip1.Items(6).Visible = False
            Me.MenuStrip1.Items(7).Visible = False

            'Mod.17/09/2009 -->Omendoza - Pasando al datahelper   
            'objgeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago, VOCONTROLUSUARIO)
            objgeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago)
            '
            'dvlistar_forma_pago.RowFilter = "idforma_pago <> 2"
            cbidforma_pago.DataSource = dvlistar_forma_pago
            cbidforma_pago.DisplayMember = "FORMA_PAGO"
            cbidforma_pago.ValueMember = "IDFORMA_PAGO"
            ''Mod.17/09/2009 -->Omendoza - Pasando al datahelper   - No se considera el objeto VOCONTROLUSUARIO 
            'objgeneral.fnlistar_tipo_comprobante(dvlistar_forma_pago, Me.cbidtipo_comprobante, VOCONTROLUSUARIO)
            objgeneral.fnlistar_tipo_comprobante(dvlistar_forma_pago, Me.cbidtipo_comprobante)
            '
            dvlistar_forma_pago.RowFilter = "IDTIPO_COMPROBANTE = 1 or IDTIPO_COMPROBANTE = 2 or IDTIPO_COMPROBANTE = 3"

            'objgeneral.FNLISTAR_TIPO_MONEDA(dvlistar_tipo_moneda, Me.cbidtipo_comprobante, VOCONTROLUSUARIO)
            'datahelper
            'objgeneral.FN_cmb_Listar_agencias(CNN, Me.cmbAgencia)
            objgeneral.FN_cmb_Listar_agencias(Me.cmbAgencia)
            ObjPersona.CODIGO_CLIENTE = "NULL"
            ObjPersona.IDTIPO_PERSONA = 0
            ObjPersona.IDPERSONA = 0

            'datahelper
            'dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
            ObjProcesos.fnCargar_iWin_r(Me.txtidpersona, dvlistar_persona_todos, Colllistar_persona_todos, Iwinlistar_persona_todos, 0)

            'datahelper
            'objgeneral.FN_L_UNIDAD_agencia_(VOCONTROLUSUARIO, Me.CBIDUNIDAD_AGENCIA)
            'objgeneral.FN_L_UNIDAD_agencia_(VOCONTROLUSUARIO, Me.CBIDUNIDAD_AGENCIA_DESTINO)
            objgeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA)
            objgeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA_DESTINO)

            'Mod.18/09/2009 -->Omendoza - Pasando al datahelper   
            objgeneral.fn_L_TIPO_ENTREGA(dvidtipo_entrega, Me.cbidtipo_entrega)
            '
            'datahelper
            'objgeneral.fn_L_TIPO_comunicacion(dvidtipo_comunicacion, Me.CBIDTIPO_COMUNICACION, VOCONTROLUSUARIO)


            'objgeneral.fn_L_TIPO_comunicacion(dvidtipo_comunicacion, Me.CBIDTIPO_COMUNICACION)
            '

            Dim dt2 As DataTable = ListarTipoControl(20, 0)
            With Me.cboEstado
                .DataSource = dt2
                .DisplayMember = "descripcion"
                .ValueMember = "valor"
                .SelectedValue = 1
            End With

            Me.cbidforma_pago.SelectedIndex = -1
            Me.cbidtipo_comprobante.SelectedIndex = -1
            Me.cmbAgencia.SelectedIndex = -1
            'Me.cmbUsuarios.SelectedIndex = -1
            Me.CBIDUNIDAD_AGENCIA.SelectedIndex = -1
            Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndex = -1
            Me.cbidtipo_entrega.SelectedIndex = -1
            'Me.CBIDTIPO_COMUNICACION.SelectedIndex = -1

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub cmbAgencia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAgencia.GotFocus
        'Me.txtsub_total.Text = 0
        'Me.txtmonto_impuesto.Text = 0
        'Me.txttotal_costo.Text = 0
        DGV3.DataSource = Nothing
    End Sub

    'Private Sub cmbAgencia_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectionChangeCommitted
    '    Try
    '        Dim p_id_rol_usuario, p_idagencia As Int64
    '        p_id_rol_usuario = 6
    '        If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
    '            p_idagencia = CType(Me.cmbAgencia.SelectedValue, Int64)
    '            'datahelper
    '            'objgeneral.FN_cmb_LISTAR_USUARIOS_VENDEDOR(cnn, Me.cmbUsuarios, p_id_rol_usuario, p_idagencia)
    '            objgeneral.FN_cmb_LISTAR_USUARIOS_VENDEDOR(Me.cmbUsuarios, p_id_rol_usuario, p_idagencia)
    '        Else
    '            cmbUsuarios.DataSource = Nothing
    '        End If
    '        Me.cmbUsuarios.SelectedIndex = -1
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '    End Try
    'End Sub

    Private Sub FrmConsulFactuEmiti_MenuImprimir() Handles Me.MenuImprimir
        'Try
        '    ObjReport.Dispose()
        'Catch
        'End Try
        'ObjReport = New ClsLbTepsa.dtoFrmReport
        'Select Case Me.TabMante.SelectedIndex
        '    Case 0
        '        Try
        '            If Me.DGV3.RowCount <= 0 Then
        '                MsgBox("No existen registro", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
        '                Exit Sub
        '            End If


        '            If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
        '                ObjMensajeria.IDPERSONA = 0
        '            Else

        '                ObjMensajeria.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
        '            End If
        '            If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjMensajeria.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjMensajeria.FECHA_INICIO = "NULL"
        '            If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjMensajeria.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjMensajeria.FECHA_FINAL = "NULL"
        '            If Not IsNothing(Me.cbidtipo_comprobante.SelectedValue) Then
        '                ObjMensajeria.IDTIPO_COMPROBANTE = Me.cbidtipo_comprobante.SelectedValue
        '            Else
        '                ObjMensajeria.IDTIPO_COMPROBANTE = 0
        '            End If

        '            ObjMensajeria.IDTIPO_MONEDA = 0

        '            If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
        '                ObjMensajeria.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
        '            Else
        '                ObjMensajeria.IDUSUARIO_PERSONAL = 0
        '            End If
        '            If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
        '                ObjMensajeria.IDAGENCIAS = cmbAgencia.SelectedValue
        '            Else
        '                ObjMensajeria.IDAGENCIAS = 0
        '            End If

        '            If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
        '                ObjMensajeria.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
        '            Else
        '                ObjMensajeria.IDFORMA_PAGO = 0
        '            End If
        '            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
        '                ObjMensajeria.IDUNIDAD_ORIGEN = Me.CBIDUNIDAD_AGENCIA.SelectedValue
        '            Else
        '                ObjMensajeria.IDUNIDAD_ORIGEN = 0
        '            End If

        '            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
        '                ObjMensajeria.IDUNIDAD_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
        '            Else
        '                ObjMensajeria.IDUNIDAD_DESTINO = 0
        '            End If

        '            'If Len(Me.tbnro_factura.Text.Trim) = 0 Then
        '            '    ObjMensajeria.NRO_FACTURA = 0
        '            'Else
        '            '    ObjMensajeria.NRO_FACTURA = Me.tbnro_factura.Text.Trim
        '            'End If

        '            If Not IsNothing(Me.cbidtipo_entrega.SelectedValue) Then
        '                ObjMensajeria.IDTIPO_ENTREGA = Me.cbidtipo_entrega.SelectedValue
        '            Else
        '                ObjMensajeria.IDTIPO_ENTREGA = 0
        '            End If

        '            Dim P_ENTRE As String

        '            'If Me.RBENTRE.Checked = True Then
        '            '    P_ENTRE = 1
        '            'ElseIf Me.RBSIN_ENTRE.Checked = True Then
        '            P_ENTRE = 0
        '            'Else
        '            '    P_ENTRE = 2
        '            'End If


        '            'If Me.RBAGENCIA_VENTA.Checked = True Then
        '            '    ObjMensajeria.agencia_venta = 1
        '            'Else
        '            '    ObjMensajeria.agencia_venta = 0
        '            'End If


        '            If Me.RBCONMSG.Checked = True Then
        '                ObjMensajeria.ConSinMsg = 1
        '            ElseIf Me.RBSINMSG.Checked = True Then
        '                ObjMensajeria.ConSinMsg = 0
        '            Else
        '                ObjMensajeria.ConSinMsg = 2
        '            End If




        '            With ObjMensajeria

        '                '.IDFACTURA = Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index)("IDFACTURA")


        '                ObjReport.rutaRpt = PathFrmReport
        '                ObjReport.conectar(rptservice, rptuser, rptpass)
        '                If Me.RBREPRESU.Checked = True Then
        '                    ObjReport.printrptB(False, "", "MSG002.RPT", _
        '                    "p_TITULO_fecha;" & "(Desde el " & .FECHA_INICIO & " hasta el " & .FECHA_FINAL & ")", _
        '                    "P_CONSINMSG;" & .ConSinMsg, _
        '                    "p_idpersona;" & .IDPERSONA, _
        '                    "p_idtipo_comunicacion;" & .IDTIPO_COMUNICACION, _
        '                    "p_idforma_pago;" & .IDFORMA_PAGO, _
        '                    "p_idtipo_moneda;" & .IDTIPO_MONEDA, _
        '                    "p_idagencias;" & .IDAGENCIAS, _
        '                    "p_idusuario_personal;" & .IDUSUARIO_PERSONAL, _
        '                    "p_fecha_inicial;" & .FECHA_INICIO, _
        '                    "p_fecha_final;" & .FECHA_FINAL, _
        '                   "p_idunidad_origen;" & .IDUNIDAD_ORIGEN, _
        '                    "p_idunidad_destino;" & .IDUNIDAD_DESTINO, _
        '                    "p_idtipo_comprobante;" & .IDTIPO_COMPROBANTE, _
        '                    "p_idtipo_entrega;" & .IDTIPO_ENTREGA)
        '                Else

        '                    ObjReport.printrptB(False, "", "MSG001.RPT", _
        '                    "p_TITULO_fecha;" & "(Desde el " & .FECHA_INICIO & " hasta el " & .FECHA_FINAL & ")", _
        '                    "P_CONSINMSG;" & .ConSinMsg, _
        '                    "p_idpersona;" & .IDPERSONA, _
        '                    "p_idtipo_comunicacion;" & .IDTIPO_COMUNICACION, _
        '                    "p_idforma_pago;" & .IDFORMA_PAGO, _
        '                    "p_idtipo_moneda;" & .IDTIPO_MONEDA, _
        '                    "p_idagencias;" & .IDAGENCIAS, _
        '                    "p_idusuario_personal;" & .IDUSUARIO_PERSONAL, _
        '                    "p_fecha_inicial;" & .FECHA_INICIO, _
        '                    "p_fecha_final;" & .FECHA_FINAL, _
        '                   "p_idunidad_origen;" & .IDUNIDAD_ORIGEN, _
        '                    "p_idunidad_destino;" & .IDUNIDAD_DESTINO, _
        '                    "p_idtipo_comprobante;" & .IDTIPO_COMPROBANTE, _
        '                    "p_idtipo_entrega;" & .IDTIPO_ENTREGA)

        '                End If
        '            End With
        '        Catch ex As Exception
        '            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        '        End Try
        'End Select
    End Sub

    Private Sub FrmConsulFactuEmiti_MenuSalir() Handles Me.MenuSalir
        Close()
    End Sub

    Private Sub txtidpersona_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtidpersona.GotFocus, _
    DTPFECHAINICIOFACTURA.GotFocus, _
    DTPFECHAFINALFACTURA.GotFocus, _
        cbidtipo_comprobante.GotFocus, _
        cbidforma_pago.GotFocus, _
 _
        cmbAgencia.GotFocus, _
 _
        CBIDUNIDAD_AGENCIA.GotFocus, _
        CBIDUNIDAD_AGENCIA_DESTINO.GotFocus, _
        cbidtipo_entrega.GotFocus, cboEstado.GotFocus


        Me.txtCONMSG.Text = 0
        Me.txtSINMSG.Text = 0
        Me.txtTOTALMSG.Text = 0
        Label9.Text = ""
        DGV3.DataSource = Nothing
    End Sub

    Private Sub txtidpersona_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtidpersona.KeyUp
        Try
            If e.KeyCode = 13 Then
                If Not Iwinlistar_persona_todos.IndexOf(txtidpersona.Text) = -1 Then
                    With ObjPersona
                        .IDPERSONA = Int(Colllistar_persona_todos.Item(Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                        .IDTIPO_PERSONA = 0
                        .CODIGO_CLIENTE = "NULL"
                        'datahelper
                        'ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, .IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                        ObjPersona.FNLISTAR_PERSONA(.IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                        Me.txtCodigoCliente.Text = .CODIGO_CLIENTE
                        Me.DTPFECHAINICIOFACTURA.Focus()
                    End With
                    Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
                Else
                    Me.txtCodigoCliente.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub txtidpersona_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtidpersona.LostFocus
        If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
            Me.txtidpersona.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub

    Private Sub txtidpersona_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtidpersona.TextChanged
        Me.txtCONMSG.Text = 0
        Me.txtSINMSG.Text = 0
        Me.txtTOTALMSG.Text = 0
        Label9.Text = ""
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub txtCodigoCliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.GotFocus
        Me.txtCONMSG.Text = 0
        Me.txtSINMSG.Text = 0
        Me.txtTOTALMSG.Text = 0
        Label9.Text = ""
        DGV3.DataSource = Nothing
    End Sub

    Private Sub txtCodigoCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCliente.KeyPress
        Try
            If e.KeyChar = Chr(13) Then

                ObjPersona.CODIGO_CLIENTE = Trim(Me.txtCodigoCliente.Text)
                ObjPersona.IDTIPO_PERSONA = 0
                ObjPersona.IDPERSONA = 0

                If Len(ObjPersona.CODIGO_CLIENTE) = 0 Then
                    Me.txtCodigoCliente.Text = ""
                    Me.txtidpersona.Text = ""
                    Exit Sub
                End If

                'datahelper
                'If ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE).Count = 1 Then
                If ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE).Count = 1 Then
                    Me.txtidpersona.Text = ObjPersona.RAZON_SOCIAL
                    Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
                    txtidpersona.Focus()
                Else
                    MsgBox("No existe el cliente", MsgBoxStyle.Information, "Segurdiad del Sistema")
                    Me.txtidpersona.Text = ""
                End If
            End If
        Catch EX As Exception
            MsgBox(EX.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub tbnro_factura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            Me.cmbAgencia.Focus()
        End If
    End Sub

    Private Sub txtCodigoCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.LostFocus
        If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
            Me.txtidpersona.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub



    Private Sub DTPFECHAINICIOFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.GotFocus

        Me.txtCONMSG.Text = 0
        Me.txtSINMSG.Text = 0
        Me.txtTOTALMSG.Text = 0
        Label9.Text = ""
        DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAINICIOFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            DTPFECHAFINALFACTURA.Focus()
        End If
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.ValueChanged
        Me.DGV3.DataSource = Nothing
        Label9.Text = ""
        Me.txtCONMSG.Text = 0
        Me.txtSINMSG.Text = 0
        Me.txtTOTALMSG.Text = 0

    End Sub

    Private Sub DTPFECHAFINALFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.GotFocus

        Me.txtCONMSG.Text = 0
        Me.txtSINMSG.Text = 0
        Me.txtTOTALMSG.Text = 0
        Label9.Text = ""
        DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAFINALFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cbidtipo_comprobante.Focus()
        End If
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged
        Me.DGV3.DataSource = Nothing
        Me.txtCONMSG.Text = 0
        Me.txtSINMSG.Text = 0
        Me.txtTOTALMSG.Text = 0
        Label9.Text = ""
    End Sub

    Private Sub cbidtipo_moneda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbidtipo_comprobante.GotFocus

        Me.txtCONMSG.Text = 0
        Me.txtSINMSG.Text = 0
        Me.txtTOTALMSG.Text = 0
        Label9.Text = ""
        DGV3.DataSource = Nothing
    End Sub

    Private Sub cbidtipo_moneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidtipo_comprobante.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cbidforma_pago.Focus()
        End If
    End Sub

    Private Sub cbidforma_pago_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbidforma_pago.GotFocus
        Me.txtCONMSG.Text = 0
        Me.txtSINMSG.Text = 0
        Me.txtTOTALMSG.Text = 0
        Label9.Text = ""
        DGV3.DataSource = Nothing
    End Sub

    Private Sub cbidforma_pago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidforma_pago.KeyPress
        'If e.KeyChar = Chr(13) Then
        '    Me.tbnro_factura.Focus()
        'End If
    End Sub

    Private Sub cmbUsuarios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            Me.CBIDUNIDAD_AGENCIA.Focus()
        End If
    End Sub


    Private Sub cmbAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectedIndexChanged
        Me.txtCONMSG.Text = 0
        Me.txtSINMSG.Text = 0
        Me.txtTOTALMSG.Text = 0
        Label9.Text = ""
        Me.DGV3.DataSource = Nothing
    End Sub
    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub cbidforma_pago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbidforma_pago.SelectedIndexChanged
        Me.txtCONMSG.Text = 0
        Me.txtSINMSG.Text = 0
        Me.txtTOTALMSG.Text = 0
        Label9.Text = ""
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub tbnro_factura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmbUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.txtCONMSG.Text = 0
        Me.txtSINMSG.Text = 0
        Me.txtTOTALMSG.Text = 0
        Label9.Text = ""
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.Button3.Focus()
        End If
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndexChanged
        Me.txtCONMSG.Text = 0
        Me.txtSINMSG.Text = 0
        Me.txtTOTALMSG.Text = 0
        Label9.Text = ""
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBIDUNIDAD_AGENCIA.KeyPress, cbidtipo_entrega.KeyPress, cboEstado.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.CBIDUNIDAD_AGENCIA_DESTINO.Focus()
        End If
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA.SelectedIndexChanged, cbidtipo_entrega.SelectedIndexChanged, cboEstado.SelectedIndexChanged
        Me.txtCONMSG.Text = 0
        Me.txtSINMSG.Text = 0
        Me.txtTOTALMSG.Text = 0
        Label9.Text = ""
        Me.DGV3.DataSource = Nothing
    End Sub
    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub DGV3_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGV3.RowsAdded
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.DGV3), 0)
    End Sub

    Private Sub DGV3_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGV3.RowsRemoved
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.DGV3), 0)
    End Sub

    Private Sub txtCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.TextChanged
        Me.txtCONMSG.Text = 0
        Me.txtSINMSG.Text = 0
        Me.txtTOTALMSG.Text = 0
        Label9.Text = ""
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub cbidtipo_comprobante_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbidtipo_comprobante.SelectedIndexChanged
        Me.txtCONMSG.Text = 0
        Me.txtSINMSG.Text = 0
        Me.txtTOTALMSG.Text = 0
        Label9.Text = ""
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBREPRESU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.txtCONMSG.Text = 0
        Me.txtSINMSG.Text = 0
        Me.txtTOTALMSG.Text = 0
        Label9.Text = ""
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBREPDETA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.txtCONMSG.Text = 0
        Me.txtSINMSG.Text = 0
        Me.txtTOTALMSG.Text = 0
        Label9.Text = ""
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBCONMSG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBCONMSG.CheckedChanged
        Me.txtCONMSG.Text = 0
        Me.txtSINMSG.Text = 0
        Me.txtTOTALMSG.Text = 0
        Label9.Text = ""
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBSINMSG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSINMSG.CheckedChanged
        Me.txtCONMSG.Text = 0
        Me.txtSINMSG.Text = 0
        Me.txtTOTALMSG.Text = 0
        Label9.Text = ""
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBAMBOS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBAMBOS.CheckedChanged
        Me.txtCONMSG.Text = 0
        Me.txtSINMSG.Text = 0
        Me.txtTOTALMSG.Text = 0
        Label9.Text = ""
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub ConfigurarDGV3()
        With DGV3
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvRecojo)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
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
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Origen" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_agencia_origen As New DataGridViewTextBoxColumn
            With col_agencia_origen
                .Name = "agencia_origen" : .DataPropertyName = "agencia_origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia Origen" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Destino" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cliente" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Comprobante" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Format = "###,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            x += +1
            Dim col_fecha_entrega As New DataGridViewTextBoxColumn
            With col_fecha_entrega
                .Name = "fecha_entrega" : .DataPropertyName = "fecha_entrega"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Entrega" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_tipo_entrega As New DataGridViewTextBoxColumn
            With col_tipo_entrega
                .Name = "tipo_entrega" : .DataPropertyName = "tipo_entrega"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Entrega" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_numero As New DataGridViewTextBoxColumn
            With col_numero
                .Name = "numero" : .DataPropertyName = "numero"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Móvil" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            x += +1
            Dim col_estado_envio As New DataGridViewTextBoxColumn
            With col_estado_envio
                .Name = "estado_envio" : .DataPropertyName = "estado_envio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado Envío" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With

            .Columns.AddRange(col_origen, col_agencia_origen, col_destino, col_cliente, col_fecha, col_tipo, col_comprobante, col_total, _
                              col_fecha_entrega, col_tipo_entrega, col_estado, col_numero, col_estado_envio)
        End With
    End Sub
End Class
