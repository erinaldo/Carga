Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows
Imports CrystalDecisions.Shared

Public Class FrmConsulClienFunci
#Region "Variables"
    'Dim odba_consulta As New OleDb.OleDbDataAdapter
    Dim myclase As New dtoconsultaclte_x_funcionario
    'Dim rstfuncionario, rsttipopersona, rstestado, rstcorporativo As New ADODB.Recordset
    'Dim rstcargacltexfun As New ADODB.Recordset
    Dim dtfuncionario, dttipopersona, dtestado, dtcorporativo As New DataTable
    Dim dtcargacltexfun As New DataTable
    Dim dvfuncionario, dvtipopersona, dvestado, dvcorporativo As New DataView
    Dim dvcargacltexfun As New DataView

    Private ObjReport As ClsLbTepsa.dtoFrmReport '
    Dim bIngreso As Boolean = False
    Public hnd As Long

#End Region

    Private Sub FrmConsulClienFunci_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmConsulClienFunci_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmConsulClienFunci_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.ShadowLabel1.Text = "Lista de Clientes x Funcionario"
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False
            ' 
            MenuTab.Items(0).Text = "Consulta"
            MenuTab.Items(1).Enabled = False
            MenuTab.Items(1).Visible = False
            MenuTab.Items(2).Enabled = False
            MenuTab.Items(2).Visible = False
            MenuTab.Items(3).Enabled = False
            MenuTab.Items(3).Visible = False
            MenuTab.Items(4).Enabled = False
            MenuTab.Items(4).Visible = False
            MenuTab.Items(5).Enabled = False
            MenuTab.Items(5).Visible = False
            ' Cargando los combos, que corresponden, para seleccionar el funcionario  
            'datahelper
            'rstfuncionario = myclase.fn_getcmb_usuario_persona()
            'rsttipopersona = rstfuncionario.NextRecordset
            'rstestado = rstfuncionario.NextRecordset()
            'rstcorporativo = rstfuncionario.NextRecordset()

            Dim rstfuncionario As DataSet = myclase.fn_getcmb_usuario_persona()
            'datahelper
            'odba_consulta.Fill(dtfuncionario, rstfuncionario)
            'odba_consulta.Fill(dttipopersona, rsttipopersona)
            'odba_consulta.Fill(dtestado, rstestado)
            'odba_consulta.Fill(dtcorporativo, rstcorporativo)
            ' Cargando combo 
            'dvfuncionario = CargarCombo(cmbUsuarios, dtfuncionario, "usuario", "idusuario_personal", 9999)
            'dvtipopersona = CargarCombo(cmbtipopersona, dttipopersona, "TIPO_PERSONA", "IDTIPO_PERSONA", 9999)
            'dvestado = CargarCombo(Cmbestado, dtestado, "estado_registro", "idestado_registro", 1)
            'dvcorporativo = CargarCombo(cmbcorporativo, dtcorporativo, "nombrecorporativo", "idcorporativo", 9999)

            'hlamas 06-01-2014
            'dvfuncionario = CargarCombo(cmbUsuarios, rstfuncionario.Tables(0), "usuario", "idusuario_personal", 9999)
            dvfuncionario = ClsLbTepsa.dtoGENERAL.CarteraResponsable(cmbUsuarios, "", "", 3, " (TODOS)")

            dvtipopersona = CargarCombo(cmbtipopersona, rstfuncionario.Tables(1), "TIPO_PERSONA", "IDTIPO_PERSONA", 9999)
            dvestado = CargarCombo(Cmbestado, rstfuncionario.Tables(2), "estado_registro", "idestado_registro", 1)
            dvcorporativo = CargarCombo(cmbcorporativo, rstfuncionario.Tables(3), "nombrecorporativo", "idcorporativo", 9999)

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub btnCargarClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarClientes.Click
        Try
            'Inicializando los valores
            dtcargacltexfun = Nothing
            dtcargacltexfun = New DataTable
            dvcargacltexfun = Nothing
            dvcargacltexfun = New DataView

            DGVFuncionario_x_clte.Columns.Clear() 'Limpiando la Grilla

            If cmbUsuarios.SelectedValue = 9999 Or cmbUsuarios.SelectedValue = 0 Then
                myclase.idfuncionarios = -666    'Nulo 
            Else
                myclase.idfuncionarios = cmbUsuarios.SelectedValue
            End If

            If cmbtipopersona.SelectedValue = 9999 Then
                myclase.idtipo_persona = -666    'Nulo 
            Else
                myclase.idtipo_persona = cmbtipopersona.SelectedValue
            End If

            'Por defecto va a mostrar todos - Es mas no debiera pasar por parametro
            myclase.cliente_corporativo = -666

            'Estado de Registro 
            If Cmbestado.SelectedValue = 9999 Then
                myclase.idestado_registro = -666
            Else
                myclase.idestado_registro = CType(Cmbestado.SelectedValue, Long)
            End If

            'Ingresando los corporativos
            If cmbcorporativo.SelectedValue = 9999 Then
                myclase.cliente_corporativo = -666
            Else
                myclase.cliente_corporativo = CType(cmbcorporativo.SelectedValue, Long)
            End If

            grillaformato() ' Con el nuevo formato.

            Dim rstcargacltexfun As DataTable = myclase.fn_carga_cliente_x_funcionario()
            dvcargacltexfun = rstcargacltexfun.DefaultView
            '
            DGVFuncionario_x_clte.DataSource = dvcargacltexfun
            ' 
            'Formato_GridView(DGVFuncionario_x_clte)  omendoza 

            DGVFuncionario_x_clte.AllowUserToAddRows = False
            Labnroregistro.Text = "Nº Registros :" & CType(DGVFuncionario_x_clte.Rows.Count, String)
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub FrmConsulClienFunci_MenuImprimir() Handles Me.MenuImprimir
        Try
            'El reporte està funcionando mal - Verificar  
            If Me.DGVFuncionario_x_clte.RowCount <= 0 Then
                MsgBox("No existen registro", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
                Exit Sub
            End If
            '
            ' Recuperando la información para el reporte 
            ' Pasando los valores
            Try
                ObjReport.Dispose()
            Catch
            End Try
            ObjReport = New ClsLbTepsa.dtoFrmReport
            Dim iidfuncionario, iidtipo_persona, icliente_corporativo, iidestado_registro As Integer
            '
            iidfuncionario = IIf(cmbUsuarios.SelectedValue = 0, -666, cmbUsuarios.SelectedValue)
            iidtipo_persona = IIf(cmbtipopersona.SelectedValue = 9999, -666, cmbtipopersona.SelectedValue)
            icliente_corporativo = IIf(cmbcorporativo.SelectedValue = 9999, -666, cmbcorporativo.SelectedValue)
            iidestado_registro = IIf(Cmbestado.SelectedValue = 9999, -666, Cmbestado.SelectedValue)
            '
            ObjReport.rutaRpt = PathFrmReport
            ObjReport.conectar(rptservice, rptuser, rptpass) ' ("tepsa", "titan", "titan")
            ObjReport.printrptB(False, "", "CLI001.rpt", _
            "IIDFUNCIONARIOS;" & iidfuncionario, _
            "IIDTIPO_PERSONA;" & iidtipo_persona, _
            "ICLIENTE_CORPORATIVO;" & icliente_corporativo, _
            "IIDESTADO_REGISTRO;" & iidestado_registro)

            'ObjReport.printrptB(False, "", "CLI001C.rpt", _
            '"IIDFUNCIONARIOS;NULL", _
            '"IIDTIPO_PERSONA;NULL", _
            '"ICLIENTE_CORPORATIVO;NULL", _
            '"IIDESTADO_REGISTRO;NULL")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Sub grillaformato()
        With DGVFuncionario_x_clte
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            '.DataSource = dvListar_Prefacturas
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        '
        Dim usuario As New DataGridViewTextBoxColumn
        With usuario '0                
            .DataPropertyName = "usuario"
            .Name = "usuario"
            .HeaderText = "Funcionario"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        DGVFuncionario_x_clte.Columns.Add(usuario)
        '
        Dim razonsocial As New DataGridViewTextBoxColumn
        With razonsocial '1                
            

            .HeaderText = "Cliente"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"

            .Width = 200

            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True

        End With
        DGVFuncionario_x_clte.Columns.Add(razonsocial)
        '
        Dim Tipocliente As New DataGridViewTextBoxColumn
        With Tipocliente '2                 
            .DataPropertyName = "cliente_corporativo"
            .Name = "cliente_corporativo"
            .HeaderText = "Tipo Cliente"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Visible = False
        End With
        DGVFuncionario_x_clte.Columns.Add(Tipocliente)
        '
        Dim destino As New DataGridViewTextBoxColumn
        With destino '3
            .DataPropertyName = "nu_docu_suna"
            .Name = "nu_docu_suna"
            .HeaderText = "RUC"
            .Width = 110
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        DGVFuncionario_x_clte.Columns.Add(destino)
        '
        Dim tipo_facturacion As New DataGridViewTextBoxColumn
        With tipo_facturacion '4
            .DataPropertyName = "tipo_facturacion"
            .Name = "tipo_facturacion"
            .HeaderText = "Tipo Facturación"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        DGVFuncionario_x_clte.Columns.Add(tipo_facturacion)
        '
        Dim nro_guia As New DataGridViewTextBoxColumn
        With nro_guia   '5 
            .DataPropertyName = "linea_credito"
            .Name = "linea_credito"
            .HeaderText = "Línea Crédito"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        DGVFuncionario_x_clte.Columns.Add(nro_guia)
        ' 
        Dim condicionpago As New DataGridViewTextBoxColumn
        With condicionpago '  6
            .DataPropertyName = "condicion"
            .Name = "condicion"
            .HeaderText = "Condición Pago"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        DGVFuncionario_x_clte.Columns.Add(condicionpago)

        Dim repesentante_legal As New DataGridViewTextBoxColumn
        With repesentante_legal '  6
            .DataPropertyName = "Representante_Legal"
            .Name = "representante_legal"
            .HeaderText = "Repesentante Legal"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        DGVFuncionario_x_clte.Columns.Add(repesentante_legal)

        Dim gerente_general As New DataGridViewTextBoxColumn
        With gerente_general '  6
            .DataPropertyName = "Gerente_General"
            .Name = "gerente_general"
            .HeaderText = "Gerente General"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        DGVFuncionario_x_clte.Columns.Add(gerente_general)

        Dim telefono As New DataGridViewTextBoxColumn
        With telefono '  6
            .DataPropertyName = "telefono"
            .Name = "telefono"
            .HeaderText = "Teléfono"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        DGVFuncionario_x_clte.Columns.Add(telefono)

        Dim email As New DataGridViewTextBoxColumn
        With email '  6
            .DataPropertyName = "email"
            .Name = "email"
            .HeaderText = "E-Mail"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        DGVFuncionario_x_clte.Columns.Add(email)

        '
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

    Private Sub DGVFuncionario_x_clte_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVFuncionario_x_clte.CellContentClick

    End Sub

    Private Sub DGVFuncionario_x_clte_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGVFuncionario_x_clte.RowsAdded
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.DGVFuncionario_x_clte), 0)
    End Sub

    Private Sub DGVFuncionario_x_clte_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGVFuncionario_x_clte.RowsRemoved
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.DGVFuncionario_x_clte), 0)
    End Sub

    Private Sub cmbUsuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUsuarios.SelectedIndexChanged
        Me.DGVFuncionario_x_clte.DataSource = Nothing
    End Sub

    Private Sub cmbcorporativo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcorporativo.SelectedIndexChanged
        Me.DGVFuncionario_x_clte.DataSource = Nothing
    End Sub
End Class
