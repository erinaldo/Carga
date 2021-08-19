Public Class FrmTarifaPasaje
    Inherits FrmFormBase
    Dim Clase As New dtoTarifaPasaje
    Dim ClaseDet As New dtoItinerario_Detalle
    'Dim rstIti, rstTar, rstUnd, rstSer, rstRut, rstArt, rstDetalle, rstRet As ADODB.Recordset
    'Dim dr4, da As New OleDbDataAdapter
    Dim dt, DtCbOri, DtCbRta, DtCbSer, DtCbOde, DtCbRut, DtCbSde, DtDetalle, DtArti, DtRutas, DtOriRut, DtDesRut, DtIti, DtDetaCopy As New System.Data.DataTable
    Dim DvAgencia, DvCbOri, DvCbRta, DvCbSer, DvCbOde, DvCbRut, DvCbSde, DvDetalle, DvArti, DvRutas, DvOriRut, DvDesRut, DvDetaCopy As DataView
    Dim DrUnd, dr, dr2, dr3, DrRuta, DrAge1, DrAge2, DrCopy As DataRowView
    Dim Fact, filcb, conta, AgeOri, AgeDes, i, IDUser As Integer
    Dim valor, NAgeOri, NAgeDes, CiuOri, CiuDes, hora_ini, hora_fin, horinia, horfina, filtro As String
    Dim fec_ini, fec_fin, rfec_ini, rfec_fin, fecinia, fecfina As Date
    Dim FlgTre As Integer
    Dim ndias As Double
    Dim chora As String
    Dim bIngreso As Boolean
    Public hnd As Long

    Private Sub FrmTarifaPasaje_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmTarifaPasaje_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmTarifaPasaje_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim lds_tmp As New DataSet
            '
            ShadowLabel1.Text = "Mantenimiento de Tarifarios - Pasajes"
            dt.Clear()
            'Mod.29/09/2009 -->Omendoza - Pasando al datahelper -  
            'rstTar = Clase.Lista
            'rstUnd = rstTar.NextRecordset
            'rstSer = rstTar.NextRecordset
            'rstRut = rstTar.NextRecordset
            'rstDetalle = rstUnd.NextRecordset
            'dr4.Fill(dt, rstTar)
            'dr4.Fill(DtCbOri, rstUnd)
            'dr4.Fill(DtCbSer, rstSer)
            'dr4.Fill(DtCbRut, rstRut)
            'dr4.Fill(DtDetalle, rstDetalle)
            lds_tmp = Clase.Lista
            dt = lds_tmp.Tables(0)
            DtCbOri = lds_tmp.Tables(1)
            DtCbSer = lds_tmp.Tables(2)
            DtCbRut = lds_tmp.Tables(3)
            DtDetalle = lds_tmp.Tables(4)
            '
            DvAgencia = dt.DefaultView
            DvCbOri = DtCbOri.DefaultView
            DtCbOde = DtCbOri.Copy
            DvCbOde = DtCbOde.DefaultView
            DtOriRut = DtCbOri.Copy
            DvOriRut = DtOriRut.DefaultView
            DtDesRut = DtCbOri.Copy
            DvDesRut = DtDesRut.DefaultView

            DvCbSer = DtCbSer.DefaultView
            DtCbSde = DtCbSer.Copy
            DvCbSde = DtCbSde.DefaultView
            DvCbRut = DtCbRut.DefaultView
            DtCbRta = DtCbRut.Copy
            DvCbRta = DtCbRta.DefaultView
            DtRutas = DtCbRut.Copy
            DvRutas = DtRutas.DefaultView
            'DvCbOri.RowFilter = "idunidad_agencia <> 9999"
            DvCbOde.RowFilter = "idunidad_agencia <> 9999"
            DvCbSde.RowFilter = "idclase <> 9999"
            LlenaCombo2(DvCbOri, CbOrigen, "nombre_unidad")
            LlenaCombo2(DvCbRta, CbDestino, "nombre_ruta")
            LlenaCombo2(DvCbSer, CbServicio, "clase")
            LlenaCombo2(DvCbOde, CbOriDet, "nombre_unidad")
            LlenaCombo2(DvCbSde, CbSerDet, "clase")
            LlenaCombo2(DvCbRut, CbRuta, "nombre_ruta")
            LlenaCombo2(DvOriRut, CbOriRut, "nombre_unidad")
            LlenaCombo2(DvDesRut, CbDesRut, "nombre_unidad")
            '
            DvDetalle = DtDetalle.DefaultView
            DtDetaCopy = DtDetalle.Copy
            DvDetaCopy = DtDetaCopy.DefaultView
            DvAgencia.AllowNew = False
            DvDetalle.AllowNew = False
            DvRutas.AllowNew = False
            FlgTre = 0
            Fact = 0
            MenuTab.Items(0).Text = "BUSQUEDA"
            MenuTab.Items(1).Text = "DATOS GENERALES"
            MenuTab.Items(2).Text = "ACTUALIZACION MASIVA"
            Call GrillaMante2()
            'Call GrillaMante()
            Call GrillaRutas()

            bIngreso = False
            Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim NDia, NMes, NAno As String
        ''MaskedTextBox1.Text = DateTimePicker1.Value.Day & " / " & DateTimePicker1.Value.Month & " / " & DateTimePicker1.Value.Year
        'NDia = Mid((StrReverse("00" + Trim(Convert.ToString(DateTimePicker1.Value.Day)))), 1, 2)
        'NDia = StrReverse(NDia)
        'NMes = Mid((StrReverse("00" + Trim(Convert.ToString(DateTimePicker1.Value.Month)))), 1, 2)
        'NMes = StrReverse(NMes)
        'NAno = Mid((StrReverse("0000" + Trim(Convert.ToString(DateTimePicker1.Value.Year)))), 1, 4)
        'NAno = StrReverse(NAno)
        ''MaskedTextBox1.Text = DateTimePicker1.Value.Day & DateTimePicker1.Value.Month & DateTimePicker1.Value.Year
        'MaskedTextBox1.Text = NDia & NMes & NAno

    End Sub


    Private Sub MaskedTextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim fechamin As Date = #1/1/1900#
        'If MaskedTextBox1.Text <> "  /  /" Then
        '    Try
        '        MaskedTextBox1.Text = Format(CType(MaskedTextBox1.Text, Date), "dd/MM/yyyy")
        '    Catch ex As Exception
        '        MessageBox.Show("Error")
        '        MaskedTextBox1.Text = ""
        '        MaskedTextBox1.Focus()
        '    End Try
        'End If
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

    Sub GrillaMante()
        DataGridDeta.Columns.Clear()
        With DataGridDeta
            .AllowUserToAddRows = True
            .AllowUserToDeleteRows = True
            .AllowUserToOrderColumns = True
            .BackgroundColor = SystemColors.Info
            '.Font = New System.Drawing.Font("Tahoma", 14.0!, FontStyle.Bold)
            .ReadOnly = True
            .AutoGenerateColumns = False
            .VirtualMode = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersWidth = 10
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EAF")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .DataSource = DvDetalle
        End With

        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .DataPropertyName = "FECHA_ACTIVACION"
            .HeaderText = "Fecha Inicio"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "d"
        End With
        DataGridDeta.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DataPropertyName = "FECHA_DESACTIVACION"
            .HeaderText = "Fecha Fin"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "d"
        End With
        DataGridDeta.Columns.Add(col1)
        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .DataPropertyName = "FECHA_TARIFA"
            .HeaderText = "Fecha Fija"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "d"
        End With
        DataGridDeta.Columns.Add(col2)
        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .DataPropertyName = "HORA_TARIFA"
            .HeaderText = "Hora Fija"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridDeta.Columns.Add(col3)
        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .DataPropertyName = "VALOR_PASAJE"
            .HeaderText = "Valor Pasaje"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridDeta.Columns.Add(col4)
        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .DataPropertyName = "VIGENCIA"
            .HeaderText = "Vigencia"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridDeta.Columns.Add(col5)
    End Sub
    Sub GrillaMante2()
        DataGridViewLista.Columns.Clear()
        With DataGridViewLista
            .AllowUserToAddRows = True
            .AllowUserToDeleteRows = True
            .AllowUserToOrderColumns = True
            .BackgroundColor = SystemColors.Window
            '.Font = New System.Drawing.Font("Tahoma", 14.0!, FontStyle.Bold)
            .ReadOnly = True
            .AutoGenerateColumns = False
            .DataSource = DvAgencia
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
            .DataPropertyName = "IDTARIFAS_RUTAS"
            .HeaderText = "Nro.Tar."
            .Width = 60
        End With
        DataGridViewLista.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DataPropertyName = "NOMBRE_RUTA"
            .HeaderText = "Ruta"
            .Width = 100
        End With
        DataGridViewLista.Columns.Add(col1)

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .DataPropertyName = "CLASE"
            .HeaderText = "Servicio"
            .Width = 100
        End With
        DataGridViewLista.Columns.Add(col2)

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .DataPropertyName = "VALOR_PASAJE"
            .HeaderText = "Valor Pasaje"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Width = 50
        End With
        DataGridViewLista.Columns.Add(col3)

        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .DataPropertyName = "FECHA_TARIFA"
            .HeaderText = "Fecha Fija"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "d"
        End With
        DataGridViewLista.Columns.Add(col4)

        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .DataPropertyName = "HORA_TARIFA"
            .HeaderText = "Hora Fija"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridViewLista.Columns.Add(col5)

        Dim col6 As New DataGridViewTextBoxColumn
        With col6
            .DataPropertyName = "FECHA_ACTIVACION"
            .HeaderText = "Fecha Inicial"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "d"
        End With
        DataGridViewLista.Columns.Add(col6)

        Dim col7 As New DataGridViewTextBoxColumn
        With col7
            .DataPropertyName = "FECHA_DESACTIVACION"
            .HeaderText = "Fecha Final"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "d"
        End With
        DataGridViewLista.Columns.Add(col7)
    End Sub

    Sub GrillaRutas()
        With DataGridRutas
            .AllowUserToAddRows = True
            .AllowUserToDeleteRows = True
            .AllowUserToOrderColumns = True
            .BackgroundColor = SystemColors.Window
            '.Font = New System.Drawing.Font("Tahoma", 14.0!, FontStyle.Bold)
            .ReadOnly = False
            .AutoGenerateColumns = False
            .DataSource = DtRutas
            .VirtualMode = True
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersWidth = 10
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EAF")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
        End With

        Dim col0 As New DataGridViewCheckBoxColumn
        With col0
            .DataPropertyName = "flag"
            .HeaderText = "F"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .Width = 20
            .ReadOnly = False
        End With
        DataGridRutas.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DataPropertyName = "nombre_ruta"
            .HeaderText = "Ruta"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridRutas.Columns.Add(col1)

    End Sub




    Private Sub CbOriDet_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbOriDet.SelectedIndexChanged
        filcb = CbOriDet.SelectedIndex
        If filcb >= 0 Then
            dr = DvCbOde.Item(filcb)
            valor = IIf(IsDBNull(dr("idunidad_agencia")) = True, "0", dr("idunidad_agencia").ToString)
            DvCbRut.RowFilter = "idunidad_agencia = " & valor
        Else
            DvCbRut.RowFilter = "idunidad_agencia = 0"
        End If
    End Sub


    Private Sub TxtHora_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtHora.Validating
        If TxtHora.Text <> "  :" Then
            If Mid(Trim(TxtHora.Text), 1, 2) > "23" Or Mid(Trim(TxtHora.Text), 4, 2) > "59" Then
                MessageBox.Show("Hora Incorrecta", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub FrmTarifaPasaje_MenuEditar() Handles Me.MenuEditar
        Try
            Fact = 2
            Call Edicion()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Seguridad del Sistema")
            Exit Sub
        End Try
    End Sub

    Private Sub FrmTarifaPasaje_MenuGrabar() Handles Me.MenuGrabar
        'If Trim(TxtNomAgencia.Text) = "" Then
        '    MsgBox("Nombre de Agencia Vacio... Verifique!!!", MsgBoxStyle.Critical, "Seguridad del Sistema")
        '    Exit Sub
        'End If
        'If Trim(TxtCodAge.Text) = "" Then
        '    MsgBox("Codigo de Agencia Vacio... Verifique!!!", MsgBoxStyle.Critical, "Seguridad del Sistema")
        '    Exit Sub
        'End If
        Dim drrut, drclas As DataRowView
        Try
            If Fact = 1 Then
                TxtID.Text = "0"
            End If
            drrut = DvCbRut.Item(CbRuta.SelectedIndex)
            drclas = DvCbSde.Item(CbSerDet.SelectedIndex)
            Clase.Accion = Fact
            Clase.Clase = drclas("idclase")
            Clase.Ruta = drrut("idrutas")
            Clase.ID = Convert.ToInt16(TxtID.Text)
            'If ChkVigente.Checked = True Then
            Clase.Vigente = 1
            'Else
            '    Clase.Vigente = 0
            'End If
            Clase.Usuario = 1
            Clase.Rol = 1
            Clase.IP = "192.168.50.47"
            'Clase.Estado = drest("idestado_registro")
            Clase.Estado = 1
            Clase.Hora_Tar = Trim(TxtHora.Text)
            Clase.Fecha_Tar = TxtFecha.GetMyFecha
            Clase.Fecha_Ini = TxtFecIni.GetMyFecha
            Clase.Fecha_Fin = TxtFecFin.GetMyFecha
            Clase.Pasaje = Convert.ToDouble(TxtPasaje.Text)
            'Mod.29/09/2009 -->Omendoza - Pasando al datahelper -  
            Dim lds_tmp As DataSet
            ' rst = Clase.Grabar
            lds_tmp = Clase.Grabar
            'If Convert.ToInt16(rst.Fields(0).Value) = 0 Then
            If Convert.ToInt16(lds_tmp.Tables(0).Rows(0)(0)) = 0 Then
                'rstRet = rst.NextRecordset()
                MsgBox("Registro Grabado Correctamente", MsgBoxStyle.Information, "Seguridad del Sistema")
                filtro = DvAgencia.RowFilter
                dt.Clear()
                'dr4.Fill(dt, rstRet)
                dt = lds_tmp.Tables(1)
                DvAgencia = dt.DefaultView
                DvAgencia.RowFilter = filtro
                Call GrillaMante2()
                TabMante.SelectedIndex = 0
            Else
                'MessageBox.Show("Descripcion : " + Trim(Convert.ToString(rst.Fields(1).Value)), "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show("Descripcion : " + Trim(Convert.ToString(lds_tmp.Tables(0).Rows(0)(1))), "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
            Exit Sub
        End Try
    End Sub
    Private Sub FrmTarifaPasaje_MenuNuevo() Handles Me.MenuNuevo
        Fact = 1
        'TxtFecInicio._MyFecha = ""
        TxtFecIni._MyFecha = Today.ToString
        'TxtFecFin._MyFecha = Today.ToString
        TxtFecha._MyFecha = ""
        TxtHora.Text = ""
        TxtPasaje.Text = "0.00"
        TxtFecIni.Enabled = True
        TxtFecFin.Enabled = True
        DvCbOde.RowFilter = "idunidad_agencia <> 9999"
        DvCbSde.RowFilter = "idclase <> 9999"
        DvCbRut.RowFilter = ""
        CbOriDet.SelectedIndex = 0
        DtDetalle.Clear()
    End Sub


    Private Sub BtnAyuRut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAyuRut.Click
        DtAyuRut = DtCbRut.Copy
        Dim Ayuda As New FrmRutas
        'Ayuda.ShowDialog()

        Acceso.Asignar(Ayuda, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            Ayuda.ShowDialog()
            DtCbRut = DtAyuRut.Copy
            DvCbRut = DtCbRut.DefaultView
            LlenaCombo2(DvCbRut, CbRuta, "nombre_ruta")
        Else
            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Sub Edicion()
        Dim filarow As Integer
        filarow = DataGridViewLista.CurrentRow.Index
        If filarow >= 0 Then
            DrUnd = DvAgencia.Item(DataGridViewLista.CurrentRow.Index)
            Clase.Ruta = Convert.ToString(DrUnd("IDRUTAS"))
            Clase.Clase = Convert.ToString(DrUnd("IDCLASE"))
            DtDetalle.Clear()
            'Mod.29/09/2009 -->Omendoza - Pasando al datahelper -  
            'rstDetalle = Clase.Buscar
            'dr4.Fill(DtDetalle, rstDetalle)
            '
            DtDetalle = Clase.Buscar
            DvDetalle = DtDetalle.DefaultView
            TabMante.SelectedIndex = 1
            TxtID.Text = Convert.ToString(DrUnd("IDTARIFAS_RUTAS"))
            'TxtFecInicio._MyFecha = DrUnd("fecha_itinerario")
            TxtFecIni._MyFecha = DrUnd("FECHA_ACTIVACION")
            TxtFecFin._MyFecha = IIf(IsDBNull(DrUnd("FECHA_DESACTIVACION")) = True, "", DrUnd("FECHA_DESACTIVACION"))
            'CbOriDet.SelectedIndex = UbicaCombo2(DvCbOriDet, DrUnd, "idunidad_agencia", "idunidad_agencia", "nombre_unidad")
            'CbDesDet.SelectedIndex = UbicaCombo2(DvCbDesDet, DrUnd, "idunidad_agencia", "idunidad_agencia_destino", "nombre_unidad")
            DvCbOde.RowFilter = "idunidad_agencia = " + Convert.ToString(DrUnd("idunidad_agencia"))
            DvCbRut.RowFilter = "idrutas = " + Convert.ToString(DrUnd("idrutas"))
            DvCbSde.RowFilter = "idclase = " + Convert.ToString(DrUnd("idclase"))
            TxtPasaje.Text = Format(Math.Round(Convert.ToDouble(DrUnd("valor_pasaje")), 2), "####0.00")
            'CbRuta.SelectedIndex = UbicaCombo2(DvCbRut, DrUnd, "idrutas", "idrutas", "nombre_ruta")
            'CbAge1.SelectedIndex = UbicaCombo2(DvCbAg1, DrUnd, "idagencias", "idagencia_origen", "nombre_agencia")
            'CbAge2.SelectedIndex = UbicaCombo2(DvCbAg2, DrUnd, "idagencias", "idagencia_destino", "nombre_agencia")
            TxtMensaje.Text = "Modificacion"
            'TxtFecIni.Enabled = False
            'TxtFecFin.Enabled = False
            Call GrillaMante()
            CbOriDet.Focus()
        End If


    End Sub

    Sub UpdateCopyDetail(ByVal SId As Integer)
        DrCopy = DvDetalle.Item(SId)
        If DrCopy("idrutas_itinerarios") > 0 Then
            DvDetaCopy.Sort = "idrutas_itinerarios"
            IDUser = DvDetaCopy.Find(DrCopy("idrutas_itinerarios"))
            If IDUser >= 0 Then
                dr2 = DvDetaCopy.Item(IDUser)
                dr2("flgdel") = 1
            End If
        End If
    End Sub



    Private Sub CbOrigen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbOrigen.SelectedIndexChanged
        filcb = CbOrigen.SelectedIndex
        If filcb >= 0 Then
            dr = DvCbOri.Item(filcb)
            valor = IIf(IsDBNull(dr("idunidad_agencia")) = True, "0", dr("idunidad_agencia").ToString)
            DvCbRta.RowFilter = "idunidad_agencia = " & valor
            Call FiltraDatos()
        Else
            DvCbRta.RowFilter = "idunidad_agencia = 0"
        End If
    End Sub


    Private Sub CbOriRut_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbOriRut.SelectedIndexChanged
        filcb = CbOriRut.SelectedIndex
        If filcb >= 0 Then
            dr = DvOriRut.Item(filcb)
            valor = IIf(IsDBNull(dr("idunidad_agencia")) = True, "0", dr("idunidad_agencia").ToString)
            If valor = "9999" Then
                filtro = "1=1"
            Else
                filtro = "idunidad_agencia = " & valor
            End If
            filcb = CbDesRut.SelectedIndex
            If filcb >= 0 Then
                dr = DvDesRut.Item(filcb)
                valor = IIf(IsDBNull(dr("idunidad_agencia")) = True, "0", dr("idunidad_agencia").ToString)
                If valor <> "9999" Then
                    filtro = filtro & " and idunidad_agencia_destino = " & valor
                End If
            End If
            DvRutas.RowFilter = filtro
        Else
            DvRutas.RowFilter = "idunidad_agencia = 0"
        End If
    End Sub

    Private Sub CbDesRut_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbDesRut.SelectedIndexChanged
        filcb = CbOriRut.SelectedIndex
        If filcb >= 0 Then
            dr = DvOriRut.Item(filcb)
            valor = IIf(IsDBNull(dr("idunidad_agencia")) = True, "0", dr("idunidad_agencia").ToString)
            If valor = "9999" Then
                filtro = "1=1"
            Else
                filtro = "idunidad_agencia = " & valor
            End If
            filcb = CbDesRut.SelectedIndex
            If filcb >= 0 Then
                dr = DvDesRut.Item(filcb)
                valor = IIf(IsDBNull(dr("idunidad_agencia")) = True, "0", dr("idunidad_agencia").ToString)
                If valor <> "9999" Then
                    filtro = filtro & " and idunidad_agencia_destino = " & valor
                End If
            End If
            DvRutas.RowFilter = filtro
        Else
            DvRutas.RowFilter = "idunidad_agencia = 0"
        End If
    End Sub

    Private Sub TxtPasaje_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPasaje.Enter
        If Fact = 1 Then
            If CbSerDet.SelectedIndex >= 0 And CbRuta.SelectedIndex >= 0 Then
                DrAge1 = DvCbRut.Item(CbRuta.SelectedIndex)
                DrAge2 = DvCbSde.Item(CbSerDet.SelectedIndex)
                Clase.Ruta = Convert.ToString(DrAge1("IDRUTAS"))
                Clase.Clase = Convert.ToString(DrAge2("IDCLASE"))
                DtDetalle.Clear()
                'Mod.29/09/2009 -->Omendoza - Pasando al datahelper -
                'rstDetalle = Clase.Buscar
                'dr4.Fill(DtDetalle, rstDetalle)
                '
                DtDetalle = Clase.Buscar
                '
                DvDetalle = DtDetalle.DefaultView
                Call GrillaMante()
            End If
        End If
    End Sub

    Private Sub TxtPasaje_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtPasaje.Validating
        Try
            TxtPasaje.Text = Format(Math.Round(Convert.ToDouble(TxtPasaje.Text), 2), "####0.00")
        Catch ex As Exception
            MsgBox("Error en el Formato de Ingreso", MsgBoxStyle.Critical, "General Error")
            TxtPasaje.Text = "0.00"
            Exit Sub
        End Try
    End Sub


    Private Sub CbDestino_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbDestino.SelectedIndexChanged
        Call FiltraDatos()
    End Sub
    Sub FiltraDatos()
        Try
            filcb = CbDestino.SelectedIndex
            If filcb >= 0 Then
                dr = DvCbRta.Item(filcb)
                filtro = "idrutas = " + IIf(IsDBNull(dr("idrutas")) = True, "0", dr("idrutas").ToString)
                filcb = CbServicio.SelectedIndex
                If filcb >= 0 Then
                    dr = DvCbSer.Item(filcb)
                    valor = IIf(IsDBNull(dr("idclase")) = True, "0", dr("idclase").ToString)
                    If valor <> "9999" Then
                        filtro = filtro + " and idclase = " + valor
                    End If
                End If
                DvAgencia.RowFilter = filtro
            Else
                If Trim(CbOrigen.Text) = "TODOS" Then
                    DvAgencia.RowFilter = ""
                Else
                    DvAgencia.RowFilter = "idrutas = 0"
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub CbServicio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbServicio.SelectedIndexChanged
        Call FiltraDatos()
    End Sub

    Sub VerificaCambio(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem1.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, GrabarToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, CancelarToolStripMenuItem7.EnabledChanged, AyudaToolStripMenuItem1.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class