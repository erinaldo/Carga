Imports INTEGRACION_LN
Imports INTEGRACION_EN
Public Class FrmTarifasSubCuenta
    Dim idTarifaSubCuenta As String
    Dim idCentroCosto As String
    'Private objBuscarTarifaCargaCliente_LN As Cls_TarifaCargaClientes_LN
#Region "Atributos"

    'Private lObj_ClsTarifaSubCuentaLN As Cls_TarifaSubCuentaLN

#End Region


    Public hnd As Long
    Dim col_Origen As New Collection
    Dim col_Destino As New Collection

    Dim col_Origen_Cta As New Collection
    Dim col_Destino_Cta As New Collection
    Dim Col_CentroCosto As New Collection

    Dim col_Funcionario As New Collection
    Dim col_Cliente As New Collection
    Dim daControl_FAC As New OleDb.OleDbDataAdapter
    Dim dtControl_FAC As New System.Data.DataTable
    Dim dvControl_FAC As System.Data.DataView
    Dim iControl As Integer = 1  ' Insertar 1 
    '24/10/2007 
    Dim dt_centro_costo As New DataTable
    Dim dv_centro_costo As New DataView
    Dim lds_tmp As New DataSet
    'Private obj_ClsCargaComboDestino As ClsCargaComboDestino
    Dim dt_Resultado2 As Integer
#Region "EVENTOS DE COMPONENTES"

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Sub New(ByVal CodUnidad_Destino As String)

        InitializeComponent()

        'obj_ClsCargaComboDestino = New ClsCargaComboDestino

        'obj_ClsCargaComboDestino.F_CargarComboDestino(cmbDestino_SubCta, "TIPO_SEGURO")
        cmbDestino_SubCta.SelectedValue = CodUnidad_Destino

    End Sub



#End Region


    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub FrmTarifasSubCuenta_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmTarifasSubCuenta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmTarifasSubCuenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToolStripMenuItem1.Text = "CONSULTAS TARIFA"
        ToolStripMenuItem2.Text = "MANTENIMIENTO TARIFA"
        checkVigente.Visible = False
        Button1.Visible = False

        Try
            'Mod.29/09/2009 -->Omendoza - Pasando al datahelper -  
            'rst = Nothing
            'rst = ObjTarifaSubCuenta.fnSP_LISTA_DATOS_TARIFARIOS()
            'ModuUtil.LlenarComboIDs2(rst, cmbOrigen, col_Origen, dtoUSUARIOS.m_idciudad, cmbDestino, col_Destino, 9999)
            'rst.MoveFirst()
            'ModuUtil.LlenarComboIDs2(rst, cmbOrigen_SubCta, col_Origen_Cta, dtoUSUARIOS.m_idciudad, cmbDestino_SubCta, col_Destino_Cta, 9999)
            'ModuUtil.LlenarComboIDs(rst.NextRecordset, cmbFuncionario, col_Funcionario, dtoUSUARIOS.IdLogin)
            lds_tmp = ObjTarifaSubCuenta.fnSP_LISTA_DATOS_TARIFARIOS

            ModuUtil.LlenarComboIDs2(lds_tmp.Tables(0), cmbOrigen, col_Origen, dtoUSUARIOS.m_idciudad, cmbDestino, col_Destino, 9999)
            ' rst.MoveFirst()
            ModuUtil.LlenarComboIDs2(lds_tmp.Tables(0), cmbOrigen_SubCta, col_Origen_Cta, dtoUSUARIOS.m_idciudad, cmbDestino_SubCta, col_Destino_Cta, 9999)
            ModuUtil.LlenarComboIDs_dt(lds_tmp.Tables(1), cmbFuncionario, col_Funcionario, dtoUSUARIOS.IdLogin)
            fnLoadGrid()

            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)

        Catch ex As Exception
            '
        End Try
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Try
            ObjTarifaSubCuenta.v_iControl = 1
            txtCliente.Text = cmbCliente.Text
            txtRuc.Text = ""
            cmbOrigen_SubCta.Text = cmbOrigen.Text
            cmbDestino_SubCta.Text = cmbDestino.Text
            If (cmb_subcuenta.Text = "") Then
                MsgBox("No puede ingresar la tarifa del Cliente " & txtCliente.Text & " por que no tiene sub cuenta," & Chr(13) & " Comuniquese con Sistemas", MsgBoxStyle.Information, "Mensaje Alerta")
                cmb_subcuenta.Focus()
            Else
                cmbCentroCosto.Text = cmb_subcuenta.Text
                txtPrecioPostalBase.Text = 0
                txtPrecioPostalFinal.Text = 0
                txtPrecio_Sobre_public.Text = 0
                txtPrecio_Sobre.Text = 0
                txtPrecioPostalPeso.Text = 0
                txtPrecioPostalPesoFinal.Text = 0
                txtPrecioPostalVolumen.Text = 0
                txtPrecioPostalVolumenFinal.Text = 0
                dtFecha_Activacion.Text = dtoUSUARIOS.m_sFecha
                checkVigente.Checked = False
                SelectMenu(1)

                txtPrecioPostalBase.Enabled = True
                txtPrecioPostalFinal.Enabled = True
                txtPrecio_Sobre_public.Enabled = True
                txtPrecio_Sobre.Enabled = True
                txtPrecioPostalPeso.Enabled = True
                txtPrecioPostalPesoFinal.Enabled = True
                txtPrecioPostalVolumen.Enabled = True
                txtPrecioPostalVolumenFinal.Enabled = True
                txtRuc.Enabled = False
                CargaTarifaSubCuenta()
                'Bloquear_Data2()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function CargaTarifaSubCuenta() As String
        Try

            ObjTarifaSubCuenta.v_IDUNIDAD_AGENCIA = Int(col_Origen_Cta.Item(cmbOrigen_SubCta.SelectedIndex.ToString()))
            ObjTarifaSubCuenta.v_IDUNIDAD_AGENCIA_DESTINO = Int(col_Destino_Cta.Item(cmbDestino_SubCta.SelectedIndex.ToString()))
            If ObjTarifaSubCuenta.fnSP_LISTA_TARIFA_PUBLICA() = True Then
                txtPrecioPostalBase.Text = ObjTarifaSubCuenta.Cg_Monto_Base
                txtPrecio_Sobre_public.Text = ObjTarifaSubCuenta.Cg_Monto_Base
                txtPrecioPostalPeso.Text = ObjTarifaSubCuenta.Cg_x_Peso
                txtPrecioPostalVolumen.Text = ObjTarifaSubCuenta.Cg_x_Volumen
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Private Function F_Centro_Costo() As Integer


        Dim iPersona As String
        iPersona = ObjTarifaSubCuenta.v_IDCENTRO_COSTO

        ' lObj_ClsTarifaSubCuentaLN = New Cls_TarifaSubCuentaLN
        Dim dtResultado3 As New DataTable

        'dtResultado3 = lObj_ClsTarifaSubCuentaLN.BuscarCentroCostoLN(iPersona)
        idCentroCosto = IIf(IsDBNull(dtResultado3.Rows(0)("CENTRO_COSTO")), "", dtResultado3.Rows(0)("CENTRO_COSTO"))



    End Function

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click


        Try
            ObjTarifaSubCuenta.v_iControl = 2
            If DataGridViewTarifa.Rows().Count - 1 = 0 Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            Dim row As Integer = DataGridViewTarifa.SelectedRows.Item(0).Index
            If DataGridViewTarifa.Rows().Count - 1 = row Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            ObjTarifaSubCuenta.v_IDTARIFA_SUB_CUENTA = DataGridViewTarifa.Rows(row).Cells(1).Value

            If ObjTarifaSubCuenta.fnSP_DATOS_TARIFA_SUBCUENTA() = True Then
                txtCliente.Text = ObjTarifaSubCuenta.v_RAZON_SOCIAL
                txtRuc.Text = ObjTarifaSubCuenta.v_RUC

                ' TRAIGO EL DESTINO Y EL ORIGEN DE ACUERDO A MI SELECCION - DIEGO ZEGARRA 27/06/2013
                ModuUtil.LlenarComboIDs2(lds_tmp.Tables(0), cmbOrigen_SubCta, col_Origen, ObjTarifaSubCuenta.v_IDUNIDAD_AGENCIA, cmbDestino_SubCta, col_Destino, ObjTarifaSubCuenta.v_IDUNIDAD_AGENCIA_DESTINO)
                'FIN
                txtPrecioPostalBase.Text = ObjTarifaSubCuenta.Cg_Monto_Base
                txtPrecioPostalFinal.Text = ObjTarifaSubCuenta.v_MONTO_BASE
                txtPrecio_Sobre_public.Text = ObjTarifaSubCuenta.Cg_Monto_Base
                txtPrecio_Sobre.Text = ObjTarifaSubCuenta.v_PRECIO_X_SOBRE
                txtPrecioPostalPeso.Text = ObjTarifaSubCuenta.Cg_x_Peso
                txtPrecioPostalPesoFinal.Text = ObjTarifaSubCuenta.v_PRECIO_X_PESO
                txtPrecioPostalVolumen.Text = ObjTarifaSubCuenta.Cg_x_Volumen
                txtPrecioPostalVolumenFinal.Text = ObjTarifaSubCuenta.v_PRECIO_X_VOLUMEN
                dtFecha_Activacion.Text = ObjTarifaSubCuenta.v_FECHA_ACTIVACION
                'Obteniendo el Centro de Costo
                F_Centro_Costo()

                cmbCentroCosto.Text = idCentroCosto


                SelectMenu(1)
                Bloquear_Data2()
            Else
                MsgBox("Revizar datos... no Existen resultados para esta busqueda...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnVerData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerData.Click
        Try
            ObjTarifaSubCuenta.v_iControl = 5
            If DataGridViewTarifa.Rows().Count - 1 = 0 Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            Dim row As Integer = DataGridViewTarifa.SelectedRows.Item(0).Index
            If DataGridViewTarifa.Rows().Count - 1 = row Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            ObjTarifaSubCuenta.v_IDTARIFA_SUB_CUENTA = DataGridViewTarifa.Rows(row).Cells(1).Value

            If ObjTarifaSubCuenta.fnSP_DATOS_TARIFA_SUBCUENTA() = True Then
                txtCliente.Text = ObjTarifaSubCuenta.v_RAZON_SOCIAL
                txtRuc.Text = ObjTarifaSubCuenta.v_RUC
                '
                txtPrecioPostalBase.Text = ObjTarifaSubCuenta.Cg_Monto_Base
                txtPrecioPostalFinal.Text = ObjTarifaSubCuenta.v_MONTO_BASE
                txtPrecio_Sobre_public.Text = ObjTarifaSubCuenta.Cg_Monto_Base
                txtPrecio_Sobre.Text = ObjTarifaSubCuenta.v_PRECIO_X_SOBRE
                txtPrecioPostalPeso.Text = ObjTarifaSubCuenta.Cg_x_Peso
                txtPrecioPostalPesoFinal.Text = ObjTarifaSubCuenta.v_PRECIO_X_PESO
                txtPrecioPostalVolumen.Text = ObjTarifaSubCuenta.Cg_x_Volumen
                txtPrecioPostalVolumenFinal.Text = ObjTarifaSubCuenta.v_PRECIO_X_VOLUMEN
                dtFecha_Activacion.Text = ObjTarifaSubCuenta.v_FECHA_ACTIVACION
                'Obteniendo el Centro de Costo
                F_Centro_Costo()
                cmbCentroCosto.Text = idCentroCosto

                SelectMenu(1)
                Bloquear_Data()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Public Function Bloquear_Data2() As String

        txtPrecioPostalBase.Enabled = True
        txtPrecioPostalFinal.Enabled = True
        txtPrecio_Sobre_public.Enabled = True
        txtPrecio_Sobre.Enabled = True
        txtPrecioPostalPeso.Enabled = True
        txtPrecioPostalPesoFinal.Enabled = True
        txtPrecioPostalVolumen.Enabled = True
        txtPrecioPostalVolumenFinal.Enabled = True
        cmbCentroCosto.Enabled = True
        cmbDestino_SubCta.Enabled = True
        cmbOrigen_SubCta.Enabled = True
        txtRuc.Enabled = False
        btnGrabar.Enabled = True
        txtCliente.Enabled = True
        Button1.Enabled = True
        dtFecha_Activacion.Enabled = True

    End Function
    Public Function Bloquear_Data() As String

        txtPrecioPostalBase.Enabled = False
        txtPrecioPostalFinal.Enabled = False
        txtPrecio_Sobre_public.Enabled = False
        txtPrecio_Sobre.Enabled = False
        txtPrecioPostalPeso.Enabled = False
        txtPrecioPostalPesoFinal.Enabled = False
        txtPrecioPostalVolumen.Enabled = False
        txtPrecioPostalVolumenFinal.Enabled = False
        cmbCentroCosto.Enabled = False
        cmbDestino_SubCta.Enabled = False
        cmbOrigen_SubCta.Enabled = False
        txtRuc.Enabled = False
        btnGrabar.Enabled = False
        txtCliente.Enabled = False
        Button1.Enabled = False
        dtFecha_Activacion.Enabled = False

    End Function

    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        Try
            If DataGridViewTarifa.Rows().Count - 1 = 0 Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            Dim row As Integer = DataGridViewTarifa.SelectedRows.Item(0).Index
            If DataGridViewTarifa.Rows().Count - 1 = row Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            ObjTarifaSubCuenta.v_IDTARIFA_SUB_CUENTA = DataGridViewTarifa.Rows(row).Cells(1).Value
            If (MessageBox.Show("Esta Seguro que desea Anular la Tarifa ?", "Mensaje Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                If ObjTarifaSubCuenta.fnSP_ANULAR_TARIFARIO() = True Then
                    DataGridViewTarifa.Rows.RemoveAt(row)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbFuncionario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFuncionario.SelectedIndexChanged
        Dim ldt_tmp As New DataTable
        Try
            Dim index As Integer = Int(col_Funcionario.Item(cmbFuncionario.SelectedIndex.ToString()))
            If index >= 0 Then
                'rst = ObjTarifaSubCuenta.fnSP_LISTA_CLIENTES(index)
                ldt_tmp = ObjTarifaSubCuenta.fnSP_LISTA_CLIENTES(index)
                ModuUtil.LlenarComboIDs_dt(ldt_tmp, cmbCliente, col_Cliente, 9999)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        'Try
        '20/10/2007
        recuperar_datos()
        '    ObjTarifaSubCuenta.iControl = 1
        '    ObjTarifaSubCuenta.v_Origen = Int(col_Origen.Item(cmbOrigen.SelectedIndex.ToString()))
        '    ObjTarifaSubCuenta.v_Destino = Int(col_Destino.Item(cmbDestino.SelectedIndex.ToString()))
        '    ObjTarifaSubCuenta.v_IDPERSONA = Int(col_Cliente.Item(cmbCliente.SelectedIndex.ToString()))
        '    dtControl_FAC.Clear()
        '    DataGridViewTarifa.Refresh()
        '    daControl_FAC.Fill(dtControl_FAC, ObjTarifaSubCuenta.fnSP_BUSCAR_TARIFARIOS())
        '    dvControl_FAC = dtControl_FAC.DefaultView
        '    'bformatImage = True
        '    DataGridViewTarifa.DataSource = dvControl_FAC
        '    DataGridViewTarifa.Refresh()
        '    lbNroRegistro.Text = dvControl_FAC.Count
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
    End Sub
    Public Function fnLoadGrid() As Boolean
        Try
            With DataGridViewTarifa
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
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            Dim idEstadoImage As New DataGridViewImageColumn
            With idEstadoImage
                .DataPropertyName = "imagen"
                .HeaderText = "CL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DisplayIndex = 0
                .Visible = True
                '.ValuesAreIcons = True
                '.InheritedStyle.BackColor = Color.Transparent
                .Image = bmActivo
            End With
            DataGridViewTarifa.Columns.Add(idEstadoImage)
            Dim colID As New DataGridViewTextBoxColumn
            With colID
                .DisplayIndex = 1
                .DataPropertyName = "idtarifa_sub_cuenta"
                .HeaderText = "idtarifa_sub_cuenta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            DataGridViewTarifa.Columns.Add(colID)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub fnGrabar()
        Try
            'ObjTarifaSubCuenta.v_iControl = 1
            ObjTarifaSubCuenta.v_IDTARIFA_SUB_CUENTA = 0
            ObjTarifaSubCuenta.v_IDPERSONA = ObjTarifaSubCuenta.v_IDPERSONA
            ObjTarifaSubCuenta.v_IDCLIENTE_SUBCUENTA = ObjTarifaSubCuenta.v_IDPERSONA
            ObjTarifaSubCuenta.v_IDCENTRO_COSTO = Int(Col_CentroCosto.Item(cmbCentroCosto.SelectedIndex.ToString()))
            ObjTarifaSubCuenta.v_IDUNIDAD_AGENCIA = Int(col_Origen.Item(cmbOrigen_SubCta.SelectedIndex.ToString()))
            ObjTarifaSubCuenta.v_IDUNIDAD_AGENCIA_DESTINO = Int(col_Destino.Item(cmbDestino_SubCta.SelectedIndex.ToString()))
            ObjTarifaSubCuenta.v_PRECIO_X_PESO = IIf(txtPrecioPostalPesoFinal.Text <> "", txtPrecioPostalPesoFinal.Text, 0)
            ObjTarifaSubCuenta.v_PRECIO_X_VOLUMEN = IIf(txtPrecioPostalVolumenFinal.Text <> "", txtPrecioPostalVolumenFinal.Text, 0)
            ObjTarifaSubCuenta.v_PRECIO_X_SOBRE = IIf(txtPrecio_Sobre.Text <> "", txtPrecio_Sobre.Text, 0)
            ObjTarifaSubCuenta.v_MONTO_BASE = IIf(txtPrecioPostalFinal.Text <> "", txtPrecioPostalFinal.Text, 0)
            ObjTarifaSubCuenta.v_ES_VIGENTE = 1
            ObjTarifaSubCuenta.v_IDTIPO_MONEDA = 1
            ObjTarifaSubCuenta.v_IP = dtoUSUARIOS.IP
            ObjTarifaSubCuenta.v_IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            ObjTarifaSubCuenta.v_IDESTADO_REGISTRO = 1
            ObjTarifaSubCuenta.v_FECHA_ACTIVACION = dtFecha_Activacion.Text
            ObjTarifaSubCuenta.v_FECHA_DESACTIVACION = dtFecha_Activacion.Text
            ObjTarifaSubCuenta.v_IDROL_USUARIO = dtoUSUARIOS.IdRol
            ObjTarifaSubCuenta.fnSP_INSUPD_TARIFA_SUB_CUENTA()
            ObjTarifaSubCuenta.v_iControl = 1

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Function F_BuscarTarifaSubCuenta() As Integer

        Dim iOrigen As String
        Dim iDestino As String
        Dim iCliente As String


        iOrigen = Int(col_Origen.Item(cmbOrigen_SubCta.SelectedIndex.ToString()))
        iDestino = Int(col_Destino.Item(cmbDestino_SubCta.SelectedIndex.ToString()))
        iCliente = ObjTarifaSubCuenta.v_IDPERSONA

        ' lObj_ClsTarifaSubCuentaLN = New Cls_TarifaSubCuentaLN
        Dim dtResultado As New DataTable
        'dtResultado = lObj_ClsTarifaSubCuentaLN.F_BuscarTarifaSubCuenta_LN(iOrigen, iDestino, iCliente)

        idTarifaSubCuenta = IIf(IsDBNull(dtResultado.Rows(0)("idtarifa_sub_cuenta")), "", dtResultado.Rows(0)("idtarifa_sub_cuenta"))

    End Function
    Private Function f_Editar() As Integer

        Try
            Dim lStr_MsgGuardar As String
            'lObj_ClsTarifaSubCuentaLN = New Cls_TarifaSubCuentaLN
            Dim ObjTarifaSubCuentaEN As New Cls_TarifaSubCuentaEN

            '09/07/2013 Diego Zegarra T.
            'Busca la Ultima tarifa vigente si es que hubiera mas de una tarifa, es por error de ingresos anteriores
            If (F_BuscarTarifaSubCuenta() > 1) Then
                MsgBox("Por Favor Comunicate con el Area de Sistemas")
            End If

            With ObjTarifaSubCuentaEN

                .iDTARIFA_SUBCUENTA = idTarifaSubCuenta
                .IdPersona = ObjTarifaSubCuenta.v_IDPERSONA
                .iDCLIENTE_SUBCUENTA = ObjTarifaSubCuenta.v_IDPERSONA
                .IDCENTRO_COSTO = Int(Col_CentroCosto.Item(cmbCentroCosto.SelectedIndex.ToString()))
                .IDUNIDAD_AGENCIA = ObjTarifaSubCuenta.v_IDUNIDAD_AGENCIA
                .IDUNIDAD_AGENCIA_DESTINO = ObjTarifaSubCuenta.v_IDUNIDAD_AGENCIA_DESTINO
                .PRECIO_X_PESO = txtPrecioPostalPesoFinal.Text
                .PRECIO_X_VOLUMEN = txtPrecioPostalVolumenFinal.Text
                .PRECIO_X_SOBRE = txtPrecio_Sobre.Text
                .MONTO_BASE = txtPrecioPostalFinal.Text
                .esVigente = 1
                .IDTIPO_MONEDA = 1
                .IP = dtoUSUARIOS.IP
                .IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                .IDESTADO_REGISTRO = 1
                .FECHA_ACTIVACION = Now
                .FECHA_DESACTIVACION = Now
                .IDROL_USUARIO = dtoUSUARIOS.IdRol

            End With

            'lStr_MsgGuardar = lObj_ClsTarifaSubCuentaLN.F_EditarTarifa_LN(ObjTarifaSubCuentaEN)

            If lStr_MsgGuardar.Trim.Length > 0 Then
                MsgBox(lStr_MsgGuardar.Trim, MsgBoxStyle.Critical, "Se produjo un error")
                Return -1
            Else
                MsgBox("Se actualizó el registro", MsgBoxStyle.Information, "Aviso")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Private Function F_ValidaClienteLineaCredito() As String
        'objBuscarTarifaCargaCliente_LN = New Cls_TarifaCargaClientes_LN

        Dim iPersona2 As String
        iPersona2 = ObjTarifaSubCuenta.v_IDPERSONA
        'dt_Resultado2 = objBuscarTarifaCargaCliente_LN.BuscarLC_ClienteLN_1(iPersona2)
    End Function

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        ' Modificado por Diego Zegarra 13/07/2013
        Try
            Dim bflag As Boolean = False
            Dim rstBusqueda As String

            F_ValidaClienteLineaCredito()
            If (dt_Resultado2 > 0) Then
                'rstBusqueda = Funciones.BuscaTarifario_SubCuenta(ObjTarifaSubCuenta.v_IDPERSONA, ObjTarifaSubCuenta.v_IDUNIDAD_AGENCIA, ObjTarifaSubCuenta.v_IDUNIDAD_AGENCIA_DESTINO)
                If rstBusqueda > 0 Then
                    If (MessageBox.Show("YA EXISTE UNA TARIFA PARA LA RUTA " & cmbOrigen_SubCta.Text & " - " & cmbDestino_SubCta.Text & Chr(13) & _
                                           "Desea Modificar la Tarifa?", "Mensaje Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes) Then
                        f_Editar() ' Llama a la funcion que editara, pondra Vigentes en 0 y el nuevo ingreso en 1
                    Else
                        txtPrecioPostalFinal.Focus()
                    End If
                Else
                    If (MessageBox.Show("Esta seguro que desea grabar la tarifa sub Cuenta", "Mensaje Titan", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) = DialogResult.OK) Then
                        fnGrabar()
                        MsgBox("Se grabo Satisfactoriamente")
                    Else
                        txtPrecioPostalFinal.Focus()
                    End If
                End If
            Else
                MessageBox.Show("No se puede Ingresar las Tarifas Sub Cuenta por que no tiene " & Chr(13) & " Linea de Credito Activa ,Comunicate con Sistemas", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Sub limpiarData()
        txtPrecioPostalFinal.Text = ""
        txtPrecio_Sobre.Text = ""
        txtPrecioPostalPesoFinal.Text = ""
        txtPrecioPostalVolumenFinal.Text = ""
    End Sub
    Private Sub cmbCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCliente.SelectedIndexChanged
        '
        ' Dim rst_tmp As New ADODB.Recordset
        '
        Try
            dt_centro_costo = Nothing
            dv_centro_costo = Nothing
            dt_centro_costo = New DataTable
            dv_centro_costo = New DataView
            '
            ObjTarifaSubCuenta.v_IDPERSONA = col_Cliente.Item(cmbCliente.SelectedIndex.ToString())
            If Int(ObjTarifaSubCuenta.v_IDPERSONA) >= 0 Then
                dt_centro_costo = ObjTarifaSubCuenta.fnSP_CENTRO_COSTO()                '                                
                ModuUtil.LlenarComboIDs_dt(dt_centro_costo, cmbCentroCosto, Col_CentroCosto, 9999)

                'rst_tmp = ObjTarifaSubCuenta.fnSP_CENTRO_COSTO()
                'daControl_FAC.Fill(dt_centro_costo, rst_tmp)
                dv_centro_costo = CargarCombo(Me.cmb_subcuenta, dt_centro_costo, "CENTRO_COSTO", "IDCENTRO_COSTO", 0)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            ObjTarifaSubCuenta.v_IDUNIDAD_AGENCIA = Int(col_Origen_Cta.Item(cmbOrigen_SubCta.SelectedIndex.ToString()))
            ObjTarifaSubCuenta.v_IDUNIDAD_AGENCIA_DESTINO = Int(col_Destino_Cta.Item(cmbDestino_SubCta.SelectedIndex.ToString()))
            If ObjTarifaSubCuenta.fnSP_LISTA_TARIFA_PUBLICA() = True Then
                txtPrecioPostalBase.Text = ObjTarifaSubCuenta.Cg_Monto_Base
                txtPrecio_Sobre_public.Text = ObjTarifaSubCuenta.Cg_Monto_Base
                txtPrecioPostalPeso.Text = ObjTarifaSubCuenta.Cg_x_Peso
                txtPrecioPostalVolumen.Text = ObjTarifaSubCuenta.Cg_x_Volumen
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        SelectMenu(0)
        recuperar_datos()
    End Sub
#Region "Tarifa masiva"
    Private Sub btn_masiva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_masiva.Click
        Dim obj_cliente_tarifa_masiva As New frmClientesTarifasMasivas
        Dim ls_idpersona, ls_razon_social As String
        Try
            ls_idpersona = Int(col_Cliente.Item(cmbCliente.SelectedIndex.ToString()))
            ls_razon_social = Me.cmbCliente.Text
            '
            obj_cliente_tarifa_masiva.pl_tipo_tarifa = 2 'Nivel de sub cuenta 
            obj_cliente_tarifa_masiva.ps_idpersona = ls_idpersona
            obj_cliente_tarifa_masiva.ps_razon_social = ls_razon_social
            'obj_cliente_tarifa_masiva.ps_sub_cuenta = Me.cmb_subcuenta.SelectedValue
            obj_cliente_tarifa_masiva.ps_idsub_cuenta = IIf(Me.cmb_subcuenta.SelectedValue = Nothing Or IsDBNull(Me.cmb_subcuenta.SelectedValue) = True, 0, Me.cmb_subcuenta.SelectedValue)
            '

            'obj_cliente_tarifa_masiva.ShowDialog()

            Acceso.Asignar(obj_cliente_tarifa_masiva, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                obj_cliente_tarifa_masiva.Show()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If obj_cliente_tarifa_masiva.pb_cancelar = False Then
                recuperar_datos()
            End If
            obj_cliente_tarifa_masiva = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
#End Region
    Sub recuperar_datos()
        Try
            ObjTarifaSubCuenta.iControl = 1
            ObjTarifaSubCuenta.v_Origen = Int(col_Origen.Item(cmbOrigen.SelectedIndex.ToString()))
            ObjTarifaSubCuenta.v_Destino = Int(col_Destino.Item(cmbDestino.SelectedIndex.ToString()))
            ObjTarifaSubCuenta.v_IDPERSONA = Int(col_Cliente.Item(cmbCliente.SelectedIndex.ToString()))
            If Me.cmb_subcuenta.SelectedValue < 1 Then
                ObjTarifaSubCuenta.ls_idcentro_costo = "0"
            Else
                ObjTarifaSubCuenta.ls_idcentro_costo = CType(Me.cmb_subcuenta.SelectedValue, String)
            End If
            dtControl_FAC.Clear()
            DataGridViewTarifa.Refresh()
            '
            'Mod.29/09/2009 -->Omendoza - Pasando al datahelper -  
            'daControl_FAC.Fill(dtControl_FAC, ObjTarifaSubCuenta.fnSP_BUSCAR_TARIFARIOS())
            dtControl_FAC = ObjTarifaSubCuenta.fnSP_BUSCAR_TARIFARIOS
            dvControl_FAC = dtControl_FAC.DefaultView
            'bformatImage = True
            DataGridViewTarifa.DataSource = dvControl_FAC
            DataGridViewTarifa.Refresh()
            lbNroRegistro.Text = dvControl_FAC.Count
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub cmbDestino_SubCta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDestino_SubCta.SelectedIndexChanged
        Try
            ObjTarifaSubCuenta.v_IDUNIDAD_AGENCIA = Int(col_Origen_Cta.Item(cmbOrigen_SubCta.SelectedIndex.ToString()))
            ObjTarifaSubCuenta.v_IDUNIDAD_AGENCIA_DESTINO = Int(col_Destino_Cta.Item(cmbDestino_SubCta.SelectedIndex.ToString()))
            If ObjTarifaSubCuenta.fnSP_LISTA_TARIFA_PUBLICA() = True Then
                txtPrecioPostalBase.Text = ObjTarifaSubCuenta.Cg_Monto_Base
                txtPrecio_Sobre_public.Text = ObjTarifaSubCuenta.Cg_Monto_Base
                txtPrecioPostalPeso.Text = ObjTarifaSubCuenta.Cg_x_Peso
                txtPrecioPostalVolumen.Text = ObjTarifaSubCuenta.Cg_x_Volumen
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
