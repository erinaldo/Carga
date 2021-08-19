'Imports System.Data.OleDb
Public Class frmConfiguracionTerminal
    'Dim da As New OleDbDataAdapter
    Dim dTable_Lista_Control_Comprobante As New DataTable()
    Dim DigitosSerie, DigitosDoc As Integer
    Dim CONTROLNUEVO As Integer
    Dim iROW_ACTUAL As Integer
    Dim iCOL_ACTUAL As Integer
    Public hnd As Long
    Sub GrillaMante()
        'DataGridViewLista.DataSource = dTable_Lista_Control_Comprobante
        With DataGridViewLista
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = True
            .AllowUserToOrderColumns = True
            .BackgroundColor = SystemColors.Window
            .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
            .ReadOnly = False
            .AutoGenerateColumns = False
            .DataSource = dTable_Lista_Control_Comprobante
            .VirtualMode = True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .RowHeadersWidth = 10
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5AF55")
        End With

        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .DisplayIndex = 0
            .DataPropertyName = "idcontrol_comprobantes"
            .HeaderText = "ID"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .ReadOnly = True
            .Visible = False
        End With
        DataGridViewLista.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DisplayIndex = 1
            .DataPropertyName = "tipo_comprobante"
            .HeaderText = "COMPROBANTE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        DataGridViewLista.Columns.Add(col1)

        Dim col2 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
        With col2
            .DisplayIndex = 2
            .DataPropertyName = "serie"
            .HeaderText = "SERIE"
            .Mask = Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
            '.DefaultCellStyle.NullValue = Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
            .Width = 60
        End With
        DataGridViewLista.Columns.Add(col2)

        Dim col3 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
        With col3
            .DisplayIndex = 3
            .DataPropertyName = "nro_documento"
            .HeaderText = "DOCUMENTO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Mask = Microsoft.VisualBasic.Right("000000000000000000", DigitosDoc)
            '.DefaultCellStyle.NullValue = Microsoft.VisualBasic.Right("000000000000000000", DigitosDoc)
            .Width = 60
        End With
        'DataGridViewLista.Columns.Insert(0, col3)
        DataGridViewLista.Columns.Add(col3)

        Dim col4 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
        With col4
            .DisplayIndex = 4
            .DataPropertyName = "nro_documento_fin"
            .HeaderText = "DOCUMENTO FINAL"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Mask = Microsoft.VisualBasic.Right("000000000000000000", DigitosDoc)
            '.DefaultCellStyle.NullValue = Microsoft.VisualBasic.Right("000000000000000000", DigitosDoc)
            .Width = 60
        End With
        DataGridViewLista.Columns.Add(col4)

        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .DisplayIndex = 5
            .DataPropertyName = "ipmaquina_impresion"
            .HeaderText = "IP MAQUINA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        DataGridViewLista.Columns.Add(col5)

        Dim col6 As New DataGridViewImageColumn
        With col6
            .DisplayIndex = 6
            '.DataPropertyName = "imagen"
            .HeaderText = "CAMBIAR IP"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .Visible = True
            .Image = Image.FromFile(strPlus1) 'strPlus1: variable creada en ModUtil
        End With
        DataGridViewLista.Columns.Add(col6)

        Dim col7 As New DataGridViewTextBoxColumn
        With col7
            .DisplayIndex = 7
            .DataPropertyName = "impresora"
            .HeaderText = "IMPRESORA"

            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .ReadOnly = True
            .Visible = True
            .Width = 300

        End With
        DataGridViewLista.Columns.Add(col7)

        Dim col8 As New DataGridViewTextBoxColumn
        With col8
            .DisplayIndex = 8
            .DataPropertyName = "tamano"
            .HeaderText = "TAMAÑO"

            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .ReadOnly = True
            .Visible = False
            .Width = 300

        End With
        DataGridViewLista.Columns.Add(col8)

        Dim col9 As New DataGridViewTextBoxColumn
        With col9
            .DisplayIndex = 9
            .DataPropertyName = "superior"
            .HeaderText = "SUPERIOR"

            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .ReadOnly = True
            .Visible = False
            .Width = 300

        End With
        DataGridViewLista.Columns.Add(col9)

        Dim col10 As New DataGridViewTextBoxColumn
        With col10
            .DisplayIndex = 10
            .DataPropertyName = "izquierda"
            .HeaderText = "IZQUIERDA"

            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .ReadOnly = True
            .Visible = False
            .Width = 300

        End With
        DataGridViewLista.Columns.Add(col10)

    End Sub
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
                objCONFIGURACION_DOCUMENTARIA.superior = 0
                objCONFIGURACION_DOCUMENTARIA.izquierda = 0
            Else
                objCONFIGURACION_DOCUMENTARIA.fnImpresora = DataGridViewLista.Rows().Item(i).DataGridView(7, i).Value.ToString()
                objCONFIGURACION_DOCUMENTARIA.Tamaño = IIf(IsDBNull(DataGridViewLista.Rows().Item(i).DataGridView(8, i).Value), 0, DataGridViewLista.Rows().Item(i).DataGridView(8, i).Value)
                objCONFIGURACION_DOCUMENTARIA.superior = IIf(IsDBNull(DataGridViewLista.Rows().Item(i).DataGridView(9, i).Value), 0, DataGridViewLista.Rows().Item(i).DataGridView(9, i).Value)
                objCONFIGURACION_DOCUMENTARIA.izquierda = IIf(IsDBNull(DataGridViewLista.Rows().Item(i).DataGridView(10, i).Value), 0, DataGridViewLista.Rows().Item(i).DataGridView(10, i).Value)
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
        'InitConexion()
        Try
            'dtoUSUARIOS.IP = Get_LocalIPAddress() '"192.168.50.41"

            Dim bEstado As Boolean
            objCONFIGURACION_DOCUMENTARIA.fnIDCONTROL_COMPROBANTES = 15
            bEstado = objCONFIGURACION_DOCUMENTARIA.fnDIGITOS_SERIE_DOCUMENTO
            If bEstado = True Then
                DigitosSerie = 3 'Temporalmente se coloca valores fijos   Tepsa  
                DigitosDoc = 7
                'DigitosSerie = objCONFIGURACION_DOCUMENTARIA.vSerie
                'DigitosDoc = objCONFIGURACION_DOCUMENTARIA.vDoc
            End If
            objCONFIGURACION_DOCUMENTARIA.fnIDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
            objCONFIGURACION_DOCUMENTARIA.fnIP = dtoUSUARIOS.IP
            objCONFIGURACION_DOCUMENTARIA.fnIDROL_USUARIO = dtoUSUARIOS.IdRol
            objCONFIGURACION_DOCUMENTARIA.fnIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            bEstado = objCONFIGURACION_DOCUMENTARIA.fnLISTA_CONTROL_COMPROBANTE()
            If bEstado = True Then
                'datahelper
                'da.Fill(dTable_Lista_Control_Comprobante, objCONFIGURACION_DOCUMENTARIA.rst_Lista_Control_Comprobante)
                dTable_Lista_Control_Comprobante = objCONFIGURACION_DOCUMENTARIA.rst_Lista_Control_Comprobante
                GrillaMante()
            Else

            End If

            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Try
            Call GrabarDatos()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DataGridViewLista_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridViewLista.CellBeginEdit
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

    Private Sub DataGridViewLista_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewLista.CellClick
        'Carga en un nuevo form la lista de todas las direcciones ip
        If e.RowIndex = -1 Then Exit Sub
        Dim frm As New frm_configura_impresion ' Frm_prueba -->Se camibo por frm_configura_impresion  que se usa por el correlativo por las impresoras 
        'Acceso.Asignar(frm, Me.hnd)
        iCOL_ACTUAL = e.ColumnIndex
        If iCOL_ACTUAL = 6 Then
            frm.Text = "Correlativo"
            'frm.Location = _
            'New System.Drawing.Point(e.ColumnIndex * 200, e.RowIndex * 200)
            frm.Width = 358
            frm.GrbOpciones.Visible = False
            frm.Tag = 1
            'If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            frm.ShowDialog()
            'End If

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
            'If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            frm.ShowDialog()
            If bControl Then
                DataGridViewLista.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = sImpresora
                DataGridViewLista.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).Value = mParametros(1)
                DataGridViewLista.Rows(e.RowIndex).Cells(e.ColumnIndex + 2).Value = mParametros(2)
                DataGridViewLista.Rows(e.RowIndex).Cells(e.ColumnIndex + 3).Value = mParametros(3)
            End If
            'End If
        End If
    End Sub

    Private Sub DataGridViewLista_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewLista.CellEndEdit
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
    Private Sub frmConfiguracionTerminal_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Try
            'If IsNothing(DataGridViewLista.CurrentRow.Index) Then Return
            If DataGridViewLista.CurrentRow.Index <> Nothing Then
                Dim i As Short = DataGridViewLista.CurrentRow.Index
                If bControl = True Then
                    DataGridViewLista.Rows().Item(i).DataGridView(5, i).Value = sIPMAQUINA
                    bControl = False
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub DataGridViewLista_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewLista.CellContentClick

    End Sub
End Class
