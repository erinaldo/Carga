'Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmCierre_LiquiOfi
    Dim DVCierres2 As New DataView
    Dim DVCierres As New DataView
    Dim DVGuias_liquidados As New DataView
    Dim Impresion As New ClsPrint
    Dim obj As New ClsLbTepsa.dtoLiqui_Oficinas
    Dim objLiqui_Turnos As New ClsLbTepsa.dtoLIQUI_TURNOS

    Private ObjReport As ClsLbTepsa.dtoFrmReport '
    Dim bIngreso As Boolean = False
    Public hnd As Long

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
            If dtoUSUARIOS.IdLogin = ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(i + 1) Then
                Me.cmbUsuarios.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub

    Private Sub FrmCierre_LiquiOfi_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmCierre_LiquiOfi_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmCierre_Liquidacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ObjCIERRE_LIQUIDACIONES.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            ObjCIERRE_LIQUIDACIONES.IDROL_USUARIO = dtoUSUARIOS.IdRol
            ObjCIERRE_LIQUIDACIONES.IP = dtoUSUARIOS.m_sIP
            ObjCIERRE_LIQUIDACIONES.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS

            If ObjCIERRE_LIQUIDACIONES.fnABRIR_LIQUIDACIONES = True Then
            End If

            Me.DTPFIN.Value = Now
            Me.DTPINICIO.Value = Now
            llenar_agencias()

            If fnValidar_Rol("14") = True Then 'ADMINISTRADOR DE AGENCIA
            End If
            If fnValidar_Rol("1") = True Then 'ADMINISTRADOR
            End If
            If fnValidar_Rol("2") = True Then 'DBA
            End If

            Select Case dtoUSUARIOS.m_iIdRol
                Case 1, 2
                    Me.cmbAgencia.Enabled = True
                    Me.cmbUsuarios.Enabled = True
                Case 14
                    Call seleccionar_agencias()
                    Call LISTAR_USUARIOS()
                    Call seleccionar_USUARIOS()
                    Me.cmbAgencia.Enabled = False
                    Me.cmbUsuarios.Enabled = False
                Case Else
                    Me.cmbAgencia.Enabled = False
                    Me.cmbUsuarios.Enabled = False
            End Select

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub llenar_agencias()

        If ObjCIERRE_LIQUIDACIONES.fnLISTA_AGENCIA_USUARIOS() = True Then
            'datahelper
            'ModuUtil.LlenarComboIDs(ObjCIERRE_LIQUIDACIONES.cur_Lista_Agencias, cmbAgencia, ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias, 1)
            ModuUtil.LlenarCombo2(ObjCIERRE_LIQUIDACIONES.cur_Lista_Agencias, cmbAgencia, ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias, 1)
        End If
    End Sub
    Private Function VALIDAR_MOSTRAR() As Boolean
        VALIDAR_MOSTRAR = False
        If CDate(Me.DTPINICIO.Value.ToShortDateString) > CDate(Me.DTPFIN.Value.ToShortDateString) Then
            MsgBox("La fecha incial no puede ser mayor que la final...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        If Me.cmbAgencia.SelectedIndex = -1 Then
            MsgBox("Seleccione agencia...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        If Me.cmbUsuarios.SelectedIndex = -1 Then
            MsgBox("Seleccione usuario...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        VALIDAR_MOSTRAR = True
    End Function

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click

        Call MOSTRAR_LIQUIDACIONES()
    End Sub
    Private Sub LISTAR_USUARIOS()

        If Me.cmbAgencia.SelectedIndex <> -1 Then
            dtoUSUARIOS.m_iIdAgencia = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias.Item(cmbAgencia.SelectedIndex.ToString()))
            'datahelper
            If ObjCIERRE_LIQUIDACIONES.fnLISTA_USUARIOS() = True Then
                'ModuUtil.LlenarComboIDs(ObjCIERRE_LIQUIDACIONES.cur_Lista_Usuarios, Me.cmbUsuarios, ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios, 1)
                ModuUtil.LlenarCombo2(ObjCIERRE_LIQUIDACIONES.cur_Lista_Usuarios, Me.cmbUsuarios, ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios, 1)
            End If
        End If
    End Sub

    Private Sub cmbAgencia_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbAgencia.KeyUp
        If e.KeyCode = Keys.Enter Then
            cmbUsuarios.Focus()
        End If
    End Sub
    Private Sub cmbAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectedIndexChanged
        Call LISTAR_USUARIOS()
        DGV.DataSource = Nothing
    End Sub
    Function VALIDAR() As Boolean
        VALIDAR = False
        If IsNothing(DVCierres.Table) = True Then
            MsgBox("No existen elmentos en la lista...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        If DVCierres.Table.Rows.Count <= 0 Then
            MsgBox("Seleccione una liquidación...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        If DVCierres.Table.Rows(dgv.CurrentCell.RowIndex)("cerrado") = 1 Then
            MsgBox("La liquidación esta cerrada...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        For i As Integer = 0 To DVCierres2.Count - 1
            If DVCierres2.Table.Rows(i)("cerrado") = 0 Then
                MsgBox("Existe turnos abiertos, no se puede realizar el cierre...", MsgBoxStyle.Information, "Seguridad del sistema")
                Exit Function
            End If
        Next

        VALIDAR = True
    End Function
    Function VALIDAR_PRELIMINAR() As Boolean
        VALIDAR_PRELIMINAR = False
        If Me.cmbAgencia.SelectedIndex = -1 Then
            MsgBox("Seleccione agencia...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        If Me.cmbUsuarios.SelectedIndex = -1 Then
            MsgBox("Seleccione usuario...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        If IsNothing(DVCierres.Table) = True Then
            MsgBox("No existen elmentos en la lista...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        If DVCierres.Table.Rows.Count <= 0 Then
            MsgBox("Seleccione una liquidacion...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        If DVCierres.Table.Rows(dgv.CurrentCell.RowIndex)("CERRADO") = 1 Then
            MsgBox("La liquidacion esta cerrada...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        VALIDAR_PRELIMINAR = True
    End Function
    Function VALIDAR_ANTERIOR() As Boolean
        VALIDAR_ANTERIOR = False
        If Me.cmbAgencia.SelectedIndex = -1 Then
            MsgBox("Seleccione agencia...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        If Me.cmbUsuarios.SelectedIndex = -1 Then
            MsgBox("Seleccione usuario...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        If IsNothing(DVCierres.Table) = True Then
            MsgBox("No existen elmentos en la lista...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        If DVCierres.Table.Rows.Count <= 0 Then
            MsgBox("Seleccione una liquidacion...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        If DVCierres.Table.Rows(dgv.CurrentCell.RowIndex)("cerrado") = 0 Then
            MsgBox("La liquidacion esta abierta...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        VALIDAR_ANTERIOR = True
    End Function
    Private Sub BTNARQUE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNARQUE.Click
        Try
            If VALIDAR() = False Then Exit Sub

            Dim ObjFrmPassCierreLiqui As New FrmPassCierreLiqui
            'ObjFrmPassCierreLiqui.ShowDialog(Me)
            Acceso.Asignar(ObjFrmPassCierreLiqui, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                ObjFrmPassCierreLiqui.ShowDialog(Me)
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                return
            End If


            obj.IDLIQUI_OFI = DVCierres.Table.Rows(Me.dgv.CurrentCell.RowIndex)("IDLIQUI_OFI")
            'ObjCIERRE_LIQUIDACIONES.IDCIERRES_LIQUIDACIONES = DVCierres.Table.Rows(Me.dgv.CurrentCell.RowIndex)("IDCIERRES_LIQUIDACIONES")

            obj.IDUSUARIO_PERSONAL = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(Me.cmbUsuarios.SelectedIndex.ToString))
            'ObjCIERRE_LIQUIDACIONES.IDUSUARIO_PERSONAL = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(Me.cmbUsuarios.SelectedIndex.ToString))

            obj.IDAGENCIAS = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias.Item(Me.cmbAgencia.SelectedIndex.ToString))
            'ObjCIERRE_LIQUIDACIONES.IDAGENCIAS = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias.Item(Me.cmbAgencia.SelectedIndex.ToString))

            obj.IDUSUARIO_PERSONALMOD = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(Me.cmbUsuarios.SelectedIndex.ToString))
            'ObjCIERRE_LIQUIDACIONES.IDUSUARIO_PERSONALMOD = 1

            'ObjCIERRE_LIQUIDACIONES.IDPROCESOS = 4

            obj.IDESTADO_REGISTRO = 23
            'ObjCIERRE_LIQUIDACIONES.IDESTADO_REGISTRO = 23

            obj.IPMOD = dtoUSUARIOS.m_sIP
            'ObjCIERRE_LIQUIDACIONES.IPMOD = dtoUSUARIOS.m_sIP

            obj.IDROL_USUARIOMOD = dtoUSUARIOS.m_iIdRol
            'ObjCIERRE_LIQUIDACIONES.IDROL_USUARIOMOD = dtoUSUARIOS.m_iIdRol

            If obj.IDUSUARIO_PERSONAL <> obj.IDUSUARIO_PERSONALMOD Then
                obj.obser = "FORZADO"
            Else
                obj.obser = "null"
            End If
            obj.CERRADO = 1
            obj.FECHA_INICIAL = Me.DTPFECHAINICIOGUIA.Value.ToShortDateString
            obj.FECHA_FINAL = Me.DTPFECHAFINALGUIA.Value.ToShortDateString

            If flag_Salir = True Then
                Close()
            Else
                'datahelper
                'obj.SP_LIQUI_OFICINAS(VOCONTROLUSUARIO, cnn)
                obj.SP_LIQUI_OFICINAS()
            End If
            Call MOSTRAR_LIQUIDACIONES()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Sub FORMAT_GRILLA()
        DGV.Columns.Clear()
        With dgv

            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = DVCierres
            .ReadOnly = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


            '.AllowUserToAddRows = True
            '.AllowUserToDeleteRows = True
            '.AllowUserToOrderColumns = True
            '.BackgroundColor = SystemColors.Info
            ''.Font = New System.Drawing.Font("Tahoma", 14.0!, FontStyle.Bold)
            '.ReadOnly = True
            '.AutoGenerateColumns = False
            '.DataSource = 
            '.VirtualMode = True
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.RowHeadersWidth = 10
            '.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EAF")
            '.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            '.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
        End With

        Dim idEstadoImage As New DataGridViewImageColumn
        With idEstadoImage
            .DataPropertyName = "imagen"
            .HeaderText = "CT"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .DisplayIndex = 0
            .Visible = True
            .Image = bmActivo
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        dgv.Columns.Add(idEstadoImage)

        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .DataPropertyName = "NOMBRE"
            .HeaderText = "Usuario"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format.ToUpper()
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        dgv.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DataPropertyName = "LOGIN"
            .HeaderText = "Login"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format.ToUpper()
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        dgv.Columns.Add(col1)


        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .DataPropertyName = "FECHA_APER"
            .HeaderText = "F. Apertura"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format.ToUpper()
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        dgv.Columns.Add(col2)

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .DataPropertyName = "FECHA_CIERRE"
            .HeaderText = "F. Cierre"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format.ToUpper()
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        dgv.Columns.Add(col3)

        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .DataPropertyName = "nombre_agencia"
            .HeaderText = "Agencia"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format.ToUpper()
            .SortMode = DataGridViewColumnSortMode.NotSortable

        End With
        dgv.Columns.Add(col4)

        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .DataPropertyName = "LEYE_APERTURADO_CIERRE"
            .HeaderText = "A/C"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format.ToUpper()
            dgv.Columns.Add(col5)
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
    End Sub

    Function VALIDAR_IMPRIMIR() As Boolean
        VALIDAR_IMPRIMIR = False
        If IsNothing(DVCierres.Table) = True Then
            MsgBox("No existen elmentos en la lista...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        If DVCierres.Table.Rows.Count <= 0 Then
            MsgBox("Seleccione una liquidacion...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        If DVCierres.Table.Rows(dgv.CurrentCell.RowIndex)("cerrado") = 0 Then
            MsgBox("La liquidacion esta Abierta...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        VALIDAR_IMPRIMIR = True
    End Function
    Private Sub BTNSALI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSALI.Click
        Close()
    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub cmbUsuarios_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbUsuarios.KeyUp
        If e.KeyCode = Keys.Enter Then
            BTNMOSTRAR.Focus()
        End If

    End Sub

    Private Sub cmbUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUsuarios.SelectedIndexChanged
        DGV.DataSource = Nothing
    End Sub

    Private Sub BTNPRELI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNPRELI.Click
        If VALIDAR_PRELIMINAR() = False Then Exit Sub

        Try
            ObjReport.Dispose()
        Catch
        End Try

        ObjReport = New ClsLbTepsa.dtoFrmReport


        ObjCIERRE_LIQUIDACIONES.IDAGENCIAS = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias.Item(cmbAgencia.SelectedIndex.ToString))
        ObjCIERRE_LIQUIDACIONES.IDUSUARIO_PERSONAL = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(Me.cmbUsuarios.SelectedIndex.ToString))
        ObjReport.rutaRpt = PathFrmReport
        ObjReport.conectar(rptservice, rptuser, rptpass)
        ObjReport.printrptB(False, "", "CLQ006.RPT", "P_IDUSUARIO_PERSONAL;" & ObjCIERRE_LIQUIDACIONES.IDUSUARIO_PERSONAL, _
        "P_IDAGENCIAS;" & ObjCIERRE_LIQUIDACIONES.IDAGENCIAS, _
        "P_USUARIO;" & Me.cmbUsuarios.Text.ToString, _
        "P_RANGO_FECHA;" & "(Desde " + Me.DTPFECHAINICIOGUIA.Value.ToShortDateString + " al " + Me.DTPFECHAFINALGUIA.Value.ToShortDateString + ")", _
        "P_FECHA_INICIAL;" & Me.DTPFECHAINICIOGUIA.Value.ToShortDateString, _
        "P_FECHA_FINAL;" & Me.DTPFECHAFINALGUIA.Value.ToShortDateString, _
        "P_AGENCIA;" & Me.cmbAgencia.Text.ToString)



    End Sub

    Private Sub BTNANTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNANTE.Click
        Try
            ObjReport.Dispose()
        Catch
        End Try

        ObjReport = New ClsLbTepsa.dtoFrmReport

        Try
            If VALIDAR_ANTERIOR() = False Then Exit Sub



            obj.IDLIQUI_OFI = DVCierres.Table.Rows(dgv.CurrentCell.RowIndex)("IDLIQUI_OFI")
            ObjReport.rutaRpt = PathFrmReport
            ObjReport.conectar(rptservice, rptuser, rptpass)
            ObjReport.printrpt(False, "", "CLQ007.RPT", "P_IDliqui_ofi;" & obj.IDLIQUI_OFI, _
            "P_USUARIO;" & Me.cmbUsuarios.Text.ToString, _
            "P_AGENCIA;" & Me.cmbAgencia.Text.ToString, _
            "P_RANGO_FECHA;" & "(Desde " + Me.DTPFECHAINICIOGUIA.Value.ToShortDateString + " al " + Me.DTPFECHAFINALGUIA.Value.ToShortDateString + ")", _
            "P_FECHA_APERTURA;" & DVCierres.Table.Rows(dgv.CurrentCell.RowIndex)("FECHA_APER"), _
            "P_FECHA_CIERRE;" & DVCierres.Table.Rows(dgv.CurrentCell.RowIndex)("FECHA_CIERRE"), _
            "P_IMPRESO;" & 0)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del sistema")
        End Try
    End Sub

    Private Sub BTNIMPRI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRI.Click
        Try
            ObjReport.Dispose()
        Catch
        End Try
        ObjReport = New ClsLbTepsa.dtoFrmReport
        Try

            Dim IMPRESO As String
            If VALIDAR_ANTERIOR() = False Then Exit Sub

            If DVCierres.Table.Rows(dgv.CurrentCell.RowIndex)("IMPRESO") = 1 Then
                IMPRESO = "REIMPRESION"
            Else
                IMPRESO = ""
                DVCierres.Table.Rows(dgv.CurrentCell.RowIndex)("IMPRESO") = 1
            End If



            obj.IDLIQUI_OFI = DVCierres.Table.Rows(dgv.CurrentCell.RowIndex)("IDLIQUI_OFI")
            ObjReport.rutaRpt = PathFrmReport
            ObjReport.conectar(rptservice, rptuser, rptpass)
            ObjReport.printrpt(True, "", "CLQ007.RPT", "P_IDliqui_ofi;" & obj.IDLIQUI_OFI, _
            "P_USUARIO;" & Me.cmbUsuarios.Text.ToString, _
            "P_AGENCIA;" & Me.cmbAgencia.Text.ToString, _
            "P_RANGO_FECHA;" & "(Desde " + Me.DTPFECHAINICIOGUIA.Value.ToShortDateString + " al " + Me.DTPFECHAFINALGUIA.Value.ToShortDateString + ")", _
            "P_FECHA_APERTURA;" & DVCierres.Table.Rows(dgv.CurrentCell.RowIndex)("FECHA_APER"), _
            "P_FECHA_CIERRE;" & DVCierres.Table.Rows(dgv.CurrentCell.RowIndex)("FECHA_CIERRE"), _
            "P_IMPRESO;" & 1)


        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del sistema")
        End Try
    End Sub

    Private Sub DTPINICIO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTPINICIO.KeyUp
        If e.KeyCode = Keys.Enter Then
            DTPFIN.Focus()
        End If
    End Sub

    Private Sub DTPINICIO_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPINICIO.ValueChanged

    End Sub

    Private Sub DTPFIN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTPFIN.KeyUp
        If e.KeyCode = Keys.Enter Then
            cmbAgencia.Focus()
        End If
    End Sub

    Private Sub DTPFIN_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFIN.ValueChanged

    End Sub

    Private Sub DTPFECHAINICIOGUIA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAINICIOGUIA.KeyPress


    End Sub

    Private Sub DTPFECHAINICIOGUIA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTPFECHAINICIOGUIA.KeyUp
        If e.KeyCode = Keys.Enter Then
            DTPFECHAFINALGUIA.Focus()
        End If
    End Sub

    Private Sub DTPFECHAINICIOGUIA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOGUIA.ValueChanged

    End Sub

    Private Sub DTPFECHAFINALGUIA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTPFECHAFINALGUIA.KeyUp
        If e.KeyCode = Keys.Enter Then
            BTNPRELI.Focus()
        End If
    End Sub

    Private Sub DTPFECHAFINALGUIA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALGUIA.ValueChanged

    End Sub

    Private Sub DGV_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            If dgv.CurrentRow.Index = -1 Then Exit Sub
            Me.DTPFECHAFINALGUIA.Value = DVCierres.Table.Rows(Me.dgv.CurrentRow.Index)("FECHA_LIQUIDACION_APER")
            Me.DTPFECHAINICIOGUIA.Value = DVCierres.Table.Rows(Me.dgv.CurrentRow.Index)("FECHA_LIQUIDACION_APER")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try


    End Sub

    Private Sub DGV_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub dgv_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub
    Function MOSTRAR_LIQUIDACIONES_TURNOS()
        If VALIDAR_MOSTRAR() = False Then Exit Function
        objLiqui_Turnos.IDAGENCIAS = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias.Item(cmbAgencia.SelectedIndex.ToString))
        objLiqui_Turnos.IDUSUARIO_PERSONAL = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(Me.cmbUsuarios.SelectedIndex.ToString))
        objLiqui_Turnos.FECHA_INICIAL = Me.DTPFECHAINICIOGUIA.Value.ToShortDateString.ToString
        objLiqui_Turnos.FECHA_FINAL = Me.DTPFECHAFINALGUIA.Value.ToShortDateString.ToString

        DVCierres2 = New DataView



        Try
            If DVCierres.Table.Rows(dgv.CurrentCell.RowIndex)("cerrado") = 0 Then
                'datahelper
                'DVCierres2 = objLiqui_Turnos.SP_L_LIQUI_OFI_TURNOS_PEND(VOCONTROLUSUARIO, cnn)
                DVCierres2 = objLiqui_Turnos.SP_L_LIQUI_OFI_TURNOS_PEND()
                Call format_grilla2()
            Else
                obj.IDLIQUI_OFI = DVCierres.Table.Rows(dgv.CurrentCell.RowIndex)("IDLIQUI_OFI")
                'datahelper
                'DVCierres2 = obj.SP_L_LIQUI_TURNOS_CERRA(VOCONTROLUSUARIO, cnn)
                DVCierres2 = obj.SP_L_LIQUI_TURNOS_CERRA()
                Call format_grilla2()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Function
    Private Sub format_grilla2()
        dgv2.Columns.Clear()
        With dgv2

            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = DVCierres2
            .ReadOnly = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


            '.AllowUserToAddRows = True
            '.AllowUserToDeleteRows = True
            '.AllowUserToOrderColumns = True
            '.BackgroundColor = SystemColors.Info
            ''.Font = New System.Drawing.Font("Tahoma", 14.0!, FontStyle.Bold)
            '.ReadOnly = True
            '.AutoGenerateColumns = False
            '.DataSource = 
            '.VirtualMode = True
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.RowHeadersWidth = 10
            '.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EAF")
            '.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            '.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
        End With

        Dim idEstadoImage As New DataGridViewImageColumn
        With idEstadoImage
            .DataPropertyName = "imagen"
            .HeaderText = "CT"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .DisplayIndex = 0
            .Visible = True
            .Image = bmActivo
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        dgv2.Columns.Add(idEstadoImage)

        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .DataPropertyName = "NOMBRE"
            .HeaderText = "Usuario"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format.ToUpper()
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        dgv2.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DataPropertyName = "LOGIN"
            .HeaderText = "Login"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format.ToUpper()
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        dgv2.Columns.Add(col1)


        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .DataPropertyName = "FECHA_APER"
            .HeaderText = "F. Apertura"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format.ToUpper()
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        dgv2.Columns.Add(col2)

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .DataPropertyName = "FECHA_CIERRE"
            .HeaderText = "F. Cierre"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format.ToUpper()
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        dgv2.Columns.Add(col3)

        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .DataPropertyName = "nombre_agencia"
            .HeaderText = "Agencia"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format.ToUpper()
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        dgv2.Columns.Add(col4)

        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .DataPropertyName = "LEYE_APERTURADO_CIERRE"
            .HeaderText = "A/C"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format.ToUpper()
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        dgv2.Columns.Add(col5)

    End Sub

    Private Sub dgv_CellEnter1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellEnter
        Try
            If dgv.CurrentRow.Index = -1 Then Exit Sub
            Me.DTPFECHAFINALGUIA.Value = DVCierres.Table.Rows(Me.dgv.CurrentRow.Index)("FECHA_APER")
            Me.DTPFECHAINICIOGUIA.Value = DVCierres.Table.Rows(Me.dgv.CurrentRow.Index)("FECHA_APER")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try

        Call MOSTRAR_LIQUIDACIONES_TURNOS()
    End Sub
    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub

    Private Sub MOSTRAR_LIQUIDACIONES2009()
        If VALIDAR_MOSTRAR() = False Then Exit Sub
        obj.IDAGENCIAS = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias.Item(cmbAgencia.SelectedIndex.ToString))
        obj.IDUSUARIO_PERSONAL = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(Me.cmbUsuarios.SelectedIndex.ToString))
        obj.FECHA_INICIAL = Me.DTPINICIO.Value.ToShortDateString.ToString
        obj.FECHA_FINAL = Me.DTPFIN.Value.ToShortDateString.ToString

        DVCierres = New DataView
        Try
            'DVCierres = obj.SP_LISTAR_LIQUI_OFICINAS_PEND(VOCONTROLUSUARIO, cnn)
            Call FORMAT_GRILLA()
            dgv2.DataSource = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub MOSTRAR_LIQUIDACIONES()
        If VALIDAR_MOSTRAR() = False Then Exit Sub
        obj.IDAGENCIAS = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias.Item(cmbAgencia.SelectedIndex.ToString))
        obj.IDUSUARIO_PERSONAL = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(Me.cmbUsuarios.SelectedIndex.ToString))
        obj.FECHA_INICIAL = Me.DTPINICIO.Value.ToShortDateString.ToString
        obj.FECHA_FINAL = Me.DTPFIN.Value.ToShortDateString.ToString

        DVCierres = New DataView
        'datahelper
        Try
            DVCierres = obj.SP_LISTAR_LIQUI_OFICINAS_PEND()
            Call FORMAT_GRILLA()
            dgv2.DataSource = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
End Class