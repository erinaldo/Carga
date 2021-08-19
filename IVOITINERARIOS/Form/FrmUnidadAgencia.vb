Imports System.Data.OracleClient
'Imports System.Data.OleDb
Imports System.Drawing
Imports System.Data
Imports System.Collections
Imports System.Windows.Forms
Public Class FrmUnidadAgencia
    'Dim dr3 As New OracleDataAdapter
    'Dim dr4 As New OleDbDataAdapter
    Dim dt As New DataTable
    Dim lobj_dtomantenimiento As New dtomantablas
    Dim DvAgencia As DataView
    Dim Fact As Integer
    Private Sub SplitContainer1_Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel2.Paint
        MyBase.OnPaint(e)
        Dim rec As New Rectangle(New Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Sub SplitContainer1_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New Rectangle(New Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Info, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Sub CargaDatos()
        Dim lds_tmp As New DataSet
        'Dim ObjUnd As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_UNIDADES", 0}
        lds_tmp = lobj_dtomantenimiento.fn_get_busca_procedimiento("PKG_IVOITINERARIOS.SP_LISTA_UNIDADES")
        'rst = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd)
        'MsgBox(rst.Fields(0).Value.ToString() + rst.Fields(1).Value)
        dt.Clear()
        'dr4.Fill(dt, VOCONTROLUSUARIO.fnSQLQuery(ObjUnd))
        dt = lds_tmp.Tables(0)
        '
        DvAgencia = dt.DefaultView
        DvAgencia.AllowNew = False
    End Sub
    Sub GrillaMante()
        With DataGridUnd
            .DataSource = dt
            .BackColor = SystemColors.Info
            .BackgroundColor = SystemColors.Info
            '.RowHeadersVisible = False
            .BorderStyle = BorderStyle.Fixed3D
            .CaptionBackColor = SystemColors.ActiveCaption
            .CaptionFont = New Font("Tahoma", 14.0!, FontStyle.Bold)
            .CaptionText = ""
            .CaptionVisible = False
            .Font = New Font("Tahoma", 8.0!)
            .ParentRowsBackColor = Color.White
            .ParentRowsForeColor = Color.Black
            .GridLineStyle = DataGridLineStyle.Solid
            .ParentRowsVisible = False
            .AllowNavigation = True
            .ReadOnly = False
            .AllowSorting = True
        End With
        DataGridUnd.TableStyles.Clear()

        Dim DataGridTableStylew As New DataGridTableStyle()
        With DataGridTableStylew
            .MappingName = DvAgencia.Table.TableName
            .RowHeaderWidth = 5
            .AllowSorting = True
        End With
        Dim DataGridTableStyle1 As New DataGridTextBoxColumn()
        With DataGridTableStyle1
            .MappingName = "idunidad_agencia"
            .HeaderText = "Codigo"
            .Width = 85
            '.ReadOnly = True
            .NullText = ""
            .TextBox.Enabled = False
        End With
        Dim DataGridTableStyle2 As New DataGridTextBoxColumn()
        With DataGridTableStyle2
            .MappingName = "nombre_unidad"
            .HeaderText = "Unidad"
            .Width = 300
            .NullText = ""
        End With
        DataGridTableStylew.GridColumnStyles.AddRange _
    (New DataGridColumnStyle() _
         {DataGridTableStyle1, _
         DataGridTableStyle2})
        DataGridUnd.TableStyles.Add(DataGridTableStylew)
    End Sub

    Private Sub FrmUnidadAgencia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SplitContainer1.Panel1Collapsed = True
        Call CargaDatos()
        Fact = 0
        Call GrillaMante()
    End Sub
    Private Sub DataGridUnd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridUnd.DoubleClick
        Call Edicion()
    End Sub

    Private Sub DataGridUnd_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridUnd.MouseUp
        Dim pt As New Point(e.X, e.Y)
        Dim hti As DataGrid.HitTestInfo = DataGridUnd.HitTest(pt)
        If hti.Type = DataGrid.HitTestType.Cell Then
            DataGridUnd.CurrentCell = New DataGridCell(hti.Row, hti.Column)
            DataGridUnd.Select(hti.Row)
        End If
    End Sub

    Private Sub TabListaUser_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabListaUser.Paint
        MyBase.OnPaint(e)
        Dim rec As New Rectangle(New Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub



    Private Sub TabDatosUsuario_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabDatosUsuario.Paint
        MyBase.OnPaint(e)
        Dim rec As New Rectangle(New Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Sub Edicion()
        Dim filarow As Integer
        Dim DrUnd As DataRowView
        filarow = DataGridUnd.CurrentRowIndex
        If filarow >= 0 Then
            NuevoToolStripMenuItem1.Enabled = False
            EdicionToolStripMenuItem.Enabled = False
            GrabarToolStripMenuItem.Enabled = True
            DrUnd = DvAgencia.Item(DataGridUnd.CurrentRowIndex)
            TxtIdUnd.Text = DrUnd("idunidad_agencia").ToString
            TxtNomUnd.Text = DrUnd("nombre_unidad").ToString
            TabUsuarios.SelectedIndex = 1
            TxtNomUnd.Focus()
        End If
    End Sub



    Private Sub TabUsuarios_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabUsuarios.Selecting
        If e.TabPageIndex = 1 Then
            If Fact <> 1 Then
                Fact = 2
                Call Edicion()
            End If
        Else
            Fact = 0
            NuevoToolStripMenuItem1.Enabled = True
            EdicionToolStripMenuItem.Enabled = True
            GrabarToolStripMenuItem.Enabled = False
        End If
    End Sub



    Private Sub MenuStrip1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MenuStrip1.Paint
        MyBase.OnPaint(e)
        Dim rec As New Rectangle(New Point(0, 0), New Point(965, 55))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub NuevoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem1.Click
        NuevoToolStripMenuItem1.Enabled = False
        EdicionToolStripMenuItem.Enabled = False
        GrabarToolStripMenuItem.Enabled = True
        TxtIdUnd.Text = ""
        TxtNomUnd.Text = ""
        Fact = 1
        TabUsuarios.SelectedIndex = 1
        TxtNomUnd.Focus()
    End Sub

    Private Sub EdicionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EdicionToolStripMenuItem.Click
        Fact = 2
        Call Edicion()
    End Sub

    Private Sub GrabarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrabarToolStripMenuItem.Click
        Dim lds_tmp As DataSet
        If Fact = 1 Then
            TxtIdUnd.Text = "0"
        End If
        'Dim ObjUnd As Object() = {"PKG_IVOITINERARIOS.SP_INSUPD_UNIDAD_AGENCIA", 14, Fact, 1, Convert.ToInt16(TxtIdUnd.Text), 1, TxtNomUnd.Text, 2, 1, 1, 1, 1, "192.168.50.47", 2}
        'rst = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd)
        '
        lobj_dtomantenimiento.control = Fact
        lobj_dtomantenimiento.idunidad_agencia = Convert.ToInt32(TxtIdUnd.Text)
        lobj_dtomantenimiento.nombre_agencia = TxtNomUnd.Text
        lobj_dtomantenimiento.codigo_iata = "PRU" '-- No debe usasrse 
        ' Por defecto la ciudad de Lima 
        lobj_dtomantenimiento.distrito = 2
        lobj_dtomantenimiento.provincia = 17
        lobj_dtomantenimiento.departamento = 15
        lobj_dtomantenimiento.pais = 4
        lobj_dtomantenimiento.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
        lobj_dtomantenimiento.idrol = dtoUSUARIOS.IdRol
        lobj_dtomantenimiento.ip = dtoUSUARIOS.IP
        '
        lds_tmp = lobj_dtomantenimiento.fn_get_busca_procedimiento("PKG_IVOITINERARIOS.SP_INSUPD_UNIDAD_AGENCIA")
        '
        Call CargaDatos()
        Call GrillaMante()
        TabUsuarios.SelectedIndex = 0
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub TableLayoutPanel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New Rectangle(New Point(0, 0), Me.ClientSize)
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

End Class