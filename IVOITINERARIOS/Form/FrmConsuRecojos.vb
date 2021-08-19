Imports System.Data.OleDb
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Collections
Public Class FrmConsuRecojos
    Inherits FrmFormBase
    Dim Clase As New dtoConsuRecojos
    Dim ClaseDet As New dtoItinerario_Detalle
    Dim Impresion As New ClsPrint
    'dim rstIti, rstMov, rstRut, rstSta, rstDetalle, rstRet As ADODB.Recordset
    'Dim dr4, da As New OleDbDataAdapter
    Dim dt, DtCbMov, DtCbRut, DtCbSta, DtIti, DtDetaCopy As New System.Data.DataTable
    Dim DtDetalle As New DataTable
    Dim DvAgencia, DvCbMov, DvCbRut, DvCbSta, DvDetalle, DvDetaCopy As DataView
    Dim dr, dr2, DrRuta, DrAge1, DrAge2, DrCopy As DataRowView
    Dim Fact, filcb, conta, AgeOri, AgeDes, i, IDUser As Integer
    Dim valor, NAgeOri, NAgeDes, CiuOri, CiuDes, hora_ini, hora_fin, horinia, horfina As String
    Dim fec_ini, fec_fin, rfec_ini, rfec_fin, fecinia, fecfina As Date
    Dim FlgTre As Integer
    Dim ndias As Double
    Dim chora As String
    '****************************************************************************************************************
    Dim dr3 As DataRowView
    Dim WithEvents WinSockCliente As New Cliente()
    Dim bIngreso As Boolean
    Public hnd As Long
    Private Sub Conectar()
        '[mendoza] 
        '    Try
        '        With WinSockCliente
        '            'Determino a donde se quiere conectar el usuario 
        '            .IPDelHost = IPServer
        '            .PuertoDelHost = Port
        '            .Conectar()
        '        End With
        '    Catch ex As Exception
        '        MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema ...")
        '    End Try
    End Sub
    Private Sub WinSockCliente_DatosRecibidos(ByVal datos As String) Handles WinSockCliente.DatosRecibidos
        Try
            'If datos.Length() > 0 Then
            '    Call BuscaRecojos()
            'End If
            'MsgBox("Recibiendo Datos", MsgBoxStyle.Information, "Segurida Sistema")
            BuscaRecojos()
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema...")
        End Try
    End Sub
    Private Sub Enviar_Datos(ByVal strDatos As String)
        Try
            WinSockCliente.EnviarDatos(strDatos)
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema...")
        End Try
    End Sub
    Private Sub WinSockCliente_ConexionTerminada() Handles WinSockCliente.ConexionTerminada
        Try
            MsgBox("Finalizo la conexion", MsgBoxStyle.Information, "Segurida Sistema")

        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub FrmConsuRecojos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmConsuRecojos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    '****************************************************************************************************************

    Private Sub FrmConsuRecojos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        NuevoToolStripMenuItem1.Enabled = False
        EdicionToolStripMenuItem.Enabled = False
        GrabarToolStripMenuItem.Enabled = False
        CancelarToolStripMenuItem7.Visible = False
        ExportarToolStripMenuItem.Enabled = True
        AyudaToolStripMenuItem1.Enabled = False
        SalirToolStripMenuItem.Enabled = True
        EliminarToolStripMenuItem.Enabled = False
        ImprimirToolStripMenuItem.Enabled = True
        Call IniciarImagenes()

        ShadowLabel1.Text = "Consulta de Recojos de Carga"
        TxtFechaIni._MyFecha = Convert.ToString(Today)
        TxtFechaFin._MyFecha = Convert.ToString(Today)
        dt.Clear()
        'Mod.25/09/2009 -->Omendoza - Pasando al datahelper   
        Dim lds_tmp As New DataSet
        'rstMov = Clase.Lista
        'rstRut = rstMov.NextRecordset
        'rstSta = rstMov.NextRecordset
        'dr4.Fill(DtCbMov, rstMov)
        'dr4.Fill(DtCbRut, rstRut)
        'dr4.Fill(DtCbSta, rstSta)

        lds_tmp = Clase.Lista
        DtCbMov = lds_tmp.Tables(0)
        DtCbRut = lds_tmp.Tables(1)
        DtCbSta = lds_tmp.Tables(2)
        DvCbMov = DtCbMov.DefaultView
        DvCbRut = DtCbRut.DefaultView
        DvCbSta = DtCbSta.DefaultView

        'DvCbOri.RowFilter = "idunidad_agencia <> 9999"
        'DtCbDes = DtCbOri.Copy
        'DvCbDes = DtCbDes.DefaultView
        'DvCbDes.RowFilter = "idunidad_agencia <> 9999"
        'DvCbSer.RowFilter = "idclase <> 9999"
        'DtCbOde = DtCbOri.Copy
        'DvCbOde = DtCbOde.DefaultView
        'DvCbOde.RowFilter = "idunidad_agencia <> 9999"
        LlenaCombo2(DvCbMov, CbMovil, "NRO_UNIDAD_TRANSPORTE")
        LlenaCombo2(DvCbRut, CbRutMov, "NOMBRE_RUTA_ENTREGA_RECOJO")
        LlenaCombo2(DvCbSta, CbEstado, "ESTADO_REGISTRO")
        '
        FlgTre = 0
        Fact = 0
        TxtCliente.Text = "%"
        MenuTab.Items(0).Text = "BUSQUEDA"
        MenuTab.Items(1).Text = "DATOS GENERALES"
        'Call GrillaMante2()
        'Call GrillaMante()
        Try
            If CbMovil.SelectedIndex >= 0 Then
                dr = DvCbMov.Item(CbMovil.SelectedIndex)
            End If
            If CbRutMov.SelectedIndex >= 0 Then
                dr2 = DvCbRut.Item(CbRutMov.SelectedIndex)
            End If
            If CbEstado.SelectedIndex >= 0 Then
                dr3 = DvCbSta.Item(CbEstado.SelectedIndex)
            End If


        Catch ex As Exception

        End Try
        Try
            Call Conectar()
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try

        bIngreso = False
        Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
        Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)
        bIngreso = True

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

    Private Sub BtBusca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBusca.Click
        BuscaRecojos()
    End Sub

    Private Sub BtBusca_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtBusca.GotFocus
        FlgTre = 1
    End Sub
    Sub GrillaMante()
        DataGridViewLista.Columns.Clear()
        With DataGridViewLista
            .AllowUserToAddRows = True
            .AllowUserToDeleteRows = True
            .AllowUserToOrderColumns = True
            .BackgroundColor = SystemColors.Info
            '.Font = New System.Drawing.Font("Tahoma", 14.0!, FontStyle.Bold)
            .ReadOnly = True
            .AutoGenerateColumns = False
            '.DataSource = DtDetalle
            .VirtualMode = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersWidth = 10
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EAF")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
        End With

        Dim idEstadoImage As New DataGridViewImageColumn
        With idEstadoImage
            .DataPropertyName = "imagen"
            .HeaderText = "CT"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .DisplayIndex = 0
            .Visible = True
            .Image = bmActivo

        End With
        DataGridViewLista.Columns.Add(idEstadoImage)

        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .DataPropertyName = "IDSOLICITUD_RECOJO_CARGA"
            .HeaderText = "id"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridViewLista.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DataPropertyName = "idruta_entrega_recojo"
            .HeaderText = "Ruta"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridViewLista.Columns.Add(col1)
        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .DataPropertyName = "nro_paquetes"
            .HeaderText = "Paquetes"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format.ToUpper()
        End With
        DataGridViewLista.Columns.Add(col2)
        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .DataPropertyName = "FECHA_RECOJO"
            .HeaderText = "Fecha Recojo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "d"

        End With
        DataGridViewLista.Columns.Add(col3)
        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .DataPropertyName = "razon_social"
            .HeaderText = "Nombre Cliente"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridViewLista.Columns.Add(col4)
        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .DataPropertyName = "nro_unidad_transporte"
            .HeaderText = "Movil"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridViewLista.Columns.Add(col5)
        Dim col6 As New DataGridViewTextBoxColumn
        With col6
            .DataPropertyName = "idestado_recojo"
            .HeaderText = "Estado Recojo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridViewLista.Columns.Add(col6)
        Dim col7 As New DataGridViewTextBoxColumn
        With col7
            .DataPropertyName = "estado_registro"
            .HeaderText = "Nom Estado"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridViewLista.Columns.Add(col7)
        Dim col8 As New DataGridViewCheckBoxColumn
        With col8
            .DataPropertyName = "flag"
            .HeaderText = "Nom Estado"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridViewLista.Columns.Add(col8)
        'Dim col8 As New DataGridViewTextBoxColumn
        'With col8
        '    .DataPropertyName = "AGENCIA_DESTINO"
        '    .HeaderText = "Agencia Destino"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        'End With
        'DataGridDeta.Columns.Add(col8)
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
            .DataPropertyName = "IDITINERARIOS"
            .HeaderText = "Nro.It."
            .Width = 40
        End With
        DataGridViewLista.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DataPropertyName = "NOMBRE_RUTA"
            .HeaderText = "Nombre Ruta"
            .Width = 160
        End With
        DataGridViewLista.Columns.Add(col1)

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .DataPropertyName = "CLASE"
            .HeaderText = "Servicio"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            '.Visible = False
        End With
        DataGridViewLista.Columns.Add(col2)

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .DataPropertyName = "FECHA_ITINERARIO"
            .HeaderText = "Fecha Partida"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "d"
        End With
        DataGridViewLista.Columns.Add(col3)

        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .DataPropertyName = "HORA_PARTIDA"
            .HeaderText = "Hora Partida"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridViewLista.Columns.Add(col4)

        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .DataPropertyName = "FECHA_llegada"
            .HeaderText = "Fecha Llegada"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "d"
        End With
        DataGridViewLista.Columns.Add(col5)

        Dim col6 As New DataGridViewTextBoxColumn
        With col6
            .DataPropertyName = "hora_llegada"
            .HeaderText = "Hora Llegada"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridViewLista.Columns.Add(col6)

    End Sub


    'Private Sub CbOriDet_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbOriDet.SelectedIndexChanged
    '    filcb = CbOriDet.SelectedIndex
    '    If filcb >= 0 Then
    '        dr = DvCbOde.Item(filcb)
    '        valor = IIf(IsDBNull(dr("idunidad_agencia")) = True, "0", dr("idunidad_agencia").ToString)
    '        DvCbRut.RowFilter = "idunidad_agencia = " & valor
    '        DvCbAg1.RowFilter = "idunidad_agencia = " & valor
    '        filcb = DvCbRut.Count
    '        If filcb > 0 Then
    '            dr = DvCbRut.Item(0)
    '            valor = IIf(IsDBNull(dr("idunidad_agencia_destino")) = True, "0", dr("idunidad_agencia_destino").ToString)
    '            DvCbAg2.RowFilter = "idunidad_agencia = " & valor
    '        Else
    '            DvCbAg1.RowFilter = "idunidad_agencia = 0"
    '            DvCbAg2.RowFilter = "idunidad_agencia = 0"
    '        End If
    '    Else
    '        DvCbRut.RowFilter = "idunidad_agencia = 0"
    '        DvCbAg1.RowFilter = "idunidad_agencia = 0"
    '        DvCbAg2.RowFilter = "idunidad_agencia = 0"
    '    End If
    'End Sub

    'Private Sub CbRuta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbRuta.SelectedIndexChanged
    '    filcb = CbRuta.SelectedIndex
    '    If filcb >= 0 Then
    '        dr = DvCbRut.Item(filcb)
    '        valor = IIf(IsDBNull(dr("idunidad_agencia")) = True, "0", dr("idunidad_agencia").ToString)
    '        DvCbAg1.RowFilter = "idunidad_agencia = " & valor
    '        valor = IIf(IsDBNull(dr("idunidad_agencia_destino")) = True, "0", dr("idunidad_agencia_destino").ToString)
    '        DvCbAg2.RowFilter = "idunidad_agencia = " & valor
    '    Else
    '        DvCbAg1.RowFilter = "idunidad_agencia = 0"
    '        DvCbAg2.RowFilter = "idunidad_agencia = 0"
    '    End If
    'End Sub

    'Private Sub TxtHora_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtHora.Validating
    '    If TxtHora.Text <> "  :" Then
    '        Try
    '            If Mid(Trim(TxtHora.Text), 1, 2) > "23" Or Mid(Trim(TxtHora.Text), 4, 2) > "59" Then
    '                MessageBox.Show("Hora Incorrecta", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                e.Cancel = True
    '            Else
    '                Call RecalculaFechas(Convert.ToDateTime(TxtFecInicio.GetMyFecha))
    '            End If
    '        Catch ex As Exception
    '            MsgBox("Formato de Hora Incorrecto", MsgBoxStyle.Critical, "Seguridad del Sistema")
    '            e.Cancel = True
    '        End Try
    '    End If
    'End Sub

    Private Sub FrmConsuRecojos_MenuCancelar() Handles Me.MenuCancelar
        Fact = 0
    End Sub

    Private Sub FrmConsuRecojos_MenuEditar() Handles Me.MenuEditar
        'Try
        '    Fact = 2
        '    Call Edicion()
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Seguridad del Sistema")
        '    Exit Sub
        'End Try
    End Sub

    Private Sub FrmConsuRecojos_MenuGrabar() Handles Me.MenuGrabar
        'If DvDetalle.Count = 0 Then
        '    MsgBox("Itinerario sin Tramos... Verifique!!!", MsgBoxStyle.Critical, "Seguridad del Sistema")
        '    Exit Sub
        'End If
        'If TxtFecInicio.GetMyFecha = "  /  /" Then
        '    MsgBox("Fecha de Partida Vacia, Verifique", MsgBoxStyle.Critical, "Seguridad Sistema")
        '    Exit Sub
        'End If
        'If TxtHora.Text = "  :" Then
        '    MsgBox("Hora de Partida Vacia, Verifique", MsgBoxStyle.Critical, "Seguridad Sistema")
        '    Exit Sub
        'End If
        ''If Trim(TxtNomAgencia.Text) = "" Then
        ''    MsgBox("Nombre de Agencia Vacio... Verifique!!!", MsgBoxStyle.Critical, "Seguridad del Sistema")
        ''    Exit Sub
        ''End If
        ''If Trim(TxtCodAge.Text) = "" Then
        ''    MsgBox("Codigo de Agencia Vacio... Verifique!!!", MsgBoxStyle.Critical, "Seguridad del Sistema")
        ''    Exit Sub
        ''End If
        'Dim drori, drdes, drrut, drclas, drest As DataRowView
        'drrut = DvCbRut.Item(CbRuta.SelectedIndex)
        'If DvDetalle.Count > 0 Then
        '    conta = DvDetalle.Count
        '    dr = DvDetalle.Item(0)
        '    fec_ini = dr("fecha_partida")
        '    dr = DvDetalle.Item(conta - 1)
        '    fec_fin = dr("fecha_llegada")
        '    valor = dr("hora_llegada")
        '    If dr("idunidad_destino") <> drrut("idunidad_agencia_destino") Then
        '        MsgBox("Destino del ultimo Tramo debe coincidir con el Destino de la Ruta Principal", MsgBoxStyle.Critical, "Seguridad del Sistema")
        '        Exit Sub
        '    End If
        'End If
        'Try
        '    If Fact = 1 Then
        '        TxtID.Text = "0"
        '    End If
        '    drori = DvCbAg1.Item(CbAge1.SelectedIndex)
        '    drdes = DvCbAg2.Item(CbAge2.SelectedIndex)
        '    drrut = DvCbRut.Item(CbRuta.SelectedIndex)
        '    drclas = DvCbSde.Item(CbSerDet.SelectedIndex)
        '    Clase.Accion = Fact
        '    Clase.AgeOrigen = drori("idagencias")
        '    Clase.AgeDestino = drdes("idagencias")
        '    Clase.Clase = drclas("idclase")
        '    Clase.Ruta = drrut("idrutas")
        '    Clase.ID = Convert.ToInt16(TxtID.Text)
        '    If ChkVigente.Checked = True Then
        '        Clase.Vigente = 1
        '    Else
        '        Clase.Vigente = 0
        '    End If
        '    Clase.Usuario = 1
        '    Clase.Rol = 1
        '    Clase.IP = "192.168.50.47"
        '    'Clase.Estado = drest("idestado_registro")
        '    Clase.Estado = 1
        '    Clase.Hora_Ini = Trim(TxtHora.Text)
        '    rfec_ini = Convert.ToDateTime(TxtFecIni.GetMyFecha)
        '    rfec_fin = Convert.ToDateTime(TxtFecFin.GetMyFecha)
        '    While rfec_ini <= rfec_fin
        '        'Clase.Fecha_Ini = Trim(TxtFecInicio.GetMyFecha)
        '        Clase.Fecha_Ini = Mid(Convert.ToString(rfec_ini), 1, 10)
        '        Call RecalculaFechas(rfec_ini)
        '        Clase.Hora_Par = hora_ini
        '        Clase.Fecha_Lle = Mid(Convert.ToString(fec_fin), 1, 10)
        '        Clase.Hora_Lle = hora_fin
        '        rst = Clase.Grabar
        '        If Convert.ToInt16(rst.Fields(0).Value) = 0 Then
        '            rstRet = rst.NextRecordset()
        '            MsgBox("Registro Grabado Correctamente", MsgBoxStyle.Information, "Seguridad del Sistema")
        '            ClaseDet.Accion = 1
        '            ClaseDet.Itinerario = rstRet.Fields(0).Value
        '            ClaseDet.Usuario = 1
        '            ClaseDet.Rol = 1
        '            ClaseDet.IP = "192.168.50.47"
        '            ClaseDet.Estado = 1
        '            For i = 1 To DvDetalle.Count
        '                dr = DvDetalle.Item(i - 1)
        '                If dr("IDRUTAS_ITINERARIOS") = 0 Then
        '                    ClaseDet.ID = 0
        '                    ClaseDet.Ruta = dr("idrutas")
        '                    ClaseDet.Item = dr("item")
        '                    ClaseDet.Fecha_Par = Mid(Convert.ToString(dr("fecha_partida")), 1, 19) + Mid(Convert.ToString(dr("fecha_partida")), 21, 1) + Mid(Convert.ToString(dr("fecha_partida")), 23, 1)
        '                    ClaseDet.Hora_Par = dr("hora_partida")
        '                    ClaseDet.Fecha_Lle = Mid(Convert.ToString(dr("fecha_llegada")), 1, 19) + Mid(Convert.ToString(dr("fecha_llegada")), 21, 1) + Mid(Convert.ToString(dr("fecha_llegada")), 23, 1)
        '                    ClaseDet.Hora_lle = dr("hora_llegada")
        '                    ClaseDet.AgeOrigen = dr("idagencia_origen")
        '                    ClaseDet.AgeDestino = dr("idagencia_destino")
        '                    rst = ClaseDet.Grabar
        '                    If Convert.ToInt16(rst.Fields(0).Value) = 0 Then
        '                        MsgBox("Detalle Grabado Correctamente", MsgBoxStyle.Information, "Seguridad del Sistema")
        '                    Else
        '                        MessageBox.Show("Descripcion : " + Trim(Convert.ToString(rst.Fields(1).Value)), "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                    End If
        '                End If
        '            Next
        '            For i = 1 To DvDetaCopy.Count
        '                dr = DvDetaCopy.Item(i - 1)
        '                If dr("flgdel") = 1 Then
        '                    ClaseDet.ID = dr("IDRUTAS_ITINERARIOS")
        '                    rst = ClaseDet.Eliminar
        '                    If Convert.ToInt16(rst.Fields(0).Value) = 0 Then
        '                        MsgBox("Detalle Eliminado Correctamente", MsgBoxStyle.Information, "Seguridad del Sistema")
        '                    Else
        '                        MessageBox.Show("Descripcion : " + Trim(Convert.ToString(rst.Fields(1).Value)), "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                    End If
        '                Else
        '                    DvDetalle.Sort = "IDRUTAS_ITINERARIOS"
        '                    filcb = DvDetalle.Find(dr("IDRUTAS_ITINERARIOS"))
        '                    If filcb >= 0 Then
        '                        dr2 = DvDetalle.Item(filcb)
        '                        If dr("fecha_partida") <> dr2("fecha_partida") Or dr("fecha_llegada") <> dr2("fecha_llegada") Or dr("hora_partida") <> dr2("hora_partida") Or dr("hora_llegada") <> dr2("hora_llegada") Then
        '                            ClaseDet.Accion = 2
        '                            ClaseDet.ID = dr("IDRUTAS_ITINERARIOS")
        '                            ClaseDet.Ruta = dr("idrutas")
        '                            ClaseDet.Item = dr2("item")
        '                            ClaseDet.Fecha_Par = Mid(Convert.ToString(dr2("fecha_partida")), 1, 19) + Mid(Convert.ToString(dr2("fecha_partida")), 21, 1) + Mid(Convert.ToString(dr2("fecha_partida")), 23, 1)
        '                            ClaseDet.Hora_Par = dr2("hora_partida")
        '                            ClaseDet.Fecha_Lle = Mid(Convert.ToString(dr2("fecha_llegada")), 1, 19) + Mid(Convert.ToString(dr2("fecha_llegada")), 21, 1) + Mid(Convert.ToString(dr2("fecha_llegada")), 23, 1)
        '                            ClaseDet.Hora_lle = dr2("hora_llegada")
        '                            ClaseDet.AgeOrigen = dr("idagencia_origen")
        '                            ClaseDet.AgeDestino = dr("idagencia_destino")
        '                            rst = ClaseDet.Grabar
        '                            If Convert.ToInt16(rst.Fields(0).Value) = 0 Then
        '                                MsgBox("Modificacion Grabada Correctamente", MsgBoxStyle.Information, "Seguridad del Sistema")
        '                            Else
        '                                MessageBox.Show("Descripcion : " + Trim(Convert.ToString(rst.Fields(1).Value)), "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                            End If
        '                        End If
        '                    End If
        '                End If
        '            Next
        '            Fact = 0
        '            TabMante.SelectedIndex = 0
        '        Else
        '            MessageBox.Show("Descripcion : " + Trim(Convert.ToString(rst.Fields(1).Value)), "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        End If
        '        rfec_ini = DateAdd(DateInterval.Day, 1, rfec_ini)
        '    End While

        'Catch Exp As Exception
        '    MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
        '    Exit Sub
        'End Try
    End Sub

    Private Sub FrmConsuRecojos_MenuImprimir() Handles Me.MenuImprimir
        Dim PrDialog As New PrintPreviewDialog
        Dim Campos As New ArrayList
        If Fact = 0 Then
            Impresion.Titulo = "Relacion de Itinerarios"
            Impresion.Orientacion = 1
            Impresion.DGV = DataGridViewLista
            Impresion.TopDetalle = 100
        Else
            Impresion.Titulo = "Relacion de Tramos"
            Campos.Add("Nro.Itinerario :")
            Campos.Add("100")
            Campos.Add("50")
            Campos.Add(Trim(TxtID.Text))
            Campos.Add("250")
            Campos.Add("50")
            Campos.Add("Ruta           :")
            Campos.Add("100")
            Campos.Add("70")
            Campos.Add(Trim(CbRuta.Text))
            Campos.Add("250")
            Campos.Add("70")
            Campos.Add("Servicio        :")
            Campos.Add("550")
            Campos.Add("70")
            Campos.Add(Trim(CbSerDet.Text))
            Campos.Add("700")
            Campos.Add("70")
            Campos.Add("Fecha Partida  :")
            Campos.Add("100")
            Campos.Add("90")
            Campos.Add(Trim(TxtFecInicio.GetMyFecha))
            Campos.Add("250")
            Campos.Add("90")
            Campos.Add("Hora Partida    :")
            Campos.Add("550")
            Campos.Add("90")
            Campos.Add(Trim(TxtHora.Text))
            Campos.Add("700")
            Campos.Add("90")
            Campos.Add("Agencia Origen :")
            Campos.Add("100")
            Campos.Add("110")
            Campos.Add(Trim(CbAge1.Text))
            Campos.Add("250")
            Campos.Add("110")
            Campos.Add("Agencia Destino :")
            Campos.Add("550")
            Campos.Add("110")
            Campos.Add(Trim(CbAge2.Text))
            Campos.Add("700")
            Campos.Add("110")
            Impresion.TopDetalle = 200
            Impresion.Orientacion = 1
            Impresion.DGV = DataGridDeta
        End If
        Impresion.Lista = Campos
        PrDialog.Document = Impresion
        PrDialog.ShowDialog()
    End Sub



    Private Sub FrmConsuRecojos_MenuNuevo() Handles Me.MenuNuevo
        'Fact = 1
        'TxtFecInicio._MyFecha = ""
        'TxtFecIni._MyFecha = ""
        'TxtFecFin._MyFecha = ""
        'TxtHora.Text = ""
        'TxtFecIni.Enabled = True
        'TxtFecFin.Enabled = True
        'CbOriDet.SelectedIndex = 0
        'DtDetalle.Clear()
    End Sub


    'Private Sub BtnElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnElimina.Click
    '    'Try
    '    '    filcb = DvDetalle.Count
    '    '    If filcb > 0 Then
    '    '        filcb = DataGridDeta.CurrentRow.Index
    '    '        If filcb >= 0 Then
    '    '            If filcb + 1 = DvDetalle.Count Then
    '    '                Call UpdateCopyDetail(filcb)
    '    '                DvDetalle.Delete(filcb)
    '    '            Else
    '    '                dr = DvDetalle.Item(filcb)
    '    '                fec_ini = dr("fecha_partida")
    '    '                conta = dr("item")
    '    '                AgeOri = dr("idunidad_origen")
    '    '                CiuOri = dr("origen")
    '    '                SwDetAge1 = dr("idagencia_origen")
    '    '                NAgeOri = dr("agencia_origen")
    '    '                dr("flgdel") = 1
    '    '                dr = DvDetalle.Item(filcb + 1)
    '    '                AgeDes = dr("idunidad_destino")
    '    '                CiuDes = dr("destino")
    '    '                SwDetAge2 = dr("idagencia_destino")
    '    '                NAgeDes = dr("agencia_destino")
    '    '                dr("flgdel") = 1
    '    '                DvCbDetRut.RowFilter = "idunidad_agencia = " & Convert.ToString(AgeOri) & " and idunidad_agencia_destino = " & Convert.ToString(AgeDes)
    '    '                If DvCbDetRut.Count > 0 Then
    '    '                    DrRuta = DvCbDetRut.Item(0)
    '    '                    filcb = DvDetalle.Count
    '    '                    DvDetalle.AllowNew = True
    '    '                    DvDetalle.AddNew()
    '    '                    dr = DvDetalle.Item(filcb)
    '    '                    dr("item") = conta
    '    '                    dr("idrutas_itinerarios") = 0
    '    '                    dr("idrutas") = DrRuta("idrutas")
    '    '                    dr("origen") = DrRuta("origen")
    '    '                    dr("destino") = DrRuta("destino")
    '    '                    dr("dias_viaje") = DrRuta("dias_viaje")
    '    '                    dr("horas_viaje") = DrRuta("horas_de_viaje")
    '    '                    dr("idagencia_origen") = SwDetAge1
    '    '                    dr("agencia_origen") = NAgeOri
    '    '                    dr("idagencia_destino") = SwDetAge2
    '    '                    dr("agencia_destino") = NAgeDes
    '    '                    dr("idunidad_origen") = DrRuta("idunidad_agencia")
    '    '                    dr("idunidad_destino") = DrRuta("idunidad_agencia_destino")
    '    '                    filcb = DvDetalle.Count
    '    '                    DvDetalle.AddNew()
    '    '                    DvDetalle.Delete(filcb)
    '    '                    DvDetalle.AllowNew = False
    '    '                    For i = 1 To DvDetalle.Count
    '    '                        If i > DvDetalle.Count Then
    '    '                            Exit For
    '    '                        End If
    '    '                        dr = DvDetalle.Item(i - 1)
    '    '                        conta = IIf(IsDBNull(dr("flgdel")) = True, 0, dr("flgdel"))
    '    '                        If conta = 1 Then
    '    '                            Call UpdateCopyDetail(i - 1)
    '    '                            DvDetalle.Delete(i - 1)
    '    '                            i = i - 1
    '    '                        End If
    '    '                    Next
    '    '                    DvDetalle.Sort = "item"
    '    '                    Call RecalculaFechas(Convert.ToDateTime(TxtFecInicio.GetMyFecha))
    '    '                Else
    '    '                    MsgBox("Ruta " + CiuOri + "-" + CiuDes + " No Existe", MsgBoxStyle.Critical, "Seguridad Sistema")
    '    '                End If
    '    '            End If
    '    '        End If
    '    '    End If
    '    'Catch ex As Exception
    '    '    MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
    '    'End Try
    'End Sub

    'Private Sub BtnInserta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInserta.Click
    '    Try
    '        If TxtFecInicio.GetMyFecha = "  /  /" Then
    '            MsgBox("Fecha de Partida Vacia, Verifique", MsgBoxStyle.Critical, "Seguridad Sistema")
    '            Exit Sub
    '        End If
    '        If TxtHora.Text = "  :" Then
    '            MsgBox("Hora de Partida Vacia, Verifique", MsgBoxStyle.Critical, "Seguridad Sistema")
    '            Exit Sub
    '        End If
    '        If DvDetalle.Count > 0 Then
    '            filcb = DataGridDeta.CurrentRow.Index
    '            dr = DvDetalle.Item(filcb)
    '            SwDetRuta = IIf(IsDBNull(dr("idunidad_origen")) = True, 0, dr("idunidad_origen"))
    '            AgeDes = IIf(IsDBNull(dr("idunidad_destino")) = True, 0, dr("idunidad_destino"))
    '            fec_ini = dr("fecha_partida")
    '            conta = dr("item")
    '            SwDetAge1 = 0
    '            Dim Detalle As New FrmDetaItinerarios(DvCbDetRut, DvCbDetAg1, DvCbDetAg2)
    '            Detalle.ShowDialog()
    '            AgeOri = Detalle.AgeOri
    '            If SwFlgDet = 1 Then
    '                DvCbDetRut.RowFilter = "idunidad_agencia = " & Convert.ToString(AgeOri) & " and idunidad_agencia_destino = " & Convert.ToString(AgeDes)
    '                If DvCbDetRut.Count = 0 Then
    '                    MsgBox("Destino no tiene Ruta Asociada", MsgBoxStyle.Critical, "Seguridad Sistema")
    '                    DvCbDetRut.RowFilter = ""
    '                    Exit Sub
    '                End If
    '                DvCbDetRut.RowFilter = "idrutas = " + SwDetRuta.ToString
    '                If DvCbDetRut.Count > 0 Then
    '                    DrRuta = DvCbDetRut.Item(0)
    '                    DrAge1 = DvCbDetAg1.Item(SwDetAge1)
    '                    DrAge2 = DvCbDetAg2.Item(SwDetAge2)
    '                    Call UpdateCopyDetail(filcb)
    '                    DvDetalle.Delete(filcb)
    '                    filcb = DvDetalle.Count
    '                    DvDetalle.AllowNew = True
    '                    DvDetalle.AddNew()
    '                    dr = DvDetalle.Item(filcb)
    '                    dr("item") = conta
    '                    dr("idrutas_itinerarios") = 0
    '                    dr("idrutas") = DrRuta("idrutas")
    '                    dr("origen") = DrRuta("origen")
    '                    dr("destino") = DrRuta("destino")
    '                    dr("dias_viaje") = DrRuta("dias_viaje")
    '                    dr("horas_viaje") = DrRuta("horas_de_viaje")
    '                    dr("idagencia_origen") = DrAge1("idagencias")
    '                    dr("agencia_origen") = DrAge1("nombre_agencia")
    '                    dr("idagencia_destino") = DrAge2("idagencias")
    '                    dr("agencia_destino") = DrAge2("nombre_agencia")
    '                    dr("idunidad_origen") = DrRuta("idunidad_agencia")
    '                    dr("idunidad_destino") = DrRuta("idunidad_agencia_destino")
    '                    fec_ini = fec_fin
    '                    DvCbDetRut.RowFilter = "idunidad_agencia = " & Convert.ToString(AgeOri) & " and idunidad_agencia_destino = " & Convert.ToString(AgeDes)
    '                    If DvCbDetRut.Count > 0 Then
    '                        DrRuta = DvCbDetRut.Item(0)
    '                        filcb = DvDetalle.Count
    '                        DvDetalle.AddNew()
    '                        dr = DvDetalle.Item(filcb)
    '                        dr("item") = conta + 5
    '                        dr("idrutas_itinerarios") = 0
    '                        dr("idrutas") = DrRuta("idrutas")
    '                        dr("origen") = DrRuta("origen")
    '                        dr("destino") = DrRuta("destino")
    '                        dr("dias_viaje") = DrRuta("dias_viaje")
    '                        dr("horas_viaje") = DrRuta("horas_de_viaje")
    '                        dr("idagencia_origen") = DrAge1("idagencias")
    '                        dr("agencia_origen") = DrAge1("nombre_agencia")
    '                        dr("idagencia_destino") = DrAge2("idagencias")
    '                        dr("agencia_destino") = DrAge2("nombre_agencia")
    '                        dr("idunidad_origen") = DrRuta("idunidad_agencia")
    '                        dr("idunidad_destino") = DrRuta("idunidad_agencia_destino")
    '                        filcb = DvDetalle.Count
    '                        DvDetalle.AddNew()
    '                        DvDetalle.Delete(filcb)
    '                    End If
    '                    DvDetalle.AllowNew = False
    '                    DvDetalle.Sort = "item"
    '                    Call RecalculaFechas(Convert.ToDateTime(TxtFecInicio.GetMyFecha))
    '                End If
    '                DvCbDetRut.RowFilter = ""
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
    '    End Try
    'End Sub

    'Private Sub TxtFecInicio_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtFecInicio.Validating
    '    If TxtFecInicio.GetMyFecha <> "  /  /" Then
    '        Try
    '            fec_ini = Convert.ToDateTime(TxtFecInicio.GetMyFecha)
    '            TxtFecIni._MyFecha = TxtFecInicio.GetMyFecha
    '            TxtFecFin._MyFecha = TxtFecInicio.GetMyFecha
    '            Call RecalculaFechas(Convert.ToDateTime(TxtFecInicio.GetMyFecha))
    '        Catch ex As Exception
    '            MsgBox("Formato de Fecha Incorrecto", MsgBoxStyle.Critical, "Seguridad Sistema")
    '            e.Cancel = True
    '        End Try
    '    End If
    'End Sub


    'Private Sub BtnAyuRut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAyuRut.Click
    '    DtAyuRut = DtCbRut.Copy
    '    Dim Ayuda As New FrmRutas
    '    Ayuda.ShowDialog()
    '    DtCbRut = DtAyuRut.Copy
    '    DtCbDetRut = DtAyuRut.Copy
    '    DvCbRut = DtCbRut.DefaultView
    '    DvCbDetRut = DtCbDetRut.DefaultView
    '    LlenaCombo2(DvCbRut, CbRuta, "nombre_ruta")
    'End Sub


    'Private Sub BtnAyuAge1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAyuAge1.Click
    '    Try
    '        NAgeOri = DvCbAg1.RowFilter
    '        NAgeDes = DvCbAg2.RowFilter
    '        DtAyuRut = DtCbAg1.Copy
    '        DvCbAg1.RowFilter = ""
    '        DvCbAg2.RowFilter = ""
    '        Dim Ayuda As New FrmAgencias
    '        Ayuda.ShowDialog()
    '        DtCbAg1 = DtAyuRut.Copy
    '        DtCbAg2 = DtAyuRut.Copy
    '        DtCbDetAg1 = DtAyuRut.Copy
    '        DtCbDetAg2 = DtAyuRut.Copy
    '        DvCbAg1 = DtCbAg1.DefaultView
    '        DvCbAg2 = DtCbAg2.DefaultView
    '        DvCbDetAg1 = DtCbDetAg1.DefaultView
    '        DvCbDetAg2 = DtCbDetAg2.DefaultView
    '        LlenaCombo2(DvCbAg1, CbAge1, "nombre_agencia")
    '        LlenaCombo2(DvCbAg2, CbAge2, "nombre_agencia")
    '        DvCbAg1.RowFilter = NAgeOri
    '        DvCbAg2.RowFilter = NAgeDes
    '    Catch ex As Exception
    '        MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
    '    End Try
    'End Sub

    'Private Sub BtnAyuAge2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAyuAge2.Click
    '    Try
    '        NAgeOri = DvCbAg1.RowFilter
    '        NAgeDes = DvCbAg2.RowFilter
    '        DtAyuRut = DtCbAg1.Copy
    '        DvCbAg1.RowFilter = ""
    '        DvCbAg2.RowFilter = ""
    '        Dim Ayuda As New FrmAgencias
    '        Ayuda.ShowDialog()
    '        DtCbAg1 = DtAyuRut.Copy
    '        DtCbAg2 = DtAyuRut.Copy
    '        DtCbDetAg1 = DtAyuRut.Copy
    '        DtCbDetAg2 = DtAyuRut.Copy
    '        DvCbAg1 = DtCbAg1.DefaultView
    '        DvCbAg2 = DtCbAg2.DefaultView
    '        DvCbDetAg1 = DtCbDetAg1.DefaultView
    '        DvCbDetAg2 = DtCbDetAg2.DefaultView
    '        LlenaCombo2(DvCbAg1, CbAge1, "nombre_agencia")
    '        LlenaCombo2(DvCbAg2, CbAge2, "nombre_agencia")
    '        DvCbAg1.RowFilter = NAgeOri
    '        DvCbAg2.RowFilter = NAgeDes
    '    Catch ex As Exception
    '        MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
    '    End Try
    'End Sub
    'Sub Edicion()
    '    Dim filarow As Integer
    '    Dim DrUnd As DataRowView
    '    filarow = DataGridViewLista.CurrentRow.Index
    '    If filarow >= 0 Then
    '        DrUnd = DvAgencia.Item(DataGridViewLista.CurrentRow.Index)
    '        ClaseDet.ID = Convert.ToString(DrUnd("iditinerarios"))
    '        DtDetalle.Clear()
    '        rstDetalle = ClaseDet.Lista
    '        dr4.Fill(DtDetalle, rstDetalle)
    '        DvDetalle = DtDetalle.DefaultView
    '        DtDetaCopy = DtDetalle.Copy
    '        DvDetaCopy = DtDetaCopy.DefaultView
    '        TabMante.SelectedIndex = 1
    '        TxtID.Text = Convert.ToString(DrUnd("iditinerarios"))
    '        TxtFecInicio._MyFecha = DrUnd("fecha_itinerario")
    '        TxtFecIni._MyFecha = DrUnd("fecha_itinerario")
    '        TxtFecFin._MyFecha = DrUnd("fecha_itinerario")
    '        TxtHora.Text = DrUnd("hora_partida")
    '        CbOriDet.SelectedIndex = UbicaCombo2(DvCbOde, DrUnd, "idunidad_agencia", "idunidad_agencia", "nombre_unidad")
    '        CbRuta.SelectedIndex = UbicaCombo2(DvCbRut, DrUnd, "idrutas", "idrutas", "nombre_ruta")
    '        CbAge1.SelectedIndex = UbicaCombo2(DvCbAg1, DrUnd, "idagencias", "idagencia_origen", "nombre_agencia")
    '        CbAge2.SelectedIndex = UbicaCombo2(DvCbAg2, DrUnd, "idagencias", "idagencia_destino", "nombre_agencia")
    '        CbSerDet.SelectedIndex = UbicaCombo2(DvCbSde, DrUnd, "idclase", "idclase", "clase")
    '        TxtMensaje.Text = "Modificacion"
    '        TxtFecIni.Enabled = False
    '        TxtFecFin.Enabled = False
    '        ImprimirToolStripMenuItem.Enabled = True
    '        'Call GrillaMante()
    '        CbOriDet.Focus()
    '    End If
    'End Sub
    'Sub RecalculaFechas(ByVal fec_inicial As Date)
    '    If DvDetalle.Count > 0 Then
    '        fec_ini = DateAdd(DateInterval.Hour, Convert.ToDouble(Mid(TxtHora.Text, 1, 2)), fec_inicial)
    '        fec_ini = DateAdd(DateInterval.Minute, Convert.ToDouble(Mid(TxtHora.Text, 4, 2)), fec_ini)
    '        hora_ini = Mid(Convert.ToString(fec_ini), 12, 13)
    '        For i = 1 To DvDetalle.Count
    '            If i > DvDetalle.Count Then
    '                Exit For
    '            End If
    '            dr = DvDetalle.Item(i - 1)
    '            ndias = IIf(IsDBNull(dr("dias_viaje")) = True, 0, dr("dias_viaje"))
    '            chora = IIf(IsDBNull(dr("horas_viaje")) = True, "00:00", dr("horas_viaje"))
    '            fec_fin = CalculaFechaLlegada(ndias, chora, fec_ini)

    '            dr("hora_partida") = Mid(Convert.ToString(fec_ini), 12, 13)
    '            dr("hora_llegada") = Mid(Convert.ToString(fec_fin), 12, 13)
    '            dr("fecha_partida") = fec_ini
    '            dr("fecha_llegada") = fec_fin
    '            hora_fin = Mid(Convert.ToString(fec_fin), 12, 13)
    '            fec_ini = fec_fin
    '        Next
    '    End If

    'End Sub
    'Sub UpdateCopyDetail(ByVal SId As Integer)
    '    DrCopy = DvDetalle.Item(SId)
    '    If DrCopy("idrutas_itinerarios") > 0 Then
    '        DvDetaCopy.Sort = "idrutas_itinerarios"
    '        IDUser = DvDetaCopy.Find(DrCopy("idrutas_itinerarios"))
    '        If IDUser >= 0 Then
    '            dr2 = DvDetaCopy.Item(IDUser)
    '            dr2("flgdel") = 1
    '        End If
    '    End If
    'End Sub
    Public Function BuscaRecojos() As Boolean

        Dim movil, ruta, estado As Integer

        'Dim rstbus As ADODB.Recordset
        Try
            DtDetalle.Clear()
            If CbMovil.Items().Count > 0 Then
                Dim dt1 As Object = CbMovil.SelectedIndex
                Dim dt2 As Object = CbRutMov.SelectedIndex
                Dim dt3 As Object = CbEstado.SelectedIndex
                If IsNothing(dt1) = False And IsNothing(dt2) = False And IsNothing(dt3) = False Then
                    dr = DvCbMov.Item(CbMovil.SelectedIndex)
                    dr2 = DvCbRut.Item(CbRutMov.SelectedIndex)
                    dr3 = DvCbSta.Item(CbEstado.SelectedIndex)
                Else
                    dr = DvCbMov.Item(0)
                    dr2 = DvCbRut.Item(0)
                    dr3 = DvCbSta.Item(0)
                End If
            Else
                dr = DvCbMov.Item(0)
                dr2 = DvCbRut.Item(0)
                dr3 = DvCbSta.Item(0)
            End If



            movil = dr("IDUNIDAD_TRANSPORTE")
            ruta = dr2("IDRUTA_ENTREGA_RECOJO")
            estado = dr3("IDESTADO_REGISTRO")
            Clase.Movil = movil
            Clase.Ruta = ruta
            Clase.Estado = estado
            If Trim(TxtCliente.Text) = "" Then
                TxtCliente.Text = "%"
            End If
            If IsNumeric(TxtCliente.Text) = True Then
                Clase.Ruc = Trim(TxtCliente.Text)
                Clase.Cliente = "ZZZZ"
            Else
                Clase.Ruc = "0"
                Clase.Cliente = Trim(TxtCliente.Text)
            End If
            Clase.Fecha_Ini = TxtFechaIni.GetMyFecha
            Clase.Fecha_Fin = TxtFechaFin.GetMyFecha
            Dim ldt_tmp As New DataTable
            'rstbus = Clase.Buscar
            DtDetalle = Clase.Buscar
            'dr4.Fill(DtDetalle, rstbus)
            'DvDetalle = DtDetalle.DefaultView
            DvDetalle = DtDetalle.DefaultView
            DvDetalle.AllowNew = False
            'MessageBox.Show(DvDetalle.Count.ToString)
            Call GrillaMante()


            'DvCbRut.RowFilter = "idunidad_agencia = " + origen.ToString + " and idunidad_agencia_destino = " + destino.ToString
            'If DvCbRut.Count > 0 Or origen = 9999 Or destino = 9999 Then
            '    dr = DvCbRut.Item(0)
            '    Clase.Ruta = dr("idrutas")
            '    Clase.Fecha_Ini = TxtFechaIni.GetMyFecha
            '    Clase.Fecha_Lle = TxtFechaFin.GetMyFecha
            '    DtIti.Clear()
            '    rstIti = Clase.Buscar
            '    da.Fill(DtIti, rstIti)
            '    DvAgencia = DtIti.DefaultView
            '    DvAgencia.AllowNew = False
            '    Call GrillaMante2()
            'Else
            '    MsgBox("El Origen y Destino Seleccionado no tiene una Ruta Registrada", MsgBoxStyle.Critical, "Seguridad Sistema")
            'End If
            'DvCbRut.RowFilter = ""
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
        Return False
    End Function
    Private Sub GridListaPedidos_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridViewLista.CellFormatting
        Dim strvar As String = ""
        Try
            strvar = e.RowIndex.ToString()
            'If bformatImage = True Then
            If e.ColumnIndex = 0 Then
                Dim IdEstado As Integer
                IdEstado = DataGridViewLista.Rows().Count
                If e.RowIndex >= 0 And DataGridViewLista.Rows().Count - 1 >= e.RowIndex Then
                    dr = DvDetalle.Item(e.RowIndex)
                    IdEstado = dr("idestado_recojo")
                    'If IsDBNull(DataGridViewLista.Rows(e.RowIndex).Cells(1).Value) = False Then
                    '    ' GridListaPedidos.Rows(e.RowIndex).Cells(0).Tag = 1
                    '    IdEstado = DataGridViewLista.Rows(e.RowIndex).Cells(9).Value
                    '    'IdEstado = GridListaPedidos.Rows(e.RowIndex).Cells(1).Value
                    '    'IdEstado = GridListaPedidos.Rows(e.RowIndex).Cells(9).Value
                    'Else
                    '    IdEstado = 0
                    'End If
                    'IdEstado = IIf(IsNothing(DataGridViewUser.Rows(e.RowIndex).Cells(7).Value), 0, DataGridViewUser.Rows(e.RowIndex).Cells(7).Value)
                    Select Case IdEstado
                        Case 10
                            e.Value = bmActivo
                        Case 11
                            e.Value = bmPendiente
                        Case 3
                            e.Value = bmEliminado
                        Case Else
                            e.Value = bmPendiente
                    End Select
                    'GridListaPedidos.UpdateCellValue(e.ColumnIndex, e.RowIndex)
                    'GridListaPedidos.Update()
                    'Update()

                End If
            End If

            'End If

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema" & strvar)
        End Try
    End Sub
    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem1.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem1.EnabledChanged, CancelarToolStripMenuItem7.EnabledChanged, GrabarToolStripMenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub DataGridViewLista_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewLista.CellContentClick

    End Sub

    Private Sub BtnAgrega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgrega.Click

    End Sub

    Private Sub BtnInserta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInserta.Click

    End Sub
End Class