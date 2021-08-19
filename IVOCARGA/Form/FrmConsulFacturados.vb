Public Class FrmConsulFacturados

    Dim ObjDESPACHO_RECEPCION As New ClsLbTepsa.dtoDESPACHO_RECEPCION
    Dim dvListar_Tarifas As New DataView

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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        '
        listar_guias()
        '
    End Sub

    Private Sub listar_guias()
        Try
            Dim Obj As New ClsLbTepsa.dtoFACTURA
            If Not IsNothing(Me.CBIDUSUARIO_PERSONAL.SelectedValue) Then
                Obj.IDUSUARIO_PERSONAL = Me.CBIDUSUARIO_PERSONAL.SelectedValue
            Else
                Obj.IDUSUARIO_PERSONAL = 0
            End If

            Obj.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString
            Obj.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString

            'datahelper
            'dvListar_Tarifas = Obj.SP_LIST_FACTURADOS(VOCONTROLUSUARIO)
            dvListar_Tarifas = Obj.SP_LIST_FACTURADOS()
            FORMAT()
            DGV2.DataSource = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub DGV3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.CellContentClick

    End Sub



    Sub FORMAT()
        DGV3.Columns.Clear()

        With DGV3
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = dvListar_Tarifas
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With


        Dim CG_MONTO_BASE As New DataGridViewTextBoxColumn
        With CG_MONTO_BASE
            .HeaderText = "Prec. Base"
            .Name = "CG_MONTO_BASE"
            .DataPropertyName = "CG_MONTO_BASE"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim CG_X_PESO As New DataGridViewTextBoxColumn
        With CG_X_PESO
            .HeaderText = "Prec. Peso"
            .Name = "CG_X_PESO"
            .DataPropertyName = "CG_X_PESO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim CG_X_VOLUMEN As New DataGridViewTextBoxColumn
        With CG_X_VOLUMEN
            .HeaderText = "Prec. Volúmen"
            .Name = "CG_X_VOLUMEN"
            .DataPropertyName = "CG_X_VOLUMEN"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim DESTINO As New DataGridViewTextBoxColumn
        With DESTINO
            .HeaderText = "Destino"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim EC_MONTO_BASE As New DataGridViewTextBoxColumn
        With EC_MONTO_BASE
            .HeaderText = "EC_MONTO_BASE"
            .Name = "EC_MONTO_BASE"
            .DataPropertyName = "EC_MONTO_BASE"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim EC_X_PESO As New DataGridViewTextBoxColumn
        With EC_X_PESO
            .HeaderText = "EC_X_PESO"
            .Name = "EC_X_PESO"
            .DataPropertyName = "EC_X_PESO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim EC_X_VOLUMEN As New DataGridViewTextBoxColumn
        With EC_X_VOLUMEN
            .HeaderText = "EC_X_VOLUMEN"
            .Name = "EC_X_VOLUMEN"
            .DataPropertyName = "EC_X_VOLUMEN"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim ES_VIGENTE As New DataGridViewTextBoxColumn
        With ES_VIGENTE
            .HeaderText = "ES_VIGENTE"
            .Name = "ES_VIGENTE"
            .DataPropertyName = "ES_VIGENTE"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim FECHA_ACTIVACION As New DataGridViewTextBoxColumn
        With FECHA_ACTIVACION
            .HeaderText = "FECHA_ACTIVACION"
            .Name = "FECHA_ACTIVACION"
            .DataPropertyName = "FECHA_ACTIVACION"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FECHA_ACTUALIZACION As New DataGridViewTextBoxColumn
        With FECHA_ACTUALIZACION
            .HeaderText = "FECHA_ACTUALIZACION"
            .Name = "FECHA_ACTUALIZACION"
            .DataPropertyName = "FECHA_ACTUALIZACION"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FECHA_DESACTIVACION As New DataGridViewTextBoxColumn
        With FECHA_DESACTIVACION
            .HeaderText = "FECHA_DESACTIVACION"
            .Name = "FECHA_DESACTIVACION"
            .DataPropertyName = "FECHA_DESACTIVACION"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FECHA_REGISTRO As New DataGridViewTextBoxColumn
        With FECHA_REGISTRO
            .HeaderText = "FECHA_REGISTRO"
            .Name = "FECHA_REGISTRO"
            .DataPropertyName = "FECHA_REGISTRO"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim GI_MONTO_BASE As New DataGridViewTextBoxColumn
        With GI_MONTO_BASE
            .HeaderText = "GI_MONTO_BASE"
            .Name = "GI_MONTO_BASE"
            .DataPropertyName = "GI_MONTO_BASE"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim GI_NORMAL As New DataGridViewTextBoxColumn
        With GI_NORMAL
            .HeaderText = "GI_NORMAL"
            .Name = "GI_NORMAL"
            .DataPropertyName = "GI_NORMAL"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim GI_TELEFONICO As New DataGridViewTextBoxColumn
        With GI_TELEFONICO
            .HeaderText = "GI_TELEFONICO"
            .Name = "GI_TELEFONICO"
            .DataPropertyName = "GI_TELEFONICO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With IDESTADO_REGISTRO
            .HeaderText = "IDESTADO_REGISTRO"
            .Name = "IDESTADO_REGISTRO"
            .DataPropertyName = "IDESTADO_REGISTRO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDPERSONA As New DataGridViewTextBoxColumn
        With IDPERSONA
            .HeaderText = "IDPERSONA"
            .Name = "IDPERSONA"
            .DataPropertyName = "IDPERSONA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = False
        End With
        Dim IDROL_USUARIO As New DataGridViewTextBoxColumn
        With IDROL_USUARIO
            .HeaderText = "IDROL_USUARIO"
            .Name = "IDROL_USUARIO"
            .DataPropertyName = "IDROL_USUARIO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDROL_USUARIOMOD As New DataGridViewTextBoxColumn
        With IDROL_USUARIOMOD
            .HeaderText = "IDROL_USUARIOMOD"
            .Name = "IDROL_USUARIOMOD"
            .DataPropertyName = "IDROL_USUARIOMOD"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDTARIFAS_CARGA_CLIENTE As New DataGridViewTextBoxColumn
        With IDTARIFAS_CARGA_CLIENTE
            .HeaderText = "IDTARIFAS_CARGA_CLIENTE"
            .Name = "IDTARIFAS_CARGA_CLIENTE"
            .DataPropertyName = "IDTARIFAS_CARGA_CLIENTE"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDUNIDAD_AGENCIA As New DataGridViewTextBoxColumn
        With IDUNIDAD_AGENCIA
            .HeaderText = "IDUNIDAD_AGENCIA"
            .Name = "IDUNIDAD_AGENCIA"
            .DataPropertyName = "IDUNIDAD_AGENCIA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDUNIDAD_AGENCIA_DESTINO As New DataGridViewTextBoxColumn
        With IDUNIDAD_AGENCIA_DESTINO
            .HeaderText = "IDUNIDAD_AGENCIA_DESTINO"
            .Name = "IDUNIDAD_AGENCIA_DESTINO"
            .DataPropertyName = "IDUNIDAD_AGENCIA_DESTINO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDUSUARIO_PERSONAL As New DataGridViewTextBoxColumn
        With IDUSUARIO_PERSONAL
            .HeaderText = "IDUSUARIO_PERSONAL"
            .Name = "IDUSUARIO_PERSONAL"
            .DataPropertyName = "IDUSUARIO_PERSONAL"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDUSUARIO_PERSONALMOD As New DataGridViewTextBoxColumn
        With IDUSUARIO_PERSONALMOD
            .HeaderText = "IDUSUARIO_PERSONALMOD"
            .Name = "IDUSUARIO_PERSONALMOD"
            .DataPropertyName = "IDUSUARIO_PERSONALMOD"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IP As New DataGridViewTextBoxColumn
        With IP
            .HeaderText = "IP"
            .Name = "IP"
            .DataPropertyName = "IP"
            .Width = 15
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim IPMOD As New DataGridViewTextBoxColumn
        With IPMOD
            .HeaderText = "IPMOD"
            .Name = "IPMOD"
            .DataPropertyName = "IPMOD"
            .Width = 15
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .HeaderText = "Cliente"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim LOGIN As New DataGridViewTextBoxColumn
        With LOGIN
            .HeaderText = "Funcionario"
            .Name = "LOGIN"
            .DataPropertyName = "LOGIN"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ORIGEN As New DataGridViewTextBoxColumn
        With ORIGEN
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim PO_MONTO_BASE As New DataGridViewTextBoxColumn
        With PO_MONTO_BASE
            .HeaderText = "PO_MONTO_BASE"
            .Name = "PO_MONTO_BASE"
            .DataPropertyName = "PO_MONTO_BASE"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
        With SIMBOLO_MONEDA
            .HeaderText = "M."
            .Name = "SIMBOLO_MONEDA"
            .DataPropertyName = "SIMBOLO_MONEDA"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim PO_X_PESO As New DataGridViewTextBoxColumn
        With PO_X_PESO
            .HeaderText = "PO_X_PESO"
            .Name = "PO_X_PESO"
            .DataPropertyName = "PO_X_PESO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim NRO_GUIAS_VENDIDAS As New DataGridViewTextBoxColumn
        With NRO_GUIAS_VENDIDAS
            .HeaderText = "Nro de Guias Vendidas"
            .Name = "NRO_GUIAS_VENDIDAS"
            .DataPropertyName = "NRO_GUIAS_VENDIDAS"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
        End With

        Dim TOTAL_VENTAS As New DataGridViewTextBoxColumn
        With TOTAL_VENTAS
            .HeaderText = "Total Ventas"
            .Name = "TOTAL_VENTAS"
            .DataPropertyName = "TOTAL_VENTAS"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim NRO_GUIAS_FACTURADAS As New DataGridViewTextBoxColumn
        With NRO_GUIAS_FACTURADAS
            .HeaderText = "Nro. de Guias Facturadas"
            .Name = "NRO_GUIAS_FACTURADAS"
            .DataPropertyName = "NRO_GUIAS_FACTURADAS"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N"
            .DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
        End With




        Dim TOTAL_FACTURADO As New DataGridViewTextBoxColumn
        With TOTAL_FACTURADO
            .HeaderText = "Total Facturado"
            .Name = "TOTAL_FACTURADO"
            .DataPropertyName = "TOTAL_FACTURADO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim NRO_GUIAS_FACTURAR As New DataGridViewTextBoxColumn
        With NRO_GUIAS_FACTURAR
            .HeaderText = "Nro Guias por Facturar"
            .Name = "NRO_GUIAS_FACTURAR"
            .DataPropertyName = "NRO_GUIAS_FACTURAR"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
        End With

        Dim TOTAL_FACTURAR As New DataGridViewTextBoxColumn
        With TOTAL_FACTURAR
            .HeaderText = "Total por Facturar"
            .Name = "TOTAL_FACTURAR"
            .DataPropertyName = "TOTAL_FACTURAR"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim RECEPCIONADO As New DataGridViewTextBoxColumn
        With RECEPCIONADO
            .HeaderText = "Recepcionado"
            .Name = "RECEPCIONADO"
            .DataPropertyName = "RECEPCIONADO"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim DESPACHADO As New DataGridViewTextBoxColumn
        With DESPACHADO
            .HeaderText = "Despachado"
            .Name = "DESPACHADO"
            .DataPropertyName = "DESPACHADO"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim PENDIENTE As New DataGridViewTextBoxColumn
        With PENDIENTE
            .HeaderText = "Pendiente"
            .Name = "PENDIENTE"
            .DataPropertyName = "PENDIENTE"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim CANTIDAD_ENTRE_DOMI As New DataGridViewTextBoxColumn
        With CANTIDAD_ENTRE_DOMI
            .HeaderText = "Entregado Domicilio"
            .Name = "CANTIDAD_ENTRE_DOMI"
            .DataPropertyName = "CANTIDAD_ENTRE_DOMI"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim CANTIDAD_PENDI_DOMI As New DataGridViewTextBoxColumn
        With CANTIDAD_PENDI_DOMI
            .HeaderText = "Por Entregar Domicilio"
            .Name = "CANTIDAD_PENDI_DOMI"
            .DataPropertyName = "CANTIDAD_PENDI_DOMI"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        With DGV3
            .Columns.AddRange(IDPERSONA, LOGIN, RAZON_SOCIAL, NRO_GUIAS_VENDIDAS, TOTAL_VENTAS, NRO_GUIAS_FACTURADAS, TOTAL_FACTURADO, NRO_GUIAS_FACTURAR, TOTAL_FACTURAR, RECEPCIONADO, DESPACHADO, PENDIENTE, CANTIDAD_ENTRE_DOMI, CANTIDAD_PENDI_DOMI)
        End With
    End Sub

    Private Sub FrmConsulFacturados_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmConsulFacturados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub


    Private Sub FrmConsulFactuEmiti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ObjPersona.CODIGO_CLIENTE = "NULL"
            ObjPersona.IDTIPO_PERSONA = 0
            ObjPersona.IDPERSONA = 0

            Me.DTPFECHAINICIOFACTURA.Value = Now.Date.ToShortDateString
            Me.DTPFECHAINICIOFACTURA.Value = Now.Date.ToShortDateString

            Dim p_id_rol_usuario, p_idagencia As Int64
            p_id_rol_usuario = 0

            p_idagencia = 0

            Me.ShadowLabel1.Text = "Consulta de Guias Total Vendidos y Total Facturados"
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False

            ObjPersona.CODIGO_CLIENTE = "NULL"
            ObjPersona.IDTIPO_PERSONA = 0
            ObjPersona.IDPERSONA = 0

            'datahelper
            'dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            Dim ObjProcesos As New ClsLbTepsa.dtoProcesos

            'datahelper
            'objgeneral.FN_L_FUNCIONARIOS(VOCONTROLUSUARIO, Me.CBIDUSUARIO_PERSONAL, 11)
            'hlamas 06-01-2014
            'objgeneral.FN_L_FUNCIONARIOS(Me.CBIDUSUARIO_PERSONAL, 11)


            CBIDUSUARIO_PERSONAL.SelectedIndex = -1

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub cmbAgencia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        DGV3.DataSource = Nothing
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
                    Dim obj As New ClsLbTepsa.dtoFACTURA
                    If Me.DGV3.RowCount <= 0 Then
                        MsgBox("No existen registro", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
                        Exit Sub
                    End If
                    If Not IsNothing(Me.CBIDUSUARIO_PERSONAL.SelectedValue) Then
                        obj.IDUSUARIO_PERSONAL = Me.CBIDUSUARIO_PERSONAL.SelectedValue
                    Else
                        obj.IDUSUARIO_PERSONAL = 0
                    End If

                    obj.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString
                    obj.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString

                    With obj

                        ObjReport.rutaRpt = PathFrmReport
                        ObjReport.conectar(rptservice, rptuser, rptpass)
                        ObjReport.printrptB(False, "", "GUI008.RPT", _
                        "p_idusuario_personal;" & .IDUSUARIO_PERSONAL, _
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

    Private Sub txtCodigoCliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        DGV3.DataSource = Nothing
    End Sub
    Private Sub DTPFECHAINICIOFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        DGV3.DataSource = Nothing
    End Sub
    Private Sub DTPFECHAFINALFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        DGV3.DataSource = Nothing
    End Sub
    Private Sub cbidtipo_moneda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        DGV3.DataSource = Nothing
    End Sub
    Private Sub cmbUsuarios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            Me.Button3.Focus()
        End If
    End Sub

    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub

    Private Sub DGV3_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.CellEnter
        Try
            With ObjDESPACHO_RECEPCION
                .IDPERSONA = Me.DGV3.CurrentRow.Cells("IDPERSONA").Value
                .FECHA_INI = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString
                .FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString
                FORMAT_GRILLA2()

            End With
        Catch ex As System.Data.OracleClient.OracleException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Seguridad del Sistema...")
        Catch se As System.Exception
            MsgBox(se.ToString, MsgBoxStyle.Exclamation, "Seguridad del Sistema...")
        End Try
    End Sub
    Sub FORMAT_GRILLA2()
        DGV2.Columns.Clear()
        With DGV2
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            'Datahelper
            .DataSource = ObjDESPACHO_RECEPCION.SP_L_V_L_DESPACHOS_PERSO()
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim IMAGEN As New DataGridViewImageColumn
        With IMAGEN
            .HeaderText = "E."
            '.Name = "CODIGO_BARRA"
            .DataPropertyName = "IMAGEN"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Image = bmActivo
        End With

        Dim FECHA_GUIA As New DataGridViewTextBoxColumn

        With FECHA_GUIA
            .HeaderText = "Fecha. Documeto"
            .Name = "FECHA_GUIA"
            .DataPropertyName = "FECHA_GUIA"
            .Width = 80
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim NRO_GUIA As New DataGridViewTextBoxColumn

        With NRO_GUIA
            .HeaderText = "Nro. Guia"
            .Name = "NRO_GUIA"
            .DataPropertyName = "NRO_GUIA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim IDCOMPROBANTE As New DataGridViewTextBoxColumn

        With IDCOMPROBANTE
            .HeaderText = "IDCOMPROBANTE"
            .Name = "IDCOMPROBANTE"
            .DataPropertyName = "IDCOMPROBANTE"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = False
        End With
        Dim IDTIPO_COMPROBANTE As New DataGridViewTextBoxColumn

        With IDTIPO_COMPROBANTE
            .HeaderText = "IDTIPO_COMPROBANTE"
            .Name = "IDTIPO_COMPROBANTE"
            .DataPropertyName = "IDTIPO_COMPROBANTE"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = False
        End With
        Dim IDAGENCIAS As New DataGridViewTextBoxColumn

        With IDAGENCIAS
            .HeaderText = "IDAGENCIAS"
            .Name = "IDAGENCIAS"
            .DataPropertyName = "IDAGENCIAS"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = False
        End With
        Dim IDUNIDAD_AGENCIA As New DataGridViewTextBoxColumn

        With IDUNIDAD_AGENCIA
            .HeaderText = "Unidad Origen"
            .Name = "IDUNIDAD_AGENCIA"
            .DataPropertyName = "IDUNIDAD_AGENCIA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = False
        End With
        Dim ORIGEN As New DataGridViewTextBoxColumn

        With ORIGEN
            .HeaderText = "Unidad Origen"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim IDAGENCIAS_DESTINO As New DataGridViewTextBoxColumn

        With IDAGENCIAS_DESTINO
            .HeaderText = "IDAGENCIAS_DESTINO"
            .Name = "IDAGENCIAS_DESTINO"
            .DataPropertyName = "IDAGENCIAS_DESTINO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = False
        End With
        Dim IDUNIDAD_AGENCIA_DESTI As New DataGridViewTextBoxColumn

        With IDUNIDAD_AGENCIA_DESTI
            .HeaderText = "Unidad Destino"
            .Name = "IDUNIDAD_AGENCIA_DESTI"
            .DataPropertyName = "IDUNIDAD_AGENCIA_DESTI"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = False
        End With
        Dim DESTINO As New DataGridViewTextBoxColumn

        With DESTINO
            .HeaderText = "Unidad Destino"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim RECEPCIONADO As New DataGridViewTextBoxColumn
        With RECEPCIONADO
            .HeaderText = "Recepcionado"
            .Name = "RECEPCIONADO"
            .DataPropertyName = "RECEPCIONADO"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim DESPACHADO As New DataGridViewTextBoxColumn
        With DESPACHADO
            .HeaderText = "Despachado"
            .Name = "DESPACHADO"
            .DataPropertyName = "DESPACHADO"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim PENDIENTE As New DataGridViewTextBoxColumn
        With PENDIENTE
            .HeaderText = "Pendiente"
            .Name = "PENDIENTE"
            .DataPropertyName = "PENDIENTE"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim CANTIDAD_ENTRE_DOMI As New DataGridViewTextBoxColumn
        With CANTIDAD_ENTRE_DOMI
            .HeaderText = "Entregado Domicilio"
            .Name = "CANTIDAD_ENTRE_DOMI"
            .DataPropertyName = "CANTIDAD_ENTRE_DOMI"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim CANTIDAD_PENDI_DOMI As New DataGridViewTextBoxColumn
        With CANTIDAD_PENDI_DOMI
            .HeaderText = "Por Entregar Domicilio"
            .Name = "CANTIDAD_PENDI_DOMI"
            .DataPropertyName = "CANTIDAD_PENDI_DOMI"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With


        Dim IDESTADO_ENVIO As New DataGridViewTextBoxColumn
        With IDESTADO_ENVIO
            .HeaderText = "IDESTADO_ENVIO"
            .Name = "IDESTADO_ENVIO"
            .DataPropertyName = "IDESTADO_ENVIO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = False
        End With

        Dim TOTAL_VOLUMEN As New DataGridViewTextBoxColumn
        With TOTAL_VOLUMEN
            .HeaderText = "T. Vol"
            .Name = "TOTAL_VOLUMEN"
            .DataPropertyName = "TOTAL_VOLUMEN"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Width = 50
            .Visible = True
        End With

        Dim TOTAL_PESO As New DataGridViewTextBoxColumn
        With TOTAL_PESO
            .HeaderText = "T. Peso"
            .Name = "TOTAL_PESO"
            .DataPropertyName = "TOTAL_PESO"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Width = 50
            .Visible = True
        End With

        Dim SOBRES As New DataGridViewTextBoxColumn
        With SOBRES
            .HeaderText = "T. Sobres"
            .Name = "SOBRES"
            .DataPropertyName = "SOBRES"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Width = 50
            .Visible = True
        End With

        Dim NRO_GUIA_TRANSPORTISTA As New DataGridViewTextBoxColumn
        With NRO_GUIA_TRANSPORTISTA
            .HeaderText = "Guia Transpor."
            .Name = "NRO_GUIA_TRANSPORTISTA"
            .DataPropertyName = "NRO_GUIA_TRANSPORTISTA"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            '.DefaultCellStyle.Format = "N0"
            '.DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Width = 100
            .Visible = True
        End With

        With DGV2
            .Columns.AddRange( _
            IMAGEN, _
            IDESTADO_ENVIO, _
            IDTIPO_COMPROBANTE, _
            IDCOMPROBANTE, _
            FECHA_GUIA, _
            NRO_GUIA, _
            IDAGENCIAS, _
            IDUNIDAD_AGENCIA, _
            ORIGEN, _
            IDAGENCIAS_DESTINO, _
            IDUNIDAD_AGENCIA_DESTI, _
            DESTINO, _
            SOBRES, _
            TOTAL_PESO, _
            TOTAL_VOLUMEN, _
            RECEPCIONADO, _
            DESPACHADO, _
            PENDIENTE, _
            CANTIDAD_ENTRE_DOMI, _
            CANTIDAD_PENDI_DOMI, _
            NRO_GUIA_TRANSPORTISTA _
            )
        End With
    End Sub

    Private Sub DGV2_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGV2.CellFormatting

        Try

            If Me.DGV2.RowCount <= 0 Then Exit Sub
            If e.ColumnIndex = 0 Then
                If e.RowIndex >= 0 Then
                    If Not IsDBNull(Me.DGV2.Rows(e.RowIndex).Cells("IDESTADO_ENVIO").Value) Then
                        Select Case Me.DGV2.Rows(e.RowIndex).Cells("IDESTADO_ENVIO").Value
                            Case 18
                                e.Value = C_RECEPCIONADO
                            Case 19
                                e.Value = C_DESPACHADO
                            Case 41
                                e.Value = C_DESPACHO_PARCIAL
                            Case 20
                                e.Value = C_LLEGADA
                            Case 40
                                e.Value = C_LLEGADA_PARCIAL
                            Case 25
                                e.Value = C_PERDIDO
                            Case 21
                                e.Value = C_ENTREGADO
                            Case 22
                                e.Value = C_CARGO
                            Case Else
                                e.Value = bmpNoImagen
                        End Select
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Seguridad Sistema...")
        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAINICIOFACTURA.ValueChanged
        ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.CBIDUSUARIO_PERSONAL, Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString, Me.DTPFECHAFINALFACTURA.Value.ToShortDateString, 1)
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged
        ClsLbTepsa.dtoGENERAL.CarteraResponsable(Me.CBIDUSUARIO_PERSONAL, Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString, Me.DTPFECHAFINALFACTURA.Value.ToShortDateString, 1)
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub CBIDUSUARIO_PERSONAL_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUSUARIO_PERSONAL.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub DGV3_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGV3.RowsAdded
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.DGV3), 0)
    End Sub

    Private Sub DGV3_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGV3.RowsRemoved
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.DGV3), 0)
    End Sub

    Private Sub DGV2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV2.CellContentClick

    End Sub

    Private Sub DGV2_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGV2.RowsAdded
        Me.LblRegistros2.Text = FormatNumber(NumeroRegistro(Me.DGV2), 0)
    End Sub

    Private Sub DGV2_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGV2.RowsRemoved
        Me.LblRegistros2.Text = FormatNumber(NumeroRegistro(Me.DGV2), 0)
    End Sub
End Class
