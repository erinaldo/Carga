'Imports System.Data.OleDb
Public Class FrmCPU
    Inherits FrmFormBase
    Dim Clase As New dtoCPU
    Dim Impresion As New ClsPrint
    'Dim rstUnd As ADODB.Recordset
    'Dim dr4 As New OleDbDataAdapter
    Dim drg As DataRowView
    Dim dt, DtCbAge, DtCbAre, DtCbMaq, DtCbSta As New System.Data.DataTable
    Dim dtCboMaquina As New DataTable
    Dim dtCboTipoIp As New DataTable
    Dim DvAgencia, DvCbAge, DvCbAre, DvCbMaq, DvCbSta As DataView
    Dim dvCboMaquina As DataView
    Dim dvCboTipoIp As DataView
    Dim Fact As Integer
    Dim bIngreso As Boolean
    Public hnd As Long

    Private Sub FrmCPU_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmCPU_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    'Private rstRet, rstAgeT, rstAge, rstAre, rstMaq, rstSta As ADODB.Recordset
    '
    Private Sub FrmCPU_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            ShadowLabel1.Text = "Mantenimiento de CPUs"
            dt.Clear()
            DtCbAge.Clear()
            'Mod.25/09/2009 -->Omendoza - Pasando al datahelper   
            'rstUnd = Clase.Lista
            'rstAgeT = rstUnd.NextRecordset
            'rstAge = rstUnd.NextRecordset
            'rstAre = rstUnd.NextRecordset
            'rstMaq = rstUnd.NextRecordset
            'rstSta = rstUnd.NextRecordset
            '
            'dr4.Fill(dt, rstUnd)
            'dr4.Fill(DtCbAge, rstAge)
            'dr4.Fill(DtCbAre, rstAre)
            'dr4.Fill(DtCbMaq, rstMaq)
            'dr4.Fill(DtCbSta, rstSta)
            '
            Dim lds_tmp As New DataSet
            lds_tmp = Clase.Lista
            dt = lds_tmp.Tables(0)
            DtCbAge = lds_tmp.Tables(1)

            DtCbAre = lds_tmp.Tables(3)
            DtCbMaq = lds_tmp.Tables(4)
            DtCbSta = lds_tmp.Tables(5)
            dtCboMaquina = lds_tmp.Tables(6)
            dtCboTipoIp = lds_tmp.Tables(7)
            '
            'DvAgencia = DtCbAge.DefaultView
            DvAgencia = dt.DefaultView
            '
            DvAgencia.AllowNew = False
            DvCbAge = DtCbAge.DefaultView
            DvCbAre = DtCbAre.DefaultView
            DvCbMaq = DtCbMaq.DefaultView
            DvCbSta = DtCbSta.DefaultView
            dvCboMaquina = dtCboMaquina.DefaultView
            dvCboTipoIp = dtCboTipoIp.DefaultView
            '        
            LlenaCombo2(DvCbAge, CbAgencia, "nombre_agencia")
            LlenaCombo2(DvCbAre, CbArea, "departamento_oficina")
            LlenaCombo2(DvCbMaq, CbMaquina, "tipo_maquina")
            LlenaCombo2(DvCbSta, CbEstado, "estado_registro")
            '07-01-2010
            LlenaCombo2(dvCboMaquina, cboMaquina, "tipo_computador")
            LlenaCombo2(dvCboTipoIp, cboTipoIp, "tipo_ip")
            '
            'ModuUtil.LlenarTreeCtrl(rstAge, Me.TreeLista, "Agencias")
            ModuUtil.LlenarTreeCtrl(DtCbAge, Me.TreeLista, "Agencias")
            TreeLista.ExpandAll()
            MenuTab.Items(0).Text = "LISTA GENERAL"
            MenuTab.Items(1).Text = "DATOS GENERALES"
            Fact = 0
            Call GrillaMante()

            bIngreso = False
            Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub
    Private Sub TreeLista_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeLista.AfterSelect
        Dim idagencia As Integer
        Dim filtro As String = ""
        idagencia = e.Node().Tag
        If idagencia <> "9999" Then
            'filtro = "IDAGENCIAS = '" & Trim(idagencia) & "'"
            filtro = "IDAGENCIAS = " & Trim(idagencia)
        Else
            filtro = ""
        End If
        DvAgencia.RowFilter = filtro
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
            .DataPropertyName = "IP"
            .HeaderText = "Codigo"
            .Width = 85
        End With
        DataGridViewLista.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DataPropertyName = "NOMBRE_EQUIPO"
            .HeaderText = "Nombre"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridViewLista.Columns.Add(col1)
    End Sub
    Sub Edicion()
        Dim filarow As Integer
        Dim DrUnd As DataRowView
        filarow = DataGridViewLista.CurrentRow.Index
        If filarow >= 0 Then
            TabMante.SelectedIndex = 1
            DrUnd = DvAgencia.Item(DataGridViewLista.CurrentRow.Index)
            TxtIP.Text = Convert.ToString(DrUnd("ip"))
            TxtNomEquipo.Text = DrUnd("nombre_equipo").ToString
            TxtNomRed.Text = DrUnd("nombre_red").ToString
            TxtRam.Text = DrUnd("ram_mb").ToString
            TxtParticion.Text = DrUnd("nro_particiones").ToString
            TxtReloj.Text = DrUnd("frecuencia_reloj").ToString
            TxtHD.Text = DrUnd("MEMORIA_DISCO_DURO_GB").ToString
            TxtServidor.Text = DrUnd("es_servidor").ToString
            CbArea.SelectedIndex = UbicaCombo(DvCbAre, DrUnd, "iddepartamento_oficina")
            CbMaquina.SelectedIndex = UbicaCombo(DvCbMaq, DrUnd, "idtipo_maquina")
            CbAgencia.SelectedIndex = UbicaCombo(DvCbAge, DrUnd, "idagencias")
            cboMaquina.SelectedIndex = UbicaCombo(dvCboMaquina, DrUnd, "idtipo_computador")
            cboTipoIp.SelectedIndex = UbicaCombo(dvCboTipoIp, DrUnd, "idtipo_ip")

            cboTipoAlmacen.SelectedIndex = DrUnd("almacen").ToString

            TxtMensaje.Text = "Modificacion"
            TxtIP.Focus()
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

    Private Sub FrmCPU_MenuEditar() Handles Me.MenuEditar
        Fact = 2
        Call Edicion()
    End Sub

    Private Sub FrmCPU_MenuGrabar() Handles Me.MenuGrabar
        If Trim(TxtNomEquipo.Text) = "" Then
            MsgBox("Nombre de Equipo Vacio... Verifique!!!", MsgBoxStyle.Critical, "Seguridad del Sistema")
            Exit Sub
        End If
        If Trim(TxtIP.Text) = "" Then
            MsgBox("IP Vacio... Verifique!!!", MsgBoxStyle.Critical, "Seguridad del Sistema")
            Exit Sub
        End If
        Dim fil As Integer
        Dim filtro As String
        'If Fact = 1 Then
        '    TxtID.Text = "0"
        'End If
        Try
            Dim drarea, drmaq, drage As DataRowView
            Dim drComputador As DataRowView
            Dim drTipoIp As DataRowView
            drarea = DvCbAre.Item(CbArea.SelectedIndex)
            drmaq = DvCbMaq.Item(CbMaquina.SelectedIndex)
            drage = DvCbAge.Item(CbAgencia.SelectedIndex)
            drComputador = dvCboMaquina.Item(cboMaquina.SelectedIndex)
            drTipoIp = dvCboTipoIp.Item(cboTipoIp.SelectedIndex)
            Clase.Accion = Fact
            Clase.Area = drarea("iddepartamento_oficina")
            Clase.TipoMaq = drmaq("idtipo_maquina")
            Clase.Agencia = drage("idagencias")
            Clase.IP = Trim(TxtIP.Text)
            Clase.NomEquipo = IIf(Trim(TxtNomEquipo.Text) = "", " ", Trim(TxtNomEquipo.Text))
            Clase.NomRed = IIf(Trim(TxtNomRed.Text) = "", " ", Trim(TxtNomRed.Text))
            Clase.Frec_Reloj = IIf(Convert.ToDecimal(TxtReloj.Text) = 0.0, 0.0, Convert.ToDecimal(TxtReloj.Text))
            Clase.RAM_Mb = IIf(Convert.ToInt16(TxtRam.Text) = 0, 0, Convert.ToInt16(TxtRam.Text))
            Clase.Particiones = IIf(Trim(TxtParticion.Text) = "", 0, Convert.ToInt16(TxtParticion.Text))
            Clase.HD_Gb = IIf(Trim(TxtHD.Text) = "", 0, Convert.ToInt16(TxtHD.Text))
            Clase.Servidor = IIf(Trim(TxtServidor.Text) = "", 0, Convert.ToInt16(TxtServidor.Text))
            'ncont = ""
            Clase.Usuario = dtoUSUARIOS.IdLogin
            Clase.Rol = dtoUSUARIOS.IdRol
            Clase.IP_Reg = dtoUSUARIOS.IP
            Clase.Computador = drComputador("idtipo_computador")
            Clase.TipoIp = drTipoIp("idtipo_ip")
            Clase.TipoAlmacen = Me.cboTipoAlmacen.SelectedIndex
            '
            'Mod.25/09/2009 -->Omendoza - Pasando al datahelper   
            Dim lds_tmp As New DataSet
            'rst = Clase.Grabar
            'rstRet = rst.NextRecordset()
            '
            lds_tmp = Clase.Grabar
            'rstRet = rst.NextRecordset()
            '
            If Convert.ToInt16(lds_tmp.Tables(0).Rows(0).Item(0)) = 0 Then
                MsgBox("Registro Grabado Correctamente", MsgBoxStyle.Information, "Seguridad del Sistema")
                filtro = DvAgencia.RowFilter
                DvAgencia.RowFilter = ""
                If Fact = 1 Then
                    fil = DvAgencia.Count
                    DvAgencia.AllowNew = True
                    DvAgencia.AddNew()
                    ActualizaGrilla(fil, lds_tmp.Tables(1))
                    DvAgencia.AllowNew = False
                Else
                    DvAgencia.Sort = "ip"
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

    Private Sub FrmCPU_MenuImprimir() Handles Me.MenuImprimir
        Dim PrDialog As New PrintPreviewDialog
        Impresion.Titulo = "Relacion de CPUs"
        Impresion.DGV = DataGridViewLista
        PrDialog.Document = Impresion
        PrDialog.ShowDialog()
    End Sub

    Private Sub FrmCPU_MenuNuevo() Handles Me.MenuNuevo
        TxtIP.Text = ""
        TxtNomEquipo.Text = ""
        TxtNomRed.Text = ""
        TxtRam.Text = 0
        TxtParticion.Text = 0
        TxtReloj.Text = 0
        TxtHD.Text = 0
        TxtServidor.Text = 0
        Fact = 1
        TabMante.SelectedIndex = 1
        TxtMensaje.Text = "Nuevo"
        Me.cboTipoIp.SelectedIndex = 0
        Me.cboMaquina.SelectedIndex = 1
        Me.cboTipoAlmacen.SelectedIndex = 0
        TxtIP.Focus()
    End Sub
    Private Sub datagridviewlista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLista.DoubleClick
        Call Edicion()
    End Sub
    Private Sub TxtBusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBusca.TextChanged
        Try
            DvAgencia.RowFilter = "trim(nombre_agencia) like '%" & Trim(TxtBusca.Text) & "%'"
            'Call GrabaFiltros()
            'swgrid = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Sub ActualizaGrilla(ByVal filg As Integer, ByVal adt_table As DataTable)


        drg = DvAgencia.Item(filg)
        drg("IP") = adt_table.Rows(0).Item(0)
        drg("NOMBRE_EQUIPO") = adt_table.Rows(0).Item(1)
        drg("NOMBRE_RED") = adt_table.Rows(0).Item(2)
        drg("IDDEPARTAMENTO_OFICINA") = adt_table.Rows(0).Item(3)
        drg("IDTIPO_MAQUINA") = adt_table.Rows(0).Item(4)
        drg("FRECUENCIA_RELOJ") = adt_table.Rows(0).Item(5)
        drg("RAM_MB") = adt_table.Rows(0).Item(6)
        drg("NRO_PARTICIONES") = adt_table.Rows(0).Item(7)
        drg("MEMORIA_DISCO_DURO_GB") = adt_table.Rows(0).Item(8)
        drg("ES_SERVIDOR") = adt_table.Rows(0).Item(9)
        drg("idagencias") = adt_table.Rows(0).Item(10)
        drg("idtipo_computador") = adt_table.Rows(0).Item(11)
        drg("idtipo_ip") = adt_table.Rows(0).Item(12)
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem1.EnabledChanged, CancelarToolStripMenuItem7.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class