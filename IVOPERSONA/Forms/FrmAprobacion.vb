Public Class FrmAprobacionLineaCredito
    Dim sName As String = ""
    Dim dt As DataTable
    Dim iEstado2 As Integer
    Dim iEstado As Integer
    Dim sCodigo As String = ""
    Dim sObservaciones As String = ""
    Dim iMontoPreAprobado As Double = 0
    Private iId As Integer
    Dim bIngreso As Boolean = False
    Dim iSobregiro As Double = 0
    Public hnd As Long

    Sub FormatoDgv()
        With dgv
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            .DefaultCellStyle.SelectionForeColor = Color.Black

            Dim idsolicitud_credito As New DataGridViewTextBoxColumn
            With idsolicitud_credito
                .HeaderText = "Id"
                .Name = "idsolicitud_credito"
                .DataPropertyName = "idsolicitud_credito"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim nro_solicitud As New DataGridViewTextBoxColumn
            With nro_solicitud
                .HeaderText = "Nº"
                .Name = "nro_solicitud"
                .DataPropertyName = "nro_solicitud"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
            End With

            Dim fecha As New DataGridViewTextBoxColumn
            With fecha
                .HeaderText = "Fecha"
                .Name = "fecha"
                .DataPropertyName = "fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
            End With

            Dim fecha_pre_aprobacion As New DataGridViewTextBoxColumn
            With fecha_pre_aprobacion
                .HeaderText = "Fecha Pre Apro"
                .Name = "fecha_pre_aprobacion"
                .DataPropertyName = "fecha_pre_aprobacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim fecha_aprobacion As New DataGridViewTextBoxColumn
            With fecha_aprobacion
                .HeaderText = "Fecha Apro"
                .Name = "fecha_aprobacion"
                .DataPropertyName = "fecha_aprobacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim fecha_rechazo_pre_aprobacion As New DataGridViewTextBoxColumn
            With fecha_rechazo_pre_aprobacion
                .HeaderText = "Fecha Rech Pre Apro"
                .Name = "fecha_rechazo_pre_aprobacion"
                .DataPropertyName = "fecha_rechazo_pre_aprobacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim fecha_rechazo_aprobacion As New DataGridViewTextBoxColumn
            With fecha_rechazo_aprobacion
                .HeaderText = "Fecha Rech Apro"
                .Name = "fecha_rechazo_aprobacion"
                .DataPropertyName = "fecha_rechazo_aprobacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim codigo_persona As New DataGridViewTextBoxColumn
            With codigo_persona
                .HeaderText = "Código"
                .Name = "codigo_persona"
                .DataPropertyName = "codigo_persona"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
            End With

            Dim nombre_persona As New DataGridViewTextBoxColumn
            With nombre_persona
                .HeaderText = "Cliente"
                .Name = "nombre_persona"
                .DataPropertyName = "nombre_persona"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim monto_solicitado As New DataGridViewTextBoxColumn
            With monto_solicitado
                .HeaderText = "Monto Solicitado"
                .Name = "monto_solicitado"
                .DataPropertyName = "monto_solicitado"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
            End With

            Dim monto_pre_aprobado As New DataGridViewTextBoxColumn
            With monto_pre_aprobado
                .HeaderText = "Monto Pre Aprobado"
                .Name = "monto_pre_aprobado"
                .DataPropertyName = "monto_pre_aprobado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
                .Visible = False
            End With

            Dim estado As New DataGridViewTextBoxColumn
            With estado
                .HeaderText = "Estado"
                .Name = "estado"
                .DataPropertyName = "estado"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .Visible = False
            End With

            Dim periodo_pago As New DataGridViewTextBoxColumn
            With periodo_pago
                .HeaderText = "Condición"
                .Name = "periodo_pago"
                .DataPropertyName = "periodo_pago"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .Visible = False
            End With

            Dim dia_pago As New DataGridViewTextBoxColumn
            With dia_pago
                .HeaderText = "Día Pago"
                .Name = "dia_pago"
                .DataPropertyName = "dia_pago"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .Visible = False
            End With

            Dim fecha1 As New DataGridViewTextBoxColumn
            With fecha1
                .HeaderText = "Fecha1"
                .Name = "fecha1"
                .DataPropertyName = "fecha1"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .Visible = False
            End With

            Dim fecha2 As New DataGridViewTextBoxColumn
            With fecha2
                .HeaderText = "Fecha2"
                .Name = "fecha2"
                .DataPropertyName = "fecha2"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .Visible = False
            End With

            Dim fecha3 As New DataGridViewTextBoxColumn
            With fecha3
                .HeaderText = "Fecha3"
                .Name = "fecha3"
                .DataPropertyName = "fecha3"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .Visible = False
            End With

            Dim fecha4 As New DataGridViewTextBoxColumn
            With fecha4
                .HeaderText = "Fecha4"
                .Name = "fecha4"
                .DataPropertyName = "fecha4"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .Visible = False
            End With

            Dim horario_pago_ini As New DataGridViewTextBoxColumn
            With horario_pago_ini
                .HeaderText = "Hora Pago Inicio"
                .Name = "horario_pago_ini"
                .DataPropertyName = "horario_pago_ini"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .Visible = False
            End With

            Dim horario_pago_fin As New DataGridViewTextBoxColumn
            With horario_pago_fin
                .HeaderText = "Hora Pago Fin"
                .Name = "horario_pago_fin"
                .DataPropertyName = "horario_pago_fin"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .Visible = False
            End With

            Dim tipo_pago As New DataGridViewTextBoxColumn
            With tipo_pago
                .HeaderText = "Tipo Pago"
                .Name = "tipo_pago"
                .DataPropertyName = "tipo_pago"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .Visible = False
            End With

            Dim linea_solicitada As New DataGridViewTextBoxColumn
            With linea_solicitada
                .HeaderText = "Monto Aprobado"
                .Name = "linea_solicitada"
                .DataPropertyName = "linea_solicitada"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
                .Visible = False
            End With

            Dim sobregiro As New DataGridViewTextBoxColumn
            With sobregiro
                .HeaderText = "Sobregiro Aprobado"
                .Name = "sobregiro"
                .DataPropertyName = "sobregiro"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
                .Visible = False
            End With

            Dim total_asignado As New DataGridViewTextBoxColumn
            With total_asignado
                .HeaderText = "Línea Final Aprobada"
                .Name = "total_asignado"
                .DataPropertyName = "total_asignado"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
                .Visible = False
            End With

            Dim porcentaje_sobregiro As New DataGridViewTextBoxColumn
            With porcentaje_sobregiro
                .HeaderText = "Porcentaje Sobregiro"
                .Name = "porcentaje_sobregiro"
                .DataPropertyName = "porcentaje_sobregiro"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .DefaultCellStyle.Format = "N2"
                .ReadOnly = True
                .Visible = False
            End With

            Dim dia1 As New DataGridViewTextBoxColumn
            With dia1
                .HeaderText = "Lunes"
                .Name = "dia1"
                .DataPropertyName = "dia1"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With
            Dim dia2 As New DataGridViewTextBoxColumn
            With dia2
                .HeaderText = "Martes"
                .Name = "dia2"
                .DataPropertyName = "dia2"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With
            Dim dia3 As New DataGridViewTextBoxColumn
            With dia3
                .HeaderText = "Miércoles"
                .Name = "dia3"
                .DataPropertyName = "dia3"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With
            Dim dia4 As New DataGridViewTextBoxColumn
            With dia4
                .HeaderText = "Jueves"
                .Name = "dia4"
                .DataPropertyName = "dia4"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With
            Dim dia5 As New DataGridViewTextBoxColumn
            With dia5
                .HeaderText = "Viernes"
                .Name = "dia5"
                .DataPropertyName = "dia5"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With
            Dim dia6 As New DataGridViewTextBoxColumn
            With dia6
                .HeaderText = "Sábado"
                .Name = "dia6"
                .DataPropertyName = "dia6"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With
            Dim dia7 As New DataGridViewTextBoxColumn
            With dia7
                .HeaderText = "Domingo"
                .Name = "dia7"
                .DataPropertyName = "dia7"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim idusuario_personal As New DataGridViewTextBoxColumn
            With idusuario_personal
                .HeaderText = "Usuario Solicitud de Crédito"
                .Name = "idusuario_personal"
                .DataPropertyName = "idusuario_personal"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With
            Dim idusuario_personalmod As New DataGridViewTextBoxColumn
            With idusuario_personalmod
                .HeaderText = "Usuario Modificación Solicitud de Crédito"
                .Name = "idusuario_personalmod"
                .DataPropertyName = "idusuario_personalmod"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With
            Dim usuario_pre_aprobacion As New DataGridViewTextBoxColumn
            With usuario_pre_aprobacion
                .HeaderText = "Usuario Pre Aprobación"
                .Name = "usuario_pre_aprobacion"
                .DataPropertyName = "usuario_pre_aprobacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With
            Dim usuario_aprobacion As New DataGridViewTextBoxColumn
            With usuario_aprobacion
                .HeaderText = "Usuario Aprobación"
                .Name = "usuario_aprobacion"
                .DataPropertyName = "usuario_aprobacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With
            Dim usuario_rechazo_pre_aprobacion As New DataGridViewTextBoxColumn
            With usuario_rechazo_pre_aprobacion
                .HeaderText = "Usuario Rechazo Pre Aprobación"
                .Name = "usuario_rechazo_pre_aprobacion"
                .DataPropertyName = "usuario_rechazo_pre_aprobacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With
            Dim usuario_rechazo_aprobacion As New DataGridViewTextBoxColumn
            With usuario_rechazo_aprobacion
                .HeaderText = "Usuario Rechazo Aprobación"
                .Name = "usuario_rechazo_aprobacion"
                .DataPropertyName = "usuario_rechazo_aprobacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With
            Dim usuario_desactivacion As New DataGridViewTextBoxColumn
            With usuario_desactivacion
                .HeaderText = "Usuario Desactivación"
                .Name = "usuario_desactivacion"
                .DataPropertyName = "usuario_desactivacion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim funcionario As New DataGridViewTextBoxColumn
            With funcionario
                .HeaderText = "Funcionario"
                .Name = "funcionario"
                .DataPropertyName = "funcionario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim cliente As New DataGridViewTextBoxColumn
            With cliente
                .HeaderText = "Cliente"
                .Name = "cliente"
                .DataPropertyName = "cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Visible = False
            End With

            .Columns.AddRange(idsolicitud_credito, nro_solicitud, fecha, fecha_pre_aprobacion, fecha_aprobacion, _
            fecha_rechazo_pre_aprobacion, fecha_rechazo_aprobacion, codigo_persona, nombre_persona, monto_solicitado, monto_pre_aprobado, estado, _
            periodo_pago, dia_pago, fecha1, fecha2, fecha3, fecha4, horario_pago_ini, horario_pago_fin, tipo_pago, _
            linea_solicitada, sobregiro, total_asignado, porcentaje_sobregiro, dia1, dia2, dia3, dia4, dia5, dia6, dia7, _
            idusuario_personal, idusuario_personalmod, usuario_pre_aprobacion, usuario_aprobacion, usuario_rechazo_pre_aprobacion, _
            usuario_rechazo_aprobacion, usuario_desactivacion, funcionario, cliente)
        End With
    End Sub

    Private Sub FrmAprobacionLineaCredito_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmAprobacionLineaCredito_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmAprobacionLineaCredito_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.FormatoDgv()

        bIngreso = False
        Dim dt1 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
        Acceso.AplicaConfiguracion(dt1, Me)
        bIngreso = True

        Me.RbtPreaprobar.Checked = True
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        Dim sSustento As String = ""
        iEstado = sName
        If iEstado = 2 Then
            If Me.RbtSi.Checked Then
                If Val(Me.TxtMontoOtorgado.Text) = 0 Then
                    MessageBox.Show("Debe Ingresar Monto Otorgado.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtMontoOtorgado.Text = ""
                    Me.TxtMontoOtorgado.Focus()
                    Return
                End If
                If CDbl(Me.TxtMontoOtorgado.Text) <> CDbl(Me.LblMontoPreaprobado.Text) Then
                    Dim frm As New FrmObservacion
                    If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                        sSustento = frm.TxtObservaciones.Text.Trim
                    Else
                        sObservaciones = ""
                        sSustento = ""
                        Return
                    End If
                End If
            End If
        ElseIf iEstado = 1 Then
            If Me.RbtSi.Checked Then
                If Val(Me.TxtMontoPreAprobado.Text) = 0 Then
                    MessageBox.Show("Debe Ingresar Monto Pre Aprobado.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.TxtMontoPreAprobado.Text = ""
                    Me.TxtMontoPreAprobado.Focus()
                    Return
                End If
            End If
        End If

        If Me.RbtNo.Checked Then
            If Me.TxtObservacion.Text.Trim.Length = 0 Then
                MessageBox.Show("Debe Ingresar Descripción del Rechazo.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtObservacion.Text = ""
                Me.TxtObservacion.Focus()
                Return
            End If
        End If

        iId = Me.dgv.CurrentRow.Cells("idsolicitud_credito").Value
        If iEstado = 1 Then
            iEstado2 = 2
        ElseIf iEstado = 2 Then
            iEstado2 = 3
        End If

        Dim sAprobar As String
        If Me.RbtSi.Checked Then
            sAprobar = Me.LblAprobar.Text
            sObservaciones = ""
            If sSustento.Trim.Length > 0 Then
                sObservaciones = sSustento
            End If
            If Me.Panel4.Visible Then
                iMontoPreAprobado = CDbl(Me.TxtMontoPreAprobado.Text)
            Else
                iMontoPreAprobado = CDbl(Me.LblMontoPreaprobado.Text)
            End If
        Else
            sAprobar = "Rechazar"
            If iEstado = 1 Then
                iEstado2 = 4
            ElseIf iEstado = 2 Then
                iEstado2 = 5
            End If
            sObservaciones = Me.TxtObservacion.Text.Trim
        End If

        Dim iRespuesta As DialogResult
        iRespuesta = MessageBox.Show("¿Está Seguro de " & sAprobar & " la Solicitud?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If iRespuesta = Windows.Forms.DialogResult.Yes Then
            Aceptar()
        End If
    End Sub

    Private Sub RbtSi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtSi.CheckedChanged
        Me.TxtObservacion.Enabled = False
        Me.TxtObservacion.Text = ""
        If sName = "1" Or sName = "" Then
            Me.BtnAceptar.Text = "&Pre Aprobar"
        ElseIf sName = "2" Then
            Me.BtnAceptar.Text = "&Aprobar"
        End If
        Me.TxtObservacion.Focus()
    End Sub

    Private Sub RbtNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtNo.CheckedChanged
        Me.TxtObservacion.Enabled = True
        Me.BtnAceptar.Text = "&Rechazar"
        Me.TxtObservacion.Focus()
    End Sub

    Private Sub TxtMontoOtorgado_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMontoOtorgado.Enter
        Dim iValor As Double = 0
        If Me.TxtMontoOtorgado.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.TxtMontoOtorgado.Text
        End If
        Me.TxtMontoOtorgado.Text = Format(CDbl(iValor), "########0.00")
    End Sub

    Private Sub TxtMontoOtorgado_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMontoOtorgado.GotFocus
        TxtMontoOtorgado.SelectAll()
    End Sub

    Private Sub TxtMontoOtorgado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMontoOtorgado.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.ChkSobregiro.Focus()
        Else
            If Not (sName = "1" Or sName = "2") Then
                e.Handled = True
            Else
                e.Handled = Numero(e, TxtMontoOtorgado)
            End If
        End If
    End Sub

    Private Sub TxtSobregiro_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSobregiro.Enter
        'Me.TxtSobregiro.SelectAll()
    End Sub

    Private Sub TxtSobregiro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSobregiro.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.BtnAceptar.Focus()
        End If
    End Sub

    Private Sub TxtMontoOtorgado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMontoOtorgado.LostFocus
        Dim iValor As Double = 0
        If Me.TxtMontoOtorgado.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.TxtMontoOtorgado.Text
        End If
        Me.TxtMontoOtorgado.Text = Format(CDbl(iValor), "##,###,###0.00")
    End Sub

    Sub Aceptar()
        Try
            Dim obj As New dtoAprobacion
            If Me.RbtSi.Checked AndAlso iEstado = 2 Then 'Generar Línea de Crédito
                With obj
                    .Control = 1
                    .CodigoPersona = sCodigo
                    .IDConfigCtaCte = 0 'IIf(Len(Trim(Me.txtIDAprobacion.Text)) = 0, 0, Me.txtIDAprobacion.Text) '1 'Momentaneamente
                    .NumeroControl = sCodigo
                    .LineaOtorgada = CType(Me.LblMontoAprobado.Text, Double)
                    .SobreGiro = CType(Me.LblSobregiroAprobado.Text, Double)
                    .TotalAsignado = CType(Me.LblLineaFinalAprobada.Text, Double)
                    .EstadoRegistro = 1
                    .ID_SOLICITUD_CREDITO = iId
                    If Me.ChkSobregiro.Checked Then
                        .PORCENTAJE_SOBREGIRO = Me.TxtSobregiro.Text
                    Else
                        .PORCENTAJE_SOBREGIRO = 0
                    End If
                    .UsuarioPersonal = dtoUSUARIOS.IdLogin
                    .IDRolUsuario = dtoUSUARIOS.m_iIdRol
                    .IP = dtoUSUARIOS.IP
                End With

                Dim dt As DataTable = obj.GrabaAprobacion
            End If

            obj.Aprobar(iId, iEstado2, iMontoPreAprobado, sObservaciones)
            'If sObservaciones.Trim.Length = 0 Then
            If Me.RbtSi.Checked Then
                MessageBox.Show("Solicitud " & IIf(iEstado = 1, "Pre Aprobada", "Aprobada"), "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Solicitud Rechazada", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.Tab.SelectedIndex = 0
            Me.LblCliente.Text = ""

            'Dim s As String = sName
            'Dim nodo As TreeNode() = tvw.Nodes.Find(IIf(s = 1, 2, 1), True)
            'tvw.SelectedNode = nodo(0)
            'nodo = tvw.Nodes.Find(s, True)
            'tvw.SelectedNode = nodo(0)
            Dim sender As New Object, e As New EventArgs
            Me.Eleccion(sName, sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgv_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.RowEnter
        With dgv
            If .Rows.Count > 0 Then
                Dim row As DataGridViewRow = .Rows(e.RowIndex)
                sCodigo = row.Cells("codigo_persona").Value
                iId = row.Cells("idsolicitud_credito").Value
                Me.LblCliente.Text = IIf(IsDBNull(row.Cells("nombre_persona").Value), "", row.Cells("nombre_persona").Value.ToString.ToUpper)

                Me.LblCondicion.Text = dtoAprobacion.CondicionPago(row.Cells("periodo_pago").Value)
                Dim s As String = ""
                If row.Cells("fecha1").Value > 0 Then
                    Me.LblPeriodo.Text = "Día de Mes"
                    If row.Cells("fecha1").Value > 1 Then
                        s &= row.Cells("fecha1").Value & ","
                    End If
                    If row.Cells("fecha2").Value > 1 Then
                        s &= row.Cells("fecha2").Value & ","
                    End If
                    If row.Cells("fecha3").Value > 1 Then
                        s &= row.Cells("fecha3").Value & ","
                    End If
                    If row.Cells("fecha4").Value > 1 Then
                        s &= row.Cells("fecha4").Value & ","
                    End If
                Else
                    Me.LblPeriodo.Text = "Día de Semana"
                    If row.Cells("dia1").Value = 1 Then
                        s &= "Lunes,"
                    End If
                    If row.Cells("dia2").Value = 1 Then
                        s &= "Martes,"
                    End If
                    If row.Cells("dia3").Value = 1 Then
                        s &= "Miércoles,"
                    End If
                    If row.Cells("dia4").Value = 1 Then
                        s &= "Jueves,"
                    End If
                    If row.Cells("dia5").Value = 1 Then
                        s &= "Viernes,"
                    End If
                    If row.Cells("dia6").Value = 1 Then
                        s &= "Sábado,"
                    End If
                    If row.Cells("dia7").Value = 1 Then
                        s &= "Domingo,"
                    End If
                End If
                If s.Trim.Length > 0 Then
                    s = s.Trim.Substring(0, s.Trim.Length - 1)
                End If
                Me.LblDia.Text = s

                If IsDBNull(row.Cells("horario_pago_ini").Value) Or IsDBNull(row.Cells("horario_pago_fin").Value) Then
                    Me.LblInicio.Text = ""
                    Me.LblFin.Text = ""
                Else
                    Me.LblInicio.Text = row.Cells("horario_pago_ini").Value
                    Me.LblFin.Text = row.Cells("horario_pago_fin").Value
                End If

                Me.LblMontoSolicitado.Text = Format(row.Cells("monto_solicitado").Value, "#,###,###,###0.00")
                Me.LblMontoPreaprobado.Text = Format(row.Cells("monto_pre_aprobado").Value, "#,###,###,###0.00")

                Me.LblMontoSolicitado2.Text = Format(row.Cells("monto_solicitado").Value, "#,###,###,###0.00")
                Me.TxtMontoPreAprobado.Text = Format(row.Cells("monto_solicitado").Value, "#,###,###,###0.00")

                Me.TxtMontoOtorgado.Text = Format(row.Cells("linea_solicitada").Value, "#,###,###,###0.00")

                If Val(Me.TxtMontoOtorgado.Text) = 0 Then
                    Me.TxtMontoOtorgado.Text = ""
                End If

                If Val(Me.TxtMontoPreAprobado.Text) = 0 Then
                    Me.TxtMontoPreAprobado.Text = ""
                End If

                Me.LblUsuario.Text = ""
                Me.LblUsuario2.Text = ""
                iSobregiro = 10
                Me.ChkSobregiro.Checked = True
                If sName = "1" Then
                    Me.LblUsuario.Text = IIf(IsDBNull(row.Cells("idusuario_personal").Value), "", row.Cells("idusuario_personal").Value)
                    Me.LblUsuario2.Text = "Usuario Solicitud Línea de Crédito"
                ElseIf sName = "2" Then
                    Me.LblUsuario.Text = IIf(IsDBNull(row.Cells("usuario_pre_aprobacion").Value), "", row.Cells("usuario_pre_aprobacion").Value)
                    Me.LblUsuario2.Text = "Usuario Pre Aprobación"
                ElseIf sName = "3" Then
                    Me.LblUsuario.Text = IIf(IsDBNull(row.Cells("usuario_aprobacion").Value), "", row.Cells("usuario_aprobacion").Value)
                    Me.LblUsuario2.Text = "Usuario Aprobación"
                    If row.Cells("sobregiro").Value = 0 Then
                        iSobregiro = 0
                        Me.ChkSobregiro.Checked = False
                    End If
                End If
            Else
                Me.LblCliente.Text = ""
            End If
        End With
    End Sub

    Sub ActivarDesactivar(ByVal estado As Integer)
        With dgv
            If estado = 1 Then
                .Columns("fecha_pre_aprobacion").Visible = False
                .Columns("fecha_aprobacion").Visible = False
                .Columns("fecha_rechazo_pre_aprobacion").Visible = False
                .Columns("fecha_rechazo_aprobacion").Visible = False
                .Columns("monto_pre_aprobado").Visible = False
            ElseIf estado = 2 Then
                .Columns("fecha_pre_aprobacion").Visible = True
                .Columns("fecha_aprobacion").Visible = False
                .Columns("fecha_rechazo_pre_aprobacion").Visible = False
                .Columns("fecha_rechazo_aprobacion").Visible = False
                .Columns("monto_pre_aprobado").Visible = True
            ElseIf estado = 3 Then
                .Columns("fecha_pre_aprobacion").Visible = True
                .Columns("fecha_aprobacion").Visible = True
                .Columns("fecha_rechazo_pre_aprobacion").Visible = False
                .Columns("fecha_rechazo_aprobacion").Visible = False
                .Columns("monto_pre_aprobado").Visible = True
            End If
        End With
    End Sub

    Private Sub TxtMontoPreAprobado_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMontoPreAprobado.Enter
        Dim iValor As Double = 0
        If Me.TxtMontoPreAprobado.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.TxtMontoPreAprobado.Text
        End If
        Me.TxtMontoPreAprobado.Text = Format(CDbl(iValor), "########0.00")
    End Sub

    Private Sub TxtSobregiro_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSobregiro.LostFocus
        'Me.TxtSobregiro.Text = Me.TxtSobregiro.Text
    End Sub

    Private Sub TxtMontoPreAprobado_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMontoPreAprobado.GotFocus
        Me.TxtMontoPreAprobado.SelectAll()
    End Sub

    Private Sub TxtMontoPreAprobado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMontoPreAprobado.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.BtnAceptar.Focus()
        Else
            e.Handled = Numero(e, TxtMontoPreAprobado)
        End If
    End Sub

    Private Sub TxtMontoPreAprobado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMontoPreAprobado.LostFocus
        Dim iValor As Double = 0
        If Me.TxtMontoPreAprobado.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.TxtMontoPreAprobado.Text
        End If
        Me.TxtMontoPreAprobado.Text = Format(CDbl(iValor), "##,###,###0.00")
    End Sub

    Private Sub ChkSobregiro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkSobregiro.Click

    End Sub

    Private Sub ChkSobregiro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ChkSobregiro.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.BtnAceptar.Focus()
        End If
    End Sub

    Private Sub RbtPreaprobar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtPreaprobar.CheckedChanged, RbtAprobar.CheckedChanged, RbtAprobadas.CheckedChanged, RbtRechazadas.CheckedChanged
        Me.LblCliente.Text = ""
        Dim i As Integer = CType(sender, RadioButton).Tag
        Me.Eleccion(i, sender, e)

        If i = 1 Then
            If Not (Me.BtnAceptar.Tag Is Nothing) Then
                If Me.BtnAceptar.Tag = 0 Then
                    Me.BtnAceptar.Enabled = False
                Else
                    Me.BtnAceptar.Enabled = True
                End If
            Else
                Me.BtnAceptar.Enabled = True
            End If

        ElseIf i = 2 Then
            If Not (Me.BtnAceptar2.Tag Is Nothing) Then
                If Me.BtnAceptar2.Tag = 0 Then
                    Me.BtnAceptar.Enabled = False
                Else
                    Me.BtnAceptar.Enabled = True
                End If
            Else
                Me.BtnAceptar.Enabled = True
            End If

        End If
        Me.BtnAceptar2.Visible = False
    End Sub

    Sub Eleccion(ByVal i As Integer, ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.AppStarting

        tool.Items("tsbdesactivar").Visible = False
        tool.Items("tsbhistorial").Visible = False
        Me.Tab.Controls.Remove(Tab2)
        sName = i
        If i > 0 Then
            Dim obj As New dtoAprobacion
            If Acceso.SiRol(G_Rol, Me, 1) Then
                dt = obj.Solicitud(i)
            Else
                dt = obj.Solicitud(i, dtoUSUARIOS.IdLogin)
            End If
            dgv.DataSource = dt

            If sName = 1 Then
                Me.Flow1.Visible = False
                If Me.dgv.Rows.Count > 0 Then
                    Me.Tab.Controls.Add(Tab2)
                Else
                    Me.Tab.Controls.Remove(Tab2)
                End If
                Me.LblAprobar.Text = "Pre Aprobar"
                Me.Tab2.Text = "Pre Aprobar"
                Me.BtnAceptar.Text = "&Pre Aprobar"
                Panel2.Visible = False
                Panel4.Visible = True
                Panel4.Top = Panel2.Top
                Panel1.Visible = True
            ElseIf sName = 2 Then
                Me.Flow1.Visible = False
                If Me.dgv.Rows.Count > 0 Then
                    Me.Tab.Controls.Add(Tab2)
                Else
                    Me.Tab.Controls.Remove(Tab2)
                End If
                Me.LblAprobar.Text = "Aprobar"
                Me.Tab2.Text = "Aprobar"
                Me.BtnAceptar.Text = "&Aprobar"
                Panel2.Visible = True
                Panel4.Visible = False

                Panel1.Visible = True
            ElseIf sName = 4 Then
                Me.Flow1.Visible = True

                Me.CboDato.Items.Clear()
                Me.CboDato.Items.Add("Pre Aprobación")
                Me.CboDato.Items.Add("Aprobación")
                Me.CboDato.SelectedIndex = 0
            Else
                Me.Flow1.Visible = False
            End If
            If sName = 3 Then
                Panel2.Visible = True
                Panel4.Visible = False
                If Me.dgv.Rows.Count > 0 Then
                    Me.Tab.Controls.Add(Tab2)
                    tool.Items("tsbdesactivar").Visible = True
                    Me.Tab2.Text = "Detalle"
                    Panel1.Visible = False
                    Me.dgv.Columns("linea_solicitada").Visible = True
                    Me.dgv.Columns("sobregiro").Visible = True
                    Me.dgv.Columns("total_asignado").Visible = True
                Else
                    Me.Tab.Controls.Remove(Tab2)
                End If
            Else
                Me.dgv.Columns("linea_solicitada").Visible = False
                Me.dgv.Columns("sobregiro").Visible = False
                Me.dgv.Columns("total_asignado").Visible = False
            End If

            ActivarDesactivar(sName)
        Else
            dgv.DataSource = Nothing
            sName = ""
        End If

        If sName = 1 Or sName = 2 Then
            If Me.dgv.Rows.Count = 0 Then
                tool.Items("tsbhistorial").Visible = False
            Else
                tool.Items("tsbhistorial").Visible = True
            End If
        Else
            tool.Items("tsbhistorial").Visible = False
        End If

        If i = 4 Then
            'Me.dgv.Top = 53
            Me.Flow1.Visible = True
            Me.Flow2.Visible = True
        Else
            'Me.dgv.Top = 10
            Me.Flow1.Visible = False
            Me.Flow2.Visible = False
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Tab_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tab.SelectedIndexChanged
        If Tab.SelectedIndex = 1 Then
            Me.Cursor = Cursors.AppStarting
            If sName = 2 Then
                Me.TxtMontoOtorgado.Focus()
            Else
                Me.BtnAceptar.Focus()
            End If
            Me.TxtObservacion.Text = ""
            Me.RbtSi.Checked = True
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub dgv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv.DoubleClick
        If Me.dgv.Rows.Count > 0 Then
            Tab.SelectedIndex = 1
            Me.Tab_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub CboDato_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDato.SelectedIndexChanged, DtpInicio.ValueChanged, DtpFin.ValueChanged
        Dim iOpcion As Integer = IIf(Me.CboDato.SelectedIndex = 0, 4, 5)
        Dim sIni As String = Me.DtpInicio.Value.Date.ToShortDateString
        Dim sFin As String = Me.DtpFin.Value.Date.ToShortDateString
        Dim dv As DataView = dt.DefaultView

        If iOpcion = 4 Then
            dv.RowFilter = "estado=" & iOpcion & " and fecha_rechazo_pre_aprobacion>='" & sIni & "' and fecha_rechazo_pre_aprobacion<='" & sFin & "'"
        Else
            dv.RowFilter = "estado=" & iOpcion & " and fecha_rechazo_aprobacion>='" & sIni & "' and fecha_rechazo_aprobacion<='" & sFin & "'"
        End If
        dgv.DataSource = dv

        With dgv
            If iOpcion = 4 Then
                .Columns("fecha_pre_aprobacion").Visible = False
                .Columns("fecha_aprobacion").Visible = False
                .Columns("fecha_rechazo_pre_aprobacion").Visible = True
                .Columns("fecha_rechazo_aprobacion").Visible = False
                .Columns("monto_pre_aprobado").Visible = False
            ElseIf iOpcion = 5 Then
                .Columns("fecha_pre_aprobacion").Visible = False
                .Columns("fecha_aprobacion").Visible = False
                .Columns("fecha_rechazo_pre_aprobacion").Visible = False
                .Columns("fecha_rechazo_aprobacion").Visible = True
                .Columns("monto_pre_aprobado").Visible = True
            End If
        End With

        If dgv.Rows.Count > 0 Then
            tool.Items("tsbhistorial").Visible = True
        Else
            tool.Items("tsbhistorial").Visible = False
        End If
    End Sub

    Private Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles BtnAceptar.EnabledChanged
        If bIngreso Then
            'Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Sub Desactivar(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim obj As New dtoAprobacion
            Dim id As Integer = Me.dgv.CurrentRow.Cells("cliente").Value

            obj.DesactivarCtaCte(id, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IdRol, dtoUSUARIOS.IP)
            MessageBox.Show("La Línea de Crédito ha sido Desactivada.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Eleccion(3, sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbSalir.Click
        Close()
    End Sub

    Private Sub TsbDesactivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbDesactivar.Click
        Dim resultado As DialogResult = MessageBox.Show("¿Está Seguro de Desactivar la Línea de Crédito?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If resultado = Windows.Forms.DialogResult.Yes Then
            Desactivar(sender, e)
        End If
    End Sub

    Private Sub TsbHistorial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsbHistorial.Click
        Dim frm As New FrmHistorialLineaCredito
        frm.Cliente = dgv.CurrentRow.Cells("cliente").Value
        frm.ShowDialog()
    End Sub

    Private Sub TxtMontoOtorgado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMontoOtorgado.TextChanged, ChkSobregiro.CheckedChanged
        Dim iMontoOtorgado As Double = 0
        Dim iMontoAprobado As Double = 0
        Dim iSobregiroAprobado As Double = 0

        Dim iLineaFinalAprobada As Double = 0

        iMontoOtorgado = CDbl(IIf(Me.TxtMontoOtorgado.Text.Trim.Length = 0, 0, Me.TxtMontoOtorgado.Text))
        iMontoAprobado = iMontoOtorgado

        If Me.ChkSobregiro.Checked Then
            iSobregiroAprobado = iMontoAprobado * (iSobregiro / 100)
        Else
            iSobregiroAprobado = 0
        End If

        iLineaFinalAprobada = iMontoAprobado + iSobregiroAprobado

        Me.LblMontoAprobado.Text = Format(iMontoAprobado, "#,###,###,###0.00")
        Me.LblSobregiroAprobado.Text = Format(iSobregiroAprobado, "#,###,###,###0.00")
        Me.LblLineaFinalAprobada.Text = Format(iLineaFinalAprobada, "#,###,###,###0.00")
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub TxtMontoPreAprobado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMontoPreAprobado.TextChanged

    End Sub
End Class
