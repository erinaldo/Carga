Public Class FrmFacturacionEspecial

    Dim ObjFacturaEspecial As New INTEGRACION.clsFacturacionEspecial

    Dim dsGuias As DataSet
    Dim dtPersona As DataTable
    Dim dtGuias As DataTable
    Dim dtError As DataTable

    Dim dtGuiasCopia As DataTable
    Dim dc As DataColumn
    Dim dr As DataRow

    Dim dtFacturas As DataTable
    Dim dtGuiasFacturadas As DataTable
    Dim blnOk As Boolean = False

    Dim dtDireccion As DataTable

    Dim hnd As Long = 0

    '---------------Pestaña de Consulta de Guias Pendientes de Facturar------------------------
    Private Sub FrmFacturacionEspecial_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            NuevoToolStripMenuItem.Visible = False
            EdicionToolStripMenuItem.Visible = False
            CancelarToolStripmenuItem.Visible = False
            GrabarToolStripMenuItem.Visible = False
            EliminarToolStripMenuItem.Visible = False
            ExportarToolStripMenuItem.Visible = False
            ImprimirToolStripMenuItem.Visible = False



            dtPersona = ObjFacturaEspecial.FNLISTAR_PERSONA_1_Y_2()
            cboRazonSocial.DataSource = dtPersona
            cboRazonSocial.DisplayMember = "RAZON_SOCIAL"
            cboRazonSocial.ValueMember = "IDPERSONA"
            cboRazonSocial.SelectedIndex = 0
            blnOk = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboRazonSocial_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles cboRazonSocial.KeyUp
        Dim Ascci As Integer = Convert.ToInt32(e.KeyCode)
        Dim blnExiste As Boolean = False
        Try
            If blnOk Then
                If cboRazonSocial.Text.Trim <> "" Then
                    If Ascci = Keys.Enter Then
                        For index As Integer = 0 To dtPersona.Rows.Count - 1
                            If dtPersona.Rows(index).Item("RAZON_SOCIAL").ToString.Trim = Me.cboRazonSocial.Text Then
                                Me.txtRuc.Text = dtPersona.Rows(cboRazonSocial.SelectedIndex).Item("NU_DOCU_SUNA").ToString.Trim
                                blnExiste = True
                                Exit For
                            End If
                        Next

                        If blnExiste = False Then
                            MessageBox.Show("El nombre de cliente no existe, verifique que se encuentre registrado", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cboRazonSocial.Text = ""
                            Me.txtRuc.Text = ""
                            Me.cboRazonSocial.Focus()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnProcesar_Click(sender As System.Object, e As System.EventArgs) Handles btnProcesar.Click
        Cursor.Current = Cursors.AppStarting
        Dim CantGuias As Integer = 0
        Try
            chkSeleccionTodos.Checked = False
            ObjFacturaEspecial.FECHA_INICIO = dtFechaInicio.Value.Date.ToString("dd/MM/yyyy")
            ObjFacturaEspecial.FECHA_FINAL = dtFechaFinal.Value.Date.ToString("dd/MM/yyyy")
            ObjFacturaEspecial.ID_PERSONA = Convert.ToInt32(dtPersona.Rows(cboRazonSocial.SelectedIndex).Item("IDPERSONA").ToString)
            ObjFacturaEspecial.ID_USUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            dsGuias = ObjFacturaEspecial.FNLISTAR_GUIAS_PENDIENTES()

            dtGuias = dsGuias.Tables(0)
            dtError = dsGuias.Tables(1)

            If Not IsNothing(dtGuias) Then
                dgvGuias.Columns.Clear()
                If dtGuias.Rows.Count > 0 Then
                    AgregarColumasGuias()
                    dgvGuias.DataSource = dtGuias
                    grpDetalle.Text = "Detalle de Guías: ( " & dtGuias.Rows.Count & " Registros )"
                    lblMontoSubTotal.Text = "S/. " & dtGuias.Compute("Sum(SubTotal_Costo_Final)", "")
                    lblMontoIgv.Text = "S/. " & dtGuias.Compute("Sum(Monto_Impuesto_Final)", "")
                    lblMontoTotal.Text = "S/. " & dtGuias.Compute("Sum(Total_Costo_Final)", "")
                    chkSeleccionTodos.Enabled = True
                Else
                    grpDetalle.Text = "Detalle de Guías: ( 0 Registros )"
                    lblMontoSubTotal.Text = "S/. 0.00"
                    lblMontoIgv.Text = "S/. 0.00"
                    lblMontoTotal.Text = "S/. 0.00"
                    chkSeleccionTodos.Enabled = False
                    MessageBox.Show("No existen guías pendientes de facturar para el rango de fechas seleccionado", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Cursor.Current = Cursors.WaitCursor
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

    Sub AgregarColumasGuias()
        Dim Seleccionar As New DataGridViewCheckBoxColumn
        With Seleccionar
            .HeaderText = "Seleccionar"
            .Name = "Seleccionar"
            .DataPropertyName = "Seleccionar_To_Factura"
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            .Width = 90
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim IataOrigen As New DataGridViewTextBoxColumn
        With IataOrigen
            .HeaderText = "Iata Origen"
            .Name = "IataOrigen"
            .DataPropertyName = "IataOrigen"
            .ReadOnly = True
            .Width = 70
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

        Dim IataDestino As New DataGridViewTextBoxColumn
        With IataDestino
            .HeaderText = "Iata Destino"
            .Name = "IataDestino"
            .DataPropertyName = "IataDestino"
            .ReadOnly = True
            .Width = 70
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

        Dim UnidadOrigen As New DataGridViewTextBoxColumn
        With UnidadOrigen
            .HeaderText = "UnidadOrigen"
            .Name = "UnidadOrigen"
            .DataPropertyName = "UnidadOrigen"
            .ReadOnly = True
            .Visible = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim UnidadDestino As New DataGridViewTextBoxColumn
        With UnidadDestino
            .HeaderText = "UnidadDestino"
            .Name = "UnidadDestino"
            .DataPropertyName = "UnidadDestino"
            .ReadOnly = True
            .Visible = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim Razon_Social As New DataGridViewTextBoxColumn
        With Razon_Social
            .HeaderText = "Razón Social"
            .Name = "Razon_Social"
            .DataPropertyName = "Razon_Social"
            .ReadOnly = True
            .Width = 180
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim IdCentro_Costo As New DataGridViewTextBoxColumn
        With IdCentro_Costo
            .HeaderText = "IdCentro_Costo"
            .Name = "IdCentro_Costo"
            .DataPropertyName = "IdCentro_Costo"
            .ReadOnly = True
            .Visible = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim Centro_Costo As New DataGridViewTextBoxColumn
        With Centro_Costo
            .HeaderText = "Centro Costo"
            .Name = "Centro_Costo"
            .DataPropertyName = "Centro_Costo"
            .ReadOnly = True
            .Width = 120
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim IdCentro_Costo_Contacto As New DataGridViewTextBoxColumn
        With IdCentro_Costo_Contacto
            .HeaderText = "Centro Costo Contacto"
            .Name = "Centro_Costo_Contacto"
            .DataPropertyName = "IdCentro_Costo_Contacto"
            .ReadOnly = True
            .Width = 130
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

        Dim Nro_Guia As New DataGridViewTextBoxColumn
        With Nro_Guia
            .HeaderText = "Nro. Guía"
            .Name = "Nro_Guia"
            .DataPropertyName = "Nro_Guia"
            .ReadOnly = True
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

        Dim Fecha_Guia As New DataGridViewTextBoxColumn
        With Fecha_Guia
            .HeaderText = "Fecha Guía"
            .Name = "Fecha_Guia"
            .DataPropertyName = "Fecha_Guia"
            .ReadOnly = True
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

        Dim IdGuias_Envio As New DataGridViewTextBoxColumn
        With IdGuias_Envio
            .HeaderText = "IdGuias_Envio"
            .Name = "IdGuias_Envio"
            .DataPropertyName = "IdGuias_Envio"
            .ReadOnly = True
            .Visible = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim Forma_Pago As New DataGridViewTextBoxColumn
        With Forma_Pago
            .HeaderText = "Forma Pago"
            .Name = "Forma_Pago"
            .DataPropertyName = "Forma_Pago"
            .ReadOnly = True
            .Width = 90
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

        Dim Simbolo_Moneda As New DataGridViewTextBoxColumn
        With Simbolo_Moneda
            .HeaderText = "Símbolo Moneda"
            .Name = "Simbolo_Moneda"
            .DataPropertyName = "Simbolo_Moneda"
            .ReadOnly = True
            .Width = 110
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim Total_Peso As New DataGridViewTextBoxColumn
        With Total_Peso
            .HeaderText = "Total Peso"
            .Name = "Total_Peso"
            .DataPropertyName = "Total_Peso"
            .ReadOnly = True
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Precio_X_Peso As New DataGridViewTextBoxColumn
        With Precio_X_Peso
            .HeaderText = "Precio Peso"
            .Name = "Precio_X_Peso"
            .DataPropertyName = "Precio_X_Peso"
            .ReadOnly = True
            .Visible = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Total_Peso_Final As New DataGridViewTextBoxColumn
        With Total_Peso_Final
            .HeaderText = "Total Peso Final"
            .Name = "Total_Peso_Final"
            .DataPropertyName = "Total_Peso_Final"
            .ReadOnly = True
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Precio_X_Peso_Final As New DataGridViewTextBoxColumn
        With Precio_X_Peso_Final
            .HeaderText = "Precio Peso Final"
            .Name = "Precio_X_Peso_Final"
            .DataPropertyName = "Precio_X_Peso_Final"
            .ReadOnly = True
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Total_Volumen As New DataGridViewTextBoxColumn
        With Total_Volumen
            .HeaderText = "Total Volumen"
            .Name = "Total_Volumen"
            .DataPropertyName = "Total_Volumen"
            .ReadOnly = True
            .Width = 90
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Precio_X_Volumen As New DataGridViewTextBoxColumn
        With Precio_X_Volumen
            .HeaderText = "Precio Volumen"
            .Name = "Precio_X_Volumen"
            .DataPropertyName = "Precio_X_Volumen"
            .ReadOnly = True
            .Visible = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Total_Volumen_Final As New DataGridViewTextBoxColumn
        With Total_Volumen_Final
            .HeaderText = "Total Volumen Final"
            .Name = "Total_Volumen_Final"
            .DataPropertyName = "Total_Volumen_Final"
            .ReadOnly = True
            .Width = 120
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Precio_X_Volumen_Final As New DataGridViewTextBoxColumn
        With Precio_X_Volumen_Final
            .HeaderText = "Precio Volumen Final"
            .Name = "Precio_X_Volumen_Final"
            .DataPropertyName = "Precio_X_Volumen_Final"
            .ReadOnly = True
            .Width = 120
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Total_Sobre As New DataGridViewTextBoxColumn
        With Total_Sobre
            .HeaderText = "Total Sobres"
            .Name = "Cantidad_Sobres"
            .DataPropertyName = "Cantidad_Sobres"
            .ReadOnly = True
            .Width = 75
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Precio_X_Sobre As New DataGridViewTextBoxColumn
        With Precio_X_Sobre
            .HeaderText = "Precio Sobres"
            .Name = "Precio_Sobres"
            .DataPropertyName = "Precio_Sobres"
            .ReadOnly = True
            .Visible = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Total_Sobre_Final As New DataGridViewTextBoxColumn
        With Total_Sobre_Final
            .HeaderText = "Total Sobres Final"
            .Name = "Cant_Sobres_Final"
            .DataPropertyName = "Cant_Sobres_Final"
            .ReadOnly = True
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Precio_X_Sobre_Final As New DataGridViewTextBoxColumn
        With Precio_X_Sobre_Final
            .HeaderText = "Precio Sobres Final"
            .Name = "Precio_Sobres_Final"
            .DataPropertyName = "Precio_Sobres_Final"
            .ReadOnly = True
            .Width = 105
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Monto_Base As New DataGridViewTextBoxColumn
        With Monto_Base
            .HeaderText = "Monto Base"
            .Name = "Monto_Base"
            .DataPropertyName = "Monto_Base"
            .ReadOnly = True
            .Width = 75
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Monto_Base_Final As New DataGridViewTextBoxColumn
        With Monto_Base_Final
            .HeaderText = "Monto Base Final"
            .Name = "Monto_Base_Final"
            .DataPropertyName = "Monto_Base_Final"
            .ReadOnly = True
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim SubTotal_Costo As New DataGridViewTextBoxColumn
        With SubTotal_Costo
            .HeaderText = "SubTotal Costo"
            .Name = "SubTotal_Costo"
            .DataPropertyName = "SubTotal_Costo"
            .ReadOnly = True
            .Width = 95
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim SubTotal_Costo_Final As New DataGridViewTextBoxColumn
        With SubTotal_Costo_Final
            .HeaderText = "SubTotal Costo Final"
            .Name = "SubTotal_Costo_Final"
            .DataPropertyName = "SubTotal_Costo_Final"
            .ReadOnly = True
            .Width = 120
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Monto_Impuesto As New DataGridViewTextBoxColumn
        With Monto_Impuesto
            .HeaderText = "IGV"
            .Name = "Monto_Impuesto"
            .DataPropertyName = "Monto_Impuesto"
            .ReadOnly = True
            .Width = 45
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Monto_Impuesto_Final As New DataGridViewTextBoxColumn
        With Monto_Impuesto_Final
            .HeaderText = "IGV Final"
            .Name = "Monto_Impuesto_Final"
            .DataPropertyName = "Monto_Impuesto_Final"
            .ReadOnly = True
            .Width = 70
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Total_Costo As New DataGridViewTextBoxColumn
        With Total_Costo
            .HeaderText = "Total Costo"
            .Name = "Total_Costo"
            .DataPropertyName = "Total_Costo"
            .ReadOnly = True
            .Width = 75
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Total_Costo_Final As New DataGridViewTextBoxColumn
        With Total_Costo_Final
            .HeaderText = "Total Costo Final"
            .Name = "Total_Costo_Final"
            .DataPropertyName = "Total_Costo_Final"
            .ReadOnly = True
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Flag As New DataGridViewTextBoxColumn
        With Flag
            .HeaderText = "Flag"
            .Name = "Flag"
            .DataPropertyName = "Flag"
            .ReadOnly = True
            .Visible = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Cantidad As New DataGridViewTextBoxColumn
        With Cantidad
            .HeaderText = "Cantidad"
            .Name = "Cantidad"
            .DataPropertyName = "Cantidad"
            .ReadOnly = True
            .Visible = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim IdForma_Pago As New DataGridViewTextBoxColumn
        With IdForma_Pago
            .HeaderText = "IdForma_Pago"
            .Name = "IdForma_Pago"
            .DataPropertyName = "IdForma_Pago"
            .ReadOnly = True
            .Visible = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim IdTipo_Moneda As New DataGridViewTextBoxColumn
        With IdTipo_Moneda
            .HeaderText = "IdTipo_Moneda"
            .Name = "IdTipo_Moneda"
            .DataPropertyName = "IdTipo_Moneda"
            .ReadOnly = True
            .Visible = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        dgvGuias.Columns.AddRange(Seleccionar, IataOrigen, IataDestino, UnidadOrigen, UnidadDestino, Razon_Social, Nro_Guia, Fecha_Guia, IdCentro_Costo, Centro_Costo, IdCentro_Costo_Contacto, IdGuias_Envio, Forma_Pago, Simbolo_Moneda, Total_Peso, Precio_X_Peso, Total_Peso_Final, Precio_X_Peso_Final, Total_Volumen, Precio_X_Volumen, Total_Volumen_Final, Precio_X_Volumen_Final, Total_Sobre, Precio_X_Sobre, Total_Sobre_Final, Precio_X_Sobre_Final, Monto_Base, Monto_Base_Final, SubTotal_Costo, SubTotal_Costo_Final, Monto_Impuesto, Monto_Impuesto_Final, Total_Costo, Total_Costo_Final, Flag, Cantidad, IdForma_Pago, IdTipo_Moneda)
        dgvGuias.Columns("Total_Peso").DefaultCellStyle.BackColor = Color.LightPink
        dgvGuias.Columns("Total_Peso_Final").DefaultCellStyle.BackColor = Color.LightYellow
        dgvGuias.Columns("Precio_X_Peso_Final").DefaultCellStyle.BackColor = Color.LightSteelBlue

        dgvGuias.Columns("Total_Volumen").DefaultCellStyle.BackColor = Color.LightPink
        dgvGuias.Columns("Total_Volumen_Final").DefaultCellStyle.BackColor = Color.LightYellow
        dgvGuias.Columns("Precio_X_Volumen_Final").DefaultCellStyle.BackColor = Color.LightSteelBlue

        dgvGuias.Columns("Cantidad_Sobres").DefaultCellStyle.BackColor = Color.LightPink
        dgvGuias.Columns("Cant_Sobres_Final").DefaultCellStyle.BackColor = Color.LightYellow
        dgvGuias.Columns("Precio_Sobres_Final").DefaultCellStyle.BackColor = Color.LightSteelBlue

        dgvGuias.Columns("Monto_Base").DefaultCellStyle.BackColor = Color.LightPink
        dgvGuias.Columns("Monto_Base_Final").DefaultCellStyle.BackColor = Color.LightYellow

        dgvGuias.Columns("SubTotal_Costo").DefaultCellStyle.BackColor = Color.LightPink
        dgvGuias.Columns("SubTotal_Costo_Final").DefaultCellStyle.BackColor = Color.LightYellow

        dgvGuias.Columns("Monto_Impuesto").DefaultCellStyle.BackColor = Color.LightPink
        dgvGuias.Columns("Monto_Impuesto_Final").DefaultCellStyle.BackColor = Color.LightYellow

        dgvGuias.Columns("Total_Costo").DefaultCellStyle.BackColor = Color.LightPink
        dgvGuias.Columns("Total_Costo_Final").DefaultCellStyle.BackColor = Color.LightYellow
    End Sub

    Private Sub chkSeleccionTodos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSeleccionTodos.CheckedChanged
        Try
            If chkSeleccionTodos.Checked = True Then
                For Index As Integer = 0 To dtGuias.Rows.Count - 1
                    dgvGuias.Rows(Index).Cells("Seleccionar").Value = True
                    dtGuias.Rows(Index).Item("Seleccionar_To_Factura") = 1
                Next
            Else
                For Index As Integer = 0 To dtGuias.Rows.Count - 1
                    dgvGuias.Rows(Index).Cells("Seleccionar").Value = False
                    dtGuias.Rows(Index).Item("Seleccionar_To_Factura") = 0
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgvGuias_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGuias.CellClick
        Try
            If e.RowIndex < 0 Or Not e.ColumnIndex = 0 Then Exit Sub

            If dgvGuias.Rows(dgvGuias.CurrentRow.Index).Cells("Seleccionar").Value = False Then
                dgvGuias.Rows(e.RowIndex).Cells("Seleccionar").Value = True
                dtGuias.Rows(dgvGuias.CurrentRow.Index).Item("Seleccionar_To_Factura") = 1
            Else
                dgvGuias.Rows(e.RowIndex).Cells("Seleccionar").Value = False
                dtGuias.Rows(dgvGuias.CurrentRow.Index).Item("Seleccionar_To_Factura") = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    '------------------------------------------------------------------------------------------


    '------------------------Pestaña de Generación de Factura----------------------------------
    Private Sub TCFacturacionEspecial_Selecting(sender As System.Object, e As System.Windows.Forms.TabControlCancelEventArgs) Handles TCFacturacionEspecial.Selecting
        Dim CantGuiasSeleccionadas As Integer = 0
        Dim CantGuiasCentoCostoGenerico As Integer = 0
        Try
            If TCFacturacionEspecial.SelectedIndex = 0 Then
                GrabarToolStripMenuItem.Visible = False
                ImprimirToolStripMenuItem.Visible = False
            ElseIf TCFacturacionEspecial.SelectedIndex = 1 Then
                If Not IsNothing(dtGuias) Then
                    If dtGuias.Rows.Count > 0 Then
                        'For index As Integer = 0 To dtGuias.Rows.Count - 1
                        '    If Convert.ToInt32(dtGuias.Rows(index).Item("Seleccionar_To_Factura").ToString) = 1 Then
                        '        CantGuiasSeleccionadas = CantGuiasSeleccionadas + 1
                        '        Exit For
                        '    End If
                        'Next

                        For index As Integer = 0 To dtGuias.Rows.Count - 1
                            If Convert.ToInt32(dtGuias.Rows(index).Item("Seleccionar_To_Factura").ToString) = 1 And Convert.ToInt32(dtGuias.Rows(index).Item("IdCentro_Costo").ToString.Trim) = 999 Then
                                CantGuiasSeleccionadas = CantGuiasSeleccionadas + 1
                                CantGuiasCentoCostoGenerico = CantGuiasCentoCostoGenerico + 1
                            ElseIf Convert.ToInt32(dtGuias.Rows(index).Item("Seleccionar_To_Factura").ToString) = 1 And Convert.ToInt32(dtGuias.Rows(index).Item("IdCentro_Costo").ToString.Trim) <> 999 Then
                                CantGuiasSeleccionadas = CantGuiasSeleccionadas + 1
                            End If
                        Next

                        If CantGuiasSeleccionadas <= 0 Then
                            MessageBox.Show("No existen guías seleccionadas para generar la factura", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            TCFacturacionEspecial.SelectedIndex = 0
                            dgvGuias.Focus()
                            Return
                        End If

                        If CantGuiasCentoCostoGenerico > 0 Then
                            MessageBox.Show("Existen " & CantGuiasCentoCostoGenerico.ToString & " guías seleccionadas de Centro de Costo Generico, motivo por el cual no se puede generar la factura", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            TCFacturacionEspecial.SelectedIndex = 0
                            dgvGuias.Focus()
                            Return
                        End If

                        Me.lblRazonSocial.Text = Me.cboRazonSocial.Text.Trim
                        Me.lblDatoFormaPago.Text = dtGuias.Rows(0).Item("Forma_Pago").ToString

                        dtDireccion = ObjFacturaEspecial.FNCARGAR_DIRECCION_CLIENTE()
                        If IsNothing(dtDireccion) = False Then
                            If dtDireccion.Rows.Count > 0 Then
                                cboDireccion.DataSource = dtDireccion
                                cboDireccion.DisplayMember = "direccion"
                                cboDireccion.ValueMember = "iddireccion_consignado"
                                cboDireccion.SelectedIndex = 0
                            Else
                                MessageBox.Show("No existen direcciones registradas para el cliente", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                TCFacturacionEspecial.SelectedIndex = 0
                                dgvGuias.Focus()
                                Return
                            End If
                        Else
                            MessageBox.Show("No existen direcciones registradas para el cliente", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            TCFacturacionEspecial.SelectedIndex = 0
                            dgvGuias.Focus()
                            Return
                        End If

                        Dim obj As New ClsLbTepsa.dtoCONTROL_COMPROBANTES
                        obj.FNLISTAR_CONTROL_COMPROBANTES(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, dtoUSUARIOS.IdLogin, 1)
                        Me.lblSerieNumeroDV.Text = obj.SERIE & " - " & obj.NRO_DOCUMENTO

                        dtGuiasCopia = Nothing
                        dtGuiasCopia = New DataTable

                        dc = New DataColumn
                        dc.ColumnName = "IdGuias_Envio"
                        dc.Caption = "IdGuias_Envio"
                        dtGuiasCopia.Columns.Add(dc)

                        dc = New DataColumn
                        dc.ColumnName = "IataOrigen"
                        dc.Caption = "IataOrigen"
                        dtGuiasCopia.Columns.Add(dc)

                        dc = New DataColumn
                        dc.ColumnName = "IataDestino"
                        dc.Caption = "IataDestino"
                        dtGuiasCopia.Columns.Add(dc)

                        dc = New DataColumn
                        dc.ColumnName = "Nro_Guia"
                        dc.Caption = "Nro_Guia"
                        dtGuiasCopia.Columns.Add(dc)

                        dc = New DataColumn
                        dc.ColumnName = "Centro_Costo"
                        dc.Caption = "Centro_Costo"
                        dtGuiasCopia.Columns.Add(dc)

                        dc = New DataColumn
                        dc.ColumnName = "IdCentro_Costo_Contacto"
                        dc.Caption = "IdCentro_Costo_Contacto"
                        dtGuiasCopia.Columns.Add(dc)

                        dc = New DataColumn
                        dc.ColumnName = "SubTotal_Costo_Final"
                        dc.Caption = "SubTotal_Costo_Final"
                        dtGuiasCopia.Columns.Add(dc)

                        dc = New DataColumn
                        dc.ColumnName = "Monto_Impuesto_Final"
                        dc.Caption = "Monto_Impuesto_Final"
                        dtGuiasCopia.Columns.Add(dc)

                        dc = New DataColumn
                        dc.ColumnName = "Total_Costo_Final"
                        dc.Caption = "Total_Costo_Final"
                        dtGuiasCopia.Columns.Add(dc)

                        dc = New DataColumn
                        dc.ColumnName = "Cantidad"
                        dc.Caption = "Cantidad"
                        dtGuiasCopia.Columns.Add(dc)

                        dc = New DataColumn
                        dc.ColumnName = "Total_Peso"
                        dc.Caption = "Total_Peso"
                        dtGuiasCopia.Columns.Add(dc)

                        dc = New DataColumn
                        dc.ColumnName = "Total_Volumen"
                        dc.Caption = "Total_Volumen"
                        dtGuiasCopia.Columns.Add(dc)

                        dc = New DataColumn
                        dc.ColumnName = "IdForma_Pago"
                        dc.Caption = "IdForma_Pago"
                        dtGuiasCopia.Columns.Add(dc)

                        dc = New DataColumn
                        dc.ColumnName = "IdTipo_Moneda"
                        dc.Caption = "IdTipo_Moneda"
                        dtGuiasCopia.Columns.Add(dc)

                        lblSubtotalFac.Text = "0.00"
                        lblIGVFac.Text = "0.00"
                        lblTotalFac.Text = "0.00"

                        For index As Integer = 0 To dtGuias.Rows.Count - 1
                            If Convert.ToInt32(dtGuias.Rows(index).Item("Seleccionar_to_factura").ToString) = 1 Then
                                dr = dtGuiasCopia.NewRow
                                dr("IdGuias_Envio") = dtGuias.Rows(index).Item("IdGuias_Envio").ToString
                                dr("IataOrigen") = dtGuias.Rows(index).Item("IataOrigen").ToString
                                dr("IataDestino") = dtGuias.Rows(index).Item("IataDestino").ToString
                                dr("Nro_Guia") = dtGuias.Rows(index).Item("Nro_Guia").ToString
                                dr("Centro_Costo") = dtGuias.Rows(index).Item("Centro_Costo").ToString
                                dr("IdCentro_Costo_Contacto") = dtGuias.Rows(index).Item("IdCentro_Costo_Contacto").ToString
                                dr("SubTotal_Costo_Final") = dtGuias.Rows(index).Item("SubTotal_Costo_Final").ToString
                                dr("Monto_Impuesto_Final") = dtGuias.Rows(index).Item("Monto_Impuesto_Final").ToString
                                dr("Total_Costo_Final") = dtGuias.Rows(index).Item("Total_Costo_Final").ToString
                                dr("Cantidad") = dtGuias.Rows(index).Item("Cantidad").ToString
                                dr("Total_Peso") = dtGuias.Rows(index).Item("Total_Peso").ToString
                                dr("Total_Volumen") = dtGuias.Rows(index).Item("Total_Volumen").ToString
                                dr("IdForma_Pago") = dtGuias.Rows(index).Item("IdForma_Pago").ToString
                                dr("IdTipo_Moneda") = dtGuias.Rows(index).Item("IdTipo_Moneda").ToString
                                dtGuiasCopia.Rows.Add(dr)
                                lblSubtotalFac.Text = Convert.ToString(Convert.ToDouble(lblSubtotalFac.Text.Trim) + Convert.ToDouble(dtGuias.Rows(index).Item("SubTotal_Costo_Final").ToString))
                                lblIGVFac.Text = Convert.ToString(Convert.ToDouble(lblIGVFac.Text.Trim) + Convert.ToDouble(dtGuias.Rows(index).Item("Monto_Impuesto_Final").ToString))
                                lblTotalFac.Text = Convert.ToString(Convert.ToDouble(lblTotalFac.Text.Trim) + Convert.ToDouble(dtGuias.Rows(index).Item("Total_Costo_Final").ToString))
                            End If
                        Next

                        dgvDetalleFactura.Columns.Clear()
                        AgregarColumasFactura()

                        Me.dgvDetalleFactura.DataSource = dtGuiasCopia

                        grpDetallefactura.Text = "Detalle de Factura: ( " & dtGuiasCopia.Rows.Count & " Registros )"

                        lblSubtotalFac.Text = "S/. " & lblSubtotalFac.Text
                        lblIGVFac.Text = "S/. " & lblIGVFac.Text
                        lblTotalFac.Text = "S/. " & lblTotalFac.Text

                        GrabarToolStripMenuItem.Visible = True
                        ImprimirToolStripMenuItem.Visible = False
                    Else
                        MessageBox.Show("Ejecute el procesamiento de las guías para generar la factura", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        TCFacturacionEspecial.SelectedIndex = 0
                        dgvGuias.Focus()
                        Return
                    End If
                Else
                    MessageBox.Show("Ejecute el procesamiento de las guías para generar la factura", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    TCFacturacionEspecial.SelectedIndex = 0
                    dgvGuias.Focus()
                    Return
                End If
            ElseIf TCFacturacionEspecial.SelectedIndex = 2 Then
                GrabarToolStripMenuItem.Visible = False
                ImprimirToolStripMenuItem.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub AgregarColumasFactura()

        Dim IataOrigen As New DataGridViewTextBoxColumn
        With IataOrigen
            .HeaderText = "Iata Origen"
            .Name = "IataOrigen"
            .DataPropertyName = "IataOrigen"
            .ReadOnly = True
            .Width = 70
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

        Dim IataDestino As New DataGridViewTextBoxColumn
        With IataDestino
            .HeaderText = "Iata Destino"
            .Name = "IataDestino"
            .DataPropertyName = "IataDestino"
            .ReadOnly = True
            .Width = 70
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

        Dim Centro_Costo As New DataGridViewTextBoxColumn
        With Centro_Costo
            .HeaderText = "Centro Costo"
            .Name = "Centro_Costo"
            .DataPropertyName = "Centro_Costo"
            .ReadOnly = True
            .Width = 90
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim IdCentro_Costo_Contacto As New DataGridViewTextBoxColumn
        With IdCentro_Costo_Contacto
            .HeaderText = "Centro Costo Contacto"
            .Name = "Centro_Costo_Contacto"
            .DataPropertyName = "IdCentro_Costo_Contacto"
            .ReadOnly = True
            .Width = 130
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

        Dim Nro_Guia As New DataGridViewTextBoxColumn
        With Nro_Guia
            .HeaderText = "Nro. Guía"
            .Name = "Nro_Guia"
            .DataPropertyName = "Nro_Guia"
            .ReadOnly = True
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

        Dim IdGuias_Envio As New DataGridViewTextBoxColumn
        With IdGuias_Envio
            .HeaderText = "IdGuias_Envio"
            .Name = "IdGuias_Envio"
            .DataPropertyName = "IdGuias_Envio"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
        End With

        Dim SubTotal_Costo_Final As New DataGridViewTextBoxColumn
        With SubTotal_Costo_Final
            .HeaderText = "SubTotal Costo Final"
            .Name = "SubTotal_Costo_Final"
            .DataPropertyName = "SubTotal_Costo_Final"
            .ReadOnly = True
            .Width = 120
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Monto_Impuesto_Final As New DataGridViewTextBoxColumn
        With Monto_Impuesto_Final
            .HeaderText = "IGV Final"
            .Name = "Monto_Impuesto_Final"
            .DataPropertyName = "Monto_Impuesto_Final"
            .ReadOnly = True
            .Width = 70
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Total_Costo_Final As New DataGridViewTextBoxColumn
        With Total_Costo_Final
            .HeaderText = "Total Costo Final"
            .Name = "Total_Costo_Final"
            .DataPropertyName = "Total_Costo_Final"
            .ReadOnly = True
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Cantidad As New DataGridViewTextBoxColumn
        With Cantidad
            .HeaderText = "Cantidad"
            .Name = "Cantidad"
            .DataPropertyName = "Cantidad"
            .ReadOnly = True
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Visible = False
        End With

        Dim Total_Peso As New DataGridViewTextBoxColumn
        With Total_Peso
            .HeaderText = "Total_Peso"
            .Name = "Total_Peso"
            .DataPropertyName = "Total_Peso"
            .ReadOnly = True
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Visible = False
        End With

        Dim Total_Volumen As New DataGridViewTextBoxColumn
        With Total_Volumen
            .HeaderText = "Total_Volumen"
            .Name = "Total_Volumen"
            .DataPropertyName = "Total_Volumen"
            .ReadOnly = True
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Visible = False
        End With

        Dim IdForma_Pago As New DataGridViewTextBoxColumn
        With IdForma_Pago
            .HeaderText = "IdForma_Pago"
            .Name = "IdForma_Pago"
            .DataPropertyName = "IdForma_Pago"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Visible = False
        End With

        Dim IdTipo_Moneda As New DataGridViewTextBoxColumn
        With IdTipo_Moneda
            .HeaderText = "IdTipo_Moneda"
            .Name = "IdTipo_Moneda"
            .DataPropertyName = "IdTipo_Moneda"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Visible = False
        End With

        dgvDetalleFactura.Columns.AddRange(IataOrigen, IataDestino, Nro_Guia, Centro_Costo, IdCentro_Costo_Contacto, IdGuias_Envio, SubTotal_Costo_Final, Monto_Impuesto_Final, Total_Costo_Final, Cantidad, Total_Peso, Total_Volumen, IdForma_Pago, IdTipo_Moneda)

        dgvDetalleFactura.Columns("SubTotal_Costo_Final").DefaultCellStyle.BackColor = Color.LightPink
        dgvDetalleFactura.Columns("Monto_Impuesto_Final").DefaultCellStyle.BackColor = Color.LightYellow
        dgvDetalleFactura.Columns("Total_Costo_Final").DefaultCellStyle.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub GrabarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GrabarToolStripMenuItem.Click
        Dim P_CANTIDAD As Double = 0
        Dim P_TOTAL_PESO As Double = 0
        Dim P_TOTAL_VOLUMEN As Double = 0
        Dim P_TOTAL_COSTO As Double = 0
        Dim P_MONTO_IMPUESTO As Double = 0
        Dim P_CANTIDAD_X_UNIDAD_VOLUMEN As Double = 0
        Dim P_CANTIDAD_X_UNIDAD_ARTI As Double = 0
        Try
            If dtGuiasCopia.Rows.Count > 0 Then
                For index As Integer = 0 To dtGuiasCopia.Rows.Count - 1
                    P_TOTAL_COSTO = P_TOTAL_COSTO + Convert.ToDouble(dtGuiasCopia.Rows(index).Item("Total_Costo_Final").ToString)
                    P_MONTO_IMPUESTO = P_MONTO_IMPUESTO + Convert.ToDouble(dtGuiasCopia.Rows(index).Item("Monto_Impuesto_Final").ToString)
                    P_CANTIDAD = P_CANTIDAD + Convert.ToDouble(dtGuiasCopia.Rows(index).Item("Cantidad").ToString)
                    P_TOTAL_PESO = P_TOTAL_PESO + Convert.ToDouble(dtGuiasCopia.Rows(index).Item("Total_Peso").ToString)
                    P_TOTAL_VOLUMEN = P_TOTAL_VOLUMEN + Convert.ToDouble(dtGuiasCopia.Rows(index).Item("Total_Volumen").ToString)
                Next
                
                If P_TOTAL_COSTO = 0 Then
                    MessageBox.Show("La Factura no se generará, porque no ha seleccionado ninguna guía para facturar o las guías seleccionadas tienen costo cero soles", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Return
                End If

                Dim ObjGuias_Envio_Prefactura As New ClsLbTepsa.dtoGuias_Envio_Prefactura

                P_CANTIDAD_X_UNIDAD_VOLUMEN = 0
                P_CANTIDAD_X_UNIDAD_ARTI = 0

                Dim ObjFactura As New ClsLbTepsa.dtoFACTURA

                With ObjFactura
                    .CANTIDAD_X_UNIDAD_ARTI = P_CANTIDAD_X_UNIDAD_ARTI
                    .CANTIDAD_X_UNIDAD_VOLUMEN = P_CANTIDAD_X_UNIDAD_VOLUMEN
                    .IDFORMA_PAGO = dtGuias.Rows(0).Item("IdForma_Pago").ToString
                    .IDESTADO_ENVIO = 19
                    .IDESTADO_FACTURA = 1
                    .CANTIDAD = P_CANTIDAD
                    .TOTAL_PESO = P_TOTAL_PESO
                    .TOTAL_VOLUMEN = P_TOTAL_VOLUMEN
                    .IDGUIA_TRANSPORTISTA = 0
                    .IDGUIA_TRANSPORTISTA_UPD = 0
                    .IDUNIDAD_ORIGEN = 0
                    .IDUNIDAD_DESTINO = 0
                    .IDDIREECION_ORIGEN = cboDireccion.SelectedValue
                    .IDDIREECION_DESTINO = 0
                    .MONTO_TIPO_CAMBIO = 3.33
                    .IDTIPO_MONEDA = dtGuias.Rows(0).Item("IdTipo_Moneda").ToString
                    .FECHA = Me.dtFechaFactura.Value.ToShortDateString
                    .FECHA_VENCIMIENTO = Me.dtFechaVencimiento.Value.ToShortDateString
                    .IDPERSONA_ORIGEN = 0
                    .IDPERSONA_DESTINO = 0
                    .IDPERSONA = ObjFacturaEspecial.ID_PERSONA
                    .IDTIPO_COMPROBANTE = 1
                    .MONTO_IMPUESTO = P_MONTO_IMPUESTO
                    .TOTAL_COSTO = P_TOTAL_COSTO
                    .IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
                    .IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                    .IP = dtoUSUARIOS.IP
                    .IDROL_USUARIO = dtoUSUARIOS.IdRol

                    If MessageBox.Show("¿Está seguro de grabar la Factura : " & lblSerieNumeroDV.Text.Trim & "?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                        Return
                    End If
                    If .FNINUPDE_FACTURA() = True Then
                        For i As Integer = 0 To Me.dtGuiasCopia.Rows.Count - 1
                            ObjGuias_Envio_Prefactura.IDFACTURA = ObjFactura.IDFACTURA
                            ObjGuias_Envio_Prefactura.IDGUIAS_ENVIO = dtGuiasCopia.Rows(i).Item("IDGUIAS_ENVIO").ToString
                            ObjGuias_Envio_Prefactura.IDROL_USUARIO = dtoUSUARIOS.IdRol
                            ObjGuias_Envio_Prefactura.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                            ObjGuias_Envio_Prefactura.IP = dtoUSUARIOS.IP

                            ObjGuias_Envio_Prefactura.fnCOMPROMETER_GUIAS_FACTU()
                        Next

                        MsgBox("Los datos se grabaron satisfactoriamente con el id: " & Str(ObjFactura.IDFACTURA), MsgBoxStyle.Information, "Seguridad del Sistema")

                    End If

                    dtGuiasCopia = Nothing
                    dgvDetalleFactura.DataSource = Nothing
                    btnProcesar_Click(sender, e)
                    TCFacturacionEspecial.SelectedIndex = 0
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    '------------------------------------------------------------------------------------------


    '---------------Pestaña de Consulta de Facturas Emitidas por Fecha ------------------------
    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
        Try
            If Me.txtRuc.Text = "" Then
                MessageBox.Show("Seleccione el cliente para consultar las facturas", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Return
            End If

            ObjFacturaEspecial.ID_PERSONA = Convert.ToInt32(dtPersona.Rows(cboRazonSocial.SelectedIndex).Item("IDPERSONA").ToString)

            If Me.dtFacturaFechaIni.Enabled = True Then ObjFacturaEspecial.FECHA_FACTURA_INICIO = Me.dtFacturaFechaIni.Value.ToShortDateString Else ObjFacturaEspecial.FECHA_FACTURA_INICIO = "NULL"
            If Me.dtFacturaFechaFin.Enabled = True Then ObjFacturaEspecial.FECHA_FACTURA_FINAL = Me.dtFacturaFechaFin.Value.ToShortDateString Else ObjFacturaEspecial.FECHA_FACTURA_FINAL = "NULL"

            dtFacturas = ObjFacturaEspecial.FNLISTAR_FACTURAS()

            dgvFacturaEmitida.Columns.Clear()
            AgregarColumasConsultaFactura()

            dgvFacturaEmitida.DataSource = dtFacturas

            grpConsultaFactura.Text = "Cantidad de facturas: ( " & dtFacturas.Rows.Count & " Registros )"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub AgregarColumasConsultaFactura()

        Dim IdFactura As New DataGridViewTextBoxColumn
        With IdFactura
            .HeaderText = "IdFactura"
            .Name = "IdFactura"
            .DataPropertyName = "IdFactura"
            .ReadOnly = True
            .Width = 70
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .Visible = False
        End With

        Dim Razon_Social As New DataGridViewTextBoxColumn
        With Razon_Social
            .HeaderText = "Razón Social"
            .Name = "Razon_Social"
            .DataPropertyName = "Razon_Social"
            .ReadOnly = True
            .Width = 150
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim Codigo_Cliente As New DataGridViewTextBoxColumn
        With Codigo_Cliente
            .HeaderText = "RUC"
            .Name = "Codigo_Cliente"
            .DataPropertyName = "Codigo_Cliente"
            .ReadOnly = True
            .Width = 90
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

        Dim Serie_Factura As New DataGridViewTextBoxColumn
        With Serie_Factura
            .HeaderText = "Serie"
            .Name = "Serie_Factura"
            .DataPropertyName = "Serie_Factura"
            .ReadOnly = True
            .Width = 55
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

        Dim Nro_Factura As New DataGridViewTextBoxColumn
        With Nro_Factura
            .HeaderText = "Nro. Factura"
            .Name = "Nro_Factura"
            .DataPropertyName = "Nro_Factura"
            .ReadOnly = True
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

        Dim Fecha As New DataGridViewTextBoxColumn
        With Fecha
            .HeaderText = "Fecha"
            .Name = "Fecha"
            .DataPropertyName = "Fecha"
            .ReadOnly = True
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

        Dim Sub_Total As New DataGridViewTextBoxColumn
        With Sub_Total
            .HeaderText = "SubTotal"
            .Name = "Sub_Total"
            .DataPropertyName = "Sub_Total"
            .ReadOnly = True
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim IGV As New DataGridViewTextBoxColumn
        With IGV
            .HeaderText = "IGV"
            .Name = "Monto_Impuesto"
            .DataPropertyName = "Monto_Impuesto"
            .ReadOnly = True
            .Width = 70
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Total_Costo As New DataGridViewTextBoxColumn
        With Total_Costo
            .HeaderText = "Total"
            .Name = "Total_Costo"
            .DataPropertyName = "Total_Costo"
            .ReadOnly = True
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Estado_Registro As New DataGridViewTextBoxColumn
        With Estado_Registro
            .HeaderText = "Estado"
            .Name = "Estado_Registro"
            .DataPropertyName = "Estado_Registro"
            .ReadOnly = True
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

        Dim Desc_Moneda As New DataGridViewTextBoxColumn
        With Desc_Moneda
            .HeaderText = "Desc_Moneda"
            .Name = "Desc_Moneda"
            .DataPropertyName = "Desc_Moneda"
            .ReadOnly = True
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Visible = False
        End With

        dgvFacturaEmitida.Columns.AddRange(IdFactura, Razon_Social, Codigo_Cliente, Serie_Factura, Nro_Factura, Fecha, Sub_Total, IGV, Total_Costo, Estado_Registro, Desc_Moneda)

        dgvFacturaEmitida.Columns("Sub_Total").DefaultCellStyle.BackColor = Color.LightPink
        dgvFacturaEmitida.Columns("Monto_Impuesto").DefaultCellStyle.BackColor = Color.LightYellow
        dgvFacturaEmitida.Columns("Total_Costo").DefaultCellStyle.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub dgvFacturaEmitida_Click(sender As System.Object, e As System.EventArgs) Handles dgvFacturaEmitida.Click
        Try
            ObjFacturaEspecial.ID_FACTURA = Convert.ToInt32(dtFacturas.Rows(dgvFacturaEmitida.CurrentRow.Index).Item("IDFACTURA").ToString)
            
            dtGuiasFacturadas = ObjFacturaEspecial.FNFACTURAS_GUIAS()

            dgvGuiaFacturada.Columns.Clear()
            AgregarColumasConsultaGuiasFacturadas()

            dgvGuiaFacturada.DataSource = dtGuiasFacturadas

            grpGuiaFacturada.Text = "Cantidad de Guías facturadas: ( " & dtGuiasFacturadas.Rows.Count & " Registros )"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub AgregarColumasConsultaGuiasFacturadas()

        Dim Razon_Social As New DataGridViewTextBoxColumn
        With Razon_Social
            .HeaderText = "Razón Social"
            .Name = "Razon_Social"
            .DataPropertyName = "Razon_Social"
            .ReadOnly = True
            .Width = 150
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim Nu_Docu_Suna As New DataGridViewTextBoxColumn
        With Nu_Docu_Suna
            .HeaderText = "RUC"
            .Name = "Nu_Docu_Suna"
            .DataPropertyName = "Nu_Docu_Suna"
            .ReadOnly = True
            .Width = 90
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

        Dim IdGuias_Envio As New DataGridViewTextBoxColumn
        With IdGuias_Envio
            .HeaderText = "IdGuias_Envio"
            .Name = "IdGuias_Envio"
            .DataPropertyName = "IdGuias_Envio"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Visible = False
        End With

        Dim Liquidado As New DataGridViewCheckBoxColumn
        With Liquidado
            .HeaderText = "Liquidado"
            .Name = "Liquidado"
            .DataPropertyName = "Liquidado"
            .TrueValue = 1
            .FalseValue = 0
            .ReadOnly = True
            .Width = 60
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

        Dim Facturado As New DataGridViewCheckBoxColumn
        With Facturado
            .HeaderText = "Facturado"
            .Name = "Facturado"
            .DataPropertyName = "Facturado"
            .TrueValue = 1
            .FalseValue = 0
            .ReadOnly = True
            .Width = 60
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

        Dim Nro_Guia As New DataGridViewTextBoxColumn
        With Nro_Guia
            .HeaderText = "Nro. Guía"
            .Name = "Nro_Guia"
            .DataPropertyName = "Nro_Guia"
            .ReadOnly = True
            .Width = 90
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

        Dim Fecha As New DataGridViewTextBoxColumn
        With Fecha
            .HeaderText = "Fecha"
            .Name = "Fecha"
            .DataPropertyName = "Fecha"
            .ReadOnly = True
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

        Dim Origen As New DataGridViewTextBoxColumn
        With Origen
            .HeaderText = "Origen"
            .Name = "Origen"
            .DataPropertyName = "Origen"
            .ReadOnly = True
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim Destino As New DataGridViewTextBoxColumn
        With Destino
            .HeaderText = "Destino"
            .Name = "Destino"
            .DataPropertyName = "Destino"
            .ReadOnly = True
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim Cantidad As New DataGridViewTextBoxColumn
        With Cantidad
            .HeaderText = "Cantidad"
            .Name = "Cantidad"
            .DataPropertyName = "Cantidad"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .Visible = False
        End With

        Dim Sub_Total As New DataGridViewTextBoxColumn
        With Sub_Total
            .HeaderText = "SubTotal"
            .Name = "Sub_Total"
            .DataPropertyName = "Sub_Total"
            .ReadOnly = True
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim IGV As New DataGridViewTextBoxColumn
        With IGV
            .HeaderText = "IGV"
            .Name = "Importe_Igv"
            .DataPropertyName = "Importe_Igv"
            .ReadOnly = True
            .Width = 70
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Total_Costo As New DataGridViewTextBoxColumn
        With Total_Costo
            .HeaderText = "Total"
            .Name = "Total_Costo"
            .DataPropertyName = "Total_Costo"
            .ReadOnly = True
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim Estado_Registro As New DataGridViewTextBoxColumn
        With Estado_Registro
            .HeaderText = "Estado"
            .Name = "Estado_Registro"
            .DataPropertyName = "Estado_Registro"
            .ReadOnly = True
            .Width = 90
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        End With

        dgvGuiaFacturada.Columns.AddRange(Razon_Social, Nu_Docu_Suna, IdGuias_Envio, Liquidado, Facturado, Nro_Guia, Fecha, Origen, Destino, Cantidad, Sub_Total, IGV, Total_Costo, Estado_Registro)

        dgvGuiaFacturada.Columns("Sub_Total").DefaultCellStyle.BackColor = Color.LightPink
        dgvGuiaFacturada.Columns("Importe_Igv").DefaultCellStyle.BackColor = Color.LightYellow
        dgvGuiaFacturada.Columns("Total_Costo").DefaultCellStyle.BackColor = Color.LightSteelBlue
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ImprimirToolStripMenuItem.Click
        Dim obj As New Imprimir
        Dim ObjReport = New ClsLbTepsa.dtoFrmReport

        Dim Total_Costo As Double = 0
        Dim Monto_Impuesto As Double = 0
        Dim Interes As Double = 0

        Dim glosa02 As String = String.Empty
        Try
            Select Case Me.TCFacturacionEspecial.SelectedIndex
                Case 2
                    If dgvFacturaEmitida.Rows.Count = 0 Then
                        MessageBox.Show("Seleccione una factura para la impresión", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    If IsNothing(dgvFacturaEmitida.CurrentCell) Then
                        MsgBox("Seleccione una factura", MsgBoxStyle.Information, "Seguridad del Sistema")
                        Exit Sub
                    End If

                    Total_Costo = dtFacturas.Rows(dgvFacturaEmitida.CurrentRow.Index).Item("TOTAL_COSTO")
                    Monto_Impuesto = dtFacturas.Rows(dgvFacturaEmitida.CurrentRow.Index).Item("MONTO_IMPUESTO")
                    Interes = 100 * (Monto_Impuesto) / (Total_Costo - Monto_Impuesto)
                    Interes = Int(FormatNumber(Interes, 2))

                    If Total_Costo > 400 Then
                        If MessageBox.Show("Posiblemente esta factura este considerando en la impresion la GLOSA DE DETRACCION" & Chr(13) & Chr(13) & " ¿DESEA IMPRIMIR LA GLOSA?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            glosa02 = "OPERACION SUJETA AL SISTEMA DE PAGO DE OPERACIONES TRIBUTARIAS BANCO DE " & vbCrLf & _
                                      "LA NACION Nº 0019-002829. EXCLUIDOS DE RETENCION DEL 6% DE IGV POR SER  " & vbCrLf & _
                                      "AGENTES DE RETENCION SEGUN ART. 10 C.T., R.S. 228-2012/SUNAT"
                        Else
                            glosa02 = ""
                        End If
                    Else
                        glosa02 = "EXCLUIDOS DE RETENCION DEL 6% DE IGV POR SER AGENTES DE RETENCION SEGUN " & _
                                  "ART. 10 C.T., R.S. 228-2012/SUNAT"
                    End If

                    If glosa02 = "" Then
                        If MessageBox.Show("¿Desea imprimir la glosa personalizada?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            Dim a As New FrmGlosaPersonalizada
                            Acceso.Asignar(a, Me.hnd)
                            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                                a.ShowDialog()
                                glosa02 = Glosa_Persona
                            Else
                                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                glosa02 = ""
                            End If

                        End If
                    End If

                    Dim objFac As New ClsLbTepsa.dtoFACTURA
                    Dim dt As DataTable = objFac.Facturacion(dtFacturas.Rows(dgvFacturaEmitida.CurrentRow.Index).Item("IDFACTURA"))

                    obj.Inicializar()
                    Dim sImpresora As String
                    Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0

                    Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
                    Dim dt2 As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 1)
                    If dt2.Rows.Count = 0 Then
                        sImpresora = ""
                    Else
                        If IsDBNull(dt2.Rows(0).Item("impresora")) Then
                            sImpresora = ""
                        Else
                            sImpresora = dt2.Rows(0).Item("impresora")
                            iTamaño = dt2.Rows(0).Item("tamano")
                            iSuperior = dt2.Rows(0).Item("superior")
                            Iizquierda = dt2.Rows(0).Item("izquierda")
                        End If
                    End If
                    obj.Impresora = sImpresora
                    obj.Superior = iSuperior
                    obj.Izquierda = Iizquierda

                    Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
                    Dim iLong As Integer = IIf(iTamaño = 0, 38, iTamaño)

                    y = iLong * pagina + 4
                    For Each row As DataRow In dt.Rows
                        y += 1
                        i += 1
                        Dim direccion As String = "Av. Manuel Echeandia Nro.303 - San Luis - Lima - Lima"
                        Dim sDoc As String = row("SERIE_FACTURA") & "-" & row("NRO_FACTURA")
                        obj.EscribirLinea(y + 2, 10, direccion)
                        obj.EscribirLinea(y + 1, 80, "Fact: " & sDoc)

                        'Dim sDoc As String = row("SERIE_FACTURA") & "-" & row("NRO_FACTURA")
                        'obj.EscribirLinea(y, 48, "Fact: " & sDoc)

                        obj.EscribirLinea(y + 4, 8, row("DIA_FACTURA"))
                        obj.EscribirLinea(y + 4, 23, row("MES_FACTURA"))
                        obj.EscribirLinea(y + 4, 42, row("ANIO_FACTURA"))

                        obj.EscribirLinea(y + 5, 13, IIf(IsDBNull(row("RAZON_SOCIAL")), "", row("RAZON_SOCIAL")))
                        obj.EscribirLinea(y + 5, 66, IIf(IsDBNull(row("CODIGO_CLIENTE")), "", row("CODIGO_CLIENTE")))
                        obj.EscribirLinea(y + 5, 105, IIf(IsDBNull(row("REFE")), "", row("REFE")))

                        obj.EscribirLinea(y + 6, 13, row("DIREC_REMI"))
                        obj.EscribirLinea(y + 6, 105, IIf(IsDBNull(row("MEMO")), "", row("MEMO")))

                        obj.EscribirLinea(y + 7, 66, IIf(IsDBNull(row("REMITENTE")), "", row("REMITENTE")))
                        obj.EscribirLinea(y + 7, 46, IIf(IsDBNull(row("DESTINO")), "", row("DESTINO")))
                        'obj.EscribirLinea(y + 7, 66, IIf(IsDBNull(row("DIREC_REMI")), "", row("DIREC_REMI")))
                        obj.EscribirLinea(y + 7, 105, IIf(IsDBNull(row("CONDI_PAGO")), "", row("CONDI_PAGO")))

                        obj.EscribirLinea(y + 9, 13, IIf(IsDBNull(row("NRO_PREFACTURA")), "", row("NRO_PREFACTURA")))
                        obj.EscribirLinea(y + 9, 66, IIf(IsDBNull(row("DIREC_DESTI")), "", row("DIREC_DESTI")))

                        If Not IsDBNull(row("GLOSA")) Then
                            Dim glosa As String
                            glosa = row("GLOSA").ToString.Replace(Chr(13), "")
                            glosa = row("GLOSA").ToString.Replace(Chr(10), "")
                            glosa = glosa.Trim & Space(300 - glosa.Length)

                            obj.EscribirLinea(y + 13, 21, glosa.Substring(0, 72))
                            obj.EscribirLinea(y + 14, 21, glosa.Substring(72, 72))
                            obj.EscribirLinea(y + 15, 21, glosa.Substring(144, 72))
                            obj.EscribirLinea(y + 16, 21, glosa.Substring(216, 72))
                        End If

                        If glosa02.Trim.Length > 0 Then
                            glosa02 = glosa02.Replace(Chr(13), "")
                            glosa02 = glosa02.Replace(Chr(10), "")
                            glosa02 = glosa02.Trim & Space(300 - glosa02.Length)

                            obj.EscribirLinea(y + 17, 21, glosa02.Substring(0, 72))
                            obj.EscribirLinea(y + 18, 21, glosa02.Substring(72, 72))
                            obj.EscribirLinea(y + 19, 21, glosa02.Substring(144, 72))
                        End If

                        obj.EscribirLinea(y + 13, 110, FormatNumber(row("SUB_TOTAL"), 2).PadLeft(10, " "))

                        obj.EscribirLinea(y + 20, 21, "Son: " & ConvercionNroEnLetras(dtFacturas.Rows(dgvFacturaEmitida.CurrentRow.Index).Item("TOTAL_COSTO")))
                        obj.EscribirLinea(y + 21, 21, "S.E.U.O.")


                        obj.EscribirLinea(y + 22, 83, dtoUSUARIOS.iIGV.ToString("0.00"))

                        obj.EscribirLinea(y + 21, 105, "S/.")
                        obj.EscribirLinea(y + 22, 105, "S/.")
                        obj.EscribirLinea(y + 23, 105, "S/.")

                        obj.EscribirLinea(y + 21, 110, FormatNumber(row("SUB_TOTAL"), 2).PadLeft(10, " "))
                        obj.EscribirLinea(y + 22, 110, FormatNumber(row("MONTO_IMPUESTO"), 2).PadLeft(10, " "))
                        obj.EscribirLinea(y + 23, 110, FormatNumber(row("TOTAL_COSTO"), 2).PadLeft(10, " "))

                        obj.EscribirLinea(y + 26, 54, row("FACTURADOR"))
                    Next
                    obj.Comprimido = True
                    obj.Preliminar = True
                    obj.Tamaño = iLong
                    obj.Imprimir()
                    obj.Finalizar()

                    Dim frm As New FrmPreview
                    frm.Documento = 1
                    frm.Tamaño = iLong
                    frm.Text = "Facturación Otros"
                    frm.ShowDialog()

                    Dim OBJFACTURA As New ClsLbTepsa.dtoFACTURA
                    OBJFACTURA.IDFACTURA = dtFacturas.Rows(dgvFacturaEmitida.CurrentRow.Index).Item("IDFACTURA")
                    OBJFACTURA.FN_ESTADO_IMPRESO()
                    'listar_facturas()
                    'mostrar_guias()

                    Return
                    'ObjReport.rutaRpt = PathFrmReport
                    'ObjReport.conectar(rptservice, rptuser, rptpass)
                    'ObjReport.printrpt(False, "", "FAC001.RPT", "P_IDFACTURA;" & dtFacturas.Rows(dgvFacturaEmitida.CurrentRow.Index)("IDFACTURA"), _
                    '"P_USUARIO;" & "", _
                    '"P_AGENCIA;" & "", _
                    '"P_FECHA_APERTURA;" & "", _
                    '"P_FECHA_CIERRE;" & "", _
                    '"P_MONTO_LETRAS;" & ConvercionNroEnLetras(dtFacturas.Rows(dgvFacturaEmitida.CurrentRow.Index)("TOTAL_COSTO")), _
                    '"P_MENSAJE;" & "", _
                    '"P_IGV;" & Interes, _
                    '"P_GLOSA02;" & glosa02, _
                    '"P_DIRECCION;" & cmbDireccion.Text, _
                    '"P_IMPRESO;" & "")
            End Select
        Catch ex As Exception
            obj.Finalizar()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ExportarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportarToolStripMenuItem.Click
        Try

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    '------------------------------------------------------------------------------------------
    
    
    
End Class