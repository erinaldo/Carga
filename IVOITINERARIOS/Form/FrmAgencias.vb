'Imports System.Data.OleDb
'Imports System.Data
'Imports System.Drawing
'Imports System.Collections
'Imports System.Windows.Forms
Public Class FrmAgencias
    Inherits FrmFormBase
    Dim Clase As New dtoAgencias
    Dim Impresion As New ClsPrint
    'Dim rstAge, rstUnd, rstUnd2, rstPais, rstDepar, rstProv, rstDist, rstSta, rstRet As ADODB.Recordset
    '
    'Dim rstRet As ADODB.Recordset
    '
    Dim dt, DtCbUnd, DtCbPais, DtCbDepar, DtCbProv, DtCbDist, DtCbSta, DtCbEst, DtrstUnd2, dt_rstRet As New System.Data.DataTable
    Dim dt_tipo_agencia As New DataTable
    Dim DvAgencia, DvCbUnd, DvCbPais, DvCbDepar, DvCbProv, DvCbDist, DvCbSta, DvCbEst, dv_tipo_agencia As DataView
    'Dim dr4 As New OleDbDataAdapter
    Dim drg As DataRowView
    Dim Fact, IdTag, IdSta As Integer
    Dim s As New Impresion
    Dim Pagina As Integer
    Dim Contador As Integer
    Dim Cantidad As Integer
    Dim ib_lee As Boolean = True
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub FrmAgencias_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'Importante - para considerar en los formularios no modales - Siempre en el evento Activated 
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmAgencias_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click

    End Sub

    Private Sub FrmAgencias_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Importante - para considerar en los formularios no modales - Siempre se debe eliminar la estructura (Nothing) 
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmAgencias_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus

    End Sub

    Private Sub FrmAgencias_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.MainMenuStrip = MenuStrip1
        Dim lds_tmp As New DataSet
        Try
            ShadowLabel1.Text = "Mantenimiento de Agencias"
            dt.Clear()
            'Mod.24/09/2009 -->Omendoza - Pasando al datahelper   
            'rstAge = Clase.Lista
            lds_tmp = Clase.Lista
            'rstUnd = rstAge.NextRecordset
            'rstPais = rstAge.NextRecordset
            'rstDepar = rstAge.NextRecordset
            'rstProv = rstAge.NextRecordset
            'rstDist = rstAge.NextRecordset
            'rstSta = rstAge.NextRecordset
            'rstUnd2 = rstAge.NextRecordset
            'dr4.Fill(dt, rstAge)
            'dr4.Fill(DtCbUnd, rstUnd)
            'DvCbUnd = DtCbUnd.DefaultView
            'dr4.Fill(DtCbPais, rstPais)
            'dr4.Fill(DtCbDepar, rstDepar)
            'dr4.Fill(DtCbProv, rstProv)

            'dr4.Fill(DtCbDist, rstDist)
            'dr4.Fill(DtCbSta, rstSta)

            dt = lds_tmp.Tables(0)
            DtCbUnd = lds_tmp.Tables(1)
            DtCbPais = lds_tmp.Tables(2)
            DtCbDepar = lds_tmp.Tables(3)
            DtCbProv = lds_tmp.Tables(4)
            DtCbDist = lds_tmp.Tables(5)
            DtCbSta = lds_tmp.Tables(6)
            DtrstUnd2 = lds_tmp.Tables(7)
            dt_tipo_agencia = lds_tmp.Tables(8)

            DtCbEst = DtCbSta.Copy
            '
            DvAgencia = dt.DefaultView
            DvAgencia.AllowNew = False
            DvCbUnd = DtCbUnd.DefaultView
            DvCbPais = DtCbPais.DefaultView
            DvCbDepar = DtCbDepar.DefaultView
            DvCbProv = DtCbProv.DefaultView
            DvCbDist = DtCbDist.DefaultView
            DvCbSta = DtCbSta.DefaultView
            DvCbEst = DtCbEst.DefaultView
            '
            DvCbEst.RowFilter = "idestado_registro <> 0"
            '
            ib_lee = False
            LlenaCombo3(DvCbUnd, CbUnidad, "nombre_unidad", "idunidad_agencia")
            LlenaCombo2(DvCbPais, CbPais, "pais")
            LlenaCombo2(DvCbDepar, CbDepar, "departamento")
            LlenaCombo2(DvCbProv, CbProv, "provincia")
            LlenaCombo2(DvCbDist, CbDist, "dsitrito")
            LlenaCombo2(DvCbSta, CbEstado, "estado_registro")
            LlenaCombo2(DvCbEst, CbStatus, "estado_registro")
            ib_lee = True
            '
            dv_tipo_agencia = CargarCombo(cmb_tipo_agencia, dt_tipo_agencia, "tipo_agencia", "idtipo_agencia", 0)  ' Por defecto 0 No debe aparecer nada 
            '
            'rstUnd.MoveFirst()

            'ModuUtil.LlenarTreeCtrl(rstUnd2, Me.TreeLista, "Ciudades")
            ModuUtil.LlenarTreeCtrl(DtrstUnd2, Me.TreeLista, "Ciudades")
            TreeLista.ExpandAll()
            MenuTab.Items(0).Text = "LISTA GENERAL"
            MenuTab.Items(1).Text = "DATOS GENERALES"
            DvAgencia.Sort = "nombre_agencia"
            Fact = 0
            IdTag = 0
            IdSta = 0
            Call GrillaMante()

            'Codigo Adicional - Para el control de acceso
            'G_Fila - Es el numero de ventana que está activo
            bIngreso = False
            Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TreeLista_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeLista.AfterSelect
        IdTag = e.Node().Tag
        Call GrabaFiltros()
    End Sub
    Sub GrillaMante()
        With DataGridViewLista
            .AllowUserToAddRows = True
            .AllowUserToDeleteRows = True
            .AllowUserToOrderColumns = True
            .BackgroundColor = SystemColors.Window
            '.Font = New System.Drawing.Font("Tahoma", 14.0!, FontStyle.Bold)
            .ReadOnly = True
            .AutoGenerateColumns = False
            .DataSource = dt
            .VirtualMode = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersWidth = 10
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EAF")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
        End With

        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .DataPropertyName = "IDAGENCIAS"
            .HeaderText = "Codigo"
            .Width = 85
        End With
        DataGridViewLista.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DataPropertyName = "NOMBRE_AGENCIA"
            .HeaderText = "Nombre"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridViewLista.Columns.Add(col1)
    End Sub
    Sub Edicion()
        Dim filarow As Integer
        Dim valor As String
        Dim drc As DataRowView
        Dim filcb As Integer
        '
        Dim DrUnd As DataRowView
        filarow = DataGridViewLista.CurrentRow.Index
        If filarow >= 0 Then
            TabMante.SelectedIndex = 1
            DrUnd = DvAgencia.Item(DataGridViewLista.CurrentRow.Index)
            TxtID.Text = Convert.ToString(DrUnd("idagencias"))
            'TxtCodAge.Text = DrUnd("codigo_agencia").ToString
            TxtNomAgencia.Text = DrUnd("nombre_agencia").ToString
            txtNomCorto.Text = DrUnd("nombre_corto").ToString
            TxtApePat.Text = DrUnd("nombre_contacto_apepat").ToString
            TxtApeMat.Text = DrUnd("nombre_contacto_apemat").ToString
            TxtNomCon.Text = DrUnd("nombre_contacto").ToString
            TxtCelular.Text = DrUnd("celular").ToString
            TxtDireccion.Text = DrUnd("direccion_agencia").ToString
            TxtTele1.Text = DrUnd("telefono1").ToString
            TxtTele2.Text = DrUnd("telefono2").ToString
            TxtFax1.Text = DrUnd("fax1").ToString
            TxtFax2.Text = DrUnd("fax2").ToString
            TxtEMail.Text = DrUnd("e_mail").ToString
            TxtRPM1.Text = DrUnd("rpm1").ToString
            TxtRPM2.Text = DrUnd("rpm2").ToString
            '
            Me.cmb_tipo_agencia.SelectedValue = DrUnd("es_terminal")
            '
            CbUnidad.SelectedIndex = UbicaCombo2(DvCbUnd, DrUnd, "idunidad_agencia", "idunidad_agencia", "nombre_unidad")
            CbPais.SelectedIndex = UbicaCombo(DvCbPais, DrUnd, "idpais")
            If DvCbDepar.Count > 0 Then
                If IsDBNull(DrUnd("iddepartamento")) = True Then
                    CbDepar.SelectedIndex = 0
                Else
                    CbDepar.SelectedIndex = UbicaCombo(DvCbDepar, DrUnd, "iddepartamento")
                End If
                CbDepar.SelectedIndex = UbicaCombo(DvCbDepar, DrUnd, "iddepartamento")
            End If
            If DvCbProv.Count > 0 Then
                If IsDBNull(DrUnd("idprovincia")) = True Then
                    CbProv.SelectedIndex = 0
                Else
                    CbProv.SelectedIndex = UbicaCombo(DvCbProv, DrUnd, "idprovincia")
                End If
            End If
            If DvCbDist.Count > 0 Then
                If IsDBNull(DrUnd("iddistrito")) = True Then
                    CbDist.SelectedIndex = 0
                Else
                    '
                    filcb = CbProv.SelectedIndex
                    drc = DvCbProv.Item(filcb)
                    valor = IIf(IsDBNull(drc("idprovincia")) = True, "0", drc("idprovincia").ToString)
                    '
                    DvCbDist.RowFilter = "idprovincia = " & valor
                    CbDist.SelectedIndex = UbicaCombo(DvCbDist, DrUnd, "iddistrito")
                End If
            End If
            If DvCbEst.Count > 0 Then
                If IsDBNull(DrUnd("idestado_registro")) = True Then
                    CbStatus.SelectedIndex = 0
                Else
                    CbStatus.SelectedIndex = UbicaCombo(DvCbEst, DrUnd, "idestado_registro")
                End If
            End If
            Me.cboPortavalor.SelectedIndex = DrUnd("portavalor")

            TxtMensaje.Text = "Modificacion"
            TxtNomAgencia.Focus()
        End If
    End Sub
    Private Sub TabMante_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabMante.Selecting
        If e.TabPageIndex = 1 Then
            If Fact <> 1 Then
                Fact = 2
                Call Edicion()
            End If
        Else
            Fact = 0
        End If
    End Sub

    Private Sub FrmAgencias_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MdiChildActivate

    End Sub

    Private Sub FrmAgencias_MenuEditar() Handles Me.MenuEditar
        Fact = 2
        Call Edicion()
    End Sub
    Private Sub FrmAgencias_MenuGrabar() Handles Me.MenuGrabar
        If TxtNomAgencia.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Nombre de la Agencia", "Agencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtNomAgencia.Text = ""
            Me.TxtNomAgencia.Focus()
            Return
        End If

        If TxtDireccion.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Dirección de la Agencia", "Agencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtDireccion.Text = ""
            Me.TxtDireccion.Focus()
            Return
        End If

        If Me.cmb_tipo_agencia.SelectedIndex < 0 Then
            MessageBox.Show("Seleccione Tipo de Agencia", "Agencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmb_tipo_agencia.Focus()
            Return
        End If

        If Me.cboPortavalor.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione Tipo de Portavalor", "Agencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboPortavalor.Focus()
            Return
        End If

        'If Trim(TxtCodAge.Text) = "" Then
        '    MsgBox("Codigo de Agencia Vacio... Verifique!!!", MsgBoxStyle.Critical, "Seguridad del Sistema")
        '    Exit Sub
        'End If
        Dim fil As Integer
        Dim filtro As String
        If Fact = 1 Then
            TxtID.Text = "0"
        End If
        Try
            Dim drpais, drdepa, drprov, drdist, drund, drest As DataRowView
            drpais = DvCbPais.Item(CbPais.SelectedIndex)
            drdepa = DvCbDepar.Item(CbDepar.SelectedIndex)

            Dim i As Integer
            'For i = 0 To CbDepar.Items.Count - 1
            ' CbDepar.SelectedIndex = i
            'MessageBox.Show(CbDepar.Text)
            'Next

            drprov = DvCbProv.Item(CbProv.SelectedIndex)
            drdist = DvCbDist.Item(CbDist.SelectedIndex)
            drund = DvCbUnd.Item(CbUnidad.SelectedIndex)
            drest = DvCbEst.Item(CbStatus.SelectedIndex)
            Clase.Accion = Fact
            Clase.Pais = drpais("idpais")
            Clase.Departamento = drdepa("iddepartamento")
            Clase.Provincia = drprov("idprovincia")
            Clase.Distrito = drdist("iddistrito")
            Clase.Unidad = drund("idunidad_agencia")
            Clase.Estado = drest("idestado_registro")
            Clase.ID = Convert.ToInt16(TxtID.Text)
            Clase.NomAgencia = IIf(Trim(TxtNomAgencia.Text) = "", " ", Trim(TxtNomAgencia.Text))
            Clase.ApePatCto = IIf(Trim(TxtApePat.Text) = "", " ", Trim(TxtApePat.Text))
            Clase.ApeMatCto = IIf(Trim(TxtApeMat.Text) = "", " ", Trim(TxtApeMat.Text))
            'ncont = ""
            Clase.Contacto = IIf(Trim(TxtNomCon.Text) = "", " ", Trim(TxtNomCon.Text))
            Clase.Celular = IIf(Trim(TxtCelular.Text) = "", " ", Trim(TxtCelular.Text))
            Clase.Direccion = IIf(Trim(TxtDireccion.Text) = "", " ", Trim(TxtDireccion.Text))
            Clase.Telefono1 = IIf(Trim(TxtTele1.Text) = "", " ", Trim(TxtTele1.Text))
            Clase.Telefono2 = IIf(Trim(TxtTele2.Text) = "", " ", Trim(TxtTele2.Text))
            Clase.RPM1 = IIf(Trim(TxtRPM1.Text) = "", " ", Trim(TxtRPM1.Text))
            Clase.RPM2 = IIf(Trim(TxtRPM2.Text) = "", " ", Trim(TxtRPM2.Text))
            Clase.Fax1 = IIf(Trim(TxtFax1.Text) = "", " ", Trim(TxtFax1.Text))
            Clase.Fax2 = IIf(Trim(TxtFax2.Text) = "", " ", Trim(TxtFax2.Text))
            Clase.E_Mail = IIf(Trim(TxtEMail.Text) = "", " ", Trim(TxtEMail.Text))
            Clase.NomCorto = IIf(Trim(txtNomCorto.Text) = "", " ", Trim(txtNomCorto.Text))
            'Clase.CodAgencia = IIf(Trim(TxtCodAge.Text) = "", " ", Trim(TxtCodAge.Text))
            '
            Clase.Usuario = dtoUSUARIOS.IdLogin
            '
            Clase.Rol = 1
            'Clase.IP = "192.168.50.47"
            Clase.IP = dtoUSUARIOS.IP
            Clase.Portavalor = Me.cboPortavalor.SelectedIndex
            '
            Clase.es_terminal = Me.cmb_tipo_agencia.SelectedValue
            If Clase.es_terminal = 1 Then
                '10/12/2009 - Veirifica si cambia de terminal 
                Dim ldt_tmp As New DataTable
                Dim li_idagencia As Integer
                Dim ls_agencia, ls_mensaje As String
                Dim rpta As New DialogResult
                ldt_tmp = Clase.verifica_tipo_agencia()
                If ldt_tmp.Rows.Count > 0 Then
                    li_idagencia = ldt_tmp.Rows(0)(0)
                    ls_agencia = ldt_tmp.Rows(0)(1)
                    ls_mensaje = "Existe " + ls_agencia + " como agencia terminal ¿Desea cambiar, la agencia terminal?"
                    '---
                    rpta = MessageBox.Show(Me, ls_mensaje, "Agencias", MessageBoxButtons.YesNo, _
                      MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)
                    '---
                    If rpta = DialogResult.No Then
                        Exit Sub
                    End If
                End If
                '---
            End If
            '
            Dim lds_tmp As New DataSet
            'rst = Clase.Grabar
            lds_tmp = Clase.Grabar
            If Convert.ToInt16(lds_tmp.Tables(0).Rows(0).Item(0)) = 0 Then
                MsgBox("Registro Grabado Correctamente", MsgBoxStyle.Information, "Seguridad del Sistema")
                'rstRet = rst.NextRecordset()
                dt_rstRet = lds_tmp.Tables(1)
                filtro = DvAgencia.RowFilter
                DvAgencia.RowFilter = ""
                If Fact = 1 Then
                    fil = DvAgencia.Count
                    DvAgencia.AllowNew = True
                    DvAgencia.AddNew()
                    ActualizaGrilla(fil)
                    DvAgencia.AllowNew = False
                Else
                    DvAgencia.Sort = "idagencias"
                    fil = DvAgencia.Find(IIf(IsDBNull(lds_tmp.Tables(1).Rows(0).Item(0)) = True, 0, lds_tmp.Tables(1).Rows(0).Item(0)))
                    If fil >= 0 Then
                        ActualizaGrilla(fil)
                    End If
                End If
                DtAyuRut = DvAgencia.ToTable
                DvAgencia.RowFilter = filtro
                'Call CargaDatos()
                'lds_tmp = Clase.Lista(dtoUSUARIOS.m_idciudad)
                'dt = lds_tmp.Tables(0)
                'Call GrillaMante()
                DvAgencia.Sort = "nombre_agencia"
                TabMante.SelectedIndex = 0
            Else
                'MessageBox.Show("Descripcion : " + Trim(Convert.ToString(rst.Fields(1))), "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show("Descripcion : " + Trim(Convert.ToString(lds_tmp.Tables(0).Rows(0).Item(1))), "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
            Exit Sub
        End Try

    End Sub

    Private Sub FrmAgencias_MenuImprimir() Handles Me.MenuImprimir
        Dim PrDialog As New PrintPreviewDialog
        Dim PrReporte As New Reportes
        Dim Campos As New ArrayList
        Impresion.Titulo = "Relacion de Agencias Asociadas a la Empresa S.A.C."
        Impresion.TopDetalle = 100
        Impresion.DGV = DataGridViewLista
        Impresion.Lista = Campos
        PrReporte.pd.Document = Impresion
        PrReporte.Dock = DockStyle.Fill
        PrReporte.ShowDialog()
        'PrDialog.Document = Impresion
        'PrDialog.ShowDialog()

        'Me.PrintDocument1.Print()
        'Static aux As String
        ''aux = InputBox("Cantidad de Columnas", "Columnas Variables", aux)
        ''If Not IsNumeric(aux) Then
        ''    MessageBox.Show("Debe especificar un valor numérico", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ''    Exit Sub
        ''End If
        ''Cantidad = Val(aux)
        'Cantidad = DataGridViewLista.ColumnCount
        'If Cantidad < 1 Or Cantidad > 8 Then
        '    MessageBox.Show("Número de Columnas Inválido  (1-8)", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If
        'AddHandler s.Titulos, AddressOf TitulosColumnasVariables
        's.GenerarReporte(False, "Carta")
        'RemoveHandler s.Titulos, AddressOf TitulosColumnasVariables
    End Sub

    Private Sub FrmAgencias_MenuNuevo() Handles Me.MenuNuevo
        TxtID.Text = ""
        'TxtCodAge.Text = ""
        TxtNomAgencia.Text = ""
        txtNomCorto.Text = ""
        TxtNomCon.Text = ""
        TxtCelular.Text = ""
        TxtDireccion.Text = ""
        TxtApePat.Text = ""
        TxtApeMat.Text = ""
        TxtTele1.Text = ""
        TxtTele2.Text = ""
        TxtFax1.Text = ""
        TxtFax2.Text = ""
        TxtEMail.Text = ""
        TxtRPM1.Text = ""
        TxtRPM2.Text = ""
        Me.cboPortavalor.SelectedIndex = 0
        Fact = 1
        TabMante.SelectedIndex = 1
        TxtMensaje.Text = "Nuevo"
        TxtNomAgencia.Focus()
    End Sub
    Private Sub datagridviewlista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLista.DoubleClick
        Call Edicion()
    End Sub
    Private Sub TxtBusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBusca.TextChanged
        DvAgencia.RowFilter = "trim(nombre_agencia) like '*" & Trim(TxtBusca.Text) & "*'"
        'Call GrabaFiltros()
        'swgrid = True
    End Sub

    Private Sub CbPais_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbPais.SelectedIndexChanged
        Dim filcb As Integer
        Dim drc As DataRowView
        Dim valor As String
        If ib_lee = True Then
            filcb = CbPais.SelectedIndex
            If filcb >= 0 Then
                drc = DvCbPais.Item(filcb)
                valor = IIf(IsDBNull(drc("idpais")) = True, "0", drc("idpais").ToString)
                DvCbDepar.RowFilter = "idpais = " & valor
                If DvCbDepar.Count > 0 Then
                    drc = DvCbDepar.Item(0)
                    valor = IIf(IsDBNull(drc("iddepartamento")) = True, "0", drc("iddepartamento").ToString)
                    DvCbProv.RowFilter = "iddepartamento = " & valor
                    If DvCbProv.Count > 0 Then
                        drc = DvCbProv.Item(0)
                        valor = IIf(IsDBNull(drc("idprovincia")) = True, "0", drc("idprovincia").ToString)
                        DvCbDist.RowFilter = "idprovincia = " & valor
                    End If
                End If
            Else
                DvCbDepar.RowFilter = "idpais = 0"
                DvCbProv.RowFilter = "iddepartamento = 0"
                DvCbDist.RowFilter = "idprovincia = 0"
            End If
        End If
    End Sub

    Private Sub CbDepar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbDepar.SelectedIndexChanged
        Dim filcb As Integer
        Dim drc As DataRowView
        Dim valor As String
        '
        If ib_lee = True Then
            filcb = CbDepar.SelectedIndex
            If filcb >= 0 Then
                drc = DvCbDepar.Item(filcb)
                valor = IIf(IsDBNull(drc("iddepartamento")) = True, "0", drc("iddepartamento").ToString)
                DvCbProv.RowFilter = "iddepartamento = " & valor
                If DvCbProv.Count > 0 Then
                    drc = DvCbProv.Item(0)
                    valor = IIf(IsDBNull(drc("idprovincia")) = True, "0", drc("idprovincia").ToString)
                    DvCbDist.RowFilter = "idprovincia = " & valor
                End If
            Else
                DvCbProv.RowFilter = "iddepartamento = 0"
            End If
        End If
        '
    End Sub

    Private Sub CbProv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbProv.SelectedIndexChanged
        If ib_lee = True Then
            Dim filcb As Integer
            Dim drc As DataRowView
            Dim valor As String
            filcb = CbProv.SelectedIndex
            If filcb >= 0 Then
                drc = DvCbProv.Item(filcb)
                valor = IIf(IsDBNull(drc("idprovincia")) = True, "0", drc("idprovincia").ToString)
                DvCbDist.RowFilter = "idprovincia = " & valor
            Else
                DvCbDist.RowFilter = "idprovincia = 0"
            End If
        End If
    End Sub
    Sub ActualizaGrilla(ByVal filg As Integer)
        'Mod.25/09/2009 -->Omendoza - Pasando al datahelper   
        drg = DvAgencia.Item(filg)
        'drg("idagencias") = dt_rstRet.Rows(0).Item(0).value
        'drg("nombre_agencia") = dt_rstRet.Rows(0).Item(1).value
        'drg("nombre_corto") = dt_rstRet.Rows(0).Item(2).value
        'drg("NOMBRE_CONTACTO_APEPAT") = dt_rstRet.Rows(0).Item(3).value
        'drg("NOMBRE_CONTACTO_APEMAT") = dt_rstRet.Rows(0).Item(4).value
        'drg("NOMBRE_CONTACTO") = dt_rstRet.Rows(0).Item(5).value
        'drg("DIRECCION_AGENCIA") = dt_rstRet.Rows(0).Item(6).value
        'drg("CELULAR") = dt_rstRet.Rows(0).Item(7).value
        'drg("TELEFONO1") = dt_rstRet.Rows(0).Item(8).value
        'drg("TELEFONO2") = dt_rstRet.Rows(0).Item(9).value
        'drg("FAX1") = dt_rstRet.Rows(0).Item(10).value
        'drg("FAX2") = dt_rstRet.Rows(0).Item(11).value
        'drg("E_MAIL") = dt_rstRet.Rows(0).Item(12).value
        'drg("RPM1") = dt_rstRet.Rows(0).Item(13).value
        'drg("RPM2") = dt_rstRet.Rows(0).Item(14).value
        'drg("IDPAIS") = dt_rstRet.Rows(0).Item(15).value
        'drg("IDDEPARTAMENTO") = dt_rstRet.Rows(0).Item(16).value
        'drg("IDPROVINCIA") = dt_rstRet.Rows(0).Item(17).value
        'drg("IDDISTRITO") = dt_rstRet.Rows(0).Item(18).value
        'drg("IDUNIDAD_AGENCIA") = dt_rstRet.Rows(0).Item(19).value
        ''drg("CODIGO_AGENCIA") = dt_rstRet.Rows(0).Item(20).value
        'drg("IDESTADO_REGISTRO") = dt_rstRet.Rows(0).Item(20).value
        '''''''''''
        drg("idagencias") = dt_rstRet.Rows(0).Item(0)
        drg("nombre_agencia") = dt_rstRet.Rows(0).Item(1)
        drg("nombre_corto") = dt_rstRet.Rows(0).Item(2)
        drg("NOMBRE_CONTACTO_APEPAT") = dt_rstRet.Rows(0).Item(3)
        drg("NOMBRE_CONTACTO_APEMAT") = dt_rstRet.Rows(0).Item(4)
        drg("NOMBRE_CONTACTO") = dt_rstRet.Rows(0).Item(5)
        drg("DIRECCION_AGENCIA") = dt_rstRet.Rows(0).Item(6)
        drg("CELULAR") = dt_rstRet.Rows(0).Item(7)
        drg("TELEFONO1") = dt_rstRet.Rows(0).Item(8)
        drg("TELEFONO2") = dt_rstRet.Rows(0).Item(9)
        drg("FAX1") = dt_rstRet.Rows(0).Item(10)
        drg("FAX2") = dt_rstRet.Rows(0).Item(11)
        drg("E_MAIL") = dt_rstRet.Rows(0).Item(12)
        drg("RPM1") = dt_rstRet.Rows(0).Item(13)
        drg("RPM2") = dt_rstRet.Rows(0).Item(14)
        drg("IDPAIS") = dt_rstRet.Rows(0).Item(15)
        drg("IDDEPARTAMENTO") = dt_rstRet.Rows(0).Item(16)
        drg("IDPROVINCIA") = dt_rstRet.Rows(0).Item(17)
        drg("IDDISTRITO") = dt_rstRet.Rows(0).Item(18)
        drg("IDUNIDAD_AGENCIA") = dt_rstRet.Rows(0).Item(19)
        'drg("CODIGO_AGENCIA") = dt_rstRet.Rows(0).Item(20)
        drg("IDESTADO_REGISTRO") = dt_rstRet.Rows(0).Item(20)
        drg("ES_TERMINAL") = dt_rstRet.Rows(0).Item(21)
        drg("portavalor") = dt_rstRet.Rows(0).Item("portavalor")
        If dt_rstRet.Rows(0).Item(21) = 1 Then '-- Solo si es terminal 
            Dim fila As Long
            For fila = 0 To DvAgencia.Count - 1
                drg = DvAgencia.Item(fila)
                If fila <> filg Then
                    If dt_rstRet.Rows(0).Item(19) = drg("IDUNIDAD_AGENCIA") Then
                        drg("ES_TERMINAL") = 2
                    End If
                End If
            Next
        End If
    End Sub
    Private Sub CbEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbEstado.SelectedIndexChanged
        Dim drsta As DataRowView
        drsta = DvCbSta.Item(CbEstado.SelectedIndex)
        IdSta = drsta("idestado_registro")
        Call GrabaFiltros()
    End Sub
    Sub GrabaFiltros()
        Dim filtro As String
        If IdTag = 0 Then
            filtro = "1=1"
        Else
            filtro = "idunidad_agencia = " + Trim(IdTag)
        End If
        If IdSta > 0 Then
            filtro = filtro + " and idestado_registro = " + Trim(IdSta)
        End If
        DvAgencia.RowFilter = filtro
    End Sub
    Private Sub TitulosColumnasVariables()
        Dim Cont As Integer, Linea As Integer
        s.Imprimir("Encabezado del Reporte")
        s.SalLinea(2)
        s.LineaL(2)
        s.SalLinea()
        s.ResetCols()
        For Cont = 1 To Cantidad
            s.DefCol(80)
        Next
        For Linea = 1 To DvAgencia.Count
            drg = DvAgencia.Item(Linea - 1)
            s.ImprimirTab(drg("idagencias").ToString, True)
            s.ImprimirTab(drg("nombre_agencia").ToString, True)
            s.SalLinea()
        Next
        'For Linea = 1 To 10
        '    For Cont = 1 To Cantidad
        '        s.ImprimirTab(Cont, True)
        '    Next
        '    s.SalLinea()
        'Next
    End Sub
    'Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
    '    oStringFormat = New StringFormat
    '    oStringFormat.Alignment = StringAlignment.Near
    '    oStringFormat.LineAlignment = StringAlignment.Center
    '    oStringFormat.Trimming = StringTrimming.EllipsisCharacter
    '    oStringFormatComboBox = New StringFormat
    '    oStringFormatComboBox.LineAlignment = StringAlignment.Center
    '    oStringFormatComboBox.FormatFlags = StringFormatFlags.NoWrap
    '    oStringFormatComboBox.Trimming = StringTrimming.EllipsisCharacter
    '    oButton = New Button
    '    oCheckbox = New CheckBox
    '    oComboBox = New ComboBox
    '    nTotalWidth = 0
    '    For Each oColumn As DataGridViewColumn In DataGridViewLista.Columns
    '        nTotalWidth += oColumn.Width
    '    Next
    '    nPageNo = 1
    '    NewPage = True
    '    nRowPos = 0
    'End Sub
    'Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
    '    Static oColumnLefts As New ArrayList
    '    Static oColumnWidths As New ArrayList
    '    Static oColumnTypes As New ArrayList
    '    Static nHeight As Int16
    '    Dim nWidth, i, nRowsPerPage As Int16
    '    Dim nTop As Int16 = e.MarginBounds.Top
    '    Dim nLeft As Int16 = e.MarginBounds.Left
    '    If nPageNo = 1 Then
    '        For Each oColumn As DataGridViewColumn In DataGridViewLista.Columns
    '            nWidth = CType(Math.Floor(oColumn.Width / nTotalWidth * nTotalWidth * (e.MarginBounds.Width / nTotalWidth)), Int16)
    '            nHeight = e.Graphics.MeasureString(oColumn.HeaderText, oColumn.InheritedStyle.Font, nWidth).Height + 11
    '            oColumnLefts.Add(nLeft)
    '            oColumnWidths.Add(nWidth)
    '            oColumnTypes.Add(oColumn.GetType)
    '            nLeft += nWidth
    '        Next
    '    End If
    '    Do While nRowPos < DataGridViewLista.Rows.Count - 1
    '        Dim oRow As DataGridViewRow = DataGridViewLista.Rows(nRowPos)
    '        If nTop + nHeight >= e.MarginBounds.Height + e.MarginBounds.Top Then
    '            DrawFooter(e, nRowsPerPage)
    '            NewPage = True
    '            nPageNo += 1
    '            e.HasMorePages = True
    '            Exit Sub
    '        Else
    '            If NewPage Then
    '                ' Draw Header
    '                e.Graphics.DrawString(Header, New Font(DataGridViewLista.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top - e.Graphics.MeasureString(Header, New Font(DataGridViewLista.Font, FontStyle.Bold), e.MarginBounds.Width).Height - 13)
    '                ' Draw Columns
    '                nTop = e.MarginBounds.Top
    '                i = 0
    '                For Each oColumn As DataGridViewColumn In DataGridViewLista.Columns
    '                    e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight))
    '                    e.Graphics.DrawRectangle(Pens.Black, New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight))
    '                    e.Graphics.DrawString(oColumn.HeaderText, oColumn.InheritedStyle.Font, New SolidBrush(oColumn.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i), nTop, oColumnWidths(i), nHeight), oStringFormat)
    '                    i += 1
    '                Next
    '                NewPage = False
    '            End If
    '            nTop += nHeight
    '            i = 0
    '            For Each oCell As DataGridViewCell In oRow.Cells
    '                If oColumnTypes(i) Is GetType(DataGridViewTextBoxColumn) OrElse oColumnTypes(i) Is GetType(DataGridViewLinkColumn) Then
    '                    e.Graphics.DrawString(oCell.ToString, oCell.InheritedStyle.Font, New SolidBrush(oCell.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i), nTop, oColumnWidths(i), nHeight), oStringFormat)
    '                ElseIf oColumnTypes(i) Is GetType(DataGridViewButtonColumn) Then
    '                    oButton.Text = oCell.ToString
    '                    oButton.Size = New Size(oColumnWidths(i), nHeight)
    '                    Dim oBitmap As New Bitmap(oButton.Width, oButton.Height)
    '                    oButton.DrawToBitmap(oBitmap, New Rectangle(0, 0, oBitmap.Width, oBitmap.Height))
    '                    e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i), nTop))
    '                ElseIf oColumnTypes(i) Is GetType(DataGridViewCheckBoxColumn) Then
    '                    oCheckbox.Size = New Size(14, 14)
    '                    oCheckbox.Checked = CType(oCell, Boolean)
    '                    Dim oBitmap As New Bitmap(oColumnWidths(i), nHeight)
    '                    Dim oTempGraphics As Graphics = Graphics.FromImage(oBitmap)
    '                    oTempGraphics.FillRectangle(Brushes.White, New Rectangle(0, 0, oBitmap.Width, oBitmap.Height))
    '                    oCheckbox.DrawToBitmap(oBitmap, New Rectangle(CType((oBitmap.Width - oCheckbox.Width) / 2, Int32), CType((oBitmap.Height - oCheckbox.Height) / 2, Int32), oCheckbox.Width, oCheckbox.Height))
    '                    e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i), nTop))
    '                ElseIf oColumnTypes(i) Is GetType(DataGridViewComboBoxColumn) Then
    '                    oComboBox.Size = New Size(oColumnWidths(i), nHeight)
    '                    Dim oBitmap As New Bitmap(oComboBox.Width, oComboBox.Height)
    '                    oComboBox.DrawToBitmap(oBitmap, New Rectangle(0, 0, oBitmap.Width, oBitmap.Height))
    '                    e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i), nTop))
    '                    e.Graphics.DrawString(oCell.ToString, oCell.InheritedStyle.Font, New SolidBrush(oCell.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i) + 1, nTop, oColumnWidths(i) - 16, nHeight), oStringFormatComboBox)
    '                ElseIf oColumnTypes(i) Is GetType(DataGridViewImageColumn) Then
    '                    Dim oCellSize As Rectangle = New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight)
    '                    Dim oImageSize As Size = CType(oCell, Image).Size
    '                    e.Graphics.DrawImage(oCell, New Rectangle(oColumnLefts(i) + CType(((oCellSize.Width - oImageSize.Width) / 2), Int32), nTop + CType(((oCellSize.Height - oImageSize.Height) / 2), Int32), CType(oCell, Image).Width, CType(oCell, Image).Height))
    '                End If
    '                e.Graphics.DrawRectangle(Pens.Black, New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight))
    '                i += 1
    '            Next
    '        End If
    '        nRowPos += 1
    '        nRowsPerPage += 1
    '    Loop
    '    DrawFooter(e, nRowsPerPage)
    '    e.HasMorePages = False
    'End Sub
    'Private Sub DrawFooter(ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal RowsPerPage As Int32)
    '    Dim sPageNo As String = nPageNo.ToString + " of " + Math.Ceiling(DataGridViewLista.Rows.Count / RowsPerPage).ToString
    '    ' Right Align - User Name
    '    e.Graphics.DrawString(sUserName, DataGridViewLista.Font, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(sPageNo, DataGridViewLista.Font, e.MarginBounds.Width).Width), e.MarginBounds.Top + e.MarginBounds.Height + 7)
    '    ' Left Align - Date/Time
    '    e.Graphics.DrawString(Now.ToLongDateString + " " + Now.ToShortTimeString, DataGridViewLista.Font, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top + e.MarginBounds.Height + 7)
    '    ' Center  - Page No. Info
    '    e.Graphics.DrawString(sPageNo, DataGridViewLista.Font, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(sPageNo, DataGridViewLista.Font, e.MarginBounds.Width).Width) / 2, e.MarginBounds.Top + e.MarginBounds.Height + 31)
    'End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem1.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class
