Imports AccesoDatos
Public Class frmConfiuracionSistemas
#Region "Variables Publicas"
    Public hnd As Long
#End Region
#Region "Variables Privadas"
    Dim ObjCofigura_sistema As New ClsLbTepsa.dto_configura_sistema
    Dim ObjValida As New ClsLbTepsa.dtoValida
    Dim lb_modifica As Boolean
    Dim bIngreso As Boolean = False
#End Region
#Region "Eventos Adicionales"
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

    Private Sub frmConfiuracionSistemas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frmConfiuracionSistemas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '
            'Datahelper
            '
            ObjCofigura_sistema.get_configura_sistema()
            '
            Me.txt_monto_minimo.Text = Format(ObjCofigura_sistema.MONTO_MINIMO_PCE, "######.00")
            Me.txt_nro_meses_lc.Text = Format(ObjCofigura_sistema.nro_meses_linea_credito, "#0")
            '
            lb_modifica = False

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
    Private Sub txt_monto_minimo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_monto_minimo.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If chr.IsDigit(chr) Then
                e.Handled = False
            ElseIf chr.IsControl(chr) Then
                e.Handled = False
            ElseIf chr = "." And Not tb.Text.IndexOf(".") = -1 Then
                e.Handled = False
            ElseIf e.KeyChar = "." Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub txt_monto_minimo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_monto_minimo.TextChanged
        lb_modifica = True
    End Sub
    Private Sub txt_nro_meses_lc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nro_meses_lc.TextChanged
        lb_modifica = True
    End Sub
    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Try
            If lb_modifica = True Then
                If valida() = False Then Exit Sub

                With ObjCofigura_sistema
                    .MONTO_MINIMO_PCE = Me.txt_monto_minimo.Text
                    .nro_meses_linea_credito = Me.txt_nro_meses_lc.Text
                    .ip = dtoUSUARIOS.IP
                    .idusuario_personal = dtoUSUARIOS.IdLogin
                    .IDROL_USUARIO = dtoUSUARIOS.m_iIdRol
                    '
                    'Datahelper
                    '
                    If .SP_act_configuracion() = True Then
                        MsgBox("Se guardó correctamente", MsgBoxStyle.Information, "Seguridad del sistema...")
                    End If

                End With
            End If
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
#End Region
#Region "Procedimientos y Funciones"
    Private Function valida() As Boolean
        With ObjValida
            If .NO_BLANCO(Me.txt_monto_minimo, Me) = False Then
                Return False
            End If
            If .NO_BLANCO(Me.txt_nro_meses_lc, Me) = False Then
                Return False
            End If
            '---
            If .NUMERO_NO_NEGATIVO(Me.txt_monto_minimo, Me) = False Then
                Return False
            End If
            If .NUMERO_NO_NEGATIVO(Me.txt_nro_meses_lc, Me) = False Then
                Return False
            End If

            Return True
        End With
    End Function
#End Region
End Class