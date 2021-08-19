'Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmCierre_Liquidacion
    'Dim dr1 As New OleDbDataAdapter
    Dim DTCierres As New DataTable
    Dim DVCierres As New DataView
    Dim DVGuias_liquidados As New DataView
    Dim Impresion As New ClsPrint

    Dim ObjReport As ClsLbTepsa.dtoFrmReport
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Dim iLong As Integer = 71
    Dim iAncho As Integer = 137

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

    Private Sub FrmCierre_Liquidacion_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmCierre_Liquidacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmCierre_Liquidacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'If fnValidar_Rol("25") = True Then
        'GroupBox4.Visible = True
        'Else
        GroupBox4.Visible = False
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
        Me.DTPFIN.Value = Now
        Me.DTPINICIO.Value = Now
        llenar_agencias()
        Try
            Select Case dtoUSUARIOS.m_iIdRol
                Case 1
                    Me.cmbAgencia.Enabled = True
                    Me.cmbUsuarios.Enabled = True
                Case 14
                    Call seleccionar_agencias()
                    Me.cmbAgencia.Enabled = False
                    Call LISTAR_USUARIOS()
                    Me.cmbUsuarios.Enabled = True
                Case 7
                    Call seleccionar_agencias()
                    Call LISTAR_USUARIOS()
                    Call seleccionar_USUARIOS()
                    Me.cmbAgencia.Enabled = True
                    Me.cmbUsuarios.Enabled = True
                Case 21
                    Call seleccionar_agencias()
                    Call LISTAR_USUARIOS()
                    Call seleccionar_USUARIOS()
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
            'ModuUtil.LlenarComboIDs(objCIERRE_LIQUIDACIONES.cur_Lista_Agencias, cmbAgencia, objCIERRE_LIQUIDACIONES.coll_Lista_Agencias, 1)
            ModuUtil.LlenarCombo2(ObjCIERRE_LIQUIDACIONES.cur_Lista_Agencias, cmbAgencia, ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias, dtoUSUARIOS.m_iIdAgencia)
            'cmbAgencia.SelectedValue = ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias(dtoUSUARIOS.iIDAGENCIAS)
        End If
    End Sub
    Private Function VALIDAR_MOSTRAR() As Boolean
        VALIDAR_MOSTRAR = False
        If CDate(Me.DTPINICIO.Value) > CDate(Me.DTPFIN.Value) Then
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
    Private Sub MOSTRAR_LIQUIDACIONES()
        If VALIDAR_MOSTRAR() = False Then Exit Sub
        objCIERRE_LIQUIDACIONES.IDAGENCIAS = Int(objCIERRE_LIQUIDACIONES.coll_Lista_Agencias.Item(cmbAgencia.SelectedIndex.ToString))
        objCIERRE_LIQUIDACIONES.IDUSUARIO_PERSONAL = Int(objCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(Me.cmbUsuarios.SelectedIndex.ToString))
        objCIERRE_LIQUIDACIONES.FECHA_INICIO = Me.DTPINICIO.Value.ToShortDateString.ToString
        objCIERRE_LIQUIDACIONES.FECHA_FIN = Me.DTPFIN.Value.ToShortDateString.ToString

        DVCierres = New DataView
        DTCierres = New DataTable


        Try
            'datahelper
            'If ObjCIERRE_LIQUIDACIONES.fnLISTAR_Liquidaciones = True Then
            '    dr1.Fill(DTCierres, ObjCIERRE_LIQUIDACIONES.cur_listar_liquidaciones)
            '    DVCierres = DTCierres.DefaultView
            '    Call FORMAT_GRILLA()
            'End If
            If ObjCIERRE_LIQUIDACIONES.fnLISTAR_Liquidaciones = True Then
                DTCierres = ObjCIERRE_LIQUIDACIONES.cur_listar_liquidaciones
                DVCierres = DTCierres.DefaultView
                Call FORMAT_GRILLA()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")

        End Try
    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        Call MOSTRAR_LIQUIDACIONES()
    End Sub
    Private Sub LISTAR_USUARIOS()

        If Me.cmbAgencia.SelectedIndex <> -1 Then
            dtoUSUARIOS.m_iIdAgencia = Int(objCIERRE_LIQUIDACIONES.coll_Lista_Agencias.Item(cmbAgencia.SelectedIndex.ToString()))
            If ObjCIERRE_LIQUIDACIONES.fnLISTA_USUARIOS(2, DTPINICIO.Text, DTPFIN.Text) = True Then
                'datahelper
                'ModuUtil.LlenarComboIDs(ObjCIERRE_LIQUIDACIONES.cur_Lista_Usuarios, Me.cmbUsuarios, ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios, 1)
                ModuUtil.LlenarCombo2(ObjCIERRE_LIQUIDACIONES.cur_Lista_Usuarios, Me.cmbUsuarios, ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios, dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item(2).ToString)
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
            MsgBox("Seleccione una liquidacion...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        If DVCierres.Table.Rows.Count <= 0 Then
            MsgBox("Seleccione una liquidacion...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        If DVCierres.Table.Rows(DGV.CurrentCell.RowIndex)("estado_aperturado_cierre") = 1 Then
            MsgBox("La liquidacion esta cerrada...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
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
        If DVCierres.Table.Rows(DGV.CurrentCell.RowIndex)("estado_aperturado_cierre") = 1 Then
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
        If DVCierres.Table.Rows(DGV.CurrentCell.RowIndex)("estado_aperturado_cierre") = 0 Then
            MsgBox("La liquidacion esta abierta...", MsgBoxStyle.Information, "Seguridad del sistema")
            Exit Function
        End If
        VALIDAR_ANTERIOR = True
    End Function

    Dim Total_Carga_Credito As Double
    Private Sub BTNARQUE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNARQUE.Click
        Try
            If VALIDAR() = False Then Exit Sub

            Dim ObjFrmPassCierreLiqui As New FrmPassCierreLiqui
            'ObjFrmPassCierreLiqui.ShowDialog(Me)

            Acceso.Asignar(ObjFrmPassCierreLiqui, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                ObjFrmPassCierreLiqui.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ObjCIERRE_LIQUIDACIONES.IDCIERRES_LIQUIDACIONES = DVCierres.Table.Rows(Me.DGV.CurrentCell.RowIndex)("IDCIERRES_LIQUIDACIONES")
            ObjCIERRE_LIQUIDACIONES.IDUSUARIO_PERSONAL = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(Me.cmbUsuarios.SelectedIndex.ToString))
            '
            'Agregado Liquidacion Oficina-
            Dim idUsuario As Integer = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(Me.cmbUsuarios.SelectedIndex.ToString))
            '---------
            '
            ObjCIERRE_LIQUIDACIONES.IDAGENCIAS = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias.Item(Me.cmbAgencia.SelectedIndex.ToString))
            ObjCIERRE_LIQUIDACIONES.IDUSUARIO_PERSONALMOD = 1
            ObjCIERRE_LIQUIDACIONES.IDPROCESOS = 4
            ObjCIERRE_LIQUIDACIONES.IDESTADO_REGISTRO = 23
            ObjCIERRE_LIQUIDACIONES.IPMOD = dtoUSUARIOS.m_sIP
            ObjCIERRE_LIQUIDACIONES.IDROL_USUARIOMOD = dtoUSUARIOS.m_iIdRol
            If ObjCIERRE_LIQUIDACIONES.IDUSUARIO_PERSONAL <> ObjCIERRE_LIQUIDACIONES.IDUSUARIO_PERSONALMOD Then
                ObjCIERRE_LIQUIDACIONES.OBSER = "FORZADO"
            Else
                ObjCIERRE_LIQUIDACIONES.OBSER = ""
            End If
            ObjCIERRE_LIQUIDACIONES.ESTADO_APERTURADO_CIERRE = 1
            ObjCIERRE_LIQUIDACIONES.FECHA_INICIO = Me.DTPFECHAINICIOGUIA.Value.ToShortDateString
            ObjCIERRE_LIQUIDACIONES.FECHA_FIN = Me.DTPFECHAFINALGUIA.Value.ToShortDateString


            ObjCIERRE_LIQUIDACIONES.IDUSUARIO_PERSONAL = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(Me.cmbUsuarios.SelectedIndex.ToString))

            '--Agregado Liquidacion x Oficina
            Dim objMonto As New dtoCierreOficina
            Dim dt As DataTable = objMonto.DetalleVenta(2, idUsuario, Me.DTPFECHAFINALGUIA.Value.ToShortDateString, Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias.Item(Me.cmbAgencia.SelectedIndex.ToString)))
            Total_Carga_Credito = IIf(IsDBNull(dt.Rows(0)("TOTAL")), 0, dt.Rows(0)("TOTAL")) 'total_Monto_Factura
            ObjCIERRE_LIQUIDACIONES.Total_venta_Credito = Total_Carga_Credito
            '-------------

            If flag_Salir = True Then
                Close()
            Else
                'If ObjCIERRE_LIQUIDACIONES.fnLISTAR_ARQUEOS() = True Then 'Comentado x Liquidacion Oficina
                'End If                
                ObjCIERRE_LIQUIDACIONES.fnLISTAR_ARQUEOS_I() 'Agregado Liquidacion Oficina
            End If
            Call MOSTRAR_LIQUIDACIONES()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Sub FORMAT_GRILLA()
        DGV.Columns.Clear()
        With DGV
            .AllowUserToAddRows = True
            .AllowUserToDeleteRows = True
            .AllowUserToOrderColumns = True
            .BackgroundColor = SystemColors.Info
            '.Font = New System.Drawing.Font("Tahoma", 14.0!, FontStyle.Bold)
            .ReadOnly = True
            .AutoGenerateColumns = False
            .DataSource = DVCierres
            .VirtualMode = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersWidth = 10
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EAF")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
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
        DGV.Columns.Add(idEstadoImage)

        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .DataPropertyName = "NOMBRE"
            .HeaderText = "Usuario"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format.ToUpper()
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        DGV.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DataPropertyName = "LOGIN"
            .HeaderText = "Login"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format.ToUpper()
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        DGV.Columns.Add(col1)


        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .DataPropertyName = "FECHA_LIQUIDACION_APER"
            .HeaderText = "F. Apertura"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format.ToUpper()
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        DGV.Columns.Add(col2)

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .DataPropertyName = "FECHA_LIQUIDACION_CIERRE"
            .HeaderText = "F. Cierre"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format.ToUpper()
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        DGV.Columns.Add(col3)

        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .DataPropertyName = "nombre_unidad"
            .HeaderText = "Agencia"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format.ToUpper()
            .SortMode = DataGridViewColumnSortMode.NotSortable

        End With
        DGV.Columns.Add(col4)

        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .DataPropertyName = "LEYE_APERTURADO_CIERRE"
            .HeaderText = "A/C"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format.ToUpper()
            DGV.Columns.Add(col5)
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
        If DVCierres.Table.Rows(DGV.CurrentCell.RowIndex)("estado_aperturado_cierre") = 0 Then
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
        Try
            If VALIDAR_PRELIMINAR() = False Then Exit Sub
            Me.Cursor = Cursors.AppStarting
            Dim obj As New dtoCIERRE_LIQUIDACIONES
            Dim id As Integer = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(Me.cmbUsuarios.SelectedIndex.ToString))
            Dim iAgencia As Integer = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias.Item(cmbAgencia.SelectedIndex.ToString))
            Dim sIni As String = Me.DTPFECHAINICIOGUIA.Value.ToShortDateString
            Dim sFin As String = Me.DTPFECHAFINALGUIA.Value.ToShortDateString
            Dim ds As DataSet = obj.ListarLiquidacionTurnoCredito(id, iAgencia, sIni, sFin)
            ImprimirLiquidacion2(ds)

            Me.Cursor = Cursors.Default
            Dim frm As New FrmPreview
            frm.Documento = 37
            frm.Tamaño = iLong
            frm.Text = "Liquidación Ventas al Crédito"
            frm.ShowDialog()
            obj = Nothing
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'If VALIDAR_PRELIMINAR() = False Then Exit Sub
        'Try
        '    ObjReport.Dispose()
        'Catch
        'End Try
        'ObjReport = New ClsLbTepsa.dtoFrmReport

        'ObjCIERRE_LIQUIDACIONES.IDAGENCIAS = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias.Item(cmbAgencia.SelectedIndex.ToString))
        'ObjCIERRE_LIQUIDACIONES.IDUSUARIO_PERSONAL = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(Me.cmbUsuarios.SelectedIndex.ToString))
        'ObjReport.rutaRpt = PathFrmReport
        'ObjReport.conectar(rptservice, rptuser, rptpass)
        'ObjReport.printrptB(False, "", "CLQ_002.RPT", "P_IDUSUARIO_PERSONAL;" & ObjCIERRE_LIQUIDACIONES.IDUSUARIO_PERSONAL, _
        '"P_IDAGENCIAS;" & ObjCIERRE_LIQUIDACIONES.IDAGENCIAS, _
        '"P_USUARIO;" & Me.cmbUsuarios.Text.ToString, _
        '"P_RANGO_FECHA;" & "(Desde " + Me.DTPFECHAINICIOGUIA.Value.ToShortDateString + " al " + Me.DTPFECHAFINALGUIA.Value.ToShortDateString + ")", _
        '"P_FECHA_INICIO;" & Me.DTPFECHAINICIOGUIA.Value.ToShortDateString, _
        '"P_FECHA_FINAL;" & Me.DTPFECHAFINALGUIA.Value.ToShortDateString, _
        '"P_AGENCIA;" & Me.cmbAgencia.Text.ToString)



    End Sub

    Private Sub BTNANTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNANTE.Click
        Try
            If VALIDAR_ANTERIOR() = False Then Exit Sub
            Me.Cursor = Cursors.AppStarting
            Dim obj As New dtoCIERRE_LIQUIDACIONES
            Dim id As Integer = DVCierres.Table.Rows(DGV.CurrentCell.RowIndex)("IDCIERRES_LIQUIDACIONES")
            Dim ds As DataSet = obj.ListarLiquidacionTurnoCredito(id)
            ImprimirLiquidacion(ds)

            Me.Cursor = Cursors.Default
            Dim frm As New FrmPreview
            frm.Documento = 37
            frm.Tamaño = iLong
            frm.Text = "Liquidación Ventas al Crédito"
            frm.ShowDialog()
            obj = Nothing
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Try
        '    ObjReport.Dispose()
        'Catch
        'End Try
        'Try
        '    If VALIDAR_ANTERIOR() = False Then Exit Sub


        '    ObjReport = New ClsLbTepsa.dtoFrmReport
        '    ObjCIERRE_LIQUIDACIONES.IDCIERRES_LIQUIDACIONES = DVCierres.Table.Rows(DGV.CurrentCell.RowIndex)("IDCIERRES_LIQUIDACIONES")
        '    ObjReport.rutaRpt = PathFrmReport
        '    ObjReport.conectar(rptservice, rptuser, rptpass)
        '    ObjReport.printrpt(False, "", "CLQ_001.RPT", "P_IDCIERRES_LIQUIDACIONES;" & ObjCIERRE_LIQUIDACIONES.IDCIERRES_LIQUIDACIONES, _
        '    "P_USUARIO;" & Me.cmbUsuarios.Text.ToString, _
        '    "P_AGENCIA;" & Me.cmbAgencia.Text.ToString, _
        '    "P_RANGO_FECHA;", _
        '    "P_FECHA_APERTURA;" & DVCierres.Table.Rows(DGV.CurrentCell.RowIndex)("FECHA_LIQUIDACION_APER"), _
        '    "P_FECHA_CIERRE;" & DVCierres.Table.Rows(DGV.CurrentCell.RowIndex)("FECHA_LIQUIDACION_CIERRE"), _
        '    "P_IMPRESO;")
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del sistema")
        'End Try
    End Sub

    Private Sub BTNIMPRI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRI.Click
        Try
            ObjReport.Dispose()
        Catch
        End Try
        Try

            Dim IMPRESO As String
            If VALIDAR_ANTERIOR() = False Then Exit Sub

            If DVCierres.Table.Rows(DGV.CurrentCell.RowIndex)("IMPRESO") = 1 Then
                IMPRESO = "REIMPRESION"
            Else
                IMPRESO = ""
                DVCierres.Table.Rows(DGV.CurrentCell.RowIndex)("IMPRESO") = 1
            End If



            ObjReport = New ClsLbTepsa.dtoFrmReport
            ObjCIERRE_LIQUIDACIONES.IDCIERRES_LIQUIDACIONES = DVCierres.Table.Rows(DGV.CurrentCell.RowIndex)("IDCIERRES_LIQUIDACIONES")
            ObjReport.rutaRpt = PathFrmReport
            ObjReport.conectar(rptservice, rptuser, rptpass)
            ObjReport.printrpt(True, "", "CLQ_001.RPT", "P_IDCIERRES_LIQUIDACIONES;" & ObjCIERRE_LIQUIDACIONES.IDCIERRES_LIQUIDACIONES, _
            "P_USUARIO;" & Me.cmbUsuarios.Text.ToString, _
            "P_AGENCIA;" & Me.cmbAgencia.Text.ToString, _
            "P_RANGO_FECHA;" & "(Desde " + Me.DTPFECHAINICIOGUIA.Value.ToShortDateString + " al " + Me.DTPFECHAFINALGUIA.Value.ToShortDateString + ")", _
            "P_FECHA_APERTURA;" & DVCierres.Table.Rows(DGV.CurrentCell.RowIndex)("FECHA_LIQUIDACION_APER"), _
            "P_FECHA_CIERRE;" & DVCierres.Table.Rows(DGV.CurrentCell.RowIndex)("FECHA_LIQUIDACION_CIERRE"), _
            "P_IMPRESO;" & IMPRESO)
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

    Private Sub DGV_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellContentClick

    End Sub

    Private Sub DGV_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellEnter
        Try
            If DGV.CurrentRow.Index = -1 Then Exit Sub
            Me.DTPFECHAFINALGUIA.Value = DVCierres.Table.Rows(Me.DGV.CurrentRow.Index)("FECHA_LIQUIDACION_APER")
            Me.DTPFECHAINICIOGUIA.Value = DVCierres.Table.Rows(Me.DGV.CurrentRow.Index)("FECHA_LIQUIDACION_APER")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If VALIDAR_PRELIMINAR() = False Then Exit Sub
            Dim obj As New dtoCIERRE_LIQUIDACIONES
            Dim id As Integer = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(Me.cmbUsuarios.SelectedIndex.ToString))
            Dim iAgencia As Integer = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias.Item(cmbAgencia.SelectedIndex.ToString))
            Dim sIni As String = Me.DTPFECHAINICIOGUIA.Value.ToShortDateString
            Dim sFin As String = Me.DTPFECHAFINALGUIA.Value.ToShortDateString
            Dim ds As DataSet = obj.ListarLiquidacionTurnoCredito(id, iAgencia, sIni, sFin)
            ImprimirLiquidacion2(ds)

            Dim frm As New FrmPreview
            frm.Documento = 37
            frm.Tamaño = iLong
            frm.Text = "Liquidación Ventas al Crédito"
            frm.ShowDialog()
            obj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'ObjReport = New ClsLbTepsa.dtoFrmReport
        'ObjCIERRE_LIQUIDACIONES.IDAGENCIAS = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias.Item(cmbAgencia.SelectedIndex.ToString))
        'ObjCIERRE_LIQUIDACIONES.IDUSUARIO_PERSONAL = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(Me.cmbUsuarios.SelectedIndex.ToString))
        'ObjReport.rutaRpt = PathFrmReport
        'ObjReport.conectar(rptservice, rptuser, rptpass)
        'ObjReport.printrptB(False, "", "CLQ_002.RPT", "P_IDUSUARIO_PERSONAL;" & ObjCIERRE_LIQUIDACIONES.IDUSUARIO_PERSONAL, _
        '"P_IDAGENCIAS;" & ObjCIERRE_LIQUIDACIONES.IDAGENCIAS, _
        '"P_USUARIO;" & Me.cmbUsuarios.Text.ToString, _
        '"P_RANGO_FECHA;" & "(Desde " + Me.DTPFECHAINICIOGUIA.Value.ToShortDateString + " al " + Me.DTPFECHAFINALGUIA.Value.ToShortDateString + ")", _
        '"P_FECHA_INICIO;" & Me.DTPFECHAINICIOGUIA.Value.ToShortDateString, _
        '"P_FECHA_FINAL;" & Me.DTPFECHAFINALGUIA.Value.ToShortDateString, _
        '"P_AGENCIA;" & Me.cmbAgencia.Text.ToString)
    End Sub

    Sub ImprimirLiquidacion2(ByVal ds As DataSet)
        Dim obj As New Imprimir
        Dim dt As DataTable = ds.Tables(0)
        Try
            Dim sImpresora As String
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0
            Dim sGrupo1 As String = ""
            Dim i1 As Double = 0, i2 As Double = 0, i3 As Double = 0
            Dim bGrupo As Boolean = False

            obj.Inicializar()

            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim dt2 As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 8)
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
            obj.Superior = iSuperior
            obj.Izquierda = Iizquierda

            obj.Impresora = sImpresora
            Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
            iLong = IIf(iTamaño = 0, 71, iTamaño)

            'cabecera
            Cabecera2(dt, obj, pagina)
            y = iLong * pagina + 7
            For Each row As DataRow In dt.Rows
                i += 1
                y += 1
                obj.EscribirLinea(y, 0, i.ToString.PadLeft(3, " "))
                obj.EscribirLinea(y, 4, row("nro_guia"))
                obj.EscribirLinea(y, 18, row("razon_social").ToString.Trim.PadRight(39, " ").Substring(0, 38))
                obj.EscribirLinea(y, 58, Format(row("total_peso"), "####,###,###0.00").PadLeft(8, " "))
                obj.EscribirLinea(y, 66, Format(row("total_volumen"), "####,###,###0.00").PadLeft(8, " "))
                obj.EscribirLinea(y, 75, Format(row("cantidad_sobres"), "####,###,###0").PadLeft(3, " "))
                obj.EscribirLinea(y, 81, row("destino"))
                obj.EscribirLinea(y, 86, row("fecha_guia"))
                obj.EscribirLinea(y, 97, IIf(IsDBNull(row("documentos")), "", row("documentos").ToString.Trim.PadRight(27, " ").Substring(0, 26)))
                obj.EscribirLinea(y, 127, row("estado_registro"))
                If i Mod 55 = 0 Then
                    pagina += 1
                    Cabecera2(dt, obj, pagina)
                    y = iLong * pagina + 7
                End If
            Next
            'grupo
            'Grupo(i1, i2, i3, obj, y, dt)
            'totales
            Total(dt, obj, y)
            'resumen
            'Resumen1(dt, dtResumen, obj, y)

            obj.Comprimido = True
            obj.Preliminar = True
            obj.Tamaño = iLong
            obj.Imprimir()
            obj.Finalizar()

        Catch ex As Exception
            obj.Finalizar()
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub Cabecera2(ByVal dt As DataTable, ByVal obj As Imprimir, ByVal y As Integer)
        Dim n As Integer = 1
        Dim s As String = ""
        obj.EscribirLinea(iLong * y + n, 1, "T.E.P.S.A.C.")
        obj.EscribirLinea(iLong * y + n, Centrar("LIQUIDACION DE GUIAS DE ENVIO", iAncho), "LIQUIDACION DE GUIAS DE ENVIO")
        obj.EscribirLinea(iLong * y + n, Derecha(Date.Now.ToShortDateString, iAncho), Date.Now.ToShortDateString)

        obj.EscribirLinea(iLong * y + n + 1, 1, "AGENCIA:")
        obj.EscribirLinea(iLong * y + n + 1, 9, Me.cmbAgencia.Text.ToString)
        obj.EscribirLinea(iLong * y + n + 1, Centrar("PRELIMINAR", iAncho), "PRELIMINAR")

        obj.EscribirLinea(iLong * y + n + 1, Derecha(Date.Now.ToShortTimeString, iAncho), Date.Now.ToShortTimeString)

        obj.EscribirLinea(iLong * y + n + 2, 1, "USUARIO:")
        obj.EscribirLinea(iLong * y + n + 2, 9, Me.cmbUsuarios.Text.ToString)
        s = "(Desde " + Me.DTPFECHAINICIOGUIA.Value.ToShortDateString + " al " + Me.DTPFECHAFINALGUIA.Value.ToShortDateString + ")"
        obj.EscribirLinea(iLong * y + n + 2, Centrar(s, iAncho), s)

        obj.EscribirLinea(iLong * y + n + 2, Derecha("Pag " & y + 1, iAncho), "Pag " & y + 1)


        obj.EscribirLinea(iLong * y + n + 4, 0, Replicate("-", iAncho))

        obj.EscribirLinea(iLong * y + n + 5, 1, "N. GUIA")
        obj.EscribirLinea(iLong * y + n + 5, 18, "CLIENTE")
        obj.EscribirLinea(iLong * y + n + 5, 57, "T. PESO")
        obj.EscribirLinea(iLong * y + n + 5, 67, "T. VOL")
        obj.EscribirLinea(iLong * y + n + 5, 74, "SOBRE")
        obj.EscribirLinea(iLong * y + n + 5, 81, "DEST")
        obj.EscribirLinea(iLong * y + n + 5, 88, "FECHA")
        obj.EscribirLinea(iLong * y + n + 5, 97, "DOCUMENTOS")
        obj.EscribirLinea(iLong * y + n + 5, 128, "ESTADO")

        obj.EscribirLinea(iLong * y + n + 6, 0, Replicate("-", iAncho))
    End Sub

    Sub Total(ByVal dt As DataTable, ByVal obj As Imprimir, ByVal y As Integer)
        If dt.Rows.Count > 0 Then
            obj.EscribirLinea(y + 1, 57, Replicate("-", 9))
            obj.EscribirLinea(y + 1, 66, Replicate("-", 8))
            obj.EscribirLinea(y + 1, 74, Replicate("-", 5))

            Dim iPeso As Double = 0
            Dim iVolumen As Double = 0
            Dim iSobre As Double

            iPeso = dt.Compute("sum(total_peso)", "")
            iVolumen = dt.Compute("sum(total_volumen)", "")
            iSobre = dt.Compute("sum(cantidad_sobres)", "")

            obj.EscribirLinea(y + 2, 58, Format(iPeso, "####,###,###0.00").PadLeft(8, " "))
            obj.EscribirLinea(y + 2, 66, Format(iVolumen, "####,###,###0.00").PadLeft(8, " "))
            obj.EscribirLinea(y + 2, 75, iSobre.ToString.PadLeft(3, " "))
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If VALIDAR_ANTERIOR() = False Then Exit Sub
            Dim obj As New dtoCIERRE_LIQUIDACIONES
            Dim id As Integer = DVCierres.Table.Rows(DGV.CurrentCell.RowIndex)("IDCIERRES_LIQUIDACIONES")
            Dim ds As DataSet = obj.ListarLiquidacionTurnoCredito(id)
            ImprimirLiquidacion(ds)

            Dim frm As New FrmPreview
            frm.Documento = 37
            frm.Tamaño = iLong
            frm.Text = "Liquidación Ventas al Crédito"
            frm.ShowDialog()
            obj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Try
        '    If VALIDAR_ANTERIOR() = False Then Exit Sub
        '    ObjReport = New ClsLbTepsa.dtoFrmReport
        '    ObjCIERRE_LIQUIDACIONES.IDCIERRES_LIQUIDACIONES = DVCierres.Table.Rows(DGV.CurrentCell.RowIndex)("IDCIERRES_LIQUIDACIONES")
        '    ObjReport.rutaRpt = PathFrmReport
        '    ObjReport.conectar(rptservice, rptuser, rptpass)
        '    ObjReport.printrpt(False, "", "CLQ_001.RPT", "P_IDCIERRES_LIQUIDACIONES;" & ObjCIERRE_LIQUIDACIONES.IDCIERRES_LIQUIDACIONES, _
        '    "P_USUARIO;" & Me.cmbUsuarios.Text.ToString, _
        '    "P_AGENCIA;" & Me.cmbAgencia.Text.ToString, _
        '    "P_RANGO_FECHA;", _
        '    "P_FECHA_APERTURA;" & DVCierres.Table.Rows(DGV.CurrentCell.RowIndex)("FECHA_LIQUIDACION_APER"), _
        '    "P_FECHA_CIERRE;" & DVCierres.Table.Rows(DGV.CurrentCell.RowIndex)("FECHA_LIQUIDACION_CIERRE"), _
        '    "P_IMPRESO;")
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del sistema")
        'End Try
    End Sub

    Sub ImprimirLiquidacion(ByVal ds As DataSet)
        Dim obj As New Imprimir
        Dim dt As DataTable = ds.Tables(0)
        Try
            Dim sImpresora As String
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0
            Dim sGrupo1 As String = ""
            Dim i1 As Double = 0, i2 As Double = 0, i3 As Double = 0
            Dim bGrupo As Boolean = False

            obj.Inicializar()

            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim dt2 As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 8)
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
            obj.Superior = iSuperior
            obj.Izquierda = Iizquierda

            obj.Impresora = sImpresora
            Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
            iLong = IIf(iTamaño = 0, 71, iTamaño)

            'cabecera
            Cabecera(dt, obj, pagina)
            y = iLong * pagina + 7
            For Each row As DataRow In dt.Rows
                y += 1
                i += 1
                obj.EscribirLinea(y, 0, i.ToString.PadLeft(3, " "))
                obj.EscribirLinea(y, 4, row("nro_guia"))
                obj.EscribirLinea(y, 18, row("razon_social").ToString.Trim.PadRight(39, " ").Substring(0, 38))
                obj.EscribirLinea(y, 58, Format(row("total_peso"), "####,###,###0.00").PadLeft(8, " "))
                obj.EscribirLinea(y, 66, Format(row("total_volumen"), "####,###,###0.00").PadLeft(8, " "))
                obj.EscribirLinea(y, 75, Format(row("cantidad_sobres"), "####,###,###0").PadLeft(3, " "))
                obj.EscribirLinea(y, 81, row("destino"))
                obj.EscribirLinea(y, 86, row("fecha_guia"))
                obj.EscribirLinea(y, 97, IIf(IsDBNull(row("documentos")), "", row("documentos").ToString.Trim.PadRight(27, " ").Substring(0, 26)))
                obj.EscribirLinea(y, 127, row("estado_registro"))

                If i Mod 55 = 0 Then
                    pagina += 1
                    Cabecera(dt, obj, pagina)
                    y = iLong * pagina + 7
                End If
            Next
            'grupo
            'Grupo(i1, i2, i3, obj, y, dt)
            'totales
            Total(dt, obj, y)
            'resumen
            'Resumen(dt, dtResumen, obj, y)

            obj.Comprimido = True
            obj.Preliminar = True
            obj.Tamaño = iLong
            obj.Imprimir()
            obj.Finalizar()

        Catch ex As Exception
            obj.Finalizar()
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub Cabecera(ByVal dt As DataTable, ByVal obj As Imprimir, ByVal y As Integer)
        Dim n As Integer = 1
        Dim s As String = ""
        obj.EscribirLinea(iLong * y + n, 1, "T.E.P.S.A.C.")
        obj.EscribirLinea(iLong * y + n, Centrar("LIQUIDACION DE GUIAS DE ENVIO", iAncho), "LIQUIDACION DE GUIAS DE ENVIO")
        obj.EscribirLinea(iLong * y + n, Derecha(Date.Now.ToShortDateString, iAncho), Date.Now.ToShortDateString)

        obj.EscribirLinea(iLong * y + n + 1, 1, "AGENCIA:")
        obj.EscribirLinea(iLong * y + n + 1, 9, Me.cmbAgencia.Text.ToString)

        If dt.Rows.Count > 0 Then
            obj.EscribirLinea(iLong * y + n + 1, Centrar(dt.Rows(0).Item("IDCIERRES_LIQUIDACIONES"), iAncho), dt.Rows(0).Item("IDCIERRES_LIQUIDACIONES"))
        End If

        obj.EscribirLinea(iLong * y + n + 1, Derecha(Date.Now.ToShortTimeString, iAncho), Date.Now.ToShortTimeString)

        obj.EscribirLinea(iLong * y + n + 2, 1, "USUARIO:")
        obj.EscribirLinea(iLong * y + n + 2, 9, Me.cmbUsuarios.Text.ToString)

        obj.EscribirLinea(iLong * y + n + 3, 1, "F.APERTURA")
        If dt.Rows.Count > 0 Then
            obj.EscribirLinea(iLong * y + n + 3, 12, Format(DVCierres.Table.Rows(DGV.CurrentCell.RowIndex)("FECHA_LIQUIDACION_APER"), "dd/MM/yyyy hh:mm:ss tt"))
        End If

        obj.EscribirLinea(iLong * y + n + 3, 38, "F.CIERRE")
        If dt.Rows.Count > 0 Then
            obj.EscribirLinea(iLong * y + n + 3, 47, Format(DVCierres.Table.Rows(DGV.CurrentCell.RowIndex)("FECHA_LIQUIDACION_CIERRE"), "dd/MM/yyyy hh:mm:ss tt"))
        End If

        obj.EscribirLinea(iLong * y + n + 2, Derecha("Pag " & y + 1, iAncho), "Pag " & y + 1)


        obj.EscribirLinea(iLong * y + n + 4, 0, Replicate("-", iAncho))

        obj.EscribirLinea(iLong * y + n + 5, 1, "N. GUIA")
        obj.EscribirLinea(iLong * y + n + 5, 18, "CLIENTE")
        obj.EscribirLinea(iLong * y + n + 5, 57, "T. PESO")
        obj.EscribirLinea(iLong * y + n + 5, 67, "T. VOL")
        obj.EscribirLinea(iLong * y + n + 5, 74, "SOBRE")
        obj.EscribirLinea(iLong * y + n + 5, 81, "DEST")
        obj.EscribirLinea(iLong * y + n + 5, 88, "FECHA")
        obj.EscribirLinea(iLong * y + n + 5, 97, "DOCUMENTOS")
        obj.EscribirLinea(iLong * y + n + 5, 128, "ESTADO")

        obj.EscribirLinea(iLong * y + n + 6, 0, Replicate("-", iAncho))
    End Sub

End Class