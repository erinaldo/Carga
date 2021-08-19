Public Class frmProgramaRecojo

    Public iWinDestino As New AutoCompleteStringCollection
    Public iWinDistrito As New AutoCompleteStringCollection
    Public iWinDias As New AutoCompleteStringCollection

    Public iWinDireccionRemitente As New AutoCompleteStringCollection
    Public iWinOperador As New AutoCompleteStringCollection

    Public coll_Lista_Destino As New Collection
    Public coll_Lista_Distritos As New Collection
    Public coll_Lista_Dias As New Collection

    Public coll_list_DireccionRemitente As New Collection
    Public coll_list_Operador As New Collection

    'Dim da, daPrograma As New OleDb.OleDbDataAdapter
    Dim dt, dtPrograma As New System.Data.DataTable
    Dim dv, dvPrograma As System.Data.DataView
    Dim cur_list_Programacion As New ADODB.Recordset
    Dim bIngreso As Boolean = False
    Public hnd As Long

#Region " PROCEDIMIENTOS QUE SE ENCARGAN DEL STILO VISUAL "
    'Private Sub SplitContainer1_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel1.Paint
    '    MyBase.OnPaint(e)
    '    Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), New System.Drawing.Point(965, 80))
    '    Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#366AB3"), Drawing2D.LinearGradientMode.Vertical)
    '    e.Graphics.FillRegion(gradiente, New Region(rec))
    'End Sub
    'Private Sub SplitContainer1_Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel2.Paint
    '    MyBase.OnPaint(e)
    '    Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
    '    Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#366AB3"), Drawing2D.LinearGradientMode.Vertical)
    '    e.Graphics.FillRegion(gradiente, New Region(rec))
    'End Sub
    Private Sub SplitContainer2_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer2.Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#366AB3"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Sub SplitContainer2_Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer2.Panel2.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#366AB3"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Sub MenuStrip1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MenuStrip1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), New System.Drawing.Point(965, 55))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#366AB3"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Sub TabDatos_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabDatos.Paint, TabLista.Paint, TabPage1.Paint, TabPage2.Paint, TabPage3.Paint, TabPage4.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#366AB3"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#366AB3"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Sub MenuTab_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MenuTab.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), New System.Drawing.Point(965, 55))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#366AB3"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
#End Region

    Private Sub frmProgramaRecojo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub frmProgramaRecojo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim lds_tmp As New DataSet
        Try
            'Mod.02/10/2009 -->Omendoza - Pasando al datahelper -  
            'If fnValidar_Rol("1") = True Or fnValidar_Rol("3") = True Or fnValidar_Rol("4") = True Or fnValidar_Rol("31") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 1) Then
                lds_tmp = ObjFiltrosEntregaRecojos.fnSP_RECOJO_PROGRAMADO(1) 'todos
            Else
                lds_tmp = ObjFiltrosEntregaRecojos.fnSP_RECOJO_PROGRAMADO(2)
            End If

            'LlenarTreeListViewCtrl(ObjFiltrosEntregaRecojos.CUR_DATOS, TreeLista, "FUNCIONARIOS")
            'TreeLista.ExpandAll()
            'fnCargar_iWin(txtDestino, ObjFiltrosEntregaRecojos.CUR_DATOS.NextRecordset, coll_Lista_Destino, iWinDestino, 0)
            'fnCargar_iWin(txtDistrito, ObjFiltrosEntregaRecojos.CUR_DATOS.NextRecordset, coll_Lista_Distritos, iWinDistrito, 0)
            'fnCargar_iWin(txtDias, ObjFiltrosEntregaRecojos.CUR_DATOS.NextRecordset, coll_Lista_Dias, iWinDias, 0)
            '''        
            ' LlenarTreeListViewCtrl(ObjFiltrosEntregaRecojos.CUR_DATOS, TreeLista, "FUNCIONARIOS")
            LlenarTreeListViewCtrl(lds_tmp.Tables(0), TreeLista, "FUNCIONARIOS")
            TreeLista.ExpandAll()
            fnCargar_iWin_dt(txtDestino, lds_tmp.Tables(1), coll_Lista_Destino, iWinDestino, 0)
            fnCargar_iWin_dt(txtDistrito, lds_tmp.Tables(2), coll_Lista_Distritos, iWinDistrito, 0)
            fnCargar_iWin_dt(txtDias, lds_tmp.Tables(3), coll_Lista_Dias, iWinDias, 0)
            '
            txtHoraIni.Text = ObjFiltrosEntregaRecojos.fnHORA_FORMATO24()
            txtHoraFin.Text = ObjFiltrosEntregaRecojos.fnHORA_FORMATO24()
            LoadGrid()

            ShadowLabel1.Text = "PROGRAMACION DE RECOJOS "
            MenuTab.Items(0).Text = "Busqueda"
            MenuTab.Items(1).Text = "Mantenimiento..."

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub Nuevo()
        Try
            Me.SelectMenu(1)
            MenuTab.Items(0).Enabled = False
            MenuTab.Items(1).Enabled = True
            MenuTab.Items(2).Enabled = True
            MenuTab.Items(3).Enabled = True
            MenuTab.Items(4).Enabled = True
            TreeLista.Enabled = False
            'EdicionToolStripMenuItem.
            fnClearObj()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub NuevoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem1.Click
        Nuevo()
    End Sub
    Public Sub SelectMenu(ByVal ItemMenu As Integer)
        Dim ItemsTotal As Integer = MenuTab.Items.Count() - 1
        For i As Integer = 0 To ItemsTotal
            MenuTab.Items(i).BackColor = Color.Transparent
            MenuTab.Items(i).Font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Regular)
        Next
        MenuTab.Items(ItemMenu).BackColor = System.Drawing.SystemColors.Info
        MenuTab.Items(ItemMenu).Font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Bold)
        TabMante.SelectedIndex = ItemMenu
    End Sub

    Private Sub CancelarToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarToolStripMenuItem7.Click
        VolverGrilla()
    End Sub
    Private Sub VolverGrilla()

        MenuTab.Items(0).Enabled = True
        MenuTab.Items(1).Enabled = False
        MenuTab.Items(2).Enabled = False
        MenuTab.Items(3).Enabled = False
        MenuTab.Items(4).Enabled = True
        TreeLista.Enabled = True
        Me.SelectMenu(0)
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Try
            Close()
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub TreeLista_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeLista.AfterSelect
        Try
            txtRazonSocial.Text = e.Node().Text.ToString()
            txtFuncionario.Text = e.Node().Text.ToString()
            If Int(e.Node().Tag) > 0 Then
                dt.Clear()
                'Mod.03/10/2009 -->Omendoza - Pasando al datahelper -  
                'da.Fill(dt, ObjFiltrosEntregaRecojos.fnSP_CLIENTE_FUNCIONARIO(Int(e.Node().Tag)))
                dt = ObjFiltrosEntregaRecojos.fnSP_CLIENTE_FUNCIONARIO(Int(e.Node().Tag))
                dv = dt.DefaultView
                DataGridViewClientes.DataSource = dv
                DataGridViewClientes.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub LoadGrid()

        Try

            With dtGridViweRecojos
                '    .AllowUserToAddRows = False
                '    .AllowUserToDeleteRows = False
                '    .AllowUserToOrderColumns = True
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                '    .AutoGenerateColumns = False
                '    '.DataSource = dtable_Lista_Control_Comprobante
                '    .VirtualMode = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 10
                '.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With


            Dim idprogramacion_recojos As New DataGridViewTextBoxColumn
            With idprogramacion_recojos
                .DisplayIndex = 0
                .DataPropertyName = "idprogramacion_recojos"
                .HeaderText = "idprogramacion_recojos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViweRecojos.Columns.Add(idprogramacion_recojos)


            Dim Registro As New DataGridViewTextBoxColumn
            With Registro
                .DisplayIndex = 1
                .DataPropertyName = "Registro"
                .HeaderText = "Registro"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViweRecojos.Columns.Add(Registro)


            Dim Dia_Semana As New DataGridViewTextBoxColumn
            With Dia_Semana
                .DisplayIndex = 2
                .DataPropertyName = "Dia_Semana"
                .HeaderText = "Dia_Semana"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViweRecojos.Columns.Add(Dia_Semana)

            Dim peso_kg As New DataGridViewTextBoxColumn
            With peso_kg
                .DisplayIndex = 3
                .DataPropertyName = "peso_kg"
                .HeaderText = "peso_kg"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViweRecojos.Columns.Add(peso_kg)

            Dim volumen As New DataGridViewTextBoxColumn
            With volumen
                .DisplayIndex = 4
                .DataPropertyName = "volumen"
                .HeaderText = "volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViweRecojos.Columns.Add(volumen)

            '----------------------------------------------------------------------

            With DataGridViewClientes
                '    .AllowUserToAddRows = False
                '    .AllowUserToDeleteRows = False
                '    .AllowUserToOrderColumns = True
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                '    .AutoGenerateColumns = False
                '    '.DataSource = dtable_Lista_Control_Comprobante
                '    .VirtualMode = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 10
                '.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With


            Dim colID As New DataGridViewTextBoxColumn
            With colID
                .DisplayIndex = 1
                .DataPropertyName = "Idpersona"
                .HeaderText = "Idpersona"

                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            DataGridViewClientes.Columns.Add(colID)


            Dim CODIGO As New DataGridViewTextBoxColumn
            With CODIGO
                .DisplayIndex = 3
                .DataPropertyName = "CODIGO"
                .HeaderText = "CODIGO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DataGridViewClientes.Columns.Add(CODIGO)

            Dim Razon_Social As New DataGridViewTextBoxColumn
            With Razon_Social
                .DisplayIndex = 4
                .DataPropertyName = "Razon_Social"
                .HeaderText = "RAZON SOCIAL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DataGridViewClientes.Columns.Add(Razon_Social)

            Dim CORPORATIVO As New DataGridViewTextBoxColumn
            With CORPORATIVO
                .DisplayIndex = 5
                .DataPropertyName = "CORPORATIVO"
                .HeaderText = "CORPORATIVO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DataGridViewClientes.Columns.Add(CORPORATIVO)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridViewClientes_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridViewClientes.MouseDoubleClick
        Try
            If DataGridViewClientes.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = DataGridViewClientes.SelectedRows.Item(0).Index
            If DataGridViewClientes.Rows().Count - 1 = row Then
                Return
            End If
            txtRazonSocial.Text = DataGridViewClientes.Rows(row).Cells(2).Value
            ObjFiltrosEntregaRecojos.v_IDPERSONA = DataGridViewClientes.Rows(row).Cells(0).Value
            ' Mod.03/10/2009 -->Omendoza - Pasando al datahelper -  
            Dim lds_tmp As New DataSet
            lds_tmp = ObjFiltrosEntregaRecojos.fnSP_CONTROL_CLIENTES()

            '  fnCargar_iWin(txtDireccionRemitente, ObjFiltrosEntregaRecojos.fnSP_CONTROL_CLIENTES(), coll_list_DireccionRemitente, iWinDireccionRemitente, 0)
            ' fnCargar_iWin_dt(txtOperador, ObjFiltrosEntregaRecojos.CUR_DATOS.NextRecordset, coll_list_Operador, iWinOperador, 0)
            fnCargar_iWin_dt(txtDireccionRemitente, lds_tmp.Tables(0), coll_list_DireccionRemitente, iWinDireccionRemitente, 0)
            fnCargar_iWin_dt(txtOperador, lds_tmp.Tables(1), coll_list_Operador, iWinOperador, 0)


            dtPrograma.Clear()
            'daPrograma.Fill(dtPrograma, ObjFiltrosEntregaRecojos.CUR_DATOS.NextRecordset)
            dtPrograma = lds_tmp.Tables(2)
            ' 
            dvPrograma = dtPrograma.DefaultView
            dtGridViweRecojos.DataSource = dvPrograma
            dtGridViweRecojos.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            Nuevo()

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Try
            fnGrabar(1)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Try
            fnGrabar(2)
        Catch ex As Exception

        End Try
    End Sub
    Private Function fnGrabar(ByVal iControl As Integer) As Boolean
        Try
            If txtDias.Text = "" Then
                MsgBox("Debe Ingresar un Dia de la Semana, para tener una configuracion...", MsgBoxStyle.Information, "Seguridad Sistema")
                txtDias.Focus()
                Return False
            End If

            If txtOperador.Text = "" Then
                MsgBox("Debe Ingresar un Contacto del Cliente...", MsgBoxStyle.Information, "Seguridad Sistema")
                txtOperador.Focus()
                Return False
            End If

            If txtDireccionRemitente.Text = "" Then
                MsgBox("Debe Ingresar una direccion de Recojo...", MsgBoxStyle.Information, "Seguridad Sistema")
                txtDireccionRemitente.Focus()
                Return False
            End If
            If txtDistrito.Text = "" Then
                MsgBox("Debe Ingresar un Distrito de Recojo...", MsgBoxStyle.Information, "Seguridad Sistema")
                txtDistrito.Focus()
                Return False
            End If
            If txtCantidad.Text = "" Then
                MsgBox("Debe Ingresar la Cantidad a recojer ...", MsgBoxStyle.Information, "Seguridad Sistema")
                txtCantidad.Focus()
                Return False
            End If
            If txtPeso.Text = "" Then
                MsgBox("Debe Ingresar el Peso promedio a Recojor ; Es Informacion Referencial...", MsgBoxStyle.Information, "Seguridad Sistema")
                txtPeso.Focus()
                Return False
            End If

            Dim indexof As Integer = 0
            If txtPeso.Text <> "" And txtCantidad.Text <> "" And txtDistrito.Text <> "" And txtDireccionRemitente.Text <> "" Then
                ObjFiltrosEntregaRecojos.v_idProgramacion_Recojo = 0
                ObjFiltrosEntregaRecojos.v_Nombre_Cliente_Llamada = 0
                ' ObjFiltrosEntregaRecojos.v_IDPERSONA = 0

                ObjFiltrosEntregaRecojos.v_Contacto_Persona = IIf(txtOperador.Text <> "", txtOperador.Text, "NULL")
                ObjFiltrosEntregaRecojos.v_Idcontacto_Persona = 0
                If iWinOperador.Count > 0 Then
                    indexof = iWinOperador.IndexOf(txtOperador.Text.ToString())
                    ObjFiltrosEntregaRecojos.v_Idcontacto_Persona = 0
                    If indexof >= 0 Then
                        ObjFiltrosEntregaRecojos.v_Idcontacto_Persona = Int(coll_list_Operador.Item(indexof.ToString))
                    End If
                Else
                    ObjFiltrosEntregaRecojos.v_Idcontacto_Persona = 0
                End If

                indexof = 0
                ObjFiltrosEntregaRecojos.v_Direccion_Consignado = IIf(txtDireccionRemitente.Text <> "", txtDireccionRemitente.Text, "NULL")
                ObjFiltrosEntregaRecojos.v_Iddireccion_Consignado = 0
                If iWinDireccionRemitente.Count > 0 Then
                    indexof = iWinDireccionRemitente.IndexOf(txtDireccionRemitente.Text.ToString())
                    ObjFiltrosEntregaRecojos.v_Iddireccion_Consignado = 0
                    If indexof >= 0 Then
                        ObjFiltrosEntregaRecojos.v_Iddireccion_Consignado = Int(coll_list_DireccionRemitente.Item(indexof.ToString))
                    End If
                Else
                    ObjFiltrosEntregaRecojos.v_Iddireccion_Consignado = 0
                End If

                ObjFiltrosEntregaRecojos.v_Iddistrito = 0
                If iWinDistrito.Count > 0 Then
                    indexof = iWinDistrito.IndexOf(txtDistrito.Text.ToString())
                    ObjFiltrosEntregaRecojos.v_Iddistrito = 0
                    If indexof >= 0 Then
                        ObjFiltrosEntregaRecojos.v_Iddistrito = Int(coll_Lista_Distritos.Item(indexof.ToString))
                    End If
                End If

                ObjFiltrosEntregaRecojos.v_idDia = 0
                If iWinDias.Count > 0 Then
                    indexof = iWinDias.IndexOf(txtDias.Text.ToString())
                    ObjFiltrosEntregaRecojos.v_idDia = 0
                    If indexof >= 0 Then
                        ObjFiltrosEntregaRecojos.v_idDia = Int(coll_Lista_Dias.Item(indexof.ToString))
                    End If
                End If

                ObjFiltrosEntregaRecojos.v_Hora_Ini = txtHoraIni.Text
                ObjFiltrosEntregaRecojos.v_Hora_Fin = txtHoraFin.Text
                ObjFiltrosEntregaRecojos.v_Peso_Kg = IIf(txtPeso.Text <> "", txtPeso.Text, 0)
                ObjFiltrosEntregaRecojos.v_Volumen = IIf(txtVolumen.Text <> "", txtVolumen.Text, 0)
                ObjFiltrosEntregaRecojos.v_Nro_Paquetes = IIf(txtCantidad.Text <> "", txtCantidad.Text, 0)
                ObjFiltrosEntregaRecojos.v_Observacion = IIf(txtObs.Text <> "", txtObs.Text, "NULL")
                'If ObjFiltrosEntregaRecojos.fnSP_INSUPD_RECOJOS(iControl) = True Then
                Try
                    If dtGridViweRecojos.Rows().Count - 1 = 0 Then
                        ObjFiltrosEntregaRecojos.v_idProgramacion_Recojo = 0
                    Else
                        Dim row As Integer = dtGridViweRecojos.SelectedRows.Item(0).Index
                        ObjFiltrosEntregaRecojos.v_idProgramacion_Recojo = dtGridViweRecojos.Rows(row).Cells(0).Value
                    End If
                Catch ex As Exception
                    ObjFiltrosEntregaRecojos.v_idProgramacion_Recojo = 0
                End Try
                

                If ObjFiltrosEntregaRecojos.fnSP_INSUPD_RECOJOS_I(iControl) = True Then

                    dtPrograma.Clear()
                    'Mod.03/10/2009 -->Omendoza - Pasando al datahelper -  
                    'daPrograma.Fill(dtPrograma, ObjFiltrosEntregaRecojos.fnSP_LISTA_RECOJOS_PATRON())
                    dtPrograma = ObjFiltrosEntregaRecojos.fnSP_LISTA_RECOJOS_PATRON()
                    dvPrograma = dtPrograma.DefaultView
                    dtGridViweRecojos.DataSource = dvPrograma
                    dtGridViweRecojos.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")

                    fnClearObj()
                End If
            End If

        Catch ex As Exception

        End Try
    End Function
    Private Sub fnClearObj()
        txtDistrito.Text = ""
        txtDireccionRemitente.Text = ""
        txtOperador.Text = ""
        txtDestino.Text = ""
        txtDias.Text = ""
        txtHoraIni.Text = ""
        txtHoraFin.Text = ""
        txtPeso.Text = ""
        txtCantidad.Text = ""
        txtObs.Text = ""
        txtVolumen.Text = ""
    End Sub

    Private Sub EdicionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EdicionToolStripMenuItem.Click
        Try
            If DataGridViewClientes.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = DataGridViewClientes.SelectedRows.Item(0).Index
            If DataGridViewClientes.Rows().Count - 1 = row Then
                Return
            End If
            txtRazonSocial.Text = DataGridViewClientes.Rows(row).Cells(2).Value
            ObjFiltrosEntregaRecojos.v_IDPERSONA = DataGridViewClientes.Rows(row).Cells(0).Value
            'Mod.03/10/2009 -->Omendoza - Pasando al datahelper -  
            Dim lds_tmp As New DataSet
            lds_tmp = ObjFiltrosEntregaRecojos.fnSP_CONTROL_CLIENTES()
            'fnCargar_iWin(txtDireccionRemitente, ObjFiltrosEntregaRecojos.fnSP_CONTROL_CLIENTES(), coll_list_DireccionRemitente, iWinDireccionRemitente, 0)
            'fnCargar_iWin(txtOperador, ObjFiltrosEntregaRecojos.CUR_DATOS.NextRecordset, coll_list_Operador, iWinOperador, 0)
            fnCargar_iWin_dt(txtDireccionRemitente, lds_tmp.Tables(0), coll_list_DireccionRemitente, iWinDireccionRemitente, 0)
            'Datahelper
            fnCargar_iWin_dt(txtOperador, lds_tmp.Tables(1), coll_list_Operador, iWinOperador, 0)
            '
            dtPrograma.Clear()
            'daPrograma.Fill(dtPrograma, ObjFiltrosEntregaRecojos.CUR_DATOS.NextRecordset)
            dtPrograma = lds_tmp.Tables(2)
            dvPrograma = dtPrograma.DefaultView
            dtGridViweRecojos.DataSource = dvPrograma
            dtGridViweRecojos.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            Nuevo()

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub TxtBusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBusca.TextChanged
        Try
            Dim FiltroLista As String = "RAZON_SOCIAL LIKE '%" & Me.TxtBusca.Text & "%'"
            dv.RowFilter = FiltroLista

        Catch ex As Exception

        End Try
        
    End Sub
    Private Sub dtGridViweRecojos_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtGridViweRecojos.MouseDoubleClick
        Try
            If dtGridViweRecojos.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViweRecojos.SelectedRows.Item(0).Index
            If dtGridViweRecojos.Rows().Count - 1 = row Then
                Return
            End If
            Dim varID As String = dtGridViweRecojos.Rows(row).Cells(0).Value
            If ObjFiltrosEntregaRecojos.fnSP_LISTAR_UPDATE_RECOJO(varID) = True Then
                ObjFiltrosEntregaRecojos.v_idProgramacion_Recojo = varID
                txtDistrito.Text = ObjFiltrosEntregaRecojos.v_DISTRITO
                txtDireccionRemitente.Text = ObjFiltrosEntregaRecojos.v_Direccion_Consignado
                txtOperador.Text = ObjFiltrosEntregaRecojos.v_Contacto_Persona
                txtDestino.Text = IIf(ObjFiltrosEntregaRecojos.v_DESTINO <> " ", ObjFiltrosEntregaRecojos.v_DESTINO, "")
                txtHoraIni.Text = ObjFiltrosEntregaRecojos.v_Hora_Ini
                txtHoraFin.Text = ObjFiltrosEntregaRecojos.v_Hora_Fin
                txtDias.Text = IIf(ObjFiltrosEntregaRecojos.v_DIA <> " ", ObjFiltrosEntregaRecojos.v_DIA, "")
                txtPeso.Text = ObjFiltrosEntregaRecojos.v_Peso_Kg
                txtCantidad.Text = ObjFiltrosEntregaRecojos.v_Nro_Paquetes
                txtVolumen.Text = ObjFiltrosEntregaRecojos.v_Volumen
                txtObs.Text = IIf(ObjFiltrosEntregaRecojos.v_Observacion <> " ", ObjFiltrosEntregaRecojos.v_Observacion, "")
            Else
                MsgBox("Revise sus datos, debe ser validados...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnInactivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInactivar.Click
        Try
            If dtGridViweRecojos.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViweRecojos.SelectedRows.Item(0).Index
            If dtGridViweRecojos.Rows().Count - 1 = row Then
                Return
            End If
            Dim varID As String = dtGridViweRecojos.Rows(row).Cells(0).Value
            If MsgBox("Esta Seguro de Eliminar esta Programacion...", MsgBoxStyle.YesNoCancel, "Seguridad Sistema") = MsgBoxResult.Yes Then
                If ObjFiltrosEntregaRecojos.fnSP_ELIMINACION_REGISTRO(varID) = False Then
                    MsgBox("No pudo realizar esta Operacion...", MsgBoxStyle.Information, "Seguridad Sistema")
                Else
                    dtGridViweRecojos.Rows.RemoveAt(row)

                    fnClearObj()
                    'dtGridViweRecojos.Rows(0). 
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem1.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem1.EnabledChanged, CancelarToolStripMenuItem7.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class