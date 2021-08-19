'Imports System.Data.OleDb
Public Class frmConfiguracionComprobante
    'Dim da As New OleDbDataAdapter
    Dim dTable_Lista_Control_Comprobante As New DataTable()
    Dim DigitosSerie, DigitosDoc As Integer
    Dim CONTROLNUEVO As Integer
    Dim iROW_ACTUAL As Integer
    Dim iCOL_ACTUAL As Integer

    Dim blnInicio As Boolean

    Public hnd As Long
    Sub GrabarDatos()
        'InitConexion()
        'Try
        Dim i As Integer
        Dim bEstado As Boolean
        i = DataGridViewLista.CurrentRow.Index
        '
        ' Tepsa    24/10/2006, Se le ha comentado para el nro de vías  
        '
        ''recorrer todos los registros para ver que la diferencia entre Documento inicial y Documento Final sea mayor o igual a 5
        'For i = 0 To DataGridViewLista.Rows.Count - 1
        '    If (IIf(IsDBNull(DataGridViewLista.Rows().Item(i).DataGridView(4, i).Value) = True, 0, DataGridViewLista.Rows().Item(i).DataGridView(4, i).Value)) - _
        '    IIf(IsDBNull(DataGridViewLista.Rows().Item(i).DataGridView(3, i).Value) = True, 0, DataGridViewLista.Rows().Item(i).DataGridView(3, i).Value) < 5 Then
        '        MsgBox("El nùmero del documento final debe ser mayor al inicial", MsgBoxStyle.Information)
        '        Exit Sub
        '    End If
        'Next

        i = 0
        For i = 0 To DataGridViewLista.Rows.Count - 1
            objCONFIGURACION_DOCUMENTARIA.fnIP = dtoUSUARIOS.IP
            objCONFIGURACION_DOCUMENTARIA.fnIDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
            objCONFIGURACION_DOCUMENTARIA.fnIDCONTROL_COMPROBANTES = DataGridViewLista.Rows().Item(i).DataGridView(0, i).Value.ToString()

            If DataGridViewLista.Rows().Item(i).DataGridView(2, i).Value.ToString = "" Then
                objCONFIGURACION_DOCUMENTARIA.fnSERIE = "null"
            Else
                objCONFIGURACION_DOCUMENTARIA.fnSERIE = RellenoRight(DigitosSerie, DataGridViewLista.Rows().Item(i).DataGridView(2, i).Value.ToString())
                'objCONFIGURACION_DOCUMENTARIA.fnSERIE = _
                'Microsoft.VisualBasic.Right("0000000000" & DataGridViewLista.Rows().Item(i).DataGridView(2, i).Value.ToString(), DigitosSerie)
            End If

            If DataGridViewLista.Rows().Item(i).DataGridView(3, i).Value.ToString = "" Then
                objCONFIGURACION_DOCUMENTARIA.fnNRO_DOCUMENTO = "null"
            Else
                objCONFIGURACION_DOCUMENTARIA.fnNRO_DOCUMENTO = RellenoRight(DigitosDoc, DataGridViewLista.Rows().Item(i).DataGridView(3, i).Value.ToString())
                'objCONFIGURACION_DOCUMENTARIA.fnNRO_DOCUMENTO = _
                'Microsoft.VisualBasic.Right("0000000000" & DataGridViewLista.Rows().Item(i).DataGridView(3, i).Value.ToString(), DigitosDoc)
            End If

            If DataGridViewLista.Rows().Item(i).DataGridView(4, i).Value.ToString = "" Then
                objCONFIGURACION_DOCUMENTARIA.fnNRO_DOCUMENTO_FIN = "null"
            Else
                objCONFIGURACION_DOCUMENTARIA.fnNRO_DOCUMENTO_FIN = RellenoRight(DigitosDoc, DataGridViewLista.Rows().Item(i).DataGridView(4, i).Value.ToString())
                'objCONFIGURACION_DOCUMENTARIA.fnNRO_DOCUMENTO_FIN = _
                'Microsoft.VisualBasic.Right("0000000000" & DataGridViewLista.Rows().Item(i).DataGridView(4, i).Value.ToString(), DigitosDoc)
            End If
            objCONFIGURACION_DOCUMENTARIA.fnIPMOD = dtoUSUARIOS.IP
            'Cargar en una lista las IPs de la Red para colocarlo en el DataGridViewLista(5,i) ya que si se coloca una IP
            'no existente ocurre un error!!!!
            objCONFIGURACION_DOCUMENTARIA.fnIPMAQUINA = IIf(IsDBNull(DataGridViewLista.Rows().Item(i).DataGridView(5, i).Value), "", DataGridViewLista.Rows().Item(i).DataGridView(5, i).Value)
            objCONFIGURACION_DOCUMENTARIA.fnIDROL_USUARIO = dtoUSUARIOS.IdRol  ' 1
            objCONFIGURACION_DOCUMENTARIA.fnIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin ' 1 
            If DataGridViewLista.Rows().Item(i).DataGridView(7, i).Value.ToString() = "" Then
                objCONFIGURACION_DOCUMENTARIA.fnImpresora = "null"
                objCONFIGURACION_DOCUMENTARIA.Tamaño = 0
                objCONFIGURACION_DOCUMENTARIA.Superior = 0
                objCONFIGURACION_DOCUMENTARIA.Izquierda = 0
            Else
                objCONFIGURACION_DOCUMENTARIA.fnImpresora = DataGridViewLista.Rows().Item(i).DataGridView(7, i).Value.ToString()
                objCONFIGURACION_DOCUMENTARIA.Tamaño = IIf(IsDBNull(DataGridViewLista.Rows().Item(i).DataGridView(8, i).Value), 0, DataGridViewLista.Rows().Item(i).DataGridView(8, i).Value)
                objCONFIGURACION_DOCUMENTARIA.Superior = IIf(IsDBNull(DataGridViewLista.Rows().Item(i).DataGridView(9, i).Value), 0, DataGridViewLista.Rows().Item(i).DataGridView(9, i).Value)
                objCONFIGURACION_DOCUMENTARIA.Izquierda = IIf(IsDBNull(DataGridViewLista.Rows().Item(i).DataGridView(10, i).Value), 0, DataGridViewLista.Rows().Item(i).DataGridView(10, i).Value)
            End If

            bEstado = objCONFIGURACION_DOCUMENTARIA.fnUPD_CONTROL_COMPRO()
        Next
        '
        If bEstado = True Then
            'limpiar el datatable para volver a cargar los datos
            'dTable_Lista_Control_Comprobante.Clear()
            'datahelper
            'da.Fill(dTable_Lista_Control_Comprobante, objCONFIGURACION_DOCUMENTARIA.rst_Upd_Control_Comprobante)
            dTable_Lista_Control_Comprobante = objCONFIGURACION_DOCUMENTARIA.rst_Upd_Control_Comprobante
            MsgBox("Datos Actualizados")
        End If
        'Catch ex As Exception
        'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
    End Sub

    Private Sub frmConfiguracionTerminal_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frmConfiguracionTerminal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub frmConfiguracionTerminal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        blnInicio = True
        DigitosSerie = 3
        DigitosDoc = 7
        ConfigurarDGVAgencia()
        ConfigurarDgvComprobante()
        ListarAgencias(0)
        blnInicio = False
        Return
        Try
            Dim bEstado As Boolean
            objCONFIGURACION_DOCUMENTARIA.fnIDCONTROL_COMPROBANTES = 15
            bEstado = objCONFIGURACION_DOCUMENTARIA.fnDIGITOS_SERIE_DOCUMENTO
            If bEstado = True Then
                DigitosSerie = 3 'Temporalmente se coloca valores fijos   Tepsa  
                DigitosDoc = 7
            End If
            objCONFIGURACION_DOCUMENTARIA.fnIDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
            objCONFIGURACION_DOCUMENTARIA.fnIP = dtoUSUARIOS.IP
            objCONFIGURACION_DOCUMENTARIA.fnIDROL_USUARIO = dtoUSUARIOS.IdRol
            objCONFIGURACION_DOCUMENTARIA.fnIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            bEstado = objCONFIGURACION_DOCUMENTARIA.fnLISTA_CONTROL_COMPROBANTE()
            If bEstado = True Then
                dTable_Lista_Control_Comprobante = objCONFIGURACION_DOCUMENTARIA.rst_Lista_Control_Comprobante
                'GrillaMante()
            Else
            End If

            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call GrabarDatos()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DataGridViewLista_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        'para que no se caiga el Sistema si es que es null el campo y la mascara generá error al ingresar un dato null
        iROW_ACTUAL = e.RowIndex
        iCOL_ACTUAL = e.ColumnIndex
        If iCOL_ACTUAL = 2 Then
            If IsDBNull(DataGridViewLista(iCOL_ACTUAL, iROW_ACTUAL).Value) Then
                DataGridViewLista(iCOL_ACTUAL, iROW_ACTUAL).Value = Microsoft.VisualBasic.Right("00000000000", DigitosSerie)
            End If
        End If
        If iCOL_ACTUAL = 3 Or iCOL_ACTUAL = 4 Then
            If IsDBNull(DataGridViewLista(iCOL_ACTUAL, iROW_ACTUAL).Value) Then
                DataGridViewLista(iCOL_ACTUAL, iROW_ACTUAL).Value = Microsoft.VisualBasic.Right("00000000000", DigitosDoc)
            End If
        End If
    End Sub

    Private Sub DataGridViewLista_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        'Carga en un nuevo form la lista de todas las direcciones ip
        If e.RowIndex = -1 Then Exit Sub
        Dim frm As New frm_configura_impresion ' Frm_prueba -->Se camibo por frm_configura_impresion  que se usa por el correlativo por las impresoras 
        Acceso.Asignar(frm, Me.hnd)
        iCOL_ACTUAL = e.ColumnIndex
        If iCOL_ACTUAL = 6 Then
            frm.Text = "Correlativo"
            'frm.Location = _
            'New System.Drawing.Point(e.ColumnIndex * 200, e.RowIndex * 200)
            frm.Width = 358
            frm.GrbOpciones.Visible = False
            frm.Tag = 1
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.ShowDialog()
            End If

            If bControl Then DataGridViewLista.Rows(e.RowIndex).Cells(5).Value = sIPMAQUINA
        ElseIf iCOL_ACTUAL = 7 Then
            frm.Text = "Impresoras"
            frm.GrbOpciones.Visible = True
            frm.Button1.Left = 342
            frm.Button2.Left = 432
            frm.sImp = IIf(IsDBNull(DataGridViewLista.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "", DataGridViewLista.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
            frm.iTamaño = IIf(IsDBNull(DataGridViewLista.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).Value), 0, DataGridViewLista.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).Value)
            frm.iSuperior = IIf(IsDBNull(DataGridViewLista.Rows(e.RowIndex).Cells(e.ColumnIndex + 2).Value), 0, DataGridViewLista.Rows(e.RowIndex).Cells(e.ColumnIndex + 2).Value)
            frm.iIzquierda = IIf(IsDBNull(DataGridViewLista.Rows(e.RowIndex).Cells(e.ColumnIndex + 3).Value), 0, DataGridViewLista.Rows(e.RowIndex).Cells(e.ColumnIndex + 3).Value)

            frm.Tag = 2
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frm.ShowDialog()
                If bControl Then
                    DataGridViewLista.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = sImpresora
                    DataGridViewLista.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).Value = mParametros(1)
                    DataGridViewLista.Rows(e.RowIndex).Cells(e.ColumnIndex + 2).Value = mParametros(2)
                    DataGridViewLista.Rows(e.RowIndex).Cells(e.ColumnIndex + 3).Value = mParametros(3)
                End If
            End If
        End If
    End Sub

    Private Sub DataGridViewLista_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            Dim row As Short = e.RowIndex
            Dim col As Short = e.ColumnIndex
            If DataGridViewLista.Rows(e.RowIndex).Cells(3).Value.ToString = "" Or DataGridViewLista.Rows(e.RowIndex).Cells(4).Value.ToString = "" Then Exit Sub
            If col = 4 Or col = 3 Then
                If Int(DataGridViewLista(3, row).Value) > Int(DataGridViewLista(4, row).Value) Then
                    MsgBox("Número de inicio no puede ser mayor al de fin")
                    DataGridViewLista.Rows(e.RowIndex).Cells(4).Value = _
                    DataGridViewLista.Rows(e.RowIndex).Cells(3).Value + 1
                    'Microsoft.VisualBasic.Right("000000000001", DigitosDoc)
                End If
            End If


            If col = 5 Then
                If ValidarEXP_REG_IP(DataGridViewLista(5, row).Value).ToString = False Then
                    MsgBox("Dirección IP NO VALIDA", MsgBoxStyle.Information)
                    DataGridViewLista(5, row).Value = dtoUSUARIOS.IP
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    'Función ProcessCmdKey de MyBase para avanzar con la tecla Enter en lugar del Tab
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean = True
        Dim flat As Boolean = True
        Try
            Dim var As Integer = msg.WParam.ToInt32
            If msg.WParam.ToInt32 = Keys.Enter Then
                SendKeys.Send("{Tab}")
            Else
                flat = MyBase.ProcessCmdKey(msg, KeyData)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flat
    End Function
    Private Sub frmConfiguracionTerminal_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        If DataGridViewLista.CurrentRow.Index <> Nothing Then
            Dim i As Short = DataGridViewLista.CurrentRow.Index
            If bControl = True Then
                DataGridViewLista.Rows().Item(i).DataGridView(5, i).Value = sIPMAQUINA
                bControl = False
            End If
        End If
    End Sub

    Sub ConfigurarDgvComprobante()
        'DataGridViewLista.DataSource = dTable_Lista_Control_Comprobante
        With dgvComprobante
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = True
            .AllowUserToOrderColumns = True
            '.BackgroundColor = SystemColors.Window
            '.Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
            .ReadOnly = False
            .AutoGenerateColumns = False
            '.DataSource = dTable_Lista_Control_Comprobante
            .VirtualMode = True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .RowHeadersWidth = 20
            '.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
            '.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            '.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5AF55")
        End With

        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .DisplayIndex = 0
            .DataPropertyName = "id"
            .HeaderText = "id" : .Name = "id"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .ReadOnly = True
            .Visible = False
        End With
        dgvComprobante.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DisplayIndex = 1
            .DataPropertyName = "tipo"
            .HeaderText = "Tipo Comprobante" : .Name = "tipo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .ReadOnly = True
        End With
        dgvComprobante.Columns.Add(col1)

        Dim col2 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
        With col2
            .DisplayIndex = 2
            .DataPropertyName = "serie"
            .HeaderText = "Nº Serie" : .Name = "serie"
            .Mask = Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
            '.DefaultCellStyle.NullValue = Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
            .Width = 100
        End With
        dgvComprobante.Columns.Add(col2)

        Dim col3 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
        With col3
            .DisplayIndex = 3
            .DataPropertyName = "numero_inicio"
            .HeaderText = "Nº Inicio" : .Name = "numero_inicio"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .Mask = Microsoft.VisualBasic.Right("000000000000000000", DigitosDoc)
            '.DefaultCellStyle.NullValue = Microsoft.VisualBasic.Right("000000000000000000", DigitosDoc)
            .Width = 100
        End With
        'DataGridViewLista.Columns.Insert(0, col3)
        dgvComprobante.Columns.Add(col3)

        Dim col4 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
        With col4
            .DisplayIndex = 4
            .DataPropertyName = "numero_fin"
            .HeaderText = "Nº Fin" : .Name = "numero_fin"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .Mask = Microsoft.VisualBasic.Right("000000000000000000", DigitosDoc)
            '.DefaultCellStyle.NullValue = Microsoft.VisualBasic.Right("000000000000000000", DigitosDoc)
            .Width = 100
        End With
        'DataGridViewLista.Columns.Insert(0, col3)
        dgvComprobante.Columns.Add(col4)

        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .DisplayIndex = 5
            .DataPropertyName = "idtipo"
            .HeaderText = "idtipo" : .Name = "idtipo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .Visible = False
            .ReadOnly = True
        End With
        dgvComprobante.Columns.Add(col5)

    End Sub
    Private Sub ConfigurarDGVAgencia()
        With dgvAgencias
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            .RowHeadersWidth = 20
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .HeaderText = "Nº Id" : .Visible = False
            End With
            x += +1
            Dim col_agencia As New DataGridViewTextBoxColumn
            With col_agencia
                .Name = "descripcion" : .DataPropertyName = "descripcion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Agencia" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With

            .Columns.AddRange(col_id, col_agencia)
        End With
    End Sub
    Sub ListarAgencias(ciudad As Integer)
        Dim obj As New dtoCONFIGURACION_DOCUMENTARIA
        With Me.dgvAgencias
            .DataSource = obj.ListarAgencias(ciudad)
        End With
    End Sub
    Sub ListarComprobantes(agencia As Integer)
        Dim obj As New dtoCONFIGURACION_DOCUMENTARIA
        With Me.dgvComprobante
            .DataSource = obj.ListarComprobantes(agencia)
        End With
    End Sub
    Private Sub dgvAgencias_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAgencias.RowEnter
        If blnInicio Then
            Return
        End If

        Dim intAgencia As Integer
        intAgencia = dgvAgencias.Rows(e.RowIndex).Cells("id").Value
        ListarComprobantes(intAgencia)
    End Sub

    Private Sub dgvComprobante_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvComprobante.CellBeginEdit
        'para que no se caiga el Sistema si es que es null el campo y la mascara generá error al ingresar un dato null
        iROW_ACTUAL = e.RowIndex
        iCOL_ACTUAL = e.ColumnIndex
        If iCOL_ACTUAL = 2 Then
            If IsDBNull(dgvComprobante(iCOL_ACTUAL, iROW_ACTUAL).Value) Or IsNothing(dgvComprobante(iCOL_ACTUAL, iROW_ACTUAL).Value) Then
                dgvComprobante(iCOL_ACTUAL, iROW_ACTUAL).Value = Microsoft.VisualBasic.Right("00000000000", DigitosSerie)
            End If
        End If
        If iCOL_ACTUAL = 3 Or iCOL_ACTUAL = 4 Then
            If IsDBNull(dgvComprobante(iCOL_ACTUAL, iROW_ACTUAL).Value) Or IsNothing(dgvComprobante(iCOL_ACTUAL, iROW_ACTUAL).Value) Then
                dgvComprobante(iCOL_ACTUAL, iROW_ACTUAL).Value = Microsoft.VisualBasic.Right("00000000000", DigitosDoc)
            End If
        End If
    End Sub

    Private Sub dgvComprobante_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvComprobante.CellEndEdit
        Dim row As Short = e.RowIndex
        Dim col As Short = e.ColumnIndex
        If col = 4 Or col = 3 Then
            Dim intInicio As Long, intFin As Long
            If IsDBNull(dgvComprobante(3, row).Value) Then
                intInicio = 0
            Else
                intInicio = Int(dgvComprobante(3, row).Value)
            End If
            If IsDBNull(dgvComprobante(4, row).Value) Then
                intFin = 0
            Else
                intFin = Int(dgvComprobante(4, row).Value)
            End If
            If intInicio = 0 Or intFin = 0 Then Return
            If intInicio > intFin Then
                MessageBox.Show("Nº de inicio no puede ser mayor al de Nº de fin", "Numerador de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvComprobante.Rows(e.RowIndex).Cells(4).Value = _
                dgvComprobante.Rows(e.RowIndex).Cells(3).Value + 1
            End If
        End If
    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Sub Grabar()
        Try
            With Me.dgvComprobante
                If .Rows.Count > 0 Then
                    Cursor = Cursors.WaitCursor
                    Dim intId As Integer, intTipo As Integer, strSerie As String, intSerieDigitos As Integer
                    Dim strInicio As String, strFin As String, intDocumentoDigito As Integer
                    Dim strIp As String, intUsuario As Integer, intAgencia As Integer = dgvAgencias.CurrentRow.Cells("id").Value
                    Dim blnGraba As Boolean = False

                    Dim obj As New dtoCONFIGURACION_DOCUMENTARIA
                    For Each row As DataGridViewRow In .Rows
                        intId = IIf(IsDBNull(row.Cells("id").Value), 0, row.Cells("id").Value)
                        intTipo = row.Cells("idtipo").Value
                        If Not IsDBNull(row.Cells("serie").Value) Then
                            If Val(row.Cells("serie").Value) > 0 Then
                                strSerie = (row.Cells("serie").Value)
                            Else
                                strSerie = 0
                            End If
                        Else
                            strSerie = 0
                        End If
                        intSerieDigitos = DigitosSerie
                        If Not IsDBNull(row.Cells("numero_inicio").Value) Then
                            If Val(row.Cells("numero_inicio").Value) > 0 Then
                                strInicio = (row.Cells("numero_inicio").Value)
                            Else
                                strInicio = 0
                            End If
                        Else
                            strInicio = 0
                        End If
                        If Not IsDBNull(row.Cells("numero_fin").Value) Then
                            If Val(row.Cells("numero_fin").Value) > 0 Then
                                strFin = (row.Cells("numero_fin").Value)
                            Else
                                strFin = 0
                            End If
                        Else
                            strFin = 0
                        End If
                        intDocumentoDigito = DigitosDoc
                        strIp = dtoUSUARIOS.IP
                        intUsuario = dtoUSUARIOS.IdLogin

                        obj.GrabarComprobante(intId, intTipo, strSerie, intSerieDigitos, strInicio, strFin, intDocumentoDigito, strIp, intUsuario, intAgencia)
                    Next
                    Me.ListarComprobantes(intAgencia)
                    Cursor = Cursors.Default
                Else
                    MessageBox.Show("No se encontraron comprobantes", "Numerador de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End With
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tsbGrabar_Click(sender As Object, e As System.EventArgs) Handles tsbGrabar.Click
        Grabar()
    End Sub

    Private Sub dgvAgencias_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAgencias.CellContentClick

    End Sub
End Class
