Public Class frmconsultadatosmensajeria
#Region "Variables Publicas"
    Public hnd As Long
#End Region
#Region "Variables"
    '
    Dim objdatosmensajeria As New dto_datosmensajeria
    'Dim odba_datosmensajeria As New OleDb.OleDbDataAdapter
    'datahelper
    'Dim rst_datosmensajeria As New ADODB.Recordset
    Dim rst_datosmensajeria As DataTable
    Dim dt_datosmensajeria As New DataTable
    Dim dv_datosmensajeria As New DataView
    Dim bIngreso As Boolean = False
    '
#End Region
#Region "Eventos Adicional"
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
#End Region
#Region "Eventos"

    Private Sub frmconsultadatosmensajeria_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frmconsultadatosmensajeria_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    'Load 
    Private Sub frmconsultadatosmensajeria_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Limpiar los campos   
        Dim ll_idusuario_venta As Long
        Try
            ToolStripMenuItem1.Text = "&Datos Comprobante"
            ToolStripMenuItem2.Enabled = False
            ToolStripMenuItem3.Enabled = False
            ToolStripMenuItem4.Enabled = False
            ToolStripMenuItem5.Enabled = False
            ToolStripMenuItem6.Enabled = False
            SelectMenu(0)
            ' Recupera los datos 
            Me.DTP_fec_inicio.Text = dtoUSUARIOS.dfecha_sistema
            Me.DTP_fec_final.Text = dtoUSUARIOS.dfecha_sistema
            '
            objdatosmensajeria.idusuario_venta = dtoUSUARIOS.IdLogin ' Usuario 
            objdatosmensajeria.fecha_venta = dtoUSUARIOS.dfecha_sistema
            '
            'datahelper
            'rst_datosmensajeria = objdatosmensajeria.fn_Listar_documentos()
            rst_datosmensajeria = objdatosmensajeria.fn_Listar_documentos
            'datahelper
            'odba_datosmensajeria.Fill(dt_datosmensajeria, rst_datosmensajeria)           
            dt_datosmensajeria = rst_datosmensajeria
            dv_datosmensajeria = dt_datosmensajeria.DefaultView
            '
            formato_grilla()
            dgv_consulta.DataSource = dv_datosmensajeria
            '

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub txt_documento_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_documento.Leave
        'datahelper
        'Dim lrst_mensaje As New ADODB.Recordset
        'Dim ldt_mensaje As New DataTable
        Dim lrst_mensaje As New DataTable
        Dim ldt_mensaje As New DataTable

        Dim ls_fecha, ls_mensaje As String
        Dim ll_cod_mensaje As Long
        Try
            If Me.txt_documento.Text <> "" Then
                objdatosmensajeria.nro_documento = Me.txt_documento.Text
                objdatosmensajeria.idusuario_venta = dtoUSUARIOS.IdLogin
                lrst_mensaje = objdatosmensajeria.fn_verificar_datos()
                ldt_mensaje = lrst_mensaje
                If ldt_mensaje.Rows.Count > 0 Then
                    ls_fecha = CType(ldt_mensaje.Rows(0).Item(0), String)
                    MsgBox("Documento ha sido ingresado el día " & ls_fecha, MsgBoxStyle.Information, "Datos del Cliente")
                    Me.txt_documento.Text = ""
                    Exit Sub
                End If
                'datahelper
                'odba_datosmensajeria.Fill(ldt_mensaje, lrst_mensaje)
                'If ldt_mensaje.Rows.Count > 0 Then
                '    ls_fecha = CType(ldt_mensaje.Rows(0)(0), String)
                '    MsgBox("Documento ha sido ingresado el día " & ls_fecha, MsgBoxStyle.Information, "Datos del Cliente")
                '    Me.txt_documento.Text = ""
                '    Exit Sub
                'End If

                objdatosmensajeria.fecha_venta = dtoUSUARIOS.dfecha_sistema
                Dim ds As DataSet = objdatosmensajeria.fn_actualizar_datos
                lrst_mensaje = ds.Tables(0)
                rst_datosmensajeria = ds.Tables(1)

                If IsDBNull(lrst_mensaje.Rows(0).Item(0)) = False Then
                    ll_cod_mensaje = CType(lrst_mensaje.Rows(0).Item(0), Long)

                    If ll_cod_mensaje <> 0 Then
                        ls_mensaje = CType(lrst_mensaje.Rows(0).Item(1), String)
                        MsgBox(ls_mensaje, MsgBoxStyle.Exclamation, "Datos del Cliente")
                        Exit Sub
                    End If
                    dt_datosmensajeria = Nothing
                    dv_datosmensajeria = Nothing

                    dt_datosmensajeria = New DataTable
                    dv_datosmensajeria = New DataView
                    dt_datosmensajeria = rst_datosmensajeria
                    dv_datosmensajeria = dt_datosmensajeria.DefaultView
                    formato_grilla()
                    dgv_consulta.DataSource = dv_datosmensajeria
                    Me.txt_documento.Text = ""
                    Me.txt_documento.Focus()
                End If
            End If
            'datahelper
            '    lrst_mensaje = Nothing
            '    rst_datosmensajeria = Nothing
            '    lrst_mensaje = objdatosmensajeria.fn_actualizar_datos
            '    rst_datosmensajeria = lrst_mensaje.NextRecordset
            '    '
            '    If IsDBNull(lrst_mensaje.Fields(0).Value) = False Then
            '        ll_cod_mensaje = CType(lrst_mensaje.Fields(0).Value, Long)
            '        '
            '        If ll_cod_mensaje <> 0 Then
            '            ls_mensaje = CType(lrst_mensaje.Fields(1).Value, String)
            '            MsgBox(ls_mensaje, MsgBoxStyle.Exclamation, "Datos del Cliente")
            '            Exit Sub
            '        End If
            '        dt_datosmensajeria = Nothing
            '        dv_datosmensajeria = Nothing
            '        '
            '        dt_datosmensajeria = New DataTable
            '        dv_datosmensajeria = New DataView
            '        odba_datosmensajeria.Fill(dt_datosmensajeria, rst_datosmensajeria)
            '        dv_datosmensajeria = dt_datosmensajeria.DefaultView
            '        '
            '        formato_grilla()
            '        '
            '        dgv_consulta.DataSource = dv_datosmensajeria
            '        Me.txt_documento.Text = ""
            '        Me.txt_documento.Focus()
            '    End If
            '    '
            'End If
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
        End Try
    End Sub
#End Region
#Region "Procedimientos y Funciones"
    Private Sub ExportarExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarExcelToolStripMenuItem.Click
        Try
            fnEXCELGrid(dgv_consulta)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Sub formato_grilla()
        Try
            dgv_consulta.Columns.Clear()
            With dgv_consulta
                .AllowUserToOrderColumns = True
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                .AutoGenerateColumns = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                '    '.DataSource = dtable_Lista_Control_Comprobante
                '    .VirtualMode = False
                '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            '
            Dim REMITENTE As New DataGridViewTextBoxColumn
            With REMITENTE '0
                .DisplayIndex = 0
                .DataPropertyName = "REMITENTE"
                .Name = "REMITENTE"
                .HeaderText = "Remitente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(REMITENTE)
            '
            Dim NOMBRE_CONSIGNADO As New DataGridViewTextBoxColumn
            With NOMBRE_CONSIGNADO '1
                .DisplayIndex = 1
                .DataPropertyName = "NOMBRE_CONSIGNADO"
                .Name = "NOMBRE_CONSIGNADO"
                .HeaderText = "Consignado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(NOMBRE_CONSIGNADO)
            '
            Dim NOMBRE_FUNCIONARIO As New DataGridViewTextBoxColumn
            With NOMBRE_FUNCIONARIO  '2
                .DisplayIndex = 2
                .DataPropertyName = "NOMBRE_FUNCIONARIO"
                .Name = "NOMBRE_FUNCIONARIO"
                .HeaderText = "Funcionario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(NOMBRE_FUNCIONARIO)
            '
            Dim LOGIN As New DataGridViewTextBoxColumn
            With LOGIN ' 3
                .DisplayIndex = 3
                .DataPropertyName = "LOGIN"
                .Name = "LOGIN"
                .HeaderText = "Login"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(LOGIN)
            '
            Dim TELEFONO_CLIENTE As New DataGridViewTextBoxColumn
            With TELEFONO_CLIENTE ' 4
                .DisplayIndex = 4
                .DataPropertyName = "TELEFONO_CLIENTE"
                .Name = "TELEFONO_CLIENTE"
                .HeaderText = "Teléfono"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(TELEFONO_CLIENTE)
            '
            Dim TIPO_COMPROBANTE As New DataGridViewTextBoxColumn
            With TIPO_COMPROBANTE ' 5
                .DisplayIndex = 5
                .DataPropertyName = "TIPO_COMPROBANTE"
                .Name = "TIPO_COMPROBANTE"
                .HeaderText = "Tipo Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(TIPO_COMPROBANTE)
            '
            Dim DOCUMENTO As New DataGridViewTextBoxColumn
            With DOCUMENTO '6 
                .DisplayIndex = 6
                .DataPropertyName = "DOCUMENTO"
                .Name = "DOCUMENTO"
                .HeaderText = "Documento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(DOCUMENTO)
            '      
            Dim CIUDAD_ORIGEN As New DataGridViewTextBoxColumn
            With CIUDAD_ORIGEN '7 
                .DisplayIndex = 7
                .DataPropertyName = "CIUDAD_ORIGEN"
                .Name = "CIUDAD_ORIGEN"
                .HeaderText = "Ciudad Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(CIUDAD_ORIGEN)
            '
            Dim CIUDAD_DESTINO As New DataGridViewTextBoxColumn
            With CIUDAD_DESTINO      '8 
                .DisplayIndex = 8
                .DataPropertyName = "CIUDAD_DESTINO"
                .Name = "CIUDAD_DESTINO"
                .HeaderText = "Ciudad Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(CIUDAD_DESTINO)
            '
            Dim DATOS_GUIA_TRANSPORTISTA As New DataGridViewTextBoxColumn
            With DATOS_GUIA_TRANSPORTISTA  '9
                .DisplayIndex = 9
                .DataPropertyName = "DATOS_GUIA_TRANSPORTISTA"
                .Name = "DATOS_GUIA_TRANSPORTISTA"
                .HeaderText = "Datos Guia Transportista"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(DATOS_GUIA_TRANSPORTISTA)
            '
            Dim FECHA_REGISTRO_DCTO As New DataGridViewTextBoxColumn
            With FECHA_REGISTRO_DCTO '10
                .DisplayIndex = 10
                .DataPropertyName = "FECHA_REGISTRO_DCTO"
                .Name = "FECHA_REGISTRO_DCTO"
                .HeaderText = "Fecha Registro Dcto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(FECHA_REGISTRO_DCTO)
            '
            Dim FECHA_LLEGADA_DCTO As New DataGridViewTextBoxColumn
            With FECHA_LLEGADA_DCTO '11
                .DisplayIndex = 11
                .Name = "FECHA_LLEGADA_DCTO"
                .DataPropertyName = "FECHA_LLEGADA_DCTO"
                .HeaderText = "Fecha Llgada"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(FECHA_LLEGADA_DCTO)

            Dim FECHA_ENTREGA_DCTO As New DataGridViewTextBoxColumn
            With FECHA_ENTREGA_DCTO '12
                .DisplayIndex = 12
                .DataPropertyName = "FECHA_ENTREGA_DCTO"
                .Name = "FECHA_ENTREGA_DCTO"
                .HeaderText = "Fecha Entrega"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(FECHA_ENTREGA_DCTO)
            '
            Dim FECHA_ACTUALIZACION_DCTO As New DataGridViewTextBoxColumn
            With FECHA_ACTUALIZACION_DCTO  '13
                .DisplayIndex = 13
                .DataPropertyName = "FECHA_ACTUALIZACION_DCTO"
                .Name = "FECHA_ACTUALIZACION_DCTO"
                .HeaderText = "Fecha Actualizacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(FECHA_ACTUALIZACION_DCTO)
            '
            Dim NRO_PREFACTURA As New DataGridViewTextBoxColumn
            With NRO_PREFACTURA '14
                .DisplayIndex = 14
                .DataPropertyName = "NRO_PREFACTURA"
                .Name = "NRO_PREFACTURA"
                .HeaderText = "Nº Prefactura"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(NRO_PREFACTURA)
            '
            Dim NRO_FACTURA As New DataGridViewTextBoxColumn
            With NRO_FACTURA '15
                .DisplayIndex = 15
                .DataPropertyName = "NRO_FACTURA"
                .Name = "NRO_FACTURA"
                .HeaderText = "Nº Factura"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(NRO_FACTURA)
            '
            Dim DOCUMENTO_ASOCIADO As New DataGridViewTextBoxColumn
            With DOCUMENTO_ASOCIADO '16
                .DisplayIndex = 16
                .DataPropertyName = "DOCUMENTO_ASOCIADO"
                .Name = "DOCUMENTO_ASOCIADO"
                .HeaderText = "Dcto Cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dgv_consulta.Columns.Add(DOCUMENTO_ASOCIADO)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
#End Region

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
    Private Sub btnfiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfiltrar.Click
        'datahelper
        'Dim lrst_datos As New ADODB.Recordset
        Dim lrst_datos As DataTable
        Try
            objdatosmensajeria.idusuario_venta = dtoUSUARIOS.IdLogin ' Usuario 
            objdatosmensajeria.fecha_inicio = Me.DTP_fec_inicio.Text
            objdatosmensajeria.fecha_final = Me.DTP_fec_final.Text
            lrst_datos = objdatosmensajeria.fn_get_datos_mensajeria()
            dt_datosmensajeria = Nothing
            dv_datosmensajeria = Nothing
            '
            dt_datosmensajeria = New DataTable
            dv_datosmensajeria = New DataView
            'datahelper
            'odba_datosmensajeria.Fill(dt_datosmensajeria, lrst_datos)
            dt_datosmensajeria = lrst_datos
            dv_datosmensajeria = dt_datosmensajeria.DefaultView
            '
            formato_grilla()
            '
            dgv_consulta.DataSource = dv_datosmensajeria
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub EliminarDocumentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarDocumentoToolStripMenuItem.Click
        Dim ls_mensaje As String
        Dim ls_comprobante As String
        Dim dgrv0 As DataGridViewRow
        'datahelper
        'Dim lrst_datos As New ADODB.Recordset
        Dim lrst_datos As New DataTable
        Try
            If Me.dgv_consulta.Rows.Count < 1 Then
                Exit Sub
            End If
            dgrv0 = Me.dgv_consulta.CurrentRow()
            ls_mensaje = "¿Está seguro de eliminar el registro?"
            Dim resp As DialogResult = MessageBox.Show(ls_mensaje, "Seguridad del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resp = Windows.Forms.DialogResult.Yes Then
                ls_comprobante = CType(dgrv0.Cells("DOCUMENTO").Value, String)
                '
                objdatosmensajeria.nro_documento = ls_comprobante
                objdatosmensajeria.idusuario_venta = dtoUSUARIOS.IdLogin ' Usuario 
                objdatosmensajeria.fecha_inicio = Me.DTP_fec_inicio.Text
                objdatosmensajeria.fecha_final = Me.DTP_fec_final.Text
                'datahelper
                'lrst_datos = objdatosmensajeria.fn_elimina_registro_mensajeria
                ''
                'dt_datosmensajeria = Nothing
                'dv_datosmensajeria = Nothing
                ''
                'dt_datosmensajeria = New DataTable
                'dv_datosmensajeria = New DataView
                'odba_datosmensajeria.Fill(dt_datosmensajeria, lrst_datos)
                'dv_datosmensajeria = dt_datosmensajeria.DefaultView
                '
                lrst_datos = objdatosmensajeria.fn_elimina_registro_mensajeria
                '
                dt_datosmensajeria = Nothing
                dv_datosmensajeria = Nothing
                '
                dt_datosmensajeria = New DataTable
                dv_datosmensajeria = New DataView
                dt_datosmensajeria = lrst_datos
                dv_datosmensajeria = dt_datosmensajeria.DefaultView

                formato_grilla()
                '
                dgv_consulta.DataSource = dv_datosmensajeria
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem.Click
        '
        Dim ls_mensaje As String
        Dim ls_comprobante As String
        'datahelper
        'Dim lrst_datos As New ADODB.Recordset
        Dim lrst_datos As New DataTable
        Try
            If Me.dgv_consulta.Rows.Count < 1 Then
                Exit Sub
            End If            
            ls_mensaje = "¿Está seguro de eliminar todos registro?"
            Dim resp As DialogResult = MessageBox.Show(ls_mensaje, "Seguridad del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resp = Windows.Forms.DialogResult.Yes Then
                objdatosmensajeria.idusuario_venta = dtoUSUARIOS.IdLogin ' Usuario 
                objdatosmensajeria.fecha_inicio = Me.DTP_fec_inicio.Text
                objdatosmensajeria.fecha_final = Me.DTP_fec_final.Text
                '
                lrst_datos = objdatosmensajeria.fn_elimina_todos_registros_mensajeria
                '
                dt_datosmensajeria = Nothing
                dv_datosmensajeria = Nothing
                '
                dt_datosmensajeria = New DataTable
                dv_datosmensajeria = New DataView
                'datahelper
                'odba_datosmensajeria.Fill(dt_datosmensajeria, lrst_datos)
                dt_datosmensajeria = lrst_datos
                dv_datosmensajeria = dt_datosmensajeria.DefaultView
                '
                formato_grilla()
                '
                dgv_consulta.DataSource = dv_datosmensajeria
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
        '
    End Sub

    Private Sub txt_documento_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt_documento.TextChanged

    End Sub
End Class
