Public Class FrmManteMensajeriaPesona
    Dim objmensajeria As New ClsLbTepsa.dtoMensajeria
    Dim OBJGeneral As New ClsLbTepsa.dtoGENERAL
    Dim OBJPersona As New ClsLbTepsa.dtoPersona
    Dim ObjReport As New ClsLbTepsa.dtoFrmReport
    Dim ObjAgencias As New ClsLbTepsa.dtoAgencias
    Dim dv_LISTAR_ESTADOS_ENVIO As DataView
    Dim Eliminar_Configuraciones As Boolean = True
    '29/10/2007 
    Dim dt_centro_costo As New DataTable
    Dim dv_centro_costo As New DataView
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub FrmManteMensajeriaPesona_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmConsulComiFunci_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub

    Private Sub FrmManteMensajeriaPesona_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmConsulComiFunci_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.ShadowLabel1.Text = "Mantenimiento Mensajeria Personalizada..."
            Me.MenuStrip1.Items(0).Visible = False 'nuevo
            Me.MenuStrip1.Items(1).Visible = False 'edicion 
            Me.MenuStrip1.Items(2).Visible = False 'cancelar
            Me.MenuStrip1.Items(3).Visible = False  'grabar
            Me.MenuStrip1.Items(4).Visible = False 'eliminar
            Me.MenuStrip1.Items(5).Visible = False 'exportar
            Me.MenuStrip1.Items(6).Visible = True 'imprimir
            Me.MenuStrip1.Items(7).Visible = True 'ayuda
            Me.MenuStrip1.Items(8).Visible = True 'salir
            '
            Dim flag As Boolean = False
            '27	RESPONSABLE DE COMISION AGENCIAS	1
            '30	RESPONSABLE DE COMISION FUNCIONARIO	1
            'If fnValidar_Rol("11") = True Then  'Funcionario Agencia 
            'bloque
            If Acceso.SiRol(G_Rol, Me, 1) Then
                flag = True
            End If
            'If fnValidar_Rol("14") = True And flag = False Then  'Administrador Agencia  
            'bloque
            If Acceso.SiRol(G_Rol, Me, 2) Then
                flag = True
            End If
            If flag = False Then
                MessageBox.Show("No tiene acceso", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End
            End If

            'datahelper
            'objmensajeria.FN_cmb_listar_tipo_comunicacion(cnn, Me.CBIDTIPO_COMUNICACION)
            objmensajeria.FN_cmb_listar_tipo_comunicacion(Me.CBIDTIPO_COMUNICACION)
            CBIDTIPO_COMUNICACION.SelectedIndex = -1
            Me.Txtrazon_social.Tag = ""

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub Format_Grilla()
        Try

            DGV1.Columns.Clear()

            With objmensajeria
                .IDCTRL_MSG_CLIENTE = 0
                .IDPERSONA = Me.Txtrazon_social.Tag
                .IDPROCESOS = 20
                .IDESTADO_ENVIO = 20
                .ENVIO_MOVIL = 0
                .ENVIO_EMAIL = 0
                .IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                .IP = dtoUSUARIOS.IP
                .FECHA_REGISTRO = "01/08/2007"
                .IDESTADO_REGISTRO = 1
                .idcentro_costo = CType(Me.cmb_centro_costo.SelectedValue, Long)
            End With
            dv_LISTAR_ESTADOS_ENVIO = New DataView
            'datahelper
            'dv_LISTAR_ESTADOS_ENVIO = objmensajeria.SP_LISTAR_EST_ENVIO_PERSONA(cnn)
            dv_LISTAR_ESTADOS_ENVIO = objmensajeria.SP_LISTAR_EST_ENVIO_PERSONA()

            With DGV1
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                .DataSource = dv_LISTAR_ESTADOS_ENVIO
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .VirtualMode = True
                .RowHeadersVisible = True
                .ReadOnly = True
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            '
            Dim ENVIO_MOVIL As New DataGridViewCheckBoxColumn
            With ENVIO_MOVIL
                .HeaderText = "Celular"
                .Name = "ENVIO_MOVIL"
                .DataPropertyName = "ENVIO_MOVIL"
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                '.FlatStyle = FlatStyle.Standard
                '.CellTemplate = New DataGridViewCheckBoxCell()
                '.CellTemplate.Style.BackColor = Color.Beige
                .Width = 100
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            Dim ENVIO_CONSOLIDADO As New DataGridViewCheckBoxColumn
            With ENVIO_CONSOLIDADO
                .HeaderText = "Consolidado"
                .Name = "ENVIO_CONSOLIDADO"
                .DataPropertyName = "ENVIO_CONSOLIDADO"
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                '.FlatStyle = FlatStyle.Standard
                '.CellTemplate = New DataGridViewCheckBoxCell()
                '.CellTemplate.Style.BackColor = Color.Beige
                .Width = 100
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            Dim ENVIO_EMAIL As New DataGridViewCheckBoxColumn
            With ENVIO_EMAIL
                .HeaderText = "Mail"
                .Name = "ENVIO_EMAIL"
                .DataPropertyName = "ENVIO_EMAIL"
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                '.FlatStyle = FlatStyle.Standard
                '.CellTemplate = New DataGridViewCheckBoxCell()
                '.CellTemplate.Style.BackColor = Color.Beige
                .Width = 100
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
            With ESTADO_REGISTRO
                .HeaderText = "Proceso"
                .Name = "ESTADO_REGISTRO"
                .DataPropertyName = "ESTADO_REGISTRO"
                .Width = 350
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            Dim IDESTADO_REGISTRO As New DataGridViewTextBoxColumn
            With IDESTADO_REGISTRO
                .HeaderText = "IDESTADO_ENVIO"
                .Name = "IDESTADO_ENVIO"
                .DataPropertyName = "IDESTADO_ENVIO"
                .Width = 400
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            With DGV1

                .Columns.AddRange(ESTADO_REGISTRO, ENVIO_MOVIL, ENVIO_EMAIL, ENVIO_CONSOLIDADO, IDESTADO_REGISTRO)

            End With

            FORMAT_GRILLA2()
            FORMAT_GRILLA3()
        Catch ex As Exception
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Public Sub FORMAT_GRILLA2()
        Try

            DGV2.Columns.Clear()

            With objmensajeria
                .IDCTRL_MSG_CLIENTE = 0
                .IDPERSONA = Me.Txtrazon_social.Tag
                .IDPROCESOS = 20
                .IDESTADO_ENVIO = 20
                .ENVIO_MOVIL = 0
                .ENVIO_EMAIL = 0
                .IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                .IP = dtoUSUARIOS.IP
                .FECHA_REGISTRO = "01/08/2007"
                .IDESTADO_REGISTRO = 1
                .idcentro_costo = CType(Me.cmb_centro_costo.SelectedValue, Long)
            End With


            With DGV2
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                'datahelper
                '.DataSource = objmensajeria.SP_LISTAR_T_TIPO_MSG_MOVIL(cnn)
                .DataSource = objmensajeria.SP_LISTAR_T_TIPO_MSG_MOVIL()
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .VirtualMode = True
                .RowHeadersVisible = True
                .ReadOnly = True
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With




            Dim TIPO_COMUNICACION As New DataGridViewTextBoxColumn
            With TIPO_COMUNICACION
                .HeaderText = "TIPO_COMUNICACION"
                .Name = "TIPO_COMUNICACION"
                .DataPropertyName = "TIPO_COMUNICACION"
                .Width = 200
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            Dim NRO_MOVIL As New DataGridViewTextBoxColumn
            With NRO_MOVIL
                .HeaderText = "NRO_MOVIL"
                .Name = "NRO_MOVIL"
                .DataPropertyName = "NRO_MOVIL"
                .Width = 150
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            Dim IDTIPO_MSG_MOVIL As New DataGridViewTextBoxColumn
            With IDTIPO_MSG_MOVIL
                .HeaderText = "IDTIPO_MSG_MOVIL"
                .Name = "IDTIPO_MSG_MOVIL"
                .DataPropertyName = "IDTIPO_MSG_MOVIL"
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            With DGV2
                .Columns.AddRange(TIPO_COMUNICACION, NRO_MOVIL, IDTIPO_MSG_MOVIL)
            End With
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Public Sub FORMAT_GRILLA3()
        Try

            DGV3.Columns.Clear()

            With objmensajeria
                .IDCTRL_MSG_CLIENTE = 0
                .IDPERSONA = Me.Txtrazon_social.Tag
                .IDPROCESOS = 20
                .IDESTADO_ENVIO = 20
                .ENVIO_MOVIL = 0
                .ENVIO_EMAIL = 0
                .IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                .IP = dtoUSUARIOS.IP
                .FECHA_REGISTRO = "01/08/2007"
                .IDESTADO_REGISTRO = 1
                .idcentro_costo = CType(Me.cmb_centro_costo.SelectedValue, Long)
            End With



            With DGV3
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
                'datahelper
                '.DataSource = objmensajeria.SP_LISTAR_T_TIPO_MSG_MAIL(cnn)
                .DataSource = objmensajeria.SP_LISTAR_T_TIPO_MSG_MAIL()
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .VirtualMode = True
                .RowHeadersVisible = True
                .ReadOnly = True
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With



            Dim E_MAIL As New DataGridViewTextBoxColumn
            With E_MAIL
                .HeaderText = "E_MAIL"
                .Name = "E_MAIL"
                .DataPropertyName = "E_MAIL"
                .Width = 150
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            Dim IDTIPO_MSG_MAIL As New DataGridViewTextBoxColumn
            With IDTIPO_MSG_MAIL
                .HeaderText = "IDTIPO_MSG_MAIL"
                .Name = "IDTIPO_MSG_MAIL"
                .DataPropertyName = "IDTIPO_MSG_MAIL"
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            With DGV3

                .Columns.AddRange(E_MAIL, IDTIPO_MSG_MAIL)

            End With
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub



    Private Sub dgv1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub



    Private Sub FrmConsulComiFunci_MenuImprimir() Handles Me.MenuImprimir

        Try
            ObjReport.Dispose()
        Catch

        End Try

        ObjReport = New ClsLbTepsa.dtoFrmReport
        Try


            ObjReport.rutaRpt = PathFrmReport
            ObjReport.conectar(rptservice, rptuser, rptpass)



            If ObjAgencias.IDTIPO_COMI_AGEN = "TIP2" Then
                ObjReport.printrpt(False, "", "CC002.RPT", _
                "p_IDCOMI_CALCU;")
            Else
                ObjReport.printrpt(False, "", "CC004.RPT", _
                                    "p_IDCOMI_CALCU;")

            End If


        Catch
        End Try
    End Sub


    Private Sub dgv1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGV1.MouseUp


        Try

            If e.Button = Windows.Forms.MouseButtons.Left Then


                objmensajeria.IDCTRL_MSG_CLIENTE = dv_LISTAR_ESTADOS_ENVIO.Table.Rows(DGV1.CurrentRow.Index)("IDCTRL_MSG_CLIENTE")
                objmensajeria.IDPERSONA = Me.Txtrazon_social.Tag
                objmensajeria.IDPROCESOS = 20
                objmensajeria.IDESTADO_ENVIO = dv_LISTAR_ESTADOS_ENVIO.Table.Rows(DGV1.CurrentRow.Index)("IDESTADO_ENVIO")


                objmensajeria.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                objmensajeria.IP = dtoUSUARIOS.IP
                objmensajeria.FECHA_REGISTRO = "01/01/2007"
                objmensajeria.IDESTADO_REGISTRO = 1

                If DGV1.CurrentCell.ColumnIndex = 1 Then

                    Dim a As DataRowView = Me.dv_LISTAR_ESTADOS_ENVIO.Item(Me.DGV1.CurrentRow.Index)

                    If a("ENVIO_MOVIL") = 0 Then 'Ya esta Seleccionado
                        If a("ENVIO_MOVIL") = 0 Then
                            dv_LISTAR_ESTADOS_ENVIO.Table.Rows(DGV1.CurrentRow.Index)("ENVIO_MOVIL") = 1
                            DGV1.RefreshEdit()
                            objmensajeria.ENVIO_MOVIL = 1
                            objmensajeria.ENVIO_EMAIL = dv_LISTAR_ESTADOS_ENVIO.Table.Rows(DGV1.CurrentRow.Index)("ENVIO_EMAIL")
                            objmensajeria.ENVIO_CONSOLIDADO = dv_LISTAR_ESTADOS_ENVIO.Table.Rows(DGV1.CurrentRow.Index)("ENVIO_CONSOLIDADO")

                            'datahelper
                            'objmensajeria.SP_UP_T_CTRL_MSG_CLIENTE(cnn)
                            objmensajeria.SP_UP_T_CTRL_MSG_CLIENTE()
                            Exit Sub
                        End If
                    End If

                    If a("ENVIO_MOVIL") = 1 Then 'Ya esta Seleccionado
                        If a("ENVIO_MOVIL") = 1 Then

                            dv_LISTAR_ESTADOS_ENVIO.Table.Rows(DGV1.CurrentRow.Index)("ENVIO_MOVIL") = 0
                            DGV1.RefreshEdit()
                            objmensajeria.ENVIO_MOVIL = 0
                            objmensajeria.ENVIO_EMAIL = dv_LISTAR_ESTADOS_ENVIO.Table.Rows(DGV1.CurrentRow.Index)("ENVIO_EMAIL")
                            objmensajeria.ENVIO_CONSOLIDADO = dv_LISTAR_ESTADOS_ENVIO.Table.Rows(DGV1.CurrentRow.Index)("ENVIO_CONSOLIDADO")

                            'datahelper
                            'objmensajeria.SP_UP_T_CTRL_MSG_CLIENTE(cnn)
                            objmensajeria.SP_UP_T_CTRL_MSG_CLIENTE()
                            Exit Sub
                        End If
                    End If
                ElseIf DGV1.CurrentCell.ColumnIndex = 2 Then
                    Dim a As DataRowView = Me.dv_LISTAR_ESTADOS_ENVIO.Item(Me.DGV1.CurrentRow.Index)

                    If a("ENVIO_EMAIL") = 0 Then 'Ya esta Seleccionado
                        If a("ENVIO_EMAIL") = 0 Then
                            dv_LISTAR_ESTADOS_ENVIO.Table.Rows(DGV1.CurrentRow.Index)("ENVIO_EMAIL") = 1
                            DGV1.RefreshEdit()
                            objmensajeria.ENVIO_EMAIL = 1
                            objmensajeria.ENVIO_MOVIL = dv_LISTAR_ESTADOS_ENVIO.Table.Rows(DGV1.CurrentRow.Index)("ENVIO_MOVIL")
                            objmensajeria.ENVIO_CONSOLIDADO = dv_LISTAR_ESTADOS_ENVIO.Table.Rows(DGV1.CurrentRow.Index)("ENVIO_CONSOLIDADO")

                            'datahelper
                            'objmensajeria.SP_UP_T_CTRL_MSG_CLIENTE(cnn)
                            objmensajeria.SP_UP_T_CTRL_MSG_CLIENTE()
                            Exit Sub
                        End If
                    End If

                    If a("ENVIO_EMAIL") = 1 Then 'Ya esta Seleccionado
                        If a("ENVIO_EMAIL") = 1 Then

                            dv_LISTAR_ESTADOS_ENVIO.Table.Rows(DGV1.CurrentRow.Index)("ENVIO_EMAIL") = 0
                            DGV1.RefreshEdit()
                            objmensajeria.ENVIO_EMAIL = 0
                            objmensajeria.ENVIO_MOVIL = dv_LISTAR_ESTADOS_ENVIO.Table.Rows(DGV1.CurrentRow.Index)("ENVIO_MOVIL")
                            objmensajeria.ENVIO_CONSOLIDADO = dv_LISTAR_ESTADOS_ENVIO.Table.Rows(DGV1.CurrentRow.Index)("ENVIO_CONSOLIDADO")

                            'datahelper
                            'objmensajeria.SP_UP_T_CTRL_MSG_CLIENTE(cnn)
                            objmensajeria.SP_UP_T_CTRL_MSG_CLIENTE()
                            Exit Sub
                        End If
                    End If
                ElseIf DGV1.CurrentCell.ColumnIndex = 3 Then
                    Dim a As DataRowView = Me.dv_LISTAR_ESTADOS_ENVIO.Item(Me.DGV1.CurrentRow.Index)

                    If a("ENVIO_CONSOLIDADO") = 0 Then 'Ya esta Seleccionado
                        If a("ENVIO_CONSOLIDADO") = 0 Then
                            dv_LISTAR_ESTADOS_ENVIO.Table.Rows(DGV1.CurrentRow.Index)("ENVIO_CONSOLIDADO") = 1
                            DGV1.RefreshEdit()
                            objmensajeria.ENVIO_CONSOLIDADO = 1
                            objmensajeria.ENVIO_MOVIL = dv_LISTAR_ESTADOS_ENVIO.Table.Rows(DGV1.CurrentRow.Index)("ENVIO_MOVIL")
                            objmensajeria.ENVIO_EMAIL = dv_LISTAR_ESTADOS_ENVIO.Table.Rows(DGV1.CurrentRow.Index)("ENVIO_EMAIL")

                            'datahelper
                            'objmensajeria.SP_UP_T_CTRL_MSG_CLIENTE(cnn)
                            objmensajeria.SP_UP_T_CTRL_MSG_CLIENTE()
                            Exit Sub
                        End If
                    End If

                    If a("ENVIO_CONSOLIDADO") = 1 Then 'Ya esta Seleccionado
                        If a("ENVIO_CONSOLIDADO") = 1 Then

                            dv_LISTAR_ESTADOS_ENVIO.Table.Rows(DGV1.CurrentRow.Index)("ENVIO_CONSOLIDADO") = 0
                            DGV1.RefreshEdit()
                            objmensajeria.ENVIO_CONSOLIDADO = 0
                            objmensajeria.ENVIO_MOVIL = dv_LISTAR_ESTADOS_ENVIO.Table.Rows(DGV1.CurrentRow.Index)("ENVIO_MOVIL") = 1
                            objmensajeria.ENVIO_EMAIL = dv_LISTAR_ESTADOS_ENVIO.Table.Rows(DGV1.CurrentRow.Index)("ENVIO_EMAIL") = 1

                            'datahelper
                            'objmensajeria.SP_UP_T_CTRL_MSG_CLIENTE(cnn)
                            objmensajeria.SP_UP_T_CTRL_MSG_CLIENTE()
                            Exit Sub
                        End If
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub BtnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub
    Private Sub BTNAGRE_E_MAIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAGRE_E_MAIL.Click
        Try
            If Len(Me.TXTE_MAIL.Text.Trim) = 0 Then
                MsgBox("Ingrese un email...", MsgBoxStyle.Exclamation, "Segurdiad del Sistema...")
                Exit Sub
            End If
            For j As Integer = 0 To DGV3.RowCount - 1
                DGV3.CurrentCell = DGV3.Rows(j).Cells(0)
                If UCase(DGV3.CurrentRow.Cells("E_MAIL").Value.TRIM) = UCase(Me.TXTE_MAIL.Text.Trim) Then
                    MsgBox("El mail ya esta en la lista...", MsgBoxStyle.Exclamation, "Segurdiad del Sistema...")
                    Exit Sub
                End If
            Next
            objmensajeria.IDTIPO_MSG_MAIL = 1
            objmensajeria.E_MAIL = Me.TXTE_MAIL.Text
            objmensajeria.IDESTADO_REGISTRO = 1
            objmensajeria.IDPERSONA = Me.Txtrazon_social.Tag
            'objmensajeria.SP_IN_TIPO_MSG_MAIL(cnn)
            '29/10/2007 - 
            objmensajeria.idcentro_costo = CType(Me.cmb_centro_costo.SelectedValue, Long)
            'datahelper
            'objmensajeria.SP_IN_TIPO_MSG_MAIL_subcta(cnn)
            objmensajeria.SP_IN_TIPO_MSG_MAIL_subcta()
            FORMAT_GRILLA3()
            Me.TXTE_MAIL.Text = ""
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub BTNAGRE_MOVIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAGRE_MOVIL.Click
        Try
            If IsNothing(Me.CBIDTIPO_COMUNICACION.SelectedValue) Then
                MsgBox("Seleccione el tipo de móvil...", MsgBoxStyle.Exclamation, "Segurdiad del Sistema...")
                Exit Sub
            End If
            If Len(Me.TXTNRO_MOVIL.Text.Trim) = 0 Then
                MsgBox("Ingrese un número...", MsgBoxStyle.Exclamation, "Segurdiad del Sistema...")
                Exit Sub
            End If
            For j As Integer = 0 To DGV2.RowCount - 1
                Eliminar_Configuraciones = True
                DGV2.CurrentCell = DGV2.Rows(j).Cells(1)
                If DGV2.CurrentRow.Cells("NRO_MOVIL").Value.TRIM = Me.TXTNRO_MOVIL.Text.Trim Then
                    MsgBox("El número ya esta en la lista...", MsgBoxStyle.Exclamation, "Segurdiad del Sistema...")
                    Exit Sub
                End If
            Next
            objmensajeria.NRO_MOVIL = Me.TXTNRO_MOVIL.Text
            objmensajeria.IDESTADO_REGISTRO = 1
            objmensajeria.IDPERSONA = Me.Txtrazon_social.Tag
            objmensajeria.IDTIPO_MSG_MOVIL = 0
            objmensajeria.IDTIPO_COMUNICACION = Me.CBIDTIPO_COMUNICACION.SelectedValue
            objmensajeria.idcentro_costo = CType(Me.cmb_centro_costo.SelectedValue, Long)
            'datahelper
            'objmensajeria.SP_IN_TIPO_MSG_MOVIL(cnn)
            objmensajeria.SP_IN_TIPO_MSG_MOVIL()
            FORMAT_GRILLA2()
            Me.TXTNRO_MOVIL.Text = ""
            Me.CBIDTIPO_COMUNICACION.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub BTNELI_MOVIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELI_MOVIL.Click
        Try
            If DGV2.RowCount <= 0 Then
                Exit Sub
            End If
            objmensajeria.IDTIPO_MSG_MOVIL = DGV2.CurrentRow.Cells("IDTIPO_MSG_MOVIL").Value
            'datahelper
            'objmensajeria.SP_DE_TIPO_MSG_MOVIL(cnn)
            objmensajeria.SP_DE_TIPO_MSG_MOVIL()
            FORMAT_GRILLA2()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If DGV3.RowCount <= 0 Then
                Exit Sub
            End If
            objmensajeria.IDTIPO_MSG_MAIL = DGV3.CurrentRow.Cells("IDTIPO_MSG_MAIL").Value
            'datahelper
            'objmensajeria.SP_DE_TIPO_MSG_MAIL(cnn)
            objmensajeria.SP_DE_TIPO_MSG_MAIL()
            FORMAT_GRILLA3()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub RBENVIO_MENSAJERIA_ACTI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBENVIO_MENSAJERIA_ACTI.CheckedChanged
        Try
            If RBENVIO_MENSAJERIA_ACTI.Checked = True Then
                objmensajeria.envio_mensageria = 1
                'datahelper
                'objmensajeria.SP_UP_SI_ENVIO_MENSAJERIA(cnn)
                objmensajeria.SP_UP_SI_ENVIO_MENSAJERIA()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub RBENVIO_MENSAJERIA_DESAC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBENVIO_MENSAJERIA_DESAC.CheckedChanged
        Try
            If RBENVIO_MENSAJERIA_DESAC.Checked = True Then
                objmensajeria.envio_mensageria = 0
                'datahelper
                'objmensajeria.SP_UP_SI_ENVIO_MENSAJERIA(cnn)
                objmensajeria.SP_UP_SI_ENVIO_MENSAJERIA()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub Txtrazon_social_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtrazon_social.GotFocus
        Try
            Eliminar_Configuraciones = False
            For j As Integer = 0 To DGV1.RowCount - 1
                Eliminar_Configuraciones = True
                DGV1.CurrentCell = DGV1.Rows(j).Cells(1)
                If DGV1.CurrentRow.Cells("ENVIO_CONSOLIDADO").Value = 1 _
                Or DGV1.CurrentRow.Cells("ENVIO_EMAIL").Value = 1 _
                Or DGV1.CurrentRow.Cells("ENVIO_MOVIL").Value = 1 Then
                    Eliminar_Configuraciones = False
                    Exit For
                End If
            Next
            If Eliminar_Configuraciones = True Then
                objmensajeria.IDPERSONA = Me.Txtrazon_social.Tag
                'datahelper
                'objmensajeria.SP_DE_T_CTRL_MSG_CLIENTE(cnn)
                objmensajeria.SP_DE_T_CTRL_MSG_CLIENTE()
            End If
            Me.DGV1.DataSource = Nothing
            Me.DGV2.DataSource = Nothing
            Me.DGV3.DataSource = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub Txtrazon_social_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtrazon_social.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Me.Txtnu_docu_suna.Text = ""
                llamar_cliente()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Sub llamar_cliente()
        '
        If Me.Txtnu_docu_suna.Text.Trim = "" And Me.Txtrazon_social.Text.Trim = "" Then
            MsgBox("Ingrese un criterio de busqueda", MsgBoxStyle.Exclamation, "Seguridad del Sistema...")
            Exit Sub
        End If
        '
        RGT_CODIGO_CLIENTE = Me.Txtnu_docu_suna.Text
        RGT_RAZON_SOCIAL = Me.Txtrazon_social.Text
        '
        Dim a As New FrmBuscaClienMensa
        'a.ShowDialog(Me)

        Acceso.Asignar(a, nFrmManteMensajeriaPersona.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            a.ShowDialog(Me)
        Else
            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If Not Me.Txtrazon_social.Tag.ToString = "" Then
            ' 30/10/2007 - Omendoza
            ' Recupera la persona con la sub cuenta 
            dt_centro_costo = Nothing
            dt_centro_costo = New DataTable
            dv_centro_costo = Nothing
            dv_centro_costo = New DataView
            objmensajeria.IDPERSONA = CType(Me.Txtrazon_social.Tag.ToString, Long)
            '
            'datahelper
            'dt_centro_costo = objmensajeria.SP_recupera_centro_costo_m(cnn)
            dt_centro_costo = objmensajeria.SP_recupera_centro_costo_m()
            'Por defecto se carga el generico 
            dv_centro_costo = CargarCombo(Me.cmb_centro_costo, dt_centro_costo, "CENTRO_COSTO", "IDCENTRO_COSTO", 999)
            '--
            recupera_formato()
            '
            'Format_Grilla()
            'If objmensajeria.SP_SI_ENVIO_MENSAJERIA(cnn).Table.Rows(0)(0) = 0 Then
            '    Me.RBENVIO_MENSAJERIA_DESAC.Checked = True
            'Else
            '    Me.RBENVIO_MENSAJERIA_ACTI.Checked = True
            'End If
            'DGV1.Focus()
        Else
            Eliminar_Configuraciones = False
            For j As Integer = 0 To DGV1.RowCount - 1
                Eliminar_Configuraciones = True
                DGV1.CurrentCell = DGV1.Rows(j).Cells(1)
                If DGV1.CurrentRow.Cells("ENVIO_CONSOLIDADO").Value = 1 _
                Or DGV1.CurrentRow.Cells("ENVIO_EMAIL").Value = 1 _
                Or DGV1.CurrentRow.Cells("ENVIO_MOVIL").Value = 1 Then
                    Eliminar_Configuraciones = False
                    Exit For
                End If
            Next
            If Eliminar_Configuraciones = True Then
                objmensajeria.IDPERSONA = Me.Txtrazon_social.Tag
                'datahelper
                'objmensajeria.SP_DE_T_CTRL_MSG_CLIENTE(cnn)
                objmensajeria.SP_DE_T_CTRL_MSG_CLIENTE()
            End If
            Me.DGV1.DataSource = Nothing
            Me.DGV2.DataSource = Nothing
            Me.DGV3.DataSource = Nothing
            Me.Txtrazon_social.Focus()
        End If

    End Sub
    Private Sub Txtrazon_social_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtrazon_social.TextChanged

    End Sub

    Private Sub Txtnu_docu_suna_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtnu_docu_suna.GotFocus
        Try
            Eliminar_Configuraciones = False
            For j As Integer = 0 To DGV1.RowCount - 1
                Eliminar_Configuraciones = True
                DGV1.CurrentCell = DGV1.Rows(j).Cells(1)
                If DGV1.CurrentRow.Cells("ENVIO_CONSOLIDADO").Value = 1 _
                Or DGV1.CurrentRow.Cells("ENVIO_EMAIL").Value = 1 _
                Or DGV1.CurrentRow.Cells("ENVIO_MOVIL").Value = 1 Then
                    Eliminar_Configuraciones = False
                    Exit For
                End If
            Next
            If Eliminar_Configuraciones = True Then
                objmensajeria.IDPERSONA = Me.Txtrazon_social.Tag
                'datahelper
                'objmensajeria.SP_DE_T_CTRL_MSG_CLIENTE(cnn)
                objmensajeria.SP_DE_T_CTRL_MSG_CLIENTE()
            End If
            Me.DGV1.DataSource = Nothing
            Me.DGV2.DataSource = Nothing
            Me.DGV3.DataSource = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub Txtnu_docu_suna_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtnu_docu_suna.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Me.Txtrazon_social.Text = ""
                llamar_cliente()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub


    Private Sub FrmManteMensajeriaPesona_MenuSalir() Handles Me.MenuSalir
        Try
            For j As Integer = 0 To DGV1.RowCount - 1
                DGV1.CurrentCell = DGV1.Rows(j).Cells(1)
                If DGV1.CurrentRow.Cells("ENVIO_MOVIL").Value = 1 Then
                    If Me.DGV2.RowCount <= 0 Then
                        MsgBox("Ingrese por lo menos un número telefónico...", MsgBoxStyle.Exclamation, "Seguridad del Sistema...")
                        Exit Sub
                    End If
                End If
            Next

            For j As Integer = 0 To DGV1.RowCount - 1
                DGV1.CurrentCell = DGV1.Rows(j).Cells(1)
                If DGV1.CurrentRow.Cells("ENVIO_EMAIL").Value = 1 Then
                    If Me.DGV3.RowCount <= 0 Then
                        MsgBox("Ingrese por lo menos un correo electrónico...", MsgBoxStyle.Exclamation, "Seguridad del Sistema...")
                        Exit Sub
                    End If

                End If
            Next

            For j As Integer = 0 To DGV1.RowCount - 1
                DGV1.CurrentCell = DGV1.Rows(j).Cells(1)
                If DGV1.CurrentRow.Cells("ENVIO_CONSOLIDADO").Value = 1 Then
                    If Me.DGV3.RowCount <= 0 Then
                        MsgBox("Ingrese por lo menos un correo electrónico...", MsgBoxStyle.Exclamation, "Seguridad del Sistema...")
                        Exit Sub
                    End If

                End If
            Next
            Eliminar_Configuraciones = False
            For j As Integer = 0 To DGV1.RowCount - 1
                Eliminar_Configuraciones = True
                DGV1.CurrentCell = DGV1.Rows(j).Cells(1)
                If DGV1.CurrentRow.Cells("ENVIO_CONSOLIDADO").Value = 1 _
                Or DGV1.CurrentRow.Cells("ENVIO_EMAIL").Value = 1 _
                Or DGV1.CurrentRow.Cells("ENVIO_MOVIL").Value = 1 Then
                    Eliminar_Configuraciones = False
                    Exit For
                End If
            Next
            If Eliminar_Configuraciones = True Then
                objmensajeria.IDPERSONA = Me.Txtrazon_social.Tag
                'datahelper
                'objmensajeria.SP_DE_T_CTRL_MSG_CLIENTE(cnn)
                objmensajeria.SP_DE_T_CTRL_MSG_CLIENTE()
            End If
            '
            Close()
            '
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub cmb_centro_costo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_centro_costo.SelectedIndexChanged
        Try
            recupera_formato()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Sistema de Seguridad")
        End Try
    End Sub
    Sub recupera_formato()
        Try
            Format_Grilla()
            'datahelper
            'If objmensajeria.SP_SI_ENVIO_MENSAJERIA(cnn).Table.Rows(0)(0) = 0 Then
            If objmensajeria.SP_SI_ENVIO_MENSAJERIA().Table.Rows(0)(0) = 0 Then
                Me.RBENVIO_MENSAJERIA_DESAC.Checked = True
            Else
                Me.RBENVIO_MENSAJERIA_ACTI.Checked = True
            End If
            DGV1.Focus()
        Catch ex As Exception
        End Try
    End Sub

    'Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
    '    If bIngreso Then
    '        Acceso.VerificaCambio(sender, e)
    '    End If
    'End Sub

    Private Sub Txtnu_docu_suna_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtnu_docu_suna.TextChanged

    End Sub
End Class
