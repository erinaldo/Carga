Public Class FrmConsulTariClien


    Dim dvListar_Tarifas As New DataView

    Dim dvTarifasCliente As New DataView

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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If RBCLIEN.Checked = True Then
            listar_TARIFAS()
        Else
            Listar_tarifas_publicas()
        End If
    End Sub
    Sub FORMAT_GRILLA_PUBLI()
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
            .HeaderText = "Des"
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
            .HeaderText = "RAZON_SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ORIGEN As New DataGridViewTextBoxColumn
        With ORIGEN
            .HeaderText = "Ori."
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
        With DGV3

            .Columns.AddRange(ORIGEN, DESTINO, SIMBOLO_MONEDA, CG_MONTO_BASE, CG_X_PESO, CG_X_VOLUMEN)

        End With
    End Sub
    Private Sub Listar_tarifas_publicas()

        Try

            Dim Obj As New ClsLbTepsa.dtoTARIFAS_CARGA_CLIENTE

            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
                Obj.IDUNIDAD_AGENCIA = Me.CBIDUNIDAD_AGENCIA.SelectedValue
            Else
                Obj.IDUNIDAD_AGENCIA = 0
            End If

            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                Obj.IDUNIDAD_AGENCIA_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
            Else
                Obj.IDUNIDAD_AGENCIA_DESTINO = 0
            End If


            'datahelper
            'dvListar_Tarifas = Obj.FN_L_TARIFAS_CARGA(VOCONTROLUSUARIO)
            dvListar_Tarifas = Obj.FN_L_TARIFAS_CARGA()
            FORMAT_GRILLA_PUBLI()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub listar_TARIFAS()
        Try
            Dim Obj As New ClsLbTepsa.dtoTARIFAS_CARGA_CLIENTE

            If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                Obj.IDPERSONA = 0
            Else

                Obj.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
            End If

            If Not IsNothing(Me.CBIDUSUARIO_PERSONAL.SelectedValue) Then
                Obj.IDUSUARIO_PERSONAL = Me.CBIDUSUARIO_PERSONAL.SelectedValue
            Else
                Obj.IDUSUARIO_PERSONAL = 0
            End If

            '-------------- Actualmente esta codificado asi --------------
            'dvListar_Tarifas = Obj.FN_L_TARIFAS_CLIEN()
            'FORMAT_GRILLA3()
            '-------------------------------------------------------------

            dvTarifasCliente = Funciones.CargarTarifaCliente(txtCodigoCliente.Text.Trim, DGV3)

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
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
        Dim FUNCIONARIO As New DataGridViewTextBoxColumn
        With FUNCIONARIO
            .HeaderText = "Funcionario"
            .Name = "FUNCIONARIO"
            .DataPropertyName = "FUNCIONARIO"
            .Width = 200
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
        With DGV3

            .Columns.AddRange(ORIGEN, DESTINO, RAZON_SOCIAL, FUNCIONARIO, SIMBOLO_MONEDA, CG_MONTO_BASE, CG_X_PESO, CG_X_VOLUMEN)

        End With
    End Sub

    Private Sub FrmConsulTariClien_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmConsulTariClien_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmConsulFactuEmiti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ObjPersona.CODIGO_CLIENTE = "NULL"
            ObjPersona.IDTIPO_PERSONA = 0
            ObjPersona.IDPERSONA = 0


            'datahelper
            'objgeneral.FN_L_UNIDAD_agencia_(VOCONTROLUSUARIO, Me.CBIDUNIDAD_AGENCIA)
            'objgeneral.FN_L_UNIDAD_agencia_(VOCONTROLUSUARIO, Me.CBIDUNIDAD_AGENCIA_DESTINO)

            objgeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA)
            objgeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA_DESTINO)


            Dim p_id_rol_usuario, p_idagencia As Int64
            p_id_rol_usuario = 0

            p_idagencia = 0

            Me.ShadowLabel1.Text = "Consulta de Tarifas"
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
            ObjProcesos.fnCargar_iWin_r(Me.txtidpersona, dvlistar_persona_todos, Colllistar_persona_todos, Iwinlistar_persona_todos, 0)

            'datahelper
            'objgeneral.FN_L_FUNCIONARIOS(VOCONTROLUSUARIO, Me.CBIDUSUARIO_PERSONAL, 11)

            'hlamas 06-01-2014
            'objgeneral.FN_L_FUNCIONARIOS(Me.CBIDUSUARIO_PERSONAL, 11)
            ClsLbTepsa.dtoGENERAL.CarteraResponsable(CBIDUSUARIO_PERSONAL, "", "", 3)


            CBIDUNIDAD_AGENCIA.SelectedIndex = -1
            CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndex = -1
            CBIDUSUARIO_PERSONAL.SelectedIndex = -1

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

        If Me.RBCLIEN.Checked = True Then

            Select Case Me.TabMante.SelectedIndex
                Case 0
                    Try
                        If Me.DGV3.RowCount <= 0 Then
                            MsgBox("No existen registro", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
                            Exit Sub
                        End If
                        Dim ObjFactura As New ClsLbTepsa.dtoFACTURA

                        If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                            ObjFactura.IDPERSONA = 0
                        Else

                            ObjFactura.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                        End If

                        If Not IsNothing(Me.CBIDUSUARIO_PERSONAL.SelectedValue) Then
                            ObjFactura.IDUSUARIO_PERSONAL = Me.CBIDUSUARIO_PERSONAL.SelectedValue
                        Else
                            ObjFactura.IDUSUARIO_PERSONAL = 0
                        End If
                        With ObjFactura

                            ObjReport.rutaRpt = PathFrmReport
                            ObjReport.conectar(rptservice, rptuser, rptpass)
                            ObjReport.printrptB(False, "", "TAR001.RPT", _
                            "p_idpersona;" & .IDPERSONA, _
                            "P_IDUSUARIO_PERSONAL;" & .IDUSUARIO_PERSONAL)
                        End With
                    Catch ex As Exception
                        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
                    End Try
            End Select
        Else
            Select Case Me.TabMante.SelectedIndex
                Case 0
                    Try
                        If Me.DGV3.RowCount <= 0 Then
                            MsgBox("No existen registro", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
                            Exit Sub
                        End If

                        Dim Obj As New ClsLbTepsa.dtoTARIFAS_CARGA_CLIENTE

                        If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
                            Obj.IDUNIDAD_AGENCIA = Me.CBIDUNIDAD_AGENCIA.SelectedValue
                        Else
                            Obj.IDUNIDAD_AGENCIA = 0
                        End If

                        If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                            Obj.IDUNIDAD_AGENCIA_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
                        Else
                            Obj.IDUNIDAD_AGENCIA_DESTINO = 0
                        End If

                        With Obj

                            ObjReport.rutaRpt = PathFrmReport
                            ObjReport.conectar(rptservice, rptuser, rptpass)
                            ObjReport.printrptB(False, "", "TAR002.RPT", "P_IDUNIDAD_AGENCIA;" & .IDUNIDAD_AGENCIA, "P_IDUNIDAD_AGENCIA_DESTINO;" & .IDUNIDAD_AGENCIA_DESTINO)



                        End With
                    Catch ex As Exception
                        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
                    End Try
            End Select
        End If
    End Sub
    Private Sub FrmConsulFactuEmiti_MenuSalir() Handles Me.MenuSalir
        Close()
    End Sub

    Private Sub txtidpersona_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtidpersona.GotFocus
        CBIDUSUARIO_PERSONAL.SelectedIndex = -1
        DGV3.DataSource = Nothing
    End Sub
    Private Sub txtidpersona_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtidpersona.KeyUp
        If e.KeyCode = 13 Then
            If Not Iwinlistar_persona_todos.IndexOf(txtidpersona.Text) = -1 Then
                With ObjPersona
                    .IDPERSONA = Int(Colllistar_persona_todos.Item(Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
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

        End If
    End Sub
    Private Sub txtCodigoCliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.GotFocus
        DGV3.DataSource = Nothing
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

                'datahelper
                'If ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE).Count = 1 Then
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

    Private Sub RBCLIEN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBCLIEN.CheckedChanged
        Me.GroupBox2.Visible = False
        Me.GroupBox1.Visible = True

    End Sub

    Private Sub RBPUBLI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBPUBLI.CheckedChanged
        Me.GroupBox2.Visible = True
        Me.GroupBox1.Visible = False
    End Sub

    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub

    Private Sub CBIDUSUARIO_PERSONAL_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUSUARIO_PERSONAL.SelectedIndexChanged
        txtidpersona.Text = ""
        txtCodigoCliente.Text = ""
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If RBCLIEN.Checked = True Then
            listar_TARIFAS()
        Else
            Listar_tarifas_publicas()
        End If
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

    Private Sub txtCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.TextChanged
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub txtidpersona_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtidpersona.TextChanged
        Me.DGV3.DataSource = Nothing
    End Sub
End Class
