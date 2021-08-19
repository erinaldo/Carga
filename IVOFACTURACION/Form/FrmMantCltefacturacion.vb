'Imports System.Windows.Forms
'Imports System.ComponentModel
'Imports System.Text.RegularExpressions
'Imports System
'Imports System.Data
'Imports System.Data.OleDb
'Imports System.Drawing
'Imports System.IO
'Imports ADOSERVERLib
'Imports Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn
Public Class FrmMantCltefacturacion
#Region "Variables Publicas"
    Dim objFACTURA As New ClsLbTepsa.dtoFACTURA
    Dim dv_persona_factura_otro As New DataView
    Public siddireccion_consignado As String
    Public dtfrmmantclte_rubro As New DataTable
    Public coll_Lista_Personas As New Collection
    Public iWinPersona As New AutoCompleteStringCollection
    Public iWinPersonaRUC As New AutoCompleteStringCollection
    Public iWinPersonaRubro As New AutoCompleteStringCollection
    Public iWinrepresentante_legal As New AutoCompleteStringCollection
    Public hnd As Long
#End Region
#Region "Variables del Formulario"
    '
    'Dim dr4 As New OleDb.OleDbDataAdapter
    'Recupera datatable 
    Dim dttipodireccion, dtpais, dtdepartamento, dtprovincia, dtdistrito, dtagencia As New DataTable
    Dim dtdireccionconsignado As New DataTable

    'Recupera dataview
    Dim dvtipodireccion, dvpais, dvdepartamento, dvprovincia, dvdistrito, dvagencia As New DataView
    Public dvdireccionconsignado, dvfrmmantclte_rubro As New DataView
    '
    Dim iddistrito, idprovincia, iddepartamento, idpais, nomagencvia As String
    Dim drvAgencia As DataRowView
    ' Variables de control 
    Dim b_lee_campo As Boolean = True
    Dim b_lee_cliente As Boolean = False
    Dim b_ingresa_cliente As Boolean = False
    Dim bIngreso As Boolean = False
#End Region
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Try
            If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
                SendKeys.Send("{Tab}")
                Return True
            End If
            If msg.WParam.ToInt32() = CInt(Keys.F5) Then
                If Btnaceptar.Enabled Then
                    Me.Aceptar()
                End If
                'devolviendo_direccion()
                Return True
            End If
            If msg.WParam.ToInt32() = CInt(Keys.F12) Then
                limpiartodo()
                Exit Function
            End If
            Return MyBase.ProcessCmdKey(msg, keyData)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad de Sistema")
        End Try
    End Function
    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize)
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Function validar() As Boolean
        validar = False

        If Me.txtruc.Text.Trim = "" Then
            MsgBox("Ingrese el RUC/DNI", MsgBoxStyle.Critical, "Seguridad de Sistema")
            Exit Function
        End If
        If Me.txtcliente.Text.Trim = "" Then
            MsgBox("Ingrese el cliente", MsgBoxStyle.Critical, "Seguridad de Sistema")
            Exit Function
        End If
        If cmbrubro_frmmantclte.SelectedIndex < 0 Then
            MsgBox("Seleccione el rubro", MsgBoxStyle.Critical, "Seguridad de Sistema")
            Exit Function
        End If
        If Me.txtrepresentante_legal.Text.Trim = "" Then
            MsgBox("Ingrese el Representante Legal", MsgBoxStyle.Critical, "Seguridad de Sistema")
            Exit Function
        End If
        If cmbtipodireccion.SelectedIndex < 0 Then
            MsgBox("Seleccione el tipo de dirección", MsgBoxStyle.Critical, "Seguridad de Sistema")
            Exit Function
        End If
        If cmbpais.SelectedIndex < 0 Then
            MsgBox("Seleccione el pais", MsgBoxStyle.Critical, "Seguridad de Sistema")
            Exit Function
        End If
        If cmbdepartamento.SelectedIndex < 0 Then
            MsgBox("Seleccione el departamento", MsgBoxStyle.Critical, "Seguridad de Sistema")
            Exit Function
        End If
        If cmbprovincia.SelectedIndex < 0 Then
            MsgBox("Seleccione la provincia", MsgBoxStyle.Critical, "Seguridad de Sistema")
            Exit Function
        End If

        If cmbdistrito.SelectedIndex < 0 Then
            MsgBox("Seleccione el distrito", MsgBoxStyle.Critical, "Seguridad de Sistema")
            Exit Function
        End If

        If Me.txtdireccion.Text.Trim = "" Then
            MsgBox("Ingrese la dirección", MsgBoxStyle.Critical, "Seguridad de Sistema")
            Exit Function
        End If
        validar = True

    End Function

    Private Sub FrmMantCltefacturacion_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmMantCltefacturacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmMantClteCarga_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Recuperando el distrito de la agencia 
        Dim ltipodireccion As Integer
        Dim sFiltroDistrito As String
        Try
            ' Por defecto se esta poniendo este valor igual que el frm_cliente
            objmant_clte_facturacion.lidagencia = CType(dtoUSUARIOS.m_iIdAgencia, Long)
            objmant_clte_facturacion.sidireccionconsignado = Mod_otro_facturacion.siddireccion_consignado 'siddireccion_consignado
            ' --
            'If objmant_clte_facturacion.sidireccionconsignado = "null" Then
            '
            If objmant_clte_facturacion.fn_load_mant_clte_facturacion = True Then
                'datahelper
                'dr4.Fill(dttipodireccion, objmant_clte_facturacion.rst_tipo_direccion)
                'dr4.Fill(dtpais, objmant_clte_facturacion.rst_pais)
                'dr4.Fill(dtdepartamento, objmant_clte_facturacion.rst_dptos)
                'dr4.Fill(dtprovincia, objmant_clte_facturacion.rst_provincia)
                'dr4.Fill(dtdistrito, objmant_clte_facturacion.rst_distrito)
                'dr4.Fill(dtagencia, objmant_clte_facturacion.rst_agencia)
                dttipodireccion = objmant_clte_facturacion.rst_tipo_direccion
                dtpais = objmant_clte_facturacion.rst_pais
                dtdepartamento = objmant_clte_facturacion.rst_dptos
                dtprovincia = objmant_clte_facturacion.rst_provincia
                dtdistrito = objmant_clte_facturacion.rst_distrito
                dtagencia = objmant_clte_facturacion.rst_agencia
                'Recuperando el valor del pais 
                idpais = CType(dtagencia.Rows(0).Item(3), Integer)
                iddepartamento = CType(dtagencia.Rows(0).Item(2), Integer)
                idprovincia = CType(dtagencia.Rows(0).Item(1), Integer)
                iddistrito = CType(dtagencia.Rows(0).Item(0), Integer)
                'datahelper
                'dr4.Fill(dtdireccionconsignado, objmant_clte_facturacion.rst_direccion_consignado)
                dtdireccionconsignado = objmant_clte_facturacion.rst_direccion_consignado
            End If
            ' Llenando los combos 
            ' Tipo dirección                 
            If dtdireccionconsignado.Rows.Count > 0 Then
                If IsDBNull(dtdireccionconsignado.Rows(0).Item(0)) = True Then
                    ltipodireccion = 1
                Else
                    ltipodireccion = CType(dtdireccionconsignado.Rows(0).Item(0), Integer)
                End If
            Else
                ltipodireccion = 1
            End If
            '''''''''
            b_lee_campo = False
            'Llenando los Combos a treves de DataViews
            dvtipodireccion = CargarCombo(Me.cmbtipodireccion, dttipodireccion, "TIPO_DIRECCION", "IDTIPO_DIRECCION", ltipodireccion)
            ' País                 
            dvpais = CargarCombo(cmbpais, dtpais, "PAIS", "IDPAIS", idpais)
            ' Departamento 
            dvdepartamento = CargarCombo(cmbdepartamento, dtdepartamento, "DEPARTAMENTO", "IDDEPARTAMENTO", iddepartamento)
            dvprovincia = CargarCombo(cmbprovincia, dtprovincia, "PROVINCIA", "IDPROVINCIA", idprovincia)
            dvdistrito = CargarCombo(cmbdistrito, dtdistrito, "DSITRITO", "IDDISTRITO", iddistrito)
            If dtdireccionconsignado.Rows.Count = 1 Then
                ' Recupera información de la dirección si lo tuviese 
                cmbtipodireccion.SelectedValue = CType(dtdireccionconsignado.Rows(0).Item(0), Integer)
                '
                cmbpais.SelectedValue = CType(dtdireccionconsignado.Rows(0).Item(2), Integer)
                cmbpais.Enabled = False
                cmbdepartamento.SelectedValue = dtdireccionconsignado.Rows(0).Item(3)
                cmbdepartamento.Enabled = False
                cmbprovincia.SelectedValue = dtdireccionconsignado.Rows(0).Item(4)
                cmbprovincia.Enabled = True

                Dim posicion As Integer
                ' Dim drv As DataRowView
                Dim prov As Integer
                Dim FiltroDistrito As String
                Dim iidpais As Integer
                Dim iiddepartamento As Integer
                ' 
                Try

                    posicion = cmbprovincia.SelectedIndex()
                    If posicion >= 0 Then
                        ' drv = dvprovincia.Item(posicion)
                        ' prov = IIf(IsDBNull(drv("IDPROVINCIA")) = True, "0", drv("IDPROVINCIA").ToString)
                        prov = CType(Me.cmbprovincia.SelectedValue, Integer)
                        ''
                        'Dim FiltroDistrito As String = ""
                        'Dim MyParametroDs As Integer = cmbprovincia.SelectedValue
                        'iddistrito = rstagencia.Fields.Item(0).Value
                        iidpais = CType(cmbpais.SelectedValue, Integer)
                        iiddepartamento = CType(cmbdepartamento.SelectedValue, Integer)
                        FiltroDistrito = "IDPAIS =  " & iidpais & " and IDDEPARTAMENTO  = " & iiddepartamento & " and IDPROVINCIA = " & prov
                        dvdistrito.RowFilter = FiltroDistrito
                        cmbdistrito.Refresh()
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
                End Try




                cmbdistrito.SelectedValue = dtdireccionconsignado.Rows(0).Item(5)
                cmbdistrito.Enabled = True
                txtdireccion.Text = dtdireccionconsignado.Rows(0).Item(6)
                txtdireccion.Enabled = True


            End If
            'End If
            b_lee_campo = True


            mostrar_datos()

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch exp As Exception
            MsgBox(exp.ToString, MsgBoxStyle.Exclamation, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub Btncancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btncancelar.Click
        limpiartodo()
        ''
        'Me.Close()
    End Sub
    Private Sub cmbprovincia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprovincia.SelectedIndexChanged
        Dim posicion As Integer
        ' Dim drv As DataRowView
        Dim prov As Integer
        Dim FiltroDistrito As String
        Dim iidpais As Integer
        Dim iiddepartamento As Integer
        ' 
        Try
            If b_lee_campo Then
                posicion = cmbprovincia.SelectedIndex()
                If posicion >= 0 Then
                    ' drv = dvprovincia.Item(posicion)
                    ' prov = IIf(IsDBNull(drv("IDPROVINCIA")) = True, "0", drv("IDPROVINCIA").ToString)
                    prov = CType(Me.cmbprovincia.SelectedValue, Integer)
                    ''
                    'Dim FiltroDistrito As String = ""
                    'Dim MyParametroDs As Integer = cmbprovincia.SelectedValue
                    'iddistrito = rstagencia.Fields.Item(0).Value
                    iidpais = CType(cmbpais.SelectedValue, Integer)
                    iiddepartamento = CType(cmbdepartamento.SelectedValue, Integer)
                    FiltroDistrito = "IDPAIS =  " & iidpais & " and IDDEPARTAMENTO  = " & iiddepartamento & " and IDPROVINCIA = " & prov
                    dvdistrito.RowFilter = FiltroDistrito
                    cmbdistrito.Refresh()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub cmbpais_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbpais.SelectedIndexChanged
        'Try
        '    Dim idpais As Integer
        '    idpais = cmbpais.SelectedIndex
        '    If idpais >= 0 Then
        '        idpais = IIf(cmbpais.SelectedIndex.ToString() <> "", Int(coll_Pais(cmbpais.SelectedIndex.ToString())), 0)
        '        If ModuUtil.SP_CONTROL_UBIGEO(2, idpais) = True Then
        '            ModuUtil.LlenarComboIDs(ModuUtil.rst_cur_datos, cmbdepartamento, ModVOCONTROLUSUARIO.coll_Departamento, Int(ModuUtil.rst_cur_datos.Fields.Item(0).Value))
        '        Else
        '            NingunoComboIDs(cmbdepartamento, ModVOCONTROLUSUARIO.coll_Departamento)
        '            NingunoComboIDs(cmbprovincia, ModVOCONTROLUSUARIO.coll_Provincia)
        '            NingunoComboIDs(cmbdistrito, ModVOCONTROLUSUARIO.coll_Distrito)
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
    End Sub
    Private Sub cmbdepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdepartamento.SelectedIndexChanged
        'Try
        '    Dim idDepartamento As Integer
        '    idDepartamento = cmbdepartamento.SelectedIndex
        '    If idDepartamento >= 0 Then
        '        idDepartamento = IIf(cmbdepartamento.SelectedIndex.ToString() <> "", Int(coll_Departamento(cmbdepartamento.SelectedIndex.ToString())), 0)
        '        If ModuUtil.SP_CONTROL_UBIGEO(3, idDepartamento) = True Then
        '            ModuUtil.LlenarComboIDs(ModuUtil.rst_cur_datos, cmbprovincia, ModVOCONTROLUSUARIO.coll_Provincia, Int(ModuUtil.rst_cur_datos.Fields.Item(0).Value))
        '        Else
        '            NingunoComboIDs(cmbprovincia, ModVOCONTROLUSUARIO.coll_Provincia)
        '            NingunoComboIDs(cmbdistrito, ModVOCONTROLUSUARIO.coll_Distrito)
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
    End Sub
    Private Sub txtubigeografica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnprovincia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprovincia.Click
        ' Dim Parametros() As String = {"Mantenimiento de Geográfico", "PKG_IVOPERSONA.SP_GRILLASUBICACION", "PKG_IVOPERSONA.SP_INSUPD_PAIS", "IDPAIS", "PAIS", "IDDEPARTAMENTO", "PAIS", "DEPARTAMENTO", "IDPROVINCIA", "PAIS", "DEPARTAMENTO", "PROVINCIA", "IDDISTRITO", "PAIS", "DEPARTAMENTO", "PROVINCIA", "DISTRITO", "ID PAIS", "NOMBRE DEL PAIS", "ID DEPARTAMENTO", "NOMBRE DEPARTAMENTO", "ID PROVINCIA", "NOMBRE PROVINCIA", "ID DISTRITO", "NOMBRE DISTRITO", "3", "MANT. PAISES", "MANT. DEPARTAMENTOS", "MANT. PROVINCIAS", "MANT. DISTRITOS"}
        ''''''''''''''''
        Try
            '    Modunitransporte.inumerocontrol = 3
            '    Dim FrmNuevoprovincia As Frmmantenimientosimple = New Frmmantenimientosimple
            '    Dim resultado As DialogResult = FrmNuevotipounidadtransporte.ShowDialog()
            '    If resultado = Windows.Forms.DialogResult.OK Then
            '        dttipounidad.Clear()
            '        dttipounidad = FrmNuevotipounidadtransporte.Nuevostipounidadtransporte.Copy
            '        Dim ElIngresadoEs As Integer = FrmNuevotipounidadtransporte.Ingresado
            '        dvtipounidad_creado = Funciones.CargarCombo(Cmbtipounidadm, dttipounidad, "tipo_unidad_transporte", "idtipo_unidad_transporte", ElIngresadoEs)
            '    End If
        Catch qex As Exception
            '    MessageBox.Show(qex.Message, "Seguridad del Sistema")
        End Try

        '        ''''''''''''''
        '        Dim a As FrmDosCampos = New FrmDosCampos(Parametros)
        '        Dim resultado As DialogResult = a.ShowDialog()

        '        If resultado = Windows.Forms.DialogResult.OK Then
        '            dtPaisCombo.Clear()
        '            dtDepartamentoCombo.Clear()
        '            dtProvinciaCombo.Clear()
        '            dtDistritoCombo.Clear()

        '            dtPaisCombo = a.dtPaisFinal.Copy
        '            dtDepartamentoCombo = a.dtDepartamentoFinal.Copy
        '            dtProvinciaCombo = a.dtProvinciaFinal.Copy
        '            dtDistritoCombo = a.dtDistritoFinal.Copy

        '            dvpais = dtPaisCombo.DefaultView
        '            dvdepartamento = dtDepartamentoCombo.DefaultView
        '            dvprovincia = dtProvinciaCombo.DefaultView
        '            dvdistrito = dtDistritoCombo.DefaultView

        '            cmbpais.DataSource = dvpais
        '            cmbpais.DisplayMember = "PAIS"
        '            cmbpais.ValueMember = "IDPAIS"

        '            Dim FiltroDepartamento As String = ""
        '            Dim MyParametroD As Integer = cmbpais.SelectedValue
        '            FiltroDepartamento = "IDPAIS = '" & MyParametroD & "'"
        '            dvdepartamento.RowFilter = FiltroDepartamento
        '            cmbdepartamento.DataSource = dvdepartamento
        '            cmbdepartamento.DisplayMember = "DEPARTAMENTO"
        '            cmbdepartamento.ValueMember = "IDDEPARTAMENTO"

        '            Dim FiltroProvincia As String = ""
        '            Dim MyParametroP As Integer = cmbdepartamento.SelectedValue
        '            FiltroProvincia = "IDDEPARTAMENTO = '" & MyParametroP & "'"
        '            dvprovincia.RowFilter = FiltroProvincia
        '            cmbprovincia.DataSource = dvprovincia
        '            cmbprovincia.DisplayMember = "PROVINCIA"
        '            cmbprovincia.ValueMember = "IDPROVINCIA"

        '            Dim FiltroDistrito As String = ""
        '            Dim MyParametroDs As Integer = cmbprovincia.SelectedValue
        '            FiltroDistrito = "IDPROVINCIA = '" & MyParametroDs & "'"
        '            dvdistrito.RowFilter = FiltroDistrito
        '            cmbdistrito.DataSource = dvdistrito
        '            cmbdistrito.DisplayMember = "DSITRITO"
        '            cmbdistrito.ValueMember = "IDDISTRITO"

        '            cmbpais.SelectedValue = a.PaisSeleccionado
        '            cmbdepartamento.SelectedValue = a.DepartamentoSeleccionado
        '            cmbprovincia.SelectedValue = a.ProvinciaSeleccionado

        '        End If
    End Sub
    Private Sub txtapellidos_y_nombres_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Btnaceptar.Focus()
    End Sub
    Sub devolviendo_direccion()
        ' Validando los campos que trae la funcion 
        Dim tipodireccion As Integer
        Dim iddistrito As Integer
        '
        tipodireccion = cmbtipodireccion.SelectedValue
        '
        iddistrito = CType(cmbdistrito.SelectedValue, Integer)
        ' Pasando las variables 
        Mod_otro_facturacion.sidpersona = Me.txtidpersona.Text
        Mod_otro_facturacion.siddireccion_consignado = Me.txtiddireccionconsignado.Text
        Mod_otro_facturacion.sruc = Me.txtruc.Text
        Mod_otro_facturacion.scliente = Me.txtcliente.Text
        Mod_otro_facturacion.iidrubro = Me.cmbrubro_frmmantclte.SelectedValue
        Mod_otro_facturacion.siddireccion_consignado = Me.txtdireccion.Text        
        '
        Mod_otro_facturacion.bcancelar = False
        'Grabando datos del Cliente y la Direccion legal 
        'graba_direccion()
        Me.Close()
    End Sub
    Sub limpiartodo()
        Mod_otro_facturacion.siddireccion_consignado = Nothing
        Mod_otro_facturacion.tipodireccion = Nothing
        Mod_otro_facturacion.idubigeo = Nothing
        Mod_otro_facturacion.idpais = Nothing
        Mod_otro_facturacion.iddpto = Nothing
        Mod_otro_facturacion.idprov = Nothing
        Mod_otro_facturacion.iddistrito = Nothing
        Mod_otro_facturacion.sdireccion = Nothing
        '
        ModSolRecojoCarga.bcancelar = True
        '
        Me.Close()
    End Sub
    'txtruc

    Private Sub mostrar_datos()
        Try
            Dim indexof As Integer = 0
            b_lee_cliente = True
            b_ingresa_cliente = False
            If Me.txtruc.Text <> "" Then
                If iWinPersona.Count > 0 Then
                    indexof = iWinPersonaRUC.IndexOf(txtruc.Text)
                    If indexof >= 0 Then
                        objmant_clte_facturacion.sidpersona = coll_Lista_Personas(indexof.ToString)
                        Me.txtidpersona.Text = objmant_clte_facturacion.sidpersona
                        If indexof <= iWinPersona.Count Then
                            Me.txtcliente.Text = iWinPersona.Item(indexof)
                            Me.cmbrubro_frmmantclte.SelectedValue = iWinPersonaRubro.Item(indexof)
                            Me.txtrepresentante_legal.Text = iWinrepresentante_legal.Item(indexof)
                            'Recupera Dirección Legal del Cliente 
                            recupera_direccion(Me.txtidpersona.Text) ' Omendoza 
                            b_lee_cliente = False
                        End If
                    Else
                        b_ingresa_cliente = True
                        'MsgBox("Cliente no encontrado...", MsgBoxStyle.Information, "Seguridad Sistema")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub txtruc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtruc.Leave
        Dim indexof As Integer = 0


        If iWinPersona.Count > 0 Then
            'indexof = IIf(iWinContacto_Remitente.IndexOf(txtRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtRemitente.Text), -1)
            indexof = IIf(iWinPersona.IndexOf(Me.txtcliente.Text) >= 0, iWinPersona.IndexOf(Me.txtcliente.Text), -1)

            If indexof >= 0 Then
                objOtras_facturas.sidpersona = coll_Lista_Personas(indexof.ToString)
                Me.txtidpersona.Text = objOtras_facturas.sidpersona
                If indexof <= iWinPersonaRUC.Count Then
                    Me.txtruc.Text = iWinPersonaRUC.Item(indexof)
                    'Me.cmbrubro_frmmantclte.SelectedValue = iWinPersonaRubro.Item(indexof)
                    'Recupera Dirección Legal del Cliente 
                    recupera_direccion(Me.txtidpersona.Text)
                    b_ingresa_cliente = False
                End If
            Else
                'datahelper
                'dv_persona_factura_otro = objFACTURA.sp_busca_liente_fac_otro(cnn, Me.txtruc.Text)
                dv_persona_factura_otro = objFACTURA.sp_busca_liente_fac_otro(Me.txtruc.Text)

                If dv_persona_factura_otro.Table.Rows.Count > 0 Then

                    Me.txtruc.Text = dv_persona_factura_otro.Table.Rows(0)("nu_docu_suna")
                    txtcliente.Text = dv_persona_factura_otro.Table.Rows(0)("razon_social")

                    If dv_persona_factura_otro.Table.Rows(0).IsNull("idrubro") Then
                        Me.cmbrubro_frmmantclte.SelectedValue = 475
                    Else
                        Me.cmbrubro_frmmantclte.SelectedValue = dv_persona_factura_otro.Table.Rows(0)("idrubro")
                    End If

                    If dv_persona_factura_otro.Table.Rows(0).IsNull("direccion") Then
                        txtdireccion.Text = ""
                    Else
                        txtdireccion.Text = dv_persona_factura_otro.Table.Rows(0)("direccion")
                    End If


                    txtidpersona.Text = dv_persona_factura_otro.Table.Rows(0)("idpersona")



                    If dv_persona_factura_otro.Table.Rows(0).IsNull("iddireccion_consignado") Then
                        txtiddireccionconsignado.Text = ""
                    Else
                        txtiddireccionconsignado.Text = dv_persona_factura_otro.Table.Rows(0)("iddireccion_consignado")
                    End If

                    If dv_persona_factura_otro.Table.Rows(0).IsNull("representante_legal") Then
                        txtrepresentante_legal.Text = ""
                    Else
                        txtrepresentante_legal.Text = dv_persona_factura_otro.Table.Rows(0)("representante_legal")
                    End If

                    b_lee_cliente = False
                Else
                    txtcliente.Text = ""
                    Me.cmbrubro_frmmantclte.SelectedValue = 475
                    txtdireccion.Text = ""
                    txtidpersona.Text = ""
                    txtiddireccionconsignado.Text = ""
                    txtrepresentante_legal.Text = ""

                    b_ingresa_cliente = True
                End If




                End If
            End If

    End Sub
    'txtcliente
    'Private Sub txtcliente_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcliente.Leave
    '    Dim indexof As Integer = 0

    '    If b_lee_cliente = True Then
    '        If iWinPersona.Count > 0 Then
    '            'indexof = IIf(iWinContacto_Remitente.IndexOf(txtRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtRemitente.Text), -1)
    '            indexof = IIf(iWinPersona.IndexOf(Me.txtcliente.Text) >= 0, iWinPersona.IndexOf(Me.txtcliente.Text), -1)

    '            If indexof >= 0 Then
    '                objOtras_facturas.sidpersona = coll_Lista_Personas(indexof.ToString)
    '                Me.txtidpersona.Text = objOtras_facturas.sidpersona
    '                If indexof <= iWinPersonaRUC.Count Then
    '                    Me.txtruc.Text = iWinPersonaRUC.Item(indexof)
    '                    'Me.cmbrubro_frmmantclte.SelectedValue = iWinPersonaRubro.Item(indexof)
    '                    'Recupera Dirección Legal del Cliente 
    '                    recupera_direccion(Me.txtidpersona.Text)
    '                    b_ingresa_cliente = False
    '                End If
    '            Else
    '                dv_persona_factura_otro = objFACTURA.sp_busca_liente_fac_otro(cnn, Me.txtruc.Text)
    '                If dv_persona_factura_otro.Table.Rows.Count > 0 Then

    '                    Me.txtruc.Text = dv_persona_factura_otro.Table.Rows(0)("nu_docu_suna")
    '                    txtcliente.Text = dv_persona_factura_otro.Table.Rows(0)("razon_social")

    '                    If dv_persona_factura_otro.Table.Rows(0).IsNull("idrubro") Then
    '                        Me.cmbrubro_frmmantclte.SelectedValue = 475
    '                    Else
    '                        Me.cmbrubro_frmmantclte.SelectedValue = dv_persona_factura_otro.Table.Rows(0)("idrubro")
    '                    End If

    '                    If dv_persona_factura_otro.Table.Rows(0).IsNull("direccion") Then
    '                        txtdireccion.Text = ""
    '                    Else
    '                        txtdireccion.Text = dv_persona_factura_otro.Table.Rows(0)("direccion")
    '                    End If


    '                    txtidpersona.Text = dv_persona_factura_otro.Table.Rows(0)("idpersona")



    '                    If dv_persona_factura_otro.Table.Rows(0).IsNull("iddireccion_consignado") Then
    '                        txtdireccion.Text = ""
    '                    Else
    '                        txtdireccion.Text = dv_persona_factura_otro.Table.Rows(0)("iddireccion_consignado")
    '                    End If

    '                    If dv_persona_factura_otro.Table.Rows(0).IsNull("representante_legal") Then
    '                        txtrepresentante_legal.Text = ""
    '                    Else
    '                        txtrepresentante_legal.Text = dv_persona_factura_otro.Table.Rows(0)("representante_legal")
    '                    End If

    '                    b_lee_cliente = False
    '                Else
    '                    b_ingresa_cliente = True
    '                End If




    '            End If
    '        End If
    '    End If
    'End Sub
    Sub recupera_direccion2009(ByVal vidpersona As String)
        'Try
        '    objmant_clte_facturacion.sidpersona = vidpersona
        '    If objmant_clte_facturacion.fn_recupera_persona = True Then
        '        'Recupera la Razon Social 
        '        If IsDBNull(objmant_clte_facturacion.rst_cliente.Fields.Item("idrubro").Value) = True Then
        '            Me.cmbrubro_frmmantclte.SelectedValue = -666
        '        Else
        '            Me.cmbrubro_frmmantclte.SelectedValue = CType(objmant_clte_facturacion.rst_cliente.Fields.Item("idrubro").Value, String)
        '        End If

        '        'Recupera la Razon Social 
        '        If IsDBNull(objmant_clte_facturacion.rst_cliente.Fields.Item("razon_social").Value) = True Then
        '            Me.txtcliente.Text = ""
        '        Else
        '            Me.txtcliente.Text = CType(objmant_clte_facturacion.rst_cliente.Fields.Item("razon_social").Value, String)
        '        End If

        '        'Representante legal 
        '        If IsDBNull(objmant_clte_facturacion.rst_cliente.Fields.Item("representante_legal").Value) = True Then
        '            Me.txtrepresentante_legal.Text = ""
        '        Else
        '            Me.txtrepresentante_legal.Text = CType(objmant_clte_facturacion.rst_cliente.Fields.Item("representante_legal").Value, String)
        '        End If
        '        'Recupera el RUC 
        '        If IsDBNull(objmant_clte_facturacion.rst_cliente.Fields.Item("nu_docu_suna").Value) = True Then
        '            Me.txtruc.Text = ""
        '        Else
        '            Me.txtruc.Text = CType(objmant_clte_facturacion.rst_cliente.Fields.Item("nu_docu_suna").Value, String)
        '        End If
        '        'Rubro 
        '        If IsDBNull(objmant_clte_facturacion.rst_cliente.Fields.Item("idrubro").Value) = True Then
        '            Me.cmbrubro_frmmantclte.SelectedValue = -666
        '        Else
        '            Me.cmbrubro_frmmantclte.SelectedValue = CType(objmant_clte_facturacion.rst_cliente.Fields.Item("idrubro").Value, Long)
        '        End If
        '        If (objmant_clte_facturacion.rst_direccion_local.EOF = True And objmant_clte_facturacion.rst_direccion_local.BOF = True) Then
        '            ' No tiene dirección 
        '            Exit Sub
        '        Else
        '            ' Tipo Direccion 
        '            If IsDBNull(objmant_clte_facturacion.rst_direccion_local.Fields.Item("idtipo_direccion").Value) = True Then
        '                Me.cmbtipodireccion.SelectedValue = 1   'Tipo Dirección  
        '            Else
        '                Me.cmbtipodireccion.SelectedValue = CType(objmant_clte_facturacion.rst_direccion_local.Fields.Item("idtipo_direccion").Value, Long)
        '            End If
        '            ' País 
        '            If IsDBNull(objmant_clte_facturacion.rst_direccion_local.Fields.Item("IDPAIS").Value) = True Then
        '                Me.cmbpais.SelectedValue = -666
        '            Else
        '                Me.cmbpais.SelectedValue = CType(objmant_clte_facturacion.rst_direccion_local.Fields.Item("IDPAIS").Value, Long)
        '            End If
        '            ' Departamento 
        '            If IsDBNull(objmant_clte_facturacion.rst_direccion_local.Fields.Item("IDDEPARTAMENTO").Value) = True Then
        '                Me.cmbdepartamento.SelectedValue = -666
        '            Else
        '                Me.cmbdepartamento.SelectedValue = CType(objmant_clte_facturacion.rst_direccion_local.Fields.Item("IDDEPARTAMENTO").Value, Long)
        '            End If
        '            ' Provincia 
        '            If IsDBNull(objmant_clte_facturacion.rst_direccion_local.Fields.Item("IDPROVINCIA").Value) = True Then
        '                Me.cmbprovincia.SelectedValue = -666
        '            Else
        '                Me.cmbprovincia.SelectedValue = CType(objmant_clte_facturacion.rst_direccion_local.Fields.Item("IDPROVINCIA").Value, Long)
        '            End If
        '            ' Distrito 
        '            If IsDBNull(objmant_clte_facturacion.rst_direccion_local.Fields.Item("IDDISTRITO").Value) = True Then
        '                Me.cmbdistrito.SelectedValue = -666
        '            Else
        '                Me.cmbdistrito.SelectedValue = CType(objmant_clte_facturacion.rst_direccion_local.Fields.Item("IDDISTRITO").Value, Long)
        '            End If
        '            ' Dirección 
        '            If IsDBNull(objmant_clte_facturacion.rst_direccion_local.Fields.Item("DIRECCION").Value) = True Then
        '                Me.txtdireccion.Text = ""
        '            Else
        '                Me.txtdireccion.Text = CType(objmant_clte_facturacion.rst_direccion_local.Fields.Item("DIRECCION").Value, String)
        '            End If
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        'End Try
    End Sub
    Sub graba_direccion()
        Dim sidpersona As String

        Try
            If Me.txtidpersona.Text = "" Then
                objmant_clte_facturacion.icontrol = 1
                objmant_clte_facturacion.sidpersona = "null"
            Else
                objmant_clte_facturacion.icontrol = 2
                objmant_clte_facturacion.sidpersona = Me.txtidpersona.Text
            End If
            If Me.txtcliente.Text = "" Then
                objmant_clte_facturacion.srazon_social = "null"
            Else
                objmant_clte_facturacion.srazon_social = Me.txtcliente.Text
            End If
            If Me.txtrepresentante_legal.Text = "" Then
                objmant_clte_facturacion.srepresentante_legal = "null"
            Else
                objmant_clte_facturacion.srepresentante_legal = Me.txtrepresentante_legal.Text
            End If
            If Me.txtruc.Text = "" Then
                objmant_clte_facturacion.sruc = "null"
            Else
                objmant_clte_facturacion.sruc = Me.txtruc.Text
            End If
            If Me.cmbrubro_frmmantclte.SelectedValue < 0 Then
                objmant_clte_facturacion.lidrubro = -666
            Else
                objmant_clte_facturacion.lidrubro = CType(Me.cmbrubro_frmmantclte.SelectedValue, Long)
            End If
            objmant_clte_facturacion.lidusuario_personal = dtoUSUARIOS.IdLogin
            objmant_clte_facturacion.lidrol = dtoUSUARIOS.IdRol
            objmant_clte_facturacion.sip = dtoUSUARIOS.IP

            'IDDIRECCION_CONSIGNADO NO SE MUESTRA

            If Me.txtiddireccionconsignado.Text = "" Then
                objmant_clte_facturacion.sididdireccion_consigna = "null"
            Else
                objmant_clte_facturacion.sididdireccion_consigna = Me.txtiddireccionconsignado.Text
            End If
            If Me.txtdireccion.Text = "" Then
                objmant_clte_facturacion.sdireccion = "null"
            Else
                objmant_clte_facturacion.sdireccion = Me.txtdireccion.Text
            End If
            objmant_clte_facturacion.lidpais = Me.cmbpais.SelectedValue

            '''''''''''''''''''''''''''''''                                  

            'liddepartamento, 1, _
            'lidprovincia, 1, _
            'liddistrito, 1

            '''''''''''''''''''''''''''''''''
            'idpais = CType(cmbpais.SelectedValue, Integer)
            'iddpto = CType(cmbdepartamento.SelectedValue, Integer)
            'idprov = CType(cmbprovincia.SelectedValue, Integer)
            'If IsDBNull(cmbdistrito.SelectedValue) Then
            '    smensaje = "No a ingresado el distrito"
            '    MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    cmbdistrito.Focus()
            '    Exit Sub
            'End If
            'iddistrito = CType(cmbdistrito.SelectedValue, Integer)
            ''
            'If IsDBNull(txtdireccion.Text) = True Then
            '    smensaje = "No a ingresado la dirección"
            '    MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    txtdireccion.Focus()
            '    Exit Sub
            'Else
            '    If txtdireccion.Text = "" Then
            '        smensaje = "No a ingresado la dirección"
            '        MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        txtdireccion.Focus()
            '        Exit Sub
            '    End If
            'End If
            'sdireccion = txtdireccion.Text
            ''
            'If IsDBNull(txtiddireccionconsignado.Text) = True Then
            '    siddireccion_consignado = 0
            'Else
            '    If txtiddireccionconsignado.Text = "" Then
            '        siddireccion_consignado = 0
            '    Else
            '        siddireccion_consignado = CType(txtiddireccionconsignado.Text, String)
            '    End If
            'End If
            '' Pasando las variables 
            'Mod_otro_facturacion.siddireccion_consignado = siddireccion_consignado
            'Mod_otro_facturacion.tipodireccion = tipodireccion
            'Mod_otro_facturacion.idubigeo = idubigeo
            'Mod_otro_facturacion.idpais = idpais
            'Mod_otro_facturacion.iddpto = iddpto
            'Mod_otro_facturacion.idprov = idprov
            'Mod_otro_facturacion.iddistrito = iddistrito
            'Mod_otro_facturacion.sdireccion = sdireccion
            'Mod_otro_facturacion.bcancelar = False
        Catch ex As Exception

        End Try
    End Sub
    Function fn_graba_cliente_direccion() As Boolean
        Dim smensaje As String
        Try
            'Validando los campos necesarios 
            Dim MyObligatorios As Object() = {Me.txtruc, Me.txtcliente, Me.txtdireccion}
            If Funciones.Validaciones(MyObligatorios) <> 0 Then
                Return False
            End If
            If Me.txtidpersona.Text = "" Then
                objmant_clte_facturacion.icontrol = 1
                objmant_clte_facturacion.sidpersona = "null"

            Else
                objmant_clte_facturacion.icontrol = 2
                objmant_clte_facturacion.sidpersona = Me.txtidpersona.Text
            End If
            ' 
            If Me.txtcliente.Text = "" Then
                objmant_clte_facturacion.srazon_social = "null"
            Else
                objmant_clte_facturacion.srazon_social = Me.txtcliente.Text
            End If
            '
            If Me.txtrepresentante_legal.Text = "" Then
                objmant_clte_facturacion.srepresentante_legal = "null"
            Else
                objmant_clte_facturacion.srepresentante_legal = Me.txtrepresentante_legal.Text
            End If
            '
            If Me.txtruc.Text = "" Then
                objmant_clte_facturacion.sruc = "null"
            Else
                objmant_clte_facturacion.sruc = Me.txtruc.Text
            End If
            ' 
            objmant_clte_facturacion.lidrubro = Me.cmbrubro_frmmantclte.SelectedValue
            objmant_clte_facturacion.lidusuario_personal = dtoUSUARIOS.IdLogin
            objmant_clte_facturacion.lidrol = dtoUSUARIOS.IdRol
            objmant_clte_facturacion.sip = dtoUSUARIOS.IP
            '




            If Me.txtiddireccionconsignado.Text = "" Then
                objmant_clte_facturacion.sididdireccion_consigna = "null"
            Else
                
                objmant_clte_facturacion.sididdireccion_consigna = Me.txtiddireccionconsignado.Text
            End If
            ' 



            If Me.txtdireccion.Text = "" Then
                objmant_clte_facturacion.sdireccion = "null"
            Else
                objmant_clte_facturacion.sdireccion = Me.txtdireccion.Text
            End If
            ' 
            objmant_clte_facturacion.lidpais = Me.cmbpais.SelectedValue
            objmant_clte_facturacion.liddepartamento = Me.cmbdepartamento.SelectedValue
            objmant_clte_facturacion.lidprovincia = Me.cmbprovincia.SelectedValue
            objmant_clte_facturacion.liddistrito = Me.cmbdistrito.SelectedValue

            objmant_clte_facturacion.sidireccionconsignado = Mod_otro_facturacion.siddireccion_consignado

            If objmant_clte_facturacion.fn_graba_cliente() = True Then

                MsgBox("El registro se grabó correctamente", MsgBoxStyle.Information, "Sistema de Seguridad")
                If CType(objmant_clte_facturacion.rst_mensaje.Rows(0).Item("cod_msj").ToString, Long) <> 0 Then
                    smensaje = CType(objmant_clte_facturacion.rst_mensaje.Rows(0).Item("cod_msj").ToString, String)
                    Return False
                Else
                    Me.txtidpersona.Text = CType(objmant_clte_facturacion.rst_graba.Rows(0).Item("idpersona").ToString, String)
                    Me.txtiddireccionconsignado.Text = CType(objmant_clte_facturacion.rst_graba.Rows(0).Item("iddireccion").ToString, String)
                End If

                'datahelper
                'If CType(objmant_clte_facturacion.rst_mensaje.Fields.Item("cod_msj").Value, Long) <> 0 Then
                '    smensaje = CType(objmant_clte_facturacion.rst_mensaje.Fields.Item("cod_msj").Value, String)
                '    Return False
                'Else
                '    Me.txtidpersona.Text = CType(objmant_clte_facturacion.rst_graba.Fields.Item("idpersona").Value, String)
                '    Me.txtiddireccionconsignado.Text = CType(objmant_clte_facturacion.rst_graba.Fields.Item("iddireccion").Value, String)
                'End If
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
            Return False
        End Try
    End Function

    Sub recupera_direccion(ByVal vidpersona As String)
        Try
            objmant_clte_facturacion.sidpersona = vidpersona
            If objmant_clte_facturacion.fn_recupera_persona = True Then
                'Recupera la Razon Social 
                If IsDBNull(objmant_clte_facturacion.rst_cliente.Rows(0).Item("idrubro").ToString) = True Then
                    Me.cmbrubro_frmmantclte.SelectedValue = -666
                Else
                    Me.cmbrubro_frmmantclte.SelectedValue = CType(objmant_clte_facturacion.rst_cliente.Rows(0).Item("idrubro").ToString, String)
                End If

                'Recupera la Razon Social 
                If IsDBNull(objmant_clte_facturacion.rst_cliente.Rows(0).Item("razon_social").ToString) = True Then
                    Me.txtcliente.Text = ""
                Else
                    Me.txtcliente.Text = CType(objmant_clte_facturacion.rst_cliente.Rows(0).Item("razon_social").ToString, String)
                End If

                'Representante legal 
                If IsDBNull(objmant_clte_facturacion.rst_cliente.Rows(0).Item("representante_legal")) = True Then
                    Me.txtrepresentante_legal.Text = ""
                Else
                    Me.txtrepresentante_legal.Text = CType(objmant_clte_facturacion.rst_cliente.Rows(0).Item("representante_legal").ToString, String)
                End If
                'Recupera el RUC 
                If IsDBNull(objmant_clte_facturacion.rst_cliente.Rows(0).Item("nu_docu_suna")) = True Then
                    Me.txtruc.Text = ""
                Else
                    Me.txtruc.Text = CType(objmant_clte_facturacion.rst_cliente.Rows(0).Item("nu_docu_suna").ToString, String)
                End If
                'Rubro 
                If IsDBNull(objmant_clte_facturacion.rst_cliente.Rows(0).Item("idrubro").ToString) = True Then
                    Me.cmbrubro_frmmantclte.SelectedValue = -666
                Else
                    Me.cmbrubro_frmmantclte.SelectedValue = CType(objmant_clte_facturacion.rst_cliente.Rows(0).Item("idrubro").ToString, Long)
                End If
                If (objmant_clte_facturacion.rst_direccion_local.Rows.Count = 0) Then
                    ' No tiene dirección 
                    Exit Sub
                Else
                    ' Tipo Direccion 
                    If IsDBNull(objmant_clte_facturacion.rst_direccion_local.Rows(0).Item("idtipo_direccion")) = True Then
                        Me.cmbtipodireccion.SelectedValue = 1   'Tipo Dirección  
                    Else
                        Me.cmbtipodireccion.SelectedValue = CType(objmant_clte_facturacion.rst_direccion_local.Rows(0).Item("idtipo_direccion").ToString, Long)
                    End If
                    ' País 
                    If IsDBNull(objmant_clte_facturacion.rst_direccion_local.Rows(0).Item("IDPAIS")) = True Then
                        Me.cmbpais.SelectedValue = -666
                    Else
                        Me.cmbpais.SelectedValue = CType(objmant_clte_facturacion.rst_direccion_local.Rows(0).Item("IDPAIS").ToString, Long)
                    End If
                    ' Departamento 
                    If IsDBNull(objmant_clte_facturacion.rst_direccion_local.Rows(0).Item("IDDEPARTAMENTO")) = True Then
                        Me.cmbdepartamento.SelectedValue = -666
                    Else
                        Me.cmbdepartamento.SelectedValue = CType(objmant_clte_facturacion.rst_direccion_local.Rows(0).Item("IDDEPARTAMENTO"), Long)
                    End If
                    ' Provincia 
                    If IsDBNull(objmant_clte_facturacion.rst_direccion_local.Rows(0).Item("IDPROVINCIA")) = True Then
                        Me.cmbprovincia.SelectedValue = -666
                    Else
                        Me.cmbprovincia.SelectedValue = CType(objmant_clte_facturacion.rst_direccion_local.Rows(0).Item("IDPROVINCIA").ToString, Long)
                    End If
                    ' Distrito 
                    If IsDBNull(objmant_clte_facturacion.rst_direccion_local.Rows(0).Item("IDDISTRITO")) = True Then
                        Me.cmbdistrito.SelectedValue = -666
                    Else
                        Me.cmbdistrito.SelectedValue = CType(objmant_clte_facturacion.rst_direccion_local.Rows(0).Item("IDDISTRITO").ToString, Long)
                    End If
                    ' Dirección 
                    If IsDBNull(objmant_clte_facturacion.rst_direccion_local.Rows(0).Item("DIRECCION")) = True Then
                        Me.txtdireccion.Text = ""
                    Else
                        Me.txtdireccion.Text = CType(objmant_clte_facturacion.rst_direccion_local.Rows(0).Item("DIRECCION").ToString, String)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub Btnaceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnaceptar.Click
        Me.Aceptar()
    End Sub

    Sub Aceptar()
        Try
            'Grabar Cliente  y direccion 
            If validar() = False Then Exit Sub

            If fn_graba_cliente_direccion() = False Then
                Exit Sub
            End If
            'Devolviendo la direccion y el contacto
            devolviendo_direccion()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtcliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcliente.KeyPress
        If Not ValidarLetraNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtcliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtcliente.TextChanged

    End Sub
End Class