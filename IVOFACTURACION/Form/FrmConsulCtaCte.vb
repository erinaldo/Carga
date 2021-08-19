Public Class FrmConsulCtaCte
    Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
    Dim ObjFactura As New ClsLbTepsa.dtoFACTURA
    Private ObjReport As ClsLbTepsa.dtoFrmReport
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub FrmConsulCtaCte_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub
    Private Sub FrmConsulCtaCte_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub

    Private Sub FrmConsulCtaCte_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmConsulCtaCte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.MenuTab.Items(0).Text = "Línea de Crédito"
            'Me.MenuTab.Items(1).Text = "Rangos Tarifas Carga Asegurada"
            'Me.MenuTab.Items(2).Text = "Rangos Tarifas Carga Asegurada Persona"

            Me.ShadowLabel1.Text = "Línea de Crédito"

            Me.MenuStrip1.Items(0).Visible = False 'nuevo
            Me.MenuStrip1.Items(1).Visible = False 'edicion 
            Me.MenuStrip1.Items(2).Visible = False 'cancelar
            Me.MenuStrip1.Items(3).Visible = False  'grabar
            Me.MenuStrip1.Items(3).Enabled = False 'grabar
            Me.MenuStrip1.Items(4).Visible = False 'eliminar
            Me.MenuStrip1.Items(5).Visible = False 'exportar
            Me.MenuStrip1.Items(6).Visible = True 'imprimir
            Me.MenuStrip1.Items(6).Enabled = True 'imprimir
            Me.MenuStrip1.Items(7).Visible = False 'ayuda
            Me.MenuStrip1.Items(8).Visible = True 'salir
            'Data Helper 
            ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.cmbUsuarios, "", "", 5)

            'Me.cmbUsuarios.DataSource = ObjGeneral.sp_L_funcionario_carga()
            'Me.cmbUsuarios.DataSource = ObjGeneral.sp_L_funcionario_carga(cnn)
            '
            Me.cmbUsuarios.DisplayMember = "usuario_personal"
            Me.cmbUsuarios.ValueMember = "idusuario_personal"

            'ObjGeneral.sp_listar_t_tipo_facturacion(cnn, cmbtipofacturacion)
            'datahelper
            'ObjGeneral.sp_listar_t_tipo_facturacion_sin_contado(cnn, cmbtipofacturacion)
            ObjGeneral.sp_listar_t_tipo_facturacion_sin_contado(cmbtipofacturacion)
            cmbtipofacturacion.SelectedIndex = -1
            cmbUsuarios.SelectedIndex = -1
            '
            FORMAT_GRILLA3()
            formato_grilla_resumen()
            '
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub listar_facturas()
        Try

            If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
                ObjFactura.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
            Else
                ObjFactura.IDUSUARIO_PERSONAL = 0
            End If

            If Not IsNothing(Me.cmbtipofacturacion.SelectedValue) Then
                ObjFactura.IDTIPO_FACTURACION = Me.cmbtipofacturacion.SelectedValue
            Else
                ObjFactura.IDTIPO_FACTURACION = 0
            End If
            FORMAT_GRILLA3()
            '
            'datahelper
            dgv.DataSource = ObjFactura.sp_listar_solicitu_credi()
            '
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Sub FORMAT_GRILLA3()
        dgv.Columns.Clear()
        With dgv
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            '.DataSource = ObjFactura.sp_listar_solicitu_credi(cnn)
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim login As New DataGridViewTextBoxColumn
        With login
            .HeaderText = "Funcionario"
            .Name = "login"
            .DataPropertyName = "login"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim CODIGO_CLIENTE As New DataGridViewTextBoxColumn
        With CODIGO_CLIENTE
            .HeaderText = "Código Cliente"
            .Name = "CODIGO_CLIENTE"
            .DataPropertyName = "CODIGO_CLIENTE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .HeaderText = "Razón Social"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .Width = 220
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With


        'Dim LINEA_SOLICITADA As New DataGridViewTextBoxColumn
        'With LINEA_SOLICITADA
        '    .HeaderText = "PLINEA_SOLICITADA"
        '    .Name = "LINEA_SOLICITADAo"
        '    .DataPropertyName = "LINEA_SOLICITADA"
        '    .Width = 100
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    .DefaultCellStyle.Format = "N2"
        '    .DefaultCellStyle.NullValue = "0,00"
        '    .SortMode = DataGridViewColumnSortMode.NotSortable
        '    .ReadOnly = True
        'End With

      
        Dim TOTAL_ASIGNADO As New DataGridViewTextBoxColumn
        With TOTAL_ASIGNADO
            .HeaderText = "Línea Asginada"
            .Name = "TOTAL_ASIGNADO"
            .DataPropertyName = "TOTAL_ASIGNADO"
            .Width = 97
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim SOBREGIRO As New DataGridViewTextBoxColumn
        With SOBREGIRO
            .HeaderText = "Sobregiro"
            .Name = "SOBREGIRO"
            .DataPropertyName = "SOBREGIRO"
            .Width = 97
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim SALDO_ACTUAL As New DataGridViewTextBoxColumn
        With SALDO_ACTUAL
            .HeaderText = "Saldo Actual"
            .Name = "SALDO_ACTUAL"
            .DataPropertyName = "SALDO_ACTUAL"
            .Width = 97
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        '
        Dim idpersona As New DataGridViewTextBoxColumn
        With idpersona
            .HeaderText = "Id. Persona"
            .Name = "idpersona"
            .DataPropertyName = "idpersona"
            .Width = 120
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Visible = False
        End With
        With dgv
            .Columns.AddRange(login, CODIGO_CLIENTE, RAZON_SOCIAL, TOTAL_ASIGNADO, SOBREGIRO, SALDO_ACTUAL, idpersona)
        End With
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        listar_facturas()
    End Sub
    Private Sub FrmConsulCtaCte_MenuImprimir() Handles Me.MenuImprimir
        Try
            ObjReport.Dispose()
        Catch
        End Try
        ObjReport = New ClsLbTepsa.dtoFrmReport
        '
        ObjReport.rutaRpt = PathFrmReport
        ObjReport.conectar(rptservice, rptuser, rptpass)
        '
        ObjReport.printrptB(False, "", "FAC036.rpt", _
        "p_idusuario_personal;" & ObjFactura.IDUSUARIO_PERSONAL, _
        "p_idtipo_facturacion;" & ObjFactura.IDTIPO_FACTURACION)
    End Sub
    Sub formato_grilla_resumen()
        '
        dgv_resumen_cliente.Columns.Clear()
        '
        With dgv_resumen_cliente
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = False
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim cantidad_ge As New DataGridViewTextBoxColumn
        With cantidad_ge
            .HeaderText = "Cantidad G.E."
            .Name = "cantidad_ge"
            .DataPropertyName = "cantidad_ge"
            .Width = 112
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "N"
            .DefaultCellStyle.NullValue = "0"
        End With
        '
        Dim monto_total_ge As New DataGridViewTextBoxColumn
        With monto_total_ge
            .HeaderText = "Total G.E."
            .Name = "monto_total_ge"
            .DataPropertyName = "monto_total_ge"
            .Width = 112
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
        End With
        '
        Dim cantidad_pre As New DataGridViewTextBoxColumn
        With cantidad_pre
            .HeaderText = "Cantidad prefactura"
            .Name = "cantidad_pre"
            .DataPropertyName = "cantidad_pre"
            .Width = 112
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ReadOnly = True
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format = "N"
            .DefaultCellStyle.NullValue = "0"
        End With
        '
        Dim monto_total_pre As New DataGridViewTextBoxColumn
        With monto_total_pre
            .HeaderText = "Monto Total Pre-factura"
            .Name = "monto_total_pre"
            .DataPropertyName = "monto_total_pre"
            .Width = 112
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        '
        Dim cantidad_factura As New DataGridViewTextBoxColumn
        With cantidad_factura
            .HeaderText = "Cantidad Factura"
            .Name = "cantidad_factura"
            .DataPropertyName = "cantidad_factura"
            .Width = 112
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N"
            .DefaultCellStyle.NullValue = "0"
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim total_factura_pend As New DataGridViewTextBoxColumn
        With total_factura_pend
            .HeaderText = "Total Factura"
            .Name = "total_factura_pend"
            .DataPropertyName = "total_factura_pend"
            .Width = 112
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N"
            .DefaultCellStyle.NullValue = "0,00"
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        '
        With dgv_resumen_cliente
            .Columns.AddRange(cantidad_ge, monto_total_ge, cantidad_pre, monto_total_pre, cantidad_factura, total_factura_pend)
        End With
    End Sub
    Sub get_recupera_resumen()
        Dim lds_resumen As New DataSet
        Dim ldtgvr_fila As DataGridViewRow
        Dim ll_fila As Long
        Dim ll_idpersona As Long
        Try
            '
            ll_fila = Me.dgv.Rows.Count
            If ll_fila < 1 Then
                Exit Sub
            End If
            '
            ldtgvr_fila = Me.dgv.CurrentRow()
            ll_idpersona = CType(ldtgvr_fila.Cells("idpersona").Value, Long)
            ObjFactura.IDPERSONA = ll_idpersona
            ' 
            'Datahelper
            lds_resumen = ObjFactura.sp_get_linea_credito_resumen()
            '
            formato_grilla_resumen()            
            Me.dgv_resumen_cliente.DataSource = lds_resumen.Tables(0).DefaultView
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub dgv_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellEnter
        Try
            get_recupera_resumen()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub dgv_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv.RowsAdded
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.dgv), 0)
    End Sub

    Private Sub dgv_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgv.RowsRemoved
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.dgv), 0)
    End Sub

    Private Sub cmbtipofacturacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtipofacturacion.SelectedIndexChanged
        Me.dgv.DataSource = Nothing
    End Sub

    Private Sub cmbUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUsuarios.SelectedIndexChanged
        Me.dgv.DataSource = Nothing
    End Sub

    Private Sub dgv_DoubleClick(sender As Object, e As System.EventArgs) Handles dgv.DoubleClick

    End Sub
End Class
