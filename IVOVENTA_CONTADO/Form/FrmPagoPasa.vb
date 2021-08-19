Public Class FrmPagoPasa

    Dim DV_L_PASA_CREDI_AMOR As New DataView

    Dim DV_L_PASA_CREDI_AMOR_DETA As New DataView

    Dim dvidtipo_entrega As New DataView

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
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        listar_facturas()
    End Sub
    Private Sub listar_facturas()
        Try
            Dim ObjFactura As New ClsLbTepsa.dtoFACTURA
            If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                ObjFactura.IDPERSONA = 0
            Else

                ObjFactura.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
            End If
            If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjFactura.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_INICIO = "NULL"
            If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjFactura.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_FINAL = "NULL"
            If Not IsNothing(Me.cbidtipo_comprobante.SelectedValue) Then
                ObjFactura.IDTIPO_COMPROBANTE = Me.cbidtipo_comprobante.SelectedValue
            Else
                ObjFactura.IDTIPO_COMPROBANTE = 0
            End If
            'ObjFactura.IDTIPO_MONEDA = 0
            'If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
            '    ObjFactura.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
            'Else
            '    ObjFactura.IDUSUARIO_PERSONAL = 0
            'End If

            ObjFactura.SERIE_FACTURA = Mid(Me.MTBNro_factura.Text, 1, 3)
            ObjFactura.NRO_FACTURA = Mid(Me.MTBNro_factura.Text, 5, 7)

            ObjFactura.SERIE_FACTURA = IIf(ObjFactura.SERIE_FACTURA.Trim = "", 0, ObjFactura.SERIE_FACTURA.Trim)
            ObjFactura.NRO_FACTURA = IIf(ObjFactura.NRO_FACTURA.Trim = "", 0, ObjFactura.NRO_FACTURA.Trim)

            If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                ObjFactura.IDAGENCIAS = Me.cmbAgencia.SelectedValue
            Else
                ObjFactura.IDAGENCIAS = 0
            End If

            'If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
            '    ObjFactura.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
            'Else
            '    ObjFactura.IDFORMA_PAGO = 0
            'End If
            'If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
            '    ObjFactura.IDUNIDAD_ORIGEN = Me.CBIDUNIDAD_AGENCIA.SelectedValue
            'Else
            '    ObjFactura.IDUNIDAD_ORIGEN = 0
            'End If

            'If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
            '    ObjFactura.IDUNIDAD_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
            'Else
            '    ObjFactura.IDUNIDAD_DESTINO = 0
            'End If

            'If Not IsNothing(Me.cbidtipo_entrega.SelectedValue) Then
            '    ObjFactura.IDTIPO_ENTREGA = Me.cbidtipo_entrega.SelectedValue
            'Else
            '    ObjFactura.IDTIPO_ENTREGA = 0
            'End If

            'Dim P_ENTRE As String

            'If Me.RBENTRE.Checked = True Then
            '    P_ENTRE = 1
            'ElseIf Me.RBSIN_ENTRE.Checked = True Then
            '    P_ENTRE = 0
            'Else
            '    P_ENTRE = 2
            'End If
            '
            dvListar_facturas = ObjFactura.SP_l_pasa_credi()
            '
            FORMAT_GRILLA3()

            CALCULAR_TOTAL()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub CALCULAR_TOTAL()


        Me.txttotal_costo.Text = 0

        For i As Integer = 0 To dvListar_facturas.Count - 1

            If dvListar_facturas.Table.Rows(i)("SELECCIONAR") = 1 Then
                Me.txttotal_costo.Text = Format(CDbl(Me.txttotal_costo.Text) + dvListar_facturas.Table.Rows(i)("MONTO_TOTAL"), "###,###,###.00")
            End If
        Next



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
            .DataSource = dvListar_facturas
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim SELECCIONAR As New DataGridViewCheckBoxColumn
        With SELECCIONAR
            .HeaderText = "SELECCIONAR"
            .Name = "SELECCIONAR"
            .DataPropertyName = "SELECCIONAR"
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            '.FlatStyle = FlatStyle.Standard
            '.CellTemplate = New DataGridViewCheckBoxCell()
            '.CellTemplate.Style.BackColor = Color.Beige
            .Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
        Dim FECHA_EMISION As New DataGridViewTextBoxColumn
        With FECHA_EMISION
            .HeaderText = "FECHA_EMISION"
            .Name = "FECHA_EMISION"
            .DataPropertyName = "FECHA_EMISION"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim ESTA_PAGO_PASA As New DataGridViewTextBoxColumn
        With ESTA_PAGO_PASA
            .HeaderText = "EST. PAG."
            .Name = "ESTA_PAGO_PASA"
            .DataPropertyName = "ESTA_PAGO_PASA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
        Dim NRO_COMPROBANTE As New DataGridViewTextBoxColumn
        With NRO_COMPROBANTE
            .HeaderText = "NRO_COMPROBANTE"
            .Name = "NRO_COMPROBANTE"
            .DataPropertyName = "NRO_COMPROBANTE"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
        Dim SERIE_COMPROBANTE As New DataGridViewTextBoxColumn
        With SERIE_COMPROBANTE
            .HeaderText = "SERIE_COMPROBANTE"
            .Name = "SERIE_COMPROBANTE"
            .DataPropertyName = "SERIE_COMPROBANTE"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
        Dim MONTO_TOTAL As New DataGridViewTextBoxColumn
        With MONTO_TOTAL
            .HeaderText = "MONTO_TOTAL"
            .Name = "MONTO_TOTAL"
            .DataPropertyName = "MONTO_TOTAL"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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

        With DGV3
            .Columns.AddRange(SELECCIONAR, RAZON_SOCIAL, TIPO_COMPROBANTE, SERIE_COMPROBANTE, NRO_COMPROBANTE, FECHA_EMISION, MONTO_TOTAL, ESTADO_REGISTRO, ESTA_PAGO_PASA)

        End With
    End Sub

    Private Sub FrmPagoPasa_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmPagoPasa_ClickTabPage1() Handles Me.ClickTabPage1
        Me.MenuStrip1.Items(3).Visible = True
        Me.MenuStrip1.Items(4).Visible = False

    End Sub

    Private Sub FrmConsulFactuEmiti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.ShadowLabel1.Text = "Pagos de Pasajes..."
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = True
            Me.MenuStrip1.Items(3).Enabled = True
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False


            Me.MenuTab.Items(0).Text = "Realizar Pago"
            Me.MenuTab.Items(1).Text = "Consultas"



            'objgeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago, VOCONTROLUSUARIO)
            'dvlistar_forma_pago.RowFilter = "idforma_pago <> 2"
            'cbidforma_pago.DataSource = dvlistar_forma_pago
            'cbidforma_pago.DisplayMember = "FORMA_PAGO"
            'cbidforma_pago.ValueMember = "IDFORMA_PAGO"
            '
            ''Mod.17/09/2009 -->Omendoza - Pasando al datahelper   - No se considera el objeto VOCONTROLUSUARIO 
            'objgeneral.fnlistar_tipo_comprobante(dvlistar_forma_pago, Me.cbidtipo_comprobante, VOCONTROLUSUARIO)
            objgeneral.fnlistar_tipo_comprobante(dvlistar_forma_pago, Me.cbidtipo_comprobante)
            '
            dvlistar_forma_pago.RowFilter = "IDTIPO_COMPROBANTE = 1 or IDTIPO_COMPROBANTE = 2 or IDTIPO_COMPROBANTE = 3"

            'objgeneral.FNLISTAR_TIPO_MONEDA(dvlistar_tipo_moneda, Me.cbidtipo_comprobante, VOCONTROLUSUARIO)
            'Mod.21/09/2009 -->Omendoza - Pasando al datahelper   
            objgeneral.FN_cmb_Listar_agencias(Me.cmbAgencia)
            objgeneral.FN_cmb_l_TIPOS_PAGOS_CREDITOS(Me.cbIDTIPOS_PAGOS_CREDI)
            objgeneral.FN_cmb_l_TIPOS_PAGOS_CREDITOS(Me.cbIDTIPOS_PAGOS_CREDI1)

            ObjPersona.CODIGO_CLIENTE = "NULL"
            ObjPersona.IDTIPO_PERSONA = 0
            ObjPersona.IDPERSONA = 0



            'Mod.21/09/2009 -->Omendoza - Pasando al datahelper   
            'dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            '
            Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
            ObjProcesos.fnCargar_iWin_r(Me.txtidpersona, dvlistar_persona_todos, Colllistar_persona_todos, Iwinlistar_persona_todos, 0)



            'objgeneral.FN_L_UNIDAD_agencia_(VOCONTROLUSUARIO, Me.CBIDUNIDAD_AGENCIA)
            'objgeneral.FN_L_UNIDAD_agencia_(VOCONTROLUSUARIO, Me.CBIDUNIDAD_AGENCIA_DESTINO)

            'objgeneral.fn_L_TIPO_ENTREGA(dvidtipo_entrega, Me.cbidtipo_entrega, VOCONTROLUSUARIO)

            'Me.cbidforma_pago.SelectedIndex = -1
            Me.cbidtipo_comprobante.SelectedIndex = -1
            Me.cmbAgencia.SelectedIndex = -1
            Me.cbIDTIPOS_PAGOS_CREDI.SelectedIndex = -1
            Me.cbIDTIPOS_PAGOS_CREDI1.SelectedIndex = -1
            'Me.cmbUsuarios.SelectedIndex = -1
            'Me.CBIDUNIDAD_AGENCIA.SelectedIndex = -1
            'Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndex = -1
            'Me.cbidtipo_entrega.SelectedIndex = -1

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub cmbAgencia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAgencia.GotFocus

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
                    Dim ObjFactura As New ClsLbTepsa.dtoFACTURA

                    If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                        ObjFactura.IDPERSONA = 0
                    Else

                        ObjFactura.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                    End If
                    If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjFactura.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_INICIO = "NULL"
                    If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjFactura.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_FINAL = "NULL"
                    If Not IsNothing(Me.cbidtipo_comprobante.SelectedValue) Then
                        ObjFactura.IDTIPO_COMPROBANTE = Me.cbidtipo_comprobante.SelectedValue
                    Else
                        ObjFactura.IDTIPO_COMPROBANTE = 0
                    End If

                    ObjFactura.IDTIPO_MONEDA = 0

                    'If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
                    '    ObjFactura.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
                    'Else
                    '    ObjFactura.IDUSUARIO_PERSONAL = 0
                    'End If
                    If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                        ObjFactura.IDAGENCIAS = cmbAgencia.SelectedValue
                    Else
                        ObjFactura.IDAGENCIAS = 0
                    End If

                    'If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
                    '    ObjFactura.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
                    'Else
                    '    ObjFactura.IDFORMA_PAGO = 0
                    'End If
                    'If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
                    '    ObjFactura.IDUNIDAD_ORIGEN = Me.CBIDUNIDAD_AGENCIA.SelectedValue
                    'Else
                    '    ObjFactura.IDUNIDAD_ORIGEN = 0
                    'End If

                    'If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                    '    ObjFactura.IDUNIDAD_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
                    'Else
                    '    ObjFactura.IDUNIDAD_DESTINO = 0
                    'End If

                    ObjFactura.SERIE_FACTURA = Mid(Me.MTBNro_factura.Text, 1, 3)
                    ObjFactura.NRO_FACTURA = Mid(Me.MTBNro_factura.Text, 5, 7)

                    ObjFactura.SERIE_FACTURA = IIf(ObjFactura.SERIE_FACTURA.Trim = "", 0, ObjFactura.SERIE_FACTURA.Trim)
                    ObjFactura.NRO_FACTURA = IIf(ObjFactura.NRO_FACTURA.Trim = "", 0, ObjFactura.NRO_FACTURA.Trim)


                    'If Not IsNothing(Me.cbidtipo_entrega.SelectedValue) Then
                    '    ObjFactura.IDTIPO_ENTREGA = Me.cbidtipo_entrega.SelectedValue
                    'Else
                    '    ObjFactura.IDTIPO_ENTREGA = 0
                    'End If

                    'Dim P_ENTRE As String

                    'If Me.RBENTRE.Checked = True Then
                    '    P_ENTRE = 1
                    'ElseIf Me.RBSIN_ENTRE.Checked = True Then
                    '    P_ENTRE = 0
                    'Else
                    '    P_ENTRE = 2
                    'End If

                    With ObjFactura

                        .IDFACTURA = Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index)("IDFACTURA")


                        ObjReport.rutaRpt = PathFrmReport
                        ObjReport.conectar(rptservice, rptuser, rptpass)


                        'ObjReport.printrptB(False, "", "FAC010.RPT", _
                        '"p_idpersona;" & .IDPERSONA, _
                        '"p_idforma_pago;" & .IDFORMA_PAGO, _
                        '"p_idtipo_moneda;" & .IDTIPO_MONEDA, _
                        '"p_idagencias;" & .IDAGENCIAS, _
                        '"p_idusuario_personal;" & .IDUSUARIO_PERSONAL, _
                        '"p_idunidad_origen;" & .IDUNIDAD_ORIGEN, _
                        '"p_idunidad_destino;" & .IDUNIDAD_DESTINO, _
                        '"p_nro_factura;" & .NRO_FACTURA, _
                        '"p_idtipo_comprobante;" & .IDTIPO_COMPROBANTE, _
                        '"p_fecha_inicial;" & .FECHA_INICIO, _
                        '"p_fecha_final;" & .FECHA_FINAL, _
                        '"p_idtipo_entrega;" & .IDTIPO_ENTREGA, _
                        '"p_rango_fecha;" & "(Desde el " & .FECHA_INICIO & " hasta el " & .FECHA_FINAL & ")", _
                        '"p_entre;" & P_ENTRE)


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
        cbidtipo_comprobante.GotFocus



        Me.txttotal_costo.Text = 0
        DGV3.DataSource = Nothing
    End Sub

    Private Sub txtidpersona_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtidpersona.KeyUp
        If e.KeyCode = 13 Then
            If Not Iwinlistar_persona_todos.IndexOf(txtidpersona.Text) = -1 Then
                With ObjPersona
                    .IDPERSONA = Int(Colllistar_persona_todos.Item(Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                    .IDTIPO_PERSONA = 0
                    .CODIGO_CLIENTE = "NULL"
                    'Mod.21/09/2009 -->Omendoza - Pasando al datahelper   
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
    End Sub

    Private Sub txtidpersona_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtidpersona.LostFocus
        If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
            Me.txtidpersona.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub

    Private Sub txtidpersona_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtidpersona.TextChanged

    End Sub

    Private Sub txtCodigoCliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.GotFocus, MTBNro_factura.GotFocus
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
                    Exit Sub
                End If
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

        Me.txttotal_costo.Text = 0
        DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAINICIOFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            DTPFECHAFINALFACTURA.Focus()
        End If
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.ValueChanged

    End Sub

    Private Sub DTPFECHAFINALFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.GotFocus

        Me.txttotal_costo.Text = 0
        DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAFINALFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cbidtipo_comprobante.Focus()
        End If
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged

    End Sub

    Private Sub cbidtipo_moneda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbidtipo_comprobante.GotFocus

        Me.txttotal_costo.Text = 0
        DGV3.DataSource = Nothing
    End Sub

    'Private Sub cbidtipo_moneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidtipo_comprobante.KeyPress
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

    'Private Sub cbidforma_pago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar = Chr(13) Then
    '        Me.tbnro_factura.Focus()
    '    End If
    'End Sub

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

    End Sub
    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub cbidforma_pago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub tbnro_factura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

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

    'Private Sub CBIDUNIDAD_AGENCIA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar = Chr(13) Then
    '        Me.CBIDUNIDAD_AGENCIA_DESTINO.Focus()
    '    End If
    'End Sub

    Private Sub CBIDUNIDAD_AGENCIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub

    Private Sub DGV3_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV3.CellMouseUp
        Dim objfactura As New ClsLbTepsa.dtoFACTURA
        Try

            If e.Button = Windows.Forms.MouseButtons.Left Then

                Dim a As DataRowView = Me.dvListar_facturas.Item(Me.DGV3.CurrentRow.Index)

                If DGV3.CurrentCell.ColumnIndex <> 0 Then Exit Sub

                If Not dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("IDESTA_PAGO_PASA") = "PEND" Then
                    MsgBox("La factura ya esta cancelada", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
                    dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("SELECCIONAR") = 0
                    DGV3.RefreshEdit()
                    CALCULAR_TOTAL()
                    Exit Sub
                End If




                If a("SELECCIONAR") = 0 Then 'Ya esta Seleccionado
                    If a("SELECCIONAR") = 0 Then
                        dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("SELECCIONAR") = 1
                        DGV3.RefreshEdit()
                        CALCULAR_TOTAL()

                        Exit Sub
                    End If
                End If

                If a("SELECCIONAR") = 1 Then 'Ya esta Seleccionado
                    If a("SELECCIONAR") = 1 Then

                        dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("SELECCIONAR") = 0
                        DGV3.RefreshEdit()
                        CALCULAR_TOTAL()

                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub DGV3_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGV3.KeyUp
        Try



            If e.KeyCode = Keys.Space Then

                Dim a As DataRowView = Me.dvListar_facturas.Item(Me.DGV3.CurrentRow.Index)
                If DGV3.RowCount <= 0 Then Exit Sub

                If Not dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("IDESTA_PAGO_PASA") = "PEND" Then
                    MsgBox("La factura ya esta cancelada", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
                    dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("SELECCIONAR") = 0
                    DGV3.RefreshEdit()
                    CALCULAR_TOTAL()
                    Exit Sub
                End If

                If a("SELECCIONAR") = 0 Then
                    dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("SELECCIONAR") = 1
                    DGV3.RefreshEdit()
                    CALCULAR_TOTAL()

                    Exit Sub
                End If



                If a("SELECCIONAR") = 1 Then

                    dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("SELECCIONAR") = 0
                    DGV3.RefreshEdit()
                    CALCULAR_TOTAL()

                    Exit Sub
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub FrmPagoPasa_MenuGrabar() Handles Me.MenuGrabar
        Dim ObjValida As New ClsLbTepsa.dtoValida

        Dim HAY_SELECCIONADO As Boolean = False

        For i As Integer = 0 To dvListar_facturas.Count - 1

            If dvListar_facturas.Table.Rows(i)("SELECCIONAR") = 1 Then
                HAY_SELECCIONADO = True
            End If
        Next

        If HAY_SELECCIONADO = False Then
            MsgBox("No existe elemento seleccionado...", MsgBoxStyle.Critical, "Seguridad del Sistema...")
            Exit Sub
        End If

        If ObjValida.CB_SELECT_VALUE(Me.cbIDTIPOS_PAGOS_CREDI, Me) = False Then Exit Sub
        If ObjValida.NUMERO_NO_CERO(TBMONTO, Me) = False Then Exit Sub
        If ObjValida.NUMERO_NO_NEGATIVO(TBMONTO, Me) = False Then Exit Sub
        If ObjValida.NUMERO_NO_CERO(TBTipo_Cambi, Me) = False Then Exit Sub
        If ObjValida.NUMERO_NO_NEGATIVO(TBTipo_Cambi, Me) = False Then Exit Sub

        If CDbl(Me.txttotal_costo.Text) > CDbl(Me.TBMONTO.Text) Then
            MsgBox("El monto seleccionado es mayor que el ingresado...", MsgBoxStyle.Information, "Seguridad del Sistema...")
            Exit Sub
        End If

        Try
            Dim obj As New ClsLbTepsa.dtoPagos_pasajes
            With obj
                For i As Integer = 0 To dvListar_facturas.Count - 1

                    If dvListar_facturas.Table.Rows(i)("SELECCIONAR") = 1 Then
                        .IDVENTA_PASAJES_STRING = .IDVENTA_PASAJES_STRING + CStr(dvListar_facturas.Table.Rows(i)("IDVENTA_PASAJES")) + ";"
                    End If
                Next
                .IDPAGOS_PASAJES = 0
                .IDVENTA_PASAJES = 0
                .FECHA = Me.DTPFECHA.Value.ToShortDateString
                .MONTO = TBMONTO.Text
                .OPERACION = TBOPERACION.Text
                .TIPO_CAMBI = TBTipo_Cambi.Text
                .FECHA_REGISTRO = "NULL"
                .FECHA_ACTUALIZACION = "NULL"
                .IP = dtoUSUARIOS.m_sIP
                .IPMOD = "NULL"
                .IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                .IDROL = dtoUSUARIOS.IdRol
                .IDROL_MOD = 0
                .IDUSUARIO_PERSONAL_MOD = 0
                .IDTIPOS_PAGOS_CREDI = Me.cbIDTIPOS_PAGOS_CREDI.SelectedValue
                'Datahelper
                .SP_IN_PASA_CREDI()
            End With
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Seguridad del Sistema...")
        Finally
            MsgBox("Proceso completado con exito...", MsgBoxStyle.Information, "Seguridad del Sistema...")
        End Try
    End Sub

    Private Sub cbIDTIPOS_PAGOS_CREDI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbIDTIPOS_PAGOS_CREDI.SelectedIndexChanged

    End Sub

    Private Sub FrmPagoPasa_ClickTabPage2() Handles Me.ClickTabPage2
        Me.MenuStrip1.Items(3).Visible = False
        Me.MenuStrip1.Items(4).Visible = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub listar_pagos()
        Dim ObjPagos_pasajes As New ClsLbTepsa.dtoPagos_pasajes
        ObjPagos_pasajes.FECHA_INI = Me.DTPFECHA_INI1.Value.ToShortDateString
        ObjPagos_pasajes.FECHA_FINAL = Me.DTPFECHA_FINAL1.Value.ToShortDateString

        If Not IsNothing(Me.cbIDTIPOS_PAGOS_CREDI1.SelectedValue) Then
            ObjPagos_pasajes.IDTIPOS_PAGOS_CREDI = Me.cbIDTIPOS_PAGOS_CREDI1.SelectedValue
        Else
            ObjPagos_pasajes.IDTIPOS_PAGOS_CREDI = 0
        End If
        'Datahelper
        DV_L_PASA_CREDI_AMOR = ObjPagos_pasajes.SP_L_PASA_CREDI_AMOR()

        FORMAT_GRILLA4()
    End Sub
    Private Sub BtnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        listar_pagos()

    End Sub
    Private Sub FORMAT_GRILLA4()
        DGV4.Columns.Clear()

        With DGV4
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = DV_L_PASA_CREDI_AMOR
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim SELECCIONAR As New DataGridViewCheckBoxColumn
        With SELECCIONAR
            .HeaderText = "SELECCIONAR"
            .Name = "SELECCIONAR"
            .DataPropertyName = "SELECCIONAR"
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            '.FlatStyle = FlatStyle.Standard
            '.CellTemplate = New DataGridViewCheckBoxCell()
            '.CellTemplate.Style.BackColor = Color.Beige
            .Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
        Dim FECHA As New DataGridViewTextBoxColumn
        With FECHA
            .HeaderText = "FECHA"
            .Name = "FECHA"
            .DataPropertyName = "FECHA"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
        Dim TIPO_ENTREGA As New DataGridViewTextBoxColumn
        With TIPO_ENTREGA
            .HeaderText = "TIPO_ENTREGA"
            .Name = "TIPO_ENTREGA"
            .DataPropertyName = "TIPO_ENTREGA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim OPERACION As New DataGridViewTextBoxColumn
        With OPERACION
            .HeaderText = "OPERACION"
            .Name = "OPERACION"
            .DataPropertyName = "OPERACION"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim TIPOS_PAGOS_CREDI As New DataGridViewTextBoxColumn
        With TIPOS_PAGOS_CREDI
            .HeaderText = "TIPOS_PAGOS_CREDI"
            .Name = "TIPOS_PAGOS_CREDI"
            .DataPropertyName = "TIPOS_PAGOS_CREDI"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
        Dim NRO_COMPROBANTE As New DataGridViewTextBoxColumn
        With NRO_COMPROBANTE
            .HeaderText = "NRO_COMPROBANTE"
            .Name = "NRO_COMPROBANTE"
            .DataPropertyName = "NRO_COMPROBANTE"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
        Dim SERIE_COMPROBANTE As New DataGridViewTextBoxColumn
        With SERIE_COMPROBANTE
            .HeaderText = "SERIE_COMPROBANTE"
            .Name = "SERIE_COMPROBANTE"
            .DataPropertyName = "SERIE_COMPROBANTE"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
        Dim MONTO As New DataGridViewTextBoxColumn
        With MONTO
            .HeaderText = "MONTO"
            .Name = "MONTO"
            .DataPropertyName = "MONTO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim IDCABE_PAGOS_PASAJES As New DataGridViewTextBoxColumn
        With IDCABE_PAGOS_PASAJES
            .HeaderText = "IDCABE_PAGOS_PASAJES"
            .Name = "IDCABE_PAGOS_PASAJES"
            .DataPropertyName = "IDCABE_PAGOS_PASAJES"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
        End With
        Dim IDESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With IDESTADO_REGISTRO
            .HeaderText = "IDESTADO_REGISTRO"
            .Name = "IDESTADO_REGISTRO"
            .DataPropertyName = "IDESTADO_REGISTRO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
        End With

        With DGV4
            .Columns.AddRange(IDCABE_PAGOS_PASAJES, LOGIN, FECHA, MONTO, OPERACION, TIPOS_PAGOS_CREDI, ESTADO_REGISTRO, IDESTADO_REGISTRO)

        End With
    End Sub

    Private Sub DGV4_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV4.CellContentClick

    End Sub

    Private Sub DGV4_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV4.CellEnter
        Dim obj As New ClsLbTepsa.dtoPagos_pasajes
        With obj
            .IDCABE_PAGOS_PASAJES = DGV4.CurrentRow.Cells("IDCABE_PAGOS_PASAJES").Value
            'Datahelper
            DV_L_PASA_CREDI_AMOR_DETA = .SP_L_PASA_CREDI_AMOR_DETA()
            Call FORMAT_GRILLA5()
        End With
    End Sub
    Sub FORMAT_GRILLA5()
        DGV5.Columns.Clear()

        With DGV5
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = DV_L_PASA_CREDI_AMOR_DETA
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim SELECCIONAR As New DataGridViewCheckBoxColumn
        With SELECCIONAR
            .HeaderText = "SELECCIONAR"
            .Name = "SELECCIONAR"
            .DataPropertyName = "SELECCIONAR"
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            '.FlatStyle = FlatStyle.Standard
            '.CellTemplate = New DataGridViewCheckBoxCell()
            '.CellTemplate.Style.BackColor = Color.Beige
            .Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
        Dim FECHA_EMISION As New DataGridViewTextBoxColumn
        With FECHA_EMISION
            .HeaderText = "FECHA_EMISION"
            .Name = "FECHA_EMISION"
            .DataPropertyName = "FECHA_EMISION"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim ESTA_PAGO_PASA As New DataGridViewTextBoxColumn
        With ESTA_PAGO_PASA
            .HeaderText = "EST. PAG."
            .Name = "ESTA_PAGO_PASA"
            .DataPropertyName = "ESTA_PAGO_PASA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
        Dim NRO_COMPROBANTE As New DataGridViewTextBoxColumn
        With NRO_COMPROBANTE
            .HeaderText = "NRO_COMPROBANTE"
            .Name = "NRO_COMPROBANTE"
            .DataPropertyName = "NRO_COMPROBANTE"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
        Dim SERIE_COMPROBANTE As New DataGridViewTextBoxColumn
        With SERIE_COMPROBANTE
            .HeaderText = "SERIE_COMPROBANTE"
            .Name = "SERIE_COMPROBANTE"
            .DataPropertyName = "SERIE_COMPROBANTE"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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
        Dim MONTO_TOTAL As New DataGridViewTextBoxColumn
        With MONTO_TOTAL
            .HeaderText = "MONTO_TOTAL"
            .Name = "MONTO_TOTAL"
            .DataPropertyName = "MONTO_TOTAL"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
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

        With DGV5
            .Columns.AddRange(RAZON_SOCIAL, TIPO_COMPROBANTE, SERIE_COMPROBANTE, NRO_COMPROBANTE, FECHA_EMISION, MONTO_TOTAL, ESTADO_REGISTRO, ESTA_PAGO_PASA)

        End With
    End Sub

    Private Sub FrmPagoPasa_MenuEliminar() Handles Me.MenuEliminar
        If DGV4.CurrentRow.Cells("IDESTADO_REGISTRO").Value = 2 Then
            MsgBox("El registro ya esta ANULADO...", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
            Exit Sub
        End If
        Try
            Dim obj As New ClsLbTepsa.dtoPagos_pasajes
            With obj

                If MsgBox("Seguro que desea ANULAR este registro...?", MsgBoxStyle.YesNo, "Seguridad del Sistema") = MsgBoxResult.Yes Then
                    .IDCABE_PAGOS_PASAJES = DGV4.CurrentRow.Cells("IDCABE_PAGOS_PASAJES").Value
                    'Datahelper 
                    .SP_DELE_PASA_CREDI_AMOR_DETA()
                    '
                    listar_pagos()
                Else
                    Exit Sub
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        Finally
            MsgBox("Proceso terminado correctamente...", MsgBoxStyle.Information, "Seguridad del Sistema")

        End Try
    End Sub

    Private Sub FrmPagoPasa_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class
