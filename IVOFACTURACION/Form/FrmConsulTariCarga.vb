Public Class FrmConsulTariCarga


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
        listar_TARIFAS()
    End Sub
    Private Sub listar_TARIFAS()
        Try

            Dim Obj As New ClsLbTepsa.dtoTARIFAS_CARGA_CLIENTE

            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) And Me.CBIDUNIDAD_AGENCIA.Text.Length > 0 Then
                Obj.IDUNIDAD_AGENCIA = Me.CBIDUNIDAD_AGENCIA.SelectedValue
            Else
                Obj.IDUNIDAD_AGENCIA = 0
            End If

            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) And Me.CBIDUNIDAD_AGENCIA_DESTINO.Text.Length > 0 Then
                Obj.IDUNIDAD_AGENCIA_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
            Else
                Obj.IDUNIDAD_AGENCIA_DESTINO = 0
            End If

            'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
            'dvListar_Tarifas = Obj.FN_L_TARIFAS_CARGA(VOCONTROLUSUARIO)
            dvListar_Tarifas = Obj.FN_L_TARIFAS_CARGA()
            FORMAT_GRILLA3()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub DGV3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.CellContentClick

    End Sub

    Sub FORMAT_GRILLA3()
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
            .HeaderText = "MONTO BASE"
            .Name = "CG_MONTO_BASE"
            .DataPropertyName = "CG_MONTO_BASE"
            .Width = 55
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim CG_X_PESO As New DataGridViewTextBoxColumn
        With CG_X_PESO
            .HeaderText = "PESO"
            .Name = "CG_X_PESO"
            .DataPropertyName = "CG_X_PESO"
            .Width = 55
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim CG_X_VOLUMEN As New DataGridViewTextBoxColumn
        With CG_X_VOLUMEN
            .HeaderText = "VOL."
            .Name = "CG_X_VOLUMEN"
            .DataPropertyName = "CG_X_VOLUMEN"
            .Width = 55
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim DESTINO As New DataGridViewTextBoxColumn
        With DESTINO
            .HeaderText = "DESTINO"
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
            .Visible = False
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
            .Visible = False
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
            .Visible = False
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
            .Visible = False
        End With
        Dim FECHA_ACTIVACION As New DataGridViewTextBoxColumn
        With FECHA_ACTIVACION
            .HeaderText = "FECHA_ACTIVACION"
            .Name = "FECHA_ACTIVACION"
            .DataPropertyName = "FECHA_ACTIVACION"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
        End With
        Dim FECHA_ACTUALIZACION As New DataGridViewTextBoxColumn
        With FECHA_ACTUALIZACION
            .HeaderText = "FECHA_ACTUALIZACION"
            .Name = "FECHA_ACTUALIZACION"
            .DataPropertyName = "FECHA_ACTUALIZACION"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
        End With
        Dim FECHA_DESACTIVACION As New DataGridViewTextBoxColumn
        With FECHA_DESACTIVACION
            .HeaderText = "FECHA_DESACTIVACION"
            .Name = "FECHA_DESACTIVACION"
            .DataPropertyName = "FECHA_DESACTIVACION"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
        End With
        Dim FECHA_REGISTRO As New DataGridViewTextBoxColumn
        With FECHA_REGISTRO
            .HeaderText = "FECHA_REGISTRO"
            .Name = "FECHA_REGISTRO"
            .DataPropertyName = "FECHA_REGISTRO"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
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
            .Visible = False
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
            .Visible = False
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
            .Visible = False
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
            .Visible = False
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
            .Visible = False
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
            .Visible = False
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
            .Visible = False
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
            .Visible = False
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
            .Visible = False
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
            .Visible = False
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
            .Visible = False
        End With
        Dim IP As New DataGridViewTextBoxColumn
        With IP
            .HeaderText = "IP"
            .Name = "IP"
            .DataPropertyName = "IP"
            .Width = 15
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
        End With
        Dim IPMOD As New DataGridViewTextBoxColumn
        With IPMOD
            .HeaderText = "IPMOD"
            .Name = "IPMOD"
            .DataPropertyName = "IPMOD"
            .Width = 15
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
        End With
        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .HeaderText = "RAZON_SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
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
            .Visible = False
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
            .Visible = False
        End With
        Dim PO_X_VOLUMEN As New DataGridViewTextBoxColumn
        With PO_X_VOLUMEN
            .HeaderText = "PO_X_VOLUMEN"
            .Name = "PO_X_VOLUMEN"
            .DataPropertyName = "PO_X_VOLUMEN"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = False
        End With
        Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
        With SIMBOLO_MONEDA
            .HeaderText = "MON."
            .Name = "SIMBOLO_MONEDA"
            .DataPropertyName = "SIMBOLO_MONEDA"
            .Width = 35
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        '13-10-2008 hlamas  agrega nuevas columnas cont/cre
        Dim CG_MONTO_BASE_CONTADO As New DataGridViewTextBoxColumn
        With CG_MONTO_BASE_CONTADO
            .HeaderText = "MONTO BASE"
            .Name = "CG_MONTO_BASE_CONTADO"
            .DataPropertyName = "CG_MONTO_BASE_CONTADO"
            .Width = 55
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim CG_X_PESO_CONTADO As New DataGridViewTextBoxColumn
        With CG_X_PESO_CONTADO
            .HeaderText = "PESO"
            .Name = "CG_X_PESO_CONTADO"
            .DataPropertyName = "CG_X_PESO_CONTADO"
            .Width = 55
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim CG_X_VOLUMEN_CONTADO As New DataGridViewTextBoxColumn
        With CG_X_VOLUMEN_CONTADO
            .HeaderText = "VOL."
            .Name = "CG_X_VOLUMEN_CONTADO"
            .DataPropertyName = "CG_X_VOLUMEN_CONTADO"
            .Width = 55
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim CG_X_SOBRE As New DataGridViewTextBoxColumn
        With CG_X_SOBRE
            .HeaderText = "SOBRE"
            .Name = "CG_X_SOBRE"
            .DataPropertyName = "CG_X_SOBRE"
            .Width = 55
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim CG_X_SOBRE_CONTADO As New DataGridViewTextBoxColumn
        With CG_X_SOBRE_CONTADO
            .HeaderText = "SOBRE"
            .Name = "CG_X_SOBRE_CONTADO"
            .DataPropertyName = "CG_X_SOBRE_CONTADO"
            .Width = 55
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        With DGV3
            .Columns.AddRange(ORIGEN, DESTINO, SIMBOLO_MONEDA, CG_MONTO_BASE, CG_X_PESO, CG_X_VOLUMEN, CG_X_SOBRE, CG_MONTO_BASE_CONTADO, CG_X_PESO_CONTADO, CG_X_VOLUMEN_CONTADO, CG_X_SOBRE_CONTADO)
        End With
    End Sub

    Private Sub FrmConsulTariCarga_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmConsulTariCarga_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmConsulFactuEmiti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim p_id_rol_usuario, p_idagencia As Int64
            p_id_rol_usuario = 0

            p_idagencia = 0

            Me.ShadowLabel1.Text = "Consulta de Tarifas Publica"
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False

            ObjPersona.CODIGO_CLIENTE = "NULL"
            ObjPersona.IDTIPO_PERSONA = 0
            ObjPersona.IDPERSONA = 0

            'datahleper
            objgeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA)
            objgeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA_DESTINO)

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                    If Me.DGV3.RowCount <= 0 Then
                        MsgBox("No existen registro", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
                        Exit Sub
                    End If

                    Dim Obj As New ClsLbTepsa.dtoTARIFAS_CARGA_CLIENTE

                    If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) And Me.CBIDUNIDAD_AGENCIA.Text.Length > 0 Then
                        Obj.IDUNIDAD_AGENCIA = Me.CBIDUNIDAD_AGENCIA.SelectedValue
                    Else
                        Obj.IDUNIDAD_AGENCIA = 0
                    End If

                    If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) And Me.CBIDUNIDAD_AGENCIA_DESTINO.Text.Length > 0 Then
                        Obj.IDUNIDAD_AGENCIA_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
                    Else
                        Obj.IDUNIDAD_AGENCIA_DESTINO = 0
                    End If
                    With Obj
                        ObjReport.rutaRpt = PathFrmReport
                        ObjReport.conectar(rptservice, rptuser, rptpass)
                        ObjReport.printrptB(False, "", "TAR002_1.RPT", "P_IDUNIDAD_AGENCIA;" & IIf(.IDUNIDAD_AGENCIA = 0, "0", .IDUNIDAD_AGENCIA), "P_IDUNIDAD_AGENCIA_DESTINO;" & IIf(.IDUNIDAD_AGENCIA_DESTINO = 0, "0", .IDUNIDAD_AGENCIA_DESTINO))
                    End With
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
                End Try
        End Select
    End Sub

    Private Sub FrmConsulFactuEmiti_MenuSalir() Handles Me.MenuSalir
        Close()
    End Sub

    Private Sub txtidpersona_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        DGV3.DataSource = Nothing
    End Sub



    Private Sub txtidpersona_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtCodigoCliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        DGV3.DataSource = Nothing
    End Sub



    Private Sub txtCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

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





    Private Sub cmbUsuarios_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        DGV3.DataSource = Nothing
    End Sub


    Private Sub cmbUsuarios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            Me.Button3.Focus()
        End If
    End Sub


    Private Sub cmbAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.TextChanged
        'CBIDUNIDAD_AGENCIA_DESTINO = 0
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub DGV3_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGV3.RowsAdded
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.DGV3), 0)
    End Sub

    Private Sub DGV3_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGV3.RowsRemoved
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.DGV3), 0)
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA.SelectedIndexChanged
        Me.DGV3.DataSource = Nothing
    End Sub
End Class
