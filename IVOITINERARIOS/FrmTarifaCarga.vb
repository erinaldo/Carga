'Imports System.Data.OleDb
Public Class FrmTarifaCarga
    Inherits FrmFormBase
    Dim Clase As New dtoTarifaCarga
    Dim Impresion As New ClsPrint
    Dim ClaseDet As New dtoItinerario_Detalle
    'Dim rstIti, rstTar, rstUnd, rstArt, rstArt2, rstDetalle, rstRet As ADODB.Recordset
    'Dim dr4, da As New OleDbDataAdapter
    Dim dt, DtCbOri, DtCbDes, DtCbOriDet, DtCbDesDet, DtCbOriM, DtCbDesM, DtDetalle, DtArti, DtRutas, DtIti, DtDetaCopy As New System.Data.DataTable
    Dim DvAgencia, DvCbOri, DvCbDes, DvCbOriDet, DvCbDesDet, DvCbOriM, DvCbDesM, DvDetalle, DvArti, DvRutas, DvDetaCopy As DataView
    Dim dr, dr2, dr3, DrRuta, DrAge1, DrAge2, DrCopy, DrUnd As DataRowView
    Dim Fact, filcb, conta, AgeOri, AgeDes, i, IDUser As Integer
    Dim valor, NAgeOri, NAgeDes, CiuOri, CiuDes, hora_ini, hora_fin, horinia, horfina, filtro As String
    Dim fec_ini, fec_fin, rfec_ini, rfec_fin, fecinia, fecfina As Date
    Dim FlgTre, FlgUpd As Integer
    Dim MontoArt As Double
    Dim bIngreso As Boolean
    Public hnd As Long

    Private Sub FrmTarifaCarga_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmTarifaCarga_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmTarifaCarga_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            ShadowLabel1.Text = "Mantenimiento de Tarifarios - Carga"
            SplitTarifarios.Visible = False
            SplitTarifarios.Panel1Collapsed = True
            SplitTarifarios.Panel2Collapsed = True
            dt.Clear()
            'Mod.28/09/2009 -->Omendoza - Pasando al datahelper -  
            'rstTar = Clase.Lista
            'rstUnd = rstTar.NextRecordset
            'rstArt = rstTar.NextRecordset
            'rstDetalle = rstTar.NextRecordset
            'dr4.Fill(dt, rstTar)
            'dr4.Fill(DtCbOri, rstUnd)
            'dr4.Fill(DtArti, rstArt)
            'dr4.Fill(DtDetalle, rstDetalle)

            Dim lds_tmp As New DataSet
            lds_tmp = Clase.Lista
            dt = lds_tmp.Tables(0)
            DtCbOri = lds_tmp.Tables(1)
            DtArti = lds_tmp.Tables(2)
            DtDetalle = lds_tmp.Tables(3)
            '
            DvCbOri = DtCbOri.DefaultView
            DtCbDes = DtCbOri.Copy
            DvCbDes = DtCbDes.DefaultView
            DtCbOriDet = DtCbOri.Copy
            DvCbOriDet = DtCbOriDet.DefaultView
            DtCbDesDet = DtCbOri.Copy
            DvCbDesDet = DtCbDesDet.DefaultView
            DtCbOriM = DtCbOri.Copy
            DvCbOriM = DtCbOriM.DefaultView
            DtCbDesM = DtCbOri.Copy
            DvCbDesM = DtCbDesM.DefaultView
            DvArti = DtArti.DefaultView
            DvAgencia = dt.DefaultView
            DtRutas = dt.Copy
            DvRutas = DtRutas.DefaultView
            LlenaCombo2(DvCbOri, CbOrigen, "nombre_unidad")
            LlenaCombo2(DvCbDes, CbDestino, "nombre_unidad")
            LlenaCombo2(DvCbOriDet, CbOriDet, "nombre_unidad")
            LlenaCombo2(DvCbDesDet, CbDesDet, "nombre_unidad")
            LlenaCombo2(DvCbOriM, CbOriMas, "nombre_unidad")
            LlenaCombo2(DvCbDesM, CbDesMas, "nombre_unidad")
            DvDetalle = DtDetalle.DefaultView
            DvAgencia.AllowNew = False
            DvDetalle.AllowNew = False
            DvArti.AllowNew = False
            DvRutas.AllowNew = False
            FlgTre = 0
            FlgUpd = 0
            Fact = 0
            MenuTab.Items(0).Text = "BUSQUEDA"
            MenuTab.Items(1).Text = "DATOS GENERALES"
            MenuTab.Items(1).Visible = False
            MenuTab.Items(2).Text = "ACTUALIZACION MASIVA"
            Call GrillaMante2()
            Call GrillaArticulo()
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

    'Private Sub BtBusca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        dr = DvCbRta.Item(CbOrigen.SelectedIndex)
    '        dr3 = DvCbSer.Item(CbServicio.SelectedIndex)
    '        Clase.Clase = dr3("idclase")
    '        Clase.Ruta = dr("idrutas")
    '        Clase.Fecha_Ini = TxtFechaIni.GetMyFecha
    '        Clase.Fecha_Lle = TxtFechaFin.GetMyFecha
    '        DtIti.Clear()
    '        rstIti = Clase.Buscar
    '        da.Fill(DtIti, rstIti)
    '        DvAgencia = DtIti.DefaultView
    '        DvAgencia.AllowNew = False
    '        Call GrillaMante2()
    '    Catch ex As Exception
    '        MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
    '    End Try
    'End Sub

    Private Sub BtBusca_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        FlgTre = 1
    End Sub
    Sub GrillaMante()
        With DataGridDeta
            .AllowUserToAddRows = True
            .AllowUserToDeleteRows = True
            .AllowUserToOrderColumns = True
            .BackgroundColor = SystemColors.Window
            '.Font = New System.Drawing.Font("Tahoma", 14.0!, FontStyle.Bold)
            .ReadOnly = True
            .AutoGenerateColumns = False
            .DataSource = DtDetalle
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
            .DataPropertyName = "fecha_activacion"
            .HeaderText = "Fecha Inicio"
            .Width = 100
            .DefaultCellStyle.Format = "d"
        End With
        DataGridDeta.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DataPropertyName = "fecha_desactivacion"
            .HeaderText = "Fecha Fin"
            .Width = 100
            .DefaultCellStyle.Format = "d"
        End With
        DataGridDeta.Columns.Add(col1)

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .DataPropertyName = "CG_MONTO_BASE"
            .HeaderText = "Carga-Mon.Base"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        DataGridDeta.Columns.Add(col2)

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .DataPropertyName = "CG_X_PESO"
            .HeaderText = "Carga-Peso"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        DataGridDeta.Columns.Add(col3)

        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .DataPropertyName = "CG_X_VOLUMEN"
            .HeaderText = "Carga-Volumen"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        DataGridDeta.Columns.Add(col4)


        'Dim col5 As New DataGridViewTextBoxColumn
        'With col5
        '    .DataPropertyName = "EC_MONTO_BASE"
        '    .HeaderText = "Encom.-Mon.Base"
        '    .Width = 80
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'End With
        'DataGridDeta.Columns.Add(col5)

        'Dim col6 As New DataGridViewTextBoxColumn
        'With col6
        '    .DataPropertyName = "EC_X_PESO"
        '    .HeaderText = "Encom.-Peso"
        '    .Width = 80
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'End With
        'DataGridDeta.Columns.Add(col6)

        'Dim col7 As New DataGridViewTextBoxColumn
        'With col7
        '    .DataPropertyName = "EC_X_VOLUMEN"
        '    .HeaderText = "Encom.-Volumen"
        '    .Width = 80
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'End With
        'DataGridDeta.Columns.Add(col7)

        'Dim col8 As New DataGridViewTextBoxColumn
        'With col8
        '    .DataPropertyName = "PO_MONTO_BASE"
        '    .HeaderText = "Postal-Mon.Base"
        '    .Width = 80
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'End With
        'DataGridDeta.Columns.Add(col8)

        'Dim col9 As New DataGridViewTextBoxColumn
        'With col9
        '    .DataPropertyName = "PO_X_PESO"
        '    .HeaderText = "Postal-Peso"
        '    .Width = 80
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'End With
        'DataGridDeta.Columns.Add(col9)

        'Dim col10 As New DataGridViewTextBoxColumn
        'With col10
        '    .DataPropertyName = "PO_X_VOLUMEN"
        '    .HeaderText = "Postal-Volumen"
        '    .Width = 80
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'End With
        'DataGridDeta.Columns.Add(col10)

        'Dim col11 As New DataGridViewTextBoxColumn
        'With col11
        '    .DataPropertyName = "GI_MONTO_BASE"
        '    .HeaderText = "Giros-Mon.Base"
        '    .Width = 80
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'End With
        'DataGridDeta.Columns.Add(col11)

        'Dim col12 As New DataGridViewTextBoxColumn
        'With col12
        '    .DataPropertyName = "GI_NORMAL"
        '    .HeaderText = "Giro Normal"
        '    .Width = 80
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'End With
        'DataGridDeta.Columns.Add(col12)

        'Dim col13 As New DataGridViewTextBoxColumn
        'With col13
        '    .DataPropertyName = "GI_TELEFONICO"
        '    .HeaderText = "Giro Telef."
        '    .Width = 80
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'End With
        'DataGridDeta.Columns.Add(col13)
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
            .DataPropertyName = "IDTARIFAS_CARGA"
            .HeaderText = "Nro.Tar."
            .Width = 60
        End With
        DataGridViewLista.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DataPropertyName = "ORIGEN"
            .HeaderText = "Origen"
            .Width = 100
        End With
        DataGridViewLista.Columns.Add(col1)

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .DataPropertyName = "destino"
            .HeaderText = "Destino"
            .Width = 100
        End With
        DataGridViewLista.Columns.Add(col2)

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .DataPropertyName = "CG_MONTO_BASE"
            .HeaderText = "Carga Mon Base"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Width = 60
        End With
        DataGridViewLista.Columns.Add(col3)

        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .DataPropertyName = "CG_X_PESO"
            .HeaderText = "Carga Peso"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Width = 60
        End With
        DataGridViewLista.Columns.Add(col4)

        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .DataPropertyName = "CG_X_VOLUMEN"
            .HeaderText = "Carga Volumen"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Width = 60
        End With
        DataGridViewLista.Columns.Add(col5)

        Dim col19 As New DataGridViewTextBoxColumn
        With col19
            .DataPropertyName = "CG_X_SOBRE"
            .HeaderText = "Carga Sobre"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Width = 60
        End With
        DataGridViewLista.Columns.Add(col19)

        DataGridViewLista.Refresh()

        Dim col6 As New DataGridViewTextBoxColumn
        With col6
            .DataPropertyName = "EC_MONTO_BASE"
            .HeaderText = "Encom. Mon Base"
            .Width = 50
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Visible = False
        End With
        DataGridViewLista.Columns.Add(col6)

        Dim col7 As New DataGridViewTextBoxColumn
        With col7
            .DataPropertyName = "EC_X_PESO"
            .HeaderText = "Encom. Peso"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Visible = False
        End With
        DataGridViewLista.Columns.Add(col7)

        Dim col8 As New DataGridViewTextBoxColumn
        With col8
            .DataPropertyName = "EC_X_VOLUMEN"
            .HeaderText = "Encom. Volumen"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Visible = False
        End With
        DataGridViewLista.Columns.Add(col8)

        Dim col9 As New DataGridViewTextBoxColumn
        With col9
            .DataPropertyName = "PO_MONTO_BASE"
            .HeaderText = "Postal Mon Base"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Visible = False
        End With
        DataGridViewLista.Columns.Add(col9)

        Dim col10 As New DataGridViewTextBoxColumn
        With col10
            .DataPropertyName = "PO_X_PESO"
            .HeaderText = "Postal Peso"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Visible = False
        End With
        DataGridViewLista.Columns.Add(col10)

        Dim col11 As New DataGridViewTextBoxColumn
        With col11
            .DataPropertyName = "PO_X_VOLUMEN"
            .HeaderText = "Postal Volumen"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Visible = False
        End With
        DataGridViewLista.Columns.Add(col11)

        Dim col12 As New DataGridViewTextBoxColumn
        With col12
            .DataPropertyName = "GI_MONTO_BASE"
            .HeaderText = "Giro Mon Base"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Visible = False
        End With
        DataGridViewLista.Columns.Add(col12)

        Dim col13 As New DataGridViewTextBoxColumn
        With col13
            .DataPropertyName = "GI_NORMAL"
            .HeaderText = "Giro Normal"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Visible = False
        End With
        DataGridViewLista.Columns.Add(col13)

        Dim col14 As New DataGridViewTextBoxColumn
        With col14
            .DataPropertyName = "GI_TELEFONICO"
            .HeaderText = "Giro Telef."
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Visible = False
        End With
        DataGridViewLista.Columns.Add(col14)


        Dim col15 As New DataGridViewTextBoxColumn
        With col15
            .DataPropertyName = "CG_MONTO_BASE_CONTADO"
            .HeaderText = "Carga Mon Base"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Width = 60
        End With
        DataGridViewLista.Columns.Add(col15)

        Dim col16 As New DataGridViewTextBoxColumn
        With col16
            .DataPropertyName = "CG_X_PESO_CONTADO"
            .HeaderText = "Carga Peso"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Width = 60
        End With
        DataGridViewLista.Columns.Add(col16)

        Dim col17 As New DataGridViewTextBoxColumn
        With col17
            .DataPropertyName = "CG_X_VOLUMEN_CONTADO"
            .HeaderText = "Carga Volumen"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Width = 60
        End With
        DataGridViewLista.Columns.Add(col17)

        Dim col18 As New DataGridViewTextBoxColumn
        With col18
            .DataPropertyName = "CG_X_SOBRE_CONTADO"
            .HeaderText = "Carga Sobre"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Width = 60
        End With
        DataGridViewLista.Columns.Add(col18)
        DataGridViewLista.Refresh()

        Dim col20 As New DataGridViewTextBoxColumn
        With col20
            .DataPropertyName = "PY_BASE_CONTADO"
            .HeaderText = "Carga Pyme Base"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Width = 60
        End With
        DataGridViewLista.Columns.Add(col20)

        Dim col21 As New DataGridViewTextBoxColumn
        With col21
            .DataPropertyName = "PY_PESO_CONTADO"
            .HeaderText = "Carga Pyme Peso"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Width = 60
        End With
        DataGridViewLista.Columns.Add(col21)

        Dim col22 As New DataGridViewTextBoxColumn
        With col22
            .DataPropertyName = "PY_VOLUMEN_CONTADO"
            .HeaderText = "Carga Pyme Volumen"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Width = 60
        End With
        DataGridViewLista.Columns.Add(col22)

        Dim col23 As New DataGridViewTextBoxColumn
        With col23
            .DataPropertyName = "PY_SOBRE_CONTADO"
            .HeaderText = "Carga Pyme Sobre"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Width = 60
        End With
        DataGridViewLista.Columns.Add(col23)

    End Sub
    Sub GrillaArticulo()
        DataGridArti.Columns.Clear()
        With DataGridArti
            .AllowUserToAddRows = True
            .AllowUserToDeleteRows = True
            .AllowUserToOrderColumns = True
            .BackgroundColor = SystemColors.Window
            '.Font = New System.Drawing.Font("Tahoma", 14.0!, FontStyle.Bold)
            .ReadOnly = False
            .AutoGenerateColumns = False
            .VirtualMode = True
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersWidth = 10
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EAF")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .DataSource = DtArti
        End With

        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .DataPropertyName = "NOMBRE_ARTICULO"
            .HeaderText = "Articulo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        DataGridArti.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DataPropertyName = "MONTO"
            .HeaderText = "Precio"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "####.#0"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        DataGridArti.Columns.Add(col1)

    End Sub
    Sub GrillaRutas()
        With DataGridRutas
            .Columns.Clear()
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
            .HeaderText = ""
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .Width = 20
            .ReadOnly = False
        End With
        DataGridRutas.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DataPropertyName = "origen"
            .HeaderText = "Origen"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Width = 200
        End With
        DataGridRutas.Columns.Add(col1)
        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .DataPropertyName = "destino"
            .HeaderText = "Destino"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Width = 200
        End With
        DataGridRutas.Columns.Add(col2)

    End Sub

    Private Sub FrmTarifaCarga_MenuCancelar() Handles Me.MenuCancelar
        'Fact = 0
        'CbOriDet.SelectedIndex = 0
        'CbDesDet.SelectedIndex = 0
    End Sub

    Private Sub FrmTarifaCarga_MenuEditar() Handles Me.MenuEditar
        Try
            Fact = 2
            Call Edicion()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Seguridad del Sistema")
            Exit Sub
        End Try
    End Sub

    Private Sub FrmTarifaCarga_MenuGrabar() Handles Me.MenuGrabar
        '
        Dim lds_tmp1 As DataSet
        '
        If Fact = 3 Then
            Try
                DataGridRutas.CurrentCell = DataGridRutas.Rows(0).Cells(0)
                'filcb = DvRutas.Count
                'DvRutas.AllowNew = True
                'DvRutas.AddNew()
                'DvRutas.Delete(filcb)
                'DvRutas.AllowNew = False
                FlgUpd = 0
                For i = 0 To DvRutas.Count - 1
                    dr = DvRutas.Item(i)
                    If IsDBNull(dr("flag")) = True Then
                        dr("flag") = 0
                    End If
                    If dr("flag") = 1 Then
                        SwFlgDet = 0
                        Clase.Accion = 2
                        Clase.Origen = dr("idunidad_agencia")
                        Clase.Destino = dr("idunidad_agencia_destino")
                        Clase.ID = dr("IDTARIFAS_CARGA")
                        Clase.Vigente = 1
                        Clase.Usuario = 1
                        Clase.Rol = 1
                        Clase.IP = dtoUSUARIOS.IP
                        Clase.Estado = 1
                        Clase.CMonBas = AsignaValorMasivo(Convert.ToDouble(dr("CG_MONTO_BASE")), Trim(TxtPMbC.Text), Trim(TxtMMbC.Text))
                        Clase.CPeso = AsignaValorMasivo(Convert.ToDouble(dr("CG_X_PESO")), Trim(TxtPppC.Text), Trim(TxtMppC.Text))
                        Clase.CVol = AsignaValorMasivo(Convert.ToDouble(dr("CG_X_VOLUMEN")), Trim(TxtPpvC.Text), Trim(TxtMpvC.Text))
                        Clase.CSobre = AsignaValorMasivo(Convert.ToDouble(IIf(IsDBNull(dr("CG_X_SOBRE")), 0, dr("CG_X_SOBRE"))), Trim(TxtPpsC.Text), Trim(TxtMpsC.Text))

                        Clase.CMonBasContado = AsignaValorMasivo(Convert.ToDouble(IIf(IsDBNull(dr("CG_MONTO_BASE_CONTADO")), 0, dr("CG_MONTO_BASE_CONTADO"))), Trim(TxtPMbCon.Text), Trim(TxtMMbCon.Text))
                        Clase.CPesoContado = AsignaValorMasivo(Convert.ToDouble(IIf(IsDBNull(dr("CG_X_PESO_CONTADO")), 0, dr("CG_X_PESO_CONTADO"))), Trim(TxtPppCon.Text), Trim(TxtMppCon.Text))
                        Clase.CVolContado = AsignaValorMasivo(Convert.ToDouble(IIf(IsDBNull(dr("CG_X_VOLUMEN_CONTADO")), 0, dr("CG_X_VOLUMEN_CONTADO"))), Trim(TxtPpvCon.Text), Trim(TxtMpvCon.Text))
                        Clase.CSobreContado = AsignaValorMasivo(Convert.ToDouble(IIf(IsDBNull(dr("CG_X_SOBRE_CONTADO")), 0, dr("CG_X_SOBRE_CONTADO"))), Trim(TxtPpsCon.Text), Trim(TxtMpsCon.Text))

                        Clase.EMonBas = AsignaValorMasivo(Convert.ToDouble(dr("EC_MONTO_BASE")), Trim(TxtPMbE.Text), Trim(TxtMMbE.Text))
                        Clase.EPeso = AsignaValorMasivo(Convert.ToDouble(dr("EC_X_PESO")), Trim(TxtPppE.Text), Trim(TxtMppE.Text))
                        Clase.EVol = AsignaValorMasivo(Convert.ToDouble(dr("EC_X_VOLUMEN")), Trim(TxtPpvE.Text), Trim(TxtMpvE.Text))
                        Clase.PMonBas = AsignaValorMasivo(Convert.ToDouble(dr("PO_MONTO_BASE")), Trim(TxtPMbP.Text), Trim(TxtMMbP.Text))
                        Clase.PPeso = AsignaValorMasivo(Convert.ToDouble(dr("PO_X_PESO")), Trim(TxtPppP.Text), Trim(TxtMppP.Text))
                        Clase.PVol = AsignaValorMasivo(Convert.ToDouble(dr("PO_X_VOLUMEN")), Trim(TxtPpvP.Text), Trim(TxtMpvP.Text))
                        Clase.GMonBas = AsignaValorMasivo(Convert.ToDouble(dr("GI_MONTO_BASE")), Trim(TxtPMbG.Text), Trim(TxtMMbG.Text))
                        Clase.GNormal = AsignaValorMasivo(Convert.ToDouble(dr("GI_NORMAL")), Trim(TxtPNor.Text), Trim(TxtMNor.Text))
                        Clase.GTelefono = AsignaValorMasivo(Convert.ToDouble(dr("GI_TELEFONICO")), Trim(TxtPTel.Text), Trim(TxtMTel.Text))
                        Clase.Fecha_Ini = Today.ToString
                        Clase.Fecha_Fin = "/  /"
                        '
                        If SwFlgDet = 1 Then
                            'rst = Clase.Grabar
                            lds_tmp1 = Clase.Grabar

                            'If Convert.ToInt16(rst.Fields(0).Value) = 0 Then
                            If Convert.ToInt16(lds_tmp1.Tables(0).Rows(0)(0)) = 0 Then
                                FlgUpd = 1
                            End If
                        Else
                            MsgBox("No se Registraron Valores para actualizar", MsgBoxStyle.Information, "Seguridad del Sistema")
                        End If
                    End If
                Next
                If FlgUpd = 1 Then
                    MsgBox("Registro Grabado Correctamente", MsgBoxStyle.Information, "Seguridad del Sistema")
                    dt.Clear()
                    DtRutas.Clear()
                    'Mod.28/09/2009 -->Omendoza - Pasando al datahelper -  
                    'rstTar = Clase.Lista
                    'dr4.Fill(dt, rstTar)
                    Dim lds_tmp As New DataSet
                    lds_tmp = Clase.Lista
                    dt = lds_tmp.Tables(0)
                    'DtCbOri = lds_tmp.Tables(1)
                    'DtArti = lds_tmp.Tables(2)
                    'DtDetalle = lds_tmp.Tables(3)
                    '
                    DvAgencia = dt.DefaultView
                    DtRutas = dt.Copy
                    DvRutas = DtRutas.DefaultView
                    Call GrillaMante2()
                    Call GrillaRutas()
                    TabMante.SelectedIndex = 0
                End If
                Exit Sub
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
                Exit Sub
            End Try
        End If
        If TxtCMonBas.Text = "" Or TxtCMonBas.Text = "0.00" Then
            'MessageBox.Show("Monto Base debe ser Mayor que 0", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Exit Sub
        End If
        If TxtCPeso.Text = "" Or TxtCPeso.Text = "0.00" Then
            'MessageBox.Show("Precio por Peso debe ser Mayor que 0", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Exit Sub
        End If
        If TxtCVol.Text = "" Or TxtCVol.Text = "0.00" Then
            'MessageBox.Show("Precio por Volumen debe ser Mayor que 0", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Exit Sub
        End If

        If Val(TxtCMonBas.Text) = 0 And Val(TxtCPeso.Text) = 0 And Val(TxtCVol.Text) = 0 And Val(txtcMonSobre.Text) = 0 Then
            If Val(txtcMonBasContado.Text) = 0 And Val(TxtCPesoContado.Text) = 0 And Val(TxtCVolContado.Text) = 0 And Val(txtcMonSobreContado.Text) = 0 Then
                MessageBox.Show("Debe ingresar siquiera un monto.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        If CbOriDet.SelectedIndex >= 0 And CbDesDet.SelectedIndex >= 0 And Fact = 1 Then
            DrAge1 = DvCbOriDet.Item(CbOriDet.SelectedIndex)
            DrAge2 = DvCbDesDet.Item(CbDesDet.SelectedIndex)
            filtro = DvAgencia.RowFilter
            DvAgencia.RowFilter = "idunidad_agencia = " + Convert.ToString(DrAge1("idunidad_agencia")) + " and idunidad_agencia_destino = " + Convert.ToString(DrAge2("idunidad_agencia"))
            If DvAgencia.Count > 0 Then
                DvAgencia.RowFilter = filtro
                MessageBox.Show("Origen y Destino ya tiene una Tarifa asignada", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            DvAgencia.RowFilter = filtro
        End If
        If CbDesDet.Text = CbOriDet.Text Then
            MessageBox.Show("Origen - Destino Igual", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim drori, drdes As DataRowView
        FlgUpd = 0
        If Fact = 2 Then
            If Convert.ToDouble(TxtCMonBas.Text) <> Convert.ToDouble(DrUnd("cg_monto_base")) Then
                FlgUpd = 1
            End If
            If Convert.ToDouble(TxtEMonBas.Text) <> Convert.ToDouble(DrUnd("ec_monto_base")) Then
                FlgUpd = 1
            End If
            If Convert.ToDouble(TxtPMonBas.Text) <> Convert.ToDouble(DrUnd("po_monto_base")) Then
                FlgUpd = 1
            End If
            If Convert.ToDouble(TxtGMonBas.Text) <> Convert.ToDouble(DrUnd("gi_monto_base")) Then
                FlgUpd = 1
            End If
            If Convert.ToDouble(TxtCPeso.Text) <> Convert.ToDouble(DrUnd("cg_x_peso")) Then
                FlgUpd = 1
            End If
            If Convert.ToDouble(TxtEPeso.Text) <> Convert.ToDouble(DrUnd("ec_x_peso")) Then
                FlgUpd = 1
            End If
            If Convert.ToDouble(TxtPPeso.Text) <> Convert.ToDouble(DrUnd("po_x_peso")) Then
                FlgUpd = 1
            End If
            If Convert.ToDouble(TxtCVol.Text) <> Convert.ToDouble(DrUnd("cg_x_volumen")) Then
                FlgUpd = 1
            End If
            If Convert.ToDouble(TxtEVol.Text) <> Convert.ToDouble(DrUnd("ec_x_volumen")) Then
                FlgUpd = 1
            End If
            If Convert.ToDouble(TxtPVol.Text) <> Convert.ToDouble(DrUnd("po_x_volumen")) Then
                FlgUpd = 1
            End If
            If Convert.ToDouble(TxtGNor.Text) <> Convert.ToDouble(DrUnd("gi_normal")) Then
                FlgUpd = 1
            End If
            If Convert.ToDouble(TxtGTel.Text) <> Convert.ToDouble(DrUnd("gi_telefonico")) Then
                FlgUpd = 1
            End If
            If Convert.ToDouble(txtcMonSobre.Text) <> Convert.ToDouble(IIf(IsDBNull(DrUnd("cg_x_sobre")), 0, DrUnd("cg_x_sobre"))) Then
                FlgUpd = 1
            End If

            If Convert.ToDouble(txtcMonBasContado.Text) <> Convert.ToDouble(IIf(IsDBNull(DrUnd("cg_monto_base_contado")), 0, DrUnd("cg_monto_base_contado"))) Then
                FlgUpd = 1
            End If
            If Convert.ToDouble(TxtCPesoContado.Text) <> Convert.ToDouble(IIf(IsDBNull(DrUnd("cg_x_peso_contado")), 0, DrUnd("cg_x_peso_contado"))) Then
                FlgUpd = 1
            End If
            If Convert.ToDouble(TxtCVolContado.Text) <> Convert.ToDouble(IIf(IsDBNull(DrUnd("cg_x_volumen_contado")), 0, DrUnd("cg_x_volumen_contado"))) Then
                FlgUpd = 1
            End If
            If Convert.ToDouble(txtcMonSobreContado.Text) <> Convert.ToDouble(IIf(IsDBNull(DrUnd("cg_x_sobre_contado")), 0, DrUnd("cg_x_sobre_contado"))) Then
                FlgUpd = 1
            End If

            For i = 1 To DvArti.Count
                dr = DvArti.Item(i - 1)
                dr2 = DvDetaCopy.Item(i - 1)
                If IsDBNull(dr("monto")) = True Then
                    dr("monto") = 0
                End If
                If IsDBNull(dr2("monto")) = True Then
                    dr2("monto") = 0
                End If
                If dr("monto") <> dr2("monto") Then
                    FlgUpd = 1
                End If
            Next
            If FlgUpd = 0 Then
                MsgBox("Tarifario sin Modificaciones registradas", MsgBoxStyle.Information, "Seguridad del Sistema")
                Exit Sub
            End If
        End If
        Try
            If Fact = 1 Then
                TxtID.Text = "0"
            End If
            drori = DvCbOriDet.Item(CbOriDet.SelectedIndex)
            drdes = DvCbDesDet.Item(CbDesDet.SelectedIndex)
            Clase.Accion = Fact
            Clase.Origen = drori("idunidad_agencia")
            Clase.Destino = drdes("idunidad_agencia")
            Clase.ID = Convert.ToInt16(TxtID.Text)
            'If ChkVigente.Checked = True Then
            Clase.Vigente = 1
            'Else
            '    Clase.Vigente = 0
            'End If
            Clase.Usuario = dtoUSUARIOS.IdLogin ' 1
            Clase.Rol = dtoUSUARIOS.IdRol '1
            Clase.IP = dtoUSUARIOS.IP '"192.168.50.47" 
            'Clase.Estado = drest("idestado_registro")
            Clase.Estado = 1
            Clase.CMonBas = Convert.ToDouble(TxtCMonBas.Text)
            Clase.CPeso = Convert.ToDouble(TxtCPeso.Text)
            Clase.CVol = Convert.ToDouble(TxtCVol.Text)
            Clase.CSobre = Convert.ToDouble(txtcMonSobre.Text)

            Clase.CMonBasContado = Convert.ToDouble(txtcMonBasContado.Text)
            Clase.CPesoContado = Convert.ToDouble(TxtCPesoContado.Text)
            Clase.CVolContado = Convert.ToDouble(TxtCVolContado.Text)
            Clase.CSobreContado = Convert.ToDouble(txtcMonSobreContado.Text)

            Clase.EMonBas = Convert.ToDouble(TxtEMonBas.Text)
            Clase.EPeso = Convert.ToDouble(TxtEPeso.Text)
            Clase.EVol = Convert.ToDouble(TxtEVol.Text)
            Clase.PMonBas = Convert.ToDouble(TxtPMonBas.Text)
            Clase.PPeso = Convert.ToDouble(TxtPPeso.Text)
            Clase.PVol = Convert.ToDouble(TxtPVol.Text)
            Clase.GMonBas = Convert.ToDouble(TxtGMonBas.Text)
            Clase.GNormal = Convert.ToDouble(TxtGNor.Text)
            Clase.GTelefono = Convert.ToDouble(TxtGTel.Text)
            Clase.Fecha_Ini = Trim(TxtFecIni.GetMyFecha)
            Clase.Fecha_Fin = Trim(TxtFecFin.GetMyFecha)
            'Mod.28/09/2009 -->Omendoza - Pasando al datahelper -  
            'rst = Clase.Grabar
            '
            lds_tmp1 = Clase.Grabar
            If Convert.ToInt16(lds_tmp1.Tables(0).Rows(0)(0)) = 0 Then
                'If Convert.ToInt16(rst.Fields(0).Value) = 0 Then
                'rstRet = rst.NextRecordset()
                MsgBox("Registro Grabado Correctamente", MsgBoxStyle.Information, "Seguridad del Sistema")
                'Clase.Tarifa = rstRet.Fields(0).Value
                Clase.Tarifa = lds_tmp1.Tables(1).Rows(0)(0)
                '
                For i = 1 To DvArti.Count
                    dr = DvArti.Item(i - 1)
                    If IsDBNull(dr("monto")) = True Then
                        MontoArt = 0
                    Else
                        MontoArt = Convert.ToDouble(dr("monto"))
                    End If
                    If MontoArt > 0 Then
                        Clase.Articulo = Convert.ToInt16(dr("IDARTICULOS"))
                        Clase.Monto = MontoArt
                        'Mod.28/09/2009 -->Omendoza - Pasando al datahelper -  
                        Dim ldt_tmp As New DataTable
                        'rst = Clase.GrabarArticulo()
                        ldt_tmp = Clase.GrabarArticulo()
                        'If Convert.ToInt16(rst.Fields(0).Value) = 0 Then
                        If Convert.ToInt16(ldt_tmp.Rows(0)(0)) = 0 Then
                            MsgBox("Articulo Grabado Correctamente", MsgBoxStyle.Information, "Seguridad del Sistema")
                        Else
                            'MessageBox.Show("Descripcion : " + Trim(Convert.ToString(rst.Fields(1).Value)), "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            MessageBox.Show("Descripcion : " + Trim(Convert.ToString(ldt_tmp.Rows(0)(1))), "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                Next
                filtro = DvAgencia.RowFilter
                DvAgencia.RowFilter = filtro
                If Fact = 1 Then
                    filcb = DvAgencia.Count
                    DvAgencia.AllowNew = True
                    DvAgencia.AddNew()
                    ActualizaGrilla(filcb, lds_tmp1.Tables(1))
                    filcb = DvAgencia.Count
                    DvAgencia.AddNew()
                    DvAgencia.Delete(filcb)
                    DvAgencia.AllowNew = False
                    dt.AcceptChanges()
                Else
                    DvAgencia.Sort = "IDTARIFAS_CARGA"
                    filcb = DvAgencia.Find(TxtID.Text)
                    If filcb >= 0 Then
                        ActualizaGrilla(filcb, lds_tmp1.Tables(1))
                        dt.AcceptChanges()
                    End If
                End If
                DvAgencia.RowFilter = filtro
                Fact = 0
                CbOriDet.SelectedIndex = 0
                CbDesDet.SelectedIndex = 0
                TabMante.SelectedIndex = 0
            Else
                'MessageBox.Show("Error : " + Trim(Convert.ToString(rst.Fields(1).Value)), "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show("Error : " + Trim(Convert.ToString(lds_tmp1.Tables(0).Rows(0)(1))), "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
            Exit Sub
        End Try
    End Sub

    Private Sub FrmTarifaCarga_MenuImprimir() Handles Me.MenuImprimir
        Dim PrDialog As New PrintPreviewDialog
        Impresion.Titulo = "Relacion de Tarifas - Carga"
        Impresion.DGV = DataGridViewLista
        PrDialog.Document = Impresion
        PrDialog.ShowDialog()
    End Sub

    Private Sub FrmTarifaCarga_MenuMasivo() Handles Me.MenuMasivo
        Fact = 3
        TxtMMbC.Text = "0.00"
        TxtMMbE.Text = "0.00"
        TxtMMbP.Text = "0.00"
        TxtMMbG.Text = "0.00"
        TxtMppC.Text = "0.00"
        TxtMppE.Text = "0.00"
        TxtMppP.Text = "0.00"
        TxtMpvC.Text = "0.00"
        TxtMpvE.Text = "0.00"
        TxtMpvP.Text = "0.00"
        TxtPMbC.Text = "0.00"
        TxtPMbE.Text = "0.00"
        TxtPMbP.Text = "0.00"
        TxtPMbG.Text = "0.00"
        TxtPppC.Text = "0.00"
        TxtPppE.Text = "0.00"
        TxtPppP.Text = "0.00"
        TxtPpvC.Text = "0.00"
        TxtPpvE.Text = "0.00"
        TxtPpvP.Text = "0.00"
        TxtMNor.Text = "0.00"
        TxtPNor.Text = "0.00"
        TxtMTel.Text = "0.00"
        TxtPTel.Text = "0.00"

        TxtPpsC.Text = "0.00"
        TxtMpsC.Text = "0.00"

        TxtPMbCon.Text = "0.00"
        TxtPppCon.Text = "0.00"
        TxtPpvCon.Text = "0.00"
        TxtPpsCon.Text = "0.00"

        TxtMMbCon.Text = "0.00"
        TxtMppCon.Text = "0.00"
        TxtMpvCon.Text = "0.00"
        TxtMpsCon.Text = "0.00"
    End Sub

    Private Sub FrmTarifaCarga_MenuNuevo() Handles Me.MenuNuevo
        Fact = 1
        'TxtFecInicio._MyFecha = ""
        TxtFecIni._MyFecha = Convert.ToString(Today)
        TxtFecFin._MyFecha = ""
        TxtFecIni.Enabled = True
        TxtFecFin.Enabled = True
        TxtID.Text = "0"
        TxtCMonBas.Text = "0.00"
        'TxtCMonBas.Text = Microsoft.VisualBasic.Strings.Format("{0:n2}", Math.Round(0, 2))
        TxtCPeso.Text = "0.00"
        TxtCVol.Text = "0.00"
        txtcMonSobre.Text = "0.00"

        txtcMonBasContado.Text = "0.00"
        'TxtCMonBas.Text = Microsoft.VisualBasic.Strings.Format("{0:n2}", Math.Round(0, 2))
        TxtCPesoContado.Text = "0.00"
        TxtCVolContado.Text = "0.00"
        txtcMonSobreContado.Text = "0.00"

        TxtEMonBas.Text = "0.00"
        TxtEPeso.Text = "0.00"
        TxtEVol.Text = "0.00"
        TxtPMonBas.Text = "0.00"
        TxtPPeso.Text = "0.00"
        TxtPVol.Text = "0.00"
        TxtGMonBas.Text = "0.00"
        TxtGNor.Text = "0.00"
        TxtGTel.Text = "0.00"
        DvCbOriDet.RowFilter = "idunidad_agencia <> 9999"
        DvCbDesDet.RowFilter = "idunidad_agencia <> 9999"
        CbOriDet.SelectedIndex = 0
        CbDesDet.SelectedIndex = 0
        For i = 1 To DvArti.Count
            dr = DvArti.Item(i - 1)
            dr("monto") = 0
        Next
        DtDetaCopy = DtArti.Copy
        DvDetaCopy = DtDetaCopy.DefaultView
        DtDetalle.Clear()
    End Sub


    Private Sub BtnAyuRut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAyuRut.Click
        'DtAyuRut = DtCbRut.Copy
        'Dim Ayuda As New FrmRutas
        'Ayuda.ShowDialog()
        'DtCbRut = DtAyuRut.Copy
        'DvCbRut = DtCbRut.DefaultView
        'LlenaCombo2(DvCbRut, CbRuta, "nombre_ruta")
    End Sub

    Sub Edicion()
        Dim filarow As Integer        
        filarow = DataGridViewLista.CurrentRow.Index
        If filarow >= 0 Then
            DrUnd = DvAgencia.Item(DataGridViewLista.CurrentRow.Index)
            Clase.ID = Convert.ToString(DrUnd("IDTARIFAS_CARGA"))
            Clase.Origen = Convert.ToString(DrUnd("IDUNIDAD_AGENCIA"))
            Clase.Destino = Convert.ToString(DrUnd("IDUNIDAD_AGENCIA_DESTINO"))
            DtDetalle.Clear()
            DtArti.Clear()
            'Mod.28/09/2009 -->Omendoza - Pasando al datahelper -  
            'rstDetalle = Clase.Buscar
            'rstArt2 = rstDetalle.NextRecordset
            'dr4.Fill(DtDetalle, rstDetalle)
            'dr4.Fill(DtArti, rstArt2)
            '
            Dim lds_tmp As New DataSet
            '
            lds_tmp = Clase.Buscar
            DtDetalle = lds_tmp.Tables(0)
            DtArti = lds_tmp.Tables(1)
            '
            DvDetalle = DtDetalle.DefaultView
            DvArti = DtArti.DefaultView
            DtDetaCopy = DtArti.Copy
            DvDetaCopy = DtDetaCopy.DefaultView
            TabMante.SelectedIndex = 1
            TxtID.Text = Convert.ToString(DrUnd("IDTARIFAS_CARGA"))
            'TxtFecInicio._MyFecha = DrUnd("fecha_itinerario")
            TxtFecIni._MyFecha = DrUnd("FECHA_ACTIVACION")
            TxtFecFin._MyFecha = IIf(IsDBNull(DrUnd("FECHA_DESACTIVACION")) = True, "", DrUnd("FECHA_DESACTIVACION"))
            'CbOriDet.SelectedIndex = UbicaCombo2(DvCbOriDet, DrUnd, "idunidad_agencia", "idunidad_agencia", "nombre_unidad")
            'CbDesDet.SelectedIndex = UbicaCombo2(DvCbDesDet, DrUnd, "idunidad_agencia", "idunidad_agencia_destino", "nombre_unidad")
            DvCbOriDet.RowFilter = "idunidad_agencia = " + Convert.ToString(DrUnd("idunidad_agencia"))
            DvCbDesDet.RowFilter = "idunidad_agencia = " + Convert.ToString(DrUnd("idunidad_agencia_destino"))
            TxtCMonBas.Text = Format(Math.Round(Convert.ToDouble(DrUnd("CG_MONTO_BASE")), 2), "####0.00")
            txtcMonBasContado.Text = Format(Math.Round(Convert.ToDouble(IIf(IsDBNull(DrUnd("CG_MONTO_BASE_CONTADO")), 0, DrUnd("CG_MONTO_BASE_CONTADO"))), 2), "####0.00")
            TxtEMonBas.Text = Format(Math.Round(Convert.ToDouble(DrUnd("EC_MONTO_BASE")), 2), "####0.00")
            TxtPMonBas.Text = Format(Math.Round(Convert.ToDouble(DrUnd("PO_MONTO_BASE")), 2), "####0.00")
            TxtGMonBas.Text = Format(Math.Round(Convert.ToDouble(DrUnd("GI_MONTO_BASE")), 2), "####0.00")
            TxtCPeso.Text = Format(Math.Round(Convert.ToDouble(DrUnd("CG_X_PESO")), 2), "####0.00")
            TxtCPesoContado.Text = Format(Math.Round(Convert.ToDouble(IIf(IsDBNull(DrUnd("CG_X_PESO_CONTADO")), 0, DrUnd("CG_X_PESO_CONTADO"))), 2), "####0.00")
            TxtEPeso.Text = Format(Math.Round(Convert.ToDouble(DrUnd("EC_X_PESO")), 2), "####0.00")
            TxtPPeso.Text = Format(Math.Round(Convert.ToDouble(DrUnd("PO_X_PESO")), 2), "####0.00")
            TxtCVol.Text = Format(Math.Round(Convert.ToDouble(DrUnd("CG_X_VOLUMEN")), 2), "####0.00")
            TxtCVolContado.Text = Format(Math.Round(Convert.ToDouble(IIf(IsDBNull(DrUnd("CG_X_VOLUMEN_CONTADO")), 0, DrUnd("CG_X_VOLUMEN_CONTADO"))), 2), "####0.00")
            TxtEVol.Text = Format(Math.Round(Convert.ToDouble(DrUnd("EC_X_VOLUMEN")), 2), "####0.00")
            TxtPVol.Text = Format(Math.Round(Convert.ToDouble(DrUnd("PO_X_VOLUMEN")), 2), "####0.00")
            TxtGNor.Text = Format(Math.Round(Convert.ToDouble(DrUnd("GI_NORMAL")), 2), "####0.00")
            TxtGTel.Text = Format(Math.Round(Convert.ToDouble(DrUnd("GI_TELEFONICO")), 2), "####0.00")
            txtcMonSobreContado.Text = Format(Math.Round(Convert.ToDouble(IIf(IsDBNull(DrUnd("CG_X_SOBRE_CONTADO")), 0, DrUnd("CG_X_SOBRE_CONTADO"))), 2), "####0.00")
            txtcMonSobre.Text = Format(Math.Round(Convert.ToDouble(IIf(IsDBNull(DrUnd("CG_X_SOBRE")), 0, DrUnd("CG_X_SOBRE"))), 2), "####0.00")
            'CbRuta.SelectedIndex = UbicaCombo2(DvCbRut, DrUnd, "idrutas", "idrutas", "nombre_ruta")
            'CbAge1.SelectedIndex = UbicaCombo2(DvCbAg1, DrUnd, "idagencias", "idagencia_origen", "nombre_agencia")
            'CbAge2.SelectedIndex = UbicaCombo2(DvCbAg2, DrUnd, "idagencias", "idagencia_destino", "nombre_agencia")
            TxtMensaje.Text = "Modificacion"
            TxtFecIni.Enabled = False
            TxtFecFin.Enabled = False
            Call GrillaMante()
            Call GrillaArticulo()
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
            If valor = "9999" Then
                filtro = "1=1"
            Else
                filtro = "idunidad_agencia = " & valor
            End If
            filcb = CbDestino.SelectedIndex
            If filcb >= 0 Then
                dr = DvCbDes.Item(filcb)
                valor = IIf(IsDBNull(dr("idunidad_agencia")) = True, "0", dr("idunidad_agencia").ToString)
                If valor <> "9999" Then
                    filtro = filtro & " and idunidad_agencia_destino = " & valor
                End If
            End If
            DvAgencia.RowFilter = filtro
        Else
            DvAgencia.RowFilter = "idunidad_agencia = 0"
        End If
    End Sub


    Private Sub CbOriMas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbOriMas.SelectedIndexChanged
        filcb = CbOriMas.SelectedIndex
        If filcb >= 0 Then
            dr = DvCbOriM.Item(filcb)
            valor = IIf(IsDBNull(dr("idunidad_agencia")) = True, "0", dr("idunidad_agencia").ToString)
            If valor = "9999" Then
                filtro = "1=1"
            Else
                filtro = "idunidad_agencia = " & valor
            End If
            filcb = CbDesMas.SelectedIndex
            If filcb >= 0 Then
                dr = DvCbDesM.Item(filcb)
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

    Private Sub CbDesMas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbDesMas.SelectedIndexChanged
        filcb = CbOriMas.SelectedIndex
        If filcb >= 0 Then
            dr = DvCbOriM.Item(filcb)
            valor = IIf(IsDBNull(dr("idunidad_agencia")) = True, "0", dr("idunidad_agencia").ToString)
            If valor = "9999" Then
                filtro = "1=1"
            Else
                filtro = "idunidad_agencia = " & valor
            End If
            filcb = CbDesMas.SelectedIndex
            If filcb >= 0 Then
                dr = DvCbDesM.Item(filcb)
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

    Private Sub CbDestino_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbDestino.SelectedIndexChanged
        filcb = CbOrigen.SelectedIndex
        If filcb >= 0 Then
            dr = DvCbOri.Item(filcb)
            valor = IIf(IsDBNull(dr("idunidad_agencia")) = True, "0", dr("idunidad_agencia").ToString)
            If valor = "9999" Then
                filtro = "1=1"
            Else
                filtro = "idunidad_agencia = " & valor
            End If
            filcb = CbDestino.SelectedIndex
            If filcb >= 0 Then
                dr = DvCbDes.Item(filcb)
                valor = IIf(IsDBNull(dr("idunidad_agencia")) = True, "0", dr("idunidad_agencia").ToString)
                If valor <> "9999" Then
                    filtro = filtro & " and idunidad_agencia_destino = " & valor
                End If
            End If
            DvAgencia.RowFilter = filtro
        Else
            DvAgencia.RowFilter = "idunidad_agencia = 0"
        End If
    End Sub

    Private Sub TxtCMonBas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCMonBas.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub


    Private Sub TxtCMonBas_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCMonBas.Validating
        Try
            TxtCMonBas.Text = Format(Math.Round(Convert.ToDouble(TxtCMonBas.Text), 2), "####0.00")
            TxtEMonBas.Text = Format(Math.Round(Convert.ToDouble(TxtCMonBas.Text), 2), "####0.00")
            TxtPMonBas.Text = Format(Math.Round(Convert.ToDouble(TxtCMonBas.Text), 2), "####0.00")
            TxtGMonBas.Text = Format(Math.Round(Convert.ToDouble(TxtCMonBas.Text), 2), "####0.00")
        Catch ex As Exception
            MsgBox("Error en el Formato de Ingreso", MsgBoxStyle.Critical, "General Error")
            TxtMMbC.Text = "0.00"
            Exit Sub
        End Try
    End Sub

    Private Sub TxtCPeso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCPeso.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub TxtCPeso_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCPeso.Validating
        Try
            TxtCPeso.Text = Format(Math.Round(Convert.ToDouble(TxtCPeso.Text), 2), "####0.00")
            TxtEPeso.Text = Format(Math.Round(Convert.ToDouble(TxtCPeso.Text), 2), "####0.00")
            TxtPPeso.Text = Format(Math.Round(Convert.ToDouble(TxtCPeso.Text), 2), "####0.00")
        Catch ex As Exception
            MsgBox("Error en el Formato de Ingreso", MsgBoxStyle.Critical, "General Error")
            TxtMMbC.Text = "0.00"
            Exit Sub
        End Try
    End Sub

    Private Sub TxtCVol_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCVol.KeyDown
    End Sub

    Private Sub TxtCVol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCVol.Validating
        Try
            TxtCVol.Text = Format(Math.Round(Convert.ToDouble(TxtCVol.Text), 2), "####0.00")
            TxtEVol.Text = Format(Math.Round(Convert.ToDouble(TxtCVol.Text), 2), "####0.00")
            TxtPVol.Text = Format(Math.Round(Convert.ToDouble(TxtCVol.Text), 2), "####0.00")
        Catch ex As Exception
            MsgBox("Error en el Formato de Ingreso", MsgBoxStyle.Critical, "General Error")
            TxtMMbC.Text = "0.00"
            Exit Sub
        End Try
    End Sub

    Private Sub ChkHisto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkHisto.CheckedChanged
        If ChkArti.Checked = True Then
            SplitTarifarios.Visible = True
            If ChkHisto.Checked = True Then
                SplitTarifarios.Panel1Collapsed = False
                SplitTarifarios.Panel2Collapsed = False
            Else
                SplitTarifarios.Panel1Collapsed = True
                SplitTarifarios.Panel2Collapsed = False
            End If
        Else
            If ChkHisto.Checked = False Then
                SplitTarifarios.Visible = False
            Else
                SplitTarifarios.Visible = True
                SplitTarifarios.Panel1Collapsed = False
                SplitTarifarios.Panel2Collapsed = True
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Articulos As New FrmManTablas("Mantenimiento de Articulos", "PKG_IVOITINERARIOS.SP_LISTA_ARTICULOS", "PKG_IVOITINERARIOS.SP_INSUPD_ARTICULOS", "IDARTICULOS", "NOMBRE_ARTICULO", "null")
        'Articulos.ShowDialog()
        Acceso.Asignar(Articulos, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            Articulos.ShowDialog()
        Else
            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub ChkArti_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkArti.CheckedChanged
        If ChkArti.Checked = True Then
            SplitTarifarios.Visible = True
            If ChkHisto.Checked = True Then
                SplitTarifarios.Panel1Collapsed = False
                SplitTarifarios.Panel2Collapsed = False
            Else
                SplitTarifarios.Panel1Collapsed = True
                SplitTarifarios.Panel2Collapsed = False
            End If
        Else
            If ChkHisto.Checked = False Then
                SplitTarifarios.Visible = False
            Else
                SplitTarifarios.Visible = True
                SplitTarifarios.Panel1Collapsed = False
                SplitTarifarios.Panel2Collapsed = True
            End If
        End If
    End Sub

    Private Sub CbDesDet_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbDesDet.SelectedIndexChanged
        If CbOriDet.SelectedIndex >= 0 And CbDesDet.SelectedIndex >= 0 And Fact = 1 Then
            DrAge1 = DvCbOriDet.Item(CbOriDet.SelectedIndex)
            DrAge2 = DvCbDesDet.Item(CbDesDet.SelectedIndex)
            filtro = DvAgencia.RowFilter
            DvAgencia.RowFilter = "idunidad_agencia = " + Convert.ToString(DrAge1("idunidad_agencia")) + " and idunidad_agencia_destino = " + Convert.ToString(DrAge2("idunidad_agencia"))
            If DvAgencia.Count > 0 Then
                DvAgencia.RowFilter = filtro
                MessageBox.Show("Origen y Destino ya tiene una Tarifa asignada", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            DvAgencia.RowFilter = filtro
        End If
    End Sub

    Sub ActualizaGrilla(ByVal filg As Integer, ByVal adt_datatable As DataTable)
        dr = DvAgencia.Item(filg)
        'dr("IDTARIFAS_CARGA") = rstRet.Fields("IDTARIFAS_CARGA").Value
        'dr("IDUNIDAD_AGENCIA") = rstRet.Fields("IDUNIDAD_AGENCIA").Value
        'dr("IDUNIDAD_AGENCIA_DESTINO") = rstRet.Fields("IDUNIDAD_AGENCIA_DESTINO").Value
        'dr("CG_MONTO_BASE") = rstRet.Fields("CG_MONTO_BASE").Value
        'dr("CG_X_PESO") = rstRet.Fields("CG_X_PESO").Value
        'dr("CG_X_VOLUMEN") = rstRet.Fields("CG_X_VOLUMEN").Value

        'dr("CG_MONTO_BASE_CONTADO") = rstRet.Fields("CG_MONTO_BASE_CONTADO").Value
        'dr("CG_X_PESO_CONTADO") = rstRet.Fields("CG_X_PESO_CONTADO").Value
        'dr("CG_X_VOLUMEN_CONTADO") = rstRet.Fields("CG_X_VOLUMEN_CONTADO").Value
        'dr("CG_X_SOBRE_CONTADO") = rstRet.Fields("CG_X_SOBRE_CONTADO").Value
        'dr("CG_X_SOBRE") = rstRet.Fields("CG_X_SOBRE").Value

        'dr("EC_MONTO_BASE") = rstRet.Fields("EC_MONTO_BASE").Value
        'dr("EC_X_PESO") = rstRet.Fields("EC_X_PESO").Value
        'dr("EC_X_VOLUMEN") = rstRet.Fields("EC_X_VOLUMEN").Value
        'dr("PO_MONTO_BASE") = rstRet.Fields("PO_MONTO_BASE").Value
        'dr("PO_X_PESO") = rstRet.Fields("PO_X_PESO").Value
        'dr("PO_X_VOLUMEN") = rstRet.Fields("PO_X_VOLUMEN").Value
        'dr("GI_MONTO_BASE") = rstRet.Fields("GI_MONTO_BASE").Value
        'dr("GI_NORMAL") = rstRet.Fields("GI_NORMAL").Value
        'dr("GI_TELEFONICO") = rstRet.Fields("GI_TELEFONICO").Value
        'dr("FECHA_ACTIVACION") = rstRet.Fields("FECHA_ACTIVACION").Value
        'dr("FECHA_DESACTIVACION") = rstRet.Fields("FECHA_DESACTIVACION").Value
        'dr("ES_VIGENTE") = rstRet.Fields("ES_VIGENTE").Value
        'dr("ORIGEN") = rstRet.Fields("ORIGEN").Value
        'dr("DESTINO") = rstRet.Fields("DESTINO").Value
        '''''''''''''''''''''''''
        dr("IDTARIFAS_CARGA") = adt_datatable.Rows(0).Item("IDTARIFAS_CARGA")
        dr("IDUNIDAD_AGENCIA") = adt_datatable.Rows(0).Item("IDUNIDAD_AGENCIA")
        dr("IDUNIDAD_AGENCIA_DESTINO") = adt_datatable.Rows(0).Item("IDUNIDAD_AGENCIA_DESTINO")
        dr("CG_MONTO_BASE") = adt_datatable.Rows(0).Item("CG_MONTO_BASE")
        dr("CG_X_PESO") = adt_datatable.Rows(0).Item("CG_X_PESO")
        dr("CG_X_VOLUMEN") = adt_datatable.Rows(0).Item("CG_X_VOLUMEN")

        dr("CG_MONTO_BASE_CONTADO") = adt_datatable.Rows(0).Item("CG_MONTO_BASE_CONTADO")
        dr("CG_X_PESO_CONTADO") = adt_datatable.Rows(0).Item("CG_X_PESO_CONTADO")
        dr("CG_X_VOLUMEN_CONTADO") = adt_datatable.Rows(0).Item("CG_X_VOLUMEN_CONTADO")
        dr("CG_X_SOBRE_CONTADO") = adt_datatable.Rows(0).Item("CG_X_SOBRE_CONTADO")
        dr("CG_X_SOBRE") = adt_datatable.Rows(0).Item("CG_X_SOBRE")

        dr("EC_MONTO_BASE") = adt_datatable.Rows(0).Item("EC_MONTO_BASE")
        dr("EC_X_PESO") = adt_datatable.Rows(0).Item("EC_X_PESO")
        dr("EC_X_VOLUMEN") = adt_datatable.Rows(0).Item("EC_X_VOLUMEN")
        dr("PO_MONTO_BASE") = adt_datatable.Rows(0).Item("PO_MONTO_BASE")
        dr("PO_X_PESO") = adt_datatable.Rows(0).Item("PO_X_PESO")
        dr("PO_X_VOLUMEN") = adt_datatable.Rows(0).Item("PO_X_VOLUMEN")
        dr("GI_MONTO_BASE") = adt_datatable.Rows(0).Item("GI_MONTO_BASE")
        dr("GI_NORMAL") = adt_datatable.Rows(0).Item("GI_NORMAL")
        dr("GI_TELEFONICO") = adt_datatable.Rows(0).Item("GI_TELEFONICO")
        dr("FECHA_ACTIVACION") = adt_datatable.Rows(0).Item("FECHA_ACTIVACION")
        dr("FECHA_DESACTIVACION") = adt_datatable.Rows(0).Item("FECHA_DESACTIVACION")
        dr("ES_VIGENTE") = adt_datatable.Rows(0).Item("ES_VIGENTE")
        dr("ORIGEN") = adt_datatable.Rows(0).Item("ORIGEN")
        dr("DESTINO") = adt_datatable.Rows(0).Item("DESTINO")
    End Sub

    Private Sub TxtMMbC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMMbC.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try

    End Sub

    Private Sub TxtMMbC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtMMbC.Validating
        Try
            TxtMMbC.Text = Format(Math.Round(Convert.ToDouble(TxtMMbC.Text), 2), "####0.00")
            TxtMMbE.Text = Format(Math.Round(Convert.ToDouble(TxtMMbC.Text), 2), "####0.00")
            TxtMMbP.Text = Format(Math.Round(Convert.ToDouble(TxtMMbC.Text), 2), "####0.00")
            TxtMMbG.Text = Format(Math.Round(Convert.ToDouble(TxtMMbC.Text), 2), "####0.00")
        Catch ex As Exception
            MsgBox("Error en el Formato de Ingreso", MsgBoxStyle.Critical, "General Error")
            TxtMMbC.Text = "0.00"
            Exit Sub
        End Try
    End Sub

    Private Sub TxtMppC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMppC.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try

    End Sub

    Private Sub TxtMppC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtMppC.Validating
        Try
            TxtMppC.Text = Format(Math.Round(Convert.ToDouble(TxtMppC.Text), 2), "####0.00")
            TxtMppE.Text = Format(Math.Round(Convert.ToDouble(TxtMppC.Text), 2), "####0.00")
            TxtMppP.Text = Format(Math.Round(Convert.ToDouble(TxtMppC.Text), 2), "####0.00")
        Catch ex As Exception
            MsgBox("Error en el Formato de Ingreso", MsgBoxStyle.Critical, "General Error")
            TxtMMbC.Text = "0.00"
            Exit Sub
        End Try
    End Sub

    Private Sub TxtMpvC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMpvC.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub TxtMpvC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtMpvC.Validating
        Try
            TxtMpvC.Text = Format(Math.Round(Convert.ToDouble(TxtMpvC.Text), 2), "####0.00")
            TxtMpvE.Text = Format(Math.Round(Convert.ToDouble(TxtMpvC.Text), 2), "####0.00")
            TxtMpvP.Text = Format(Math.Round(Convert.ToDouble(TxtMpvC.Text), 2), "####0.00")
        Catch ex As Exception
            MsgBox("Error en el Formato de Ingreso", MsgBoxStyle.Critical, "General Error")
            TxtMMbC.Text = "0.00"
            Exit Sub
        End Try
    End Sub

    Private Sub TxtPMbC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPMbC.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try

    End Sub
    Private Sub TxtPMbC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtPMbC.Validating
        Try
            TxtPMbC.Text = Format(Math.Round(Convert.ToDouble(TxtPMbC.Text), 2), "####0.00")
            TxtPMbE.Text = Format(Math.Round(Convert.ToDouble(TxtPMbC.Text), 2), "####0.00")
            TxtPMbP.Text = Format(Math.Round(Convert.ToDouble(TxtPMbC.Text), 2), "####0.00")
            TxtPMbG.Text = Format(Math.Round(Convert.ToDouble(TxtPMbC.Text), 2), "####0.00")
        Catch ex As Exception
            MsgBox("Error en el Formato de Ingreso", MsgBoxStyle.Critical, "General Error")
            TxtMMbC.Text = "0.00"
            Exit Sub
        End Try
    End Sub

    Private Sub TxtPppC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPppC.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub TxtPppC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtPppC.Validating
        Try
            TxtPppC.Text = Format(Math.Round(Convert.ToDouble(TxtPppC.Text), 2), "####0.00")
            TxtPppE.Text = Format(Math.Round(Convert.ToDouble(TxtPppC.Text), 2), "####0.00")
            TxtPppP.Text = Format(Math.Round(Convert.ToDouble(TxtPppC.Text), 2), "####0.00")
        Catch ex As Exception
            MsgBox("Error en el Formato de Ingreso", MsgBoxStyle.Critical, "General Error")
            TxtMMbC.Text = "0.00"
            Exit Sub
        End Try
    End Sub

    Private Sub TxtPpvC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPpvC.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub TxtPpvC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtPpvC.Validating
        Try
            TxtPpvC.Text = Format(Math.Round(Convert.ToDouble(TxtPpvC.Text), 2), "####0.00")
            TxtPpvE.Text = Format(Math.Round(Convert.ToDouble(TxtPpvC.Text), 2), "####0.00")
            TxtPpvP.Text = Format(Math.Round(Convert.ToDouble(TxtPpvC.Text), 2), "####0.00")
        Catch ex As Exception
            MsgBox("Error en el Formato de Ingreso", MsgBoxStyle.Critical, "General Error")
            TxtMMbC.Text = "0.00"
            Exit Sub
        End Try
    End Sub

    Private Sub TxtCMonBas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCMonBas.TextChanged
        If TxtCMonBas.Text = "" Then TxtCMonBas.Text = "0"
    End Sub

    Private Sub TxtCPeso_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCPeso.TextChanged
        If TxtCPeso.Text = "" Then TxtCPeso.Text = "0"
    End Sub

    Private Sub TxtCVol_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCVol.TextChanged
        If TxtCVol.Text = "" Then TxtCVol.Text = "0"
    End Sub

    Private Sub TxtCVol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCVol.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try

    End Sub

    Private Sub txtcMonBasContado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try

    End Sub

    Private Sub txtcMonBasContado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TxtCPesoContado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try

    End Sub

    Private Sub TxtCPesoContado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TxtCVolContado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try

    End Sub

    Private Sub TxtCVolContado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtcMonBasContado_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        txtcMonBasContado.Text = Format(Val(txtcMonBasContado.Text), "0.00")
    End Sub

    Private Sub TxtCPesoContado_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        TxtCPesoContado.Text = Format(Val(TxtCPesoContado.Text), "0.00")
    End Sub

    Private Sub TxtCVolContado_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        TxtCVolContado.Text = Format(Val(TxtCVolContado.Text), "0.00")
    End Sub

    Private Sub txtcMonSobreContado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub txtcMonSobre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub DataGridViewLista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLista.DoubleClick
        Try
            Fact = 2
            Call Edicion()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Seguridad del Sistema")
            Exit Sub
        End Try
    End Sub

    Private Sub TxtPMbCon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPMbCon.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub TxtPMbCon_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtPMbCon.Validating
        TxtPMbCon.Text = Format(Math.Round(Convert.ToDouble(TxtPMbCon.Text), 2), "####0.00")
    End Sub

    Private Sub TxtPppCon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPppCon.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub TxtPppCon_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtPppCon.Validating
        TxtPppCon.Text = Format(Math.Round(Convert.ToDouble(TxtPppCon.Text), 2), "####0.00")
    End Sub

    Private Sub TxtPpvCon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPpvCon.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub TxtPpvCon_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtPpvCon.Validating
        TxtPpvCon.Text = Format(Math.Round(Convert.ToDouble(TxtPpvCon.Text), 2), "####0.00")
    End Sub

    Private Sub TxtPpsCon_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        TxtPpsCon.Text = Format(Math.Round(Convert.ToDouble(TxtPpsCon.Text), 2), "####0.00")
    End Sub

    Private Sub TxtMMbCon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMMbCon.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub TxtMMbCon_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtMMbCon.Validating
        TxtMMbCon.Text = Format(Math.Round(Convert.ToDouble(TxtMMbCon.Text), 2), "####0.00")
    End Sub

    Private Sub TxtMppCon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMppCon.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub TxtMppCon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMppCon.TextChanged

    End Sub

    Private Sub TxtMppCon_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtMppCon.Validating
        TxtMppCon.Text = Format(Math.Round(Convert.ToDouble(TxtMppCon.Text), 2), "####0.00")
    End Sub

    Private Sub TxtMpvCon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMpvCon.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub TxtMpvCon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMpvCon.TextChanged

    End Sub

    Private Sub TxtMpvCon_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtMpvCon.Validating
        TxtMpvCon.Text = Format(Math.Round(Convert.ToDouble(TxtMpvCon.Text), 2), "####0.00")
    End Sub

    Private Sub TxtMpsCon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TxtMpsCon_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        TxtMpsCon.Text = Format(Math.Round(Convert.ToDouble(TxtMpsCon.Text), 2), "####0.00")
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub TxtPpsC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TxtPpsC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        TxtPpsC.Text = Format(Math.Round(Convert.ToDouble(TxtPpsC.Text), 2), "####0.00")
    End Sub

    Private Sub TxtMpsC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TxtMpsC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        TxtMpsC.Text = Format(Math.Round(Convert.ToDouble(TxtMpsC.Text), 2), "####0.00")
    End Sub

    Private Sub TxtPpvC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPpvC.TextChanged

    End Sub

    Private Sub TxtPMbC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPMbC.TextChanged

    End Sub

    Private Sub TabDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabDatos.Click

    End Sub

    Private Sub CbOriDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbOriDet.SelectedIndexChanged

    End Sub

    Private Sub TxtPppC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPppC.TextChanged

    End Sub

    Private Sub TxtPpsC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPpsC.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub TxtPpsC_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPpsC.TextChanged

    End Sub

    Private Sub TxtMMbC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMMbC.TextChanged

    End Sub

    Private Sub TxtMppC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMppC.TextChanged

    End Sub

    Private Sub TxtMpvC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMpvC.TextChanged

    End Sub

    Private Sub TxtMpsC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMpsC.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub TxtPpsCon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPpsCon.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub TxtMpsCon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMpsCon.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub TxtMpsCon_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMpsCon.TextChanged

    End Sub

    Private Sub rbtSelQuitar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSelQuitar.CheckedChanged
        If DvRutas Is Nothing Then Exit Sub
        For i = 0 To DvRutas.Count - 1
            dr = DvRutas.Item(i)
            If rbtSelTodo.Checked Then
                dr("flag") = 1
            Else
                dr("flag") = 0
            End If
        Next
    End Sub

    Private Sub TxtMpsC_Validating1(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtMpsC.Validating
        Try
            TxtMpsC.Text = Format(Math.Round(Convert.ToDouble(TxtMpsC.Text), 2), "####0.00")
        Catch ex As Exception
            MsgBox("Error en el Formato de Ingreso", MsgBoxStyle.Critical, "General Error")
            TxtMpsC.Text = "0.00"
            Exit Sub
        End Try
    End Sub

    Private Sub TxtMpsCon_Validating1(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtMpsCon.Validating
        Try
            TxtMpsCon.Text = Format(Math.Round(Convert.ToDouble(TxtMpsCon.Text), 2), "####0.00")
        Catch ex As Exception
            MsgBox("Error en el Formato de Ingreso", MsgBoxStyle.Critical, "General Error")
            TxtMpsC.Text = "0.00"
            Exit Sub
        End Try
    End Sub

    Private Sub txtcMonSobre_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcMonSobre.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try

    End Sub

    Private Sub txtcMonSobre_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcMonSobre.TextChanged
        If txtcMonSobre.Text = "" Then txtcMonSobre.Text = "0"
    End Sub

    Private Sub txtcMonBasContado_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcMonBasContado.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try

    End Sub

    Private Sub txtcMonBasContado_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcMonBasContado.TextChanged
        If txtcMonBasContado.Text = "" Then txtcMonBasContado.Text = "0"
    End Sub

    Private Sub TxtCPesoContado_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCPesoContado.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try

    End Sub

    Private Sub TxtCPesoContado_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCPesoContado.TextChanged
        If TxtCPesoContado.Text = "" Then TxtCPesoContado.Text = "0"
    End Sub

    Private Sub TxtCVolContado_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCVolContado.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try

    End Sub

    Private Sub TxtCVolContado_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCVolContado.TextChanged
        If TxtCVolContado.Text = "" Then TxtCVolContado.Text = "0"
    End Sub

    Private Sub txtcMonSobreContado_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcMonSobreContado.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "." And InStr(tb.Text, ".") = 0) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try

    End Sub

    Private Sub txtcMonSobreContado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcMonSobreContado.TextChanged
        If txtcMonSobreContado.Text = "" Then txtcMonSobreContado.Text = "0"
    End Sub

    Sub VerificaCambio(ByVal sender As Object, ByVal e As EventArgs) Handles CancelarToolStripMenuItem7.EnabledChanged, AyudaToolStripMenuItem1.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class
