Public Class frmcambio_tipo_entrega
#Region "Variable publica"
    ' 
    Public iIDagenciaDestino As Integer 'CAMBIO 
    Public ps_idpersona As String
    Public ps_idcomprobante As String
    Public ps_idtipo_comprobante As String
    Public ps_agenciaDestino As Integer
    Public pl_tipo_entrega As Long
    Public pb_cancela As Boolean = False
    Public hnd As Long
    Dim dtdireccion As DataTable

    'Public pdt_tipo_entrega As New DataTable
    '
    Public iWinDireccion_Destinatario As New AutoCompleteStringCollection
#End Region
#Region "variable"
    Dim odbda_tipo_entrega As New OleDb.OleDbDataAdapter
    Dim rst_direccion_cliente As New ADODB.Recordset
    Dim dt_tipo_entrega_datos, dt_tipo_entrega As New DataTable
    Dim dv_tipo_entrega As New DataView
    Dim coll_Direccion_Destinatario As New Collection
    Dim b_lee As Boolean = True
    Dim bIngreso As Boolean = False
#End Region
#Region "Adicional"
    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize)
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
#End Region

    Public dtDepartamento, dtDepartamento2 As DataTable
    Public dtProvincia, dtProvincia2 As DataTable
    Public dtDistrito, dtDistrito2 As DataTable

#Region "evento"

    Private Sub frmcambio_tipo_entrega_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
        If Not btnaceptar.Focused Then pb_cancela = True
    End Sub
    'Load 
    Private Sub frmcambio_tipo_entrega_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim lrst_tipo_entrega As New ADODB.Recordset
        Dim li_tipo_entrega As Long
        '
        Try
            b_lee = False
            Me.txtidpersona.Text = ps_idpersona
            Me.txtidcomprobante.Text = ps_idcomprobante
            Me.txtidtipo_comprobante.Text = ps_idtipo_comprobante
            'Recupera lista de entrega de carga 
            ObjEntregaCarga.sidpersona = ps_idpersona
            ObjEntregaCarga.lidtipo_comprobante = CType(ps_idtipo_comprobante, Long)
            ObjEntregaCarga.sidcomprobante = ps_idcomprobante
            '
            'Mod.14/09/2009 -->Omendoza - Pasando al datahelper   
            '
            dt_tipo_entrega_datos = ObjEntregaCarga.fnrecupera_datos_tipo_entrega()
            'lrst_tipo_entrega = ObjEntregaCarga.rst_tipo_entrega_o
            'rst_direccion_cliente = ObjEntregaCarga.rst_direccion_entrega
            recupera_direccion(ObjEntregaCarga.dt_rst_direccion_entrega)
            '
            'odbda_tipo_entrega.Fill(dt_tipo_entrega, lrst_tipo_entrega)
            dt_tipo_entrega = ObjEntregaCarga.dt_rst_tipo_entrega_o
            '
            dv_tipo_entrega = Funciones.CargarCombo(Me.cmbtipo_entrega, dt_tipo_entrega, "tipo_entrega", "idtipo_entrega", pl_tipo_entrega)
            ' 
            li_tipo_entrega = pl_tipo_entrega
            Me.cmbtipo_entrega.SelectedValue = li_tipo_entrega
            Me.lab_tipo_dcto.Text = CType(dt_tipo_entrega_datos.Rows(0)(5), String)
            Me.txt_razon_social.Text = CType(dt_tipo_entrega_datos.Rows(0)(1), String)
            Me.txtnro_documento.Text = CType(dt_tipo_entrega_datos.Rows(0)(2), String)
            If IsDBNull(dt_tipo_entrega_datos.Rows(0)(3)) = False And li_tipo_entrega = 2 Then
                Me.txtiddireccion.Text = CType(dt_tipo_entrega_datos.Rows(0)(3), String)
            Else
                Me.txtiddireccion.Text = ""
            End If

            If IsDBNull(dt_tipo_entrega_datos.Rows(0)(4)) = False And li_tipo_entrega = 2 Then
                Me.txt_direccion.Text = CType(dt_tipo_entrega_datos.Rows(0)(4), String)
            Else
                Me.txt_direccion.Text = ""
            End If
            '
            configura()
            '
            b_lee = True
            '
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True           
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    'Salir 
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        pb_cancela = True
        Me.Close()
    End Sub

    Dim iFila As Integer = 0
    Sub CargarDireccionEstructurada()
        iFila = Me.CboDireccion.SelectedIndex
        'RemoveHandler CboDepartamento.SelectedIndexChanged, AddressOf CboDepartamento_SelectedIndexChanged
        'RemoveHandler CboDistrito.SelectedIndexChanged, AddressOf CboDistrito_SelectedIndexChanged
        'RemoveHandler CboProvincia.SelectedIndexChanged, AddressOf CboProvincia_SelectedIndexChanged
        CboDepartamento.SelectedValue = IIf(IsDBNull(dtdireccion.Rows(iFila).Item("iddepartamento")), iFila, dtdireccion.Rows(iFila).Item("iddepartamento"))
        CboProvincia.SelectedValue = IIf(IsDBNull(dtdireccion.Rows(iFila).Item("idprovincia")), iFila, dtdireccion.Rows(iFila).Item("idprovincia"))
        CboDistrito.SelectedValue = IIf(IsDBNull(dtdireccion.Rows(iFila).Item("iddistrito")), iFila, dtdireccion.Rows(iFila).Item("iddistrito"))
        CboVia.SelectedValue = IIf(IsDBNull(dtdireccion.Rows(iFila).Item("id_via")), iFila, dtdireccion.Rows(iFila).Item("id_via"))
        TxtVia.Text = IIf(IsDBNull(dtdireccion.Rows(iFila).Item("via")), "", dtdireccion.Rows(iFila).Item("via"))
        TxtNumero2.Text = IIf(IsDBNull(dtdireccion.Rows(iFila).Item("numero")), "", dtdireccion.Rows(iFila).Item("numero"))
        TxtManzana.Text = IIf(IsDBNull(dtdireccion.Rows(iFila).Item("manzana")), "", dtdireccion.Rows(iFila).Item("manzana"))
        TxtLote.Text = IIf(IsDBNull(dtdireccion.Rows(iFila).Item("lote")), "", dtdireccion.Rows(iFila).Item("lote"))
        CboNivel.SelectedValue = IIf(IsDBNull(dtdireccion.Rows(iFila).Item("id_nivel")), iFila, dtdireccion.Rows(iFila).Item("id_nivel"))
        TxtNivel.Text = IIf(IsDBNull(dtdireccion.Rows(iFila).Item("nivel")), "", dtdireccion.Rows(iFila).Item("nivel"))
        CboZona.SelectedValue = IIf(IsDBNull(dtdireccion.Rows(iFila).Item("id_zona")), iFila, dtdireccion.Rows(iFila).Item("id_zona"))
        TxtZona.Text = IIf(IsDBNull(dtdireccion.Rows(iFila).Item("zona")), "", dtdireccion.Rows(iFila).Item("zona"))
        CboClasificacion.SelectedValue = IIf(IsDBNull(dtdireccion.Rows(iFila).Item("Id_Clasificacion")), iFila, dtdireccion.Rows(iFila).Item("Id_Clasificacion"))
        TxtClasificacion.Text = IIf(IsDBNull(dtdireccion.Rows(iFila).Item("Clasificacion")), "", dtdireccion.Rows(iFila).Item("Clasificacion"))
        TxtReferencia.Text = IIf(IsDBNull(dtdireccion.Rows(iFila).Item("De_Referencia")), "", dtdireccion.Rows(iFila).Item("De_Referencia"))
        'AddHandler CboDepartamento.SelectedIndexChanged, AddressOf CboDepartamento_SelectedIndexChanged
        'AddHandler CboDistrito.SelectedIndexChanged, AddressOf CboDistrito_SelectedIndexChanged
        'AddHandler CboProvincia.SelectedIndexChanged, AddressOf CboProvincia_SelectedIndexChanged
    End Sub

   
    Dim bSalir As Boolean = True
    Public iTipoEntrega As Integer
    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        Try
            'Dim rst_mensaje As New ADODB.Recordset
            Dim dt_rst_mensaje As New DataTable
            Dim ls_mensaje As String
            Dim ll_valor As Long
            '
            ObjEntregaCarga.lidtipo_comprobante = CType(ps_idtipo_comprobante, Long)
            ObjEntregaCarga.sidcomprobante = CType(ps_idcomprobante, String)
            ObjEntregaCarga.l_tipo_entrega = Me.cmbtipo_entrega.SelectedValue

            'If Me.txtiddireccion.Text.Trim = "" Then
            '    ObjEntregaCarga.s_iddireccion_tipo_entrega = "0"
            'Else
            '    ObjEntregaCarga.s_iddireccion_tipo_entrega = CType(Me.txtiddireccion.Text, String)
            'End If

            If Me.CboDireccion.SelectedValue = 0 Then
                ObjEntregaCarga.s_iddireccion_tipo_entrega = "0"
            Else
                ObjEntregaCarga.s_iddireccion_tipo_entrega = Me.CboDireccion.SelectedValue
            End If

            ' 
            'If Me.cmbtipo_entrega.SelectedValue = 2 Then
            '    If Me.txt_direccion.Text = "" Then
            '        MsgBox("Debe ingresar dirección", MsgBoxStyle.Information, "Sistema Entrega de Carga")
            '        Me.txt_direccion.Focus()
            '        Exit Sub
            '    Else
            '        ObjEntregaCarga.s_direccion_tipo_entrega = Me.txt_direccion.Text
            '    End If
            'End If
            ' 
            ObjEntregaCarga.sidpersona = Me.txtidpersona.Text
            ObjEntregaCarga.l_idusuario_personal = dtoUSUARIOS.IdLogin
            ObjEntregaCarga.l_idrol_usuario = dtoUSUARIOS.IdRol
            ObjEntregaCarga.s_ip = dtoUSUARIOS.IP
            'Mod.14/09/2009 -->Omendoza - Pasando al datahelper   
            'dt_rst_mensaje = ObjEntregaCarga.fnactualiza_datos_tipo_entrega()
            ''
            ''ll_valor = CType(rst_mensaje.Fields.Item(0).Value, Long)
            ''ls_mensaje = CType(rst_mensaje.Fields.Item(1).Value, String)
            'll_valor = CType(dt_rst_mensaje.Rows(0).Item(0), Long)
            'ls_mensaje = CType(dt_rst_mensaje.Rows(0).Item(1), String)
            'MsgBox(ls_mensaje, MsgBoxStyle.Information, "Sistema Entrega de Carga")
            'If ll_valor <> 0 Then
            '    Exit Sub
            'End If
            'pb_cancela = False
            'Me.Close()

            '-----------------VERSION DIRECCION ESTRUCTURADA----------------------------------------------------------------
            If cmbtipo_entrega.SelectedIndex = 1 And CboDireccion.SelectedIndex = 0 Then
                If Me.CboDepartamento.SelectedValue = 0 Then
                    MessageBox.Show("Seleccione el Departamento", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    Me.CboDepartamento.Focus()
                    Return
                End If

                If Me.CboProvincia.SelectedValue = 0 Then
                    MessageBox.Show("Seleccione la Provincia", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    Me.CboProvincia.Focus()
                    Return
                End If

                If Me.CboDistrito.SelectedValue = 0 Then
                    MessageBox.Show("Seleccione el Distrito", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    Me.CboDistrito.Focus()
                    Return
                End If

                'If Me.CboVia.SelectedValue = 0 Then
                If Me.CboVia.SelectedValue = 0 And CboZona.SelectedValue = 0 Then 'cambio 03102011
                    MessageBox.Show("Seleccione Tipo de Vía", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    Me.CboVia.Focus()
                    Return
                End If

                'If Me.TxtVia.Text.Trim.Length = 0 Then
                If Me.TxtVia.Text.Trim.Length = 0 And CboZona.SelectedValue = 0 Then 'cambio 03102011
                    MessageBox.Show("Ingrese Nombre de la Vía", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    Me.TxtVia.Text = ""
                    Me.TxtVia.Focus()
                    Return
                End If

                If Me.TxtNumero2.Text.Trim.Length = 0 And Me.TxtManzana.Text.Trim.Length = 0 And Me.TxtLote.Text.Trim.Length = 0 Then
                    Dim sMje As String = ""
                    Dim i As Integer
                    'If Me.TxtNumero2.Text.Trim.Length = 0 Then
                    If Me.TxtNumero2.Text.Trim.Length = 0 And CboVia.SelectedValue > 0 Then 'cambio 03102011
                        sMje = "Nº de la Vía"
                        i = 1
                    ElseIf Me.TxtManzana.Text.Trim.Length = 0 Then
                        sMje = "Manzana de la Vía"
                        i = 2
                    Else
                        sMje = "Lote de la Vía"
                        i = 3
                    End If
                    MessageBox.Show("Ingrese " & sMje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    If Me.TxtManzana.Text.Trim.Length = 0 Then Me.TxtManzana.Text = ""
                    If Me.TxtLote.Text.Trim.Length = 0 Then Me.TxtLote.Text = ""

                    If i = 1 Then
                        Me.TxtNumero2.Focus()
                    ElseIf i = 2 Then
                        Me.TxtManzana.Focus()
                    Else
                        Me.TxtLote.Focus()
                    End If
                    Return
                End If

                If Me.TxtNumero2.Text.Trim.Length = 0 And (Me.TxtManzana.Text.Trim.Length = 0 Or Me.TxtLote.Text.Trim.Length = 0) Then
                    Dim sMje As String = ""
                    Dim i As Integer
                    If Me.TxtManzana.Text.Trim.Length = 0 Then
                        sMje = "Manzana de la Vía"
                        i = 1
                    Else
                        sMje = "Lote de la Vía"
                        i = 2
                    End If
                    MessageBox.Show("Ingrese " & sMje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    If Me.TxtManzana.Text.Trim.Length = 0 Then Me.TxtManzana.Text = ""
                    If Me.TxtLote.Text.Trim.Length = 0 Then Me.TxtLote.Text = ""
                    If i = 1 Then
                        Me.TxtManzana.Focus()
                    Else
                        Me.TxtLote.Focus()
                    End If
                    Return
                End If

                If Me.CboNivel.SelectedValue > 0 AndAlso Me.TxtNivel.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Nombre del Nivel", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    Me.TxtNivel.Text = ""
                    Me.TxtNivel.Focus()
                    Return
                End If

                If Me.CboZona.SelectedValue > 0 AndAlso Me.TxtZona.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Nombre de la Zona", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    Me.TxtZona.Text = ""
                    Me.TxtZona.Focus()
                    Return
                End If

                If Me.CboClasificacion.SelectedValue > 0 AndAlso Me.TxtClasificacion.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Nombre de la Clasificación", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bSalir = False
                    Me.TxtClasificacion.Text = ""
                    Me.TxtClasificacion.Focus()
                    Return
                End If


                Dim sDireccion As String = IIf(CboVia.SelectedValue = 0, "", CboVia.Text) & " " & TxtVia.Text.Trim & " " 'Cambio 03102011
                If TxtNumero2.Text.Trim.Length > 0 Then
                    sDireccion &= TxtNumero2.Text.Trim & " "
                End If

                '20-10-2011
                If CboZona.SelectedValue > 0 Then
                    sDireccion &= CboZona.Text & " " & TxtZona.Text.Trim & " "
                End If

                If TxtManzana.Text.Trim.Length > 0 Then
                    sDireccion &= "MZ " & TxtManzana.Text.Trim & " LT " & TxtLote.Text.Trim & " "
                End If
                '----------------------------------------------------------------------------------------
                If CboNivel.SelectedValue > 0 Then
                    sDireccion &= CboNivel.Text & " " & TxtNivel.Text.Trim & " "
                End If
                If CboClasificacion.SelectedValue > 0 Then
                    sDireccion &= CboClasificacion.Text & " " & TxtClasificacion.Text.Trim & " "
                End If
                ObjEntregaCarga.s_direccion_tipo_entrega = sDireccion
            End If

            

            dt_rst_mensaje = ObjEntregaCarga.fnactualiza_datos_tipo_entrega_I(CboDepartamento.SelectedValue, CboProvincia.SelectedValue, CboDistrito.SelectedValue, CboVia.SelectedValue, _
                                                                              TxtVia.Text.Trim, TxtNumero2.Text.Trim, TxtManzana.Text.Trim, TxtLote.Text.Trim, _
                                                                              CboNivel.SelectedValue, TxtNivel.Text.Trim, CboZona.SelectedValue, _
                                                                              TxtZona.Text.Trim, CboClasificacion.SelectedValue, TxtClasificacion.Text.Trim, _
                                                                              TxtReferencia.Text.Trim, ps_agenciaDestino)

            ll_valor = CType(dt_rst_mensaje.Rows(0).Item(0), Long)
            ls_mensaje = CType(dt_rst_mensaje.Rows(0).Item(1), String)
            MsgBox(ls_mensaje, MsgBoxStyle.Information, "Sistema Entrega de Carga")
            If ll_valor <> 0 Then
                Exit Sub
            End If
            pb_cancela = False
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    'Cambio de entrega 
    Private Sub cmbtipo_entrega_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtipo_entrega.SelectedValueChanged
        'Dim l_tipo_entrega As Long
        Try
            If b_lee = True Then
                configura()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub txt_direccion_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_direccion.Leave
        Try
            fnMantenimienteDireccion(txt_direccion)
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "Procedimientos y Funciones"
    '
    'Mod.14/09/2009 -->Omendoza - Pasando al datahelper   
    'Sub recupera_direccion(ByVal arst_direccion_cliente As ADODB.Recordset)
    '    Try
    '        If arst_direccion_cliente.BOF = False And arst_direccion_cliente.EOF = False Then
    '            Me.txtiddireccion.Text = Int(arst_direccion_cliente.Fields.Item(0).Value.ToString)
    '            Me.txt_direccion.Text = arst_direccion_cliente.Fields.Item(1).Value.ToString
    '            fnCargar_iWin(Me.txt_direccion, arst_direccion_cliente, coll_Direccion_Destinatario, iWinDireccion_Destinatario, Int(Me.txtiddireccion.Text))
    '        Else
    '            Me.txt_direccion.Text = ""
    '            Me.txtiddireccion.Text = 0
    '        End If
    '        '
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
    '    End Try
    'End Sub
    Sub recupera_direccion(ByVal dt_rst_direccion_cliente As DataTable)
        Try
            If dt_rst_direccion_cliente.Rows.Count > 0 Then
                Me.txtiddireccion.Text = Int(dt_rst_direccion_cliente.Rows(0).Item(0).ToString)
                Me.txt_direccion.Text = dt_rst_direccion_cliente.Rows(0).Item(1).ToString
                fnCargar_iWin_dt(Me.txt_direccion, dt_rst_direccion_cliente, coll_Direccion_Destinatario, iWinDireccion_Destinatario, Int(Me.txtiddireccion.Text))
            Else
                Me.txt_direccion.Text = ""
                Me.txtiddireccion.Text = 0
            End If
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Public Function fnMantenimienteDireccion(ByVal iDireccion As TextBox) As Boolean
        Dim ls_flag As Boolean = True
        Try
            '
            Dim indexof As Long
            '
            If iWinDireccion_Destinatario.Count > 0 Then
                indexof = iWinDireccion_Destinatario.IndexOf(iDireccion.Text)
                ObjManteClienteContado.v_idDireccion = 0
                If indexof >= 0 Then
                    Me.txtiddireccion.Text = Int(coll_Direccion_Destinatario.Item(indexof.ToString))
                Else
                    Me.txtiddireccion.Text = ""
                End If
            Else
                Me.txtiddireccion.Text = ""
            End If
            '
        Catch ex As Exception
            Return ls_flag
        End Try
    End Function
    Sub configura()
        Dim l_tipo_entrega As Long
        l_tipo_entrega = CType(Me.cmbtipo_entrega.SelectedValue, Long)
        If l_tipo_entrega = 1 Then ' Debe ocultar los campos de Agencia 
            Me.txt_direccion.Visible = False
            Me.txt_direccion.Text = ""  ' Limpiando variable fr
            Me.lab_direccion.Visible = False

            Me.lbldireccion.Visible = False
            Me.CboDireccion.Visible = False
            Me.GrbDireccion.Visible = False

            Me.Size = New System.Drawing.Size(390, 158)           
            Me.btn_cancelar.Location = New Point(189, 90)
            Me.btnaceptar.Location = New Point(285, 90)
        Else
            'Me.Size = New System.Drawing.Size(700, 372)
            Me.txt_direccion.Visible = True
            Me.lab_direccion.Visible = True
            Me.lbldireccion.Visible = True
            Me.CboDireccion.Visible = True

            ''----DIRECCION ESTRUCTURADA------               
            Dim obj As New dtoVentaCargaContado
            'Dim dtdireccion As DataTable = obj.Direccion(CType(dt_tipo_entrega_datos.Rows(0)(3), String))
            dtdireccion = obj.Direccion_I(ps_idpersona, ps_agenciaDestino)

            With Me.CboDireccion
                .DataSource = dtdireccion
                .DisplayMember = "direccion"
                .ValueMember = "iddireccion_consignado"
                If CboDireccion.Items.Count = 1 Then
                    .SelectedIndex = 0
                    .Focus()
                    Me.NuevaDireccion()
                Else
                    'CboDireccion.SelectedValue = CType(dt_tipo_entrega_datos.Rows(0)(3), Integer)
                    .SelectedIndex = 1
                    .DroppedDown = True
                    .Focus()                    
                End If
            End With
            'Me.CargarDireccionEstructurada()

        End If
    End Sub

    Sub Inicio()
        Try
            Dim obj As New dtoVentaCargaContado
            Dim ds As New DataSet           
            ds = obj.Inicio(ps_agenciaDestino, 1)

            With Me.CboVia
                .DataSource = ds.Tables(0)
                .DisplayMember = "via"
                .ValueMember = "id_via"
            End With

            With Me.CboZona
                .DataSource = ds.Tables(1)
                .DisplayMember = "zona"
                .ValueMember = "id_zona"
            End With

            With Me.CboNivel
                .DataSource = ds.Tables(2)
                .DisplayMember = "nivel"
                .ValueMember = "id_nivel"
            End With
            With Me.CboClasificacion
                .DataSource = ds.Tables(3)
                .DisplayMember = "clasificacion"
                .ValueMember = "id_clasificacion"
            End With
            dtDepartamento = ds.Tables(4)
            With Me.CboDepartamento
                .DataSource = dtDepartamento
                .DisplayMember = "departamento"
                .ValueMember = "iddepartamento"
            End With

            dtProvincia = ds.Tables(5)
            With Me.CboProvincia
                CboProvincia.DataSource = dtProvincia
                CboProvincia.DisplayMember = "provincia"
                CboProvincia.ValueMember = "idprovincia"
            End With

            dtDistrito = ds.Tables(6)
            With Me.CboDistrito
                CboDistrito.DataSource = dtDistrito
                CboDistrito.DisplayMember = "dsitrito"
                CboDistrito.ValueMember = "iddistrito"
            End With

            Dim sender As Object
            Dim e As New EventArgs
            If ds.Tables(7).Rows.Count > 0 Then
                CboDepartamento.SelectedValue = ds.Tables(7).Rows(0).Item("dpto")
                If CboDepartamento.SelectedIndex < 0 Then CboDepartamento.SelectedValue = 0

                CboProvincia.SelectedValue = 0
                CboDepartamento_SelectedIndexChanged(sender, e)
                CboProvincia_SelectedIndexChanged(sender, e)
                CboDistrito.SelectedValue = 0
            Else
                CboDepartamento_SelectedIndexChanged(sender, e)
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

#End Region

    '-----Nuevo direccion Estructurada

    Private Sub CboDepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDepartamento.SelectedIndexChanged
        If Not IsReference(CboDepartamento.SelectedValue) Then
            Dim sFiltro As String = "iddepartamento=" & CboDepartamento.SelectedValue & " or iddepartamento=0"
            dtProvincia.DefaultView.RowFilter = sFiltro

            sFiltro = "iddepartamento=" & CboDepartamento.SelectedValue & " or iddepartamento=0"
            dtDistrito.DefaultView.RowFilter = sFiltro
        End If
    End Sub

    Private Sub CboProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboProvincia.SelectedIndexChanged
        If Not IsReference(CboProvincia.SelectedValue) Then
            Dim sFiltro As String = ""
            If CboProvincia.SelectedValue > 0 Then
                sFiltro = "(iddepartamento=" & CboDepartamento.SelectedValue & " or iddepartamento=0) and (idprovincia=" & CboProvincia.SelectedValue & " or idprovincia=0)"
            Else
                sFiltro = "iddepartamento=" & CboDepartamento.SelectedValue & " or iddepartamento=0"
            End If
            dtDistrito.DefaultView.RowFilter = sFiltro
            CboDistrito.SelectedValue = 0
        End If
    End Sub

    Private Sub CboDistrito_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDistrito.SelectedIndexChanged
        If Not IsReference(CboDistrito.SelectedValue) Then
            Dim iId As Integer = CboDistrito.SelectedValue
            Dim filas() As DataRow = dtDistrito.Select("iddistrito=" & iId)
            RemoveHandler CboProvincia.SelectedIndexChanged, AddressOf CboProvincia_SelectedIndexChanged
            Me.CboProvincia.SelectedValue = filas(0).Item("idprovincia")
            AddHandler CboProvincia.SelectedIndexChanged, AddressOf CboProvincia_SelectedIndexChanged
        End If
    End Sub

    Private Sub CboDireccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDireccion.SelectedIndexChanged
        'Dim a As Integer = CboDireccion.SelectedValue
        If CboDireccion.SelectedIndex = 0 And CboDireccion.Focused Then            
            Me.NuevaDireccion()
        Else
            GrbDireccion.Visible = False
            Me.Size = New System.Drawing.Size(383, 180)
            Me.btn_cancelar.Location = New Point(189, 112)
            Me.btnaceptar.Location = New Point(285, 112)
        End If
    End Sub

    Sub NuevaDireccion()
        Me.Inicio() 'cambio direccion estructurada
        Me.btn_cancelar.Location = New Point(482, 254)
        Me.btnaceptar.Location = New Point(578, 254)
        Me.Size = New System.Drawing.Size(680, 321)
        GrbDireccion.Visible = True
    End Sub
End Class