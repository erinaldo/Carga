Imports System
Imports System.Drawing
Imports System.Net
Imports System.Net.Sockets
Imports System.Reflection
Public Class FrmListaEntregaRecojo

    Dim daControl_FAC As New OleDb.OleDbDataAdapter
    Dim dtControl_FAC As New System.Data.DataTable
    Dim dvControl_FAC As System.Data.DataView
    Dim bformatImage As Boolean = False

    Private Sub FrmListaEntregaRecojo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If ObjFiltrosEntregaRecojos.fnLISTA_SINO_TIPO() = False Then
                'Mod.02/10/2009 -->Omendoza - Pasando al datahelper -  
                'ModuUtil.LlenarComboIDs(ObjFiltrosEntregaRecojos.CUR_DATOS, cmbSINO, ObjFiltrosEntregaRecojos.col_sino, 9)
                'ModuUtil.LlenarComboIDs(ObjFiltrosEntregaRecojos.CUR_DATOS.NextRecordset, cmbTipoOperacion, ObjFiltrosEntregaRecojos.col_tipo_operacion, 999)
                ModuUtil.LlenarComboIDs_dt(ObjFiltrosEntregaRecojos.ds_cur_datos.Tables(0), cmbSINO, ObjFiltrosEntregaRecojos.col_sino, 9)
                ModuUtil.LlenarComboIDs_dt(ObjFiltrosEntregaRecojos.ds_cur_datos.Tables(1), cmbTipoOperacion, ObjFiltrosEntregaRecojos.col_tipo_operacion, 999)
            End If


            Me.dtFechaFin.Text = dtoUSUARIOS.m_sFecha
            Me.dtFechaInicio.Text = dtoUSUARIOS.m_sFecha
            'Mod.10/09/2009 -->Omendoza - Pasando al datahelper   
            ModuUtil.LlenarComboIDs_dt(ObjEntregaCarga.fnEstadoRegistros(), cmbEstados, ObjEntregaCarga.col_Estados, 999)
            ''Datahelper
            'rst = New ADODB.Recordset
            'rst = VOCONTROLUSUARIO.ListarAgencias(-1)
            'ModuUtil.LlenarComboIDs(rst, cmbAgencia, objGuiaEnvio.coll_Lista_Agencias, dtoUSUARIOS.m_iIdAgencia)
            '
            Dim lobj_adoserver As New AdoServer
            lobj_adoserver.ListarAgencias()
            'ModuUtil.LlenarComboIDs(rst, cmbAgencia, objGuiaEnvio.coll_Lista_Agencias, dtoUSUARIOS.m_iIdAgencia)
            ModuUtil.LlenarComboIDs_dt(lobj_adoserver.dt_Listar_agencias, cmbAgencia, objGuiaEnvio.coll_Lista_Agencias, dtoUSUARIOS.m_iIdAgencia)
            '''''''''''''''''
            '
            'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper   
            If objGuiaEnvio.fnFILTRO_USUARIO_X_AGENCIA(dtoUSUARIOS.m_iIdAgencia) = True Then
                '01/09/2009 - Mod. x Datahelper x datatable 
                'ModuUtil.LlenarComboIDs(objGuiaEnvio.rst_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, dtoUSUARIOS.IdLogin)
                ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, dtoUSUARIOS.IdLogin)
            Else
                NingunoComboIDs(cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios)
            End If

            fnLoadGrid()
        Catch ex As Exception
            MsgBox("Consulte con Sistemas...", MsgBoxStyle.Information, "Seguridad Sistemas")
        End Try
    End Sub
    Public Function fnLoadGrid() As Boolean
        Try
            With dtGridViewControl_FACBOL
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
            dtGridViewControl_FACBOL.Columns.Add(idEstadoImage)

            Dim PK As New DataGridViewTextBoxColumn
            With PK
                .DisplayIndex = 1
                .DataPropertyName = "PK"
                .HeaderText = "PK"

                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(PK)

            Dim IDDOC As New DataGridViewTextBoxColumn
            With IDDOC
                .DisplayIndex = 2
                .DataPropertyName = "IDDOC"
                .HeaderText = "IDDOC"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(IDDOC)


            Dim NRODOC As New DataGridViewTextBoxColumn
            With NRODOC
                .DisplayIndex = 3
                .DataPropertyName = "NRODOC"
                .HeaderText = "NRODOC"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(NRODOC)

            Dim TIPO As New DataGridViewTextBoxColumn
            With TIPO
                .DisplayIndex = 4
                .DataPropertyName = "Tipo"
                .HeaderText = "TIPO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
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
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(FECHA)


            Dim ENTREGA As New DataGridViewTextBoxColumn
            With ENTREGA
                .DisplayIndex = 6
                .DataPropertyName = "ENTREGA"
                .HeaderText = "ENTREGA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
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
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
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
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Razon_Social)

            Dim forma_pago As New DataGridViewTextBoxColumn
            With forma_pago
                .DisplayIndex = 9
                .DataPropertyName = "forma_pago"
                .HeaderText = "PAGO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(forma_pago)

            Dim Nro_Guia_Transportista As New DataGridViewTextBoxColumn
            With Nro_Guia_Transportista
                .DisplayIndex = 10
                .DataPropertyName = "Nro_Guia_Transportista"
                .HeaderText = "G.TRANSP"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Nro_Guia_Transportista)

            Dim Fecha_Salida As New DataGridViewTextBoxColumn
            With Fecha_Salida
                .DisplayIndex = 11
                .DataPropertyName = "Fecha_Salida"
                .HeaderText = "F.SALIDA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Fecha_Salida)


            Dim Hora_Salida As New DataGridViewTextBoxColumn
            With Hora_Salida
                .DisplayIndex = 12
                .DataPropertyName = "Hora_Salida"
                .HeaderText = "H.SALIDA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Hora_Salida)


            Dim Origen As New DataGridViewTextBoxColumn
            With Origen
                .DisplayIndex = 13
                .DataPropertyName = "Origen"
                .HeaderText = "ORIGEN"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Origen)

            Dim Destino As New DataGridViewTextBoxColumn
            With Destino
                .DisplayIndex = 14
                .DataPropertyName = "Destino"
                .HeaderText = "DESTINO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Destino)

            Dim Transito As New DataGridViewTextBoxColumn
            With Transito
                .DisplayIndex = 15
                .DataPropertyName = "Transito"
                .HeaderText = "TRASNSITO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Transito)

            Dim Cantidad_x_Peso As New DataGridViewTextBoxColumn
            With Cantidad_x_Peso
                .DisplayIndex = 16
                .DataPropertyName = "Cantidad_x_Peso"
                .HeaderText = "C. PESO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Cantidad_x_Peso)

            Dim Cantidad_x_Volumen As New DataGridViewTextBoxColumn
            With Cantidad_x_Volumen
                .DisplayIndex = 17
                .DataPropertyName = "Cantidad_x_Volumen"
                .HeaderText = "C. VOL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Cantidad_x_Volumen)

            Dim Cantidad_x_Sobre As New DataGridViewTextBoxColumn
            With Cantidad_x_Sobre
                .DisplayIndex = 18
                .DataPropertyName = "Cantidad_x_Sobre"
                .HeaderText = "C. SOBRE"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Cantidad_x_Sobre)

            Dim Total_Peso As New DataGridViewTextBoxColumn
            With Total_Peso
                .DisplayIndex = 19
                .DataPropertyName = "Total_Peso"
                .HeaderText = "T. PESO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Total_Peso)

            Dim Total_Volumen As New DataGridViewTextBoxColumn
            With Total_Volumen
                .DisplayIndex = 20
                .DataPropertyName = "Total_Volumen"
                .HeaderText = "T. VOL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Total_Volumen)

            Dim Fecha_Entrega As New DataGridViewTextBoxColumn
            With Fecha_Entrega
                .DisplayIndex = 21
                .DataPropertyName = "Fecha_Entrega"
                .HeaderText = "F.Entrega"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Fecha_Entrega)

            Dim Hora_Entrega As New DataGridViewTextBoxColumn
            With Hora_Entrega
                .DisplayIndex = 22
                .DataPropertyName = "Hora_Entrega"
                .HeaderText = "H.ENTREGA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Hora_Entrega)


            Dim idEstadoGuiaTrans As New DataGridViewTextBoxColumn
            With idEstadoGuiaTrans
                .DisplayIndex = 23
                .DataPropertyName = "idEstadoGuiaTrans"
                .HeaderText = "idEstadoGuiaTrans"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(idEstadoGuiaTrans)

            Dim Estado_Documento As New DataGridViewTextBoxColumn
            With Estado_Documento
                .DisplayIndex = 24
                .DataPropertyName = "Estado_Documento"
                .HeaderText = "ESTADO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Estado_Documento)

            Dim idEstado_Documento As New DataGridViewTextBoxColumn
            With idEstado_Documento
                .DisplayIndex = 25
                .DataPropertyName = "idEstado_Documento"
                .HeaderText = "ESTADO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewControl_FACBOL.Columns.Add(idEstado_Documento)

            Dim Login As New DataGridViewTextBoxColumn
            With Login
                .DisplayIndex = 26
                .DataPropertyName = "Login"
                .HeaderText = "DESPACHADO X"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewControl_FACBOL.Columns.Add(Login)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad sistema")
        End Try
        Return False
    End Function
    Private Sub btnEntregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEntregar.Click
        Try
            Dim Frm As New FrmAtencionCliente
            Frm.ShowDialog()
            Frm = Nothing
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnVerData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerData.Click

    End Sub
End Class
