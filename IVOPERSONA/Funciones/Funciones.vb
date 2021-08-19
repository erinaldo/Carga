'Imports Excel
'Imports Word

'Imports System.Data
'Imports System.Data.OleDb
Imports System.IO
Imports AccesoDatos
Imports System.Data.OracleClient
Imports INTEGRACION_AD
''' <summary>
''' En este Modulo se encuentran todas las funciones que se emplearan anivel del Proyecto.
''' </summary>
''' <remarks></remarks>
Module Funciones
    Private iOracle_Cmd As New OracleCommand
#Region " FUNCION PARA EXPORTAR A MICROSOFT WORD "
    ''' <summary>
    ''' Escribe un documento en Microsoft Word a partir de un DatagridView
    ''' </summary>
    ''' <param name="DataGridLista"></param>
    ''' <remarks></remarks>
    Public Sub ExportarWord(ByVal DataGridLista As DataGridView)
        'Para la exportacion en Word.
        Dim MsWord As New Word.Application
        Dim Documento As New Word.Document
        Dim myTable As System.Data.DataTable
        Dim fila, Columna, numcol As Integer
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
        '
    End Sub
#End Region

#Region " FUNCION PARA EXPORTAR A MICROSOFT EXCEL "
    ''' <summary>
    ''' Escribe un documento en Microsoft Excel a partir de un DatagridView
    ''' </summary>
    ''' <param name="DataGridLista"></param>
    ''' <remarks></remarks>
    '''
    'Public Function ExportarExcel_tmp2009_eliminarlo() As Boolean
    '    Dim cur_datos As New ADODB.Recordset
    '    Dim cur_FileName As New ADODB.Recordset
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOPERSONA.sp_get_cliente_x_funcionario", 2}
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        cur_FileName = cur_datos.NextRecordset
    '        If cur_FileName.BOF = False And cur_FileName.EOF = False Then
    '            Dim fs As FileStream
    '            Dim strFile As String
    '            fs = File.Open("..\" & cur_FileName.Fields.Item("NOMBRE_FILE").Value.ToString() & "_ENTREGA.txt", FileMode.Create, FileAccess.Write)
    '            Dim s As New StreamWriter(fs)
    '            s.WriteLine("Funcionario,Cliente,Razón Social")
    '            While cur_datos.BOF = False And cur_datos.EOF = False
    '                s.WriteLine(cur_datos.Fields.Item("Datos").Value.ToString())
    '                cur_datos.MoveNext()
    '            End While
    '            s.Flush()
    '            fs.Flush()
    '            s.Close()
    '            fs.Close()
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Seguridad Sistema")
    '    End Try
    'End Function
    Public Sub ExportarExcel(ByVal MyForm As Form, ByVal DataGridLista As DataGridView)
        'Codigo para Exportar a Ecxel
        Dim xlApp As New Excel.Application
        Dim xlBook As Excel.Workbook
        Dim xlSheet As Excel.Worksheet
        Dim variable As String
        Dim fila, Columna, numcol, x As Integer
        Dim myTable As New System.Data.DataTable
        Dim FilaExcel As Integer = 2
        xlBook = CType(xlApp.Workbooks.Add, Excel.Workbook)
        xlSheet = CType(xlBook.Worksheets(1), Excel.Worksheet)
        Try
            MyForm.Cursor = Cursors.WaitCursor
            'myTable = CType(DataGridLista.DataSource, System.Data.DataTable) 'obtengo la estructura del datagrid 
            myTable = CType(CType(DataGridLista.DataSource, System.Data.DataView).Table, System.Data.DataTable) 'Modificado 
            numcol = myTable.Columns.Count
            For x = 1 To numcol
                xlSheet.Cells(1, x).Font.Bold = True
                xlSheet.Cells(1, x).Font.Size = 11
                xlSheet.Cells(1, x).Font.Name = "Arial"
            Next
            For fila = 0 To myTable.Rows.Count - 1 ' numero de filas 
                Try
                    For Columna = 0 To myTable.Columns.Count - 1 ' numero de columnas 

                        xlSheet.Cells(1, Columna + 1).value = myTable.Columns(Columna).ColumnName
                        'If IsNumeric(DataGridLista.Item(fila, Columna).ToString) Then
                        If IsNumeric(DataGridLista.Item(fila, Columna).Value) Then
                            'variable = Convert.ToString(DataGridLista.Item(fila, Columna))
                            variable = CType(DataGridLista.Item(fila, Columna).Value, String)
                            'ElseIf IsNumeric(DataGridLista.Item(fila, Columna).ToString) Then
                        ElseIf IsNumeric(DataGridLista.Item(fila, Columna).Value) Then
                            'variable = Convert.ToString(DataGridLista.Item(fila, Columna))
                            variable = CType(DataGridLista.Item(fila, Columna).Value, String)
                        ElseIf IsDate(DataGridLista.Item(fila, Columna).ToString) Then
                            variable = Convert.ToString(Microsoft.VisualBasic.Format(DataGridLista.Item(fila, Columna), "Short Date")) ' convierte la fecha en formato 22/11/77 
                            'ElseIf IsDBNull(DataGridLista.Item(fila, Columna).ToString) Then
                        ElseIf IsDBNull(DataGridLista.Item(fila, Columna).Value) Then
                            variable = " "
                        Else
                            'variable = Convert.ToString(DataGridLista.Item(fila, Columna))
                            variable = CType(DataGridLista.Item(fila, Columna).Value, String)
                        End If
                        xlSheet.Cells(FilaExcel, Columna + 1).value = variable

                    Next
                    FilaExcel += 1
                Catch ex As Exception
                    Exit For
                End Try
            Next
            xlSheet.Columns.AutoFit()
            'Se exporta la hoja Excel cargada en el objeto oExcel a un archivo .XLS 
            Dim SaveDialog = New SaveFileDialog
            SaveDialog.DefaultExt = "*.xls"
            SaveDialog.Filter = "(*.xls)|*.xls"
            If SaveDialog.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Try
                    xlSheet.SaveAs(SaveDialog.FileName)
                    MyForm.Cursor = Cursors.Default
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
            MyForm.Cursor = Cursors.Default
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
            MyForm.Cursor = Cursors.Default
            Exit Sub
        End Try
        '
    End Sub
#End Region

#Region " FUNCION PARA DESHABILITAR LOS TABPAGE NO NOMBRADOS EN UN FORMULARIO "
    ''' <summary>
    ''' Esta Funcion deshabilita los MenuTabPage que no se le asigna su nombre, 
    ''' siempre debe ser invocada despues llenar la propiedas Text del
    ''' MenuStrip (MenuTabPage)
    ''' </summary>
    ''' <param name="MyMenuTab"></param>
    ''' <remarks></remarks>
    Public Sub HabilitarMenu(ByVal MyMenuTab As MenuStrip)
        Dim ItemsTotal As Integer = MyMenuTab.Items.Count() - 1
        For i As Integer = 0 To ItemsTotal
            If MyMenuTab.Items(i).Text = " " Then
                MyMenuTab.Items(i).Visible = False
            End If
        Next
    End Sub
#End Region

#Region " FUNCIONES PARA LA CARGA DE COMBOS Y TREEVIEW "

    'Public Function CargarCombo(ByVal StoredProcedure As String, ByVal Combo As ComboBox) As System.Data.DataTable
    'Dim da As New OleDbDataAdapter
    'Dim dt As New System.Data.DataTable
    'Dim dv As New DataView
    'Try
    '    Dim objdtoA As Object() = {StoredProcedure, 0}
    '    da.Fill(dt, VOCONTROLUSUARIO.fnSQLQuery(objdtoA))
    '    For i As Integer = 0 To dt.Rows.Count - 1
    '        Combo.Items.Add(dt.Rows(i)(1))
    '    Next
    'Catch Qex As Exception
    '    MessageBox.Show(Qex.Message, "Control del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    'End Try
    'Return dt
    'End Function

    Public Sub CargarCombo(ByVal Mydt As System.Data.DataTable, ByVal Combo As ComboBox, Optional ByVal ItemSeleccion As Integer = -1)
        'Dim da As New OleDbDataAdapter
        Dim dt As New System.Data.DataTable
        Dim dv As New DataView
        dt = Mydt
        Try
            For i As Integer = 0 To dt.Rows.Count - 1
                Combo.Items.Add(dt.Rows(i)(1))
            Next
            If ItemSeleccion <> -1 Then
                Combo.SelectedIndex = ItemSeleccion
            End If
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Control del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    ''' <summary>
    ''' MyDataTableA es el Contenedor de los Nodos Primarios (Column1,Column2,Column3...),
    ''' ColumnaA es el indice de la Columna que queremos que se llene al TreeView,
    ''' DataTableB es el Contenedor de los Nodos Secundarios (Column1,Column2,Column3...),
    ''' ColumnaAFiltro es la columna por la que filtraremos a ColumnaBFiltro,
    ''' ColumnaB es el indice de la columna de MyDataTableA por el que queremos filtrar a
    ''' la ColumnaBFiltro DataTableB. 
    ''' </summary>
    ''' <param name="MyDataTableA"></param>
    ''' <param name="ColumnaA"></param>
    ''' <param name="MyDataTableB"></param>
    ''' <param name="ColumnaAFiltro"></param>
    ''' <param name="ColumnaBFiltro"></param>
    ''' <param name="cTree"></param>
    ''' <remarks></remarks>
    Public Sub LlenarTreeView(ByVal MyDataTableA As System.Data.DataTable, ByVal ColumnaA As Integer, ByVal MyDataTableB As System.Data.DataTable, ByVal ColumnaAFiltro As Integer, ByVal ColumnaBFiltro As String, ByVal cTree As TreeView)
        Try
            cTree.Nodes.Clear()
            cTree.CheckBoxes = True

            For i As Integer = 0 To MyDataTableA.Rows.Count - 1
                'Llenamos los Nodos Primarios
                cTree.Nodes.Add(MyDataTableA.Rows(i)(ColumnaA).ToString)
                cTree.Nodes(i).NodeFont = New Font("Arial", 8, FontStyle.Bold)

                'Este proceso filtra los valores para ser agregados a cada nodo Primario.
                Dim MyDataView As New DataView
                Dim dr As DataRowView
                MyDataView = MyDataTableB.DefaultView
                Dim MyFiltro As String = ""
                Dim MyValor As Integer = MyDataTableA.Rows(i)(ColumnaAFiltro)
                MyFiltro = ColumnaBFiltro & "= '" & MyValor & "'"
                MyDataView.RowFilter = MyFiltro
                For j As Integer = 0 To MyDataView.Count - 1
                    dr = MyDataView.Item(j)
                    'cTree.Nodes(i).Nodes.Add(dr("DEPARTAMENTO"))
                    cTree.Nodes(i).Nodes.Add(dr("NOMBRE USUARIO"))
                    cTree.Nodes(i).Nodes(j).NodeFont = New Font("Arial", 8, FontStyle.Regular)
                Next
            Next

        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub LlenarTreeView(ByVal MyDataTableA As System.Data.DataTable, ByVal ColumnaA As Integer, ByVal cTree As TreeView, ByVal NombreNodoSuperior As String)
        Try
            cTree.Nodes.Clear()
            cTree.CheckBoxes = True
            'Llenamos los Nodos Primarios
            cTree.Nodes.Add(NombreNodoSuperior)
            For i As Integer = 0 To MyDataTableA.Rows.Count - 1
                cTree.Nodes(0).Nodes.Add(MyDataTableA.Rows(i)(ColumnaA).ToString)
                cTree.Nodes(0).Nodes(i).Tag = MyDataTableA.Rows(i)("ID").ToString 'Tepsa 
                cTree.Nodes(0).Nodes(i).NodeFont = New Font("Arial", 8, FontStyle.Regular)
            Next
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region " FUNCION PARA ESTABLECER LOS TABINDEX POR SELECCION DE TIPO PERSONA "
    ''' <summary>
    ''' Muestra Los campos necesarios para en Ingreso de Persona Natural
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EstableceTabIndexNatural(ByVal GroupBoxDatosPersonales As System.Windows.Forms.GroupBox, ByVal txtNombreP As TextBox, ByVal txtNombreS As TextBox, ByVal txtApellidoP As TextBox, ByVal txtApellidoM As TextBox, ByVal cmbTipoDocIdent As ComboBox, ByVal txtNumeroDocto As TextBox, _
                                     ByVal txtFechaNacimiento As ControlsTepsa.DataPickerMasked, ByVal txtCorreoElectronico As TextBox, ByVal btnTipoDocumentoCliente As Button, ByVal lblNombreP As Label, ByVal lblNombreS As Label, ByVal lblApellidoP As Label, _
                                     ByVal lblApellidoM As Label, ByVal lblDocumentotoIdentidad As Label, ByVal lblFechaNacimiento As Label, ByVal lblEmail As Label, ByVal txtRazonSocial As TextBox, ByVal txtRUC As TextBox, ByVal txtGG As TextBox, ByVal txtRepLegal As TextBox, _
                                     ByVal txtWebSite As TextBox, ByVal lblRazonSocial As Label, ByVal lblRUC As Label, ByVal lblGG As Label, ByVal lblRepLegal As Label, ByVal lblEBusiness As Label, ByVal lblSexo As Label, ByVal rdbSexoMasCliente As RadioButton, ByVal rdbSexoFemCliente As RadioButton)

        GroupBoxDatosPersonales.SendToBack()
        'Campos Individuales
        txtNombreP.Visible = True
        txtNombreS.Visible = True
        txtApellidoP.Visible = True
        txtApellidoM.Visible = True
        cmbTipoDocIdent.Visible = True
        txtNumeroDocto.Visible = True
        txtFechaNacimiento.Visible = True
        txtCorreoElectronico.Visible = True
        btnTipoDocumentoCliente.Visible = True

        lblNombreP.Visible = True
        lblNombreS.Visible = True
        lblApellidoP.Visible = True
        lblApellidoM.Visible = True
        lblDocumentotoIdentidad.Visible = True
        lblFechaNacimiento.Visible = True
        lblEmail.Visible = True
        lblSexo.Visible = True
        rdbSexoFemCliente.Visible = True
        rdbSexoMasCliente.Visible = True

        'Deshabilitar en Juridica
        txtRazonSocial.Visible = False
        txtRUC.Visible = False
        txtGG.Visible = False
        txtRepLegal.Visible = False
        txtWebSite.Visible = False

        lblRazonSocial.Visible = False
        lblRUC.Visible = False
        lblGG.Visible = False
        lblRepLegal.Visible = False
        lblEBusiness.Visible = False
    End Sub

    ''' <summary>
    ''' Muestra Los campos necesarios para en Ingreso de Persona Juridica
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EstableceTabIndexJuridica(ByVal GroupBoxDatosPersonales As System.Windows.Forms.GroupBox, ByVal txtNombreP As TextBox, ByVal txtNombreS As TextBox, ByVal txtApellidoP As TextBox, ByVal txtApellidoM As TextBox, ByVal cmbTipoDocIdent As ComboBox, ByVal txtNumeroDocto As TextBox, _
                                         ByVal txtFechaNacimiento As ControlsTepsa.DataPickerMasked, ByVal txtCorreoElectronico As TextBox, ByVal btnTipoDocumentoCliente As Button, ByVal lblNombreP As Label, ByVal lblNombreS As Label, ByVal lblApellidoP As Label, _
                                         ByVal lblApellidoM As Label, ByVal lblDocumentotoIdentidad As Label, ByVal lblFechaNacimiento As Label, ByVal lblEmail As Label, ByVal txtRazonSocial As TextBox, ByVal txtRUC As TextBox, ByVal txtGG As TextBox, ByVal txtRepLegal As TextBox, _
                                         ByVal txtWebSite As TextBox, ByVal lblRazonSocial As Label, ByVal lblRUC As Label, ByVal lblGG As Label, ByVal lblRepLegal As Label, ByVal lblEBusiness As Label, ByVal lblSexo As Label, ByVal rdbSexoMasCliente As RadioButton, ByVal rdbSexoFemCliente As RadioButton)

        GroupBoxDatosPersonales.SendToBack()
        'Campos Individuales
        txtNombreP.Visible = False
        txtNombreS.Visible = False
        txtApellidoP.Visible = False
        txtApellidoM.Visible = False
        cmbTipoDocIdent.Visible = False
        txtNumeroDocto.Visible = False
        txtFechaNacimiento.Visible = False
        txtCorreoElectronico.Visible = False
        btnTipoDocumentoCliente.Visible = False

        lblNombreP.Visible = False
        lblNombreS.Visible = False
        lblApellidoP.Visible = False
        lblApellidoM.Visible = False
        lblDocumentotoIdentidad.Visible = False
        lblFechaNacimiento.Visible = False
        lblEmail.Visible = False
        lblSexo.Visible = False
        rdbSexoFemCliente.Visible = False
        rdbSexoMasCliente.Visible = False

        'Habilitar en Juridica
        txtRazonSocial.Visible = True
        txtRUC.Visible = True
        txtGG.Visible = True
        txtRepLegal.Visible = True
        txtWebSite.Visible = True

        lblRazonSocial.Visible = True
        lblRUC.Visible = True
        lblGG.Visible = True
        lblRepLegal.Visible = True
        lblEBusiness.Visible = True
    End Sub
#End Region

#Region " FUNCION PARA ESTABLECER TAMAÑOS EN LOS GROUPBOX "
    Public Sub TamanoGroupBox(ByVal ParamArray MyGroupControls() As Object)
        For i As Integer = 0 To UBound(MyGroupControls)
            CType(MyGroupControls(i), GroupBox).Width = 497
        Next
    End Sub
#End Region

#Region " FUNCIONES PARA VALIDACION DE CAMPOS "
    ''' <summary>
    ''' Esta funcion permite las validaciona de campos de un Form, ojo que si  tenemos un 
    ''' TextBox con un Button para busquedas, en la declaracion del Object debemos de 
    ''' declararlas en forma consecutiva. 
    ''' Ademas valida solo TextBox simples, TextBox con Button de Busquedas, ComboBox y
    ''' DataPickerMasked.
    ''' </summary>
    ''' <param name="MyObligatorios"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Validaciones(ByVal MyObligatorios As Object) As Integer
        'Dim Resp As Integer = 0
        'Static MyError As New ErrorProvider
        'For i As Integer = 0 To UBound(MyObligatorios)
        '    If Len(Trim(CType(MyObligatorios(i), TextBox).Text)) = 0 Then
        '        MyError.SetError(CType(MyObligatorios(i), TextBox), "Campo Obligatorio")
        '        Resp = 1
        '    Else
        '        MyError.SetError(CType(MyObligatorios(i), TextBox), "")
        '    End If
        'Next
        'Return Resp

        Dim Resp As Integer = 0
        Static MyError As New ErrorProvider
        For i As Integer = 0 To UBound(MyObligatorios)
            'Si la validacion sera en un TextBox con un Button
            If TypeOf MyObligatorios(i) Is Button Then
                If TypeOf MyObligatorios(i - 1) Is TextBox Then
                    If Len(Trim(CType(MyObligatorios(i - 1), TextBox).Text)) = 0 Then
                        MyError.SetError(CType(MyObligatorios(i), Button), "Campo Obligatorio para Guardar el Registro")
                        MyError.SetError(CType(MyObligatorios(i - 1), TextBox), "")
                        Resp = 1
                    Else
                        MyError.SetError(CType(MyObligatorios(i), Button), "")
                    End If
                End If
            ElseIf TypeOf MyObligatorios(i) Is TextBox Then
                If Len(Trim(CType(MyObligatorios(i), TextBox).Text)) = 0 Then
                    MyError.SetError(CType(MyObligatorios(i), TextBox), "Campo Obligatorio para Guardar el Registro")
                    Resp = 1
                Else
                    MyError.SetError(CType(MyObligatorios(i), TextBox), "")
                End If
            End If

            'Si la validacion sera en un ComboBox
            If TypeOf MyObligatorios(i) Is ComboBox Then
                If Len(Trim(CType(MyObligatorios(i), ComboBox).Text)) = 0 Then
                    MyError.SetError(CType(MyObligatorios(i + 1), Button), "Campo Obligatorio para Guardar el Registro")
                    Resp = 1
                Else
                    MyError.SetError(CType(MyObligatorios(i + 1), Button), "")
                End If
            End If

            'Si la validacion es en un DataPickerMasked
            If TypeOf MyObligatorios(i) Is ControlsTepsa.DataPickerMasked Then
                If Len(Trim(CType(MyObligatorios(i), ControlsTepsa.DataPickerMasked).GetMyFecha)) = 0 Then
                    MyError.SetError(CType(MyObligatorios(i), ControlsTepsa.DataPickerMasked), "Campo Obligatorio para Guardar el Registro")
                    Resp = 1
                Else
                    MyError.SetError(CType(MyObligatorios(i), ControlsTepsa.DataPickerMasked), "")
                End If
            End If

            'Si la validacion sera en un Label como contenedor de dos RadioButton
            If i >= 3 Then
                If TypeOf MyObligatorios(i - 2) Is Label And TypeOf MyObligatorios(i - 1) Is RadioButton And TypeOf MyObligatorios(i) Is RadioButton Then
                    If CType(MyObligatorios(i - 1), RadioButton).Checked = False And CType(MyObligatorios(i), RadioButton).Checked = False Then
                        MyError.SetError(CType(MyObligatorios(i - 2), Label), "Campo Obligatorio para Guardar el Registro")
                        Resp = 1
                    Else
                        MyError.SetError(CType(MyObligatorios(i - 2), Label), "")
                    End If
                End If
            End If

            'Si la validacion sera en un DataGridView con filas, sino no.
            If TypeOf MyObligatorios(i) Is DataGridView Then
                If CType(MyObligatorios(i), DataGridView).RowCount <= 1 Then
                    MyError.SetError(CType(MyObligatorios(i), DataGridView), "Campo Obligatorio para Guardar el Registro")
                    Resp = 1
                Else
                    MyError.SetError(CType(MyObligatorios(i), DataGridView), "")
                End If
            End If

        Next
        Return Resp

    End Function
#End Region

#Region " FUNCIONES PARA ASIGNACION DE CHECKED DE TREEVIEW "
    ''' <summary>
    ''' Este procedimiento realiza el checked masivo de nodos hijo respecto al nodo
    ''' padre.
    ''' </summary>
    ''' <param name="node"></param>
    ''' <param name="check"></param>
    ''' <remarks></remarks>
    Public Sub ActualizarCheck(ByVal node As TreeNode, ByVal check As Boolean)
        ' actualizo los check de los nodos hijos, del nodo que se envío como parametro y a con el valor de parametro
        Dim n As TreeNode
        For Each n In node.Nodes
            n.Checked = check
            If n.Nodes.Count <> 0 Then
                ActualizarCheck(n, check)
            End If
        Next n
    End Sub
#End Region

#Region " FUNCIONES PARA VALIDAR SOLO NUMERICOS "
    Public Function SoloNumeros(ByVal Keyascii As Short) As Short
        If InStr("1234567890", Chr(Keyascii)) = 0 Then
            SoloNumeros = 0
        Else
            SoloNumeros = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumeros = Keyascii
            Case 13
                SoloNumeros = Keyascii
        End Select
    End Function
#End Region

#Region " FUNCION PARA LA CARGA GENERICA DE LOS TREEVIEWS CON DATA DE FUNCIONARIOS "

    ''' <summary>
    ''' Esta Funcion carga cualquier TreeView con todos los funcionarios Activos.
    ''' </summary>
    ''' <param name="MyTree"></param>
    ''' <remarks></remarks>
    Public Sub LlenaTreeFuncionarios(ByVal MyTree As TreeView)
        'Dim rstFuncionario As ADODB.Recordset
        Dim dtFuncionarios As New DataTable
        Try
            For i As Integer = 0 To MyTree.Nodes.Count - 1
                MyTree.Nodes(i).Remove()
            Next
            'datahelper
            'Dim Myobj As Object() = {"PKG_IVOPERSONA.SP_FUNCIONARIOS", 0}
            'rstFuncionario = VOCONTROLUSUARIO.fnSQLQuery(Myobj)
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_FUNCIONARIOS", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_FUNCIONARIOS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            dtFuncionarios = db.EjecutarDataTable

            'datahelper
            'Dim da As New OleDbDataAdapter
            'da.Fill(dtFuncionarios, rstFuncionario)
            LlenarTreeView(dtFuncionarios, 2, MyTree, "FUNCIONARIOS")
            MyTree.ExpandAll()

        Catch Qex As Excepcion
            'MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw New Exception(Qex.Excepcion)
        End Try
    End Sub

    Public Sub LlenaTreeSoloFuncionarios(ByVal l_idusuario_personal As Long, ByVal MyTree As TreeView)
        'Dim rstFuncionario As ADODB.Recordset
        Dim dtFuncionarios As New DataTable
        Dim NombreNodoSuperior As String
        Try
            For i As Integer = 0 To MyTree.Nodes.Count - 1
                MyTree.Nodes(i).Remove()
            Next

            'datahelper
            'Dim Myobj As Object() = {"PKG_IVOPERSONA.SP_FUNCIONARIO_NEGOCIO", 4, _
            'l_idusuario_personal, 1}
            'rstFuncionario = VOCONTROLUSUARIO.fnSQLQuery(Myobj)
            'Dim da As New OleDbDataAdapter
            'da.Fill(dtFuncionarios, rstFuncionario)

            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_FUNCIONARIO_NEGOCIO", CommandType.StoredProcedure)
            db.AsignarParametro("vi_idusuario_personal", l_idusuario_personal, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_FUNCIONARIOS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            dtFuncionarios = db.EjecutarDataTable

            LlenarTreeView(dtFuncionarios, 2, MyTree, "FUNCIONARIOS")
            MyTree.ExpandAll()
        Catch Qex As Excepcion
            'MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw New Exception(Qex.Excepcion)
        End Try
    End Sub
    Public Sub LlenaTreeFuncionariosPasajes(ByVal MyTree As TreeView)
        'Dim rstFuncionario As ADODB.Recordset
        Dim dtFuncionarios As New DataTable
        Try
            For i As Integer = 0 To MyTree.Nodes.Count - 1
                MyTree.Nodes(i).Remove()
            Next
            'datahelper
            'Dim Myobj As Object() = {"PKG_IVOPERSONA.SP_FUNCIONARIOS_PASAJES", 0}
            'rstFuncionario = VOCONTROLUSUARIO.fnSQLQuery(Myobj)
            'Dim da As New OleDbDataAdapter
            'da.Fill(dtFuncionarios, rstFuncionario)
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_FUNCIONARIOS_PASAJES", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_FUNCIONARIOS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            dtFuncionarios = db.EjecutarDataTable
            LlenarTreeView(dtFuncionarios, 2, MyTree, "FUNCIONARIOS")
            MyTree.ExpandAll()
        Catch Qex As Excepcion
            'MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw New Exception(Qex.Excepcion)
        End Try
    End Sub
#End Region

#Region " FUNCION PARA LA CARGA DE CLIENTES EN LA GRILLA "
    ' Ritcher 09/08/2007 
    Public Function CargarGrillaClientesPasajes(ByVal MyDataGridLista As DataGridView, ByVal MyFuncionario As String) As DataView
        Try
            'Dim rstListaClientes As ADODB.Recordset
            Dim dtListaClientes As New DataTable
            MyFuncionario = Replace(MyFuncionario, ",", " ")

            'datahelper
            'Dim Myobj As Object() = {"PKG_IVOPERSONA.SP_LISTA_CLIENTES_FUNCI_PASA", 4, MyFuncionario, 2}
            'rstListaClientes = VOCONTROLUSUARIO.fnSQLQuery(Myobj)
            'Dim da As New OleDbDataAdapter
            'da.Fill(dtListaClientes, rstListaClientes)
            'Dim MydvListaClientes As DataView
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CLIENTES_FUNCI_PASA", CommandType.StoredProcedure)
            db.AsignarParametro("iNOMBRE_FUNCIONARIO", MyFuncionario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_LISTA_CLIENTES", OracleClient.OracleType.Cursor)
            db.Desconectar()
            dtListaClientes = db.EjecutarDataTable
            Dim MydvListaClientes As DataView
            MydvListaClientes = dtListaClientes.DefaultView
            With MyDataGridLista
                '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .DataSource = MydvListaClientes
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .VirtualMode = True
                '.RowHeadersWidth = 30
                .RowHeadersVisible = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            Dim col0 As New DataGridViewCheckBoxColumn
            With col0
                .HeaderText = "¿ACTIVO?"
                .Name = "ACTIVO"
                .DataPropertyName = "IDESTADO_REGISTRO"
                .Width = 62
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .Frozen = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            'MyDataGridLista.Columns.Add(col0)

            Dim col1 As New DataGridViewTextBoxColumn
            With col1
                .HeaderText = "ID"
                .Name = "ID"
                .DataPropertyName = "IDPERSONA"
                .ReadOnly = True
                .ToolTipText = "Identificador del cliente en la Base de Datos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            End With
            'MyDataGridLista.Columns.Add(col1)

            Dim col2 As New DataGridViewTextBoxColumn
            With col2
                .HeaderText = "CODIGO"
                .Name = "CODIGO"
                .DataPropertyName = "CODIGO_CLIENTE"
                .ToolTipText = "Código del Cliente"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            End With
            'MyDataGridLista.Columns.Add(col2)

            Dim Col3 As New DataGridViewTextBoxColumn
            With Col3
                .HeaderText = "DOCT."
                .Name = "DOCUMENTO"
                .DataPropertyName = "NU_DOCU_SUNA"
                .ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            End With
            'MyDataGridLista.Columns.Add(Col3)

            Dim col4 As New DataGridViewTextBoxColumn
            With col4
                .HeaderText = "RAZON SOCIAL"
                .Name = "RAZONSOCIAL"
                .DataPropertyName = "RAZON_SOCIAL"
                .ToolTipText = "Razon Social para Personas Juridicos"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            'MyDataGridLista.Columns.Add(col4)

            Dim col5 As New DataGridViewTextBoxColumn
            With col5
                .HeaderText = "NOMBRE Y APELLIDOS"
                .Name = "NOMBREYAPELLIDO"
                .DataPropertyName = "NOMNRES_APELLIDOS"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            'MyDataGridLista.Columns.Add(col5)

            Dim col6 As New DataGridViewTextBoxColumn
            With col6
                .HeaderText = "TIPO PERSONA"
                .Name = "JURIDICAONATURAL"
                .DataPropertyName = "IDTIPO_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            'MyDataGridLista.Columns.Add(col6)

            Dim col7 As New DataGridViewCheckBoxColumn
            With col7
                .HeaderText = "CLIENTE CORPORATIVO"
                .Name = "CLIENTE_CORPORATIVO"
                .DataPropertyName = "CLIENTE_CORPORATIVO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col8 As New DataGridViewTextBoxColumn
            With col8
                .HeaderText = "GERENTE GENERAL"
                .Name = "GERENTE_GENERAL"
                .DataPropertyName = "GERENTE_GENERAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col9 As New DataGridViewTextBoxColumn
            With col9
                .HeaderText = "REPRESENTANTE LEGAL"
                .Name = "REPRESENTANTE_LEGAL"
                .DataPropertyName = "REPRESENTANTE_LEGAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col10 As New DataGridViewTextBoxColumn
            With col10
                .HeaderText = "FECHA INGRESO"
                .Name = "FECHA_INGRESO"
                .DataPropertyName = "FECHA_INGRESO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col11 As New DataGridViewCheckBoxColumn
            With col11
                .HeaderText = "PAGO POST FACTURACION"
                .Name = "PAGO_POST_FACTURACION"
                .DataPropertyName = "PAGO_POST_FACTURACION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col12 As New DataGridViewTextBoxColumn
            With col12
                .HeaderText = "EMAIL"
                .Name = "EMAIL"
                .DataPropertyName = "EMAIL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col13 As New DataGridViewTextBoxColumn
            With col13
                .HeaderText = "APELLIDO PATERNO"
                .Name = "APELLIDO_PATERNO"
                .DataPropertyName = "APELLIDO_PATERNO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col14 As New DataGridViewTextBoxColumn
            With col14
                .HeaderText = "APELLIDO MATERNO"
                .Name = "APELLIDO_MATERNO"
                .DataPropertyName = "APELLIDO_MATERNO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col15 As New DataGridViewTextBoxColumn
            With col15
                .HeaderText = "NOMPRE PERSONA"
                .Name = "NOMPRE_PERSONA"
                .DataPropertyName = "NOMPRE_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col16 As New DataGridViewTextBoxColumn
            With col16
                .HeaderText = "NOMPRE PERSONA1"
                .Name = "NOMPRE_PERSONA1"
                .DataPropertyName = "NOMPRE_PERSONA1"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col17 As New DataGridViewTextBoxColumn
            With col17
                .HeaderText = "FECHA NACIMIENTO"
                .Name = "FECHA_NACIMIENTO"
                .DataPropertyName = "FECHA_NACIMIENTO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col18 As New DataGridViewTextBoxColumn
            With col18
                .HeaderText = "SEXO PERSONA"
                .Name = "SEXO_PERSONA"
                .DataPropertyName = "SEXO_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col19 As New DataGridViewCheckBoxColumn
            With col19
                .HeaderText = "ESMENOREDAD"
                .Name = "ESMENOREDAD"
                .DataPropertyName = "ESMENOREDAD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col20 As New DataGridViewCheckBoxColumn
            With col20
                .HeaderText = "AGENTE RETENCION"
                .Name = "AGENTE_RETENCION"
                .DataPropertyName = "AGENTE_RETENCION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col21 As New DataGridViewTextBoxColumn
            With col21
                .HeaderText = "IDTIPO DOC IDENTIDAD"
                .Name = "IDTIPO_DOC_IDENTIDAD"
                .DataPropertyName = "IDTIPO_DOC_IDENTIDAD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col22 As New DataGridViewTextBoxColumn
            With col22
                .HeaderText = "NU RETE SUNA"
                .Name = "NU_RETE_SUNA"
                .DataPropertyName = "NU_RETE_SUNA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col23 As New DataGridViewTextBoxColumn
            With col23
                .HeaderText = "IDRUBRO"
                .Name = "IDRUBRO"
                .DataPropertyName = "IDRUBRO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col24 As New DataGridViewTextBoxColumn
            With col24
                .HeaderText = "IDCLASIFICACION PERSONA"
                .Name = "IDCLASIFICACION_PERSONA"
                .DataPropertyName = "IDCLASIFICACION_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col25 As New DataGridViewTextBoxColumn
            With col25
                .HeaderText = "IDUSUARIO PERSONAL"
                .Name = "IDUSUARIO_PERSONAL"
                .DataPropertyName = "IDUSUARIO_PERSONAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col26 As New DataGridViewTextBoxColumn
            With col26
                .HeaderText = "IDROL USUARIO"
                .Name = "IDROL_USUARIO"
                .DataPropertyName = "IDROL_USUARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col27 As New DataGridViewTextBoxColumn
            With col27
                .HeaderText = "IP"
                .Name = "IP"
                .DataPropertyName = "IP"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col28 As New DataGridViewTextBoxColumn
            With col28
                .HeaderText = "FECHA REGISTRO"
                .Name = "FECHA_REGISTRO"
                .DataPropertyName = "FECHA_REGISTRO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col29 As New DataGridViewTextBoxColumn
            With col29
                .HeaderText = "IDUSUARIO PERSONALMOD"
                .Name = "IDUSUARIO_PERSONALMOD"
                .DataPropertyName = "IDUSUARIO_PERSONALMOD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col30 As New DataGridViewTextBoxColumn
            With col30
                .HeaderText = "IDROL USUARIOMOD"
                .Name = "IDROL_USUARIOMOD"
                .DataPropertyName = "IDROL_USUARIOMOD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col31 As New DataGridViewTextBoxColumn
            With col31
                .HeaderText = "IPMOD"
                .Name = "IPMOD"
                .DataPropertyName = "IPMOD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col32 As New DataGridViewTextBoxColumn
            With col32
                .HeaderText = "FECHA_ACTUALIZACION"
                .Name = "FECHA_ACTUALIZACION"
                .DataPropertyName = "FECHA_ACTUALIZACION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col33 As New DataGridViewTextBoxColumn
            With col33
                .HeaderText = "IDPAIS"
                .Name = "IDPAIS"
                .DataPropertyName = "IDPAIS"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col34 As New DataGridViewTextBoxColumn
            With col34
                .HeaderText = "IDDEPARTAMENTO"
                .Name = "IDDEPARTAMENTO"
                .DataPropertyName = "IDDEPARTAMENTO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col35 As New DataGridViewTextBoxColumn
            With col35
                .HeaderText = "IDPROVINCIA"
                .Name = "IDPROVINCIA"
                .DataPropertyName = "IDPROVINCIA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col36 As New DataGridViewTextBoxColumn
            With col36
                .HeaderText = "IDDISTRITO"
                .Name = "IDDISTRITO"
                .DataPropertyName = "IDDISTRITO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col37 As New DataGridViewTextBoxColumn
            With col37
                .HeaderText = "USUARIO"
                .Name = "USUARIO"
                .DataPropertyName = "USUARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            Dim col38 As New DataGridViewTextBoxColumn
            With col38
                .HeaderText = "ROL USUARIO"
                .Name = "ROL_USUARIO"
                .DataPropertyName = "ROL_USUARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col39 As New DataGridViewTextBoxColumn
            With col39
                .HeaderText = "IDFUNCIONARIO ACTUAL"
                .Name = "IDFUNCIONARIO_ACTUAL"
                .DataPropertyName = "IDFUNCIONARIO_ACTUAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col40 As New DataGridViewTextBoxColumn
            With col40
                .HeaderText = "FUNCIONARIO"
                .Name = "FUNCIONARIO"
                .DataPropertyName = "FUNCIONARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col41 As New DataGridViewTextBoxColumn
            With col41
                .HeaderText = "IDTIPO_FACTURACION"
                .Name = "IDTIPO_FACTURACION"
                .DataPropertyName = "IDTIPO_FACTURACION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            '
            Dim col42 As New DataGridViewTextBoxColumn
            With col42
                .HeaderText = "Tipo Crédito"
                .Name = "TIPO_CREDITO"
                .DataPropertyName = "TIPO_CREDITO"
                .ToolTipText = "Tipo Crédito"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            '
            MyDataGridLista.Columns.AddRange(col0, col1, col2, Col3, col4, col5, col6, col7, col8, col9, col10, col11, col12, col13, col14, col15, col16, col17, col18, col19, col20, col21, col22, col23, col24, col25, col26, col27, col28, col29, col30, col31, col32, col33, col34, col35, col36, col37, col38, col39, col40, col41, col42)
            '
            For i As Integer = 0 To 42
                MyDataGridLista.Columns(i).Visible = False
            Next
            '
            MyDataGridLista.Columns(0).Visible = True
            MyDataGridLista.Columns(2).Visible = True
            MyDataGridLista.Columns(4).Visible = True
            MyDataGridLista.Columns(5).Visible = True
            '
            Return MydvListaClientes
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function CargarGrillaClientesPasajes(ByVal MyDataGridLista As DataGridView) As DataView
        Try
            'Dim rstListaClientes As ADODB.Recordset
            Dim dtListaClientes As New DataTable

            'datahelper
            'Dim Myobj As Object() = {"PKG_IVOPERSONA.SP_LISTA_CLIENTES_PASA", 0}
            'rstListaClientes = VOCONTROLUSUARIO.fnSQLQuery(Myobj)
            'Dim da As New OleDbDataAdapter
            'da.Fill(dtListaClientes, rstListaClientes)
            'Dim MydvListaClientes As DataView
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CLIENTES_PASA", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_LISTA_CLIENTES", OracleClient.OracleType.Cursor)
            db.Desconectar()
            dtListaClientes = db.EjecutarDataTable
            Dim MydvListaClientes As DataView

            MydvListaClientes = dtListaClientes.DefaultView
            With MyDataGridLista
                '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .DataSource = MydvListaClientes
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .VirtualMode = True
                '.RowHeadersWidth = 30
                .RowHeadersVisible = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            Dim col0 As New DataGridViewCheckBoxColumn
            With col0
                .HeaderText = "¿ACTIVO?"
                .Name = "ACTIVO"
                .DataPropertyName = "IDESTADO_REGISTRO"
                .Width = 62
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .Frozen = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            'MyDataGridLista.Columns.Add(col0)

            Dim col1 As New DataGridViewTextBoxColumn
            With col1
                .HeaderText = "ID"
                .Name = "ID"
                .DataPropertyName = "IDPERSONA"
                .ReadOnly = True
                .ToolTipText = "Identificador del cliente en la Base de Datos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            End With
            'MyDataGridLista.Columns.Add(col1)

            Dim col2 As New DataGridViewTextBoxColumn
            With col2
                .HeaderText = "CODIGO"
                .Name = "CODIGO"
                .DataPropertyName = "CODIGO_CLIENTE"
                .ToolTipText = "Código del Cliente"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            End With
            'MyDataGridLista.Columns.Add(col2)

            Dim Col3 As New DataGridViewTextBoxColumn
            With Col3
                .HeaderText = "DOCT."
                .Name = "DOCUMENTO"
                .DataPropertyName = "NU_DOCU_SUNA"
                .ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            End With
            'MyDataGridLista.Columns.Add(Col3)

            Dim col4 As New DataGridViewTextBoxColumn
            With col4
                .HeaderText = "RAZON SOCIAL"
                .Name = "RAZONSOCIAL"
                .DataPropertyName = "RAZON_SOCIAL"
                .ToolTipText = "Razon Social para Personas Juridicos"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            'MyDataGridLista.Columns.Add(col4)

            Dim col5 As New DataGridViewTextBoxColumn
            With col5
                .HeaderText = "NOMBRE Y APELLIDOS"
                .Name = "NOMBREYAPELLIDO"
                .DataPropertyName = "NOMNRES_APELLIDOS"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            'MyDataGridLista.Columns.Add(col5)

            Dim col6 As New DataGridViewTextBoxColumn
            With col6
                .HeaderText = "TIPO PERSONA"
                .Name = "JURIDICAONATURAL"
                .DataPropertyName = "IDTIPO_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            'MyDataGridLista.Columns.Add(col6)

            Dim col7 As New DataGridViewCheckBoxColumn
            With col7
                .HeaderText = "CLIENTE CORPORATIVO"
                .Name = "CLIENTE_CORPORATIVO"
                .DataPropertyName = "CLIENTE_CORPORATIVO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col8 As New DataGridViewTextBoxColumn
            With col8
                .HeaderText = "GERENTE GENERAL"
                .Name = "GERENTE_GENERAL"
                .DataPropertyName = "GERENTE_GENERAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col9 As New DataGridViewTextBoxColumn
            With col9
                .HeaderText = "REPRESENTANTE LEGAL"
                .Name = "REPRESENTANTE_LEGAL"
                .DataPropertyName = "REPRESENTANTE_LEGAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col10 As New DataGridViewTextBoxColumn
            With col10
                .HeaderText = "FECHA INGRESO"
                .Name = "FECHA_INGRESO"
                .DataPropertyName = "FECHA_INGRESO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col11 As New DataGridViewCheckBoxColumn
            With col11
                .HeaderText = "PAGO POST FACTURACION"
                .Name = "PAGO_POST_FACTURACION"
                .DataPropertyName = "PAGO_POST_FACTURACION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col12 As New DataGridViewTextBoxColumn
            With col12
                .HeaderText = "EMAIL"
                .Name = "EMAIL"
                .DataPropertyName = "EMAIL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col13 As New DataGridViewTextBoxColumn
            With col13
                .HeaderText = "APELLIDO PATERNO"
                .Name = "APELLIDO_PATERNO"
                .DataPropertyName = "APELLIDO_PATERNO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col14 As New DataGridViewTextBoxColumn
            With col14
                .HeaderText = "APELLIDO MATERNO"
                .Name = "APELLIDO_MATERNO"
                .DataPropertyName = "APELLIDO_MATERNO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col15 As New DataGridViewTextBoxColumn
            With col15
                .HeaderText = "NOMPRE PERSONA"
                .Name = "NOMPRE_PERSONA"
                .DataPropertyName = "NOMPRE_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col16 As New DataGridViewTextBoxColumn
            With col16
                .HeaderText = "NOMPRE PERSONA1"
                .Name = "NOMPRE_PERSONA1"
                .DataPropertyName = "NOMPRE_PERSONA1"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col17 As New DataGridViewTextBoxColumn
            With col17
                .HeaderText = "FECHA NACIMIENTO"
                .Name = "FECHA_NACIMIENTO"
                .DataPropertyName = "FECHA_NACIMIENTO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col18 As New DataGridViewTextBoxColumn
            With col18
                .HeaderText = "SEXO PERSONA"
                .Name = "SEXO_PERSONA"
                .DataPropertyName = "SEXO_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col19 As New DataGridViewCheckBoxColumn
            With col19
                .HeaderText = "ESMENOREDAD"
                .Name = "ESMENOREDAD"
                .DataPropertyName = "ESMENOREDAD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col20 As New DataGridViewCheckBoxColumn
            With col20
                .HeaderText = "AGENTE RETENCION"
                .Name = "AGENTE_RETENCION"
                .DataPropertyName = "AGENTE_RETENCION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col21 As New DataGridViewTextBoxColumn
            With col21
                .HeaderText = "IDTIPO DOC IDENTIDAD"
                .Name = "IDTIPO_DOC_IDENTIDAD"
                .DataPropertyName = "IDTIPO_DOC_IDENTIDAD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col22 As New DataGridViewTextBoxColumn
            With col22
                .HeaderText = "NU RETE SUNA"
                .Name = "NU_RETE_SUNA"
                .DataPropertyName = "NU_RETE_SUNA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col23 As New DataGridViewTextBoxColumn
            With col23
                .HeaderText = "IDRUBRO"
                .Name = "IDRUBRO"
                .DataPropertyName = "IDRUBRO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col24 As New DataGridViewTextBoxColumn
            With col24
                .HeaderText = "IDCLASIFICACION PERSONA"
                .Name = "IDCLASIFICACION_PERSONA"
                .DataPropertyName = "IDCLASIFICACION_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col25 As New DataGridViewTextBoxColumn
            With col25
                .HeaderText = "IDUSUARIO PERSONAL"
                .Name = "IDUSUARIO_PERSONAL"
                .DataPropertyName = "IDUSUARIO_PERSONAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col26 As New DataGridViewTextBoxColumn
            With col26
                .HeaderText = "IDROL USUARIO"
                .Name = "IDROL_USUARIO"
                .DataPropertyName = "IDROL_USUARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col27 As New DataGridViewTextBoxColumn
            With col27
                .HeaderText = "IP"
                .Name = "IP"
                .DataPropertyName = "IP"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col28 As New DataGridViewTextBoxColumn
            With col28
                .HeaderText = "FECHA REGISTRO"
                .Name = "FECHA_REGISTRO"
                .DataPropertyName = "FECHA_REGISTRO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col29 As New DataGridViewTextBoxColumn
            With col29
                .HeaderText = "IDUSUARIO PERSONALMOD"
                .Name = "IDUSUARIO_PERSONALMOD"
                .DataPropertyName = "IDUSUARIO_PERSONALMOD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col30 As New DataGridViewTextBoxColumn
            With col30
                .HeaderText = "IDROL USUARIOMOD"
                .Name = "IDROL_USUARIOMOD"
                .DataPropertyName = "IDROL_USUARIOMOD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col31 As New DataGridViewTextBoxColumn
            With col31
                .HeaderText = "IPMOD"
                .Name = "IPMOD"
                .DataPropertyName = "IPMOD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col32 As New DataGridViewTextBoxColumn
            With col32
                .HeaderText = "FECHA_ACTUALIZACION"
                .Name = "FECHA_ACTUALIZACION"
                .DataPropertyName = "FECHA_ACTUALIZACION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col33 As New DataGridViewTextBoxColumn
            With col33
                .HeaderText = "IDPAIS"
                .Name = "IDPAIS"
                .DataPropertyName = "IDPAIS"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col34 As New DataGridViewTextBoxColumn
            With col34
                .HeaderText = "IDDEPARTAMENTO"
                .Name = "IDDEPARTAMENTO"
                .DataPropertyName = "IDDEPARTAMENTO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col35 As New DataGridViewTextBoxColumn
            With col35
                .HeaderText = "IDPROVINCIA"
                .Name = "IDPROVINCIA"
                .DataPropertyName = "IDPROVINCIA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col36 As New DataGridViewTextBoxColumn
            With col36
                .HeaderText = "IDDISTRITO"
                .Name = "IDDISTRITO"
                .DataPropertyName = "IDDISTRITO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col37 As New DataGridViewTextBoxColumn
            With col37
                .HeaderText = "USUARIO"
                .Name = "USUARIO"
                .DataPropertyName = "USUARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col38 As New DataGridViewTextBoxColumn
            With col38
                .HeaderText = "ROL USUARIO"
                .Name = "ROL_USUARIO"
                .DataPropertyName = "ROL_USUARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col39 As New DataGridViewTextBoxColumn
            With col39
                .HeaderText = "IDFUNCIONARIO ACTUAL"
                .Name = "IDFUNCIONARIO_ACTUAL"
                .DataPropertyName = "IDFUNCIONARIO_ACTUAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col40 As New DataGridViewTextBoxColumn
            With col40
                .HeaderText = "FUNCIONARIO"
                .Name = "FUNCIONARIO"
                .DataPropertyName = "FUNCIONARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col41 As New DataGridViewTextBoxColumn
            With col41
                .HeaderText = "IDTIPO_FACTURACION"
                .Name = "IDTIPO_FACTURACION"
                .DataPropertyName = "IDTIPO_FACTURACION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            '27/08/2010 - Crédito 
            Dim col42 As New DataGridViewTextBoxColumn
            With col42
                .HeaderText = "Tipo Crédito"
                .Name = "TIPO_CREDITO"
                .DataPropertyName = "TIPO_CREDITO"
                .ToolTipText = "Tipo Crédito"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            '
            MyDataGridLista.Columns.AddRange(col0, col1, col2, Col3, col4, col5, col6, col7, col8, col9, col10, col11, col12, col13, col14, col15, col16, col17, col18, col19, col20, col21, col22, col23, col24, col25, col26, col27, col28, col29, col30, col31, col32, col33, col34, col35, col36, col37, col38, col39, col40, col41, col42)
            ''
            For i As Integer = 0 To 42
                MyDataGridLista.Columns(i).Visible = False
            Next
            ''
            MyDataGridLista.Columns(0).Visible = True
            MyDataGridLista.Columns(2).Visible = True
            MyDataGridLista.Columns(4).Visible = True
            MyDataGridLista.Columns(5).Visible = True

            Return MydvListaClientes

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Modificado por Omendoza - 25/06/2007 
    'Public Function CargarGrillaClientes(ByVal MyDataGridLista As DataGridView) As DataView
    '    Dim rstListaClientes As ADODB.Recordset
    '    Dim dtListaClientes As New DataTable
    '    '
    '    Dim Myobj As Object() = {"PKG_IVOPERSONA.SP_LISTA_CLIENTES", 0}
    '    rstListaClientes = VOCONTROLUSUARIO.fnSQLQuery(Myobj)
    '    '
    '    Dim da As New OleDbDataAdapter
    '    da.Fill(dtListaClientes, rstListaClientes)
    '    Dim MydvListaClientes As DataView

    '    MydvListaClientes = dtListaClientes.DefaultView
    '    With MyDataGridLista
    '        '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
    '        .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    '        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
    '        .AllowUserToOrderColumns = True
    '        .AllowUserToDeleteRows = False
    '        .AllowUserToAddRows = False
    '        .AutoGenerateColumns = False
    '        .DataSource = MydvListaClientes
    '        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
    '        .SelectionMode = DataGridViewSelectionMode.CellSelect
    '        .VirtualMode = True
    '        '.RowHeadersWidth = 30
    '        .RowHeadersVisible = False
    '        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    End With

    '    Dim col0 As New DataGridViewCheckBoxColumn
    '    With col0
    '        .HeaderText = "¿ACTIVO?"
    '        .Name = "ACTIVO"
    '        .DataPropertyName = "IDESTADO_REGISTRO"
    '        .Width = 62
    '        .ThreeState = False
    '        .TrueValue = 1
    '        .FalseValue = 0
    '        .Frozen = True
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With
    '    'MyDataGridLista.Columns.Add(col0)

    '    Dim col1 As New DataGridViewTextBoxColumn
    '    With col1
    '        .HeaderText = "ID"
    '        .Name = "ID"
    '        .DataPropertyName = "IDPERSONA"
    '        .ReadOnly = True
    '        .ToolTipText = "Identificador del cliente en la Base de Datos"
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
    '    End With
    '    'MyDataGridLista.Columns.Add(col1)

    '    Dim col2 As New DataGridViewTextBoxColumn
    '    With col2
    '        .HeaderText = "CODIGO"
    '        .Name = "CODIGO"
    '        .DataPropertyName = "CODIGO_CLIENTE"
    '        .ToolTipText = "Código del Cliente"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
    '    End With
    '    'MyDataGridLista.Columns.Add(col2)

    '    Dim Col3 As New DataGridViewTextBoxColumn
    '    With Col3
    '        .HeaderText = "DOCT."
    '        .Name = "DOCUMENTO"
    '        .DataPropertyName = "NU_DOCU_SUNA"
    '        .ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
    '    End With
    '    'MyDataGridLista.Columns.Add(Col3)

    '    Dim col4 As New DataGridViewTextBoxColumn
    '    With col4
    '        .HeaderText = "RAZON SOCIAL"
    '        .Name = "RAZONSOCIAL"
    '        .DataPropertyName = "RAZON_SOCIAL"
    '        .ToolTipText = "Razon Social para Personas Juridicos"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '    End With
    '    'MyDataGridLista.Columns.Add(col4)

    '    Dim col5 As New DataGridViewTextBoxColumn
    '    With col5
    '        .HeaderText = "NOMBRE Y APELLIDOS"
    '        .Name = "NOMBREYAPELLIDO"
    '        .DataPropertyName = "NOMNRES_APELLIDOS"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '    End With
    '    'MyDataGridLista.Columns.Add(col5)

    '    Dim col6 As New DataGridViewTextBoxColumn
    '    With col6
    '        .HeaderText = "TIPO PERSONA"
    '        .Name = "JURIDICAONATURAL"
    '        .DataPropertyName = "IDTIPO_PERSONA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With
    '    'MyDataGridLista.Columns.Add(col6)

    '    Dim col7 As New DataGridViewCheckBoxColumn
    '    With col7
    '        .HeaderText = "CLIENTE CORPORATIVO"
    '        .Name = "CLIENTE_CORPORATIVO"
    '        .DataPropertyName = "CLIENTE_CORPORATIVO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col8 As New DataGridViewTextBoxColumn
    '    With col8
    '        .HeaderText = "GERENTE GENERAL"
    '        .Name = "GERENTE_GENERAL"
    '        .DataPropertyName = "GERENTE_GENERAL"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col9 As New DataGridViewTextBoxColumn
    '    With col9
    '        .HeaderText = "REPRESENTANTE LEGAL"
    '        .Name = "REPRESENTANTE_LEGAL"
    '        .DataPropertyName = "REPRESENTANTE_LEGAL"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col10 As New DataGridViewTextBoxColumn
    '    With col10
    '        .HeaderText = "FECHA INGRESO"
    '        .Name = "FECHA_INGRESO"
    '        .DataPropertyName = "FECHA_INGRESO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col11 As New DataGridViewCheckBoxColumn
    '    With col11
    '        .HeaderText = "PAGO POST FACTURACION"
    '        .Name = "PAGO_POST_FACTURACION"
    '        .DataPropertyName = "PAGO_POST_FACTURACION"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col12 As New DataGridViewTextBoxColumn
    '    With col12
    '        .HeaderText = "EMAIL"
    '        .Name = "EMAIL"
    '        .DataPropertyName = "EMAIL"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col13 As New DataGridViewTextBoxColumn
    '    With col13
    '        .HeaderText = "APELLIDO PATERNO"
    '        .Name = "APELLIDO_PATERNO"
    '        .DataPropertyName = "APELLIDO_PATERNO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col14 As New DataGridViewTextBoxColumn
    '    With col14
    '        .HeaderText = "APELLIDO MATERNO"
    '        .Name = "APELLIDO_MATERNO"
    '        .DataPropertyName = "APELLIDO_MATERNO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col15 As New DataGridViewTextBoxColumn
    '    With col15
    '        .HeaderText = "NOMPRE PERSONA"
    '        .Name = "NOMPRE_PERSONA"
    '        .DataPropertyName = "NOMPRE_PERSONA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col16 As New DataGridViewTextBoxColumn
    '    With col16
    '        .HeaderText = "NOMPRE PERSONA1"
    '        .Name = "NOMPRE_PERSONA1"
    '        .DataPropertyName = "NOMPRE_PERSONA1"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col17 As New DataGridViewTextBoxColumn
    '    With col17
    '        .HeaderText = "FECHA NACIMIENTO"
    '        .Name = "FECHA_NACIMIENTO"
    '        .DataPropertyName = "FECHA_NACIMIENTO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col18 As New DataGridViewTextBoxColumn
    '    With col18
    '        .HeaderText = "SEXO PERSONA"
    '        .Name = "SEXO_PERSONA"
    '        .DataPropertyName = "SEXO_PERSONA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col19 As New DataGridViewCheckBoxColumn
    '    With col19
    '        .HeaderText = "ESMENOREDAD"
    '        .Name = "ESMENOREDAD"
    '        .DataPropertyName = "ESMENOREDAD"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col20 As New DataGridViewCheckBoxColumn
    '    With col20
    '        .HeaderText = "AGENTE RETENCION"
    '        .Name = "AGENTE_RETENCION"
    '        .DataPropertyName = "AGENTE_RETENCION"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col21 As New DataGridViewTextBoxColumn
    '    With col21
    '        .HeaderText = "IDTIPO DOC IDENTIDAD"
    '        .Name = "IDTIPO_DOC_IDENTIDAD"
    '        .DataPropertyName = "IDTIPO_DOC_IDENTIDAD"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col22 As New DataGridViewTextBoxColumn
    '    With col22
    '        .HeaderText = "NU RETE SUNA"
    '        .Name = "NU_RETE_SUNA"
    '        .DataPropertyName = "NU_RETE_SUNA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col23 As New DataGridViewTextBoxColumn
    '    With col23
    '        .HeaderText = "IDRUBRO"
    '        .Name = "IDRUBRO"
    '        .DataPropertyName = "IDRUBRO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col24 As New DataGridViewTextBoxColumn
    '    With col24
    '        .HeaderText = "IDCLASIFICACION PERSONA"
    '        .Name = "IDCLASIFICACION_PERSONA"
    '        .DataPropertyName = "IDCLASIFICACION_PERSONA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col25 As New DataGridViewTextBoxColumn
    '    With col25
    '        .HeaderText = "IDUSUARIO PERSONAL"
    '        .Name = "IDUSUARIO_PERSONAL"
    '        .DataPropertyName = "IDUSUARIO_PERSONAL"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col26 As New DataGridViewTextBoxColumn
    '    With col26
    '        .HeaderText = "IDROL USUARIO"
    '        .Name = "IDROL_USUARIO"
    '        .DataPropertyName = "IDROL_USUARIO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col27 As New DataGridViewTextBoxColumn
    '    With col27
    '        .HeaderText = "IP"
    '        .Name = "IP"
    '        .DataPropertyName = "IP"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col28 As New DataGridViewTextBoxColumn
    '    With col28
    '        .HeaderText = "FECHA REGISTRO"
    '        .Name = "FECHA_REGISTRO"
    '        .DataPropertyName = "FECHA_REGISTRO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col29 As New DataGridViewTextBoxColumn
    '    With col29
    '        .HeaderText = "IDUSUARIO PERSONALMOD"
    '        .Name = "IDUSUARIO_PERSONALMOD"
    '        .DataPropertyName = "IDUSUARIO_PERSONALMOD"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col30 As New DataGridViewTextBoxColumn
    '    With col30
    '        .HeaderText = "IDROL USUARIOMOD"
    '        .Name = "IDROL_USUARIOMOD"
    '        .DataPropertyName = "IDROL_USUARIOMOD"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col31 As New DataGridViewTextBoxColumn
    '    With col31
    '        .HeaderText = "IPMOD"
    '        .Name = "IPMOD"
    '        .DataPropertyName = "IPMOD"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col32 As New DataGridViewTextBoxColumn
    '    With col32
    '        .HeaderText = "FECHA_ACTUALIZACION"
    '        .Name = "FECHA_ACTUALIZACION"
    '        .DataPropertyName = "FECHA_ACTUALIZACION"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col33 As New DataGridViewTextBoxColumn
    '    With col33
    '        .HeaderText = "IDPAIS"
    '        .Name = "IDPAIS"
    '        .DataPropertyName = "IDPAIS"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col34 As New DataGridViewTextBoxColumn
    '    With col34
    '        .HeaderText = "IDDEPARTAMENTO"
    '        .Name = "IDDEPARTAMENTO"
    '        .DataPropertyName = "IDDEPARTAMENTO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col35 As New DataGridViewTextBoxColumn
    '    With col35
    '        .HeaderText = "IDPROVINCIA"
    '        .Name = "IDPROVINCIA"
    '        .DataPropertyName = "IDPROVINCIA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col36 As New DataGridViewTextBoxColumn
    '    With col36
    '        .HeaderText = "IDDISTRITO"
    '        .Name = "IDDISTRITO"
    '        .DataPropertyName = "IDDISTRITO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col37 As New DataGridViewTextBoxColumn
    '    With col37
    '        .HeaderText = "USUARIO"
    '        .Name = "USUARIO"
    '        .DataPropertyName = "USUARIO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col38 As New DataGridViewTextBoxColumn
    '    With col38
    '        .HeaderText = "ROL USUARIO"
    '        .Name = "ROL_USUARIO"
    '        .DataPropertyName = "ROL_USUARIO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col39 As New DataGridViewTextBoxColumn
    '    With col39
    '        .HeaderText = "IDFUNCIONARIO ACTUAL"
    '        .Name = "IDFUNCIONARIO_ACTUAL"
    '        .DataPropertyName = "IDFUNCIONARIO_ACTUAL"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col40 As New DataGridViewTextBoxColumn
    '    With col40
    '        .HeaderText = "FUNCIONARIO"
    '        .Name = "FUNCIONARIO"
    '        .DataPropertyName = "FUNCIONARIO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col41 As New DataGridViewTextBoxColumn
    '    With col41
    '        .HeaderText = "IDTIPO_FACTURACION"
    '        .Name = "IDTIPO_FACTURACION"
    '        .DataPropertyName = "IDTIPO_FACTURACION"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    MyDataGridLista.Columns.AddRange(col0, col1, col2, Col3, col4, col5, col6, col7, col8, col9, col10, col11, col12, col13, col14, col15, col16, col17, col18, col19, col20, col21, col22, col23, col24, col25, col26, col27, col28, col29, col30, col31, col32, col33, col34, col35, col36, col37, col38, col39, col40, col41)

    '    For i As Integer = 0 To 41
    '        MyDataGridLista.Columns(i).Visible = False
    '    Next

    '    MyDataGridLista.Columns(0).Visible = True
    '    MyDataGridLista.Columns(2).Visible = True
    '    MyDataGridLista.Columns(4).Visible = True
    '    MyDataGridLista.Columns(5).Visible = True
    '    Return MydvListaClientes
    'End Function
    '
    'Public Function CargarGrillaClientes(ByVal MyDataGridLista As DataGridView) As DataView
    '    Dim rstListaClientes As ADODB.Recordset
    '    Dim dtListaClientes As New DataTable
    '    'hlamas
    '    'Dim Myobj As Object() = {"SP_LISTA_CLIENTES", 0}
    '    Dim Myobj As Object() = {"PKG_IVOPERSONA.SP_LISTA_CLIENTES", 0}
    '    rstListaClientes = VOCONTROLUSUARIO.fnSQLQuery(Myobj)
    '    '
    '    Dim da As New OleDbDataAdapter
    '    da.Fill(dtListaClientes, rstListaClientes)
    '    Dim MydvListaClientes As DataView

    '    MydvListaClientes = dtListaClientes.DefaultView
    '    With MyDataGridLista
    '        '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
    '        .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    '        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
    '        .AllowUserToOrderColumns = True
    '        .AllowUserToDeleteRows = False
    '        .AllowUserToAddRows = False
    '        .AutoGenerateColumns = False
    '        .DataSource = MydvListaClientes
    '        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
    '        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        .VirtualMode = True
    '        '.RowHeadersWidth = 30
    '        .RowHeadersVisible = False
    '        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    '        '.Font = New Font("Arial", 8.0!, FontStyle.Regular)
    '        '.AllowUserToOrderColumns = True
    '        '.AllowUserToDeleteRows = False
    '        '.AllowUserToAddRows = False
    '        '.AutoGenerateColumns = False
    '        '.DataSource = dvListar_facturas
    '        '.DefaultCellStyle.WrapMode = DataGridViewTriState.True
    '        '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        '.VirtualMode = True
    '        '.RowHeadersVisible = True
    '        '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

    '    End With

    '    Dim col0 As New DataGridViewCheckBoxColumn
    '    With col0
    '        .HeaderText = "¿ACTIVO?"
    '        .Name = "ACTIVO"
    '        .DataPropertyName = "IDESTADO_REGISTRO"
    '        .Width = 62
    '        .ThreeState = False
    '        .TrueValue = 1
    '        .FalseValue = 0
    '        .Frozen = True
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With
    '    'MyDataGridLista.Columns.Add(col0)

    '    Dim col1 As New DataGridViewTextBoxColumn
    '    With col1
    '        .HeaderText = "ID"
    '        .Name = "ID"
    '        .DataPropertyName = "IDPERSONA"
    '        .ReadOnly = True
    '        .ToolTipText = "Identificador del cliente en la Base de Datos"
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
    '    End With
    '    'MyDataGridLista.Columns.Add(col1)

    '    Dim col2 As New DataGridViewTextBoxColumn
    '    With col2
    '        .HeaderText = "CODIGO"
    '        .Name = "CODIGO"
    '        .DataPropertyName = "CODIGO_CLIENTE"
    '        .ToolTipText = "Código del Cliente"
    '        .Width = 110
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
    '    End With
    '    'MyDataGridLista.Columns.Add(col2)

    '    Dim Col3 As New DataGridViewTextBoxColumn
    '    With Col3
    '        .HeaderText = "DOCT."
    '        .Name = "DOCUMENTO"
    '        .DataPropertyName = "NU_DOCU_SUNA"
    '        .ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
    '    End With
    '    'MyDataGridLista.Columns.Add(Col3)

    '    Dim col4 As New DataGridViewTextBoxColumn
    '    With col4
    '        .HeaderText = "RAZON SOCIAL"
    '        .Name = "RAZONSOCIAL"
    '        .DataPropertyName = "RAZON_SOCIAL"
    '        .ToolTipText = "Razon Social para Personas Juridicos"
    '        .ReadOnly = True
    '        '.Width = 300
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '    End With
    '    'MyDataGridLista.Columns.Add(col4)

    '    Dim col5 As New DataGridViewTextBoxColumn
    '    With col5
    '        .HeaderText = "NOMBRE Y APELLIDOS"
    '        .Name = "NOMBREYAPELLIDO"
    '        .DataPropertyName = "NOMNRES_APELLIDOS"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '    End With
    '    'MyDataGridLista.Columns.Add(col5)

    '    Dim col6 As New DataGridViewTextBoxColumn
    '    With col6
    '        .HeaderText = "TIPO PERSONA"
    '        .Name = "JURIDICAONATURAL"
    '        .DataPropertyName = "IDTIPO_PERSONA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With
    '    'MyDataGridLista.Columns.Add(col6)

    '    Dim col7 As New DataGridViewCheckBoxColumn
    '    With col7
    '        .HeaderText = "CLIENTE CORPORATIVO"
    '        .Name = "CLIENTE_CORPORATIVO"
    '        .DataPropertyName = "CLIENTE_CORPORATIVO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col8 As New DataGridViewTextBoxColumn
    '    With col8
    '        .HeaderText = "GERENTE GENERAL"
    '        .Name = "GERENTE_GENERAL"
    '        .DataPropertyName = "GERENTE_GENERAL"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col9 As New DataGridViewTextBoxColumn
    '    With col9
    '        .HeaderText = "REPRESENTANTE LEGAL"
    '        .Name = "REPRESENTANTE_LEGAL"
    '        .DataPropertyName = "REPRESENTANTE_LEGAL"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col10 As New DataGridViewTextBoxColumn
    '    With col10
    '        .HeaderText = "FECHA INGRESO"
    '        .Name = "FECHA_INGRESO"
    '        .DataPropertyName = "FECHA_INGRESO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col11 As New DataGridViewCheckBoxColumn
    '    With col11
    '        .HeaderText = "PAGO POST FACTURACION"
    '        .Name = "PAGO_POST_FACTURACION"
    '        .DataPropertyName = "PAGO_POST_FACTURACION"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col12 As New DataGridViewTextBoxColumn
    '    With col12
    '        .HeaderText = "EMAIL"
    '        .Name = "EMAIL"
    '        .DataPropertyName = "EMAIL"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col13 As New DataGridViewTextBoxColumn
    '    With col13
    '        .HeaderText = "APELLIDO PATERNO"
    '        .Name = "APELLIDO_PATERNO"
    '        .DataPropertyName = "APELLIDO_PATERNO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col14 As New DataGridViewTextBoxColumn
    '    With col14
    '        .HeaderText = "APELLIDO MATERNO"
    '        .Name = "APELLIDO_MATERNO"
    '        .DataPropertyName = "APELLIDO_MATERNO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col15 As New DataGridViewTextBoxColumn
    '    With col15
    '        .HeaderText = "NOMPRE PERSONA"
    '        .Name = "NOMPRE_PERSONA"
    '        .DataPropertyName = "NOMPRE_PERSONA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col16 As New DataGridViewTextBoxColumn
    '    With col16
    '        .HeaderText = "NOMPRE PERSONA1"
    '        .Name = "NOMPRE_PERSONA1"
    '        .DataPropertyName = "NOMPRE_PERSONA1"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col17 As New DataGridViewTextBoxColumn
    '    With col17
    '        .HeaderText = "FECHA NACIMIENTO"
    '        .Name = "FECHA_NACIMIENTO"
    '        .DataPropertyName = "FECHA_NACIMIENTO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col18 As New DataGridViewTextBoxColumn
    '    With col18
    '        .HeaderText = "SEXO PERSONA"
    '        .Name = "SEXO_PERSONA"
    '        .DataPropertyName = "SEXO_PERSONA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col19 As New DataGridViewCheckBoxColumn
    '    With col19
    '        .HeaderText = "ESMENOREDAD"
    '        .Name = "ESMENOREDAD"
    '        .DataPropertyName = "ESMENOREDAD"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col20 As New DataGridViewCheckBoxColumn
    '    With col20
    '        .HeaderText = "AGENTE RETENCION"
    '        .Name = "AGENTE_RETENCION"
    '        .DataPropertyName = "AGENTE_RETENCION"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col21 As New DataGridViewTextBoxColumn
    '    With col21
    '        .HeaderText = "IDTIPO DOC IDENTIDAD"
    '        .Name = "IDTIPO_DOC_IDENTIDAD"
    '        .DataPropertyName = "IDTIPO_DOC_IDENTIDAD"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col22 As New DataGridViewTextBoxColumn
    '    With col22
    '        .HeaderText = "NU RETE SUNA"
    '        .Name = "NU_RETE_SUNA"
    '        .DataPropertyName = "NU_RETE_SUNA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col23 As New DataGridViewTextBoxColumn
    '    With col23
    '        .HeaderText = "IDRUBRO"
    '        .Name = "IDRUBRO"
    '        .DataPropertyName = "IDRUBRO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col24 As New DataGridViewTextBoxColumn
    '    With col24
    '        .HeaderText = "IDCLASIFICACION PERSONA"
    '        .Name = "IDCLASIFICACION_PERSONA"
    '        .DataPropertyName = "IDCLASIFICACION_PERSONA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col25 As New DataGridViewTextBoxColumn
    '    With col25
    '        .HeaderText = "IDUSUARIO PERSONAL"
    '        .Name = "IDUSUARIO_PERSONAL"
    '        .DataPropertyName = "IDUSUARIO_PERSONAL"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col26 As New DataGridViewTextBoxColumn
    '    With col26
    '        .HeaderText = "IDROL USUARIO"
    '        .Name = "IDROL_USUARIO"
    '        .DataPropertyName = "IDROL_USUARIO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col27 As New DataGridViewTextBoxColumn
    '    With col27
    '        .HeaderText = "IP"
    '        .Name = "IP"
    '        .DataPropertyName = "IP"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col28 As New DataGridViewTextBoxColumn
    '    With col28
    '        .HeaderText = "FECHA REGISTRO"
    '        .Name = "FECHA_REGISTRO"
    '        .DataPropertyName = "FECHA_REGISTRO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col29 As New DataGridViewTextBoxColumn
    '    With col29
    '        .HeaderText = "IDUSUARIO PERSONALMOD"
    '        .Name = "IDUSUARIO_PERSONALMOD"
    '        .DataPropertyName = "IDUSUARIO_PERSONALMOD"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col30 As New DataGridViewTextBoxColumn
    '    With col30
    '        .HeaderText = "IDROL USUARIOMOD"
    '        .Name = "IDROL_USUARIOMOD"
    '        .DataPropertyName = "IDROL_USUARIOMOD"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col31 As New DataGridViewTextBoxColumn
    '    With col31
    '        .HeaderText = "IPMOD"
    '        .Name = "IPMOD"
    '        .DataPropertyName = "IPMOD"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col32 As New DataGridViewTextBoxColumn
    '    With col32
    '        .HeaderText = "FECHA_ACTUALIZACION"
    '        .Name = "FECHA_ACTUALIZACION"
    '        .DataPropertyName = "FECHA_ACTUALIZACION"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col33 As New DataGridViewTextBoxColumn
    '    With col33
    '        .HeaderText = "IDPAIS"
    '        .Name = "IDPAIS"
    '        .DataPropertyName = "IDPAIS"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col34 As New DataGridViewTextBoxColumn
    '    With col34
    '        .HeaderText = "IDDEPARTAMENTO"
    '        .Name = "IDDEPARTAMENTO"
    '        .DataPropertyName = "IDDEPARTAMENTO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col35 As New DataGridViewTextBoxColumn
    '    With col35
    '        .HeaderText = "IDPROVINCIA"
    '        .Name = "IDPROVINCIA"
    '        .DataPropertyName = "IDPROVINCIA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col36 As New DataGridViewTextBoxColumn
    '    With col36
    '        .HeaderText = "IDDISTRITO"
    '        .Name = "IDDISTRITO"
    '        .DataPropertyName = "IDDISTRITO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col37 As New DataGridViewTextBoxColumn
    '    With col37
    '        .HeaderText = "USUARIO"
    '        .Name = "USUARIO"
    '        .DataPropertyName = "USUARIO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col38 As New DataGridViewTextBoxColumn
    '    With col38
    '        .HeaderText = "ROL USUARIO"
    '        .Name = "ROL_USUARIO"
    '        .DataPropertyName = "ROL_USUARIO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col39 As New DataGridViewTextBoxColumn
    '    With col39
    '        .HeaderText = "IDFUNCIONARIO ACTUAL"
    '        .Name = "IDFUNCIONARIO_ACTUAL"
    '        .DataPropertyName = "IDFUNCIONARIO_ACTUAL"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col40 As New DataGridViewTextBoxColumn
    '    With col40
    '        .HeaderText = "FUNCIONARIO"
    '        .Name = "FUNCIONARIO"
    '        .DataPropertyName = "FUNCIONARIO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col41 As New DataGridViewTextBoxColumn
    '    With col41
    '        .HeaderText = "IDTIPO_FACTURACION"
    '        .Name = "IDTIPO_FACTURACION"
    '        .DataPropertyName = "IDTIPO_FACTURACION"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col42 As New DataGridViewTextBoxColumn
    '    With col42
    '        .HeaderText = "MONTO_BASE"
    '        .Name = "MONTO_BASE"
    '        .DataPropertyName = "MONTO_BASE"
    '        .ToolTipText = "¿Afecto a Monto Base?"
    '        .ReadOnly = True
    '        '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With


    '    Dim TELEFONO_DIRECCION As New DataGridViewTextBoxColumn
    '    With TELEFONO_DIRECCION
    '        .HeaderText = "TELEFONO"
    '        .Name = "TELEFONO_DIRECCION"
    '        .DataPropertyName = "TELEFONO_DIRECCION"
    '        .ToolTipText = "Telefono"
    '        .ReadOnly = True
    '        .Width = 200
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim FAX_DIRECCION As New DataGridViewTextBoxColumn
    '    With FAX_DIRECCION
    '        .HeaderText = "FAX"
    '        .Name = "FAX_DIRECCION"
    '        .DataPropertyName = "FAX_DIRECCION"
    '        .ToolTipText = "FAX_DIRECCION"
    '        .ReadOnly = True
    '        .Width = 200
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim porc_dscto As New DataGridViewTextBoxColumn
    '    With porc_dscto
    '        .HeaderText = "Porc. Dscto"
    '        .Name = "porcentaje_descuento"
    '        .DataPropertyName = "porcentaje_descuento"
    '        .ToolTipText = "Porc. Dscto"
    '        .ReadOnly = True
    '        .Visible = False
    '    End With


    '    MyDataGridLista.Columns.AddRange(col0, col1, col2, Col3, col4, col5, col6, col7, col8, col9, col10, col11, col12, col13, col14, col15, col16, col17, col18, col19, col20, col21, col22, col23, col24, col25, col26, col27, col28, col29, col30, col31, col32, col33, col34, col35, col36, col37, col38, col39, col40, col41, col42, TELEFONO_DIRECCION, FAX_DIRECCION, porc_dscto)

    '    For i As Integer = 0 To 43
    '        MyDataGridLista.Columns(i).Visible = False
    '    Next

    '    MyDataGridLista.Columns(0).Visible = True
    '    MyDataGridLista.Columns(2).Visible = True
    '    MyDataGridLista.Columns(4).Visible = True
    '    MyDataGridLista.Columns(5).Visible = True
    '    Return MydvListaClientes
    'End Function

    Public Function CargarGrillaClientes(ByVal MyDataGridLista As DataGridView) As DataView
        Try
            'datahelper
            'Dim rstListaClientes As ADODB.Recordset
            'Dim dtListaClientes As New DataTable
            ''hlamas
            ''Dim Myobj As Object() = {"SP_LISTA_CLIENTES", 0}
            'Dim Myobj As Object() = {"PKG_IVOPERSONA.SP_LISTA_CLIENTES", 0}
            'rstListaClientes = VOCONTROLUSUARIO.fnSQLQuery(Myobj)
            ''
            'Dim da As New OleDbDataAdapter
            'da.Fill(dtListaClientes, rstListaClientes)
            'Dim MydvListaClientes As DataView

            'MydvListaClientes = dtListaClientes.DefaultView

            Dim db As New BaseDatos
            db.Conectar()
            'hlamas 06-01-2013
            'db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CLIENTES", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CLIENTES_car", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_LISTA_CLIENTES", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dtListaClientes As DataTable = db.EjecutarDataTable
            Dim MydvListaClientes As DataView
            MydvListaClientes = dtListaClientes.DefaultView
            With MyDataGridLista
                '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .DataSource = MydvListaClientes
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .VirtualMode = True
                '.RowHeadersWidth = 30
                .RowHeadersVisible = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                '.Font = New Font("Arial", 8.0!, FontStyle.Regular)
                '.AllowUserToOrderColumns = True
                '.AllowUserToDeleteRows = False
                '.AllowUserToAddRows = False
                '.AutoGenerateColumns = False
                '.DataSource = dvListar_facturas
                '.DefaultCellStyle.WrapMode = DataGridViewTriState.True
                '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                '.VirtualMode = True
                '.RowHeadersVisible = True
                '.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            End With

            Dim col0 As New DataGridViewCheckBoxColumn
            With col0
                .HeaderText = "¿ACTIVO?"
                .Name = "ACTIVO"
                .DataPropertyName = "IDESTADO_REGISTRO"
                .Width = 62
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .Frozen = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            'MyDataGridLista.Columns.Add(col0)

            Dim col1 As New DataGridViewTextBoxColumn
            With col1
                .HeaderText = "ID"
                .Name = "ID"
                .DataPropertyName = "IDPERSONA"
                .ReadOnly = True
                .ToolTipText = "Identificador del cliente en la Base de Datos"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            End With
            'MyDataGridLista.Columns.Add(col1)

            Dim col2 As New DataGridViewTextBoxColumn
            With col2
                .HeaderText = "CODIGO"
                .Name = "CODIGO"
                .DataPropertyName = "CODIGO_CLIENTE"
                .ToolTipText = "Código del Cliente"
                .Width = 110
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            End With
            'MyDataGridLista.Columns.Add(col2)

            Dim Col3 As New DataGridViewTextBoxColumn
            With Col3
                .HeaderText = "DOCT."
                .Name = "DOCUMENTO"
                .DataPropertyName = "NU_DOCU_SUNA"
                .ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            End With
            'MyDataGridLista.Columns.Add(Col3)

            Dim col4 As New DataGridViewTextBoxColumn
            With col4
                .HeaderText = "CLIENTE"
                .Name = "RAZONSOCIAL"
                .DataPropertyName = "RAZON_SOCIAL"
                .ToolTipText = "Razon Social para Personas Juridicos"
                .ReadOnly = True
                '.Width = 300
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            'MyDataGridLista.Columns.Add(col4)

            Dim col5 As New DataGridViewTextBoxColumn
            With col5
                .HeaderText = "CLIENTE"
                .Name = "NOMBREYAPELLIDO"
                .DataPropertyName = "RAZON_SOCIAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            'MyDataGridLista.Columns.Add(col5)

            Dim col6 As New DataGridViewTextBoxColumn
            With col6
                .HeaderText = "TIPO PERSONA"
                .Name = "JURIDICAONATURAL"
                .DataPropertyName = "IDTIPO_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            'MyDataGridLista.Columns.Add(col6)

            Dim col7 As New DataGridViewCheckBoxColumn
            With col7
                .HeaderText = "CLIENTE CORPORATIVO"
                .Name = "CLIENTE_CORPORATIVO"
                .DataPropertyName = "CLIENTE_CORPORATIVO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col8 As New DataGridViewTextBoxColumn
            With col8
                .HeaderText = "GERENTE GENERAL"
                .Name = "GERENTE_GENERAL"
                .DataPropertyName = "GERENTE_GENERAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col9 As New DataGridViewTextBoxColumn
            With col9
                .HeaderText = "REPRESENTANTE LEGAL"
                .Name = "REPRESENTANTE_LEGAL"
                .DataPropertyName = "REPRESENTANTE_LEGAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col10 As New DataGridViewTextBoxColumn
            With col10
                .HeaderText = "FECHA INGRESO"
                .Name = "FECHA_INGRESO"
                .DataPropertyName = "FECHA_INGRESO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col11 As New DataGridViewCheckBoxColumn
            With col11
                .HeaderText = "PAGO POST FACTURACION"
                .Name = "PAGO_POST_FACTURACION"
                .DataPropertyName = "PAGO_POST_FACTURACION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col12 As New DataGridViewTextBoxColumn
            With col12
                .HeaderText = "EMAIL"
                .Name = "EMAIL"
                .DataPropertyName = "EMAIL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col13 As New DataGridViewTextBoxColumn
            With col13
                .HeaderText = "APELLIDO PATERNO"
                .Name = "APELLIDO_PATERNO"
                .DataPropertyName = "APELLIDO_PATERNO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col14 As New DataGridViewTextBoxColumn
            With col14
                .HeaderText = "APELLIDO MATERNO"
                .Name = "APELLIDO_MATERNO"
                .DataPropertyName = "APELLIDO_MATERNO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col15 As New DataGridViewTextBoxColumn
            With col15
                .HeaderText = "NOMPRE PERSONA"
                .Name = "NOMPRE_PERSONA"
                .DataPropertyName = "NOMPRE_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col16 As New DataGridViewTextBoxColumn
            With col16
                .HeaderText = "NOMPRE PERSONA1"
                .Name = "NOMPRE_PERSONA1"
                .DataPropertyName = "NOMPRE_PERSONA1"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col17 As New DataGridViewTextBoxColumn
            With col17
                .HeaderText = "FECHA NACIMIENTO"
                .Name = "FECHA_NACIMIENTO"
                .DataPropertyName = "FECHA_NACIMIENTO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col18 As New DataGridViewTextBoxColumn
            With col18
                .HeaderText = "SEXO PERSONA"
                .Name = "SEXO_PERSONA"
                .DataPropertyName = "SEXO_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col19 As New DataGridViewCheckBoxColumn
            With col19
                .HeaderText = "ESMENOREDAD"
                .Name = "ESMENOREDAD"
                .DataPropertyName = "ESMENOREDAD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col20 As New DataGridViewCheckBoxColumn
            With col20
                .HeaderText = "AGENTE RETENCION"
                .Name = "AGENTE_RETENCION"
                .DataPropertyName = "AGENTE_RETENCION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col21 As New DataGridViewTextBoxColumn
            With col21
                .HeaderText = "IDTIPO DOC IDENTIDAD"
                .Name = "IDTIPO_DOC_IDENTIDAD"
                .DataPropertyName = "IDTIPO_DOC_IDENTIDAD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col22 As New DataGridViewTextBoxColumn
            With col22
                .HeaderText = "NU RETE SUNA"
                .Name = "NU_RETE_SUNA"
                .DataPropertyName = "NU_RETE_SUNA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col23 As New DataGridViewTextBoxColumn
            With col23
                .HeaderText = "IDRUBRO"
                .Name = "IDRUBRO"
                .DataPropertyName = "IDRUBRO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col24 As New DataGridViewTextBoxColumn
            With col24
                .HeaderText = "IDCLASIFICACION PERSONA"
                .Name = "IDCLASIFICACION_PERSONA"
                .DataPropertyName = "IDCLASIFICACION_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col25 As New DataGridViewTextBoxColumn
            With col25
                .HeaderText = "IDUSUARIO PERSONAL"
                .Name = "IDUSUARIO_PERSONAL"
                .DataPropertyName = "IDUSUARIO_PERSONAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col26 As New DataGridViewTextBoxColumn
            With col26
                .HeaderText = "IDROL USUARIO"
                .Name = "IDROL_USUARIO"
                .DataPropertyName = "IDROL_USUARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col27 As New DataGridViewTextBoxColumn
            With col27
                .HeaderText = "IP"
                .Name = "IP"
                .DataPropertyName = "IP"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col28 As New DataGridViewTextBoxColumn
            With col28
                .HeaderText = "FECHA REGISTRO"
                .Name = "FECHA_REGISTRO"
                .DataPropertyName = "FECHA_REGISTRO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col29 As New DataGridViewTextBoxColumn
            With col29
                .HeaderText = "IDUSUARIO PERSONALMOD"
                .Name = "IDUSUARIO_PERSONALMOD"
                .DataPropertyName = "IDUSUARIO_PERSONALMOD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col30 As New DataGridViewTextBoxColumn
            With col30
                .HeaderText = "IDROL USUARIOMOD"
                .Name = "IDROL_USUARIOMOD"
                .DataPropertyName = "IDROL_USUARIOMOD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col31 As New DataGridViewTextBoxColumn
            With col31
                .HeaderText = "IPMOD"
                .Name = "IPMOD"
                .DataPropertyName = "IPMOD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col32 As New DataGridViewTextBoxColumn
            With col32
                .HeaderText = "FECHA_ACTUALIZACION"
                .Name = "FECHA_ACTUALIZACION"
                .DataPropertyName = "FECHA_ACTUALIZACION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col33 As New DataGridViewTextBoxColumn
            With col33
                .HeaderText = "IDPAIS"
                .Name = "IDPAIS"
                .DataPropertyName = "IDPAIS"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col34 As New DataGridViewTextBoxColumn
            With col34
                .HeaderText = "IDDEPARTAMENTO"
                .Name = "IDDEPARTAMENTO"
                .DataPropertyName = "IDDEPARTAMENTO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col35 As New DataGridViewTextBoxColumn
            With col35
                .HeaderText = "IDPROVINCIA"
                .Name = "IDPROVINCIA"
                .DataPropertyName = "IDPROVINCIA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col36 As New DataGridViewTextBoxColumn
            With col36
                .HeaderText = "IDDISTRITO"
                .Name = "IDDISTRITO"
                .DataPropertyName = "IDDISTRITO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col37 As New DataGridViewTextBoxColumn
            With col37
                .HeaderText = "USUARIO"
                .Name = "USUARIO"
                .DataPropertyName = "USUARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col38 As New DataGridViewTextBoxColumn
            With col38
                .HeaderText = "ROL USUARIO"
                .Name = "ROL_USUARIO"
                .DataPropertyName = "ROL_USUARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col39 As New DataGridViewTextBoxColumn
            With col39
                .HeaderText = "IDFUNCIONARIO ACTUAL"
                .Name = "IDFUNCIONARIO_ACTUAL"
                .DataPropertyName = "IDFUNCIONARIO_ACTUAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col40 As New DataGridViewTextBoxColumn
            With col40
                .HeaderText = "FUNCIONARIO"
                .Name = "FUNCIONARIO"
                .DataPropertyName = "FUNCIONARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col41 As New DataGridViewTextBoxColumn
            With col41
                .HeaderText = "IDTIPO_FACTURACION"
                .Name = "IDTIPO_FACTURACION"
                .DataPropertyName = "IDTIPO_FACTURACION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col42 As New DataGridViewTextBoxColumn
            With col42
                .HeaderText = "MONTO_BASE"
                .Name = "MONTO_BASE"
                .DataPropertyName = "MONTO_BASE"
                .ToolTipText = "¿Afecto a Monto Base?"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With


            Dim TELEFONO_DIRECCION As New DataGridViewTextBoxColumn
            With TELEFONO_DIRECCION
                .HeaderText = "TELEFONO"
                .Name = "TELEFONO_DIRECCION"
                .DataPropertyName = "TELEFONO_DIRECCION"
                .ToolTipText = "Telefono"
                .ReadOnly = True
                .Width = 200
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim FAX_DIRECCION As New DataGridViewTextBoxColumn
            With FAX_DIRECCION
                .HeaderText = "FAX"
                .Name = "FAX_DIRECCION"
                .DataPropertyName = "FAX_DIRECCION"
                .ToolTipText = "FAX_DIRECCION"
                .ReadOnly = True
                .Width = 200
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With


            Dim DESCUENTO As New DataGridViewTextBoxColumn
            With DESCUENTO
                .HeaderText = "DESCUENTO"
                .Name = "DESCUENTO"
                .DataPropertyName = "PORCENTAJE_DESCUENTO"
                .ToolTipText = "% DESCUENTO/INCREMENTO"
                .ReadOnly = True
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With


            MyDataGridLista.Columns.AddRange(col0, col1, col2, Col3, col4, col5, col6, col7, col8, col9, col10, col11, col12, col13, col14, col15, col16, col17, col18, col19, col20, col21, col22, col23, col24, col25, col26, col27, col28, col29, col30, col31, col32, col33, col34, col35, col36, col37, col38, col39, col40, col41, col42, TELEFONO_DIRECCION, FAX_DIRECCION, DESCUENTO)

            For i As Integer = 0 To 43
                MyDataGridLista.Columns(i).Visible = False
            Next

            MyDataGridLista.Columns(0).Visible = True
            MyDataGridLista.Columns(2).Visible = True
            MyDataGridLista.Columns(4).Visible = True
            MyDataGridLista.Columns(5).Visible = True
            Return MydvListaClientes

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    ' Se Repite la función anterior - Creado el 25/06/2007 
    'Public Function CargarGrillaClientes_x_funcionario(ByVal sidusurio_funcionario As String, ByVal MyDataGridLista As DataGridView) As DataView
    '    Dim rstListaClientes As ADODB.Recordset
    '    Dim dtListaClientes As New DataTable
    '    '
    '    Dim Myobj As Object() = {"PKG_IVOPERSONA.SP_LISTA_CLIENTES_x_FUNCIONAR", 4, _
    '                             sidusurio_funcionario, 2}
    '    rstListaClientes = VOCONTROLUSUARIO.fnSQLQuery(Myobj)
    '    '
    '    Dim da As New OleDbDataAdapter
    '    da.Fill(dtListaClientes, rstListaClientes)
    '    Dim MydvListaClientes As DataView
    '    '
    '    MydvListaClientes = dtListaClientes.DefaultView
    '    '
    '    With MyDataGridLista
    '        '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
    '        .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    '        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
    '        .AllowUserToOrderColumns = True
    '        .AllowUserToDeleteRows = False
    '        .AllowUserToAddRows = False
    '        .AutoGenerateColumns = False
    '        .DataSource = MydvListaClientes
    '        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
    '        .SelectionMode = DataGridViewSelectionMode.CellSelect
    '        .VirtualMode = True
    '        '.RowHeadersWidth = 30
    '        .RowHeadersVisible = False
    '        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    End With

    '    Dim col0 As New DataGridViewCheckBoxColumn
    '    With col0
    '        .HeaderText = "¿ACTIVO?"
    '        .Name = "ACTIVO"
    '        .DataPropertyName = "IDESTADO_REGISTRO"
    '        .Width = 62
    '        .ThreeState = False
    '        .TrueValue = 1
    '        .FalseValue = 0
    '        .Frozen = True
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With
    '    'MyDataGridLista.Columns.Add(col0)

    '    Dim col1 As New DataGridViewTextBoxColumn
    '    With col1
    '        .HeaderText = "ID"
    '        .Name = "ID"
    '        .DataPropertyName = "IDPERSONA"
    '        .ReadOnly = True
    '        .ToolTipText = "Identificador del cliente en la Base de Datos"
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
    '    End With
    '    'MyDataGridLista.Columns.Add(col1)

    '    Dim col2 As New DataGridViewTextBoxColumn
    '    With col2
    '        .HeaderText = "CODIGO"
    '        .Name = "CODIGO"
    '        .DataPropertyName = "CODIGO_CLIENTE"
    '        .ToolTipText = "Código del Cliente"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
    '    End With
    '    'MyDataGridLista.Columns.Add(col2)

    '    Dim Col3 As New DataGridViewTextBoxColumn
    '    With Col3
    '        .HeaderText = "DOCT."
    '        .Name = "DOCUMENTO"
    '        .DataPropertyName = "NU_DOCU_SUNA"
    '        .ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
    '    End With
    '    'MyDataGridLista.Columns.Add(Col3)

    '    Dim col4 As New DataGridViewTextBoxColumn
    '    With col4
    '        .HeaderText = "RAZON SOCIAL"
    '        .Name = "RAZONSOCIAL"
    '        .DataPropertyName = "RAZON_SOCIAL"
    '        .ToolTipText = "Razon Social para Personas Juridicos"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '    End With
    '    'MyDataGridLista.Columns.Add(col4)

    '    Dim col5 As New DataGridViewTextBoxColumn
    '    With col5
    '        .HeaderText = "NOMBRE Y APELLIDOS"
    '        .Name = "NOMBREYAPELLIDO"
    '        .DataPropertyName = "NOMNRES_APELLIDOS"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '    End With
    '    'MyDataGridLista.Columns.Add(col5)

    '    Dim col6 As New DataGridViewTextBoxColumn
    '    With col6
    '        .HeaderText = "TIPO PERSONA"
    '        .Name = "JURIDICAONATURAL"
    '        .DataPropertyName = "IDTIPO_PERSONA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With
    '    'MyDataGridLista.Columns.Add(col6)

    '    Dim col7 As New DataGridViewCheckBoxColumn
    '    With col7
    '        .HeaderText = "CLIENTE CORPORATIVO"
    '        .Name = "CLIENTE_CORPORATIVO"
    '        .DataPropertyName = "CLIENTE_CORPORATIVO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col8 As New DataGridViewTextBoxColumn
    '    With col8
    '        .HeaderText = "GERENTE GENERAL"
    '        .Name = "GERENTE_GENERAL"
    '        .DataPropertyName = "GERENTE_GENERAL"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col9 As New DataGridViewTextBoxColumn
    '    With col9
    '        .HeaderText = "REPRESENTANTE LEGAL"
    '        .Name = "REPRESENTANTE_LEGAL"
    '        .DataPropertyName = "REPRESENTANTE_LEGAL"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col10 As New DataGridViewTextBoxColumn
    '    With col10
    '        .HeaderText = "FECHA INGRESO"
    '        .Name = "FECHA_INGRESO"
    '        .DataPropertyName = "FECHA_INGRESO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col11 As New DataGridViewCheckBoxColumn
    '    With col11
    '        .HeaderText = "PAGO POST FACTURACION"
    '        .Name = "PAGO_POST_FACTURACION"
    '        .DataPropertyName = "PAGO_POST_FACTURACION"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col12 As New DataGridViewTextBoxColumn
    '    With col12
    '        .HeaderText = "EMAIL"
    '        .Name = "EMAIL"
    '        .DataPropertyName = "EMAIL"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col13 As New DataGridViewTextBoxColumn
    '    With col13
    '        .HeaderText = "APELLIDO PATERNO"
    '        .Name = "APELLIDO_PATERNO"
    '        .DataPropertyName = "APELLIDO_PATERNO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col14 As New DataGridViewTextBoxColumn
    '    With col14
    '        .HeaderText = "APELLIDO MATERNO"
    '        .Name = "APELLIDO_MATERNO"
    '        .DataPropertyName = "APELLIDO_MATERNO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col15 As New DataGridViewTextBoxColumn
    '    With col15
    '        .HeaderText = "NOMPRE PERSONA"
    '        .Name = "NOMPRE_PERSONA"
    '        .DataPropertyName = "NOMPRE_PERSONA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col16 As New DataGridViewTextBoxColumn
    '    With col16
    '        .HeaderText = "NOMPRE PERSONA1"
    '        .Name = "NOMPRE_PERSONA1"
    '        .DataPropertyName = "NOMPRE_PERSONA1"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col17 As New DataGridViewTextBoxColumn
    '    With col17
    '        .HeaderText = "FECHA NACIMIENTO"
    '        .Name = "FECHA_NACIMIENTO"
    '        .DataPropertyName = "FECHA_NACIMIENTO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col18 As New DataGridViewTextBoxColumn
    '    With col18
    '        .HeaderText = "SEXO PERSONA"
    '        .Name = "SEXO_PERSONA"
    '        .DataPropertyName = "SEXO_PERSONA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col19 As New DataGridViewCheckBoxColumn
    '    With col19
    '        .HeaderText = "ESMENOREDAD"
    '        .Name = "ESMENOREDAD"
    '        .DataPropertyName = "ESMENOREDAD"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col20 As New DataGridViewCheckBoxColumn
    '    With col20
    '        .HeaderText = "AGENTE RETENCION"
    '        .Name = "AGENTE_RETENCION"
    '        .DataPropertyName = "AGENTE_RETENCION"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col21 As New DataGridViewTextBoxColumn
    '    With col21
    '        .HeaderText = "IDTIPO DOC IDENTIDAD"
    '        .Name = "IDTIPO_DOC_IDENTIDAD"
    '        .DataPropertyName = "IDTIPO_DOC_IDENTIDAD"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col22 As New DataGridViewTextBoxColumn
    '    With col22
    '        .HeaderText = "NU RETE SUNA"
    '        .Name = "NU_RETE_SUNA"
    '        .DataPropertyName = "NU_RETE_SUNA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col23 As New DataGridViewTextBoxColumn
    '    With col23
    '        .HeaderText = "IDRUBRO"
    '        .Name = "IDRUBRO"
    '        .DataPropertyName = "IDRUBRO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col24 As New DataGridViewTextBoxColumn
    '    With col24
    '        .HeaderText = "IDCLASIFICACION PERSONA"
    '        .Name = "IDCLASIFICACION_PERSONA"
    '        .DataPropertyName = "IDCLASIFICACION_PERSONA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col25 As New DataGridViewTextBoxColumn
    '    With col25
    '        .HeaderText = "IDUSUARIO PERSONAL"
    '        .Name = "IDUSUARIO_PERSONAL"
    '        .DataPropertyName = "IDUSUARIO_PERSONAL"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col26 As New DataGridViewTextBoxColumn
    '    With col26
    '        .HeaderText = "IDROL USUARIO"
    '        .Name = "IDROL_USUARIO"
    '        .DataPropertyName = "IDROL_USUARIO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col27 As New DataGridViewTextBoxColumn
    '    With col27
    '        .HeaderText = "IP"
    '        .Name = "IP"
    '        .DataPropertyName = "IP"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col28 As New DataGridViewTextBoxColumn
    '    With col28
    '        .HeaderText = "FECHA REGISTRO"
    '        .Name = "FECHA_REGISTRO"
    '        .DataPropertyName = "FECHA_REGISTRO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col29 As New DataGridViewTextBoxColumn
    '    With col29
    '        .HeaderText = "IDUSUARIO PERSONALMOD"
    '        .Name = "IDUSUARIO_PERSONALMOD"
    '        .DataPropertyName = "IDUSUARIO_PERSONALMOD"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col30 As New DataGridViewTextBoxColumn
    '    With col30
    '        .HeaderText = "IDROL USUARIOMOD"
    '        .Name = "IDROL_USUARIOMOD"
    '        .DataPropertyName = "IDROL_USUARIOMOD"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col31 As New DataGridViewTextBoxColumn
    '    With col31
    '        .HeaderText = "IPMOD"
    '        .Name = "IPMOD"
    '        .DataPropertyName = "IPMOD"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col32 As New DataGridViewTextBoxColumn
    '    With col32
    '        .HeaderText = "FECHA_ACTUALIZACION"
    '        .Name = "FECHA_ACTUALIZACION"
    '        .DataPropertyName = "FECHA_ACTUALIZACION"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col33 As New DataGridViewTextBoxColumn
    '    With col33
    '        .HeaderText = "IDPAIS"
    '        .Name = "IDPAIS"
    '        .DataPropertyName = "IDPAIS"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col34 As New DataGridViewTextBoxColumn
    '    With col34
    '        .HeaderText = "IDDEPARTAMENTO"
    '        .Name = "IDDEPARTAMENTO"
    '        .DataPropertyName = "IDDEPARTAMENTO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col35 As New DataGridViewTextBoxColumn
    '    With col35
    '        .HeaderText = "IDPROVINCIA"
    '        .Name = "IDPROVINCIA"
    '        .DataPropertyName = "IDPROVINCIA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col36 As New DataGridViewTextBoxColumn
    '    With col36
    '        .HeaderText = "IDDISTRITO"
    '        .Name = "IDDISTRITO"
    '        .DataPropertyName = "IDDISTRITO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col37 As New DataGridViewTextBoxColumn
    '    With col37
    '        .HeaderText = "USUARIO"
    '        .Name = "USUARIO"
    '        .DataPropertyName = "USUARIO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col38 As New DataGridViewTextBoxColumn
    '    With col38
    '        .HeaderText = "ROL USUARIO"
    '        .Name = "ROL_USUARIO"
    '        .DataPropertyName = "ROL_USUARIO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col39 As New DataGridViewTextBoxColumn
    '    With col39
    '        .HeaderText = "IDFUNCIONARIO ACTUAL"
    '        .Name = "IDFUNCIONARIO_ACTUAL"
    '        .DataPropertyName = "IDFUNCIONARIO_ACTUAL"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col40 As New DataGridViewTextBoxColumn
    '    With col40
    '        .HeaderText = "FUNCIONARIO"
    '        .Name = "FUNCIONARIO"
    '        .DataPropertyName = "FUNCIONARIO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col41 As New DataGridViewTextBoxColumn
    '    With col41
    '        .HeaderText = "IDTIPO_FACTURACION"
    '        .Name = "IDTIPO_FACTURACION"
    '        .DataPropertyName = "IDTIPO_FACTURACION"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With


    '    Dim col442 As New DataGridViewTextBoxColumn
    '    With col442
    '        .HeaderText = "MONTO_BASE"
    '        .Name = "MONTO_BASE"
    '        .DataPropertyName = "MONTO_BASE"
    '        .ToolTipText = "Monto Base"
    '        .ReadOnly = True
    '        .Visible = False
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col443 As New DataGridViewTextBoxColumn
    '    With col443
    '        .HeaderText = "PORC. DESCTO"
    '        .Name = "PORCENTAJE_DESCUENTO"
    '        .DataPropertyName = "PORCENTAJE_DESCUENTO"
    '        .ToolTipText = "Porc. Descuento"
    '        .ReadOnly = True
    '        .Visible = False
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With
    '    MyDataGridLista.Columns.AddRange(col0, col1, col2, Col3, col4, col5, col6, col7, col8, col9, col10, col11, col12, col13, col14, col15, col16, col17, col18, col19, col20, col21, col22, col23, col24, col25, col26, col27, col28, col29, col30, col31, col32, col33, col34, col35, col36, col37, col38, col39, col40, col41, col442, col443)
    '    '
    '    For i As Integer = 0 To 42
    '        MyDataGridLista.Columns(i).Visible = False
    '    Next

    '    MyDataGridLista.Columns(0).Visible = True
    '    MyDataGridLista.Columns(2).Visible = True
    '    MyDataGridLista.Columns(4).Visible = True
    '    MyDataGridLista.Columns(5).Visible = True
    '    Return MydvListaClientes


    'End Function
#End Region

#Region " FUNCION CARGA LA CARGA DE COMBOS A PARTIR DE UN DATATABLE Y RETORNA UN DATAVIEW"
    Public Function CargarCombo(ByVal MyCombo As ComboBox, ByVal MyDataTable As DataTable, ByVal MyDisplayMenber As String, ByVal MyValueMember As String, ByVal MySelectDefault As Int64) As DataView
        Try
            MyCombo.DataSource = MyDataTable.DefaultView
            MyCombo.DisplayMember = MyDisplayMenber ' "CENTRO_COSTO"
            MyCombo.ValueMember = MyValueMember '"IDCENTRO_COSTO"
            MyCombo.SelectedValue = MySelectDefault

            Return MyDataTable.DefaultView
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de seguridad")
        End Try


    End Function

    Public Function CargarCombo(ByVal MyCombo As ComboBox, ByVal MyDataTable As DataTable, ByVal MyDisplayMenber As String, ByVal MyValueMember As String, ByVal MySelectDefault As String) As DataView
        MyCombo.DataSource = MyDataTable.DefaultView
        MyCombo.DisplayMember = MyDisplayMenber '"CENTRO_COSTO"
        MyCombo.ValueMember = MyValueMember '"IDCENTRO_COSTO"
        MyCombo.SelectedValue = MySelectDefault

        Return MyDataTable.DefaultView

    End Function

    Public Function CargarCombo(ByVal MyCombo As ComboBox, ByVal MyDataTable As DataTable, ByVal MyDisplayMenber As String, ByVal MyValueMember As String) As DataView
        MyCombo.DataSource = MyDataTable.DefaultView
        MyCombo.DisplayMember = MyDisplayMenber ' "CENTRO_COSTO"
        MyCombo.ValueMember = MyValueMember '"IDCENTRO_COSTO"
        'MyCombo.SelectedValue = MySelectDefault

        Return MyDataTable.DefaultView

    End Function

    Public Function CargarCombo(ByVal MyCombo As ComboBox, ByVal MyDataView As DataView, ByVal MyDisplayMenber As String, ByVal MyValueMember As String, ByVal MySelectDefault As Int64) As DataView
        MyCombo.DataSource = MyDataView
        MyCombo.DisplayMember = MyDisplayMenber ' "CENTRO_COSTO"
        MyCombo.ValueMember = MyValueMember '"IDCENTRO_COSTO"
        MyCombo.SelectedIndex = MySelectDefault
        Return MyDataView

    End Function
#End Region

#Region " FUNCION PARA LA CARGA DE ARTICULOS EN ACUERDO COMERCIAL "

    Public Function CargarArticulos(ByVal MyDataGridLista As DataGridView) As DataView
        'datahelper
        'Dim rstArticulos As ADODB.Recordset
        'Dim dtArticulos As New DataTable
        'Dim MydvListaArticulos As DataView

        'Dim MyObjectArticulos As Object() = {"PKG_IVOPERSONA.SP_LISTA_ARTICULOS", 0}
        'rstArticulos = VOCONTROLUSUARIO.fnSQLQuery(MyObjectArticulos)
        'Dim da As New OleDbDataAdapter
        'da.Fill(dtArticulos, rstArticulos)
        'MydvListaArticulos = dtArticulos.DefaultView
        'MyDataGridLista.Columns.Clear()
        'MydvListaArticulos = dtArticulos.DefaultView

        Dim db As New BaseDatos
        db.Conectar()
        db.CrearComando("PKG_IVOPERSONA.SP_LISTA_ARTICULOS", CommandType.StoredProcedure)
        db.AsignarParametro("oCUR_ARTICULOS", OracleClient.OracleType.Cursor)
        db.Desconectar()
        Dim dtArticulos As DataTable = db.EjecutarDataTable()
        Dim MydvListaArticulos As DataView = dtArticulos.DefaultView
        MyDataGridLista.Columns.Clear()

        With MyDataGridLista
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = MydvListaArticulos
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .HeaderText = "IDARTICULOS"
            .Name = "IDARTICULOS"
            .DataPropertyName = "IDARTICULOS"
            .Frozen = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .HeaderText = "ARTICULO"
            .Name = "NOMBRE_ARTICULO"
            .DataPropertyName = "NOMBRE_ARTICULO"
            .ReadOnly = True
            .ToolTipText = "Nombre del Articulo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            .Frozen = True
        End With

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .HeaderText = "PRECIO_BASE"
            .Name = "PRECIO_BASE"
            .DataPropertyName = "MONTO"
            .ToolTipText = "Precio Base del Artìculo"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
        End With

        Dim Col3 As New DataGridViewTextBoxColumn
        With Col3
            .HeaderText = "DESCUENTO"
            .Name = "DESCUENTO"
            .DataPropertyName = "DESCUENTO"
            .ToolTipText = "Descuento al Precio Base del Artículo."
            .ReadOnly = False
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim Col4 As New DataGridViewTextBoxColumn
        With Col4
            .HeaderText = "PRECIO_FINAL"
            .Name = "PRECIO_FINAL"
            .DataPropertyName = "PRECIO_FINAL"
            .ToolTipText = "Precio Final del Artículo."
            .ReadOnly = False
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "N4"
        End With

        MyDataGridLista.Columns.AddRange(col0, col1, col2, Col3, Col4)
        MyDataGridLista.Columns(0).Visible = False

        Return MydvListaArticulos

    End Function

#End Region

#Region " FUNCION PARA LA LECTURA DE DIRECCION Y DATOS DEPENDIENTES DE CLIENTES PARA CTACTE "
 

    Public Function LeerDireccionRubro(ByVal CodigoCliente As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_DIRECCION_PERSONA", CommandType.StoredProcedure)
            db.AsignarParametro("iCODIGO_PERSONA", CodigoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_DIRECCION", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_RUBRO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_CONDICION_PAGO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region

#Region " FUNCION PARA LA CARGA DEL PRIMER RECORSET PARA LA CARGA DE GRILLAS DE CTACTE."
    'Public Function CargaRecorsetCtaCte2009_eliminarlo(ByVal NroSolicitud As Integer) As ADODB.Recordset
    '    Dim rstCtaCte As ADODB.Recordset
    '    Dim MyObjectArticulos As Object() = {"PKG_IVOPERSONA.SP_GRILLAS_CTACTE", 4, NroSolicitud, 1}
    '    rstCtaCte = VOCONTROLUSUARIO.fnSQLQuery(MyObjectArticulos)
    '    Return rstCtaCte
    'End Function

    Public Function CargaRecorsetCtaCte(ByVal NroSolicitud As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_GRILLAS_CTACTE", CommandType.StoredProcedure)
            db.AsignarParametro("iIDSOLICITUD", NroSolicitud, OracleClient.OracleType.Int32)
            db.AsignarParametro("oCUR_RUTAS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_DOCUMENTOS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region

#Region " CARGA DE UNIDADES PARA EL MODULO DE TARIFARIO "
    ''' <summary>
    ''' Carga las unidades para tarifario, como PESO y VOLUMEN
    ''' </summary>
    ''' <param name="MyDataGridLista"></param>
    ''' <remarks></remarks>
    Public Sub CargarUnidades(ByVal MyDataGridLista As DataGridView)
        'datahelper
        'Dim rstUnidades As ADODB.Recordset
        'Dim dtUnidades As New DataTable
        'Dim MydvListaUnidades As DataView

        'Dim MyObjectArticulos As Object() = {"PKG_IVOPERSONA.SP_LISTA_UNIDADES", 0}
        'rstUnidades = VOCONTROLUSUARIO.fnSQLQuery(MyObjectArticulos)
        'Dim da As New OleDbDataAdapter
        'da.Fill(dtUnidades, rstUnidades)
        'MydvListaUnidades = dtUnidades.DefaultView
        'MyDataGridLista.Columns.Clear()

        'MyDataGridLista.Columns.Clear()
        'MydvListaUnidades = dtUnidades.DefaultView
        Dim db As New BaseDatos
        db.Conectar()
        db.CrearComando("PKG_IVOPERSONA.SP_LISTA_UNIDADES", CommandType.StoredProcedure)
        db.AsignarParametro("oCUR_UNIDADES", OracleClient.OracleType.Cursor)
        db.Desconectar()
        Dim dtUnidades As DataTable = db.EjecutarDataTable
        Dim MydvListaUnidades As DataView = dtUnidades.DefaultView

        With MyDataGridLista
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = MydvListaUnidades
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim col00 As New DataGridViewTextBoxColumn
        With col00
            .HeaderText = "CONCEPTO"
            .Name = "CONCEPTO"
            .DataPropertyName = "CONCEPTO"
            .Frozen = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With
        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .HeaderText = "UNIDAD"
            .Name = "UNIDAD"
            .DataPropertyName = "UNIDAD"
            .Frozen = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With
        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .HeaderText = "ID_UNIDAD"
            .Name = "ID_UNIDAD"
            .DataPropertyName = "ID_UNIDAD"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .HeaderText = "PRECIO_BASE"
            .Name = "PRECIO_BASE"
            .DataPropertyName = "PRECIO_BASE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .HeaderText = "INICIO"
            .Name = "INICIO"
            .DataPropertyName = "INICIO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .HeaderText = "FIN"
            .Name = "FIN"
            .DataPropertyName = "FIN"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .HeaderText = "DESC"
            .Name = "DESC"
            .DataPropertyName = "DESC"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim col6 As New DataGridViewTextBoxColumn
        With col6
            .HeaderText = "PRECIO_FINAL"
            .Name = "PRECIO_FINAL"
            .DataPropertyName = "PRECIO_FINAL"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        MyDataGridLista.Columns.AddRange(col00, col0, col1, col2, col3, col4, col5, col6)
        MyDataGridLista.Columns(2).Visible = False

    End Sub
    ' Creado por Tepsa la variable 
    Public Sub CargarTarifasCondicional(ByVal MyDataGridLista As DataGridView, ByVal iid_tarifacliente As Long)
        Try
            'datahelper
            'Dim rstUnidades As ADODB.Recordset
            'Dim dtUnidades As New DataTable
            'Dim MydvListaUnidades As DataView

            'Dim MyObjectArticulos As Object() = {"PKG_IVOPERSONA.SP_LISTA_TARIFA_CONDICIONAL", 4, iid_tarifacliente, 1} 'omendoza
            'rstUnidades = VOCONTROLUSUARIO.fnSQLQuery(MyObjectArticulos)
            'Dim da As New OleDbDataAdapter
            'da.Fill(dtUnidades, rstUnidades)
            'MydvListaUnidades = dtUnidades.DefaultView
            'MyDataGridLista.Columns.Clear()

            'MyDataGridLista.Columns.Clear()
            'MydvListaUnidades = dtUnidades.DefaultView

            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_TARIFA_CONDICIONAL", CommandType.StoredProcedure)
            db.AsignarParametro("iidtarifa_carga_cliente", iid_tarifacliente, OracleClient.OracleType.Number)
            db.AsignarParametro("oCUR_TarifaCondicional", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dtUnidades As DataTable = db.EjecutarDataTable
            Dim MydvListaUnidades As DataView = dtUnidades.DefaultView
            MyDataGridLista.Columns.Clear()

            With MyDataGridLista
                '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .DataSource = MydvListaUnidades
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .VirtualMode = True
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            '
            Dim col00 As New DataGridViewTextBoxColumn  '0
            With col00
                .HeaderText = "CONCEPTO"
                .Name = "CONCEPTO"
                .DataPropertyName = "CONCEPTO"
                .Frozen = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            Dim col0 As New DataGridViewTextBoxColumn   '1
            With col0
                .HeaderText = "UNIDAD"
                .Name = "UNIDAD"
                .DataPropertyName = "UNIDAD"
                .Frozen = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            Dim col1 As New DataGridViewTextBoxColumn   '2
            With col1
                .HeaderText = "ID_UNIDAD"
                .Name = "ID_UNIDAD"
                .DataPropertyName = "ID_UNIDAD"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            Dim col2 As New DataGridViewTextBoxColumn   '3
            With col2
                .HeaderText = "PRECIO_BASE"
                .Name = "PRECIO_BASE"
                .DataPropertyName = "PRECIO_BASE"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            Dim col3 As New DataGridViewTextBoxColumn   '4
            With col3
                .HeaderText = "INICIO"
                .Name = "INICIO"
                .DataPropertyName = "INICIO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            Dim col4 As New DataGridViewTextBoxColumn   '5
            With col4
                .HeaderText = "FIN"
                .Name = "FIN"
                .DataPropertyName = "FIN"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            Dim col5 As New DataGridViewTextBoxColumn   '6
            With col5
                .HeaderText = "DESC"
                .Name = "DESC"
                .DataPropertyName = "DESC"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            Dim col6 As New DataGridViewTextBoxColumn   '7
            With col6
                .HeaderText = "PRECIO_FINAL"
                .Name = "PRECIO_FINAL"
                .DataPropertyName = "PRECIO_FINAL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            'Ingresado por Tepsa 
            Dim col71 As New DataGridViewTextBoxColumn   '8
            With col71
                .HeaderText = "id_unidad"
                .Name = "id_unidad"
                .DataPropertyName = "id_unidad"
                .Visible = False
                .ReadOnly = False
            End With

            MyDataGridLista.Columns.AddRange(col00, col0, col1, col2, col3, col4, col5, col6, col71)
            MyDataGridLista.Columns(2).Visible = False

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Sub
#End Region

#Region " CARGA DE ORIGEN Y DESTINO A COMBOS PARA TARIFARIO "
    'Public Function CargarOrigenDestino2009_eliminarlo() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_TARIFACARGA", 0}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function CargarOrigenDestino() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOITINERARIOS.SP_LISTA_TARIFACARGA", CommandType.StoredProcedure)
            db.AsignarParametro("cur_tarifas", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_unidad", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_articulos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_detalle", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region

#Region " CARGA TARIFARIO POR CLIENTE "
    Public Function CargarTarifaCliente(ByVal CodigoCliente As String, ByVal MyGrilla As DataGridView) As DataView
        Try
            'datahelper
            'Dim rstTarifasCliente As ADODB.Recordset
            'Dim dt As New DataTable
            'Dim Mydv As New DataView
            'Dim da As New OleDbDataAdapter
            '
            'MyGrilla.Columns.Clear()
            '
            'Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_LISTA_TARIFA_CLIENTE", 4, CodigoCliente, 2}
            'Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_LISTA_TARIFA_CLIENTE_1", 4, CodigoCliente, 2}
            'rstTarifasCliente = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
            'da.Fill(dt, rstTarifasCliente)
            'Mydv = dt.DefaultView
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_TARIFA_CLIENTE_1", CommandType.StoredProcedure)
            db.AsignarParametro("VI_CODIGOCLIENTE", CodigoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_TARIFA_CLIENTE", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            Dim Mydv As New DataView
            Mydv = dt.DefaultView

            MyGrilla.Columns.Clear()
            With MyGrilla
                '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .DataSource = Mydv
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .VirtualMode = True
                '.RowHeadersWidth = 30
                .RowHeadersVisible = False
                .ReadOnly = True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            ' 
            Dim IDTARIFAS_CARGA_CLIENTE As New DataGridViewTextBoxColumn
            With IDTARIFAS_CARGA_CLIENTE
                .DisplayIndex = 0
                .HeaderText = "Id Tarifa Cliente"
                .Name = "IDTARIFAS_CARGA_CLIENTE"
                .DataPropertyName = "IDTARIFAS_CARGA_CLIENTE"
                .Visible = False
                .Frozen = True
            End With

            Dim IDPERSONA As New DataGridViewTextBoxColumn
            With IDPERSONA
                .DisplayIndex = 1
                .HeaderText = "Id Persona"
                .Name = "IDPERSONA"
                .DataPropertyName = "IDPERSONA"
                .Visible = False
                .Frozen = True
            End With

            Dim IDUNIDAD_AGENCIA As New DataGridViewTextBoxColumn
            With IDUNIDAD_AGENCIA
                .DisplayIndex = 2
                .HeaderText = "Id Unidad Agencia Origen"
                .Name = "IDUNIDAD_AGENCIA"
                .DataPropertyName = "IDUNIDAD_AGENCIA"
                .Visible = False
                .Frozen = True
            End With

            Dim IDUNIDAD_AGENCIA_DESTINO As New DataGridViewTextBoxColumn
            With IDUNIDAD_AGENCIA_DESTINO
                .DisplayIndex = 3
                .HeaderText = "Id Unidad Agencia DESTINO"
                .Name = "IDUNIDAD_AGENCIA_DESTINO"
                .DataPropertyName = "IDUNIDAD_AGENCIA_DESTINO"
                .Visible = False
                .Frozen = True
            End With
            ' Datos mostrados en la tarifa 
            Dim ORIGEN As New DataGridViewTextBoxColumn
            With ORIGEN
                .DisplayIndex = 4
                .HeaderText = "Origen"
                .Name = "ORIGEN"
                .DataPropertyName = "ORIGEN"
                .ToolTipText = "Ciudad Origen del Documento"
                .ReadOnly = True
                .Frozen = True
            End With
            '
            Dim DESTINO As New DataGridViewTextBoxColumn
            With DESTINO
                .DisplayIndex = 5
                .HeaderText = "Destino"
                .Name = "DESTINO"
                .DataPropertyName = "DESTINO"
                .ToolTipText = "Ciudad destino del Documento"
                .ReadOnly = True
                .Frozen = True
            End With
            ' 
            Dim pre_base_publica As New DataGridViewTextBoxColumn
            With pre_base_publica
                .DisplayIndex = 6
                .HeaderText = "Pre. Base Público"
                .Name = "pre_base_publica"
                .DataPropertyName = "pre_base_publica"
                .ToolTipText = "Precio base del tarifario público"
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            '
            Dim pre_peso_publica As New DataGridViewTextBoxColumn
            With pre_peso_publica
                .DisplayIndex = 7
                .HeaderText = "Pre.Peso Público"
                .Name = "pre_peso_publica"
                .DataPropertyName = "pre_peso_publica"
                .ToolTipText = "Precio por peso del tarifario público"
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            '
            Dim pre_volumne_publica As New DataGridViewTextBoxColumn
            With pre_volumne_publica
                .DisplayIndex = 8
                .HeaderText = "Pre.Volumen Público"
                .Name = "pre_volumne_publica"
                .DataPropertyName = "pre_volumne_publica"
                .ToolTipText = "Precio por volumen del tarifario público"
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            '---
            Dim pre_x_sobre_publica As New DataGridViewTextBoxColumn
            With pre_x_sobre_publica
                .DisplayIndex = 9
                .HeaderText = "Pre.Sobre Público"
                .Name = "pre_x_sobre_publica"
                .DataPropertyName = "pre_x_sobre_publica"
                .ToolTipText = "Precio por sobre del tarifario público"
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            '--
            Dim porc_descuento As New DataGridViewTextBoxColumn
            With porc_descuento
                .DisplayIndex = 10
                .HeaderText = "% Descuento"
                .Name = "porc_descuento"
                .DataPropertyName = "porc_descuento"
                .ToolTipText = "% descuento cliente"
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            '---
            Dim Neto_base As New DataGridViewTextBoxColumn
            With Neto_base
                .DisplayIndex = 11
                .HeaderText = "Pre. Base Neto"
                .Name = "Neto_base"
                .DataPropertyName = "Neto_base"
                .ToolTipText = "Precio base del tarifario neto para el cliente"
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            '---------
            Dim peso_neto As New DataGridViewTextBoxColumn
            With peso_neto
                .DisplayIndex = 12
                .HeaderText = "Pre. Peso Neto"
                .Name = "peso_neto"
                .DataPropertyName = "peso_neto"
                .ToolTipText = "Precio por peso del tarifario neto para el cliente"
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            '----
            Dim volumen_neto As New DataGridViewTextBoxColumn
            With volumen_neto
                .DisplayIndex = 13
                .HeaderText = "Pre. Volumen Neto"
                .Name = "volumen_neto"
                .DataPropertyName = "volumen_neto"
                .ToolTipText = "Precio por volimen del tarifario neto para el cliente"
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            '------
            Dim sobre_neto As New DataGridViewTextBoxColumn
            With sobre_neto
                .DisplayIndex = 14
                .HeaderText = "Pre. Sobre Neto"
                .Name = "sobre_neto"
                .DataPropertyName = "sobre_neto"
                .ToolTipText = "Precio por Sobre del tarifario neto para el cliente"
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            '-------
            Dim pre_base_pers As New DataGridViewTextBoxColumn
            With pre_base_pers
                .DisplayIndex = 15
                .HeaderText = "Pre.Base Pers."
                .Name = "pre_base_pers"
                .DataPropertyName = "pre_base_pers"
                .ToolTipText = "Precio base personalizado para el cliente"
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            '-------
            Dim pre_x_peso_per As New DataGridViewTextBoxColumn
            With pre_x_peso_per
                .DisplayIndex = 16
                .HeaderText = "Pre. x peso Pers."
                .Name = "pre_x_peso_per"
                .DataPropertyName = "pre_x_peso_per"
                .ToolTipText = "Precio peso personalizado para el cliente"
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            '-------
            Dim pre_x_volumen_pers As New DataGridViewTextBoxColumn
            With pre_x_volumen_pers
                .DisplayIndex = 17
                .HeaderText = "Pre. x volumen Pers."
                .Name = "pre_x_volumen_pers"
                .DataPropertyName = "pre_x_volumen_pers"
                .ToolTipText = "Precio volumen personalizado para el cliente"
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            '---
            Dim pre_x_sobre_pers As New DataGridViewTextBoxColumn
            With pre_x_sobre_pers
                .DisplayIndex = 18
                .HeaderText = "Pre. x sobre Pers."
                .Name = "pre_x_sobre_pers"
                .DataPropertyName = "pre_x_sobre_pers"
                .ToolTipText = "Precio sobre personalizado para el cliente"
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            '---
            MyGrilla.Columns.AddRange(IDTARIFAS_CARGA_CLIENTE, IDPERSONA, IDUNIDAD_AGENCIA, IDUNIDAD_AGENCIA_DESTINO, ORIGEN, DESTINO, _
                                      pre_base_publica, pre_peso_publica, pre_volumne_publica, pre_x_sobre_publica, porc_descuento, Neto_base, _
                                      peso_neto, volumen_neto, sobre_neto, pre_base_pers, pre_x_peso_per, pre_x_volumen_pers, pre_x_sobre_pers)
            '
            '
            '
            'MyGrilla.Columns(0).Visible = False 'Id Tarifa por Cliente
            'MyGrilla.Columns(1).Visible = False 'Id Cliente
            'MyGrilla.Columns(2).Visible = False 'Id Orige
            '' MyGrilla.Columns(4).Visible = False 'Id Destino  ' Modificado 11/12/2008 
            '   MyGrilla.Columns(3).Visible = False 'Id Destino
            ' 
            '
            'For i As Integer = 19 To 31 ' 10/12/2008 - Se incrementa en un 1 (en vez de 29 a 30) 
            '    MyGrilla.Columns(i).Visible = False 'Id Destino
            'Next
            '
            Return Mydv
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function CargarArticulos_x_cliente2009_eliminarlo(ByVal MyDataGridLista As DataGridView, _
    '                                      ByVal icodigo_cliente As String, _
    '                                      ByVal iidtarifa_cliente As Integer, _
    '                                      ByVal iagencia_origen As Integer, _
    '                                      ByVal iagencia_destino As Integer) As DataView   ' Tepsa
    'Dim rstArticulos As ADODB.Recordset
    'Dim dtArticulos As New DataTable
    'Dim MydvListaArticulos As DataView
    'icodigo_cliente = IIf(icodigo_cliente = "" Or IsDBNull(icodigo_cliente) = True, "null", icodigo_cliente)
    'Dim MyObjectArticulos As Object() = {"PKG_IVOPERSONA.SP_LISTA_ARTICULOS_DETALLE ", 10, icodigo_cliente, 2, iidtarifa_cliente, 1, iagencia_origen, 1, iagencia_destino, 1}
    'rstArticulos = VOCONTROLUSUARIO.fnSQLQuery(MyObjectArticulos)
    'Dim da As New OleDbDataAdapter
    'da.Fill(dtArticulos, rstArticulos)
    'MydvListaArticulos = dtArticulos.DefaultView
    'MyDataGridLista.Columns.Clear()

    'MydvListaArticulos = dtArticulos.DefaultView

    'With MyDataGridLista
    '    '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
    '    .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    '    .Font = New Font("Arial", 8.0!, FontStyle.Regular)
    '    .AllowUserToOrderColumns = True
    '    .AllowUserToDeleteRows = False
    '    .AllowUserToAddRows = False
    '    .AutoGenerateColumns = False
    '    .DataSource = MydvListaArticulos
    '    .DefaultCellStyle.WrapMode = DataGridViewTriState.True
    '    .SelectionMode = DataGridViewSelectionMode.CellSelect
    '    .VirtualMode = True
    '    .RowHeadersVisible = False
    '    .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    'End With

    'Dim col0 As New DataGridViewTextBoxColumn
    'With col0
    '    .HeaderText = "IDARTICULOS"
    '    .Name = "IDARTICULOS"
    '    .DataPropertyName = "IDARTICULOS"
    '    .Frozen = True
    '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    'End With

    'Dim col1 As New DataGridViewTextBoxColumn
    'With col1
    '    .HeaderText = "ARTICULO"
    '    .Name = "NOMBRE_ARTICULO"
    '    .DataPropertyName = "NOMBRE_ARTICULO"
    '    .ReadOnly = True
    '    .ToolTipText = "Nombre del Articulo"
    '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
    '    .Frozen = True
    'End With

    'Dim col2 As New DataGridViewTextBoxColumn
    'With col2
    '    .HeaderText = "PRECIO_BASE"
    '    .Name = "PRECIO_BASE"
    '    .DataPropertyName = "MONTO"
    '    .ToolTipText = "Precio Base del Artìculo"
    '    .ReadOnly = True
    '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '    .DefaultCellStyle.Format = "N2"
    '    .DefaultCellStyle.NullValue = "0,00"
    'End With

    'Dim Col3 As New DataGridViewTextBoxColumn
    'With Col3
    '    .HeaderText = "DESCUENTO"
    '    .Name = "DESCUENTO"
    '    .DataPropertyName = "DESCUENTO"
    '    .ToolTipText = "Descuento al Precio Base del Artículo."
    '    .ReadOnly = False
    '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    'End With

    'Dim Col4 As New DataGridViewTextBoxColumn
    'With Col4
    '    .HeaderText = "PRECIO_FINAL"
    '    .Name = "PRECIO_FINAL"
    '    .DataPropertyName = "PRECIO_FINAL"
    '    .ToolTipText = "Precio Final del Artículo."
    '    .ReadOnly = False
    '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '    .DefaultCellStyle.Format = "N4"
    'End With

    'MyDataGridLista.Columns.AddRange(col0, col1, col2, Col3, Col4)
    'MyDataGridLista.Columns(0).Visible = False

    'Return MydvListaArticulos

    'End Function

    Public Function CargarArticulos_x_cliente(ByVal MyDataGridLista As DataGridView, _
                                              ByVal icodigo_cliente As String, _
                                              ByVal iidtarifa_cliente As Integer, _
                                              ByVal iagencia_origen As Integer, _
                                              ByVal iagencia_destino As Integer) As DataView   ' Tepsa

        Try
            'datahelper
            'Dim rstArticulos As ADODB.Recordset
            'Dim dtArticulos As New DataTable
            'Dim MydvListaArticulos As DataView
            'icodigo_cliente = IIf(icodigo_cliente = "" Or IsDBNull(icodigo_cliente) = True, "null", icodigo_cliente)
            'Dim MyObjectArticulos As Object() = {"PKG_IVOPERSONA.SP_LISTA_ARTICULOS_DETALLE ", 10, icodigo_cliente, 2, iidtarifa_cliente, 1, iagencia_origen, 1, iagencia_destino, 1}
            'rstArticulos = VOCONTROLUSUARIO.fnSQLQuery(MyObjectArticulos)
            'Dim da As New OleDbDataAdapter
            'da.Fill(dtArticulos, rstArticulos)
            'MydvListaArticulos = dtArticulos.DefaultView
            'MyDataGridLista.Columns.Clear()
            'MydvListaArticulos = dtArticulos.DefaultView
            Dim dtArticulos As New DataTable
            Dim MydvListaArticulos As DataView
            icodigo_cliente = IIf(icodigo_cliente = "" Or IsDBNull(icodigo_cliente) = True, "null", icodigo_cliente)

            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_ARTICULOS_DETALLE", CommandType.StoredProcedure)
            db.AsignarParametro("icodigo_cliente", icodigo_cliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("IID_TARIFA_CARGA_CLIENTE", iidtarifa_cliente, OracleClient.OracleType.Number)
            db.AsignarParametro("IID_AGENCIA_ORIGEN", iagencia_origen, OracleClient.OracleType.Number)
            db.AsignarParametro("IID_AGENCIA_DESTINO", iagencia_destino, OracleClient.OracleType.Number)
            db.AsignarParametro("oCUR_ARTICULOS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            dtArticulos = db.EjecutarDataTable
            MydvListaArticulos = dtArticulos.DefaultView
            MyDataGridLista.Columns.Clear()
            MydvListaArticulos = dtArticulos.DefaultView

            With MyDataGridLista
                '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .DataSource = MydvListaArticulos
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .VirtualMode = True
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            Dim col0 As New DataGridViewTextBoxColumn
            With col0
                .HeaderText = "IDARTICULOS"
                .Name = "IDARTICULOS"
                .DataPropertyName = "IDARTICULOS"
                .Frozen = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col1 As New DataGridViewTextBoxColumn
            With col1
                .HeaderText = "ARTICULO"
                .Name = "NOMBRE_ARTICULO"
                .DataPropertyName = "NOMBRE_ARTICULO"
                .ReadOnly = True
                .ToolTipText = "Nombre del Articulo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                .Frozen = True
            End With

            Dim col2 As New DataGridViewTextBoxColumn
            With col2
                .HeaderText = "PRECIO_BASE"
                .Name = "PRECIO_BASE"
                .DataPropertyName = "MONTO"
                .ToolTipText = "Precio Base del Artìculo"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
            End With

            Dim Col3 As New DataGridViewTextBoxColumn
            With Col3
                .HeaderText = "DESCUENTO"
                .Name = "DESCUENTO"
                .DataPropertyName = "DESCUENTO"
                .ToolTipText = "Descuento al Precio Base del Artículo."
                .ReadOnly = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With

            Dim Col4 As New DataGridViewTextBoxColumn
            With Col4
                .HeaderText = "PRECIO_FINAL"
                .Name = "PRECIO_FINAL"
                .DataPropertyName = "PRECIO_FINAL"
                .ToolTipText = "Precio Final del Artículo."
                .ReadOnly = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Format = "N4"
            End With

            MyDataGridLista.Columns.AddRange(col0, col1, col2, Col3, Col4)
            MyDataGridLista.Columns(0).Visible = False

            Return MydvListaArticulos

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

#End Region

#Region " SEPARACION DE TEXTO EN PALABRAS "
    Private Sub Separacion(ByVal MyTreeView As TreeView)
        For i As Integer = 0 To MyTreeView.Nodes(0).Nodes.Count - 1
            If MyTreeView.Nodes(0).Nodes(i).Checked = True Then
                Dim NombreCompleto As String
                NombreCompleto = MyTreeView.Nodes(0).Nodes(i).Text
                MessageBox.Show("*" & NombreCompleto & "*", "NombreCompleto")
                Dim PrimerEspacio As Integer = InStr(NombreCompleto, " ")
                Dim Nombre As String = Mid(NombreCompleto, 1, PrimerEspacio - 1)
                MessageBox.Show("*" & Nombre & "*", "Nombre")
                NombreCompleto = NombreCompleto.Substring(PrimerEspacio)
                'MessageBox.Show("*" & NombreCompleto & "*", "NombreCompleto")
                Dim SegundoEspacio As Integer = InStr(NombreCompleto, " ")
                Dim ApellidoPaterno As String = Mid(NombreCompleto, 1, SegundoEspacio - 1)
                MessageBox.Show("*" & ApellidoPaterno & "*", "ApellidoPaterno")
                NombreCompleto = NombreCompleto.Substring(SegundoEspacio)
                Dim ApellidoMaterno As String
                ApellidoMaterno = NombreCompleto
                MessageBox.Show("*" & ApellidoMaterno & "*", "ApellidoMaterno")
            End If
        Next
    End Sub
#End Region

#Region " FUNCION PARA LA CARGA DE CLIENTES EN LA GRILLA POR FUNCIONARIO"
    'Public Function CargarGrillaClientes(ByVal MyDataGridLista As DataGridView, ByVal MyFuncionario As String) As DataView
    '    Dim rstListaClientes As ADODB.Recordset
    '    Dim dtListaClientes As New DataTable
    '    MyFuncionario = Replace(MyFuncionario, ",", " ")
    '    'lamas
    '    Dim Myobj As Object() = {"SP_LISTA_CLIENTES_FUNCIONARIO", 4, MyFuncionario, 2}
    '    'Dim Myobj As Object() = {"PKG_IVOPERSONA.SP_LISTA_CLIENTES_FUNCIONARIO1", 4, MyFuncionario, 2}
    '    rstListaClientes = VOCONTROLUSUARIO.fnSQLQuery(Myobj)
    '    Dim da As New OleDbDataAdapter
    '    da.Fill(dtListaClientes, rstListaClientes)
    '    Dim MydvListaClientes As DataView

    '    MydvListaClientes = dtListaClientes.DefaultView
    '    With MyDataGridLista
    '        '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
    '        .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    '        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
    '        .AllowUserToOrderColumns = True
    '        .AllowUserToDeleteRows = False
    '        .AllowUserToAddRows = False
    '        .AutoGenerateColumns = False
    '        .DataSource = MydvListaClientes
    '        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
    '        .SelectionMode = DataGridViewSelectionMode.CellSelect
    '        .VirtualMode = True
    '        '.RowHeadersWidth = 30
    '        .RowHeadersVisible = False
    '        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    End With

    '    Dim col0 As New DataGridViewCheckBoxColumn
    '    With col0
    '        .HeaderText = "¿ACTIVO?"
    '        .Name = "ACTIVO"
    '        .DataPropertyName = "IDESTADO_REGISTRO"
    '        .Width = 62
    '        .ThreeState = False
    '        .TrueValue = 1
    '        .FalseValue = 0
    '        .Frozen = True
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With
    '    'MyDataGridLista.Columns.Add(col0)

    '    Dim col1 As New DataGridViewTextBoxColumn
    '    With col1
    '        .HeaderText = "ID"
    '        .Name = "ID"
    '        .DataPropertyName = "IDPERSONA"
    '        .ReadOnly = True
    '        .ToolTipText = "Identificador del cliente en la Base de Datos"
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
    '    End With
    '    'MyDataGridLista.Columns.Add(col1)

    '    Dim col2 As New DataGridViewTextBoxColumn
    '    With col2
    '        .HeaderText = "CODIGO"
    '        .Name = "CODIGO"
    '        .DataPropertyName = "CODIGO_CLIENTE"
    '        .ToolTipText = "Código del Cliente"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
    '    End With
    '    'MyDataGridLista.Columns.Add(col2)

    '    Dim Col3 As New DataGridViewTextBoxColumn
    '    With Col3
    '        .HeaderText = "DOCT."
    '        .Name = "DOCUMENTO"
    '        .DataPropertyName = "NU_DOCU_SUNA"
    '        .ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
    '    End With
    '    'MyDataGridLista.Columns.Add(Col3)

    '    Dim col4 As New DataGridViewTextBoxColumn
    '    With col4
    '        .HeaderText = "RAZON SOCIAL"
    '        .Name = "RAZONSOCIAL"
    '        .DataPropertyName = "RAZON_SOCIAL"
    '        .ToolTipText = "Razon Social para Personas Juridicos"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '    End With
    '    'MyDataGridLista.Columns.Add(col4)

    '    Dim col5 As New DataGridViewTextBoxColumn
    '    With col5
    '        .HeaderText = "NOMBRE Y APELLIDOS"
    '        .Name = "NOMBREYAPELLIDO"
    '        .DataPropertyName = "NOMNRES_APELLIDOS"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '    End With
    '    'MyDataGridLista.Columns.Add(col5)

    '    Dim col6 As New DataGridViewTextBoxColumn
    '    With col6
    '        .HeaderText = "TIPO PERSONA"
    '        .Name = "JURIDICAONATURAL"
    '        .DataPropertyName = "IDTIPO_PERSONA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With
    '    'MyDataGridLista.Columns.Add(col6)

    '    Dim col7 As New DataGridViewCheckBoxColumn
    '    With col7
    '        .HeaderText = "CLIENTE CORPORATIVO"
    '        .Name = "CLIENTE_CORPORATIVO"
    '        .DataPropertyName = "CLIENTE_CORPORATIVO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col8 As New DataGridViewTextBoxColumn
    '    With col8
    '        .HeaderText = "GERENTE GENERAL"
    '        .Name = "GERENTE_GENERAL"
    '        .DataPropertyName = "GERENTE_GENERAL"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col9 As New DataGridViewTextBoxColumn
    '    With col9
    '        .HeaderText = "REPRESENTANTE LEGAL"
    '        .Name = "REPRESENTANTE_LEGAL"
    '        .DataPropertyName = "REPRESENTANTE_LEGAL"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col10 As New DataGridViewTextBoxColumn
    '    With col10
    '        .HeaderText = "FECHA INGRESO"
    '        .Name = "FECHA_INGRESO"
    '        .DataPropertyName = "FECHA_INGRESO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col11 As New DataGridViewCheckBoxColumn
    '    With col11
    '        .HeaderText = "PAGO POST FACTURACION"
    '        .Name = "PAGO_POST_FACTURACION"
    '        .DataPropertyName = "PAGO_POST_FACTURACION"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col12 As New DataGridViewTextBoxColumn
    '    With col12
    '        .HeaderText = "EMAIL"
    '        .Name = "EMAIL"
    '        .DataPropertyName = "EMAIL"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col13 As New DataGridViewTextBoxColumn
    '    With col13
    '        .HeaderText = "APELLIDO PATERNO"
    '        .Name = "APELLIDO_PATERNO"
    '        .DataPropertyName = "APELLIDO_PATERNO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col14 As New DataGridViewTextBoxColumn
    '    With col14
    '        .HeaderText = "APELLIDO MATERNO"
    '        .Name = "APELLIDO_MATERNO"
    '        .DataPropertyName = "APELLIDO_MATERNO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col15 As New DataGridViewTextBoxColumn
    '    With col15
    '        .HeaderText = "NOMPRE PERSONA"
    '        .Name = "NOMPRE_PERSONA"
    '        .DataPropertyName = "NOMPRE_PERSONA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col16 As New DataGridViewTextBoxColumn
    '    With col16
    '        .HeaderText = "NOMPRE PERSONA1"
    '        .Name = "NOMPRE_PERSONA1"
    '        .DataPropertyName = "NOMPRE_PERSONA1"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col17 As New DataGridViewTextBoxColumn
    '    With col17
    '        .HeaderText = "FECHA NACIMIENTO"
    '        .Name = "FECHA_NACIMIENTO"
    '        .DataPropertyName = "FECHA_NACIMIENTO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col18 As New DataGridViewTextBoxColumn
    '    With col18
    '        .HeaderText = "SEXO PERSONA"
    '        .Name = "SEXO_PERSONA"
    '        .DataPropertyName = "SEXO_PERSONA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col19 As New DataGridViewCheckBoxColumn
    '    With col19
    '        .HeaderText = "ESMENOREDAD"
    '        .Name = "ESMENOREDAD"
    '        .DataPropertyName = "ESMENOREDAD"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col20 As New DataGridViewCheckBoxColumn
    '    With col20
    '        .HeaderText = "AGENTE RETENCION"
    '        .Name = "AGENTE_RETENCION"
    '        .DataPropertyName = "AGENTE_RETENCION"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col21 As New DataGridViewTextBoxColumn
    '    With col21
    '        .HeaderText = "IDTIPO DOC IDENTIDAD"
    '        .Name = "IDTIPO_DOC_IDENTIDAD"
    '        .DataPropertyName = "IDTIPO_DOC_IDENTIDAD"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col22 As New DataGridViewTextBoxColumn
    '    With col22
    '        .HeaderText = "NU RETE SUNA"
    '        .Name = "NU_RETE_SUNA"
    '        .DataPropertyName = "NU_RETE_SUNA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col23 As New DataGridViewTextBoxColumn
    '    With col23
    '        .HeaderText = "IDRUBRO"
    '        .Name = "IDRUBRO"
    '        .DataPropertyName = "IDRUBRO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col24 As New DataGridViewTextBoxColumn
    '    With col24
    '        .HeaderText = "IDCLASIFICACION PERSONA"
    '        .Name = "IDCLASIFICACION_PERSONA"
    '        .DataPropertyName = "IDCLASIFICACION_PERSONA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col25 As New DataGridViewTextBoxColumn
    '    With col25
    '        .HeaderText = "IDUSUARIO PERSONAL"
    '        .Name = "IDUSUARIO_PERSONAL"
    '        .DataPropertyName = "IDUSUARIO_PERSONAL"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col26 As New DataGridViewTextBoxColumn
    '    With col26
    '        .HeaderText = "IDROL USUARIO"
    '        .Name = "IDROL_USUARIO"
    '        .DataPropertyName = "IDROL_USUARIO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col27 As New DataGridViewTextBoxColumn
    '    With col27
    '        .HeaderText = "IP"
    '        .Name = "IP"
    '        .DataPropertyName = "IP"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col28 As New DataGridViewTextBoxColumn
    '    With col28
    '        .HeaderText = "FECHA REGISTRO"
    '        .Name = "FECHA_REGISTRO"
    '        .DataPropertyName = "FECHA_REGISTRO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col29 As New DataGridViewTextBoxColumn
    '    With col29
    '        .HeaderText = "IDUSUARIO PERSONALMOD"
    '        .Name = "IDUSUARIO_PERSONALMOD"
    '        .DataPropertyName = "IDUSUARIO_PERSONALMOD"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col30 As New DataGridViewTextBoxColumn
    '    With col30
    '        .HeaderText = "IDROL USUARIOMOD"
    '        .Name = "IDROL_USUARIOMOD"
    '        .DataPropertyName = "IDROL_USUARIOMOD"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col31 As New DataGridViewTextBoxColumn
    '    With col31
    '        .HeaderText = "IPMOD"
    '        .Name = "IPMOD"
    '        .DataPropertyName = "IPMOD"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col32 As New DataGridViewTextBoxColumn
    '    With col32
    '        .HeaderText = "FECHA_ACTUALIZACION"
    '        .Name = "FECHA_ACTUALIZACION"
    '        .DataPropertyName = "FECHA_ACTUALIZACION"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col33 As New DataGridViewTextBoxColumn
    '    With col33
    '        .HeaderText = "IDPAIS"
    '        .Name = "IDPAIS"
    '        .DataPropertyName = "IDPAIS"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col34 As New DataGridViewTextBoxColumn
    '    With col34
    '        .HeaderText = "IDDEPARTAMENTO"
    '        .Name = "IDDEPARTAMENTO"
    '        .DataPropertyName = "IDDEPARTAMENTO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col35 As New DataGridViewTextBoxColumn
    '    With col35
    '        .HeaderText = "IDPROVINCIA"
    '        .Name = "IDPROVINCIA"
    '        .DataPropertyName = "IDPROVINCIA"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col36 As New DataGridViewTextBoxColumn
    '    With col36
    '        .HeaderText = "IDDISTRITO"
    '        .Name = "IDDISTRITO"
    '        .DataPropertyName = "IDDISTRITO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col37 As New DataGridViewTextBoxColumn
    '    With col37
    '        .HeaderText = "USUARIO"
    '        .Name = "USUARIO"
    '        .DataPropertyName = "USUARIO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col38 As New DataGridViewTextBoxColumn
    '    With col38
    '        .HeaderText = "ROL USUARIO"
    '        .Name = "ROL_USUARIO"
    '        .DataPropertyName = "ROL_USUARIO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col39 As New DataGridViewTextBoxColumn
    '    With col39
    '        .HeaderText = "IDFUNCIONARIO ACTUAL"
    '        .Name = "IDFUNCIONARIO_ACTUAL"
    '        .DataPropertyName = "IDFUNCIONARIO_ACTUAL"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col40 As New DataGridViewTextBoxColumn
    '    With col40
    '        .HeaderText = "FUNCIONARIO"
    '        .Name = "FUNCIONARIO"
    '        .DataPropertyName = "FUNCIONARIO"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    Dim col41 As New DataGridViewTextBoxColumn
    '    With col41
    '        .HeaderText = "IDTIPO_FACTURACION"
    '        .Name = "IDTIPO_FACTURACION"
    '        .DataPropertyName = "IDTIPO_FACTURACION"
    '        .ToolTipText = "Nombres y Apellidos para Personas Naturales"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With

    '    'hlamas
    '    Dim col42 As New DataGridViewTextBoxColumn
    '    With col42
    '        .HeaderText = "MONTO_BASE"
    '        .Name = "MONTO_BASE"
    '        .DataPropertyName = "MONTO_BASE"
    '        .ToolTipText = "¿Afecto a Monto Base?"
    '        .ReadOnly = True
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With
    '    '

    '    Dim col43 As New DataGridViewTextBoxColumn
    '    With col43
    '        .HeaderText = "Porc. Descuento"
    '        .Name = "porcentaje_descuento"
    '        .DataPropertyName = "porcentaje_descuento"
    '        .ToolTipText = "¿Afecto a Monto Base?"
    '        .ReadOnly = True
    '        .Visible = False
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
    '    End With
    '    '
    '    MyDataGridLista.Columns.AddRange(col0, col1, col2, Col3, col4, col5, col6, col7, col8, col9, col10, col11, col12, col13, col14, col15, col16, col17, col18, col19, col20, col21, col22, col23, col24, col25, col26, col27, col28, col29, col30, col31, col32, col33, col34, col35, col36, col37, col38, col39, col40, col41, col42, col43)
    '    '
    '    For i As Integer = 0 To 43
    '        MyDataGridLista.Columns(i).Visible = False
    '    Next

    '    MyDataGridLista.Columns(0).Visible = True
    '    MyDataGridLista.Columns(2).Visible = True
    '    MyDataGridLista.Columns(4).Visible = True
    '    MyDataGridLista.Columns(5).Visible = True

    '    Return MydvListaClientes

    'End Function
    Public Function CargarGrillaClientes(ByVal MyDataGridLista As DataGridView, ByVal MyFuncionario As String) As DataView
        Try
            'datahelper
            'Dim rstListaClientes As ADODB.Recordset
            'Dim dtListaClientes As New DataTable
            'MyFuncionario = Replace(MyFuncionario, ",", " ")
            ''lamas
            'Dim Myobj As Object() = {"SP_LISTA_CLIENTES_FUNCIONARIO", 4, MyFuncionario, 2}
            ''Dim Myobj As Object() = {"PKG_IVOPERSONA.SP_LISTA_CLIENTES_FUNCIONARIO1", 4, MyFuncionario, 2}
            'rstListaClientes = VOCONTROLUSUARIO.fnSQLQuery(Myobj)
            'Dim da As New OleDbDataAdapter
            'da.Fill(dtListaClientes, rstListaClientes)
            'Dim MydvListaClientes As DataView
            'MydvListaClientes = dtListaClientes.DefaultView
            MyFuncionario = Replace(MyFuncionario, ",", " ")
            Dim db As New BaseDatos
            db.Conectar()
            'hlamas 06-01-2014
            'db.CrearComando("SP_LISTA_CLIENTES_FUNCIONARIO", CommandType.StoredProcedure)
            db.CrearComando("SP_LISTA_CLIENTES_FUNC_CARTERA", CommandType.StoredProcedure)
            db.AsignarParametro("iNOMBRE_FUNCIONARIO", MyFuncionario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_LISTA_CLIENTES", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dtListaClientes As DataTable = db.EjecutarDataTable
            Dim MydvListaClientes As DataView = dtListaClientes.DefaultView
            With MyDataGridLista
                '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .DataSource = MydvListaClientes
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .VirtualMode = True
                '.RowHeadersWidth = 30
                .RowHeadersVisible = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            Dim col0 As New DataGridViewCheckBoxColumn
            With col0
                .HeaderText = "¿ACTIVO?"
                .Name = "ACTIVO"
                .DataPropertyName = "IDESTADO_REGISTRO"
                .Width = 62
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .Frozen = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            'MyDataGridLista.Columns.Add(col0)

            Dim col1 As New DataGridViewTextBoxColumn
            With col1
                .HeaderText = "ID"
                .Name = "ID"
                .DataPropertyName = "IDPERSONA"
                .ReadOnly = True
                .ToolTipText = "Identificador del cliente en la Base de Datos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            End With
            'MyDataGridLista.Columns.Add(col1)

            Dim col2 As New DataGridViewTextBoxColumn
            With col2
                .HeaderText = "CODIGO"
                .Name = "CODIGO"
                .DataPropertyName = "CODIGO_CLIENTE"
                .ToolTipText = "Código del Cliente"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            End With
            'MyDataGridLista.Columns.Add(col2)

            Dim Col3 As New DataGridViewTextBoxColumn
            With Col3
                .HeaderText = "DOCT."
                .Name = "DOCUMENTO"
                .DataPropertyName = "NU_DOCU_SUNA"
                .ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            End With
            'MyDataGridLista.Columns.Add(Col3)

            Dim col4 As New DataGridViewTextBoxColumn
            With col4
                .HeaderText = "CLIENTE"
                .Name = "RAZONSOCIAL"
                .DataPropertyName = "RAZON_SOCIAL"
                .ToolTipText = "Razon Social para Personas Juridicos"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            'MyDataGridLista.Columns.Add(col4)

            Dim col5 As New DataGridViewTextBoxColumn
            With col5
                .HeaderText = "CLIENTE"
                .Name = "NOMBREYAPELLIDO"
                .DataPropertyName = "NOMNRES_APELLIDOS"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            'MyDataGridLista.Columns.Add(col5)

            Dim col6 As New DataGridViewTextBoxColumn
            With col6
                .HeaderText = "TIPO PERSONA"
                .Name = "JURIDICAONATURAL"
                .DataPropertyName = "IDTIPO_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            'MyDataGridLista.Columns.Add(col6)

            Dim col7 As New DataGridViewCheckBoxColumn
            With col7
                .HeaderText = "CLIENTE CORPORATIVO"
                .Name = "CLIENTE_CORPORATIVO"
                .DataPropertyName = "CLIENTE_CORPORATIVO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col8 As New DataGridViewTextBoxColumn
            With col8
                .HeaderText = "GERENTE GENERAL"
                .Name = "GERENTE_GENERAL"
                .DataPropertyName = "GERENTE_GENERAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col9 As New DataGridViewTextBoxColumn
            With col9
                .HeaderText = "REPRESENTANTE LEGAL"
                .Name = "REPRESENTANTE_LEGAL"
                .DataPropertyName = "REPRESENTANTE_LEGAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col10 As New DataGridViewTextBoxColumn
            With col10
                .HeaderText = "FECHA INGRESO"
                .Name = "FECHA_INGRESO"
                .DataPropertyName = "FECHA_INGRESO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col11 As New DataGridViewCheckBoxColumn
            With col11
                .HeaderText = "PAGO POST FACTURACION"
                .Name = "PAGO_POST_FACTURACION"
                .DataPropertyName = "PAGO_POST_FACTURACION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col12 As New DataGridViewTextBoxColumn
            With col12
                .HeaderText = "EMAIL"
                .Name = "EMAIL"
                .DataPropertyName = "EMAIL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col13 As New DataGridViewTextBoxColumn
            With col13
                .HeaderText = "APELLIDO PATERNO"
                .Name = "APELLIDO_PATERNO"
                .DataPropertyName = "APELLIDO_PATERNO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col14 As New DataGridViewTextBoxColumn
            With col14
                .HeaderText = "APELLIDO MATERNO"
                .Name = "APELLIDO_MATERNO"
                .DataPropertyName = "APELLIDO_MATERNO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col15 As New DataGridViewTextBoxColumn
            With col15
                .HeaderText = "NOMPRE PERSONA"
                .Name = "NOMPRE_PERSONA"
                .DataPropertyName = "NOMPRE_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col16 As New DataGridViewTextBoxColumn
            With col16
                .HeaderText = "NOMPRE PERSONA1"
                .Name = "NOMPRE_PERSONA1"
                .DataPropertyName = "NOMPRE_PERSONA1"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col17 As New DataGridViewTextBoxColumn
            With col17
                .HeaderText = "FECHA NACIMIENTO"
                .Name = "FECHA_NACIMIENTO"
                .DataPropertyName = "FECHA_NACIMIENTO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col18 As New DataGridViewTextBoxColumn
            With col18
                .HeaderText = "SEXO PERSONA"
                .Name = "SEXO_PERSONA"
                .DataPropertyName = "SEXO_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col19 As New DataGridViewCheckBoxColumn
            With col19
                .HeaderText = "ESMENOREDAD"
                .Name = "ESMENOREDAD"
                .DataPropertyName = "ESMENOREDAD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col20 As New DataGridViewCheckBoxColumn
            With col20
                .HeaderText = "AGENTE RETENCION"
                .Name = "AGENTE_RETENCION"
                .DataPropertyName = "AGENTE_RETENCION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col21 As New DataGridViewTextBoxColumn
            With col21
                .HeaderText = "IDTIPO DOC IDENTIDAD"
                .Name = "IDTIPO_DOC_IDENTIDAD"
                .DataPropertyName = "IDTIPO_DOC_IDENTIDAD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col22 As New DataGridViewTextBoxColumn
            With col22
                .HeaderText = "NU RETE SUNA"
                .Name = "NU_RETE_SUNA"
                .DataPropertyName = "NU_RETE_SUNA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col23 As New DataGridViewTextBoxColumn
            With col23
                .HeaderText = "IDRUBRO"
                .Name = "IDRUBRO"
                .DataPropertyName = "IDRUBRO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col24 As New DataGridViewTextBoxColumn
            With col24
                .HeaderText = "IDCLASIFICACION PERSONA"
                .Name = "IDCLASIFICACION_PERSONA"
                .DataPropertyName = "IDCLASIFICACION_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col25 As New DataGridViewTextBoxColumn
            With col25
                .HeaderText = "IDUSUARIO PERSONAL"
                .Name = "IDUSUARIO_PERSONAL"
                .DataPropertyName = "IDUSUARIO_PERSONAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col26 As New DataGridViewTextBoxColumn
            With col26
                .HeaderText = "IDROL USUARIO"
                .Name = "IDROL_USUARIO"
                .DataPropertyName = "IDROL_USUARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col27 As New DataGridViewTextBoxColumn
            With col27
                .HeaderText = "IP"
                .Name = "IP"
                .DataPropertyName = "IP"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col28 As New DataGridViewTextBoxColumn
            With col28
                .HeaderText = "FECHA REGISTRO"
                .Name = "FECHA_REGISTRO"
                .DataPropertyName = "FECHA_REGISTRO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col29 As New DataGridViewTextBoxColumn
            With col29
                .HeaderText = "IDUSUARIO PERSONALMOD"
                .Name = "IDUSUARIO_PERSONALMOD"
                .DataPropertyName = "IDUSUARIO_PERSONALMOD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col30 As New DataGridViewTextBoxColumn
            With col30
                .HeaderText = "IDROL USUARIOMOD"
                .Name = "IDROL_USUARIOMOD"
                .DataPropertyName = "IDROL_USUARIOMOD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col31 As New DataGridViewTextBoxColumn
            With col31
                .HeaderText = "IPMOD"
                .Name = "IPMOD"
                .DataPropertyName = "IPMOD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col32 As New DataGridViewTextBoxColumn
            With col32
                .HeaderText = "FECHA_ACTUALIZACION"
                .Name = "FECHA_ACTUALIZACION"
                .DataPropertyName = "FECHA_ACTUALIZACION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col33 As New DataGridViewTextBoxColumn
            With col33
                .HeaderText = "IDPAIS"
                .Name = "IDPAIS"
                .DataPropertyName = "IDPAIS"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col34 As New DataGridViewTextBoxColumn
            With col34
                .HeaderText = "IDDEPARTAMENTO"
                .Name = "IDDEPARTAMENTO"
                .DataPropertyName = "IDDEPARTAMENTO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col35 As New DataGridViewTextBoxColumn
            With col35
                .HeaderText = "IDPROVINCIA"
                .Name = "IDPROVINCIA"
                .DataPropertyName = "IDPROVINCIA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col36 As New DataGridViewTextBoxColumn
            With col36
                .HeaderText = "IDDISTRITO"
                .Name = "IDDISTRITO"
                .DataPropertyName = "IDDISTRITO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col37 As New DataGridViewTextBoxColumn
            With col37
                .HeaderText = "USUARIO"
                .Name = "USUARIO"
                .DataPropertyName = "USUARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col38 As New DataGridViewTextBoxColumn
            With col38
                .HeaderText = "ROL USUARIO"
                .Name = "ROL_USUARIO"
                .DataPropertyName = "ROL_USUARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col39 As New DataGridViewTextBoxColumn
            With col39
                .HeaderText = "IDFUNCIONARIO ACTUAL"
                .Name = "IDFUNCIONARIO_ACTUAL"
                .DataPropertyName = "IDFUNCIONARIO_ACTUAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col40 As New DataGridViewTextBoxColumn
            With col40
                .HeaderText = "FUNCIONARIO"
                .Name = "FUNCIONARIO"
                .DataPropertyName = "FUNCIONARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col41 As New DataGridViewTextBoxColumn
            With col41
                .HeaderText = "IDTIPO_FACTURACION"
                .Name = "IDTIPO_FACTURACION"
                .DataPropertyName = "IDTIPO_FACTURACION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            'hlamas
            Dim col42 As New DataGridViewTextBoxColumn
            With col42
                .HeaderText = "MONTO_BASE"
                .Name = "MONTO_BASE"
                .DataPropertyName = "MONTO_BASE"
                .ToolTipText = "¿Afecto a Monto Base?"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim DESCUENTO As New DataGridViewTextBoxColumn
            With DESCUENTO
                .HeaderText = "DESCUENTO"
                .Name = "DESCUENTO"
                .DataPropertyName = "PORCENTAJE_DESCUENTO"
                .ToolTipText = "DESCUENTO/INCREMENTO"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            MyDataGridLista.Columns.AddRange(col0, col1, col2, Col3, col4, col5, col6, col7, col8, col9, col10, col11, col12, col13, col14, col15, col16, col17, col18, col19, col20, col21, col22, col23, col24, col25, col26, col27, col28, col29, col30, col31, col32, col33, col34, col35, col36, col37, col38, col39, col40, col41, col42, DESCUENTO)

            For i As Integer = 0 To 42
                MyDataGridLista.Columns(i).Visible = False
            Next

            MyDataGridLista.Columns(0).Visible = True
            MyDataGridLista.Columns(2).Visible = True
            MyDataGridLista.Columns(4).Visible = True
            MyDataGridLista.Columns(5).Visible = True

            Return MydvListaClientes

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function CargarCliente2009_eliminarlo(ByVal cliente As String) As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_LISTA_CLIENTE", 4, cliente, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function CargarCliente(ByVal cliente As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'hlamas 06-01-2014
            'db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CLIENTE", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CLIENTE_CAR", CommandType.StoredProcedure)
            db.AsignarParametro("cliente", cliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_LISTA_CLIENTES", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function CargarGrillaClientes_x_funcionario(ByVal sidusurio_funcionario As String, ByVal MyDataGridLista As DataGridView) As DataView
        Try
            'Dim rstListaClientes As ADODB.Recordset
            Dim dtListaClientes As New DataTable
            'datahelper
            'Dim Myobj As Object() = {"PKG_IVOPERSONA.SP_LISTA_CLIENTES_x_FUNCIONAR", 4, _
            '                         sidusurio_funcionario, 2}
            'rstListaClientes = VOCONTROLUSUARIO.fnSQLQuery(Myobj)
            ''
            'Dim da As New OleDbDataAdapter
            'da.Fill(dtListaClientes, rstListaClientes)
            'Dim MydvListaClientes As DataView
            ''
            'MydvListaClientes = dtListaClientes.DefaultView
            '

            Dim db As New BaseDatos
            Dim MydvListaClientes As DataView

            db.Conectar()
            'hlamas 06-01-2014
            'db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CLIENTES_x_FUNCIONAR", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CLIENTES_x_FUN_car", CommandType.StoredProcedure)
            db.AsignarParametro("vi_idfuncionario", sidusurio_funcionario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_LISTA_CLIENTES", OracleClient.OracleType.Cursor)

            db.Desconectar()
            dtListaClientes = db.EjecutarDataTable
            MydvListaClientes = dtListaClientes.DefaultView

            With MyDataGridLista
                '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .DataSource = MydvListaClientes
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .VirtualMode = True
                '.RowHeadersWidth = 30
                .RowHeadersVisible = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            Dim col0 As New DataGridViewCheckBoxColumn
            With col0
                .HeaderText = "¿ACTIVO?"
                .Name = "ACTIVO"
                .DataPropertyName = "IDESTADO_REGISTRO"
                .Width = 62
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .Frozen = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            'MyDataGridLista.Columns.Add(col0)

            Dim col1 As New DataGridViewTextBoxColumn
            With col1
                .HeaderText = "ID"
                .Name = "ID"
                .DataPropertyName = "IDPERSONA"
                .ReadOnly = True
                .ToolTipText = "Identificador del cliente en la Base de Datos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            End With
            'MyDataGridLista.Columns.Add(col1)

            Dim col2 As New DataGridViewTextBoxColumn
            With col2
                .HeaderText = "CODIGO"
                .Name = "CODIGO"
                .DataPropertyName = "CODIGO_CLIENTE"
                .ToolTipText = "Código del Cliente"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            End With
            'MyDataGridLista.Columns.Add(col2)

            Dim Col3 As New DataGridViewTextBoxColumn
            With Col3
                .HeaderText = "DOCT."
                .Name = "DOCUMENTO"
                .DataPropertyName = "NU_DOCU_SUNA"
                .ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            End With
            'MyDataGridLista.Columns.Add(Col3)

            Dim col4 As New DataGridViewTextBoxColumn
            With col4
                .HeaderText = "CLIENTE"
                .Name = "RAZONSOCIAL"
                .DataPropertyName = "RAZON_SOCIAL"
                .ToolTipText = "Razon Social para Personas Juridicos"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            'MyDataGridLista.Columns.Add(col4)

            Dim col5 As New DataGridViewTextBoxColumn
            With col5
                .HeaderText = "CLIENTE"
                .Name = "NOMBREYAPELLIDO"
                .DataPropertyName = "NOMNRES_APELLIDOS"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            'MyDataGridLista.Columns.Add(col5)

            Dim col6 As New DataGridViewTextBoxColumn
            With col6
                .HeaderText = "TIPO PERSONA"
                .Name = "JURIDICAONATURAL"
                .DataPropertyName = "IDTIPO_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            'MyDataGridLista.Columns.Add(col6)

            Dim col7 As New DataGridViewCheckBoxColumn
            With col7
                .HeaderText = "CLIENTE CORPORATIVO"
                .Name = "CLIENTE_CORPORATIVO"
                .DataPropertyName = "CLIENTE_CORPORATIVO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col8 As New DataGridViewTextBoxColumn
            With col8
                .HeaderText = "GERENTE GENERAL"
                .Name = "GERENTE_GENERAL"
                .DataPropertyName = "GERENTE_GENERAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col9 As New DataGridViewTextBoxColumn
            With col9
                .HeaderText = "REPRESENTANTE LEGAL"
                .Name = "REPRESENTANTE_LEGAL"
                .DataPropertyName = "REPRESENTANTE_LEGAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col10 As New DataGridViewTextBoxColumn
            With col10
                .HeaderText = "FECHA INGRESO"
                .Name = "FECHA_INGRESO"
                .DataPropertyName = "FECHA_INGRESO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col11 As New DataGridViewCheckBoxColumn
            With col11
                .HeaderText = "PAGO POST FACTURACION"
                .Name = "PAGO_POST_FACTURACION"
                .DataPropertyName = "PAGO_POST_FACTURACION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col12 As New DataGridViewTextBoxColumn
            With col12
                .HeaderText = "EMAIL"
                .Name = "EMAIL"
                .DataPropertyName = "EMAIL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col13 As New DataGridViewTextBoxColumn
            With col13
                .HeaderText = "APELLIDO PATERNO"
                .Name = "APELLIDO_PATERNO"
                .DataPropertyName = "APELLIDO_PATERNO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col14 As New DataGridViewTextBoxColumn
            With col14
                .HeaderText = "APELLIDO MATERNO"
                .Name = "APELLIDO_MATERNO"
                .DataPropertyName = "APELLIDO_MATERNO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col15 As New DataGridViewTextBoxColumn
            With col15
                .HeaderText = "NOMPRE PERSONA"
                .Name = "NOMPRE_PERSONA"
                .DataPropertyName = "NOMPRE_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col16 As New DataGridViewTextBoxColumn
            With col16
                .HeaderText = "NOMPRE PERSONA1"
                .Name = "NOMPRE_PERSONA1"
                .DataPropertyName = "NOMPRE_PERSONA1"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col17 As New DataGridViewTextBoxColumn
            With col17
                .HeaderText = "FECHA NACIMIENTO"
                .Name = "FECHA_NACIMIENTO"
                .DataPropertyName = "FECHA_NACIMIENTO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col18 As New DataGridViewTextBoxColumn
            With col18
                .HeaderText = "SEXO PERSONA"
                .Name = "SEXO_PERSONA"
                .DataPropertyName = "SEXO_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col19 As New DataGridViewCheckBoxColumn
            With col19
                .HeaderText = "ESMENOREDAD"
                .Name = "ESMENOREDAD"
                .DataPropertyName = "ESMENOREDAD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col20 As New DataGridViewCheckBoxColumn
            With col20
                .HeaderText = "AGENTE RETENCION"
                .Name = "AGENTE_RETENCION"
                .DataPropertyName = "AGENTE_RETENCION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col21 As New DataGridViewTextBoxColumn
            With col21
                .HeaderText = "IDTIPO DOC IDENTIDAD"
                .Name = "IDTIPO_DOC_IDENTIDAD"
                .DataPropertyName = "IDTIPO_DOC_IDENTIDAD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col22 As New DataGridViewTextBoxColumn
            With col22
                .HeaderText = "NU RETE SUNA"
                .Name = "NU_RETE_SUNA"
                .DataPropertyName = "NU_RETE_SUNA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col23 As New DataGridViewTextBoxColumn
            With col23
                .HeaderText = "IDRUBRO"
                .Name = "IDRUBRO"
                .DataPropertyName = "IDRUBRO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col24 As New DataGridViewTextBoxColumn
            With col24
                .HeaderText = "IDCLASIFICACION PERSONA"
                .Name = "IDCLASIFICACION_PERSONA"
                .DataPropertyName = "IDCLASIFICACION_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col25 As New DataGridViewTextBoxColumn
            With col25
                .HeaderText = "IDUSUARIO PERSONAL"
                .Name = "IDUSUARIO_PERSONAL"
                .DataPropertyName = "IDUSUARIO_PERSONAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col26 As New DataGridViewTextBoxColumn
            With col26
                .HeaderText = "IDROL USUARIO"
                .Name = "IDROL_USUARIO"
                .DataPropertyName = "IDROL_USUARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col27 As New DataGridViewTextBoxColumn
            With col27
                .HeaderText = "IP"
                .Name = "IP"
                .DataPropertyName = "IP"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col28 As New DataGridViewTextBoxColumn
            With col28
                .HeaderText = "FECHA REGISTRO"
                .Name = "FECHA_REGISTRO"
                .DataPropertyName = "FECHA_REGISTRO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col29 As New DataGridViewTextBoxColumn
            With col29
                .HeaderText = "IDUSUARIO PERSONALMOD"
                .Name = "IDUSUARIO_PERSONALMOD"
                .DataPropertyName = "IDUSUARIO_PERSONALMOD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col30 As New DataGridViewTextBoxColumn
            With col30
                .HeaderText = "IDROL USUARIOMOD"
                .Name = "IDROL_USUARIOMOD"
                .DataPropertyName = "IDROL_USUARIOMOD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col31 As New DataGridViewTextBoxColumn
            With col31
                .HeaderText = "IPMOD"
                .Name = "IPMOD"
                .DataPropertyName = "IPMOD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col32 As New DataGridViewTextBoxColumn
            With col32
                .HeaderText = "FECHA_ACTUALIZACION"
                .Name = "FECHA_ACTUALIZACION"
                .DataPropertyName = "FECHA_ACTUALIZACION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col33 As New DataGridViewTextBoxColumn
            With col33
                .HeaderText = "IDPAIS"
                .Name = "IDPAIS"
                .DataPropertyName = "IDPAIS"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col34 As New DataGridViewTextBoxColumn
            With col34
                .HeaderText = "IDDEPARTAMENTO"
                .Name = "IDDEPARTAMENTO"
                .DataPropertyName = "IDDEPARTAMENTO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col35 As New DataGridViewTextBoxColumn
            With col35
                .HeaderText = "IDPROVINCIA"
                .Name = "IDPROVINCIA"
                .DataPropertyName = "IDPROVINCIA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col36 As New DataGridViewTextBoxColumn
            With col36
                .HeaderText = "IDDISTRITO"
                .Name = "IDDISTRITO"
                .DataPropertyName = "IDDISTRITO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col37 As New DataGridViewTextBoxColumn
            With col37
                .HeaderText = "USUARIO"
                .Name = "USUARIO"
                .DataPropertyName = "USUARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col38 As New DataGridViewTextBoxColumn
            With col38
                .HeaderText = "ROL USUARIO"
                .Name = "ROL_USUARIO"
                .DataPropertyName = "ROL_USUARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col39 As New DataGridViewTextBoxColumn
            With col39
                .HeaderText = "IDFUNCIONARIO ACTUAL"
                .Name = "IDFUNCIONARIO_ACTUAL"
                .DataPropertyName = "IDFUNCIONARIO_ACTUAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col40 As New DataGridViewTextBoxColumn
            With col40
                .HeaderText = "FUNCIONARIO"
                .Name = "FUNCIONARIO"
                .DataPropertyName = "FUNCIONARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col41 As New DataGridViewTextBoxColumn
            With col41
                .HeaderText = "IDTIPO_FACTURACION"
                .Name = "IDTIPO_FACTURACION"
                .DataPropertyName = "IDTIPO_FACTURACION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            'hlamas
            Dim col42 As New DataGridViewTextBoxColumn
            With col42
                .HeaderText = "MONTO_BASE"
                .Name = "MONTO_BASE"
                .DataPropertyName = "MONTO_BASE"
                .ToolTipText = "¿Afecto a Monto Base?"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim DESCUENTO As New DataGridViewTextBoxColumn
            With DESCUENTO
                .HeaderText = "DESCUENTO"
                .Name = "DESCUENTO"
                .DataPropertyName = "PORCENTAJE_DESCUENTO"
                .ToolTipText = "DESCUENTO/INCREMENTO"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            '
            MyDataGridLista.Columns.AddRange(col0, col1, col2, Col3, col4, col5, col6, col7, col8, col9, col10, col11, col12, col13, col14, col15, col16, col17, col18, col19, col20, col21, col22, col23, col24, col25, col26, col27, col28, col29, col30, col31, col32, col33, col34, col35, col36, col37, col38, col39, col40, col41, col42, DESCUENTO)

            For i As Integer = 0 To 42
                MyDataGridLista.Columns(i).Visible = False
            Next
            '
            MyDataGridLista.Columns(0).Visible = True
            MyDataGridLista.Columns(2).Visible = True
            MyDataGridLista.Columns(4).Visible = True
            MyDataGridLista.Columns(5).Visible = True
            Return MydvListaClientes
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function


#End Region

#Region " BUSCA SI YA EXISTE UN TARIFARIO PARA UN CLIENTE POR ORIGEN Y DESTINO "
    'Public Function BuscaTarifario2009_eliminarlo(ByVal CodigoCliente As String, ByVal Origen As Integer, ByVal Destino As Integer) As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_BUSCA_TARIFA", 10, CodigoCliente, 2, Origen, 1, Destino, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function BuscaTarifario(ByVal CodigoCliente As String, ByVal Origen As Integer, ByVal Destino As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_BUSCA_TARIFA", CommandType.StoredProcedure)
            db.AsignarParametro("iCODIGOPERSONA", CodigoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iCODIGO_ORIGEN", Origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("iCODIGO_DESTINO", Destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("oCUR_RESULTADO", OracleClient.OracleType.Cursor)
            'db.CrearComando("f_valida_cliente_ruta", CommandType.StoredProcedure)
            'db.AsignarParametro("iCODIGOPERSONA", CodigoCliente, OracleClient.OracleType.VarChar)
            'db.AsignarParametro("iCODIGO_ORIGEN", Origen, OracleClient.OracleType.Int32)
            'db.AsignarParametro("iCODIGO_DESTINO", Destino, OracleClient.OracleType.Int32)
            'db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region

#Region " BUSCA SI YA EXISTE UN TARIFARIO PARA UN CLIENTE POR ORIGEN Y DESTINO "
    'Public Function BuscaTarifario2009_eliminarlo(ByVal CodigoCliente As String, ByVal Origen As Integer, ByVal Destino As Integer) As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_BUSCA_TARIFA", 10, CodigoCliente, 2, Origen, 1, Destino, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function

    ' Funcion que Valida si ya existe el tarifario de origen a destino - 20/06/2013
    'Public Function BuscaTarifarioII(ByVal CodigoCliente As String, ByVal Origen As Integer, ByVal Destino As Integer) As String

    '    Try
    '        Dim lStr_Retorno As String
    '        Dim vStrFuncion As String = ""
    '        iOracle_Cmd = New OracleCommand
    '        iOracle_Cmd.Connection = Conexion_2()
    '        vStrFuncion = "SELECT (f_valida_cliente_ruta('" & CodigoCliente & "'," & Origen & "," & Destino & ")) FROM DUAL"
    '        iOracle_Cmd.CommandText = vStrFuncion
    '        iOracle_Cmd.CommandType = CommandType.Text
    '        lStr_Retorno = iOracle_Cmd.ExecuteScalar()

    '        Return lStr_Retorno
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    Finally
    '        iOracle_Cmd.Connection.Close()
    '    End Try
    'End Function
    'Public Function BuscaTarifario_SubCuenta(ByVal Cliente As String, ByVal Origen_SubCuenta As Integer, ByVal Destino_Subcuenta As Integer) As String

    '    Try
    '        Dim lStr_Retorno As String
    '        Dim vStrFuncion As String = ""
    '        iOracle_Cmd = New OracleCommand
    '        iOracle_Cmd.Connection = Conexion_2()
    '        vStrFuncion = "SELECT (f_valida_cliente_subcuenta('" & Cliente & "'," & Origen_SubCuenta & "," & Destino_Subcuenta & ")) FROM DUAL"
    '        iOracle_Cmd.CommandText = vStrFuncion
    '        iOracle_Cmd.CommandType = CommandType.Text
    '        lStr_Retorno = iOracle_Cmd.ExecuteScalar()

    '        Return lStr_Retorno
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    Finally
    '        iOracle_Cmd.Connection.Close()
    '    End Try
    'End Function



    'Public Function BuscaTarifario_Cliente(ByVal Cliente As String, ByVal Origen As Integer, ByVal Destino As Integer) As String

    '    Try
    '        Dim lStr_Retorno As String
    '        Dim vStrFuncion As String = ""
    '        iOracle_Cmd = New OracleCommand
    '        iOracle_Cmd.Connection = Conexion_2()
    '        vStrFuncion = "SELECT (f_valida_tarifa_cliente('" & Cliente & "'," & Origen & "," & Destino & ")) FROM DUAL"
    '        iOracle_Cmd.CommandText = vStrFuncion
    '        iOracle_Cmd.CommandType = CommandType.Text
    '        lStr_Retorno = iOracle_Cmd.ExecuteScalar()

    '        Return lStr_Retorno
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    Finally
    '        iOracle_Cmd.Connection.Close()
    '    End Try
    'End Function


    'Public Function BuscaTarifario_SubCuenta1(ByVal Cliente As String, ByVal Origen As Integer, ByVal Destino As Integer) As String

    '    Try
    '        Dim lStr_Retorno As String
    '        Dim vStrFuncion As String = ""
    '        iOracle_Cmd = New OracleCommand
    '        iOracle_Cmd.Connection = Conexion_2()
    '        vStrFuncion = "SELECT (F_TARFA_SUB_CUENTA('" & Cliente & "'," & Origen & "," & Destino & ")) FROM DUAL"
    '        iOracle_Cmd.CommandText = vStrFuncion
    '        iOracle_Cmd.CommandType = CommandType.Text
    '        lStr_Retorno = iOracle_Cmd.ExecuteScalar()

    '        Return lStr_Retorno
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    Finally
    '        iOracle_Cmd.Connection.Close()
    '    End Try
    'End Function


    'Public Function BuscaTarifario_Publico(ByVal Origen As Integer, ByVal Destino As Integer, ByVal StrProducto As String, ByVal StrVisibilidad As String, ByVal StrTipoTarifa As String) As String

    '    Try
    '        Dim lStr_Retorno As String
    '        Dim vStrFuncion As String = ""
    '        iOracle_Cmd = New OracleCommand
    '        iOracle_Cmd.Connection = Conexion_2()
    '        vStrFuncion = "SELECT (F_TARIFA_PUBLICA(" & Origen & "," & Destino & "," & StrProducto & "," & StrVisibilidad & "," & StrTipoTarifa & ")) FROM DUAL"
    '        iOracle_Cmd.CommandText = vStrFuncion
    '        iOracle_Cmd.CommandType = CommandType.Text
    '        lStr_Retorno = iOracle_Cmd.ExecuteScalar()

    '        Return lStr_Retorno
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    Finally
    '        iOracle_Cmd.Connection.Close()
    '    End Try
    'End Function




#End Region

#Region " BUSCA SI YA EXISTE UN CLIENTE "
    'Public Function BuscaCliente2009(ByVal CodigoCliente As String) As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_BUSCA_CLIENTE", 4, CodigoCliente, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function

    Public Function BuscarCliente(ByVal CodigoCliente As String) As DataTable
        Try
            'Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_BUSCA_CLIENTE", 4, CodigoCliente, 2}
            'Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_BUSCA_CLIENTE", CommandType.StoredProcedure)
            db.AsignarParametro("iCODIGOPERSONA", CodigoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_RESULTADO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region

#Region " LIMPIA CHECKETS DE LOS CHECKBOX "
    Public Sub LimpiaCheckBox(ByVal ParamArray MyCheckBox() As CheckBox)
        For i As Integer = 0 To UBound(MyCheckBox)
            MyCheckBox(i).Checked = False
        Next
    End Sub
#End Region

#Region " BUSCA SI YA UN RANGO DE GUIAS DE ENVIO ESTAN ASOCIADAS A UN CLIENTE "
    'Public Function BuscaGuias2009_eliminarlo(ByVal NroInicial As Integer, ByVal NroFinal As Integer) As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_BUSCA_GUIAS_ENVIO", 6, NroInicial, 1, NroFinal, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function BuscaGuias(ByVal NroInicial As Integer, ByVal NroFinal As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_BUSCA_GUIAS_ENVIO", CommandType.StoredProcedure)
            db.AsignarParametro("iNRO_INICIAL", NroInicial, OracleClient.OracleType.Int32)
            db.AsignarParametro("iNRO_FINAL", NroFinal, OracleClient.OracleType.Int32)
            db.AsignarParametro("oCUR_RESULTADO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region

#Region " LISTA DE GUIAS DE ENVIO QUE ESTAN ASOCIADAS A UN CLIENTE "
    'Public Function ListaGuiasEnvio2009_eliminarlo(ByVal CodigoCliente As String) As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_LISTA_GUIAS_USADA", 6, CodigoCliente, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function

    Public Function ListaGuiasEnvio(ByVal CodigoCliente As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_GUIAS_USADA", CommandType.StoredProcedure)
            db.AsignarParametro("iCODIGOCLIENTE", CodigoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_GUIAS_ENVIO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region

#Region " ASOCIA SUB CUENTAS A UN CLIENTE "
    'Public Function SubCuentasCliente2009_eliminarlo(ByVal CodigoCliente As String) As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_SUB_CUENTAS", 6, CodigoCliente, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function

    Public Function SubCuentasCliente(ByVal CodigoCliente As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_SUB_CUENTAS", CommandType.StoredProcedure)
            db.AsignarParametro("iCODIGOCLIENTE", CodigoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_SUB_CUENTA", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region

#Region " CARGA DATA DE SOLICITUD DE CLEDIRO DEPENDIENDO DEL CODIGO DEL CLIENTE "
    'Public Function CargaDataSolicitud2009_eliminarlo(ByVal CodigoCliente As String) As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_CARGA_SOLICITUD", 6, CodigoCliente, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function CargaDataSolicitud(ByVal CodigoCliente As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_CARGA_SOLICITUD_DH", CommandType.StoredProcedure)
            db.AsignarParametro("iCODIGOCLIENTE", CodigoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oSOLICITUD_CREDITO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oPROVEEDORES_SOLICITUD", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCLIENTES_SOLICITUD", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oDESTINOS_VIAJE_SOLICITUD", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oREFERENCIA_BANCARIA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oDOCUMENTOS_SOLICITUD", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_ESTADO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region

#Region " CARGA CONFIGURACION CTACTE "
    'Public Function CargaConfigCtaCte2009(ByVal CodigoCliente As String) As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_BUSCA_CONFIG_CTACTE", 4, CodigoCliente, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function

    Public Function CargaConfigCtaCte(ByVal CodigoCliente As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_BUSCA_CONFIG_CTACTE", CommandType.StoredProcedure)
            db.AsignarParametro("iCODIGOCLIENTE", CodigoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_CONFIG", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region

#Region " BUSCA CLIENTE CONFIGURACION "
    ''' <summary>
    ''' Para evitar la Edicion si un cliente ya tiene su Configuracion CtaCte(Esta Aprobado si o no)
    ''' </summary>
    ''' <param name="CodigoCliente"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function BuscaClienteConfig2009_eliminarlo(ByVal CodigoCliente As String) As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_CLIENTE_CONFIGURACION", 4, CodigoCliente, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function

    Public Function BuscaClienteConfig(ByVal CodigoCliente As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_CLIENTE_CONFIGURACION", CommandType.StoredProcedure)
            db.AsignarParametro("iCODIGOCLIENTE", CodigoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_CONFIG", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region

#Region " CARGA A LOS CLIENTES CON SOLICITUD PENDIENTE POR APROBAR Y APROBADAS TAMBIEN "
    ''' <summary>
    '''  Carga a Clientes con Solicitudes de Credito Pendientes de Aprobacion y Aprobadas tambien.
    ''' </summary>
    ''' <param name="MyDataGridLista"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CargarGrillaClientesSolicitudPendiente(ByVal MyDataGridLista As DataGridView) As DataView
        'dataset
        'Dim rstListaClientes As ADODB.Recordset
        'Dim dtListaClientes As New DataTable

        'Dim Myobj As Object() = {"PKG_IVOPERSONA.SP_LISTA_CLIENTE_SOLICITUD", 0}
        'rstListaClientes = VOCONTROLUSUARIO.fnSQLQuery(Myobj)
        'Dim da As New OleDbDataAdapter
        'da.Fill(dtListaClientes, rstListaClientes)
        'Dim MydvListaClientes As DataView

        Try
            Dim dtListaClientes As New DataTable
            Dim db As New BaseDatos
            db.Conectar()
            'hlamas 06-01-2014
            'db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CLIENTE_SOLICITUD", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CLIENTE_SOL_car", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_CLIENTE_SOLICITUD", OracleClient.OracleType.Cursor)
            db.Desconectar()
            dtListaClientes = db.EjecutarDataTable

            Dim MydvListaClientes As DataView
            MydvListaClientes = dtListaClientes.DefaultView
            With MyDataGridLista
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .DataSource = MydvListaClientes
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .VirtualMode = True
                .RowHeadersVisible = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            Dim col0 As New DataGridViewCheckBoxColumn
            With col0
                .HeaderText = "¿ACTIVO?"
                .Name = "ACTIVO"
                .DataPropertyName = "IDESTADO_REGISTRO"
                .Width = 62
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .Frozen = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            'MyDataGridLista.Columns.Add(col0)

            Dim col1 As New DataGridViewTextBoxColumn
            With col1
                .HeaderText = "ID"
                .Name = "ID"
                .DataPropertyName = "IDPERSONA"
                .ReadOnly = True
                .ToolTipText = "Identificador del cliente en la Base de Datos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            End With
            'MyDataGridLista.Columns.Add(col1)

            Dim col2 As New DataGridViewTextBoxColumn
            With col2
                .HeaderText = "CODIGO"
                .Name = "CODIGO"
                .DataPropertyName = "CODIGO_CLIENTE"
                .ToolTipText = "Código del Cliente"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            End With
            'MyDataGridLista.Columns.Add(col2)

            Dim Col3 As New DataGridViewTextBoxColumn
            With Col3
                .HeaderText = "DOCT."
                .Name = "DOCUMENTO"
                .DataPropertyName = "NU_DOCU_SUNA"
                .ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            End With
            'MyDataGridLista.Columns.Add(Col3)

            Dim col4 As New DataGridViewTextBoxColumn
            With col4
                .HeaderText = "RAZON SOCIAL"
                .Name = "RAZONSOCIAL"
                .DataPropertyName = "RAZON_SOCIAL"
                .ToolTipText = "Razon Social para Personas Juridicos"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            'MyDataGridLista.Columns.Add(col4)

            Dim col5 As New DataGridViewTextBoxColumn
            With col5
                .HeaderText = "NOMBRE Y APELLIDOS"
                .Name = "NOMBREYAPELLIDO"
                .DataPropertyName = "NOMNRES_APELLIDOS"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            'MyDataGridLista.Columns.Add(col5)

            Dim col6 As New DataGridViewTextBoxColumn
            With col6
                .HeaderText = "TIPO PERSONA"
                .Name = "JURIDICAONATURAL"
                .DataPropertyName = "IDTIPO_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            'MyDataGridLista.Columns.Add(col6)

            Dim col7 As New DataGridViewCheckBoxColumn
            With col7
                .HeaderText = "CLIENTE CORPORATIVO"
                .Name = "CLIENTE_CORPORATIVO"
                .DataPropertyName = "CLIENTE_CORPORATIVO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col8 As New DataGridViewTextBoxColumn
            With col8
                .HeaderText = "GERENTE GENERAL"
                .Name = "GERENTE_GENERAL"
                .DataPropertyName = "GERENTE_GENERAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col9 As New DataGridViewTextBoxColumn
            With col9
                .HeaderText = "REPRESENTANTE LEGAL"
                .Name = "REPRESENTANTE_LEGAL"
                .DataPropertyName = "REPRESENTANTE_LEGAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col10 As New DataGridViewTextBoxColumn
            With col10
                .HeaderText = "FECHA INGRESO"
                .Name = "FECHA_INGRESO"
                .DataPropertyName = "FECHA_INGRESO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col11 As New DataGridViewCheckBoxColumn
            With col11
                .HeaderText = "PAGO POST FACTURACION"
                .Name = "PAGO_POST_FACTURACION"
                .DataPropertyName = "PAGO_POST_FACTURACION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col12 As New DataGridViewTextBoxColumn
            With col12
                .HeaderText = "EMAIL"
                .Name = "EMAIL"
                .DataPropertyName = "EMAIL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col13 As New DataGridViewTextBoxColumn
            With col13
                .HeaderText = "APELLIDO PATERNO"
                .Name = "APELLIDO_PATERNO"
                .DataPropertyName = "APELLIDO_PATERNO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col14 As New DataGridViewTextBoxColumn
            With col14
                .HeaderText = "APELLIDO MATERNO"
                .Name = "APELLIDO_MATERNO"
                .DataPropertyName = "APELLIDO_MATERNO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col15 As New DataGridViewTextBoxColumn
            With col15
                .HeaderText = "NOMPRE PERSONA"
                .Name = "NOMPRE_PERSONA"
                .DataPropertyName = "NOMPRE_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col16 As New DataGridViewTextBoxColumn
            With col16
                .HeaderText = "NOMPRE PERSONA1"
                .Name = "NOMPRE_PERSONA1"
                .DataPropertyName = "NOMPRE_PERSONA1"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col17 As New DataGridViewTextBoxColumn
            With col17
                .HeaderText = "FECHA NACIMIENTO"
                .Name = "FECHA_NACIMIENTO"
                .DataPropertyName = "FECHA_NACIMIENTO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col18 As New DataGridViewTextBoxColumn
            With col18
                .HeaderText = "SEXO PERSONA"
                .Name = "SEXO_PERSONA"
                .DataPropertyName = "SEXO_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col19 As New DataGridViewCheckBoxColumn
            With col19
                .HeaderText = "ESMENOREDAD"
                .Name = "ESMENOREDAD"
                .DataPropertyName = "ESMENOREDAD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col20 As New DataGridViewCheckBoxColumn
            With col20
                .HeaderText = "AGENTE RETENCION"
                .Name = "AGENTE_RETENCION"
                .DataPropertyName = "AGENTE_RETENCION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col21 As New DataGridViewTextBoxColumn
            With col21
                .HeaderText = "IDTIPO DOC IDENTIDAD"
                .Name = "IDTIPO_DOC_IDENTIDAD"
                .DataPropertyName = "IDTIPO_DOC_IDENTIDAD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col22 As New DataGridViewTextBoxColumn
            With col22
                .HeaderText = "NU RETE SUNA"
                .Name = "NU_RETE_SUNA"
                .DataPropertyName = "NU_RETE_SUNA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col23 As New DataGridViewTextBoxColumn
            With col23
                .HeaderText = "IDRUBRO"
                .Name = "IDRUBRO"
                .DataPropertyName = "IDRUBRO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col24 As New DataGridViewTextBoxColumn
            With col24
                .HeaderText = "IDCLASIFICACION PERSONA"
                .Name = "IDCLASIFICACION_PERSONA"
                .DataPropertyName = "IDCLASIFICACION_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col25 As New DataGridViewTextBoxColumn
            With col25
                .HeaderText = "IDUSUARIO PERSONAL"
                .Name = "IDUSUARIO_PERSONAL"
                .DataPropertyName = "IDUSUARIO_PERSONAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col26 As New DataGridViewTextBoxColumn
            With col26
                .HeaderText = "IDROL USUARIO"
                .Name = "IDROL_USUARIO"
                .DataPropertyName = "IDROL_USUARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col27 As New DataGridViewTextBoxColumn
            With col27
                .HeaderText = "IP"
                .Name = "IP"
                .DataPropertyName = "IP"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col28 As New DataGridViewTextBoxColumn
            With col28
                .HeaderText = "FECHA REGISTRO"
                .Name = "FECHA_REGISTRO"
                .DataPropertyName = "FECHA_REGISTRO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col29 As New DataGridViewTextBoxColumn
            With col29
                .HeaderText = "IDUSUARIO PERSONALMOD"
                .Name = "IDUSUARIO_PERSONALMOD"
                .DataPropertyName = "IDUSUARIO_PERSONALMOD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col30 As New DataGridViewTextBoxColumn
            With col30
                .HeaderText = "IDROL USUARIOMOD"
                .Name = "IDROL_USUARIOMOD"
                .DataPropertyName = "IDROL_USUARIOMOD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col31 As New DataGridViewTextBoxColumn
            With col31
                .HeaderText = "IPMOD"
                .Name = "IPMOD"
                .DataPropertyName = "IPMOD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col32 As New DataGridViewTextBoxColumn
            With col32
                .HeaderText = "FECHA_ACTUALIZACION"
                .Name = "FECHA_ACTUALIZACION"
                .DataPropertyName = "FECHA_ACTUALIZACION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col33 As New DataGridViewTextBoxColumn
            With col33
                .HeaderText = "IDPAIS"
                .Name = "IDPAIS"
                .DataPropertyName = "IDPAIS"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col34 As New DataGridViewTextBoxColumn
            With col34
                .HeaderText = "IDDEPARTAMENTO"
                .Name = "IDDEPARTAMENTO"
                .DataPropertyName = "IDDEPARTAMENTO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col35 As New DataGridViewTextBoxColumn
            With col35
                .HeaderText = "IDPROVINCIA"
                .Name = "IDPROVINCIA"
                .DataPropertyName = "IDPROVINCIA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col36 As New DataGridViewTextBoxColumn
            With col36
                .HeaderText = "IDDISTRITO"
                .Name = "IDDISTRITO"
                .DataPropertyName = "IDDISTRITO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col37 As New DataGridViewTextBoxColumn
            With col37
                .HeaderText = "USUARIO"
                .Name = "USUARIO"
                .DataPropertyName = "USUARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col38 As New DataGridViewTextBoxColumn
            With col38
                .HeaderText = "ROL USUARIO"
                .Name = "ROL_USUARIO"
                .DataPropertyName = "ROL_USUARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col39 As New DataGridViewTextBoxColumn
            With col39
                .HeaderText = "IDFUNCIONARIO ACTUAL"
                .Name = "IDFUNCIONARIO_ACTUAL"
                .DataPropertyName = "IDFUNCIONARIO_ACTUAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col40 As New DataGridViewTextBoxColumn
            With col40
                .HeaderText = "FUNCIONARIO"
                .Name = "FUNCIONARIO"
                .DataPropertyName = "FUNCIONARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col41 As New DataGridViewCheckBoxColumn
            With col41
                .HeaderText = "¿PRESENTO_SOLICITUD?"
                .Name = "SOLICITUD_PENDIENTE"
                .DataPropertyName = "SOLICITUD_PENDIENTE"
                .ToolTipText = "Indica si la solicitud que presento este cliente esta Pendiente"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
            End With

            Dim col42 As New DataGridViewCheckBoxColumn
            With col42
                .HeaderText = "¿APROBADO?"
                .Name = "APROBADO"
                .DataPropertyName = "APROBADO"
                .ToolTipText = "Indica si la solicitud que presento este cliente esta Pendiente"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
            End With

            MyDataGridLista.Columns.AddRange(col0, col1, col2, Col3, col4, col5, col6, col7, col8, col9, col10, col11, col12, col13, col14, col15, col16, col17, col18, col19, col20, col21, col22, col23, col24, col25, col26, col27, col28, col29, col30, col31, col32, col33, col34, col35, col36, col37, col38, col39, col40, col41, col42)

            For i As Integer = 0 To 41
                MyDataGridLista.Columns(i).Visible = False
            Next

            'MyDataGridLista.Columns(0).Visible = True
            MyDataGridLista.Columns(2).Visible = True
            MyDataGridLista.Columns(4).Visible = True
            MyDataGridLista.Columns(5).Visible = True
            MyDataGridLista.Columns(40).Visible = True
            MyDataGridLista.Columns(41).Visible = True

            Return MydvListaClientes

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region

#Region " CARGA A LOS CLIENTES CON SOLICITUD PENDIENTE POR APROBAR Y APROBADAS TAMBIEN SOLO DE DETERMINADO FUNCIONARIO"
    ''' <summary>
    '''  Carga a Clientes con Solicitudes de Credito Pendientes de Aprobacion y Aprobadas tambien.
    ''' </summary>
    ''' <param name="MyDataGridLista"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CargarGrillaClientesSolicitudPendiente(ByVal MyDataGridLista As DataGridView, ByVal MyFuncionario As String) As DataView
        'datahelper
        'Dim rstListaClientes As ADODB.Recordset
        'Dim dtListaClientes As New DataTable

        'Dim Myobj As Object() = {"PKG_IVOPERSONA.SP_LISTA_CLIENTE_SOLICITUD_FUN", 4, MyFuncionario, 2}
        'rstListaClientes = VOCONTROLUSUARIO.fnSQLQuery(Myobj)
        'Dim da As New OleDbDataAdapter
        'da.Fill(dtListaClientes, rstListaClientes)
        'Dim MydvListaClientes As DataView

        Try
            Dim db As New BaseDatos
            db.Conectar()
            'hlamas 06-01-2014
            'db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CLIENTE_SOLICITUD_FUN", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CLIENTE_SOL_FUN_car", CommandType.StoredProcedure)
            db.AsignarParametro("iNOMBRE_FUNCIONARIO", MyFuncionario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_CLIENTE_SOLICITUD", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dtListaClientes As DataTable = db.EjecutarDataTable
            Dim MydvListaClientes As DataView
            MydvListaClientes = dtListaClientes.DefaultView
            With MyDataGridLista
                '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .DataSource = MydvListaClientes
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .VirtualMode = True
                '.RowHeadersWidth = 30
                .RowHeadersVisible = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            Dim col0 As New DataGridViewCheckBoxColumn
            With col0
                .HeaderText = "¿ACTIVO?"
                .Name = "ACTIVO"
                .DataPropertyName = "IDESTADO_REGISTRO"
                .Width = 62
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .Frozen = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            'MyDataGridLista.Columns.Add(col0)

            Dim col1 As New DataGridViewTextBoxColumn
            With col1
                .HeaderText = "ID"
                .Name = "ID"
                .DataPropertyName = "IDPERSONA"
                .ReadOnly = True
                .ToolTipText = "Identificador del cliente en la Base de Datos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            End With
            'MyDataGridLista.Columns.Add(col1)

            Dim col2 As New DataGridViewTextBoxColumn
            With col2
                .HeaderText = "CODIGO"
                .Name = "CODIGO"
                .DataPropertyName = "CODIGO_CLIENTE"
                .ToolTipText = "Código del Cliente"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            End With
            'MyDataGridLista.Columns.Add(col2)

            Dim Col3 As New DataGridViewTextBoxColumn
            With Col3
                .HeaderText = "DOCT."
                .Name = "DOCUMENTO"
                .DataPropertyName = "NU_DOCU_SUNA"
                .ToolTipText = "RUC en caso de Juridicos o DNI,LM... en caso de Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
            End With
            'MyDataGridLista.Columns.Add(Col3)

            Dim col4 As New DataGridViewTextBoxColumn
            With col4
                .HeaderText = "RAZON SOCIAL"
                .Name = "RAZONSOCIAL"
                .DataPropertyName = "RAZON_SOCIAL"
                .ToolTipText = "Razon Social para Personas Juridicos"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            'MyDataGridLista.Columns.Add(col4)

            Dim col5 As New DataGridViewTextBoxColumn
            With col5
                .HeaderText = "NOMBRE Y APELLIDOS"
                .Name = "NOMBREYAPELLIDO"
                .DataPropertyName = "NOMNRES_APELLIDOS"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            'MyDataGridLista.Columns.Add(col5)

            Dim col6 As New DataGridViewTextBoxColumn
            With col6
                .HeaderText = "TIPO PERSONA"
                .Name = "JURIDICAONATURAL"
                .DataPropertyName = "IDTIPO_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            'MyDataGridLista.Columns.Add(col6)

            Dim col7 As New DataGridViewCheckBoxColumn
            With col7
                .HeaderText = "CLIENTE CORPORATIVO"
                .Name = "CLIENTE_CORPORATIVO"
                .DataPropertyName = "CLIENTE_CORPORATIVO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col8 As New DataGridViewTextBoxColumn
            With col8
                .HeaderText = "GERENTE GENERAL"
                .Name = "GERENTE_GENERAL"
                .DataPropertyName = "GERENTE_GENERAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col9 As New DataGridViewTextBoxColumn
            With col9
                .HeaderText = "REPRESENTANTE LEGAL"
                .Name = "REPRESENTANTE_LEGAL"
                .DataPropertyName = "REPRESENTANTE_LEGAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col10 As New DataGridViewTextBoxColumn
            With col10
                .HeaderText = "FECHA INGRESO"
                .Name = "FECHA_INGRESO"
                .DataPropertyName = "FECHA_INGRESO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col11 As New DataGridViewCheckBoxColumn
            With col11
                .HeaderText = "PAGO POST FACTURACION"
                .Name = "PAGO_POST_FACTURACION"
                .DataPropertyName = "PAGO_POST_FACTURACION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col12 As New DataGridViewTextBoxColumn
            With col12
                .HeaderText = "EMAIL"
                .Name = "EMAIL"
                .DataPropertyName = "EMAIL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col13 As New DataGridViewTextBoxColumn
            With col13
                .HeaderText = "APELLIDO PATERNO"
                .Name = "APELLIDO_PATERNO"
                .DataPropertyName = "APELLIDO_PATERNO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col14 As New DataGridViewTextBoxColumn
            With col14
                .HeaderText = "APELLIDO MATERNO"
                .Name = "APELLIDO_MATERNO"
                .DataPropertyName = "APELLIDO_MATERNO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col15 As New DataGridViewTextBoxColumn
            With col15
                .HeaderText = "NOMPRE PERSONA"
                .Name = "NOMPRE_PERSONA"
                .DataPropertyName = "NOMPRE_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col16 As New DataGridViewTextBoxColumn
            With col16
                .HeaderText = "NOMPRE PERSONA1"
                .Name = "NOMPRE_PERSONA1"
                .DataPropertyName = "NOMPRE_PERSONA1"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col17 As New DataGridViewTextBoxColumn
            With col17
                .HeaderText = "FECHA NACIMIENTO"
                .Name = "FECHA_NACIMIENTO"
                .DataPropertyName = "FECHA_NACIMIENTO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col18 As New DataGridViewTextBoxColumn
            With col18
                .HeaderText = "SEXO PERSONA"
                .Name = "SEXO_PERSONA"
                .DataPropertyName = "SEXO_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col19 As New DataGridViewCheckBoxColumn
            With col19
                .HeaderText = "ESMENOREDAD"
                .Name = "ESMENOREDAD"
                .DataPropertyName = "ESMENOREDAD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col20 As New DataGridViewCheckBoxColumn
            With col20
                .HeaderText = "AGENTE RETENCION"
                .Name = "AGENTE_RETENCION"
                .DataPropertyName = "AGENTE_RETENCION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col21 As New DataGridViewTextBoxColumn
            With col21
                .HeaderText = "IDTIPO DOC IDENTIDAD"
                .Name = "IDTIPO_DOC_IDENTIDAD"
                .DataPropertyName = "IDTIPO_DOC_IDENTIDAD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col22 As New DataGridViewTextBoxColumn
            With col22
                .HeaderText = "NU RETE SUNA"
                .Name = "NU_RETE_SUNA"
                .DataPropertyName = "NU_RETE_SUNA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col23 As New DataGridViewTextBoxColumn
            With col23
                .HeaderText = "IDRUBRO"
                .Name = "IDRUBRO"
                .DataPropertyName = "IDRUBRO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col24 As New DataGridViewTextBoxColumn
            With col24
                .HeaderText = "IDCLASIFICACION PERSONA"
                .Name = "IDCLASIFICACION_PERSONA"
                .DataPropertyName = "IDCLASIFICACION_PERSONA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col25 As New DataGridViewTextBoxColumn
            With col25
                .HeaderText = "IDUSUARIO PERSONAL"
                .Name = "IDUSUARIO_PERSONAL"
                .DataPropertyName = "IDUSUARIO_PERSONAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col26 As New DataGridViewTextBoxColumn
            With col26
                .HeaderText = "IDROL USUARIO"
                .Name = "IDROL_USUARIO"
                .DataPropertyName = "IDROL_USUARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col27 As New DataGridViewTextBoxColumn
            With col27
                .HeaderText = "IP"
                .Name = "IP"
                .DataPropertyName = "IP"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col28 As New DataGridViewTextBoxColumn
            With col28
                .HeaderText = "FECHA REGISTRO"
                .Name = "FECHA_REGISTRO"
                .DataPropertyName = "FECHA_REGISTRO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col29 As New DataGridViewTextBoxColumn
            With col29
                .HeaderText = "IDUSUARIO PERSONALMOD"
                .Name = "IDUSUARIO_PERSONALMOD"
                .DataPropertyName = "IDUSUARIO_PERSONALMOD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col30 As New DataGridViewTextBoxColumn
            With col30
                .HeaderText = "IDROL USUARIOMOD"
                .Name = "IDROL_USUARIOMOD"
                .DataPropertyName = "IDROL_USUARIOMOD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col31 As New DataGridViewTextBoxColumn
            With col31
                .HeaderText = "IPMOD"
                .Name = "IPMOD"
                .DataPropertyName = "IPMOD"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col32 As New DataGridViewTextBoxColumn
            With col32
                .HeaderText = "FECHA_ACTUALIZACION"
                .Name = "FECHA_ACTUALIZACION"
                .DataPropertyName = "FECHA_ACTUALIZACION"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col33 As New DataGridViewTextBoxColumn
            With col33
                .HeaderText = "IDPAIS"
                .Name = "IDPAIS"
                .DataPropertyName = "IDPAIS"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col34 As New DataGridViewTextBoxColumn
            With col34
                .HeaderText = "IDDEPARTAMENTO"
                .Name = "IDDEPARTAMENTO"
                .DataPropertyName = "IDDEPARTAMENTO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col35 As New DataGridViewTextBoxColumn
            With col35
                .HeaderText = "IDPROVINCIA"
                .Name = "IDPROVINCIA"
                .DataPropertyName = "IDPROVINCIA"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col36 As New DataGridViewTextBoxColumn
            With col36
                .HeaderText = "IDDISTRITO"
                .Name = "IDDISTRITO"
                .DataPropertyName = "IDDISTRITO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col37 As New DataGridViewTextBoxColumn
            With col37
                .HeaderText = "USUARIO"
                .Name = "USUARIO"
                .DataPropertyName = "USUARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col38 As New DataGridViewTextBoxColumn
            With col38
                .HeaderText = "ROL USUARIO"
                .Name = "ROL_USUARIO"
                .DataPropertyName = "ROL_USUARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col39 As New DataGridViewTextBoxColumn
            With col39
                .HeaderText = "IDFUNCIONARIO ACTUAL"
                .Name = "IDFUNCIONARIO_ACTUAL"
                .DataPropertyName = "IDFUNCIONARIO_ACTUAL"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col40 As New DataGridViewTextBoxColumn
            With col40
                .HeaderText = "FUNCIONARIO"
                .Name = "FUNCIONARIO"
                .DataPropertyName = "FUNCIONARIO"
                .ToolTipText = "Nombres y Apellidos para Personas Naturales"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col41 As New DataGridViewCheckBoxColumn
            With col41
                .HeaderText = "¿PRESENTO_SOLICITUD?"
                .Name = "SOLICITUD_PENDIENTE"
                .DataPropertyName = "SOLICITUD_PENDIENTE"
                .ToolTipText = "Indica si la solicitud que presento este cliente esta Pendiente"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
            End With

            Dim col42 As New DataGridViewCheckBoxColumn
            With col42
                .HeaderText = "¿APROBADO?"
                .Name = "APROBADO"
                .DataPropertyName = "APROBADO"
                .ToolTipText = "Indica si la solicitud que presento este cliente esta Pendiente"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
            End With

            MyDataGridLista.Columns.AddRange(col0, col1, col2, Col3, col4, col5, col6, col7, col8, col9, col10, col11, col12, col13, col14, col15, col16, col17, col18, col19, col20, col21, col22, col23, col24, col25, col26, col27, col28, col29, col30, col31, col32, col33, col34, col35, col36, col37, col38, col39, col40, col41, col42)

            For i As Integer = 0 To 41
                MyDataGridLista.Columns(i).Visible = False
            Next

            'MyDataGridLista.Columns(0).Visible = True
            MyDataGridLista.Columns(2).Visible = True
            MyDataGridLista.Columns(4).Visible = True
            MyDataGridLista.Columns(5).Visible = True
            MyDataGridLista.Columns(40).Visible = True
            MyDataGridLista.Columns(41).Visible = True

            Return MydvListaClientes

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

#End Region

#Region " CREA EL FICHERO TXT "
    Public Sub GeneraArchivo(ByVal MyGrilla As DataGridView, ByVal Direccion As String)
        'Variables para abrir el archivo en modo de escritura
        Dim strStreamW As Stream
        Dim strStreamWriter As StreamWriter
        Try
            Dim ds As New DataSet

            'Dim FilePath As String = "C:\nombreArchivo.txt"
            Dim FilePath As String = Direccion

            'Se abre el archivo y si este no existe se crea
            strStreamW = File.OpenWrite(FilePath)
            strStreamWriter = New StreamWriter(strStreamW, _
                                System.Text.Encoding.UTF8)

            'Se traen los datos que necesitamos para el archivo
            'TraerDatosArchivo retorna un dataset pero perfectamente
            'podria ser cualquier otro tipo de objeto

            'ds = Negocios.TraerDatosArchivo()

            'Dim dr As DataRow
            Dim dr As DataGridViewRow

            Dim Nombre As String = ""
            Dim Apellido As String = ""
            Dim Email As String = ""

            'strStreamWriter.WriteLine("  " & "ID CLIENTE" & vbTab & "CODIGO CLIENTE" & vbTab & "        RAZON SOCIAL          ")
            'strStreamWriter.WriteLine("  " & "----------" & vbTab & "--------------" & vbTab & "------------------------------")
            strStreamWriter.WriteLine("  " & "ID CLIENTE" & vbTab & "CODIGO CLIENTE" & vbTab & "        RAZON SOCIAL          ")
            strStreamWriter.WriteLine("  " & "----------" & vbTab & "--------------" & vbTab & "------------------------------")

            For Each dr In MyGrilla.Rows
                'Obtenemos los datos del dataset
                Nombre = CStr(dr.Cells("ID").Value.ToString.PadRight(8))
                Apellido = CStr(dr.Cells("CODIGO").Value.ToString.PadRight(14))
                Email = CStr(dr.Cells("RAZONSOCIAL").Value.ToString.PadRight(60))

                'Escribimos la línea en el achivo de texto
                strStreamWriter.WriteLine("  " & "  " & Nombre & vbTab & Apellido & vbTab & Email)

            Next

            strStreamWriter.Close()

            MsgBox("El archivo se generó con éxito")

        Catch ex As Exception
            strStreamWriter.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region " BUSCA A UN CLIENTE POR CODIGO O RAZON SOCIAL"
    'Public Function ClientePrefactura2009_eliminarlo(ByVal Cod_Raz As Integer, ByVal CodigoCliente As String) As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_LISTA_GUIAS_CLIENTE", 6, Cod_Raz, 1, CodigoCliente, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function

    'Public Function ClientePrefactura_new2009(ByVal Cod_Raz As Integer, ByVal CodigoCliente As String, ByVal sfecha_inicio As String, ByVal sfecha_final As String, ByVal lnro_prefactura As String) As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_LISTA_GUIAS_CLIENTE_NEW", 12, Cod_Raz, 1, CodigoCliente, 2, sfecha_inicio, 2, sfecha_final, 2, lnro_prefactura, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function

    Public Function ClientePrefactura_new(ByVal Cod_Raz As Integer, ByVal CodigoCliente As String, ByVal sfecha_inicio As String, ByVal sfecha_final As String, ByVal lnro_prefactura As String, dt As String, producto As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_GUIAS_CLIENTE_NEW", CommandType.StoredProcedure)
            db.AsignarParametro("iBUSQUEDA_POR", Cod_Raz, OracleClient.OracleType.Int32)
            db.AsignarParametro("iNOMBRE_CLIENTE", CodigoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iFECHA_INICIO", sfecha_inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iFECHA_FINAL", sfecha_final, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNroprefactura", lnro_prefactura, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iDT", dt, OracleType.VarChar)
            db.AsignarParametro("ni_producto", producto, OracleType.Int32)
            db.AsignarParametro("oCLIENTE", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_GUIAS_CLIENTE", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_NRO_PREFACTURA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_SUB_CUENTA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_SUB_DESTINOS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function sp_Guias_to_prefac2009_eliminarlo(ByVal Cod_Raz As Integer, _
    'ByVal CodigoCliente As String, _
    'ByVal fecha_inicio As String, _
    'ByVal fecha_final As String, _
    'ByVal prefacturado As String) As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_PREFACTURACION.sp_Guias_to_prefac", 12, Cod_Raz, 1, CodigoCliente, 2, fecha_inicio, 2, fecha_final, 2, prefacturado, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function CargarArticulos_x_cliente_CC(ByVal iidcentro_costo As Integer, _
                                             ByVal MyDataGridLista As DataGridView, _
                                             ByVal icodigo_cliente As String, _
                                             ByVal iidtarifa_cliente As Integer, _
                                             ByVal iagencia_origen As Integer, _
                                             ByVal iagencia_destino As Integer) As DataView   ' Tepsa
        'datahelper
        'Dim rstArticulos As ADODB.Recordset
        'Dim dtArticulos As New DataTable
        'Dim MydvListaArticulos As DataView
        'icodigo_cliente = IIf(icodigo_cliente = "" Or IsDBNull(icodigo_cliente) = True, "null", icodigo_cliente)
        'Dim MyObjectArticulos As Object() = {"PKG_IVOPERSONA.SP_LISTA_ARTICULOS_DETALLE_cc", 12, iidcentro_costo, 1, icodigo_cliente, 2, iidtarifa_cliente, 1, iagencia_origen, 1, iagencia_destino, 1}
        'rstArticulos = VOCONTROLUSUARIO.fnSQLQuery(MyObjectArticulos)
        'Dim da As New OleDbDataAdapter
        'da.Fill(dtArticulos, rstArticulos)
        'MydvListaArticulos = dtArticulos.DefaultView
        'MyDataGridLista.Columns.Clear()

        Try
            Dim dtArticulos As New DataTable
            Dim MydvListaArticulos As DataView
            icodigo_cliente = IIf(icodigo_cliente = "" Or IsDBNull(icodigo_cliente) = True, "null", icodigo_cliente)

            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_ARTICULOS_DETALLE_cc", CommandType.StoredProcedure)
            db.AsignarParametro("P_IDCENTRO_COSTO", iidcentro_costo, OracleClient.OracleType.Int32)
            db.AsignarParametro("icodigo_cliente", icodigo_cliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("IID_TARIFA_CARGA_CLIENTE", iidtarifa_cliente, OracleClient.OracleType.Number)
            db.AsignarParametro("IID_AGENCIA_ORIGEN", iagencia_origen, OracleClient.OracleType.Number)
            db.AsignarParametro("IID_AGENCIA_DESTINO", iagencia_destino, OracleClient.OracleType.Number)
            db.AsignarParametro("oCUR_ARTICULOS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            dtArticulos = db.EjecutarDataTable

            MydvListaArticulos = dtArticulos.DefaultView
            MyDataGridLista.Columns.Clear()
            MydvListaArticulos = dtArticulos.DefaultView
            With MyDataGridLista
                '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .DataSource = MydvListaArticulos
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .VirtualMode = True
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            Dim col0 As New DataGridViewTextBoxColumn
            With col0
                .HeaderText = "IDARTICULOS"
                .Name = "IDARTICULOS"
                .DataPropertyName = "IDARTICULOS"
                .Frozen = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With

            Dim col1 As New DataGridViewTextBoxColumn
            With col1
                .HeaderText = "ARTICULO"
                .Name = "NOMBRE_ARTICULO"
                .DataPropertyName = "NOMBRE_ARTICULO"
                .ReadOnly = True
                .ToolTipText = "Nombre del Articulo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                .Frozen = True
            End With

            Dim col2 As New DataGridViewTextBoxColumn
            With col2
                .HeaderText = "PRECIO_BASE"
                .Name = "PRECIO_BASE"
                .DataPropertyName = "MONTO"
                .ToolTipText = "Precio Base del Artìculo"
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.NullValue = "0,00"
            End With

            Dim Col3 As New DataGridViewTextBoxColumn
            With Col3
                .HeaderText = "DESCUENTO"
                .Name = "DESCUENTO"
                .DataPropertyName = "DESCUENTO"
                .ToolTipText = "Descuento al Precio Base del Artículo."
                .ReadOnly = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With

            Dim Col4 As New DataGridViewTextBoxColumn
            With Col4
                .HeaderText = "PRECIO_FINAL"
                .Name = "PRECIO_FINAL"
                .DataPropertyName = "PRECIO_FINAL"
                .ToolTipText = "Precio Final del Artículo."
                .ReadOnly = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Format = "N4"
            End With

            MyDataGridLista.Columns.AddRange(col0, col1, col2, Col3, Col4)
            MyDataGridLista.Columns(0).Visible = False
            '
            Return MydvListaArticulos
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function FN_estado_facturado2009(ByVal VOCONTROLUSUARIO As Object, ByRef Cmb As System.Windows.Forms.ComboBox)
        '''''''''''''
        ''10/09/2007'
        '''''''''''''
        'Dim dT As New DataTable
        'Dim dv As New DataView
        'Dim DA As New OleDb.OleDbDataAdapter
        'Dim Rst As New ADODB.Recordset
        'Dim varSP_OBJECT() As Object = {"PKG_IVOGENERAL.SP_estado_dcto_guia_trans", 2}
        ''
        'Rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        'DA.Fill(dT, Rst)
        'Try
        '    dv = dT.DefaultView
        '    With Cmb
        '        .DataSource = dv
        '        .DisplayMember = "DESCRIPCION"
        '        .ValueMember = "FACTURADO"
        '    End With
        'Catch ex As System.Exception
        '    MsgBox(dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
        'Catch OEx As System.Data.OracleClient.OracleException
        '    MsgBox(OEx, MsgBoxStyle.Information, "Seguridad del Sistema")
        'End Try
    End Function
#End Region
#Region "Recupera clientes con datos"
    '06/06/2008  - Modificado por Omendoza - Recupera los datos del cliente 
    'Public Function BuscaCliente_datos2009_eliminarlo(ByVal CodigoCliente As String) As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_BUSCA_CLIENTE_datos", 4, CodigoCliente, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function

    Public Function BuscaCliente_datos(ByVal CodigoCliente As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_BUSCA_CLIENTE_datos", CommandType.StoredProcedure)
            db.AsignarParametro("iCODIGOPERSONA", CodigoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_RESULTADO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

#End Region
    'Public Function BuscaFuncionarioCliente2009(ByVal cliente As String) As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOPERSONA.SP_FUNCIONARIO_CLIENTE", 4, cliente, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function BuscaFuncionarioCliente(ByVal cliente As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'hlamas 06-01-2014
            'db.CrearComando("PKG_IVOPERSONA.SP_FUNCIONARIO_CLIENTE", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOPERSONA.SP_FUNCIONARIO_CLIENTE_car", CommandType.StoredProcedure)
            db.AsignarParametro("iCLIENTE", cliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_RESULTADO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function DireccionLegal(ByVal cliente As Integer) As Integer
        Try
            Dim db As New BaseDatos
            db.Conectar()
            Dim s As String = "select sf_get_direccion_legal(" & cliente & ") from dual"
            db.CrearComando(s, CommandType.Text)
            Return db.EjecutarEscalar()
            db.Desconectar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Module