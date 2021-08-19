Public Class FrmMigrarFacturasDbf

    Dim TablaDbf As String
    Dim dt As New DataTable

    Dim CnnDbf As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\;Extended Properties=dBASE IV;User ID=Admin;Password=")

    Dim dvListar_facturas As New DataView

    Dim Colllistar_persona_todos As New Collection
    Dim Iwinlistar_persona_todos As New AutoCompleteStringCollection

    Dim ObjPersona As New ClsLbTepsa.dtoPersona
    Dim objgeneral As New ClsLbTepsa.dtoGENERAL

    Dim dvlistar_persona_todos As New DataView
    Dim dvlistar_tipo_moneda As New DataView

    Dim dvlistar_forma_pago As New DataView

    Private ObjReport As ClsLbTepsa.dtoFrmReport '
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        listar_facturas(0)
    End Sub
    Private Sub listar_facturas(ByVal P_OPERACION As Long)
        Try


            Dim ObjFactura As New ClsLbTepsa.dtoFACTURA

            If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                ObjFactura.IDPERSONA = 0
            Else

                ObjFactura.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
            End If
            If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjFactura.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_INICIO = "NULL"
            If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjFactura.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_FINAL = "NULL"
            If Not IsNothing(Me.cbidtipo_moneda.SelectedValue) Then
                ObjFactura.IDTIPO_MONEDA = Me.cbidtipo_moneda.SelectedValue
            Else
                ObjFactura.IDTIPO_MONEDA = 0
            End If
            If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
                ObjFactura.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
            Else
                ObjFactura.IDUSUARIO_PERSONAL = 0
            End If
            If Not IsNothing(cmbAgencia.SelectedValue) Then
                ObjFactura.IDAGENCIAS = Me.cmbAgencia.SelectedValue
            Else
                ObjFactura.IDAGENCIAS = 0
            End If

            If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
                ObjFactura.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
            Else
                ObjFactura.IDFORMA_PAGO = 0
            End If
            Dim ObjMigra As New ClsLbTepsa.dtoMigra

            Dim P_EXPORTADO As Double

            If Me.RBEXPOR.Checked = True Then
                P_EXPORTADO = 1
            End If
            If Me.RBSIN_EXPOR.Checked = True Then
                P_EXPORTADO = 0
            End If
            If Me.RBEXPOR_Y_SIN_EXPOR.Checked = True Then
                P_EXPORTADO = -1
            End If
            'Mod.14/10/2009 -->Omendoza - Pasando al datahelper -  
            dvListar_facturas = ObjMigra.FN_L_factura(ObjFactura.IDAGENCIAS, ObjFactura.IDFORMA_PAGO, _
            ObjFactura.IDUSUARIO_PERSONAL, ObjFactura.IDTIPO_MONEDA, ObjFactura.IDPERSONA, ObjFactura.FECHA_INICIO, ObjFactura.FECHA_FINAL, P_EXPORTADO, P_OPERACION)

            dgv1.DataSource = dvListar_facturas

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub FrmMigrarFacturasDbf_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmMigrarFacturasDbf_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmConsulFactuEmiti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.ShadowLabel1.Text = "Exportación de Facturas a DBF"
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False
            'Mod.17/09/2009 -->Omendoza - Pasando al datahelper   
            'objgeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago, VOCONTROLUSUARIO)
            objgeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago)
            'Datahelper
            objgeneral.FNLISTAR_TIPO_MONEDA(dvlistar_tipo_moneda, Me.cbidtipo_moneda)
            objgeneral.FN_cmb_Listar_agencias(Me.cmbAgencia)
            ObjPersona.CODIGO_CLIENTE = "NULL"
            ObjPersona.IDTIPO_PERSONA = 0
            ObjPersona.IDPERSONA = 0

            'Dataheolper
            dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
            ObjProcesos.fnCargar_iWin_r(Me.txtidpersona, dvlistar_persona_todos, Colllistar_persona_todos, Iwinlistar_persona_todos, 0)

            Me.cbidforma_pago.SelectedIndex = -1
            Me.cbidtipo_moneda.SelectedIndex = -1
            Me.cmbAgencia.SelectedIndex = -1
            Me.cmbUsuarios.SelectedIndex = -1

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub cmbAgencia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAgencia.GotFocus
        dgv1.DataSource = Nothing
    End Sub

    Private Sub cmbAgencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbAgencia.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cmbUsuarios.Focus()
        End If
    End Sub




    Private Sub cmbAgencia_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectionChangeCommitted
        Dim p_id_rol_usuario, p_idagencia As Int64
        p_id_rol_usuario = 0
        If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
            p_idagencia = CType(Me.cmbAgencia.SelectedValue, Int64)
            'datahelper
            objgeneral.FN_cmb_LISTAR_USUARIOS_AGENCIAS(Me.cmbUsuarios, p_id_rol_usuario, p_idagencia)
        Else
            cmbUsuarios.DataSource = Nothing
        End If


    End Sub

    Private Sub FrmConsulFactuEmiti_MenuImprimir() Handles Me.MenuImprimir
        Try
            ObjReport.Dispose()
        Catch
        End Try
        ObjReport = New ClsLbTepsa.dtoFrmReport
        Select Case Me.TabMante.SelectedIndex
            Case 0
                Try
                    If Me.dgv1.RowCount <= 0 Then
                        MsgBox("No existen registro", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
                        Exit Sub
                    End If
                    Dim ObjFactura As New ClsLbTepsa.dtoFACTURA

                    If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                        ObjFactura.IDPERSONA = 0
                    Else

                        ObjFactura.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                    End If
                    If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjFactura.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_INICIO = "NULL"
                    If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjFactura.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_FINAL = "NULL"
                    If Not IsNothing(Me.cbidtipo_moneda.SelectedValue) Then
                        ObjFactura.IDTIPO_MONEDA = Me.cbidtipo_moneda.SelectedValue
                    Else
                        ObjFactura.IDTIPO_MONEDA = 0
                    End If
                    If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
                        ObjFactura.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
                    Else
                        ObjFactura.IDUSUARIO_PERSONAL = 0
                    End If
                    If Not IsNothing(cmbAgencia.SelectedValue) Then
                        ObjFactura.IDAGENCIAS = Me.cmbAgencia.SelectedValue
                    Else
                        ObjFactura.IDAGENCIAS = 0
                    End If

                    If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
                        ObjFactura.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
                    Else
                        ObjFactura.IDFORMA_PAGO = 0
                    End If
                    With ObjFactura

                        .IDGUIAS_ENVIO = Me.dvListar_facturas.Table.Rows(Me.dgv1.CurrentRow.Index)("IDGUIAS_ENVIO")


                        ObjReport.rutaRpt = PathFrmReport
                        ObjReport.conectar(rptservice, rptuser, rptpass)
                        ObjReport.printrptB(False, "", "GUI002.RPT", _
                        "p_idpersona;" & IIf(.IDPERSONA = 0, "NULL", .IDPERSONA), _
                        "p_idforma_pago;" & IIf(.IDFORMA_PAGO = 0, "NULL", .IDFORMA_PAGO), _
                        "p_idtipo_moneda;" & IIf(.IDTIPO_MONEDA = 0, "NULL", .IDTIPO_MONEDA), _
                        "p_idagencias;" & IIf(.IDAGENCIAS = 0, "NULL", .IDAGENCIAS), _
                        "p_idusuario_personal;" & IIf(.IDUSUARIO_PERSONAL = 0, "NULL", .IDUSUARIO_PERSONAL), _
                        "p_fecha_inicial;" & .FECHA_INICIO, _
                        "p_fecha_final;" & .FECHA_FINAL, _
                        "p_titulo_fecha;" & "Del " & Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString & " Al " & Me.DTPFECHAFINALFACTURA.Value.ToShortDateString)

                    End With
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
                End Try
        End Select
    End Sub

    Private Sub FrmConsulFactuEmiti_MenuSalir() Handles Me.MenuSalir
        Close()
    End Sub

    Private Sub txtidpersona_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtidpersona.GotFocus
        dgv1.DataSource = Nothing
    End Sub

    Private Sub txtidpersona_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtidpersona.KeyUp
        If e.KeyCode = 13 Then
            If Not Iwinlistar_persona_todos.IndexOf(txtidpersona.Text) = -1 Then
                With ObjPersona
                    .IDPERSONA = Int(Colllistar_persona_todos.Item(Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                    .IDTIPO_PERSONA = 0
                    .CODIGO_CLIENTE = "NULL"
                    'datahelper
                    ObjPersona.FNLISTAR_PERSONA(.IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                    Me.txtCodigoCliente.Text = .CODIGO_CLIENTE
                End With
                Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
            Else
                Me.txtCodigoCliente.Text = ""
            End If
            Me.DTPFECHAINICIOFACTURA.Focus()
        End If
    End Sub

    Private Sub txtidpersona_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtidpersona.TextChanged

    End Sub

    Private Sub txtCodigoCliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.GotFocus
        dgv1.DataSource = Nothing
    End Sub

    Private Sub txtCodigoCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCliente.KeyPress
        Try
            If e.KeyChar = Chr(13) Then

                ObjPersona.CODIGO_CLIENTE = Trim(Me.txtCodigoCliente.Text)
                ObjPersona.IDTIPO_PERSONA = 0
                ObjPersona.IDPERSONA = 0

                If Len(ObjPersona.CODIGO_CLIENTE) = 0 Then
                    Me.txtCodigoCliente.Text = ""
                    Me.txtidpersona.Text = ""
                    Exit Sub
                End If

                'Datahelper
                If ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE).Count = 1 Then
                    Me.txtidpersona.Text = ObjPersona.RAZON_SOCIAL
                    Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
                    txtidpersona.Focus()
                Else
                    MsgBox("No existe el cliente", MsgBoxStyle.Information, "Segurdiad del Sistema")
                    Me.txtidpersona.Text = ""
                End If
            End If
        Catch EX As Exception
            MsgBox(EX.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub txtCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.TextChanged

    End Sub

    Private Sub DTPFECHAINICIOFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.GotFocus
        dgv1.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAINICIOFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            DTPFECHAFINALFACTURA.Focus()
        End If
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.ValueChanged

    End Sub

    Private Sub DTPFECHAFINALFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.GotFocus
        dgv1.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAFINALFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cbidtipo_moneda.Focus()
        End If
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged

    End Sub

    Private Sub cbidtipo_moneda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbidtipo_moneda.GotFocus

        dgv1.DataSource = Nothing
    End Sub

    Private Sub cbidtipo_moneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidtipo_moneda.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cbidforma_pago.Focus()
        End If
    End Sub

    Private Sub cbidforma_pago_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbidforma_pago.GotFocus
        dgv1.DataSource = Nothing
    End Sub

    Private Sub cbidforma_pago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidforma_pago.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cmbAgencia.Focus()
        End If
    End Sub

    Private Sub cmbUsuarios_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUsuarios.GotFocus
        dgv1.DataSource = Nothing
    End Sub


    Private Sub cmbUsuarios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbUsuarios.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.Button3.Focus()
        End If
    End Sub



    Private Sub FrmMigrarGuias_MenuSalir() Handles Me.MenuSalir
        Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        If Me.TBRUTA.Text = "" Then
            MsgBox("Seleccione una carpeta para copiar el archivo", MsgBoxStyle.Information, "Seguridad del Sistema")
            Exit Sub
        End If
        If Me.dvListar_facturas.Count <= 0 Then
            MsgBox("No existen registros seleccionados", MsgBoxStyle.Information, "Seguridad del Sistema")
            Exit Sub
        End If

        Me.listar_facturas(1)

        Dim filename As String

        filename = "F" & Format(Date.Now, "ddMM_HH") & ".DBF"
        FileCopy("FAC.DBF", Me.TBRUTA.Text & "\" & filename)

        CnnDbf = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Me.TBRUTA.Text & "\" & ";Extended Properties=dBASE IV;User ID=Admin;Password=")

        CnnDbf.Open()


        Dim OBJGUIAS As New ClsLbTepsa.dtoguias
        Dim da As New OleDb.OleDbDataAdapter
        Dim sql As String

        pb.Minimum = 0
        pb.Maximum = dvListar_facturas.Count - 1
        pb.Visible = True
        Try

            sql = "delete from " & filename
            da = New OleDb.OleDbDataAdapter(sql, CnnDbf)
            da.Fill(dt)

            For i As Integer = 0 To dvListar_facturas.Count - 1
                sql = "insert into " & filename & "(CODOFI06, " _
                & "OFIORI06, " _
                & "NSERIE06, " _
                & "NUMGUI06, " _
                & "OFIDES06, " _
                & "FECLIQ06, " _
                & "FECEMI06, " _
                & "NOMCON06, " _
                & "PORIGV06, " _
                & "IMPBRU06, " _
                & "IMPIGV06, " _
                & "IMPGIR06, " _
                & "CANTID06, " _
                & "TIPSER06, " _
                & "TIPDOC06, " _
                & "TIPMON06, " _
                & "CONDIC06, " _
                & "DESCTO06, " _
                & "NROMEM06, " _
                & "FECDIG06, " _
                & "HORDIG06, " _
                & "USUDIG06, " _
                & "FECMOD06, " _
                & "HORMOD06, " _
                & "CODRUC06, " _
                & "TARBAS06, " _
                & "TARPES06, " _
                & "CODART06, " _
                & "PESVOL06, " _
                & "PESKIL06, " _
                & "CODBUL06, " _
                & "NUMFAC06, " _
                & "DOCGUI06, " _
                & "CODSUC06, " _
                & "FECDEV06, " _
                & "FLGDEV06, " _
                & "FECIMP06, " _
                & "CANSOB06, " _
                & "DOCREF06, " _
                & "CODCTA06  " _
                & ") values(" _
                & dvListar_facturas.Table.Rows(i)("CODOFI06") & ", " _
                & dvListar_facturas.Table.Rows(i)("OFIORI06") & ", " _
                & dvListar_facturas.Table.Rows(i)("NSERIE06") & ", '" _
                & dvListar_facturas.Table.Rows(i)("NUMGUI06") & "', " _
                & dvListar_facturas.Table.Rows(i)("OFIDES06") & ", " _
                & IIf(dvListar_facturas.Table.Rows(i).IsNull("FECLIQ06") = True, "NULL", "'" & dvListar_facturas.Table.Rows(i)("FECLIQ06") & "'") & ", " _
                & IIf(dvListar_facturas.Table.Rows(i).IsNull("FECEMI06") = True, "NULL", "'" & dvListar_facturas.Table.Rows(i)("FECEMI06") & "'") & ", '" _
                & IIf(Len(dvListar_facturas.Table.Rows(i)("NOMCON06")) > 40, Mid(dvListar_facturas.Table.Rows(i)("NOMCON06"), 1, 40), dvListar_facturas.Table.Rows(i)("NOMCON06")) & "', " _
                & dvListar_facturas.Table.Rows(i)("PORIGV06") & ", " _
                & dvListar_facturas.Table.Rows(i)("IMPBRU06") & ", " _
                & dvListar_facturas.Table.Rows(i)("IMPIGV06") & ", " _
                & dvListar_facturas.Table.Rows(i)("IMPGIR06") & ", " _
                & dvListar_facturas.Table.Rows(i)("CANTID06") & ", '" _
                & dvListar_facturas.Table.Rows(i)("TIPSER06") & "', '" _
                & dvListar_facturas.Table.Rows(i)("TIPDOC06") & "', '" _
                & dvListar_facturas.Table.Rows(i)("TIPMON06") & "', '" _
                & dvListar_facturas.Table.Rows(i)("CONDIC06") & "', " _
                & dvListar_facturas.Table.Rows(i)("DESCTO06") & ", " _
                & dvListar_facturas.Table.Rows(i)("NROMEM06") & ", '" _
                & dvListar_facturas.Table.Rows(i)("FECDIG06") & "','" _
                & dvListar_facturas.Table.Rows(i)("HORDIG06") & "', " _
                & dvListar_facturas.Table.Rows(i)("USUDIG06") & ", '" _
                & dvListar_facturas.Table.Rows(i)("FECMOD06") & "', '" _
                & dvListar_facturas.Table.Rows(i)("HORMOD06") & "', " _
                & dvListar_facturas.Table.Rows(i)("CODRUC06") & ", " _
                & dvListar_facturas.Table.Rows(i)("TARBAS06") & ", " _
                & dvListar_facturas.Table.Rows(i)("TARPES06") & ", " _
                & dvListar_facturas.Table.Rows(i)("CODART06") & ", " _
                & dvListar_facturas.Table.Rows(i)("PESVOL06") & ", " _
                & dvListar_facturas.Table.Rows(i)("PESKIL06") & ", " _
                & dvListar_facturas.Table.Rows(i)("CODBUL06") & ", " _
                & dvListar_facturas.Table.Rows(i)("NUMFAC06") & ", " _
                & dvListar_facturas.Table.Rows(i)("DOCGUI06") & ", " _
                & dvListar_facturas.Table.Rows(i)("CODSUC06") & ", " _
                & dvListar_facturas.Table.Rows(i)("FECDEV06") & ", " _
                & dvListar_facturas.Table.Rows(i)("FLGDEV06") & ", " _
                & dvListar_facturas.Table.Rows(i)("FECIMP06") & ", " _
                & dvListar_facturas.Table.Rows(i)("CANSOB06") & ", " _
                & dvListar_facturas.Table.Rows(i)("DOCREF06") & ", " _
                & dvListar_facturas.Table.Rows(i)("CODCTA06") & " " _
                & ")"

                'InputBox("copialo", "sql", sql)

                da = New OleDb.OleDbDataAdapter(sql, CnnDbf)

                da.Fill(dt)
                pb.Value = i
            Next
            MsgBox("Se exportaron " & Str(dvListar_facturas.Count) & " registros" & Chr(13) & "El nombre del archivo es " & filename, MsgBoxStyle.Information, "Segurdidad del Sistema")

        Catch EX As OleDb.OleDbException
            MsgBox(EX.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
            InputBox("copialo", "sql", sql)
        Catch Ek As SystemException
            MsgBox(Ek.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
            InputBox("copialo", "sql", sql)
        End Try

        pb.Visible = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        fbd.ShowDialog()
        TBRUTA.Text = fbd.SelectedPath
    End Sub
    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class
