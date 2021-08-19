'Imports System
'Imports System.Drawing
'Imports System.Net
'Imports System.Net.Sockets
'Imports System.Reflection
Imports PrinterTxt
' Omendoza - 25/08/2008 
Public Class FrmGuiaEnvio
    Inherits frmBaseVentas
    '
    Dim ObjRptGuiaEnvio As New dtoRptGuiaEnvio()

    Dim mostrar_pre_guias As Boolean = True

    Dim flag_ver_datos As Boolean = False

    Dim p_domicilio As String
    Dim p_agencia As String
    Dim p_contado As String
    Dim p_destino As String
    Dim p_credito As String


    Dim v_iDestino As String = "      "
    Dim v_iCredito As String = "      "

    Dim v_iDomicilio As String = "      "
    Dim v_iAgencia As String = "      "
    Dim v_Origen, v_destino As String
    Dim p_cargo As String = " "

    Dim bControl_Busqueda As Boolean = False
    Dim tarifa_Peso As Double
    Dim tarifa_Volumen As Double
    Dim tarifa_Articulo As Double
    Dim tarifa_Sobre As Double


    Dim IGV As Double
    Dim Monto_Base As Double = 0
    Dim bControl_Tarifas As Boolean = False

    Dim iROW_ACTUAL As Integer
    Dim iCOL_ACTUAL As Integer

    Dim iROW As Integer = -1
    Dim iCOL As Integer = -1

    'Dim iDigitosSerie As Integer = 3 'De acuerdo al cliente  Se modifica de 3 a 4 
    Dim li_iDigitosSerie As Integer = 3 'De acuerdo al cliente es la serie, modifica de 3 a 4 
    '
    Dim iDigitosDcoumento As Integer = 7
    '
    Dim iDigitosDecimal As Integer = 3
    Dim iFlagControl As Boolean = False
    '
    Public iWinOrigen As New AutoCompleteStringCollection
    Public iWinDestino As New AutoCompleteStringCollection
    Public iWinPerosa As New AutoCompleteStringCollection
    Public iWinPerosaRUC As New AutoCompleteStringCollection
    Public iwinNro_digito_serie_cliente As New AutoCompleteStringCollection  ' 18/07/2009 
    '
    Public iWinPerosaDNI_Remite As New AutoCompleteStringCollection
    Public iWinPerosaDNI_Destino As New AutoCompleteStringCollection
    '
    Dim iWinCLIENTE_Remitente As New AutoCompleteStringCollection
    Dim iWinCLIENTEDNI_Remite As New AutoCompleteStringCollection

    Public iWinContacto_Remitente As New AutoCompleteStringCollection
    Public iWinDireccion_Remitente As New AutoCompleteStringCollection
    Public iWinTelefono_Remitente As New AutoCompleteStringCollection
    Public iWinContacto_Destinatario As New AutoCompleteStringCollection
    Public iWinDireccion_Destinatario As New AutoCompleteStringCollection
    Public iWinTelefono_Destinatario As New AutoCompleteStringCollection

    Public coll_Lista_Personas As New Collection
    Public coll_iOrigen As New Collection
    Public coll_iDestino As New Collection
    Public xcoll_iDestino As New Collection
    Public coll_Remitente As New Collection

    '
    'Dim daControl_Guia As New OleDb.OleDbDataAdapter
    '
    Dim dtControl_Guia As New System.Data.DataTable
    Dim dvControl_Guia As System.Data.DataView
    Dim bformatImage As Boolean = False
    Dim CONTROL As Integer = 3
    Dim fArticulo As Boolean = False
    Dim fnCONTROLDATOS As Boolean = False
    Dim lb_no_lee As Boolean = True '15/08/2008 -No lee los datos 
    Dim lb_no_paso As Boolean   '22/08/2008 
    '13/05/2009 - 
    Dim coll_AgenciasOrigen As New Collection
    '

    'Private Sub FrmPre_Fact_Automatica_ClickTabPage1() Handles Me.ClickTabPage1
    '    Try
    '        MsgBox("Menu 1")
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    'End Sub
    'Private Sub FrmPre_Fact_Automatica_ClickTabPage2() Handles Me.ClickTabPage2
    '    Try
    '        MsgBox("Menu 1")
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    'End Sub
    Dim strNroGuias_Remision As String = ""
    Dim iTOTAL_BULTOS As String = ""
    Dim iTOTAL_VOLUMEN As String = ""
    Dim iTOTAL_PESO As String = ""

    Dim CORRELATIVO As String = "0"
    Dim xIMPRESORA As Integer = 1
    Dim ObjReport As New ClsLbTepsa.dtoFrmReport
    Dim objPRE_GUIAS As New ClsLbTepsa.dtoPRE_GUIAS
    '03/08/2008 - Actualiza valores 
    Dim lb_datos_editados As Boolean
    Dim lb_solo_visualiza As Boolean
    Dim bRango As Boolean = False
    '26/08/2009 -
    Dim sFecha As String
    Dim sHora As String
    Dim total_bultos As Long
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub FrmGuiaEnvio_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmGuiaEnvio_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    '
    Private Sub FrmGuiaEnvio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '
            iProceso = 0
            lb_datos_editados = False
            '' objLOG.fnLog("LOAD MAIN GUIAS_ENVIO")
            objGuiaEnvio.iCONTROL = 1
            fnCONTROLDATOS = True
            ToolStripMenuItem1.Text = "BUSCAR"
            ToolStripMenuItem2.Text = "GUIAS DE ENVIO"
            'rst = Nothing
            'rst = VOCONTROLUSUARIO.ListarAgencias(-1)
            'ModuUtil.LlenarTreeCtrl(rst, Me.TreeLista, "AGENCIAS")
            'Los Permisos para revizar otras liquidaciones estan validas
            'solo para Administradores de Agencia y Para DBA
            '

            'If fnValidar_Rol("2") = True Or fnValidar_Rol("14") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 1) Then
                cmbUsuarios.Enabled = True
                cmbAgencia.Enabled = True
            Else
                cmbUsuarios.Enabled = False
                cmbAgencia.Enabled = False
            End If

            IGV = dtoUSUARIOS.iIGV / 100
            lbIGV.Text = "( " & Int(100 * IGV).ToString & "% ) IGV"
            IniciarImagenes()
            fnConfiguracion_Grillas()
            objGuiaEnvio.iCARGO = Int(chechCargo.Checked)
            'dtoUSUARIOS.m_iIdAgencia = 1
            'objGuiaEnvio.iCONTROL = 1
            'If objGuiaEnvio.fnLISTA_AGENCIA_USUARIOS() = True Then
            '    ModuUtil.LlenarComboIDs(objGuiaEnvio.rst_Lista_Unidades, cmbAgencia, objGuiaEnvio.coll_Lista_Agencias, dtoUSUARIOS.m_iIdAgencia)
            '    ModuUtil.LlenarComboIDs(objGuiaEnvio.rst_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, 0)
            '    objGuiaEnvio.rst_Lista_Unidades = Nothing
            '    objGuiaEnvio.rst_Lista_Usuarios = Nothing
            'End If

            TabMante.SelectedIndex = 1
            Me.txtFechaGuia.Text = dtoUSUARIOS.m_sFecha
            dtFechaGuia.Text = dtoUSUARIOS.m_sFecha
            dtFechaInicio.Text = dtoUSUARIOS.m_sFecha
            dtFechaFin.Text = dtoUSUARIOS.m_sFecha

            TxtGuiaEnvio.SelectAll()
            TxtGuiaEnvio.Focus()
            'TxtGuiaEnvio.Cursor = Cursors.Hand
            ' Me.cmbTipo_Entrega.Show()
            'Me.cmbTipo_Entrega.DisplayRectangle()
            'SendMessage(cmbTipo_Entrega.hwnd, , CB_SHOWDROPDOWN, 1, 0)
            Call LoadGrilla()
            TxtGuiaEnvio.Focus()
            '
            'MODIFICADO POR RITCHER GOMEZ

            'If objGuiaEnvio.fnLISTA_PERSONAS() = True Then
            '    fnCargar_iWin2(Me.TxtRasonSocial, objGuiaEnvio.rst_Lista_Personas, coll_Lista_Personas, iWinPerosa, 0, iWinPerosaRUC)
            'End If
            'Mod. 22/08/2009 -->Omendoza - Pasando al datahelper   
            If objGuiaEnvio.fnLISTA_PERSONASII(dtoUSUARIOS.IdLogin) = True Then
                '
                'fnCargar_iWin2(Me.TxtRasonSocial, objGuiaEnvio.rst_Lista_Personas, coll_Lista_Personas, iWinPerosa, 0, iWinPerosaRUC)  ' Modificado 18/07/2009 
                '22/08/2009 - Modificado por data-helper 
                '
                fnCargar_iWin2(Me.TxtRasonSocial, objGuiaEnvio.dt_Lista_Personas, coll_Lista_Personas, iWinPerosa, 0, iWinPerosaRUC, iwinNro_digito_serie_cliente) 'Modificado 18/07/2009 
            End If
            'Mod. 25/08/2009 -->Omendoza - Pasando al datahelper   
            If objGuiaEnvio.fnLISTA_ORIGEN_DESTINO() = True Then
                fnCargar_iWin_dt(txtiWinOrigen, objGuiaEnvio.dt_cur_Origen, coll_iOrigen, iWinOrigen, dtoUSUARIOS.m_idciudad)
                fnCargar_iWin_dt(txtiWinDestino, objGuiaEnvio.dt_cur_Destino, coll_iDestino, iWinDestino, 5630)
            End If
            'Mod. 28/08/2009 -->Omendoza - Pasando al datahelper   
            If (objGuiaEnvio.fnLISTA_INICIAL_GUIAS_ENVIO() = True) Then
                'Dim var_rst As ADODB.Recordset = objGuiaEnvio.rst_Lista_Unidades
                'fnCargar_iWin2(txtiWinOrigen, txtiWinDestino, objGuiaEnvio.rst_Lista_Unidades, coll_iOrigen, iWinOrigen, 1, iWinDestino, 1)
                'fnCargar_iWin(txtiWinOrigen, objGuiaEnvio.rst_Lista_Unidades, coll_iOrigen, iWinOrigen, 1)
                'fnCargar_iWin(txtiWinDestino, objGuiaEnvio.rst_Lista_Unidades, coll_iOrigen, iWinOrigen, 1, iWinDestino, 1)
                '
                'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper   
                If objGuiaEnvio.fnLISTA_AGENCIAS_UNIDADES() = True Then
                    ModuUtil.LlenarComboIDs2(objGuiaEnvio.dt_Lista_Unidades_Agencia, cmbOrigen, objGuiaEnvio.coll_Lista_Origen, 9999, cmbDestino, objGuiaEnvio.coll_Lista_Destino, 9999)
                End If
                '
                Dim ldt As New AdoServer

                ldt.ListarAgencias()
                ' Modificado 01/09/2009 - Por cambio al datahelper 
                'rst = New ADODB.Recordset 
                'rst = VOCONTROLUSUARIO.ListarAgencias(-1) ' Con Recordset pasado a datatable 

                '
                ModuUtil.LlenarComboIDs_dt(ldt.dt_Listar_agencias, cmbAgencia, objGuiaEnvio.coll_Lista_Agencias, dtoUSUARIOS.m_iIdAgencia)
                '
                '01/09/2009 - Convertido a datatable x Datahelper                 
                'ModuUtil.LlenarComboIDs(rst, cmbAgencia, objGuiaEnvio.coll_Lista_Agencias, dtoUSUARIOS.m_iIdAgencia)
                '
                'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper   
                '
                If objGuiaEnvio.fnFILTRO_USUARIO_X_AGENCIA(dtoUSUARIOS.m_iIdAgencia) = True Then
                    '
                    '01/09/2009 - Modificado por datahelper 
                    '
                    'ModuUtil.LlenarComboIDs(objGuiaEnvio.rst_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, dtoUSUARIOS.IdLogin)
                    ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, dtoUSUARIOS.IdLogin)
                Else
                    NingunoComboIDs(cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios)
                End If
                'ModuUtil.LlenarComboIDs(objGuiaEnvio.rst_Lista_Estados, cmbEstados, objGuiaEnvio.coll_Lista_Estados, 999)
                'ModuUtil.LlenarComboIDs(objGuiaEnvio.rst_Lista_Forma_Pagos, cmbFormaCredito, objGuiaEnvio.coll_Lista_Forma_Pagos, 2)
                'ModuUtil.LlenarComboIDs(objGuiaEnvio.rst_Lista_Tipo_Entrega, cmbTipo_Entrega, objGuiaEnvio.coll_Lista_Tipo_Entrega, 1)
                ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_Lista_Estados, cmbEstados, objGuiaEnvio.coll_Lista_Estados, 999)
                ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_Lista_Forma_Pagos, cmbFormaCredito, objGuiaEnvio.coll_Lista_Forma_Pagos, 2)
                ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_Lista_Tipo_Entrega, cmbTipo_Entrega, objGuiaEnvio.coll_Lista_Tipo_Entrega, 1)
                '
            End If
            fnNUEVO()
            objGuiaEnvio.iCONTROL = 1
            cmbFormaCredito.Enabled = False
            cmbFormaCredito.Enabled = False
            xIMPRESORA = fnSeleccionImpresion()
            '27/11/2009 - Validando 
            If xIMPRESORA = 0 Then
                MsgBox("Se recomienda seleccionar la impresora que emite las etiquetas, en la opción [Configuración/Impresora Térmica]", MsgBoxStyle.Information, "Seguridad Sistema")
                xIMPRESORA = 1 ' Por defecto 
            End If
            '
            If dtoUSUARIOS.m_iIdAgencia > 0 Then
                objGuiaEnvio.iIDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
            Else
                objGuiaEnvio.iIDAGENCIAS = 0
            End If
            '
            fnAgenciaOrigen()
            lb_solo_visualiza = False

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub LoadGrilla()
        Try
            '' dtGridViewControl_GUIAS.Columns.Clear()
            With dtGridViewControl_GUIAS
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
            'Dim col_Guias0 As New DataGridViewTextBoxColumn
            'With col_Guias0
            '    .DisplayIndex = 0
            '    .DataPropertyName = "Idguias_Envio"
            '    .HeaderText = "Idguias_Envio"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .ReadOnly = True
            '    .Visible = False
            'End With
            'dtGridViewControl_GUIAS.Columns.Add(col_Guias0)


            'Dim col_Guias1 As New DataGridViewTextBoxColumn
            'With col_Guias1
            '    .DisplayIndex = 1
            '    .DataPropertyName = "f_Guia"
            '    .HeaderText = "f_Guia"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .ReadOnly = True
            '    .Visible = True
            'End With
            'dtGridViewControl_GUIAS.Columns.Add(col_Guias1)


            'Dim col_Guias2 As New DataGridViewTextBoxColumn
            'With col_Guias2
            '    .DisplayIndex = 2
            '    .DataPropertyName = "Nro_Guia"
            '    .HeaderText = "Nro_Guia"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .ReadOnly = True
            '    .Visible = True
            'End With
            'dtGridViewControl_GUIAS.Columns.Add(col_Guias2)

            'Dim col_Guias3 As New DataGridViewTextBoxColumn
            'With col_Guias3
            '    .DisplayIndex = 3
            '    .DataPropertyName = "Cantidad"
            '    .HeaderText = "Cantidad"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .ReadOnly = True
            '    .Visible = True
            'End With
            'dtGridViewControl_GUIAS.Columns.Add(col_Guias3)

            'Dim col_Guias4 As New DataGridViewTextBoxColumn
            'With col_Guias4
            '    .DisplayIndex = 4
            '    .DataPropertyName = "Nu_Docu_Suna"
            '    .HeaderText = "Nu_Docu_Suna"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .ReadOnly = True
            '    .Visible = True
            'End With
            'dtGridViewControl_GUIAS.Columns.Add(col_Guias4)

            'Dim col_Guias5 As New DataGridViewTextBoxColumn
            'With col_Guias5
            '    .DisplayIndex = 5
            '    .DataPropertyName = "Razon_Social"
            '    .HeaderText = "Razon_Social"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .ReadOnly = True
            '    .Visible = True
            'End With
            'dtGridViewControl_GUIAS.Columns.Add(col_Guias5)

            'Dim col_Guias6 As New DataGridViewTextBoxColumn
            'With col_Guias6
            '    .DisplayIndex = 6
            '    .DataPropertyName = "ORIGEN"
            '    .HeaderText = "ORIGEN"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .ReadOnly = True
            '    .Visible = True
            'End With
            'dtGridViewControl_GUIAS.Columns.Add(col_Guias6)

            'Dim col_Guias7 As New DataGridViewTextBoxColumn
            'With col_Guias7
            '    .DisplayIndex = 7
            '    .DataPropertyName = "DESTINO"
            '    .HeaderText = "DESTINO"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .ReadOnly = True
            '    .Visible = True
            'End With
            'dtGridViewControl_GUIAS.Columns.Add(col_Guias7)

            'Dim col_Guias8 As New DataGridViewTextBoxColumn
            'With col_Guias8
            '    .DisplayIndex = 8
            '    .DataPropertyName = "CIUDAD_TRANCITO"
            '    .HeaderText = "CIUDAD_TRANCITO"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .ReadOnly = True
            '    .Visible = True
            'End With
            'dtGridViewControl_GUIAS.Columns.Add(col_Guias8)

            'Dim col_Guias9 As New DataGridViewTextBoxColumn
            'With col_Guias9
            '    .DisplayIndex = 9
            '    .DataPropertyName = "f_Registro"
            '    .HeaderText = "f_Registro"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .ReadOnly = True
            '    .Visible = True
            'End With
            'dtGridViewControl_GUIAS.Columns.Add(col_Guias9)

            'Dim col_Guias10 As New DataGridViewTextBoxColumn
            'With col_Guias10
            '    .DisplayIndex = 10
            '    .DataPropertyName = "Estado_Registro"
            '    .HeaderText = "Estado_Registro"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .ReadOnly = True
            '    .Visible = True
            'End With
            'dtGridViewControl_GUIAS.Columns.Add(col_Guias10)

            'Dim col_Guias11 As New DataGridViewTextBoxColumn
            'With col_Guias11
            '    .DisplayIndex = 11
            '    .DataPropertyName = "Idestado_Registro"
            '    .HeaderText = "Idestado_Registro"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .ReadOnly = True
            '    .Visible = False
            'End With
            'dtGridViewControl_GUIAS.Columns.Add(col_Guias11)

            'Dim col_Guias12 As New DataGridViewTextBoxColumn
            'With col_Guias12
            '    .DisplayIndex = 12
            '    .DataPropertyName = "Idunidad_Agencia"
            '    .HeaderText = "Idunidad_Agencia"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .ReadOnly = True
            '    .Visible = False
            'End With
            'dtGridViewControl_GUIAS.Columns.Add(col_Guias12)

            'Dim col_Guias13 As New DataGridViewTextBoxColumn
            'With col_Guias13
            '    .DisplayIndex = 13
            '    .DataPropertyName = "Idunidad_Agencia_Destino"
            '    .HeaderText = "Idunidad_Agencia_Destino"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .ReadOnly = True
            '    .Visible = False
            'End With
            'dtGridViewControl_GUIAS.Columns.Add(col_Guias13)

            '-----------------------------------------------------------------------------------------------------------
            '-----------------------------------------------------------------------------------------------------------
            'Dim APEPAT As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            'With APEPAT
            '    .DisplayIndex = 0
            '    .DataPropertyName = "APEPAT"
            '    .HeaderText = "APEPAT"
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            '    '.Mask = "###-#######"
            '    .DefaultCellStyle.NullValue = "-"
            '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '    .ReadOnly = False
            '    '.DefaultCellStyle .
            'End With
            'dtGridViewRemitente.Columns.Add(APEPAT)

            'Dim APEMAT As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            'With APEMAT
            '    .DisplayIndex = 0
            '    .DataPropertyName = "APEMAT"
            '    .HeaderText = "APEMAT"
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            '    '.Mask = "###-#######"
            '    .DefaultCellStyle.NullValue = "-"
            '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '    .ReadOnly = False
            'End With
            'dtGridViewRemitente.Columns.Add(APEMAT)

            'Dim NOMPER As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            'With NOMPER
            '    .DisplayIndex = 0
            '    .DataPropertyName = "NOMPER"
            '    .HeaderText = "NOMPER"
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            '    '.Mask = "###-#######"
            '    .DefaultCellStyle.NullValue = "-"
            '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '    .ReadOnly = False
            'End With
            'dtGridViewRemitente.Columns.Add(NOMPER)
            'Dim datos As String() = {"", "", ""}
            'dtGridViewRemitente.Rows().Add(datos)
            'dtGridViewControl_GUIAS.Rows  
            ' Grilla para los Documentos
            With dtGridViewArticulo
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AllowUserToOrderColumns = False
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = False
                .AutoGenerateColumns = False
                '.DataSource = dtable_Lista_Control_Comprobante
                .VirtualMode = False
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            Dim col_Art1 As New DataGridViewTextBoxColumn
            With col_Art1
                .DisplayIndex = 0
                .DataPropertyName = "idarticulos"
                .HeaderText = "idarticulos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewArticulo.Columns.Add(col_Art1)
            Dim col_Art2 As New DataGridViewTextBoxColumn
            With col_Art2
                .DisplayIndex = 1
                .DataPropertyName = "Nombre_Articulo"
                .HeaderText = "Nombre_Articulo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            dtGridViewArticulo.Columns.Add(col_Art2)
            Dim col_Art0 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            'Dim col_Art0 As New DataGridViewTextBoxColumn
            With col_Art0
                .DisplayIndex = 2
                .DataPropertyName = "Precio_Final"
                .HeaderText = "Precio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "####,###.00"
                .Mask = "####,###.00"
                .ReadOnly = True
                .Visible = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            dtGridViewArticulo.Columns.Add(col_Art0)


            Dim col_Art3 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            'Dim col_Art3 As New DataGridViewTextBoxColumn
            With col_Art3
                .DisplayIndex = 3
                .DataPropertyName = "Cantidad"
                .HeaderText = "Cant."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Mask = "#####0"
                .ReadOnly = False
                .Visible = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            dtGridViewArticulo.Columns.Add(col_Art3)


            Dim col_Art6 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            'Dim col_Art3 As New DataGridViewTextBoxColumn
            With col_Art6
                .DisplayIndex = 4
                .DataPropertyName = "M3"
                .HeaderText = "M3"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "####,##0.000"
                .ReadOnly = False
                .Visible = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            dtGridViewArticulo.Columns.Add(col_Art6)


            Dim col_Art5 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            'Dim col_Art0 As New DataGridViewTextBoxColumn
            With col_Art5
                .DisplayIndex = 5
                .DataPropertyName = "TOTAL_PESO"
                .HeaderText = "Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "####,###.00"
                '.Mask = "####,###.00"
                .ReadOnly = False
                .Visible = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            dtGridViewArticulo.Columns.Add(col_Art5)
            '
            Dim col_Art4 As New DataGridViewTextBoxColumn
            With col_Art4
                .DisplayIndex = 6
                .DataPropertyName = "TOTAL_COSTO"
                .HeaderText = "P. Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
                .Visible = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            dtGridViewArticulo.Columns.Add(col_Art4)
            '----------------------------------------------------------------------------------------------------------------------------------------
            With DataGridViewDocumentos
                .AllowUserToAddRows = True
                .AllowUserToDeleteRows = True
                .AllowUserToOrderColumns = True
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = False
                .AutoGenerateColumns = False
                '.DataSource = dtable_Lista_Control_Comprobante
                .VirtualMode = False
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            Dim col_1 As New DataGridViewTextBoxColumn
            With col_1
                .DisplayIndex = 0
                .DataPropertyName = "id1"
                .HeaderText = "ID1"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            DataGridViewDocumentos.Columns.Add(col_1)
            Dim col_0 As New DataGridViewTextBoxColumn
            With col_0
                .DisplayIndex = 1
                .DataPropertyName = "id2"
                .HeaderText = "ID2"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            DataGridViewDocumentos.Columns.Add(col_0)
            'Dim col1 As New DataGridViewTextBoxColumn
            Dim col_2 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            With col_2
                .DisplayIndex = 2
                .DataPropertyName = "NRODOCUMENTO1"
                .HeaderText = "NRO DOCUMENTOS"
                .DefaultCellStyle.ForeColor = Color.Black
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.Mask = "###-########"
                .Mask = "AAAA-AAAAAAAAAA"
                .DefaultCellStyle.NullValue = "-"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = False
            End With
            DataGridViewDocumentos.Columns.Add(col_2)
            Dim col_3 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            'Dim col2 As New DataGridViewTextBoxColumn
            With col_3
                .DisplayIndex = 3
                .DataPropertyName = "NRODOCUMENTO2"
                .HeaderText = "NRO DOCUMENTOS"
                .DefaultCellStyle.ForeColor = Color.Black
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.Mask = "###-########"
                '.Mask = "AAAA-AAAAAAAAAA"  '18/07/2009 
                .Mask = "AAA-AAAAAAAAAA"    '18/07/2009  Por defecto va ocupar 3 dígitos  
                .DefaultCellStyle.NullValue = "-"
                .ReadOnly = False
            End With
            DataGridViewDocumentos.Columns.Add(col_3)
            Dim row11 As String() = {"", "", "-", "-"}
            DataGridViewDocumentos.Rows().Add(row11)
            DataGridViewDocumentos.Rows().Add(row11)
            '****************************************************************************
            With dtGridViewBultos
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = True
                .AllowUserToOrderColumns = False
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = False
                .AutoGenerateColumns = False
                '.DataSource = dtable_Lista_Control_Comprobante
                .VirtualMode = False
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .RowHeadersWidth = 14
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            Dim col As New DataGridViewTextBoxColumn
            With col
                .DisplayIndex = 0
                .DataPropertyName = "var"
                .HeaderText = "ID"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewBultos.Columns.Add(col)
            Dim col0 As New DataGridViewTextBoxColumn
            With col0
                .DisplayIndex = 1
                .DataPropertyName = "TIPO"
                .HeaderText = "TIPO"
                .SortMode = DataGridViewColumnSortMode.NotSortable   'add 14/08/2008
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            dtGridViewBultos.Columns.Add(col0)
            '
            'Dim col2 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            Dim col2 As New DataGridViewTextBoxColumn

            With col2
                .DisplayIndex = 2
                .DataPropertyName = "Cantidad"
                .HeaderText = "PIEZAS"
                .DefaultCellStyle.ForeColor = Color.Black
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '                
                '.Mask = "#####"  '--> 25/08/2008
                .DefaultCellStyle.Format = "####0"
                '
                .ReadOnly = False
            End With
            dtGridViewBultos.Columns.Add(col2)
            '
            'Dim col1 As New DataGridViewTextBoxColumn
            'Dim col1 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            Dim col1 As New DataGridViewTextBoxColumn
            With col1
                .DisplayIndex = 3
                .DataPropertyName = "PESO_VOLUMEN"
                .HeaderText = "PESO/VOLUMEN"
                .DefaultCellStyle.ForeColor = Color.Black
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.Mask = "####,###,###.000"
                .DefaultCellStyle.Format = "####,###,###.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = False
            End With
            dtGridViewBultos.Columns.Add(col1)
            ' Modifcado 08/08/2008 - Se agrego el campo del costo 
            Dim col4 As New DataGridViewTextBoxColumn
            With col4
                .DisplayIndex = 4
                .Name = "COSTO"
                .DataPropertyName = "COSTO"
                .HeaderText = "COSTO"
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.Mask = "99999999.999" 'Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
                .DefaultCellStyle.Format = "##,###,###.00"
                .DefaultCellStyle.NullValue = "0.00"
                '.DefaultCellStyle.NullValue = Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
                .Width = 100
            End With
            dtGridViewBultos.Columns.Add(col4)
            '
            'Dim col3 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            Dim col3 As New DataGridViewTextBoxColumn
            With col3
                .DisplayIndex = 5
                .DataPropertyName = "TOTAL"
                .HeaderText = "SUB TOTAL"
                .ReadOnly = True
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.Mask = "99999999.999" 'Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
                .DefaultCellStyle.Format = "##,###,###.00"
                .DefaultCellStyle.NullValue = "0.00"
                '.DefaultCellStyle.NullValue = Microsoft.VisualBasic.Right("000000000000000000", DigitosSerie)
                .Width = 100
                .SortMode = DataGridViewColumnSortMode.NotSortable   'add 19/08/2008
            End With
            ' 
            ' 08/08/2008 - Agrega el campo del costo 
            '
            dtGridViewBultos.Columns.Add(col3)
            Dim row0 As String() = {"", "PESO", "", "", "0.00", "0.00"}
            dtGridViewBultos.Rows().Add(row0)
            Dim row1 As String() = {"", "VOLUMEN", "", "", "0.00", "0.00"}
            dtGridViewBultos.Rows().Add(row1)
            Dim row2 As String() = {"", "BASE", "", "", "0.00", "0.00"}
            dtGridViewBultos.Rows().Add(row2)
            '
            'Dim ColEstReg As New DataGridViewComboBoxColumn
            'With ColEstReg
            '    .DataPropertyName = "Idestado_Registro"
            '    .HeaderText = "Estado"
            '    .DisplayIndex = 4
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '    ' Bind ColumnCar to Cars table
            '    .DataSource = dtEstReg.DefaultView
            '    .ValueMember = "Idestado_Registro"
            '    .DisplayMember = "Estado_Registro"
            '    .FlatStyle = FlatStyle.Flat
            '    '.DisplayMember = .ValueMember
            '    .CellTemplate.Style.BackColor = Color.Beige
            'End With
            ''dtGridViewPedido.Columns.Add(ColEstReg)

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Try
            Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    '    Private Sub FrmGuiaEnvio_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    'GroupBox3.Left = Me.ClientSize.Width - GroupBox3.Width - 10
    'GroupBox3.Top = Me.ClientSize.Height - GroupBox3.Height - 10
    'GroupBox2.Left = Me.ClientSize.Width - GroupBox1.Width - 10
    'GroupBox2.Top = Me.ClientSize.Height - GroupBox1.Height - 10
    'DataGridView1.Left = Me.ClientSize.Width - DataGridView1.Width - 10
    'DataGridView1.Top = Me.ClientSize.Height - DataGridView1.Height - 10
    'TabLista.Left = Me.ClientSize.Width - TabLista.Width - 10
    'TabLista.Top = Me.ClientSize.Height - TabLista.Height - 10
    'End Sub

    Private Sub cmbAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectedIndexChanged
        Try
            Dim idAgencia As Integer
            idAgencia = Int(cmbAgencia.SelectedIndex)
            If idAgencia >= 0 Then
                idAgencia = IIf(cmbAgencia.SelectedIndex.ToString() <> "", Int(objGuiaEnvio.coll_Lista_Agencias(cmbAgencia.SelectedIndex.ToString())), 0)
                'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper                   
                If objGuiaEnvio.fnFILTRO_USUARIO_X_AGENCIA(idAgencia) = True Then
                    'Mod. 01/09/2009 - Por el paso al datahelper 
                    'ModuUtil.LlenarComboIDs(objGuiaEnvio.rst_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, 0)
                    ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, 0)
                Else
                    NingunoComboIDs(cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub dtFechaGuia_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFechaGuia.ValueChanged
        Try
            Me.txtFechaGuia.Text = dtFechaGuia.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtGuiaEnvio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtGuiaEnvio.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                BuscarClientesGuia_Envio()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Public Function fnBuscarDatosCleinte() As Boolean
        Try
            'Mod. 24/08/2009 -->Omendoza - Pasando al datahelper   
            If objGuiaEnvio.fnControlGuiasImpresas(TxtGuiaEnvio.Text) = False Then
                txtiWinDestino.Focus()
                txtiWinDestino.SelectAll()
                GoTo SALIR
            End If
            txtiWinOrigen.Text = objGuiaEnvio.iNOMBRE_UNIDAD_ORIGEN
            txtiWinDestino.Text = objGuiaEnvio.iNOMBRE_UNIDAD_DESTINO
            TxtRuc.Text = objGuiaEnvio.sNU_DOCU_SUNAT
        Catch ex As Exception

        End Try
SALIR:
        Return False
    End Function
    Private Function BuscarClientesGuia_Envio() As Boolean
        Dim flag As Boolean = False
        ' Try
        If CONTROL = 4 Then
            CONTROL = 1
        End If

        'If objGuiaEnvio.iCONTROL <> 2 Then
        '    objGuiaEnvio.iCONTROL = CONTROL
        'End If

        objGuiaEnvio.iControl_Busqueda = CONTROL
        If CONTROL <> 2 Then
            objGuiaEnvio.iIDPERSONA = 0
        End If

        TxtGuiaEnvio.Text = RellenoRight(NroDigitos_Guias, TxtGuiaEnvio.Text)

        If txtiWinOrigen.Text <> "" And txtiWinDestino.Text <> "" Then
            objGuiaEnvio.iIDUNIDAD_AGENCIA = Int(coll_iOrigen.Item(iWinOrigen.IndexOf(txtiWinOrigen.Text.ToString()) + 1).ToString())
            objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = Int(coll_iDestino.Item(iWinDestino.IndexOf(txtiWinDestino.Text.ToString()) + 1).ToString())
        Else
            'MsgBox("No ha definido el Destino De envio...", MsgBoxStyle.Information, "Seguridad Sistemas")
            objGuiaEnvio.iIDUNIDAD_AGENCIA = 999
            objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = 999
        End If

        If objGuiaEnvio.iIDUNIDAD_AGENCIA = objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO Then
            'MsgBox("No Existen Tarifas Para Una Ruta Igual..,Verifique sus Datos", MsgBoxStyle.Information, "Seguridad Sistema")
            GoTo SALIR
        End If
        If Me.TxtGuiaEnvio.Text <> "" And TxtGuiaEnvio.Text.Length() > 0 And bControl_Busqueda = False Then
            'objGuiaEnvio.iCONTROL = 1
            objGuiaEnvio.sNRO_GUIA = TxtGuiaEnvio.Text
        Else
            objGuiaEnvio.sNRO_GUIA = "@"
        End If

        'If objGuiaEnvio.fnControlGuiasImpresas(TxtGuiaEnvio.Text) = False Then
        '    txtiWinDestino.Focus()
        '    txtiWinDestino.SelectAll()
        '    GoTo SALIR
        'End If
        'txtiWinOrigen.Text = objGuiaEnvio.iNOMBRE_UNIDAD_ORIGEN
        'txtiWinDestino.Text = objGuiaEnvio.iNOMBRE_UNIDAD_DESTINO
        'TxtRuc.Text = objGuiaEnvio.sNU_DOCU_SUNAT

        'fnCargar_iWin2(Me.TxtRasonSocial, objGuiaEnvio.rst_Lista_Personas, coll_Lista_Personas, iWinPerosa, 0, iWinPerosaRUC)                    
        CONTROL = 2
        Dim indexof As Integer = 0
        If iWinPerosa.Count > 0 Then
            'indexof = IIf(iWinContacto_Remitente.IndexOf(txtRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtRemitente.Text), -1)
            indexof = iWinPerosaRUC.IndexOf(TxtRuc.Text)
            objGuiaEnvio.iIDPERSONA = -1
            If indexof >= 0 Then
                objGuiaEnvio.iIDPERSONA = Int(coll_Lista_Personas(indexof.ToString))
                objGuiaEnvio.iCONTROLIdpersona = objGuiaEnvio.iIDPERSONA
                If indexof <= iWinPerosa.Count Then
                    Me.TxtRasonSocial.Text = iWinPerosa.Item(indexof)
                    objGuiaEnvio.iID_REMITENTE = objGuiaEnvio.iIDPERSONA  'Obs ¿P'q'? 
                    objGuiaEnvio.iREMITENTE = TxtRasonSocial.Text
                    objGuiaEnvio.iNRODOC_REM = Me.TxtRuc.Text
                    bControl_Busqueda = True
                End If
            Else
                MsgBox("El Cliente no tiene línea de crédito, Revise sus datos", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        End If
        'If BuscarClientesGuia_Envio() = True Then
        '    '  SendKeys.Send("{Tab}")
        'End If
        '    ElseIf Me.dtGridViewBultos.Focused = True Then
        'Sin mensages
        'MsgBox("Seguridad TAB")
        'Mod. 28/08/2009 -->Omendoza - Pasando al datahelper
        If objGuiaEnvio.fnCONTROL_GUIAS_ENVIO_DOC() = True Then
            'MsgBox("Datos...", MsgBoxStyle.Information, "Control")
            flag = True
            Me.TxtRuc.Text = objGuiaEnvio.sNU_DOCU_SUNAT.ToString
            Me.TxtRasonSocial.Text = objGuiaEnvio.sRASON_SOCIAL.ToString

            txtCliente_Remitente.Text = TxtRasonSocial.Text
            txtDocCliente_Remitente.Text = TxtRuc.Text

            lbTipoFacturacion.Text = objGuiaEnvio.iIDTipoFacturacion.ToString
            If objGuiaEnvio.iIDTipoFacturacion = 3 Then
                chechCargo.Checked = True
            Else
                chechCargo.Checked = False
            End If
            '
            '02/09/2009 - Cambiando por datahelper 
            'Me.txtFechaGuia.Text = objGuiaEnvio.sFECHA_GUIA.ToString
            'If objGuiaEnvio.cur_Sub_Cuenta.EOF = False And objGuiaEnvio.cur_Sub_Cuenta.BOF = False Then
            '    '02/09/2009 - Cambio por dastahelper 
            '    'ModuUtil.LlenarComboIDs(objGuiaEnvio.cur_Sub_Cuenta, cmbSubCuenta, objGuiaEnvio.coll_Sub_Cuenta, objGuiaEnvio.iIDCENTRO_COSTO)
            '    ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_cur_Sub_Cuenta, cmbSubCuenta, objGuiaEnvio.coll_Sub_Cuenta, objGuiaEnvio.iIDCENTRO_COSTO)
            '    cmbSubCuenta.SelectedIndex = 0
            'End If
            '
            If objGuiaEnvio.dt_cur_Sub_Cuenta.Rows.Count > 0 Then
                '02/09/2009 - Cambio por dastahelper 
                'ModuUtil.LlenarComboIDs(objGuiaEnvio.cur_Sub_Cuenta, cmbSubCuenta, objGuiaEnvio.coll_Sub_Cuenta, objGuiaEnvio.iIDCENTRO_COSTO)
                ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_cur_Sub_Cuenta, cmbSubCuenta, objGuiaEnvio.coll_Sub_Cuenta, objGuiaEnvio.iIDCENTRO_COSTO)
                cmbSubCuenta.SelectedIndex = 0
            End If

            '//CONTACTO REMITENTE
            '01/09/2009 - Cambio por datahelper 
            '
            'If objGuiaEnvio.cur_Nombres_Remitente.BOF = False And objGuiaEnvio.cur_Nombres_Remitente.EOF = False Then
            '    objGuiaEnvio.iIDCONTACTO_PERSONA = Int(objGuiaEnvio.cur_Nombres_Remitente.Fields.Item(0).Value.ToString)
            '    txtRemitente.Text = objGuiaEnvio.cur_Nombres_Remitente.Fields.Item(1).Value.ToString
            '    txtDNIRemitente.Text = objGuiaEnvio.cur_Nombres_Remitente.Fields.Item(2).Value.ToString
            '    'fnCargar_iWin(txtRemitente, objGuiaEnvio.cur_Nombres_Remitente, objGuiaEnvio.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA)
            '    fnCargar_iWin2(txtRemitente, objGuiaEnvio.cur_Nombres_Remitente, objGuiaEnvio.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA, iWinPerosaDNI_Remite)
            'Else
            '    objGuiaEnvio.iIDCONTACTO_PERSONA = -1
            '    txtRemitente.Text = ""
            '    Me.txtDNIRemitente.Text = ""
            'End If

            If objGuiaEnvio.dt_cur_Nombres_Remitente.Rows.Count > 0 Then
                objGuiaEnvio.iIDCONTACTO_PERSONA = Int(objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(0).ToString)
                txtRemitente.Text = objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(1).ToString
                txtDNIRemitente.Text = objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(2).ToString
                'fnCargar_iWin(txtRemitente, objGuiaEnvio.cur_Nombres_Remitente, objGuiaEnvio.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA)
                'fnCargar_iWin2(txtRemitente, objGuiaEnvio.dt_cur_Nombres_Remitente, objGuiaEnvio.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA, iWinPerosaDNI_Remite)
            Else
                objGuiaEnvio.iIDCONTACTO_PERSONA = -1
                txtRemitente.Text = ""
                Me.txtDNIRemitente.Text = ""
            End If
            fnCargar_iWin2(txtRemitente, objGuiaEnvio.dt_cur_Nombres_Remitente, objGuiaEnvio.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA, iWinPerosaDNI_Remite)

            '//CONTACTO DIRECCIONES
            '02/09/2009 - Cambio por datahelper 
            'If objGuiaEnvio.cur_Direccion_Remitente.BOF = False And objGuiaEnvio.cur_Direccion_Remitente.EOF = False Then
            '    objGuiaEnvio.iIDDIRECCION_REMITENTE = Int(objGuiaEnvio.cur_Direccion_Remitente.Fields.Item(0).Value.ToString)
            '    txtDireccionRemitente.Text = objGuiaEnvio.cur_Direccion_Remitente.Fields.Item(1).Value.ToString
            '    'fnCargar_iWin(txtDireccionRemitente, objGuiaEnvio.cur_Direccion_Remitente, objGuiaEnvio.coll_Direccion_Remitente, iWinDireccion_Remitente, objGuiaEnvio.iIDDIRECCION_REMITENTE)
            '    fnCargar_iWin(txtDireccionRemitente, objGuiaEnvio.cur_Direccion_Remitente, objGuiaEnvio.coll_Direccion_Remitente, iWinDireccion_Remitente, objGuiaEnvio.iIDDIRECCION_REMITENTE)
            'Else
            '    txtDireccionRemitente.Text = ""
            '    objGuiaEnvio.iIDDIRECCION_REMITENTE = -1
            'End If
            If objGuiaEnvio.dt_cur_Direccion_Remitente.Rows.Count > 0 Then
                objGuiaEnvio.iIDDIRECCION_REMITENTE = Int(objGuiaEnvio.dt_cur_Direccion_Remitente.Rows(0).Item(0).ToString)
                txtDireccionRemitente.Text = objGuiaEnvio.dt_cur_Direccion_Remitente.Rows(0).Item(1).ToString
                'fnCargar_iWin_dt(txtDireccionRemitente, objGuiaEnvio.dt_cur_Direccion_Remitente, objGuiaEnvio.coll_Direccion_Remitente, iWinDireccion_Remitente, objGuiaEnvio.iIDDIRECCION_REMITENTE)
            Else
                txtDireccionRemitente.Text = ""
                objGuiaEnvio.iIDDIRECCION_REMITENTE = -1
            End If
            fnCargar_iWin_dt(txtDireccionRemitente, objGuiaEnvio.dt_cur_Direccion_Remitente, objGuiaEnvio.coll_Direccion_Remitente, iWinDireccion_Remitente, objGuiaEnvio.iIDDIRECCION_REMITENTE)

            '//CONTACTO TELEFONOS
            'If objGuiaEnvio.cur_Telefono_Remitente.BOF = False And objGuiaEnvio.cur_Telefono_Remitente.EOF = False Then
            '    objGuiaEnvio.iIDTEFONO_REMITENTE = Int(objGuiaEnvio.cur_Telefono_Remitente.Fields.Item(0).Value.ToString)
            '    txtTelefonoRemitente.Text = objGuiaEnvio.cur_Telefono_Remitente.Fields.Item(1).Value.ToString
            '    fnCargar_iWin(txtTelefonoRemitente, objGuiaEnvio.cur_Telefono_Remitente, objGuiaEnvio.coll_Telefono_Remitente, iWinTelefono_Remitente, objGuiaEnvio.iIDTEFONO_REMITENTE)
            'Else
            '    Me.txtTelefonoRemitente.Text = ""
            '    objGuiaEnvio.iIDTEFONO_REMITENTE = -1
            'End If

            Me.txtTelefonoRemitente.Text = ""
            objGuiaEnvio.iIDTEFONO_REMITENTE = -1

            '//DESTINATARIO DESTINATARIO
            'If objGuiaEnvio.cur_Nombres_Destinatario.BOF = False And objGuiaEnvio.cur_Nombres_Destinatario.EOF = False Then
            '    objGuiaEnvio.iIDCONTACTO_DESTINATARIO = Int(objGuiaEnvio.cur_Nombres_Destinatario.Fields.Item(0).Value.ToString)
            '    txtDestinatario.Text = objGuiaEnvio.cur_Nombres_Destinatario.Fields.Item(1).Value.ToString
            '    txtDNIDestinatario.Text = objGuiaEnvio.cur_Nombres_Destinatario.Fields.Item(2).Value.ToString
            '    'fnCargar_iWin(txtDestinatario, objGuiaEnvio.cur_Nombres_Destinatario, objGuiaEnvio.coll_Nombres_Destinatario, iWinContacto_Destinatario, objGuiaEnvio.iIDCONTACTO_DESTINATARIO)
            '    fnCargar_iWin2(txtDestinatario, objGuiaEnvio.cur_Nombres_Destinatario, objGuiaEnvio.coll_Nombres_Destinatario, iWinContacto_Destinatario, objGuiaEnvio.iIDCONTACTO_DESTINATARIO, iWinPerosaDNI_Destino)
            'Else
            '    objGuiaEnvio.iIDCONTACTO_DESTINATARIO = -1
            '    txtDestinatario.Text = ""
            '    txtDNIDestinatario.Text = ""
            'End If
            '//DESTINATARIO DESTINATARIO - 03/09/2009 - Mod. por datahelper 
            If objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows.Count > 0 Then
                objGuiaEnvio.iIDCONTACTO_DESTINATARIO = Int(objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(0).ToString)
                txtDestinatario.Text = objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(1).ToString
                txtDNIDestinatario.Text = objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(2).ToString
                'fnCargar_iWin2(txtDestinatario, objGuiaEnvio.dt_cur_Nombres_Destinatario, objGuiaEnvio.coll_Nombres_Destinatario, iWinContacto_Destinatario, objGuiaEnvio.iIDCONTACTO_DESTINATARIO, iWinPerosaDNI_Destino)
            Else
                objGuiaEnvio.iIDCONTACTO_DESTINATARIO = -1
                txtDestinatario.Text = ""
                txtDNIDestinatario.Text = ""
            End If
            fnCargar_iWin2(txtDestinatario, objGuiaEnvio.dt_cur_Nombres_Destinatario, objGuiaEnvio.coll_Nombres_Destinatario, iWinContacto_Destinatario, objGuiaEnvio.iIDCONTACTO_DESTINATARIO, iWinPerosaDNI_Destino)
            'ModuUtil.LlenarComboIDs(objGuiaEnvio.rst_Lista_Tipo_Entrega, cmbTipo_Entrega, objGuiaEnvio.coll_Lista_Tipo_Entrega, 1)
            '1 Agencia
            '2 Domicilio
            Dim idTipoDire As Integer = Int(objGuiaEnvio.coll_Lista_Tipo_Entrega.Item(cmbTipo_Entrega.SelectedIndex.ToString))
            '
            If idTipoDire = 2 Then
                '
                '03/09/2009 - Modificado por datahelper  
                '
                'If objGuiaEnvio.cur_Direccion_Destinatario.BOF = False And objGuiaEnvio.cur_Direccion_Destinatario.EOF = False Then
                '    objGuiaEnvio.iIDDIRECCION_DESTINATARIO = Int(objGuiaEnvio.cur_Direccion_Destinatario.Fields.Item(0).Value.ToString)
                '    txtDireccionDestinatario.Text = objGuiaEnvio.cur_Direccion_Destinatario.Fields.Item(1).Value.ToString
                '    fnCargar_iWin(Me.txtDireccionDestinatario, objGuiaEnvio.cur_Direccion_Destinatario, objGuiaEnvio.coll_Direccion_Destinatario, iWinDireccion_Destinatario, objGuiaEnvio.iIDDIRECCION_DESTINATARIO)
                'Else
                '    objGuiaEnvio.iIDDIRECCION_DESTINATARIO = -1
                '    txtDireccionDestinatario.Text = ""
                'End If
                '
                If objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows.Count > 0 Then
                    objGuiaEnvio.iIDDIRECCION_DESTINATARIO = Int(objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows(0).Item(0).ToString)
                    txtDireccionDestinatario.Text = objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows(0).Item(1).ToString
                Else
                    objGuiaEnvio.iIDDIRECCION_DESTINATARIO = -1
                    txtDireccionDestinatario.Text = ""
                End If
                fnCargar_iWin_dt(Me.txtDireccionDestinatario, objGuiaEnvio.dt_cur_Direccion_Destinatario, objGuiaEnvio.coll_Direccion_Destinatario, iWinDireccion_Destinatario, objGuiaEnvio.iIDDIRECCION_DESTINATARIO)
            End If
            '
            txtTelefonoDestinatario.Text = ""
            objGuiaEnvio.iIDTEFONO_CONSIGNADO = -1

            Dim i As Integer = 0
            For i = 1 To dtGridViewArticulo.Rows().Count
                dtGridViewArticulo.Rows().RemoveAt(0)
            Next

            txtSubTotal.Text = "0.00"
            txMontotIGV.Text = "0.00"
            txtTotal_Pago.Text = "0.00"

            For i = 0 To 2
                dtGridViewBultos(2, i).Value() = ""
                dtGridViewBultos(3, i).Value() = ""
                dtGridViewBultos(4, i).Value() = "0.00"
            Next


            'If objGuiaEnvio.rst_Articulos.State = 1 Then
            '    While objGuiaEnvio.rst_Articulos.BOF = False And objGuiaEnvio.rst_Articulos.EOF = False
            '        Dim row0 As String() = {Int(objGuiaEnvio.rst_Articulos.Fields.Item(0).Value).ToString, _
            '        objGuiaEnvio.rst_Articulos.Fields.Item(1).Value, _
            '        objGuiaEnvio.rst_Articulos.Fields.Item(2).Value.ToString, _
            '        "", _
            '        "", _
            '        "", _
            '        "0.00"}
            '        dtGridViewArticulo.Rows().Add(row0)
            '        objGuiaEnvio.rst_Articulos.MoveNext()
            '    End While
            'End If

            '03/09/2009 - por datahelper 
            If objGuiaEnvio.dt_rst_Articulos.Rows.Count > 0 Then
                For Each row As DataRow In objGuiaEnvio.dt_rst_Articulos.Rows
                    Dim row0 As String() = {Int(row.Item(0)).ToString, _
                    row.Item(1), _
                    row.Item(2).ToString, _
                    "", _
                    "", _
                    "", _
                    "0.00"}
                    dtGridViewArticulo.Rows().Add(row0)
                Next
            End If
        Else
            Call ClearData()
            ' MsgBox("GUIA NO ASIGNADAS A NINGUN CLIENTE... ", MsgBoxStyle.Information, "Seguridad Sistema")
            flag = False
        End If
        ' objGuiaEnvio.iCONTROL = 1
SALIR:
        '03/09/2009 - Modificado por datahelper 
        'Catch ex As Exception
        '    MsgBox("Error Interno...Verificar Datos", MsgBoxStyle.Information, "Seguridad Sistema")
        '    flag = False
        '    'objGuiaEnvio.iCONTROL = 1
        'End Try
        Return flag
    End Function
    Private Sub llenar_collections()
        Dim flag As Boolean = False
        'Mod. 22/08/2009 -->Omendoza - Pasando al datahelper   
        If objGuiaEnvio.fnCONTROL_GUIAS_ENVIO_DOC_CC() = True Then


            flag = True
            Me.TxtRuc.Text = objGuiaEnvio.sNU_DOCU_SUNAT.ToString
            Me.TxtRasonSocial.Text = objGuiaEnvio.sRASON_SOCIAL.ToString

            txtCliente_Remitente.Text = TxtRasonSocial.Text
            txtDocCliente_Remitente.Text = TxtRuc.Text

            lbTipoFacturacion.Text = objGuiaEnvio.iIDTipoFacturacion.ToString

            'modificado por ritcher gomez recuperara lo que realmente esta en la base de datos
            'If objGuiaEnvio.iIDTipoFacturacion = 3 Then
            '    chechCargo.Checked = True
            'Else
            '    chechCargo.Checked = False
            'End If

            If objGuiaEnvio.iCARGO = 1 Then
                chechCargo.Checked = True
            Else
                chechCargo.Checked = False
            End If



            'Me.txtFechaGuia.Text = objGuiaEnvio.sFECHA_GUIA.ToString
            If mostrar_pre_guias = True Then
                '
                'Mod. 07/09/2009 - por data helper 
                '
                'If objGuiaEnvio.cur_Sub_Cuenta.EOF = False And objGuiaEnvio.cur_Sub_Cuenta.BOF = False Then
                '    ModuUtil.LlenarComboIDs(objGuiaEnvio.cur_Sub_Cuenta, cmbSubCuenta, objGuiaEnvio.coll_Sub_Cuenta, objGuiaEnvio.iIDCENTRO_COSTO)
                '    cmbSubCuenta.SelectedIndex = 0
                'End If
                If objGuiaEnvio.dt_cur_Sub_Cuenta.Rows.Count > 0 Then
                    ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_cur_Sub_Cuenta, cmbSubCuenta, objGuiaEnvio.coll_Sub_Cuenta, objGuiaEnvio.iIDCENTRO_COSTO)
                    cmbSubCuenta.SelectedIndex = 0
                End If
            End If
            '//CONTACTO REMITENTE
            '07/09/2009 - Mod. por Data Helper 
            'If objGuiaEnvio.cur_Nombres_Remitente.BOF = False And objGuiaEnvio.cur_Nombres_Remitente.EOF = False Then
            '    objGuiaEnvio.iIDCONTACTO_PERSONA = Int(objGuiaEnvio.cur_Nombres_Remitente.Fields.Item(0).Value.ToString)
            '    txtRemitente.Text = objGuiaEnvio.cur_Nombres_Remitente.Fields.Item(1).Value.ToString
            '    txtDNIRemitente.Text = objGuiaEnvio.cur_Nombres_Remitente.Fields.Item(2).Value.ToString
            '    'fnCargar_iWin(txtRemitente, objGuiaEnvio.cur_Nombres_Remitente, objGuiaEnvio.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA)
            '    fnCargar_iWin2(txtRemitente, objGuiaEnvio.cur_Nombres_Remitente, objGuiaEnvio.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA, iWinPerosaDNI_Remite)
            'Else
            '    objGuiaEnvio.iIDCONTACTO_PERSONA = -1
            '    txtRemitente.Text = ""
            '    Me.txtDNIRemitente.Text = ""
            'End If

            If objGuiaEnvio.dt_cur_Nombres_Remitente.Rows.Count > 0 Then
                objGuiaEnvio.iIDCONTACTO_PERSONA = Int(objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(0).ToString)
                txtRemitente.Text = objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(1).ToString
                txtDNIRemitente.Text = objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(2).ToString
                '07/09/2009 - Cambiado por datahelper 
                'fnCargar_iWin(txtRemitente, objGuiaEnvio.cur_Nombres_Remitente, objGuiaEnvio.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA)
                fnCargar_iWin2(txtRemitente, objGuiaEnvio.dt_cur_Nombres_Remitente, objGuiaEnvio.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA, iWinPerosaDNI_Remite)
            Else
                objGuiaEnvio.iIDCONTACTO_PERSONA = -1
                txtRemitente.Text = ""
                Me.txtDNIRemitente.Text = ""
            End If
            '//CONTACTO DIRECCIONES
            '
            ' Mod. 07/09/2009 x datahelper 
            '
            'If objGuiaEnvio.cur_Direccion_Remitente.BOF = False And objGuiaEnvio.cur_Direccion_Remitente.EOF = False Then
            '    objGuiaEnvio.iIDDIRECCION_REMITENTE = Int(objGuiaEnvio.cur_Direccion_Remitente.Fields.Item(0).Value.ToString)
            '    txtDireccionRemitente.Text = objGuiaEnvio.cur_Direccion_Remitente.Fields.Item(1).Value.ToString
            '    'fnCargar_iWin(txtDireccionRemitente, objGuiaEnvio.cur_Direccion_Remitente, objGuiaEnvio.coll_Direccion_Remitente, iWinDireccion_Remitente, objGuiaEnvio.iIDDIRECCION_REMITENTE)
            '    fnCargar_iWin(txtDireccionRemitente, objGuiaEnvio.cur_Direccion_Remitente, objGuiaEnvio.coll_Direccion_Remitente, iWinDireccion_Remitente, objGuiaEnvio.iIDDIRECCION_REMITENTE)
            'Else
            '    txtDireccionRemitente.Text = ""
            '    objGuiaEnvio.iIDDIRECCION_REMITENTE = -1
            'End If
            '
            If objGuiaEnvio.dt_cur_Direccion_Remitente.Rows.Count > 0 Then
                objGuiaEnvio.iIDDIRECCION_REMITENTE = Int(objGuiaEnvio.dt_cur_Direccion_Remitente.Rows(0).Item(0).ToString)
                txtDireccionRemitente.Text = objGuiaEnvio.dt_cur_Direccion_Remitente.Rows(0).Item(1).ToString
                fnCargar_iWin_dt(txtDireccionRemitente, objGuiaEnvio.dt_cur_Direccion_Remitente, objGuiaEnvio.coll_Direccion_Remitente, iWinDireccion_Remitente, objGuiaEnvio.iIDDIRECCION_REMITENTE)
            Else
                txtDireccionRemitente.Text = ""
                objGuiaEnvio.iIDDIRECCION_REMITENTE = -1
            End If

            '//CONTACTO TELEFONOS
            'If objGuiaEnvio.cur_Telefono_Remitente.BOF = False And objGuiaEnvio.cur_Telefono_Remitente.EOF = False Then
            '    objGuiaEnvio.iIDTEFONO_REMITENTE = Int(objGuiaEnvio.cur_Telefono_Remitente.Fields.Item(0).Value.ToString)
            '    txtTelefonoRemitente.Text = objGuiaEnvio.cur_Telefono_Remitente.Fields.Item(1).Value.ToString
            '    fnCargar_iWin(txtTelefonoRemitente, objGuiaEnvio.cur_Telefono_Remitente, objGuiaEnvio.coll_Telefono_Remitente, iWinTelefono_Remitente, objGuiaEnvio.iIDTEFONO_REMITENTE)
            'Else
            '    Me.txtTelefonoRemitente.Text = ""
            '    objGuiaEnvio.iIDTEFONO_REMITENTE = -1
            'End If

            Me.txtTelefonoRemitente.Text = ""
            objGuiaEnvio.iIDTEFONO_REMITENTE = -1

            '//DESTINATARIO DESTINATARIO
            'Mod. por datahelper 07/09/2009
            'If objGuiaEnvio.cur_Nombres_Destinatario.BOF = False And objGuiaEnvio.cur_Nombres_Destinatario.EOF = False Then
            '    objGuiaEnvio.iIDCONTACTO_DESTINATARIO = Int(objGuiaEnvio.cur_Nombres_Destinatario.Fields.Item(0).Value.ToString)
            '    txtDestinatario.Text = objGuiaEnvio.cur_Nombres_Destinatario.Fields.Item(1).Value.ToString
            '    txtDNIDestinatario.Text = objGuiaEnvio.cur_Nombres_Destinatario.Fields.Item(2).Value.ToString
            '    'fnCargar_iWin(txtDestinatario, objGuiaEnvio.cur_Nombres_Destinatario, objGuiaEnvio.coll_Nombres_Destinatario, iWinContacto_Destinatario, objGuiaEnvio.iIDCONTACTO_DESTINATARIO)
            '    fnCargar_iWin2(txtDestinatario, objGuiaEnvio.cur_Nombres_Destinatario, objGuiaEnvio.coll_Nombres_Destinatario, iWinContacto_Destinatario, objGuiaEnvio.iIDCONTACTO_DESTINATARIO, iWinPerosaDNI_Destino)
            'Else
            '    objGuiaEnvio.iIDCONTACTO_DESTINATARIO = -1
            '    txtDestinatario.Text = ""
            '    txtDNIDestinatario.Text = ""
            'End If

            If objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows.Count > 1 Then
                objGuiaEnvio.iIDCONTACTO_DESTINATARIO = Int(objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(0).ToString)
                txtDestinatario.Text = objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(1).ToString
                txtDNIDestinatario.Text = objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(2).ToString
                fnCargar_iWin2(txtDestinatario, objGuiaEnvio.dt_cur_Nombres_Destinatario, objGuiaEnvio.coll_Nombres_Destinatario, iWinContacto_Destinatario, objGuiaEnvio.iIDCONTACTO_DESTINATARIO, iWinPerosaDNI_Destino)
            Else
                objGuiaEnvio.iIDCONTACTO_DESTINATARIO = -1
                txtDestinatario.Text = ""
                txtDNIDestinatario.Text = ""
            End If

            'ModuUtil.LlenarComboIDs(objGuiaEnvio.rst_Lista_Tipo_Entrega, cmbTipo_Entrega, objGuiaEnvio.coll_Lista_Tipo_Entrega, 1)
            '1 Agencia
            '2 Domicilio

            Dim idTipoDire As Integer = Int(objGuiaEnvio.coll_Lista_Tipo_Entrega.Item(cmbTipo_Entrega.SelectedIndex.ToString))
            If idTipoDire = 2 Then
                'If objGuiaEnvio.cur_Direccion_Destinatario.BOF = False And objGuiaEnvio.cur_Direccion_Destinatario.EOF = False Then
                '    objGuiaEnvio.iIDDIRECCION_DESTINATARIO = Int(objGuiaEnvio.cur_Direccion_Destinatario.Fields.Item(0).Value.ToString)
                '    txtDireccionDestinatario.Text = objGuiaEnvio.cur_Direccion_Destinatario.Fields.Item(1).Value.ToString
                '    fnCargar_iWin(Me.txtDireccionDestinatario, objGuiaEnvio.cur_Direccion_Destinatario, objGuiaEnvio.coll_Direccion_Destinatario, iWinDireccion_Destinatario, objGuiaEnvio.iIDDIRECCION_DESTINATARIO)
                'Else
                '    objGuiaEnvio.iIDDIRECCION_DESTINATARIO = -1
                '    txtDireccionDestinatario.Text = ""
                'End If
                If objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows.Count > 0 Then
                    objGuiaEnvio.iIDDIRECCION_DESTINATARIO = Int(objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows(0).Item(0).ToString)
                    txtDireccionDestinatario.Text = objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows(0).Item(1).ToString
                    '
                    fnCargar_iWin_dt(Me.txtDireccionDestinatario, objGuiaEnvio.dt_cur_Direccion_Destinatario, objGuiaEnvio.coll_Direccion_Destinatario, iWinDireccion_Destinatario, objGuiaEnvio.iIDDIRECCION_DESTINATARIO)
                Else
                    objGuiaEnvio.iIDDIRECCION_DESTINATARIO = -1
                    txtDireccionDestinatario.Text = ""
                End If
            End If
            '
            txtTelefonoDestinatario.Text = ""
            objGuiaEnvio.iIDTEFONO_CONSIGNADO = -1

            Dim i As Integer = 0
            For i = 1 To dtGridViewArticulo.Rows().Count
                dtGridViewArticulo.Rows().RemoveAt(0)
            Next

            txtSubTotal.Text = "0.00"
            txMontotIGV.Text = "0.00"
            txtTotal_Pago.Text = "0.00"

            For i = 0 To 2
                dtGridViewBultos(2, i).Value() = ""
                dtGridViewBultos(3, i).Value() = ""
                dtGridViewBultos(4, i).Value() = "0.00"
            Next

            'If objGuiaEnvio.rst_Articulos.State = 1 Then
            '    While objGuiaEnvio.rst_Articulos.BOF = False And objGuiaEnvio.rst_Articulos.EOF = False
            '        Dim row0 As String() = {Int(objGuiaEnvio.rst_Articulos.Fields.Item(0).Value).ToString, _
            '        objGuiaEnvio.rst_Articulos.Fields.Item(1).Value, _
            '        objGuiaEnvio.rst_Articulos.Fields.Item(2).Value.ToString, _
            '        "", _
            '        "", _
            '        "", _
            '        "0.00"}
            '        '
            '        dtGridViewArticulo.Rows().Add(row0)
            '        objGuiaEnvio.rst_Articulos.MoveNext()
            '    End While
            'End If            

            If objGuiaEnvio.dt_rst_Articulos.Rows.Count > 0 Then
                For Each row As DataRow In objGuiaEnvio.dt_rst_Articulos.Rows
                    Dim row0 As String() = {Int(row.Item(0)).ToString, _
                    row.Item(1), _
                    row.Item(2).ToString, _
                    "", _
                    "", _
                    "", _
                    "0.00"}
                    '
                    dtGridViewArticulo.Rows().Add(row0)
                Next
            End If

        Else
            Call ClearData()
            ' MsgBox("GUIA NO ASIGNADAS A NINGUN CLIENTE... ", MsgBoxStyle.Information, "Seguridad Sistema")
            flag = False
        End If
    End Sub
    Private Function BuscarGuia_Envio_X_CLIENTES() As Boolean
        Dim flag As Boolean = False
        Try
            If CONTROL = 4 Then
                CONTROL = 1
            End If

            'objLOG.fnLog("[ENTER] :" & TxtRasonSocial.Text.ToString)
            'Mod. 24/08/2009 -->Omendoza - Pasando al datahelper   
            If objGuiaEnvio.fnControlGuiasImpresas(TxtGuiaEnvio.Text) = False Then
                txtiWinDestino.Focus()
                txtiWinDestino.SelectAll()
                GoTo SALIR
            End If
            txtiWinOrigen.Text = objGuiaEnvio.iNOMBRE_UNIDAD_ORIGEN
            txtiWinDestino.Text = objGuiaEnvio.iNOMBRE_UNIDAD_DESTINO
            TxtRuc.Text = objGuiaEnvio.sNU_DOCU_SUNAT
            TxtRasonSocial.Text = objGuiaEnvio.sRASON_SOCIAL
            ' fnCargar_iWin(Me.TxtRasonSocial, objGuiaEnvio.rst_Lista_Personas, coll_Lista_Personas, iWinPerosa, 0)
            'iWinPerosa()
            CONTROL = 2
            Dim indexof As Integer = 0
            If iWinPerosa.Count > 0 Then
                'indexof = IIf(iWinContacto_Remitente.IndexOf(txtRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtRemitente.Text), -1)
                'indexof = IIf(iWinPerosa.IndexOf(TxtRasonSocial.Text) >= 0, iWinPerosa.IndexOf(TxtRasonSocial.Text), -1)
                ' objGuiaEnvio.iIDPERSONA = -1
                If indexof >= 0 Then
                    '  objGuiaEnvio.iIDPERSONA = Int(coll_Lista_Personas(indexof.ToString))
                    objGuiaEnvio.iCONTROLIdpersona = objGuiaEnvio.iIDPERSONA
                    If indexof <= iWinPerosaRUC.Count Then
                        ' Me.TxtRuc.Text = iWinPerosaRUC.Item(indexof)
                        ' TxtRasonSocial.Text=
                        txtCliente_Remitente.Text = TxtRasonSocial.Text
                        txtDocCliente_Remitente.Text = Me.TxtRuc.Text
                        objGuiaEnvio.iID_REMITENTE = objGuiaEnvio.iIDPERSONA
                        objGuiaEnvio.iREMITENTE = TxtRasonSocial.Text
                        objGuiaEnvio.iNRODOC_REM = Me.TxtRuc.Text
                        bControl_Busqueda = True
                        ' fnTarifario()
                        'Modificado el 12/08/2008
                        limpia_monto_x_cambio()
                        '
                        If fb_buscar_cliente() = True Then
                            txtCliente_Remitente.Focus()
                            txtCliente_Remitente.SelectAll()
                        End If
                        '
                        'If BuscarClientesGuia_Envio() = True Then
                        '    '    txtDestinatario.Focus()
                        '    '    txtDestinatario.SelectAll()
                        '    '    'SendKeys.Send("{Tab}")
                        '    '    fnTarifario()
                        'End If
                        '
                    End If
                Else
                    MsgBox("El Cliente no tiene línea de crédito, revise sus datos", MsgBoxStyle.Information, "Seguridad Sistema")
                End If
            End If

            'If BuscarClientesGuia_Envio() = True Then
            '    txtCliente_Remitente.Focus()
            '    txtCliente_Remitente.SelectAll()
            '    'SendKeys.Send("{Tab}")
            '    fnTarifario()
            'End If
            'If objGuiaEnvio.iCONTROL <> 2 Then
            '    objGuiaEnvio.iCONTROL = CONTROL
            'End If

            objGuiaEnvio.iControl_Busqueda = CONTROL
            If CONTROL <> 2 Then
                objGuiaEnvio.iIDPERSONA = 0
            End If

            TxtGuiaEnvio.Text = RellenoRight(NroDigitos_Guias, TxtGuiaEnvio.Text)

            If txtiWinOrigen.Text <> "" And txtiWinDestino.Text <> "" Then
                objGuiaEnvio.iIDUNIDAD_AGENCIA = Int(coll_iOrigen.Item(iWinOrigen.IndexOf(txtiWinOrigen.Text.ToString()) + 1).ToString())
                objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = Int(coll_iDestino.Item(iWinDestino.IndexOf(txtiWinDestino.Text.ToString()) + 1).ToString())
            Else
                'MsgBox("No ha definido el Destino De envio...", MsgBoxStyle.Information, "Seguridad Sistemas")
                objGuiaEnvio.iIDUNIDAD_AGENCIA = 999
                objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = 999
            End If

            If objGuiaEnvio.iIDUNIDAD_AGENCIA = objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO Then
                'MsgBox("No Existen Tarifas Para Una Ruta Igual..,Verifique sus Datos", MsgBoxStyle.Information, "Seguridad Sistema")
                GoTo SALIR
            End If
            If Me.TxtGuiaEnvio.Text <> "" And TxtGuiaEnvio.Text.Length() > 0 And bControl_Busqueda = False Then
                'objGuiaEnvio.iCONTROL = 1
                objGuiaEnvio.sNRO_GUIA = TxtGuiaEnvio.Text
            Else
                objGuiaEnvio.sNRO_GUIA = "@"
            End If

            'If objGuiaEnvio.fnControlGuiasImpresas(TxtGuiaEnvio.Text) = False Then
            '    txtiWinDestino.Focus()
            '    txtiWinDestino.SelectAll()
            '    GoTo SALIR
            'End If
            'txtiWinOrigen.Text = objGuiaEnvio.iNOMBRE_UNIDAD_ORIGEN
            'txtiWinDestino.Text = objGuiaEnvio.iNOMBRE_UNIDAD_DESTINO
            'TxtRuc.Text = objGuiaEnvio.sNU_DOCU_SUNAT

            'fnCargar_iWin2(Me.TxtRasonSocial, objGuiaEnvio.rst_Lista_Personas, coll_Lista_Personas, iWinPerosa, 0, iWinPerosaRUC)                    
            'CONTROL = 2
            'Dim indexof As Integer = 0
            'If iWinPerosa.Count > 0 Then
            '    'indexof = IIf(iWinContacto_Remitente.IndexOf(txtRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtRemitente.Text), -1)
            '    indexof = iWinPerosaRUC.IndexOf(TxtRuc.Text)
            '    objGuiaEnvio.iIDPERSONA = -1
            '    If indexof >= 0 Then
            '        objGuiaEnvio.iIDPERSONA = Int(coll_Lista_Personas(indexof.ToString))
            '        objGuiaEnvio.iCONTROLIdpersona = objGuiaEnvio.iIDPERSONA
            '        If indexof <= iWinPerosa.Count Then
            '            Me.TxtRasonSocial.Text = iWinPerosa.Item(indexof)
            '            objGuiaEnvio.iID_REMITENTE = objGuiaEnvio.iIDPERSONA
            '            objGuiaEnvio.iREMITENTE = TxtRasonSocial.Text
            '            objGuiaEnvio.iNRODOC_REM = Me.TxtRuc.Text
            '            bControl_Busqueda = True
            '        End If
            '    Else
            '        MsgBox("El Nombre del Cliente No Tiene Linea de Credito, Revice sus datos", MsgBoxStyle.Information, "Seguridad Sistema")
            '    End If
            'End If
            'If BuscarClientesGuia_Envio() = True Then
            '    '  SendKeys.Send("{Tab}")
            'End If
            '    ElseIf Me.dtGridViewBultos.Focused = True Then
            'Sin mensages
            'MsgBox("Seguridad TAB")            
            'Mod. 28/08/2009 -->Omendoza - Pasando al datahelper
            If objGuiaEnvio.fnCONTROL_GUIAS_ENVIO_DOC() = True Then
                'MsgBox("Datos...", MsgBoxStyle.Information, "Control")
                flag = True
                Me.TxtRuc.Text = objGuiaEnvio.sNU_DOCU_SUNAT.ToString
                Me.TxtRasonSocial.Text = objGuiaEnvio.sRASON_SOCIAL.ToString

                txtCliente_Remitente.Text = TxtRasonSocial.Text
                txtDocCliente_Remitente.Text = TxtRuc.Text
                'Me.txtFechaGuia.Text = objGuiaEnvio.sFECHA_GUIA.ToString
                'If objGuiaEnvio.cur_Sub_Cuenta.EOF = False And objGuiaEnvio.cur_Sub_Cuenta.BOF = False Then
                If objGuiaEnvio.dt_cur_Sub_Cuenta.Rows.Count > 0 Then
                    ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_cur_Sub_Cuenta, cmbSubCuenta, objGuiaEnvio.coll_Sub_Cuenta, objGuiaEnvio.iIDCENTRO_COSTO)
                    'cmbSubCuenta.SelectedIndex = 0
                End If
                '//CONTACTO REMITENTE
                'If objGuiaEnvio.cur_Nombres_Remitente.BOF = False And objGuiaEnvio.cur_Nombres_Remitente.EOF = False Then
                If objGuiaEnvio.dt_cur_Nombres_Remitente.Rows.Count > 0 Then
                    objGuiaEnvio.iIDCONTACTO_PERSONA = Int(objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(0).ToString)
                    txtRemitente.Text = objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(1).ToString
                    txtDNIRemitente.Text = objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(2).ToString
                    'fnCargar_iWin(txtRemitente, objGuiaEnvio.cur_Nombres_Remitente, objGuiaEnvio.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA)
                    fnCargar_iWin2_dt2(txtRemitente, objGuiaEnvio.dt_cur_Nombres_Remitente, objGuiaEnvio.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA, iWinPerosaDNI_Remite)
                Else
                    objGuiaEnvio.iIDCONTACTO_PERSONA = -1
                    txtRemitente.Text = ""
                    Me.txtDNIRemitente.Text = ""
                End If
                '//CONTACTO DIRECCIONES
                'If objGuiaEnvio.cur_Direccion_Remitente.BOF = False And objGuiaEnvio.cur_Direccion_Remitente.EOF = False Then
                If objGuiaEnvio.dt_cur_Direccion_Remitente.Rows.Count > 0 Then
                    objGuiaEnvio.iIDDIRECCION_REMITENTE = Int(objGuiaEnvio.dt_cur_Direccion_Remitente.Rows(0).Item(0).ToString)
                    txtDireccionRemitente.Text = objGuiaEnvio.dt_cur_Direccion_Remitente.Rows(0).Item(1).ToString
                    'fnCargar_iWin(txtDireccionRemitente, objGuiaEnvio.cur_Direccion_Remitente, objGuiaEnvio.coll_Direccion_Remitente, iWinDireccion_Remitente, objGuiaEnvio.iIDDIRECCION_REMITENTE)
                    fnCargar_iWin_dt(txtDireccionRemitente, objGuiaEnvio.dt_cur_Direccion_Remitente, objGuiaEnvio.coll_Direccion_Remitente, iWinDireccion_Remitente, objGuiaEnvio.iIDDIRECCION_REMITENTE)
                Else
                    txtDireccionRemitente.Text = ""
                    objGuiaEnvio.iIDDIRECCION_REMITENTE = -1
                End If

                '//CONTACTO TELEFONOS
                'If objGuiaEnvio.cur_Telefono_Remitente.BOF = False And objGuiaEnvio.cur_Telefono_Remitente.EOF = False Then
                '    objGuiaEnvio.iIDTEFONO_REMITENTE = Int(objGuiaEnvio.cur_Telefono_Remitente.Fields.Item(0).Value.ToString)
                '    txtTelefonoRemitente.Text = objGuiaEnvio.cur_Telefono_Remitente.Fields.Item(1).Value.ToString
                '    fnCargar_iWin(txtTelefonoRemitente, objGuiaEnvio.cur_Telefono_Remitente, objGuiaEnvio.coll_Telefono_Remitente, iWinTelefono_Remitente, objGuiaEnvio.iIDTEFONO_REMITENTE)
                'Else
                '    Me.txtTelefonoRemitente.Text = ""
                '    objGuiaEnvio.iIDTEFONO_REMITENTE = -1
                'End If

                Me.txtTelefonoRemitente.Text = ""
                objGuiaEnvio.iIDTEFONO_REMITENTE = -1

                '//DESTINATARIO DESTINATARIO
                'If objGuiaEnvio.cur_Nombres_Destinatario.BOF = False And objGuiaEnvio.cur_Nombres_Destinatario.EOF = False Then
                If objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows.Count > 0 Then
                    objGuiaEnvio.iIDCONTACTO_DESTINATARIO = Int(objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(0).ToString)
                    txtDestinatario.Text = objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(1).ToString
                    txtDNIDestinatario.Text = objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(2).ToString
                    'fnCargar_iWin(txtDestinatario, objGuiaEnvio.cur_Nombres_Destinatario, objGuiaEnvio.coll_Nombres_Destinatario, iWinContacto_Destinatario, objGuiaEnvio.iIDCONTACTO_DESTINATARIO)
                    fnCargar_iWin2_dt2(txtDestinatario, objGuiaEnvio.dt_cur_Nombres_Destinatario, objGuiaEnvio.coll_Nombres_Destinatario, iWinContacto_Destinatario, objGuiaEnvio.iIDCONTACTO_DESTINATARIO, iWinPerosaDNI_Destino)
                Else
                    objGuiaEnvio.iIDCONTACTO_DESTINATARIO = -1
                    txtDestinatario.Text = ""
                    txtDNIDestinatario.Text = ""
                End If

                'ModuUtil.LlenarComboIDs(objGuiaEnvio.rst_Lista_Tipo_Entrega, cmbTipo_Entrega, objGuiaEnvio.coll_Lista_Tipo_Entrega, 1)
                '1 Agencia
                '2 Domicilio

                Dim idTipoDire As Integer = Int(objGuiaEnvio.coll_Lista_Tipo_Entrega.Item(cmbTipo_Entrega.SelectedIndex.ToString))
                If idTipoDire = 2 Then
                    'If objGuiaEnvio.cur_Direccion_Destinatario.BOF = False And objGuiaEnvio.cur_Direccion_Destinatario.EOF = False Then
                    If objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows.Count > 0 Then
                        objGuiaEnvio.iIDDIRECCION_DESTINATARIO = Int(objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows(0).Item(0).ToString)
                        txtDireccionDestinatario.Text = objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows(0).Item(1).ToString
                        fnCargar_iWin_dt(Me.txtDireccionDestinatario, objGuiaEnvio.dt_cur_Direccion_Destinatario, objGuiaEnvio.coll_Direccion_Destinatario, iWinDireccion_Destinatario, objGuiaEnvio.iIDDIRECCION_DESTINATARIO)
                    Else
                        objGuiaEnvio.iIDDIRECCION_DESTINATARIO = -1
                        txtDireccionDestinatario.Text = ""
                    End If
                End If

                'If objGuiaEnvio.cur_Telefono_Destinatario.BOF = False And objGuiaEnvio.cur_Telefono_Destinatario.EOF = False Then
                '    objGuiaEnvio.iIDTEFONO_CONSIGNADO = Int(objGuiaEnvio.cur_Telefono_Destinatario.Fields.Item(0).Value.ToString)
                '    txtTelefonoDestinatario.Text = objGuiaEnvio.cur_Telefono_Destinatario.Fields.Item(1).Value.ToString
                '    fnCargar_iWin(txtTelefonoDestinatario, objGuiaEnvio.cur_Telefono_Destinatario, objGuiaEnvio.coll_Telefono_Destinatario, iWinTelefono_Destinatario, objGuiaEnvio.iIDTEFONO_CONSIGNADO)
                'Else
                '    objGuiaEnvio.iIDTEFONO_CONSIGNADO = -1
                '    txtTelefonoDestinatario.Text = ""
                'End If

                txtTelefonoDestinatario.Text = ""
                objGuiaEnvio.iIDTEFONO_CONSIGNADO = -1
                '

                Dim i As Integer = 0
                For i = 1 To dtGridViewArticulo.Rows().Count
                    dtGridViewArticulo.Rows().RemoveAt(0)
                Next

                txtSubTotal.Text = "0.00"
                txMontotIGV.Text = "0.00"
                txtTotal_Pago.Text = "0.00"

                For i = 0 To 2
                    dtGridViewBultos(2, i).Value() = ""
                    dtGridViewBultos(3, i).Value() = ""
                    dtGridViewBultos(4, i).Value() = "0.00"
                Next

                'If objGuiaEnvio.rst_Articulos.State = 1 Then
                If objGuiaEnvio.dt_rst_Articulos.Rows.Count > 0 Then
                    For Each fila As DataRow In objGuiaEnvio.dt_rst_Articulos.Rows
                        'While objGuiaEnvio.rst_Articulos.BOF = False And objGuiaEnvio.rst_Articulos.EOF = False
                        Dim row0 As String() = {Int(fila.Item(0)).ToString, fila.Item(1), fila.Item(2).ToString, "", "", "0.00"}
                        dtGridViewArticulo.Rows().Add(row0)
                        ' objGuiaEnvio.rst_Articulos.MoveNext()
                    Next
                End If
            Else
                Call ClearData()
                ' MsgBox("GUIA NO ASIGNADAS A NINGUN CLIENTE... ", MsgBoxStyle.Information, "Seguridad Sistema")
                flag = False
            End If
            objGuiaEnvio.iCONTROL = 1
SALIR:
        Catch ex As Exception
            MsgBox("Error Interno...Verificar Datos", MsgBoxStyle.Information, "Seguridad Sistema")
            flag = False
            'objGuiaEnvio.iCONTROL = 1
        End Try
        Return flag
    End Function
    Private Sub ClearData()
        Try
            Me.txtCliente.Text = ""
            Me.txtDestinatario.Text = ""
            Me.txtDNIDestinatario.Text = ""
            Me.txtDNIRemitente.Text = ""
            Me.txtDireccionDestinatario.Text = ""
            Me.txtFechaGuia.Text = dtoUSUARIOS.m_sFecha
            Me.txtNroDocumento.Text = ""
            Me.txtDireccionRemitente.Text = ""
            Me.txtNroDocumento.Text = ""
            Me.TxtRasonSocial.Text = ""
            Me.txtRemitente.Text = ""
            Me.TxtRuc.Text = ""
            Me.txtTelefonoDestinatario.Text = ""
            Me.txtTelefonoRemitente.Text = ""
            'Me.txtiWinDestino.Text = ""
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub cmbTipo_Entrega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo_Entrega.SelectedIndexChanged
        Try
            Dim idTipoEntrega As Integer = Int(objGuiaEnvio.coll_Lista_Tipo_Entrega.Item(Me.cmbTipo_Entrega.SelectedIndex.ToString()))
            If idTipoEntrega = 1 Then ' AGENCIA
                'Me.txtDireccionDestinatario.Visible = True
                Me.txtDireccionDestinatario.Text = "AGENCIA"
                Me.txtDireccionDestinatario.Text = cmbAgenciaVenta.Text

                Me.txtDireccionDestinatario.ReadOnly = True
                'Me.txtDNIDestinatario.Visible = True
                'lbDNIDestinatario.Visible = True
                cmbAgenciaVenta.Enabled = True
            Else 'DOMICILIO
                'Me.txtDireccionDestinatario.Visible = True
                Me.txtDireccionDestinatario.Text = ""
                Me.txtDireccionDestinatario.ReadOnly = False
                'Me.txtDNIDestinatario.Visible = True
                'Me.txtTelefonoDestinatario.Visible = True
                'lbDNIDestinatario.Visible = True
                cmbAgenciaVenta.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub YATATextBoxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtiWinDestino.KeyPress, txtiWinOrigen.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            If Not IsNumeric(e.KeyChar) And Char.IsLetter(e.KeyChar) Then
                e.Handled = Not Char.IsLetter(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub
    'Private Sub DataGridViewDocumentos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridViewDocumentos.KeyDown
    '    Try
    '        '    Dim row As Integer = DataGridViewDocumentos.SelectedCells(0).ColumnIndex
    '        '    Dim row1 As Integer = DataGridViewDocumentos.SelectedRows(0).Index
    '        '    'Dim col As Integer = DataGridViewDocumentos.SelectedCells(0).ColumnIndex
    '        '    If DataGridViewDocumentos.Rows().Count - 1 = row Then
    '        '        Return
    '        '    End If

    '        If e.KeyData = Keys.Delete And iCOL_ACTUAL = 2 Then
    '            DataGridViewDocumentos.Rows(iROW_ACTUAL).Cells(2).Value = ""
    '        End If

    '        If e.KeyData = Keys.Delete And iCOL_ACTUAL = 3 Then
    '            DataGridViewDocumentos.Rows(iROW_ACTUAL).Cells(3).Value = ""
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    'End Sub
    'Private Sub DataGridViewDocumentos_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridViewDocumentos.CellBeginEdit
    '    iROW_ACTUAL = e.RowIndex
    '    iCOL_ACTUAL = e.ColumnIndex
    'End Sub
    'Private Sub DataGridViewDocumentos_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGridViewDocumentos.CellValidating
    '    iROW_ACTUAL = e.RowIndex
    '    iCOL_ACTUAL = e.ColumnIndex
    'End Sub
    Private Function RellenoRight(ByVal Nro As Integer, ByVal texto As String) As String
        Dim cCount As Integer = Len(texto)
        Dim sNewCadena As String = texto
        If Nro = cCount Then
            Return texto
        End If
        Try
            Dim i As Integer
            For i = 1 To Nro - cCount
                sNewCadena = "0" & sNewCadena
            Next
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return sNewCadena
    End Function
    Private Function RellenoLeft(ByVal Nro As Integer, ByVal texto As String) As String
        Dim cCount As Integer = Len(texto)
        Dim sNewCadena As String = texto
        If Nro = cCount Then
            Return texto
        End If
        Try
            Dim i As Integer
            For i = 1 To Nro - cCount
                sNewCadena = sNewCadena & "0"
            Next
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return sNewCadena
    End Function
    Private Sub DataGridViewDocumentos_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewDocumentos.CellEndEdit
        Try
            Dim row As Short = e.RowIndex
            Dim col As Short = e.ColumnIndex
            Dim serie_NroDoc() As String = Split(DataGridViewDocumentos(col, row).Value.ToString, "-")
            Dim serie As String = ""
            Dim NroDoc As String = ""

            If serie_NroDoc(0).Length > 0 Then
                'serie = RellenoRight(iDigitosSerie, Trim(serie_NroDoc(0)))  (4)
                serie = RellenoRight(li_iDigitosSerie, Trim(serie_NroDoc(0)))

            End If
            If serie_NroDoc.Length >= 2 Then
                If serie_NroDoc(1).Length > 0 Then
                    NroDoc = RellenoRight(iDigitosDcoumento + 1, Trim(serie_NroDoc(1)))
                End If
            End If
            DataGridViewDocumentos(col, row).Value = serie & "-" & NroDoc
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub dtGridViewBultos_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtGridViewBultos.CellEndEdit
        Dim row As Short = e.RowIndex
        Dim col As Short = e.ColumnIndex
        '14/08/2008 
        Dim valor1 As Double
        Dim valor2 As Double
        '
        If lb_no_paso = True Then
            Exit Sub
        End If
        iROW_ACTUAL = e.RowIndex
        iCOL_ACTUAL = e.ColumnIndex
        iROW = e.RowIndex
        iCOL = e.ColumnIndex
        Try
            If lb_datos_editados = False Then '14/08/2008 - Se le adiciona el if 
                If iROW = 2 Then
                    dtGridViewBultos(0, row).Value = ""
                    dtGridViewBultos(1, row).Value = "BASE"
                    dtGridViewBultos(2, row).Value = ""
                    '  dtGridViewBultos(3, row).Value = ""  ' Comentado el costo no debe borrarse 
                    dtGridViewBultos(4, row).Value = Monto_Base
                    GoTo CONTROL_SALIDA_1
                End If
            End If
            'If col = 3 Then
            '    If IsDBNull(dtGridViewBultos(3, row).Value) Then
            '        Dim valorConatidad As Double = Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(3, row).Value.ToString))
            '        dtGridViewBultos(3, row).Value = valorConatidad
            '    End If
            'End If
            If col = 3 Then
                'Dim Entero_Decimal() As String = Split(dtGridViewBultos(col, row).Value.ToString, ".")
                'hlamas 22-06-2010
                Dim Entero_Decimal() As String = Nothing
                If dtGridViewBultos(col, row).Value Then
                    Entero_Decimal = Split(dtGridViewBultos(col, row).Value.ToString, ".")
                Else
                    Entero_Decimal = Split("0", ".")
                End If

                Dim sEntero As String

                If Len(Entero_Decimal(0)) > 0 And IsNumeric(Trim(Entero_Decimal(0))) = True Then
                    sEntero = Int(Trim(Entero_Decimal(0))).ToString
                Else
                    sEntero = "0"
                End If

                Dim sDecimal As String
                If Entero_Decimal.Length > 1 Then
                    If Len(Entero_Decimal(1)) > 0 And IsNumeric(Trim(Entero_Decimal(1))) = True Then
                        'sDecimal = RellenoLeft(iDigitosDecimal, Int(Trim(Entero_Decimal(1))).ToString())
                        sDecimal = Trim(Entero_Decimal(1)).ToString()
                    Else
                        sDecimal = "000"
                    End If
                Else
                    sDecimal = "000"
                End If
                dtGridViewBultos(col, row).Value = sEntero & "." & sDecimal
            End If
            '    If lb_datos_editados = False Then '14/08/2008 - Se le adiciona el if 
            valor1 = Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(4, row).Value.ToString)) 'Costo 
            valor2 = Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(3, row).Value.ToString)) ' Cantidad
            'End If
            'dtGridViewBultos(4, row).Value = valor1 * valor2

            '13/08/2080 - Modificado no deberia recalcular 
            'If bControl_Tarifas = False Then
            '    If fnTarifario() = False Then
            '        If col = 2 Then
            '            dtGridViewBultos(2, row).Value = "0.00"
            '            dtGridViewBultos(3, row).Value = "0.00"
            '            dtGridViewBultos.Rows(row).Cells(2).Value = "0.00"
            '            dtGridViewBultos.Rows(row).Cells(3).Value = "0.00"
            '            dtGridViewBultos.CurrentCell = dtGridViewBultos.Rows(row).Cells(1)
            '        ElseIf col = 3 Then
            '            dtGridViewBultos(2, row).Value = "0.00"
            '            dtGridViewBultos(3, row).Value = "0.00"
            '            dtGridViewBultos.Rows(row).Cells(2).Value = "0.00"
            '            dtGridViewBultos.Rows(row).Cells(3).Value = "0.00"
            '            dtGridViewBultos.CurrentCell = dtGridViewBultos.Rows(row).Cells(2)
            '        End If
            '        Update()
            '    End If
            'End If
            '
            '15/08/2008 - Modificado 
            '
            'If bControl_Tarifas = True Then
            '13/08/2080 - Modificado no deberia recalcular 
            'If fnTarifario() = False Then
            '    If col = 2 Then
            '        dtGridViewBultos(2, row).Value = "0.00"
            '        dtGridViewBultos(3, row).Value = "0.00"
            '        dtGridViewBultos.Rows(row).Cells(2).Value = "0.00"
            '        dtGridViewBultos.Rows(row).Cells(3).Value = "0.00"
            '        dtGridViewBultos.CurrentCell = dtGridViewBultos.Rows(row).Cells(1)
            '    ElseIf col = 3 Then
            '        dtGridViewBultos(2, row).Value = "0.00"
            '        dtGridViewBultos(3, row).Value = "0.00"
            '        dtGridViewBultos.Rows(row).Cells(2).Value = "0.00"
            '        dtGridViewBultos.Rows(row).Cells(3).Value = "0.00"
            '        dtGridViewBultos.CurrentCell = dtGridViewBultos.Rows(row).Cells(2)
            '    End If
            '    Update()
            'End If
            dtGridViewBultos(4, 2).Value = Format(Monto_Base, "##,###,####.00")
            If row = 0 Then   ' Row ¿¿¿???
                If valor2 = 0 Then
                    'Modif. 08/08/2008 - 
                    'dtGridViewBultos(4, row).Value = Format(valor1 * valor2 * tarifa_Peso, "###,###,###.00")
                    dtGridViewBultos(5, row).Value = Format(valor1 * valor2 * tarifa_Peso, "###,###,###.00")
                Else
                    If objGuiaEnvio.iPeso_Minimo <= valor2 And valor2 <= objGuiaEnvio.iPeso_Maximo And objGuiaEnvio.iPeso_Maximo > 0 Then
                        'If objGuiaEnvio.iPeso_Minimo <= valor1 And valor1 <= objGuiaEnvio.iPeso_Maximo And lb_datos_editados = False Then
                        'dtGridViewBultos(4, row).Value = Format(objGuiaEnvio.iPrecio_cond_Peso, "###,###,###.00")
                        dtGridViewBultos(5, row).Value = Format(objGuiaEnvio.iPrecio_cond_Peso, "###,###,###.00")
                    Else
                        'dtGridViewBultos(4, row).Value = Format(valor1 * tarifa_Peso, "###,###,###.00")
                        If lb_datos_editados = True Then
                            dtGridViewBultos(5, row).Value = Format(valor1 * valor2, "###,###,###.00")
                        Else
                            If valor1 <> tarifa_Peso Then
                                dtGridViewBultos(5, row).Value = Format(valor1 * tarifa_Peso, "###,###,###.00")
                            Else
                                dtGridViewBultos(5, row).Value = Format(valor1 * valor2, "###,###,###.00")
                            End If
                        End If
                    End If
                End If
            ElseIf row = 1 Then
                If valor2 = 0 Then
                    'Modif. 08/08/2008 - 
                    'dtGridViewBultos(4, row).Value = Format(valor1 * valor2 * tarifa_Volumen, "###,###,###.00")
                    dtGridViewBultos(5, row).Value = Format(valor1 * valor2 * tarifa_Volumen, "###,###,###.00")
                Else
                    'Modif. 08/08/2008 - 
                    'dtGridViewBultos(5, row).Value = Format(valor1 * tarifa_Volumen, "###,###,###.00")
                    If lb_datos_editados = True Then
                        dtGridViewBultos(5, row).Value = Format(valor1 * valor2, "###,###,###.00")
                    Else
                        If valor1 <> tarifa_Volumen Then
                            dtGridViewBultos(5, row).Value = Format(valor1 * tarifa_Volumen, "###,###,###.00")
                        Else
                            dtGridViewBultos(5, row).Value = Format(valor1 * valor2, "###,###,###.00")
                        End If
                    End If
                End If
                'ElseIf row = 2 Then
                '    dtGridViewBultos(4, row).Value = valor1 * valor2 * tarifa_Articulo
            End If
            Total_Pagar()
            If iROW = 0 And iCOL = 2 Then
                'dtGridViewBultos.CurrentCell = dtGridViewBultos.Rows(0).Cells(3)
                'dtGridViewBultos.Rows(0).Cells(3).Selected = True

            ElseIf iROW = 1 And iCOL = 2 Then
                'dtGridViewBultos.CurrentCell = dtGridViewBultos.Rows(1).Cells(3)
                'dtGridViewBultos.Rows(1).Cells(3).Selected = True
                'ElseIf iROW = 2 And iCOL = 3 Then
                '    dtGridViewBultos.CurrentCell = dtGridViewBultos.Rows(1).Cells(1)
                '    dtGridViewBultos.Rows(1).Cells(1).Selected = True
            End If
            '15/08/2008 - Tener cuidado con los otros valores ¿¿¿¿????
            'Else
            '    If row = 0 Then
            '        dtGridViewBultos(4, row).Value = "0.00"
            '    ElseIf row = 1 Then
            '        dtGridViewBultos(4, row).Value = "0.00"
            '        'ElseIf row = 2 Then
            '        '    dtGridViewBultos(4, row).Value = "0.00"
            '    End If
            'End If
CONTROL_SALIDA_1:


        Catch ex As Exception
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            fnTarifario()
        End Try

        If row = 0 And col = 2 Then
            'dtGridViewBultos.CurrentCell = dtGridViewBultos.Rows(0).Cells(3)
            'dtGridViewBultos.Rows(1).Cells(2).Selected = True
            '    MsgBox("entro")
        ElseIf row = 1 And col = 2 Then
            'dtGridViewBultos.CurrentCell = dtGridViewBultos.Rows(1).Cells(3)
            'dtGridViewBultos.Rows(1).Cells(3).Selected = True
            '    MsgBox("todo")
            'ElseIf row = 2 And col = 3 Then
            '    dtGridViewBultos.CurrentCell = dtGridViewBultos.Rows(1).Cells(1)
            '    dtGridViewBultos.Rows(1).Cells(1).Selected = True
            '    MsgBox("paso de Nuevo")
        End If

        ''dtGridViewBultos.EndEdit()
        'MsgBox("var")
    End Sub
    Private Function Total_Pagar() As Boolean
        Try
            'txtSubTotal.Text = Format(dtGridViewBultos(4, 0).Value + dtGridViewBultos(4, 1).Value + dtGridViewBultos(4, 2).Value, "######.000")
            'Dim Costo_Peso As Double = CDbl(dtGridViewBultos(4, 0).Value.ToString)
            Dim Costo_Peso As Double = CDbl(dtGridViewBultos(5, 0).Value.ToString)
            'Dim Costo_Volumen As Double = CDbl(dtGridViewBultos(4, 1).Value.ToString)
            Dim Costo_Volumen As Double = CDbl(dtGridViewBultos(5, 1).Value.ToString)
            'Dim Costo_Articulo As Double = CDbl(dtGridViewBultos(4, 2).Value.ToString)
            Dim Monto_Base As Double = CDbl(dtGridViewBultos(4, 2).Value.ToString)

            Dim ivol As Double = 0
            If dtGridViewBultos(2, 1).Value <> Nothing And dtGridViewBultos(3, 1).Value <> Nothing Then
                'ivol = Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(2, 1).Value.ToString) * Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(3, 1).Value.ToString)
                ivol = Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(2, 1).Value.ToString) * Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(4, 1).Value.ToString)
            End If

            Dim ipes As Double = 0
            If dtGridViewBultos(2, 0).Value <> Nothing And dtGridViewBultos(3, 0).Value <> Nothing Then
                'ipes = Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(2, 0).Value.ToString) * Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(3, 0).Value.ToString)
                ipes = Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(2, 0).Value.ToString) * Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(4, 0).Value.ToString)
            End If


            'Dim ivol As Double = CDbl(dtGridViewBultos(2, 1).Value.ToString) * Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(3, 1).Value.ToString)
            'Dim ipes As Double = CDbl(dtGridViewBultos(2, 0).Value.ToString) * Microsoft.VisualBasic.Conversion.Val(dtGridViewBultos(3, 0).Value.ToString)

            If ivol > 0 Then
                'Costo_Volumen = Costo_Volumen + Monto_Base
                Costo_Volumen = Costo_Volumen
            Else
                Costo_Volumen = 0
            End If

            If ipes = 0 Then
                Costo_Peso = 0
            End If

            Dim c__var As Integer = 1
            Dim Monto_Sobre As Double = 0
            If c__var Then
                Monto_Sobre = tarifa_Sobre * Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
                txtTotalSobre.Visible = True
                txtTotalSobre.Text = Format(Monto_Sobre, "####,###,###.00")
            Else
                txtTotalSobre.Visible = False
                Monto_Sobre = 0
                txtTotalSobre.Text = "0.00"
            End If

            If ivol > 0 And ipes >= 0 Then
                txtSubTotal.Text = Format(Monto_Sobre + Costo_Peso + Costo_Volumen + Monto_Base, "####,###,###.00")
                txMontotIGV.Text = Format((IGV) * (Monto_Sobre + Costo_Peso + Costo_Volumen + Monto_Base), "####,###,###.00")
                txtTotal_Pago.Text = Format((1 + IGV) * (Monto_Sobre + Costo_Peso + Costo_Volumen + Monto_Base), "####,###,###.00")

            ElseIf ipes > 0 And ivol >= 0 Then

                txtSubTotal.Text = Format(Monto_Sobre + Costo_Peso + Monto_Base, "####,###,###.00")
                txMontotIGV.Text = Format((IGV) * (Monto_Sobre + Costo_Peso + Monto_Base), "####,###,###.00")
                txtTotal_Pago.Text = Format((1 + IGV) * (Monto_Sobre + Costo_Peso + Monto_Base), "####,###,###.00")

            ElseIf ipes = 0 And ivol = 0 Then
                Dim Total_Articulo As Double = 0
                If fArticulo = True Then
                    objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = 0
                    Dim ii1 As Integer = 0
                    For ii1 = 0 To dtGridViewArticulo.Rows().Count() - 1
                        Total_Articulo = Total_Articulo + CDbl(dtGridViewArticulo.Rows(ii1).Cells(6).Value.ToString)
                        objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI + Microsoft.VisualBasic.Conversion.Val(dtGridViewArticulo.Rows(ii1).Cells(3).Value.ToString)
                    Next
                    ' Total_Articulo = Total_Articulo '+ Monto_Base * Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
                    If Total_Articulo > 0 Then
                        txtSubTotal.Text = Format(Monto_Base + Monto_Sobre + Total_Articulo, "####,###,###.00")
                        txMontotIGV.Text = Format((IGV) * (Monto_Base + Monto_Sobre + Total_Articulo), "####,###,###.00")
                        txtTotal_Pago.Text = Format((1 + IGV) * (Monto_Base + Monto_Sobre + Total_Articulo), "####,###,###.00")
                    Else
                        txtSubTotal.Text = Format(Monto_Sobre, "####,###,###.00")
                        txMontotIGV.Text = Format((IGV) * (Monto_Sobre), "####,###,###.00")
                        txtTotal_Pago.Text = Format((1 + IGV) * (Monto_Sobre), "####,###,###.00")
                    End If
                Else
                    txtSubTotal.Text = Format(Monto_Sobre, "####,###,###.00")
                    txMontotIGV.Text = Format((IGV) * (Monto_Sobre), "####,###,###.00")
                    txtTotal_Pago.Text = Format((1 + IGV) * (Monto_Sobre), "####,###,###.00")
                End If


            Else
                txtSubTotal.Text = "0.00"
                txMontotIGV.Text = "0.00"
                txtTotal_Pago.Text = "0.00"
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            txtTotalSobre.Text = "0.00"
        End Try
        Return False
    End Function
    Private Function Limpiar_Todo() As Boolean
        Try
            Me.TxtGuiaEnvio.Focus()
            txtCliente_Remitente.Text = ""
            txtDocCliente_Remitente.Text = ""
            Me.TxtGuiaEnvio.Text = ""
            Me.TxtRuc.Text = ""
            Me.TxtRasonSocial.Text = ""
            'txtRemitente.Visible = True
            'txtDNIRemitente.Visible = True
            'txtDireccionRemitente.Visible = True
            'txtTelefonoRemitente.Visible = True

            'txtDestinatario.Visible = True
            'txtDNIDestinatario.Visible = True
            'txtDireccionDestinatario.Visible = True
            'txtTelefonoDestinatario.Visible = True

            txtRemitente.Text = ""
            txtDNIRemitente.Text = ""
            txtDireccionDestinatario.Text = ""
            txtTelefonoRemitente.Text = ""

            txtDestinatario.Text = ""
            txtDNIDestinatario.Text = ""
            txtDireccionDestinatario.Text = ""
            txtTelefonoDestinatario.Text = ""

            Me.txtTotal_Pago.Text = "0.00"
            Me.txtSubTotal.Text = "0.00"
            Me.txMontotIGV.Text = "0.00"
            Me.dtFechaGuia.Text = dtoUSUARIOS.m_sFecha

            Dim i As Integer = 0

            'Me.txtDireccionDestinatario.Visible = True
            Me.txtDireccionDestinatario.Text = "AGENCIA"
            Me.txtDireccionDestinatario.ReadOnly = True
            'Me.txtDNIDestinatario.Visible = False
            'Me.txtTelefonoDestinatario.Visible = True
            'lbDNIDestinatario.Visible = False
            txtDireccionRemitente.Text = ""
            Me.cmbTipo_Entrega.SelectedIndex = 0

            For i = 1 To DataGridViewDocumentos.Rows.Count - 1
                DataGridViewDocumentos.Rows().RemoveAt(0)
            Next
            Dim row11 As String() = {"", "", "", ""}
            DataGridViewDocumentos.Rows().Add(row11)
            DataGridViewDocumentos.Rows().Add(row11)
            For i = 0 To 2
                dtGridViewBultos(2, i).Value() = ""
                dtGridViewBultos(3, i).Value() = ""
                dtGridViewBultos(4, i).Value() = "0.00"
                dtGridViewBultos(5, i).Value() = "0.00" ' Add 14/08/2008
            Next
            For i = 1 To dtGridViewArticulo.Rows.Count
                dtGridViewArticulo.Rows().RemoveAt(0)
            Next

            checkSobres.Checked = False
            txtCantidadSobres.Visible = False
            objGuiaEnvio.iCANTIDAD_SOBRES = 0
            objGuiaEnvio.iIDSINO_SOBRES = 0
            txtTotalSobre.Text = "0.00"
            txtCantidadSobres.Text = "0"
            txtiWinDestino.Text = ""
            '
            Me.lb_base.Visible = False
            Me.txt_base.Visible = False
            ''28/08/2009 
            cmbAgenciaOrigen.SelectedIndex = -1
            objGuiaEnvio.iIDAGENCIAS = 0
            objGuiaEnvio.iIDAGENCIAS_DESTINO = 0
            Me.txtiWinDestino.Text = ""
            Me.cmbAgenciaVenta.SelectedValue = 0
            Me.cmbAgenciaVenta.Text = ""
            Me.cmbAgenciaVenta.SelectedIndex = -1
            '
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try

    End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean = True
        Dim flat As Boolean = True
        Try
            Dim var As Integer = msg.WParam.ToInt32
            If msg.WParam.ToInt32 = Keys.Tab Then
                If checkSobres.Focused = True Then
                    txtCantidadSobres.Focus()
                    txtCantidadSobres.SelectAll()
                End If
            End If
            If msg.WParam.ToInt32 = Keys.Enter Then
                'TxtGuiaEnvio.CanSelect()
                'objLOG.fnLog("[ENTER] :" & txtNroDocumento.Text.ToString)
                '
                If txtNroDocumento.Focused = True Then
                    'MsgBox("Busca NroControl...")
                    CONTROL = 5
                    fnBuscarNroGUIA()
                ElseIf TxtRasonSocial.Focused = True Then
                    ' Recupera el tarifario del cliente 
                    'objLOG.fnLog("[ENTER] :" & TxtRasonSocial.Text.ToString)
                    ' fnCargar_iWin(Me.TxtRasonSocial, objGuiaEnvio.rst_Lista_Personas, coll_Lista_Personas, iWinPerosa, 0)
                    'iWinPerosa()
                    CONTROL = 2
                    Dim indexof As Integer = 0
                    If iWinPerosa.Count > 0 Then
                        'indexof = IIf(iWinContacto_Remitente.IndexOf(txtRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtRemitente.Text), -1)
                        indexof = IIf(iWinPerosa.IndexOf(TxtRasonSocial.Text) >= 0, iWinPerosa.IndexOf(TxtRasonSocial.Text), -1)
                        objGuiaEnvio.iIDPERSONA = -1
                        If indexof >= 0 Then
                            objGuiaEnvio.iIDPERSONA = Int(coll_Lista_Personas(indexof.ToString))
                            objGuiaEnvio.iCONTROLIdpersona = objGuiaEnvio.iIDPERSONA
                            'Recupera los datos 
                            If indexof <= iWinPerosaRUC.Count Then
                                Me.TxtRuc.Text = iWinPerosaRUC.Item(indexof)
                                '(3) 
                                li_iDigitosSerie = iwinNro_digito_serie_cliente.Item(indexof)
                                formatea_grilla_nuevo()
                                '
                                txtCliente_Remitente.Text = TxtRasonSocial.Text
                                txtDocCliente_Remitente.Text = Me.TxtRuc.Text
                                objGuiaEnvio.iID_REMITENTE = objGuiaEnvio.iIDPERSONA '01/2010 - Debe considerarse como primer cambio 
                                objGuiaEnvio.iREMITENTE = TxtRasonSocial.Text
                                objGuiaEnvio.iNRODOC_REM = Me.TxtRuc.Text
                                bControl_Busqueda = True
                                ' fnTarifario()                                
                                '12/08/2008 - Limpiando los datos 
                                limpia_monto_x_cambio()
                                '
                                If fb_buscar_cliente() = True Then ' Y recupera el tarifario 
                                    txtCliente_Remitente.Focus()
                                    txtCliente_Remitente.SelectAll()
                                End If
                                '
                                '
                                'If BuscarClientesGuia_Envio() = True Then
                                '    'txtCliente_Remitente.Focus()
                                '    'txtCliente_Remitente.SelectAll()
                                '    txtDestinatario.Focus()
                                '    txtDestinatario.SelectAll()
                                '    'SendKeys.Send("{Tab}")
                                '    fnTarifario()
                                'End If

                            End If
                        Else
                            MsgBox("El cliente no tiene línea de crédito, revise sus datos", MsgBoxStyle.Information, "Seguridad Sistema")
                        End If
                    End If
                    'If BuscarClientesGuia_Envio() = True Then
                    '    txtCliente_Remitente.Focus()
                    '    txtCliente_Remitente.SelectAll()
                    '    'SendKeys.Send("{Tab}")
                    '    fnTarifario()
                    'End If

                ElseIf txtRemitente.Focused = True Then
                    'MsgBox("Exe...")
                    Dim indexof As Integer = 0
                    txtDNIRemitente.Text = ""
                    indexof = IIf(iWinContacto_Remitente.IndexOf(txtRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtRemitente.Text), -1)
                    objGuiaEnvio.iIDCONTACTO_PERSONA = -1
                    If indexof >= 0 Then
                        objGuiaEnvio.iIDCONTACTO_PERSONA = Int(objGuiaEnvio.coll_Nombres_Remitente(indexof.ToString))
                        If indexof <= iWinPerosaDNI_Remite.Count Then
                            Me.txtDNIRemitente.Text = iWinPerosaDNI_Remite.Item(indexof)
                        End If
                    End If
                    SendKeys.Send("{Tab}")
                ElseIf txtDestinatario.Focused = True Then
                    'MsgBox("Exe...")
                    Dim indexof As Integer = 0
                    txtDNIDestinatario.Text = ""
                    indexof = IIf(iWinContacto_Destinatario.IndexOf(txtDestinatario.Text) >= 0, iWinContacto_Destinatario.IndexOf(txtDestinatario.Text), -1)
                    objGuiaEnvio.iIDCONTACTO_REMITENTE = -1
                    If indexof >= 0 Then
                        objGuiaEnvio.iIDCONTACTO_PERSONA = Int(objGuiaEnvio.coll_Nombres_Destinatario(indexof.ToString))
                        If indexof <= iWinPerosaDNI_Destino.Count Then
                            txtDNIDestinatario.Text = iWinPerosaDNI_Destino.Item(indexof)
                        End If
                    End If
                    SendKeys.Send("{Tab}")
                    'fnCargar_iWin2(txtDestinatario, objGuiaEnvio.cur_Nombres_Destinatario, objGuiaEnvio.coll_Nombres_Destinatario, iWinContacto_Destinatario, objGuiaEnvio.iIDCONTACTO_DESTINATARIO, iWinPerosaDNI_Destino)
                ElseIf TxtRuc.Focused = True Then
                    'fnCargar_iWin2(Me.TxtRasonSocial, objGuiaEnvio.rst_Lista_Personas, coll_Lista_Personas, iWinPerosa, 0, iWinPerosaRUC)                    
                    CONTROL = 2
                    Dim indexof As Integer = 0
                    If iWinPerosa.Count > 0 Then
                        'indexof = IIf(iWinContacto_Remitente.IndexOf(txtRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtRemitente.Text), -1)
                        indexof = iWinPerosaRUC.IndexOf(TxtRuc.Text)
                        ' (7)
                        If indexof < 0 Then
                            MsgBox("El Cliente no tiene Línea de Crédito, revise sus datos", MsgBoxStyle.Information, "Seguridad Sistema")
                            Return False
                        End If
                        li_iDigitosSerie = iwinNro_digito_serie_cliente.Item(indexof)
                        formatea_grilla_nuevo()
                        '
                        objGuiaEnvio.iIDPERSONA = -1
                        If indexof >= 0 Then
                            objGuiaEnvio.iIDPERSONA = Int(coll_Lista_Personas(indexof.ToString))
                            objGuiaEnvio.iCONTROLIdpersona = objGuiaEnvio.iIDPERSONA
                            If indexof <= iWinPerosa.Count Then
                                Me.TxtRasonSocial.Text = iWinPerosa.Item(indexof)
                                objGuiaEnvio.iID_REMITENTE = objGuiaEnvio.iIDPERSONA
                                objGuiaEnvio.iREMITENTE = TxtRasonSocial.Text
                                objGuiaEnvio.iNRODOC_REM = Me.TxtRuc.Text
                                bControl_Busqueda = True
                            End If
                        Else
                            MsgBox("El Cliente no tiene Línea de Crédito, revise sus datos", MsgBoxStyle.Information, "Seguridad Sistema")
                        End If
                    End If
                    If BuscarClientesGuia_Envio() = True Then
                        SendKeys.Send("{Tab}")
                    End If
                    '    ElseIf Me.dtGridViewBultos.Focused = True Then
                    'Sin mensages
                    'MsgBox("Seguridad TAB")

                ElseIf TxtGuiaEnvio.Focused = True Then  ' Busca todos los Items de la lista de Datos
                    '-----------------OJO ACTIVAR PARA CONTROL
                    If fnDigito_Chequeo(TxtGuiaEnvio.Text) = False Then
                        MsgBox("NRO DE GUIA DE ENVIO MAL ESCRITO REVISE,....O GENERE UNA NUEVA GUIA...", MsgBoxStyle.Information, "Seguridad Sistema")
                        TxtGuiaEnvio.Focus()
                        TxtGuiaEnvio.SelectAll()
                        Return False
                    End If

                    If fnDigito_Chequeo(TxtGuiaEnvio.Text) = True Then
                        CONTROL = 1
                        bControl_Busqueda = False
                        txtiWinDestino.Focus()
                        txtiWinDestino.SelectAll()
                        'If BuscarGuia_Envio_X_CLIENTES() = True Then
                        '    SendKeys.Send("{Tab}")
                        'End If
                    Else
                        'txtiWinDestino.Focus()
                        'txtiWinDestino.SelectAll()

                        If BuscarClientesGuia_Envio() = True Then
                            txtiWinDestino.Focus()
                            txtiWinDestino.SelectAll()
                            'SendKeys.Send("{Tab}")
                        Else
                            If objGuiaEnvio.iControl_Guias_Existe = 1 Or objGuiaEnvio.iControl_Guias_Existe = 3 Then
                                TxtGuiaEnvio.Focus()
                                TxtGuiaEnvio.SelectAll()
                            Else
                                txtiWinDestino.Focus()
                                txtiWinDestino.SelectAll()
                            End If
                        End If

                        'TxtGuiaEnvio.Focus()
                        'TxtGuiaEnvio.SelectAll()
                        'MsgBox("El Nro de Guia No es Valido", MsgBoxStyle.Information, "Seguridad Sistema")
                    End If

                    'txtiWinDestino.Focus()
                    'txtiWinDestino.SelectAll()
                    'ElseIf txtDestinatario.Focused = True Then
                    '    txtDNIDestinatario.Focus()
                    '    SendKeys.Send("{Tab}")
                ElseIf Me.dtGridViewBultos.Focused = True Then
                    fnTarifario()
                Else
                    SendKeys.Send("{Tab}")
                End If

                'If Me.txtNroDocuento.Focused = True Then
                '    MsgBox("Hola Munfo")
                '    txtNroDocuento.Focus()
                'End If

                'If TxtGuiaEnvio.CanSelect() = True Then
                '    BuscarClientesGuia_Envio()
                'Else
                '    SendKeys.Send("{Tab}")
                'End If

                'If iFlagControl = False Or iCOL = 2 Then
                '    MsgBox("Entro")
                'Else
                '    MsgBox("paso")
                '    If iROW = 0 And iCOL = 3 Then
                '        dtGridViewBultos.CurrentCell = dtGridViewBultos.Rows(1).Cells(2)
                '        dtGridViewBultos.Rows(1).Cells(2).Selected = True
                '        MsgBox("entro")
                '    ElseIf iROW = 1 And iCOL = 3 Then
                '        dtGridViewBultos.CurrentCell = dtGridViewBultos.Rows(2).Cells(2)
                '        dtGridViewBultos.Rows(1).Cells(1).Selected = True
                '        MsgBox("todo")
                '    ElseIf iROW = 2 And iCOL = 3 Then
                '        dtGridViewBultos.CurrentCell = dtGridViewBultos.Rows(1).Cells(1)
                '        dtGridViewBultos.Rows(1).Cells(1).Selected = True
                '        MsgBox("paso de Nuevo")
                '    End If
                '    'SendKeys.Send("{Tab}")
                'End If
            ElseIf msg.WParam.ToInt32 = Keys.F7 Then

                txtRemitente.Focus()
                txtRemitente.SelectAll()
            ElseIf msg.WParam.ToInt32 = Keys.F12 Then
                If MsgBox("¿Esta Seguro que Quiere Salir....?", MsgBoxStyle.YesNoCancel, "Seguridad Sistema") = MsgBoxResult.Yes Then
                    iFlagControl = False
                    Close()
                End If
            ElseIf msg.WParam.ToInt32 = Keys.F1 Then
                cmbTipo_Entrega.Focus()
                cmbTipo_Entrega.SelectAll()
                'If TxtGuiaEnvio.Focused = True Then  ' Busca todos los Items de la lista de Datos
                '    CONTROL = 1
                '    bControl_Busqueda = False
                '    If BuscarClientesGuia_Envio() = True Then
                '        SendKeys.Send("{Tab}")
                '    End If
                'End If
            ElseIf msg.WParam.ToInt32 = Keys.F2 Then ' Ediciion de los datos
                TxtRasonSocial.Focus()
                TxtRasonSocial.SelectAll()
            ElseIf msg.WParam.ToInt32 = Keys.F3 Then ' Edicion de los datos
                'cambio tecla funcion
                If Me.btnNuevo.Enabled Then
                    fnNUEVO()
                    fnCONTROLDATOS = True
                    SelectMenu(1)
                End If
            ElseIf msg.WParam.ToInt32 = Keys.Escape Then
                iFlagControl = False
                If MsgBox("¿Está seguro de cancelar esta operación?", MsgBoxStyle.YesNo, "Seguridad Sistema") = MsgBoxResult.Yes Then
                    Limpiar_Todo()
                    fnCONTROLDATOS = True
                End If

            ElseIf msg.WParam.ToInt32 = Keys.F5 Then
                If Me.btnGrabar.Enabled Then
                    Grabar()
                End If
                'If fnDigito_Chequeo(Me.TxtGuiaEnvio.Text.ToString) = False Then
                '    MsgBox("EL Nº DE GUIA ESTA MAL ESCRITO, REVISE SU Nº Ó CREE UNA NUEVA GUIA DE ENVIO...", MsgBoxStyle.Information, "Seguridad Sistema")
                '    TxtGuiaEnvio.Focus()
                '    TxtGuiaEnvio.SelectAll()
                '    Return False
                'End If
                'If fnControlFecha_GuiaEnvio(Me.txtFechaGuia.Text.ToString) = True Then

                '    iFlagControl = False
                '    If fnCONTROLDATOS = True Then
                '        'MsgBox("Grabado Correctamente ", MsgBoxStyle.Information, "Seguridad Sistema")
                '        If objGuiaEnvio.iCONTROL = 1 Then
                '            strNroGuias_Remision = ""
                '            'Try - 04/09/2009  - Desactiva por el datahelper 
                '            'Mod. 24/08/2009 -->Omendoza - Pasando al datahelper 
                '            v_Origen = objGuiaEnvio.fnIATA(objGuiaEnvio.iIDUNIDAD_AGENCIA)
                '            v_destino = objGuiaEnvio.fnIATA(objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO)
                '            'Catch ex As Exception
                '            'MsgBox("Verifique sus datos de IATA en la guía de envío", MsgBoxStyle.Information, "Seguridad Sistema")
                '            'End Try

                '            Dim flagGuia As Boolean = False
                '            If Int(CORRELATIVO) = Int(TxtGuiaEnvio.Text) Then
                '                flagGuia = True
                '            End If
                '            ObjRptGuiaEnvio.P_PROVINCIA = txtiWinDestino.Text
                '            ObjRptGuiaEnvio.P_CARGO = IIf(objGuiaEnvio.iIDTipoFacturacion = 3, "X", " ")
                '            If Grabar_GuiaEnvio() = True Then
                '                If flagGuia = True Then
                '                    ObjVentaCargaContado.fnIncrementarNroDoc(3)
                '                End If
                '                If MsgBox("Desea imprimir esta Guia ...", MsgBoxStyle.YesNo, "Seguridad Sistema") = MsgBoxResult.Yes Then

                '                    v_iDestino = "       "
                '                    v_iCredito = "       "
                '                    v_iDomicilio = "      "
                '                    v_iAgencia = "      "

                '                    If objGuiaEnvio.iIDTIPO_ENTREGA_CARGA = 1 Then
                '                        p_domicilio = ""
                '                        p_agencia = "X"
                '                    Else
                '                        p_domicilio = "X"
                '                        p_agencia = ""
                '                    End If
                '                    ObjRptGuiaEnvio.p_forma_pago = v_iDestino & v_iCredito

                '                    If objGuiaEnvio.iIDFORMA_PAGO = 1 Then
                '                        p_contado = "X"
                '                        p_destino = ""
                '                        p_credito = ""
                '                    ElseIf objGuiaEnvio.iIDFORMA_PAGO = 2 Then
                '                        p_contado = ""
                '                        p_destino = ""
                '                        p_credito = "X"
                '                    Else
                '                        p_contado = ""
                '                        p_destino = "X"
                '                        p_credito = ""
                '                    End If

                '                    ObjRptGuiaEnvio.p_NroGUIA = TxtGuiaEnvio.Text
                '                    ObjRptGuiaEnvio.p_tipo_entrega = v_iDomicilio & v_iAgencia
                '                    ObjRptGuiaEnvio.p_ruc = Me.TxtRuc.Text & "-" & Me.TxtRasonSocial.Text
                '                    ' ObjRptGuiaEnvio.p_tipo_entrega = ObjRptGuiaEnvio.p_tipo_entrega
                '                    'ObjRptGuiaEnvio.p_forma_pago = ObjRptGuiaEnvio.p_forma_pago
                '                    ObjRptGuiaEnvio.p_contacto = IIf(txtRemitente.Text <> "", txtRemitente.Text, "")
                '                    ObjRptGuiaEnvio.p_codigo_iata_ori = v_Origen
                '                    ObjRptGuiaEnvio.p_codigo_iata_desti = v_destino
                '                    ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI = Me.txtTelefonoRemitente.Text
                '                    ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI = Me.txtTelefonoDestinatario.Text
                '                    ObjRptGuiaEnvio.P_REMITENTE = Me.txtCliente_Remitente.Text
                '                    ObjRptGuiaEnvio.P_DIRECCION_REMI = Me.txtDireccionRemitente.Text
                '                    ObjRptGuiaEnvio.P_DIRECCION_DESTI = Me.txtDireccionDestinatario.Text
                '                    ObjRptGuiaEnvio.P_NOMBRES_DESTI = Me.txtDestinatario.Text
                '                    ObjRptGuiaEnvio.P_FECHA_GUIA = Me.txtFechaGuia.Text
                '                    ObjRptGuiaEnvio.P_TOTAL_BULTOS = objGuiaEnvio.iCANTIDAD + objGuiaEnvio.iCANTIDAD_X_UNIDAD_VOLUMEN + objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI
                '                    ObjRptGuiaEnvio.P_TOTAL_VOLUMEN = objGuiaEnvio.dTOTAL_VOLUMEN.ToString


                '                    'AGREGAR PESO DESDE ARTICULOS
                '                    'If Me.dtGridViewArticulo.Visible = True Then
                '                    '    ObjRptGuiaEnvio.P_TOTAL_PESO = fn_peso_desde_articulos()
                '                    'Else
                '                    '    ObjRptGuiaEnvio.P_TOTAL_PESO = objGuiaEnvio.dTOTAL_PESO.ToString
                '                    'End If


                '                    ObjRptGuiaEnvio.P_TOTAL_PESO = objGuiaEnvio.dTOTAL_PESO.ToString


                '                    ObjRptGuiaEnvio.P_TOTAL_SOBRES = IIf(objGuiaEnvio.iCANTIDAD_SOBRES.ToString <> "", objGuiaEnvio.iCANTIDAD_SOBRES.ToString, " ")


                '                    ObjCODIGOBARRA.Cantidad = ObjRptGuiaEnvio.P_TOTAL_BULTOS
                '                    ObjCODIGOBARRA.NroDOC = ObjRptGuiaEnvio.p_NroGUIA
                '                    ObjCODIGOBARRA.clinte = TxtRasonSocial.Text
                '                    ObjCODIGOBARRA.Origen = v_Origen
                '                    ObjCODIGOBARRA.Destino = v_destino
                '                    ObjCODIGOBARRA.AGEDOM = Mid(cmbTipo_Entrega.Text, 1, 3)

                '                    fnInprecion_Guia_Envio()

                '                    'ObjReportrutaRpt = PathFrmReport
                '                    'ObjReportconectar(RptService, RptUser, RptPass)
                '                    'ObjReportprintrpt(True, "", "GUI006.RPT", "P_IDGUIAS_ENVIO;" & objGuiaEnvio.iIDGUIAS_ENVIO)

                '                End If
                '                ObjCODIGOBARRA.Cantidad = objGuiaEnvio.iCANTIDAD + objGuiaEnvio.iCANTIDAD_X_UNIDAD_VOLUMEN + objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI + objGuiaEnvio.iCANTIDAD_SOBRES
                '                ObjCODIGOBARRA.NroDOC = TxtGuiaEnvio.Text
                '                ObjCODIGOBARRA.clinte = TxtRasonSocial.Text
                '                ObjCODIGOBARRA.Origen = v_Origen
                '                ObjCODIGOBARRA.Destino = v_destino
                '                ObjCODIGOBARRA.AGEDOM = Mid(cmbTipo_Entrega.Text, 1, 3)
                '                If MsgBox("Esta Seguro de Imprimir Etiquetas...", MsgBoxStyle.YesNoCancel, "Seguridad") = MsgBoxResult.Yes Then
                '                    If xIMPRESORA = 1 Then
                '                        fnImprimirEtiquetasGUIA()
                '                    Else
                '                        If xIMPRESORA = 2 Then
                '                            fnImprimirEtiquetasGUIA_II()
                '                        Else
                '                            fnImprimirEtiquetasGUIA_III()
                '                        End If
                '                        'fnImprimirEtiquetasGUIA_II()  Estaba anterior 
                '                    End If
                '                End If
                '                strNroGuias_Remision = ""
                '                Me.fnNUEVO()
                '                'Limpiar_Todo()
                '                objGuiaEnvio.iCONTROL = 1

                '            End If
                '        Else ' 
                '            If MsgBox("Esta realizando una edición...,¿Está seguro de continuar?", MsgBoxStyle.YesNoCancel, "Seguridad Sistema") = MsgBoxResult.Yes Then
                '                If objGuiaEnvio.iCONTROL = 2 Then
                '                    EDITAR_GuiaEnvio()
                '                    objGuiaEnvio.iCONTROL = 2
                '                    If Grabar_GuiaEnvio() = True Then
                '                        'If EDITAR_GuiaEnvio() = True Then
                '                        'End If
                '                        Me.fnNUEVO()
                '                        'Limpiar_Todo()
                '                        objGuiaEnvio.iCONTROL = 1
                '                    End If
                '                Else
                '                    MsgBox("Revices sus datos ..., No puede realizar esta operacion..., No es Ni editar ni Grabar, salga del sistema", MsgBoxStyle.Information, " Seguridad Sistema")
                '                End If
                '            End If

                '        End If
                '        fnCONTROLDATOS = True
                '    End If
                '    '  objGuiaEnvio.iCONTROL = 1
                'Else
                '    MsgBox("No puede Ingresar Fecha Guia Mayor a Hoy ni menor a 01/01/1996, Operacion cancelada", MsgBoxStyle.Information, "Seguridad Sistema")
                '    Me.txtFechaGuia.Text = dtoUSUARIOS.m_sFecha
                '    Me.txtFechaGuia.SelectAll()
                '    Return True
                'End If
            ElseIf msg.WParam.ToInt32 = Keys.F4 Then
                txtDestinatario.Focus()
                txtDestinatario.SelectAll()
            ElseIf msg.WParam.ToInt32 = Keys.F10 Then
                txtiWinDestino.SelectAll()
                txtiWinDestino.Focus()
            ElseIf msg.WParam.ToInt32 = Keys.F6 Then
                iFlagControl = False
                TxtRuc.SelectAll()
                TxtRuc.Focus()
            ElseIf msg.WParam.ToInt32 = Keys.F11 Then
                If Me.btnArticulo.Enabled Then
                    fnControl_Articulos()
                End If
                'ElseIf msg.WParam.ToInt32 = Keys.PrintScreen Then
                '    'fnControl_Articulos()
                '    TabMante.SelectedIndex = 0
            ElseIf msg.WParam.ToInt32 = Keys.F9 Then
                iFlagControl = True
                If fArticulo = False Then
                    dtGridViewBultos.Focus()
                    dtGridViewBultos.CurrentCell = dtGridViewBultos.Rows(0).Cells(2)
                    dtGridViewBultos.Rows(0).Cells(2).Selected = True
                Else
                    dtGridViewArticulo.Focus()
                    dtGridViewArticulo.CurrentCell = dtGridViewArticulo.Rows(0).Cells(3)
                    dtGridViewArticulo.Rows(0).Cells(2).Selected = True
                End If
            ElseIf msg.WParam.ToInt32 = Keys.F8 Then
                iFlagControl = False
                DataGridViewDocumentos.Focus()
                DataGridViewDocumentos.CurrentCell = DataGridViewDocumentos.Rows(0).Cells(2)
                DataGridViewDocumentos.Rows(0).Cells(2).Selected = True
            Else
                flat = MyBase.ProcessCmdKey(msg, KeyData)
            End If
            ''Modifica 08/08/2008 - Saltos de campos 
            'If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            '    SendKeys.Send("{Tab}")
            '    Return True
            'End If

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
            objGuiaEnvio.iCONTROL = 1
        End Try
        Return flat
    End Function
    Public Function EDITAR_GuiaEnvio() As Boolean
        Try
            '---------------DETALLE DE ARTICULOS-----------
            'Mod. 24/08/2009 -->Omendoza - Pasando al datahelper   
            objGuiaEnvio.fnELIMINAR_DOC_GUIASII(objGuiaEnvio.iIDGUIAS_ENVIO)
            Dim ii As Integer = 0
            objGuia_Envio_Articulo.iCONTROL = 1
            objGuia_Envio_Articulo.iIDGUIAS_ENVIO_ARTICULOS = 0
            objGuia_Envio_Articulo.iIDGUIAS_ENVIO = objGuiaEnvio.iIDGUIAS_ENVIO
            objGuia_Envio_Articulo.iIGV = IGV
            objGuia_Envio_Articulo.iDESCUENTO = 0
            objGuia_Envio_Articulo.iPENALIDAD = 0
            objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
            objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol
            objGuia_Envio_Articulo.iIDESTADO_REGISTRO = 18

            'For ii = 0 To Me.dtGridViewArticulo.Rows().Count() - 1
            '    If IsDBNull(dtGridViewArticulo.Rows(ii).Cells(3)) = False Then
            '        If dtGridViewArticulo.Rows(ii).Cells(3).Value.ToString <> "" Then
            '            objGuia_Envio_Articulo.iIDARTICULOS = Int(dtGridViewArticulo.Rows(ii).Cells(0).Value.ToString)
            '            objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(dtGridViewArticulo.Rows(ii).Cells(3).Value.ToString)
            '            objGuia_Envio_Articulo.iPRECIO_X_ARTICULO = Microsoft.VisualBasic.Conversion.Val(dtGridViewArticulo.Rows(ii).Cells(2).Value.ToString)
            '            'If objGuia_Envio_Articulo.fnINSTUPD_GENVIO_ARTICULOS() = True Then
            '            'End If
            '        End If
            '    End If
            'Next
            '---------------DETALLE DOCUMENTOS----------------------------------
            Dim i As Integer = 0
            Dim serie_NroDoc() As String
            objGuiaEnvio.iControl_Documentos = 1
            Dim iContador As Integer = 0

            For i = 0 To Me.DataGridViewDocumentos.Rows().Count() - 2

                If IsDBNull(DataGridViewDocumentos.Rows(i).Cells(2)) = False Then
                    If DataGridViewDocumentos.Rows(i).Cells(2).Value.ToString <> "" Then
                        serie_NroDoc = Split(DataGridViewDocumentos.Rows(i).Cells(2).Value.ToString, "-")
                        If serie_NroDoc.Length > 1 Then
                            objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                            objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                            If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                'If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
                                'Mod. 27/08/2009 -->Omendoza - Pasando al datahelper   
                                If objGuiaEnvio.fnINSUPD_DOCUMENTOS_GUIAS() = True Then
                                    iContador = iContador + 1
                                End If
                                'End If
                            End If
                        End If
                    End If
                End If
                If IsDBNull(DataGridViewDocumentos.Rows(i).Cells(3)) = False Then
                    If DataGridViewDocumentos.Rows(i).Cells(3).Value.ToString <> "" Then
                        serie_NroDoc = Split(DataGridViewDocumentos.Rows(i).Cells(3).Value.ToString, "-")
                        If serie_NroDoc.Length > 1 Then
                            objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                            objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                            If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                'If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) >= 0 Then
                                'Mod. 27/08/2009 -->Omendoza - Pasando al datahelper   
                                If objGuiaEnvio.fnINSUPD_DOCUMENTOS_GUIAS() = True Then
                                    iContador = iContador + 1
                                End If
                                'End If
                            End If
                        End If
                    End If
                End If
            Next

            'fnNUEVO()
        Catch ex As Exception
            'MsgBox("Verifique sus Datos No puede editar los Documentos", MsgBoxStyle.Information, "Seguridad Sistema")
            MsgBox("Grabo Correctamente Sus datos...", MsgBoxStyle.Information, "Seguridad Sistema")
            'fnNUEVO()
        End Try
        Return False
    End Function
    Private Sub fnControl_Articulos()
        Try
            Dim i As Integer = 0
            If fArticulo = False Then
                If dtGridViewArticulo.Rows().Count >= 1 Then
                    fArticulo = True
                    dtGridViewBultos.Visible = False
                    dtGridViewArticulo.Visible = True
                    lbEtiquetaControl.Text = "( F11 ) PESO VOLUMEN"
                    dtGridViewArticulo.Focus()
                    fnControlArticulo_Peso()
                    cargar_articulos()
                    'fnArticulo_Peso()
                    '15/08/2008 - Visualiza la base 
                    '
                    Me.txt_base.Visible = True
                    Me.lb_base.Visible = True
                Else
                    Me.txt_base.Visible = False
                    Me.lb_base.Visible = False
                    MsgBox("No Puede realizar esta Operaciòn, No Tiene Articulos Asociados", MsgBoxStyle.Information, "Seguridad Sistema")
                End If
            Else
                fArticulo = False
                dtGridViewBultos.Visible = True
                dtGridViewArticulo.Visible = False
                '15/08/2008 - Oculta la base 
                Me.txt_base.Visible = False
                Me.lb_base.Visible = False
                lbEtiquetaControl.Text = "( F11 ) ARTICULOS"
                dtGridViewBultos.Focus()
                fnControlArticulo_Peso()
                'fnArticulo_Peso()
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub fnControlArticulo_Peso()
        Try
            Me.txtSubTotal.Text = "0.00"
            Me.txMontotIGV.Text = "0.00"
            Me.txtTotal_Pago.Text = "0.00"

            Dim i As Integer = 0
            For i = 0 To 2
                dtGridViewBultos(2, i).Value() = ""
                dtGridViewBultos(3, i).Value() = ""
                dtGridViewBultos(5, i).Value() = "0.00"
                'dtGridViewBultos(4, i).Value() = "0.00"  16/08/2008 - como se recupera  
            Next

            For i = 0 To dtGridViewArticulo.Rows.Count
                dtGridViewArticulo(5, i).Value() = "0.00"
                dtGridViewArticulo(4, i).Value() = ""
                dtGridViewArticulo(3, i).Value() = ""
            Next

            Me.txtSubTotal.Text = "0.00"
            Me.txMontotIGV.Text = "0.00"
            Me.txtTotal_Pago.Text = "0.00"
            Me.Update()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub fnArticulo_Peso()
        Try
            Dim i As Integer = 0
            For i = 0 To 2
                dtGridViewBultos(2, i).Value() = ""
                dtGridViewBultos(3, i).Value() = ""
                dtGridViewBultos(4, i).Value() = "0.00"
            Next
            For i = 1 To dtGridViewArticulo.Rows.Count
                dtGridViewArticulo.Rows().RemoveAt(0)
            Next
            txtSubTotal.Text = "0.00"
            txMontotIGV.Text = "0.00"
            txtTotal_Pago.Text = "0.00"
        Catch ex As Exception

        End Try
    End Sub
    Private Sub numericTextboxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDNIRemitente.KeyPress, txtTelefonoRemitente.KeyPress, TxtGuiaEnvio.KeyPress, txtTelefonoDestinatario.KeyPress, txtDNIDestinatario.KeyPress, TxtRuc.KeyPress, txtDocCliente_Remitente.KeyPress, txtNroDocumento.KeyPress, txtCantidadSobres.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
                'ElseIf e.KeyChar = "." Then
                'If Not (tb.SelectedText = "." Or IsNumeric(tb.Text & e.KeyChar)) Then
                'e.Handled = True
                'End If
                'ElseIf e.KeyChar = "-" Then
                'If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
                'e.Handled = True
                'End If
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub
    Private Function fnControl_Guias_Envio() As Boolean
        Dim flag As Boolean = True
        Try
            TxtGuiaEnvio.Text = IIf(TxtGuiaEnvio.Text.Length() > 0, TxtGuiaEnvio.Text, 0)
            If TxtGuiaEnvio.Text = "" Or Int(TxtGuiaEnvio.Text.ToString) <= 0 Then
                ErrorProvider.SetError(Me.TxtGuiaEnvio, "Debe Ingresar un Valor valido")
                MsgBox("Debe Ingresar un Nro Valido de Guia de Envio", MsgBoxStyle.Information, "Seguridad Sistema")
                TxtGuiaEnvio.Focus()
                flag = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            flag = False
        End Try
        Return flag
    End Function
    Private Function Grabar_GuiaEnvio() As Boolean
        Dim flat As Boolean = True
        Dim lb_valida As Boolean
        '
        'If fnDigito_Chequeo(TxtGuiaEnvio.Text) = False Then
        '    MsgBox("El Nro de Guia de Envio no es Valido", MsgBoxStyle.Information, "Seguridad Sistema")
        '    Return False
        'End If

        Try
            '19/08/2008 ' Valida que ingrese el peso y el volumen 
            If Me.dtGridViewArticulo.Visible = False Then
                lb_valida = fw_valida_bultos_y_peso()
                If lb_valida = False Then
                    Exit Function
                End If
            End If
            '
            'objGuiaEnvio.iCONTROL = 1
            'ModuUtil.LlenarComboIDs(ObjVentaCargaContado.rstVarAgencias, cmbAgenciaVenta, ObjVentaCargaContado.coll_AgenciasVenta, Int(ObjVentaCargaContado.rstVarAgencias.Fields(0).Value))
            objGuiaEnvio.iIDAGENCIAS_DESTINO = ObjVentaCargaContado.coll_AgenciasVenta.Item(cmbAgenciaVenta.SelectedIndex.ToString)
            If fnControl_Guias_Envio() = False Then
                flat = False
                ErrorProvider.SetError(TxtGuiaEnvio, "Debe Ingresar un valor Valido de Guia de Envio")
                MsgBox("Ingrese Un Valor valido de Guia", MsgBoxStyle.Information, "Seguridad del Sistema")
                TxtGuiaEnvio.SelectAll()
                TxtGuiaEnvio.Focus()
                GoTo CONTROL_SALIDA
            End If

            If objGuiaEnvio.iCONTROL = 1 Then
                objGuiaEnvio.iID_REMITENTE = 0
                objGuiaEnvio.iIDCONTACTO_PERSONA = 0
                objGuiaEnvio.iIDCONTACTO_DESTINATARIO = 0
                objGuiaEnvio.iIDDIRECCION_CONSIGNADO = 0
                objGuiaEnvio.iIDDIRECCION_DESTINATARIO = 0
                objGuiaEnvio.iIDDIRECCION_REMITENTE = 0
                objGuiaEnvio.iIDTEFONO_CONSIGNADO = 0
                objGuiaEnvio.iIDTEFONO_REMITENTE = 0
                objGuiaEnvio.iIDGUIAS_ENVIO = 0
            Else
                If objGuiaEnvio.iCONTROL = 2 Then
                    If objGuiaEnvio.iIDGUIAS_ENVIO <= 0 Then
                        MsgBox("Error Revise sus datos...el IDGUIA ENVIO ES: " & objGuiaEnvio.iIDGUIAS_ENVIO.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
                        Return False
                    End If
                Else
                    MsgBox("Error Revise sus datos...Operacion No Permitida", MsgBoxStyle.Information, "Seguridad Sistema")
                    Return False
                End If

            End If
            'hlamas 22-06-2010
            'Verifica si Cantidad (pieza o bulto) de Tipos(peso,volumen) tienen su peso/volumen asociado
            'Peso
            If Val(dtGridViewBultos.Rows(0).Cells(3).Value) > 0 And Val(dtGridViewBultos.Rows(0).Cells(2).Value) = 0 Then
                MessageBox.Show("Debe ingresar Nº de Piezas o Bultos para Tipo Peso.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            'Volumen
            If Val(dtGridViewBultos.Rows(1).Cells(3).Value) > 0 And Val(dtGridViewBultos.Rows(1).Cells(2).Value) = 0 Then
                MessageBox.Show("Debe ingresar Nº de Piezas o Bultos para Tipo Volumen.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            TxtGuiaEnvio.Text = RellenoRight(NroDigitos_Guias, TxtGuiaEnvio.Text)
            objGuiaEnvio.sFECHA_GUIA = txtFechaGuia.Text 'Format(Me.txtFechaGuia.Text, "dd/mm/yyyy")
            objGuiaEnvio.sNRO_GUIA = RellenoRight(NroDigitos_Guias, TxtGuiaEnvio.Text)
            Dim idPersona As Integer = iWinPerosa.IndexOf(TxtRasonSocial.Text)
            objGuiaEnvio.iIDPERSONA = Int(coll_Lista_Personas.Item(idPersona.ToString))
            'cmbSubCuenta
            objGuiaEnvio.iIDTIPO_ENTREGA_CARGA = Int(objGuiaEnvio.coll_Lista_Tipo_Entrega.Item(Me.cmbTipo_Entrega.SelectedIndex.ToString()))
            objGuiaEnvio.iIDFORMA_PAGO = Int(objGuiaEnvio.coll_Lista_Forma_Pagos.Item(Me.cmbFormaCredito.SelectedIndex.ToString()))
            If txtiWinOrigen.Text = txtiWinDestino.Text Then
                MsgBox("No Puede ser el Origen igual Al destino...", MsgBoxStyle.Information, "Seguridad Sistema")
                ErrorProvider.SetError(txtiWinDestino, "Debe Ingresar un valor Valido de Guia de Envio")
                txtiWinDestino.SelectAll()
                txtiWinDestino.Focus()
                flat = False
                GoTo CONTROL_SALIDA
            End If
            If txtiWinOrigen.Text = "" Then
                MsgBox("No Puede Realizar esta Operacion, revice datos de Origen ", MsgBoxStyle.Information, "Seguridad Sistema")
                ErrorProvider.SetError(txtiWinOrigen, "Debe Ingresar un valor Valido de Guia de Envio")
                txtiWinOrigen.SelectAll()
                txtiWinOrigen.Focus()
                flat = False
                GoTo CONTROL_SALIDA
            End If
            If txtiWinDestino.Text = "" Then
                MsgBox("No Puede Realizar esta Operacion, revice datos de Destino ", MsgBoxStyle.Information, "Seguridad Sistema")
                ErrorProvider.SetError(txtiWinDestino, "Debe Ingresar un valor Valido de Guia de Envio")
                txtiWinDestino.SelectAll()
                txtiWinDestino.Focus()
                flat = False
                GoTo CONTROL_SALIDA
            End If

            objGuiaEnvio.iIDUNIDAD_AGENCIA = Int(coll_iOrigen.Item(iWinDestino.IndexOf(txtiWinOrigen.Text) + 1))
            objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = Int(coll_iDestino.Item(iWinDestino.IndexOf(txtiWinDestino.Text) + 1))
            objGuiaEnvio.iIDCIUDAD_TRANSITO = objGuiaEnvio.iIDUNIDAD_AGENCIA
            If objGuiaEnvio.iIDUNIDAD_AGENCIA = objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO Then
                MsgBox("No Puede Realizar esta Operacion, Origen y Destino Iguales", MsgBoxStyle.Information, "Seguridad Sistema")
                flat = False
                GoTo CONTROL_SALIDA
            End If
            '
            ErrorProvider.Clear()
            '
            'objGuiaEnvio.iIDUNIDAD_AGENCIA = Int(objGuiaEnvio.coll_Lista_Forma_Pagos.Item(Me.cmbFormaCredito.SelectedIndex.ToString()))
            'objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = Int(objGuiaEnvio.coll_Lista_Unidades_Origen.Item(iWinDestino.IndexOf(txtiWinDestino.Text)))
            'objGuiaEnvio.iIDCIUDAD_TRANSITO = Int(coll_iOrigen.Item(iWinOrigen.IndexOf(txtiWinOrigen.Text)))
            '
            '
            ' 12/08/2008 - Si la guia de envio es editada no deberia cambiar la agencia
            '
            If lb_datos_editados = False Then
                objGuiaEnvio.iIDAGENCIAS = coll_AgenciasOrigen.Item(Me.cmbAgenciaOrigen.SelectedIndex.ToString)
                'objGuiaEnvio.iIDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
            End If
            If txtRemitente.Text = "" Then
                MsgBox("No Puede Realizar esta Operacion, Debe ingresar un Contacto", MsgBoxStyle.Information, "Seguridad Sistema")
                flat = False
                txtRemitente.Focus()
                GoTo CONTROL_SALIDA
            End If
            Dim indexof As Integer = 0

            If iWinContacto_Remitente.Count > 0 And objGuiaEnvio.coll_Nombres_Remitente.Count > 0 Then
                'indexof = IIf(iWinContacto_Remitente.IndexOf(txtRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtRemitente.Text), -1)
                indexof = IIf(iWinContacto_Remitente.IndexOf(txtRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtRemitente.Text), -1)
                objGuiaEnvio.iIDCONTACTO_REMITENTE = -1
                If indexof >= 0 Then
                    objGuiaEnvio.iIDCONTACTO_REMITENTE = Int(objGuiaEnvio.coll_Nombres_Remitente.Item(indexof.ToString))
                End If
            End If
            '  objGuiaEnvio.iIDCONTACTO_REMITENTE = -1
            If iWinDireccion_Remitente.Count > 0 Then
                indexof = iWinDireccion_Remitente.IndexOf(txtDireccionRemitente.Text)
                objGuiaEnvio.iIDDIRECCION_REMITENTE = -1
                If indexof >= 0 Then
                    objGuiaEnvio.iIDDIRECCION_REMITENTE = Int(objGuiaEnvio.coll_Direccion_Remitente.Item(indexof.ToString))
                End If
            End If
            If iWinTelefono_Remitente.Count > 0 Then
                indexof = iWinTelefono_Remitente.IndexOf(txtTelefonoRemitente.Text)
                objGuiaEnvio.iIDTEFONO_REMITENTE = -1
                If indexof >= 0 Then
                    objGuiaEnvio.iIDTEFONO_REMITENTE = Int(objGuiaEnvio.coll_Telefono_Remitente.Item(indexof.ToString))
                End If
            End If
            'Destinatario
            If objGuiaEnvio.coll_Nombres_Destinatario.Count > 0 And iWinContacto_Destinatario.Count > 0 Then
                indexof = iWinContacto_Destinatario.IndexOf(txtDestinatario.Text)
                objGuiaEnvio.iIDCONTACTO_DESTINATARIO = -1
                If indexof >= 0 Then
                    objGuiaEnvio.iIDCONTACTO_DESTINATARIO = Int(objGuiaEnvio.coll_Nombres_Destinatario.Item(indexof.ToString))
                End If
            End If

            If iWinDireccion_Destinatario.Count > 0 Then
                indexof = iWinDireccion_Destinatario.IndexOf(txtDireccionDestinatario.Text)
                objGuiaEnvio.iIDDIRECCION_DESTINATARIO = -1
                If indexof >= 0 Then
                    objGuiaEnvio.iIDDIRECCION_DESTINATARIO = Int(objGuiaEnvio.coll_Direccion_Destinatario.Item(indexof.ToString))
                Else '27/08/2008
                    If Me.txtDireccionDestinatario.Text <> "" Then
                        objGuiaEnvio.iIDDIRECCION_DESTINATARIO = 0
                    End If
                End If
            Else
                If Me.txtDireccionDestinatario.Text <> "" Then
                    objGuiaEnvio.iIDDIRECCION_DESTINATARIO = 0
                End If
            End If
            If iWinTelefono_Destinatario.Count > 0 Then
                indexof = iWinTelefono_Destinatario.IndexOf(txtTelefonoDestinatario.Text)
                objGuiaEnvio.iIDTEFONO_CONSIGNADO = -1
                If indexof >= 0 Then
                    objGuiaEnvio.iIDTEFONO_CONSIGNADO = Int(objGuiaEnvio.coll_Telefono_Destinatario.Item(indexof.ToString))
                End If
            End If

            objGuiaEnvio.iCANTIDAD = 0  'Unidades Peso
            objGuiaEnvio.iCANTIDAD_X_UNIDAD_VOLUMEN = 0 'Unidades Volumen
            objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = 0 'Unidades Articulos

            objGuiaEnvio.dTOTAL_VOLUMEN = 0

            Dim totalCosto As Double = 0
            Dim valor1 As Double = 0
            Dim valor2 As Double = 0
            objGuiaEnvio.dMONTO_BASE = Format(Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(4, 2).Value.ToString)), "##,###,####.00") ' Base

            'Analizar esta parte - 16/08/2008
            If IsDBNull(dtGridViewBultos.Rows(0).Cells(2)) = False Then
                '16/08/2008 - comentado 
                'valor1 = Format(Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(3, 0).Value.ToString)), "##,###,####.00")
                valor1 = Format(Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(3, 0).Value.ToString)), "##,###,####.00")
                '
                valor2 = Format(Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(2, 0).Value.ToString)), "##,###,####.00")
                objGuiaEnvio.iCANTIDAD = valor2
                valor2 = Format(Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(4, 0).Value.ToString)), "##,###,####.00") ' Costo 
                objGuiaEnvio.dTOTAL_PESO = valor1
                totalCosto = valor1 * valor2
            End If
            If IsDBNull(dtGridViewBultos.Rows(1).Cells(2)) = False And dtGridViewBultos.Rows(1).Cells(2).Value.ToString <> "" Then
                '14/08/2008 - Comentado 
                'valor1 = Format(Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(3, 1).Value.ToString)), "##,###,###.00")
                valor2 = Format(Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(2, 1).Value.ToString)), "##,###,###.00")
                objGuiaEnvio.iCANTIDAD_X_UNIDAD_VOLUMEN = valor2
                valor1 = Format(Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(4, 1).Value.ToString)), "##,###,###.00")
                '
                valor2 = Format(Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(3, 1).Value.ToString)), "##,###,###.00")
                objGuiaEnvio.dTOTAL_VOLUMEN = valor2

                totalCosto = totalCosto + valor1 * valor2 + Monto_Base
            End If

            If Me.dtGridViewArticulo.Visible = True Then
                objGuiaEnvio.dTOTAL_PESO = fn_peso_desde_articulos()
            End If

            If Me.dtGridViewArticulo.Visible = True Then
                objGuiaEnvio.dTOTAL_VOLUMEN = fn_Volumen_desde_articulos()
            End If

            objGuiaEnvio.iCARGO = Int(chechCargo.Checked)

            'If IsDBNull(DataGridViewDocumentos.Rows(2).Cells(2)) = False Then
            'If IsDBNull(dtGridViewBultos.Rows(2).Cells(2)) = False Then
            '    valor1 = Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(3, 2).Value.ToString))
            '    valor2 = Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(2, 2).Value.ToString))
            '    objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = valor2
            '    totalCosto = totalCosto + valor1 * valor2
            'End If

            totalCosto = totalCosto + tarifa_Sobre * Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
            '
            If lb_datos_editados = True Then '19/08/2008 - Pasando la nueva tarifa 
                objGuiaEnvio.dMONTO_BASE = Format(Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(4, 2).Value.ToString)), "##,###,####.00") ' Base
                objGuiaEnvio.iPrecio_x_Volumen = Format(Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(4, 1).Value.ToString)), "##,###,####.00") ' Costo x volumen 
                objGuiaEnvio.iPrecio_x_Peso = Format(Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(4, 0).Value.ToString)), "##,###,####.00") ' Costo x Peso                 
                objGuiaEnvio.iTarifa_Publica_Monto_Peso = objGuiaEnvio.iPrecio_x_Peso
                objGuiaEnvio.iTarifa_Publica_Monto_Volumen = objGuiaEnvio.iPrecio_x_Volumen
            End If
            '
            '----------------------------------------------------------------------------------------------------------------------
            If Me.txtRemitente.Text <> "" And Me.txtRemitente.Text.Length > 3 Then
                objGuiaEnvio.iNOMBRES_REMITENTE = Me.txtRemitente.Text
            Else
                objGuiaEnvio.iNOMBRES_REMITENTE = "NULL"
                'ErrorProvider.SetError(txtRemitente, "Debe Registrar El Los Nombres ApePat ApeMat, Nombres del Remitente...")
                'txtRemitente.Focus()
                'Return False
            End If

            If txtDNIRemitente.Text <> "" And txtDNIRemitente.Text.Length > 5 Then
                objGuiaEnvio.iDNI_REMITENTE = Me.txtDNIRemitente.Text
            Else
                objGuiaEnvio.iDNI_REMITENTE = "@"
                'ErrorProvider.SetError(txtDNIRemitente, "Debe Registrar El DNI  del  Remitente...")
                'txtDNIRemitente.Focus()
                'Return False
            End If

            If txtDireccionRemitente.Text <> "" And txtDireccionRemitente.Text.Length > 5 Then
                objGuiaEnvio.iDIRECCION_REMITENTE = txtDireccionRemitente.Text
            Else
                ErrorProvider.SetError(txtDireccionRemitente, "Debe Registrar la Direccion de Remitente...")
                txtDireccionRemitente.Focus()
                Return False
            End If

            objGuiaEnvio.sTelefono_Remitente = IIf(txtTelefonoRemitente.Text <> "", txtTelefonoRemitente.Text, "NULL")

            'If txtTelefonoRemitente.Text <> "" And txtTelefonoRemitente.Text.Length > 5 Then
            '    objGuiaEnvio.sTelefono_Remitente = txtTelefonoRemitente.Text
            'Else
            '    ErrorProvider.SetError(txtTelefonoRemitente, "Debe Registrar El Telefono de Remitente...")
            '    txtTelefonoRemitente.Focus()
            '    Return False
            'End If


            'DESTINATARIO...
            If txtDestinatario.Text <> "" And txtDestinatario.Text.Length > 5 Then
                objGuiaEnvio.iNOMBRES_DESTINATARIO = txtDestinatario.Text
            Else
                ErrorProvider.SetError(txtDestinatario, "Debe Registrar la Direccion de Destinatario...")
                txtDestinatario.Focus()
                Return False
            End If
            If txtDNIDestinatario.Text <> "" Then '19/08/2008 -  And txtDNIDestinatario.Text.Length > 5 Then ---> No se sabe el nº dcto del consignado
                objGuiaEnvio.iDNI_DESTINATARIO = txtDNIDestinatario.Text
            Else
                ErrorProvider.SetError(txtDNIDestinatario, "Debe registrar documento del consignado...")
                txtDNIDestinatario.Focus()
                Return False
            End If
            If txtDireccionDestinatario.Text <> "" And txtDireccionDestinatario.Text.Length > 5 Then
                objGuiaEnvio.iDIRECCION_DESTINATARIO = txtDireccionDestinatario.Text
            Else
                ErrorProvider.SetError(txtDireccionDestinatario, "Debe Registrar la Direccion de Destinatario...")
                txtDireccionDestinatario.Focus()
                Return False
            End If

            'objGuiaEnvio.sTelefono_Destinatario = IIf(txtTelefonoDestinatario.Text.Length > 5, txtTelefonoDestinatario.Text.Length, "NULL")
            objGuiaEnvio.sTelefono_Destinatario = IIf(txtTelefonoDestinatario.Text <> "", txtTelefonoDestinatario.Text, "NULL")
            'If txtTelefonoDestinatario.Text <> "" And txtTelefonoDestinatario.Text.Length > 5 Then
            '    objGuiaEnvio.sTelefono_Destinatario = txtTelefonoDestinatario.Text
            'Else
            '    ErrorProvider.SetError(txtTelefonoDestinatario, "Debe Registrar El Telefono de Destinatario...")
            '    txtTelefonoDestinatario.Focus()
            '    Return False
            'End If

            '   VALIDACION QUE INGRESO EL PESO AL ARTICULO
            If fArticulo = True Then

                For ii1 As Integer = 0 To Me.dtGridViewArticulo.Rows().Count() - 1
                    If dtGridViewArticulo.Rows(ii1).Cells(3).Value.ToString.Trim <> "" And dtGridViewArticulo.Rows(ii1).Cells(3).Value.ToString.Trim <> "0.00" And dtGridViewArticulo.Rows(ii1).Cells(3).Value.ToString.Trim <> "0" And IsNumeric(dtGridViewArticulo.Rows(ii1).Cells(3).Value) Then
                        If dtGridViewArticulo.Rows(ii1).Cells(5).Value.ToString.Trim = "0.00" Or dtGridViewArticulo.Rows(ii1).Cells(5).Value.ToString.Trim = "0" Or Not (IsNumeric(dtGridViewArticulo.Rows(ii1).Cells(5).Value)) Then
                            ErrorProvider.SetError(dtGridViewArticulo, "Debe ingresar el peso...")
                            MsgBox("Debe Ingresar el peso...", MsgBoxStyle.Critical, "Seguridad del Sistema")
                            Return False
                        End If
                    End If

                Next


                'validando el peso para metro cubico
                For ii1 As Integer = 0 To Me.dtGridViewArticulo.Rows().Count() - 1
                    If dtGridViewArticulo.Rows(ii1).Cells(0).Value.ToString.Trim = "211" Then
                        If dtGridViewArticulo.Rows(ii1).Cells(4).Value.ToString.Trim <> "" And dtGridViewArticulo.Rows(ii1).Cells(3).Value.ToString.Trim <> "0.00" And dtGridViewArticulo.Rows(ii1).Cells(4).Value.ToString.Trim <> "0" And IsNumeric(dtGridViewArticulo.Rows(ii1).Cells(4).Value) Then
                            If dtGridViewArticulo.Rows(ii1).Cells(5).Value.ToString.Trim = "0.00" Or dtGridViewArticulo.Rows(ii1).Cells(5).Value.ToString.Trim = "0" Or Not (IsNumeric(dtGridViewArticulo.Rows(ii1).Cells(5).Value)) Then
                                ErrorProvider.SetError(dtGridViewArticulo, "Debe ingresar el peso...")
                                MsgBox("Debe Ingresar el peso...", MsgBoxStyle.Critical, "Seguridad del Sistema")
                                Return False
                            End If
                        End If
                    End If
                Next

                'validando la cantidad para metro cubico
                For ii1 As Integer = 0 To Me.dtGridViewArticulo.Rows().Count() - 1
                    If dtGridViewArticulo.Rows(ii1).Cells(0).Value.ToString.Trim = "211" Then
                        If dtGridViewArticulo.Rows(ii1).Cells(3).Value.ToString.Trim <> "" And dtGridViewArticulo.Rows(ii1).Cells(3).Value.ToString.Trim <> "0.00" And dtGridViewArticulo.Rows(ii1).Cells(3).Value.ToString.Trim <> "0" And IsNumeric(dtGridViewArticulo.Rows(ii1).Cells(3).Value) Then
                            If dtGridViewArticulo.Rows(ii1).Cells(5).Value.ToString.Trim = ".00" Or dtGridViewArticulo.Rows(ii1).Cells(5).Value.ToString.Trim = "0.00" Or dtGridViewArticulo.Rows(ii1).Cells(5).Value.ToString.Trim = "0" Or Not (IsNumeric(dtGridViewArticulo.Rows(ii1).Cells(5).Value)) Then
                                ErrorProvider.SetError(dtGridViewArticulo, "Debe ingresar el peso...")
                                MsgBox("Debe Ingresar el peso...", MsgBoxStyle.Critical, "Seguridad del Sistema")
                                Return False
                            End If
                        End If
                    End If
                Next

                'valida que el ingreso sea de catidad obligatoriamente para  metro cubico con respecto culumna metro cubico
                For ii1 As Integer = 0 To Me.dtGridViewArticulo.Rows().Count() - 1
                    If dtGridViewArticulo.Rows(ii1).Cells(4).Value.ToString.Trim <> "" And dtGridViewArticulo.Rows(ii1).Cells(4).Value.ToString.Trim <> "0.00" And dtGridViewArticulo.Rows(ii1).Cells(4).Value.ToString.Trim <> "0" And IsNumeric(dtGridViewArticulo.Rows(ii1).Cells(4).Value) Then
                        If dtGridViewArticulo.Rows(ii1).Cells(3).Value.ToString.Trim = ".00" Or dtGridViewArticulo.Rows(ii1).Cells(3).Value.ToString.Trim = "0.00" Or dtGridViewArticulo.Rows(ii1).Cells(3).Value.ToString.Trim = "0" Or Not (IsNumeric(dtGridViewArticulo.Rows(ii1).Cells(3).Value)) Then
                            ErrorProvider.SetError(dtGridViewArticulo, "Debe ingresar la cantidad...")
                            MsgBox("Debe Ingresar la cantidad...", MsgBoxStyle.Critical, "Seguridad del Sistema")
                            Return False
                        End If
                    End If

                Next
            End If

            If fArticulo = True Then
                Dim Total As Double = 0
                Dim ii1 As Integer = 0
                For ii1 = 0 To Me.dtGridViewArticulo.Rows().Count() - 1
                    Total = Total + Microsoft.VisualBasic.Conversion.Val(dtGridViewArticulo.Rows(ii1).Cells(3).Value.ToString)
                    objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI + Microsoft.VisualBasic.Conversion.Val(dtGridViewArticulo.Rows(ii1).Cells(3).Value.ToString)
                Next
            End If



            'objGuiaEnvio.dMONTO_BASE = Monto_Base '26/08/2008  Se toma el valor de los bultos 
            objGuiaEnvio.dPRECIO_X_UNIDAD = tarifa_Articulo 'kgr
            objGuiaEnvio.dIMPUESTO = IGV
            'objGuiaEnvio.dTOTAL_COSTO = Microsoft.VisualBasic.Conversion.Val(Me.txtTotal_Pago.Text)
            objGuiaEnvio.dMONTO_IMPUESTO = Me.txMontotIGV.Text
            objGuiaEnvio.dTOTAL_COSTO = Me.txtTotal_Pago.Text
            objGuiaEnvio.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            objGuiaEnvio.iIDROL_USUARIO = dtoUSUARIOS.IdRol
            objGuiaEnvio.sIP = dtoUSUARIOS.IP
            objGuiaEnvio.iIDESTADO_REGISTRO = 18
            objGuiaEnvio.iREMITENTE = txtCliente_Remitente.Text
            objGuiaEnvio.iNRODOC_REM = txtDocCliente_Remitente.Text
            objGuiaEnvio.iIDCENTRO_COSTO = Int(objGuiaEnvio.coll_Sub_Cuenta.Item(cmbSubCuenta.SelectedIndex.ToString))

            If checkSobres.Checked = True Then
                objGuiaEnvio.iCANTIDAD_SOBRES = Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
                objGuiaEnvio.iIDSINO_SOBRES = 1
            Else

                objGuiaEnvio.iCANTIDAD_SOBRES = 0
                objGuiaEnvio.iIDSINO_SOBRES = 0
            End If

            iTOTAL_BULTOS = ""
            iTOTAL_VOLUMEN = ""
            iTOTAL_PESO = ""
            'Mod. 28/08/2009 -->Omendoza - Pasando al datahelper   
            If objGuiaEnvio.Grabar() = True Then
                iTOTAL_BULTOS = objGuiaEnvio.iCANTIDAD + objGuiaEnvio.iCANTIDAD_X_UNIDAD_VOLUMEN + objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI + objGuiaEnvio.iCANTIDAD_SOBRES
                iTOTAL_VOLUMEN = objGuiaEnvio.dTOTAL_VOLUMEN
                iTOTAL_PESO = objGuiaEnvio.dTOTAL_PESO
                '---------------DETALLE DE ARTICULOS
                Dim ii As Integer = 0
                objGuia_Envio_Articulo.iCONTROL = 1
                objGuia_Envio_Articulo.iIDGUIAS_ENVIO_ARTICULOS = 0
                objGuia_Envio_Articulo.iIDGUIAS_ENVIO = objGuiaEnvio.iIDGUIAS_ENVIO
                objGuia_Envio_Articulo.iIGV = IGV
                objGuia_Envio_Articulo.iDESCUENTO = 0
                objGuia_Envio_Articulo.iPENALIDAD = 0
                objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
                objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol
                objGuia_Envio_Articulo.iIDESTADO_REGISTRO = 18
                For ii = 0 To Me.dtGridViewArticulo.Rows().Count() - 1
                    If IsDBNull(dtGridViewArticulo.Rows(ii).Cells(3)) = False Then
                        If dtGridViewArticulo.Rows(ii).Cells(3).Value.ToString <> "" Then
                            objGuia_Envio_Articulo.iIDARTICULOS = Int(dtGridViewArticulo.Rows(ii).Cells(0).Value.ToString)


                            objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(dtGridViewArticulo.Rows(ii).Cells(3).Value.ToString)

                            If dtGridViewArticulo.Rows(ii).Cells(4).Value.ToString = "" Then
                                objGuia_Envio_Articulo.iMETRO_CUBICO = 0
                            Else
                                objGuia_Envio_Articulo.iMETRO_CUBICO = CDbl(dtGridViewArticulo.Rows(ii).Cells(4).Value.ToString)
                            End If

                            If dtGridViewArticulo.Rows(ii).Cells(5).Value.ToString = "" Then
                                objGuia_Envio_Articulo.iPESO = 0
                            Else
                                objGuia_Envio_Articulo.iPESO = CDbl(dtGridViewArticulo.Rows(ii).Cells(5).Value.ToString)
                            End If

                            objGuia_Envio_Articulo.iPRECIO_X_ARTICULO = Microsoft.VisualBasic.Conversion.Val(dtGridViewArticulo.Rows(ii).Cells(2).Value.ToString)
                            'Mod. 21/08/2009 -->Omendoza - Pasando al datahelper   
                            'If objGuia_Envio_Articulo.fnINSTUPD_GENVIO_ARTICULOS_RGT() = True Then
                            'End If
                            objGuia_Envio_Articulo.fnINSTUPD_GENVIO_ARTICULOS_RGT()
                            '
                        End If

                    End If

                Next
                '---------------DETALLE DOCUMENTOS----------------------------------
                flat = True
                Dim i As Integer = 0
                Dim serie_NroDoc() As String
                objGuiaEnvio.iControl_Documentos = objGuiaEnvio.iCONTROL
                Dim iContador As Integer = 0
                If objGuiaEnvio.iCONTROL = 1 Then
                    For i = 0 To Me.DataGridViewDocumentos.Rows().Count() - 2
                        Try
                            If IsDBNull(DataGridViewDocumentos.Rows(i).Cells(2)) = False Then
                                If DataGridViewDocumentos.Rows(i).Cells(2).Value.ToString <> "" Then
                                    serie_NroDoc = Split(DataGridViewDocumentos.Rows(i).Cells(2).Value.ToString, "-")
                                    If serie_NroDoc.Length > 1 Then
                                        objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                        objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                                        strNroGuias_Remision = strNroGuias_Remision & "  " & objGuiaEnvio.iNro_Serie & "-" & objGuiaEnvio.iNro_Docu
                                        If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                            'If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
                                            'Mod. 27/08/2009 -->Omendoza - Pasando al datahelper   
                                            If objGuiaEnvio.fnINSUPD_DOCUMENTOS_GUIAS() = True Then
                                                iContador = iContador + 1
                                            End If
                                            'End If
                                        End If
                                    End If
                                End If
                            End If
                        Catch ex As Exception
                            'MsgBox("....")
                        End Try

                        Try
                            If IsDBNull(DataGridViewDocumentos.Rows(i).Cells(3)) = False Then
                                If DataGridViewDocumentos.Rows(i).Cells(3).Value.ToString <> "" Then
                                    serie_NroDoc = Split(DataGridViewDocumentos.Rows(i).Cells(3).Value.ToString, "-")
                                    If serie_NroDoc.Length > 1 Then
                                        objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                        objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                                        strNroGuias_Remision = strNroGuias_Remision & "  " & objGuiaEnvio.iNro_Serie & "-" & objGuiaEnvio.iNro_Docu
                                        If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                            'If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
                                            'Mod. 27/08/2009 -->Omendoza - Pasando al datahelper   
                                            If objGuiaEnvio.fnINSUPD_DOCUMENTOS_GUIAS() = True Then
                                                iContador = iContador + 1
                                            End If
                                            'End If
                                        End If
                                    End If
                                End If
                            End If
                        Catch ex As Exception
                            'MsgBox("....")
                        End Try

                    Next
                End If
                'fnNUEVO()
            Else
                flat = False
                'MsgBox("Verifique sus datos.., no ha Grabado", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
CONTROL_SALIDA:
        Catch ex As Exception

            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
            flat = False
        End Try
        Return flat
    End Function
    Private Function fnControl_Tarifa_Publica() As Boolean
        Dim flat As Boolean = False
        Try
            If txtiWinOrigen.Text <> "" And txtiWinDestino.Text <> "" Then
                objGuiaEnvio.iIDUNIDAD_AGENCIA = Int(objGuiaEnvio.coll_Lista_Forma_Pagos.Item(Me.cmbFormaCredito.SelectedIndex.ToString()))
                objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = Int(objGuiaEnvio.coll_Lista_Unidades_Origen.Item(iWinDestino.IndexOf(txtiWinDestino.Text)))
                ' 29/12/2008 
                If objGuiaEnvio.iIDUNIDAD_AGENCIA > 0 And objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO > 0 Then
                    'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper   
                    flat = objGuiaEnvio.fnTARIFA_PUBLICA_CARGA()
                Else
                    flat = False
                End If
            Else
                flat = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            flat = False
        End Try
        'CONTROL_SALIDA:
        'MsgBox("No Existe Tarifa para este Origen y Destino",...)
        Return flat
    End Function

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        fnNUEVO()
    End Sub
    Private Sub fnNUEVO()

        mostrar_pre_guias = True
        '
        '15/08/2008 -> No lee la lectura.  
        '
        lb_no_lee = True
        lb_solo_visualiza = False
        '
        Dim flat As Boolean = False
        Try
            'ToolStripMenuItem1.Enabled 
            TxtGuiaEnvio.Focus()
            Limpiar_Todo()
            SelectMenu(1)
            fnVer_Datos(True)
            objGuiaEnvio.iCONTROL = 1
            If Me.dtGridViewBultos.Visible = False Then
                fnControl_Articulos()
            End If
            flag_ver_datos = False
            If ObjVentaCargaContado.fnNroDocuemnto(3) = True Then
                Me.TxtGuiaEnvio.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc)
                CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc)
                TxtGuiaEnvio.SelectAll()
                TxtGuiaEnvio.Focus()
                fnCONTROLDATOS = True
            Else
                MsgBox("No podrá realizar está operación, el Nº de la guia envío no ha configurado")
            End If
            'fnVer_Datos(False)
            cmbFormaCredito.Enabled = False
            TxtGuiaEnvio.ReadOnly = False
            ' 15/08/2080 - Siempre por defecto aparecera el grid de los bultos 
            fArticulo = False
            dtGridViewBultos.Visible = True
            ' 26/08/2008 - Habilita los datos 
            Me.cmbAgenciaOrigen.Enabled = True
            Me.txtiWinOrigen.Enabled = True
            'Me.txtiWinOrigen.Text = dtoUSUARIOS.
            Me.cmbSubCuenta.Text = ""
            '28/08/2009 - Modificado para el Data Help 
            objGuiaEnvio.iIDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
            fnAgenciaOrigen()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            flat = False
            cmbFormaCredito.Enabled = False
        End Try
    End Sub

    Private Sub fnControl_Registro_GUIA(ByVal idEstado As Integer)
        Dim flat As Boolean = False
        Try
            Dim row As Integer = dtGridViewControl_GUIAS.SelectedRows.Item(0).Index
            If dtGridViewControl_GUIAS.Rows().Count - 1 = row Then
                Return
                MsgBox("Debe Elegir Un  Item Valido...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            If row >= 0 Then
                If MsgBox("Esta Seguro de " & ContextMenuStrip1.Text & " para esta Guia de Envio Nro: " & dtGridViewControl_GUIAS.Rows(row).Cells(2).Value.ToString, MsgBoxStyle.YesNoCancel, "Seguridad Sistema") = MsgBoxResult.Yes Then
                    Dim idGuia As Integer = Int(dtGridViewControl_GUIAS.Rows(row).Cells(1).Value.ToString)
                    'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper (Agrego el else)    
                    If objGuiaEnvio.fnANULAR_GUIA_ENVIO(idGuia, idEstado) = True Then
                        MsgBox("OPERACION REALIZADA CORRECTAMENTE...", MsgBoxStyle.Information, "Seguridad Sistema")
                        dtGridViewControl_GUIAS.Rows(row).DataGridView(12, row).Value = idEstado
                        dtGridViewControl_GUIAS.UpdateCellValue(0, row)
                    Else
                        MsgBox("LA GUIA DE ENVIO NO A SIDO ANULADA...", MsgBoxStyle.Information, "Seguridad Sistema")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Function fnTarifario() As Boolean
        Dim flag As Boolean = False
        'Try -- 03/09/2009 - Se comenta x el datahelper 
        '25/09/2008 - Tepsa Iniciando las variables 
        objGuiaEnvio.iPeso_Minimo = 0
        objGuiaEnvio.iPeso_Maximo = 0
        '
        'Para Traer en una sola la tarifa Origen Destino
        bControl_Tarifas = False
        tarifa_Peso = 0
        tarifa_Volumen = 0
        tarifa_Articulo = 0
        Monto_Base = 0
        objGuiaEnvio.sNU_DOCU_SUNAT = IIf(TxtRuc.Text <> "", TxtRuc.Text, "@")
        'objGuiaEnvio.iIDUNIDAD_AGENCIA = 100
        'objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = 575
        Dim idOrigenvar As Integer = iWinDestino.IndexOf(txtiWinOrigen.Text) + 1
        Dim idDestinovar As Integer = iWinDestino.IndexOf(txtiWinDestino.Text) + 1

        'MsgBox(objGuiaEnvio.iIDUNIDAD_AGENCIA)
        'MsgBox(objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO)

        'objGuiaEnvio.iIDUNIDAD_AGENCIA = Int(coll_iOrigen.Item(idOrigenvar.ToString))
        'objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = Int(coll_iOrigen.Item(idDestinovar.ToString))

        Try
            'objGuiaEnvio.iIDCENTRO_COSTO = Int(objGuiaEnvio.coll_Sub_Cuenta.Item(cmbSubCuenta.SelectedItem.ToString()))
            objGuiaEnvio.iIDCENTRO_COSTO = Int(objGuiaEnvio.coll_Sub_Cuenta.Item(cmbSubCuenta.SelectedIndex.ToString))
        Catch ex As Exception
            objGuiaEnvio.iIDCENTRO_COSTO = 0

        End Try

        If txtiWinOrigen.Text <> "" And txtiWinDestino.Text <> "" And txtiWinOrigen.Text <> txtiWinDestino.Text Then
            objGuiaEnvio.iIDUNIDAD_AGENCIA = Int(coll_iOrigen.Item(iWinDestino.IndexOf(txtiWinOrigen.Text) + 1))
            objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = Int(coll_iDestino.Item(iWinDestino.IndexOf(txtiWinDestino.Text) + 1))
        Else
            objGuiaEnvio.iIDUNIDAD_AGENCIA = 999
            objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = 999
        End If
        'Mod. 27/08/2009 -->Omendoza - Pasando al datahelper   
        If objGuiaEnvio.fnLISTA_TARIFA_CLIENTE() = True Then
            tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
            'Mod. 08/08/2008 - Añade los valores 
            dtGridViewBultos(4, 0).Value = tarifa_Peso
            '
            tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
            dtGridViewBultos(4, 1).Value = tarifa_Volumen
            '
            tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
            Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base
            tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Sobre
            'dtGridViewBultos(4, 2).Value = Monto_Base
            ' Modificado 08/08/2008 - Registro                 
            dtGridViewBultos(4, 2).Value = Monto_Base
            dtGridViewBultos(5, 2).Value = Monto_Base
            '15/08/2008 Recupera la base 
            Me.txt_base.Text = Format(Monto_Base, "####,###.00")
            '
            flag = True
            bControl_Tarifas = True
            'MsgBox(Monto_Base + objGuiaEnvio.iTarifa_Publica_Monto_Peso + objGuiaEnvio.iTarifa_Publica_Monto_Volumen + 100000)
        ElseIf objGuiaEnvio.fnTARIFA_PUBLICA_CARGA() = True Then 'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper   
            tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
            'Mod. 08/08/2008 - Añade los valores 
            dtGridViewBultos(4, 0).Value = tarifa_Peso
            tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
            dtGridViewBultos(4, 1).Value = tarifa_Volumen
            tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
            '
            Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base
            dtGridViewBultos(4, 2).Value = Monto_Base
            dtGridViewBultos(5, 2).Value = Monto_Base
            tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Base_Xpostal
            flag = True
            bControl_Tarifas = True
            'If lb_datos_editados = True Then '19/08/2008 - Pasando la nueva tarifa 
            '    objGuiaEnvio.dMONTO_BASE = objGuiaEnvio.iTarifa_Publica_Monto_Base
            '    objGuiaEnvio.iPrecio_x_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
            '    objGuiaEnvio.iPrecio_x_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
            'End If

            'MsgBox(Monto_Base + objGuiaEnvio.iTarifa_Publica_Monto_Peso + objGuiaEnvio.iTarifa_Publica_Monto_Volumen)
        Else
            flag = False
            MsgBox("NO EXISTE TARIFA PARA ESTE ORIGEN Y DESTINO, NI ASOCIADO A UNA TARIFA DEL CLIENTE", MsgBoxStyle.Information, "REVICE SUS DATOS")
        End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
        Return flag
    End Function
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            'casos()
            '10 Limpio Nro Ruc
            '20 Limpio NrGuia
            '30 Limpio Nro Ruc y Limpio NroGuia
            '40 not Limpio Ambos N 
            'txtNroDocuento
            'txtCliente
            If cmbAgencia.Text = "" Then
                MsgBox("Debe Elegir Un Iten de Agencias...,Operacion Cancelada", MsgBoxStyle.Information, "Seguridad Sistema")
                GoTo SALIR
            End If

            If cmbUsuarios.Text = "" Then
                MsgBox("Debe Elegir Un Usuario...,Operacion Cancelada", MsgBoxStyle.Information, "Seguridad Sistema")
                GoTo SALIR
            End If

            If txtCliente.Text = "" And txtNroDocumento.Text <> "" Then
                objGuiaEnvio.idCONTROL_GUIAS = 1
            ElseIf txtCliente.Text = "" And txtNroDocumento.Text <> "" Then
                objGuiaEnvio.idCONTROL_GUIAS = 2
            ElseIf txtCliente.Text = "" And txtNroDocumento.Text = "" Then
                objGuiaEnvio.idCONTROL_GUIAS = 3
            Else
                objGuiaEnvio.idCONTROL_GUIAS = 1
            End If

            objGuiaEnvio.idCONTROL_GUIAS = 1
            objGuiaEnvio.iCONTROLFecha_Inicio = dtFechaInicio.Text
            objGuiaEnvio.iCONTROLFecha_Final = dtFechaFin.Text
            objGuiaEnvio.iCONTROL_Nro_Guia = IIf(txtNroDocumento.Text <> "", txtNroDocumento.Text, "@")
            objGuiaEnvio.iCONTROLIdagencias = IIf(cmbAgencia.SelectedIndex.ToString <> "", Int(objGuiaEnvio.coll_Lista_Agencias.Item(cmbAgencia.SelectedIndex.ToString)), 0)
            'ModuUtil.LlenarComboIDs(rst, cmbAgencia, objGuiaEnvio.coll_Lista_Agencias, dtoUSUARIOS.iIDAGENCIAS)
            'ModuUtil.LlenarComboIDs(objGuiaEnvio.rst_Lista_Usuarios, cmbUsuarios, objGuiaEnvio.coll_Lista_Usuarios, dtoUSUARIOS.IdLogin)
            objGuiaEnvio.iCONTROLIdunidad_Origen = IIf(cmbOrigen.SelectedIndex.ToString <> "", Int(objGuiaEnvio.coll_Lista_Origen.Item(cmbOrigen.SelectedIndex.ToString)), 0)
            objGuiaEnvio.iCONTROLIdunidad_Destino = IIf(cmbDestino.SelectedIndex.ToString <> "", Int(objGuiaEnvio.coll_Lista_Origen.Item(cmbDestino.SelectedIndex.ToString)), 0)
            objGuiaEnvio.iCONTROL_Nro_RUC_RASON_SOCIAl = IIf(txtCliente.Text <> "", txtCliente.Text, "@")

            objGuiaEnvio.iCONTROLIdpersona = Int(objGuiaEnvio.coll_Lista_Usuarios.Item(cmbUsuarios.SelectedIndex.ToString))
            objGuiaEnvio.iCONTROLIdrol_Usuariol = dtoUSUARIOS.IdRol
            objGuiaEnvio.iCONTROLIdIdestado_Registro = IIf(cmbEstados.SelectedIndex.ToString <> "", Int(objGuiaEnvio.coll_Lista_Estados.Item(cmbEstados.SelectedIndex.ToString)), 0)
            objGuiaEnvio.iIDUSUARIO_PERSONAL = IIf(cmbUsuarios.Text <> "", objGuiaEnvio.coll_Lista_Usuarios.Item(cmbUsuarios.SelectedIndex.ToString), 0)
            'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper   
            'rst = Nothing
            If objGuiaEnvio.fnCONTROL_GUIAS_ENVIO() = True Then
                fnLimpiarGRILLABUSQUEDA()
            Else
                MsgBox("No existe resultado, para está búsqueda...", MsgBoxStyle.Information, "Seguridad Sistema")
                dtControl_Guia.Clear()
                lbNroRegistro.Text = 0
            End If
            objGuiaEnvio.idCONTROL_GUIAS = 1
SALIR:
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub chechCargo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chechCargo.CheckedChanged
        Try
            objGuiaEnvio.iCARGO = Int(chechCargo.Checked)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub fnBuscarNroGUIA()
        Try
            If txtNroDocumento.Text <> "" Then
                objGuiaEnvio.idCONTROL_GUIAS = CONTROL
                objGuiaEnvio.iCONTROL_Nro_Guia = IIf(txtNroDocumento.Text <> "", txtNroDocumento.Text, "@")
                objGuiaEnvio.iCONTROLIdagencias = dtoUSUARIOS.m_iIdAgencia
                If CONTROL <> 5 Then
                    objGuiaEnvio.iCONTROLIdunidad_Origen = Int(coll_iOrigen.Item(iWinDestino.IndexOf(txtiWinOrigen.Text) + 1))
                    objGuiaEnvio.iCONTROLIdunidad_Destino = Int(coll_iDestino.Item(iWinDestino.IndexOf(txtiWinDestino.Text) + 1))
                Else
                    objGuiaEnvio.iCONTROLIdunidad_Origen = 999
                    objGuiaEnvio.iCONTROLIdunidad_Destino = 999
                End If


                If CONTROL <> 2 Then
                    objGuiaEnvio.iCONTROLIdpersona = 1
                End If
                objGuiaEnvio.iCONTROL_Nro_RUC_RASON_SOCIAl = "0000"
                objGuiaEnvio.iCONTROLIdrol_Usuariol = 0
                'objGuiaEnvio.iCONTROLIdIdestado_Registro = 0

                'Por Datahelper 
                ' rst = New ADODB.Recordset

                objGuiaEnvio.iCONTROLFecha_Inicio = dtFechaInicio.Text
                objGuiaEnvio.iCONTROLFecha_Final = dtFechaFin.Text
                '
                'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper   
                '
                If objGuiaEnvio.fnCONTROL_GUIAS_ENVIO() = True Then
                    dtControl_Guia.Clear()
                    dtGridViewControl_GUIAS.Refresh()
                    'dtControl_Guia.Columns.Clear()
                    'daControl_Guia.Fill(dtControl_Guia, objGuiaEnvio.cur_Lista_guias_Envio)
                    dtControl_Guia = objGuiaEnvio.dt_cur_Lista_guias_Envio
                    dvControl_Guia = dtControl_Guia.DefaultView
                    dtGridViewControl_GUIAS.DataSource = dvControl_Guia
                    dtGridViewControl_GUIAS.Refresh()
                    If dvControl_Guia.Count = 0 Then
                        MsgBox("No Se han Encontrado Ninguna Resulatdo para esta busqueda..., en toda la Base de datos", MsgBoxStyle.Information, "Seguridad Sistema")
                    End If
                    bformatImage = True
                Else
                    MsgBox("No Se han Encontrado Ninguna Resulatdo para esta busqueda..., en toda la Base de datos", MsgBoxStyle.Information, "Seguridad Sistema")
                End If
            End If
        Catch ex As Exception
            MsgBox("No existen Ningun Resultado para esta Operacion", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub fnLimpiarGRILLABUSQUEDA()
        Try
            dtControl_Guia.Clear()
            'daControl_Guia.Fill(dtControl_Guia, objGuiaEnvio.cur_Lista_guias_Envio)
            'dvControl_Guia = dtControl_Guia.DefaultView
            dvControl_Guia = objGuiaEnvio.dt_cur_Lista_guias_Envio.DefaultView
            lbNroRegistro.Text = dvControl_Guia.Count
            bformatImage = True
            dtGridViewControl_GUIAS.DataSource = dvControl_Guia
            dtGridViewControl_GUIAS.Refresh()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub fnConfiguracion_Grillas()
        Try
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
            dtGridViewControl_GUIAS.Columns.Add(idEstadoImage)

            Dim Idguias_Envio As New DataGridViewTextBoxColumn
            With Idguias_Envio
                .DataPropertyName = "Idguias_Envio"
                .HeaderText = "ID"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DisplayIndex = 1
                '.ReadOnly = True
                .Visible = False
                '.Frozen = True
            End With
            dtGridViewControl_GUIAS.Columns.Add(Idguias_Envio)

            Dim f_Guia As New DataGridViewTextBoxColumn
            With f_Guia
                .DataPropertyName = "f_Guia"
                .HeaderText = "f_Guia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DisplayIndex = 2
                '.ReadOnly = True
                .Visible = False
                '.Frozen = True
            End With
            dtGridViewControl_GUIAS.Columns.Add(f_Guia)


            Dim Nro_Guia As New DataGridViewTextBoxColumn
            With Nro_Guia
                .DataPropertyName = "Nro_Guia"
                .HeaderText = "Nro_Guia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DisplayIndex = 3
                .ReadOnly = True
                '.Frozen = True
            End With
            dtGridViewControl_GUIAS.Columns.Add(Nro_Guia)


            Dim Cantidad As New DataGridViewTextBoxColumn
            With Cantidad
                .DataPropertyName = "Cantidad"
                .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DisplayIndex = 4
                .ReadOnly = True
                '.Frozen = True
            End With
            dtGridViewControl_GUIAS.Columns.Add(Cantidad)

            Dim Nu_Docu_Suna As New DataGridViewTextBoxColumn
            With Nu_Docu_Suna
                .DataPropertyName = "Nu_Docu_Suna"
                .HeaderText = "Nu_Docu_Suna"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DisplayIndex = 5
                .ReadOnly = True
                '.Frozen = True
            End With
            dtGridViewControl_GUIAS.Columns.Add(Nu_Docu_Suna)


            Dim Razon_Social As New DataGridViewTextBoxColumn
            With Razon_Social
                .DataPropertyName = "Razon_Social"
                .HeaderText = "Razon_Social"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DisplayIndex = 6
                .ReadOnly = True
                '.Frozen = True
            End With
            dtGridViewControl_GUIAS.Columns.Add(Razon_Social)


            Dim ORIGEN As New DataGridViewTextBoxColumn
            With ORIGEN
                .DataPropertyName = "ORIGEN"
                .HeaderText = "ORIGEN"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DisplayIndex = 7
                .ReadOnly = True
                '.Frozen = True
            End With
            dtGridViewControl_GUIAS.Columns.Add(ORIGEN)

            Dim DESTINO As New DataGridViewTextBoxColumn
            With DESTINO
                .DataPropertyName = "DESTINO"
                .HeaderText = "DESTINO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DisplayIndex = 8
                .ReadOnly = True
                '.Frozen = True
            End With
            dtGridViewControl_GUIAS.Columns.Add(DESTINO)


            Dim CIUDAD_TRANCITO As New DataGridViewTextBoxColumn
            With CIUDAD_TRANCITO
                .DataPropertyName = "CIUDAD_TRANCITO"
                .HeaderText = "CIUDAD TRANSITO"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DisplayIndex = 9
                .ReadOnly = True
                '.Frozen = True
            End With
            dtGridViewControl_GUIAS.Columns.Add(CIUDAD_TRANCITO)

            Dim f_Registro As New DataGridViewTextBoxColumn
            With f_Registro
                .DataPropertyName = "f_Registro"
                .HeaderText = "f_Registro"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DisplayIndex = 10
                .ReadOnly = True
                '.Frozen = True
            End With
            dtGridViewControl_GUIAS.Columns.Add(f_Registro)
            Dim Estado_Registro As New DataGridViewTextBoxColumn
            With Estado_Registro
                .DataPropertyName = "Estado_Registro"
                .HeaderText = "Estado_Registro"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DisplayIndex = 11
                .ReadOnly = True
                '.Frozen = True
            End With
            dtGridViewControl_GUIAS.Columns.Add(Estado_Registro)
            Dim Idestado_Registro As New DataGridViewTextBoxColumn
            With Idestado_Registro
                .DataPropertyName = "Idestado_Registro"
                .HeaderText = "Idestado_Registro"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DisplayIndex = 12
                .ReadOnly = True
                '.Frozen = True
                .Visible = False
            End With
            dtGridViewControl_GUIAS.Columns.Add(Idestado_Registro)

            Dim Idunidad_Agencia As New DataGridViewTextBoxColumn
            With Idunidad_Agencia
                .DataPropertyName = "Idunidad_Agencia"
                .HeaderText = "Idunidad_Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DisplayIndex = 13
                .ReadOnly = True
                .Visible = False
                '.Frozen = True
            End With
            dtGridViewControl_GUIAS.Columns.Add(Idunidad_Agencia)


            Dim Idunidad_Agencia_Destino As New DataGridViewTextBoxColumn
            With Idunidad_Agencia_Destino
                .DataPropertyName = "Idunidad_Agencia_Destino"
                .HeaderText = "Idunidad_Agencia_Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DisplayIndex = 14
                .ReadOnly = True
                .Visible = False
                '.Frozen = True
            End With
            dtGridViewControl_GUIAS.Columns.Add(Idunidad_Agencia_Destino)

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub dtGridViewControl_GUIAS_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtGridViewControl_GUIAS.CellFormatting
        Dim strvar As String = ""
        Try
            strvar = e.RowIndex.ToString()
            If bformatImage = True Then
                If e.ColumnIndex = 0 Then
                    Dim IdEstado As Integer
                    If e.RowIndex >= 0 And dtGridViewControl_GUIAS.Rows().Count - 1 >= e.RowIndex Then
                        If IsDBNull(dtGridViewControl_GUIAS.Rows(e.RowIndex).Cells(12).Value) = False Then
                            IdEstado = dtGridViewControl_GUIAS.Rows(e.RowIndex).Cells(12).Value
                            dtGridViewControl_GUIAS.Rows(e.RowIndex).Cells(1).Tag = 1
                        Else
                            IdEstado = 0
                        End If
                        'IdEstado = IIf(IsNothing(DataGridViewUser.Rows(e.RowIndex).Cells(7).Value), 0, DataGridViewUser.Rows(e.RowIndex).Cells(7).Value)
                        Select Case IdEstado
                            Case 18
                                e.Value = bmActivo
                            Case 2
                                e.Value = bmEliminado
                            Case 22
                                e.Value = bmpGUIAS_CARGO
                            Case 23
                                e.Value = bmpGUIAS_LIQUIDADAS
                            Case 21
                                e.Value = bmpGUIAS_ENTREGADAS
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
    Private Sub AnularRegistroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnularRegistroToolStripMenuItem.Click
        Try
            fnControl_Registro_GUIA(2)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub RecepcionadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecepcionadoToolStripMenuItem.Click
        Try
            fnControl_Registro_GUIA(18)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub DespachadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DespachadoToolStripMenuItem.Click
        Try
            fnControl_Registro_GUIA(19)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub EditarRegistroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarRegistroToolStripMenuItem.Click
        Try
            fnControl_Registro_GUIA(20)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub NuevaGUIAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevaGUIAToolStripMenuItem.Click
        Try
            fnControl_Registro_GUIA(21)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub CargosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargosToolStripMenuItem.Click
        Try
            fnControl_Registro_GUIA(22)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub LiquidadaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquidadaToolStripMenuItem.Click
        Try
            fnControl_Registro_GUIA(23)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub dtGridViewControl_GUIAS_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtGridViewControl_GUIAS.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                ContextMenuStrip1.Show(sender, e.X, e.Y)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try

    End Sub
    Private Sub cmbEstados_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEstados.SelectedIndexChanged
        Try

            CONTROL = 4
            objGuiaEnvio.iCONTROLIdIdestado_Registro = Int(objGuiaEnvio.coll_Lista_Estados.Item(cmbEstados.SelectedIndex.ToString()))
            fnBuscarNroGUIA()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub dtGridViewArticulo_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtGridViewArticulo.CellEndEdit
        Try
            Dim row As Short = e.RowIndex
            Dim col As Short = e.ColumnIndex
            If col = 3 Or col = 4 Then
                fnTarifario()

                If Not IsNumeric(dtGridViewArticulo(col, row).Value) Then
                    If col = 3 Then
                        dtGridViewArticulo(col, row).Value = ""
                    Else
                        dtGridViewArticulo(col, row).Value = ""
                    End If

                End If

                'If fnTarifario() = True Then
                If fArticulo = True Then
                    objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = 0
                    Dim Total As Double = 0
                    Dim ii1 As Integer = 0
                    If dtGridViewArticulo.Rows(row).Cells(0).Value = 211 Then
                        dtGridViewArticulo.Rows(row).Cells(6).Value = Format(Val(dtGridViewArticulo.Rows(row).Cells(2).Value) * Microsoft.VisualBasic.Conversion.Val(dtGridViewArticulo.Rows(row).Cells(4).Value.ToString), "###,###,###.00")
                        dtGridViewArticulo.Rows(row).Cells(3).Value = Format(Val(Replace(dtGridViewArticulo.Rows(row).Cells(3).Value.ToString, ",", "")), "###,###,###")

                    Else
                        dtGridViewArticulo.Rows(row).Cells(6).Value = Format(Microsoft.VisualBasic.Conversion.Val(dtGridViewArticulo.Rows(row).Cells(2).Value) * Microsoft.VisualBasic.Conversion.Val(dtGridViewArticulo.Rows(row).Cells(3).Value.ToString), "###,###,###.00")
                        dtGridViewArticulo.Rows(row).Cells(4).Value = ""
                    End If

                    'dtGridViewArticulo.Rows(row).Cells(3).Value = Format(Microsoft.VisualBasic.Conversion.Val(dtGridViewArticulo.Rows(row).Cells(3).Value), "###,###,####.000")
                    For ii1 = 0 To dtGridViewArticulo.Rows().Count() - 1

                        Total = Total + CDbl(dtGridViewArticulo.Rows(ii1).Cells(6).Value.ToString)
                        objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI + Microsoft.VisualBasic.Conversion.Val(dtGridViewArticulo.Rows(ii1).Cells(3).Value.ToString)
                    Next

                    Dim Monto_Sobre As Double = 0

                    If checkSobres.Checked = True Then
                        Monto_Sobre = tarifa_Sobre * Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
                        txtTotalSobre.Visible = True
                        txtTotalSobre.Text = Format(Monto_Sobre, "#,###,###,###.00")
                    End If


                    Total = Monto_Base + Total + tarifa_Sobre * Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)

                    txtSubTotal.Text = Format(Total, "##,####,###.00")
                    txMontotIGV.Text = Format(Total * IGV, "##,####,###.00")
                    txtTotal_Pago.Text = Format(Total * (1 + IGV), "##,####,####.00")

                    'txtSubTotal.Text = Format(Total, "##,####,####.00")
                    'txMontotIGV.Text = Format(Total * IGV, "##,####,####.00")
                    'txtTotal_Pago.Text = Format(Total * (1 + IGV), "##,####,####.00")
                End If
                'End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbFormaCredito_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFormaCredito.SelectedIndexChanged
        Try
            If cmbFormaCredito.SelectedIndex > 0 Then
                If Int(objGuiaEnvio.coll_Lista_Forma_Pagos.Item(cmbFormaCredito.SelectedIndex.ToString)) = 2 Then
                    txtNrofactura.Enabled = False
                    lbFectura.Enabled = False
                Else
                    txtNrofactura.Text = ""
                    txtNrofactura.Enabled = True
                    lbFectura.Enabled = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    ' EDICION DE LA GUIA DE ENVIO    
    Public Sub fnControl_Guias_Envio(ByVal rflag As Boolean)
        Dim flat As Boolean = False
        ' Modificado el 26/08/2008 
        Dim flag As Boolean = False
        '
        flag_ver_datos = True
        Try
            If dtGridViewControl_GUIAS.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViewControl_GUIAS.SelectedRows.Item(0).Index
            If dtGridViewControl_GUIAS.Rows().Count - 1 = row Then
                Return
            End If
            'If fnValidar_Rol("15") Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 2) Then
                rflag = False
            End If
            If row >= 0 Then
                If dtGridViewControl_GUIAS.Rows(row).Cells(12).Value = 18 Or rflag = False Then
                    Limpiar_Todo()
                    SelectMenu(1)
                    objGuiaEnvio.iIDGUIAS_ENVIO = dtGridViewControl_GUIAS.Rows(row).Cells(1).Value
                    'Mod. 25/08/2009 -->Omendoza - Pasando al datahelper   
                    If objGuiaEnvio.fnEDIT_GUIAS_EMVIO() = True Then
                        'If objGuiaEnvio.cur_Sub_Cuenta.EOF = False And objGuiaEnvio.cur_Sub_Cuenta.BOF = False Then
                        '    ModuUtil.LlenarComboIDs(objGuiaEnvio.cur_Sub_Cuenta, cmbSubCuenta, objGuiaEnvio.coll_Sub_Cuenta, objGuiaEnvio.iIDCENTRO_COSTO)
                        '    'cmbSubCuenta.SelectedIndex = 0
                        'End If
                        If objGuiaEnvio.dt_cur_Sub_Cuenta.Rows.Count > 0 Then
                            '05/09/2009 - Cambiado por datahelper 
                            'ModuUtil.LlenarComboIDs(objGuiaEnvio.cur_Sub_Cuenta, cmbSubCuenta, objGuiaEnvio.coll_Sub_Cuenta, objGuiaEnvio.iIDCENTRO_COSTO)
                            ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_cur_Sub_Cuenta, cmbSubCuenta, objGuiaEnvio.coll_Sub_Cuenta, objGuiaEnvio.iIDCENTRO_COSTO)
                            'cmbSubCuenta.SelectedIndex = 0
                        End If

                        objGuiaEnvio.iControl_Busqueda = 2

                        Dim fecha_guia As String = objGuiaEnvio.sFECHA_GUIA
                        llenar_collections()
                        objGuiaEnvio.sFECHA_GUIA = fecha_guia


                        Me.txtiWinOrigen.Text = objGuiaEnvio.iNOMBRE_UNIDAD_ORIGEN
                        Me.txtiWinDestino.Text = objGuiaEnvio.iNOMBRE_UNIDAD_DESTINO
                        fnAgenciaDestino()
                        Me.TxtGuiaEnvio.Text = objGuiaEnvio.sNRO_GUIA
                        Me.txtFechaGuia.Text = objGuiaEnvio.sFECHA_GUIA
                        Me.TxtRasonSocial.Text = objGuiaEnvio.sRASON_SOCIAL
                        Me.TxtRuc.Text = objGuiaEnvio.sNU_DOCU_SUNAT

                        txtCliente_Remitente.Text = objGuiaEnvio.iREMITENTE
                        txtDocCliente_Remitente.Text = objGuiaEnvio.iNRODOC_REM
                        '07/09/2009 - Mod. por datahelper 
                        'objGuiaEnvio.rst_Lista_Forma_Pagos.MoveFirst()
                        'objGuiaEnvio.rst_Lista_Tipo_Entrega.MoveFirst()
                        ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_Lista_Forma_Pagos, cmbFormaCredito, objGuiaEnvio.coll_Lista_Forma_Pagos, objGuiaEnvio.iIDFORMA_PAGO)
                        ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_Lista_Tipo_Entrega, cmbTipo_Entrega, objGuiaEnvio.coll_Lista_Tipo_Entrega, objGuiaEnvio.iIDTIPO_ENTREGA_CARGA)

                        txtRemitente.Text = objGuiaEnvio.iNOMBRES_REMITENTE
                        txtDNIRemitente.Text = objGuiaEnvio.iDNI_REMITENTE
                        txtDireccionRemitente.Text = objGuiaEnvio.iDIRECCION_REMITENTE
                        txtDestinatario.Text = objGuiaEnvio.iNOMBRES_DESTINATARIO
                        txtDNIDestinatario.Text = objGuiaEnvio.iDNI_DESTINATARIO
                        txtDireccionDestinatario.Text = objGuiaEnvio.iDIRECCION_DESTINATARIO
                        Me.txtTelefonoRemitente.Text = objGuiaEnvio.sTelefono_Remitente
                        Me.txtTelefonoDestinatario.Text = objGuiaEnvio.sTelefono_Destinatario
                        If objGuiaEnvio.iIDSINO_SOBRES = 1 Then
                            Me.checkSobres.Checked = True
                            txtCantidadSobres.Visible = True
                            txtCantidadSobres.Text = objGuiaEnvio.iCANTIDAD_SOBRES
                            txtTotalSobre.Text = Format(objGuiaEnvio.iCANTIDAD_SOBRES * objGuiaEnvio.dMONTO_BASE, "####,###.00") ' 16/08/2008 - Obs los sobres ¿¿¿???
                        Else
                            Me.checkSobres.Checked = False
                            txtCantidadSobres.Visible = False
                            txtCantidadSobres.Text = 0
                            txtTotalSobre.Text = "0.00"
                        End If
                        '
                        '.DefaultCellStyle.Format = "##,###,###.000"
                        '14/08/2080 - Colocando los valores del costo 
                        dtGridViewBultos.Rows(0).Cells(4).Value = Format(objGuiaEnvio.iPrecio_x_Peso, "##,###,###.00") ' add 14/08/2008 
                        dtGridViewBultos.Rows(1).Cells(4).Value = Format(objGuiaEnvio.iPrecio_x_Volumen, "##,###,###.00") ' add 14/08/2008 
                        dtGridViewBultos.Rows(2).Cells(4).Value = Format(objGuiaEnvio.dMONTO_BASE, "##,###,###.00")

                        '15/08/2008 - Recupera la base cuando edita 
                        Me.txt_base.Text = Format(objGuiaEnvio.dMONTO_BASE, "####,###.00")
                        Monto_Base = Format(objGuiaEnvio.dMONTO_BASE, "####,###.00")
                        '
                        'Dim flag As Boolean = False
                        If objGuiaEnvio.dTOTAL_PESO <> 0 Then ' Para el caso de edición 
                            dtGridViewBultos.Rows(0).Cells(2).Value = objGuiaEnvio.iCANTIDAD
                            dtGridViewBultos.Rows(0).Cells(3).Value = Format(objGuiaEnvio.dTOTAL_PESO, "##,###,###.00")
                            '16/08/208 - Recupera la tarifa del peso 
                            tarifa_Peso = Format(objGuiaEnvio.iPrecio_x_Peso, "##,###,###.00")
                            dtGridViewBultos.Rows(0).Cells(5).Value = Format(objGuiaEnvio.iPrecio_x_Peso * objGuiaEnvio.dTOTAL_PESO, "##,###,###.00")
                            dtGridViewBultos.Rows(2).Cells(5).Value = Format(objGuiaEnvio.dMONTO_BASE, "##,###,###.00")
                            flag = True
                        End If
                        If objGuiaEnvio.dTOTAL_VOLUMEN <> 0 Then
                            dtGridViewBultos.Rows(1).Cells(2).Value = objGuiaEnvio.iCANTIDAD_X_UNIDAD_VOLUMEN
                            dtGridViewBultos.Rows(1).Cells(3).Value = Format(objGuiaEnvio.dTOTAL_VOLUMEN, "##,###,###.00")
                            '
                            tarifa_Volumen = Format(objGuiaEnvio.iPrecio_x_Volumen, "##,###,###.00")
                            '
                            dtGridViewBultos.Rows(1).Cells(5).Value = Format(objGuiaEnvio.iPrecio_x_Volumen * objGuiaEnvio.dTOTAL_VOLUMEN, "##,###,###.00") ' add 14/08/2008 
                            dtGridViewBultos.Rows(2).Cells(5).Value = Format(objGuiaEnvio.dMONTO_BASE, "##,###,###.00")
                            flag = True
                        End If
                        'Mod. 22/08/2009 -->Omendoza - Pasando al datahelper   
                        If objGuiaEnvio.SP_SI_VENTA_ARTICULOS = True Then
                            flag = False
                        Else
                            flag = True
                        End If
                        '
                        If flag = False Then
                            fArticulo = True
                            dtGridViewBultos.Visible = False
                            dtGridViewArticulo.Visible = True
                            lbEtiquetaControl.Text = "( F11 ) PESO VOLUMEN"
                            '
                            Me.txt_base.Visible = True
                            Me.lb_base.Visible = True
                            '
                            Dim i As Integer = 0
                            For i = 1 To dtGridViewArticulo.Rows().Count
                                dtGridViewArticulo.Rows().RemoveAt(0)
                            Next
                            '
                            '07/09/2009 - Modificado por el datahelper 
                            'If objGuiaEnvio.cur_edtguia_articulos.State = 1 Then

                            '    While objGuiaEnvio.cur_edtguia_articulos.BOF = False And objGuiaEnvio.cur_edtguia_articulos.EOF = False
                            '        Dim varidarticulo = Int(objGuiaEnvio.cur_edtguia_articulos.Fields.Item(0).Value)
                            '        Dim vararticulo = objGuiaEnvio.cur_edtguia_articulos.Fields.Item(1).Value
                            '        Dim varprecio_final = objGuiaEnvio.cur_edtguia_articulos.Fields.Item(2).Value
                            '        Dim varcantidad = IIf(IsDBNull(objGuiaEnvio.cur_edtguia_articulos.Fields.Item(3).Value) = True, "", objGuiaEnvio.cur_edtguia_articulos.Fields.Item(3).Value)




                            '        Dim varmetro_cubico = IIf(IsDBNull(objGuiaEnvio.cur_edtguia_articulos.Fields.Item(4).Value) = True, 0, objGuiaEnvio.cur_edtguia_articulos.Fields.Item(4).Value)
                            '        'total peso

                            '        Dim vartotal_peso = IIf(IsDBNull(objGuiaEnvio.cur_edtguia_articulos.Fields.Item(5).Value) = True, 0, objGuiaEnvio.cur_edtguia_articulos.Fields.Item(5).Value)

                            '        Dim vartotal_costo As Double = 0

                            '        If varidarticulo = 211 Then
                            '            If IsNumeric(varcantidad) Then
                            '                vartotal_costo = varprecio_final * varmetro_cubico
                            '            Else
                            '                vartotal_costo = 0
                            '            End If
                            '        Else
                            '            If IsNumeric(varcantidad) Then
                            '                vartotal_costo = varprecio_final * varcantidad
                            '            Else
                            '                vartotal_costo = 0
                            '            End If

                            '        End If
                            '        Dim row0 As String() = {Int(varidarticulo), _
                            '            vararticulo, _
                            '            varprecio_final, _
                            '            varcantidad, _
                            '            varmetro_cubico, _
                            '            vartotal_peso, _
                            '            Format(vartotal_costo, "##,###,###.00")}

                            '        dtGridViewArticulo.Rows().Add(row0)

                            '        objGuiaEnvio.cur_edtguia_articulos.MoveNext()
                            '    End While
                            'End If

                            '
                            If objGuiaEnvio.dt_cur_edtguia_articulos.Rows.Count > 0 Then
                                For Each fila As DataRow In objGuiaEnvio.dt_cur_edtguia_articulos.Rows
                                    Dim varidarticulo = Int(fila.Item(0))
                                    Dim vararticulo = fila.Item(1)
                                    Dim varprecio_final = fila.Item(2)
                                    Dim varcantidad = IIf(IsDBNull(fila.Item(3)) = True, "", fila.Item(3))
                                    '
                                    Dim varmetro_cubico = IIf(IsDBNull(fila.Item(4)) = True, 0, fila.Item(4))
                                    Dim vartotal_peso = IIf(IsDBNull(fila.Item(5)) = True, 0, fila.Item(5))
                                    '
                                    Dim vartotal_costo As Double = 0
                                    '
                                    If varidarticulo = 211 Then   ' Para metros cubicos - Amarrado a un código especifico 
                                        If IsNumeric(varcantidad) Then
                                            vartotal_costo = varprecio_final * varmetro_cubico
                                        Else
                                            vartotal_costo = 0
                                        End If
                                    Else
                                        If IsNumeric(varcantidad) Then
                                            vartotal_costo = varprecio_final * varcantidad
                                        Else
                                            vartotal_costo = 0
                                        End If

                                    End If
                                    Dim row0 As String() = {Int(varidarticulo), _
                                        vararticulo, _
                                        varprecio_final, _
                                        varcantidad, _
                                        varmetro_cubico, _
                                        vartotal_peso, _
                                        Format(vartotal_costo, "##,###,###.00")}
                                    dtGridViewArticulo.Rows().Add(row0)
                                Next
                            End If
                        End If
                    End If

                    txMontotIGV.Text = Format(objGuiaEnvio.dMONTO_IMPUESTO, "##,###,###.00")
                    txtTotal_Pago.Text = Format(objGuiaEnvio.dTOTAL_COSTO, "##,###,###.00")
                    txtSubTotal.Text = Format(objGuiaEnvio.dTOTAL_COSTO - objGuiaEnvio.dMONTO_IMPUESTO, "##,###,###.00")
                    '
                    '07/09/2009 Mod. por cambio de datahelper 
                    '
                    'If objGuiaEnvio.cur_Sub_Cuenta.EOF = False And objGuiaEnvio.cur_Sub_Cuenta.BOF = False Then
                    '    ModuUtil.LlenarComboIDs(objGuiaEnvio.cur_Sub_Cuenta, cmbSubCuenta, objGuiaEnvio.coll_Sub_Cuenta, Int(objGuiaEnvio.iIDCENTRO_COSTO))
                    '    'cmbSubCuenta.SelectedIndex = 0
                    'End If
                    If objGuiaEnvio.dt_cur_Sub_Cuenta.Rows.Count > 0 Then
                        ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_cur_Sub_Cuenta, cmbSubCuenta, objGuiaEnvio.coll_Sub_Cuenta, Int(objGuiaEnvio.iIDCENTRO_COSTO))
                    End If
                    '
                    TxtGuiaEnvio.Focus()
                    TxtGuiaEnvio.SelectAll()
                    'TxtGuiaEnvio.ReadOnly = True

                    'If objGuiaEnvio.cur_edtguia_documentos.State = 1 Then
                    '    Dim i As Integer = 0
                    '    For i = 1 To DataGridViewDocumentos.Rows().Count - 1
                    '        DataGridViewDocumentos.Rows().RemoveAt(0)
                    '    Next


                    '    While objGuiaEnvio.cur_edtguia_documentos.BOF = False And objGuiaEnvio.cur_edtguia_documentos.EOF = False
                    '        Dim idDoc0 As String = objGuiaEnvio.cur_edtguia_documentos.Fields.Item(0).Value
                    '        Dim NroDoc0 As String = objGuiaEnvio.cur_edtguia_documentos.Fields.Item(1).Value
                    '        Dim idDoc1 As String = ""
                    '        Dim NroDoc1 As String = "-"
                    '        objGuiaEnvio.cur_edtguia_documentos.MoveNext()
                    '        If objGuiaEnvio.cur_edtguia_documentos.BOF = False And objGuiaEnvio.cur_edtguia_documentos.EOF = False Then
                    '            idDoc1 = objGuiaEnvio.cur_edtguia_documentos.Fields.Item(0).Value
                    '            NroDoc1 = objGuiaEnvio.cur_edtguia_documentos.Fields.Item(1).Value
                    '        End If
                    '        Dim row0 As String() = {idDoc0, idDoc1, NroDoc0, NroDoc1}
                    '        DataGridViewDocumentos.Rows().Add(row0)
                    '        If objGuiaEnvio.cur_edtguia_documentos.EOF = False And objGuiaEnvio.cur_edtguia_documentos.BOF = False Then
                    '            objGuiaEnvio.cur_edtguia_documentos.MoveNext()
                    '        End If
                    '    End While
                    'End If

                    If objGuiaEnvio.dt_cur_edtguia_documentos.Rows.Count > 0 Then
                        Dim i As Integer = 0
                        For i = 1 To DataGridViewDocumentos.Rows().Count - 1
                            DataGridViewDocumentos.Rows().RemoveAt(0)
                        Next
                        '
                        Dim li_index As Integer = 0
                        '
                        Dim idDoc1 As String = ""
                        Dim NroDoc1 As String = "-"
                        '
                        Dim idDoc0 As String
                        Dim NroDoc0 As String
                        '
                        Dim lb_par_activo As Boolean = False
                        For Each fila As DataRow In objGuiaEnvio.dt_cur_edtguia_documentos.Rows
                            If (li_index Mod 2) = 0 Then
                                idDoc1 = ""
                                NroDoc1 = "-"
                                idDoc0 = fila.Item(0)
                                NroDoc0 = fila.Item(1)
                                lb_par_activo = True
                            End If

                            If (li_index Mod 2) = 1 Then
                                idDoc1 = fila.Item(0)
                                NroDoc1 = fila.Item(1)
                                '                                
                                Dim row0 As String() = {idDoc0, idDoc1, NroDoc0, NroDoc1}
                                DataGridViewDocumentos.Rows().Add(row0)
                                '
                                idDoc0 = ""
                                NroDoc0 = ""
                                '
                                idDoc1 = ""
                                NroDoc1 = "-"
                                lb_par_activo = False
                            End If
                            li_index = li_index + 1
                        Next
                        '
                        If lb_par_activo = True Then
                            Dim row0 As String() = {idDoc0, idDoc1, NroDoc0, NroDoc1}
                            DataGridViewDocumentos.Rows().Add(row0)
                        End If
                        '
                    End If
                    ''26/08/2008 - Verificando que cargue los articulos 
                    If lb_datos_editados = True And flag = True And lb_no_lee = True Then
                        cargar_articulos()
                    End If
                    '  fnVer_Datos(rflag)
                    fnAgenciaOrigen()
                Else
                    MsgBox("No Puede Realizar esta Operacion, Solo puede Editar las Recepcionadas", MsgBoxStyle.Information, "Seguridad Sistema")
                End If
            End If
            'msgbox "En Construccion...",MsgBoxStyle.Information 
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            flat = False
        End Try
    End Sub
    Public Function fnVer_Datos(ByVal flag As Boolean) As Boolean
        Try

            'TxtGuiaEnvio.ReadOnly = flag
            'txtiWinOrigen.ReadOnly = flag
            'txtiWinDestino.ReadOnly = flag
            'txtFechaGuia.ReadOnly = flag
            'dtFechaGuia.Enabled = Not flag
            'cmbTipo_Entrega.Enabled = Not flag
            'cmbFormaCredito.Enabled = Not flag
            'TxtRuc.ReadOnly = flag
            'TxtRasonSocial.ReadOnly = flag
            'cmbSubCuenta.Enabled = Not flag
            'txtCliente_Remitente.ReadOnly = flag
            'txtDestinatario.ReadOnly = flag
            'txtDocCliente_Remitente.ReadOnly = flag
            'txtDireccionRemitente.ReadOnly = flag
            'txtRemitente.ReadOnly = flag
            'txtDNIRemitente.ReadOnly = flag
            'txtTelefonoRemitente.ReadOnly = flag
            'txtDestinatario.ReadOnly = flag
            'txtDNIDestinatario.ReadOnly = flag
            'txtDireccionDestinatario.ReadOnly = flag
            'txtTelefonoDestinatario.ReadOnly = flag
            'txtNrofactura.ReadOnly = flag
            'DataGridViewDocumentos.ReadOnly = flag
            'dtGridViewArticulo.ReadOnly = flag
            'dtGridViewBultos.ReadOnly = flag
            '         
            TxtGuiaEnvio.Enabled = flag
            txtiWinOrigen.Enabled = flag
            txtiWinDestino.Enabled = flag
            txtFechaGuia.Enabled = flag
            dtFechaGuia.Enabled = flag
            cmbTipo_Entrega.Enabled = flag
            cmbFormaCredito.Enabled = flag
            TxtRuc.Enabled = flag
            TxtRasonSocial.Enabled = flag
            cmbSubCuenta.Enabled = flag
            txtCliente_Remitente.Enabled = flag
            txtDestinatario.Enabled = flag
            txtDocCliente_Remitente.Enabled = flag
            txtDireccionRemitente.Enabled = flag
            txtRemitente.Enabled = flag
            txtDNIRemitente.Enabled = flag
            txtTelefonoRemitente.Enabled = flag
            txtDestinatario.Enabled = flag
            txtDNIDestinatario.Enabled = flag
            txtDireccionDestinatario.Enabled = flag
            txtTelefonoDestinatario.Enabled = flag
            txtNrofactura.Enabled = flag
            checkSobres.Enabled = flag
            txtCantidadSobres.Enabled = flag
            cmbAgenciaVenta.Enabled = flag
            cmbAgenciaOrigen.Enabled = flag
            cmbAgenciaVenta.Enabled = flag
            If dtGridViewArticulo.Visible = True Then
                dtGridViewArticulo.Enabled = flag
            End If
            If dtGridViewBultos.Visible = True Then
                dtGridViewBultos.Enabled = flag
            End If
            'DataGridViewDocumentos.ReadOnly = flag
            'dtGridViewArticulo.ReadOnly = flag
            'dtGridViewBultos.ReadOnly = flag

        Catch ex As Exception
            MsgBox("Error en la Actualización de Componentes", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flag
    End Function
    Private Sub btnVerData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerData.Click
        mostrar_pre_guias = False
        Try
            lb_no_lee = False
            'If fnValidar_Rol("7") = True Or fnValidar_Rol("11") = True Or fnValidar_Rol("12") = True And fnValidar_Rol("13") = True Or fnValidar_Rol("17") = True Or fnValidar_Rol("15") = True Or fnValidar_Rol("21") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 3) Then                '
                ' 15/08/2080 - Siempre por defecto aparecera el grid de los bultos                 
                fArticulo = False
                dtGridViewBultos.Visible = True
                lb_solo_visualiza = True
                '
                fnControl_Guias_Envio(False)
                fnVer_Datos(False)
                '
                fnCONTROLDATOS = False
                '                
            Else
                MsgBox("Usted No Tiene permisos para realizar esta Operación")
            End If
            lb_no_lee = True
        Catch ex As Exception
            MsgBox("Revise sus Datos.., Operacion Cancelada", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        mostrar_pre_guias = False
        Try
            lb_no_lee = False
            lb_solo_visualiza = False
            If dtGridViewControl_GUIAS.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViewControl_GUIAS.SelectedRows.Item(0).Index
            If dtGridViewControl_GUIAS.Rows().Count - 1 = row Then
                Return
            End If

            objGuiaEnvio.iIDGUIAS_ENVIO = dtGridViewControl_GUIAS.Rows(row).Cells(1).Value

            If objGuiaEnvio.iIDGUIAS_ENVIO = 0 Then
                MsgBox("No Puede realizar esta Operacion ...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            'If objGuiaEnvio.fnControlEdicion(objGuiaEnvio.iIDGUIAS_ENVIO) = True Then
            '    'MsgBox("La Guia de Envio esta Liquidada", MsgBoxStyle.Information, "Seguridad Sistema")
            '    MsgBox("La Guia de esta Facturada O Prefacturada...", MsgBoxStyle.Information, "Seguridad Sistema")
            '    GoTo SALIR
            'End If

            'If fnValidar_Rol("21") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 4) Then
                ' 15/08/2080 - Siempre por defecto aparecera el grid de los bultos 
                fArticulo = False
                dtGridViewBultos.Visible = True
                '
                CONTROL = 2 ' 26/08/2008 - Editados 'Se tiene la razon social 
                lb_datos_editados = True
                fnControl_Guias_Envio(True)
                fnVer_Datos(True)
                '
                fnTarifario()
                '
                objGuiaEnvio.iCONTROL = 2
                fnCONTROLDATOS = True

                ' objGuiaEnvio.iIDAGENCIAS_DESTINO = 0  -- comentado 03/08/2008 
                fnAgenciaDestino()
            Else
                MsgBox("Usted No Tiene Persmisos para realizar esta Operaciom")
            End If
            TxtGuiaEnvio.ReadOnly = True
            'Siempre que se edite no se va a poder modificar el origen 
            Me.cmbAgenciaOrigen.Enabled = False
            Me.txtiWinOrigen.Enabled = False
            '
            lb_no_lee = True

SALIR:
        Catch ex As Exception
            MsgBox("Revise sus Datos.., Operacion Cancelada", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnular.Click
        Try
            If dtGridViewControl_GUIAS.Rows().Count - 1 = 0 Then
                Return
            End If
            'If fnValidar_Rol("14") = True Or fnValidar_Rol("11") = True Or fnValidar_Rol("13") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 5) Then
                fnControl_Registro_GUIA(2)
            Else
                MessageBox.Show(G_Mje)
            End If
        Catch ex As Exception
            MsgBox("Revise sus Datos.., Operacion Cancelada", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btnRecepcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecepcion.Click
        Try
            Dim objFrm As New FrmRecepcionGuias
            'objFrm.ShowDialog()

            Acceso.Asignar(objFrm, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                objFrm.ShowDialog()
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            objFrm = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Dim id_columEstado As Integer = 12
    Private Sub dtGridViewControl_GUIAS_CellToolTipTextNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellToolTipTextNeededEventArgs) Handles dtGridViewControl_GUIAS.CellToolTipTextNeeded
        Try
            If e.ColumnIndex = 0 And e.RowIndex >= 0 Then
                Dim ide As New Object
                ide = dtGridViewControl_GUIAS.Rows(e.RowIndex).DataGridView(id_columEstado, e.RowIndex).Value

                If IsNothing(ide) = False Or Len(dtGridViewControl_GUIAS.Rows(e.RowIndex).DataGridView(id_columEstado, e.RowIndex).Value.ToString) > 0 Then
                    'Dim var As String = CargaTxtCmb(Me.cmbEstadoRegistro, ModVOESPECIESVALORADAS.IDEstadoRegistro, ide)
                    If ide = 1 Then
                        e.ToolTipText = "ACTIVO"
                    ElseIf ide = 2 Then
                        e.ToolTipText = "ANULADO"
                    ElseIf ide = 3 Then
                        e.ToolTipText = "ELIMINADO"
                    ElseIf ide = 9 Then
                        e.ToolTipText = "INACTIVO"
                    ElseIf ide = 18 Then
                        e.ToolTipText = "RECEPCIONADO"
                    ElseIf ide = 19 Then
                        e.ToolTipText = "DESPACHADO"
                    ElseIf ide = 20 Then
                        e.ToolTipText = "LLEGADA"
                    ElseIf ide = 21 Then
                        e.ToolTipText = "ENTREGADO"
                    ElseIf ide = 22 Then
                        e.ToolTipText = "CARGO"
                    ElseIf ide = 23 Then
                        e.ToolTipText = "LIQUIDADO"
                    ElseIf ide = 24 Then
                        e.ToolTipText = "PENDIENTE"
                    ElseIf ide = 25 Then
                        e.ToolTipText = "PERDIDO"
                    Else
                        e.ToolTipText = "NO DEFINIDO"
                    End If
                End If
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub EditarGUIAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarGUIAToolStripMenuItem.Click
        Try
            'If fnValidar_Rol("21") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 6) Then
                If dtGridViewControl_GUIAS.Rows().Count - 1 = 0 Then
                    Return
                End If
                Dim row As Integer = dtGridViewControl_GUIAS.SelectedRows.Item(0).Index
                If dtGridViewControl_GUIAS.Rows().Count - 1 = row Then
                    Return
                End If
                objGuiaEnvio.iIDGUIAS_ENVIO = dtGridViewControl_GUIAS.Rows(row).Cells(1).Value
                'Mod. 24/08/2009 -->Omendoza - Pasando al datahelper   
                If objGuiaEnvio.fnControlEdicion(objGuiaEnvio.iIDGUIAS_ENVIO) = True Then
                    'MsgBox("La Guia de Envio esta Liquidada", MsgBoxStyle.Information, "Seguridad Sistema")
                    MsgBox("La Guía de está facturada O pre-facturada...", MsgBoxStyle.Information, "Seguridad Sistema")
                    GoTo SALIR
                End If
                fnControl_Guias_Envio(True)
                fnVer_Datos(True)
            Else
                MsgBox("Usted No Tiene Persmisos para realizar esta Operaciom")
            End If
SALIR:
        Catch ex As Exception
            MsgBox("Revice sus Datos.., Operacion Cancelada", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub NuevaGuiaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevaGuiaToolStripMenuItem1.Click
        fnNUEVO()
    End Sub

    Private Sub txtCantidadSobres_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidadSobres.LostFocus
        Try
            If fnTarifario() = False Then
                Total_Pagar()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub txtCantidadSobres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidadSobres.TextChanged
        Try
            Total_Pagar()
            'objGuiaEnvio.iCANTIDAD = 0  'Unidades Peso
            'objGuiaEnvio.iCANTIDAD_X_UNIDAD_VOLUMEN = 0 'Unidades Volumen
            'objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = 0 'Unidades Articulos
            'Dim totalCosto As Double = 0
            'Dim valor1 As Double = 0
            'Dim valor2 As Double = 0
            'If IsDBNull(DataGridViewDocumentos.Rows(0).Cells(2)) = False Then
            '    valor1 = Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(2, 0).Value.ToString))
            '    valor2 = Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(3, 0).Value.ToString))
            '    objGuiaEnvio.iCANTIDAD = valor2
            '    objGuiaEnvio.dTOTAL_PESO = valor1
            '    totalCosto = valor1 * valor2
            '    totalCosto = valor1 * valor2
            'End If
            'If IsDBNull(DataGridViewDocumentos.Rows(1).Cells(2)) = False Then
            '    valor1 = Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(2, 1).Value.ToString))
            '    valor2 = Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(3, 1).Value.ToString))
            '    objGuiaEnvio.dTOTAL_VOLUMEN = valor1
            '    objGuiaEnvio.iCANTIDAD_X_UNIDAD_VOLUMEN = valor2
            '    totalCosto = totalCosto + valor1 * valor2 + Monto_Base
            'End If

            'If IsDBNull(DataGridViewDocumentos.Rows(2).Cells(2)) = False Then
            '    valor1 = Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(2, 2).Value.ToString))
            '    valor2 = Microsoft.VisualBasic.Conversion.Val(Trim(dtGridViewBultos(3, 2).Value.ToString))
            '    objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = valor2
            '    totalCosto = totalCosto + valor1 * valor2
            'End If

            'Dim Total As Double = Monto_Base * Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text.ToString()) + totalCosto
            'txtSubTotal.Text = Format(Total, "#####.00")
            'txMontotIGV.Text = Format(Total * IGV, "#####.00")
            'txtTotal_Pago.Text = Format(Total * (1 + IGV), "#####.00")
        Catch ex As Exception
            txtSubTotal.Text = "0.00"
            txMontotIGV.Text = "0.00"
            txtTotal_Pago.Text = "0.00"
        End Try
    End Sub
    Private Sub checkSobres_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkSobres.CheckedChanged
        Try
            If checkSobres.Checked = True Then

                txtCantidadSobres.Visible = True
                txtCantidadSobres.Focus()
                txtCantidadSobres.SelectAll()

            Else
                txtCantidadSobres.Visible = False

            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub checkSobres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkSobres.Click
        Try
            If checkSobres.Checked = True Then
                fnTarifario()
                txtCantidadSobres.Visible = True
                objGuiaEnvio.iCANTIDAD_SOBRES = Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
                objGuiaEnvio.iIDSINO_SOBRES = 1
                txtTotalSobre.Visible = True
                'Total_Pagar()
            Else

                txtCantidadSobres.Visible = False
                objGuiaEnvio.iCANTIDAD_SOBRES = 0
                objGuiaEnvio.iIDSINO_SOBRES = 0
                txtTotalSobre.Visible = True
                txtTotalSobre.Text = "0.00"
                txtCantidadSobres.Text = "0"
                'Total_Pagar()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub dtGridViewArticulo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtGridViewArticulo.Validating
        Try
            'If sen.ColumnIndex = 0 And e.RowIndex >= 0 Then
            '    Dim ide As New Object
            '    ide = dtGridViewControl_GUIAS.Rows(e.RowIndex).DataGridView(id_columEstado, e.RowIndex).Value
            'End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LiberarCargoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiberarCargoToolStripMenuItem.Click
        Try
            'If fnValidar_Rol("7") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 7) Then
                fnControl_Registro_GUIA(21)
            Else
                MsgBox("Usted No Tiene Persmisos para realizar esta Operaciom, No es Funcionario carga", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub txtFechaGuia_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFechaGuia.Validating
        'Try
        '    If CDate(txtFechaGuia.Text.ToString) >= CDate(dtoUSUARIOS.m_sFecha.ToString) Then
        '        MsgBox("No Puede registrar una fecha Mayor a la del dia...", MsgBoxStyle.Information, "Seguridad Sistema")
        '        txtFechaGuia.Text = dtoUSUARIOS.m_sFecha
        '    End If
        'Catch ex As Exception
        '    txtFechaGuia.Text = dtoUSUARIOS.m_sFecha
        'End Try
    End Sub

    Private Sub txtFechaGuia_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFechaGuia.Validated
        'Try
        '    If CDate(txtFechaGuia.Text.ToString) >= CDate(dtoUSUARIOS.m_sFecha.ToString) Then
        '        MsgBox("No Puede registrar una fecha Mayor a la del dia...", MsgBoxStyle.Information, "Seguridad Sistema")
        '        txtFechaGuia.Text = dtoUSUARIOS.m_sFecha
        '    End If
        'Catch ex As Exception
        '    txtFechaGuia.Text = dtoUSUARIOS.m_sFecha
        'End Try
    End Sub

    Private Sub txtFechaGuia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFechaGuia.TextChanged
        'Try
        '    If CDate(txtFechaGuia.Text.ToString) >= CDate(dtoUSUARIOS.m_sFecha.ToString) Then
        '        MsgBox("No Puede registrar una fecha Mayor a la del dia...", MsgBoxStyle.Information, "Seguridad Sistema")
        '        txtFechaGuia.Text = dtoUSUARIOS.m_sFecha
        '    End If
        'Catch ex As Exception
        '    txtFechaGuia.Text = dtoUSUARIOS.m_sFecha
        'End Try
    End Sub
    Public Function fnControlFecha_GuiaEnvio(ByVal dtFechaGuia As String) As Boolean
        Dim flag As Boolean = True
        Try
            'Mod. 24/08/2009 -->Omendoza - Pasando al datahelper   
            If objGuiaEnvio.fnSQLLIQUIDACIONES() = True Then
                objGuiaEnvio.FEC_MAX_APERTURA_LIQ = ""
                objGuiaEnvio.FEC_MAX_CIERRE_LIQ = ""
            End If
            If CDate(dtFechaGuia) > CDate(dtoUSUARIOS.m_sFecha) Or CDate(dtFechaGuia) <= CDate("01/01/1996") Then
                flag = False
            End If
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function
    Public Function fnInprecion_Guia_Envio() As Boolean
        Dim obj As New Imprimir
        Try
            ObjRptGuiaEnvio.p_Hora_Guia = fnGetHora()
            Dim objImpresoras As New dtoCONFIGURACION_DOCUMENTARIA
            Dim dt As DataTable = objImpresoras.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 3)
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, iIzquierda As Integer = 0
            Dim flags As Boolean
            If dt.Rows.Count = 0 Then
                flags = False
            Else
                If IsDBNull(dt.Rows(0).Item("impresora")) Then
                    flags = False
                Else
                    sImpresora = dt.Rows(0).Item("impresora")
                    iTamaño = dt.Rows(0).Item("tamano")
                    iSuperior = dt.Rows(0).Item("superior")
                    Iizquierda = dt.Rows(0).Item("izquierda")
                    flags = True
                End If
            End If

            Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
            Dim iLong As Integer = IIf(iTamaño = 0, 22, iTamaño)

            y = iLong * pagina + 2
            i += 1

            If flags Then
                obj.Inicializar()
                obj.Impresora = sImpresora
                obj.Superior = iSuperior
                obj.Izquierda = iIzquierda

                obj.EscribirLinea(y, 22, ObjRptGuiaEnvio.p_NroGUIA)
                obj.EscribirLinea(y, 82, ObjRptGuiaEnvio.p_codigo_iata_ori)
                obj.EscribirLinea(y, 92, ObjRptGuiaEnvio.p_codigo_iata_desti)
                obj.EscribirLinea(y + 2, 0, ObjRptGuiaEnvio.p_ruc)
                obj.EscribirLinea(y + 5, 0, ObjRptGuiaEnvio.P_REMITENTE)
                If ObjRptGuiaEnvio.P_DIRECCION_REMI.ToString.Length > 40 Then
                    obj.EscribirLinea(y + 3, 0, ObjRptGuiaEnvio.P_DIRECCION_REMI.ToString.Substring(0, 41))
                    obj.EscribirLinea(y + 4, 0, ObjRptGuiaEnvio.P_DIRECCION_REMI.ToString.Substring(41))
                Else
                    obj.EscribirLinea(y + 6, 0, ObjRptGuiaEnvio.P_DIRECCION_REMI)
                End If

                obj.EscribirLinea(y + 5, 59, ObjRptGuiaEnvio.P_NOMBRES_DESTI)
                obj.EscribirLinea(y + 6, 59, ObjRptGuiaEnvio.P_DIRECCION_DESTI)

                obj.EscribirLinea(y + 2, 33, p_domicilio)
                obj.EscribirLinea(y + 2, 43, p_agencia)
                obj.EscribirLinea(y + 2, 54, p_contado)
                obj.EscribirLinea(y + 2, 64, p_destino)
                obj.EscribirLinea(y + 2, 76, p_credito)

                'obj.EscribirLinea(ObjRptGuiaEnvio.P_CARGO)
                obj.EscribirLinea(y + 9, 0, ObjRptGuiaEnvio.p_contacto)
                obj.EscribirLinea(y + 8, 29, ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI)
                obj.EscribirLinea(y + 8, 59, ObjRptGuiaEnvio.P_PROVINCIA)
                obj.EscribirLinea(y + 8, 84, ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI)


                'obj.EscribirLinea(Mid(strNroGuias_Remision, 1, 80))
                If Not (strNroGuias_Remision Is Nothing) Then
                    If Val(strNroGuias_Remision.Trim.Length) < 126 Then
                        strNroGuias_Remision = strNroGuias_Remision & Space(126 - Len(strNroGuias_Remision.Trim))
                    End If
                    strNroGuias_Remision = Mid(strNroGuias_Remision.Trim, 1, 126)

                    Dim iGuiones As Integer
                    iGuiones = DevuelveGuiones(strNroGuias_Remision)
                    If iGuiones >= 7 Then       '3 lineas
                        obj.EscribirLinea(y + 11, 0, Trim(Mid(strNroGuias_Remision, 1, 42)))
                        obj.EscribirLinea(y + 12, 0, Trim(Mid(strNroGuias_Remision, 43, 42)))
                        obj.EscribirLinea(y + 13, 0, Trim(Mid(strNroGuias_Remision, 86, 42)))
                    ElseIf iGuiones >= 4 Then   '2 lineas
                        obj.EscribirLinea(y + 11, 0, Trim(Mid(strNroGuias_Remision, 1, 42)))
                        obj.EscribirLinea(y + 12, 0, Trim(Mid(strNroGuias_Remision, 43, 42)))
                    Else                        '1 linea
                        obj.EscribirLinea(y + 11, 0, Trim(Mid(strNroGuias_Remision, 1, 42)))
                    End If
                End If

                obj.EscribirLinea(y + 17, 26, Format(CDate(ObjRptGuiaEnvio.P_FECHA_GUIA), "dd     MM      yy"))
                obj.EscribirLinea(y + 13, 49, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_BULTOS), 2))
                obj.EscribirLinea(y + 13, 57, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_PESO), 2))
                obj.EscribirLinea(y + 13, 65, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_VOLUMEN), 2))
                obj.EscribirLinea(y + 13, 78, dtoUSUARIOS.m_sFecha)
                obj.EscribirLinea(y + 13, 92, ObjRptGuiaEnvio.p_Hora_Guia)
                obj.EscribirLinea(y + 14, 57, "Nº SOBRES " & ObjRptGuiaEnvio.P_TOTAL_SOBRES)

                obj.Comprimido = True
                obj.Tamaño = iLong
                obj.Imprimir()
                obj.Finalizar()
            Else
                Dim objImpresora As New dtoVentaCargaContado
                ''Dim flag = objImpresora.fnSP_Buscar_Impresora(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE)
                ''19/08/2008 - Solo se trabaja con el tipo de comprobante de GE - omendoza            
                ''Lima
                '04/05/2009 - Cambio por el datahelper 
                Dim flag = objImpresora.fnSP_Buscar_Impresora(3, dtoUSUARIOS.IP)
                If flag Then
                    Dim objImprimir As New ImprimirTexto("Draft Condensed", 8, objImpresora.v_Impresora, "guia", 1305, 1305)

                    'Envío de impresión texto Guía de Envío (Nuevo)
                    'Dim objImprimir As New ImprimirTexto("Arial", 8, "PDFCreator", "tres", 1305, 1305)
                    objImprimir.Agregar(210, 25, ObjRptGuiaEnvio.p_NroGUIA)
                    objImprimir.Agregar(485, 15, ObjRptGuiaEnvio.p_codigo_iata_ori)
                    objImprimir.Agregar(545, 15, ObjRptGuiaEnvio.p_codigo_iata_desti)
                    objImprimir.Agregar(0, 55, ObjRptGuiaEnvio.p_ruc)
                    objImprimir.Agregar(25, 105, ObjRptGuiaEnvio.P_REMITENTE)
                    objImprimir.Agregar(25, 120, ObjRptGuiaEnvio.P_DIRECCION_REMI)

                    objImprimir.Agregar(355, 105, ObjRptGuiaEnvio.P_NOMBRES_DESTI)
                    objImprimir.Agregar(355, 120, ObjRptGuiaEnvio.P_DIRECCION_DESTI)

                    objImprimir.Agregar(190, 55, p_domicilio)
                    objImprimir.Agregar(245, 55, p_agencia)
                    objImprimir.Agregar(310, 55, p_contado)
                    objImprimir.Agregar(370, 55, p_destino)
                    objImprimir.Agregar(435, 55, p_credito)
                    objImprimir.Agregar(570, 55, ObjRptGuiaEnvio.P_CARGO)

                    objImprimir.Agregar(25, 175, ObjRptGuiaEnvio.p_contacto)

                    objImprimir.Agregar(162, 155, ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI)
                    objImprimir.Agregar(370, 155, ObjRptGuiaEnvio.P_PROVINCIA)
                    objImprimir.Agregar(525, 155, ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI)

                    objImprimir.Agregar(20, 210, Mid(strNroGuias_Remision, 1, 80))
                    objImprimir.Agregar(155, 300, Format(CDate(ObjRptGuiaEnvio.P_FECHA_GUIA), "dd     MM      yy"))

                    objImprimir.Agregar(280, 235, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_BULTOS), 2))
                    objImprimir.Agregar(330, 235, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_PESO), 2))
                    objImprimir.Agregar(380, 235, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_VOLUMEN), 2))

                    objImprimir.Agregar(450, 240, dtoUSUARIOS.m_sFecha)
                    objImprimir.Agregar(535, 240, ObjRptGuiaEnvio.p_Hora_Guia)

                    objImprimir.Agregar(300, 252, "Nº SOBRES " & ObjRptGuiaEnvio.P_TOTAL_SOBRES)

                    objImprimir.Imprimir()
                    objImprimir = Nothing
                Else
                    '
                    'MessageBox.Show("El Documento no tiene asociado una impresora.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '
                    ''19/08/2008 - Inicio comentado - Omendoza - Printer 
                    Dim ObjReport As New ClsLbTepsa.dtoFrmReport
                    ObjReport.rutaRpt = PathFrmReport
                    'ObjReport.rutaRpt = "\\192.168.50.196\ReportesRitcher\"
                    'ObjReport.conectar(rptservice, rptuser, rptpass)
                    ObjReport.printrptlpt(True, "", "GUI007.RPT", _
                    "p_domicilio;" & p_domicilio, _
                    "p_agencia;" & p_agencia, _
                    "p_contado;" & p_contado, _
                    "p_destino;" & p_destino, _
                    "p_credito;" & p_credito, _
                    "p_ruc;" & ObjRptGuiaEnvio.p_ruc, _
                    "p_codigo_iata_ori;" & ObjRptGuiaEnvio.p_codigo_iata_ori, _
                    "p_codigo_iata_desti;" & ObjRptGuiaEnvio.p_codigo_iata_desti, _
                    "P_NROCOMUNICACION_CONTACTO_ORI;" & ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI, _
                    "P_NROCOMUNICACION_CONTACTO_DESTI;" & ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI, _
                    "P_REMITENTE;" & ObjRptGuiaEnvio.P_REMITENTE, _
                    "P_DIRECCION_REMI;" & ObjRptGuiaEnvio.P_DIRECCION_REMI, _
                    "P_DIRECCION_DESTI;" & ObjRptGuiaEnvio.P_DIRECCION_DESTI, _
                    "P_NOMBRES_DESTI;" & ObjRptGuiaEnvio.P_NOMBRES_DESTI, _
                    "P_DOCUMENTOS;" & Mid(strNroGuias_Remision, 1, 80), _
                    "P_FECHA_GUIA;" & Format(CDate(ObjRptGuiaEnvio.P_FECHA_GUIA), "dd     MM      yy"), _
                    "P_TOTAL_BULTOS;" & FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_BULTOS), 2), _
                    "P_TOTAL_VOLUMEN;" & FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_VOLUMEN), 3), _
                    "P_TOTAL_PESO;" & FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_PESO), 2), _
                    "P_SOBRES;" & "NRO SOBRES : " & ObjRptGuiaEnvio.P_TOTAL_SOBRES, _
                    "P_CONTACTO;" & ObjRptGuiaEnvio.p_contacto, _
                    "P_LOGIN;" & " ", _
                    "P_NRO_GUIA;" & ObjRptGuiaEnvio.p_NroGUIA, _
                    "P_HORA_GUIA;" & ObjRptGuiaEnvio.p_Hora_Guia, _
                    "P_FECHA_RECIBIDO;" & dtoUSUARIOS.m_sFecha, _
                    "P_PROVINCIA;" & ObjRptGuiaEnvio.P_PROVINCIA, _
                    "P_CLIE_CARGO;" & ObjRptGuiaEnvio.P_CARGO)
                End If
            End If
            ' Fin de la modificación 19/08/2008 - Omendoza 
        Catch ex As Exception
            obj.Finalizar()
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function
    Public Function fnImprimirEtiquetas() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""

            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()
            For I As Int16 = 1 To 1
                prn.EscribeLinea("^XA")
                prn.EscribeLinea("^PW400")
                prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD0000734-001/020^FS")
                'prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD " & Me.TextBox1.Text & "^FS")
                'prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & Me.TextBox2.Text & I & "^FS")
                prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD" & TxtGuiaEnvio.Text.ToString & "^FS")
                prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & I.ToString & "^FS")
                prn.EscribeLinea("^FT17,141^A0N,28,28^FH\^FDLIM /^FS")
                prn.EscribeLinea("^FT96,141^A0N,28,28^FH\^FDAQP^FS")
                prn.EscribeLinea("^FT305,188^AAN,18,10^FH\^FDTEPSAC^FS")
                prn.EscribeLinea("^FT183,188^AAN,18,10^FH\^FD" & Now.ToShortTimeString & "^FS")
                prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & Now.ToShortDateString & "^FS")
                prn.EscribeLinea("^PQ1,0,1,Y")
                prn.EscribeLinea("^XZ")
                prn.EscribeLinea(cadena)
            Next
            prn.FinDoc()
        Catch ex As Exception
            MsgBox(ex.ToString)
            flag = False
        End Try

        Return flag
    End Function
    Public Function fnImprimirEtiquetasGUIA() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()

            'ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
            'ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)

            ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            '   ObjCODIGOBARRA.Cantidad = objGuiaEnvio.v_CANTIDAD_ETIQUETAS

            'Dim I As Int16 = 1
            Dim i As Int16
            If bRango Then
                i = 1
            Else
                i = correlativo_inicial
                'Mod 21/08/2009 
                If i = 0 Then i = 1
            End If

            ObjCODIGOBARRA.tipo = 3
            ObjCODIGOBARRA.id = objGuiaEnvio.iIDGUIAS_ENVIO
            ObjCODIGOBARRA.sp_etiqueta_generada()
            '26/08/2009 - Obtiene Fecha y Hora - Hlamas
            '04/09/2009 - Obtiene Fecha y Hora x datahelper 
            ObjVentaCargaContado.fnFechaRegistro(3, objGuiaEnvio.iIDGUIAS_ENVIO)
            '
            sFecha = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(0)
            sHora = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(1)
            ' 
            HoraActual = sHora
            ObjCODIGOBARRA.Fecha = sFecha

            '05/09/2009 - Cambiando por el datahelper 
            'While objGuiaEnvio.cur_codBarras.EOF = False And objGuiaEnvio.cur_codBarras.BOF = False
            '    ObjCODIGOBARRA.CodigoBarra = objGuiaEnvio.cur_codBarras.Fields.Item(0).Value
            '    prn.EscribeLinea("^XA")
            '    prn.EscribeLinea("^PW400")
            '    prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD " & ObjCODIGOBARRA.NroDOC & "          " & objGuiaEnvio.cur_codBarras.Fields.Item(1).Value.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & "^FS")
            '    'prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD " & Me.TextBox1.Text & "^FS")
            '    'prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & Me.TextBox2.Text & I & "^FS")
            '    prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.clinte & "^FS")
            '    prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & ObjCODIGOBARRA.CodigoBarra & "^FS")
            '    prn.EscribeLinea("^FT17,141^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
            '    prn.EscribeLinea("^FT96,142^A0N,39,45^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")
            '    prn.EscribeLinea("^FT305,188^AAN,18,10^FH\^FDTEPSAC^FS")
            '    prn.EscribeLinea("^FT183,188^AAN,18,10^FH\^FD" & HoraActual & "^FS")
            '    prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & ObjCODIGOBARRA.Fecha & "^FS")
            '    prn.EscribeLinea("^PQ1,0,1,Y")
            '    prn.EscribeLinea("^XZ")
            '    prn.EscribeLinea(cadena)
            '    objGuiaEnvio.cur_codBarras.MoveNext()
            '    I = I + 1
            'End While
            '''
            For Each row As DataRow In objGuiaEnvio.dt_cur_codBarras.Rows
                ObjCODIGOBARRA.CodigoBarra = row.Item(0)
                prn.EscribeLinea("^XA")
                prn.EscribeLinea("^PW400")
                prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD " & ObjCODIGOBARRA.NroDOC & "          " & row.Item(1).ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & "^FS")
                'prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD " & Me.TextBox1.Text & "^FS")
                'prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & Me.TextBox2.Text & I & "^FS")
                prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.clinte & "^FS")
                prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & ObjCODIGOBARRA.CodigoBarra & "^FS")
                prn.EscribeLinea("^FT17,141^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
                prn.EscribeLinea("^FT96,142^A0N,39,45^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")
                prn.EscribeLinea("^FT305,188^AAN,18,10^FH\^FDTEPSAC^FS")
                prn.EscribeLinea("^FT183,188^AAN,18,10^FH\^FD" & HoraActual & "^FS")
                prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & ObjCODIGOBARRA.Fecha & "^FS")
                prn.EscribeLinea("^PQ1,0,1,Y")
                prn.EscribeLinea("^XZ")
                prn.EscribeLinea(cadena)
                i = i + 1
            Next


            prn.FinDoc()
        Catch ex As Exception
            MsgBox(ex.ToString)
            flag = False
        End Try
        Return flag
    End Function
    Public Function fnImprimirEtiquetasGUIA_II() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()

            'ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
            'ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)

            ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            '   ObjCODIGOBARRA.Cantidad = objGuiaEnvio.v_CANTIDAD_ETIQUETAS

            'Dim I As Int16 = 1
            Dim i As Int16
            If bRango Then
                i = 1
            Else
                i = correlativo_inicial
                'Mod 21/08/2009 
                If i = 0 Then i = 1
            End If
            ObjCODIGOBARRA.tipo = 3
            ObjCODIGOBARRA.id = objGuiaEnvio.iIDGUIAS_ENVIO
            ObjCODIGOBARRA.sp_etiqueta_generada()
            '25/08/2009 - Obtiene Fecha y Hora - Hlamas
            '04/09/2009 - Obtiene Fecha y Hora x datahelper 
            ObjVentaCargaContado.fnFechaRegistro(3, objGuiaEnvio.iIDGUIAS_ENVIO)
            sFecha = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(0)
            sHora = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(1)
            HoraActual = sHora
            ObjCODIGOBARRA.Fecha = sFecha
            '
            '04/09/2009 - Cambio x datahelper
            '
            'While objGuiaEnvio.cur_codBarras.EOF = False And objGuiaEnvio.cur_codBarras.BOF = False
            '    ObjCODIGOBARRA.CodigoBarra = objGuiaEnvio.cur_codBarras.Fields.Item(0)
            '    prn.EscribeLinea("<STX><ESC>C0<ETX>")
            '    prn.EscribeLinea("<STX><ESC>k<ETX>")
            '    prn.EscribeLinea("<STX><SI>N60<ETX>")
            '    prn.EscribeLinea("<STX><SI>L197<ETX>")
            '    prn.EscribeLinea("<STX><SI>S20<ETX>")
            '    prn.EscribeLinea("<STX><SI>d0<ETX>")
            '    prn.EscribeLinea("<STX><SI>h0,0;<ETX>")
            '    prn.EscribeLinea("<STX><SI>l8<ETX>")
            '    prn.EscribeLinea("<STX><SI>I3<ETX>")
            '    prn.EscribeLinea("<STX><SI>F20<ETX>")
            '    prn.EscribeLinea("<STX><SI>D0<ETX>")
            '    prn.EscribeLinea("<STX><SI>t0<ETX>")
            '    prn.EscribeLinea("<STX><SI>W394<ETX>")
            '    prn.EscribeLinea("<STX><SI>g1,567<ETX>")
            '    prn.EscribeLinea("<STX><ESC>P<ETX>")
            '    prn.EscribeLinea("<STX>E*;F*;<ETX>")
            '    prn.EscribeLinea("<STX>L1;<ETX>")
            '    prn.EscribeLinea("<STX>D0;<ETX>")
            '    prn.EscribeLinea("<STX>H0;o165,12;f3;c25;h15;w15;d3," & ObjCODIGOBARRA.clinte & ";<ETX>")
            '    prn.EscribeLinea("<STX>D1;<ETX>")
            '    prn.EscribeLinea("<STX>H1;o130,13;f3;c25;h9;w15;d3," & ObjCODIGOBARRA.NroDOC & " -" & objGuiaEnvio.cur_codBarras.Fields.Item(1).Value.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & ";<ETX>")
            '    prn.EscribeLinea("<STX>H2;o88,11;f3;c25;h11;w11;d3," & ObjCODIGOBARRA.Origen & " / ;<ETX>")
            '    'prn.EscribeLinea("<STX>B3;o96,180;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
            '    prn.EscribeLinea("<STX>B3;o96,160;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
            '    prn.EscribeLinea("<STX>H4;o14,13;f3;c25;h7;w7;d3," & ObjCODIGOBARRA.Fecha & ";<ETX>")
            '    prn.EscribeLinea("<STX>H5;o14,200;f3;c25;h7;w7;d3," & HoraActual & ";<ETX>")
            '    prn.EscribeLinea("<STX>H6;o14,300;f3;c25;h7;w7;d3,TEPSAC;<ETX>")
            '    prn.EscribeLinea("<STX>H7;o102,96;f3;c25;h17;w16;d3," & ObjCODIGOBARRA.Destino & ";<ETX>")
            '    prn.EscribeLinea("<STX>R<ETX>")
            '    prn.EscribeLinea("<STX><ESC>E*<CAN><ETX>")
            '    prn.EscribeLinea("<STX><RS>1<US>1<ETB><ETX>")

            '    prn.EscribeLinea(cadena)
            '    objGuiaEnvio.cur_codBarras.MoveNext()
            '    I = I + 1
            'End While
            '''''''''''
            For Each row As DataRow In objGuiaEnvio.dt_cur_codBarras.Rows
                ObjCODIGOBARRA.CodigoBarra = row.Item(0)
                prn.EscribeLinea("<STX><ESC>C0<ETX>")
                prn.EscribeLinea("<STX><ESC>k<ETX>")
                prn.EscribeLinea("<STX><SI>N60<ETX>")
                prn.EscribeLinea("<STX><SI>L197<ETX>")
                prn.EscribeLinea("<STX><SI>S20<ETX>")
                prn.EscribeLinea("<STX><SI>d0<ETX>")
                prn.EscribeLinea("<STX><SI>h0,0;<ETX>")
                prn.EscribeLinea("<STX><SI>l8<ETX>")
                prn.EscribeLinea("<STX><SI>I3<ETX>")
                prn.EscribeLinea("<STX><SI>F20<ETX>")
                prn.EscribeLinea("<STX><SI>D0<ETX>")
                prn.EscribeLinea("<STX><SI>t0<ETX>")
                prn.EscribeLinea("<STX><SI>W394<ETX>")
                prn.EscribeLinea("<STX><SI>g1,567<ETX>")
                prn.EscribeLinea("<STX><ESC>P<ETX>")
                prn.EscribeLinea("<STX>E*;F*;<ETX>")
                prn.EscribeLinea("<STX>L1;<ETX>")
                prn.EscribeLinea("<STX>D0;<ETX>")
                prn.EscribeLinea("<STX>H0;o165,12;f3;c25;h15;w15;d3," & ObjCODIGOBARRA.clinte & ";<ETX>")
                prn.EscribeLinea("<STX>D1;<ETX>")
                prn.EscribeLinea("<STX>H1;o130,13;f3;c25;h9;w15;d3," & ObjCODIGOBARRA.NroDOC & " -" & row.Item(1).ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & ";<ETX>")
                prn.EscribeLinea("<STX>H2;o88,11;f3;c25;h11;w11;d3," & ObjCODIGOBARRA.Origen & " / ;<ETX>")
                'prn.EscribeLinea("<STX>B3;o96,180;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
                prn.EscribeLinea("<STX>B3;o96,160;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
                prn.EscribeLinea("<STX>H4;o14,13;f3;c25;h7;w7;d3," & ObjCODIGOBARRA.Fecha & ";<ETX>")
                prn.EscribeLinea("<STX>H5;o14,200;f3;c25;h7;w7;d3," & HoraActual & ";<ETX>")
                prn.EscribeLinea("<STX>H6;o14,300;f3;c25;h7;w7;d3,TEPSAC;<ETX>")
                prn.EscribeLinea("<STX>H7;o102,96;f3;c25;h17;w16;d3," & ObjCODIGOBARRA.Destino & ";<ETX>")
                prn.EscribeLinea("<STX>R<ETX>")
                prn.EscribeLinea("<STX><ESC>E*<CAN><ETX>")
                prn.EscribeLinea("<STX><RS>1<US>1<ETB><ETX>")
                '
                prn.EscribeLinea(cadena)
                '
                i = i + 1
            Next
            '''''''''''
            prn.FinDoc()
        Catch ex As Exception
            MsgBox(ex.ToString)
            flag = False
        End Try
        Return flag
    End Function

    Private Sub btnRango_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRango.Click
        Try
            Dim ObjRangoGuiasRemision As New frmRangoGuiasRemision
            ObjRangoGuiasRemision.txtSerie.MaxLength = li_iDigitosSerie
            '
            Acceso.Asignar(ObjRangoGuiasRemision, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                If ObjRangoGuiasRemision.ShowDialog = Windows.Forms.DialogResult.OK Then
                    DataGridViewDocumentos.Rows.Clear()
                    Dim Serie As String = RellenoRight(li_iDigitosSerie, ObjRangoGuiasRemision.Serie)
                    '
                    Dim Inicio As String = ObjRangoGuiasRemision.Inicio
                    Dim Final As String = ObjRangoGuiasRemision.Final

                    Dim var1 As String = ""
                    Dim var2 As String = ""
                    If DataGridViewDocumentos.Rows.Count >= 1 Then

                        Dim I As Integer = 0
                        For index As Integer = 0 To (Int(Final) + 3 - Int(Inicio)) / 2

                            var1 = Serie & "-" & RellenoRight(8, (I + Int(Inicio)).ToString())
                            var2 = Serie & "-" & RellenoRight(8, (I + +Int(Inicio) + 1).ToString())
                            If Int(Final) >= I + Int(Inicio) And Int(Final) >= I + +Int(Inicio) + 1 Then
                                Dim row11 As String() = {"", "", var1, var2}
                                DataGridViewDocumentos.Rows().Add(row11)
                            End If

                            If Int(Final) >= I + Int(Inicio) And Int(Final) < I + Int(Inicio) + 1 Then
                                Dim row11 As String() = {"", "", var1, "-"}
                                DataGridViewDocumentos.Rows().Add(row11)
                            End If

                            I = I + 2
                        Next
                    End If
                End If
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            ObjRangoGuiasRemision = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtiWinDestino_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtiWinDestino.Validating
        objGuiaEnvio.iIDAGENCIAS_DESTINO = 0
        '12/08/2008 
        If Me.txtiWinDestino.Text = "" Then
            Exit Sub
        End If
        If lb_no_lee = True Then
            limpia_monto_x_cambio()
            '
            fnAgenciaDestino()
            'Recupera tarifa  
            If txtiWinDestino.Text <> "" Then
                '
                If fArticulo = True Then
                    fArticulo = False
                    Me.dtGridViewArticulo.Visible = False
                    Me.dtGridViewBultos.Visible = True
                End If
                '
                recupera_tarifa()
            End If
        End If
    End Sub
    Private Sub fnAgenciaDestino()
        Try
            Dim idUnidadAgencias As Integer = iWinDestino.IndexOf(txtiWinDestino.Text)
            If idUnidadAgencias >= 0 Then
                idUnidadAgencias = Int(coll_iDestino.Item(idUnidadAgencias.ToString))
                If idUnidadAgencias > 0 Then
                    ObjVentaCargaContado.fnGetAgencias(idUnidadAgencias)
                    If objGuiaEnvio.iIDAGENCIAS_DESTINO > 0 Then
                        '01/09/2009 - Cambiado x datahelper x datatable
                        'ModuUtil.LlenarComboIDs(ObjVentaCargaContado.rstVarAgencias, cmbAgenciaVenta, ObjVentaCargaContado.coll_AgenciasVenta, objGuiaEnvio.iIDAGENCIAS_DESTINO)
                        ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_VarAgencias, cmbAgenciaVenta, ObjVentaCargaContado.coll_AgenciasVenta, objGuiaEnvio.iIDAGENCIAS_DESTINO)
                    Else
                        '01/09/2009 - Cambiado x datahelper x datatable
                        'ModuUtil.LlenarComboIDs(ObjVentaCargaContado.rstVarAgencias, cmbAgenciaVenta, ObjVentaCargaContado.coll_AgenciasVenta, Int(ObjVentaCargaContado.rstVarAgencias.Fields(0).Value))
                        ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_VarAgencias, cmbAgenciaVenta, ObjVentaCargaContado.coll_AgenciasVenta, Int(ObjVentaCargaContado.dt_VarAgencias.Rows(0).Item(0)))
                    End If

                Else
                    cmbAgenciaVenta.Controls.Clear()
                    cmbAgenciaVenta.Items.Clear()
                End If
            Else
                If txtiWinDestino.Text <> "" Then
                    MsgBox("Ciudad destino no se encuentra disponible en la base de datos", MsgBoxStyle.Exclamation, "Sistema de Seguridad")
                    Me.txtiWinDestino.Text = ""
                    Me.txtiWinDestino.Focus()
                    objGuiaEnvio.iIDAGENCIAS_DESTINO = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub fnAgenciaOrigen()
        Dim li_idagencias As Integer
        Try
            Dim idUnidadAgencias As Integer = iWinOrigen.IndexOf(txtiWinOrigen.Text)
            If idUnidadAgencias >= 0 Then
                idUnidadAgencias = Int(coll_iDestino.Item(idUnidadAgencias.ToString))
                If idUnidadAgencias > 0 Then
                    ObjVentaCargaContado.fnGetAgencias(idUnidadAgencias)
                    'ModuUtil.LlenarComboIDs(ObjVentaCargaContado.rstVarAgencias, cmbAgenciaOrigen, ObjVentaCargaContado.coll_AgenciasVenta, dtoUSUARIOS.iIDAGENCIAS)
                    'If lb_datos_editados = True Then '27/08/2008 
                    '    If IsDBNull(ObjVentaCargaContado.rstVarAgencias.Fields(0).Value) = False Then
                    '        objGuiaEnvio.iIDAGENCIAS = ObjVentaCargaContado.rstVarAgencias.Fields(0).Value
                    '    Else
                    '        objGuiaEnvio.iIDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS  ' No deberia pasar porq' el origen no debiera ser modificado asi por asi  
                    '    End If
                    'End If
                    '01/09/2009 - Mod x datahelper x datatable 
                    'ModuUtil.LlenarComboIDs(ObjVentaCargaContado.rstVarAgencias, cmbAgenciaOrigen, ObjVentaCargaContado.coll_AgenciasVenta, objGuiaEnvio.iIDAGENCIAS)
                    ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_VarAgencias, cmbAgenciaOrigen, ObjVentaCargaContado.coll_AgenciasVenta, objGuiaEnvio.iIDAGENCIAS)
                    '
                    coll_AgenciasOrigen = CType(ObjVentaCargaContado.coll_AgenciasVenta, Collection)
                    '
                    'Modificado 03/09/2007
                    'If objGuiaEnvio.iIDAGENCIAS > 0 Then

                    '    'ModuUtil.LlenarComboIDs(ObjVentaCargaContado.rstVarAgencias, cmbAgenciaOrigen, ObjVentaCargaContado.coll_AgenciasVenta, objGuiaEnvio.iIDAGENCIAS)
                    '    'modificado 03/09/2007 
                    '    ModuUtil.LlenarComboIDs(ObjVentaCargaContado.rstVarAgencias, cmbAgenciaOrigen, ObjVentaCargaContado.coll_AgenciasVenta, dtoUSUARIOS.iIDAGENCIAS)
                    'Else
                    '    'ModuUtil.LlenarComboIDs(ObjVentaCargaContado.rstVarAgencias, cmbAgenciaOrigen, ObjVentaCargaContado.coll_AgenciasVenta, Int(ObjVentaCargaContado.rstVarAgencias.Fields(0).Value))
                    '    'Modificado 03/09/2007 
                    '    ModuUtil.LlenarComboIDs(ObjVentaCargaContado.rstVarAgencias, cmbAgenciaOrigen, ObjVentaCargaContado.coll_AgenciasVenta, dtoUSUARIOS.iIDAGENCIAS)
                    'End If
                Else
                    '
                    objGuiaEnvio.iIDAGENCIAS_DESTINO = 0
                    '
                    cmbAgenciaOrigen.Controls.Clear()
                    cmbAgenciaOrigen.Items.Clear()
                End If
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub cmbAgenciaVenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAgenciaVenta.SelectedIndexChanged
        Try
            Dim idTipoEntrega As Integer = Int(objGuiaEnvio.coll_Lista_Tipo_Entrega.Item(Me.cmbTipo_Entrega.SelectedIndex.ToString()))
            If idTipoEntrega = 1 Then ' AGENCIA
                txtDireccionDestinatario.Text = cmbAgenciaVenta.Text
            End If

        Catch ex As Exception
        End Try
    End Sub
    Public Function fnImprimirEtiquetasN95() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.HoraImpresion
            prn.Nombre_impresora = NOMBRE_IMPRESORA '"\\192.168.50.147\PRNZEBRA"
            Dim EXISTE As Boolean = prn.SetearImpresora()

            'ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
            'ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            'ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            'ObjCODIGOBARRA.Cantidad = ObjVentaCargaContado.v_CANTIDAD_ETIQUETAS

            'Dim I As Int16 = 1
            Dim i As Int16
            If bRango Then
                i = 1
            Else
                i = correlativo_inicial
                'Mod 21/08/2009 
                If i = 0 Then i = 1
            End If
            ObjCODIGOBARRA.tipo = 3
            ObjCODIGOBARRA.id = objGuiaEnvio.iIDGUIAS_ENVIO
            ObjCODIGOBARRA.sp_etiqueta_generada()
            '28/08/2009 - Obtiene Fecha y Hora - Hlamas 
            'sFecha = ObjVentaCargaContado.rstFechaRegistro.Fields(0).Value
            'sHora = ObjVentaCargaContado.rstFechaRegistro.Fields(1).Value
            ObjVentaCargaContado.fnFechaRegistro(3, objGuiaEnvio.iIDGUIAS_ENVIO)
            sFecha = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(0)
            sHora = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(1)
            HoraActual = sHora
            ObjCODIGOBARRA.Fecha = sFecha
            '05/09/2009 - Cambiando por data helper 
            ' While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
            '    ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(0).Value
            '    prn.EscribeLinea("^XA")
            '    prn.EscribeLinea("^PW400")
            '    prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD " & ObjCODIGOBARRA.NroDOC & "          " & ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(1).Value.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & "^FS")
            '    'prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD " & Me.TextBox1.Text & "^FS")
            '    'prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & Me.TextBox2.Text & I & "^FS")
            '    prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.clinte & "^FS")
            '    prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & ObjCODIGOBARRA.CodigoBarra & "^FS")
            '    prn.EscribeLinea("^FT17,141^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
            '    prn.EscribeLinea("^FT96,142^A0N,39,45^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")
            '    prn.EscribeLinea("^FT305,188^AAN,18,10^FH\^FDTEPSAC^FS")
            '    prn.EscribeLinea("^FT183,188^AAN,18,10^FH\^FD" & HoraActual & "^FS")
            '    prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & ObjCODIGOBARRA.Fecha & "^FS")
            '    prn.EscribeLinea("^PQ1,0,1,Y")
            '    prn.EscribeLinea("^XZ")
            '    prn.EscribeLinea(cadena)
            '    ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
            '    I = I + 1
            'End While

            'For Each row As DataRow In ObjVentaCargaContado.dt_cur_codBarras.Rows
            For Each row As DataRow In ObjVentaCargaContado.dt_Cur_CODIGOBARRAS.Rows
                '
                ObjCODIGOBARRA.CodigoBarra = row.Item(0)
                '
                prn.EscribeLinea("^XA")
                prn.EscribeLinea("^PW400")
                prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD " & ObjCODIGOBARRA.NroDOC & "          " & row.Item(1).ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & "^FS")
                'prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD " & Me.TextBox1.Text & "^FS")
                'prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & Me.TextBox2.Text & I & "^FS")
                prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.clinte & "^FS")
                prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & ObjCODIGOBARRA.CodigoBarra & "^FS")
                prn.EscribeLinea("^FT17,141^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
                prn.EscribeLinea("^FT96,142^A0N,39,45^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")
                prn.EscribeLinea("^FT305,188^AAN,18,10^FH\^FDTEPSAC^FS")
                prn.EscribeLinea("^FT183,188^AAN,18,10^FH\^FD" & HoraActual & "^FS")
                prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & ObjCODIGOBARRA.Fecha & "^FS")
                prn.EscribeLinea("^PQ1,0,1,Y")
                prn.EscribeLinea("^XZ")
                prn.EscribeLinea(cadena)
                'ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
                i = i + 1
            Next
            '
            prn.FinDoc()
        Catch ex As Exception
            MsgBox(ex.ToString)
            flag = False
        End Try
        Return flag
    End Function
    Public Function fnImprimirEtiquetasFAC_IIN95() As Boolean

        Dim flag As Boolean = True

        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.HoraImpresion
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()

            'ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
            'ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            'ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            'ObjCODIGOBARRA.Cantidad = ObjVentaCargaContado.v_CANTIDAD_ETIQUETAS

            'Dim I As Int16 = 1
            Dim i As Int16
            If bRango Then
                i = 1
            Else
                i = correlativo_inicial
                'Mod 21/08/2009 
                If i = 0 Then i = 1
            End If

            ObjCODIGOBARRA.tipo = 3
            ObjCODIGOBARRA.id = objGuiaEnvio.iIDGUIAS_ENVIO
            ObjCODIGOBARRA.sp_etiqueta_generada()
            '28/08/2009 - Obtiene Fecha y Hora - Hlamas 
            '04/09/2009 - Obtiene Fecha y Hora x datahelper 
            ObjVentaCargaContado.fnFechaRegistro(3, objGuiaEnvio.iIDGUIAS_ENVIO)
            sFecha = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(0)
            sHora = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(1)
            HoraActual = sHora
            ObjCODIGOBARRA.Fecha = sFecha

            '04/09/2009 - CAmbiar x data helper 
            '   While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
            '    ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(0).Value
            '    prn.EscribeLinea("<STX><ESC>C0<ETX>")
            '    prn.EscribeLinea("<STX><ESC>k<ETX>")
            '    prn.EscribeLinea("<STX><SI>N60<ETX>")
            '    prn.EscribeLinea("<STX><SI>L197<ETX>")
            '    prn.EscribeLinea("<STX><SI>S20<ETX>")
            '    prn.EscribeLinea("<STX><SI>d0<ETX>")
            '    prn.EscribeLinea("<STX><SI>h0,0;<ETX>")
            '    prn.EscribeLinea("<STX><SI>l8<ETX>")
            '    prn.EscribeLinea("<STX><SI>I3<ETX>")
            '    prn.EscribeLinea("<STX><SI>F20<ETX>")
            '    prn.EscribeLinea("<STX><SI>D0<ETX>")
            '    prn.EscribeLinea("<STX><SI>t0<ETX>")
            '    prn.EscribeLinea("<STX><SI>W394<ETX>")
            '    prn.EscribeLinea("<STX><SI>g1,567<ETX>")
            '    prn.EscribeLinea("<STX><ESC>P<ETX>")
            '    prn.EscribeLinea("<STX>E*;F*;<ETX>")
            '    prn.EscribeLinea("<STX>L1;<ETX>")
            '    prn.EscribeLinea("<STX>D0;<ETX>")
            '    prn.EscribeLinea("<STX>H0;o165,12;f3;c25;h12;w20;d3," & ObjCODIGOBARRA.clinte & ";<ETX>")
            '    prn.EscribeLinea("<STX>D1;<ETX>")
            '    prn.EscribeLinea("<STX>H1;o130,13;f3;c25;h9;w15;d3," & ObjCODIGOBARRA.NroDOC & " -" & ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(1).Value.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & ";<ETX>")
            '    prn.EscribeLinea("<STX>H2;o88,11;f3;c25;h11;w11;d3," & ObjCODIGOBARRA.Origen & " / ;<ETX>")
            '    prn.EscribeLinea("<STX>B3;o96,160;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
            '    prn.EscribeLinea("<STX>H4;o14,13;f3;c25;h7;w7;d3," & ObjCODIGOBARRA.Fecha & ";<ETX>")
            '    prn.EscribeLinea("<STX>H5;o14,200;f3;c25;h7;w7;d3," & HoraActual & ";<ETX>")
            '    prn.EscribeLinea("<STX>H6;o14,300;f3;c25;h7;w7;d3,TEPSAC;<ETX>")
            '    prn.EscribeLinea("<STX>H7;o102,96;f3;c25;h17;w16;d3," & ObjCODIGOBARRA.Destino & ";<ETX>")
            '    prn.EscribeLinea("<STX>R<ETX>")
            '    prn.EscribeLinea("<STX><ESC>E*<CAN><ETX>")
            '    prn.EscribeLinea("<STX><RS>1<US>1<ETB><ETX>")
            '    '
            '    prn.EscribeLinea(cadena)
            '    ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
            '    I = I + 1
            'End While
            '

            For Each row As DataRow In ObjVentaCargaContado.dt_Cur_CODIGOBARRAS.Rows  'ObjVentaCargaContado.dt_cur_codBarras.Rows
                ObjCODIGOBARRA.CodigoBarra = row.Item(0)
                '
                prn.EscribeLinea("<STX><ESC>C0<ETX>")
                prn.EscribeLinea("<STX><ESC>k<ETX>")
                prn.EscribeLinea("<STX><SI>N60<ETX>")
                prn.EscribeLinea("<STX><SI>L197<ETX>")
                prn.EscribeLinea("<STX><SI>S20<ETX>")
                prn.EscribeLinea("<STX><SI>d0<ETX>")
                prn.EscribeLinea("<STX><SI>h0,0;<ETX>")
                prn.EscribeLinea("<STX><SI>l8<ETX>")
                prn.EscribeLinea("<STX><SI>I3<ETX>")
                prn.EscribeLinea("<STX><SI>F20<ETX>")
                prn.EscribeLinea("<STX><SI>D0<ETX>")
                prn.EscribeLinea("<STX><SI>t0<ETX>")
                prn.EscribeLinea("<STX><SI>W394<ETX>")
                prn.EscribeLinea("<STX><SI>g1,567<ETX>")
                prn.EscribeLinea("<STX><ESC>P<ETX>")
                prn.EscribeLinea("<STX>E*;F*;<ETX>")
                prn.EscribeLinea("<STX>L1;<ETX>")
                prn.EscribeLinea("<STX>D0;<ETX>")
                prn.EscribeLinea("<STX>H0;o165,12;f3;c25;h12;w20;d3," & ObjCODIGOBARRA.clinte & ";<ETX>")
                prn.EscribeLinea("<STX>D1;<ETX>")
                prn.EscribeLinea("<STX>H1;o130,13;f3;c25;h9;w15;d3," & ObjCODIGOBARRA.NroDOC & " -" & row.Item(1).ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & ";<ETX>")

                prn.EscribeLinea("<STX>H2;o88,11;f3;c25;h11;w11;d3," & ObjCODIGOBARRA.Origen & " / ;<ETX>")
                prn.EscribeLinea("<STX>B3;o96,160;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
                prn.EscribeLinea("<STX>H4;o14,13;f3;c25;h7;w7;d3," & ObjCODIGOBARRA.Fecha & ";<ETX>")
                prn.EscribeLinea("<STX>H5;o14,200;f3;c25;h7;w7;d3," & HoraActual & ";<ETX>")
                prn.EscribeLinea("<STX>H6;o14,300;f3;c25;h7;w7;d3,TEPSAC;<ETX>")
                prn.EscribeLinea("<STX>H7;o102,96;f3;c25;h17;w16;d3," & ObjCODIGOBARRA.Destino & ";<ETX>")
                prn.EscribeLinea("<STX>R<ETX>")
                prn.EscribeLinea("<STX><ESC>E*<CAN><ETX>")
                prn.EscribeLinea("<STX><RS>1<US>1<ETB><ETX>")
                prn.EscribeLinea(cadena)
                '
                i = i + 1
            Next
            '
            prn.FinDoc()
        Catch ex As Exception
            MsgBox(ex.ToString)
            flag = False
        End Try
        Return flag
    End Function
    Private Sub btnTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTicket.Click
        Try
            '08/09/2009 -  Pasando al datahelper - último procedimiento hecho por de lamas 
            Dim ll_idusuario_tmp As Long
            If dtGridViewControl_GUIAS.Rows().Count - 1 = 0 Then
                Return
            End If
            Dim row As Integer = dtGridViewControl_GUIAS.SelectedRows.Item(0).Index
            If dtGridViewControl_GUIAS.Rows().Count - 1 = row Then
                Return
            End If


            objGuiaEnvio.iIDGUIAS_ENVIO = dtGridViewControl_GUIAS.Rows(row).Cells(1).Value


            'Dim cmd As New System.Data.OracleClient.OracleCommand
            'cmd.Connection = cnn
            'cmd.CommandType = CommandType.StoredProcedure
            'cmd.CommandText = "PKG_IVOVENTACARGA.sp_nro_bultos"

            'cmd.Parameters.Add(New OracleClient.OracleParameter("p_idguias_envio", OracleClient.OracleType.Number)).Value = objGuiaEnvio.iIDGUIAS_ENVIO
            'cmd.Parameters.Add(New OracleClient.OracleParameter("cur_nro_bultos", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output


            'Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)

            'Dim ds As New DataSet
            'daora.Fill(ds)
            objGuiaEnvio.get_nro_bultos_x_reimpresion()
            total_bultos = objGuiaEnvio.total_bultos
            ' 
            If objGuiaEnvio.iIDGUIAS_ENVIO = 0 Then
                MsgBox("No puede realizar esta operación ...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            '
            Dim objEtiqueta As New dtoGuiaEnvio
            'If fnValidar_Rol("21") = True Then
            'bloque
            If Acceso.SiRol(G_Rol, Me, 8) Then
                If MsgBox("Esta Seguro de Imprimir Etiquetas..?", MsgBoxStyle.YesNo, "Seguridad Sistemas") = MsgBoxResult.No Then Exit Sub
                'Verifica si documento para el cual se reimprimiran etiquetas ya ha sido impreso
                If objEtiqueta.fnEtiquetaImpresa(3, dtGridViewControl_GUIAS.Rows(row).Cells(1).Value) Then
                    If objEtiqueta.dt_cur_etiqueta.Rows(0).Item(0) = 1 Then
                        'Obtener usuario y password de usuario que reimprime
                        ll_idusuario_tmp = dtoUSUARIOS.IdLogin
                        Dim lfrmusuario_entrega As New frmUsuarioEtiqueta
                        lfrmusuario_entrega.Lab_tip_dcto.Text = "GUIA DE ENVIO" '24/10/2008
                        lfrmusuario_entrega.txt_dcto.Text = dtGridViewControl_GUIAS.Rows(row).Cells(3).Value '24/10/2008
                        lfrmusuario_entrega.txt_origen.Text = dtGridViewControl_GUIAS.Rows(row).Cells(7).Value
                        lfrmusuario_entrega.txt_destino.Text = dtGridViewControl_GUIAS.Rows(row).Cells(8).Value

                        lfrmusuario_entrega.txtLogin.Text = dtoUSUARIOS.iLOGIN
                        lfrmusuario_entrega.txtPasswor.Focus()

                        'lfrmusuario_entrega.ShowDialog()
                        Acceso.Asignar(lfrmusuario_entrega, Me.hnd)
                        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                            lfrmusuario_entrega.ShowDialog()
                            If lfrmusuario_entrega.pb_cancelar = True Then
                                Exit Sub ' No hace nada 
                            End If
                            dtoUSUARIOS.IdLogin = lfrmusuario_entrega.pl_idusuario_personal
                        Else
                            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return
                        End If
                    End If
                End If
                'Genera etiquetas
                Dim sEtiqueta As String
                Dim sMotivo As String
                '

                If objEtiqueta.dt_cur_etiqueta.Rows(0)(0) = 1 Then
                    Dim a As New FrmRangoEtiquetas()
                    '
                    a.total_bultos = total_bultos
                    '
                    'a.ShowDialog()

                    Acceso.Asignar(a, Me.hnd)
                    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                        a.ShowDialog()
                        sMotivo = a.txtMotivo.Text
                        sEtiqueta = a.NumeUDini.Value
                        bRango = False
                    Else
                        MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If
                Else
                    Dim a As New FrmRangoEtiquetas2()
                    '
                    a.total_bultos = total_bultos
                    '
                    'a.ShowDialog()

                    Acceso.Asignar(a, Me.hnd)
                    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                        a.ShowDialog()
                        bRango = True
                    Else
                        MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If

                End If

                If correlativo_inicial = -1 Then Exit Sub
                ObjVentaCargaContado.UsuarioEtiqueta = dtoUSUARIOS.IdLogin
                '09/09/2009 - Cambiado x data helper 
                If ObjVentaCargaContado.fnREIMPRESIONCODIGOSII(3, objGuiaEnvio.iIDGUIAS_ENVIO, correlativo_inicial, correlativo_final) = True Then
                    If xIMPRESORA = 1 Then
                        fnImprimirEtiquetasN95()
                    Else
                        If xIMPRESORA = 2 Then
                            fnImprimirEtiquetasFAC_IIN95()
                        Else
                            fnImprimirEtiquetasFAC_IIN97()
                        End If
                    End If

                    If objEtiqueta.dt_cur_etiqueta.Rows(0)(0) = 1 Then
                        '02/09/2009 - Actualiza auditoria de reimpresion de etiquetas
                        Dim objReimpresionEtiquetas As New dtoGuiaEnvio
                        If objReimpresionEtiquetas.fnActualizaReimpresion(3, dtGridViewControl_GUIAS.Rows(row).Cells(1).Value, ObjCODIGOBARRA.CodigoBarra, sMotivo, dtoUSUARIOS.m_sFecha, dtoUSUARIOS.IdLogin, ObjCODIGOBARRA.fnGetHora, sEtiqueta) Then
                        End If
                    Else
                        ObjCODIGOBARRA.tipo = 3
                        ObjCODIGOBARRA.id = objGuiaEnvio.iIDGUIAS_ENVIO
                        ObjCODIGOBARRA.sp_etiqueta_generada()
                    End If

                    'End If
                Else
                    MsgBox("No puede cargar esta data, faltan datos...", MsgBoxStyle.Information, "Seguridad Sistema")
                End If
            Else
                MsgBox("Usted no tiene persmiso para realizar esta operación")
            End If
            If objEtiqueta.dt_cur_etiqueta.Rows(0)(0) = 1 Then
                dtoUSUARIOS.IdLogin = ll_idusuario_tmp
            End If
SALIR:
        Catch ex As Exception
            MsgBox("Revise sus Datos.., Operacion Cancelada", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        'Try
        '    If dtGridViewControl_FACBOL.Rows().Count - 1 = 0 Then
        '        MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
        '        Return
        '    End If
        '    Dim row As Integer = dtGridViewControl_FACBOL.SelectedRows.Item(0).Index
        '    If dtGridViewControl_FACBOL.Rows().Count - 1 = row Then
        '        MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
        '        Return
        '    End If
        '    Dim v_idFacura As Integer = dtGridViewControl_FACBOL.Rows(row).Cells(1).Value
        '    If ObjVentaCargaContado.fnREIMPRESIONCODIGOS(1, v_idFacura) = True Then
        '        If MsgBox("Esta Seguro de Imprimir Etiquetas..?", MsgBoxStyle.YesNo, "Seguridad Sistemas") = MsgBoxResult.Yes Then

        '            If xIMPRESORA = 1 Then
        '                fnImprimirEtiquetasN95()
        '            Else
        '                fnImprimirEtiquetasFAC_IIN95()
        '            End If
        '        End If

        '    Else
        '        MsgBox("No puede cargar esta data, faltan datos...", MsgBoxStyle.Information, "Seguridad Sistema")
        '    End If
        'Catch ex As Exception
        '    MsgBox("revizar datos....", MsgBoxStyle.Information, "Seguridad Sistema")
        'End Try
    End Sub

    Private Sub ExportExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportExcelToolStripMenuItem.Click
        Try
            fnEXCELGrid(dtGridViewControl_GUIAS)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub txtiWinOrigen_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtiWinOrigen.Validating
        Try
            If lb_no_lee = True Then
                If Me.txtiWinOrigen.Text = "" Then
                    Exit Sub
                End If
                limpia_monto_x_cambio()
                objGuiaEnvio.iIDAGENCIAS = 0
                fnAgenciaOrigen()
                '12/08/2008 - Valida que existan los datos para recuperar de nuevo la tarifa
                Dim idUnidadAgencias As Integer = iWinOrigen.IndexOf(txtiWinOrigen.Text)
                If idUnidadAgencias >= 0 Then
                    idUnidadAgencias = Int(coll_iDestino.Item(idUnidadAgencias.ToString))
                    If idUnidadAgencias <> 0 Then
                        '
                        If fArticulo = True Then
                            fArticulo = False
                            Me.dtGridViewArticulo.Visible = False
                            Me.dtGridViewBultos.Visible = True
                        End If
                        '
                        recupera_tarifa()
                    End If
                End If
                '
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Function fnImprimirEtiquetasGUIA_III() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()
            'ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
            'ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            '   ObjCODIGOBARRA.Cantidad = objGuiaEnvio.v_CANTIDAD_ETIQUETAS
            'Dim I As Int16 = 1
            Dim i As Int16
            If bRango Then
                i = 1
            Else
                i = correlativo_inicial
                'Mod 21/08/2009 
                If i = 0 Then i = 1
            End If

            ObjCODIGOBARRA.tipo = 3
            ObjCODIGOBARRA.id = objGuiaEnvio.iIDGUIAS_ENVIO
            ObjCODIGOBARRA.sp_etiqueta_generada()
            '26/08/2009 - Obtiene Fecha y Hora - Hlamas 
            '04/09/2009 - Obtiene Fecha y Hora x datahelper 
            ObjVentaCargaContado.fnFechaRegistro(3, objGuiaEnvio.iIDGUIAS_ENVIO)
            sFecha = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(0)
            sHora = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(1)
            HoraActual = sHora
            ObjCODIGOBARRA.Fecha = sFecha
            '04/09/2009 - Cambio por datahelper 
            'While objGuiaEnvio.cur_codBarras.EOF = False And objGuiaEnvio.cur_codBarras.BOF = False
            '    ObjCODIGOBARRA.CodigoBarra = objGuiaEnvio.cur_codBarras.Fields.Item(0).Value
            '    prn.EscribeLinea("N")
            '    prn.EscribeLinea("N")
            '    '
            '    prn.EscribeLinea("A30,14,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
            '    prn.EscribeLinea("A30,47,0,4,1,1,N,""" & Mid(ObjCODIGOBARRA.NroDOC, 5, 13) & " -" & objGuiaEnvio.cur_codBarras.Fields.Item(1).Value.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
            '    prn.EscribeLinea("A317,47,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
            '    prn.EscribeLinea("A30,110,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-  """)
            '    prn.EscribeLinea("A30,163,0,1,1,1,N,""" & ObjCODIGOBARRA.Fecha & """")
            '    prn.EscribeLinea("A321,163,0,1,1,1,N,""TEPSAC""")
            '    prn.EscribeLinea("A205,163,0,1,1,1,N,""" & HoraActual & """")
            '    prn.EscribeLinea("A89,94,0,4,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
            '    prn.EscribeLinea("B148,83,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """")
            '    '
            '    prn.EscribeLinea("P1")
            '    prn.EscribeLinea("N")
            '    prn.EscribeLinea(cadena)
            '    objGuiaEnvio.cur_codBarras.MoveNext()
            '    I = I + 1
            'End While
            For Each row As DataRow In objGuiaEnvio.dt_cur_codBarras.Rows
                ObjCODIGOBARRA.CodigoBarra = row.Item(0)
                prn.EscribeLinea("N")
                prn.EscribeLinea("N")
                '
                prn.EscribeLinea("A30,14,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
                prn.EscribeLinea("A30,47,0,4,1,1,N,""" & Mid(ObjCODIGOBARRA.NroDOC, 5, 13) & " -" & row.Item(1).ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
                prn.EscribeLinea("A317,47,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
                prn.EscribeLinea("A30,110,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-  """)
                prn.EscribeLinea("A30,163,0,1,1,1,N,""" & ObjCODIGOBARRA.Fecha & """")
                prn.EscribeLinea("A321,163,0,1,1,1,N,""TEPSAC""")
                prn.EscribeLinea("A205,163,0,1,1,1,N,""" & HoraActual & """")
                prn.EscribeLinea("A89,94,0,4,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
                prn.EscribeLinea("B148,83,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """")
                '
                prn.EscribeLinea("P1")
                prn.EscribeLinea("N")
                prn.EscribeLinea(cadena)
                '
                i = i + 1
            Next
            '
            prn.FinDoc()
        Catch ex As Exception
            MsgBox(ex.ToString)
            flag = False
        End Try
        Return flag
    End Function
    Public Function fnImprimirEtiquetasFAC_IIN97() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.HoraImpresion
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()
            'Dim I As Int16 = 1
            'hlamas 24/08/2009
            Dim i As Int16
            If bRango Then
                i = 1
            Else
                i = correlativo_inicial
                If i = 0 Then i = 1
            End If

            ObjCODIGOBARRA.tipo = 3
            ObjCODIGOBARRA.id = objGuiaEnvio.iIDGUIAS_ENVIO
            ObjCODIGOBARRA.sp_etiqueta_generada()

            'Obtiene Fecha y Hora
            ObjVentaCargaContado.fnFechaRegistro(3, objGuiaEnvio.iIDGUIAS_ENVIO)
            sFecha = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(0)
            sHora = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(1)
            '
            HoraActual = sHora
            ObjCODIGOBARRA.Fecha = sFecha
            For Each row As DataRow In ObjVentaCargaContado.dt_Cur_CODIGOBARRAS.Rows 'dt_cur_codBarras.Rows
                ObjCODIGOBARRA.CodigoBarra = row.Item(0)
                '
                prn.EscribeLinea("N")
                prn.EscribeLinea("N")
                '
                prn.EscribeLinea("A30,14,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
                '
                prn.EscribeLinea("A30,47,0,4,1,1,N,""" & ObjCODIGOBARRA.NroDOC & " -" & row.Item(1).ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
                '
                prn.EscribeLinea("A317,47,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
                prn.EscribeLinea("A30,110,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-  """)
                prn.EscribeLinea("A30,163,0,1,1,1,N,""" & ObjCODIGOBARRA.Fecha & """")
                prn.EscribeLinea("A321,163,0,1,1,1,N,""TEPSAC""")
                prn.EscribeLinea("A205,163,0,1,1,1,N,""" & HoraActual & """")
                prn.EscribeLinea("A89,94,0,4,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
                prn.EscribeLinea("B148,83,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """")
                '
                prn.EscribeLinea("P1")
                prn.EscribeLinea("N")
                prn.EscribeLinea(cadena)
                '
                i = i + 1
            Next
            'While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
            '    ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(0).Value

            '    prn.EscribeLinea("N")
            '    prn.EscribeLinea("N")

            '    prn.EscribeLinea("A30,14,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
            '    prn.EscribeLinea("A30,47,0,4,1,1,N,""" & ObjCODIGOBARRA.NroDOC & " -" & ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(1).Value.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
            '    prn.EscribeLinea("A317,47,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
            '    prn.EscribeLinea("A30,110,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-  """)
            '    prn.EscribeLinea("A30,163,0,1,1,1,N,""" & ObjCODIGOBARRA.Fecha & """")
            '    prn.EscribeLinea("A321,163,0,1,1,1,N,""TEPSAC""")
            '    prn.EscribeLinea("A205,163,0,1,1,1,N,""" & HoraActual & """")
            '    prn.EscribeLinea("A89,94,0,4,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
            '    prn.EscribeLinea("B148,83,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """")

            '    prn.EscribeLinea("P1")
            '    prn.EscribeLinea("N")
            '    prn.EscribeLinea(cadena)
            '    ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
            '    i = i + 1
            'End While
            prn.FinDoc()
        Catch ex As Exception
            MsgBox(ex.ToString)
            flag = False
        End Try
        Return flag
    End Function
    'Public Function fnImprimirEtiquetasFAC_IIN97() As Boolean
    '    Dim flag As Boolean = True
    '    Try
    '        Dim prn As New PrinterTxt.PrintTxt
    '        Dim cadena As String = ""
    '        Dim HoraActual As String = ObjCODIGOBARRA.HoraImpresion
    '        'prn.Nombre_impresora = "PRNZEBRA"
    '        prn.Nombre_impresora = NOMBRE_IMPRESORA
    '        Dim EXISTE As Boolean = prn.SetearImpresora()
    '        'Dim I As Int16 = 1
    '        Dim i As Int16
    '        If bRango Then
    '            i = 1
    '        Else
    '            i = correlativo_inicial
    '            'Mod 21/08/2009 
    '            If i = 0 Then i = 1
    '        End If

    '        ObjCODIGOBARRA.tipo = 3
    '        ObjCODIGOBARRA.id = objGuiaEnvio.iIDGUIAS_ENVIO
    '        ObjCODIGOBARRA.sp_etiqueta_generada()
    '        '
    '        '26/08/2009 - Obtiene Fecha y Hora - Hlamas    
    '        '04/09/2009 - Obtiene Fecha y Hora x datahelper 
    '        ObjVentaCargaContado.fnFechaRegistro(3, objGuiaEnvio.iIDGUIAS_ENVIO)
    '        sFecha = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(0)
    '        sHora = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(1)
    '        '
    '        HoraActual = sHora
    '        '
    '        'ObjCODIGOBARRA.Fecha = sFecha
    '        ''
    '        'For Each row As DataRow In ObjVentaCargaContado.d_Cur_CODIGOBARRAS

    '        'Next
    '        '05/09/2009 - Cambiando por datahelper 
    '        'While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
    '        '    ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(0).Value
    '        '    '
    '        '    prn.EscribeLinea("N")
    '        '    prn.EscribeLinea("N")
    '        '    '
    '        '    prn.EscribeLinea("A30,14,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
    '        '    prn.EscribeLinea("A30,47,0,4,1,1,N,""" & ObjCODIGOBARRA.NroDOC & " -" & ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(1).Value.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
    '        '    prn.EscribeLinea("A317,47,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
    '        '    prn.EscribeLinea("A30,110,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-  """)
    '        '    prn.EscribeLinea("A30,163,0,1,1,1,N,""" & ObjCODIGOBARRA.Fecha & """")
    '        '    prn.EscribeLinea("A321,163,0,1,1,1,N,""TEPSAC""")
    '        '    prn.EscribeLinea("A205,163,0,1,1,1,N,""" & HoraActual & """")
    '        '    prn.EscribeLinea("A89,94,0,4,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
    '        '    prn.EscribeLinea("B148,83,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """")
    '        '    '
    '        '    prn.EscribeLinea("P1")
    '        '    prn.EscribeLinea("N")
    '        '    prn.EscribeLinea(cadena)
    '        '    ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
    '        '    '
    '        '    i = i + 1
    '        'End While
    '        '
    '        For Each row As DataRow In ObjVentaCargaContado.dt_cur_codBarras.Rows
    '            ObjCODIGOBARRA.CodigoBarra = row.Item(0)
    '            '
    '            prn.EscribeLinea("N")
    '            prn.EscribeLinea("N")
    '            '
    '            prn.EscribeLinea("A30,14,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
    '            '
    '            prn.EscribeLinea("A30,47,0,4,1,1,N,""" & ObjCODIGOBARRA.NroDOC & " -" & row.Item(1).Value.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
    '            '
    '            prn.EscribeLinea("A317,47,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
    '            prn.EscribeLinea("A30,110,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-  """)
    '            prn.EscribeLinea("A30,163,0,1,1,1,N,""" & ObjCODIGOBARRA.Fecha & """")
    '            prn.EscribeLinea("A321,163,0,1,1,1,N,""TEPSAC""")
    '            prn.EscribeLinea("A205,163,0,1,1,1,N,""" & HoraActual & """")
    '            prn.EscribeLinea("A89,94,0,4,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
    '            prn.EscribeLinea("B148,83,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """")
    '            '
    '            prn.EscribeLinea("P1")
    '            prn.EscribeLinea("N")
    '            prn.EscribeLinea(cadena)
    '            '
    '            i = i + 1
    '        Next

    '        prn.FinDoc()
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Private Sub CARGAR_DATOS_CLIENTE()
        BuscarClientesGuia_EnvioCC()
    End Sub
    Private Sub cmbSubCuenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubCuenta.SelectedIndexChanged
        If lb_solo_visualiza = False Then
            If cmbSubCuenta.Focused = True Then
                '12/08/2008 - 
                limpia_monto_x_cambio()

                CARGAR_DATOS_CLIENTE()
                '
                '19/08/2008 - recupera la tarifa de la sub - cuenta  
                recupera_tarifa()
                '
                cargar_articulos()
                '
            End If
        End If
    End Sub
    Private Sub cargar_articulos()
        Try
            If lb_solo_visualiza = False Then
                Dim idPersona As Integer = iWinPerosa.IndexOf(TxtRasonSocial.Text)
                objGuiaEnvio.iIDPERSONA = Int(coll_Lista_Personas.Item(idPersona.ToString))
                '
                objGuiaEnvio.iIDUNIDAD_AGENCIA = Int(coll_iOrigen.Item(iWinOrigen.IndexOf(txtiWinOrigen.Text.ToString()) + 1).ToString())
                objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = Int(coll_iDestino.Item(iWinDestino.IndexOf(txtiWinDestino.Text.ToString()) + 1).ToString())
                '
                objGuiaEnvio.iIDCENTRO_COSTO = Int(objGuiaEnvio.coll_Sub_Cuenta.Item(cmbSubCuenta.SelectedIndex.ToString))
                '
                Dim i As Integer = 0
                For i = 1 To dtGridViewArticulo.Rows().Count
                    dtGridViewArticulo.Rows().RemoveAt(0)
                Next

                txtSubTotal.Text = "0.00"
                txMontotIGV.Text = "0.00"
                txtTotal_Pago.Text = "0.00"

                For i = 0 To 2
                    dtGridViewBultos(2, i).Value() = ""
                    dtGridViewBultos(3, i).Value() = ""
                    dtGridViewBultos(5, i).Value() = "0.00"
                    ' dtGridViewBultos(4, i).Value() = "0.00" '19/08/2008 - 1 
                Next
                'Mod. 24/08/2009 -->Omendoza - Pasando al datahelper   
                If objGuiaEnvio.fnSP_CONSULTA_ARTI_SUB_CUENTA() = True Then
                    '
                    '05/09/2009 - Mod. por Datahelper 
                    '
                    'If objGuiaEnvio.rst_Articulos_sub_cuenta.State = 1 Then
                    '    While objGuiaEnvio.rst_Articulos_sub_cuenta.BOF = False And objGuiaEnvio.rst_Articulos_sub_cuenta.EOF = False
                    '        Dim row0 As String() = {Int(objGuiaEnvio.rst_Articulos_sub_cuenta.Fields.Item(0).Value).ToString, _
                    '        objGuiaEnvio.rst_Articulos_sub_cuenta.Fields.Item(1).Value, _
                    '        objGuiaEnvio.rst_Articulos_sub_cuenta.Fields.Item(2).Value.ToString, _
                    '        "", _
                    '        "", _
                    '        "", _
                    '        "0.00"}


                    '        dtGridViewArticulo.Rows().Add(row0)
                    '        objGuiaEnvio.rst_Articulos_sub_cuenta.MoveNext()
                    '    End While
                    'End If
                    '
                    If objGuiaEnvio.dt_rst_Articulos_sub_cuenta.Rows.Count > 0 Then
                        For Each row As DataRow In objGuiaEnvio.dt_rst_Articulos_sub_cuenta.Rows
                            Dim row0 As String() = {Int(row.Item(0)).ToString, _
                            row.Item(1), _
                            row.Item(2).ToString, _
                            "", _
                            "", _
                            "", _
                            "0.00"}
                            dtGridViewArticulo.Rows().Add(row0)
                        Next
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Function fn_peso_desde_articulos() As Double

        Dim ipeso As Double = 0

        For ii As Integer = 0 To Me.dtGridViewArticulo.Rows().Count() - 1
            If IsDBNull(dtGridViewArticulo.Rows(ii).Cells(3)) = False Then
                If dtGridViewArticulo.Rows(ii).Cells(3).Value.ToString <> "" Then
                    If Not dtGridViewArticulo.Rows(ii).Cells(5).Value.ToString = "" Then
                        ipeso = ipeso + CDbl(dtGridViewArticulo.Rows(ii).Cells(5).Value.ToString)
                    End If
                End If
            End If
        Next
        Return ipeso
    End Function
    Private Function fn_Volumen_desde_articulos() As Double
        Dim iVolumen As Double = 0
        For ii As Integer = 0 To Me.dtGridViewArticulo.Rows().Count() - 1
            If IsDBNull(dtGridViewArticulo.Rows(ii).Cells(3)) = False Then
                If dtGridViewArticulo.Rows(ii).Cells(3).Value.ToString <> "" Then
                    If Not dtGridViewArticulo.Rows(ii).Cells(4).Value.ToString = "" Then
                        iVolumen = iVolumen + CDbl(dtGridViewArticulo.Rows(ii).Cells(4).Value.ToString)
                    End If
                End If
            End If
        Next
        Return iVolumen
    End Function

    Private Sub TxtGuiaEnvio_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtGuiaEnvio.KeyUp
        If e.KeyCode = Keys.Enter Then


        End If
    End Sub

    Private Sub TxtGuiaEnvio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtGuiaEnvio.TextChanged

    End Sub

    Private Sub txtiWinOrigen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtiWinOrigen.TextChanged

    End Sub

    Private Sub txtiWinDestino_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtiWinDestino.TextChanged


    End Sub

    Private Sub TxtGuiaEnvio_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtGuiaEnvio.Validated

        If mostrar_pre_guias = False Then Exit Sub
        If Len(Me.TxtGuiaEnvio.Text) <= 0 Then Exit Sub
        '
        objPRE_GUIAS.NRO_GUIA = Me.TxtGuiaEnvio.Text
        'Mod.14/10/2009 -->Omendoza - Pasando al datahelper -  
        'If objPRE_GUIAS.SP_SELEC_SELECIONAR_PRE_GUIA(cnn) = True Then
        If objPRE_GUIAS.SP_SELEC_SELECIONAR_PRE_GUIA() = True Then
            'para origen
            txtiWinOrigen.Text = objPRE_GUIAS.ORIGEN
            Try
                'Modificado - 07/07/2009 - Por Jsalas 

                ' objGuiaEnvio.iIDAGENCIAS = 0
                ' fnAgenciaOrigen()
            Catch ex As Exception
            End Try

            ' para destino

            txtiWinDestino.Text = objPRE_GUIAS.DESTINO
            Try
                objGuiaEnvio.iIDAGENCIAS = 0
                fnAgenciaDestino()
            Catch ex As Exception

            End Try
            'idtipo_entrega carga
            'Datahelper
            'objGuiaEnvio.rst_Lista_Tipo_Entrega.MoveFirst()
            If Not objPRE_GUIAS.IDTIPO_ENTREGA_CARGA = 0 Then
                ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_Lista_Tipo_Entrega, cmbTipo_Entrega, objGuiaEnvio.coll_Lista_Tipo_Entrega, objPRE_GUIAS.IDTIPO_ENTREGA_CARGA)
            Else
                ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_Lista_Tipo_Entrega, cmbTipo_Entrega, objGuiaEnvio.coll_Lista_Tipo_Entrega, 1)
            End If
            '
            'CODIGO DEL CLIENTE
            Me.TxtRuc.Text = objPRE_GUIAS.CODIGO_CLIENTE
            '
            'RAZON SOCIAL DEL CLIENTE
            TxtRasonSocial.Text = objPRE_GUIAS.RAZON_SOCIAL

            '
            Try
                '
                'objLOG.fnLog("[ENTER] :" & TxtRasonSocial.Text.ToString)
                '
                ' fnCargar_iWin(Me.TxtRasonSocial, objGuiaEnvio.rst_Lista_Personas, coll_Lista_Personas, iWinPerosa, 0)
                'iWinPerosa()
                CONTROL = 2
                Dim indexof As Integer = 0
                If iWinPerosa.Count > 0 Then
                    'indexof = IIf(iWinContacto_Remitente.IndexOf(txtRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtRemitente.Text), -1)
                    indexof = IIf(iWinPerosa.IndexOf(TxtRasonSocial.Text) >= 0, iWinPerosa.IndexOf(TxtRasonSocial.Text), -1)
                    objGuiaEnvio.iIDPERSONA = -1
                    If indexof >= 0 Then
                        objGuiaEnvio.iIDPERSONA = Int(coll_Lista_Personas(indexof.ToString))
                        objGuiaEnvio.iCONTROLIdpersona = objGuiaEnvio.iIDPERSONA
                        If indexof <= iWinPerosaRUC.Count Then
                            Me.TxtRuc.Text = iWinPerosaRUC.Item(indexof)
                            txtCliente_Remitente.Text = TxtRasonSocial.Text
                            txtDocCliente_Remitente.Text = Me.TxtRuc.Text
                            objGuiaEnvio.iID_REMITENTE = objGuiaEnvio.iIDPERSONA
                            objGuiaEnvio.iREMITENTE = TxtRasonSocial.Text
                            objGuiaEnvio.iNRODOC_REM = Me.TxtRuc.Text
                            bControl_Busqueda = True
                            ' fnTarifario()
                            If BuscarClientesGuia_Envio() = True Then
                                'txtCliente_Remitente.Focus()
                                'txtCliente_Remitente.SelectAll()
                                txtDestinatario.Focus()
                                txtDestinatario.SelectAll()
                                'SendKeys.Send("{Tab}")
                                fnTarifario()
                            End If

                        End If
                    Else
                        MsgBox("El Nombre del Cliente No Tiene Linea de Credito, Revice sus datos", MsgBoxStyle.Information, "Seguridad Sistema")
                    End If
                End If
            Catch ex As Exception

            End Try
            '
            '07/07/2009 - Comentado a solicitud de Jsalas 
            'txtCliente_Remitente.Text = objPRE_GUIAS.REMITENTE 
            '

            txtDireccionRemitente.Text = objPRE_GUIAS.DIRECCIO_REMITENTE
        End If
    End Sub

    Private Sub TxtRuc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRuc.TextChanged

    End Sub

    Private Sub TxtRasonSocial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRasonSocial.TextChanged

    End Sub

    Private Sub TxtRuc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtRuc.Validated
        If flag_ver_datos = True Then Exit Sub
        If Len(Me.TxtRuc.Text) <= 0 Then Exit Sub
        '
        ''objLOG.fnLog("[ENTER] :" & TxtRasonSocial.Text.ToString)
        '
        ' fnCargar_iWin(Me.TxtRasonSocial, objGuiaEnvio.rst_Lista_Personas, coll_Lista_Personas, iWinPerosa, 0)
        'iWinPerosa()
        CONTROL = 2
        Dim indexof As Integer = 0
        If iWinPerosa.Count > 0 Then
            'indexof = IIf(iWinContacto_Remitente.IndexOf(txtRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtRemitente.Text), -1)
            indexof = IIf(iWinPerosa.IndexOf(TxtRasonSocial.Text) >= 0, iWinPerosa.IndexOf(TxtRasonSocial.Text), -1)
            objGuiaEnvio.iIDPERSONA = -1
            If indexof >= 0 Then
                objGuiaEnvio.iIDPERSONA = Int(coll_Lista_Personas(indexof.ToString))
                objGuiaEnvio.iCONTROLIdpersona = objGuiaEnvio.iIDPERSONA
                If indexof <= iWinPerosaRUC.Count Then
                    Me.TxtRuc.Text = iWinPerosaRUC.Item(indexof)
                    txtCliente_Remitente.Text = TxtRasonSocial.Text
                    txtDocCliente_Remitente.Text = Me.TxtRuc.Text
                    objGuiaEnvio.iID_REMITENTE = objGuiaEnvio.iIDPERSONA
                    objGuiaEnvio.iREMITENTE = TxtRasonSocial.Text
                    objGuiaEnvio.iNRODOC_REM = Me.TxtRuc.Text
                    bControl_Busqueda = True
                    ' fnTarifario()
                    If BuscarClientesGuia_Envio() = True Then
                        'txtCliente_Remitente.Focus()
                        'txtCliente_Remitente.SelectAll()
                        txtDestinatario.Focus()
                        txtDestinatario.SelectAll()
                        'SendKeys.Send("{Tab}")
                        fnTarifario()
                    End If

                End If
            Else
                MsgBox("El Cliente no tiene línea de crédito, revise sus datos", MsgBoxStyle.Information, "Seguridad Sistema")
                TxtRuc.Focus()
            End If
        End If
        'If BuscarClientesGuia_Envio() = True Then
        '    txtCliente_Remitente.Focus()
        '    txtCliente_Remitente.SelectAll()
        '    'SendKeys.Send("{Tab}")
        '    fnTarifario()
        'End If
    End Sub

    Private Function BuscarClientesGuia_EnvioCC() As Boolean
        Dim flag As Boolean = False
        Try
            If CONTROL = 4 Then
                CONTROL = 1
            End If

            'If objGuiaEnvio.iCONTROL <> 2 Then
            '    objGuiaEnvio.iCONTROL = CONTROL
            'End If

            objGuiaEnvio.iControl_Busqueda = CONTROL
            If CONTROL <> 2 Then
                objGuiaEnvio.iIDPERSONA = 0
            End If

            TxtGuiaEnvio.Text = RellenoRight(NroDigitos_Guias, TxtGuiaEnvio.Text)

            If txtiWinOrigen.Text <> "" And txtiWinDestino.Text <> "" Then
                objGuiaEnvio.iIDUNIDAD_AGENCIA = Int(coll_iOrigen.Item(iWinOrigen.IndexOf(txtiWinOrigen.Text.ToString()) + 1).ToString())
                objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = Int(coll_iDestino.Item(iWinDestino.IndexOf(txtiWinDestino.Text.ToString()) + 1).ToString())
            Else
                'MsgBox("No ha definido el Destino De envio...", MsgBoxStyle.Information, "Seguridad Sistemas")
                objGuiaEnvio.iIDUNIDAD_AGENCIA = 999
                objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = 999
            End If

            If objGuiaEnvio.iIDUNIDAD_AGENCIA = objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO Then
                'MsgBox("No Existen Tarifas Para Una Ruta Igual..,Verifique sus Datos", MsgBoxStyle.Information, "Seguridad Sistema")
                GoTo SALIR
            End If
            If Me.TxtGuiaEnvio.Text <> "" And TxtGuiaEnvio.Text.Length() > 0 And bControl_Busqueda = False Then
                'objGuiaEnvio.iCONTROL = 1
                objGuiaEnvio.sNRO_GUIA = TxtGuiaEnvio.Text
            Else
                objGuiaEnvio.sNRO_GUIA = "@"
            End If

            'If objGuiaEnvio.fnControlGuiasImpresas(TxtGuiaEnvio.Text) = False Then
            '    txtiWinDestino.Focus()
            '    txtiWinDestino.SelectAll()
            '    GoTo SALIR
            'End If
            'txtiWinOrigen.Text = objGuiaEnvio.iNOMBRE_UNIDAD_ORIGEN
            'txtiWinDestino.Text = objGuiaEnvio.iNOMBRE_UNIDAD_DESTINO
            'TxtRuc.Text = objGuiaEnvio.sNU_DOCU_SUNAT

            'fnCargar_iWin2(Me.TxtRasonSocial, objGuiaEnvio.rst_Lista_Personas, coll_Lista_Personas, iWinPerosa, 0, iWinPerosaRUC)                    
            CONTROL = 2
            Dim indexof As Integer = 0
            If iWinPerosa.Count > 0 Then
                'indexof = IIf(iWinContacto_Remitente.IndexOf(txtRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtRemitente.Text), -1)
                indexof = iWinPerosaRUC.IndexOf(TxtRuc.Text)
                objGuiaEnvio.iIDPERSONA = -1
                If indexof >= 0 Then
                    objGuiaEnvio.iIDPERSONA = Int(coll_Lista_Personas(indexof.ToString))
                    objGuiaEnvio.iCONTROLIdpersona = objGuiaEnvio.iIDPERSONA
                    If indexof <= iWinPerosa.Count Then
                        Me.TxtRasonSocial.Text = iWinPerosa.Item(indexof)
                        objGuiaEnvio.iID_REMITENTE = objGuiaEnvio.iIDPERSONA
                        objGuiaEnvio.iREMITENTE = TxtRasonSocial.Text
                        objGuiaEnvio.iNRODOC_REM = Me.TxtRuc.Text
                        bControl_Busqueda = True
                    End If
                Else
                    MsgBox("El Cliente no tiene línea de crédito, revise sus datos", MsgBoxStyle.Information, "Seguridad Sistema")
                End If
            End If
            'If BuscarClientesGuia_Envio() = True Then
            '    '  SendKeys.Send("{Tab}")
            'End If
            '    ElseIf Me.dtGridViewBultos.Focused = True Then
            'Sin mensages
            'MsgBox("Seguridad TAB")
            '
            objGuiaEnvio.iIDCENTRO_COSTO = Int(objGuiaEnvio.coll_Sub_Cuenta.Item(cmbSubCuenta.SelectedIndex.ToString))
            'Mod. 22/08/2009 -->Omendoza - Pasando al datahelper   
            If objGuiaEnvio.fnCONTROL_GUIAS_ENVIO_DOC_CC() = True Then
                'MsgBox("Datos...", MsgBoxStyle.Information, "Control")
                flag = True
                Me.TxtRuc.Text = objGuiaEnvio.sNU_DOCU_SUNAT.ToString
                Me.TxtRasonSocial.Text = objGuiaEnvio.sRASON_SOCIAL.ToString

                txtCliente_Remitente.Text = TxtRasonSocial.Text
                txtDocCliente_Remitente.Text = TxtRuc.Text

                lbTipoFacturacion.Text = objGuiaEnvio.iIDTipoFacturacion.ToString
                If objGuiaEnvio.iIDTipoFacturacion = 3 Then
                    chechCargo.Checked = True
                Else
                    chechCargo.Checked = False
                End If

                'no cargara porque el foco esta en la sub cuenta
                'Me.txtFechaGuia.Text = objGuiaEnvio.sFECHA_GUIA.ToString
                '' '' '' ''If objGuiaEnvio.cur_Sub_Cuenta.EOF = False And objGuiaEnvio.cur_Sub_Cuenta.BOF = False Then
                '' '' '' ''    ModuUtil.LlenarComboIDs(objGuiaEnvio.cur_Sub_Cuenta, cmbSubCuenta, objGuiaEnvio.coll_Sub_Cuenta, objGuiaEnvio.iIDCENTRO_COSTO)
                '' '' '' ''    cmbSubCuenta.SelectedIndex = 0
                '' '' '' ''End If


                '//CLIENTE_REMITENTE
                objGuiaEnvio.coll_Nombres_CLIENTE_REMITENTE.Clear()
                ' If objGuiaEnvio.cur_CLIENTE_REMITENTE.BOF = False And objGuiaEnvio.cur_CLIENTE_REMITENTE.EOF = False Then
                If objGuiaEnvio.dt_cur_CLIENTE_REMITENTE.Rows.Count > 0 Then
                    objGuiaEnvio.iID_REMITENTE = Int(objGuiaEnvio.dt_cur_CLIENTE_REMITENTE.Rows(0).Item(0).ToString)
                    txtCliente_Remitente.Text = objGuiaEnvio.dt_cur_CLIENTE_REMITENTE.Rows(0).Item(1).ToString
                    txtDocCliente_Remitente.Text = objGuiaEnvio.dt_cur_CLIENTE_REMITENTE.Rows(0).Item(2).ToString
                    'fnCargar_iWin(txtRemitente, objGuiaEnvio.cur_Nombres_Remitente, objGuiaEnvio.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA)
                    fnCargar_iWin2_dt2(txtCliente_Remitente, objGuiaEnvio.dt_cur_CLIENTE_REMITENTE, objGuiaEnvio.coll_Nombres_CLIENTE_REMITENTE, iWinCLIENTE_Remitente, objGuiaEnvio.iID_REMITENTE, iWinCLIENTEDNI_Remite)
                Else
                    objGuiaEnvio.iID_REMITENTE = -1
                    txtCliente_Remitente.Text = ""
                    Me.txtDocCliente_Remitente.Text = ""
                    fnCargar_iWin2_dt2(txtCliente_Remitente, objGuiaEnvio.dt_cur_CLIENTE_REMITENTE, objGuiaEnvio.coll_Nombres_CLIENTE_REMITENTE, iWinCLIENTE_Remitente, objGuiaEnvio.iID_REMITENTE, iWinCLIENTEDNI_Remite)
                End If
                objGuiaEnvio.coll_Nombres_Remitente.Clear()
                '//CONTACTO REMITENTE
                'If objGuiaEnvio.cur_Nombres_Remitente.BOF = False And objGuiaEnvio.cur_Nombres_Remitente.EOF = False Then
                If objGuiaEnvio.dt_cur_Nombres_Remitente.Rows.Count > 0 Then
                    objGuiaEnvio.iIDCONTACTO_PERSONA = Int(objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(0).ToString)
                    txtRemitente.Text = objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(1).ToString
                    txtDNIRemitente.Text = objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(2).ToString
                    'fnCargar_iWin(txtRemitente, objGuiaEnvio.cur_Nombres_Remitente, objGuiaEnvio.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA)
                    fnCargar_iWin2_dt2(txtRemitente, objGuiaEnvio.dt_cur_Nombres_Remitente, objGuiaEnvio.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA, iWinPerosaDNI_Remite)
                Else
                    objGuiaEnvio.iIDCONTACTO_PERSONA = -1
                    txtRemitente.Text = ""
                    Me.txtDNIRemitente.Text = ""
                    fnCargar_iWin2_dt2(txtRemitente, objGuiaEnvio.dt_cur_Nombres_Remitente, objGuiaEnvio.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA, iWinPerosaDNI_Remite)
                End If

                '//CONTACTO DIRECCIONES
                objGuiaEnvio.coll_Direccion_Remitente.Clear()
                'If objGuiaEnvio.cur_Direccion_Remitente.BOF = False And objGuiaEnvio.cur_Direccion_Remitente.EOF = False Then
                If objGuiaEnvio.dt_cur_Direccion_Remitente.Rows.Count > 0 Then
                    objGuiaEnvio.iIDDIRECCION_REMITENTE = Int(objGuiaEnvio.dt_cur_Direccion_Remitente.Rows(0).Item(0).ToString)
                    txtDireccionRemitente.Text = objGuiaEnvio.dt_cur_Direccion_Remitente.Rows(0).Item(1).ToString
                    'fnCargar_iWin(txtDireccionRemitente, objGuiaEnvio.cur_Direccion_Remitente, objGuiaEnvio.coll_Direccion_Remitente, iWinDireccion_Remitente, objGuiaEnvio.iIDDIRECCION_REMITENTE)
                    fnCargar_iWin_dt(txtDireccionRemitente, objGuiaEnvio.dt_cur_Direccion_Remitente, objGuiaEnvio.coll_Direccion_Remitente, iWinDireccion_Remitente, objGuiaEnvio.iIDDIRECCION_REMITENTE)
                Else
                    txtDireccionRemitente.Text = ""
                    objGuiaEnvio.iIDDIRECCION_REMITENTE = -1
                    fnCargar_iWin_dt(txtDireccionRemitente, objGuiaEnvio.dt_cur_Direccion_Remitente, objGuiaEnvio.coll_Direccion_Remitente, iWinDireccion_Remitente, objGuiaEnvio.iIDDIRECCION_REMITENTE)
                End If

                '//CONTACTO TELEFONOS
                'If objGuiaEnvio.cur_Telefono_Remitente.BOF = False And objGuiaEnvio.cur_Telefono_Remitente.EOF = False Then
                '    objGuiaEnvio.iIDTEFONO_REMITENTE = Int(objGuiaEnvio.cur_Telefono_Remitente.Fields.Item(0).Value.ToString)
                '    txtTelefonoRemitente.Text = objGuiaEnvio.cur_Telefono_Remitente.Fields.Item(1).Value.ToString
                '    fnCargar_iWin(txtTelefonoRemitente, objGuiaEnvio.cur_Telefono_Remitente, objGuiaEnvio.coll_Telefono_Remitente, iWinTelefono_Remitente, objGuiaEnvio.iIDTEFONO_REMITENTE)
                'Else
                '    Me.txtTelefonoRemitente.Text = ""
                '    objGuiaEnvio.iIDTEFONO_REMITENTE = -1
                'End If

                Me.txtTelefonoRemitente.Text = ""
                objGuiaEnvio.iIDTEFONO_REMITENTE = -1

                '//DESTINATARIO DESTINATARIO
                If objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows.Count > 0 Then
                    'If objGuiaEnvio.cur_Nombres_Destinatario.BOF = False And objGuiaEnvio.cur_Nombres_Destinatario.EOF = False Then
                    objGuiaEnvio.iIDCONTACTO_DESTINATARIO = Int(objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(0).ToString)
                    txtDestinatario.Text = objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(1).ToString
                    txtDNIDestinatario.Text = objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(2).ToString
                    'fnCargar_iWin(txtDestinatario, objGuiaEnvio.cur_Nombres_Destinatario, objGuiaEnvio.coll_Nombres_Destinatario, iWinContacto_Destinatario, objGuiaEnvio.iIDCONTACTO_DESTINATARIO)
                    fnCargar_iWin2_dt2(txtDestinatario, objGuiaEnvio.dt_cur_Nombres_Destinatario, objGuiaEnvio.coll_Nombres_Destinatario, iWinContacto_Destinatario, objGuiaEnvio.iIDCONTACTO_DESTINATARIO, iWinPerosaDNI_Destino)
                Else
                    objGuiaEnvio.iIDCONTACTO_DESTINATARIO = -1
                    txtDestinatario.Text = ""
                    txtDNIDestinatario.Text = ""
                End If
                '
                'ModuUtil.LlenarComboIDs(objGuiaEnvio.rst_Lista_Tipo_Entrega, cmbTipo_Entrega, objGuiaEnvio.coll_Lista_Tipo_Entrega, 1)
                '1 Agencia
                '2 Domicilio
                '
                Dim idTipoDire As Integer = Int(objGuiaEnvio.coll_Lista_Tipo_Entrega.Item(cmbTipo_Entrega.SelectedIndex.ToString))
                If idTipoDire = 2 Then
                    'If objGuiaEnvio.cur_Direccion_Destinatario.BOF = False And objGuiaEnvio.cur_Direccion_Destinatario.EOF = False Then
                    If objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows.Count > 0 Then
                        objGuiaEnvio.iIDDIRECCION_DESTINATARIO = Int(objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows(0).Item(0).ToString)
                        txtDireccionDestinatario.Text = objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows(0).Item(1).ToString
                        fnCargar_iWin_dt(Me.txtDireccionDestinatario, objGuiaEnvio.dt_cur_Direccion_Destinatario, objGuiaEnvio.coll_Direccion_Destinatario, iWinDireccion_Destinatario, objGuiaEnvio.iIDDIRECCION_DESTINATARIO)
                    Else
                        objGuiaEnvio.iIDDIRECCION_DESTINATARIO = -1
                        txtDireccionDestinatario.Text = ""
                    End If
                End If

                'If objGuiaEnvio.cur_Telefono_Destinatario.BOF = False And objGuiaEnvio.cur_Telefono_Destinatario.EOF = False Then
                '    objGuiaEnvio.iIDTEFONO_CONSIGNADO = Int(objGuiaEnvio.cur_Telefono_Destinatario.Fields.Item(0).Value.ToString)
                '    txtTelefonoDestinatario.Text = objGuiaEnvio.cur_Telefono_Destinatario.Fields.Item(1).Value.ToString
                '    fnCargar_iWin(txtTelefonoDestinatario, objGuiaEnvio.cur_Telefono_Destinatario, objGuiaEnvio.coll_Telefono_Destinatario, iWinTelefono_Destinatario, objGuiaEnvio.iIDTEFONO_CONSIGNADO)
                'Else
                '    objGuiaEnvio.iIDTEFONO_CONSIGNADO = -1
                '    txtTelefonoDestinatario.Text = ""
                'End If

                txtTelefonoDestinatario.Text = ""
                objGuiaEnvio.iIDTEFONO_CONSIGNADO = -1

                Dim i As Integer = 0
                For i = 1 To dtGridViewArticulo.Rows().Count
                    dtGridViewArticulo.Rows().RemoveAt(0)
                Next

                txtSubTotal.Text = "0.00"
                txMontotIGV.Text = "0.00"
                txtTotal_Pago.Text = "0.00"

                For i = 0 To 2
                    dtGridViewBultos(2, i).Value() = ""
                    dtGridViewBultos(3, i).Value() = ""
                    'dtGridViewBultos(4, i).Value() = "0.00"
                    dtGridViewBultos(5, i).Value() = "0.00"
                Next

                'If objGuiaEnvio.rst_Articulos.State = 1 Then
                '    While objGuiaEnvio.rst_Articulos.BOF = False And objGuiaEnvio.rst_Articulos.EOF = False
                '        Dim row0 As String() = {Int(objGuiaEnvio.rst_Articulos.Fields.Item(0).Value).ToString, _
                '        objGuiaEnvio.rst_Articulos.Fields.Item(1).Value, _
                '        objGuiaEnvio.rst_Articulos.Fields.Item(2).Value.ToString, _
                '        "", _
                '        "", _
                '        "", _
                '        "0.00"}
                '        dtGridViewArticulo.Rows().Add(row0)
                '        objGuiaEnvio.rst_Articulos.MoveNext()
                '    End While
                'End If

                'If objGuiaEnvio.rst_Articulos.State = 1 Then
                If objGuiaEnvio.dt_rst_Articulos.Rows.Count > 0 Then
                    For Each fila As DataRow In objGuiaEnvio.dt_rst_Articulos.Rows
                        'While objGuiaEnvio.rst_Articulos.BOF = False And objGuiaEnvio.rst_Articulos.EOF = False
                        Dim row0 As String() = {Int(fila.Item(0)).ToString, _
                        fila.Item(1), _
                        fila.Item(2).ToString, _
                        "", _
                        "", _
                        "", _
                        "0.00"}
                        dtGridViewArticulo.Rows().Add(row0)
                        'objGuiaEnvio.rst_Articulos.MoveNext()
                        'End While
                    Next
                End If

            Else
                Call ClearData()
                ' MsgBox("GUIA NO ASIGNADAS A NINGUN CLIENTE... ", MsgBoxStyle.Information, "Seguridad Sistema")
                flag = False
            End If
            ' objGuiaEnvio.iCONTROL = 1
SALIR:
        Catch ex As Exception
            MsgBox("Error Interno...Verificar Datos", MsgBoxStyle.Information, "Seguridad Sistema")
            flag = False
            'objGuiaEnvio.iCONTROL = 1
        End Try
        Return flag
    End Function
    Sub limpia_monto_x_cambio()
        Try
            If lb_no_lee = True Then
                Dim li_fila As Integer
                '
                ' Cuando cambia de valor siempre será el mismo 
                '
                If fArticulo = True Then
                    Me.dtGridViewArticulo.Visible = True
                    dtGridViewBultos.Visible = False
                Else
                    dtGridViewBultos.Visible = True
                    dtGridViewArticulo.Visible = False
                End If

                ' Limpia Total 
                Me.txtTotalSobre.Text = ""
                Me.txtCantidadSobres.Text = ""
                ' Limpiando los montos 
                '
                txtSubTotal.Text = "0.00"
                txMontotIGV.Text = "0.00"
                txtTotal_Pago.Text = "0.00"
                '

                'Limpia los datos de la grilla 
                For li_fila = 0 To dtGridViewBultos.RowCount - 1
                    dtGridViewBultos(2, li_fila).Value() = ""     ' Bultos 
                    dtGridViewBultos(3, li_fila).Value() = ""     ' Peso 
                    dtGridViewBultos(5, li_fila).Value() = "0.00"
                Next
                '
                Me.txt_base.Text = ""
                '            
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Function fb_buscar_cliente() As Boolean
        Dim lb_retorna As Boolean
        'Try - 03/09/2009 - 
        lb_retorna = False
        If BuscarClientesGuia_Envio() = True Then
            lb_retorna = True
            fnTarifario()
        End If
        Return lb_retorna
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        'End Try
    End Function
    '13/08/2008 - Recupera tarifa 
    Sub recupera_tarifa()
        Dim ll_idunidad_origen As Long
        Dim ll_idunidad_destino As Long
        Dim ll_fila As Long = 0

        Try
            If lb_no_lee = True Then
                'Origen 
                ll_idunidad_origen = Int(coll_iOrigen.Item(iWinOrigen.IndexOf(txtiWinOrigen.Text.ToString()) + 1).ToString())
                If ll_idunidad_origen < 0 Then
                    Exit Sub
                End If
                'Destino 
                If txtiWinDestino.Text.ToString() = "" Then
                    Exit Sub
                End If
                ll_idunidad_destino = Int(coll_iDestino.Item(iWinDestino.IndexOf(txtiWinDestino.Text.ToString()) + 1).ToString())
                If ll_idunidad_destino < 0 Then
                    Exit Sub
                End If
                '
                If ll_idunidad_origen = ll_idunidad_destino Then
                    MsgBox("La ciudad origen y destino son iguales", MsgBoxStyle.Information, "Sistema de Seguridad")
                    txtiWinDestino.Text = ""
                    txtiWinDestino.Focus()
                    Exit Sub
                End If
                'Ver los datos 
                If Me.TxtRasonSocial.Text = "" Then
                    Exit Sub
                End If
                '
                'If Me.TxtRasonSocial.Text = iWinPerosa.Item(ll_fila) Then
                'End If
                'Recuperando el nuevo tarifario 
                fnTarifario()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Function fw_valida_bultos_y_peso() As Boolean
        Dim ll_nro_bultos As Long
        Dim ldb_peso As Double
        Dim lb_valida As Boolean
        Dim lb_bultos, lb_peso As Boolean
        Try
            lb_valida = True
            If Me.dtGridViewBultos.Visible = True Then
                'Peso
                If IsDBNull(Me.dtGridViewBultos.Rows(0).Cells(2)) = True Or CType(LTrim(Me.dtGridViewBultos.Rows(0).Cells(2).Value), String) = "" Then
                    ll_nro_bultos = 0
                Else
                    ll_nro_bultos = CType(Me.dtGridViewBultos.Rows(0).Cells(2).Value, Long)
                End If
                '
                If IsDBNull(Me.dtGridViewBultos.Rows(0).Cells(3)) = True Or CType(LTrim(Me.dtGridViewBultos.Rows(0).Cells(3).Value), String) = "" Then
                    ldb_peso = 0
                Else
                    ldb_peso = CType(Me.dtGridViewBultos.Rows(0).Cells(3).Value, Double)
                End If
                '
                If ll_nro_bultos > 0 Then
                    lb_bultos = True
                Else
                    lb_bultos = False
                End If
                '
                If ldb_peso > 0 Then
                    lb_peso = True
                Else
                    lb_peso = False
                End If
                If (lb_bultos = True And lb_peso = False) Or (lb_bultos = False And lb_peso = True) Then
                    If lb_bultos = False Then
                        MsgBox("Falta ingresar el número de bultos x peso", MsgBoxStyle.Exclamation, "Sistema de Seguridad")
                        Me.dtGridViewBultos.CurrentCell = Me.dtGridViewBultos.Rows(0).Cells(2)
                        Return False
                    End If
                    If lb_peso Then
                        MsgBox("Falta ingresar el peso de los bultos", MsgBoxStyle.Exclamation, "Sistema de Seguridad")
                        Me.dtGridViewBultos.CurrentCell = Me.dtGridViewBultos.Rows(0).Cells(3)
                        Return False
                    End If
                End If
                'Volumen
                If IsDBNull(Me.dtGridViewBultos.Rows(1).Cells(2)) = True Or CType(LTrim(Me.dtGridViewBultos.Rows(1).Cells(2).Value), String) = "" Then
                    ll_nro_bultos = 0
                Else
                    ll_nro_bultos = CType(Me.dtGridViewBultos.Rows(1).Cells(2).Value, Long)
                End If
                If IsDBNull(Me.dtGridViewBultos.Rows(1).Cells(3)) = True Or CType(LTrim(Me.dtGridViewBultos.Rows(1).Cells(3).Value), String) = "" Then
                    ldb_peso = 0
                Else
                    ldb_peso = CType(Me.dtGridViewBultos.Rows(1).Cells(3).Value, Double)
                End If

                If ll_nro_bultos > 0 Then
                    lb_bultos = True
                Else
                    lb_bultos = False
                End If
                '
                If ldb_peso > 0 Then
                    lb_peso = True
                Else
                    lb_peso = False
                End If

                If (lb_bultos = True And lb_peso = False) Or (lb_bultos = False And lb_peso = True) Then
                    If lb_bultos = False Then
                        MsgBox("Falta ingresar el número de bultos x volumén", MsgBoxStyle.Exclamation, "Sistema de Seguridad")
                        Me.dtGridViewBultos.CurrentCell = Me.dtGridViewBultos.Rows(1).Cells(2)
                        Return False
                    End If
                    If lb_peso Then
                        MsgBox("Falta ingresar el peso de los bultos", MsgBoxStyle.Exclamation, "Sistema de Seguridad")
                        Me.dtGridViewBultos.CurrentCell = Me.dtGridViewBultos.Rows(1).Cells(3)
                        Return False
                    End If
                End If
                '
            End If
            Return lb_valida
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de seguridad")
        End Try
    End Function
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        'Try
        '    ObjRptGuiaEnvio.p_Hora_Guia = fnGetHora()
        '    ' 20/08/2008 - Recupera los datos a partir del Nº de Guía  


        '
        '    Dim objImpresora As New dtoVentaCargaContado
        '    'Dim flag = objImpresora.fnSP_Buscar_Impresora(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE)
        '    '19/08/2008 - Solo se trabaja con el tipo de comprobante de GE - omendoza            
        '    '
        '    Dim flag = objImpresora.fnSP_Buscar_Impresora(3, dtoUSUARIOS.IP)
        '    If flag Then
        '        Dim objImprimir As New ImprimirTexto("Draft Condensed", 7, objImpresora.v_Impresora, "guia", 1305, 1305)

        '        'Envío de impresión texto Guía de Envío (Nuevo)
        '        'Dim objImprimir As New ImprimirTexto("Arial", 8, "PDFCreator", "tres", 1305, 1305)
        '        objImprimir.Agregar(210, 25, ObjRptGuiaEnvio.p_NroGUIA)
        '        objImprimir.Agregar(485, 15, ObjRptGuiaEnvio.p_codigo_iata_ori)
        '        objImprimir.Agregar(545, 15, ObjRptGuiaEnvio.p_codigo_iata_desti)
        '        objImprimir.Agregar(0, 55, ObjRptGuiaEnvio.p_ruc)
        '        objImprimir.Agregar(25, 105, ObjRptGuiaEnvio.P_REMITENTE)
        '        objImprimir.Agregar(25, 120, ObjRptGuiaEnvio.P_DIRECCION_REMI)

        '        objImprimir.Agregar(355, 105, ObjRptGuiaEnvio.P_NOMBRES_DESTI)
        '        objImprimir.Agregar(355, 120, ObjRptGuiaEnvio.P_DIRECCION_DESTI)

        '        objImprimir.Agregar(190, 55, p_domicilio)
        '        objImprimir.Agregar(245, 55, p_agencia)
        '        objImprimir.Agregar(310, 55, p_contado)
        '        objImprimir.Agregar(370, 55, p_destino)
        '        objImprimir.Agregar(435, 55, p_credito)
        '        objImprimir.Agregar(570, 55, ObjRptGuiaEnvio.P_CARGO)

        '        objImprimir.Agregar(25, 175, ObjRptGuiaEnvio.p_contacto)

        '        objImprimir.Agregar(162, 155, ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI)
        '        objImprimir.Agregar(370, 155, ObjRptGuiaEnvio.P_PROVINCIA)
        '        objImprimir.Agregar(525, 155, ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI)

        '        objImprimir.Agregar(20, 210, Mid(strNroGuias_Remision, 1, 80))
        '        objImprimir.Agregar(155, 300, Format(CDate(ObjRptGuiaEnvio.P_FECHA_GUIA), "dd     MM      yy"))

        '        objImprimir.Agregar(280, 235, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_BULTOS), 2))
        '        objImprimir.Agregar(330, 235, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_PESO), 2))
        '        objImprimir.Agregar(380, 235, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_VOLUMEN), 2))

        '        objImprimir.Agregar(450, 240, dtoUSUARIOS.m_sFecha)
        '        objImprimir.Agregar(535, 240, ObjRptGuiaEnvio.p_Hora_Guia)

        '        objImprimir.Agregar(300, 252, "Nº SOBRES " & ObjRptGuiaEnvio.P_TOTAL_SOBRES)

        '        objImprimir.Imprimir()
        '        objImprimir = Nothing
        '    Else
        '        MessageBox.Show("El Documento no tiene asociado una impresora.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        'End Try
    End Sub

    Private Sub dtGridViewBultos_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtGridViewBultos.CellFormatting
        Try


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub dtGridViewBultos_EditModeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtGridViewBultos.EditModeChanged
        Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try

    End Sub
    Private Sub dtGridViewBultos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtGridViewBultos.KeyPress
        Try


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub dtGridViewBultos_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtGridViewBultos.CellValidated
        Dim ll_bulto As Long
        Dim ld_peso As Double
        Try
            lb_no_paso = False
            If e.RowIndex = 0 And e.ColumnIndex = 2 Then ' Bultos en Peso
                Try
                    If LTrim(Me.dtGridViewBultos.Rows(0).Cells(2).Value) <> "" Then
                        ll_bulto = CType(Me.dtGridViewBultos.Rows(0).Cells(2).Value, Long)
                    End If
                Catch ex As Exception
                    dtGridViewBultos.Rows(0).Cells(2).Value = ""
                    dtGridViewBultos.CurrentCell = dtGridViewBultos.Rows(0).Cells(2)
                    lb_no_paso = True
                    Exit Sub
                End Try
            End If
            '
            If e.RowIndex = 0 And e.ColumnIndex = 3 Then ' Total en Peso
                Try
                    If LTrim(Me.dtGridViewBultos.Rows(0).Cells(3).Value) <> "" Then
                        ld_peso = CType(Me.dtGridViewBultos.Rows(0).Cells(3).Value, Double)
                    End If
                Catch ex As Exception
                    dtGridViewBultos.Rows(0).Cells(3).Value = ""
                    dtGridViewBultos.CurrentCell = dtGridViewBultos.Rows(0).Cells(3)
                    lb_no_paso = True
                    Exit Sub
                End Try
            End If
            '
            If e.RowIndex = 1 And e.ColumnIndex = 2 Then ' Bulto en volumen 
                Try
                    If LTrim(Me.dtGridViewBultos.Rows(1).Cells(2).Value) <> "" Then
                        ll_bulto = CType(Me.dtGridViewBultos.Rows(1).Cells(2).Value, Long)
                    End If
                Catch ex As Exception
                    dtGridViewBultos.Rows(1).Cells(2).Value = ""
                    dtGridViewBultos.CurrentCell = dtGridViewBultos.Rows(1).Cells(2)
                    lb_no_paso = True
                    Exit Sub
                End Try
            End If
            '
            If e.RowIndex = 1 And e.ColumnIndex = 3 Then ' Peso x Volumen 
                Try
                    If LTrim(Me.dtGridViewBultos.Rows(1).Cells(3).Value) <> "" Then
                        ll_bulto = CType(Me.dtGridViewBultos.Rows(1).Cells(3).Value, Double)
                    End If
                Catch ex As Exception
                    dtGridViewBultos.Rows(1).Cells(3).Value = ""
                    dtGridViewBultos.CurrentCell = dtGridViewBultos.Rows(1).Cells(3)
                    lb_no_paso = True
                    Exit Sub
                End Try
            End If
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Sub formatea_grilla_nuevo()
        Dim DigitosSerie_formato As String
        Try
            '
            DigitosSerie_formato = "A"
            Dim i As Integer
            For i = 1 To li_iDigitosSerie - 1
                DigitosSerie_formato = DigitosSerie_formato & "A"
            Next
            DigitosSerie_formato = DigitosSerie_formato & "-AAAAAAAAAA"  ' Por defecto 
            '            
            DataGridViewDocumentos.Columns.Clear()
            With DataGridViewDocumentos
                .AllowUserToAddRows = True
                .AllowUserToDeleteRows = True
                .AllowUserToOrderColumns = True
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = False
                .AutoGenerateColumns = False
                '.DataSource = dtable_Lista_Control_Comprobante
                .VirtualMode = False
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            Dim col_1 As New DataGridViewTextBoxColumn
            With col_1
                .DisplayIndex = 0
                .DataPropertyName = "id1"
                .HeaderText = "ID1"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            DataGridViewDocumentos.Columns.Add(col_1)
            Dim col_0 As New DataGridViewTextBoxColumn
            With col_0
                .DisplayIndex = 1
                .DataPropertyName = "id2"
                .HeaderText = "ID2"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            DataGridViewDocumentos.Columns.Add(col_0)
            'Dim col1 As New DataGridViewTextBoxColumn
            Dim col_2 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            With col_2
                .DisplayIndex = 2
                .DataPropertyName = "NRODOCUMENTO1"
                .HeaderText = "NRO DOCUMENTOS"
                .DefaultCellStyle.ForeColor = Color.Black
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.Mask = "###-########"
                ' .Mask = "AAA-AAAAAAAAAA"
                .Mask = DigitosSerie_formato
                .DefaultCellStyle.NullValue = "-"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = False
            End With
            DataGridViewDocumentos.Columns.Add(col_2)
            Dim col_3 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            'Dim col2 As New DataGridViewTextBoxColumn
            With col_3
                .DisplayIndex = 3
                .DataPropertyName = "NRODOCUMENTO2"
                .HeaderText = "NRO DOCUMENTOS"
                .DefaultCellStyle.ForeColor = Color.Black
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.Mask = "###-########"
                '.Mask = "AAAA-AAAAAAAAAA"  '18/07/2009 
                '.Mask = "AAA-AAAAAAAAAA"    '18/07/2009  Por defecto va ocupar 3 dígitos  
                '
                .Mask = DigitosSerie_formato
                '
                .DefaultCellStyle.NullValue = "-"
                .ReadOnly = False
            End With
            DataGridViewDocumentos.Columns.Add(col_3)
            Dim row11 As String() = {"", "", "-", "-"}
            DataGridViewDocumentos.Rows().Add(row11)
            DataGridViewDocumentos.Rows().Add(row11)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Sub Grabar()
        If fnDigito_Chequeo(Me.TxtGuiaEnvio.Text.ToString) = False Then
            MsgBox("EL Nº DE GUIA ESTA MAL ESCRITO, REVISE SU Nº Ó CREE UNA NUEVA GUIA DE ENVIO...", MsgBoxStyle.Information, "Seguridad Sistema")
            TxtGuiaEnvio.Focus()
            TxtGuiaEnvio.SelectAll()
            Return
        End If
        If fnControlFecha_GuiaEnvio(Me.txtFechaGuia.Text.ToString) = True Then

            iFlagControl = False
            If fnCONTROLDATOS = True Then
                'MsgBox("Grabado Correctamente ", MsgBoxStyle.Information, "Seguridad Sistema")
                If objGuiaEnvio.iCONTROL = 1 Then
                    strNroGuias_Remision = ""
                    'Try - 04/09/2009  - Desactiva por el datahelper 
                    'Mod. 24/08/2009 -->Omendoza - Pasando al datahelper 
                    v_Origen = objGuiaEnvio.fnIATA(objGuiaEnvio.iIDUNIDAD_AGENCIA)
                    v_destino = objGuiaEnvio.fnIATA(objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO)
                    'Catch ex As Exception
                    'MsgBox("Verifique sus datos de IATA en la guía de envío", MsgBoxStyle.Information, "Seguridad Sistema")
                    'End Try

                    Dim flagGuia As Boolean = False
                    If Int(CORRELATIVO) = Int(TxtGuiaEnvio.Text) Then
                        flagGuia = True
                    End If
                    ObjRptGuiaEnvio.P_PROVINCIA = txtiWinDestino.Text
                    ObjRptGuiaEnvio.P_CARGO = IIf(objGuiaEnvio.iIDTipoFacturacion = 3, "X", " ")
                    If Grabar_GuiaEnvio() = True Then
                        If flagGuia = True Then
                            ObjVentaCargaContado.fnIncrementarNroDoc(3)
                        End If
                        If MsgBox("Desea imprimir esta Guia ...", MsgBoxStyle.YesNo, "Seguridad Sistema") = MsgBoxResult.Yes Then

                            v_iDestino = "       "
                            v_iCredito = "       "
                            v_iDomicilio = "      "
                            v_iAgencia = "      "

                            If objGuiaEnvio.iIDTIPO_ENTREGA_CARGA = 1 Then
                                p_domicilio = ""
                                p_agencia = "X"
                            Else
                                p_domicilio = "X"
                                p_agencia = ""
                            End If
                            ObjRptGuiaEnvio.p_forma_pago = v_iDestino & v_iCredito

                            If objGuiaEnvio.iIDFORMA_PAGO = 1 Then
                                p_contado = "X"
                                p_destino = ""
                                p_credito = ""
                            ElseIf objGuiaEnvio.iIDFORMA_PAGO = 2 Then
                                p_contado = ""
                                p_destino = ""
                                p_credito = "X"
                            Else
                                p_contado = ""
                                p_destino = "X"
                                p_credito = ""
                            End If

                            ObjRptGuiaEnvio.p_NroGUIA = TxtGuiaEnvio.Text
                            ObjRptGuiaEnvio.p_tipo_entrega = v_iDomicilio & v_iAgencia
                            ObjRptGuiaEnvio.p_ruc = Me.TxtRuc.Text & "-" & Me.TxtRasonSocial.Text
                            ' ObjRptGuiaEnvio.p_tipo_entrega = ObjRptGuiaEnvio.p_tipo_entrega
                            'ObjRptGuiaEnvio.p_forma_pago = ObjRptGuiaEnvio.p_forma_pago
                            ObjRptGuiaEnvio.p_contacto = IIf(txtRemitente.Text <> "", txtRemitente.Text, "")
                            ObjRptGuiaEnvio.p_codigo_iata_ori = v_Origen
                            ObjRptGuiaEnvio.p_codigo_iata_desti = v_destino
                            ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI = Me.txtTelefonoRemitente.Text
                            ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI = Me.txtTelefonoDestinatario.Text
                            ObjRptGuiaEnvio.P_REMITENTE = Me.txtCliente_Remitente.Text
                            ObjRptGuiaEnvio.P_DIRECCION_REMI = Me.txtDireccionRemitente.Text
                            ObjRptGuiaEnvio.P_DIRECCION_DESTI = Me.txtDireccionDestinatario.Text
                            ObjRptGuiaEnvio.P_NOMBRES_DESTI = Me.txtDestinatario.Text
                            ObjRptGuiaEnvio.P_FECHA_GUIA = Me.txtFechaGuia.Text
                            ObjRptGuiaEnvio.P_TOTAL_BULTOS = objGuiaEnvio.iCANTIDAD + objGuiaEnvio.iCANTIDAD_X_UNIDAD_VOLUMEN + objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI
                            ObjRptGuiaEnvio.P_TOTAL_VOLUMEN = objGuiaEnvio.dTOTAL_VOLUMEN.ToString


                            'AGREGAR PESO DESDE ARTICULOS
                            'If Me.dtGridViewArticulo.Visible = True Then
                            '    ObjRptGuiaEnvio.P_TOTAL_PESO = fn_peso_desde_articulos()
                            'Else
                            '    ObjRptGuiaEnvio.P_TOTAL_PESO = objGuiaEnvio.dTOTAL_PESO.ToString
                            'End If


                            ObjRptGuiaEnvio.P_TOTAL_PESO = objGuiaEnvio.dTOTAL_PESO.ToString


                            ObjRptGuiaEnvio.P_TOTAL_SOBRES = IIf(objGuiaEnvio.iCANTIDAD_SOBRES.ToString <> "", objGuiaEnvio.iCANTIDAD_SOBRES.ToString, " ")


                            ObjCODIGOBARRA.Cantidad = ObjRptGuiaEnvio.P_TOTAL_BULTOS
                            ObjCODIGOBARRA.NroDOC = ObjRptGuiaEnvio.p_NroGUIA
                            ObjCODIGOBARRA.clinte = TxtRasonSocial.Text
                            ObjCODIGOBARRA.Origen = v_Origen
                            ObjCODIGOBARRA.Destino = v_destino
                            ObjCODIGOBARRA.AGEDOM = Mid(cmbTipo_Entrega.Text, 1, 3)

                            fnInprecion_Guia_Envio()

                            'ObjReportrutaRpt = PathFrmReport
                            'ObjReportconectar(RptService, RptUser, RptPass)
                            'ObjReportprintrpt(True, "", "GUI006.RPT", "P_IDGUIAS_ENVIO;" & objGuiaEnvio.iIDGUIAS_ENVIO)

                        End If
                        ObjCODIGOBARRA.Cantidad = objGuiaEnvio.iCANTIDAD + objGuiaEnvio.iCANTIDAD_X_UNIDAD_VOLUMEN + objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI + objGuiaEnvio.iCANTIDAD_SOBRES
                        ObjCODIGOBARRA.NroDOC = TxtGuiaEnvio.Text
                        ObjCODIGOBARRA.clinte = TxtRasonSocial.Text
                        ObjCODIGOBARRA.Origen = v_Origen
                        ObjCODIGOBARRA.Destino = v_destino
                        ObjCODIGOBARRA.AGEDOM = Mid(cmbTipo_Entrega.Text, 1, 3)
                        If MsgBox("Esta Seguro de Imprimir Etiquetas...", MsgBoxStyle.YesNoCancel, "Seguridad") = MsgBoxResult.Yes Then
                            If xIMPRESORA = 1 Then
                                fnImprimirEtiquetasGUIA()
                            Else
                                If xIMPRESORA = 2 Then
                                    fnImprimirEtiquetasGUIA_II()
                                Else
                                    fnImprimirEtiquetasGUIA_III()
                                End If
                                'fnImprimirEtiquetasGUIA_II()  Estaba anterior 
                            End If
                        End If
                        strNroGuias_Remision = ""
                        Me.fnNUEVO()
                        'Limpiar_Todo()
                        objGuiaEnvio.iCONTROL = 1

                    End If
                Else ' 
                    If MsgBox("Esta realizando una edición...,¿Está seguro de continuar?", MsgBoxStyle.YesNoCancel, "Seguridad Sistema") = MsgBoxResult.Yes Then
                        If objGuiaEnvio.iCONTROL = 2 Then
                            EDITAR_GuiaEnvio()
                            objGuiaEnvio.iCONTROL = 2
                            If Grabar_GuiaEnvio() = True Then
                                'If EDITAR_GuiaEnvio() = True Then
                                'End If
                                Me.fnNUEVO()
                                'Limpiar_Todo()
                                objGuiaEnvio.iCONTROL = 1
                            End If
                        Else
                            MsgBox("Revices sus datos ..., No puede realizar esta operacion..., No es Ni editar ni Grabar, salga del sistema", MsgBoxStyle.Information, " Seguridad Sistema")
                        End If
                    End If

                End If
                fnCONTROLDATOS = True
            End If
            '  objGuiaEnvio.iCONTROL = 1
        Else
            MsgBox("No puede Ingresar Fecha Guia Mayor a Hoy ni menor a 01/01/1996, Operacion cancelada", MsgBoxStyle.Information, "Seguridad Sistema")
            Me.txtFechaGuia.Text = dtoUSUARIOS.m_sFecha
            Me.txtFechaGuia.SelectAll()
            Return
        End If
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Me.Grabar()
    End Sub

    Private Sub btnArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArticulo.Click
        fnControl_Articulos()
    End Sub

    Private Sub txtNroDocumento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNroDocumento.TextChanged

    End Sub
End Class
