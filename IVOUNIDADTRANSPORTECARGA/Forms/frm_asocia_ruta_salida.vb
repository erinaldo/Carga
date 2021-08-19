Public Class frm_asocia_ruta_salida
#Region "Publicas"

    Public pl_idunidad_origen As Long
    Public pl_idunidad_destino As Long
    Public pl_idnro_salida_vehiculo As Long
    Public pdt_origen As DataTable
    Public pdt_destino As DataTable

#End Region
#Region "Variables"
    Dim lobj_asocia_ciudad As New ClsLbTepsa.dto_asocia_ciudad_ruta
    Dim lb_no_lee As Boolean = True
    Public hnd As Long
#End Region
#Region "Adicionales"
    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize)
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            SendKeys.Send("{Tab}")
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
#End Region
#Region "Eventos"

    Private Sub frm_asocia_ruta_salida_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frm_asocia_ruta_salida_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frm_asocia_ruta_salida_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ldt_ciudad_asocia As New DataTable
        Dim ldv_ciudad_asocia As New DataView

        Dim ldv_ciudad_origen As New DataView
        Dim ldv_ciudad_destino As New DataView
        Dim ldt_escoge_ciudad As New DataTable

        Dim ls_mensaje As String
        Try
            'Recupera los destinos de la salida 
            Me.txt_nro_salida.Text = CType(pl_idnro_salida_vehiculo, String)
            '
            ldv_ciudad_origen = CargarCombo(Me.cmb_origen, pdt_origen, "nombre_unidad", "idunidad_agencia", pl_idunidad_origen)  ' Asocia a la ciudad origen 
            ldv_ciudad_destino = CargarCombo(Me.cmb_destino, pdt_destino, "nombre_unidad", "idunidad_agencia", pl_idunidad_destino)  ' Asocia a la ciudad destino
            '
            lobj_asocia_ciudad.idnro_salida = pl_idnro_salida_vehiculo
            'Datahelper
            ldt_ciudad_asocia = lobj_asocia_ciudad.sp_get_ciudad_asocia_salida()
            '
            If ldt_ciudad_asocia.Rows.Count < 1 Then
                ls_mensaje = "La ruta seleccionada no tiene destino intemedios y/o final"
                MsgBox(ls_mensaje, MsgBoxStyle.Information, "Asociar ciudad a la ruta del bus")
                Me.Close()
                Exit Sub
            End If
            '                       
            lb_no_lee = False
            ldv_ciudad_asocia = CargarCombo(Me.cmb_ruta_asociar, ldt_ciudad_asocia, "destino", "idunidad_agencia_destino", 0)  ' Asocia a la ciudad que está en ruta 
            'Datahelper 
            ldt_escoge_ciudad = lobj_asocia_ciudad.sp_get_escoje_ciudad_asocia()
            '
            CargarCombo(Me.cmb_asocia_ciudad, ldt_escoge_ciudad, "nombre_unidad", "idunidad_agencia", 0)  ' Asocia a la ciudad que está en ruta 
            lb_no_lee = True

            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub cmb_ruta_asociar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_ruta_asociar.SelectedIndexChanged
        Dim ldt_cidudad_asocia_ruta As New DataTable
        Dim ldt_escoge_ciudad As New DataTable
        Dim ll_ciudad_asocia_ruta As Long
        Try
            If lb_no_lee = True Then
                ll_ciudad_asocia_ruta = Me.cmb_ruta_asociar.SelectedValue
                '
                lobj_asocia_ciudad.idnro_salida = pl_idnro_salida_vehiculo
                lobj_asocia_ciudad.idciudad_ruta = ll_ciudad_asocia_ruta
                ''Datahelper
                ldt_cidudad_asocia_ruta = lobj_asocia_ciudad.sp_get_ciudad_asocia_ruta()
                grilla_ciudad_asocia()
                '
                dgv_asocia_ruta.DataSource = ldt_cidudad_asocia_ruta.DefaultView
                ' Cambia la seleccion de seleccionar las ciudades que va actualizar  
                recupera_ciudad_seleccionar()
                'lb_no_lee = False
                'ldt_escoge_ciudad = lobj_asocia_ciudad.sp_get_escoje_ciudad_asocia(cnn)                
                ''
                'ldv_view = CargarCombo(Me.cmb_asocia_ciudad, ldt_escoge_ciudad, "nombre_unidad", "idunidad_agencia", 0)  ' Asocia a la ciudad que está en ruta 
                'lb_no_lee = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub cmb_asocia_ciudad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_asocia_ciudad.SelectedIndexChanged
        Dim ls_mensaje As String
        Dim ll_fila, ll_ciudad_asocia, ll_idusuario As Long
        Dim ld_ciudad_asocia As DataView
        Dim lds_asocia_ciudad As DataSet
        Dim ldt_mensaje As DataTable
        Try
            '
            If lb_no_lee = True Then
                If Me.cmb_ruta_asociar.SelectedValue <= 0 Then ' Por no ha sido seleccionado a la ciudad que se va asociar 
                    ls_mensaje = "No ha sido seleccionado la ciudad a la que se va asociar el destino"
                    MsgBox(ls_mensaje, MsgBoxStyle.Information, "Asociar ciudad a la ruta del bus")
                    Me.cmb_ruta_asociar.Focus()
                    Me.cmb_asocia_ciudad.SelectedValue = 0
                    Exit Sub
                End If
                '
                If Me.cmb_asocia_ciudad.SelectedValue > 0 Then
                    For ll_fila = 0 To dgv_asocia_ruta.Rows.Count - 1
                        ll_ciudad_asocia = CType(dgv_asocia_ruta.Rows(ll_fila).Cells("idunidad_agencia_asocia").Value, Long)
                        If CType(Me.cmb_asocia_ciudad.SelectedValue, Long) = ll_ciudad_asocia Then
                            MsgBox("La ciudad ya ha sido asociada a esté nº de salida del bus", MsgBoxStyle.Information, "Asociar ciudad a la ruta del bus")
                            Me.cmb_asocia_ciudad.SelectedValue = 0
                            Exit Sub
                        End If
                    Next
                End If
                '
                ' Grabando la ciudad 
                '
                lb_no_lee = False
                ll_idusuario = CType(dtoUSUARIOS.IdLogin, Long)
                lobj_asocia_ciudad.idnro_salida = pl_idnro_salida_vehiculo
                lobj_asocia_ciudad.idciudad_ruta = Me.cmb_ruta_asociar.SelectedValue
                lobj_asocia_ciudad.idciudad_asocia = Me.cmb_asocia_ciudad.SelectedValue
                lobj_asocia_ciudad.idusuario_personal = ll_idusuario
                'Datahelper
                lds_asocia_ciudad = lobj_asocia_ciudad.sp_registra_ciudad_asocia()
                ldt_mensaje = lds_asocia_ciudad.Tables(0)
                '
                If ldt_mensaje.Rows(0).Item(0) = 0 Then  ' No ocurrio ningún error 
                    ls_mensaje = CType(ldt_mensaje.Rows(0).Item(1), String)
                    MsgBox(ls_mensaje, MsgBoxStyle.Information, "Asociar ciudad a la ruta del bus")
                    ld_ciudad_asocia = lds_asocia_ciudad.Tables(1).DefaultView
                    grilla_ciudad_asocia()
                    dgv_asocia_ruta.DataSource = ld_ciudad_asocia
                    recupera_ciudad_seleccionar()
                Else
                    ls_mensaje = CType(ldt_mensaje.Rows(0).Item(1), String)
                    MsgBox(ls_mensaje, MsgBoxStyle.Information, "Asociar ciudad a la ruta del bus")
                End If
                '                
                lb_no_lee = False
                Me.cmb_asocia_ciudad.SelectedValue = 0 ' Poniendo a su posición original 
                lb_no_lee = True
                '
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub dgv_asocia_ruta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv_asocia_ruta.KeyDown
        Try
            Dim dgrv_ciudad As DataGridViewRow
            Dim ll_idunidad_agencia As Long
            Dim ls_ciudad As String
            Dim ldt_mensaje As DataTable
            Dim lds_asocia_ciudad As DataSet
            Dim ls_mensaje As String
            Dim ld_ciudad_asocia As DataView
            dgrv_ciudad = Me.dgv_asocia_ruta.CurrentRow()
            '''''''''''''
            If e.KeyCode = Keys.Delete Then
                Dim iResp As Integer
                ls_ciudad = CType(dgrv_ciudad.Cells("ciudad").Value, String)
                iResp = MessageBox.Show("¿Está seguro de eliminar la ciudad " + ls_ciudad + "?", "Asociar ciudad a la ruta del bus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                '
                If iResp = vbNo Then Exit Sub
                '
                ll_idunidad_agencia = CType(dgrv_ciudad.Cells("idunidad_agencia_asocia").Value, Long)
                ' Eliminando la ciudad asociada 
                lobj_asocia_ciudad.idnro_salida = pl_idnro_salida_vehiculo
                lobj_asocia_ciudad.idciudad_ruta = Me.cmb_ruta_asociar.SelectedValue
                lobj_asocia_ciudad.idciudad_asocia = ll_idunidad_agencia
                'Datahelper
                lds_asocia_ciudad = lobj_asocia_ciudad.sp_elimina_ciudad_asocia()
                '
                ldt_mensaje = lds_asocia_ciudad.Tables(0)
                '
                If ldt_mensaje.Rows(0).Item(0) = 0 Then  ' No ocurrio ningún error 
                    ls_mensaje = CType(ldt_mensaje.Rows(0).Item(1), String)
                    MsgBox(ls_mensaje, MsgBoxStyle.Information, "Asociar ciudad a la ruta del bus")
                    ld_ciudad_asocia = lds_asocia_ciudad.Tables(1).DefaultView
                    grilla_ciudad_asocia()
                    dgv_asocia_ruta.DataSource = ld_ciudad_asocia
                    recupera_ciudad_seleccionar()
                Else
                    ls_mensaje = CType(ldt_mensaje.Rows(0).Item(1), String)
                    MsgBox(ls_mensaje, MsgBoxStyle.Information, "Asociar ciudad a la ruta del bus")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de seguridad")
        End Try
    End Sub

#End Region

#Region "Procedimientos"
    '
    Sub grilla_ciudad_asocia()
        dgv_asocia_ruta.Columns.Clear()
        '
        With dgv_asocia_ruta
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True            
            .ReadOnly = True            
        End With
        '
        Dim ciudad_asocia As New DataGridViewTextBoxColumn
        With ciudad_asocia
            .DataPropertyName = "ciudad"
            .Name = "ciudad"
            .HeaderText = "Ciudad Asocia"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ReadOnly = False
            .Width = 250
        End With
        dgv_asocia_ruta.Columns.Add(ciudad_asocia)
        '
        Dim idciudad_asocia As New DataGridViewTextBoxColumn
        With idciudad_asocia
            .DataPropertyName = "idunidad_agencia_asocia"
            .Name = "idunidad_agencia_asocia"
            .HeaderText = "Id. ciudad Asociar"
            .Visible = False            
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        dgv_asocia_ruta.Columns.Add(idciudad_asocia)
    End Sub
    Sub recupera_ciudad_seleccionar()
        Dim ldt_escoge_ciudad As DataTable
        Dim ldv_view As DataView
        Try
            lobj_asocia_ciudad.idnro_salida = pl_idnro_salida_vehiculo
            '
            ldt_escoge_ciudad = lobj_asocia_ciudad.sp_get_escoje_ciudad_asocia()
            '
            lb_no_lee = False
            ldv_view = CargarCombo(Me.cmb_asocia_ciudad, ldt_escoge_ciudad, "nombre_unidad", "idunidad_agencia", 0)  ' Asocia a la ciudad que está en ruta 
            lb_no_lee = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
#End Region
End Class