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
Public Class FrmMantClteCarga
    'Dim dr4 As New OleDb.OleDbDataAdapter
    'Datos de la persona 
    Dim mypersona As New dtoSolicitudRecojoCarga
    'datahelper
    'Recuperando los recordset 
    'Dim rsttipodireccion, rstpais, rstdepartamento, rstprovincia, rstdistrito, rstctrocosto As New ADODB.Recordset
    Dim rsttipodireccion, rstpais, rstdepartamento, rstprovincia, rstdistrito, rstctrocosto As DataTable
    'datahelper
    'Dim rsttipocontacto, rsttipodcto, rstagencia, rstdireccionconsignado As New ADODB.Recordset
    Dim rsttipocontacto, rsttipodcto, rstagencia, rstdireccionconsignado As DataTable
    'Recupera datatable 
    Dim dttipdireccion, dtpais, dtdepartamento, dtprovincia, dtdistrito, dtctrocosto, dttipcontacto, dttipdcto, dtagencia As New DataTable
    Dim dtdireccionconsignado As New DataTable
    'Recupera dataview
    Dim dvtipdireccion, dvpais, dvdepartamento, dvprovincia, dvdistrito, dvctrocosto, dvtipcontacto, dvtipdcto, dvagencia As New DataView
    Dim dvdireccionconsignado As New DataView
    '
    Dim iddistrito, idprovincia, iddepartamento, idpais, nomagencvia As String
    Dim drvAgencia As DataRowView
    Public hnd As Long
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Try
            If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
                SendKeys.Send("{Tab}")
                Return True
            End If
            If msg.WParam.ToInt32() = CInt(Keys.F5) Then
                devolviendo_direccion()
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

    Private Sub FrmMantClteCarga_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmMantClteCarga_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmMantClteCarga_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Recuperando el distrito de la agencia 
        Try
            ' Por defecto se esta poniendo este valor igual que el frm_cliente
            txtubigeografica.Text = "00000"
            '
            mypersona.idagencia = ModSolRecojoCarga.idagencia
            mypersona.direccionconsignado = ModSolRecojoCarga.iddireccion_consignado
            '
            'Se deben cargar los datos los combos
            'datahelper
            Dim ds As DataSet = mypersona.get_persona
            rsttipodireccion = ds.Tables(0)
            rstpais = ds.Tables(1)
            rstdepartamento = ds.Tables(2)
            rstprovincia = ds.Tables(3)
            rstdistrito = ds.Tables(4)
            rstctrocosto = ds.Tables(5)
            rsttipocontacto = ds.Tables(6)
            rsttipodcto = ds.Tables(7)
            rstagencia = ds.Tables(8)
            rstdireccionconsignado = ds.Tables(9)
            ' Llenando los combos 
            dttipdireccion = rsttipodireccion
            Dim ltipodireccion As Integer
            ltipodireccion = dttipdireccion.Rows(0).Item(0)
            dvtipdireccion = CargarCombo(cmbtipdireccion, dttipdireccion, "TIPO_DIRECCION", "IDTIPO_DIRECCION", ltipodireccion)
            ' País 
            'Recuperando el pais,departamento, provincia, distrito  
            dtagencia = rstagencia
            'Recuperando el valor del pais 
            idpais = CType(dtagencia.Rows(0).Item(3), Integer)
            iddepartamento = CType(dtagencia.Rows(0).Item(2), Integer)
            idprovincia = CType(dtagencia.Rows(0).Item(1), Integer)
            iddistrito = CType(dtagencia.Rows(0).Item(0), Integer)
            '
            dtpais = rstpais

            dvpais = CargarCombo(cmbpais, dtpais, "PAIS", "IDPAIS", idpais)
            ' Departamento 
            dtdepartamento = rstdepartamento
            dvdepartamento = dtdepartamento.DefaultView
            dvdepartamento.AllowNew = False
            'Se debe filtrar de acuerdo al pais seleccionadao 
            '
            dvdepartamento = CargarCombo(cmbdepartamento, dtdepartamento, "DEPARTAMENTO", "IDDEPARTAMENTO", iddepartamento)
            '' Provincia 
            dtprovincia = rstprovincia
            dvprovincia = dtprovincia.DefaultView
            dvprovincia.AllowNew = False
            Dim FiltroProvincia As String = ""
            FiltroProvincia = "IDPAIS =  " & idpais & " and IDDEPARTAMENTO  = " & iddepartamento
            dvprovincia.RowFilter = FiltroProvincia
            '
            dvprovincia = CargarCombo(cmbprovincia, dtprovincia, "PROVINCIA", "IDPROVINCIA", idprovincia)
            '' Distritos 
            dtdistrito = rstdistrito
            dvdistrito = dtdistrito.DefaultView
            dvdistrito.AllowNew = False
            dvdistrito = CargarCombo(cmbdistrito, dtdistrito, "DSITRITO", "IDDISTRITO", iddistrito)
            ' Centro costo 
            dtctrocosto = rstctrocosto
            dvctrocosto = dtctrocosto.DefaultView
            dvctrocosto.AllowNew = False
            dvctrocosto = CargarCombo(cmbsubcuenta, dtctrocosto, "CENTRO_COSTO", "IDCENTRO_COSTO", 9) 'Por defecto 9 Recojo de carga
            '''''''''''''''''
            ' Tipo contacto 
            dttipcontacto = rsttipocontacto
            dvtipcontacto = dttipcontacto.DefaultView
            dvtipcontacto.AllowNew = False
            dvtipcontacto = CargarCombo(cmbcargo, dttipcontacto, "TIPO_CONTACTO", "IDTIPO_CONTACTO", 3)
            ' Tipo documento identidad 
            dttipdcto = rsttipodcto
            dvtipdcto = dttipdcto.DefaultView
            dvtipdcto.AllowNew = False
            dvtipcontacto = CargarCombo(cmbtipodcto, dttipdcto, "TIPO_DOC_IDENTIDAD", "IDTIPO_DOC_IDENTIDAD", 3)
            ' Por defecto, masculino 
            rbtmasculino.Checked = True
            '''''''''''''
            dtdireccionconsignado = rstdireccionconsignado
            If dtdireccionconsignado.Rows.Count = 1 Then
                ' Recupera información de la dirección si lo tuviese 
                cmbtipdireccion.SelectedValue = CType(dtdireccionconsignado.Rows(0).Item(0), Integer)
                If IsDBNull(dtdireccionconsignado.Rows(0).Item(1)) = False Then
                    txtubigeografica.Text = CType(dtdireccionconsignado.Rows(0).Item(1), Integer)
                End If
                txtubigeografica.Enabled = False
                cmbpais.SelectedValue = CType(dtdireccionconsignado.Rows(0).Item(2), Integer)
                cmbpais.Enabled = False
                cmbdepartamento.SelectedValue = dtdireccionconsignado.Rows(0).Item(3)
                cmbdepartamento.Enabled = False
                cmbprovincia.SelectedValue = dtdireccionconsignado.Rows(0).Item(4)
                cmbprovincia.Enabled = False
                cmbdistrito.SelectedValue = dtdireccionconsignado.Rows(0).Item(5)
                cmbdistrito.Enabled = False
                txtdireccion.Text = dtdireccionconsignado.Rows(0).Item(6)
                txtdireccion.Enabled = False
                txtrefllegada.Text = dtdireccionconsignado.Rows(0).Item(7)
                txtrefllegada.Enabled = False
                ' 
                txtnrodocumento.Focus()
            End If
            '

            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)

        Catch exp As Exception
            MsgBox(exp.ToString, MsgBoxStyle.Exclamation, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub Btncancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btncancelar.Click
        limpiartodo()
        ''Se debe limpiar las variables 
        'ModSolRecojoCarga.iddireccion_consignado = Nothing
        'ModSolRecojoCarga.tipodireccion = Nothing
        'ModSolRecojoCarga.idubigeo = Nothing
        'ModSolRecojoCarga.idpais = Nothing
        'ModSolRecojoCarga.iddpto = Nothing
        'ModSolRecojoCarga.idprov = Nothing
        'ModSolRecojoCarga.iddistrito = Nothing
        'ModSolRecojoCarga.sdireccion = Nothing
        'ModSolRecojoCarga.srefllegada = Nothing
        'ModSolRecojoCarga.snrodcto = Nothing
        'ModSolRecojoCarga.sapellidos_nombres = Nothing
        ''ModSolRecojoCarga.snombre = Nothing
        ''ModSolRecojoCarga.sapepaterno = Nothing
        ''ModSolRecojoCarga.sapematerno = Nothing
        'ModSolRecojoCarga.idsucuenta = Nothing
        'ModSolRecojoCarga.idcargo = Nothing
        'ModSolRecojoCarga.idtipdcto = Nothing
        'ModSolRecojoCarga.idsexo = Nothing
        ''
        'ModSolRecojoCarga.bcancelar = True
        ''
        'Me.Close()
    End Sub
    Private Sub cmbprovincia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprovincia.SelectedIndexChanged
        'Try
        '    Dim idProvicnia As Integer
        '    idProvicnia = cmbprovincia.SelectedIndex
        '    If idProvicnia >= 0 Then
        '        idProvicnia = IIf(cmbprovincia.SelectedIndex.ToString() <> "", Int(coll_Provincia(cmbprovincia.SelectedIndex.ToString())), 0)
        '        If ModuUtil.SP_CONTROL_UBIGEO(4, idProvicnia) = True Then
        '            ModuUtil.LlenarComboIDs(ModuUtil.rst_cur_datos, cmbdistrito, ModVOCONTROLUSUARIO.coll_Distrito, Int(ModuUtil.rst_cur_datos.Fields.Item(0).Value))
        '        Else
        '            NingunoComboIDs(cmbdistrito, ModVOCONTROLUSUARIO.coll_Distrito)
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
        Dim posicion As Integer
        Dim drv As DataRowView
        Dim prov As Integer
        Dim FiltroDistrito As String
        Dim iidpais As Integer
        Dim iiddepartamento As Integer
        ' 
        posicion = cmbprovincia.SelectedIndex()
        If posicion >= 0 Then
            drv = dvprovincia.Item(posicion)
            prov = IIf(IsDBNull(drv("IDPROVINCIA")) = True, "0", drv("IDPROVINCIA").ToString)
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
    End Sub
    Private Sub Btnaceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnaceptar.Click
        'Devolviendo la direccion y el contacto
        devolviendo_direccion()
        '' Validando los campos que trae la funcion 
        'Dim tipodireccion, idubigeo As Integer
        'Dim idpais, iddpto, idprov, iddistrito As Integer
        'Dim sdireccion, smensaje, srefllegada, snrodcto As String
        'Dim sapellidos_nombres1 As String
        ''Dim snombre, sapepaterno, sapematerno As String
        'Dim idsucuenta, idcargo, idtipdcto, idsexo As Integer
        'Dim iidireccion_consignado As Integer
        ''
        'tipodireccion = cmbtipdireccion.SelectedValue
        'If txtubigeografica.Text = "" Then
        '    idubigeo = txtubigeografica.Text = "00000"
        'Else
        '    idubigeo = CType(txtubigeografica.Text, Integer)
        'End If
        ''If txtubigeografica.Text = "" Then
        ''    smensaje = "No a ingresado la ubicación geográfica"
        ''    MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''    txtubigeografica.Focus()
        ''    Return
        ''End If

        ''
        'idpais = CType(cmbpais.SelectedValue, Integer)
        'iddpto = CType(cmbdepartamento.SelectedValue, Integer)
        'idprov = CType(cmbprovincia.SelectedValue, Integer)
        'If IsDBNull(cmbdistrito.SelectedValue) Then
        '    smensaje = "No a ingresado el distrito"
        '    MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    cmbdistrito.Focus()
        '    Return
        'End If
        'iddistrito = CType(cmbdistrito.SelectedValue, Integer)
        ''
        'If IsDBNull(txtdireccion.Text) = True Then
        '    smensaje = "No a ingresado la dirección"
        '    MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtdireccion.Focus()
        '    Return
        'Else
        '    If txtdireccion.Text = "" Then
        '        smensaje = "No a ingresado la dirección"
        '        MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        txtdireccion.Focus()
        '        Return
        '    End If
        'End If
        'sdireccion = txtdireccion.Text
        'If IsDBNull(txtrefllegada.Text) = True Then
        '    srefllegada = "null"
        'Else
        '    srefllegada = txtrefllegada.Text
        'End If
        'idsucuenta = CType(cmbsubcuenta.SelectedValue, Integer)
        'idcargo = CType(cmbcargo.SelectedValue, Integer)
        'idtipdcto = CType(cmbtipodcto.SelectedValue, Integer)
        ''
        'If IsDBNull(txtnrodocumento.Text) = True Then
        '    smensaje = "No a ingresado el número documento"
        '    MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtnrodocumento.Focus()
        '    Return
        'Else
        '    If txtnrodocumento.Text = "" Then
        '        smensaje = "No a ingresado el número documento"
        '        MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        txtnrodocumento.Focus()
        '        Return
        '    End If
        'End If
        'snrodcto = CType(txtnrodocumento.Text, String)
        'If IsDBNull(txtapellidos_y_nombres.Text) = True Then
        '    smensaje = "No a ingresado  apellidos y nombre"
        '    MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtapellidos_y_nombres.Focus()
        '    Return
        'Else
        '    If txtapellidos_y_nombres.Text = "" Then
        '        smensaje = "No a ingresado  apellidos y nombre"
        '        MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        txtapellidos_y_nombres.Focus()
        '        Return
        '    End If
        'End If
        'sapellidos_nombres1 = CType(txtapellidos_y_nombres.Text, String)
        ''snombre = CType(txtnombre.Text, String)
        ''If IsDBNull(txtpaterno.Text) = True Then
        ''    smensaje = "No a ingresado el apellido paterno"
        ''    MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''    txtpaterno.Focus()
        ''    Return
        ''Else
        ''    If txtpaterno.Text = "" Then
        ''        smensaje = "No a ingresado el apellido paterno"
        ''        MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''        txtpaterno.Focus()
        ''        Return
        ''    End If
        ''End If
        ''sapepaterno = CType(txtpaterno.Text, String)
        ' ''
        ''If IsDBNull(txtapematerno.Text) = True Then
        ''    sapematerno = " "
        ''Else
        ''    sapematerno = CType(txtapematerno.Text, String)
        ''End If
        'If rbtmasculino.Checked = True Then
        '    idsexo = 1
        'End If
        'If rbtfemenino.Checked = True Then
        '    idsexo = 2
        'End If
        ''
        'If IsDBNull(txtiddireccionconsignado.Text) = True Then
        '    iidireccion_consignado = 0
        'Else
        '    If txtiddireccionconsignado.Text = "" Then
        '        iidireccion_consignado = 0
        '    Else
        '        iidireccion_consignado = CType(txtiddireccionconsignado.Text, Integer)
        '    End If
        'End If
        '' Pasando las variables 
        'ModSolRecojoCarga.iddireccion_consignado = iidireccion_consignado
        'ModSolRecojoCarga.tipodireccion = tipodireccion
        'ModSolRecojoCarga.idubigeo = idubigeo
        'ModSolRecojoCarga.idpais = idpais
        'ModSolRecojoCarga.iddpto = iddpto
        'ModSolRecojoCarga.idprov = idprov
        'ModSolRecojoCarga.iddistrito = iddistrito
        'ModSolRecojoCarga.sdireccion = sdireccion
        'ModSolRecojoCarga.srefllegada = srefllegada
        'ModSolRecojoCarga.snrodcto = snrodcto
        'ModSolRecojoCarga.sapellidos_nombres = sapellidos_nombres1
        ''ModSolRecojoCarga.snombre = snombre
        ''ModSolRecojoCarga.sapepaterno = sapepaterno
        ''ModSolRecojoCarga.sapematerno = sapematerno
        'ModSolRecojoCarga.idsucuenta = idsucuenta
        'ModSolRecojoCarga.idcargo = idcargo
        'ModSolRecojoCarga.idtipdcto = idtipdcto
        'ModSolRecojoCarga.idsexo = idsexo
        'ModSolRecojoCarga.bcancelar = False
        ''
        'Me.Close()
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
    Private Sub txtubigeografica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtubigeografica.KeyPress
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
    Private Sub txtrefllegada_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrefllegada.Validated
        txtnrodocumento.Focus()
    End Sub
    Private Sub txtnrodocumento_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtnrodocumento.Validating
        txtapellidos_y_nombres.Focus()
    End Sub
    Private Sub txtnrodocumento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnrodocumento.KeyPress
        Dim tb As TextBox = CType(sender, TextBox)
        Dim chr As Char = e.KeyChar
        Try
            If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub
    Private Sub txtapellidos_y_nombres_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtapellidos_y_nombres.Validating
        Btnaceptar.Focus()
    End Sub
    Sub devolviendo_direccion()
        ' Validando los campos que trae la funcion 
        Dim tipodireccion, idubigeo As Integer
        Dim idpais, iddpto, idprov, iddistrito As Integer
        Dim sdireccion, smensaje, srefllegada, snrodcto As String
        Dim sapellidos_nombres1 As String
        'Dim snombre, sapepaterno, sapematerno As String
        Dim idsucuenta, idcargo, idtipdcto, idsexo As Integer
        Dim iidireccion_consignado As Integer
        '
        tipodireccion = cmbtipdireccion.SelectedValue
        If txtubigeografica.Text = "" Then
            idubigeo = txtubigeografica.Text = "00000"
        Else
            idubigeo = CType(txtubigeografica.Text, Integer)
        End If
        'If txtubigeografica.Text = "" Then
        '    smensaje = "No a ingresado la ubicación geográfica"
        '    MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtubigeografica.Focus()
        '    Return
        'End If

        '
        idpais = CType(cmbpais.SelectedValue, Integer)
        iddpto = CType(cmbdepartamento.SelectedValue, Integer)
        idprov = CType(cmbprovincia.SelectedValue, Integer)
        If IsDBNull(cmbdistrito.SelectedValue) Then
            smensaje = "No a ingresado el distrito"
            MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbdistrito.Focus()
            Exit Sub
        End If
        iddistrito = CType(cmbdistrito.SelectedValue, Integer)
        '
        If IsDBNull(txtdireccion.Text) = True Then
            smensaje = "No a ingresado la dirección"
            MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtdireccion.Focus()
            Exit Sub
        Else
            If txtdireccion.Text = "" Then
                smensaje = "No a ingresado la dirección"
                MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtdireccion.Focus()
                Exit Sub
            End If
        End If
        sdireccion = txtdireccion.Text
        If IsDBNull(txtrefllegada.Text) = True Then
            srefllegada = "null"
        Else
            srefllegada = txtrefllegada.Text
        End If
        idsucuenta = CType(cmbsubcuenta.SelectedValue, Integer)
        idcargo = CType(cmbcargo.SelectedValue, Integer)
        idtipdcto = CType(cmbtipodcto.SelectedValue, Integer)
        '
        If IsDBNull(txtnrodocumento.Text) = True Then
            smensaje = "No a ingresado el número documento"
            MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtnrodocumento.Focus()
            Exit Sub
        Else
            If txtnrodocumento.Text = "" Then
                smensaje = "No a ingresado el número documento"
                MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtnrodocumento.Focus()
                Exit Sub
            End If
        End If
        snrodcto = CType(txtnrodocumento.Text, String)
        If IsDBNull(txtapellidos_y_nombres.Text) = True Then
            smensaje = "No a ingresado  apellidos y nombre"
            MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtapellidos_y_nombres.Focus()
            Exit Sub
        Else
            If txtapellidos_y_nombres.Text = "" Then
                smensaje = "No a ingresado  apellidos y nombre"
                MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtapellidos_y_nombres.Focus()
                Exit Sub
            End If
        End If
        sapellidos_nombres1 = CType(txtapellidos_y_nombres.Text, String)
        'snombre = CType(txtnombre.Text, String)
        'If IsDBNull(txtpaterno.Text) = True Then
        '    smensaje = "No a ingresado el apellido paterno"
        '    MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtpaterno.Focus()
        '    Return
        'Else
        '    If txtpaterno.Text = "" Then
        '        smensaje = "No a ingresado el apellido paterno"
        '        MessageBox.Show(smensaje, "Mantenimiento Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        txtpaterno.Focus()
        '        Return
        '    End If
        'End If
        'sapepaterno = CType(txtpaterno.Text, String)
        ''
        'If IsDBNull(txtapematerno.Text) = True Then
        '    sapematerno = " "
        'Else
        '    sapematerno = CType(txtapematerno.Text, String)
        'End If
        If rbtmasculino.Checked = True Then
            idsexo = 1
        End If
        If rbtfemenino.Checked = True Then
            idsexo = 2
        End If
        '
        If IsDBNull(txtiddireccionconsignado.Text) = True Then
            iidireccion_consignado = 0
        Else
            If txtiddireccionconsignado.Text = "" Then
                iidireccion_consignado = 0
            Else
                iidireccion_consignado = CType(txtiddireccionconsignado.Text, Integer)
            End If
        End If
        ' Pasando las variables 
        ModSolRecojoCarga.iddireccion_consignado = iidireccion_consignado
        ModSolRecojoCarga.tipodireccion = tipodireccion
        ModSolRecojoCarga.idubigeo = idubigeo
        ModSolRecojoCarga.idpais = idpais
        ModSolRecojoCarga.iddpto = iddpto
        ModSolRecojoCarga.idprov = idprov
        ModSolRecojoCarga.iddistrito = iddistrito
        ModSolRecojoCarga.sdireccion = sdireccion
        ModSolRecojoCarga.srefllegada = srefllegada
        ModSolRecojoCarga.snrodcto = snrodcto
        ModSolRecojoCarga.sapellidos_nombres = sapellidos_nombres1
        'ModSolRecojoCarga.snombre = snombre
        'ModSolRecojoCarga.sapepaterno = sapepaterno
        'ModSolRecojoCarga.sapematerno = sapematerno
        ModSolRecojoCarga.idsucuenta = idsucuenta
        ModSolRecojoCarga.idcargo = idcargo
        ModSolRecojoCarga.idtipdcto = idtipdcto
        ModSolRecojoCarga.idsexo = idsexo
        ModSolRecojoCarga.bcancelar = False
        '
        Me.Close()
    End Sub
    Sub limpiartodo()
        ModSolRecojoCarga.iddireccion_consignado = Nothing
        ModSolRecojoCarga.tipodireccion = Nothing
        ModSolRecojoCarga.idubigeo = Nothing
        ModSolRecojoCarga.idpais = Nothing
        ModSolRecojoCarga.iddpto = Nothing
        ModSolRecojoCarga.idprov = Nothing
        ModSolRecojoCarga.iddistrito = Nothing
        ModSolRecojoCarga.sdireccion = Nothing
        ModSolRecojoCarga.srefllegada = Nothing
        ModSolRecojoCarga.snrodcto = Nothing
        ModSolRecojoCarga.sapellidos_nombres = Nothing
        'ModSolRecojoCarga.snombre = Nothing
        'ModSolRecojoCarga.sapepaterno = Nothing
        'ModSolRecojoCarga.sapematerno = Nothing
        ModSolRecojoCarga.idsucuenta = Nothing
        ModSolRecojoCarga.idcargo = Nothing
        ModSolRecojoCarga.idtipdcto = Nothing
        ModSolRecojoCarga.idsexo = Nothing
        '
        ModSolRecojoCarga.bcancelar = True
        '
        Me.Close()
    End Sub
End Class