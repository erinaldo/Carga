Imports System.Windows.Forms
Imports System.Drawing
Imports Word
Imports Excel
''' <summary>
''' Esta Clase es el Formulario Padre para todo el Proyecto, de esta heredaran todos los formularios.
''' </summary>
''' <remarks></remarks>
Public Class FrmPlantilla

#Region " DECLARACION DE EVENTOS PUBLICOS VARIABLES "
    Public Event MenuNuevo()
    Public Event MenuEditar()
    Public Event MenuCancelar()
    Public Event MenuGrabar()
    Public Event MenuEliminar()
    Public Event MenuExWord()
    Public Event MenuExExcel()
    Public Event MenuExPDF()
    Public Event MenuExEMail()
    Public Event MenuImprimir()
    Public Event MenuSalir()
    Public Event ClickTabPage1()
    Public Event ClickTabPage2()
    Public Event ClickTabPage3()
    Public Event ClickTabPage4()
    Public Event ClickTabPage5()
    Public Event ClickTabPage6()
#End Region

#Region " PROCEDIMIENTOS QUE SE ENCARGAN DEL STILO VISUAL "
    Private Sub SplitContainer1_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), New System.Drawing.Point(965, 80))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#366AB3"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Sub SplitContainer1_Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel2.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#366AB3"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Sub SplitContainer2_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer2.Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#366AB3"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Sub SplitContainer2_Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer2.Panel2.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#366AB3"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Sub MenuStrip1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MenuStrip1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), New System.Drawing.Point(965, 55))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#366AB3"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Sub TabDatos_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabDatos.Paint, TabLista.Paint, TabPage1.Paint, TabPage2.Paint, TabPage3.Paint, TabPage4.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#366AB3"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#366AB3"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Sub MenuTab_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MenuTab.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), New System.Drawing.Point(965, 55))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#366AB3"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
#End Region

#Region " ASIGNACION DE LOS EVENTOS PUBLICOS AL MENU PRINCIPAL "

    Private Sub NuevoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        RaiseEvent MenuNuevo()
        'SelectMenu(1)
        'SplitContainer2.Panel1Collapsed = True
        'NuevoToolStripMenuItem.Enabled = False
        'EdicionToolStripMenuItem.Enabled = False
        'CancelarToolStripmenuItem.Enabled = True
        'CancelarToolStripmenuItem.Visible = True
        'GrabarToolStripMenuItem.Enabled = True
        'EliminarToolStripMenuItem.Enabled = False
        'ExportarToolStripMenuItem.Enabled = False
        'ImprimirToolStripMenuItem.Enabled = False
    End Sub

    Private Sub EdicionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EdicionToolStripMenuItem.Click
        RaiseEvent MenuEditar()
        'SelectMenu(1)
        'SplitContainer2.Panel1Collapsed = True
        'NuevoToolStripMenuItem.Enabled = False
        'EdicionToolStripMenuItem.Enabled = False
        'CancelarToolStripmenuItem.Enabled = True
        'CancelarToolStripmenuItem.Visible = True
        'GrabarToolStripMenuItem.Enabled = True 'Colocar en todos los formualrios esto, luego de dshabilitarlos.
        'EliminarToolStripMenuItem.Enabled = False
        'ExportarToolStripMenuItem.Enabled = False
        'ImprimirToolStripMenuItem.Enabled = False
    End Sub

    Private Sub CancelarToolStripmenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarToolStripmenuItem.Click
        RaiseEvent MenuCancelar()
        'SelectMenu(0)
        'SplitContainer2.Panel1Collapsed = False
        'NuevoToolStripMenuItem.Enabled = True
        'EdicionToolStripMenuItem.Enabled = True
        'CancelarToolStripmenuItem.Enabled = False
        'CancelarToolStripmenuItem.Visible = False
        'GrabarToolStripMenuItem.Enabled = False
        'EliminarToolStripMenuItem.Enabled = True
        'ExportarToolStripMenuItem.Enabled = True
        'ImprimirToolStripMenuItem.Enabled = True
    End Sub

    Private Sub GrabarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrabarToolStripMenuItem.Click
        RaiseEvent MenuGrabar()
        'SelectMenu(0)
        'SplitContainer2.Panel1Collapsed = False
        'NuevoToolStripMenuItem.Enabled = True
        'EdicionToolStripMenuItem.Enabled = True
        'CancelarToolStripmenuItem.Enabled = False
        'CancelarToolStripmenuItem.Visible = False
        'GrabarToolStripMenuItem.Enabled = False
        'EliminarToolStripMenuItem.Enabled = True
        'ExportarToolStripMenuItem.Enabled = True
        'ImprimirToolStripMenuItem.Enabled = True
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem.Click
        RaiseEvent MenuEliminar()
    End Sub

    Private Sub WordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WordToolStripMenuItem.Click
        MessageBox.Show("Evento del Exportar a Word")
        RaiseEvent MenuExWord()
    End Sub

    Private Sub ExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelToolStripMenuItem.Click
        MessageBox.Show("Evento del Exportar a Excel")
        RaiseEvent MenuExExcel()
    End Sub

    Private Sub PDFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PDFToolStripMenuItem.Click
        RaiseEvent MenuExPDF()
    End Sub

    Private Sub EmailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailToolStripMenuItem.Click
        RaiseEvent MenuExEMail()
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirToolStripMenuItem.Click
        RaiseEvent MenuImprimir()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        RaiseEvent MenuSalir()
        'Me.Close()
    End Sub
#End Region

#Region " FUNCIONES A NIVEL DEL FORMULARIO "
    ''' <summary>
    ''' DataGridLista_MouseUp(), esta funcion devuelve la posición de la Fila,
    ''' a la que le hacemos Double Click.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridLista_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'Dim pt As New System.Drawing.Point(e.X, e.Y)
        'Dim hti As DataGrid.HitTestInfo = DataGridLista.HitTest(pt)
        'If hti.Type = DataGrid.HitTestType.Cell Then
        '    DataGridLista.CurrentCell = New DataGridCell(hti.Row, hti.Column)
        '    DataGridLista.Select(hti.Row)
        'End If
    End Sub

    ''' <summary>
    ''' Esta funcion cambia los estados de los controles cuado se visualiza la Grilla.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub VolverGrilla()
        SplitContainer2.Panel1Collapsed = False
        NuevoToolStripMenuItem.Enabled = True
        EdicionToolStripMenuItem.Enabled = True
        GrabarToolStripMenuItem.Enabled = False
        EliminarToolStripMenuItem.Enabled = True
        ExportarToolStripMenuItem.Enabled = True
    End Sub

    ''' <summary>  
    ''' Esta funcion selecciona el Tabpage del tabControl a partir de la seleccion del MenuStrip.
    ''' </summary>
    ''' <param name="ItemMenu"></param>
    ''' <remarks></remarks>
    Public Sub SelectMenu(ByVal ItemMenu As Integer)
        Dim ItemsTotal As Integer = MenuTab.Items.Count() - 1
        For i As Integer = 0 To ItemsTotal
            MenuTab.Items(i).BackColor = Color.Transparent
            MenuTab.Items(i).Font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Regular)
        Next
        MenuTab.Items(ItemMenu).BackColor = System.Drawing.SystemColors.Info
        MenuTab.Items(ItemMenu).Font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Bold)
        TabMante.SelectedIndex = ItemMenu
    End Sub

    ''' <summary>
    ''' Esta funcion cuadra todos los controles en RunTime, asi evitamos errores de Diseño en Herencias.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CuadrarFormulario()

        'Definimos el Tamaños del Formulario y Controles para no tener problemas en las herecias.
        Me.Size = New Size(788, 648)
        SplitContainer1.Size = New Size(788, 648)
        ShadowLabel1.Size = New Size(788, 35)
        SplitContainer2.Size = New Size(782, 556)
        MenuStrip1.Size = New Size(788, 32)
        StatusStrip1.Size = New Size(543, 21)
        Panel1.Size = New Size(545, 520)
        MyTreeView.Size = New Size(182, 539)
        MenuTab.Size = New Size(543, 28)
        TabMante.Size = New Size(543, 493)

        Dim MyObj As Object
        'Dim a As Integer
        For Each MyObj In Me.TabMante.TabPages
            If TypeOf MyObj Is TabPage Then
                'MessageBox.Show("Si Hay Tab Pages " & a.ToString, "TabPage de Nombre: " & CType(MyObj, TabPage).Name)
                'a += 1
                CType(MyObj, TabPage).Size = New Size(535, 464)
            End If
        Next

        'DataGridLista.Size = New Size(505, 369)
        'Fin de Definicion de tamaños.

        'Definimos las Posiciones de los Controles tambien.
        SplitContainer1.Location = New System.Drawing.Point(0, 0)
        ShadowLabel1.Location = New System.Drawing.Point(0, -2)
        SplitContainer2.Location = New System.Drawing.Point(0, 32)
        MenuStrip1.Location = New System.Drawing.Point(0, 0)
        StatusStrip1.Location = New System.Drawing.Point(18, 516)
        Panel1.Location = New System.Drawing.Point(17, 18)
        MyTreeView.Location = New System.Drawing.Point(8, 8)
        MenuTab.Location = New System.Drawing.Point(0, 0)
        TabMante.Location = New System.Drawing.Point(0, 3)
        'No asignamos las posiciones de los Tabpages pues estos no tienen esa propiedad.
        'DataGridLista.Location = New System.Drawing.Point(15, 78)
        'Fin de la Definicion de Posiciones.

    End Sub
#End Region

#Region " SELECCION DE LOS TABPAGE A PARTIR DEL MENU STRIP "

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        RaiseEvent ClickTabPage1()
        SelectMenu(0)
        VolverGrilla()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        RaiseEvent ClickTabPage2()
        SelectMenu(1)
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        RaiseEvent ClickTabPage3()
        'SelectMenu(2)
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        RaiseEvent ClickTabPage4()
        'SelectMenu(3)
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        RaiseEvent ClickTabPage5()
        'SelectMenu(4)
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        RaiseEvent ClickTabPage6()
        SelectMenu(5)
    End Sub

#End Region

#Region " EVENTOS DEL FORMULARIO Y DEMAS CONTROLES "
    Private Sub FrmPlantilla_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CuadrarFormulario()
        SelectMenu(0)
        NuevoToolStripMenuItem.Enabled = True
        EdicionToolStripMenuItem.Enabled = True
        CancelarToolStripmenuItem.Enabled = False
        CancelarToolStripmenuItem.Visible = False
        GrabarToolStripMenuItem.Enabled = False
        EliminarToolStripMenuItem.Enabled = True
        ExportarToolStripMenuItem.Enabled = True

        'Me.toolUsuario.Text = "Richard Vásquez Cuyotupac"
        'Me.toolRol.Text = "DBA"
        'Me.toolIP.Text = "192.168.50.47"
        'Tepsa 
        Me.toolUsuario.Text = dtoUSUARIOS.NameLogin
        Me.toolRol.Text = dtoUSUARIOS.Rol
        Me.toolIP.Text = dtoUSUARIOS.IP
    End Sub

    Private Sub MyTreeView_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles MyTreeView.AfterCheck
        MyTreeView.BeginUpdate()
        ActualizarCheck(e.Node, e.Node.Checked)
        MyTreeView.EndUpdate()
    End Sub

#End Region

End Class