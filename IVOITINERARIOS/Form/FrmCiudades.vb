'Imports System.Data.OracleClient
'Imports System.Data.OleDb
'Imports System.Drawing
Imports System.Web
Imports System.Web.Mail

Public Class FrmCiudades
    Inherits FrmFormBase
    Dim Clase As New dtoCiudades
    '
    'Dim rstCiu, rstUnd, rstUnd2, rstPais, rstDepar, rstProv, rstDist, rstSta, rstRet As ADODB.Recordset 
    '
    Dim DvAgencia, DvCbUnd, DvCbPais, DvCbDepar, DvCbProv, DvCbDist, DvCbSta, DvCbEst As DataView
    '   Dim dr3 As New OracleDataAdapter
    'Dim dr4 As New OleDbDataAdapter
    Dim dt, DtCbUnd, DtCbPais, DtCbDepar, DtCbProv, DtCbDist, DtCbSta, DtCbEst As New System.Data.DataTable
    Dim Fact As Integer
    Dim Impresion As New ClsPrint
    Dim lb_lee As Boolean
    Private _Nombre, _SPLista, _SPGraba, _campo1, _campo2, _campo3 As String
    Dim bIngreso As Boolean = False
    Public hnd As Long
    Public Sub New()
        MyBase.new()
        ' This call is required by the Windows Form Designer.

        'Dim Rutas As New FrmManTablas("Mantenimiento de Ciudades", "PKG_IVOITINERARIOS.SP_LISTA_UNIDADES", "PKG_IVOITINERARIOS.SP_INSUPD_UNIDAD_AGENCIA", "idunidad_agencia", "nombre_unidad", "codigo_iata")
        InitializeComponent()
        _Nombre = "Mantenimiento de Ciudades"
        _SPLista = "PKG_IVOITINERARIOS.SP_LISTA_UNIDADES"
        _SPGraba = "PKG_IVOITINERARIOS.SP_INSUPD_UNIDAD_AGENCIA"
        _campo1 = "idunidad_agencia"
        _campo2 = "nombre_unidad"
        _campo3 = "codigo_iata"

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub CargaDatos()
        Dim ObjUnd As Object() = {_SPLista, 0}
        'rst = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd)
        'MsgBox(rst.Fields(0).Value.ToString() + rst.Fields(1).Value)
        dt.Clear()
        'Mod.25/09/2009 -->Omendoza - Pasando al datahelper   

        'rstCiu = Clase.Lista
        'rstPais = rstCiu.NextRecordset
        'rstDepar = rstCiu.NextRecordset
        'rstProv = rstCiu.NextRecordset
        'rstDist = rstCiu.NextRecordset
        'dr4.Fill(dt, rstCiu)
        'dr4.Fill(DtCbPais, rstPais)
        'dr4.Fill(DtCbDepar, rstDepar)
        'dr4.Fill(DtCbProv, rstProv)
        'dr4.Fill(DtCbDist, rstDist)
        '
        lb_lee = False
        '
        Dim lds_tmp As New DataSet
        lds_tmp = Clase.Lista
        '
        dt = lds_tmp.Tables(0)
        DtCbPais = lds_tmp.Tables(1)
        DtCbDepar = lds_tmp.Tables(2)
        DtCbProv = lds_tmp.Tables(3)
        DtCbDist = lds_tmp.Tables(4)
        '
        DvCbPais = DtCbPais.DefaultView
        DvCbDepar = DtCbDepar.DefaultView
        DvCbProv = DtCbProv.DefaultView
        DvCbDist = DtCbDist.DefaultView
        '
        LlenaCombo2(DvCbPais, CbPais, "pais")
        LlenaCombo2(DvCbDepar, CbDepar, "departamento")
        LlenaCombo2(DvCbProv, CbProv, "provincia")
        LlenaCombo2(DvCbDist, CbDist, "dsitrito")
        DvAgencia = dt.DefaultView
        DvAgencia.AllowNew = False
        '
        lb_lee = True
        '
    End Sub

    Private Sub FrmCiudades_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmRutas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            SplitContainer2.Panel1Collapsed = True
            ShadowLabel1.Text = _Nombre
            MenuTab.Items(0).Text = "LISTA GENERAL"
            MenuTab.Items(1).Text = "DATOS GENERALES"
            If _campo3 = "Null" Then
                LbCampo3.Visible = False
                TxtCampo3.Visible = False
            Else
                LbCampo3.Visible = True
                LbCampo3.Text = _campo3
                TxtCampo3.Visible = True
            End If
            Call CargaDatos()
            Fact = 0
            Call GrillaMante()

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
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
            .DataPropertyName = _campo1
            .HeaderText = "Codigo"
            .Width = 85
        End With
        DataGridViewLista.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DataPropertyName = _campo2
            .HeaderText = "Nombre"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridViewLista.Columns.Add(col1)

        If _campo3 <> "Null" Then
            Dim col2 As New DataGridViewTextBoxColumn
            With col2
                .DataPropertyName = _campo3
                .HeaderText = _campo3
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            DataGridViewLista.Columns.Add(col2)
        End If
    End Sub
    Sub Edicion()
        Dim filarow As Integer
        Dim DrUnd As DataRowView
        filarow = DataGridViewLista.CurrentRow.Index
        If filarow >= 0 Then
            TabMante.SelectedIndex = 1
            DrUnd = DvAgencia.Item(DataGridViewLista.CurrentRow.Index)
            TxtIdUnd.Text = DrUnd(_campo1).ToString
            TxtNomUnd.Text = DrUnd(_campo2).ToString
            If _campo3 <> "Null" Then
                TxtCampo3.Text = DrUnd(_campo3).ToString
            End If
            If IsDBNull(DrUnd("idpais")) Then
                CbPais.SelectedValue = ""
            Else
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
                        CbDist.SelectedIndex = UbicaCombo(DvCbDist, DrUnd, "iddistrito")
                    End If
                End If
            End If

            TxtNomUnd.Focus()
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

    Private Sub FrmCiudades_MenuExEMail() Handles Me.MenuExEMail
        Try
            Dim MyMail As New Net.Mail.MailMessage
            Dim smtp As New System.Net.Mail.SmtpClient
            MyMail.From = New System.Net.Mail.MailAddress("evizcarra@tepsa.com.pe")
            MyMail.To.Add("rvasquez@tepsa.com.pe")
            MyMail.Subject = "Prueba de Correo"
            MyMail.Body = " Prueba de Correo"
            smtp.Host = "192.168.200.2"
            'SmtpMail.SmtpServer = "192.168.50.1"
            smtp.Send(MyMail)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub
    Private Sub FrmRutas_MenuGrabar() Handles Me.MenuGrabar
        Dim fil As Integer
        Dim dr As DataRowView
        If Fact = 1 Then
            TxtIdUnd.Text = "0"
        End If
        Try
            Dim drpais, drdepa, drprov, drdist As DataRowView
            drpais = DvCbPais.Item(CbPais.SelectedIndex)
            drdepa = DvCbDepar.Item(CbDepar.SelectedIndex)
            drprov = DvCbProv.Item(CbProv.SelectedIndex)
            drdist = DvCbDist.Item(CbDist.SelectedIndex)
            Clase.Accion = Fact
            Clase.Pais = drpais("idpais")
            Clase.Departamento = drdepa("iddepartamento")
            Clase.Provincia = drprov("idprovincia")
            Clase.Distrito = drdist("iddistrito")
            Clase.ID = Convert.ToInt16(TxtIdUnd.Text)
            Clase.NomCiudad = TxtNomUnd.Text
            Clase.IATA = TxtCampo3.Text
            Clase.Usuario = dtoUSUARIOS.IdLogin
            Clase.Rol = dtoUSUARIOS.IdRol
            Clase.IP = dtoUSUARIOS.IP
            Dim lds_tmp As New DataSet
            'Mod.25/09/2009 -->Omendoza - Pasando al datahelper   
            'rst = Clase.Grabar
            lds_tmp = Clase.Grabar
            'If Convert.ToInt16(rst.Fields(0).Value) = 0 Then
            If Convert.ToInt16(lds_tmp.Tables(0).Rows(0).Item(0)) = 0 Then
                'rstRet = rst.NextRecordset()
                MsgBox("Registro Grabado Correctamente", MsgBoxStyle.Information, "Seguridad del Sistema")
                If Fact = 1 Then
                    fil = DvAgencia.Count
                    DvAgencia.AllowNew = True
                    DvAgencia.AddNew()
                    dr = DvAgencia.Item(fil)
                    dr(_campo1) = lds_tmp.Tables(1).Rows(0).Item(0)
                    dr(_campo2) = lds_tmp.Tables(1).Rows(0).Item(1)
                    dr(_campo3) = lds_tmp.Tables(1).Rows(0).Item(2)
                    dr("IDPAIS") = lds_tmp.Tables(1).Rows(0).Item(3)
                    dr("IDDEPARTAMENTO") = lds_tmp.Tables(1).Rows(0).Item(4)
                    dr("IDPROVINCIA") = lds_tmp.Tables(1).Rows(0).Item(5)
                    dr("IDDISTRITO") = lds_tmp.Tables(1).Rows(0).Item(6)
                    DvAgencia.AllowNew = False
                Else
                    fil = DataGridViewLista.CurrentRow.Index
                    If fil >= 0 Then
                        dr = DvAgencia.Item(fil)
                        dr(_campo1) = lds_tmp.Tables(1).Rows(0).Item(0)
                        dr(_campo2) = lds_tmp.Tables(1).Rows(0).Item(1)
                        dr(_campo3) = lds_tmp.Tables(1).Rows(0).Item(2)
                        dr("IDPAIS") = lds_tmp.Tables(1).Rows(0).Item(3)
                        dr("IDDEPARTAMENTO") = lds_tmp.Tables(1).Rows(0).Item(4)
                        dr("IDPROVINCIA") = lds_tmp.Tables(1).Rows(0).Item(5)
                        dr("IDDISTRITO") = lds_tmp.Tables(1).Rows(0).Item(6)
                    End If
                End If
                'Call CargaDatos()
                'Call GrillaMante()
                TabMante.SelectedIndex = 0
            Else
                MessageBox.Show("Descripcion : " + Trim(Convert.ToString(lds_tmp.Tables(0).Rows(0).Item(1))), "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub
    Private Sub FrmCiudades_MenuImprimir() Handles Me.MenuImprimir
        Dim PrDialog As New PrintPreviewDialog
        Impresion.Titulo = _Nombre
        Impresion.DGV = DataGridViewLista
        PrDialog.Document = Impresion
        PrDialog.ShowDialog()
    End Sub
    Private Sub FrmRutas_MenuNuevo() Handles Me.MenuNuevo
        TxtIdUnd.Text = ""
        TxtNomUnd.Text = ""
        TxtCampo3.Text = ""
        Fact = 1
        CbPais.SelectedValue = ""
        TabMante.SelectedIndex = 1
        TxtNomUnd.Focus()
    End Sub
    Private Sub datagridviewlista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLista.DoubleClick
        Call Edicion()
    End Sub
    Public Sub DrawStringFloatFormat(ByVal e As PaintEventArgs)
        Dim drawString As [String] = "Sample Text"
        Dim drawFont As New System.Drawing.Font("Arial", 16)
        Dim drawBrush As New SolidBrush(Color.Black)
        Dim x As Single = 150.0F
        Dim y As Single = 50.0F
        Dim drawFormat As New StringFormat()
        drawFormat.FormatFlags = StringFormatFlags.DirectionVertical
        e.Graphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat)
    End Sub
    Private Sub TxtBusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBusca.TextChanged
        DvAgencia.RowFilter = "trim(" & Trim(_campo2) & ") like '*" & Trim(TxtBusca.Text) & "*'"
        'Call GrabaFiltros()
        'swgrid = True
    End Sub

    Private Sub CbPais_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbPais.SelectedIndexChanged
        If lb_lee = True Then
            Dim filcb As Integer
            Dim drc As DataRowView
            Dim valor As String
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

    Private Sub CbDepar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbDepar.SelectedIndexChanged
        If lb_lee = True Then
            Dim filcb As Integer
            Dim drc As DataRowView
            Dim valor As String
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
    End Sub

    Private Sub CbProv_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbProv.SelectedIndexChanged
        If lb_lee = True Then
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

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem1.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem1.EnabledChanged, CancelarToolStripMenuItem7.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class