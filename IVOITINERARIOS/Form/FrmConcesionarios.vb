Imports System.Data
Imports System.Windows.Forms
Imports System.Object
Imports System.Drawing
Imports System.Web.UI.WebControls.FontInfo
Public Class FrmConcesionarios
    Inherits FrmFormBase
    Dim Clase As New dtoConcesionarios
    Dim Impresion As New ClsPrint
    'Dim rstCon, rstAge, rstPais, rstDepar, rstProv, rstDist, rstRet, rstAge1, rstAge2, rstUnd, rstAgeAso, rstSta As ADODB.Recordset
    '
    Dim dt, DtCbPais, DtCbDepar, DtCbProv, DtCbDist, DtAge1, DtAge2, DtCbUnd, DtCbSta, DtCbEst As New System.Data.DataTable
    'Dim dr4 As New OleDbDataAdapter
    '
    Dim drg As DataRowView
    Dim DvAgencia, DvCbPais, DvCbDepar, DvCbProv, DvCbDist, DvAge1, DvAge2, DvCbUnd, DvCbSta, DvCbEst As DataView
    Dim Fact, IdSta As Integer

    Private Sub FrmConcesionarios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SplitContainer2.Panel1Collapsed = True
        ShadowLabel1.Text = "Mantenimiento de Concesionarios"
        dt.Clear()
        '
        'Mod.25/09/2009 -->Omendoza - Pasando al datahelper   
        '
        'rstCon = Clase.Lista
        'rstAge = rstCon.NextRecordset
        'rstPais = rstCon.NextRecordset
        'rstDepar = rstCon.NextRecordset
        'rstProv = rstCon.NextRecordset
        'rstDist = rstCon.NextRecordset
        'rstUnd = rstCon.NextRecordset
        'rstSta = rstCon.NextRecordset
        'dr4.Fill(dt, rstCon)
        'dr4.Fill(DtCbPais, rstPais)
        'dr4.Fill(DtAge1, rstAge)
        'dr4.Fill(DtCbDepar, rstDepar)
        'dr4.Fill(DtCbProv, rstProv)
        'dr4.Fill(DtCbDist, rstDist)
        'dr4.Fill(DtCbUnd, rstUnd)
        'dr4.Fill(DtCbSta, rstSta)

        Dim lds_tmp As New DataSet
        lds_tmp = Clase.Lista()
        dt = lds_tmp.Tables(0)
        DtAge1 = lds_tmp.Tables(1)
        DtAge2 = DtAge1.Copy
        DtCbPais = lds_tmp.Tables(2)
        DtCbDepar = lds_tmp.Tables(3)
        DtCbProv = lds_tmp.Tables(4)
        DtCbDist = lds_tmp.Tables(5)
        DtCbUnd = lds_tmp.Tables(6)
        DtCbSta = lds_tmp.Tables(7)
        '
        DvAgencia = dt.DefaultView
        DvAgencia.AllowNew = False
        '
        DvAge1 = DtAge1.DefaultView
        DvCbPais = DtCbPais.DefaultView
        DvCbDepar = DtCbDepar.DefaultView
        DvCbProv = DtCbProv.DefaultView
        DvCbDist = DtCbDist.DefaultView
        DvCbUnd = DtCbUnd.DefaultView
        DvCbSta = DtCbSta.DefaultView
        '
        DtCbEst = DtCbSta.Copy
        DvCbEst = DtCbEst.DefaultView
        DvCbEst.RowFilter = "idestado_registro <> 0"
        '
        LlenaCombo2(DvCbPais, CbPais, "pais")
        LlenaCombo2(DvCbDepar, CbDepar, "departamento")
        LlenaCombo2(DvCbProv, CbProv, "provincia")
        LlenaCombo2(DvCbDist, CbDist, "dsitrito")
        LlenaCombo2(DvCbUnd, CbUnidad, "nombre_unidad")
        LlenaCombo2(DvCbSta, CbEstado, "estado_registro")
        LlenaCombo2(DvCbEst, CbStatus, "estado_registro")
        '
        'ModuUtil.LlenarTreeCtrl(rstAge, Me.TreeLista, "Agencias")
        'TreeLista.ExpandAll()
        '
        DvAge1.AllowNew = False
        'rstAge.MoveFirst()
        'dr4.Fill(DtAge2, rstAge)
        DvAge2 = DtAge2.DefaultView
        DvAge2.AllowNew = False
        MenuTab.Items(0).Text = "LISTA GENERAL"
        MenuTab.Items(1).Text = "DATOS GENERALES"
        MenuTab.Items(2).Text = "AGENCIAS ASOCIADAS"
        Fact = 0
        IdSta = 0
        Call GrillaMante()
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
            .DataPropertyName = "IDEMPRESAS_CONCESION"
            .HeaderText = "Codigo"
            .Width = 85
        End With
        DataGridViewLista.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DataPropertyName = "NOMBRE_EMPRESA"
            .HeaderText = "Nombre"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridViewLista.Columns.Add(col1)


        With DataGridAge1
            .AutoGenerateColumns = False
            .DataSource = DvAge1
            .RowHeadersWidth = 10
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EAF")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .ReadOnly = False
        End With

        Dim colu1 As New DataGridViewCheckBoxColumn
        With colu1
            .DataPropertyName = "flag"
            .HeaderText = "F"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .Width = 20
            .ReadOnly = False
        End With
        DataGridAge1.Columns.Add(colu1)

        Dim colu2 As New DataGridViewTextBoxColumn
        With colu2
            .DataPropertyName = "nombre_agencia"
            .HeaderText = "Origen"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        DataGridAge1.Columns.Add(colu2)

        With DataGridAge2
            .RowHeadersWidth = 10
            .AutoGenerateColumns = False
            .DataSource = DvAge2
            .ReadOnly = False
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EAF")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
        End With

        Dim dg1 As New DataGridViewCheckBoxColumn
        With dg1
            .DataPropertyName = "flag"
            .HeaderText = "F"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .Width = 20
            .ReadOnly = False
        End With
        DataGridAge2.Columns.Add(dg1)

        Dim dg2 As New DataGridViewTextBoxColumn
        With dg2
            .DataPropertyName = "nombre_agencia"
            .HeaderText = "Destino"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        DataGridAge2.Columns.Add(dg2)

    End Sub
    Sub Edicion()
        Dim filarow As Integer
        Dim DrUnd As DataRowView
        filarow = DataGridViewLista.CurrentRow.Index
        If filarow >= 0 Then
            TabMante.SelectedIndex = 1
            DrUnd = DvAgencia.Item(DataGridViewLista.CurrentRow.Index)
            TxtID.Text = Convert.ToString(DrUnd("idempresas_concesion"))
            TxtNomEmp.Text = DrUnd("nombre_empresa").ToString
            txtNomCorto.Text = DrUnd("nombre_corto").ToString
            TxtApePat.Text = DrUnd("apepat_contacto").ToString
            TxtApeMat.Text = DrUnd("apemat_contacto").ToString
            TxtNomCon.Text = DrUnd("nombre_contacto").ToString
            TxtRUC.Text = DrUnd("ruc").ToString
            TxtCelular.Text = DrUnd("celular").ToString
            TxtDireccion.Text = DrUnd("direccion").ToString
            TxtTelefono.Text = DrUnd("telefono").ToString
            TxtFax.Text = DrUnd("fax").ToString
            TxtRPM.Text = DrUnd("rpm").ToString
            'CbUnidad.SelectedIndex = UbicaCombo(DvCbUnd, DrUnd, "idunidad_agencia")
            CbPais.SelectedIndex = UbicaCombo(DvCbPais, DrUnd, "idpais")
            CbDepar.SelectedIndex = UbicaCombo(DvCbDepar, DrUnd, "iddepartamento")
            CbProv.SelectedIndex = UbicaCombo(DvCbProv, DrUnd, "idprovincia")
            CbDist.SelectedIndex = UbicaCombo(DvCbDist, DrUnd, "iddistrito")
            CbStatus.SelectedIndex = UbicaCombo(DvCbEst, DrUnd, "idestado_registro")
            TxtMensaje.Text = "Modificacion"
            TxtNomEmp.Focus()
        End If
    End Sub
    Private Sub TabMante_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabMante.Selecting
        Select Case e.TabPageIndex
            Case 1
                If Fact <> 1 Then
                    Fact = 2
                    Call Edicion()
                End If
            Case 2
                Fact = 3
                Call AgenciasAsociadas()
            Case Else
                Fact = 0
        End Select
    End Sub

    Private Sub datagridviewlista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles datagridviewlista.DoubleClick
        Call Edicion()
    End Sub
    Private Sub TxtBusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBusca.TextChanged
        DvAgencia.RowFilter = "trim(nombre_empresa) like '*" & Trim(TxtBusca.Text) & "*'"
        'Call GrabaFiltros()
        'swgrid = True
    End Sub

    Private Sub CbPais_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbPais.SelectedIndexChanged
        Dim filcb As Integer
        Dim drc As DataRowView
        Dim valor As String
        filcb = CbPais.SelectedIndex
        If filcb >= 0 Then
            drc = DvCbPais.Item(filcb)
            valor = IIf(IsDBNull(drc("idpais")) = True, "0", drc("idpais").ToString)
            DvCbDepar.RowFilter = "idpais = " & valor
        Else
            DvCbDepar.RowFilter = "idpais = 0"
        End If
    End Sub

    Private Sub CbDepar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbDepar.SelectedIndexChanged
        Dim filcb As Integer
        Dim drc As DataRowView
        Dim valor As String
        filcb = CbDepar.SelectedIndex
        If filcb >= 0 Then
            drc = DvCbDepar.Item(filcb)
            valor = IIf(IsDBNull(drc("iddepartamento")) = True, "0", drc("iddepartamento").ToString)
            DvCbProv.RowFilter = "iddepartamento = " & valor
        Else
            DvCbProv.RowFilter = "iddepartamento = 0"
        End If
    End Sub

    Private Sub CbProv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbProv.SelectedIndexChanged
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
    End Sub

    Private Sub FrmConcesionarios_MenuEditar() Handles Me.MenuEditar
        Fact = 2
        Call Edicion()
    End Sub

    Private Sub FrmConcesionarios_MenuGrabar() Handles Me.MenuGrabar
        If Fact = 3 Then
            Dim filarow As Integer
            Dim DrAge As DataRowView
            Dim IDValor As String
            Dim i As Integer
            Dim dr2 As DataRowView
            filarow = DataGridViewLista.CurrentRow.Index
            If filarow >= 0 Then
                DrAge = DvAgencia.Item(filarow)
                IDValor = IIf(IsDBNull(DrAge("idempresas_concesion")) = True, "0", DrAge("idempresas_concesion").ToString)
                Try
                    Clase.ID = IDValor
                    Clase.Agencia = 0
                    Clase.Accion = 1
                    'Mod.25/09/2009 -->Omendoza - Pasando al datahelper   
                    Dim lds_tmp As New DataSet
                    Dim ldt_tmp As New DataTable
                    'rstAgeAso = Clase.GrabaAgenciasAsociadas
                    ldt_tmp = Clase.GrabaAgenciasAsociadas
                    '
                    For i = 1 To DvAge2.Count
                        dr2 = DvAge2.Item(i - 1)
                        Clase.ID = IDValor
                        Clase.Agencia = dr2("idagencias")
                        Clase.Accion = 2
                        'rstAgeAso = Clase.GrabaAgenciasAsociadas
                        ldt_tmp = Clase.GrabaAgenciasAsociadas
                    Next
                    MsgBox("Registro Grabado Correctamente", MsgBoxStyle.Information, "Seguridad del Sistema")
                    TabMante.SelectedIndex = 0
                    Exit Sub
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
                    Exit Sub
                End Try
            Else
                MsgBox("Empresa Vacia... Verifique!!!", MsgBoxStyle.Critical, "Seguridad del Sistema")
                Exit Sub
            End If
        End If
        If Trim(TxtNomEmp.Text) = "" Then
            MsgBox("Nombre de Empresa Vacio... Verifique!!!", MsgBoxStyle.Critical, "Seguridad del Sistema")
            Exit Sub
        End If
        Dim fil As Integer
        Dim filtro As String
        If Fact = 1 Then
            TxtID.Text = "0"
        End If
        Try
            Dim drpais, drdepa, drprov, drdist, drest As DataRowView
            'Dim drund As DataRowView
            drpais = DvCbPais.Item(CbPais.SelectedIndex)
            drdepa = DvCbDepar.Item(CbDepar.SelectedIndex)
            drprov = DvCbProv.Item(CbProv.SelectedIndex)
            drdist = DvCbDist.Item(CbDist.SelectedIndex)
            drest = DvCbEst.Item(CbStatus.SelectedIndex)
            'drund = DvCbUnd.Item(CbUnidad.SelectedIndex)
            Clase.Accion = Fact
            Clase.Pais = drpais("idpais")
            Clase.Departamento = drdepa("iddepartamento")
            Clase.Provincia = drprov("idprovincia")
            Clase.Distrito = drdist("iddistrito")
            Clase.Estado = drest("idestado_registro")
            'Clase.Unidad = drund("idunidad_agencia")
            Clase.ID = Convert.ToInt16(TxtID.Text)
            Clase.NomEmpresa = IIf(Trim(TxtNomEmp.Text) = "", " ", Trim(TxtNomEmp.Text))
            Clase.ApePatCto = IIf(Trim(TxtApePat.Text) = "", " ", Trim(TxtApePat.Text))
            Clase.ApeMatCto = IIf(Trim(TxtApeMat.Text) = "", " ", Trim(TxtApeMat.Text))
            'ncont = ""
            Clase.Contacto = IIf(Trim(TxtNomCon.Text) = "", " ", Trim(TxtNomCon.Text))
            Clase.Celular = IIf(Trim(TxtCelular.Text) = "", " ", Trim(TxtCelular.Text))
            Clase.Direccion = IIf(Trim(TxtDireccion.Text) = "", " ", Trim(TxtDireccion.Text))
            Clase.Telefono = IIf(Trim(TxtTelefono.Text) = "", " ", Trim(TxtTelefono.Text))
            Clase.RPM = IIf(Trim(TxtRPM.Text) = "", " ", Trim(TxtRPM.Text))
            Clase.Fax = IIf(Trim(TxtFax.Text) = "", " ", Trim(TxtFax.Text))
            Clase.RUC = IIf(Trim(TxtRUC.Text) = "", " ", Trim(TxtRUC.Text))
            Clase.NomCorto = IIf(Trim(TxtNomCorto.Text) = "", " ", Trim(TxtNomCorto.Text))
            Clase.Usuario = dtoUSUARIOS.IdLogin
            Clase.Rol = dtoUSUARIOS.IdRol
            Clase.IP = dtoUSUARIOS.IP
            'Mod.25/09/2009 -->Omendoza - Pasando al datahelper   
            'rst = Clase.Grabar
            Dim lds_tmp As DataSet
            lds_tmp = Clase.Grabar
            'If Convert.ToInt16(rst.Fields(0).Value) = 0 Then
            If Convert.ToInt16(lds_tmp.Tables(0).Rows(0).Item(0)) = 0 Then
                MsgBox("Registro Grabado Correctamente", MsgBoxStyle.Information, "Seguridad del Sistema")
                'rstRet = rst.NextRecordset() 
                filtro = DvAgencia.RowFilter
                DvAgencia.RowFilter = ""
                If Fact = 1 Then
                    fil = DvAgencia.Count
                    DvAgencia.AllowNew = True
                    DvAgencia.AddNew()
                    ActualizaGrilla(fil, lds_tmp.Tables(1))
                    DvAgencia.AllowNew = False
                Else
                    DvAgencia.Sort = "idempresas_concesion"
                    fil = DvAgencia.Find(IIf(IsDBNull(lds_tmp.Tables(0).Rows(0).Item(0)) = True, 0, lds_tmp.Tables(0).Rows(0).Item(0)))
                    If fil >= 0 Then
                        ActualizaGrilla(fil, lds_tmp.Tables(1))
                    End If
                End If
                DvAgencia.RowFilter = filtro
                'Call CargaDatos()
                'Call GrillaMante()
                TabMante.SelectedIndex = 0
            Else
                MessageBox.Show("Descripcion : " + Trim(Convert.ToString(lds_tmp.Tables(0).Rows(0).Item(1))), "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
            Exit Sub
        End Try
    End Sub

    Private Sub FrmConcesionarios_MenuImprimir() Handles Me.MenuImprimir
        Dim PrDialog As New PrintPreviewDialog
        Impresion.Titulo = "Relacion de Concesionarios"
        Impresion.DGV = DataGridViewLista
        PrDialog.Document = Impresion
        PrDialog.ShowDialog()
    End Sub
    Private Sub FrmConcesionarios_MenuNuevo() Handles Me.MenuNuevo
        TxtID.Text = ""
        TxtRUC.Text = ""
        TxtNomEmp.Text = ""
        TxtNomCorto.Text = ""
        TxtNomCon.Text = ""
        TxtCelular.Text = ""
        TxtDireccion.Text = ""
        TxtApePat.Text = ""
        TxtApeMat.Text = ""
        TxtTelefono.Text = ""
        TxtFax.Text = ""
        TxtRPM.Text = ""
        Fact = 1
        TabMante.SelectedIndex = 1
        TxtMensaje.Text = "Nuevo"
        TxtNomEmp.Focus()
    End Sub
    Sub ActualizaGrilla(ByVal filg As Integer, ByVal adt_table As DataTable)
        drg = DvAgencia.Item(filg)
        drg("IDEMPRESAS_CONCESION") = adt_table.Rows(0).Item(0)
        drg("IDDISTRITO") = adt_table.Rows(0).Item(1)
        drg("IDPROVINCIA") = adt_table.Rows(0).Item(2)
        drg("IDDEPARTAMENTO") = adt_table.Rows(0).Item(3)
        drg("IDPAIS") = adt_table.Rows(0).Item(4)
        drg("NOMBRE_EMPRESA") = adt_table.Rows(0).Item(5)
        drg("NOMBRE_CORTO") = adt_table.Rows(0).Item(6)
        drg("RUC") = adt_table.Rows(0).Item(7)
        drg("NOMBRE_CONTACTO") = adt_table.Rows(0).Item(8)
        drg("APEPAT_CONTACTO") = adt_table.Rows(0).Item(9)
        drg("APEMAT_CONTACTO") = adt_table.Rows(0).Item(10)
        drg("DIRECCION") = adt_table.Rows(0).Item(11)
        drg("CELULAR") = adt_table.Rows(0).Item(12)
        drg("TELEFONO") = adt_table.Rows(0).Item(13)
        drg("FAX") = adt_table.Rows(0).Item(14)
        drg("RPM") = adt_table.Rows(0).Item(15)
        drg("IDESTADO_REGISTRO") = adt_table.Rows(0).Item(16)
    End Sub
    Sub AgenciasAsociadas()
        Dim filarow As Integer
        Dim DrAge As DataRowView
        Dim IDValor As String
        Dim lds_tmp As New DataSet
        '
        filarow = DataGridViewLista.CurrentRow.Index
        If filarow >= 0 Then
            DrAge = DvAgencia.Item(filarow)
            IDValor = IIf(IsDBNull(DrAge("idempresas_concesion")) = True, "0", DrAge("idempresas_concesion").ToString)
            Clase.Filtro = IDValor
            '
            'Mod.25/09/2009 -->Omendoza - Pasando al datahelper   
            'rstAge1 = Clase.AgenciasAsociadas
            'rstAge2 = rstAge1.NextRecordset

            lds_tmp = Clase.AgenciasAsociadas
            DtAge1.Clear()
            DtAge2.Clear()
            DtAge1 = lds_tmp.Tables(0)
            DtAge2 = lds_tmp.Tables(1)

            'rstAge.MoveFirst()
            'dr4.Fill(DtAge1, rstAge1)
            DvAge1 = DtAge1.DefaultView
            DvAge1.AllowNew = False
            'rstAge.MoveFirst()
            'dr4.Fill(DtAge2, rstAge2)
            DvAge2 = DtAge2.DefaultView
            DvAge2.AllowNew = False
            TxtConcesion.Text = "NOMBRE DE EMPRESA : " & Trim(DrAge("nombre_empresa").ToString)
            'DvAge1.RowFilter = "idempresas_concesion is null or idempresas_concesion <> " & IDValor
            'DvAge2.RowFilter = "idempresas_concesion = " & IDValor
        Else
            TxtConcesion.Text = "NO TIENE EMPRESA ASIGNADA"
        End If
    End Sub

    Private Sub BtAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAgregar.Click
        Dim i, k As Integer
        Dim dro, drc, drv As DataRowView
        Dim FValor, IDAge, bus As Integer
        Dim IDValor As String
        dro = DvAgencia.Item(DataGridViewLista.CurrentRow.Index)
        IDValor = IIf(IsDBNull(dro("idempresas_concesion")) = True, "0", dro("idempresas_concesion").ToString)
        For i = 1 To DvAge1.Count
            If i - 1 >= DvAge1.Count Then
                Exit For
            End If
            drv = DvAge1.Item(i - 1)
            FValor = IIf(IsDBNull(drv("flag")) = True, 0, drv("flag"))
            If FValor = 1 Then
                DvAge2.Sort = "idagencias"
                IDAge = drv("idagencias")
                bus = DvAge2.Find(IDAge)
                If bus < 0 Then
                    k = DvAge2.Count
                    DvAge2.AllowNew = True
                    DvAge2.AddNew()
                    drc = DvAge2.Item(k)
                    drc("idagencias") = IDAge
                    drc("nombre_agencia") = drv("nombre_agencia")
                    drc("idunidad_agencia") = drv("idunidad_agencia")
                    drc("idempresas_concesion") = IDValor
                    drc("flag") = 0
                    DvAge2.AllowNew = False
                    DvAge1.Delete(i - 1)
                    i = i - 1
                End If
            End If
        Next
        k = DvAge2.Count
        DvAge2.AllowNew = True
        DvAge2.AddNew()
        DvAge2.AllowNew = False
        DvAge2.Delete(k)
        DataGridAge2.Focus()
    End Sub

    Private Sub BtSacar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSacar.Click
        Dim i, k As Integer
        Dim dro, drc, drv As DataRowView
        Dim FValor, IDAge, bus As Integer
        Dim filtro As String
        filtro = DvAge1.RowFilter
        DvAge1.RowFilter = ""
        Dim IDValor As String
        dro = DvAgencia.Item(DataGridViewLista.CurrentRow.Index)
        IDValor = IIf(IsDBNull(dro("idempresas_concesion")) = True, "0", dro("idempresas_concesion").ToString)
        For i = 1 To DvAge2.Count
            If i - 1 >= DvAge2.Count Then
                Exit For
            End If
            drv = DvAge2.Item(i - 1)
            FValor = IIf(IsDBNull(drv("flag")) = True, 0, drv("flag"))
            If FValor = 1 Then
                DvAge1.Sort = "idagencias"
                IDAge = drv("idagencias")
                bus = DvAge1.Find(IDAge)
                If bus < 0 Then
                    k = DvAge1.Count
                    DvAge1.AllowNew = True
                    DvAge1.AddNew()
                    drc = DvAge1.Item(k)
                    drc("idagencias") = IDAge
                    drc("nombre_agencia") = drv("nombre_agencia")
                    drc("idunidad_agencia") = drv("idunidad_agencia")
                    drc("idempresas_concesion") = IDValor
                    drc("flag") = 0
                    DvAge1.AllowNew = False
                    DvAge2.Delete(i - 1)
                    i = i - 1
                End If
            End If
        Next
        k = DvAge1.Count
        DvAge1.AllowNew = True
        DvAge1.AddNew()
        DvAge1.AllowNew = False
        DvAge1.Delete(k)
        DvAge1.RowFilter = filtro
        DataGridAge1.Focus()
    End Sub

    Private Sub CbUnidad_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbUnidad.SelectedIndexChanged
        Try
            Dim filcb As Integer
            Dim drc As DataRowView
            Dim valor As String
            filcb = CbUnidad.SelectedIndex
            If filcb >= 0 Then
                drc = DvCbUnd.Item(filcb)
                valor = IIf(IsDBNull(drc("idunidad_agencia")) = True, "0", drc("idunidad_agencia").ToString)
                If valor = "9999" Then
                    DvAge1.RowFilter = ""
                Else
                    DvAge1.RowFilter = "idunidad_agencia = " & valor
                End If
            Else
                DvAge1.RowFilter = "idunidad_agencia = 0"
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer
        Dim drt As DataRowView
        For i = 1 To DvAge1.Count
            drt = DvAge1.Item(i - 1)
            drt("flag") = 1
        Next
    End Sub
    Private Sub CbEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbEstado.SelectedIndexChanged
        Dim drsta As DataRowView
        drsta = DvCbSta.Item(CbEstado.SelectedIndex)
        IdSta = drsta("idestado_registro")
        Call GrabaFiltros()
    End Sub
    Sub GrabaFiltros()
        Dim filtro As String
        'If IdTag = 0 Then
        filtro = ""
        'Else
        '    filtro = "idunidad_agencia = " + Trim(IdTag)
        'End If
        If IdSta > 0 Then
            filtro = "idestado_registro = " + Trim(IdSta)
        End If
        DvAgencia.RowFilter = filtro
    End Sub
End Class
