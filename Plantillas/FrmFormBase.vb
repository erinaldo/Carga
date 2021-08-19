Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Excel
Imports Word
Public Class FrmFormBase
    Public Event MenuNuevo()
    Public Event MenuEditar()
    Public Event MenuGrabar()
    Public Event MenuCancelar()
    Public Event MenuEliminar()
    Public Event MenuExWord()
    Public Event MenuExExcel()
    Public Event MenuExPDF()
    Public Event MenuExEMail()
    Public Event MenuImprimir()
    Public Event MenuMasivo()
    Public Event MenuSalir()
    Private Sub SplitContainer1_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), New System.Drawing.Point(965, 80))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#507EAF"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Sub SplitContainer1_Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel2.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#507EAF"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Sub SplitContainer2_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer2.Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Info, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Sub SplitContainer2_Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer2.Panel2.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#507EAF"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub


    Private Sub MenuStrip1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MenuStrip1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), New System.Drawing.Point(965, 55))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#507EAF"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub NuevoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem1.Click
        RaiseEvent MenuNuevo()
        NuevoToolStripMenuItem1.Enabled = False
        EdicionToolStripMenuItem.Enabled = False
        GrabarToolStripMenuItem.Enabled = True
        TabMante.SelectedIndex = 1
        TxtMensaje.Text = "Nuevo"
    End Sub

    Private Sub EdicionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EdicionToolStripMenuItem.Click
        RaiseEvent MenuEditar()
        NuevoToolStripMenuItem1.Enabled = False
        EdicionToolStripMenuItem.Enabled = False
        GrabarToolStripMenuItem.Enabled = True
        TabMante.SelectedIndex = 1
        TxtMensaje.Text = "Modificacion"
    End Sub

    Private Sub GrabarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrabarToolStripMenuItem.Click
        RaiseEvent MenuGrabar()
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem.Click
        RaiseEvent MenuEliminar()
    End Sub

    Private Sub WordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WordToolStripMenuItem.Click
        Dim MsWord As New Word.Application
        Dim Documento As New Word.Document
        Dim myTable As System.Data.DataTable
        Dim fila, Columna, numcol As Integer
        'Dim x As Integer  Tepsa 
        Dim Titulo, Detalle, Variable As String
        myTable = CType(DataGridLista.DataSource, System.Data.DataTable) 'obtengo la estructura del datagrid 
        numcol = myTable.Columns.Count
        Documento = MsWord.Documents.Add
        Titulo = ""
        Detalle = ""
        For Columna = 0 To myTable.Columns.Count - 1 ' numero de columnas 
            Titulo = Titulo & myTable.Columns(Columna).ColumnName & vbTab
        Next
        Documento.Range.InsertAfter(Titulo)
        Documento.Range.InsertParagraphAfter()
        For fila = 0 To myTable.Rows.Count - 1 ' numero de filas 
            For Columna = 0 To myTable.Columns.Count - 1 ' numero de columnas 
                If IsNumeric(DataGridLista.Item(fila, Columna).ToString) Then
                    Variable = Convert.ToString(DataGridLista.Item(fila, Columna))
                ElseIf IsNumeric(DataGridLista.Item(fila, Columna).ToString) Then
                    Variable = Convert.ToString(DataGridLista.Item(fila, Columna))
                ElseIf IsDate(DataGridLista.Item(fila, Columna).ToString) Then
                    Variable = Convert.ToString(Microsoft.VisualBasic.Format(DataGridLista.Item(fila, Columna), "Short Date")) ' convierte la fecha en formato 22/11/77 
                ElseIf IsDBNull(DataGridLista.Item(fila, Columna).ToString) Then
                    Variable = ""
                Else
                    Variable = Convert.ToString(DataGridLista.Item(fila, Columna))
                End If
                Detalle = Detalle & Variable & vbTab
            Next
            Documento.Range.InsertAfter(Detalle)
            Detalle = ""
            Documento.Range.InsertParagraphAfter()
        Next
        Dim selRange As Word.Range
        selRange = Documento.Paragraphs.Item(1).Range
        selRange.Font.Size = 14
        selRange.Font.Bold = True
        'selRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
        Dim fName As String
        Dim SaveFileDialog1 = New SaveFileDialog
        SaveFileDialog1.Filter = "Documents|*.doc"
        SaveFileDialog1.ShowDialog()
        fName = SaveFileDialog1.FileName
        If fName <> "" Then
            Try
                Documento.SaveAs(fName)
            Catch exc As Exception
                MessageBox.Show("Failed to save document" & exc.Message)
            End Try
        End If
        MessageBox.Show("El Documento contiene " & Convert.ToString(Documento.Paragraphs.Count) & " Linea(s)")
        'MsgBox("The document contains " & doc.Paragraphs.Count & " paragraphs " & vbCrLf & _
        'doc.Words.Count & " words and " & doc.Characters.Count & " words")
        'Closing the document. 
        Documento.Close(Word.WdSaveOptions.wdDoNotSaveChanges)
        RaiseEvent MenuExWord()
    End Sub

    Private Sub ExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelToolStripMenuItem.Click
        Dim xlApp As New Excel.Application
        Dim xlBook As Excel.Workbook
        Dim xlSheet As Excel.Worksheet
        Dim variable As String
        Dim fila, Columna, numcol, x As Integer
        Dim myTable As System.Data.DataTable
        Dim FilaExcel As Integer = 2
        xlBook = CType(xlApp.Workbooks.Add, Excel.Workbook)
        xlSheet = CType(xlBook.Worksheets(1), Excel.Worksheet)
        Try
            Me.Cursor = Cursors.WaitCursor
            myTable = CType(DataGridLista.DataSource, System.Data.DataTable) 'obtengo la estructura del datagrid 
            numcol = myTable.Columns.Count
            For x = 1 To numcol
                xlSheet.Cells(1, x).Font.Bold = True
                xlSheet.Cells(1, x).Font.Size = 11
                xlSheet.Cells(1, x).Font.Name = "Arial"
            Next
            For fila = 0 To myTable.Rows.Count - 1 ' numero de filas 
                For Columna = 0 To myTable.Columns.Count - 1 ' numero de columnas 
                    xlSheet.Cells(1, Columna + 1).value = myTable.Columns(Columna).ColumnName
                    If IsNumeric(DataGridLista.Item(fila, Columna).ToString) Then
                        variable = Convert.ToString(DataGridLista.Item(fila, Columna))
                    ElseIf IsNumeric(DataGridLista.Item(fila, Columna).ToString) Then
                        variable = Convert.ToString(DataGridLista.Item(fila, Columna))
                    ElseIf IsDate(DataGridLista.Item(fila, Columna).ToString) Then
                        variable = Convert.ToString(Microsoft.VisualBasic.Format(DataGridLista.Item(fila, Columna), "Short Date")) ' convierte la fecha en formato 22/11/77 
                    ElseIf IsDBNull(DataGridLista.Item(fila, Columna).ToString) Then
                        variable = ""
                    Else
                        variable = Convert.ToString(DataGridLista.Item(fila, Columna))
                    End If
                    xlSheet.Cells(FilaExcel, Columna + 1).value = variable
                Next
                FilaExcel += 1
            Next
            xlSheet.Columns.AutoFit()
            'Se exporta la hoja Excel cargada en el objeto oExcel a un archivo .XLS 
            Dim SaveDialog = New SaveFileDialog
            SaveDialog.DefaultExt = "*.xls"
            SaveDialog.Filter = "(*.xls)|*.xls"
            If SaveDialog.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Try
                    xlSheet.SaveAs(SaveDialog.FileName)
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("Documento Guardado Como : " & SaveDialog.FileName, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    xlBook.Close()
                    xlApp.Quit()
                    xlApp = Nothing
                Catch ex As Exception
                    MessageBox.Show("No se Puede Procesar, El Archivo puede que se encuentre abierto, Verifique")
                End Try
            End If
        Catch ex As System.NullReferenceException
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
        'RaiseEvent MenuExExcel()
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
        Me.Close()
    End Sub


    Private Sub TabDatos_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabDatos.Paint, TabLista.Paint, TabPage1.Paint, TabPage2.Paint, TabPage3.Paint, TabPage4.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#507EAF"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub



    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#507EAF"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        SelectMenu(0)
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Dim filarow As Integer
        filarow = DataGridLista.CurrentRowIndex
        If filarow >= 0 Then
            SelectMenu(1)
        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        SelectMenu(2)
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        SelectMenu(3)
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        SelectMenu(4)
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        SelectMenu(5)
    End Sub

    Private Sub MenuTab_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MenuTab.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), New System.Drawing.Point(965, 55))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#507EAF"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Public Sub SelectMenu(ByVal ItemMenu As Integer)
        Dim ItemsTotal As Integer = MenuTab.Items.Count() - 1
        For i As Integer = 0 To ItemsTotal
            MenuTab.Items(i).BackColor = Color.Transparent
        Next
        MenuTab.Items(ItemMenu).BackColor = System.Drawing.SystemColors.Info
        TabMante.SelectedIndex = ItemMenu
    End Sub
    Public Sub SelectMenu2(ByVal ItemMenu As Integer)
        Dim ItemsTotal As Integer = MenuTab.Items.Count() - 1
        For i As Integer = 0 To ItemsTotal
            MenuTab.Items(i).BackColor = Color.Transparent
        Next
        MenuTab.Items(ItemMenu).BackColor = System.Drawing.SystemColors.Info
    End Sub

    Private Sub FrmPlantilla_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'PicBusca.Image = Image.FromFile("E:\TEMPLATE\TEMPLATE\icon\home_24.ico")
        DataGridLista.AlternatingBackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
        DataGridLista.BackgroundColor = SystemColors.Window
        NuevoToolStripMenuItem1.Enabled = True
        EdicionToolStripMenuItem.Enabled = True
        GrabarToolStripMenuItem.Enabled = False
        CancelarToolStripMenuItem7.Visible = False
        SelectMenu(0)
    End Sub

    Private Sub DataGridLista_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridLista.MouseUp
        Dim pt As New System.Drawing.Point(e.X, e.Y)
        Dim hti As DataGrid.HitTestInfo = DataGridLista.HitTest(pt)
        If hti.Type = DataGrid.HitTestType.Cell Then
            DataGridLista.CurrentCell = New DataGridCell(hti.Row, hti.Column)
            DataGridLista.Select(hti.Row)
        End If
    End Sub

    Private Sub TabMante_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabMante.Selecting
        Select Case e.TabPageIndex
            Case 1
                NuevoToolStripMenuItem1.Enabled = False
                EdicionToolStripMenuItem.Enabled = False
                GrabarToolStripMenuItem.Enabled = True
                CancelarToolStripMenuItem7.Visible = True
                CancelarToolStripMenuItem7.Enabled = True
                ExportarToolStripMenuItem.Enabled = False
                AyudaToolStripMenuItem1.Enabled = False
                SalirToolStripMenuItem.Enabled = False
                EliminarToolStripMenuItem.Enabled = False
                ImprimirToolStripMenuItem.Enabled = False
            Case 2
                RaiseEvent MenuMasivo()
                NuevoToolStripMenuItem1.Enabled = False
                EdicionToolStripMenuItem.Enabled = False
                GrabarToolStripMenuItem.Enabled = True
                CancelarToolStripMenuItem7.Visible = True
                ExportarToolStripMenuItem.Enabled = False
                AyudaToolStripMenuItem1.Enabled = False
                SalirToolStripMenuItem.Enabled = False
                EliminarToolStripMenuItem.Enabled = False
                ImprimirToolStripMenuItem.Enabled = False
            Case Else
                NuevoToolStripMenuItem1.Enabled = True
                EdicionToolStripMenuItem.Enabled = True
                GrabarToolStripMenuItem.Enabled = False
                CancelarToolStripMenuItem7.Visible = False
                ExportarToolStripMenuItem.Enabled = True
                AyudaToolStripMenuItem1.Enabled = True
                SalirToolStripMenuItem.Enabled = True
                EliminarToolStripMenuItem.Enabled = True
                ImprimirToolStripMenuItem.Enabled = True
        End Select
        SelectMenu2(e.TabPageIndex)
    End Sub





    Private Sub CancelarToolStripMenuItem7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelarToolStripMenuItem7.Click
        RaiseEvent MenuCancelar()
        SelectMenu(0)
    End Sub



End Class