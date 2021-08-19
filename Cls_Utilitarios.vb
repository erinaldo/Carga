Imports System.Data.OleDb
Imports System.Data
Imports System.Drawing.Printing
Imports System.Drawing
Imports INTEGRACION_LN
Imports Microsoft.Office.Interop
'mports Microsoft.Office.Interop.Excel
Imports System.Windows.Forms
Imports System.Xml
Imports AccesoDatos

Public Class Cls_Utilitarios
    Private prtSettings As PrinterSettings
    Private Declare Function GetProfileString Lib "kernel32" Alias "GetProfileStringA" ( _
    ByVal lpAppName As String, _
    ByVal lpKeyName As String, _
    ByVal lpDefault As String, _
    ByVal lpReturnedString As String, _
    ByVal nSize As Long) As Long

    Dim hj As Principal

    Public Shared Sub DataTableToExcel(ByVal pDataTable As DataTable)

        'FileOpen(1, xRuta, OpenMode.Output)

        Dim sb As String = ""
        Dim dc As DataColumn
        For Each dc In pDataTable.Columns
            sb &= Trim(dc.Caption) & Microsoft.VisualBasic.ControlChars.Tab
        Next
        PrintLine(1, sb)

        Dim i As Integer = 0
        Dim dr As DataRow
        For Each dr In pDataTable.Rows
            i = 0 : sb = ""
            For Each dc In pDataTable.Columns
                If Not IsDBNull(dr(i)) Then
                    If IsDate(dr(i)) Then
                        sb &= Replace(Convert.ToString(Microsoft.VisualBasic.Format(dr(i), "dd/MM/yyyy")), Microsoft.VisualBasic.ControlChars.CrLf, "") & Microsoft.VisualBasic.ControlChars.Tab
                    Else
                        sb &= Replace(Trim(CStr(dr(i))), Microsoft.VisualBasic.ControlChars.CrLf, "") & Microsoft.VisualBasic.ControlChars.Tab
                    End If
                Else
                    sb &= Microsoft.VisualBasic.ControlChars.Tab
                End If
                i += 1
            Next

            PrintLine(1, sb)
        Next
        FileClose(1)

        'Dim vCultura As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture        
        'System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("es-SV")

        'Dim p As System.Diagnostics.Process = New System.Diagnostics.Process
        'p.EnableRaisingEvents = False
        'p.Start("Excel.exe", xRuta)

        'System.Threading.Thread.CurrentThread.CurrentCulture = vCultura


    End Sub

    Public Shared Function fnEXCELGrid_ConFormato(ByVal dGridView As DataGridView) As Boolean
        Try
            Dim xlApp As New Excel.Application()
            Dim xlBook As Excel.Workbook
            Dim xlSheet As Excel.Worksheet
            Dim rowIndex, colIndex, i, j As Integer
            rowIndex = 1
            colIndex = 0
            xlBook = xlApp.Workbooks().Add
            xlSheet = xlBook.Worksheets("hoja1")
            '  Dim cVisibles As Integer = 0

            'For i = 0 To dGridView.Columns().Count - 1

            '    If dGridView.Columns().Item(i).Visible = True Then
            '        cVisibles = cVisibles + 1
            '    End If
            'Next

            For i = 0 To dGridView.Columns().Count - 1
                If dGridView.Columns().Item(i).Visible = True Then
                    colIndex = colIndex + 1
                    xlApp.Cells(1, colIndex) = dGridView.Columns().Item(i).DataPropertyName

                End If
            Next
            For i = 0 To dGridView.Rows().Count - 1
                rowIndex = rowIndex + 1
                colIndex = 0
                For j = 0 To dGridView.Columns().Count - 1

                    If dGridView.Columns().Item(j).Visible = True Then
                        colIndex = colIndex + 1
                        xlApp.Cells(rowIndex, colIndex) = dGridView.Rows(i).Cells(j).Value
                    End If

                Next
            Next
            With xlSheet
                .Range(.Cells(1, 1), .Cells(1, colIndex)).Font.Name = "Arial"
                .Range(.Cells(1, 1), .Cells(1, colIndex)).Font.Bold = True
                .Range(.Cells(1, 1), .Cells(rowIndex, colIndex)).Borders.LineStyle = 1

            End With
            xlApp.Visible = True

        Catch ex As Exception
            MsgBox("Verifique sus Datos..", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return False
    End Function

    Public Sub AddItemGrid(ByVal DG As DataGridView)
        For x As Integer = 0 To DG.Rows.Count - 1  'Para el correlativo en la columna ITEM
            With DG
                .Rows(x).Cells("item").Value = x + 1
            End With
        Next
    End Sub
    Public Shared Sub FormatDataGridView(ByVal ObjDgv As DataGridView)
        Try
            ObjDgv.GridColor = Color.DarkGray
            ObjDgv.BorderStyle = BorderStyle.Fixed3D
            With ObjDgv
                .Font = New Font("Arial", 6.5!, FontStyle.Regular)
                .ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 6.5!, FontStyle.Bold)

                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#EFFBFB")
                .AllowUserToOrderColumns = False 'indica si está habilitado el cambio manual de la posición de las columnas
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = True

                .MultiSelect = True  'Obtiene o establece un valor que indica si el usuario puede seleccionar a la vez varias celdas, filas o columnas del control DataGridView.
                .AllowUserToResizeRows = False 'Obtiene o establece un valor que indica si los usuarios pueden cambiar el tamaño de las filas.
                .AllowUserToResizeColumns = False 'establece si elos usuarios pueden cambiar el tamaño de las columnas
                .DefaultCellStyle.WrapMode = DataGridViewTriState.False
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .VirtualMode = True
                .RowHeadersVisible = True
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            'ObjDgv.RowHeadersVisible = False
            ''ObjDgv.EnableHeadersVisualStyles = False
            'ObjDgv.ColumnHeadersDefaultCellStyle.Font = New Drawing.Font("Arial", 7, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
            ''ObjDgv.DefaultCellStyle.Font = New Drawing.Font("Arial", 8, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
            ''ObjDgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            'ObjDgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#EFFBFB")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function F_ObtenerUsuarioRed() As String
        Try
            Dim ws As Object
            Dim lstrMatUsu As String
            lstrMatUsu = ""
            ws = CreateObject("WScript.Network")
            lstrMatUsu = ws.UserName
            ws = Nothing
            Return UCase(lstrMatUsu)
        Catch ex As Exception
            Return ""
            MsgBox(Err.Description)
        End Try

    End Function
    'Public Function F_ObtenerDatosUsuarioRed(ByVal p_IntTipo As String) As String
    '    Dim lObj_Cls_ObtenerUsuario_LN As New Cls_ObtenerUsuario_LN
    '    Dim lStr_DatosUsuario As String
    '    Dim lStr_UsuarioEntrante As String
    '    Dim caden As String

    '    lStr_UsuarioEntrante = F_ObtenerUsuarioRed()

    '    lStr_DatosUsuario = lObj_Cls_ObtenerUsuario_LN.F_GetDatosUsuario_LN("dzegarra", p_IntTipo)
    '    Return lStr_DatosUsuario
    'End Function
    Public Sub S_ExportarDataGridViewExcel(ByVal xobjDatGrdViw As DataGridView)

        Dim lobjAppExc As Excel.Application
        Dim lobjLibExc As Excel.Workbook
        Dim lobjHojExc As Excel.Worksheet
        Dim lintI As Integer
        Dim lintY As Integer

        Try
            lobjAppExc = New Excel.Application
            lobjLibExc = lobjAppExc.Workbooks.Add
            lobjHojExc = lobjLibExc.Worksheets(1)

            With lobjHojExc
                'Le damos formato
                .Cells.Font.Name = "Tahoma"
                .Cells.Font.Size = 8
                .Cells.NumberFormat = "@"
                .Application.Visible = True
                'Trasladamos la data de la Grilla al Excel
                For lintY = 0 To xobjDatGrdViw.Columns.Count - 1
                    .Range(.Cells(1, lintY + 1), .Cells(1, lintY + 1)).Value = xobjDatGrdViw.Columns(lintY).Name
                Next lintY
                For lintI = 0 To xobjDatGrdViw.RowCount - 1
                    For lintY = 0 To xobjDatGrdViw.Columns.Count - 1
                        .Range(.Cells(lintI + 2, lintY + 1), .Cells(lintI + 2, lintY + 1)).Value = xobjDatGrdViw.Item(lintY, lintI).Value
                    Next lintY
                Next lintI
            End With
            MessageBox.Show("Se exportó con éxito la data", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("No pueden exportarse los datos al Excel, comuníquese con el administrador" & Chr(13) & "Error : " & ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub
    Public Shared Function F_EnviarCorreo(ByVal p_StrDe As String, ByVal p_StrPara As String, ByVal p_StrCc As String, ByVal p_StrAsunto As String, ByVal p_StrContenido As String) As Integer
        Try

            Dim SMTP As String = "192.168.219.38" '"smtp.gmail.com" 
            Dim lStr_CorreoDe As String = p_StrDe
            'Dim lStr_Contraseña As String = 'txtContraseña.Text
            Dim lStr_Para As String = p_StrPara
            Dim lStr_Cc As String = p_StrCc
            Dim lStr_Contenido As String = p_StrContenido
            Dim lSre_Asunto As String = p_StrAsunto
            Dim lInt_Puerto As Integer = 25

            'Declaro la variable para enviar el correo
            Dim correo As New System.Net.Mail.MailMessage()

            correo.From = New System.Net.Mail.MailAddress(lStr_CorreoDe)
            correo.Subject = lSre_Asunto
            correo.To.Add(lStr_Para)
            If lStr_Cc = "" Then
            Else
                correo.CC.Add(lStr_Cc)
            End If
            correo.Body = lStr_Contenido

            'Configuracion del servidor
            Dim Servidor As New System.Net.Mail.SmtpClient
            Servidor.Host = SMTP
            Servidor.Port = lInt_Puerto
            Servidor.EnableSsl = False 'en false es apra que no pida contraseña
            'Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
            'Servidor.Credentials = New System.Net.NetworkCredential()
            Servidor.Send(correo)
            ' MessageBox.Show("Se envió satisfactoriamente la Carta de Rechazo !", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return 1
        Catch ex As Exception
            MessageBox.Show("No se logro enviar correo " + ex.Message, "Correo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try

    End Function

    Public Function F_EnviarCorreoAdjunto(ByVal p_StrDe As String, ByVal p_StrPara As String, ByVal p_StrCc As String, ByVal p_StrAsunto As String, ByVal p_StrContenido As String, ByVal pStr_Ruta1 As String, ByVal pStr_Ruta2 As String, ByVal pStr_Ruta3 As String) As Integer
        Try

            Dim SMTP As String = "192.168.219.38" '"smtp.gmail.com" 
            Dim lStr_CorreoDe As String = p_StrDe
            'Dim lStr_Contraseña As String = 'txtContraseña.Text
            Dim lStr_Para As String = p_StrPara
            Dim lStr_Cc As String = p_StrCc
            Dim lStr_Contenido As String = p_StrContenido
            Dim lSre_Asunto As String = p_StrAsunto
            Dim lInt_Puerto As Integer = 25

            'Declaro la variable para enviar el correo
            Dim correo As New System.Net.Mail.MailMessage()

            'Dim archivo As New System.Net.Mail.Attachment("C:\prueba\02-ProgramacionOrientadaAObjetos.pdf") 'ruta de archivo
            Windows.Forms.Cursor.Show()
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            If pStr_Ruta1.Trim.Length > 3 Then
                Dim archivo1 As New System.Net.Mail.Attachment(pStr_Ruta1)
                correo.Attachments.Add(archivo1)
            End If

            If pStr_Ruta2.Trim.Length > 3 Then
                Dim archivo2 As New System.Net.Mail.Attachment(pStr_Ruta2)
                correo.Attachments.Add(archivo2)
            End If

            If pStr_Ruta3.Trim.Length > 3 Then
                Dim archivo3 As New System.Net.Mail.Attachment(pStr_Ruta3)
                correo.Attachments.Add(archivo3)
            End If

            correo.From = New System.Net.Mail.MailAddress(lStr_CorreoDe)

            correo.Subject = lSre_Asunto
            correo.To.Add(lStr_Para)
            If lStr_Cc = "" Then
            Else
                correo.CC.Add(lStr_Cc)
            End If
            correo.Body = lStr_Contenido

            'Configuracion del servidor
            Dim Servidor As New System.Net.Mail.SmtpClient
            Servidor.Host = SMTP
            Servidor.Port = lInt_Puerto
            Servidor.EnableSsl = False 'en false es apra que no pida contraseña
            'Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
            'Servidor.Credentials = New System.Net.NetworkCredential()
            Servidor.Send(correo)
            ' MessageBox.Show("Se envió satisfactoriamente la Carta de Rechazo !", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return 1
        Catch ex As Exception
            MessageBox.Show("No se logro enviar correo " + ex.Message, "Correo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try

    End Function
    Private Function F_SumarCampoDgw(ByVal P_ObjDgv As DataGridView, ByVal p_strcampo As String) As Double
        Dim total As Double = 0
        For Each fila As DataGridViewRow In P_ObjDgv.Rows
            If fila.Cells(p_strcampo).Value Is Nothing Then
                Exit Function
            Else
                total += Convert.ToDouble(fila.Cells(p_strcampo).Value)
            End If
        Next
        Return total
    End Function
    Public Function Establecer_Impresora(ByVal NamePrinter As String) As Boolean
        Try
            'ESTABLECE LA IMPRESORA A PREDETERMINADA
            Dim obj_Impresora As Object
            obj_Impresora = CreateObject("WScript.Network")
            obj_Impresora.setdefaultprinter(NamePrinter)
            obj_Impresora = Nothing
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Function Obtener_Impresora() As String
        'OBTIENE EL NOMBRE DE LA IMPRESORA PREDETERMINADA
        Dim instance As New Drawing.Printing.PrinterSettings

        Dim impresosaPredt As String = instance.PrinterName

        Return impresosaPredt


    End Function
    Function seleccionarImpresora() As String
        Dim lStr_ImpresoraSelec As String = ""
        Dim prtDialog As New PrintDialog
        If prtSettings Is Nothing Then
            prtSettings = New PrinterSettings
        End If

        With prtDialog
            .AllowPrintToFile = False
            .AllowSelection = False
            .AllowSomePages = True
            prtSettings.MinimumPage = 1
            prtSettings.MaximumPage = 99
            prtSettings.FromPage = 1
            prtSettings.ToPage = 99
            '
            .PrintToFile = False
            .ShowHelp = False
            .ShowNetwork = True
            .PrinterSettings = prtSettings

            If .ShowDialog() = DialogResult.OK Then
                prtSettings = .PrinterSettings
                lStr_ImpresoraSelec = .PrinterSettings.PrinterName.Trim
            Else
                lStr_ImpresoraSelec = ""
            End If

        End With

        Return lStr_ImpresoraSelec
    End Function

    Function F_SeleccionarImpresoraForm() As Boolean
        Dim lStr_Impresora As String = ""

        lStr_Impresora = seleccionarImpresora()
        If lStr_Impresora = "" Then
            MsgBox("Debe Seleccionar una impresora y dar Aceptar para poder Imprimir y cambiar la impresora", MsgBoxStyle.Information, "Aviso")
            Return False
        Else
            Establecer_Impresora(lStr_Impresora)
            Return True
        End If
    End Function
    Function F_Buscar(ByVal TextoABuscar As String, ByVal Columna As String, ByRef grid As DataGridView) As Boolean

        Dim encontrado As Boolean = False
        Dim ii As Integer
        Dim lstr_encontrado As String = "NO"
        If TextoABuscar = String.Empty Then Return False
        If grid.RowCount = 0 Then Return False
        grid.ClearSelection()
        If Columna = String.Empty Then
            For Each row As DataGridViewRow In grid.Rows
                For Each cell As DataGridViewCell In row.Cells
                    '                    If row.Cells(Columna).Value.ToString.Contains(TextoABuscar) Then
                    If row.Cells(Columna).Value.ToString = TextoABuscar Then
                        row.Selected = True

                        ii = row.Index
                        '                        grid.Rows(ii).Selected = True
                        lstr_encontrado = "SI"
                        'Return True
                    End If
                Next
            Next
        Else
            For Each row As DataGridViewRow In grid.Rows
                If row.IsNewRow Then Return False
                'If row.Cells(Columna).Value.ToString.Contains(TextoABuscar) Then
                If row.Cells(Columna).Value.ToString = TextoABuscar Then
                    row.Selected = True
                    ii = row.Index
                    ' MsgBox(grid.CurrentCell.RowIndex)
                    lstr_encontrado = "SI"
                    'Return True
                End If
            Next
        End If

        If lstr_encontrado = "SI" Then
            grid.FirstDisplayedScrollingRowIndex = ii
            Return True
        Else
            MsgBox("No se encontró el valor ingresado :" & TextoABuscar, MsgBoxStyle.Information, "Aviso")
            Return False
        End If
        Return encontrado
    End Function

    Public Sub LlenaComboItem(ByVal cboCombo As ComboBox, ByVal Tipo As String)
        cboCombo.Items.Clear()
        Select Case Tipo
            Case "SEXO"
                cboCombo.Items.Add("MASCULINO")
                cboCombo.Items.Add("FEMENINO")
            Case "PARENTESCO"
                cboCombo.Items.Add("TITULAR")
                cboCombo.Items.Add("DEPENDIENTE")
            Case "ESTADO"
                cboCombo.Items.Add("VIGENTE")
                cboCombo.Items.Add("ANULADO")
        End Select
        cboCombo.SelectedIndex = -1
    End Sub

    'Public Sub GenerarDT()

    '    dtDetalleCargo = New DataTable

    '    dtDetalleCargo.Columns.Add("COD_TIPO_DOCUMENTO")
    '    dtDetalleCargo.Columns.Add("COD_CLIENTE")
    '    dtDetalleCargo.Columns.Add("Ruc")
    '    dtDetalleCargo.Columns.Add("Cliente")
    '    dtDetalleCargo.Columns.Add("COD_AFILIADO")
    '    dtDetalleCargo.Columns.Add("Afiliado")
    '    dtDetalleCargo.Columns.Add("NRO_POLIZA")
    '    dtDetalleCargo.Columns.Add("NRO_CERTIFICADO")
    '    dtDetalleCargo.Columns.Add("COD_TIPO_PARENTESCO")
    '    dtDetalleCargo.Columns.Add("Titular")
    '    dtDetalleCargo.Columns.Add("NRO_AVISO_COBRANZA")
    '    dtDetalleCargo.Columns.Add("FEC_INICIO")
    '    dtDetalleCargo.Columns.Add("FEC_FIN")
    '    dtDetalleCargo.Columns.Add("FEC_EMISION")
    '    dtDetalleCargo.Columns.Add("NRO_DOC")
    '    dtDetalleCargo.Columns.Add("ANO_CARTA")
    '    dtDetalleCargo.Columns.Add("NRO_CARTA")
    '    dtDetalleCargo.Columns.Add("COD_TIPO_SEGURO")
    '    dtDetalleCargo.Columns.Add("COD_UNIDAD")
    '    dtDetalleCargo.Columns.Add("ANO")
    '    dtDetalleCargo.Columns.Add("NRO_CITA_DOCUMENTO")
    '    dtDetalleCargo.Columns.Add("FEC_ATENCION")
    '    dtDetalleCargo.Columns.Add("COD_ESPECIALIDAD")
    '    dtDetalleCargo.Columns.Add("COD_ACTIVIDAD")
    '    dtDetalleCargo.Columns.Add("COD_MEDICO_TRATANTE")
    '    dtDetalleCargo.Columns.Add("COD_MEDICO_INFORME")
    '    dtDetalleCargo.Columns.Add("ANOTACIONES_ESTADO")
    '    dtDetalleCargo.Columns.Add("COD_ENTREGA_RESULTADO")
    '    dtDetalleCargo.Columns.Add("COD_ENVIO_RESULTADO")
    '    dtDetalleCargo.Columns.Add("COD_PRODUCTO")
    'End Sub

    'Public Function F_TipoCargo(ByVal gStr_CodEmpresaUsuario As String) As String
    '    Select Case gStr_CodEmpresaUsuario
    '        Case "01"
    '            Return "DDC"
    '        Case "02"
    '            Return "CIT"
    '    End Select
    'End Function
    Sub LeerArchivoExcel(ByVal dgView As DataGridView, ByVal SLibro As String, ByVal sHoja As String)
        'La cadena de conexion para leer un archivo de Excel 2007 es Microsoft.ACE.OLEDB.12.0, tal como se muestra a continuación
        Dim m_sConn1 As String = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
        "Data Source=" & SLibro & ";" & _
        "Extended Properties=""Excel 12.0;HDR=YES"""

        'Generamos objeto de conexion
        Dim conn2 As New OleDbConnection(m_sConn1)
        Try
            'Definimos la consulta SQL para leer la informacion del archivo de Excel, noten que hacemos referencia a las Hojas, se puede leer cualquier hoja, siempre y cuando indiquemos el nombre con un signo $ y encerrado entre []
            Dim consulta As String
            consulta = "Select * From [" & sHoja & "$]"

            'Lo siguiente ejecutar la conexion y la consulta y llenar el DataSet que devolvera la función
            Dim da As New OleDbDataAdapter(consulta, conn2)

            Dim ds As New DataSet()


            da.Fill(ds)

            dgView.DataSource = ds.Tables(0)

            ' Return ds
        Catch ex As Exception
            MsgBox(ex.Message & SLibro)

        Finally
            conn2.Close()
        End Try
    End Sub
    Public Function ObtenerHojasEXCEL(ByVal Directorio As String)
        '
        ' Es necesario agregar una referencia a ADODB.
        '
        ' vas al menú Proyecto->Agregar referencia..., ahí seleccionarás ADODB
        '
        Try
            Dim Strconn As New ADODB.Connection ' Instancia una conexion
            With Strconn ' Se arma la cadena de conexion
                .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
     "Data Source=" & Directorio & ";" & _
     "Extended Properties=""Excel 12.0;HDR=YES"""

                .Open()
            End With
            Dim rst As ADODB.Recordset ' Se instancia el recordset
            rst = Strconn.OpenSchema(ADODB.SchemaEnum.adSchemaTables) ' Se guarda en el recordset el esquema de la tabla
            Dim cadenas() As String ' Se crea el array en donde se almacenaran los nobres de las hojas
            Dim contador As Integer ' Variable que se utiliza para control del array
            contador = 0
            While Not rst.EOF ' Mientras no se llege al final ( EOF ) del recordset se contiua en el bucle
                ReDim Preserve cadenas(contador) ' Se re-dimenciona el array preservando su contenido.
                cadenas(contador) = rst.Fields("TABLE_NAME").Value.ToString ' Se almacena en el array el nombre de la hoja
                rst.MoveNext() ' Salta a la siguiente hoja en el libro
                contador += 1 ' Incrementa el contador en uno
            End While
            Strconn.Close() ' Termina la conexion con el libro
            Strconn = Nothing ' Vacia la conexion

            Return (cadenas) ' Retorna el array para que pueda ser asigando a donde se desee

        Catch ex As OleDb.OleDbException
            MessageBox.Show("Error Cargando el Archivo de Excel: " & ex.Message)
        End Try

    End Function

    Public Sub AbrirExcelFormatoCargaMasiva(ByVal Ruta As String, ByVal Plantilla As String)
        Dim appExc As New Microsoft.Office.Interop.Excel.Application
        Dim wrkExc As Microsoft.Office.Interop.Excel.Workbook
        Dim shtExc As Microsoft.Office.Interop.Excel.Worksheet
        Dim Ejecutar As String
        'Dim ruta As String

        Try
            'Ruta = cadCnx.cadenaConeccion(rut, Plantilla)
            Ejecutar = Ruta & Plantilla
            If Ruta <> "" Then
                appExc.Visible = True
                wrkExc = appExc.Workbooks.Open(Ejecutar)
                shtExc = wrkExc.Worksheets(1)
            End If
        Catch ex As Exception
            Throw New Exception("Error en la cargar del archivo.")
        Finally
            If Not IsNothing(shtExc) Then
                shtExc = Nothing
                wrkExc = Nothing
                appExc = Nothing
            End If
        End Try
    End Sub

    Public Shared Sub EnviarCorreo(de As String, a As String, asunto As String, texto As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOGUIAS_ENVIO.SP_SEND_MAIL", CommandType.StoredProcedure)
            db.AsignarParametro("msg_from", de, OracleClient.OracleType.VarChar)
            db.AsignarParametro("msg_to", a, OracleClient.OracleType.VarChar)
            db.AsignarParametro("msg_subject", asunto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("msg_text", texto, OracleClient.OracleType.VarChar)
            db.EjecutarComando()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

End Class


