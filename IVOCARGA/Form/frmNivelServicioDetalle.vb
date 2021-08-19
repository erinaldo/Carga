
Public Class frmNivelServicioDetalle
    Dim strFecha As String
    Dim intUsuario As Integer
    Dim strIp As String
    Dim intTotalEnvios As Integer
    Dim intOrigen As Integer
    Dim intDestino As Integer
    Dim intTodo As Integer

    Public intOpcion As Integer = 0
    Dim intEstado As Integer

    Public hnd As Long

    Private Sub ConfigurarDGV2()
        With dgvNivelServicioDetalle
            Cls_Utilitarios.FormatDataGridView(dgvNivelServicioDetalle)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Microsoft Sans Serif", 8.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 9.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_registro As New DataGridViewTextBoxColumn
            With col_registro
                .Name = "registro" : .DataPropertyName = "registro"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Comprobante"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_documento As New DataGridViewTextBoxColumn
            With col_documento
                .Name = "documento" : .DataPropertyName = "documento"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Comprobante"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_envio As New DataGridViewTextBoxColumn
            With col_envio
                .Name = "envio" : .DataPropertyName = "envio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado Envío"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With

            .Columns.AddRange(col_registro, col_fecha, col_origen, col_destino, col_tipo, col_documento, col_envio)
        End With
    End Sub

    Function NombreEstadoCarga(estado As Integer) As String
        Dim strEstado As String = ""
        Select Case estado
            Case 18
                strEstado = "Registro"
            Case 19
                strEstado = "Despacho"
            Case 20
                strEstado = "Recepción"
            Case 21
                strEstado = "Entrega"
            Case 47
                strEstado = "Reparto"
        End Select
        Return strEstado
    End Function

    Private Sub ConfigurarDGV()
        With dgvNivelServicioDetalle
            Cls_Utilitarios.FormatDataGridView(dgvNivelServicioDetalle)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Microsoft Sans Serif", 8.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 9.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim x As Integer = 0
            Dim col_registro As New DataGridViewTextBoxColumn
            With col_registro
                .Name = "registro" : .DataPropertyName = "registro"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha " & NombreEstadoCarga(intOrigen)
            End With
            x += +1
            Dim col_fecha_destino As New DataGridViewTextBoxColumn
            With col_fecha_destino
                .Name = "fecha_destino" : .DataPropertyName = "fecha_destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha " & NombreEstadoCarga(intDestino)
            End With
            x += +1
            Dim col_origen As New DataGridViewTextBoxColumn
            With col_origen
                .Name = "origen" : .DataPropertyName = "origen"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Origen"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .Name = "destino" : .DataPropertyName = "destino"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Destino"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Comprobante"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_documento As New DataGridViewTextBoxColumn
            With col_documento
                .Name = "documento" : .DataPropertyName = "documento"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Comprobante"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_envio As New DataGridViewTextBoxColumn
            With col_envio
                .Name = "envio" : .DataPropertyName = "envio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado Envío"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            End With
            x += +1
            Dim col_dia As New DataGridViewTextBoxColumn
            With col_dia
                .Name = "dia" : .DataPropertyName = "dia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Día" : .DefaultCellStyle.Format = "0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight : .Visible = False
            End With
            x += +1
            Dim col_hora As New DataGridViewTextBoxColumn
            With col_hora
                .Name = "hora" : .DataPropertyName = "hora"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Hora" : .DefaultCellStyle.Format = "0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight : .Visible = False
            End With
            x += +1
            Dim col_minuto As New DataGridViewTextBoxColumn
            With col_minuto
                .Name = "minuto" : .DataPropertyName = "minuto"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Minuto" : .DefaultCellStyle.Format = "0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight : .Visible = False
            End With
            x += +1
            Dim col_segundo As New DataGridViewTextBoxColumn
            With col_segundo
                .Name = "segundo" : .DataPropertyName = "segundo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Segundo" : .DefaultCellStyle.Format = "0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight : .Visible = False
            End With
            x += +1
            Dim col_tiempo As New DataGridViewTextBoxColumn
            With col_tiempo
                .Name = "tiempo" : .DataPropertyName = "tiempo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tiempo" : .DefaultCellStyle.Format = "#,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
            x += +1
            Dim col_totalenvios As New DataGridViewTextBoxColumn
            With col_totalenvios
                .Name = "totalenvios" : .DataPropertyName = "totalenvios"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Envios" : .DefaultCellStyle.Format = "#,###,###0"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            End With
            x += +1
            Dim col_promedio As New DataGridViewTextBoxColumn
            With col_promedio
                .Name = "promedio" : .DataPropertyName = "promedio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Promedio" : .DefaultCellStyle.Format = "#,###,###0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight ': Visible = False
            End With
            .Columns.AddRange(col_registro, col_fecha, col_fecha_destino, col_origen, col_destino, col_tipo, col_documento, col_envio, col_dia, col_hora, col_minuto, col_segundo, col_tiempo, col_totalenvios, col_promedio)
        End With
    End Sub
    Public Sub Cargar(ByVal fecha As String, ByVal usuario As Integer, ByVal ip As String, ByVal TotalEnvios As Integer, ByVal origen As Integer, ByVal destino As Integer, ByVal todo As Integer)
        strFecha = fecha
        intUsuario = usuario
        strIp = ip
        intTotalEnvios = TotalEnvios
        intOrigen = origen
        intDestino = destino
        intTodo = todo
    End Sub

    Public Sub Cargar(estado As Integer, usuario As Integer, ip As String)
        intEstado = estado
        intUsuario = usuario
        strIp = ip
    End Sub

    Private Sub frmNivelServicioDetalle_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmNivelServicioDetalle_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Dim obj As New dtoCarga
            If intOpcion = 0 Then
                Dim dt As DataTable = obj.ListarNivelServicioDetalle(strFecha, intUsuario, strIp, intTotalEnvios, intTodo)
                Me.dgvNivelServicioDetalle.DataSource = dt

                Dim dblTiempo As Double = IIf(IsDBNull(dt.Compute("sum(tiempo)", "")), 0, dt.Compute("sum(tiempo)", ""))
                Me.lblTiempo.Text = dblTiempo.ToString("#,###,###0.00")

                Dim dblTotalEnvios As Double = intTotalEnvios
                Me.lblEnvios.Text = dblTotalEnvios.ToString("#,###,###0")

                Dim dblPromedio As Double = IIf(IsDBNull(dt.Compute("sum(promedio)", "")), 0, dt.Compute("sum(promedio)", ""))
                Me.lblPromedio.Text = dblPromedio.ToString("#,###,###0.00")
                Me.ConfigurarDGV()
            Else
                Dim dt As DataTable = obj.ListarInconsistencia(intEstado, intUsuario, strIp)
                Me.dgvNivelServicioDetalle.DataSource = dt
                Me.grbResultado.Visible = False
                Me.Text = Me.Text & "-Inconsistencias"
                Me.ConfigurarDGV2()
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Nivel de Servicio", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Close()
    End Sub

    Private Sub dgvNivelServicioDetalle_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvNivelServicioDetalle.DoubleClick
        Try
            If Me.dgvNivelServicioDetalle.Rows.Count > 0 Then
                Me.Cursor = Cursors.AppStarting
                Dim frm As New FrmConsultaGeneral2
                frm.ControlBox = True
                frm.intLlamada = 1
                frm.Text = "Consulta x Documento(s)"
                'frm.txtDocumento.Text = Me.dgvNivelServicioDetalle.CurrentRow.Cells("documento").Value
                frm.strDocumento = Me.dgvNivelServicioDetalle.CurrentRow.Cells("documento").Value
                Dim obj As KeyPressEventArgs
                obj = New KeyPressEventArgs(Chr(13))
                'frm.txtDocumento_KeyPress(Nothing, obj)
                frm.ShowDialog()
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Nivel de Servicio", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class