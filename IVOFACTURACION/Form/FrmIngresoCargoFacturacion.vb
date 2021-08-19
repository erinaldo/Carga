Public Class FrmIngresoCargoFacturacion
    Private dvlistar_persona_todos As New DataView
    Private ObjPersona As New ClsLbTepsa.dtoPersona
    Private ObjReport As ClsLbTepsa.dtoFrmReport '

    Private DV_L_FACTURAS_SIN_CARGOS As New DataView
    Private colllistar_persona_todos As New Collection
    Private iwinlistar_persona_todos As New AutoCompleteStringCollection
    Private dvlistar_persona As New DataView
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub FrmIngresoCargoFacturacion_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmIngresoCargoFacturacion_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
        Try
            cnnSQL.Close()
        Catch
        End Try
    End Sub

    Private Sub FrmIngresoCargoFacturacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmIngresoCargoFacturacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cnnSQL.Open()

            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False
            Me.MenuStrip1.Items(6).Visible = True
            Me.MenuStrip1.Items(7).Visible = False
            Me.MenuStrip1.Items(8).Visible = True

            Me.ShadowLabel1.Text = "Ingreso de Cargos de Facturación"
            Me.MenuTab.Items(0).Text = "INGRESO DE CARGO"

            HabilitarMenu(MenuTab)

            Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL


            ObjPersona.CODIGO_CLIENTE = "NULL"
            ObjPersona.IDTIPO_PERSONA = 0
            ObjPersona.IDPERSONA = 0

            'datahelper
            'dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
            ObjProcesos.fnCargar_iWin_r(Me.txtidpersona, dvlistar_persona_todos, colllistar_persona_todos, iwinlistar_persona_todos, 0)

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Function validar() As Boolean
        validar = False
        For i As Integer = 0 To Me.DV_L_FACTURAS_SIN_CARGOS.Count - 1
            Dim R As DataRowView = Me.DV_L_FACTURAS_SIN_CARGOS.Item(i)
            If CDate(R("FECHA")) > CDate(Me.dtpfecha_cargo.Value.ToShortDateString) Then
                MsgBox("La Fecha de Recepción de cargo no puede ser menor que la de facturación " _
                & Chr(13) & "Factura: " & R("NRO_FACTURA") & Chr(13) & "Fecha: " & R("FECHA"), MsgBoxStyle.Information, "Seguridad del sistema")
                Exit Function
            End If
        Next
        validar = True
    End Function



    Private Sub FrmIngresoCargoFacturacion_MenuGrabar() Handles Me.MenuGrabar
        
    End Sub

    Private Sub FrmIngresoCargoFacturacion_MenuImprimir() Handles Me.MenuImprimir

        Try
            ObjReport.Dispose()
        Catch
        End Try
        ObjReport = New ClsLbTepsa.dtoFrmReport

        Dim ObjfACTURA As New ClsLbTepsa.dtoFACTURA
        If Me.iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString = -1 Then
            ObjfACTURA.IDPERSONA = 0
        Else
            ObjfACTURA.IDPERSONA = Int(colllistar_persona_todos.Item(Me.iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
        End If


        If Me.dtpfecha_inicio.Enabled = True Then ObjfACTURA.FECHA_INICIO = Me.dtpfecha_inicio.Value.ToShortDateString Else ObjfACTURA.FECHA_INICIO = "NULL"
        If Me.dtpfecha_final.Enabled = True Then ObjfACTURA.FECHA_FINAL = Me.dtpfecha_final.Value.ToShortDateString Else ObjfACTURA.FECHA_FINAL = "NULL"
        If Me.RBRecep.Checked Then
            ObjfACTURA.CARGO = 1
        End If
        If Me.RBSinRecep.Checked Then
            ObjfACTURA.CARGO = 0
        End If
        If Me.RBTodos.Checked Then
            ObjfACTURA.CARGO = -1
        End If

        If Me.iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString = -1 Then
            ObjfACTURA.IDPERSONA = 0
        Else
            ObjfACTURA.IDPERSONA = Int(colllistar_persona_todos.Item(Me.iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
        End If



        ObjReport.rutaRpt = PathFrmReport
        ObjReport.conectar(rptservice, rptuser, rptpass)
        With ObjfACTURA

            ObjReport.printrptB(False, "", "FAC032.RPT", _
            "p_idpersona;" & .IDPERSONA, _
            "p_fecha_inicial;" & .FECHA_INICIO, _
            "p_fecha_final;" & .FECHA_FINAL, _
            "p_titulo_fecha;" & "(Desde el " & .FECHA_INICIO & " hasta el " & .FECHA_FINAL & ")", _
            "p_cargo;" & .CARGO)
        End With
      
    End Sub

    Private Sub FrmIngresoCargoFacturacion_MenuSalir() Handles Me.MenuSalir
        Close()
    End Sub

    Private Sub txtCodigoCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCliente.KeyPress
        Try
            If e.KeyChar = Chr(13) Then

                ObjPersona.CODIGO_CLIENTE = Me.txtCodigoCliente.Text
                ObjPersona.IDTIPO_PERSONA = 0
                ObjPersona.IDPERSONA = 0

                'datahelper
                'dvlistar_persona = ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
                dvlistar_persona = ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)

                If dvlistar_persona.Count = 1 Then
                    Me.txtidpersona.Text = ObjPersona.RAZON_SOCIAL
                    Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
                Else
                    MsgBox("No existe el cliente", MsgBoxStyle.Information, "Segurdiad del Sistema")
                    Me.txtidpersona.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub txtidpersona_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtidpersona.LostFocus
        Try
            If Not iwinlistar_persona_todos.IndexOf(txtidpersona.Text) = -1 Then
                With ObjPersona
                    .IDPERSONA = Int(colllistar_persona_todos.Item(iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                    .IDTIPO_PERSONA = 0
                    .CODIGO_CLIENTE = "NULL"
                    'datahelper
                    'ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, .IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                    ObjPersona.FNLISTAR_PERSONA(.IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                    Me.txtCodigoCliente.Text = .CODIGO_CLIENTE
                End With
                Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL


            Else
                Me.txtCodigoCliente.Text = ""

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub MOSTRAR_FACTURAS()
        Try
            Dim ObjfACTURA As New ClsLbTepsa.dtoFACTURA
            If Me.iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString = -1 Then
                ObjfACTURA.IDPERSONA = 0
            Else
                ObjfACTURA.IDPERSONA = Int(colllistar_persona_todos.Item(Me.iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
            End If


            If Me.dtpfecha_inicio.Enabled = True Then ObjfACTURA.FECHA_INICIO = Me.dtpfecha_inicio.Value.ToShortDateString Else ObjfACTURA.FECHA_INICIO = "NULL"
            If Me.dtpfecha_final.Enabled = True Then ObjfACTURA.FECHA_FINAL = Me.dtpfecha_final.Value.ToShortDateString Else ObjfACTURA.FECHA_FINAL = "NULL"
            If Me.RBRecep.Checked Then
                ObjfACTURA.CARGO = 1
            End If
            If Me.RBSinRecep.Checked Then
                ObjfACTURA.CARGO = 0
            End If
            If Me.RBTodos.Checked Then
                ObjfACTURA.CARGO = -1
            End If
            'datahelper
            'DV_L_FACTURAS_SIN_CARGOS = ObjfACTURA.FN_L_FACTURAS_SIN_CARGOS(VOCONTROLUSUARIO)
            DV_L_FACTURAS_SIN_CARGOS = ObjfACTURA.FN_L_FACTURAS_SIN_CARGOS()

            FORMAT_GRILLA()


        Catch ex As Exception
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
            Throw New Exception(ex.Message)
        End Try

    End Sub
    Sub FORMAT_GRILLA()
        DGV1.Columns.Clear()

        With DGV1
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = DV_L_FACTURAS_SIN_CARGOS
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim CARGO As New DataGridViewCheckBoxColumn
        With CARGO
            .HeaderText = "Seleccionar"
            .Name = "CARGO"
            .DataPropertyName = "CARGO"

            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            .Width = 100
            .ReadOnly = False
            .SortMode = DataGridViewColumnSortMode.NotSortable

            '.FlatStyle = FlatStyle.Standard
            '.CellTemplate = New DataGridViewCheckBoxCell()
            '.CellTemplate.Style.BackColor = Color.Beige
        End With
        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .HeaderText = "RAZON SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .ReadOnly = True
            .Width = 200
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim ORIGEN As New DataGridViewTextBoxColumn
        With ORIGEN
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"
            .ReadOnly = True
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With


        Dim DESTINO As New DataGridViewTextBoxColumn
        With DESTINO
            .HeaderText = "DESTINO"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"
            .ReadOnly = True
            .Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim FECHA As New DataGridViewTextBoxColumn
        With FECHA
            .HeaderText = "FECHA"
            .Name = "FECHA"
            .DataPropertyName = "FECHA"
            .ReadOnly = True
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim FECHA_CARGO As New DataGridViewTextBoxColumn
        With FECHA_CARGO
            .HeaderText = "F. CARGO"
            .Name = "FECHA_CARGO"
            .DataPropertyName = "FECHA_CARGO"
            .ReadOnly = True
            .Width = 80
            .DefaultCellStyle.NullValue = "  -  -  "
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim FECHA_VENCIMIENTO As New DataGridViewTextBoxColumn
        With FECHA_VENCIMIENTO
            .HeaderText = "F. VENCIMIENTO"
            .Name = "FECHA_VENCIMIENTO"
            .DataPropertyName = "FECHA_VENCIMIENTO"
            .ReadOnly = True
            .Width = 80
            .DefaultCellStyle.NullValue = "  -  -  "
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim NRO_FACTURA As New DataGridViewTextBoxColumn
        With NRO_FACTURA
            .HeaderText = "NRO. FACTURA"
            .Name = "NRO_FACTURA"
            .DataPropertyName = "NRO_FACTURA"
            .ReadOnly = True
            .Width = 70
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim SERIE_FACTURA As New DataGridViewTextBoxColumn
        With SERIE_FACTURA
            .HeaderText = "SERIE"
            .Name = "SERIE_FACTURA"
            .DataPropertyName = "SERIE_FACTURA"
            .ReadOnly = True
            .Width = 30
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With



        Dim TOTAL_PESO As New DataGridViewTextBoxColumn
        With TOTAL_PESO
            .HeaderText = "TOTAL_PESO"
            .Name = "TOTAL_PESO"
            .DataPropertyName = "TOTAL_PESO"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim TOTAL_VOLUMEN As New DataGridViewTextBoxColumn
        With TOTAL_VOLUMEN
            .HeaderText = "TOTAL_VOLUMEN"
            .Name = "TOTAL_VOLUMEN"
            .DataPropertyName = "TOTAL_VOLUMEN"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim FORMA_PAGO As New DataGridViewTextBoxColumn
        With FORMA_PAGO
            .HeaderText = "FORMA_PAGO"
            .Name = "FORMA_PAGO"
            .DataPropertyName = "FORMA_PAGO"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim SUB_TOTAL As New DataGridViewTextBoxColumn
        With SUB_TOTAL
            .HeaderText = "SUB TOTAL"
            .Name = "SUB_TOTAL"
            .DataPropertyName = "SUB_TOTAL"
            .ReadOnly = True
            .Width = 50
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim IGV As New DataGridViewTextBoxColumn
        With IGV
            .HeaderText = "IMPUESTO"
            .Name = "IGV"
            .DataPropertyName = "IGV"
            .ReadOnly = True
            .Width = 50
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim DIFERENCIA As New DataGridViewTextBoxColumn
        With DIFERENCIA
            .HeaderText = "DIFERENCIA"
            .Name = "DIFERENCIA"
            .DataPropertyName = "DIFERENCIA"
            .ReadOnly = True
            .Width = 50
            .DefaultCellStyle.Format = "N0"
            '.DefaultCellStyle.NullValue = "0,00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With


        Dim TOTAL As New DataGridViewTextBoxColumn
        With TOTAL
            .HeaderText = "TOTAL"
            .Name = "TOTAL"
            .DataPropertyName = "TOTAL"
            .ReadOnly = True
            .Width = 50
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim CONSIGNADO As New DataGridViewTextBoxColumn
        With CONSIGNADO
            .HeaderText = "CONSIGNADO"
            .Name = "CONSIGNADO"
            .DataPropertyName = "CONSIGNADO"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO
            .HeaderText = "ESTADO_REGISTRO"
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        With DGV1
            .Columns.AddRange(CARGO, FECHA, FECHA_CARGO, DIFERENCIA, FECHA_VENCIMIENTO, SERIE_FACTURA, NRO_FACTURA, RAZON_SOCIAL, SUB_TOTAL, IGV, TOTAL)

        End With

        Me.txtsub_total.Text = 0
        Me.txtmonto_impuesto.Text = 0
        Me.txttotal_costo.Text = 0


        For i As Integer = 0 To DV_L_FACTURAS_SIN_CARGOS.Table.Rows.Count - 1
            Me.txtsub_total.Text = Format(CDbl(Me.txtsub_total.Text) + DV_L_FACTURAS_SIN_CARGOS.Table.Rows(i)("SUB_TOTAL"), "###,###,###.00")
            Me.txtmonto_impuesto.Text = Format(CDbl(Me.txtmonto_impuesto.Text) + DV_L_FACTURAS_SIN_CARGOS.Table.Rows(i)("igv"), "###,###,###.00")
            Me.txttotal_costo.Text = Format(CDbl(Me.txttotal_costo.Text) + DV_L_FACTURAS_SIN_CARGOS.Table.Rows(i)("total"), "###,###,###.00")
        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Call MOSTRAR_FACTURAS()
            Me.MenuStrip1.Items(3).Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub chkSinRango_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSinRango.Click
        If Me.chkSinRango.Checked = False Then
            Me.dtpfecha_final.Enabled = True
            Me.dtpfecha_inicio.Enabled = True
        Else
            Me.dtpfecha_final.Enabled = False
            Me.dtpfecha_inicio.Enabled = False
        End If
    End Sub

    Private Sub DGV1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV1.CellMouseUp
        Try

            If e.Button = Windows.Forms.MouseButtons.Left Then

                Dim a As DataRowView = Me.DV_L_FACTURAS_SIN_CARGOS.Item(Me.DGV1.CurrentRow.Index)

                If DGV1.CurrentCell.ColumnIndex <> 0 Then Exit Sub

                If a("CARGO") = 0 Then 'Ya esta Seleccionado
                    If a("CARGO") = 0 Then
                        DV_L_FACTURAS_SIN_CARGOS.Table.Rows(DGV1.CurrentRow.Index)("CARGO") = 1
                        DGV1.RefreshEdit()
                        Exit Sub
                    End If
                End If

                If a("CARGO") = 1 Then 'Ya esta Seleccionado
                    If a("CARGO") = 1 Then
                        DV_L_FACTURAS_SIN_CARGOS.Table.Rows(DGV1.CurrentRow.Index)("CARGO") = 0
                        DGV1.RefreshEdit()
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub DGV1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGV1.MouseUp

    End Sub

    Private Sub SeleccionarTodoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeleccionarTodoToolStripMenuItem.Click
        For i As Integer = 0 To Me.DV_L_FACTURAS_SIN_CARGOS.Count - 1
            DV_L_FACTURAS_SIN_CARGOS.Table.Rows(i)("CARGO") = 1
        Next
        DGV1.RefreshEdit()
    End Sub

    Private Sub SeleccionarNingunoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SeleccionarNingunoToolStripMenuItem.Click
        For i As Integer = 0 To Me.DV_L_FACTURAS_SIN_CARGOS.Count - 1
            DV_L_FACTURAS_SIN_CARGOS.Table.Rows(i)("CARGO") = 0
        Next
        DGV1.RefreshEdit()
    End Sub

    Private Sub InvertirSeleccionarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InvertirSeleccionarToolStripMenuItem.Click
        For i As Integer = 0 To Me.DV_L_FACTURAS_SIN_CARGOS.Count - 1
            Dim r As DataRowView = DV_L_FACTURAS_SIN_CARGOS.Item(i)
            If r("CARGO") = 1 Then
                DV_L_FACTURAS_SIN_CARGOS.Table.Rows(i)("CARGO") = 0
            Else
                DV_L_FACTURAS_SIN_CARGOS.Table.Rows(i)("CARGO") = 1
            End If
        Next
        DGV1.RefreshEdit()
    End Sub

    Private Sub DGV1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellContentClick

    End Sub

    Private Sub btnagre_modi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnagre_modi.Click
        Try
            Dim OBJ As New ClsLbTepsa.dtoFACTURA

            If Me.iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString = -1 Then
                MsgBox("Selecciona un cliente...", MsgBoxStyle.Critical, "Seguridad del Sistema...")
                Exit Sub
            End If
            If Me.DV_L_FACTURAS_SIN_CARGOS.Count <= 0 Then
                MsgBox("Selecciona un elemento de la lista...", MsgBoxStyle.Critical, "Seguridad del Sistema...")
                Exit Sub
            End If

            Select Case Me.TabMante.SelectedIndex
                Case 0
                    If validar() = False Then Exit Sub
                    For i As Integer = 0 To Me.DV_L_FACTURAS_SIN_CARGOS.Count - 1
                        With OBJ
                            Dim R As DataRowView = Me.DV_L_FACTURAS_SIN_CARGOS.Item(i)
                            .IDFACTURA = Me.DV_L_FACTURAS_SIN_CARGOS.Table.Rows(i)("IDFACTURA")
                            '.IDPERSONA = Me.iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text)
                            .IDPERSONA = Int(colllistar_persona_todos.Item(iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                            .FECHA_CARGO = dtpfecha_cargo.Value.ToShortDateString

                            If R("CARGO") = 1 Then
                                If Not Me.DV_L_FACTURAS_SIN_CARGOS.Table.Rows(i).IsNull("fecha_cargo") Then
                                    If MsgBox("¿Esta seguro de cambiar el cargo de este documento " + R("serie_factura") + "-" + R("nro_factura") + "?", MsgBoxStyle.YesNo, "Seguridad del Sistema...") = MsgBoxResult.Yes Then
                                        .CARGO = 1
                                        'datahelper
                                        '.FECHA_VENCIMIENTO = .FN_CARGO_FACTU_DEVO_FECHA_VENCI(VOCONTROLUSUARIO)
                                        .FECHA_VENCIMIENTO = .FN_CARGO_FACTU_DEVO_FECHA_VENCI()

                                        .SERIE_FACTURA = LTrim(RTrim(Me.DV_L_FACTURAS_SIN_CARGOS.Table.Rows(i)("SERIE_FACTURA")))
                                        .NRO_FACTURA = RTrim(LTrim(Me.DV_L_FACTURAS_SIN_CARGOS.Table.Rows(i)("NRO_FACTURA")))


                                        Dim CMD As New SqlClient.SqlCommand
                                        CMD.Connection = cnnSQL
                                        CMD.CommandType = CommandType.StoredProcedure
                                        CMD.CommandText = "SP_ACTU_FE_VENC"

                                        CMD.Parameters.Add(New SqlClient.SqlParameter("@P_SERIE", SqlDbType.VarChar)).Value = .SERIE_FACTURA
                                        CMD.Parameters.Add(New SqlClient.SqlParameter("@P_NUMERO", SqlDbType.VarChar)).Value = .NRO_FACTURA
                                        CMD.Parameters.Add(New SqlClient.SqlParameter("@P_FE_VENC", SqlDbType.VarChar)).Value = .FECHA_VENCIMIENTO

                                        CMD.ExecuteNonQuery()


                                    End If
                                Else
                                    .CARGO = 1
                                    'datahelper
                                    '.FECHA_VENCIMIENTO = .FN_CARGO_FACTU_DEVO_FECHA_VENCI(VOCONTROLUSUARIO)
                                    .FECHA_VENCIMIENTO = .FN_CARGO_FACTU_DEVO_FECHA_VENCI()

                                    .SERIE_FACTURA = LTrim(RTrim(Me.DV_L_FACTURAS_SIN_CARGOS.Table.Rows(i)("SERIE_FACTURA")))
                                    .NRO_FACTURA = RTrim(LTrim(Me.DV_L_FACTURAS_SIN_CARGOS.Table.Rows(i)("NRO_FACTURA")))

                                    Dim CMD As New SqlClient.SqlCommand
                                    CMD.Connection = cnnSQL
                                    CMD.CommandType = CommandType.StoredProcedure
                                    CMD.CommandText = "SP_ACTU_FE_VENC"

                                    CMD.Parameters.Add(New SqlClient.SqlParameter("@P_SERIE", SqlDbType.VarChar)).Value = .SERIE_FACTURA
                                    CMD.Parameters.Add(New SqlClient.SqlParameter("@P_NUMERO", SqlDbType.VarChar)).Value = .NRO_FACTURA
                                    CMD.Parameters.Add(New SqlClient.SqlParameter("@P_FE_VENC", SqlDbType.VarChar)).Value = .FECHA_VENCIMIENTO

                                    CMD.ExecuteNonQuery()


                                End If

                                
                            End If

                        End With
                    Next
                    MsgBox("Los datos se grabaron con éxito", MsgBoxStyle.Information, "Seguridad del sistema")
                    MOSTRAR_FACTURAS()
            End Select
        Catch EX As SystemException
            MsgBox(EX.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try



    End Sub

    Private Sub RBTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBTodos.CheckedChanged
        Me.btnagre_modi.Enabled = Not Me.RBTodos.Checked
        Me.btnquitar.Enabled = Not Me.RBTodos.Checked
        Me.DGV1.DataSource = Nothing
    End Sub

    Private Sub RBRecep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBRecep.CheckedChanged
        Me.btnagre_modi.Enabled = Me.RBRecep.Checked
        Me.btnquitar.Enabled = Me.RBRecep.Checked

        btnagre_modi.Text = "Modificar cargos"

        Me.DGV1.DataSource = Nothing

    End Sub

    Private Sub RBSinRecep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSinRecep.CheckedChanged
        Me.btnagre_modi.Enabled = Me.RBSinRecep.Checked
        Me.btnquitar.Enabled = Me.RBSinRecep.Checked

        btnagre_modi.Text = "Agregar cargos"

        Me.DGV1.DataSource = Nothing

    End Sub

    Private Sub btnquitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnquitar.Click
        Try
            Dim OBJ As New ClsLbTepsa.dtoFACTURA

            If Me.iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString = -1 Then
                MsgBox("Selecciona un cliente...", MsgBoxStyle.Critical, "Seguridad del Sistema...")
                Exit Sub
            End If
            If Me.DV_L_FACTURAS_SIN_CARGOS.Count <= 0 Then
                MsgBox("Selecciona un elemento de la lista...", MsgBoxStyle.Critical, "Seguridad del Sistema...")
                Exit Sub
            End If
            Select Case Me.TabMante.SelectedIndex
                Case 0
                    If validar() = False Then Exit Sub
                    For i As Integer = 0 To Me.DV_L_FACTURAS_SIN_CARGOS.Count - 1
                        With OBJ
                            Dim R As DataRowView = Me.DV_L_FACTURAS_SIN_CARGOS.Item(i)
                            .IDFACTURA = Me.DV_L_FACTURAS_SIN_CARGOS.Table.Rows(i)("IDFACTURA")
                            '.IDPERSONA = Me.iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text)
                            .IDPERSONA = Int(colllistar_persona_todos.Item(iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                            .FECHA_CARGO = dtpfecha_cargo.Value.ToShortDateString

                            If R("CARGO") = 1 Then
                                If Not Me.DV_L_FACTURAS_SIN_CARGOS.Table.Rows(i).IsNull("fecha_cargo") Then
                                    If MsgBox("¿Esta seguro de quitar el cago de este documento " + R("serie_factura") + "-" + R("nro_factura") + "?", MsgBoxStyle.YesNo, "Seguridad del Sistema...") = MsgBoxResult.Yes Then
                                        .CARGO = 0
                                        'datahelper
                                        '.FECHA_VENCIMIENTO = .FN_CARGO_FACTU_DEVO_FECHA_VENCI(VOCONTROLUSUARIO)
                                        .FECHA_VENCIMIENTO = .FN_CARGO_FACTU_DEVO_FECHA_VENCI()

                                        .SERIE_FACTURA = LTrim(RTrim(Me.DV_L_FACTURAS_SIN_CARGOS.Table.Rows(i)("SERIE_FACTURA")))
                                        .NRO_FACTURA = RTrim(LTrim(Me.DV_L_FACTURAS_SIN_CARGOS.Table.Rows(i)("NRO_FACTURA")))

                                        Dim CMD As New SqlClient.SqlCommand
                                        CMD.Connection = cnnSQL
                                        CMD.CommandType = CommandType.StoredProcedure
                                        CMD.CommandText = "SP_ACTU_FE_VENC"

                                        CMD.Parameters.Add(New SqlClient.SqlParameter("@P_SERIE", SqlDbType.VarChar)).Value = .SERIE_FACTURA
                                        CMD.Parameters.Add(New SqlClient.SqlParameter("@P_NUMERO", SqlDbType.VarChar)).Value = .NRO_FACTURA
                                        CMD.Parameters.Add(New SqlClient.SqlParameter("@P_FE_VENC", SqlDbType.VarChar)).Value = .FECHA_VENCIMIENTO

                                        CMD.ExecuteNonQuery()

                                    End If
                                
                                    
                                End If
                            End If
                        End With
                    Next
                    MsgBox("Los datos se grabaron con éxito", MsgBoxStyle.Information, "Seguridad del sistema")
                    MOSTRAR_FACTURAS()
            End Select
        Catch EX As SystemException
            MsgBox(EX.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class
