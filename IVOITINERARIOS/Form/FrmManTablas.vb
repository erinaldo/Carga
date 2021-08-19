Imports System.Data.OracleClient
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Web
Imports System.Web.Mail
Imports System.Windows.Forms
Imports System.data
Public Class FrmManTablas
    Inherits FrmFormBase
    'Dim dr3 As New OracleDataAdapter
    'Dim dr4 As New OleDbDataAdapter
    Dim dt As New System.Data.DataTable
    Dim DvAgencia As DataView
    Dim Fact As Integer
    Dim Impresion As New ClsPrint
    Private _Nombre, _SPLista, _SPGraba, _campo1, _campo2, _campo3 As String
    '
    'Private rstRet As ADODB.Recordset
    '30/09/2009 
    Dim lobj_mantablas As New dtomantablas
    '
    Dim clase As New dtomantablas
    Dim bIngreso As Boolean
    Public hnd As Long
    Public Sub New(ByVal Nombre As String, ByVal SPLista As String, ByVal SPGraba As String, ByVal Campo1 As String, ByVal Campo2 As String, ByVal Campo3 As String)
        MyBase.new()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        _Nombre = Nombre
        _SPLista = SPLista
        _SPGraba = SPGraba
        _campo1 = Campo1
        _campo2 = Campo2
        _campo3 = Campo3

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Sub CargaDatos()
        Dim ObjUnd As Object() = {_SPLista, 0}
        'rst = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd)
        'MsgBox(rst.Fields(0).Value.ToString() + rst.Fields(1).Value)
        dt.Clear()
        'dr4.Fill(dt, VOCONTROLUSUARIO.fnSQLQuery(ObjUnd))
        dt = lobj_mantablas.fn_get_busca_procedimiento(_SPLista).Tables(0) ' Solo Recupera la Unidad de Agencia
        '
        DvAgencia = dt.DefaultView
        DvAgencia.AllowNew = False
    End Sub

    Private Sub FrmManTablas_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmManTablas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmRutas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SplitContainer2.Panel1Collapsed = True
        ShadowLabel1.Text = _Nombre
        MenuTab.Items(0).Text = "LISTA GENERAL"
        MenuTab.Items(1).Text = "DATOS GENERALES"
        If _campo3 = "null" Then
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
        Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
        Acceso.AplicaConfiguracion(dt1, Me, ContextMenuStrip)
        bIngreso = True
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

        If _campo3 <> "null" Then
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
            If _campo3 <> "null" Then
                TxtCampo3.Text = DrUnd(_campo3).ToString
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

    Private Sub FrmManTablas_MenuExEMail() Handles Me.MenuExEMail
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
        Dim lds_tmp As DataSet
        '
        If Fact = 1 Then
            TxtIdUnd.Text = "0"
        End If
        Try
            'Dim ObjUnd As Object() = {_SPGraba, 14, Fact, 1, Convert.ToInt16(TxtIdUnd.Text), 1, TxtNomUnd.Text, 2, 1, 1, 1, 1, "192.168.50.47", 2}
            Dim ObjUnd As Object()
            If _campo3 = "null" Then
                'Mod.30/09/2009 -->Omendoza - Pasando al datahelper -  
                'ObjUnd = New Object() {_SPGraba, 14, Fact, 1, Convert.ToInt16(TxtIdUnd.Text), 1, TxtNomUnd.Text, 2, 1, 1, 1, 1, "192.168.50.47", 2}
                lobj_mantablas.control = Fact
                lobj_mantablas.idunidad_agencia = Convert.ToInt32(TxtIdUnd.Text)
                lobj_mantablas.NOMBRE_ARTICULO = TxtNomUnd.Text
                lobj_mantablas.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                lobj_mantablas.idrol = dtoUSUARIOS.IdRol
                lobj_mantablas.ip = dtoUSUARIOS.IP
                lds_tmp = lobj_mantablas.fn_get_busca_procedimiento(_SPGraba)
            Else
                TxtCampo3.Text = IIf(Trim(TxtCampo3.Text) = "", " ", Trim(TxtCampo3.Text))
                'Mod.30/09/2009 -->Omendoza - Pasando al datahelper -  
                'ObjUnd = New Object() {_SPGraba, 16, Fact, 1, Convert.ToInt16(TxtIdUnd.Text), 1, TxtNomUnd.Text, 2, TxtCampo3.Text, 2, 1, 1, 1, 1, "192.168.50.47", 2}
                '
                lobj_mantablas.control = Fact
                lobj_mantablas.idunidad_agencia = Convert.ToInt32(TxtIdUnd.Text)
                lobj_mantablas.nombre_agencia = TxtNomUnd.Text
                lobj_mantablas.codigo_iata = TxtCampo3.Text
                ' Por defecto la ciudad de Lima 
                lobj_mantablas.distrito = 2
                lobj_mantablas.provincia = 17
                lobj_mantablas.departamento = 15
                lobj_mantablas.pais = 4
                lobj_mantablas.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                lobj_mantablas.idrol = dtoUSUARIOS.IdRol
                lobj_mantablas.ip = dtoUSUARIOS.IP
                '
                lds_tmp = lobj_mantablas.fn_get_busca_procedimiento(_SPGraba)
                '
            End If
            '
            'rst = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd)

            'If Convert.ToInt16(rst.Fields(0).Value) = 0 Then
            If Convert.ToInt16(lds_tmp.Tables(0).Rows(0).Item(0)) = 0 Then
                ' rstRet = rst.NextRecordset()
                MsgBox("Registro Grabado Correctamente", MsgBoxStyle.Information, "Seguridad del Sistema")
                If Fact = 1 Then
                    fil = DvAgencia.Count
                    DvAgencia.AllowNew = True
                    DvAgencia.AddNew()
                    dr = DvAgencia.Item(fil)
                    dr(_campo1) = lds_tmp.Tables(1).Rows(0)(0) 'rstRet.Fields(0).Value
                    dr(_campo2) = lds_tmp.Tables(1).Rows(0)(1) 'rstRet.Fields(1).Value
                    DvAgencia.AllowNew = False
                Else
                    fil = DataGridViewLista.CurrentRow.Index
                    If fil >= 0 Then
                        dr = DvAgencia.Item(fil)
                        dr(_campo1) = lds_tmp.Tables(1).Rows(0)(0) 'rstRet.Fields(0).Value
                        dr(_campo2) = lds_tmp.Tables(1).Rows(0)(1) 'rstRet.Fields(1).Value
                        If _campo3 <> "null" Then
                            dr(_campo3) = lds_tmp.Tables(1).Rows(0)(3) 'rstRet.Fields(2).Value
                        End If
                    End If
                End If
                'Call CargaDatos()
                'Call GrillaMante()
                TabMante.SelectedIndex = 0
            Else
                MessageBox.Show("Descripcion : " + Trim(Convert.ToString(lds_tmp.Tables(0).Rows(0).Item(1))), "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'MessageBox.Show("Descripcion : " + Trim(Convert.ToString(rst.Fields(1).Value)), "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
        End Try


    End Sub

    Private Sub FrmManTablas_MenuImprimir() Handles Me.MenuImprimir
        Dim PrDialog As New PrintPreviewDialog
        Impresion.Titulo = _Nombre
        Impresion.DGV = DataGridViewLista
        PrDialog.Document = Impresion
        PrDialog.ShowDialog()
    End Sub


    Private Sub FrmRutas_MenuNuevo() Handles Me.MenuNuevo
        TxtIdUnd.Text = ""
        TxtNomUnd.Text = ""
        Fact = 1
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

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem1.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem1.EnabledChanged, CancelarToolStripMenuItem7.EnabledChanged, GrabarToolStripMenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub DataGridViewLista_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewLista.CellContentClick

    End Sub
End Class