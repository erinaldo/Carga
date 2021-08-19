'Imports System.Data.OleDb
Public Class FrmRutas
    Inherits FrmFormBase
    Dim Clase As New dtoRutas
    Dim Impresion As New ClsPrint
    'Dim rstRut, rstUnd, rstUnd2, rstOri, rstDes, rstRet, rstSta As ADODB.Recordset
    Dim dt, DtCbOri, DtCbDes, DtCbSta, DtCbEst As New System.Data.DataTable
    Dim DvAgencia, DvCbOri, DvCbDes, DvCbSta, DvCbEst As DataView
    Dim dvAgencia2 As DataView
    'Dim dr4 As New OleDbDataAdapter
    Dim drg As DataRowView
    Dim Fact, IdTag, IdSta As Integer
    Dim FlgTre As Integer
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub FrmRutas_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub

    Private Sub FrmRutas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmRutas_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus

    End Sub

    Private Sub FrmRutas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '
        Try
            Dim lds_tmp As New DataSet
            Dim ldt_rstUnd2 As New DataTable
            '
            ShadowLabel1.Text = "Mantenimiento de Rutas"
            dt.Clear()
            'rstRut = Clase.Lista
            'rstUnd = rstRut.NextRecordset
            'rstSta = rstRut.NextRecordset
            'rstUnd2 = rstRut.NextRecordset
            'dr4.Fill(dt, rstRut)
            'dr4.Fill(DtCbOri, rstUnd)
            'dr4.Fill(DtCbSta, rstSta)
            '
            lds_tmp = Clase.Lista
            dt = lds_tmp.Tables(0)
            DtCbOri = lds_tmp.Tables(1)
            DtCbSta = lds_tmp.Tables(2)
            ldt_rstUnd2 = lds_tmp.Tables(3)
            '
            DvAgencia = dt.DefaultView
            dvAgencia2 = dt.DefaultView
            DvAgencia.AllowNew = False
            '
            DvCbOri = DtCbOri.DefaultView
            DtCbDes = DtCbOri.Copy
            DvCbDes = DtCbDes.DefaultView
            '
            DvCbSta = DtCbSta.DefaultView
            DtCbEst = DtCbSta.Copy
            DvCbEst = DtCbEst.DefaultView
            DvCbEst.RowFilter = "idestado_registro <> 0"
            LlenaCombo2(DvCbOri, CbOrigen, "nombre_unidad")
            LlenaCombo2(DvCbDes, CbDestino, "nombre_unidad")
            LlenaCombo2(DvCbSta, CbEstado, "estado_registro")
            LlenaCombo2(DvCbEst, CbStatus, "estado_registro")
            'rstUnd.MoveFirst()
            'ModuUtil.LlenarTreeCtrl(rstUnd2, Me.TreeLista, "Ciudades")
            ModuUtil.LlenarTreeCtrl(ldt_rstUnd2, Me.TreeLista, "Ciudades")
            TreeLista.ExpandAll()
            MenuTab.Items(0).Text = "LISTA GENERAL"
            MenuTab.Items(1).Text = "DATOS GENERALES"
            DvAgencia.Sort = "nombre_ruta"
            Fact = 0
            FlgTre = 0
            IdTag = 0
            IdSta = 0
            Call GrillaMante()

            bIngreso = False
            Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
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
            .DataPropertyName = "IDRUTAS"
            .HeaderText = "Codigo"
            .Width = 60
        End With
        DataGridViewLista.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DataPropertyName = "nombre_ruta"
            .HeaderText = "Nombre Ruta"
            .Width = 300
        End With
        DataGridViewLista.Columns.Add(col1)

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .DataPropertyName = "dias_viaje"
            .HeaderText = "Dias"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridViewLista.Columns.Add(col2)

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .DataPropertyName = "horas_de_viaje"
            .HeaderText = "Horas"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridViewLista.Columns.Add(col3)
    End Sub
    Private Sub TreeLista_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeLista.AfterSelect
        IdTag = e.Node().Tag
        Call GrabaFiltros()
    End Sub
    Sub Edicion()
        Dim filarow As Integer
        Dim DrUnd As DataRowView
        filarow = DataGridViewLista.CurrentRow.Index
        If filarow >= 0 Then
            TabMante.SelectedIndex = 1
            DrUnd = DvAgencia.Item(DataGridViewLista.CurrentRow.Index)
            TxtID.Text = Convert.ToString(DrUnd("idrutas"))
            TxtKilo.Text = DrUnd("NROKILOMETROS").ToString
            'TxtTimeHor.Text = DrUnd("HORAS_VIAJE").ToString
            TxtTimeHor.Text = DrUnd("HORAS_DE_VIAJE").ToString
            TxtDias.Text = DrUnd("DIAS_VIAJE").ToString
            TxtError.Text = DrUnd("MARGEN_ERROR_HORAS").ToString
            If DrUnd("ES_VIGENTE").ToString = "0" Then
                ChkVigente.Checked = False
            Else
                ChkVigente.Checked = True
            End If
            CbOrigen.SelectedIndex = UbicaCombo2(DvCbOri, DrUnd, "idunidad_agencia", "idunidad_agencia", "nombre_unidad")
            CbDestino.SelectedIndex = UbicaCombo2(DvCbDes, DrUnd, "idunidad_agencia", "IDUNIDAD_AGENCIA_DESTINO", "nombre_unidad")
            CbStatus.SelectedIndex = UbicaCombo(DvCbEst, DrUnd, "idestado_registro")
            TxtMensaje.Text = "Modificacion"
            CbOrigen.Focus()
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

    Private Sub FrmRutas_MenuEditar() Handles Me.MenuEditar
        Fact = 2
        Call Edicion()
    End Sub

    Private Sub FrmRutas_MenuEliminar() Handles Me.MenuEliminar

    End Sub

    Private Sub FrmRutas_MenuGrabar() Handles Me.MenuGrabar
        Dim drori, drdes, drest As DataRowView
        Dim filtro As String
        If CbOrigen.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione el Origen", "Grabar Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CbOrigen.Focus()
            Return
        End If

        If CbDestino.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione el Destino", "Grabar Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CbDestino.Focus()
            Return
        End If

        If CbOrigen.SelectedIndex >= 0 And CbDestino.SelectedIndex >= 0 And Fact = 1 Then
            drori = DvCbOri.Item(CbOrigen.SelectedIndex)
            drdes = DvCbDes.Item(CbDestino.SelectedIndex)
            filtro = DvAgencia.RowFilter
            DvAgencia.RowFilter = "idunidad_agencia = " + Convert.ToString(drori("idunidad_agencia")) + " and idunidad_agencia_destino = " + Convert.ToString(drdes("idunidad_agencia"))
            'If DvAgencia.Count > 0 Then
            If dtoRutas.ExisteRuta(Convert.ToString(drori("idunidad_agencia")), Convert.ToString(drdes("idunidad_agencia"))) Then
                DvAgencia.RowFilter = filtro
                Dim a As String = DvAgencia.ToTable.Rows(0).Item(0).ToString
                MessageBox.Show("Ya existe una Ruta asignada para el Origen y Destino seleccionado", "Grabar Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            DvAgencia.RowFilter = filtro
        End If
        If CbDestino.SelectedValue = CbOrigen.SelectedValue Then
            MessageBox.Show("El Origen y Destino deben ser diferentes", "Grabar Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.CbOrigen.Focus()
            Exit Sub
        End If
        If TxtTimeHor.Text = "  :" Then
            MessageBox.Show("Ingrese las Horas de Viaje", "Grabar Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        'If Trim(TxtNomAgencia.Text) = "" Then
        '    MsgBox("Nombre de Agencia Vacio... Verifique!!!", MsgBoxStyle.Critical, "Seguridad del Sistema")
        '    Exit Sub
        'End If
        'If Trim(TxtCodAge.Text) = "" Then
        '    MsgBox("Codigo de Agencia Vacio... Verifique!!!", MsgBoxStyle.Critical, "Seguridad del Sistema")
        '    Exit Sub
        'End If
        Dim fil As Integer
        If Fact = 1 Then
            TxtID.Text = "0"
        End If
        Try
            drori = DvCbOri.Item(CbOrigen.SelectedIndex)
            drdes = DvCbDes.Item(CbDestino.SelectedIndex)
            drest = DvCbEst.Item(CbStatus.SelectedIndex)
            Clase.Accion = Fact
            Clase.Origen = drori("idunidad_agencia")
            Clase.Destino = drdes("idunidad_agencia")
            Clase.NomRuta = drori("nombre_unidad") + "-" + drdes("nombre_unidad")
            Clase.ID = Convert.ToInt16(TxtID.Text)
            If Trim(TxtKilo.Text) = "" Then
                Clase.Kilometros = 0.0
            Else
                Clase.Kilometros = Convert.ToDouble(TxtKilo.Text)
            End If
            Clase.Horas = IIf(Convert.ToString(TxtTimeHor.Text) = "", " ", Convert.ToString(TxtTimeHor.Text))
            If Trim(TxtDias.Text) = "" Then
                Clase.Dias = 0
            Else
                Clase.Dias = Convert.ToInt16(TxtDias.Text)
            End If
            If Trim(TxtError.Text) = "" Then
                Clase.ErrorHor = 0
            Else
                Clase.ErrorHor = Convert.ToDouble(TxtError.Text)
            End If
            If ChkVigente.Checked = True Then
                Clase.Vigente = 1
            Else
                Clase.Vigente = 0
            End If
            'Clase.Vigente = IIf(Trim(TxtVigencia.Text) = "", 0, Convert.ToInt16(TxtVigencia.Text))
            Clase.Usuario = dtoUSUARIOS.IdLogin
            Clase.Rol = dtoUSUARIOS.IdRol
            Clase.IP = dtoUSUARIOS.IP ' "192.168.50.47"
            Clase.Estado = drest("idestado_registro")
            'Mod.28/09/2009 -->Omendoza - Pasando al datahelper -  
            'rst = Clase.Grabar
            Dim lds_tmp As DataSet
            lds_tmp = Clase.Grabar
            If Convert.ToInt16(lds_tmp.Tables(0).Rows(0).Item(0)) = 0 Then
                'rstRet = rst.NextRecordset()
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
                    DvAgencia.Sort = "idrutas"
                    fil = DvAgencia.Find(IIf(IsDBNull(lds_tmp.Tables(1).Rows(0).Item(0)) = True, 0, lds_tmp.Tables(1).Rows(0).Item(0)))
                    If fil >= 0 Then
                        ActualizaGrilla(fil, lds_tmp.Tables(1))
                    End If
                    DvAgencia.Sort = "nombre_ruta"
                End If
                DtAyuRut = DvAgencia.ToTable
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

    Private Sub FrmRutas_MenuImprimir() Handles Me.MenuImprimir
        Dim PrDialog As New PrintPreviewDialog
        Impresion.Titulo = "Relacion de Rutas"
        Impresion.DGV = DataGridViewLista
        PrDialog.Document = Impresion
        PrDialog.ShowDialog()
    End Sub

    Private Sub FrmRutas_MenuNuevo() Handles Me.MenuNuevo
        TxtID.Text = ""
        TxtKilo.Text = 0
        TxtTimeHor.Text = ""
        TxtDias.Text = 0
        TxtError.Text = 0
        ChkVigente.Checked = True
        Fact = 1
        TabMante.SelectedIndex = 1
        CbOrigen.SelectedIndex = 0
        CbDestino.SelectedIndex = 0
        TxtMensaje.Text = "Nuevo"
        CbOrigen.Focus()
    End Sub
    Private Sub datagridviewlista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLista.DoubleClick
        Call Edicion()
    End Sub
    Private Sub TxtBusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBusca.TextChanged
        Try
            DvAgencia.RowFilter = "trim(nombre_ruta) like '*" & Trim(TxtBusca.Text) & "*'"
        Catch ex As Exception
            Exit Sub
        End Try

        'Call GrabaFiltros()
        'swgrid = True
    End Sub
    Sub ActualizaGrilla(ByVal filg As Integer, ByVal adt_table As DataTable)
        'Sub ActualizaGrilla(ByVal filg As Integer)
        drg = DvAgencia.Item(filg)
        drg("IDRUTAS") = adt_table.Rows(0).Item(0)
        drg("NOMBRE_RUTA") = adt_table.Rows(0).Item(1)
        drg("NROKILOMETROS") = adt_table.Rows(0).Item(2)
        drg("HORAS_VIAJE") = adt_table.Rows(0).Item(3)
        drg("DIAS_VIAJE") = adt_table.Rows(0).Item(4)
        drg("ES_VIGENTE") = adt_table.Rows(0).Item(5)
        drg("MARGEN_ERROR_HORAS") = adt_table.Rows(0).Item(6)
        drg("IDESTADO_REGISTRO") = adt_table.Rows(0).Item(7)
        drg("IDUNIDAD_AGENCIA") = adt_table.Rows(0).Item(8)
        drg("IDUNIDAD_AGENCIA_DESTINO") = adt_table.Rows(0).Item(9)
        drg("ORIGEN") = adt_table.Rows(0).Item(10)
        drg("DESTINO") = adt_table.Rows(0).Item(11)
        drg("IDESTADO_REGISTRO") = adt_table.Rows(0).Item(12)
        drg("HORAS_DE_VIAJE") = adt_table.Rows(0).Item(13)
    End Sub

    Private Sub TxtTimeHor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtTimeHor.Validating
        If Mid(Trim(TxtTimeHor.Text), 1, 2) > "23" Or Mid(Trim(TxtTimeHor.Text), 4, 2) > "59" Then
            MessageBox.Show("Hora Incorrecta", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If FlgTre = 0 Then
            If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
                SendKeys.Send("{Tab}")
                Return True
            End If
            Return MyBase.ProcessCmdKey(msg, keyData)
        Else
            FlgTre = 0
        End If

    End Function
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
            filtro = "idunidad_agencia = " + Trim(IdTag) + " or idunidad_agencia_destino = " + Trim(IdTag)
        End If
        If IdSta > 0 Then
            filtro = filtro + " and idestado_registro = " + Trim(IdSta)
        End If
        DvAgencia.RowFilter = filtro
    End Sub

    Private Sub CbStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbStatus.SelectedIndexChanged
        If CbStatus.Text = "ACTIVO" Then
            ChkVigente.Checked = True
        Else
            ChkVigente.Checked = False
        End If
    End Sub


    Private Sub CbDestino_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CbDestino.Validating
        'If CbDestino.Text = CbOrigen.Text Then
        '    MessageBox.Show("Origen - Destino Igual", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub CbOrigen_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CbOrigen.Validating
        'If CbDestino.Text = CbOrigen.Text Then
        '    MessageBox.Show("Origen - Destino Igual", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    e.Cancel = True
        'End If
    End Sub
    Sub VerificaCambio(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem1.EnabledChanged, CancelarToolStripMenuItem7.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class