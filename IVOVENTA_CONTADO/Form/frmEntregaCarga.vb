Imports System
'Imports System.Drawing
Imports System.Net
Imports System.Net.Sockets
Imports System.Reflection
Public Class frmEntregaCarga
    'Dim daControl_FAC As New OleDb.OleDbDataAdapter
    Dim dtControl_FAC As New System.Data.DataTable
    Dim dvControl_FAC As System.Data.DataView
    Dim bformatImage As Boolean = False
    'Dim ObjIngre_Carga_Alma As New ClsLbTepsa.dtoIngre_Carga_Alma
    Dim ObjfrmBuscarCliente As New frmBuscarCliente
    Dim dv_SELEC_VENTA_UBICA As DataView
    Dim b_valida_entrega As Boolean
    ''
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Dim intHuella As Integer

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub frmEntregaCarga_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frmEntregaCarga_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        intHuella = dtoUSUARIOS.huella

        ToolStripMenuItem1.Visible = False
        ToolStripMenuItem2.Text = "ENTREGA DE CARGA"
        ToolStripMenuItem2.Enabled = False
        ToolStripMenuItem3.Enabled = False
        ToolStripMenuItem4.Enabled = False
        ToolStripMenuItem5.Enabled = False
        ToolStripMenuItem6.Enabled = False
        Try
            'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper
            If objGuiaEnvio.fnLISTA_AGENCIAS_UNIDADES() = True Then
                ModuUtil.LlenarComboIDs2(objGuiaEnvio.dt_Lista_Unidades_Agencia, cmbOrigen, objGuiaEnvio.coll_Lista_Origen, 9999, cmbDestino, objGuiaEnvio.coll_Lista_Destino, 9999)
            End If
            Me.dtFechaFin.Text = dtoUSUARIOS.m_sFecha
            Me.dtFechaInicio.Text = dtoUSUARIOS.m_sFecha
            'Mod.10/09/2009 -->Omendoza - Pasando al datahelper   
            ModuUtil.LlenarComboIDs_dt(ObjEntregaCarga.fnEstadoRegistros(), cmbEstados, ObjEntregaCarga.col_Estados, 999)
            '
            Dim lobj_adoserver As New AdoServer
            'rst = New ADODB.Recordset
            'rst = VOCONTROLUSUARIO.ListarAgencias(-1)
            '
            lobj_adoserver.ListarAgencias()
            '
            'ModuUtil.LlenarComboIDs(rst, cmbAgencia, objGuiaEnvio.coll_Lista_Agencias, dtoUSUARIOS.m_iIdAgencia)
            ModuUtil.LlenarComboIDs_dt(lobj_adoserver.dt_Listar_agencias, cmbAgencia, objGuiaEnvio.coll_Lista_Agencias, dtoUSUARIOS.m_iIdAgencia)
            '
            'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper   
            If objGuiaEnvio.fnFILTRO_USUARIO_X_AGENCIA(dtoUSUARIOS.m_iIdAgencia) = True Then
                '01/09/2009 - Mod. x Datahelper x datatable 
                'ModuUtil.LlenarComboIDs(objGuiaEnvio.rst_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, dtoUSUARIOS.IdLogin)
                ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, dtoUSUARIOS.IdLogin)
            Else
                NingunoComboIDs(cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios)
            End If
            '
            Dim objvalida_entrega As New dtoCONTROLUSUARIOS
            objvalida_entrega.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            If objvalida_entrega.GetUsuarioEntregaCargaSinValidar() Then
                If objvalida_entrega.iind_autoriza_entrega = 1 Then
                    b_valida_entrega = False
                Else
                    b_valida_entrega = True
                End If
            Else
                b_valida_entrega = True
            End If
            '
            Me.txt_total.Text = "0"
            Me.txt_total_peso.Text = "0"
            Me.txt_total_volumen.Text = "0"
            fnLoadGrid()

            Me.cboTipoEntrega.SelectedIndex = 0

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox("Consulte con Sistemas...", MsgBoxStyle.Information, "Seguridad Sistemas")
        End Try
    End Sub
    Private Sub btnVerData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerData.Click
        Try
            '13/02/2008
            If dtGridViewControl_FACBOL.Rows().Count < 1 Then
                'If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            'Modificado 13/02/2008
            'If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
            '    MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
            '    Return
            'End If
            '
            ' 
            ObjEntregaCarga.IDPK = dtGridViewControl_FACBOL.Rows(row).Cells("PK").Value '12/10/2007     dtGridViewControl_FACBOL.Rows(row).Cells(1).Value
            ObjEntregaCarga.IDDOC = dtGridViewControl_FACBOL.Rows(row).Cells("IDDOC").Value '12/10/2007 dtGridViewControl_FACBOL.Rows(row).Cells(2).Value
            ObjEntregaCarga.IDDOC = dtGridViewControl_FACBOL.Rows(row).Cells("IDDOC").Value '12/10/2007 dtGridViewControl_FACBOL.Rows(row).Cells(2).Value
            ObjEntregaCarga.l_idagencia_destino = dtGridViewControl_FACBOL.Rows(row).Cells("Idagencias_Destino").Value '21/01/2008 
            '
            Dim frmObj As New frmControlEntregasCargo
            frmObj.Modo = 1
            frmObj.TipoComprobante = dtGridViewControl_FACBOL.CurrentRow.Cells("IDTIPO_COMPROBANTE").Value
            frmObj.Comprobante = dtGridViewControl_FACBOL.CurrentRow.Cells("IDDOC").Value
            'frmObj.ShowDialog()
            Acceso.Asignar(frmObj, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frmObj.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            frmObj = Nothing
        Catch ex As Exception
            MsgBox("revisar datos....", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        'Try
        '    fnVerDatos(1) ' Ver Datos...
        'Catch ex As Exception
        '    MsgBox("revisar datos....", MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
    End Sub
    Private Sub fnVerDatos(ByVal index As Integer)
        Dim ll_idusuario_tmp As Long
        '13/02/2008
        If dtGridViewControl_FACBOL.Rows().Count < 1 Then
            'If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
            MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
            Return
        End If
        '
        Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
        '13/02/2008 
        'If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
        '    MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
        '    Return
        'End If
        '
        ObjEntregaCarga.IDPK = dtGridViewControl_FACBOL.Rows(row).Cells("PK").Value '12/10/2007   dtGridViewControl_FACBOL.Rows(row).Cells("PK").Value  
        ObjEntregaCarga.IDDOC = dtGridViewControl_FACBOL.Rows(row).Cells("IDDOC").Value '12/10/2007 dtGridViewControl_FACBOL.Rows(row).Cells("IDDOC").Value
        ' 
        ' Modificado 12/10/2007 
        '
        'ObjEntregaCarga.IDPK = dtGridViewControl_FACBOL.Rows(row).Cells(1).Value
        'ObjEntregaCarga.IDDOC = dtGridViewControl_FACBOL.Rows(row).Cells(2).Value
        '
        ' Agregado 12/07/2007 - Jbenavides 
        '
        If index <> 10 Then
            If ObjEntregaCarga.IDPK = 1 Then
                If fnSP_CONTROL_PCE(ObjEntregaCarga.IDPK, ObjEntregaCarga.IDDOC) = 0 Then
                    Return
                End If
            End If
        End If
        'idEstado_Documento
        If index = 2 Then
            '12/10/2007
            'If dtGridViewControl_FACBOL.Rows(row).DataGridView(25, row).Value = 21 Then
            If dtGridViewControl_FACBOL.Rows(row).Cells("idEstado_Documento").Value = 21 Then
                MsgBox("La carga está entregada...!", MsgBoxStyle.Information, "Seguridad Sistema")
                Exit Sub
            End If
            '29/10/2008 - 
            If dtGridViewControl_FACBOL.Rows(row).Cells("idEstado_Documento").Value = 47 Or dtGridViewControl_FACBOL.Rows(row).Cells("idEstado_Documento").Value = 69 Then
                MsgBox("La carga está en reparto...!", MsgBoxStyle.Information, "Seguridad Sistema")
                Exit Sub
            End If
            '12/10/2007 
            'If dtGridViewControl_FACBOL.Rows(row).DataGridView(25, row).Value <> 20 Then
            If (dtGridViewControl_FACBOL.Rows(row).Cells("idEstado_Documento").Value <> 20 And _
               dtGridViewControl_FACBOL.Rows(row).Cells("idEstado_Documento").Value <> 68) Then ' 18/01/2008 agregado el 68 entrega parcial
                MsgBox("No puede Realizar está Operación. La carga aun no ha llegado...!", MsgBoxStyle.Information, "Seguridad Sistema")
                index = 1
                Exit Sub
            End If
        End If
        '
        'Ingrese el usuario y pasaword del que va a ingresar 
        '
        ll_idusuario_tmp = dtoUSUARIOS.IdLogin
        If b_valida_entrega Then

            Dim lfrmusuario_entrega As New frmusuario_entrega
            '
            lfrmusuario_entrega.Lab_tip_dcto.Text = dtGridViewControl_FACBOL.Rows(row).Cells("Tipo").Value '24/10/2008
            lfrmusuario_entrega.txt_dcto.Text = dtGridViewControl_FACBOL.Rows(row).Cells("NRODOC").Value '24/10/2008
            lfrmusuario_entrega.txt_origen.Text = dtGridViewControl_FACBOL.Rows(row).Cells("Origen").Value
            lfrmusuario_entrega.txt_destino.Text = dtGridViewControl_FACBOL.Rows(row).Cells("Destino").Value
            '
            lfrmusuario_entrega.txtLogin.Text = dtoUSUARIOS.iLOGIN
            lfrmusuario_entrega.txtPasswor.Focus()
            '
            'lfrmusuario_entrega.ShowDialog()
            Acceso.Asignar(lfrmusuario_entrega, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                lfrmusuario_entrega.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If lfrmusuario_entrega.pb_cancelar = True Then
                Exit Sub ' No hace nada 
            End If
            '
            dtoUSUARIOS.IdLogin = lfrmusuario_entrega.pl_idusuario_personal
        End If
        '
        ObjEntregaCarga.l_idagencia_destino = dtGridViewControl_FACBOL.Rows(row).Cells("Idagencias_Destino").Value '21/01/2008 
        '
        Dim frmObj As New frmControlEntregasCargo
        frmObj.iVerEntrega = index
        frmObj.Modo = 2
        frmObj.TipoComprobante = Me.dtGridViewControl_FACBOL.CurrentRow.Cells("IDTIPO_COMPROBANTE").Value
        frmObj.Comprobante = Me.dtGridViewControl_FACBOL.CurrentRow.Cells("IDDOC").Value

        If intHuella = 1 Then
            If Me.dtGridViewControl_FACBOL.CurrentRow.Cells("tiene_oficina").Value = 1 Then
                If Me.dtGridViewControl_FACBOL.CurrentRow.Cells("producto").Value = 6 Then
                    dtoUSUARIOS.huella = 0
                Else
                    dtoUSUARIOS.huella = 1
                End If
            Else
                dtoUSUARIOS.huella = 0
            End If
        End If

        Acceso.Asignar(frmObj, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            If frmObj.ShowDialog() = Windows.Forms.DialogResult.OK Then
                '12/10/2007
                dtGridViewControl_FACBOL.Rows(row).Cells("idEstado_Documento").Value = frmObj.V_IDESTADO_REGISTRO
                'dtGridViewControl_FACBOL.Rows(row).DataGridView(25, row).Value = frmObj.V_IDESTADO_REGISTRO
                dtGridViewControl_FACBOL.UpdateCellValue(0, row)
            End If
        Else
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If


        'If frmObj.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '    '12/10/2007
        '    dtGridViewControl_FACBOL.Rows(row).Cells("idEstado_Documento").Value = frmObj.V_IDESTADO_REGISTRO
        '    'dtGridViewControl_FACBOL.Rows(row).DataGridView(25, row).Value = frmObj.V_IDESTADO_REGISTRO
        '    dtGridViewControl_FACBOL.UpdateCellValue(0, row)
        'End If
        '
        frmObj = Nothing
        dtoUSUARIOS.IdLogin = ll_idusuario_tmp
        '
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar2.Click
        Try
            ObjEntregaCarga.c_iControl = 1
            fnBuscar()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub fnBuscar()
        Try
            ObjEntregaCarga.c_idpersona = IIf(ObjBusquedaClientes.idPersona.ToString <> "", ObjBusquedaClientes.idPersona, 0)
            'ObjEntregaCarga.c_idusuariopersonal = Int(objGuiaEnvio.coll_Lista_Usuarios(cmbUsuarios.SelectedIndex.ToString))
            Dim strNroDoc As String() = Split(txtNroSerieDoc.Text, "-")
            If strNroDoc.Length > 1 Then
                If Val(strNroDoc(0)) > 0 And Val(strNroDoc(1)) > 0 Then
                    ObjEntregaCarga.c_Serie = strNroDoc(0)
                    ObjEntregaCarga.c_NroDoc = strNroDoc(1)
                Else
                    ObjEntregaCarga.c_Serie = "0"
                    ObjEntregaCarga.c_NroDoc = "0"
                End If
            Else
                If strNroDoc.Length = 1 Then
                    ObjEntregaCarga.c_Serie = "-1"
                    ObjEntregaCarga.c_NroDoc = strNroDoc(0)
                Else
                    ObjEntregaCarga.c_Serie = "0"
                    ObjEntregaCarga.c_NroDoc = "0"
                End If
            End If

            If ObjEntregaCarga.c_iControl = 5 Then
                ObjEntregaCarga.c_Serie = ObjBusquedaClientes.IDTIPO
                ObjEntregaCarga.c_NroDoc = ObjBusquedaClientes.IDDOC
            End If

            If CheckCliente.Checked = True Then
                ObjEntregaCarga.c_iControl = 10
            End If
            'ObjEntregaCarga.IDDOC = ObjBusquedaClientes.IDDOC
            'ObjEntregaCarga.IDPK = ObjBusquedaClientes.IDTIPO

            ObjEntregaCarga.c_fecha_inicio = dtFechaInicio.Text
            ObjEntregaCarga.c_fecha_fin = dtFechaFin.Text
            ObjEntregaCarga.c_idOrigen = Int(objGuiaEnvio.coll_Lista_Origen(cmbOrigen.SelectedIndex.ToString))
            ObjEntregaCarga.c_idDestino = Int(objGuiaEnvio.coll_Lista_Destino(cmbDestino.SelectedIndex.ToString))
            ObjEntregaCarga.c_idestado_registro = Int(ObjEntregaCarga.col_Estados.Item(cmbEstados.SelectedIndex.ToString))
            ObjEntregaCarga.c_rucdni = IIf(txtClienteDNIRUC.Text <> "", txtClienteDNIRUC.Text, "0")
            ObjEntregaCarga.c_tipo_entrega = Me.cboTipoEntrega.SelectedIndex

            dtControl_FAC.Clear()
            dtGridViewControl_FACBOL.Refresh()
            'Mod.14/09/2009 -->Omendoza - Pasando al datahelper   
            Dim ldt_tmp As New DataTable
            ldt_tmp = ObjEntregaCarga.fnCONSULTA_CARGA()

            'daControl_FAC.Fill(dtControl_FAC, ObjEntregaCarga.fnCONSULTA_CARGA())
            'dvControl_FAC = dtControl_FAC.DefaultView
            dvControl_FAC = ldt_tmp.DefaultView
            '
            bformatImage = True
            dtGridViewControl_FACBOL.DataSource = dvControl_FAC
            dtGridViewControl_FACBOL.Refresh()
            lbNroRegistro1.Text = dvControl_FAC.Count
            totales()

            If dvControl_FAC.Count = 0 Then
                MsgBox("No se han encontrado ningún resultado para está búsqueda..., en toda la Base de datos", MsgBoxStyle.Information, "Seguridad Sistema")
            Else
                bformatImage = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Public Function fnLoadGrid() As Boolean
        Try
            With dtGridViewControl_FACBOL
                .AllowUserToAddRows = False
                .AutoGenerateColumns = False
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
            dtGridViewControl_FACBOL.Columns.Add(idEstadoImage)

            Dim PK As New DataGridViewTextBoxColumn
            With PK
                .DisplayIndex = 1
                .DataPropertyName = "PK"
                .Name = "PK" ' "IDDOC"   ' Ingresado por omendoza                
                .HeaderText = "PK"

                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(PK)

            Dim IDDOC As New DataGridViewTextBoxColumn
            With IDDOC
                .DisplayIndex = 2
                .DataPropertyName = "IDDOC"
                .Name = "IDDOC" 'IDTIPO_COMPROBANTE" ' Ingresado por Omendoza
                .HeaderText = "IDDOC"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(IDDOC)


            Dim NRODOC As New DataGridViewTextBoxColumn
            With NRODOC
                .DisplayIndex = 3
                .DataPropertyName = "NRODOC"
                .Name = "NRODOC"
                .HeaderText = "Nº DOC"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(NRODOC)

            Dim TIPO As New DataGridViewTextBoxColumn
            With TIPO
                .DisplayIndex = 4
                .DataPropertyName = "Tipo"
                .Name = "Tipo"
                .HeaderText = "TIPO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(TIPO)

            Dim FECHA As New DataGridViewTextBoxColumn
            With FECHA
                .DisplayIndex = 5
                .DataPropertyName = "FECHA"
                .HeaderText = "FECHA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(FECHA)


            Dim ENTREGA As New DataGridViewTextBoxColumn
            With ENTREGA
                .DisplayIndex = 6
                .DataPropertyName = "ENTREGA"
                .Name = "ENTREGA"
                .HeaderText = "ENTREGA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(ENTREGA)

            Dim Nu_Docu_Suna As New DataGridViewTextBoxColumn
            With Nu_Docu_Suna
                .DisplayIndex = 7
                .DataPropertyName = "Nu_Docu_Suna"
                .HeaderText = "RUC/DNI"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Nu_Docu_Suna)

            Dim Razon_Social As New DataGridViewTextBoxColumn
            With Razon_Social
                .DisplayIndex = 8
                .DataPropertyName = "Razon_Social"
                .HeaderText = "RAZON SOCIAL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Razon_Social)
            '
            Dim Consignado As New DataGridViewTextBoxColumn
            With Consignado
                .DisplayIndex = 9
                .DataPropertyName = "Consignado"
                .Name = "Consignado"
                .HeaderText = "CONSIGNADO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Consignado)
            '
            Dim direccionConsignado As New DataGridViewTextBoxColumn
            With direccionConsignado
                .DisplayIndex = 10
                .DataPropertyName = "direccionconsigando"
                .Name = "direccionconsigando"
                .HeaderText = "DIR. CONSIGNADO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(direccionConsignado)
            '
            Dim forma_pago As New DataGridViewTextBoxColumn
            With forma_pago
                .DisplayIndex = 11
                .DataPropertyName = "forma_pago"
                .HeaderText = "PAGO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(forma_pago)

            Dim Nro_Guia_Transportista As New DataGridViewTextBoxColumn
            With Nro_Guia_Transportista
                .DisplayIndex = 12
                .DataPropertyName = "Nro_Guia_Transportista"
                .HeaderText = "G.TRANSP"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Nro_Guia_Transportista)

            Dim Fecha_Salida As New DataGridViewTextBoxColumn
            With Fecha_Salida
                .DisplayIndex = 13
                .DataPropertyName = "Fecha_Salida"
                .HeaderText = "F.SALIDA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Fecha_Salida)


            Dim Hora_Salida As New DataGridViewTextBoxColumn
            With Hora_Salida
                .DisplayIndex = 14
                .DataPropertyName = "Hora_Salida"
                .HeaderText = "H.SALIDA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Hora_Salida)


            Dim Origen As New DataGridViewTextBoxColumn
            With Origen
                .DisplayIndex = 15
                .DataPropertyName = "Origen"
                .Name = "Origen"
                .HeaderText = "ORIGEN"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Origen)

            Dim Destino As New DataGridViewTextBoxColumn
            With Destino
                .DisplayIndex = 16
                .DataPropertyName = "Destino"
                .HeaderText = "DESTINO"
                .Name = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Destino)
            '

            Dim Agencia_Destino As New DataGridViewTextBoxColumn
            With Agencia_Destino
                .DisplayIndex = 17
                .DataPropertyName = "Agencia_Destino"
                .Name = "Agencia_Destino"
                .HeaderText = "AG. DESTINO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Agencia_Destino)

            '---
            Dim Transito As New DataGridViewTextBoxColumn
            With Transito
                .DisplayIndex = 18
                .DataPropertyName = "Transito"
                .HeaderText = "TRANSITO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Transito)

            Dim Cantidad_x_Peso As New DataGridViewTextBoxColumn
            With Cantidad_x_Peso
                .DisplayIndex = 19
                .DataPropertyName = "Cantidad_x_Peso"
                .HeaderText = "C. PESO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Cantidad_x_Peso)

            Dim Cantidad_x_Volumen As New DataGridViewTextBoxColumn
            With Cantidad_x_Volumen
                .DisplayIndex = 20
                .DataPropertyName = "Cantidad_x_Volumen"
                .HeaderText = "C. VOL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Cantidad_x_Volumen)
            '
            Dim Cantidad_x_Sobre As New DataGridViewTextBoxColumn
            With Cantidad_x_Sobre
                .DisplayIndex = 21
                .DataPropertyName = "Cantidad_x_Sobre"
                .HeaderText = "C. SOBRE"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Cantidad_x_Sobre)

            Dim Total_Peso As New DataGridViewTextBoxColumn
            With Total_Peso
                .DisplayIndex = 22
                .DataPropertyName = "Total_Peso"
                .Name = "Total_Peso"
                .HeaderText = "T. PESO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Total_Peso)

            Dim Total_Volumen As New DataGridViewTextBoxColumn
            With Total_Volumen
                .DisplayIndex = 23
                .DataPropertyName = "Total_Volumen"
                .Name = "Total_Volumen"
                .HeaderText = "T. VOL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Total_Volumen)
            '
            '
            Dim subtotal As New DataGridViewTextBoxColumn
            With subtotal
                .DisplayIndex = 24
                .DataPropertyName = "subtotal"
                .Name = "subtotal"
                .HeaderText = "SUBTOTAL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(subtotal)
            '
            Dim total_impuesto As New DataGridViewTextBoxColumn
            With total_impuesto
                .DisplayIndex = 25
                .DataPropertyName = "total_impuesto"
                .Name = "total_impuesto"
                .HeaderText = "IMPUESTO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(total_impuesto)
            '
            Dim total_costo As New DataGridViewTextBoxColumn
            With total_costo
                .DisplayIndex = 26
                .DataPropertyName = "total_costo"
                .Name = "total_costo"
                .HeaderText = "TOTAL COSTO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(total_costo)
            '
            Dim Fecha_Entrega As New DataGridViewTextBoxColumn
            With Fecha_Entrega
                .DisplayIndex = 27
                .DataPropertyName = "Fecha_Entrega"
                .HeaderText = "F.ENTREGA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Fecha_Entrega)

            Dim Hora_Entrega As New DataGridViewTextBoxColumn
            With Hora_Entrega
                .DisplayIndex = 28
                .DataPropertyName = "Hora_Entrega"
                .HeaderText = "H.ENTREGA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Hora_Entrega)


            Dim idEstadoGuiaTrans As New DataGridViewTextBoxColumn
            With idEstadoGuiaTrans
                .DisplayIndex = 29
                .DataPropertyName = "idEstadoGuiaTrans"
                .HeaderText = "idEstadoGuiaTrans"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(idEstadoGuiaTrans)

            Dim Estado_Documento As New DataGridViewTextBoxColumn
            With Estado_Documento
                .DisplayIndex = 30
                .DataPropertyName = "Estado_Documento"
                .Name = "Estado_Documento"
                .HeaderText = "ESTADO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Estado_Documento)

            Dim idEstado_Documento As New DataGridViewTextBoxColumn
            With idEstado_Documento
                .DisplayIndex = 31
                .Name = "idEstado_Documento"
                .DataPropertyName = "idEstado_Documento"
                .HeaderText = "ESTADO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(idEstado_Documento)

            Dim Login As New DataGridViewTextBoxColumn
            With Login
                .DisplayIndex = 32
                .DataPropertyName = "Login"
                .HeaderText = "DESPACHADO POR"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Login)
            '
            Dim sidpersona As New DataGridViewTextBoxColumn
            With sidpersona
                .DisplayIndex = 33
                .DataPropertyName = "idpersona"
                .Name = "idpersona"
                .HeaderText = "Id Persona"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = False
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(sidpersona)
            '
            Dim sIdtipo_Entrega_Carga As New DataGridViewTextBoxColumn
            With sIdtipo_Entrega_Carga
                .DisplayIndex = 34
                .DataPropertyName = "Idtipo_Entrega_Carga"
                .Name = "Idtipo_Entrega_Carga"
                .HeaderText = "Id. Tipo Entrega"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = False
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(sIdtipo_Entrega_Carga)
            '
            Dim sIDTIPO_COMPROBANTE As New DataGridViewTextBoxColumn
            With sIDTIPO_COMPROBANTE
                .DisplayIndex = 35
                .DataPropertyName = "IDTIPO_COMPROBANTE"
                .Name = "IDTIPO_COMPROBANTE"
                .HeaderText = "IDTIPO_COMPROBANTE"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = False
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(sIDTIPO_COMPROBANTE)
            '
            Dim sNro_Guia As New DataGridViewTextBoxColumn
            With sNro_Guia
                .DisplayIndex = 36
                .DataPropertyName = "Nro_Guia"
                .Name = "Nro_Guia"
                .HeaderText = "Nº GUIA ASOCIADO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = False
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(sNro_Guia)
            '
            Dim funcionario As New DataGridViewTextBoxColumn
            With funcionario
                .DisplayIndex = 37
                .DataPropertyName = "funcionario"
                .Name = "funcionario"
                .HeaderText = "FUNCIONARIO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = False
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(funcionario)
            '
            Dim Idagencias_Destino As New DataGridViewTextBoxColumn
            With Idagencias_Destino
                .DisplayIndex = 38
                .DataPropertyName = "Idagencias_Destino"
                .Name = "Idagencias_Destino"
                .HeaderText = "Agencia Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = False
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(Idagencias_Destino)

            Dim IDDestino As New DataGridViewTextBoxColumn
            With IDDestino
                .DisplayIndex = 39
                .DataPropertyName = "IDDestino"
                .HeaderText = "IDDestino"
                .Name = "IDDestino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(IDDestino)

            Dim sFacturado As New DataGridViewTextBoxColumn
            With sFacturado
                .DisplayIndex = 40
                .DataPropertyName = "Facturado"
                .HeaderText = "FACTURADO"
                .Name = "Facturado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(sFacturado)

            Dim sDocumento As New DataGridViewTextBoxColumn
            With sDocumento
                .DisplayIndex = 41
                .DataPropertyName = "Nro_Factura"
                .HeaderText = "FACTURA/BOLETA"
                .Name = "Factura / Boleta"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(sDocumento)
            '
            Dim sfecha_reparto As New DataGridViewTextBoxColumn
            With sfecha_reparto
                .DisplayIndex = 42
                .DataPropertyName = "fecha_reparto"
                .HeaderText = "FECHA REPARTO"
                .Name = "fecha_reparto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(sfecha_reparto)

            Dim sDocumentos As New DataGridViewTextBoxColumn
            With sDocumentos
                .DisplayIndex = 43
                .DataPropertyName = "documentos"
                .HeaderText = "CARGO"
                .Name = "documentos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(sDocumentos)

            Dim col_producto As New DataGridViewTextBoxColumn
            With col_producto
                .DisplayIndex = 44
                .DataPropertyName = "producto"
                .HeaderText = "producto"
                .Name = "producto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(col_producto)

            Dim col_tiene_oficina As New DataGridViewTextBoxColumn
            With col_tiene_oficina
                .DisplayIndex = 45
                .DataPropertyName = "tiene_oficina"
                .HeaderText = "tiene_oficina"
                .Name = "tiene_oficina"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(col_tiene_oficina)

            Dim col_telefono As New DataGridViewTextBoxColumn
            With col_telefono
                .DisplayIndex = 46
                .DataPropertyName = "telefono"
                .HeaderText = "TELEFONO"
                .Name = "telefono"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(col_telefono)

        Catch ex As Exception

        End Try

        Return False
    End Function
    Private Sub VerDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '1302/2008
            ' If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
            If dtGridViewControl_FACBOL.Rows().Count < 1 Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            '13/02/2008 -> 
            'If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
            '    MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
            '    Return
            'End If
            '
            ObjEntregaCarga.IDPK = dtGridViewControl_FACBOL.Rows(row).Cells("PK").Value '12/10/2007   dtGridViewControl_FACBOL.Rows(row).Cells(1).Value  
            ObjEntregaCarga.IDDOC = dtGridViewControl_FACBOL.Rows(row).Cells("IDDOC").Value '12/10/2007 dtGridViewControl_FACBOL.Rows(row).Cells(2).Value           
            '
            Dim frmObj As New frmControlEntregasCargo
            'frmObj.ShowDialog()

            Acceso.Asignar(frmObj, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                frmObj.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            frmObj = Nothing
        Catch ex As Exception
            MsgBox("revizar datos....", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub EntregaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntregaToolStripMenuItem.Click
        Try
            'If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
            '13/02/2008 
            If dtGridViewControl_FACBOL.Rows().Count < 1 Then
                Return
            End If
            'If fnValidar_Rol("21") = True Or fnValidar_Rol("23") = True Or fnValidar_Rol("9") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 1) Then
                fnVerDatos(2) ' Ver Datos...
            Else
                MsgBox("Usted No tiene permiso para realizar esta Operación")
            End If
        Catch ex As Exception
            MsgBox("Revice sus Datos.., Operacion Cancelada", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btnEntregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEntregar.Click
        Try
            '13/02/2008
            If dtGridViewControl_FACBOL.Rows().Count < 1 Then
                'If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                Return
            End If
            If dtGridViewControl_FACBOL.Rows(dtGridViewControl_FACBOL.CurrentRow.Index).Cells("Facturado").Value = "NO" Then
                MessageBox.Show("Debe de Canjear el Pago Contra Entrega por una Factura o Boleta, Antes de Confirmar la Entrega de la Carga", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Return
            End If
            'If fnValidar_Rol("21") = True Or fnValidar_Rol("23") = True Or fnValidar_Rol("9") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 2) Then
                fnVerDatos(2) ' Ver Datos...
            Else
                MsgBox("Usted No Tiene Permisos para realizar esta Operacion")
            End If
        Catch ex As Exception
            MsgBox("Revise sus Datos.., Operación Cancelada", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Sub FORMAT_GRILLA1()
        dgv1.Columns.Clear()

        With dgv1
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .BackgroundColor = SystemColors.Window
            .DataSource = dv_SELEC_VENTA_UBICA
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersWidth = 10
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")

        End With

        Dim CODI_UBI As New DataGridViewTextBoxColumn
        With CODI_UBI
            .HeaderText = "Ubicación"
            .Name = "CODI_UBI"
            .DataPropertyName = "CODI_UBI"
            '.Width = 80
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim CODI_BARRA As New DataGridViewTextBoxColumn
        With CODI_BARRA
            .HeaderText = "Cód. Barra"
            .Name = "CODIGO_BARRA"
            .DataPropertyName = "CODIGO_BARRA"
            '.Width = 100
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ALMA As New DataGridViewTextBoxColumn
        With ALMA
            .HeaderText = "Almacén"
            .Name = "ALMA"
            .DataPropertyName = "ALMA"
            '.Width = 100
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim AREA As New DataGridViewTextBoxColumn
        With AREA
            .HeaderText = "Area"
            .Name = "AREA"
            .DataPropertyName = "AREA"
            '.Width = 100
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ANA As New DataGridViewTextBoxColumn
        With ANA
            .HeaderText = "Anaquel"
            .Name = "ANA"
            .DataPropertyName = "ANA"
            '.Width = 100
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim COLUM As New DataGridViewTextBoxColumn
        With COLUM
            .HeaderText = "Columna"
            .Name = "COLUM"
            .DataPropertyName = "COLUM"
            '.Width = 50
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
        End With
        Dim FILA As New DataGridViewTextBoxColumn
        With FILA
            .HeaderText = "Fila"
            .Name = "FILA"
            .DataPropertyName = "FILA"
            '.Width = 50
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
        End With
        With dgv1
            .Columns.AddRange(CODI_UBI, CODI_BARRA, ALMA, AREA, ANA, COLUM, FILA)
        End With
    End Sub
    Private Sub dtGridViewControl_FACBOL_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtGridViewControl_FACBOL.CellEnter
        'If e.RowIndex = dtGridViewControl_FACBOL.RowCount - 1 Then
        '    dgv1.DataSource = Nothing
        '    Exit Sub
        'End If

        'If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
        '    MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
        '    Return
        'End If
        'Dim row As Integer = 0
        'Try
        '    row = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
        '    If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
        '        MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
        '        Return
        '    End If
        'Catch ex As Exception

        'End Try
        'ObjEntregaCarga.IDPK = dtGridViewControl_FACBOL.Rows(row).Cells(1).Value
        'ObjEntregaCarga.IDDOC = dtGridViewControl_FACBOL.Rows(row).Cells(2).Value

        'dv_SELEC_VENTA_UBICA = New DataView
        'dv_SELEC_VENTA_UBICA = ObjEntregaCarga.SP_SELEC_VENTA_UBICA(ObjEntregaCarga.IDPK, ObjEntregaCarga.IDDOC.ToString())
        'FORMAT_GRILLA1()

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean = True
        Dim flat As Boolean = True
        Try
            Dim var As Integer = msg.WParam.ToInt32

            If msg.WParam.ToInt32 = Keys.Enter Then
                If txtNroSerieDoc.Focused = True Then
                    'ObjEntregaCarga.c_iControl = 2
                    'fnBuscar()
                    If Me.txtNroSerieDoc.Text.Trim.Length > 0 Then
                        btnBuscar_Click_1(Nothing, Nothing)
                    End If
                ElseIf txtClienteDNIRUC.Focused = True Then
                    'ObjEntregaCarga.c_iControl = 1
                    'fnBuscar()
                    If Me.txtClienteDNIRUC.Text.Trim.Length > 0 Then
                        btnBuscar_Click_1(Nothing, Nothing)
                    End If
                ElseIf Me.txtBuscar.Focused Then
                    If Me.txtBuscar.Text.Trim.Length > 0 Then
                        btnBuscar_Click_1(Nothing, Nothing)
                    End If
                Else
                    flat = MyBase.ProcessCmdKey(msg, KeyData)
                End If
            ElseIf msg.WParam.ToInt32 = Keys.F1 Then
                'cambio tecla funcion
                If Me.btnBuscarCliente.Enabled Then
                    'fnBuscarConsignado()
                    btnBuscar_Click_1(Nothing, Nothing)
                End If
            Else
                flat = MyBase.ProcessCmdKey(msg, KeyData)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flat
    End Function

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        fnBuscarConsignado()
    End Sub
    Public Function fnBuscarConsignado() As Boolean
        Try
            ObjBusquedaClientes.v_fecha_inicio = dtFechaInicio.Text
            ObjBusquedaClientes.v_fecha_final = dtFechaFin.Text

            ObjBusquedaClientes.idPersona = 0

            Acceso.Asignar(ObjfrmBuscarCliente, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                '13-10-2011
                ObjfrmBuscarCliente.Control = 10
                If ObjfrmBuscarCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ObjEntregaCarga.c_iControl = 5
                    ObjEntregaCarga.c_idpersona = ObjBusquedaClientes.idPersona
                    ObjEntregaCarga.IDDOC = ObjBusquedaClientes.IDDOC
                    ObjEntregaCarga.IDPK = ObjBusquedaClientes.IDTIPO
                    fnBuscar()
                    ObjBusquedaClientes.idPersona = 0
                    objControlFacturasBol.iControl = 0
                End If
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


            'If ObjfrmBuscarCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '    'objControlFacturasBol.iControl = 5
            '    'fnBuscarFacturas()
            '    'ObjEntregaCarga.c_iControl = 5
            '    ObjEntregaCarga.c_iControl = 5
            '    'ObjBusquedaClientes.idPersona()
            '    ObjEntregaCarga.c_idpersona = ObjBusquedaClientes.idPersona
            '    ObjEntregaCarga.IDDOC = ObjBusquedaClientes.IDDOC
            '    ObjEntregaCarga.IDPK = ObjBusquedaClientes.IDTIPO
            '    fnBuscar()
            '    ObjBusquedaClientes.idPersona = 0
            '    objControlFacturasBol.iControl = 0
            'End If
        Catch ex As Exception
            ObjBusquedaClientes.idPersona = 0
        End Try
    End Function
    Private Sub ControlLlegadaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlLlegadaToolStripMenuItem.Click
        Try
            '13/02/2008 
            If dtGridViewControl_FACBOL.Rows().Count = 0 Then
                'If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                MsgBox("Debe elegir Un Item válido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            '13/02/2008 
            'If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
            '    MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
            '    Return
            'End If
            '      
            ObjEntregaCarga.IDPK = dtGridViewControl_FACBOL.Rows(row).Cells("PK").Value '12/10/2007   dtGridViewControl_FACBOL.Rows(row).Cells(1).Value  
            ObjEntregaCarga.IDDOC = dtGridViewControl_FACBOL.Rows(row).Cells("IDDOC").Value '12/10/2007 dtGridViewControl_FACBOL.Rows(row).Cells(2).Value     
            '      
            If MsgBox("Está Seguro de Realizar está Operación...", MsgBoxStyle.YesNoCancel, "Seguridad Sistema") = MsgBoxResult.Yes Then
                ' Debe Recepcionar en forma normal 
                ' Modificado 06/06/2008 - Verifica  si el documento tiene carga 
                '
                Try
                    If ObjEntregaCarga.fnCONTROL_LLEGADAS(ObjEntregaCarga.IDPK, ObjEntregaCarga.IDDOC.ToString) = False Then
                        MsgBox("No se ha Podido realizar esta Operacion...", MsgBoxStyle.Information, "Seguridad Sistema")
                    Else
                        If ObjEntregaCarga.l_error = 0 Then
                            If ObjEntregaCarga.l_no_existe_gt = 0 Then
                                Dim ll_control As Long
                                Dim ll_idtipo_comprobante As Long
                                Dim ls_idcomprobante As String
                                Dim ll_idunidad_agencia As Long
                                Dim ls_origen, ls_destino As String
                                Dim ldto_genera_incidencia_despacho As New dtogenera_incidencia_despacho
                                'Dim lrst_datos_basicos, lrst_agencias As New ADODB.Recordset
                                Dim ldt_datos_basicos As New DataTable
                                Dim dgrv0 As DataGridViewRow
                                Dim lobj_genera_incidencia_despacho As New frm_genera_incidencia_despacho
                                '
                                dgrv0 = Me.dtGridViewControl_FACBOL.CurrentRow() '
                                ll_idtipo_comprobante = CType(dgrv0.Cells("IDTIPO_COMPROBANTE").Value, Long)
                                ls_idcomprobante = CType(dgrv0.Cells("IDDOC").Value, String) 'idcomprobante 
                                ll_idunidad_agencia = CType(dgrv0.Cells("Idagencias_Destino").Value, Long)
                                '
                                ls_origen = CType(dgrv0.Cells("Origen").Value, String) '
                                ls_destino = CType(dgrv0.Cells("Destino").Value, String) '
                                '
                                ldto_genera_incidencia_despacho.idtipo_comprobante = ll_idtipo_comprobante
                                ldto_genera_incidencia_despacho.idcomprobante = ls_idcomprobante

                                ldto_genera_incidencia_despacho.idunidad_agencia_destino = ll_idunidad_agencia
                                ldto_genera_incidencia_despacho.idagencia_recep = dtoUSUARIOS.iIDAGENCIAS ' Modif. 07/11/2008 
                                'Mod.14/09/2009 -->Omendoza - Pasando al datahelper   
                                Dim lds_tmp As New DataSet
                                'lrst_datos_basicos = ldto_genera_incidencia_despacho.fn_valida_dcto_asocia_guia_gt
                                'lrst_agencias = lrst_datos_basicos.NextRecordset
                                'daControl_FAC.Fill(ldt_datos_basicos, lrst_datos_basicos)
                                'll_control = CType(ldt_datos_basicos.Rows(0).Item(0), Long)
                                '
                                lds_tmp = ldto_genera_incidencia_despacho.fn_valida_dcto_asocia_guia_gt
                                ldt_datos_basicos = lds_tmp.Tables(0)
                                ll_control = CType(ldt_datos_basicos.Rows(0).Item(0), Long)
                                '
                                'lrst_agencias = lrst_datos_basicos.NextRecordset
                                'daControl_FAC.Fill(ldt_datos_basicos, lrst_datos_basicos)


                                'Dim ll_verifica_recepcion As Long
                                '
                                ' 07/11/2008 - Ya se recepciono en la agencia con el usuario respectivo 
                                ' 
                                If ll_control <> 0 Then 'No encontro ningun registro asociado 
                                    'Mod.14/09/2009 -->Omendoza - Pasando al datahelper   
                                    'daControl_FAC.Fill(lobj_genera_incidencia_despacho.pdt_agencias, lrst_agencias)
                                    lobj_genera_incidencia_despacho.pdt_agencias = lds_tmp.Tables(1) ' Recupera agencias 
                                    '
                                    lobj_genera_incidencia_despacho.pb_dtogenera_incidencia_despacho = ldto_genera_incidencia_despacho
                                    lobj_genera_incidencia_despacho.pdt_datos_generales = ldt_datos_basicos.Copy
                                    lobj_genera_incidencia_despacho.txtorigen.Text = ls_origen
                                    lobj_genera_incidencia_despacho.txt_destino.Text = ls_destino
                                    ' 
                                    'lobj_genera_incidencia_despacho.ShowDialog()

                                    Acceso.Asignar(lobj_genera_incidencia_despacho, Me.hnd)
                                    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                                        lobj_genera_incidencia_despacho.ShowDialog()
                                    Else
                                        MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Return
                                    End If

                                    'Verificar cuando se cancela 
                                End If
                            End If

                            'If ObjEntregaCarga.fnCONTROL_LLEGADAS(ObjEntregaCarga.IDPK, ObjEntregaCarga.IDDOC.ToString) = False Then
                            '    MsgBox("No se ha Podido realizar esta Operacion...", MsgBoxStyle.Information, "Seguridad Sistema")
                            'Else
                            '    ' Modificado 27/03/2008 - Verifica  si el documento tiene carga 
                            '    '
                            '    Try
                            '        Dim ll_control As Long
                            '        Dim ll_idtipo_comprobante As Long
                            '        Dim ls_idcomprobante As String
                            '        Dim ll_idunidad_agencia As Long
                            '        Dim ldto_genera_incidencia_despacho As New dtogenera_incidencia_despacho
                            '        Dim lrst_datos_basicos, lrst_agencias As New ADODB.Recordset
                            '        Dim ldt_datos_basicos As New DataTable
                            '        Dim dgrv0 As DataGridViewRow
                            '        Dim lobj_genera_incidencia_despacho As New frm_genera_incidencia_despacho
                            '        '
                            '        dgrv0 = Me.dtGridViewControl_FACBOL.CurrentRow() '
                            '        ll_idtipo_comprobante = CType(dgrv0.Cells("IDTIPO_COMPROBANTE").Value, Long)
                            '        ls_idcomprobante = CType(dgrv0.Cells("IDDOC").Value, String) 'idcomprobante 
                            '        ll_idunidad_agencia = CType(dgrv0.Cells("Idagencias_Destino").Value, Long)
                            '        ldto_genera_incidencia_despacho.idtipo_comprobante = ll_idtipo_comprobante
                            '        ldto_genera_incidencia_despacho.idcomprobante = ls_idcomprobante
                            '        ldto_genera_incidencia_despacho.idunidad_agencia_destino = ll_idunidad_agencia
                            '        lrst_datos_basicos = ldto_genera_incidencia_despacho.fn_valida_dcto_asocia_guia_gt
                            '        lrst_agencias = lrst_datos_basicos.NextRecordset
                            '        daControl_FAC.Fill(ldt_datos_basicos, lrst_datos_basicos)
                            '        ll_control = CType(ldt_datos_basicos.Rows(0).Item(0), Long)
                            '        If ll_control <> 0 Then 'No encontro ningun registro asociado 
                            '            daControl_FAC.Fill(lobj_genera_incidencia_despacho.pdt_agencias, lrst_agencias)

                            '            lobj_genera_incidencia_despacho.pb_dtogenera_incidencia_despacho = ldto_genera_incidencia_despacho
                            '            lobj_genera_incidencia_despacho.pdt_datos_generales = ldt_datos_basicos.Copy

                            '            lobj_genera_incidencia_despacho.ShowDialog()
                            '            'Verificar cuando se cancela 
                            '        End If
                            '
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Chequeo GT " + ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
                End Try
                '  Fin de lo modificado 27/03/2008 
                ' 
                'Modificado el 20/07/2007 
                '
                dtGridViewControl_FACBOL.Rows(row).DataGridView(25, row).Value = ObjEntregaCarga.l_idestado_envio
                'dtGridViewControl_FACBOL.Rows(row).DataGridView(25, row).Value = 20  ' Llegada...............
                dtGridViewControl_FACBOL.UpdateCellValue(0, row)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dtGridViewControl_FACBOL_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtGridViewControl_FACBOL.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                If dtGridViewControl_FACBOL.Rows.Count <= 0 Then Return
                If dtGridViewControl_FACBOL.CurrentRow.Cells("Idtipo_Entrega_Carga").Value = 1 Then
                    EntregaToolStripMenuItem.Enabled = True
                Else
                    EntregaToolStripMenuItem.Enabled = False
                End If
                ContextMenuStrip.Show(sender, e.X, e.Y)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try

    End Sub

    Private Sub ExportarExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarExcelToolStripMenuItem.Click
        Try
            fnEXCELGrid(dtGridViewControl_FACBOL)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    'Private Sub btnEdicion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdicion.Click
    '    Try
    '        fnVerDatos(10) ' Ver Datos...
    '    Catch ex As Exception
    '        MsgBox("revisar datos....", MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    'End Sub

    Private Sub dtGridViewControl_FACBOL_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtGridViewControl_FACBOL.MouseClick

        'If e.RowIndex = dtGridViewControl_FACBOL.RowCount - 1 Then
        '    dgv1.DataSource = Nothing
        '    Exit Sub
        'End If
        '13/08/2008
        If dtGridViewControl_FACBOL.Rows().Count < 1 Then
            'If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
            '
            dgv1.Columns.Clear()
            MsgBox("No se encontraron registros en la consulta ,...", MsgBoxStyle.Information, "Seguridad Sistema")
            'MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
            Return
        End If
        Dim row As Integer = 0
        Try
            row = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            '13/02/2008 
            'If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
            '    dgv1.Columns.Clear()
            '    MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
            '    Return
            'End If
        Catch ex As Exception

        End Try
        '
        ObjEntregaCarga.IDPK = dtGridViewControl_FACBOL.Rows(row).Cells("PK").Value '12/10/2007   dtGridViewControl_FACBOL.Rows(row).Cells("1").Value  
        ObjEntregaCarga.IDDOC = dtGridViewControl_FACBOL.Rows(row).Cells("IDDOC").Value '12/10/2007 dtGridViewControl_FACBOL.Rows(row).Cells("2").Value
        '
        dv_SELEC_VENTA_UBICA = New DataView
        dv_SELEC_VENTA_UBICA = ObjEntregaCarga.SP_SELEC_VENTA_UBICA(ObjEntregaCarga.IDPK, ObjEntregaCarga.IDDOC.ToString())
        FORMAT_GRILLA1()
    End Sub
    Private Sub ExportarArchivoCSVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarArchivoCSVToolStripMenuItem.Click
        Try
            ObjEntregaCarga.c_fecha_inicio = dtFechaInicio.Text
            ObjEntregaCarga.c_idOrigen = Int(objGuiaEnvio.coll_Lista_Origen(cmbOrigen.SelectedIndex.ToString))
            ObjEntregaCarga.c_idDestino = Int(objGuiaEnvio.coll_Lista_Destino(cmbDestino.SelectedIndex.ToString))
            ObjEntregaCarga.c_idestado_registro = Int(ObjEntregaCarga.col_Estados.Item(cmbEstados.SelectedIndex.ToString))
            ObjEntregaCarga.c_rucdni = IIf(txtClienteDNIRUC.Text <> "", txtClienteDNIRUC.Text, "0")
            If ObjEntregaCarga.c_rucdni = "0" Then
                MsgBox("Debe colocar el RUC del Cliente...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            ObjEntregaCarga.fnCrearArchivo_Entrega()
            MsgBox("Generado Correctamente...", MsgBoxStyle.Information, "Seguridad Sistema")
        Catch ex As Exception

        End Try
    End Sub
    ' Omendoza
    Private Sub CambioTipoEntregaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Recupera el id del documento tipo_comprobante 02/10/2007        
        Dim dgrv0 As DataGridViewRow
        Dim l_tipo_entrega As Long
        Dim s_tipo_comprobante As String
        Dim s_idcomprobante As String
        Dim s_idpersona As String
        Dim i_agenciaDestino As Integer
        Dim objfrmcambio_tipo_entrega As New frmcambio_tipo_entrega
        Try
            If Me.dtGridViewControl_FACBOL.Rows.Count < 1 Then
                Exit Sub
            End If
            'SUPERVISOR ENTREGAS 
            'If fnValidar_Rol("34") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 3) Then
                'Recupera los valores 
                dgrv0 = Me.dtGridViewControl_FACBOL.CurrentRow()
                l_tipo_entrega = CType(dgrv0.Cells("Idtipo_Entrega_Carga").Value, Long)
                s_idpersona = CType(dgrv0.Cells("idpersona").Value, String)
                s_idcomprobante = CType(dgrv0.Cells("IDDOC").Value, String) 'idcomprobante 
                s_tipo_comprobante = CType(dgrv0.Cells("IDTIPO_COMPROBANTE").Value, String)           'idtipo_comprobante 
                i_agenciaDestino = CType(dgrv0.Cells("IDDestino").Value, String)
                '
                objfrmcambio_tipo_entrega.ps_idpersona = s_idpersona
                objfrmcambio_tipo_entrega.pl_tipo_entrega = l_tipo_entrega
                objfrmcambio_tipo_entrega.ps_idtipo_comprobante = s_tipo_comprobante
                objfrmcambio_tipo_entrega.ps_idcomprobante = s_idcomprobante
                objfrmcambio_tipo_entrega.ps_agenciaDestino = i_agenciaDestino
                'objfrmcambio_tipo_entrega.ShowDialog()
                '
                Acceso.Asignar(objfrmcambio_tipo_entrega, Me.hnd)
                If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                    objfrmcambio_tipo_entrega.ShowDialog()
                Else
                    MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                If objfrmcambio_tipo_entrega.pb_cancela = False Then
                    dgrv0.Cells("ENTREGA").Value = objfrmcambio_tipo_entrega.cmbtipo_entrega.Text
                    dgrv0.Cells("Idtipo_Entrega_Carga").Value = objfrmcambio_tipo_entrega.cmbtipo_entrega.SelectedValue
                End If
            Else
                MsgBox("No tiene acceso para modificar la dirección del documento", MsgBoxStyle.Information, "Sistema de entrega de carga")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
        '
    End Sub

    Private Sub dtGridViewControl_FACBOL_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtGridViewControl_FACBOL.CellFormatting
        Dim strvar As String = ""
        Try
            strvar = e.RowIndex.ToString()
            If bformatImage = True Then
                If e.ColumnIndex = 0 Then
                    Dim IdEstado As Integer
                    If e.RowIndex >= 0 And dtGridViewControl_FACBOL.Rows().Count - 1 >= e.RowIndex Then
                        If IsDBNull(dtGridViewControl_FACBOL.Rows(e.RowIndex).Cells("idEstado_Documento").Value) = False Then
                            IdEstado = dtGridViewControl_FACBOL.Rows(e.RowIndex).Cells("idEstado_Documento").Value
                            dtGridViewControl_FACBOL.Rows(e.RowIndex).Cells(1).Tag = 1
                        Else
                            IdEstado = 0
                        End If
                        'IdEstado = IIf(IsNothing(DataGridViewUser.Rows(e.RowIndex).Cells(7).Value), 0, DataGridViewUser.Rows(e.RowIndex).Cells(7).Value)
                        Select Case IdEstado
                            Case 12
                                e.Value = C_RECOJO
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
                            Case 47
                                e.Value = C_REPARTO
                            Case 29
                                e.Value = C_DEVOLUCION
                            Case 50
                                e.Value = C_ABANDONO_LEGAL
                            Case 68
                                e.Value = bmpC_ENTREGADO_PARCIAL
                            Case 69
                                e.Value = bmpC_REPARTO_PARCIAL
                            Case Else
                                e.Value = bmpNoImagen
                        End Select
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema" & strvar)
        End Try
    End Sub
    Sub totales()
        Try
            Dim ll_fila As Long
            Dim ld_peso, ld_volumen As Double

            ' Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            '
            ld_volumen = 0
            ld_peso = 0
            For ll_fila = 0 To dtGridViewControl_FACBOL.RowCount - 1
                ld_volumen = ld_volumen + CType(dtGridViewControl_FACBOL.Rows(ll_fila).Cells("Total_Volumen").Value, Double)
                ld_peso = ld_peso + CType(dtGridViewControl_FACBOL.Rows(ll_fila).Cells("Total_Peso").Value, Double)
            Next
            '
            Me.txt_total.Text = CType(FormatNumber(ld_peso + ld_volumen, 2), String)
            Me.txt_total_peso.Text = CType(FormatNumber(ld_peso, 2), String)
            Me.txt_total_volumen.Text = CType(FormatNumber(ld_volumen, 2), String)
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles btnVerData.EnabledChanged, btnEntregar.EnabledChanged, btnCerrar.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub cmbAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectedIndexChanged
        ''Mod. 26/08/2009 -->Omendoza - Pasando al datahelper   
        'If Me.cmbAgencia.SelectedIndex = -1 Then Return
        'If objGuiaEnvio.fnFILTRO_USUARIO_X_AGENCIA(objGuiaEnvio.coll_Lista_Agencias(Me.cmbAgencia.SelectedIndex + 1)) = True Then
        '    '01/09/2009 - Mod. x Datahelper x datatable 
        '    'ModuUtil.LlenarComboIDs(objGuiaEnvio.rst_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, dtoUSUARIOS.IdLogin)
        '    ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, dtoUSUARIOS.IdLogin)
        'Else
        '    NingunoComboIDs(cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios)
        'End If
    End Sub

    Private Sub VerTrakingToolStripMenuItem_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles VerTrakingToolStripMenuItem.Click
        Try
            If dtGridViewControl_FACBOL.Rows().Count < 1 Then
                'If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
            '13/02/2008
            'If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
            '    MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
            '    Return
            'End If
            ObjEntregaCarga.IDPK = dtGridViewControl_FACBOL.Rows(row).Cells("PK").Value '12/10/2007   dtGridViewControl_FACBOL.Rows(row).Cells("1").Value  
            ObjEntregaCarga.IDDOC = dtGridViewControl_FACBOL.Rows(row).Cells("IDDOC").Value '12/10/2007 dtGridViewControl_FACBOL.Rows(row).Cells("2").Value
            '
            Dim ObjCheckPoint As New FrmCheckPoint
            'ObjCheckPoint.ShowDialog()
            Acceso.Asignar(ObjCheckPoint, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                ObjCheckPoint.ShowDialog()
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ObjCheckPoint = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub btnBuscar_Click_1(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Try
            Cursor = Cursors.AppStarting
            ObjEntregaCarga.c_iControl = 1
            Buscar()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub Buscar()
        Try
            ObjEntregaCarga.c_idpersona = IIf(ObjBusquedaClientes.idPersona.ToString <> "", ObjBusquedaClientes.idPersona, 0)
            ObjEntregaCarga.c_iControl = 1
            Dim strNroDoc As String() = Split(txtNroSerieDoc.Text, "-")
            If strNroDoc.Length > 1 Then
                If strNroDoc(0).Trim.Length > 1 And Val(strNroDoc(1)) > 0 Then
                    ObjEntregaCarga.c_iControl = 2
                    ObjEntregaCarga.c_Serie = strNroDoc(0)
                    ObjEntregaCarga.c_NroDoc = strNroDoc(1)
                Else
                    ObjEntregaCarga.c_Serie = "0"
                    ObjEntregaCarga.c_NroDoc = "0"
                End If
            Else
                If strNroDoc.Length = 1 Then
                    ObjEntregaCarga.c_Serie = "0"
                    ObjEntregaCarga.c_NroDoc = strNroDoc(0)
                    If ObjEntregaCarga.c_NroDoc = "" Then ObjEntregaCarga.c_NroDoc = "0"
                    If Val(ObjEntregaCarga.c_NroDoc) > 0 Then ObjEntregaCarga.c_iControl = 2
                Else
                    ObjEntregaCarga.c_Serie = "0"
                    ObjEntregaCarga.c_NroDoc = "0"
                End If
            End If
            ObjEntregaCarga.c_fecha_inicio = dtFechaInicio.Text
            ObjEntregaCarga.c_fecha_fin = dtFechaFin.Text
            ObjEntregaCarga.c_idOrigen = Int(objGuiaEnvio.coll_Lista_Origen(cmbOrigen.SelectedIndex.ToString))
            ObjEntregaCarga.c_idDestino = Int(objGuiaEnvio.coll_Lista_Destino(cmbDestino.SelectedIndex.ToString))
            ObjEntregaCarga.c_idestado_registro = Int(ObjEntregaCarga.col_Estados.Item(cmbEstados.SelectedIndex.ToString))
            ObjEntregaCarga.c_rucdni = IIf(txtClienteDNIRUC.Text <> "", txtClienteDNIRUC.Text, "0")
            ObjEntregaCarga.c_tipo_entrega = Me.cboTipoEntrega.SelectedIndex

            If Me.txtBuscar.Text.Trim.Length = 0 Then
                ObjEntregaCarga.c_tipo = 0
                ObjEntregaCarga.c_nombres = ""
            Else
                ObjEntregaCarga.c_tipo = IIf(Me.rbtCliente.Checked, 1, 2)
                ObjEntregaCarga.c_nombres=Me.txtBuscar.Text.Trim
            End If

            dtControl_FAC.Clear()
            dtGridViewControl_FACBOL.Refresh()
            'Mod.14/09/2009 -->Omendoza - Pasando al datahelper   
            Dim ldt_tmp As New DataTable
            ldt_tmp = ObjEntregaCarga.Listar(dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)

            dvControl_FAC = ldt_tmp.DefaultView
            '
            bformatImage = True
            dtGridViewControl_FACBOL.DataSource = dvControl_FAC
            dtGridViewControl_FACBOL.Refresh()
            lbNroRegistro1.Text = dvControl_FAC.Count
            totales()

            If dvControl_FAC.Count = 0 Then
                MessageBox.Show("No se encontraron Coincidencias", "Entrega de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                bformatImage = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Entrega de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtBuscar_Enter(sender As Object, e As System.EventArgs) Handles txtBuscar.Enter
        Me.txtBuscar.SelectAll()
    End Sub

    Private Sub rbtCliente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtCliente.CheckedChanged
        Me.txtBuscar.Focus()
    End Sub

    Private Sub rbtConsignado_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtConsignado.CheckedChanged
        Me.txtBuscar.Focus()
    End Sub

    Private Sub dtGridViewControl_FACBOL_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtGridViewControl_FACBOL.RowEnter
        With dtGridViewControl_FACBOL
            'Huella
            'Dim intTipoEntrega As Integer = .Rows(e.RowIndex).Cells("Idtipo_Entrega_Carga").Value
            'If intTipoEntrega = 1 Then
            '    Me.btnEntregar.Enabled = True
            'Else
            '    Me.btnEntregar.Enabled = False
            'End If

            If .Rows(e.RowIndex).Cells("idEstado_Documento").Value <> 21 Then
                Me.btnIncidencia.Enabled = True
            Else
                Me.btnIncidencia.Enabled = False
            End If
        End With
    End Sub

    Private Sub btnIncidencia_Click(sender As System.Object, e As System.EventArgs) Handles btnIncidencia.Click
        Dim frm As New frmEntregaIncidencia
        frm.Tipo = dtGridViewControl_FACBOL.Rows(dtGridViewControl_FACBOL.CurrentCell.RowIndex).Cells("IDTIPO_COMPROBANTE").Value
        frm.Comprobante = dtGridViewControl_FACBOL.Rows(dtGridViewControl_FACBOL.CurrentCell.RowIndex).Cells("IDDOC").Value
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            btnBuscar_Click_1(Nothing, Nothing)
        End If
    End Sub

    Private Sub dtGridViewControl_FACBOL_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtGridViewControl_FACBOL.CellContentClick

    End Sub

    Private Sub txtNroSerieDoc_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroSerieDoc.KeyPress
        If ValidaNumero2(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtNroSerieDoc_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNroSerieDoc.TextChanged

    End Sub
End Class
