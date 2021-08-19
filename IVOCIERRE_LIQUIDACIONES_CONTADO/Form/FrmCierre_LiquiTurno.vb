'Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmCierre_LiquiTurno

    Dim DVCierres As New DataView
    Dim DVGuias_liquidados As New DataView
    Dim Impresion As New ClsPrint
    Public obj As New ClsLbTepsa.dtoLIQUI_TURNOS
    Private ObjReport As ClsLbTepsa.dtoFrmReport '
    Dim bOtrasAgencias As Boolean
    Dim bIngreso As Boolean = False
    Public hnd As Long
    Dim iLong As Integer = 71
    Dim iAncho As Integer = 137
    Dim intNivel As Integer

    Dim blnInicio As Boolean

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

    Private Sub FrmCierre_LiquiTurno_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmCierre_LiquiTurno_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmCierre_Liquidacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim objOtrasAgencias As New dtoCONTROLUSUARIOS

            ObjCIERRE_LIQUIDACIONES.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            ObjCIERRE_LIQUIDACIONES.IDROL_USUARIO = dtoUSUARIOS.IdRol
            ObjCIERRE_LIQUIDACIONES.IP = dtoUSUARIOS.m_sIP
            ObjCIERRE_LIQUIDACIONES.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS

            If ObjCIERRE_LIQUIDACIONES.fnABRIR_LIQUIDACIONES = True Then
            End If

            objOtrasAgencias.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            If objOtrasAgencias.GetOtrasAgencias() Then
                If objOtrasAgencias.iIDOTRAS_AGENCIAS = 1 Then
                    bOtrasAgencias = True
                Else
                    bOtrasAgencias = False
                End If
            Else
                bOtrasAgencias = False
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
            Me.DTPFIN.Value = Now
            Me.DTPINICIO.Value = Now.AddDays(-1)
            llenar_agencias()

            If fnValidar_Rol("23") = True Then 'VENTA CARGA CONTADO
            End If
            If fnValidar_Rol("12") = True Then 'FUNCIONARIO DE TELEVENTAS
            End If
            If fnValidar_Rol("14") = True Then 'ADMINISTRADOR DE AGENCIA
            End If
            If fnValidar_Rol("1") = True Then 'ADMINISTRADOR
            End If
            If fnValidar_Rol("2") = True Then 'DBA
            End If


            'Select Case dtoUSUARIOS.m_iIdRol
            '    Case 1, 2
            '        Me.cmbAgencia.Enabled = True
            '        Me.cmbUsuarios.Enabled = True
            '    Case 14
            '        Call seleccionar_agencias()
            '        Me.cmbAgencia.Enabled = False
            '        Call LISTAR_USUARIOS()
            '        Me.cmbUsuarios.Enabled = True
            '    Case 12, 23
            '        Call seleccionar_agencias()
            '        Call LISTAR_USUARIOS()
            '        Call seleccionar_USUARIOS()
            '        Me.cmbAgencia.Enabled = False
            '        Me.cmbUsuarios.Enabled = False
            'End Select

            If Acceso.SiRol(G_Rol, Me, 1, 1) Then
                Me.cmbAgencia.Enabled = True
                Me.cmbUsuarios.Enabled = True
                intNivel = 1
            ElseIf Acceso.SiRol(G_Rol, Me, 1, 2) Then
                Call seleccionar_agencias()
                Call LISTAR_USUARIOS()
                Me.cmbAgencia.Enabled = False
                Me.cmbUsuarios.Enabled = True
                intNivel = 2
            Else
                Call seleccionar_agencias()
                Call LISTAR_USUARIOS()
                Call seleccionar_USUARIOS()
                Me.cmbAgencia.Enabled = False
                Me.cmbUsuarios.Enabled = False
                intNivel = 3
            End If

            'Select Case dtoUSUARIOS.m_iIdRol
            '    Case 1036 '-->Solo sistemas 
            '        Me.cmbAgencia.Enabled = True
            '        Me.cmbUsuarios.Enabled = True
            '    Case Else
            '        Call seleccionar_agencias()
            '        Call LISTAR_USUARIOS()
            '        Call seleccionar_USUARIOS()
            '        Me.cmbAgencia.Enabled = False
            '        Me.cmbUsuarios.Enabled = False
            'End Select



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
            ModuUtil.LlenarCombo2(ObjCIERRE_LIQUIDACIONES.cur_Lista_Agencias, cmbAgencia, ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias, dtoUSUARIOS.m_iIdAgencia)
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
            If ObjCIERRE_LIQUIDACIONES.fnLISTA_USUARIOS(1, DTPINICIO.Text, DTPFIN.Text) = True Then
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
        dgv.DataSource = Nothing
        Me.btnModificar.Enabled = False
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
        If DVCierres.Table.Rows(dgv.CurrentCell.RowIndex)("cerrado") = 1 Then
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

    Dim total_Monto_Factura As Double, total_Monto_Boleta As Double, Total_Monto_PCE As Double, Total_Venta_Carga_Credito As Double
    Dim total_Visa_Carga As Double, total_MaterCard_Carga As Double, total_Devolucion_Carga As Double, total_nota_credito As Double

    Private Sub BTNARQUE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNARQUE.Click
        Try

            If VALIDAR() = False Then Exit Sub

            Dim myFrmIngreMontosLiqui As New FrmIngreMontosLiqui
            'myFrmIngreMontosLiqui.ShowDialog(Me)
            Acceso.Asignar(myFrmIngreMontosLiqui, Me.hnd)
            'If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            myFrmIngreMontosLiqui.ShowDialog()
            If myFrmIngreMontosLiqui.DialogResult = Windows.Forms.DialogResult.Cancel Then Return
            'Else
            'MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Return
            'End If

            Dim ObjFrmPassCierreLiqui As New FrmPassCierreLiqui
            'ObjFrmPassCierreLiqui.ShowDialog(Me)
            Acceso.Asignar(ObjFrmPassCierreLiqui, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                ObjFrmPassCierreLiqui.ShowDialog(Me)
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            obj.IDLIQUI_TURNOS = DVCierres.Table.Rows(Me.dgv.CurrentCell.RowIndex)("IDLIQUI_TURNOS")
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

            'Me.DTPFECHAFINALGUIA.Value = DVCierres.Table.Rows(Me.dgv.CurrentRow.Index)("FECHA_LIQUIDACION_APER")
            'Me.DTPFECHAINICIOGUIA.Value = DVCierres.Table.Rows(Me.dgv.CurrentRow.Index)("FECHA_LIQUIDACION_APER")

            ActualizarFecha()
            obj.FECHA_INICIAL = Me.DTPFECHAINICIOGUIA.Value.ToShortDateString
            obj.FECHA_FINAL = Me.DTPFECHAFINALGUIA.Value.ToShortDateString

            '---Agregado Liquidacion de Oficinas--------------------------------            
            Dim obj1 As New dtoCIERRE_LIQUIDACIONES
            Dim iid As Integer = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(Me.cmbUsuarios.SelectedIndex.ToString))
            Dim iAgencia As Integer = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias.Item(cmbAgencia.SelectedIndex.ToString))
            Dim sIni As String = Me.DTPFECHAINICIOGUIA.Value.ToShortDateString
            Dim sFin As String = Me.DTPFECHAFINALGUIA.Value.ToShortDateString

            Dim ds1 As DataSet = obj1.ListarLiquidacionTurno(iid, iAgencia, sIni, sFin)
            Dim dt2 As DataTable = ds1.Tables(1)
            Dim dtResumen As DataTable = ds1.Tables(0)
            If dt2.Rows.Count > 0 Then
                'boleta = dt2.Compute("sum(boleta)", "")
                'factura = dt2.Compute("sum(factura)", "")
                If dt2.Rows.Count > 0 Then
                    Total_Monto_PCE = IIf(IsDBNull(dtResumen.Compute("sum(pce)", "")), 0, dtResumen.Compute("sum(pce)", ""))
                End If
            End If

            Dim objMonto As New dtoCierreOficina
            Dim dt As DataTable = objMonto.DetalleVenta(1, iid, sFin, iAgencia)
            obj.total_Monto_Factura = IIf(IsDBNull(dt.Compute("sum(FACTURA)", "")), 0, dt.Compute("sum(FACTURA)", "")) 'total_Monto_Factura 08032012 incluido tarjetas
            obj.total_Monto_Boleta = IIf(IsDBNull(dt.Compute("sum(BOLETA)", "")), 0, dt.Compute("sum(BOLETA)", "")) 'total_Monto_Boleta    08032012 Incluido tarjetas
            obj.Total_Monto_PCE = Total_Monto_PCE

            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i).Item("opcion") = 1 Then
                    If dt.Rows(i).Item("TARJETA").ToString = "VISA" Then
                        obj.total_Visa_Carga = Convert.ToDouble(dt.Rows(i)("BOLETA").ToString) + Convert.ToDouble(dt.Rows(i)("FACTURA").ToString) 'total_Visa_Carga
                    ElseIf dt.Rows(i).Item("TARJETA").ToString = "MASTER CARD" Then
                        obj.total_MaterCard_Carga = Convert.ToDouble(dt.Rows(i)("BOLETA").ToString) + Convert.ToDouble(dt.Rows(i)("FACTURA").ToString) 'total_MaterCard_Carga
                    ElseIf dt.Rows(i).Item("TARJETA").ToString = "NC" Then
                        obj.total_nota_credito_boleta = Convert.ToDouble(dt.Rows(i)("BOLETA").ToString)
                        obj.total_nota_credito_factura = Convert.ToDouble(dt.Rows(i)("FACTURA").ToString) 'total_nota_credito
                    End If
                Else
                    If dt.Rows(i).Item("TARJETA").ToString = "VISA" Then
                        obj.total_Visa_Otros = Convert.ToDouble(dt.Rows(i)("BOLETA").ToString) + Convert.ToDouble(dt.Rows(i)("FACTURA").ToString) 'total_Visa_Carga
                    ElseIf dt.Rows(i).Item("TARJETA").ToString = "MASTER CARD" Then
                        obj.total_MaterCard_Otros = Convert.ToDouble(dt.Rows(i)("BOLETA").ToString) + Convert.ToDouble(dt.Rows(i)("FACTURA").ToString) 'total_MaterCard_Carga
                    Else
                        obj.total_monto_otros = Convert.ToDouble(dt.Rows(i)("BOLETA").ToString) + Convert.ToDouble(dt.Rows(i)("FACTURA").ToString) 'total_MaterCard_Carga
                    End If
                End If
            Next

            obj.total_Devolucion_Carga = total_Devolucion_Carga

            Dim objTotal As New dtoCierreOficina
            Dim dt3 As DataTable = objMonto.TotalLiquidacion(iid, sFin, iAgencia)
            obj.total_Monto_Factura = dt3.Rows(0).Item("factura")
            obj.total_Monto_Boleta = dt3.Rows(0).Item("boleta")

            Dim dt4 As DataTable = objTotal.TotalMovimiento(sFin, iAgencia, iid)
            If dt4.Rows.Count > 0 Then
                obj.movimiento_ingreso = dt4.Rows(0).Item(0)
                obj.movimiento_egreso = dt4.Rows(0).Item(1)
            Else
                obj.movimiento_ingreso = 0
                obj.movimiento_egreso = 0
            End If

            '-------------------------------------------------------
            If flag_Salir = True Then
                Close()
            Else
                'obj.SP_LIQUI_TURNO()'Comentado X Liquidacion Oficina
                obj.SP_LIQUI_TURNO_1() 'Agregado x Liquidacion Oficina
            End If
            Call MOSTRAR_LIQUIDACIONES()

            obj.total_Visa_Carga = 0
            obj.total_MaterCard_Carga = 0
            obj.total_Visa_Otros = 0
            obj.total_MaterCard_Otros = 0
            obj.total_monto_otros = 0
            'hlamas 16-05-2017
            obj.total_nota_credito_boleta = 0
            obj.total_nota_credito_factura = 0

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Sub FORMAT_GRILLA()
        dgv.Columns.Clear()
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
            .RowHeadersWidth = 20
        End With

        Dim idEstadoImage As New DataGridViewImageColumn
        With idEstadoImage
            .DataPropertyName = "imagen"
            .HeaderText = "CT"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .DisplayIndex = 0
            .Visible = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Image = bmActivo

        End With
        'dgv.Columns.Add(idEstadoImage)

        Dim col0 As New DataGridViewTextBoxColumn
        With col0
            .DataPropertyName = "NOMBRE"
            .HeaderText = "Usuario"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format.ToUpper()
        End With
        dgv.Columns.Add(col0)

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .DataPropertyName = "LOGIN"
            .HeaderText = "Login"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format.ToUpper()
        End With
        dgv.Columns.Add(col1)


        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .DataPropertyName = "FECHA_APER"
            .HeaderText = "F. Apertura"
            .Name = "FECHA_APER"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format.ToUpper()
        End With
        dgv.Columns.Add(col2)

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .DataPropertyName = "FECHA_CIERRE"
            .HeaderText = "F. Cierre"
            .Name = "FECHA_CIERRE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format.ToUpper()
        End With
        dgv.Columns.Add(col3)

        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .DataPropertyName = "nombre_agencia"
            .HeaderText = "Agencia"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format.ToUpper()

        End With
        dgv.Columns.Add(col4)

        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .DataPropertyName = "LEYE_APERTURADO_CIERRE"
            .Name = "LEYE_APERTURADO_CIERRE"
            .HeaderText = "A/C"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Format.ToUpper()
            dgv.Columns.Add(col5)
        End With

        Dim col6 As New DataGridViewTextBoxColumn
        With col6
            .DataPropertyName = "idusuario_personal"
            .Name = "idusuario_personal"
            .HeaderText = "idusuario_personal"
            .Visible = False
            dgv.Columns.Add(col6)
        End With

        Dim col7 As New DataGridViewTextBoxColumn
        With col7
            .DataPropertyName = "idagencias"
            .Name = "idagencias"
            .HeaderText = "idagencias"
            .Visible = False
            dgv.Columns.Add(col7)
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

    Private Sub cmbUsuarios_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbUsuarios.KeyUp
        If e.KeyCode = Keys.Enter Then
            BTNMOSTRAR.Focus()
        End If
    End Sub

    Private Sub cmbUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUsuarios.SelectedIndexChanged
        dgv.DataSource = Nothing
        Me.btnModificar.Enabled = False
    End Sub

    Private Sub BTNANTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNANTE.Click
        Try
            If VALIDAR_ANTERIOR() = False Then Exit Sub
            Me.Cursor = Cursors.AppStarting
            Dim obj As New dtoCIERRE_LIQUIDACIONES
            'hlamas 16-05-2017
            Dim strFecha As String = CType(Me.dgv.CurrentRow.Cells("FECHA_APER").Value, Date).ToShortDateString
            Dim id As Integer = DVCierres.Table.Rows(dgv.CurrentCell.RowIndex)("IDLIQUI_TURNOS")
            Dim ds As DataSet = obj.ListarLiquidacionTurno(id, strFecha)
            ImprimirLiquidacion(ds)

            Me.Cursor = Cursors.Default
            Dim frm As New FrmPreview
            frm.Documento = 37
            frm.Tamaño = iLong
            frm.Text = "Liquidación Ventas al Contado"
            frm.ShowDialog()
            obj = Nothing
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BTNPRELI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNPRELI.Click
        Try
            If VALIDAR_PRELIMINAR() = False Then Exit Sub
            Me.Cursor = Cursors.AppStarting
            Dim obj As New dtoCIERRE_LIQUIDACIONES
            Dim id As Integer = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(Me.cmbUsuarios.SelectedIndex.ToString))
            Dim iAgencia As Integer = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias.Item(cmbAgencia.SelectedIndex.ToString))

            ActualizarFecha()
            Dim sIni As String = Me.DTPFECHAINICIOGUIA.Value.ToShortDateString
            Dim sFin As String = Me.DTPFECHAFINALGUIA.Value.ToShortDateString
            Dim ds As DataSet = obj.ListarLiquidacionTurno(id, iAgencia, sIni, sFin)
            ImprimirLiquidacion2(ds)

            Me.Cursor = Cursors.Default
            Dim frm As New FrmPreview
            frm.Documento = 37
            frm.Tamaño = iLong
            frm.Text = "Liquidación Ventas al Contado"
            frm.ShowDialog()
            obj = Nothing
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            obj.FECHA_INICIAL = Me.DTPFECHAINICIOGUIA.Value.ToShortDateString
            obj.FECHA_FINAL = Me.DTPFECHAFINALGUIA.Value.ToShortDateString

            obj.IDLIQUI_TURNOS = DVCierres.Table.Rows(dgv.CurrentCell.RowIndex)("IDLIQUI_TURNOS")
            ObjReport.rutaRpt = PathFrmReport
            ObjReport.conectar(rptservice, rptuser, rptpass)
            ObjReport.printrpt_sub_report("CLQ005_1.rpt", True, "", "CLQ005.RPT", "P_IDliqui_turnos;" & obj.IDLIQUI_TURNOS, _
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

    Private Sub DTPFIN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTPFIN.KeyUp
        If e.KeyCode = Keys.Enter Then
            cmbAgencia.Focus()
        End If
    End Sub

    Private Sub DTPFECHAINICIOGUIA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTPFECHAINICIOGUIA.KeyUp
        If e.KeyCode = Keys.Enter Then
            DTPFECHAFINALGUIA.Focus()
        End If
    End Sub

    Private Sub DTPFECHAFINALGUIA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DTPFECHAFINALGUIA.KeyUp
        If e.KeyCode = Keys.Enter Then
            BTNPRELI.Focus()
        End If
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

    'Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
    '    MyBase.OnPaint(e)
    '    Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
    '    Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
    '    e.Graphics.FillRegion(gradiente, New Region(rec))
    'End Sub

    Private Sub dgv_CellEnter1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellEnter
        Try
            If dgv.CurrentRow.Index = -1 Then Exit Sub
            Me.DTPFECHAFINALGUIA.Value = DVCierres.Table.Rows(Me.dgv.CurrentRow.Index)("FECHA_APER")
            Me.DTPFECHAINICIOGUIA.Value = DVCierres.Table.Rows(Me.dgv.CurrentRow.Index)("FECHA_APER")
            'Me.btnMovimiento.Enabled = DVCierres.Table.Rows(Me.dgv.CurrentRow.Index)("LEYE_APERTURADO_CIERRE") = "A"

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try

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

            Call FORMAT_GRILLA()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")

        End Try
    End Sub

    Private Sub MOSTRAR_LIQUIDACIONES()
        If VALIDAR_MOSTRAR() = False Then Exit Sub
        blnInicio = True
        obj.IDAGENCIAS = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias.Item(cmbAgencia.SelectedIndex.ToString))
        obj.IDUSUARIO_PERSONAL = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(Me.cmbUsuarios.SelectedIndex.ToString))
        obj.FECHA_INICIAL = Me.DTPINICIO.Value.ToShortDateString.ToString
        obj.FECHA_FINAL = Me.DTPFIN.Value.ToShortDateString.ToString
        DVCierres = New DataView


        'Dim idUsuarioCierre As Integer = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(Me.cmbUsuarios.SelectedIndex.ToString))
        'BTNARQUE.Enabled = (idsucuenta = dtoUSUARIOS.iLOGIN)
        Try
            'datahelper
            'DVCierres = obj.SP_LISTAR_LIQUI_TURNO_PEND(VOCONTROLUSUARIO, cnn)
            DVCierres = obj.SP_LISTAR_LIQUI_TURNO_PEND()
            Call FORMAT_GRILLA()
            If Me.dgv.Rows.Count > 0 Then
                Dim strFechaServidor As String = FechaServidor.ToString.Substring(0, 10)
                Dim strFechaApertura As String = CType(dgv.CurrentRow.Cells("FECHA_APER").Value, Date).ToShortDateString
                Dim blnValido As Boolean = CType(strFechaApertura, Date) = CType(strFechaServidor, Date)

                Me.btnModificar.Enabled = dgv.CurrentRow.Cells("LEYE_APERTURADO_CIERRE").Value = "A" And blnValido
                Me.btnMovimiento.Enabled = True
            Else
                Me.btnModificar.Enabled = False
                Me.btnMovimiento.Enabled = False
            End If
            blnInicio = False

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Try
        '    If VALIDAR_ANTERIOR() = False Then Exit Sub
        '    Dim obj As New dtoCIERRE_LIQUIDACIONES
        '    Dim id As Integer = DVCierres.Table.Rows(dgv.CurrentCell.RowIndex)("IDLIQUI_TURNOS")
        '    Dim ds As DataSet = obj.ListarLiquidacionTurno(id)
        '    ImprimirLiquidacion(ds)

        '    Dim frm As New FrmPreview
        '    frm.Documento = 37
        '    frm.Tamaño = iLong
        '    frm.Text = "Liquidación Ventas al Contado"
        '    frm.ShowDialog()
        '    obj = Nothing

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Sub ImprimirLiquidacion(ByVal ds As DataSet)
        Dim obj As New Imprimir
        Dim dt As DataTable = ds.Tables(0)
        Dim dtResumen As DataTable = ds.Tables(1)
        Dim dtMovimiento As DataTable = ds.Tables(2)
        Try
            Dim sImpresora As String
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0
            Dim sGrupo1 As Integer = -1
            Dim sGrupo2 As String = ""
            Dim i1 As Double = 0, i2 As Double = 0, i3 As Double = 0
            Dim i11 As Double = 0, i22 As Double = 0, i33 As Double = 0
            Dim bGrupo As Boolean = False

            obj.Inicializar()

            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim dt2 As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 37)
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
                If sGrupo1 <> row("idprocesos") And sGrupo2 <> row("tipo_comprobante") And sGrupo1 <> -1 And sGrupo2 <> "" Then
                    Grupo2(i11, i22, i33, obj, y, dt)
                    i11 = 0
                    i22 = 0
                    i33 = 0
                    'y += 1
                    sGrupo2 = row("tipo_comprobante")

                    Grupo(i1, i2, i3, obj, y, dt)
                    i1 = 0
                    i2 = 0
                    i3 = 0
                    y += 1
                    sGrupo1 = row("idprocesos")

                    y += 1
                    obj.EscribirLinea(y, 0, row("proceso"))
                    y += 1
                    obj.EscribirLinea(y, 0, sGrupo2)
                Else
                    If sGrupo1 <> row("idprocesos") Then
                        If i > 0 Then
                            Grupo(i1, i2, i3, obj, y, dt)
                            i1 = 0
                            i2 = 0
                            i3 = 0
                        End If
                        y += 1
                        sGrupo1 = row("idprocesos")
                        obj.EscribirLinea(y, 0, row("proceso"))
                    End If

                    If sGrupo2 <> row("tipo_comprobante") Then
                        If i > 0 Then
                            Grupo2(i11, i22, i33, obj, y, dt)
                            i11 = 0
                            i22 = 0
                            i33 = 0
                        End If
                        y += 1
                        sGrupo2 = row("tipo_comprobante")
                        obj.EscribirLinea(y, 0, sGrupo2)
                    End If
                End If

                y += 1
                i += 1
                obj.EscribirLinea(y, 0, i.ToString.PadLeft(3, " "))
                If row.Item("idtipo_comprobante") <> 85 Then
                    obj.EscribirLinea(y, 4, IIf(IsDBNull(row("serie_factura")), "", row("serie_factura")))
                    obj.EscribirLinea(y, 8, IIf(IsDBNull(row("nro_factura")), "", row("nro_factura")))
                Else
                    obj.EscribirLinea(y, 4, IIf(IsDBNull(row("nro_factura1")), "", row("nro_factura1")))
                End If
                obj.EscribirLinea(y, 16, row("razon_social").ToString.Trim.PadRight(40, " ").Substring(0, 39))
                obj.EscribirLinea(y, 58, Format(row("total_peso"), "####,###,###0.00").PadLeft(6, " "))
                obj.EscribirLinea(y, 66, Format(row("total_volumen"), "####,###,###0.00").PadLeft(6, " "))
                obj.EscribirLinea(y, 74, Format(row("cantidad_x_sobre"), "####,###,###0").PadLeft(3, " "))
                obj.EscribirLinea(y, 81, row("iata_des"))
                obj.EscribirLinea(y, 87, row("fecha_factura"))
                obj.EscribirLinea(y, 98, row("simbolo_moneda"))
                obj.EscribirLinea(y, 101, Format(row("sub_total"), "####,###,###0.00").PadLeft(8, " "))
                obj.EscribirLinea(y, 112, Format(row("monto_impuesto"), "####,###,###0.00").PadLeft(5, " "))
                obj.EscribirLinea(y, 120, Format(row("total_costo"), "####,###,###0.00").PadLeft(8, " "))
                obj.EscribirLinea(y, 129, IIf(IsDBNull(row("estado_registro")), "", row("estado_registro")))

                i11 += row("sub_total")
                i22 += row("monto_impuesto")
                i33 += row("total_costo")

                i1 += row("sub_total")
                i2 += row("monto_impuesto")
                i3 += row("total_costo")
                If i Mod 55 = 0 Then
                    pagina += 1
                    Cabecera(dt, obj, pagina)
                    y = iLong * pagina + 7
                End If
            Next
            'grupo
            'Grupo(i1, i2, i3, obj, y, dt)
            Grupo2(i11, i22, i33, obj, y, dt)
            Grupo(i1, i2, i3, obj, y, dt)
            'totales
            Total(dt, obj, y)

            'resumen
            If (y + 18) > (iLong * (pagina + 1)) Then
                pagina += 1
                Cabecera(dt, obj, pagina)
                y = iLong * pagina + 7
                Total(dt, obj, y)
            End If
            Resumen(dt, dtResumen, dtMovimiento, obj, y)

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

    Sub Resumen(ByVal dt As DataTable, ByVal dt2 As DataTable, ByVal dt3 As DataTable, ByVal obj As Imprimir, ByVal y As Integer)
        obj.EscribirLinea(y + 5, Centrar("RESUMEN".Length, iAncho), "RESUMEN")
        obj.EscribirLinea(y + 7, 10, "SERIE")
        obj.EscribirLinea(y + 7, 20, "INICIAL")
        obj.EscribirLinea(y + 7, 30, "FINAL")
        obj.EscribirLinea(y + 7, 40, "TOTAL")
        obj.EscribirLinea(y + 7, 50, "ANULADO")
        obj.EscribirLinea(y + 7, 60, "DEVUELTO")
        'obj.EscribirLinea(y + 7, 70, "FALTANTE")

        obj.EscribirLinea(y + 8, 1, Replicate("-", 125))
        obj.EscribirLinea(y + 9, 1, "FACTURA")
        If dt.Rows.Count > 0 Then
            obj.EscribirLinea(y + 9, 10, IIf(IsDBNull(dt.Rows(0).Item("factu_seri")), "", dt.Rows(0).Item("factu_seri")))
            obj.EscribirLinea(y + 9, 20, IIf(IsDBNull(dt.Rows(0).Item("factu_ini")), "", dt.Rows(0).Item("factu_ini")))
            obj.EscribirLinea(y + 9, 30, IIf(IsDBNull(dt.Rows(0).Item("factu_final")), "", dt.Rows(0).Item("factu_final")))
            obj.EscribirLinea(y + 9, 40, dt.Rows(0).Item("factu_conta"))
            obj.EscribirLinea(y + 9, 50, dt.Rows(0).Item("factu_anu"))
            obj.EscribirLinea(y + 9, 60, dt.Rows(0).Item("factu_devu"))
            'obj.EscribirLinea(y + 9, 70, IIf(IsDBNull(dt.Rows(0).Item("factu_faltan")), "", dt.Rows(0).Item("factu_faltan")))
        End If

        obj.EscribirLinea(y + 10, 1, "BOLETA")
        If dt.Rows.Count > 0 Then
            obj.EscribirLinea(y + 10, 10, IIf(IsDBNull(dt.Rows(0).Item("bole_seri")), "", dt.Rows(0).Item("bole_seri")))
            obj.EscribirLinea(y + 10, 20, IIf(IsDBNull(dt.Rows(0).Item("bole_ini")), "", dt.Rows(0).Item("bole_ini")))
            obj.EscribirLinea(y + 10, 30, IIf(IsDBNull(dt.Rows(0).Item("bole_final")), "", dt.Rows(0).Item("bole_final")))
            obj.EscribirLinea(y + 10, 40, IIf(IsDBNull(dt.Rows(0).Item("bole_conta")), "", dt.Rows(0).Item("bole_conta")))
            obj.EscribirLinea(y + 10, 50, IIf(IsDBNull(dt.Rows(0).Item("bole_anu")), "", dt.Rows(0).Item("bole_anu")))
            obj.EscribirLinea(y + 10, 60, IIf(IsDBNull(dt.Rows(0).Item("bole_devu")), "", dt.Rows(0).Item("bole_devu")))
            'obj.EscribirLinea(y + 10, 70, IIf(IsDBNull(dt.Rows(0).Item("bole_faltan")), "", dt.Rows(0).Item("bole_faltan")))
        End If
        obj.EscribirLinea(y + 11, 1, Replicate("-", 125))

        'resumen
        Dim iFila As Integer = y + 13
        Dim iCol As Integer = 4
        Dim iSubtotal As Double = 0
        Dim boleta As Double = IIf(IsDBNull(dt2.Compute("sum(boleta)", "")), "0.00", dt2.Compute("sum(boleta)", ""))
        Dim factura As Double = IIf(IsDBNull(dt2.Compute("sum(factura)", "")), "0.00", dt2.Compute("sum(factura)", ""))
        Dim nc As Double = IIf(IsDBNull(dt2.Compute("sum(nc)", "")), "0.00", dt2.Compute("sum(nc)", ""))
        Dim pce As Double
        If dt.Rows.Count > 0 Then
            pce = dt2.Compute("sum(pce)", "")
        End If

        If boleta > 0 Then
            iCol += 16
            obj.EscribirLinea(iFila, iCol, "BOLETA")
        End If
        If factura > 0 Then
            iCol += 11
            obj.EscribirLinea(iFila, iCol, "FACTURA")
        End If
        If pce > 0 Then
            iCol += 9
            obj.EscribirLinea(iFila, iCol, "PCE EMITIDO")
        End If
        If nc <> 0 Then
            iCol += 12
            obj.EscribirLinea(iFila, iCol, "NOTA CREDITO")
        End If
        If dt.Rows.Count > 0 Then
            obj.EscribirLinea(iFila, iCol + 14, "TOTAL")
        End If

        If dt2.Rows.Count > 0 And dt.Rows.Count > 0 Then
            Dim iProceso As Integer = -1
            For Each row As DataRow In dt2.Rows
                iSubtotal = 0
                iCol = 7
                iFila += 1

                If iProceso <> row.Item("idprocesos") Then
                    obj.EscribirLinea(iFila, 1, row.Item("proceso"))
                    iFila += 1
                End If

                obj.EscribirLinea(iFila, 3, row.Item("pago"))
                If boleta > 0 Then
                    iCol += 11
                    iSubtotal += row.Item("boleta")
                    obj.EscribirLinea(iFila, iCol, IIf(row.Item("boleta") = 0, "", Format(row.Item("boleta"), "####,###,###0.00").PadLeft(8, " ")))
                End If
                If factura > 0 Then
                    iCol += 11
                    iSubtotal += row.Item("factura")
                    obj.EscribirLinea(iFila, iCol, IIf(row.Item("factura") = 0, "", Format(row.Item("factura"), "####,###,###0.00").PadLeft(8, " ")))
                End If
                If pce > 0 Then
                    iCol += 11
                    iSubtotal += row.Item("pce")
                    obj.EscribirLinea(iFila, iCol, IIf(row.Item("pce") = 0, "", Format(row.Item("pce"), "####,###,###0.00").PadLeft(8, " ")))
                End If
                If nc <> 0 Then
                    iCol += 11
                    iSubtotal += row.Item("nc")
                    obj.EscribirLinea(iFila, iCol, IIf(row.Item("nc") = 0, "", Format(row.Item("nc"), "####,###,###0.00").PadLeft(8, " ")))
                End If
                obj.EscribirLinea(iFila, iCol + 14, Format(iSubtotal, "####,###,###0.00").PadLeft(8, " "))

                iProceso = row.Item("idprocesos")
            Next

            Dim dblMontoMovimiento As Double = 0
            If dt3.Rows.Count > 0 And dt.Rows.Count > 0 Then
                iFila = iFila + 2
                Dim strTipo As String, dblMonto As Double
                obj.EscribirLinea(iFila, 1, "OTROS MOVIMIENTOS")
                obj.EscribirLinea(iFila + 1, 1, "-----------------")
                iFila += 1
                For Each row As DataRow In dt3.Rows
                    iFila += 1
                    strTipo = row.Item("tipo").ToString.Trim.PadRight(22, " ").Substring(0, 22)
                    dblMonto = row.Item("monto")
                    dblMontoMovimiento += dblMonto
                    obj.EscribirLinea(iFila, 1, strTipo)
                    obj.EscribirLinea(iFila, iCol + 14, Format(dblMonto, "####,###,###0.00").PadLeft(8, " "))
                Next
            End If

            iCol = 7
            iFila += 1
            Dim iVeces As Integer
            If boleta > 0 Then iVeces += 11
            If factura > 0 Then iVeces += 11
            If pce > 0 Then iVeces += 11
            If nc <> 0 Then iVeces += 11
            obj.EscribirLinea(iFila, 1, Replicate("-", iVeces + 28))
            obj.EscribirLinea(iFila + 1, 1, "TOTAL")
            If boleta > 0 Then
                iCol += 11
                obj.EscribirLinea(iFila + 1, iCol, Format(boleta, "####,###,###0.00").PadLeft(8, " "))
            End If
            If factura > 0 Then
                iCol += 11
                obj.EscribirLinea(iFila + 1, iCol, Format(factura, "####,###,###0.00").PadLeft(8, " "))
            End If
            If pce > 0 Then
                iCol += 11
                obj.EscribirLinea(iFila + 1, iCol, Format(pce, "####,###,###0.00").PadLeft(8, " "))
            End If
            If nc <> 0 Then
                iCol += 11
                obj.EscribirLinea(iFila + 1, iCol, Format(nc, "####,###,###0.00").PadLeft(8, " "))
            End If
            obj.EscribirLinea(iFila + 1, iCol + 14, Format(boleta + factura + pce + nc + dblMontoMovimiento, "####,###,###0.00").PadLeft(8, " "))
        End If

        obj.EscribirLinea(y + 13, 75, "TOTAL ENTREGADO")
        obj.EscribirLinea(y + 14, 75, "---------------")

        obj.EscribirLinea(y + 15, 75, "EN SOLES")
        If dt.Rows.Count > 0 Then
            obj.EscribirLinea(y + 16, 75, FormatNumber(dt.Rows(0).Item("entre_soles"), 2))
        End If

        obj.EscribirLinea(y + 15, 87, "EN DOLARES")
        If dt.Rows.Count > 0 Then
            obj.EscribirLinea(y + 16, 87, FormatNumber(dt.Rows(0).Item("entre_dola"), 2))
        End If

        obj.EscribirLinea(y + 15, 99, "T.C.")
        If dt.Rows.Count > 0 Then
            obj.EscribirLinea(y + 16, 99, FormatNumber(dt.Rows(0).Item("entre_tipo_cambi"), 2))
        End If

        obj.EscribirLinea(y + 15, 111, "TOTAL SOLES")
        Dim dtotal As Double
        If dt.Rows.Count > 0 Then
            dtotal = dt.Rows(0).Item("entre_dola") * dt.Rows(0).Item("entre_tipo_cambi") + dt.Rows(0).Item("entre_soles")
        End If
        If dt.Rows.Count > 0 Then
            obj.EscribirLinea(y + 16, 111, Format(dtotal, "####,###,###0.00").PadLeft(8, " "))
        End If
    End Sub

    Sub Cabecera(ByVal dt As DataTable, ByVal obj As Imprimir, ByVal y As Integer)
        Dim n As Integer = 1
        obj.EscribirLinea(iLong * y + n, 1, "T.E.P.S.A.C.")
        obj.EscribirLinea(iLong * y + n, Centrar("LIQUIDACION DE VENTAS AL CONTADO", iAncho), "LIQUIDACION DE VENTAS AL CONTADO")
        obj.EscribirLinea(iLong * y + n, Derecha(Date.Now.ToShortDateString, iAncho), Date.Now.ToShortDateString)

        obj.EscribirLinea(iLong * y + n + 1, 1, "AGENCIA")
        obj.EscribirLinea(iLong * y + n + 1, 12, Me.cmbAgencia.Text.ToString)
        If dt.Rows.Count > 0 Then
            obj.EscribirLinea(iLong * y + n + 1, Centrar(dt.Rows(0).Item("IDLIQUI_TURNOS"), iAncho), dt.Rows(0).Item("IDLIQUI_TURNOS"))
        End If
        obj.EscribirLinea(iLong * y + n + 1, Derecha(Date.Now.ToShortTimeString, iAncho), Date.Now.ToShortTimeString)

        obj.EscribirLinea(iLong * y + n + 2, 1, "USUARIO")
        obj.EscribirLinea(iLong * y + n + 2, 12, Me.cmbUsuarios.Text.ToString)
        obj.EscribirLinea(iLong * y + n + 2, Derecha("Pag " & y + 1, iAncho), "Pag " & y + 1)

        obj.EscribirLinea(iLong * y + n + 3, 1, "F.APERTURA")
        If dt.Rows.Count > 0 Then
            obj.EscribirLinea(iLong * y + n + 3, 12, Format(DVCierres.Table.Rows(dgv.CurrentCell.RowIndex)("FECHA_APER"), "dd/MM/yyyy"))
        End If

        obj.EscribirLinea(iLong * y + n + 3, 25, "F.CIERRE")
        If dt.Rows.Count > 0 Then
            obj.EscribirLinea(iLong * y + n + 3, 34, Format(DVCierres.Table.Rows(dgv.CurrentCell.RowIndex)("FECHA_CIERRE"), "dd/MM/yyyy"))
        End If

        obj.EscribirLinea(iLong * y + n + 4, 0, Replicate("-", iAncho))

        obj.EscribirLinea(iLong * y + n + 5, 1, "N. DOCUMENTO")
        obj.EscribirLinea(iLong * y + n + 5, 16, "CLIENTE")
        obj.EscribirLinea(iLong * y + n + 5, 57, "T. PESO")
        obj.EscribirLinea(iLong * y + n + 5, 66, "T. VOL")
        obj.EscribirLinea(iLong * y + n + 5, 73, "SOBRE")
        obj.EscribirLinea(iLong * y + n + 5, 79, "DESTINO")
        obj.EscribirLinea(iLong * y + n + 5, 89, "FECHA")
        obj.EscribirLinea(iLong * y + n + 5, 97, "MON")
        obj.EscribirLinea(iLong * y + n + 5, 103, "SUBTOTAL")
        obj.EscribirLinea(iLong * y + n + 5, 113, "IGV")
        obj.EscribirLinea(iLong * y + n + 5, 121, "TOTAL")
        obj.EscribirLinea(iLong * y + n + 5, 128, "ESTADO")

        obj.EscribirLinea(iLong * y + n + 6, 0, Replicate("-", iAncho))
    End Sub

    Sub Total(ByVal dt As DataTable, ByVal obj As Imprimir, ByVal y As Integer)
        If dt.Rows.Count > 0 Then
            obj.EscribirLinea(y + 1, 101, Replicate("-", 10))
            obj.EscribirLinea(y + 1, 112, Replicate("-", 10))
            obj.EscribirLinea(y + 1, 120, Replicate("-", 10))

            Dim iSubtotal As Double = 0
            Dim iIgv As Double = 0
            Dim iTotal As Double

            iSubtotal = dt.Compute("sum(sub_total)", "")
            iIgv = dt.Compute("sum(monto_impuesto)", "")
            iTotal = dt.Compute("sum(total_costo)", "")

            obj.EscribirLinea(y + 2, 101, Format(iSubtotal, "####,###,###0.00").PadLeft(8, " "))
            obj.EscribirLinea(y + 2, 112, Format(iIgv, "####,###,###0.00").PadLeft(6, " "))
            obj.EscribirLinea(y + 2, 120, Format(iTotal, "####,###,###0.00").PadLeft(8, " "))
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If VALIDAR_PRELIMINAR() = False Then Exit Sub
            Dim obj As New dtoCIERRE_LIQUIDACIONES
            Dim id As Integer = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(Me.cmbUsuarios.SelectedIndex.ToString))
            Dim iAgencia As Integer = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias.Item(cmbAgencia.SelectedIndex.ToString))

            ActualizarFecha()
            Dim sIni As String = Me.DTPFECHAINICIOGUIA.Value.ToShortDateString
            Dim sFin As String = Me.DTPFECHAFINALGUIA.Value.ToShortDateString
            Dim ds As DataSet = obj.ListarLiquidacionTurno(id, iAgencia, sIni, sFin)
            ImprimirLiquidacion2(ds)

            Dim frm As New FrmPreview
            frm.Documento = 37
            frm.Tamaño = iLong
            frm.Text = "Liquidación Ventas al Contado"
            frm.ShowDialog()
            obj = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Cabecera2(ByVal dt As DataTable, ByVal obj As Imprimir, ByVal y As Integer)
        ActualizarFecha()
        Dim n As Integer = 1
        Dim s As String = ""
        obj.EscribirLinea(iLong * y + n, 1, "T.E.P.S.A.C.")
        obj.EscribirLinea(iLong * y + n, Centrar("LIQUIDACION DE VENTAS AL CONTADO", iAncho), "LIQUIDACION DE VENTAS AL CONTADO")
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

        obj.EscribirLinea(iLong * y + n + 5, 1, "N. DOCUMENTO")
        obj.EscribirLinea(iLong * y + n + 5, 16, "CLIENTE")
        obj.EscribirLinea(iLong * y + n + 5, 57, "T. PESO")
        obj.EscribirLinea(iLong * y + n + 5, 66, "T. VOL")
        obj.EscribirLinea(iLong * y + n + 5, 73, "SOBRE")
        obj.EscribirLinea(iLong * y + n + 5, 79, "ORI  DEST")
        obj.EscribirLinea(iLong * y + n + 5, 89, "FECHA")
        obj.EscribirLinea(iLong * y + n + 5, 97, "MON")
        obj.EscribirLinea(iLong * y + n + 5, 103, "SUBTOTAL")
        obj.EscribirLinea(iLong * y + n + 5, 113, "IGV")
        obj.EscribirLinea(iLong * y + n + 5, 121, "TOTAL")
        obj.EscribirLinea(iLong * y + n + 5, 128, "ESTADO")

        obj.EscribirLinea(iLong * y + n + 6, 0, Replicate("-", iAncho))
    End Sub

    Sub ImprimirLiquidacion2(ByVal ds As DataSet)
        Dim obj As New Imprimir
        Dim dt As DataTable = ds.Tables(1)
        Dim dtResumen As DataTable = ds.Tables(0)
        Dim dtMovimiento As DataTable = ds.Tables(2)
        Try
            Dim sImpresora As String
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0
            Dim sGrupo1 As Integer = -1
            Dim sGrupo2 As String = ""
            Dim i1 As Double = 0, i2 As Double = 0, i3 As Double = 0
            Dim i11 As Double = 0, i22 As Double = 0, i33 As Double = 0
            Dim bGrupo As Boolean = False

            obj.Inicializar()

            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim dt2 As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 37)
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
                'y += 1
                'i += 1
                If sGrupo1 <> row("idprocesos") And sGrupo2 <> row("tipo_comprobante") And sGrupo1 <> -1 And sGrupo2 <> "" Then
                    Grupo2(i11, i22, i33, obj, y, dt)
                    i11 = 0
                    i22 = 0
                    i33 = 0
                    'y += 1
                    sGrupo2 = row("tipo_comprobante")

                    Grupo(i1, i2, i3, obj, y, dt)
                    i1 = 0
                    i2 = 0
                    i3 = 0
                    y += 1
                    sGrupo1 = row("idprocesos")

                    y += 1
                    obj.EscribirLinea(y, 0, row("proceso"))
                    y += 1
                    obj.EscribirLinea(y, 0, sGrupo2)
                Else
                    If sGrupo1 <> row("idprocesos") Then
                        If i > 0 Then
                            Grupo(i1, i2, i3, obj, y, dt)
                            i1 = 0
                            i2 = 0
                            i3 = 0
                        End If
                        y += 1
                        sGrupo1 = row("idprocesos")
                        obj.EscribirLinea(y, 0, row("proceso"))
                    End If

                    If sGrupo2 <> row("tipo_comprobante") Then
                        If i > 0 Then
                            Grupo2(i11, i22, i33, obj, y, dt)
                            i11 = 0
                            i22 = 0
                            i33 = 0
                        End If
                        y += 1
                        sGrupo2 = row("tipo_comprobante")
                        obj.EscribirLinea(y, 0, sGrupo2)
                    End If
                End If

                y += 1
                i += 1

                obj.EscribirLinea(y, 0, i.ToString.PadLeft(3, " "))
                If row.Item("idtipo_comprobante") <> 85 Then
                    obj.EscribirLinea(y, 4, IIf(IsDBNull(row("serie_factura")), "", row("serie_factura")))
                    obj.EscribirLinea(y, 8, IIf(IsDBNull(row("nro_factura")), "", row("nro_factura")))
                Else
                    obj.EscribirLinea(y, 4, IIf(IsDBNull(row("nro_factura1")), "", row("nro_factura1")))
                End If
                obj.EscribirLinea(y, 16, row("razon_social").ToString.Trim.PadRight(40, " ").Substring(0, 39))
                obj.EscribirLinea(y, 58, Format(row("total_peso"), "####,###,###0.00").PadLeft(6, " "))
                obj.EscribirLinea(y, 66, Format(row("total_volumen"), "####,###,###0.00").PadLeft(6, " "))
                obj.EscribirLinea(y, 74, Format(row("cantidad_x_sobre"), "####,###,###0").PadLeft(3, " "))
                obj.EscribirLinea(y, 81, row("iata_des"))
                obj.EscribirLinea(y, 87, row("fecha_factura"))
                obj.EscribirLinea(y, 98, row("simbolo_moneda"))
                obj.EscribirLinea(y, 101, Format(row("sub_total"), "####,###,###0.00").PadLeft(8, " "))
                obj.EscribirLinea(y, 112, Format(row("monto_impuesto"), "####,###,###0.00").PadLeft(5, " "))
                obj.EscribirLinea(y, 120, Format(row("total_costo"), "####,###,###0.00").PadLeft(8, " "))
                obj.EscribirLinea(y, 129, IIf(IsDBNull(row("estado_registro")), "", row("estado_registro")))

                i11 += row("sub_total")
                i22 += row("monto_impuesto")
                i33 += row("total_costo")

                i1 += row("sub_total")
                i2 += row("monto_impuesto")
                i3 += row("total_costo")
                If i Mod 55 = 0 Then
                    pagina += 1
                    Cabecera2(dt, obj, pagina)
                    y = iLong * pagina + 7
                End If
            Next
            'grupo
            Grupo2(i11, i22, i33, obj, y, dt)
            Grupo(i1, i2, i3, obj, y, dt)
            'totales
            Total(dt, obj, y)
            'resumen
            If (y + 18) > (iLong * (pagina + 1)) Then
                pagina += 1
                Cabecera2(dt, obj, pagina)
                y = iLong * pagina + 7
                Total(dt, obj, y)
            End If
            Resumen1(dt, dtResumen, dtMovimiento, obj, y)

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

    Sub Grupo(ByVal i1 As Double, ByVal i2 As Double, ByVal i3 As Double, ByVal obj As Imprimir, ByRef y As Integer, ByVal dt As DataTable)
        If dt.Rows.Count > 0 Then
            y += 1
            obj.EscribirLinea(y, 101, Replicate("-", 10))
            obj.EscribirLinea(y, 112, Replicate("-", 10))
            obj.EscribirLinea(y, 120, Replicate("-", 10))
            y += 1
            obj.EscribirLinea(y, 81, "TOTAL PROD.")
            obj.EscribirLinea(y, 101, Format(i1, "####,###,###0.00").PadLeft(8, " "))
            obj.EscribirLinea(y, 112, Format(i2, "####,###,###0.00").PadLeft(6, " "))
            obj.EscribirLinea(y, 120, Format(i3, "####,###,###0.00").PadLeft(8, " "))
        End If
    End Sub

    Sub Grupo2(ByVal i1 As Double, ByVal i2 As Double, ByVal i3 As Double, ByVal obj As Imprimir, ByRef y As Integer, ByVal dt As DataTable)
        If dt.Rows.Count > 0 Then
            y += 1
            obj.EscribirLinea(y, 101, Replicate("-", 10))
            obj.EscribirLinea(y, 112, Replicate("-", 10))
            obj.EscribirLinea(y, 120, Replicate("-", 10))
            y += 1
            obj.EscribirLinea(y, 81, "TOTAL COMPROB.")
            obj.EscribirLinea(y, 101, Format(i1, "####,###,###0.00").PadLeft(8, " "))
            obj.EscribirLinea(y, 112, Format(i2, "####,###,###0.00").PadLeft(6, " "))
            obj.EscribirLinea(y, 120, Format(i3, "####,###,###0.00").PadLeft(8, " "))
        End If
    End Sub

    Sub Resumen1(ByVal dt As DataTable, ByVal dt2 As DataTable, ByVal dt3 As DataTable, ByVal obj As Imprimir, ByVal y As Integer)
        obj.EscribirLinea(y + 5, Centrar("RESUMEN".Length, iAncho), "RESUMEN")
        obj.EscribirLinea(y + 7, 10, "SERIE")
        obj.EscribirLinea(y + 7, 20, "INICIAL")
        obj.EscribirLinea(y + 7, 30, "FINAL")
        obj.EscribirLinea(y + 7, 40, "TOTAL")
        obj.EscribirLinea(y + 7, 50, "ANULADO")
        obj.EscribirLinea(y + 7, 60, "DEVUELTO")
        'obj.EscribirLinea(y + 7, 70, "FALTANTE")

        obj.EscribirLinea(y + 8, 1, Replicate("-", 125))
        obj.EscribirLinea(y + 9, 1, "FACTURA")
        If dt.Rows.Count > 0 Then
            obj.EscribirLinea(y + 9, 10, IIf(IsDBNull(dt.Rows(0).Item("factu_seri")), "", dt.Rows(0).Item("factu_seri")))
            obj.EscribirLinea(y + 9, 20, IIf(IsDBNull(dt.Rows(0).Item("factu_ini")), "", dt.Rows(0).Item("factu_ini")))
            obj.EscribirLinea(y + 9, 30, IIf(IsDBNull(dt.Rows(0).Item("factu_final")), "", dt.Rows(0).Item("factu_final")))
            obj.EscribirLinea(y + 9, 40, dt.Rows(0).Item("factu_conta"))
            obj.EscribirLinea(y + 9, 50, dt.Rows(0).Item("factu_anu"))
            obj.EscribirLinea(y + 9, 60, dt.Rows(0).Item("factu_devu"))
            'obj.EscribirLinea(y + 9, 70, IIf(IsDBNull(dt.Rows(0).Item("factu_faltan")), "", dt.Rows(0).Item("factu_faltan").ToString.Trim.PadLeft(57, " ").Substring(0, 57).Trim))
        End If

        obj.EscribirLinea(y + 10, 1, "BOLETA")
        If dt.Rows.Count > 0 Then
            obj.EscribirLinea(y + 10, 10, IIf(IsDBNull(dt.Rows(0).Item("bole_seri")), "", dt.Rows(0).Item("bole_seri")))
            obj.EscribirLinea(y + 10, 20, IIf(IsDBNull(dt.Rows(0).Item("bole_ini")), "", dt.Rows(0).Item("bole_ini")))
            obj.EscribirLinea(y + 10, 30, IIf(IsDBNull(dt.Rows(0).Item("bole_final")), "", dt.Rows(0).Item("bole_ini")))
            obj.EscribirLinea(y + 10, 40, dt.Rows(0).Item("bole_conta"))
            obj.EscribirLinea(y + 10, 50, dt.Rows(0).Item("bole_anu"))
            obj.EscribirLinea(y + 10, 60, dt.Rows(0).Item("bole_devu"))
            'obj.EscribirLinea(y + 10, 70, IIf(IsDBNull(dt.Rows(0).Item("bole_faltan")), "", dt.Rows(0).Item("bole_faltan").ToString.Trim.PadLeft(57, " ").Substring(0, 57).Trim))
        End If
        obj.EscribirLinea(y + 11, 1, Replicate("-", 125))

        'resumen
        Dim iFila As Integer = y + 13
        Dim iCol As Integer = 4
        Dim iSubtotal As Double = 0
        Dim boleta As Double
        Dim factura As Double
        Dim nc As Double
        Dim pce As Double

        If dt.Rows.Count > 0 Then
            boleta = dt2.Compute("sum(boleta)", "")
            factura = dt2.Compute("sum(factura)", "")
            nc = dt2.Compute("sum(nc)", "")
            If dt.Rows.Count > 0 Then
                pce = dt2.Compute("sum(pce)", "")
            End If
        End If

        If boleta > 0 Then
            iCol += 16
            obj.EscribirLinea(iFila, iCol, "BOLETA")
        End If
        If factura > 0 Then
            iCol += 11
            obj.EscribirLinea(iFila, iCol, "FACTURA")
        End If
        If pce > 0 Then
            iCol += 9
            obj.EscribirLinea(iFila, iCol, "PCE EMITIDO")
        End If
        If nc <> 0 Then
            iCol += 12
            obj.EscribirLinea(iFila, iCol, "NOTA CREDITO")
        End If
        If dt.Rows.Count > 0 Then
            obj.EscribirLinea(iFila, iCol + 14, "TOTAL")
        End If

        If dt2.Rows.Count > 0 And dt.Rows.Count > 0 Then
            Dim iProceso As Integer = -1
            For Each row As DataRow In dt2.Rows
                iSubtotal = 0
                iCol = 7
                iFila += 1

                If iProceso <> row.Item("idprocesos") Then
                    obj.EscribirLinea(iFila, 1, row.Item("proceso"))
                    iFila += 1
                End If

                obj.EscribirLinea(iFila, 3, row.Item("pago"))
                If boleta > 0 Then
                    iCol += 11
                    iSubtotal += row.Item("boleta")
                    obj.EscribirLinea(iFila, iCol, IIf(row.Item("boleta") = 0, "", Format(row.Item("boleta"), "####,###,###0.00").PadLeft(8, " ")))
                End If
                If factura > 0 Then
                    iCol += 11
                    iSubtotal += row.Item("factura")
                    obj.EscribirLinea(iFila, iCol, IIf(row.Item("factura") = 0, "", Format(row.Item("factura"), "####,###,###0.00").PadLeft(8, " ")))
                End If
                If pce > 0 Then
                    iCol += 11
                    iSubtotal += row.Item("pce")
                    obj.EscribirLinea(iFila, iCol, IIf(row.Item("pce") = 0, "", Format(row.Item("pce"), "####,###,###0.00").PadLeft(8, " ")))
                End If
                If nc <> 0 Then
                    iCol += 11
                    iSubtotal += row.Item("nc")
                    obj.EscribirLinea(iFila, iCol, IIf(row.Item("nc") = 0, "", Format(row.Item("nc"), "####,###,###0.00").PadLeft(8, " ")))
                End If
                obj.EscribirLinea(iFila, iCol + 14, Format(iSubtotal, "####,###,###0.00").PadLeft(8, " "))

                iProceso = row.Item("idprocesos")
            Next

            Dim dblMontoMovimiento As Double = 0
            If dt3.Rows.Count > 0 And dt.Rows.Count > 0 Then
                iFila = iFila + 2
                Dim strTipo As String, dblMonto As Double
                obj.EscribirLinea(iFila, 1, "OTROS MOVIMIENTOS")
                obj.EscribirLinea(iFila + 1, 1, "-----------------")
                iFila += 1
                For Each row As DataRow In dt3.Rows
                    iFila += 1
                    strTipo = row.Item("tipo").ToString.Trim.PadRight(22, " ").Substring(0, 22)
                    dblMonto = row.Item("monto")
                    dblMontoMovimiento += dblMonto
                    obj.EscribirLinea(iFila, 1, strTipo)
                    obj.EscribirLinea(iFila, iCol + 14, Format(dblMonto, "####,###,###0.00").PadLeft(8, " "))
                Next
            End If

            iCol = 7
            iFila += 1
            Dim iVeces As Integer
            If boleta > 0 Then iVeces += 11
            If factura > 0 Then iVeces += 11
            If pce > 0 Then iVeces += 11
            If nc <> 0 Then iVeces += 11
            obj.EscribirLinea(iFila, 1, Replicate("-", iVeces + 28))
            obj.EscribirLinea(iFila + 1, 1, "TOTAL")
            If boleta > 0 Then
                iCol += 11
                obj.EscribirLinea(iFila + 1, iCol, Format(boleta, "####,###,###0.00").PadLeft(8, " "))
            End If
            If factura > 0 Then
                iCol += 11
                obj.EscribirLinea(iFila + 1, iCol, Format(factura, "####,###,###0.00").PadLeft(8, " "))
            End If
            If pce > 0 Then
                iCol += 11
                obj.EscribirLinea(iFila + 1, iCol, Format(pce, "####,###,###0.00").PadLeft(8, " "))
            End If
            If nc <> 0 Then
                iCol += 11
                obj.EscribirLinea(iFila + 1, iCol, Format(nc, "####,###,###0.00").PadLeft(8, " "))
            End If
            obj.EscribirLinea(iFila + 1, iCol + 14, Format(boleta + factura + pce + nc + dblMontoMovimiento, "####,###,###0.00").PadLeft(8, " "))
        End If

    End Sub
    Private Sub DTPINICIO_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPINICIO.ValueChanged
        Call LISTAR_USUARIOS()
    End Sub

    Sub ActualizarFecha()
        Me.DTPFECHAINICIOGUIA.Value = CType(Me.dgv.CurrentRow.Cells("FECHA_APER").Value, Date).ToShortDateString
        Me.DTPFECHAFINALGUIA.Value = CType(Me.dgv.CurrentRow.Cells("FECHA_APER").Value, Date).ToShortDateString
    End Sub

    Private Sub dgv_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.RowEnter
        If blnInicio Then Return

        Dim strFechaServidor As String = FechaServidor.ToString.Substring(0, 10)
        Dim strFechaApertura As String = CType(dgv.Rows(e.RowIndex).Cells("FECHA_APER").Value, Date).ToShortDateString
        Dim blnValido As Boolean = CType(strFechaApertura, Date) = CType(strFechaServidor, Date)

        If dgv.Rows(e.RowIndex).Cells("LEYE_APERTURADO_CIERRE").Value = "A" And blnValido Then
            Me.btnModificar.Enabled = True
        Else
            Me.btnModificar.Enabled = False
        End If
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Dim frm As New frmLiquidacionModificacion
        frm.Agencia = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Agencias.Item(cmbAgencia.SelectedIndex.ToString))
        frm.Usuario = Int(ObjCIERRE_LIQUIDACIONES.coll_Lista_Usuarios.Item(Me.cmbUsuarios.SelectedIndex.ToString))
        frm.Inicio = CType(dgv.CurrentRow.Cells("FECHA_APER").Value, Date).ToShortDateString
        frm.Fin = CType(dgv.CurrentRow.Cells("FECHA_APER").Value, Date).ToShortDateString
        frm.ShowDialog()
    End Sub

    Private Sub btnMovimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMovimiento.Click
        Dim frm As New frmMovimientoCaja
        frm.Estado = dgv.CurrentRow.Cells("LEYE_APERTURADO_CIERRE").Value
        frm.Fecha = dgv.CurrentRow.Cells("FECHA_APER").Value
        frm.Usuario = dgv.CurrentRow.Cells("idusuario_personal").Value
        frm.Agencia = dgv.CurrentRow.Cells("idagencias").Value
        frm.Nivel = intNivel
        frm.ShowDialog()
    End Sub
End Class