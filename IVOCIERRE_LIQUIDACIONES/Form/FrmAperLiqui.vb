Public Class FrmAperLiqui
    Dim dto As New ClsLbTepsa.dtoLiqui_Oficinas
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Sub llenar_agencias()

        If ObjCIERRE_LIQUIDACIONES.fnLISTA_AGENCIA_USUARIOS() = True Then
            'datahelper
            'ModuUtil.LlenarComboIDs(ObjCIERRE_LIQUIDACIONES.cur_Lista_Agencias, cmbAgencia, ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias, 1)
            ModuUtil.LlenarCombo2(ObjCIERRE_LIQUIDACIONES.cur_Lista_Agencias, cmbAgencia, ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias, 1)
        End If
    End Sub

    Private Sub FrmAperLiqui_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmAperLiqui_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmAperLiquiTurno_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ObjCIERRE_LIQUIDACIONES.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
        'ObjCIERRE_LIQUIDACIONES.IDROL_USUARIO = dtoUSUARIOS.IdRol
        'ObjCIERRE_LIQUIDACIONES.IP = dtoUSUARIOS.m_sIP
        'ObjCIERRE_LIQUIDACIONES.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS

        'If ObjCIERRE_LIQUIDACIONES.fnABRIR_LIQUIDACIONES = True Then
        'End If



        'UNA MISMA AGENCIA
        'COMBO OFICINA....

        '1  ADMIN   TODOS LAS AGENCIAS/INCLUSIVE A OTARAS CERRAR CAJA SI ESTA VACIA / COMBO ESTA DESHABILITADO  // OBS DE CIERRE  (FORSADO)
        '14 ADMINISTRADOR AGENCIA 'CERRAR CAJA COMBO DE AGENCIA DESHABILITADO SELECCIONADO LA AGENCIA , y HABILITADO LOS USUARIOS DE AJENCIA (21) // OBS (FORSADO)

        '7  FUNCIONARIO CARGA  ' VER LIQUIDACIONES ANTERIORES / CERRAR CAJA, PRELIMIAR ---> NO DEBE PODER CERRAR
        '21 VENTA CARGA TODO y EN LA LISTA DE USUASRIOS DEBE POR DEFOUL Y EL COMBO DESHABILITADO


        'dtoUSUARIOS.IdRol
        'dtoUSUARIOS.IP
        'dtoUSUARIOS.m_iAgencia
        'FECHA()



        Try
            llenar_agencias()
            Call seleccionar_agencias()
            Call LISTAR_USUARIOS()
            Call seleccionar_USUARIOS()

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub LISTAR_USUARIOS()

        If Me.cmbAgencia.SelectedIndex <> -1 Then
            dtoUSUARIOS.m_iIdAgencia = Int(objCIERRE_LIQUIDACIONES.coll_Lista_Agencias.Item(cmbAgencia.SelectedIndex.ToString()))
            If ObjCIERRE_LIQUIDACIONES.fnLISTA_USUARIOS() = True Then
                'datahelper
                'ModuUtil.LlenarComboIDs(ObjCIERRE_LIQUIDACIONES.cur_Lista_Usuarios, Me.cmbUsuarios, ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios, 1)
                ModuUtil.LlenarCombo2(ObjCIERRE_LIQUIDACIONES.cur_Lista_Usuarios, Me.cmbUsuarios, ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios, 1)
            End If
        End If
    End Sub
    Private Sub seleccionar_agencias()
        For i As Integer = 0 To Me.cmbAgencia.Items.Count - 1
            If dtoUSUARIOS.iIDAGENCIAS = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias.Item(i + 1).ToString) Then
                Me.cmbAgencia.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub
    Private Sub seleccionar_USUARIOS()
        For i As Integer = 0 To Me.cmbUsuarios.Items.Count - 1
            If dtoUSUARIOS.IdLogin = objCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(i + 1) Then
                Me.cmbUsuarios.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub


    Private Sub BTNACEP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNACEP.Click
        '
        Dim ldt_liquidacion_abierta As New DataTable
        Dim ls_agencia, ls_fecha_liquidacion_aper As String
        '
        Try

            ObjCIERRE_LIQUIDACIONES.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
            ObjCIERRE_LIQUIDACIONES.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            ObjCIERRE_LIQUIDACIONES.IDROL_USUARIO = dtoUSUARIOS.Rol
            ObjCIERRE_LIQUIDACIONES.IP = dtoUSUARIOS.IP
            ObjCIERRE_LIQUIDACIONES.FECHA_LIQUIDACION_APER = dtpfecha.Value.ToShortDateString
            'datahelper
            'If Not ObjCIERRE_LIQUIDACIONES.SP_SI_LIQUIDACION_ABIERTA_(cnn).Count <= 0 Then
            ldt_liquidacion_abierta = ObjCIERRE_LIQUIDACIONES.SP_SI_LIQUIDACION_ABIERTA_()
            'If Not ObjCIERRE_LIQUIDACIONES.SP_SI_LIQUIDACION_ABIERTA_().Count <= 0 Then
            '
            If Not ldt_liquidacion_abierta.Rows.Count <= 0 Then
                ls_agencia = CType(ldt_liquidacion_abierta.Rows(0)("agencia"), String)
                ls_fecha_liquidacion_aper = CType(ldt_liquidacion_abierta.Rows(0)("FECHA_LIQUIDACION_APER"), String)
                '
                MsgBox("Ya existe TURNO CREDITO aperturada en " + ls_agencia + " el día " + ls_fecha_liquidacion_aper, MsgBoxStyle.Information, "Seguridad del Sistema")
                Exit Sub
            End If

            ObjCIERRE_LIQUIDACIONES.FECHA_LIQUIDACION_APER = dtpfecha.Value.ToShortDateString
            ObjCIERRE_LIQUIDACIONES.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            ObjCIERRE_LIQUIDACIONES.IDROL_USUARIO = dtoUSUARIOS.IdRol
            ObjCIERRE_LIQUIDACIONES.IP = dtoUSUARIOS.m_sIP
            ObjCIERRE_LIQUIDACIONES.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS

            If ObjCIERRE_LIQUIDACIONES.fnABRIR_LIQUIDACIONES_ = True Then
            End If


            Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema...")
        End Try

    End Sub

    Private Sub bcance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bcance.Click
        Close()
    End Sub
End Class
