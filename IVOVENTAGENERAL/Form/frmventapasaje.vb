Public Class frmventapasaje
#Region "Variables"
    '
    Public coll_iDestino As New Collection
    Public coll_iOrigen As New Collection
    '
    Public iWinDestino As New AutoCompleteStringCollection
    Public iWinorigen As New AutoCompleteStringCollection
    ' Los almacenamientos de datos 
    Dim odba As New OleDb.OleDbDataAdapter
    Dim dtcondicion, dttarjeta As New DataTable
    Dim dvcondicion, dvtarjeta As New DataView
    Dim bno_lee_condicion As Boolean = True
    ' 
    Dim TipoComprobante As Integer = 2
    Dim inro_Digitos_Ventas As Integer = 7
    Dim inro_Digitos_SerieVentas As Integer = 3
    '
    Dim varIdtipo_comprobante As Integer = 0
    'Variable con respecto a la asociacion de la cuenta
    Dim b_leecuenta As Boolean = False
    'Variables con respecto al pasajero  
    Dim stel_pasajero As String
    Dim lidpersona As Long
    Dim lidpersona_ruc As Long
    Dim lidUnidadAgencias_destino As Long
    ' 
    Dim snro_serie As String
    Dim snro_comprobante As String
    ' Recuperando el valor del IGV 
    Dim IGV As Double = dtoUSUARIOS.iIGV ' dtoUSUARIOS.iIGV '/ 100  el valor real ' Recupera el valor de la bd, pero en pasaje no es necesario 
    '
    Dim li_control As Long
    Dim b_no_lee_campo As Boolean
    Dim odbda As New OleDb.OleDbDataAdapter
    '
    Public dvControl, dvforma_pago As New DataView
    Public dtControl, dtforma_pago As New DataTable
    '
    Public dvdocumento As New DataView
    Public dtdocumento As New DataTable
    '
    Public dvagencias, dvagencias_origen As New DataView
    Public dtagencias, dtagencias_origen As New DataTable
    '
    Dim lscondicion As String  'Del tipo de condición para que lea los datos 
    '
    Dim lee_focus As Boolean = True
    ' Para validar el caso de comprobante 
    Dim ds_serie_comprobante_new, ds_nro_comprobante_new As String
    Dim ds_serie_comprobante_old, ds_nro_comprobante_old As String
    Dim db_comprobante_nolee As Boolean = True

    Private ObjReport As ClsLbTepsa.dtoFrmReport '

    '
    Dim bIngreso As Boolean = False
    Dim blnInicio As Boolean

    Public hnd As Long
#End Region

    Private Sub frmventapasaje_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frmventapasaje_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            blnInicio = True
            dtoUSUARIOS.m_iNombreUnidadAgencia = fnGetCiudad(dtoUSUARIOS.m_idciudad.ToString)
            dtoUSUARIOS.m_iNombreAgencia = fnGetAGENCIA(dtoUSUARIOS.m_iIdAgencia.ToString)
            Me.Text = "VENTAS PASAJE..." & dtoUSUARIOS.iLOGIN & " Ag. Nro " & dtoUSUARIOS.m_iIdAgencia & " [ " & dtoUSUARIOS.m_iNombreAgencia & " ][ " & dtoUSUARIOS.m_iNombreUnidadAgencia & "] "
            ToolStripMenuItem1.Text = "&BUSCAR"
            ToolStripMenuItem2.Text = "&BOLETO PASAJE"
            Me.RBPasaje.Checked = True
            SelectMenu(1)
            '
            If ObjVentaPasaje.fnLISTA_INICIAL_VENTAPASAJE() = True Then
                '
                dtdocumento = ObjVentaPasaje.rst_documento
                bno_lee_condicion = False
                dvdocumento = CargarCombo(Me.cmbtipocomprobante, dtdocumento, "tipo_comprobante", "idtipo_comprobante", 12)
                bno_lee_condicion = True
                ''                
                dtcondicion = ObjVentaPasaje.rst_condicion
                bno_lee_condicion = False
                dvcondicion = CargarCombo(Me.cmbcondicion, dtcondicion, "condicion", "idcondicion_boleto", 2)
                bno_lee_condicion = True
                '
                dtagencias = ObjVentaPasaje.rst_agencias
                dtagencias_origen = dtagencias.Copy

                bno_lee_condicion = False
                dvagencias = CargarCombo(Me.cmbagenciadestino, dtagencias, "nombre_agencia", "idagencias", -1)
                dvagencias_origen = CargarCombo(Me.cmbagencia_origen, dtagencias_origen, "nombre_agencia", "idagencias", dtoUSUARIOS.m_iIdAgencia)
                bno_lee_condicion = True

                '21/02/2007
                dttarjeta = ObjVentaPasaje.rst_tarjeta
                dvtarjeta = CargarCombo(Me.cmbtarjeta, dttarjeta, "descripcion", "idtarjetas", -666)
                ' 
                dtforma_pago = ObjVentaPasaje.rst_forma_pago
                dvforma_pago = CargarCombo(Me.Cmbformapago, dtforma_pago, "forma_pago", "idforma_pago", 1)
                '
                fnCargar_iWin_dt(txtiWinDestino, ObjVentaPasaje.rst_unidad_agencia, coll_iDestino, iWinDestino, 0)
                fnCargar_iWin_dt(txtiWinorigen, ObjVentaPasaje.rst_unidad_agencia, coll_iOrigen, iWinorigen, 0)
            End If
            recupera_origen(CType(dtoUSUARIOS.m_idciudad, Long))
            ' Para la pantalla de busqueda -- Omendoza 
            '
            If ObjVentaPasaje.fnLISTA_AGENCIAS_UNIDADES() = True Then
                ModuUtil.LlenarComboIDs2(ObjVentaPasaje.rst_Lista_Unidades_Agencia, cmbOrigen, ObjVentaPasaje.coll_Lista_Origen, 9999, cmbDestino, ObjVentaPasaje.coll_Lista_Destino, 9999)
            End If
            '
            Dim dt As DataTable = ObjVentaPasaje.fnGetAgencias()
            ModuUtil.LlenarCombo2(dt, cmbAgencia, ObjVentaPasaje.coll_Lista_Agencias, dtoUSUARIOS.m_iIdAgencia)

            If ObjVentaPasaje.fnFILTRO_USUARIO_X_AGENCIA(dtoUSUARIOS.m_iIdAgencia, Me.dtFechaInicio.Value.ToShortDateString, Me.dtFechaFin.Value.ToShortDateString) = True Then
                ModuUtil.LlenarCombo2(ObjVentaPasaje.rst_Lista_Usuarios, cmbUsuarios, ObjVentaPasaje.coll_Lista_Usuarios, dtoUSUARIOS.IdLogin)
            Else
                NingunoComboIDs(cmbUsuarios, ObjVentaPasaje.coll_Lista_Usuarios)
            End If
            'rst = Nothing
            blnInicio = False

            fnLoadGrid()
            '' Fin de la grilla  y busqueda  omendoza 
            dtp_fec_emision.Text = dtoUSUARIOS.m_sFecha
            DTPfec_viaje.Text = dtoUSUARIOS.m_sFecha
            '
            If ObjVentaPasaje.fnNroDocumento(5) = True Then ' La serie será del boleto de viaje -16/06/2007
                If IsDBNull(ObjVentaPasaje.Serie) = True Or RellenoRight(inro_Digitos_SerieVentas, ObjVentaPasaje.Serie) = "000" Then
                    MessageBox.Show("No ha configurado la serie del boleto de viaje", "Venta de Pasajes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                    Exit Sub
                End If
                TXTSER_COMPROBANTE.Text = RellenoRight(inro_Digitos_SerieVentas, ObjVentaPasaje.Serie)
                TXTNRO_COMPROBANTE.Text = RellenoRight(inro_Digitos_Ventas, ObjVentaPasaje.NroDoc)
                snro_serie = TXTSER_COMPROBANTE.Text
                snro_comprobante = CType(TXTNRO_COMPROBANTE.Text, String)
                ds_serie_comprobante_new = Me.TXTSER_COMPROBANTE.Text
                ds_nro_comprobante_new = Me.TXTNRO_COMPROBANTE.Text
            End If
            b_no_lee_campo = True
            li_control = 1 ' Por defecto 1 para grabar, la primera vez 
            Me.txttotal.Text = "0.00"
            '
            Labboleto_ref.Visible = False
            txtdctoreferencia_serie.Visible = False
            txtdctoreferencia_nrodcto.Visible = False
            '            
            Me.txtidunidadagencia.Focus()
            '
            Me.chk_es_fecha_abierta.Checked = False
            Me.txt_fec_viaje_tmp.Visible = False
            '
            bIngreso = False
            Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub txtiWinDestino_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtiWinDestino.KeyPress, txtiWinorigen.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            If Not IsNumeric(e.KeyChar) And Char.IsLetter(e.KeyChar) Then
                e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub
    Private Sub txtiWinDestino_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtiWinDestino.Validated
        ObjVentaPasaje.iIDAGENCIAS_DESTINO = 0
        fnAgenciaDestino()
    End Sub
    Private Sub fnAgenciaDestino()
        Try
            Dim idUnidadAgencias As Integer = iWinDestino.IndexOf(txtiWinDestino.Text)
            If idUnidadAgencias >= 0 Then
                idUnidadAgencias = Int(coll_iDestino.Item(idUnidadAgencias.ToString))
                lidUnidadAgencias_destino = CType(idUnidadAgencias, Long)
                Me.txtidunidadagencia.Text = lidUnidadAgencias_destino
                ''''''''''''''''''''
                'Recupera las agencias 
                fn_recupera_agencias(lidUnidadAgencias_destino, False)
            Else
                Me.txtidunidadagencia.Text = ""
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub cmbtipocomprobante_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtipocomprobante.SelectedIndexChanged
        Try
            If bno_lee_condicion Then
                ' varIdtipo_comprobante = Int(ObjVentaPasaje.coll_documento.Item(cmbtipocomprobante.SelectedIndex.ToString))
                varIdtipo_comprobante = Int(cmbtipocomprobante.SelectedValue)
                txtdctoreferencia_serie.Text = ""
                txtdctoreferencia_nrodcto.Text = ""
                ' Solo se debe considerar boletos . 
                If varIdtipo_comprobante = 10 Or varIdtipo_comprobante = 11 Or varIdtipo_comprobante = 12 Or varIdtipo_comprobante = 23 Then
                    Labboleto_ref.Visible = False
                    txtdctoreferencia_serie.Visible = False
                    txtdctoreferencia_nrodcto.Visible = False
                    '
                    Me.txtidunidadagencia.Focus()
                    lee_focus = True

                Else
                    Labboleto_ref.Visible = True
                    txtdctoreferencia_serie.Visible = True
                    txtdctoreferencia_nrodcto.Visible = True
                    lee_focus = False
                    Me.txtidunidadagorigen.Focus()
                End If
                '
                If varIdtipo_comprobante = 16 Or varIdtipo_comprobante = 17 Or varIdtipo_comprobante = 18 Then
                    Me.TXTSER_COMPROBANTE.Text = "200"
                Else
                    Me.TXTSER_COMPROBANTE.Text = snro_serie
                End If
                '
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub numericTextboxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTSER_COMPROBANTE.KeyPress, TXTNRO_COMPROBANTE.KeyPress, Txtdni.KeyPress, txtdctoreferencia_serie.KeyPress, txtdctoreferencia_nrodcto.KeyPress, txtedad.KeyPress, txtruc.KeyPress, txtidunidadagencia.KeyPress, txtidunidadagorigen.KeyPress, txtcuenta.KeyPress
        Try
            lee_focus = False
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
    Private Sub TXTSER_COMPROBANTE_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTSER_COMPROBANTE.Leave
        Dim b_control As Boolean
        ' 
        If db_comprobante_nolee = False Then
            db_comprobante_nolee = True
            b_no_lee_campo = True
        End If
        If b_no_lee_campo = True Then
            b_control = validar_serie_recibo()
            If Not b_control Then
                Exit Sub
            End If
            b_control = validar_serie_pasaje()
            If Not b_control Then
                Exit Sub
            End If
            'TXTNRO_COMPROBANTE.Focus()
        End If
    End Sub
    Private Sub Txtdni_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Txtdni.Validating
        Try
            If Txtdni.Text <> "" Then
                Txtdni.Text = RellenoRight(8, Txtdni.Text)
                '
                If Txtdni.Text.Length <> 8 Then
                    MsgBox("El Nº de Documento no es válido ", MsgBoxStyle.Information, "Seguridad Sistema")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            '
        End Try
    End Sub
    Private Sub DatosPersonalesboxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpasajero.KeyPress, txtmemo.KeyPress
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
    Public Function fnValidarRUC(ByVal strRUC As String) As Boolean
        Dim ret As Boolean = False
        Try
            Dim nDig, nd0, nd1, nd2, nd3, nd4, nd5, nd6, nd7, nd8, nd9, nRUC, nRes As Integer
            Dim strRes As String
            nDig = Int(strRUC.Substring(strRUC.Length - 1).ToString)
            nd0 = Int(strRUC.Substring(0, 1).ToString()) * 5
            nd1 = Int(strRUC.Substring(1, 1).ToString()) * 4
            nd2 = Int(strRUC.Substring(2, 1).ToString()) * 3
            nd3 = Int(strRUC.Substring(3, 1).ToString()) * 2
            nd4 = Int(strRUC.Substring(4, 1).ToString()) * 7
            nd5 = Int(strRUC.Substring(5, 1).ToString()) * 6
            nd6 = Int(strRUC.Substring(6, 1).ToString()) * 5
            nd7 = Int(strRUC.Substring(7, 1).ToString()) * 4
            nd8 = Int(strRUC.Substring(8, 1).ToString()) * 3
            nd9 = Int(strRUC.Substring(9, 1).ToString()) * 2
            nRUC = nd0 + nd1 + nd2 + nd3 + nd4 + nd5 + nd6 + nd7 + nd8 + nd9
            nRes = nRUC Mod 11
            strRes = Int(nRes.ToString)
            nRes = 11 - Int(strRes.Substring(strRes.Length - 1).ToString)
            strRes = Int(nRes)
            If nDig = Int(strRes.Substring(strRes.Length - 1).ToString) Then
                ret = True
            End If
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function
    Private Sub Txtdni_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtdni.Leave
        'Recupera los datos y colocas el valor 
        Try
            If b_no_lee_campo = True Then
                If Me.cmbcondicion.Focused = True Then
                    b_no_lee_campo = False
                    Exit Sub
                End If
                If Txtdni.Text = "" Then
                    Me.txtpasajero.Focus()
                    Exit Sub
                End If
                fnrecuperacliente()
                If lidpersona <= 0 Then
                    Me.txtpasajero.Focus()
                Else
                    Me.txtedad.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
        b_no_lee_campo = True
    End Sub
    Private Sub txtruc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtruc.Leave
        Try
            'Recupera los datos y colocas el valor 
            If b_no_lee_campo = True Then
                fnrecuperacliente_ruc()
                If lidpersona_ruc <= 0 And Me.txtruc.Text = "" Then
                    Me.DTPfec_viaje.Focus()
                Else
                    Me.txtrazon_social.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
        b_no_lee_campo = True
    End Sub
    Public Function fnrecuperacliente() As Boolean
        Dim flag As Boolean = False
        Try
            ' Venta al contado 
            ObjVentaPasaje.sNU_DOCU_SUNAT = IIf(Me.Txtdni.Text <> "", Me.Txtdni.Text, "null")
            If ObjVentaPasaje.fnLISTA_GET_CLIENTE = True Then
                ' stel_pasajero = ObjVentaPasaje.stelefono
                Me.txtpasajero.Text = ObjVentaPasaje.snombre_pasajero
                lidpersona = ObjVentaPasaje.lidpersona
                flag = True
            Else
                flag = False
                'MsgBox("No tiene documento de identidad", MsgBoxStyle.Information, "Revisar los datos")
            End If
        Catch ex As Exception
            flag = False
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            Throw New Exception(ex.Message)
        End Try
        Return flag
    End Function
    Public Function fnrecuperacliente_ruc() As Boolean
        Dim flag As Boolean = False
        Try
            ObjVentaPasaje.sNU_DOCU_SUNAT = IIf(Me.txtruc.Text <> "", Me.txtruc.Text, "NULL")
            If ObjVentaPasaje.fnLISTA_GET_CLIENTE_RUC = True Then
                ' stel_pasajero = ObjVentaPasaje.stelefono_ruc
                Me.txtrazon_social.Text = ObjVentaPasaje.snombre_empresa
                lidpersona_ruc = ObjVentaPasaje.lidpersona_ruc
                flag = True
            Else
                lidpersona_ruc = 0
                flag = False
                ' MsgBox("No tiene documento de identidad", MsgBoxStyle.Information, "Revisar los datos")
            End If
        Catch ex As Exception
            flag = False
            Throw New Exception(ex.Message)
        End Try
        Return flag
    End Function
    Private Sub txtruc_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtruc.Validating
        Try
            Me.txtruc.Text = RellenoRight(11, Me.txtruc.Text)
            '
            If Me.txtruc.Text <> "00000000000" Then
                If Me.txtruc.Text.Length <> 11 Then
                    MsgBox("El Nº de Documento no es válido ", MsgBoxStyle.Information, "Seguridad Sistema")
                    e.Cancel = True
                End If
                ' Valida el nro de Ruc 
                If Not fnValidarRUC(Me.txtruc.Text.ToString) Then
                    MsgBox("No podra Realizar esta Operación El Nro de RUC no esta configurado")
                    e.Cancel = True
                End If
            Else
                Me.txtruc.Text = ""
                e.Cancel = False
            End If
        Catch ex As Exception
            '
        End Try
    End Sub
    Private Sub txthora_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txthora.Validating
        Try
            Dim shora As String
            '
            shora = CType(txthora.Text, String)
            shora = validar_hora_salida(shora)
            If shora = "" Then
                txthora.Text = shora
                txthora.Focus()
                Exit Sub
            End If
            '
            txthora.Text = shora
        Catch ex As Exception
            '
        End Try
    End Sub
    Private Sub txtnroasiento_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnroasiento.Leave
        If b_no_lee_campo = True Then
            Me.txttotal.Focus()
        End If
    End Sub
    Private Sub txtdescuento_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdescuento.Leave
        If b_no_lee_campo = True Then
            Me.txtmemo.Focus()
        End If
    End Sub
    Private Sub txtmemo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmemo.Leave
        If b_no_lee_campo = True Then
            Me.txttotal.Focus()
        End If
    End Sub
#Region "Funciones"
    Sub fn_grabar_boleto()
        Dim smensaje As String
        Dim lnromensaje As Long
        ' Validar los campos que son principales         
        Dim MyObligatorios As Object() = {Me.txtidunidadagencia, Me.txttotal, Me.txtpasajero, Me.TXTSER_COMPROBANTE, Me.TXTNRO_COMPROBANTE, Me.txtidunidadagorigen.Text}
        Dim resp As DialogResult
        '
        '
        Try
            'If Me.txtcuenta.Visible = True Then
            '    If Me.txtcuenta.Text = "" Then
            '        MsgBox("Falta ingresar el ruc de la cuenta", MsgBoxStyle.Information, "Venta de Pasajes")
            '        Me.txtcuenta.Focus()
            '        Exit Sub
            '    End If
            'End If
            ' Valida serie y número del comprobante  
            If Me.TXTSER_COMPROBANTE.Text = "000" Then
                ' Dim resp As DialogResult = MessageBox.Show("La serie del comprobante es " & Me.TXTSER_COMPROBANTE.Text & " ¿Desea continuar? ", "Seguridad del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                resp = MessageBox.Show("La serie del comprobante es " & Me.TXTSER_COMPROBANTE.Text & " ¿Desea continuar? ", "Venta de Pasajes", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If resp = Windows.Forms.DialogResult.No Then
                    Me.TXTSER_COMPROBANTE.Focus()
                    Exit Sub
                End If
            End If
            If Me.TXTNRO_COMPROBANTE.Text = "0000000" Then
                resp = MessageBox.Show("El Nº el comprobante es " & Me.TXTNRO_COMPROBANTE.Text & " ¿Desea continuar? ", "Venta de Pasajes", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If resp = Windows.Forms.DialogResult.No Then
                    Me.TXTNRO_COMPROBANTE.Focus()
                    Exit Sub
                End If
            End If
            ' Valida la razón social del la empresa que se le otorga el credito 
            If Me.txtcuenta.Text <> "" And Me.txtcuenta.Text <> "0" And Me.txtrazon_social_cuenta.Visible = True Then
                If Me.txtrazon_social_cuenta.Text = "" Then
                    MsgBox("Falta ingresar la razón social de la cuenta", MsgBoxStyle.Information, "Venta de Pasajes")
                    Me.txtrazon_social_cuenta.Focus()
                    Exit Sub
                End If
            End If
            ' Validando recibo de caja  
            If Not validar_serie_recibo() Then
                Exit Sub
            End If
            If Not validar_serie_pasaje() Then
                Exit Sub
            End If
            '-- Validando que ingrese el RUC, cuando es crédito 
            If Me.Cmbformapago.SelectedValue = 2 Then  ' Forma de Pago - Credito 
                'If Me.txtcuenta.Text = "" Then   ' 20/03/2007
                '    ' if me.txtruc.Text = "" Then
                '    MessageBox.Show("Debe ingresar el RUC de la empresa que se le otorga el crédito", "Venta de Pasaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Me.txtcuenta.Focus()
                '    Exit Sub
                'End If
                'If Me.Cmbformapago.SelectedValue <> 1 Then   'Forma contado 
                '    MessageBox.Show("La forma de pago debe ser solo contado, cuando paga con tarjeta", "Venta de Pasaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Me.Cmbformapago.Focus()
                '    Exit Sub
                'End If
            End If
            '
            If cmbtarjeta.SelectedValue <> -666 Then
                If Me.Cmbformapago.SelectedValue <> 1 Then   'Forma contado 
                    MessageBox.Show("La forma de pago debe ser solo contado, cuando paga con tarjeta", "Venta de Pasaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Cmbformapago.Focus()
                    Exit Sub
                End If
            End If
            '
            If lscondicion <> "V" Then ' Cuando una boleta esta anulada, no ingresado 
                If Funciones.Validaciones(MyObligatorios) <> 0 Then
                    Exit Sub
                End If
                If Labboleto_ref.Visible = True Then
                    Dim MyObligatorios2 As Object() = {Me.txtdctoreferencia_serie, Me.txtdctoreferencia_nrodcto}
                    If Funciones.Validaciones(MyObligatorios2) <> 0 Then
                        Exit Sub
                    End If
                End If
                'If Me.labcodcuenta.Visible = True Then
                '    Dim MyObligatorios3 As Object() = {Me.txtcuenta}
                '    If Funciones.Validaciones(MyObligatorios3) <> 0 Then
                '        Exit Sub
                '    End If
                'End If
                If Me.txttotal.Text = "0.00" Or Me.txttotal.Text = "" Then
                    MsgBox("Falta ingresar el total del boleto", MsgBoxStyle.Information, "Venta Boleto")
                    Me.txttotal.Focus()
                    Exit Sub
                End If
            End If
            ObjVentaPasaje.icontrol = li_control
            If li_control = 1 Then
                If Me.cmbcondicion.SelectedValue <> 11 Then  'Cuando es devolución(11)  no debe ingresar 
                    If Not fnvalida_comprobante() Then
                        Exit Sub
                    End If
                End If
            End If
            If Me.txtidventa_pasaje.Text = "" Or IsDBNull(Me.txtidventa_pasaje.Text) = True Then
                ObjVentaPasaje.sidventa_pasaje = "null"
            Else
                ObjVentaPasaje.sidventa_pasaje = Me.txtidventa_pasaje.Text
            End If
            If IsDBNull(lidpersona) = True Or lidpersona = 0 Or lidpersona = -666 Then
                ObjVentaPasaje.sidpersona_dni = "null"
            Else
                ObjVentaPasaje.sidpersona_dni = CType(lidpersona, String)
            End If
            'ledad As Integer
            ' Public scodigo_cuenta
            If Me.txtedad.Text = "" Then
                ObjVentaPasaje.ledad = -666
            Else
                ObjVentaPasaje.ledad = CType(Me.txtedad.Text, Integer)
            End If
            If Me.txtcuenta.Text = "" Then
                ObjVentaPasaje.scodigo_cuenta = "null"
            Else
                ObjVentaPasaje.scodigo_cuenta = Me.txtcuenta.Text
            End If
            If Me.txtpasajero.Text = "" Or IsDBNull(Me.txtpasajero.Text) Then
                ObjVentaPasaje.sapellidos_nombre_dni = "null"
            Else
                ObjVentaPasaje.sapellidos_nombre_dni = Me.txtpasajero.Text
            End If
            If Me.Txtdni.Text = "" Then
                ObjVentaPasaje.snrodctoidentidad_dni = "null"
            Else
                ObjVentaPasaje.snrodctoidentidad_dni = Me.Txtdni.Text
            End If
            'ObjVentaPasaje.lidtipo_comprobante = Int(ObjVentaPasaje.coll_documento(Me.cmbtipocomprobante.SelectedIndex.ToString))
            ObjVentaPasaje.lidtipo_comprobante = Int(Me.cmbtipocomprobante.SelectedValue)
            ObjVentaPasaje.sserie_comprobante = Me.TXTSER_COMPROBANTE.Text
            ObjVentaPasaje.lidcondicion_boleto = Me.cmbcondicion.SelectedValue  'Int(ObjVentaPasaje.coll_condicion(Me.cmbcondicion.SelectedIndex.ToString))
            ObjVentaPasaje.snro_comprobante = Me.TXTNRO_COMPROBANTE.Text
            If Me.txtruc.Text <> "" Then
                If IsDBNull(lidpersona_ruc) = True Or lidpersona_ruc = 0 Then
                    ObjVentaPasaje.sidpersona_empresa = "null"
                Else
                    ObjVentaPasaje.sidpersona_empresa = CType(lidpersona_ruc, String)
                End If
                ObjVentaPasaje.srazon_social = Me.txtrazon_social.Text
                ObjVentaPasaje.sruc = Me.txtruc.Text
                '
            Else
                ObjVentaPasaje.sidpersona_empresa = "null"
                ObjVentaPasaje.srazon_social = "null"
                ObjVentaPasaje.sruc = "null"
            End If
            If cmbtipocomprobante.SelectedValue = 16 Or cmbtipocomprobante.SelectedValue = 17 Or cmbtipocomprobante.SelectedValue = 18 Then
                '16 RECIBOS DE CAJA CLASICO 
                '17 RECIBOS DE CAJA PREMIER
                '18 RECIBOS DE CAJA PRESIDENCIAL 
                '
                ' Debe buscar documento asociado 
                'RellenoRight(inro_Digitos_SerieVentas, strNroDoc(0))
                ObjVentaPasaje.sserie_comprobante_ref = RellenoRight(inro_Digitos_SerieVentas, Me.txtdctoreferencia_serie.Text)
                ObjVentaPasaje.snro_comprobante_ref = RellenoRight(inro_Digitos_Ventas, Me.txtdctoreferencia_nrodcto.Text)
            Else
                ObjVentaPasaje.sserie_comprobante_ref = "null"
                ObjVentaPasaje.snro_comprobante_ref = "null"
            End If
            If ObjVentaPasaje.sserie_comprobante_ref = "null" And Me.txtdctoreferencia_serie.Text <> "" Then
                ObjVentaPasaje.sserie_comprobante_ref = RellenoRight(inro_Digitos_SerieVentas, Me.txtdctoreferencia_serie.Text)
                ObjVentaPasaje.snro_comprobante_ref = RellenoRight(inro_Digitos_Ventas, Me.txtdctoreferencia_nrodcto.Text)
            End If
            ObjVentaPasaje.lidforma_pago = Me.Cmbformapago.SelectedValue  ' -666 '1 ' Siempre va hacer contado 
            ObjVentaPasaje.lidtipo_moneda = -666 '1 'Por ahora va hacer Nuevo Soles 
            ObjVentaPasaje.d_igv = IGV  ' Igv 
            If lscondicion <> "V" Then
                ObjVentaPasaje.lidtipo_operacion = 1 ' Venta Normal 
            Else
                ObjVentaPasaje.lidtipo_operacion = -666
            End If
            If Me.txtnroasiento.Text = "" Then
                ObjVentaPasaje.lnro_asiento = -666 'me quede aqui
            Else
                ObjVentaPasaje.lnro_asiento = Me.txtnroasiento.Text
            End If
            ObjVentaPasaje.dmonto_base = 0
            ObjVentaPasaje.dmonto_penalidad = 0
            ObjVentaPasaje.dmonto_descuento = 0
            ObjVentaPasaje.dmonto_recargo = 0
            '
            If Me.txtdescuento.Text = "" Then
                ObjVentaPasaje.dporc_descuento = 0
            Else
                ObjVentaPasaje.dporc_descuento = CType(Me.txtdescuento.Text, Double)
            End If
            ObjVentaPasaje.iidagencias_venta = dtoUSUARIOS.m_iIdAgencia  ' Agencia de Venta
            ObjVentaPasaje.iidagencias_origen = Me.cmbagencia_origen.SelectedValue
            '
            If Me.cmbagenciadestino.SelectedValue <= 0 Or IsDBNull(Me.cmbagenciadestino.SelectedValue) = True Then
                ObjVentaPasaje.iIDAGENCIAS_DESTINO = -666
            Else
                ObjVentaPasaje.iIDAGENCIAS_DESTINO = Me.cmbagenciadestino.SelectedValue  'Int(ObjVentaPasaje.coll_agencia(Me.cmbagenciadestino.SelectedIndex.ToString))
            End If
            '
            ObjVentaPasaje.lidunidad_agencia_ori = CType(txtidunidadagorigen.Text, Integer) ' 'CType(dtoUSUARIOS.m_idciudad, Integer)    ' LONG 
            If lidUnidadAgencias_destino < 0 Or IsDBNull(lidUnidadAgencias_destino) = True Then
                ObjVentaPasaje.lidunidad_agencia_des = -666
            Else
                ObjVentaPasaje.lidunidad_agencia_des = CType(lidUnidadAgencias_destino, Integer) 'LONG 
            End If
            ObjVentaPasaje.liestado_registro = 1 ' Siempre Activo 
            ObjVentaPasaje.sip = dtoUSUARIOS.IP
            ObjVentaPasaje.sfecha_emision = CType(Me.dtp_fec_emision.Value, String)
            ObjVentaPasaje.sfecha_viaje = CType(Me.DTPfec_viaje.Value, String)
            If Me.txthora.Text = "" Then
                ObjVentaPasaje.shora_salida = "null"
            Else
                ObjVentaPasaje.shora_salida = CType(Me.txthora.Text, String)
            End If
            If Me.txtmemo.Text = "" Then
                ObjVentaPasaje.smemo = "null"
            Else
                ObjVentaPasaje.smemo = Me.txtmemo.Text
            End If
            ObjVentaPasaje.dmonto_total = CType(Me.txttotal.Text, Double)
            ObjVentaPasaje.lidusuario_personal = dtoUSUARIOS.IdLogin
            ObjVentaPasaje.lidrol_usuario = dtoUSUARIOS.m_iIdRol
            ObjVentaPasaje.iidtarjetas = Me.cmbtarjeta.SelectedValue
            ' 
            If Me.txtrazon_social_cuenta.Text = "" Then
                ObjVentaPasaje.srazon_social_cta = "null"
            Else
                ObjVentaPasaje.srazon_social_cta = Me.txtrazon_social_cuenta.Text
            End If
            If Me.chk_es_fecha_abierta.Checked = True Then
                ObjVentaPasaje.ll_es_fecha_abierta = 1
                ObjVentaPasaje.sfecha_viaje = "null"
            Else
                ObjVentaPasaje.ll_es_fecha_abierta = 0
            End If
            '
            If ObjVentaPasaje.fngraba_pasaje = True Then
                'datahelper
                'lnromensaje = CType(ObjVentaPasaje.rst_mensaje_oracle.Fields.Item(0).Value, Long)   ' Se observara si necesita algun mensaje  
                'smensaje = CType(ObjVentaPasaje.rst_mensaje_oracle.Fields.Item(1).Value, String)   ' Se observara si necesita algun mensaje  
                lnromensaje = CType(ObjVentaPasaje.rst_mensaje_oracle.Rows(0).Item(0), Long)   ' Se observara si necesita algun mensaje  
                smensaje = CType(ObjVentaPasaje.rst_mensaje_oracle.Rows(0).Item(1), String)   ' Se observara si necesita algun mensaje  
                If lnromensaje <> 0 Then
                    MsgBox(smensaje, MsgBoxStyle.Information, "Venta de Pasaje")
                    Exit Sub
                Else
                    If li_control <> 2 Then
                        Dim lidtipo_documento As Integer
                        ' Verifica si cambio el correlativo para incrementar 16/06/2007
                        If Me.TXTNRO_COMPROBANTE.Text = snro_comprobante Then 'Incremente el correlativo 
                            lidtipo_documento = cmbtipocomprobante.SelectedValue
                            ' Incrementar la boleta del comprobante
                            ObjVentaPasaje.fnIncrementarNroDoc(5)  'Mod 16/06/2007  
                            If ObjVentaPasaje.fnNroDocumento(5) = True Then
                                TXTSER_COMPROBANTE.Text = RellenoRight(inro_Digitos_SerieVentas, ObjVentaPasaje.Serie)
                                TXTNRO_COMPROBANTE.Text = RellenoRight(inro_Digitos_Ventas, ObjVentaPasaje.NroDoc)
                                ds_serie_comprobante_new = Me.TXTSER_COMPROBANTE.Text
                                ds_nro_comprobante_new = Me.TXTNRO_COMPROBANTE.Text
                                snro_comprobante = Me.TXTNRO_COMPROBANTE.Text
                            End If
                        Else
                            Me.TXTNRO_COMPROBANTE.Text = snro_comprobante
                        End If
                    End If
                End If
            End If
            '                
            limpiar_variables()
            If li_control = 1 Then
                If cmbtipocomprobante.SelectedValue = 4 Or cmbtipocomprobante.SelectedValue = 16 Or cmbtipocomprobante.SelectedValue = 17 Or cmbtipocomprobante.SelectedValue = 18 Then
                    Me.txtidunidadagorigen.Focus()
                Else
                    Me.txtidunidadagencia.Focus()
                    lee_focus = True
                End If
            Else
                Me.RBPasaje.Checked = True
                dtGridViewControl_pasaje.Columns.Clear()
                fnLoadGrid()
                SelectMenu(0)
            End If
            ' 
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Sub limpiar_variables()
        Try
            lidpersona = 0
            Me.txtidventa_pasaje.Text = ""
            Me.txtpasajerobusqueda.Text = ""
            Me.txtpasajero.Text = ""
            Me.Txtdni.Text = ""
            '
            'Debe quedarse con el último ingreso 
            'cmbtipocomprobante.SelectedValue = 12 ' Siempre vuelve al servicio presidencial  
            '
            'Me.TXTSER_COMPROBANTE.Text = ""
            'Me.TXTNRO_COMPROBANTE.Text = ""
            Me.txtruc.Text = ""
            Me.txtrazon_social.Text = ""
            'Me.txtdctoreferencia_serie.Text = ""  --- No se debe limpiar la serie - 16/06/2007
            Me.txtdctoreferencia_nrodcto.Text = ""
            Me.txtnroasiento.Text = ""
            lidUnidadAgencias_destino = 0
            ' Me.dtp_fec_emision.Value = dtoUSUARIOS.dfecha_sistema  
            Me.DTPfec_viaje.Value = dtoUSUARIOS.dfecha_sistema
            Me.txtmemo.Text = ""
            Me.cmbcondicion.SelectedValue = 2 ' Siempre vuelve a la condición de efectivo 
            '
            Me.txtedad.Text = ""
            Me.txtcuenta.Text = ""
            Me.txtidunidadagencia.Text = ""
            Me.txtiWinDestino.Text = ""
            Me.txthora.Text = ""
            Me.txttotal.Text = "0.00"
            Me.txtdescuento.Text = ""
            Me.cmbagenciadestino.SelectedValue = -1
            ' Recupera origen  
            recupera_origen(dtoUSUARIOS.m_idciudad)
            'Me.cmbagenciadestino.SelectedIndex = -1
            Me.cmbtarjeta.SelectedValue = -666
            Cmbformapago.SelectedValue = 1 'Por defecto 1 Efectivo
            '
            ds_serie_comprobante_old = ""
            ds_nro_comprobante_old = ""
            '
            Me.txtcuenta.Text = ""
            Me.txtrazon_social_cuenta.Text = ""
            '07/03/2008 
            Me.chk_es_fecha_abierta.Checked = False
            Me.DTPfec_viaje.Enabled = True
            Me.DTPfec_viaje.Visible = True
            '
            Me.txtdctoreferencia_serie.Text = ""
            Me.txtdctoreferencia_nrodcto.Text = ""
            Me.txtdctoreferencia_serie.Visible = False
            Me.txtdctoreferencia_nrodcto.Visible = False
        Catch ex As Exception
            '
        End Try
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If
        ' Salir del sistema 
        If msg.WParam.ToInt32() = CInt(Keys.Escape) Then
            Me.Close()
        End If
        If msg.WParam.ToInt32() = CInt(Keys.F5) Then
            ' Grabar 
            'cambio tecla funcion
            If btngrabar.Enabled Then
                fn_grabar_boleto()
            End If
        End If
        If msg.WParam.ToInt32() = CInt(Keys.F1) Then
            b_no_lee_campo = False
            Me.cmbtipocomprobante.Focus()  ' Tipo de comprobante 
        End If
        If msg.WParam.ToInt32() = CInt(Keys.F10) Then
            b_no_lee_campo = False
            Me.txtiWinDestino.Focus()   ' Destino 
        End If
        If msg.WParam.ToInt32() = CInt(Keys.F11) Then
            b_no_lee_campo = False
            Me.cmbcondicion.Focus()   ' Condición de Pago 
        End If
        If msg.WParam.ToInt32() = CInt(Keys.F2) Then
            b_no_lee_campo = False
            Me.txtruc.Focus()   ' Ruc 
        End If
        If msg.WParam.ToInt32() = CInt(Keys.F4) Then
            b_no_lee_campo = False
            Me.txtiWinorigen.Focus()   ' 
        End If
        If msg.WParam.ToInt32() = CInt(Keys.Shift + Keys.Tab) Then
            b_no_lee_campo = False
        End If
    End Function
    ' Pertenece a la function ProcessCmdKey 
    '        Dim blnCancel As Boolean = True
    '        Dim flat As Boolean = True
    '        Try
    '            Dim var As Integer = msg.WParam.ToInt32

    '            If msg.WParam.ToInt32 = Keys.Enter Then
    '                If Me.dtGridViewBultos.Focused = True Then
    '                    'fnTarifario()
    '                    SendKeys.Send("{Tab}")
    '                ElseIf txtNroSerieDoc.Focused = True Then
    '                    objControlFacturasBol.iControl = 2
    '                    fnBuscarFacturas()
    '                ElseIf txtClienteDNIRUC.Focused = True Then
    '                    If txtClienteDNIRUC.Text <> "" Then
    '                        objControlFacturasBol.iControl = 3
    '                        fnBuscarFacturas()
    '                    Else
    '                        SendKeys.Send("{Tab}")
    '                    End If

    '                ElseIf txtDocCliente_Remitente.Focused = True Then
    '                    If txtDocCliente_Remitente.Text <> "" Then
    '                        CONTROL = 2
    '                        objGuiaEnvio.iIDPERSONA = 0
    '                        If fnBuscarCliente() = True Then
    '                            txtCliente_Destinatario.Focus()
    '                            txtCliente_Destinatario.SelectAll()
    '                        Else
    '                            SendKeys.Send("{Tab}")
    '                        End If
    '                    Else
    '                        SendKeys.Send("{Tab}")
    '                    End If
    '                    'If BuscarClientesGuia_Envio() = True Then
    '                    '    SendKeys.Send("{Tab}")
    '                    'End If
    '                ElseIf txtContactoRemitente.Focused = True Then
    '                    'MsgBox("Exe...")
    '                    Dim indexof As Integer = 0
    '                    txtDNIContacto.Text = ""
    '                    indexof = IIf(iWinContacto_Remitente.IndexOf(txtContactoRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtContactoRemitente.Text), -1)
    '                    ObjVentaCargaContado.v_IDPERSONA_ORIGEN = -1
    '                    If indexof >= 0 Then
    '                        ObjVentaCargaContado.v_IDPERSONA_ORIGEN = Int(coll_Nombres_Remitente(indexof.ToString))
    '                        If indexof <= iWinPerosaDNI_Remite.Count Then
    '                            txtDNIContacto.Text = iWinPerosaDNI_Remite.Item(indexof)
    '                        End If
    '                    End If
    '                    SendKeys.Send("{Tab}")
    '                    '--------------------------------------------------------------------------
    '                ElseIf txtCliente_Destinatario.Focused = True Then
    '                    'MsgBox("Exe...")
    '                    Dim indexof As Integer = 0
    '                    txtDNIDestinatario.Text = ""
    '                    indexof = IIf(iWinContacto_Destinatario.IndexOf(txtCliente_Destinatario.Text) >= 0, iWinContacto_Destinatario.IndexOf(txtCliente_Destinatario.Text), -1)
    '                    ObjVentaCargaContado.v_IDCONTACTO_DESTINO = -1
    '                    If indexof >= 0 Then
    '                        ObjVentaCargaContado.v_IDCONTACTO_DESTINO = Int(coll_Nombres_Destinatario(indexof.ToString))
    '                        If indexof <= iWinPerosaDNI_Destino.Count Then
    '                            txtDNIDestinatario.Text = iWinPerosaDNI_Destino.Item(indexof)
    '                        End If
    '                    End If
    '                    SendKeys.Send("{Tab}")
    '                Else
    '                    SendKeys.Send("{Tab}")
    '                End If

    '            ElseIf msg.WParam.ToInt32 = Keys.F1 Then
    '                cmbTipo_Entrega.Focus()
    '            ElseIf msg.WParam.ToInt32 = Keys.F2 Then
    '                txtDocCliente_Remitente.Focus()
    '            ElseIf msg.WParam.ToInt32 = Keys.Escape Then
    '                If MsgBox("Esta Seguro que Quiere cancelar esta Operacion...?", MsgBoxStyle.YesNoCancel, "Seguridad Sistema") = MsgBoxResult.Yes Then
    '                    fnNUEVO()
    '                End If
    '            ElseIf msg.WParam.ToInt32 = Keys.F3 Then
    '                fnNUEVO()
    '                SelectMenu(1)
    '            ElseIf msg.WParam.ToInt32 = Keys.F4 Then
    '                txtCliente_Destinatario.Focus()
    '                txtCliente_Destinatario.SelectAll()

    '                'txtDNIDestinatario.Focus()
    '                'txtDNIDestinatario.SelectAll()

    '            ElseIf msg.WParam.ToInt32 = Keys.F5 Then
    '                If TabMante.SelectedIndex = 0 Then
    '                    SendKeys.Send("{Tab}")
    '                    GoTo FINAL
    '                End If
    '                If control_venta = True Then
    '                    fnNUEVO()
    '                End If
    '                If TipoComprobante = 1 Then
    '                    If txtDocCliente_Remitente.Text.ToString.Length = 11 Then
    '                        If fnValidarRUC(txtDocCliente_Remitente.Text.ToString) = False Then
    '                            MsgBox("No puede realizar esta Operacion de Factura, el Nro de Docuemnto es Invalido")
    '                        End If
    '                    Else
    '                        MsgBox("No puede realizar esta Operacion de Factura, el Nro de Docuemnto es Invalido", MsgBoxStyle.Information, "Seguriadad Sistema")
    '                    End If
    '                End If
    '                If txtCliente_Remitente.Text = "" Then
    '                    MsgBox("No Puede Realizar esta Operacion no tiene Cliente remitente ...", MsgBoxStyle.Information, "Seguridad Sistema")
    '                    txtCliente_Remitente.Focus()
    '                    Return False
    '                End If
    '                If txtCliente_Destinatario.Text = "" Then
    '                    MsgBox("No Puede Realizar esta Operacion no tiene Cliente Destinatario ...", MsgBoxStyle.Information, "Seguridad Sistema")
    '                    txtCliente_Destinatario.Focus()
    '                    Return False
    '                End If

    '                Dim varDescuento As Integer = IIf(txtPorcernt_Descuento.Text <> "", txtPorcernt_Descuento.Text, 0)

    '                If Val(txtCosto_Total.Text) <= 0 And varDescuento <> 100 Then
    '                    MsgBox("No Puede Realizar esta Operacion no tiene monto afecto...,No Tiene el Descuento Apropiado", MsgBoxStyle.Information, "Seguridad Sistema")
    '                    Return False
    '                End If

    '                If fnGrabar() = True Then
    '                    ObjVentaCargaContado.fnIncrementarNroDoc(TipoComprobante)
    '                    If ObjVentaCargaContado.fnNroDocuemnto(2) = True Then
    '                        txtSERIE.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
    '                        txtNroDocFACBOL.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
    '                    Else
    '                        MsgBox("No podra Realizar esta Operacion El Nro de Factura/Boleta no esta configurado")
    '                    End If
    '                End If
    '            ElseIf msg.WParam.ToInt32 = Keys.F7 Then
    '                dtGridViewBultos.Focus()
    '                dtGridViewBultos.CurrentCell = dtGridViewBultos.Rows(0).Cells(2)
    '                dtGridViewBultos.Rows(0).Cells(2).Selected = True

    '            ElseIf msg.WParam.ToInt32 = Keys.F6 Then

    '                If txtDocCliente_Remitente.Focused = True Or txtCliente_Remitente.Focused = True Then
    '                    If txtCliente_Remitente.Text <> "" Then
    '                        If fnMantenimienteCliente(1, txtDocCliente_Remitente, txtCliente_Remitente, txtDireccionRemitente, 1, 1) = True Then

    '                        End If
    '                    End If
    '                End If

    '                If txtContactoRemitente.Focused = True Or txtDNIContacto.Focused = True Then
    '                    If txtContactoRemitente.Text <> "" Then
    '                        If fnMantenimienteCliente(2, txtDNIContacto, txtContactoRemitente, txtDireccionRemitente, 1, 2) = True Then

    '                        End If
    '                    End If
    '                End If
    '                If txtCliente_Destinatario.Focused = True Or txtDNIDestinatario.Focused = True Then
    '                    If txtCliente_Destinatario.Text <> "" Then
    '                        If fnMantenimienteCliente(3, txtDNIDestinatario, txtCliente_Destinatario, txtDireccionDestinatario, 1, 2) = True Then

    '                        End If
    '                    End If
    '                End If
    '                '    txtCantidad_Peso.Focus()
    '                'txtCantidad_Peso.SelectAll()

    '            ElseIf msg.WParam.ToInt32 = Keys.F8 Then
    '                txtPorcernt_Descuento.Focus()
    '                txtPorcernt_Descuento.SelectAll()
    '            ElseIf msg.WParam.ToInt32 = Keys.F9 Then
    '                'txtNroDocFACBOL.Focus()
    '                'txtNroDocFACBOL.SelectAll()

    '                txtCosto_Total.Focus()
    '                txtCosto_Total.SelectAll()
    '            ElseIf msg.WParam.ToInt32 = Keys.F10 Then
    '                txtiWinDestino.Focus()
    '                txtiWinDestino.SelectAll()
    '            ElseIf msg.WParam.ToInt32 = Keys.F11 Then
    '                cmbTipoPago.Focus()
    '                cmbTipoPago.SelectAll()
    '            ElseIf msg.WParam.ToInt32 = Keys.F12 Then
    '                If MsgBox("Esta Seguro que quiere salir de ventas al contado ", MsgBoxStyle.YesNoCancel, "Seguridad Sistema") = MsgBoxResult.Yes Then
    '                    Close()
    '                End If
    '            Else
    '                flat = MyBase.ProcessCmdKey(msg, KeyData)
    '            End If
    'FINAL:
    '        Catch ex As Exception
    '            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
    '        End Try
    '        Return flat
    '    End Function
#End Region
    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        fn_grabar_boleto()
    End Sub
    Private Sub txtidunidadagencia_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtidunidadagencia.Leave
        Dim l_idunidad_agencia As Integer
        'datahelper
        'Dim l_rstunidad_agencia As New ADODB.Recordset
        Dim l_rstunidad_agencia As DataTable
        Try
            If b_no_lee_campo = True Then
                If fn_validar_origen_destino() = False Then
                    Exit Sub
                End If
                If txtidunidadagencia.Text <> "" Then
                    l_idunidad_agencia = CType(txtidunidadagencia.Text, Integer)
                    '
                    l_rstunidad_agencia = ObjVentaPasaje.fnGetunidadagencia(l_idunidad_agencia)
                    'If l_rstunidad_agencia.BOF = False And l_rstunidad_agencia.EOF = False Then
                    'Me.txtiWinDestino.Text = l_rstunidad_agencia.Fields(1).Value ' Recupera la ciudad 
                    If l_rstunidad_agencia.Rows.Count > 0 Then
                        Me.txtiWinDestino.Text = l_rstunidad_agencia.Rows(0).Item(1) ' Recupera la ciudad 
                        ' Recupera las agecias asociadas 
                        If fn_recupera_agencias(l_idunidad_agencia, False) = True Then
                            lidUnidadAgencias_destino = l_idunidad_agencia
                            Me.dtp_fec_emision.Focus()
                        Else
                            Me.txtidunidadagencia.Focus()
                        End If
                    Else
                        Me.txtiWinDestino.Text = ""
                        Me.txtidunidadagencia.Text = ""
                        Me.txtidunidadagencia.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Function fn_recupera_agencias(ByVal lidUnidadAgencias_destino As Integer, ByVal lb_origen As Boolean) As Boolean
        Try
            Dim bencontro As Boolean = False
            Dim agencia As Integer
            If lidUnidadAgencias_destino > 0 Then
                ObjVentaPasaje.fnGetAgencias(lidUnidadAgencias_destino)
                'datahelper
                'If ObjVentaPasaje.rst_agencias.BOF = False And ObjVentaPasaje.rst_agencias.EOF = False Then
                If ObjVentaPasaje.rst_agencias.Rows.Count > 0 Then
                    If lidUnidadAgencias_destino = 5100 Then   'Solo el caso de Lima 
                        agencia = 51  'Por defecto toma JP 
                    Else
                        'datahelper
                        'agencia = Int(ObjVentaPasaje.rst_agencias.Fields(0).Value)
                        agencia = Int(ObjVentaPasaje.rst_agencias.Rows(0).Item(0))
                    End If
                    '
                    If lb_origen Then
                        Me.cmbagencia_origen.SelectedValue = agencia
                    Else
                        Me.cmbagenciadestino.SelectedValue = agencia
                    End If
                    bencontro = True
                Else
                    MsgBox("No existe agencia asociada a la ciudad", MsgBoxStyle.Information, "Venta de Pasajes")
                    Me.txtiWinDestino.Text = ""
                    Me.txtidunidadagencia.Text = ""
                    bencontro = False
                End If
            End If
            Return bencontro
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub cmbcondicion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcondicion.SelectedIndexChanged
        Dim drcondicion As DataRowView
        Dim l_idcondicion_boleto As Long
        Dim s_cuenta As String
        Dim l_idtarjeta As String
        Try
            b_no_lee_campo = False
            If bno_lee_condicion Then
                If cmbcondicion.SelectedIndex >= 0 Then
                    b_leecuenta = True
                    drcondicion = dvcondicion.Item(cmbcondicion.SelectedIndex)
                    lscondicion = CType(drcondicion("ind_asocia_cuenta"), String)
                    l_idcondicion_boleto = CType(drcondicion("idcondicion_boleto"), Long)
                    s_cuenta = IIf(IsDBNull(drcondicion("cuenta")) = True, "", "C")
                    l_idtarjeta = IIf(IsDBNull(drcondicion("idtarjeta")) = True, -666, drcondicion("idtarjeta"))
                    '
                    Labboleto_ref.Visible = False
                    If Not (li_control = 2 And Me.txtdctoreferencia_serie.Text <> "") Then
                        txtdctoreferencia_serie.Visible = False
                        txtdctoreferencia_nrodcto.Visible = False
                        txtdctoreferencia_serie.Text = ""
                        txtdctoreferencia_nrodcto.Text = ""
                    End If
                    Select Case lscondicion
                        Case "S"

                        Case "D"
                            Labboleto_ref.Visible = True
                            txtdctoreferencia_serie.Visible = True
                            txtdctoreferencia_nrodcto.Visible = True
                            If cmbcondicion.SelectedValue = 8 Then
                                Me.txtdctoreferencia_serie.Text = "200"  ' Se mantiene fijo por Fiscalización 
                                Me.txtdctoreferencia_nrodcto.Focus()
                            Else
                                Me.txtdctoreferencia_serie.Text = "110"  ' En la mayoria de casos es 110
                                'Me.txtdctoreferencia_serie.Focus()
                                Me.txtdctoreferencia_nrodcto.Focus()
                            End If
                    End Select
                    '
                    If s_cuenta = "C" Then  ' 
                        Me.Cmbformapago.SelectedValue = 2   ' Credito 
                        Me.Cmbformapago.Enabled = False
                        ' Modificado 20/03/2007
                        Me.Labrazon_social_cta.Visible = True
                        Me.txtrazon_social_cuenta.Visible = True
                        Me.labcodcuenta.Visible = True
                        Me.txtcuenta.Visible = True
                    Else
                        Me.Cmbformapago.SelectedValue = 1   ' Contado 
                        Me.Cmbformapago.Enabled = True
                        ' Modificado 20/03/2007
                        Me.Labrazon_social_cta.Visible = False
                        Me.txtrazon_social_cuenta.Visible = False
                        Me.labcodcuenta.Visible = False
                        Me.txtcuenta.Visible = False
                        '
                        Me.Labrazon_social_cta.Text = ""
                        Me.txtrazon_social_cuenta.Text = ""
                        Me.labcodcuenta.Text = ""
                        Me.txtcuenta.Text = ""
                        '
                    End If
                    '
                    Me.cmbtarjeta.SelectedValue = l_idtarjeta
                    '

                    If l_idcondicion_boleto = 10 Then ' Anulación 
                        Me.txttotal.Text = 0
                    End If
                End If
                If Me.txtcuenta.Visible = True Then
                    If Me.txtdctoreferencia_nrodcto.Visible = True Then
                        Me.txtdctoreferencia_nrodcto.Focus()
                    Else
                        Me.txtcuenta.Focus()
                    End If
                End If
            End If
            b_no_lee_campo = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub TXTNRO_COMPROBANTE_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTNRO_COMPROBANTE.Leave
        Dim b_ir_a_serie As Boolean = False
        Try
            '
            Me.TXTNRO_COMPROBANTE.Text = RellenoRight(inro_Digitos_Ventas, Me.TXTNRO_COMPROBANTE.Text)
            '
            If b_no_lee_campo = True Then
                ' Valida documento 
                Select Case li_control
                    Case 1
                        If Me.cmbcondicion.SelectedValue <> 11 Then 'Solo para el caso de devolución debe permitir 
                            If Me.TXTNRO_COMPROBANTE.Text <> ds_nro_comprobante_old Then
                                ' Validar que el comprobante del Documento existe 
                                If Not fnvalida_comprobante() Then
                                    Me.TXTSER_COMPROBANTE.Text = ds_serie_comprobante_new
                                    Me.TXTNRO_COMPROBANTE.Text = ds_nro_comprobante_new
                                    b_ir_a_serie = True
                                End If
                            End If
                        End If
                    Case 2
                        If Me.TXTNRO_COMPROBANTE.Text <> ds_nro_comprobante_old Then
                            ' Validar que el comprobante del Documento existe 
                            If Not fnvalida_comprobante() Then
                                Me.TXTSER_COMPROBANTE.Text = ds_serie_comprobante_old
                                Me.TXTNRO_COMPROBANTE.Text = ds_nro_comprobante_old
                                b_ir_a_serie = True
                            End If
                        End If
                End Select
                If b_ir_a_serie Then
                    b_no_lee_campo = False
                    db_comprobante_nolee = False
                    Me.TXTSER_COMPROBANTE.Focus()
                    Exit Sub
                End If
                '
                If Labboleto_ref.Visible = True Then
                    Me.txtdctoreferencia_serie.Focus()
                Else
                    Me.txtidunidadagencia.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub dtp_fec_emision_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fec_emision.Leave
        Try
            If b_no_lee_campo = True Then
                If Me.cmbcondicion.Focused = True Then
                    b_no_lee_campo = False
                    Exit Sub
                End If
                If labcodcuenta.Visible = True Then
                    Me.txtcuenta.Focus()
                Else
                    Me.Txtdni.Focus()
                End If
            End If
            Me.DTPfec_viaje.Value = Me.dtp_fec_emision.Value
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub txtdctoreferencia_nrodcto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdctoreferencia_nrodcto.Leave
        Dim ls_codigo_cuenta As String
        Try
            Me.txtdctoreferencia_nrodcto.Text = RellenoRight(inro_Digitos_Ventas, Me.txtdctoreferencia_nrodcto.Text)
            If Me.txtdctoreferencia_serie.Text = "100" Then
                ObjVentaPasaje.snro_comprobante_ref = Me.txtdctoreferencia_nrodcto.Text
                If ObjVentaPasaje.fn_getcodigo_cuenta = True Then
                    If IsDBNull(ObjVentaPasaje.rst_codigo_cuenta_corriente.Rows(0).Item("RUC")) = False Then
                        ls_codigo_cuenta = CType(ObjVentaPasaje.rst_codigo_cuenta_corriente.Rows(0).Item("RUC"), String)
                        Me.txtcuenta.Text = ls_codigo_cuenta
                    Else
                        MsgBox("No se encontro ninguna agencia asociada con el documento de referencia", MsgBoxStyle.Information, "Venta de Pasajes")
                        Me.txtdctoreferencia_nrodcto.Text = ""
                        Me.txtdctoreferencia_nrodcto.Focus()
                        Exit Sub
                    End If
                Else
                    MsgBox("No se encontro ninguna agencia asociada con el documento de referencia", MsgBoxStyle.Information, "Venta de Pasajes")
                    Me.txtdctoreferencia_nrodcto.Text = ""
                    Me.txtdctoreferencia_nrodcto.Focus()
                    Exit Sub
                End If
            End If
            Me.txtidunidadagencia.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Public Function fnLoadGrid() As Boolean
        Try
            With dtGridViewControl_pasaje
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                '.RowHeadersWidth = 10
                .RowHeadersVisible = True
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .AllowUserToOrderColumns = True
            End With

            Dim colfecha_emision As New DataGridViewTextBoxColumn
            With colfecha_emision '0
                .DisplayIndex = 0
                .DataPropertyName = "fecha_emision"
                .Name = "fecha_emision"
                .HeaderText = "Fecha emisión"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(colfecha_emision)
            '
            Dim colnro_comprobante As New DataGridViewTextBoxColumn
            With colnro_comprobante '1
                .DisplayIndex = 1
                .DataPropertyName = "nro_comprobante"
                .Name = "nro_comprobante"
                .HeaderText = "Nº Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(colnro_comprobante)
            '
            Dim colorigen As New DataGridViewTextBoxColumn
            With colorigen  '2
                .DisplayIndex = 2
                .DataPropertyName = "origen"
                .Name = "origen"
                .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(colorigen)
            '
            Dim coldestino As New DataGridViewTextBoxColumn
            With coldestino ' 3
                .DisplayIndex = 3
                .DataPropertyName = "destino"
                .Name = "destino"
                .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(coldestino)
            '
            Dim colagenciaventa As New DataGridViewTextBoxColumn
            With colagenciaventa ' 4
                .DisplayIndex = 4
                .DataPropertyName = "agencia_venta"
                .Name = "agencia_venta"
                .HeaderText = "Ag Venta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(colagenciaventa)
            '
            Dim coltotal As New DataGridViewTextBoxColumn
            With coltotal ' 5
                .DisplayIndex = 5
                .DataPropertyName = "monto_total"
                .Name = "monto_total"
                .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(coltotal)
            '
            Dim colcondicion As New DataGridViewTextBoxColumn
            With colcondicion '6 
                .DisplayIndex = 6
                .DataPropertyName = "tipo"
                .Name = "tipo"
                .HeaderText = "Condición"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(colcondicion)
            '
            Dim colTipo_Comprobante As New DataGridViewTextBoxColumn
            With colTipo_Comprobante  '7
                .DisplayIndex = 7
                .DataPropertyName = "Tipo_Comprobante"
                .Name = "Tipo_Comprobante"
                .HeaderText = "Tipo Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(colTipo_Comprobante)

            Dim colfecha_viaje As New DataGridViewTextBoxColumn
            With colfecha_viaje '8
                .DisplayIndex = 8
                .DataPropertyName = "fecha_viaje"
                .Name = "fecha_viaje"
                .HeaderText = "Fecha Viaje"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(colfecha_viaje)
            '
            Dim colfecha_registro As New DataGridViewTextBoxColumn
            With colfecha_registro '9
                .DisplayIndex = 9
                .Name = "fecha_registro"
                .DataPropertyName = "fecha_registro"
                .HeaderText = "Fecha registro"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(colfecha_registro)

            Dim colusuario As New DataGridViewTextBoxColumn
            With colusuario '10
                .DisplayIndex = 10
                .DataPropertyName = "usuario"
                .Name = "usuario"
                .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(colusuario)

            Dim coldatos_personales As New DataGridViewTextBoxColumn
            With coldatos_personales  '11
                .DisplayIndex = 11
                .DataPropertyName = "datos_personales"
                .Name = "datos_personales"
                .HeaderText = "Pasajero"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_pasaje.Columns.Add(coldatos_personales)

            Dim colidventa_pasajes As New DataGridViewTextBoxColumn
            With colidventa_pasajes '13
                .DisplayIndex = 13
                .DataPropertyName = "idventa_pasajes"
                .Name = "idventa_pasajes"
                .HeaderText = "idVtaPasaje"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_pasaje.Columns.Add(colidventa_pasajes)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Function
    Public Function fnBuscarpasaje() As Boolean
        Try
            ObjVentaPasaje.lidunidad_agencia_ori = Int(ObjVentaPasaje.coll_Lista_Origen(cmbOrigen.SelectedIndex.ToString))
            If ObjVentaPasaje.lidunidad_agencia_ori = 9999 Then
                ObjVentaPasaje.lidunidad_agencia_ori = -666
            End If
            ObjVentaPasaje.lidunidad_agencia_des = Int(ObjVentaPasaje.coll_Lista_Destino(cmbDestino.SelectedIndex.ToString))
            If ObjVentaPasaje.lidunidad_agencia_des = 9999 Then
                ObjVentaPasaje.lidunidad_agencia_des = -666
            End If
            ObjVentaPasaje.lidusuario_personal = Int(ObjVentaPasaje.coll_Lista_Usuarios(cmbUsuarios.SelectedIndex.ToString))
            If ObjVentaPasaje.lidusuario_personal = 0 Or ObjVentaPasaje.lidusuario_personal = 9999 Then
                ObjVentaPasaje.lidusuario_personal = -666
            End If
            ObjVentaPasaje.iidagencias_origen = Int(ObjVentaPasaje.coll_Lista_Agencias(cmbAgencia.SelectedIndex.ToString()))
            If ObjVentaPasaje.iidagencias_origen = 9999 Or ObjVentaPasaje.iidagencias_origen = 0 Then
                ObjVentaPasaje.iidagencias_origen = -666
            End If
            '--

            Dim sDoc As String = Me.txtNroSerieDoc.Text.Trim
            Dim iPos As Integer = sDoc.IndexOf("-")
            Dim sIzquierda As String = "", sDerecha As String = ""
            'Dim sIzquierda As String = sDoc.Substring(0, iPos).Trim.PadLeft(3, "0")
            'Dim sDerecha As String = sDoc.Substring(iPos + 1).Trim.PadLeft(7, "0")
            'sDoc = sIzquierda & "-" & sDerecha

            If iPos > 0 Then
                If sDoc.Substring(0, 1) = "F" Or sDoc.Substring(0, 1) = "B" Then 'electronico
                    sIzquierda = sDoc.Substring(0, iPos).Trim.PadLeft(4, "0")
                    sDerecha = sDoc.Substring(iPos + 1).Trim.PadLeft(8, "0")
                    sDoc = sIzquierda & "-" & sDerecha
                    ObjVentaPasaje.Serie = sIzquierda
                    ObjVentaPasaje.NroDoc = sDerecha
                Else 'manual
                    sIzquierda = sDoc.Substring(0, iPos).Trim.PadLeft(3, "0")
                    sDerecha = sDoc.Substring(iPos + 1).Trim.PadLeft(7, "0")
                    sDoc = sIzquierda & "-" & sDerecha
                    ObjVentaPasaje.Serie = sIzquierda
                    ObjVentaPasaje.NroDoc = sDerecha
                End If
            Else
                ObjVentaPasaje.Serie = "0"
                ObjVentaPasaje.NroDoc = "0"
            End If

            'Dim strNroDoc As String() = Split(txtNroSerieDoc.Text, "-")
            'If strNroDoc.Length > 1 Then
            '    If Val(strNroDoc(0).Length) > 0 And Val(strNroDoc(1).Length) > 0 Then
            '        ObjVentaPasaje.Serie = RellenoRight(inro_Digitos_SerieVentas, strNroDoc(0))
            '        ObjVentaPasaje.NroDoc = RellenoRight(inro_Digitos_Ventas, strNroDoc(1))
            '    Else
            '        ObjVentaPasaje.Serie = "0"
            '        ObjVentaPasaje.NroDoc = "0"
            '    End If
            'End If

            ObjVentaPasaje.sapellidos_nombre_dni = IIf(txtpasajerobusqueda.Text <> "", txtpasajerobusqueda.Text, "%")
            ObjVentaPasaje.sfecha_inicio = dtFechaInicio.Text
            ObjVentaPasaje.sfecha_final = dtFechaFin.Text
            ' 
            If ObjVentaPasaje.fnControlpasaje() = True Then
                dtControl.Clear()
                dtGridViewControl_pasaje.Columns.Clear()
                dtGridViewControl_pasaje.Refresh()
                'datahelper
                'odbda.Fill(dtControl, ObjVentaPasaje.rstvtapasaje)
                dtControl = ObjVentaPasaje.rstvtapasaje
                dvControl = dtControl.DefaultView

                dtGridViewControl_pasaje.DataSource = dvControl
                dtGridViewControl_pasaje.Refresh()
                lbNroRegistro.Text = dvControl.Count
                '
                fnLoadGrid()
                If dvControl.Count = 0 Then
                    MsgBox("No se ha encontrado ningún resultado para esta busqueda...", MsgBoxStyle.Information, "Seguridad Sistema")
                End If
                ' bformatImage = True
            Else
                MsgBox("No se ha encontrado ningún resultado para esta busqueda...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return False
    End Function
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        ObjVentaPasaje.icontrol = 1
        If Me.RBPasaje.Checked = True Then
            fnBuscarpasaje()
        Else
            fnBuscar_recibo_caja()
        End If
    End Sub
    Private Sub txtNroSerieDoc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNroSerieDoc.Leave
        ObjVentaPasaje.icontrol = 2
        If Me.RBPasaje.Checked = True Then
            fnBuscarpasaje()
        Else
            fnBuscar_recibo_caja()
        End If
    End Sub
    Private Sub txtpasajerobusqueda_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpasajerobusqueda.Leave
        If txtpasajerobusqueda.Text <> "" Then
            ObjVentaPasaje.icontrol = 3
            If Me.RBPasaje.Checked = True Then
                fnBuscarpasaje()
            Else
                fnBuscar_recibo_caja()
            End If
        End If
    End Sub
    Private Sub cmbAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectedIndexChanged
        If blnInicio Then Return
        Try
            Dim idAgencia As Integer
            idAgencia = Int(cmbAgencia.SelectedIndex)
            If idAgencia >= 0 Then
                idAgencia = IIf(cmbAgencia.SelectedIndex.ToString() <> "", Int(ObjVentaPasaje.coll_Lista_Agencias(cmbAgencia.SelectedIndex.ToString())), 0)
                If ObjVentaPasaje.fnFILTRO_USUARIO_X_AGENCIA(idAgencia, Me.dtFechaInicio.Value.ToShortDateString, Me.dtFechaFin.Value.ToShortDateString) = True Then
                    'datahelper
                    ModuUtil.LlenarCombo2(ObjVentaPasaje.rst_Lista_Usuarios, cmbUsuarios, ObjVentaPasaje.coll_Lista_Usuarios, 0)
                Else
                    NingunoComboIDs(cmbUsuarios, ObjVentaPasaje.coll_Lista_Usuarios)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btneditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneditar.Click
        Try
            If dtGridViewControl_pasaje.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViewControl_pasaje.SelectedRows.Item(0).Index
            If dtGridViewControl_pasaje.Rows().Count - 1 = row Then
                Return
            End If
            ' Recuperando los datos de la IDventa de pasaje 
            ObjVentaPasaje.sidventa_pasajes = CType(dtGridViewControl_pasaje.Rows(row).Cells("idventa_pasajes").Value, String)
            '
            If CType(ObjVentaPasaje.sidventa_pasajes, Long) <= 0 Then
                MsgBox("No puede realizar está operación ...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            ''            
            fnControl_ventapasaje(True)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    ' EDICION del Venta de pasaje
    Public Sub fnControl_ventapasaje(ByVal rflag As Boolean)
        Dim flat As Boolean = False
        Dim ll_es_fec_abierta As Long
        Try
            If dtGridViewControl_pasaje.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViewControl_pasaje.SelectedRows.Item(0).Index
            If dtGridViewControl_pasaje.Rows().Count - 1 = row Then
                Return
            End If
            If row >= 0 Then
                limpiar_variables() ' Limpiando variables
                Me.RBPasaje.Checked = True
                SelectMenu(1)
                ObjVentaPasaje.sidventa_pasajes = CType(dtGridViewControl_pasaje.Rows(row).Cells("idventa_pasajes").Value, String)
                If ObjVentaPasaje.fnEDIT_ventapasaje() = True Then
                    ''''''''''''''''''''''''''''''''''''''                    
                    'Public lidunidad_agencia_origen As Long
                    'Public sorigen As String
                    'Public lidagencia_origen1 As Long
                    li_control = 2 ' Para actualizar los datos
                    Me.txtidventa_pasaje.Text = ObjVentaPasaje.lidventa_pasajes
                    Me.cmbtipocomprobante.SelectedValue = ObjVentaPasaje.lidtipo_comprobante1
                    ''''
                    If ObjVentaPasaje.lidtipo_comprobante1 = 10 Or ObjVentaPasaje.lidtipo_comprobante1 = 11 Or ObjVentaPasaje.lidtipo_comprobante1 = 12 Then
                        Labboleto_ref.Visible = False
                        txtdctoreferencia_serie.Visible = False
                        txtdctoreferencia_nrodcto.Visible = False
                    Else
                        Labboleto_ref.Visible = True
                        txtdctoreferencia_serie.Visible = True
                        txtdctoreferencia_nrodcto.Visible = True
                    End If
                    '''' 
                    ''ObjVentaPasaje.lidunidad_agencia_origen() 
                    recupera_origen(ObjVentaPasaje.lidunidad_agencia_origen)
                    fn_recupera_agencias(CType(ObjVentaPasaje.lidunidad_agencia_origen, Integer), True)
                    Me.cmbagencia_origen.SelectedValue = ObjVentaPasaje.lidagencia_origen1
                    ''''
                    Me.TXTSER_COMPROBANTE.Text = ObjVentaPasaje.sserie_comprobante1
                    Me.TXTNRO_COMPROBANTE.Text = ObjVentaPasaje.snro_comprobante1
                    '
                    ds_serie_comprobante_old = ObjVentaPasaje.sserie_comprobante1
                    ds_nro_comprobante_old = ObjVentaPasaje.snro_comprobante1
                    '                    
                    If ObjVentaPasaje.lidagencia_destino1 = -666 Then
                        Me.txtidunidadagencia.Text = ""
                    Else
                        Me.txtidunidadagencia.Text = ObjVentaPasaje.lidunidad_agencia_destino
                        lidUnidadAgencias_destino = ObjVentaPasaje.lidunidad_agencia_destino
                    End If
                    '
                    Me.txtiWinDestino.Text = ObjVentaPasaje.sdestino
                    fn_recupera_agencias(Int(Me.txtidunidadagencia.Text), False)
                    'Me.cmbagenciadestino.SelectedIndex = ObjVentaPasaje.lidagencia_destino1
                    Me.cmbagenciadestino.SelectedValue = ObjVentaPasaje.lidagencia_destino1
                    '
                    Me.cmbcondicion.SelectedValue = ObjVentaPasaje.lidcondicion_boleto1
                    '
                    '                    Me.cmbcondicion.SelectedIndex = ObjVentaPasaje.lidcondicion_boleto1
                    Me.cmbcondicion.Enabled = True   ' Control por fiscalización 

                    Me.dtp_fec_emision.Value = ObjVentaPasaje.sfecha_emision1
                    '
                    Me.txtdctoreferencia_serie.Text = ObjVentaPasaje.sserie_comprobante_ref1
                    Me.txtdctoreferencia_nrodcto.Text = ObjVentaPasaje.snro_comprobante_ref1
                    '
                    Me.txtcuenta.Text = ObjVentaPasaje.sidpersona_cuenta
                    lidpersona = ObjVentaPasaje.lidpersona1
                    Me.Txtdni.Text = ObjVentaPasaje.sdni1
                    Me.txtpasajero.Text = ObjVentaPasaje.spasajero
                    If ObjVentaPasaje.ledad1 = -666 Then
                        Me.txtedad.Text = "" ' "" ' sfecha_nacimiento Omendoza 
                    Else
                        Me.txtedad.Text = ObjVentaPasaje.ledad1 ' "" ' sfecha_nacimiento Omendoza 
                    End If
                    lidpersona_ruc = ObjVentaPasaje.lidpersona_empresa1
                    Me.txtruc.Text = ObjVentaPasaje.sruc1
                    Me.txtrazon_social.Text = ObjVentaPasaje.srazon_social1
                    '
                    ll_es_fec_abierta = ObjVentaPasaje.ll_es_fecha_abierta
                    '
                    If ll_es_fec_abierta = 0 Then
                        Me.chk_es_fecha_abierta.Checked = False
                    Else
                        Me.chk_es_fecha_abierta.Checked = True
                    End If
                    '
                    If Not ObjVentaPasaje.sfecha_viaje1 = "" Then
                        Me.DTPfec_viaje.Value = CType(ObjVentaPasaje.sfecha_viaje1, Date)
                    End If
                    Me.txthora.Text = ObjVentaPasaje.shora_salida1
                    Me.txtnroasiento.Text = IIf(ObjVentaPasaje.lnro_asiento1 < 0, "", ObjVentaPasaje.lnro_asiento1)
                    Me.txtdescuento.Text = IIf(ObjVentaPasaje.dporc_descuento1 < 0, "", ObjVentaPasaje.dporc_descuento1)
                    Me.txtmemo.Text = ObjVentaPasaje.smemo1
                    Me.txttotal.Text = ObjVentaPasaje.dmonto_total1
                    '07/06/2008
                    Me.cmbtarjeta.SelectedValue = ObjVentaPasaje.iidtarjetas
                    '
                    Me.Cmbformapago.SelectedValue = ObjVentaPasaje.lidforma_pago
                    '
                    If ObjVentaPasaje.lidforma_pago = 2 Then ' Si es forma de pago (Credito)   
                        Me.Labrazon_social_cta.Visible = True
                        Me.txtrazon_social_cuenta.Visible = True
                        Me.labcodcuenta.Visible = True
                        Me.txtcuenta.Visible = True
                    Else
                        ' Modificado 20/03/2007
                        Me.Labrazon_social_cta.Visible = False
                        Me.txtrazon_social_cuenta.Visible = False
                        Me.labcodcuenta.Visible = False
                        Me.txtcuenta.Visible = False
                    End If
                    '
                    Me.txtcuenta.Text = ObjVentaPasaje.scodigo_cuenta1
                    Me.txtrazon_social_cuenta.Text = ObjVentaPasaje.srazon_social_cta1
                End If
            Else
                MsgBox("No Puede Realizar esta Operacion, Solo puede Editar las Recepcionadas", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            'msgbox "En Construccion...",MsgBoxStyle.Information 
        Catch ex As Exception
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            flat = False
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub frmventapasaje_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If lee_focus Then
            Me.txtidunidadagencia.Focus()
        End If
    End Sub
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim lsidunidad_origen As String
        Dim lsidunidad_destino As String
        Dim lsidusuario As String
        Dim lsidagencia As String
        Dim lsfecha_inicio As String
        Dim lsfecha_final As String
        'Recuperando los datos 
        lsidunidad_origen = CType(Int(ObjVentaPasaje.coll_Lista_Origen(cmbOrigen.SelectedIndex.ToString)), String)
        If lsidunidad_origen = "9999" Then
            lsidunidad_origen = "NULL"
        End If
        lsidunidad_destino = CType(Int(ObjVentaPasaje.coll_Lista_Destino(cmbDestino.SelectedIndex.ToString)), String)
        If lsidunidad_destino = "9999" Then
            lsidunidad_destino = "NULL"
        End If
        lsidusuario = CType(Int(ObjVentaPasaje.coll_Lista_Usuarios(cmbUsuarios.SelectedIndex.ToString)), String)
        If lsidusuario = "0" Or lsidusuario = "9999" Then
            lsidusuario = "NULL"
        End If
        lsidagencia = CType(Int(ObjVentaPasaje.coll_Lista_Agencias(cmbAgencia.SelectedIndex.ToString())), String)
        If lsidagencia = "9999" Or lsidagencia = "0" Then
            lsidagencia = "NULL"
        End If
        '--
        lsfecha_inicio = dtFechaInicio.Text
        lsfecha_final = dtFechaFin.Text

        Try
            ObjReport.Dispose()
        Catch

        End Try
        ObjReport.rutaRpt = PathFrmReport
        ObjReport.conectar(rptservice, rptuser, rptpass)
        '
        If RBPasaje.Checked = True Then
            ObjReport.printrpt(False, "", "PAS001.RPT", _
            "NORIGEN;" & lsidunidad_origen, _
            "NDESTINO;" & lsidunidad_destino, _
            "NIDUSUARIO;" & lsidusuario, _
            "NIDAGENCIA;" & lsidagencia, _
            "VFECHA_INICIO;" & lsfecha_inicio, _
            "VFECHA_FINAL;" & lsfecha_final, _
            "P_SUBTITULO;" & "Del " + lsfecha_inicio + " hasta " + lsfecha_final)
            '
        Else
            ObjReport.printrpt(False, "", "PAS002.RPT", _
        "NORIGEN;" & lsidunidad_origen, _
        "NDESTINO;" & lsidunidad_destino, _
        "NIDUSUARIO;" & lsidusuario, _
        "NIDAGENCIA;" & lsidagencia, _
        "VFECHA_INICIO;" & lsfecha_inicio, _
        "VFECHA_FINAL;" & lsfecha_final, _
        "P_SUBTITULO;" & "Del " + lsfecha_inicio + " hasta " + lsfecha_final)
            '
        End If
    End Sub
    Private Sub txtidunidadagorigen_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtidunidadagorigen.Leave
        Dim l_idunidad_agencia As Integer
        'datahelper
        'Dim l_rstunidad_agencia As New ADODB.Recordset
        Dim l_rstunidad_agencia As DataTable
        Try
            If b_no_lee_campo = True Then
                If txtidunidadagorigen.Text <> "" Then
                    l_idunidad_agencia = CType(txtidunidadagorigen.Text, Integer)
                    'datahelper
                    'l_rstunidad_agencia = ObjVentaPasaje.fnGetunidadagencia(l_idunidad_agencia)
                    'If l_rstunidad_agencia.BOF = False And l_rstunidad_agencia.EOF = False Then
                    l_rstunidad_agencia = ObjVentaPasaje.fnGetunidadagencia(l_idunidad_agencia)
                    If l_rstunidad_agencia.Rows.Count > 0 Then
                        Me.txtiWinorigen.Text = l_rstunidad_agencia.Rows(0).Item(1) ' Recupera la ciudad 
                        'datahelper
                        'Me.txtiWinorigen.Text = l_rstunidad_agencia.Fields(1).Value ' Recupera la ciudad 
                        ' Recupera las agecias asociadas 
                        If fn_recupera_agencias(l_idunidad_agencia, True) = True Then
                            Me.txtdctoreferencia_serie.Focus()
                        Else
                            Me.txtiWinorigen.Text = ""
                            Me.txtidunidadagorigen.Text = ""
                            Me.txtidunidadagorigen.Focus()
                        End If
                    Else
                        Me.txtiWinorigen.Text = ""
                        Me.txtidunidadagorigen.Text = ""
                        Me.txtidunidadagorigen.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub fnAgenciaOrigen()
        Try
            '
            Dim idUnidadAgencias As Integer = iWinorigen.IndexOf(txtiWinorigen.Text)
            'If idUnidadAgencias = CType(Me.txtidunidadagorigen.Text, Integer) Then
            '    Exit Sub
            'End If
            If idUnidadAgencias >= 0 Then
                idUnidadAgencias = Int(coll_iOrigen.Item(idUnidadAgencias.ToString))
                Me.txtidunidadagorigen.Text = CType(idUnidadAgencias, Long)
                ''''''''''''''''''''
                'Recupera las agencias 
                fn_recupera_agencias(idUnidadAgencias, True)
            Else
                '    Me.txtidunidadagorigen.Text = ""
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub txtiWinorigen_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtiWinorigen.Validated
        Try
            fnAgenciaOrigen()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Public Function fnBuscar_recibo_caja() As Boolean
        Try
            ObjVentaPasaje.lidunidad_agencia_ori = Int(ObjVentaPasaje.coll_Lista_Origen(cmbOrigen.SelectedIndex.ToString))
            If ObjVentaPasaje.lidunidad_agencia_ori = 9999 Then
                ObjVentaPasaje.lidunidad_agencia_ori = -666
            End If
            ObjVentaPasaje.lidunidad_agencia_des = Int(ObjVentaPasaje.coll_Lista_Destino(cmbDestino.SelectedIndex.ToString))
            If ObjVentaPasaje.lidunidad_agencia_des = 9999 Then
                ObjVentaPasaje.lidunidad_agencia_des = -666
            End If
            ObjVentaPasaje.lidusuario_personal = Int(ObjVentaPasaje.coll_Lista_Usuarios(cmbUsuarios.SelectedIndex.ToString))
            If ObjVentaPasaje.lidusuario_personal = 0 Or ObjVentaPasaje.lidusuario_personal = 9999 Then
                ObjVentaPasaje.lidusuario_personal = -666
            End If
            ObjVentaPasaje.iidagencias_origen = Int(ObjVentaPasaje.coll_Lista_Agencias(cmbAgencia.SelectedIndex.ToString()))
            If ObjVentaPasaje.iidagencias_origen = 9999 Or ObjVentaPasaje.iidagencias_origen = 0 Then
                ObjVentaPasaje.iidagencias_origen = -666
            End If
            '--
            Dim strNroDoc As String() = Split(txtNroSerieDoc.Text, "-")
            If strNroDoc.Length > 1 Then
                If Val(strNroDoc(0).Length) > 0 And Val(strNroDoc(1).Length) > 0 Then
                    '       ObjVentaPasaje.sserie_comprobante = RellenoRight(inro_Digitos_SerieVentas, strNroDoc(0))
                    ObjVentaPasaje.Serie = RellenoRight(inro_Digitos_SerieVentas, strNroDoc(0))
                    ObjVentaPasaje.NroDoc = RellenoRight(inro_Digitos_Ventas, strNroDoc(1))
                    'ObjVentaPasaje.snro_comprobante = RellenoRight(inro_Digitos_Ventas, strNroDoc(1))
                Else
                    ObjVentaPasaje.Serie = "0"
                    ObjVentaPasaje.NroDoc = "0"
                End If
            End If
            ObjVentaPasaje.sapellidos_nombre_dni = IIf(txtpasajerobusqueda.Text <> "", txtpasajerobusqueda.Text, "%")
            ObjVentaPasaje.sfecha_inicio = dtFechaInicio.Text
            ObjVentaPasaje.sfecha_final = dtFechaFin.Text
            ' 
            If ObjVentaPasaje.fnControl_recibocaja() = True Then
                dtControl.Clear()
                dtGridViewControl_pasaje.Columns.Clear()
                dtGridViewControl_pasaje.Refresh()
                'datahelper
                'odbda.Fill(dtControl, ObjVentaPasaje.rstvtapasaje)
                dtControl = ObjVentaPasaje.rstvtapasaje
                dvControl = dtControl.DefaultView
                '
                dtGridViewControl_pasaje.DataSource = dvControl
                dtGridViewControl_pasaje.Refresh()
                lbNroRegistro.Text = dvControl.Count
                '
                fnLoadGrid()
                '
                If dvControl.Count = 0 Then
                    MsgBox("No se ha encontrado ningún resultado para esta busqueda...", MsgBoxStyle.Information, "Seguridad Sistema")
                End If
                ' bformatImage = True
            Else
                MsgBox("No se ha encontrado ningún resultado para esta busqueda...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return False
    End Function
    Private Sub txtdctoreferencia_serie_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdctoreferencia_serie.Leave
        txtdctoreferencia_serie.Text = RellenoRight(inro_Digitos_SerieVentas, txtdctoreferencia_serie.Text)
    End Sub
    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem.Click
        'Recuperando los datos 
        Dim dgrv0 As DataGridViewRow
        Dim s_comprobante As String
        Dim s_idventa_pasaje As String
        Dim lnromensaje As Long
        Dim smensaje As String
        Try
            '
            If Me.dtGridViewControl_pasaje.Rows.Count < 1 Then
                Exit Sub
            End If
            dgrv0 = Me.dtGridViewControl_pasaje.CurrentRow()
            s_comprobante = CType(dgrv0.Cells("nro_comprobante").Value, String)
            Dim resp As DialogResult = MessageBox.Show("Está seguro de eliminar el Boleto o Recibo Nº " & s_comprobante & " ? ", "Seguridad del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resp = Windows.Forms.DialogResult.Yes Then
                s_idventa_pasaje = CType(dgrv0.Cells("idventa_pasajes").Value, String)
                '
                ObjVentaPasaje.sidventa_pasajes = s_idventa_pasaje
                '
                If ObjVentaPasaje.fnElimina_pasaje Then
                    lnromensaje = CType(ObjVentaPasaje.rst_elimina_pasaje.Rows(0).Item("codsql"), Long)
                    smensaje = CType(ObjVentaPasaje.rst_elimina_pasaje.Rows(0).Item("msjsql"), String)
                    If lnromensaje <> 0 Then
                        MsgBox(smensaje, MsgBoxStyle.Exclamation, "Venta de Pasajes")
                    Else
                        'Refresca la pantalla 
                        ObjVentaPasaje.icontrol = 1
                        If Me.RBPasaje.Checked = True Then
                            fnBuscarpasaje()
                        Else
                            fnBuscar_recibo_caja()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Function fn_validar_origen_destino() As Boolean
        If Me.txtidunidadagencia.Text = Me.txtidunidadagorigen.Text Then
            MsgBox("El destino debe ser diferente al origen.", MsgBoxStyle.Information, "Venta Pasajes")
            Me.txtidunidadagencia.Text = ""
            Me.txtiWinDestino.Text = ""
            Me.txtidunidadagencia.Focus()
            Return False
        End If
        Return True
        '
    End Function
    Private Sub txtidunidadagorigen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtidunidadagorigen.TextChanged
        Me.txtidunidadagencia.Text = ""
        Me.txtiWinDestino.Text = ""
        Me.cmbagenciadestino.SelectedValue = -1
    End Sub
    Private Sub txtiWinorigen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtiWinorigen.TextChanged
        Me.txtidunidadagencia.Text = ""
        Me.txtiWinDestino.Text = ""
        Me.cmbagenciadestino.SelectedValue = -1
    End Sub
    Function validar_serie_recibo() As Boolean
        If Me.cmbtipocomprobante.SelectedValue = 10 Or Me.cmbtipocomprobante.SelectedValue = 11 Or Me.cmbtipocomprobante.SelectedValue = 12 Then
            If Me.TXTSER_COMPROBANTE.Text = "200" Then
                MsgBox("No debe usar la serie 200, en la venta de pasaje", MsgBoxStyle.Information, "Venta Pasaje")
                Me.TXTSER_COMPROBANTE.Text = ""
                Me.TXTSER_COMPROBANTE.Focus()
                Return False
            End If
        End If
        Return True
    End Function
    Function validar_serie_pasaje() As Boolean
        If Me.cmbtipocomprobante.SelectedValue = 16 Or Me.cmbtipocomprobante.SelectedValue = 17 Or Me.cmbtipocomprobante.SelectedValue = 18 Then
            If Me.TXTSER_COMPROBANTE.Text <> "200" Then
                MsgBox("Solo debe usar la serie 200, para el recibo de caja", MsgBoxStyle.Information, "Venta Pasaje")
                Me.TXTSER_COMPROBANTE.Text = ""
                Me.TXTSER_COMPROBANTE.Focus()
                Return False
            End If
        End If
        Return True
    End Function
    Private Sub Cmbformapago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbformapago.SelectedIndexChanged
        b_no_lee_campo = False
    End Sub
    Private Sub Cmbformapago_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmbformapago.Leave
        b_no_lee_campo = True
    End Sub

    Private Sub CambiarUsuarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarUsuarioToolStripMenuItem.Click
        Dim dgrv0 As DataGridViewRow
        Dim s_idventa_pasaje As String
        Dim l_idusuario_personal, l_idagencia As Long
        Dim s_usuario_personal As String
        Try
            '
            If Me.dtGridViewControl_pasaje.Rows.Count < 1 Then
                Exit Sub
            End If
            dgrv0 = Me.dtGridViewControl_pasaje.CurrentRow()
            s_idventa_pasaje = CType(dgrv0.Cells("idventa_pasajes").Value, String)
            If s_idventa_pasaje = Nothing Then
                MessageBox.Show("No ha seleccionado ningún registro para cambiar el usuario", "Venta de Pasaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'Recuperar El usuario del Boleto 
            l_idusuario_personal = Int(ObjVentaPasaje.coll_Lista_Usuarios(cmbUsuarios.SelectedIndex.ToString))
            s_usuario_personal = Me.cmbUsuarios.SelectedItem
            ' Pasar la agencia 
            l_idagencia = CType(Int(ObjVentaPasaje.coll_Lista_Agencias(cmbAgencia.SelectedIndex.ToString())), Long)
            If l_idagencia = "9999" Or l_idagencia = "0" Then
                MessageBox.Show("Para cambiar de usuario, debe estar en la agencia del usuario a cambiar", "Venta de Pasaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            ' Invocando a la otra ventana 
            Dim a As New frmcambiousuario_pasajes
            a.txtidusuario_personal_actual.Text = l_idusuario_personal
            a.txtidventa_pasaje.Text = s_idventa_pasaje
            a.txtusuario_actual.Text = s_usuario_personal
            '
            If ObjVentaPasaje.fnFILTRO_USUARIO_X_AGENCIA(l_idagencia) = True Then
                'datahelper
                'ModuUtil.LlenarComboIDs(ObjVentaPasaje.rst_Lista_Usuarios, a.cmbusuario_nuevo, ObjVentaPasaje.coll_Lista_Usuarios, l_idusuario_personal)
                ModuUtil.LlenarCombo2(ObjVentaPasaje.rst_Lista_Usuarios, a.cmbusuario_nuevo, ObjVentaPasaje.coll_Lista_Usuarios, l_idusuario_personal)
            End If
            'a.ShowDialog()

            Acceso.Asignar(a, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                a.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            'Refresca la pantalla 
            If a.pb_refresca = True Then
                ObjVentaPasaje.icontrol = 1
                If Me.RBPasaje.Checked = True Then
                    fnBuscarpasaje()
                Else
                    fnBuscar_recibo_caja()
                End If
            End If
            'pb_refresca = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub txtcuenta_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtcuenta.Validating
        Try
            Me.txtcuenta.Text = RellenoRight(11, Me.txtcuenta.Text)
            '
            If Me.txtcuenta.Text <> "00000000000" Then
                If Me.txtcuenta.Text.Length <> 11 Then
                    MsgBox("El Nº de RUC no es válido ", MsgBoxStyle.Information, "Seguridad Sistema")
                    e.Cancel = True
                End If
                ' Valida el nro de Ruc 
                If Not fnValidarRUC(Me.txtcuenta.Text.ToString) Then
                    MsgBox("No podra Realizar esta Operación, el Nº de RUC no esta configurado")
                    e.Cancel = True
                End If
            Else
                Me.txtcuenta.Text = ""
                e.Cancel = False
            End If
        Catch ex As Exception
            '
        End Try
    End Sub
    Public Function fnrecuperacliente_ruc_cuenta() As Boolean
        Dim flag As Boolean = False
        Try
            ObjVentaPasaje.sNU_DOCU_SUNAT = IIf(Me.txtcuenta.Text <> "", Me.txtcuenta.Text, "NULL")
            If ObjVentaPasaje.fnLISTA_GET_CLIENTE_RUC = True Then
                ' stel_pasajero = ObjVentaPasaje.stelefono_ruc
                Me.txtrazon_social_cuenta.Text = ObjVentaPasaje.snombre_empresa
                flag = True
            Else
                Me.txtrazon_social_cuenta.Text = ""
                flag = False
            End If
        Catch ex As Exception
            flag = False
            Throw New Exception(ex.Message)
        End Try
        Return flag
    End Function
    Private Sub txtcuenta_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcuenta.Leave
        Dim b_flag As Boolean
        Try
            'Recupera los datos y colocas el valor  
            If b_no_lee_campo = True Then
                b_flag = fnrecuperacliente_ruc_cuenta()
                If b_flag = False Then
                    If Me.txtcuenta.Text <> "" Then
                        Me.txtrazon_social_cuenta.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
        b_no_lee_campo = True
    End Sub
    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub

    Private Sub chk_es_fecha_abierta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_es_fecha_abierta.CheckedChanged
        Try
            'DTPfec_viaje
            If chk_es_fecha_abierta.Checked = True Then
                DTPfec_viaje.Enabled = False
                DTPfec_viaje.Visible = False
                Me.txt_fec_viaje_tmp.Visible = True
            Else
                '
                DTPfec_viaje.Enabled = True
                DTPfec_viaje.Visible = True
                '
                Me.txt_fec_viaje_tmp.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Try
            limpiar_variables()
            If ObjVentaPasaje.fnNroDocumento(5) = True Then ' La serie será del boleto de viaje -16/06/2007
                If IsDBNull(ObjVentaPasaje.Serie) = True Or RellenoRight(inro_Digitos_SerieVentas, ObjVentaPasaje.Serie) = "000" Then
                    MessageBox.Show("No ha configurado la serie del boleto de viaje", "Venta de Pasajes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                    Exit Sub
                End If
                TXTSER_COMPROBANTE.Text = RellenoRight(inro_Digitos_SerieVentas, ObjVentaPasaje.Serie)
                TXTNRO_COMPROBANTE.Text = RellenoRight(inro_Digitos_Ventas, ObjVentaPasaje.NroDoc)
                snro_serie = TXTSER_COMPROBANTE.Text
                snro_comprobante = CType(TXTNRO_COMPROBANTE.Text, String)
                ds_serie_comprobante_new = Me.TXTSER_COMPROBANTE.Text
                ds_nro_comprobante_new = Me.TXTNRO_COMPROBANTE.Text
            End If
            '
            dtoUSUARIOS.m_iNombreUnidadAgencia = fnGetCiudad(dtoUSUARIOS.m_idciudad.ToString)
            dtoUSUARIOS.m_iNombreAgencia = fnGetAGENCIA(dtoUSUARIOS.m_iIdAgencia.ToString)
            Me.Text = "VENTAS PASAJE..." & dtoUSUARIOS.iLOGIN & " Ag. Nro " & dtoUSUARIOS.m_iIdAgencia & " [ " & dtoUSUARIOS.m_iNombreAgencia & " ][ " & dtoUSUARIOS.m_iNombreUnidadAgencia & "] "
            ToolStripMenuItem1.Text = "&BUSCAR"
            ToolStripMenuItem2.Text = "&BOLETO PASAJE"
            Me.RBPasaje.Checked = True
            SelectMenu(1)
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Sub recupera_origen(ByVal liduniad_agencia_origen As Long)
        Try
            Dim l_rstunidad_agencia As DataTable
            Me.txtidunidadagorigen.Text = CType(liduniad_agencia_origen, String)
            '
            l_rstunidad_agencia = ObjVentaPasaje.fnGetunidadagencia(liduniad_agencia_origen)
            If l_rstunidad_agencia.Rows.Count > 0 Then
                Me.txtiWinorigen.Text = l_rstunidad_agencia.Rows(0).Item(1) ' Recupera la ciudad 
                ' Recupera las agecias asociadas 
                Dim l_verdad As Boolean
                l_verdad = fn_recupera_agencias(CType(dtoUSUARIOS.m_idciudad, Integer), True)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Function fnvalida_comprobante() As Boolean
        Dim s_comprobante, s_nombre_agencia, s_usuario, s_fecha_emision, s_condicion_boleto As String
        Dim lidventa_pasajes As Long
        '
        Try
            ObjVentaPasaje.Serie = Me.TXTSER_COMPROBANTE.Text
            ObjVentaPasaje.NroDoc = Me.TXTNRO_COMPROBANTE.Text
            If ObjVentaPasaje.fnValida_comprobante() = True Then

                If ObjVentaPasaje.rst_valida_comprobante.Rows.Count > 0 Then
                    If IsDBNull(ObjVentaPasaje.rst_valida_comprobante.Rows(0).Item("idventa_pasajes")) = True Then
                        Return True
                    Else
                        lidventa_pasajes = CType(ObjVentaPasaje.rst_valida_comprobante.Rows(0).Item("idventa_pasajes"), Long)
                        s_comprobante = CType(ObjVentaPasaje.rst_valida_comprobante.Rows(0).Item("comprobante"), String)
                        s_fecha_emision = CType(ObjVentaPasaje.rst_valida_comprobante.Rows(0).Item("fecha_emision"), String)
                        s_nombre_agencia = CType(ObjVentaPasaje.rst_valida_comprobante.Rows(0).Item("nombre_agencia"), String)
                        s_usuario = CType(ObjVentaPasaje.rst_valida_comprobante.Rows(0).Item("usuario"), String)
                        s_condicion_boleto = CType(ObjVentaPasaje.rst_valida_comprobante.Rows(0).Item("condicion_boleto"), String)
                        MessageBox.Show("El comprobante " + Me.TXTSER_COMPROBANTE.Text + " - " + Me.TXTNRO_COMPROBANTE.Text + " existe en el " + s_comprobante + " del día " + s_fecha_emision + " hecho en la agencia " + s_nombre_agencia + _
                         " con el usuario " + s_usuario + ", con la condición " + s_condicion_boleto, "Venta de Pasaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.TXTNRO_COMPROBANTE.Text = ""
                        Me.TXTNRO_COMPROBANTE.Focus()
                        Return False
                    End If
                End If
            End If
            Return True
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Sub btnAnular_Click(sender As System.Object, e As System.EventArgs) Handles btnAnular.Click
        Try
            If MessageBox.Show("¿Está seguro de anular el documento " & dtGridViewControl_pasaje.Item("Nro_Comprobante", dtGridViewControl_pasaje.CurrentRow.Index).Value.ToString & "?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                ObjVentaPasaje.lidventa_pasajes = Convert.ToDouble(dtGridViewControl_pasaje.Item("IdVenta_Pasajes", dtGridViewControl_pasaje.CurrentRow.Index).Value.ToString)
                ObjVentaPasaje.lidpersona1 = dtoUSUARIOS.IdLogin
                ObjVentaPasaje.sip = dtoUSUARIOS.IP
                ObjVentaPasaje.fnAnularBoletoRecCaja()
                MessageBox.Show(ObjVentaPasaje.rstMensaje.Rows(0).Item(1).ToString, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                fnBuscarpasaje()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dtFechaInicio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtFechaInicio.ValueChanged
        cmbAgencia_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub dtFechaFin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtFechaFin.ValueChanged
        cmbAgencia_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub txtNroSerieDoc_MaskInputRejected(sender As System.Object, e As System.Windows.Forms.MaskInputRejectedEventArgs)

    End Sub

    Private Sub txtNroSerieDoc_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroSerieDoc.KeyPress
        If ValidaNumero2(e.KeyChar) Then
            e.Handled = False
        ElseIf Asc(e.KeyChar.ToString.ToUpper) >= 65 And Asc(e.KeyChar.ToString.ToUpper) <= 90 Then 'e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtNroSerieDoc_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNroSerieDoc.TextChanged

    End Sub
End Class
