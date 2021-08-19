Public Class frm_consultagral

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
    Dim dvListar_tipo_consulta As New DataView
    '
    Dim b_lee As Boolean = True


    Private ObjReport As ClsLbTepsa.dtoFrmReport '
    '
    Dim bIngreso As Boolean = False
    Public hnd As Long

    'Shared loginfo As CrystalDecisions.Shared.ConnectionInfo

    Private Sub frm_consultagral_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frm_consultagral_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frm_consultagral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.ShadowLabel1.Text = "Consulta General"
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False
            'Me.MenuStrip1.Items(6).Visible = False
            '
            'Mod.17/09/2009 -->Omendoza - Pasando al datahelper   - No se considera el objecto VOCONTROLUSUARIO
            'objgeneral.fnlistar_tipo_consulta(dvListar_tipo_consulta, Me.cmb_consulta_por, VOCONTROLUSUARIO)

            objgeneral.fnlistar_tipo_consulta(dvListar_tipo_consulta, Me.cmb_consulta_por)
            '
            'Mod.17/09/2009 -->Omendoza - Pasando al datahelper   
            'objgeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago, VOCONTROLUSUARIO)
            objgeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago)


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
            b_lee = False
            '
            objgeneral.FN_cmb_Listar_agencias(Me.cmbAgencia)
            objgeneral.FN_cmb_Listar_agencias(Me.cmb_agencia_destino)
            '
            ObjPersona.CODIGO_CLIENTE = "NULL"
            ObjPersona.IDTIPO_PERSONA = 0
            ObjPersona.IDPERSONA = 0
            '                        
            dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
            ObjProcesos.fnCargar_iWin_r(Me.txtidpersona, dvlistar_persona_todos, Colllistar_persona_todos, Iwinlistar_persona_todos, 0)
            '
            objgeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA)
            objgeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA_DESTINO)
            b_lee = True
            'Mod.18/09/2009 -->Omendoza - Pasando al datahelper   
            objgeneral.fn_L_TIPO_ENTREGA(dvidtipo_entrega, Me.cbidtipo_entrega)
            '
            Me.cbidforma_pago.SelectedIndex = -1
            Me.cbidtipo_comprobante.SelectedIndex = -1
            Me.cmbAgencia.SelectedIndex = -1
            Me.cmb_agencia_destino.SelectedIndex = -1
            Me.cmbUsuarios.SelectedIndex = -1
            Me.CBIDUNIDAD_AGENCIA.SelectedIndex = -1
            Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndex = -1
            Me.cbidtipo_entrega.SelectedIndex = -1
            '
            Me.txt_nro_registro.Text = "0"

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
            ' 12/08/2010 - Listado para generar el tipo de carga 
            'Adicionando el combo de la Carga Acompañada <-> 05/08/2010
            '
            'Me.Cmb_carga_acompanada.Items.Add(" -TODOS-")
            'Me.Cmb_carga_acompanada.Items.Add("NORMAL")
            'Me.Cmb_carga_acompanada.Items.Add("ACOMPAÑADA")
            'Me.Cmb_carga_acompanada.Items.Add("PYME")
            'Me.Cmb_carga_acompanada.SelectedIndex = 0
            '
            Dim obj As New dtoVentaCargaContado
            dt = New DataTable
            dt = obj.ListarProducto
            With Me.Cmb_carga_acompanada
                .DataSource = dt
                .ValueMember = "idprocesos"
                .DisplayMember = "procesos"
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Cursor = Cursors.AppStarting
        listar_facturas()
        Me.Cursor = Cursors.Default
    End Sub
    Sub FORMAT_GRILLA3()
        DGV3.Columns.Clear()

        If Me.cmb_consulta_por.SelectedValue = 5 Then
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

            Dim ORIGEN As New DataGridViewTextBoxColumn
            With ORIGEN
                .Name = "ORIGEN"
                .DataPropertyName = "ORIGEN"
                .HeaderText = "ORIGEN"
                '.Width = 4
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
            End With

            Dim DESTINO As New DataGridViewTextBoxColumn
            With DESTINO
                .Name = "DESTINO"
                .DataPropertyName = "DESTINO"
                .HeaderText = "DESTINO"
                '.Width = 4
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
            End With

            Dim AGENCIA_ORIGEN As New DataGridViewTextBoxColumn
            With AGENCIA_ORIGEN
                .Name = "AGENCIA_ORIGEN"
                .DataPropertyName = "AGENCIA_ORIGEN"
                .HeaderText = "AGENCIA ORIGEN"
                '.Width = 4
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
            End With

            Dim AGENCIA_DESTINO As New DataGridViewTextBoxColumn
            With AGENCIA_DESTINO
                .Name = "AGENCIA_DESTINO"
                .DataPropertyName = "AGENCIA_DESTINO"
                .HeaderText = "AGENCIA DESTINO"
                '.Width = 4
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
            End With

            Dim FECHA_FACTURA As New DataGridViewTextBoxColumn
            With FECHA_FACTURA
                .Name = "FECHA_FACTURA"
                .DataPropertyName = "FECHA_FACTURA"
                .HeaderText = "FECHA"
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
            End With

            Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
            With RAZON_SOCIAL
                .Name = "RAZON_SOCIAL"
                .DataPropertyName = "RAZON_SOCIAL"
                .HeaderText = "RAZON_SOCIAL"
                '.Width = 4
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
            End With

            Dim CODIGO As New DataGridViewTextBoxColumn
            With CODIGO
                .Name = "CODIGO"
                .DataPropertyName = "CODIGO"
                .HeaderText = "Nº DOC."
                .Width = 75
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
                .Visible = False
            End With

            Dim TIPO As New DataGridViewTextBoxColumn
            With TIPO
                .Name = "TIPO"
                .DataPropertyName = "TIPO"
                .HeaderText = "TIPO"
                '.Width = 50
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
            End With

            Dim DOCUMENTO As New DataGridViewTextBoxColumn
            With DOCUMENTO
                .Name = "DOCUMENTO"
                .DataPropertyName = "DOCUMENTO"
                .HeaderText = "DOCUMENTO"
                '.Width = 90
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
            End With

            Dim DIAS As New DataGridViewTextBoxColumn
            With DIAS
                .Name = "DIAS"
                .DataPropertyName = "DIAS"
                .HeaderText = "DIAS"
                .Width = 40
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
            End With

            Dim IDFACTURA As New DataGridViewTextBoxColumn
            With IDFACTURA
                .HeaderText = "Idfactura"
                .Name = "IDFACTURA"
                .DataPropertyName = "IDFACTURA"
                .Width = 50
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
                .ReadOnly = True
            End With

            Dim PESO As New DataGridViewTextBoxColumn
            With PESO
                .HeaderText = "PESO"
                .Name = "TOTAL_PESO"
                .DataPropertyName = "PESO"
                .Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
                .ReadOnly = True
            End With
            Dim VOLUMEN As New DataGridViewTextBoxColumn
            With VOLUMEN
                .HeaderText = "VOLUMEN"
                .Name = "TOTAL_VOLUMEN"
                .DataPropertyName = "VOLUMEN"
                .Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
                .ReadOnly = True
            End With

            Dim TOTAL_PESO As New DataGridViewTextBoxColumn
            With TOTAL_PESO
                .HeaderText = "TOTAL PESO"
                .Name = "PESO"
                .DataPropertyName = "TOTAL_PESO"
                .Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
                .ReadOnly = True
            End With

            Dim CANTIDAD_PESO As New DataGridViewTextBoxColumn
            With CANTIDAD_PESO
                .HeaderText = "CANTIDAD PESO"
                .Name = "CANTIDAD"
                .DataPropertyName = "CANTIDAD_PESO"
                .Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.DefaultCellStyle.Format = "N2"
                '.DefaultCellStyle.NullValue = "0,00"
                .ReadOnly = True
                .Visible = False
            End With
            Dim CANTIDAD_VOLUMEN As New DataGridViewTextBoxColumn
            With CANTIDAD_VOLUMEN
                .HeaderText = "CANTIDAD VOLUMEN"
                .Name = "CANTIDAD"
                .DataPropertyName = "CANTIDAD_VOLUMEN"
                .Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.DefaultCellStyle.Format = "N2"
                '.DefaultCellStyle.NullValue = "0,00"
                .ReadOnly = True
                .Visible = False
            End With
            Dim CANTIDAD_SOBRE As New DataGridViewTextBoxColumn
            With CANTIDAD_SOBRE
                .HeaderText = "CANTIDAD SOBRE"
                .Name = "CANTIDAD"
                .DataPropertyName = "CANTIDAD_SOBRE"
                .Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.DefaultCellStyle.Format = "N2"
                '.DefaultCellStyle.NullValue = "0,00"
                .ReadOnly = True
                .Visible = False
            End With
            Dim CANTIDAD As New DataGridViewTextBoxColumn
            With CANTIDAD
                .HeaderText = "TOTAL BULTOS"
                .Name = "CANTIDAD"
                .DataPropertyName = "CANTIDAD"
                .Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.DefaultCellStyle.Format = "N2"
                '.DefaultCellStyle.NullValue = "0,00"
                .ReadOnly = True
            End With

            Dim PARCIAL As New DataGridViewTextBoxColumn
            With PARCIAL
                .HeaderText = "¿PARCIAL?"
                .Name = "PARCIAL"
                .DataPropertyName = "PARCIAL"
                '.Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
            End With

            With DGV3
                'RAZON_SOCIAL, TIPO_COMPROBANTE, SERIE_FACTURA, NRO_FACTURA, FORMA_PAGO, FECHA_REGISTRO, FECHA_FACTURA, FECHA_SALIDA, FECHA_LLEGADA, FECHA_ENTREGA, FECHA_ACTUALIZACION, DIFERENCIA_DIAS, LOGIN, ESTADO_REGISTRO, ESTADO_REGISTRO_ENVIO, NOMBRE_AGENCIA, Nombre_Unidad_ORI, Nombre_Unidad_DESTI, TIPO_ENTREGA, cantidad_total, peso_total
                .Columns.AddRange(DIAS, FECHA_FACTURA, TIPO, DOCUMENTO, CODIGO, RAZON_SOCIAL, ORIGEN, DESTINO, AGENCIA_ORIGEN, AGENCIA_DESTINO, CANTIDAD_PESO, CANTIDAD_VOLUMEN, CANTIDAD_SOBRE, CANTIDAD, PESO, VOLUMEN, TOTAL_PESO, PARCIAL)
            End With
        Else
            With DGV3
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = True
                .AllowUserToResizeRows = True
                '.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCel
                .AutoGenerateColumns = False
                .DataSource = dvListar_facturas
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .VirtualMode = True
                .RowHeadersVisible = True
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            '
            Dim ANIO_FACTURA As New DataGridViewTextBoxColumn
            With ANIO_FACTURA
                .Name = "ANIO_FACTURA"
                .DataPropertyName = "ANIO_FACTURA"
                .HeaderText = "Año Factura"
                .Width = 4
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
            End With
            Dim CODIGO_CLIENTE As New DataGridViewTextBoxColumn
            With CODIGO_CLIENTE
                .Name = "CODIGO_CLIENTE"
                .DataPropertyName = "CODIGO_CLIENTE"
                .HeaderText = "Código Cliente"
                .Width = 20
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
            End With
            Dim DESTINATARIO As New DataGridViewTextBoxColumn
            With DESTINATARIO
                .Name = "DESTINATARIO"
                .DataPropertyName = "DESTINATARIO"
                .HeaderText = "Destinatario"
                .Width = 182
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
            End With
            Dim DESTINO As New DataGridViewTextBoxColumn
            With DESTINO

                .Name = "DESTINO"
                .DataPropertyName = "DESTINO"
                .HeaderText = "Destino"
                .ReadOnly = True
            End With
            Dim DIA_FACTURA As New DataGridViewTextBoxColumn
            With DIA_FACTURA
                .Name = "DIA_FACTURA"
                .DataPropertyName = "DIA_FACTURA"
                .HeaderText = "Día Factura"
                '.Width = 2
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
            End With
            Dim DIRECCION_PERSONA As New DataGridViewTextBoxColumn
            With DIRECCION_PERSONA
                .Name = "DIRECCION_PERSONA"
                .DataPropertyName = "DIRECCION_PERSONA"
                .HeaderText = "Dirección Persona"
                .ReadOnly = True
            End With
            Dim DIREC_DESTI As New DataGridViewTextBoxColumn
            With DIREC_DESTI
                .Name = "DIREC_DESTI"
                .DataPropertyName = "DIREC_DESTI"
                .HeaderText = "Dirección Destino"
                .Width = 200
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
            End With
            Dim DIREC_REMI As New DataGridViewTextBoxColumn
            With DIREC_REMI

                .Name = "DIREC_REMI"
                .DataPropertyName = "DIREC_REMI"
                .HeaderText = "Dirección Remitente"
                .Width = 200
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
            End With
            Dim DSCTO As New DataGridViewTextBoxColumn
            With DSCTO
                .HeaderText = "Dscto"
                .Name = "DSCTO"
                .DataPropertyName = "DSCTO"

                .ReadOnly = True
            End With
            Dim FECHA_FACTURA As New DataGridViewTextBoxColumn
            With FECHA_FACTURA
                .HeaderText = "Fecha Factura"
                .Name = "FECHA_FACTURA"
                .DataPropertyName = "FECHA_FACTURA"
                .Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
            End With
            Dim FECHA_REGISTRO As New DataGridViewTextBoxColumn
            With FECHA_REGISTRO
                .HeaderText = "Fecha Registro"
                .Name = "FECHA_REGISTRO"
                .DataPropertyName = "FECHA_REGISTRO"
                '.Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
            End With
            Dim FECHA_SALIDA As New DataGridViewTextBoxColumn
            With FECHA_SALIDA
                .HeaderText = "Fecha Salida"
                .Name = "FECHA_SALIDA"
                .DataPropertyName = "FECHA_SALIDA"
                .Width = 160
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
            End With
            Dim FECHA_LLEGADA As New DataGridViewTextBoxColumn
            With FECHA_LLEGADA
                .HeaderText = "Fecha Llegada"
                .Name = "FECHA_LLEGADA"
                .DataPropertyName = "FECHA_LLEGADA"
                .Width = 160
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
            End With

            Dim FECHA_ENTREGA As New DataGridViewTextBoxColumn
            With FECHA_ENTREGA
                .HeaderText = "Fecha Entega "
                .Name = "FECHA_ENTREGA"
                .DataPropertyName = "FECHA_ENTREGA"
                .Width = 160
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
            End With

            Dim FECHA_ACTUALIZACION As New DataGridViewTextBoxColumn
            With FECHA_ACTUALIZACION
                .HeaderText = "Fecha Actualiza"
                .Name = "FECHA_ACTUALIZACION"
                .DataPropertyName = "FECHA_ACTUALIZACION"
                .Width = 160
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
            End With
            Dim TIPO_ENTREGA As New DataGridViewTextBoxColumn
            With TIPO_ENTREGA
                .HeaderText = "Tipo Enmtrega"
                .Name = "TIPO_ENTREGA"
                .DataPropertyName = "TIPO_ENTREGA"
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
            End With
            Dim TIPO_COMPROBANTE As New DataGridViewTextBoxColumn
            With TIPO_COMPROBANTE
                .HeaderText = "Tipo Comprobante"
                .Name = "TIPO_COMPROBANTE"
                .DataPropertyName = "TIPO_COMPROBANTE"
                '.Width = 40
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
            End With
            Dim ESTADO_REGISTRO_ENVIO As New DataGridViewTextBoxColumn
            With ESTADO_REGISTRO_ENVIO
                .HeaderText = "Estado Envío"
                .Name = "ESTADO_REGISTRO_ENVIO"
                .DataPropertyName = "ESTADO_REGISTRO_ENVIO"
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
            End With
            Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
            With ESTADO_REGISTRO
                .HeaderText = "Estado Registro"
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
                .HeaderText = "Agencia"
                .Name = "NOMBRE_AGENCIA"
                .DataPropertyName = "NOMBRE_AGENCIA"
                '.Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
            End With
            Dim FORMA_PAGO As New DataGridViewTextBoxColumn
            With FORMA_PAGO
                .HeaderText = "Forma Pago"
                .Name = "FORMA_PAGO"
                .DataPropertyName = "FORMA_PAGO"
                '.Width = 50
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
            End With
            Dim IDAGENCIAS As New DataGridViewTextBoxColumn
            With IDAGENCIAS
                .HeaderText = "Idagencias"
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
                .HeaderText = "Idfactura"
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
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                '.DefaultCellStyle.Format = "N0"
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
                .HeaderText = "Nº Documento"
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
                .HeaderText = "Razón Social"
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
                .HeaderText = "Sub Total"
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
                .HeaderText = "Usuario"
                .Name = "LOGIN"
                .DataPropertyName = "LOGIN"
                '.Width = 50
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
            End With

            Dim CONFIRMACION_USUARIO As New DataGridViewTextBoxColumn
            With CONFIRMACION_USUARIO
                .HeaderText = "Confirmacion_Usuario"
                .Name = "idusuario_entrega"
                .DataPropertyName = "idusuario_entrega"
                '.Width = 50
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
            End With

            Dim ANAQUELEADO As New DataGridViewTextBoxColumn
            With ANAQUELEADO
                .HeaderText = "Anaqueleado"
                .Name = "Anaqueleado"
                .DataPropertyName = "Anaqueleado"
                '.Width = 50
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
            End With

            Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
            With TOTAL_COSTO
                .HeaderText = "Total Costo"
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
                .HeaderText = "Nº Prefactura"
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
                .HeaderText = "% Dscto."
                .Name = "Porcent_Descuento"
                .DataPropertyName = "Porcent_Descuento"
                .Width = 50
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
                .ReadOnly = True
            End With
            '
            Dim cantidad_total As New DataGridViewTextBoxColumn
            With cantidad_total
                .HeaderText = "Tot. Bultos"
                .Name = "cantidad_total"
                .DataPropertyName = "cantidad_total"
                .Width = 50
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0"
                .ReadOnly = True
            End With
            Dim peso_total As New DataGridViewTextBoxColumn
            With peso_total
                .HeaderText = "Peso Total"
                .Name = "peso_total"
                .DataPropertyName = "peso_total"
                .Width = 50
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
                .ReadOnly = True
            End With
            '13/08/2010 
            Dim tipo_venta As New DataGridViewTextBoxColumn
            With tipo_venta
                .HeaderText = "Tipo Venta"
                .Name = "tipo_venta"
                .DataPropertyName = "tipo_venta"
                .Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
            End With

            Dim fecha_reparto As New DataGridViewTextBoxColumn
            With fecha_reparto
                .HeaderText = "Fecha Reparto"
                .Name = "fecha_reparto"
                .DataPropertyName = "fecha_reparto"
                '.Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .ReadOnly = True
                '.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            End With

            Dim cargo As New DataGridViewTextBoxColumn
            With cargo
                .HeaderText = "Cargo"
                .Name = "cargo"
                .DataPropertyName = "cargo"
                '.Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .ReadOnly = True
                '.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            End With

            Dim dt As New DataGridViewTextBoxColumn
            With dt
                .HeaderText = "DT"
                .Name = "dt"
                .DataPropertyName = "dt"
                '.Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .ReadOnly = True
                '.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            End With

            Dim fecha_recojo As New DataGridViewTextBoxColumn
            With fecha_recojo
                .HeaderText = "Fecha Recojo"
                .Name = "fecha_recojo"
                .DataPropertyName = "fecha_recojo"
                '.Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .ReadOnly = True
                '.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            End With

            With DGV3
                '.Columns.AddRange( RAZON_SOCIAL, TIPO_COMPROBANTE, SERIE_FACTURA, NRO_FACTURA, FORMA_PAGO, FECHA_REGISTRO, FECHA_FACTURA, FECHA_SALIDA, FECHA_LLEGADA, FECHA_ENTREGA, FECHA_ACTUALIZACION, DIFERENCIA_DIAS, LOGIN, ESTADO_REGISTRO, ESTADO_REGISTRO_ENVIO, NOMBRE_AGENCIA, Nombre_Unidad_ORI, Nombre_Unidad_DESTI, TIPO_ENTREGA, cantidad_total, peso_total)
                .Columns.AddRange(tipo_venta, RAZON_SOCIAL, TIPO_COMPROBANTE, SERIE_FACTURA, NRO_FACTURA, FORMA_PAGO, FECHA_REGISTRO, FECHA_FACTURA, FECHA_SALIDA, FECHA_LLEGADA, FECHA_ENTREGA, FECHA_ACTUALIZACION, DIFERENCIA_DIAS, LOGIN, CONFIRMACION_USUARIO, ANAQUELEADO, ESTADO_REGISTRO, ESTADO_REGISTRO_ENVIO, NOMBRE_AGENCIA, Nombre_Unidad_ORI, Nombre_Unidad_DESTI, TIPO_ENTREGA, cantidad_total, peso_total, fecha_reparto, cargo, dt, fecha_recojo)
            End With
        End If
    End Sub


    Private Sub cmbAgencia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAgencia.GotFocus

        DGV3.DataSource = Nothing
    End Sub

    Private Sub cmbAgencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbAgencia.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cmbUsuarios.Focus()
        End If
    End Sub
    Private Sub cmbAgencia_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectionChangeCommitted
        Dim p_id_rol_usuario, p_idagencia As Int64
        p_id_rol_usuario = 0
        If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
            p_idagencia = CType(Me.cmbAgencia.SelectedValue, Int64)
            'datahelper
            objgeneral.FN_cmb_LISTAR_USUARIOS_AGENCIAS(Me.cmbUsuarios, p_id_rol_usuario, p_idagencia)
        Else
            cmbUsuarios.DataSource = Nothing
        End If
        Me.cmbUsuarios.SelectedIndex = -1
    End Sub
    'Public Shared Sub conectar(ByVal servidor As String, ByVal usuario As String, ByVal password As String)
    '    loginfo = New CrystalDecisions.Shared.ConnectionInfo
    '    loginfo.ServerName = servidor
    '    'loginfo.DatabaseName = servidor
    '    loginfo.IntegratedSecurity = False
    '    loginfo.UserID = usuario
    '    loginfo.Password = password
    'End Sub

    Private Sub frm_consultagral_MenuImprimir() Handles Me.MenuImprimir
        Try
            ObjReport.Dispose()
        Catch
        End Try
        ObjReport = New ClsLbTepsa.dtoFrmReport
        Select Case Me.TabMante.SelectedIndex
            Case 0
                Try
                    If Me.DGV3.RowCount <= 0 Then
                        MsgBox("No existen registros", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
                        Exit Sub
                    End If

                    If Me.cmb_consulta_por.SelectedValue <> 5 Then
                        Dim ObjconsultaGeneral As New ClsLbTepsa.dtoFACTURA

                        If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                            ObjconsultaGeneral.IDPERSONA = 0
                        Else

                            ObjconsultaGeneral.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                        End If
                        If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjconsultaGeneral.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjconsultaGeneral.FECHA_INICIO = "NULL"
                        If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjconsultaGeneral.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjconsultaGeneral.FECHA_FINAL = "NULL"
                        If Not IsNothing(Me.cbidtipo_comprobante.SelectedValue) Then
                            ObjconsultaGeneral.IDTIPO_COMPROBANTE = Me.cbidtipo_comprobante.SelectedValue
                        Else
                            ObjconsultaGeneral.IDTIPO_COMPROBANTE = 0
                        End If

                        ObjconsultaGeneral.IDTIPO_MONEDA = 0

                        If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
                            ObjconsultaGeneral.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
                        Else
                            ObjconsultaGeneral.IDUSUARIO_PERSONAL = 0
                        End If
                        If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                            ObjconsultaGeneral.IDAGENCIAS = cmbAgencia.SelectedValue
                        Else
                            ObjconsultaGeneral.IDAGENCIAS = 0
                        End If

                        If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
                            ObjconsultaGeneral.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
                        Else
                            ObjconsultaGeneral.IDFORMA_PAGO = 0
                        End If
                        If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
                            ObjconsultaGeneral.IDUNIDAD_ORIGEN = Me.CBIDUNIDAD_AGENCIA.SelectedValue
                        Else
                            ObjconsultaGeneral.IDUNIDAD_ORIGEN = 0
                        End If

                        If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                            ObjconsultaGeneral.IDUNIDAD_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
                        Else
                            ObjconsultaGeneral.IDUNIDAD_DESTINO = 0
                        End If

                        If Len(Me.tbnro_factura.Text.Trim) = 0 Then
                            ObjconsultaGeneral.NRO_FACTURA = 0
                        Else
                            ObjconsultaGeneral.NRO_FACTURA = Me.tbnro_factura.Text.Trim
                        End If

                        If Not IsNothing(Me.cbidtipo_entrega.SelectedValue) Then
                            ObjconsultaGeneral.IDTIPO_ENTREGA = Me.cbidtipo_entrega.SelectedValue
                        Else
                            ObjconsultaGeneral.IDTIPO_ENTREGA = 0
                        End If
                        Dim P_ENTRE As String
                        P_ENTRE = 0

                        'ObjconsultaGeneral. = Me.cmb_consulta_por.SelectedValue
                        '
                        If Not IsNothing(Me.cmb_agencia_destino.SelectedValue) Then
                            ObjconsultaGeneral.IDAGENCIAS_DESTINO = Me.cmb_agencia_destino.SelectedValue
                        Else
                            ObjconsultaGeneral.IDAGENCIAS_DESTINO = 0
                        End If
                        '13/08/2010 - 
                        '
                        'mycarga_acompanada
                        '05/08/2010 - Se adiciona la venta carga acompañada loco
                        'If Cmb_carga_acompanada.SelectedIndex = 0 Then   ' Todos 
                        '    ObjconsultaGeneral.carga_acompanada = "2"
                        'ElseIf Cmb_carga_acompanada.SelectedIndex = 1 Then '
                        '    ObjconsultaGeneral.carga_acompanada = "0"   'Venta Normal 
                        'ElseIf Cmb_carga_acompanada.SelectedIndex = 2 Then '
                        '    ObjconsultaGeneral.carga_acompanada = "1"   'Venta Carga Acompañada  
                        'Else
                        '    ObjconsultaGeneral.carga_acompanada = "3"   'Venta Carga Acompañada  
                        'End If
                        '13/07/2011
                        If Cmb_carga_acompanada.SelectedValue = 0 And Cmb_carga_acompanada.SelectedIndex = 0 Then   ' Todos 
                            ObjconsultaGeneral.carga_acompanada = "2"
                        ElseIf Cmb_carga_acompanada.SelectedValue = 0 Then '
                            ObjconsultaGeneral.carga_acompanada = "0"   'Venta Normal 
                        ElseIf Cmb_carga_acompanada.SelectedValue = 6 Then '
                            ObjconsultaGeneral.carga_acompanada = "1"   'Venta Carga Acompañada  
                        ElseIf Cmb_carga_acompanada.SelectedValue = 7 Then '
                            ObjconsultaGeneral.carga_acompanada = "3"   'Pyme
                        ElseIf Cmb_carga_acompanada.SelectedValue = 8 Then
                            ObjconsultaGeneral.carga_acompanada = "4"
                        End If

                        With ObjconsultaGeneral
                            .IDFACTURA = Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index)("IDFACTURA")
                            ObjReport.rutaRpt = PathFrmReport
                            ObjReport.conectar(rptservice, rptuser, rptpass)
                            ObjReport.printrptB(False, "", "FAC024-1.RPT", _
                            "p_rango_fecha;" & "(Desde el " & .FECHA_INICIO & " hasta el " & .FECHA_FINAL & ")", _
                            "P_AGENCIA_VENTA;" & .agencia_venta, _
                            "p_idpersona;" & .IDPERSONA, _
                            "p_idforma_pago;" & .IDFORMA_PAGO, _
                            "p_idtipo_moneda;" & .IDTIPO_MONEDA, _
                            "p_idagencias;" & .IDAGENCIAS, _
                            "p_idusuario_personal;" & .IDUSUARIO_PERSONAL, _
                            "p_fecha_inicial;" & .FECHA_INICIO, _
                            "p_fecha_final;" & .FECHA_FINAL, _
                            "p_nro_factura;" & .NRO_FACTURA, _
                            "p_idunidad_origen;" & .IDUNIDAD_ORIGEN, _
                            "p_idunidad_destino;" & .IDUNIDAD_DESTINO, _
                            "p_idtipo_comprobante;" & .IDTIPO_COMPROBANTE, _
                            "p_idtipo_entrega;" & .IDTIPO_ENTREGA, _
                            "p_entre;" & P_ENTRE, _
                            "ni_carga_acompanada;" & .carga_acompanada)
                            '"p_tipo_consulta;" & Me.cmb_consulta_por.SelectedValue, _
                            '"p_idagencia_destino;" & .IDAGENCIAS_DESTINO, _

                        End With
                    Else     'carga sin despachar
                        Dim ObjconsultaGeneral As New ClsLbTepsa.dtoConsulta_general
                        '
                        If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                            ObjconsultaGeneral.IDPERSONA = 0
                        Else
                            ObjconsultaGeneral.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                        End If
                        If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjconsultaGeneral.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjconsultaGeneral.FECHA_INICIO = "NULL"
                        If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjconsultaGeneral.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjconsultaGeneral.FECHA_FINAL = "NULL"
                        If Not IsNothing(Me.cbidtipo_comprobante.SelectedValue) Then
                            ObjconsultaGeneral.IDTIPO_COMPROBANTE = Me.cbidtipo_comprobante.SelectedValue
                        Else
                            ObjconsultaGeneral.IDTIPO_COMPROBANTE = 0
                        End If
                        ObjconsultaGeneral.IDTIPO_MONEDA = 0
                        If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
                            ObjconsultaGeneral.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
                        Else
                            ObjconsultaGeneral.IDUSUARIO_PERSONAL = 0
                        End If

                        If Len(Me.tbnro_factura.Text.Trim) = 0 Then
                            ObjconsultaGeneral.NRO_FACTURA = 0
                        Else
                            ObjconsultaGeneral.NRO_FACTURA = Me.tbnro_factura.Text.Trim
                        End If
                        If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                            ObjconsultaGeneral.IDAGENCIAS = Me.cmbAgencia.SelectedValue
                        Else
                            ObjconsultaGeneral.IDAGENCIAS = 0
                        End If

                        If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
                            ObjconsultaGeneral.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
                        Else
                            ObjconsultaGeneral.IDFORMA_PAGO = 0
                        End If
                        If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
                            ObjconsultaGeneral.IDUNIDAD_ORIGEN = Me.CBIDUNIDAD_AGENCIA.SelectedValue
                        Else
                            ObjconsultaGeneral.IDUNIDAD_ORIGEN = 0
                        End If

                        If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                            ObjconsultaGeneral.IDUNIDAD_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
                        Else
                            ObjconsultaGeneral.IDUNIDAD_DESTINO = 0
                        End If

                        If Not IsNothing(Me.cbidtipo_entrega.SelectedValue) Then
                            ObjconsultaGeneral.IDTIPO_ENTREGA = Me.cbidtipo_entrega.SelectedValue
                        Else
                            ObjconsultaGeneral.IDTIPO_ENTREGA = 0
                        End If
                        '
                        Dim P_ENTRE As String = 0
                        '
                        ObjconsultaGeneral.tipo_consulta = Me.cmb_consulta_por.SelectedValue
                        '
                        If Not IsNothing(Me.cmb_agencia_destino.SelectedValue) Then
                            ObjconsultaGeneral.IDAGENCIAS_DESTINO = Me.cmb_agencia_destino.SelectedValue
                        Else
                            ObjconsultaGeneral.IDAGENCIAS_DESTINO = 0
                        End If

                        ObjconsultaGeneral.tipo_consulta = Me.cmb_consulta_por.SelectedValue

                        With ObjconsultaGeneral
                            ObjReport.rutaRpt = PathFrmReport
                            ObjReport.conectar(rptservice, rptuser, rptpass)
                            ObjReport.printrptB(False, "", "FAC050-1.RPT", _
                            "p_rango_fecha;" & "(Desde el " & .FECHA_INICIO & " hasta el " & .FECHA_FINAL & ")", _
                            "P_AGENCIA_VENTA;" & .agencia_venta, _
                            "p_idpersona;" & .IDPERSONA, _
                            "p_idforma_pago;" & .IDFORMA_PAGO, _
                            "p_idtipo_moneda;" & .IDTIPO_MONEDA, _
                            "p_idagencias;" & .IDAGENCIAS, _
                            "p_idusuario_personal;" & .IDUSUARIO_PERSONAL, _
                            "p_fecha_inicial;" & .FECHA_INICIO, _
                            "p_fecha_final;" & .FECHA_FINAL, _
                            "p_nro_factura;" & .NRO_FACTURA, _
                            "p_idunidad_origen;" & .IDUNIDAD_ORIGEN, _
                            "p_idunidad_destino;" & .IDUNIDAD_DESTINO, _
                            "p_idtipo_comprobante;" & .IDTIPO_COMPROBANTE, _
                            "p_idtipo_entrega;" & .IDTIPO_ENTREGA, _
                            "p_entre;" & P_ENTRE, _
                            "p_tipo_consulta;" & .tipo_consulta, _
                            "p_idagencia_destino;" & .IDAGENCIAS_DESTINO)
                        End With

                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
                End Try
        End Select
    End Sub

    Private Sub frm_consultagral_MenuSalir() Handles Me.MenuSalir
        Close()
    End Sub

    Private Sub txtidpersona_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtidpersona.GotFocus, _
    DTPFECHAINICIOFACTURA.GotFocus, _
    DTPFECHAFINALFACTURA.GotFocus, _
        cbidtipo_comprobante.GotFocus, _
        cbidforma_pago.GotFocus, _
        tbnro_factura.GotFocus, _
        cmbAgencia.GotFocus, _
        cmbUsuarios.GotFocus, _
        CBIDUNIDAD_AGENCIA.GotFocus, _
        CBIDUNIDAD_AGENCIA_DESTINO.GotFocus, _
        cbidtipo_entrega.GotFocus
        DGV3.DataSource = Nothing
    End Sub
    Private Sub txtidpersona_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtidpersona.KeyUp
        If e.KeyCode = 13 Then
            If Not Iwinlistar_persona_todos.IndexOf(txtidpersona.Text) = -1 Then
                With ObjPersona
                    .IDPERSONA = Int(Colllistar_persona_todos.Item(Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                    .IDTIPO_PERSONA = 0
                    .CODIGO_CLIENTE = "NULL"
                    'Datahelper
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
        Me.DGV3.DataSource = Nothing
    End Sub
    Private Sub txtCodigoCliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.GotFocus, tbnro_factura.GotFocus
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
                'Datahelper
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
    Private Sub tbnro_factura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbnro_factura.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cmbAgencia.Focus()
        End If
    End Sub
    Private Sub txtCodigoCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.LostFocus, tbnro_factura.LostFocus
        If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
            Me.txtidpersona.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub
    Private Sub DTPFECHAINICIOFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.GotFocus

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
        DGV3.DataSource = Nothing
    End Sub
    Private Sub DTPFECHAFINALFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAFINALFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cbidtipo_comprobante.Focus()
        End If
    End Sub
    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged
        Me.DGV3.DataSource = Nothing
    End Sub
    Private Sub cbidtipo_moneda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbidtipo_comprobante.GotFocus
        DGV3.DataSource = Nothing
    End Sub
    Private Sub cbidtipo_moneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidtipo_comprobante.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cbidforma_pago.Focus()
        End If
    End Sub
    Private Sub cbidforma_pago_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbidforma_pago.GotFocus
        DGV3.DataSource = Nothing
    End Sub
    Private Sub cbidforma_pago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidforma_pago.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.tbnro_factura.Focus()
        End If
    End Sub
    Private Sub cmbUsuarios_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUsuarios.GotFocus
        DGV3.DataSource = Nothing
    End Sub
    Private Sub cmbUsuarios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbUsuarios.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.CBIDUNIDAD_AGENCIA.Focus()
        End If
    End Sub
    Private Sub cmbAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub
    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
    End Sub
    Private Sub cbidforma_pago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbidforma_pago.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub
    Private Sub tbnro_factura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbnro_factura.TextChanged
        Me.DGV3.DataSource = Nothing
    End Sub
    Private Sub cmbUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUsuarios.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub
    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.Button3.Focus()
        End If
    End Sub
    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndexChanged
        Dim ll_idunidad_agencia As Long
        Try
            Me.DGV3.DataSource = Nothing
            If b_lee = True Then
                If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                    ll_idunidad_agencia = CType(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue, Long)
                    'Datahelper
                    objgeneral.SP_cmb_LIST_AGENCIAS_UNIDAD(Me.cmb_agencia_destino, ll_idunidad_agencia)
                    cmbUsuarios.DataSource = Nothing
                Else
                    Me.cmbAgencia.DataSource = Nothing
                    cmbUsuarios.DataSource = Nothing
                End If
                Me.cmbAgencia.SelectedIndex = -1
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub CBIDUNIDAD_AGENCIA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBIDUNIDAD_AGENCIA.KeyPress, cbidtipo_entrega.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.CBIDUNIDAD_AGENCIA_DESTINO.Focus()
        End If
    End Sub
    Private Sub CBIDUNIDAD_AGENCIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA.SelectedIndexChanged, cbidtipo_entrega.SelectedIndexChanged
        Dim ll_idunidad_agencia As Long
        Try
            Me.DGV3.DataSource = Nothing
            If b_lee = True Then
                If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
                    ll_idunidad_agencia = CType(Me.CBIDUNIDAD_AGENCIA.SelectedValue, Long)
                    'Datahelper
                    objgeneral.SP_cmb_LIST_AGENCIAS_UNIDAD(Me.cmbAgencia, ll_idunidad_agencia)
                    cmbUsuarios.DataSource = Nothing
                Else
                    Me.cmbAgencia.DataSource = Nothing
                    cmbUsuarios.DataSource = Nothing
                End If
                Me.cmbAgencia.SelectedIndex = -1
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            'ObjReport.Dispose()
        Catch
        End Try
    End Sub

    Private Sub listar_facturas()
        Try
            Dim ObjconsultaGeneral As New ClsLbTepsa.dtoConsulta_general
            '
            If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                ObjconsultaGeneral.IDPERSONA = 0
            Else
                ObjconsultaGeneral.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
            End If
            If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjconsultaGeneral.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjconsultaGeneral.FECHA_INICIO = "NULL"
            If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjconsultaGeneral.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjconsultaGeneral.FECHA_FINAL = "NULL"
            If Not IsNothing(Me.cbidtipo_comprobante.SelectedValue) Then
                ObjconsultaGeneral.IDTIPO_COMPROBANTE = Me.cbidtipo_comprobante.SelectedValue
            Else
                ObjconsultaGeneral.IDTIPO_COMPROBANTE = 0
            End If
            ObjconsultaGeneral.IDTIPO_MONEDA = 0
            If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
                ObjconsultaGeneral.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
            Else
                ObjconsultaGeneral.IDUSUARIO_PERSONAL = 0
            End If

            If Len(Me.tbnro_factura.Text.Trim) = 0 Then
                ObjconsultaGeneral.NRO_FACTURA = 0
            Else
                ObjconsultaGeneral.NRO_FACTURA = Me.tbnro_factura.Text.Trim
            End If
            If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                ObjconsultaGeneral.IDAGENCIAS = Me.cmbAgencia.SelectedValue
            Else
                ObjconsultaGeneral.IDAGENCIAS = 0
            End If

            If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
                ObjconsultaGeneral.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
            Else
                ObjconsultaGeneral.IDFORMA_PAGO = 0
            End If
            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
                ObjconsultaGeneral.IDUNIDAD_ORIGEN = Me.CBIDUNIDAD_AGENCIA.SelectedValue
            Else
                ObjconsultaGeneral.IDUNIDAD_ORIGEN = 0
            End If

            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                ObjconsultaGeneral.IDUNIDAD_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
            Else
                ObjconsultaGeneral.IDUNIDAD_DESTINO = 0
            End If

            If Not IsNothing(Me.cbidtipo_entrega.SelectedValue) Then
                ObjconsultaGeneral.IDTIPO_ENTREGA = Me.cbidtipo_entrega.SelectedValue
            Else
                ObjconsultaGeneral.IDTIPO_ENTREGA = 0
            End If
            '
            Dim P_ENTRE As Long = 0
            '
            ObjconsultaGeneral.tipo_consulta = Me.cmb_consulta_por.SelectedValue
            '
            If Not IsNothing(Me.cmb_agencia_destino.SelectedValue) Then
                ObjconsultaGeneral.IDAGENCIAS_DESTINO = Me.cmb_agencia_destino.SelectedValue
            Else
                ObjconsultaGeneral.IDAGENCIAS_DESTINO = 0
            End If
            '13/08/2010 - 
            '
            'mycarga_acompanada
            '05/08/2010 - Se adiciona la venta carga acompañada loco
            'If Cmb_carga_acompanada.SelectedIndex = 0 Then   ' Todos 
            '    ObjconsultaGeneral.carga_acompanada = "2"
            'ElseIf Cmb_carga_acompanada.SelectedIndex = 1 Then '
            '    ObjconsultaGeneral.carga_acompanada = "0"   'Venta Normal 
            'ElseIf Cmb_carga_acompanada.SelectedIndex = 2 Then '
            '    ObjconsultaGeneral.carga_acompanada = "1"   'Venta Carga Acompañada  
            'Else
            '    ObjconsultaGeneral.carga_acompanada = "3"   'Pyme
            'End If
            '
            If Cmb_carga_acompanada.SelectedValue = 0 And Cmb_carga_acompanada.SelectedIndex = 0 Then   ' Todos 
                ObjconsultaGeneral.carga_acompanada = "2"
            ElseIf Cmb_carga_acompanada.SelectedValue = 0 Then '
                ObjconsultaGeneral.carga_acompanada = "0"   'Venta Normal 
            ElseIf Cmb_carga_acompanada.SelectedValue = 6 Then '
                ObjconsultaGeneral.carga_acompanada = "1"   'Venta Carga Acompañada  
            ElseIf Cmb_carga_acompanada.SelectedValue = 7 Then '
                ObjconsultaGeneral.carga_acompanada = "3"   'Pyme
            ElseIf Cmb_carga_acompanada.SelectedValue = 8 Then
                ObjconsultaGeneral.carga_acompanada = "4"
            End If

            dvListar_facturas = ObjconsultaGeneral.sp_ConsulFactuEmiEntreManu(P_ENTRE)
            '
            If dvListar_facturas.Count <= 0 Then
                MsgBox("No existen registros", MsgBoxStyle.Information, "Seguridad del Sistema...")
            End If
            '
            FORMAT_GRILLA3()
            '
            Me.txt_nro_registro.Text = CType(Me.DGV3.RowCount, String)

            Select Case Me.cmb_consulta_por.SelectedValue
                Case 1, 2, 3, 4
                    txtPeso.Text = FormatNumber(dvListar_facturas.Table.Compute("sum(peso_total)", String.Empty).ToString, 2)
                    txtBulto.Text = FormatNumber(dvListar_facturas.Table.Compute("sum(cantidad_total)", String.Empty).ToString, 2)
                Case 5
                    txtPeso.Text = FormatNumber(dvListar_facturas.Table.Compute("sum(total_peso)", String.Empty).ToString, 2)
                    txtBulto.Text = FormatNumber(dvListar_facturas.Table.Compute("sum(cantidad)", String.Empty).ToString, 2)
            End Select
            '
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
        '
    End Sub

    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click, Label17.Click

    End Sub

    Private Sub cmb_consulta_por_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_consulta_por.SelectedIndexChanged
        DGV3.DataSource = Nothing
        DGV3.Rows.Clear()
        txt_nro_registro.Text = 0
        txtBulto.Text = 0
        txtPeso.Text = "0.00"
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub DGV3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.CellContentClick

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

    Private Sub cbidtipo_comprobante_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbidtipo_comprobante.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub cmb_agencia_destino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_agencia_destino.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub Cmb_carga_acompanada_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_carga_acompanada.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub
End Class