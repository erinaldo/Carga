Public Class frmBuscarCliente
    'Dim daControl_FAC As New OleDb.OleDbDataAdapter
    Public dtControl_FAC As New System.Data.DataTable
    Dim dvControl_FAC As System.Data.DataView
    Dim bIngreso As Boolean = False
    Public hnd As Long
    Public DtpFechaInicio As String
    Public DtpFechaFin As String
    Public Control As Integer
    Public llamada As Integer = 0

    Private Sub frmBuscarCliente_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frmBuscarCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Formato()
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function fnBuscar() As Boolean
        Try
            Dim obj As New dtoPce()
            If txtBuscar.Text.Trim.Length < 3 Then
                MessageBox.Show("El Texto a Buscar debe ser mayor a 3 caracteres.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtBuscar.Focus()
                Return False
            End If

            ObjBusquedaClientes.idPersona = 0
            ObjBusquedaClientes.RUCDNI = txtBuscar.Text
            ObjBusquedaClientes.RAZON_SOCIAL = "" & txtBuscar.Text & "%"

            Dim iControl As Integer
            If Val(txtBuscar.Text) > 0 Then
                iControl = 2
            Else
                iControl = 1
            End If
            If llamada = 1 Then
                iControl = 3
            End If

            '
            dtControl_FAC.Clear()
            DgvLista.Refresh()
            '
            If Control = 10 Then
                Try
                    ObjBusquedaClientes.iControl = 1
                    If Int(txtBuscar.Text.ToString) > 0 Then
                        ObjBusquedaClientes.iControl = 2
                    End If
                Catch ex As Exception
                    ObjBusquedaClientes.iControl = 1
                End Try

                ObjBusquedaClientes.idPersona = 0
                ObjBusquedaClientes.RUCDNI = txtBuscar.Text
                ObjBusquedaClientes.RAZON_SOCIAL = "" & txtBuscar.Text & "%"
                'ObjBusquedaClientes.RAZON_SOCIAL = "" & txtBuscar.Text & "%"

                If RdbCliente.Checked = True Then
                    dtControl_FAC = ObjBusquedaClientes.fnBuscarCliente()
                Else
                    'Mod. 20/08/2009 -->Omendoza - Pasando al datahelper   
                    dtControl_FAC = ObjBusquedaClientes.fnBuscarConsignado()
                End If
            Else
                If RdbCliente.Checked = True Then
                    dtControl_FAC = obj.fnBuscarCliente(Control, iControl, DtpFechaInicio, DtpFechaFin, _
                                                        ObjBusquedaClientes.RUCDNI, ObjBusquedaClientes.RAZON_SOCIAL)
                ElseIf rdbConsignado.Checked = True Then
                    dtControl_FAC = obj.fnBuscarConsignado(Control, DtpFechaInicio, DtpFechaFin, ObjBusquedaClientes.RAZON_SOCIAL)
                End If
            End If

            dvControl_FAC = dtControl_FAC.DefaultView
            DgvLista.DataSource = dvControl_FAC
            DgvLista.Refresh()

            If dvControl_FAC.Count = 0 Then
                BtnAceptar.Enabled = False
                MessageBox.Show("No Se Encontraron Coincidencias.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.BtnBuscar.Text = Me.BtnBuscar.Text.Trim
            Else
                BtnAceptar.Enabled = True
                Me.DgvLista.Focus()
                Me.DgvLista.Rows(0).Selected = True
            End If
            LblRegistros.Text = dvControl_FAC.Count
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean = True
        Dim flat As Boolean = True
        Try
            Dim var As Integer = msg.WParam.ToInt32
            If msg.WParam.ToInt32 = Keys.Enter Then
                If txtBuscar.Focused = True Then
                    Me.Cursor = Cursors.AppStarting
                    fnBuscar()
                    Me.Cursor = Cursors.Default
                ElseIf DgvLista.Focused = True Then
                    Me.Cursor = Cursors.AppStarting
                    Me.EnviarDatos()
                    Me.Cursor = Cursors.Default
                End If
            ElseIf msg.WParam.ToInt32 = Keys.Escape Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Close()
            ElseIf msg.WParam.ToInt32 = Keys.F3 Then
                DgvLista.Focus()
                flat = MyBase.ProcessCmdKey(msg, KeyData)
            Else
                flat = MyBase.ProcessCmdKey(msg, KeyData)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
            objGuiaEnvio.iCONTROL = 1
        End Try
        Return flat
    End Function

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Try
            Me.Cursor = Cursors.AppStarting
            fnBuscar()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        Try
            Me.Cursor = Cursors.AppStarting
            Me.EnviarDatos()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DgvLista_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DgvLista.DoubleClick
        Try
            If Me.DgvLista.Rows.Count > 0 Then
                Me.Cursor = Cursors.AppStarting
                Me.EnviarDatos()
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtBuscar_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscar.Enter
        Me.txtBuscar.SelectAll()
    End Sub

    Private Sub txtBuscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscar.GotFocus
        Me.txtBuscar.SelectAll()
    End Sub

    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        If txtBuscar.Text.Trim.Length > 0 Then
            BtnBuscar.Enabled = True
        Else
            BtnBuscar.Enabled = False
        End If
    End Sub

    Sub EnviarDatos()
        Try
            Dim row As Integer = DgvLista.SelectedRows.Item(0).Index
            'ObjBusquedaClientes.idPersona = DgvLista.Rows(row).Cells(0).Value
            ObjBusquedaClientes.IDTIPO = DgvLista.Rows(row).Cells("idtipo_comprobante").Value
            ObjBusquedaClientes.IDDOC = DgvLista.Rows(row).Cells("IdFactura").Value
            dtControl_FAC.DefaultView.RowFilter = "idtipo_comprobante=" & ObjBusquedaClientes.IDTIPO & " and IdFactura=" & ObjBusquedaClientes.IDDOC & " "
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub Formato()
        With Me.DgvLista
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .AllowUserToResizeColumns = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.ScrollBars = ScrollBars.Both
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .ReadOnly = True 'readonly cuando este false se puede editar
            Dim fecha As New DataGridViewTextBoxColumn
            With fecha
                .HeaderText = "Fecha"
                .Name = "fecha"
                .DataPropertyName = "fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.ReadOnly = True
            End With
            Dim guia As New DataGridViewTextBoxColumn
            With guia
                .HeaderText = "Comprobante"
                .Name = "guia"
                .DataPropertyName = "guia"
                '.SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 150
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            Dim tipo As New DataGridViewTextBoxColumn
            With tipo
                .HeaderText = "Tipo"
                .Name = "tipo"
                .DataPropertyName = "tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            End With
            'agregar columna al grid
            Dim origen As New DataGridViewTextBoxColumn
            With origen
                .HeaderText = "Orígen"
                .Name = "origen"
                .DataPropertyName = "origen"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.Width = 150
            End With
            ' fin de agregado  
            'agregar columna al grid
            Dim destino As New DataGridViewTextBoxColumn
            With destino
                .HeaderText = "Destino"
                .Name = "destino"
                .DataPropertyName = "destino"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim transito As New DataGridViewTextBoxColumn
            With transito
                .HeaderText = "Tránsito"
                .Name = "transito"
                .DataPropertyName = "transito"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                '.Width = 120
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim documento As New DataGridViewTextBoxColumn
            With documento
                .HeaderText = "Nº Documento"
                .Name = "documento"
                .DataPropertyName = "documento"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim cliente As New DataGridViewTextBoxColumn
            With cliente
                .HeaderText = "Cliente"
                .Name = "cliente"
                .DataPropertyName = "cliente"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            Dim cantidad As New DataGridViewTextBoxColumn
            With cantidad
                .HeaderText = "Cantidad"
                .Name = "cantidad"
                .DataPropertyName = "cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            Dim total_peso As New DataGridViewTextBoxColumn
            With total_peso
                .HeaderText = "Total Peso"
                .Name = "total_peso"
                .DataPropertyName = "total_peso"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            Dim Total_Volumen As New DataGridViewTextBoxColumn
            With Total_Volumen
                .HeaderText = "Total Volumen"
                .Name = "Total_Volumen"
                .DataPropertyName = "Total_Volumen"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            Dim Precio_x_Peso As New DataGridViewTextBoxColumn
            With Precio_x_Peso
                .HeaderText = "Precio Peso"
                .Name = "Precio_x_Peso"
                .DataPropertyName = "Precio_x_Peso"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            Dim Precio_x_Volumen As New DataGridViewTextBoxColumn
            With Precio_x_Volumen
                .HeaderText = "Precio Volumen"
                .Name = "Precio_x_Volumen"
                .DataPropertyName = "Precio_x_Volumen"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            Dim Precio_x_Sobre As New DataGridViewTextBoxColumn
            With Precio_x_Sobre
                .HeaderText = "Precio Sobre"
                .Name = "Precio_x_Sobre"
                .DataPropertyName = "Precio_x_Sobre"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            Dim Monto_Base As New DataGridViewTextBoxColumn
            With Monto_Base
                .HeaderText = "Monto Base"
                .Name = "Monto_Base"
                .DataPropertyName = "Monto_Base"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim Porcent_Descuento As New DataGridViewTextBoxColumn
            With Porcent_Descuento
                .HeaderText = "% Descuento"
                .Name = "Porcent_Descuento"
                .DataPropertyName = "Porcent_Descuento"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim Monto_Sub_Total As New DataGridViewTextBoxColumn
            With Monto_Sub_Total
                .HeaderText = "SubTotal"
                .Name = "Monto_Sub_Total"
                .DataPropertyName = "Monto_Sub_Total"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim Monto_Impuesto As New DataGridViewTextBoxColumn
            With Monto_Impuesto
                .HeaderText = "Impuesto"
                .Name = "Monto_Impuesto"
                .DataPropertyName = "Monto_Impuesto"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim Total_Costo As New DataGridViewTextBoxColumn
            With Total_Costo
                .HeaderText = "Total"
                .Name = "Total_Costo"
                .DataPropertyName = "Total_Costo"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim igv As New DataGridViewTextBoxColumn
            With igv
                .HeaderText = "Igv"
                .Name = "igv"
                .DataPropertyName = "igv"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With
            Dim usuario As New DataGridViewTextBoxColumn
            With usuario
                .HeaderText = "Usuario"
                .Name = "usuario"
                .DataPropertyName = "usuario"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim Estado_Doc As New DataGridViewTextBoxColumn
            With Estado_Doc
                .HeaderText = "Estado Doc."
                .Name = "Estado_Doc"
                .DataPropertyName = "Estado_Doc"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim Estado_Envio As New DataGridViewTextBoxColumn
            With Estado_Envio
                .HeaderText = "Estado Envío"
                .Name = "Estado_Envio"
                .DataPropertyName = "Estado_Envio"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim Facturado As New DataGridViewTextBoxColumn
            With Facturado
                .HeaderText = "Cancelado"
                .Name = "Facturado"
                .DataPropertyName = "Facturado"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim proceso As New DataGridViewTextBoxColumn
            With proceso
                .HeaderText = "Producto"
                .Name = "proceso"
                .DataPropertyName = "proceso"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim nroboleto As New DataGridViewTextBoxColumn
            With nroboleto
                .HeaderText = "Nº Boleto"
                .Name = "nroboleto"
                .DataPropertyName = "nroboleto"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim comprobante As New DataGridViewTextBoxColumn
            With comprobante
                .HeaderText = "Cancelado Por"
                .Name = "comprobante"
                .DataPropertyName = "comprobante"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With

            Dim idtipo_comprobante As New DataGridViewTextBoxColumn
            With idtipo_comprobante
                .HeaderText = "idtipo_comprobante"
                .Name = "idtipo_comprobante"
                .DataPropertyName = "idtipo_comprobante"
                .Visible = False
            End With

            Dim Idestado_Factura As New DataGridViewTextBoxColumn
            With Idestado_Factura
                .HeaderText = "Idestado_Factura"
                .Name = "Idestado_Factura"
                .DataPropertyName = "Idestado_Factura"
                .Visible = False
            End With

            Dim IdFactura As New DataGridViewTextBoxColumn
            With IdFactura
                .HeaderText = "IdFactura"
                .Name = "IdFactura"
                .DataPropertyName = "IdFactura"
                .Visible = False
            End With

            Dim idforma_pago As New DataGridViewTextBoxColumn
            With idforma_pago
                .HeaderText = "idforma_pago"
                .Name = "idforma_pago"
                .DataPropertyName = "idforma_pago"
                .Visible = False
            End With

            Dim idunidad_destino As New DataGridViewTextBoxColumn
            With idunidad_destino
                .HeaderText = "idunidad_destino"
                .Name = "idunidad_destino"
                .DataPropertyName = "idunidad_destino"
                .Visible = False
            End With

            Dim idagencias_destino As New DataGridViewTextBoxColumn
            With idagencias_destino
                .HeaderText = "idagencias_destino"
                .Name = "idagencias_destino"
                .DataPropertyName = "idagencias_destino"
                .Visible = False
            End With

            Dim idunidad_origen As New DataGridViewTextBoxColumn
            With idunidad_origen
                .HeaderText = "idunidad_origen"
                .Name = "idunidad_origen"
                .DataPropertyName = "idunidad_origen"
                .Visible = False
            End With

            Dim idagencias As New DataGridViewTextBoxColumn
            With idagencias
                .HeaderText = "idagencias"
                .Name = "idagencias"
                .DataPropertyName = "idagencias"
                .Visible = False
            End With

            Dim idprocesos As New DataGridViewTextBoxColumn
            With idprocesos
                .HeaderText = "idprocesos"
                .Name = "idprocesos"
                .DataPropertyName = "idprocesos"
                .Visible = False
            End With

            Dim idestado_envio As New DataGridViewTextBoxColumn
            With idestado_envio
                .HeaderText = "idestado_envio"
                .Name = "idestado_envio"
                .DataPropertyName = "idestado_envio"
                .Visible = False
            End With

            .Columns.AddRange(fecha, guia, tipo, origen, destino, transito, documento, cliente, cantidad, _
                              total_peso, Total_Volumen, Precio_x_Peso, Precio_x_Volumen,
                              Precio_x_Sobre, Monto_Base, Porcent_Descuento, _
                              Monto_Sub_Total, Monto_Impuesto, Total_Costo, igv, _
                              usuario, Estado_Doc, Estado_Envio, Facturado, proceso, _
                              nroboleto, comprobante, idtipo_comprobante, Idestado_Factura, IdFactura, _
                              idforma_pago, idunidad_destino, idagencias_destino, idunidad_origen, _
                              idagencias, idprocesos, idestado_envio)
        End With

    End Sub

    Private Sub RdbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbCliente.CheckedChanged, rdbConsignado.CheckedChanged
        Me.txtBuscar.Focus()
    End Sub

    Private Sub DgvLista_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DgvLista.RowsRemoved
        Me.LblRegistros.Text = DgvLista.Rows.Count
    End Sub

    Private Sub DgvLista_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DgvLista.RowsAdded
        Me.LblRegistros.Text = DgvLista.Rows.Count
    End Sub
End Class