Public Class frmConsultaRecojo

    Sub FormatoDgv()
        With dgv
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim col_id_persona As New DataGridViewTextBoxColumn
            With col_id_persona
                .HeaderText = "id cliente"
                .Name = "id_persona"
                .DataPropertyName = "id_persona"
                .Visible = False
            End With

            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .HeaderText = "Cliente"
                .Name = "cliente"
                .DataPropertyName = "cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                '.Width = 200
            End With

            Dim col_id_direccion As New DataGridViewTextBoxColumn
            With col_id_direccion
                .HeaderText = "id direccion"
                .Name = "id_direccion"
                .DataPropertyName = "id_direccion"
                .Visible = False
            End With

            Dim col_direccion As New DataGridViewTextBoxColumn
            With col_direccion
                .HeaderText = "Dirección"
                .Name = "direccion"
                .DataPropertyName = "direccion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_hora_listo As New DataGridViewTextBoxColumn
            With col_hora_listo
                .HeaderText = "Hora Listo"
                .Name = "hora_listo"
                .DataPropertyName = "hora_listo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                '.Width = 54
            End With

            Dim col_hora_cierre As New DataGridViewTextBoxColumn
            With col_hora_cierre
                .HeaderText = "Hora Cierre"
                .Name = "hora_cierre"
                .DataPropertyName = "hora_cierre"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                '.Width = 54
            End With

            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .HeaderText = "Estado"
                .Name = "estado"
                .DataPropertyName = "estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_tipo_recojo As New DataGridViewTextBoxColumn
            With col_tipo_recojo
                .HeaderText = "Tipo Recojo"
                .Name = "tipo_recojo"
                .DataPropertyName = "tipo_recojo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_contacto As New DataGridViewTextBoxColumn
            With col_contacto
                .HeaderText = "Contacto"
                .Name = "contacto"
                .DataPropertyName = "contacto"
                .Visible = False
            End With

            Dim col_ruta As New DataGridViewTextBoxColumn
            With col_ruta
                .HeaderText = "Ruta"
                .Name = "ruta"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DataPropertyName = "ruta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Visible = True
                '.DisplayStyleForCurrentCellOnly = True
            End With

            Dim col_id_recojo As New DataGridViewTextBoxColumn
            With col_id_recojo
                .HeaderText = "Nº"
                .Name = "id_recojo"
                .DataPropertyName = "id_recojo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            End With

            Dim col_movil As New DataGridViewTextBoxColumn
            With col_movil
                .HeaderText = "Móvil"
                .Name = "movil"
                .DataPropertyName = "movil"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_chofer As New DataGridViewTextBoxColumn
            With col_chofer
                .HeaderText = "Chofer"
                .Name = "chofer"
                .DataPropertyName = "chofer"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_incidencia As New DataGridViewTextBoxColumn
            With col_incidencia
                .HeaderText = "Incidencia"
                .Name = "incidencia"
                .DataPropertyName = "incidencia"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim col_parcial As New DataGridViewTextBoxColumn
            With col_parcial
                .HeaderText = "Parcial"
                .Name = "parcial"
                .DataPropertyName = "parcial"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .HeaderText = "Observación"
                .Name = "observacion"
                .DataPropertyName = "observacion"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim col_producto As New DataGridViewTextBoxColumn
            With col_producto
                .HeaderText = "Producto"
                .Name = "producto"
                .DataPropertyName = "producto"
                .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim col_fecha_atencion As New DataGridViewTextBoxColumn
            With col_fecha_atencion
                .HeaderText = "Fecha Atencion"
                .Name = "fecha_atencion"
                .DataPropertyName = "fecha_atencion"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim col_fecha_no_atencion As New DataGridViewTextBoxColumn
            With col_fecha_no_atencion
                .HeaderText = "Fecha no Atencion"
                .Name = "fecha_no_atencion"
                .DataPropertyName = "fecha_no_atencion"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim col_fecha_llegada As New DataGridViewTextBoxColumn
            With col_fecha_llegada
                .HeaderText = "Fecha LLegada"
                .Name = "fecha_llegada"
                .DataPropertyName = "fecha_llegada"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim col_fecha_cancelacion As New DataGridViewTextBoxColumn
            With col_fecha_cancelacion
                .HeaderText = "Fecha Cancelación"
                .Name = "fecha_cancelacion"
                .DataPropertyName = "fecha_cancelacion"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim col_coordenada As New DataGridViewTextBoxColumn
            With col_coordenada
                .HeaderText = "Coordenada Gps"
                .Name = "coordenada"
                .DataPropertyName = "coordenada"
                .Visible = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim col_tiempo As New DataGridViewTextBoxColumn
            With col_tiempo
                .HeaderText = "tiempo"
                .Name = "tiempo"
                .DataPropertyName = "tiempo"
                .Visible = False
            End With

            .Columns.AddRange(col_id_recojo, col_id_persona, col_cliente, col_id_direccion, col_direccion, _
            col_hora_listo, col_hora_cierre, col_ruta, col_movil, col_chofer, col_estado, _
            col_tipo_recojo, col_contacto, col_incidencia, col_parcial, col_observacion, col_producto, col_fecha_atencion, _
            col_fecha_no_atencion, col_fecha_llegada, col_fecha_cancelacion, col_coordenada, col_tiempo)
        End With
    End Sub

    Sub Inicio()
        Me.CboTipoRecojo.Items.Add("(TODO)")
        Me.CboTipoRecojo.Items.Add("POR DEMANDA")
        Me.CboTipoRecojo.Items.Add("PROGRAMADO")
        Me.CboTipoRecojo.SelectedIndex = 0

        Me.cboSituacion.Items.Add("(TODO)")
        Me.cboSituacion.Items.Add("EN TIEMPO")
        Me.cboSituacion.Items.Add("FUERA DE TIEMPO")
        Me.cboSituacion.SelectedIndex = 0

        Dim obj As New DtoRecojo
        obj.Fecha = Me.DtpFecha.Text
        Dim ds As DataSet = obj.Inicio()

        CboEstado.DataSource = ds.Tables(0)
        CboEstado.ValueMember = "id_checkpoint_recojo"
        CboEstado.DisplayMember = "check_point_recojo"
        CboEstado.SelectedValue = 2

        CboRuta.DataSource = ds.Tables(1)
        CboRuta.ValueMember = "id_ruta_unidad_transporte"
        CboRuta.DisplayMember = "ruta"
        CboRuta.SelectedValue = 0
    End Sub

    Private Sub frmConsultaRecojo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FormatoDgv()
        Inicio()
    End Sub

    Private Sub BtnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        Try
            Dim obj As New DtoRecojo
            Dim intFuncionario As Integer = 0
            If Acceso.SiRol(G_Rol, Me, 1, 2) Then
                intFuncionario = dtoUSUARIOS.IdLogin
            End If
            Dim dt As DataTable = obj.ListarRecojo(Me.DtpFecha.Value.ToShortDateString, Me.CboTipoRecojo.SelectedIndex, CboEstado.SelectedValue, _
                                                   CboRuta.SelectedValue, 0, cboSituacion.SelectedIndex, intFuncionario)
            dgv.DataSource = dt

            With Me.dgv
                If .Rows.Count > 0 Then
                    Dim intTiempo As Integer
                    For Each row As DataGridViewRow In .Rows
                        intTiempo = row.Cells("tiempo").Value
                        If intTiempo = 0 Or intTiempo = 10 Then
                            row.DefaultCellStyle.BackColor = Color.White
                            row.DefaultCellStyle.ForeColor = Color.Red
                        ElseIf intTiempo = 1 Then
                            row.DefaultCellStyle.BackColor = Color.White
                            row.DefaultCellStyle.ForeColor = Color.Green
                        ElseIf intTiempo = 100 Then
                            row.DefaultCellStyle.BackColor = Color.White
                            row.DefaultCellStyle.ForeColor = Color.Gray
                        Else
                            row.DefaultCellStyle.BackColor = Color.White
                            row.DefaultCellStyle.ForeColor = Color.Black
                        End If
                    Next
                End If
            End With

            Dim intTotal As Integer = dt.Compute("count(id_recojo)", "")
            Dim int1 As Integer = dt.Compute("count(id_recojo)", "estado='ATENDIDO'")
            Dim int2 As Integer = dt.Compute("count(id_recojo)", "estado='NO ATENDIDO'")
            Dim int3 As Integer = intTotal - int1 - int2

            lbl1.Text = int1
            lbl2.Text = int2
            lbl3.Text = int3
            lblTotal.Text = intTotal

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv.DoubleClick
        If Me.dgv.Rows.Count > 0 Then
            Dim frm As New frmRecojoComprobante
            frm.Recojo = Me.dgv.CurrentRow.Cells("id_recojo").Value
            frm.ShowDialog()
        End If
    End Sub
End Class