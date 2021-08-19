Public Class FrmManteMensajeria
    '
    Dim objmensajeria As New ClsLbTepsa.dtoMensajeria
    Dim OBJGeneral As New ClsLbTepsa.dtoGENERAL
    Dim ObjReport As New ClsLbTepsa.dtoFrmReport
    Dim ObjAgencias As New ClsLbTepsa.dtoAgencias
    Dim dv_LISTAR_ESTADOS_ENVIO As DataView
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub FrmManteMensajeria_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmConsulComiFunci_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub

    Private Sub FrmManteMensajeria_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmConsulComiFunci_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '
        Dim flag As Boolean = False
        '
        Try
            Me.ShadowLabel1.Text = "Mantenimiento Mensajeria General..."
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
            'Dim flag As Boolean = False
            '
            '27	RESPONSABLE DE COMISION AGENCIAS	1

            '30	RESPONSABLE DE COMISION FUNCIONARIO	1
            '
            'No tiene sentido se comenta - 09/06/2010 - Los 2 bloque de if de abajo 
            '
            'bloque 
            'If Acceso.SiRol(G_Rol, Me, 1) Then
            '    'If fnValidar_Rol("14") = True Then
            '    flag = True
            'End If

            'If flag = False Then
            '    MsgBox("Usted no tiene Acceso", MsgBoxStyle.Information, "Seguridad Sistema")
            '    pb_mensajeria = False
            '    Exit Sub
            'End If
            '
            '
            objmensajeria.IDPROCESOS = 21
            Format_Grilla()

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            '    
            '
            bIngreso = True
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try

    End Sub
    Private Sub Format_Grilla()
        dv_LISTAR_ESTADOS_ENVIO = New DataView
        'datahelper
        'dv_LISTAR_ESTADOS_ENVIO = objmensajeria.SP_LISTAR_ESTADOS_ENVIO(cnn)
        dv_LISTAR_ESTADOS_ENVIO = objmensajeria.SP_LISTAR_ESTADOS_ENVIO()

        dgv1.Columns.Clear()

        With dgv1
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
            .Width = 400
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

        With dgv1

            .Columns.AddRange(ESTADO_REGISTRO, ENVIO_MOVIL, ENVIO_EMAIL, IDESTADO_REGISTRO)

        End With

    End Sub

    Private Sub dgv1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellContentClick

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


    Private Sub dgv1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv1.MouseUp


        Try

            If e.Button = Windows.Forms.MouseButtons.Left Then


                objmensajeria.IDESTADO_ENVIO = dv_LISTAR_ESTADOS_ENVIO.Table.Rows(dgv1.CurrentRow.Index)("IDESTADO_ENVIO")

                If Me.RBMENSA_CORPO.Checked = True Then
                    objmensajeria.IDPROCESOS = 20
                Else
                    objmensajeria.IDPROCESOS = 21
                End If



                objmensajeria.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                objmensajeria.IP = dtoUSUARIOS.IP
                objmensajeria.FECHA_REGISTRO = "01/01/2007"
                objmensajeria.IDESTADO_REGISTRO = 1

                If dgv1.CurrentCell.ColumnIndex = 1 Then

                    Dim a As DataRowView = Me.dv_LISTAR_ESTADOS_ENVIO.Item(Me.dgv1.CurrentRow.Index)

                    If a("ENVIO_MOVIL") = 0 Then 'Ya esta Seleccionado
                        If a("ENVIO_MOVIL") = 0 Then
                            dv_LISTAR_ESTADOS_ENVIO.Table.Rows(dgv1.CurrentRow.Index)("ENVIO_MOVIL") = 1
                            dgv1.RefreshEdit()
                            objmensajeria.ENVIO_MOVIL = 1
                            objmensajeria.ENVIO_EMAIL = dv_LISTAR_ESTADOS_ENVIO.Table.Rows(dgv1.CurrentRow.Index)("ENVIO_EMAIL")

                            'datahelper
                            'objmensajeria.SP_UP_T_CTRL_MSG(cnn)
                            objmensajeria.SP_UP_T_CTRL_MSG()
                            Exit Sub
                        End If
                    End If

                    If a("ENVIO_MOVIL") = 1 Then 'Ya esta Seleccionado
                        If a("ENVIO_MOVIL") = 1 Then

                            dv_LISTAR_ESTADOS_ENVIO.Table.Rows(dgv1.CurrentRow.Index)("ENVIO_MOVIL") = 0
                            dgv1.RefreshEdit()
                            objmensajeria.ENVIO_MOVIL = 0
                            objmensajeria.ENVIO_EMAIL = dv_LISTAR_ESTADOS_ENVIO.Table.Rows(dgv1.CurrentRow.Index)("ENVIO_EMAIL")

                            'datahelper
                            'objmensajeria.SP_UP_T_CTRL_MSG(cnn)
                            objmensajeria.SP_UP_T_CTRL_MSG()
                            Exit Sub
                        End If
                    End If
                ElseIf dgv1.CurrentCell.ColumnIndex = 2 Then
                    Dim a As DataRowView = Me.dv_LISTAR_ESTADOS_ENVIO.Item(Me.dgv1.CurrentRow.Index)

                    If a("ENVIO_EMAIL") = 0 Then 'Ya esta Seleccionado
                        If a("ENVIO_EMAIL") = 0 Then
                            dv_LISTAR_ESTADOS_ENVIO.Table.Rows(dgv1.CurrentRow.Index)("ENVIO_EMAIL") = 1
                            dgv1.RefreshEdit()
                            objmensajeria.ENVIO_EMAIL = 1
                            objmensajeria.ENVIO_MOVIL = dv_LISTAR_ESTADOS_ENVIO.Table.Rows(dgv1.CurrentRow.Index)("ENVIO_MOVIL")

                            'datahelper
                            'objmensajeria.SP_UP_T_CTRL_MSG(cnn)
                            objmensajeria.SP_UP_T_CTRL_MSG()
                            Exit Sub
                        End If
                    End If

                    If a("ENVIO_EMAIL") = 1 Then 'Ya esta Seleccionado
                        If a("ENVIO_EMAIL") = 1 Then

                            dv_LISTAR_ESTADOS_ENVIO.Table.Rows(dgv1.CurrentRow.Index)("ENVIO_EMAIL") = 0
                            dgv1.RefreshEdit()
                            objmensajeria.ENVIO_EMAIL = 0
                            objmensajeria.ENVIO_MOVIL = dv_LISTAR_ESTADOS_ENVIO.Table.Rows(dgv1.CurrentRow.Index)("ENVIO_MOVIL")

                            'datahelper
                            'objmensajeria.SP_UP_T_CTRL_MSG(cnn)
                            objmensajeria.SP_UP_T_CTRL_MSG()
                            Exit Sub
                        End If
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub RBMENSA_PUBLI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBMENSA_PUBLI.CheckedChanged
        objmensajeria.IDPROCESOS = 21
        Format_Grilla()
    End Sub

    Private Sub RBMENSA_CORPO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBMENSA_CORPO.CheckedChanged
        objmensajeria.IDPROCESOS = 20
        Format_Grilla()
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class
