Public Class FrmConsulGuiasRetor

    Dim dvidtipo_entrega As New DataView

    Dim dvfacturas_guias As New DataView
    Dim dvListar_guias As New DataView

    Dim Colllistar_persona_todos As New Collection
    Dim Iwinlistar_persona_todos As New AutoCompleteStringCollection

    Dim ObjPersona As New ClsLbTepsa.dtoPersona
    Dim objgeneral As New ClsLbTepsa.dtoGENERAL
    Dim ObjValida As New ClsLbTepsa.dtoValida

    Dim dvlistar_persona_todos As New DataView
    Dim dvlistar_tipo_moneda As New DataView

    Dim dvlistar_forma_pago As New DataView

    Private ObjReport As ClsLbTepsa.dtoFrmReport '
    Dim bIngreso As Boolean = False
    Public hnd As Long
    Dim blnInicio As Boolean
    'hlamas 17-09-2013 personalizado quimica suiza
    Dim ID_PERSONA_CBC As Integer = 2153948

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        listar_facturas()
    End Sub
    Private Sub listar_facturas()
        Try
            Dim ObjGuias As New ClsLbTepsa.dtoguias
            If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                ObjGuias.IDPERSONA = 0
            Else

                ObjGuias.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
            End If
            If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjGuias.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjGuias.FECHA_INICIO = "NULL"
            If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjGuias.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjGuias.FECHA_FINAL = "NULL"
            'If Not IsNothing(Me.cbidtipo_comprobante.SelectedValue) Then
            '    ObjGuias.IDTIPO_COMPROBANTE = Me.cbidtipo_comprobante.SelectedValue
            'Else
            '    ObjGuias.IDTIPO_COMPROBANTE = 0
            'End If
            'ObjGuias.IDTIPO_MONEDA = 0
            'If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
            '    ObjGuias.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
            'Else
            '    ObjGuias.IDUSUARIO_PERSONAL = 0
            'End If

            If Len(Me.tbnro_factura.Text.Trim) = 0 Then
                ObjGuias.NRO_GUIA = 0
            Else
                ObjGuias.NRO_GUIA = Me.tbnro_factura.Text.Trim
            End If


            'If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
            '    ObjGuias.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
            'Else
            '    ObjGuias.IDFORMA_PAGO = 0
            'End If
            'If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
            '    ObjGuias.IDUNIDAD_ORIGEN = Me.CBIDUNIDAD_AGENCIA.SelectedValue
            'Else
            '    ObjGuias.IDUNIDAD_ORIGEN = 0
            'End If

            'If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
            '    ObjGuias.IDUNIDAD_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
            'Else
            '    ObjGuias.IDUNIDAD_DESTINO = 0
            'End If

            If Not IsNothing(Me.cbidtipo_entrega.SelectedValue) Then
                ObjGuias.IDTIPO_ENTREGA_CARGA = Me.cbidtipo_entrega.SelectedValue
            Else
                ObjGuias.IDTIPO_ENTREGA_CARGA = 0
            End If

            If Not IsNothing(Me.CBIDTIPO_RECEPCION_DOCU.SelectedValue) Then
                ObjGuias.IDTIPO_RECEPCION_DOCU = Me.CBIDTIPO_RECEPCION_DOCU.SelectedValue
            Else
                ObjGuias.IDTIPO_RECEPCION_DOCU = "0"
            End If



            'If Me.RBRETOR.Checked = True Then
            '    ObjGuias.RETOR = 1
            'ElseIf Me.RBSinRetor.Checked = True Then
            '    ObjGuias.RETOR = 0
            'Else
            '    ObjGuias.RETOR = 2
            'End If

            ObjGuias.RETOR = 2


            If Me.RBFactu.Checked Then
                ObjGuias.FACTURADO = 1
            ElseIf Me.RBSinFactu.Checked Then
                ObjGuias.FACTURADO = 0
            ElseIf Me.RBPREFACTURADO.Checked = True Then
                ObjGuias.FACTURADO = 11
            ElseIf Me.rbSinPrefac.Checked = True Then
                ObjGuias.FACTURADO = 10
            Else
                ObjGuias.FACTURADO = 2
            End If



            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
                ObjGuias.IDUNIDAD_AGENCIA = Me.CBIDUNIDAD_AGENCIA.SelectedValue
            Else
                ObjGuias.IDUNIDAD_AGENCIA = 0
            End If

            If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                ObjGuias.IDAGENCIAS = Me.cmbAgencia.SelectedValue
            Else
                ObjGuias.IDAGENCIAS = 0
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                ObjGuias.IDUNIDAD_AGENCIA_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
            Else
                ObjGuias.IDUNIDAD_AGENCIA_DESTINO = 0
            End If

            If Not IsNothing(Me.cmbagencia_destino.SelectedValue) Then
                ObjGuias.idagencias_destino = Me.cmbagencia_destino.SelectedValue
            Else
                ObjGuias.idagencias_destino = 0
            End If

            If Not IsNothing(Me.cmbtipofacturacion.SelectedValue) Then
                ObjGuias.IDTIPO_FACTURACION = Me.cmbtipofacturacion.SelectedValue
            Else
                ObjGuias.IDTIPO_FACTURACION = -1
            End If


            Dim fecha_filtro As String

            If Me.RBFECHA_DOC.Checked = True Then
                fecha_filtro = "FDOC"
            ElseIf Me.RBFECHA_ENTRE.Checked = True Then
                fecha_filtro = "FENT"
            ElseIf Me.RBFECHA_DEVO_CARGO.Checked = True Then
                fecha_filtro = "FDEV"
            Else
                fecha_filtro = "FREV"
            End If

            If Len(Me.txtNRO_LIQUI_DEVO_CARGO.Text) = 0 Then
                ObjGuias.NRO_LIQUI_DEVO_CARGO = 0
            Else
                If ObjValida.NUMERO_ENTERO(txtNRO_LIQUI_DEVO_CARGO, Me) = False Then
                    Exit Sub
                Else
                    ObjGuias.NRO_LIQUI_DEVO_CARGO = Me.txtNRO_LIQUI_DEVO_CARGO.Text.Trim
                End If
            End If

            'hlamas 18-09-2013
            If Me.txtDT.Visible And Me.txtDT.Text.Trim.Length > 0 Then
                ObjGuias.DT = Me.txtDT.Text
            Else
                ObjGuias.DT = 0
            End If

            'hlamas 24-10-2013
            If IsNothing(Me.cmbSubcuenta.SelectedValue) Then
                ObjGuias.Subcuenta = -1
            Else
                ObjGuias.Subcuenta = Me.cmbSubcuenta.SelectedValue
            End If

            'datahelper
            'dvListar_guias = ObjGuias.sp_l_RETOR_CARGAIII(cnn, fecha_filtro)
            'dvListar_guias = ObjGuias.sp_l_RETOR_CARGAIII(fecha_filtro)

            'hlamas 08-02-2019
            ObjGuias.DTFiltro = IIf(Me.rbDt.Checked, 1, 0)

            'hlamas 18-09-2013
            dvListar_guias = ObjGuias.sp_l_RETOR_CARGAIV(fecha_filtro)
            FORMAT_GRILLA3()
            Me.txtsub_total.Text = 0
            Me.txtmonto_impuesto.Text = 0
            Me.txttotal_costo.Text = 0

            L1.Text = dvListar_guias.Count

            If dvListar_guias.Count > 0 Then
                Me.DGV3.CurrentCell = Me.DGV3.Rows(0).Cells(1)
            End If

            For i As Integer = 0 To dvListar_guias.Table.Rows.Count - 1
                Me.txtsub_total.Text = Format(CDbl(Me.txtsub_total.Text) + dvListar_guias.Table.Rows(i)("sub_total"), "###,###,###.00")
                Me.txtmonto_impuesto.Text = Format(CDbl(Me.txtmonto_impuesto.Text) + dvListar_guias.Table.Rows(i)("monto_impuesto"), "###,###,###.00")
                Me.txttotal_costo.Text = Format(CDbl(Me.txttotal_costo.Text) + dvListar_guias.Table.Rows(i)("total_costo"), "###,###,###.00")

            Next

            'hlamas 18-09-2013
            Controla(ObjGuias.IDPERSONA)

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub DGV3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.CellContentClick

    End Sub

    Sub FORMAT_GRILLA3()
        DGV3.Columns.Clear()

        With DGV3
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = dvListar_guias
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim NRO_GUIA As New DataGridViewTextBoxColumn
        With NRO_GUIA
            .HeaderText = "NRO GUIA"
            .Name = "NRO_GUIA"
            .DataPropertyName = "NRO_GUIA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ReadOnly = True
        End With

        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .HeaderText = "RAZON SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .Width = 300
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ReadOnly = True
        End With

        Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
        With NOMBRE_AGENCIA
            .HeaderText = "NOMBRE DE AGENCIA"
            .Name = "NOMBRE_AGENCIA"
            .DataPropertyName = "NOMBRE_AGENCIA_ORI"
            .Width = 140
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ReadOnly = True
        End With

        Dim origen_destino As New DataGridViewTextBoxColumn
        With origen_destino
            .HeaderText = "ORI - DESTI"
            .Name = "origen_destino"
            .DataPropertyName = "origen_destino"
            .Width = 90
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ReadOnly = True
        End With

        Dim FECHA_GUIA As New DataGridViewTextBoxColumn
        With FECHA_GUIA
            .HeaderText = "FECHA GUIA"
            .Name = "FECHA_GUIA"
            .DataPropertyName = "FECHA_GUIA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ReadOnly = True
        End With

        Dim FECHA_MES As New DataGridViewTextBoxColumn
        With FECHA_MES
            .HeaderText = "MES"
            .Name = "MES"
            .DataPropertyName = "MES"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ReadOnly = True
        End With

        Dim FECHA_ANIO As New DataGridViewTextBoxColumn
        With FECHA_ANIO
            .HeaderText = "AÑO"
            .Name = "ANIO"
            .DataPropertyName = "ANIO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ReadOnly = True
        End With

        Dim NRO_LIQUI_DEVO_CARGO As New DataGridViewTextBoxColumn
        With NRO_LIQUI_DEVO_CARGO
            .HeaderText = "NRO. LIQUID. DEV. CARGO"
            .Name = "NRO_LIQUI_DEVO_CARGO"
            .DataPropertyName = "NRO_LIQUI_DEVO_CARGO"
            .Width = 150
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ReadOnly = True
        End With

        Dim FORMA_PAGO As New DataGridViewTextBoxColumn
        With FORMA_PAGO
            .HeaderText = "FORMA DE PAGO"
            .Name = "FORMA_PAGO"
            .DataPropertyName = "FORMA_PAGO"
            .Width = 120
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ReadOnly = True
        End With

        Dim CENTRO_COSTO As New DataGridViewTextBoxColumn
        With CENTRO_COSTO
            .HeaderText = "CENTRO DE COSTO"
            .Name = "CENTRO_COSTO"
            .DataPropertyName = "CENTRO_COSTO"
            .Width = 160
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ReadOnly = True
        End With

        Dim SUB_TOTAL As New DataGridViewTextBoxColumn
        With SUB_TOTAL
            .HeaderText = "SUBTOTAL"
            .Name = "SUB_TOTAL"
            .DataPropertyName = "SUB_TOTAL"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim MONTO_IMPUESTO As New DataGridViewTextBoxColumn
        With MONTO_IMPUESTO
            .HeaderText = "IMPUESTOS"
            .Name = "MONTO_IMPUESTO"
            .DataPropertyName = "MONTO_IMPUESTO"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
        With TOTAL_COSTO
            .HeaderText = "TOTAL"
            .Name = "TOTAL_COSTO"
            .DataPropertyName = "TOTAL_COSTO"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim FECHA_ENTREGA As New DataGridViewTextBoxColumn
        With FECHA_ENTREGA
            .HeaderText = "F. ENTREGA"
            .Name = "FECHA_ENTREGA"
            .DataPropertyName = "FECHA_ENTREGA"
            .Width = 120
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ReadOnly = True
        End With

        Dim FECHA_DEVO_CARGOS As New DataGridViewTextBoxColumn
        With FECHA_DEVO_CARGOS
            .HeaderText = "F. DEV. CARGOS"
            .Name = "FECHA_DEVO_CARGOS"
            .DataPropertyName = "FECHA_DEVO_CARGOS"
            .Width = 120
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ReadOnly = True
        End With

        Dim FECHA_DOC As New DataGridViewTextBoxColumn
        With FECHA_DOC
            .HeaderText = "F. REVISION"
            .Name = "FECHA_DOC"
            .DataPropertyName = "FECHA_DOC"
            .Width = 120
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ReadOnly = True
        End With

        Dim NRO_PREFACTURA As New DataGridViewTextBoxColumn
        With NRO_PREFACTURA
            .HeaderText = "PRE_FACTURA"
            .Name = "NRO_PREFACTURA"
            .DataPropertyName = "NRO_PREFACTURA"
            .Width = 130
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ReadOnly = True
        End With

        Dim NRO_FACTURA As New DataGridViewTextBoxColumn
        With NRO_FACTURA
            .HeaderText = "FACTURA"
            .Name = "NRO_FACTURA"
            .DataPropertyName = "NRO_FACTURA"
            .Width = 130
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ReadOnly = True
        End With

        Dim TIPO_RECEPCION_DOCU As New DataGridViewTextBoxColumn
        With TIPO_RECEPCION_DOCU
            .HeaderText = "TIPO_RECEPCION_DOCU"
            .Name = "TIPO_RECEPCION_DOCU"
            .DataPropertyName = "TIPO_RECEPCION_DOCU"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ReadOnly = True
        End With

        Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO
            .HeaderText = "ESTADO_REGISTRO"
            .Name = "ESTADO_REGISTRO_ENVIO"
            .DataPropertyName = "ESTADO_REGISTRO_ENVIO"
            .Width = 120
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ReadOnly = True
        End With

        Dim FUNCIONARIO As New DataGridViewTextBoxColumn
        With FUNCIONARIO
            .HeaderText = "FUNCIONARIO"
            .Name = "FUNCIONARIO"
            .DataPropertyName = "FUNCIONARIO"
            .Width = 210
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ReadOnly = True
        End With





        Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
        With SIMBOLO_MONEDA
            .HeaderText = "SIMBOLO_MONEDA"
            .Name = "SIMBOLO_MONEDA"
            .DataPropertyName = "SIMBOLO_MONEDA"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ReadOnly = True
        End With
        Dim LOGIN As New DataGridViewTextBoxColumn
        With LOGIN
            .HeaderText = "LOGIN"
            .Name = "LOGIN"
            .DataPropertyName = "LOGIN"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SERIE_GUIA_ENVIO As New DataGridViewTextBoxColumn
        With SERIE_GUIA_ENVIO
            .HeaderText = "SERIE_GUIA_ENVIO"
            .Name = "SERIE_GUIA_ENVIO"
            .DataPropertyName = "SERIE_GUIA_ENVIO"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .DefaultCellStyle.NullValue = "000"
        End With

        Dim FECHA_REVISION As New DataGridViewTextBoxColumn
        With FECHA_REVISION
            .HeaderText = "FECHA_REVISION"
            .Name = "FECHA_REVISION"
            .DataPropertyName = "FECHA_REVISION"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FECHA_CARGOS As New DataGridViewTextBoxColumn
        With FECHA_CARGOS
            .HeaderText = "F. CARGO"
            .Name = "FECHA_CARGOS"
            .DataPropertyName = "FECHA_CARGOS"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim DT As New DataGridViewTextBoxColumn
        With DT
            .HeaderText = "DT"
            .Name = "dt"
            .DataPropertyName = "DT"
            '.Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ReadOnly = True
        End With

        Dim FechaRecojo As New DataGridViewTextBoxColumn
        With FechaRecojo
            .HeaderText = "F. RECOJO"
            .Name = "fecha_recojo"
            .DataPropertyName = "fecha_recojo"
            '.Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ReadOnly = True
        End With


        'Dim blnDT As Boolean = False
        'If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) <> -1 Then
        '    If ID_PERSONA_QUIMICA_SUIZA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString)) Then
        '        blnDT = True
        '    End If
        'End If

        With DGV3
            '.Columns.AddRange(NOMBRE_AGENCIA, origen_destino, LOGIN, RAZON_SOCIAL, NRO_LIQUI_DEVO_CARGO, NRO_GUIA, FECHA_GUIA, FORMA_PAGO, SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, FECHA_ENTREGA, FECHA_DEVO_CARGOS, FECHA_DOC, NRO_PREFACTURA, NRO_FACTURA, TIPO_RECEPCION_DOCU, ESTADO_REGISTRO)
            'If blnDT Then
            .Columns.AddRange(NRO_GUIA, RAZON_SOCIAL, FECHA_GUIA, FECHA_MES, FECHA_ANIO, NOMBRE_AGENCIA, origen_destino, NRO_LIQUI_DEVO_CARGO, FORMA_PAGO, CENTRO_COSTO,
             SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, FECHA_ENTREGA, FECHA_DEVO_CARGOS, FECHA_DOC, NRO_PREFACTURA, NRO_FACTURA, TIPO_RECEPCION_DOCU, ESTADO_REGISTRO, FUNCIONARIO, DT, FechaRecojo)
            'Else
            '.Columns.AddRange(NRO_GUIA, RAZON_SOCIAL, FECHA_GUIA, FECHA_MES, FECHA_ANIO, NOMBRE_AGENCIA, origen_destino, NRO_LIQUI_DEVO_CARGO, FORMA_PAGO, CENTRO_COSTO,
            '                 SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, FECHA_ENTREGA, FECHA_DEVO_CARGOS, FECHA_DOC, NRO_PREFACTURA, NRO_FACTURA, TIPO_RECEPCION_DOCU, ESTADO_REGISTRO, FUNCIONARIO)
            'End If
        End With
    End Sub

    Private Sub FrmConsulGuiasRetor_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        blnInicio = False
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmConsulGuiasRetor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmConsulFactuEmiti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            blnInicio = True
            MenuTab.Items(0).Text = "Pendientes por retornar"
            MenuTab.Items(1).Enabled = False
            MenuTab.Items(2).Enabled = False
            MenuTab.Items(3).Enabled = False
            MenuTab.Items(4).Enabled = False
            MenuTab.Items(5).Enabled = False

            Me.ShadowLabel1.Text = "Consulta de Pendientes por Retornar"
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False

            'objgeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago, VOCONTROLUSUARIO)
            ''dvlistar_forma_pago.RowFilter = "idforma_pago <> 2"
            'cbidforma_pago.DataSource = dvlistar_forma_pago
            'cbidforma_pago.DisplayMember = "FORMA_PAGO"
            'cbidforma_pago.ValueMember = "IDFORMA_PAGO"

            'objgeneral.fnlistar_tipo_comprobante(dvlistar_forma_pago, Me.cbidtipo_comprobante, VOCONTROLUSUARIO)
            'dvlistar_forma_pago.RowFilter = "IDTIPO_COMPROBANTE = 1 or IDTIPO_COMPROBANTE = 2 or IDTIPO_COMPROBANTE = 3"

            'objgeneral.FNLISTAR_TIPO_MONEDA(dvlistar_tipo_moneda, Me.cbidtipo_comprobante, VOCONTROLUSUARIO)

            'datahelper
            'objgeneral.FN_cmb_Listar_agencias(cnn, Me.cmbAgencia)
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
            'objgeneral.sp_listar_t_tipo_facturacion(cnn, cmbtipofacturacion)
            objgeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA)
            objgeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA_DESTINO)
            objgeneral.sp_listar_t_tipo_facturacion(cmbtipofacturacion)

            ''Mod.18/09/2009 -->Omendoza - Pasando al datahelper   
            objgeneral.fn_L_TIPO_ENTREGA(dvidtipo_entrega, Me.cbidtipo_entrega)
            '
            'datahelper
            'objgeneral.FN_cmb_L_tipo_recepcion_docu(cnn, Me.CBIDTIPO_RECEPCION_DOCU)
            objgeneral.FN_cmb_L_tipo_recepcion_docu(Me.CBIDTIPO_RECEPCION_DOCU)

            'Me.cbidforma_pago.SelectedIndex = -1
            'Me.cbidtipo_comprobante.SelectedIndex = -1
            Me.cmbAgencia.SelectedIndex = -1
            Me.cmbagencia_destino.SelectedIndex = -1
            'Me.cmbUsuarios.SelectedIndex = -1
            Me.CBIDUNIDAD_AGENCIA.SelectedIndex = -1
            Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndex = -1

            Me.cbidtipo_entrega.SelectedIndex = -1
            CBIDTIPO_RECEPCION_DOCU.SelectedIndex = -1

            cmbtipofacturacion.SelectedIndex = -1


            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub cmbAgencia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAgencia.GotFocus
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        DGV3.DataSource = Nothing
    End Sub

    'Private Sub cmbAgencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbAgencia.KeyPress
    '    If e.KeyChar = Chr(13) Then
    '        Me.cmbUsuarios.Focus()
    '    End If
    'End Sub




    'Private Sub cmbAgencia_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectionChangeCommitted
    '    Dim p_id_rol_usuario, p_idagencia As Int64
    '    p_id_rol_usuario = 0
    '    If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
    '        p_idagencia = CType(Me.cmbAgencia.SelectedValue, Int64)
    '        objgeneral.FN_cmb_LISTAR_USUARIOS_AGENCIAS(cnn, Me.cmbUsuarios, p_id_rol_usuario, p_idagencia)
    '    Else
    '        cmbUsuarios.DataSource = Nothing
    '    End If
    '    Me.cmbUsuarios.SelectedIndex = -1

    'End Sub


    Private Sub FrmConsulFactuEmiti_MenuExportar() Handles Me.MenuExportar

    End Sub


    Private Sub FrmConsulFactuEmiti_MenuImprimir() Handles Me.MenuImprimir
        Try
            ObjReport.Dispose()
        Catch
        End Try
        ObjReport = New ClsLbTepsa.dtoFrmReport
        Select Case Me.TabMante.SelectedIndex
            Case 0
                Try
                    If Me.DGV3.RowCount <= 0 Then
                        MsgBox("No existen registro", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
                        Exit Sub
                    End If

                    Dim ObjGuias As New ClsLbTepsa.dtoguias

                    If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                        ObjGuias.IDPERSONA = 0
                    Else

                        ObjGuias.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                    End If
                    If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjGuias.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjGuias.FECHA_INICIO = "NULL"
                    If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjGuias.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjGuias.FECHA_FINAL = "NULL"
                    'If Not IsNothing(Me.cbidtipo_comprobante.SelectedValue) Then
                    '    ObjGuias.IDTIPO_COMPROBANTE = Me.cbidtipo_comprobante.SelectedValue
                    'Else
                    '    ObjGuias.IDTIPO_COMPROBANTE = 0
                    'End If
                    'ObjGuias.IDTIPO_MONEDA = 0
                    'If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
                    '    ObjGuias.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
                    'Else
                    '    ObjGuias.IDUSUARIO_PERSONAL = 0
                    'End If

                    If Len(Me.tbnro_factura.Text.Trim) = 0 Then
                        ObjGuias.NRO_GUIA = 0
                    Else
                        ObjGuias.NRO_GUIA = Me.tbnro_factura.Text.Trim
                    End If



                    If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
                        ObjGuias.IDUNIDAD_AGENCIA = Me.CBIDUNIDAD_AGENCIA.SelectedValue
                    Else
                        ObjGuias.IDUNIDAD_AGENCIA = 0
                    End If

                    If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                        ObjGuias.IDAGENCIAS = Me.cmbAgencia.SelectedValue
                    Else
                        ObjGuias.IDAGENCIAS = 0
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                        ObjGuias.IDUNIDAD_AGENCIA_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
                    Else
                        ObjGuias.IDUNIDAD_AGENCIA_DESTINO = 0
                    End If

                    If Not IsNothing(Me.cmbagencia_destino.SelectedValue) Then
                        ObjGuias.idagencias_destino = Me.cmbagencia_destino.SelectedValue
                    Else
                        ObjGuias.idagencias_destino = 0
                    End If

                    If Not IsNothing(Me.cmbtipofacturacion.SelectedValue) Then
                        ObjGuias.IDTIPO_FACTURACION = Me.cmbtipofacturacion.SelectedValue
                    Else
                        ObjGuias.IDTIPO_FACTURACION = -1
                    End If

                    Dim fecha_filtro As String

                    If Me.RBFECHA_DOC.Checked = True Then
                        fecha_filtro = "FDOC"
                    ElseIf Me.RBFECHA_ENTRE.Checked = True Then
                        fecha_filtro = "FENT"
                    ElseIf Me.RBFECHA_DEVO_CARGO.Checked = True Then
                        fecha_filtro = "FDEV"
                    Else
                        fecha_filtro = "FREV"
                    End If


                    'If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
                    '    ObjGuias.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
                    'Else
                    '    ObjGuias.IDFORMA_PAGO = 0
                    'End If
                    'If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
                    '    ObjGuias.IDUNIDAD_ORIGEN = Me.CBIDUNIDAD_AGENCIA.SelectedValue
                    'Else
                    '    ObjGuias.IDUNIDAD_ORIGEN = 0
                    'End If

                    'If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                    '    ObjGuias.IDUNIDAD_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
                    'Else
                    '    ObjGuias.IDUNIDAD_DESTINO = 0
                    'End If

                    If Not IsNothing(Me.cbidtipo_entrega.SelectedValue) Then
                        ObjGuias.IDTIPO_ENTREGA_CARGA = Me.cbidtipo_entrega.SelectedValue
                    Else
                        ObjGuias.IDTIPO_ENTREGA_CARGA = 0
                    End If

                    Dim titulo As String

                    'If Me.RBRETOR.Checked = True Then
                    '    ObjGuias.RETOR = 1
                    '    titulo = "REPORTE DE GUIAS DE ENVIO CON CARGO "
                    'ElseIf Me.RBSinRetor.Checked = True Then
                    '    ObjGuias.RETOR = 0
                    '    titulo = "REPORTE DE GUIAS DE ENVIO SIN CARGO "
                    'Else
                    '    ObjGuias.RETOR = 2
                    '    titulo = "REPORTE DE GUIAS DE ENVIO "
                    'End If
                    If Me.rbresumido.Checked = True Then
                        titulo = "REPORTE DE GUIAS DE ENVIO (RESUMIDO)"
                    Else
                        titulo = "REPORTE DE GUIAS DE ENVIO"
                    End If

                    ObjGuias.RETOR = 2

                    If Me.RBFactu.Checked Then
                        ObjGuias.FACTURADO = 1
                        titulo = titulo + "(FACTURADOS)"
                    ElseIf Me.RBSinFactu.Checked Then
                        ObjGuias.FACTURADO = 0
                        titulo = titulo + "(SIN FACTURAR)"
                    ElseIf Me.RBPREFACTURADO.Checked Then
                        ObjGuias.FACTURADO = 11
                        titulo = titulo + "(PREFACTURADO)"
                    ElseIf Me.rbSinPrefac.Checked = True Then
                        ObjGuias.FACTURADO = 10
                        titulo = titulo + "(SIN PREFACTURAR)"
                    Else
                        ObjGuias.FACTURADO = 2
                    End If


                    If Not IsNothing(Me.CBIDTIPO_RECEPCION_DOCU.SelectedValue) Then
                        ObjGuias.IDTIPO_RECEPCION_DOCU = Me.CBIDTIPO_RECEPCION_DOCU.SelectedValue
                    Else
                        ObjGuias.IDTIPO_RECEPCION_DOCU = "0"
                    End If
                    Dim rango_o_liquidacion As String = "(Desde el " & Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString & " hasta el " & Me.DTPFECHAFINALFACTURA.Value.ToShortDateString & ")"

                    If Len(Me.txtNRO_LIQUI_DEVO_CARGO.Text) = 0 Then
                        ObjGuias.NRO_LIQUI_DEVO_CARGO = 0
                    Else
                        If ObjValida.NUMERO_ENTERO(txtNRO_LIQUI_DEVO_CARGO, Me) = False Then
                            Exit Sub
                        Else
                            ObjGuias.NRO_LIQUI_DEVO_CARGO = Me.txtNRO_LIQUI_DEVO_CARGO.Text.Trim
                            rango_o_liquidacion = "Liquidación de Devolución de Cargo Nro.: " & Me.txtNRO_LIQUI_DEVO_CARGO.Text
                        End If
                    End If

                    'hlamas 24-10-2013
                    If IsNothing(Me.cmbSubcuenta.SelectedValue) Then
                        ObjGuias.Subcuenta = -1
                    Else
                        ObjGuias.Subcuenta = Me.cmbSubcuenta.SelectedValue
                    End If

                    With ObjGuias

                        .IDGUIAS_ENVIO = Me.dvListar_guias.Table.Rows(Me.DGV3.CurrentRow.Index)("IDGUIAS_ENVIO")


                        ObjReport.rutaRpt = PathFrmReport
                        ObjReport.conectar(rptservice, rptuser, rptpass)
                        If Me.rbdetallado.Checked = True Then
                            'If Me.RBGENE.Checked = True Then
                            ObjReport.printrptB(False, "", "GUI011_1.RPT", _
                            "p_RETOR;" & .RETOR, _
                            "p_idunidad_agencia;" & .IDUNIDAD_AGENCIA, _
                            "p_idagencias;" & .IDAGENCIAS, _
                            "p_idunidad_agencia_destino;" & .IDUNIDAD_AGENCIA_DESTINO, _
                            "p_idagencias_destino;" & .idagencias_destino, _
                            "p_fecha_ini;" & .FECHA_INICIO, _
                            "p_fecha_final;" & .FECHA_FINAL, _
                            "p_IDPERSONA;" & .IDPERSONA, _
                            "p_IDTIPO_FACTURACION;" & .IDTIPO_FACTURACION, _
                            "p_IDTIPO_RECEPCION_DOCU;" & .IDTIPO_RECEPCION_DOCU, _
                            "p_idforma_pago;" & .IDFORMA_PAGO, _
                            "p_fecha_filtro;" & fecha_filtro, _
                            "p_idtipo_entrega;" & .IDTIPO_ENTREGA_CARGA, _
                            "p_NRO_GUIA;" & .NRO_GUIA & ";" & .Subcuenta, _
                            "p_FACTURADO;" & .FACTURADO, _
                            "p_NRO_LIQUI_DEVO_CARGO;" & .NRO_LIQUI_DEVO_CARGO, _
                            "p_TITULO;" & titulo, _
                            "p_titulo_fecha;" & rango_o_liquidacion)

                        ElseIf Me.rbresumido.Checked = True Then
                            ObjReport.printrptB(False, "", "GUI021.RPT", _
                            "p_RETOR;" & .RETOR, _
                            "p_idunidad_agencia;" & .IDUNIDAD_AGENCIA, _
                            "p_idagencias;" & .IDAGENCIAS, _
                            "p_idunidad_agencia_destino;" & .IDUNIDAD_AGENCIA_DESTINO, _
                            "p_idagencias_destino;" & .idagencias_destino, _
                            "p_fecha_ini;" & .FECHA_INICIO, _
                            "p_fecha_final;" & .FECHA_FINAL, _
                            "p_IDPERSONA;" & .IDPERSONA, _
                            "p_IDTIPO_FACTURACION;" & .IDTIPO_FACTURACION, _
                            "p_IDTIPO_RECEPCION_DOCU;" & .IDTIPO_RECEPCION_DOCU, _
                            "p_idforma_pago;" & .IDFORMA_PAGO, _
                            "p_fecha_filtro;" & fecha_filtro, _
                            "p_idtipo_entrega;" & .IDTIPO_ENTREGA_CARGA, _
                            "p_NRO_GUIA;" & .NRO_GUIA & ";" & .Subcuenta, _
                            "p_FACTURADO;" & .FACTURADO, _
                            "p_NRO_LIQUI_DEVO_CARGO;" & .NRO_LIQUI_DEVO_CARGO, _
                            "p_TITULO;" & titulo, _
                            "p_titulo_fecha;" & rango_o_liquidacion)
                        ElseIf Me.rbDt.Checked Then
                            ObjReport.printrptB(False, "", "GUI024.RPT", _
                            "p_RETOR;" & .RETOR, _
                            "p_idunidad_agencia;" & .IDUNIDAD_AGENCIA, _
                            "p_idagencias;" & .IDAGENCIAS, _
                            "p_idunidad_agencia_destino;" & .IDUNIDAD_AGENCIA_DESTINO, _
                            "p_idagencias_destino;" & .idagencias_destino, _
                            "p_fecha_ini;" & .FECHA_INICIO, _
                            "p_fecha_final;" & .FECHA_FINAL, _
                            "p_IDPERSONA;" & .IDPERSONA, _
                            "p_IDTIPO_FACTURACION;" & .IDTIPO_FACTURACION, _
                            "p_IDTIPO_RECEPCION_DOCU;" & .IDTIPO_RECEPCION_DOCU, _
                            "p_idforma_pago;" & .IDFORMA_PAGO, _
                            "p_fecha_filtro;" & fecha_filtro, _
                            "p_idtipo_entrega;" & .IDTIPO_ENTREGA_CARGA, _
                            "p_NRO_GUIA;" & .NRO_GUIA & ";" & .Subcuenta, _
                            "p_FACTURADO;" & .FACTURADO, _
                            "p_NRO_LIQUI_DEVO_CARGO;" & .NRO_LIQUI_DEVO_CARGO, _
                            "p_TITULO;" & titulo, _
                            "p_titulo_fecha;" & rango_o_liquidacion)
                        Else
                            ObjReport.printrptB(False, "", "GUI022.RPT", _
                            "p_RETOR;" & .RETOR, _
                            "p_idunidad_agencia;" & .IDUNIDAD_AGENCIA, _
                            "p_idagencias;" & .IDAGENCIAS, _
                            "p_idunidad_agencia_destino;" & .IDUNIDAD_AGENCIA_DESTINO, _
                            "p_idagencias_destino;" & .idagencias_destino, _
                            "p_fecha_ini;" & .FECHA_INICIO, _
                            "p_fecha_final;" & .FECHA_FINAL, _
                            "p_IDPERSONA;" & .IDPERSONA, _
                            "p_IDTIPO_FACTURACION;" & .IDTIPO_FACTURACION, _
                            "p_IDTIPO_RECEPCION_DOCU;" & .IDTIPO_RECEPCION_DOCU, _
                            "p_idforma_pago;" & .IDFORMA_PAGO, _
                            "p_fecha_filtro;" & fecha_filtro, _
                            "p_idtipo_entrega;" & .IDTIPO_ENTREGA_CARGA, _
                            "p_NRO_GUIA;" & .NRO_GUIA & ";" & .Subcuenta, _
                            "p_FACTURADO;" & .FACTURADO, _
                            "p_NRO_LIQUI_DEVO_CARGO;" & .NRO_LIQUI_DEVO_CARGO, _
                            "p_TITULO;" & titulo, _
                            "p_titulo_fecha;" & rango_o_liquidacion)
                        End If
                        'Else
                        'ObjReport.printrptB(False, "", "FAC011.RPT", _
                        ' "p_idpersona;" & .IDPERSONA, _
                        ' "p_idforma_pago;" & .IDFORMA_PAGO, _
                        ' "p_idtipo_moneda;" & .IDTIPO_MONEDA, _
                        ' "p_idagencias;" & .IDAGENCIAS, _
                        ' "p_idusuario_personal;" & .IDUSUARIO_PERSONAL, _
                        ' "p_idunidad_origen;" & .IDUNIDAD_ORIGEN, _
                        ' "p_idunidad_destino;" & .IDUNIDAD_DESTINO, _
                        ' "p_nro_factura;" & .NRO_FACTURA, _
                        ' "p_idtipo_comprobante;" & .IDTIPO_COMPROBANTE, _
                        ' "p_fecha_inicial;" & .FECHA_INICIO, _
                        ' "p_fecha_final;" & .FECHA_FINAL, _
                        ' "p_idtipo_entrega;" & .IDTIPO_ENTREGA, _
                        ' "p_rango_fecha;" & "(Desde el " & .FECHA_INICIO & " hasta el " & .FECHA_FINAL & ")", _
                        ' "p_entre;" & P_ENTRE)
                        'End If

                    End With
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
                End Try
        End Select
    End Sub

    Private Sub FrmConsulFactuEmiti_MenuSalir() Handles Me.MenuSalir
        Close()
    End Sub

    Private Sub txtidpersona_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtidpersona.GotFocus, _
    DTPFECHAINICIOFACTURA.GotFocus, _
    DTPFECHAFINALFACTURA.GotFocus, _
    txtNRO_LIQUI_DEVO_CARGO.GotFocus, _
    tbnro_factura.GotFocus, _
    cmbAgencia.GotFocus, _
    cbidtipo_entrega.GotFocus, RBFactu.GotFocus, RBSinFactu.GotFocus, RBFactuAmbos.GotFocus, RBPREFACTURADO.GotFocus

        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        DGV3.DataSource = Nothing
        L1.Text = ""
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
                        'hlamas 18-09-2013
                        Controla(.IDPERSONA)
                        'hlamas 24-10-2013
                        CargarSubcuentaDestino(.IDPERSONA, 0)

                        Me.DTPFECHAINICIOFACTURA.Focus()
                    End With
                    'Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
                Else
                    Me.txtCodigoCliente.Text = ""
                    'hlamas 18-09-2013
                    Controla(0)
                    'hlamas 24-10-2013
                    Me.cmbSubcuenta.DataSource = Nothing
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
            Me.cmbSubcuenta.DataSource = Nothing
            Controla(0)
        End If
    End Sub

    Private Sub txtidpersona_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtidpersona.TextChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub txtCodigoCliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.GotFocus, tbnro_factura.GotFocus
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
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
                    'hlamas 18-09-2013
                    Controla(0)
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
                'hlamas 18-09-2013
                Controla(ObjPersona.IDPERSONA)
            End If
        Catch EX As Exception
            MsgBox(EX.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub tbnro_factura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbnro_factura.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cmbAgencia.Focus()
        End If


        If e.KeyChar.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "-" Then
            e.Handled = False
        Else
            e.Handled = True
        End If




    End Sub

    Private Sub txtCodigoCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.LostFocus, tbnro_factura.LostFocus
        If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
            Me.txtidpersona.Text = ""
            Me.txtCodigoCliente.Text = ""
            Controla(0)
        End If
    End Sub



    Private Sub DTPFECHAINICIOFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.GotFocus
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAINICIOFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            DTPFECHAFINALFACTURA.Focus()
        End If
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.ValueChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.GotFocus
        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0
        DGV3.DataSource = Nothing
    End Sub

    'Private Sub DTPFECHAFINALFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAFINALFACTURA.KeyPress
    '    If e.KeyChar = Chr(13) Then
    '        Me.cbidtipo_comprobante.Focus()
    '    End If
    'End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    'Private Sub cbidtipo_moneda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbidtipo_comprobante.GotFocus
    '    Me.txtsub_total.Text = 0
    '    Me.txtmonto_impuesto.Text = 0
    '    Me.txttotal_costo.Text = 0
    '    DGV3.DataSource = Nothing
    'End Sub

    'Private Sub cbidtipo_moneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar = Chr(13) Then
    '        Me.cbidforma_pago.Focus()
    '    End If
    'End Sub

    'Private Sub cbidforma_pago_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbidforma_pago.GotFocus
    '    Me.txtsub_total.Text = 0
    '    Me.txtmonto_impuesto.Text = 0
    '    Me.txttotal_costo.Text = 0
    '    DGV3.DataSource = Nothing
    'End Sub

    Private Sub cbidforma_pago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            Me.tbnro_factura.Focus()
        End If
    End Sub

    Private Sub cmbAgencia_LostFocus(sender As Object, e As System.EventArgs) Handles cmbAgencia.LostFocus
        If IsNothing(Me.cmbAgencia.SelectedValue) Then
            Me.cmbAgencia.Text = ""
        End If
    End Sub

    'Private Sub cmbUsuarios_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUsuarios.GotFocus
    '    Me.txtsub_total.Text = 0
    '    Me.txtmonto_impuesto.Text = 0
    '    Me.txttotal_costo.Text = 0
    '    DGV3.DataSource = Nothing
    'End Sub


    'Private Sub cmbUsuarios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar = Chr(13) Then
    '        Me.CBIDUNIDAD_AGENCIA.Focus()
    '    End If
    'End Sub


    Private Sub cmbAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub
    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cbidforma_pago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub tbnro_factura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnro_factura.TextChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub cmbUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            Me.Button3.Focus()
        End If
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cbidtipo_entrega_LostFocus(sender As Object, e As System.EventArgs) Handles cbidtipo_entrega.LostFocus
        If IsNothing(Me.cbidtipo_entrega.SelectedValue) Then
            Me.cbidtipo_entrega.Text = ""
        End If
    End Sub

    'Private Sub CBIDUNIDAD_AGENCIA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidtipo_entrega.KeyPress
    '    If e.KeyChar = Chr(13) Then
    '        Me.CBIDUNIDAD_AGENCIA_DESTINO.Focus()
    '    End If
    'End Sub

    Private Sub CBIDUNIDAD_AGENCIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbidtipo_entrega.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub
    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_LostFocus(sender As Object, e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA.LostFocus
        If IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
            Me.CBIDUNIDAD_AGENCIA.Text = ""
        End If
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_LostFocus(sender As Object, e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.LostFocus
        If IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
            Me.CBIDUNIDAD_AGENCIA_DESTINO.Text = ""
        End If
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.SelectedValueChanged
        If Not blnInicio Then
            Me.DGV3.DataSource = Nothing
        End If
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.SelectionChangeCommitted
        Try
            Dim p_idunidad_agencia As Int64

            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                p_idunidad_agencia = CType(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue, Int64)
                'datahelper
                'objgeneral.SP_cmb_LIST_AGENCIAS_UNIDAD(cnn, Me.cmbagencia_destino, p_idunidad_agencia)
                objgeneral.SP_cmb_LIST_AGENCIAS_UNIDAD(Me.cmbagencia_destino, p_idunidad_agencia)
            Else
                Me.cmbagencia_destino.DataSource = Nothing
            End If
            Me.cmbagencia_destino.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA.SelectedValueChanged
        If Not blnInicio Then
            Me.DGV3.DataSource = Nothing
        End If
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA.SelectionChangeCommitted
        Dim p_idunidad_agencia As Int64

        If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
            p_idunidad_agencia = CType(Me.CBIDUNIDAD_AGENCIA.SelectedValue, Int64)
            'datahelper
            'objgeneral.SP_cmb_LIST_AGENCIAS_UNIDAD(cnn, Me.cmbAgencia, p_idunidad_agencia)
            objgeneral.SP_cmb_LIST_AGENCIAS_UNIDAD(Me.cmbAgencia, p_idunidad_agencia)
        Else
            Me.cmbAgencia.DataSource = Nothing

        End If
        Me.cmbAgencia.SelectedIndex = -1
    End Sub

    Private Sub txtNRO_LIQUI_DEVO_CARGO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNRO_LIQUI_DEVO_CARGO.KeyPress

        If e.KeyChar.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub


    Private Sub txtNRO_LIQUI_DEVO_CARGO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNRO_LIQUI_DEVO_CARGO.TextChanged
        If Len(txtNRO_LIQUI_DEVO_CARGO.Text) = 0 Then
            bloquer_x_nro_liquidacion(True)
        Else
            bloquer_x_nro_liquidacion(False)
        End If
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub bloquer_x_nro_liquidacion(ByVal p_valor As Boolean)

        txtCodigoCliente.Enabled = p_valor
        Me.txtCodigoCliente.Text = ""
        txtidpersona.Enabled = p_valor
        txtidpersona.Text = ""
        RBFECHA_DOC.Enabled = p_valor
        RBFECHA_ENTRE.Enabled = p_valor
        RBFECHA_DEVO_CARGO.Enabled = p_valor
        rbfecha_revi.Enabled = p_valor
        DTPFECHAINICIOFACTURA.Enabled = p_valor
        DTPFECHAFINALFACTURA.Enabled = p_valor
        cmbtipofacturacion.Enabled = p_valor
        cmbtipofacturacion.SelectedIndex = -1
        tbnro_factura.Enabled = p_valor
        tbnro_factura.Text = ""
        cbidtipo_entrega.Enabled = p_valor
        cbidtipo_entrega.SelectedIndex = -1
        CBIDTIPO_RECEPCION_DOCU.Enabled = p_valor
        CBIDTIPO_RECEPCION_DOCU.SelectedIndex = -1
        CBIDUNIDAD_AGENCIA.Enabled = p_valor
        CBIDUNIDAD_AGENCIA.SelectedIndex = -1
        CBIDUNIDAD_AGENCIA_DESTINO.Enabled = p_valor
        CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndex = -1
        cmbAgencia.Enabled = p_valor
        cmbAgencia.SelectedIndex = -1
        cmbagencia_destino.Enabled = p_valor
        cmbagencia_destino.SelectedIndex = -1
        RBFactu.Enabled = p_valor
        RBSinFactu.Enabled = p_valor
        RBFactuAmbos.Enabled = p_valor
        Me.rbSinPrefac.Enabled = p_valor
        Me.RBPREFACTURADO.Enabled = p_valor

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
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBFECHA_DOC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBFECHA_DOC.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBFECHA_ENTRE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBFECHA_ENTRE.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBFECHA_DEVO_CARGO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBFECHA_DEVO_CARGO.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub rbfecha_revi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbfecha_revi.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub cmbtipofacturacion_LostFocus(sender As Object, e As System.EventArgs) Handles cmbtipofacturacion.LostFocus
        If IsNothing(Me.cmbtipofacturacion.SelectedValue) Then
            Me.cmbtipofacturacion.Text = ""
        End If
    End Sub

    Private Sub cmbtipofacturacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtipofacturacion.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub CBIDTIPO_RECEPCION_DOCU_LostFocus(sender As Object, e As System.EventArgs) Handles CBIDTIPO_RECEPCION_DOCU.LostFocus
        If IsNothing(Me.CBIDTIPO_RECEPCION_DOCU.SelectedValue) Then
            Me.CBIDTIPO_RECEPCION_DOCU.Text = ""
        End If
    End Sub

    Private Sub CBIDTIPO_RECEPCION_DOCU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDTIPO_RECEPCION_DOCU.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub cmbagencia_destino_LostFocus(sender As Object, e As System.EventArgs) Handles cmbagencia_destino.LostFocus
        If IsNothing(Me.cmbagencia_destino.SelectedValue) Then
            Me.cmbagencia_destino.Text = ""
        End If
    End Sub

    Private Sub cmbagencia_destino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbagencia_destino.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub rbSinPrefac_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSinPrefac.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBPREFACTURADO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBPREFACTURADO.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBSinFactu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSinFactu.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBFactu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBFactu.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub RBFactuAmbos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBFactuAmbos.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub rbdetallado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdetallado.CheckedChanged, rbDt.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub rbresumido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbresumido.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub rbagrupordesti_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbagrupordesti.CheckedChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        If DGV3.RowCount < 1 Then
            Return
        Else
            Dim lcls_Utilitarios As New Cls_Utilitarios
            With lcls_Utilitarios
                .S_ExportarDataGridViewExcel(Me.DGV3)
            End With
            lcls_Utilitarios = Nothing
        End If

    End Sub

    Sub Controla(cliente As Integer)
        Try
            If ID_PERSONA_CBC <> cliente Then
                Me.txtDT.Text = ""
                Me.txtDT.Visible = False
                Me.lblDt.Visible = False
                Me.rbDt.Visible = False
                'DGV3.Columns(0).Visible = False
            Else
                Me.lblDt.Visible = True
                Me.txtDT.Visible = True
                Me.rbDt.Visible = True
                DGV3.Columns(0).Visible = True
                DGV3.Sort(DGV3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            End If
        Catch
        End Try
    End Sub

    Private Sub TxtDt_GotFocus(sender As Object, e As System.EventArgs) Handles txtDT.GotFocus
        Me.txtDT.SelectAll()
    End Sub

    Private Sub TxtDt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDT.KeyPress
        If Not ValidaNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub FrmConsulGuiasRetor_InputLanguageChanging(sender As Object, e As System.Windows.Forms.InputLanguageChangingEventArgs) Handles Me.InputLanguageChanging

    End Sub

    Private Sub txtDT_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDT.TextChanged

    End Sub

    Private Sub CBIDTIPO_RECEPCION_DOCU_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles CBIDTIPO_RECEPCION_DOCU.SelectedValueChanged
        If Not blnInicio Then
            Me.DGV3.DataSource = Nothing
        End If
    End Sub

    Private Sub FrmConsulGuiasRetor_AutoSizeChanged(sender As Object, e As System.EventArgs) Handles Me.AutoSizeChanged

    End Sub

    Private Sub cmbtipofacturacion_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cmbtipofacturacion.SelectedValueChanged
        If Not blnInicio Then
            Me.DGV3.DataSource = Nothing
        End If
    End Sub

    Private Sub cbidtipo_entrega_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbidtipo_entrega.SelectedValueChanged
        If Not blnInicio Then
            Me.DGV3.DataSource = Nothing
        End If
    End Sub

    Private Sub cmbAgencia_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cmbAgencia.SelectedValueChanged
        If Not blnInicio Then
            Me.DGV3.DataSource = Nothing
        End If
    End Sub

    Private Sub cmbagencia_destino_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cmbagencia_destino.SelectedValueChanged
        If Not blnInicio Then
            Me.DGV3.DataSource = Nothing
        End If
    End Sub

    Sub CargarSubcuentaDestino(cliente As Integer, ciudad As Integer)
        objGuiaEnvio.dt_cur_Sub_Cuenta_Destino = dtoVentaCargaContado.ListarSubcuentas(cliente, ciudad)
        If (objGuiaEnvio.dt_cur_Sub_Cuenta_Destino.Rows.Count > 0) Then
            With Me.cmbSubcuenta
                .DataSource = objGuiaEnvio.dt_cur_Sub_Cuenta_Destino
                .DisplayMember = "CENTRO_COSTO"
                .ValueMember = "IDCENTRO_COSTO"
                .SelectedValue = 999
            End With
        End If
    End Sub

    Private Sub cmbSubcuenta_LostFocus(sender As Object, e As System.EventArgs) Handles cmbSubcuenta.LostFocus
        If Iwinlistar_persona_todos.IndexOf(txtidpersona.Text) = -1 Then
            Me.cmbSubcuenta.Text = ""
        End If
    End Sub

    Private Sub cmbSubcuenta_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbSubcuenta.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub
End Class

