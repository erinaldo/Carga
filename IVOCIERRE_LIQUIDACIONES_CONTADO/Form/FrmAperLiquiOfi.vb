Public Class FrmAperLiquiOfi
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
            'ModuUtil.LlenarComboIDs(objCIERRE_LIQUIDACIONES.cur_Lista_Agencias, cmbAgencia, objCIERRE_LIQUIDACIONES.coll_Lista_Agencias, 1)
            ModuUtil.LlenarCombo2(ObjCIERRE_LIQUIDACIONES.cur_Lista_Agencias, cmbAgencia, ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias, 1)
        End If
    End Sub

    Private Sub FrmAperLiquiOfi_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmAperLiquiOfi_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmAperLiquiTurno_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ObjCIERRE_LIQUIDACIONES.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            ObjCIERRE_LIQUIDACIONES.IDROL_USUARIO = dtoUSUARIOS.IdRol
            ObjCIERRE_LIQUIDACIONES.IP = dtoUSUARIOS.m_sIP
            ObjCIERRE_LIQUIDACIONES.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS

            If ObjCIERRE_LIQUIDACIONES.fnABRIR_LIQUIDACIONES = True Then
            End If



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
        Try
            With dto
                .OPERACION = 1
                .NRO_FACTU = -666
                .TOTAL_MONTO_FACTU = -666
                .NRO_BOLE = -666
                .TOTAL_MONTO_BOLE = -666
                .NRO_ANULA = -666
                .TOTAL_MONTO_ANULA = -666
                .NRO_PAGO_ENTRE = -666
                .TOTAL_MONTO_PAGO_ENTRE = -666
                .NRO_DEVO = -666
                .TOTAL_MONTO_DEVO = -666
                .NRO_TARJE_CREDI = -666
                .TOTAL_MONTO_TARJE_CREDI = -666
                .NRO_SOBRES = -666
                .TOTAL_MONTO_SOBRES = -666
                .TOTAL_PESO = -666
                .TOTAL_VOLU = -666
                .TOTAL_SOBRES = -666
                .TIPO_CAMBI = -666
                .TOTAL_MONTO_SOLES = -666
                .TOTAL_MONTO_DOLA = -666
                .TOTAL_MONTO_BOUCHER_SOLES = -666
                .TOTAL_MONTO_BOUCHER_DOLA = -666
                .FECHA_APER = "NULL"
                .FECHA_CIERRE = "NULL"
                .IMPRESO = 0
                .CERRADO = 0
                .IP = dtoUSUARIOS.IP
                .IPMOD = "NULL"
                .IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                .IDUSUARIO_PERSONALMOD = -666
                .FECHA_REGISTRO = "NULL"
                .FECHA_ACTUALIZACION = "NULL"
                .IDROL_USUARIO = dtoUSUARIOS.IdRol
                .IDROL_USUARIOMOD = -666
                .IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
                .IDUNIDAD_AGENCIA = -666 'COLOCA ACA LA IDUNIDAD_AGENCIA
                .IDESTADO_REGISTRO = 1
                'datahelper
                '.SP_INSUPD_LIQUI_OFICINAS(VOCONTROLUSUARIO)
                .SP_INSUPD_LIQUI_OFICINAS()
            End With
            Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema...")
        End Try

    End Sub

    Private Sub bcance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bcance.Click
        Close()
    End Sub
End Class
