Imports System.Data.Odbc
Imports AccesoDatos
Imports INTEGRACION_LN
Public Class FrmMantenimientoContado
    Dim coll_iDestino As New Collection
    Public iWinDestino As New AutoCompleteStringCollection
    Property hnd As Long
    Dim bCondicion As Boolean = False
    Dim bTarifarioGeneral As Boolean
    Dim bOtrasAgencias As Boolean
    Dim bContado As Boolean
    Dim tipo_bole_impre As String
    Dim tipo_factu_impre As String
    Dim TipoComprobante As Integer = 2
    Dim Mro_Digitos_SerieVentas As Integer = 3
    Dim bFAC_Bol As Boolean = False
    Dim Mro_Digitos_Ventas As Integer = 7
    Dim xIMPRESORA As Integer
    Dim TipoGrid_ As String
    Dim idUnidadAgencias As Integer = -1
    Dim Factor_ As Double
    Dim MontoMinimoPyme As Double
    Dim bIngreso As Boolean = False    
    Public Shared iTotalPagado As Double = 0
    Public Shared iVuelto As Double = 0
    Dim dtAgencia As New DataTable
    Dim dtAgencia2 As New DataTable
    Dim iUsuarioCiudad As Integer
    '****variables nuevas**********

    Dim dtCliente, dtConsignado, dtContacto, dtDireccion, dtDireccion2, DtArticulos As DataTable
    Dim dtContactoParalelo As DataTable
    Dim iTipoDoc As Integer
    Dim iCliente As Integer = 0
    Dim iDespliegue As Byte = 0

    Dim bClienteNuevo As Boolean = True
    Dim bConsignadoNuevo As Boolean = True    

    Dim sNombresCli As String = "", sApCli As String = "", sAmCli As String = "", sTelfCliente As String = "", sCliente As String = "", sEmail As String
    Dim iID_TipoDocCli As Integer = 0

    Dim bClienteModificado, bDireccionModificada, bContactoModificado As Boolean

    Dim NombresCliente As String = "", apellPatCli As String = "", apellMatCli As String = "", TelfCliente As String = "" '-->cliente

    Dim iID_Persona As Integer
    Dim NombresCont As String = "", apellPatCont As String = "", apellMatCont As String = "" '---------------->contacto
    Dim iID_TipoDocCont As Integer = 0
    'distrito
    Dim iDepartamentoCli, iProvinciaCli, iDistritoCli, IDviaCli, id_NivelCli, id_ZonaCli, id_ClasificacionCli, FormatoCli As Integer
    Dim ViaCli, ManzanaCli, loteCli, NivelCli, ZonaCli, NroCli, ClasificacionCli As String
    Dim IdDireccionOrigen As Integer
    Dim utilData As New UtilData_LN
    '******************************   
    '18-11-2013 hlamas tarifa entrega a domicilio
    Dim dtTarifaServicio As DataTable
    Dim dblMontoEntregaDomicilio As Double = 0
    Dim blnInicio As Boolean = True

    Dim blnTotalManual As Boolean

    'hlamas 17-02-2015
    Dim dblMontoDC As Double = 0

    'hlamas 26-08-2015
    Dim blnCargo As Boolean, strObservacionCargo As String

    'hlamas 01-10-2019
    Dim dblMontoFueraZona As Double = 0

    'hlamas 11-09-2015
    Dim ID_PRODUCTO_TEPSA_SOBRES As Integer = 10
    Dim ID_PRODUCTO_TEPSA_BOX As Integer = 81
    Dim ID_PRODUCTO_TEPSA_BOX_10 As Integer = 82

    'hlamas 21-01-2016
    Dim dtTarifaArticuloPublico As DataTable

    'hlamas 21-03-2016
    Dim blnLimpiarDatosGeneral As Boolean = True

    Dim intNumero As Long = 231000

    'hlamas 14-04-2018
    Dim intPerfil As Integer = 1

#Region "PAGE BUSCAR"

    Sub FORMATOdgvlista()
        With DgvLista
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .AllowUserToResizeColumns = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            ' .BackgroundColor = SystemColors.ScrollBar
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter            
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 179)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            '.ScrollBars = ScrollBars.Both   
            .RowHeadersWidth = 20
            .ReadOnly = True 'readonly cuando este false se puede editar
        End With
        'Dim idEstadoImage As New DataGridViewImageColumn
        'With idEstadoImage
        '    .DataPropertyName = "imagen"
        '    .HeaderText = "CL"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        '    .DisplayIndex = 0
        '    .Visible = True
        '    '.ValuesAreIcons = True
        '    '.InheritedStyle.BackColor = Color.Transparent
        '    .Image = bmActivo
        'End With
        'dgvlista.Columns.Add(idEstadoImage)

        Dim colID As New DataGridViewTextBoxColumn
        With colID
            '.DisplayIndex = 1
            .DataPropertyName = "Idfactura"
            .Name = "Idfactura"
            .HeaderText = "Idfactura"
            .Visible = False
        End With

        Dim colIDESTADO As New DataGridViewTextBoxColumn
        With colIDESTADO
            '.DisplayIndex = 2
            .Name = "Idestado_Factura"
            .DataPropertyName = "Idestado_Factura"
            .HeaderText = "Idestado_Factura"
            .Visible = False
        End With

        Dim Fecha_Factura As New DataGridViewTextBoxColumn
        With Fecha_Factura
            .HeaderText = "Fecha"
            .DataPropertyName = "Fecha_Factura"
            .Name = "Fecha_Factura"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim FAC_BOL As New DataGridViewTextBoxColumn
        With FAC_BOL
            .HeaderText = "Nº Comprobante"
            .DataPropertyName = "FAC_BOL"
            .Name = "FAC_BOL"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim TIPO As New DataGridViewTextBoxColumn
        With TIPO
            .HeaderText = "Tipo"
            .DataPropertyName = "Tipo"
            .Name = "Tipo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim Origen As New DataGridViewTextBoxColumn
        With Origen
            .HeaderText = "Orígen"
            .DataPropertyName = "Origen"
            .Name = "Origen"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim Destino As New DataGridViewTextBoxColumn
        With Destino
            .HeaderText = "Destino"
            .DataPropertyName = "Destino"
            .Name = "Destino"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim Trancito As New DataGridViewTextBoxColumn
        With Trancito
            .HeaderText = "Tránsito"
            .DataPropertyName = "Trancito"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim DNI_RUC As New DataGridViewTextBoxColumn
        With DNI_RUC
            .HeaderText = "Nº Documento"
            .DataPropertyName = "DNI_RUC"
            .Name = "Dni_Ruc"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim razon_social As New DataGridViewTextBoxColumn
        With razon_social
            .HeaderText = "Cliente"
            .DataPropertyName = "razon_social"
            .Name = "razon_social"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim cantidad As New DataGridViewTextBoxColumn
        With cantidad
            .HeaderText = "Cantidad"
            .DataPropertyName = "cantidad"
            .Name = "Cantidad"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim Total_Peso As New DataGridViewTextBoxColumn
        With Total_Peso
            .HeaderText = "Total Peso"
            .DataPropertyName = "Total_Peso"
            .Name = "total_peso"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Format = "###,###,###0.00"
        End With

        Dim Total_Volumen As New DataGridViewTextBoxColumn
        With Total_Volumen
            .HeaderText = "Total Volumen"
            .DataPropertyName = "Total_Volumen"
            .Name = "total_volumen"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Format = "###,###,###0.00"
        End With

        Dim Precio_x_Peso As New DataGridViewTextBoxColumn
        With Precio_x_Peso
            .DataPropertyName = "Precio_x_Peso"
            .HeaderText = "Precio Peso"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Format = "###,###,###0.00"
        End With

        Dim Precio_x_Volumen As New DataGridViewTextBoxColumn
        With Precio_x_Volumen
            .HeaderText = "Precio Volumen"
            .DataPropertyName = "Precio_x_Volumen"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Format = "###,###,###0.00"
        End With

        Dim Precio_x_Sobre As New DataGridViewTextBoxColumn
        With Precio_x_Sobre
            .HeaderText = "Precio Sobre"
            .DataPropertyName = "Precio_x_Sobre"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Format = "###,###,###0.00"
        End With

        Dim Monto_Base As New DataGridViewTextBoxColumn
        With Monto_Base
            .HeaderText = "Monto Base"
            .DataPropertyName = "Monto_Base"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Format = "###,###,###0.00"
        End With

        Dim Porcent_Descuento As New DataGridViewTextBoxColumn
        With Porcent_Descuento
            .HeaderText = "% Descuento"
            .DataPropertyName = "Porcent_Descuento"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Format = "###,###,###0.00"
        End With

        Dim Monto_Sub_Total As New DataGridViewTextBoxColumn
        With Monto_Sub_Total
            .HeaderText = "SubTotal"
            .DataPropertyName = "Monto_Sub_Total"
            .Name = "Monto_Sub_Total"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Format = "###,###,###0.00"
        End With

        Dim Monto_Impuesto As New DataGridViewTextBoxColumn
        With Monto_Impuesto
            .HeaderText = "Impuesto"
            .DataPropertyName = "Monto_Impuesto"
            .Name = "Monto_Impuesto"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Format = "###,###,###0.00"
        End With

        Dim Total_Costo As New DataGridViewTextBoxColumn
        With Total_Costo
            .HeaderText = "Total"
            .DataPropertyName = "Total_Costo"
            .Name = "Total_Costo"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "###,###,###0.00"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        End With

        Dim login_creacion As New DataGridViewTextBoxColumn
        With login_creacion
            .HeaderText = "Usuario"
            .DataPropertyName = "login_creacion"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim Estado_Doc As New DataGridViewTextBoxColumn
        With Estado_Doc
            .HeaderText = "Estado Documento"
            .DataPropertyName = "Estado_Doc"
            .Name = "Estado_Doc"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim Estado_Envio As New DataGridViewTextBoxColumn
        With Estado_Envio
            .HeaderText = "Estado Envío"
            .DataPropertyName = "Estado_Envio"
            .Name = "Estado_Envio"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim cancelado As New DataGridViewTextBoxColumn
        With cancelado
            .HeaderText = "Cancelado"
            .Name = "Cancelado"
            .DataPropertyName = "cancelado"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim Proceso As New DataGridViewTextBoxColumn
        With Proceso
            .HeaderText = "Producto"
            .Name = "Proceso"
            .DataPropertyName = "Proceso"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim nroboleto As New DataGridViewTextBoxColumn
        With nroboleto
            .HeaderText = "Nº Boleto"
            .DataPropertyName = "nroboleto"
            .Name = "nroboleto"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim Cancelado_Por As New DataGridViewTextBoxColumn
        With Cancelado_Por
            .HeaderText = "Cancelado Por"
            .DataPropertyName = "Comprobante"
            .Name = "Comprobante"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        '*******************Ocultos*****************************
        Dim Tipo_Pago As New DataGridViewTextBoxColumn
        With Tipo_Pago
            .DataPropertyName = "Tipo_Pago"
            .HeaderText = "Tipo Pago"
            .Name = "Tipo_Pago"
            .Visible = False
        End With

        Dim idProceso As New DataGridViewTextBoxColumn
        With idProceso
            .HeaderText = "Proceso"
            .Name = "idproceso"
            .DataPropertyName = "idproceso"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
        End With

        Dim forma_pago As New DataGridViewTextBoxColumn
        With forma_pago
            .DataPropertyName = "forma_pago"
            .Name = "forma_pago"
            .HeaderText = "Forma Pago"
            .Visible = False
        End With

        Dim Idestado_Factura As New DataGridViewTextBoxColumn
        With Idestado_Factura
            .Name = "Idestado_Factura"
            .DataPropertyName = "Idestado_Factura"
            .HeaderText = "Estado Factura"
            .Visible = False
        End With

        Dim Facturado As New DataGridViewTextBoxColumn
        With Facturado
            .Name = "Facturado"
            .DataPropertyName = "Facturado"
            .HeaderText = "Facturado"
            .Visible = False
        End With
        ''
        Dim Idtipo_Comprobante As New DataGridViewTextBoxColumn
        With Idtipo_Comprobante
            .Name = "Idtipo_Comprobante"
            .DataPropertyName = "Idtipo_Comprobante"
            .HeaderText = "ID Tipo Comp."
            .Visible = False
        End With

        '
        Dim Idunidad_Destino As New DataGridViewTextBoxColumn
        With Idunidad_Destino
            .Name = "Idunidad_Destino"
            .DataPropertyName = "Idunidad_Destino"
            .HeaderText = "Ciudad"
            .Visible = False
        End With
        '
        Dim Idagencias_Destino As New DataGridViewTextBoxColumn
        With Idagencias_Destino
            '.DisplayIndex = 32
            .Name = "Idagencias_Destino"
            .DataPropertyName = "Idagencias_Destino"
            .HeaderText = "Agencia Destino"
            .Visible = False
        End With
        '
        Dim tipo_comprobante As New DataGridViewTextBoxColumn
        With tipo_comprobante
            .Name = "tipo_comprobante"
            .DataPropertyName = "tipo_comprobante"
            .HeaderText = "Tipo Comprobante"
            .Visible = False
        End With
        '
        Dim Idforma_Pago As New DataGridViewTextBoxColumn
        With Idforma_Pago
            .Name = "Idforma_Pago"
            .DataPropertyName = "Idforma_Pago"
            .HeaderText = "Id Forma Pago"
            .Visible = False
        End With
        '
        Dim lidagencia_origen As New DataGridViewTextBoxColumn
        With lidagencia_origen
            '.DisplayIndex = 35
            .Name = "idagencia_origen"
            .DataPropertyName = "idagencia_origen"
            .HeaderText = "Id agencia Origen"
            .Visible = False
        End With
        '
        Dim lIdunidad_Origen As New DataGridViewTextBoxColumn
        With lIdunidad_Origen
            .Name = "Idunidad_Origen"
            .DataPropertyName = "Idunidad_Origen"
            .HeaderText = "Id Unidad_Origen"
            .Visible = False
        End With

        Dim col_entrega_domicilio As New DataGridViewTextBoxColumn
        With col_entrega_domicilio
            .Name = "monto_entrega_domicilio"
            .DataPropertyName = "monto_entrega_domicilio"
            .HeaderText = "Monto Entrega Domicilio"
            .Visible = True
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "0.00"
            .DefaultCellStyle.NullValue = "0.00"
        End With

        Dim col_TipoEntrega As New DataGridViewTextBoxColumn
        With col_TipoEntrega
            .Name = "tipo_entrega"
            .DataPropertyName = "tipo_entrega"
            .HeaderText = "tipo_entrega"
            .Visible = False
        End With

        Dim col_idcliente As New DataGridViewTextBoxColumn
        With col_idcliente
            .Name = "idcliente"
            .DataPropertyName = "idcliente"
            .HeaderText = "idcliente"
            .Visible = False
        End With

        Dim col_idestado_envio As New DataGridViewTextBoxColumn
        With col_idestado_envio
            .Name = "idestado_envio"
            .DataPropertyName = "idestado_envio"
            .HeaderText = "idestado_envio"
            .Visible = False
        End With

        Dim col_n_emife As New DataGridViewTextBoxColumn
        With col_n_emife
            .Name = "n_emife"
            .DataPropertyName = "n_emife"
            .HeaderText = "Enviado a Sunat"
            .Visible = True
        End With

        Dim col_tipo_padre As New DataGridViewTextBoxColumn
        With col_tipo_padre
            .Name = "tipo_padre"
            .DataPropertyName = "tipo_padre"
            .HeaderText = "tipo_padre"
            .Visible = False
        End With
        Dim col_comprobante_padre As New DataGridViewTextBoxColumn
        With col_comprobante_padre
            .Name = "comprobante_padre"
            .DataPropertyName = "comprobante_padre"
            .HeaderText = "comprobante_padre"
            .Visible = False
        End With
        Dim col_fecha_padre As New DataGridViewTextBoxColumn
        With col_fecha_padre
            .Name = "fecha_padre"
            .DataPropertyName = "fecha_padre"
            .HeaderText = "fecha_padre"
            .Visible = False
        End With
        Dim col_direccion_padre As New DataGridViewTextBoxColumn
        With col_direccion_padre
            .Name = "direccion_padre"
            .DataPropertyName = "direccion_padre"
            .HeaderText = "direccion_padre"
            .Visible = False
        End With
        Dim col_codigo_nc As New DataGridViewTextBoxColumn
        With col_codigo_nc
            .Name = "codigo_nc"
            .DataPropertyName = "codigo_nc"
            .HeaderText = "codigo_nc"
            .Visible = False
        End With
        Dim col_descripcion_nc As New DataGridViewTextBoxColumn
        With col_descripcion_nc
            .Name = "descripcion_nc"
            .DataPropertyName = "descripcion_nc"
            .HeaderText = "descripcion_nc"
            .Visible = False
        End With
        Dim col_glosa_nc As New DataGridViewTextBoxColumn
        With col_glosa_nc
            .Name = "glosa_nc"
            .DataPropertyName = "glosa_nc"
            .HeaderText = "glosa_nc"
            .Visible = False
        End With
        Dim col_agencia_venta As New DataGridViewTextBoxColumn
        With col_agencia_venta
            '.DisplayIndex = 35
            .Name = "agencia_venta"
            .DataPropertyName = "agencia_venta"
            .HeaderText = "agencia_venta"
            .Visible = False
        End With
        Dim col_hora_partida As New DataGridViewTextBoxColumn
        With col_hora_partida
            '.DisplayIndex = 35
            .Name = "hora_partida"
            .DataPropertyName = "hora_partida"
            .HeaderText = "hora_partida"
            .Visible = False
        End With
        Dim col_nivel_equipaje As New DataGridViewTextBoxColumn
        With col_nivel_equipaje
            '.DisplayIndex = 35
            .Name = "nivel_equipaje"
            .DataPropertyName = "nivel_equipaje"
            .HeaderText = "nivel_equipaje"
            .Visible = False
        End With
        Dim col_funcionario As New DataGridViewTextBoxColumn
        With col_funcionario
            '.DisplayIndex = 35
            .Name = "funcionario"
            .DataPropertyName = "funcionario"
            .HeaderText = "Funcionario"
            .Visible = False
        End With

        Dim col_idusuario_personal As New DataGridViewTextBoxColumn
        With col_idusuario_personal
            .Name = "idusuario_personal"
            .DataPropertyName = "idusuario_personal"
            .HeaderText = "idusuario_personal"
            .Visible = False
        End With

        Dim col_monto_fuera_zona As New DataGridViewTextBoxColumn
        With col_monto_fuera_zona
            .Name = "monto_fuera_zona"
            .DataPropertyName = "monto_fuera_zona"
            .HeaderText = "Monto Fuera Zona"
            .Visible = True
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "0.00"
            .DefaultCellStyle.NullValue = "0.00"
        End With



        DgvLista.Columns.AddRange(Fecha_Factura, FAC_BOL, TIPO, Origen, Destino, Trancito, DNI_RUC, razon_social, _
        cantidad, Total_Peso, Total_Volumen, Precio_x_Peso, Precio_x_Volumen, Precio_x_Sobre, _
        Monto_Base, Porcent_Descuento, Monto_Sub_Total, Monto_Impuesto, Total_Costo, _
        login_creacion, Estado_Doc, Estado_Envio, cancelado, Proceso, nroboleto, Cancelado_Por, Tipo_Pago, forma_pago, Idestado_Factura, Facturado, Idtipo_Comprobante, Idagencias_Destino, _
        tipo_comprobante, Idforma_Pago, lidagencia_origen, lIdunidad_Origen, colID, colIDESTADO, col_entrega_domicilio, col_TipoEntrega, col_idcliente, col_idestado_envio, col_n_emife, _
        col_tipo_padre, col_comprobante_padre, col_fecha_padre, col_direccion_padre, col_codigo_nc, col_descripcion_nc, col_glosa_nc, col_agencia_venta, idProceso, col_hora_partida, col_nivel_equipaje, col_funcionario, _
        col_idusuario_personal, col_monto_fuera_zona)
    End Sub

    Private Sub FrmMantenimientoContado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmManteVentaContado_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        TxtCiudadDestino.Focus()
    End Sub

    Private Sub FrmManteVentaContado_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        dtoUSUARIOS.m_iIdAgencia = dtoUSUARIOS.iIDAGENCIAS
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        GrdDocumentosCliente.ClearSelection()
        GrdDetalleVenta.ClearSelection()
    End Sub

    Private Sub FrmManteVentaContado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            'SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FrmManteVentaContado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtNroDoc.ReadOnly = False
        TxtNroDoc.BackColor = Color.White

        TxtSerie.ReadOnly = False
        TxtSerie.BackColor = Color.White

        Me.cboTipoComprobante.SelectedIndex = 0

        'Me.TabPageVenta.Parent = Nothing
        blnTotalManual = True
        blnInicio = True
        ReDim objComprobanteAsegurada(19)
        recuperando_datos_contado = False
        Me.FORMATOdgvlista()
        DiseñaGrdDocumentos()
        '===Agregado x NConsignado====
        Me.DiseñaGrdNConsignado()
        '=============================
        RemoveHandler CboAgencia.SelectedIndexChanged, AddressOf CboAgencia_SelectedIndexChanged
        GrdDocumentosCliente.ClearSelection()
        GrdDetalleVenta.ClearSelection()
        If ObjVentaCargaContado.fnLoadManteVenta() = True Then
            'Origen           
            ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_curListAgenciasOrigDest, CboOrigen, ObjVentaCargaContado.coll_OrigDest, 0)
            dtAgencia2 = ObjVentaCargaContado.dt_curListAgenciasOrigDest.Copy
            CboCiudadOrigen.DataSource = dtAgencia2
            CboCiudadOrigen.DisplayMember = "NOMBRE_UNIDAD"
            CboCiudadOrigen.ValueMember = "IDUNIDAD_AGENCIA"
            CboCiudadOrigen.SelectedValue = IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad)
            'Destino
            ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_curListAgenciasOrigDest, CboDestino, ObjVentaCargaContado.coll_OrigDest, 0)
            'Agencia
            dtAgencia = ObjVentaCargaContado.dt_curListAgenciaOrigen.Copy
            CboAgencia.DataSource = dtAgencia
            CboAgencia.DisplayMember = "NOMBRE_AGENCIA"
            CboAgencia.ValueMember = "IDAGENCIAS"
            'Estado
            ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_curlistaEstado, CboEstado, ObjVentaCargaContado.coll_Estados, 0)
        End If

        If ObjVentaCargaContado.fnLoadVentaCarga1(dtoUSUARIOS.m_iIdAgencia.ToString) = True Then
            fnCargar_iWin_dt(TxtCiudadDestino, ObjVentaCargaContado.dt_cur_UNIDAD_AGENCIAS, coll_iDestino, iWinDestino, 0)
            ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_T_TARJETAS, CboTarjeta, ObjVentaCargaContado.coll_T_TARJETAS, ObjVentaCargaContado.v_IDFORMA_PAGO)
            ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_Tipo_Pago, CboFormaPago, ObjVentaCargaContado.coll_Tipo_Pago, 1)
            'ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_t_Tipo_Entrega, CboTipoEntrega, ObjVentaCargaContado.coll_t_Tipo_Entrega, 1)
            With Me.CboTipoEntrega
                .DisplayMember = "tipo_entrega"
                .ValueMember = "idtipo_entrega"
                .DataSource = ObjVentaCargaContado.dt_cur_t_Tipo_Entrega
                .SelectedValue = TipoEntrega.Agencia
            End With            '   

            Me.ListarProducto()

            ' Cargando Nuevo Tipo Tarifa - 1 = Estandar , 2= Urgentes
            utilData.cargarCombos("t_tipotarifa", CboTipoTarifa, False)
            'Dim index As Integer
            'Dim objTarifarioPerso_LN As New Cls_TarifaPublica_LN 'refereanciamos la clase a mostrar
            'objTarifarioPerso_LN.F_CargarOrigen_LN(CboTipoTarifa, "t_tipotarifa")
            'index = CboTipoTarifa.FindString("ESTANDAR")
            'CboTipoTarifa.SelectedIndex = index

            '--USUARIO REMOTO
            Me.listaUsuarios(IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad))
            'Dim obj As New dtoVentaCargaContado
            'Dim dt As DataTable = obj.ListarUsuarios(dtoUSUARIOS.m_idciudad)
            'With Me.CboListaUsuarios                
            '    .DisplayMember = "nombre"
            '    .ValueMember = "idusuario_personal"
            '    .DataSource = dt
            'End With
            '---------------------------------------

            Factor_ = ObjVentaCargaContado.VFactor_
            MontoMinimoPyme = ObjVentaCargaContado.VMontoMinimoPYME ''-agregado 04022012
            tipo_bole_impre = ObjVentaCargaContado.tipo_bole_impre
            tipo_factu_impre = ObjVentaCargaContado.tipo_factu_impre

            Me.Text = "Titán " & dtoUSUARIOS.iLOGIN & " Ag. Nro " & dtoUSUARIOS.m_iIdAgencia & _
           " [ " & dtoUSUARIOS.m_iNombreUnidadAgencia & " ] [ " & dtoUSUARIOS.m_iNombreAgencia & "] "
        End If

        xIMPRESORA = fnSeleccionImpresion()
        CboOrigen.Text = dtoUSUARIOS.m_iNombreUnidadAgencia
        CboAgencia.Text = dtoUSUARIOS.m_iNombreAgencia
        CboDestino.Text = "(TODO)"
        CboUsuario.Text = "(TODO)"
        Me.CboAgencia_SelectedIndexChanged(sender, e)
        AddHandler CboAgencia.SelectedIndexChanged, AddressOf CboAgencia_SelectedIndexChanged

        'hlamas 18-03-2016
        ControlaCargo(False)

        bIngreso = False
        Dim dt2 As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
        Acceso.AplicaConfiguracion(dt2, Me, ContextMenuStrip)
        bIngreso = True


        CboTipoTarifa.SelectedIndex = 1
        BtnNuevo.Visible = True
        blnInicio = False

        'Button1.Visible = IIf(dtoUSUARIOS.IdLogin = 20708, True, False) 'abanto
        'btnEnviarSunat.Visible = dtoUSUARIOS.IdRol = 1036

        'Me.TxtBoletoViaje.Text = "FA02-00085891"
        'objControlFacturasBol.iControl = 9
        'fnBuscarFacturas()
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

    Private Sub CboOrigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboOrigen.SelectedIndexChanged
        Try
            Dim idorigen As Integer = Int(ObjVentaCargaContado.coll_OrigDest(CboOrigen.SelectedIndex.ToString()))
            'If IsReference(CboOrigen.SelectedValue) Then Return
            Dim sFiltro As String
            If idorigen = 0 Then
                sFiltro = ""
            Else
                sFiltro = "Idunidad_Agencia=" & idorigen & " or Idunidad_Agencia=0"
            End If
            dtAgencia.DefaultView.RowFilter = sFiltro
            CboAgencia.SelectedValue = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub listaUsuarios(ByVal iIDCiudad As Integer)
        Dim obj As New dtoVentaCargaContado
        Dim dt As DataTable = obj.ListarUsuarios(dtoUSUARIOS.m_idciudad, 0)
        With Me.CboListaUsuarios
            .DisplayMember = "nombre"
            .ValueMember = "idusuario_personal"
            .DataSource = dt
        End With
    End Sub
    Private Sub CboCiudadOrigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCiudadOrigen.SelectedIndexChanged
        Try
            If Not IsReference(CboCiudadOrigen.SelectedValue) Then
                If iOpcion = 2 Then
                    If CboCiudadOrigen.SelectedValue <> ObjVentaCargaContado.v_IDUNIDAD_ORIGEN Then
                        CboCiudadOrigen.SelectedValue = ObjVentaCargaContado.v_IDUNIDAD_ORIGEN
                        Return
                    End If
                End If

                If dtoUSUARIOS.m_idciudad = CboCiudadOrigen.SelectedValue Then
                    iUsuarioCiudad = 0
                Else
                    iUsuarioCiudad = CboCiudadOrigen.SelectedValue
                End If

                If IsReference(CboCiudadOrigen.SelectedValue) Then Return
                'ObjVentaCargaContado.fnGetAgencias(CboCiudadOrigen.SelectedValue)
                'Dim dt As New DataTable
                'dt = ObjVentaCargaContado.dt_VarAgencias.Copy
                'CboAgenciaOrigen.DataSource = dt
                'CboAgenciaOrigen.DisplayMember = "nombre_agencia"
                'CboAgenciaOrigen.ValueMember = "idagencias"

                'dtoUSUARIOS.m_idciudad = CboCiudadOrigen.SelectedValue

                ObjVentaCargaContado.fnGetAgencias(CboCiudadOrigen.SelectedValue)
                Dim dt As New DataTable
                dt = ObjVentaCargaContado.dt_VarAgencias.Copy
                With CboAgenciaOrigen
                    .DataSource = dt
                    .DisplayMember = "nombre_agencia"
                    .ValueMember = "idagencias"
                End With
                '-------
                Me.listaUsuarios(CboCiudadOrigen.SelectedValue)

                'hlamas 17-07-2014
                ClienteProducto(iID_Persona, 999, Me.CboCiudadOrigen.SelectedValue, idUnidadAgencias)

                'hlamas 15-11-2013
                'Tarifa Entrega a Domicilio
                GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, CboCiudadOrigen.SelectedValue, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)
            End If            
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub DespliegaCboAgencia_Origen()
        With CboAgenciaOrigen
            If bNuevo Then
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
            End If
        End With
    End Sub

    Private Sub CboAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAgencia.SelectedIndexChanged
        Try
            Dim idAgencia As Integer
            'idAgencia = Int(CboAgencia.SelectedIndex)
            'If IsReference(CboAgencia.SelectedValue) Then Return
            Dim Usuario As Integer = 0
            If dtoUSUARIOS.m_iIdAgencia = CboAgencia.SelectedValue Then
                Usuario = dtoUSUARIOS.IdLogin
            Else
                Usuario = 0
            End If

            idAgencia = CboAgencia.SelectedValue
            If idAgencia >= 0 Then
                'idAgencia = IIf(CboAgencia.SelectedIndex.ToString() <> "", Int(ObjVentaCargaContado.coll_AgenciaOrigen(CboAgencia.SelectedIndex.ToString())), 0)
                idAgencia = IIf(CboAgencia.SelectedValue >= 0, CboAgencia.SelectedValue, 0)
                If objGuiaEnvio.fnFILTRO_USUARIO_X_AGENCIA_2(idAgencia) = True Then
                    ModuUtil.LlenarComboIDs_dt(objGuiaEnvio.dt_Lista_Usuarios, CboUsuario, objGuiaEnvio.coll_Lista_Usuarios, Usuario)
                Else
                    NingunoComboIDs(CboUsuario, objGuiaEnvio.coll_Lista_Usuarios)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Dim ObjfrmBuscarCliente As New frmBuscarCliente
    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Cursor = Cursors.AppStarting

            ObjBusquedaClientes.v_fecha_inicio = CboFechaInicio.Text
            ObjBusquedaClientes.v_fecha_final = CboFechaFin.Text
            Dim ObjfrmBuscarCliente As New frmBuscarCliente
            ObjfrmBuscarCliente.DtpFechaInicio = Me.CboFechaInicio.Text
            ObjfrmBuscarCliente.DtpFechaFin = Me.CboFechaFin.Text
            ObjfrmBuscarCliente.Control = 2
            Acceso.Asignar(ObjfrmBuscarCliente, Me.hnd)

            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                If ObjfrmBuscarCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    '***************
                    Me.Listar(ObjBusquedaClientes.IDDOC)
                    '***************                
                    objControlFacturasBol.iControl = 0
                End If
            Else
                MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            '******************************************************************
            'ObjBusquedaClientes.v_fecha_inicio = CboFechaInicio.Text
            'ObjBusquedaClientes.v_fecha_final = CboFechaFin.Text

            'Acceso.Asignar(ObjfrmBuscarCliente, Me.hnd)
            'If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            '    If ObjfrmBuscarCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '        objControlFacturasBol.iControl = 5
            '        fnBuscarFacturas()
            '        ObjBusquedaClientes.idPersona = 0
            '        objControlFacturasBol.iControl = 0
            '    End If
            'Else
            '    MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            ObjBusquedaClientes.idPersona = 0
        End Try
    End Sub

    Sub Listar(ByVal NroDoc As String)
        Try
            Dim obj As New dtoVentaCargaContado
            Dim dt As DataTable = obj.Listar(2, NroDoc)

            With Me.DgvLista
                .DataSource = dt
                LblRegistros.Text = .Rows.Count
            End With

            If dt.Rows.Count <= 0 Then
                Me.BtnConsultar.Enabled = False            
                MessageBox.Show("No Se Encontraron Coincidencias.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                BtnConsultar.Enabled = True
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Try
            Cursor = Cursors.AppStarting
            objControlFacturasBol.iControl = 1
            Me.fnBuscarFacturas()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(G_Mje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#Region "OPERACIONES"

#Region "Btn Nuevo"
    Dim bNuevo As Boolean
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Try
            Me.Cursor = Cursors.AppStarting
            bNuevo = True
            BtnGrabar.Enabled = True
            recuperando_datos_contado = False
            CboProducto.Enabled = True
            RemoveHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
            CboTipoTarifa.SelectedValue = 1
            AddHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
            Me.TxtFecha.Text = dtoUSUARIOS.m_sFecha '--> Fecha Hora Servidor            

            TxtFecha.Text = ""
            Me.TxtFecha.Format = DateTimePickerFormat.Custom
            Me.TxtFecha.CustomFormat = " "

            Me.fnNUEVO()
            MenuTab.SelectTab(1)
            'Me.DespliegaCboAgencia_Origen()
            'TxtCiudadDestino.Focus()

            '----USUARIO REMOTO---
            Me.LblUsuario.Visible = True
            Me.CboListaUsuarios.Visible = True
            Me.CboListaUsuarios.SelectedValue = 0
            Me.CboListaUsuarios.Enabled = True
            'Me.TxtTotal.ReadOnly = False
            '---------------------
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Btn Editar"
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        Try
            Me.Cursor = Cursors.AppStarting
            iOpcion = 1
            bNuevo = False
            BtnGrabar.Enabled = True
            TxtFecha.Enabled = True           

            '*****************************
            Me.DiseñaGrdDocumentos() '---------> Diseña Grid Documentos clientes
            TipoGrid_ = FormatoGrid.BULTO '----> Grid Bultos
            Me.DiseñaGrdDetalleVenta() '-------> Diseña GridDetalleVenta
            FormatoGrdDetalleVenta() '---------> Formato al grid
            '*****************************

            limpiar_documentos_cliente()
            recuperando_datos_contado = True
            '------------------
            fnControlDatos(2)
            '------------------

            RemoveHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
            CboTipoTarifa.SelectedIndex = 1
            AddHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
            CboProducto.Enabled = False
            TxtNroDocCliente.BackColor = System.Drawing.SystemColors.Control
            TxtNroDocCliente.ReadOnly = True
            TxtNomCliente.BackColor = System.Drawing.SystemColors.Control
            TxtNomCliente.ReadOnly = True
            TxtTelfCliente.BackColor = System.Drawing.SystemColors.Control
            TxtTelfCliente.ReadOnly = True            
            TxtNroDocContacto.BackColor = System.Drawing.SystemColors.Control
            TxtNroDocContacto.ReadOnly = True            
            'TxtTotal.ReadOnly = False

            '--            
            'TxtBoleto.Enabled = True
            'TxtBoleto.BackColor = Color.White
            TxtCiudadDestino.Enabled = True
            TxtCiudadDestino.BackColor = Color.White
            CboAgenciaDest.Enabled = True
            CboAgenciaDest.BackColor = Color.White

            'TxtNroTarjeta.ReadOnly = False
            TxtNroTarjeta.BackColor = System.Drawing.SystemColors.Control
            'txtDescDescto.ReadOnly = False
            txtDescDescto.BackColor = System.Drawing.SystemColors.Control
            TxtReferencia.ReadOnly = True
            TxtReferencia.BackColor = System.Drawing.SystemColors.Control
            'TxtSubtotal.ReadOnly = True
            TxtSubtotal.BackColor = System.Drawing.SystemColors.Control
            'TxtImpuesto.ReadOnly = True
            TxtImpuesto.BackColor = System.Drawing.SystemColors.Control
            'TxtTotal.ReadOnly = False
            TxtTotal.BackColor = System.Drawing.SystemColors.Control

            '----USUARIO REMOTO------
            Me.LblUsuario.Visible = False
            Me.CboListaUsuarios.Visible = False
            Me.CboListaUsuarios.Enabled = False
            Me.CboListaUsuarios.SelectedValue = 0
            '------------------------
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Btn Consultar"
    'Consultar por medio del boton
    Private Sub BtnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        Try
            Me.Cursor = Cursors.AppStarting
            '---------------
            Me.FnConsultar()
            '------------------
            '--USUARIO REMOTO--
            Me.LblUsuario.Visible = False
            Me.CboListaUsuarios.Visible = False
            '------------------
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    'Consultar Evento Double Clik Sobre el Grid
    Private Sub dgvlista_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DgvLista.DoubleClick
        Try
            If Me.DgvLista.Rows.Count > 0 Then
                Me.Cursor = Cursors.AppStarting
                Me.FnConsultar()
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Funcion Consultar
    Dim iOpcion As Integer = 0
    Sub FnConsultar()
        iOpcion = 2
        bNuevo = False
        Me.DiseñaGrdDocumentos() '---> Diseña Grid Documentos clientes
        TipoGrid_ = FormatoGrid.BULTO '--------> Grid Bultos
        Me.DiseñaGrdDetalleVenta() '-> Diseña GridDetalleVenta
        FormatoGrdDetalleVenta() '---> Formato al grid

        recuperando_datos_contado = True
        fnControlDatos(2)
        '**       
        RemoveHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
        CboTipoTarifa.SelectedIndex = 1
        AddHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
        CboProducto.Enabled = True
        '***********************************
        'TxtDirecConsignado.Enabled = True
        txtDescDescto.ReadOnly = False
        GrpDestino.Enabled = True
        CboTarjeta.Enabled = True
        TxtNroTarjeta.ReadOnly = False
        GrpCondicionVenta.Enabled = True
        GrpCliente.Enabled = True
        CboContacto.Enabled = True
        GrpConsignado.Enabled = True
        GrpDescuento.Enabled = True
        GrdDocumentosCliente.ReadOnly = False
        GrdDetalleVenta.ReadOnly = False
        'hlamas 18-03-2016
        'ChkCargo.Enabled = True
        ChkArticulos.Enabled = True
        chkSobres.Enabled = True
        ChkM3.Enabled = True
        txtCantidadSobres.ReadOnly = False
        txtMontoBase.ReadOnly = False
        txtTotalSobre.ReadOnly = False
        BtnCargAseg.Enabled = True
        BtnGrabar.Enabled = True
        TxtSubtotal.ReadOnly = True
        TxtImpuesto.ReadOnly = True
        TxtTotal.ReadOnly = True
        BtnGrabar.Enabled = False
        GrdDetalleVenta.ReadOnly = False
        '----
        TxtNroDocCliente.ReadOnly = False
        TxtNroDocCliente.BackColor = Color.White
        TxtNomCliente.ReadOnly = False
        TxtNomCliente.BackColor = Color.White
        TxtTelfCliente.ReadOnly = False
        TxtTelfCliente.BackColor = Color.White
        TxtNroDocContacto.ReadOnly = False
        TxtNroDocContacto.BackColor = Color.White
        '--
        TxtBoleto.Enabled = True
        TxtBoleto.BackColor = Color.White
        TxtCiudadDestino.Enabled = True
        TxtCiudadDestino.BackColor = Color.White
        CboAgenciaDest.Enabled = True
        CboAgenciaDest.BackColor = Color.White

        TxtNroTarjeta.ReadOnly = False
        TxtNroTarjeta.BackColor = Color.White
        txtDescDescto.ReadOnly = False
        txtDescDescto.BackColor = Color.White
        TxtReferencia.ReadOnly = False
        TxtReferencia.BackColor = Color.White
        'TxtSubtotal.ReadOnly = False
        TxtSubtotal.BackColor = Color.White
        'TxtImpuesto.ReadOnly = False
        TxtImpuesto.BackColor = Color.White
        'TxtTotal.ReadOnly = False
        TxtTotal.BackColor = Color.White

    End Sub

#End Region

#Region "Btn Imprimir"

    'Funciones para imprimir
    Dim ObjRptGuiaEnvio As New dtoRptGuiaEnvio()

    Public Function fnImprimirEtiquetasN95() As Boolean
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
            'Dim i As Int16
            'If bRango Then
            '    i = 1
            'Else
            '    i = correlativo_inicial
            '    'Mod 21/08/2009 
            '    If i = 0 Then i = 1
            'End If
            '''
            Dim i As Int16
            If iRango = 1 Then
                i = 1
            ElseIf iRango = 2 Then
                i = correlativo_inicial
            Else
                i = 1
            End If

            If i <= 0 Then i = 1
            '''''
            ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
            ObjCODIGOBARRA.sp_etiqueta_generada()
            '
            HoraActual = sHora
            ObjCODIGOBARRA.Fecha = sFecha
            '
            'While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
            '    ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(0).Value
            '    prn.EscribeLinea("^XA")
            '    prn.EscribeLinea("^PW400")
            '    prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD " & ObjCODIGOBARRA.NroDOC & "          " & I.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & "^FS")
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
            '
            'hlamas 26-08-2015
            'agregar CARGO para envios con devolucion de cargo
            Dim strCargo As String = "", strFecha As String
            Dim strProducto As String
            Dim strHoraPartida As String
            'Dim strComprobante As String = ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA
            'Dim strComprobante As String = ObjCODIGOBARRA.NroDOC 'ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA

            Dim strComprobante As String
            If Me.DgvLista.CurrentRow.Cells("idProceso").Value = 11 Then
                strComprobante = Me.DgvLista.CurrentRow.Cells("nroboleto").Value
            Else
                strComprobante = Me.DgvLista.CurrentRow.Cells("FAC_BOL").Value
            End If
            For Each fila As DataRow In ObjVentaCargaContado.dt_Cur_CODIGOBARRAS.Rows
                strProducto = ObtieneProducto(Me.DgvLista.CurrentRow.Cells("idProceso").Value)
                strHoraPartida = ObjVentaCargaContado.v_HoraPartida
                ObjCODIGOBARRA.CodigoBarra = fila.Item(0)
                prn.EscribeLinea("^XA")
                prn.EscribeLinea("^PW400")

                'hlamas 14-03-2017
                'prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD " & ObjCODIGOBARRA.NroDOC & "          " & i.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & "^FS")

                If Me.DgvLista.CurrentRow.Cells("Idtipo_Comprobante").Value = 4 Or Me.DgvLista.CurrentRow.Cells("Idtipo_Comprobante").Value = 6 Then
                    prn.EscribeLinea("^FT15,82^A0N,28,28^FH\^FD " & strComprobante & "      " & dtoVentaCargaContado.AgenciaNombreCorto(Me.DgvLista.CurrentRow.Cells("Idagencias_Destino").Value) & "   " & i.ToString & "/" & ObjCODIGOBARRA.Cantidad & "^FS")
                Else
                    prn.EscribeLinea("^FT15,82^A0N,28,28^FH\^FD " & strComprobante & "          " & i.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & "^FS")
                End If

                'prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD " & Me.TextBox1.Text & "^FS")
                'prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & Me.TextBox2.Text & I & "^FS")
                prn.EscribeLinea("^FT14,39^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.clinte & "^FS")
                prn.EscribeLinea("^BY2,2,46^FT190,134^BEN,,Y,N^FD" & ObjCODIGOBARRA.CodigoBarra & "^FS")
                'prn.EscribeLinea("^FT17,131^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")

                'hlamas 22-07-2017
                'If Me.DgvLista.CurrentRow.Cells("idProceso").Value = 11 Then
                'prn.EscribeLinea("^FT96,132^A0N,18,10^FH\^FD" & ObjCODIGOBARRA.Destino2 & " ^FS")
                'Else
                'prn.EscribeLinea("^FT96,132^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")
                'End If
                'hlamas 26-08-2015
                'prn.EscribeLinea("^FT305,188^AAN,18,10^FH\^FDTEPSAC^FS")
                'prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & ObjCODIGOBARRA.Fecha & "^FS")

                prn.EscribeLinea("^FT21,155^AAN,18,10^FH\^FD" & strHoraPartida & "^FS")

                strFecha = ObjCODIGOBARRA.Fecha.Trim & " " & HoraActual.Trim
                prn.EscribeLinea("^FT21,178^AAN,18,10^FH\^FD" & strFecha & "^FS")
                prn.EscribeLinea("^FT255,178^AAN,18,10^FH\^FDTEPSA^FS")
                'prn.EscribeLinea("^FT345,188^AAN,18,10^FH\^FD" & strCargo & "^FS")
                prn.EscribeLinea("^FT340,178^AAN,28,12^FH\^FD" & strProducto & "^FS") '300 20

                'hlamas 26-08-2015
                'prn.EscribeLinea("^FT183,188^AAN,18,10^FH\^FD" & HoraActual & "^FS")

                'hlamas 15-05-2017
                If Me.DgvLista.CurrentRow.Cells("idProceso").Value = 11 Then
                    prn.EscribeLinea("^FT17,131^AAN,18,10^FH\^FD" & Me.DgvLista.CurrentRow.Cells("FAC_BOL").Value & " /^FS")
                    prn.EscribeLinea("^FT17,203^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
                    prn.EscribeLinea("^FT96,203^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Destino2 & " ^FS")

                    'prn.EscribeLinea("^FT17,131^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
                    'prn.EscribeLinea("^FT96,132^A0N,18,10^FH\^FD" & ObjCODIGOBARRA.Destino2 & " ^FS")
                    'prn.EscribeLinea("^FT150,198^AAN,18,10^FH\^FD" & Me.DgvLista.CurrentRow.Cells("FAC_BOL").Value & "")
                Else
                    prn.EscribeLinea("^FT17,131^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
                    prn.EscribeLinea("^FT96,132^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")
                End If

                prn.EscribeLinea("^PQ1,0,1,Y")
                prn.EscribeLinea("^XZ")
                prn.EscribeLinea(cadena)
                'ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
                i = i + 1
            Next

            prn.FinDoc()
        Catch ex As Exception
            flag = False
            Throw New Exception(ex.Message)
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
            'Dim i As Int16
            'If bRango Then
            '    i = 1
            'Else
            '    i = correlativo_inicial
            '    'Mod 21/08/2009 
            '    If i = 0 Then i = 1
            'End If
            '
            Dim i As Int16
            If iRango = 1 Then
                i = 1
            ElseIf iRango = 2 Then
                i = correlativo_inicial
            Else
                i = 1
            End If

            If i <= 0 Then i = 1

            ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
            ObjCODIGOBARRA.sp_etiqueta_generada()
            '
            HoraActual = sHora
            ObjCODIGOBARRA.Fecha = sFecha
            '
            'While objGuiaEnvio.cur_codBarras.EOF = False And objGuiaEnvio.cur_codBarras.BOF = False
            'While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
            '    ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(0).Value

            '    'prn.EscribeLinea("<STX><ESC>C0<ETX>")
            '    'prn.EscribeLinea("<STX><ESC>k<ETX>")
            '    'prn.EscribeLinea("<STX><SI>N60<ETX>")
            '    'prn.EscribeLinea("<STX><SI>L197<ETX>")
            '    'prn.EscribeLinea("<STX><SI>S20<ETX>")
            '    'prn.EscribeLinea("<STX><SI>d0<ETX>")
            '    'prn.EscribeLinea("<STX><SI>h0,0;<ETX>")
            '    'prn.EscribeLinea("<STX><SI>l8<ETX>")
            '    'prn.EscribeLinea("<STX><SI>I3<ETX>")
            '    'prn.EscribeLinea("<STX><SI>F20<ETX>")
            '    'prn.EscribeLinea("<STX><SI>D0<ETX>")
            '    'prn.EscribeLinea("<STX><SI>t0<ETX>")
            '    'prn.EscribeLinea("<STX><SI>W394<ETX>")
            '    'prn.EscribeLinea("<STX><SI>g1,567<ETX>")
            '    'prn.EscribeLinea("<STX><ESC>P<ETX>")
            '    'prn.EscribeLinea("<STX>E*;F*;<ETX>")
            '    'prn.EscribeLinea("<STX>L1;<ETX>")
            '    'prn.EscribeLinea("<STX>D0;<ETX>")
            '    'prn.EscribeLinea("<STX>H0;o165,12;f3;c25;h12;w20;d3," & ObjCODIGOBARRA.clinte & ";<ETX>")
            '    'prn.EscribeLinea("<STX>D1;<ETX>")
            '    'prn.EscribeLinea("<STX>H1;o130,13;f3;c25;h9;w15;d3," & ObjCODIGOBARRA.NroDOC & " -" & I.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & ";<ETX>")
            '    'prn.EscribeLinea("<STX>H2;o88,11;f3;c25;h11;w11;d3," & ObjCODIGOBARRA.Origen & " / ;<ETX>")
            '    'prn.EscribeLinea("<STX>B3;o96,180;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
            '    'prn.EscribeLinea("<STX>H4;o14,13;f3;c25;h7;w7;d3," & ObjCODIGOBARRA.Fecha & ";<ETX>")
            '    'prn.EscribeLinea("<STX>H5;o14,200;f3;c25;h7;w7;d3," & HoraActual & ";<ETX>")
            '    'prn.EscribeLinea("<STX>H6;o14,300;f3;c25;h7;w7;d3,TEPSAC;<ETX>")
            '    'prn.EscribeLinea("<STX>H7;o102,96;f3;c25;h17;w16;d3," & ObjCODIGOBARRA.Destino & ";<ETX>")
            '    'prn.EscribeLinea("<STX>R<ETX>")
            '    'prn.EscribeLinea("<STX><ESC>E*<CAN><ETX>")
            '    'prn.EscribeLinea("<STX><RS>1<US>1<ETB><ETX>")

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
            '    prn.EscribeLinea("<STX>H1;o130,13;f3;c25;h9;w15;d3," & ObjCODIGOBARRA.NroDOC & " -" & I.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & ";<ETX>")
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
            '    ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
            '    I = I + 1
            'End While
            '''''''''''''''
            For Each fila As DataRow In ObjVentaCargaContado.dt_Cur_CODIGOBARRAS.Rows
                ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.dt_Cur_CODIGOBARRAS.Rows(0).Item(0)
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
                prn.EscribeLinea("<STX>H1;o130,13;f3;c25;h9;w15;d3," & ObjCODIGOBARRA.NroDOC & " -" & i.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & ";<ETX>")
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

                prn.EscribeLinea(cadena)
                'ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
                i = i + 1
            Next
            '''''''''''''''
            prn.FinDoc()
        Catch ex As Exception
            flag = False
            Throw New Exception(ex.Message)
        End Try
        Return flag
    End Function

    Function ObtieneProducto(ByVal producto As Integer) As String
        Select Case producto
            Case 0
                Return ""
            Case 6
                Return "CA"
            Case 8
                Return "TC"
            Case 10
                Return "SOB"
            Case 11
                Return "EQ"
            Case 81
                Return "BOX"
            Case 82
                Return "BOX2"
        End Select
    End Function

    Public Function GC420Encomienda() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.HoraImpresion
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()
            Dim strProducto As String
            Dim strHoraPartida As String
            'Dim strComprobante As String = ObjCODIGOBARRA.NroDOC 'ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA
            Dim strComprobante As String
            If Me.DgvLista.CurrentRow.Cells("idProceso").Value = 11 Then
                strComprobante = Me.DgvLista.CurrentRow.Cells("nroboleto").Value & "  " & dtoVentaCargaContado.AgenciaNombreCorto(Me.DgvLista.CurrentRow.Cells("Idagencias_Destino").Value)
            Else
                strComprobante = Me.DgvLista.CurrentRow.Cells("FAC_BOL").Value & "  " & dtoVentaCargaContado.AgenciaNombreCorto(Me.DgvLista.CurrentRow.Cells("Idagencias_Destino").Value)
            End If
            Dim i As Int16
            If iRango = 1 Then
                i = correlativo_inicial
                If i = 0 Then i = 1
            ElseIf iRango = 2 Then
                i = correlativo_inicial
            Else
                i = 1
            End If

            If i <= 0 Then i = 1

            '
            ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
            ObjCODIGOBARRA.sp_etiqueta_generada()

            HoraActual = sHora
            ObjCODIGOBARRA.Fecha = sFecha

            'hlamas 26-08-2015
            'agregar CARGO para envios con devolucion de cargo
            Dim strCargo As String, strFecha As String
            strCargo = IIf(Me.rbtCargoSi.Checked, "CARGO", "")
            For Each fila As DataRow In ObjVentaCargaContado.dt_Cur_CODIGOBARRAS.Rows
                strProducto = ObtieneProducto(Me.DgvLista.CurrentRow.Cells("idProceso").Value)
                strHoraPartida = Me.DgvLista.CurrentRow.Cells("hora_partida").Value
                ObjCODIGOBARRA.CodigoBarra = fila.Item(0)
                prn.EscribeLinea("N")
                prn.EscribeLinea("N")
                prn.EscribeLinea("A30,9,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")

                If Me.DgvLista.CurrentRow.Cells("Idtipo_Comprobante").Value = 4 Or Me.DgvLista.CurrentRow.Cells("Idtipo_Comprobante").Value = 6 Then
                    prn.EscribeLinea("A30,37,0,4,1,1,N,""" & strComprobante & """")
                    prn.EscribeLinea("A310,37,0,3,1,1,N,""" & i.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
                Else
                    prn.EscribeLinea("A30,37,0,4,1,1,N,""" & ObjCODIGOBARRA.NroDOC & " -" & i.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
                    prn.EscribeLinea("A317,37,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
                End If
                'prn.EscribeLinea("A30,85,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-""")
                prn.EscribeLinea("A30,118,0,3,1,1,N,""" & strHoraPartida & """")

                strFecha = ObjCODIGOBARRA.Fecha.Trim & " " & HoraActual.Trim
                prn.EscribeLinea("A30,148,0,1,1,1,N,""" & strFecha & """")
                prn.EscribeLinea("A230,148,0,1,1,1,N,""JOTASYS""")
                prn.EscribeLinea("A350,148,0,4,1,1,N,""" & strProducto & """") '290 3

                'hlamas 15-05-2017
                If Me.DgvLista.CurrentRow.Cells("idProceso").Value = 11 Then
                    'prn.EscribeLinea("A150,167,0,2,1,1,N,""" & Me.DgvLista.CurrentRow.Cells("FAC_BOL").Value & """")
                    prn.EscribeLinea("A30,85,0,2,1,1,N,""" & Me.DgvLista.CurrentRow.Cells("FAC_BOL").Value & """")
                    prn.EscribeLinea("A30,167,0,2,1,1,N,""" & ObjCODIGOBARRA.Origen & "-""")
                    prn.EscribeLinea("A85,167,0,2,1,2,N,""" & ObjCODIGOBARRA.Destino2 & """")
                Else
                    prn.EscribeLinea("A30,85,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-""")
                    prn.EscribeLinea("A89,75,0,2,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
                End If

                prn.EscribeLinea("B162,69,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """") 'b148
                prn.EscribeLinea("P1")
                prn.EscribeLinea("N")
                prn.EscribeLinea(cadena)
                i = i + 1
            Next
            '''''''''''''''''''''''''''''''''''''''
            prn.FinDoc()
        Catch ex As Exception
            flag = False
            Throw New Exception(ex.Message)
        End Try
        Return flag
    End Function

#End Region

#Region "Btn Ticket"

    Dim sFecha As String
    Dim sHora As String
    Private Sub BtnTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTicket.Click
        Try
            Me.Cursor = Cursors.AppStarting
            Dim objEtiqueta As New dtoGuiaEnvio
            Dim ll_idusuario_tmp As Long
            ObjVentaCargaContado.V_CONTROL_PCE = False
            If DgvLista.Rows().Count = 0 Then
                Me.Cursor = Cursors.Default
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            Dim row As Integer = DgvLista.SelectedRows.Item(0).Index
            If DgvLista.Rows().Count = row Then
                Me.Cursor = Cursors.Default
                MsgBox("Debe Elegir Un Item Valido de La Lista,...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If

            If MsgBox("Esta Seguro de Imprimir Etiquetas..?", MsgBoxStyle.YesNo, "Seguridad Sistemas") = MsgBoxResult.No Then Me.Cursor = Cursors.Default : Exit Sub

            Dim v_idFacura As Integer = DgvLista.Rows(row).Cells("Idfactura").Value
            'Verifica si documento para el cual se reimprimiran etiquetas ya ha sido impreso
            Dim iDoc As Integer
            Dim sDoc As String
            If Mid(DgvLista.Rows(row).Cells("Tipo").Value, 1, 1) = "B" Then
                iDoc = 2
                sDoc = "BOLETA"
            ElseIf Mid(DgvLista.Rows(row).Cells("Tipo").Value, 1, 1) = "F" Then
                iDoc = 1
                sDoc = "FACTURA"
            ElseIf Mid(DgvLista.Rows(row).Cells("Tipo").Value, 1, 1) = "E" Then
                iDoc = 4
                sDoc = "EQUIPAJE"
            Else
                iDoc = 85
                sDoc = "PCE"
            End If

            If objEtiqueta.fnEtiquetaImpresa(iDoc, DgvLista.Rows(row).Cells("Idfactura").Value) Then
                'hlamas 30-10-2015 el usuario que reimprime debe ingresar login y password
                If objEtiqueta.dt_cur_etiqueta.Rows(0)(0) = 1 Then
                    'Obtener usuario y password de usuario que reimprime
                    ll_idusuario_tmp = dtoUSUARIOS.IdLogin
                    Dim lfrmusuario_entrega As New frmUsuarioEtiqueta
                    lfrmusuario_entrega.Lab_tip_dcto.Text = sDoc '24/10/2008
                    lfrmusuario_entrega.txt_dcto.Text = DgvLista.Rows(row).Cells("FAC_BOL").Value '24/10/2008
                    lfrmusuario_entrega.txt_origen.Text = DgvLista.Rows(row).Cells("Origen").Value
                    lfrmusuario_entrega.txt_destino.Text = DgvLista.Rows(row).Cells("Destino").Value

                    lfrmusuario_entrega.txtLogin.Text = dtoUSUARIOS.iLOGIN
                    lfrmusuario_entrega.txtPasswor.Focus()

                    'lfrmusuario_entrega.ShowDialog()
                    Acceso.Asignar(lfrmusuario_entrega, Me.hnd)
                    'If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                    lfrmusuario_entrega.ShowDialog()
                    'Else
                    'Me.Cursor = Cursors.Default
                    'MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'Return
                    'End If

                    If lfrmusuario_entrega.pb_cancelar = True Then
                        Me.Cursor = Cursors.Default
                        Exit Sub ' No hace nada 
                    End If
                    'dtoUSUARIOS.IdLogin = lfrmusuario_entrega.pl_idusuario_personal
                    ll_idusuario_tmp = lfrmusuario_entrega.pl_idusuario_personal
                End If
            End If

            'Genera etiquetas
            Dim sMotivo As String
            Dim sEtiqueta As String
            Dim ll_total As Long
            '
            ll_total = DgvLista.Rows(row).Cells("Cantidad").Value
            '
            If objEtiqueta.dt_cur_etiqueta.Rows(0)(0) = 1 Then
                Dim a As New FrmRangoEtiquetas()
                a.total_bultos = ll_total
                'a.ShowDialog()
                'Acceso.Asignar(a, Me.hnd)
                'If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                a.ShowDialog()
                If a.DialogResult = Windows.Forms.DialogResult.Cancel Then
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                sMotivo = a.txtMotivo.Text
                sEtiqueta = a.NumeUDini.Value
                'bRango = False
                iRango = 2
                'Else
                'MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Return
                'End If
            Else
                Dim a As New FrmRangoEtiquetas2()
                '
                a.total_bultos = ll_total
                '
                'a.ShowDialog()
                'Acceso.Asignar(a, Me.hnd)
                'If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                a.ShowDialog()
                If a.DialogResult = Windows.Forms.DialogResult.Cancel Then
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                'bRango = True
                iRango = 1
                'Else
                'Me.Cursor = Cursors.Default
                'MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Return
                'End If
            End If

            If correlativo_inicial = -1 Then Me.Cursor = Cursors.Default : Exit Sub

            'If ObjVentaCargaContado.fnREIMPRESIONCODIGOS(1, v_idFacura) = True Then
            ObjVentaCargaContado.UsuarioEtiqueta = ll_idusuario_tmp
            Dim aaa As Integer = ObjCODIGOBARRA.Cantidad
            If ObjVentaCargaContado.fnREIMPRESIONCODIGOSII(1, v_idFacura, correlativo_inicial, correlativo_final) = True Then
                'If MsgBox("Esta Seguro de Imprimir Etiquetas..?", MsgBoxStyle.YesNo, "Seguridad Sistemas") = MsgBoxResult.Yes Then
                '''''''''
                'hlamas 26/08/2009
                'Obtiene Fecha y Hora
                ObjVentaCargaContado.fnFechaRegistro(iDoc, v_idFacura)
                sFecha = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(0)
                sHora = ObjVentaCargaContado.dt_rstFechaRegistro.Rows(0).Item(1)


                If xIMPRESORA = 1 Or xIMPRESORA = 4 Then 'xIMPRESORA = 1
                    fnImprimirEtiquetasN95()
                Else
                    If xIMPRESORA = 2 Then
                        fnImprimirEtiquetasFAC_IIN95()
                    Else
                        'hlamas 18/09/2019
                        'fnImprimirEtiquetasFAC_IIN97()
                        If Me.DgvLista.CurrentRow.Cells("idproceso").Value = 11 Or Me.DgvLista.CurrentRow.Cells("idproceso").Value = 6 Then
                            If dtoUSUARIOS.FormatoTicket = 2 Then
                                GC420Exceso()
                            Else
                                GC420Encomienda()
                            End If
                        Else
                            GC420Encomienda()
                        End If
                    End If

                    If objEtiqueta.dt_cur_etiqueta.Rows(0)(0) = 1 Then
                        'Actualiza auditoria de reimpresion de etiquetas
                        Dim objReimpresionEtiquetas As New dtoGuiaEnvio
                        If objReimpresionEtiquetas.fnActualizaReimpresion(iDoc, DgvLista.Rows(row).Cells("idfactura").Value, ObjCODIGOBARRA.CodigoBarra, sMotivo, CDate(ObjCODIGOBARRA.Fecha), ll_idusuario_tmp, ObjCODIGOBARRA.fnGetHora, sEtiqueta) Then
                        End If
                    Else
                        ObjCODIGOBARRA.tipo = iDoc
                        ObjCODIGOBARRA.id = v_idFacura
                        ObjCODIGOBARRA.sp_etiqueta_generada()
                    End If

                End If
                'End If
            Else
                MsgBox("No puede cargar esta data, faltan datos...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If

            If objEtiqueta.dt_cur_etiqueta.Rows(0)(0) = 1 Then
                'dtoUSUARIOS.IdLogin = ll_idusuario_tmp
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Btn Exportar"
    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        Try
            Me.Cursor = Cursors.AppStarting
            fnEXCELGrid(Me.DgvLista)
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Btn Anular"
    Private Sub BtnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnular.Click
        Try
            Dim sComprobante As String = Me.DgvLista.CurrentRow.Cells("FAC_BOL").Value
            Dim iComprobante As Integer = Me.DgvLista.CurrentRow.Cells("IdFactura").Value
            Dim iTipo As Integer = Me.DgvLista.CurrentRow.Cells("idtipo_comprobante").Value

            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está seguro de anular el comprobante Nº " & sComprobante & "?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Dim frm As New frmMotivoAnulacion
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    Dim strMotivo As String = frm.txtMotivo.Text.Trim
                    'Anular(iComprobante, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IdRol, dtoUSUARIOS.IP, iOpcion)
                    Dim iOpcion As Integer = 0
                    If Acceso.SiRol(G_Rol, Me, 2) Then
                        iOpcion = 1
                    End If
                    Dim dt As DataTable = ValidarAnulacion(iComprobante, dtoUSUARIOS.IdLogin, iOpcion)
                    Dim strTipo As String = IIf(iTipo = 1, "01", "03")
                    If dt.Rows(0).Item(0) = 1 Then 'El comprobante paso las reglas del negocio OK
                        If iTipo = 4 Then
                            AnularComprobante(iComprobante, strMotivo, dtoUSUARIOS.IdLogin, dtoUSUARIOS.Rol, dtoUSUARIOS.IP)
                            Cursor = Cursors.Default
                            MessageBox.Show("El Ticket de Equipaje Nº " & sComprobante & " ha sido Anulado.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.fnBuscarFacturas()
                        Else
                            If Me.DgvLista.CurrentRow.Cells("n_emife").Value = 1 Then
                                'hlamas 01-06-2016
                                'Valida si comprobante puede ser anulado
                                Dim strFecha As String = Me.DgvLista.CurrentRow.Cells("Fecha_Factura").Value
                                Dim strComprobante As String = Me.DgvLista.CurrentRow.Cells("FAC_BOL").Value
                                Dim intPosicion As Integer = InStr(strComprobante, "-")
                                'Dim strSerie As String = IIf(iTipo = 1, "F", "B") & strComprobante.Substring(0, intPosicion - 1)
                                Dim strSerie As String = strComprobante.Substring(0, intPosicion - 1)
                                Dim strNumero As String = strComprobante.Substring(intPosicion)
                                strNumero = strNumero.PadLeft(8, "0")

                                'hlamas 19-02-2019
                                Dim intUsuarioAutoriza As Integer = 0
                                'hlamas 30-09-2019
                                'If iOpcion = 0 AndAlso Me.DgvLista.CurrentRow.Cells("idProceso").Value = 6 Then 'si comprobante es CA y usuario no está autorizado para anular
                                If iOpcion = 0 Then 'si usuario no está autorizado para anular
                                    Dim frmusuarioDescuento As New frmUsuarioDescuento
                                    frmusuarioDescuento.Text = "Autoriza Anulación"
                                    frmusuarioDescuento.Venta = 2
                                    frmusuarioDescuento.Descuento = 1
                                    'hlamas 30-09-2019
                                    frmusuarioDescuento.llamada = 1
                                    frmusuarioDescuento.ShowDialog()
                                    If frmusuarioDescuento.DialogResult = Windows.Forms.DialogResult.Cancel Then
                                        Cursor = Cursors.Default
                                        Return
                                    Else
                                        intUsuarioAutoriza = frmusuarioDescuento.cboUsuario.SelectedValue
                                    End If
                                End If

                                Dim blnAnulable As Boolean = FEManager.isAvoidable(strTipo, strFecha, strSerie, strNumero, strMotivo)
                                If Not blnAnulable Then
                                    Cursor = Cursors.Default
                                    MessageBox.Show("El Comprobante no puede ser Anulado F.E.", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Else
                                    AnularComprobante(iComprobante, strMotivo, dtoUSUARIOS.IdLogin, dtoUSUARIOS.Rol, dtoUSUARIOS.IP, intUsuarioAutoriza)
                                    Cursor = Cursors.Default
                                    MessageBox.Show("La " & IIf(iTipo = 1, "Factura", "Boleta") & " Nº " & sComprobante & " ha sido Anulada.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Me.fnBuscarFacturas()
                                End If
                            Else
                                Cursor = Cursors.Default
                                MessageBox.Show("El Comprobante no puede ser Anulado, F.E." & Chr(13) & "Antes de Anularlo, envielo a SUNAT", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If
                    Else
                        Me.Cursor = Cursors.Default
                        MessageBox.Show(dt.Rows(0).Item(1), "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub AnularComprobante(ByVal comprobante As String, ByVal motivo As String, ByVal usuario As Integer, ByVal rol As Integer, ByVal ip As String, Optional ByVal autoriza As Integer = 0)
        Try
            Dim obj As New dtoGuia
            obj.AnularComprobante(comprobante, motivo, usuario, rol, ip, autoriza)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Function ValidarAnulacion(ByVal comprobante As String, ByVal usuario As Integer, ByVal opcion As Integer) As DataTable
        Try
            Dim obj As New dtoGuia
            Return obj.ValidarAnulacion(comprobante, usuario, opcion)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'CambioR 09112011
    Sub FormatoColorDgvLista()
        For i As Integer = 0 To Me.DgvLista.RowCount - 1
            If DgvLista.Rows(i).Cells("Idestado_Factura").Value = 2 Then
                DgvLista.Rows(i).DefaultCellStyle.BackColor = Color.Red
                DgvLista.Rows(i).DefaultCellStyle.ForeColor = Color.White
                'DgvLista.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(255, 0, 0)
            End If
        Next
    End Sub
#End Region


#Region "Btn Devolucion"

    Private ObjProcesosVentaContado As New FrmProcesosVentaContado
    Dim IDGRIESTADO_REG As Integer = 27
    Dim IDFACTURADO_REG As Integer = 28
    Private Sub BtnDevolucion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDevolucion.Click
        Try
            Me.Cursor = Cursors.AppStarting
            ObjVentaCargaContado.V_CONTROL_PCE = False

            If DgvLista.Rows().Count = 0 Then
                Return
            End If

            Dim row As Integer = DgvLista.SelectedRows.Item(0).Index
            If DgvLista.Rows().Count = row Then
                Return
            End If
            '***************************
            Dim Serie_Nro As String = Me.DgvLista.CurrentRow.Cells("FAC_BOL").Value
            Dim iGuia As Integer = Me.DgvLista.CurrentRow.Cells("IdFactura").Value
            Dim iTipo As Integer = Me.DgvLista.CurrentRow.Cells("idtipo_comprobante").Value

            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está seguro de Realizar la devolucion?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.AppStarting
                Dim iOpcion As Integer = 0
                If Acceso.SiRol(G_Rol, Me, 2) Then
                    iOpcion = 1
                End If
                Devolver(iGuia, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IdRol, dtoUSUARIOS.IP, 100, iOpcion)
                Me.Cursor = Cursors.Default
                MessageBox.Show("El Comprobante Nº " & Serie_Nro & " ha sido Devuelta.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnBuscar_Click(sender, e)
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Devolver(ByVal comprobante As String, ByVal usuario As Integer, _
         ByVal rol As Integer, ByVal ip As String, ByVal porcentaje As Double, ByVal opcion As Integer)
        Try
            Dim obj As New dtoGuia
            obj.Devolver(comprobante, usuario, rol, ip, porcentaje, opcion)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region

#Region "Btn Salir"
    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
#End Region

#End Region

#Region "MENU CONTEXTUAL"
    'EXPORTAR A EXCEL
    Private Sub ExportExcel_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Cursor = Cursors.AppStarting
            '----------------------------
            fnEXCELGrid(DgvLista)
            '----------------------------
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'ACTUALIZAR COMPROBANTE
    Private Sub ActualizarComprobante_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizarComprobante_MenuItem.Click
        Dim flag As Boolean = False
        Dim dgrv0 As DataGridViewRow
        Dim ls_documento As String
        Dim ls_tipo_comprobante As String
        Try
            Me.Cursor = Cursors.AppStarting
            'Rol (24) Fiscalización
            'If fnValidar_Rol("24") Then
            'bloque

            'If Acceso.SiRol(G_Rol, Me, 7) Then
            '    flag = True
            'End If
            'If flag = False Then
            '    Me.Cursor = Cursors.Default
            '    MsgBox("Usted no tiene Acceso", MsgBoxStyle.Information, "Seguridad Sistema")
            '    Exit Sub
            'End If
            '

            If Me.DgvLista.Rows.Count < 1 Then
                Me.Cursor = Cursors.Default
                MsgBox("No se encontro ningún registro", MsgBoxStyle.Information, "Sistema Titán")
                Exit Sub
            End If
            ' 
            dgrv0 = Me.DgvLista.CurrentRow()
            ls_tipo_comprobante = CType(dgrv0.Cells("tipo_comprobante").Value, String)
            ls_documento = CType(dgrv0.Cells("FAC_BOL").Value, String)
            Dim resp As DialogResult = MessageBox.Show("Está seguro(a) de actualizar el(la) " & ls_tipo_comprobante & " Nº " & ls_documento & "?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resp = Windows.Forms.DialogResult.Yes Then
                ' 
                'Actualiza los datos para venta al contado 
                '
                Dim a As New frm_actualiza_venta_contado
                a.ps_tipo_venta = "C"
                a.pl_idforma_pago = CType(dgrv0.Cells("Idforma_Pago").Value, Long)
                a.ps_idcomprobante = CType(dgrv0.Cells("idfactura").Value, String)
                a.pl_idtipo_comprobante = CType(dgrv0.Cells("Idtipo_Comprobante").Value, Long)
                ' a.pl_idunidad_agencia = CType(dgrv0.Cells("Idunidad_Destino").Value, Long) 'err
                a.pl_idagencia_destino = CType(dgrv0.Cells("Idagencias_Destino").Value, Long)
                a.ps_razon_social = CType(dgrv0.Cells("razon_social").Value, String)
                a.pd_tot_costo = CType(dgrv0.Cells("Total_Costo").Value, Double)
                a.pd_monto_sub_total = CType(dgrv0.Cells("Monto_Sub_Total").Value, Double)
                a.pd_monto_impuesto = CType(dgrv0.Cells("Monto_Impuesto").Value, Double)
                a.ps_tipo_comprobante = CType(dgrv0.Cells("tipo_comprobante").Value, String)
                a.ps_documento = CType(dgrv0.Cells("FAC_BOL").Value, String)
                a.ps_agencia_origen = CType(dgrv0.Cells("Origen").Value, String)
                ' a.ps_fecha_documento = CType(dgrv0.Cells("fecha_documento").Value, String) 'err
                '
                a.pl_idunidad_agencia_origen = CType(dgrv0.Cells("Idunidad_Origen").Value, Long)
                a.pl_idagencia_origen = CType(dgrv0.Cells("idagencia_origen").Value, Long)
                a.ps_documento_identidad = CType(dgrv0.Cells("DNI_RUC").Value, String)

                'a.pl_proceso = CType(dgrv0.Cells("idprocesos").Value, Long) 'err
                a.ps_boleto = CType(IIf(IsDBNull(dgrv0.Cells("nroboleto").Value), "", dgrv0.Cells("nroboleto").Value), String)
                ' a.pl_envio = CType(dgrv0.Cells("idEstado_envio").Value, Long) '--err
                a.pl_doc = CType(dgrv0.Cells("idEstado_factura").Value, Long)
                a.ps_idpersona = CType(dgrv0.Cells("idcliente").Value, Long)
                '
                'a.ShowDialog()
                a.cmbagencias_destinos.Enabled = intPerfil = 1
                Acceso.Asignar(a, Me.hnd)
                If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                    a.ShowDialog()
                Else
                    Me.Cursor = Cursors.Default
                    MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                If a.pb_cancela = False Then
                    fnBuscarFacturas()
                End If
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'CAMBIAR PCE A CREDITO
    'Private Sub PCE_MenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim ll_rol_usuario As Long
    '    Dim flag As Boolean = False
    '    Dim dgrv0 As DataGridViewRow
    '    Dim ls_documento As String
    '    Dim ls_tipo_comprobante As String
    '    Dim ll_facturado As Long
    '    '
    '    Try
    '        Me.Cursor = Cursors.AppStarting
    '        ll_rol_usuario = dtoUSUARIOS.m_iIdRol
    '        'Rol (36) Servicio al cliente 
    '        'If fnValidar_Rol("36") = True Then
    '        'bloque
    '        If Acceso.SiRol(G_Rol, Me, 8) Then
    '            dgrv0 = Me.DgvLista.CurrentRow()
    '            'ls_tipo_comprobante = CType(dgrv0.Cells("tipo_comprobante").Value, String)
    '            ll_facturado = CType(dgrv0.Cells("Facturado").Value, Long)
    '            If ll_facturado = 1 Then
    '                Me.Cursor = Cursors.Default
    '                MsgBox("El PCE está facturado, no se puede cambiar a crédito", MsgBoxStyle.Information, "PCE a Crédito")
    '                Exit Sub
    '            End If
    '            ls_tipo_comprobante = CType(dgrv0.Cells("tipo").Value, String)
    '            If ls_tipo_comprobante = "PCE" Then ' 85 Pce 
    '                ls_documento = CType(dgrv0.Cells("FAC_BOL").Value, String)
    '                Dim resp As DialogResult = MessageBox.Show("Está seguro(a) de actualizar la Guía de envío Nº  " & ls_documento & " ? ", "PCE a Crédito", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '                If resp = Windows.Forms.DialogResult.Yes Then
    '                    Dim lobj_pce_a_credito As New frm_pce_a_credito
    '                    lobj_pce_a_credito.pl_idfactura_contado = CType(dgrv0.Cells("idfactura").Value, String)
    '                    lobj_pce_a_credito.ps_nro_guia_envio = ls_documento
    '                    'lobj_pce_a_credito.ShowDialog()

    '                    Acceso.Asignar(lobj_pce_a_credito, Me.hnd)
    '                    If Acceso.TieneAcceso(G_Rol, G_Fila) Then
    '                        lobj_pce_a_credito.ShowDialog()
    '                    Else
    '                        Me.Cursor = Cursors.Default
    '                        MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                        Return
    '                    End If

    '                    ' Cancelar y refrescar
    '                    If lobj_pce_a_credito.pb_cancelar = False Then
    '                        fnBuscarFacturas()
    '                    End If
    '                End If
    '            Else
    '                MsgBox("El documento seleccionado no es PCE, no se puede cambiar a Crédito", MsgBoxStyle.Information, "PCE a Crédito")
    '            End If
    '        Else
    '            MsgBox("Usted no tiene Acceso a cambiar PCE a Guías Crédito, debe solicitarlo al servicio al cliente", MsgBoxStyle.Information, "PCE a Crédito")
    '        End If
    '        dtoUSUARIOS.m_iIdRol = ll_rol_usuario
    '        Me.Cursor = Cursors.Default
    '    Catch ex As Exception
    '        Me.Cursor = Cursors.Default
    '        MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

#End Region

    '***************FUNCION PARA BUSCAR LAS FACTURAS EMITIDAS POR [Origen,Destino,Fecha Inicio,Fecha fin,Agencia,Usuario,Estado,Nro Doc,N ro Comprobante]
    Dim dtControl_FAC As New System.Data.DataTable
    Dim dvControl_FAC As System.Data.DataView
    Dim bformatImage As Boolean = False
    Public Function fnBuscarFacturas() As Boolean
        Try
            objControlFacturasBol.origen = Int(ObjVentaCargaContado.coll_OrigDest(CboOrigen.SelectedIndex.ToString))
            objControlFacturasBol.destino = Int(ObjVentaCargaContado.coll_OrigDest(CboDestino.SelectedIndex.ToString))

            If objControlFacturasBol.iControl = 5 Then
                objControlFacturasBol.idUsuario = ObjBusquedaClientes.idPersona
            Else
                objControlFacturasBol.idUsuario = Int(objGuiaEnvio.coll_Lista_Usuarios(CboUsuario.SelectedIndex.ToString))
            End If

            Dim strNroDoc As String() = Split(txtNroSerieDoc.Text.Trim, "-")

            If strNroDoc.Length > 1 Then
                If strNroDoc(0).Trim.Length > 1 And Val(strNroDoc(1)) > 0 Then
                    objControlFacturasBol.serie = strNroDoc(0)
                    objControlFacturasBol.nrodoc = strNroDoc(1)
                Else
                    objControlFacturasBol.serie = "0"
                    objControlFacturasBol.nrodoc = strNroDoc(0)
                End If

            Else
                If strNroDoc.Length = 1 Then
                    objControlFacturasBol.serie = "0"
                    objControlFacturasBol.nrodoc = "0"
                    If txtNroSerieDoc.Text <> "   -" Then
                        objControlFacturasBol.nrodoc = strNroDoc(0)
                    End If
                Else
                    objControlFacturasBol.serie = "0"
                    objControlFacturasBol.nrodoc = "0"
                End If

            End If

            If objControlFacturasBol.iControl = 5 Then
                objControlFacturasBol.serie = ObjBusquedaClientes.IDTIPO
                objControlFacturasBol.nrodoc = ObjBusquedaClientes.IDDOC
            End If

            objControlFacturasBol.Agencia = CboAgencia.SelectedValue
            objControlFacturasBol.RucRazonSocial = IIf(txtClienteDNIRUC.Text <> "", txtClienteDNIRUC.Text, "0")
            objControlFacturasBol.estadoFactura = Int(ObjVentaCargaContado.coll_Estados(CboEstado.SelectedIndex.ToString))
            objControlFacturasBol.fecha_inicio = CboFechaInicio.Text
            objControlFacturasBol.fecha_final = CboFechaFin.Text
            objControlFacturasBol.TipoComprobante = Me.cboTipoComprobante.SelectedIndex
            If Me.TxtBoletoViaje.Text.Trim.Length > 0 Then
                objControlFacturasBol.boleto = Me.TxtBoletoViaje.Text.Trim
            End If

            If objControlFacturasBol.fnControlfacturasBol_2() = True Then
                dtControl_FAC.Clear()
                dvControl_FAC = objControlFacturasBol.dt_rstFacturasBol.DefaultView ' dtControl_FAC.DefaultView
                DgvLista.DataSource = dvControl_FAC
            Else
                MessageBox.Show("No Se Encontraron Coincidencias.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ActivarDesactivar(False)
            End If
            Me.FormatoColorDgvLista() 'CambioR 09112011
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return False
    End Function

    '******FUNCION USADO POR CONSULTAR,EDITAR********************************************************
    Dim iIdFactura As Integer
    Public Function fnControlDatos(ByVal var As Integer) As Boolean
        Try
            Dim row As Integer = DgvLista.SelectedRows.Item(0).Index
            Dim v_idFacura As Long = DgvLista.Rows(row).Cells("idfactura").Value
            iIdFactura = v_idFacura

            ObjVentaCargaContado.v_IDFACTURA = v_idFacura
            Dim ds As DataSet = ObjVentaCargaContado.fnVERDATA_VII(v_idFacura)
            RecuperarVenta(var, ds)

            GrdDocumentosCliente.ClearSelection()
            GrdDetalleVenta.ClearSelection()

            MenuTab.SelectTab(1)
            GrdDetalleVenta.Focus()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return False
    End Function

    '********FUNCION RECUPERANDO LOS DATOS DE LA FACTURA A EDITAR O CONSULTAR*************************
    Dim b_no_lee_tipo_entrega As Boolean = True
    Dim flagPCE As Boolean = False
    Dim TipoEntrega_ As Integer
    Dim bclienteCont As Boolean
    Dim bclienteConsig As Boolean

    Private Function RecuperarVenta(ByVal idControl As Integer, ByVal ds As DataSet) As Boolean
        Dim iContador As Integer = 0
        Me.btnEnviarSunat.Visible = False
        Try
            'hlamas 22-11-2013
            'If GrdDetalleVenta.Rows.Count = 5 Then
            'GrdDetalleVenta.Rows.RemoveAt(4)
            'End If

            bDirecConsigMod = False
            bContactoModificado = False
            bDireccionModificada = False
            fArticulo = False
            DtArticulos = Nothing

            Me.Text = "Mantenimiento Venta Contado" ' & "  [Ciudad Origen " & ObjVentaCargaContado.v_UNIDAD_ORIGEN & "]"

            '--------------------
            'If ObjVentaCargaContado.TarifarioGeneral = 1 Then
            '    bTarifarioGeneral = True
            'Else
            '    bTarifarioGeneral = False
            'End If
            ''--------------------
            'If ObjVentaCargaContado.Contado = 1 Then
            '    bContado = True
            'Else
            '    bContado = False
            'End If

            '**RECUPERANDO EL PRODUCTO****************************
            RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            CboProducto.SelectedValue = ObjVentaCargaContado.v_proceso
            iProceso = ObjVentaCargaContado.v_proceso
            AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            '**RECUPERANDO EL TIPO DE TARIFA**********************
            RemoveHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
            CboTipoTarifa.SelectedValue = ObjVentaCargaContado.TipoTarifa
            AddHandler CboTipoTarifa.SelectedIndexChanged, AddressOf CboTipoTarifa_SelectedIndexChanged
            '**RECUPERANDO LA [FECHA EMITIDA]*********************
            Me.TxtFecha.Text = ObjVentaCargaContado.v_FECHA_FACTURA
            '**RECUPERANDO LA SERIE*********************************
            'Me.TxtSerie.Text = ObjVentaCargaContado.v_SERIE_FACTURA
            Me.TxtSerie.Text = ObjVentaCargaContado.v_SERIE_FACTURA
            '**RECUPERANDO EL NRO DE [BOLETA O FACTURA]*************
            'Me.TxtNroDoc.Text = ObjVentaCargaContado.v_NRO_FACTURA
            Me.TxtNroDoc.Text = ObjVentaCargaContado.v_NRO_FACTURA
            '**RECUPERANDO DATOS DEL ORIGEN*************************
            ObjVentaCargaContado.fnGetAgencias_2(ObjVentaCargaContado.v_IDAGENCIAS)
            'Ciudad origen
            'LblCiudad.Text = ObjVentaCargaContado.v_UNIDAD_ORIGEN
            CboCiudadOrigen.SelectedValue = ObjVentaCargaContado.v_IDUNIDAD_ORIGEN
            'dtoUSUARIOS.m_idciudad = ObjVentaCargaContado.v_IDUNIDAD_ORIGEN
            'Agencia origen
            'LblAgencia.Text = ObjVentaCargaContado.dt_rstVarAgencias_2.Rows(0).Item(0)
            CboAgenciaOrigen.Text = ObjVentaCargaContado.dt_rstVarAgencias_2.Rows(0).Item(0)
            '**RECUPERANDO DATOS DEL DESTINO************************
            'Ciudad Destino
            Me.TxtCiudadDestino.Text = ObjVentaCargaContado.v_UNIDAD_DESTINO
            iOficinaDestino = ObjVentaCargaContado.v_IDUNIDAD_DESTINO
            idUnidadAgencias = ObjVentaCargaContado.v_IDUNIDAD_DESTINO
            Me.TxtCiudadDestino.Tag = ObjVentaCargaContado.v_IDUNIDAD_DESTINO
            'Agencia Destino
            'ObjVentaCargaContado.fnGetAgencias(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            'ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_VarAgencias, CboAgenciaDest, ObjVentaCargaContado.coll_AgenciasVenta, ObjVentaCargaContado.v_IDAGENCIAS_DESTINO)

            ObjVentaCargaContado.fnGetAgencias(ds.Tables(0).Rows(0).Item("IDDESTINO"))
            Dim DtAgenciaDestino As DataTable = ObjVentaCargaContado.dt_VarAgencias.Copy
            With Me.CboAgenciaDest
                DtAgenciaDestino = ObjVentaCargaContado.dt_VarAgencias.Copy
                .DataSource = DtAgenciaDestino
                .DisplayMember = "nombre_agencia"
                .ValueMember = "idagencias"
                .SelectedValue = ObjVentaCargaContado.v_IDAGENCIAS_DESTINO
            End With


            'dtoUSUARIOS.m_iIdAgencia = ObjVentaCargaContado.v_IDAGENCIAS
            '-----------------[CONDICION DE LA VENTA]--------------------
            '*****Recuperando el [TIPO ENTREGA]
            TipoEntrega_ = ObjVentaCargaContado.v_IDTIPO_ENTREGA
            b_no_lee_tipo_entrega = False

            'Recuperando el [TIPOPAGO]*********
            CboTipoEntrega.SelectedValue = ObjVentaCargaContado.v_IDTIPO_ENTREGA

            Dim TipoPago_ As Integer = ObjVentaCargaContado.v_IDTIPO_PAGO
            ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_Tipo_Pago, CboFormaPago, ObjVentaCargaContado.coll_Tipo_Pago, ObjVentaCargaContado.v_IDTIPO_PAGO)

            sDocCliente = ObjVentaCargaContado.v_NRO_DNI_RUC.Trim
            Dim Cliente As Integer = ObjVentaCargaContado.v_IDPERSONA
            '----------------------------------------------------------------------------------
            '**************DATOS CLIENTES******************************************************
            '***Buscando el cliente a editar               
            'If iOpcion = 1 Then
            If sDocCliente.Trim.Length > 0 Then
                Buscar(sDocCliente, 1, dtoUSUARIOS.m_idciudad, idUnidadAgencias)
            Else
                Buscar(Cliente, dtoUSUARIOS.m_idciudad, idUnidadAgencias)
            End If
            'End If
            '****************
            'Recuperando el [NRO DOCUMENTO CLIENTE, NRO DE RUC, NRO BOLETA]TxtNroDocCliente
            RemoveHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
            Me.TxtNroDocCliente.Text = ObjVentaCargaContado.v_NRO_DNI_RUC.Trim
            Me.TxtNroDocCliente.Tag = ObjVentaCargaContado.v_IDPERSONA '
            AddHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
            'Recuperando el [NOMBRE DEL CLIENTE]
            Me.TxtNomCliente.Text = ObjVentaCargaContado.v_NOMBRES_RASONSOCIAL
            'Recuperando la [DIRECCION DEL CLIENTE]
            IdDireccionOrigen = ObjVentaCargaContado.v_IDDIREECION_ORIGEN
            ' Me.CboDireccion.Items.Add(Trim(ObjVentaCargaContado.v_DIRECCION_REMITENTE))
            RemoveHandler CboDireccion.SelectedIndexChanged, AddressOf CboDireccion_SelectedIndexChanged
            Me.CboDireccion.SelectedValue = ObjVentaCargaContado.v_IDDIREECION_ORIGEN
            'IdDireccionOrigen = CboDireccion.SelectedValue
            AddHandler CboDireccion.SelectedIndexChanged, AddressOf CboDireccion_SelectedIndexChanged
            'Recuperando dato [ChkCargo]**************************
            If ObjVentaCargaContado.v_cargo = 1 Then
                Me.chkDocumentoCliente.Checked = True
                Me.rbtCargoSi.Checked = True
            Else
                Me.chkDocumentoCliente.Checked = False
                Me.rbtCargoSi.Checked = False
            End If
            'Recuperando el [TELEFONO DEL CLIENTE]
            Me.TxtTelfCliente.Text = ObjVentaCargaContado.v_TELEFONO_REMITENTE
            sEmail = ObjVentaCargaContado.v_Email.Trim
            '---------------------------------------------------------------------------------
            '**************DATOS CONTACTO*****************************************************                       
            'Recuperando el [NRO DOCUMENTO CONTACTO]
            Me.TxtNroDocContacto.Text = Trim(ObjVentaCargaContado.v_NRO_DOC_REMITENTE)
            Me.TxtNroDocContacto.Tag = ObjVentaCargaContado.v_IDPERSONA_ORIGEN '----NO RECUPERA
            'Recuperando el [NOMBRE DE CONTACTO]          
            RemoveHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
            Me.CboContacto.SelectedValue = ObjVentaCargaContado.v_IDPERSONA_ORIGEN
            idcontacto = CboContacto.SelectedValue
            AddHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
            If Me.TxtNroDocCliente.Text.Trim = Me.TxtNroDocContacto.Text.Trim And Me.TxtNroDocCliente.Text.Trim.Length > 0 Then
                bclienteCont = True
                ChkCliente1.Checked = True
            Else
                bclienteCont = False
                ChkCliente1.Checked = False
            End If

            '--------------------------------------------------------------------------------
            '**************DATOS CONSIGNADO**************************************************            
            GrdNConsignado.Rows.Clear()
            If ds.Tables(5).Rows.Count > 0 Then
                ChkCliente2.Checked = False
                For Each fila As DataRow In ds.Tables(5).Rows
                    Dim row0 As String() = {fila.Item("IDConsignado"), fila.Item("NroDocumento"), fila.Item("Nombres").ToString, _
                                            fila.Item("Telefono").ToString, _
                                            fila.Item("Nombre"), fila.Item("IDTipoDocDocumento"), _
                                            fila.Item("apepat"), fila.Item("apemat"), 0, fila.Item("IDVentaConsignado")
                                           }
                    GrdNConsignado.Rows().Add(row0)
                Next

                If ds.Tables(5).Rows.Count = 1 AndAlso Me.TxtNroDocCliente.Text.Trim = GrdNConsignado("Nº Documento", 0).Value.Trim And Me.TxtNroDocCliente.Text.Trim.Length > 0 Then
                    ChkCliente2.Checked = True
                    bclienteConsig = True
                Else
                    bclienteConsig = False
                End If
            Else
                GrdNConsignado.Rows.Add()
                GrdNConsignado("IDConsignado", 0).Value = ObjVentaCargaContado.v_IDCONTACTO_DESTINO
                GrdNConsignado("Nº Documento", 0).Value = Trim(ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO)
                GrdNConsignado("Nombres", 0).Value = Trim(ObjVentaCargaContado.v_NOMBRES_DESTINATARIO)
                GrdNConsignado("Telefono", 0).Value = ObjVentaCargaContado.v_TELEFONO_DESTINATARIO
                GrdNConsignado("nombre", 0).Value = ObjVentaCargaContado.v_NOMBRE_CONSIGNADO
                GrdNConsignado("tipo", 0).Value = ObjVentaCargaContado.v_TIPODOC_CONSIGNADO
                GrdNConsignado("apepat", 0).Value = ObjVentaCargaContado.v_APEPAT_CONSIGNADO
                GrdNConsignado("apemat", 0).Value = ObjVentaCargaContado.v_APEMAT_CONSIGNADO

                If Me.TxtNroDocCliente.Text.Trim = GrdNConsignado("Nº Documento", 0).Value.Trim And Me.TxtNroDocCliente.Text.Trim.Length > 0 Then
                    ChkCliente2.Checked = True
                    bclienteConsig = True
                Else
                    ChkCliente2.Checked = False
                    bclienteConsig = False
                End If
            End If


            '--
            Dim dr As DataRow
            dtConsignado = New DataTable
            dtConsignado.Columns.Add(New DataColumn("idcontacto_persona", GetType(Integer)))
            dtConsignado.Columns.Add(New DataColumn("nrodocumento", GetType(String)))
            dtConsignado.Columns.Add(New DataColumn("nombres", GetType(String)))
            dtConsignado.Columns.Add(New DataColumn("nombre", GetType(String)))
            'dtConsignado.Columns.Add(New DataColumn("idtipo_documento_contacto", GetType(Integer)))
            dtConsignado.Columns.Add(New DataColumn("tipo", GetType(Integer)))
            dtConsignado.Columns.Add(New DataColumn("apepat", GetType(String)))
            dtConsignado.Columns.Add(New DataColumn("apemat", GetType(String)))
            dtConsignado.Columns.Add(New DataColumn("telefono", GetType(String)))
            dr = dtConsignado.NewRow
            dr("idcontacto_persona") = ObjVentaCargaContado.v_IDCONTACTO_DESTINO
            dr("nombres") = ObjVentaCargaContado.v_NOMBRES_DESTINATARIO
            dr("nombre") = ObjVentaCargaContado.v_NOMBRE_CONSIGNADO
            'dr("idtipo_documento_contacto") = frm.CboTipoDocumento.SelectedValue
            dr("tipo") = ObjVentaCargaContado.v_TIPODOC_CONSIGNADO
            dr("nrodocumento") = Trim(ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO)
            dr("apepat") = ObjVentaCargaContado.v_APEPAT_CONSIGNADO
            dr("apemat") = ObjVentaCargaContado.v_APEMAT_CONSIGNADO
            dr("telefono") = ObjVentaCargaContado.v_TELEFONO_DESTINATARIO
            dtConsignado.Rows.Add(dr)
            '***************

            'Recuperando el [NRO DOCUMENTO CONSIGNADO,RUC, BOLETA]
            'Me.TxtNroDocConsignado.Text = Trim(ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO) 'Nconsignados
            'Recuperando el [NOMBRE DEL CONSIGNADO]
            ' Me.TxtNombConsignado.Text = Trim(ObjVentaCargaContado.v_NOMBRES_DESTINATARIO) 'Nconsignados
            'Recuperando el IDCONSIGNADO
            ObjVentaCargaContado.v_IDCONTACTO_DESTINO = ObjVentaCargaContado.v_IDCONTACTO_DESTINO
            iIDConsignado = ObjVentaCargaContado.v_IDCONTACTO_DESTINO
            bConsignadoNuevo = False
            'Recuperando La [DIRECCION DEL CONSIGNADO]
            If TipoEntrega_ = 1 Then
                CboTipoEntrega.SelectedValue = TipoEntrega.Agencia
                'Me.CboDireccion2.Text = "AGENCIA"
            Else
                CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio
                Me.CboDireccion2.SelectedValue = ObjVentaCargaContado.v_IDDIREECION_DESTINO
                Me.idDireConsignado = ObjVentaCargaContado.v_IDDIREECION_DESTINO
            End If
            'Recuperando el [EL TELEFONO DEL CONSIGNADO]
            ' Me.txtTelfConsignado.Text = ObjVentaCargaContado.v_TELEFONO_DESTINATARIO 'Nconsignados
            Me.TxtReferencia.Text = ObjVentaCargaContado.v_Referencia.Trim

            RemoveHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
            'Nconsignados
            'If Me.TxtNroDocCliente.Text.Trim = Me.TxtNroDocConsignado.Text.Trim And Me.TxtNroDocCliente.Text.Trim.Length > 0 Then
            '    ChkCliente2.Checked = True
            '    bclienteConsig = True
            'Else
            '    ChkCliente2.Checked = False
            '    bclienteConsig = False
            'End If
            AddHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
            '--------------------------------------------------------------------------------
            '**************DATOS DESCUENTO***************************************************
            'Recuperando el [DESCUENTO]
            Me.TxtDescuento.Text = IIf(ObjVentaCargaContado.v_PORCENT_DESCUENTO = 0, "", ObjVentaCargaContado.v_PORCENT_DESCUENTO)

            If Trim(TxtDescuento.Text.Length) > 0 Then
                txtDescDescto.Enabled = True
            Else
                txtDescDescto.Enabled = False
            End If
            'Recuperando la [DESCRIPCION DEL DESCUENTO]
            Me.txtDescDescto.Text = Trim(ObjVentaCargaContado.v_MEMO)

            '--------------------------------------------------------------------------------            
            '*****RECUPERANDO DATOS DEL GRID DETALLE DE VENTA********************************  
            If ObjVentaCargaContado.v_METROCUBICO = 0 Then
                TipoGrid_ = FormatoGrid.BULTO '--------------> Grid Volumetrico
                Me.DiseñaGrdDetalleVenta() '-------> Diseña GridDetalleVenta
                FormatoGrdDetalleVenta() '---------> Formato al grid   

                '**FILA PESO**
                GrdDetalleVenta("Bulto", 0).Value() = IIf(ObjVentaCargaContado.v_CANTIDAD_X_PESO = 0, "", ObjVentaCargaContado.v_CANTIDAD_X_PESO)
                GrdDetalleVenta("Peso/Volumen", 0).Value() = ObjVentaCargaContado.v_TOTAL_PESO
                'If Conversion.Val(GrdDetalleVenta(iCOL, iROW).Value) = 0 Then GrdDetalleVenta(iCOL, iROW).Value = "0.00" : Return
                'GrdDetalleVenta(iCOL, iROW).Value = FormatNumber(GrdDetalleVenta(iCOL, iROW).Value, 2)
                GrdDetalleVenta("Costo", 0).Value() = ObjVentaCargaContado.v_PRECIO_X_PESO
                tarifa_Peso = ObjVentaCargaContado.v_PRECIO_X_PESO

                If GrdDetalleVenta.Rows.Count > 1 Then
                    '**FILA VOLUMEN**
                    GrdDetalleVenta("Bulto", 1).Value() = IIf(ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN = 0, "", ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN)
                    GrdDetalleVenta("Peso/Volumen", 1).Value() = ObjVentaCargaContado.v_TOTAL_VOLUMEN
                    GrdDetalleVenta("Costo", 1).Value() = ObjVentaCargaContado.v_PRECIO_X_VOLUMEN
                End If
                tarifa_Volumen = ObjVentaCargaContado.v_PRECIO_X_VOLUMEN

                If ds.Tables(4).Rows.Count > 0 Then
                    objGuiaEnvio.CondicionTarifa_ = True
                    '--
                    objGuiaEnvio.UnidadPeso_ = ds.Tables(4).Rows.Item(0)("UNIDAD")
                    objGuiaEnvio.iPeso_Minimo = ds.Tables(4).Rows.Item(0)("INICIO")
                    objGuiaEnvio.iPeso_Maximo = ds.Tables(4).Rows.Item(0)("FIN")
                    '--
                    objGuiaEnvio.UnidadVol_ = ds.Tables(4).Rows.Item(1)("UNIDAD")
                    objGuiaEnvio.iVol_Minimo = ds.Tables(4).Rows.Item(1)("INICIO")
                    objGuiaEnvio.iVol_Maximo = ds.Tables(4).Rows.Item(1)("FIN")
                    '--
                    objGuiaEnvio.iPrecio_cond_Peso = ds.Tables(4).Rows.Item(0)("MONTO")
                    objGuiaEnvio.iPrecio_cond_Vol = ds.Tables(4).Rows.Item(1)("MONTO")

                    '****CALCULO PESO*****
                    If ObjVentaCargaContado.v_TOTAL_PESO >= objGuiaEnvio.iPeso_Minimo And ObjVentaCargaContado.v_TOTAL_PESO <= objGuiaEnvio.iPeso_Maximo Then
                        GrdDetalleVenta("Sub Neto", 0).Value = objGuiaEnvio.iPrecio_cond_Peso
                    ElseIf ObjVentaCargaContado.v_TOTAL_PESO > objGuiaEnvio.iPeso_Maximo Then
                        Dim Calculo As Double = (ObjVentaCargaContado.v_TOTAL_PESO - objGuiaEnvio.iPeso_Maximo) * (tarifa_Peso)
                        Dim SubNeto As Double = (Calculo + objGuiaEnvio.iPrecio_cond_Peso)
                        GrdDetalleVenta("Sub Neto", 0).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)
                    ElseIf ObjVentaCargaContado.v_TOTAL_PESO < objGuiaEnvio.iPeso_Minimo Then
                        GrdDetalleVenta("Sub Neto", 0).Value = "0.00"
                    End If

                    '****CALCULO VOLUMEN***
                    If ObjVentaCargaContado.v_TOTAL_VOLUMEN >= objGuiaEnvio.iVol_Minimo And ObjVentaCargaContado.v_TOTAL_VOLUMEN <= objGuiaEnvio.iVol_Maximo Then
                        GrdDetalleVenta("Sub Neto", 1).Value = objGuiaEnvio.iPrecio_cond_Vol
                    ElseIf ObjVentaCargaContado.v_TOTAL_VOLUMEN > objGuiaEnvio.iVol_Maximo Then
                        Dim Calculo2 As Double = (ObjVentaCargaContado.v_TOTAL_VOLUMEN - objGuiaEnvio.iVol_Maximo) * (tarifa_Volumen)
                        Dim SubNeto As Double = (Calculo2 + objGuiaEnvio.iPrecio_cond_Vol)
                        GrdDetalleVenta("Sub Neto", 1).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)
                    ElseIf ObjVentaCargaContado.v_TOTAL_VOLUMEN < objGuiaEnvio.iVol_Minimo Then
                        GrdDetalleVenta("Sub Neto", 1).Value = "0.00"
                    End If
                Else
                    objGuiaEnvio.CondicionTarifa_ = False
                    If CboProducto.SelectedValue = 81 Then
                        GrdDetalleVenta("Sub Neto", 0).Value() = ObjVentaCargaContado.v_CANTIDAD_X_PESO * ObjVentaCargaContado.v_PRECIO_X_PESO '* ObjVentaCargaContado.v_PORCENT_DESCUENTO / 100
                        'GrdDetalleVenta("Sub Neto", 1).Value() = ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN * ObjVentaCargaContado.v_PRECIO_X_VOLUMEN '* ObjVentaCargaContado.v_PORCENT_DESCUENTO / 100
                    ElseIf CboProducto.SelectedValue = 82 Then
                        GrdDetalleVenta("Sub Neto", 0).Value() = ObjVentaCargaContado.v_CANTIDAD_X_PESO * ObjVentaCargaContado.v_PRECIO_X_PESO '* ObjVentaCargaContado.v_PORCENT_DESCUENTO / 100
                        'GrdDetalleVenta("Sub Neto", 1).Value() = ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN * ObjVentaCargaContado.v_PRECIO_X_VOLUMEN '* ObjVentaCargaContado.v_PORCENT_DESCUENTO / 100
                    Else
                        GrdDetalleVenta("Sub Neto", 0).Value() = ObjVentaCargaContado.v_TOTAL_PESO * ObjVentaCargaContado.v_PRECIO_X_PESO '* ObjVentaCargaContado.v_PORCENT_DESCUENTO / 100
                        GrdDetalleVenta("Sub Neto", 1).Value() = ObjVentaCargaContado.v_TOTAL_VOLUMEN * ObjVentaCargaContado.v_PRECIO_X_VOLUMEN '* ObjVentaCargaContado.v_PORCENT_DESCUENTO / 100
                    End If
                End If

                'FILA SOBRE
                If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                    GrdDetalleVenta("Bulto", 2).Value() = IIf(ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = 0, "", ObjVentaCargaContado.v_CANTIDAD_X_SOBRE)
                    GrdDetalleVenta("Peso/Volumen", 2).Value() = "0.00"
                    GrdDetalleVenta("Costo", 2).Value() = ObjVentaCargaContado.v_PRECIO_X_SOBRE
                    'Nor_Sobres = ObjVentaCargaContado.v_PRECIO_X_SOBRE
                    tarifa_Sobre = ObjVentaCargaContado.v_PRECIO_X_SOBRE
                    GrdDetalleVenta("Sub Neto", 2).Value() = ObjVentaCargaContado.v_CANTIDAD_X_SOBRE * ObjVentaCargaContado.v_PRECIO_X_SOBRE
                    'FILA BASE
                    GrdDetalleVenta("Costo", 3).Value() = Format(ObjVentaCargaContado.v_MONTO_BASE, "###,###.00")
                    Monto_Base = ObjVentaCargaContado.v_MONTO_BASE
                    GrdDetalleVenta("Sub Neto", 3).Value() = Format(ObjVentaCargaContado.v_MONTO_BASE, "###,###.00")
                End If
                '***************************************** 
                'hlamas 20-11-2013
                If ObjVentaCargaContado.MontoEntregaDomicilio > 0 Then
                    GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, CboCiudadOrigen.SelectedValue, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)
                    'AgregarItemVenta("ENTREGA", False)
                    'Dim intFila As Integer = BuscarItemVenta("ENTREGA")
                    'Me.GrdDetalleVenta("Sub Neto", intFila).Value = ObjVentaCargaContado.MontoEntregaDomicilio
                End If
                'Me.FormatoMiles()
            End If

            If TxtNroDocCliente.Text.Trim.Length > 0 Then
                Dim iTarifario = ObjVentaCargaContado.TarifaGeneral(ObjVentaCargaContado.v_NRO_DNI_RUC.Trim, ObjVentaCargaContado.v_IDUNIDAD_ORIGEN, _
                                                    ObjVentaCargaContado.v_IDUNIDAD_DESTINO, 999)
                If iTarifario = 0 Then
                    bTarifarioGeneral = True
                    bContado = True
                Else
                    bTarifarioGeneral = False
                    bContado = False
                End If
            Else
                bTarifarioGeneral = True
                bContado = True
            End If

            'Recuperando el [SUB_TOTAL]**********
            TxtSubtotal.Text = Format(ObjVentaCargaContado.v_MONTO_SUB_TOTAL, "###,###,###.00")
            'Recuperando el [IGV(IMPUESTO)]**********
            TxtImpuesto.Text = Format(ObjVentaCargaContado.v_MONTO_IMPUESTO, "###,###,###.00")
            'Recuperando el [TOTAL]**********
            TxtTotal.Text = Format(ObjVentaCargaContado.v_TOTAL_COSTO, "###,###,###.00")

            If ObjVentaCargaContado.v_IDTIPO_PAGO = 2 Then
                CboTarjeta.Enabled = True
                TxtNroTarjeta.Enabled = True
                ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_T_TARJETAS, CboTarjeta, ObjVentaCargaContado.coll_T_TARJETAS, ObjVentaCargaContado.v_IDTARJETAS)
                'Recuperando el [NRO DE TARJETA]**********
                TxtNroTarjeta.Text = ObjVentaCargaContado.v_NROTARJETA
            Else
                CboTarjeta.Enabled = False
                TxtNroTarjeta.Enabled = False
                TxtNroTarjeta.Text = ""
                RemoveHandler CboTarjeta.SelectedIndexChanged, AddressOf CboTarjeta_SelectedIndexChanged
                CboTarjeta.SelectedIndex = -1
                AddHandler CboTarjeta.SelectedIndexChanged, AddressOf CboTarjeta_SelectedIndexChanged
            End If

            '--------------------------------------------------------------------------------
            '**RECUPERANDO DATOS (GRID ARTICULOS)********************************************          
            If ObjVentaCargaContado.v_CANTIDAD_X_ARTICULO > 0 Then
                TipoGrid_ = FormatoGrid.ARTICULOS : LbldetalleVenta.Text = "Articulos"
                Me.DiseñaGrdDetalleVenta()
                GrpDescuento.Enabled = False
                RemoveHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged
                ChkArticulos.Checked = True
                AddHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged

                lblMontoBase.Visible = True
                txtMontoBase.Visible = True
                chkSobres.Visible = True
                txtCantidadSobres.Visible = True
                txtTotalSobre.Visible = True
                Try
                    If ds.Tables(1).Rows.Count > 0 Then
                        fArticulo = True
                        For Each fila As DataRow In ds.Tables(1).Rows
                            Dim row0 As String() = {fila.Item(1), FormatNumber(fila.Item(2).ToString, 2), fila.Item(3).ToString, _
                                                    fila.Item(4).ToString, _
                                                    (fila.Item(2)) * (fila.Item(3)), fila.Item(0).ToString()
                                                   }
                            GrdDetalleVenta.Rows().Add(row0)
                        Next
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                RemoveHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged
                ChkArticulos.Checked = False
                lblMontoBase.Visible = False
                txtMontoBase.Visible = False
                chkSobres.Visible = False
                txtCantidadSobres.Visible = False
                txtTotalSobre.Visible = False
                AddHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged
            End If

            '--------------------------------------------------------------------------------
            '**RECUPERANDO DATOS M3 (VOLUMETRICO)********************************************
            If ObjVentaCargaContado.v_METROCUBICO = 1 Then
                TipoGrid_ = FormatoGrid.VOLUMETRICO '--------> Grid Volumetrico
                Me.DiseñaGrdDetalleVenta() '-----------------> Diseña GridDetalleVenta                             
                txtMontoBase.Text = ObjVentaCargaContado.v_MONTO_BASE
                RemoveHandler ChkM3.CheckedChanged, AddressOf ChkVolumetrico_CheckedChanged
                ChkM3.Checked = True
                AddHandler ChkM3.CheckedChanged, AddressOf ChkVolumetrico_CheckedChanged

                If ds.Tables(2).Rows.Count > 0 Then
                    fArticulo = True
                    For Each fila As DataRow In ds.Tables(2).Rows
                        Dim row0 As String() = {fila.Item("ITEM"), fila.Item("CANTIDAD"), FormatNumber(fila.Item("ALTURA"), 2), _
                                                FormatNumber(fila.Item("ANCHO"), 2), FormatNumber(fila.Item("LARGO"), 2), _
                                                FormatNumber(fila.Item("PESO_KG"), 2), FormatNumber(fila.Item("PRECIO_COSTO"), 2), _
                                                FormatNumber(fila.Item("PESO_KG"), 2) * FormatNumber(fila.Item("PRECIO_COSTO"), 2)
                                                }
                        GrdDetalleVenta.Rows().Add(row0)
                    Next
                End If

                If ObjVentaCargaContado.MontoEntregaDomicilio > 0 Then
                    GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, CboCiudadOrigen.SelectedValue, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)
                End If

                tarifa_Peso = ObjVentaCargaContado.v_PRECIO_X_PESO
                tarifa_Sobre = ObjVentaCargaContado.v_PRECIO_X_SOBRE
                '------------------------------
                'Recuperando el [SUB_TOTAL]
                TxtSubtotal.Text = Format(ObjVentaCargaContado.v_MONTO_SUB_TOTAL, "###,###,###.00")
                'Recuperando el [IGV(IMPUESTO)]
                TxtImpuesto.Text = Format(ObjVentaCargaContado.v_MONTO_IMPUESTO, "###,###,###.00")
                'Recuperando el [TOTAL]
                TxtTotal.Text = Format(ObjVentaCargaContado.v_TOTAL_COSTO, "###,###,###.00")

                chkSobres.Visible = True
                txtCantidadSobres.Visible = True
                txtTotalSobre.Visible = True
                lblMontoBase.Visible = True
                txtMontoBase.Visible = True
                GrpDescuento.Enabled = True
            Else
                RemoveHandler ChkM3.CheckedChanged, AddressOf ChkVolumetrico_CheckedChanged
                ChkM3.Checked = False
                AddHandler ChkM3.CheckedChanged, AddressOf ChkVolumetrico_CheckedChanged
            End If

            'hlamas 05-12-2013
            dblMontoEntregaDomicilio = Val(ds.Tables(0).Rows(0).Item("monto_entrega_domicilio"))
            If dblMontoEntregaDomicilio > 0 Then
                AgregarItemVenta("ENTREGA", GrdDetalleVenta)
                Dim intFila As Integer = BuscarItemVenta("ENTREGA", GrdDetalleVenta)
                If Not fArticulo Then
                    GrdDetalleVenta("sub neto", intFila).Value = dblMontoEntregaDomicilio
                Else
                    GrdDetalleVenta("T.Costo", intFila).Value = dblMontoEntregaDomicilio
                End If
            End If

            dblMontoDC = Val(ds.Tables(0).Rows(0).Item("monto_devolucion_cargo"))
            If dblMontoDC > 0 Then
                AgregarItemVenta("DEV CARGO", GrdDetalleVenta)
                Dim intFila As Integer = BuscarItemVenta("DEV CARGO", GrdDetalleVenta)
                GrdDetalleVenta("sub neto", intFila).Value = dblMontoDC
            End If

            dblMontoFueraZona = Val(ds.Tables(0).Rows(0).Item("monto_fuera_zona"))
            If dblMontoFueraZona > 0 Then
                AgregarItemVenta("FUERA ZONA", GrdDetalleVenta)
                Dim intFila As Integer = BuscarItemVenta("FUERA ZONA", GrdDetalleVenta)
                GrdDetalleVenta("sub neto", intFila).Value = dblMontoFueraZona
            End If

            '--------------------------------------------------------------------------------
            '**RECUPERANDO DATOS DOCUMENTOS DEL CLIENTE**************************************
            If ds.Tables(3).Rows.Count > 0 Then
                For i As Integer = 1 To GrdDocumentosCliente.Rows().Count - 1
                    GrdDocumentosCliente.Rows().RemoveAt(0)
                Next

                iFilas = 0
                For Each fila As DataRow In ds.Tables(3).Rows
                    If asignar_seleccionados(ds.Tables(3)) = True Then
                        Me.agregar_documentos_asegurados()
                    End If
                Next

                Try
                    iContador = 0
                    For Each fila As DataRow In ds.Tables(3).Rows
                        If IsDBNull(fila.Item("PORCEN")) Then
                            If iFilas < iContador Then
                                GrdDocumentosCliente.Rows.Add()
                            End If
                            If Not (fila.Item(1) Is Nothing) Then
                                iContador += 1
                            End If
                        End If
                    Next

                    iContador = 0
                    For Each fila As DataRow In ds.Tables(3).Rows
                        If IsDBNull(fila.Item("PORCEN")) Then
                            iContador += 1
                            Dim idDoc0 As String = fila.Item(0)
                            Dim NroDoc0 As String = fila.Item(1)
                            '
                            GrdDocumentosCliente.Rows(iContador - 1).Cells(0).Value = idDoc0
                            GrdDocumentosCliente.Rows(iContador - 1).Cells(2).Value = NroDoc0
                        End If
                    Next
                Catch
                End Try
            Else
                GrdDocumentosCliente.Rows.Clear()
                GrdDocumentosCliente.Rows.Add(3)
            End If
            If ObjVentaCargaContado.v_CANTIDAD_X_SOBRE > 0 And (ChkM3.Checked Or ChkArticulos.Checked) Then
                chkSobres.Checked = True
                RemoveHandler txtCantidadSobres.TextChanged, AddressOf txtCantidadSobres_TextChanged
                txtCantidadSobres.Text = ObjVentaCargaContado.v_CANTIDAD_X_SOBRE
                txtTotalSobre.Text = ObjVentaCargaContado.v_CANTIDAD_X_SOBRE * ObjVentaCargaContado.v_PRECIO_X_SOBRE
                AddHandler txtCantidadSobres.TextChanged, AddressOf txtCantidadSobres_TextChanged
            Else
                RemoveHandler chkSobres.CheckedChanged, AddressOf chkSobres_CheckedChanged
                chkSobres.Checked = False
                AddHandler chkSobres.CheckedChanged, AddressOf chkSobres_CheckedChanged

                RemoveHandler chkSobres.CheckedChanged, AddressOf chkSobres_CheckedChanged
                txtCantidadSobres.Enabled = False
                txtTotalSobre.Enabled = False
                AddHandler chkSobres.CheckedChanged, AddressOf chkSobres_CheckedChanged
            End If
            '--------------------------------------------------------------------------------
            '**RECUPERANDO DATOS DOCUMENTOS DEL CLIENTE**************************************
            If ObjVentaCargaContado.v_CANTIDAD_X_SOBRE > 0 And ObjVentaCargaContado.v_CANTIDAD_X_ARTICULO > 0 Then
                RemoveHandler chkSobres.CheckedChanged, AddressOf chkSobres_CheckedChanged
                RemoveHandler txtCantidadSobres.TextChanged, AddressOf txtCantidadSobres_TextChanged
                chkSobres.Checked = True
                txtCantidadSobres.Enabled = True
                txtTotalSobre.Enabled = True
                txtCantidadSobres.Text = ObjVentaCargaContado.v_CANTIDAD_X_SOBRE
                txtTotalSobre.Text = ObjVentaCargaContado.v_CANTIDAD_X_SOBRE * ObjVentaCargaContado.v_PRECIO_X_SOBRE
                AddHandler chkSobres.CheckedChanged, AddressOf chkSobres_CheckedChanged
                AddHandler txtCantidadSobres.TextChanged, AddressOf txtCantidadSobres_TextChanged
            End If

            txtMontoBase.Text = ObjVentaCargaContado.v_MONTO_BASE
            'GrdDetalleVenta.ReadOnly = True
            'fnEnableStadoControl(True)

            txtMontoBase.Text = ObjVentaCargaContado.v_MONTO_BASE
            'GrdDetalleVenta.ReadOnly = True
            'fnEnableStadoControl(True)
            TipoComprobante = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE

            If idControl = 2 Then
                If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 1 Then
                    TipoComprobante = 1
                    LblTipoComprobante.Text = "FACTURA"
                    CboContacto.Enabled = True
                    ChkCliente1.Enabled = True
                ElseIf ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 2 Then
                    TipoComprobante = 2
                    LblTipoComprobante.Text = "BOLETA"
                    CboContacto.Enabled = False
                    TxtNroDocContacto.Text = ""
                    ChkCliente1.Enabled = False
                ElseIf ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = FEManager.TITAN_ID_TIPCOM_NOTA_CREDITO Then
                    LblTipoComprobante.Text = "N.CREDITO"
                    CboContacto.Enabled = False
                    TxtNroDocContacto.Text = ""
                    ChkCliente1.Enabled = False
                ElseIf ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = FEManager.TITAN_ID_TIPCOM_NOTA_DEBITO Then
                    LblTipoComprobante.Text = "N.DEBITO"
                    CboContacto.Enabled = False
                    TxtNroDocContacto.Text = ""
                    ChkCliente1.Enabled = False
                End If
            End If

            If idControl = 1 Then
                CboFormaPago.Enabled = True
                ' TxtDirecCliente.Focus()
            End If


            '*******************************************************************
            If idControl = 2 Then
                If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3 Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Then
                    'TxtSerie.Visible = False
                    'TxtNroDoc.Visible = False
                Else
                    'TxtSerie.Visible = True
                    'TxtNroDoc.Visible = True
                End If
            Else
                If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 3 Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Then
                    If fnValidarRUC(TxtNroDocCliente.Text.ToString()) Then
                        LblTipoComprobante.Text = "FACTURA"
                        If es_carga_asegurada Then
                            LblPasajero.Visible = True
                        Else
                            LblPasajero.Visible = False
                        End If

                        bFAC_Bol = True
                        TipoComprobante = 1
                        'TxtDirecCliente.Focus()
                        Descubrir_contacto()
                    Else
                        LblTipoComprobante.Text = "BOLETA"
                        If es_carga_asegurada Then
                            LblPasajero.Visible = True
                        Else
                            LblPasajero.Visible = False
                        End If

                        bFAC_Bol = False
                        TipoComprobante = 2
                        ' TxtDirecCliente.Focus()
                    End If
                End If
            End If

            LblTipoComprobante.Update()
            Update()
            '
            b_no_lee_tipo_entrega = True
            ''hlamas 08-10-2010 carga acompañada
            Controla(True)
            'bCargaAcompañada2 = False
            RemoveHandler txtBoleto.TextChanged, AddressOf TxtBoleto_TextChanged
            RemoveHandler txtBoleto.LostFocus, AddressOf TxtBoleto_LostFocus
            Me.txtBoleto.Text = ObjVentaCargaContado.v_nroboleto
            '*********************************************************************
            If ObjVentaCargaContado.v_proceso = 6 And ObjVentaCargaContado.v_nroboleto.Trim.Length > 2 Then
                bCargaAcompañada = True
                Me.txtBoleto.Enabled = False
                Controla(False)
                Grpa.Visible = True
                txtBoleto.Visible = True
                TxtCiudadDestino.Enabled = False
                CboAgenciaDest.Enabled = False

                If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 AndAlso ObjVentaCargaContado.v_facturado = 0 Then
                    TxtNroDocCliente.Text = TxtNroDocCliente.Text.Trim
                    'TxtNroDocConsignado.Text = TxtNroDocConsignado.Text.Trim 'Nconsignados
                    TxtNomCliente.Text = TxtNomCliente.Text.Trim
                    'TxtNombConsignado.Text = TxtNombConsignado.Text.Trim 'Nconsignados
                    TxtNroDocContacto.Text = TxtNroDocContacto.Text.Trim
                    'TxtNombContacto.Text = TxtNombContacto.Text.Trim
                End If
            Else
                TxtCiudadDestino.Enabled = True
                CboAgenciaDest.Enabled = True
                If ObjVentaCargaContado.v_proceso = 7 Then
                    iProceso = 7
                    CboProducto.SelectedValue = 7
                End If

                bCargaAcompañada = False
                Me.txtBoleto.Enabled = True

                If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 85 Then
                    If ObjVentaCargaContado.v_proceso = 6 Then
                        Me.txtBoleto.Visible = True
                        Controla(False)
                    Else
                        Me.txtBoleto.Visible = False
                    End If
                End If
                Grpa.Visible = False
                txtBoleto.Visible = False
            End If

            If Not bNuevo And Me.DgvLista.Rows.Count > 0 Then
                Dim intTipo As Integer = Me.DgvLista.CurrentRow.Cells("idtipo_comprobante").Value
                If intTipo = 1 Or intTipo = 2 Or intTipo = 30 Then
                    btnEnviarSunat.Visible = Me.DgvLista.CurrentRow.Cells("n_emife").Value = 0
                End If
            End If

            AddHandler txtBoleto.LostFocus, AddressOf TxtBoleto_LostFocus
            AddHandler txtBoleto.TextChanged, AddressOf TxtBoleto_TextChanged
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return False
    End Function

    Sub Descubrir_contacto()
        'Me.GrpContacto.Visible = True
        Me.TxtNroDocContacto.Visible = True
        Me.TxtNroDocContacto.Text = ""
        Label22.Visible = True
        'lbFacturador.Visible = True
        ' TxtNombContacto.Visible = True
        'TxtNombContacto.Text = ""
    End Sub

    Private Function asignar_seleccionados(ByVal adt_tmp As DataTable) As Boolean
        asignar_seleccionados = False
        Dim indice As Integer = 0
        If adt_tmp.Rows.Count > 0 Then
            For Each fila As DataRow In adt_tmp.Rows
                If Not fila.Item("fecha") Is DBNull.Value Then
                    Try
                        objComprobanteAsegurada(indice).ID_GUIAS_ENVIO_DOC = fila.Item("ID_GUIAS_ENVIO_DOC")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDGUIAS_ENVIO = fila.Item("IDGUIAS_ENVIO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDTIPO_COMPROBANTE = fila.Item("IDTIPO_COMPROBANTE")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).NRO_SERIE = fila.Item("NRO_SERIE")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).NRO_DOCU = fila.Item("NRO_DOCU")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDUSUARIO_PERSONAL = fila.Item("IDUSUARIO_PERSONAL")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDUSUARIO_PERSONALMOD = fila.Item("IDUSUARIO_PERSONALMOD")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDROL_USUARIO = fila.Item("IDROL_USUARIO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDROL_USUARIOMOD = fila.Item("IDROL_USUARIOMOD")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IP = fila.Item("IP")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IPMOD = fila.Item("IPMOD")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).FECHA_REGISTRO = fila.Item("FECHA_REGISTRO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).FECHA_ACTUALIZACION = fila.Item("FECHA_ACTUALIZACION")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDESTADO_REGISTRO = fila.Item("IDESTADO_REGISTRO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).FECHA = fila.Item("FECHA")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).MONTO_TIPO_CAMBIO = fila.Item("MONTO_TIPO_CAMBIO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).MONTO_SUB_TOTAL = fila.Item("MONTO_SUB_TOTAL")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).MONTO_IMPUESTO = fila.Item("MONTO_IMPUESTO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).TOTAL_COSTO = fila.Item("TOTAL_COSTO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).OBS = fila.Item("OBS")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).IDTIPO_MONEDA = fila.Item("IDTIPO_MONEDA")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).PORCEN = fila.Item("PORCEN")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).TIPO = fila.Item("TIPO_MONTO")
                    Catch
                    End Try
                    Try
                        objComprobanteAsegurada(indice).PROCEDENCIA = fila.Item("IND_PROCEDENCIA")
                    Catch
                    End Try
                    asignar_seleccionados = True
                End If
                indice = indice + 1
            Next
        End If
    End Function

    Private Sub CboAgenciaDest_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAgenciaDest.SelectedIndexChanged
        If iOpcion = 2 Then
            'Dim IDagencia As Integer = Int(ObjVentaCargaContado.coll_AgenciasVenta(CboAgenciaDest.SelectedIndex.ToString))

            If Not IsReference(CboAgenciaDest.SelectedValue) Then
                Dim IDagencia As Integer = CboAgenciaDest.SelectedValue
                If ObjVentaCargaContado.v_IDAGENCIAS_DESTINO <> IDagencia Then
                    CboAgenciaDest.SelectedValue = ObjVentaCargaContado.v_IDAGENCIAS_DESTINO
                    'ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_VarAgencias, CboAgenciaDest, ObjVentaCargaContado.coll_AgenciasVenta, ObjVentaCargaContado.v_IDAGENCIAS_DESTINO)
                End If
            End If
        End If
    End Sub

    Private Sub TxtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFecha.ValueChanged
        If iOpcion = 2 Then
            If TxtFecha.Text <> ObjVentaCargaContado.v_FECHA_FACTURA Then
                TxtFecha.Text = ObjVentaCargaContado.v_FECHA_FACTURA
                Return
            End If
        ElseIf iOpcion <> 2 And bNuevo Then
            Me.TxtFecha.Format = 2
        End If
    End Sub

    Private Sub MenuTab_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuTab.SelectedIndexChanged
        If MenuTab.SelectedIndex = 0 Then
            iOpcion = 0
        End If
        GrdDocumentosCliente.ClearSelection()
        GrdDetalleVenta.ClearSelection()
    End Sub

    Dim IdTipoComprob As Integer
    Private Sub dgvlista_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvLista.RowEnter
        IdTipoComprob = DgvLista.Rows(e.RowIndex).Cells("Idtipo_Comprobante").Value
        Dim Estado As Integer = DgvLista.Rows(e.RowIndex).Cells("Idestado_Factura").Value
        Dim Facturado As Integer = Val(DgvLista.Rows(e.RowIndex).Cells("Facturado").Value)
        Dim intProducto As Integer = DgvLista.Rows(e.RowIndex).Cells("idProceso").Value

        Me.btnTicketResumen.Enabled = False
        If IdTipoComprob = 85 And Facturado <> 1 Then
            ' BtnPCE.Enabled = True
            BtnEditar.Enabled = False
            BtnConsultar.Enabled = False
            BtnImprimir.Enabled = False
            BtnTicket.Enabled = False
            BtnDevolucion.Enabled = False
            BtnAnular.Enabled = False
        ElseIf IdTipoComprob = 85 Then
            BtnEditar.Enabled = False
            BtnConsultar.Enabled = False
            BtnImprimir.Enabled = False
            BtnTicket.Enabled = False
            BtnDevolucion.Enabled = False
            BtnAnular.Enabled = False
        Else
            BtnImprimir.Enabled = True
            BtnTicket.Enabled = True
            BtnDevolucion.Enabled = True
            BtnEditar.Enabled = True
            BtnConsultar.Enabled = True
            BtnAnular.Enabled = True
            BtnExportar.Enabled = True
            Me.btnImprimirComprobante.Enabled = True
        End If

        If intProducto = 11 Or intProducto = 6 Then
            Me.btnTicketResumen.Enabled = True
        End If


        Dim iEstado As Integer = DgvLista.Rows(e.RowIndex).Cells("Idestado_Factura").Value
        If iEstado = 2 Or iEstado = 3 Or iEstado = 29 Then
            Me.BtnEditar.Enabled = False
            Me.BtnAnular.Enabled = False
            Me.BtnImprimir.Enabled = False
            Me.BtnTicket.Enabled = False
            Me.BtnExportar.Enabled = False
            Me.BtnDevolucion.Enabled = False

        End If
    End Sub

    Private Sub DgvLista_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DgvLista.RowsAdded
        Me.LblRegistros.Text = FormatNumber(Me.DgvLista.Rows.Count, 0)
    End Sub

    Private Sub DgvLista_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DgvLista.RowsRemoved
        Me.LblRegistros.Text = FormatNumber(Me.DgvLista.Rows.Count, 0)
    End Sub

    Private Sub DgvLista_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DgvLista.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            intPerfil = 1
            If Not Acceso.SiRol(G_Rol, Me, 1, 1) Then 'Oficina
                If Acceso.SiRol(G_Rol, Me, 1, 2) Then
                    intPerfil = 2
                    Dim intFuncionario As Integer
                    intFuncionario = Me.DgvLista.CurrentRow.Cells("funcionario").Value
                    If intFuncionario <> dtoUSUARIOS.IdLogin Then
                        Return
                    End If
                ElseIf Acceso.SiRol(G_Rol, Me, 1, 3) Then
                    intPerfil = 3
                    Dim intAgencia As Integer
                    intAgencia = Me.DgvLista.CurrentRow.Cells("idagencia_origen").Value
                    If intAgencia <> dtoUSUARIOS.iIDAGENCIAS Then
                        Return
                    Else
                        If Not (Me.DgvLista.CurrentRow.Cells("Idunidad_Origen").Value = 5100 Or Me.DgvLista.CurrentRow.Cells("Idunidad_Origen").Value = 5630) Then
                            Return
                        End If
                    End If
                Else
                    intPerfil = 4
                    Return
                End If
            End If
            If Me.DgvLista.Rows.Count > 0 Then
                Dim intEstado As Integer = Me.DgvLista.CurrentRow.Cells("idestado_envio").Value
                Dim blnOK As Boolean = intEstado <> 21 And intEstado <> 29 And intEstado <> 50
                If blnOK Then
                    Me.ContextContado.Show(sender, e.X, e.Y)
                End If
            End If
        End If
    End Sub

    Sub ActivarDesactivar(ByVal estado As Boolean)
        Me.BtnEditar.Enabled = estado
        Me.BtnConsultar.Enabled = estado
        Me.BtnImprimir.Enabled = estado
        Me.BtnTicket.Enabled = estado
        Me.BtnExportar.Enabled = estado
        Me.BtnAnular.Enabled = estado
        Me.BtnDevolucion.Enabled = estado
        Me.btnImprimirComprobante.Enabled = estado
        ' Me.BtnPCE.Enabled = estado
    End Sub

#End Region

    '******************
#Region "PAGE VENTA"
    '*********Productos (NORMAL, CARGA ACOMPAÑADA, PYME, MASIVA)*********
    Sub ListarProducto()
        Try
            Dim obj As New dtoVentaCargaContado
            Dim dt As DataTable = obj.ListarProceso(0)
            RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            Me.CboProducto.DataSource = dt
            Me.CboProducto.DisplayMember = "nombre_secundario"
            Me.CboProducto.ValueMember = "idprocesos"
            'Me.CboProducto.SelectedIndex = 0
            AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            Dim sender As Object
            Dim e As EventArgs
            CboProducto_SelectedIndexChanged(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*********Diseñando el grid GrdDetalleVenta**************************
    Sub DiseñaGrdDetalleVenta()
        Try
            Dim Camp1 As String = "", camp2 = "", camp3 = "", camp4 = "", camp5 = "", camp6 = "", camp7 = "", camp8 = ""
            If TipoGrid_ = FormatoGrid.BULTO Then
                Camp1 = "Tipo" : camp2 = "Bulto" : camp3 = "Peso/Volumen"
                camp4 = "Costo" : camp5 = "Sub Neto"
            ElseIf TipoGrid_ = FormatoGrid.ARTICULOS Then
                Camp1 = "Artículo" : camp2 = "Precio" : camp3 = "Cantidad"
                camp4 = "Peso" : camp5 = "T.Costo" : camp6 = "IDARTICULO"
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
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersVisible = True
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ScrollBars = ScrollBars.Both
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
                '.DefaultCellStyle.SelectionForeColor = Color.Black
                .RowHeadersWidth = 20

                Dim col1 As New DataGridViewTextBoxColumn
                With col1
                    .HeaderText = Camp1
                    .Name = Camp1
                    .DataPropertyName = Camp1
                    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    If TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                        .Width = 100
                    End If
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                    .ReadOnly = True
                    .Visible = True
                End With
                GrdDetalleVenta.Columns.Add(col1)


                Dim col2 As New DataGridViewTextBoxColumn
                With col2
                    .HeaderText = camp2
                    .Name = camp2
                    .DataPropertyName = camp2
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    If TipoGrid_ = FormatoGrid.BULTO Or TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                        .ReadOnly = False
                        .MaxInputLength = 5
                    ElseIf TipoGrid_ = FormatoGrid.ARTICULOS Then
                        .ReadOnly = True
                    End If
                End With
                GrdDetalleVenta.Columns.Add(col2)


                Dim col3 As New DataGridViewTextBoxColumn
                With col3
                    .HeaderText = camp3
                    .Name = camp3
                    .DataPropertyName = camp3

                    If TipoGrid_ = FormatoGrid.BULTO Then
                        If CboProducto.SelectedValue = 81 Or CboProducto.SelectedValue = 82 Then
                            .ReadOnly = True
                        Else
                            .MaxInputLength = 9
                            .ReadOnly = False
                        End If
                    ElseIf TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                        .DefaultCellStyle.Format = "0.00"
                        .MaxInputLength = 9
                        .ReadOnly = False
                    Else
                        .MaxInputLength = 5
                        .ReadOnly = False
                    End If
                    'If TipoGrid_ = FormatoGrid.BULTO Or TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                    '    .DefaultCellStyle.Format = "0.00"
                    '    .MaxInputLength = 9
                    'Else
                    '    .MaxInputLength = 5
                    'End If
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    '.ReadOnly = False
                End With
                GrdDetalleVenta.Columns.Add(col3)

                Dim col4 As New DataGridViewTextBoxColumn
                With col4
                    .HeaderText = camp4
                    .Name = camp4
                    .DataPropertyName = camp4
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    If TipoGrid_ = FormatoGrid.BULTO Then
                        .ReadOnly = True
                        .DefaultCellStyle.Format = "0.00"
                    ElseIf TipoGrid_ = FormatoGrid.VOLUMETRICO Then
                        .ReadOnly = False
                        .DefaultCellStyle.Format = "0.00"
                        .MaxInputLength = 9
                    ElseIf TipoGrid_ = FormatoGrid.ARTICULOS Then
                        .ReadOnly = False
                        .DefaultCellStyle.Format = "0.00"
                        .MaxInputLength = 5
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
                    If TipoGrid_ <> FormatoGrid.VOLUMETRICO Then
                        .ReadOnly = True
                        .MaxInputLength = 9
                    End If
                End With
                GrdDetalleVenta.Columns.Add(col5)

                If TipoGrid_ = FormatoGrid.ARTICULOS Then
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
            Throw New Exception(ex.Message)
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
                    'Dim row1 As String() = {"CAJA 10KG", "", "0.00", "0.00", "0.00"}
                    'GrdDetalleVenta.Rows().Add(row1)
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
                    'Dim row4 As String() = {"FUERA ZONAS", "", "0.00", "0.00", "0.00"}
                    'GrdDetalleVenta.Rows().Add(row4)
                End If

                GrdDocumentosCliente.Rows.Clear()
                Dim row11 As String() = {"", " ", " ", ""}
                GrdDocumentosCliente.Rows().Add(row11)
                GrdDocumentosCliente.Rows().Add(row11)
                GrdDocumentosCliente.Rows().Add(row11)
            Else
                Dim row0 As String() = {"1", "", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00"}
                GrdDetalleVenta.Rows().Add(row0)
            End If

            TxtSubtotal.Text = "0.00"
            TxtImpuesto.Text = "0.00"
            TxtTotal.Text = "0.00"
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

#Region "PAGE_VENTA"

#Region "PRODUCTO"

    Sub RefreshNroDocumento(ByVal Producto_ As Integer)
        If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, Producto_, 1, Me.CboAgenciaOrigen.SelectedValue) = True Then
            TxtSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
            TxtNroDoc.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
        End If
    End Sub

    Private Sub CboProducto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboProducto.SelectedIndexChanged
        Try
            If iOpcion = 2 Then
                If CboProducto.SelectedValue <> iProceso Then
                    CboProducto.SelectedValue = iProceso
                End If
                Return
            End If

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
            sNombresCli = "" : sApCli = "" : sAmCli = "" : sTelfCliente = "" : sCliente = ""
            dtDireccion2 = Nothing
            Me.LimpiarCliente()
            Me.LimpiarConsignado()

            If CboProducto.SelectedValue = 0 Then '--------------------------------> [NORMAL]
                Me.RefreshNroDocumento(0)
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
                Me.RefreshNroDocumento(0)
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

                'hlamas 21-03-2016
                If Me.chkDocumentoCliente.Checked Then
                    ControlaCargo(False)
                End If

                Me.DiseñaGrdDetalleVenta()
                Me.FormatoGrdDetalleVenta()
                '*********************************
            ElseIf CboProducto.SelectedValue = 7 Then '----------------------------> [PYME]
                objGuiaEnvio.TarifaMasiva_ = False
                Me.RefreshNroDocumento(7)
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
                Me.RefreshNroDocumento(8)
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
            ElseIf CboProducto.SelectedValue = 9 Then '----------------------------> TEPSA COURIER OFFICE
                Me.RefreshNroDocumento(9)
                objGuiaEnvio.TarifaBox_ = False
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
            ElseIf CboProducto.SelectedValue = 10 Then '----------------------------> TEPSA SOBRES
                Me.RefreshNroDocumento(10)
                objGuiaEnvio.TarifaBox_ = False
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
            ElseIf CboProducto.SelectedValue = 81 Or CboProducto.SelectedValue = 82 Then '----------------------------> MASIVA 
                Me.RefreshNroDocumento(0)
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
                '***********************************
            End If
            'hlamas 15-11-2013
            'Tarifa Entrega a Domicilio
            If CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX And CboProducto.SelectedValue <> ID_PRODUCTO_TEPSA_BOX_10 Then
                GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, CboCiudadOrigen.SelectedValue, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)
            End If

            AddHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
            AddHandler TxtBoleto.TextChanged, AddressOf TxtBoleto_TextChanged
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub LimpiarDatosGeneral()
        'hlamas 21-03-2016
        If blnLimpiarDatosGeneral Then
            Me.TxtCliente.Text = ""
        End If
        Me.TxtConsignado.Text = ""
        '***Comentado x NConsignado*****
        ' Me.TxtNombConsignado.Text = ""
        '*******************************
        Me.TxtBoleto.Text = ""
        Me.TxtCiudadDestino.Enabled = True
        Me.TxtCiudadDestino.ReadOnly = False

        'hlamas 26-08-2015
        strObservacionCargo = ""

        Me.LimpiarDatosCliente()
    End Sub

    Function ClienteLineaCredit() As Boolean
        If ObjVentaCargaContado.BuscarCliente(1, Me.TxtNroDocCliente.Text, IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad), idUnidadAgencias, Me.CboProducto.SelectedValue) = True Then
            Iid = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(0)
            Dim ldt_tmp As New DataTable
            ldt_tmp = sp_linea_credito()

            If ldt_tmp.Rows.Count > 0 Then
                If CType(ldt_tmp.Rows(0).Item("ES_ACTIVO"), Boolean) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End If
    End Function

#End Region 'OK

#Region "SELECCION ESTANDAR O 24 HORAS"
    Private Sub CboTipoTarifa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoTarifa.SelectedIndexChanged
        Try
            If iOpcion = 2 Then
                If CboTipoTarifa.SelectedIndex <> -1 Then
                    CboTipoTarifa.SelectedIndex = 1
                End If
                Return
            End If

            If ChkArticulos.Checked = True Then
                ChkArticulos.Checked = False
            End If

            If CboTipoTarifa.SelectedIndex = 1 Then
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
                GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, CboCiudadOrigen.SelectedValue, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)
            End If

            Me.fnTarifario()
            GrdDetalleVenta("Costo", 0).Value = Format(tarifa_Peso, "0.00")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region 'OK

#Region "CARGA ACOMPAÑADA ----> BOLETO"

    Dim cnn As OdbcConnection '-> Conexion Mysql
    Dim bEntra As Boolean = False
    Dim bBoleto As Boolean = False

    Dim sBoleto As String = ""
    Private Sub TxtBoleto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBoleto.LostFocus
        Try
            If iOpcion = 2 Then
                Return
            End If

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

            'hlamas 07-04-2014
            'coneccion a athenea (vyr)
            'cnn = New Odbc.OdbcConnection("DRIVER={MySQL ODBC 3.51 Driver};SERVER=192.168.200.241;DATABASE=Tepsa;UID=ventas;PWD=10913035110;OPTION=18475")

            Dim sDoc As String = Me.txtBoleto.Text.Trim
            Dim iPos As Integer = sDoc.IndexOf("-")
            Dim sIzquierda As String = sDoc.Substring(0, iPos).Trim.PadLeft(4, "0")
            Dim sDerecha As String = sDoc.Substring(iPos + 1).Trim.PadLeft(7, "0")
            sDoc = sIzquierda & "-" & sDerecha
            Me.txtBoleto.Text = sDoc

            Dim obj As New dto_CargaAcompañada
            Dim dt As DataTable = obj.ObtenerBoleto(sDoc)
            CargarBoleto(dt)

            'hlamas 07-04-2014 CA MYSQL
            'Dim sql As String
            'sql = "SELECT V.idVenta ID, V.NroBoleto NUMBOLETO, "
            'sql = sql & "LEFT(V.FechaPartida,10) FECHAPARTIDA, LEFT(V.HoraPartida, 8) HORAPARTIDA, "
            'sql = sql & "P.NroDocumento nrodocumento,P.NroDocumento nu_docu_suna, upper(P.ApellidoPaterno) ap, upper(P.ApellidoPaterno) apepat, "
            'sql = sql & "UPPER(P.ApellidoMaterno) am, UPPER(P.ApellidoMaterno) apemat, "
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

    Dim bInicioCargaAcompañada As Boolean = False
    Sub CargarBoleto(ByVal dt As DataTable)
        If dt.Rows.Count > 0 Then
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
                    'bTecla = False
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

                    If sDestino = "MARCONA" Then
                        sDestino = "SJMARCONA"
                    End If

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

                        If iDes <> ObjVentaCargaContado.v_IDUNIDAD_DESTINO Then
                            'Destino de guia no coincide con boleto
                            MessageBox.Show("El Destino del Boleto no coincide con la Guía.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            bCargaAcompañada = False
                            TxtBoleto.Text = ""
                            Return
                        End If
                    Else    'comprobante de pago                        
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
                        'TxtNroDocCliente.Tag = IIf(IsDBNull(dt.Rows(0).Item("tipo")), 9, ObtieneTipoDocumento(dt.Rows(0).Item("tipo")))
                        TxtNroDocCliente.Tag = dt.Rows(0).Item("tipo")
                    ElseIf dt.Rows(0).Item("nrodocumento").ToString.Trim.Length = 0 Then
                        TxtNroDocCliente.Text = dt.Rows(0).Item("nrodocumento")
                        'TxtNroDocCliente.Tag = IIf(IsDBNull(dt.Rows(0).Item("tipo")), 9, ObtieneTipoDocumento(dt.Rows(0).Item("tipo")))
                        TxtNroDocCliente.Tag = dt.Rows(0).Item("tipo")
                    End If
                    iID_TipoDocCli = TxtNroDocCliente.Tag

                    Dim sNombres As String = dt.Rows(0).Item("nombres").ToString.Trim & " " & dt.Rows(0).Item("apepat").ToString.Trim & " " & dt.Rows(0).Item("apemat").ToString.Trim
                    TxtNomCliente.Text = sNombres
                    TxtNomCliente.Tag = sNombres 'dt.Rows(0).Item("ap").ToString.Trim & "*" & dt.Rows(0).Item("am").ToString.Trim
                    TxtTelfCliente.Text = IIf(IsDBNull(dt.Rows(0).Item("telefono")), "", dt.Rows(0).Item("telefono"))

                    '**********Comentado x NConsignado***************************************************************************************
                    'TxtNroDocConsignado.Text = dt.Rows(0).Item("nrodocumento").ToString.Trim
                    ''TxtNroDocConsignado.Tag = IIf(IsDBNull(dt.Rows(0).Item("tipo")), 9, ObtieneTipoDocumento(dt.Rows(0).Item("tipo")))
                    'TxtNombConsignado.Text = sNombres
                    'txtTelfConsignado.Text = IIf(IsDBNull(dt.Rows(0).Item("telefono")), "", dt.Rows(0).Item("telefono"))

                    '****gnr**************                          
                    dtCliente = dt.Copy
                    dtConsignado = dt.Copy
                    'iTipoDoc = Me.ObtieneTipoDocumento(dtCliente.Rows(0).Item("tipo"))
                    '*********************
                    ' TxtTelfCliente.Text = IIf(IsDBNull(dt.Rows(0).Item("telefono")), "", dt.Rows(0).Item("telefono"))
                    If TxtNroDocCliente.Text.Trim.Length > 0 Then
                        bInicioCargaAcompañada = True 'rose                        
                        Me.Buscar(TxtNroDocCliente.Text, 1, IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad), idUnidadAgencias)
                        bInicioCargaAcompañada = False
                    End If
                    Me.ChkCliente2.Checked = True

                    iIDConsignado = 0
                    bConsignadoNuevo = True
                    bConsignadoModificado = False
                    sNombresCli = dt.Rows(0).Item("nombres").ToString.Trim
                    sApCli = dt.Rows(0).Item("ap").ToString.Trim
                    sAmCli = dt.Rows(0).Item("am").ToString.Trim
                    sTelfCliente = TxtTelfCliente.Text.Trim
                    sEmail = dt.Rows(0).Item("email").ToString.Trim

                    iID_TipoDocConsig = TxtNroDocCliente.Tag
                    sNombresConsig = dt.Rows(0).Item("nombres").ToString.Trim
                    sapellPatConsig = dt.Rows(0).Item("ap").ToString.Trim
                    sapellMatConsig = dt.Rows(0).Item("am").ToString.Trim
                    sTelefonoConsig = TxtTelfCliente.Text.Trim
                    '****Comentado x NConsignado************************
                    'If TxtNroDocConsignado.Text.Trim.Length = 0 Then
                    'iID_TipoDocConsig = 9
                    'iID_TipoDocCli = 9
                    'End If
                    bEntra = True
                    Me.GrdDetalleVenta.Focus()
                    Me.GrdDetalleVenta.Rows(0).Selected = True
                    Me.GrdDetalleVenta.CurrentCell = Me.GrdDetalleVenta.Rows(0).Cells(1)
                Else    'anulado
                    MessageBox.Show("El Boleto de Viaje está anulado", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    bBoleto = False
                    'Me.LblBoleto.Text = ""
                    'Me.LblBoleto.Visible = False
                    'Me.lblCarga.Text = "-->CARGA ASEGURADA"
                    'Me.lblCarga.Visible = False
                    Controla(True)
                    Me.TxtCiudadDestino.ReadOnly = False
                    Me.TxtBoleto.Focus()
                End If
                Me.BtnGrabar.Focus()
            Else
                Dim s As String = ""
                For i As Integer = 0 To dt2.Rows.Count - 1
                    s = s & dt2.Rows(i).Item(0) & " " & dt2.Rows(i).Item(1) & Chr(13)
                Next
                MessageBox.Show("El Boleto " & sBoleto & " está asociado a:" & Chr(13) & Chr(13) & s, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bBoleto = False
                'Me.LblBoleto.Text = ""
                'Me.LblBoleto.Visible = False
                'Me.lblCarga.Text = "-->CARGA ASEGURADA"
                'Me.lblCarga.Visible = False
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
        'flagPCEVALIDADOC = True
        fnVALIDARDOCUMENTOS()
        bIngresa = False
        'flagPCEVALIDADOC = False
    End Sub
#End Region 'OK

#Region "DESTINO" '--> OK

    Dim iOficinaDestino As Integer
    Dim CodCiudadDest_ As Integer

    Private Sub TxtCiudadDestino_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCiudadDestino.Enter
        Me.TxtCiudadDestino.SelectAll()
    End Sub
    Private Sub TxtCiudadDestino_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCiudadDestino.LostFocus
        Try
            Me.Cursor = Cursors.AppStarting
            idUnidadAgencias = iWinDestino.IndexOf(TxtCiudadDestino.Text)
            Dim ErrCiudad_ As String = "" : CodCiudadDest_ = -1
            If idUnidadAgencias >= 0 Then 'existe ciudad
                idUnidadAgencias = Int(coll_iDestino.Item(idUnidadAgencias.ToString))

                If idUnidadAgencias = iOficinaDestino Then
                    Me.Cursor = Cursors.Default
                    Return
                End If

                If bNuevo Then
                    RemoveItemsCargAseg() '--->Limpiando items [carga asegurada]
                    ChkM3.Checked = False
                    bCondicion = False
                    '***Reseteando valores del grid****
                    TipoGrid_ = FormatoGrid.BULTO
                    Me.DiseñaGrdDetalleVenta()
                    FormatoGrdDetalleVenta()
                End If

                '*******lista las agencias de la ciudad destino*****************
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

                If bNuevo Then
                    '***************************************************************               
                    Me.objGuiaEnvio.TarifaPyme_ = False
                    Me.objGuiaEnvio.TarifaBox_ = False

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
                End If

                '****Obteniendo el Tarifario******               
                fnTarifario()

                If Not bNuevo Then
                    Dim s As Object
                    Dim ee As New System.Windows.Forms.DataGridViewCellEventArgs(2, 0)
                    GrdDetalleVenta_CellEndEdit(s, ee)
                End If
                '*********************************
                'CboAgenciaDest.Focus()

                'hlamas 17-07-2014
                ClienteProducto(iID_Persona, 999, Me.CboCiudadOrigen.SelectedValue, idUnidadAgencias)

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
            'hlamas 15-11-2013
            'Tarifa Entrega a Domicilio
            GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, CboCiudadOrigen.SelectedValue, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)

            iOficinaDestino = idUnidadAgencias
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub RemoveItemsCargAseg()
        If es_carga_asegurada Then
            objComprobanteAsegurada = Nothing
            ReDim objComprobanteAsegurada(19)
            es_carga_asegurada = False
        End If
    End Sub

    Private Sub TxtCiudadDestino_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCiudadDestino.KeyPress
        If Not Me.ValidaTexto(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

#End Region 'OK

#Region "CONDICION DE LA VENTA"

    'SELECCION TIPO DE ENTREGA (AGENCIA, DOMICILIO)
    Dim bValidaEntrega As Boolean = False
    Private Sub CboTipoEntrega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoEntrega.SelectedIndexChanged
        Try
            'Dim iidTipo As Integer = ObjVentaCargaContado.coll_t_Tipo_Entrega(CboTipoEntrega.SelectedIndex.ToString)
            Dim iidTipo As Integer = CboTipoEntrega.SelectedValue
            If iOpcion = 2 Then
                If iidTipo <> TipoEntrega_ And TipoEntrega_ = 1 Then
                    CboTipoEntrega.SelectedValue = TipoEntrega.Agencia
                ElseIf iidTipo <> TipoEntrega_ And TipoEntrega_ = 2 Then
                    CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio
                End If
                Return
            End If

            Me.ConvertirTipoEntrega(CboTipoEntrega.SelectedValue)
            If CboProducto.SelectedValue = 6 Then Me.ResetCalculo()
            If CboProducto.SelectedValue = 6 And iidTipo = 1 Then '------> Tipo Entrega [Agencia] No Incluye Base
                GrdDetalleVenta(3, 3).Value = "0.00"
                GrdDetalleVenta(4, 3).Value = "0.00"
                Me.Monto_Base = 0.0
                Me.TxtReferencia.Text = ""
            ElseIf CboProducto.SelectedValue = 6 And iidTipo = 2 Then '--> Tipo Entrega [Agencia] Si Icluye Base
                GrdDetalleVenta(3, 3).Value = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base, "0.00")
                GrdDetalleVenta(4, 3).Value = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base, "0.00")
                Me.Monto_Base = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base, "0.00")
            End If

            'hlamas 15-11-2013
            'Tarifa Entrega a Domicilio
            GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, CboCiudadOrigen.SelectedValue, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)

            'hlamas 27-07-2015
            If CboProducto.SelectedValue = 81 Or CboProducto.SelectedValue = 82 Then
                fnTarifario()
                fnTotalPago()
                'CalculoArticulos()
            End If
            'hlamas 21-01-2016
            If Me.ChkArticulos.Checked Then
                CalculoArticulos()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'SELECCION FORMA DE PAGO (EFECTIVO, TARJETA, CORTESIA)
    Dim varIdCondicion As Integer = 0
    Private Sub CboFormaPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboFormaPago.SelectedIndexChanged
        Try
            varIdCondicion = Int(ObjVentaCargaContado.coll_Tipo_Pago.Item(CboFormaPago.SelectedIndex.ToString))
            If iOpcion = 2 Then
                If varIdCondicion <> ObjVentaCargaContado.v_IDTIPO_PAGO Then
                    ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_Tipo_Pago, CboFormaPago, ObjVentaCargaContado.coll_Tipo_Pago, ObjVentaCargaContado.v_IDTIPO_PAGO)
                End If
                Return
            End If

            RemoveHandler CboTarjeta.SelectedIndexChanged, AddressOf CboTarjeta_SelectedIndexChanged
            If CboFormaPago.SelectedIndex = 0 Then
                '"EFECTIVO"                  
                CboTarjeta.Enabled = False
                TxtNroTarjeta.Enabled = False
                '
                TxtDescuento.Enabled = True
                GrpDescuento.Enabled = True
                Grpa.Enabled = True
                CboTarjeta.SelectedIndex = -1
                TxtNroTarjeta.Text = ""
            ElseIf CboFormaPago.SelectedIndex = 1 Then
                '"TARJETA"                                              
                CboTarjeta.Enabled = True
                TxtNroTarjeta.Enabled = True
                TxtNroTarjeta.Text = ""
                '
                TxtDescuento.Enabled = True
                GrpDescuento.Enabled = True
                Grpa.Enabled = True
                CboTarjeta.SelectedIndex = 0
            Else
                '"CORTESIA"
                CboTarjeta.Enabled = False
                TxtNroTarjeta.Enabled = False
                '
                TxtDescuento.Enabled = False
                GrpDescuento.Enabled = False
                'Grpa.Enabled = False
                CboTarjeta.SelectedIndex = -1
                TxtNroTarjeta.Text = ""
            End If


            If CboTarjeta.Visible = True Then
                Me.CboTarjeta.Focus()
            Else
                Me.TxtNroDocCliente.Focus()
            End If

            AddHandler CboTarjeta.SelectedIndexChanged, AddressOf CboTarjeta_SelectedIndexChanged
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'SELECCION TARJETA (VISA, MASTER CARD)
    Private Sub CboTarjeta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTarjeta.SelectedIndexChanged
        Try
            Dim IdCondicion As Integer = Int(ObjVentaCargaContado.coll_T_TARJETAS.Item(CboTarjeta.SelectedIndex.ToString))
            If iOpcion = 2 Then
                If IdCondicion <> ObjVentaCargaContado.v_IDTARJETAS Then
                    If ObjVentaCargaContado.v_IDTIPO_PAGO = 1 Or ObjVentaCargaContado.v_IDTIPO_PAGO = 5 Then
                        RemoveHandler CboTarjeta.SelectedIndexChanged, AddressOf CboTarjeta_SelectedIndexChanged
                        CboTarjeta.SelectedIndex = -1
                        AddHandler CboTarjeta.SelectedIndexChanged, AddressOf CboTarjeta_SelectedIndexChanged
                        Return
                    End If
                    ModuUtil.LlenarComboIDs_dt(ObjVentaCargaContado.dt_cur_T_TARJETAS, CboTarjeta, ObjVentaCargaContado.coll_T_TARJETAS, ObjVentaCargaContado.v_IDTARJETAS)
                End If
                Return
            End If

            If TxtNroTarjeta.Visible = True Then
                Me.TxtNroTarjeta.Focus()
            Else
                Me.TxtNroDocCliente.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TxtNroTarjeta_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroTarjeta.KeyPress
        If Not Me.ValidaNumero(e.KeyChar) Then
            e.Handled = True
        End If

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True : TxtNroDocCliente.Focus()
        End If
    End Sub
#End Region 'OK

#Region "CLIENTE"

    Dim sDocCliente As String = ""
    'Dim bBoleto As Boolean = False   
    'Dim flagPCE As Boolean = False
    'Dim flagPCEVALIDADOC As Boolean = False
    Dim bIngresa As Boolean
    Dim iForma As Integer = 0
    Dim s_persona_remitente As String = ""
    Dim bCargaAcompañada As Boolean = False
    Dim CONTROL As Integer = 1

    Dim Valida_ As Boolean
    Private Sub TxtNroDocCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNroDocCliente.TextChanged
        Try
            'If idUnidadAgencias = -1 Then LblTipoComprobante.Text = "BOLETA"
            CONTROL = 2
            objGuiaEnvio.iIDPERSONA = 0
            'If fnBuscarCliente() = True Then
            '    TxtNroDocCliente.Focus()
            '    TxtNroDocCliente.SelectAll()
            'End If
            bCondicion = False
            objGuiaEnvio.iPeso_Maximo = 0
            objGuiaEnvio.iPrecio_cond_Peso = 0
            LblTipoComprobante.Text = "BOLETA"

            'If flagPCEVALIDADOC = False Then
            If fnVALIDARDOCUMENTOS() = False Then
                TarifaPublica_ = True
                bDescuento = False
                bTieneLineaCredito = False
                'If CboProducto.SelectedValue <> 6 Then
                'fnTarifario()
                'End If
            End If
            'End If
            If Me.ChkCliente2.Checked Then
                If bBoleto Then
                    RemoveHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
                    Me.ChkCliente2.Checked = False
                    AddHandler ChkCliente2.CheckedChanged, AddressOf ChkCliente2_CheckedChanged
                Else
                    Me.ChkCliente2.Checked = False
                End If
            End If
            sDocCliente = TxtNroDocCliente.Text.Trim
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function fnVALIDARDOCUMENTOS2() As Boolean
        Try
            If TxtNroDocCliente.Text.Length = 11 Then
                If fnValidarRUC(TxtNroDocCliente.Text.ToString) Then
                    Me.LblTipoComprobante.Text = "FACTURA"
                    bFAC_Bol = True
                    TipoComprobante = 1
                    If CboProducto.SelectedValue <> 6 Then '--->Diferente De Carga Acompañada (para mantener la tarifa de carga acompañada)                                    
                        If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, CboProducto.SelectedValue, 1, Me.CboAgenciaOrigen.SelectedValue) = True Then
                            '*********Quitar Error*************************************  
                            TxtSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                            TxtNroDoc.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                            ' GrpContacto.Enabled = True
                            Return True
                        ElseIf ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0, 1, Me.CboAgenciaOrigen.SelectedValue) = True Then
                            TxtSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                            TxtNroDoc.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                            'GrpContacto.Enabled = True
                            Return True
                        Else
                            'GrpContacto.Enabled = True
                            Return False
                        End If
                    Else
                        If CboProducto.SelectedValue <> 6 Then
                            If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, CboProducto.SelectedValue, 1, Me.CboAgenciaOrigen.SelectedValue) = True Then
                                TxtSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                                TxtNroDoc.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                                Return False
                            ElseIf ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0, 1, Me.CboAgenciaOrigen.SelectedValue) = True Then
                                TxtSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                                TxtNroDoc.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                                Return False
                            End If
                            Return False
                        End If
                    End If
                Else
                    LblTipoComprobante.Text = "BOLETA"
                    bFAC_Bol = False
                    TxtNroDocCliente.SelectAll()
                    TxtNroDocCliente.Focus()
                    TipoComprobante = 2
                    Return False
                End If
            ElseIf TxtNroDocCliente.Text.Length = 8 Or bIngresa Then
                LblTipoComprobante.Text = "BOLETA"
                TxtNroDocContacto.Text = ""
                'TxtNombContacto.Text = ""
                TipoComprobante = 2

                If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, CboProducto.SelectedValue, 1, Me.CboAgenciaOrigen.SelectedValue) = True Then
                    TxtSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                    TxtNroDoc.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                    ' GrpContacto.Enabled = False
                    Return True
                ElseIf ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0, 1, Me.CboAgenciaOrigen.SelectedValue) = True Then
                    TxtSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                    TxtNroDoc.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                    ' GrpContacto.Enabled = False
                    Return True
                Else
                    Return False
                End If
            Else
                TipoComprobante = 2
                LblTipoComprobante.Text = "BOLETA"
                'GrpContacto.Enabled = False
                If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0, 1, Me.CboAgenciaOrigen.SelectedValue) = True Then
                    TxtSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                    TxtNroDoc.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                    ' GrpContacto.Enabled = False
                End If
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    '***********FUNCIONES******************************************
    'TARIFA PUBLICA EN MEMORIA
    Sub ListaTarifaPublicaMemoria()
        If idUnidadAgencias <> -1 Then
            GrdDetalleVenta(3, 0).Value = Format(objGuiaEnvio.iTarifa_Publica_Monto_Peso, "0.00")
            GrdDetalleVenta(3, 1).Value = Format(objGuiaEnvio.iTarifa_Publica_Monto_Volumen, "0.00")
            GrdDetalleVenta(3, 2).Value = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base_Xpostal, "0.00")
            GrdDetalleVenta(3, 3).Value = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base, "0.00")
            GrdDetalleVenta(4, 3).Value = Format(objGuiaEnvio.iTarifa_Publica_Monto_Base, "0.00")
        End If
    End Sub
    'EXISTE EL CLIENTE 
    Private Function FnExisteCliente() As Boolean
        If ObjVentaCargaContado.BuscarCliente(1, Me.TxtNroDocCliente.Text, IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad), idUnidadAgencias, Me.CboProducto.SelectedValue) = True Then
            ObjVentaCargaContado.v_IDPERSONA = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(0)
            If ObjVentaCargaContado.v_IDPERSONA = 0 Then
                Return False
            Else
                Return True
            End If
        End If
    End Function 'Func 1
    'SI TIENE ARTICULOS,DESCUENTO, LINEA DE CREDITO
    Sub Consulta()
        Try
            'hlamas 21-01-2016
            ChkArticulos.Tag = Nothing
            'If ObjVentaCargaContado.BuscarCliente(1, Me.TxtNroDocCliente.Text, dtoUSUARIOS.m_idciudad.ToString, idUnidadAgencias) = True Then
            Me.DtArticulos = ObjVentaCargaContado.dt_cur_Articulos.Copy
            'If CboTipoTarifa.Text <> "24 HORAS" Then
            Iid = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(0)
            '****************************************************************************************
            If Iid > 0 Then
                RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                '**************************TIPO DE CLIENTE [Normal, PYME]****************************
                Dim iProceso As Integer = ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(7)
                If iProceso = 0 Then '------> Normal  Or (iProceso = 7 And ObjVentaCargaContado.dt_cur_persona.Rows(0).Item(8) <> TxtCliente.Text.Trim)
                    objGuiaEnvio.TarifaPyme_ = False
                    If CboProducto.SelectedValue = 6 Then
                        Me.CboProducto.SelectedValue = 6
                    ElseIf CboProducto.SelectedValue = 8 And bTieneLineaCredito = False Then
                        Me.CboProducto.SelectedValue = 8
                    Else
                        Me.CboProducto.SelectedValue = iProceso
                    End If
                ElseIf iProceso = 7 Then '--> Pyme  
                    Me.CboProducto.SelectedValue = iProceso
                    ' Me.TxtTelfConsignado.Focus()
                    Me.objGuiaEnvio.TarifaPyme_ = True '--> indica q traera tarifa Pyme                                      
                ElseIf iProceso = 8 Then '--> Masiva
                    objGuiaEnvio.TarifaPyme_ = False
                    Me.CboProducto.SelectedValue = iProceso
                    objGuiaEnvio.TarifaMasiva_ = True
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
            'Else
            'bTieneLineaCredito = False
            'bDescuento = False
            'End If
            'End If

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
    '**************************************************************
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

    Private Sub ObtieneMontosAsegurados(ByRef s As Double, ByRef i As Double, ByRef t As Double)
        s = 0
        i = 0
        t = 0
        For Each obj As ClsLbTepsa.dtoCargaAsegurada.ComprobanteAsegurada In objComprobanteAsegurada
            'If Not objComprobanteAsegurada(i).NRO_DOCU Is Nothing Then
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
    End Sub

    Private Function fnVALIDARDOCUMENTOS() As Boolean
        Try
            If TxtNroDocCliente.Text.Length = 11 Then
                If fnValidarRUC(TxtNroDocCliente.Text.ToString) Then

                    '*********Quitar Error*************************************                                    
                    Me.LblTipoComprobante.Text = "FACTURA"
                    bFAC_Bol = True
                    TipoComprobante = 1
                    If CboProducto.SelectedValue <> 6 Then '--->Diferente De Carga Acompañada (para mantener la tarifa de carga acompañada)               
                        fnTarifario()
                        If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, CboProducto.SelectedValue, 1, Me.CboAgenciaOrigen.SelectedValue) = True Then
                            '*********Quitar Error*************************************  
                            TxtSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                            TxtNroDoc.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                            'GrpContacto.Enabled = True
                            Return True
                        ElseIf ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0, 1, Me.CboAgenciaOrigen.SelectedValue) = True Then
                            TxtSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                            TxtNroDoc.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                            'GrpContacto.Enabled = True
                            Return True
                        Else
                            '*********Añadir Error*************************************  
                            ' GrpContacto.Enabled = True
                            Return False
                        End If
                    Else
                        'If CboProducto.SelectedValue <> 6 Then
                        If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, CboProducto.SelectedValue, 1, Me.CboAgenciaOrigen.SelectedValue) = True Then
                            '*********Quitar Error*************************************  
                            TxtSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                            TxtNroDoc.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                            Return False
                        ElseIf ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0, 1, Me.CboAgenciaOrigen.SelectedValue) = True Then
                            TxtSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                            TxtNroDoc.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                            Return False
                        End If
                        Return False
                        'End If
                    End If
                Else
                    '*********Añadir Error*************************************                  
                    Me.LimpiarDatosCliente()
                    '**********************************************************
                    LblTipoComprobante.Text = "BOLETA"
                    bFAC_Bol = False
                    TxtNroDocCliente.SelectAll()
                    TxtNroDocCliente.Focus()
                    TipoComprobante = 1
                    Return False
                End If
            ElseIf TxtNroDocCliente.Text.Length = 8 Or bIngresa Then
                If CboProducto.SelectedValue <> 6 Then
                    'If flagPCEVALIDADOC = False Then
                    fnTarifario()
                    'End If
                End If

                LblTipoComprobante.Text = "BOLETA"
                'TxtNroDocContacto.Text = ""

                bFAC_Bol = False
                TipoComprobante = 2
                If ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, CboProducto.SelectedValue, 1, Me.CboAgenciaOrigen.SelectedValue) = True Then
                    TxtSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                    TxtNroDoc.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                    'GrpContacto.Enabled = False
                    Return True
                ElseIf ObjVentaCargaContado.fnNroDocuemnto(TipoComprobante, 0, 1, Me.CboAgenciaOrigen.SelectedValue) = True Then
                    TxtSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                    TxtNroDoc.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                    'GrpContacto.Enabled = False
                    Return True
                Else
                    'Me.LimpiarDatosCliente()
                    Return False
                End If
            Else
                LblTipoComprobante.Text = "BOLETA"
                'GrpContacto.Enabled = False
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function 'func 3


    Public objGuiaEnvio As New dtoGuiaEnvio
    Dim bControl_Tarifas As Boolean = False
    Dim tarifa_Peso As Double = 0
    Dim tarifa_Volumen As Double = 0
    Dim tarifa_Articulo As Double = 0
    Dim tarifa_Sobre As Double = 0
    Dim Monto_Base As Double = 0
    Dim iTarifa As Integer = 0
    Dim bCargaAcompañada2 As Boolean = False
    Dim iControlMonto_Base As Double = 1
    Dim bTieneLineaCredito As Boolean = False
    Dim bDescuento As Boolean
    Dim iDescuento As Double = 0
    Dim Monto_25 As Double = 0
    Dim Monto_40 As Double = 0
    Public Function fnTarifario() As Boolean
        Dim flag As Boolean = False
        Try
            bTieneLineaCredito = False
            bControl_Tarifas = False
            tarifa_Peso = 0
            tarifa_Volumen = 0
            tarifa_Articulo = 0
            Monto_Base = 0

            If CboProducto.SelectedValue = 8 Then objGuiaEnvio.TarifaMasiva_ = True
            '********************Parametros*************************************************************
            objGuiaEnvio.iIDUNIDAD_AGENCIA = IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad)
            objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = idUnidadAgencias 'CodCiudadDest_
            objGuiaEnvio.TipoProducto_ = CboProducto.SelectedValue
            If IsNumeric(CboTipoTarifa.SelectedValue) Then
                objGuiaEnvio.TipoTarifa_ = CboTipoTarifa.SelectedValue
            Else
                objGuiaEnvio.TipoTarifa_ = 0
            End If
            'objGuiaEnvio.TipoTarifa_ = CboTipoTarifa.SelectedIndex
            objGuiaEnvio.sNU_DOCU_SUNAT = IIf(Me.TxtNroDocCliente.Text <> "", Me.TxtNroDocCliente.Text, "@")
            'hlamas 30-07-2015
            Dim intTipoEntrega As Integer = 0
            If Me.CboProducto.SelectedValue = 81 Or CboProducto.SelectedValue = 82 Then
                intTipoEntrega = Me.CboTipoEntrega.SelectedValue
            End If

            '*******************************************************************************************'
            'Listando la tarifa corporativa (ciudad origen, ciudad  destino, cliente)     no incluye igv
            '*******************************************************************************************'                       
            'If CboTipoTarifa.SelectedIndex = 0 AndAlso Me.TxtNroDocCliente.Text.Trim.Length > 0 AndAlso objGuiaEnvio.fnLISTA_TARIFA_CLIENTE() = True Then
            '    bTarifarioGeneral = False
            '    tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
            '    tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
            '    tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
            '    Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base
            '    tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Sobre
            '    iTarifa = objGuiaEnvio.iTarifa

            '    If CboProducto.SelectedValue = 81 Then
            '        GrdDetalleVenta("Costo", 0).Value = tarifa_Peso
            '        GrdDetalleVenta("Costo", 1).Value = tarifa_Volumen
            '    Else
            '        GrdDetalleVenta("Costo", 0).Value = tarifa_Peso
            '        GrdDetalleVenta("Costo", 1).Value = tarifa_Volumen
            '        GrdDetalleVenta("Costo", 2).Value = tarifa_Sobre
            '        If iControlMonto_Base = 1 Then
            '            GrdDetalleVenta("Costo", 3).Value = Monto_Base
            '            GrdDetalleVenta("Sub Neto", 3).Value = Monto_Base
            '        End If
            '    End If

            '    flag = True
            '    bControl_Tarifas = True

            '    '*******************************************************************************************'
            '    'Tarifa publica (ciudad origen, ciudad destino)                   incluye igv
            '    '*******************************************************************************************'
            'Else
            '--===>Consulta tarifario
            If (idUnidadAgencias > 0) Then
                Dim tarifasCargo As New dtoTarifasCargo
                'hlamas 21-01-2016
                tarifasCargo = ObjVentaCargaContado.ObtenerTarifaPublica(objGuiaEnvio.iIDUNIDAD_AGENCIA, _
                                                                         objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO, CboProducto.SelectedValue, _
                                                                         objGuiaEnvio.TipoTarifa_, intTipoEntrega)
                'tarifasCargo = ObjVentaCargaContado.obtenerTarifas(objGuiaEnvio.iIDUNIDAD_AGENCIA, _
                '                                                 idUnidadAgencias, CboProducto.SelectedValue, _
                '                                                 objGuiaEnvio.TipoTarifa_, intTipoEntrega)

                If IsNothing(tarifasCargo) = False Then
                    bContado = True
                    bTarifarioGeneral = True
                    '-->Pasa valores de la tarifa al objeto objGuiaEnvio.
                    objGuiaEnvio.iTarifa_Publica_Monto_Peso = tarifasCargo.precioPeso
                    objGuiaEnvio.iTarifa_Publica_Monto_Volumen = tarifasCargo.precioVolumen
                    tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
                    objGuiaEnvio.iTarifa_Publica_Monto_Base = tarifasCargo.precioBase
                    objGuiaEnvio.iTarifa_Publica_Monto_Base_Xpostal = tarifasCargo.precioSobre
                    objGuiaEnvio.iPeso_Maximo = tarifasCargo.pesoMinimo
                    objGuiaEnvio.iVol_Maximo = tarifasCargo.volumnenMinimo
                    objGuiaEnvio.iPrecio_cond_Peso = tarifasCargo.fleteMinimoPeso
                    objGuiaEnvio.iPrecio_cond_Vol = tarifasCargo.fleteMinimoVolumen
                    objGuiaEnvio.iMonto25 = tarifasCargo.importeArticulo_Caja5
                    objGuiaEnvio.iMonto40 = tarifasCargo.importeArticulo_Caja10

                    'hlamas 21-01-2016 temporal 
                    'Dim dt As DataTable = ObjVentaCargaContado.ObtenerTarifa(objGuiaEnvio.sNU_DOCU_SUNAT, dtoUSUARIOS.m_idciudad.ToString, idUnidadAgencias, _
                    '                                                       intTipoEntrega, CboProducto.SelectedValue, objGuiaEnvio.TipoTarifa_)
                    Dim dt As DataTable = ObjVentaCargaContado.ObtenerTarifa(iID_Persona, objGuiaEnvio.iIDUNIDAD_AGENCIA, objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO, _
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

                    '-->Pasa valores a las variables publicas las que se utilizarán para el respectivo calculo
                    tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
                    tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
                    tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
                    Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base
                    tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Base_Xpostal
                    Monto_25 = objGuiaEnvio.iMonto25
                    Monto_40 = objGuiaEnvio.iMonto40

                    '-->Asigna valores con la condicion de peso minimo y/o volumne minimo.
                    objGuiaEnvio.CondicionTarifa_ = False
                    If (tarifasCargo.pesoMinimo > 0) Then
                        objGuiaEnvio.UnidadPeso_ = "PESO"
                        objGuiaEnvio.iPeso_Minimo = 0.01
                        objGuiaEnvio.CondicionTarifa_ = True
                    End If
                    If (tarifasCargo.volumnenMinimo > 0) Then
                        objGuiaEnvio.UnidadVol_ = "VOL"
                        objGuiaEnvio.iVol_Minimo = 0.01
                        objGuiaEnvio.CondicionTarifa_ = True
                    End If

                    'verifica si esta afecto a monto base para carga acompañada
                    If CboProducto.SelectedValue = 6 Then
                        If CboTipoEntrega.SelectedValue = TipoEntrega.Agencia Then
                            Monto_Base = 0
                        End If
                        'bBoleto = "N"
                    End If

                    'If bTieneLineaCredito AndAlso CboProducto.SelectedValue = 0 Then
                    '    tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso_credito
                    '    tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen_credito
                    '    Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base_credito
                    '    tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Base_Xpostal_credito
                    '    bContado = False
                    '    TarifaPublica_ = False
                    'End If

                    isDescuento_ = False
                    If bBoleto = False Then
                        If bDescuento Then
                            tarifa_Peso = tarifa_Peso * (1 - iDescuento)
                            tarifa_Volumen = tarifa_Volumen * (1 - iDescuento)
                            'tarifa_Sobre = tarifa_Sobre * (1 - iDescuento)
                            isDescuento_ = True
                        End If
                    End If
                    'bBoleto = False

                    'If ChkM3.Checked = False Then
                    '    If CboProducto.SelectedValue = 81 Then
                    '        GrdDetalleVenta("Costo", 0).Value = tarifa_Peso
                    '        GrdDetalleVenta("Costo", 1).Value = tarifa_Volumen
                    '    Else
                    '        GrdDetalleVenta("Costo", 0).Value = tarifa_Peso
                    '        GrdDetalleVenta("Costo", 1).Value = tarifa_Volumen
                    '        GrdDetalleVenta("Costo", 2).Value = tarifa_Sobre

                    '        If iControlMonto_Base = 1 Then
                    '            GrdDetalleVenta("Costo", 3).Value = Monto_Base
                    '            GrdDetalleVenta("Sub Neto", 3).Value = Monto_Base
                    '        End If
                    '    End If
                    'End If
                    'If ChkM3.Checked = False Then
                    '    GrdDetalleVenta("Costo", 0).Value = tarifa_Peso
                    '    GrdDetalleVenta("Costo", 1).Value = tarifa_Volumen
                    '    GrdDetalleVenta("Costo", 2).Value = tarifa_Sobre

                    '    If iControlMonto_Base = 1 Then
                    '        GrdDetalleVenta("Costo", 3).Value = Monto_Base
                    '        GrdDetalleVenta("Sub Neto", 3).Value = Monto_Base
                    '    End If
                    'End If

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
                '-------------------------------
                '-->colova valores de la tarifa del grid
                For i As Integer = 0 To GrdDetalleVenta.Rows.Count - 1
                    If CboProducto.SelectedValue = 81 Then
                        'Select Case i
                        'Case 0
                        GrdDetalleVenta("Costo", 0).Value = Format(Monto_25, "0.00")
                        'Case 1
                        'GrdDetalleVenta("Costo", 1).Value = Format(Monto_40, "0.00")
                        'End Select
                    ElseIf CboProducto.SelectedValue = 82 Then
                        'Select Case i
                        'Case 0
                        GrdDetalleVenta("Costo", 0).Value = Format(Monto_40, "0.00")
                        'Case 1
                        'GrdDetalleVenta("Costo", 1).Value = Format(Monto_40, "0.00")
                        'End Select
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
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return flag
    End Function

    Dim coll_Direccion_Remitente As New Collection
    Dim coll_Direccion_Destinatario As New Collection
    Dim coll_Nombres_Remitente As New Collection
    Dim coll_Nombres_Destinatario As New Collection
    Public iWinContacto_Remitente As New AutoCompleteStringCollection
    Public iWinDireccion_Remitente As New AutoCompleteStringCollection
    Public iWinPerosaDNI_Remite As New AutoCompleteStringCollection
    Public iWinContacto_Destinatario As New AutoCompleteStringCollection
    Public iWinDireccion_Destinatario As New AutoCompleteStringCollection
    Public iWinPerosaDNI_Destino As New AutoCompleteStringCollection

    Dim b_lee As Boolean = True
    Dim Iid As String
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
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Sub LimpiarDatosCliente()
        '*******Items carga Asegurada**********
        Me.RemoveItemsCargAseg()
        '*******Datos Cliente******************
        Me.LimpiarCliente()
        '**************************************
        LblTipoComprobante.Text = "BOLETA"
        TipoComprobante = 2
        If CboProducto.SelectedValue <> 6 Then
            LblPasajero.Visible = False
        End If
        CboContacto.Enabled = False

        TxtDescuento.Text = ""
        GrpDescuento.Enabled = True
        RemoveHandler ChkArticulos.CheckedChanged, AddressOf ChkArticulos_CheckedChanged
        If ChkArticulos.Checked = True Then
            chkSobres.Visible = False
            txtCantidadSobres.Visible = False
            txtMontoBase.Visible = False
            txtTotalSobre.Visible = False
            lblMontoBase.Visible = False
            TipoGrid_ = FormatoGrid.BULTO
            Me.DiseñaGrdDetalleVenta()
            FormatoGrdDetalleVenta()
        Else
            Me.ResetCalculo()
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
        If CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
            RemoveHandler CboDireccion2.SelectedIndexChanged, AddressOf CboDireccion2_SelectedIndexChanged
            Me.CboDireccion2.DataSource = Nothing
            AddHandler CboDireccion2.SelectedIndexChanged, AddressOf CboDireccion2_SelectedIndexChanged
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
    End Sub

    '**************VALIDACION DEL TEXBOX (TEXTO, NUMERICO, ALFANUMERICO)***********************
    Private Sub TxtNroDocConsignado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not Me.ValidaNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNroDocCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroDocCliente.KeyPress
        If Not Me.ValidaNroTexto(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNomCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNomCliente.KeyPress
        If Not Me.ValidaTexto(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNombConsignado_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not Me.ValidaTexto(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCantidadSobres_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidadSobres.KeyPress
        If Not Me.ValidaNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

#End Region 'OK

#Region "CONSIGNADO"

    Private Sub BtnConsignado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsignado.Click
        Try
            If iOpcion = 2 Then
                Return
            End If

            Dim frm As New FrmConsignado
            frm.iFicha = 1
            Dim iFila As Integer = 0
            Dim sNumero As String = ""
            Dim sConsignado As String = ""
            Dim sNombresConsig As String = ""
            Dim sApePConsig As String = ""
            Dim sApeMConsig As String = ""
            Dim sTelfConsig As String = ""
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
            Dim bEsCliente As Boolean = False

            'If Me.TxtNroDocConsignado.Text.Trim.Length > 0 Or Me.TxtNombConsignado.Text.Trim.Length > 0 Then
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

                '19-10-2011
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


            frm.cargar(iTipo, sNumero, sCliente, sConsignado, sNombresConsig, bEsCliente, iDepartamento, iProvincia, iDistrito, iId_via, sVia, sNumero2, _
                       sManzana, sLote, iId_Nivel, sNivel, iId_Zona, sZona, iId_Clasificacion, sClasificacion, sApePConsig, sApeMConsig, sTelfConsig, sNombresCli,
                       sApCli, sAmCli, sTelfCliente, sReferencia, iIDConsignado)

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
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub ChkCliente2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCliente2.CheckedChanged
        Try
            If iOpcion = 2 Then
                ChkCliente2.Checked = bclienteConsig
                Return
            End If

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
                    dr("nombre") = sNombresCli 'new
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
                    sNombresConsig = sNombresCli
                    iID_TipoDocConsig = iID_TipoDocCli
                    sapellPatConsig = sApCli
                    sapellMatConsig = sAmCli
                    sTelefonoConsig = Me.TxtTelfCliente.Text.Trim
                    'Me.txtTelfConsignado.Text = Me.TxtTelfCliente.Text.Trim
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
                    'Me.txtTelfConsignado.Text = ""
                    '************************************
                Else
                    i = 0
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Sub BuscarConsignado()
        Try
            Me.Cursor = Cursors.AppStarting
            Dim iOpcion As Integer = IIf(Me.RbtDocumento3.Checked, 1, 2)
            Dim frm As New FrmConsignado
            Dim sConsignado As String = Me.TxtConsignado.Text.Trim
            Dim obj As New dtoVentaCargaContado
            Dim ds As DataSet = obj.BuscarConsignado(sConsignado, iOpcion, idUnidadAgencias)
            dtConsignado = ds.Tables(0)
            bConsignadoNuevo = True

            If ds.Tables(0).Rows.Count = 0 Then
                Me.Cursor = Cursors.Default
                MessageBox.Show("El Consignado no Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '***Comentado x NConsignado****
                'Me.LimpiarConsignado()

                '===Agregado x NConsignado=====
                If Me.ChkCliente2.Checked Then Me.ChkCliente2.Checked = False
                'bExiste = False
                '==============================

                frm = New FrmConsignado
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
                    If frm.bConsignadoNuevo Then
                        CargarConsignado(frm)
                    Else
                        ds = obj.BuscarConsignado(frm.TxtNumero.Tag)
                        dtConsignado = ds.Tables(0)
                        Me.MostrarConsignado(ds)
                    End If
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
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
            'Me.txtTelfConsignado.Text = ds.Tables(0).Rows(0).Item("telefono").ToString.Trim

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

    Sub LimpiarConsignado()
        '*****Comentado x NConsignado*******
        'Me.TxtNroDocConsignado.Text = ""
        'Me.TxtNombConsignado.Text = ""
        'Me.txtTelfConsignado.Text = ""

        '===Agregado x NConsignado==========
        GrdNConsignado.Rows.Clear()
        '===================================

        Me.ChkCliente2.Checked = False
        bConsignadoNuevo = True
    End Sub

    Private Sub TxtConsignado_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtConsignado.Enter, TxtCliente.Enter
        Me.TxtConsignado.SelectAll()
    End Sub

    Private Sub TxtConsignado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtConsignado.KeyPress
        If Me.RbtDocumento3.Checked Then
            If Not ValidarNumero(e.KeyChar) Then
                e.Handled = True
            End If
        Else
            If Not ValidarLetra(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Public bDirecConsigMod, bConsignadoModificado As Boolean
    Dim sNombresConsig As String = ""
    Dim sReferencia As String = ""
    Dim sapellPatConsig As String = ""
    Dim sapellMatConsig As String = ""
    Dim sTelefonoConsig As String = "" '-->datos consignado
    Dim iID_TipoDocConsig As Integer = 0
    'direccion
    Dim iDepartamentoConsig, iProvinciaConsig, iDistritoConsig, IDviaConsig, id_NivelConsig, id_ZonaConsig, id_ClasificacionConsig, FormatoConsig As Integer
    Dim ViaConsig, ManzanaConsig, loteConsig, NivelConsig, ZonaConsig, NroConsig, ClasificacionConsig As String
    Sub CargarConsignado(ByVal frm As FrmConsignado)
        Try
            If frm.bConsignadoNuevo Then
                '***Comentado x NConsignado****
                'TxtNroDocConsignado.Tag = 0

                '===Agregado x NConsignado=====
                iNroDocumentoTag = 0
                '==============================
            End If

            '***Comentado x NConsignado********
            'Me.TxtNroDocConsignado.Text = frm.TxtNumero.Text.Trim
            'Me.TxtNombConsignado.Text = frm.TxtConsignado.Text.Trim & " " & frm.txtapePConsig.Text & " " & frm.txtapeMConsig.Text
            'Me.txtTelfConsignado.Text = frm.txtTelefono.Text.Trim
            Me.TxtReferencia.Text = frm.TxtReferencia.Text.Trim
            '--
            iID_TipoDocConsig = frm.CboTipoDocumento.SelectedValue
            sNombresConsig = frm.TxtConsignado.Text.Trim
            sReferencia = frm.TxtReferencia.Text.Trim
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
                Dim ds As DataSet = obj.BuscarConsignado(frm.TxtNumero.Text, 1, IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad))
                'Comentado x NConsignado
                'If Me.TxtNroDocConsignado.Text.Trim.Length > 0 Then
                If frm.TxtNumero.Text.Trim.Length > 0 Then
                    ds = obj.BuscarConsignado(frm.TxtNumero.Text, 1, IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad))
                Else
                    ds = obj.BuscarConsignado(frm.TxtNumero.Tag)
                End If
                dtConsignado = ds.Tables(0)
                Me.MostrarConsignado(ds)
            ElseIf frm.TabConsignado.SelectedIndex = 1 Then
                Dim dr As DataRow
                'consignado
                dtConsignado = New DataTable

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
                'Me.ChkCliente2.Tag = Me.ChkCliente2.Checked
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
                'If iIDConsignado = 0 And (Not ExisteValorGrid(Me.GrdNConsignado, "Nº Documento", frm.TxtNumero.Text.Trim) Or frm.TxtNumero.Text.Trim.Length = 0) Then
                If iIDConsignado = 0 And iIndice = -1 Then '(iIndice = -1 Or frm.TxtNumero.Text.Trim.Length = 0) Then
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

                If frm.bDirecConsigMod AndAlso Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                    RemoveHandler CboDireccion2.SelectedIndexChanged, AddressOf CboDireccion2_SelectedIndexChanged
                    Me.CboDireccion2.DataSource = Nothing
                    AddHandler CboDireccion2.SelectedIndexChanged, AddressOf CboDireccion2_SelectedIndexChanged
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
                    dtDireccion2.Columns.Add(New DataColumn("de_referencia", GetType(String)))

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
                    dr("direccion") = Trim(sDireccion) 'Cambio 03102011
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
                    dr("de_referencia") = frm.TxtReferencia.Text.Trim
                    dtDireccion2.Rows.Add(dr)

                    Me.CboDireccion2.DataSource = dtDireccion2
                    CboDireccion2.DisplayMember = "direccion"
                    CboDireccion2.ValueMember = "iddireccion_consignado"
                    Me.CboDireccion2.SelectedIndex = 1
                End If

                '***Comentado x NConsignado******************************
                'If TxtNroDocCliente.Text.Trim.Length > 0 Then
                'Me.ChkCliente2.Checked = IIf(TxtNroDocCliente.Text = TxtNroDocConsignado.Text, 1, 0)
                'End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub ConvertirTipoEntrega(ByVal tipo As Integer)
        If tipo = TipoEntrega.Agencia Then
            Me.CboDireccion2.DataSource = Nothing
            Me.CboDireccion2.Items.Clear()
            Me.CboDireccion2.Items.Add("AGENCIA")
            Me.CboDireccion2.SelectedIndex = 0
            Me.TxtReferencia.Text = ""
        ElseIf tipo = TipoEntrega.Domicilio Then
            If dtDireccion2 IsNot Nothing Then
                Me.CboDireccion2.DataSource = dtDireccion2
                Me.CboDireccion2.ValueMember = "iddireccion_consignado"
                Me.CboDireccion2.DisplayMember = "direccion"

                If Me.CboDireccion2.Items.Count = 2 Then
                    Me.CboDireccion2.SelectedIndex = 1
                Else
                    Me.CboDireccion2.SelectedIndex = 0
                    Me.TxtReferencia.Text = ""
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
            Me.TxtReferencia.Text = ""
        End If
    End Sub


#End Region 'OK

#Region "CONTACTO"
    'Dim bTecla As Boolean = False

    'Private Sub TxtNroDocContacto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroDocContacto.KeyPress
    '    Try
    '        Dim tb As TextBox = CType(sender, TextBox)

    '        If tb.Name.ToUpper = "txtDocCliente_Remitente".ToUpper Then
    '            bTecla = True
    '        End If

    '        Dim chr As Char = e.KeyChar
    '        If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
    '            e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
    '        ElseIf Not Char.IsControl(e.KeyChar) Then
    '            e.Handled = True
    '        End If

    '        'If e.KeyChar = Convert.ToChar(Keys.Return) Then
    '        '    e.Handled = True : TxtNombContacto.Focus()
    '        'End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End Try
    'End Sub

    Dim idcontacto As Integer
    Private Sub CboContacto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboContacto.SelectedIndexChanged
        Try
            If iOpcion = 2 Then 'AndAlso Not IsReference(CboContacto)
                If Not IsReference(CboContacto.SelectedValue) Then
                    If CboContacto.SelectedValue <> ObjVentaCargaContado.v_IDPERSONA_ORIGEN Then
                        CboContacto.SelectedValue = ObjVentaCargaContado.v_IDPERSONA_ORIGEN
                    End If
                End If
                Return
            End If

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

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

#End Region 'OK

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
                    Me.fnCalcularCostoDescuento()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Try
        '    If Val(TxtDescuento.Text) > 0 Or Val(TxtDescuento.Text) < 0 Then
        '        txtDescDescto.Enabled = True
        '        txtDescDescto.ReadOnly = False
        '        txtDescDescto.Text = ""
        '        TxtDescuento.ReadOnly = False
        '        txtDescDescto.BackColor = Color.White
        '    Else
        '        txtDescDescto.BackColor = System.Drawing.SystemColors.Control
        '        txtDescDescto.Enabled = False
        '        txtDescDescto.ReadOnly = True
        '        txtDescDescto.Text = ""
        '    End If

        '    If bMontoMinimo = False Then
        '        '**Calculando Descuento**
        '        If ChkM3.Checked = True Then
        '            Me.DescuentoM3()
        '        Else
        '            Me.fnCalcularCostoDescuento()
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
            If Conversion.Val(GrdDetalleVenta("Costo", 0).Value) = 0 Then valor2 = 0 Else Costo = GrdDetalleVenta("Costo", 0).Value '-----------------> campo [Piezas]   Fila [Peso]

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
                GrdDetalleVenta("Sub Neto", 0).Value = IIf(valor1 * tarifa_Peso = 0, "0.00", FormatNumber(Format((valor1 * tarifa_Peso), "###,###,###.00"), 2))
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
                GrdDetalleVenta("Sub Neto", 1).Value = IIf(valor1 * tarifa_Volumen = 0, "0.00", FormatNumber(Format((valor1 * tarifa_Volumen), "###,###,###.00"), 2))
            End If

            '****************CALCULO [PESO/VOLUMEN] * [COSTO] Row=2*********************************
            If Conversion.Val(GrdDetalleVenta("Peso/Volumen", 2).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta("Peso/Volumen", 2).Value '--> campo [Peso/Vol] Fila [Sobre]
            If Conversion.Val(GrdDetalleVenta("Bulto", 2).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta("Bulto", 2).Value '----------------> campo [Piezas]   Fila [Sobre]

            GrdDetalleVenta("Sub Neto", 2).Value = IIf(valor2 * tarifa_Sobre = 0, "0.00", FormatNumber(Format((valor2 * tarifa_Sobre), "###,###,###.00"), 2))
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
            If Conversion.Val(GrdDetalleVenta("Sub Neto", 2).Value) = 0 Then Sobre = 0 Else Sobre = GrdDetalleVenta("Sub Neto", 2).Value

            Dim SubTotal As Double = 0
            Dim Monto As Double = 0
            If Vol + Peso > 0 Then
                If iControlMonto_Base = 1 Then
                    SubTotal = Monto_Base + Vol + Peso + Sobre
                Else
                    SubTotal = Vol + Peso + Sobre
                End If
            Else
                SubTotal = Vol + Peso + Sobre
            End If


            Dim IGV As Double = dtoUSUARIOS.iIGV / 100
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
                'hlamas 11-09-2015
                'SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SubTotal * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
                SUB_TOTAL_GENERAL = Format((1 + IGV) * SubTotal * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000")
                If Val(TxtDescuento.Text) > 0 Or Val(TxtDescuento.Text) < 0 Then
                    SUB_TOTAL_GENERAL = RedondearMas(SUB_TOTAL_GENERAL, 1)
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

            '*****************************APLICACION CALCULO*******************************************************************************************************
            TxtSubtotal.Text = IIf(SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
            TxtImpuesto.Text = IIf(IGV * SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
            TxtTotal.Text = IIf(SUB_TOTAL_GENERAL = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL, "###,###,###.00"), 2))
            '******************************************************************************************************************************************************
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region 'OK

#Region "DETALLE VENTA"

    '***DEFINIENDO TIPO DE CARACTER A LAS CELDAS**************
    Dim tipo_ As String
    Sub TipoCampos()
        Try
            If ChkArticulos.Checked = True Then '--------> ARTICULOS
                If iCOL = 2 Then tipo_ = "Int"
                If iCOL = 3 Then tipo_ = "Float"
            End If

            If ChkM3.Checked = True Then '---------------> M3 (VOLUMETRICO)
                If iCOL = 1 Then tipo_ = "Int"
                If iCOL >= 2 Then tipo_ = "Float"
            End If

            If ChkM3.Checked = False And ChkArticulos.Checked = False Then '-->BULTOS
                If iCOL = 1 Then tipo_ = "Int"
                If iCOL = 2 Then tipo_ = "Float"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '***FORMATO MILES PARA LAS CELDAS [EJEMPLO (12,400.25)]***  
    Sub FormatoMiles()
        If tipo_ = "Float" Then '-- tipo decimales
            If Conversion.Val(GrdDetalleVenta(iCOL, iROW).Value) = 0 Then GrdDetalleVenta(iCOL, iROW).Value = "0.00" : Return
            GrdDetalleVenta(iCOL, iROW).Value = FormatNumber(GrdDetalleVenta(iCOL, iROW).Value, 2)
        ElseIf tipo_ = "Int" Then '--> tipo Entero
            If Conversion.Val(GrdDetalleVenta(iCOL, iROW).Value) = 0 Then GrdDetalleVenta(iCOL, iROW).Value = "" : Return
            GrdDetalleVenta(iCOL, iROW).Value = FormatNumber(GrdDetalleVenta(iCOL, iROW).Value, 0)
        End If
    End Sub

    '***RESET VALORES DE LAS CELDAS***************************
    Sub ResetCalculo() '-> reseteando el calculo al cambiar el tipo de entrega 
        If ChkM3.Checked = False Then
            For i As Integer = 0 To GrdDetalleVenta.RowCount() - 2
                GrdDetalleVenta(1, i).Value = "" '-----> reset campo [Bulto]
                GrdDetalleVenta(2, i).Value = "0.00" '-> reset campo [Peso/Volumen]
                GrdDetalleVenta(4, i).Value = "0.00" '-> reset campo [Sub Neto]
            Next
        ElseIf ChkM3.Checked = True Then
            For i As Integer = 0 To GrdDetalleVenta.RowCount() - 1
                GrdDetalleVenta(1, i).Value = ""
                GrdDetalleVenta(2, i).Value = "0.00"
                GrdDetalleVenta(3, i).Value = "0.00"
                GrdDetalleVenta(4, i).Value = "0.00"
                GrdDetalleVenta(5, i).Value = "0.00"
                GrdDetalleVenta(7, i).Value = "0.00"
            Next
        End If

        TxtSubtotal.Text = "0.00"
        TxtImpuesto.Text = "0.00"
        TxtTotal.Text = "0.00"
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
    '***CONTROL DEL KEYDOWN AL GRID***************************
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


    '**************************************************************************************
    '******************CALCULOS[BULTO, ARTICULOS, M3(Volumetrico)]*************************
    Dim iCOL As Integer = 0, iROW As Integer = 0
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

            Me.TipoCampos()
            If TxtCiudadDestino.Text = "" Then idUnidadAgencias = -1

            '*********************************************************************
            If ChkM3.Checked = False And ChkArticulos.Checked = False Then
                If idUnidadAgencias <> -1 Then
                    fnTotalPago() '------------------------> Calculo[GRID BULTOS]  
                End If
                '---
                Me.FormatoMiles()
            End If

            '*********************************************************************
            If ChkArticulos.Enabled = True And ChkArticulos.Checked = True Then
                If idUnidadAgencias <> -1 Then
                    Me.CalculoArticulos() '----------------> Calculo[GRID ARTICULOS] 
                End If
                '---
                Me.FormatoMiles()
            End If

            '********************************************************************
            If ChkM3.Checked = True Then '-----------------> M3 (VOLUMETRICO)
                If idUnidadAgencias <> -1 Then
                    Me.Calculo_M3()
                End If
                '---
                Me.FormatoMiles()
            End If

            'hlamas 11-09-2015
            If Val(TxtDescuento.Text) > 0 Or Val(TxtDescuento.Text) < 0 Then
                TxtDescuento_TextChanged(Nothing, Nothing)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '***CALCULO DE VENTA PARA [CASO BULTOS]*******************
    Dim SubTotal_Costo As Double = 0
    Public Function fnTotalPago() As Boolean
        Dim flag As Boolean = False

        Try
            blnTotalManual = False
            If ChkM3.Checked = True Then
                Me.Calculo_M3()
                Return flag
            End If
            '**********Tomando los valores del campo [Peso/Volumen: Peso] y [Peso/Volumen: Volumen] y [Bulto: Sobre]********
            'Si se ingreso un descuento
            Dim PorcentajeDesc As Double = Val(TxtDescuento.Text.ToString) / 100
            Dim ValPeso_Peso As Double = 0, valPeso_Volum As Double = 0, ValNroSobres As Double = 0
            '*********************Formateando las Comas***********************************************
            If Conversion.Val(GrdDetalleVenta("Peso/Volumen", 0).Value) = 0 Then
                If CboProducto.SelectedValue = 81 Then
                    GrdDetalleVenta("Peso/Volumen", 0).Value = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 5
                    ValPeso_Peso = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 5
                ElseIf CboProducto.SelectedValue = 82 Then
                    GrdDetalleVenta("Peso/Volumen", 0).Value = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 10
                    ValPeso_Peso = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 10
                Else
                    ValPeso_Peso = 0
                End If
            Else
                If CboProducto.SelectedValue = 81 Then
                    GrdDetalleVenta("Peso/Volumen", 0).Value = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 5
                    ValPeso_Peso = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 5
                ElseIf CboProducto.SelectedValue = 82 Then
                    GrdDetalleVenta("Peso/Volumen", 0).Value = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 10
                    ValPeso_Peso = Conversion.Val(GrdDetalleVenta("Bulto", 0).Value) * 10
                Else
                    ValPeso_Peso = GrdDetalleVenta("Peso/Volumen", 0).Value
                End If
            End If
            'hlamas 11-09-2015
            ValPeso_Peso = RedondearMas(ValPeso_Peso)
            GrdDetalleVenta("Peso/Volumen", 0).Value = ValPeso_Peso

            If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                If Conversion.Val(GrdDetalleVenta("Peso/Volumen", 1).Value) = 0 Then
                    If CboProducto.SelectedValue = 81 Then
                        GrdDetalleVenta("Peso/Volumen", 1).Value = Conversion.Val(GrdDetalleVenta("Bulto", 1).Value) * 10
                        valPeso_Volum = Conversion.Val(GrdDetalleVenta("Bulto", 1).Value) * 10
                    Else
                        valPeso_Volum = 0
                    End If
                Else
                    If CboProducto.SelectedValue = 81 Then
                        GrdDetalleVenta("Peso/Volumen", 1).Value = Conversion.Val(GrdDetalleVenta("Bulto", 1).Value) * 10
                        valPeso_Volum = Conversion.Val(GrdDetalleVenta("Bulto", 1).Value) * 10
                    Else
                        valPeso_Volum = GrdDetalleVenta("Peso/Volumen", 1).Value
                    End If
                End If
            End If

            'hlamas 11-09-2015
            valPeso_Volum = RedondearMas(valPeso_Volum)

            If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                GrdDetalleVenta("Peso/Volumen", 1).Value = valPeso_Volum
            End If


            If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                If Conversion.Val(GrdDetalleVenta("Bulto", 2).Value) = 0 Then ValNroSobres = 0 Else ValNroSobres = GrdDetalleVenta("Bulto", 2).Value
            End If

            '*****************************************************************************************
            Dim IGV As Double = dtoUSUARIOS.iIGV / 100

            '*************************************************************************
            '***********CALCULO [SUB_NETO]= [PESO/VOLUMEN] * [COSTO]******************  

            'If objGuiaEnvio.CondicionTarifa_ And objGuiaEnvio.UnidadPeso_ = "PESO" Then '----> Si tiene CONDICION TARIFA(Calculo Peso)               
            '    Me.fnCalcularCondicionTarifa(0, ValPeso_Peso, GrdDetalleVenta("Costo", 0).Value) '-----------------> [Sub Neto (Peso)]
            'Else
            '    If CboProducto.SelectedValue = 81 And GrdDetalleVenta("Bulto", 0).Value.ToString <> "" Then
            '        GrdDetalleVenta("Sub Neto", 0).Value = IIf(GrdDetalleVenta("Bulto", 0).Value * tarifa_Peso = 0, "0.00", FormatNumber(Format((GrdDetalleVenta("Bulto", 0).Value * tarifa_Peso), "###,###,###.00"), 2)) '-------> [Sub Neto (Peso)] 
            '    Else
            '        GrdDetalleVenta("Sub Neto", 0).Value = IIf(ValPeso_Peso * tarifa_Peso = 0, "0.00", FormatNumber(Format((ValPeso_Peso * tarifa_Peso), "###,###,###.00"), 2)) '-------> [Sub Neto (Peso)] 
            '    End If
            'End If

            ''---
            'If objGuiaEnvio.CondicionTarifa_ And objGuiaEnvio.UnidadVol_ = "VOL" Then '----> Si tiene CONDICION TARIFA(Calculo volumen)   
            '    Me.fnCalcularCondicionTarifa(1, valPeso_Volum, GrdDetalleVenta("Costo", 1).Value) '-----------------> [Sub Neto (Volumen)]
            'Else
            '    If CboProducto.SelectedValue = 81 And GrdDetalleVenta("Bulto", 1).Value.ToString <> "" Then
            '        GrdDetalleVenta("Sub Neto", 1).Value = IIf(GrdDetalleVenta("Bulto", 1).Value * tarifa_Volumen = 0, "0.00", FormatNumber(Format((GrdDetalleVenta("Bulto", 1).Value * tarifa_Volumen), "###,###,###.00"), 2)) '-> [Sub Neto (Volumen)]
            '    Else
            '        GrdDetalleVenta("Sub Neto", 1).Value = IIf(valPeso_Volum * tarifa_Volumen = 0, "0.00", FormatNumber(Format((valPeso_Volum * tarifa_Volumen), "###,###,###.00"), 2)) '-> [Sub Neto (Volumen)]
            '    End If
            'End If

            Dim subNeto As Double = 0.0
            Dim colPeso As Integer = 0
            Dim colVol As Integer = 1
            Dim pesoMinimo As Double = objGuiaEnvio.iPeso_Maximo
            Dim fleteMinimo As Double = objGuiaEnvio.iPrecio_cond_Peso
            Dim subNetoPeso As Double = GrdDetalleVenta("Sub Neto", colPeso).Value
            Dim subNetoVolumen As Double ' = GrdDetalleVenta("Sub Neto", colVol).Value
            If CboProducto.SelectedValue = 81 Or CboProducto.SelectedValue = 82 Then
                If GrdDetalleVenta.Rows.Count > 1 Then
                    subNetoVolumen = GrdDetalleVenta("Sub Neto", colVol).Value
                End If
            End If

            If objGuiaEnvio.CondicionTarifa_ Then '-----------------> === CONDICION TARIFA  
                If (CboProducto.SelectedValue = 8) Then '-->Para el producto tepsa courrier
                    If (iROW = colPeso) Then
                        If (ValPeso_Peso <= pesoMinimo) Then
                            Me.fnCalcularCondicionTarifa(iROW, ValPeso_Peso, GrdDetalleVenta("Costo", colPeso).Value)

                            If (ValPeso_Peso = 0) Then '-->Aplica la refla del flete minomo al volumen
                                Me.fnCalcularCondicionTarifa(colVol, valPeso_Volum, GrdDetalleVenta("Costo", colVol).Value)
                            ElseIf (valPeso_Volum < pesoMinimo) Then '-->No aplica la regla fete mimimo al volumne
                                subNetoPeso = valPeso_Volum * tarifa_Volumen
                                GrdDetalleVenta("Sub Neto", colVol).Value = subNetoPeso
                            End If

                        ElseIf (ValPeso_Peso > pesoMinimo) Then
                            Me.fnCalcularCondicionTarifa(iROW, ValPeso_Peso, GrdDetalleVenta("Costo", colPeso).Value)

                            If (valPeso_Volum < pesoMinimo) Then
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
                    Me.fnCalcularCondicionTarifa(0, ValPeso_Peso, GrdDetalleVenta("Costo", 0).Value) '-----------------> [Sub Neto (Peso)]
                    Me.fnCalcularCondicionTarifa(1, valPeso_Volum, GrdDetalleVenta("Costo", 1).Value) '-----------------> [Sub Neto (Volumen)]
                End If

            Else
                If CboProducto.SelectedValue = 81 And Val(GrdDetalleVenta("Bulto", 0).Value) > 0 Then 'GrdDetalleVenta("Bulto", 0).Value <> "" Then
                    GrdDetalleVenta("Sub Neto", 0).Value = IIf(GrdDetalleVenta("Bulto", 0).Value * Monto_25 = 0, "0.00", FormatNumber(Format((GrdDetalleVenta("Bulto", 0).Value * Monto_25), "###,###,###.00"), 2)) '-------> [Sub Neto (Peso)] 
                ElseIf CboProducto.SelectedValue = 82 And Val(GrdDetalleVenta("Bulto", 0).Value) > 0 Then 'GrdDetalleVenta("Bulto", 0).Value <> "" Then
                    GrdDetalleVenta("Sub Neto", 0).Value = IIf(GrdDetalleVenta("Bulto", 0).Value * Monto_40 = 0, "0.00", FormatNumber(Format((GrdDetalleVenta("Bulto", 0).Value * Monto_40), "###,###,###.00"), 2)) '-------> [Sub Neto (Peso)] 
                Else
                    GrdDetalleVenta("Sub Neto", 0).Value = IIf(ValPeso_Peso * tarifa_Peso = 0, "0.00", FormatNumber(Format((ValPeso_Peso * tarifa_Peso), "###,###,###.00"), 2)) '-------> [Sub Neto (Peso)] 
                End If

                If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                    If CboProducto.SelectedValue = 81 And Val(GrdDetalleVenta("Bulto", 1).Value) > 0 Then 'GrdDetalleVenta("Bulto", 1).Value <> "" Then
                        GrdDetalleVenta("Sub Neto", 1).Value = IIf(GrdDetalleVenta("Bulto", 1).Value * Monto_40 = 0, "0.00", FormatNumber(Format((GrdDetalleVenta("Bulto", 1).Value * Monto_40), "###,###,###.00"), 2)) '-> [Sub Neto (Volumen)]
                    Else
                        GrdDetalleVenta("Sub Neto", 1).Value = IIf(valPeso_Volum * tarifa_Volumen = 0, "0.00", FormatNumber(Format((valPeso_Volum * tarifa_Volumen), "###,###,###.00"), 2)) '-> [Sub Neto (Volumen)]
                    End If
                End If
            End If

            '-->Recalcula el sub total
            Dim Monto As Double = 0.0
            SubTotal_Costo = 0.0
            For i As Integer = 0 To GrdDetalleVenta.Rows.Count() - 3
                If Conversion.Val(GrdDetalleVenta("Sub Neto", i).Value) = 0 Then Monto = 0 _
                                Else Monto = GrdDetalleVenta("Sub Neto", i).Value '--> Formateando en caso de Coma
                SubTotal_Costo += Monto
            Next

            If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                GrdDetalleVenta("Sub Neto", 2).Value = IIf(tarifa_Sobre * ValNroSobres = 0, "0.00", FormatNumber(Format((tarifa_Sobre * ValNroSobres), "###,###,###.00"), 2))  '----> [Sub Neto (Sobre)]  
            End If

            '*************************************************************************
            If Monto_Base > 0 Then
                ObjVentaCargaContado.v_MONTO_BASE = Monto_Base
            End If

            '**************************************************************************
            'SubTotal_Costo = 0
            If objGuiaEnvio.CondicionTarifa_ = False Then
                If CboProducto.SelectedValue = 81 Then
                    If Val(GrdDetalleVenta("Bulto", 0).Value) <> 0 Then
                        SubTotal_Costo = Monto_Base + ((GrdDetalleVenta("Bulto", 0).Value * Monto_25) / (1 + IGV))
                    End If
                    'If GrdDetalleVenta("Bulto", 1).Value <> "" Then
                    'SubTotal_Costo = SubTotal_Costo + ((GrdDetalleVenta("Bulto", 1).Value * Monto_40) / (1 + IGV))
                    'End If
                    SubTotal_Costo = SubTotal_Costo + (tarifa_Sobre * ValNroSobres)
                ElseIf CboProducto.SelectedValue = 82 Then
                    If Val(GrdDetalleVenta("Bulto", 0).Value) <> 0 Then
                        SubTotal_Costo = Monto_Base + ((GrdDetalleVenta("Bulto", 0).Value * Monto_40) / (1 + IGV))
                    End If
                    'If GrdDetalleVenta("Bulto", 1).Value <> "" Then
                    'SubTotal_Costo = SubTotal_Costo + ((GrdDetalleVenta("Bulto", 1).Value * Monto_40) / (1 + IGV))
                    'End If
                    SubTotal_Costo = SubTotal_Costo + (tarifa_Sobre * ValNroSobres)
                Else
                    If ValPeso_Peso * tarifa_Peso + valPeso_Volum * tarifa_Volumen > 0 Then
                        If iControlMonto_Base = 1 Then
                            SubTotal_Costo = (Monto_Base + ValPeso_Peso * tarifa_Peso + valPeso_Volum * tarifa_Volumen + tarifa_Sobre * ValNroSobres) '* (1 - PorcentajeDesc)               
                        Else
                            SubTotal_Costo = (ValPeso_Peso * tarifa_Peso + valPeso_Volum * tarifa_Volumen + tarifa_Sobre * ValNroSobres) '* (1 - PorcentajeDesc)
                        End If
                    Else
                        SubTotal_Costo = (ValPeso_Peso * tarifa_Peso + valPeso_Volum * tarifa_Volumen + tarifa_Sobre * ValNroSobres) '* (1 - PorcentajeDesc)
                    End If
                End If
            Else
                If CboProducto.SelectedValue = 81 Then
                    If Val(GrdDetalleVenta("Bulto", 0).Value) <> 0 Then
                        SubTotal_Costo = Monto_Base + ((GrdDetalleVenta("Bulto", 0).Value * Monto_25) / (1 + IGV))
                    End If
                    'If GrdDetalleVenta("Bulto", 1).Value <> "" Then
                    'SubTotal_Costo = SubTotal_Costo + ((GrdDetalleVenta("Bulto", 1).Value * Monto_40) / (1 + IGV))
                    'End If
                    SubTotal_Costo = SubTotal_Costo + (tarifa_Sobre * ValNroSobres)
                ElseIf CboProducto.SelectedValue = 82 Then
                    If Val(GrdDetalleVenta("Bulto", 0).Value) <> 0 Then
                        SubTotal_Costo = Monto_Base + ((GrdDetalleVenta("Bulto", 0).Value * Monto_40) / (1 + IGV))
                    End If
                    'If GrdDetalleVenta("Bulto", 1).Value <> "" Then
                    'SubTotal_Costo = SubTotal_Costo + ((GrdDetalleVenta("Bulto", 1).Value * Monto_40) / (1 + IGV))
                    'End If
                    SubTotal_Costo = SubTotal_Costo + (tarifa_Sobre * ValNroSobres)
                Else
                    SubTotal_Costo += tarifa_Sobre * ValNroSobres
                    If Monto_Base > 0 Then
                        SubTotal_Costo = (Monto_Base + SubTotal_Costo)
                    End If
            End If
            End If
            '**************************************************************************

            TxtSubtotal.Text = SubTotal_Costo
            TxtImpuesto.Text = IGV * SubTotal_Costo
            TxtTotal.Text = SubTotal_Costo + IGV * SubTotal_Costo
            Dim xSubtotal As Double = 0.0
            If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                If bTarifarioGeneral And bContado Then
                    xSubtotal = Format(SubTotal_Costo / (1 + IGV), "###,###,###.0000")
                    TxtSubtotal.Text = xSubtotal
                    TxtImpuesto.Text = IGV * SubTotal_Costo
                    TxtTotal.Text = SubTotal_Costo
                End If
            End If

            precio_carga_asegurada()
            If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                SubTotal_Costo = xSubtotal
                If es_carga_asegurada Then
                    SubTotal_Costo = TxtSubtotal.Text
                End If

                'SubTotal_Costo = TxtSubtotal.Text
            End If

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
            If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 And CboProducto.SelectedValue <> 7 Then
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
            'GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, CboCiudadOrigen.SelectedValue, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, 1)
            'dblMontoEntregaDomicilio = GestionaMontoTarifaDomicilio()
            'SUB_TOTAL_GENERAL = SUB_TOTAL_GENERAL + dblMontoEntregaDomicilio

            '***************************************************************************************************
            'If CboProducto.SelectedValue = 7 And SUB_TOTAL_GENERAL <= MontoMinimoPyme Then 'agregado 04022012
            '    Me.CondicionMontoMinimoPYME()
            'Else
            'End If

            TxtSubtotal.Text = IIf(SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
            TxtImpuesto.Text = IIf(IGV * SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
            TxtTotal.Text = IIf(SUB_TOTAL_GENERAL = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL, "###,###,###.00"), 2))
            blnTotalManual = True
            Return flag
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

            TxtSubtotal.Text = Replace(TxtSubtotal.Text, ",", "")
            TxtImpuesto.Text = Replace(TxtImpuesto.Text, ",", "")
            TxtTotal.Text = Replace(TxtTotal.Text, ",", "")
            TxtSubtotal.Text = Val(TxtSubtotal.Text) + cdblsub_total
            TxtImpuesto.Text = Val(TxtImpuesto.Text) + cdblmonto_IGV
            TxtTotal.Text = Val(TxtTotal.Text) + cdblcosto_total
        End If
    End Sub


    '***CALCULO DE VENTA PARA [CASO ARTICULOS]****************      

    Private Sub ChkArticulos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkArticulos.CheckedChanged
        Try

            If iOpcion = 2 Then
                If ObjVentaCargaContado.v_CANTIDAD_X_ARTICULO > 0 Then
                    ChkArticulos.Checked = True
                Else
                    ChkArticulos.Checked = False
                End If
                Return
            End If

            If ChkArticulos.Checked = False Then
                TipoGrid_ = FormatoGrid.BULTO : LbldetalleVenta.Text = "Detalle Venta" : Me.DiseñaGrdDetalleVenta()
                FormatoGrdDetalleVenta()
                Me.tarifarioEnMemoria()
                TxtSubtotal.Text = "0.00"
                TxtImpuesto.Text = "0.00"
                TxtTotal.Text = "0.00"

                chkSobres.Visible = False
                txtCantidadSobres.Visible = False
                txtTotalSobre.Visible = False
                lblMontoBase.Visible = False
                txtMontoBase.Visible = False
                GrpDescuento.Enabled = True
                Return
            End If


            If DtArticulos.Rows.Count > 0 Then
                If ChkM3.Checked = True Then ChkM3.Checked = False
                chkSobres.Checked = False
                TipoGrid_ = FormatoGrid.ARTICULOS : LbldetalleVenta.Text = "Articulos"
                Me.DiseñaGrdDetalleVenta()
                fArticulo = True
                '*********cargando lo datos de articulos**********

                For Each fila As DataRow In DtArticulos.Rows
                    Dim row0 As String() = {fila.Item(1), FormatNumber(fila.Item(2).ToString, 2), "", "0.00", "0.00", fila.Item(0).ToString()}
                    GrdDetalleVenta.Rows().Add(row0)
                Next

                TxtSubtotal.Text = "0.00"
                TxtImpuesto.Text = "0.00"
                TxtTotal.Text = "0.00"
                Update()

                txtMontoBase.Text = FormatNumber(IIf(Val(Monto_Base) = 0, 0, Monto_Base), 2)
                chkSobres.Visible = True
                txtCantidadSobres.Visible = True
                txtTotalSobre.Visible = True
                lblMontoBase.Visible = True
                txtMontoBase.Visible = True
                GrpDescuento.Enabled = False

                RemoveHandler TxtDescuento.TextChanged, AddressOf TxtDescuento_TextChanged
                TxtDescuento.Text = ""
                txtDescDescto.Enabled = False
                AddHandler TxtDescuento.TextChanged, AddressOf TxtDescuento_TextChanged
            End If
            Me.RemoveItemsCargAseg()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CalculoArticulos()
        Try
            'hlamas 21-01-2016
            If iCOL = 2 Or iCOL = 3 Then '2 = Columna cantidad
                Dim IGV As Double = dtoUSUARIOS.iIGV / 100
                Dim SubTotal_Costo As Double = 0

                objGuiaEnvio.iCANTIDAD_X_UNIDAD_ARTI = 0
                Dim Total As Double = 0
                Dim ii1 As Integer = 0

                Dim Precio_ As Double = 0, Cantidad_ As Double = 0
                If Conversion.Val(GrdDetalleVenta.Rows(iROW).Cells(1).Value) = 0 And Conversion.Val(GrdDetalleVenta.Rows(iROW).Cells(2).Value) = 0 Then
                    Precio_ = 0
                    Cantidad_ = 0
                Else
                    Precio_ = Conversion.Val(GrdDetalleVenta.Rows(iROW).Cells(1).Value)
                    Cantidad_ = Conversion.Val(GrdDetalleVenta.Rows(iROW).Cells(2).Value)
                End If

                'hlamas 21-01-2016
                Dim dblPeso As Double = 0
                GrdDetalleVenta.Rows(iROW).Cells(4).Value = IIf(Precio_ * Cantidad_ = 0, "0.00", Format(Precio_ * Cantidad_, "###,###,####.00"))
                For ii1 = 0 To GrdDetalleVenta.Rows().Count() - 1
                    'hlamas 21-01-2016
                    If GrdDetalleVenta.Rows(ii1).Cells(0).Value <> "ENTREGA" Then
                        dblPeso += Convert.ToDouble((GrdDetalleVenta.Rows(ii1).Cells(3).Value))
                        Total = Total + Convert.ToDouble((GrdDetalleVenta.Rows(ii1).Cells(4).Value))
                    End If
                Next

                Dim Monto_Sobre As Double = 0
                If chkSobres.Checked = True Then
                    Monto_Sobre = tarifa_Sobre * Conversion.Val(txtCantidadSobres.Text)
                    txtTotalSobre.Visible = True
                    txtTotalSobre.Text = Format(Monto_Sobre, "####,###,###.00")
                End If


                SubTotal_Costo = Monto_Base + Total + Monto_Sobre
                If Total = 0 Then
                    SubTotal_Costo = Monto_Sobre
                End If

                'hlamas 21-01-2016 entrega a domicilio
                dblMontoEntregaDomicilio = 0
                If Me.CboTipoEntrega.SelectedValue = 2 Then
                    AgregarItemVenta("ENTREGA", GrdDetalleVenta)
                Else
                    EliminarItemVenta("ENTREGA", GrdDetalleVenta)
                End If
                Dim intFila As Integer = BuscarItemVenta("ENTREGA", GrdDetalleVenta)
                If intFila > 0 Then
                    'obt
                    'Busca tarifa por generico
                    dblMontoEntregaDomicilio += ObtieneMontoTarifaServicio(100, dblPeso, dtTarifaServicio)
                    GrdDetalleVenta.Rows(intFila).Cells(4).Value = Format(dblMontoEntregaDomicilio, "0.00")
                    SubTotal_Costo = SubTotal_Costo + dblMontoEntregaDomicilio '/ (1 + IGV)
                End If
                '***************************************************************************************************


                Dim SUB_TOTAL_GENERAL As Double = 0
                If (1 - Val(Me.TxtDescuento.Text) / 100) > 0 Then
                    'hlamas 11-09-2015
                    'SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SubTotal_Costo * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
                    SUB_TOTAL_GENERAL = Format((1 + IGV) * SubTotal_Costo * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000")
                Else
                    If (1 - Val(Me.TxtDescuento.Text) / 100) = 0 Then
                        SUB_TOTAL_GENERAL = 0
                    End If
                End If

                '*****************Calculo Operacion*********************************************
                TxtSubtotal.Text = IIf(SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
                TxtImpuesto.Text = IIf(IGV * SUB_TOTAL_GENERAL / (1 + IGV) = 0, "0.00", FormatNumber(Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00"), 2))
                TxtTotal.Text = IIf(SUB_TOTAL_GENERAL = 0, "0.00", FormatNumber(Format(SUB_TOTAL_GENERAL, "###,###,###.00"), 2))
                '*******************************************************************************                          
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '***CALCULO DE SOBRES (CASO ARTICULOS)********************
    Private Sub chkSobres_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSobres.CheckedChanged

        Try
            If iOpcion = 2 Then
                If ObjVentaCargaContado.v_CANTIDAD_X_SOBRE > 0 Then
                    chkSobres.Checked = True
                Else
                    chkSobres.Checked = False
                End If
                Return
            End If

            If chkSobres.Checked = True Then
                txtCantidadSobres.Enabled = True
                txtCantidadSobres.Focus()
            Else
                txtCantidadSobres.Enabled = False
                txtCantidadSobres.Text = ""
                txtTotalSobre.Text = "0.00"
                If ChkM3.Checked = True Then
                    Me.Calculo_M3()
                Else
                    Me.CalculoArticulos()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCantidadSobres_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidadSobres.LostFocus
        If txtCantidadSobres.Text = "" Then
            chkSobres.Checked = False
            txtCantidadSobres.Enabled = False
        End If
    End Sub

    Private Sub txtCantidadSobres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidadSobres.TextChanged
        Try
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

                If Not Val Then
                    TxtSubtotal.Text = "0.00"
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

            'If recuperando_datos_contado = False Then
            If ChkM3.Checked = True Then
                Me.Calculo_M3() '---------> Sobre M3
            ElseIf (Val(Me.txtCantidadSobres.Text) / 100) > 0 Then
                Calculo_Sobre() '---------> Sobre Bulto
            Else
                iCOL = 2
                Me.CalculoArticulos() '--->Sobre Articulo
            End If
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

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
            If fArticulo = True Then
                Dim ii1 As Integer = 0
                For ii1 = 0 To GrdDetalleVenta.Rows().Count() - 1
                    Total_Articulo = Total_Articulo + Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii1).Cells("Sub Neto").Value.ToString)
                Next
                ' Total_Articulo = Total_Articulo '+ Monto_Base * Microsoft.VisualBasic.Conversion.Val(txtCantidadSobres.Text)
                If Total_Articulo > 0 Then
                    TxtSubtotal.Text = Format(Monto_Base + Monto_Sobre + Total_Articulo, "####,###,###.00")
                    TxtImpuesto.Text = Format((IGV) * (Monto_Base + Monto_Sobre + Total_Articulo), "####,###,###.00")
                    TxtTotal.Text = Format((1 + IGV) * (Monto_Base + Monto_Sobre + Total_Articulo), "####,###,###.00")
                Else
                    TxtSubtotal.Text = Format(Monto_Sobre, "####,###,###.00")
                    TxtImpuesto.Text = Format((IGV) * (Monto_Sobre), "####,###,###.00")
                    TxtTotal.Text = Format((1 + IGV) * (Monto_Sobre), "####,###,###.00")
                End If
            Else
                TxtSubtotal.Text = Format(Monto_Sobre, "####,###,###.00")
                TxtImpuesto.Text = Format((IGV) * (Monto_Sobre), "####,###,###.00")
                TxtTotal.Text = Format((1 + IGV) * (Monto_Sobre), "####,###,###.00")
            End If


            Dim SUB_TOTAL_GENERAL As Double = 0
            Dim SubTotal_Costo As Double = TxtSubtotal.Text
            If (1 - Val(Me.TxtDescuento.Text) / 100) > 0 Then
                'hlamas 11-09-2015
                'SUB_TOTAL_GENERAL = fnTECHO(Format((1 + IGV) * SubTotal_Costo * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000")) '01/09/2010 
                SUB_TOTAL_GENERAL = Format((1 + IGV) * SubTotal_Costo * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000") '01/09/2010 
            Else
                If (1 - Val(Me.TxtDescuento.Text) / 100) = 0 Then
                    SUB_TOTAL_GENERAL = 0
                End If
            End If

            TxtSubtotal.Text = Format(SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00")
            TxtImpuesto.Text = Format(IGV * SUB_TOTAL_GENERAL / (1 + IGV), "###,###,###.00")
            TxtTotal.Text = Format(SUB_TOTAL_GENERAL, "###,###,###.00")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            txtTotalSobre.Text = "0.00"
        End Try
        Return False
    End Function

    '***CALCULO M3[VOLUMETRICO]*******************************
    Private Sub ChkVolumetrico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkM3.CheckedChanged
        Try

            If iOpcion = 2 Then
                If ObjVentaCargaContado.v_METROCUBICO = 1 Then
                    ChkM3.Checked = True
                Else
                    ChkM3.Checked = False
                End If
                Return
            End If

            If ChkM3.Checked = True Then
                If ChkArticulos.Checked = True Then ChkArticulos.Checked = False
                RemoveItemsCargAseg() '------------>Limpiando items [carga asegurada]
                TipoGrid_ = FormatoGrid.VOLUMETRICO '--------> Grid Volumetrico
                Me.DiseñaGrdDetalleVenta() '-------> Diseña GridDetalleVenta
                FormatoGrdDetalleVenta() '---------> Formato al grid
                GrdDetalleVenta(6, 0).Value = Format(tarifa_Peso, "0.00")
                txtMontoBase.Text = FormatNumber(IIf(Val(tarifa_Sobre) = 0, 0, tarifa_Sobre), 2)

                chkSobres.Visible = True
                txtCantidadSobres.Visible = True
                txtTotalSobre.Visible = True
                lblMontoBase.Visible = True
                txtMontoBase.Visible = True
                GrpDescuento.Enabled = True

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
                TxtSubtotal.Text = "0.00"
                TxtImpuesto.Text = "0.00"
                TxtTotal.Text = "0.00"

                chkSobres.Visible = False
                txtCantidadSobres.Visible = False
                txtTotalSobre.Visible = False
                lblMontoBase.Visible = False
                txtMontoBase.Visible = False
                GrpDescuento.Enabled = True

                '--NuevaCondicion MontoMinimo 04022012
                If CboProducto.SelectedValue = 7 Then
                    Me.CondicionMontoMinimoPYME() '--NuevaCondicion MontoMinimo
                End If
                'Return
            End If
            'hlamas 28-11-2013
            GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, dtoUSUARIOS.m_idciudad, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Calculo_M3()
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
            'GrdDetalleVenta("Peso Kg", iROW).Value = IIf((Altura * Ancho * Largo) * Factor_ = 0, "0.00", _
            '                                          FormatNumber(Format((Altura * Ancho * Largo) * Factor_, "###,###,###.00"), 2))
            Dim dblPeso As Double = Altura * Ancho * Largo * Factor_
            GrdDetalleVenta("Peso Kg", iROW).Value = IIf((Altura * Ancho * Largo) * Factor_ = 0, "0.00", FormatNumber(Format(RedondearMas(dblPeso), "###,###,###.00"), 2))

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
            '**********************

            Dim Monto_Sobre As Double = 0
            If chkSobres.Checked = True Then
                Monto_Sobre = tarifa_Sobre * Conversion.Val(txtCantidadSobres.Text)
                txtTotalSobre.Visible = True
                txtTotalSobre.Text = Format(Monto_Sobre, "####,###,###.00")
            End If

            '****Añade [Sobres] al la sumaSubNeto*******************************************
            Dim MontoSobre_ As Double = 0
            If (Val(Me.txtCantidadSobres.Text) / 100) > 0 Then MontoSobre_ = _
                                                               (txtCantidadSobres.Text * tarifa_Sobre) ' + Monto_Base
            '*******************************************************************************
            'hlamas 11-09-2015
            'SumSubNeto_ = fnTECHO(Format(SumSubNeto_ + MontoSobre_, "0.000"))
            SumSubNeto_ = Format(SumSubNeto_ + MontoSobre_, "0.000")


            'hlamas 28-11-2013
            '********************************ENTREGA A DOMICILIO***********************************************
            dblMontoEntregaDomicilio = GestionaMontoTarifaDomicilio(dtTarifaServicio, GrdDetalleVenta, TipoGrid_)
            SumSubNeto_ = SumSubNeto_ + dblMontoEntregaDomicilio
            '*******************************************

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

            Dim Total_ As Double = SumSubNeto_
            Dim Subtotal_ As Double = Total_ / (1 + IGV)
            Dim Impuesto_ As Double = Subtotal_ * IGV
            '*******************************************

            If CboProducto.SelectedValue = 7 And Total_ <= MontoMinimoPyme Then '04022012
                Me.CondicionMontoMinimoPYME()
            Else
                TxtSubtotal.Text = IIf(Subtotal_ = 0, "0.00", FormatNumber(Format(Subtotal_, "###,###,###.00"), 2))
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
    End Sub

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
            If Val(Me.txtMontoBase.Text) > 0 Then
                SumSubNeto_ = (Format(SumSubNeto_ + Val(Me.txtMontoBase.Text), "0.00"))
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

                If bTarifarioGeneral Then
                    'hlamas 11-09-2015
                    'SUB_TOTAL_GENERAL = fnTECHO(Format(SumSubNeto_ * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000"))
                    SUB_TOTAL_GENERAL = Format(SumSubNeto_ * (1 - Val(Me.TxtDescuento.Text) / 100), "###,###,###.000")
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
                TxtSubtotal.Text = IIf(Subtotal_ = 0, "0.00", FormatNumber(Format(Subtotal_, "###,###,###.00"), 2))
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
        '    If CboProducto.SelectedValue = 7 And Total_ <= MontoMinimoPyme Then 'agregado 04022012
        '        Me.CondicionMontoMinimoPYME()
        '    Else
        '        TxtSubtotal.Text = IIf(Subtotal_ = 0, "0.00", FormatNumber(Format(Subtotal_, "###,###,###.00"), 2))
        '        TxtImpuesto.Text = IIf(Impuesto_ = 0, "0.00", FormatNumber(Format(Impuesto_, "###,###,###.00"), 2))
        '        TxtTotal.Text = IIf(Total_ = 0, "0.00", FormatNumber(Total_, 2))
        '    End If

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    '*************************************************************************
    '***CONDICION TARIFA(CALCULO)*********************************************

    Private Sub fnCalcularCondicionTarifa(ByVal row As Integer, ByVal Peso_Volumen As Double, ByVal Costo As Double)
        Try
            Dim ValorRango_ As Double = 0
            If (CboProducto.SelectedValue = 8) Then '-->Si es tepsa curriecourrier
                If row = 0 Or row = 1 Then
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
                If row = 0 Then
                    If Peso_Volumen >= objGuiaEnvio.iPeso_Minimo And Peso_Volumen <= objGuiaEnvio.iPeso_Maximo And Costo > 0 Then
                        GrdDetalleVenta("Sub Neto", row).Value = objGuiaEnvio.iPrecio_cond_Peso
                    ElseIf Peso_Volumen > objGuiaEnvio.iPeso_Maximo And Costo > 0 Then
                        Dim Calculo As Double = (Peso_Volumen - objGuiaEnvio.iPeso_Maximo) * (Costo)
                        Dim SubNeto As Double = (Calculo + objGuiaEnvio.iPrecio_cond_Peso)
                        GrdDetalleVenta("Sub Neto", row).Value = FormatNumber(Format(SubNeto, "###,###,###.00"), 2)
                    ElseIf Peso_Volumen < objGuiaEnvio.iPeso_Minimo Then
                        GrdDetalleVenta("Sub Neto", row).Value = "0.00"
                    End If
                ElseIf row = 1 Then
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


    '*************************************************************************
    '****************FORMATO SEPARADOS SIN MILES******************************
    Dim BCol_ As Integer, BRow_ As Integer
    Private Sub GrdDetalleVenta_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles GrdDetalleVenta.CellBeginEdit
        Try
            'hlamas 28-11-2013
            If TipoGrid_ = FormatoGrid.VOLUMETRICO AndAlso Not IsNumeric(GrdDetalleVenta("TIPO", e.RowIndex).Value) Then
                e.Cancel = True
            End If

            Dim Format_ As Double
            BCol_ = e.ColumnIndex
            BRow_ = e.RowIndex

            If ChkM3.Checked = False And ChkArticulos.Checked = False Then '----------> Bultos
                If BCol_ = 1 Or BCol_ = 2 Then
                    If Conversion.Val(GrdDetalleVenta(BCol_, BRow_).Value) = 0 Then
                        Return
                    Else
                        Format_ = GrdDetalleVenta(BCol_, BRow_).Value
                    End If
                    GrdDetalleVenta(BCol_, BRow_).Value = Format_

                    'hlamas 03-08-2015
                    If Me.CboProducto.SelectedValue = 0 Then
                        If BRow_ = 2 Then
                            If Conversion.Val(GrdDetalleVenta(BCol_, BRow_).Value) > 0 Then
                                GrdDetalleVenta(BCol_, BRow_).Value = 0
                                e.Cancel = True
                            End If
                        End If
                    End If
                End If
            End If


            If ChkArticulos.Checked = True Then '-----------> Articulos
                'hlamas 21-01-2016
                If Me.GrdDetalleVenta.Rows(BRow_).Cells(0).Value = "ENTREGA" Then
                    e.Cancel = True
                    If BCol_ = 2 Or BCol_ = 3 Then
                        If Conversion.Val(GrdDetalleVenta(BCol_, BRow_).Value) = 0 Then
                            Return
                        Else
                            Format_ = GrdDetalleVenta(BCol_, BRow_).Value
                        End If
                        GrdDetalleVenta(BCol_, BRow_).Value = Format_
                    End If
                End If
            End If

            If ChkM3.Checked = True Then '-----------> M3
                If BCol_ >= 1 And BCol_ <= 5 Then
                    If Conversion.Val(GrdDetalleVenta(BCol_, BRow_).Value) = 0 Then
                        Return
                    Else
                        Format_ = GrdDetalleVenta(BCol_, BRow_).Value
                    End If
                    GrdDetalleVenta(BCol_, BRow_).Value = Format_
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '****************EVENTOS PARA VALIDAR LAS CELDAS (SOLO TEXTO)*************
    Private WithEvents celda As DataGridViewTextBoxEditingControl
    Dim GrdDocumentos As Boolean
    Dim GrdDetVenta As Boolean
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
        celda = TryCast(e.Control, DataGridViewTextBoxEditingControl)
    End Sub

    Private Sub celda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles celda.KeyPress
        If GrdDocumentos Then
            e.Handled = Me.NumeroDocu(e, celda)
        ElseIf GrdDetVenta Then
            e.Handled = Me.Numero(e, celda)
        End If
    End Sub

    Public Function Numero(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByRef cajasTexto As TextBox) As Boolean
        If ChkM3.Checked = False And ChkArticulos.Checked = False Then '-------------------> BULTOS
            If BCol_ = 2 Then '----->Campo [Peso/Volumen]            
                If UCase(e.KeyChar) Like "[!0-9.]" Then
                    If Not Asc(e.KeyChar) = Keys.Back Then
                        Return True
                    End If
                End If

                Dim c As Short = 0
                If UCase(e.KeyChar) Like "[.]" Then
                    If InStr(cajasTexto.Text, ".") > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            ElseIf BCol_ = 1 Then '-->Campo [Bulto]
                If UCase(e.KeyChar) Like "[!0-9]" Then
                    If Not Asc(e.KeyChar) = Keys.Back Then
                        Return True
                    End If
                End If
            End If
        ElseIf ChkArticulos.Checked = True Then '---------------> ARTICULOS
            If BCol_ = 3 Then 'Campo [Peso]
                If UCase(e.KeyChar) Like "[!0-9.]" Then
                    If Not Asc(e.KeyChar) = Keys.Back Then
                        Return True
                    End If
                End If

                Dim c As Short = 0
                If UCase(e.KeyChar) Like "[.]" Then
                    If InStr(cajasTexto.Text, ".") > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            ElseIf BCol_ = 2 Then '-->Campo [Cantidad]
                If UCase(e.KeyChar) Like "[!0-9]" Then
                    If Not Asc(e.KeyChar) = Keys.Back Then
                        Return True
                    End If
                End If
            End If
        End If

        If ChkM3.Checked = True Then '----------------->M3
            If BCol_ >= 2 Then 'Campo [Peso]
                If UCase(e.KeyChar) Like "[!0-9.]" Then
                    If Not Asc(e.KeyChar) = Keys.Back Then
                        Return True
                    End If
                End If

                Dim c As Short = 0
                If UCase(e.KeyChar) Like "[.]" Then
                    If InStr(cajasTexto.Text, ".") > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            ElseIf BCol_ = 1 Then '-->Campo [Cantidad]
                If UCase(e.KeyChar) Like "[!0-9]" Then
                    If Not Asc(e.KeyChar) = Keys.Back Then
                        Return True
                    End If
                End If
            End If
        End If

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
#End Region 'OK

#Region "DOCUMENTOS DEL CLIENTE"
    Dim iDigitosSerie As Integer = 3
    Dim iDigitosDcoumento As Integer = 7
    Private Sub DataGridViewDocumentos_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDocumentosCliente.CellEndEdit
        Try
            Dim row As Short = e.RowIndex
            Dim col As Short = e.ColumnIndex
            Dim serie_NroDoc() As String = Split(GrdDocumentosCliente(col, row).Value.ToString, "-")
            Dim serie As String = ""
            Dim NroDoc As String = ""
            If serie_NroDoc(0).Length > 0 Then
                serie = RellenoRight(iDigitosSerie, Trim(serie_NroDoc(0)))
                'serie = Trim(serie_NroDoc(0))
            End If

            If serie_NroDoc.Length >= 2 Then
                If serie_NroDoc(1).Length > 0 Then
                    'NroDoc = Trim(serie_NroDoc(1))
                    NroDoc = RellenoRight(iDigitosDcoumento + 1, Trim(serie_NroDoc(1)))
                End If
            End If
            GrdDocumentosCliente(col, row).Value = IIf(serie & "-" & NroDoc = "000-", "", serie & "-" & NroDoc)
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region 'OK

    'Continuar
#Region "GRABAR"

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

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        Dim objLIQUI_TURNOS As New ClsLbTepsa.dtoLIQUI_TURNOS
        objLIQUI_TURNOS.IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
        objLIQUI_TURNOS.IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
        If objLIQUI_TURNOS.SP_LISTAR_LIQUI_TURNO().Count <= 0 Then
            MessageBox.Show("Aperture su Turno.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        objLIQUI_TURNOS = Nothing

        Try
            If Not Validar() Then
                Return
            End If
            '
            Me.Cursor = Cursors.AppStarting
            Me.Grabar()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function Validar() As Boolean
        Dim b As Boolean = True
        If Me.TxtBoleto.Visible Then 'flagPCE And 
            If Me.TxtBoleto.Text.Trim.Length < 2 Then
                b = False
            ElseIf Not bCargaAcompañada Then
                b = False
            End If
        End If

        If Not b Then
            MessageBox.Show("Asocie un Boleto de Viaje al Comprobante de Venta", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtBoleto.Focus()
            Me.Cursor = Cursors.Default
            Return False
        End If

        'hlamas 11-03-2019
        If Me.TxtFecha.Format = 8 Then
            MessageBox.Show("Ingrese la Fecha de Comprobante", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtFecha.Focus()
            Return False
        End If

        'hlamas 13-10-2015
        If Me.TxtFecha.Value > FechaServidor() Then
            MessageBox.Show("La Fecha de Comprobante debe ser menor o igual a la Fecha actual", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtFecha.Focus()
            Return False
        End If

        '----VALIDACION USUARIO REMOTO----
        If CboListaUsuarios.SelectedValue = 0 And bNuevo = True Then
            MessageBox.Show("Seleccione el usuario remoto", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CboListaUsuarios.Focus()
            CboListaUsuarios.SelectAll()
            Return False
        End If

        If CboAgenciaOrigen.SelectedValue = 0 And bNuevo = True Then
            MessageBox.Show("Seleccione la Agencia origen", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CboAgenciaOrigen.Focus()
            CboAgenciaOrigen.SelectAll()
            Return False
        End If

        '*******validacion del Nro Serie************
        'If Val(TxtSerie.Text.Trim) = 0 Then
        '    MessageBox.Show("Ingrese el Número de Serie", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Me.TxtSerie.Focus()
        '    Return False
        'ElseIf Val(Me.TxtSerie.Text.Trim) < 100 Then
        '    MessageBox.Show("Ingrese un Nº de Serie mayor o igual a 100", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Me.TxtSerie.Focus()
        '    Return False
        'ElseIf Val(TxtNroDoc.Text.Trim) = 0 Then
        '    MessageBox.Show("Ingrese el Número de Comprobante", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Me.TxtNroDoc.Focus()
        '    Return False
        'End If

        If idUnidadAgencias <= 0 Then
            MessageBox.Show("Seleccione la Ciudad de Destino", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtCiudadDestino.Text = ""
            TxtCiudadDestino.Focus()
            TxtCiudadDestino.SelectAll()
            Return False
        End If

        If IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad) = idUnidadAgencias Then
            MessageBox.Show("Seleccione una Ciudad Destino diferente a la Ciudad Orígen", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.TxtCiudadDestino.Focus()
            Me.TxtCiudadDestino.SelectAll()
            Return False
        End If

        If Me.CboAgenciaDest.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione la Agencia de Destino.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.CboAgenciaDest.Focus()
            Return False
        End If

        If CboTipoEntrega.SelectedValue = 0 Then
            MessageBox.Show("Seleccione el Tipo de Entrega.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.CboTipoEntrega.Focus()
            Return False
        End If

        If Me.CboFormaPago.SelectedIndex = 1 AndAlso TxtNroTarjeta.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese Número de Tarjeta", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtNroTarjeta.Focus()
            TxtNroTarjeta.SelectAll()
            Return False
        End If

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

        If Me.CboTipoEntrega.SelectedValue = 1 Then
            If idUnidadAgencias = 601 Then
                MessageBox.Show("No están permitidos envíos en agencia para la ciudad destino seleccionada", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.CboTipoEntrega.Focus()
                Return False
            End If
        End If

        '*************************************Validacion de Campos*****************************************
        'hlamas 21/07/2016
        If iID_TipoDocCli = 1 Then 'tipo de documento de cliente es ruc
            If Not fnValidarRUC(TxtNroDocCliente.Text.Trim) Then
                MessageBox.Show("Ingrese un RUC Válido", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtCliente.Focus()
                Me.TxtCliente.SelectAll()
                Return False
            End If
        ElseIf iID_TipoDocCli = 3 Then 'tipo de documento de cliente es ruc
            If TxtNroDocCliente.Text.Trim.Length <> 8 Then
                MessageBox.Show("Ingrese un DNI Válido", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtCliente.Focus()
                Me.TxtCliente.SelectAll()
                Return False
            End If
        End If

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

        'hlamas 10-06-2016
        '------------------------------------------------------------
        If Me.LblTipoComprobante.Text.Trim.Substring(0, 1) = "B" Then '==> Boleta de Venta
            If TxtNroDocCliente.Text.Trim.Length < 8 Then
                MessageBox.Show("Ingrese un DNI válido", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtCliente.Focus() : TxtCliente.SelectAll()
                Return False
            End If
        End If

        If TipoComprobante = 1 Then
            If Me.CboDireccion.SelectedValue = 0 Then
                MessageBox.Show("Seleccione la Dirección Fiscal", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.CboDireccion.Focus()
                Return False
            End If
        End If

        'If Me.CboProducto.SelectedValue <> 6 AndAlso Me.CboDireccion.SelectedValue = 0 Then
        '    MessageBox.Show("Seleccione una Dirección", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Me.CboDireccion.Focus()
        '    Return False
        'End If

        '*******validando nombre del Consignado********
        '***Comentado x NConsignado**************************
        'If TxtNombConsignado.Text.Trim.Length = 0 Then
        '    MessageBox.Show("Ingrese el Consignado", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

        If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio AndAlso Me.CboDireccion2.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione la Direccion del Consignado", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.CboDireccion2.Focus()
            CboDireccion2.SelectAll()
            Return False
        End If

        Dim iDescuento As Integer = IIf(TxtDescuento.Text.Trim <> "", TxtDescuento.Text.Trim, 0)
        If iDescuento > 0 Then
            If iDescuento < -100 Or iDescuento > 100 Then
                MessageBox.Show("Ingrese un Monto de Descuento Correcto", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtDescuento.Focus()
                Me.TxtDescuento.SelectAll()
                Return False
            ElseIf Me.txtDescDescto.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese Nombre de la Persona que Autoriza el Descuento", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDescDescto.Text = ""
                txtDescDescto.Focus()
                txtDescDescto.SelectAll()
                Return False
            End If
        End If

        'hlamas 18-03-2016
        If Me.chkDocumentoCliente.Checked Then 'selecciono con documento del cliente
            If Me.rbtCargoSi.Checked = False And Me.rbtCargoNo.Checked = False Then 'no selecciono si documento cliente es con cargo o sin cargo
                MessageBox.Show("Seleccione si documento del cliente es " & Chr(13) & Chr(13) & "CON DEVOLUCION DE CARGO o SIN DEVOLUCION DE CARGO", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.rbtCargoSi.Focus()
                Me.rbtCargoSi.Checked = False
                Return False
            End If
            'hlamas 18-03-2015
            If Me.rbtCargoSi.Checked Then
                If Not TieneCargo(Me.GrdDocumentosCliente, 2) Then
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
                If Not TieneCargo(Me.GrdDocumentosCliente, 2) Then
                    MessageBox.Show("Ingrese Documentos del Cliente", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.GrdDocumentosCliente.Focus()
                    Return False
                End If
            End If
        End If

        If (ChkArticulos.Checked = False) And ChkM3.Checked = False Then
            'hlamas 11-09-2015
            If Me.CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_SOBRES Then 'tepsa sobres
                If Val(GrdDetalleVenta.Rows(0).Cells(2).Value) > 0 Or Val(GrdDetalleVenta.Rows(0).Cells(1).Value) > 0 Then
                    MessageBox.Show("No puede Ingresar Peso", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
                If Val(GrdDetalleVenta.Rows(1).Cells(2).Value) > 0 Or Val(GrdDetalleVenta.Rows(1).Cells(1).Value) > 0 Then
                    MessageBox.Show("No puede Ingresar Volumen", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            Else
                'Peso
                If Val(GrdDetalleVenta.Rows(0).Cells(2).Value) > 0 And Val(GrdDetalleVenta.Rows(0).Cells(1).Value) = 0 Then
                    MessageBox.Show("Ingrese Número de Bultos para Peso", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If

                'Volumen
                If Val(GrdDetalleVenta.Rows(1).Cells(2).Value) > 0 And Val(GrdDetalleVenta.Rows(1).Cells(1).Value) = 0 Then
                    MessageBox.Show("Ingrese Número de Bultos para Volumen", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If

                'If ObjVentaCargaContado.v_CANTIDAD_X_PESO + ObjVentaCargaContado.v_CANTIDAD_X_SOBRE + ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN + ObjVentaCargaContado.v_MONTO_PENALIDAD <= 0 Then
                If Val(GrdDetalleVenta.Rows(0).Cells(2).Value) = 0 And Val(GrdDetalleVenta.Rows(0).Cells(1).Value) > 0 Then
                    MessageBox.Show("Ingrese Peso del Envío", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
                If Val(GrdDetalleVenta.Rows(1).Cells(2).Value) = 0 And Val(GrdDetalleVenta.Rows(1).Cells(1).Value) > 0 Then
                    MessageBox.Show("Ingrese Volúmen del Envío", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If

            'hlamas 18-07-2015
            If Me.CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX Or Me.CboProducto.SelectedValue = ID_PRODUCTO_TEPSA_BOX_10 Then
                If Val(TxtTotal.Text) <= 0 Then
                    MessageBox.Show("Ingrese Nº de Paquetes", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            Else
                If Val(TxtTotal.Text) <= 0 Then
                    If Val(GrdDetalleVenta.Rows(0).Cells(4).Value) = 0 And Val(GrdDetalleVenta.Rows(1).Cells(4).Value) = 0 And Val(GrdDetalleVenta.Rows(2).Cells(4).Value) = 0 Then
                        MessageBox.Show("Ingrese Peso, Volumen o Sobre", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                Else
                    'hlamas 21-03-2016
                    If Val(GrdDetalleVenta.Rows(0).Cells(4).Value) = 0 And Val(GrdDetalleVenta.Rows(1).Cells(4).Value) = 0 And Val(GrdDetalleVenta.Rows(2).Cells(1).Value) = 0 Then
                        MessageBox.Show("Ingrese Peso, Volumen o Sobre", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return False
                    End If
                End If
            End If
        ElseIf Me.ChkArticulos.Checked Then 'hlamas 21-01-2016
            For Each row As DataGridViewRow In Me.GrdDetalleVenta.Rows
                If Val(row.Cells(2).Value) = 0 And Val(row.Cells(3).Value) > 0 Then
                    MessageBox.Show("Ingrese la Cantidad", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
                If Val(row.Cells(2).Value) > 0 And Val(row.Cells(3).Value) = 0 Then
                    MessageBox.Show("Ingrese el Peso", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            Next
        End If

            '*******validando Monto Afecto**************
            If Val(TxtTotal.Text) <= 0 Then
                MessageBox.Show("Complete la Venta", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.GrdDetalleVenta.Focus()
                Return False
            End If

            ''******Entrega a Domicilio***********
            'If Me.CboTipoEntrega.SelectedValue = 2 Then
            '    Dim intFila As Integer = BuscarItemVenta("ENTREGA", GrdDetalleVenta)
            '    If intFila = 0 Then
            '        If Val(GrdDetalleVenta("sub neto", intFila).Value) = 0 Then
            '            MessageBox.Show("El Servicio de Entrega a Domicilio debe tener una Tarifa Asignada", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '            Me.GrdDetalleVenta.Focus()
            '            Return False
            '        End If
            '    End If
            'End If

            Return True
    End Function

    Dim iOficinaOrigen As Integer
    Dim strNroGuias_Remision As String
    Public bControlFiscalizacion As Boolean = False
    Sub Grabar()
        Try
            ''CARGA ACOMPAÑADA
            'If recuperando_datos_contado And bCargaAcompañada And Me.TxtBoleto.ReadOnly = False And ObjVentaCargaContado.v_facturado = 0 Then
            '    Dim s As String = Me.TxtBoleto.Text.Trim
            '    Dim obj As New dtoVentaCargaContado
            '    If bCargaAcompañada2 = False Then
            '        bCargaAcompañada = False
            '        s = ""
            '    End If

            '    'TxtNombContacto.Text
            '    obj.ActualizaCargaAcompañada(iIdFactura, s, TxtNombConsignado.Text, TxtNroDocConsignado, "", TxtNroDocContacto, TxtNomCliente.Text, TxtNroDocCliente, 0) ', TxtTelfCliente.Text.Trim
            '    MessageBox.Show("Registro Grabado.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    bCargaAcompañada = False
            '    bCargaAcompañada2 = False
            '    fnNUEVO()
            '    limpiar_documentos_cliente()
            '    iOficinaDestino = 0
            '    iOficinaOrigen = 0
            '    Me.Cursor = Cursors.Default
            '    Return
            'ElseIf recuperando_datos_contado And bCargaAcompañada And Me.TxtBoleto.ReadOnly = False And ObjVentaCargaContado.v_facturado = 0 Then 'carga acompañada'And flagPCE
            '    Dim s As String = Me.TxtBoleto.Text.Trim
            '    Dim obj As New dtoVentaCargaContado
            '    If bCargaAcompañada2 = False Then
            '        bCargaAcompañada = False
            '        s = ""
            '    End If
            '    obj.ActualizaCargaAcompañada(iIdFactura, s)
            'ElseIf bCargaAcompañada And LblTipoComprobante.Text.Substring(0, 1) <> "G" And ObjVentaCargaContado.v_facturado = 1 Then 'flagPCE
            '    Me.Cursor = Cursors.Default
            '    Return
            'End If

            If Val(TxtDescuento.Text) = 0 Then
                TxtDescuento.Text = ""
            End If
            bNuevo = True
            If bNuevo Then
                'hlamas 16-05-2017
                'If fnGrabarInsert() = True Then
                If GrabarVenta() Then
                    If ObjVentaCargaContado.fnNroDocuemnto(2, CboProducto.SelectedValue, 1, Me.CboAgenciaOrigen.SelectedValue) = True Then
                        TxtSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                        TxtNroDoc.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                        TxtSerie.Visible = True
                        TxtNroDoc.Visible = True
                    ElseIf ObjVentaCargaContado.fnNroDocuemnto(2, 0, 1, Me.CboAgenciaOrigen.SelectedValue) = True Then
                        TxtSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, ObjVentaCargaContado.Serie)
                        TxtNroDoc.Text = RellenoRight(Mro_Digitos_Ventas, ObjVentaCargaContado.NroDoc)
                        TxtSerie.Visible = True
                        TxtNroDoc.Visible = True
                    End If
                    sDocCliente = ""
                    bBoleto = False
                End If
            Else
                If FnGrabarUpdate() = True Then
                    sDocCliente = ""
                    bBoleto = False
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    '*******************INSERT**********************************
    Dim bOrigenDiferente As Boolean = False
    Dim ObjIMPRESIONFACT_BOL As New dtoIMPRESIONFACT_BOL
    Dim ConfiMensajeriaDlg As New FrmConfiMensajeria
    Public Function fnGrabarInsert() As Boolean
        Dim flat As Boolean = False
        Try
            'PARAMETRO TIPO_COMPROBANTE
            ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = TipoComprobante
            'PARAMETRO v_SERIE_FACTURA******************************************
            ObjVentaCargaContado.v_SERIE_FACTURA = TxtSerie.Text.Trim

            'PARAMETRO v_NRO_FACTURA********************************************
            'If TxtNroDocCliente.Text <> "" Then
            ObjVentaCargaContado.v_NRO_FACTURA = RellenoRight(Mro_Digitos_Ventas, TxtNroDoc.Text)
            TxtNroDoc.Text = RellenoRight(Mro_Digitos_Ventas, TxtNroDoc.Text)
            'End If
            'PARAMETRO FECHA INGRESO (FECHA_FACTURA)****************************
            If bControlFiscalizacion = False Then
                ObjVentaCargaContado.v_FECHA_FACTURA = Format("DD/MM/YYYY", Me.TxtFecha.Text)
            Else
                ObjVentaCargaContado.v_FECHA_FACTURA = Format("DD/MM/YYYY", Me.TxtFecha.Text)
            End If
            'PARAMETRO PRODUCTO (IDPROCESOS)************************************
            ObjVentaCargaContado.v_iProceso = CboProducto.SelectedValue
            'PARAMETRO TIPO TARIFA**********************************************
            ObjVentaCargaContado.TipoTarifa = CboTipoTarifa.SelectedValue
            'PARAMETROS CIUDAD ORIGEN (IDUNIDAD_ORIGEN)*************************
            ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = CboCiudadOrigen.SelectedValue 'dtoUSUARIOS.m_idciudad
            'PARAMETRO AGENCIA ORIGEN*******************************************
            ObjVentaCargaContado.v_IDAGENCIAS = CboAgenciaOrigen.SelectedValue 'dtoUSUARIOS.m_iIdAgencia

            'PARAMETRO CIUDAD DESTINO*******************************************
            If idUnidadAgencias > 0 Then
                'PARAMETRO (IDCIUDAD_DESTINO)***********************************
                ObjVentaCargaContado.v_IDUNIDAD_DESTINO = idUnidadAgencias
                'PARAMETRO (IDAGENCIA_DESTINO*********************************
                ObjVentaCargaContado.v_IDAGENCIAS_DESTINO = CboAgenciaDest.SelectedValue 'Int(ObjVentaCargaContado.coll_AgenciasVenta(CboAgenciaDest.SelectedIndex.ToString))
            End If

            'PARAMETRO TIPO ENTREGA (IDTIPO_ENTREGA)****************************
            ObjVentaCargaContado.v_IDTIPO_ENTREGA = Me.CboTipoEntrega.SelectedValue 'Int(ObjVentaCargaContado.coll_t_Tipo_Entrega(CboTipoEntrega.SelectedIndex.ToString))
            'PARAMETRO TIPO PAGO (IDTIPO_PAGO)**********************************
            ObjVentaCargaContado.v_IDTIPO_PAGO = Int(ObjVentaCargaContado.coll_Tipo_Pago(CboFormaPago.SelectedIndex.ToString))

            'PARAMETRO TARGETAS (IDTARJETAS)************************************
            ObjVentaCargaContado.v_IDTARJETAS = 0
            ObjVentaCargaContado.v_NROTARJETA = "@"
            If ObjVentaCargaContado.v_IDTIPO_PAGO = 2 Then
                'PARAMETRO IDTARJETAS******            
                ObjVentaCargaContado.v_IDTARJETAS = Int(ObjVentaCargaContado.coll_T_TARJETAS(CboTarjeta.SelectedIndex.ToString))
                'PARAMETRO NROTARJETA******
                ObjVentaCargaContado.v_NROTARJETA = IIf(TxtNroTarjeta.Text <> "", TxtNroTarjeta.Text, "@")
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
            If CboDireccion.SelectedIndex = 0 Then
                IdDireccionOrigen = -1 '--> sin direccion valor(seleccione)
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
            ObjVentaCargaContado.ID_TipoDocCli = iID_TipoDocCli '--->agre
            ObjVentaCargaContado.NombresCliente = sNombresCli
            ObjVentaCargaContado.apellPatCli = sApCli
            ObjVentaCargaContado.apellMatCli = sAmCli
            ObjVentaCargaContado.TelefCliente = IIf(sTelfCliente.Length > 0, sTelfCliente.Trim, "@")
            ObjVentaCargaContado.sEmail = sEmail

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
            ObjVentaCargaContado.v_NOMBRES_REMITENTE = IIf(Trim(CboContacto.Text) <> "", CboContacto.Text, "@") 'p
            ObjVentaCargaContado.contacto_mod = IIf(bContactoModificado, 1, 0)
            ObjVentaCargaContado.v_NRO_DOC_REMITENTE = IIf(Trim(TxtNroDocContacto.Text) <> "", TxtNroDocContacto.Text, "@")
            ObjVentaCargaContado.ID_TipoDocCont = iID_TipoDocCont
            ObjVentaCargaContado.NombreCont = NombresCont
            ObjVentaCargaContado.apellPatCont = apellPatCont
            ObjVentaCargaContado.apellMatCont = apellMatCont

            '======================================CONSIGNADO=================================
            '***Comentado x Nconsignado**********************************************
            'PARAMETRO ID_NOMBRE_CONSIGNADO**
            'If Me.TxtNroDocConsignado.Tag = 0 AndAlso Me.ChkCliente2.Checked Then
            '    Dim objContacto As New dtoVentaCargaContado
            '    Dim dt As DataTable = objContacto.BuscarContacto(TxtNroDocConsignado.Text)
            '    Dim resp As Integer = dt.Rows.Count
            '    If resp = 0 Then
            '        Me.TxtNroDocConsignado.Tag = 0
            '    Else
            '        Me.TxtNroDocConsignado.Tag = dt.Rows(0).Item(0)
            '        bConsignadoModificado = False
            '    End If
            'End If
            '************************************************************************

            '===Cambio(Agregado) NConsignado==========================================
            If iNroDocumentoTag = 0 AndAlso Me.ChkCliente2.Checked Then
                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.BuscarContacto(GrdNConsignado("Nº Documento", 0).Value)
                Dim resp As Integer = dt.Rows.Count
                If resp = 0 Then
                    iNroDocumentoTag = 0
                    GrdNConsignado("IDConsignado", 0).Value = "0"
                Else
                    iNroDocumentoTag = dt.Rows(0).Item(0)
                    GrdNConsignado("IDConsignado", 0).Value = dt.Rows(0).Item(0)
                    bConsignadoModificado = False
                End If
            End If
            '=========================================================================

            '***Comentado x NConsignado***********************************************
            'ObjVentaCargaContado.v_IDCONTACTO_DESTINO = IIf(IsNothing(Me.TxtNroDocConsignado.Tag), 0, Me.TxtNroDocConsignado.Tag)
            ''ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = IIf(Trim(sNombresConsig.Trim) <> "", sNombresConsig.Trim, "@")
            'ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = IIf(Me.TxtNombConsignado.Text.Trim <> "", Me.TxtNombConsignado.Text.Trim, "@")
            'ObjVentaCargaContado.NombConsignado_mod = IIf(bConsignadoModificado, 1, 0)
            'ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO = IIf(Trim(TxtNroDocConsignado.Text) <> "", TxtNroDocConsignado.Text, "@")
            'ObjVentaCargaContado.ID_TipoDocConsig = iID_TipoDocConsig
            'ObjVentaCargaContado.NombreConsignado = sNombresConsig
            'ObjVentaCargaContado.apellPatConsig = sapellPatConsig
            'ObjVentaCargaContado.apellMatConsig = sapellMatConsig
            'ObjVentaCargaContado.TelfConsignado = IIf(sTelefonoConsig.Length > 0, sTelefonoConsig, "@")

            '===Agregado x NConsignado================================================
            Me.LimpiarNConsignados()
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
            '=================================================================================

            '--DIRECCION ESTRUCTURADA CONSIGNADO
            'PARAMETRO ID_DIRECCION_DESTINO**
            If CboDireccion2.SelectedIndex = 0 Then
                idDireConsignado = -1
            End If
            ObjVentaCargaContado.v_IDDIREECION_DESTINO = idDireConsignado
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
            ObjVentaCargaContado.sReferencia = TxtReferencia.Text.Trim

            '---Nuevos Parametros a agregar---
            ObjVentaCargaContado.TarifarioGeneral = IIf(bTarifarioGeneral, 1, 0)
            ObjVentaCargaContado.Contado = IIf(bContado, 1, 0)

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
            ObjVentaCargaContado.v_cargo = Me.rbtCargoSi.Checked
            'hlamas 26-08-2015
            'If TieneCargo(Me.GrdDocumentosCliente, 2) Then
            'ObjVentaCargaContado.v_cargo = True
            'Me.ChkCargo.Checked = True
            'End If

            'ObjVentaCargaContado.v_idagencia_venta = dtoUSUARIOS.m_iIdAgencia
            'ObjVentaCargaContado.v_idciudad_venta = dtoUSUARIOS.m_idciudad
            ObjVentaCargaContado.v_idagencia_venta = 0
            ObjVentaCargaContado.v_idciudad_venta = 0

            If CboProducto.SelectedValue = 6 Then 'PARAMETROS CARGA ACOMPAÑADA
                ObjVentaCargaContado.v_idagencia_venta = CboAgenciaOrigen.SelectedValue 'dtoUSUARIOS.m_iIdAgencia
                ObjVentaCargaContado.v_idciudad_venta = CboCiudadOrigen.SelectedValue 'dtoUSUARIOS.m_idciudad
                ObjVentaCargaContado.v_nroboleto = Me.TxtBoleto.Text
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
                'hlamas 18-07-2015
            ElseIf CboProducto.SelectedValue = 9 Then 'PARAMETROS ESTANDAR(NORMAL)
                ObjVentaCargaContado.v_nroboleto = ""
                ObjVentaCargaContado.v_carga_acompañada = 0 'Nota                
                ObjVentaCargaContado.bOrigenDiferente = False
                ObjVentaCargaContado.v_TIPO_DOCUMENTO = 0
            ElseIf CboProducto.SelectedValue = 10 Then 'PARAMETROS ESTANDAR(NORMAL)
                ObjVentaCargaContado.v_nroboleto = ""
                ObjVentaCargaContado.v_carga_acompañada = 0 'Nota                
                ObjVentaCargaContado.bOrigenDiferente = False
                ObjVentaCargaContado.v_TIPO_DOCUMENTO = 0
            End If

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

                'VOLUMEN
                If IsDBNull(GrdDetalleVenta.Rows(1).Cells(2)) = False Then
                    If Conversion.Val(GrdDetalleVenta(1, 1).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta(1, 1).Value
                    If Conversion.Val(GrdDetalleVenta(2, 1).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta(2, 1).Value
                    ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN = valor1
                    ObjVentaCargaContado.v_TOTAL_VOLUMEN = valor2
                    totalCosto = totalCosto + valor2 * tarifa_Volumen
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
                tarifa_Volumen = Format(Val(GrdDetalleVenta(3, 1).Value), "##,###,###.00")

                If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                    tarifa_Sobre = Format(Val(GrdDetalleVenta(3, 2).Value), "##,###,###.00")
                    'hlamas 18-07-2015
                    If Val(GrdDetalleVenta.Rows(0).Cells(4).Value) = 0 And Val(GrdDetalleVenta.Rows(1).Cells(4).Value) = 0 And Val(GrdDetalleVenta.Rows(2).Cells(4).Value) = 0 And tarifa_Sobre = 0 Then
                        tarifa_Sobre = CDbl(Me.TxtTotal.Text)
                    End If
                End If
            End If

            '******************************GRID M3*********************************
            If ChkM3.Checked = True Then
                'PESO
                If IsDBNull(GrdDetalleVenta.Rows(0).Cells(2)) = False Then
                    '-------
                    If Conversion.Val(GrdDetalleVenta(1, 0).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta(1, 0).Value
                    If Conversion.Val(GrdDetalleVenta(5, 0).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta(5, 0).Value
                    '-------
                    ObjVentaCargaContado.v_CANTIDAD_X_PESO = valor1
                    ObjVentaCargaContado.v_TOTAL_PESO = valor2
                    totalCosto = valor2 * tarifa_Peso
                End If

                'SOBRE
                If Val(txtCantidadSobres.Text) > 0 Then
                    valor1 = Val(txtCantidadSobres.Text)
                    ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = valor1
                    totalCosto = totalCosto + valor1 * tarifa_Sobre
                End If

                '************                
                ObjVentaCargaContado.v_METROCUBICO = 1
                ObjVentaCargaContado.v_ALTURA = FormatNumber(Format(Val(GrdDetalleVenta(2, 0).Value), "##,###,###.00"), 2)
                ObjVentaCargaContado.v_ANCHO = Format(Val(GrdDetalleVenta(3, 0).Value), "##,###,###.00")
                ObjVentaCargaContado.v_LARGO = Format(Val(GrdDetalleVenta(4, 0).Value), "##,###,###.00")
                ObjVentaCargaContado.v_PESO_KG = Format(Val(GrdDetalleVenta(5, 0).Value), "##,###,###.00")
                ObjVentaCargaContado.v_FACTOR = Factor_
                '************

                '*******
                tarifa_Peso = Format(Val(GrdDetalleVenta(6, 0).Value), "##,###,###.00")
                tarifa_Sobre = Format(Val(txtMontoBase.Text), "##,###,###.00")
                '*******
            Else
                ObjVentaCargaContado.v_METROCUBICO = 0
                ObjVentaCargaContado.v_ALTURA = 0
                ObjVentaCargaContado.v_ANCHO = 0
                ObjVentaCargaContado.v_LARGO = 0
                ObjVentaCargaContado.v_PESO_KG = 0
                ObjVentaCargaContado.v_FACTOR = 0
            End If

            If chkSobres.Checked = True Then
                ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = Val(txtCantidadSobres.Text)
            End If

            ObjVentaCargaContado.v_PRECIO_X_PESO = tarifa_Peso
            ObjVentaCargaContado.v_PRECIO_X_VOLUMEN = tarifa_Volumen
            ObjVentaCargaContado.v_PRECIO_X_SOBRE = tarifa_Sobre


            ObjVentaCargaContado.v_MONTO_SUB_TOTAL = TxtSubtotal.Text
            ObjVentaCargaContado.v_MONTO_IMPUESTO = TxtImpuesto.Text
            ObjVentaCargaContado.v_TOTAL_COSTO = TxtTotal.Text

            ObjVentaCargaContado.v_IDTIPO_MONEDA = 1 'Soles
            '---USUARIO REMOTO--------
            ObjVentaCargaContado.v_IDUSUARIO_PERSONAL = Me.CboListaUsuarios.SelectedValue 'dtoUSUARIOS.IdLogin 08102011
            ObjVentaCargaContado.iIDUsuarioRemoto = dtoUSUARIOS.IdLogin '08102011
            '-------------------------

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

            '********************fin grid articulos*********************************************************
            '----------------------------------------------------------------------------------------------------------------------------            
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

            ObjIMPRESIONFACT_BOL.xDestino = TxtCiudadDestino.Text
            ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL = Me.TxtSerie.Text & "-" & Me.TxtNroDoc.Text
            ObjIMPRESIONFACT_BOL.xRazonSocial = Me.TxtNomCliente.Text.Trim
            ObjIMPRESIONFACT_BOL.xDireccionRemitente = Me.CboDireccion.Text.Trim
            ObjIMPRESIONFACT_BOL.xRuc = TxtNroDocCliente.Text
            ObjIMPRESIONFACT_BOL.xConsignado = ObjVentaCargaContado.v_NOMBRES_DESTINATARIO 'GrdNConsignado("Nombres", 0).Value 'Me.TxtNombConsignado.Text NConsignado
            'ObjIMPRESIONFACT_BOL.xDireccionConsignado = Me.TxtDirecConsignado.Text'verificar
            ObjIMPRESIONFACT_BOL.xDireccionConsignado = Me.CboDireccion2.Text & IIf(Me.CboTipoEntrega.SelectedValue = TipoEntrega.Agencia, " " & Me.CboAgenciaDest.Text, "")
            ObjIMPRESIONFACT_BOL.xfecha_factura = Me.TxtFecha.Text
            ObjIMPRESIONFACT_BOL.xTotalPeso = ObjVentaCargaContado.v_TOTAL_PESO
            ObjIMPRESIONFACT_BOL.xTotalVolumen = ObjVentaCargaContado.v_TOTAL_VOLUMEN
            ObjIMPRESIONFACT_BOL.xTotalSobres = 0
            ObjIMPRESIONFACT_BOL.xNroRef = Me.TxtSerie.Text & "-" & Me.TxtNroDoc.Text
            ObjIMPRESIONFACT_BOL.xMemo = Me.txtDescDescto.Text
            ObjIMPRESIONFACT_BOL.xMonto_Sub_Total = Me.TxtSubtotal.Text
            ObjIMPRESIONFACT_BOL.xMonto_Impuesto = TxtImpuesto.Text
            ObjIMPRESIONFACT_BOL.xTotal_Costo = ObjVentaCargaContado.v_TOTAL_COSTO
            ObjIMPRESIONFACT_BOL.xDescuento = IIf(TxtDescuento.Text <> "", TxtDescuento.Text, "")
            ObjIMPRESIONFACT_BOL.xAgenciaDestino = IIf(CboAgenciaDest.Text <> "", CboAgenciaDest.Text, "")
            ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA = CboTipoEntrega.Text

            If ObjVentaCargaContado.v_MONTO_SUB_TOTAL + ObjVentaCargaContado.v_MONTO_IMPUESTO <> ObjVentaCargaContado.v_TOTAL_COSTO Then
                ObjVentaCargaContado.v_MONTO_SUB_TOTAL = FormatNumber(Format(ObjVentaCargaContado.v_TOTAL_COSTO / 1.18, "###,###,###.00"), 2)
                ObjVentaCargaContado.v_MONTO_IMPUESTO = FormatNumber(Format(0.18 * ObjVentaCargaContado.v_TOTAL_COSTO / 1.18, "###,###,###.00"), 2)
                Me.TxtSubtotal.Text = Format(ObjVentaCargaContado.v_MONTO_SUB_TOTAL, "###,###,###.00")
                Me.TxtImpuesto.Text = Format(ObjVentaCargaContado.v_MONTO_IMPUESTO, "###,###,###.00")
            End If


            If varIdCondicion = 2 Or varIdCondicion = 5 Then '====> (2=Tarjeta,5=Cortesia)
                Me.Cursor = Cursors.AppStarting
                asignar_documentos_clientes()

                If ObjVentaCargaContado.GrabarV = True Then
                    iCliente = ObjVentaCargaContado.v_IDPERSONA
                    Me.Cursor = Cursors.Default
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
                    ObjIMPRESIONFACT_BOL.xIdFactura = ObjVentaCargaContado.v_IDFACTURA.ToString

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
                            objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = Me.CboListaUsuarios.SelectedValue 'dtoUSUARIOS.IdLogin 'USUARIO REMOTO
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
                                                 Factor_,
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
                            objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = Me.CboListaUsuarios.SelectedValue 'dtoUSUARIOS.IdLogin USUARIO REMOTO
                            objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol
                            objGuia_Envio_Articulo.iIDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                            objGuia_Envio_Articulo.iIDESTADO_REGISTRO = 18

                            For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                                If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                                    'hlamas 21-01-2016
                                    If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" And GrdDetalleVenta.Rows(ii).Cells(0).Value <> "ENTREGA" Then
                                        objGuia_Envio_Articulo.iIDARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(5).Value.ToString)
                                        objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString)
                                        objGuia_Envio_Articulo.iPESO = Int(GrdDetalleVenta.Rows(ii).Cells(3).Value.ToString)
                                        objGuia_Envio_Articulo.iPRECIO_X_ARTICULO = Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii).Cells(1).Value.ToString)
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
                    objGuiaEnvio.iIDUSUARIO_PERSONAL = Me.CboListaUsuarios.SelectedValue '--USUARIO REMOTO
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


                    'If bControlFiscalizacion = False Then
                    '    MessageBox.Show("Encienda la Impresora", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '    If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 1 Then
                    '        ImprimirFactura()
                    '    Else
                    '        ImprimirBoleta()
                    '    End If
                    'End If

                    'If flagPCEVALIDADOC = False Then
                    If MessageBox.Show("¿Está Seguro de Imprimir las Etiquetas?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        If xIMPRESORA = 1 Or xIMPRESORA = 4 Then
                            fnImprimirEtiquetas()
                        Else
                            If xIMPRESORA = 2 Then
                                fnImprimirEtiquetasFAC_II()
                            Else
                                fnImprimirEtiquetasFAC_III()
                            End If
                        End If
                    End If
                    'End If

                    fnNUEVO()
                    limpiar_documentos_cliente()
                    flat = True
                    iOficinaDestino = 0
                    iOficinaOrigen = 0
                Else
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("La Venta no se Registró", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            ElseIf varIdCondicion = 1 Then '-> 1=Efectivo
                If bControlFiscalizacion = False Then
                    Dim varDlgPagos As New frmPagosContado
                    If varDlgPagos.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        If varDlgPagos.txtPagoSoles.Text > 0 Then
                            lblTotalPagado.Visible = True
                            lblTotalVenta.Visible = True
                            lblVuelto.Visible = True
                            txtTotalPagado.Visible = True
                            txtTotalVenta.Visible = True
                            txtVuelto.Visible = True
                            txtTotalVenta.Text = FormatNumber(TxtTotal.Text, 2)
                            txtTotalPagado.Text = FormatNumber(varDlgPagos.txtPagoSoles.Text, 2)
                            txtVuelto.Text = FormatNumber(varDlgPagos.txtVuelto.Text, 2)
                        End If
                        asignar_documentos_clientes()

                        If ObjVentaCargaContado.GrabarV = True Then
                            iCliente = ObjVentaCargaContado.v_IDPERSONA
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
                            ObjPagosSoles.v_idfactura_contado = ObjVentaCargaContado.v_IDFACTURA
                            ObjPagosDolares.v_idfactura_contado = ObjVentaCargaContado.v_IDFACTURA
                            ObjIMPRESIONFACT_BOL.xIdFactura = ObjVentaCargaContado.v_IDFACTURA.ToString

                            '-------------------------------------------
                            'INSERCION VOLUMETRICO
                            '-------------------------------------------
                            Try
                                If ChkM3.Checked = True Then
                                    Dim obj As New dtoVentaCargaContado
                                    Dim ii As Integer = 0
                                    objGuia_Envio_Articulo.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
                                    objGuia_Envio_Articulo.iIGV = dtoUSUARIOS.iIGV
                                    objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
                                    objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = CboListaUsuarios.SelectedValue 'dtoUSUARIOS.IdLogin 'USUARIO REMOTO
                                    objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol

                                    For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                                        If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                                            If GrdDetalleVenta.Rows(ii).Cells("sub neto").Value > 0 And IsNumeric(GrdDetalleVenta.Rows(ii).Cells("tipo").Value) Then
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
                                                         Factor_,
                                                         GrdDetalleVenta.Rows(ii).Cells("Costo").Value)
                                            End If
                                        End If
                                    Next
                                End If
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try


                            '-------------------------------------------
                            'INSERCION DE ARTICULOS
                            '------------------------------------------- 
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
                                    objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = CboListaUsuarios.SelectedValue 'dtoUSUARIOS.IdLogin USUARIO REMOTO
                                    objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol

                                    objGuia_Envio_Articulo.iIDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                                    objGuia_Envio_Articulo.iIDESTADO_REGISTRO = 18
                                    For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                                        If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                                            'hlamas 21-01-2016
                                            If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" And GrdDetalleVenta.Rows(ii).Cells(0).Value <> "ENTREGA" Then
                                                objGuia_Envio_Articulo.iIDARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(5).Value.ToString)
                                                objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString)
                                                objGuia_Envio_Articulo.iPESO = Int(GrdDetalleVenta.Rows(ii).Cells(3).Value.ToString)
                                                objGuia_Envio_Articulo.iPRECIO_X_ARTICULO = Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii).Cells(1).Value.ToString)
                                                objGuia_Envio_Articulo.fnINSTUPD_FACBOL_ARTICULOS()
                                            End If
                                        End If
                                    Next
                                End If
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try


                            flat = True
                            Dim i As Integer = 0
                            Dim serie_NroDoc() As String
                            objGuiaEnvio.iControl_Documentos = 1
                            objGuiaEnvio.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
                            objGuiaEnvio.V_IDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                            objGuiaEnvio.iIDUSUARIO_PERSONAL = CboListaUsuarios.SelectedValue 'USUARIO REMOTO
                            Dim iContador As Integer = 0

                            '-------------------------------------------
                            'INICIO DE DOCUMENTOS DEL CLIENTE
                            '-------------------------------------------                     
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


                            'If bControlFiscalizacion = False Then
                            '    MessageBox.Show("Encienda la Impresora", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            '    If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = 1 Then
                            '        ImprimirFactura()
                            '    Else
                            '        ImprimirBoleta()
                            '    End If
                            'End If

                            'If flagPCEVALIDADOC = False Then
                            'If MessageBox.Show("¿Esta Seguro de Imprimir la Etiquetas?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            '    If xIMPRESORA = 1 Or xIMPRESORA = 4 Then
                            '        fnImprimirEtiquetas()
                            '    Else
                            '        If xIMPRESORA = 2 Then
                            '            fnImprimirEtiquetasFAC_II()
                            '        Else
                            '            fnImprimirEtiquetasFAC_III()
                            '        End If
                            '    End If
                            'End If
                            'End If

                            fnNUEVO()
                            limpiar_documentos_cliente()
                            flat = True
                            iOficinaDestino = 0
                            iOficinaOrigen = 0
                        Else
                            lblTotalPagado.Visible = False
                            lblTotalVenta.Visible = False
                            lblVuelto.Visible = False
                            txtTotalPagado.Visible = False
                            txtTotalVenta.Visible = False
                            txtVuelto.Visible = False
                            MessageBox.Show("La Venta no se Registró", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        lblTotalPagado.Visible = False
                        lblTotalVenta.Visible = False
                        lblVuelto.Visible = False
                        txtTotalPagado.Visible = False
                        txtTotalVenta.Visible = False
                        txtVuelto.Visible = False
                        'MsgBox("Cancelo Operacion Puede Intentar el Pago de Nuevo", MsgBoxStyle.Information, "Seguridad Sistema")
                    End If
                Else
                    asignar_documentos_clientes()
                    '                   
                    If ObjVentaCargaContado.GrabarV() = True Then
                        iCliente = ObjVentaCargaContado.v_IDPERSONA
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
                        Try
                            If ChkArticulos.Enabled = True Then
                                Dim ii As Integer = 0
                                objGuia_Envio_Articulo.iCONTROL = 1
                                objGuia_Envio_Articulo.iIDGUIAS_ENVIO_ARTICULOS = 0
                                objGuia_Envio_Articulo.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
                                objGuia_Envio_Articulo.iIGV = dtoUSUARIOS.iIGV
                                objGuia_Envio_Articulo.iDESCUENTO = 0
                                objGuia_Envio_Articulo.iPENALIDAD = 0
                                objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
                                objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = CboListaUsuarios.SelectedValue 'dtoUSUARIOS.IdLogin USUARIO REMOTO
                                objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol
                                objGuia_Envio_Articulo.iIDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                                objGuia_Envio_Articulo.iIDESTADO_REGISTRO = 18
                                For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                                    If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                                        If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
                                            objGuia_Envio_Articulo.iIDARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(5).Value.ToString)
                                            objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString)
                                            objGuia_Envio_Articulo.iPESO = Int(GrdDetalleVenta.Rows(ii).Cells(3).Value.ToString)
                                            objGuia_Envio_Articulo.iPRECIO_X_ARTICULO = Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii).Cells(1).Value.ToString)
                                            objGuia_Envio_Articulo.fnINSTUPD_FACBOL_ARTICULOS()
                                        End If
                                    End If
                                Next
                            End If
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        flat = True
                        Dim i As Integer = 0
                        Dim serie_NroDoc() As String
                        objGuiaEnvio.iControl_Documentos = 1
                        objGuiaEnvio.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
                        objGuiaEnvio.V_IDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                        objGuiaEnvio.iIDUSUARIO_PERSONAL = CboListaUsuarios.SelectedValue 'USUARIO REMOTO
                        Dim iContador As Integer = 0

                        '************************GRIDVIEW DOCUMENTOS**************************************************************
                        If objGuiaEnvio.iCONTROL = 0 Or objGuiaEnvio.iCONTROL = 1 Then
                            For i = 0 To Me.GrdDocumentosCliente.Rows().Count() - 2
                                Try
                                    If IsDBNull(GrdDocumentosCliente.Rows(i).Cells(2)) = False Then
                                        'If GrdDocumentosCliente.Rows(i).Cells(2).Value.ToString <> "" Then
                                        If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells(2).Value) Then
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
                                    If IsDBNull(GrdDocumentosCliente.Rows(i).Cells(3)) = False Then
                                        'If GrdDocumentosCliente.Rows(i).Cells(3).Value.ToString <> "" Then
                                        If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells(3).Value) Then
                                            serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells(3).Value.ToString, "-")
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
                        If MessageBox.Show("¿Está Seguro de Imprimir las Etiquetas?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            If xIMPRESORA = 1 Or xIMPRESORA = 4 Then
                                fnImprimirEtiquetas()
                            Else
                                If xIMPRESORA = 2 Then
                                    fnImprimirEtiquetasFAC_II()
                                Else
                                    fnImprimirEtiquetasFAC_III()
                                End If
                            End If
                        End If

                        TipoComprobante = 2
                        fnNUEVO()
                        limpiar_documentos_cliente()
                        flat = True
                        iOficinaDestino = 0
                        iOficinaOrigen = 0
                    End If
                End If
            End If
            bOrigenDiferente = False
        Catch ex As Exception
            flat = False
            Throw New Exception(ex.Message)
        End Try
        Return flat
    End Function

    '*******************UPDATE**********************************
    Public Function FnGrabarUpdate() As Boolean
        Dim flat As Boolean = False
        Try
            'PARAMETRO TIPO_COMPROBANTE
            ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = TipoComprobante
            'PARAMETRO v_SERIE_FACTURA******************************************
            ObjVentaCargaContado.v_SERIE_FACTURA = TxtSerie.Text.Trim

            'PARAMETRO v_NRO_FACTURA********************************************
            'If TxtNroDocCliente.Text <> "" Then
            ObjVentaCargaContado.v_NRO_FACTURA = RellenoRight(Mro_Digitos_Ventas, TxtNroDoc.Text)
            TxtNroDoc.Text = RellenoRight(Mro_Digitos_Ventas, TxtNroDoc.Text)
            'End If
            'PARAMETRO FECHA INGRESO (FECHA_FACTURA)****************************
            '--If bControlFiscalizacion = False Then
            'ObjVentaCargaContado.v_FECHA_FACTURA = dtoUSUARIOS.m_sFecha
            'Else
            ObjVentaCargaContado.v_FECHA_FACTURA = Format("DD/MM/YYYY", Me.TxtFecha.Text)
            'End If
            'PARAMETRO PRODUCTO (IDPROCESOS)**************************** ********
            ObjVentaCargaContado.v_iProceso = CboProducto.SelectedValue
            'PARAMETRO TIPO TARIFA**********************************************
            ObjVentaCargaContado.TipoTarifa = CboTipoTarifa.SelectedValue
            'PARAMETROS CIUDAD ORIGEN (IDUNIDAD_ORIGEN)*************************
            ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = CboCiudadOrigen.SelectedValue 'dtoUSUARIOS.m_idciudad
            'PARAMETRO AGENCIA ORIGEN*******************************************
            ObjVentaCargaContado.v_IDAGENCIAS = CboAgenciaOrigen.SelectedValue 'dtoUSUARIOS.m_iIdAgencia

            'PARAMETRO CIUDAD DESTINO*******************************************
            If idUnidadAgencias > 0 Then
                'PARAMETRO (IDCIUDAD_DESTINO)***********************************
                ObjVentaCargaContado.v_IDUNIDAD_DESTINO = idUnidadAgencias
                'PARAMETRO (IDAGENCIA_DESTINO*********************************
                ObjVentaCargaContado.v_IDAGENCIAS_DESTINO = CboAgenciaDest.SelectedValue 'Int(ObjVentaCargaContado.coll_AgenciasVenta(CboAgenciaDest.SelectedIndex.ToString))
            End If

            'PARAMETRO TIPO ENTREGA (IDTIPO_ENTREGA)****************************
            ObjVentaCargaContado.v_IDTIPO_ENTREGA = Me.CboTipoEntrega.SelectedValue
            'PARAMETRO TIPO PAGO (IDTIPO_PAGO)**********************************
            ObjVentaCargaContado.v_IDTIPO_PAGO = Int(ObjVentaCargaContado.coll_Tipo_Pago(CboFormaPago.SelectedIndex.ToString))

            'PARAMETRO TARGETAS (IDTARJETAS)************************************
            ObjVentaCargaContado.v_IDTARJETAS = 0
            ObjVentaCargaContado.v_NROTARJETA = "@"
            If ObjVentaCargaContado.v_IDTIPO_PAGO = 2 Then
                'PARAMETRO IDTARJETAS******            
                ObjVentaCargaContado.v_IDTARJETAS = Int(ObjVentaCargaContado.coll_T_TARJETAS(CboTarjeta.SelectedIndex.ToString))
                'PARAMETRO NROTARJETA******
                ObjVentaCargaContado.v_NROTARJETA = IIf(TxtNroTarjeta.Text <> "", TxtNroTarjeta.Text, "@")
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
            If CboDireccion.SelectedIndex = 0 Then
                IdDireccionOrigen = -1 '--> sin direccion valor(seleccione)
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
            ObjVentaCargaContado.ID_TipoDocCli = iID_TipoDocCli '--->agre
            ObjVentaCargaContado.NombresCliente = sNombresCli
            ObjVentaCargaContado.apellPatCli = sApCli
            ObjVentaCargaContado.apellMatCli = sAmCli
            ObjVentaCargaContado.TelefCliente = IIf(sTelfCliente.Length > 0, sTelfCliente.Trim, "@")
            ObjVentaCargaContado.sEmail = sEmail

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
            ObjVentaCargaContado.v_NOMBRES_REMITENTE = IIf(Trim(CboContacto.Text) <> "", CboContacto.Text, "@") 'p
            ObjVentaCargaContado.contacto_mod = IIf(bContactoModificado, 1, 0)
            ObjVentaCargaContado.v_NRO_DOC_REMITENTE = IIf(Trim(TxtNroDocContacto.Text) <> "", TxtNroDocContacto.Text, "@")
            ObjVentaCargaContado.ID_TipoDocCont = iID_TipoDocCont
            ObjVentaCargaContado.NombreCont = NombresCont
            ObjVentaCargaContado.apellPatCont = apellPatCont
            ObjVentaCargaContado.apellMatCont = apellMatCont

            '======================================CONSIGNADO=================================
            '***Comentado x Nconsignado**********************************************
            'PARAMETRO ID_NOMBRE_CONSIGNADO**
            'If Me.TxtNroDocConsignado.Tag = 0 AndAlso Me.ChkCliente2.Checked Then
            '    Dim objContacto As New dtoVentaCargaContado
            '    Dim dt As DataTable = objContacto.BuscarContacto(TxtNroDocConsignado.Text)
            '    Dim resp As Integer = dt.Rows.Count
            '    If resp = 0 Then
            '        Me.TxtNroDocConsignado.Tag = 0
            '    Else
            '        Me.TxtNroDocConsignado.Tag = dt.Rows(0).Item(0)
            '        bConsignadoModificado = False
            '    End If
            'End If
            '************************************************************************

            '===Cambio(Agregado) NConsignado==========================================
            If iNroDocumentoTag = 0 AndAlso Me.ChkCliente2.Checked Then
                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.BuscarContacto(GrdNConsignado("Nº Documento", 0).Value)
                Dim resp As Integer = dt.Rows.Count
                If resp = 0 Then
                    iNroDocumentoTag = 0
                    GrdNConsignado("IDConsignado", 0).Value = "0"
                Else
                    iNroDocumentoTag = dt.Rows(0).Item(0)
                    GrdNConsignado("IDConsignado", 0).Value = dt.Rows(0).Item(0)
                    bConsignadoModificado = False
                End If
            End If
            '=========================================================================

            '***Comentado x NConsignado***********************************************
            'ObjVentaCargaContado.v_IDCONTACTO_DESTINO = IIf(IsNothing(Me.TxtNroDocConsignado.Tag), 0, Me.TxtNroDocConsignado.Tag)
            ''ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = IIf(Trim(sNombresConsig.Trim) <> "", sNombresConsig.Trim, "@")
            'ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = IIf(Me.TxtNombConsignado.Text.Trim <> "", Me.TxtNombConsignado.Text.Trim, "@")
            'ObjVentaCargaContado.NombConsignado_mod = IIf(bConsignadoModificado, 1, 0)
            'ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO = IIf(Trim(TxtNroDocConsignado.Text) <> "", TxtNroDocConsignado.Text, "@")
            'ObjVentaCargaContado.ID_TipoDocConsig = iID_TipoDocConsig
            'ObjVentaCargaContado.NombreConsignado = sNombresConsig
            'ObjVentaCargaContado.apellPatConsig = sapellPatConsig
            'ObjVentaCargaContado.apellMatConsig = sapellMatConsig
            'ObjVentaCargaContado.TelfConsignado = IIf(sTelefonoConsig.Length > 0, sTelefonoConsig, "@")

            '===Agregado x NConsignado================================================
            Me.LimpiarNConsignados()
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
                ObjVentaCargaContado.IDVentaConsignado &= GrdNConsignado("IDVentaConsignado", i).Value & ";"
            Next
            '=================================================================================

            '--DIRECCION ESTRUCTURADA CONSIGNADO
            'PARAMETRO ID_DIRECCION_DESTINO**
            If CboDireccion2.SelectedIndex = 0 Then
                idDireConsignado = -1
            End If
            ObjVentaCargaContado.v_IDDIREECION_DESTINO = idDireConsignado
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
            ObjVentaCargaContado.sReferencia = TxtReferencia.Text.Trim

            '---Nuevos Parametros a agregar---
            ObjVentaCargaContado.TarifarioGeneral = IIf(bTarifarioGeneral, 1, 0)
            ObjVentaCargaContado.Contado = IIf(bContado, 1, 0)

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
            ObjVentaCargaContado.v_cargo = Me.rbtCargoSi.Checked

            'ObjVentaCargaContado.v_idagencia_venta = dtoUSUARIOS.m_iIdAgencia
            'ObjVentaCargaContado.v_idciudad_venta = dtoUSUARIOS.m_idciudad
            ObjVentaCargaContado.v_idagencia_venta = 0
            ObjVentaCargaContado.v_idciudad_venta = 0

            If CboProducto.SelectedValue = 6 Then 'PARAMETROS CARGA ACOMPAÑADA
                ObjVentaCargaContado.v_idagencia_venta = Me.CboAgenciaOrigen.SelectedValue
                ObjVentaCargaContado.v_idciudad_venta = Me.CboCiudadOrigen.SelectedValue
                ObjVentaCargaContado.v_nroboleto = Me.TxtBoleto.Text
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
            ElseIf CboProducto.SelectedValue = 81 Or CboProducto.SelectedValue = 82 Then
                ObjVentaCargaContado.v_nroboleto = ""
                ObjVentaCargaContado.v_carga_acompañada = 0
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

                'VOLUMEN
                If IsDBNull(GrdDetalleVenta.Rows(1).Cells(2)) = False Then
                    If Conversion.Val(GrdDetalleVenta(1, 1).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta(1, 1).Value
                    If Conversion.Val(GrdDetalleVenta(2, 1).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta(2, 1).Value
                    ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN = valor1
                    ObjVentaCargaContado.v_TOTAL_VOLUMEN = valor2
                    totalCosto = totalCosto + valor2 * tarifa_Volumen
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
                tarifa_Volumen = Format(Val(GrdDetalleVenta(3, 1).Value), "##,###,###.00")

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
                    If Conversion.Val(GrdDetalleVenta(1, 0).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta(1, 0).Value
                    If Conversion.Val(GrdDetalleVenta(5, 0).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta(5, 0).Value
                    '-------

                    ObjVentaCargaContado.v_CANTIDAD_X_PESO = valor1
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
                ObjVentaCargaContado.v_FACTOR = Factor_
                '**************

                'MOD***
                tarifa_Peso = Format(Val(GrdDetalleVenta(6, 0).Value), "##,###,###.00")
                tarifa_Sobre = Format(Val(txtMontoBase.Text), "##,###,###.00")
                '******
            Else
                ObjVentaCargaContado.v_METROCUBICO = 0
                ObjVentaCargaContado.v_ALTURA = 0
                ObjVentaCargaContado.v_ANCHO = 0
                ObjVentaCargaContado.v_LARGO = 0
                ObjVentaCargaContado.v_PESO_KG = 0
                ObjVentaCargaContado.v_FACTOR = 0
            End If

            If chkSobres.Checked = True Then
                ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = Val(txtCantidadSobres.Text)
            End If

            ObjVentaCargaContado.v_PRECIO_X_PESO = tarifa_Peso
            ObjVentaCargaContado.v_PRECIO_X_VOLUMEN = tarifa_Volumen
            ObjVentaCargaContado.v_PRECIO_X_SOBRE = tarifa_Sobre


            ObjVentaCargaContado.v_MONTO_SUB_TOTAL = TxtSubtotal.Text
            ObjVentaCargaContado.v_MONTO_IMPUESTO = TxtImpuesto.Text
            ObjVentaCargaContado.v_TOTAL_COSTO = TxtTotal.Text

            ObjVentaCargaContado.v_IDTIPO_MONEDA = 1 'Soles

            ObjVentaCargaContado.v_IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
            ObjVentaCargaContado.iIDUsuarioRemoto = 0 '08102011
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

            ObjIMPRESIONFACT_BOL.fnClear()

            '***********************************
            If ChkArticulos.Checked = False And ChkArticulos.Enabled = False And ChkM3.Checked = False Then '--BULTOS
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso = Val(GrdDetalleVenta("Sub Neto", 0).Value)
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol = Val(GrdDetalleVenta("Sub Neto", 1).Value)
                ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Val(GrdDetalleVenta("Sub Neto", 2).Value)
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

            ObjIMPRESIONFACT_BOL.xDestino = TxtCiudadDestino.Text
            ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL = Me.TxtSerie.Text & "-" & Me.TxtNroDoc.Text
            ObjIMPRESIONFACT_BOL.xRazonSocial = Me.TxtNomCliente.Text.Trim
            ObjIMPRESIONFACT_BOL.xDireccionRemitente = Me.CboDireccion.Text.Trim
            ObjIMPRESIONFACT_BOL.xRuc = TxtNroDocCliente.Text
            ObjIMPRESIONFACT_BOL.xConsignado = ObjVentaCargaContado.v_NOMBRES_DESTINATARIO 'GrdNConsignado("Nombres", 0).Value 'Me.TxtNombConsignado.Text NConsignado
            'ObjIMPRESIONFACT_BOL.xDireccionConsignado = Me.TxtDirecConsignado.Text'verificar
            ObjIMPRESIONFACT_BOL.xDireccionConsignado = Me.CboDireccion2.Text & IIf(Me.CboTipoEntrega.SelectedValue = TipoEntrega.Agencia, " " & Me.CboAgenciaDest.Text, "")
            ObjIMPRESIONFACT_BOL.xfecha_factura = Me.TxtFecha.Text
            ObjIMPRESIONFACT_BOL.xTotalPeso = ObjVentaCargaContado.v_TOTAL_PESO
            ObjIMPRESIONFACT_BOL.xTotalVolumen = ObjVentaCargaContado.v_TOTAL_VOLUMEN
            ObjIMPRESIONFACT_BOL.xTotalSobres = 0
            ObjIMPRESIONFACT_BOL.xNroRef = Me.TxtSerie.Text & "-" & Me.TxtNroDoc.Text
            ObjIMPRESIONFACT_BOL.xMemo = Me.txtDescDescto.Text
            ObjIMPRESIONFACT_BOL.xMonto_Sub_Total = Me.TxtSubtotal.Text
            ObjIMPRESIONFACT_BOL.xMonto_Impuesto = TxtImpuesto.Text
            ObjIMPRESIONFACT_BOL.xTotal_Costo = ObjVentaCargaContado.v_TOTAL_COSTO
            ObjIMPRESIONFACT_BOL.xDescuento = IIf(TxtDescuento.Text <> "", TxtDescuento.Text, "")
            ObjIMPRESIONFACT_BOL.xAgenciaDestino = IIf(CboAgenciaDest.Text <> "", CboAgenciaDest.Text, "")
            ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA = CboTipoEntrega.Text

            If varIdCondicion = 2 Or varIdCondicion = 5 Then '====> (2=TARGETA, 5=CORTESIA)
                Me.Cursor = Cursors.AppStarting
                asignar_documentos_clientes()

                If ObjVentaCargaContado.ActualizarVenta = True Then
                    iCliente = ObjVentaCargaContado.v_IDPERSONA
                    Me.Cursor = Cursors.Default
                    ObjIMPRESIONFACT_BOL.xIdFactura = ObjVentaCargaContado.v_IDFACTURA.ToString
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

                            For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                                If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                                    If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
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
                                                 Factor_,
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
                                If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                                    If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
                                        objGuia_Envio_Articulo.iIDARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(5).Value.ToString)
                                        objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString)
                                        objGuia_Envio_Articulo.iPESO = Int(GrdDetalleVenta.Rows(ii).Cells(3).Value.ToString)
                                        objGuia_Envio_Articulo.iPRECIO_X_ARTICULO = Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii).Cells(1).Value.ToString)
                                        objGuia_Envio_Articulo.fnINSTUPD_FACBOL_ARTICULOS()
                                    End If
                                End If
                            Next
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    '-----------------------------------------------------------------
                    'INSERCION DE DOCUMENTOS DEL CLIENTE' 
                    '-----------------------------------------------------------------   
                    flat = True
                    Dim i As Integer = 0
                    Dim serie_NroDoc() As String
                    Dim iContador As Integer = 0
                    objGuiaEnvio.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
                    objGuiaEnvio.V_IDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                    For i = 0 To Me.GrdDocumentosCliente.Rows().Count() - 1
                        Try
                            If IsDBNull(GrdDocumentosCliente.Rows(i).Cells("cargo")) = False Then
                                If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells("cargo").Value) Then
                                    serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells("cargo").Value.ToString, "-")
                                    If serie_NroDoc.Length > 1 Then
                                        objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                        objGuiaEnvio.iNro_Docu = serie_NroDoc(1)

                                        If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                            If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
                                                objGuiaEnvio.iControl_Documentos = iContador
                                                If objGuiaEnvio.fnSP_INSUPD_DOCUMENTOS_FACBOL_I() = True Then
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
                            If IsDBNull(GrdDocumentosCliente.Rows(i).Cells("seguro")) = False Then
                                'If GrdDocumentosCliente.Rows(i).Cells(3).Value.ToString <> "" Then
                                If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells("seguro").Value) Then
                                    serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells("seguro").Value.ToString, "-")
                                    If serie_NroDoc.Length > 1 Then
                                        objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                        objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                                        If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                            If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
                                                If objGuiaEnvio.fnSP_INSUPD_DOCUMENTOS_FACBOL_I() = True Then
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
                    '**************************************************************************************************** 

                    limpiar_documentos_cliente()

                    Dim dt As DataTable = ObjVentaCargaContado.dtVenta
                    ObjVentaCargaContado.v_IDPERSONA = IIf(IsDBNull(dt.Rows(0).Item(0)), "-1", dt.Rows(0).Item(0))
                    iID_Persona = IIf(IsDBNull(dt.Rows(0).Item(0)), "-1", dt.Rows(0).Item(0))
                    ObjVentaCargaContado.v_IDDIREECION_ORIGEN = IIf(IsDBNull(dt.Rows(0).Item(1)), "-1", dt.Rows(0).Item(1))
                    IdDireccionOrigen = IIf(IsDBNull(dt.Rows(0).Item(1)), "-1", dt.Rows(0).Item(1))
                    ObjVentaCargaContado.v_IDPERSONA_ORIGEN = IIf(IsDBNull(dt.Rows(0).Item(2)), "-1", dt.Rows(0).Item(2))
                    idcontacto = IIf(IsDBNull(dt.Rows(0).Item(2)), "-1", dt.Rows(0).Item(2))
                    ObjVentaCargaContado.v_IDCONTACTO_DESTINO = IIf(IsDBNull(dt.Rows(0).Item(3)), "-1", dt.Rows(0).Item(3))
                    iIDConsignado = IIf(IsDBNull(dt.Rows(0).Item(3)), "-1", dt.Rows(0).Item(3))
                    ObjVentaCargaContado.v_IDDIREECION_DESTINO = IIf(IsDBNull(dt.Rows(0).Item(4)), "-1", dt.Rows(0).Item(4))
                    idDireConsignado = IIf(IsDBNull(dt.Rows(0).Item(4)), "-1", dt.Rows(0).Item(4))
                Else
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("No se Registró La Actualizacion", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            ElseIf varIdCondicion = 1 Then '-> 1 ===> EFECTIVO
                If bControlFiscalizacion = False Then
                    If ObjVentaCargaContado.ActualizarVenta = True Then
                        'Refres = True
                        'objControlFacturasBol.iControl = 1
                        'Me.fnBuscarFacturas() '--Refres al GridFACBOL
                        '--------
                        ObjPagosSoles.v_idfactura_contado = ObjVentaCargaContado.v_IDFACTURA
                        ObjPagosDolares.v_idfactura_contado = ObjVentaCargaContado.v_IDFACTURA
                        ObjIMPRESIONFACT_BOL.xIdFactura = ObjVentaCargaContado.v_IDFACTURA.ToString
                        '-------------------------------------------
                        'INSERCION VOLUMETRICO
                        '-------------------------------------------
                        Try
                            If ChkM3.Checked = True Then
                                Dim obj As New dtoVentaCargaContado
                                Dim ii As Integer = 0
                                objGuia_Envio_Articulo.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
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
                                                     ObjIMPRESIONFACT_BOL.xIdFactura,
                                                     GrdDetalleVenta.Rows(ii).Cells("Tipo").Value,
                                                     GrdDetalleVenta.Rows(ii).Cells("Bulto").Value,
                                                     GrdDetalleVenta.Rows(ii).Cells("Altura").Value,
                                                     GrdDetalleVenta.Rows(ii).Cells("Ancho").Value,
                                                     GrdDetalleVenta.Rows(ii).Cells("Largo").Value,
                                                     GrdDetalleVenta.Rows(ii).Cells("Peso Kg").Value,
                                                     Factor_,
                                                     GrdDetalleVenta.Rows(ii).Cells("Costo").Value)
                                        End If
                                    End If
                                Next
                            End If
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try


                        '-------------------------------------------
                        'INSERCION DE ARTICULOS
                        '-------------------------------------------                          
                        Try
                            If ChkArticulos.Checked = True Then
                                Dim ii As Integer = 0
                                objGuia_Envio_Articulo.iCONTROL = 2
                                objGuia_Envio_Articulo.iIDGUIAS_ENVIO_ARTICULOS = 0
                                objGuia_Envio_Articulo.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura '1200922
                                objGuia_Envio_Articulo.iIGV = dtoUSUARIOS.iIGV
                                objGuia_Envio_Articulo.iDESCUENTO = 0
                                objGuia_Envio_Articulo.iPENALIDAD = 0
                                objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
                                objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                                objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol
                                'v_CANTIDAD_X_ARTICULO
                                objGuia_Envio_Articulo.iIDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                                objGuia_Envio_Articulo.iIDESTADO_REGISTRO = 18
                                For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                                    If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                                        If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
                                            objGuia_Envio_Articulo.iIDARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(5).Value.ToString)
                                            Dim iArticuloGuiaEnvio As Integer = ObjVentaCargaContado.fnGetIDGuiaEnvio(ObjVentaCargaContado.v_IDFACTURA, objGuia_Envio_Articulo.iIDARTICULOS)
                                            objGuia_Envio_Articulo.iIDGUIAS_ENVIO_ARTICULOS = iArticuloGuiaEnvio
                                            objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString)
                                            objGuia_Envio_Articulo.iPESO = Int(GrdDetalleVenta.Rows(ii).Cells(3).Value.ToString)
                                            objGuia_Envio_Articulo.iPRECIO_X_ARTICULO = Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii).Cells(1).Value.ToString)
                                            objGuia_Envio_Articulo.fnINSTUPD_FACBOL_ARTICULOS() 'update 2
                                        End If
                                    End If
                                Next
                            End If
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try


                        '-----------------------------------------------------------------
                        'INSERCION DE DOCUMENTOS DEL CLIENTE' 
                        '-----------------------------------------------------------------   
                        flat = True
                        Dim i As Integer = 0
                        Dim serie_NroDoc() As String
                        Dim iContador As Integer = 0
                        objGuiaEnvio.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
                        objGuiaEnvio.V_IDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                        For i = 0 To Me.GrdDocumentosCliente.Rows().Count() - 1
                            Try
                                If IsDBNull(GrdDocumentosCliente.Rows(i).Cells("cargo")) = False Then
                                    If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells("cargo").Value) Then
                                        serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells("cargo").Value.ToString, "-")
                                        If serie_NroDoc.Length > 1 Then
                                            objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                            objGuiaEnvio.iNro_Docu = serie_NroDoc(1)

                                            If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                                If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
                                                    objGuiaEnvio.iControl_Documentos = iContador
                                                    If objGuiaEnvio.fnSP_INSUPD_DOCUMENTOS_FACBOL_I() = True Then
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
                                If IsDBNull(GrdDocumentosCliente.Rows(i).Cells("seguro")) = False Then
                                    'If GrdDocumentosCliente.Rows(i).Cells(3).Value.ToString <> "" Then
                                    If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells("seguro").Value) Then
                                        serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells("seguro").Value.ToString, "-")
                                        If serie_NroDoc.Length > 1 Then
                                            objGuiaEnvio.iNro_Serie = serie_NroDoc(0)
                                            objGuiaEnvio.iNro_Docu = serie_NroDoc(1)
                                            If objGuiaEnvio.iNro_Serie.ToString.Length > 0 And objGuiaEnvio.iNro_Docu.ToString.Length > 0 Then
                                                If Int(objGuiaEnvio.iNro_Serie.ToString) >= 0 And Int(objGuiaEnvio.iNro_Docu.ToString) > 0 Then
                                                    If objGuiaEnvio.fnSP_INSUPD_DOCUMENTOS_FACBOL_I() = True Then
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
                        '****************************************************************************************************                        
                        limpiar_documentos_cliente()
                        Dim dt As DataTable = ObjVentaCargaContado.dtVenta
                        ObjVentaCargaContado.v_IDPERSONA = IIf(IsDBNull(dt.Rows(0).Item(0)), "-1", dt.Rows(0).Item(0))
                        iID_Persona = IIf(IsDBNull(dt.Rows(0).Item(0)), "-1", dt.Rows(0).Item(0))
                        ObjVentaCargaContado.v_IDDIREECION_ORIGEN = IIf(IsDBNull(dt.Rows(0).Item(1)), "-1", dt.Rows(0).Item(1))
                        IdDireccionOrigen = IIf(IsDBNull(dt.Rows(0).Item(1)), "-1", dt.Rows(0).Item(1))
                        ObjVentaCargaContado.v_IDPERSONA_ORIGEN = IIf(IsDBNull(dt.Rows(0).Item(2)), "-1", dt.Rows(0).Item(2))
                        idcontacto = IIf(IsDBNull(dt.Rows(0).Item(2)), "-1", dt.Rows(0).Item(2))
                        ObjVentaCargaContado.v_IDCONTACTO_DESTINO = IIf(IsDBNull(dt.Rows(0).Item(3)), "-1", dt.Rows(0).Item(3))
                        iIDConsignado = IIf(IsDBNull(dt.Rows(0).Item(3)), "-1", dt.Rows(0).Item(3))
                        ObjVentaCargaContado.v_IDDIREECION_DESTINO = IIf(IsDBNull(dt.Rows(0).Item(4)), "-1", dt.Rows(0).Item(4))
                        idDireConsignado = IIf(IsDBNull(dt.Rows(0).Item(4)), "-1", dt.Rows(0).Item(4))

                    Else
                        lblTotalPagado.Visible = False
                        lblTotalVenta.Visible = False
                        lblVuelto.Visible = False
                        txtTotalPagado.Visible = False
                        txtTotalVenta.Visible = False
                        txtVuelto.Visible = False
                        MessageBox.Show("La Venta no se Registró", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    asignar_documentos_clientes()
                    '                   
                    If ObjVentaCargaContado.ActualizarVenta() = True Then
                        iCliente = ObjVentaCargaContado.v_IDPERSONA

                        'ConfiMensajeriaDlg = New FrmConfiMensajeria
                        ''ConfiMensajeriaDlg.ShowDialog()
                        'Acceso.Asignar(ConfiMensajeriaDlg, Me.hnd)
                        'If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                        '    ConfiMensajeriaDlg.ShowDialog()
                        'Else
                        '    MessageBox.Show(G_Mje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'End If
                        'ConfiMensajeriaDlg = Nothing

                        TipoComprobante = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                        ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA = CboTipoEntrega.Text   ' 27/04/2007
                        ObjIMPRESIONFACT_BOL.xIdFactura = ObjVentaCargaContado.v_IDFACTURA.ToString
                        Try
                            If ChkArticulos.Enabled = True Then
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
                                    If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                                        If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" Then
                                            objGuia_Envio_Articulo.iIDARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(5).Value.ToString)
                                            objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString)
                                            objGuia_Envio_Articulo.iPESO = Int(GrdDetalleVenta.Rows(ii).Cells(3).Value.ToString)
                                            objGuia_Envio_Articulo.iPRECIO_X_ARTICULO = Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii).Cells(1).Value.ToString)
                                            objGuia_Envio_Articulo.fnINSTUPD_FACBOL_ARTICULOS()
                                        End If
                                    End If
                                Next
                            End If
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        flat = True
                        Dim i As Integer = 0
                        Dim serie_NroDoc() As String
                        objGuiaEnvio.iControl_Documentos = 1
                        objGuiaEnvio.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
                        objGuiaEnvio.V_IDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE

                        Dim iContador As Integer = 0

                        '************************GRIDVIEW DOCUMENTOS**************************************************************
                        If objGuiaEnvio.iCONTROL = 0 Or objGuiaEnvio.iCONTROL = 1 Then
                            For i = 0 To Me.GrdDocumentosCliente.Rows().Count() - 2
                                Try
                                    If IsDBNull(GrdDocumentosCliente.Rows(i).Cells(2)) = False Then
                                        'If GrdDocumentosCliente.Rows(i).Cells(2).Value.ToString <> "" Then
                                        If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells(2).Value) Then
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
                                    If IsDBNull(GrdDocumentosCliente.Rows(i).Cells(3)) = False Then
                                        'If GrdDocumentosCliente.Rows(i).Cells(3).Value.ToString <> "" Then
                                        If Not IsNothing(GrdDocumentosCliente.Rows(i).Cells(3).Value) Then
                                            serie_NroDoc = Split(GrdDocumentosCliente.Rows(i).Cells(3).Value.ToString, "-")
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

                        TipoComprobante = 2
                        fnNUEVO()
                        limpiar_documentos_cliente()
                        iOficinaDestino = 0
                        iOficinaOrigen = 0
                        flat = True
                    End If
                End If
            End If
            bOrigenDiferente = False
        Catch ex As Exception
            flat = False
            Throw New Exception(ex.Message)
        End Try
        Return flat
    End Function

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

    Public Function fnImprimirEtiquetas() As Boolean 'O
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

            If j <= 0 Then j = 1
            '''''''''''''''
            'hlamas 26-08-2015
            'agregar CARGO para envios con devolucion de cargo
            Dim strCargo As String, strFecha As String
            strCargo = IIf(Me.rbtCargoSi.Checked, "CARGO", "")
            While i <= ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows.Count - 1
                ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows(i)(0).ToString
                'While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
                'ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.Cur_CODIGOBARRAS.Fields.Item(0).Value
                prn.EscribeLinea("^XA")
                prn.EscribeLinea("^PW400")
                prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD " & ObjCODIGOBARRA.NroDOC & "          " & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & "^FS")
                prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.clinte & "^FS")
                prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & ObjCODIGOBARRA.CodigoBarra & "^FS")
                prn.EscribeLinea("^FT17,141^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
                prn.EscribeLinea("^FT96,142^A0N,39,45^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")
                'hlamas 26-08-2015
                'prn.EscribeLinea("^FT305,188^AAN,18,10^FH\^FDTEPSAC^FS")
                'prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & ObjCODIGOBARRA.Fecha & "^FS")

                strFecha = ObjCODIGOBARRA.Fecha.Trim & " " & HoraActual.Trim
                prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & strFecha & "^FS")
                prn.EscribeLinea("^FT255,188^AAN,18,10^FH\^FDTEPSAC^FS")
                'prn.EscribeLinea("^FT345,188^AAN,18,10^FH\^FD" & strCargo & "^FS")
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

            If j <= 0 Then j = 1

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

            If j <= 0 Then j = 1
            '
            'hlamas 26-08-2015
            'agregar CARGO para envios con devolucion de cargo
            Dim strCargo As String, strFecha As String
            strCargo = IIf(Me.rbtCargoSi.Checked, "CARGO", "")
            While I <= ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows.Count - 1
                ObjCODIGOBARRA.CodigoBarra = ObjVentaCargaContado.dv_Cur_CODIGOBARRAS.Table.Rows(I)(0).ToString
                prn.EscribeLinea("N")
                prn.EscribeLinea("N")
                prn.EscribeLinea("A30,14,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
                prn.EscribeLinea("A30,47,0,4,1,1,N,""" & ObjCODIGOBARRA.NroDOC & " -" & j.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
                prn.EscribeLinea("A317,47,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
                prn.EscribeLinea("A30,110,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-  """)

                'hlamas 26-08-2015
                'prn.EscribeLinea("A30,163,0,1,1,1,N,""" & ObjCODIGOBARRA.Fecha & """")
                'prn.EscribeLinea("A321,163,0,1,1,1,N,""TEPSAC""")

                strFecha = ObjCODIGOBARRA.Fecha.Trim & " " & HoraActual.Trim
                prn.EscribeLinea("A30,163,0,1,1,1,N,""" & strFecha & """")
                prn.EscribeLinea("A230,163,0,1,1,1,N,""TEPSAC""")
                prn.EscribeLinea("A300,163,0,2,1,1,N,""" & strCargo & """")

                'hlamas 26-08-2015
                'prn.EscribeLinea("A205,163,0,1,1,1,N,""" & HoraActual & """")

                prn.EscribeLinea("A89,94,0,4,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
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
            'Dim fecha_Systema As String() = Split(dtoUSUARIOS.m_sFecha, "/")
            Dim fecha_Systema As String()
            fecha_Systema = Split(FechaServidor.ToString.Substring(0, 10), "/")
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

                Dim sConsignado As String = ObjIMPRESIONFACT_BOL.xConsignado.Trim.Replace(";", ",")
                sConsignado = sConsignado.Substring(0, sConsignado.Trim.Length - 1)

                If Me.CboProducto.SelectedValue <> -100 Then
                    iLong = IIf(iTamaño = 0, 36, iTamaño)
                    y = iLong * pagina + 4
                    y += 1
                    i += 1
                    If es_carga_asegurada Then
                        obj.EscribirLinea(y + 1, 48, ObjIMPRESIONFACT_BOL.xAgenciaDestino & v_ca)
                    Else
                        If ObjIMPRESIONFACT_BOL.xAgenciaDestino.ToString.Trim.Length > 20 Then
                            obj.EscribirLinea(y + 1, 48, ObjIMPRESIONFACT_BOL.xAgenciaDestino.ToString.Trim.Substring(0, 20))
                        Else
                            obj.EscribirLinea(y + 1, 48, ObjIMPRESIONFACT_BOL.xAgenciaDestino)
                        End If

                        'obj.EscribirLinea(y + 1, 48, ObjIMPRESIONFACT_BOL.xAgenciaDestino)
                    End If

                    obj.EscribirLinea(y, 48, ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL)
                    obj.EscribirLinea(y + 2, 53, fnGetHora())

                    obj.EscribirLinea(y + 4, 8, dia)
                    obj.EscribirLinea(y + 4, 23, Mes)
                    obj.EscribirLinea(y + 4, 42, Anio)

                    obj.EscribirLinea(y + 5, 13, ObjIMPRESIONFACT_BOL.xRazonSocial)
                    obj.EscribirLinea(y + 6, 13, ObjIMPRESIONFACT_BOL.xDireccionRemitente)
                    obj.EscribirLinea(y + 7, 13, ObjIMPRESIONFACT_BOL.xOrigen)
                    obj.EscribirLinea(y + 8, 13, sConsignado)
                    obj.EscribirLinea(y + 9, 13, ObjIMPRESIONFACT_BOL.xDireccionConsignado)

                    obj.EscribirLinea(y + 5, 66, ObjIMPRESIONFACT_BOL.xRuc)
                    obj.EscribirLinea(y + 7, 66, ObjIMPRESIONFACT_BOL.xDestino)

                    obj.EscribirLinea(y + 5, 105, ObjIMPRESIONFACT_BOL.xNroRef)
                    obj.EscribirLinea(y + 7, 105, ObjIMPRESIONFACT_BOL.xFormaPago)
                    obj.EscribirLinea(y + 8, 105, ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA)

                    'hlamas 21-01-2016
                    If ChkArticulos.Checked Then
                        Dim intFilaArticulo As Integer = 12
                        For Each row As DataGridViewRow In Me.GrdDetalleVenta.Rows
                            If Val(row.Cells("cantidad").Value) > 0 Then
                                obj.EscribirLinea(y + intFilaArticulo, 13, row.Cells("cantidad").Value)
                                obj.EscribirLinea(y + intFilaArticulo, 23, row.Cells("Artículo").Value)
                                obj.EscribirLinea(y + intFilaArticulo, 92, row.Cells("peso").Value)
                                intFilaArticulo += 1
                            End If
                        Next
                    Else
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
                        'If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Impuesto) = 0 Then
                        '    obj.EscribirLinea(y + 14, 13, ObjIMPRESIONFACT_BOL.xCantidad_Sobre)
                        '    obj.EscribirLinea(y + 14, 23, "SOBRES")
                        'End If
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

                    obj.EscribirLinea(y + 21, 85, "S/")
                    obj.EscribirLinea(y + 22, 85, "S/")
                    obj.EscribirLinea(y + 23, 85, "S/")

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

                    obj.EscribirLinea(y, 66, Me.CboCiudadOrigen.Text)
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

                    obj.EscribirLinea(y + 5, 16, sConsignado)
                    'obj.EscribirLinea(y + 5, 108, TxtNroDocConsignado.Text.Trim) NConsignado
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

                        If Val(Me.txtMontoBase.Text) > 0 Then
                            obj.EscribirLinea(y + 14, 23, "BASE")
                            obj.EscribirLinea(y + 14, 120, Format(CDbl(Me.txtMontoBase.Text), "###,###,###0.00").PadLeft(10, " "))
                        End If
                    ElseIf Me.ChkArticulos.Checked Then
                        If Val(Me.txtTotalSobre.Text) > 0 Then
                            obj.EscribirLinea(y + 13, 23, "SOBRES")
                            obj.EscribirLinea(y + 13, 90, Me.txtCantidadSobres.Text)
                            obj.EscribirLinea(y + 13, 120, Format(CDbl(Me.txtTotalSobre.Text), "###,###,###0.00").PadLeft(10, " "))
                        End If

                        If Val(Me.txtMontoBase.Text) > 0 Then
                            obj.EscribirLinea(y + 14, 23, "BASE")
                            obj.EscribirLinea(y + 14, 120, Format(CDbl(Me.txtMontoBase.Text), "###,###,###0.00").PadLeft(10, " "))
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

    Public Function ImprimirBoleta() As Boolean
        Dim obj As New Imprimir
        Dim iSubTotal As Double, iImpuesto As Double, iTotal As Double
        Dim blnCortesia As Boolean
        Try
            Dim HoraSistema As String = fnGetHora()
            Dim GLOSA2 As String = ""
            Dim PESO As String = ""
            Dim PARCIAL As String = ""
            Dim CANTIDAD As String = ""

            'Dim fecha_Systema As String() = Split(dtoUSUARIOS.m_sFecha, "/")
            Dim fecha_Systema As String()
            fecha_Systema = Split(FechaServidor.ToString.Substring(0, 10), "/")
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
            ''ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre = Val(dtGridViewBultos(7, 2).Value)
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

                blnCortesia = False
                If Me.CboFormaPago.SelectedIndex = 2 Then 'Me.grbPromocion.Visible And Me.lblPromocionDescuento.Text = 100 Then
                    blnCortesia = True
                End If

                'hlamas 02-02-2016
                'If Me.CboProducto.SelectedValue <> -100 Then
                If dtoUSUARIOS.FormatoBoleta = "A" Then
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
                    'hlamas 21-01-2016
                    If ChkArticulos.Checked Then
                        Dim intFilaArticulo As Integer = 7
                        For Each row As DataGridViewRow In Me.GrdDetalleVenta.Rows
                            If row.Cells(0).Value <> "ENTREGA" Then
                                obj.EscribirLinea(y + intFilaArticulo, 13, row.Cells("cantidad").Value)
                                obj.EscribirLinea(y + intFilaArticulo, 23, row.Cells("Artículo").Value)
                                obj.EscribirLinea(y + intFilaArticulo, 92, row.Cells("peso").Value)
                                intFilaArticulo += 1
                            End If
                        Next
                    End If
                    If Not ChkArticulos.Checked Then
                        obj.EscribirLinea(y + 7, 16, "BULTOS   " & Val(Val(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + Val(ObjIMPRESIONFACT_BOL.xCantidad_Vol)).ToString)
                        obj.EscribirLinea(y + 7, 46, ObjIMPRESIONFACT_BOL.xTotalPeso)
                        obj.EscribirLinea(y + 7, 56, ObjIMPRESIONFACT_BOL.xTotalVolumen)
                    End If
                    If es_carga_asegurada Then
                        obj.EscribirLinea(y + 7, 67, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo - iTotal), "###,###,###.00"))
                    Else
                        obj.EscribirLinea(y + 7, 67, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                    End If

                    If Not ChkArticulos.Checked Then
                        obj.EscribirLinea(y + 7, 84, "BULTOS   " & Val(Val(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + Val(ObjIMPRESIONFACT_BOL.xCantidad_Vol)).ToString)
                        obj.EscribirLinea(y + 7, 105, ObjIMPRESIONFACT_BOL.xTotalVolumen)
                        obj.EscribirLinea(y + 7, 112, ObjIMPRESIONFACT_BOL.xTotalPeso)
                    End If
                    If es_carga_asegurada Then
                        obj.EscribirLinea(y + 7, 121, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo - iTotal), "###,###,###.00"))
                    Else
                        obj.EscribirLinea(y + 7, 121, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                    End If

                    If Not ChkArticulos.Checked Then
                        obj.EscribirLinea(y + 8, 16, "SOBRES   " & Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString)
                        obj.EscribirLinea(y + 8, 84, "SOBRES   " & Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString)
                    End If

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
                    ilong = IIf(iTamaño = 0, 24, iTamaño)
                    y = ilong * pagina + 7
                    y += 1
                    i += 1

                    blnCortesia = False
                    If Me.CboFormaPago.SelectedIndex = 2 Then 'Me.grbPromocion.Visible And Me.lblPromocionDescuento.Text = 100 Then
                        blnCortesia = True
                    End If

                    obj.EscribirLinea(0, 17, CboProducto.Text) 'cambio

                    obj.EscribirLinea(y - 1, 6, dtoUSUARIOS.m_iNombreUnidadAgencia)
                    obj.EscribirLinea(y + 1, 6, ObjIMPRESIONFACT_BOL.xfecha_factura)
                    obj.EscribirLinea(y + 2, 6, ObjIMPRESIONFACT_BOL.xRazonSocial)
                    obj.EscribirLinea(y + 3, 6, sConsignado)
                    obj.EscribirLinea(y + 4, 6, ObjIMPRESIONFACT_BOL.xDireccionConsignado)
                    obj.EscribirLinea(y - 1, 30, ObjIMPRESIONFACT_BOL.xDestino)

                    If es_carga_asegurada Then
                        obj.EscribirLinea(0, 30, v_ca)
                    End If

                    obj.EscribirLinea(y + 1, 30, HoraSistema)
                    obj.EscribirLinea(y + 1, 55, CboFormaPago.Text)
                    obj.EscribirLinea(y - 1, 65, ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA)

                    'y+7=12
                    'hlamas 21-01-2016
                    If ChkArticulos.Checked Then
                        Dim intFilaArticulo As Integer = 7
                        For Each row As DataGridViewRow In Me.GrdDetalleVenta.Rows
                            If row.Cells(0).Value <> "ENTREGA" Then
                                If Val(row.Cells("cantidad").Value) > 0 Then
                                    obj.EscribirLinea(y + intFilaArticulo, 16, row.Cells("cantidad").Value)
                                    obj.EscribirLinea(y + intFilaArticulo, 23, row.Cells("Artículo").Value)
                                    obj.EscribirLinea(y + intFilaArticulo, 46, row.Cells("peso").Value)
                                    intFilaArticulo += 1
                                End If
                            End If
                        Next
                    End If

                    If Not ChkArticulos.Checked Then
                        obj.EscribirLinea(y + 7, 16, "BULTOS   " & Val(Val(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + Val(ObjIMPRESIONFACT_BOL.xCantidad_Vol)).ToString)
                        obj.EscribirLinea(y + 7, 46, ObjIMPRESIONFACT_BOL.xTotalPeso)
                        obj.EscribirLinea(y + 7, 56, ObjIMPRESIONFACT_BOL.xTotalVolumen)
                    End If

                    If es_carga_asegurada Then
                        obj.EscribirLinea(y + 7, 67, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo - iTotal), "###,###,###.00"))
                    Else
                        obj.EscribirLinea(y + 7, 67, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                    End If

                    If Not ChkArticulos.Checked Then
                        obj.EscribirLinea(y + 7, 84, "BULTOS   " & Val(Val(ObjIMPRESIONFACT_BOL.xCantidad_Peso) + Val(ObjIMPRESIONFACT_BOL.xCantidad_Vol)).ToString)
                        obj.EscribirLinea(y + 7, 112, ObjIMPRESIONFACT_BOL.xTotalVolumen)
                        obj.EscribirLinea(y + 7, 120, ObjIMPRESIONFACT_BOL.xTotalPeso)
                    End If

                    If es_carga_asegurada Then
                        obj.EscribirLinea(y + 7, 127, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo - iTotal), "###,###,###.00"))
                    Else
                        obj.EscribirLinea(y + 7, 127, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                    End If

                    If Not ChkArticulos.Checked Then
                        If Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre) > 0 Then
                            obj.EscribirLinea(y + 8, 16, "SOBRES   " & Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString)
                            obj.EscribirLinea(y + 8, 84, "SOBRES   " & Val(ObjIMPRESIONFACT_BOL.xCantidad_Sobre).ToString)
                        End If
                    End If

                    If Not blnCortesia Then
                        obj.EscribirLinea(y + 13, 67, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                        obj.EscribirLinea(y + 13, 127, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo), "###,###,###.00"))
                    Else
                        obj.EscribirLinea(y + 13, 67, "0.00")
                        obj.EscribirLinea(y + 13, 127, "0.00")
                    End If

                    obj.EscribirLinea(0, 10, dtoUSUARIOS.iLOGIN)


                    If blnCortesia Then
                        obj.EscribirLinea(0, 90, "CORTESIA")
                        obj.EscribirLinea(0, 81, "CORTESIA")
                    Else
                        obj.EscribirLinea(0, 90, dtoUSUARIOS.iLOGIN)
                    End If

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

                    obj.EscribirLinea(5, 52, ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL)
                    obj.EscribirLinea(y - 1, 92, dtoUSUARIOS.m_iNombreUnidadAgencia)
                    obj.EscribirLinea(y + 1, 90, ObjIMPRESIONFACT_BOL.xfecha_factura)
                    obj.EscribirLinea(y + 2, 92, ObjIMPRESIONFACT_BOL.xRazonSocial)
                    obj.EscribirLinea(y + 3, 92, sConsignado)
                    obj.EscribirLinea(y + 4, 92, ObjIMPRESIONFACT_BOL.xDireccionConsignado)
                    obj.EscribirLinea(y - 1, 109, ObjIMPRESIONFACT_BOL.xDestino)
                    obj.EscribirLinea(y + 1, 110, HoraSistema)

                    obj.EscribirLinea(y + 1, 127, Me.CboFormaPago.Text)
                    obj.EscribirLinea(y, 130, ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA)

                    obj.EscribirLinea(0, 0, ObjIMPRESIONFACT_BOL.xIdFactura)
                    obj.EscribirLinea(5, 30, ObjIMPRESIONFACT_BOL.xAgenciaDestino)
                    obj.EscribirLinea(3, 83, ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL)
                    obj.EscribirLinea(0, 83, ObjIMPRESIONFACT_BOL.xIdFactura)
                    obj.EscribirLinea(5, 83, ObjIMPRESIONFACT_BOL.xAgenciaDestino)
                    obj.EscribirLinea(0, 83, CboProducto.Text) 'cambio

                    If blnCortesia Then
                        obj.EscribirLinea(y + 9, 30, "SERVICIOS PRESTADOS A TITULO GRATUITO")
                        obj.EscribirLinea(y + 11, 30, "(SON: CERO y 0/100 SOLES)")
                    End If

                    'ilong = IIf(iTamaño = 0, 36, iTamaño)
                    'y = ilong * pagina + 8
                    'y += 1
                    'i += 1

                    'obj.EscribirLinea(y, 8, dia & " DE " & MonthName(Mes).ToString.ToUpper)
                    'obj.EscribirLinea(y, 33, Anio)

                    'obj.EscribirLinea(y, 66, Me.CboCiudadOrigen.Text)
                    'obj.EscribirLinea(y, 108, ObjIMPRESIONFACT_BOL.xDestino)

                    'If Me.CboTipoTarifa.SelectedValue = 1 Then
                    '    obj.EscribirLinea(y + 2, 21, "X")
                    'ElseIf Me.CboTipoTarifa.SelectedValue = 2 Then
                    '    obj.EscribirLinea(y + 2, 31, "X")
                    'End If

                    'If Me.CboTipoEntrega.SelectedValue = TipoEntrega.Domicilio Then
                    '    obj.EscribirLinea(y + 2, 67, "X")
                    'Else
                    '    obj.EscribirLinea(y + 2, 77, "X")
                    'End If

                    'obj.EscribirLinea(y + 2, 108, ObjIMPRESIONFACT_BOL.TelefonoCliente(iCliente))

                    'obj.EscribirLinea(y + 3, 16, ObjIMPRESIONFACT_BOL.xRazonSocial)
                    'obj.EscribirLinea(y + 3, 108, ObjIMPRESIONFACT_BOL.xRuc)
                    'obj.EscribirLinea(y + 4, 16, ObjIMPRESIONFACT_BOL.xDireccionRemitente)

                    'obj.EscribirLinea(y + 5, 16, sConsignado)
                    ''obj.EscribirLinea(y + 5, 108, TxtNroDocConsignado.Text.Trim) NConsignado
                    'obj.EscribirLinea(y + 5, 108, ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO) 'GrdNConsignado("Nº Documento", 0).Value
                    'obj.EscribirLinea(y + 6, 16, ObjIMPRESIONFACT_BOL.xDireccionConsignado)
                    '' obj.EscribirLinea(y + 7, 108, TxtTelfConsignado.Text.Trim)

                    'If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso) = 0 Then
                    '    obj.EscribirLinea(y + 11, 23, "BULTOS")
                    '    obj.EscribirLinea(y + 11, 90, ObjIMPRESIONFACT_BOL.xCantidad_Peso)
                    '    obj.EscribirLinea(y + 11, 102, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotalPeso), "###,###,###0.00").PadLeft(8, " "))
                    '    obj.EscribirLinea(y + 11, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Peso), "###,###,###0.00").PadLeft(10, " "))
                    'End If
                    'If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol) = 0 Then
                    '    obj.EscribirLinea(y + 12, 23, "BULTOS (V.)")
                    '    obj.EscribirLinea(y + 12, 90, ObjIMPRESIONFACT_BOL.xCantidad_Vol)
                    '    obj.EscribirLinea(y + 12, 102, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotalVolumen), "###,###,###0.00").PadLeft(8, " "))
                    '    obj.EscribirLinea(y + 12, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Vol), "###,###,###0.00").PadLeft(10, " "))
                    'End If
                    'If Not CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre) = 0 Then
                    '    obj.EscribirLinea(y + 13, 23, "SOBRES")
                    '    obj.EscribirLinea(y + 13, 90, ObjIMPRESIONFACT_BOL.xCantidad_Sobre)
                    '    obj.EscribirLinea(y + 13, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Sub_Total_Sobre), "###,###,###0.00").PadLeft(10, " "))
                    'End If

                    'If Not Me.ChkArticulos.Checked And Not Me.ChkM3.Checked Then
                    '    If Val(GrdDetalleVenta("Sub Neto", 3).Value) > 0 Then
                    '        obj.EscribirLinea(y + 14, 23, "BASE")
                    '        obj.EscribirLinea(y + 14, 120, Format(CDbl(GrdDetalleVenta("Sub Neto", 3).Value), "###,###,###0.00").PadLeft(10, " "))
                    '    End If
                    'ElseIf Me.ChkM3.Checked Then
                    '    If Val(Me.txtTotalSobre.Text) > 0 Then
                    '        obj.EscribirLinea(y + 13, 23, "SOBRES")
                    '        obj.EscribirLinea(y + 13, 90, Me.txtCantidadSobres.Text)
                    '        obj.EscribirLinea(y + 13, 120, Format(CDbl(Me.txtTotalSobre.Text), "###,###,###0.00").PadLeft(10, " "))
                    '    End If

                    '    If Val(Me.txtMontoBase.Text) > 0 Then
                    '        obj.EscribirLinea(y + 14, 23, "BASE")
                    '        obj.EscribirLinea(y + 14, 120, Format(CDbl(Me.txtMontoBase.Text), "###,###,###0.00").PadLeft(10, " "))
                    '    End If
                    'ElseIf Me.ChkArticulos.Checked Then
                    '    If Val(Me.txtTotalSobre.Text) > 0 Then
                    '        obj.EscribirLinea(y + 13, 23, "SOBRES")
                    '        obj.EscribirLinea(y + 13, 90, Me.txtCantidadSobres.Text)
                    '        obj.EscribirLinea(y + 13, 120, Format(CDbl(Me.txtTotalSobre.Text), "###,###,###0.00").PadLeft(10, " "))
                    '    End If

                    '    If Val(Me.txtMontoBase.Text) > 0 Then
                    '        obj.EscribirLinea(y + 14, 23, "BASE")
                    '        obj.EscribirLinea(y + 14, 120, Format(CDbl(Me.txtMontoBase.Text), "###,###,###0.00").PadLeft(10, " "))
                    '    End If
                    'End If


                    ''obj.EscribirLinea(y + 17, 120, ObjIMPRESIONFACT_BOL.xMonto_Sub_Total.PadLeft(10, " "))
                    ''obj.EscribirLinea(y + 18, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xMonto_Impuesto), "####,###,###0.00").PadLeft(10, " "))
                    'obj.EscribirLinea(y + 17, 120, Format(CDbl(ObjIMPRESIONFACT_BOL.xTotal_Costo.ToString), "####,###,###0.00").PadLeft(10, " "))

                End If
                'obj.Comprimido = True
                'obj.Tamaño = ilong
                'obj.Imprimir()
                'obj.Finalizar()

                obj.Comprimido = True
                obj.Preliminar = True
                obj.Tamaño = ilong
                obj.Imprimir()
                obj.Finalizar()

                Dim frm As New FrmPreview
                frm.Tamaño = ilong
                frm.Documento = 1
                frm.Text = "Boleta"
                frm.ShowDialog()
            End If

        Catch ex As Exception
            obj.Finalizar()
            Throw New Exception(ex.Message)
        End Try
        Return False
    End Function
#End Region 'FIN GRABAR

#Region "NUEVO"

    Public Function fnNUEVO() As Boolean
        Try
            Me.btnEnviarSunat.Visible = False
            lblTotalPagado.Visible = False
            lblTotalVenta.Visible = False
            lblVuelto.Visible = False
            txtTotalPagado.Visible = False
            txtTotalVenta.Visible = False
            txtVuelto.Visible = False
            bDescuento = False
            bTieneLineaCredito = False
            TxtTelfCliente.Text = ""
            'txtTelfConsignado.Text = ""
            TxtCliente.Text = ""

            sDocCliente = ""
            iOficinaDestino = 0
            Me.CboCiudadOrigen.SelectedValue = 0
            Me.CboAgenciaOrigen.SelectedValue = 0
            TxtCiudadDestino.Text = ""
            Me.CboTipoEntrega.SelectedValue = 0 'TipoEntrega.Agencia
            RemoveHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
            TxtNroDocCliente.Text = ""
            AddHandler TxtNroDocCliente.TextChanged, AddressOf TxtNroDocCliente_TextChanged
            Me.LimpiarDatosGeneral()
            CboAgenciaDest.DataSource = Nothing
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
            CboProducto.SelectedIndex = 0
            CboFormaPago.SelectedIndex = 0
            Me.TxtCiudadDestino.Focus()
            '**********

            bClienteModificado = False
            bDireccionModificada = False
            bContactoModificado = False
            bConsignadoModificado = False
            bDirecConsigMod = False

            bConsignadoNuevo = True
            bClienteNuevo = True
            sNombresCli = "" : sApCli = "" : sAmCli = "" : sTelfCliente = "" : sCliente = ""

            sTelefonoConsig = ""
            sTelfCliente = ""

            Me.LimpiarCliente()
            Me.LimpiarConsignado()

            Me.TxtSubtotal.ReadOnly = True
            Me.TxtImpuesto.ReadOnly = True
            Me.TxtTotal.ReadOnly = True
            '**********

            'se agrego 14/08/2011
            iID_Persona = 0
            IdDireccionOrigen = 0
            bClienteModificado = False
            iID_TipoDocCli = 0
            sNombresCli = ""
            sApCli = ""
            sAmCli = ""
            sTelfCliente = ""
            idcontacto = 0
            bContactoModificado = False
            iID_TipoDocCont = 0
            NombresCont = ""
            apellPatCont = ""
            apellMatCont = ""

            iIDConsignado = 0
            idDireConsignado = 0
            bConsignadoModificado = False
            iID_TipoDocConsig = 0
            sNombresConsig = ""
            sapellPatConsig = ""
            sapellMatConsig = ""
            sTelefonoConsig = ""
            bDirecConsigMod = False
            bConsignadoNuevo = True
            RefreshNroDocumento(Me.CboProducto.SelectedValue)

            '******
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

            'hlamas 18-03-2016
            ControlaCargo(False)

            '===Agregado x NConsignado=============
            Me.GrdNConsignado.Rows.Clear()
            Me.LimpiarNConsignados()
            '======================================
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
#End Region 'OK

#Region "BTN_CARGA_ASEGURADA"
    Private Sub BtnCargAseg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCargAseg.Click
        Try
            If ChkArticulos.Checked = False Then
                Dim A As New FrmDocCliente

                A.sFecha = TxtFecha.Text
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

    Dim es_carga_asegurada As Boolean
    Dim iSub_Total_CA As Double = 0, iImpuesto_CA As Double = 0, iTotal_CA As Double = 0
    Dim bMontoMinimo As Boolean
    Dim objCargaAsegurada As New ClsLbTepsa.dtoCargaAsegurada
    Dim fArticulo As Boolean = False
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
                GrdDocumentosCliente("Seguro", k).Value = ""
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

                        'GrdDetalleVenta("Tipo", 4).Value = "CA"
                        'GrdDetalleVenta("Peso/Volumen", 4).Value = "0.00"
                        'GrdDetalleVenta("Costo", 4).Value = "0.00"

                        If bTarifarioGeneral And bContado Then
                            GrdDetalleVenta("Sub Neto", intFila).Value = FormatNumber(iTotal_CA, 2)
                        Else
                            GrdDetalleVenta("Sub Neto", intFila).Value = FormatNumber(iSub_Total_CA, 2)
                        End If
                    End If
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
                        GrdDetalleVenta("Tipo", intFila).Value = "CARGA SEGURO"
                        GrdDetalleVenta("Altura", intFila).Value = "0.00"
                        GrdDetalleVenta("Ancho", intFila).Value = "0.00"
                        GrdDetalleVenta("Largo", intFila).Value = "0.00"
                        GrdDetalleVenta("Peso Kg", intFila).Value = "0.00"
                        GrdDetalleVenta("Costo", intFila).Value = "0.00"
                        If bTarifarioGeneral And bContado Then
                            GrdDetalleVenta("Sub Neto", intFila).Value = FormatNumber(iTotal_CA, 2)
                        Else
                            GrdDetalleVenta("Sub Neto", intFila).Value = FormatNumber(iSub_Total_CA, 2)
                        End If
                    End If
                End If
            Else
                If ChkM3.Checked = False Then
                    intFila = BuscarItemVenta("SEGURO", GrdDetalleVenta)
                    If intFila > 0 Then
                        GrdDetalleVenta.Rows.RemoveAt(intFila)
                    End If
                    'If GrdDetalleVenta.Rows.Count = 5 Then
                    'GrdDetalleVenta.Rows.RemoveAt(4)
                    'End If
                ElseIf ChkM3.Checked = True Then
                    intFila = BuscarItemVenta("SEGURO", GrdDetalleVenta)
                    If intFila > 0 Then
                        GrdDetalleVenta.Rows.RemoveAt(intFila)
                    End If
                    'If GrdDetalleVenta.Rows.Count = 2 Then
                    '   GrdDetalleVenta.Rows.RemoveAt(1)
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
            MsgBox(ex.Message())
        End Try
    End Sub
#End Region 'OK

    Dim TarifaPublica_ As Boolean
    Dim TarifLineaCredito_ As Boolean
    Dim isDescuento_ As Boolean
    Sub tarifarioEnMemoria()
        GrdDetalleVenta(3, 0).Value = tarifa_Peso
        GrdDetalleVenta(3, 1).Value = tarifa_Volumen
        GrdDetalleVenta(3, 2).Value = tarifa_Sobre
        GrdDetalleVenta(3, 3).Value = Monto_Base
        GrdDetalleVenta(4, 3).Value = Monto_Base
    End Sub
#End Region

    Private Sub TxtNroDoc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroDoc.KeyPress
        If Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtSerie_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSerie.KeyPress
        If Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

#Region "FUNCIONES DE VALIDACIONES"
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

    Public Function ValidaNroTexto2(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[A-ZñÑa-z0-9\b]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            ValidaNroTexto2 = True
        Else
            ValidaNroTexto2 = False
        End If
    End Function

    Public Function ValidaNumero2(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[-0-9\b]") '("^\d+$")  
        If re.IsMatch(txtStr.ToString()) Then
            ValidaNumero2 = True
        Else
            ValidaNumero2 = False
        End If
    End Function

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
            MsgBox(ex.Message())
        End Try
        If monto Mod 0.5 = 0 Then
            Return monto
        Else
            Return monto_total
        End If
    End Function

    'funcion captura la teclas enter
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean = True
        Dim flat As Boolean = True
        Try
            Dim var As Integer = msg.WParam.ToInt32
            If msg.WParam.ToInt32 = Keys.Enter And Not BtnGrabar.Focused Then
                Dim bTecla As Boolean
                If TxtNroSerieDoc.Focused = True Then
                    If TxtNroSerieDoc.Text.Trim.Length > 0 Then
                        Me.Cursor = Cursors.AppStarting
                        objControlFacturasBol.iControl = 2
                        fnBuscarFacturas()
                        Me.Cursor = Cursors.Default
                    End If
                ElseIf txtClienteDNIRUC.Focused = True Then
                    If txtClienteDNIRUC.Text.Trim.Length > 0 Then
                        Me.Cursor = Cursors.AppStarting
                        objControlFacturasBol.iControl = 3
                        fnBuscarFacturas()
                        Me.Cursor = Cursors.Default
                    End If
                ElseIf TxtBoletoViaje.Focused = True Then
                    If TxtBoletoViaje.Text.Trim.Length > 0 Then
                        Me.Cursor = Cursors.AppStarting
                        objControlFacturasBol.iControl = 9
                        fnBuscarFacturas()
                        Me.Cursor = Cursors.Default
                    End If
                End If

                '************************
                If Me.TxtCliente.Focused AndAlso Me.TxtCliente.Text.Trim.Length > 0 Then
                    Dim scliente As String = Me.TxtCliente.Text.Trim
                    Dim iOpcion2 As Integer = IIf(Me.RbtDocumento.Checked, 1, 2)
                    If iOpcion = 0 Then
                        Buscar(scliente, iOpcion2, IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad), idUnidadAgencias)
                    End If
                ElseIf Me.TxtConsignado.Focused AndAlso Me.TxtConsignado.Text.Trim.Length > 0 AndAlso idUnidadAgencias >= 0 Then
                    BuscarConsignado()
                ElseIf Me.CboDireccion.Focused AndAlso Me.CboContacto.Enabled AndAlso Me.CboContacto.Items.Count > 1 AndAlso Me.CboContacto.SelectedIndex = 0 AndAlso Me.CboDireccion.SelectedIndex > 0 Then
                    Me.DespliegaContacto()
                ElseIf Me.CboCiudadOrigen.Focused Then
                    Me.DespliegaCboAgencia_Origen()
                Else
                    SendKeys.Send("{Tab}")
                End If
                '***********************
                objControlFacturasBol.iControl = 0
                'ElseIf msg.WParam.ToInt32 = Keys.F5 Then
                '    If Me.MenuTab.SelectedIndex = 1 AndAlso Me.BtnGrabar.Enabled Then
                '        Me.Cursor = Cursors.AppStarting
                '        Dim sender As Object
                '        Dim e As EventArgs
                '        BtnGrabar_Click(sender, e)
                '        Me.Cursor = Cursors.Default
                '    End If
            Else

                If iOpcion <= 1 Then '(Not TxtCliente.Focused Or Not TxtConsignado.Focused)
                    flat = MyBase.ProcessCmdKey(msg, KeyData)
                Else
                    If msg.WParam.ToInt32 = Keys.Tab Or msg.WParam.ToInt32 = Keys.Enter Then
                        flat = MyBase.ProcessCmdKey(msg, KeyData)
                    Else
                        flat = True
                    End If                    
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return flat
    End Function

#End Region

    '*****ultimo codigos***********
    Private Sub GrdDocumentosCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdDocumentosCliente.LostFocus
        GrdDocumentosCliente.ClearSelection()
    End Sub

    Private Sub GrdDetalleVenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdDetalleVenta.LostFocus
        GrdDetalleVenta.ClearSelection()
    End Sub

    Private Sub txtClienteDNIRUC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClienteDNIRUC.KeyPress
        If Not Me.ValidaNroTexto2(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNroSerieDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroSerieDoc.KeyPress
        If Me.ValidaNumero2(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

#End Region

    Private Sub CboAgenciaOrigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAgenciaOrigen.SelectedIndexChanged
        Try
            If Not IsReference(CboAgenciaOrigen.SelectedValue) Then
                If iOpcion = 2 Then
                    If CboAgenciaOrigen.Text <> ObjVentaCargaContado.dt_rstVarAgencias_2.Rows(0).Item(0) Then
                        CboAgenciaOrigen.Text = ObjVentaCargaContado.dt_rstVarAgencias_2.Rows(0).Item(0)
                        Return
                    End If
                Else
                    Me.RefreshNroDocumento(Me.CboProducto.SelectedValue)
                End If
                'dtoUSUARIOS.m_iIdAgencia = CboAgenciaOrigen.SelectedValue
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RbtDocumento3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtDocumento3.CheckedChanged, RbtNombre3.CheckedChanged
        Me.TxtConsignado.Text = ""
        'Me.TxtNroDocConsignado.Text = ""
        'Me.TxtNroDocConsignado.Tag = ""
        'Me.TxtNombConsignado.Text = ""

        If CType(sender, RadioButton).Name = "RbtDocumento3" Then
            Me.TxtConsignado.MaxLength = 11
        Else
            Me.TxtConsignado.MaxLength = 50
        End If
        Me.TxtConsignado.Focus()
    End Sub

    '********ultimos***********
    Sub Buscar(ByVal scliente As String, ByVal iopcion As Integer, ByVal m_idciudad As Integer, ByVal idUnidadAgencia As Integer)
        Try
            'hlamas 21-03-2016
            'If Me.CboProducto.SelectedValue = 8 Then
            'blnLimpiarDatosGeneral = False
            'Me.CboProducto.SelectedValue = 0
            'blnLimpiarDatosGeneral = True
            'End If

            Dim frm As New FrmCliente2
            Dim obj As New dtoVentaCargaContado
            Dim ds As DataSet = obj.Buscar(scliente, iopcion, 0, 0, , , 1)

            Dim bClienteExisteCA As Boolean = False
            If bInicioCargaAcompañada Then
                'If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item(0).ToString.Trim <> "" Then
                    bClienteExisteCA = True
                    If ds.Tables(0).Rows(0).Item("ap").ToString.Trim <> "" Then
                        dtCliente = ds.Tables(0)
                    End If
                End If
            Else
                dtCliente = ds.Tables(0)
            End If
            bClienteNuevo = True

            If IsDBNull(dtCliente.Rows(0).Item(0)) Then
                If Not bInicioCargaAcompañada Then
                    MessageBox.Show("El Cliente no Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.LimpiarCliente()
                    bClienteCredito = False
                    frm = New FrmCliente2
                    frm.bClienteNuevo = bClienteNuevo
                    frm.iFicha = 1
                    frm.TxtNumero.Text = IIf(RbtDocumento.Checked, scliente.Trim, "") '22092011 Agregado ayuda nroDocumento
                    frm.ShowDialog()
                    If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                        Me.LimpiarCliente()
                        CargarCliente(frm)
                    End If
                End If
            ElseIf (ds.Tables(0).Rows.Count = 1 And Not bInicioCargaAcompañada) Or (bInicioCargaAcompañada And bClienteExisteCA) Then
                Me.Mostrar(ds)
            ElseIf Not bInicioCargaAcompañada Then
                frm.bClienteNuevo = bClienteNuevo
                frm = New FrmCliente2
                frm.iFicha = 0

                frm.cargar(ds.Tables(0), 2)
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    If frm.bClienteNuevo Then
                        CargarCliente(frm)
                    Else
                        ds = obj.Buscar(frm.TxtNumero.Tag, 3, IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad), idUnidadAgencias)
                        dtCliente = ds.Tables(0)
                        Me.Mostrar(ds)
                    End If
                End If
            End If
            sDocCliente = TxtCliente.Text.Trim

            'hlamas 17-07-2014
            ClienteProducto(iID_Persona, 999, Me.CboCiudadOrigen.SelectedValue, idUnidadAgencias)

            'hlamas 15-11-2013
            'Tarifa Entrega a Domicilio
            GestionaTarifaDomicilio(CboTipoEntrega.SelectedValue, dtoUSUARIOS.m_idciudad, idUnidadAgencias, CboProducto.SelectedValue, CboTipoTarifa.SelectedValue, 3, IIf(Me.CboTipoEntrega.SelectedValue = 1, 4, 1), iID_Persona)
        Catch ex As Exception
            Throw New Exception
        End Try
    End Sub

    Sub Buscar(ByVal idPersona As Integer, ByVal m_idciudad As Integer, ByVal idUnidadAgencia As Integer)
        Try
            Dim frm As New FrmCliente2
            Dim obj As New dtoVentaCargaContado
            Dim ds As DataSet = obj.Buscar(idPersona, m_idciudad, idUnidadAgencia)

            Dim bClienteExisteCA As Boolean = False
            If bInicioCargaAcompañada Then
                'If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item(0).ToString.Trim <> "" Then
                    bClienteExisteCA = True
                    If ds.Tables(0).Rows(0).Item("ap").ToString.Trim <> "" Then
                        dtCliente = ds.Tables(0)
                    End If
                End If
            Else
                dtCliente = ds.Tables(0)
            End If
            bClienteNuevo = True

            If IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                If Not bInicioCargaAcompañada Then
                    MessageBox.Show("El Cliente no Existe.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.LimpiarCliente()
                    frm = New FrmCliente2
                    frm.bClienteNuevo = bClienteNuevo
                    frm.iFicha = 1
                    frm.TxtNumero.Text = IIf(RbtDocumento.Checked, sCliente.Trim, "") '22092011 Agregado ayuda nroDocumento
                    frm.ShowDialog()
                    If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                        Me.LimpiarCliente()
                        CargarCliente(frm)
                    End If
                End If
            ElseIf (ds.Tables(0).Rows.Count = 1 And Not bInicioCargaAcompañada) Or (bInicioCargaAcompañada And bClienteExisteCA) Then
                Me.Mostrar(ds)
            ElseIf Not bInicioCargaAcompañada Then
                frm.bClienteNuevo = bClienteNuevo
                frm = New FrmCliente2
                frm.iFicha = 0

                frm.cargar(ds.Tables(0), 2)
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    If frm.bClienteNuevo Then
                        CargarCliente(frm)
                    Else
                        ds = obj.Buscar(frm.TxtNumero.Text, 1, IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad), idUnidadAgencias)
                        dtCliente = ds.Tables(0)
                        Me.Mostrar(ds)
                    End If
                End If
            End If
            sDocCliente = TxtCliente.Text.Trim
        Catch ex As Exception
            Throw New Exception
        End Try
    End Sub

    Sub Mostrar(ByVal ds As DataSet)
        Try
            'hlamas 21-01-2016
            ChkArticulos.Tag = Nothing
            If bNuevo Then Me.LimpiarDatosCliente()
            ChkM3.Checked = False
            bClienteNuevo = False

            '**linea de credito**              
            'If ds.Tables(4).Rows.Count > 0 Then
            '    If CType(ds.Tables(4).Rows(0)("ES_ACTIVO"), Boolean) Then
            '        bTieneLineaCredito = True
            '    Else
            '        bTieneLineaCredito = False
            '    End If
            'Else
            '    bTieneLineaCredito = False
            'End If


            'If (ds.Tables(0).Rows(0)("Cliente_Corporativo")) = 1 Then
            '    bClienteCredito = True
            'Else
            bClienteCredito = False
            'End If

            '**Articulos**
            DtArticulos = ds.Tables(5).Copy
            If ds.Tables(5).Rows.Count > 0 Then
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
            If CboProducto.SelectedValue = 81 Or CboProducto.SelectedValue = 82 Then
                iProceso = CboProducto.SelectedValue
            End If
            '******************************************************
            If bNuevo Then
                RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
                If iProceso = 0 Then '------> Normal  Or (iProceso = 7 And ds.Tables(0).Rows(0).Item("codigo_cliente") <> TxtCliente.Text.Trim)
                    objGuiaEnvio.TarifaPyme_ = False
                    objGuiaEnvio.TarifaBox_ = False

                    If CboProducto.SelectedValue = 6 Then
                        Me.CboProducto.SelectedValue = 6
                    ElseIf CboProducto.SelectedValue = 8 Then 'And bTieneLineaCredito = False Then
                        Me.CboProducto.SelectedValue = 8
                    ElseIf CboProducto.SelectedValue = 9 Then 'And bTieneLineaCredito = False Then
                        Me.CboProducto.SelectedValue = 9
                    ElseIf CboProducto.SelectedValue = 10 Then 'And bTieneLineaCredito = False Then
                        Me.CboProducto.SelectedValue = 10
                    ElseIf CboProducto.SelectedValue = 81 Then
                        CboProducto.SelectedValue = 81
                    ElseIf CboProducto.SelectedValue = 82 Then
                        CboProducto.SelectedValue = 82
                    Else
                        Me.CboProducto.SelectedValue = iProceso
                    End If
                    Me.RefreshNroDocumento(0)
                ElseIf iProceso = 7 Then '--> Pyme  
                    objGuiaEnvio.TarifaBox_ = False

                    If CboProducto.SelectedValue = 6 Then
                        Me.CboProducto.SelectedValue = 6
                    Else
                        Me.CboProducto.SelectedValue = iProceso
                        Me.CondicionMontoMinimoPYME() '--Monto Minimo 04022012
                    End If

                    Me.objGuiaEnvio.TarifaPyme_ = True '--> indica q traera tarifa Pyme                                      
                    Me.RefreshNroDocumento(7)
                ElseIf iProceso = 8 Then '--> Masiva
                    objGuiaEnvio.TarifaPyme_ = False
                    objGuiaEnvio.TarifaBox_ = False
                    Me.CboProducto.SelectedValue = iProceso
                    objGuiaEnvio.TarifaMasiva_ = True
                    Me.RefreshNroDocumento(8)
                ElseIf iProceso = 9 Then '--> Tepsa Courier Office
                    objGuiaEnvio.TarifaPyme_ = False
                    objGuiaEnvio.TarifaBox_ = False
                    Me.CboProducto.SelectedValue = iProceso
                    objGuiaEnvio.TarifaMasiva_ = True
                    Me.RefreshNroDocumento(9)
                ElseIf iProceso = 10 Then '--> Tepsa Sobres
                    objGuiaEnvio.TarifaPyme_ = False
                    objGuiaEnvio.TarifaBox_ = False
                    Me.CboProducto.SelectedValue = iProceso
                    objGuiaEnvio.TarifaMasiva_ = True
                    Me.RefreshNroDocumento(10)
                ElseIf iProceso = 81 Or iProceso = 82 Then '--> Tepsa Box
                    objGuiaEnvio.TarifaPyme_ = False
                    objGuiaEnvio.TarifaMasiva_ = False
                    objGuiaEnvio.TarifaBox_ = True
                    Me.CboProducto.SelectedValue = iProceso
                    Me.RefreshNroDocumento(0)
                End If
                AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            End If

            If bNuevo Then
                Me.TxtNroDocCliente.Text = ds.Tables(0).Rows(0).Item("nu_docu_suna").ToString.Trim
                Me.TxtNomCliente.Text = ds.Tables(0).Rows(0).Item("razon_social").ToString.Trim
                Me.TxtTelfCliente.Text = IIf(IsDBNull(dtCliente.Rows(0).Item("telefono")), "", dtCliente.Rows(0).Item("telefono"))
            End If

            '--recuperando datos cliente--
            sNombresCli = IIf(IsDBNull(dtCliente.Rows(0).Item("nombres")), "", dtCliente.Rows(0).Item("nombres"))
            sApCli = IIf(IsDBNull(dtCliente.Rows(0).Item("ap")), "", dtCliente.Rows(0).Item("ap"))
            sAmCli = IIf(IsDBNull(dtCliente.Rows(0).Item("am")), "", dtCliente.Rows(0).Item("am"))
            sTelfCliente = IIf(IsDBNull(dtCliente.Rows(0).Item("telefono")), "", dtCliente.Rows(0).Item("telefono"))
            sCliente = IIf(IsDBNull(dtCliente.Rows(0).Item("razon_social")), "", dtCliente.Rows(0).Item("razon_social"))
            iID_TipoDocCli = ds.Tables(0).Rows(0).Item("tipo").ToString.Trim
            sEmail = IIf(IsDBNull(dtCliente.Rows(0).Item("email")), "", dtCliente.Rows(0).Item("email"))

            '********************************************************
            With Me.CboDireccion
                dtDireccion = ds.Tables(1)
                .DataSource = dtDireccion
                .DisplayMember = "direccion"
                .ValueMember = "iddireccion_consignado"

                If bNuevo Then
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
                End If
            End With

            RemoveHandler CboDireccion2.SelectedIndexChanged, AddressOf CboDireccion2_SelectedIndexChanged
            With Me.CboDireccion2
                dtDireccion2 = ds.Tables(2)
                .DataSource = dtDireccion2
                .DisplayMember = "direccion"
                .ValueMember = "iddireccion_consignado"

                'If Me.CboTipoEntrega.SelectedIndex > 0 Then
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
                    Me.ConvertirTipoEntrega(Me.CboTipoEntrega.SelectedValue)
                End If
            End With
            AddHandler CboDireccion2.SelectedIndexChanged, AddressOf CboDireccion2_SelectedIndexChanged

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
            'AddHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged

            If TipoComprobante = 1 Then
                CboContacto.Enabled = True
                ChkCliente1.Enabled = True
            Else
                ChkCliente1.Enabled = False
                CboContacto.Enabled = False
                CboContacto.SelectedIndex = 0
            End If

            If Me.CboProducto.SelectedValue <> 6 And Me.CboProducto.SelectedValue <> 8 Then  'solo aplica para tepsa encomiendas y tepsa courier office
                'hlamas 18-03-2016
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

            If bNuevo Then
                Me.CboListaUsuarios.SelectedValue = 0
            Else
                Me.CboListaUsuarios.SelectedValue = Me.DgvLista.CurrentRow.Cells("idusuario_personal").Value
            End If

            fnTarifario()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub DespliegaContacto()
        Me.CboContacto.DroppedDown = True
        Me.CboContacto.Focus()
        Me.Cursor = Cursors.Default
    End Sub

    Sub CargarCliente(ByVal frm As FrmCliente2)
        Try
            If frm.bClienteNuevo Then
                iID_Persona = 0
                bClienteCredito = False
            End If
            Me.TxtNroDocCliente.Text = frm.TxtNumero.Text
            Me.TxtNomCliente.Text = frm.TxtCliente.Text & " " & frm.TxtAPCliente.Text & " " & frm.TxtAMCliente.Text
            Me.TxtTelfCliente.Text = frm.txtTelefono.Text
            bClienteModificado = frm.bClienteModificado
            bDireccionModificada = frm.bDireccionModificada
            bContactoModificado = frm.bContactoModificado

            '-----datos cliente-------------------------  
            iID_TipoDocCli = frm.CboTipoDocumento.SelectedValue
            sNombresCli = frm.TxtCliente.Text
            sApCli = frm.TxtAPCliente.Text
            sAmCli = frm.TxtAMCliente.Text
            sTelfCliente = frm.txtTelefono.Text
            sEmail = frm.TxtEmail.Text
            '---------------------------------------------
            RemoveHandler CboDireccion.SelectedIndexChanged, AddressOf CboDireccion_SelectedIndexChanged
            RemoveHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
            If frm.TabCliente.SelectedIndex = 0 Then
                Me.TxtNroDocCliente.Text = frm.TxtNumero.Text.Trim
                Dim obj As New dtoVentaCargaContado
                Dim ds As DataSet = obj.Buscar(frm.TxtNumero.Text, 1, IIf(iUsuarioCiudad = 0, dtoUSUARIOS.m_idciudad, iUsuarioCiudad), idUnidadAgencias)
                dtCliente = ds.Tables(0)
                Me.Mostrar(ds)
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
                dtCliente.Columns.Add(New DataColumn("email", GetType(String)))

                dr = dtCliente.NewRow
                dr("idpersona") = 0
                dr("razon_social") = frm.TxtCliente.Text & " " & frm.TxtAPCliente.Text & " " & frm.TxtAMCliente.Text
                dr("tipo") = frm.CboTipoDocumento.SelectedValue
                dr("nu_docu_suna") = frm.TxtNumero.Text.Trim
                dr("nombres") = frm.TxtCliente.Text.Trim
                dr("ap") = frm.TxtAPCliente.Text.Trim
                dr("am") = frm.TxtAMCliente.Text.Trim
                dr("telefono") = frm.txtTelefono.Text.Trim
                dr("email") = frm.TxtEmail.Text.Trim
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
                        '------datos direccion estructurada----------
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
                        '20-10-2011
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
                        dr("direccion") = sDireccion
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
                End If

                If frm.bContactoModificado Or dtContacto Is Nothing Then
                    Me.CboContacto.DataSource = Nothing
                    Me.CboContacto.Items.Clear()

                    'Contacto
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
            Else
                ChkCliente1.Enabled = False
                CboContacto.Enabled = False
                'CboContacto.SelectedIndex = 0
            End If
            'AddHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
            AddHandler CboDireccion.SelectedIndexChanged, AddressOf CboDireccion_SelectedIndexChanged
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub LimpiarCliente()
        Me.TxtNroDocCliente.Text = ""
        Me.TxtNomCliente.Text = ""
        Me.TxtTelfCliente.Text = ""

        Me.CboDireccion.DataSource = Nothing
        Me.CboDireccion.Items.Clear()
        Me.CboDireccion.Items.Add(" (SELECCIONE)")
        Me.CboDireccion.SelectedIndex = 0

        Me.TxtNroDocContacto.Text = ""
        RemoveHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
        Me.CboContacto.DataSource = Nothing
        Me.CboContacto.Items.Clear()
        Me.CboContacto.Items.Add(" (SELECCIONE)")
        Me.CboContacto.SelectedIndex = 0
        AddHandler CboContacto.SelectedIndexChanged, AddressOf CboContacto_SelectedIndexChanged
        Me.ChkCliente1.Checked = False
    End Sub

    Dim bClienteCredito As Boolean
    Private Sub BtnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCliente.Click
        Try
            If iOpcion = 2 Then                
                Return
            End If

            Me.Cursor = Cursors.AppStarting
            Dim frm As New FrmCliente2
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
            Dim sAmCont As String
            Dim bEsCliente As Boolean = False

            If Me.TxtNroDocCliente.Text.Trim.Length > 0 Or Me.TxtNomCliente.Text.Trim.Length > 0 Then
                If Not bClienteNuevo Then
                    sNumero = IIf(IsDBNull(dtCliente.Rows(iFila).Item("nu_docu_suna")), "", dtCliente.Rows(iFila).Item("nu_docu_suna"))
                    sCliente = IIf(IsDBNull(dtCliente.Rows(iFila).Item("razon_social")), "", dtCliente.Rows(iFila).Item("razon_social"))
                    'If Not bBoleto Then
                    iTipo = IIf(IsDBNull(dtCliente.Rows(iFila).Item("tipo")), "", dtCliente.Rows(iFila).Item("tipo"))
                    sEmail = IIf(IsDBNull(dtCliente.Rows(iFila).Item("email")), "", dtCliente.Rows(iFila).Item("email"))
                    'Else
                    'iTipo = IIf(IsDBNull(dtCliente.Rows(iFila).Item("tipo")), 9, Me.ObtieneTipoDocumento(dtCliente.Rows(iFila).Item("tipo")))
                    'End If
                    sTelfCliente = IIf(IsDBNull(dtCliente.Rows(iFila).Item("telefono")), "", dtCliente.Rows(iFila).Item("telefono"))
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

                    iFila = IIf(Me.CboDireccion.SelectedIndex = -1, 0, Me.CboDireccion.SelectedIndex)
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

                    iFila = IIf(Me.CboContacto.SelectedIndex = -1, 0, Me.CboContacto.SelectedIndex)
                    iTipo2 = IIf(IsDBNull(dtContacto.Rows(iFila).Item("idtipo_documento_contacto")), 0, dtContacto.Rows(iFila).Item("idtipo_documento_contacto"))
                    sNumero3 = IIf(IsDBNull(dtContacto.Rows(iFila).Item("nrodocumento")), "", dtContacto.Rows(iFila).Item("nrodocumento"))
                    sContacto = IIf(IsDBNull(dtContacto.Rows(iFila).Item("nombres")), " ", dtContacto.Rows(iFila).Item("nombres"))
                    sNombresCont = IIf(IsDBNull(dtContacto.Rows(iFila).Item("nombre")), "", dtContacto.Rows(iFila).Item("nombre")) 'new
                    sApCont = IIf(IsDBNull(dtContacto.Rows(iFila).Item("apepat")), "", dtContacto.Rows(iFila).Item("apepat"))
                    sAmCont = IIf(IsDBNull(dtContacto.Rows(iFila).Item("apemat")), "", dtContacto.Rows(iFila).Item("apemat"))

                    If sContacto.Trim.Substring(0, 1) = "(" Then
                        sContacto = ""
                    End If
                    bEsCliente = Me.ChkCliente1.Checked
                Else
                    sNumero = IIf(IsDBNull(dtCliente.Rows(0).Item("nu_docu_suna")), "", dtCliente.Rows(0).Item("nu_docu_suna"))
                    sCliente = IIf(IsDBNull(dtCliente.Rows(0).Item("razon_social")), "", dtCliente.Rows(0).Item("razon_social"))
                    sEmail = IIf(IsDBNull(dtCliente.Rows(iFila).Item("email")), "", dtCliente.Rows(iFila).Item("email"))
                    If Not bBoleto Then
                        iTipo = IIf(IsDBNull(dtCliente.Rows(0).Item("tipo")), "", dtCliente.Rows(0).Item("tipo"))
                    Else
                        'iTipo = IIf(IsDBNull(dtCliente.Rows(0).Item("tipo")), 9, ObtieneTipoDocumento(dtCliente.Rows(0).Item("tipo")))
                        iTipo = IIf(IsDBNull(dtCliente.Rows(0).Item("tipo")), "", dtCliente.Rows(0).Item("tipo"))
                    End If
                    sTelfCliente = IIf(IsDBNull(dtCliente.Rows(iFila).Item("telefono")), "", dtCliente.Rows(iFila).Item("telefono"))
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
                        iFila = IIf(Me.CboDireccion.SelectedIndex = -1, 0, Me.CboDireccion.SelectedIndex)
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
                            iFila = IIf(Me.CboContacto.SelectedIndex = -1, 0, Me.CboContacto.SelectedIndex)
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
                    End If
                End If
            End If

            frm.cargar(sNumero, sCliente, iTipo, sNombresCli, sApCli, sAmCli, iDepartamento, iProvincia, iDistrito, iId_via, sVia, sNumero2, _
                       sManzana, sLote, iId_Nivel, sNivel, iId_Zona, sZona, iId_Clasificacion, _
                       sClasificacion, iTipo2, sNumero3, sContacto, sNombresCont, sApCont, sAmCont, sTelfCliente, bEsCliente, sEmail, bClienteCredito)

            frm.bClienteNuevo = bClienteNuevo
            frm.bContactoNuevo = IIf(idcontacto > 0, False, True)
            'frm.iTipoComprobante = TipoComprobante
            frm.ShowDialog()
            Me.Cursor = Cursors.Default
            If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.AppStarting
                Me.CargarCliente(frm)

                'hlamas 17-07-2014
                ClienteProducto(iID_Persona, 999, Me.CboCiudadOrigen.SelectedValue, idUnidadAgencias)

                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ChkCliente1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCliente1.CheckedChanged
        Try
            If iOpcion = 2 Then
                ChkCliente1.Checked = bclienteCont
                Return
            End If

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
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub CboDireccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDireccion.SelectedIndexChanged
        Try
            If Not IsReference(CboDireccion.SelectedValue) Then
                If iOpcion = 2 Then                    
                    CboDireccion.SelectedValue = IdDireccionOrigen
                    Return
                End If

                If Not bDireccionModificada Then
                    IdDireccionOrigen = CboDireccion.SelectedValue
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Dim idDireConsignado, iIDConsignado As Integer
    Private Sub CboDireccion2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDireccion2.SelectedIndexChanged
        Try
            If iOpcion = 2 Then
                If CboDireccion2.SelectedValue <> ObjVentaCargaContado.v_IDDIREECION_DESTINO Then
                    CboDireccion2.SelectedValue = ObjVentaCargaContado.v_IDDIREECION_DESTINO
                    Return
                End If                
            End If

            If CboTipoEntrega.SelectedValue = 2 Then
                If CboDireccion2.SelectedIndex = 0 Then '09092011
                    TxtReferencia.Text = ""
                ElseIf CboDireccion2.SelectedIndex > 0 Then
                    TxtReferencia.Text = IIf(IsDBNull(dtDireccion2.Rows(CboDireccion2.SelectedIndex).Item("de_referencia")), "", dtDireccion2.Rows(CboDireccion2.SelectedIndex).Item("de_referencia"))
                    sReferencia = TxtReferencia.Text.Trim
                End If
            Else
                TxtReferencia.Text = ""
                sReferencia = ""
            End If

            If Not bDirecConsigMod Then
                idDireConsignado = CboDireccion2.SelectedValue
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub CboDireccion_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDireccion.SelectedValueChanged
        If iDespliegue = 1 Then
            If CboDireccion.SelectedIndex > 0 AndAlso CboContacto.SelectedIndex = 0 And TipoComprobante = 1 Then
                Me.DespliegaContacto()
            End If
        End If
        iDespliegue = 0
    End Sub

    Private Sub CboDireccion_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDireccion.SelectionChangeCommitted
        iDespliegue = 1
    End Sub

    Private Sub txttotal_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTotal.Enter
        Dim iValor As Double = 0
        If Me.txttotal.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.txttotal.Text
        End If
        Me.txttotal.Text = Format(CDbl(iValor), "########0.00")
        If Val(txttotal.Text) = 0 Then
            txttotal.Text = ""
        End If
    End Sub

    Private Sub txttotal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTotal.GotFocus
        txttotal.SelectAll()
    End Sub

    Private Sub txttotal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTotal.LostFocus
        Dim iValor As Double = 0
        If Me.TxtTotal.Text.Trim.Length = 0 Then
            iValor = 0
        Else
            iValor = Me.TxtTotal.Text
        End If
        Me.TxtTotal.Text = Format(CDbl(iValor), "##,###,###0.00")
        If Val(TxtTotal.Text) = 0 Then
            TxtTotal.Text = ""
        End If
    End Sub

    Private Sub TxtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCliente.KeyPress
        'If Not bNuevo Then
        '    e.Handled = True
        'End If
        If Me.RbtDocumento.Checked Then
            If Not ValidarLetraNumero(e.KeyChar) Then
                e.Handled = True
            End If
        Else
            If Not ValidarLetra(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTotal.TextChanged
        Return
        If blnTotalManual = False Then Return
        If Not Me.TxtTotal.ReadOnly Then
            Dim iTotal As Double = 0
            Dim iSubTotal As Double = 0
            Dim iImpuesto As Double = 0
            If Val(TxtTotal.Text) > 0 Then
                iTotal = TxtTotal.Text
            Else
                iTotal = 0
            End If
            iSubTotal = iTotal / (1 + (dtoUSUARIOS.iIGV / 100))
            iImpuesto = iSubTotal * (dtoUSUARIOS.iIGV / 100)

            Me.TxtSubtotal.Text = Format(iSubTotal, "###,###,###.00")
            Me.TxtImpuesto.Text = Format(iImpuesto, "###,###,###.00")
        End If
    End Sub

    Private Sub txttotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTotal.KeyPress
        e.Handled = ModuUtil.Numero(e, TxtTotal)
    End Sub

    Private Sub GrdDocumentosCliente_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles GrdDocumentosCliente.RowsAdded
        GrdDocumentosCliente.ClearSelection()
        GrdDetalleVenta.ClearSelection()
    End Sub

    Private Sub GrdDetalleVenta_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles GrdDetalleVenta.RowsAdded
        GrdDocumentosCliente.ClearSelection()
        GrdDetalleVenta.ClearSelection()
    End Sub

    Private Sub GrdDetalleVenta_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles GrdDetalleVenta.RowsRemoved
        GrdDocumentosCliente.ClearSelection()
        GrdDetalleVenta.ClearSelection()
    End Sub

    Private Sub RbtDocumento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtDocumento.CheckedChanged, RbtNombre.CheckedChanged
        Me.TxtCliente.Text = ""
        'Me.TxtNroDocCliente.Text = ""
        'Me.TxtNroDocCliente.Tag = ""
        'Me.TxtNomCliente.Text = ""

        If CType(sender, RadioButton).Name = "RbtDocumento" Then
            Me.TxtCliente.MaxLength = 11
        Else
            Me.TxtCliente.MaxLength = 50
        End If
        Me.TxtCliente.Focus()
    End Sub


    '-----------NUEVO CODIGO NCONSIGNADO--------   
    Sub DiseñaGrdNConsignado()
        Try

            Dim Camp0 As String = "", camp1 = "", camp2 = "", camp3 = "", camp4 = "", camp5 = "", camp6 = "", camp7 = "", camp8 = "", camp9 = ""
            Camp0 = "IDConsignado" : camp1 = "N. Doc." : camp2 = "Nombres" : camp3 = "Telefono"
            camp4 = "nombre" : camp5 = "tipo" : camp6 = "apepat" : camp7 = "apemat" : camp8 = "Modificado" : camp9 = "IDVentaConsignado"

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
        ObjVentaCargaContado.IDVentaConsignado = ""
    End Sub

    'ACTUALIZA O REGISTRA NUEVO CONSIGNADO
    Dim indice As Integer = 0    
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
        GrdNConsignado("IDVentaConsignado", row).Value = "0"
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
    '19-10-2011
    'Dim iIndice As Integer          
    Private Sub GrdNConsignado_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdNConsignado.RowEnter
        'iIndice = e.RowIndex
    End Sub

    Private Sub TxtImpuesto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtImpuesto.KeyPress
        e.Handled = ModuUtil.Numero(e, TxtImpuesto)
    End Sub

    Private Sub TxtSubtotal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSubtotal.KeyPress
        e.Handled = ModuUtil.Numero(e, TxtSubtotal)
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles BtnNuevo.EnabledChanged, BtnEditar.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
            Dim a As Boolean = BtnNuevo.Enabled
        End If
    End Sub

#Region "Entrega Domicilio"
    Sub GestionaTarifaDomicilio(TipoEntrega As Integer, origen As Integer, destino As Integer, producto As Integer, tipo_tarifa As Integer, tipo_visibilidad As Integer, servicio As Integer, cliente As Integer)
        If blnInicio Then Return
        'hlamas 01-08-2015
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

    Function BuscarProducto(cliente As Integer, subcuenta As Integer, origen As Integer, destino As Integer) As Integer
        Dim objClienteProducto As New Cls_ClienteProducto_LN
        Dim intProducto As Integer = objClienteProducto.BuscarProducto(cliente, subcuenta, origen, destino, 1)
        Return intProducto
    End Function

    Sub ClienteProducto(cliente As Integer, subcuenta As Integer, origen As Integer, destino As Integer)
        If Me.CboProducto.SelectedValue <> 0 And Me.CboProducto.SelectedValue <> 8 And Me.CboProducto.SelectedValue <> 9 And Me.CboProducto.SelectedValue <> 10 Then Return
        If Me.CboProducto.SelectedValue <> 9 Then
            If cliente = 0 Or subcuenta = 0 Or origen = 0 Or destino = 0 Then Return
            If Me.TxtNroDocCliente.Text.Trim.Length = 0 Then
                'iID_Persona=0
                Return
            End If
        End If

        Dim intProducto As Integer = Me.BuscarProducto(cliente, subcuenta, origen, destino)
        If intProducto > 0 Then
            RemoveHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
            Me.CboProducto.SelectedValue = intProducto
            'Me.CboProducto.Enabled = False
            'Me.RefreshNroDocumento(8)
            Me.RefreshNroDocumento(Me.CboProducto.SelectedValue)
            objGuiaEnvio.TarifaBox_ = False
            objGuiaEnvio.TarifaPyme_ = False
            Me.bBoleto = False '-->"N" Base <> 0
            'Me.LimpiarDatosGeneral()

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
            AddHandler CboProducto.SelectedIndexChanged, AddressOf CboProducto_SelectedIndexChanged
        ElseIf Me.CboProducto.SelectedValue = 8 Then
            'MessageBox.Show("El Cliente no tiene asignado el Producto Tepsa Courier", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Me.CboProducto.SelectedValue = 0
            'If Not Cls_ClienteProducto_LN.AccedeProducto(cliente) Then
            'Me.CboProducto.SelectedValue = 0
            'End If
            If Me.TxtNroDocCliente.Text.Trim.Length = 11 Then
                Me.CboProducto.SelectedValue = 0
            End If
        ElseIf Me.CboProducto.SelectedValue = 9 Then
            'MessageBox.Show("El Cliente no tiene asignado el Producto Tepsa Courier", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Me.CboProducto.SelectedValue = 0
            'If Cls_LineaCredito_LN.LineaCredito(cliente) = 1 Then
            'Me.CboProducto.SelectedValue = 0
            'End If
            'If Not Cls_ClienteProducto_LN.AccedeProducto(cliente) Then
            Me.CboProducto.SelectedValue = 0
            'End If
        End If
    End Sub
#End Region

    Private Sub TxtCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCliente.TextChanged
        'If Me.CboProducto.SelectedValue = 8 Then
        'Me.CboProducto.SelectedValue = 0
        'End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        BtnImprimir.Enabled = True
    End Sub

    Private Sub ChkCargo_CheckedChanged(sender As System.Object, e As System.EventArgs)
        'If iOpcion = 2 Then
        '    ChkCargo.Checked = ObjVentaCargaContado.v_cargo
        'End If
        'Try
        '    dblMontoDC = ObtieneMontoDevolucionCargo()
        '    If GrdDetalleVenta.Rows.Count = 0 Then Return
        '    If TipoGrid_ = FormatoGrid.BULTO Then
        '        fnTotalPago()
        '    ElseIf TipoGrid_ <> FormatoGrid.ARTICULOS Then
        '        iROW = 0
        '        Calculo_M3()
        '    End If
        'Catch
        'End Try
    End Sub

    Function ObtieneMontoDevolucionCargo() As Double
        'If Me.CboProducto.SelectedValue <> 0 And Me.CboProducto.SelectedValue <> 9 And Me.CboProducto.SelectedValue <> 10 Then 'solo aplica para tepsa encomiendas y tepsa courier office
        'If Me.CboProducto.SelectedValue = 6 Or Me.CboProducto.SelectedValue = 8 Then
        'dblMontoDC = 0
        'Return dblMontoDC
        'End If

        Dim dblMonto As Double = 0
        If rbtCargoSi.Checked Then
            dblMonto = dtoVentaCargaContado.MontoDevolucionCargo(Me.CboProducto.SelectedValue, iID_Persona)
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
        If estado Then
        Else
            LimpiarGrid(GrdDocumentosCliente, 2)
            'Me.GrdDocumentosCliente.Rows.Clear()
            'Dim row11 As String() = {"", " ", " ", ""}
            'GrdDocumentosCliente.Rows().Add(row11)
            'GrdDocumentosCliente.Rows().Add(row11)
            'GrdDocumentosCliente.Rows().Add(row11)
        End If
    End Sub

    Private Sub chkDocumentoCliente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDocumentoCliente.CheckedChanged
        'hlamas 18-03-2016
        If iOpcion = 2 Then Return
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

    Private Sub TxtSerie_LostFocus(sender As Object, e As System.EventArgs) Handles TxtSerie.LostFocus, TxtNroDoc.LostFocus
        TxtSerie.Text = RellenoRight(Mro_Digitos_SerieVentas, TxtSerie.Text)
        TxtNroDoc.Text = RellenoRight(Mro_Digitos_Ventas, TxtNroDoc.Text)
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviarSunat.Click

        If String.IsNullOrEmpty(TxtSerie.Text.Trim) Then
            MessageBox.Show("El Comprobante no tiene Número de Serie", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        ElseIf String.IsNullOrEmpty(TxtNroDoc.Text.Trim) Then
            MessageBox.Show("El Comprobante no tiene Número de Correlativo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim serie As String = TxtSerie.Text.Trim
        Dim correlativo As String = TxtNroDoc.Text.Trim
        'serie = "F999"
        'correlativo = "0000261"

        If ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = FEManager.TITAN_ID_TIPCOM_FACTURA Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = FEManager.TITAN_ID_TIPCOM_BOLETA Then
            '-->Facturas y boletas
            '**********************************************
            If Convert.ToDouble(TxtTotal.Text) <= 0 Then
                MessageBox.Show("El total debe ser mayor a cero", "Alerta FE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim idProducto As Integer = DirectCast(CboProducto.SelectedItem, DataRowView)(0)

            Dim fecliente As New FECliente
            fecliente.tipoDocumentoID = iID_TipoDocCli
            fecliente.numeroDocumento = TxtNroDocCliente.Text.Trim()
            fecliente.nombres = TxtNomCliente.Text.Trim.ToUpper()
            fecliente.direccion = IIf(CboDireccion.SelectedValue > 0, CboDireccion.Text.Trim.ToUpper(), Nothing)
            Dim venta As New FEVenta
            venta.cliente = fecliente
            venta.numeroSerie = serie
            venta.numeroCorrelativo = correlativo
            venta.fechaEmision = DgvLista.CurrentRow.Cells("fecha_factura").Value
            venta.tipoComprobanteID = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            venta.opGravada = TxtSubtotal.Text.Trim()
            venta.igv = TxtImpuesto.Text.Trim()
            venta.total = TxtTotal.Text.Trim()
            venta.totalLetras = ConvercionNroEnLetras(venta.total)
            venta.formaPago = CboFormaPago.Text.Trim().ToUpper()
            Dim formaPagoID As Integer = Int(ObjVentaCargaContado.coll_Tipo_Pago(CboFormaPago.SelectedIndex.ToString))
            If (formaPagoID = 5) Then '-->Cortesia
                venta.isCortesia = True
            End If
            '->Consigando
            Dim consignado As String = ""
            For Each row As DataGridViewRow In GrdNConsignado.Rows
                If (Not row Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells("Nombres").Value.ToString.Trim)) Then
                    consignado += row.Cells("Nombres").Value
                End If
            Next
            venta.consignado = consignado
            venta.tipoEntrega = CboTipoEntrega.Text.Trim.ToUpper()
            venta.direccionEntrega = CboDireccion2.Text.Trim.ToUpper()
            venta.agenciaId = DirectCast(CboAgenciaOrigen.SelectedItem, DataRowView)(0)
            If Me.DgvLista.CurrentRow.Cells("agencia_venta").Value > 0 Then
                venta.agenciaId = Me.DgvLista.CurrentRow.Cells("agencia_venta").Value
            End If
            venta.usuarioID = DirectCast(DgvLista.DataSource, DataView).Item(DgvLista.CurrentRow.Index).Item("usuario")
            venta.usuarioInsercion = DirectCast(DgvLista.DataSource, DataView).Item(DgvLista.CurrentRow.Index).Item("login")
            venta.usuarioModificacion = DirectCast(DgvLista.DataSource, DataView).Item(DgvLista.CurrentRow.Index).Item("login")
            venta.detalleVenta = FEManager.CrearDetalleVenta(GrdDetalleVenta, venta.total, ChkArticulos.Checked, ChkM3.Checked, idProducto)

            Dim result = FEManager.sendVentaSunat(venta, Nothing)
            If (result.IsCorrect) Then
                Dim objFac As New ClsLbTepsa.dtoFACTURA
                objFac.actualizarEmisonFE(ObjVentaCargaContado.v_IDFACTURA, "T_FACTURA_CONTADO")
            End If
            MessageBox.Show(result.Message, "Emisión F.E.", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = FEManager.TITAN_ID_TIPCOM_NOTA_CREDITO Or ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = FEManager.TITAN_ID_TIPCOM_NOTA_DEBITO Then
            '-->Notas de credito y debito
            '**********************************************
            Dim fecliente As New FECliente
            fecliente.tipoDocumentoID = iID_TipoDocCli
            fecliente.numeroDocumento = TxtNroDocCliente.Text.Trim()
            fecliente.nombres = TxtNomCliente.Text.Trim.ToUpper()
            fecliente.direccion = DgvLista.CurrentRow.Cells("direccion_padre").Value

            Dim documentoReferencia As New FEDocumentoReferencia
            documentoReferencia.tipoDocumentoID = DgvLista.CurrentRow.Cells("tipo_padre").Value
            documentoReferencia.numeroDocumento = DgvLista.CurrentRow.Cells("comprobante_padre").Value
            documentoReferencia.fechaEmision = DgvLista.CurrentRow.Cells("fecha_padre").Value

            Dim fenote As New FENota
            fenote.numeroSerie = serie
            fenote.numeroCorrelativo = correlativo
            fenote.cliente = fecliente
            fenote.documentoReferencia = documentoReferencia
            fenote.fechaEmison = DgvLista.Rows(DgvLista.CurrentRow.Index).Cells("fecha_factura").Value
            fenote.igv = Convert.ToDouble(TxtImpuesto.Text) * -1
            fenote.subTotal = Convert.ToDouble(TxtSubtotal.Text) * -1
            fenote.total = Convert.ToDouble(TxtTotal.Text) * -1
            fenote.tipoNota = DgvLista.CurrentRow.Cells("codigo_nc").Value
            fenote.descripcionTipoNota = DgvLista.CurrentRow.Cells("descripcion_nc").Value
            fenote.totalLentras = ConvercionNroEnLetras(fenote.total)
            fenote.descripcionSustento = DgvLista.CurrentRow.Cells("glosa_nc").Value
            fenote.agenciaId = DirectCast(CboAgenciaOrigen.SelectedItem, DataRowView)(0)
            If Me.DgvLista.CurrentRow.Cells("agencia_venta").Value > 0 Then
                fenote.agenciaId = Me.DgvLista.CurrentRow.Cells("agencia_venta").Value
            End If
            fenote.usuarioID = DirectCast(DgvLista.DataSource, DataView).Item(DgvLista.CurrentRow.Index).Item("usuario")
            fenote.usuarioInsercion = DirectCast(DgvLista.DataSource, DataView).Item(DgvLista.CurrentRow.Index).Item("login")
            fenote.usuarioModificacion = DirectCast(DgvLista.DataSource, DataView).Item(DgvLista.CurrentRow.Index).Item("login")

            Dim result = Nothing
            If (ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = FEManager.TITAN_ID_TIPCOM_NOTA_CREDITO) Then
                result = FEManager.sendNota(fenote, True)
            ElseIf (ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = FEManager.TITAN_ID_TIPCOM_NOTA_DEBITO) Then
                result = FEManager.sendNota(fenote, False)
            End If


            If Not result Is Nothing Then
                If (result.isCorrect) Then
                    Dim idNotaCredito As Long = ObjVentaCargaContado.v_IDFACTURA
                    Dim objFac As New ClsLbTepsa.dtoFACTURA
                    objFac.actualizarEmisonFE(idNotaCredito, "T_FACTURA_CONTADO")
                End If
                MessageBox.Show(result.Message, "Respuesta WSSunat", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Tipo de comprobante no Válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    'Sub ImprimirTicket(ByVal impresora As DataTable)
    '    Dim prn As New FEManager
    '    Dim feventa As New FEVenta
    '    Dim fecliente As New FECliente

    '    Dim venta As dtoVentaCargaContado

    '    fecliente.tipoDocumentoID = venta.ID_TipoDocCli
    '    fecliente.numeroDocumento = venta.v_NRO_DNI_RUC
    '    fecliente.nombres = venta.v_NOMBRES_RASONSOCIAL

    '    'If ObjVentaCargaContado.v_direccion.Trim.Length > 0 Then
    '    'fecliente.direccion = ObjVentaCargaContado.v_direccion.Trim.ToUpper
    '    'Else
    '    fecliente.direccion = IIf(cmbDireccion.SelectedIndex > 0, cmbDireccion.Text.Trim.ToUpper(), "")
    '    'End If
    '    feventa.cliente = fecliente

    '    Dim strSerie As String
    '    If LblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_BOLETA) Then
    '        strSerie = "B"
    '    ElseIf LblTipoComprobante.Text.Equals(LABEL_TIPOCOMPROBANTE_FACTURA) Then
    '        strSerie = "F"
    '    Else
    '        strSerie = ""
    '    End If
    '    feventa.numeroSerie = strSerie & Me.lblSerie.Text 'venta.v_SERIE_FACTURA
    '    feventa.numeroCorrelativo = Me.lblNumeroComprobante.Text 'venta.v_NRO_FACTURA 'lblNumeroComprobante.Text.Trim

    '    feventa.fechaEmision = FechaServidor()
    '    feventa.tipoComprobanteID = venta.v_IDTIPO_COMPROBANTE
    '    feventa.opGravada = 0
    '    feventa.igv = 0
    '    feventa.total = 0
    '    feventa.totalLetras = ObjVentaCargaContado.v_nroboleto
    '    feventa.formaPago = IIf(cmbFormaPago.SelectedIndex = 0, "", cmbFormaPago.Text.Trim().ToUpper())
    '    Dim formaPagoID As Integer = cmbFormaPago.SelectedValue
    '    If (formaPagoID = 5) Then '-->Cortesia
    '        feventa.isCortesia = True
    '    End If

    '    '-->Para la impresion
    '    feventa.producto = IIf(venta.v_iProceso = 11, "EQUIPAJE", "CARGA ACOMPAÑADA")
    '    feventa.origen = lblCiudadOrigen.Text.Trim.ToUpper()
    '    feventa.destino = lblCiudadDestino.Text.Trim.ToUpper()
    '    feventa.remitenete = fecliente.nombres
    '    feventa.consignado = Me.lblNombres.Text.Trim.ToUpper
    '    feventa.tipoEntrega = "AGENCIA"
    '    feventa.direccionEntrega = "AGENCIA"
    '    feventa.agenciaEmision = dtoUSUARIOS.m_iNombreAgencia
    '    feventa.usuarioEmision = dtoUSUARIOS.NameLogin
    '    feventa.detalleVenta = FEManager.crearDetalleVenta(dgDetalleEquipaje, 0, False, False, venta.v_iProceso, 1)
    '    feventa.id = ObjVentaCargaContado.v_IDFACTURA
    '    feventa.tabla = "T_FACTURA_CONTADO"

    '    Dim result As New servicefe.Result
    '    prn.Print(feventa, "04", impresora, result)
    'End Sub

    Private Sub TxtNroSerieDoc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNroSerieDoc.TextChanged

    End Sub

    Private Sub btnTicketResumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTicketResumen.Click
        If MessageBox.Show("¿Está seguro de imprimir el Ticket de Entrega?", "Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
            Return
        End If

        Try
            Dim dtImpresora As DataTable = FEManager.buscarPrint()
            If dtImpresora Is Nothing Then
                MessageBox.Show(FEManager.MESSAGE_NO_PRINT, "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            Me.Cursor = Cursors.WaitCursor

            Dim prn As New FEManager
            Dim strBoleto As String = Me.DgvLista.CurrentRow.Cells("nroboleto").Value
            Dim intNivel As Integer = Me.DgvLista.CurrentRow.Cells("nivel_equipaje").Value
            Dim intComprobante As Integer = Me.DgvLista.CurrentRow.Cells("Idfactura").Value
            With Me.DgvLista
                Dim obj As New dtoVentaCargaContado
                Dim dt As DataTable = obj.ListarBoleto(strBoleto, 3, intNivel, intComprobante)
                If dt.Rows.Count > 0 Then
                    Dim feventa As New FEVenta
                    Dim fecliente As New FECliente

                    Dim intCantidad As Integer
                    If dt.Rows(0).Item("idprocesos") = 11 Then
                        Dim obj2 As New dtoVentaCargaContado
                        intCantidad = dt.Rows(0).Item("cp")
                    Else
                        intCantidad = 1
                    End If

                    For i As Integer = 1 To intCantidad
                        fecliente.tipoDocumentoID = dt.Rows(0).Item("idtipo_doc_identidad")
                        fecliente.numeroDocumento = dt.Rows(0).Item("nu_docu_suna")
                        fecliente.nombres = dt.Rows(0).Item("cliente")
                        feventa.cliente = fecliente

                        Dim intTipo As Integer = dt.Rows(0).Item("idtipo_comprobante")
                        Dim strSerie As String
                        If intTipo = 2 Then
                            strSerie = "B"
                        ElseIf intTipo = 1 Then
                            strSerie = "F"
                        Else
                            strSerie = ""
                        End If
                        feventa.numeroSerie = strSerie & dt.Rows(0).Item("serie_factura") 'venta.v_SERIE_FACTURA
                        feventa.numeroCorrelativo = dt.Rows(0).Item("nro_factura") 'venta.v_NRO_FACTURA 'lblNumeroComprobante.Text.Trim

                        feventa.fechaEmision = FechaServidor()
                        feventa.tipoComprobanteID = dt.Rows(0).Item("idtipo_comprobante")
                        feventa.opGravada = 0
                        feventa.igv = 0
                        feventa.total = 0
                        feventa.totalLetras = dt.Rows(0).Item("nroboleto")
                        feventa.cliente.direccion = dt.Rows(0).Item("serie_factura") & "-" & dt.Rows(0).Item("nro_factura")

                        If intTipo = 4 Then
                            feventa.formaPago = ""
                        Else
                            If dt.Rows(0).Item("idtipo_pago") = 1 Then
                                feventa.formaPago = "EFECTIVO"
                            ElseIf dt.Rows(0).Item("idtipo_pago") = 2 Then
                                feventa.formaPago = "TARJETA"
                            Else
                                feventa.formaPago = "CORTESIA"
                            End If
                        End If
                        Dim formaPagoID As Integer = dt.Rows(0).Item("idtipo_pago")
                        If (formaPagoID = 5) Then '-->Cortesia
                            feventa.isCortesia = True
                        End If

                        '-->Para la impresion
                        feventa.producto = IIf(dt.Rows(0).Item("idprocesos") = 11, "EQUIPAJE", "CARGA ACOMPAÑADA")

                        feventa.destino = dt.Rows(0).Item("destino")
                        If dt.Rows(0).Item("idprocesos") = 11 Then
                            Dim strCodigo As String = obj.ListarCodigo(dt.Rows(0).Item("id"), i)
                            feventa.origen = dt.Rows(0).Item("agencia_destino")
                            feventa.remitenete = i.ToString.Trim & "/" & intCantidad
                            feventa.consignado = dt.Rows(0).Item("servicio")
                            feventa.tipoEntrega = dt.Rows(0).Item("fecha_partida")
                            feventa.direccionEntrega = dt.Rows(0).Item("hora_partida")
                            feventa.cliente.direccion = strCodigo
                            feventa.formaPago = dt.Rows(0).Item("serie_factura") & "-" & dt.Rows(0).Item("nro_factura")
                        Else
                            feventa.origen = dt.Rows(0).Item("origen")
                            feventa.remitenete = dt.Rows(0).Item("cliente")
                            feventa.consignado = dt.Rows(0).Item("cliente")
                            feventa.tipoEntrega = "AGENCIA"
                            feventa.direccionEntrega = "AGENCIA"
                        End If
                        feventa.agenciaEmision = dt.Rows(0).Item("agencia")
                        feventa.usuarioEmision = dt.Rows(0).Item("usuario")

                        feventa.detalleVenta = FEManager.CrearDetalleVenta(dt)
                        feventa.id = dt.Rows(0).Item("id")
                        feventa.tabla = "T_FACTURA_CONTADO"

                        Dim result As New servicefe.Result
                        'Dim result As New feserviceDesarrollo.Result
                        If dt.Rows(0).Item("idprocesos") = 11 Then
                            prn.Print(feventa, "04", dtImpresora, result)
                        Else
                            prn.Print(feventa, "04", dtImpresora, result, 1)
                        End If
                    Next
                End If
            End With
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TxtBoletoViaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBoletoViaje.KeyPress
        If ValidaNumero2(e.KeyChar) Then
            e.Handled = False
        ElseIf Asc(e.KeyChar.ToString.ToUpper) >= 65 And Asc(e.KeyChar.ToString.ToUpper) <= 90 Then 'e.KeyChar.ToString.ToUpper = "F" Or e.KeyChar.ToString.ToUpper = "B" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtClienteDNIRUC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClienteDNIRUC.TextChanged

    End Sub

    Private Sub btnImprimirComprobante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirComprobante.Click
        Try
            If (MessageBox.Show("¿Desea imprimir el Ticket?", "Impresión de Ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                Cursor = Cursors.WaitCursor
                Dim intTipo As Integer = DgvLista.CurrentRow.Cells("idtipo_comprobante").Value
                Dim intId As Integer = DgvLista.CurrentRow.Cells("Idfactura").Value
                Dim obj As New dtoGuiasTransp
                Dim dt As DataTable = obj.ListarComprobante(intTipo, intId, 1)

                '--->Realiza la reimpresion del Ticket del Comprobante seleccionado
                reimpresionTicket(dt)

                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Imprimir Ticket", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Sub reimpresionTicket(ByVal dataTable As DataTable)
        For Each row As DataRow In dataTable.Rows
            Dim fecliente As New FECliente
            fecliente.tipoDocumentoID = row.Item("tipo_documento").ToString()
            fecliente.numeroDocumento = row.Item("numero_documento").ToString()
            fecliente.nombres = row.Item("cliente").ToString()
            fecliente.direccion = IIf(IsDBNull(row.Item("direccion_origen")), "", row.Item("direccion_origen").ToString())
            Dim venta As New FEVenta
            Dim serie As String = row.Item("Comprobante").ToString().Split("-")(0)
            Dim correlativo As String = row.Item("Comprobante").ToString().Split("-")(1)
            venta.cliente = fecliente
            venta.numeroSerie = serie
            venta.numeroCorrelativo = correlativo
            venta.fechaEmision = Convert.ToDateTime(row.Item("fecha_emision").ToString()).ToString("dd/MM/yyyy")
            venta.tipoComprobanteID = row.Item("Tipo")
            venta.opGravada = row.Item("monto_sub_total")
            venta.igv = row.Item("monto_impuesto")
            venta.total = row.Item("total_costo")
            venta.totalLetras = ConvercionNroEnLetras(venta.total)
            venta.formaPago = row.Item("tipo_pago").ToString()
            venta.producto = row.Item("producto").ToString()
            venta.origen = row.Item("origen").ToString()
            'venta.destino = row.Item("destino").ToString()
            Dim strCiudad As String = dtoVentaCargaContado.CiudadComprobante(row.Item("tipo"), row.Item("id"), 2)
            If strCiudad.Trim.ToUpper = row.Item("destino").ToString.Trim.ToUpper Then
                venta.destino = row.Item("destino").ToString()
            Else
                venta.destino = strCiudad
            End If

            venta.remitenete = fecliente.nombres
            venta.consignado = row.Item("consignado").ToString()
            venta.tipoEntrega = row.Item("tipo_entrega").ToString()
            venta.direccionEntrega = IIf(row("tipo_entrega") = "AGENCIA", row("agencia_destino"), row.Item("direccion_destino").ToString())
            venta.agenciaEmision = row.Item("agencia_emision").ToString()
            venta.usuarioEmision = row.Item("usuario").ToString()

            Dim result = FEManager.reimprimirComprobante(venta)
            If Not (result.isCorrect) Then
                MessageBox.Show("No se puedo imprimir el Comprobante N° " & row.Item("Comprobante").ToString(), "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Next
    End Sub

    Public Function GrabarVenta() As Boolean
        Dim flat As Boolean = False
        Try
            'PARAMETRO TIPO_COMPROBANTE
            ObjVentaCargaContado.v_IDTIPO_COMPROBANTE = TipoComprobante
            'PARAMETRO v_SERIE_FACTURA******************************************
            ObjVentaCargaContado.v_SERIE_FACTURA = TxtSerie.Text.Trim

            'PARAMETRO v_NRO_FACTURA********************************************
            'If TxtNroDocCliente.Text <> "" Then
            ObjVentaCargaContado.v_NRO_FACTURA = RellenoRight(Mro_Digitos_Ventas, TxtNroDoc.Text)
            TxtNroDoc.Text = RellenoRight(Mro_Digitos_Ventas, TxtNroDoc.Text)
            'End If
            'PARAMETRO FECHA INGRESO (FECHA_FACTURA)****************************
            If bControlFiscalizacion = False Then
                ObjVentaCargaContado.v_FECHA_FACTURA = Format("DD/MM/YYYY", Me.TxtFecha.Text)
            Else
                ObjVentaCargaContado.v_FECHA_FACTURA = Format("DD/MM/YYYY", Me.TxtFecha.Text)
            End If
            'PARAMETRO PRODUCTO (IDPROCESOS)************************************
            ObjVentaCargaContado.v_iProceso = CboProducto.SelectedValue
            'PARAMETRO TIPO TARIFA**********************************************
            ObjVentaCargaContado.TipoTarifa = CboTipoTarifa.SelectedValue
            'PARAMETROS CIUDAD ORIGEN (IDUNIDAD_ORIGEN)*************************
            ObjVentaCargaContado.v_IDUNIDAD_ORIGEN = CboCiudadOrigen.SelectedValue 'dtoUSUARIOS.m_idciudad
            'PARAMETRO AGENCIA ORIGEN*******************************************
            ObjVentaCargaContado.v_IDAGENCIAS = CboAgenciaOrigen.SelectedValue 'dtoUSUARIOS.m_iIdAgencia

            'PARAMETRO CIUDAD DESTINO*******************************************
            If idUnidadAgencias > 0 Then
                'PARAMETRO (IDCIUDAD_DESTINO)***********************************
                ObjVentaCargaContado.v_IDUNIDAD_DESTINO = idUnidadAgencias
                'PARAMETRO (IDAGENCIA_DESTINO*********************************
                ObjVentaCargaContado.v_IDAGENCIAS_DESTINO = CboAgenciaDest.SelectedValue 'Int(ObjVentaCargaContado.coll_AgenciasVenta(CboAgenciaDest.SelectedIndex.ToString))
            End If

            'PARAMETRO TIPO ENTREGA (IDTIPO_ENTREGA)****************************
            ObjVentaCargaContado.v_IDTIPO_ENTREGA = Me.CboTipoEntrega.SelectedValue 'Int(ObjVentaCargaContado.coll_t_Tipo_Entrega(CboTipoEntrega.SelectedIndex.ToString))
            'PARAMETRO TIPO PAGO (IDTIPO_PAGO)**********************************
            ObjVentaCargaContado.v_IDTIPO_PAGO = Int(ObjVentaCargaContado.coll_Tipo_Pago(CboFormaPago.SelectedIndex.ToString))

            'PARAMETRO TARGETAS (IDTARJETAS)************************************
            ObjVentaCargaContado.v_IDTARJETAS = 0
            ObjVentaCargaContado.v_NROTARJETA = "@"
            If ObjVentaCargaContado.v_IDTIPO_PAGO = 2 Then
                'PARAMETRO IDTARJETAS******            
                ObjVentaCargaContado.v_IDTARJETAS = Int(ObjVentaCargaContado.coll_T_TARJETAS(CboTarjeta.SelectedIndex.ToString))
                'PARAMETRO NROTARJETA******
                ObjVentaCargaContado.v_NROTARJETA = IIf(TxtNroTarjeta.Text <> "", TxtNroTarjeta.Text, "@")
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
            ObjVentaCargaContado.ID_TipoDocCli = iID_TipoDocCli '--->agre
            ObjVentaCargaContado.NombresCliente = sNombresCli
            ObjVentaCargaContado.apellPatCli = sApCli
            ObjVentaCargaContado.apellMatCli = sAmCli
            ObjVentaCargaContado.TelefCliente = IIf(sTelfCliente.Length > 0, sTelfCliente.Trim, "@")
            ObjVentaCargaContado.sEmail = sEmail

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
            ObjVentaCargaContado.v_NOMBRES_REMITENTE = IIf(Trim(CboContacto.Text) <> "", CboContacto.Text, "@") 'p
            ObjVentaCargaContado.contacto_mod = IIf(bContactoModificado, 1, 0)
            ObjVentaCargaContado.v_NRO_DOC_REMITENTE = IIf(Trim(TxtNroDocContacto.Text) <> "", TxtNroDocContacto.Text, "@")
            ObjVentaCargaContado.ID_TipoDocCont = iID_TipoDocCont
            ObjVentaCargaContado.NombreCont = NombresCont
            ObjVentaCargaContado.apellPatCont = apellPatCont
            ObjVentaCargaContado.apellMatCont = apellMatCont

            '======================================CONSIGNADO=================================
            '***Comentado x Nconsignado**********************************************
            'PARAMETRO ID_NOMBRE_CONSIGNADO**
            'If Me.TxtNroDocConsignado.Tag = 0 AndAlso Me.ChkCliente2.Checked Then
            '    Dim objContacto As New dtoVentaCargaContado
            '    Dim dt As DataTable = objContacto.BuscarContacto(TxtNroDocConsignado.Text)
            '    Dim resp As Integer = dt.Rows.Count
            '    If resp = 0 Then
            '        Me.TxtNroDocConsignado.Tag = 0
            '    Else
            '        Me.TxtNroDocConsignado.Tag = dt.Rows(0).Item(0)
            '        bConsignadoModificado = False
            '    End If
            'End If
            '************************************************************************

            '===Cambio(Agregado) NConsignado==========================================
            If iNroDocumentoTag = 0 AndAlso Me.ChkCliente2.Checked Then
                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.BuscarContacto(GrdNConsignado("Nº Documento", 0).Value)
                Dim resp As Integer = dt.Rows.Count
                If resp = 0 Then
                    iNroDocumentoTag = 0
                    GrdNConsignado("IDConsignado", 0).Value = "0"
                Else
                    iNroDocumentoTag = dt.Rows(0).Item(0)
                    GrdNConsignado("IDConsignado", 0).Value = dt.Rows(0).Item(0)
                    bConsignadoModificado = False
                End If
            End If
            '=========================================================================

            '***Comentado x NConsignado***********************************************
            'ObjVentaCargaContado.v_IDCONTACTO_DESTINO = IIf(IsNothing(Me.TxtNroDocConsignado.Tag), 0, Me.TxtNroDocConsignado.Tag)
            ''ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = IIf(Trim(sNombresConsig.Trim) <> "", sNombresConsig.Trim, "@")
            'ObjVentaCargaContado.v_NOMBRES_DESTINATARIO = IIf(Me.TxtNombConsignado.Text.Trim <> "", Me.TxtNombConsignado.Text.Trim, "@")
            'ObjVentaCargaContado.NombConsignado_mod = IIf(bConsignadoModificado, 1, 0)
            'ObjVentaCargaContado.v_NRO_DOC_DESTINATARIO = IIf(Trim(TxtNroDocConsignado.Text) <> "", TxtNroDocConsignado.Text, "@")
            'ObjVentaCargaContado.ID_TipoDocConsig = iID_TipoDocConsig
            'ObjVentaCargaContado.NombreConsignado = sNombresConsig
            'ObjVentaCargaContado.apellPatConsig = sapellPatConsig
            'ObjVentaCargaContado.apellMatConsig = sapellMatConsig
            'ObjVentaCargaContado.TelfConsignado = IIf(sTelefonoConsig.Length > 0, sTelefonoConsig, "@")

            '===Agregado x NConsignado================================================
            Me.LimpiarNConsignados()
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
            '=================================================================================

            '--DIRECCION ESTRUCTURADA CONSIGNADO
            'PARAMETRO ID_DIRECCION_DESTINO**
            If CboDireccion2.SelectedIndex = 0 Then
                idDireConsignado = -1
            End If
            ObjVentaCargaContado.v_IDDIREECION_DESTINO = idDireConsignado
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
            ObjVentaCargaContado.sReferencia = TxtReferencia.Text.Trim

            '---Nuevos Parametros a agregar---
            ObjVentaCargaContado.TarifarioGeneral = IIf(bTarifarioGeneral, 1, 0)
            ObjVentaCargaContado.Contado = IIf(bContado, 1, 0)

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
            ObjVentaCargaContado.v_cargo = Me.rbtCargoSi.Checked
            'hlamas 26-08-2015
            'If TieneCargo(Me.GrdDocumentosCliente, 2) Then
            'ObjVentaCargaContado.v_cargo = True
            'Me.ChkCargo.Checked = True
            'End If

            'ObjVentaCargaContado.v_idagencia_venta = dtoUSUARIOS.m_iIdAgencia
            'ObjVentaCargaContado.v_idciudad_venta = dtoUSUARIOS.m_idciudad
            ObjVentaCargaContado.v_idagencia_venta = 0
            ObjVentaCargaContado.v_idciudad_venta = 0

            If CboProducto.SelectedValue = 6 Then 'PARAMETROS CARGA ACOMPAÑADA
                ObjVentaCargaContado.v_idagencia_venta = CboAgenciaOrigen.SelectedValue 'dtoUSUARIOS.m_iIdAgencia
                ObjVentaCargaContado.v_idciudad_venta = CboCiudadOrigen.SelectedValue 'dtoUSUARIOS.m_idciudad
                ObjVentaCargaContado.v_nroboleto = Me.TxtBoleto.Text
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
                'hlamas 18-07-2015
            ElseIf CboProducto.SelectedValue = 9 Then 'PARAMETROS ESTANDAR(NORMAL)
                ObjVentaCargaContado.v_nroboleto = ""
                ObjVentaCargaContado.v_carga_acompañada = 0 'Nota                
                ObjVentaCargaContado.bOrigenDiferente = False
                ObjVentaCargaContado.v_TIPO_DOCUMENTO = 0
            ElseIf CboProducto.SelectedValue = 10 Then 'PARAMETROS ESTANDAR(NORMAL)
                ObjVentaCargaContado.v_nroboleto = ""
                ObjVentaCargaContado.v_carga_acompañada = 0 'Nota                
                ObjVentaCargaContado.bOrigenDiferente = False
                ObjVentaCargaContado.v_TIPO_DOCUMENTO = 0
            End If

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

                'VOLUMEN
                If IsDBNull(GrdDetalleVenta.Rows(1).Cells(2)) = False Then
                    If Conversion.Val(GrdDetalleVenta(1, 1).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta(1, 1).Value
                    If Conversion.Val(GrdDetalleVenta(2, 1).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta(2, 1).Value
                    ObjVentaCargaContado.v_CANTIDAD_X_VOLUMEN = valor1
                    ObjVentaCargaContado.v_TOTAL_VOLUMEN = valor2
                    totalCosto = totalCosto + valor2 * tarifa_Volumen
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
                tarifa_Volumen = Format(Val(GrdDetalleVenta(3, 1).Value), "##,###,###.00")

                If CboProducto.SelectedValue <> 81 And CboProducto.SelectedValue <> 82 Then
                    tarifa_Sobre = Format(Val(GrdDetalleVenta(3, 2).Value), "##,###,###.00")
                    'hlamas 18-07-2015
                    If Val(GrdDetalleVenta.Rows(0).Cells(4).Value) = 0 And Val(GrdDetalleVenta.Rows(1).Cells(4).Value) = 0 And Val(GrdDetalleVenta.Rows(2).Cells(4).Value) = 0 And tarifa_Sobre = 0 Then
                        tarifa_Sobre = CDbl(Me.TxtTotal.Text)
                    End If
                End If
            End If

            '******************************GRID M3*********************************
            If ChkM3.Checked = True Then
                'PESO
                If IsDBNull(GrdDetalleVenta.Rows(0).Cells(2)) = False Then
                    '-------
                    If Conversion.Val(GrdDetalleVenta(1, 0).Value) = 0 Then valor1 = 0 Else valor1 = GrdDetalleVenta(1, 0).Value
                    If Conversion.Val(GrdDetalleVenta(5, 0).Value) = 0 Then valor2 = 0 Else valor2 = GrdDetalleVenta(5, 0).Value
                    '-------
                    ObjVentaCargaContado.v_CANTIDAD_X_PESO = valor1
                    ObjVentaCargaContado.v_TOTAL_PESO = valor2
                    totalCosto = valor2 * tarifa_Peso
                End If

                'SOBRE
                If Val(txtCantidadSobres.Text) > 0 Then
                    valor1 = Val(txtCantidadSobres.Text)
                    ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = valor1
                    totalCosto = totalCosto + valor1 * tarifa_Sobre
                End If

                '************                
                ObjVentaCargaContado.v_METROCUBICO = 1
                ObjVentaCargaContado.v_ALTURA = FormatNumber(Format(Val(GrdDetalleVenta(2, 0).Value), "##,###,###.00"), 2)
                ObjVentaCargaContado.v_ANCHO = Format(Val(GrdDetalleVenta(3, 0).Value), "##,###,###.00")
                ObjVentaCargaContado.v_LARGO = Format(Val(GrdDetalleVenta(4, 0).Value), "##,###,###.00")
                ObjVentaCargaContado.v_PESO_KG = Format(Val(GrdDetalleVenta(5, 0).Value), "##,###,###.00")
                ObjVentaCargaContado.v_FACTOR = Factor_
                '************

                '*******
                tarifa_Peso = Format(Val(GrdDetalleVenta(6, 0).Value), "##,###,###.00")
                tarifa_Sobre = Format(Val(txtMontoBase.Text), "##,###,###.00")
                '*******
            Else
                ObjVentaCargaContado.v_METROCUBICO = 0
                ObjVentaCargaContado.v_ALTURA = 0
                ObjVentaCargaContado.v_ANCHO = 0
                ObjVentaCargaContado.v_LARGO = 0
                ObjVentaCargaContado.v_PESO_KG = 0
                ObjVentaCargaContado.v_FACTOR = 0
            End If

            If chkSobres.Checked = True Then
                ObjVentaCargaContado.v_CANTIDAD_X_SOBRE = Val(txtCantidadSobres.Text)
            End If

            ObjVentaCargaContado.v_PRECIO_X_PESO = tarifa_Peso
            ObjVentaCargaContado.v_PRECIO_X_VOLUMEN = tarifa_Volumen
            ObjVentaCargaContado.v_PRECIO_X_SOBRE = tarifa_Sobre


            ObjVentaCargaContado.v_MONTO_SUB_TOTAL = TxtSubtotal.Text
            ObjVentaCargaContado.v_MONTO_IMPUESTO = TxtImpuesto.Text
            ObjVentaCargaContado.v_TOTAL_COSTO = TxtTotal.Text

            ObjVentaCargaContado.v_IDTIPO_MONEDA = 1 'Soles
            '---USUARIO REMOTO--------
            ObjVentaCargaContado.v_IDUSUARIO_PERSONAL = Me.CboListaUsuarios.SelectedValue 'dtoUSUARIOS.IdLogin 08102011
            ObjVentaCargaContado.iIDUsuarioRemoto = dtoUSUARIOS.IdLogin '08102011
            '-------------------------

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

            '********************fin grid articulos*********************************************************
            '----------------------------------------------------------------------------------------------------------------------------            
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

            ObjIMPRESIONFACT_BOL.xDestino = TxtCiudadDestino.Text
            ObjIMPRESIONFACT_BOL.xNRODOCFAC_BOL = Me.TxtSerie.Text & "-" & Me.TxtNroDoc.Text
            ObjIMPRESIONFACT_BOL.xRazonSocial = Me.TxtNomCliente.Text.Trim
            ObjIMPRESIONFACT_BOL.xDireccionRemitente = Me.CboDireccion.Text.Trim
            ObjIMPRESIONFACT_BOL.xRuc = TxtNroDocCliente.Text
            ObjIMPRESIONFACT_BOL.xConsignado = ObjVentaCargaContado.v_NOMBRES_DESTINATARIO 'GrdNConsignado("Nombres", 0).Value 'Me.TxtNombConsignado.Text NConsignado
            'ObjIMPRESIONFACT_BOL.xDireccionConsignado = Me.TxtDirecConsignado.Text'verificar
            ObjIMPRESIONFACT_BOL.xDireccionConsignado = Me.CboDireccion2.Text & IIf(Me.CboTipoEntrega.SelectedValue = TipoEntrega.Agencia, " " & Me.CboAgenciaDest.Text, "")
            ObjIMPRESIONFACT_BOL.xfecha_factura = Me.TxtFecha.Text
            ObjIMPRESIONFACT_BOL.xTotalPeso = ObjVentaCargaContado.v_TOTAL_PESO
            ObjIMPRESIONFACT_BOL.xTotalVolumen = ObjVentaCargaContado.v_TOTAL_VOLUMEN
            ObjIMPRESIONFACT_BOL.xTotalSobres = 0
            ObjIMPRESIONFACT_BOL.xNroRef = Me.TxtSerie.Text & "-" & Me.TxtNroDoc.Text
            ObjIMPRESIONFACT_BOL.xMemo = Me.txtDescDescto.Text
            ObjIMPRESIONFACT_BOL.xMonto_Sub_Total = Me.TxtSubtotal.Text
            ObjIMPRESIONFACT_BOL.xMonto_Impuesto = TxtImpuesto.Text
            ObjIMPRESIONFACT_BOL.xTotal_Costo = ObjVentaCargaContado.v_TOTAL_COSTO
            ObjIMPRESIONFACT_BOL.xDescuento = IIf(TxtDescuento.Text <> "", TxtDescuento.Text, "")
            ObjIMPRESIONFACT_BOL.xAgenciaDestino = IIf(CboAgenciaDest.Text <> "", CboAgenciaDest.Text, "")
            ObjIMPRESIONFACT_BOL.xTIPO_ENTREGA = CboTipoEntrega.Text

            If ObjVentaCargaContado.v_MONTO_SUB_TOTAL + ObjVentaCargaContado.v_MONTO_IMPUESTO <> ObjVentaCargaContado.v_TOTAL_COSTO Then
                ObjVentaCargaContado.v_MONTO_SUB_TOTAL = FormatNumber(Format(ObjVentaCargaContado.v_TOTAL_COSTO / 1.18, "###,###,###.00"), 2)
                ObjVentaCargaContado.v_MONTO_IMPUESTO = FormatNumber(Format(0.18 * ObjVentaCargaContado.v_TOTAL_COSTO / 1.18, "###,###,###.00"), 2)
                Me.TxtSubtotal.Text = Format(ObjVentaCargaContado.v_MONTO_SUB_TOTAL, "###,###,###.00")
                Me.TxtImpuesto.Text = Format(ObjVentaCargaContado.v_MONTO_IMPUESTO, "###,###,###.00")
            End If

            'hlamas 16-05-2017
            Dim dlgPago As New frmPagoContado
            dlgPago.Numero = TxtNroDocCliente.Text.Trim
            dlgPago.Cliente = TxtNomCliente.Text.Trim
            dlgPago.TotalVenta = CType(TxtTotal.Text, Double).ToString("0.00")
            dlgPago.intCuentaCorriente = 0
            If dlgPago.ShowDialog() = Windows.Forms.DialogResult.OK Then
                'If dlgPago.txtPagoSoles.Text > 0 Then
                lblTotalPagado.Visible = True
                lblTotalVenta.Visible = True
                lblVuelto.Visible = True
                txtTotalPagado.Visible = True
                txtTotalVenta.Visible = True
                txtVuelto.Visible = True
                txtTotalVenta.Text = FormatNumber(TxtTotal.Text, 2)
                txtTotalPagado.Text = FormatNumber(dlgPago.lblTotalPago.Text, 2)
                txtVuelto.Text = FormatNumber(dlgPago.lblVuelto.Text, 2)
                'End If
                asignar_documentos_clientes()

                If ObjVentaCargaContado.GrabarV = True Then
                    iCliente = ObjVentaCargaContado.v_IDPERSONA
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
                    ObjPagosSoles.v_idfactura_contado = ObjVentaCargaContado.v_IDFACTURA
                    ObjPagosDolares.v_idfactura_contado = ObjVentaCargaContado.v_IDFACTURA
                    ObjIMPRESIONFACT_BOL.xIdFactura = ObjVentaCargaContado.v_IDFACTURA.ToString

                    '-------------------------------------------
                    'INSERCION VOLUMETRICO
                    '-------------------------------------------
                    Try
                        If ChkM3.Checked = True Then
                            Dim obj As New dtoVentaCargaContado
                            Dim ii As Integer = 0
                            objGuia_Envio_Articulo.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
                            objGuia_Envio_Articulo.iIGV = dtoUSUARIOS.iIGV
                            objGuia_Envio_Articulo.iIP = dtoUSUARIOS.IP
                            objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = CboListaUsuarios.SelectedValue 'dtoUSUARIOS.IdLogin 'USUARIO REMOTO
                            objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol

                            For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                                If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                                    If GrdDetalleVenta.Rows(ii).Cells("sub neto").Value > 0 And IsNumeric(GrdDetalleVenta.Rows(ii).Cells("tipo").Value) Then
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
                                                 Factor_,
                                                 GrdDetalleVenta.Rows(ii).Cells("Costo").Value)
                                    End If
                                End If
                            Next
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try


                    '-------------------------------------------
                    'INSERCION DE ARTICULOS
                    '------------------------------------------- 
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
                            objGuia_Envio_Articulo.iIDUSUARIO_PERSONAL = CboListaUsuarios.SelectedValue 'dtoUSUARIOS.IdLogin USUARIO REMOTO
                            objGuia_Envio_Articulo.iIDROL_USUARIO = dtoUSUARIOS.IdRol

                            objGuia_Envio_Articulo.iIDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                            objGuia_Envio_Articulo.iIDESTADO_REGISTRO = 18
                            For ii = 0 To Me.GrdDetalleVenta.Rows().Count() - 1
                                If IsDBNull(GrdDetalleVenta.Rows(ii).Cells(2)) = False Then
                                    'hlamas 21-01-2016
                                    If GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString <> "" And GrdDetalleVenta.Rows(ii).Cells(0).Value <> "ENTREGA" Then
                                        objGuia_Envio_Articulo.iIDARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(5).Value.ToString)
                                        objGuia_Envio_Articulo.iCANTIDAD_ARTICULOS = Int(GrdDetalleVenta.Rows(ii).Cells(2).Value.ToString)
                                        objGuia_Envio_Articulo.iPESO = Int(GrdDetalleVenta.Rows(ii).Cells(3).Value.ToString)
                                        objGuia_Envio_Articulo.iPRECIO_X_ARTICULO = Microsoft.VisualBasic.Conversion.Val(GrdDetalleVenta.Rows(ii).Cells(1).Value.ToString)
                                        objGuia_Envio_Articulo.fnINSTUPD_FACBOL_ARTICULOS()
                                    End If
                                End If
                            Next
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try


                    flat = True
                    Dim i As Integer = 0
                    Dim serie_NroDoc() As String
                    objGuiaEnvio.iControl_Documentos = 1
                    objGuiaEnvio.iIDGUIAS_ENVIO = ObjIMPRESIONFACT_BOL.xIdFactura
                    objGuiaEnvio.V_IDTIPO_COMPROBANTE = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                    objGuiaEnvio.iIDUSUARIO_PERSONAL = CboListaUsuarios.SelectedValue 'USUARIO REMOTO
                    Dim iContador As Integer = 0

                    '-------------------------------------------
                    'INICIO DE DOCUMENTOS DEL CLIENTE
                    '-------------------------------------------                     
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

                    'If MessageBox.Show("¿Esta Seguro de Imprimir la Etiquetas?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    '    If xIMPRESORA = 1 Or xIMPRESORA = 4 Then
                    '        fnImprimirEtiquetas()
                    '    Else
                    '        If xIMPRESORA = 2 Then
                    '            fnImprimirEtiquetasFAC_II()
                    '        Else
                    '            fnImprimirEtiquetasFAC_III()
                    '        End If
                    '    End If
                    'End If
                    'End If

                    'hlamas 05-05-2017
                    'Grabar tipo de pagos
                    GrabarTipoPago(dlgPago, ObjVentaCargaContado.v_IDFACTURA)

                    'hlamas 16-05-2017
                    GrabarNotaCredito(dlgPago, ObjVentaCargaContado.v_IDPERSONA)

                    fnNUEVO()
                    limpiar_documentos_cliente()
                    flat = True
                    iOficinaDestino = 0
                    iOficinaOrigen = 0
                Else
                    lblTotalPagado.Visible = False
                    lblTotalVenta.Visible = False
                    lblVuelto.Visible = False
                    txtTotalPagado.Visible = False
                    txtTotalVenta.Visible = False
                    txtVuelto.Visible = False
                    MessageBox.Show("La Venta no se Registró", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                lblTotalPagado.Visible = False
                lblTotalVenta.Visible = False
                lblVuelto.Visible = False
                txtTotalPagado.Visible = False
                txtTotalVenta.Visible = False
                txtVuelto.Visible = False
                'MsgBox("Cancelo Operacion Puede Intentar el Pago de Nuevo", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
            bOrigenDiferente = False
        Catch ex As Exception
            flat = False
            Throw New Exception(ex.Message)
        End Try
        Return flat
    End Function

    Sub GrabarTipoPago(ByVal frm As frmPagoContado, ByVal comprobante As Integer)
        Try
            Dim obj As New dtoVentaCargaContado

            With frm
                For Each row As DataGridViewRow In .dgvPago.Rows
                    obj.GrabarTipoPago(comprobante, row.Cells("tipo_pago").Value, row.Cells("tipo_tarjeta").Value, row.Cells("afecto").Value, _
                                       row.Cells("pago").Value, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, row.Cells("tarjeta").Value)
                Next
            End With
        Catch
        End Try
    End Sub

    Public Sub imprime(ByVal documento As Integer, ByVal factura As Integer, Optional ByVal serie As String = "", Optional ByVal numero As String = "")
        Dim obj As New Imprimir
        Try
            Dim ldt_cur_datos_venta As New DataTable
            Dim lds_tmp As New DataSet
            '
            Dim flag As Boolean = False
            Dim iSubTotal As Double = 0, iImpuesto As Double = 0, iTotal As Double = 0
            lds_tmp = ObjVentaCargaContado.fn_SP_VER_VENTACONTADO_I(factura)
            '
            ldt_cur_datos_venta = lds_tmp.Tables(0)
            '
            'Dim objImpresora As New dtoVentaCargaContado
            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim objImprimir As New ImprimirTexto()
            Dim sImpresora As String = ""
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0
            '
            If documento = 85 Then
                documento = 3
            End If
            'flag = objImpresora.fnSP_Buscar_Impresora(documento, dtoUSUARIOS.IP)
            Dim dt As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, documento)
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
                Dim sDocumento As String
                If documento = 1 Then
                    sDocumento = "factura"
                ElseIf documento = 2 Then
                    sDocumento = "boleta"
                Else
                    sDocumento = "guia"
                End If
                'objImprimir = New ImprimirTexto("Draft Condensed", 8, objImpresora.v_Impresora, sDocumento, 1305, 1305)
                Dim strSerie As String, strNumero As String
                strSerie = serie
                strNumero = numero.PadLeft(7, "0")
                If documento = 1 Then       'Factura
                    obj = New Imprimir
                    obj.Inicializar()
                    obj.Superior = iSuperior
                    obj.Izquierda = Iizquierda
                    obj.Impresora = sImpresora

                    Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
                    Dim iLong As Integer = IIf(iTamaño = 0, 36, iTamaño)

                    y = iLong * pagina + 4
                    y += 1
                    i += 1

                    'obj.EscribirLinea(y, 48, ldt_cur_datos_venta.Rows(0).Item("serie_factura") & "-" & ldt_cur_datos_venta.Rows(0).Item("nro_factura"))
                    obj.EscribirLinea(y, 48, strSerie & "-" & strNumero)

                    If ldt_cur_datos_venta.Rows(0).Item("es_carga_asegurada") = 1 Then
                        obj.EscribirLinea(y + 1, 48, ldt_cur_datos_venta.Rows(0).Item("agencia_destino") & v_ca)
                    Else
                        obj.EscribirLinea(y + 1, 48, ldt_cur_datos_venta.Rows(0).Item("agencia_destino"))
                    End If

                    '.HeaderText = "Producto"
                    '.Name = "Proceso"
                    obj.EscribirLinea(y + 0, 75, ldt_cur_datos_venta.Rows(0).Item("Producto")) 'cambio
                    obj.EscribirLinea(y + 2, 53, ldt_cur_datos_venta.Rows(0).Item("hora_factura"))
                    obj.EscribirLinea(y + 4, 8, DatePart(DateInterval.Day, ldt_cur_datos_venta.Rows(0).Item("fecha_factura")).ToString.PadLeft(2, "0"))
                    obj.EscribirLinea(y + 4, 23, DatePart(DateInterval.Month, ldt_cur_datos_venta.Rows(0).Item("fecha_factura")).ToString.PadLeft(2, "0"))
                    obj.EscribirLinea(y + 4, 42, DatePart(DateInterval.Year, ldt_cur_datos_venta.Rows(0).Item("fecha_factura")))
                    obj.EscribirLinea(y + 5, 13, ldt_cur_datos_venta.Rows(0).Item("razon_social"))
                    obj.EscribirLinea(y + 6, 13, ldt_cur_datos_venta.Rows(0).Item("dirorigen"))

                    obj.EscribirLinea(y + 7, 13, ldt_cur_datos_venta.Rows(0).Item("origen"))
                    obj.EscribirLinea(y + 8, 13, ldt_cur_datos_venta.Rows(0).Item("destinatario"))
                    obj.EscribirLinea(y + 9, 13, ldt_cur_datos_venta.Rows(0).Item("dirdestino"))
                    obj.EscribirLinea(y + 5, 66, ldt_cur_datos_venta.Rows(0).Item("Nu_Docu_Suna"))
                    obj.EscribirLinea(y + 7, 66, ldt_cur_datos_venta.Rows(0).Item("destino"))
                    'obj.EscribirLinea(y + 5, 105, ldt_cur_datos_venta.Rows(0).Item("serie_factura") & "-" & ldt_cur_datos_venta.Rows(0).Item("nro_factura"))
                    obj.EscribirLinea(y + 5, 105, strSerie & "-" & strNumero)

                    If ldt_cur_datos_venta.Rows(0).Item("Idforma_Pago") = 1 Then
                        obj.EscribirLinea(y + 7, 105, "CONTADO")
                    ElseIf ldt_cur_datos_venta.Rows(0).Item("Idforma_Pago") = 2 Then
                        obj.EscribirLinea(y + 7, 105, "CREDITO")
                    Else
                        obj.EscribirLinea(y + 7, 105, "PAGO CONTRA ENTREGA")
                    End If

                    If ldt_cur_datos_venta.Rows(0).Item("Idtipo_Entrega") = 1 Then
                        If ldt_cur_datos_venta.Rows(0).Item("agencia_destino").ToString.Trim.Length > 20 Then
                            obj.EscribirLinea(y + 8, 105, "AGENCIA" & " " & ldt_cur_datos_venta.Rows(0).Item("agencia_destino").ToString.Trim.Substring(0, 20))
                        Else
                            obj.EscribirLinea(y + 8, 105, "AGENCIA" & " " & ldt_cur_datos_venta.Rows(0).Item("agencia_destino"))
                        End If
                    Else
                        obj.EscribirLinea(y + 8, 105, "DOMICILIO")
                    End If

                    If Convert.ToDouble(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Articulos").ToString) <> 0 Then
                        obj.EscribirLinea(y + 12, 13, ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Articulos"))
                    Else
                        obj.EscribirLinea(y + 12, 13, ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Peso"))
                    End If

                    obj.EscribirLinea(y + 12, 23, "BULTOS")
                    obj.EscribirLinea(y + 12, 92, ldt_cur_datos_venta.Rows(0).Item("total_peso"))
                    obj.EscribirLinea(y + 13, 13, ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Volumen"))
                    obj.EscribirLinea(y + 13, 23, "BULTOS (V.)")
                    obj.EscribirLinea(y + 13, 92, ldt_cur_datos_venta.Rows(0).Item("total_volumen"))
                    obj.EscribirLinea(y + 14, 13, ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Sobre"))
                    obj.EscribirLinea(y + 14, 23, "SOBRES")

                    If CDbl(ldt_cur_datos_venta.Rows(0).Item("Total_Costo")) > 400 Then
                        obj.EscribirLinea(y + 15, 23, "OPERACION SUJETA AL SISTEMA DE PAGO DE OBLIGACIONES TRIBUT.")
                        obj.EscribirLinea(y + 16, 23, "CON EL GOBIERNO CENTRAL,SEGUN D.L. N. 940 - R.S. N.")
                        obj.EscribirLinea(y + 17, 23, "158-2006-SUNAT/D.S. N. 033-2006-MTC.")
                        obj.EscribirLinea(y + 18, 23, "Sirvase,depositar a la Cta. del Bco. de la Nación N.0019-002829.")
                    End If
                    obj.EscribirLinea(y + 12, 110, ldt_cur_datos_venta.Rows(0).Item("Monto_Sub_Total").ToString.PadLeft(10, " "))

                    Dim montoLetras As String = ConvercionNroEnLetras(CDbl(ldt_cur_datos_venta.Rows(0).Item("Total_Costo")))
                    obj.EscribirLinea(y + 21, 11, "Son:  " & montoLetras)

                    obj.EscribirLinea(y + 23, 54, ldt_cur_datos_venta.Rows(0).Item("usuario"))
                    'obj.EscribirLinea(y + 22, 54, "19.00")

                    obj.EscribirLinea(y + 21, 85, "S/.")
                    obj.EscribirLinea(y + 22, 85, "S/.")
                    obj.EscribirLinea(y + 23, 85, "S/.")

                    obj.EscribirLinea(y + 21, 110, ldt_cur_datos_venta.Rows(0).Item("Monto_Sub_Total").ToString.PadLeft(10, " "))
                    obj.EscribirLinea(y + 22, 110, Format(CDbl(ldt_cur_datos_venta.Rows(0).Item("MONTO_IMPUESTO")), "####,###,###0.00").PadLeft(10, " "))
                    obj.EscribirLinea(y + 23, 110, Format(CDbl(ldt_cur_datos_venta.Rows(0).Item("Total_Costo")), "####,###,###0.00").PadLeft(10, " "))

                    obj.Comprimido = True
                    obj.Tamaño = iLong
                    obj.Imprimir()
                    obj.Finalizar()

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

                ElseIf documento = 2 Then   'Boleta
                    obj = New Imprimir
                    obj.Inicializar()
                    obj.Superior = iSuperior
                    obj.Izquierda = Iizquierda
                    obj.Impresora = sImpresora

                    Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
                    Dim iLong As Integer = IIf(iTamaño = 0, 18, iTamaño)

                    y = iLong * pagina + 4
                    y += 1
                    i += 1

                    Dim HoraSistema As String = fnGetHora()
                    obj.EscribirLinea(0, 13, ldt_cur_datos_venta.Rows(0).Item("Producto")) 'cambio
                    obj.EscribirLinea(y, 6, ldt_cur_datos_venta.Rows(0).Item("origen"))
                    obj.EscribirLinea(y + 1, 6, ldt_cur_datos_venta.Rows(0).Item("fecha_factura"))
                    obj.EscribirLinea(y + 2, 6, ldt_cur_datos_venta.Rows(0).Item("razon_social"))
                    obj.EscribirLinea(y + 3, 6, ldt_cur_datos_venta.Rows(0).Item("destinatario"))
                    obj.EscribirLinea(y + 4, 6, ldt_cur_datos_venta.Rows(0).Item("dirdestino"))
                    obj.EscribirLinea(y, 30, ldt_cur_datos_venta.Rows(0).Item("destino"))
                    obj.EscribirLinea(y + 1, 30, ldt_cur_datos_venta.Rows(0).Item("hora_factura"))

                    If ldt_cur_datos_venta.Rows(0).Item("Idforma_Pago") = 1 Then
                        obj.EscribirLinea(y + 1, 53, "CONTADO")
                    ElseIf ldt_cur_datos_venta.Rows(0).Item("Idforma_Pago") = 2 Then
                        obj.EscribirLinea(y + 1, 53, "CREDITO")
                    Else
                        obj.EscribirLinea(y + 1, 53, "PAGO CONTRA ENTREGA")
                    End If

                    If ldt_cur_datos_venta.Rows(0).Item("Idtipo_Entrega") = 1 Then
                        obj.EscribirLinea(y, 52, "AGENCIA" & " " & ldt_cur_datos_venta.Rows(0).Item("agencia_destino"))
                    Else
                        obj.EscribirLinea(y, 52, "DOMICILIO")
                    End If

                    '11
                    obj.EscribirLinea(y + 7, 16, "BULTOS   " & Val(Val(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Peso"))) + Val(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Volumen")))
                    obj.EscribirLinea(y + 7, 46, Val(ldt_cur_datos_venta.Rows(0).Item("total_peso")))
                    obj.EscribirLinea(y + 7, 56, Val(ldt_cur_datos_venta.Rows(0).Item("Total_Volumen")))
                    obj.EscribirLinea(y + 7, 67, Format(CDbl(ldt_cur_datos_venta.Rows(0).Item("Total_Costo")), "###,###,###.00"))

                    obj.EscribirLinea(y + 7, 84, "BULTOS  " & Val(Val(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Peso"))) + Val(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Volumen")))
                    obj.EscribirLinea(y + 7, 105, Val(ldt_cur_datos_venta.Rows(0).Item("Total_Volumen")))
                    obj.EscribirLinea(y + 7, 112, Val(ldt_cur_datos_venta.Rows(0).Item("total_peso")))
                    obj.EscribirLinea(y + 7, 121, Format(CDbl(ldt_cur_datos_venta.Rows(0).Item("Total_Costo")), "###,###,###.00"))

                    '12
                    obj.EscribirLinea(y + 8, 16, "SOBRES   " & Val(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Sobre")))
                    obj.EscribirLinea(y + 8, 84, "SOBRES  " & Val(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Sobre")))

                    obj.EscribirLinea(3, 33, ldt_cur_datos_venta.Rows(0).Item("serie_factura") & "-" & ldt_cur_datos_venta.Rows(0).Item("nro_factura"))
                    obj.EscribirLinea(y, 89, ldt_cur_datos_venta.Rows(0).Item("origen"))
                    obj.EscribirLinea(y + 1, 89, ldt_cur_datos_venta.Rows(0).Item("fecha_factura"))
                    obj.EscribirLinea(y + 2, 89, ldt_cur_datos_venta.Rows(0).Item("razon_social"))
                    obj.EscribirLinea(y + 3, 89, ldt_cur_datos_venta.Rows(0).Item("destinatario"))
                    obj.EscribirLinea(y + 4, 89, ldt_cur_datos_venta.Rows(0).Item("dirdestino"))
                    obj.EscribirLinea(y, 105, ldt_cur_datos_venta.Rows(0).Item("destino"))
                    obj.EscribirLinea(y + 1, 114, ldt_cur_datos_venta.Rows(0).Item("hora_factura"))

                    If ldt_cur_datos_venta.Rows(0).Item("Idforma_Pago") = 1 Then
                        obj.EscribirLinea(y + 1, 105, "CONTADO")
                    ElseIf ldt_cur_datos_venta.Rows(0).Item("Idforma_Pago") = 2 Then
                        obj.EscribirLinea(y + 1, 105, "CREDITO")
                    Else
                        obj.EscribirLinea(y + 1, 105, "PAGO CONTRA ENTREGA")
                    End If

                    If ldt_cur_datos_venta.Rows(0).Item("Idtipo_Entrega") = 1 Then
                        obj.EscribirLinea(y, 120, "AGENCIA" & " " & ldt_cur_datos_venta.Rows(0).Item("agencia_destino"))
                    Else
                        obj.EscribirLinea(y, 120, "DOMICILIO")
                    End If
                    obj.EscribirLinea(0, 0, factura)

                    If ldt_cur_datos_venta.Rows(0).Item("es_carga_asegurada") = 1 Then
                        obj.EscribirLinea(0, 30, v_ca)
                        obj.EscribirLinea(0, 16, ldt_cur_datos_venta.Rows(0).Item("usuario"))
                    Else
                        obj.EscribirLinea(0, 16, ldt_cur_datos_venta.Rows(0).Item("usuario"))
                    End If
                    obj.EscribirLinea(4, 30, ldt_cur_datos_venta.Rows(0).Item("agencia_destino"))
                    obj.EscribirLinea(3, 82, ldt_cur_datos_venta.Rows(0).Item("serie_factura") & "-" & ldt_cur_datos_venta.Rows(0).Item("nro_factura"))
                    obj.EscribirLinea(0, 82, factura)

                    If ldt_cur_datos_venta.Rows(0).Item("agencia_destino").ToString.Trim.Length > 20 Then
                        obj.EscribirLinea(4, 82, ldt_cur_datos_venta.Rows(0).Item("agencia_destino").ToString.Trim.Substring(0, 20))
                    Else
                        obj.EscribirLinea(4, 82, ldt_cur_datos_venta.Rows(0).Item("agencia_destino"))
                    End If
                    obj.EscribirLinea(0, 90, ldt_cur_datos_venta.Rows(0).Item("usuario"))
                    obj.EscribirLinea(y + 10, 67, Format(CDbl(ldt_cur_datos_venta.Rows(0).Item("Total_Costo")), "###,###,###.00"))
                    obj.EscribirLinea(y + 10, 121, Format(CDbl(ldt_cur_datos_venta.Rows(0).Item("Total_Costo")), "###,###,###.00"))
                    obj.EscribirLinea(0, 113, ldt_cur_datos_venta.Rows(0).Item("Producto")) 'cambio

                    obj.Comprimido = True
                    obj.Preliminar = True
                    obj.Tamaño = iLong
                    obj.Imprimir()
                    obj.Finalizar()

                    Dim frm As New FrmPreview
                    frm.Documento = 2
                    frm.Tamaño = iLong
                    frm.Text = "Boleta"
                    frm.ShowDialog()

                ElseIf documento = 3 Then       'guia de envio
                    obj = New Imprimir
                    obj.Inicializar()
                    obj.Superior = iSuperior
                    obj.Izquierda = Iizquierda
                    obj.Impresora = sImpresora

                    Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
                    Dim iLong As Integer = IIf(iTamaño = 0, 22, iTamaño)

                    y = iLong * pagina + 2
                    i += 1

                    ObjRptGuiaEnvio.p_Hora_Guia = fnGetHora()
                    If ldt_cur_datos_venta.Rows(0).Item("es_carga_asegurada") = 1 Then
                        obj.EscribirLinea(y, 22, ldt_cur_datos_venta.Rows(0).Item("Nro_Guia") & v_ca)
                    Else
                        obj.EscribirLinea(y, 22, ldt_cur_datos_venta.Rows(0).Item("Nro_Guia"))
                    End If
                    obj.EscribirLinea(y, 82, ldt_cur_datos_venta.Rows(0).Item("origen_iata"))
                    obj.EscribirLinea(y, 92, ldt_cur_datos_venta.Rows(0).Item("destino_iata"))
                    obj.EscribirLinea(y + 2, 0, ldt_cur_datos_venta.Rows(0).Item("Nu_Docu_Suna") & "-" & ldt_cur_datos_venta.Rows(0).Item("razon_social"))
                    obj.EscribirLinea(y + 5, 0, ldt_cur_datos_venta.Rows(0).Item("razon_social"))
                    If ldt_cur_datos_venta.Rows(0).Item("DirOrigen").ToString.Trim.Length > 40 Then
                        obj.EscribirLinea(y + 6, 0, ldt_cur_datos_venta.Rows(0).Item("DirOrigen").ToString.Substring(0, 41))
                        obj.EscribirLinea(y + 7, 0, ldt_cur_datos_venta.Rows(0).Item("DirOrigen").ToString.Substring(41))
                    Else
                        obj.EscribirLinea(y + 6, 0, ldt_cur_datos_venta.Rows(0).Item("DirOrigen"))
                    End If

                    obj.EscribirLinea(y + 5, 59, ldt_cur_datos_venta.Rows(0).Item("destinatario"))
                    obj.EscribirLinea(y + 6, 59, ldt_cur_datos_venta.Rows(0).Item("dirdestino"))

                    If ldt_cur_datos_venta.Rows(0).Item("Idtipo_Entrega") = 2 Then
                        obj.EscribirLinea(y + 2, 33, "X")
                    ElseIf ldt_cur_datos_venta.Rows(0).Item("Idtipo_Entrega") = 1 Then
                        obj.EscribirLinea(y + 2, 42, "X")
                    End If

                    If ldt_cur_datos_venta.Rows(0).Item("Idforma_Pago") = 1 Then
                        obj.EscribirLinea(y + 2, 54, "X")
                    ElseIf ldt_cur_datos_venta.Rows(0).Item("Idforma_Pago") = 2 Then
                        obj.EscribirLinea(y + 2, 64, "X")
                    Else
                        obj.EscribirLinea(y + 2, 76, "X")
                    End If
                    obj.EscribirLinea(y + 9, 0, "FACTURAR A: " & ldt_cur_datos_venta.Rows(0).Item("destinatario"))
                    obj.EscribirLinea(y + 8, 29, ldt_cur_datos_venta.Rows(0).Item("telefono"))
                    obj.EscribirLinea(y + 8, 59, ldt_cur_datos_venta.Rows(0).Item("destino"))
                    obj.EscribirLinea(y + 8, 84, IIf(IsDBNull(ldt_cur_datos_venta.Rows(0).Item("telefono_consignado")), "", ldt_cur_datos_venta.Rows(0).Item("telefono_consignado")))
                    obj.EscribirLinea(y + 17, 26, Format(CDate(ldt_cur_datos_venta.Rows(0).Item("fecha_factura")), "dd     MM      yy"))
                    obj.EscribirLinea(y + 13, 49, FormatNumber(CDbl(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Peso")) + CDbl(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Volumen")), 2))
                    obj.EscribirLinea(y + 13, 57, FormatNumber(CDbl(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Peso")), 2))
                    obj.EscribirLinea(y + 13, 65, FormatNumber(CDbl(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Volumen")), 2))
                    obj.EscribirLinea(y + 13, 78, ldt_cur_datos_venta.Rows(0).Item("fecha_factura"))
                    obj.EscribirLinea(y + 13, 92, ldt_cur_datos_venta.Rows(0).Item("hora_factura"))
                    obj.EscribirLinea(y + 14, 57, "N. SOBRES " & ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Sobre"))

                    obj.Comprimido = True
                    obj.Preliminar = True
                    obj.Tamaño = iLong
                    obj.Imprimir()
                    obj.Finalizar()

                    Dim frm As New FrmPreview
                    frm.Documento = 3
                    frm.Tamaño = iLong
                    frm.Text = "PCE Guía de Envío"
                    frm.ShowDialog()


                    '    ObjRptGuiaEnvio.p_Hora_Guia = fnGetHora()
                    '    If ldt_cur_datos_venta.Rows(0).Item("es_carga_asegurada") = 1 Then
                    '        objImprimir.Agregar(210, 25, ldt_cur_datos_venta.Rows(0).Item("Nro_Guia") & v_ca)
                    '    Else
                    '        objImprimir.Agregar(210, 25, ldt_cur_datos_venta.Rows(0).Item("Nro_Guia"))
                    '    End If
                    '    objImprimir.Agregar(485, 15, ldt_cur_datos_venta.Rows(0).Item("origen_iata"))
                    '    objImprimir.Agregar(545, 15, ldt_cur_datos_venta.Rows(0).Item("destino_iata"))
                    '    objImprimir.Agregar(0, 55, ldt_cur_datos_venta.Rows(0).Item("Nu_Docu_Suna") & "-" & ldt_cur_datos_venta.Rows(0).Item("razon_social"))
                    '    objImprimir.Agregar(25, 105, ldt_cur_datos_venta.Rows(0).Item("razon_social"))
                    '    objImprimir.Agregar(25, 120, ldt_cur_datos_venta.Rows(0).Item("DirOrigen"))
                    '    objImprimir.Agregar(355, 105, ldt_cur_datos_venta.Rows(0).Item("destinatario"))
                    '    objImprimir.Agregar(355, 120, ldt_cur_datos_venta.Rows(0).Item("dirdestino"))

                    '    If ldt_cur_datos_venta.Rows(0).Item("Idtipo_Entrega") = 2 Then
                    '        objImprimir.Agregar(190, 55, "X")
                    '    ElseIf ldt_cur_datos_venta.Rows(0).Item("Idtipo_Entrega") = 1 Then
                    '        objImprimir.Agregar(245, 55, "X")
                    '    End If

                    '    If ldt_cur_datos_venta.Rows(0).Item("Idforma_Pago") = 1 Then
                    '        objImprimir.Agregar(310, 55, "X")
                    '    ElseIf ldt_cur_datos_venta.Rows(0).Item("Idforma_Pago") = 2 Then
                    '        objImprimir.Agregar(435, 55, "X")
                    '    Else
                    '        objImprimir.Agregar(370, 55, "X")
                    '    End If
                    '    objImprimir.Agregar(25, 175, "FACTURAR A: " & ldt_cur_datos_venta.Rows(0).Item("destinatario"))
                    '    objImprimir.Agregar(162, 155, ldt_cur_datos_venta.Rows(0).Item("telefono"))
                    '    objImprimir.Agregar(370, 155, ldt_cur_datos_venta.Rows(0).Item("destino"))
                    '    objImprimir.Agregar(525, 155, IIf(IsDBNull(ldt_cur_datos_venta.Rows(0).Item("telefono_consignado")), "", ldt_cur_datos_venta.Rows(0).Item("telefono_consignado")))
                    '    objImprimir.Agregar(155, 300, Format(CDate(ldt_cur_datos_venta.Rows(0).Item("fecha_factura")), "dd     MM      yy"))
                    '    objImprimir.Agregar(280, 235, FormatNumber(CDbl(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Peso")) + CDbl(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Volumen")), 2))
                    '    objImprimir.Agregar(330, 235, FormatNumber(CDbl(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Peso")), 2))
                    '    objImprimir.Agregar(380, 235, FormatNumber(CDbl(ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Volumen")), 2))
                    '    objImprimir.Agregar(450, 240, ldt_cur_datos_venta.Rows(0).Item("fecha_factura"))
                    '    objImprimir.Agregar(535, 240, ldt_cur_datos_venta.Rows(0).Item("hora_factura"))
                    '    objImprimir.Agregar(300, 252, "Nº SOBRES " & ldt_cur_datos_venta.Rows(0).Item("Cantidad_x_Sobre"))
                End If
                'objImprimir.Imprimir()
            Else
                MessageBox.Show("El Documento no tiene asociado una impresora.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            objImprimir = Nothing
            objImpresora = Nothing
        Catch ex As Exception
            obj.Finalizar()
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        Try
            Me.Cursor = Cursors.AppStarting
            Dim iResp As Integer
            Dim row As Integer = DgvLista.SelectedRows.Item(0).Index

            Dim iFactura As String = DgvLista.Rows(row).Cells("idfactura").Value
            Dim iDocumento As Integer = DgvLista.Rows(row).Cells("Idtipo_Comprobante").Value
            '--------------------------------
            Me.imprime(iDocumento, iFactura)
            '--------------------------------
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnImprimirManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirManual.Click
        Try
            Me.Cursor = Cursors.AppStarting
            'Dim iResp As Integer
            'Dim row As Integer = DgvLista.SelectedRows.Item(0).Index

            Dim iFactura As String '= DgvLista.Rows(row).Cells("idfactura").Value
            Dim iDocumento As Integer '= DgvLista.Rows(row).Cells("Idtipo_Comprobante").Value

            Dim rows As DataGridViewSelectedRowCollection
            rows = Me.DgvLista.SelectedRows
            If rows.Count > 0 Then
                For i As Integer = 0 To rows.Count - 1
                    iDocumento = rows.Item(i).Cells("Idtipo_Comprobante").Value
                    iFactura = rows.Item(i).Cells("idfactura").Value
                    intNumero = intNumero + 1
                    Me.imprime(iDocumento, iFactura, "962", intNumero)
                    dtoVentaCargaContado.GrabarCorrelativoTmp(iDocumento, iFactura, "962", intNumero.ToString.PadLeft(7, "0"))
                Next
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim obj As New dtoControlFacturasBol
        If obj.ListaTmp = True Then
            dtControl_FAC.Clear()
            dvControl_FAC = obj.dt_rstFacturasBol.DefaultView ' dtControl_FAC.DefaultView
            DgvLista.DataSource = dvControl_FAC
        Else
            MessageBox.Show("No Se Encontraron Coincidencias.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ActivarDesactivar(False)
        End If
        'Me.FormatoColorDgvLista() 'CambioR 09112011

        'Return
        'Dim iFactura As String '= DgvLista.Rows(row).Cells("idfactura").Value
        'Dim iDocumento As Integer '= DgvLista.Rows(row).Cells("Idtipo_Comprobante").Value
        'Dim dt As DataTable = dtoVentaCargaContado.ListarCorrelativoTmp()
        'If dt.Rows.Count > 0 Then
        '    For i As Integer = 0 To dt.Rows.Count - 1
        '        iDocumento = dt.Rows(i).Item("tipo")
        '        iFactura = dt.Rows(i).Item("comprobante")
        '        intNumero = intNumero + 1
        '        Me.imprime(iDocumento, iFactura, "962", intNumero)
        '        dtoVentaCargaContado.GrabarCorrelativoTmp(iDocumento, iFactura, "962", intNumero.ToString.PadLeft(7, "0"))
        '    Next
        'End If
    End Sub

    Sub GrabarNotaCredito(ByVal frm As frmPagoContado, ByVal cliente As Integer)
        Try
            Dim intTipoPago As Integer = 0
            Dim dblPago As Double, dblCuota As Double, dblResultado As Double
            Dim intComprobanteOriginal As Integer, intTipo As Integer, strFecha As String, strSerie As String
            Dim dt As New DataTable, dtCtaCte As DataTable
            Dim obj As New dtoVentaCargaContado
            With frm
                For Each row As DataGridViewRow In .dgvPago.Rows 'buscar pago con nota de credito
                    If row.Cells("tipo_pago").Value = 6 Then 'si encuentra pago con nota de credito
                        dtCtaCte = obj.ListarCtaCteDetalle(cliente) 'lista de saldo cta cte por comprobante sin devolucion de dinero
                        If dtCtaCte.Rows.Count > 0 Then
                            dblResultado = row.Cells("pago").Value
                            For Each rowCtaCte As DataRow In dtCtaCte.Rows
                                intComprobanteOriginal = rowCtaCte.Item("comprobante")
                                intTipo = rowCtaCte.Item("tipo")
                                strFecha = rowCtaCte.Item("fecha")
                                strSerie = rowCtaCte.Item("serie")

                                dblCuota = rowCtaCte.Item("monto")
                                If dblResultado - dblCuota >= 0 Then
                                    dblPago = dblCuota
                                Else
                                    dblPago = dblResultado
                                End If
                                dblResultado = dblResultado - dblCuota
                                dt = obj.GrabarNotaCredito(intComprobanteOriginal, 30, row.Cells("pago").Value, dblPago, dtoUSUARIOS.iIDAGENCIAS, dtoUSUARIOS.IdLogin, _
                                                      dtoUSUARIOS.IP)
                                'no se aplica envios a sunat
                                'EnviarNotaCreditoSunat(dt.Rows(0), row.Cells("pago").Value, dblPago, intTipo, strSerie, strFecha, dtImpresora)

                                If dblResultado <= 0 Then
                                    Exit For
                                End If
                            Next
                        End If
                        Exit For
                    End If
                Next
            End With
        Catch
        End Try
    End Sub

    Private Sub btnSunat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSunat.Click
        EnviarSunat()
    End Sub

    Sub EnviarSunat()

        For Each rowi As DataGridViewRow In Me.DgvLista.Rows
            'serie = "F999"
            'correlativo = "0000261"
            If rowi.Cells("Idtipo_Comprobante").Value = 1 Or rowi.Cells("Idtipo_Comprobante").Value = 2 Then
                '-->Facturas y boletas
                '**********************************************
                Dim serie As String = rowi.Cells("FAC_BOL").Value.ToString.Trim.Substring(0, 4)
                Dim correlativo As String = rowi.Cells("FAC_BOL").Value.ToString.Trim.Substring(5)

                Me.DgvLista.CurrentCell = Me.DgvLista(0, rowi.Index)
                FnConsultar()

                'If Convert.ToDouble(TxtTotal.Text) <= 0 Then
                'MessageBox.Show("El total debe ser mayor a cero", "Alerta FE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Return

                Dim idProducto As Integer = rowi.Cells("idproceso").Value
                Dim fecliente As New FECliente
                fecliente.tipoDocumentoID = iID_TipoDocCli
                fecliente.numeroDocumento = TxtNroDocCliente.Text.Trim()
                fecliente.nombres = TxtNomCliente.Text.Trim.ToUpper()
                fecliente.direccion = IIf(CboDireccion.SelectedIndex > 0, CboDireccion.Text.Trim.ToUpper(), Nothing)
                Dim venta As New FEVenta
                venta.cliente = fecliente
                venta.numeroSerie = serie
                venta.numeroCorrelativo = correlativo
                venta.fechaEmision = DgvLista.CurrentRow.Cells("fecha_factura").Value
                venta.tipoComprobanteID = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
                venta.opGravada = TxtSubtotal.Text.Trim()
                venta.igv = TxtImpuesto.Text.Trim()
                venta.total = TxtTotal.Text.Trim()
                venta.totalLetras = ConvercionNroEnLetras(venta.total)
                venta.formaPago = CboFormaPago.Text.Trim().ToUpper()
                Dim formaPagoID As Integer = Int(ObjVentaCargaContado.coll_Tipo_Pago(CboFormaPago.SelectedIndex.ToString))
                If (formaPagoID = 5) Then '-->Cortesia
                    venta.isCortesia = True
                End If
                '->Consigando
                Dim consignado As String = ""
                For Each row As DataGridViewRow In GrdNConsignado.Rows
                    If (Not row Is Nothing AndAlso Not String.IsNullOrEmpty(row.Cells("Nombres").Value.ToString.Trim)) Then
                        consignado += row.Cells("Nombres").Value
                    End If
                Next
                venta.consignado = consignado
                venta.tipoEntrega = CboTipoEntrega.Text.Trim.ToUpper()
                venta.direccionEntrega = CboDireccion2.Text.Trim.ToUpper()
                venta.agenciaId = DirectCast(CboAgenciaOrigen.SelectedItem, DataRowView)(0)
                If Me.DgvLista.CurrentRow.Cells("agencia_venta").Value > 0 Then
                    venta.agenciaId = Me.DgvLista.CurrentRow.Cells("agencia_venta").Value
                End If
                venta.usuarioID = DirectCast(DgvLista.DataSource, DataView).Item(DgvLista.CurrentRow.Index).Item("usuario")
                venta.usuarioInsercion = DirectCast(DgvLista.DataSource, DataView).Item(DgvLista.CurrentRow.Index).Item("login")
                venta.usuarioModificacion = DirectCast(DgvLista.DataSource, DataView).Item(DgvLista.CurrentRow.Index).Item("login")
                venta.detalleVenta = FEManager.CrearDetalleVenta(GrdDetalleVenta, venta.total, ChkArticulos.Checked, ChkM3.Checked, idProducto)

                Dim result = FEManager.sendVentaSunat(venta, Nothing)
                If (result.IsCorrect) Then
                    Dim objFac As New ClsLbTepsa.dtoFACTURA
                    objFac.actualizarEmisonFE(ObjVentaCargaContado.v_IDFACTURA, "T_FACTURA_CONTADO")
                End If
                MessageBox.Show(result.Message, "Emisión F.E.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Tipo de comprobante no Válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Next
    End Sub

    Private Sub CboListaUsuarios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboListaUsuarios.SelectedIndexChanged
        If iOpcion = 2 Then
            Me.CboListaUsuarios.SelectedValue = Me.DgvLista.CurrentRow.Cells("idusuario_personal").Value
        End If
    End Sub

    Public Function GC420Exceso() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.HoraImpresion
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()
            Dim strProducto As String
            Dim strHoraPartida As String, strFechaPartida As String
            Dim strAgenciaEmbarque As String, strAgenciaDesembarque As String
            Dim strComprobante As String
            If Me.DgvLista.CurrentRow.Cells("idProceso").Value = 11 Then
                strComprobante = Me.DgvLista.CurrentRow.Cells("nroboleto").Value & "  " & dtoVentaCargaContado.AgenciaNombreCorto(Me.DgvLista.CurrentRow.Cells("Idagencias_Destino").Value)
            Else
                strComprobante = Me.DgvLista.CurrentRow.Cells("FAC_BOL").Value & "  " & dtoVentaCargaContado.AgenciaNombreCorto(Me.DgvLista.CurrentRow.Cells("Idagencias_Destino").Value)
            End If
            strAgenciaEmbarque = Me.DgvLista.CurrentRow.Cells("FAC_BOL").Value

            Dim i As Int16
            If iRango = 1 Then
                i = correlativo_inicial
                If i = 0 Then i = 1
            ElseIf iRango = 2 Then
                i = correlativo_inicial
            Else
                i = 1
            End If

            If i <= 0 Then i = 1

            '
            ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
            ObjCODIGOBARRA.sp_etiqueta_generada()

            HoraActual = sHora
            ObjCODIGOBARRA.Fecha = sFecha

            'hlamas 26-08-2015
            'agregar CARGO para envios con devolucion de cargo
            Dim strCargo As String, strFecha As String
            strCargo = IIf(Me.rbtCargoSi.Checked, "CARGO", "")
            For Each fila As DataRow In ObjVentaCargaContado.dt_Cur_CODIGOBARRAS.Rows
                strProducto = ObtieneProducto(Me.DgvLista.CurrentRow.Cells("idProceso").Value)
                strFechaPartida = ObjCODIGOBARRA.FechaPartida 'Me.DgvLista.CurrentRow.Cells("fecha_partida").Value
                strHoraPartida = ObjCODIGOBARRA.HoraPartida 'Me.DgvLista.CurrentRow.Cells("hora_partida").Value
                ObjCODIGOBARRA.CodigoBarra = fila.Item(0)
                prn.EscribeLinea("N")
                prn.EscribeLinea("N")

                'hlamas 02-07-2019
                '"A30,85,0,2,1,1,N
                prn.EscribeLinea("A30,10,0,4,2,1,N,""JOTASYS""")
                If Me.DgvLista.CurrentRow.Cells("idProceso").Value = 11 Then
                    prn.EscribeLinea("A30,50,0,2,1,1,N,""N.EQUIPAJE""")
                Else
                    prn.EscribeLinea("A490,10,0,4,2,1,N,""CA""")
                    prn.EscribeLinea("A30,50,0,2,1,1,N,""N.COMPROB.""")
                End If
                prn.EscribeLinea("A200,50,0,2,1,1,N,""PESO""")
                prn.EscribeLinea("A280,50,0,2,1,1,N,""PRECIO""")
                prn.EscribeLinea("A400,50,0,2,1,1,N,""EQUIPAJE""")

                prn.EscribeLinea("A30,70,0,3,1,1,N,""" & Me.DgvLista.CurrentRow.Cells("FAC_BOL").Value & """")
                prn.EscribeLinea("A210,70,0,3,1,1,N,""" & ObjCODIGOBARRA.peso & """")
                prn.EscribeLinea("A280,70,0,3,1,1,N,""" & Format(ObjCODIGOBARRA.TotalBoleto, "0.00") & """")
                prn.EscribeLinea("A420,70,0,3,1,1,N,""" & i.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")

                prn.EscribeLinea("A30,110,0,2,1,1,N,""N.BOLETO""")
                prn.EscribeLinea("A230,110,0,2,1,1,N,""F.VIAJE""")
                prn.EscribeLinea("A410,110,0,2,1,1,N,""HORA""")
                prn.EscribeLinea("A490,110,0,2,1,1,N,""ASIENTO""")

                prn.EscribeLinea("A30,130,0,3,1,1,N,""" & Me.DgvLista.CurrentRow.Cells("nroboleto").Value & """")
                prn.EscribeLinea("A230,130,0,3,1,1,N,""" & strFechaPartida & """")
                prn.EscribeLinea("A390,130,0,4,2,2,N,""" & strHoraPartida & """")
                prn.EscribeLinea("A515,130,0,3,1,1,N,""" & ObjCODIGOBARRA.asiento & """")

                prn.EscribeLinea("A30,190,0,4,1,1,N,""" & getCentrar(ObjCODIGOBARRA.clinte, 33) & """")
                prn.EscribeLinea("A30,220,0,4,2,2,N,""" & getCentrar(ObjCODIGOBARRA.Destino2, 18) & """")

                prn.EscribeLinea("B370,300,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """")

                If Me.DgvLista.CurrentRow.Cells("idProceso").Value = 11 Then
                    prn.EscribeLinea("A30,300,0,2,1,1,N,""TIPO EQU:""")
                Else
                    prn.EscribeLinea("A30,300,0,2,1,1,N,""TIPO CAR:""")
                End If

                prn.EscribeLinea("A30,330,0,2,1,1,N,""EMBARQUE:""")
                prn.EscribeLinea("A30,360,0,2,1,1,N,""DESEMBAR:""")

                If Not IsDBNull(fila("categoria")) Then
                    prn.EscribeLinea("A135,300,0,3,1,1,N,""" & getRecortar(fila("categoria"), 16) & """")
                End If
                prn.EscribeLinea("A135,330,0,3,1,1,N,""" & getRecortar(ObjCODIGOBARRA.AgenciaEmbarque, 16) & """")
                prn.EscribeLinea("A135,360,0,3,1,1,N,""" & getRecortar(ObjCODIGOBARRA.AgenciaDesembarque, 16) & """")

                '-------------------------------------------------------------------------------------------'

                'prn.EscribeLinea("A30,9,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
                'If Me.DgvLista.CurrentRow.Cells("Idtipo_Comprobante").Value = 4 Or Me.DgvLista.CurrentRow.Cells("Idtipo_Comprobante").Value = 6 Then
                '    prn.EscribeLinea("A30,37,0,4,1,1,N,""" & strComprobante & """")
                '    prn.EscribeLinea("A310,37,0,3,1,1,N,""" & i.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
                'Else
                '    prn.EscribeLinea("A30,37,0,4,1,1,N,""" & ObjCODIGOBARRA.NroDOC & " -" & i.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
                '    prn.EscribeLinea("A317,37,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
                'End If
                'prn.EscribeLinea("A30,118,0,3,1,1,N,""" & strHoraPartida & """")

                'strFecha = ObjCODIGOBARRA.Fecha.Trim & " " & HoraActual.Trim
                'prn.EscribeLinea("A30,148,0,1,1,1,N,""" & strFecha & """")
                'prn.EscribeLinea("A230,148,0,1,1,1,N,""TEPSA""")
                'prn.EscribeLinea("A350,148,0,4,1,1,N,""" & strProducto & """") '290 3

                ''hlamas 15-05-2017
                'If Me.DgvLista.CurrentRow.Cells("idProceso").Value = 11 Then
                '    prn.EscribeLinea("A30,85,0,2,1,1,N,""" & Me.DgvLista.CurrentRow.Cells("FAC_BOL").Value & """")
                '    prn.EscribeLinea("A30,167,0,2,1,1,N,""" & ObjCODIGOBARRA.Origen & "-""")
                '    prn.EscribeLinea("A85,167,0,2,1,2,N,""" & ObjCODIGOBARRA.Destino2 & """")
                'Else
                '    prn.EscribeLinea("A30,85,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-""")
                '    prn.EscribeLinea("A89,75,0,2,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
                'End If

                'prn.EscribeLinea("B162,69,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """") 'b148
                prn.EscribeLinea("P1")
                prn.EscribeLinea("N")
                prn.EscribeLinea(cadena)
                i = i + 1
            Next
            '''''''''''''''''''''''''''''''''''''''
            prn.FinDoc()
        Catch ex As Exception
            flag = False
            Throw New Exception(ex.Message)
        End Try
        Return flag
    End Function

    Function getCentrar(ByVal s As String, ByVal longitud As Integer) As String
        Dim l As Integer
        l = (longitud - s.Length) / 2
        If l < 0 Then
            l = 0
        End If
        Return Space(l) & s & Space(l)
    End Function

    Function getRecortar(ByVal s As String, ByVal longitud As Integer) As String
        If longitud >= s.Length Then
            Return s
        Else
            Return s.Substring(0, longitud)
        End If
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
            Dim strProducto As String
            Dim strHoraPartida As String
            'Dim strComprobante As String = ObjCODIGOBARRA.NroDOC 'ObjVentaCargaContado.v_SERIE_FACTURA & "-" & ObjVentaCargaContado.v_NRO_FACTURA
            Dim strComprobante As String
            If Me.DgvLista.CurrentRow.Cells("idProceso").Value = 11 Then
                strComprobante = Me.DgvLista.CurrentRow.Cells("nroboleto").Value & "  " & dtoVentaCargaContado.AgenciaNombreCorto(Me.DgvLista.CurrentRow.Cells("Idagencias_Destino").Value)
            Else
                strComprobante = Me.DgvLista.CurrentRow.Cells("FAC_BOL").Value & "  " & dtoVentaCargaContado.AgenciaNombreCorto(Me.DgvLista.CurrentRow.Cells("Idagencias_Destino").Value)
            End If
            '
            'Dim i As Int16
            'If bRango Then
            '    i = 1
            'Else
            '    i = correlativo_inicial
            '    'Mod 21/08/2009 
            '    If i = 0 Then i = 1
            'End If
            '
            Dim i As Int16
            If iRango = 1 Then
                i = correlativo_inicial
                If i = 0 Then i = 1
            ElseIf iRango = 2 Then
                i = correlativo_inicial
            Else
                i = 1
            End If

            If i <= 0 Then i = 1

            '
            ObjCODIGOBARRA.tipo = ObjVentaCargaContado.v_IDTIPO_COMPROBANTE
            ObjCODIGOBARRA.id = ObjVentaCargaContado.v_IDFACTURA
            ObjCODIGOBARRA.sp_etiqueta_generada()

            HoraActual = sHora
            ObjCODIGOBARRA.Fecha = sFecha

            'hlamas 26-08-2015
            'agregar CARGO para envios con devolucion de cargo
            Dim strCargo As String, strFecha As String
            strCargo = IIf(Me.rbtCargoSi.Checked, "CARGO", "")
            For Each fila As DataRow In ObjVentaCargaContado.dt_Cur_CODIGOBARRAS.Rows
                strProducto = ObtieneProducto(Me.DgvLista.CurrentRow.Cells("idProceso").Value)
                strHoraPartida = Me.DgvLista.CurrentRow.Cells("hora_partida").Value
                ObjCODIGOBARRA.CodigoBarra = fila.Item(0)
                prn.EscribeLinea("N")
                prn.EscribeLinea("N")
                prn.EscribeLinea("A30,9,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")

                If Me.DgvLista.CurrentRow.Cells("Idtipo_Comprobante").Value = 4 Or Me.DgvLista.CurrentRow.Cells("Idtipo_Comprobante").Value = 6 Then
                    prn.EscribeLinea("A30,37,0,4,1,1,N,""" & strComprobante & """")
                    prn.EscribeLinea("A310,37,0,3,1,1,N,""" & i.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
                Else
                    prn.EscribeLinea("A30,37,0,4,1,1,N,""" & ObjCODIGOBARRA.NroDOC & " -" & i.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
                    prn.EscribeLinea("A317,37,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
                End If
                'prn.EscribeLinea("A30,85,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-""")
                prn.EscribeLinea("A30,118,0,3,1,1,N,""" & strHoraPartida & """")

                strFecha = ObjCODIGOBARRA.Fecha.Trim & " " & HoraActual.Trim
                prn.EscribeLinea("A30,148,0,1,1,1,N,""" & strFecha & """")
                prn.EscribeLinea("A230,148,0,1,1,1,N,""JOTASYS""")
                prn.EscribeLinea("A350,148,0,4,1,1,N,""" & strProducto & """") '290 3

                'hlamas 15-05-2017
                If Me.DgvLista.CurrentRow.Cells("idProceso").Value = 11 Then
                    'prn.EscribeLinea("A150,167,0,2,1,1,N,""" & Me.DgvLista.CurrentRow.Cells("FAC_BOL").Value & """")
                    prn.EscribeLinea("A30,85,0,2,1,1,N,""" & Me.DgvLista.CurrentRow.Cells("FAC_BOL").Value & """")
                    prn.EscribeLinea("A30,167,0,2,1,1,N,""" & ObjCODIGOBARRA.Origen & "-""")
                    prn.EscribeLinea("A85,167,0,2,1,2,N,""" & ObjCODIGOBARRA.Destino2 & """")
                Else
                    prn.EscribeLinea("A30,85,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-""")
                    prn.EscribeLinea("A89,75,0,2,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
                End If

                prn.EscribeLinea("B162,69,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """") 'b148
                prn.EscribeLinea("P1")
                prn.EscribeLinea("N")
                prn.EscribeLinea(cadena)
                i = i + 1
            Next
            '''''''''''''''''''''''''''''''''''''''
            prn.FinDoc()
        Catch ex As Exception
            flag = False
            Throw New Exception(ex.Message)
        End Try
        Return flag
    End Function

    Private Sub DgvLista_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvLista.CellContentClick

    End Sub
End Class
