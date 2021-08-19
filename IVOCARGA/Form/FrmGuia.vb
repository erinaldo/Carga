﻿Imports System.Data.Odbc
Imports AccesoDatos
Imports INTEGRACION_LN
Imports System.Data.OracleClient
Imports INTEGRACION_EN

Enum FormatoGrid
    BULTO = 1
    ARTICULOS = 2
    VOLUMETRICO = 3
End Enum
Public Class FrmGuia
    Private objTarifarioPerso_LN As Cls_TarifaPublica_EN

    Public iwinNro_digito_serie_cliente As New AutoCompleteStringCollection
    Public iWinPersonaRUC As New AutoCompleteStringCollection
    Public iWinPersona As New AutoCompleteStringCollection
    Public coll_Lista_Personas As New Collection
    '----------------------------------------------------------------------
    Dim utilData As New UtilData_LN
    Dim objCargaAsegurada As New ClsLbTepsa.dtoCargaAsegurada
    Public iWinDestino As New AutoCompleteStringCollection
    Dim objMantenimientoCheckpoint As New dtoMantenimientoCheckpoint

    Dim coll_iDestino As New Collection
    Dim bTarifarioGeneral As Boolean
    Dim bIngreso As Boolean = False
    Dim bOtrasAgencias As Boolean
    Dim iTipoDoc As Integer
    Dim xIMPRESORA As Integer
    Dim TipoGrid_ As Integer
    Dim bContado As Boolean

    Property hnd As Long

    Dim IGV As Double
    Dim dFactor As Double
    Dim MontoMinimoPyme As Double
    Dim iDespliegue As Byte = 0

    Dim bClienteNuevo As Boolean = True
    Dim bConsignadoNuevo As Boolean = True
    Dim dtCliente, dtConsignado, dtContacto, dtRemitente, dtDireccion, dtDireccion2, DtArticulos, DtSubcuenta As DataTable
    Dim dtContactoParalelo,dtRemitenteParalelo As DataTable
    Dim bControl_Busqueda As Boolean = False
    Dim li_iDigitosSerie As Integer = 3
    Dim bInicioCargaAcompañada As Boolean = False
    '18/11/2011
    Dim iBaseArticulo As Integer = 1

    Dim iDireccion_Catenada As String

    Dim dsPreGuia As DataSet
    Dim blnAgencia As Boolean = False

    'Variables para determinar las filas que se muestran en la grilla del detalle de venta cuando la guia es de retorno
    Dim blnPeso As Boolean = False
    Dim blnVolumen As Boolean = False
    Dim blnSobre As Boolean = False
    Dim blnBase As Boolean = False

    '-->Constantes que guardan relación con la BD
    Dim ID_PRODUCTO_CARGA_EXPRESA As Integer = 5
    Dim ID_PRDUCTO_CARGA_ACOMPANADA As Integer = 6
    Dim ID_PRODUCTO_PYME As Integer = 7
    Dim ID_PRODUCTO_TEPSA_COURIER As Integer = 8

    Dim ID_PRODUCTO_TEPSA_BOX As Integer = 81
    Dim ID_PRODUCTO_TEPSA_BOX_10 As Integer = 82

    Dim ID_TIPO_PCE As Integer = 1
    Dim ID_TIPO_CREDITO As Integer = 2
    Dim ID_PERSONA_QUIMICA_SUIZA As Integer = 1290
    Dim ID_PERSONA_ECKERD As Integer = 1266
    Dim ID_PERSONA_SANROQUE As Integer = 2059
    Dim ID_PERSONA_DATAIMAGENES As Integer = 588692
    Dim ID_PERSONA_OLVA As Integer = 853
    Dim ID_PERSONA_PESQUERA As Integer = 1268
    Dim ID_PERSONA_CBC As Integer = 2153948
    Dim ID_PERSONA_SODIMAC As Integer = 167315

    Dim flagControl As Boolean = False

    '18-11-2013 hlamas tarifa entrega a domicilio
    Dim dtTarifaServicio As DataTable
    Dim dblMontoEntregaDomicilio As Double = 0

    'hlamas 17-02-2015
    Dim dblMontoDC As Double = 0

    'hlamas 26-08-2015
    Dim blnCargo As Boolean, strObservacionCargo As String

    Dim toolTip As New ToolTip()

    'hlamas 21-01-2016
    Dim dtTarifaArticuloPublico As DataTable

    'hlamas 24-09-2018
    Dim Monto_25 As Double = 0
    Dim Monto_40 As Double = 0

    'hlamas 20-06-2019
    Dim intMinimoArticulo As Double

    'hlamas 10-03-2020
    Dim ListaCodigo As New List(Of dtoCodigo)

    Private Sub FrmGuiaEnviaR_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        TxtCiudadDestino.Focus()
    End Sub
    Private Sub FrmGuiaEnviaR_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        dtoUSUARIOS.m_iIdAgencia = dtoUSUARIOS.iIDAGENCIAS
        recuperando_datos_contado = False
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        GrdDocumentosCliente.ClearSelection()
        GrdDetalleVenta.ClearSelection()
    End Sub

    Private Sub FrmGuiaEnviaR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FrmGuia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            recuperando_datos_contado = False
            ToolTip.SetToolTip(Me.btnAutorizar, "Autorizar Descuento")

            ReDim objComprobanteAsegurada(19)
            sBoleto = ""
            Me.CboDireccion.SelectedIndex = 0
            Me.CboContacto.SelectedIndex = 0
            Me.CboRemitente.SelectedIndex = 0
            Me.ConvertirTipoEntrega(0)

            Me.DiseñaGrdDocumentos()
            TipoGrid_ = FormatoGrid.BULTO '---> Grid Bultos
            Me.DiseñaGrdDetalleVenta() '------> Diseña GridDetalleVenta
            FormatoGrdDetalleVenta() '--------> Formato al grid

            '===Agregado x NConsignado====
            Me.DiseñaGrdNConsignado()
            '=============================

            bTarifarioGeneral = False
            bContado = False

            ObjVentaCargaContado = Nothing
            ObjVentaCargaContado = New dtoVentaCargaContado

            Me.Text = "Guía de Envío " & dtoUSUARIOS.iLOGIN & " Ag. Nro " & dtoUSUARIOS.m_iIdAgencia & _
            "[" & dtoUSUARIOS.m_iNombreAgencia & "] [" & dtoUSUARIOS.m_iNombreUnidadAgencia & "]"

            Me.txtFechaGuia.Text = dtoUSUARIOS.m_sFecha '------------> Fecha
            Me.LblCiudad.Text = dtoUSUARIOS.m_iNombreUnidadAgencia '-> Unidad Agencia
            Me.LblAgencia.Text = dtoUSUARIOS.m_iNombreAgencia '------> Nombre Agencia

            'hlamas 01-09-2013
            CargarSubcuentaOrigen(0, dtoUSUARIOS.m_iIdAgencia)

            'hlamas 22-03-2016
            'Me.objGuiaEnvio.iCARGO = Int(ChkCargo.Checked)
            Me.objGuiaEnvio.iCARGO = Int(rbtCargoSi.Checked)

            Me.objGuiaEnvio.iCONTROL = 1

            Dim iOpcion As Integer = 0
            If Acceso.SiRol(G_Rol, Me, 1, 1) Then
                iOpcion = 0
            ElseIf Acceso.SiRol(G_Rol, Me, 1, 2) Then
                iOpcion = 1
            ElseIf Acceso.SiRol(G_Rol, Me, 1, 3) Then
                iOpcion = 2
            ElseIf Acceso.SiRol(G_Rol, Me, 1, 4) Then
                iOpcion = 3
            End If

            Me.ListarProducto(iOpcion)

            'Dim index As Integer
            'index = CboProducto.FindString("CARGA EXPRESSA")
            'CboProducto.SelectedIndex = index

            Me.IGV = dtoUSUARIOS.iIGV / 100
            '---Cargar datos--
            Me.Inicio()
            '-----------------


            '-->Carga tipo de tarifa
            utilData.cargarCombos("t_tipotarifa", CboTipoTarifa, False)

            'Dim index As Integer
            'objTarifarioPerso_LN = New Cls_TarifaPublica_LN 'refereanciamos la clase a mostrar
            'objTarifarioPerso_LN.F_CargarOrigen_LN(CboTipoTarifa, "t_tipotarifa")
            ''index = CboTipoTarifa.FindString("ESTANDAR")
            ''CboTipoTarifa.SelectedIndex = index
            'CboTipoTarifa.SelectedIndex = 0
            ' Fin

            Me.CondicionMontoMinimoPCE()

            'If Me.CboTipo.SelectedValue = 2 Then
            'If ObjVentaCargaContado.fnNroDocuemnto(3, CboProducto.SelectedValue) = True Then
            '    txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
            '    CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc)
            '    ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroNroGuia.Text.Trim
            'ElseIf ObjVentaCargaContado.fnNroDocuemnto(3, 0) = True Then
            '    txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
            '    CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc)
            '    ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroNroGuia.Text
            'ElseIf Me.CboTipo.SelectedValue = 2 Then
            '    MessageBox.Show("Configure Número de Guía de Envío.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.BtnGraba.Enabled = False
            'End If
            'End If

            RemoveHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
            CboTipoTarifa.SelectedIndex = 1

            AddHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged

            bIngreso = False
            Dim dt2 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt2, Me, ContextMenuStrip)
            bIngreso = True

            CboProducto.SelectedValue = 0
            If iOpcion <> 3 Then
                CboTipo.SelectedValue = 2
            Else
                CboTipo.SelectedValue = 1
            End If

            CboTipoTarifa.SelectedIndex = 1

            'Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            'Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#Region "VENTA CREDITO"

#Region "Diseñador Grid"

    '*********Diseñando el grid GrdDetalleVenta**************************
    Sub DiseñaGrdDetalleVenta()
        Try
            Dim Camp1 As String = "", camp2 = "", camp3 = "", camp4 = "", camp5 = "", camp6 = "", camp7 = "", camp8 = ""

            If TipoGrid_ = FormatoGrid.BULTO Then
                Camp1 = "Tipo" : camp2 = "Bulto" : camp3 = "Peso/Volumen"
                camp4 = "Costo" : camp5 = "Sub Neto"
            ElseIf TipoGrid_ = FormatoGrid.ARTICULOS And CboTipo.SelectedValue <> 2 Then
                Camp1 = "Articulos" : camp2 = "Precio" : camp3 = "Cantidad"
                camp4 = "Peso" : camp5 = "P.Total" : camp6 = "IDARTICULO" 'T.Costo cambiado 09112011 
            ElseIf TipoGrid_ = FormatoGrid.ARTICULOS And CboTipo.SelectedValue = 2 Then
                If iID_Persona = ID_PERSONA_SODIMAC Then
                    Camp1 = "Articulos" : camp2 = "Precio" : camp3 = "Cantidad"
                    camp4 = "M3" : camp5 = "Peso" : camp6 = "P.Total" : camp7 = "IDARTICULO"
                Else
                    Camp1 = "Articulos" : camp2 = "Precio" : camp3 = "Cantidad"
                    camp4 = "M3" : camp5 = "Peso" : camp6 = "P.Total" : camp7 = "IDARTICULO"
                End If
            ElseIf TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                Camp1 = "Tipo" : camp2 = "Bulto" : camp3 = "Altura"
                camp4 = "Ancho" : camp5 = "Largo" : camp6 = "Peso Kg"
                camp7 = "Costo" : camp8 = "Sub Neto"
            End If

            With GrdDetalleVenta
                .Columns.Clear()
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = False
                .AutoGenerateColumns = False
                .RowHeadersWidth = 20
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersVisible = True
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ScrollBars = ScrollBars.Both
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
                '.DefaultCellStyle.SelectionForeColor = Color.Black

                Dim col1 As New DataGridViewTextBoxColumn
                With col1
                    .HeaderText = Camp1
                    .Name = Camp1
                    .DataPropertyName = Camp1
                    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill 'm
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    If TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                        .Width = 85
                    ElseIf TipoGrid_ = FormatoGrid.ARTICULOS Then
                        ' .Width = 100
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    Else
                        .Width = 60
                    End If
                    ' .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .ReadOnly = True
                    .Visible = True
                End With
                GrdDetalleVenta.Columns.Add(col1)

                Dim col2 As New DataGridViewTextBoxColumn
                With col2
                    .HeaderText = camp2
                    .Name = camp2
                    .DataPropertyName = camp2
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill 'm
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    If TipoGrid_ = FormatoGrid.BULTO Or TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                        .ReadOnly = False
                        .MaxInputLength = 5
                    ElseIf TipoGrid_ = FormatoGrid.ARTICULOS Then
                        .ReadOnly = True
                        .Width = 40
                    End If
                End With
                GrdDetalleVenta.Columns.Add(col2)

                Dim col3 As New DataGridViewTextBoxColumn
                With col3
                    .HeaderText = camp3
                    .Name = camp3
                    .DataPropertyName = camp3
                    If TipoGrid_ = FormatoGrid.ARTICULOS And CboTipo.SelectedValue = 2 Then
                        If iID_Persona = ID_PERSONA_SODIMAC Then
                            camp3 = "Sku"
                            .HeaderText = camp3
                        End If
                    End If
                    If TipoGrid_ = FormatoGrid.BULTO Or TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                        .DefaultCellStyle.Format = "0.00"
                        .MaxInputLength = 9
                        .Width = 90
                    Else
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        .MaxInputLength = 5
                    End If
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .ReadOnly = False
                End With
                GrdDetalleVenta.Columns.Add(col3)

                Dim col4 As New DataGridViewTextBoxColumn
                With col4
                    .HeaderText = camp4
                    .Name = camp4
                    .DataPropertyName = camp4
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill 'm
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    If TipoGrid_ = FormatoGrid.BULTO Then
                        .ReadOnly = True
                        .DefaultCellStyle.Format = "0.00"
                    ElseIf TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                        .ReadOnly = False
                        .DefaultCellStyle.Format = "0.00"
                        .MaxInputLength = 9
                    ElseIf TipoGrid_ = FormatoGrid.ARTICULOS And CboTipo.SelectedValue <> 2 Then
                        .ReadOnly = False
                        .DefaultCellStyle.Format = "0.00"
                        .MaxInputLength = 5
                        .Width = 35
                    ElseIf TipoGrid_ = FormatoGrid.ARTICULOS And CboTipo.SelectedValue = 2 Then
                        .ReadOnly = False
                        .DefaultCellStyle.Format = "0.00"
                        .MaxInputLength = 5
                        .Width = 35
                        If iID_Persona = ID_PERSONA_SODIMAC Then
                            camp4 = "Cantidad"
                            .HeaderText = camp4
                            .Visible = True
                        Else
                            .Visible = False
                        End If
                    End If
                End With
                GrdDetalleVenta.Columns.Add(col4)

                Dim col5 As New DataGridViewTextBoxColumn
                With col5
                    .HeaderText = camp5
                    .Name = camp5
                    .DataPropertyName = camp5
                    .DefaultCellStyle.Format = "0.00"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    If TipoGrid_ = FormatoGrid.VOLUMETRICO Or CboTipo.SelectedValue = 2 Then
                        .ReadOnly = False
                        .MaxInputLength = 9
                    End If

                    If TipoGrid_ = FormatoGrid.BULTO Then
                        .ReadOnly = True
                        .MaxInputLength = 9
                    End If
                End With
                GrdDetalleVenta.Columns.Add(col5)

                If TipoGrid_ = FormatoGrid.ARTICULOS And CboTipo.SelectedValue = 2 Then
                    Dim col6 As New DataGridViewTextBoxColumn
                    With col6
                        .HeaderText = camp6
                        .Name = camp6
                        .DataPropertyName = camp6
                        ' .DefaultCellStyle.Format = "0.00"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .Visible = True
                        .ReadOnly = True
                    End With
                    GrdDetalleVenta.Columns.Add(col6)

                    Dim col7 As New DataGridViewTextBoxColumn
                    With col7
                        .HeaderText = camp7
                        .Name = camp7
                        .DataPropertyName = camp7
                        ' .DefaultCellStyle.Format = "0.00"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .Visible = False
                    End With
                    GrdDetalleVenta.Columns.Add(col7)
                ElseIf TipoGrid_ = FormatoGrid.ARTICULOS And CboTipo.SelectedValue <> 2 Then
                    Dim col6 As New DataGridViewTextBoxColumn
                    With col6
                        .HeaderText = camp6
                        .Name = camp6
                        .DataPropertyName = camp6
                        ' .DefaultCellStyle.Format = "0.00"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .Visible = False
                    End With
                    GrdDetalleVenta.Columns.Add(col6)
                End If


                If TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                    Dim col6 As New DataGridViewTextBoxColumn
                    With col6
                        .HeaderText = camp6
                        .Name = camp6
                        .DataPropertyName = camp6
                        .DefaultCellStyle.Format = "0.00"
                        .MaxInputLength = 9
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .ReadOnly = True
                    End With
                    GrdDetalleVenta.Columns.Add(col6)

                    Dim col7 As New DataGridViewTextBoxColumn
                    With col7
                        .HeaderText = camp7
                        .Name = camp7
                        .DataPropertyName = camp7
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .ReadOnly = True
                        .DefaultCellStyle.Format = "0.00"
                        .MaxInputLength = 9
                    End With
                    GrdDetalleVenta.Columns.Add(col7)

                    Dim col8 As New DataGridViewTextBoxColumn
                    With col8
                        .HeaderText = camp8
                        .Name = camp8
                        .DataPropertyName = camp8
                        .DefaultCellStyle.Format = "0.00"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        .SortMode = DataGridViewColumnSortMode.NotSortable
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                        .ReadOnly = True
                        .MaxInputLength = 9
                    End With
                    GrdDetalleVenta.Columns.Add(col8)
                End If

            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*********Diseñando el grid GrdDocumentosCliente*********************
    Sub DiseñaGrdDocumentos()
        Try
            With GrdDocumentosCliente
                .Rows.Clear()
                .Columns.Clear()
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .AllowUserToAddRows = True
                .AllowUserToDeleteRows = True
                .AllowUserToOrderColumns = True
                '.BackgroundColor = SystemColors.Window
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .ReadOnly = False
                '.AutoGenerateColumns = False
                '.VirtualMode = False
                '.SelectionMode = DataGridViewSelectionMode.CellSelect
                .RowHeadersWidth = 20
                '.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                '.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With

            Dim col_1 As New DataGridViewTextBoxColumn
            With col_1
                .DisplayIndex = 0
                .DataPropertyName = "ID1"
                .Name = "ID1"
                .HeaderText = "ID1"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With


            Dim col_2 As New DataGridViewTextBoxColumn
            With col_2
                .DisplayIndex = 1
                .DataPropertyName = "ID2"
                .Name = "ID2"
                .HeaderText = "ID2"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With



            Dim col_3 As New DataGridViewTextBoxColumn
            With col_3
                .DisplayIndex = 2
                .DataPropertyName = "Cargo"
                .Name = "Cargo"
                .HeaderText = "Cargo"
                .DefaultCellStyle.ForeColor = Color.Black
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .MaxInputLength = 13
                '.Mask = "###-########"
                .DefaultCellStyle.NullValue = ""
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = False
            End With


            Dim col_4 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn
            With col_4
                .DisplayIndex = 3
                .DataPropertyName = "Seguro"
                .Name = "Seguro"
                .HeaderText = "Seguro"
                .DefaultCellStyle.ForeColor = Color.Black
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Mask = "###-########"
                .DefaultCellStyle.NullValue = ""
                .ReadOnly = True
            End With
            GrdDocumentosCliente.Columns.AddRange(col_1, col_2, col_3, col_4)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '*********Añadiendo Formato Al grid GrdDetalleVenta******************
    Sub FormatoGrdDetalleVenta()
        Try
            GrdDetalleVenta.Rows.Clear()
            If TipoGrid_ = FormatoGrid.BULTO Then
                If CboProducto.SelectedValue = 81 Then
                    Dim row0 As String() = {"CAJA 5KG", "", "0.00", "0.00", "0.00"}
                    GrdDetalleVenta.Rows().Add(row0)
                ElseIf CboProducto.SelectedValue = 82 Then
                    Dim row0 As String() = {"CAJA 10KG", "", "0.00", "0.00", "0.00"}
                    GrdDetalleVenta.Rows().Add(row0)
                Else
                    Dim row0 As String() = {"PESO", "", "0.00", "0.00", "0.00"}
                    GrdDetalleVenta.Rows().Add(row0)
                    Dim row1 As String() = {"VOLUMEN", "", "0.00", "0.00", "0.00"}
                    GrdDetalleVenta.Rows().Add(row1)
                    Dim row2 As String() = {"SOBRE", "", "0.00", "0.00", "0.00"}
                    GrdDetalleVenta.Rows().Add(row2)
                    Dim row3 As String() = {"BASE", "", "0.00", "0.00", "0.00"}
                    GrdDetalleVenta.Rows().Add(row3)

                    GrdDocumentosCliente.Rows.Clear()
                    Dim row11 As String() = {"", " ", " ", ""}
                    GrdDocumentosCliente.Rows().Add(row11)
                    GrdDocumentosCliente.Rows().Add(row11)
                    GrdDocumentosCliente.Rows().Add(row11)
                End If
            Else
                Dim row0 As String() = {"1", "", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00"}
                GrdDetalleVenta.Rows().Add(row0)
            End If

            If CboTipo.SelectedValue <> 1 Then
                TxtSubTotal.Text = "0.00"
                TxtImpuesto.Text = "0.00"
                TxtTotal.Text = "0.00"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

    '*********Funcion Condicion MONTO MINIMO (PCE)***********************
    Dim monto_minimo_PCE As Double
    Sub CondicionMontoMinimoPCE()
        Try
            'If CboTipo.SelectedValue = 1 Then
            If dtoGuia.MinimoPce(dtoUSUARIOS.m_idciudad, idUnidadAgencias, iID_Persona) = 1 Then
                CboSubCuenta.Enabled = False
                TxtSubTotal.Text = FormatNumber(Format(monto_minimo_PCE / (1 + IGV), "###,###,###.00"), 2)
                TxtImpuesto.Text = FormatNumber(IGV * Format(monto_minimo_PCE / (1 + IGV), "###,###,###.00"), 2)
                TxtTotal.Text = FormatNumber(Format(monto_minimo_PCE, "###,###,###.00"), 2)
            Else
                Dim dblTotal As Double = TxtTotal.Text
                TxtSubTotal.Text = FormatNumber(Format(dblTotal / (1 + IGV), "###,###,###.00"), 2)
                TxtImpuesto.Text = FormatNumber(IGV * Format(dblTotal / (1 + IGV), "###,###,###.00"), 2)
                TxtTotal.Text = FormatNumber(Format(dblTotal, "###,###,###.00"), 2)
            End If

            'hlamas 12-02-2014
            If TipoGrid_ = FormatoGrid.BULTO Then
                Dim intDescuentoPromocion = CalculaPromocion()
                If intDescuentoPromocion > 0 Then
                    'hlamas 11-09-2015
                    'Dim dblNuevoMontoMinimo As Double = fnTECHO(Format(monto_minimo_PCE * (1 - Val(intDescuentoPromocion) / 100), "###,###,###.000"))
                    Dim dblNuevoMontoMinimo As Double = Format(monto_minimo_PCE * (1 - Val(intDescuentoPromocion) / 100), "###,###,###.000")

                    TxtSubTotal.Text = FormatNumber(Format(dblNuevoMontoMinimo / (1 + IGV), "###,###,###.00"), 2)
                    TxtImpuesto.Text = FormatNumber(IGV * Format(dblNuevoMontoMinimo / (1 + IGV), "###,###,###.00"), 2)
                    TxtTotal.Text = FormatNumber(Format(dblNuevoMontoMinimo, "###,###,###.00"), 2)
                End If
            End If

            'End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '--agregado 04022012
    Sub CondicionMontoMinimoPYME()
        Try
            If CboProducto.SelectedValue = 7 Then
                Dim IGV As Double = dtoUSUARIOS.iIGV / 100
                TxtSubtotal.Text = FormatNumber(Format(MontoMinimoPyme / (1 + IGV), "###,###,###.00"), 2)
                TxtImpuesto.Text = FormatNumber(IGV * Format(MontoMinimoPyme / (1 + IGV), "###,###,###.00"), 2)
                TxtTotal.Text = FormatNumber(Format(MontoMinimoPyme, "###,###,###.00"), 2)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub Inicio()
        Dim obj As New dtoGuia
        Dim ds As DataSet = obj.InicioGuia(dtoUSUARIOS.IdLogin)

        '========================================================================================================            
        '0)*******Cargando Tipos ([Credito], [Pago_Contra_Entrega (PCE)], [Recojo_Carga_Acompañada (PCA)])**
        Dim dt As DataTable
        dt = New DataTable
        dt = ds.Tables(0)
        Me.CboTipo.DataSource = dt.DefaultView
        Me.CboTipo.DisplayMember = "descripcion"
        Me.CboTipo.ValueMember = "id_tipo_guia_envio"

        ''1)*******Cargando Listado Producto***************
        'dt = New DataTable
        'dt = ds.Tables(1)
        'Me.CboProducto.DataSource = dt.DefaultView
        'Me.CboProducto.DisplayMember = "nombre_secundario"
        'Me.CboProducto.ValueMember = "idprocesos"
        '2)*******Cargando filtrado de las agencias*******
        dt = New DataTable
        dt = ds.Tables(1)
        fnCargar_iWin_dt(TxtCiudadDestino, dt, coll_iDestino, iWinDestino, 0)
        '3)*******Cargando los tipos de entrega***********
        dt = New DataTable
        dt = ds.Tables(2)
        Me.CboTipoEntrega.DataSource = dt.DefaultView
        Me.CboTipoEntrega.DisplayMember = "Tipo_Entrega"
        Me.CboTipoEntrega.ValueMember = "Idtipo_Entrega"
        Me.CboTipoEntrega.SelectedValue = 0

        '4)*******Seleccion de Impresion******************
        dt = New DataTable
        dt = ds.Tables(3)
        If dt.Rows.Count > 0 Then
            Me.xIMPRESORA = dt.Rows(0).Item("IMPRESION")
            NOMBRE_IMPRESORA = dt.Rows(0).Item("Control_Impresoras")
        Else
            Me.xIMPRESORA = 0
        End If

        '6)*******Cargando Monto Minimo PCE***************
        dt = New DataTable
        dt = ds.Tables(4)
        If dt.Rows.Count > 0 Then
            monto_minimo_PCE = dt.Rows(0).Item(0)
            dFactor = dt.Rows(0).Item(1) '16112011
            MontoMinimoPyme = dt.Rows(0).Item("MONTO_MINIMO_PYME") '04022012
        Else
            monto_minimo_PCE = 0
            dFactor = 0
        End If
    End Sub


#Region "CARGA ACOMPAÑADA ----> BOLETO"
    Dim cnn As OdbcConnection '-> Conexion Mysql
    Dim bEntra As Boolean = False    
    Dim sBoleto As String = ""
    Dim bCargaAcompañada As Boolean = False
    Dim bOrigenDiferente As Boolean = False

    Private Sub txtBoleto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBoleto.KeyPress
        If ValidaNumero2(e.KeyChar) Then
            e.Handled = False
        ElseIf Asc(e.KeyChar.ToString.ToUpper) >= 65 And Asc(e.KeyChar.ToString.ToUpper) <= 90 Then 'e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TxtBoleto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBoleto.LostFocus
        Try
            Me.Cursor = Cursors.AppStarting
            '*************************************
            objGuiaEnvio.TarifaPyme_ = False
            '*************************************

            sDocCliente = ""
            bDescuento = False
            bTieneLineaCredito = False

            If Me.txtBoleto.ReadOnly Or Me.txtBoleto.Text.Trim.Length <= 1 Then
                Me.Cursor = Cursors.Default
                Return
            End If
            If Me.LblTipoComprobante.Text.Substring(0, 1) <> "G" Then
                bCargaAcompañada = False
            End If

            'hlamas 07-04-2014 CA coneccion a MYSQL
            'coneccion a athenea (vyr)
            'cnn = New Odbc.OdbcConnection("DRIVER={MySQL ODBC 3.51 Driver};SERVER=192.168.200.241;DATABASE=Tepsa;UID=ventas;PWD=10913035110;OPTION=18475")

            Dim sDoc As String = Me.txtBoleto.Text.Trim
            Dim iPos As Integer = sDoc.IndexOf("-")
            Dim sIzquierda As String = "", sDerecha As String = ""
            'Dim sIzquierda As String = sDoc.Substring(0, iPos).Trim.PadLeft(3, "0")
            'Dim sDerecha As String = sDoc.Substring(iPos + 1).Trim.PadLeft(7, "0")
            'sDoc = sIzquierda & "-" & sDerecha

            If iPos > 0 Then
                If sDoc.Substring(0, 1) = "F" Or sDoc.Substring(0, 1) = "B" Then 'electronico
                    sIzquierda = sDoc.Substring(0, iPos).Trim.PadLeft(4, "0")
                    sDerecha = sDoc.Substring(iPos + 1).Trim.PadLeft(8, "0")
                    sDoc = sIzquierda & "-" & sDerecha
                Else 'manual
                    sIzquierda = sDoc.Substring(0, iPos).Trim.PadLeft(3, "0")
                    sDerecha = sDoc.Substring(iPos + 1).Trim.PadLeft(7, "0")
                    sDoc = sIzquierda & "-" & sDerecha
                End If
            End If
            Me.txtBoleto.Text = sDoc

            Dim obj As New dto_CargaAcompañada
            Dim dt As DataTable = obj.ObtenerBoleto(sDoc)
            CargarBoleto(dt)

            'nu_docu_suna
            'Dim sql As String
            'sql = "SELECT V.idVenta ID, V.NroBoleto NUMBOLETO, "
            'sql = sql & "LEFT(V.FechaPartida,10) FECHAPARTIDA, LEFT(V.HoraPartida, 8) HORAPARTIDA, "
            'sql = sql & "P.NroDocumento nrodocumento,P.NroDocumento nu_docu_suna, upper(P.ApellidoPaterno) apepat,upper(P.ApellidoPaterno) ap, "
            'sql = sql & "UPPER(P.ApellidoMaterno) apemat,UPPER(P.ApellidoMaterno) am, "
            'sql = sql & "UPPER(P.Nombres) NOMBRES,UPPER(P.Nombres) NOMBRE,UPPER(P.Nombres) razon_social, V.NroAsiento, upper(R.LocalidadOrigen) ORIGEN, "
            'sql = sql & "UPPER(R.LocalidadDestino) DESTINO, "
            'sql = sql & "if(V.TipoOperacion='', 'V', 'A') VENTA, V.idPasajero IDPASAJERO, P.PasajeroFrecuente, "
            'sql = sql & "codCiudadOrigen,P.idtipodocumento tipo, P.telefono,'' email "
            'sql = sql & "FROM VtaPasajes V "
            'sql = sql & "INNER JOIN Clientes P ON (V.idPasajero = P.idCliente) "
            'sql = sql & "INNER JOIN Rutas R ON (V.idRuta = R.idRuta) "
            'sql = sql & "WHERE V.NroBoleto='" & sDoc & "' "

            'sql = "SELECT V.idVenta ID, V.NroBoleto NUMBOLETO, "
            'sql = sql & "LEFT(V.FechaPartida,10) FECHAPARTIDA, LEFT(V.HoraPartida, 8) HORAPARTIDA, "
            'sql = sql & "P.NroDocumento nrodocumento,P.NroDocumento nu_docu_suna, upper(P.ApellidoPaterno) apepat, upper(P.ApellidoPaterno) ap, "
            'sql = sql & "UPPER(P.ApellidoMaterno) apemat, UPPER(P.ApellidoMaterno) am, "
            'sql = sql & "UPPER(P.Nombres) NOMBRES,UPPER(P.Nombres) NOMBRE,UPPER(P.Nombres) razon_social, V.NroAsiento, upper(R.LocalidadOrigen) ORIGEN, "
            'sql = sql & "UPPER(R.LocalidadDestino) DESTINO, "
            'sql = sql & "if(V.TipoTransaccion='V', 'V', 'A') VENTA, V.idPasajero IDPASAJERO, P.PasajeroFrecuente, "
            'sql = sql & "codCiudadOrigen,P.idtipodocumento tipo, P.telefono, '' email "
            'sql = sql & "FROM VtaPasajes V "
            'sql = sql & "inner join "
            'sql = sql & "(select max(idVenta) idVenta from VtaPasajes where NroBoleto='" & sDoc & "' GROUP BY NroControl) V1 "
            'sql = sql & "on (V.idVenta = V1.idVenta) "
            'sql = sql & "INNER JOIN Clientes P ON (V.idPasajero = P.idCliente) "
            'sql = sql & "INNER JOIN Rutas R ON (V.idRuta = R.idRuta) "
            'sql = sql & "WHERE V.NroBoleto='" & sDoc & "' "
            'Dim dt As DataTable = ObtieneDT(sql)
            'CargarBoleto(dt)
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            bBoleto = False
            Controla(True)
            bCargaAcompañada = False
            Me.TxtCiudadDestino.ReadOnly = False
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CargarBoleto(ByVal dt As DataTable)
        If dt.Rows.Count > 0 Then
            'If sBoleto = TxtBoleto.Text.Trim Then
            '    Return
            'End If
            Dim iTipo As Integer
            For Each row As DataRow In dt.Rows
                iTipo = row.Item("tipo")
                row.Item("tipo") = ObtieneTipoDocumento(iTipo)
            Next

            sBoleto = TxtBoleto.Text.Trim
            Dim sql As String
            'verifica si boleto está asociado a algun documento (guia,boleta,factura)
            Dim dt2 As DataTable
            If Not BoletoAsociado(sBoleto, dt2) Then
                Dim iEstado As Integer = IIf(dt.Rows(0).Item("venta") = "V", 1, 0)
                If iEstado = 1 Then                   
                    bBoleto = True
                    Controla(False)

                    Me.TxtCiudadDestino.ReadOnly = True
                    Dim iPasajeroFrecuente As Integer = dt.Rows(0).Item("PasajeroFrecuente")
                    'If iPasajeroFrecuente = 1 Then
                    '    'verifica si pasajero frecuente esta activo
                    '    Dim iPasajero As Integer = dt.Rows(0).Item("idpasajero")
                    '    sql = "SELECT idPasajeroFrecuente, Estado FROM PasajeroFrecuente WHERE idCliente=" & iPasajero & " "
                    '    Dim dt1 As DataTable = ObtieneDT(sql)
                    '    If dt1.Rows.Count > 0 Then
                    '        iPasajeroFrecuente = IIf(dt1.Rows(0).Item("estado") = "A", 1, 0)
                    '    End If
                    'End If
                    LblPasajero.Visible = True
                    Me.LblPasajero.Text = IIf(iPasajeroFrecuente = 1, "FRECUENTE", "NORMAL")

                    Dim sender1 As New Object
                    Dim ee As New System.ComponentModel.CancelEventArgs
                    'TxtNroDocCliente_LostFocus(sender1, ee) '_Validating
                    bBoleto = True
                    'oracle
                    Dim db As New BaseDatos
                    db.Conectar()

                    'validaciones
                    Dim sOrigen As String = dt.Rows(0).Item("origen").ToString.Trim     'origen boleto
                    Dim sDestino As String = dt.Rows(0).Item("destino").ToString.Trim   'destino boleto
                    Dim iOri As Integer  'origen guia
                    Dim iDes As Integer  'destino guia

                    sql = "select PKG_IVOCARGA_ACOMPANADA.sf_ciudad_id('" & sOrigen & "') from dual"
                    db.CrearComando(sql, CommandType.Text)
                    iOri = db.EjecutarEscalar

                    sql = "select PKG_CARGA_ACOMPANADA.sf_ciudad_id('" & sDestino & "') from dual"
                    db.CrearComando(sql, CommandType.Text)
                    iDes = db.EjecutarEscalar

                    If ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = 0 Then
                        ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad
                    End If
                    If ObjVentaCargaContado.v_IDAGENCIAS = 0 Then
                        ObjVentaCargaContado.v_IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia
                    End If

                    If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 86 Then
                        If iOri <> ObjVentaCargaContado.v_IDUNIDAD_ORIGEN Then
                            'Origen de guia no coincide con boleto
                            MessageBox.Show("El Orígen del Boleto no coincide con la Guía.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            bCargaAcompañada = False
                            TxtBoleto.Text = ""
                            Return
                        End If

                        'If iDes <> ObjVentaCargaContado.v_IDUNIDAD_DESTINO Then
                        '    'Destino de guia no coincide con boleto
                        '    MessageBox.Show("El Destino del Boleto no coincide con la Guía.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '    bCargaAcompañada = False
                        '    TxtBoleto.Text = ""
                        '    Return
                        'End If
                    Else    'comprobante de pago
                        'If (iOri <> ObjVentaCargaContado.v_IDUNIDAD_ORIGEN) And (iDes <> ObjVentaCargaContado.v_IDUNIDAD_ORIGEN) Then
                        '    'unidad destino del boleto es diferente a la unidad destino del comprobante
                        '    MessageBox.Show("La Ciudad Orígen de la Venta no coincide con el Orígen o Destino del Boleto.", "Titán", MessageBoxButtons.OK)
                        '    bCargaAcompañada = False
                        '    TxtBoleto.Text = ""
                        '    Return
                        'End If
                        If iOri <> ObjVentaCargaContado.v_IDUNIDAD_ORIGEN Then
                            'unidad origen del boleto es diferente a la unidad origen del cpu
                            Dim resp As DialogResult = MessageBox.Show("La Ciudad Orígen del boleto no coincide con la Venta." & ControlChars.CrLf & "¿Desea Continuar?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            If resp = Windows.Forms.DialogResult.No Then
                                bCargaAcompañada = False
                                TxtBoleto.Text = ""
                                Return
                            Else
                                bOrigenDiferente = True
                            End If
                        End If
                    End If

                    ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = iOri
                    objGuiaEnvio.iIDUNIDAD_AGENCIA = iOri

                    Dim sAgenciaBoleto = dt.Rows(0).Item("codCiudadOrigen")
                    sql = "select PKG_IVOCARGA_ACOMPANADA.sf_agencia_id(" & iOri & ",'" & sAgenciaBoleto & "') from dual"
                    db.CrearComando(sql, CommandType.Text)
                    Dim iAgencia As Integer = db.EjecutarEscalar

                    ObjVentaCargaContado.v_IDAGENCIAS = iAgencia
                    objGuiaEnvio.iIDAGENCIAS = iAgencia

                    TxtCiudadDestino.Text = sDestino
                    bCargaAcompañada = True
                    bCargaAcompañada2 = True

                    iOficinaDestino = 0

                    'If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE <> 85 Then
                    Dim sender As Object
                    Dim e As New System.ComponentModel.CancelEventArgs
                    TxtCiudadDestino_LostFocus(sender, e) '-> obteniendo la ciudad destino del Boleto 
                    'End If

                    'Actualizar
                    If dt.Rows(0).Item("nrodocumento").ToString.Trim.Length > 0 Then
                        TxtNroDocCliente.Text = dt.Rows(0).Item("nrodocumento")
                        'TxtNroDocCliente.Tag = IIf(IsDBNull(dt.Rows(0).Item("tipo")), 1, ObtieneTipoDocumento(dt.Rows(0).Item("tipo")))
                        TxtNroDocCliente.Tag = dt.Rows(0).Item("tipo")
                    ElseIf dt.Rows(0).Item("nrodocumento").ToString.Trim.Length = 0 Then
                        TxtNroDocCliente.Text = dt.Rows(0).Item("nrodocumento")
                        'TxtNroDocCliente.Tag = IIf(IsDBNull(dt.Rows(0).Item("tipo")), 1, ObtieneTipoDocumento(dt.Rows(0).Item("tipo")))
                        TxtNroDocCliente.Tag = dt.Rows(0).Item("tipo")
                    End If
                    iID_TipoDocCli = TxtNroDocCliente.Tag

                    '--
                    Dim sNombres As String = dt.Rows(0).Item("nombres").ToString.Trim & " " & dt.Rows(0).Item("apepat").ToString.Trim & " " & dt.Rows(0).Item("apemat").ToString.Trim
                    TxtNomCliente.Text = sNombres
                    TxtNomCliente.Tag = dt.Rows(0).Item("apepat").ToString.Trim & "*" & dt.Rows(0).Item("apemat").ToString.Trim
                    TxtTelfCliente.Text = IIf(IsDBNull(dt.Rows(0).Item("telefono")), "", dt.Rows(0).Item("telefono"))
                    '--
                    '**********Comentado x NConsignado***************************************************************************************
                    'TxtNroDocConsignado.Text = dt.Rows(0).Item("nrodocumento").ToString.Trim
                    'TxtNombConsignado.Text = sNombres
                    'TxtTelfConsignado.Text = IIf(IsDBNull(dt.Rows(0).Item("telefono")), "", dt.Rows(0).Item("telefono"))

                    '****Haciendo una copia del DT**************                          
                    dtCliente = dt.Copy
                    dtConsignado = dt.Copy
                    'dtContacto = dt.Copy
                    'dtRemitente = dt.Copy
                    'iTipo = Me.ObtieneTipoDocumento(dtCliente.Rows(0).Item("tipo"))
                    '*********************
                    ' TxtTelfCliente.Text = IIf(IsDBNull(dt.Rows(0).Item("telefono")), "", dt.Rows(0).Item("telefono"))
                    If TxtNroDocCliente.Text.Trim.Length > 0 Then
                        bInicioCargaAcompañada = True
                        Me.Buscar(1)
                        bInicioCargaAcompañada = False
                    Else
                        Me.InicializarDT()
                    End If
                    Me.ChkCliente.Checked = True
                    Me.ChkCliente1.Checked = True
                    Me.ChkCliente2.Checked = True

                    iIDConsignado = 0
                    bConsignadoNuevo = True
                    bConsignadoModificado = False
                    iID_TipoDocConsig = TxtNroDocCliente.Tag

                    '****cliente****
                    sNombresCli = dt.Rows(0).Item("nombres").ToString.Trim
                    sApCli = dt.Rows(0).Item("ap").ToString.Trim
                    sAmCli = dt.Rows(0).Item("am").ToString.Trim
                    sTelfCliente = TxtTelfCliente.Text.Trim
                    sEmail = dt.Rows(0).Item("email").ToString.Trim
                    '****Remitente******                    
                    sNombreRemitente = sNombresCli
                    iID_TipoDocRemitente = iID_TipoDocCli
                    sNroDocRemitente = Me.TxtNroDocCliente.Text.Trim
                    sApRemitente = sApCli
                    sAmRemitente = sAmCli
                    '****Contacto*******
                    idcontacto = Iid
                    NombresCont = sNombresCli
                    iID_TipoDocCont = iID_TipoDocCli
                    apellPatCont = sApCli
                    apellMatCont = sAmCli
                    '****Consignado*****
                    iID_TipoDocConsig = TxtNroDocCliente.Tag
                    sNombresConsig = dt.Rows(0).Item("nombres").ToString.Trim
                    sapellPatConsig = dt.Rows(0).Item("ap").ToString.Trim
                    sapellMatConsig = dt.Rows(0).Item("am").ToString.Trim
                    sTelefonoConsig = TxtTelfCliente.Text.Trim

                    '****Comentado x NConsignado************************
                    'If TxtNroDocConsignado.Text.Trim.Length = 0 Then
                    '    iID_TipoDocConsig = 9
                    '    iID_TipoDocCli = 9
                    'End If
                    bEntra = True
                Else    'anulado
                    MessageBox.Show("El Boleto de Viaje está anulado", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bBoleto = False
                    Controla(True)
                    Me.TxtCiudadDestino.ReadOnly = False
                    Me.TxtBoleto.Focus()
                End If
                Me.BtnGraba.Focus()
            Else
                Dim s As String = ""
                For i As Integer = 0 To dt2.Rows.Count - 1
                    s = s & dt2.Rows(i).Item(0) & " " & dt2.Rows(i).Item(1) & Chr(13)
                Next
                MessageBox.Show("El Boleto " & sBoleto & " está asociado a:" & Chr(13) & Chr(13) & s, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bBoleto = False
                Controla(True)
                Me.TxtCiudadDestino.ReadOnly = False
                Me.TxtBoleto.Text = ""
                Me.TxtBoleto.Focus()
            End If
        Else
            MessageBox.Show("El Boleto " & Me.TxtBoleto.Text.Trim & " no existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bBoleto = False
            Me.TxtCiudadDestino.ReadOnly = False
            Controla(True)
            Me.TxtBoleto.Text = ""
            Me.TxtBoleto.Focus()
        End If
    End Sub

    Function BoletoAsociado(ByVal boleto As String, ByRef dt As DataTable) As Boolean
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOCARGA_ACOMPANADA.sp_boleto_asociado", CommandType.StoredProcedure)
            db.AsignarParametro("vi_boleto", boleto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            dt = db.EjecutarDataTable
            If dt.Rows.Count = 0 Then
                Return False
            Else
                If IsDBNull(dt.Rows(0).Item(0)) Then
                    Return False
                Else
                    Return True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ObtieneDT(ByVal sql As String) As DataTable
        Dim cmd As New OdbcCommand
        cmd.CommandText = sql
        cmd.CommandType = CommandType.Text
        cmd.Connection = cnn
        Dim da As New OdbcDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        Return dt
    End Function

    Sub Controla(ByVal estado As Boolean)
        Me.ChkArticulos.Enabled = estado
    End Sub

    Private Sub TxtBoleto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoleto.TextChanged
        bCargaAcompañada2 = False
        sBoleto = ""
        iOficinaDestino = 0
        'Controla(True)
        bIngresa = True
        flagPCEVALIDADOC = True
        fnVALIDARDOCUMENTOS()
        bIngresa = False
        flagPCEVALIDADOC = False
    End Sub

#End Region 'OK

    '*********SELECCION TIPO [PCE], [CREDITO], [RECOJO CARGA ACOMPAÑADA]
#Region "TIPO"
    Private Sub CboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipo.SelectedIndexChanged
        Try
            If IsReference(CboTipo.SelectedValue) Then Return

            Me.Cursor = Cursors.AppStarting
            Me.TxtCliente.Text = ""
            Me.TxtConsignado.Text = ""

            '---CambioR 10112011----
            Me.TxtNroDocCliente.Text = ""
            Me.TxtNomCliente.Text = ""
            Me.FNNUEVO()
            '----------------------

            'Me.LimpiarDatosCliente()
            'Me.LimpiarDatosGeneral()
            'Me.LimpiarConsignado()

            'hlamas 22-02-2019
            'If ObjVentaCargaContado.fnNroDocuemnto(3, CboProducto.SelectedValue) = True And Me.CboTipo.SelectedValue = 2 Then
            '    txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
            '    CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc)
            '    ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroNroGuia.Text.Trim
            'ElseIf ObjVentaCargaContado.fnNroDocuemnto(3, 0) = True And Me.CboTipo.SelectedValue = 2 Then
            '    txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
            '    CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc)
            '    ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroNroGuia.Text
            'ElseIf Me.CboTipo.SelectedValue = 2 Then
            '    MessageBox.Show("Configure Número de Guía de Envío.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.BtnGraba.Enabled = False
            'ElseIf Me.CboTipo.SelectedValue = 1 Then
            '    txtNroNroGuia.Text = ""
            '    CORRELATIVO = ""
            '    ObjVentaCargaContado.v_NROGUIA_VIGENTE = ""
            'End If


            If CboTipo.SelectedValue = 1 Then '-------> Pago Contra Entrega
                Me.CboProducto.Enabled = True

                Me.ListarProducto(0)
                LblContacto.Text = "Facturar a"
                sDocCliente = ""
                'sRazonSocial = ""               
                Me.CboSubCuenta.Enabled = False
                Me.CondicionMontoMinimoPCE() '-------->    Monto minimo PCE
                '*******************************

                'duff-----------------------------------               
                If FnExisteCliente() = False Then
                    bTieneLineaCredito = False
                    bDescuento = False
                Else
                    If CboProducto.SelectedValue <> 6 Then
                        Me.Consulta() '-->si tiene linea de credito,bdescuento,Articulos                   
                    End If
                End If
                '--------------------------------------
                Me.Grpa.Visible = False
                Me.TxtCiudadDestino.ReadOnly = False
                Me.TxtCiudadDestino.Enabled = True
                If TxtCiudadDestino.Text = "" Then idUnidadAgencias = -1

                RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                CboProducto.SelectedIndex = 0
                AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                CboTipoTarifa.Enabled = True
                RemoveHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
                CboTipoTarifa.SelectedIndex = 1
                AddHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged


                If idUnidadAgencias <> -1 Then
                    If Not ChkArticulos.Checked And ChkM3.Checked = False Then Me.fnTarifario() 'CambioR 10112011
                Else
                    Me.iOficinaDestino = 0 '--> si repite la Ciudad omitir
                End If

                '****************************************
                If CboTipoEntrega.SelectedValue = TipoEntrega.Agencia Then
                    If CboProducto.SelectedValue = 6 Then Me.ResetCalculo()
                Else
                    If ObjVentaCargaContado.dt_cur_dire_destino.Rows.Count > 0 Then
                        ObjVentaCargaContado.v_IDDIREECION_DESTINO = Int(ObjVentaCargaContado.dt_cur_dire_destino.Rows(0).Item(0).ToString)
                    Else
                        ObjVentaCargaContado.v_IDDIREECION_DESTINO = 0
                    End If
                    If CboProducto.SelectedValue = 6 Then Me.ResetCalculo()
                End If
                '****************************************

                'If ObjVentaCargaContado.fnNroDocuemnto(3, CboProducto.SelectedValue) = True Then
                '    txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
                '    CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc)
                '    txtNroNroGuia.SelectAll()
                '    ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroNroGuia.Text
                'ElseIf ObjVentaCargaContado.fnNroDocuemnto(3, 0) = True Then
                '    txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
                '    CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc)
                '    txtNroNroGuia.SelectAll()
                '    ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroNroGuia.Text
                'End If

                BtnCargAseg.Enabled = True
                CboProducto.Enabled = True
                CboSubCuenta.DataSource = Nothing

                Dim s As Object
                Dim ee As New System.Windows.Forms.DataGridViewCellEventArgs(2, 0)
                GrdDetalleVenta_CellEndEdit(s, ee)

                'If CboTipo.SelectedValue = 1 Then 'PCE
                Me.CboTipoEntrega.SelectedValue = 1
                'End If

                Me.CboProducto.Enabled = True
            ElseIf CboTipo.SelectedValue = 2 Then '----------------------------> credito (Carga Expressa y Tepsa Courier)
                'hlamas 09-05-2015
                Me.TxtDescuento.Text = ""
                Me.TxtDescuento.Enabled = False
                Me.txtDescDescto.Text = ""
                Me.txtDescDescto.Enabled = False

                'Jalando los nuevos Productos de carga expressa              
                Me.ListarProducto(4)
                '----CambioR 09102011--
                Me.TxtNroDocCliente.Text = ""
                Me.TxtNomCliente.Text = ""
                Me.FNNUEVO()
                LimpiarDatosCliente()

                '----------------------

                LblContacto.Text = "Contacto"
                sDocCliente = ""
                'sRazonSocial = ""
                Me.TxtDescuento.Text = ""
                'Me.TxtDescuento.Enabled = False
                Me.txtDescDescto.Enabled = False
                Me.bTieneLineaCredito = False
                Me.bDescuento = False
                Me.Grpa.Visible = False
                RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                'RemoveHandler TxtNomCliente.TextChanged, AddressOf TxtRasonSocialCliente_TextChanged
                RemoveHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
                Me.CboSubCuenta.DataSource = Nothing
                Me.CboSubCuenta.Enabled = True
                Me.ChkSobres.Enabled = False
                Me.BtnCargAseg.Enabled = False
                Me.CboProducto.Enabled = True
                Me.CboProducto.SelectedIndex = -1
                'Me.CboTipoTarifa.Enabled = False
                'Me.CboTipoTarifa.SelectedIndex = -1
                Me.CboTipoTarifa.SelectedIndex = 1
                If CboTipoEntrega.SelectedValue = TipoEntrega.Agencia Then '"AGENCIA"
                    If CboAgenciaDest.Text = "" Then
                        'TxtDirecConsignado.Text = "AGENCIA"
                    Else
                        'TxtDirecConsignado.Text = CboAgenciaDest.Text
                    End If
                Else
                    'TxtDirecConsignado.Text = ""
                End If
                '******
                Me.TxtCiudadDestino.ReadOnly = False
                Me.TxtCiudadDestino.Enabled = True
                Me.Grpa.Visible = False
                LblPasajero.Visible = False
                '******
                AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                'AddHandler TxtNomCliente.TextChanged, AddressOf TxtRasonSocialCliente_TextChanged
                CboProducto.SelectedIndex = 0
                AddHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged

                'hlamas 13-03-2014
                Me.CboProducto.Enabled = False

            ElseIf CboTipo.SelectedValue = 3 Then '---> recojo carga acompañada
                LblContacto.Text = "Facturar a"
                objGuiaEnvio.TarifaPyme_ = False
                objGuiaEnvio.TarifaMasiva_ = False
                '**FORMATO PARA CARGA ACOMPAÑADA****
                RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                CboProducto.SelectedValue = 6
                AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                Me.CboSubCuenta.DataSource = Nothing
                Me.CboSubCuenta.Enabled = False
                Me.TxtCiudadDestino.Enabled = True
                Me.CboAgenciaDest.DataSource = Nothing
                Me.TxtCiudadDestino.Text = ""
                'Me.Grpa.Text = "Carga Acompañada"
                Me.Grpa.Visible = True
                Me.TxtBoleto.Visible = True
                Me.bBoleto = True '-->"Y" Base = 0
                Me.TxtBoleto.Focus()
                '*********************************
                Me.TipoGrid_ = FormatoGrid.BULTO
                Me.DiseñaGrdDetalleVenta()
                Me.FormatoGrdDetalleVenta()
                '-----
                Me.CboProducto.Enabled = False
                Me.CboTipoTarifa.Enabled = False
                Me.CboTipoTarifa.SelectedIndex = -1
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Sistema de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

    '*********SELECCION DE PRODUCTO [NORMAL], [CARGA ACOMPAÑADA], [PYME], [TEPSA ENCOMIENDA]*** 
#Region "PRODUCTO"
    Dim idProducto As Integer
    Private Sub CboProducto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboProducto.SelectedIndexChanged
        Try
            RemoveHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
            RemoveHandler TxtBoleto.TextChanged, AddressOf TxtBoleto_TextChanged
            Me.CboTipoEntrega.SelectedValue = 0
            sDocCliente = ""
            bClienteModificado = False
            bDireccionModificada = False
            bContactoModificado = False
            bConsignadoModificado = False
            bDirecConsigMod = False

            bConsignadoNuevo = True
            bClienteNuevo = True
            sNombresCli = "" : sApCli = "" : sAmCli = "" : sTelfCliente = "" : sRazonSocialCliente = ""
            Me.LimpiarCliente()
            Me.LimpiarConsignado()

            If CboProducto.SelectedValue = 0 Then '--------------------------------> [NORMAL]
                'Me.RefreshNroDocumento(0)
                objGuiaEnvio.TarifaPyme_ = False
                objGuiaEnvio.TarifaMasiva_ = False
                Me.bBoleto = False '-->"N" Base <> 0
                Me.LimpiarDatosGeneral() '-->limpiar datos general
                Me.Grpa.Visible = False
                LblPasajero.Visible = False
                '******TRAERA TARIFA PUBLICA******************              
                bTieneLineaCredito = False
                bDescuento = False
                If TxtCiudadDestino.Text = "" Then idUnidadAgencias = -1
                If idUnidadAgencias <> -1 Then
                    Me.fnTarifario()
                Else
                    iOficinaDestino = 0 '--> si repite la Ciudad omitir
                End If
            ElseIf CboProducto.SelectedValue = 6 Then '----------------------------> [CARGA ACOMPAÑADA]  
                'Me.RefreshNroDocumento(0)
                objGuiaEnvio.TarifaPyme_ = False
                objGuiaEnvio.TarifaMasiva_ = False
                '**FORMATO PARA CARGA ACOMPAÑADA****          
                Me.LimpiarDatosGeneral()
                Me.TxtCiudadDestino.Enabled = False
                Me.CboAgenciaDest.DataSource = Nothing
                Me.TxtCiudadDestino.Text = ""
                'Me.Grpa.Text = "Carga Acompañada"
                Me.Grpa.Visible = True
                Me.TxtBoleto.Visible = True
                Me.bBoleto = True '-->"Y" Base = 0
                Me.TxtBoleto.Focus()
                '*********************************
                Me.TipoGrid_ = FormatoGrid.BULTO
                Me.DiseñaGrdDetalleVenta()
                Me.FormatoGrdDetalleVenta()
                '*********************************
            ElseIf CboProducto.SelectedValue = 7 Then '----------------------------> [PYME]
                objGuiaEnvio.TarifaMasiva_ = False
                'Me.RefreshNroDocumento(7)
                Me.bBoleto = False '-->"N" Base <> 0
                Me.LimpiarDatosGeneral()
                Me.Grpa.Visible = False
                '***********TARIFA PYME*********               
                bTieneLineaCredito = False
                bDescuento = False
                If TxtCiudadDestino.Text = "" Then idUnidadAgencias = -1
                If idUnidadAgencias <> -1 Then
                    objGuiaEnvio.TarifaPyme_ = True
                    Me.fnTarifario()
                Else
                    iOficinaDestino = 0 '--> si repite la Ciudad omitir
                End If
                LblPasajero.Visible = False
                '*******************************
            ElseIf CboProducto.SelectedValue = 8 Then '----------------------------> MASIVA 
                'Me.RefreshNroDocumento(8)
                objGuiaEnvio.TarifaPyme_ = False
                Me.bBoleto = False '-->"N" Base <> 0
                Me.LimpiarDatosGeneral()

                Me.Grpa.Visible = False
                Me.TxtBoleto.Visible = False

                '*******TARIFA MASIVA*******
                objGuiaEnvio.TarifaMasiva_ = True
                bTieneLineaCredito = False
                bDescuento = False

                If TxtCiudadDestino.Text = "" Then idUnidadAgencias = -1
                If idUnidadAgencias <> -1 Then
                    Me.fnTarifario()
                Else
                    iOficinaDestino = 0
                End If
                LblPasajero.Visible = False
                '***********************************
            ElseIf CboProducto.SelectedValue = 5 Then '-------- TEPSA COURIER

                objGuiaEnvio.TarifaPyme_ = False
                Me.bBoleto = False '-->"N" Base <> 0
                Me.LimpiarDatosGeneral()

                If idUnidadAgencias <> -1 Then
                    Me.fnTarifario()
                Else
                    iOficinaDestino = 0
                End If
            ElseIf CboProducto.SelectedValue = 10 Then '--------------------------------> [TEPSA SOBRES]
                'hlamas 11-09-2015
                Me.CboProducto.SelectedValue = 0

                'Me.RefreshNroDocumento(0)
                objGuiaEnvio.TarifaPyme_ = False
                objGuiaEnvio.TarifaMasiva_ = False
                Me.bBoleto = False '-->"N" Base <> 0
                Me.LimpiarDatosGeneral() '-->limpiar datos general
                Me.Grpa.Visible = False
                LblPasajero.Visible = False
                '******TRAERA TARIFA PUBLICA******************              
                bTieneLineaCredito = False
                bDescuento = False
                If TxtCiudadDestino.Text = "" Then idUnidadAgencias = -1
                If idUnidadAgencias <> -1 Then
                    Me.fnTarifario()
                Else
                    iOficinaDestino = 0 '--> si repite la Ciudad omitir
                End If
            ElseIf CboProducto.SelectedValue = 81 Or CboProducto.SelectedValue = 82 Then '----------------------------> TEPSA BOX
                'Me.RefreshNroDocumento(0)
                objGuiaEnvio.TarifaPyme_ = False
                objGuiaEnvio.TarifaMasiva_ = False
                Me.bBoleto = False '-->"N" Base <> 0
                Me.LimpiarDatosGeneral() '-->limpiar datos general

                Me.Grpa.Visible = False
                Me.txtBoleto.Visible = False
                Me.LblPasajero.Visible = False

                '*******TARIFA TEPSA BOX*******
                objGuiaEnvio.TarifaBox_ = True
                bTieneLineaCredito = False
                bDescuento = False

                If TxtCiudadDestino.Text = "" Then idUnidadAgencias = -1
                If idUnidadAgencias <> -1 Then
                    Me.fnTarifario()
                Else
                    iOficinaDestino = 0
                End If
                LblPasajero.Visible = False
            Else
                TipoGrid_ = FormatoGrid.BULTO
                DiseñaGrdDetalleVenta()
                Me.ResetCalculo()
            End If
            AddHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
            AddHandler txtBoleto.TextChanged, AddressOf TxtBoleto_TextChanged

            '-->10/09/2013 - jabanto
            '-->Oculta los campos DT(Docuemento de transporte)
            lbldt.Visible = False
            txtdt.Visible = False
            Me.dtpFechaRecojo.Visible = False
            Me.dtpFechaRecojo.Checked = False
            TxtTelfCliente.Size = New Size(329, 20)
            txtdt.Clear()

            'hlamas 23-09-2013
            Me.ControlaSubcuentaOrigen(False)
            CboSubCuenta.DataSource = Nothing

            'hlamas 15-11-2013
            'Tarifa Entrega a Domicilio
            If CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX And CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX_10 Then
                GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, dtoUSUARIOS.m_idciudad, idUnidadAgencias, CboProducto.SelectedValue, 3, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "TARIFA"
    Private Sub CboTipoTarifa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoTarifa.SelectedIndexChanged
        Try
            If ChkArticulos.Checked = True Then
                ChkArticulos.Checked = False
            End If

            'If CboTipoTarifa.SelectedIndex = 1 Then Comentado por Diego Zegarra
            If CboTipoTarifa.SelectedIndex = 1 Then  ' Nuevo Tipo Tarifa 1 = Estandar , 2= Urgentes
                bTieneLineaCredito = False
                bDescuento = False
            End If

            Me.RemoveItemsCargAseg()
            objGuiaEnvio.TarifaPyme_ = IIf(CboProducto.SelectedValue = 7, 1, 0)
            '***********LISTARA TARIFA PUBLICA O CREDITO**********
            If CboProducto.SelectedValue <> 6 AndAlso Me.TxtNroDocCliente.Text.Trim.Length > 0 AndAlso ObjVentaCargaContado.dt_cur_persona.Rows.Count > 0 Then
                Me.Consulta() '--> si el cliente tiene linea de credito, Descuento, Normal o tiene Articulos
            Else
                If bTieneLineaCredito Then bTieneLineaCredito = False
                If bDescuento Then bDescuento = False
            End If

            Me.ResetCalculo()
            If CboProducto.SelectedValue = 8 Then objGuiaEnvio.TarifaMasiva_ = True

            'hlamas 15-11-2013
            'Tarifa Entrega a Domicilio
            If Not IsReference(CboTipoTarifa.SelectedValue) Then
                GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, dtoUSUARIOS.m_idciudad, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)
            End If

            Me.fnTarifario()
            GrdDetalleVenta("Costo", 0).Value = Format(tarifa_Peso, "0.00")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "DESTINO"
    Dim iOficinaDestino As Integer
    Dim CodCiudadDest_ As Integer
    Dim lb_no_lee As Boolean = True
    Dim idUnidadAgencias As Integer = -1
    '****CIUDAD*****
    Private Sub TxtCiudadDestino_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCiudadDestino.Enter
        TxtCiudadDestino.SelectAll()
    End Sub

    Private Sub TxtCiudadDestino_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCiudadDestino.LostFocus
        Try
            Me.Cursor = Cursors.AppStarting

            ChkArticulos.Checked = False
            idUnidadAgencias = iWinDestino.IndexOf(TxtCiudadDestino.Text)
            Dim ErrCiudad_ As String = "" : CodCiudadDest_ = -1

            If idUnidadAgencias >= 0 Then '-> existe ciudad
                dtDireccion2 = Nothing
                CboDireccion2.DataSource = Nothing
                Me.CboDireccion2.Items.Clear()
                Me.CboDireccion2.Items.Add(" (SELECCIONE)")
                Me.CboDireccion2.SelectedIndex = 0

                idUnidadAgencias = Int(coll_iDestino.Item(idUnidadAgencias.ToString))

                'hlamas 24-02-2014
                If Me.CboTipoEntrega.SelectedValue = 2 Then
                    ActualizaDireccion(CboDireccion2)
                End If

                RemoveItemsCargAseg() '--->Limpiando items [carga asegurada]
                ChkM3.Checked = False

                '***Reseteando valores del grid****
                TipoGrid_ = FormatoGrid.BULTO
                Me.DiseñaGrdDetalleVenta()
                FormatoGrdDetalleVenta()
                '**********************************
                CodCiudadDest_ = idUnidadAgencias
                ObjVentaCargaContado.fnGetAgencias(idUnidadAgencias, 1)
                Dim DtAgenciaDestino As DataTable = ObjVentaCargaContado.dt_VarAgencias.Copy

                With Me.CboAgenciaDest
                    DtAgenciaDestino = ObjVentaCargaContado.dt_VarAgencias.Copy
                    .DataSource = DtAgenciaDestino
                    .DisplayMember = "nombre_agencia"
                    .ValueMember = "idagencias"
                    If .Items.Count > 2 Then
                        .SelectedIndex = 0
                        .DroppedDown = True
                        .Focus()
                        Me.Cursor = Cursors.Default
                    ElseIf .Items.Count = 1 Then
                        .SelectedIndex = 0
                        .Focus()
                    Else
                        .SelectedIndex = 1
                        .Focus()
                    End If
                End With

                '*********************************
                Me.objGuiaEnvio.TarifaPyme_ = False
                If FnExisteCliente() = False Then
                    If CboProducto.SelectedValue = 81 Or CboProducto.SelectedValue = 82 Then
                        objGuiaEnvio.TarifaPublica_ = False
                        objGuiaEnvio.TarifaBox_ = True
                    Else
                        objGuiaEnvio.TarifaPublica_ = True
                    End If
                    bTieneLineaCredito = False
                    bDescuento = False
                Else
                    If CboProducto.SelectedValue <> 6 Then
                        Me.Consulta() '-->si tiene linea de credito,bdescuento,Articulos
                    ElseIf CboProducto.SelectedValue = 7 Then
                        Me.objGuiaEnvio.TarifaPyme_ = True
                    ElseIf CboProducto.SelectedValue = 81 Or CboProducto.SelectedValue = 82 Then
                        objGuiaEnvio.TarifaBox_ = True
                    End If
                End If

                '****OBTENIENDO EL TARIFARIO******    
                '****OBTENIENDO EL TARIFARIO******     
                If (CboTipo.SelectedValue = 2 And CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_COURIER) Then
                    fnTarifario()
                    'fncValidarEnvioRetorno_Destino_CentroCosto()
                    Me.Cursor = Cursors.Default
                ElseIf Me.CboTipo.SelectedValue <> 2 Or (Me.CboTipo.SelectedValue = 2 And Me.TxtCliente.Text.Trim.Length > 0 And _
                                                          CboProducto.SelectedValue = ID_PRODUCTO_CARGA_EXPRESA) Then
                    fnTarifario()
                    'fncValidarEnvioRetorno_Destino_CentroCosto()
                    Me.Cursor = Cursors.Default
                End If

                'If CboTipo.SelectedValue <> 2 Then
                '    fnTarifario()
                'End If

                ' Me.NewfnTarifario()
                '*********************************

                'hlamas 13-03-2014
                ClienteProducto(iID_Persona, Me.CboSubCuenta.SelectedValue, dtoUSUARIOS.m_idciudad, idUnidadAgencias)

                'hlamas 24-02-2014
                'If ID_PERSONA_DATAIMAGENES = iID_Persona Then
                Me.ClientePersonalizado(iID_Persona)
                'End If

                Me.Cursor = Cursors.Default
            ElseIf idUnidadAgencias = -1 Then '-> No existe la Ciudad Destino
                RemoveItemsCargAseg()
                CboAgenciaDest.DataSource = Nothing
                TipoGrid_ = FormatoGrid.BULTO
                Me.DiseñaGrdDetalleVenta()
                FormatoGrdDetalleVenta()
                bDescuento = False
                bTieneLineaCredito = False
                iOficinaDestino = -1
                ChkArticulos.Enabled = False : ChkArticulos.Checked = False
                ChkM3.Checked = False
                Me.Cursor = Cursors.Default
            End If
            iOficinaDestino = idUnidadAgencias

            'hlamas 01-10-2013
            Me.CargarSubcuentaDestino(ObjVentaCargaContado.v_IDPERSONA, idUnidadAgencias)

            'hlamas 15-11-2013
            'Tarifa Entrega a Domicilio
            GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, dtoUSUARIOS.m_idciudad, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'SI TIENE ARTICULOS,DESCUENTO, LINEA DE CREDITO
    Sub Consulta()
        Try
            'hlamas 21-01-2016
            ChkArticulos.Tag = Nothing
            Me.DtArticulos = ObjVentaCargaContado.dt_cur_Articulos.Copy
            Iid = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(0)
            '****************************************************************************************
            If Iid > 0 Then
                RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                '**************************TIPO DE CLIENTE [Normal, PYME]****************************
                Dim iProceso As Integer = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(7)
                If iProceso = 0 Then '------> Normal Or (iProceso = 7 And ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(8) <> TxtCliente.Text.Trim)
                    objGuiaEnvio.TarifaPyme_ = False
                    If CboProducto.SelectedValue = 6 Then
                        Me.CboProducto.SelectedValue = 6
                    ElseIf CboProducto.SelectedValue = 8 And bTieneLineaCredito = False Then
                        Me.CboProducto.SelectedValue = 8
                    ElseIf CboProducto.SelectedValue = 81 Then
                        Me.CboProducto.SelectedValue = 81
                    ElseIf CboProducto.SelectedValue = 82 Then
                        Me.CboProducto.SelectedValue = 82
                        'Else
                        '    Me.CboProducto.SelectedValue = iProceso
                    End If
                ElseIf iProceso = 7 Then '--> Pyme  
                    Me.CboProducto.SelectedValue = iProceso
                    ' Me.TxtTelfConsignado.Focus()
                    Me.objGuiaEnvio.TarifaPyme_ = True '--> indica q traera tarifa Pyme                                      
                ElseIf iProceso = 8 Then '--> Masiva
                    objGuiaEnvio.TarifaPyme_ = False
                    Me.CboProducto.SelectedValue = iProceso
                    objGuiaEnvio.TarifaMasiva_ = True
                ElseIf iProceso = 81 Or iProceso = 82 Then '--> Tepsa Box
                    Me.CboProducto.SelectedValue = iProceso
                    objGuiaEnvio.TarifaPyme_ = False
                    objGuiaEnvio.TarifaMasiva_ = False
                    objGuiaEnvio.TarifaBox_ = True
                    Me.CboProducto.SelectedValue = iProceso
                End If
                AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                '**************************CLIENTE TIENE DESCUENTO***********************************
                iDescuento = IIf(ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(4) <> 0, ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(4), 0)
                If iDescuento <> 0 Then
                    iDescuento = iDescuento / 100
                    bDescuento = True
                Else
                    bDescuento = False
                End If
            Else
                bDescuento = False
                ChkArticulos.Enabled = False : ChkArticulos.Checked = False
            End If
            If Iid > 0 Then
                '****************CLIENTE TIENE [ARTICULOS]*******************************
                If DtArticulos.Rows.Count > 0 Then
                    ChkArticulos.Enabled = True
                    'hlamas 21-01-2016
                    ChkArticulos.Tag = 1
                Else
                    ChkArticulos.Enabled = False : ChkArticulos.Checked = False
                End If
            Else
                ChkArticulos.Enabled = False : ChkArticulos.Checked = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '****AGENCIA*****
    Private Sub CboAgenciaDest_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAgenciaDest.SelectedIndexChanged
        Try
            Me.Cursor = Cursors.AppStarting
            If CboTipo.SelectedValue = 2 Then 'PCE

                'TxtDirecConsignado.Text = CboAgenciaDest.Text
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

    'TIPO ENTREGA, SUB_CUENTA
#Region "CONDICION"

    'Private Sub CboTipoEntrega_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboTipoEntrega.KeyPress
    'End Sub
    '****ENTREGA****
    Private Sub CboTipoEntrega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoEntrega.SelectedIndexChanged
        Try
            If Not IsReference(CboTipoEntrega.SelectedValue) Then
                Dim iidTipo As Integer = CboTipoEntrega.SelectedValue
                'If (iidTipo = 2 Or iidTipo = 0) AndAlso Me.CboTipo.SelectedValue = 1 Then 'si pce es a domicilio se fuerza a agencia
                'Me.CboTipoEntrega.SelectedValue = 1
                'Return
                'End If
                Me.ConvertirTipoEntrega(CboTipoEntrega.SelectedValue)

                If CboProducto.SelectedValue = 6 Then Me.ResetCalculo()
                '09-09-2011 richard
                If CboTipo.SelectedValue <> 3 Then
                    If CboProducto.SelectedValue = 6 And iidTipo = 1 Then '------> Tipo Entrega [Agencia] No Incluye Base
                        GrdDetalleVenta(3, 3).Value = "0.00"
                        GrdDetalleVenta(4, 3).Value = "0.00"
                        Me.Monto_Base = 0.0
                        Me.TxtReferencia.Text = "" '09092011
                    ElseIf CboProducto.SelectedValue = 6 And iidTipo = 2 Then '--> Tipo Entrega [Agencia] Si Icluye Base
                        GrdDetalleVenta(3, 3).Value = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base, "0.00")
                        GrdDetalleVenta(4, 3).Value = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base, "0.00")
                        Me.Monto_Base = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base, "0.00")
                    End If
                Else
                    GrdDetalleVenta(3, 3).Value = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base, "0.00")
                    GrdDetalleVenta(4, 3).Value = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base, "0.00")
                    Me.Monto_Base = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base, "0.00")
                End If

                'hlamas 24-02-2014
                If Me.CboTipoEntrega.SelectedValue = 2 AndAlso Me.CboDireccion2.Items.Count <= 1 Then
                    ActualizaDireccion(CboDireccion2)
                End If

                'hlamas 15-11-2013
                'Tarifa Entrega a Domicilio
                GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, dtoUSUARIOS.m_idciudad, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)

                If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX Or CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX_10 Then
                    fnTarifario()
                    fnTotalPago()
                    'CalculoArticulos()
                End If
                Me.RbtDocumento.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '****SUB CUENTA****    
    Dim CboSubCuentaSelectedIndex_ As Boolean
    Private Sub CboSubCuenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSubCuenta.SelectedIndexChanged
        Try
            Me.Cursor = Cursors.AppStarting
            'If (CboProducto.SelectedValue = ID_PRODUCTO_CARGA_EXPRESA) Then
            If CboSubCuenta.Focused = True Then
                flagControl = True
                TipoGrid_ = FormatoGrid.BULTO : LbldetalleVenta.Text = "Detalle Venta" : Me.DiseñaGrdDetalleVenta()
                FormatoGrdDetalleVenta()
                ' Me.tarifarioEnMemoria()
                Me.ResetCalculo()

                Dim iOpcion As Integer = IIf(Me.RbtDocumento.Checked, 1, 2)
                Dim iCliente As Integer = iID_Persona 'iOpcion = 2, Me.TxtCliente.Text.Trim,

                Dim obj As New dtoGuiaEnvio
                'Consultando X SubCuenta
                'Dim ds As DataSet = obj.BuscarClienteCredito(iCliente, 1, dtoUSUARIOS.m_idciudad, idUnidadAgencias, objGuiaEnvio.iIDCENTRO_COSTO)
                Dim ds As DataSet = obj.BuscarClienteCredito(iCliente, dtoUSUARIOS.m_idciudad, idUnidadAgencias, CboSubCuenta.SelectedValue)

                ChkCliente.Checked = False
                ChkCliente1.Checked = False
                'BuscarClienteCredito()

                'Me.MostrarClienteCredito(ds)
                Me.MostrarClienteCreditoXSubCuenta(ds)

                'hlamas 24-02-2014
                Me.ClientePersonalizado(iCliente)

                'hlamas 13-03-2014
                ClienteProducto(iID_Persona, Me.CboSubCuenta.SelectedValue, dtoUSUARIOS.m_idciudad, idUnidadAgencias)

                Me.ConvertirTipoEntrega(CboTipoEntrega.SelectedValue)
                If Me.CboProducto.SelectedIndex > -1 Then
                    fnTarifario()
                End If

                If Me.CboTipoEntrega.SelectedValue = 2 AndAlso Me.CboDireccion2.Items.Count <= 1 Then
                    ActualizaDireccion(CboDireccion2)
                End If

                'Se le quita esta opcion de validar en 0 el MONTO_BASE,debido a que todos tendran de retorno de 5.93 
                'fncValidarEnvioRetorno_Destino_CentroCosto()


            End If
            'End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'FUNCION MOSTRAR DATOS SUB_CUENTA
    Sub MostrarClienteCreditoXSubCuenta(ByVal ds As DataSet)
        bClienteNuevo = False
        'Me.LimpiarDatosCliente()
        LimpiaDatosCliente()

        '**Articulos**
        DtArticulos = ds.Tables(2).Copy
        If ds.Tables(2).Rows.Count > 0 Then
            ChkArticulos.Enabled = True
        Else
            ChkArticulos.Enabled = False : ChkArticulos.Checked = False
        End If


        With Me.CboDireccion2
            dtDireccion2 = ds.Tables(0)
            .DataSource = dtDireccion2
            .DisplayMember = "direccion"
            .ValueMember = "iddireccion_consignado"

            If .Items.Count > 2 Then
                .SelectedIndex = 0
                .DroppedDown = True
                ' .Focus()
                Me.Cursor = Cursors.Default
            ElseIf .Items.Count = 1 Then
                .SelectedIndex = 0
                ' .Focus()
            Else
                .SelectedIndex = 1
                IdDireccionOrigen = CboDireccion2.SelectedValue
                '  .Focus()
            End If
        End With

        'RemoveHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
        With Me.CboContacto
            dtContacto = ds.Tables(1)
            dtContactoParalelo = ds.Tables(1).Copy
            .DataSource = dtContacto
            .DisplayMember = "nombres"
            .ValueMember = "idcontacto_persona"
            If .Items.Count > 2 Then
                .SelectedIndex = 0
            ElseIf .Items.Count = 1 Then
                .SelectedIndex = 0
                ChkCliente1.Checked = True
            Else
                .SelectedIndex = 1
            End If
            ' Me.ChkCliente1.Tag = DBNull.Value
        End With

        With Me.CboRemitente
            dtRemitente = ds.Tables(1).Copy
            dtRemitenteParalelo = ds.Tables(1).Copy
            .DataSource = dtRemitente
            .DisplayMember = "nombres"
            .ValueMember = "idcontacto_persona"
            If .Items.Count > 2 Then
                .SelectedIndex = 0
            ElseIf .Items.Count = 1 Then
                .SelectedIndex = 0
                ChkCliente.Checked = True
            Else
                .SelectedIndex = 1
            End If
            'Me.ChkCliente.Tag = DBNull.Value
        End With

        ' AddHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged

        If TipoComprobante = 1 Then
            CboContacto.Enabled = True
            ChkCliente1.Enabled = True
        End If
    End Sub
#End Region

#Region "CLIENTE"

    '****X NOMBRE O NRO DOCUMENTO DEL CLIENTE******
    Private Sub RbtDocumento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtDocumento.CheckedChanged, RbtNombre.CheckedChanged
        Me.TxtCliente.Text = ""
        If CType(sender, RadioButton).Name = "RbtDocumento" Then
            Me.TxtCliente.MaxLength = 11
        Else
            Me.TxtCliente.MaxLength = 50
        End If
        Me.TxtCliente.Focus()
    End Sub
    'Cliente
    Dim sNombresCli As String = "", sApCli As String = "", sAmCli As String = "", sTelfCliente As String = "", sEmail = "", sRazonSocialCliente As String = ""
    Dim iID_TipoDocCli As Integer = 0
    'Remitente
    Dim sNombreRemitente As String = "", sApRemitente As String = "", sAmRemitente As String = "", sNroDocRemitente As String = ""
    Dim iID_TipoDocRemitente As Integer = 0
    Dim bClienteCredito As Boolean
    '***BUSCAR CLIENTE***


    Private Sub BtnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCliente.Click
        Try
            Me.Cursor = Cursors.AppStarting
            Dim frm As New FrmCliente3
            frm.iProducto = Me.CboProducto.SelectedValue
            frm.iFicha = 1
            Dim iFila As Integer = 0
            Dim sNumero As String = ""
            Dim iTipo As Integer
            Dim iDepartamento As Integer
            Dim iProvincia As Integer
            Dim iDistrito As Integer
            Dim iId_via As Integer
            Dim sVia As String = ""
            Dim sNumero2 As String = ""
            Dim sManzana As String = ""
            Dim sLote As String = ""
            Dim iId_Nivel As Integer
            Dim sNivel As String = ""
            Dim iId_Zona As Integer
            Dim sZona As String = ""
            Dim iId_Clasificacion As Integer
            Dim sClasificacion As String = ""

            Dim iTipo2 As Integer
            Dim sNumero3 As String = ""
            Dim sContacto As String = ""
            Dim sNombresCont As String = ""
            Dim sApCont As String = ""
            Dim sAmCont As String = ""
            Dim bEsCliente As Boolean = False

            Dim iTipo3 As Integer
            Dim sNroDocRemitente As String = ""
            Dim sRemitente As String = ""
            Dim sNombresRemitente As String = ""
            Dim sAp As String = ""
            Dim sAm As String = ""
            Dim bEsCliente2 As Boolean = False

            If Me.TxtNroDocCliente.Text.Trim.Length > 0 Or Me.TxtNomCliente.Text.Trim.Length > 0 Then
                If Not bClienteNuevo Then
                    sNumero = IIf(IsDBNull(dtCliente.Rows(iFila).Item("nu_docu_suna")), "", dtCliente.Rows(iFila).Item("nu_docu_suna"))
                    sRazonSocialCliente = IIf(IsDBNull(dtCliente.Rows(iFila).Item("razon_social")), "", dtCliente.Rows(iFila).Item("razon_social"))
                    iTipo = IIf(IsDBNull(dtCliente.Rows(iFila).Item("tipo")), "", dtCliente.Rows(iFila).Item("tipo"))
                    sTelfCliente = IIf(IsDBNull(dtCliente.Rows(iFila).Item("telefono")), "", dtCliente.Rows(iFila).Item("telefono"))
                    sEmail = IIf(IsDBNull(dtCliente.Rows(iFila).Item("Email")), "", dtCliente.Rows(iFila).Item("Email")) '07092011
                    If iTipo = 1 Then
                        sNombresCli = ""
                        sApCli = ""
                        sAmCli = ""
                    Else
                        sNombresCli = IIf(IsDBNull(dtCliente.Rows(0).Item("nombres")), "", dtCliente.Rows(0).Item("nombres"))
                        sApCli = IIf(IsDBNull(dtCliente.Rows(0).Item("ap")), "", dtCliente.Rows(0).Item("ap"))
                        sAmCli = IIf(IsDBNull(dtCliente.Rows(0).Item("am")), "", dtCliente.Rows(0).Item("am"))
                        'If sNombresCli.Trim.Length = 0 Then
                        '    sNombresCli = sCliente
                        'End If
                    End If

                    iFila = Me.CboDireccion.SelectedIndex
                    iDepartamento = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("iddepartamento")), 0, dtDireccion.Rows(iFila).Item("iddepartamento"))
                    iProvincia = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("idprovincia")), 0, dtDireccion.Rows(iFila).Item("idprovincia"))
                    iDistrito = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("iddistrito")), 0, dtDireccion.Rows(iFila).Item("iddistrito"))
                    iId_via = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("id_via")), 0, dtDireccion.Rows(iFila).Item("id_via"))
                    sVia = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("via")), "", dtDireccion.Rows(iFila).Item("via"))
                    sNumero2 = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("numero")), "", dtDireccion.Rows(iFila).Item("numero"))
                    sManzana = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("manzana")), "", dtDireccion.Rows(iFila).Item("manzana"))
                    sLote = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("lote")), "", dtDireccion.Rows(iFila).Item("lote"))
                    iId_Nivel = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("id_nivel")), 0, dtDireccion.Rows(iFila).Item("id_nivel"))
                    sNivel = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("nivel")), "", dtDireccion.Rows(iFila).Item("nivel"))
                    iId_Zona = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("id_zona")), 0, dtDireccion.Rows(iFila).Item("id_zona"))
                    sZona = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("zona")), "", dtDireccion.Rows(iFila).Item("zona"))
                    iId_Clasificacion = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("Id_Clasificacion")), 0, dtDireccion.Rows(iFila).Item("Id_Clasificacion"))
                    sClasificacion = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("Clasificacion")), "", dtDireccion.Rows(iFila).Item("Clasificacion"))

                    iFila = Me.CboContacto.SelectedIndex
                    iTipo2 = IIf(IsDBNull(dtContacto.Rows(iFila).Item("idtipo_documento_contacto")), 0, dtContacto.Rows(iFila).Item("idtipo_documento_contacto"))
                    sNumero3 = IIf(IsDBNull(dtContacto.Rows(iFila).Item("nrodocumento")), "", dtContacto.Rows(iFila).Item("nrodocumento"))
                    sContacto = IIf(IsDBNull(dtContacto.Rows(iFila).Item("nombres")), "", dtContacto.Rows(iFila).Item("nombres"))
                    sNombresCont = IIf(IsDBNull(dtContacto.Rows(iFila).Item("nombre")), "", dtContacto.Rows(iFila).Item("nombre")) 'new
                    sApCont = IIf(IsDBNull(dtContacto.Rows(iFila).Item("apepat")), "", dtContacto.Rows(iFila).Item("apepat"))
                    sAmCont = IIf(IsDBNull(dtContacto.Rows(iFila).Item("apemat")), "", dtContacto.Rows(iFila).Item("apemat"))

                    If sContacto.Trim.Substring(0, 1) = "(" Then
                        sContacto = ""
                    End If
                    bEsCliente = Me.ChkCliente1.Checked

                    iFila = Me.CboRemitente.SelectedIndex
                    iTipo3 = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("idtipo_documento_contacto")), 0, dtRemitente.Rows(iFila).Item("idtipo_documento_contacto"))
                    sNroDocRemitente = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("nrodocumento")), "", dtRemitente.Rows(iFila).Item("nrodocumento"))
                    sRemitente = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("nombres")), "", dtRemitente.Rows(iFila).Item("nombres"))
                    sNombresRemitente = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("nombre")), "", dtRemitente.Rows(iFila).Item("nombre")) 'new
                    sAp = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("apepat")), "", dtRemitente.Rows(iFila).Item("apepat"))
                    sAm = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("apemat")), "", dtRemitente.Rows(iFila).Item("apemat"))

                    If sRemitente.Trim.Substring(0, 1) = "(" Then
                        sRemitente = ""
                    End If
                    bEsCliente2 = Me.ChkCliente.Checked
                Else
                    sNumero = IIf(IsDBNull(dtCliente.Rows(0).Item("nu_docu_suna")), "", dtCliente.Rows(0).Item("nu_docu_suna"))
                    sRazonSocialCliente = IIf(IsDBNull(dtCliente.Rows(0).Item("razon_social")), "", dtCliente.Rows(0).Item("razon_social"))
                    If Not bBoleto Then
                        iTipo = IIf(IsDBNull(dtCliente.Rows(0).Item("tipo")), "", dtCliente.Rows(0).Item("tipo"))
                    Else
                        'iTipo = IIf(IsDBNull(dtCliente.Rows(0).Item("tipo")), 9, ObtieneTipoDocumento(dtCliente.Rows(0).Item("tipo")))
                        iTipo = IIf(IsDBNull(dtCliente.Rows(0).Item("tipo")), "", dtCliente.Rows(0).Item("tipo"))
                    End If
                    sTelfCliente = IIf(IsDBNull(dtCliente.Rows(iFila).Item("telefono")), "", dtCliente.Rows(iFila).Item("telefono"))
                    sEmail = IIf(IsDBNull(dtCliente.Rows(iFila).Item("Email")), "", dtCliente.Rows(iFila).Item("Email")) '07092011
                    If iTipo = 1 Then
                        sNombresCli = ""
                        sApCli = ""
                        sAmCli = ""
                    Else
                        sNombresCli = IIf(IsDBNull(dtCliente.Rows(0).Item("nombres")), "", dtCliente.Rows(0).Item("nombres"))
                        sApCli = IIf(IsDBNull(dtCliente.Rows(0).Item("ap")), "", dtCliente.Rows(0).Item("ap"))
                        sAmCli = IIf(IsDBNull(dtCliente.Rows(0).Item("am")), "", dtCliente.Rows(0).Item("am"))
                        sTelfCliente = IIf(IsDBNull(dtCliente.Rows(iFila).Item("telefono")), "", dtCliente.Rows(iFila).Item("telefono"))
                    End If
                    If Not bBoleto Then
                        iFila = Me.CboDireccion.SelectedIndex
                        iDepartamento = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("iddepartamento")), 0, dtDireccion.Rows(iFila).Item("iddepartamento"))
                        iProvincia = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("idprovincia")), 0, dtDireccion.Rows(iFila).Item("idprovincia"))
                        iDistrito = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("iddistrito")), 0, dtDireccion.Rows(iFila).Item("iddistrito"))
                        iId_via = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("id_via")), 0, dtDireccion.Rows(iFila).Item("id_via"))
                        sVia = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("via")), "", dtDireccion.Rows(iFila).Item("via"))
                        sNumero2 = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("numero")), "", dtDireccion.Rows(iFila).Item("numero"))
                        sManzana = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("manzana")), "", dtDireccion.Rows(iFila).Item("manzana"))
                        sLote = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("lote")), "", dtDireccion.Rows(iFila).Item("lote"))
                        iId_Nivel = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("id_nivel")), 0, dtDireccion.Rows(iFila).Item("id_nivel"))
                        sNivel = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("nivel")), "", dtDireccion.Rows(iFila).Item("nivel"))
                        iId_Zona = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("id_zona")), 0, dtDireccion.Rows(iFila).Item("id_zona"))
                        sZona = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("zona")), "", dtDireccion.Rows(iFila).Item("zona"))
                        iId_Clasificacion = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("id_clasificacion")), 0, dtDireccion.Rows(iFila).Item("id_clasificacion"))
                        sClasificacion = IIf(IsDBNull(dtDireccion.Rows(iFila).Item("clasificacion")), "", dtDireccion.Rows(iFila).Item("clasificacion"))

                        If Me.CboContacto.Enabled Then
                            iFila = Me.CboContacto.SelectedIndex
                            iTipo2 = IIf(IsDBNull(dtContacto.Rows(iFila).Item("idtipo_documento_contacto")), 0, dtContacto.Rows(iFila).Item("idtipo_documento_contacto"))
                            sNumero3 = IIf(IsDBNull(dtContacto.Rows(iFila).Item("nrodocumento")), "", dtContacto.Rows(iFila).Item("nrodocumento"))
                            sContacto = IIf(IsDBNull(dtContacto.Rows(iFila).Item("nombres")), "", dtContacto.Rows(iFila).Item("nombres"))
                            sNombresCont = IIf(IsDBNull(dtContacto.Rows(iFila).Item("nombre")), "", dtContacto.Rows(iFila).Item("nombre")) 'new
                            sApCont = IIf(IsDBNull(dtContacto.Rows(iFila).Item("apepat")), "", dtContacto.Rows(iFila).Item("apepat"))
                            sAmCont = IIf(IsDBNull(dtContacto.Rows(iFila).Item("apemat")), "", dtContacto.Rows(iFila).Item("apemat"))
                            If sContacto.Trim.Substring(0, 1) = "(" Then
                                sContacto = ""
                            End If
                            bEsCliente = Me.ChkCliente1.Checked
                        End If

                        If Me.CboRemitente.Enabled Then
                            iFila = Me.CboRemitente.SelectedIndex
                            iTipo3 = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("idtipo_documento_contacto")), 0, dtRemitente.Rows(iFila).Item("idtipo_documento_contacto"))
                            sNroDocRemitente = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("nrodocumento")), "", dtRemitente.Rows(iFila).Item("nrodocumento"))
                            sRemitente = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("nombres")), "", dtRemitente.Rows(iFila).Item("nombres"))
                            sNombresRemitente = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("nombre")), "", dtRemitente.Rows(iFila).Item("nombre")) 'new
                            sAp = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("apepat")), "", dtRemitente.Rows(iFila).Item("apepat"))
                            sAm = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("apemat")), "", dtRemitente.Rows(iFila).Item("apemat"))
                            If sRemitente.Trim.Substring(0, 1) = "(" Then
                                sRemitente = ""
                            End If
                            bEsCliente2 = Me.ChkCliente.Checked
                        End If
                    End If
                    bEsCliente = Me.ChkCliente1.Checked
                    bEsCliente2 = Me.ChkCliente.Checked
                End If
            End If

            frm.cargar(sNumero, sRazonSocialCliente, iTipo, sNombresCli, sApCli, sAmCli, iDepartamento, iProvincia, iDistrito, iId_via, sVia, sNumero2, _
                       sManzana, sLote, iId_Nivel, sNivel, iId_Zona, sZona, iId_Clasificacion, _
                       sClasificacion, iTipo2, sNumero3, sContacto, sNombresCont, sApCont, sAmCont, sTelfCliente, bEsCliente, bEsCliente2, sNombresCli, _
                       sApCli, sAmCli, sTelfCliente, iTipo3, sNroDocRemitente, sRemitente, sNombresRemitente, sAp, sAm, sEmail, bClienteCredito)

            frm.bClienteNuevo = bClienteNuevo
            frm.GrbContacto.Text = IIf(Me.CboTipo.SelectedValue = 2, "Contacto", "Facturar a")
            '04092011
            frm.iTipoVenta = IIf(Me.CboTipo.SelectedValue = TipoVenta.Credito, TipoVenta.Credito, TipoVenta.Contado)
            frm.bRemitenteNuevo = IIf(idRemitente > 0, False, True)
            frm.bContactoNuevo = IIf(idcontacto > 0, False, True)
            frm.ShowDialog()
            Me.Cursor = Cursors.Default
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                'If CboTipo.SelectedValue = 2 Then
                '    'ds = obj.BuscarClienteCredito(frm.TxtNumero.Text, 1, dtoUSUARIOS.m_idciudad, idUnidadAgencias)
                '    'dtCliente = ds.Tables(0)
                '    'Me.MostrarClienteCredito(ds)
                '    'ChkCliente.Checked = True
                '    'ChkCliente1.Checked = True
                'Else
                Me.Cursor = Cursors.AppStarting
                Me.CargarCliente(frm)
                'End If

                'hlamas 12-02-2014
                If TipoGrid_ = FormatoGrid.BULTO Then
                    fnTotalPago()
                ElseIf TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                    Calculo_M3()
                End If

                'hlamas 13-03-2014
                ClienteProducto(iID_Persona, Me.CboSubCuenta.SelectedValue, dtoUSUARIOS.m_idciudad, idUnidadAgencias)

                'hlamas 24-02-2014
                ClientePersonalizado(iID_Persona)

                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '****NRO DOCUMENTO******
    Dim sDocCliente As String = ""
    Dim s_persona_remitente As String = ""
    Dim flagPCEVALIDADOC As Boolean = False   
    Private Sub TxtNroDocCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNroDocCliente.TextChanged
        Try
            If CboTipo.SelectedValue = 1 Or CboTipo.SelectedValue = 2 Then '---> Contado
                RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                'hlamas 01-10-2013
                Me.CargarSubcuentaOrigen(ObjVentaCargaContado.v_IDPERSONA, objGuiaEnvio.iIDUNIDAD_AGENCIA)
                Me.CargarSubcuentaDestino(ObjVentaCargaContado.v_IDPERSONA, objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO)

                If CboProducto.SelectedValue <> 6 Then
                    If FnExisteCliente() = False Then '                       
                        Me.LimpiarDatosCliente()
                        'Me.RefreshNroDocumento(0)
                        '**************************************             
                        TarifaPublica_ = True
                        bTieneLineaCredito = False
                        bDescuento = False
                        If CboProducto.SelectedValue = 7 Then CboProducto.SelectedValue = 0

                        '-->consulta tarifario solo cuando el tip es crédito
                        If (CboTipo.SelectedValue = ID_TIPO_CREDITO) Then fnTarifario()


                        '**************************************
                        If CboProducto.SelectedValue <> 6 Then
                            TxtCiudadDestino.ReadOnly = False
                            TxtCiudadDestino.Enabled = True
                        End If

                        If fnVALIDARDOCUMENTOS() Then
                        End If
                    Else
                        sDocCliente = ""
                        If CboProducto.SelectedValue <> 6 Then
                            TxtCiudadDestino.ReadOnly = False
                            TxtCiudadDestino.Enabled = True
                        End If
                        '-->consulta tarifario solo cuando el tip es crédito
                        If (CboTipo.SelectedValue = ID_TIPO_CREDITO) Then fnTarifario()

                        'hlamas 20-09-2013 si se ingresa un cliente pyme actualiza la tarifa
                        If CboProducto.SelectedValue = 7 Then fnTarifario()
                    End If
                Else
                    sDocCliente = ""
                    If Me.ChkCliente2.Checked Then
                        RemoveHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
                        Me.ChkCliente2.Checked = False
                        AddHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
                    End If
                End If
                AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            ElseIf CboTipo.SelectedValue = 2 Then '---> Credito
                'If TxtNroDocCliente.Text = "" Then
                '    Me.LimpiarDatosCliente()
                '    TxtNomCliente.Text = ""
                'End If
                CONTROL = 2
                bControl_Busqueda = True
                Me.fb_buscar_cliente()
            End If

            'hlamas 24-02-2014
            'If Me.CboTipo.SelectedValue = 2 Then
            Me.TxtCiudadDestino.Enabled = True
            Me.CboTipoEntrega.Enabled = True
            Me.CboDireccion2.Enabled = True
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function ExisteEsElCliente(ByVal numero As String, ByVal cbo As ComboBox, ByVal dt As DataTable, ByVal campo As String, ByVal campo2 As String) As Integer
        Dim sNumero As String
        For i As Integer = 1 To dt.Rows.Count - 1
            sNumero = IIf(IsDBNull(dt.Rows(i).Item(campo)), "", dt.Rows(i).Item(campo))
            If numero.Trim = sNumero.Trim Then
                Return dt.Rows(i).Item(campo2)
            End If
        Next
        Return 0
    End Function

    'FUNCION BUSCAR (CLIENTE)    
    Sub Buscar(Optional ByVal opcion As Integer = 0)
        Try
            Me.Cursor = Cursors.AppStarting
            Dim iOpcion As Integer = IIf(Me.RbtDocumento.Checked, 1, 2)
            Dim frm As New FrmCliente3
            Dim scliente As String = IIf(opcion = 0, Me.TxtCliente.Text.Trim, Me.TxtNroDocCliente.Text)
            Dim iCliente As Integer
            Dim obj As New dtoVentaCargaContado
            Dim ds As DataSet = obj.Buscar(scliente, iOpcion, dtoUSUARIOS.m_idciudad, idUnidadAgencias)
            Dim bClienteExisteCA As Boolean = False
            If bInicioCargaAcompañada Then
                If ds.Tables(0).Rows(0).Item(0).ToString <> "" Then '06092011
                    'If ds.Tables(0).Rows.Count > 0 Then
                    bClienteExisteCA = True
                    'dtCliente = ds.Tables(0)
                    If ds.Tables(0).Rows(0).Item("ap").ToString.Trim <> "" Then 'Agregado Cambio
                        dtCliente = ds.Tables(0)
                    End If
                    'Me.ChkCliente2.Checked=False
                Else
                    InicializarDT() '06092011 habilitado
                    'dtCliente = ds.Tables(0)'Comentado en Observacion (No existe el cliente de CA no deberia tomar ds.tables)
                End If
            Else
                dtCliente = ds.Tables(0)
            End If
            bClienteNuevo = True

            If IsDBNull(dtCliente.Rows(0).Item(0)) Then
                If Not bInicioCargaAcompañada Then
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("El Cliente no Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frm = New FrmCliente3
                    frm.bClienteNuevo = bClienteNuevo
                    bClienteCredito = False
                    frm.iFicha = 1
                    frm.TxtNumero.Text = IIf(RbtDocumento.Checked, scliente.Trim, "") '22092011 Agregado ayuda nroDocumento
                    frm.ShowDialog()
                    If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                        Me.LimpiarCliente()
                        CargarCliente(frm)
                    End If
                End If
                'ElseIf (ds.Tables(0).Rows.Count = 1 And Not bBoleto) Or (bBoleto And bClienteExisteCA) Then
            ElseIf (ds.Tables(0).Rows.Count = 1 And Not bInicioCargaAcompañada) Or (bInicioCargaAcompañada And bClienteExisteCA And ds.Tables(0).Rows.Count = 1) Then
                Me.Mostrar(ds)
                ChkCliente.Checked = True
                ChkCliente1.Checked = True
            Else 'If Not bInicioCargaAcompañada Then
                frm.bClienteNuevo = bClienteNuevo
                frm = New FrmCliente3
                frm.iFicha = 0

                frm.cargar(ds.Tables(0), 2)
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    If frm.bClienteNuevo Then
                        CargarCliente(frm)
                    Else
                        ds = obj.Buscar(frm.TxtNumero.Tag, 3, dtoUSUARIOS.m_idciudad, idUnidadAgencias)
                        dtCliente = ds.Tables(0)
                        If IsDBNull(dtCliente.Rows(0).Item(0)) Then
                            If Not bInicioCargaAcompañada Then
                                Me.Cursor = Cursors.Default
                                MessageBox.Show("El Cliente no Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                frm = New FrmCliente3
                                frm.bClienteNuevo = bClienteNuevo
                                bClienteCredito = False
                                frm.iFicha = 1
                                frm.TxtNumero.Text = IIf(RbtDocumento.Checked, scliente.Trim, "") '22092011 Agregado ayuda nroDocumento
                                frm.ShowDialog()
                                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                                    Me.LimpiarCliente()
                                    CargarCliente(frm)
                                End If
                            End If
                        Else
                            Me.Mostrar(ds)
                            ChkCliente.Checked = True
                            ChkCliente1.Checked = True
                        End If
                    End If
                End If
            End If
            sDocCliente = TxtCliente.Text.Trim

            'hlamas 14-02-2019
            ClienteProducto(iID_Persona, 999, dtoUSUARIOS.m_idciudad, idUnidadAgencias)

            'hlamas 15-11-2013
            'Tarifa Entrega a Domicilio
            GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, dtoUSUARIOS.m_idciudad, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            Throw New Exception
        End Try
    End Sub

    Sub InicializarDT()
        '****REMITENTE***
        Dim dr As DataRow
        Me.CboRemitente.DataSource = Nothing
        Me.CboRemitente.Items.Clear()
        dtRemitente = New DataTable
        dtRemitente.Columns.Add(New DataColumn("idcontacto_persona", GetType(Integer)))
        dtRemitente.Columns.Add(New DataColumn("nombres", GetType(String)))
        dtRemitente.Columns.Add(New DataColumn("nombre", GetType(String))) 'new
        dtRemitente.Columns.Add(New DataColumn("idtipo_documento_contacto", GetType(Integer)))
        dtRemitente.Columns.Add(New DataColumn("nrodocumento", GetType(String)))
        dtRemitente.Columns.Add(New DataColumn("apepat", GetType(String)))
        dtRemitente.Columns.Add(New DataColumn("apemat", GetType(String)))

        dr = dtRemitente.NewRow
        dr("idcontacto_persona") = 0
        dr("nombres") = " (SELECCIONE)"
        dr("idtipo_documento_contacto") = 0
        dr("nrodocumento") = ""
        dtRemitente.Rows.Add(dr)
        dtRemitenteParalelo = dtRemitente.Copy

        Me.CboRemitente.DataSource = dtRemitente
        CboRemitente.DisplayMember = "nombres"
        CboRemitente.ValueMember = "idcontacto_persona"
        Me.CboRemitente.SelectedIndex = IIf(dtRemitente.Rows.Count > 1, 1, 0)

        '*****CONTACTO*****
        Me.CboContacto.DataSource = Nothing
        Me.CboContacto.Items.Clear()
        dtContacto = New DataTable
        dtContacto.Columns.Add(New DataColumn("idcontacto_persona", GetType(Integer)))
        dtContacto.Columns.Add(New DataColumn("nombres", GetType(String)))
        dtContacto.Columns.Add(New DataColumn("nombre", GetType(String))) 'new
        dtContacto.Columns.Add(New DataColumn("idtipo_documento_contacto", GetType(Integer)))
        dtContacto.Columns.Add(New DataColumn("nrodocumento", GetType(String)))
        dtContacto.Columns.Add(New DataColumn("apepat", GetType(String)))
        dtContacto.Columns.Add(New DataColumn("apemat", GetType(String)))

        dr = dtContacto.NewRow
        dr("idcontacto_persona") = 0
        dr("nombres") = " (SELECCIONE)"
        dr("idtipo_documento_contacto") = 0
        dr("nrodocumento") = ""
        dtContacto.Rows.Add(dr)
        dtContactoParalelo = dtContacto.Copy

        Me.CboContacto.DataSource = dtContacto
        CboContacto.DisplayMember = "nombres"
        CboContacto.ValueMember = "idcontacto_persona"
        Me.CboContacto.SelectedIndex = IIf(dtContacto.Rows.Count > 1, 1, 0)
    End Sub

    Dim iID_Persona As Integer
    Sub Mostrar(ByVal ds As DataSet)
        'hlamas 21-01-2016
        ChkArticulos.Tag = Nothing
        bClienteNuevo = False
        Me.LimpiarDatosCliente()

        '**linea de credito**   
        If ds.Tables(4).Rows.Count > 0 Then
            If CType(ds.Tables(4).Rows(0)("ES_ACTIVO"), Boolean) Then
                bTieneLineaCredito = True
            Else
                bTieneLineaCredito = False
            End If
        Else
            bTieneLineaCredito = False
        End If

        If (dtCliente.Rows(0).Item("Cliente_Corporativo")) = 1 Then
            bClienteCredito = True
        Else
            bClienteCredito = False
        End If
        '**Articulos**
        DtArticulos = ds.Tables(5).Copy
        If ds.Tables(5).Rows.Count > 0 Then
            '18/11/2011
            'Base Articulo
            iBaseArticulo = ds.Tables(5).Rows(0).Item("base")
            ChkArticulos.Enabled = True
            'hlamas 21-01-2016
            ChkArticulos.Tag = 1
        Else
            ChkArticulos.Enabled = False : ChkArticulos.Checked = False
        End If

        '**Descuento****
        If CboProducto.SelectedValue <> 6 Then '-->Diferente De Carga Acompañada
            iDescuento = IIf(ds.Tables(6).Rows(0)("porcentage_descuento") <> 0, ds.Tables(6).Rows(0)("porcentage_descuento"), 0)
            If iDescuento <> 0 Then
                iDescuento = iDescuento / 100
                bDescuento = True
            Else
                bDescuento = False
            End If
        End If

        '******************************************************
        iID_Persona = ds.Tables(0).Rows(0).Item("idpersona")
        Dim iProceso As Integer = ds.Tables(0).Rows(0).Item("id_proceso")
        'hlamas 17-07-2015
        If Me.CboProducto.SelectedValue = 10 Then
            iProceso = 10
        ElseIf CboProducto.SelectedValue = 81 Then
            iProceso = 81
        ElseIf CboProducto.SelectedValue = 82 Then
            iProceso = 82
        End If
        '******************************************************
        If CboTipo.SelectedValue <> 2 Then ' Solo contado
            RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            If iProceso = 0 Then '------> Normal Or (iProceso = 7 And ds.Tables(0).Rows(0).Item("codigo_cliente") <> TxtCliente.Text.Trim)
                objGuiaEnvio.TarifaPyme_ = False
                If CboProducto.SelectedValue = 6 Then
                    Me.CboProducto.SelectedValue = 6
                ElseIf CboProducto.SelectedValue = 8 Then 'And bTieneLineaCredito = False Then
                    Me.CboProducto.SelectedValue = 8
                ElseIf CboProducto.SelectedValue = 81 Then
                    Me.CboProducto.SelectedValue = 81
                ElseIf CboProducto.SelectedValue = 82 Then
                    Me.CboProducto.SelectedValue = 82
                Else
                    Me.CboProducto.SelectedValue = iProceso
                End If
                'Me.RefreshNroDocumento(0)
            ElseIf iProceso = 7 Then '--> Pyme  
                If CboProducto.SelectedValue = 6 Then
                    Me.CboProducto.SelectedValue = 6
                Else
                    Me.CboProducto.SelectedValue = iProceso
                    Me.CondicionMontoMinimoPYME() '--Monto Minimo 04022012
                End If
                Me.objGuiaEnvio.TarifaPyme_ = True '--> indica q traera tarifa Pyme                                      
                'Me.RefreshNroDocumento(7)
            ElseIf iProceso = 8 Then '--> Masiva
                objGuiaEnvio.TarifaPyme_ = False
                Me.CboProducto.SelectedValue = iProceso
                objGuiaEnvio.TarifaMasiva_ = True
                'Me.RefreshNroDocumento(8)
            ElseIf iProceso = 10 Then '------> Normal Or (iProceso = 7 And ds.Tables(0).Rows(0).Item("codigo_cliente") <> TxtCliente.Text.Trim)
                objGuiaEnvio.TarifaPyme_ = False
                If CboProducto.SelectedValue = 6 Then
                    Me.CboProducto.SelectedValue = 6
                ElseIf CboProducto.SelectedValue = 8 Then 'And bTieneLineaCredito = False Then
                    Me.CboProducto.SelectedValue = 8
                Else
                    Me.CboProducto.SelectedValue = iProceso
                End If
                'Me.RefreshNroDocumento(0)
            ElseIf iProceso = 81 Or iProceso = 82 Then
                objGuiaEnvio.TarifaPyme_ = False
                objGuiaEnvio.TarifaMasiva_ = False
                objGuiaEnvio.TarifaBox_ = True
                Me.CboProducto.SelectedValue = iProceso
                'Me.RefreshNroDocumento(0)
            End If
            AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
        End If
        '********************************************************

        'Me.TxtNroDocCliente.Tag = ds.Tables(0).Rows(0).Item("idpersona")
        Me.TxtNroDocCliente.Text = ds.Tables(0).Rows(0).Item("nu_docu_suna").ToString.Trim
        Me.TxtNomCliente.Text = ds.Tables(0).Rows(0).Item("razon_social").ToString.Trim
        Me.TxtTelfCliente.Text = IIf(IsDBNull(dtCliente.Rows(0).Item("telefono")), "", dtCliente.Rows(0).Item("telefono"))
        sEmail = IIf(IsDBNull(dtCliente.Rows(0).Item("Email")), "", dtCliente.Rows(0).Item("Email")) '07092011
        '--recuperando datos cliente--
        sNombresCli = IIf(IsDBNull(dtCliente.Rows(0).Item("nombres")), "", dtCliente.Rows(0).Item("nombres"))
        sApCli = IIf(IsDBNull(dtCliente.Rows(0).Item("ap")), "", dtCliente.Rows(0).Item("ap"))
        sAmCli = IIf(IsDBNull(dtCliente.Rows(0).Item("am")), "", dtCliente.Rows(0).Item("am"))
        sTelfCliente = IIf(IsDBNull(dtCliente.Rows(0).Item("telefono")), "", dtCliente.Rows(0).Item("telefono"))
        sRazonSocialCliente = IIf(IsDBNull(dtCliente.Rows(0).Item("razon_social")), "", dtCliente.Rows(0).Item("razon_social"))
        iID_TipoDocCli = ds.Tables(0).Rows(0).Item("tipo").ToString.Trim

        With Me.CboDireccion
            dtDireccion = ds.Tables(1)
            .DataSource = dtDireccion
            .DisplayMember = "direccion"
            .ValueMember = "iddireccion_consignado"

            If .Items.Count > 2 Then
                .SelectedIndex = 0
                .DroppedDown = True
                .Focus()
                Me.Cursor = Cursors.Default
            ElseIf .Items.Count = 1 Then
                .SelectedIndex = 0
                .Focus()
            Else
                .SelectedIndex = 1
                IdDireccionOrigen = CboDireccion.SelectedValue
                .Focus()
            End If
        End With

        With Me.CboDireccion2
            dtDireccion2 = ds.Tables(2)
            .DataSource = dtDireccion2
            .DisplayMember = "direccion"
            .ValueMember = "iddireccion_consignado"
            If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                If .Items.Count > 2 Then
                    .SelectedIndex = 0
                    '.DroppedDown = True
                    '.Focus()
                    Me.Cursor = Cursors.Default
                ElseIf .Items.Count = 1 Then
                    .SelectedIndex = 0
                Else
                    .SelectedIndex = 1
                End If
            Else
                '01092011
                Me.ConvertirTipoEntrega(Me.CboTipoEntrega.SelectedValue)
            End If
        End With

        'RemoveHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
        With Me.CboContacto
            dtContacto = ds.Tables(3)
            dtContactoParalelo = ds.Tables(3).Copy
            .DataSource = dtContacto
            .DisplayMember = "nombres"
            .ValueMember = "idcontacto_persona"
            If .Items.Count > 2 Then
                .SelectedIndex = 0
            ElseIf .Items.Count = 1 Then
                .SelectedIndex = 0
            Else
                .SelectedIndex = 1
            End If
            Me.ChkCliente1.Tag = DBNull.Value
        End With

        With Me.CboRemitente
            dtRemitente = ds.Tables(3).Copy
            dtRemitenteParalelo = ds.Tables(3).Copy
            .DataSource = dtRemitente
            .DisplayMember = "nombres"
            .ValueMember = "idcontacto_persona"
            If .Items.Count > 2 Then
                .SelectedIndex = 0
            ElseIf .Items.Count = 1 Then
                .SelectedIndex = 0
            Else
                .SelectedIndex = 1
            End If
            Me.ChkCliente.Tag = DBNull.Value
        End With

        ' AddHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged

        If TipoComprobante = 1 Then
            CboContacto.Enabled = True
            ChkCliente1.Enabled = True
        End If

        If Me.CboProducto.SelectedValue <> 6 Then  'solo aplica para tepsa encomiendas y tepsa courier office
            'hlamas 22-03-2016
            'verifica si cliente tiene devolucion de cargo por defecto
            Dim obj As New Cls_ClienteCargo_LN
            Dim intTipo As Integer = 2
            Dim intDevCargo As Integer = obj.DevolucionCargo(intTipo, iID_Persona)
            If intDevCargo >= 1 Then
                If Me.chkDocumentoCliente.Checked = False Then
                    Me.chkDocumentoCliente.Checked = True
                    Me.rbtCargoSi.Checked = True
                Else
                    If Me.rbtCargoSi.Checked = False Then
                        Me.rbtCargoSi.Checked = True
                    End If
                End If
            Else
                If Me.chkDocumentoCliente.Checked Then
                    Me.chkDocumentoCliente.Checked = False
                End If
            End If
        End If
        '----------------------------------------------------------

        '01/09/2011
        'Informa si el cliente tiene crédito y va a emitir PCE
        If Me.CboTipo.SelectedValue = 1 AndAlso bTieneLineaCredito Then
            If iID_Persona = ID_PERSONA_SANROQUE Then
                Dim sNumeroDocumento As String = Me.TxtNroDocCliente.Text.Trim
                Me.CboTipo.SelectedValue = 2
                Me.RbtDocumento.Checked = True
                Me.TxtCliente.Text = sNumeroDocumento
                Me.BuscarClienteCredito()
            Else
                If iID_Persona <> ID_PERSONA_PESQUERA Then
                    Dim sMje As String
                    sMje = "El Cliente tiene Línea de Crédito." & vbCrLf
                    sMje &= "¿Está Seguro de Emitir un Pago Contraentrega?"
                    Dim dlgRespuesta As DialogResult
                    dlgRespuesta = MessageBox.Show(sMje, "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If dlgRespuesta = Windows.Forms.DialogResult.No Then
                        Dim sNumeroDocumento As String = Me.TxtNroDocCliente.Text.Trim
                        Me.CboTipo.SelectedValue = 2
                        Me.RbtDocumento.Checked = True
                        Me.TxtCliente.Text = sNumeroDocumento
                        Me.BuscarClienteCredito()
                    End If
                Else
                    Dim sNumeroDocumento As String = Me.TxtNroDocCliente.Text.Trim
                    Me.CboTipo.SelectedValue = 2
                    Me.RbtDocumento.Checked = True
                    Me.TxtCliente.Text = sNumeroDocumento
                    Me.BuscarClienteCredito()
                End If
            End If
        End If
        'hlamas 21-01-2016
        fnTarifario()

        '-->10/09/2013 ajabanto - Implemetación de la funcionalidad del DT(Documento de transporte) utilizado por Quimica suiza.
        '->Solo se visualiza cuando el cliente es Química Suiza
        'If Me.CboTipo.SelectedIndex = 0 Then
        '    ID_PERSONA_QUIMICA_SUIZA = -10
        'Else
        '    ID_PERSONA_QUIMICA_SUIZA = 1290
        'End If

        'txtdt.Clear()
        'lbldt.Visible = (iID_Persona = ID_PERSONA_QUIMICA_SUIZA And objGuiaEnvio.iIDUNIDAD_AGENCIA = 5100)
        'txtdt.Visible = (iID_Persona = ID_PERSONA_QUIMICA_SUIZA And objGuiaEnvio.iIDUNIDAD_AGENCIA = 5100)
        'TxtTelfCliente.Size = IIf(iID_Persona = ID_PERSONA_QUIMICA_SUIZA, New Size(120, 20), New Size(329, 20))
        'IIf(iID_Persona = ID_PERSONA_QUIMICA_SUIZA, txtdt.Focus, TxtConsignado.Focus)

        'hlamas 07-02-2019
        If Me.CboTipo.SelectedIndex = 0 Then
            ID_PERSONA_CBC = -10
        Else
            ID_PERSONA_CBC = 2153948
        End If

        txtdt.Clear()
        lbldt.Visible = (iID_Persona = ID_PERSONA_CBC And objGuiaEnvio.iIDUNIDAD_AGENCIA = 5100)
        txtdt.Visible = (iID_Persona = ID_PERSONA_CBC And objGuiaEnvio.iIDUNIDAD_AGENCIA = 5100)
        Me.dtpFechaRecojo.Visible = (iID_Persona = ID_PERSONA_CBC And objGuiaEnvio.iIDUNIDAD_AGENCIA = 5100)
        TxtTelfCliente.Size = IIf(iID_Persona = ID_PERSONA_CBC, New Size(86, 20), New Size(329, 20))
        IIf(iID_Persona = ID_PERSONA_CBC, txtdt.Focus, TxtConsignado.Focus)
    End Sub

    Dim bClienteModificado, bDireccionModificada, bContactoModificado, bRemitenteModificado As Boolean
    Dim NombresCliente, apellPatCli, apellMatCli, TelfCliente As String '--------------->cliente
    Dim NombresCont, apellPatCont, apellMatCont As String '----------------------------->contacto
    Dim iID_TipoDocCont As Integer = 0
    'distrito
    Dim iDepartamentoCli, iProvinciaCli, iDistritoCli, IDviaCli, id_NivelCli, id_ZonaCli, id_ClasificacionCli, FormatoCli As Integer
    Dim ViaCli, ManzanaCli, loteCli, NivelCli, ZonaCli, NroCli, ClasificacionCli As String
    Private Sub CargarCliente(ByVal frm As FrmCliente3)

        RemoveHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
        RemoveHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
        Me.TxtNroDocCliente.Text = frm.TxtNumero.Text
        AddHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged

        Me.TxtNomCliente.Text = frm.TxtCliente.Text & " " & frm.TxtAPCliente.Text & " " & frm.TxtAMCliente.Text
        Me.TxtTelfCliente.Text = frm.txtTelefono.Text
        '--
        bClienteModificado = frm.bClienteModificado
        bDireccionModificada = frm.bDireccionModificada
        bContactoModificado = frm.bContactoModificado
        bRemitenteModificado = frm.bRemitenteModificado
        '--
        '-----datos cliente-------------------------  
        iID_TipoDocCli = frm.CboTipoDocumento.SelectedValue
        If iID_TipoDocCli = 1 Then
            sRazonSocialCliente = frm.TxtCliente.Text
            sNombresCli = ""
        Else
            sRazonSocialCliente = frm.TxtCliente.Text
            sNombresCli = frm.TxtCliente.Text
        End If
        sApCli = frm.TxtAPCliente.Text
        sAmCli = frm.TxtAMCliente.Text
        sTelfCliente = frm.txtTelefono.Text
        sEmail = frm.TxtEmail.Text.Trim '07092011

        '---------------------------------------------
        RemoveHandler CboDireccion.SelectedIndexChanged, AddressOf CboDireccion_SelectedIndexChanged
        RemoveHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
        If frm.TabCliente.SelectedIndex = 0 Then
            Me.TxtNroDocCliente.Text = frm.TxtNumero.Text.Trim
            Dim obj As New dtoVentaCargaContado
            ' Dim obj As New dtoGuiaEnvio
            Dim ds As DataSet = obj.Buscar(frm.TxtNumero.Text, 1, dtoUSUARIOS.m_idciudad, idUnidadAgencias)
            ' Dim ds As DataSet = obj.BuscarClienteCredito(frm.TxtNumero.Text, 1, dtoUSUARIOS.m_idciudad, idUnidadAgencias, objGuiaEnvio.iIDCENTRO_COSTO)
            dtCliente = ds.Tables(0)
            Me.Mostrar(ds)
            Me.ChkCliente.Checked = True
            Me.ChkCliente1.Checked = True
        ElseIf frm.TabCliente.SelectedIndex = 1 Then
            Dim dr As DataRow
            'cliente
            dtCliente = New DataTable
            dtCliente.Columns.Add(New DataColumn("idpersona", GetType(Integer)))
            dtCliente.Columns.Add(New DataColumn("razon_social", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("tipo", GetType(Integer)))
            dtCliente.Columns.Add(New DataColumn("nu_docu_suna", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("nombres", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("ap", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("am", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("telefono", GetType(String)))
            dtCliente.Columns.Add(New DataColumn("Email", GetType(String)))
            'hlamas 01/08/2015
            dtCliente.Columns.Add(New DataColumn("idtipo_facturacion", GetType(Integer)))

            dr = dtCliente.NewRow
            dr("idpersona") = 0
            dr("razon_social") = frm.TxtCliente.Text & " " & frm.TxtAPCliente.Text & " " & frm.TxtAMCliente.Text
            dr("tipo") = frm.CboTipoDocumento.SelectedValue
            dr("nu_docu_suna") = frm.TxtNumero.Text.Trim
            dr("nombres") = frm.TxtCliente.Text.Trim
            dr("ap") = frm.TxtAPCliente.Text.Trim
            dr("am") = frm.TxtAMCliente.Text.Trim
            dr("telefono") = frm.txtTelefono.Text.Trim
            dr("Email") = frm.TxtEmail.Text.Trim
            'hlamas 01/08/2015
            dr("idtipo_facturacion") = 0
            dtCliente.Rows.Add(dr)

            If frm.bDireccionModificada Or dtDireccion Is Nothing Then
                Me.CboDireccion.DataSource = Nothing
                Me.CboDireccion.Items.Clear()

                dtDireccion = New DataTable
                dtDireccion.Columns.Add(New DataColumn("iddireccion_consignado", GetType(Integer)))
                dtDireccion.Columns.Add(New DataColumn("direccion", GetType(String)))
                dtDireccion.Columns.Add(New DataColumn("id_via", GetType(Integer)))
                dtDireccion.Columns.Add(New DataColumn("via", GetType(String)))
                dtDireccion.Columns.Add(New DataColumn("numero", GetType(String)))
                dtDireccion.Columns.Add(New DataColumn("manzana", GetType(String)))
                dtDireccion.Columns.Add(New DataColumn("lote", GetType(String)))
                dtDireccion.Columns.Add(New DataColumn("id_nivel", GetType(Integer)))
                dtDireccion.Columns.Add(New DataColumn("nivel", GetType(String)))
                dtDireccion.Columns.Add(New DataColumn("id_zona", GetType(Integer)))
                dtDireccion.Columns.Add(New DataColumn("zona", GetType(String)))
                dtDireccion.Columns.Add(New DataColumn("id_clasificacion", GetType(Integer)))
                dtDireccion.Columns.Add(New DataColumn("clasificacion", GetType(String)))
                dtDireccion.Columns.Add(New DataColumn("iddepartamento", GetType(Integer)))
                dtDireccion.Columns.Add(New DataColumn("idprovincia", GetType(Integer)))
                dtDireccion.Columns.Add(New DataColumn("iddistrito", GetType(Integer)))

                dr = dtDireccion.NewRow
                dr("iddireccion_consignado") = 0
                dr("direccion") = " (SELECCIONE)"
                dr("id_via") = 0
                dr("via") = ""
                dr("numero") = ""
                dr("manzana") = ""
                dr("lote") = ""
                dr("id_nivel") = 0
                dr("nivel") = ""
                dr("id_zona") = 0
                dr("zona") = ""
                dr("id_clasificacion") = 0
                dr("clasificacion") = ""
                dr("iddepartamento") = 0
                dr("idprovincia") = 0
                dr("iddistrito") = 0
                dtDireccion.Rows.Add(dr)

                If frm.bDireccionModificada Then
                    '------datos direccion estructurada---------                
                    iDepartamentoCli = frm.CboDepartamento.SelectedValue
                    iProvinciaCli = frm.CboProvincia.SelectedValue
                    iDistritoCli = frm.CboDistrito.SelectedValue
                    IDviaCli = frm.CboVia.SelectedValue
                    ViaCli = frm.TxtVia.Text
                    NroCli = frm.TxtNumero2.Text
                    ManzanaCli = frm.TxtManzana.Text
                    loteCli = frm.TxtLote.Text
                    id_NivelCli = frm.CboNivel.SelectedValue
                    NivelCli = frm.TxtNivel.Text
                    id_ZonaCli = frm.CboZona.SelectedValue
                    ZonaCli = frm.TxtZona.Text
                    id_ClasificacionCli = frm.CboClasificacion.SelectedValue
                    ClasificacionCli = frm.TxtClasificacion.Text


                    FormatoCli = 1

                    'Dirección
                    'Dim sDireccion As String = frm.CboVia.Text & " " & frm.TxtVia.Text.Trim & " "
                    Dim sDireccion As String = IIf(frm.CboVia.SelectedValue = 0, "", frm.CboVia.Text) & " " & IIf(frm.CboVia.SelectedValue = 0, "", frm.TxtVia.Text.Trim) & " " 'Cambio 03102011
                    'sDireccion = Trim(sDireccion)

                    If frm.CboVia.SelectedValue > 0 And frm.TxtNumero2.Text.Trim.Length > 0 Then
                        sDireccion &= frm.TxtNumero2.Text.Trim & " "
                    End If

                    If frm.TxtManzana.Text.Trim.Length > 0 Then
                        sDireccion &= "MZ " & frm.TxtManzana.Text.Trim & " LT " & frm.TxtLote.Text.Trim & " "
                    End If

                    If frm.CboNivel.SelectedValue > 0 Then
                        sDireccion &= frm.CboNivel.Text & " " & frm.TxtNivel.Text.Trim & " "
                    End If

                    If frm.CboZona.SelectedValue > 0 Then
                        sDireccion &= frm.CboZona.Text & " " & frm.TxtZona.Text.Trim & " "
                    End If

                    If frm.CboClasificacion.SelectedValue > 0 Then
                        sDireccion &= frm.CboClasificacion.Text & " " & frm.TxtClasificacion.Text.Trim & " "
                    End If

                    If frm.CboDistrito.SelectedValue > 0 Then
                        sDireccion &= frm.CboDistrito.Text
                    End If


                    dr = dtDireccion.NewRow
                    dr("iddireccion_consignado") = -1
                    dr("direccion") = sDireccion.Trim
                    dr("id_via") = frm.CboVia.SelectedValue
                    dr("via") = frm.TxtVia.Text.Trim
                    dr("numero") = frm.TxtNumero2.Text.Trim
                    dr("manzana") = frm.TxtManzana.Text.Trim
                    dr("lote") = frm.TxtLote.Text.Trim
                    dr("id_nivel") = frm.CboNivel.SelectedValue
                    dr("nivel") = frm.TxtNivel.Text.Trim
                    dr("id_zona") = frm.CboZona.SelectedValue
                    dr("zona") = frm.TxtZona.Text.Trim
                    dr("id_clasificacion") = frm.CboClasificacion.SelectedValue
                    dr("clasificacion") = frm.TxtClasificacion.Text.Trim
                    dr("iddepartamento") = frm.CboDepartamento.SelectedValue
                    dr("idprovincia") = frm.CboProvincia.SelectedValue
                    dr("iddistrito") = frm.CboDistrito.SelectedValue
                    dtDireccion.Rows.Add(dr)
                End If

                Me.CboDireccion.DataSource = dtDireccion
                CboDireccion.DisplayMember = "direccion"
                CboDireccion.ValueMember = "iddireccion_consignado"
                If frm.bDireccionModificada Then
                    Me.CboDireccion.SelectedIndex = 1
                Else
                    Me.CboDireccion.SelectedIndex = 0
                End If

                '** SE INSERTA LA DIRECCION CON ESTA FUNCION*****DIEGO ZEGARRA ******31-05-2013
                'F_InsertarDireccion()
                'BuscarClienteCredito()  'REFRESH AL COMBO PARA MOSTRAR LA INSERCCION
                'If frm.bDireccionModificada Then
                '    Me.CboDireccion.SelectedIndex = 1
                'Else
                '    Me.CboDireccion.SelectedIndex = 0
                'End If
                'CboDireccion.SelectedValue = fr
                '*****************************************************************************
            End If

            If frm.bContactoModificado Or IsNothing(dtContacto) Then
                Me.CboContacto.DataSource = Nothing
                Me.CboContacto.Items.Clear()

                'Contacto
                idcontacto = 0
                iID_TipoDocCont = frm.CboDocContacto.SelectedValue
                NombresCont = frm.TxtContacto.Text.Trim
                apellPatCont = frm.TxtAPContacto.Text.Trim
                apellMatCont = frm.TxtAMContacto.Text.Trim

                'Me.TxtNroDocContacto.Text = frm.txtnrodocumento.Text.Trim
                'Me.CboContacto.DataSource = Nothing
                'Me.CboContacto.Items.Add(NombresCont & " " & apellPatCont & " " & apellMatCont)
                'Me.CboContacto.SelectedIndex = 0

                dtContacto = New DataTable
                dtContacto.Columns.Add(New DataColumn("idcontacto_persona", GetType(Integer)))
                dtContacto.Columns.Add(New DataColumn("nombres", GetType(String)))
                dtContacto.Columns.Add(New DataColumn("nombre", GetType(String))) 'new
                dtContacto.Columns.Add(New DataColumn("idtipo_documento_contacto", GetType(Integer)))
                dtContacto.Columns.Add(New DataColumn("nrodocumento", GetType(String)))
                dtContacto.Columns.Add(New DataColumn("apepat", GetType(String)))
                dtContacto.Columns.Add(New DataColumn("apemat", GetType(String)))

                dr = dtContacto.NewRow
                dr("idcontacto_persona") = 0
                dr("nombres") = " (SELECCIONE)"
                dr("idtipo_documento_contacto") = 0
                dr("nrodocumento") = ""
                dtContacto.Rows.Add(dr)

                If frm.TxtContacto.Text.Trim.Length > 0 Then
                    dr = dtContacto.NewRow
                    dr("idcontacto_persona") = idcontacto
                    dr("nombres") = NombresCont & " " & apellPatCont & " " & apellMatCont
                    dr("nombre") = NombresCont 'new                    
                    dr("idtipo_documento_contacto") = frm.CboDocContacto.SelectedValue
                    dr("nrodocumento") = frm.txtnrodocumento.Text.Trim
                    dr("apepat") = apellPatCont 'new
                    dr("apemat") = apellMatCont 'new
                    dtContacto.Rows.Add(dr)
                End If
                dtContactoParalelo = dtContacto.Copy

                AddHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
                Me.CboContacto.DataSource = dtContacto
                CboContacto.DisplayMember = "nombres"
                CboContacto.ValueMember = "idcontacto_persona"
                Me.CboContacto.SelectedIndex = IIf(dtContacto.Rows.Count > 1, 1, 0)

                RemoveHandler ChkCliente1.CheckedChanged, AddressOf ChkCliente1_CheckedChanged
                Me.ChkCliente1.Checked = frm.ChkCliente.Checked
                Me.ChkCliente1.Tag = Me.ChkCliente1.Checked
                AddHandler ChkCliente1.CheckedChanged, AddressOf ChkCliente1_CheckedChanged
            End If

            If frm.bRemitenteModificado Or IsNothing(dtRemitente) Then
                Me.CboRemitente.DataSource = Nothing
                Me.CboRemitente.Items.Clear()

                'Remitente
                idRemitente = 0
                sNroDocRemitente = frm.TxtNumeroRemitente.Text
                iID_TipoDocRemitente = frm.CboDocRemitente.SelectedValue
                sNombreRemitente = frm.TxtRemitente.Text.Trim
                sApRemitente = frm.TxtAPRemitente.Text.Trim
                sAmRemitente = frm.TxtAMRemitente.Text.Trim

                dtRemitente = New DataTable
                dtRemitente.Columns.Add(New DataColumn("idcontacto_persona", GetType(Integer)))
                dtRemitente.Columns.Add(New DataColumn("nombres", GetType(String)))
                dtRemitente.Columns.Add(New DataColumn("nombre", GetType(String))) 'new
                dtRemitente.Columns.Add(New DataColumn("idtipo_documento_contacto", GetType(Integer)))
                dtRemitente.Columns.Add(New DataColumn("nrodocumento", GetType(String)))
                dtRemitente.Columns.Add(New DataColumn("apepat", GetType(String)))
                dtRemitente.Columns.Add(New DataColumn("apemat", GetType(String)))

                dr = dtRemitente.NewRow
                dr("idcontacto_persona") = 0
                dr("nombres") = " (SELECCIONE)"
                dr("idtipo_documento_contacto") = 0
                dr("nrodocumento") = ""
                dtRemitente.Rows.Add(dr)

                If frm.TxtRemitente.Text.Trim.Length > 0 Then
                    dr = dtRemitente.NewRow
                    dr("idcontacto_persona") = -1
                    dr("nombres") = sNombreRemitente & " " & sApRemitente & " " & sAmRemitente
                    dr("nombre") = sNombreRemitente 'new                    
                    dr("idtipo_documento_contacto") = frm.CboDocRemitente.SelectedValue
                    dr("nrodocumento") = frm.TxtNumeroRemitente.Text.Trim
                    dr("apepat") = sApRemitente 'new
                    dr("apemat") = sAmRemitente 'new
                    dtRemitente.Rows.Add(dr)
                End If
                dtRemitenteParalelo = dtRemitente.Copy

                AddHandler CboRemitente.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
                Me.CboRemitente.DataSource = dtRemitente
                CboRemitente.DisplayMember = "nombres"
                CboRemitente.ValueMember = "idcontacto_persona"
                Me.CboRemitente.SelectedIndex = IIf(dtRemitente.Rows.Count > 1, 1, 0)

                RemoveHandler ChkCliente1.CheckedChanged, AddressOf ChkCliente1_CheckedChanged
                Me.ChkCliente1.Checked = frm.ChkCliente.Checked
                Me.ChkCliente1.Tag = Me.ChkCliente1.Checked
                AddHandler ChkCliente1.CheckedChanged, AddressOf ChkCliente1_CheckedChanged
            End If
            If Me.ChkCliente2.Checked Then
                Me.ChkCliente2.Checked = False
                Me.ChkCliente2.Checked = True
            End If
            'hlamas 21-01-2016
            Me.ChkArticulos.Checked = False
            Me.ChkArticulos.Tag = Nothing
            DtArticulos = dtTarifaArticuloPublico
        End If

        If TipoComprobante = 1 Then
            CboContacto.Enabled = True
            ChkCliente1.Enabled = True
            'CboContacto.SelectedIndex = 0
            'Else
            '    ChkCliente1.Enabled = False
            '    CboContacto.Enabled = False
            'CboContacto.SelectedIndex = 0
        End If
        'AddHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
        AddHandler CboDireccion.SelectedIndexChanged, AddressOf CboDireccion_SelectedIndexChanged
    End Sub

    'Public Function F_InsertarDireccion() As Integer

    '    Dim ObjInDireccionCliente_EN As New Cls_InDireccionCliente_EN
    '    lObj_InDireccionCliente_LN = New Cls_InDireccionCliente_LN

    '    Dim vStr_Mensaje As String = ""
    '    Dim lInt_MsgBoxResult As Integer

    '    Windows.Forms.Cursor.Show()
    '    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    '    lInt_MsgBoxResult = MessageBox.Show("Está seguro de guardar el registro la Direccion", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
    '    If lInt_MsgBoxResult = Windows.Forms.DialogResult.No Then
    '        Return -1
    '    Else

    '        With ObjInDireccionCliente_EN

    '            .IdPersona = iID_Persona
    '            .idZona = id_ZonaCli
    '            .Zona = ZonaCli
    '            .IdVia = IDviaCli
    '            .Via = ViaCli
    '            .idNivel = id_NivelCli
    '            .Nivel = NivelCli
    '            .Numero = NroCli
    '            .Manzana = ManzanaCli
    '            .Lote = loteCli
    '            .Unidad_Agencia = objGuiaEnvio.iIDUNIDAD_AGENCIA
    '            .Formato = FormatoCli
    '            .IdDepartamento = iDepartamentoCli
    '            .IdProvincia = iProvinciaCli
    '            .IdDistrito = iDistritoCli


    '        End With
    '    End If
    '    vStr_Mensaje = lObj_InDireccionCliente_LN.F_InsDireccionRemitente_LN(ObjInDireccionCliente_EN)

    '    If vStr_Mensaje.Length > 0 Then
    '        MsgBox(vStr_Mensaje, MsgBoxStyle.Critical, "Error")
    '        Return -1
    '    Else
    '        MsgBox("La Direccion se Grabo satisfactoriamente", MsgBoxStyle.Information, "Aviso")
    '    End If

    'End Function


    '****DIRECCION CLIENTE**
    Dim IdDireccionOrigen As Integer
    Private Sub CboDireccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDireccion.SelectedIndexChanged
        If Not IsReference(CboDireccion.SelectedValue) Then
            If Not bDireccionModificada Then
                IdDireccionOrigen = CboDireccion.SelectedValue
            End If
        End If
    End Sub

    Private Sub CboDireccion_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboDireccion.SelectedValueChanged
        If iDespliegue = 1 Then
            If CboDireccion.SelectedIndex > 0 AndAlso CboContacto.SelectedIndex = 0 And TipoComprobante = 1 Then
                Me.DespliegaContacto()
            End If
        End If
        iDespliegue = 0
    End Sub

    Private Sub CboDireccion_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboDireccion.SelectionChangeCommitted
        iDespliegue = 1
    End Sub


    'FUNCION BUSCAR (CLIENTE CREDITO)
    Sub BuscarClienteCredito(Optional ByVal opcion As Integer = 0)
        Try
            Dim iOpcion As Integer = IIf(Me.RbtDocumento.Checked, 1, 2)
            Dim frm As New FrmCliente3
            Dim scliente As String = IIf(opcion = 0, Me.TxtCliente.Text.Trim, Me.TxtNroDocCliente.Text)
            Dim iCliente As Integer
            Dim obj As New dtoGuiaEnvio
            Dim ds As DataSet = obj.BuscarClienteCredito(scliente, iOpcion, dtoUSUARIOS.m_idciudad, idUnidadAgencias, objGuiaEnvio.iIDCENTRO_COSTO)
            dtCliente = ds.Tables(0)
            bClienteNuevo = True

            If IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                If Not bBoleto Then
                    MessageBox.Show("El Cliente no Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'Me.LimpiarCliente()
                    Return
                End If
            ElseIf ds.Tables(0).Rows.Count = 1 Then
                Me.MostrarClienteCredito(ds)
                ChkCliente.Checked = True
                ChkCliente1.Checked = True
            Else
                frm.bClienteNuevo = bClienteNuevo
                frm = New FrmCliente3
                frm.iFicha = 0

                frm.cargar(ds.Tables(0), 2)
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    ds = obj.BuscarClienteCredito(frm.TxtNumero.Text, 1, dtoUSUARIOS.m_idciudad, idUnidadAgencias)
                    dtCliente = ds.Tables(0)
                    Me.MostrarClienteCredito(ds)
                    ChkCliente.Checked = True
                    ChkCliente1.Checked = True
                End If
            End If

            'hlamas 13-03-2014
            ClienteProducto(iID_Persona, Me.CboSubCuenta.SelectedValue, dtoUSUARIOS.m_idciudad, idUnidadAgencias)

            'hlamas 24-02-2014
            ClientePersonalizado(iID_Persona)

            sDocCliente = TxtCliente.Text.Trim
        Catch ex As Exception
            Throw New Exception
        End Try
    End Sub

    Sub ClienteProducto(ByVal cliente As Integer, ByVal subcuenta As Integer, ByVal origen As Integer, ByVal destino As Integer)
        'hlamas 14-02-2019
        'If Me.CboTipo.SelectedValue = 1 Then Return
        If cliente = 0 Or subcuenta = 0 Or origen = 0 Or destino = 0 Then Return

        Dim intContado As Integer = IIf(Me.CboTipo.SelectedIndex = 0, 1, 0)
        Dim intProducto As Integer = Me.BuscarProducto(cliente, subcuenta, origen, destino, intContado)
        If intProducto > 0 Then
            RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            Me.CboProducto.SelectedValue = intProducto
            Me.fnTarifario()
            AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
        ElseIf intContado = 1 Then
            If Me.CboProducto.SelectedValue = 1 Then
                'Me.CboProducto.SelectedIndex = 0
            End If
            Me.CboProducto.Enabled = True
            Me.fnTarifario()
        Else
            RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            Me.CboProducto.SelectedIndex = IIf(intContado = 0, -1, 0)
            AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            DiseñaGrdDetalleVenta()
            FormatoGrdDetalleVenta()
            tarifa_Peso = 0
            tarifa_Volumen = 0
            tarifa_Articulo = 0
            Monto_Base = 0
            tarifa_Sobre = 0
            Me.CboProducto.Enabled = IIf(intContado = 0, False, True)
        End If
    End Sub

    Sub ClientePersonalizado(cliente As Integer)
        If Me.CboTipo.SelectedValue <> 2 And cliente > 0 Then Return
        If ID_PERSONA_DATAIMAGENES = cliente Then
            'hlamas 23-04-2014
            'If objGuiaEnvio.iIDUNIDAD_AGENCIA <> 5100 And objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = 5100 Then
            If dtoGuiaEnvio.VenderEnCiudad(cliente, objGuiaEnvio.iIDUNIDAD_AGENCIA, objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO) = False Then
                MessageBox.Show("El Cliente " & Me.TxtNomCliente.Text.Trim & " no puede realizar envíos de Provincia a Lima", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DiseñaGrdDetalleVenta()
                FormatoGrdDetalleVenta()
                tarifa_Peso = 0
                tarifa_Volumen = 0
                tarifa_Articulo = 0
                Monto_Base = 0
                tarifa_Sobre = 0
                Return
            End If
        End If

        If objGuiaEnvio.iIDUNIDAD_AGENCIA <> 5100 Then Return
        Dim objCliPer As New dtoGuiaEnvio
        Dim dt As DataTable = objCliPer.ClientePersonalizado(cliente)
        With dt
            If .Rows.Count > 0 Then 'cliente tiene datos personalizados
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Dim strActivar As String = .Rows(0).Item("ACTIVAR")

                    'tipo tarifa
                    Dim TipoTarifa As Integer = Val(strActivar.Substring(3, 1))

                    If TipoTarifa < 2 Then
                        Dim intTipoEntrega As Integer = .Rows(0).Item("idtipo_entrega")
                        If intTipoEntrega > 0 Then
                            Me.CboTipoEntrega.SelectedValue = intTipoEntrega
                        End If

                        Dim strDestino As String = .Rows(0).Item("destino")
                        If strDestino.Trim.Length > 0 Then
                            idUnidadAgencias = .Rows(0).Item("iddestino")
                            Me.TxtCiudadDestino.Text = strDestino
                            Me.TxtCiudadDestino_LostFocus(Nothing, Nothing)
                        End If
                        Dim intDireccion As Integer = .Rows(0).Item("iddireccion")
                        If intTipoEntrega > 0 And strDestino.Trim.Length > 0 And intDireccion > 0 Then
                            Dim dtDir As DataTable = objCliPer.ClienteDireccion(iID_Persona, 1, idUnidadAgencias)
                            With Me.CboDireccion2
                                dtDireccion2 = dtDir
                                .DataSource = dtDir
                                .DisplayMember = "direccion"
                                .ValueMember = "iddireccion_consignado"
                            End With
                        End If
                        If intDireccion > 0 Then
                            Me.CboDireccion2.SelectedValue = intDireccion
                        End If

                        Dim intTipoTarifa As Integer = .Rows(0).Item("idtipo_tarifa")
                        If intTipoTarifa > 0 Then
                            Me.CboTipoTarifa.SelectedValue = intTipoTarifa
                        End If
                    Else
                        Dim ok As Boolean = False
                        Dim strDestino As String = .Rows(0).Item("iddestino")
                        If strDestino.Trim.Length > 0 Then
                            If strDestino = objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO Then
                                ok = True
                            End If
                        Else
                            ok = True
                        End If
                        If ok Then
                            Dim intTipoTarifa As Integer = .Rows(0).Item("idtipo_tarifa")
                            If intTipoTarifa > 0 Then
                                Me.CboTipoTarifa.SelectedValue = intTipoTarifa
                            End If
                        End If
                    End If
                    ClienteActivarPersonalizado(strActivar)
                End If
            End If
        End With
    End Sub

    Sub ClienteActivarPersonalizado(config As String)
        Me.TxtCiudadDestino.Enabled = IIf(Val(config.Substring(0, 1)) > 0, True, False)
        Me.CboTipoEntrega.Enabled = IIf(Val(config.Substring(1, 1)) > 0, True, False)
        Me.CboDireccion2.Enabled = IIf(Val(config.Substring(2, 1)) > 0, True, False)
        Me.CboTipoTarifa.Enabled = IIf(Val(config.Substring(3, 1)) > 0, True, False)
    End Sub

    'FUNCION MOSTRAR DATOS CREDITO
    Sub MostrarClienteCredito(ByVal ds As DataSet)

        bClienteNuevo = False
        Me.LimpiarDatosCliente()

        If (dtCliente.Rows(0).Item("Cliente_Corporativo")) = 1 Then
            bTieneLineaCredito = True
            bClienteCredito = True
        Else
            bTieneLineaCredito = False
            bClienteCredito = False
        End If

        '**Articulos**
        DtArticulos = ds.Tables(4).Copy
        If ds.Tables(4).Rows.Count > 0 Then
            ChkArticulos.Enabled = True
        Else
            ChkArticulos.Enabled = False : ChkArticulos.Checked = False
        End If

        '*
        iID_Persona = ds.Tables(0).Rows(0).Item("idpersona")
        Dim iProceso As Integer = ds.Tables(0).Rows(0).Item("id_proceso")
        '*****************************************************************

        'Me.TxtNroDocCliente.Tag = ds.Tables(0).Rows(0).Item("idpersona")

        Me.TxtNroDocCliente.Text = ds.Tables(0).Rows(0).Item("nu_docu_suna").ToString.Trim
        Me.TxtNomCliente.Text = ds.Tables(0).Rows(0).Item("razon_social").ToString.Trim
        Me.TxtTelfCliente.Text = IIf(IsDBNull(dtCliente.Rows(0).Item("telefono")), "", dtCliente.Rows(0).Item("telefono"))

        '--recuperando datos cliente--       
        sNombresCli = IIf(IsDBNull(dtCliente.Rows(0).Item("nombres")), "", dtCliente.Rows(0).Item("nombres"))
        sApCli = IIf(IsDBNull(dtCliente.Rows(0).Item("ap")), "", dtCliente.Rows(0).Item("ap"))
        sAmCli = IIf(IsDBNull(dtCliente.Rows(0).Item("am")), "", dtCliente.Rows(0).Item("am"))
        sTelfCliente = IIf(IsDBNull(dtCliente.Rows(0).Item("telefono")), "", dtCliente.Rows(0).Item("telefono"))
        sRazonSocialCliente = IIf(IsDBNull(dtCliente.Rows(0).Item("razon_social")), "", dtCliente.Rows(0).Item("razon_social"))
        iID_TipoDocCli = ds.Tables(0).Rows(0).Item("tipo").ToString.Trim
        Dim iIDTipoFacturacion As Integer = ds.Tables(0).Rows(0).Item("Idtipo_Facturacion")
        MostrarTipoFacturacion(iIDTipoFacturacion)
        'hlamas 22-03-2016
        'If iIDTipoFacturacion = 3 Then
        '    ChkCargo.Checked = True
        'Else
        '    ChkCargo.Checked = False
        'End If
        If iIDTipoFacturacion = 3 Then
            Me.chkDocumentoCliente.Checked = True
            Me.rbtCargoSi.Checked = True
            Me.rbtCargoNo.Visible = False
        Else
            Me.chkDocumentoCliente.Checked = False
            Me.rbtCargoSi.Checked = False
            Me.rbtCargoNo.Visible = True
            Me.rbtCargoNo.Checked = False
        End If

        With Me.CboDireccion
            dtDireccion = ds.Tables(1)
            .DataSource = dtDireccion
            .DisplayMember = "direccion"
            .ValueMember = "iddireccion_consignado"

            If .Items.Count > 2 Then
                .SelectedIndex = 0
                .DroppedDown = True
                .Focus()
                Me.Cursor = Cursors.Default
            ElseIf .Items.Count = 1 Then
                .SelectedIndex = 0
                .Focus()
            Else
                .SelectedIndex = 1
                IdDireccionOrigen = CboDireccion.SelectedValue
                .Focus()
            End If
        End With

        With Me.CboDireccion2
            dtDireccion2 = ds.Tables(2)
            .DataSource = dtDireccion2
            .DisplayMember = "direccion"
            .ValueMember = "iddireccion_consignado"

            If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                If .Items.Count > 2 Then
                    .SelectedIndex = 0
                    '.DroppedDown = True
                    '.Focus()
                    Me.Cursor = Cursors.Default
                ElseIf .Items.Count = 1 Then
                    .SelectedIndex = 0
                Else
                    .SelectedIndex = 1
                End If
            Else
                '01092011
                Me.ConvertirTipoEntrega(Me.CboTipoEntrega.SelectedValue)
            End If
        End With

        'RemoveHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
        With Me.CboContacto
            dtContacto = ds.Tables(3)
            dtContactoParalelo = ds.Tables(3).Copy
            .DataSource = dtContacto
            .DisplayMember = "nombres"
            .ValueMember = "idcontacto_persona"
            If .Items.Count > 2 Then
                .SelectedIndex = 0
            ElseIf .Items.Count = 1 Then
                .SelectedIndex = 0
            Else
                .SelectedIndex = 1
            End If
            Me.ChkCliente1.Tag = DBNull.Value
        End With

        With Me.CboRemitente
            dtRemitente = ds.Tables(3).Copy
            dtRemitenteParalelo = ds.Tables(3).Copy
            .DataSource = dtRemitente
            .DisplayMember = "nombres"
            .ValueMember = "idcontacto_persona"
            If .Items.Count > 2 Then
                .SelectedIndex = 0
            ElseIf .Items.Count = 1 Then
                .SelectedIndex = 0
            Else
                .SelectedIndex = 1
            End If
            Me.ChkCliente.Tag = DBNull.Value
        End With

        ''->subCuenta destino
        'With Me.CboSubCuenta
        '    DtSubcuenta = ds.Tables(5).Copy
        '    .DataSource = DtSubcuenta
        '    .DisplayMember = "CENTRO_COSTO"
        '    .ValueMember = "IDCENTRO_COSTO"
        '    .SelectedValue = 999
        'End With

        '-->jabanto - 13/09/2013 - carga la subCuenta origen
        'If (iID_Persona = Cls_Constantes_LN.ID_PERSONA_ECKERD And CboProducto.SelectedValue = Cls_Constantes_LN.ID_PRODUCTO_CARGA_EXPRESA) Then
        '    CboSubCuentaOrigen.Enabled = True
        '    With Me.CboSubCuentaOrigen
        '        DtSubcuenta = ds.Tables(6).Copy
        '        .DataSource = DtSubcuenta
        '        .DisplayMember = "CENTRO_COSTO"
        '        .ValueMember = "IDCENTRO_COSTO"
        '        .SelectedValue = 999
        '    End With
        'Else
        '    CboSubCuentaOrigen.DataSource = Nothing
        '    CboSubCuentaOrigen.Enabled = False
        'End If

        ' AddHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged

        If TipoComprobante = 1 Then
            CboContacto.Enabled = True
            ChkCliente1.Enabled = True
        End If

        'hlamas 22-03-2016
        If iIDTipoFacturacion <> 3 Then  'solo aplica para tepsa encomiendas y tepsa courier office
            'hlamas 22-03-2016
            'verifica si cliente tiene devolucion de cargo por defecto
            Dim obj As New Cls_ClienteCargo_LN
            Dim intTipo As Integer = 2
            Dim intDevCargo As Integer = obj.DevolucionCargo(intTipo, iID_Persona)
            If intDevCargo >= 1 Then
                If Me.chkDocumentoCliente.Checked = False Then
                    Me.chkDocumentoCliente.Checked = True
                    Me.rbtCargoSi.Checked = True
                Else
                    If Me.rbtCargoSi.Checked = False Then
                        Me.rbtCargoSi.Checked = True
                    End If
                End If
            Else
                If Me.chkDocumentoCliente.Checked Then
                    Me.chkDocumentoCliente.Checked = False
                End If
            End If
        End If
        '----------------------------------------------------------

        '-->10/09/2013 ajabanto - Implemetación de la funcionalidad del DT(Documento de transporte) utilizado por Quimica suiza.
        '->Solo se visualiza cuando el cliente es Química Suiza
        If Me.CboTipo.SelectedIndex = 0 Then
            ID_PERSONA_QUIMICA_SUIZA = -10
        Else
            ID_PERSONA_QUIMICA_SUIZA = 1290
        End If
        'txtdt.Clear()
        'lbldt.Visible = (iID_Persona = ID_PERSONA_QUIMICA_SUIZA And objGuiaEnvio.iIDUNIDAD_AGENCIA = 5100)
        'txtdt.Visible = (iID_Persona = ID_PERSONA_QUIMICA_SUIZA And objGuiaEnvio.iIDUNIDAD_AGENCIA = 5100)
        'TxtTelfCliente.Size = IIf(iID_Persona = ID_PERSONA_QUIMICA_SUIZA, New Size(120, 20), New Size(329, 20))
        'IIf(iID_Persona = ID_PERSONA_QUIMICA_SUIZA, txtdt.Focus, TxtConsignado.Focus)

        'hlamas 07-02-2019
        txtdt.Clear()
        lbldt.Visible = (iID_Persona = ID_PERSONA_CBC And objGuiaEnvio.iIDUNIDAD_AGENCIA = 5100)
        txtdt.Visible = (iID_Persona = ID_PERSONA_CBC And objGuiaEnvio.iIDUNIDAD_AGENCIA = 5100)
        Me.dtpFechaRecojo.Visible = (iID_Persona = ID_PERSONA_CBC And objGuiaEnvio.iIDUNIDAD_AGENCIA = 5100)
        TxtTelfCliente.Size = IIf(iID_Persona = ID_PERSONA_CBC, New Size(86, 20), New Size(329, 20))
        IIf(iID_Persona = ID_PERSONA_CBC, txtdt.Focus, TxtConsignado.Focus)

        'hlamas 23-09-2013
        If iID_Persona = ID_PERSONA_ECKERD Then
            ControlaSubcuentaOrigen(True)
        Else
            ControlaSubcuentaOrigen(False)
        End If
        'Me.lblSubcuentaOrigen.Visible = iID_Persona = ID_PERSONA_ECKERD
        'Me.CboSubCuentaOrigen.Visible = iID_Persona = ID_PERSONA_ECKERD
    End Sub

#Region "D?"
    'EXISTE EL CLIENTE 
    Private Function FnExisteCliente() As Boolean
        Try
            If ObjVentaCargaContado.fnBuscarCliente(1, Me.TxtNroDocCliente.Text, dtoUSUARIOS.m_idciudad.ToString, idUnidadAgencias) = True Then
                ObjVentaCargaContado.v_IDPERSONA = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(0)
                If ObjVentaCargaContado.v_IDPERSONA = 0 Then
                    Return False
                Else
                    Return True
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Dim Iid As String
    Dim bBoleto As Boolean = False
    Private Function fnBuscarCliente() As Boolean
        Dim flag As Boolean = False
        Dim iAgenciaOrigen As Integer
        Try
            'b_lee = False
            iAgenciaOrigen = dtoUSUARIOS.m_idciudad
            If bOtrasAgencias Then
                iAgenciaOrigen = ObjVentaCargaContado.v_IDUNIDAD_ORIGEN
            End If

            'Buscando El cliente (Control, NroDocumento, RazonSocial, IDAgenciaOrigen,IDCiudadDest) 
            If ObjVentaCargaContado.fnBuscarCliente(1, Me.TxtNroDocCliente.Text, iAgenciaOrigen, idUnidadAgencias) = True Then

                '**********[Verifica si cliente tiene linea de credito]*********************************************              
                Iid = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(0)
                Dim ldt_tmp As New DataTable
                ldt_tmp = sp_linea_credito() '-> llamando el stored Procedure                
                If ldt_tmp.Rows.Count > 0 Then
                    If CType(ldt_tmp.Rows(0).Item("ES_ACTIVO"), Boolean) Then
                        bTieneLineaCredito = True
                    Else
                        bTieneLineaCredito = False
                    End If
                Else
                    bTieneLineaCredito = False
                End If
                flag = True

                '*************************CARGANDO LOS DATOS DEL CLIENTE BUSCADO************************************
                'Codigo cliente
                ObjVentaCargaContado.v_IDPERSONA = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(0)
                If ObjVentaCargaContado.v_IDPERSONA = 0 Then Return False '-> No encontro el cliente

                '-> iProceso = al tipo de Producto q pertenece El NroDocumento del Cliente (NORMAL,PYME)
                Dim iProceso As Integer = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(7)

                'TxtRazonSocialRem.Text = Trim(ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(1))
                TxtNomCliente.Text = Trim(ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(1))
                's_persona_remitente = TxtRazonSocialRem.Text
                '*************************************************
                RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                If iProceso = 0 Then '------> Normal
                    objGuiaEnvio.TarifaPyme_ = False
                    If CboProducto.SelectedValue = 6 Then
                        Me.CboProducto.SelectedValue = 6
                    ElseIf CboProducto.SelectedValue = 8 And bTieneLineaCredito = False Then
                        Me.CboProducto.SelectedValue = 8
                    Else
                        Me.CboProducto.SelectedValue = iProceso
                    End If
                ElseIf iProceso = 7 Then '--> Pyme  
                    If CboProducto.SelectedValue = 6 Then
                        Me.CboProducto.SelectedValue = 6
                    Else
                        Me.CboProducto.SelectedValue = iProceso
                    End If
                    'Me.TxtTelfConsignado.Focus()
                    Me.objGuiaEnvio.TarifaPyme_ = True '--> indica q traera tarifa Pyme                                      
                ElseIf iProceso = 8 Then '--> Masiva
                    objGuiaEnvio.TarifaPyme_ = False
                    Me.CboProducto.SelectedValue = iProceso
                    objGuiaEnvio.TarifaMasiva_ = True
                End If
                AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                '**************DATOS CLIENTES************************************************************
                Me.TxtNroDocCliente.Text = Trim(ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(6))
                If TxtNroDocCliente.Text = "" Then Return flag
                Me.TxtNroDocCliente.Tag = (ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(5))
                'TxtNroDocRem.Text = Trim(ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(6))
                ' Me.TxtTelfCliente.Text = Trim(ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(2))
                iControlMonto_Base = Trim(ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(3))

                If ObjVentaCargaContado.dt_cur_dire_origen.Rows.Count > 0 Then
                    ObjVentaCargaContado.v_IDDIREECION_ORIGEN = Int(ObjVentaCargaContado.dt_cur_dire_origen.Rows(0).Item(0).ToString)
                    'TxtDirecRem.Text = ObjVentaCargaContado.dt_cur_dire_origen.Rows(0).Item(1).ToString
                Else
                    'TxtDirecRem.Text = ""
                    ObjVentaCargaContado.v_IDDIREECION_ORIGEN = 0
                End If

                '**************CLIENTE TIENE DESCUENTO***************************************************  
                If CboProducto.SelectedValue <> 6 Then '--->Diferente De Carga Acompañada
                    iDescuento = IIf(ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(4) <> 0, ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(4), 0)
                    '
                    If iDescuento <> 0 Then
                        iDescuento = iDescuento / 100
                        bDescuento = True
                    Else
                        bDescuento = False
                    End If
                End If

                '**************DATOS CONTACTO*************************************************************
                If ObjVentaCargaContado.dt_cur_cont_origen.Rows.Count > 0 Then
                    ObjVentaCargaContado.v_IDPERSONA_ORIGEN = Int(ObjVentaCargaContado.dt_cur_cont_origen.Rows(0).Item(0).ToString)
                    'TxtRazonSocialCont.Text = Trim(ObjVentaCargaContado.dt_cur_cont_origen.Rows(0).Item(1).ToString)
                    TxtNroDocContacto.Text = Trim(ObjVentaCargaContado.dt_cur_cont_origen.Rows(0).Item(3).ToString)
                    TxtTelfCliente.Text = Trim(ObjVentaCargaContado.dt_cur_cont_origen.Rows(0).Item(5).ToString)
                Else
                    ObjVentaCargaContado.v_IDPERSONA_ORIGEN = 0
                    'TxtRazonSocialCont.Text = ""
                    TxtNroDocContacto.Text = ""
                End If


                '**************DATOS COSIGNADO*************************************************************
                If CboProducto.SelectedValue <> 6 Then '--->Diferente De Carga Acompañada
                    If ObjVentaCargaContado.dt_cur_cont_destino.Rows.Count > 0 Then
                        ObjVentaCargaContado.v_IDCONTACTO_DESTINO = Int(ObjVentaCargaContado.dt_cur_cont_destino.Rows(0).Item(0).ToString)

                        '****Comentado x NConsignado******
                        'TxtNombConsignado.Text = ObjVentaCargaContado.dt_cur_cont_destino.Rows(0).Item(1).ToString
                        'TxtNroDocConsignado.Text = ObjVentaCargaContado.dt_cur_cont_destino.Rows(0).Item(2).ToString
                        'TxtTelfConsignado.Text = ObjVentaCargaContado.dt_cur_cont_destino.Rows(0).Item(3).ToString
                        '**********************************
                    Else
                        If Not bBoleto Then
                            ObjVentaCargaContado.v_IDCONTACTO_DESTINO = 0
                            '****Comentado x NConsignado******
                            'TxtNombConsignado.Text = ""
                            'TxtNroDocConsignado.Text = ""
                        End If
                    End If

                    If ObjVentaCargaContado.dt_cur_dire_destino.Rows.Count > 0 Then
                        ObjVentaCargaContado.v_IDDIREECION_DESTINO = Int(ObjVentaCargaContado.dt_cur_dire_destino.Rows(0).Item(0).ToString)
                        'TxtDirecConsignado.Text = ObjVentaCargaContado.dt_cur_dire_destino.Rows(0).Item(1).ToString
                        'If CboTipoEntrega.Text.Trim <> "AGENCIA" And TxtDirecConsignado.Text.Trim = "AGENCIA" Then TxtDirecConsignado.Text = ""
                    Else
                        'TxtDirecConsignado.Text = ""
                        ObjVentaCargaContado.v_IDDIREECION_DESTINO = 0
                    End If
                End If

            Else
                ObjVentaCargaContado.v_IDPERSONA = 0
                'TxtRazonSocialRem.Text = ""
                ' TxtTelfCliente.Text = ""
                Me.TxtNroDocCliente.Tag = ""

                ObjVentaCargaContado.v_IDPERSONA_ORIGEN = 0
                'TxtRazonSocialCont.Text = ""
                TxtNroDocContacto.Text = ""

                ObjVentaCargaContado.v_IDCONTACTO_DESTINO = 0
                '****Comentado x NConsignado****
                'TxtNombConsignado.Text = ""
                'TxtNroDocConsignado.Text = ""

                'TxtDirecRem.Text = ""
                ObjVentaCargaContado.v_IDDIREECION_ORIGEN = 0
                'TxtDirecConsignado.Enabled = True
                'TxtDirecConsignado.Text = ""
                ObjVentaCargaContado.v_IDDIREECION_DESTINO = 0
                s_persona_remitente = ""
            End If
            'If ObjVentaCargaContado.v_IDPERSONA > 0 Then ' Encontro a la persona 
            '    TxtRasonSocialConsig.Focus()
            'End If

            '****************CLIENTE TIENE [ARTICULOS]*******************************
            If ObjVentaCargaContado.dt_cur_Articulos.Rows.Count > 0 Then
                ChkArticulos.Enabled = True
            Else
                ChkArticulos.Enabled = False : ChkArticulos.Checked = False
            End If
            '************************************************************************                       
        Catch ex As Exception
            Throw New Exception(ex.Message)
            flag = False
        End Try
        Return flag
    End Function

    Public Function sp_linea_credito() As DataTable
        Try
            Dim ll_idpersona As Int32
            Dim ldt_tmp As DataTable
            '
            ll_idpersona = objGuiaEnvio.iIDPERSONA
            objGuiaEnvio.iIDPERSONA = Iid
            ldt_tmp = objGuiaEnvio.sp_linea_credito()
            objGuiaEnvio.iIDPERSONA = ll_idpersona
            Return ldt_tmp
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Dim TipoComprobante As Integer
    Dim bIngresa As Boolean
    Private Function fnVALIDARDOCUMENTOS() As Boolean
        Try
            If TxtNroDocCliente.Text.Length = 11 Then
                If fnValidarRUC(TxtNroDocCliente.Text.ToString) Then
                    TipoComprobante = 3
                    If CboProducto.SelectedValue <> 6 Then '--->Diferente De Carga Acompañada (para mantener la tarifa de carga acompañada)               
                        fnTarifario()
                        'hlamas 22-02-2019
                        If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante) = True Then
                            '    txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
                            Return True
                        Else
                            Return False
                        End If
                    Else
                        If CboProducto.SelectedValue <> 6 Then
                            If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante) = True Then
                                'hlamas 22-02-2019
                                'txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
                                Return True
                            Else
                                Return False
                            End If
                        End If
                    End If
                    Else
                        '*********Añadir Error*************************************                  
                        Me.LimpiarDatosCliente()
                        '**********************************************************                                   
                        TxtNroDocCliente.SelectAll()
                        TxtNroDocCliente.Focus()
                        TipoComprobante = 3
                        Return False
                    End If
            ElseIf TxtNroDocCliente.Text.Length = 8 Or bIngresa Then
                If CboProducto.SelectedValue <> 6 Then
                    If flagPCEVALIDADOC = False Then
                        fnTarifario()
                        '  Me.NewfnTarifario()
                    End If
                End If
                'Dim vals As String = TxtRazonSocialRem.Text
                TxtNroDocContacto.Text = ""
                'TxtRazonSocialCont.Text = ""

                TipoComprobante = 3
                If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante) = True Then
                    'hlamas 22-02-2019
                    'txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
            Throw New Exception(ex.Message)
        End Try
    End Function

    Function fb_buscar_cliente() As Boolean
        Try
            Dim lb_retorna As Boolean
            lb_retorna = False
            If BuscarClientesGuia_Envio() = True Then
                lb_retorna = True
                fnTarifario()
            End If

            Return lb_retorna
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Dim CONTROL As Integer = 3
    Public iWinContacto_Remitente As New AutoCompleteStringCollection
    Public iWinDireccion_Remitente As New AutoCompleteStringCollection
    Public iWinDireccion_Destinatario As New AutoCompleteStringCollection
    Public iWinContacto_Destinatario As New AutoCompleteStringCollection
    Public iWinPersonaDNI_Remite As New AutoCompleteStringCollection
    Public iWinPersonaDNI_Destino As New AutoCompleteStringCollection
    Private Function BuscarClientesGuia_Envio() As Boolean
        Dim flag As Boolean = False
        Try
            If CONTROL = 4 Then
                CONTROL = 1
            End If

            objGuiaEnvio.iControl_Busqueda = CONTROL
            If CONTROL <> 2 Then
                objGuiaEnvio.iIDPERSONA = 0
            End If

            'TxtGuiaEnvio.Text = RellenoRight(NroDigitos_Guias, TxtGuiaEnvio.Text)

            If TxtCiudadDestino.Text <> "" Then
                objGuiaEnvio.iIDUNIDAD_AGENCIA = dtoUSUARIOS.m_idciudad.ToString
                objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = CodCiudadDest_
            Else
                objGuiaEnvio.iIDUNIDAD_AGENCIA = 999
                objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = 999
            End If

            If objGuiaEnvio.iIDUNIDAD_AGENCIA = objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO Then
                Return flag
            End If

            'If Me.TxtGuiaEnvio.Text <> "" And TxtGuiaEnvio.Text.Length() > 0 And bControl_Busqueda = False Then
            '    objGuiaEnvio.sNRO_GUIA = TxtGuiaEnvio.Text
            'Else
            objGuiaEnvio.sNRO_GUIA = "@"
            'End If

            Dim indexof As Integer = 0
            'If iWinPersona.Count > 0 Then
            indexof = iWinPersona.IndexOf(TxtNomCliente.Text) 'filtrado x razon Social
            objGuiaEnvio.iIDPERSONA = -1
            If indexof = -1 Then indexof = iWinPersonaRUC.IndexOf(TxtNroDocCliente.Text) 'filtrado x Nro Ruc

            If indexof >= 0 Then
                objGuiaEnvio.iIDPERSONA = Int(coll_Lista_Personas(indexof.ToString))
                objGuiaEnvio.iCONTROLIdpersona = objGuiaEnvio.iIDPERSONA

                'Recupera los datos 
                If indexof <= iWinPersonaRUC.Count Then
                    Me.TxtNroDocCliente.Text = iWinPersonaRUC.Item(indexof)
                    Me.li_iDigitosSerie = iwinNro_digito_serie_cliente.Item(indexof)
                    Me.objGuiaEnvio.iID_REMITENTE = objGuiaEnvio.iIDPERSONA
                    Me.objGuiaEnvio.iREMITENTE = TxtNomCliente.Text
                    Me.objGuiaEnvio.iNRODOC_REM = TxtNroDocCliente.Text
                    Me.bControl_Busqueda = True
                    bTieneLineaCredito = True
                End If
            Else
                MessageBox.Show("El cliente no tiene línea de crédito, revise sus datos", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            'End If


            If objGuiaEnvio.fnCONTROL_GUIAS_ENVIO_DOC() = True Then
                flag = True
                Me.TxtNroDocCliente.Text = objGuiaEnvio.sNU_DOCU_SUNAT.ToString
                Me.TxtNomCliente.Text = objGuiaEnvio.sRASON_SOCIAL.ToString
                'Me.TxtRazonSocialRem.Text = TxtRasonSocialCliente.Text
                'Me.TxtNroDocRem.Text = TxtNroDocCliente.Text

                'hlamas 22-03-2016
                'If objGuiaEnvio.iIDTipoFacturacion = 3 Then
                '    ChkCargo.Checked = True
                'Else
                '    ChkCargo.Checked = False
                'End If
                MostrarTipoFacturacion(objGuiaEnvio.iIDTipoFacturacion)
                If objGuiaEnvio.iIDTipoFacturacion = 3 Then
                    Me.chkDocumentoCliente.Checked = True
                    Me.rbtCargoSi.Checked = True
                    Me.rbtCargoNo.Visible = False
                Else
                    Me.chkDocumentoCliente.Checked = False
                    Me.rbtCargoSi.Checked = False
                    Me.rbtCargoNo.Visible = True
                    Me.rbtCargoNo.Checked = False
                End If

                '*************LLenando la Subcuenta************
                If objGuiaEnvio.dt_cur_Sub_Cuenta.Rows.Count > 0 Then
                    ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_cur_Sub_Cuenta, CboSubCuenta, objGuiaEnvio.coll_Sub_Cuenta, objGuiaEnvio.iIDCENTRO_COSTO)
                    CboSubCuenta.SelectedIndex = 0
                End If

                '*******Obteniendo Los Datos Del Contacto******
                If objGuiaEnvio.dt_cur_Nombres_Remitente.Rows.Count > 0 Then
                    objGuiaEnvio.iIDCONTACTO_PERSONA = Int(objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(0).ToString)
                    'TxtRazonSocialCont.Text = objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(1).ToString
                    TxtNroDocContacto.Text = objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(2).ToString
                Else
                    objGuiaEnvio.iIDCONTACTO_PERSONA = -1
                    'TxtRazonSocialCont.Text = ""
                    Me.TxtNroDocContacto.Text = ""
                End If

                '*******Obteniendo Los Datos Del Remitente*****
                'fnCargar_iWin2(TxtRazonSocialCont, objGuiaEnvio.dt_cur_Nombres_Remitente, objGuiaEnvio.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA, iWinPersonaDNI_Remite)
                If objGuiaEnvio.dt_cur_Direccion_Remitente.Rows.Count > 0 Then
                    objGuiaEnvio.iIDDIRECCION_REMITENTE = Int(objGuiaEnvio.dt_cur_Direccion_Remitente.Rows(0).Item(0).ToString)
                    'TxtDirecRem.Text = objGuiaEnvio.dt_cur_Direccion_Remitente.Rows(0).Item(1).ToString
                Else
                    'TxtDirecRem.Text = ""
                    objGuiaEnvio.iIDDIRECCION_REMITENTE = -1
                End If
                'fnCargar_iWin_dt(TxtDirecRem, objGuiaEnvio.dt_cur_Direccion_Remitente, objGuiaEnvio.coll_Direccion_Remitente, iWinDireccion_Remitente, objGuiaEnvio.iIDDIRECCION_REMITENTE)
                Me.TxtTelfCliente.Text = ""


                '*******Obteniendo Los Datos Del Consignado*****
                objGuiaEnvio.iIDTEFONO_REMITENTE = -1
                If objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows.Count > 0 Then
                    objGuiaEnvio.iIDCONTACTO_DESTINATARIO = Int(objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(0).ToString)
                    '***Comentado x NConsignado*****************************
                    'TxtNombConsignado.Text = objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(1).ToString
                    'TxtNroDocConsignado.Text = objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(2).ToString
                    '*******************************************************
                Else
                    objGuiaEnvio.iIDCONTACTO_DESTINATARIO = -1
                    'TxtNombConsignado.Text = ""
                    'TxtNroDocConsignado.Text = ""
                End If

                '***Comentado x NConsignado****************
                'fnCargar_iWin2(TxtNombConsignado, objGuiaEnvio.dt_cur_Nombres_Destinatario, objGuiaEnvio.coll_Nombres_Destinatario, iWinContacto_Destinatario, objGuiaEnvio.iIDCONTACTO_DESTINATARIO, iWinPersonaDNI_Destino)
                Dim idTipoDire As Integer = 0
                If idTipoDire = 2 Then
                    If objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows.Count > 0 Then
                        objGuiaEnvio.iIDDIRECCION_DESTINATARIO = Int(objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows(0).Item(0).ToString)
                        'TxtDirecConsignado.Text = objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows(0).Item(1).ToString
                    Else
                        objGuiaEnvio.iIDDIRECCION_DESTINATARIO = -1
                        'TxtDirecConsignado.Text = ""
                    End If
                    'fnCargar_iWin_dt(Me.TxtDirecConsignado, objGuiaEnvio.dt_cur_Direccion_Destinatario, objGuiaEnvio.coll_Direccion_Destinatario, iWinDireccion_Destinatario, objGuiaEnvio.iIDDIRECCION_DESTINATARIO)
                End If

                If objGuiaEnvio.dt_rst_Articulos.Rows.Count > 0 Then
                    ChkArticulos.Enabled = True
                Else
                    ChkArticulos.Enabled = False : ChkArticulos.Checked = False
                End If

                'TxtTelfConsignado.Text = ""
                objGuiaEnvio.iIDTEFONO_CONSIGNADO = -1


                TxtSubTotal.Text = "0.00"
                TxtImpuesto.Text = "0.00"
                TxtTotal.Text = "0.00"
            Else
                flag = False
            End If
        Catch ex As Exception
            flag = False
            Throw New Exception(ex.Message)
        End Try
        Return flag
    End Function

    Private Sub CARGAR_DATOS_CLIENTE()
        BuscarClientesGuia_EnvioCC()
    End Sub

    Dim iWinCLIENTE_Remitente As New AutoCompleteStringCollection
    Dim iWinCLIENTEDNI_Remite As New AutoCompleteStringCollection
    Private Function BuscarClientesGuia_EnvioCC() As Boolean
        Dim flag As Boolean = False
        Try
            If CONTROL = 4 Then
                CONTROL = 1
            End If
            '***********************Parametros**********************************
            objGuiaEnvio.iControl_Busqueda = CONTROL
            If CONTROL <> 2 Then
                objGuiaEnvio.iIDPERSONA = 0
            End If
            'TxtGuiaEnvio.Text = RellenoRight(NroDigitos_Guias, TxtGuiaEnvio.Text)
            If TxtCiudadDestino.Text <> "" Then
                objGuiaEnvio.iIDUNIDAD_AGENCIA = dtoUSUARIOS.m_idciudad.ToString
                objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = CodCiudadDest_
            Else
                objGuiaEnvio.iIDUNIDAD_AGENCIA = 999
                objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = 999
            End If

            'If Me.TxtGuiaEnvio.Text <> "" And TxtGuiaEnvio.Text.Length() > 0 And bControl_Busqueda = False Then
            '    objGuiaEnvio.sNRO_GUIA = TxtGuiaEnvio.Text
            'Else
            '    objGuiaEnvio.sNRO_GUIA = "@"
            'End If
            '*******************************************************************

            CONTROL = 2
            Dim indexof As Integer = 0
            If iWinPersona.Count > 0 Then
                'indexof = IIf(iWinContacto_Remitente.IndexOf(txtRemitente.Text) >= 0, iWinContacto_Remitente.IndexOf(txtRemitente.Text), -1)
                indexof = iWinPersonaRUC.IndexOf(TxtNroDocCliente.Text)
                objGuiaEnvio.iIDPERSONA = -1
                If indexof >= 0 Then
                    objGuiaEnvio.iIDPERSONA = Int(coll_Lista_Personas(indexof.ToString))
                    objGuiaEnvio.iCONTROLIdpersona = objGuiaEnvio.iIDPERSONA
                    If indexof <= iWinPersona.Count Then
                        Me.TxtNomCliente.Text = iWinPersona.Item(indexof)
                        objGuiaEnvio.iID_REMITENTE = objGuiaEnvio.iIDPERSONA
                        objGuiaEnvio.iREMITENTE = TxtNomCliente.Text
                        objGuiaEnvio.iNRODOC_REM = Me.TxtNroDocCliente.Text
                        bControl_Busqueda = True
                    End If
                Else
                    MessageBox.Show("El Cliente no tiene línea de crédito, revise sus datos", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If


            objGuiaEnvio.iIDCENTRO_COSTO = CboSubCuenta.SelectedValue

            If objGuiaEnvio.fnCONTROL_GUIAS_ENVIO_DOC_CC() = True Then
                flag = True
                Me.TxtNroDocCliente.Text = objGuiaEnvio.sNU_DOCU_SUNAT.ToString
                Me.TxtNomCliente.Text = objGuiaEnvio.sRASON_SOCIAL.ToString

                'TxtRazonSocialRem.Text = TxtRasonSocialCliente.Text
                'TxtNroDocRem.Text = TxtNroDocCliente.Text

                'lbTipoFacturacion.Text = objGuiaEnvio.iIDTipoFacturacion.ToString

                'hlamas 22-03-2016
                'If objGuiaEnvio.iIDTipoFacturacion = 3 Then
                '    ChkCargo.Checked = True
                'Else
                '    ChkCargo.Checked = False
                'End If
                MostrarTipoFacturacion(objGuiaEnvio.iIDTipoFacturacion)
                If objGuiaEnvio.iIDTipoFacturacion = 3 Then
                    Me.chkDocumentoCliente.Checked = True
                    Me.rbtCargoSi.Checked = True
                    Me.rbtCargoNo.Visible = False
                Else
                    Me.chkDocumentoCliente.Checked = False
                    Me.rbtCargoSi.Checked = False
                    Me.rbtCargoNo.Visible = True
                    Me.rbtCargoNo.Checked = False
                End If

                objGuiaEnvio.coll_Nombres_CLIENTE_REMITENTE.Clear()
                '*****Recuperando Datos Remitente***************************
                If objGuiaEnvio.dt_cur_CLIENTE_REMITENTE.Rows.Count > 0 Then
                    objGuiaEnvio.iID_REMITENTE = Int(objGuiaEnvio.dt_cur_CLIENTE_REMITENTE.Rows(0).Item(0).ToString)
                    'TxtRazonSocialRem.Text = objGuiaEnvio.dt_cur_CLIENTE_REMITENTE.Rows(0).Item(1).ToString
                    'TxtNroDocRem.Text = objGuiaEnvio.dt_cur_CLIENTE_REMITENTE.Rows(0).Item(2).ToString
                    'fnCargar_iWin2_dt2(TxtRazonSocialRem, objGuiaEnvio.dt_cur_CLIENTE_REMITENTE, objGuiaEnvio.coll_Nombres_CLIENTE_REMITENTE, iWinCLIENTE_Remitente, objGuiaEnvio.iID_REMITENTE, iWinCLIENTEDNI_Remite)
                Else
                    objGuiaEnvio.iID_REMITENTE = -1
                    'TxtRazonSocialRem.Text = ""
                    'Me.TxtNroDocRem.Text = ""
                    'fnCargar_iWin2_dt2(TxtRazonSocialRem, objGuiaEnvio.dt_cur_CLIENTE_REMITENTE, objGuiaEnvio.coll_Nombres_CLIENTE_REMITENTE, iWinCLIENTE_Remitente, objGuiaEnvio.iID_REMITENTE, iWinCLIENTEDNI_Remite)
                End If

                objGuiaEnvio.coll_Direccion_Remitente.Clear()
                If objGuiaEnvio.dt_cur_Direccion_Remitente.Rows.Count > 0 Then
                    objGuiaEnvio.iIDDIRECCION_REMITENTE = Int(objGuiaEnvio.dt_cur_Direccion_Remitente.Rows(0).Item(0).ToString)
                    'TxtDirecRem.Text = objGuiaEnvio.dt_cur_Direccion_Remitente.Rows(0).Item(1).ToString
                    'fnCargar_iWin_dt(TxtDirecRem, objGuiaEnvio.dt_cur_Direccion_Remitente, objGuiaEnvio.coll_Direccion_Remitente, iWinDireccion_Remitente, objGuiaEnvio.iIDDIRECCION_REMITENTE)
                Else
                    'TxtDirecRem.Text = ""
                    objGuiaEnvio.iIDDIRECCION_REMITENTE = -1
                    'fnCargar_iWin_dt(TxtDirecRem, objGuiaEnvio.dt_cur_Direccion_Remitente, objGuiaEnvio.coll_Direccion_Remitente, iWinDireccion_Remitente, objGuiaEnvio.iIDDIRECCION_REMITENTE)
                End If

                '*****Recuperando Datos Contacto****************************
                objGuiaEnvio.coll_Nombres_Remitente.Clear()
                If objGuiaEnvio.dt_cur_Nombres_Remitente.Rows.Count > 0 Then
                    objGuiaEnvio.iIDCONTACTO_PERSONA = Int(objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(0).ToString)
                    'TxtRazonSocialCont.Text = objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(1).ToString
                    TxtNroDocContacto.Text = objGuiaEnvio.dt_cur_Nombres_Remitente.Rows(0).Item(2).ToString
                    'fnCargar_iWin2_dt2(TxtRazonSocialCont, objGuiaEnvio.dt_cur_Nombres_Remitente, objGuiaEnvio.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA, iWinPersonaDNI_Remite)
                Else
                    objGuiaEnvio.iIDCONTACTO_PERSONA = -1
                    'TxtRazonSocialCont.Text = ""
                    Me.TxtNroDocContacto.Text = ""
                    'fnCargar_iWin2_dt2(TxtRazonSocialCont, objGuiaEnvio.dt_cur_Nombres_Remitente, objGuiaEnvio.coll_Nombres_Remitente, iWinContacto_Remitente, objGuiaEnvio.iIDCONTACTO_PERSONA, iWinPersonaDNI_Remite)
                End If

                Me.TxtTelfCliente.Text = ""
                objGuiaEnvio.iIDTEFONO_REMITENTE = -1

                '*****Recuperando Datos Consignado*****************************
                If objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows.Count > 0 Then
                    objGuiaEnvio.iIDCONTACTO_DESTINATARIO = Int(objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(0).ToString)
                    '***Comentado x NConsignado**********
                    'TxtNombConsignado.Text = objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(1).ToString
                    'TxtNroDocConsignado.Text = objGuiaEnvio.dt_cur_Nombres_Destinatario.Rows(0).Item(2).ToString
                    'fnCargar_iWin2_dt2(TxtNombConsignado, objGuiaEnvio.dt_cur_Nombres_Destinatario, objGuiaEnvio.coll_Nombres_Destinatario, iWinContacto_Destinatario, objGuiaEnvio.iIDCONTACTO_DESTINATARIO, iWinPersonaDNI_Destino)
                    '*************************************
                Else
                    objGuiaEnvio.iIDCONTACTO_DESTINATARIO = -1
                    '***Comentado x NConsignado*****
                    'TxtNombConsignado.Text = ""
                    'TxtNroDocConsignado.Text = ""
                    '*******************************
                End If

                If CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                    If objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows.Count > 0 Then
                        objGuiaEnvio.iIDDIRECCION_DESTINATARIO = Int(objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows(0).Item(0).ToString)
                        'TxtDirecConsignado.Text = objGuiaEnvio.dt_cur_Direccion_Destinatario.Rows(0).Item(1).ToString
                        'fnCargar_iWin_dt(Me.TxtDirecConsignado, objGuiaEnvio.dt_cur_Direccion_Destinatario, objGuiaEnvio.coll_Direccion_Destinatario, iWinDireccion_Destinatario, objGuiaEnvio.iIDDIRECCION_DESTINATARIO)
                    Else
                        objGuiaEnvio.iIDDIRECCION_DESTINATARIO = -1
                        'TxtDirecConsignado.Text = ""
                    End If
                End If

                '**Comentado x NConsignado
                'TxtTelfConsignado.Text = ""
                objGuiaEnvio.iIDTEFONO_CONSIGNADO = -1

                TxtSubTotal.Text = "0.00"
                TxtImpuesto.Text = "0.00"
                TxtTotal.Text = "0.00"


                If objGuiaEnvio.dt_rst_Articulos.Rows.Count > 0 Then
                    ChkArticulos.Enabled = True
                End If

            Else
                'Call ClearData()               
                flag = False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
            flag = False
        End Try
        Return flag
    End Function

    Private Sub cargar_articulos()
        Try
            Dim idPersona As Integer = iWinPersona.IndexOf(TxtNomCliente.Text)

            '**********Parametros*******************************************************
            objGuiaEnvio.iIDCENTRO_COSTO = Int(objGuiaEnvio.coll_Sub_Cuenta.Item(CboSubCuenta.SelectedIndex.ToString))
            objGuiaEnvio.iIDUNIDAD_AGENCIA = dtoUSUARIOS.m_idciudad.ToString
            objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = CodCiudadDest_
            objGuiaEnvio.iIDPERSONA = Int(coll_Lista_Personas.Item(idPersona.ToString))
            '***************************************************************************

            '********Devuelve true si la subcuenta tiene Articulos**********************
            If objGuiaEnvio.fnSP_CONSULTA_ARTI_SUB_CUENTA() = True Then
                ChkArticulos.Enabled = True
            Else
                ChkArticulos.Enabled = False
            End If

            '***************************************************************************
            For i As Integer = 0 To GrdDetalleVenta.RowCount - 2
                GrdDetalleVenta(2, i).Value() = "0.00"
                GrdDetalleVenta(4, i).Value() = "0.00"
            Next
            TxtSubTotal.Text = "0.00"
            TxtImpuesto.Text = "0.00"
            TxtTotal.Text = "0.00"
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Dim bTieneLineaCredito As Boolean = False
    Dim bCargaAcompañada2 As Boolean = False
    Dim bControl_Tarifas As Boolean = False
    Dim iControlMonto_Base As Double = 1
    Dim tarifa_Articulo As Double = 0
    Dim tarifa_Volumen As Double = 0
    Dim tarifa_Sobre As Double = 0
    Dim tarifa_Peso As Double = 0
    Dim iDescuento As Double = 0
    Dim iTarifa As Integer = 0
    Dim bDescuento As Boolean
    Public objGuiaEnvio As New dtoGuiaEnvio
    Public Function fnTarifario() As Boolean
        Dim flag As Boolean = False
        Try
            bControl_Tarifas = False
            objGuiaEnvio.CondicionTarifa_ = False

            tarifa_Peso = 0
            tarifa_Volumen = 0
            tarifa_Articulo = 0
            Monto_Base = 0
            tarifa_Sobre = 0
            Monto_25 = 0
            Monto_40 = 0

            If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_COURIER Then objGuiaEnvio.TarifaMasiva_ = True
            If CboProducto.SelectedValue = ID_PRODUCTO_PYME Then objGuiaEnvio.TarifaPyme_ = True
            '********************Parametros*************************************************************
            objGuiaEnvio.iIDUNIDAD_AGENCIA = dtoUSUARIOS.m_idciudad.ToString
            objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = idUnidadAgencias 'CodCiudadDest_
            objGuiaEnvio.TipoProducto_ = CboProducto.SelectedValue
            'objGuiaEnvio.TipoTarifa_ = IIf(CboTipoTarifa.SelectedIndex = -1, 0, CboTipoTarifa.SelectedIndex) ' Comentado por Diego Zegarra
            'objGuiaEnvio.TipoTarifa_ = IIf(CboTipoTarifa.SelectedIndex = 0, 1, 2)
            If IsNumeric(CboTipoTarifa.SelectedValue) Then
                objGuiaEnvio.TipoTarifa_ = CboTipoTarifa.SelectedValue
            Else
                objGuiaEnvio.TipoTarifa_ = 0
            End If
            objGuiaEnvio.sNU_DOCU_SUNAT = IIf(Me.TxtNroDocCliente.Text <> "", Me.TxtNroDocCliente.Text, "@")
            objGuiaEnvio.iIDCENTRO_COSTO = IIf(CboSubCuenta.SelectedValue Is Nothing, 999, CboSubCuenta.SelectedValue)
            objGuiaEnvio.iIPRODUCTO = IIf(CboProducto.SelectedValue Is Nothing, 0, CboProducto.SelectedValue)
            'objGuiaEnvio.i= IIf(CboSubCuenta.SelectedValue Is Nothing, 999, CboSubCuenta.SelectedValue)
            '*******************************************************************************************'
            'Listando la tarifa corporativa (ciudad origen, ciudad  destino, cliente)     no incluye igv
            '*******************************************************************************************'       
            ''hlamas 01-10-2013
            'objGuiaEnvio.dt_cur_Sub_Cuenta = dtoVentaCargaContado.ListarSubcuentas(ObjVentaCargaContado.v_IDPERSONA, objGuiaEnvio.iIDUNIDAD_AGENCIA)
            'If (objGuiaEnvio.dt_cur_Sub_Cuenta.Rows.Count > 0) Then
            '    With Me.CboSubCuentaOrigen
            '        .DataSource = objGuiaEnvio.dt_cur_Sub_Cuenta
            '        .DisplayMember = "CENTRO_COSTO"
            '        .ValueMember = "IDCENTRO_COSTO"
            '        .SelectedValue = 999
            '    End With
            '    If ID_PERSONA_ECKERD = ObjVentaCargaContado.v_IDPERSONA Then
            '        Me.ControlaSubcuentaOrigen(True)
            '    Else
            '        Me.ControlaSubcuentaOrigen(False)
            '    End If
            'End If

            'objGuiaEnvio.dt_cur_Sub_Cuenta_Destino = dtoVentaCargaContado.ListarSubcuentas(ObjVentaCargaContado.v_IDPERSONA, objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO)
            'If (objGuiaEnvio.dt_cur_Sub_Cuenta_Destino.Rows.Count > 0) Then
            '    With Me.CboSubCuenta
            '        .DataSource = objGuiaEnvio.dt_cur_Sub_Cuenta_Destino
            '        .DisplayMember = "CENTRO_COSTO"
            '        .ValueMember = "IDCENTRO_COSTO"
            '        .SelectedValue = 999
            '    End With
            'End If

            'If (CboProducto.SelectedValue = ID_PRODUCTO_CARGA_EXPRESA) And (CboTipo.SelectedValue = 2) _
            '   AndAlso Me.TxtNroDocCliente.Text.Trim.Length > 0 AndAlso objGuiaEnvio.fnLISTA_TARIFA_CLIENTE() = True Then
            objGuiaEnvio.iTipo = Me.CboTipo.SelectedValue
            If CboTipo.SelectedValue = 2 AndAlso Me.TxtNroDocCliente.Text.Trim.Length > 0 AndAlso objGuiaEnvio.fnLISTA_TARIFA_CLIENTE() = True Then
                bTarifarioGeneral = False
                tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
                tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
                tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
                Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base
                tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Sobre

                'hlamas 07/05/2015
                objGuiaEnvio.iPeso_Maximo = objGuiaEnvio.iPeso_Maximo
                objGuiaEnvio.iVol_Maximo = 0 'objGuiaEnvio.iVol_Maximo
                objGuiaEnvio.iPrecio_cond_Peso = objGuiaEnvio.iPrecio_cond_Peso
                objGuiaEnvio.iPrecio_cond_Vol = 0 'objGuiaEnvio.iPrecio_cond_Vol

                objGuiaEnvio.CondicionTarifa_ = False
                'If (CboTipo.SelectedValue = 2) Then
                If (objGuiaEnvio.iPeso_Maximo > 0) Then
                    objGuiaEnvio.UnidadPeso_ = "PESO"
                    objGuiaEnvio.iPeso_Minimo = 0.01
                    objGuiaEnvio.CondicionTarifa_ = True
                End If
                If (objGuiaEnvio.iVol_Maximo > 0) Then
                    objGuiaEnvio.UnidadVol_ = "VOL"
                    objGuiaEnvio.iVol_Minimo = 0.01
                    objGuiaEnvio.CondicionTarifa_ = True
                End If

                iTarifa = objGuiaEnvio.iTarifa

                GrdDetalleVenta("Costo", 0).Value = tarifa_Peso
                GrdDetalleVenta("Costo", 1).Value = tarifa_Volumen
                GrdDetalleVenta("Costo", 2).Value = tarifa_Sobre

                If iControlMonto_Base = 1 Then
                    GrdDetalleVenta("Costo", 3).Value = Monto_Base
                    GrdDetalleVenta("Sub Neto", 3).Value = Monto_Base
                End If

                flag = True
                bControl_Tarifas = True
                bContado = False


                '*******************************************************************************************'
                'Tarifa publica (ciudad origen, ciudad destino)                   incluye igv
                '*******************************************************************************************'

            ElseIf objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO > 0 Then  'If objGuiaEnvio.fnTARIFA_PUBLICA_CARGA2() = True Then
                Dim tarifaCarga As New dtoTarifasCargo
                Dim objVentaContado As New dtoVentaCargaContado

                'hlamas 24-09-2018
                Dim intTipoEntrega As Integer = 0
                If Me.CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX Or Me.CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX_10 Then
                    intTipoEntrega = Me.CboTipoEntrega.SelectedValue
                End If

                'hlamas 21-01-2016
                tarifaCarga = ObjVentaCargaContado.ObtenerTarifaPublica(dtoUSUARIOS.m_idciudad.ToString, _
                                                                         idUnidadAgencias, CboProducto.SelectedValue, _
                                                                         objGuiaEnvio.TipoTarifa_, intTipoEntrega)
                'tarifaCarga = objVentaContado.obtenerTarifas(objGuiaEnvio.iIDUNIDAD_AGENCIA, _
                '                                         objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO, _
                '                                         objGuiaEnvio.iIPRODUCTO, _
                '                                        objGuiaEnvio.TipoTarifa_)

                If IsNothing(tarifaCarga) = False Then
                    bContado = True
                    bTarifarioGeneral = True

                    '-->Pasa valores al objeto objGuiaEnvio
                    objGuiaEnvio.iTarifa_Publica_Monto_Peso = tarifaCarga.precioPeso
                    objGuiaEnvio.iTarifa_Publica_Monto_Volumen = tarifaCarga.precioVolumen
                    objGuiaEnvio.iTarifa_Publica_Monto_Base = tarifaCarga.precioBase
                    objGuiaEnvio.iTarifa_Publica_Monto_Base_Xpostal = tarifaCarga.precioSobre
                    objGuiaEnvio.iPeso_Maximo = tarifaCarga.pesoMinimo
                    objGuiaEnvio.iVol_Maximo = tarifaCarga.volumnenMinimo
                    objGuiaEnvio.iPrecio_cond_Peso = tarifaCarga.fleteMinimoPeso
                    objGuiaEnvio.iPrecio_cond_Vol = tarifaCarga.fleteMinimoVolumen
                    objGuiaEnvio.iMonto25 = tarifaCarga.importeArticulo_Caja5
                    objGuiaEnvio.iMonto40 = tarifaCarga.importeArticulo_Caja10


                    'hlamas 21-01-2016 temporal 
                    'Dim dt As DataTable = ObjVentaCargaContado.ObtenerTarifa(objGuiaEnvio.sNU_DOCU_SUNAT, dtoUSUARIOS.m_idciudad.ToString, idUnidadAgencias, _
                    '                                                       intTipoEntrega, CboProducto.SelectedValue, objGuiaEnvio.TipoTarifa_)
                    Dim dt As DataTable = ObjVentaCargaContado.ObtenerTarifa(iID_Persona, dtoUSUARIOS.m_idciudad.ToString, idUnidadAgencias, _
                                                                                               intTipoEntrega, CboProducto.SelectedValue, objGuiaEnvio.TipoTarifa_, 999)
                    If dt.Rows.Count > 0 Then
                        If Not IsDBNull(dt.Rows(0).Item(0)) Then
                            If dt.Rows(0).Item(0) >= 0 Then
                                objGuiaEnvio.iTarifa_Publica_Monto_Peso = dt.Rows(0).Item(0)
                            End If
                            If dt.Rows(0).Item(1) >= 0 Then
                                objGuiaEnvio.iTarifa_Publica_Monto_Volumen = dt.Rows(0).Item(1)
                            End If
                            If dt.Rows(0).Item(2) >= 0 Then
                                tarifa_Articulo = dt.Rows(0).Item(2)
                            End If
                            If dt.Rows(0).Item(3) >= 0 Then
                                objGuiaEnvio.iTarifa_Publica_Monto_Base = dt.Rows(0).Item(3)
                            End If
                            If dt.Rows(0).Item(4) >= 0 Then
                                objGuiaEnvio.iTarifa_Publica_Monto_Base_Xpostal = dt.Rows(0).Item(4)
                            End If
                            If dt.Rows(0).Item(5) >= 0 Then
                                objGuiaEnvio.iPeso_Maximo = dt.Rows(0).Item(5)
                            End If
                            If dt.Rows(0).Item(6) >= 0 Then
                                objGuiaEnvio.iVol_Maximo = dt.Rows(0).Item(6)
                            End If
                            If dt.Rows(0).Item(7) >= 0 Then
                                objGuiaEnvio.iPrecio_cond_Peso = dt.Rows(0).Item(7)
                            End If
                            If dt.Rows(0).Item(8) >= 0 Then
                                objGuiaEnvio.iPrecio_cond_Vol = dt.Rows(0).Item(8)
                            End If
                            If dt.Rows(0).Item(9) >= 0 Then
                                objGuiaEnvio.iMonto25 = dt.Rows(0).Item(9)
                            End If
                            If dt.Rows(0).Item(10) >= 0 Then
                                objGuiaEnvio.iMonto40 = dt.Rows(0).Item(10)
                            End If
                        End If
                    End If

                    '-->Pasa valores a la variables publicas
                    tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
                    tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
                    tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
                    tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
                    Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base
                    tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Base_Xpostal
                    Monto_25 = objGuiaEnvio.iMonto25
                    Monto_40 = objGuiaEnvio.iMonto40

                    '-->Asigna valores con la condicion de peso minimo y/o volumne minimo.
                    objGuiaEnvio.CondicionTarifa_ = False
                    'If (CboTipo.SelectedValue = 2) Then
                    If (tarifaCarga.pesoMinimo > 0) Then
                        objGuiaEnvio.UnidadPeso_ = "PESO"
                        objGuiaEnvio.iPeso_Minimo = 0.01
                        objGuiaEnvio.CondicionTarifa_ = True
                    End If
                    If (tarifaCarga.volumnenMinimo > 0) Then
                        objGuiaEnvio.UnidadVol_ = "VOL"
                        objGuiaEnvio.iVol_Minimo = 0.01
                        objGuiaEnvio.CondicionTarifa_ = True
                    End If
                    'End If

                    'verifica si esta afecto a monto base para carga acompañada
                    If CboProducto.SelectedValue = 6 Then
                        If CboTipoEntrega.SelectedValue = TipoEntrega.Agencia Then
                            Monto_Base = 0
                        End If
                        'bBoleto = "N"
                    End If
                    If bBoleto = False Then
                        If bDescuento Then
                            tarifa_Peso = tarifa_Peso * (1 - iDescuento)
                            tarifa_Volumen = tarifa_Volumen * (1 - iDescuento)
                            'tarifa_Sobre = tarifa_Sobre * (1 - iDescuento)
                            isDescuento_ = True
                        End If
                    End If
                    flag = True
                    bControl_Tarifas = True
                Else
                    flag = False
                End If

                'hlamas 21-01-2016 recupera tarifa de articulos publico
                dtTarifaArticuloPublico = ObjVentaCargaContado.dtTarifaArticuloPublico
                If ChkArticulos.Tag Is Nothing And dtTarifaArticuloPublico.Rows.Count > 0 Then
                    DtArticulos = dtTarifaArticuloPublico
                    Me.ChkArticulos.Enabled = True
                    Me.ChkArticulos.Checked = False
                ElseIf ChkArticulos.Tag Is Nothing Then
                    DtArticulos = Nothing
                    Me.ChkArticulos.Enabled = False
                    Me.ChkArticulos.Checked = False
                End If
            Else
                flag = False
            End If
            Me.ResetCalculo()

            If Me.CboProducto.SelectedValue <> 81 And Me.CboProducto.SelectedValue <> 82 Then
                If ChkM3.Checked = False Then
                    GrdDetalleVenta("Costo", 0).Value = tarifa_Peso
                    GrdDetalleVenta("Costo", 1).Value = tarifa_Volumen
                    GrdDetalleVenta("Costo", 2).Value = tarifa_Sobre

                    If iControlMonto_Base = 1 Then
                        GrdDetalleVenta("Costo", 3).Value = Monto_Base
                        GrdDetalleVenta("Sub Neto", 3).Value = Monto_Base
                    End If
                End If
            End If
            flagControl = False

            '-->colova valores de la tarifa del grid
            For i As Integer = 0 To GrdDetalleVenta.Rows.Count - 1
                If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX Then
                    Select Case i
                        Case 0
                            GrdDetalleVenta("Costo", 0).Value = Format(Monto_25, "0.00")
                            'Case 1
                            'GrdDetalleVenta("Costo", 1).Value = Format(Monto_40, "0.00")
                    End Select
                ElseIf CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX_10 Then
                    GrdDetalleVenta("Costo", 0).Value = Format(Monto_40, "0.00")
                Else
                    Select Case i
                        Case 0
                            GrdDetalleVenta("Costo", 0).Value = Format(tarifa_Peso, "0.00")
                        Case 1
                            GrdDetalleVenta("Costo", 1).Value = Format(tarifa_Volumen, "0.00")
                        Case 2
                            GrdDetalleVenta("Costo", 2).Value = Format(tarifa_Sobre, "0.00")
                        Case 3
                            GrdDetalleVenta("Costo", 3).Value = Format(Monto_Base, "0.00")
                            GrdDetalleVenta("Sub Neto", 3).Value = Format(Monto_Base, "0.00")
                    End Select
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return flag
    End Function

    Dim TipoTarifa_ As Integer
    Dim TipoProducto_ As Integer
    Dim iPeso_Minimo As Double = 0
    Dim iPeso_Maximo As Double = 0
    Dim iPrecio_cond_Peso As Double = 0
    Dim TarifaPublica_ As Boolean
    Dim TarifaPyme_ As Boolean
    Dim TarifaMasiva_ As Boolean
    Dim Unidad_ As String
    Dim CondicionTarifa_ As Boolean
    Dim dPRECIO_X_UNIDAD As Double
    'Public Function NewfnTarifario() As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        bControl_Tarifas = False
    '        tarifa_Peso = 0
    '        tarifa_Volumen = 0
    '        tarifa_Articulo = 0
    '        Monto_Base = 0

    '        If CboProducto.SelectedValue = 8 Then objGuiaEnvio.TarifaMasiva_ = True
    '        '*******************Parametros**************************************************************            
    '        objGuiaEnvio.iIDUNIDAD_AGENCIA = dtoUSUARIOS.m_idciudad.ToString
    '        objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = CodCiudadDest_
    '        objGuiaEnvio.TipoProducto_ = CboProducto.SelectedValue
    '        objGuiaEnvio.TipoTarifa_ = CboTipoTarifa.SelectedValue
    '        objGuiaEnvio.sNU_DOCU_SUNAT = IIf(Me.TxtNroDocCliente.Text <> "", Me.TxtNroDocCliente.Text, "@")
    '        If CboTipo.SelectedValue = 2 Then
    '            If CboSubCuenta.SelectedIndex.ToString <> -1 Then
    '                objGuiaEnvio.iIDCENTRO_COSTO = Int(objGuiaEnvio.coll_Sub_Cuenta.Item(CboSubCuenta.SelectedIndex.ToString))
    '            Else
    '                objGuiaEnvio.iIDCENTRO_COSTO = 999
    '            End If

    '        End If

    '        Dim obj As New dtoGuia
    '        '*******************************************************************************************'
    '        'Listando la tarifa corporativa (ciudad origen, ciudad  destino, cliente)---> no incluye igv
    '        '*******************************************************************************************' 
    '        If objGuiaEnvio.fnLISTA_TARIFA_CLIENTE() = True Then
    '            bTarifarioGeneral = False
    '            tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
    '            tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
    '            tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
    '            Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base
    '            tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Sobre
    '            iTarifa = objGuiaEnvio.iTarifa

    '            GrdDetalleVenta(3, 0).Value = tarifa_Peso
    '            GrdDetalleVenta(3, 1).Value = tarifa_Volumen
    '            GrdDetalleVenta(3, 2).Value = tarifa_Sobre

    '            If iControlMonto_Base = 1 Then
    '                GrdDetalleVenta(3, 3).Value = Monto_Base
    '                GrdDetalleVenta(4, 3).Value = Monto_Base
    '            End If

    '            flag = True
    '            bControl_Tarifas = True

    '            Dim ds As DataSet = obj.fnTARIFA_PUBLICA_CARGA1(dtoUSUARIOS.m_idciudad.ToString, CodCiudadDest_, CboProducto.SelectedValue, CboTipoTarifa.SelectedIndex)
    '            If ds.Tables(0).Rows.Count > 0 Then
    '                Monto_Base = Format(ds.Tables(0).Rows(0).Item(1), "##,###.00")
    '                tarifa_Peso = Format(ds.Tables(0).Rows(0).Item(2), "##,###.00")
    '                tarifa_Volumen = Format(ds.Tables(0).Rows(0).Item(3), "##,###.00")
    '                'iTarifa_Publica_Monto_Base_Xpostal = Format(ds.Tables(0).Rows(0).Item(7), "##,###.00")
    '                tarifa_Sobre = Format(IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_X_SOBRE")), 0, ds.Tables(0).Rows(0).Item("CG_X_SOBRE")), "##,###.00")
    '                tarifa_Articulo = Format(IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_X_SOBRE")), 0, ds.Tables(0).Rows(0).Item("CG_X_SOBRE")))
    '                iTarifa = ds.Tables(0).Rows(0).Item("tarifa")
    '                '                                       
    '                If ds.Tables(1).Rows.Count > 0 Then
    '                    If ds.Tables(1).Rows(0).Item("UNIDAD") = "PESO" Then
    '                        iPeso_Minimo = ds.Tables(1).Rows(0).Item("INICIO")
    '                        iPeso_Maximo = ds.Tables(1).Rows(0).Item("FIN")
    '                        iPrecio_cond_Peso = ds.Tables(1).Rows(0).Item("PRECIO_FINAL")
    '                    End If

    '                    'If ds.Tables(1).Rows(0).Item("UNIDAD") = "VOLUMEN" Then
    '                    '    iVol_Minimo = ds.Tables(1).Rows(0).Item("INICIO")
    '                    '    iVol_Maximo = ds.Tables(1).Rows(0).Item("FIN")
    '                    '    iPrecio_cond_Vol = ds.Tables(1).Rows(0).Item("PRECIO_FINAL")
    '                    'End If
    '                End If
    '                flag = True
    '            Else
    '                flag = False
    '            End If
    '        Else
    '            '*******************************************************************************************'
    '            'Tarifa publica (ciudad origen, ciudad destino)-----------------------> incluye igv
    '            '*******************************************************************************************'               
    '            Dim ds As DataSet = obj.fnTARIFA_PUBLICA_CARGA1(dtoUSUARIOS.m_idciudad.ToString, CodCiudadDest_, CboProducto.SelectedValue, CboTipoTarifa.SelectedIndex)

    '            'cargando si la tarifa tiene condicion tarifa
    '            If ds.Tables(1).Rows.Count > 0 Then
    '                If ds.Tables(1).Rows(0).Item(0) IsNot System.DBNull.Value Then
    '                    Unidad_ = ds.Tables(1).Rows(0).Item("UNIDAD")
    '                    iPeso_Minimo = ds.Tables(1).Rows(0).Item("INICIO")
    '                    iPeso_Maximo = ds.Tables(1).Rows(0).Item("FIN")
    '                    iPrecio_cond_Peso = ds.Tables(1).Rows(0).Item("MONTO")
    '                    TipoTarifa_ = ds.Tables(1).Rows(0).Item("TIPO_TARIFA")
    '                    TipoProducto_ = ds.Tables(1).Rows(0).Item("ID_PRODUCTO")
    '                    CondicionTarifa_ = True
    '                Else
    '                    CondicionTarifa_ = False
    '                End If
    '            Else
    '                CondicionTarifa_ = False
    '            End If

    '            If ds.Tables(0).Rows.Count = 1 And ds.Tables(0).Rows(0).Item(0) = 1 Then
    '                If TipoTarifa_ = 0 Then '---> TARIFA 48 HORAS
    '                    tarifa_Peso = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_X_PESO")), 0, ds.Tables(0).Rows(0).Item("CG_X_PESO"))
    '                    tarifa_Volumen = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_X_VOLUMEN")), 0, ds.Tables(0).Rows(0).Item("CG_X_VOLUMEN"))
    '                    Monto_Base = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_MONTO_BASE")), 0, ds.Tables(0).Rows(0).Item("CG_MONTO_BASE"))
    '                    tarifa_Articulo = Monto_Base
    '                    tarifa_Sobre = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_X_SOBRE")), 0, ds.Tables(0).Rows(0).Item("CG_X_SOBRE"))
    '                    bContado = IIf(ds.Tables(0).Rows(0).Item("CONTADO") = 1, True, False)

    '                    If TarifaPyme_ Then
    '                        tarifa_Peso = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("PY_PESO_CONTADO")), 0, ds.Tables(0).Rows(0).Item("PY_PESO_CONTADO"))
    '                        tarifa_Volumen = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("PY_VOLUMEN_CONTADO")), 0, ds.Tables(0).Rows(0).Item("PY_VOLUMEN_CONTADO"))
    '                        Monto_Base = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("PY_BASE_CONTADO")), 0, ds.Tables(0).Rows(0).Item("PY_BASE_CONTADO"))
    '                        tarifa_Articulo = Monto_Base
    '                        tarifa_Sobre = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("PY_SOBRE_CONTADO")), 0, ds.Tables(0).Rows(0).Item("PY_SOBRE_CONTADO"))
    '                        TarifaPyme_ = False
    '                    ElseIf TarifaMasiva_ Then
    '                        tarifa_Peso = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ma48_PESO_CONTADO")), 0, ds.Tables(0).Rows(0).Item("ma48_PESO_CONTADO"))
    '                        tarifa_Volumen = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ma48_VOLUMEN_CONTADO")), 0, ds.Tables(0).Rows(0).Item("ma48_VOLUMEN_CONTADO"))
    '                        Monto_Base = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ma48_BASE_CONTADO")), 0, ds.Tables(0).Rows(0).Item("ma48_BASE_CONTADO"))
    '                        tarifa_Sobre = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ma48_SOBRE_CONTADO")), 0, ds.Tables(0).Rows(0).Item("ma48_SOBRE_CONTADO"))
    '                        tarifa_Articulo = 0
    '                        TarifaMasiva_ = False
    '                    End If
    '                Else '----------------------> TARIFA 24 HORAS
    '                    If TarifaMasiva_ Then
    '                        tarifa_Peso = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ma24_PESO_CONTADO")), 0, ds.Tables(0).Rows(0).Item("ma24_PESO_CONTADO"))
    '                        tarifa_Volumen = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ma24_VOLUMEN_CONTADO")), 0, ds.Tables(0).Rows(0).Item("ma24_VOLUMEN_CONTADO"))
    '                        Monto_Base = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ma24_BASE_CONTADO")), 0, ds.Tables(0).Rows(0).Item("ma24_BASE_CONTADO"))
    '                        tarifa_Sobre = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ma24_SOBRE_CONTADO")), 0, ds.Tables(0).Rows(0).Item("ma24_SOBRE_CONTADO"))
    '                        TarifaMasiva_ = False
    '                    Else
    '                        tarifa_Peso = 0
    '                        tarifa_Volumen = 0
    '                        tarifa_Articulo = 0
    '                        tarifa_Sobre = 0
    '                    End If
    '                End If

    '                'verifica si esta afecto a monto base para carga acompañada
    '                If CboProducto.SelectedValue = 6 Then
    '                    If CboTipoEntrega.SelectedValue = TipoEntrega.Agencia Then
    '                        Monto_Base = 0
    '                    End If
    '                End If

    '                If bTieneLineaCredito Then
    '                    tarifa_Peso = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_X_PESO_CREDITO")), 0, ds.Tables(0).Rows(0).Item("CG_X_PESO_CREDITO"))
    '                    tarifa_Volumen = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_X_VOLUMEN_CREDITO")), 0, ds.Tables(0).Rows(0).Item("CG_X_VOLUMEN_CREDITO"))
    '                    Monto_Base = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_MONTO_BASE_CREDITO")), 0, ds.Tables(0).Rows(0).Item("CG_MONTO_BASE_CREDITO"))
    '                    tarifa_Sobre = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_X_SOBRE_CREDITO")), 0, ds.Tables(0).Rows(0).Item("CG_X_SOBRE_CREDITO"))
    '                    bContado = False
    '                    TarifaPublica_ = False
    '                End If

    '                '

    '                If bDescuento Then
    '                    tarifa_Peso = tarifa_Peso * (1 - iDescuento)
    '                    tarifa_Volumen = tarifa_Volumen * (1 - iDescuento)
    '                    'tarifa_Sobre = tarifa_Sobre * (1 - iDescuento)
    '                    isDescuento_ = True
    '                End If

    '                If ChkM3.Checked = False Then
    '                    GrdDetalleVenta("Costo", 0).Value = tarifa_Peso
    '                    GrdDetalleVenta("Costo", 1).Value = tarifa_Volumen
    '                    GrdDetalleVenta("Costo", 2).Value = tarifa_Sobre

    '                    If iControlMonto_Base = 1 Then
    '                        GrdDetalleVenta("Costo", 3).Value = Monto_Base
    '                        GrdDetalleVenta("Sub Neto", 3).Value = Monto_Base
    '                    End If
    '                End If

    '                flag = True
    '                bControl_Tarifas = True

    '                If bContado = 0 Then
    '                    If tarifa_Sobre <= 0 Then
    '                        tarifa_Sobre = Monto_Base
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try
    '    Return flag
    'End Function

#End Region


#End Region

#Region "REMITENTE"
    '****NOMBRE  REMITENTE**
    Dim idRemitente As Integer
    Private Sub CboRemitente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboRemitente.SelectedIndexChanged
        If Not IsReference(CboRemitente.SelectedValue) Then
            If Not bRemitenteModificado Then
                idRemitente = CboRemitente.SelectedValue
            End If
            Me.TxtNumDocRemitente.Text = IIf(IsDBNull(dtRemitente.Rows(CboRemitente.SelectedIndex).Item("nrodocumento")), "", dtRemitente.Rows(CboRemitente.SelectedIndex).Item("nrodocumento"))
            sNroDocRemitente = Me.TxtNumDocRemitente.Text
        ElseIf Me.CboRemitente.DataSource Is Nothing Then
            If Me.CboRemitente.Items.Count > 1 Then
                Dim iFila As Integer = IIf(CboRemitente.SelectedIndex < 0, 0, CboRemitente.SelectedIndex)
                Me.TxtNumDocRemitente.Text = IIf(IsDBNull(dtRemitente.Rows(iFila).Item("nrodocumento")), "", dtRemitente.Rows(iFila).Item("nrodocumento"))
                sNroDocRemitente = Me.TxtNumDocRemitente.Text
            End If
        End If

        RemoveHandler ChkCliente.CheckedChanged, AddressOf ChkCliente_CheckedChanged
        If Me.CboRemitente.SelectedIndex = 0 Then
            Me.ChkCliente.Checked = False
        Else
            'Me.ChkCliente1.Checked = IIf(IsDBNull(Me.ChkCliente1.Tag), Me.ChkCliente1.Checked, Me.ChkCliente1.Tag)
            Me.ChkCliente.Checked = IIf(TxtNroDocCliente.Text = TxtNumDocRemitente.Text, 1, 0)
        End If
        AddHandler ChkCliente.CheckedChanged, AddressOf ChkCliente_CheckedChanged
    End Sub

    '****(REMITENTE) ES EL CLIENTE
    Private Sub ChkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCliente.CheckedChanged
        If ChkCliente.Checked Then
            If Me.TxtNroDocCliente.Text.Trim.Length > 0 Or Me.TxtNomCliente.Text.Trim.Length > 0 Then
                Dim iExisteEsElCliente As Integer = ExisteEsElCliente(Me.TxtNroDocCliente.Text.Trim, CboRemitente, dtRemitenteParalelo, "nrodocumento", "idcontacto_persona")
                Dim iId As Integer = iExisteEsElCliente

                RemoveHandler Me.CboRemitente.SelectedIndexChanged, AddressOf Me.CboRemitente_SelectedIndexChanged
                Me.CboRemitente.DataSource = Nothing
                Me.CboRemitente.Items.Clear()
                Me.CboRemitente.Items.Add(" (SELECCIONE)")
                Me.CboRemitente.Items.Add(Me.TxtNomCliente.Text.Trim)
                Me.TxtNumDocRemitente.Text = Me.TxtNroDocCliente.Text.Trim

                dtRemitente.Rows.Clear()
                Dim dr As DataRow
                dr = dtRemitente.NewRow
                dr("idcontacto_persona") = 0
                dr("nombres") = " (SELECCIONE)"
                dr("nombre") = "" '
                dr("idtipo_documento_contacto") = 0
                dr("nrodocumento") = ""
                dr("apepat") = "" '
                dr("apemat") = "" '
                dtRemitente.Rows.Add(dr)

                dr = dtRemitente.NewRow
                dr("idcontacto_persona") = iId
                dr("nombres") = Me.TxtNomCliente.Text.Trim
                dr("nombre") = sNombresCli '
                dr("idtipo_documento_contacto") = IIf(IsDBNull(dtCliente.Rows(0).Item("tipo")), "", dtCliente.Rows(0).Item("tipo"))
                dr("nrodocumento") = Me.TxtNroDocCliente.Text.Trim
                dr("apepat") = sApCli '
                dr("apemat") = sAmCli '               
                dtRemitente.Rows.Add(dr)

                idRemitente = iId
                sNombreRemitente = sNombresCli
                iID_TipoDocRemitente = iID_TipoDocCli
                sNroDocRemitente = Me.TxtNroDocCliente.Text.Trim
                sApRemitente = sApCli
                sAmRemitente = sAmCli

                AddHandler Me.CboRemitente.SelectedIndexChanged, AddressOf Me.CboRemitente_SelectedIndexChanged
                RemoveHandler Me.CboRemitente.SelectedIndexChanged, AddressOf Me.CboRemitente_SelectedIndexChanged
                Me.CboRemitente.SelectedIndex = 1
                AddHandler Me.CboRemitente.SelectedIndexChanged, AddressOf Me.CboRemitente_SelectedIndexChanged

                Me.ChkCliente2.Focus()
            Else
                MessageBox.Show("Ingrese el Cliente.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ChkCliente.Checked = False
                Me.TxtCliente.Focus()
            End If
        Else
            If dtRemitenteParalelo IsNot Nothing Then
                dtRemitente = dtRemitenteParalelo.Copy
                Me.CboRemitente.DataSource = dtRemitente
                Me.CboRemitente.DisplayMember = "nombres"
                Me.CboRemitente.ValueMember = "idcontacto_persona"
                Me.CboRemitente.SelectedIndex = 0
            Else
                Me.CboRemitente.DataSource = Nothing
                Me.CboRemitente.Items.Clear()
                Me.CboRemitente.Items.Add(" (SELECCIONE)")
                Me.CboRemitente.SelectedIndex = 0
                Me.TxtNumDocRemitente.Text = ""
            End If
        End If
        NombresCont = ""
        apellPatCont = ""
        apellMatCont = ""
    End Sub
#End Region

#Region "CONTACTO"

    '****NOMBRE  CONTACTO********
    Dim idcontacto As Integer
    Private Sub CboContacto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboContacto.SelectedIndexChanged
        If Not IsReference(CboContacto.SelectedValue) Then
            If Not bContactoModificado Then
                idcontacto = CboContacto.SelectedValue
            End If
            Me.TxtNroDocContacto.Text = IIf(IsDBNull(dtContacto.Rows(CboContacto.SelectedIndex).Item("nrodocumento")), "", dtContacto.Rows(CboContacto.SelectedIndex).Item("nrodocumento"))
        ElseIf Me.CboContacto.DataSource Is Nothing Then
            If Me.CboContacto.Items.Count > 1 Then
                Dim iFila As Integer = IIf(CboContacto.SelectedIndex < 0, 0, CboContacto.SelectedIndex)
                Me.TxtNroDocContacto.Text = IIf(IsDBNull(dtContacto.Rows(iFila).Item("nrodocumento")), "", dtContacto.Rows(iFila).Item("nrodocumento"))
            End If
        End If

        RemoveHandler ChkCliente1.CheckedChanged, AddressOf ChkCliente1_CheckedChanged
        If Me.CboContacto.SelectedIndex = 0 Then
            Me.ChkCliente1.Checked = False
        Else
            'Me.ChkCliente1.Checked = IIf(IsDBNull(Me.ChkCliente1.Tag), Me.ChkCliente1.Checked, Me.ChkCliente1.Tag)
            Me.ChkCliente1.Checked = IIf(TxtNroDocCliente.Text = TxtNroDocContacto.Text, 1, 0)
        End If
        AddHandler ChkCliente1.CheckedChanged, AddressOf ChkCliente1_CheckedChanged
    End Sub

    '****CONTACTO) ES EL CLIENTE (
    Private Sub ChkCliente1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCliente1.CheckedChanged
        If ChkCliente1.Checked Then
            If Me.TxtNroDocCliente.Text.Trim.Length > 0 Or Me.TxtNomCliente.Text.Trim.Length > 0 Then

                Dim iExisteEsElCliente As Integer = ExisteEsElCliente(Me.TxtNroDocCliente.Text.Trim, CboContacto, dtContactoParalelo, "nrodocumento", "idcontacto_persona")
                Dim iId As Integer = iExisteEsElCliente

                RemoveHandler Me.CboContacto.SelectedIndexChanged, AddressOf Me.CboContacto_SelectedIndexChanged
                Me.CboContacto.DataSource = Nothing
                Me.CboContacto.Items.Clear()
                Me.CboContacto.Items.Add(" (SELECCIONE)")
                Me.CboContacto.Items.Add(Me.TxtNomCliente.Text.Trim)
                Me.TxtNroDocContacto.Text = Me.TxtNroDocCliente.Text.Trim

                dtContacto.Rows.Clear()
                Dim dr As DataRow
                dr = dtContacto.NewRow
                dr("idcontacto_persona") = 0
                dr("nombres") = " (SELECCIONE)"
                dr("nombre") = ""
                dr("idtipo_documento_contacto") = 0
                dr("nrodocumento") = ""
                dr("apepat") = ""
                dr("apemat") = ""
                dtContacto.Rows.Add(dr)

                dr = dtContacto.NewRow
                dr("idcontacto_persona") = iId
                dr("nombres") = Me.TxtNomCliente.Text.Trim
                dr("nombre") = sNombresCli
                dr("idtipo_documento_contacto") = IIf(IsDBNull(dtCliente.Rows(0).Item("tipo")), "", dtCliente.Rows(0).Item("tipo"))
                dr("nrodocumento") = Me.TxtNroDocCliente.Text.Trim
                dr("apepat") = sApCli
                dr("apemat") = sAmCli
                dtContacto.Rows.Add(dr)

                idcontacto = iId
                NombresCont = sNombresCli
                iID_TipoDocCont = iID_TipoDocCli
                apellPatCont = sApCli
                apellMatCont = sAmCli

                AddHandler Me.CboContacto.SelectedIndexChanged, AddressOf Me.CboContacto_SelectedIndexChanged
                RemoveHandler Me.CboContacto.SelectedIndexChanged, AddressOf Me.CboContacto_SelectedIndexChanged
                Me.CboContacto.SelectedIndex = 1
                AddHandler Me.CboContacto.SelectedIndexChanged, AddressOf Me.CboContacto_SelectedIndexChanged

                Me.ChkCliente2.Focus()
            Else
                MessageBox.Show("Ingrese el Cliente.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ChkCliente1.Checked = False
                Me.TxtCliente.Focus()
            End If
        Else
            If dtContactoParalelo IsNot Nothing Then
                dtContacto = dtContactoParalelo.Copy
                Me.CboContacto.DataSource = dtContacto
                Me.CboContacto.DisplayMember = "nombres"
                Me.CboContacto.ValueMember = "idcontacto_persona"
                Me.CboContacto.SelectedIndex = 0
            Else
                Me.CboContacto.DataSource = Nothing
                Me.CboContacto.Items.Clear()
                Me.CboContacto.Items.Add(" (SELECCIONE)")
                Me.CboContacto.SelectedIndex = 0
                Me.TxtNroDocContacto.Text = ""
            End If
        End If
        NombresCont = ""
        apellPatCont = ""
        apellMatCont = ""
    End Sub

#End Region

#Region "CONSIGNADO"

    '***BUSCAR CONSIGNADO**
    Dim iIDConsignado As Integer
    Private Sub BtnConsignado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsignado.Click
        Dim frm As New FrmConsignado
        frm.iFicha = 1
        Dim iFila As Integer = 0
        Dim sNumero As String = ""
        Dim sConsignado As String = ""
        Dim sNombresConsig As String = ""
        Dim sApePConsig As String = ""
        Dim sApeMConsig As String = ""
        Dim sTelfConsig As String = ""
        Dim iTipo As Integer = 3 '18112011
        Dim iDepartamento As Integer
        Dim iProvincia As Integer
        Dim iDistrito As Integer
        Dim iId_via As Integer
        Dim sVia As String = ""
        Dim sNumero2 As String = ""
        Dim sManzana As String = ""
        Dim sLote As String = ""
        Dim iId_Nivel As Integer
        Dim sNivel As String = ""
        Dim iId_Zona As Integer
        Dim sZona As String = ""
        Dim iId_Clasificacion As Integer
        Dim sClasificacion As String = ""
        Dim bEsCliente As Boolean = False
        sReferencia = "" 'CambioR 18112011

        'Comentado x NConsignado
        'If Me.TxtNroDocConsignado.Text.Trim.Length > 0 Or Me.TxtNombConsignado.Text.Trim.Length > 0 Then
        'Agregado(Reemplasado) x NConsignado
        If Me.GrdNConsignado.Rows.Count > 0 Then
            '--Comentado x NConsignado--
            'sNumero = IIf(IsDBNull(dtConsignado.Rows(0).Item("nrodocumento")), "", dtConsignado.Rows(0).Item("nrodocumento")) 'Me.TxtNroDocCliente.Text.Trim
            'sConsignado = IIf(IsDBNull(dtConsignado.Rows(0).Item("nombres")), "", dtConsignado.Rows(0).Item("nombres"))
            'sNombresConsig = IIf(IsDBNull(dtConsignado.Rows(0).Item("nombre")), "", dtConsignado.Rows(0).Item("nombre"))
            'iTipo = IIf(IsDBNull(dtConsignado.Rows(0).Item("tipo")), "", dtConsignado.Rows(0).Item("tipo"))
            'sApePConsig = IIf(IsDBNull(dtConsignado.Rows(0).Item("apepat")), "", dtConsignado.Rows(0).Item("apepat"))
            'sApeMConsig = IIf(IsDBNull(dtConsignado.Rows(0).Item("apemat")), "", dtConsignado.Rows(0).Item("apemat"))
            'sTelfConsig = IIf(IsDBNull(dtConsignado.Rows(0).Item("telefono")), "", dtConsignado.Rows(0).Item("telefono"))

            '==agregado x NConsignado===
            bConsignadoNuevo = False
            'bExiste = True

            Dim iIndice As Integer = Me.GrdNConsignado.CurrentCell.RowIndex
            iIDConsignado = GrdNConsignado("IDConsignado", iIndice).Value
            sNumero = GrdNConsignado("Nº Documento", iIndice).Value
            sConsignado = GrdNConsignado("Nombres", iIndice).Value
            sNombresConsig = GrdNConsignado("nombre", iIndice).Value
            iTipo = GrdNConsignado("tipo", iIndice).Value
            sApePConsig = GrdNConsignado("apepat", iIndice).Value
            sApeMConsig = GrdNConsignado("apemat", iIndice).Value
            sTelfConsig = GrdNConsignado("Telefono", iIndice).Value
            '=============================

            '01092011
            If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio And CboDireccion2.SelectedIndex > 0 Then
                iFila = Me.CboDireccion2.SelectedIndex
                iDepartamento = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("iddepartamento")), 0, dtDireccion2.Rows(iFila).Item("iddepartamento"))
                iProvincia = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("idprovincia")), 0, dtDireccion2.Rows(iFila).Item("idprovincia"))
                iDistrito = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("iddistrito")), 0, dtDireccion2.Rows(iFila).Item("iddistrito"))
                iId_via = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_via")), 0, dtDireccion2.Rows(iFila).Item("id_via"))
                sVia = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("via")), "", dtDireccion2.Rows(iFila).Item("via"))
                sNumero2 = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("numero")), "", dtDireccion2.Rows(iFila).Item("numero"))
                sManzana = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("manzana")), "", dtDireccion2.Rows(iFila).Item("manzana"))
                sLote = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("lote")), "", dtDireccion2.Rows(iFila).Item("lote"))
                iId_Nivel = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_nivel")), 0, dtDireccion2.Rows(iFila).Item("id_nivel"))
                sNivel = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("nivel")), "", dtDireccion2.Rows(iFila).Item("nivel"))
                iId_Zona = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_zona")), 0, dtDireccion2.Rows(iFila).Item("id_zona"))
                sZona = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("zona")), "", dtDireccion2.Rows(iFila).Item("zona"))
                iId_Clasificacion = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("Id_Clasificacion")), 0, dtDireccion2.Rows(iFila).Item("Id_Clasificacion"))
                sClasificacion = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("Clasificacion")), "", dtDireccion2.Rows(iFila).Item("Clasificacion"))
                sReferencia = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("De_Referencia")), "", dtDireccion2.Rows(iFila).Item("De_Referencia"))
            End If
            bEsCliente = Me.ChkCliente2.Checked
            'Else
            '    sNumero = IIf(IsDBNull(dtConsignado.Rows(0).Item("nrodocumento")), "", dtConsignado.Rows(0).Item("nrodocumento")) 'Me.TxtNroDocCliente.Text.Trim
            '    sConsignado = IIf(IsDBNull(dtConsignado.Rows(0).Item("nombres")), "", dtConsignado.Rows(0).Item("nombres"))
            '    sNombresConsig = IIf(IsDBNull(dtConsignado.Rows(0).Item("nombre")), "", dtConsignado.Rows(0).Item("nombre"))
            '    iTipo = IIf(IsDBNull(dtConsignado.Rows(0).Item("tipo")), "", dtConsignado.Rows(0).Item("tipo"))
            '    sApePConsig = IIf(IsDBNull(dtConsignado.Rows(0).Item("apepat")), "", dtConsignado.Rows(0).Item("apepat"))
            '    sApeMConsig = IIf(IsDBNull(dtConsignado.Rows(0).Item("apemat")), "", dtConsignado.Rows(0).Item("apemat"))
            '    sTelfConsig = IIf(IsDBNull(dtConsignado.Rows(0).Item("telefono")), "", dtConsignado.Rows(0).Item("telefono"))

            '    If bBoleto = False Then
            '        If Me.CboTipoEntrega.SelectedIndex = 1 Then
            '            iFila = Me.CboDireccion2.SelectedIndex
            '            iDepartamento = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("iddepartamento")), 0, dtDireccion2.Rows(iFila).Item("iddepartamento"))
            '            iProvincia = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("idprovincia")), 0, dtDireccion2.Rows(iFila).Item("idprovincia"))
            '            iDistrito = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("iddistrito")), 0, dtDireccion2.Rows(iFila).Item("iddistrito"))
            '            iId_via = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_via")), 0, dtDireccion2.Rows(iFila).Item("id_via"))
            '            sVia = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("via")), "", dtDireccion2.Rows(iFila).Item("via"))
            '            sNumero2 = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("numero")), "", dtDireccion2.Rows(iFila).Item("numero"))
            '            sManzana = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("manzana")), "", dtDireccion2.Rows(iFila).Item("manzana"))
            '            sLote = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("lote")), "", dtDireccion2.Rows(iFila).Item("lote"))
            '            iId_Nivel = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_nivel")), 0, dtDireccion2.Rows(iFila).Item("id_nivel"))
            '            sNivel = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("nivel")), "", dtDireccion2.Rows(iFila).Item("nivel"))
            '            iId_Zona = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_zona")), 0, dtDireccion2.Rows(iFila).Item("id_zona"))
            '            sZona = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("zona")), "", dtDireccion2.Rows(iFila).Item("zona"))
            '            iId_Clasificacion = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("Id_Clasificacion")), 0, dtDireccion2.Rows(iFila).Item("Id_Clasificacion"))
            '            sClasificacion = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("Clasificacion")), "", dtDireccion2.Rows(iFila).Item("Clasificacion"))
            '        End If
            '        bEsCliente = Me.ChkCliente2.Checked
            '    End If
            'End If
        End If
        '01092011
        If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio And CboDireccion2.SelectedIndex > 0 Then
            iFila = Me.CboDireccion2.SelectedIndex
            iDepartamento = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("iddepartamento")), 0, dtDireccion2.Rows(iFila).Item("iddepartamento"))
            iProvincia = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("idprovincia")), 0, dtDireccion2.Rows(iFila).Item("idprovincia"))
            iDistrito = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("iddistrito")), 0, dtDireccion2.Rows(iFila).Item("iddistrito"))
            iId_via = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_via")), 0, dtDireccion2.Rows(iFila).Item("id_via"))
            sVia = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("via")), "", dtDireccion2.Rows(iFila).Item("via"))
            sNumero2 = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("numero")), "", dtDireccion2.Rows(iFila).Item("numero"))
            sManzana = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("manzana")), "", dtDireccion2.Rows(iFila).Item("manzana"))
            sLote = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("lote")), "", dtDireccion2.Rows(iFila).Item("lote"))
            iId_Nivel = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_nivel")), 0, dtDireccion2.Rows(iFila).Item("id_nivel"))
            sNivel = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("nivel")), "", dtDireccion2.Rows(iFila).Item("nivel"))
            iId_Zona = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_zona")), 0, dtDireccion2.Rows(iFila).Item("id_zona"))
            sZona = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("zona")), "", dtDireccion2.Rows(iFila).Item("zona"))
            iId_Clasificacion = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("Id_Clasificacion")), 0, dtDireccion2.Rows(iFila).Item("Id_Clasificacion"))
            sClasificacion = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("Clasificacion")), "", dtDireccion2.Rows(iFila).Item("Clasificacion"))
            sReferencia = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("De_Referencia")), "", dtDireccion2.Rows(iFila).Item("De_Referencia"))
        End If

        frm.cargar(iTipo, sNumero, sRazonSocialCliente, sConsignado, sNombresConsig, bEsCliente, iDepartamento, iProvincia, iDistrito, iId_via, sVia, sNumero2, _
                   sManzana, sLote, iId_Nivel, sNivel, iId_Zona, sZona, iId_Clasificacion, sClasificacion, sApePConsig, sApeMConsig, sTelfConsig, sNombresCli,
                   sApCli, sAmCli, sTelfCliente, sReferencia, iIDConsignado) '09092011

        If Me.GrdNConsignado.Rows.Count = 0 Then bConsignadoNuevo = True 'CambioR 18112011
        frm.bConsignadoNuevo = bConsignadoNuevo
        frm.iTipoEntrega = Me.CboTipoEntrega.SelectedValue

        iTipoDoc = 0
        If Not (dtCliente Is Nothing) Then
            If bBoleto Then
                'iTipoDoc = IIf(IsDBNull(dtCliente.Rows(0).Item("tipo")), "", ObtieneTipoDocumento(dtCliente.Rows(0).Item("tipo")))
                iTipoDoc = IIf(IsDBNull(dtCliente.Rows(0).Item("tipo")), "", dtCliente.Rows(0).Item("tipo"))
            Else
                iTipoDoc = IIf(IsDBNull(dtCliente.Rows(0).Item("tipo")), "", dtCliente.Rows(0).Item("tipo"))
            End If
        End If

        frm.iTipoDoc = iTipoDoc '--
        frm.sNumeroDoc = Me.TxtNroDocCliente.Text.Trim
        frm.snombre = Me.TxtNomCliente.Text.Trim
        frm.idUnidadAgencias = idUnidadAgencias
        '
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.AppStarting
            Me.CargarConsignado(frm)
            Me.Cursor = Cursors.Default
        End If

        'Dim frm As New FrmConsignado
        'frm.iFicha = 1
        'frm.ShowDialog()
        'If frm.DialogResult = Windows.Forms.DialogResult.OK Then
        '    frm.iTipoEntrega = Me.CboTipoEntrega.SelectedIndex
        '    CargarConsignado(frm)
        'End If
    End Sub

    '***ES EL CLIENTE PARA EL CONSIGNADO**
    Private Sub ChkCliente2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCliente2.CheckedChanged
        Static i As Integer = 0
        If ChkCliente2.Checked Then
            If Me.TxtNroDocCliente.Text.Trim.Length > 0 Or Me.TxtNomCliente.Text.Trim.Length > 0 Then
                dtConsignado = New DataTable
                dtConsignado.Columns.Add(New DataColumn("idcontacto_persona", GetType(Integer)))
                dtConsignado.Columns.Add(New DataColumn("nombres", GetType(String)))
                dtConsignado.Columns.Add(New DataColumn("nombre", GetType(String))) 'new
                dtConsignado.Columns.Add(New DataColumn("tipo", GetType(Integer)))
                dtConsignado.Columns.Add(New DataColumn("nrodocumento", GetType(String)))
                dtConsignado.Columns.Add(New DataColumn("telefono", GetType(String)))
                dtConsignado.Columns.Add(New DataColumn("apepat", GetType(String)))
                dtConsignado.Columns.Add(New DataColumn("apemat", GetType(String)))

                Dim dr As DataRow
                dr = dtConsignado.NewRow
                dr("idcontacto_persona") = 0
                dr("nombres") = Me.TxtNomCliente.Text.Trim
                dr("nombre") = sNombresCli.Trim 'new
                dr("tipo") = iID_TipoDocCli
                dr("nrodocumento") = Me.TxtNroDocCliente.Text.Trim
                dr("apepat") = sApCli
                dr("apemat") = sAmCli
                dr("telefono") = sTelfCliente
                dtConsignado.Rows.Add(dr)

                '***Comentado x Nconsignado***
                'Me.TxtNroDocConsignado.Tag = 0
                '==Agregado x Nconsignado==
                iNroDocumentoTag = 0
                '===

                iIDConsignado = 0
                'Me.TxtNroDocConsignado.Text = Me.TxtNroDocCliente.Text.Trim
                'Me.TxtNombConsignado.Text = Me.TxtNomCliente.Text.Trim
                sNombresConsig = sNombresCli.Trim
                iID_TipoDocConsig = iID_TipoDocCli
                sapellPatConsig = sApCli
                sapellMatConsig = sAmCli
                sTelefonoConsig = Me.TxtTelfCliente.Text.Trim
                'Me.TxtTelfConsignado.Text = Me.TxtTelfCliente.Text.Trim
                '******************************

                bConsignadoNuevo = True
                bConsignadoModificado = False
                Me.CboDireccion2.Focus()

                '=====Agregado x NConsignado======================
                GrdNConsignado.Rows.Clear()
                GrdNConsignado.Rows.Add()
                GrdNConsignado("IDConsignado", 0).Value = 0
                GrdNConsignado("Nº Documento", 0).Value = Me.TxtNroDocCliente.Text.Trim
                GrdNConsignado("Nombres", 0).Value = Me.TxtNomCliente.Text.Trim
                GrdNConsignado("Telefono", 0).Value = Me.TxtTelfCliente.Text.Trim
                GrdNConsignado("nombre", 0).Value = sNombresCli
                GrdNConsignado("tipo", 0).Value = iID_TipoDocCli
                GrdNConsignado("apepat", 0).Value = sApCli
                GrdNConsignado("apemat", 0).Value = sAmCli
                GrdNConsignado("Modificado", 0).Value = "0"
                '==================================================
            Else
                MessageBox.Show("Ingrese el Cliente.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                i = 1
                Me.ChkCliente2.Checked = False
                Me.TxtCliente.Focus()
            End If
        Else
            If i = 0 Then
                dtConsignado.Rows.Clear()
                '==Agregado x Nconsignado============
                GrdNConsignado.Rows.Clear()
                '====================================

                '***Comentado x NConsignado**********
                'Me.TxtNroDocConsignado.Text = ""
                'Me.TxtNombConsignado.Text = ""
                'Me.TxtTelfConsignado.Text = ""
                '************************************
            Else
                i = 0
            End If
        End If
    End Sub

    '***BUSCAR CONSIGNADO*****************
    Sub BuscarConsignado()
        Try
            Me.Cursor = Cursors.AppStarting
            Dim iOpcion As Integer = IIf(Me.RbtDocumento3.Checked, 1, 2)
            Dim frm As New FrmConsignado
            Dim sConsignado As String = Me.TxtConsignado.Text.Trim
            Dim iConsignado As Integer
            Dim obj As New dtoVentaCargaContado
            Dim ds As DataSet = obj.BuscarConsignado(sConsignado, iOpcion, idUnidadAgencias)
            dtConsignado = ds.Tables(0)
            bConsignadoNuevo = True

            If ds.Tables(0).Rows.Count = 0 Then
                Me.Cursor = Cursors.Default
                MessageBox.Show("El Consignado no Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)

                '****CambioR 18112011********
                Dim iFila As Integer = 0
                Dim sNumero As String = ""
                sConsignado = ""
                Dim sNombresConsig As String = ""
                Dim sApePConsig As String = ""
                Dim sApeMConsig As String = ""
                Dim sTelfConsig As String = ""
                Dim iDepartamento As Integer
                Dim iProvincia As Integer
                Dim iDistrito As Integer
                Dim iId_via As Integer
                Dim sVia As String = ""
                Dim sNumero2 As String = ""
                Dim sManzana As String = ""
                Dim sLote As String = ""
                Dim iId_Nivel As Integer
                Dim sNivel As String = ""
                Dim iId_Zona As Integer
                Dim sZona As String = ""
                Dim iId_Clasificacion As Integer
                Dim sClasificacion As String = ""
                sReferencia = ""

                'Me.LimpiarConsignado()'Gunners
                If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio And CboDireccion2.SelectedIndex > 0 Then
                    iFila = Me.CboDireccion2.SelectedIndex
                    iDepartamento = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("iddepartamento")), 0, dtDireccion2.Rows(iFila).Item("iddepartamento"))
                    iProvincia = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("idprovincia")), 0, dtDireccion2.Rows(iFila).Item("idprovincia"))
                    iDistrito = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("iddistrito")), 0, dtDireccion2.Rows(iFila).Item("iddistrito"))
                    iId_via = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_via")), 0, dtDireccion2.Rows(iFila).Item("id_via"))
                    sVia = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("via")), "", dtDireccion2.Rows(iFila).Item("via"))
                    sNumero2 = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("numero")), "", dtDireccion2.Rows(iFila).Item("numero"))
                    sManzana = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("manzana")), "", dtDireccion2.Rows(iFila).Item("manzana"))
                    sLote = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("lote")), "", dtDireccion2.Rows(iFila).Item("lote"))
                    iId_Nivel = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_nivel")), 0, dtDireccion2.Rows(iFila).Item("id_nivel"))
                    sNivel = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("nivel")), "", dtDireccion2.Rows(iFila).Item("nivel"))
                    iId_Zona = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("id_zona")), 0, dtDireccion2.Rows(iFila).Item("id_zona"))
                    sZona = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("zona")), "", dtDireccion2.Rows(iFila).Item("zona"))
                    iId_Clasificacion = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("Id_Clasificacion")), 0, dtDireccion2.Rows(iFila).Item("Id_Clasificacion"))
                    sClasificacion = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("Clasificacion")), "", dtDireccion2.Rows(iFila).Item("Clasificacion"))
                    sReferencia = IIf(IsDBNull(dtDireccion2.Rows(iFila).Item("De_Referencia")), "", dtDireccion2.Rows(iFila).Item("De_Referencia"))
                End If

                frm.cargar(3, sNumero, sRazonSocialCliente, sConsignado, sNombresConsig, 0, iDepartamento, iProvincia, iDistrito, iId_via, sVia, sNumero2, _
                   sManzana, sLote, iId_Nivel, sNivel, iId_Zona, sZona, iId_Clasificacion, sClasificacion, sApePConsig, sApeMConsig, sTelfConsig, sNombresCli,
                   sApCli, sAmCli, sTelfCliente, sReferencia, iIDConsignado)
                '******************************

                '===Agregado x NConsignado=====
                If Me.ChkCliente2.Checked Then Me.ChkCliente2.Checked = False
                bExiste = False
                '==============================
                frm.bConsignadoNuevo = bConsignadoNuevo
                frm.iTipoEntrega = Me.CboTipoEntrega.SelectedValue
                frm.iFicha = 1
                frm.TxtNumero.Text = IIf(RbtDocumento3.Checked, sConsignado.Trim, "") '22092011 Agregado ayuda nroDocumento
                frm.idUnidadAgencias = idUnidadAgencias
                frm.ShowDialog()
                Me.Cursor = Cursors.Default
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    CargarConsignado(frm)
                End If
            ElseIf ds.Tables(0).Rows.Count = 1 Then
                Me.MostrarConsignado(ds)
                Me.Cursor = Cursors.Default
            Else
                frm = New FrmConsignado
                frm.iFicha = 0
                frm.idUnidadAgencias = idUnidadAgencias
                frm.cargar(ds.Tables(0), 2)
                frm.ShowDialog()
                Me.Cursor = Cursors.Default
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    ds = obj.BuscarConsignado(frm.TxtNumero.Tag)
                    dtConsignado = ds.Tables(0)
                    Me.MostrarConsignado(ds)
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '***CARGAR CONSIGNADO*****************
    Public bDirecConsigMod, bConsignadoModificado As Boolean
    Dim sNombresConsig As String = ""
    Dim sReferencia As String = "" '09092011
    Dim sapellPatConsig As String = ""
    Dim sapellMatConsig As String = ""
    Dim sTelefonoConsig As String = "" '-->datos consignado
    Dim iID_TipoDocConsig As Integer = 0
    'direccion
    Dim iDepartamentoConsig, iProvinciaConsig, iDistritoConsig, IDviaConsig, id_NivelConsig, id_ZonaConsig, id_ClasificacionConsig, FormatoConsig As Integer
    Dim ViaConsig, ManzanaConsig, loteConsig, NivelConsig, ZonaConsig, NroConsig, ClasificacionConsig As String

    Sub CargarConsignado(ByVal frm As FrmConsignado)
        If frm.bConsignadoNuevo Then
            '***Comentado x NConsignado****
            'TxtNroDocConsignado.Tag = 0
            '******************************

            '===Agregado x NConsignado=====
            iNroDocumentoTag = 0
            '==============================
        End If

        '***Comentado x NConsignado***************************
        'Me.TxtNroDocConsignado.Text = frm.TxtNumero.Text.Trim
        'Me.TxtNombConsignado.Text = frm.TxtConsignado.Text.Trim & " " & frm.txtapePConsig.Text & " " & frm.txtapeMConsig.Text
        'Me.TxtTelfConsignado.Text = frm.txtTelefono.Text.Trim       
        ''*****************************************************

        Me.TxtReferencia.Text = frm.TxtReferencia.Text.Trim '09092011
        iID_TipoDocConsig = frm.CboTipoDocumento.SelectedValue
        sNombresConsig = frm.TxtConsignado.Text.Trim
        sReferencia = frm.TxtReferencia.Text.Trim '09092011
        sapellPatConsig = frm.txtapePConsig.Text.Trim
        sapellMatConsig = frm.txtapeMConsig.Text.Trim
        sTelefonoConsig = frm.txtTelefono.Text.Trim
        '--
        bDirecConsigMod = frm.bDirecConsigMod
        bConsignadoModificado = frm.bConsignadoModificado

        If frm.TabConsignado.SelectedIndex = 0 Then
            '***Comentado x NConsignado*****************************
            'Me.TxtNroDocConsignado.Text = frm.TxtNumero.Text.Trim            
            Dim obj As New dtoVentaCargaContado
            Dim ds As DataSet = obj.BuscarConsignado(frm.TxtNumero.Text, 1, dtoUSUARIOS.m_idciudad)
            dtConsignado = ds.Tables(0)
            Me.MostrarConsignado(ds)
        ElseIf frm.TabConsignado.SelectedIndex = 1 Then
            Dim dr As DataRow
            'consignado
            dtConsignado = New DataTable
            dtConsignado.Columns.Add(New DataColumn("idcontacto_persona", GetType(Integer)))
            dtConsignado.Columns.Add(New DataColumn("nombres", GetType(String)))
            dtConsignado.Columns.Add(New DataColumn("nombre", GetType(String)))
            'dtConsignado.Columns.Add(New DataColumn("idtipo_documento_contacto", GetType(Integer)))
            dtConsignado.Columns.Add(New DataColumn("tipo", GetType(Integer)))
            dtConsignado.Columns.Add(New DataColumn("nrodocumento", GetType(String)))
            dtConsignado.Columns.Add(New DataColumn("apepat", GetType(String)))
            dtConsignado.Columns.Add(New DataColumn("apemat", GetType(String)))
            dtConsignado.Columns.Add(New DataColumn("telefono", GetType(String)))
            dr = dtConsignado.NewRow

            bConsignadoNuevo = frm.bConsignadoNuevo
            If frm.bConsignadoNuevo Then
                iIDConsignado = 0
                '===Agregado x NConsignado======
                'bExiste = False
                If ChkCliente2.Checked Then GrdNConsignado.Rows.Clear()
                '===============================
            End If

            dr("idcontacto_persona") = iIDConsignado
            dr("nombres") = frm.TxtConsignado.Text.Trim & " " & frm.txtapePConsig.Text.Trim & " " & frm.txtapeMConsig.Text.Trim
            dr("nombre") = frm.TxtConsignado.Text.Trim
            'dr("idtipo_documento_contacto") = frm.CboTipoDocumento.SelectedValue
            dr("tipo") = frm.CboTipoDocumento.SelectedValue
            dr("nrodocumento") = frm.TxtNumero.Text.Trim
            dr("apepat") = frm.txtapePConsig.Text.Trim
            dr("apemat") = frm.txtapeMConsig.Text.Trim
            dr("telefono") = frm.txtTelefono.Text.Trim
            dtConsignado.Rows.Add(dr)

            RemoveHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
            Me.ChkCliente2.Checked = frm.ChkCliente.Checked
            'Me.ChkCliente1.Tag = Me.ChkCliente1.Checked
            AddHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged

            '=======================Agregado x NConsignado========================================
            '19-10-2011
            Dim iIndice As Integer = -1
            If Me.GrdNConsignado.Rows.Count > 0 And Not bConsignadoNuevo Then
                iIndice = Me.GrdNConsignado.CurrentCell.RowIndex
            End If
            If bConsignadoNuevo And frm.TxtNumero.Text.Trim.Length > 0 Then
                iIndice = ValorGrid(Me.GrdNConsignado, "Nº Documento", frm.TxtNumero.Text.Trim)
            End If

            If iIDConsignado = 0 And iIndice = -1 Then
                row = GrdNConsignado.Rows.Count()
                GrdNConsignado.Rows.Add()
                GrdNConsignado("IDConsignado", row).Value = iIDConsignado
                GrdNConsignado("Nº Documento", row).Value = frm.TxtNumero.Text.Trim
                GrdNConsignado("Nombres", row).Value = frm.TxtConsignado.Text.Trim & " " & frm.txtapePConsig.Text.Trim & " " & frm.txtapeMConsig.Text.Trim
                GrdNConsignado("Telefono", row).Value = frm.txtTelefono.Text.Trim
                GrdNConsignado("nombre", row).Value = frm.TxtConsignado.Text.Trim
                GrdNConsignado("tipo", row).Value = frm.CboTipoDocumento.SelectedValue
                GrdNConsignado("apepat", row).Value = frm.txtapePConsig.Text.Trim
                GrdNConsignado("apemat", row).Value = frm.txtapeMConsig.Text.Trim
                GrdNConsignado("Modificado", row).Value = 0
            Else
                GrdNConsignado("Nº Documento", iIndice).Value = frm.TxtNumero.Text.Trim
                GrdNConsignado("Nombres", iIndice).Value = frm.TxtConsignado.Text.Trim & " " & frm.txtapePConsig.Text.Trim & " " & frm.txtapeMConsig.Text.Trim
                GrdNConsignado("Telefono", iIndice).Value = frm.txtTelefono.Text.Trim
                GrdNConsignado("nombre", iIndice).Value = frm.TxtConsignado.Text.Trim
                GrdNConsignado("tipo", iIndice).Value = frm.CboTipoDocumento.SelectedValue
                GrdNConsignado("apepat", iIndice).Value = frm.txtapePConsig.Text.Trim
                GrdNConsignado("apemat", iIndice).Value = frm.txtapeMConsig.Text.Trim
                If bConsignadoModificado Then
                    GrdNConsignado("Modificado", iIndice).Value = 1
                End If
            End If
            '=====================================================================================

            If frm.bDirecConsigMod AndAlso CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                Me.CboDireccion2.DataSource = Nothing
                Me.CboDireccion2.Items.Clear()
                '-----------
                iDepartamentoConsig = frm.CboDepartamento.SelectedValue
                iProvinciaConsig = frm.CboProvincia.SelectedValue
                iDistritoConsig = frm.CboDistrito.SelectedValue
                IDviaConsig = frm.CboVia.SelectedValue
                ViaConsig = frm.TxtVia.Text
                NroConsig = frm.TxtNumero2.Text
                ManzanaConsig = frm.TxtManzana.Text
                loteConsig = frm.TxtLote.Text
                id_NivelConsig = frm.CboNivel.SelectedValue
                NivelConsig = frm.TxtNivel.Text
                id_ZonaConsig = frm.CboZona.SelectedValue
                ZonaConsig = frm.TxtZona.Text
                id_ClasificacionConsig = frm.CboClasificacion.SelectedValue
                ClasificacionConsig = frm.TxtClasificacion.Text
                If bDireccionModificada Then FormatoConsig = 1
                '-----------

                'Dirección
                'Dim sDireccion As String = frm.CboVia.Text & " " & frm.TxtVia.Text.Trim & " "
                Dim sDireccion As String = IIf(frm.CboVia.SelectedValue = 0, "", frm.CboVia.Text) & " " & frm.TxtVia.Text.Trim & " " 'Cambio 03102011                
                If frm.TxtNumero2.Text.Trim.Length > 0 Then
                    sDireccion &= frm.TxtNumero2.Text.Trim & " "
                End If

                If frm.TxtManzana.Text.Trim.Length > 0 Then
                    sDireccion &= "MZ " & frm.TxtManzana.Text.Trim & " LT " & frm.TxtLote.Text.Trim & " "
                End If

                If frm.CboNivel.SelectedValue > 0 Then
                    sDireccion &= frm.CboNivel.Text & " " & frm.TxtNivel.Text.Trim & " "
                End If

                '20-10-2011
                If frm.CboZona.SelectedValue > 0 Then
                    sDireccion &= frm.CboZona.Text & " " & frm.TxtZona.Text.Trim & " "
                End If

                If frm.CboClasificacion.SelectedValue > 0 Then
                    sDireccion &= frm.CboClasificacion.Text & " " & frm.TxtClasificacion.Text.Trim & " "
                End If

                If frm.CboDistrito.SelectedValue > 0 Then
                    sDireccion &= frm.CboDistrito.Text
                End If

                dtDireccion2 = New DataTable
                dtDireccion2.Columns.Add(New DataColumn("iddireccion_consignado", GetType(Integer)))
                dtDireccion2.Columns.Add(New DataColumn("direccion", GetType(String)))
                dtDireccion2.Columns.Add(New DataColumn("id_via", GetType(Integer)))
                dtDireccion2.Columns.Add(New DataColumn("via", GetType(String)))
                dtDireccion2.Columns.Add(New DataColumn("numero", GetType(String)))
                dtDireccion2.Columns.Add(New DataColumn("manzana", GetType(String)))
                dtDireccion2.Columns.Add(New DataColumn("lote", GetType(String)))
                dtDireccion2.Columns.Add(New DataColumn("id_nivel", GetType(Integer)))
                dtDireccion2.Columns.Add(New DataColumn("nivel", GetType(String)))
                dtDireccion2.Columns.Add(New DataColumn("id_zona", GetType(Integer)))
                dtDireccion2.Columns.Add(New DataColumn("zona", GetType(String)))
                dtDireccion2.Columns.Add(New DataColumn("id_clasificacion", GetType(Integer)))
                dtDireccion2.Columns.Add(New DataColumn("clasificacion", GetType(String)))
                dtDireccion2.Columns.Add(New DataColumn("iddepartamento", GetType(Integer)))
                dtDireccion2.Columns.Add(New DataColumn("idprovincia", GetType(Integer)))
                dtDireccion2.Columns.Add(New DataColumn("iddistrito", GetType(Integer)))
                dtDireccion2.Columns.Add(New DataColumn("de_referencia", GetType(String))) '09092011

                dr = dtDireccion2.NewRow
                dr("iddireccion_consignado") = 0
                dr("direccion") = " (SELECCIONE)"
                dr("id_via") = 0
                dr("via") = ""
                dr("numero") = ""
                dr("manzana") = ""
                dr("lote") = ""
                dr("id_nivel") = 0
                dr("nivel") = ""
                dr("id_zona") = 0
                dr("zona") = ""
                dr("id_clasificacion") = 0
                dr("clasificacion") = ""
                dr("iddepartamento") = 0
                dr("idprovincia") = 0
                dr("iddistrito") = 0
                dr("de_referencia") = ""
                dtDireccion2.Rows.Add(dr)

                dr = dtDireccion2.NewRow
                dr("iddireccion_consignado") = -1
                'dr("direccion") = sDireccion
                dr("direccion") = sDireccion.Trim 'Cambio 03102011
                dr("id_via") = frm.CboVia.SelectedValue
                dr("via") = frm.TxtVia.Text.Trim
                dr("numero") = frm.TxtNumero2.Text.Trim
                dr("manzana") = frm.TxtManzana.Text.Trim
                dr("lote") = frm.TxtLote.Text.Trim
                dr("id_nivel") = frm.CboNivel.SelectedValue
                dr("nivel") = frm.TxtNivel.Text.Trim
                dr("id_zona") = frm.CboZona.SelectedValue
                dr("zona") = frm.TxtZona.Text.Trim
                dr("id_clasificacion") = frm.CboClasificacion.SelectedValue
                dr("clasificacion") = frm.TxtClasificacion.Text.Trim
                dr("iddepartamento") = frm.CboDepartamento.SelectedValue
                dr("idprovincia") = frm.CboProvincia.SelectedValue
                dr("iddistrito") = frm.CboDistrito.SelectedValue
                dr("de_referencia") = frm.TxtReferencia.Text.Trim '09092011
                dtDireccion2.Rows.Add(dr)

                Me.CboDireccion2.DataSource = dtDireccion2
                CboDireccion2.DisplayMember = "direccion"
                CboDireccion2.ValueMember = "iddireccion_consignado"
                Me.CboDireccion2.SelectedIndex = 1
            End If

            '***Comentado x NConsignado******************************
            'If TxtNroDocCliente.Text.Trim.Length > 0 Then
            '    Me.ChkCliente2.Checked = IIf(TxtNroDocCliente.Text = TxtNroDocConsignado.Text, 1, 0)
            'End If
            '********************************************************
        End If        
    End Sub

    '***DIREECCION CONSIGNADO*************
    Dim idDireConsignado As Integer
    Private Sub CboDireccion2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDireccion2.SelectedIndexChanged
        Try
            If CboDireccion2.SelectedIndex = 0 Then '09092011
                TxtReferencia.Text = ""
            Else
                TxtReferencia.Text = IIf(IsDBNull(dtDireccion2.Rows(CboDireccion2.SelectedIndex).Item("de_referencia")), "", dtDireccion2.Rows(CboDireccion2.SelectedIndex).Item("de_referencia"))
                sReferencia = TxtReferencia.Text.Trim
            End If

            If Not bDirecConsigMod Then
                idDireConsignado = CboDireccion2.SelectedValue
            End If
            Me.GrdDetalleVenta.Focus()
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "DESCUENTO"

    Private Sub TxtDescuento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDescuento.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf e.KeyChar = "." Then
                If Not (tb.SelectedText = ".") Then
                    e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
                End If
            ElseIf e.KeyChar = "-" Then
                If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
                    e.Handled = True
                End If
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TxtDescuento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDescuento.LostFocus
        'If Val(TxtTotal.Text) = monto_minimo_PCE Then
        '    TxtDescuento.Text = ""
        '    TxtDescuento.Enabled = False
        '    txtDescDescto.Text = ""
        '    txtDescDescto.Enabled = False
        'End If
    End Sub

    Private Sub TxtDescuento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescuento.TextChanged
        Try
            If Val(TxtDescuento.Text) > 0 Or Val(TxtDescuento.Text) < 0 Then
                txtDescDescto.Text = ""
                'hlamas 07-12-2015
                'txtDescDescto.Enabled = True
                'TxtDescuento.ReadOnly = False
                If Val(TxtDescuento.Text) > 0 Then
                    Me.btnAutorizar.Enabled = True
                    txtDescDescto.Enabled = False
                Else
                    Me.btnAutorizar.Enabled = False
                    txtDescDescto.Enabled = True
                    TxtDescuento.ReadOnly = False
                End If
            Else
                'hlamas 07-12-2015
                Me.btnAutorizar.Enabled = False
                txtDescDescto.Enabled = False
                txtDescDescto.Text = ""
            End If

            If bMontoMinimo = False Then
                '**Calculando Descuento**
                If ChkM3.Checked = True Then
                    Me.DescuentoM3()
                Else
                    If Me.CboTipo.SelectedValue = 1 Then
                        Me.fnCalcularCostoDescuento()
                    Else
                        Total_Pagar(0, 0)
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        'Try
        '    If Val(TxtDescuento.Text) > 0 Or Val(TxtDescuento.Text) < 0 Then
        '        txtDescDescto.Enabled = True
        '        txtDescDescto.Text = ""
        '        'TxtDescuento.ReadOnly = False
        '    Else
        '        txtDescDescto.Enabled = False
        '        txtDescDescto.Text = ""
        '    End If

        '    If bMontoMinimo = False Then
        '        '**Calculando Descuento**
        '        If ChkM3.Checked = True Then
        '            Me.DescuentoM3()
        '        Else
        '            'hlamas 09-05-2015
        '            If Me.CboTipo.SelectedValue = 1 Then
        '                Me.fnCalcularCostoDescuento()
        '            End If
        '        End If
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Dim iControlFacturacion As Double = 0
    Private Sub fnCalcularCostoDescuento()
        Try
            Dim valor1 As Double = 0
            Dim valor2 As Double = 0 'Costo
            Dim Costo As Double = 0
            '******************CALCULO [PESO/VOLUMEN] * [COSTO] Row=0*******************************
            If Conversion.Val(GrdDetalleVenta("Peso/Volumen", 0).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta("Peso/Volumen", 0).Value '--> campo [Peso/Vol] Fila [Peso]
            If Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta("Bulto", 0).Value '----------------> campo [Piezas]   Fila [Peso]
            If Conversion.Val(GrdDetalleVenta("Costo", 0).Value) = 0 Then valor2 = 0 Else Costo = GrdDetalleVenta("Costo", 0).Value '----------------> campo [Piezas]   Fila [Peso]

            If objGuiaEnvio.CondicionTarifa_ And objGuiaEnvio.UnidadPeso_ = "PESO" Then
                If valor1 >= objGuiaEnvio.iPeso_Minimo And valor1 <= objGuiaEnvio.iPeso_Maximo Then
                    GrdDetalleVenta("Sub Neto", 0).Value = objGuiaEnvio.iPrecio_cond_Peso
                ElseIf valor1 > objGuiaEnvio.iPeso_Maximo Then
                    Dim Calculo As Double = (valor1 - objGuiaEnvio.iPeso_Maximo) * (Costo)
                    Dim SubNeto As Double = (Calculo + objGuiaEnvio.iPrecio_cond_Peso)
                    GrdDetalleVenta("Sub Neto", 0).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)
                ElseIf valor1 < objGuiaEnvio.iPeso_Minimo Then
                    GrdDetalleVenta("Sub Neto", 0).Value = "0.00"
                End If
            Else
                If CboProducto.SelectedValue = 81 Or CboProducto.SelectedValue = 82 Then
                    GrdDetalleVenta("Sub Neto", 0).Value = IIf(valor2 * tarifa_Peso = 0, "0.00", FormatNumber(Format((valor2 * tarifa_Peso), "###,###,###.00"), 2))
                Else
                    GrdDetalleVenta("Sub Neto", 0).Value = IIf(valor1 * tarifa_Peso = 0, "0.00", FormatNumber(Format((valor1 * tarifa_Peso), "###,###,###.00"), 2))
                End If
            End If
            '****************CALCULO [PESO/VOLUMEN] * [COSTO] Row=1*********************************
            If Conversion.Val(GrdDetalleVenta("Peso/Volumen", 1).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta("Peso/Volumen", 1).Value '--> campo [Peso/Vol] Fila [Volumen]
            If Conversion.Val(GrdDetalleVenta("Bulto", 1).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta("Bulto", 1).Value '----------------> campo [Piezas]   Fila [Volumen]        

            If objGuiaEnvio.CondicionTarifa_ And objGuiaEnvio.UnidadVol_ = "VOL" Then
                If valor1 >= objGuiaEnvio.iVol_Minimo And valor1 <= objGuiaEnvio.iVol_Maximo Then
                    GrdDetalleVenta("Sub Neto", 1).Value = objGuiaEnvio.iPrecio_cond_Vol
                ElseIf valor1 > objGuiaEnvio.iVol_Maximo Then
                    Dim Calculo As Double = (valor1 - objGuiaEnvio.iVol_Maximo) * (tarifa_Volumen)
                    Dim SubNeto As Double = (Calculo + objGuiaEnvio.iPrecio_cond_Vol)
                    GrdDetalleVenta("Sub Neto", 1).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)
                ElseIf valor1 < objGuiaEnvio.iVol_Minimo Then
                    GrdDetalleVenta("Sub Neto", 1).Value = "0.00"
                End If
            Else
                If CboProducto.SelectedValue = 81 Or CboProducto.SelectedValue = 82 Then
                    GrdDetalleVenta("Sub Neto", 1).Value = IIf(valor2 * tarifa_Volumen = 0, "0.00", FormatNumber(Format((valor2 * tarifa_Volumen), "###,###,###.00"), 2))
                Else
                    GrdDetalleVenta("Sub Neto", 1).Value = IIf(valor1 * tarifa_Volumen = 0, "0.00", FormatNumber(Format((valor1 * tarifa_Volumen), "###,###,###.00"), 2))
                End If
            End If

            '****************CALCULO [PESO/VOLUMEN] * [COSTO] Row=2*********************************
            If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                If Conversion.Val(GrdDetalleVenta("Peso/Volumen", 2).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta("Peso/Volumen", 2).Value '--> campo [Peso/Vol] Fila [Sobre]
                If Conversion.Val(GrdDetalleVenta("Bulto", 2).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta("Bulto", 2).Value '----------------> campo [Piezas]   Fila [Sobre]

                GrdDetalleVenta("Sub Neto", 2).Value = IIf(valor2 * tarifa_Sobre = 0, "0.00", FormatNumber(Format((valor2 * tarifa_Sobre), "###,###,###.00"), 2))
            End If
            '***************************************************************************************

            If iControlFacturacion > 0 Then
                ObjVentaCargaContado.v_MONTO_BASE = Monto_Base
            Else
                If iControlMonto_Base = 0 Then
                    ObjVentaCargaContado.v_MONTO_BASE = 0
                    Monto_Base = 0
                Else
                    If Monto_Base > 0 Then
                        ObjVentaCargaContado.v_MONTO_BASE = Monto_Base 'Monto_Base
                    End If
                End If
            End If

            '----------------------------------------------------------------------------------------------------------------------------
            Dim Vol, Peso, Sobre As Double
            If Conversion.Val(GrdDetalleVenta("Sub Neto", 0).Value) = 0 Then Vol = 0 Else Vol = GrdDetalleVenta("Sub Neto", 0).Value
            If Conversion.Val(GrdDetalleVenta("Sub Neto", 1).Value) = 0 Then Peso = 0 Else Peso = GrdDetalleVenta("Sub Neto", 1).Value
            If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                If Conversion.Val(GrdDetalleVenta("Sub Neto", 2).Value) = 0 Then Sobre = 0 Else Sobre = GrdDetalleVenta("Sub Neto", 2).Value
            End If

            Dim IGV As Double = dtoUSUARIOS.iIGV / 100
            Dim SubTotal As Double = 0
            Dim Monto As Double = 0
            If Vol + Peso > 0 Then
                If CboProducto.SelectedValue = 81 Or CboProducto.SelectedValue = 82 Then
                    SubTotal = (Monto_Base + Peso + Vol + Sobre) / (1 + IGV)
                Else
                    If iControlMonto_Base = 1 Then
                        SubTotal = Monto_Base + Vol + Peso + Sobre
                    Else
                        SubTotal = Vol + Peso + Sobre
                    End If
                End If
            Else
                If CboProducto.SelectedValue = 81 Or CboProducto.SelectedValue = 82 Then
                    SubTotal = (Monto_Base + Peso + Vol + Sobre) / (1 + IGV)
                Else
                    SubTotal = Vol + Peso + Sobre
                End If
            End If

            '*******APLICACION CARGA ASEGURADA****************
            'hlamas 23-11-2013
            Dim intFila As Integer
            If es_carga_asegurada Then
                If bTarifarioGeneral And bContado Then
                    intFila = BuscarItemVenta("SEGURO", GrdDetalleVenta)
                    SubTotal += Format(Val(GrdDetalleVenta("Sub Neto", intFila).Value), "0.00")
                Else
                    SubTotal += Val(GrdDetalleVenta("Sub Neto", intFila).Value)
                End If
                'If bTarifarioGeneral And bContado Then
                '    SubTotal += Format(Val(GrdDetalleVenta("Sub Neto", 4).Value), "0.00")
                'Else
                '    SubTotal += Val(GrdDetalleVenta("Sub Neto", 4).Value)
                'End If
            End If
            '*******Entrega a domicilio*************************
            intFila = BuscarItemVenta("ENTREGA", GrdDetalleVenta)
            If intFila > 0 Then
                SubTotal += Format(Val(GrdDetalleVenta("Sub Neto", intFila).Value), "0.00")
            End If
            '****************************************************
            '********************************DEVOLUCION DE CARGO************************************************
            intFila = BuscarItemVenta("DEV CARGO", GrdDetalleVenta)
            If intFila > 0 Then
                'dblMontoDC = ObtieneMontoDevolucionCargo()
                SubTotal += Format(Val(GrdDetalleVenta("Sub Neto", intFila).Value), "0.00")
            End If
            '********************************DEVOLUCION DE CARGO************************************************

            Dim SUB_TOTAL_GENERAL As Double = 0
            '********APLICACION DESCUENTO*********************
            If (1 - Val(Me.TxtDescuento.Text) / 100) > 0 Then
                If bContado Then
                    'hlamas 11-09-2015
                    'SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SubTotal * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
                    SUB_TOTAL_GENERAL = Format((1 + IGV) * SubTotal * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000")
                    If Val(TxtDescuento.Text) > 0 Or Val(TxtDescuento.Text) < 0 Then
                        SUB_TOTAL_GENERAL = RedondearMas(SUB_TOTAL_GENERAL, 1)
                    End If
                Else
                    SUB_TOTAL_GENERAL = Format((1 + IGV) * SubTotal * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000")
                End If
                If bTarifarioGeneral And bContado Then
                    'hlamas 11-09-2015
                    'SUB_TOTAL_GENERAL = fnTECHO(Format(SubTotal * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
                    SUB_TOTAL_GENERAL = Format(SubTotal * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000")
                    If Val(TxtDescuento.Text) > 0 Or Val(TxtDescuento.Text) < 0 Then
                        SUB_TOTAL_GENERAL = RedondearMas(SUB_TOTAL_GENERAL, 1)
                    End If
                End If
            Else
                If (1 - Val(Me.TxtDescuento.Text) / 100) = 0 Then
                    SUB_TOTAL_GENERAL = 0
                End If
            End If

            If (SUB_TOTAL_GENERAL < monto_minimo_PCE) And bContado Then
                'TxtDescuento.Enabled = False
                Me.CondicionMontoMinimoPCE()
            Else
                TxtDescuento.Enabled = True

                'hlamas 12-02-2014
                If TipoGrid_ = FormatoGrid.BULTO Then
                    Dim intDescuentoPromocion = CalculaPromocion()
                    If intDescuentoPromocion > 0 Then
                        'hlamas 11-09-2015
                        'SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SubTotal_Costo * (1 - Val(intDescuentoPromocion) / 100), "###,###,###.000"))
                        SUB_TOTAL_GENERAL = Format((1 + IGV) * SubTotal_Costo * (1 - Val(intDescuentoPromocion) / 100), "###,###,###.000")
                        If Val(TxtDescuento.Text) > 0 Or Val(TxtDescuento.Text) < 0 Then
                            SUB_TOTAL_GENERAL = RedondearMas(SUB_TOTAL_GENERAL, 1)
                        End If
                    End If
                End If
                '*****************************APLICACION CALCULO*******************************************************************************************************
                TxtSubTotal.Text = IIf(SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
                TxtImpuesto.Text = IIf(IGV * SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
                TxtTotal.Text = IIf(SUB_TOTAL_GENERAL = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL, "###,###,###.00"), 2))
                '******************************************************************************************************************************************************
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "GRABAR"

    '***GRABAR**
    Private Sub BtnGraba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGraba.Click
        Try
            If Not Validar() Then
                Return
            End If
            Me.Cursor = Cursors.AppStarting
            Me.Grabar()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '****VALIDAR**
    Function Validar() As Boolean
        If Me.CboTipo.SelectedIndex = 0 Then
            Dim objLIQUI_TURNOS As New ClsLbTepsa.dtoLIQUI_TURNOS
            objLIQUI_TURNOS.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
            objLIQUI_TURNOS.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            If objLIQUI_TURNOS.SP_LISTAR_LIQUI_TURNO().Count <= 0 Then
                MessageBox.Show("Aperture su Turno.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Function
            End If
            objLIQUI_TURNOS = Nothing
        End If

        Dim b As Boolean = True
        If Me.txtBoleto.Visible Then 'flagPCE And 
            If Me.txtBoleto.Text.Trim.Length < 2 Then
                b = False
            ElseIf Not bCargaAcompañada Then
                b = False
            End If
        End If

        If CboTipo.SelectedValue = 1 Then
            If Not b Then
                MessageBox.Show("Asocie un Boleto de Viaje al Comprobante de Venta", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtBoleto.Focus()
                Me.Cursor = Cursors.Default
                Return False
            End If
        End If

        'hlamas 13-03-2014
        If Me.CboTipo.SelectedIndex = 1 AndAlso Me.CboProducto.SelectedValue <= 0 Then
            MessageBox.Show("El Cliente Crédito no tiene asociado ningún producto", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Cursor = Cursors.Default
            Me.CboProducto.Focus()
            Return False
        End If

        '*******validacion del Nro Serie************
        'If txtNroNroGuia.Text.Trim.Length = 0 And CboTipo.SelectedValue = 2 Then
        '    MessageBox.Show("Ingrese el Número de Serie", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    'Me.BtnGrabar.Focus()
        '    Return False
        '    'ElseIf Val(LblNroBoletaFact.Text.Trim) = 0 Then
        '    '    MessageBox.Show("Ingrese el Número de Comprobante", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    '    Me.BtnGrabar.Focus()
        '    '    Return False
        'End If

        If idUnidadAgencias <= 0 Then
            MessageBox.Show("Seleccione la Ciudad de Destino", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtCiudadDestino.Text = ""
            TxtCiudadDestino.Focus()
            TxtCiudadDestino.SelectAll()
            Return False
        End If

        If dtoUSUARIOS.m_idciudad = idUnidadAgencias Then
            MessageBox.Show("Seleccione una Ciudad Destino diferente a la Ciudad Orígen", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtCiudadDestino.Focus()
            Me.TxtCiudadDestino.SelectAll()
            Return False
        End If

        If CboAgenciaDest.SelectedValue = 0 Then
            MessageBox.Show("Seleccione la Agencia de Destino", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CboAgenciaDest.Focus()
            CboAgenciaDest.SelectAll()
            Return False
        End If

        If CboTipoEntrega.SelectedValue = 0 Then
            MessageBox.Show("Seleccione el Tipo de Entrega.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.CboTipoEntrega.Focus()
            Return False
        End If

        If CboTipo.SelectedValue = 1 Then
            If idUnidadAgencias = 601 Then
                MessageBox.Show("No están permitidos envíos para la ciudad destino seleccionada", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.CboTipo.Focus()
                Return False
            End If
        End If

        'If ObjVentaCargaContado.v_IDTIPO_PAGO = 2 AndAlso TxtNroTarjeta.Text.Trim.Length = 0 Then
        '    MessageBox.Show("Ingrese Número de Tarjeta", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    TxtNroTarjeta.Focus()
        '    TxtNroTarjeta.SelectAll()
        '    Return False
        'End If

        '*******validando nombre del cliente********
        If TipoComprobante = 1 Then
            If TxtNroDocCliente.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese el Cliente", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtCliente.Text = ""
                TxtCliente.Focus()
                TxtCliente.SelectAll()
                Return False
            End If
        Else
            If TxtNomCliente.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese el Cliente", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtCliente.Text = ""
                TxtCliente.Focus()
                TxtCliente.SelectAll()
                Return False
            End If
        End If

        If Me.CboProducto.SelectedValue = 7 AndAlso Me.TxtNroDocCliente.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese el Nº de Documento", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtCliente.Text = ""
            TxtCliente.Focus()
            TxtCliente.SelectAll()
            Return False
        End If

        '*************************************Validacion de Campos*****************************************
        If TipoComprobante = 1 Then
            If TxtNroDocCliente.Text.Trim.Length = 11 Then
                If fnValidarRUC(TxtNroDocCliente.Text.Trim) = False Then
                    MessageBox.Show("Ingrese un RUC Válido", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtCliente.Focus()
                    TxtCliente.SelectAll()
                    Return False
                End If
            Else
                MessageBox.Show("Ingrese un RUC Válido", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtCliente.Focus()
                TxtCliente.SelectAll()
                Return False
            End If
        End If

        If TxtNroDocCliente.Text.Trim.Length = 11 Then         'ruc
            If fnValidarRUC(TxtNroDocCliente.Text.ToString.Trim) Then
                If LblTipoComprobante.Text.Substring(0, 1) <> "F" And LblTipoComprobante.Text.Substring(0, 1) <> "G" Then
                    MessageBox.Show("Se debe generar una Factura", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    TxtCliente.Focus() : TxtCliente.SelectAll()
                    Return False
                End If

                'hlamas 24-07-2015
                If Me.CboTipo.SelectedValue = 2 Then
                    If dtCliente.Rows(0).Item("idtipo_facturacion") = 3 Then
                        'hlamas 22-03-2016
                        'If Not Me.ChkCargo.Checked Then
                        '    Me.ChkCargo.Checked = True
                        'End If
                        If Not Me.rbtCargoSi.Checked Then
                            Me.chkDocumentoCliente.Checked = True
                            Me.rbtCargoSi.Checked = True
                        End If

                        'If TxtNroDocCliente.Text.ToString.Trim = "20100085225" Then
                        '    If Not TieneCargo() Then
                        '        MessageBox.Show("Ingrese Cargos del Cliente", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '        Return False
                        '    End If
                        'End If
                    End If
                End If

                'If Me.CboTipo.SelectedIndex = 1 And Me.TxtNroDocCliente.Text.ToString.Trim = "20136165667" Then

                'End If
            Else
                MessageBox.Show("Ingrese un RUC Válido", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TxtCliente.Focus()
                TxtCliente.SelectAll()
                Return False
            End If
        ElseIf TxtNroDocCliente.Text.Trim.Length = 8 Then         'boleta
            If LblTipoComprobante.Text.Substring(0, 1) <> "B" And LblTipoComprobante.Text.Substring(0, 1) <> "G" Then
                MessageBox.Show("Se debe generar una Boleta de Venta", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TxtCliente.Focus() : TxtCliente.SelectAll()
                Return False
            End If
        ElseIf TxtNroDocCliente.Text.Trim.Length > 0 And TxtNroDocCliente.Text.Trim.Length < 6 Then         'sin documento
            If Not bCargaAcompañada Then
                MessageBox.Show("Ingrese Número de Documento Válido", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TxtCliente.Focus() : TxtCliente.SelectAll()
                Return False
            End If
        End If

        If iID_Persona = ID_PERSONA_ECKERD Then
            Dim obj As New dtoGuia
            Dim intResultado As Integer = obj.ClienteSubcuenta(iID_Persona, Me.CboSubCuentaOrigen.SelectedValue, Me.CboSubCuenta.SelectedValue)
            If intResultado > 1 Then
                If intResultado = 2 Then
                    MessageBox.Show("Seleccione una subcuenta diferente de GENERICO", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.CboSubCuentaOrigen.Focus()
                    Return False
                End If
                If intResultado = 3 Then
                    MessageBox.Show("Seleccione una subcuenta diferente de GENERICO", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.CboSubCuenta.Focus()
                    Return False
                End If
            End If
        ElseIf iID_Persona = ID_PERSONA_DATAIMAGENES And dtoUSUARIOS.m_idciudad = 5100 And Me.CboSubCuenta.SelectedValue = 999 Then
            If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                MessageBox.Show("El Cliente sólo puede realizar envíos en Agencia", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.CboTipoEntrega.Focus()
                Return False
            End If
        ElseIf iID_Persona = ID_PERSONA_OLVA AndAlso dtoUSUARIOS.m_idciudad = 5100 And idUnidadAgencias <> 601 Then
            If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                MessageBox.Show("El Cliente sólo puede realizar envíos en Agencia", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.CboTipoEntrega.Focus()
                Return False
            End If
        End If

        '01092011
        'If Me.CboProducto.SelectedValue <> 6 AndAlso Me.CboDireccion.SelectedValue = 0 Then
        'If Me.CboTipo.SelectedValue = 2 AndAlso Me.CboDireccion.SelectedIndex = 0 Then
        'MessageBox.Show("Seleccione una Dirección", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Me.CboDireccion.Focus()
        'Return False
        'End If
        '----
        If Me.CboRemitente.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione el Remitente", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.CboRemitente.Focus()
            Return False
        End If

        If Me.CboContacto.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione el Contacto", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.CboContacto.Focus()
            Return False
        End If

        '-->10/09/2013 - jabanto - Reliza la validacion del ingreso del DT(Documento de Transporte), solo si es visible 
        '-->Es obligatorio si el producto seleccionado es CARGA EXPRESS, caso contrario es opcional
        If (txtdt.Visible And CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_COURIER) Then
            'And dtoUSUARIOS.m_idciudad = 5100
            If Not Me.dtpFechaRecojo.Checked Then
                MessageBox.Show("Ingrese Fecha de Recojo", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dtpFechaRecojo.Focus()
                Return False
            End If
            If (txtdt.Text.Trim.Length = 0) Then
                MessageBox.Show("Ingrese el Documento de Transporte", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtdt.Focus()
                Return False
                'ElseIf (txtdt.Text.Length < 7) Then '-->Valida que el campo DT contenga 7 digitos
                '    MessageBox.Show("El DT (Documento de Transporte) debe tener 7 dígitos", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    txtdt.Focus()
                '    Return False
            ElseIf Val(txtdt.Text) <= 0 Then
                MessageBox.Show("El Documento de Transporte debe ser válido", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtdt.Focus()
                Return False
            End If
        ElseIf txtdt.Visible And txtdt.Text.Trim.Length > 0 Then
            If Not Me.dtpFechaRecojo.Checked Then
                MessageBox.Show("Ingrese Fecha de Recojo", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dtpFechaRecojo.Focus()
                Return False
            End If
            If Val(txtdt.Text) <= 0 Then
                MessageBox.Show("El Documento de Transporte debe ser válido", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtdt.Focus()
                Return False
            End If
        End If

        '*******validando nombre del Consignado********
        '***Comentado x NConsignado**************************
        'If TxtNombConsignado.Text.Trim.Length = 0 Then
        '    MessageBox.Show("Seleccione el Consignado", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    TxtConsignado.Text = ""
        '    TxtConsignado.Focus()
        '    TxtConsignado.SelectAll()
        '    Return False
        'End If

        '=====Agregado(Reemplasado) x NConsignado=============
        If GrdNConsignado.Rows.Count = 0 Then
            MessageBox.Show("Ingrese el Consignado", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtConsignado.Text = ""
            TxtConsignado.Focus()
            TxtConsignado.SelectAll()
            Return False
        End If
        '=====================================================

        With GrdNConsignado
            If .Rows.Count > 0 Then
                For Each row As DataGridViewRow In .Rows
                    If dtoVentaCargaContado.ClienteConsignado(TxtNroDocCliente.Text.Trim, row.Cells(1).Value.ToString.Trim) = 0 Then
                        MessageBox.Show("El Consignado no es válido para el cliente", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.TxtConsignado.Focus()
                        Me.TxtConsignado.SelectAll()
                        Return False
                    End If
                Next
            End If
        End With

        If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio AndAlso Me.CboDireccion2.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione la Direccion del Consignado", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.CboDireccion2.Focus()
            CboDireccion2.SelectAll()
            Return False
        End If

        Dim iDescuento As Integer = IIf(TxtDescuento.Text.Trim <> "", TxtDescuento.Text.Trim, 0)
        If iDescuento <> 0 Then
            If iDescuento < -100 Or iDescuento > 100 Then
                MessageBox.Show("Ingrese un Monto de Descuento o Incremento Correcto", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtDescuento.Focus()
                Me.TxtDescuento.SelectAll()
                Return False
            ElseIf Me.txtDescDescto.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nombre de la Persona que Autoriza el Descuento o Incremento", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDescDescto.Text = ""
                txtDescDescto.Focus()
                txtDescDescto.SelectAll()
                Return False
            End If
        End If

        'hlamas 22-03-2015
        ''hlamas 26-08-2015
        'If Me.ChkCargo.Checked Then
        '    If Not ModuUtil.TieneCargo(Me.GrdDocumentosCliente, 2) Then
        '        Dim frm As New frmCargoValidacion
        '        frm.ShowDialog()
        '        blnCargo = frm.rbtSi.Checked
        '        If Not blnCargo Then
        '            strObservacionCargo = frm.txtMotivo.Text.Trim
        '        Else
        '            strObservacionCargo = ""
        '            Me.GrdDocumentosCliente.Focus()
        '            Return False
        '        End If
        '    End If
        'End If
        If Me.chkDocumentoCliente.Checked Then 'selecciono con documento del cliente
            If Me.rbtCargoSi.Checked = False And Me.rbtCargoNo.Checked = False Then 'no selecciono si documento cliente es con cargo o sin cargo
                MessageBox.Show("Seleccione si documento del cliente es " & Chr(13) & Chr(13) & "CON DEVOLUCION DE CARGO o SIN DEVOLUCION DE CARGO", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.rbtCargoSi.Focus()
                Me.rbtCargoSi.Checked = False
                Return False
            End If
            'hlamas 18-03-2015
            If Me.rbtCargoSi.Checked Then
                If Not ModuUtil.TieneCargo(Me.GrdDocumentosCliente, 2) Then
                    Dim frm As New frmCargoValidacion
                    frm.ShowDialog()
                    blnCargo = frm.rbtSi.Checked
                    If Not blnCargo Then
                        strObservacionCargo = frm.txtMotivo.Text.Trim
                    Else
                        strObservacionCargo = ""
                        Me.GrdDocumentosCliente.Focus()
                        Return False
                    End If
                End If
            Else
                If Not ModuUtil.TieneCargo(Me.GrdDocumentosCliente, 2) Then
                    MessageBox.Show("Ingrese Documentos del Cliente", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.GrdDocumentosCliente.Focus()
                    Return False
                End If
            End If
        End If

        If (ChkArticulos.Checked = False Or ChkArticulos.Enabled = False) And ChkM3.Checked = False Then
            'Peso
            If Val(GrdDetalleVenta.Rows(0).Cells(2).Value) > 0 And Val(GrdDetalleVenta.Rows(0).Cells(1).Value) <= 0 Then
                MessageBox.Show("Ingrese Número de Bultos para Peso", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            If Me.CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX And Me.CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX_10 Then
                'Volumen
                If Val(GrdDetalleVenta.Rows(1).Cells(2).Value) > 0 And Val(GrdDetalleVenta.Rows(1).Cells(1).Value) <= 0 Then
                    MessageBox.Show("Ingrese Número de Bultos para Volumen", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If

            'If ObjVentaCargaContado.v_CANTIDAD_X_PESO + ObjVentaCargaContado.v_CANTIDAD_X_SOBRE + ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN + ObjVentaCargaContado.v_MONTO_PENALIDAD <= 0 Then
            If Val(GrdDetalleVenta.Rows(0).Cells(2).Value) <= 0 And Val(GrdDetalleVenta.Rows(0).Cells(1).Value) > 0 Then
                MessageBox.Show("Ingrese Peso del Envío", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If

            If Me.CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX And Me.CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX_10 Then
                If Val(GrdDetalleVenta.Rows(1).Cells(2).Value) <= 0 And Val(GrdDetalleVenta.Rows(1).Cells(1).Value) > 0 Then
                    MessageBox.Show("Ingrese Volúmen del Envío", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If

            If Me.CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX Or Me.CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX_10 Then
                If Val(TxtTotal.Text) <= 0 Then
                    MessageBox.Show("Ingrese Nº de Paquetes", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            Else
                '--> 10/09/2013 - jabanto - evita el registro de la guía con 0 bultos
                Dim isCorrectoCantBultos As Boolean = False
                '->valida cantidad Peso
                isCorrectoCantBultos = Val(GrdDetalleVenta.Rows(0).Cells(1).Value) > 0
                '->si es falso valida cantidad volumen
                If Not (isCorrectoCantBultos) Then isCorrectoCantBultos = Val(GrdDetalleVenta.Rows(1).Cells(1).Value) > 0
                '->si es falso valida cantidad sobres
                If Not (isCorrectoCantBultos) Then isCorrectoCantBultos = Val(GrdDetalleVenta.Rows(2).Cells(1).Value) > 0

                If Not (isCorrectoCantBultos) Then
                    MessageBox.Show("Debe de completar el ingreso de la cantidad de bultos o Sobres, " & Chr(13) & "según la condición que corresponda.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If
        ElseIf Me.ChkArticulos.Checked Then 'hlamas 21-01-2016
            For Each row As DataGridViewRow In Me.GrdDetalleVenta.Rows
                If Me.CboTipo.SelectedIndex = 0 Then
                    If Val(row.Cells(2).Value) = 0 And Val(row.Cells(3).Value) > 0 Then
                        MessageBox.Show("Ingrese la Cantidad", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                    If Val(row.Cells(2).Value) > 0 And Val(row.Cells(3).Value) = 0 Then
                        MessageBox.Show("Ingrese el Peso", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                Else
                    'hlamas 02-10-2019
                    If TipoGrid_ = FormatoGrid.ARTICULOS And CboTipo.SelectedValue = 2 And iID_Persona = ID_PERSONA_SODIMAC Then
                        If Val(row.Cells(2).Value) = 0 And (Val(row.Cells(3).Value) > 0 Or Val(row.Cells(4).Value) > 0) Then
                            MessageBox.Show("Ingrese el Sku", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return False
                        End If
                        If Val(row.Cells(2).Value) > 0 And Val(row.Cells(3).Value) = 0 Then
                            MessageBox.Show("Ingrese la Cantidad", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return False
                        End If
                        If Val(row.Cells(2).Value) > 0 And Val(row.Cells(4).Value) = 0 Then
                            MessageBox.Show("Ingrese el Peso", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return False
                        End If

                        If Val(row.Cells(3).Value) = 0 And (Val(row.Cells(2).Value) > 0 Or Val(row.Cells(4).Value) > 0) Then
                            MessageBox.Show("Ingrese la Cantidad", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return False
                        End If
                        If Val(row.Cells(3).Value) > 0 And Val(row.Cells(2).Value) = 0 Then
                            MessageBox.Show("Ingrese el Sku", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return False
                        End If
                        If Val(row.Cells(3).Value) > 0 And Val(row.Cells(4).Value) = 0 Then
                            MessageBox.Show("Ingrese el Peso", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return False
                        End If

                        If Val(row.Cells(4).Value) = 0 And (Val(row.Cells(2).Value) > 0 Or Val(row.Cells(3).Value) > 0) Then
                            MessageBox.Show("Ingrese el Peso", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return False
                        End If
                        If Val(row.Cells(4).Value) > 0 And Val(row.Cells(2).Value) = 0 Then
                            MessageBox.Show("Ingrese el Sku", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return False
                        End If
                        If Val(row.Cells(4).Value) > 0 And Val(row.Cells(3).Value) = 0 Then
                            MessageBox.Show("Ingrese la Cantidad", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return False
                        End If


                    Else
                        If Val(row.Cells(2).Value) = 0 And Val(row.Cells(4).Value) > 0 Then
                            MessageBox.Show("Ingrese la Cantidad", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return False
                        End If
                        If Val(row.Cells(2).Value) > 0 And Val(row.Cells(4).Value) = 0 Then
                            MessageBox.Show("Ingrese el Peso", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return False
                        End If
                    End If
                End If
            Next
        End If

        '-->jabanto - 14/09/2013. Realiza la valizadion SOLO PARA ECKERD si la subCuenta destino tiene configurado el CODIGO SAP.
        'If (CboTipo.SelectedValue = Cls_Constantes_LN.TIPO_CREDITO And CboProducto.SelectedValue = Cls_Constantes_LN.ID_PRODUCTO_CARGA_EXPRESA) Then
        '    If (iID_Persona = Cls_Constantes_LN.ID_PERSONA_ECKERD And CboSubCuenta.SelectedValue <> Cls_Constantes_LN.ID_CENTRO_COSTO_GENERICO) Then
        '        If IsDBNull(DirectCast(CboSubCuenta.SelectedItem, DataRowView)("codigoSap")) Then
        '            MessageBox.Show("No puede continuar con la emisión de la Guía," & Chr(13) & "la SubCuenta destino no tiene configurado un CÓDIGO SAP.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            Return False
        '        End If
        '    End If
        'End If


        '*******validando Monto Afecto**************
        Dim Sum As Double
        If Not ChkArticulos.Checked And CboTipo.SelectedValue = 1 Then
            For i As Integer = 0 To GrdDetalleVenta.Rows.Count() - 1 '- 2 'CambioR 10112011
                If GrdDetalleVenta("Sub Neto", i).Value < 0 Then
                    MessageBox.Show("Los Subtotales no deben ser negativos", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
                Sum += Val(GrdDetalleVenta("Sub Neto", i).Value)
            Next

            If Sum <= 0 Then
                MessageBox.Show("Complete la Venta", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.GrdDetalleVenta.Focus()
                Return False
            End If
        End If

        If Val(TxtTotal.Text) <= 0 Then
            MessageBox.Show("Complete la Venta", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.GrdDetalleVenta.Focus()
            Return False
        End If


        ''******Entrega a Domicilio***********
        'If Me.CboTipoEntrega.SelectedValue = 2 Then
        '    Dim intFila As Integer = BuscarItemVenta("ENTREGA", GrdDetalleVenta)
        '    If intFila > 0 Then
        '        If Val(GrdDetalleVenta("sub neto", intFila).Value) = 0 Then
        '            MessageBox.Show("El Servicio de Entrega a Domicilio debe tener una Tarifa Asignada", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            Me.GrdDetalleVenta.Focus()
        '            Return False
        '        End If
        '    End If
        'End If

        '01/09/2011
        'Informa si el cliente tiene crédito y va a emitir PCE
        If Me.CboTipo.SelectedValue = 1 AndAlso bTieneLineaCredito Then
            If iID_Persona = ID_PERSONA_SANROQUE Then
                Dim sNumeroDocumento As String = Me.TxtNroDocCliente.Text.Trim
                Me.CboTipo.SelectedValue = 2
                Me.RbtDocumento.Checked = True
                Me.TxtCliente.Text = sNumeroDocumento
                Me.BuscarClienteCredito()
            Else
                If iID_Persona <> ID_PERSONA_PESQUERA Then
                    Dim sMje As String
                    sMje = "El Cliente tiene Línea de Crédito." & vbCrLf
                    sMje &= "¿Está Seguro de Emitir un Pago Contraentrega?"
                    Dim dlgRespuesta As DialogResult
                    dlgRespuesta = MessageBox.Show(sMje, "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If dlgRespuesta = Windows.Forms.DialogResult.No Then
                        Return False
                    End If
                Else
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Sub FormateoVariables()
        '**DATOS CLIENTE
        If NombresCliente Is Nothing Then ObjVentaCargaContado.NombresCliente = ""
        If apellPatCli Is Nothing Then ObjVentaCargaContado.apellPatCli = ""
        If apellMatCli Is Nothing Then ObjVentaCargaContado.apellMatCli = ""
        If TelfCliente Is Nothing Then ObjVentaCargaContado.TelefCliente = ""

        '**DIRECCION CLIENTE
        If ViaCli Is Nothing Then ObjVentaCargaContado.viaCli = ""
        If NroCli Is Nothing Then ObjVentaCargaContado.NumeroCli = ""
        If ManzanaCli Is Nothing Then ObjVentaCargaContado.manzanaCli = ""
        If loteCli Is Nothing Then ObjVentaCargaContado.loteCli = ""
        If NivelCli Is Nothing Then ObjVentaCargaContado.nivelCli = ""
        If ZonaCli Is Nothing Then ObjVentaCargaContado.zonaCli = ZonaCli = ""
        If ClasificacionCli Is Nothing Then ObjVentaCargaContado.clasificacionCli = ""
        '**CONTACTO
        If apellPatCont Is Nothing Then ObjVentaCargaContado.apellPatCont = ""
        If apellMatCont Is Nothing Then ObjVentaCargaContado.apellMatCont = ""
        '**DATOS CONSIGNADO
        If sNombresConsig Is Nothing Then ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = ""
        If sapellPatConsig Is Nothing Then ObjVentaCargaContado.apellPatConsig = ""
        If sapellMatConsig Is Nothing Then ObjVentaCargaContado.apellMatConsig = ""
        If sTelefonoConsig Is Nothing Then ObjVentaCargaContado.TelfConsignado = ""
        '**DIRECCION CONSIGNADO
        If ViaConsig Is Nothing Then ObjVentaCargaContado.viaConsig = ""
        If NroConsig Is Nothing Then ObjVentaCargaContado.NumeroConsig = ""
        If ManzanaConsig Is Nothing Then ObjVentaCargaContado.manzanaConsig = ""
        If loteConsig Is Nothing Then ObjVentaCargaContado.loteConsig = ""
        If NivelConsig Is Nothing Then ObjVentaCargaContado.nivelConsig = ""
        If ZonaConsig Is Nothing Then ObjVentaCargaContado.zonaConsig = ""
        If ClasificacionConsig Is Nothing Then ObjVentaCargaContado.clasificacionConsig = ""
    End Sub

    Dim iIdFactura As Integer
    Dim iOficinaOrigen As Integer
    Public bControlFiscalizacion As Boolean = False
    Dim control_venta As Boolean
    Dim Mro_Digitos_SerieVentas As Integer = 3
    Sub Grabar()
        Try
            If Val(TxtDescuento.Text) = 0 Then
                TxtDescuento.Text = ""
            End If

            If CboTipo.SelectedValue = 1 Or CboTipo.SelectedValue = 3 Then
                If fnGrabarContado() = True Then
                    If Me.CboTipo.SelectedValue = 1 Then
                        ObjVentaCargaContado.v_GUIA = ""
                        ObjVentaCargaContado.NroDoc = ObjVentaCargaContado.v_GUIA
                        CORRELATIVO = ObjVentaCargaContado.v_GUIA
                        ObjVentaCargaContado.v_NROGUIA_VIGENTE = ObjVentaCargaContado.v_GUIA
                        Me.txtNroNroGuia.Text = ""
                        'Else
                        '    If ObjVentaCargaContado.fnNroDocuemnto(3, CboProducto.SelectedValue) = True Then
                        '        txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
                        '        CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
                        '        ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroNroGuia.Text.Trim
                        '    ElseIf ObjVentaCargaContado.fnNroDocuemnto(3, 0) = True Then
                        '        txtNroNroGuia.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
                        '        CORRELATIVO = RellenoRight(11, ObjVentaCargaContado.NroDoc.Trim)
                        '        ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroNroGuia.Text.Trim
                        '    End If
                    End If
                    sDocCliente = ""
                    bBoleto = False
                End If
                    BtnCargAseg.Enabled = True
                    RemoveItemsCargAseg()


            ElseIf CboTipo.SelectedValue = 2 Then
                If FnGrabarCredito() = True Then
                    objGuiaEnvio.guia = ""
                    txtNroNroGuia.Text = ""
                    CORRELATIVO = ""
                    ObjVentaCargaContado.v_NROGUIA_VIGENTE = ""
                    'If ObjVentaCargaContado.fnNroDocuemnto(3, CboProducto.SelectedValue) = True Then
                    '    txtNroNroGuia.Text = ObjVentaCargaContado.NroDoc.Trim
                    '    CORRELATIVO = ObjVentaCargaContado.NroDoc.Trim
                    '    ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroNroGuia.Text.Trim
                    'ElseIf ObjVentaCargaContado.fnNroDocuemnto(3, 0) = True Then
                    '    txtNroNroGuia.Text = ObjVentaCargaContado.NroDoc.Trim
                    '    CORRELATIVO = ObjVentaCargaContado.NroDoc.Trim
                    '    ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroNroGuia.Text.Trim
                    'End If
                End If
                BtnCargAseg.Enabled = False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Dim ObjIMPRESIONFACT_BOL As New dtoIMPRESIONFACT_BOL
    Dim ConfiMensajeriaDlg As New FrmConfiMensajeria
    Public Function fnGrabarContado() As Boolean
        Dim flat As Boolean = False
        Try
            'PARAMETRO TIPO_COMPROBANTE
            If CboTipo.SelectedValue = 1 Then
                ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85
            ElseIf CboTipo.SelectedValue = 3 Then
                ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 86
            End If

            'PARAMETRO v_SERIE_FACTURA******************************************
            ObjVentaCargaContado.v_SERIE_FACTURA = "000"

            'PARAMETRO v_NRO_FACTURA********************************************
            ObjVentaCargaContado.v_NRO_FACTURA = txtNroNroGuia.Text.Trim

            'PARAMETRO FECHA INGRESO (FECHA_FACTURA)****************************
            If bControlFiscalizacion = False Then
                ObjVentaCargaContado.v_FECHA_FACTURA = dtoUSUARIOS.m_sFecha
            Else
                ObjVentaCargaContado.v_FECHA_FACTURA = Format("DD/MM/YYYY", Me.txtFechaGuia.Text)
            End If

            'PARAMETRO PRODUCTO (IDPROCESOS)************************************
            ObjVentaCargaContado.v_iProceso = CboProducto.SelectedValue

            'PARAMETRO TIPO TARIFA**********************************************
            'ObjVentaCargaContado.TipoTarifa = IIf(CboTipoTarifa.SelectedIndex = -1, 0, CboTipoTarifa.SelectedIndex) Comentado por Diego Zegarra
            'ObjVentaCargaContado.TipoTarifa = IIf(CboTipoTarifa.SelectedIndex = -1, 1, CboTipoTarifa.SelectedIndex)
            ObjVentaCargaContado.TipoTarifa = CboTipoTarifa.SelectedValue


            If dtoUSUARIOS.agencia <> dtoUSUARIOS.m_iIdAgencia Or dtoUSUARIOS.agencia <> dtoUSUARIOS.iIDAGENCIAS Then
                dtoUSUARIOS.m_iIdAgencia = dtoUSUARIOS.agencia
                dtoUSUARIOS.iIDAGENCIAS = dtoUSUARIOS.agencia
                dtoUSUARIOS.m_idciudad = dtoUSUARIOS.ciudad
            End If

            'PARAMETROS CIUDAD ORIGEN (IDUNIDAD_ORIGEN)*************************
            ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = dtoUSUARIOS.m_idciudad

            'PARAMETRO AGENCIA ORIGEN*******************************************
            ObjVentaCargaContado.v_IDAGENCIAS = dtoUSUARIOS.m_iIdAgencia

            'PARAMETRO CIUDAD DESTINO*******************************************
            If idUnidadAgencias > 0 Then
                'PARAMETRO (IDCIUDAD_DESTINO)***********************************
                ObjVentaCargaContado.v_IDUNIDAD_DESTINO = idUnidadAgencias

                'PARAMETRO (IDAGENCIA_DESTINO*********************************
                ObjVentaCargaContado.v_IDAGENCIAS_DESTINO = CboAgenciaDest.SelectedValue
            End If

            'PARAMETRO TIPO ENTREGA (IDTIPO_ENTREGA)****************************
            ObjVentaCargaContado.v_IDTIPO_ENTREGA = CboTipoEntrega.SelectedValue

            'PARAMETRO TIPO PAGO (IDTIPO_PAGO)**********************************efectivo, tarjeta, cortesia
            ObjVentaCargaContado.v_IDTIPO_PAGO = 1 'Int(ObjVentaCargaContado.coll_Tipo_Pago(CboFormaPago.SelectedIndex.ToString))

            'PARAMETRO 
            ObjVentaCargaContado.v_IDFORMA_PAGO = IIf(CboTipo.SelectedValue = 1, 3, CboTipo.SelectedValue)

            'PARAMETRO TARGETAS (IDTARJETAS)************************************
            ObjVentaCargaContado.v_IDTARJETAS = 0
            ObjVentaCargaContado.v_NROTARJETA = "@"

            If ObjVentaCargaContado.v_IDTIPO_PAGO = 2 Then
                'PARAMETRO IDTARJETAS******            
                ObjVentaCargaContado.v_IDTARJETAS = 0 'Int(ObjVentaCargaContado.coll_T_TARJETAS(CboTarjeta.SelectedIndex.ToString))

                'PARAMETRO NROTARJETA******
                ObjVentaCargaContado.v_NROTARJETA = "@" 'IIf(TxtNroTarjeta.Text <> "", TxtNroTarjeta.Text, "@")
            End If

            '*********************Condiciones de Modificacion***************************
            Me.FormateoVariables()

            '=================================CLIENTE=======================================================
            'PARAMETRO IDPERSONA************,
            ObjVentaCargaContado.v_IDPERSONA = IIf(bClienteNuevo, 0, iID_Persona)

            'PARAMETRO NRO_DNI_RUC**********
            ObjVentaCargaContado.v_NRO_DNI_RUC = IIf(TxtNroDocCliente.Text <> "", TxtNroDocCliente.Text, "@")

            'PARAMETRO NOMBRES_RASONSOCIAL**
            ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL = IIf(TxtNomCliente.Text <> "", TxtNomCliente.Text, "@")

            'PARAMETRO IDDIRECCION_ORIGEN****** 
            IdDireccionOrigen = Me.CboDireccion.SelectedValue
            If CboDireccion.SelectedValue = 0 Then
                IdDireccionOrigen = -1 '--> sin direccion valor(seleccione)
            ElseIf CboDireccion.SelectedValue = -1 Then
                IdDireccionOrigen = 0
            End If
            ObjVentaCargaContado.v_IDDIREECION_ORIGEN = IdDireccionOrigen

            'PARAMETRO NOMBRE DE LA DIRECCION**
            ObjVentaCargaContado.v_DIRECCION_REMITENTE = IIf(IdDireccionOrigen = -1, "@", CboDireccion.Text)

            If (TipoComprobante = 1 Or CboProducto.SelectedValue = 7) Then
                sNombresCli = ""
            ElseIf ChkCliente1.Checked And TipoComprobante = 1 Then
                NombresCont = ""
            ElseIf ChkCliente2.Checked And TipoComprobante = 1 Then
                sNombresConsig = ""
            End If

            '---------DATOS DEL CLIENTE------
            ObjVentaCargaContado.Cliente_mod = IIf(bClienteModificado, 1, 0)
            ObjVentaCargaContado.ID_TipoDocCli = iID_TipoDocCli
            ObjVentaCargaContado.NombresCliente = sNombresCli
            ObjVentaCargaContado.apellPatCli = sApCli
            ObjVentaCargaContado.apellMatCli = sAmCli
            ObjVentaCargaContado.TelefCliente = IIf(sTelfCliente.Length > 0, sTelfCliente, "@")
            ObjVentaCargaContado.sEmail = sEmail.trim '07092011

            '--DIRECCION ESTRUCTURADO DEL CLIENTE          
            ObjVentaCargaContado.DirecCli_mod = IIf(bDireccionModificada, 1, 0)
            ObjVentaCargaContado.id_DepartamentoCli = iDepartamentoCli
            ObjVentaCargaContado.id_ProvinciaCli = iProvinciaCli
            ObjVentaCargaContado.id_DistritoCli = iDistritoCli
            ObjVentaCargaContado.id_viaCli = IDviaCli
            ObjVentaCargaContado.viaCli = ViaCli
            ObjVentaCargaContado.NumeroCli = NroCli
            ObjVentaCargaContado.manzanaCli = ManzanaCli
            ObjVentaCargaContado.loteCli = loteCli
            ObjVentaCargaContado.id_nivelCli = id_NivelCli
            ObjVentaCargaContado.nivelCli = NivelCli
            ObjVentaCargaContado.id_zonaCli = id_ZonaCli
            ObjVentaCargaContado.zonaCli = ZonaCli
            ObjVentaCargaContado.id_clasificacionCli = id_ClasificacionCli
            ObjVentaCargaContado.clasificacionCli = ClasificacionCli
            ObjVentaCargaContado.formatoCli = FormatoCli

            '=============================DATOS REMITENTE=====================================
            'PARAMETRO ID_NOMBRE_REMITENTE**
            If CboRemitente.SelectedIndex = 0 Then
                idRemitente = -1
            End If

            If idcontacto = 0 AndAlso Me.ChkCliente.Checked Then
                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.BuscarContacto(Me.TxtNroDocCliente.Text, TxtNumDocRemitente.Text)
                Dim resp As Integer = dt.Rows.Count
                If resp = 0 Then
                    Me.TxtNumDocRemitente.Tag = 0
                    idRemitente = 0
                Else
                    Me.TxtNumDocRemitente.Tag = dt.Rows(0).Item(0)
                    idRemitente = dt.Rows(0).Item(0)
                    bRemitenteModificado = False
                End If
            End If

            'PARAMETRO NOMBRE REMITENTE*****
            ObjVentaCargaContado.iIDRemitente = idRemitente
            ObjVentaCargaContado.sNombresRemitente = IIf(idRemitente = -1, "@", CboRemitente.Text)
            ObjVentaCargaContado.iRemitenteModificado = IIf(bRemitenteModificado, 1, 0)
            ObjVentaCargaContado.sNumeroDocumento = IIf(sNroDocRemitente.Trim = "", "@", sNroDocRemitente.Trim)
            ObjVentaCargaContado.iID_TipoDocumentoRemitente = iID_TipoDocRemitente
            ObjVentaCargaContado.sNombreRemitente = sNombreRemitente
            ObjVentaCargaContado.sApellidoPaternoRemitente = sApRemitente
            ObjVentaCargaContado.sApellidoMaternoRemitente = sAmRemitente

            '=============================DATOS CONTACTO======================================           
            'PARAMETRO ID_NOMBRE_CONTACTO**          
            If CboContacto.SelectedIndex = 0 Then
                idcontacto = -1
            End If

            If idcontacto = 0 AndAlso Me.ChkCliente1.Checked Then
                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.BuscarContacto(Me.TxtNroDocCliente.Text, TxtNroDocContacto.Text)
                Dim resp As Integer = dt.Rows.Count
                If resp = 0 Then
                    Me.TxtNroDocContacto.Tag = 0
                    idcontacto = 0
                Else
                    Me.TxtNroDocContacto.Tag = dt.Rows(0).Item(0)
                    idcontacto = dt.Rows(0).Item(0)
                    bContactoModificado = False
                End If
            End If

            'PARAMETRO NOMBRE CONTACTO*****
            ObjVentaCargaContado.v_IDPERSONA_ORIGEN = idcontacto
            ObjVentaCargaContado.v_NOMBRES_REMITENTE = IIf(idcontacto = -1, "@", CboContacto.Text) '
            ObjVentaCargaContado.contacto_mod = IIf(bContactoModificado, 1, 0)
            ObjVentaCargaContado.v_NRO_DOC_REMITENTE = IIf(Trim(TxtNroDocContacto.Text) <> "", TxtNroDocContacto.Text, "@")
            ObjVentaCargaContado.ID_TipoDocCont = iID_TipoDocCont
            ObjVentaCargaContado.NombreCont = NombresCont
            ObjVentaCargaContado.apellPatCont = apellPatCont
            ObjVentaCargaContado.apellMatCont = apellMatCont

            '======================================CONSIGNADO=================================   
            '====Agregado x NConsignado================================todo el Bloque
            If Me.iIDConsignado = 0 AndAlso Me.ChkCliente2.Checked Then
                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.BuscarContacto(GrdNConsignado("Nº Documento", 0).Value) 'TxtNroDocConsignado.Text Comentado
                Dim resp As Integer = dt.Rows.Count
                If resp = 0 Then
                    iIDConsignado = 0
                    GrdNConsignado("IDConsignado", 0).Value = "0"
                Else
                    iIDConsignado = dt.Rows(0).Item(0)
                    GrdNConsignado("IDConsignado", 0).Value = dt.Rows(0).Item(0)
                    bConsignadoModificado = True
                End If
            End If

            '***Comentado x NConsignado***********************
            'If Me.iIDConsignado = 0 AndAlso Me.ChkCliente2.Checked Then
            '    Dim objContacto As New dtoVentaCargaContado
            '    Dim dt As DataTable = objContacto.BuscarContacto(TxtNroDocConsignado.Text)
            '    Dim resp As Integer = dt.Rows.Count
            '    If resp = 0 Then
            '        iIDConsignado = 0
            '    Else
            '        iIDConsignado = dt.Rows(0).Item(0)
            '        bConsignadoModificado = True
            '    End If
            'End If

            '***Comentado x NConsignado***********************
            'PARAMETRO ID_NOMBRE_CONSIGNADO**
            'ObjVentaCargaContado.v_IDCONTACTO_DESTINO = IIf(IsNothing(iIDConsignado), 0, iIDConsignado)
            ''ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = IIf(Trim(sNombresConsig.Trim) <> "", sNombresConsig.Trim, "@")
            'ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = IIf(Me.TxtNombConsignado.Text.Trim <> "", Me.TxtNombConsignado.Text.Trim, "@")
            'ObjVentaCargaContado.NombConsignado_mod = IIf(bConsignadoModificado, 1, 0)
            'ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO = IIf(Trim(TxtNroDocConsignado.Text) <> "", TxtNroDocConsignado.Text, "@")
            'ObjVentaCargaContado.ID_TipoDocConsig = iID_TipoDocConsig
            'ObjVentaCargaContado.NombreConsignado = sNombresConsig
            'ObjVentaCargaContado.apellPatConsig = sapellPatConsig
            'ObjVentaCargaContado.apellMatConsig = sapellMatConsig
            'ObjVentaCargaContado.TelfConsignado = IIf(sTelefonoConsig.Length > 0, sTelefonoConsig, "@")

            '===Agregado x NConsignado==============================
            Me.LimpiarNConsignados()
            '21-10-2011
            For i As Integer = 0 To GrdNConsignado.Rows.Count() - 1
                ObjVentaCargaContado.v_IDCONTACTO_DESTINO &= GrdNConsignado("IDConsignado", i).Value & ";"
                ObjVentaCargaContado.v_NOMBRES_DESTINATARIO &= GrdNConsignado("Nombres", i).Value & ";"
                ObjVentaCargaContado.NombreConsignado &= GrdNConsignado("nombre", i).Value & ";"
                ObjVentaCargaContado.apellPatConsig &= GrdNConsignado("apepat", i).Value & ";"
                ObjVentaCargaContado.apellMatConsig &= GrdNConsignado("apemat", i).Value & ";"
                ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO &= GrdNConsignado("Nº Documento", i).Value & ";"
                ObjVentaCargaContado.ID_TipoDocConsig &= GrdNConsignado("tipo", i).Value & ";"
                ObjVentaCargaContado.TelfConsignado &= GrdNConsignado("Telefono", i).Value & ";"
                ObjVentaCargaContado.NombConsignado_mod &= GrdNConsignado("Modificado", i).Value & ";"
            Next

            'PARAMETRO ID_DIRECCION_DESTINO**
            If CboDireccion2.SelectedIndex = 0 Then
                idDireConsignado = -1
            End If
            ObjVentaCargaContado.v_IDDIREECION_DESTINO = idDireConsignado

            '--DIRECCION ESTRUCTURADA CONSIGNADO
            ObjVentaCargaContado.DirecConsignado_mod = IIf(bDirecConsigMod, 1, 0)
            ObjVentaCargaContado.v_DIRECCION_DESTINATARIO = IIf(idDireConsignado = -1, "@", CboDireccion2.Text)
            ObjVentaCargaContado.id_DepartamentoConsig = iDepartamentoConsig
            ObjVentaCargaContado.id_ProvinciaConsig = iProvinciaConsig
            ObjVentaCargaContado.id_DistritoConsig = iDistritoConsig
            ObjVentaCargaContado.id_viaConsig = IDviaConsig
            ObjVentaCargaContado.viaConsig = ViaConsig
            ObjVentaCargaContado.NumeroConsig = NroConsig
            ObjVentaCargaContado.manzanaConsig = ManzanaConsig
            ObjVentaCargaContado.loteConsig = loteConsig
            ObjVentaCargaContado.id_nivelConsig = id_NivelConsig
            ObjVentaCargaContado.nivelConsig = NivelConsig
            ObjVentaCargaContado.id_zonaConsig = id_ZonaConsig
            ObjVentaCargaContado.zonaConsig = ZonaConsig
            ObjVentaCargaContado.id_clasificacionConsig = id_ClasificacionConsig
            ObjVentaCargaContado.clasificacionConsig = ClasificacionConsig
            ObjVentaCargaContado.formatoConsig = FormatoConsig
            ObjVentaCargaContado.sReferencia = TxtReferencia.Text.Trim '09092011

            '---Nuevos Parametros a agregar---
            ObjVentaCargaContado.TarifarioGeneral = IIf(bTarifarioGeneral, 1, 0)
            ObjVentaCargaContado.Contado = IIf(bContado, 1, 0)
            ObjVentaCargaContado.v_MONTO_MINIMOs = monto_minimo_PCE

            'nota bOtrasAgencias deberia ser=true no=false
            ObjVentaCargaContado.v_OTRAS_AGENCIAS = True 'bOtrasAgencias

            'PARAMETROS PARA CARGA ACOMPAÑADA***********************************           
            If Val(iTotal_CA) > 0 Then
                ObjVentaCargaContado.v_SUB_TOTAL_CA = Format(iSub_Total_CA, "0.00")
                ObjVentaCargaContado.v_IMPUESTO_CA = Format(iImpuesto_CA, "0.00")
                ObjVentaCargaContado.v_TOTAL_CA = Format(iTotal_CA, "0.00")
            Else
                ObjVentaCargaContado.v_SUB_TOTAL_CA = 0
                ObjVentaCargaContado.v_IMPUESTO_CA = 0
                ObjVentaCargaContado.v_TOTAL_CA = 0
            End If

            'PARAMETRO v_cargo**************************************************
            'hlamas 22-03-2016
            'ObjVentaCargaContado.v_cargo = Me.ChkCargo.Checked
            ObjVentaCargaContado.v_cargo = Me.rbtCargoSi.Checked

            'hlamas 26-08-2015
            'hlamas 22-03-2016
            'If ModuUtil.TieneCargo(Me.GrdDocumentosCliente, 2) Then
            '    ObjVentaCargaContado.v_cargo = True
            'End If

            ObjVentaCargaContado.v_idagencia_venta = 0 'dtoUSUARIOS.m_iIdAgencia
            ObjVentaCargaContado.v_idciudad_venta = 0 'dtoUSUARIOS.m_idciudad

            If CboProducto.SelectedValue = 6 Then 'PARAMETROS CARGA ACOMPAÑADA
                'ObjVentaCargaContado.v_nroboleto = Me.TxtBoleto.Text
                ObjVentaCargaContado.v_nroboleto = IIf(Me.TxtBoleto.Text.Trim = "-", "", Me.TxtBoleto.Text.Trim)
                ObjVentaCargaContado.v_carga_acompañada = 1
                ObjVentaCargaContado.bOrigenDiferente = bOrigenDiferente
                ObjVentaCargaContado.v_TIPO_DOCUMENTO = IIf(IsDBNull(Me.TxtNroDocCliente.Tag), 0, Me.TxtNroDocCliente.Tag)
            ElseIf CboProducto.SelectedValue = 0 Then 'PARAMETROS ESTANDAR(NORMAL)
                ObjVentaCargaContado.v_nroboleto = ""
                ObjVentaCargaContado.v_carga_acompañada = 0 'Nota                
                ObjVentaCargaContado.bOrigenDiferente = False
                ObjVentaCargaContado.v_TIPO_DOCUMENTO = 0
            ElseIf CboProducto.SelectedValue = 7 Then 'PARAMETROS PYME
                ObjVentaCargaContado.v_nroboleto = ""
                ObjVentaCargaContado.v_carga_acompañada = 7
                ObjVentaCargaContado.bOrigenDiferente = False
                ObjVentaCargaContado.v_TIPO_DOCUMENTO = 0
            ElseIf CboProducto.SelectedValue = 8 Then
                ObjVentaCargaContado.v_nroboleto = ""
                ObjVentaCargaContado.v_carga_acompañada = 8
                ObjVentaCargaContado.bOrigenDiferente = False
                ObjVentaCargaContado.v_TIPO_DOCUMENTO = 0
            End If

            ' ObjVentaCargaContado.v_TELEFONO_DESTINATARIO = IIf(Trim(TxtTelfConsignado.Text) <> "", TxtTelfConsignado.Text, "@")
            ObjVentaCargaContado.v_MEMO = IIf(Trim(txtDescDescto.Text) <> "", txtDescDescto.Text, "@")
            ObjVentaCargaContado.v_MONTO_DESCUENTO = IIf(Trim(TxtDescuento.Text) <> "", TxtDescuento.Text, 0)
            '
            Dim totalCosto As Double = 0
            Dim valor1 As Double = 0
            Dim valor2 As Double = 0
            '
            ObjVentaCargaContado.v_CANTIDAD_X_PESO = 0
            ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN = 0
            ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = 0

            ObjVentaCargaContado.v_TOTAL_PESO = 0
            ObjVentaCargaContado.v_TOTAL_VOLUMEN = 0
            '

            '******************************GRID BULTOS*********************************
            If (ChkArticulos.Checked = False Or ChkArticulos.Enabled = False) And ChkM3.Checked = False Then
                'PESO
                If IsDBNull(GrdDetalleVenta.Rows(0).Cells(2)) = False Then
                    If Conversion.Val(GrdDetalleVenta(1, 0).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta(1, 0).Value
                    If Conversion.Val(GrdDetalleVenta(2, 0).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta(2, 0).Value
                    ObjVentaCargaContado.v_CANTIDAD_X_PESO = valor1
                    ObjVentaCargaContado.v_TOTAL_PESO = valor2
                    totalCosto = valor2 * tarifa_Peso
                End If

                If Me.CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX And Me.CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX_10 Then
                    'VOLUMEN
                    If IsDBNull(GrdDetalleVenta.Rows(1).Cells(2)) = False Then
                        If Conversion.Val(GrdDetalleVenta(1, 1).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta(1, 1).Value
                        If Conversion.Val(GrdDetalleVenta(2, 1).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta(2, 1).Value
                        ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN = valor1
                        ObjVentaCargaContado.v_TOTAL_VOLUMEN = valor2
                        totalCosto = totalCosto + valor2 * tarifa_Volumen
                    End If
                End If

                'SOBRE
                If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                    If IsDBNull(GrdDetalleVenta.Rows(2).Cells(2)) = False Then
                        If Conversion.Val(GrdDetalleVenta(1, 2).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta(1, 2).Value
                        ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = valor1
                        totalCosto = totalCosto + valor1 * tarifa_Sobre
                    End If
                End If

                tarifa_Peso = Format(Val(GrdDetalleVenta(3, 0).Value), "##,###,###.00")
                If Me.CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX And Me.CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX_10 Then
                    tarifa_Volumen = Format(Val(GrdDetalleVenta(3, 1).Value), "##,###,###.00")
                End If

                If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                    tarifa_Sobre = Format(Val(GrdDetalleVenta(3, 2).Value), "##,###,###.00")
                End If
            End If

            '******************************GRID M3*********************************
            If ChkM3.Checked = True Then
                'PESO
                If IsDBNull(GrdDetalleVenta.Rows(0).Cells(2)) = False Then
                    'valor1 = Format(Val(GrdDetalleVenta(1, 0).Value), "##,###,####.00")
                    'valor2 = Format(Val(GrdDetalleVenta(5, 0).Value), "##,###,####.00")
                    '-------
                    ' If Conversion.Val(GrdDetalleVenta(1, 0).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta(1, 0).Value
                    If Conversion.Val(GrdDetalleVenta(5, 0).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta(5, 0).Value
                    '-------

                    'ObjVentaCargaContado.v_CANTIDAD_X_PESO = valor1
                    ObjVentaCargaContado.v_CANTIDAD_X_PESO = Format(Val(GrdDetalleVenta(1, 0).Value), "##,###,###.00")  'valor1 16112011
                    ObjVentaCargaContado.v_TOTAL_PESO = valor2
                    totalCosto = valor2 * tarifa_Peso
                End If

                'SOBRE
                If Val(txtCantidadSobres.Text) > 0 Then
                    valor1 = Val(txtCantidadSobres.Text)
                    ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = valor1
                    totalCosto = totalCosto + valor1 * tarifa_Sobre
                End If

                '*****MOD******                
                ObjVentaCargaContado.v_METROCUBICO = 1
                ObjVentaCargaContado.v_ALTURA = FormatNumber(Format(Val(GrdDetalleVenta(2, 0).Value), "##,###,###.00"), 2)
                ObjVentaCargaContado.v_ANCHO = Format(Val(GrdDetalleVenta(3, 0).Value), "##,###,###.00")
                ObjVentaCargaContado.v_LARGO = Format(Val(GrdDetalleVenta(4, 0).Value), "##,###,###.00")
                ObjVentaCargaContado.v_PESO_KG = Format(Val(GrdDetalleVenta(5, 0).Value), "##,###,###.00")
                ObjVentaCargaContado.v_FACTOR = dFactor
                '**************

                'MOD***
                tarifa_Peso = Format(Val(GrdDetalleVenta(6, 0).Value), "##,###,###.00")
                tarifa_Sobre = Format(Val(TxtMontoBase.Text), "##,###,###.00")
                '******
            Else
                ObjVentaCargaContado.v_METROCUBICO = 0
                ObjVentaCargaContado.v_ALTURA = 0
                ObjVentaCargaContado.v_ANCHO = 0
                ObjVentaCargaContado.v_LARGO = 0
                ObjVentaCargaContado.v_PESO_KG = 0
                ObjVentaCargaContado.v_FACTOR = 0
            End If

            If ChkSobres.Checked = True Then
                ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = Val(txtCantidadSobres.Text)
            End If

            ObjVentaCargaContado.v_PRECIO_X_PESO = tarifa_Peso
            ObjVentaCargaContado.v_PRECIO_X_VOLUMEN = tarifa_Volumen
            ObjVentaCargaContado.v_PRECIO_X_SOBRE = tarifa_Sobre


            ObjVentaCargaContado.v_MONTO_SUB_TOTAL = TxtSubTotal.Text
            ObjVentaCargaContado.v_MONTO_IMPUESTO = TxtImpuesto.Text
            ObjVentaCargaContado.v_TOTAL_COSTO = TxtTotal.Text

            ObjVentaCargaContado.v_IDTIPO_MONEDA = 1 'Soles

            ObjVentaCargaContado.v_IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            ObjVentaCargaContado.v_IP = dtoUSUARIOS.IP
            ObjVentaCargaContado.v_IDROL_USUARIO = dtoUSUARIOS.IdRol

            ObjVentaCargaContado.v_MONTO_PENALIDAD = 0
            ObjVentaCargaContado.v_IDFUNCIONARIO_AUTORIZACION = 0

            ObjVentaCargaContado.v_IGV = dtoUSUARIOS.iIGV
            ObjVentaCargaContado.v_PORCENT_DEVOLUCION = 0
            ObjVentaCargaContado.v_PORCENT_DESCUENTO = Format(Val(TxtDescuento.Text), "###.00")
            ObjVentaCargaContado.v_MONTO_RECARGO = 0

            '----------------------------------------------------------------------------------------------------------------------------
            ObjVentaCargaContado.v_MONTO_BASE = Monto_Base
            ObjVentaCargaContado.v_MONTO_PENALIDAD = 0                ' Para la cantidad
            ObjVentaCargaContado.v_MONTO_RECARGO = 0                    ' Para El Peso

            'hlamas 19-11-2013
            ObjVentaCargaContado.MontoEntregaDomicilio = dblMontoEntregaDomicilio
            'hlamas 17-02-2015
            ObjVentaCargaContado.MontoDC = dblMontoDC
            'hlamas 26-08-2015
            ObjVentaCargaContado.ObservacionCargo = strObservacionCargo

            '****************************Grid Articulos******************************
            If ChkArticulos.Checked = True Then
                Try
                    Dim ii As Integer = 0
                    For ii = 0 To Me.GrdDetalleVenta.RowCount - 1
                        If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                            If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
                                ObjVentaCargaContado.v_MONTO_PENALIDAD = ObjVentaCargaContado.v_MONTO_PENALIDAD + Int(GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString)
                                ObjVentaCargaContado.v_MONTO_RECARGO = ObjVentaCargaContado.v_MONTO_RECARGO + Int(GrdDetalleVenta.Rows(ii).Cells(3).Value.ToString)
                            End If
                        End If
                    Next
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

            'CboTipoEntrega
            ObjIMPRESIONFACT_BOL.fnClear()

            '**MOD***********************************
            If ChkArticulos.Checked = False And ChkArticulos.Enabled = False And ChkM3.Checked = False Then '--BULTOS
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso = Val(GrdDetalleVenta("Sub Neto", 0).Value)
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol = Val(GrdDetalleVenta("Sub Neto", 1).Value)
                If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                    ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Val(GrdDetalleVenta("Sub Neto", 2).Value)
                End If
            ElseIf ChkArticulos.Checked = True Then
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso = "0.00" '---ARTICULOS
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol = "0.00"
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = "0.00"
            End If

            If ChkM3.Checked = True Then
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso = Val(GrdDetalleVenta("Sub Neto", 0).Value)
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol = "0.00"
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Format(Val(txtTotalSobre.Text), "##,###,###.00")
            End If
            '****************************************


            ObjIMPRESIONFACT_BOL.xCantidad_Peso = ObjVentaCargaContado.v_CANTIDAD_X_PESO
            ObjIMPRESIONFACT_BOL.xCantidad_Sobre = ObjVentaCargaContado.v_CANTIDAD_X_SOBRE
            ObjIMPRESIONFACT_BOL.xCantidad_Vol = ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN

            ObjCODIGOBARRA.clinte = ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL
            ObjCODIGOBARRA.NroDOC = ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA
            ObjCODIGOBARRA.AGEDOM = Mid(CboTipoEntrega.Text, 1, 3)

            ObjIMPRESIONFACT_BOL.xOrigen = ObjVentaCargaContado.v_UNIDAD_ORIGEN
            ObjIMPRESIONFACT_BOL.xDestino = TxtCiudadDestino.Text
            ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL = Me.txtNroNroGuia.Text.Trim '& "-" & Me.LblNroBoletaFact.Text
            ObjIMPRESIONFACT_BOL.xRazonSocial = Me.TxtNomCliente.Text.Trim
            'ObjIMPRESIONFACT_BOL.xDireccionRemitente = Me.TxtDirecCliente.Text
            ObjIMPRESIONFACT_BOL.xRuc = TxtNroDocCliente.Text
            'ObjIMPRESIONFACT_BOL.xConsignado = Me.TxtNombConsignado.Text
            ObjIMPRESIONFACT_BOL.xConsignado = ObjVentaCargaContado.v_NOMBRES_DESTINATARIO ' 'Me.TxtNombConsignado.Text 'Agregado NConsignado
            'ObjIMPRESIONFACT_BOL.xDireccionConsignado = Me.TxtDirecConsignado.Text'verificar
            ObjIMPRESIONFACT_BOL.xDireccionConsignado = Me.CboDireccion2.Text
            ObjIMPRESIONFACT_BOL.xfecha_factura = Me.txtFechaGuia.Text
            ObjIMPRESIONFACT_BOL.xTotalPeso = ObjVentaCargaContado.v_TOTAL_PESO
            ObjIMPRESIONFACT_BOL.xTotalVolumen = ObjVentaCargaContado.v_TOTAL_VOLUMEN
            ObjIMPRESIONFACT_BOL.xTotalSobres = 0
            ObjIMPRESIONFACT_BOL.xFormaPago = CboTipo.Text
            ObjIMPRESIONFACT_BOL.xNroRef = Me.txtNroNroGuia.Text.Trim '& "-" & Me.LblNroBoletaFact.Text
            ObjIMPRESIONFACT_BOL.xMemo = Me.txtDescDescto.Text
            ObjIMPRESIONFACT_BOL.xMonto_Sub_Total = Me.TxtSubTotal.Text
            ObjIMPRESIONFACT_BOL.xMonto_Impuesto = TxtImpuesto.Text
            ObjIMPRESIONFACT_BOL.xTotal_Costo = ObjVentaCargaContado.v_TOTAL_COSTO
            ObjIMPRESIONFACT_BOL.xDescuento = IIf(TxtDescuento.Text <> "", TxtDescuento.Text, "")
            ObjIMPRESIONFACT_BOL.xAgenciaDestino = IIf(CboAgenciaDest.Text <> "", CboAgenciaDest.Text, "")
            ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA = CboTipoEntrega.Text


            'If fnDigito_Chequeo(txtNroNroGuia.Text) = True Then
            txtNroNroGuia.Text = RellenoRight(NroDigitos_Guias, txtNroNroGuia.Text.Trim)
            ObjVentaCargaContado.v_SERIE_FACTURA = "000"
            ObjVentaCargaContado.v_NRO_FACTURA = txtNroNroGuia.Text.Trim
            ' ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85              
            'IMPRESION DE GUIA DE ENVIO
            '***************************************************************************************************************************
            Try
                v_Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
                v_destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            Catch ex As Exception
                MsgBox("Verifique sus datos de IATA ewn la GUIA", MsgBoxStyle.Information, "Seguridad Sistema")
            End Try

            v_iDestino = "       "
            v_iCredito = "       "
            v_iDomicilio = "      "
            v_iAgencia = "      "

            If CboTipoEntrega.SelectedValue = TipoEntrega.Agencia Then
                p_domicilio = ""
                p_agencia = "X"
            Else
                p_domicilio = "X"
                p_agencia = ""
            End If

            p_contado = ""
            p_destino = "X"
            p_credito = ""

            ObjRptGuiaEnvio.p_NroGUIA = txtNroNroGuia.Text.Trim
            ObjRptGuiaEnvio.p_tipo_entrega = v_iDomicilio & v_iAgencia
            ObjRptGuiaEnvio.p_ruc = TxtNroDocCliente.Text & "-" & ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL

            ObjRptGuiaEnvio.p_contacto = "FACTURAR A: " & IIf(CboContacto.Text <> "", CboContacto.Text, "") 'gnr
            ObjRptGuiaEnvio.p_codigo_iata_ori = v_Origen
            ObjRptGuiaEnvio.p_codigo_iata_desti = v_destino
            ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI = Me.TxtTelfCliente.Text
            'ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI = Me.TxtTelfConsignado.Text

            ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI = ObjVentaCargaContado.TelfConsignado 'GrdNConsignado("Telefono", 0).Value 'Me.TxtTelfConsignado.Text Comentado x NConsignado
            ObjRptGuiaEnvio.P_REMITENTE = Me.TxtNomCliente.Text
            ObjRptGuiaEnvio.P_DIRECCION_REMI = IIf(Me.CboDireccion.Text <> "", CboDireccion.Text, "") 'gnr
            ObjRptGuiaEnvio.P_DIRECCION_DESTI = IIf(Me.CboDireccion2.Text <> "", CboDireccion2.Text, "") 'gnr

            'ObjRptGuiaEnvio.P_NOMBRES_DESTI = Me.TxtNombConsignado.Text
            '21-10-2011
            'ObjRptGuiaEnvio.P_NOMBRES_DESTI = GrdNConsignado("Nombres", 0).Value 'Me.TxtNombConsignado.Text
            ObjRptGuiaEnvio.P_NOMBRES_DESTI = ObjVentaCargaContado.v_NOMBRES_DESTINATARIO
            ObjRptGuiaEnvio.P_FECHA_GUIA = txtFechaGuia.Text

            'ObjRptGuiaEnvio.P_TOTAL_BULTOS = ObjVentaCargaContado.v_CANTIDAD_X_PESO + ObjVentaCargaContado.v_CANTIDAD_X_ARTICULO + ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN
            'ObjRptGuiaEnvio.P_TOTAL_BULTOS = ObjVentaCargaContado.v_CANTIDAD_X_PESO + ObjVentaCargaContado.v_MONTO_PENALIDAD + ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN
            ObjRptGuiaEnvio.P_TOTAL_BULTOS = ObjVentaCargaContado.v_CANTIDAD_X_PESO + ObjVentaCargaContado.v_CANTIDAD_X_SOBRE + ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN
            ObjRptGuiaEnvio.P_TOTAL_VOLUMEN = ObjVentaCargaContado.v_TOTAL_VOLUMEN
            ObjRptGuiaEnvio.P_TOTAL_PESO = ObjVentaCargaContado.v_TOTAL_PESO + ObjVentaCargaContado.v_MONTO_RECARGO
            ObjRptGuiaEnvio.P_TOTAL_SOBRES = IIf(ObjVentaCargaContado.v_CANTIDAD_X_SOBRE.ToString() <> "", ObjVentaCargaContado.v_CANTIDAD_X_SOBRE.ToString(), " ")
            ObjRptGuiaEnvio.P_TOTAL_COSTO = ObjIMPRESIONFACT_BOL.xTotal_Costo

            ObjCODIGOBARRA.Cantidad = ObjRptGuiaEnvio.P_TOTAL_BULTOS
            ObjCODIGOBARRA.NroDOC = Mid(ObjRptGuiaEnvio.p_NroGUIA, 7, Len(ObjRptGuiaEnvio.p_NroGUIA))
            ObjCODIGOBARRA.clinte = ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL
            ObjCODIGOBARRA.Origen = v_Origen
            ObjCODIGOBARRA.Destino = v_destino & IIf(es_carga_asegurada = True, v_ca, "")
            ObjCODIGOBARRA.AGEDOM = "PCE"  'Mid(cmbTipo_Entrega.Text, 1, 3)
            ObjRptGuiaEnvio.P_PROVINCIA = TxtCiudadDestino.Text
            '**********************************************************************************************************************************************
            'End If


            asignar_documentos_clientes()
            ObjVentaCargaContado.v_IDPROCESOS = CboProducto.SelectedValue

            If ObjVentaCargaContado.GrabarVII() = True Then
                txtNroNroGuia.Text = ObjVentaCargaContado.v_GUIA
                Me.txtNroNroGuia.Refresh()
                ObjCODIGOBARRA.NroDOC = ObjVentaCargaContado.v_GUIA
                ObjVentaCargaContado.v_NRO_FACTURA = ObjVentaCargaContado.v_GUIA

                ConfiMensajeriaDlg = New FrmConfiMensajeria
                Acceso.Asignar(ConfiMensajeriaDlg, Me.hnd)
                If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                    'hlamas 14-08-2015
                    ConfiMensajeriaDlg.Tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                    ConfiMensajeriaDlg.Comprobante = ObjVentaCargaContado.v_IDFACTURA
                    ConfiMensajeriaDlg.ShowDialog()
                Else
                    MessageBox.Show(G_Mje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                ConfiMensajeriaDlg = Nothing

                TipoComprobante = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA = CboTipoEntrega.Text   ' 27/04/2007
                ObjIMPRESIONFACT_BOL.xIdFactura = ObjVentaCargaContado.v_IDFACTURA.ToString

                '---------------------------------------------------------
                '----------- Datos para Insertar el checkpoint -----------
                '---------------------------------------------------------
                objMantenimientoCheckpoint.Comprobante = ObjVentaCargaContado.v_IDFACTURA.ToString
                objMantenimientoCheckpoint.TipoComprobante = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                objMantenimientoCheckpoint.Checkpoint = 1
                objMantenimientoCheckpoint.CantidadBultos = 0

                If ChkArticulos.Checked = True Then
                    For ii As Integer = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                        If IsDBNull(GrdDetalleVenta.Rows(ii).Cells("Cantidad")) = False Then
                            If GrdDetalleVenta.Rows(ii).Cells("Cantidad").Value.ToString <> "" Then
                                objMantenimientoCheckpoint.CantidadBultos = objMantenimientoCheckpoint.CantidadBultos + Int(GrdDetalleVenta.Rows(ii).Cells("Cantidad").Value.ToString)
                            End If
                        End If
                    Next
                    objMantenimientoCheckpoint.CantidadBultos = objMantenimientoCheckpoint.CantidadBultos + objGuiaEnvio.iCANTIDAD_SOBRES
                ElseIf ChkM3.Checked = True Then
                    For ii As Integer = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                        If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                            If GrdDetalleVenta.Rows(ii).Cells("sub neto").Value > 0 And IsNumeric(GrdDetalleVenta.Rows(ii).Cells("tipo").Value) Then
                                objMantenimientoCheckpoint.CantidadBultos = objMantenimientoCheckpoint.CantidadBultos + GrdDetalleVenta.Rows(ii).Cells("Bulto").Value
                            End If
                        End If
                    Next
                    objMantenimientoCheckpoint.CantidadBultos = objMantenimientoCheckpoint.CantidadBultos + objGuiaEnvio.iCANTIDAD_SOBRES
                Else
                    objMantenimientoCheckpoint.CantidadBultos = ObjRptGuiaEnvio.P_TOTAL_BULTOS
                End If

                'hlamas 19-11-2014 no necesita ingresar a almacen, porque nunca sale del almacen
                'objMantenimientoCheckpoint.fncInsertarTrackingCheckpoint()
                '---------------------------------------------------------
                '---------------------------------------------------------


                '-----------------------------------------------------------------
                'INSERCION VOLUMETRICO
                '-----------------------------------------------------------------
                Try
                    If ChkM3.Checked = True Then
                        Dim obj As New dtoVentaCargaContado
                        Dim ii As Integer = 0
                        objGuia_Envio_Articulo.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
                        objGuia_Envio_Articulo.iIGV = dtoUSUARIOS.iIGV
                        objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
                        objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                        objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol
                        'hlamas 28-11-2013
                        For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                            If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                                If GrdDetalleVenta.Rows(ii).Cells("sub neto").Value > 0 And IsNumeric(GrdDetalleVenta.Rows(ii).Cells("Tipo").Value) Then
                                    obj.FNinsert_Volumetrico(
                                             ii,
                                             0,
                                             ObjIMPRESIONFACT_BOL.xIdFactura,
                                             GrdDetalleVenta.Rows(ii).Cells("Tipo").Value,
                                             GrdDetalleVenta.Rows(ii).Cells("Bulto").Value,
                                             GrdDetalleVenta.Rows(ii).Cells("Altura").Value,
                                             GrdDetalleVenta.Rows(ii).Cells("Ancho").Value,
                                             GrdDetalleVenta.Rows(ii).Cells("Largo").Value,
                                             GrdDetalleVenta.Rows(ii).Cells("Peso Kg").Value,
                                             dFactor,
                                             GrdDetalleVenta.Rows(ii).Cells("Costo").Value)
                                End If
                            End If
                        Next
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                '-----------------------------------------------------------------
                'INSERCION DE ARTICULOS
                '-----------------------------------------------------------------
                'CambioR 10112011
                Try
                    If ChkArticulos.Checked = True Then
                        Dim ii As Integer = 0
                        objGuia_Envio_Articulo.iCONTROL = 1
                        objGuia_Envio_Articulo.iIDGUIAS_ENVIO_ARTICULOS = 0
                        objGuia_Envio_Articulo.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
                        objGuia_Envio_Articulo.iIGV = dtoUSUARIOS.iIGV
                        objGuia_Envio_Articulo.iDESCUENTO = 0
                        objGuia_Envio_Articulo.iPENALIDAD = 0
                        objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
                        objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                        objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol
                        objGuia_Envio_Articulo.iIDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                        objGuia_Envio_Articulo.iIDESTADO_REGISTRO = 18

                        For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                            If IsDBNull(GrdDetalleVenta.Rows(ii).Cells("Cantidad")) = False Then '2
                                If GrdDetalleVenta.Rows(ii).Cells("Cantidad").Value.ToString <> "" Then '2
                                    objGuia_Envio_Articulo.iIDARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells("IDARTICULO").Value.ToString)
                                    objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells("Cantidad").Value.ToString)
                                    objGuia_Envio_Articulo.iPESO = Int(GrdDetalleVenta.Rows(ii).Cells("Peso").Value.ToString)
                                    objGuia_Envio_Articulo.iPRECIO_X_ARTICULO = Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii).Cells("Precio").Value.ToString)

                                    objGuia_Envio_Articulo.fnINSTUPD_FACBOL_ARTICULOS()
                                End If
                            End If
                        Next
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                '-----------------------------------------------------------------
                'INSERCION DE DOCUMENTOS DEL CLIENTE
                '-----------------------------------------------------------------   
                flat = True
                Dim i As Integer = 0
                Dim serie_NroDoc() As String
                objGuiaEnvio.iControl_Documentos = 1
                objGuiaEnvio.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
                objGuiaEnvio.V_IDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                Dim iContador As Integer = 0
                If objGuiaEnvio.iCONTROL = 0 Or objGuiaEnvio.iCONTROL = 1 Then
                    For i = 0 To Me.GrdDocumentosCliente.Rows().Count() - 2
                        Try
                            If IsDBNull(GrdDocumentosCliente.Rows(i).Cells("Cargo")) = False Then
                                'If Trim(GrdDocumentosCliente.Rows(i).Cells("Cargo").Value.ToString) <> "" Then
                                If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells("Cargo").Value) Then
                                    serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells(2).Value.ToString, "-")
                                    If serie_NroDoc.Length > 1 Then
                                        objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                        objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                                        If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                            If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then

                                                If objGuiaEnvio.fnSP_INSUPD_DOCUMENTOS_FACBOL() = True Then
                                                    strNroGuias_Remision = strNroGuias_Remision & "  " & objGuiaEnvio.iNro_Serie & "-" & objGuiaEnvio.iNro_Docu
                                                    iContador = iContador + 1
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        Try
                            If IsDBNull(GrdDocumentosCliente.Rows(i).Cells("Seguro")) = False Then
                                'If Trim(GrdDocumentosCliente.Rows(i).Cells("Seguro").Value.ToString) <> "" Then
                                If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells("Seguro").Value) Then
                                    serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells("Seguro").Value.ToString, "-")
                                    If serie_NroDoc.Length > 1 Then
                                        objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                        objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                                        If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                            If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then

                                                If objGuiaEnvio.fnSP_INSUPD_DOCUMENTOS_FACBOL() = True Then
                                                    strNroGuias_Remision = strNroGuias_Remision & "  " & objGuiaEnvio.iNro_Serie & "-" & objGuiaEnvio.iNro_Docu
                                                    iContador = iContador + 1
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    Next
                End If

                '****************************************************************************************************
                If Me.CboTipo.SelectedIndex <> 2 Then
                    If bControlFiscalizacion = False Then
                        If MsgBox("¿Está Seguro de Imprimir el PCE?", MsgBoxStyle.YesNo, "Seguridad Sistema") = MsgBoxResult.Yes Then
                            'ImprimirGuiaEnvio()
                            Dim dtImpresora As DataTable = FEManager.buscarPrint()
                            ImprimirTicket(ObjVentaCargaContado, dtImpresora)
                        End If
                    End If
                End If

                If Me.CboTipo.SelectedIndex <> 2 Then
                    If MsgBox("Esta Seguro de Imprimir Etiquetas..?", MsgBoxStyle.YesNo, "Seguridad Sistemas") = MsgBoxResult.Yes Then
                        If xIMPRESORA = 1 Or xIMPRESORA = 4 Then
                            fnImprimirEtiquetas()
                        Else
                            If xIMPRESORA = 2 Then
                                fnImprimirEtiquetasFAC_II()
                            Else
                                fnImprimirEtiquetasFAC_III()
                            End If
                            'fnImprimirEtiquetasFAC_II()
                        End If
                    End If
                End If

                'hlamas 12-02-2014
                If TipoGrid_ = FormatoGrid.VOLUMETRICO Or TipoGrid_ = FormatoGrid.BULTO Then
                    If Me.grbPromocion.Visible Then
                        Dim obj As New dtoVentaCargaContado
                        obj.GrabaPromocion(Me.lblPromocionDescuento.Tag, ObjVentaCargaContado.v_IDPERSONA, _
                                           Me.lblPromocionDescuento.Text, Me.lblPromocionEnvio.Text, ObjVentaCargaContado.v_IDFACTURA)
                        Me.LimpiarPromocion()
                    End If
                End If

                ObjVentaCargaContado.v_NROGUIA_VIGENTE = txtNroNroGuia.Text.Trim
                TipoComprobante = 2
                FNNUEVO()
                Me.LimpiarPromocion()
                'limpiar_documentos_cliente()
                flat = True
                iOficinaDestino = 0
            End If
            bOrigenDiferente = False
        Catch ex As Exception
            flat = False
            Throw New Exception(ex.Message)
        End Try
        Return flat
    End Function

    Public Function FnGrabarCredito() As Boolean
        Dim flat As Boolean = False
        Try
            strNroGuias_Remision = ""
            v_Origen = objGuiaEnvio.fnIATA(objGuiaEnvio.iIDUNIDAD_AGENCIA)
            v_destino = objGuiaEnvio.fnIATA(objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO)

            Dim flagGuia As Boolean = False
            'If Int(CORRELATIVO) = Int(txtNroNroGuia.Text) Then
            flagGuia = True
            'End If
            ObjRptGuiaEnvio.P_PROVINCIA = TxtCiudadDestino.Text
            ObjRptGuiaEnvio.P_CARGO = IIf(objGuiaEnvio.iIDTipoFacturacion = 3, "X", " ")

            If Grabar_GuiaEnvio() = True Then
                'hlamas 22-02-2019
                'If flagGuia = True Then
                'ObjVentaCargaContado.fnIncrementarNroDoc(3)
                'End If
                'If MessageBox.Show("¿Está seguro de Imprimir la Guía de Envío?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
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

                ObjRptGuiaEnvio.p_NroGUIA = objGuiaEnvio.guia 'txtNroNroGuia.Text.Trim
                ObjRptGuiaEnvio.p_tipo_entrega = v_iDomicilio & v_iAgencia
                ObjRptGuiaEnvio.p_ruc = Me.TxtNroDocCliente.Text & "-" & Me.TxtNomCliente.Text
                ' ObjRptGuiaEnvio.p_tipo_entrega = ObjRptGuiaEnvio.p_tipo_entrega
                'ObjRptGuiaEnvio.p_forma_pago = ObjRptGuiaEnvio.p_forma_pago
                ObjRptGuiaEnvio.p_contacto = IIf(CboContacto.SelectedIndex = 0, "", CboContacto.Text)
                ObjRptGuiaEnvio.p_codigo_iata_ori = v_Origen
                ObjRptGuiaEnvio.p_codigo_iata_desti = v_destino
                ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI = Me.TxtTelfCliente.Text
                ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI = sTelefonoConsignado 'GrdNConsignado("Telefono", 0).Value 'Me.TxtTelfConsignado.Text
                ObjRptGuiaEnvio.P_REMITENTE = IIf(CboRemitente.SelectedIndex = 0, "", CboRemitente.Text) ' Me.txtCliente_Remitente.Text 
                ObjRptGuiaEnvio.P_DIRECCION_REMI = IIf(CboDireccion.SelectedIndex = 0, "", CboDireccion.Text) 'Me.txtDireccionRemitente.Text
                ObjRptGuiaEnvio.P_DIRECCION_DESTI = IIf(CboDireccion2.SelectedIndex = 0, "", CboDireccion2.Text) 'Me.txtDireccionDestinatario.Text
                ObjRptGuiaEnvio.P_NOMBRES_DESTI = sNombresConsignado 'GrdNConsignado("Nombres", 0).Value 'Me.TxtNombConsignado.Text
                ObjRptGuiaEnvio.P_FECHA_GUIA = Me.txtFechaGuia.Text
                ObjRptGuiaEnvio.P_TOTAL_BULTOS = objGuiaEnvio.iCANTIDAD + objGuiaEnvio.iCANTIDAD_X_UNIDAD_VOLUMEN + objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI
                ObjRptGuiaEnvio.P_TOTAL_VOLUMEN = objGuiaEnvio.dTOTAL_VOLUMEN.ToString

                ObjRptGuiaEnvio.P_TOTAL_PESO = objGuiaEnvio.dTOTAL_PESO.ToString

                ObjRptGuiaEnvio.P_TOTAL_SOBRES = IIf(objGuiaEnvio.iCANTIDAD_SOBRES.ToString <> "", objGuiaEnvio.iCANTIDAD_SOBRES.ToString, " ")

                ObjCODIGOBARRA.Cantidad = ObjRptGuiaEnvio.P_TOTAL_BULTOS
                ObjCODIGOBARRA.NroDOC = ObjRptGuiaEnvio.p_NroGUIA
                ObjCODIGOBARRA.clinte = TxtNomCliente.Text
                ObjCODIGOBARRA.Origen = v_Origen
                ObjCODIGOBARRA.Destino = v_destino
                ObjCODIGOBARRA.AGEDOM = Mid(CboTipoEntrega.Text, 1, 3)

                'hlamas 22-02-2019
                'fnInprecion_Guia_Envio()
                Dim dtImpresora As DataTable = FEManager.buscarPrint()
                ImprimirTicketGuia(ObjVentaCargaContado, dtImpresora)
                'End If

                ObjCODIGOBARRA.Cantidad = objGuiaEnvio.iCANTIDAD + objGuiaEnvio.iCANTIDAD_X_UNIDAD_VOLUMEN + objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI + objGuiaEnvio.iCANTIDAD_SOBRES
                ObjCODIGOBARRA.NroDOC = objGuiaEnvio.guia
                ObjCODIGOBARRA.clinte = TxtNomCliente.Text
                ObjCODIGOBARRA.Origen = v_Origen
                ObjCODIGOBARRA.Destino = v_destino
                ObjCODIGOBARRA.AGEDOM = Mid(CboTipoEntrega.Text, 1, 3)

                If MsgBox("Está Seguro de Imprimir las Etiquetas", MsgBoxStyle.YesNoCancel, "Seguridad") = MsgBoxResult.Yes Then
                    If xIMPRESORA = 1 Or xIMPRESORA = 4 Then
                        fnImprimirEtiquetasGUIA()
                    Else
                        If xIMPRESORA = 2 Then
                            fnImprimirEtiquetasGUIA_II()
                        Else
                            fnImprimirEtiquetasGUIA_III()
                        End If
                    End If
                End If
                Me.FNNUEVO()
                flat = True
            End If
        Catch ex As Exception
            flat = False
            Throw New Exception(ex.Message)
        End Try
        Return flat
    End Function

    Sub ImprimirTicketGuia(ByVal venta As dtoVentaCargaContado, ByVal impresora As DataTable)
        Dim prn As New FEManager
        Dim feventa As New FEVenta
        Dim fecliente As New FECliente

        fecliente.tipoDocumentoID = iID_TipoDocCli
        fecliente.numeroDocumento = TxtNroDocCliente.Text.Trim
        fecliente.nombres = TxtNomCliente.Text.Trim

        'If ObjVentaCargaContado.v_direccion.Trim.Length > 0 Then
        'fecliente.direccion = ObjVentaCargaContado.v_direccion.Trim.ToUpper
        'Else
        fecliente.direccion = IIf(CboDireccion.SelectedValue > 0, CboDireccion.Text.Trim.ToUpper(), "")
        'End If
        feventa.cliente = fecliente

        Dim strSerie As String = ""

        feventa.numeroSerie = "" 'strSerie & Me.lblSerie.Text 'venta.v_SERIE_FACTURA
        feventa.numeroCorrelativo = objGuiaEnvio.guia 'venta.v_NRO_FACTURA

        feventa.fechaEmision = FechaServidor()
        feventa.tipoComprobanteID = 3
        feventa.opGravada = 0
        feventa.igv = 0
        feventa.total = CDbl(Me.TxtTotal.Text)
        feventa.totalLetras = ObjVentaCargaContado.v_nroboleto
        feventa.formaPago = Me.CboContacto.Text 'IIf(cmbFormaPago.SelectedIndex = 0, "", cmbFormaPago.Text.Trim().ToUpper())
        Dim formaPagoID As Integer = 0 'cboFormaPago.SelectedValue
        feventa.isCortesia = False

        '-->Para la impresion
        feventa.producto = CboProducto.Text
        feventa.origen = LblCiudad.Text.Trim.ToUpper()
        feventa.destino = TxtCiudadDestino.Text.Trim.ToUpper()
        feventa.remitenete = Me.CboRemitente.Text 'ObjRptGuiaEnvio.P_REMITENTE

        Dim sConsignado As String = ObjRptGuiaEnvio.P_NOMBRES_DESTI.Trim.Replace(";", ",")
        sConsignado = sConsignado.Substring(0, sConsignado.Trim.Length - 1)
        feventa.consignado = sConsignado

        feventa.tipoEntrega = Me.CboTipoEntrega.Text
        feventa.direccionEntrega = Me.CboDireccion2.Text
        feventa.agenciaEmision = dtoUSUARIOS.m_iNombreAgencia
        feventa.usuarioEmision = dtoUSUARIOS.NameLogin
        feventa.detalleVenta = FEManager.crearDetallePCE(GrdDetalleVenta, CDbl(Me.TxtTotal.Text), Me.ChkArticulos.Checked, False, venta.v_iProceso, 0)
        feventa.id = ObjVentaCargaContado.v_IDFACTURA
        strNroGuias_Remision = strNroGuias_Remision.Trim
        strNroGuias_Remision = strNroGuias_Remision.Replace("  ", ",")
        feventa.MontoLetras = strNroGuias_Remision
        feventa.direccionFiscal = IIf(Me.rbtCargoSi.Checked, "SI", "NO")
        feventa.tabla = "T_GUIAS_ENVIO"

        Dim barra As String = feventa.numeroCorrelativo
        Dim strRuta As String = Path.PathSys & "\barra.png"
        Dim bytes() As Byte = CodigoBarra(barra, strRuta)

        Dim result As New servicefe.Result
        'Dim result As New feserviceDesarrollo.Result
        prn.PrintGE(feventa, impresora, bytes)
    End Sub

    Dim iTOTAL_BULTOS As String = ""
    Dim iTOTAL_VOLUMEN As String = ""
    Dim iTOTAL_PESO As String = ""
    'Private Function Grabar_GuiaEnvio() As Boolean
    '    Dim flat As Boolean = True
    '    Dim lb_valida As Boolean
    '    Try
    '        'PARAMETRO IDGUIA ENVIO
    '        Dim iIDGUIAS_ENVIO As Integer = 0
    '        Dim sFECHA_GUIA As String = txtFechaGuia.Text '---------------------------------> PARAMETRO FECHA GUIA            
    '        Dim sNRO_GUIA As String = RellenoRight(NroDigitos_Guias, txtNroNroGuia.Text) '--> PARAMETRO NRO GUIA             
    '        '=================================CLIENTE=======================================================                                           
    '        If (TipoComprobante = 1 Or CboProducto.SelectedValue = 7) Then
    '            sNombresCli = ""
    '        ElseIf ChkCliente1.Checked And TipoComprobante = 1 Then
    '            NombresCont = ""
    '        ElseIf ChkCliente2.Checked And TipoComprobante = 1 Then
    '            sNombresConsig = ""
    '        End If

    '        '---------DATOS DEL CLIENTE------
    '        Dim iClienteModificado As Integer = IIf(bClienteModificado, 1, 0)
    '        Dim iIDPERSONA As Integer = IIf(bClienteNuevo, 0, iID_Persona) '---------------------->  PARAMETRO IDPERSONA    
    '        Dim sNombresCliente As String = IIf(TxtNomCliente.Text <> "", TxtNomCliente.Text, "@") ' PARAMETRO NOMBRES O RAZON SOCIAL
    '        Dim sNumeroDocumentoCliente As String = IIf(TxtNroDocCliente.Text <> "", TxtNroDocCliente.Text, "@")
    '        Dim iID_TipoDocumentoCliente As Integer = iID_TipoDocCli '--->agre
    '        Dim sNombreCliente As String = sNombresCli
    '        Dim sApellidoPaternoCliente As String = sApCli
    '        Dim sApellidoMaternoCliente As String = sAmCli
    '        Dim TelefonoCliente As String = IIf(sTelfCliente.Length > 0, sTelfCliente, "@")

    '        '--DIRECCION ESTRUCTURADO DEL CLIENTE          
    '        Dim iDireccionCliente_Mod As Integer = IIf(bDireccionModificada, 1, 0)
    '        'PARAMETRO IDDIRECCION_ORIGEN******
    '        If CboDireccion.SelectedValue = 0 Then
    '            IdDireccionOrigen = -1
    '        End If
    '        Dim IDDIREECION_ORIGEN As Integer = IdDireccionOrigen
    '        'PARAMETRO NOMBRE DE LA DIRECCION**
    '        Dim NombreDireccion_Origen As String = IIf(IdDireccionOrigen = -1, "@", CboDireccion.Text)
    '        'ObjVentaCargaContado.id_DepartamentoCli = iDepartamentoCli
    '        'ObjVentaCargaContado.id_ProvinciaCli = iProvinciaCli
    '        'ObjVentaCargaContado.id_DistritoCli = iDistritoCli
    '        'ObjVentaCargaContado.id_viaCli = IDviaCli
    '        'ObjVentaCargaContado.viaCli = ViaCli
    '        'ObjVentaCargaContado.NumeroCli = NroCli
    '        'ObjVentaCargaContado.manzanaCli = ManzanaCli
    '        'ObjVentaCargaContado.loteCli = loteCli
    '        'ObjVentaCargaContado.id_nivelCli = id_NivelCli
    '        'ObjVentaCargaContado.nivelCli = NivelCli
    '        'ObjVentaCargaContado.id_zonaCli = id_ZonaCli
    '        'ObjVentaCargaContado.zonaCli = ZonaCli
    '        'ObjVentaCargaContado.id_clasificacionCli = id_ClasificacionCli
    '        'ObjVentaCargaContado.clasificacionCli = ClasificacionCli          


    '        '=============================DATOS REMITENTE=====================================
    '        If CboRemitente.SelectedIndex = 0 Then
    '            idRemitente = -1
    '        End If
    '        If idcontacto = 0 AndAlso Me.ChkCliente.Checked Then
    '            Dim objContacto As New dtoVentaCargaContado
    '            Dim dt As DataTable = objContacto.BuscarContacto(Me.TxtNroDocCliente.Text, TxtNumDocRemitente.Text)
    '            Dim resp As Integer = dt.Rows.Count
    '            If resp = 0 Then
    '                Me.TxtNumDocRemitente.Tag = 0
    '                idRemitente = 0
    '            Else
    '                Me.TxtNumDocRemitente.Tag = dt.Rows(0).Item(0)
    '                idRemitente = dt.Rows(0).Item(0)
    '                bRemitenteModificado = False
    '            End If
    '        End If
    '        'PARAMETRO ID_NOMBRE_REMITENTE**
    '        Dim iRemitenteModificado As Integer = IIf(bRemitenteModificado, 1, 0)
    '        Dim iIDRemitente As Integer = idRemitente
    '        Dim sNombresRemitente As String = IIf(idRemitente = -1, "@", CboRemitente.Text)
    '        Dim sNumeroDocumentoRemitente As String = IIf(sNroDocRemitente.Trim = "", "@", sNroDocRemitente.Trim)
    '        Dim iID_TipoDocumentoRemitente As Integer = iID_TipoDocRemitente
    '        Dim sNombreRemitente As String = sNombresRemitente
    '        Dim sApellidoPaternoRemitente As String = sApRemitente
    '        Dim sApellidoMaternoRemitente As String = sAmRemitente

    '        '=============================DATOS CONTACTO======================================                           
    '        'PARAMETRO ID_NOMBRE_CONTACTO**          
    '        If CboContacto.SelectedIndex = 0 Then
    '            idcontacto = -1
    '        End If
    '        If idcontacto = 0 AndAlso Me.ChkCliente1.Checked Then
    '            Dim objContacto As New dtoVentaCargaContado
    '            Dim dt As DataTable = objContacto.BuscarContacto(Me.TxtNroDocCliente.Text, TxtNroDocContacto.Text)
    '            Dim resp As Integer = dt.Rows.Count
    '            If resp = 0 Then
    '                Me.TxtNroDocContacto.Tag = 0
    '                idcontacto = 0
    '            Else
    '                Me.TxtNroDocContacto.Tag = dt.Rows(0).Item(0)
    '                idcontacto = dt.Rows(0).Item(0)
    '                bContactoModificado = False
    '            End If
    '        End If

    '        Dim iContactoModificado As Integer = IIf(bContactoModificado, 1, 0)
    '        Dim iIDcontacto As Integer = idcontacto
    '        Dim sNombresContacto As String = IIf(idcontacto = -1, "@", CboContacto.Text) '            
    '        Dim sNumeroDocumentoContacto As String = IIf(Trim(TxtNroDocContacto.Text) <> "", TxtNroDocContacto.Text, "@")
    '        Dim iIDTipoDocumentoContacto As Integer = iID_TipoDocCont
    '        Dim sNombreContacto As String = NombresCont
    '        Dim sApellidoPaternoContacto As String = apellPatCont
    '        Dim sApellidoMaternoContacto As String = apellMatCont

    '        '======================================CONSIGNADO=================================   
    '        If iIDConsignado = 0 AndAlso Me.ChkCliente2.Checked Then
    '            Dim objContacto As New dtoVentaCargaContado
    '            Dim dt As DataTable = objContacto.BuscarContacto(TxtNroDocConsignado.Text)
    '            Dim resp As Integer = dt.Rows.Count
    '            If resp = 0 Then
    '                iIDConsignado = 0
    '            Else
    '                iIDConsignado = dt.Rows(0).Item(0)
    '                bConsignadoModificado = False
    '            End If
    '        End If

    '        'PARAMETRO ID_NOMBRE_CONSIGNADO**
    '        Dim iConsignadoModificado As Integer = IIf(bConsignadoModificado, 1, 0)
    '        Dim iID_Consignado As Integer = IIf(IsNothing(iIDConsignado), 0, iIDConsignado)
    '        Dim sNombresConsignado As String = IIf(Me.TxtNombConsignado.Text.Trim <> "", Me.TxtNombConsignado.Text.Trim, "@")
    '        Dim sNumeroDocumentoConsignado As String = IIf(Trim(TxtNroDocConsignado.Text) <> "", TxtNroDocConsignado.Text, "@")
    '        Dim iIDTipoDocumentoConsignado As Integer = iID_TipoDocConsig
    '        Dim sNombreConsignado As String = sNombresConsig
    '        Dim sApellidoPaternoConsignado As String = sapellPatConsig
    '        Dim sApellidoMaternoConsignado As String = sapellMatConsig
    '        Dim sTelefonoConsignado As String = IIf(sTelefonoConsig.Length > 0, sTelefonoConsig, "@")

    '        'PARAMETRO ID_DIRECCION_DESTINO**
    '        If CboDireccion2.SelectedIndex = 0 Then
    '            idDireConsignado = -1
    '        End If
    '        ObjVentaCargaContado.v_IDDIREECION_DESTINO = idDireConsignado

    '        '--DIRECCION ESTRUCTURADA CONSIGNADO
    '        Dim iDirecConsignado_mod As Integer = IIf(bDirecConsigMod, 1, 0)
    '        ObjVentaCargaContado.v_DIRECCION_DESTINATARIO = IIf(idDireConsignado = -1, "@", CboDireccion2.Text)
    '        'ObjVentaCargaContado.id_DepartamentoConsig = iDepartamentoConsig
    '        'ObjVentaCargaContado.id_ProvinciaConsig = iProvinciaConsig
    '        'ObjVentaCargaContado.id_DistritoConsig = iDistritoConsig
    '        'ObjVentaCargaContado.id_viaConsig = IDviaConsig
    '        'ObjVentaCargaContado.viaConsig = ViaConsig
    '        'ObjVentaCargaContado.NumeroConsig = NroConsig
    '        'ObjVentaCargaContado.manzanaConsig = ManzanaConsig
    '        'ObjVentaCargaContado.loteConsig = loteConsig
    '        'ObjVentaCargaContado.id_nivelConsig = id_NivelConsig
    '        'ObjVentaCargaContado.nivelConsig = NivelConsig
    '        'ObjVentaCargaContado.id_zonaConsig = id_ZonaConsig
    '        'ObjVentaCargaContado.zonaConsig = ZonaConsig
    '        'ObjVentaCargaContado.id_clasificacionConsig = id_ClasificacionConsig
    '        'ObjVentaCargaContado.clasificacionConsig = ClasificacionConsig
    '        'ObjVentaCargaContado.formatoConsig = FormatoConsig

    '        '----------------------------------------------------------------------            
    '        Dim iIDTIPO_ENTREGA As Integer = CboTipoEntrega.SelectedValue 'PARAMETRO TIPO ENTREGA CARGA (Agencia,Domicilio)            
    '        Dim iIDFORMA_PAGO As Integer = 2 'PARAMETRO FORMA PAGO 'Int(objGuiaEnvio.coll_Lista_Forma_Pagos.Item(Me.cmbFormaCredito.SelectedIndex.ToString()))            
    '        Dim iAGENCIA_ORIGEN As Integer = objGuiaEnvio.iIDUNIDAD_AGENCIA 'PARAMETRO IDUNIDAD AGENCIA_ORIGEN  'agregar 'Int(coll_iOrigen.Item(iWinDestino.IndexOf(txtiWinOrigen.Text) + 1))
    '        Dim iIDCIUDAD_TRANSITO As Integer = objGuiaEnvio.iIDUNIDAD_AGENCIA 'PARAMETRO IDCIUDAD TRANSITO
    '        Dim iAGENCIA_DESTINO As Integer = idUnidadAgencias 'PARAMETRO IDAGENCIA DESTINO  'agregar'Int(coll_iDestino.Item(iWinDestino.IndexOf(txtiWinDestino.Text) + 1))
    '        Dim iIDAGENCIAS As Integer = dtoUSUARIOS.m_iIdAgencia 'PARAMETRO IDAGENCIAS'Agregar codigo           
    '        Dim iIDDIRECCION_REMITENTE As Integer = IdDireccionOrigen 'PARAMETRO IDDIRECCION REMITENTE

    '        'PARAMETRO IDTELEFONO REMITENTE
    '        'OBSERVACION
    '        'If iWinTelefono_Remitente.Count > 0 Then
    '        '    indexof = iWinTelefono_Remitente.IndexOf(txtTelefonoRemitente.Text)
    '        '    objGuiaEnvio.iIDTEFONO_REMITENTE = -1
    '        '    If indexof >= 0 Then
    '        '        objGuiaEnvio.iIDTEFONO_REMITENTE = Int(objGuiaEnvio.coll_Telefono_Remitente.Item(indexof.ToString))
    '        '    End If
    '        'End If
    '        Dim iIDCONTACTO_REMITENTE As Integer = idcontacto 'CboContacto.SelectedValue 'PARAMETRO IDCONTACTOREMITENTE
    '        Dim iIDTELEFONO_REMITENTE As Integer = 0 'PARAMETRO IDTELEFONO REMITENTE
    '        Dim iIDCONTACTO_DESTINATARIO As Integer = IIf(IsNothing(iIDConsignado), 0, iIDConsignado) 'CODIGO NOMBRE CONSIGNADO 'Int(objGuiaEnvio.coll_Nombres_Destinatario.Item(indexof.ToString))
    '        Dim iIDDIRECCION_DESTINATARIO As Integer = idDireConsignado  'CODIGO DIRECCION CONSIGNADO'Int(objGuiaEnvio.coll_Direccion_Destinatario.Item(indexof.ToString))

    '        'PARAMETRO IDTELEFONO CONSIGNADO
    '        'OBSERVACION
    '        'If iWinTelefono_Destinatario.Count > 0 Then
    '        '    indexof = iWinTelefono_Destinatario.IndexOf(txtTelefonoDestinatario.Text)
    '        '    objGuiaEnvio.iIDTEFONO_CONSIGNADO = -1
    '        '    If indexof >= 0 Then
    '        '        objGuiaEnvio.iIDTEFONO_CONSIGNADO = Int(objGuiaEnvio.coll_Telefono_Destinatario.Item(indexof.ToString))
    '        '    End If
    '        'End If
    '        Dim iIDTELEFONO_CONSIGNADO As Integer = 0 'PARAMETRO IDTELEFONO CONSIGNADO

    '        Dim iCANTIDAD As Integer = 0  'Unidades Peso
    '        Dim iCANTIDAD_X_UNIDAD_VOLUMEN As Integer = 0 'Unidades Volumen
    '        Dim iCANTIDAD_X_UNIDAD_ARTI As Integer = 0 'Unidades Articulos
    '        Dim dTOTAL_VOLUMEN As Double = 0
    '        Dim dTOTAL_PESO As Double = 0

    '        Dim totalCosto As Double = 0
    '        Dim valor1 As Double = 0
    '        Dim valor2 As Double = 0

    '        'Camp1 = "Tipo" : camp2 = "Bulto" : camp3 = "Altura"
    '        'camp4 = "Ancho" : camp5 = "Largo" : camp6 = "Peso Kg"
    '        'camp7 = "Costo" : camp8 = "Sub Neto"

    '        If TipoGrid_ = FormatoGrid.BULTO Then
    '            valor1 = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Peso/Volumen", 0).Value.ToString)), "##,###,####.00")
    '            valor2 = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Bulto", 0).Value.ToString)), "##,###,####.00")
    '            iCANTIDAD = valor2 'PARAMETRO ICANTIDAD
    '            valor2 = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Costo", 0).Value.ToString)), "##,###,####.00") ' Costo 
    '            dTOTAL_PESO = valor1 'PARAMETRO DTOTAL PESO
    '            totalCosto = valor1 * valor2
    '        End If

    '        Dim iMetroCubico As Integer = 0
    '        If ChkM3.Checked Then
    '            iMetroCubico = 1

    '            valor2 = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Bulto", 1).Value.ToString)), "##,###,###.00")
    '            iCANTIDAD_X_UNIDAD_VOLUMEN = valor2 'PARAMETRO iCANTIDAD_X_UNIDAD_VOLUMEN
    '            valor1 = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Costo", 1).Value.ToString)), "##,###,###.00")
    '            valor2 = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Peso Kg", 1).Value.ToString)), "##,###,###.00")
    '            dTOTAL_VOLUMEN = valor2 'PARAMETRO DTOTAL_VOLUMEN
    '            totalCosto = totalCosto + valor1 * valor2 + Monto_Base
    '        End If


    '        If ChkArticulos.Checked Then
    '            Dim Total As Double = 0
    '            Dim ii1 As Integer = 0
    '            For ii1 = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
    '                Total = Total + Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii1).Cells(3).Value.ToString)
    '                'PARAMETRO iCANTIDAD_X_UNIDAD_ARTI
    '                iCANTIDAD_X_UNIDAD_ARTI = objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI + Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii1).Cells(3).Value.ToString)
    '            Next
    '        End If


    '        'PARAMETRO dPRECIO_X_UNIDAD
    '        Dim dPRECIO_X_UNIDAD As Double = tarifa_Articulo 'kgr
    '        'PARAMETRO dIMPUESTO
    '        Dim dIMPUESTO As Double = IGV
    '        'PARAMETRO dMONTO_IMPUESTO
    '        Dim dMONTO_IMPUESTO As Double = Me.TxtImpuesto.Text
    '        'PARAMETRO dTOTAL_COSTO
    '        Dim dTOTAL_COSTO As Double = Me.TxtTotal.Text
    '        'PARAMETRO iIDUSUARIO_PERSONAL
    '        Dim iIDUSUARIO_PERSONAL As Integer = dtoUSUARIOS.IdLogin
    '        'PARAMETRO iIDROL_USUARIO
    '        Dim iIDROL_USUARIO As Integer = dtoUSUARIOS.IdRol
    '        'PARAMETRO sIP
    '        Dim sIP As String = dtoUSUARIOS.IP
    '        'PARAMETRO iIDESTADO_REGISTRO
    '        Dim iIDESTADO_REGISTRO As Integer = 18

    '        'PARAMETRO iNOMBRES_REMITENTE
    '        Dim iNOMBRES_REMITENTE As String = ""
    '        If Me.CboRemitente.Text <> "" And Me.CboRemitente.Text.Length > 3 Then
    '            iNOMBRES_REMITENTE = Me.CboRemitente.Text
    '        Else
    '            iNOMBRES_REMITENTE = "NULL"
    '        End If

    '        'PARAMETRO iDNI_REMITENTE
    '        Dim sDNI_REMITENTE As String = ""
    '        If TxtNroDocContacto.Text <> "" And TxtNroDocContacto.Text.Length > 5 Then
    '            sDNI_REMITENTE = Me.TxtNroDocContacto.Text
    '        Else
    '            sDNI_REMITENTE = "@"
    '        End If

    '        'PARAMETRO iDIRECCION_REMITENTE
    '        Dim sDIRECCION_REMITENTE As String = ""
    '        If CboDireccion.Text <> "" And CboDireccion.Text.Length > 5 Then
    '            sDIRECCION_REMITENTE = CboDireccion.Text
    '        End If

    '        'PARAMETRO iNOMBRES_DESTINATARIO... (CONSIGNADO)
    '        Dim sNOMBRES_DESTINATARIO As String = ""
    '        If TxtNombConsignado.Text <> "" And TxtNombConsignado.Text.Length > 5 Then
    '            sNOMBRES_DESTINATARIO = TxtNombConsignado.Text
    '        End If

    '        'PARAMETRO iDNI_DESTINATARIO
    '        Dim iDNI_DESTINATARIO As String = ""
    '        If TxtNroDocConsignado.Text <> "" Then '19/08/2008 -  And txtDNIDestinatario.Text.Length > 5 Then ---> No se sabe el nº dcto del consignado
    '            iDNI_DESTINATARIO = TxtNroDocConsignado.Text
    '        End If

    '        'PARAMETRO iDIRECCION_DESTINATARIO
    '        Dim iDIRECCION_DESTINATARIO As String = ""
    '        If CboDireccion2.Text <> "" And CboDireccion2.Text.Length > 5 Then
    '            iDIRECCION_DESTINATARIO = CboDireccion2.Text
    '        End If
    '        'PARAMETRO iCARGO

    '        Dim iCARGO As Integer = Int(ChkCargo.Checked)

    '        'PARAMETRO sTelefono_Remitente
    '        Dim sTelefono_Remitente As String = IIf(TxtTelfCliente.Text <> "", TxtTelfCliente.Text, "NULL")
    '        'PARAMETRO sTelefono_Destinatario
    '        Dim sTelefono_Destinatario As String = IIf(TxtTelfConsignado.Text <> "", TxtTelfConsignado.Text, "NULL")

    '        'PARAMETRO iID_REMITENTE
    '        Dim iID_REMITENTE As Integer = 0
    '        'PARAMETRO iREMITENTE 
    '        Dim sREMITENTE As String = CboRemitente.Text 'OBSERVACION
    '        'PARAMETRO iNRODOC_REM
    '        Dim sNRODOC_REM As String = TxtNumDocRemitente.Text
    '        'PARAMETRO iIDCENTRO_COSTO
    '        Dim iIDCENTRO_COSTO As Integer = CboSubCuenta.SelectedValue

    '        Dim iCANTIDAD_SOBRES As Integer
    '        Dim iIDSINO_SOBRES As Integer
    '        If ChkSobres.Checked = True Then
    '            'PARAMETRO iCANTIDAD_SOBRES
    '            iCANTIDAD_SOBRES = Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
    '            'PARAMETRO iIDSINO_SOBRES
    '            iIDSINO_SOBRES = 1
    '        Else
    '            iCANTIDAD_SOBRES = 0
    '            iIDSINO_SOBRES = 0
    '        End If

    '        'PARAMETRO iIDAGENCIAS_DESTINO
    '        Dim iIDAGENCIAS_DESTINO As Integer = CboAgenciaDest.SelectedValue

    '        objGuiaEnvio.iIDCONTACTO_PERSONA = 0
    '        objGuiaEnvio.iIDDIRECCION_CONSIGNADO = 0

    '        'PARAMETRO MONTO BASE
    '        Dim dMONTO_BASE As Double
    '        Dim dPrecio_x_Volumen As Double
    '        Dim dPrecio_x_Peso As Double
    '        If TipoGrid_ = FormatoGrid.BULTO Then
    '            dMONTO_BASE = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Costo", 3).Value.ToString)), "##,###,####.00") ' Base
    '            dPrecio_x_Volumen = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Costo", 1).Value.ToString)), "##,###,####.00") ' Costo x volumen 
    '            dPrecio_x_Peso = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Costo", 0).Value.ToString)), "##,###,####.00") ' Costo x Peso                 
    '        End If


    '        'OBSERVACION
    '        'If Me.dtGridViewArticulo.Visible = True Then
    '        '    objGuiaEnvio.dTOTAL_PESO = fn_peso_desde_articulos()
    '        'End If

    '        'If Me.dtGridViewArticulo.Visible = True Then
    '        '    objGuiaEnvio.dTOTAL_VOLUMEN = fn_Volumen_desde_articulos()
    '        'End If

    '        '----------------------------------------------------------------------------------------------------------------------            
    '        'objGuiaEnvio.dMONTO_BASE = Monto_Base '26/08/2008  Se toma el valor de los bultos                       
    '        iTOTAL_BULTOS = ""
    '        iTOTAL_VOLUMEN = ""
    '        iTOTAL_PESO = ""


    '        Dim sReferencia As String = TxtReferencia.Text.Trim

    '        '=========================================================
    '        If objGuiaEnvio.GrabarGuiaCredito(0, sFECHA_GUIA, sNRO_GUIA, iIDTIPO_ENTREGA, iIDFORMA_PAGO, _
    '                                          iAGENCIA_ORIGEN, iIDCIUDAD_TRANSITO, iAGENCIA_DESTINO, iIDAGENCIAS, iIDCONTACTO_REMITENTE, _
    '                                          iIDDIRECCION_REMITENTE, iIDTELEFONO_REMITENTE, iIDCONTACTO_DESTINATARIO, iIDDIRECCION_DESTINATARIO, _
    '                                          iIDTELEFONO_CONSIGNADO, dMONTO_BASE, dTOTAL_PESO, iCANTIDAD, dTOTAL_VOLUMEN, iCANTIDAD_X_UNIDAD_VOLUMEN, _
    '                                          iCANTIDAD_X_UNIDAD_ARTI, dPRECIO_X_UNIDAD, dIMPUESTO, dMONTO_IMPUESTO, dTOTAL_COSTO, iIDUSUARIO_PERSONAL, _
    '                                          iIDROL_USUARIO, sIP, iIDESTADO_REGISTRO, iNOMBRES_REMITENTE, sDNI_REMITENTE, sDIRECCION_REMITENTE, _
    '                                          sNOMBRES_DESTINATARIO, iDNI_DESTINATARIO, iDIRECCION_DESTINATARIO, dPrecio_x_Volumen, dPrecio_x_Peso, _
    '                                          iCARGO, sTelefono_Remitente, sTelefono_Destinatario, iID_REMITENTE, sREMITENTE, sNRODOC_REM, iIDCENTRO_COSTO, _
    '                                          iCANTIDAD_SOBRES, iIDSINO_SOBRES, iIDAGENCIAS_DESTINO, iClienteModificado, iIDPERSONA, sNombresCliente, _
    '                                          sNumeroDocumentoCliente, iID_TipoDocumentoCliente, sNombreCliente, sApellidoPaternoCliente, _
    '                                          sApellidoMaternoCliente, TelefonoCliente, iRemitenteModificado, iIDRemitente, sNombresRemitente, _
    '                                          sNumeroDocumentoRemitente, iID_TipoDocumentoRemitente, sNombreRemitente, sApellidoPaternoRemitente, _
    '                                          sApellidoMaternoRemitente, iContactoModificado, iIDcontacto, sNombresContacto, sNumeroDocumentoContacto, _
    '                                          iIDTipoDocumentoContacto, sNombreContacto, sApellidoPaternoContacto, sApellidoMaternoContacto, _
    '                                         iConsignadoModificado, iID_Consignado, sNombresConsignado, sNumeroDocumentoConsignado, _
    '                                         iIDTipoDocumentoConsignado, sNombreConsignado, sApellidoPaternoConsignado, sApellidoMaternoConsignado, _
    '                                         sTelefonoConsignado, iDireccionCliente_Mod, iDepartamentoCli, iProvinciaCli, iDistritoCli,
    '                                         IDviaCli, ViaCli, NroCli, ManzanaCli, loteCli, id_NivelCli, NivelCli, id_ZonaCli, ZonaCli, _
    '                                         id_ClasificacionCli, ClasificacionCli, iDirecConsignado_mod, iDepartamentoConsig, iProvinciaConsig, _
    '                                         iDistritoConsig, IDviaConsig, ViaConsig, NroConsig, ManzanaConsig, loteConsig, id_NivelConsig, _
    '                                         NivelConsig, id_ZonaConsig, ZonaConsig, id_ClasificacionConsig, ClasificacionConsig, sEmail, sReferencia, iMetroCubico) = True Then


    '            iTOTAL_BULTOS = objGuiaEnvio.iCANTIDAD + objGuiaEnvio.iCANTIDAD_X_UNIDAD_VOLUMEN + objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI + objGuiaEnvio.iCANTIDAD_SOBRES
    '            iTOTAL_VOLUMEN = objGuiaEnvio.dTOTAL_VOLUMEN
    '            iTOTAL_PESO = objGuiaEnvio.dTOTAL_PESO

    '            '-----------------------------------------------------------------
    '            'INSERCION VOLUMETRICO
    '            '-----------------------------------------------------------------
    '            Try
    '                If ChkM3.Checked = True Then
    '                    Dim obj As New dtoVentaCargaContado
    '                    Dim ii As Integer = 0
    '                    objGuia_Envio_Articulo.iIDGUIAS_ENVIO = objGuiaEnvio.iIDGUIAS_ENVIO
    '                    objGuia_Envio_Articulo.iIGV = dtoUSUARIOS.iIGV
    '                    objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
    '                    objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
    '                    objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol

    '                    For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
    '                        If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
    '                            If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
    '                                obj.FNinsert_Volumetrico(
    '                                         ii,
    '                                         0,
    '                                         objGuiaEnvio.iIDGUIAS_ENVIO,
    '                                         GrdDetalleVenta.Rows(ii).Cells("Tipo").Value,
    '                                         GrdDetalleVenta.Rows(ii).Cells("Bulto").Value,
    '                                         GrdDetalleVenta.Rows(ii).Cells("Altura").Value,
    '                                         GrdDetalleVenta.Rows(ii).Cells("Ancho").Value,
    '                                         GrdDetalleVenta.Rows(ii).Cells("Largo").Value,
    '                                         GrdDetalleVenta.Rows(ii).Cells("Peso Kg").Value,
    '                                         dFactor,
    '                                         GrdDetalleVenta.Rows(ii).Cells("Costo").Value)
    '                            End If
    '                        End If
    '                    Next
    '                End If
    '            Catch ex As Exception
    '                MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            End Try

    '            '-----------------------------------------------------------------
    '            'INSERCION DE ARTICULOS
    '            '-----------------------------------------------------------------                
    '            objGuia_Envio_Articulo.iCONTROL = 1
    '            objGuia_Envio_Articulo.iIDGUIAS_ENVIO_ARTICULOS = 0
    '            objGuia_Envio_Articulo.iIDGUIAS_ENVIO = objGuiaEnvio.iIDGUIAS_ENVIO
    '            objGuia_Envio_Articulo.iIGV = IGV
    '            objGuia_Envio_Articulo.iDESCUENTO = 0
    '            objGuia_Envio_Articulo.iPENALIDAD = 0
    '            objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
    '            objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
    '            objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol
    '            objGuia_Envio_Articulo.iIDESTADO_REGISTRO = 18

    '            If ChkArticulos.Checked = True Then
    '                For ii As Integer = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
    '                    If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
    '                        If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
    '                            objGuia_Envio_Articulo.iIDARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells("IDARTICULO").Value.ToString)
    '                            objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells("Cantidad").Value.ToString)
    '                            If GrdDetalleVenta.Rows(ii).Cells("M3").Value.ToString = "" Then
    '                                objGuia_Envio_Articulo.iMETRO_CUBICO = 0
    '                            Else
    '                                objGuia_Envio_Articulo.iMETRO_CUBICO = CDbl(GrdDetalleVenta.Rows(ii).Cells("M3").Value.ToString)
    '                            End If
    '                            objGuia_Envio_Articulo.iPESO = Int(GrdDetalleVenta.Rows(ii).Cells("Peso").Value.ToString)
    '                            objGuia_Envio_Articulo.iPRECIO_X_ARTICULO = Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii).Cells("P.Total").Value.ToString)
    '                            objGuia_Envio_Articulo.fnINSTUPD_GENVIO_ARTICULOS_RGT()
    '                        End If
    '                    End If
    '                Next
    '            End If


    '            '---------------DETALLE DOCUMENTOS----------------------------------
    '            flat = True
    '            Dim i As Integer = 0
    '            Dim serie_NroDoc() As String
    '            objGuiaEnvio.iControl_Documentos = 1
    '            Dim iContador As Integer = 0
    '            'If objGuiaEnvio.iCONTROL = 1 Then
    '            For i = 0 To Me.GrdDocumentosCliente.Rows().Count() - 2
    '                Try
    '                    If IsDBNull(GrdDocumentosCliente.Rows(i).Cells("Cargo")) = False Then
    '                        'If Trim(GrdDocumentosCliente.Rows(i).Cells("Cargo").Value.ToString) <> "" Then
    '                        If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells("Cargo").Value) Then
    '                            serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells("Cargo").Value.ToString, "-")
    '                            If serie_NroDoc.Length > 1 Then
    '                                objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
    '                                objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
    '                                strNroGuias_Remision = strNroGuias_Remision & "  " & objGuiaEnvio.iNro_Serie & "-" & objGuiaEnvio.iNro_Docu
    '                                If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
    '                                    If objGuiaEnvio.fnINSUPD_DOCUMENTOS_GUIAS() = True Then
    '                                        iContador = iContador + 1
    '                                    End If
    '                                End If
    '                            End If
    '                        End If
    '                    End If
    '                Catch ex As Exception
    '                    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                End Try

    '                Try
    '                    If IsDBNull(GrdDocumentosCliente.Rows(i).Cells("Seguro")) = False Then
    '                        'If GrdDocumentosCliente.Rows(i).Cells("Seguro").Value.ToString <> "" Then
    '                        If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells("Seguro").Value) Then
    '                            serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells("Seguro").Value.ToString, "-")
    '                            If serie_NroDoc.Length > 1 Then
    '                                objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
    '                                objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
    '                                strNroGuias_Remision = strNroGuias_Remision & "  " & objGuiaEnvio.iNro_Serie & "-" & objGuiaEnvio.iNro_Docu
    '                                If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
    '                                    If objGuiaEnvio.fnINSUPD_DOCUMENTOS_GUIAS() = True Then
    '                                        iContador = iContador + 1
    '                                    End If
    '                                End If
    '                            End If
    '                        End If
    '                    End If
    '                Catch ex As Exception
    '                    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                End Try
    '            Next
    '            'End If
    '        Else
    '            Me.Cursor = Cursors.Default
    '            'MessageBox.Show("La Guia no se Registró", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            flat = False
    '        End If
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '        flat = False
    '    End Try
    '    Return flat
    'End Function

#Region "FUNCIONES DE IMPRESIONES GUIA_ENVIO CREDITO"

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
                    iIzquierda = dt.Rows(0).Item("izquierda")
                    flags = True
                End If
            End If

            Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
            Dim iLong As Integer = IIf(iTamaño = 0, 22, iTamaño)

            y = iLong * pagina + 2
            i += 1

            If flags Then
                '21-10-2011
                Dim sConsignado As String = ObjRptGuiaEnvio.P_NOMBRES_DESTI.Trim.Replace(";", ",")
                sConsignado = sConsignado.Substring(0, sConsignado.Trim.Length - 1)

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

                obj.EscribirLinea(y + 5, 59, sConsignado)
                obj.EscribirLinea(y + 6, 59, ObjRptGuiaEnvio.P_DIRECCION_DESTI)

                obj.EscribirLinea(y + 2, 33, p_domicilio)
                obj.EscribirLinea(y + 2, 43, p_agencia)
                obj.EscribirLinea(y + 2, 54, p_contado)
                obj.EscribirLinea(y + 2, 64, p_destino)
                obj.EscribirLinea(y + 2, 76, p_credito)

                'obj.EscribirLinea(ObjRptGuiaEnvio.P_CARGO)
                obj.EscribirLinea(y + 9, 0, ObjRptGuiaEnvio.p_contacto)
                obj.EscribirLinea(y + 8, 29, ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI)
                obj.EscribirLinea(y + 8, 59, Me.CboAgenciaDest.Text)
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

                '----------------------------
                obj.Comprimido = True
                obj.Preliminar = True
                obj.Tamaño = iLong
                obj.Imprimir()
                obj.Finalizar()

                Dim frm As New FrmPreview
                frm.Tamaño = iLong
                frm.Documento =
                frm.Text = "GE"
                frm.ShowDialog()

                '**********************************
                'obj.Comprimido = True
                'obj.Tamaño = iLong
                'obj.Imprimir()
                'obj.Finalizar()
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

    Dim bRango As Boolean
    Dim sFecha As String
    Dim sHora As String
    Public Function fnImprimirEtiquetasGUIA() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()
            Dim strAgenciaDestino As String = dtoVentaCargaContado.AgenciaAbreviado(Me.CboAgenciaDest.SelectedValue)

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
            'hlamas 26-08-2015
            'agregar CARGO para envios con devolucion de cargo
            Dim strCargo As String, strFecha As String
            'hlamas 22-03-2016
            'strCargo = IIf(Me.ChkCargo.Checked, "CARGO", "")
            strCargo = IIf(Me.rbtCargoSi.Checked, "CARGO", "")

            Dim strAgeDom As String
            For Each row As DataRow In objGuiaEnvio.dt_cur_codBarras.Rows
                strAgeDom = ObjCODIGOBARRA.AGEDOM & "  GE"
                ObjCODIGOBARRA.CodigoBarra = row.Item(0)
                prn.EscribeLinea("^XA")
                prn.EscribeLinea("^PW400")
                prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD " & ObjCODIGOBARRA.NroDOC & "          " & row.Item(1).ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & strAgeDom & "^FS")
                'prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD " & Me.TextBox1.Text & "^FS")
                'prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & Me.TextBox2.Text & I & "^FS")
                prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.clinte & "^FS")
                prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & ObjCODIGOBARRA.CodigoBarra & "^FS")
                prn.EscribeLinea("^FT17,141^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
                prn.EscribeLinea("^FT96,142^A0N,39,45^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")
                'hlamas 26-08-2015
                'prn.EscribeLinea("^FT305,188^AAN,18,10^FH\^FDTEPSAC^FS")
                'prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & ObjCODIGOBARRA.Fecha & "^FS")

                strAgenciaDestino = strAgenciaDestino.Trim
                prn.EscribeLinea("^FT21,165^AAN,18,10^FH\^FD" & strAgenciaDestino & "^FS")

                strFecha = ObjCODIGOBARRA.Fecha.Trim & " " & HoraActual.Trim
                prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & strFecha & "^FS")
                prn.EscribeLinea("^FT255,188^AAN,18,10^FH\^FDTEPSA^FS")
                prn.EscribeLinea("^FT330,188^AAN,20,12^FH\^FD" & strCargo & "^FS")

                'hlamas 26-08-2015
                'prn.EscribeLinea("^FT183,188^AAN,18,10^FH\^FD" & HoraActual & "^FS")

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

    Public Function fnImprimirEtiquetasGUIA_III() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()
            Dim strAgenciaDestino As String = dtoVentaCargaContado.AgenciaAbreviado(Me.CboAgenciaDest.SelectedValue)

            'Dim strAgenciaDestino As String = dtoVentaCargaContado.AgenciaAbreviado(ObjVentaCargaContado.v_IDAGENCIAS_DESTINO)
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

            'hlamas 26-08-2015
            'agregar CARGO para envios con devolucion de cargo
            Dim strCargo As String, strFecha As String
            'hlamas 22-03-2015
            'strCargo = IIf(Me.ChkCargo.Checked, "CARGO", "")
            strCargo = IIf(Me.rbtCargoSi.Checked, "CARGO", "")
            Dim strAgeDom As String
            For Each row As DataRow In objGuiaEnvio.dt_cur_codBarras.Rows
                strAgeDom = ObjCODIGOBARRA.AGEDOM & "  GE"
                ObjCODIGOBARRA.CodigoBarra = row.Item(0)
                prn.EscribeLinea("N")
                prn.EscribeLinea("N")
                '
                prn.EscribeLinea("A30,14,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
                prn.EscribeLinea("A30,47,0,4,1,1,N,""" & Mid(ObjCODIGOBARRA.NroDOC, 5, 13) & " -" & row.Item(1).ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
                prn.EscribeLinea("A317,47,0,3,1,1,N,""" & strAgeDom & """")
                prn.EscribeLinea("A30,110,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-  """)

                'hlamas 26-08-2015
                'prn.EscribeLinea("A30,163,0,1,1,1,N,""" & ObjCODIGOBARRA.Fecha & """")
                'prn.EscribeLinea("A321,163,0,1,1,1,N,""TEPSAC""")

                strAgenciaDestino = strAgenciaDestino.Trim
                prn.EscribeLinea("A30,140,0,3,1,1,N,""" & strAgenciaDestino & """")

                strFecha = ObjCODIGOBARRA.Fecha.Trim & " " & HoraActual.Trim
                prn.EscribeLinea("A30,163,0,1,1,1,N,""" & strFecha & """")
                prn.EscribeLinea("A230,163,0,1,1,1,N,""JOTASYS""")
                prn.EscribeLinea("A300,163,0,2,1,1,N,""" & strCargo & """")

                'hlamas 26-08-2015
                'prn.EscribeLinea("A205,163,0,1,1,1,N,""" & HoraActual & """")

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


#End Region



    Private Sub asignar_documentos_clientes()
        With ObjVentaCargaContado
            .v_ID_GUIAS_ENVIO_DOCs = Nothing
            .v_FECHAs = Nothing
            .v_MONTO_TIPO_CAMBIOs = Nothing
            .v_IDTIPO_MONEDAs = Nothing
            .v_IDTIPO_COMPROBANTEs = Nothing
            .v_NRO_SERIEs = Nothing
            .v_NRO_DOCUs = Nothing
            .v_MONTO_IMPUESTOs = Nothing
            .v_TOTAL_COSTOs = Nothing
            .v_PORCENs = Nothing
            .v_OBSs = Nothing
            .v_TIPOs = Nothing
            .v_PROCEDENCIAs = Nothing

            For i As Integer = 0 To 19
                If Not objComprobanteAsegurada(i).NRO_SERIE Is Nothing Then
                    .v_ID_GUIAS_ENVIO_DOCs = .v_ID_GUIAS_ENVIO_DOCs & objComprobanteAsegurada(i).ID_GUIAS_ENVIO_DOC & ";"
                    .v_FECHAs = .v_FECHAs & objComprobanteAsegurada(i).FECHA & ";"
                    .v_MONTO_TIPO_CAMBIOs = .v_MONTO_TIPO_CAMBIOs & objComprobanteAsegurada(i).MONTO_TIPO_CAMBIO & ";"
                    .v_IDTIPO_MONEDAs = .v_IDTIPO_MONEDAs & objComprobanteAsegurada(i).IDTIPO_MONEDA & ";"
                    .v_IDTIPO_COMPROBANTEs = .v_IDTIPO_COMPROBANTEs & objComprobanteAsegurada(i).IDTIPO_COMPROBANTE & ";"
                    .v_NRO_SERIEs = .v_NRO_SERIEs & objComprobanteAsegurada(i).NRO_SERIE & ";"
                    .v_NRO_DOCUs = .v_NRO_DOCUs & objComprobanteAsegurada(i).NRO_DOCU & ";"
                    .v_MONTO_IMPUESTOs = .v_MONTO_IMPUESTOs & objComprobanteAsegurada(i).MONTO_IMPUESTO & ";"
                    .v_TOTAL_COSTOs = .v_TOTAL_COSTOs & objComprobanteAsegurada(i).TOTAL_COSTO & ";"
                    .v_PORCENs = .v_PORCENs & objComprobanteAsegurada(i).PORCEN & ";"
                    .v_OBSs = .v_OBSs & objComprobanteAsegurada(i).OBS & ";"
                    .v_TIPOs = .v_TIPOs & objComprobanteAsegurada(i).TIPO & ";"
                    .v_PROCEDENCIAs = .v_PROCEDENCIAs & objComprobanteAsegurada(i).PROCEDENCIA & ";"
                End If
            Next

            If .v_ID_GUIAS_ENVIO_DOCs Is Nothing Then Exit Sub

            .v_ID_GUIAS_ENVIO_DOCs = Mid(.v_ID_GUIAS_ENVIO_DOCs, 1, Len(.v_ID_GUIAS_ENVIO_DOCs) - 1)
            .v_FECHAs = Mid(.v_FECHAs, 1, Len(.v_FECHAs) - 1)
            .v_MONTO_TIPO_CAMBIOs = Mid(.v_MONTO_TIPO_CAMBIOs, 1, Len(.v_MONTO_TIPO_CAMBIOs) - 1)
            .v_IDTIPO_MONEDAs = Mid(.v_IDTIPO_MONEDAs, 1, Len(.v_IDTIPO_MONEDAs) - 1)
            .v_IDTIPO_COMPROBANTEs = Mid(.v_IDTIPO_COMPROBANTEs, 1, Len(.v_IDTIPO_COMPROBANTEs) - 1)
            .v_NRO_SERIEs = Mid(.v_NRO_SERIEs, 1, Len(.v_NRO_SERIEs) - 1)
            .v_NRO_DOCUs = Mid(.v_NRO_DOCUs, 1, Len(.v_NRO_DOCUs) - 1)
            .v_MONTO_IMPUESTOs = Mid(.v_MONTO_IMPUESTOs, 1, Len(.v_MONTO_IMPUESTOs) - 1)
            .v_TOTAL_COSTOs = Mid(.v_TOTAL_COSTOs, 1, Len(.v_TOTAL_COSTOs) - 1)
            .v_PORCENs = Mid(.v_PORCENs, 1, Len(.v_PORCENs) - 1)
            .v_OBSs = Mid(.v_OBSs, 1, Len(.v_OBSs) - 1)
            .v_TIPOs = Mid(.v_TIPOs, 1, Len(.v_TIPOs) - 1)
            .v_PROCEDENCIAs = Mid(.v_PROCEDENCIAs, 1, Len(.v_PROCEDENCIAs) - 1)
        End With
    End Sub

    Private Sub limpiar_documentos_cliente()
        For i As Integer = 0 To 19
            objComprobanteAsegurada(i).FECHA = Nothing
            objComprobanteAsegurada(i).FECHA_ACTUALIZACION = Nothing
            objComprobanteAsegurada(i).FECHA_REGISTRO = Nothing
            objComprobanteAsegurada(i).ID_GUIAS_ENVIO_DOC = Nothing
            objComprobanteAsegurada(i).IDESTADO_REGISTRO = Nothing
            objComprobanteAsegurada(i).IDGUIAS_ENVIO = Nothing
            objComprobanteAsegurada(i).IDROL_USUARIO = Nothing
            objComprobanteAsegurada(i).IDROL_USUARIOMOD = Nothing
            objComprobanteAsegurada(i).IDTIPO_COMPROBANTE = Nothing
            objComprobanteAsegurada(i).IDTIPO_MONEDA = Nothing
            objComprobanteAsegurada(i).IDUSUARIO_PERSONAL = Nothing
            objComprobanteAsegurada(i).IDUSUARIO_PERSONALMOD = Nothing
            objComprobanteAsegurada(i).IP = Nothing
            objComprobanteAsegurada(i).IPMOD = Nothing
            objComprobanteAsegurada(i).MONTO_BASE = Nothing
            objComprobanteAsegurada(i).MONTO_IMPUESTO = Nothing
            objComprobanteAsegurada(i).MONTO_SUB_TOTAL = Nothing
            objComprobanteAsegurada(i).MONTO_TIPO_CAMBIO = Nothing
            objComprobanteAsegurada(i).NRO_DOCU = Nothing
            objComprobanteAsegurada(i).NRO_SERIE = Nothing
            objComprobanteAsegurada(i).OBS = Nothing
            objComprobanteAsegurada(i).PORCEN = Nothing
            objComprobanteAsegurada(i).PORCEN_IMPUESTO = Nothing
            objComprobanteAsegurada(i).TOTAL_COSTO = Nothing
            objComprobanteAsegurada(i).PROCEDENCIA = Nothing
        Next
        es_carga_asegurada = False
        recuperando_datos_contado = False
        'Label5.Visible = False
    End Sub 'func 1   
    Dim fnCONTROLDATOS As Boolean = False
    Dim strNroGuias_Remision As String = ""
    Dim v_Origen, v_destino As String
    Dim CORRELATIVO As String = "0"
    Dim ObjRptGuiaEnvio As New dtoRptGuiaEnvio()
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

#End Region
    '******************************
#Region "DETALLE VENTA"

    '==================CALCULOS[BULTO, ARTICULOS, M3(VOLUMETRICO)]=========================
    Dim iCOL As Integer = 0, iROW As Integer = 0
    Dim VBase As Boolean
    Private Sub GrdDetalleVenta_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDetalleVenta.CellEndEdit
        Try
            iROW = e.RowIndex
            iCOL = e.ColumnIndex

            'hlamas 03-08-2015
            If Me.CboProducto.SelectedValue = 0 And Me.ChkArticulos.Checked = False Then
                If e.RowIndex = 2 Then
                    If Conversion.Val(GrdDetalleVenta(BCol_, BRow_).Value) > 0 Then
                        GrdDetalleVenta(BCol_, BRow_).Value = 0
                    End If
                End If
            End If

            'valida si se ingresa peso o volumen sin tarifa
            If Me.CboTipo.SelectedValue = 1 And Me.ChkArticulos.Checked = False Then
                If e.RowIndex = 0 Or e.RowIndex = 1 Then
                    If Conversion.Val(GrdDetalleVenta(3, BRow_).Value) = 0 Then
                        If Conversion.Val(GrdDetalleVenta(BCol_, BRow_).Value) > 0 Then
                            GrdDetalleVenta(BCol_, BRow_).Value = 0
                        End If
                    End If
                End If
            End If

            Me.TipoCampos()
            If TxtCiudadDestino.Text = "" Then idUnidadAgencias = -1

            '*******************************************************************************
            If ChkM3.Checked = False And ChkArticulos.Checked = False Then
                If idUnidadAgencias <> -1 Then
                    If CboTipo.SelectedValue = 1 Then
                        fnTotalPago() '------------------------> Calculo[GRID BULTOS]PCE
                    Else
                        Total_Pagar(iROW, iCOL) '--------------> Calculo[GRID BULTOS]CREDITO
                        If Val(Me.TxtDescuento.Text) <> 0 Then
                            TxtDescuento_TextChanged(sender, e)
                        End If
                    End If
                End If
                '---
                Me.FormatoMiles()
            End If

            '*******************************************************************************
            If ChkArticulos.Enabled = True And ChkArticulos.Checked = True Then
                If idUnidadAgencias <> -1 Then
                    If CboTipo.SelectedValue = 1 Then
                        Me.CalculoArticulos() '---------------> Calculo[GRID ARTICULOS] PCE 
                    Else
                        Me.calculoGrdArticulos() '------------> Calculo[GRID ARTICULOS] CREDITO
                    End If
                End If
                '---
                Me.FormatoMiles()
            End If

            '*******************************************************************************
            If ChkM3.Checked = True Then '
                If idUnidadAgencias <> -1 Then
                    bInicio = False
                    Me.Calculo_M3() '--------------------------> Calculo M3 (VOLUMETRICO)
                End If
                '---
                Me.FormatoMiles()
            End If

            'hlamas 11-09-2015
            If CboTipo.SelectedValue = 1 Then
                If Val(TxtDescuento.Text) > 0 Or Val(TxtDescuento.Text) < 0 Then
                    TxtDescuento_TextChanged(Nothing, Nothing)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '********CALCULO BULTOS PCE*****************************
    Dim SubTotal_Costo As Double = 0
    Public Function fnTotalPago() As Boolean
        Dim flag As Boolean = False
        Try
            If ChkM3.Checked = True Then
                Me.Calculo_M3()
                Return flag
            End If
            '**********Tomando los valores del campo [Peso/Volumen: Peso] y [Peso/Volumen: Volumen] y [Bulto: Sobre]********
            'Si se ingreso un descuento
            Dim PorcentajeDesc As Double = 0 'Val(TxtDescuento.Text.ToString) / 100

            Dim ValPeso_Peso As Double = 0, valPeso_Volum As Double = 0, ValNroSobres As Double = 0
            '*********************Formateando las Comas***********************************************
            If Val(GrdDetalleVenta("Peso/Volumen", 0).Value) = 0 Then
                If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX Then
                    GrdDetalleVenta("Peso/Volumen", 0).Value = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 5
                    ValPeso_Peso = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 5
                ElseIf CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX_10 Then
                    GrdDetalleVenta("Peso/Volumen", 0).Value = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 10
                    ValPeso_Peso = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 10
                Else
                    ValPeso_Peso = 0
                End If
            Else
                If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX Then
                    GrdDetalleVenta("Peso/Volumen", 0).Value = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 5
                    ValPeso_Peso = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 5
                ElseIf CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX_10 Then
                    GrdDetalleVenta("Peso/Volumen", 0).Value = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 10
                    ValPeso_Peso = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 10
                Else
                    ValPeso_Peso = GrdDetalleVenta("Peso/Volumen", 0).Value
                End If
            End If
            'hlamas 11-09-2015
            ValPeso_Peso = RedondearMas(ValPeso_Peso)
            GrdDetalleVenta("Peso/Volumen", 0).Value = ValPeso_Peso

            If CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX And CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX_10 Then
                If Val(GrdDetalleVenta("Peso/Volumen", 1).Value) = 0 Then
                    If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX Then
                        GrdDetalleVenta("Peso/Volumen", 1).Value = Conversion.Val(GrdDetalleVenta("Bulto", 1).Value) * 10
                        valPeso_Volum = Conversion.Val(GrdDetalleVenta("Bulto", 1).Value) * 10
                    Else
                        valPeso_Volum = 0
                    End If
                Else
                    If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX Then
                        GrdDetalleVenta("Peso/Volumen", 1).Value = Conversion.Val(GrdDetalleVenta("Bulto", 1).Value) * 10
                        valPeso_Volum = Conversion.Val(GrdDetalleVenta("Bulto", 1).Value) * 10
                    Else
                        valPeso_Volum = GrdDetalleVenta("Peso/Volumen", 1).Value
                    End If
                End If
            End If


            'hlamas 11-09-2015
            valPeso_Volum = RedondearMas(valPeso_Volum)
            If CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX And CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX_10 Then
                GrdDetalleVenta("Peso/Volumen", 1).Value = valPeso_Volum
            End If

            If CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX And CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX_10 Then
                If Val(GrdDetalleVenta("Bulto", 2).Value) = 0 Then ValNroSobres = 0 Else ValNroSobres = GrdDetalleVenta("Bulto", 2).Value
            End If
            '*****************************************************************************************
            Dim IGV As Double = dtoUSUARIOS.iIGV / 100

            '*************************************************************************
            '***********CALCULO [SUB_NETO]= [PESO/VOLUMEN] * [COSTO]****************
            If objGuiaEnvio.CondicionTarifa_ And objGuiaEnvio.UnidadPeso_ = "PESO" Then '----> Si tiene CONDICION TARIFA(Calculo Peso)               
                Me.fnCalcularCondicionTarifa(0, ValPeso_Peso, GrdDetalleVenta("Costo", 0).Value) '-----------------> [Sub Neto (Peso)]
            Else
                If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX And Val(GrdDetalleVenta("Bulto", 0).Value) <> 0 Then
                    'GrdDetalleVenta("Sub Neto", 0).Value = IIf(GrdDetalleVenta("Bulto", 0).Value * tarifa_Peso = 0, "0.00", FormatNumber(Format((GrdDetalleVenta("Bulto", 0).Value * tarifa_Peso), "###,###,###.00"), 2)) '-------> [Sub Neto (Peso)] 
                    GrdDetalleVenta("Sub Neto", 0).Value = IIf(GrdDetalleVenta("Bulto", 0).Value * Monto_25 = 0, "0.00", FormatNumber(Format((GrdDetalleVenta("Bulto", 0).Value * Monto_25), "###,###,###.00"), 2)) '-------> [Sub Neto (Peso)] 
                ElseIf CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX_10 And Val(GrdDetalleVenta("Bulto", 0).Value) <> 0 Then
                    'GrdDetalleVenta("Sub Neto", 0).Value = IIf(GrdDetalleVenta("Bulto", 0).Value * tarifa_Peso = 0, "0.00", FormatNumber(Format((GrdDetalleVenta("Bulto", 0).Value * tarifa_Peso), "###,###,###.00"), 2)) '-------> [Sub Neto (Peso)] 
                    GrdDetalleVenta("Sub Neto", 0).Value = IIf(GrdDetalleVenta("Bulto", 0).Value * Monto_40 = 0, "0.00", FormatNumber(Format((GrdDetalleVenta("Bulto", 0).Value * Monto_40), "###,###,###.00"), 2)) '-------> [Sub Neto (Peso)] 
                Else
                    GrdDetalleVenta("Sub Neto", 0).Value = IIf(ValPeso_Peso * tarifa_Peso = 0, "0.00", _
                                         FormatNumber(Format((ValPeso_Peso * tarifa_Peso), "###,###,###.00"), 2)) '-------> [Sub Neto (Peso)] 
                End If
            End If
            '---
            If CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX And CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX_10 Then
                If objGuiaEnvio.CondicionTarifa_ And objGuiaEnvio.UnidadVol_ = "VOL" Then '----> Si tiene CONDICION TARIFA(Calculo volumen)   
                    Me.fnCalcularCondicionTarifa(1, valPeso_Volum, GrdDetalleVenta("Costo", 1).Value) '-----------------> [Sub Neto (Volumen)]
                Else
                    If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX And GrdDetalleVenta("Bulto", 1).Value <> "" Then
                        'GrdDetalleVenta("Sub Neto", 1).Value = IIf(GrdDetalleVenta("Bulto", 1).Value * tarifa_Volumen = 0, "0.00", FormatNumber(Format((GrdDetalleVenta("Bulto", 1).Value * tarifa_Volumen), "###,###,###.00"), 2)) '-> [Sub Neto (Volumen)]
                        GrdDetalleVenta("Sub Neto", 1).Value = IIf(GrdDetalleVenta("Bulto", 1).Value * Monto_40 = 0, "0.00", FormatNumber(Format((GrdDetalleVenta("Bulto", 1).Value * Monto_40), "###,###,###.00"), 2)) '-> [Sub Neto (Volumen)]
                    Else
                        GrdDetalleVenta("Sub Neto", 1).Value = IIf(valPeso_Volum * tarifa_Volumen = 0, "0.00", _
                                                            FormatNumber(Format((valPeso_Volum * tarifa_Volumen), "###,###,###.00"), 2)) '-> [Sub Neto (Volumen)]
                        'SubTotal_Costo = IIf(Val(GrdDetalleVenta("Sub Neto", 1).Value) = 0, 0, CDbl(GrdDetalleVenta("Sub Neto", 1).Value))
                    End If
                End If
            End If

            'Dim Monto As Double = 0.0
            If CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX And CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX_10 Then
                GrdDetalleVenta("Sub Neto", 2).Value = IIf(tarifa_Sobre * ValNroSobres = 0, "0.00", _
                                     FormatNumber(Format((tarifa_Sobre * ValNroSobres), "###,###,###.00"), 2))  '----> [Sub Neto (Sobre)]  
            Else
                SubTotal_Costo = 0.0
            End If

            '*************************************************************************

            If Monto_Base > 0 Then
                ObjVentaCargaContado.v_MONTO_BASE = Monto_Base
            End If

            '**************************************************************************           
            If objGuiaEnvio.CondicionTarifa_ = False Then
                If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX Then
                    If Val(GrdDetalleVenta("Bulto", 0).Value) <> 0 Then
                        SubTotal_Costo = Monto_Base + ((GrdDetalleVenta("Bulto", 0).Value * Monto_25) / (1 + IGV))
                    End If
                    SubTotal_Costo = SubTotal_Costo + (tarifa_Sobre * ValNroSobres)
                ElseIf CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX_10 Then
                    If Val(GrdDetalleVenta("Bulto", 0).Value) <> 0 Then
                        SubTotal_Costo = Monto_Base + ((GrdDetalleVenta("Bulto", 0).Value * Monto_40) / (1 + IGV))
                    End If
                Else
                    If ValPeso_Peso * tarifa_Peso + valPeso_Volum * tarifa_Volumen > 0 Then
                        If iControlMonto_Base = 1 Then
                            SubTotal_Costo = (Monto_Base + ValPeso_Peso * tarifa_Peso + valPeso_Volum * tarifa_Volumen + tarifa_Sobre * ValNroSobres)
                        Else
                            SubTotal_Costo = (ValPeso_Peso * tarifa_Peso + valPeso_Volum * tarifa_Volumen + tarifa_Sobre * ValNroSobres)
                        End If
                    Else
                        SubTotal_Costo = (ValPeso_Peso * tarifa_Peso + valPeso_Volum * tarifa_Volumen + tarifa_Sobre * ValNroSobres)
                    End If
                End If
            Else
                If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX Then '-->Tepsa box
                    If Val(GrdDetalleVenta("Bulto", 0).Value) <> 0 Then
                        SubTotal_Costo = Monto_Base + ((GrdDetalleVenta("Bulto", 0).Value * Monto_25) / (1 + IGV))
                    End If
                    SubTotal_Costo = SubTotal_Costo + (tarifa_Sobre * ValNroSobres)
                ElseIf CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX_10 Then '-->Tepsa box
                    If Val(GrdDetalleVenta("Bulto", 0).Value) <> 0 Then
                        SubTotal_Costo = Monto_Base + ((GrdDetalleVenta("Bulto", 0).Value * Monto_40) / (1 + IGV))
                    End If
                Else
                    SubTotal_Costo += tarifa_Sobre * ValNroSobres
                    If Monto_Base > 0 Then
                        SubTotal_Costo = (Monto_Base + SubTotal_Costo)
                    End If
                End If
            End If

            '**************************************************************************
            TxtSubTotal.Text = SubTotal_Costo
            TxtImpuesto.Text = IGV * SubTotal_Costo
            TxtTotal.Text = SubTotal_Costo + IGV * SubTotal_Costo

            If CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX And CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX_10 Then
                If bTarifarioGeneral And bContado Then
                    TxtSubTotal.Text = Format(SubTotal_Costo / (1 + IGV), "###,###,###.0000")
                    TxtImpuesto.Text = IGV * SubTotal_Costo
                    TxtTotal.Text = SubTotal_Costo
                End If
            End If

            precio_carga_asegurada()
            SubTotal_Costo = TxtSubTotal.Text

            '********************************ENTREGA A DOMICILIO***********************************************
            dblMontoEntregaDomicilio = GestionaMontoTarifaDomicilio(dtTarifaServicio, GrdDetalleVenta)
            SubTotal_Costo = SubTotal_Costo + dblMontoEntregaDomicilio / (1 + IGV)
            '***************************************************************************************************

            '********************************DEVOLUCION DE CARGO************************************************
            dblMontoDC = ObtieneMontoDevolucionCargo()
            SubTotal_Costo = SubTotal_Costo + dblMontoDC / (1 + IGV)
            '********************************DEVOLUCION DE CARGO************************************************

            Dim SUB_TOTAL_GENERAL As Double = 0
            '*******************************[PAGO CON DESCUENTO]***********************************************
            If CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX And CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX_10 Then
                If (1 - Val(Me.TxtDescuento.Text) / 100) > 0 Then
                    'hlamas 11-09-2015
                    'SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SubTotal_Costo * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
                    SUB_TOTAL_GENERAL = Format((1 + IGV) * SubTotal_Costo * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000")
                Else
                    If (1 - Val(Me.TxtDescuento.Text) / 100) = 0 Then
                        SUB_TOTAL_GENERAL = 0
                    End If
                End If
            Else
                SUB_TOTAL_GENERAL = SubTotal_Costo + IGV * SubTotal_Costo
            End If
            '**************************************************************************************************

            '********************************ENTREGA A DOMICILIO***********************************************
            'dblMontoEntregaDomicilio = GestionaMontoTarifaDomicilio()
            'SUB_TOTAL_GENERAL = SUB_TOTAL_GENERAL + dblMontoEntregaDomicilio
            '***************************************************************************************************

            'Agregado 04022012
            If CboTipo.SelectedValue = 1 Then
                If CboProducto.SelectedValue = 7 And (SUB_TOTAL_GENERAL / IIf(Val(PorcentajeDesc) = 0, 1, PorcentajeDesc) < MontoMinimoPyme) Then
                    Me.CondicionMontoMinimoPYME()
                ElseIf (SUB_TOTAL_GENERAL / IIf(Val(PorcentajeDesc) = 0, 1, PorcentajeDesc) < monto_minimo_PCE) And CboProducto.SelectedValue <> 7 Then
                    TxtDescuento.Enabled = False
                    Me.CondicionMontoMinimoPCE()
                Else
                    TxtDescuento.Enabled = True

                    'hlamas 12-02-2014
                    If TipoGrid_ = FormatoGrid.BULTO Then
                        Dim intDescuentoPromocion = CalculaPromocion()
                        If intDescuentoPromocion > 0 And intDescuentoPromocion < 100 Then
                            'hlamas 11-09-2015
                            'SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SubTotal_Costo * (1 - Val(intDescuentoPromocion) / 100), "###,###,###.000"))
                            SUB_TOTAL_GENERAL = Format((1 + IGV) * SubTotal_Costo * (1 - Val(intDescuentoPromocion) / 100), "###,###,###.000")
                        End If
                    End If
                    Me.TxtSubTotal.Text = IIf(SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
                    Me.TxtImpuesto.Text = IIf(IGV * SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
                    Me.TxtTotal.Text = IIf(SUB_TOTAL_GENERAL = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL, "###,###,###.00"), 2))
                End If
                If SUB_TOTAL_GENERAL > 0 Then
                    Dim dblSubtotal As Double, dblImpuesto As Double, dblTotal As Double
                    dblSubtotal = Me.TxtSubTotal.Text
                    dblImpuesto = Me.TxtImpuesto.Text
                    dblTotal = Me.TxtTotal.Text
                    If dblSubtotal + dblImpuesto <> dblTotal Then
                        TxtSubTotal.Text = FormatNumber(Format(dblTotal / (1 + IGV), "###,###,###.00"), 2)
                        TxtImpuesto.Text = FormatNumber(Format(IGV * dblTotal / (1 + IGV), "###,###,###.00"), 2)
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return False
        End Try
        Return flag
    End Function

    Private Sub precio_carga_asegurada()
        If es_carga_asegurada = True Then
            Dim cdblsub_total As Double = 0
            Dim cdblmonto_IGV As Double = 0
            Dim cdblcosto_total As Double = 0

            For i As Integer = 0 To 19
                If Not objComprobanteAsegurada(i).NRO_SERIE Is Nothing Then
                    If objComprobanteAsegurada(i).TIPO = 1 Or objComprobanteAsegurada(i).TIPO = 0 Then
                        cdblsub_total = cdblsub_total + objComprobanteAsegurada(i).MONTO_SUB_TOTAL * objComprobanteAsegurada(i).MONTO_TIPO_CAMBIO * objComprobanteAsegurada(i).PORCEN / 100
                        cdblmonto_IGV = cdblmonto_IGV + objComprobanteAsegurada(i).MONTO_IMPUESTO * objComprobanteAsegurada(i).MONTO_TIPO_CAMBIO * objComprobanteAsegurada(i).PORCEN / 100
                        cdblcosto_total = cdblcosto_total + objComprobanteAsegurada(i).TOTAL_COSTO * objComprobanteAsegurada(i).MONTO_TIPO_CAMBIO * objComprobanteAsegurada(i).PORCEN / 100
                    Else
                        cdblsub_total = cdblsub_total + objComprobanteAsegurada(i).PORCEN / (1 + objComprobanteAsegurada(i).PORCEN_IMPUESTO / 100)
                        Dim iSub As Double = objComprobanteAsegurada(i).PORCEN / (1 + objComprobanteAsegurada(i).PORCEN_IMPUESTO / 100)
                        cdblmonto_IGV = cdblmonto_IGV + (iSub * (objComprobanteAsegurada(i).PORCEN_IMPUESTO / 100))
                        cdblcosto_total = cdblcosto_total + (objComprobanteAsegurada(i).PORCEN)
                    End If
                End If
            Next
            'pendiente

            TxtSubTotal.Text = Replace(TxtSubTotal.Text, ",", "")
            TxtImpuesto.Text = Replace(TxtImpuesto.Text, ",", "")
            TxtTotal.Text = Replace(TxtTotal.Text, ",", "")
            TxtSubTotal.Text = Val(TxtSubTotal.Text) + cdblsub_total
            TxtImpuesto.Text = Val(TxtImpuesto.Text) + cdblmonto_IGV
            TxtTotal.Text = Val(TxtTotal.Text) + cdblcosto_total
        End If
    End Sub

    '********CALCULO BULTOS CREDITO*************************
    Dim fArticulo As Boolean = False
    Dim Monto_Base As Double = 0
    Dim lb_datos_editados As Boolean = False
    Private Function Total_Pagar(ByVal iROW As Integer, ByVal iCOL As Integer) As Boolean
        Try

            Dim ValPeso_Peso As Double = 0, valPeso_Volum As Double = 0, ValNroSobres As Double = 0, Base As Double = 0
            '*********************Formateando las Comas***********************************************
            If Val(GrdDetalleVenta("Peso/Volumen", 0).Value) = 0 Then ValPeso_Peso = 0 Else ValPeso_Peso = GrdDetalleVenta("Peso/Volumen", 0).Value
            'hlamas 11-09-2015
            ValPeso_Peso = RedondearMas(ValPeso_Peso)
            GrdDetalleVenta("Peso/Volumen", 0).Value = ValPeso_Peso

            If Val(GrdDetalleVenta("Peso/Volumen", 1).Value) = 0 Then valPeso_Volum = 0 Else valPeso_Volum = GrdDetalleVenta("Peso/Volumen", 1).Value
            'hlamas 11-09-2015
            valPeso_Volum = RedondearMas(valPeso_Volum)
            GrdDetalleVenta("Peso/Volumen", 1).Value = valPeso_Volum

            If Val(GrdDetalleVenta("Bulto", 2).Value) = 0 Then ValNroSobres = 0 Else ValNroSobres = GrdDetalleVenta("Bulto", 2).Value
            If Val(GrdDetalleVenta("Sub Neto", 3).Value) = 0 Then Base = 0 Else Base = GrdDetalleVenta("Sub Neto", 3).Value
            '*****************************************************************************************
            'hlamas 26-08/2014 redondeo peso para eckerd
            If iID_Persona = ID_PERSONA_ECKERD Then
                If ValPeso_Peso > 0 And ValPeso_Peso < 1 Then
                    ValPeso_Peso = 1
                    GrdDetalleVenta("Peso/Volumen", 0).Value = ValPeso_Peso
                End If
                If valPeso_Volum > 0 And valPeso_Volum < 1 Then
                    valPeso_Volum = 1
                    GrdDetalleVenta("Peso/Volumen", 1).Value = valPeso_Volum
                End If
            End If

            '***********CALCULO [SUB_NETO]= [PESO/VOLUMEN] * [COSTO]****************** 
            Dim subNeto As Double = 0.0
            Dim colPeso As Integer = 0
            Dim colVol As Integer = 1
            Dim pesoMinimo As Double = objGuiaEnvio.iPeso_Maximo
            Dim fleteMinimo As Double = objGuiaEnvio.iPrecio_cond_Peso
            Dim subNetoPeso As Double = GrdDetalleVenta("Sub Neto", colPeso).Value
            Dim subNetoVolumen As Double = GrdDetalleVenta("Sub Neto", colVol).Value

            If objGuiaEnvio.CondicionTarifa_ Then '-----------------> === CONDICION TARIFA  
                If (CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_COURIER) Then
                    If (iROW = colPeso) Then
                        If (ValPeso_Peso <= pesoMinimo) Then
                            Me.fnCalcularCondicionTarifa(iROW, ValPeso_Peso, GrdDetalleVenta("Costo", colPeso).Value)
                            If (ValPeso_Peso = 0) Then '-->Aplica la refla del flete minomo al volumen
                                Me.fnCalcularCondicionTarifa(colVol, valPeso_Volum, GrdDetalleVenta("Costo", colVol).Value)
                                'ElseIf (valPeso_Volum < pesoMinimo) Then '-->No aplica la regla fete mimimo al volumne
                                'subNetoPeso = valPeso_Volum * tarifa_Volumen
                                'GrdDetalleVenta("Sub Neto", colVol).Value = subNetoPeso
                                'End If
                            Else 'hlamas 09-05-2015
                                If (valPeso_Volum < pesoMinimo) Then
                                    subNetoPeso = valPeso_Volum * tarifa_Volumen
                                    GrdDetalleVenta("Sub Neto", colVol).Value = subNetoPeso
                                Else
                                    subNetoPeso = valPeso_Volum * tarifa_Volumen
                                    GrdDetalleVenta("Sub Neto", colVol).Value = subNetoPeso
                                End If
                            End If
                        ElseIf (ValPeso_Peso > pesoMinimo) Then
                            Me.fnCalcularCondicionTarifa(iROW, ValPeso_Peso, GrdDetalleVenta("Costo", colPeso).Value)
                            If (valPeso_Volum < pesoMinimo) Then
                                subNetoPeso = valPeso_Volum * tarifa_Volumen
                                GrdDetalleVenta("Sub Neto", colVol).Value = subNetoPeso
                            Else 'hlamas 09-05-2015
                                subNetoPeso = valPeso_Volum * tarifa_Volumen
                                GrdDetalleVenta("Sub Neto", colVol).Value = subNetoPeso
                            End If
                        ElseIf (valPeso_Volum <= pesoMinimo) Then
                            Me.fnCalcularCondicionTarifa(iROW, ValPeso_Peso, GrdDetalleVenta("Costo", colVol).Value)
                        ElseIf (valPeso_Volum > pesoMinimo) Then
                            subNetoPeso = valPeso_Volum * tarifa_Volumen
                            GrdDetalleVenta("Sub Neto", colVol).Value = subNetoPeso
                        End If
                    ElseIf (iROW = colVol) Then
                        If (ValPeso_Peso = 0) Then
                            Me.fnCalcularCondicionTarifa(iROW, valPeso_Volum, GrdDetalleVenta("Costo", colVol).Value)

                        ElseIf (ValPeso_Peso <= pesoMinimo) Then
                            Me.fnCalcularCondicionTarifa(iROW, valPeso_Volum, GrdDetalleVenta("Costo", colVol).Value)

                            subNetoPeso = valPeso_Volum * tarifa_Volumen
                            GrdDetalleVenta("Sub Neto", colVol).Value = subNetoPeso
                        ElseIf (ValPeso_Peso > pesoMinimo) Then
                            subNetoPeso = valPeso_Volum * tarifa_Volumen
                            GrdDetalleVenta("Sub Neto", colVol).Value = subNetoPeso
                        ElseIf (valPeso_Volum <= pesoMinimo) Then
                            Me.fnCalcularCondicionTarifa(iROW, valPeso_Volum, GrdDetalleVenta("Costo", colVol).Value)
                        ElseIf (valPeso_Volum > pesoMinimo) Then
                            subNetoPeso = valPeso_Volum * tarifa_Volumen
                            GrdDetalleVenta("Sub Neto", colVol).Value = subNetoPeso
                        End If
                    End If
                Else
                    Me.fnCalcularCondicionTarifa(iROW, ValPeso_Peso, GrdDetalleVenta("Costo", colPeso).Value)
                    Me.fnCalcularCondicionTarifa(iROW, valPeso_Volum, GrdDetalleVenta("Costo", colVol).Value)
                End If

            Else
                GrdDetalleVenta("Sub Neto", 0).Value = IIf(ValPeso_Peso * tarifa_Peso = 0, "0.00", _
                                     FormatNumber(Format((ValPeso_Peso * tarifa_Peso), "###,###,###.00"), 2)) '-------> [Sub Neto (Peso)] 

                GrdDetalleVenta("Sub Neto", 1).Value = IIf(valPeso_Volum * tarifa_Volumen = 0, "0.00", _
                                   FormatNumber(Format((valPeso_Volum * tarifa_Volumen), "###,###,###.00"), 2)) '---> [Sub Neto (Volumen)]

            End If


            GrdDetalleVenta("Sub Neto", 2).Value = IIf(tarifa_Sobre * ValNroSobres = 0, "0.00", _
                                     FormatNumber(Format((tarifa_Sobre * ValNroSobres), "###,###,###.00"), 2))  '-----> [Sub Neto (Sobre)]    
            '*************************************************************************
            Dim Sum_SubTotal As Double = 0
            'hlamas 17-12-2013
            If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_COURIER Then
                For i As Integer = 0 To GrdDetalleVenta.Rows.Count() - 2
                    Dim val As Double = IIf(GrdDetalleVenta("Sub Neto", i).Value = 0, 0, GrdDetalleVenta("Sub Neto", i).Value)
                    Sum_SubTotal += val
                Next
            Else
                Sum_SubTotal += ((ValPeso_Peso * tarifa_Peso) + (valPeso_Volum * tarifa_Volumen) + (tarifa_Sobre * ValNroSobres))
            End If

            If CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_COURIER Then '-->Tepsa Courier
                '-->No incluye IGV
                If Sum_SubTotal > 0 AndAlso Monto_Base > 0 Then
                    If ValPeso_Peso * tarifa_Peso + valPeso_Volum * tarifa_Volumen > 0 Then
                        Sum_SubTotal += Base
                    End If
                End If
                Sum_SubTotal = Sum_SubTotal / (1 + IGV)
            Else
                If Sum_SubTotal > 0 AndAlso Monto_Base > 0 Then
                    If ValPeso_Peso * tarifa_Peso + valPeso_Volum * tarifa_Volumen > 0 Then
                        Sum_SubTotal += Base
                    End If
                End If
            End If

            'Me.TxtDescuento.Enabled = True
            'If Val(Me.TxtDescuento.Text) > 0 Then
            '    Sum_SubTotal = Format((1) * Sum_SubTotal * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000")
            'End If


            '****************CALCULO**************************
            TxtSubTotal.Text = IIf(Sum_SubTotal = 0, "0.00", Format(Sum_SubTotal, "####,###,###.00"))
            TxtImpuesto.Text = IIf((IGV * Sum_SubTotal) = 0, "0.00", Format((IGV) * (Sum_SubTotal), "####,###,###.00"))
            TxtTotal.Text = IIf((1 + IGV) * (Sum_SubTotal) = 0, "0.00", Format((1 + IGV) * (Sum_SubTotal), "####,###,###.00"))
            '*************************************************

            'hlamas 17-12-2013 se corrige redondeo de ventas credito
            If CboProducto.SelectedValue = ID_PRODUCTO_CARGA_EXPRESA Then
                Dim dblTotal As Double = Me.TxtTotal.Text
                If dblTotal > 0 Then
                    Dim dblSubtotal As Double = dblTotal / (1 + IGV)
                    TxtSubTotal.Text = Format(dblSubtotal, "####,###,###.00")
                    TxtImpuesto.Text = Format(dblSubtotal * IGV, "####,###,###.00")
                End If
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return False
        End Try
        Return False
    End Function

    '********ARTICULOS**************************************
    Private Sub ChkArticulos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkArticulos.CheckedChanged
        Try
            Me.Cursor = Cursors.AppStarting
            If Not ChkArticulos.Checked Then
                TipoGrid_ = FormatoGrid.BULTO : LbldetalleVenta.Text = "Detalle Venta" : Me.DiseñaGrdDetalleVenta()
                FormatoGrdDetalleVenta()
                Me.tarifarioEnMemoria()

                TxtSubTotal.Text = "0.00"
                TxtImpuesto.Text = "0.00"
                TxtTotal.Text = "0.00"

                '****************************
                ChkSobres.Visible = False
                txtCantidadSobres.Visible = False
                txtTotalSobre.Visible = False
                LblMontoBase.Visible = False
                TxtMontoBase.Visible = False
                RemoveHandler txtCantidadSobres.TextChanged, AddressOf txtCantSobres_TextChanged
                RemoveHandler ChkSobres.CheckedChanged, AddressOf ChkSobre_CheckedChanged
                txtCantidadSobres.Text = ""
                txtTotalSobre.Text = "0.00"
                ChkSobres.Checked = False
                Me.CondicionMontoMinimoPCE()
                Me.Cursor = Cursors.Default
                AddHandler txtCantidadSobres.TextChanged, AddressOf txtCantSobres_TextChanged
                AddHandler ChkSobres.CheckedChanged, AddressOf ChkSobre_CheckedChanged
                Return
            End If

            TxtDescuento.Enabled = False
            If ChkM3.Checked = True Then ChkM3.Checked = False
            TipoGrid_ = FormatoGrid.ARTICULOS : LbldetalleVenta.Text = "Articulos"
            Me.DiseñaGrdDetalleVenta()

            If CboTipo.SelectedValue = 1 Then
                If DtArticulos.Rows.Count > 0 Then 'ObjVentaCargaContado.dt_cur_Articulos.Rows.Count > 0 Then
                    ChkSobres.Checked = False
                    fArticulo = True
                    '*********cargando lo datos de articulos**********
                    For Each fila As DataRow In DtArticulos.Rows
                        Dim row0 As String() = {fila.Item(1), FormatNumber(fila.Item(2).ToString, 2), "", "0.00", "0.00", fila.Item(0).ToString()}
                        GrdDetalleVenta.Rows().Add(row0)
                    Next

                    'For Each fila As DataRow In ObjVentaCargaContado.dt_cur_Articulos.Rows
                    'Dim row0 As String() = {fila.Item(1), FormatNumber(fila.Item(2).ToString, 2), "", "0.00", "0.00", fila.Item(0).ToString()}
                    'GrdDetalleVenta.Rows().Add(row0)
                    'Next
                End If
            ElseIf CboTipo.SelectedValue = 2 Then
                If DtArticulos.Rows.Count > 0 Then
                    For Each fila As DataRow In DtArticulos.Rows
                        Dim row0 As String() = {fila.Item(1).ToString, fila.Item(2).ToString, "", "0.00", "0.00", "0.00", fila.Item(0).ToString()}
                        GrdDetalleVenta.Rows().Add(row0)
                        If fila.Item(0).ToString() = 211 Then
                            GrdDetalleVenta.Columns.Item("M3").Visible = True
                        End If
                    Next
                End If
            End If

            TxtSubTotal.Text = "0.00"
            TxtImpuesto.Text = "0.00"
            TxtTotal.Text = "0.00"

            Update()
            'TxtMontoBase.Text = FormatNumber(IIf(Val(Monto_Base) = 0, 0, Monto_Base), 2)
            '18/11/2011
            If iBaseArticulo = 1 Then
                TxtMontoBase.Text = FormatNumber(IIf(Val(Monto_Base) = 0, 0, Monto_Base), 2)
            Else
                TxtMontoBase.Text = "0.00"
            End If
            ChkSobres.Visible = True
            ChkSobres.Enabled = True

            txtCantidadSobres.Visible = True : txtCantidadSobres.Enabled = False
            txtTotalSobre.Visible = True : txtTotalSobre.ReadOnly = True
            LblMontoBase.Visible = True
            TxtMontoBase.Visible = True : TxtMontoBase.ReadOnly = True
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '********CALCULO ARTICULOS (PCE)************************
    Sub CalculoArticulos()
        Try
            If iCOL = 2 Or iCOL = 3 Then '2 = Columna cantidad 3 peso
                Dim IGV As Double = dtoUSUARIOS.iIGV / 100
                Dim SubTotal_Costo As Double = 0

                objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = 0
                Dim Total As Double = 0
                Dim ii1 As Integer = 0

                Dim Precio_ As Double = 0, Cantidad_ As Double = 0
                If Conversion.Val(GrdDetalleVenta.Rows(iROW).Cells("Precio").Value) = 0 Then Precio_ = 0 Else Precio_ = GrdDetalleVenta.Rows(iROW).Cells("Precio").Value
                If Conversion.Val(GrdDetalleVenta.Rows(iROW).Cells("Cantidad").Value) = 0 Then Cantidad_ = 0 Else Cantidad_ = GrdDetalleVenta.Rows(iROW).Cells("Cantidad").Value


                GrdDetalleVenta.Rows(iROW).Cells("P.Total").Value = IIf(Precio_ * Cantidad_ = 0, "0.00", Format(Precio_ * Cantidad_, "###,###,####.00"))

                Dim Valor As Double
                For ii1 = 0 To GrdDetalleVenta.Rows().Count() - 1
                    If Val(GrdDetalleVenta.Rows(ii1).Cells("P.Total").Value) = 0 Then
                        Valor = 0
                    Else
                        Valor = GrdDetalleVenta.Rows(ii1).Cells("P.Total").Value
                    End If
                    '---------------------
                    Total = Total + Valor
                    '---------------------
                Next
                '------------------------------
                Dim Monto_Sobre As Double = 0
                If ChkSobres.Checked = True Then
                    Monto_Sobre = tarifa_Sobre * Conversion.Val(txtCantidadSobres.Text)
                    txtTotalSobre.Visible = True
                    txtTotalSobre.Text = Format(Monto_Sobre, "####,###,###.00")
                End If
                '------------------------------
                'SubTotal_Costo = Monto_Base + Total + Monto_Sobre
                '18/11/2011
                'If iBaseArticulo = 1 Then
                '    SubTotal_Costo = Monto_Base + Total + Monto_Sobre
                'Else
                '    SubTotal_Costo = Total + Monto_Sobre
                'End If

                '21/06/2019
                intMinimoArticulo = 0
                If iBaseArticulo = 1 Then
                    Dim blnBase As Boolean = False
                    Dim intCantidad As Integer = 0
                    For i As Integer = 0 To GrdDetalleVenta.Rows.Count - 1
                        If GrdDetalleVenta.Rows(i).Cells(0).Value <> "ENTREGA" Then
                            intMinimoArticulo = DtArticulos.Rows(i).Item("minimo")
                            intCantidad = Conversion.Val(GrdDetalleVenta.Rows(i).Cells(2).Value)
                            If intCantidad > 0 Then
                                If intMinimoArticulo = 0 Then
                                    blnBase = True
                                    Exit For
                                Else
                                    If intCantidad <= intMinimoArticulo Then
                                        blnBase = True
                                        Exit For
                                    End If
                                End If
                            End If
                        End If
                    Next
                    If blnBase Then
                        SubTotal_Costo = Monto_Base + Total + Monto_Sobre
                    Else
                        SubTotal_Costo = Total + Monto_Sobre
                    End If
                Else
                    SubTotal_Costo = Total + Monto_Sobre
                End If

                If Total = 0 Then
                    SubTotal_Costo = Monto_Sobre
                End If

                Dim SUB_TOTAL_GENERAL As Double = 0
                If (1 - Val(Me.TxtDescuento.Text) / 100) > 0 Then
                    'hlamas 11-09-2015
                    'SUB_TOTAL_GENERAL = Format((1 + IGV) * SubTotal_Costo * (1 - Val("") / 100), "###,###,###.000")
                    SUB_TOTAL_GENERAL = Format(SubTotal_Costo * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000")
                Else
                    If (1 - Val(Me.TxtDescuento.Text) / 100) = 0 Then
                        SUB_TOTAL_GENERAL = 0
                    End If
                End If

                '*****************Calculo Operacion*********************************************
                TxtSubTotal.Text = IIf(SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
                TxtImpuesto.Text = IIf(IGV * SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
                TxtTotal.Text = IIf(SUB_TOTAL_GENERAL = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL, "###,###,###.00"), 2))
                '*******************************************************************************                          
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '********CALCULO ARTICULOS Y SOBRES (CREDITO)***********
    Sub calculoGrdArticulos()
        Try
            objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = 0
            Dim Total As Double = 0
            Dim ii1 As Integer = 0

            Dim Cant_ As Double = 0
            If Val(GrdDetalleVenta.Rows(iROW).Cells("Cantidad").Value) = 0 Then
                Cant_ = 0
            Else
                Cant_ = GrdDetalleVenta.Rows(iROW).Cells("Cantidad").Value
            End If

            If GrdDetalleVenta.Rows(iROW).Cells("IDARTICULO").Value = 211 Then
                GrdDetalleVenta.Rows(iROW).Cells("P.Total").Value = Format(GrdDetalleVenta.Rows(iROW).Cells("Precio").Value * GrdDetalleVenta.Rows(iROW).Cells("M3").Value, "###,###,###.00")
                GrdDetalleVenta.Rows(iROW).Cells("Cantidad").Value = Format(Val(Replace(GrdDetalleVenta.Rows(iROW).Cells("Cantidad").Value.ToString, ",", "")), "###,###,###")
            Else
                GrdDetalleVenta.Rows(iROW).Cells("P.Total").Value = IIf(GrdDetalleVenta.Rows(iROW).Cells("Precio").Value * Cant_ = 0, "0.00", _
                                                                        Format(GrdDetalleVenta.Rows(iROW).Cells("Precio").Value * Cant_, "###,###,###.00"))
                'hlamas 02-10-2019
                If Not (TipoGrid_ = FormatoGrid.ARTICULOS And CboTipo.SelectedValue = 2 And iID_Persona = ID_PERSONA_SODIMAC) Then
                    GrdDetalleVenta.Rows(iROW).Cells("M3").Value = "0.00"
                End If
            End If

            For ii1 = 0 To GrdDetalleVenta.Rows().Count() - 1
                Total = Total + CDbl(GrdDetalleVenta.Rows(ii1).Cells("P.Total").Value.ToString)
                objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI + Cant_
            Next

            Dim Monto_Sobre As Double = 0

            If ChkSobres.Checked = True Then
                Monto_Sobre = (tarifa_Sobre * Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text))
                txtTotalSobre.Visible = True
                txtTotalSobre.Text = IIf(Monto_Sobre = 0, "0.00", Format(Monto_Sobre, "#,###,###,###.00"))
            End If
            '************
            If Total = 0 Then VBase = False Else _
                            VBase = True

            '***         
            Total = Total + tarifa_Sobre * Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
            If VBase Then Total += Monto_Base : VBase = False
            '***
            '********************TOTALES********************************************************************
            TxtSubTotal.Text = IIf(Total = 0, "0.00", FormatNumber(Format(Total / (1 + IGV), "###,###,###.00"), 2))
            TxtImpuesto.Text = IIf(Total * IGV = 0, "0.00", FormatNumber(Format(IGV * Total / (1 + IGV), "###,###,###.00"), 2))
            TxtTotal.Text = IIf(Total * (1 + IGV) = 0, "0.00", FormatNumber(Format(Total, "###,###,###.00"), 2))
            '***********************************************************************************************

            'TxtSubTotal.Text = IIf(SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
            'TxtImpuesto.Text = IIf(IGV * SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
            'TxtTotal.Text = IIf(SUB_TOTAL_GENERAL = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL, "###,###,###.00"), 2))

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '********CALCULO M3 (PCE)*******************************
    Private Sub ChkM3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkM3.CheckedChanged
        Try
            If ChkM3.Checked = True Then
                bInicio = True
                If ChkArticulos.Checked = True Then ChkArticulos.Checked = False
                RemoveItemsCargAseg() '------------> Limpiando items [carga asegurada]
                TipoGrid_ = FormatoGrid.VOLUMETRICO '--------> Grid Volumetrico
                Me.DiseñaGrdDetalleVenta() '-------> Diseña GridDetalleVenta
                FormatoGrdDetalleVenta() '---------> Formato al grid
                GrdDetalleVenta(6, 0).Value = Format(tarifa_Peso, "0.00")
                TxtMontoBase.Text = FormatNumber(IIf(Val(tarifa_Sobre) = 0, 0, tarifa_Sobre), 2)

                ChkSobres.Visible = True
                ChkSobres.Enabled = True
                txtCantidadSobres.Visible = True
                txtCantidadSobres.Enabled = False
                txtTotalSobre.Visible = True
                LblMontoBase.Visible = True
                TxtMontoBase.Visible = True
                GrpDescuento.Enabled = True
                Me.CondicionMontoMinimoPCE()

                '--NuevaCondicion MontoMinimo 04022012
                If CboProducto.SelectedValue = 7 Then
                    Me.CondicionMontoMinimoPYME()
                End If
            Else
                TipoGrid_ = FormatoGrid.BULTO '--------------> Grid Bultos
                Me.DiseñaGrdDetalleVenta() '-------> Diseña GridDetalleVenta
                FormatoGrdDetalleVenta() '---------> Formato al grid
                Me.tarifarioEnMemoria()
                RemoveItemsCargAseg() '--->Limpiando items [carga asegurada]
                TxtSubTotal.Text = "0.00"
                TxtImpuesto.Text = "0.00"
                TxtTotal.Text = "0.00"

                ChkSobres.Visible = False
                txtCantidadSobres.Visible = False
                txtTotalSobre.Visible = False
                LblMontoBase.Visible = False
                TxtMontoBase.Visible = False
                GrpDescuento.Enabled = True
                Me.CondicionMontoMinimoPCE()

                '--NuevaCondicion MontoMinimo 04022012
                If CboProducto.SelectedValue = 7 Then
                    Me.CondicionMontoMinimoPYME()
                End If
            End If
            'hlamas 28-11-2013
            GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, dtoUSUARIOS.m_idciudad, idUnidadAgencias, CboProducto.SelectedValue, 3, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
   
    Sub Calculo_M3()

        ' Modificado por Diego Zegarra T. 08/07/2013
        Try
            Dim IGV As Double = dtoUSUARIOS.iIGV / 100
            '************************

            Dim Altura As Double = 0
            If Conversion.Val(GrdDetalleVenta(2, iROW).Value) = 0 Then Altura = 0 _
                                     Else Altura = GrdDetalleVenta(2, iROW).Value

            '************************
            Dim Ancho As Double = 0
            If Conversion.Val(GrdDetalleVenta(3, iROW).Value) = 0 Then Ancho = 0 _
                                    Else Ancho = GrdDetalleVenta(3, iROW).Value

            '************************
            Dim Largo As Double = 0
            If Conversion.Val(GrdDetalleVenta(4, iROW).Value) = 0 Then Largo = 0 _
                                    Else Largo = GrdDetalleVenta(4, iROW).Value

            '******PESO KG***********
            'hlamas 11-09-2015
            'GrdDetalleVenta("Peso Kg", iROW).Value = IIf((Altura * Ancho * Largo) * dFactor = 0, "0.00", _
            '                                          FormatNumber(Format((Altura * Ancho * Largo) * dFactor, "###,###,###.00"), 2))
            Dim dblPeso As Double = Altura * Ancho * Largo * dFactor
            GrdDetalleVenta("Peso Kg", iROW).Value = IIf((Altura * Ancho * Largo) * dFactor = 0, "0.00", FormatNumber(Format(RedondearMas(dblPeso), "###,###,###.00"), 2))


            '******Llamando la Condicion Tarifa(Calculo)*******
            If objGuiaEnvio.CondicionTarifa_ Then
                fnCalcularCondicionTarifa(iROW, GrdDetalleVenta("Peso Kg", iROW).Value, GrdDetalleVenta("Costo", iROW).Value)
            Else
                '******Sub Neto***********
                GrdDetalleVenta("Sub Neto", iROW).Value = IIf(GrdDetalleVenta("Peso Kg", iROW).Value * Conversion.Val(GrdDetalleVenta("Costo", iROW).Value) = 0, "0.00", _
                                                              FormatNumber(Format((GrdDetalleVenta("Peso Kg", iROW).Value) * Conversion.Val(GrdDetalleVenta("Costo", iROW).Value), "###,###,###.00"), 2))
            End If

            '*****************Calculo Operacion*********************************************   
            Dim SumSubNeto_ As Double = 0
            Dim Valor_ As Double
            For i As Integer = 0 To GrdDetalleVenta.Rows.Count() - 1
                'hlamas 28-11-2013
                If IsNumeric(GrdDetalleVenta("tipo", i).Value) Then
                    If Conversion.Val(GrdDetalleVenta("Sub Neto", i).Value) = 0 Then Valor_ = 0 _
                                        Else Valor_ = GrdDetalleVenta("Sub Neto", i).Value
                    SumSubNeto_ += Valor_
                End If
            Next
            '**********************
            If SumSubNeto_ > 0 Then
                If Monto_Base > 0 Then
                    ObjVentaCargaContado.v_MONTO_BASE = Monto_Base
                End If

                ObjVentaCargaContado.v_MONTO_BASE = 0
                SumSubNeto_ = SumSubNeto_ + Monto_Base
            End If
            ''**********************

            Dim Monto_Sobre As Double = 0
            If ChkSobres.Checked = True Then
                Monto_Sobre = tarifa_Sobre * Conversion.Val(txtCantidadSobres.Text)
                txtTotalSobre.Visible = True
                txtTotalSobre.Text = Format(Monto_Sobre, "####,###,###.00")
            End If

            '****Añade [Sobres] al la sumaSubNeto*******************************************
            Dim MontoSobre_ As Double = 0
            If (Val(Me.txtCantidadSobres.Text) / 100) > 0 Then MontoSobre_ = _
                                                               (txtCantidadSobres.Text * tarifa_Sobre) ' + Monto_Base


            '****Validando el Monto Sobre Valor 0*******************************************
            If (txtTotalSobre.Text = "") Then
                txtTotalSobre.Text = 0.0
            End If


            'hlamas 28-11-2013
            '********************************ENTREGA A DOMICILIO***********************************************
            dblMontoEntregaDomicilio = GestionaMontoTarifaDomicilio(dtTarifaServicio, GrdDetalleVenta, TipoGrid_)
            SumSubNeto_ = SumSubNeto_ + dblMontoEntregaDomicilio
            '********************************DEVOLUCION DE CARGO************************************************
            dblMontoDC = ObtieneMontoDevolucionCargo()
            SumSubNeto_ = SumSubNeto_ + dblMontoDC
            '********************************DEVOLUCION DE CARGO************************************************

            '********************************CARGA SEGURO*******************************************************************
            'precio_carga_asegurada()
            'SumSubNeto_ = TxtSubtotal.Text
            Dim intFila As Integer = BuscarItemVenta("SEGURO", GrdDetalleVenta)
            If intFila > 0 Then
                SumSubNeto_ += Val(GrdDetalleVenta("sub neto", intFila).Value)
            End If

            '*******************************************************************************
            'hlamas 11-09-2015
            'SumSubNeto_ = fnTECHO(Format(SumSubNeto_ + MontoSobre_, "0.000"))
            SumSubNeto_ = Format(SumSubNeto_ + MontoSobre_, "0.000")
            '*******************************************

            Dim Total_ As Double = SumSubNeto_
            Dim Subtotal_ As Double = Total_ / (1 + IGV)
            Dim Impuesto_ As Double = Subtotal_ * IGV

            'Dim Total_ As Double
            'Dim Subtotal_ As Double
            'Dim Impuesto_ As Double

            'Subtotal_ = SumSubNeto_ + txtTotalSobre.Text + CType(txtMontoBase.Text, Double)
            'Impuesto_ = Subtotal_ * IGV
            'Total_ = Impuesto_ + Subtotal_

            '*******************************************
            If CboProducto.SelectedValue = 7 And Total_ <= MontoMinimoPyme Then '04022012
                Me.CondicionMontoMinimoPYME()
            Else
                'hlamas 12-02-2014
                If TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                    Dim intDescuentoPromocion = CalculaPromocion()
                    If intDescuentoPromocion > 0 And intDescuentoPromocion < 100 Then
                        SumSubNeto_ = (SumSubNeto_ * (1 - Val(intDescuentoPromocion) / 100))
                        'hlamas 11-09-2015
                        'SumSubNeto_ = fnTECHO(Format(SumSubNeto_, "0.000"))
                        SumSubNeto_ = Format(SumSubNeto_, "0.000")
                    End If
                End If

                TxtSubTotal.Text = IIf(Subtotal_ = 0, "0.00", FormatNumber(Format(Subtotal_, "###,###,###.00"), 2))
                TxtImpuesto.Text = IIf(Impuesto_ = 0, "0.00", FormatNumber(Format(Impuesto_, "###,###,###.00"), 2))
                TxtTotal.Text = IIf(Total_ = 0, "0.00", FormatNumber(Total_, 2))
            End If

            '*******************************************           

            If (Val(Me.TxtDescuento.Text) / 100) > 0 Then '-> Aplica Descuento
                Me.DescuentoM3()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '' Modificado por Diego Zegarra T. 06/07/2013
        'Try
        '    Dim IGV As Double = dtoUSUARIOS.iIGV / 100
        '    '************************
        '    Dim Altura As Double = 0
        '    If Conversion.Val(GrdDetalleVenta(2, iROW).Value) = 0 Then Altura = 0 _
        '                             Else Altura = GrdDetalleVenta(2, iROW).Value
        '    '************************
        '    Dim Ancho As Double = 0
        '    If Conversion.Val(GrdDetalleVenta(3, iROW).Value) = 0 Then Ancho = 0 _
        '                            Else Ancho = GrdDetalleVenta(3, iROW).Value
        '    '************************
        '    Dim Largo As Double = 0
        '    If Conversion.Val(GrdDetalleVenta(4, iROW).Value) = 0 Then Largo = 0 _
        '                            Else Largo = GrdDetalleVenta(4, iROW).Value

        '    '******PESO KG***********
        '    GrdDetalleVenta("Peso Kg", iROW).Value = IIf((Altura * Ancho * Largo) * dFactor = 0, "0.00", _
        '                                                FormatNumber(Format((Altura * Ancho * Largo) * dFactor, "###,###,###.00"), 2))

        '    '******Llamando la Condicion Tarifa(Calculo)*******
        '    If objGuiaEnvio.CondicionTarifa_ And objGuiaEnvio.UnidadPeso_ = "PESO" Then
        '        fnCalcularCondicionTarifa(iROW, GrdDetalleVenta("Peso Kg", iROW).Value, GrdDetalleVenta("Costo", iROW).Value)
        '    Else
        '        '******SUB_NETO***********
        '        GrdDetalleVenta("Sub Neto", iROW).Value = IIf(GrdDetalleVenta("Peso Kg", iROW).Value * Conversion.Val(GrdDetalleVenta("Costo", iROW).Value) = 0, "0.00", _
        '                                                      FormatNumber(Format((GrdDetalleVenta("Peso Kg", iROW).Value) * Conversion.Val(GrdDetalleVenta("Costo", iROW).Value), "###,###,###.00"), 2))
        '    End If


        '    '*****************Calculo Operacion*********************************************   
        '    Dim SumSubNeto_ As Double = 0
        '    Dim Valor_ As Double
        '    For i As Integer = 0 To GrdDetalleVenta.Rows.Count() - 1
        '        'hlamas 28-11-2013
        '        If IsNumeric(GrdDetalleVenta("tipo", i).Value) Then
        '            If Conversion.Val(GrdDetalleVenta("Sub Neto", i).Value) = 0 Then Valor_ = 0 _
        '                                Else Valor_ = GrdDetalleVenta("Sub Neto", i).Value
        '            SumSubNeto_ += Valor_
        '        End If
        '    Next
        '    ''**********************
        '    'If SumSubNeto_ > 0 Then
        '    '    If Monto_Base > 0 Then
        '    '        ObjVentaCargaContado.v_MONTO_BASE = Monto_Base
        '    '    End If

        '    '    ObjVentaCargaContado.v_MONTO_BASE = 0
        '    '    SumSubNeto_ = SumSubNeto_ + Monto_Base
        '    'End If
        '    ''**********************

        '    Dim Monto_Sobre As Double = 0
        '    If ChkSobres.Checked = True Then
        '        Monto_Sobre = tarifa_Sobre * Conversion.Val(txtCantidadSobres.Text)
        '        txtTotalSobre.Visible = True
        '        txtTotalSobre.Text = Format(Monto_Sobre, "####,###,###.00")
        '    End If


        '    '****Validando el Nullo de los Sobres*******************************************
        '    If (txtTotalSobre.Text = "") Then
        '        txtTotalSobre.Text = 0.0
        '    End If
        '    'If (Val(Me.txtCantidadSobres.Text) / 100) > 0 Then MontoSobre_ = _
        '    '                                                   (txtCantidadSobres.Text * tarifa_Sobre) ' + Monto_Base
        '    '*******************************************************************************
        '    'SumSubNeto_ = fnTECHO(Format(SumSubNeto_ + MontoSobre_, "0.000"))
        '    '*******************************************
        '    Dim Total_ As Double
        '    Dim Subtotal_ As Double
        '    Dim Impuesto_ As Double

        '    'If bTarifarioGeneral And bContado = False Then
        '    '    Total_ = SumSubNeto_ * (1 + IGV) 'fnTECHO(Format(SumSubNeto_ * (1 + IGV), "0.000"))
        '    '    Subtotal_ = Total_ / (1 + IGV)
        '    '    Impuesto_ = Subtotal_ * IGV
        '    'Else
        '    '    Total_ = SumSubNeto_
        '    '    Subtotal_ = Total_ / (1 + IGV)
        '    '    Impuesto_ = Subtotal_ * IGV
        '    'End If

        '    Subtotal_ = SumSubNeto_ + txtTotalSobre.Text + CType(TxtMontoBase.Text, Double)
        '    Impuesto_ = Subtotal_ * IGV
        '    Total_ = Impuesto_ + Subtotal_



        '    'agregado 04022012
        '    If (Total_ < MontoMinimoPyme) And CboTipo.SelectedValue = 1 And CboProducto.SelectedValue = 7 Then
        '        Me.CondicionMontoMinimoPYME()
        '    ElseIf (Total_ < monto_minimo_PCE) And CboTipo.SelectedValue = 1 And CboProducto.SelectedValue <> 7 Then
        '        TxtDescuento.Enabled = False
        '        Me.CondicionMontoMinimoPCE()
        '    Else
        '        '*******************************************
        '        TxtDescuento.Enabled = True
        '        TxtSubTotal.Text = IIf(Subtotal_ = 0, "0.00", FormatNumber(Format(Subtotal_, "###,###,###.00"), 2))
        '        TxtImpuesto.Text = IIf(Impuesto_ = 0, "0.00", FormatNumber(Format(Impuesto_, "###,###,###.00"), 2))
        '        TxtTotal.Text = IIf(Total_ = 0, "0.00", FormatNumber(Total_, 2))
        '        '******************************************* 
        '    End If

        '    'If (Val(Me.TxtDescuento.Text) / 100) > 0 Then '-> Aplica Descuento
        '    '    Me.DescuentoM3()
        '    'End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    '********CALCULO DESCUENTO M3***************************
    Sub DescuentoM3()

        Dim SumSubNeto_ As Double = 0
        Dim Valor_ As Double
        Try
            For i As Integer = 0 To GrdDetalleVenta.Rows.Count() - 1
                If IsNumeric(GrdDetalleVenta("tipo", i).Value) Then
                    If Conversion.Val(GrdDetalleVenta("Sub Neto", i).Value) = 0 Then Valor_ = 0 _
                                        Else Valor_ = GrdDetalleVenta("Sub Neto", i).Value
                    SumSubNeto_ += Valor_
                End If
            Next

            Dim IGV As Double = dtoUSUARIOS.iIGV / 100

            '****Añade [Sobres] al la sumaSubNeto*******************************************
            Dim MontoSobre_ As Double = 0
            If (Val(Me.txtCantidadSobres.Text) / 100) > 0 Then MontoSobre_ = _
                                                               (txtCantidadSobres.Text * Monto_Base) 'hlamas 28-11-2013 + Monto_Base

            SumSubNeto_ = (Format(SumSubNeto_ + MontoSobre_, "0.00"))

            'hlamas 28-11-2013
            '********Agrega Monto Base*********************************
            If Val(Me.TxtMontoBase.Text) > 0 Then
                SumSubNeto_ = (Format(SumSubNeto_ + Val(Me.TxtMontoBase.Text), "0.00"))
            End If

            Dim intFila As Integer
            '********Agrega Entrega Domicilio***************************
            intFila = BuscarItemVenta("ENTREGA", GrdDetalleVenta)
            If intFila > 0 Then
                SumSubNeto_ = (Format(SumSubNeto_ + Val(GrdDetalleVenta("SUB NETO", intFila).Value), "0.00"))
            End If
            '********************************DEVOLUCION DE CARGO************************************************
            intFila = BuscarItemVenta("DEV CARGO", GrdDetalleVenta)
            If intFila > 0 Then
                'dblMontoDC = ObtieneMontoDevolucionCargo()
                SumSubNeto_ += Format(Val(GrdDetalleVenta("Sub Neto", intFila).Value), "0.00")
            End If
            '********************************DEVOLUCION DE CARGO************************************************
            '********Agregar Carga Seguro*******************************
            intFila = BuscarItemVenta("SEGURO", GrdDetalleVenta)
            If intFila > 0 Then
                SumSubNeto_ = (Format(SumSubNeto_ + Val(GrdDetalleVenta("SUB NETO", intFila).Value), "0.00"))
            End If
            '******DESCUENTO ARTICULOS******************************************************
            Dim SUB_TOTAL_GENERAL As Double = 0
            If (1 - Val(Me.TxtDescuento.Text) / 100) > 0 Then
                'hlamas 11-09-2015
                'SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SumSubNeto_ * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
                SUB_TOTAL_GENERAL = Format((1 + IGV) * SumSubNeto_ * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000")
                If Val(TxtDescuento.Text) > 0 Or Val(TxtDescuento.Text) < 0 Then
                    SUB_TOTAL_GENERAL = RedondearMas(SUB_TOTAL_GENERAL, 1)
                End If
                If bTarifarioGeneral Then
                    'hlamas 11-09-2015
                    'SUB_TOTAL_GENERAL = fnTECHO(Format(SumSubNeto_ * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
                    SUB_TOTAL_GENERAL = Format(SumSubNeto_ * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000")
                    If Val(TxtDescuento.Text) > 0 Or Val(TxtDescuento.Text) < 0 Then
                        SUB_TOTAL_GENERAL = RedondearMas(SUB_TOTAL_GENERAL, 1)
                    End If
                End If
            Else
                If (1 - Val(Me.TxtDescuento.Text) / 100) = 0 Then
                    SUB_TOTAL_GENERAL = 0
                End If
            End If

            '*******************************************
            Dim Total_ As Double = SUB_TOTAL_GENERAL
            Dim Subtotal_ As Double = Total_ / (1 + IGV)
            Dim Impuesto_ As Double = Subtotal_ * IGV
            '*******************************************

            If CboProducto.SelectedValue = 7 And Total_ <= MontoMinimoPyme Then 'agregado 04022012
                Me.CondicionMontoMinimoPYME()
            Else
                'hlamas 12-02-2014
                If TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                    Dim intDescuentoPromocion = CalculaPromocion()
                    If intDescuentoPromocion > 0 And intDescuentoPromocion < 100 Then
                        SUB_TOTAL_GENERAL = (SUB_TOTAL_GENERAL * (1 - Val(intDescuentoPromocion) / 100))
                        'hlamas 11-09-2015
                        'SUB_TOTAL_GENERAL = fnTECHO(Format(SUB_TOTAL_GENERAL, "0.000"))
                        SUB_TOTAL_GENERAL = Format(SumSubNeto_ * (1 - Val(intDescuentoPromocion) / 100), "###,###,###.000")
                        If Val(TxtDescuento.Text) > 0 Or Val(TxtDescuento.Text) < 0 Then
                            SUB_TOTAL_GENERAL = RedondearMas(SUB_TOTAL_GENERAL, 1)
                        End If
                    End If
                End If

                TxtSubTotal.Text = IIf(Subtotal_ = 0, "0.00", FormatNumber(Format(Subtotal_, "###,###,###.00"), 2))
                TxtImpuesto.Text = IIf(Impuesto_ = 0, "0.00", FormatNumber(Format(Impuesto_, "###,###,###.00"), 2))
                TxtTotal.Text = IIf(Total_ = 0, "0.00", FormatNumber(Total_, 2))
                End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'Dim SumSubNeto_ As Double = 0
        'Dim Valor_ As Double
        'Try
        '    For i As Integer = 0 To GrdDetalleVenta.Rows.Count() - 1
        '        If Conversion.Val(GrdDetalleVenta("Sub Neto", i).Value) = 0 Then Valor_ = 0 _
        '                            Else Valor_ = GrdDetalleVenta("Sub Neto", i).Value
        '        SumSubNeto_ += Valor_
        '    Next

        '    Dim IGV As Double = dtoUSUARIOS.iIGV / 100

        '    '****Añade [Sobres] al la sumaSubNeto*******************************************
        '    Dim MontoSobre_ As Double = 0
        '    If (Val(Me.txtCantidadSobres.Text) / 100) > 0 Then MontoSobre_ = _
        '                                                       (txtCantidadSobres.Text * Monto_Base) + Monto_Base

        '    SumSubNeto_ = fnTECHO(Format(SumSubNeto_ + MontoSobre_, "0.00"))
        '    '******DESCUENTO ARTICULOS******************************************************
        '    Dim SUB_TOTAL_GENERAL As Double = 0
        '    If (1 - Val(Me.TxtDescuento.Text) / 100) > 0 Then
        '        SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SumSubNeto_ * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
        '        If bTarifarioGeneral Then
        '            SUB_TOTAL_GENERAL = fnTECHO(Format(SumSubNeto_ * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
        '        End If
        '    Else
        '        If (1 - Val(Me.TxtDescuento.Text) / 100) = 0 Then
        '            SUB_TOTAL_GENERAL = 0
        '        End If
        '    End If

        '    '*******************************************
        '    Dim Total_ As Double = SUB_TOTAL_GENERAL
        '    Dim Subtotal_ As Double = Total_ / (1 + IGV)
        '    Dim Impuesto_ As Double = Subtotal_ * IGV
        '    '*******************************************
        '    '04022012
        '    If Total_ < MontoMinimoPyme And CboTipo.SelectedValue = 1 And CboProducto.SelectedValue = 7 Then
        '        Me.CondicionMontoMinimoPYME()
        '    ElseIf (Total_ < monto_minimo_PCE) And CboTipo.SelectedValue = 1 And CboProducto.SelectedValue <> 7 Then
        '        'TxtDescuento.Enabled = False
        '        Me.CondicionMontoMinimoPCE()
        '    Else
        '        TxtDescuento.Enabled = True
        '        TxtSubTotal.Text = IIf(Subtotal_ = 0, "0.00", FormatNumber(Format(Subtotal_, "###,###,###.00"), 2))
        '        TxtImpuesto.Text = IIf(Impuesto_ = 0, "0.00", FormatNumber(Format(Impuesto_, "###,###,###.00"), 2))
        '        TxtTotal.Text = IIf(Total_ = 0, "0.00", FormatNumber(Total_, 2))
        '    End If

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub
    Private Sub fnCalcularCondicionTarifa(ByVal row As Integer, ByVal Peso_Volumen As Double, ByVal Costo As Double)
        Try
            If ChkM3.Checked Then
                If Peso_Volumen >= objGuiaEnvio.iPeso_Minimo And Peso_Volumen <= objGuiaEnvio.iPeso_Maximo And Costo > 0 Then
                    GrdDetalleVenta("Sub Neto", row).Value = objGuiaEnvio.iPrecio_cond_Peso
                ElseIf Peso_Volumen > objGuiaEnvio.iPeso_Maximo And Costo > 0 Then
                    Dim Calculo As Double = (Peso_Volumen - objGuiaEnvio.iPeso_Maximo) * (Costo)
                    Dim SubNeto As Double = (Calculo + objGuiaEnvio.iPrecio_cond_Peso)
                    GrdDetalleVenta("Sub Neto", row).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)
                ElseIf Peso_Volumen < objGuiaEnvio.iPeso_Minimo Then
                    GrdDetalleVenta("Sub Neto", row).Value = "0.00"
                End If
            Else
                If (CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_COURIER) Then
                    If row = 0 Or row = 1 Then '-->Peso
                        If Peso_Volumen >= objGuiaEnvio.iPeso_Minimo And Peso_Volumen <= objGuiaEnvio.iPeso_Maximo And Costo > 0 Then
                            GrdDetalleVenta("Sub Neto", row).Value = objGuiaEnvio.iPrecio_cond_Peso
                        ElseIf Peso_Volumen > objGuiaEnvio.iPeso_Maximo And Costo > 0 Then
                            Dim Calculo As Double = (Peso_Volumen - objGuiaEnvio.iPeso_Maximo) * (Costo)
                            Dim SubNeto As Double = (Calculo + objGuiaEnvio.iPrecio_cond_Peso)
                            GrdDetalleVenta("Sub Neto", row).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)
                        ElseIf Peso_Volumen < objGuiaEnvio.iPeso_Minimo Then
                            GrdDetalleVenta("Sub Neto", row).Value = "0.00"
                        End If
                    End If
                Else
                    If row = 0 Then '-->Peso
                        If Peso_Volumen >= objGuiaEnvio.iPeso_Minimo And Peso_Volumen <= objGuiaEnvio.iPeso_Maximo And Costo > 0 Then
                            GrdDetalleVenta("Sub Neto", row).Value = objGuiaEnvio.iPrecio_cond_Peso
                        ElseIf Peso_Volumen > objGuiaEnvio.iPeso_Maximo And Costo > 0 Then

                            Dim Calculo As Double = (Peso_Volumen - objGuiaEnvio.iPeso_Maximo) * (Costo)
                            Dim SubNeto As Double = (Calculo + objGuiaEnvio.iPrecio_cond_Peso)
                            GrdDetalleVenta("Sub Neto", row).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)
                        ElseIf Peso_Volumen < objGuiaEnvio.iPeso_Minimo Then
                            GrdDetalleVenta("Sub Neto", row).Value = "0.00"
                        End If
                    ElseIf row = 1 Then '-->Volumen
                        If Peso_Volumen >= objGuiaEnvio.iVol_Minimo And Peso_Volumen <= objGuiaEnvio.iVol_Maximo And Costo > 0 Then
                            GrdDetalleVenta("Sub Neto", row).Value = objGuiaEnvio.iPrecio_cond_Vol

                        ElseIf Peso_Volumen > objGuiaEnvio.iVol_Maximo And Costo > 0 Then
                            Dim Calculo As Double = (Peso_Volumen - objGuiaEnvio.iVol_Maximo) * (Costo)
                            Dim SubNeto As Double = (Calculo + objGuiaEnvio.iPrecio_cond_Vol)
                            GrdDetalleVenta("Sub Neto", row).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)

                        ElseIf Peso_Volumen < objGuiaEnvio.iVol_Minimo Then
                            GrdDetalleVenta("Sub Neto", row).Value = "0.00"
                        End If
                    End If
                End If

            End If


            Dim ValNroSobres As Double = 0
            Dim Nor_Sobres As Double = 0
            If ChkM3.Checked = False Then
                If Conversion.Val(GrdDetalleVenta(1, 2).Value) = 0 Then ValNroSobres = 0 Else ValNroSobres = GrdDetalleVenta(1, 2).Value
                Nor_Sobres = Val(IIf(GrdDetalleVenta(1, 2).Value Is Nothing, 0, ValNroSobres))
            End If

            Dim Sub_Neto_ As Double
            Dim Monto As Double

            For i As Integer = 0 To GrdDetalleVenta.Rows.Count() - 3
                If Conversion.Val(GrdDetalleVenta("Sub Neto", i).Value) = 0 Then Monto = 0 _
                                Else Monto = GrdDetalleVenta("Sub Neto", i).Value '--> Formateando en caso de Coma
                Sub_Neto_ += Monto
            Next
            SubTotal_Costo = Sub_Neto_

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    '********CALCULO CONDICION TARIFA***********************
    'Private Sub fnCalcularCondicionTarifa(ByVal row As Integer, ByVal Peso_Volumen As Double, ByVal Costo As Double)
    '    Try
    '        If ChkM3.Checked Then
    '            If Peso_Volumen >= objGuiaEnvio.iPeso_Minimo And Peso_Volumen <= objGuiaEnvio.iPeso_Maximo And Costo > 0 Then
    '                GrdDetalleVenta("Sub Neto", row).Value = objGuiaEnvio.iPrecio_cond_Peso
    '            ElseIf Peso_Volumen > objGuiaEnvio.iPeso_Maximo And Costo > 0 Then
    '                Dim Calculo As Double = (Peso_Volumen - objGuiaEnvio.iPeso_Maximo) * (Costo)
    '                Dim SubNeto As Double = (Calculo + objGuiaEnvio.iPrecio_cond_Peso)
    '                GrdDetalleVenta("Sub Neto", row).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)
    '            ElseIf Peso_Volumen < objGuiaEnvio.iPeso_Minimo Then
    '                GrdDetalleVenta("Sub Neto", row).Value = "0.00"
    '            End If
    '        Else
    '            If (CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_COURIER) Then
    '                If row = 0 Or row = 1 Then '-->Peso
    '                    If Peso_Volumen >= objGuiaEnvio.iPeso_Minimo And Peso_Volumen <= objGuiaEnvio.iPeso_Maximo And Costo > 0 Then
    '                        GrdDetalleVenta("Sub Neto", row).Value = objGuiaEnvio.iPrecio_cond_Peso
    '                    ElseIf Peso_Volumen > objGuiaEnvio.iPeso_Maximo And Costo > 0 Then
    '                        Dim Calculo As Double = (Peso_Volumen - objGuiaEnvio.iPeso_Maximo) * (Costo)
    '                        Dim SubNeto As Double = (Calculo + objGuiaEnvio.iPrecio_cond_Peso)
    '                        GrdDetalleVenta("Sub Neto", row).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)
    '                    ElseIf Peso_Volumen < objGuiaEnvio.iPeso_Minimo Then
    '                        GrdDetalleVenta("Sub Neto", row).Value = "0.00"
    '                    End If
    '                End If
    '            Else
    '                If row = 0 Then '-->Peso
    '                    If Peso_Volumen >= objGuiaEnvio.iPeso_Minimo And Peso_Volumen <= objGuiaEnvio.iPeso_Maximo And Costo > 0 Then
    '                        GrdDetalleVenta("Sub Neto", row).Value = objGuiaEnvio.iPrecio_cond_Peso
    '                    ElseIf Peso_Volumen > objGuiaEnvio.iPeso_Maximo And Costo > 0 Then

    '                        Dim Calculo As Double = (Peso_Volumen - objGuiaEnvio.iPeso_Maximo) * (Costo)
    '                        Dim SubNeto As Double = (Calculo + objGuiaEnvio.iPrecio_cond_Peso)
    '                        GrdDetalleVenta("Sub Neto", row).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)
    '                    ElseIf Peso_Volumen < objGuiaEnvio.iPeso_Minimo Then
    '                        GrdDetalleVenta("Sub Neto", row).Value = "0.00"
    '                    End If
    '                ElseIf row = 1 Then '-->Volumen
    '                    If Peso_Volumen >= objGuiaEnvio.iVol_Minimo And Peso_Volumen <= objGuiaEnvio.iVol_Maximo And Costo > 0 Then
    '                        GrdDetalleVenta("Sub Neto", row).Value = objGuiaEnvio.iPrecio_cond_Vol

    '                    ElseIf Peso_Volumen > objGuiaEnvio.iVol_Maximo And Costo > 0 Then
    '                        Dim Calculo As Double = (Peso_Volumen - objGuiaEnvio.iVol_Maximo) * (Costo)
    '                        Dim SubNeto As Double = (Calculo + objGuiaEnvio.iPrecio_cond_Vol)
    '                        GrdDetalleVenta("Sub Neto", row).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)

    '                    ElseIf Peso_Volumen < objGuiaEnvio.iVol_Minimo Then
    '                        GrdDetalleVenta("Sub Neto", row).Value = "0.00"
    '                    End If
    '                End If
    '            End If
    '        End If

    '        Dim ValNroSobres As Double = 0
    '        Dim Nor_Sobres As Double = 0
    '        If ChkM3.Checked = False Then
    '            If Conversion.Val(GrdDetalleVenta(1, 2).Value) = 0 Then ValNroSobres = 0 Else ValNroSobres = GrdDetalleVenta(1, 2).Value
    '            Nor_Sobres = Val(IIf(GrdDetalleVenta(1, 2).Value Is Nothing, 0, ValNroSobres))
    '        End If

    '        Dim Sub_Neto_ As Double = 0
    '        Dim Monto As Double

    '        'For i As Integer = 0 To GrdDetalleVenta.Rows.Count() - 3
    '        For i As Integer = row To row
    '            If Conversion.Val(GrdDetalleVenta("Sub Neto", i).Value) = 0 Then Monto = 0 _
    '                            Else Monto = GrdDetalleVenta("Sub Neto", i).Value '--> Formateando en caso de Coma
    '            Sub_Neto_ += Monto
    '        Next
    '        SubTotal_Costo = Sub_Neto_

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    '********SOBRES*****************************************
    Private Sub ChkSobre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSobres.CheckedChanged
        Try
            RemoveHandler txtCantidadSobres.TextChanged, AddressOf txtCantSobres_TextChanged
            If ChkSobres.Checked = True Then
                txtCantidadSobres.Enabled = True
            Else
                txtCantidadSobres.Enabled = False
            End If

            If ChkSobres.Checked = True Then
                txtCantidadSobres.Enabled = True
                txtCantidadSobres.Focus()
            Else
                txtCantidadSobres.Enabled = False
                txtCantidadSobres.Text = ""
                txtTotalSobre.Text = "0.00"
                If ChkM3.Checked = True Then
                    'Me.Calculo_M3()
                Else
                    If CboTipo.SelectedValue = 1 Then
                        Me.CalculoArticulos() '----> PCE
                    ElseIf CboTipo.SelectedValue = 2 Then
                        Me.calculoGrdArticulos() '--> CREDITO
                    End If

                End If
            End If
            AddHandler txtCantidadSobres.TextChanged, AddressOf txtCantSobres_TextChanged
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCantidadSobres_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidadSobres.Resize

    End Sub

    Private Sub txtCantSobres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidadSobres.TextChanged
        Try
            If CboTipo.SelectedValue = 1 Or CboTipo.SelectedValue = 2 Or CboTipo.SelectedValue = 3 Then
                If txtCantidadSobres.Text = "" Then
                    objGuiaEnvio.iCANTIDAD_SOBRES = 0
                    objGuiaEnvio.iIDSINO_SOBRES = 0
                    txtTotalSobre.Text = "0.00"

                    '****NEW CODIGO*********************************************
                    Dim Val As Boolean = False
                    For i As Integer = 0 To GrdDetalleVenta.Rows.Count() - 1
                        If GrdDetalleVenta(2, i).Value <> "" Then
                            Val = True
                        End If
                    Next

                    If Val Then
                        TxtSubTotal.Text = "0.00"
                        TxtImpuesto.Text = "0.00"
                        TxtTotal.Text = "0.00"
                    End If
                    '***********************************************************
                Else
                    If tarifa_Sobre = 0 Then Return
                    txtCantidadSobres.Enabled = True
                    txtCantidadSobres.Focus()
                    objGuiaEnvio.iCANTIDAD_SOBRES = Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
                    objGuiaEnvio.iIDSINO_SOBRES = 1
                End If

                If recuperando_datos_contado = False Then
                    If ChkM3.Checked = True Then
                        Me.Calculo_M3() '---------> Sobre M3
                    ElseIf (Val(Me.txtCantidadSobres.Text) / 100) > 0 Then
                        Calculo_Sobre() '---------> Sobre Bulto
                    Else
                        iCOL = 2
                        Me.CalculoArticulos() '--->Sobre Articulo
                    End If
                End If
            Else
                If ChkArticulos.Enabled = True And ChkArticulos.Checked = True Then
                    Me.calculoGrdArticulos()
                End If
            End If
            '----------------------------------------------------------------------
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCantSobres_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidadSobres.LostFocus
        'If txtCantidadSobres.Text = "" Then
        '    RemoveHandler ChkSobres.CheckedChanged, AddressOf ChkSobre_CheckedChanged
        '    ChkSobres.Checked = False
        '    txtCantidadSobres.Enabled = False
        '    AddHandler ChkSobres.CheckedChanged, AddressOf ChkSobre_CheckedChanged
        'End If
        If txtCantidadSobres.Text = "" Then
            ChkSobres.Checked = False
            txtCantidadSobres.Enabled = False
        End If
    End Sub

    '********CALCULO SOBRES PCE*****************************
    Private Function Calculo_Sobre() As Boolean
        Try
            Dim IGV As Double = dtoUSUARIOS.iIGV / 100
            Dim c__var As Integer = 1
            Dim Monto_Sobre As Double = 0
            If c__var Then
                Monto_Sobre = tarifa_Sobre * Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
                txtTotalSobre.Text = IIf(Monto_Sobre = 0, "0.00", Format(Monto_Sobre, "####,###,###.00"))
            Else
                Monto_Sobre = 0
                txtTotalSobre.Text = "0.00"
            End If

            Dim Total_Articulo As Double = 0
            Dim T_Costo As Double = 0
            If fArticulo = True Then
                Dim ii1 As Integer = 0
                For ii1 = 0 To GrdDetalleVenta.Rows().Count() - 1
                    If Val(GrdDetalleVenta.Rows(ii1).Cells("P.Total").Value) = 0 Then T_Costo = 0 Else _
                                                   T_Costo = GrdDetalleVenta.Rows(ii1).Cells("P.Total").Value
                    Total_Articulo = Total_Articulo + T_Costo
                Next
                ' Total_Articulo = Total_Articulo '+ Monto_Base * Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
                If Total_Articulo > 0 Then
                    TxtSubTotal.Text = Format(Monto_Base + Monto_Sobre + Total_Articulo, "####,###,###.00")
                    TxtImpuesto.Text = Format((IGV) * (Monto_Base + Monto_Sobre + Total_Articulo), "####,###,###.00")
                    TxtTotal.Text = Format((1 + IGV) * (Monto_Base + Monto_Sobre + Total_Articulo), "####,###,###.00")
                Else
                    TxtSubTotal.Text = Format(Monto_Sobre, "####,###,###.00")
                    TxtImpuesto.Text = Format((IGV) * (Monto_Sobre), "####,###,###.00")
                    TxtTotal.Text = Format((1 + IGV) * (Monto_Sobre), "####,###,###.00")
                End If
            Else
                TxtSubTotal.Text = Format(Monto_Sobre, "####,###,###.00")
                TxtImpuesto.Text = Format((IGV) * (Monto_Sobre), "####,###,###.00")
                TxtTotal.Text = Format((1 + IGV) * (Monto_Sobre), "####,###,###.00")
            End If

            Dim SUB_TOTAL_GENERAL As Double = 0
            Dim SubTotal_Costo As Double = TxtSubTotal.Text
            If (1 - Val("") / 100) > 0 Then
                'hlamas 11-09-2015
                'SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SubTotal_Costo * (1 - Val("") / 100), "###,###,###.0000")) '01/09/2010 
                SUB_TOTAL_GENERAL = Format((1 + IGV) * SubTotal_Costo * (1 - Val("") / 100), "###,###,###.0000") '01/09/2010
            Else
                If (1 - Val("") / 100) = 0 Then
                    SUB_TOTAL_GENERAL = 0
                End If
            End If

            TxtSubTotal.Text = Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00")
            TxtImpuesto.Text = Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00")
            TxtTotal.Text = Format(SUB_TOTAL_GENERAL, "###,###,###.00")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return False
    End Function

    Dim isDescuento_ As Boolean
    Sub tarifarioEnMemoria()
        Try
            GrdDetalleVenta(3, 0).Value = tarifa_Peso
            GrdDetalleVenta(3, 1).Value = tarifa_Volumen
            GrdDetalleVenta(3, 2).Value = tarifa_Sobre
            GrdDetalleVenta(3, 3).Value = Monto_Base
            GrdDetalleVenta(4, 3).Value = Monto_Base
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '***FUNCION FNTECHO REDONDEAR MONTO***************************************
    Public Function fnTECHO(ByVal monto As String) As String
        Dim monto_total As String = monto
        Try
            Dim varMonto() As String = Split(monto_total, ".")

            If varMonto.Length > 1 Then
                If Val(varMonto(1).ToString) < 50 Then '12/03/2008 - Puedo modificarse acá poniendo igual 
                    monto_total = varMonto(0) & ".50"
                Else
                    Dim Entero As String() = Split(varMonto(0).ToString, ",")
                    Dim i As Integer = 0
                    monto_total = varMonto(0).ToString
                    If Entero.Length >= 1 Then
                        monto_total = ""
                    End If
                    For i = 0 To Entero.Length - 1
                        monto_total = monto_total & Entero(i).ToString
                    Next
                    'monto_total = Val(monto_total) + 1   -- 01/09/2010 
                    If Val(varMonto(1)) > 500 Then
                        monto_total = Val(monto_total) + 1
                    Else
                        monto_total = Val(monto_total) + 0.5
                    End If
                    ' monto_total = monto_total.ToString & ".00"
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        If monto Mod 0.5 = 0 Then
            Return monto
        Else
            Return monto_total
        End If
    End Function

    '***DEFINIENDO TIPO DE CARACTER A LAS CELDAS******************************
    Dim tipo_ As String
    Sub TipoCampos()
        Try
            'hlamas 29-10-2018
            'If ChkArticulos.Checked = True And CboTipo.SelectedValue = 1 Then '-------------> ARTICULOS
            If ChkArticulos.Checked = True Then '-------------> ARTICULOS
                If BCol_ = 2 Then tipo_ = "Int"
                If BCol_ = 3 Then tipo_ = "Float"
            ElseIf ChkArticulos.Checked = True And CboTipo.SelectedValue = 2 Then
                If BCol_ = 2 Then tipo_ = "Int"
                If BCol_ >= 3 Then tipo_ = "Float"
            End If

            If ChkM3.Checked = True Then '--------------------------------------------------> M3 (VOLUMETRICO)
                If BCol_ = 1 Then tipo_ = "Int"
                If BCol_ >= 2 Then tipo_ = "Float"
            End If

            If ChkM3.Checked = False And ChkArticulos.Checked = False Then '----------------> BULTOS
                If BCol_ = 1 Then tipo_ = "Int"
                If BCol_ = 2 Then tipo_ = "Float"
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '*******************VALIDACION PARA LAS CELDAS (SOLO NUMEROS)*************
    Private WithEvents celda As DataGridViewTextBoxEditingControl
    Dim GrdDocumentos As Boolean
    Dim GrdDetVenta As Boolean

    Private Sub GrdDocumentosCliente_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDocumentosCliente.CellEndEdit

    End Sub
    Private Sub GrdDocumentosCliente_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles GrdDocumentosCliente.EditingControlShowing
        GrdDocumentos = True
        GrdDetVenta = False
        celda = TryCast(e.Control, DataGridViewTextBoxEditingControl)
        If TypeOf e.Control Is TextBox Then '***CONVERTIR CARACTERES A MAYUSCULAS EN EL DATAGRID
            DirectCast(e.Control, TextBox).CharacterCasing = CharacterCasing.Upper
        End If
    End Sub

    Private Sub GrdDetalleVenta_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles GrdDetalleVenta.EditingControlShowing
        GrdDetVenta = True
        GrdDocumentos = False
        Me.TipoCampos()
        celda = TryCast(e.Control, DataGridViewTextBoxEditingControl)
    End Sub

    Private Sub celda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles celda.KeyPress
        If GrdDocumentos Then
            e.Handled = Me.NumeroDocu(e, celda)
        ElseIf GrdDetVenta Then
            e.Handled = Me.Numero(e, celda)
        End If
    End Sub

    Public Function Numero(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByRef Celda As TextBox) As Boolean
        Try
            If tipo_ = "Float" Then
                If UCase(e.KeyChar) Like "[!0-9.]" Then
                    If Not Asc(e.KeyChar) = Keys.Back Then
                        Return True
                    End If
                End If

                Dim c As Short = 0
                If UCase(e.KeyChar) Like "[.]" Then
                    If InStr(Celda.Text, ".") > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            ElseIf tipo_ = "Int" Then
                If UCase(e.KeyChar) Like "[!0-9]" Then
                    If Not Asc(e.KeyChar) = Keys.Back Then
                        Return True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function NumeroDocu(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByRef Celda As TextBox) As Boolean

        Try
            If Asc(e.KeyChar) = Keys.Back Then
                Return False
            End If

            If Celda.TextLength + 1 < 4 And Not UCase(e.KeyChar) Like "[-]" Then
                If UCase(e.KeyChar) Like "[ A-ZÑ0-9\b]" Then
                    Return False
                Else
                    Return True
                End If
            ElseIf Celda.TextLength + 1 = 4 And UCase(e.KeyChar) Like "[-]" Then
                Return False
            ElseIf Celda.TextLength + 1 > 4 And Not UCase(e.KeyChar) Like "[-]" Then
                If UCase(e.KeyChar) Like "[0-9-]" Then
                    Return False
                Else
                    Return True
                End If
            End If

            Dim c As Short = 0
            If UCase(e.KeyChar) Like "[-]" Then
                If InStr(Celda.Text, "-") > 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    '****************FORMATO SEPARADOS SIN MILES******************************
    Dim BCol_ As Integer, BRow_ As Integer
    Private Sub GrdDetalleVenta_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles GrdDetalleVenta.CellBeginEdit
        Try
            'hlamas 28-11-2013
            If TipoGrid_ = FormatoGrid.VOLUMETRICO AndAlso Not IsNumeric(GrdDetalleVenta("TIPO", e.RowIndex).Value) Then
                e.Cancel = True
            End If
            '--------------
            Me.TipoCampos()
            '--------------           
            Dim Formato_ As Double
            BCol_ = e.ColumnIndex
            BRow_ = e.RowIndex

            If ChkM3.Checked = False And ChkArticulos.Checked = False Then '----------> Bultos
                If BCol_ = 1 Or BCol_ = 2 Then
                    If Conversion.Val(GrdDetalleVenta(BCol_, BRow_).Value) = 0 Then
                        Return
                    Else
                        Formato_ = GrdDetalleVenta(BCol_, BRow_).Value
                    End If
                    '------
                    GrdDetalleVenta(BCol_, BRow_).Value = Formato_
                End If
            End If


            If ChkArticulos.Checked = True Then '-------------------------------------> Articulos
                If BCol_ = 2 Or BCol_ = 3 Then
                    If Conversion.Val(GrdDetalleVenta(BCol_, BRow_).Value) = 0 Then
                        Return
                    Else
                        Formato_ = GrdDetalleVenta(BCol_, BRow_).Value
                    End If
                    '------
                    GrdDetalleVenta(BCol_, BRow_).Value = Formato_
                End If
            End If

            If ChkM3.Checked = True Then '----------------------------------------------> M3
                If BCol_ >= 1 And BCol_ <= 5 Then
                    If Conversion.Val(GrdDetalleVenta(BCol_, BRow_).Value) = 0 Then
                        Return
                    Else
                        Formato_ = GrdDetalleVenta(BCol_, BRow_).Value
                    End If
                    '------
                    GrdDetalleVenta(BCol_, BRow_).Value = Formato_
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '***FORMATO MILES PARA LAS CELDAS [EJEMPLO (12,400.25)]*******************  
    Sub FormatoMiles()
        Try
            If tipo_ = "Float" Then '-- tipo decimales
                If Conversion.Val(GrdDetalleVenta(iCOL, iROW).Value) = 0 Then GrdDetalleVenta(iCOL, iROW).Value = "0.00" : Return
                GrdDetalleVenta(iCOL, iROW).Value = FormatNumber(GrdDetalleVenta(iCOL, iROW).Value, 2)
            ElseIf tipo_ = "Int" Then '--> tipo Entero
                If Conversion.Val(GrdDetalleVenta(iCOL, iROW).Value) = 0 Then GrdDetalleVenta(iCOL, iROW).Value = "" : Return
                GrdDetalleVenta(iCOL, iROW).Value = FormatNumber(GrdDetalleVenta(iCOL, iROW).Value, 0)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '***RESET VALORES DE LAS CELDAS*******************************************
    Sub ResetCalculo() '-> reseteando el calculo al cambiar el tipo de entrega 
        Try
            'If (ChkArticulos.Checked) Then
            '    'Camp1 = "Articulo" : camp2 = "Precio" : camp3 = "Cantidad"
            '    'camp4 = "M3" : camp5 = "Peso" : camp6 = "P.Total" : camp7 = "IDARTICULO"

            '    For i As Integer = 0 To GrdDetalleVenta.RowCount() - 1
            '        'GrdDetalleVenta("Articulo", i).Value = "" '------------> reset campo [Bulto]
            '        GrdDetalleVenta("Cantidad", i).Value = "0.00" '-> reset campo [Peso/Volumen]
            '        GrdDetalleVenta("Sub Neto", i).Value = "0.00" '-----> reset campo [Sub Neto]
            '        GrdDetalleVenta("Costo", i).Value = "0.00"
            '    Next

            'Else
            If ChkM3.Checked = False Then '-----------------------------> BULTO
                For i As Integer = 0 To GrdDetalleVenta.RowCount() - 1
                    GrdDetalleVenta("Bulto", i).Value = "" '------------> reset campo [Bulto]
                    GrdDetalleVenta("Peso/Volumen", i).Value = "0.00" '-> reset campo [Peso/Volumen]
                    GrdDetalleVenta("Sub Neto", i).Value = "0.00" '-----> reset campo [Sub Neto]
                    GrdDetalleVenta("Costo", i).Value = "0.00"
                Next
            ElseIf ChkM3.Checked = True Then '---------------------------> M3
                For i As Integer = 0 To GrdDetalleVenta.RowCount() - 1
                    GrdDetalleVenta("Bulto", i).Value = ""
                    GrdDetalleVenta("Altura", i).Value = "0.00"
                    GrdDetalleVenta("Ancho", i).Value = "0.00"
                    GrdDetalleVenta("Largo", i).Value = "0.00"
                    GrdDetalleVenta("Peso Kg", i).Value = "0.00"
                    GrdDetalleVenta("Sub Neto", i).Value = "0.00"
                Next
            End If

            If CboTipo.SelectedValue <> 1 Then
                TxtSubTotal.Text = "0.00"
                TxtImpuesto.Text = "0.00"
                TxtTotal.Text = "0.00"
            ElseIf CboTipo.SelectedValue = 1 Then
                Me.CondicionMontoMinimoPCE()
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub


    Dim bInicio As Boolean
    Dim RowEnter As Integer
    Dim ColEnter As Integer
    Private Sub GrdDetalleVenta_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDetalleVenta.RowEnter
        If TipoGrid_ = FormatoGrid.VOLUMETRICO Then
            RowEnter = e.RowIndex
            ColEnter = e.ColumnIndex
        End If
    End Sub

    '***CONTROL DEL KEYDOWN AL GRID*******************************************
    Private Sub GrdDetalleVenta_KeyDown(ByVal sender As System.Object, _
                                        ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdDetalleVenta.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If

            Dim index As Integer = CType(sender, DataGridView).CurrentRow.Index
            If TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                Dim UltimaFila As Integer = GrdDetalleVenta.Rows.Count() - 1
                If (Keys.Down = e.KeyCode Or Keys.Up = e.KeyCode Or Keys.Delete = e.KeyCode) And IsNumeric(GrdDetalleVenta("tipo", index).Value) Then
                    If bInicio Then Return
                    Dim Key As Integer = e.KeyValue
                    GenerarDataGridVolumetrico(GrdDetalleVenta, index, UltimaFila, tarifa_Peso, Key)
                    'hlamas 28-11-2013
                    iROW = 0 'RowEnter
                    Me.Calculo_M3()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


#End Region

#Region "SEGURO"
    Private Sub BtnCargAseg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCargAseg.Click
        Try
            If ChkArticulos.Checked = False Then
                Dim A As New FrmDocCliente

                A.sFecha = txtFechaGuia.Text
                A.bVentaGrabada = recuperando_datos_contado
                A.sDocCliente = sDocCliente
                Acceso.Asignar(A, Me.hnd)
                If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                    A.ShowDialog()
                    agregar_documentos_asegurados()
                Else
                    MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Dim iSub_Total_CA As Double = 0, iImpuesto_CA As Double = 0, iTotal_CA As Double = 0
    Dim bMontoMinimo As Boolean
    Dim iFilas As Integer
    Private Sub agregar_documentos_asegurados()
        Try
            Dim monto_carga_asegurada As Double = 0
            Dim iContador As Integer = 0

            es_carga_asegurada = False
            iSub_Total_CA = 0
            iImpuesto_CA = 0
            iTotal_CA = 0

            For k As Integer = 0 To GrdDocumentosCliente.Rows().Count - 1
                GrdDocumentosCliente(3, k).Value = ""
            Next

            For i As Integer = 0 To 18 Step 1
                If Not (objComprobanteAsegurada(iContador).NRO_SERIE Is Nothing) Then
                    If GrdDocumentosCliente.Rows.Count - 1 = i Then
                        GrdDocumentosCliente.Rows.Add()
                    End If
                End If
                iContador += 1
            Next

            For i As Integer = 0 To 18 Step 1
                If Not ((objComprobanteAsegurada(i).NRO_SERIE Is Nothing) And (objComprobanteAsegurada(i + 1).NRO_SERIE Is Nothing)) Then
                    GrdDocumentosCliente.Rows(i).Cells(3).Value = objComprobanteAsegurada(i).NRO_SERIE + "-" + objComprobanteAsegurada(i).NRO_DOCU
                    iFilas += 1
                    es_carga_asegurada = True
                ElseIf Not (objComprobanteAsegurada(i).NRO_SERIE Is Nothing) Then
                    Dim row0 As String() = {"", _
                    "", _
                    objComprobanteAsegurada(i).NRO_SERIE + "-" + objComprobanteAsegurada(i).NRO_DOCU, _
                    "-"}
                    GrdDocumentosCliente.Rows().Add(row0)
                    es_carga_asegurada = True
                End If
                If objComprobanteAsegurada(i).TIPO = 1 Or objComprobanteAsegurada(i).TIPO = 0 Then
                    monto_carga_asegurada = FormatNumber(monto_carga_asegurada + (Val(objComprobanteAsegurada(i).MONTO_SUB_TOTAL) * Val(objComprobanteAsegurada(i).MONTO_TIPO_CAMBIO)) * Val(objComprobanteAsegurada(i).PORCEN) / 100, 2)
                ElseIf objComprobanteAsegurada(i).TIPO = 2 Then
                    Dim iSub As Double = objComprobanteAsegurada(i).PORCEN * Val(objComprobanteAsegurada(i).MONTO_TIPO_CAMBIO) / (1 + dtoUSUARIOS.vImpuesto)
                    monto_carga_asegurada = FormatNumber(monto_carga_asegurada + iSub, 2)
                End If
            Next

            Dim intFila As Integer
            If es_carga_asegurada = True Then
                If ChkM3.Checked = False Then
                    ObtieneMontosAsegurados(iSub_Total_CA, iImpuesto_CA, iTotal_CA)
                    If iTotal_CA > 0 Then
                        'hlamas 21-11-2013
                        'If GrdDetalleVenta.Rows.Count < 5 Then
                        intFila = BuscarItemVenta("SEGURO", GrdDetalleVenta)
                        If intFila = 0 Then
                            GrdDetalleVenta.Rows.Add()
                            intFila = GrdDetalleVenta.Rows.Count - 1
                        End If
                        'End If
                        'hlamas 21-11-2013
                        GrdDetalleVenta(0, intFila).Value = "CARGA SEGURO"
                        GrdDetalleVenta(2, intFila).Value = "0.00"
                        GrdDetalleVenta(3, intFila).Value = "0.00"
                        If bTarifarioGeneral And bContado Then
                            GrdDetalleVenta(4, intFila).Value = FormatNumber(iTotal_CA, 2)
                        Else
                            GrdDetalleVenta(4, intFila).Value = FormatNumber(iSub_Total_CA, 2)
                        End If
                    End If
                    'Me.Timer2.Start()
                ElseIf ChkM3.Checked = True Then
                    ObtieneMontosAsegurados(iSub_Total_CA, iImpuesto_CA, iTotal_CA)
                    If iTotal_CA > 0 Then
                        'If GrdDetalleVenta.Rows.Count < 2 Then
                        '    GrdDetalleVenta.Rows.Add()
                        '    GrdDetalleVenta.Rows(1).ReadOnly = True
                        'End If
                        intFila = BuscarItemVenta("SEGURO", GrdDetalleVenta)
                        If intFila = 0 Then
                            GrdDetalleVenta.Rows.Add()
                            intFila = GrdDetalleVenta.Rows.Count - 1
                        End If
                        GrdDetalleVenta(0, intFila).Value = "CARGA SEGURO"
                        GrdDetalleVenta(2, intFila).Value = "0.00"
                        GrdDetalleVenta(3, intFila).Value = "0.00"
                        GrdDetalleVenta(4, intFila).Value = "0.00"
                        GrdDetalleVenta(5, intFila).Value = "0.00"
                        GrdDetalleVenta(6, intFila).Value = "0.00"
                        If bTarifarioGeneral And bContado Then
                            GrdDetalleVenta(7, intFila).Value = FormatNumber(iTotal_CA, 2)
                        Else
                            GrdDetalleVenta(7, intFila).Value = FormatNumber(iSub_Total_CA, 2)
                        End If
                    End If
                    'Me.Timer2.Start()
                End If
            Else
                If ChkM3.Checked = False Then
                    intFila = BuscarItemVenta("SEGURO", GrdDetalleVenta)
                    'If GrdDetalleVenta.Rows.Count = 5 Then
                    If intFila > 0 Then
                        GrdDetalleVenta.Rows.RemoveAt(intFila)
                    End If
                ElseIf ChkM3.Checked = True Then
                    intFila = BuscarItemVenta("SEGURO", GrdDetalleVenta)
                    If intFila > 0 Then
                        GrdDetalleVenta.Rows.RemoveAt(intFila)
                    End If
                    'If GrdDetalleVenta.Rows.Count = 2 Then
                    'GrdDetalleVenta.Rows.RemoveAt(1)
                    'End If
            End If
            'Me.Timer2.Stop()
            End If
            If recuperando_datos_contado = False Then
                'hlamas 28-11-2013
                iROW = 0
                fnTotalPago()
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub ObtieneMontosAsegurados(ByRef s As Double, ByRef i As Double, ByRef t As Double)
        Try
            s = 0
            i = 0
            t = 0
            For Each obj As ClsLbTepsa.dtoCargaAsegurada.ComprobanteAsegurada In objComprobanteAsegurada
                If Not obj.NRO_DOCU Is Nothing Then
                    If obj.TIPO = 1 Or obj.TIPO = 0 Then
                        s += obj.MONTO_SUB_TOTAL * obj.MONTO_TIPO_CAMBIO * obj.PORCEN / 100
                        i += obj.MONTO_IMPUESTO * obj.MONTO_TIPO_CAMBIO * obj.PORCEN / 100
                        t += obj.TOTAL_COSTO * obj.MONTO_TIPO_CAMBIO * obj.PORCEN / 100
                    Else
                        s += obj.PORCEN / (1 + dtoUSUARIOS.iIGV / 100)
                        Dim iSub As Double = obj.PORCEN / (1 + dtoUSUARIOS.iIGV / 100)
                        i += iSub * (dtoUSUARIOS.iIGV / 100)
                        t += obj.PORCEN
                    End If
                End If
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region

#Region "BTN NUEVO"


    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Try
            Me.Cursor = Cursors.AppStarting
            If CboTipo.SelectedValue = 2 Then
                Me.CboSubCuenta.DataSource = Nothing
            End If
            Me.FNNUEVO()

            'hlamas 12-02-2014
            LimpiarPromocion()

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function FNNUEVO() As Boolean
        Try
            bDescuento = False
            bTieneLineaCredito = False
            sDocCliente = ""
            iOficinaDestino = 0
            TxtCiudadDestino.Text = ""
            Me.CboTipoEntrega.SelectedValue = 0

            'hlamas 24-02-2014
            Me.CboTipoEntrega.Enabled = True
            Me.TxtCiudadDestino.Enabled = True
            Me.CboDireccion2.Enabled = True

            RemoveHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
            TxtNroDocCliente.Text = ""
            AddHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
            Me.LimpiarDatosGeneral()
            TipoGrid_ = FormatoGrid.BULTO
            Me.DiseñaGrdDetalleVenta()
            Me.FormatoGrdDetalleVenta()
            ChkArticulos.Enabled = False
            ChkArticulos.Checked = False
            ChkM3.Checked = False
            objComprobanteAsegurada = Nothing
            ReDim objComprobanteAsegurada(19)
            '****carga asegurada***********
            es_carga_asegurada = False
            iTotal_CA = 0
            '******************************
            Me.CboSubCuenta.DataSource = Nothing
            Me.CboAgenciaDest.DataSource = Nothing
            If CboTipo.SelectedValue = 1 Then
                CboProducto.SelectedIndex = 0
            ElseIf CboTipo.SelectedValue = 2 Then
                CboProducto.SelectedIndex = -1
            End If

            'CboFormaPago.SelectedIndex = 0
            Me.TxtCiudadDestino.Focus()
            '**********
            bClienteModificado = False
            bDireccionModificada = False

            bRemitenteModificado = False
            bContactoModificado = False

            bConsignadoModificado = False
            bDirecConsigMod = False

            bConsignadoNuevo = True
            bClienteNuevo = True
            'limpiando los codigos
            iID_Persona = 0
            idRemitente = 0
            idcontacto = 0
            iIDConsignado = 0

            sNombresCli = "" : sApCli = "" : sAmCli = "" : sTelfCliente = "" : sRazonSocialCliente = ""
            RbtDocumento3.Checked = True
            RbtDocumento.Checked = True
            Me.LimpiarCliente()
            Me.LimpiarConsignado()

            'hlamas 22-03-2016
            'ChkCargo.Checked = False
            'hlamas 18-03-2016
            ControlaCargo(False)
            MostrarTipoFacturacion(0)

            ChkSobres.Checked = False
            txtCantidadSobres.Text = ""
            txtTotalSobre.Text = ""
            TxtMontoBase.Text = ""
            '**********  
            '02092011
            strNroGuias_Remision = ""
            limpiar_documentos_cliente()

            sTelefonoConsig = ""
            sTelfCliente = ""

            ChkCliente.Checked = False
            ChkCliente1.Checked = False
            ChkCliente2.Checked = False

            'Limpia variables de dirección origen
            ObjVentaCargaContado.id_DepartamentoCli = 0
            ObjVentaCargaContado.id_ProvinciaCli = 0
            ObjVentaCargaContado.id_DistritoCli = 0
            ObjVentaCargaContado.id_viaCli = 0
            ObjVentaCargaContado.viaCli = ""
            ObjVentaCargaContado.NumeroCli = ""
            ObjVentaCargaContado.manzanaCli = ""
            ObjVentaCargaContado.loteCli = ""
            ObjVentaCargaContado.id_nivelCli = 0
            ObjVentaCargaContado.nivelCli = ""
            ObjVentaCargaContado.id_zonaCli = 0
            ObjVentaCargaContado.zonaCli = ""
            ObjVentaCargaContado.id_clasificacionCli = 0
            ObjVentaCargaContado.clasificacionCli = ""
            dtDireccion = Nothing

            'Limpia variables de dirección destino
            Me.CboDireccion2.DataSource = Nothing
            Me.CboDireccion2.Items.Clear()
            Me.CboDireccion2.Items.Add("AGENCIA")
            Me.CboDireccion2.SelectedIndex = 0
            iDepartamentoConsig = 0
            iProvinciaConsig = 0
            iDistritoConsig = 0
            IDviaConsig = 0
            ViaConsig = ""
            NroConsig = ""
            ManzanaConsig = ""
            loteConsig = ""
            id_NivelConsig = 0
            NivelConsig = ""
            id_ZonaConsig = 0
            ZonaConsig = ""
            id_ClasificacionConsig = 0
            ClasificacionConsig = ""
            TxtReferencia.Text = ""
            sReferencia = ""
            dtDireccion2 = Nothing


            TxtSubTotal.Text = 0
            TxtImpuesto.Text = 0
            TxtTotal.Text = 0
            CboProducto.SelectedIndex = 0
            BtnCargAseg.Enabled = False

            '===Agregado x NConsignado=============
            Me.GrdNConsignado.Rows.Clear()
            Me.LimpiarNConsignados()
            '======================================


            '-->10/09/2013 - jabanto
            '-->Oculta los campos DT(Docuemento de transporte)
            lbldt.Visible = False
            txtdt.Visible = False
            Me.dtpFechaRecojo.Visible = False
            Me.dtpFechaRecojo.Checked = False
            TxtTelfCliente.Size = New Size(329, 20)
            txtdt.Clear()
            'hlamas 23-09-2013
            Me.ControlaSubcuentaOrigen(False)

            Me.CboTipoTarifa.SelectedIndex = 1

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
#End Region

    '=================FUNCIONES===
#Region "Keypress"
    Private Sub TxtNroDocConsignado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not Me.ValidaNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCantSobres_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidadSobres.KeyPress
        If Not Me.ValidaNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
#End Region

#Region "FUNCIONES LIMPIAR"

    Sub LimpiarDatosGeneral()
        Me.TxtCliente.Text = ""
        Me.TxtConsignado.Text = ""
        '***Comentado x NConsignado*****
        'Me.TxtNombConsignado.Text = ""
        Me.TxtBoleto.Text = ""
        Me.TxtCiudadDestino.Enabled = True

        'hlamas 24-02-2014
        Me.CboTipoEntrega.Enabled = True
        Me.CboDireccion2.Enabled = True

        Me.TxtCiudadDestino.ReadOnly = False

        'hlamas 26-08-2015
        strObservacionCargo = ""

        Me.LimpiarDatosCliente()
    End Sub

    Sub LimpiarConsignado()
        '*****Comentado x NConsignado*******
        'Me.TxtNroDocConsignado.Text = ""
        'Me.TxtNombConsignado.Text = ""
        'Me.TxtTelfConsignado.Text = ""

        '===Agregado x NConsignado==========
        GrdNConsignado.Rows.Clear()
        '===================================

        Me.ChkCliente2.Checked = False
        bConsignadoNuevo = True
    End Sub

    Sub LimpiarCliente()
        If Not CboSubCuenta.Focused Then
            'TxtNroDocCliente_TextChanged
            RemoveHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
            Me.TxtNroDocCliente.Text = ""
            AddHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
            Me.TxtNomCliente.Text = ""
        End If

        Me.CboDireccion.DataSource = Nothing
        Me.CboDireccion.Items.Clear()
        Me.CboDireccion.Items.Add(" (SELECCIONE)")
        Me.CboDireccion.SelectedIndex = 0

        Me.TxtNumDocRemitente.Text = ""
        Me.TxtNroDocContacto.Text = ""
        Me.TxtTelfCliente.Text = ""

        Me.CboRemitente.DataSource = Nothing
        Me.CboRemitente.Items.Clear()
        Me.CboRemitente.Items.Add(" (SELECCIONE)")
        Me.CboRemitente.SelectedIndex = 0

        Me.CboContacto.DataSource = Nothing
        Me.CboContacto.Items.Clear()
        Me.CboContacto.Items.Add(" (SELECCIONE)")
        Me.CboContacto.SelectedIndex = 0
    End Sub

    Sub LimpiarDatosCliente()
        '*******Items carga Asegurada**********
        Me.RemoveItemsCargAseg()
        '*******Datos Cliente******************
        Me.LimpiarCliente()
        '**************************************
        'LblTipoComprobante.Text = "BOLETA"
        TipoComprobante = 2
        If CboProducto.SelectedValue <> 6 Then
            LblPasajero.Visible = False
        End If
        'CboContacto.Enabled = False

        TxtDescuento.Text = ""
        GrpDescuento.Enabled = True
        RemoveHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged
        If ChkArticulos.Checked = True Then
            ChkSobres.Visible = False
            txtCantidadSobres.Visible = False
            TxtMontoBase.Visible = False
            txtTotalSobre.Visible = False
            LblMontoBase.Visible = False
            TipoGrid_ = FormatoGrid.BULTO
            Me.DiseñaGrdDetalleVenta()
            FormatoGrdDetalleVenta()
        Else
            If (CboTipo.SelectedValue = ID_TIPO_CREDITO) Then Me.ResetCalculo()
        End If

        ChkArticulos.Checked = False : ChkArticulos.Enabled = False
        ChkM3.Checked = False

        If CboProducto.SelectedValue <> 6 Then
            TipoGrid_ = FormatoGrid.BULTO
            Me.DiseñaGrdDetalleVenta()
            FormatoGrdDetalleVenta()
        End If

        AddHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged

        If GrdDetalleVenta.Rows.Count = 5 Then
            GrdDetalleVenta.Rows.RemoveAt(4)
        End If

        '01092011
        If Not Me.CboSubCuenta.Focused Then
            If CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                Me.CboDireccion2.DataSource = Nothing
                Me.CboDireccion2.Items.Clear()
                Me.CboDireccion2.Items.Add(" (SELECCIONE)")
                Me.CboDireccion2.SelectedIndex = 0
            ElseIf CboTipoEntrega.SelectedValue = TipoEntrega.Agencia Then
                Me.CboDireccion2.DataSource = Nothing
                Me.CboDireccion2.Items.Clear()
                Me.CboDireccion2.Items.Add("AGENCIA")
                Me.CboDireccion2.SelectedIndex = 0
            Else
                Me.CboDireccion2.DataSource = Nothing
                Me.CboDireccion2.Items.Clear()
                Me.CboDireccion2.SelectedIndex = -1
            End If
        End If

        EliminarItemVenta("SEGURO", GrdDetalleVenta)
        EliminarItemVenta("ENTREGA", GrdDetalleVenta)
    End Sub
    Sub LimpiaDatosCliente()
        '*******Items carga Asegurada**********
        Me.RemoveItemsCargAseg()
        'LblTipoComprobante.Text = "BOLETA"
        TipoComprobante = 2
        If CboProducto.SelectedValue <> 6 Then
            LblPasajero.Visible = False
        End If
        'CboContacto.Enabled = False

        TxtDescuento.Text = ""
        GrpDescuento.Enabled = True
        RemoveHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged
        If ChkArticulos.Checked = True Then
            ChkSobres.Visible = False
            txtCantidadSobres.Visible = False
            TxtMontoBase.Visible = False
            txtTotalSobre.Visible = False
            LblMontoBase.Visible = False
            TipoGrid_ = FormatoGrid.BULTO
            Me.DiseñaGrdDetalleVenta()
            FormatoGrdDetalleVenta()
        Else
            If (CboTipo.SelectedValue = ID_TIPO_CREDITO) Then Me.ResetCalculo()
        End If

        ChkArticulos.Checked = False : ChkArticulos.Enabled = False
        ChkM3.Checked = False

        'If CboProducto.SelectedValue <> 6 Then
        If CboProducto.SelectedValue <> 6 Then
            TipoGrid_ = FormatoGrid.BULTO
            Me.DiseñaGrdDetalleVenta()
            FormatoGrdDetalleVenta()
        End If

        AddHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged

        If GrdDetalleVenta.Rows.Count = 5 Then
            GrdDetalleVenta.Rows.RemoveAt(4)
        End If

        '01092011
        If Not Me.CboSubCuenta.Focused Then
            If CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                Me.CboDireccion2.DataSource = Nothing
                Me.CboDireccion2.Items.Clear()
                Me.CboDireccion2.Items.Add(" (SELECCIONE)")
                Me.CboDireccion2.SelectedIndex = 0
            ElseIf CboTipoEntrega.SelectedValue = TipoEntrega.Agencia Then
                Me.CboDireccion2.DataSource = Nothing
                Me.CboDireccion2.Items.Clear()
                Me.CboDireccion2.Items.Add("AGENCIA")
                Me.CboDireccion2.SelectedIndex = 0
            Else
                Me.CboDireccion2.DataSource = Nothing
                Me.CboDireccion2.Items.Clear()
                Me.CboDireccion2.SelectedIndex = -1
            End If
        End If

        '-->10/09/2013 - jabanto
        '-->Oculta los campos DT(Docuemento de transporte)
        'lbldt.Visible = False
        'txtdt.Visible = False
        'TxtTelfCliente.Size = New Size(329, 20)
        'txtdt.Clear()

        'If Not IsNothing(CboSubCuentaOrigen.DataSource) Then
        '    CboSubCuentaOrigen.SelectedValue = Cls_Constantes_LN.ID_CENTRO_COSTO_GENERICO
        'End If

    End Sub
    Dim es_carga_asegurada As Boolean
    Sub RemoveItemsCargAseg()
        'If es_carga_asegurada Then
        objComprobanteAsegurada = Nothing
        ReDim objComprobanteAsegurada(19)
        es_carga_asegurada = False
        'End If
    End Sub

#End Region

#Region "Funciones Validaciones"

    'Funcion Valida Solo [Numero]
    Public Function ValidaNumero(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[0-9\b]") '("^\d+$")  

        If re.IsMatch(txtStr.ToString()) Then
            ValidaNumero = True
        Else
            ValidaNumero = False
        End If
    End Function

    'Funcion Valida Solo [Texto]
    Public Function ValidaTexto(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[ A-ZñÑa-z\b]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            ValidaTexto = True
        Else
            ValidaTexto = False
        End If
    End Function

    'Funcion valida [Letra y Numero]
    Public Function ValidaNroTexto(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[ A-ZñÑa-z0-9\b]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            ValidaNroTexto = True
        Else
            ValidaNroTexto = False
        End If
    End Function

    'Funcion Control de Teclas
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean = True
        Dim flat As Boolean = True
        Try
            Dim var As Integer = msg.WParam.ToInt32
            If msg.WParam.ToInt32 = Keys.Enter And Not BtnGraba.Focused Then
                If CboTipo.SelectedValue <> 2 AndAlso Me.TxtCliente.Focused AndAlso Me.TxtCliente.Text.Trim.Length > 0 Then
                    Buscar()
                ElseIf Me.txtNroNroGuia.Focused AndAlso Me.txtNroNroGuia.Text.Trim.Length > 0 Then
                    'hlamas 22-02-2019
                    'If ValidarCodigoEAN13(Me.txtNroNroGuia.Text.Trim) Then
                    Me.FnConsultar()
                    'Else
                    'MessageBox.Show("Ingrese un Numero de Guía Valido", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    'txtNroNroGuia.Text = ""
                    'txtNroNroGuia.Focus()
                    'End If
                ElseIf CboTipo.SelectedValue = 2 AndAlso Me.TxtCliente.Focused AndAlso Me.TxtCliente.Text.Trim.Length > 0 Then
                    BuscarClienteCredito()

                    ' Comentado por diego Zegarra, todos los montos de retorno son  5.93 

                    ' fncValidarEnvioRetorno_Destino_CentroCosto()

                ElseIf Me.TxtConsignado.Focused AndAlso Me.TxtConsignado.Text.Trim.Length > 0 Then 'AndAlso idUnidadAgencias >= 0 Then
                    BuscarConsignado()

                ElseIf Me.CboDireccion.Focused Then
                    If Me.CboDireccion.Items.Count > 0 And Not (Me.CboDireccion.SelectedValue Is Nothing) Then
                        Dim intValor As Integer = Me.CboDireccion.SelectedValue
                        Me.CboDireccion.SelectedIndex = 0
                        Me.CboDireccion.SelectedValue = intValor
                    End If
                    If Me.CboRemitente.Enabled AndAlso Me.CboRemitente.Items.Count > 1 AndAlso Me.CboRemitente.SelectedIndex = 0 AndAlso Me.CboDireccion.SelectedIndex > 0 Then
                        Me.DespliegaRemitente()
                    ElseIf Me.CboDireccion.DroppedDown = False Then
                        SendKeys.Send("{Tab}")
                    End If
                ElseIf Me.CboDireccion2.Focused Then
                    If Me.CboDireccion2.Items.Count > 0 And Not (Me.CboDireccion2.SelectedValue Is Nothing) Then
                        Dim intValor As Integer = Me.CboDireccion2.SelectedValue
                        Me.CboDireccion2.SelectedIndex = 0
                        Me.CboDireccion2.SelectedValue = intValor
                    End If
                    If Me.CboDireccion2.DroppedDown = False Then
                        SendKeys.Send("{Tab}")
                    End If
                ElseIf Me.CboRemitente.Focused Then
                    If Me.CboRemitente.Items.Count > 0 And Not (Me.CboRemitente.SelectedValue Is Nothing) Then
                        Dim intValor As Integer = Me.CboRemitente.SelectedValue
                        Me.CboRemitente.SelectedIndex = 0
                        Me.CboRemitente.SelectedValue = intValor
                    End If

                    If Me.CboContacto.Enabled AndAlso Me.CboContacto.Items.Count > 1 AndAlso Me.CboContacto.SelectedIndex = 0 AndAlso Me.CboRemitente.SelectedIndex > 0 Then
                        Me.DespliegaContacto()
                    ElseIf CboRemitente.DroppedDown = False Then
                        SendKeys.Send("{Tab}")
                    End If
                ElseIf Me.CboContacto.Focused Then
                    If Me.CboContacto.Items.Count > 0 And Not (Me.CboContacto.SelectedValue Is Nothing) Then
                        Dim intValor As Integer = Me.CboContacto.SelectedValue
                        Me.CboContacto.SelectedIndex = 0
                        Me.CboContacto.SelectedValue = intValor
                    End If
                    If CboContacto.DroppedDown = False Then
                        SendKeys.Send("{Tab}")
                    End If
                ElseIf Me.CboTipoEntrega.Focused Then
                    Me.RbtDocumento.Focus()

                ElseIf Me.TxtCliente.Focused Then
                    If Me.CboTipo.SelectedValue = 2 Then
                        Me.CboSubCuenta.Focus()
                    Else
                        SendKeys.Send("{Tab}")
                    End If
                ElseIf Me.CboSubCuenta.Focused Then
                    If Me.CboSubCuenta.Items.Count > 0 Then
                        If Me.CboSubCuenta.SelectedIndex > 0 Then
                            CboSubCuenta.SelectedValue = 999
                            CboDireccion.DroppedDown = False
                            CboDireccion2.DroppedDown = False
                        End If
                    End If
                    If Me.CboTipo.SelectedValue = 2 Then
                        Me.CboDireccion.Focus()
                    End If
                Else
                    SendKeys.Send("{Tab}")
                End If
            ElseIf msg.WParam.ToInt32 = Keys.F5 Then
                Dim sender As Object
                Dim e As EventArgs
                Me.BtnGraba_Click(sender, e)
            ElseIf GrdNConsignado.Focused And msg.WParam.ToInt32 = Keys.Delete Then
                Me.EliminarItem()
            Else
                flat = MyBase.ProcessCmdKey(msg, KeyData)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return flat
    End Function

    Function ValidarCodigoEAN13(strNroGuia As String) As Boolean
        Dim Longitud As Integer = 0
        Dim DigitoControl As Integer = 0
        Dim Pares As Integer = 0
        Dim Impares As Integer = 0
        Dim Resultado As Integer = 0
        Try
            Longitud = Len(strNroGuia)
            If Longitud <= 13 Then
                strNroGuia = strNroGuia.PadLeft(13, "0")
                Longitud = Len(strNroGuia)
            Else
                Return False
            End If
            DigitoControl = strNroGuia.Substring(Longitud - 1, 1)
            strNroGuia = strNroGuia.Substring(0, Longitud - 1)

            For i As Integer = 1 To Len(strNroGuia)
                If i Mod 2 = 0 Then
                    Pares = Pares + Convert.ToInt32(strNroGuia.Substring(i - 1, 1))
                Else
                    Impares = Impares + Convert.ToInt32(strNroGuia.Substring(i - 1, 1))
                End If
            Next

            Pares = Pares * 3
            Resultado = Pares + Impares
            Resultado = Resultado Mod 10

            Resultado = 10 - Resultado

            If Resultado = 10 Then
                Resultado = 0
            End If

            If Resultado = DigitoControl Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

#End Region



#Region "IMPRESIONES"

    Dim p_agencia, v_iDestino, v_iCredito, v_iDomicilio, v_iAgencia, p_domicilio, p_contado, p_destino, p_credito As String
    Public Function ImprimirGuiaEnvio() As Boolean
        Dim iSubTotal As Double, iImpuesto As Double, iTotal As Double
        Dim obj As New Imprimir
        Try
            ObjRptGuiaEnvio.p_Hora_Guia = fnGetHora()
            'Dim objImpresora As New dtoVentaCargaContado
            If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Then
                ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3
            End If

            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim dt As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 3)
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0
            Dim flag As Boolean
            If dt.Rows.Count = 0 Then
                flag = False
            Else
                If IsDBNull(dt.Rows(0).Item("impresora")) Then
                    flag = False
                Else
                    sImpresora = dt.Rows(0).Item("impresora")
                    iTamaño = dt.Rows(0).Item("tamano")
                    iSuperior = dt.Rows(0).Item("superior")
                    Iizquierda = dt.Rows(0).Item("izquierda")
                    flag = True
                End If
            End If

            Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
            Dim iLong As Integer = IIf(iTamaño = 0, 22, iTamaño)

            y = iLong * pagina + 2
            i += 1

            If flag Then
                '21-10-2011 
                Dim sConsignado As String = ObjRptGuiaEnvio.P_NOMBRES_DESTI.Trim.Replace(";", ",")
                sConsignado = sConsignado.Substring(0, sConsignado.Trim.Length - 1)
                'ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI = ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI.Replace(";", ",")
                ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI = ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI.Replace(";", " ")

                'EliminarCaracter(ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI, ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI.Length)
                'EliminarCaracter(ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI, ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI.Length)
                '========================================================

                obj.Inicializar()
                obj.Impresora = sImpresora
                obj.Superior = iSuperior
                obj.Izquierda = Iizquierda

                If es_carga_asegurada Then
                    obj.EscribirLinea(y, 22, ObjRptGuiaEnvio.p_NroGUIA & v_ca)
                Else
                    obj.EscribirLinea(y, 22, ObjRptGuiaEnvio.p_NroGUIA)
                End If

                obj.EscribirLinea(y + 0, 60, CboProducto.Text) 'cambio 
                obj.EscribirLinea(y, 82, ObjRptGuiaEnvio.p_codigo_iata_ori)
                obj.EscribirLinea(y, 92, ObjRptGuiaEnvio.p_codigo_iata_desti)
                obj.EscribirLinea(y + 2, 0, ObjRptGuiaEnvio.p_ruc)
                obj.EscribirLinea(y + 5, 0, ObjRptGuiaEnvio.P_REMITENTE)

                If ObjRptGuiaEnvio.P_DIRECCION_REMI.ToString.Length > 40 Then
                    obj.EscribirLinea(y + 3, 0, ObjRptGuiaEnvio.P_DIRECCION_REMI.ToString.Substring(0, 41))
                    obj.EscribirLinea(y + 4, 0, ObjRptGuiaEnvio.P_DIRECCION_REMI.ToString.Substring(41))
                Else
                    If Trim(ObjRptGuiaEnvio.P_DIRECCION_REMI) <> "(SELECCIONE)" Then
                        obj.EscribirLinea(y + 6, 0, ObjRptGuiaEnvio.P_DIRECCION_REMI)
                    End If
                End If
                    obj.EscribirLinea(y + 5, 59, sConsignado)
                    obj.EscribirLinea(y + 6, 59, ObjRptGuiaEnvio.P_DIRECCION_DESTI)

                    obj.EscribirLinea(y + 2, 33, p_domicilio)
                    obj.EscribirLinea(y + 2, 43, p_agencia)
                    obj.EscribirLinea(y + 2, 54, p_contado)
                    obj.EscribirLinea(y + 2, 64, p_destino)
                    obj.EscribirLinea(y + 2, 76, p_credito)

                    'obj.EscribirLinea(ObjRptGuiaEnvio.P_CARGO)
                    obj.EscribirLinea(y + 9, 0, ObjRptGuiaEnvio.p_contacto)
                    'obj.EscribirLinea(y + 9, 0, "FACTURAR A: " & ObjRptGuiaEnvio.P_NOMBRES_DESTI)

                    obj.EscribirLinea(y + 8, 29, ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_ORI)
                obj.EscribirLinea(y + 8, 59, Me.CboAgenciaDest.Text)
                    obj.EscribirLinea(y + 8, 84, ObjRptGuiaEnvio.P_NROCOMUNICACION_CONTACTO_DESTI)

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

                    'obj.EscribirLinea(y + 17, 26, Format(CDate(ObjRptGuiaEnvio.P_FECHA_GUIA), "dd     MM      yy"))
                    obj.EscribirLinea(y + 17, 26, Format(CDate(FechaServidor.ToString.Substring(0, 10)), "dd     MM      yy"))

                    obj.EscribirLinea(y + 13, 26, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_BULTOS), 2))
                    obj.EscribirLinea(y + 13, 34, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_PESO), 2))
                obj.EscribirLinea(y + 13, 42, FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_VOLUMEN), 2))
                obj.EscribirLinea(y + 13, 55, FechaServidor.ToString.Substring(0, 10))
                    obj.EscribirLinea(y + 13, 69, ObjRptGuiaEnvio.p_Hora_Guia)

                    If ObjRptGuiaEnvio.P_TOTAL_SOBRES > 0 Then
                        obj.EscribirLinea(y + 14, 57, "Nº SOBRES " & ObjRptGuiaEnvio.P_TOTAL_SOBRES)
                    End If
                    obj.EscribirLinea(y + 13, 10, "TOTAL A PAGAR S/. " & FormatNumber(CDbl(ObjRptGuiaEnvio.P_TOTAL_COSTO), 2))


                    '******************************
                obj.Comprimido = True
                obj.Tamaño = iLong
                obj.Imprimir()
                obj.Finalizar() 'axl

                    '******************************
                'obj.Comprimido = True
                'obj.Preliminar = True
                'obj.Tamaño = iLong
                'obj.Imprimir()
                'obj.Finalizar()

                'Dim frm As New FrmPreview
                'frm.Tamaño = iLong
                'frm.Documento = 1
                'frm.Text = "GE"
                'frm.ShowDialog()

            End If

        Catch ex As Exception
            obj.Finalizar()
            Throw New Exception(ex.Message)
        End Try
        Return False
    End Function

    Public Function fnImprimirEtiquetas() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()
            Dim strAgenciaDestino As String = dtoVentaCargaContado.AgenciaAbreviado(ObjVentaCargaContado.v_IDAGENCIAS_DESTINO)

            ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
            ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            ObjCODIGOBARRA.Cantidad = ObjVentaCargaContado.v_CANTIDAD_ETIQUETAS

            'Dim I As Int16 = 1
            Dim i As Int16 = 0
            'Dim j As Int16 = 1
            Dim j As Int16
            'If bRango Then
            '    j = 1
            'Else
            '    j = correlativo_inicial
            '    'Mod 21/08/2009 
            '    If j = 0 Then j = 1
            'End If
            '''''''''''''''''
            If iRango = 1 Then
                j = 1
            ElseIf iRango = 2 Then
                j = correlativo_inicial
            Else
                j = 1
            End If
            '''''''''''''''
            'hlamas 26-08-2015
            'agregar CARGO para envios con devolucion de cargo
            Dim strCargo As String, strFecha As String
            'hlamas 22-03-2015
            'strCargo = IIf(Me.ChkCargo.Checked, "CARGO", "")
            strCargo = IIf(Me.rbtCargoSi.Checked, "CARGO", "")
            Dim strTipo As String = ObtieneTipoComprobante(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE)
            Dim strAgeDom As String
            Dim strProducto As String = ObtieneProducto(Me.CboProducto.SelectedValue)
            While i <= ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows.Count - 1
                strAgeDom = ObjCODIGOBARRA.AGEDOM & "  " & strTipo
                ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows(i)(0).ToString
                'While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
                'ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(0).Value
                prn.EscribeLinea("^XA")
                prn.EscribeLinea("^PW400")
                prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD " & ObjCODIGOBARRA.NroDOC & "          " & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & strAgeDom & "^FS")
                prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.clinte & "^FS")
                prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & ObjCODIGOBARRA.CodigoBarra & "^FS")
                prn.EscribeLinea("^FT17,141^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
                prn.EscribeLinea("^FT96,142^A0N,39,45^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")
                'hlamas 26-08-2015
                'prn.EscribeLinea("^FT305,188^AAN,18,10^FH\^FDTEPSAC^FS")
                'prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & ObjCODIGOBARRA.Fecha & "^FS")

                strProducto = strProducto & "  " & strAgenciaDestino
                strProducto = strProducto.Trim
                prn.EscribeLinea("^FT21,165^AAN,18,10^FH\^FD" & strProducto & "^FS")

                strFecha = ObjCODIGOBARRA.Fecha.Trim & " " & HoraActual.Trim
                prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & strFecha & "^FS")
                prn.EscribeLinea("^FT255,188^AAN,18,10^FH\^FDTEPSA^FS")
                prn.EscribeLinea("^FT330,188^AAN,20,12^FH\^FD" & strCargo & "^FS")

                'hlamas 26-08-2015
                'prn.EscribeLinea("^FT183,188^AAN,18,10^FH\^FD" & HoraActual & "^FS")

                prn.EscribeLinea("^PQ1,0,1,Y")
                prn.EscribeLinea("^XZ")
                prn.EscribeLinea(cadena)
                'ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
                j = j + 1
                i += 1
            End While
            prn.FinDoc()
            '
            ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
            ObjCODIGOBARRA.sp_etiqueta_generada()
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function

    Public Function fnImprimirEtiquetasFAC_II() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()

            ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
            ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            ObjCODIGOBARRA.Cantidad = ObjVentaCargaContado.v_CANTIDAD_ETIQUETAS

            Dim I As Int16 = 0
            'Dim j As Int16 = 1
            'Dim j As Int16
            'If bRango Then
            '    j = 1
            'Else
            '    j = correlativo_inicial
            '    'Mod 21/08/2009 
            '    If j = 0 Then j = 1
            'End If
            ''''''''''''''''''''''''
            'Dim j As Int16 = 1
            Dim j As Int16
            If iRango = 1 Then
                j = 1
            ElseIf iRango = 2 Then
                j = correlativo_inicial
            Else
                j = 1
            End If


            ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
            ObjCODIGOBARRA.sp_etiqueta_generada()


            'While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
            'ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(0).Value
            While I <= ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows.Count - 1
                ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows(I)(0).ToString
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
                prn.EscribeLinea("<STX>H1;o130,13;f3;c25;h9;w15;d3," & ObjCODIGOBARRA.NroDOC & " -" & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & ";<ETX>")
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
                'ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
                'I = I + 1
                j = j + 1
                I += 1
            End While
            prn.FinDoc()
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function

    Function ObtieneProducto(producto As Integer) As String
        Select Case producto
            Case 0
                Return ""
            Case 6
                Return "CA"
            Case 8
                Return "TC"
            Case 10
                Return "SOB"
            Case 81
                Return "BOX"
            Case 82
                Return "BOX2"
        End Select
    End Function

    Function ObtieneTipoComprobante(tipo As Integer) As String
        Select Case tipo
            Case 1
                Return "FAC"
            Case 2
                Return "BOL"
            Case 3
                Return "GE"
            Case 85
                Return "PCE"
        End Select
    End Function

    Dim iRango As Byte = 0
    Public Function fnImprimirEtiquetasFAC_III() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()

            ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
            ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            ObjCODIGOBARRA.Cantidad = ObjVentaCargaContado.v_CANTIDAD_ETIQUETAS
            Dim strAgenciaDestino As String = dtoVentaCargaContado.AgenciaAbreviado(ObjVentaCargaContado.v_IDAGENCIAS_DESTINO)

            Dim I As Int16 = 0
            'Dim j As Int16 = 1
            Dim j As Int16
            ''''''''''''''
            'If bRango Then
            '    j = 1
            'Else
            '    j = correlativo_inicial
            '    'Mod 21/08/2009 
            '    If j = 0 Then j = 1
            'End If
            ''''''''''''''
            If iRango = 1 Then
                j = 1
            ElseIf iRango = 2 Then
                j = correlativo_inicial
            Else
                j = 1
            End If
            '
            'hlamas 26-08-2015
            'agregar CARGO para envios con devolucion de cargo
            Dim strCargo As String, strFecha As String
            'hlamas 22-03-2016
            'strCargo = IIf(Me.ChkCargo.Checked, "CARGO", "")
            strCargo = IIf(Me.rbtCargoSi.Checked, "CARGO", "")
            Dim strTipo As String = ObtieneTipoComprobante(ObjVentaCargaContado.v_IDTIPO_COMPROBANTE)
            Dim strAgeDom As String
            Dim strProducto As String = ObtieneProducto(Me.CboProducto.SelectedValue)
            While I <= ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows.Count - 1
                strAgeDom = ObjCODIGOBARRA.AGEDOM & "  " & strTipo
                ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows(I)(0).ToString
                prn.EscribeLinea("N")
                prn.EscribeLinea("N")
                prn.EscribeLinea("A30,14,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
                prn.EscribeLinea("A30,47,0,3,1,1,N,""" & ObjCODIGOBARRA.NroDOC & " " & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
                prn.EscribeLinea("A317,47,0,3,1,1,N,""" & strAgeDom & """")
                prn.EscribeLinea("A30,110,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-  """)


                strProducto = strProducto & "  " & strAgenciaDestino
                strProducto = strProducto.Trim
                prn.EscribeLinea("A30,140,0,3,1,1,N,""" & strProducto & """")

                'hlamas 26-08-2015
                'prn.EscribeLinea("A30,163,0,1,1,1,N,""" & ObjCODIGOBARRA.Fecha & """")
                'prn.EscribeLinea("A321,163,0,1,1,1,N,""TEPSAC""")

                strFecha = ObjCODIGOBARRA.Fecha.Trim & " " & HoraActual.Trim
                prn.EscribeLinea("A30,163,0,1,1,1,N,""" & strFecha & """")
                prn.EscribeLinea("A230,163,0,1,1,1,N,""JOTASYS""")
                prn.EscribeLinea("A300,163,0,2,1,1,N,""" & strCargo & """")

                'hlamas 26-08-2015
                'prn.EscribeLinea("A205,163,0,1,1,1,N,""" & HoraActual & """")

                prn.EscribeLinea("A89,94,0,3,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
                prn.EscribeLinea("B148,83,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """")
                prn.EscribeLinea("P1")
                prn.EscribeLinea("N")
                prn.EscribeLinea(cadena)
                j = j + 1
                I += 1
            End While
            prn.FinDoc()
            '
            ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
            ObjCODIGOBARRA.sp_etiqueta_generada()
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function

    Private ObjReport As ClsLbTepsa.dtoFrmReport
    Const v_ca As String = "->CARGA ASEGURADA"
    Private Function ImprimirFactura() As Boolean
        Dim iSubTotal As Double, iImpuesto As Double, iTotal As Double
        Dim flag As Boolean = False
        iSubTotal = 0
        iImpuesto = 0
        iTotal = 0
        Dim obj As New Imprimir
        Try
            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim sImpresora As String = ""
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0

            Dim montoLetras As String = ConvercionNroEnLetras(ObjIMPRESIONFACT_BOL.xTotal_Costo)
            Dim fecha_Systema As String() = Split(dtoUSUARIOS.m_sFecha, "/")
            Dim dia As String = fecha_Systema(0)
            Dim Mes As String = fecha_Systema(1)
            Dim Anio As String = fecha_Systema(2)

            Dim glosa3 As String = ""

            '    Dim GLOSA2 As String = ""
            '    Dim PESO As String = ""
            '    Dim PARCIAL As String = ""
            '    Dim CANTIDAD As String = ""

            '    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso) = 0 Then
            '        CANTIDAD = ObjIMPRESIONFACT_BOL.xCantidad_Peso & Chr(13)
            '        GLOSA2 = "BULTOS" & Chr(13)
            '        PESO = ObjIMPRESIONFACT_BOL.xTotalPeso & Chr(13)
            '        PARCIAL = Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso), "####,###,###.00") & Chr(13)
            '    End If

            '    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol) = 0 Then
            '        CANTIDAD = CANTIDAD & ObjIMPRESIONFACT_BOL.xCantidad_Vol & "" & Chr(13)
            '        GLOSA2 = GLOSA2 & "BULTOS (V.)" & Chr(13)
            '        PESO = PESO & ObjIMPRESIONFACT_BOL.xTotalVolumen & Chr(13)
            '        PARCIAL = PARCIAL & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol), "####,###,###.00") & Chr(13)
            '    End If

            '    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre) = 0 Then
            '        CANTIDAD = CANTIDAD & ObjIMPRESIONFACT_BOL.xCantidad_Sobre & ""
            '        GLOSA2 = GLOSA2 & "SOBRES"
            '        PESO = PESO & ""
            '        PARCIAL = PARCIAL & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre), "####,###,###.00")
            '    End If


            '    ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Val(GrdDetalleVenta(7, 2).Value)


            '    If CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString) > 400 Then

            '        glosa3 = "OPERACION SUJETA AL SISTEMA DE PAGO DE OBLIGACIONES TRIBUTARIAS CON " & Chr(13) & _
            '        "EL GOBIERNO CENTRAL ,  SEGÚN D.L. Nº  940 - R.S. Nº 158 -2006-SUNAT  / D.S. " & Chr(13) & _
            '        "Nº 033-2006-MTC." & Chr(13) & _
            '        "Sirvase a Depositar a la Cuenta del Bco. de la Nación Nº 0019-002829."
            '    Else
            '        glosa3 = ""
            '    End If

            Dim dt As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 1, Me.CboProducto.SelectedValue)
            If dt.Rows.Count = 0 Then
                flag = False
            Else
                If IsDBNull(dt.Rows(0).Item("impresora")) Then
                    flag = False
                Else
                    sImpresora = dt.Rows(0).Item("impresora")
                    iTamaño = dt.Rows(0).Item("tamano")
                    iSuperior = dt.Rows(0).Item("superior")
                    Iizquierda = dt.Rows(0).Item("izquierda")
                    flag = True
                End If
            End If

            If flag Then
                obj.Inicializar()
                obj.Superior = iSuperior
                obj.Izquierda = Iizquierda
                obj.Impresora = sImpresora

                Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
                Dim iLong As Integer
                If Me.CboProducto.SelectedValue <> 8 Then
                    iLong = IIf(iTamaño = 0, 36, iTamaño)
                    y = iLong * pagina + 4
                    y += 1
                    i += 1
                    If es_carga_asegurada Then
                        obj.EscribirLinea(y + 1, 48, ObjIMPRESIONFACT_BOL.xAgenciaDestino & v_ca)
                    Else
                        obj.EscribirLinea(y + 1, 48, ObjIMPRESIONFACT_BOL.xAgenciaDestino)
                    End If

                    obj.EscribirLinea(y, 48, ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL)
                    obj.EscribirLinea(y + 2, 53, fnGetHora())

                    obj.EscribirLinea(y + 4, 8, dia)
                    obj.EscribirLinea(y + 4, 23, Mes)
                    obj.EscribirLinea(y + 4, 42, Anio)

                    obj.EscribirLinea(y + 5, 13, ObjIMPRESIONFACT_BOL.xRazonSocial)
                    obj.EscribirLinea(y + 6, 13, ObjIMPRESIONFACT_BOL.xDireccionRemitente)
                    obj.EscribirLinea(y + 7, 13, ObjIMPRESIONFACT_BOL.xOrigen)
                    obj.EscribirLinea(y + 8, 13, ObjIMPRESIONFACT_BOL.xConsignado)
                    obj.EscribirLinea(y + 9, 13, ObjIMPRESIONFACT_BOL.xDireccionConsignado)

                    obj.EscribirLinea(y + 5, 66, ObjIMPRESIONFACT_BOL.xRuc)
                    obj.EscribirLinea(y + 7, 66, ObjIMPRESIONFACT_BOL.xDestino)

                    obj.EscribirLinea(y + 5, 105, ObjIMPRESIONFACT_BOL.xNroRef)
                    obj.EscribirLinea(y + 7, 105, ObjIMPRESIONFACT_BOL.xFormaPago)
                    obj.EscribirLinea(y + 8, 105, ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA)

                    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso) = 0 Then
                        obj.EscribirLinea(y + 12, 13, ObjIMPRESIONFACT_BOL.xCantidad_Peso)
                        obj.EscribirLinea(y + 12, 23, "BULTOS")
                        obj.EscribirLinea(y + 12, 92, ObjIMPRESIONFACT_BOL.xTotalPeso)
                    End If
                    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol) = 0 Then
                        obj.EscribirLinea(y + 13, 13, ObjIMPRESIONFACT_BOL.xCantidad_Vol)
                        obj.EscribirLinea(y + 13, 23, "BULTOS (V.)")
                        obj.EscribirLinea(y + 13, 92, ObjIMPRESIONFACT_BOL.xTotalVolumen)
                    End If
                    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre) = 0 Then
                        obj.EscribirLinea(y + 14, 13, ObjIMPRESIONFACT_BOL.xCantidad_Sobre)
                        obj.EscribirLinea(y + 14, 23, "SOBRES")
                    End If
                    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Impuesto) = 0 Then
                        obj.EscribirLinea(y + 14, 13, ObjIMPRESIONFACT_BOL.xCantidad_Sobre)
                        obj.EscribirLinea(y + 14, 23, "SOBRES")
                    End If

                    If es_carga_asegurada Then
                        ObtieneMontosAsegurados(iSubTotal, iImpuesto, iTotal)
                        If ObjVentaCargaContado.v_MONTO_DESCUENTO > 0 Then
                            iSubTotal = iSubTotal * (1 - (ObjVentaCargaContado.v_MONTO_DESCUENTO / 100))
                        End If
                        iSubTotal = FormatNumber(iSubTotal, 2)
                        obj.EscribirLinea(y + 15, 23, "SEGURO CARGA")
                        obj.EscribirLinea(y + 15, 110, Format(CDbl(iSubTotal.ToString.ToString), "####,###,###0.00").PadLeft(10, " "))
                        Dim isub As String
                        isub = Format(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total - iSubTotal, "0.00")
                        obj.EscribirLinea(y + 12, 110, isub.ToString.PadLeft(10, " "))
                    Else
                        obj.EscribirLinea(y + 12, 110, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total.ToString), "####,###,###0.00").PadLeft(10, " "))
                    End If

                    If CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString) > 400 Then
                        glosa3 = "OPERACION SUJETA AL SISTEMA DE PAGO DE OBLIGACIONES TRIBUTARIAS CON " & Chr(13) & _
                        "EL GOBIERNO CENTRAL ,  SEGÚN D.L. Nº  940 - R.S. Nº 158 -2006-SUNAT  / D.S. " & Chr(13) & _
                        "Nº 033-2006-MTC." & Chr(13) & _
                        "Sirvase a Depositar a la Cuenta del Bco. de la Nación Nº 0019-002829."

                        obj.EscribirLinea(y + 16, 23, "OPERACION SUJETA AL SISTEMA DE PAGO DE OBLIGACIONES TRIBUTARIAS CON")
                        obj.EscribirLinea(y + 17, 23, "EL GOBIERNO CENTRAL,SEGÚN D.L. Nº 940 - R.S. Nº 158 -2006-SUNAT/D.S.")
                        obj.EscribirLinea(y + 18, 23, "Nº 033-2006-MTC.")
                        obj.EscribirLinea(y + 19, 23, "Sirvase a Depositar a la Cuenta del Bco. de la Nación Nº 0019-002829.")
                    End If

                    obj.EscribirLinea(y + 21, 11, "Son:  " & montoLetras)
                    obj.EscribirLinea(y + 23, 54, dtoUSUARIOS.iLOGIN)
                    'obj.EscribirLinea(y + 22, 54, "19.00")

                    obj.EscribirLinea(y + 21, 85, "S/.")
                    obj.EscribirLinea(y + 22, 85, "S/.")
                    obj.EscribirLinea(y + 23, 85, "S/.")

                    obj.EscribirLinea(y + 21, 110, ObjIMPRESIONFACT_BOL.xMonto_Sub_Total.PadLeft(10, " "))
                    obj.EscribirLinea(y + 22, 110, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Impuesto), "####,###,###0.00").PadLeft(10, " "))
                    obj.EscribirLinea(y + 23, 110, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString), "####,###,###0.00").PadLeft(10, " "))
                Else
                    iLong = IIf(iTamaño = 0, 36, iTamaño)
                    y = iLong * pagina + 8
                    y += 1
                    i += 1
                    obj.EscribirLinea(y, 8, dia & " DE " & MonthName(Mes).ToString.ToUpper)
                    obj.EscribirLinea(y, 33, Anio)

                    obj.EscribirLinea(y, 66, Me.LblCiudad.Text)
                    obj.EscribirLinea(y, 108, ObjIMPRESIONFACT_BOL.xDestino)

                    If Me.CboTipoTarifa.SelectedValue = 1 Then
                        obj.EscribirLinea(y + 2, 21, "X")
                    ElseIf Me.CboTipoTarifa.SelectedValue = 2 Then
                        obj.EscribirLinea(y + 2, 31, "X")
                    End If

                    If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                        obj.EscribirLinea(y + 2, 67, "X")
                    Else
                        obj.EscribirLinea(y + 2, 77, "X")
                    End If

                    obj.EscribirLinea(y + 2, 108, ObjIMPRESIONFACT_BOL.TelefonoCliente(iCliente))

                    obj.EscribirLinea(y + 3, 16, ObjIMPRESIONFACT_BOL.xRazonSocial)
                    obj.EscribirLinea(y + 3, 108, ObjIMPRESIONFACT_BOL.xRuc)
                    obj.EscribirLinea(y + 4, 16, ObjIMPRESIONFACT_BOL.xDireccionRemitente)

                    obj.EscribirLinea(y + 5, 16, ObjIMPRESIONFACT_BOL.xConsignado) 'ya viene Concatenado
                    'obj.EscribirLinea(y + 5, 108, TxtNroDocConsignado.Text.Trim)
                    obj.EscribirLinea(y + 5, 108, ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO) 'GrdNConsignado("Nº Documento", 0).Value
                    obj.EscribirLinea(y + 6, 16, ObjIMPRESIONFACT_BOL.xDireccionConsignado)
                    'obj.EscribirLinea(y + 7, 108, TxtTelfConsignado.Text.Trim)

                    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso) = 0 Then
                        obj.EscribirLinea(y + 11, 23, "BULTOS")
                        obj.EscribirLinea(y + 11, 90, ObjIMPRESIONFACT_BOL.xCantidad_Peso)
                        obj.EscribirLinea(y + 11, 102, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotalPeso), "###,###,###0.00").PadLeft(8, " "))
                        obj.EscribirLinea(y + 11, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso), "###,###,###0.00").PadLeft(10, " "))
                    End If
                    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol) = 0 Then
                        obj.EscribirLinea(y + 12, 23, "BULTOS (V.)")
                        obj.EscribirLinea(y + 12, 90, ObjIMPRESIONFACT_BOL.xCantidad_Vol)
                        obj.EscribirLinea(y + 12, 102, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotalVolumen), "###,###,###0.00").PadLeft(8, " "))
                        obj.EscribirLinea(y + 12, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol), "###,###,###0.00").PadLeft(10, " "))
                    End If
                    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre) = 0 Then
                        obj.EscribirLinea(y + 13, 23, "SOBRES")
                        obj.EscribirLinea(y + 13, 90, ObjIMPRESIONFACT_BOL.xCantidad_Sobre)
                        obj.EscribirLinea(y + 13, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre), "###,###,###0.00").PadLeft(10, " "))
                    End If

                    If Not Me.ChkArticulos.Checked And Not Me.ChkM3.Checked Then
                        If Val(GrdDetalleVenta("Sub Neto", 3).Value) > 0 Then
                            obj.EscribirLinea(y + 14, 23, "BASE")
                            obj.EscribirLinea(y + 14, 120, Format(CDbl(GrdDetalleVenta("Sub Neto", 3).Value), "###,###,###0.00").PadLeft(10, " "))
                        End If
                    ElseIf Me.ChkM3.Checked Then
                        If Val(Me.txtTotalSobre.Text) > 0 Then
                            obj.EscribirLinea(y + 13, 23, "SOBRES")
                            obj.EscribirLinea(y + 13, 90, Me.txtCantidadSobres.Text)
                            obj.EscribirLinea(y + 13, 120, Format(CDbl(Me.txtTotalSobre.Text), "###,###,###0.00").PadLeft(10, " "))
                        End If

                        If Val(Me.TxtMontoBase.Text) > 0 Then
                            obj.EscribirLinea(y + 14, 23, "BASE")
                            obj.EscribirLinea(y + 14, 120, Format(CDbl(Me.TxtMontoBase.Text), "###,###,###0.00").PadLeft(10, " "))
                        End If
                    ElseIf Me.ChkArticulos.Checked Then
                        If Val(Me.txtTotalSobre.Text) > 0 Then
                            obj.EscribirLinea(y + 13, 23, "SOBRES")
                            obj.EscribirLinea(y + 13, 90, Me.txtCantidadSobres.Text)
                            obj.EscribirLinea(y + 13, 120, Format(CDbl(Me.txtTotalSobre.Text), "###,###,###0.00").PadLeft(10, " "))
                        End If

                        If Val(Me.TxtMontoBase.Text) > 0 Then
                            obj.EscribirLinea(y + 14, 23, "BASE")
                            obj.EscribirLinea(y + 14, 120, Format(CDbl(Me.TxtMontoBase.Text), "###,###,###0.00").PadLeft(10, " "))
                        End If
                    End If

                    'If es_carga_asegurada Then
                    'ObtieneMontosAsegurados(iSubTotal, iImpuesto, iTotal)
                    'If ObjVentaCargaContado.v_MONTO_DESCUENTO > 0 Then
                    '    iSubTotal = iSubTotal * (1 - (ObjVentaCargaContado.v_MONTO_DESCUENTO / 100))
                    'End If
                    'iSubTotal = FormatNumber(iSubTotal, 2)
                    'obj.EscribirLinea(y + 15, 23, "SEGURO CARGA")
                    'obj.EscribirLinea(y + 15, 110, Format(CDbl(iSubTotal.ToString.ToString), "####,###,###0.00").PadLeft(10, " "))
                    'Dim isub As String
                    'isub = Format(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total - iSubTotal, "0.00")
                    'obj.EscribirLinea(y + 12, 110, isub.ToString.PadLeft(10, " "))
                    'End If

                    If CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString) > 400 Then
                        obj.EscribirLinea(y + 15, 0, "OPERACION SUJETA AL SISTEMA DE PAGO DE OBLIGACIONES TRIBUTARIAS CON EL GOBIERNO CENTRAL")
                        obj.EscribirLinea(y + 16, 0, "SEGUN D.L. N. 940-R.S. N. 158-2006-SUNAT/D.S. N. 033-2006-MTC.")
                        obj.EscribirLinea(y + 17, 0, "SIRVASE DEPOSITAR A LA CUENTA DEL BANCO DE LA NACION Nº0019-002829.")
                    End If

                    obj.EscribirLinea(y + 17, 120, ObjIMPRESIONFACT_BOL.xMonto_Sub_Total.PadLeft(10, " "))
                    obj.EscribirLinea(y + 18, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Impuesto), "####,###,###0.00").PadLeft(10, " "))
                    obj.EscribirLinea(y + 20, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString), "####,###,###0.00").PadLeft(10, " "))
                End If

                'obj.Comprimido = True
                'obj.Preliminar = True
                'obj.Tamaño = iLong
                'obj.Imprimir()
                'obj.Finalizar()

                'Dim frm As New FrmPreview
                'frm.Tamaño = iLong
                'frm.Documento = 1
                'frm.Text = "Factura"
                'frm.ShowDialog()

                obj.Comprimido = True
                obj.Tamaño = iLong
                obj.Imprimir()
                obj.Finalizar()
            End If

        Catch ex As Exception
            obj.Finalizar()
            Throw New Exception(ex.Message)
        End Try
        Return False
    End Function

    Dim iCliente As Integer = 0
    Public Function ImprimirBoleta() As Boolean
        Dim obj As New Imprimir
        Dim iSubTotal As Double, iImpuesto As Double, iTotal As Double
        Try
            Dim HoraSistema As String = fnGetHora()
            Dim GLOSA2 As String = ""
            Dim PESO As String = ""
            Dim PARCIAL As String = ""
            Dim CANTIDAD As String = ""

            Dim fecha_Systema As String() = Split(dtoUSUARIOS.m_sFecha, "/")
            Dim dia As String = fecha_Systema(0)
            Dim Mes As String = fecha_Systema(1)
            Dim Anio As String = fecha_Systema(2)

            Dim glosa3 As String = ""

            '
            'If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso) = 0 Then
            '    CANTIDAD = ObjIMPRESIONFACT_BOL.xCantidad_Peso & Chr(13)
            '    GLOSA2 = "BULTOS" & Chr(13)
            '    PESO = ObjIMPRESIONFACT_BOL.xTotalPeso & Chr(13)
            '    PARCIAL = Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso), "####,###,###.00") & Chr(13)
            'End If

            'If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol) = 0 Then
            '    CANTIDAD = CANTIDAD & ObjIMPRESIONFACT_BOL.xCantidad_Vol & "" & Chr(13)
            '    GLOSA2 = GLOSA2 & "BULTOS (V.)" & Chr(13)
            '    PESO = PESO & ObjIMPRESIONFACT_BOL.xTotalVolumen & Chr(13)
            '    PARCIAL = PARCIAL & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol), "####,###,###.00") & Chr(13)
            'End If

            'If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre) = 0 Then
            '    CANTIDAD = CANTIDAD & ObjIMPRESIONFACT_BOL.xCantidad_Sobre & ""
            '    GLOSA2 = GLOSA2 & "SOBRES"
            '    PESO = PESO & ""
            '    PARCIAL = PARCIAL & Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre), "####,###,###.00")
            'End If

            'Dim Detalle As String = CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Vol)
            'Detalle = Detalle & "  SOBRE'S: " & CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString
            'GLOSA2 = "BULTOS   " & Val(Val(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + Val(ObjIMPRESIONFACT_BOL.xCantidad_Vol)).ToString & Chr(13) & "SOBRES   " & Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString
            ''"P_DETALLE;" & "CANTIDAD: " & CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Sobre) + CDbl(ObjIMPRESIONFACT_BOL.xCantidad_Vol), _
            ''ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Val(GrdDetalleVenta(7, 2).Value)
            'ObjReport.rutaRpt = PathFrmReport

            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim dt As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 2, Me.CboProducto.SelectedValue)
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0
            Dim flag As Boolean
            If dt.Rows.Count = 0 Then
                flag = False
            Else
                If IsDBNull(dt.Rows(0).Item("impresora")) Then
                    flag = False
                Else
                    sImpresora = dt.Rows(0).Item("impresora")
                    iTamaño = dt.Rows(0).Item("tamano")
                    iSuperior = dt.Rows(0).Item("superior")
                    Iizquierda = dt.Rows(0).Item("izquierda")
                    flag = True
                End If
            End If

            If flag Then
                obj.Inicializar()
                obj.Impresora = sImpresora
                obj.Superior = iSuperior
                obj.Izquierda = Iizquierda

                Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0

                Dim ilong As Integer

                Dim sConsignado As String = ObjIMPRESIONFACT_BOL.xConsignado.Trim.Replace(";", ",")
                sConsignado = sConsignado.Substring(0, sConsignado.Trim.Length - 1)

                If Me.CboProducto.SelectedValue <> 8 Then
                    ilong = IIf(iTamaño = 0, 18, iTamaño)
                    y = ilong * pagina + 4
                    y += 1
                    i += 1

                    obj.EscribirLinea(y, 6, ObjIMPRESIONFACT_BOL.xOrigen)
                    obj.EscribirLinea(y + 1, 6, ObjIMPRESIONFACT_BOL.xfecha_factura)
                    obj.EscribirLinea(y + 2, 6, ObjIMPRESIONFACT_BOL.xRazonSocial)
                    obj.EscribirLinea(y + 3, 6, sConsignado)
                    obj.EscribirLinea(y + 4, 6, ObjIMPRESIONFACT_BOL.xDireccionConsignado)
                    obj.EscribirLinea(y, 30, ObjIMPRESIONFACT_BOL.xDestino)

                    If es_carga_asegurada Then
                        obj.EscribirLinea(0, 30, v_ca)
                    End If

                    obj.EscribirLinea(y + 1, 30, HoraSistema)
                    obj.EscribirLinea(y + 1, 53, ObjIMPRESIONFACT_BOL.xFormaPago)
                    obj.EscribirLinea(y, 52, ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA)

                    'y+7=12
                    obj.EscribirLinea(y + 7, 16, "BULTOS   " & Val(Val(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + Val(ObjIMPRESIONFACT_BOL.xCantidad_Vol)).ToString)
                    obj.EscribirLinea(y + 7, 46, ObjIMPRESIONFACT_BOL.xTotalPeso)
                    obj.EscribirLinea(y + 7, 56, ObjIMPRESIONFACT_BOL.xTotalVolumen)
                    If es_carga_asegurada Then
                        obj.EscribirLinea(y + 7, 67, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo - iTotal), "###,###,###.00"))
                    Else
                        obj.EscribirLinea(y + 7, 67, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                    End If

                    obj.EscribirLinea(y + 7, 84, "BULTOS   " & Val(Val(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + Val(ObjIMPRESIONFACT_BOL.xCantidad_Vol)).ToString)
                    obj.EscribirLinea(y + 7, 105, ObjIMPRESIONFACT_BOL.xTotalVolumen)
                    obj.EscribirLinea(y + 7, 112, ObjIMPRESIONFACT_BOL.xTotalPeso)
                    If es_carga_asegurada Then
                        obj.EscribirLinea(y + 7, 121, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo - iTotal), "###,###,###.00"))
                    Else
                        obj.EscribirLinea(y + 7, 121, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                    End If

                    obj.EscribirLinea(y + 8, 16, "SOBRES   " & Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString)
                    obj.EscribirLinea(y + 8, 84, "SOBRES   " & Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString)

                    obj.EscribirLinea(y + 10, 67, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                    obj.EscribirLinea(y + 10, 121, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))

                    obj.EscribirLinea(0, 16, dtoUSUARIOS.iLOGIN)
                    obj.EscribirLinea(0, 90, dtoUSUARIOS.iLOGIN)

                    If es_carga_asegurada Then
                        ObtieneMontosAsegurados(iSubTotal, iImpuesto, iTotal)
                        iTotal = FormatNumber(iTotal, 2)
                        If ObjVentaCargaContado.v_MONTO_DESCUENTO > 0 Then
                            iTotal = iTotal * (1 - (ObjVentaCargaContado.v_MONTO_DESCUENTO / 100))
                        End If

                        obj.EscribirLinea(y + 9, 16, "SEGURO CARGA")
                        obj.EscribirLinea(y + 9, 67, Format(CDbl(iTotal), "###,###,###.00"))

                        obj.EscribirLinea(y + 9, 84, "SEGURO CARGA")
                        obj.EscribirLinea(y + 9, 121, Format(CDbl(iTotal), "###,###,###.00"))
                    End If

                    obj.EscribirLinea(3, 33, ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL)
                    obj.EscribirLinea(y, 89, ObjIMPRESIONFACT_BOL.xOrigen)
                    obj.EscribirLinea(y + 1, 89, ObjIMPRESIONFACT_BOL.xfecha_factura)
                    obj.EscribirLinea(y + 2, 89, ObjIMPRESIONFACT_BOL.xRazonSocial)
                    obj.EscribirLinea(y + 3, 89, sConsignado)
                    obj.EscribirLinea(y + 4, 89, ObjIMPRESIONFACT_BOL.xDireccionConsignado)
                    obj.EscribirLinea(y, 105, ObjIMPRESIONFACT_BOL.xDestino)
                    obj.EscribirLinea(y + 1, 114, HoraSistema)

                    obj.EscribirLinea(y + 1, 105, ObjIMPRESIONFACT_BOL.xFormaPago)
                    obj.EscribirLinea(y, 120, ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA)


                    obj.EscribirLinea(0, 0, ObjIMPRESIONFACT_BOL.xIdFactura)
                    obj.EscribirLinea(4, 30, ObjIMPRESIONFACT_BOL.xAgenciaDestino)
                    obj.EscribirLinea(3, 82, ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL)
                    obj.EscribirLinea(0, 82, ObjIMPRESIONFACT_BOL.xIdFactura)
                    obj.EscribirLinea(4, 82, ObjIMPRESIONFACT_BOL.xAgenciaDestino)
                Else
                    ilong = IIf(iTamaño = 0, 36, iTamaño)
                    y = ilong * pagina + 8
                    y += 1
                    i += 1

                    obj.EscribirLinea(y, 8, dia & " DE " & MonthName(Mes).ToString.ToUpper)
                    obj.EscribirLinea(y, 33, Anio)

                    obj.EscribirLinea(y, 66, Me.LblCiudad.Text)
                    obj.EscribirLinea(y, 108, ObjIMPRESIONFACT_BOL.xDestino)

                    If Me.CboTipoTarifa.SelectedValue = 1 Then
                        obj.EscribirLinea(y + 2, 21, "X")
                    ElseIf Me.CboTipoTarifa.SelectedValue = 2 Then
                        obj.EscribirLinea(y + 2, 31, "X")
                    End If

                    If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                        obj.EscribirLinea(y + 2, 67, "X")
                    ElseIf ObjVentaCargaContado.v_IDTIPO_ENTREGA = 0 Then
                        obj.EscribirLinea(y + 2, 77, "X")
                    End If

                    obj.EscribirLinea(y + 2, 108, ObjIMPRESIONFACT_BOL.TelefonoCliente(iCliente))

                    obj.EscribirLinea(y + 3, 16, ObjIMPRESIONFACT_BOL.xRazonSocial)
                    obj.EscribirLinea(y + 3, 108, ObjIMPRESIONFACT_BOL.xRuc)
                    obj.EscribirLinea(y + 4, 16, ObjIMPRESIONFACT_BOL.xDireccionRemitente)

                    obj.EscribirLinea(y + 5, 16, sConsignado)
                    'obj.EscribirLinea(y + 5, 108, TxtNroDocConsignado.Text.Trim)
                    obj.EscribirLinea(y + 5, 108, ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO) 'GrdNConsignado("Nº Documento", 0).Value
                    obj.EscribirLinea(y + 6, 16, ObjIMPRESIONFACT_BOL.xDireccionConsignado)
                    ' obj.EscribirLinea(y + 7, 108, TxtTelfConsignado.Text.Trim)

                    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso) = 0 Then
                        obj.EscribirLinea(y + 11, 23, "BULTOS")
                        obj.EscribirLinea(y + 11, 90, ObjIMPRESIONFACT_BOL.xCantidad_Peso)
                        obj.EscribirLinea(y + 11, 102, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotalPeso), "###,###,###0.00").PadLeft(8, " "))
                        obj.EscribirLinea(y + 11, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso), "###,###,###0.00").PadLeft(10, " "))
                    End If
                    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol) = 0 Then
                        obj.EscribirLinea(y + 12, 23, "BULTOS (V.)")
                        obj.EscribirLinea(y + 12, 90, ObjIMPRESIONFACT_BOL.xCantidad_Vol)
                        obj.EscribirLinea(y + 12, 102, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotalVolumen), "###,###,###0.00").PadLeft(8, " "))
                        obj.EscribirLinea(y + 12, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol), "###,###,###0.00").PadLeft(10, " "))
                    End If
                    If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre) = 0 Then
                        obj.EscribirLinea(y + 13, 23, "SOBRES")
                        obj.EscribirLinea(y + 13, 90, ObjIMPRESIONFACT_BOL.xCantidad_Sobre)
                        obj.EscribirLinea(y + 13, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre), "###,###,###0.00").PadLeft(10, " "))
                    End If

                    If Not Me.ChkArticulos.Checked And Not Me.ChkM3.Checked Then
                        If Val(GrdDetalleVenta("Sub Neto", 3).Value) > 0 Then
                            obj.EscribirLinea(y + 14, 23, "BASE")
                            obj.EscribirLinea(y + 14, 120, Format(CDbl(GrdDetalleVenta("Sub Neto", 3).Value), "###,###,###0.00").PadLeft(10, " "))
                        End If
                    ElseIf Me.ChkM3.Checked Then
                        If Val(Me.txtTotalSobre.Text) > 0 Then
                            obj.EscribirLinea(y + 13, 23, "SOBRES")
                            obj.EscribirLinea(y + 13, 90, Me.txtCantidadSobres.Text)
                            obj.EscribirLinea(y + 13, 120, Format(CDbl(Me.txtTotalSobre.Text), "###,###,###0.00").PadLeft(10, " "))
                        End If

                        If Val(Me.TxtMontoBase.Text) > 0 Then
                            obj.EscribirLinea(y + 14, 23, "BASE")
                            obj.EscribirLinea(y + 14, 120, Format(CDbl(Me.TxtMontoBase.Text), "###,###,###0.00").PadLeft(10, " "))
                        End If
                    ElseIf Me.ChkArticulos.Checked Then
                        If Val(Me.txtTotalSobre.Text) > 0 Then
                            obj.EscribirLinea(y + 13, 23, "SOBRES")
                            obj.EscribirLinea(y + 13, 90, Me.txtCantidadSobres.Text)
                            obj.EscribirLinea(y + 13, 120, Format(CDbl(Me.txtTotalSobre.Text), "###,###,###0.00").PadLeft(10, " "))
                        End If

                        If Val(Me.TxtMontoBase.Text) > 0 Then
                            obj.EscribirLinea(y + 14, 23, "BASE")
                            obj.EscribirLinea(y + 14, 120, Format(CDbl(Me.TxtMontoBase.Text), "###,###,###0.00").PadLeft(10, " "))
                        End If
                    End If


                    'obj.EscribirLinea(y + 17, 120, ObjIMPRESIONFACT_BOL.xMonto_Sub_Total.PadLeft(10, " "))
                    'obj.EscribirLinea(y + 18, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Impuesto), "####,###,###0.00").PadLeft(10, " "))
                    obj.EscribirLinea(y + 17, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString), "####,###,###0.00").PadLeft(10, " "))

                End If
                obj.Comprimido = True
                obj.Tamaño = ilong
                obj.Imprimir()
                obj.Finalizar()

                'obj.Comprimido = True
                'obj.Preliminar = True
                'obj.Tamaño = ilong
                'obj.Imprimir()
                'obj.Finalizar()

                'Dim frm As New FrmPreview
                'frm.Tamaño = ilong
                'frm.Documento = 1
                'frm.Text = "Boleta"
                'frm.ShowDialog()
            End If

        Catch ex As Exception
            obj.Finalizar()
            Throw New Exception(ex.Message)
        End Try
        Return False
    End Function
#End Region

#Region "FUNCIONES"
    Sub ListarProducto(ByVal opcion As Integer)
        Try
            Dim obj As New dtoVentaCargaContado
            Dim dt As DataTable = obj.ListarProceso(opcion)
            RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged

            Dim dtp As New DataTable
            dtp.Columns.Add("idprocesos").DataType = GetType(Integer)
            dtp.Columns.Add("nombre_secundario").DataType = GetType(String)

            For Each row As DataRow In dt.Rows
                If (CboTipo.SelectedValue = 1) Then '-->PCE
                    'If (row("idprocesos") <> ID_PRODUCTO_TEPSA_COURIER) Then '-->para PCE no carga el producto TEPSA CURRIER
                    dtp.Rows.Add(row("idprocesos"), row("nombre_secundario"))
                    'End If
                Else '-->CREDITO
                dtp.Rows.Add(row("idprocesos"), row("nombre_secundario"))
                End If
            Next

            Me.CboProducto.DataSource = dtp
            Me.CboProducto.DisplayMember = "nombre_secundario"
            Me.CboProducto.ValueMember = "idprocesos"
            Me.CboProducto.SelectedIndex = 0

            AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged

            '13/09/2011 richard chikito
            Dim sender As Object
            Dim e As EventArgs
            CboProducto_SelectedIndexChanged(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub DespliegaRemitente()
        Me.CboRemitente.DroppedDown = True
        Me.CboRemitente.Focus()
        Me.Cursor = Cursors.Default
    End Sub

    Sub DespliegaContacto()
        Me.CboContacto.DroppedDown = True
        Me.CboContacto.Focus()
        Me.Cursor = Cursors.Default
    End Sub

    Sub ConvertirTipoEntrega(ByVal tipo As Integer)
        If tipo = TipoEntrega.Agencia Then
            Me.CboDireccion2.DataSource = Nothing
            Me.CboDireccion2.Items.Clear()
            Me.CboDireccion2.Items.Add("AGENCIA")
            Me.CboDireccion2.SelectedIndex = 0
            Me.TxtReferencia.Text = "" '09092011
        ElseIf tipo = TipoEntrega.Domicilio Then
            If dtDireccion2 IsNot Nothing Then
                Me.CboDireccion2.DataSource = dtDireccion2
                Me.CboDireccion2.ValueMember = "iddireccion_consignado"
                Me.CboDireccion2.DisplayMember = "direccion"

                If Me.CboDireccion2.Items.Count = 2 Then
                    Me.CboDireccion2.SelectedIndex = 1
                Else
                    Me.CboDireccion2.SelectedIndex = 0
                    Me.TxtReferencia.Text = "" '09092011
                End If

            Else
                Me.CboDireccion2.Items.Clear()
                Me.CboDireccion2.Items.Add(" (SELECCIONE)")
                Me.CboDireccion2.SelectedIndex = 0
            End If
        Else
            Me.CboDireccion2.DataSource = Nothing
            Me.CboDireccion2.Items.Clear()
            Me.CboDireccion2.SelectedIndex = -1
            Me.TxtReferencia.Text = "" '09092011
        End If
    End Sub

    Sub MostrarConsignado(ByVal ds As DataSet)
        Try
            bConsignadoNuevo = False
            '****comentado x nconsignado******
            'Me.TxtNroDocConsignado.Tag = ds.Tables(0).Rows(0).Item("idcontacto_persona").ToString.Trim
            iNroDocumentoTag = ds.Tables(0).Rows(0).Item("idcontacto_persona").ToString.Trim
            iIDConsignado = ds.Tables(0).Rows(0).Item("idcontacto_persona").ToString.Trim
            'Me.TxtNroDocConsignado.Text = ds.Tables(0).Rows(0).Item("nrodocumento").ToString.Trim
            'Me.TxtNombConsignado.Text = ds.Tables(0).Rows(0).Item("nombres").ToString.Trim '& " " & ds.Tables(0).Rows(0).Item("apepat").ToString.Trim & " " & ds.Tables(0).Rows(0).Item("apemat").ToString.Trim
            'Me.TxtTelfConsignado.Text = ds.Tables(0).Rows(0).Item("telefono").ToString.Trim

            '====Agregado x NConsignados=============================================
            If ChkCliente2.Checked Then GrdNConsignado.Rows.Clear()
            Dim bExiste As Boolean = False
            If iIDConsignado > 0 And GrdNConsignado.Rows.Count > 0 Then
                For i As Integer = 0 To GrdNConsignado.Rows.Count - 1
                    If iIDConsignado = GrdNConsignado("IDConsignado", i).Value Then
                        bExiste = True
                    End If
                Next
            End If

            If Not bExiste Then
                Me.ActualizarGrid(ds)
            End If
            '=========================================================================

            '****comentado x NConsignado***********************************************
            'RemoveHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
            'If Me.TxtNomCliente.Text.Trim = Me.TxtNombConsignado.Text.Trim Then Me.ChkCliente2.Checked = True Else Me.ChkCliente2.Checked = False
            'AddHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged

            Me.CboDireccion2.Focus()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

#End Region

    Private Sub GrdDocumentosCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdDocumentosCliente.LostFocus
        GrdDocumentosCliente.ClearSelection()
    End Sub

    Private Sub GrdDetalleVenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdDetalleVenta.LostFocus
        GrdDetalleVenta.ClearSelection()
    End Sub

    Private Sub GrdDocumentosCliente_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles GrdDocumentosCliente.RowsAdded
        GrdDocumentosCliente.ClearSelection()
        GrdDetalleVenta.ClearSelection()
    End Sub


    Private Sub txtNroNroGuia_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNroNroGuia.Validating
        txtNroNroGuia.Text = RellenoRight(NroDigitos_Guias, txtNroNroGuia.Text.Trim)
        ' Me.FnConsultar()

    End Sub

    Sub FnConsultar()
        Try
            limpiar_documentos_cliente()
            '-----
            dsPreGuia = objGuiaEnvio.RecuperarPreGuiaVenta(Convert.ToInt32(txtNroNroGuia.Text))
            Me.MostrarVentaCredito(dsPreGuia)

            'GrdDocumentosCliente.ClearSelection()
            'GrdDetalleVenta.ClearSelection()
            'TabGuia.SelectTab(1)
            'GrdDetalleVenta.Focus()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Dim iIDSubcuenta As Integer, iIDAgenciaDestino As Integer, iCiudad As Integer, iAgencia As Integer, iTipoEntrega As Integer, iTipoVenta As Integer
    Dim Proceso As Integer, iTipoTarifa As Integer
    Dim sFechaGuia As String
    Dim bSclienteConsignado As Boolean

    Sub MostrarVentaCredito(ByVal ds As DataSet)
        Try
            If IsNothing(ds) Then
                Return
            End If

            If ds.Tables(0).Rows.Count <= 0 Then
                Return
            End If

            bDirecConsigMod = False
            bContactoModificado = False
            bDireccionModificada = False

            CboTipo.SelectedValue = 2
            CboProducto.SelectedIndex = -1
            CboTipoTarifa.SelectedIndex = -1

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("IDAGENCIAS_ORI")) Then
                iCiudad = ds.Tables(0).Rows(0).Item("IDAGENCIAS_ORI")
                LblCiudad.Text = ds.Tables(0).Rows(0).Item("UNIDAD_ORIGEN")
            End If
            
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("IdAgencia_o")) Then
                objGuiaEnvio.iIDUNIDAD_AGENCIA = ds.Tables(0).Rows(0).Item("IdAgencia_o")
                LblAgencia.Text = ds.Tables(0).Rows(0).Item("Agencia_Origen")
            End If

            iAgencia = ds.Tables(0).Rows(0).Item("IDAGENCIAS")
            'CboAgencia_Origen.SelectedValue = ds.Tables(0).Rows(0).Item("IDAGENCIAS")

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("IDTIPO_ENTREGA_CARGA")) Then
                iTipoEntrega = ds.Tables(0).Rows(0).Item("IDTIPO_ENTREGA_CARGA")
                CboTipoEntrega.SelectedValue = ds.Tables(0).Rows(0).Item("IDTIPO_ENTREGA_CARGA")
            Else
                iTipoEntrega = 0
                CboTipoEntrega.SelectedValue = 0
            End If

            '*************************************************************************
            '************************** Ciudad Destino *******************************
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("IdAgencias_Desti")) Then
                blnAgencia = True
                TxtCiudadDestino.Text = ds.Tables(0).Rows(0).Item("UNIDAD_DESTINO")
                CodCiudadDest_ = ds.Tables(0).Rows(0).Item("IdAgencias_Desti")
                blnAgencia = False
            End If

            '=========================================================================
            '*****DATOS CLIENTE*******************************************************
            bClienteModificado = False
            bClienteNuevo = False
            Me.iID_Persona = ds.Tables(0).Rows(0).Item("idpersona")
            Me.TxtCliente.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NU_DOCU_SUNA")), "", ds.Tables(0).Rows(0).Item("NU_DOCU_SUNA"))
            BuscarClienteCredito()

            '*************************************************************************
            '************* Centro de costo o Sub Cuenta ******************************
            CboSubCuenta.SelectedValue = ds.Tables(0).Rows(0).Item("IDCENTRO_COSTO")

            '*************************************************************************
            '************************** Agencia Destino ******************************
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("IdAgencia_d")) Then
                CboAgenciaDest.SelectedValue = ds.Tables(0).Rows(0).Item("IdAgencia_d")
            End If

            Dim dr As DataRow

            '==========================================
            '****DIRECCION CLIENTE*********************
            For index As Integer = 0 To dtDireccion.Rows.Count - 1
                If dtDireccion.Rows(index)("iddireccion_consignado").ToString.Trim = ds.Tables(0).Rows(0).Item("IDDIRECCION_REMITENTE").ToString.Trim Then
                    CboDireccion.SelectedIndex = index
                    Exit For
                End If
            Next

            '==============================================================================
            '*********DATOS REMITENTE******************************************************
            If ds.Tables(0).Rows(0).Item("NroDocumentoRemitente").ToString <> TxtCliente.Text Then
                ChkCliente.Checked = False
            End If
            For index As Integer = 0 To dtRemitente.Rows.Count - 1
                If dtRemitente.Rows(index)("idcontacto_persona").ToString.Trim = ds.Tables(0).Rows(0).Item("ID_REMITENTE").ToString.Trim Then
                    CboRemitente.SelectedIndex = index
                    Exit For
                End If
            Next

            '=============================================================================
            '*********DATOS CONTACTO******************************************************
            If ds.Tables(0).Rows(0).Item("NroDocumentoContacto").ToString <> TxtCliente.Text Then
                ChkCliente1.Checked = False
            End If
            For index As Integer = 0 To dtContacto.Rows.Count - 1
                If dtContacto.Rows(index)("idcontacto_persona").ToString.Trim = ds.Tables(0).Rows(0).Item("idcontacto").ToString.Trim Then
                    CboContacto.SelectedIndex = index
                    Exit For
                End If
            Next

            '=========================================================================
            '*****DATOS CLIENTE*******************************************************
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("idconsignado")) Then
                iIDConsignado = ds.Tables(0).Rows(0).Item("idconsignado")
                row = GrdNConsignado.Rows.Count()
                GrdNConsignado.Rows.Add()
                GrdNConsignado("IDConsignado", row).Value = iIDConsignado
                GrdNConsignado("Nº Documento", row).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NroDocumentoConsignado")), "", ds.Tables(0).Rows(0).Item("NroDocumentoConsignado"))
                GrdNConsignado("Nombres", row).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NombresConsignado")), "", ds.Tables(0).Rows(0).Item("NombresConsignado"))
                GrdNConsignado("Telefono", row).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("TelefonoConsignado")), "", ds.Tables(0).Rows(0).Item("TelefonoConsignado"))
                GrdNConsignado("nombre", row).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("NombreConsignado")), "", ds.Tables(0).Rows(0).Item("NombreConsignado"))
                GrdNConsignado("tipo", row).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("TipoDocumentoConsignado")), "", ds.Tables(0).Rows(0).Item("TipoDocumentoConsignado"))
                GrdNConsignado("apepat", row).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApellPaternoConsignado")), "", ds.Tables(0).Rows(0).Item("ApellPaternoConsignado"))
                GrdNConsignado("apemat", row).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("ApellMaternoConsignado")), "", ds.Tables(0).Rows(0).Item("ApellMaternoConsignado"))
                GrdNConsignado("Modificado", row).Value = "0"
                GrdNConsignado("Existe", row).Value = "Y"
                Me.TxtConsignado.Text = ""

            End If

            '=============================================
            '****DIRECCION CONSIGNADO*********************
            'If Not IsDBNull(ds.Tables(0).Rows(0).Item("iddireccion_destinatario")) Then
            '    If dtDireccion2.Rows.Count > 0 Then
            '        For index As Integer = 0 To dtDireccion2.Rows.Count - 1
            '            If dtDireccion2.Rows(index).Item("IDDIRECCION_CONSIGNADO").ToString.Trim = ds.Tables(0).Rows(0).Item("iddireccion_destinatario").ToString.Trim Then
            '                CboDireccion2.SelectedIndex = index
            '                Exit For
            '            End If
            '        Next
            '    End If
            'End If
            CboDireccion2.SelectedValue = ds.Tables(0).Rows(0).Item("iddireccion_destinatario")
            ' fncValidarEnvioRetorno_Destino_CentroCosto()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

#End Region

    Dim sNombresConsignado As String = ""
    Dim sTelefonoConsignado As String = ""
    Private Function Grabar_GuiaEnvio() As Boolean
        Dim flat As Boolean = True
        Dim lb_valida As Boolean
        Try
            Dim iIDGUIAS_ENVIO As Integer = 0
            Dim sFECHA_GUIA As String = txtFechaGuia.Text '---------------------------------> PARAMETRO FECHA GUIA            
            Dim sNRO_GUIA As String = RellenoRight(NroDigitos_Guias, txtNroNroGuia.Text.Trim) '--> PARAMETRO NRO GUIA             
            '=================================CLIENTE=======================================================                                           
            If (TipoComprobante = 1 Or CboProducto.SelectedValue = 7) Then
                sNombresCli = ""
            ElseIf ChkCliente1.Checked And TipoComprobante = 1 Then
                NombresCont = ""
            ElseIf ChkCliente2.Checked And TipoComprobante = 1 Then
                sNombresConsig = ""
            End If

            '---------DATOS DEL CLIENTE------
            Dim iClienteModificado As Integer = IIf(bClienteModificado, 1, 0)
            Dim iIDPERSONA As Integer = IIf(bClienteNuevo, 0, iID_Persona) '---------------------->  PARAMETRO IDPERSONA    
            Dim sNombresCliente As String = IIf(TxtNomCliente.Text <> "", TxtNomCliente.Text, "@") ' PARAMETRO NOMBRES O RAZON SOCIAL
            Dim sNumeroDocumentoCliente As String = IIf(TxtNroDocCliente.Text <> "", TxtNroDocCliente.Text, "@")
            Dim iID_TipoDocumentoCliente As Integer = iID_TipoDocCli '--->agre
            Dim sNombreCliente As String = sNombresCli
            Dim sApellidoPaternoCliente As String = sApCli
            Dim sApellidoMaternoCliente As String = sAmCli
            Dim TelefonoCliente As String = IIf(sTelfCliente.Length > 0, sTelfCliente, "@")

            '--DIRECCION ESTRUCTURADO DEL CLIENTE  
            Dim iDireccionCliente_Mod As Integer = IIf(bDireccionModificada, 1, 0)
            ' Dim Direccion_Cliente As Integer = IIf(iDireccion_Catenada, 1, 0)

            'PARAMETRO IDDIRECCION_ORIGEN******
            If CboDireccion.SelectedValue = 0 Then
                IdDireccionOrigen = -1
            Else
                IdDireccionOrigen = CboDireccion.SelectedValue
            End If
            Dim IDDIREECION_ORIGEN As Integer = IdDireccionOrigen
            'PARAMETRO NOMBRE DE LA DIRECCION**
            Dim NombreDireccion_Origen As String = IIf(IdDireccionOrigen = -1, "@", CboDireccion.Text)

            '=============================DATOS REMITENTE=====================================
            If CboRemitente.SelectedIndex = 0 Then
                idRemitente = -1
            End If
            If idcontacto = 0 AndAlso Me.ChkCliente.Checked Then
                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.BuscarContacto(Me.TxtNroDocCliente.Text, TxtNumDocRemitente.Text)
                Dim resp As Integer = dt.Rows.Count
                If resp = 0 Then
                    Me.TxtNumDocRemitente.Tag = 0
                    idRemitente = 0
                Else
                    Me.TxtNumDocRemitente.Tag = dt.Rows(0).Item(0)
                    idRemitente = dt.Rows(0).Item(0)
                    bRemitenteModificado = False
                End If
            End If

            'PARAMETRO ID_NOMBRE_REMITENTE**
            Dim iRemitenteModificado As Integer = IIf(bRemitenteModificado, 1, 0)
            Dim iIDRemitente As Integer = idRemitente
            Dim sNombresRemitente As String = IIf(idRemitente = -1, "@", CboRemitente.Text) 'NConsignado
            Dim sNumeroDocumentoRemitente As String = IIf(sNroDocRemitente.Trim = "", "@", sNroDocRemitente.Trim)
            Dim iID_TipoDocumentoRemitente As Integer = iID_TipoDocRemitente
            Dim sNombreRemitente As String = IIf(iID_TipoDocRemitente = 1, "", sNombreRemitente) 'NConsignado
            Dim sApellidoPaternoRemitente As String = sApRemitente
            Dim sApellidoMaternoRemitente As String = sAmRemitente

            '=============================DATOS CONTACTO======================================                           
            'PARAMETRO ID_NOMBRE_CONTACTO**          
            If CboContacto.SelectedIndex = 0 Then
                idcontacto = -1
            End If

            If idcontacto = 0 AndAlso Me.ChkCliente1.Checked Then
                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.BuscarContacto(Me.TxtNroDocCliente.Text, TxtNroDocContacto.Text)
                Dim resp As Integer = dt.Rows.Count
                If resp = 0 Then
                    Me.TxtNroDocContacto.Tag = 0
                    idcontacto = 0
                Else
                    Me.TxtNroDocContacto.Tag = dt.Rows(0).Item(0)
                    idcontacto = dt.Rows(0).Item(0)
                    bContactoModificado = False
                End If
            End If

            Dim iContactoModificado As Integer = IIf(bContactoModificado, 1, 0)
            Dim iIDcontacto As Integer = idcontacto
            Dim sNombresContacto As String = IIf(idcontacto = -1, "@", CboContacto.Text) '            
            Dim sNumeroDocumentoContacto As String = IIf(Trim(TxtNroDocContacto.Text) <> "", TxtNroDocContacto.Text, "@")
            Dim iIDTipoDocumentoContacto As Integer = iID_TipoDocCont
            Dim sNombreContacto As String = IIf(iID_TipoDocCont = 1, "", NombresCont)
            Dim sApellidoPaternoContacto As String = apellPatCont
            Dim sApellidoMaternoContacto As String = apellMatCont

            '======================================CONSIGNADO=================================   
            '***Comentado x NConsignado****
            'If iIDConsignado = 0 AndAlso Me.ChkCliente2.Checked Then
            '    Dim objContacto As New dtoVentaCargaContado
            '    Dim dt As DataTable = objContacto.BuscarContacto(TxtNroDocConsignado.Text)
            '    Dim resp As Integer = dt.Rows.Count
            '    If resp = 0 Then
            '        iIDConsignado = 0
            '    Else
            '        iIDConsignado = dt.Rows(0).Item(0)
            '        bConsignadoModificado = False
            '    End If
            'End If

            '===Agregado x NConsignado==============================
            If iIDConsignado = 0 AndAlso Me.ChkCliente2.Checked Then
                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.BuscarContacto(GrdNConsignado("Nº Documento", 0).Value)
                Dim resp As Integer = dt.Rows.Count
                If resp = 0 Then
                    GrdNConsignado("IDConsignado", 0).Value = 0
                Else
                    GrdNConsignado("IDConsignado", 0).Value = dt.Rows(0).Item(0)
                    GrdNConsignado("Modificado", 0).Value = "0"
                End If
            End If

            '========================================================
            '***Comentado x NConsignado**
            'Dim iConsignadoModificado As Integer = IIf(bConsignadoModificado, 1, 0)
            'Dim iID_Consignado As Integer = IIf(IsNothing(iIDConsignado), 0, iIDConsignado)
            'Dim sNombresConsignado As String = "" ' IIf(Me.TxtNombConsignado.Text.Trim <> "", Me.TxtNombConsignado.Text.Trim, "@")
            'Dim sNumeroDocumentoConsignado As String = "" ' IIf(Trim(TxtNroDocConsignado.Text) <> "", TxtNroDocConsignado.Text, "@")
            'Dim iIDTipoDocumentoConsignado As Integer = iID_TipoDocConsig
            'Dim sNombreConsignado As String = sNombresConsig
            'Dim sApellidoPaternoConsignado As String = sapellPatConsig
            'Dim sApellidoMaternoConsignado As String = sapellMatConsig
            'Dim sTelefonoConsignado As String = IIf(sTelefonoConsig.Length > 0, sTelefonoConsig, "@")
            'rose

            '===Agregado x NConsignado==============================
            Dim iConsignadoModificado As String = ""
            Dim iID_Consignado As String = ""
            sNombresConsignado = ""
            Dim sNumeroDocumentoConsignado As String = ""
            Dim iIDTipoDocumentoConsignado As String = ""
            Dim sNombreConsignado As String = ""
            Dim sApellidoPaternoConsignado As String = ""
            Dim sApellidoMaternoConsignado As String = ""
            sTelefonoConsignado = ""

            For i As Integer = 0 To GrdNConsignado.Rows.Count() - 1
                iID_Consignado &= GrdNConsignado("IDConsignado", i).Value & IIf(GrdNConsignado("IDConsignado", i).Value.ToString.Trim.Length = 0, "", ";")
                sNombresConsignado &= GrdNConsignado("Nombres", i).Value & IIf(GrdNConsignado("Nombres", i).Value.ToString.Trim.Length = 0, "", ";")
                sNombreConsignado &= GrdNConsignado("nombre", i).Value & IIf(GrdNConsignado("nombre", i).Value.ToString.Trim.Length = 0, "", ";")
                sApellidoPaternoConsignado &= GrdNConsignado("apepat", i).Value & IIf(GrdNConsignado("apepat", i).Value.ToString.Trim.Length = 0, "", ";")
                sApellidoMaternoConsignado &= GrdNConsignado("apemat", i).Value & IIf(GrdNConsignado("apemat", i).Value.ToString.Trim.Length = 0, "", ";")
                sNumeroDocumentoConsignado &= GrdNConsignado("Nº Documento", i).Value & IIf(GrdNConsignado("Nº Documento", i).Value.ToString.Trim.Length = 0, "", ";")
                iIDTipoDocumentoConsignado &= GrdNConsignado("tipo", i).Value & IIf(GrdNConsignado("tipo", i).Value.ToString.Trim.Length = 0, "", ";")
                sTelefonoConsignado &= GrdNConsignado("Telefono", i).Value & IIf(GrdNConsignado("Telefono", i).Value.ToString.Trim.Length = 0, "", ";")
                iConsignadoModificado &= GrdNConsignado("Modificado", i).Value & IIf(GrdNConsignado("Modificado", i).Value.ToString.Trim.Length = 0, "", ";")
            Next
            '========================================================

            '*****DIRECCION ESTRUCTURADA CONSIGNADO*****
            'PARAMETRO ID_DIRECCION_DESTINO**
            If CboDireccion2.SelectedIndex = 0 Then
                idDireConsignado = -1
            End If
            ObjVentaCargaContado.v_IDDIREECION_DESTINO = idDireConsignado
            Dim iDirecConsignado_mod As Integer = IIf(bDirecConsigMod, 1, 0)
            ObjVentaCargaContado.v_DIRECCION_DESTINATARIO = IIf(idDireConsignado = -1, "@", CboDireccion2.Text)
            'ObjVentaCargaContado.id_DepartamentoConsig = iDepartamentoConsig
            'ObjVentaCargaContado.id_ProvinciaConsig = iProvinciaConsig
            'ObjVentaCargaContado.id_DistritoConsig = iDistritoConsig
            'ObjVentaCargaContado.id_viaConsig = IDviaConsig
            'ObjVentaCargaContado.viaConsig = ViaConsig
            'ObjVentaCargaContado.NumeroConsig = NroConsig
            'ObjVentaCargaContado.manzanaConsig = ManzanaConsig
            'ObjVentaCargaContado.loteConsig = loteConsig
            'ObjVentaCargaContado.id_nivelConsig = id_NivelConsig
            'ObjVentaCargaContado.nivelConsig = NivelConsig
            'ObjVentaCargaContado.id_zonaConsig = id_ZonaConsig
            'ObjVentaCargaContado.zonaConsig = ZonaConsig
            'ObjVentaCargaContado.id_clasificacionConsig = id_ClasificacionConsig
            'ObjVentaCargaContado.clasificacionConsig = ClasificacionConsig
            'ObjVentaCargaContado.formatoConsig = FormatoConsig

            '----------------------------------------------------------------------            
            Dim iIDTIPO_ENTREGA As Integer = CboTipoEntrega.SelectedValue 'PARAMETRO TIPO ENTREGA CARGA (Agencia,Domicilio)            
            Dim iIDFORMA_PAGO As Integer = 2 'PARAMETRO FORMA PAGO 'Int(objGuiaEnvio.coll_Lista_Forma_Pagos.Item(Me.cmbFormaCredito.SelectedIndex.ToString()))            
            Dim iAGENCIA_ORIGEN As Integer = objGuiaEnvio.iIDUNIDAD_AGENCIA 'PARAMETRO IDUNIDAD AGENCIA_ORIGEN  'agregar 'Int(coll_iOrigen.Item(iWinDestino.IndexOf(txtiWinOrigen.Text) + 1))
            Dim iIDCIUDAD_TRANSITO As Integer = objGuiaEnvio.iIDUNIDAD_AGENCIA 'PARAMETRO IDCIUDAD TRANSITO
            Dim iAGENCIA_DESTINO As Integer = idUnidadAgencias 'PARAMETRO IDAGENCIA DESTINO  'agregar'Int(coll_iDestino.Item(iWinDestino.IndexOf(txtiWinDestino.Text) + 1))
            Dim iIDAGENCIAS As Integer = dtoUSUARIOS.m_iIdAgencia 'PARAMETRO IDAGENCIAS'Agregar codigo           
            Dim sIDDIRECCION_REMITENTE As String = IdDireccionOrigen 'PARAMETRO IDDIRECCION REMITENTE

            'PARAMETRO IDTELEFONO REMITENTE
            'OBSERVACION
            'If iWinTelefono_Remitente.Count > 0 Then
            '    indexof = iWinTelefono_Remitente.IndexOf(txtTelefonoRemitente.Text)
            '    objGuiaEnvio.iIDTEFONO_REMITENTE = -1
            '    If indexof >= 0 Then
            '        objGuiaEnvio.iIDTEFONO_REMITENTE = Int(objGuiaEnvio.coll_Telefono_Remitente.Item(indexof.ToString))
            '    End If
            'End If
            Dim sIDCONTACTO_REMITENTE As String = idcontacto 'CboContacto.SelectedValue 'PARAMETRO IDCONTACTOREMITENTE
            Dim sIDTELEFONO_REMITENTE As String = 0 'PARAMETRO IDTELEFONO REMITENTE
            Dim sIDCONTACTO_DESTINATARIO As String = IIf(IsNothing(iIDConsignado), 0, iIDConsignado) 'CODIGO NOMBRE CONSIGNADO 'Int(objGuiaEnvio.coll_Nombres_Destinatario.Item(indexof.ToString))
            Dim sIDDIRECCION_DESTINATARIO As String = idDireConsignado  'CODIGO DIRECCION CONSIGNADO'Int(objGuiaEnvio.coll_Direccion_Destinatario.Item(indexof.ToString))

            'PARAMETRO IDTELEFONO CONSIGNADO
            'OBSERVACION
            'If iWinTelefono_Destinatario.Count > 0 Then
            '    indexof = iWinTelefono_Destinatario.IndexOf(txtTelefonoDestinatario.Text)
            '    objGuiaEnvio.iIDTEFONO_CONSIGNADO = -1
            '    If indexof >= 0 Then
            '        objGuiaEnvio.iIDTEFONO_CONSIGNADO = Int(objGuiaEnvio.coll_Telefono_Destinatario.Item(indexof.ToString))
            '    End If
            'End If
            Dim sIDTELEFONO_CONSIGNADO As String = 0 'PARAMETRO IDTELEFONO CONSIGNADO

            Dim iCANTIDAD As Integer = 0  'Unidades Peso
            Dim iCANTIDAD_X_UNIDAD_VOLUMEN As Integer = 0 'Unidades Volumen
            Dim iCANTIDAD_X_UNIDAD_ARTI As Integer = 0 'Unidades Articulos
            Dim dTOTAL_VOLUMEN As Double = 0
            Dim dTOTAL_PESO As Double = 0
            Dim iCANTIDAD_SOBRES As Integer
            Dim dMONTO_BASE As Double
            Dim dPrecio_x_Volumen As Double
            Dim dPrecio_x_Peso As Double
            Dim dPrecioSobre As Double

            Dim totalCosto As Double = 0
            Dim valor1 As Double = 0
            Dim valor2 As Double = 0

            'Camp1 = "Tipo" : camp2 = "Bulto" : camp3 = "Altura"
            'camp4 = "Ancho" : camp5 = "Largo" : camp6 = "Peso Kg"
            'camp7 = "Costo" : camp8 = "Sub Neto"

            If TipoGrid_ = FormatoGrid.BULTO Then
                Dim iBulto As Integer
                'BULTO
                If Val(GrdDetalleVenta("Bulto", 0).Value) = 0 Then
                    iBulto = 0
                Else
                    iBulto = GrdDetalleVenta("Bulto", 0).Value
                End If
                'iCANTIDAD = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Bulto", 0).Value.ToString)), "##,###,####.00")
                iCANTIDAD = Format(iBulto, "##,###,####.00")
                Dim iPeso As Double
                'PESO
                If Val(GrdDetalleVenta("Peso/Volumen", 0).Value) = 0 Then
                    iPeso = 0
                Else
                    iPeso = GrdDetalleVenta("Peso/Volumen", 0).Value
                End If
                'dTOTAL_PESO = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Peso/Volumen", 0).Value.ToString)), "##,###,####.00")
                dTOTAL_PESO = Format(iPeso, "##,###,####.00")

                dPrecio_x_Peso = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Costo", 0).Value.ToString)), "##,###,####.00") ' Costo x Peso                 

                'BULTO
                If Val(GrdDetalleVenta("Bulto", 1).Value) = 0 Then
                    iBulto = 0
                Else
                    iBulto = GrdDetalleVenta("Bulto", 1).Value
                End If
                'iCANTIDAD_X_UNIDAD_VOLUMEN = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Bulto", 1).Value.ToString)), "##,###,####.00")
                iCANTIDAD_X_UNIDAD_VOLUMEN = Format(iBulto, "##,###,####.00")

                'VOLUMEN
                Dim iVolumen As Double
                If Val(GrdDetalleVenta("Peso/Volumen", 1).Value) = 0 Then
                    iVolumen = 0
                Else
                    iVolumen = GrdDetalleVenta("Peso/Volumen", 1).Value
                End If
                'dTOTAL_VOLUMEN = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Peso/Volumen", 1).Value.ToString)), "##,###,####.00")
                dTOTAL_VOLUMEN = Format(iVolumen, "##,###,####.00")
                dPrecio_x_Volumen = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Costo", 1).Value.ToString)), "##,###,####.00") ' Costo x volumen 

                'SOBRE
                'BULTO
                If Val(GrdDetalleVenta("Bulto", 2).Value) = 0 Then
                    iBulto = 0
                Else
                    iBulto = GrdDetalleVenta("Bulto", 2).Value
                End If
                'iCANTIDAD_SOBRES = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Bulto", 2).Value.ToString)), "##,###,####.00")
                iCANTIDAD_SOBRES = Format(iBulto, "##,###,####.00")
                dPrecioSobre = tarifa_Sobre

                Dim iSobre As Double
                If Val(GrdDetalleVenta("Costo", 3).Value) = 0 Then
                    iSobre = 0
                Else
                    iSobre = GrdDetalleVenta("Costo", 3).Value
                End If
                'dMONTO_BASE = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Costo", 3).Value.ToString)), "##,###,####.00") ' Base
                dMONTO_BASE = Format(iSobre, "##,###,####.00") ' Base
            End If


            'PARAMETRO MONTO BASE            


            Dim iMetroCubico As Integer = 0
            If ChkM3.Checked Then
                iMetroCubico = 1
                valor2 = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Bulto", 0).Value.ToString)), "##,###,###.00")
                iCANTIDAD_X_UNIDAD_VOLUMEN = valor2 'PARAMETRO iCANTIDAD_X_UNIDAD_VOLUMEN
                valor1 = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Costo", 0).Value.ToString)), "##,###,###.00")
                valor2 = Format(Microsoft.VisualBasic.Conversion.Val(Trim(GrdDetalleVenta("Peso Kg", 0).Value.ToString)), "##,###,###.00")
                dTOTAL_VOLUMEN = valor2 'PARAMETRO DTOTAL_VOLUMEN

                'Comentado por Aldo Chavarría porque al momento de Insertar esta generando 1 etiqueta de codigo de barra mas
                'iCANTIDAD = GrdDetalleVenta.Rows.Count  'valor1 16112011


                ' totalCosto = totalCosto + valor1 * valor2 + Monto_Base
            End If


            If ChkArticulos.Checked Then
                Dim Total As Double = 0
                Dim ii1 As Integer = 0
                For ii1 = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                    Total = Total + Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii1).Cells(3).Value.ToString)
                    'PARAMETRO iCANTIDAD_X_UNIDAD_ARTI
                    If TipoGrid_ = FormatoGrid.ARTICULOS And CboTipo.SelectedValue = 2 And iID_Persona = ID_PERSONA_SODIMAC Then
                        iCANTIDAD_X_UNIDAD_ARTI = iCANTIDAD_X_UNIDAD_ARTI + Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii1).Cells("m3").Value.ToString)
                    Else
                        iCANTIDAD_X_UNIDAD_ARTI = iCANTIDAD_X_UNIDAD_ARTI + Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii1).Cells("cantidad").Value.ToString)
                    End If
                Next
            End If


            'PARAMETRO dPRECIO_X_UNIDAD
            Dim dPRECIO_X_UNIDAD As Double = tarifa_Articulo 'kgr
            'PARAMETRO dIMPUESTO
            Dim dIMPUESTO As Double = IGV
            'PARAMETRO dMONTO_IMPUESTO
            Dim dMONTO_IMPUESTO As Double = Me.TxtImpuesto.Text
            'PARAMETRO dTOTAL_COSTO
            Dim dTOTAL_COSTO As Double = Me.TxtTotal.Text
            'PARAMETRO iIDUSUARIO_PERSONAL
            Dim iIDUSUARIO_PERSONAL As Integer = dtoUSUARIOS.IdLogin
            'PARAMETRO iIDROL_USUARIO
            Dim iIDROL_USUARIO As Integer = dtoUSUARIOS.IdRol
            'PARAMETRO sIP
            Dim sIP As String = dtoUSUARIOS.IP
            'PARAMETRO iIDESTADO_REGISTRO
            Dim iIDESTADO_REGISTRO As Integer = 18

            'PARAMETRO iNOMBRES_REMITENTE
            Dim sNOMBRES_REMITENTE As String = ""
            If Me.CboRemitente.Text <> "" And Me.CboRemitente.Text.Length > 3 Then
                sNOMBRES_REMITENTE = Me.CboRemitente.Text
            Else
                sNOMBRES_REMITENTE = "NULL"
            End If

            'PARAMETRO iDNI_REMITENTE
            Dim sDNI_REMITENTE As String = ""
            If TxtNroDocContacto.Text <> "" And TxtNroDocContacto.Text.Length > 5 Then
                sDNI_REMITENTE = Me.TxtNroDocContacto.Text
            Else
                sDNI_REMITENTE = "@"
            End If

            'PARAMETRO iDIRECCION_REMITENTE
            Dim sDIRECCION_REMITENTE As String = ""
            If CboDireccion.Text <> "" And CboDireccion.Text.Length > 5 Then
                sDIRECCION_REMITENTE = CboDireccion.Text
            End If

            'PARAMETRO iNOMBRES_DESTINATARIO... (CONSIGNADO)
            Dim sNOMBRES_DESTINATARIO As String = ""
            'If TxtNombConsignado.Text <> "" And TxtNombConsignado.Text.Length > 5 Then
            '    sNOMBRES_DESTINATARIO = TxtNombConsignado.Text
            'End If 

            'PARAMETRO sDNI_DESTINATARIO
            Dim sDNI_DESTINATARIO As String = ""
            'If TxtNroDocConsignado.Text <> "" Then '19/08/2008 -  And txtDNIDestinatario.Text.Length > 5 Then ---> No se sabe el nº dcto del consignado
            '    sDNI_DESTINATARIO = TxtNroDocConsignado.Text
            'End If 

            'PARAMETRO iDIRECCION_DESTINATARIO
            Dim sDIRECCION_DESTINATARIO As String = ""
            If CboDireccion2.Text <> "" And CboDireccion2.Text.Length > 5 Then
                sDIRECCION_DESTINATARIO = CboDireccion2.Text
            End If
            'PARAMETRO iCARGO

            'hlamas 22-03-2016
            'Dim iCARGO As Integer = Int(ChkCargo.Checked)
            Dim iCARGO As Integer = Int(Me.rbtCargoSi.Checked)

            'hlamas 26-08-2015
            'hlamas 22-03-2016
            'If ModuUtil.TieneCargo(Me.GrdDocumentosCliente, 2) Then
            'iCARGO = 1
            'End If

            'PARAMETRO sTelefono_Remitente
            Dim sTelefono_Remitente As String = IIf(TxtTelfCliente.Text <> "", TxtTelfCliente.Text, "NULL")
            'PARAMETRO sTelefono_Destinatario
            Dim sTelefono_Destinatario As String = "" 'IIf(TxtTelfConsignado.Text <> "", TxtTelfConsignado.Text, "NULL") 

            'PARAMETRO iID_REMITENTE
            Dim sID_REMITENTE As String = 0
            'PARAMETRO iREMITENTE 
            Dim sREMITENTE As String = CboRemitente.Text 'OBSERVACION
            'PARAMETRO iNRODOC_REM
            Dim sNRODOC_REM As String = TxtNumDocRemitente.Text
            'PARAMETRO iIDCENTRO_COSTO
            Dim iIDCENTRO_COSTO As Integer = CboSubCuenta.SelectedValue


            Dim iIDSINO_SOBRES As Integer
            If ChkSobres.Checked = True Then
                'PARAMETRO iCANTIDAD_SOBRES
                iCANTIDAD_SOBRES = Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
                'PARAMETRO iIDSINO_SOBRES
                iIDSINO_SOBRES = 1
            End If

            'PARAMETRO iIDAGENCIAS_DESTINO
            Dim iIDAGENCIAS_DESTINO As Integer = CboAgenciaDest.SelectedValue

            objGuiaEnvio.iIDCONTACTO_PERSONA = 0
            objGuiaEnvio.iIDDIRECCION_CONSIGNADO = 0


            'OBSERVACION
            'If Me.dtGridViewArticulo.Visible = True Then
            '    objGuiaEnvio.dTOTAL_PESO = fn_peso_desde_articulos()
            'End If

            'If Me.dtGridViewArticulo.Visible = True Then
            '    objGuiaEnvio.dTOTAL_VOLUMEN = fn_Volumen_desde_articulos()
            'End If

            '----------------------------------------------------------------------------------------------------------------------            
            'objGuiaEnvio.dMONTO_BASE = Monto_Base '26/08/2008  Se toma el valor de los bultos                       
            iTOTAL_BULTOS = ""
            iTOTAL_VOLUMEN = ""
            iTOTAL_PESO = ""
            objGuiaEnvio.iCANTIDAD = iCANTIDAD
            objGuiaEnvio.iCANTIDAD_X_UNIDAD_VOLUMEN = iCANTIDAD_X_UNIDAD_VOLUMEN
            objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = iCANTIDAD_X_UNIDAD_ARTI
            objGuiaEnvio.iCANTIDAD_SOBRES = iCANTIDAD_SOBRES
            objGuiaEnvio.dTOTAL_VOLUMEN = dTOTAL_VOLUMEN
            objGuiaEnvio.dTOTAL_PESO = dTOTAL_PESO
            objGuiaEnvio.iIDTIPO_ENTREGA_CARGA = Me.CboTipoEntrega.SelectedValue
            objGuiaEnvio.iIDFORMA_PAGO = 1

            Dim sReferencia As String = TxtReferencia.Text.Trim
            Dim iDescuento As Double = IIf(TxtDescuento.Text.Trim <> "", TxtDescuento.Text, 0)
            Dim sAutoriza As String = IIf(TxtDescuento.Text.Trim <> "", txtDescDescto.Text, "")
            Dim strFechaRecojo As String = ""
            If Me.dtpFechaRecojo.Visible Then
                strFechaRecojo = Me.dtpFechaRecojo.Value.ToShortDateString
            End If

            '=========================================================
            If objGuiaEnvio.GrabarGuiaCredito(0, sFECHA_GUIA, sNRO_GUIA, iIDTIPO_ENTREGA, iIDFORMA_PAGO, _
                                              iAGENCIA_ORIGEN, iIDCIUDAD_TRANSITO, iAGENCIA_DESTINO, iIDAGENCIAS, sIDCONTACTO_REMITENTE, _
                                              sIDDIRECCION_REMITENTE, sIDTELEFONO_REMITENTE, sIDCONTACTO_DESTINATARIO, sIDDIRECCION_DESTINATARIO, _
                                              sIDTELEFONO_CONSIGNADO, dMONTO_BASE, dTOTAL_PESO, iCANTIDAD, dTOTAL_VOLUMEN, iCANTIDAD_X_UNIDAD_VOLUMEN, _
                                              iCANTIDAD_X_UNIDAD_ARTI, dPRECIO_X_UNIDAD, dIMPUESTO, dMONTO_IMPUESTO, dTOTAL_COSTO, iIDUSUARIO_PERSONAL, _
                                              iIDROL_USUARIO, sIP, iIDESTADO_REGISTRO, sNOMBRES_REMITENTE, sDNI_REMITENTE, sDIRECCION_REMITENTE, _
                                              sNOMBRES_DESTINATARIO, sDNI_DESTINATARIO, sDIRECCION_DESTINATARIO, dPrecio_x_Volumen, dPrecio_x_Peso, dPrecioSobre, _
                                              iCARGO, sTelefono_Remitente, sTelefono_Destinatario, sID_REMITENTE, sREMITENTE, sNRODOC_REM, iIDCENTRO_COSTO, _
                                              iCANTIDAD_SOBRES, iIDSINO_SOBRES, iIDAGENCIAS_DESTINO, iClienteModificado, iIDPERSONA, sNombresCliente, _
                                              sNumeroDocumentoCliente, iID_TipoDocumentoCliente, sNombreCliente, sApellidoPaternoCliente, _
                                              sApellidoMaternoCliente, TelefonoCliente, iRemitenteModificado, iIDRemitente, sNombresRemitente, _
                                              sNumeroDocumentoRemitente, iID_TipoDocumentoRemitente, sNombreRemitente, sApellidoPaternoRemitente, _
                                              sApellidoMaternoRemitente, iContactoModificado, iIDcontacto, sNombresContacto, sNumeroDocumentoContacto, _
                                              iIDTipoDocumentoContacto, sNombreContacto, sApellidoPaternoContacto, sApellidoMaternoContacto, _
                                             iConsignadoModificado, iID_Consignado, sNombresConsignado, sNumeroDocumentoConsignado, _
                                             iIDTipoDocumentoConsignado, sNombreConsignado, sApellidoPaternoConsignado, sApellidoMaternoConsignado, _
                                             sTelefonoConsignado, iDireccionCliente_Mod, iDepartamentoCli, iProvinciaCli, iDistritoCli,
                                             IDviaCli, ViaCli, NroCli, ManzanaCli, loteCli, id_NivelCli, NivelCli, id_ZonaCli, ZonaCli, _
                                             id_ClasificacionCli, ClasificacionCli, iDirecConsignado_mod, iDepartamentoConsig, iProvinciaConsig, _
                                             iDistritoConsig, IDviaConsig, ViaConsig, NroConsig, ManzanaConsig, loteConsig, id_NivelConsig, _
                                             NivelConsig, id_ZonaConsig, ZonaConsig, id_ClasificacionConsig, ClasificacionConsig, sEmail, sReferencia, iMetroCubico, iDescuento, sAutoriza, CboTipoTarifa.SelectedValue, strObservacionCargo, 1, _
                                             CboProducto.SelectedValue, txtdt.Text.Trim, CboSubCuentaOrigen.SelectedValue, strFechaRecojo) = True Then

                iTOTAL_BULTOS = objGuiaEnvio.iCANTIDAD + objGuiaEnvio.iCANTIDAD_X_UNIDAD_VOLUMEN + objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI + objGuiaEnvio.iCANTIDAD_SOBRES
                iTOTAL_VOLUMEN = objGuiaEnvio.dTOTAL_VOLUMEN
                iTOTAL_PESO = objGuiaEnvio.dTOTAL_PESO

                '------------------------------------------------------------------------------
                '------ Datos para Grabar el Checkpoint del Ingreso de Carga al Almacen -------
                '------------------------------------------------------------------------------
                objMantenimientoCheckpoint.Comprobante = objGuiaEnvio.iIDGUIAS_ENVIO
                objMantenimientoCheckpoint.TipoComprobante = 3
                objMantenimientoCheckpoint.Checkpoint = 1
                objMantenimientoCheckpoint.CantidadBultos = 0

                If ChkArticulos.Checked = True Then
                    For ii As Integer = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                        If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                            If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
                                objMantenimientoCheckpoint.CantidadBultos = objMantenimientoCheckpoint.CantidadBultos + Int(GrdDetalleVenta.Rows(ii).Cells("Cantidad").Value.ToString)
                            End If
                        End If
                    Next
                    objMantenimientoCheckpoint.CantidadBultos = objMantenimientoCheckpoint.CantidadBultos + objGuiaEnvio.iCANTIDAD_SOBRES
                ElseIf ChkM3.Checked = True Then
                    For ii As Integer = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                        If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                            If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
                                objMantenimientoCheckpoint.CantidadBultos = objMantenimientoCheckpoint.CantidadBultos + GrdDetalleVenta.Rows(ii).Cells("Bulto").Value
                            End If
                        End If
                    Next
                    objMantenimientoCheckpoint.CantidadBultos = objMantenimientoCheckpoint.CantidadBultos + objGuiaEnvio.iCANTIDAD_SOBRES
                Else
                    objMantenimientoCheckpoint.CantidadBultos = iTOTAL_BULTOS
                End If

                'hlamas 19-11-2014 no necesita ingresar a almacen, porque nunca sale del almacen
                'objMantenimientoCheckpoint.fncInsertarTrackingCheckpoint()
                '------------------------------------------------------------------------------
                '------------------------------------------------------------------------------


                '-----------------------------------------------------------------
                'INSERCION VOLUMETRICO
                '-----------------------------------------------------------------
                Try
                    If ChkM3.Checked = True Then
                        Dim obj As New dtoVentaCargaContado
                        Dim ii As Integer = 0
                        objGuia_Envio_Articulo.iIDGUIAS_ENVIO = objGuiaEnvio.iIDGUIAS_ENVIO
                        objGuia_Envio_Articulo.iIGV = dtoUSUARIOS.iIGV
                        objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
                        objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                        objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol

                        For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                            If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                                If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
                                    obj.FNinsert_Volumetrico(
                                             ii,
                                             0,
                                             objGuiaEnvio.iIDGUIAS_ENVIO,
                                             GrdDetalleVenta.Rows(ii).Cells("Tipo").Value,
                                             GrdDetalleVenta.Rows(ii).Cells("Bulto").Value,
                                             GrdDetalleVenta.Rows(ii).Cells("Altura").Value,
                                             GrdDetalleVenta.Rows(ii).Cells("Ancho").Value,
                                             GrdDetalleVenta.Rows(ii).Cells("Largo").Value,
                                             GrdDetalleVenta.Rows(ii).Cells("Peso Kg").Value,
                                             dFactor,
                                             GrdDetalleVenta.Rows(ii).Cells("Costo").Value)
                                End If
                            End If
                        Next
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                '-----------------------------------------------------------------
                'INSERCION DE ARTICULOS
                '-----------------------------------------------------------------                
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

                If ChkArticulos.Checked = True Then
                    For ii As Integer = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                        If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                            If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
                                objGuia_Envio_Articulo.iIDARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells("IDARTICULO").Value.ToString)

                                'hlamas 04-10-2019
                                If TipoGrid_ = FormatoGrid.ARTICULOS And CboTipo.SelectedValue = 2 And iID_Persona = ID_PERSONA_SODIMAC Then
                                    objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells("m3").Value.ToString)
                                    objGuia_Envio_Articulo.iMETRO_CUBICO = CDbl(GrdDetalleVenta.Rows(ii).Cells("cantidad").Value.ToString)
                                Else
                                    objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells("Cantidad").Value.ToString)
                                    If GrdDetalleVenta.Rows(ii).Cells("M3").Value.ToString = "" Then
                                        objGuia_Envio_Articulo.iMETRO_CUBICO = 0
                                    Else
                                        objGuia_Envio_Articulo.iMETRO_CUBICO = CDbl(GrdDetalleVenta.Rows(ii).Cells("M3").Value.ToString)
                                    End If
                                End If
                                objGuia_Envio_Articulo.iPESO = Int(GrdDetalleVenta.Rows(ii).Cells("Peso").Value.ToString)
                                objGuia_Envio_Articulo.iPRECIO_X_ARTICULO = Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii).Cells("Precio").Value.ToString)
                                objGuia_Envio_Articulo.fnINSTUPD_GENVIO_ARTICULOS_RGT()
                            End If
                        End If
                    Next
                End If


                '---------------DETALLE DOCUMENTOS----------------------------------
                flat = True
                Dim i As Integer = 0
                Dim serie_NroDoc() As String
                objGuiaEnvio.iControl_Documentos = 1
                Dim iContador As Integer = 0

                For i = 0 To Me.GrdDocumentosCliente.Rows().Count() - 2
                    Try
                        If IsDBNull(GrdDocumentosCliente.Rows(i).Cells("Cargo")) = False Then
                            If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells("Cargo").Value) Then
                                serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells("Cargo").Value.ToString, "-")
                                If serie_NroDoc.Length > 1 Then
                                    objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                    objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                                    strNroGuias_Remision = strNroGuias_Remision & "  " & objGuiaEnvio.iNro_Serie & "-" & objGuiaEnvio.iNro_Docu
                                    If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                        If objGuiaEnvio.fnINSUPD_DOCUMENTOS_GUIAS() = True Then
                                            iContador = iContador + 1
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    Try
                        If IsDBNull(GrdDocumentosCliente.Rows(i).Cells("Seguro")) = False Then
                            If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells("Seguro").Value) Then
                                serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells("Seguro").Value.ToString, "-")
                                If serie_NroDoc.Length > 1 Then
                                    objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                    objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                                    strNroGuias_Remision = strNroGuias_Remision & "  " & objGuiaEnvio.iNro_Serie & "-" & objGuiaEnvio.iNro_Docu
                                    If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                        If objGuiaEnvio.fnINSUPD_DOCUMENTOS_GUIAS() = True Then
                                            iContador = iContador + 1
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Next
                'End If
            Else
                Me.Cursor = Cursors.Default
                'MessageBox.Show("La Guia no se Registró", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                flat = False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
            flat = False
        End Try
        Return flat
    End Function

    '-----------NUEVO CODIGO NCONSIGNADO--------   
    Sub DiseñaGrdNConsignado()
        Try

            Dim Camp0 As String = "", camp1 = "", camp2 = "", camp3 = "", camp4 = "", camp5 = "", camp6 = "", camp7 = "", camp8 = "", camp9 = ""
            Camp0 = "IDConsignado" : camp1 = "Nº Documento" : camp2 = "Nombres" : camp3 = "Telefono"
            camp4 = "nombre" : camp5 = "tipo" : camp6 = "apepat" : camp7 = "apemat" : camp8 = "Modificado" : camp9 = "Existe"

            With GrdNConsignado
                .Columns.Clear()
                .Font = New Font("Arial", 8.0!, FontStyle.Regular)
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AllowUserToResizeColumns = False
                .AutoGenerateColumns = False
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .RowHeadersVisible = True
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ScrollBars = ScrollBars.Both
                .RowHeadersWidth = 10
                .DefaultCellStyle.WrapMode = DataGridViewTriState.False
                '.DefaultCellStyle.WrapMode = DataGridViewTriState.True
                '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
                '.DefaultCellStyle.SelectionForeColor = Color.Black

                Dim col0 As New DataGridViewTextBoxColumn
                With col0
                    .HeaderText = Camp0
                    .Name = Camp0
                    .DataPropertyName = Camp0
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .ReadOnly = True
                    .Visible = False
                End With
                .Columns.Add(col0)

                Dim col1 As New DataGridViewTextBoxColumn
                With col1
                    .HeaderText = "N. Doc."
                    .Name = "Nº Documento"
                    .DataPropertyName = "Nº Documento"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .ReadOnly = True
                    '.Width = 75
                End With
                .Columns.Add(col1)

                Dim col2 As New DataGridViewTextBoxColumn
                With col2
                    .HeaderText = camp2
                    .Name = camp2
                    .DataPropertyName = camp2
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .ReadOnly = True
                    '.Width = 300
                End With
                .Columns.Add(col2)


                Dim col3 As New DataGridViewTextBoxColumn
                With col3
                    .HeaderText = camp3
                    .Name = camp3
                    .DataPropertyName = camp3
                    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .ReadOnly = True
                End With
                .Columns.Add(col3)

                Dim col4 As New DataGridViewTextBoxColumn
                With col4
                    .HeaderText = camp4
                    .Name = camp4
                    .DataPropertyName = camp4
                    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .Visible = False
                End With
                .Columns.Add(col4)

                Dim col5 As New DataGridViewTextBoxColumn
                With col5
                    .HeaderText = camp5
                    .Name = camp5
                    .DataPropertyName = camp5
                    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .Visible = False
                End With
                .Columns.Add(col5)

                Dim col6 As New DataGridViewTextBoxColumn
                With col6
                    .HeaderText = camp6
                    .Name = camp6
                    .DataPropertyName = camp6
                    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .Visible = False
                End With
                .Columns.Add(col6)

                Dim col7 As New DataGridViewTextBoxColumn
                With col7
                    .HeaderText = camp7
                    .Name = camp7
                    .DataPropertyName = camp7
                    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .Visible = False
                End With
                .Columns.Add(col7)

                Dim col8 As New DataGridViewTextBoxColumn
                With col8
                    .HeaderText = camp8
                    .Name = camp8
                    .DataPropertyName = camp8
                    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .Visible = False
                End With
                .Columns.Add(col8)

                Dim col9 As New DataGridViewTextBoxColumn
                With col9
                    .HeaderText = camp9
                    .Name = camp9
                    .DataPropertyName = camp9
                    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .Visible = False
                End With
                .Columns.Add(col9)
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub LimpiarNConsignados()
        ObjVentaCargaContado.v_IDCONTACTO_DESTINO = ""
        ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = ""
        ObjVentaCargaContado.NombreConsignado = ""
        ObjVentaCargaContado.apellPatConsig = ""
        ObjVentaCargaContado.apellMatConsig = ""
        ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO = ""
        ObjVentaCargaContado.ID_TipoDocConsig = ""
        ObjVentaCargaContado.TelfConsignado = ""
        ObjVentaCargaContado.NombConsignado_mod = ""
    End Sub

    'ACTUALIZA O REGISTRA NUEVO CONSIGNADO
    Dim indice As Integer = 0
    Dim bNuevo As Boolean = True
    Dim bExiste As Boolean
    Dim iNroDocumentoTag As Integer
    Public DTNconsignado As DataTable

    Dim row As Integer
    Private Sub ActualizarGrid(ByVal ds As DataSet)
        row = GrdNConsignado.Rows.Count()
        GrdNConsignado.Rows.Add()
        GrdNConsignado("IDConsignado", row).Value = iIDConsignado
        GrdNConsignado("Nº Documento", row).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("nrodocumento")), "", ds.Tables(0).Rows(0).Item("nrodocumento"))
        GrdNConsignado("Nombres", row).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("nombres")), "", ds.Tables(0).Rows(0).Item("nombres"))
        GrdNConsignado("Telefono", row).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("telefono")), "", ds.Tables(0).Rows(0).Item("telefono"))
        GrdNConsignado("nombre", row).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("nombre")), "", ds.Tables(0).Rows(0).Item("nombre"))
        GrdNConsignado("tipo", row).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("tipo")), "", ds.Tables(0).Rows(0).Item("tipo"))
        GrdNConsignado("apepat", row).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("apepat")), "", ds.Tables(0).Rows(0).Item("apepat"))
        GrdNConsignado("apemat", row).Value = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("apemat")), "", ds.Tables(0).Rows(0).Item("apemat"))
        GrdNConsignado("Modificado", row).Value = "0"
        GrdNConsignado("Existe", row).Value = "Y"

        Me.TxtConsignado.Text = ""
        RemoveHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
        If Me.TxtNroDocCliente.Text.Trim = GrdNConsignado("Nº Documento", row).Value AndAlso Me.TxtNroDocCliente.Text.Trim <> "" Then Me.ChkCliente2.Checked = True Else Me.ChkCliente2.Checked = False
        AddHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
        '=======================================================================================
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If GrdNConsignado.Rows.Count > 0 Then
            Dim iResp As Integer = MessageBox.Show("¿Está Seguro de Eliminar el Consignado?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If iResp = vbYes Then
                Me.EliminarItem()
            End If
        End If
    End Sub

    Sub EliminarItem()
        Me.GrdNConsignado.Rows.Remove(Me.GrdNConsignado.CurrentRow)
        If ChkCliente2.Checked Then ChkCliente2.Checked = False
    End Sub

    Dim iIndice As Integer   
    Private Sub GrdNConsignado_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdNConsignado.RowEnter
        iIndice = e.RowIndex
    End Sub

    Private Sub TxtCiudadDestino_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCiudadDestino.TextChanged
        If blnAgencia = True Then
            TxtCiudadDestino_LostFocus(sender, e)
        End If
    End Sub

    Sub CutCopyPaste(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TxtCliente.KeyDown, TxtConsignado.KeyDown, TxtNomCliente.KeyDown, TxtNroDocCliente.KeyDown, TxtNroDocContacto.KeyDown, TxtReferencia.KeyDown, TxtTelfCliente.KeyDown
        If e.Control Then
            If e.KeyCode = Keys.V Then
                'CType(sender, TextBox).Text = Clipboard.GetDataObject().GetData(DataFormats.Text)
                CType(sender, TextBox).Paste()
            ElseIf CType(sender, TextBox).Text.Trim.Length > 0 And (e.KeyCode = Keys.X Or e.KeyCode = Keys.C) Then
                Clipboard.Clear()
                'Clipboard.SetText(CType(sender, TextBox).Text)
                CType(sender, TextBox).Copy()
                If e.KeyCode = Keys.X Then
                    CType(sender, TextBox).SelectedText = ""
                End If
            End If
        End If
    End Sub

    Private Sub RbtNombre3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtNombre3.CheckedChanged
        Me.TxtConsignado.Text = ""
        If CType(sender, RadioButton).Name = "RbtDocumento" Then
            Me.TxtConsignado.MaxLength = 11
        Else
            Me.TxtConsignado.MaxLength = 50
        End If
        Me.TxtConsignado.Focus()
    End Sub

    Private Sub RbtDocumento3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtDocumento3.CheckedChanged
        Me.TxtConsignado.Text = ""
        If CType(sender, RadioButton).Name = "RbtDocumento" Then
            Me.TxtConsignado.MaxLength = 11
        Else
            Me.TxtConsignado.MaxLength = 50
        End If
        Me.TxtConsignado.Focus()
    End Sub


    'Validar la Guia de envio por cliente, es de retorno, subcuenta propia
    'Private Function fncValidarEnvioRetorno_Destino_CentroCosto()
    '    Dim obj As New dtoGuiaEnvio
    '    Dim blnOk As Boolean = False
    '    Try

    '        Dim ds As DataSet = obj.ValidarGuiaEnvioRetornoCliente(idUnidadAgencias, iID_Persona, CboSubCuenta.SelectedValue)

    '        If Not IsDBNull(ds) Then
    '            If ds.Tables(0).Rows.Count = 1 Then
    '                If Convert.ToInt32(ds.Tables(0).Rows(0).Item("idtipo_centro_costo").ToString) = 1 Then

    '                    If TipoGrid_ = FormatoGrid.BULTO Then

    '                        If Convert.ToInt32(ds.Tables(0).Rows(0).Item("Peso").ToString) = 0 Then
    '                            Me.GrdDetalleVenta.Rows(0).Cells("Bulto").ReadOnly = True
    '                            Me.GrdDetalleVenta.Rows(0).Cells("Peso/Volumen").ReadOnly = True
    '                        Else
    '                            Me.GrdDetalleVenta.Rows(0).Cells("Bulto").ReadOnly = False
    '                            Me.GrdDetalleVenta.Rows(0).Cells("Peso/Volumen").ReadOnly = False
    '                        End If

    '                        If Convert.ToInt32(ds.Tables(0).Rows(0).Item("Volumen").ToString) = 0 Then
    '                            Me.GrdDetalleVenta.Rows(1).Cells("Bulto").ReadOnly = True
    '                            Me.GrdDetalleVenta.Rows(1).Cells("Peso/Volumen").ReadOnly = True
    '                        Else
    '                            Me.GrdDetalleVenta.Rows(1).Cells("Bulto").ReadOnly = False
    '                            Me.GrdDetalleVenta.Rows(1).Cells("Peso/Volumen").ReadOnly = False
    '                        End If

    '                        Monto_Base = 0
    '                        Me.GrdDetalleVenta.Rows(3).Cells("Costo").Value = Math.Round(Monto_Base, 2)
    '                        Me.GrdDetalleVenta.Rows(3).Cells("Sub Neto").Value = Math.Round(Monto_Base, 2)
    '                        blnOk = True
    '                    End If
    '                End If
    '            End If
    '        End If

    '        If blnOk = False Then
    '            Me.GrdDetalleVenta.Rows(0).Cells("Bulto").ReadOnly = False
    '            Me.GrdDetalleVenta.Rows(0).Cells("Peso/Volumen").ReadOnly = False

    '            Me.GrdDetalleVenta.Rows(1).Cells("Bulto").ReadOnly = False
    '            Me.GrdDetalleVenta.Rows(1).Cells("Peso/Volumen").ReadOnly = False

    '            Me.GrdDetalleVenta.Rows(2).Cells("Bulto").ReadOnly = False
    '            Me.GrdDetalleVenta.Rows(2).Cells("Peso/Volumen").ReadOnly = False

    '        End If
    '        Me.GrdDetalleVenta.Rows(3).Cells("Bulto").ReadOnly = True
    '        Me.GrdDetalleVenta.Rows(3).Cells("Peso/Volumen").ReadOnly = True
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Function
    '-------------------------------------------- FUNCION PARA LLAMAR LAS PRE-GUIAS----------------------------------------------------------
    '---------------------------------------------DIEGO ZEGARRA------------------------------------------------------------------------------
    '-----------------------------------------------29-04-2013-------------------------------------------------------------------------------
    '-----------------------------------------------4 CAPAS------------------------------------------------------------------------

   
    Private Sub txtNroNroGuia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroNroGuia.KeyPress
        'If Not ValidarNumero(e.KeyChar) Then
        '    e.Handled = True
        'End If

    End Sub

    Private Sub BtnPreGuia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPreGuia.Click

        Dim P_NroGuia As String
        P_NroGuia = txtNroNroGuia.Text

        If (P_NroGuia <> 0) Then
            f_Retrieve(P_NroGuia)
        Else
            MsgBox("El Numero de Guia debe de ser Diferente de Cero")
        End If
    End Sub


    Private Function f_Retrieve(ByVal v_NroGuia As String) As Integer

        Dim ObjClassBuscarPreguias_LN As New Cls_BuscarPreGuias_LN
        Windows.Forms.Cursor.Show()
        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        'dtResultado = ObjClassBuscarPreguias_LN.BuscarNroGuia_LN(v_NroGuia)
        'TxtCiudadDestino.Text = dtResultado.Rows(0).Item("DESTINO")

        '    dtResultado = ObjClassBuscarPreguias_LN.BuscarNroGuia_LN(v_NroGuia)
        '    If IsDBNull(dtResultado.Rows(0).Item("ORIGEN")) Then
        '        LblCiudad.Text = Nothing
        '    Else
        '        LblCiudad.Text = dtResultado.Rows(0).Item("ORIGEN")
        '    End If
        '    If IsDBNull(dtResultado.Rows(0).Item("DESTINO")) Then
        '        TxtCiudadDestino.Text = ""
        '    Else
        '        TxtCiudadDestino.Text = dtResultado.Rows(0).Item("DESTINO")
        '    End If

        Dim custDataset As New DataSet
        Dim dtResultado As New DataTable
        dtResultado = ObjClassBuscarPreguias_LN.BuscarNroGuia_LN(v_NroGuia)

        If (dtResultado.Rows.Count > 0) Then
            TxtCiudadDestino.Text = IIf(IsDBNull(dtResultado.Rows(0)("DESTINO")), "", dtResultado.Rows(0)("DESTINO"))
            CboTipoEntrega.Text = IIf(IsDBNull(dtResultado.Rows(0)("TIPO_ENTREGA")), "", dtResultado.Rows(0)("TIPO_ENTREGA"))
            LblCiudad.Text = IIf(IsDBNull(dtResultado.Rows(0)("ORIGEN")), "", dtResultado.Rows(0)("ORIGEN"))
            BuscarClienteCredito()
        Else
            f_limpiar()
            MsgBox("El Nro de Guia no Existe")
            Close()

        End If

        '  f_limpiar()

        ' Estoy Obteniendo la Descripcion de Destino Agencia
        Dim sender As Object
        Dim e As New System.ComponentModel.CancelEventArgs
        TxtCiudadDestino_LostFocus(sender, e)

        'TxtCliente.Text = dtResultado.Rows(0).Item("CLIENTE")
        RbtNombre.Checked = True
        TxtCliente.Text = IIf(IsDBNull(dtResultado.Rows(0).Item("CLIENTE")), "", dtResultado.Rows(0).Item("CLIENTE"))
        CboDireccion.Text = dtResultado.Rows(0).Item("DIRECCION_REMITENTE")
        CboDireccion.Items.Add("DIRECCION_REMITENTE")

        'CboDireccion.Items.Clear()
        'Dim cadena As String
        'cadena = CboDireccion.Items("DIRECCION_REMITENTE")S

        'If (cadena Is DBNull.Value) Then
        '    CboDireccion.Text = dtResultado.Rows(0).Item("DIRECCION_REMITENTE")
        'End If




        ' CboDireccion.Text = dtResultado.Rows(0).Item("DIRECCION_REMITENTE")



        ' fin
        'RbtNombre3.Checked = True
        'TxtConsignado.Text = dtResultado.Rows(0).Item("CONSIGNADO")



    End Function

    Sub f_limpiar()
        TxtCiudadDestino.Text = ""
        LblCiudad.Text = ""
        CboTipoEntrega.Items.Clear()
    End Sub

    Private Sub txtdt_GotFocus(sender As Object, e As System.EventArgs) Handles txtdt.GotFocus
        Me.txtdt.SelectAll()
    End Sub
    Private Sub txtdt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdt.KeyPress
        If (Char.IsDigit(e.KeyChar)) Then
            e.Handled = False
        ElseIf (Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Sub ControlaSubcuentaOrigen(estado As Boolean)
        If Not estado Then
            Me.CboSubCuentaOrigen.Enabled = False
        Else
            Me.CboSubCuentaOrigen.Enabled = True
        End If
    End Sub

    Sub CargarSubcuentaDestino(cliente As Integer, ciudad As Integer)
        objGuiaEnvio.dt_cur_Sub_Cuenta_Destino = dtoVentaCargaContado.ListarSubcuentas(cliente, ciudad)
        If (objGuiaEnvio.dt_cur_Sub_Cuenta_Destino.Rows.Count > 0) Then
            With Me.CboSubCuenta
                .DataSource = objGuiaEnvio.dt_cur_Sub_Cuenta_Destino
                .DisplayMember = "CENTRO_COSTO"
                .ValueMember = "IDCENTRO_COSTO"
                .SelectedValue = 999
            End With
        End If
    End Sub

    Sub CargarSubcuentaOrigen(cliente As Integer, ciudad As Integer)
        objGuiaEnvio.dt_cur_Sub_Cuenta = dtoVentaCargaContado.ListarSubcuentas(cliente, ciudad)
        If (objGuiaEnvio.dt_cur_Sub_Cuenta.Rows.Count > 0) Then
            With Me.CboSubCuentaOrigen
                .DataSource = objGuiaEnvio.dt_cur_Sub_Cuenta
                .DisplayMember = "CENTRO_COSTO"
                .ValueMember = "IDCENTRO_COSTO"
                .SelectedValue = 999
            End With
            If ID_PERSONA_ECKERD = cliente And Me.CboTipo.SelectedIndex = 1 Then
                Me.ControlaSubcuentaOrigen(True)
            Else
                Me.ControlaSubcuentaOrigen(False)
            End If
        End If

    End Sub

#Region "Entrega Domicilio"

    Sub GestionaTarifaDomicilio(TipoEntrega As Integer, origen As Integer, destino As Integer, producto As Integer, tipo_tarifa As Integer, tipo_visibilidad As Integer, servicio As Integer, cliente As Integer)
        'If TipoEntrega <> 2 Or origen = 0 Or destino = 0 Or producto = -1 Or tipo_tarifa = -1 Or tipo_visibilidad = 0 Then
        If origen = 0 Or destino = 0 Or producto = -1 Or tipo_tarifa = -1 Or tipo_visibilidad = 0 Then
            EliminarItemVenta("ENTREGA", GrdDetalleVenta)
            dtTarifaServicio = Nothing
            dblMontoEntregaDomicilio = 0
        Else
            dtTarifaServicio = ObtieneTarifaServicio(origen, destino, producto, 3, tipo_visibilidad, servicio, cliente)
            If dtTarifaServicio.Rows.Count > 0 Then
                AgregarItemVenta("ENTREGA", GrdDetalleVenta)
            Else
                EliminarItemVenta("ENTREGA", GrdDetalleVenta)
                dtTarifaServicio = Nothing
                dblMontoEntregaDomicilio = 0
            End If
        End If
        If GrdDetalleVenta.Rows.Count = 0 Then Return
        'hlamas 26-08-2015
        'Tarifa entrega es solo para contado
        If Me.CboTipo.SelectedIndex = 1 Then Return

        If TipoGrid_ = FormatoGrid.BULTO Then
            fnTotalPago()
        ElseIf TipoGrid_ <> FormatoGrid.ARTICULOS Then
            iROW = 0
            Calculo_M3()
        End If
    End Sub

    Function ObtieneTarifaServicio(origen As Integer, destino As Integer, producto As Integer, tipo_tarifa As Integer, tipo_visibilidad As Integer, servicio As Integer, cliente As Integer) As DataTable
        Dim objTarifaLN As New Cls_TarifaServicio_LN
        Dim dt As DataTable = objTarifaLN.ObtenerTarifaServicio(origen, destino, producto, tipo_tarifa, tipo_visibilidad, servicio, cliente, 1)
        Return dt
    End Function

    Sub ActualizaDireccion(cbo As ComboBox)
        Dim obj As New dtoGuiaEnvio
        Dim dt As DataTable = obj.ClienteDireccion(iID_Persona, dtoUSUARIOS.m_idciudad, idUnidadAgencias)
        With cbo
            dtDireccion2 = dt
            .DataSource = dt
            .DisplayMember = "direccion"
            .ValueMember = "iddireccion_consignado"
        End With
    End Sub

    Function CalculaPromocion() As Integer
        Dim intDescuento As Integer = 0
        Dim intEnvio As Integer = 0
        Dim intPromocion As Integer = 0
        Dim dblPeso As Double
        Dim strNumero As String = Me.TxtNroDocCliente.Text.Trim
        Dim intTipo As Integer = Me.CboTipo.SelectedValue

        Me.grbPromocion.Visible = False
        Me.lblPromocionDescuento.Text = ""
        Me.lblPromocionEnvio.Text = ""
        Me.lblPromocionDescuento.Tag = ""

        If Val(Me.TxtDescuento.Text) = 0 Then
            If intTipo = 1 And Me.CboProducto.SelectedValue = 0 And Me.TxtNroDocCliente.Text.Trim.Length > 0 And dtoUSUARIOS.m_idciudad > 0 And idUnidadAgencias > 0 Then  'tepsa encomiendas
                If TipoGrid_ = FormatoGrid.BULTO Then
                    If Conversion.Val(GrdDetalleVenta(2, 0).Value) = 0 Then dblPeso = 0 Else dblPeso = GrdDetalleVenta(2, 0).Value
                    If Conversion.Val(GrdDetalleVenta(2, 1).Value) > 0 Then dblPeso = dblPeso + GrdDetalleVenta(2, 1).Value
                Else
                    For i As Integer = 0 To GrdDetalleVenta.Rows.Count() - 1
                        If IsNumeric(GrdDetalleVenta("tipo", i).Value) Then
                            If Conversion.Val(GrdDetalleVenta("Peso Kg", i).Value) > 0 Then
                                dblPeso += Convert.ToDouble(GrdDetalleVenta("Peso Kg", i).Value)
                            End If
                        End If
                    Next
                End If
                Dim obj As New dtoVentaCargaContado
                'Dim dt As DataTable = obj.ObtienePromocion(IIf(iID_Persona = 0, 1, 0), dtoUSUARIOS.m_idciudad, idUnidadAgencias, iID_Persona, dblPeso, strNumero, intTipo)
                Dim dt As DataTable = obj.ObtienePromocion(IIf(iID_Persona = 0, 1, 0), dtoUSUARIOS.m_iIdAgencia, idUnidadAgencias, iID_Persona, dblPeso, strNumero, intTipo)
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0).Item(0) > 0 Then 'cliente accede a promocion
                        intDescuento = dt.Rows(0).Item(0)
                        intEnvio = dt.Rows(0).Item(1)
                        intPromocion = dt.Rows(0).Item(2)

                        Me.lblPromocionDescuento.Text = intDescuento
                        Me.lblPromocionEnvio.Text = intEnvio
                        Me.lblPromocionDescuento.Tag = intPromocion

                        If intPromocion = 1 Or intPromocion = 2 Then
                            grbPromocion.Width = 224
                        Else
                            grbPromocion.Width = 123
                        End If

                        Me.grbPromocion.Visible = True
                    End If
                End If
            End If
        End If
        Return intDescuento
    End Function

    Sub LimpiarPromocion()
        Me.grbPromocion.Visible = False
        Me.lblPromocionDescuento.Text = ""
        Me.lblPromocionEnvio.Text = ""
        Me.lblPromocionDescuento.Tag = ""
        'intPeso = 0
        'Me.CboFormaPago.SelectedIndex = 0
    End Sub

    Function BuscarProducto(ByVal cliente As Integer, ByVal subcuenta As Integer, ByVal origen As Integer, ByVal destino As Integer, ByVal contado As Integer) As Integer
        Dim objClienteProducto As New Cls_ClienteProducto_LN
        Dim intProducto As Integer = objClienteProducto.BuscarProducto(cliente, subcuenta, origen, destino, contado)
        Return intProducto
    End Function

    Private Sub ChkCargo_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Try
            'hlamas 07-08-2015
            'la tarifa de devolucion de cargos solo se aplica a venta contado
            If Me.CboTipo.SelectedIndex <> 0 Then Return

            dblMontoDC = ObtieneMontoDevolucionCargo()
            'If dblMontoDC = 0 Then
            If GrdDetalleVenta.Rows.Count = 0 Then Return
            If TipoGrid_ = FormatoGrid.BULTO Then
                fnTotalPago()
            ElseIf TipoGrid_ <> FormatoGrid.ARTICULOS Then
                iROW = 0
                Calculo_M3()
            End If
            'End If
        Catch
        End Try
    End Sub

    Function ObtieneMontoDevolucionCargo() As Double
        If Me.CboProducto.SelectedValue <> 0 Then Return 0 'solo aplica para tepsa encomiendas

        Dim dblMonto As Double = 0
        'hlamas 22-03-2016
        'If ChkCargo.Checked Then
        If rbtCargoSi.Checked Then
            dblMonto = dtoVentaCargaContado.MontoDevolucionCargo(0, iID_Persona)
            If dblMonto > 0 Then
                Dim intFila As Integer = BuscarItemVenta("DEV CARGO", GrdDetalleVenta)
                If intFila > 0 Then
                    EliminarItemVenta("DEV CARGO", GrdDetalleVenta)
                End If
                AgregarItemVenta("DEV CARGO", GrdDetalleVenta)

                intFila = BuscarItemVenta("DEV CARGO", GrdDetalleVenta)
                GrdDetalleVenta("Sub Neto", intFila).Value = Format(dblMonto, "0.00")
            End If
        Else
            EliminarItemVenta("DEV CARGO", GrdDetalleVenta)
            dblMonto = 0
        End If
        Return dblMonto
    End Function

    Function TieneCargo() As Boolean
        For Each row As DataGridViewRow In Me.GrdDocumentosCliente.Rows
            If Not IsNothing(row.Cells(2).Value) Then
                If row.Cells(2).Value.ToString.Trim.Length > 4 Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

#End Region

    Private Sub TxtCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCliente.TextChanged
    End Sub

    Private Sub btnAutorizar_Click(sender As System.Object, e As System.EventArgs) Handles btnAutorizar.Click
        Dim frm As New frmUsuarioDescuento
        frm.Descuento = Me.TxtDescuento.Text
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.txtDescDescto.Text = frm.cboUsuario.Text
        End If
    End Sub

    Sub ControlaCargo(estado As Boolean)
        Me.GrdDocumentosCliente.Enabled = estado
        Me.chkDocumentoCliente.Checked = estado
        Me.rbtCargoSi.Enabled = estado
        Me.rbtCargoSi.Checked = False
        Me.rbtCargoNo.Enabled = estado
        Me.rbtCargoNo.Checked = False

        If Me.lblTipoFacturacion.Tag <> 3 Then
            Me.rbtCargoNo.Visible = True
        End If

        If estado Then
        Else
            LimpiarGrid(GrdDocumentosCliente, 2)
        End If
    End Sub

    Private Sub chkDocumentoCliente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDocumentoCliente.CheckedChanged
        'hlamas 18-03-2016
        If Me.CboProducto.SelectedValue = 6 Then 'no aplica para carga acompañada
            If Me.chkDocumentoCliente.Checked Then
                Me.chkDocumentoCliente.Checked = False
            End If
            Return
        End If
        ControlaCargo(Me.chkDocumentoCliente.Checked)
    End Sub

    Private Sub rbtCargoSi_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtCargoSi.CheckedChanged
        Try
            If Me.CboTipo.SelectedIndex = 1 Then Return
            dblMontoDC = ObtieneMontoDevolucionCargo()
            'If dblMontoDC = 0 Then
            If GrdDetalleVenta.Rows.Count = 0 Then Return
            If TipoGrid_ = FormatoGrid.BULTO Then
                fnTotalPago()
            ElseIf TipoGrid_ <> FormatoGrid.ARTICULOS Then
                iROW = 0
                Calculo_M3()
            End If
            'End If
        Catch
        End Try
    End Sub

    Sub MostrarTipoFacturacion(tipo As Integer)
        Dim strTipo As String
        Select Case tipo
            Case 1
                strTipo = "I"
            Case 2
                strTipo = "II"
            Case 3
                strTipo = "III"
            Case Else
                strTipo = ""
        End Select

        If tipo >= 1 Then
            Me.lblTipoFacturacion.Text = "TIPO FACTURACION " & strTipo
        Else
            Me.lblTipoFacturacion.Text = ""
        End If
        Me.lblTipoFacturacion.Tag = tipo
    End Sub

    Sub ImprimirTicket(ByVal venta As dtoVentaCargaContado, ByVal impresora As DataTable, Optional ByVal venta2 As dtoVentaCargaContado = Nothing)
        Dim prn As New FEManager
        Dim feventa As New FEVenta
        Dim fecliente As New FECliente

        fecliente.tipoDocumentoID = venta.ID_TipoDocCli
        fecliente.numeroDocumento = venta.v_NRO_DNI_RUC
        fecliente.nombres = venta.v_NOMBRES_RASONSOCIAL

        'If ObjVentaCargaContado.v_direccion.Trim.Length > 0 Then
        'fecliente.direccion = ObjVentaCargaContado.v_direccion.Trim.ToUpper
        'Else
        fecliente.direccion = IIf(CboDireccion.SelectedIndex > 0, CboDireccion.Text.Trim.ToUpper(), "")
        'End If
        feventa.cliente = fecliente

        Dim strSerie As String = ""

        feventa.numeroSerie = "" 'strSerie & Me.lblSerie.Text 'venta.v_SERIE_FACTURA
        feventa.numeroCorrelativo = venta.v_NRO_FACTURA

        feventa.fechaEmision = FechaServidor()
        feventa.tipoComprobanteID = venta.v_IDTIPO_COMPROBANTE
        feventa.opGravada = 0
        feventa.igv = 0
        feventa.total = CDbl(Me.TxtTotal.Text)
        feventa.totalLetras = ObjVentaCargaContado.v_nroboleto
        feventa.formaPago = "" 'IIf(cmbFormaPago.SelectedIndex = 0, "", cmbFormaPago.Text.Trim().ToUpper())
        Dim formaPagoID As Integer = 0 'cboFormaPago.SelectedValue
        feventa.isCortesia = False

        '-->Para la impresion
        feventa.producto = CboProducto.Text
        feventa.origen = LblCiudad.Text.Trim.ToUpper()
        feventa.destino = TxtCiudadDestino.Text.Trim.ToUpper()
        feventa.remitenete = fecliente.nombres

        Dim sConsignado As String = ObjVentaCargaContado.v_NOMBRES_DESTINATARIO.Trim.Replace(";", ",")
        sConsignado = sConsignado.Substring(0, sConsignado.Trim.Length - 1)
        feventa.consignado = sConsignado

        feventa.tipoEntrega = Me.CboTipoEntrega.Text
        feventa.direccionEntrega = Me.CboDireccion2.Text
        feventa.agenciaEmision = dtoUSUARIOS.m_iNombreAgencia
        feventa.usuarioEmision = dtoUSUARIOS.NameLogin
        feventa.detalleVenta = FEManager.crearDetallePCE(GrdDetalleVenta, CDbl(Me.TxtTotal.Text), Me.ChkArticulos.Checked, False, venta.v_iProceso, 0)
        feventa.id = ObjVentaCargaContado.v_IDFACTURA
        strNroGuias_Remision = strNroGuias_Remision.Trim
        strNroGuias_Remision = strNroGuias_Remision.Replace("  ", ",")
        feventa.totalLetras = strNroGuias_Remision
        feventa.direccionFiscal = IIf(Me.rbtCargoSi.Checked, "SI", "NO")
        feventa.tabla = "T_FACTURA_CONTADO"

        Dim result As New servicefe.Result
        'Dim result As New feserviceDesarrollo.Result
        prn.Print(feventa, impresora)
    End Sub
    
    Private Sub GrdDetalleVenta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdDetalleVenta.DoubleClick
        If Not Me.ChkArticulos.Checked Then Return
        Dim intCantidad As Integer
        Dim strArticulo As String

        strArticulo = "" & Me.GrdDetalleVenta.CurrentRow.Cells(0).Value
        intCantidad = Val(Me.GrdDetalleVenta.CurrentRow.Cells(2).Value)
        If intCantidad > 0 Then
            Dim frm As New frmGeArticuloItem
            frm.Articulo = strArticulo
            frm.Cantidad = intCantidad

            Dim lista As New List(Of String)
            Dim item As New dtoCodigo
            item = ListaCodigo.Find(Function(codigo As dtoCodigo) codigo.Id = GrdDetalleVenta.CurrentCell.RowIndex)
            If Not IsNothing(item) Then
                For i As Integer = 0 To item.Lista.Count - 1
                    lista.Add(item.Lista(i))
                Next
            End If
            frm.lista = lista
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                AgregarCodigo(GrdDetalleVenta.CurrentCell.RowIndex, frm)
            Else
                If frm.lista.Count = 0 Then
                    item = ListaCodigo.Find(Function(codigo As dtoCodigo) codigo.Id = GrdDetalleVenta.CurrentCell.RowIndex)
                    ListaCodigo.Remove(item)
                End If
            End If
        End If
    End Sub

    Sub AgregarCodigo(ByVal id As Integer, ByVal frm As frmGeArticuloItem)
        Dim item As New dtoCodigo

        If ListaCodigo.Exists(Function(codigo As dtoCodigo) codigo.Id = id) Then
            item = ListaCodigo.Find(Function(codigo As dtoCodigo) codigo.Id = id)
            ListaCodigo.Remove(item)
        End If

        item = New dtoCodigo
        item.Id = id
        For i As Integer = 0 To frm.lista.Count - 1
            item.Lista.Add(frm.lista(i))
        Next
        ListaCodigo.Add(item)
    End Sub

    Private Sub GrdDetalleVenta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDetalleVenta.CellContentClick

    End Sub

    Private Sub GrdDetalleVenta_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDetalleVenta.CellValueChanged
        'hlamas 11-03-2020
        If Me.ChkArticulos.Checked Then
            If iCOL = 2 Then
                Dim id As Integer = e.RowIndex
                Dim item As New dtoCodigo
                If ListaCodigo.Exists(Function(codigo As dtoCodigo) codigo.Id = id) Then
                    item = ListaCodigo.Find(Function(codigo As dtoCodigo) codigo.Id = id)
                    If GrdDetalleVenta(e.ColumnIndex, e.RowIndex).Value <> item.Lista.Count Then
                        ListaCodigo.Remove(item)
                    End If
                End If
            End If
        End If
    End Sub
End Class