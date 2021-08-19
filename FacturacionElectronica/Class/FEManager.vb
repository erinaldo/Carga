Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports INTEGRACION.servicefe
Imports AccesoDatos

'Imports INTEGRACION.feserviceDesarrollo
Public Class FEManager
#Region "IDENTIFICADORES TITAN, SEGUN BASE DE DATOS"
    '-->Identificadores de los tipos de documentos (t_tipo_doc_identidad)
    Private Shared ReadOnly TITAN_ID_TIPDOC_RUC As Integer = 1
    Private Shared ReadOnly TITAN_ID_TIPDOC_DNI As Integer = 3
    Private Shared ReadOnly TITAN_ID_TIPDOC_PASAPORTE As Integer = 5
    Private Shared ReadOnly TITAN_ID_TIPDOC_CARNET_EXTRANJERIA As Integer = 99
    Private Shared ReadOnly TITAN_ID_TIPDOC_CEDULA_IDENTIDAD As Integer = 2

    '-->Identificadores de los tipos de comprobante (t_tipo_comprobante)
    Public Shared ReadOnly TITAN_ID_TIPCOM_FACTURA As Integer = 1
    Public Shared ReadOnly TITAN_ID_TIPCOM_BOLETA As Integer = 2
    Public Shared ReadOnly TITAN_ID_TIPCOM_NOTA_CREDITO As Integer = 30
    Public Shared ReadOnly TITAN_ID_TIPCOM_NOTA_DEBITO As Integer = 92
    Public Shared ReadOnly TITAN_ID_TIPCOM_EQUIPAJE As Integer = 4

    '-->Identificadores del tipo de producto
    Private Shared ReadOnly TITAN_ID_TIPPRO_TEPSABOX As Integer = 81
#End Region
#Region "IDENTIFICADORES SUNAT, SEGUN CATALOGOS"
    '-->Identificadores de los tipos de documentos - Catalogo N° 1
    Private Shared ReadOnly SUNAT_ID_TIPDOC_RUC As String = "6"
    Private Shared ReadOnly SUNAT_ID_TIPDOC_DNI As String = "1"
    Private Shared ReadOnly SUNAT_ID_TIPDOC_CARNET_EXTRANJERIA As String = "4"
    Private Shared ReadOnly SUNAT_ID_TIPDOC_PASAPORTE As String = "7"
    Private Shared ReadOnly SUNAT_ID_TIPDOC_CEDULA_IDENTIDAD As String = "A"

    '-->Identificadores de los tipos de comprobante - Catalogo N° 6
    Private Shared ReadOnly SUNAT_ID_TIPCOM_FACTURA As String = "01"
    Private Shared ReadOnly SUNAT_ID_TIPCOM_BOLETA As String = "03"
    Private Shared ReadOnly SUNAT_ID_TIPCOM_NOTA_CREDITO As String = "07"
    Private Shared ReadOnly SUNAT_ID_TIPCOM_NOTA_DEBITO As String = "08"
    Private Shared ReadOnly SUNAT_ID_TIPCOM_TICKET As String = "04"
    Private Shared ReadOnly SUNAT_ID_TIPCOM_PCE As String = "85"

    '-->Unidades de medida - Catalogo N° 3
    Public Shared ReadOnly SUNAT_UNIMED_UNIDAD As String = "NIU"
    Public Shared ReadOnly SUNAT_UNIMED_PESO As String = "C1"

#End Region
#Region "VARIABLES PRIVADAS"    
    '-->Codigo de los las columnas del detalle de la venta
    Private Shared ReadOnly NAME_COLUMN_TIPO As String = "TIPO"
    Private Shared ReadOnly NAME_COLUMN_BULTO As String = "BULTO"
    Private Shared ReadOnly NAME_COLUMN_PESO_VOLUMEN As String = "PESO/VOLUMEN"
    Private Shared ReadOnly NAME_COLUMN_TARIFA As String = "COSTO"
    Private Shared ReadOnly NAME_COLUMN_SUBNETO As String = "SUB NETO"
    Private Shared ReadOnly NAME_COLUMN_VOLUMETRICO_PESO As String = "PESO KG"
    Private Shared ReadOnly NAME_COLUMN_ARTICULO As String = "ARTÍCULO"
    Private Shared ReadOnly NAME_COLUMN_ARTICULO_TCOSTO As String = "T.COSTO"
    Private Shared ReadOnly NAME_COLUMN_ARTICULO_PESO As String = "PESO"
    Private Shared ReadOnly NAME_COLUMN_ARTICULO_PRECIO As String = "PRECIO"
    Private Shared ReadOnly NAME_COLUMN_ARTICULO_CANTIDAD As String = "CANTIDAD"

    Private Shared ReadOnly NAME_COLUMN_TIPO_CA As String = "COL_TIPO"
    Private Shared ReadOnly NAME_COLUMN_BULTO_CA As String = "COL_BULTO"
    Private Shared ReadOnly NAME_COLUMN_PESO_VOLUMEN_CA As String = "COL_PESOVOLUMEN"
    Private Shared ReadOnly NAME_COLUMN_TARIFA_CA As String = "COL_COSTO"
    Private Shared ReadOnly NAME_COLUMN_SUBNETO_CA As String = "COL_SUBNETO"

    '-->Codigos de los tipos de servcios
    Private Shared ReadOnly CODIGO_ENVIO_PESO As String = "PESO"
    Private Shared ReadOnly CODIGO_ENVIO_VOLUMEN As String = "VOLUMEN"
    Private Shared ReadOnly CODIGO_ENVIO_SOBRE As String = "SOBRE"
    Private Shared ReadOnly CODIGO_ENVIO_BASE As String = "BASE"
    Private Shared ReadOnly CODIGO_ENVIO_ENTREGA_DOMICILIO As String = "ENTREGA"
    Private Shared ReadOnly CODIGO_ENVIO_DEV_CARGOS As String = "DEV CARGO"
    Private Shared ReadOnly CODIGO_ENVIO_CARGA_ASEGURADA As String = "CARGA SEGURO"
    Private Shared ReadOnly CODIGO_ENVIO_FUERA_ZONA As String = "FUERA ZONA"
    '-->Denominaciones de los tipos de servcios
    Private Shared ReadOnly DENOMINACION_ENVIO As String = "TRASLADO DE ; BULTOS "
    Private Shared ReadOnly DENOMINACION_ENVIO_TARIFA_BASE As String = "TARIFA BASE"
    Private Shared ReadOnly DENOMINACION_ENVIO_ENTREGA_DOMICILIO As String = "ENTREGA A DOMICILIO"
    Private Shared ReadOnly DENOMINACION_ENVIO_DEV_CARGOS As String = "DEVOLUCION DE CARGOS"
    Private Shared ReadOnly DENOMINACION_ENVIO_CARGA_ASEGURADA As String = "CARGA ASEGURADA"
    Private Shared ReadOnly DENOMINACION_ENVIO_FUERA_ZONA As String = "FUERA DE ZONA"
    Private Shared ReadOnly DENOMINACION_ENVIO_VOLUMENTRICO As String = "VOLUMETRICO"

    '-->Token
    Private Shared ReadOnly TOKEN As String = "#13579ZCBMKHFAQETUIP12W4R6Y8U9O#..."
#End Region
#Region "VARIABLES STATICAS PUBLICAS"
    Public Shared ReadOnly TIPO_VENTA_CONTADO As Integer = 0
    Public Shared ReadOnly TIPO_VENTA_CREDITO As Integer = 1
    Public Shared ReadOnly TIPO_VENTA_ESPECIAL As Integer = 2
    Public Shared ReadOnly VAL_IGV As Double = 18 '-->Valor de igv
    Public Shared ReadOnly DETRACCION_MONTO_MAYOR_400 As Double = 400
    Public Shared ReadOnly DETRACCION_GLOSA_MAYOR_400 As String = "OPERACION SUJETA AL SISTEMA DE PAGO DE OPERACIONES TRIBUTARIAS BANCO DE " & _
                                                                  "LA NACION Nº 0019-002829. EXCLUIDOS DE RETENCION DEL 6% DE IGV POR SER " & _
                                                                  "AGENTES DE RETENCION SEGUN ART. 10 C.T., R.S. 228-2012/SUNAT"
    Public Shared ReadOnly DETRACCION_GLOSA_MENOR_400 As String = "EXCLUIDOS DE RETENCION DEL 6% DE IGV POR SER AGENTES DE RETENCION SEGUN " & _
                                                                  "ART. 10 C.T., R.S. 228-2012/SUNAT"
    Public Shared ReadOnly DETRACCION_GLOSA_MAYOR_400ESPECIAL As String = "OPERACION SUJETA AL SISTEMA DE PAGO DE OBLIGACIONES TRIBUTARIAS CON " & _
                                                                         "EL GOBIERNO CENTRAL, SEGÚN D.L.Nº 940-R.S. Nº158-2006-SUNAT/D.S. " & _
                                                                         "Nº 033-2006-MTC." & Chr(13) & _
                                                                         "Sirvase Depositar a la Cuenta del Bco. de la Nación Nº 0019-002829."
    Public Shared ReadOnly MESSAGE_NO_PRINT As String = "No se ha encontrado ninguna impresara configurada"
    'Public Shared result As Result
#End Region
#Region "FUNCIONES"
    ''' <summary>
    ''' Busca el nombre del tipo de documento, segun el identificador de titan
    ''' </summary>
    ''' <param name="titanTipoDocumentoID">Identificador del tipo de documento, segun la db Titan</param>
    ''' <returns>Nombre de tipo de documento</returns>
    Private Shared Function getNameTipoDoct(titanTipoDocumentoID) As String
        Select Case titanTipoDocumentoID
            Case TITAN_ID_TIPDOC_RUC
                Return "RUC"
            Case TITAN_ID_TIPDOC_DNI
                Return "DNI"
            Case TITAN_ID_TIPDOC_PASAPORTE
                Return "PASAPORTE"
            Case TITAN_ID_TIPDOC_CARNET_EXTRANJERIA
                Return "CARNET DE EXTRANJERIA"
            Case TITAN_ID_TIPDOC_CEDULA_IDENTIDAD
                Return "DECULA DE IDENTIDAD PERUANA"
            Case Else
                Return Nothing
        End Select
    End Function
    ''' <summary>
    ''' Busca el identificador tipo de documento, segun catalogo N° 1 de la Sunat
    ''' </summary>
    ''' <param name="titanTipoDocumentoID">Identificador del tipo de documento, segun la db Titan</param>
    ''' <returns>Identificador segun Catralogo Sunat</returns>
    Private Shared Function getTipoDoctSunat(titanTipoDocumentoID) As String
        Select Case titanTipoDocumentoID
            Case TITAN_ID_TIPDOC_RUC
                Return SUNAT_ID_TIPDOC_RUC
            Case TITAN_ID_TIPDOC_DNI
                Return SUNAT_ID_TIPDOC_DNI
            Case TITAN_ID_TIPDOC_PASAPORTE
                Return SUNAT_ID_TIPDOC_PASAPORTE
            Case TITAN_ID_TIPDOC_CARNET_EXTRANJERIA
                Return SUNAT_ID_TIPDOC_CARNET_EXTRANJERIA
            Case TITAN_ID_TIPDOC_CEDULA_IDENTIDAD
                Return SUNAT_ID_TIPDOC_CEDULA_IDENTIDAD
            Case Else
                Return Nothing
        End Select
    End Function
    ''' <summary>
    ''' Busca el identificador tipo de documento, segun catalogo N° 6 de la Sunat
    ''' </summary>
    ''' <param name="titanTipoComprobanteId">Identificador tipoComprobanteID segun la DB en Titan</param>
    ''' <returns>Identificador segun Catralogo Sunat</returns>
    Private Shared Function getTipoCompSunat(titanTipoComprobanteId) As String
        Select Case titanTipoComprobanteId
            Case TITAN_ID_TIPCOM_FACTURA
                Return SUNAT_ID_TIPCOM_FACTURA
            Case TITAN_ID_TIPCOM_BOLETA
                Return SUNAT_ID_TIPCOM_BOLETA
            Case TITAN_ID_TIPCOM_NOTA_CREDITO
                Return SUNAT_ID_TIPCOM_NOTA_CREDITO
            Case TITAN_ID_TIPCOM_NOTA_DEBITO
                Return SUNAT_ID_TIPCOM_NOTA_DEBITO
            Case Else
                Return Nothing
        End Select
    End Function
    '-->Comentado por que ya no es necesario, titan ya guarda la serie incluyendo la letra
    'Public Shared Function autoCompletSerie(serie As String, tipoComprobanteID As String)
    '    Dim _serie As String = "000" & serie
    '    If (tipoComprobanteID.Equals(SUNAT_ID_TIPCOM_FACTURA)) Then
    '        _serie = "F" & _serie.Substring(serie.Length, 3)
    '    ElseIf (tipoComprobanteID.Equals(SUNAT_ID_TIPCOM_BOLETA)) Then
    '        _serie = "B" & _serie.Substring(serie.Length, 3)
    '    End If

    '    Return _serie
    'End Function
    Private Shared Function autoCompletCorrelativo(correlativo As String)
        Dim _correlativo As String = "00000000" & correlativo
        _correlativo = _correlativo.Substring(correlativo.ToString().Length, 8)

        Return _correlativo
    End Function
    ''' <summary>
    ''' Crea el detalle de la venta.
    ''' </summary>
    ''' <param name="GrdDetalleVenta">Objeto DataGridView del formulario, el cual contiene el detalle de la venta</param>
    ''' <param name="totalVenta">Monto total de la venta</param>
    ''' <param name="isArticulos">Determina si es un envio con articulos(True), caso contrario(False)</param>
    ''' <param name="isVolumnetrico">Determina si es un envio Volumetrico(True), caso contrario(False)</param>
    ''' <returns>Detalle de la venta</returns>
    ''' 
    Public Shared Function CrearDetalleVenta(ByVal dt As DataTable) As List(Of FEDetalleVenta)
        Dim listaDetalle As New List(Of FEDetalleVenta)

        Dim detalleVenta As New FEDetalleVenta
        detalleVenta.descripcion = "PESO"
        detalleVenta.unidadMedida = ""
        If dt.Rows(0).Item("cp") > 0 And dt.Rows(0).Item("idprocesos") = 6 Then
            detalleVenta.cantidad = dt.Rows(0).Item("tp")
            detalleVenta.tarifa = dt.Rows(0).Item("cp")
        Else
            detalleVenta.cantidad = 0
            detalleVenta.tarifa = 0
        End If
        listaDetalle.Add(detalleVenta)

        Dim detalleVenta2 As New FEDetalleVenta
        detalleVenta2.descripcion = "VOLUMEN"
        detalleVenta2.unidadMedida = ""
        If dt.Rows(0).Item("cv") > 0 Then
            detalleVenta2.cantidad = dt.Rows(0).Item("tv")
            detalleVenta2.tarifa = dt.Rows(0).Item("cv")
        Else
            detalleVenta2.cantidad = 0
            detalleVenta2.tarifa = 0
        End If
        listaDetalle.Add(detalleVenta2)

        Dim detalleVenta3 As New FEDetalleVenta
        Dim intFila As Integer = IIf(dt.Rows.Count = 1, 0, 1)
        detalleVenta3.descripcion = "EQUIPAJE"
        detalleVenta3.unidadMedida = ""
        If dt.Rows(intFila).Item("cp") > 0 And dt.Rows(intFila).Item("idprocesos") = 11 Then
            detalleVenta3.cantidad = dt.Rows(intFila).Item("tp")
            detalleVenta3.tarifa = dt.Rows(intFila).Item("cp")
        Else
            detalleVenta3.cantidad = 0
            detalleVenta3.tarifa = 0
        End If
        listaDetalle.Add(detalleVenta3)

        Return listaDetalle
    End Function

    Public Shared Function crearDetalleVentaCA(ByVal GrdDetalleVenta As DataGridView, ByVal totalVenta As Double, ByVal isArticulos As Boolean, ByVal isVolumnetrico As Boolean, Optional ByVal idProducto As Integer = 0, Optional ByVal IsCa As Integer = 0, Optional ByVal maximo As Integer = 0, Optional ByVal cantidad As Integer = 0) As List(Of FEDetalleVenta)
        '-->==========DETALLE DE LA VENTA===============
        Dim listaDetalle As New List(Of FEDetalleVenta)
        '-->Determina el nombre de las columnas del GRDDetalleVenta
        Dim NAME_COLUMN_TIPO As String
        Dim NAME_COLUMN_SUBNETO As String
        Dim NAME_COLUMN_PESO As String
        Dim NAME_COLUMN_TARIFA As String
        Dim NAME_COLUMN_CANTIDAD As String
        Dim intValor As Integer = IsCa

        If intValor >= 1 Then
            NAME_COLUMN_TIPO = FEManager.NAME_COLUMN_TIPO_CA
            NAME_COLUMN_SUBNETO = FEManager.NAME_COLUMN_SUBNETO_CA
            NAME_COLUMN_PESO = FEManager.NAME_COLUMN_PESO_VOLUMEN_CA
            NAME_COLUMN_TARIFA = FEManager.NAME_COLUMN_TARIFA_CA
            NAME_COLUMN_CANTIDAD = FEManager.NAME_COLUMN_BULTO_CA
            If intValor = 2 Then
                intValor = 0
            End If
        Else
            NAME_COLUMN_TIPO = IIf(isArticulos, FEManager.NAME_COLUMN_ARTICULO, FEManager.NAME_COLUMN_TIPO)
            NAME_COLUMN_SUBNETO = IIf(isArticulos, FEManager.NAME_COLUMN_ARTICULO_TCOSTO, FEManager.NAME_COLUMN_SUBNETO)
            NAME_COLUMN_PESO = IIf(isVolumnetrico, FEManager.NAME_COLUMN_VOLUMETRICO_PESO, IIf(isArticulos, FEManager.NAME_COLUMN_ARTICULO_PESO, FEManager.NAME_COLUMN_PESO_VOLUMEN))
            NAME_COLUMN_TARIFA = IIf(isArticulos, FEManager.NAME_COLUMN_ARTICULO_PRECIO, FEManager.NAME_COLUMN_TARIFA)
            NAME_COLUMN_CANTIDAD = IIf(isArticulos, FEManager.NAME_COLUMN_ARTICULO_CANTIDAD, FEManager.NAME_COLUMN_BULTO)
        End If

        '-->Primero agrega la tarifa base por el envio
        Dim totalSubNeto As Double = 0.0
        For Each row As DataGridViewRow In GrdDetalleVenta.Rows
            '-->Valida que no se el concepto base
            If Not (row.Cells(NAME_COLUMN_TIPO).Value.Equals(FEManager.CODIGO_ENVIO_BASE)) Then
                totalSubNeto += IIf(IsNumeric(row.Cells(NAME_COLUMN_SUBNETO).Value), row.Cells(NAME_COLUMN_SUBNETO).Value, 0)
            End If
        Next
        If (totalSubNeto > 0) Then
            Dim tarifaBase As Double = FormatNumber(totalVenta - totalSubNeto, 2) '-->Determina el precio base del envio

            If (tarifaBase = 0) Then
                '-->Calculando la tarifa base, cuando este esta incluido en el subneto
                For Each row As DataGridViewRow In GrdDetalleVenta.Rows
                    Dim subNeto As Double = IIf(IsNumeric(row.Cells(NAME_COLUMN_SUBNETO).Value), row.Cells(NAME_COLUMN_SUBNETO).Value, 0)
                    Dim tarifa As Double = IIf(IsNumeric(row.Cells(NAME_COLUMN_TARIFA).Value), row.Cells(NAME_COLUMN_TARIFA).Value, 0)
                    Dim peso As Double = IIf(IsNumeric(row.Cells(NAME_COLUMN_PESO).Value), row.Cells(NAME_COLUMN_PESO).Value, 0)

                    Dim csubneto As Double = FormatNumber(peso * tarifa, 2)
                    If (csubneto < subNeto AndAlso peso > 0) Then
                        tarifaBase += FormatNumber(subNeto - csubneto, 2)
                    End If
                Next
            End If

            If (tarifaBase > 0) Then
                Dim detalleVenta As New FEDetalleVenta
                detalleVenta.descripcion = FEManager.DENOMINACION_ENVIO_TARIFA_BASE
                detalleVenta.cantidad = 1
                detalleVenta.tarifa = tarifaBase
                detalleVenta.unidadMedida = FEManager.SUNAT_UNIMED_UNIDAD
                listaDetalle.Add(detalleVenta)
            End If
        End If
        '-->Agrega los demas servicios
        For Each row As DataGridViewRow In GrdDetalleVenta.Rows
            If Not (row.Cells(NAME_COLUMN_TIPO).Value.Equals(FEManager.CODIGO_ENVIO_BASE)) Then
                Dim subneto As Double = IIf(IsNumeric(row.Cells(NAME_COLUMN_SUBNETO).Value), row.Cells(NAME_COLUMN_SUBNETO).Value, 0)
                '-->Solo los servicios utilizados
                If (subneto + intValor > 0) Then 'And row.Cells(NAME_COLUMN_TIPO).Value <> "EQUIPAJE" Then
                    Dim detalleVenta As New FEDetalleVenta
                    detalleVenta.descripcion = FEManager.DENOMINACION_ENVIO
                    If (idProducto = TITAN_ID_TIPPRO_TEPSABOX) Then
                        '-->Si es tepsa box invierte la cantidad a bultos para que cuadre en la impresion.
                        If (Not isArticulos) Then _
                            detalleVenta.cantidad = IIf(Val(row.Cells(NAME_COLUMN_BULTO).Value) > 0, row.Cells(NAME_COLUMN_BULTO).Value, 1)
                        If (isArticulos) Then _
                            detalleVenta.bultos = IIf(row.Cells(NAME_COLUMN_PESO).Value > 0, row.Cells(NAME_COLUMN_PESO).Value, 1)
                    Else
                        If (Not isArticulos) Then
                            If intValor = 1 Then
                                detalleVenta.cantidad = row.Cells(NAME_COLUMN_PESO).Value
                            Else
                                detalleVenta.cantidad = IIf(row.Cells(NAME_COLUMN_PESO).Value > 0, row.Cells(NAME_COLUMN_PESO).Value, 1)
                            End If
                        End If

                        If (isArticulos) Then detalleVenta.bultos = IIf(row.Cells(NAME_COLUMN_PESO).Value > 0, row.Cells(NAME_COLUMN_PESO).Value, 1)
                    End If

                    If (IsNumeric(row.Cells(NAME_COLUMN_TARIFA).Value)) Then
                        detalleVenta.tarifa = IIf(row.Cells(NAME_COLUMN_TARIFA).Value > 0, row.Cells(NAME_COLUMN_TARIFA).Value, subneto)
                    Else
                        detalleVenta.tarifa = subneto
                    End If
                    detalleVenta.unidadMedida = FEManager.SUNAT_UNIMED_UNIDAD
                    '-->Para colocarle o completar la descripcion del servicio a un nombre mas personalizado
                    Select Case row.Cells(NAME_COLUMN_TIPO).Value
                        Case FEManager.CODIGO_ENVIO_PESO
                            detalleVenta.descripcion += "(" & FEManager.CODIGO_ENVIO_PESO & ")"
                        Case FEManager.CODIGO_ENVIO_VOLUMEN
                            detalleVenta.descripcion += "(" & FEManager.CODIGO_ENVIO_VOLUMEN & ")"
                        Case FEManager.CODIGO_ENVIO_SOBRE
                            detalleVenta.descripcion += "(" & FEManager.CODIGO_ENVIO_SOBRE & ")"
                        Case FEManager.CODIGO_ENVIO_ENTREGA_DOMICILIO
                            detalleVenta.descripcion = FEManager.DENOMINACION_ENVIO_ENTREGA_DOMICILIO
                        Case FEManager.CODIGO_ENVIO_DEV_CARGOS
                            detalleVenta.descripcion = FEManager.DENOMINACION_ENVIO_DEV_CARGOS
                        Case FEManager.CODIGO_ENVIO_CARGA_ASEGURADA
                            detalleVenta.descripcion = FEManager.DENOMINACION_ENVIO_CARGA_ASEGURADA
                        Case FEManager.CODIGO_ENVIO_FUERA_ZONA
                            detalleVenta.descripcion = FEManager.DENOMINACION_ENVIO_FUERA_ZONA
                        Case Else
                            '-->Coloca el nombre de la fila del Tipo si no coincide con los criterios anteriores
                            If (Not isVolumnetrico AndAlso Not isArticulos) Then
                                detalleVenta.descripcion = row.Cells(NAME_COLUMN_TIPO).Value
                            ElseIf (Not isVolumnetrico AndAlso isArticulos) Then
                                detalleVenta.descripcion += row.Cells(NAME_COLUMN_TIPO).Value & " ( ARTICULOS )"
                            Else
                                detalleVenta.descripcion += "(" & FEManager.DENOMINACION_ENVIO_VOLUMENTRICO & ")"
                            End If
                    End Select
                    '-->Cantidad de bultos
                    Dim cantidadBultos As Integer = IIf(IsNumeric(row.Cells(NAME_COLUMN_CANTIDAD).Value), row.Cells(NAME_COLUMN_CANTIDAD).Value, 0)
                    If (cantidadBultos + intValor > 0) Then
                        '-->Rempleaza le simbolo(;) por la cantidad de bultos
                        detalleVenta.descripcion = detalleVenta.descripcion.Replace(";", cantidadBultos)
                        '-->si la cantidad es 1 cambia el nombre de "Bultos" a "Bulto"
                        If (Not isArticulos AndAlso cantidadBultos = 1) Then detalleVenta.descripcion = detalleVenta.descripcion.Replace("BULTOS", "BULTO")
                        '-->Si es Articulos
                        If (isArticulos) Then
                            '-->Quita la palabra "Bultos"
                            detalleVenta.descripcion = detalleVenta.descripcion.Replace("BULTOS", "")
                            '-->Si la cantidad de bultos es mayor a 1, reemplaza el nombre del articulo al mismo, pero en plural, ejemp: de "Caja" a "Cajas"
                            If (cantidadBultos > 1) Then detalleVenta.descripcion = detalleVenta.descripcion.Replace(row.Cells(NAME_COLUMN_TIPO).Value, row.Cells(NAME_COLUMN_TIPO).Value & "S")
                            detalleVenta.cantidad = cantidadBultos
                        Else
                            If intValor = 1 Then
                                detalleVenta.tarifa = cantidadBultos
                            Else
                                detalleVenta.bultos = cantidadBultos
                                If detalleVenta.descripcion.Substring(1, 2) = "CA" Then
                                    'detalleVenta.cantidad = cantidadBultos
                                    detalleVenta.cantidad = IIf(row.Cells(NAME_COLUMN_PESO).Value > 0, row.Cells(NAME_COLUMN_PESO).Value, 1)
                                ElseIf detalleVenta.descripcion = "EQUIPAJE" Then
                                    detalleVenta.cantidad = IIf(row.Cells(NAME_COLUMN_PESO).Value - maximo > 0, row.Cells(NAME_COLUMN_PESO).Value - maximo, 0)
                                End If
                            End If
                        End If
                    ElseIf (isArticulos) Then
                        detalleVenta.cantidad = 1 '-->Para los servicios adicionales como entrega, seguro, etc.
                    End If

                    If totalSubNeto > 0 Then
                        If Val(detalleVenta.cantidad) = 0 Then
                            Dim intCantidad As Integer = ObtieneCantidadCA(ObjVentaCargaContado.v_IDFACTURA, row.Index + 1)
                            detalleVenta.bultos = intCantidad
                        End If
                    End If

                    listaDetalle.Add(detalleVenta)
                End If
            End If
        Next

        Return listaDetalle
    End Function

    Public Shared Function crearDetalleVenta(ByVal GrdDetalleVenta As DataGridView, ByVal totalVenta As Double, ByVal isArticulos As Boolean, ByVal isVolumnetrico As Boolean, Optional ByVal idProducto As Integer = 0, Optional ByVal IsCa As Integer = 0, Optional ByVal maximo As Integer = 0, Optional ByVal cantidad As Integer = 0, Optional ByVal descuento As Double = 0) As List(Of FEDetalleVenta)
        '-->==========DETALLE DE LA VENTA===============
        Dim listaDetalle As New List(Of FEDetalleVenta)
        '-->Determina el nombre de las columnas del GRDDetalleVenta
        Dim NAME_COLUMN_TIPO As String
        Dim NAME_COLUMN_SUBNETO As String
        Dim NAME_COLUMN_PESO As String
        Dim NAME_COLUMN_TARIFA As String
        Dim NAME_COLUMN_CANTIDAD As String
        Dim intValor As Integer = IsCa

        If intValor >= 1 Then
            NAME_COLUMN_TIPO = FEManager.NAME_COLUMN_TIPO_CA
            NAME_COLUMN_SUBNETO = FEManager.NAME_COLUMN_SUBNETO_CA
            NAME_COLUMN_PESO = FEManager.NAME_COLUMN_PESO_VOLUMEN_CA
            NAME_COLUMN_TARIFA = FEManager.NAME_COLUMN_TARIFA_CA
            NAME_COLUMN_CANTIDAD = FEManager.NAME_COLUMN_BULTO_CA
            If intValor = 2 Then
                intValor = 0
            End If
        Else
            NAME_COLUMN_TIPO = IIf(isArticulos, FEManager.NAME_COLUMN_ARTICULO, FEManager.NAME_COLUMN_TIPO)
            NAME_COLUMN_SUBNETO = IIf(isArticulos, FEManager.NAME_COLUMN_ARTICULO_TCOSTO, FEManager.NAME_COLUMN_SUBNETO)
            NAME_COLUMN_PESO = IIf(isVolumnetrico, FEManager.NAME_COLUMN_VOLUMETRICO_PESO, IIf(isArticulos, FEManager.NAME_COLUMN_ARTICULO_PESO, FEManager.NAME_COLUMN_PESO_VOLUMEN))
            NAME_COLUMN_TARIFA = IIf(isArticulos, FEManager.NAME_COLUMN_ARTICULO_PRECIO, FEManager.NAME_COLUMN_TARIFA)
            NAME_COLUMN_CANTIDAD = IIf(isArticulos, FEManager.NAME_COLUMN_ARTICULO_CANTIDAD, FEManager.NAME_COLUMN_BULTO)
        End If

        '-->Primero agrega la tarifa base por el envio
        Dim totalSubNeto As Double = 0.0
        For Each row As DataGridViewRow In GrdDetalleVenta.Rows
            '-->Valida que no se el concepto base
            If Not (row.Cells(NAME_COLUMN_TIPO).Value.Equals(FEManager.CODIGO_ENVIO_BASE)) Then
                totalSubNeto += IIf(IsNumeric(row.Cells(NAME_COLUMN_SUBNETO).Value), row.Cells(NAME_COLUMN_SUBNETO).Value, 0)
            End If
        Next
        If (totalSubNeto > 0) Then
            If descuento > 0 Then
                Dim dblDescuento As Double = descuento / 100
                Dim dblSubneto As Double = totalSubNeto * dblDescuento
                totalSubNeto = totalSubNeto - dblSubneto
            End If

            Dim tarifaBase As Double = FormatNumber(totalVenta - totalSubNeto, 2) '-->Determina el precio base del envio
            If (tarifaBase = 0) Then
                '-->Calculando la tarifa base, cuando este esta incluido en el subneto
                For Each row As DataGridViewRow In GrdDetalleVenta.Rows
                    Dim subNeto As Double = IIf(IsNumeric(row.Cells(NAME_COLUMN_SUBNETO).Value), row.Cells(NAME_COLUMN_SUBNETO).Value, 0)
                    Dim tarifa As Double = IIf(IsNumeric(row.Cells(NAME_COLUMN_TARIFA).Value), row.Cells(NAME_COLUMN_TARIFA).Value, 0)
                    Dim peso As Double = IIf(IsNumeric(row.Cells(NAME_COLUMN_PESO).Value), row.Cells(NAME_COLUMN_PESO).Value, 0)

                    Dim csubneto As Double = FormatNumber(peso * tarifa, 2)
                    If (csubneto < subNeto AndAlso peso > 0) Then
                        tarifaBase += FormatNumber(subNeto - csubneto, 2)
                    End If
                Next
            End If

            If (tarifaBase > 0) Then
                Dim detalleVenta As New FEDetalleVenta
                detalleVenta.descripcion = FEManager.DENOMINACION_ENVIO_TARIFA_BASE
                detalleVenta.cantidad = 1
                detalleVenta.tarifa = tarifaBase
                detalleVenta.unidadMedida = FEManager.SUNAT_UNIMED_UNIDAD
                listaDetalle.Add(detalleVenta)
            End If
        End If
        '-->Agrega los demas servicios
        For Each row As DataGridViewRow In GrdDetalleVenta.Rows
            If Not (row.Cells(NAME_COLUMN_TIPO).Value.Equals(FEManager.CODIGO_ENVIO_BASE)) Then
                Dim subneto As Double = IIf(IsNumeric(row.Cells(NAME_COLUMN_SUBNETO).Value), row.Cells(NAME_COLUMN_SUBNETO).Value, 0)
                '-->Solo los servicios utilizados
                If (subneto + intValor > 0) Then 'And row.Cells(NAME_COLUMN_TIPO).Value <> "EQUIPAJE" Then
                    Dim detalleVenta As New FEDetalleVenta
                    detalleVenta.descripcion = FEManager.DENOMINACION_ENVIO
                    If (idProducto = TITAN_ID_TIPPRO_TEPSABOX) Then
                        '-->Si es tepsa box invierte la cantidad a bultos para que cuadre en la impresion.
                        If (Not isArticulos) Then _
                            detalleVenta.cantidad = IIf(Val(row.Cells(NAME_COLUMN_BULTO).Value) > 0, row.Cells(NAME_COLUMN_BULTO).Value, 1)
                        If (isArticulos) Then _
                            detalleVenta.bultos = IIf(row.Cells(NAME_COLUMN_PESO).Value > 0, row.Cells(NAME_COLUMN_PESO).Value, 1)
                    Else
                        If (Not isArticulos) Then
                            If intValor = 1 Then
                                detalleVenta.cantidad = row.Cells(NAME_COLUMN_PESO).Value
                            Else
                                detalleVenta.cantidad = IIf(row.Cells(NAME_COLUMN_PESO).Value > 0, row.Cells(NAME_COLUMN_PESO).Value, 1)
                            End If
                        End If

                        If (isArticulos) Then detalleVenta.bultos = IIf(row.Cells(NAME_COLUMN_PESO).Value > 0, row.Cells(NAME_COLUMN_PESO).Value, 1)
                    End If

                    If (IsNumeric(row.Cells(NAME_COLUMN_TARIFA).Value)) Then
                        detalleVenta.tarifa = IIf(row.Cells(NAME_COLUMN_TARIFA).Value > 0, row.Cells(NAME_COLUMN_TARIFA).Value, subneto)
                    Else
                        detalleVenta.tarifa = subneto
                    End If
                    detalleVenta.unidadMedida = FEManager.SUNAT_UNIMED_UNIDAD
                    '-->Para colocarle o completar la descripcion del servicio a un nombre mas personalizado
                    Select Case row.Cells(NAME_COLUMN_TIPO).Value
                        Case FEManager.CODIGO_ENVIO_PESO
                            detalleVenta.descripcion += "(" & FEManager.CODIGO_ENVIO_PESO & ")"
                        Case FEManager.CODIGO_ENVIO_VOLUMEN
                            detalleVenta.descripcion += "(" & FEManager.CODIGO_ENVIO_VOLUMEN & ")"
                        Case FEManager.CODIGO_ENVIO_SOBRE
                            detalleVenta.descripcion += "(" & FEManager.CODIGO_ENVIO_SOBRE & ")"
                        Case FEManager.CODIGO_ENVIO_ENTREGA_DOMICILIO
                            detalleVenta.descripcion = FEManager.DENOMINACION_ENVIO_ENTREGA_DOMICILIO
                        Case FEManager.CODIGO_ENVIO_DEV_CARGOS
                            detalleVenta.descripcion = FEManager.DENOMINACION_ENVIO_DEV_CARGOS
                        Case FEManager.CODIGO_ENVIO_CARGA_ASEGURADA
                            detalleVenta.descripcion = FEManager.DENOMINACION_ENVIO_CARGA_ASEGURADA
                        Case FEManager.CODIGO_ENVIO_FUERA_ZONA
                            detalleVenta.descripcion = FEManager.DENOMINACION_ENVIO_FUERA_ZONA
                        Case Else
                            '-->Coloca el nombre de la fila del Tipo si no coincide con los criterios anteriores
                            If (Not isVolumnetrico AndAlso Not isArticulos) Then
                                detalleVenta.descripcion = row.Cells(NAME_COLUMN_TIPO).Value
                            ElseIf (Not isVolumnetrico AndAlso isArticulos) Then
                                detalleVenta.descripcion += row.Cells(NAME_COLUMN_TIPO).Value & " ( ARTICULOS )"
                            Else
                                detalleVenta.descripcion += "(" & FEManager.DENOMINACION_ENVIO_VOLUMENTRICO & ")"
                            End If
                    End Select
                    '-->Cantidad de bultos
                    Dim cantidadBultos As Integer = IIf(IsNumeric(row.Cells(NAME_COLUMN_CANTIDAD).Value), row.Cells(NAME_COLUMN_CANTIDAD).Value, 0)
                    If (cantidadBultos + intValor > 0) Then
                        '-->Rempleaza le simbolo(;) por la cantidad de bultos
                        detalleVenta.descripcion = detalleVenta.descripcion.Replace(";", cantidadBultos)
                        '-->si la cantidad es 1 cambia el nombre de "Bultos" a "Bulto"
                        If (Not isArticulos AndAlso cantidadBultos = 1) Then detalleVenta.descripcion = detalleVenta.descripcion.Replace("BULTOS", "BULTO")
                        '-->Si es Articulos
                        If (isArticulos) Then
                            '-->Quita la palabra "Bultos"
                            detalleVenta.descripcion = detalleVenta.descripcion.Replace("BULTOS", "")
                            '-->Si la cantidad de bultos es mayor a 1, reemplaza el nombre del articulo al mismo, pero en plural, ejemp: de "Caja" a "Cajas"
                            If (cantidadBultos > 1) Then detalleVenta.descripcion = detalleVenta.descripcion.Replace(row.Cells(NAME_COLUMN_TIPO).Value, row.Cells(NAME_COLUMN_TIPO).Value & "S")
                            detalleVenta.cantidad = cantidadBultos
                        Else
                            If intValor = 1 Then
                                detalleVenta.tarifa = cantidadBultos
                            Else
                                detalleVenta.bultos = cantidadBultos
                                If detalleVenta.descripcion.Substring(1, 2) = "CA" Then
                                    'detalleVenta.cantidad = cantidadBultos
                                    detalleVenta.cantidad = IIf(row.Cells(NAME_COLUMN_PESO).Value > 0, row.Cells(NAME_COLUMN_PESO).Value, 1)
                                ElseIf detalleVenta.descripcion = "EQUIPAJE" Then
                                    detalleVenta.cantidad = IIf(row.Cells(NAME_COLUMN_PESO).Value - maximo > 0, row.Cells(NAME_COLUMN_PESO).Value - maximo, 0)
                                End If
                            End If
                        End If
                    ElseIf (isArticulos) Then
                        detalleVenta.cantidad = 1 '-->Para los servicios adicionales como entrega, seguro, etc.
                    End If
                    listaDetalle.Add(detalleVenta)
                End If
            End If
        Next

        Return listaDetalle
    End Function

    Public Shared Function crearDetallePCE(ByVal GrdDetalleVenta As DataGridView, ByVal totalVenta As Double, ByVal isArticulos As Boolean, ByVal isVolumnetrico As Boolean, Optional ByVal idProducto As Integer = 0, Optional ByVal IsCa As Integer = 0, Optional ByVal maximo As Integer = 0) As List(Of FEDetalleVenta)
        '-->==========DETALLE DE LA VENTA===============
        Dim listaDetalle As New List(Of FEDetalleVenta)
        '-->Determina el nombre de las columnas del GRDDetalleVenta
        Dim NAME_COLUMN_TIPO As String
        Dim NAME_COLUMN_SUBNETO As String
        Dim NAME_COLUMN_PESO As String
        Dim NAME_COLUMN_TARIFA As String
        Dim NAME_COLUMN_CANTIDAD As String
        Dim intValor As Integer = IsCa

        If intValor >= 1 Then
            NAME_COLUMN_TIPO = FEManager.NAME_COLUMN_TIPO_CA
            NAME_COLUMN_SUBNETO = FEManager.NAME_COLUMN_SUBNETO_CA
            NAME_COLUMN_PESO = FEManager.NAME_COLUMN_PESO_VOLUMEN_CA
            NAME_COLUMN_TARIFA = FEManager.NAME_COLUMN_TARIFA_CA
            NAME_COLUMN_CANTIDAD = FEManager.NAME_COLUMN_BULTO_CA
            If intValor = 2 Then
                intValor = 0
            End If
        Else
            NAME_COLUMN_TIPO = IIf(isArticulos, "Articulos", FEManager.NAME_COLUMN_TIPO)
            NAME_COLUMN_SUBNETO = IIf(isArticulos, "P.Total", FEManager.NAME_COLUMN_SUBNETO)
            NAME_COLUMN_PESO = IIf(isVolumnetrico, "Peso", IIf(isArticulos, FEManager.NAME_COLUMN_ARTICULO_PESO, FEManager.NAME_COLUMN_PESO_VOLUMEN))
            NAME_COLUMN_TARIFA = IIf(isArticulos, "Precio", FEManager.NAME_COLUMN_TARIFA)
            NAME_COLUMN_CANTIDAD = IIf(isArticulos, "Cantidad", FEManager.NAME_COLUMN_BULTO)
        End If

        '-->Primero agrega la tarifa base por el envio
        Dim totalSubNeto As Double = 0.0
        For Each row As DataGridViewRow In GrdDetalleVenta.Rows
            '-->Valida que no se el concepto base
            If Not (row.Cells(NAME_COLUMN_TIPO).Value.Equals(FEManager.CODIGO_ENVIO_BASE)) Then
                totalSubNeto += IIf(IsNumeric(row.Cells(NAME_COLUMN_SUBNETO).Value), row.Cells(NAME_COLUMN_SUBNETO).Value, 0)
            End If
        Next
        If (totalSubNeto > 0) Then
            Dim tarifaBase As Double = FormatNumber(totalVenta - totalSubNeto, 2) '-->Determina el precio base del envio

            If (tarifaBase = 0) Then
                '-->Calculando la tarifa base, cuando este esta incluido en el subneto
                For Each row As DataGridViewRow In GrdDetalleVenta.Rows
                    Dim subNeto As Double = IIf(IsNumeric(row.Cells(NAME_COLUMN_SUBNETO).Value), row.Cells(NAME_COLUMN_SUBNETO).Value, 0)
                    Dim tarifa As Double = IIf(IsNumeric(row.Cells(NAME_COLUMN_TARIFA).Value), row.Cells(NAME_COLUMN_TARIFA).Value, 0)
                    Dim peso As Double = IIf(IsNumeric(row.Cells(NAME_COLUMN_PESO).Value), row.Cells(NAME_COLUMN_PESO).Value, 0)

                    Dim csubneto As Double = FormatNumber(peso * tarifa, 2)
                    If (csubneto < subNeto AndAlso peso > 0) Then
                        tarifaBase += FormatNumber(subNeto - csubneto, 2)
                    End If
                Next
            End If

            If (tarifaBase > 0) Then
                Dim detalleVenta As New FEDetalleVenta
                detalleVenta.descripcion = FEManager.DENOMINACION_ENVIO_TARIFA_BASE
                detalleVenta.cantidad = 1
                detalleVenta.tarifa = tarifaBase
                detalleVenta.unidadMedida = FEManager.SUNAT_UNIMED_UNIDAD
                listaDetalle.Add(detalleVenta)
            End If
        End If
        '-->Agrega los demas servicios
        For Each row As DataGridViewRow In GrdDetalleVenta.Rows
            If Not (row.Cells(NAME_COLUMN_TIPO).Value.Equals(FEManager.CODIGO_ENVIO_BASE)) Then
                Dim subneto As Double = IIf(IsNumeric(row.Cells(NAME_COLUMN_SUBNETO).Value), row.Cells(NAME_COLUMN_SUBNETO).Value, 0)
                '-->Solo los servicios utilizados
                If (subneto + intValor > 0) Then 'And row.Cells(NAME_COLUMN_TIPO).Value <> "EQUIPAJE" Then
                    Dim detalleVenta As New FEDetalleVenta
                    detalleVenta.descripcion = FEManager.DENOMINACION_ENVIO
                    If (idProducto = TITAN_ID_TIPPRO_TEPSABOX) Then
                        '-->Si es tepsa box invierte la cantidad a bultos para que cuadre en la impresion.
                        If (Not isArticulos) Then _
                            detalleVenta.cantidad = IIf(row.Cells(NAME_COLUMN_BULTO).Value > 0, row.Cells(NAME_COLUMN_BULTO).Value, 1)
                        If (isArticulos) Then _
                            detalleVenta.bultos = IIf(row.Cells(NAME_COLUMN_PESO).Value > 0, row.Cells(NAME_COLUMN_PESO).Value, 1)
                    Else
                        If (Not isArticulos) Then
                            If intValor = 1 Then
                                detalleVenta.cantidad = row.Cells(NAME_COLUMN_PESO).Value
                            Else
                                detalleVenta.cantidad = IIf(row.Cells(NAME_COLUMN_PESO).Value > 0, row.Cells(NAME_COLUMN_PESO).Value, 1)
                            End If
                        End If

                        If (isArticulos) Then detalleVenta.bultos = IIf(row.Cells(NAME_COLUMN_PESO).Value > 0, row.Cells(NAME_COLUMN_PESO).Value, 1)
                    End If

                    If (IsNumeric(row.Cells(NAME_COLUMN_TARIFA).Value)) Then
                        detalleVenta.tarifa = IIf(row.Cells(NAME_COLUMN_TARIFA).Value > 0, row.Cells(NAME_COLUMN_TARIFA).Value, subneto)
                    Else
                        detalleVenta.tarifa = subneto
                    End If
                    detalleVenta.unidadMedida = FEManager.SUNAT_UNIMED_UNIDAD
                    '-->Para colocarle o completar la descripcion del servicio a un nombre mas personalizado
                    Select Case row.Cells(NAME_COLUMN_TIPO).Value
                        Case FEManager.CODIGO_ENVIO_PESO
                            detalleVenta.descripcion += "(" & FEManager.CODIGO_ENVIO_PESO & ")"
                        Case FEManager.CODIGO_ENVIO_VOLUMEN
                            detalleVenta.descripcion += "(" & FEManager.CODIGO_ENVIO_VOLUMEN & ")"
                        Case FEManager.CODIGO_ENVIO_SOBRE
                            detalleVenta.descripcion += "(" & FEManager.CODIGO_ENVIO_SOBRE & ")"
                        Case FEManager.CODIGO_ENVIO_ENTREGA_DOMICILIO
                            detalleVenta.descripcion = FEManager.DENOMINACION_ENVIO_ENTREGA_DOMICILIO
                        Case FEManager.CODIGO_ENVIO_DEV_CARGOS
                            detalleVenta.descripcion = FEManager.DENOMINACION_ENVIO_DEV_CARGOS
                        Case FEManager.CODIGO_ENVIO_CARGA_ASEGURADA
                            detalleVenta.descripcion = FEManager.DENOMINACION_ENVIO_CARGA_ASEGURADA
                        Case FEManager.CODIGO_ENVIO_FUERA_ZONA
                            detalleVenta.descripcion = FEManager.DENOMINACION_ENVIO_FUERA_ZONA
                        Case Else
                            '-->Coloca el nombre de la fila del Tipo si no coincide con los criterios anteriores
                            If (Not isVolumnetrico AndAlso Not isArticulos) Then
                                detalleVenta.descripcion = row.Cells(NAME_COLUMN_TIPO).Value
                            ElseIf (Not isVolumnetrico AndAlso isArticulos) Then
                                detalleVenta.descripcion += row.Cells(NAME_COLUMN_TIPO).Value & " ( ARTICULOS )"
                            Else
                                detalleVenta.descripcion += "(" & FEManager.DENOMINACION_ENVIO_VOLUMENTRICO & ")"
                            End If
                    End Select
                    '-->Cantidad de bultos
                    Dim cantidadBultos As Integer = IIf(IsNumeric(row.Cells(NAME_COLUMN_CANTIDAD).Value), row.Cells(NAME_COLUMN_CANTIDAD).Value, 0)
                    If (cantidadBultos + intValor > 0) Then
                        '-->Rempleaza le simbolo(;) por la cantidad de bultos
                        detalleVenta.descripcion = detalleVenta.descripcion.Replace(";", cantidadBultos)
                        '-->si la cantidad es 1 cambia el nombre de "Bultos" a "Bulto"
                        If (Not isArticulos AndAlso cantidadBultos = 1) Then detalleVenta.descripcion = detalleVenta.descripcion.Replace("BULTOS", "BULTO")
                        '-->Si es Articulos
                        If (isArticulos) Then
                            '-->Quita la palabra "Bultos"
                            detalleVenta.descripcion = detalleVenta.descripcion.Replace("BULTOS", "")
                            '-->Si la cantidad de bultos es mayor a 1, reemplaza el nombre del articulo al mismo, pero en plural, ejemp: de "Caja" a "Cajas"
                            If (cantidadBultos > 1) Then detalleVenta.descripcion = detalleVenta.descripcion.Replace(row.Cells(NAME_COLUMN_TIPO).Value, row.Cells(NAME_COLUMN_TIPO).Value & "S")
                            'detalleVenta.cantidad = cantidadBultos

                            'hlamas 18-10-2018
                            detalleVenta.cantidad = detalleVenta.bultos
                            detalleVenta.bultos = cantidadBultos
                        Else
                            If intValor = 1 Then
                                detalleVenta.tarifa = cantidadBultos
                            Else
                                detalleVenta.bultos = cantidadBultos
                                If detalleVenta.descripcion.Substring(1, 2) = "CA" Then
                                    'detalleVenta.cantidad = cantidadBultos
                                    detalleVenta.cantidad = IIf(row.Cells(NAME_COLUMN_PESO).Value > 0, row.Cells(NAME_COLUMN_PESO).Value, 1)
                                ElseIf detalleVenta.descripcion = "EQUIPAJE" Then
                                    detalleVenta.cantidad = IIf(row.Cells(NAME_COLUMN_PESO).Value - maximo > 0, row.Cells(NAME_COLUMN_PESO).Value - maximo, 0)
                                End If
                            End If
                        End If
                    ElseIf (isArticulos) Then
                        detalleVenta.cantidad = 1 '-->Para los servicios adicionales como entrega, seguro, etc.
                    End If
                    listaDetalle.Add(detalleVenta)
                End If
            End If
        Next

        Return listaDetalle
    End Function
#End Region
    ''' <summary>
    ''' Crea el objeto venta para luego ser enviado al servcio web
    ''' </summary>
    ''' <param name="venta">Instancia de la Clase FEVenta</param>
    ''' <returns>Class Venta</returns>
    Private Shared Function createWSVenta(venta As FEVenta) As Venta
        '-->Cliente
        'Dim wscliente As New feserviceDesarrollo.Cliente
        Dim strLog As String = ""
        Dim strLog2 As String = ""
        Dim wscliente As New servicefe.Cliente
        wscliente.numeroDocumento = venta.cliente.numeroDocumento
        wscliente.nombres = venta.cliente.nombres
        wscliente.direccion = venta.cliente.direccion
        wscliente.tipoDocumentoID = getTipoDoctSunat(venta.cliente.tipoDocumentoID)

        '-->Venta
        Dim wsventa As New Venta
        wsventa.tipoComprobanteID = getTipoCompSunat(venta.tipoComprobanteID) 'Segunn catalogo 1 (Factura)
        'wsventa.numeroSerie = autoCompletSerie(venta.numeroSerie, wsventa.tipoComprobanteID)
        wsventa.numeroSerie = venta.numeroSerie
        wsventa.numeroCorrelativo = autoCompletCorrelativo(venta.numeroCorrelativo)
        wsventa.tipoMonedaSoles = venta.isMonedaSoles
        wsventa.producto = venta.producto
        wsventa.fechaEmision = Convert.ToDateTime(venta.fechaEmision).ToString("yyyy-MM-dd")
        '-->Valida si es cortesia
        If Not (venta.isCortesia) Then
            wsventa.montoTotal = venta.total
            wsventa.igv = venta.igv
            wsventa.montoSubTotal = venta.opGravada
        Else
            wsventa.montoTotal = 0
            wsventa.igv = 0
            wsventa.montoSubTotal = 0
        End If
        wsventa.montoTotalDescuento = 0
        wsventa.glosaRetencion = venta.glosaRetencion
        wsventa.numeroPrefactura = venta.numeroPrefactura
        wsventa.isSOUE = venta.isSOUE
        wsventa.cliente = wscliente
        If (venta.agenciaId = 0) Then
            wsventa.agenciaID = dtoUSUARIOS.iIDAGENCIAS
        Else
            wsventa.agenciaID = venta.agenciaId
        End If
        If (venta.usuarioID = 0) Then
            wsventa.usuarioID = dtoUSUARIOS.IdLogin
        Else
            wsventa.usuarioID = venta.usuarioID
        End If
        If (venta.usuarioInsercion Is Nothing) Then
            wsventa.usuarioInsercion = dtoUSUARIOS.iLOGIN
        Else
            wsventa.usuarioInsercion = venta.usuarioInsercion
        End If
        If (venta.usuarioModificacion Is Nothing) Then
            wsventa.usuarioModificacion = dtoUSUARIOS.iLOGIN
        Else
            wsventa.usuarioModificacion = venta.usuarioModificacion
        End If
        wsventa.tipoVenta = venta.tipoVenta

        '-->Aplica glosa de detraccion cuando el monto es mayor a 400
        If (wsventa.glosaRetencion Is Nothing Or wsventa.glosaRetencion = "") Then
            If wsventa.igv > 0 AndAlso Not venta.isCortesia AndAlso wsventa.tipoComprobanteID.Equals(FEManager.SUNAT_ID_TIPCOM_FACTURA) Then
                If (venta.total > FEManager.DETRACCION_MONTO_MAYOR_400) Then
                    'wsventa.glosaRetencion = FEManager.DETRACCION_GLOSA_MAYOR_400ESPECIAL
                End If
            End If
        End If

        '--> Cuando se tenga la necesidad de obtener el detalle de un comprobante anterior
        '-->Solamente se deberia dar en el modulo de emision de notas de credito para clientes contado, en titan (Procesos/Operacion contado/Nota de credito
        Dim totalOpGratuitas As Double = 0.0
        If Not (venta.detalleVenta Is Nothing) Then
            '-->Detalle de la venta
            Dim lstDetalleVenta As New List(Of DetalleVenta)
            Dim item As Integer = 0
            Dim intTipoVenta As Integer '1 gravada 2 no gravada 3 cortesia
            For Each detalleVenta As FEDetalleVenta In venta.detalleVenta
                item += +1
                Dim wsdetalleVenta As New DetalleVenta
                wsdetalleVenta.item = item
                wsdetalleVenta.bultos = IIf(detalleVenta.bultos > 0, detalleVenta.bultos, Nothing) '-->Numero de bultos (No se envia a la sunat)
                wsdetalleVenta.unidadMedida = detalleVenta.unidadMedida '--> Unidad de medida segun catalogo N° 3
                wsdetalleVenta.porcentajeIgv = VAL_IGV
                wsdetalleVenta.descripcion = detalleVenta.descripcion
                wsdetalleVenta.cantidad = detalleVenta.cantidad
                wsdetalleVenta.tarifa = detalleVenta.tarifa '-->Incluye el Igv
                If Not (venta.isCortesia) Then
                    If wsventa.igv > 0 Then 'Operacion gravada
                        intTipoVenta = 1
                        Dim igv_x As Double = FormatNumber(wsdetalleVenta.porcentajeIgv / 100, 2) '(0.18)
                        Dim igv_y As Double = igv_x + 1 '(1.18)

                        wsdetalleVenta.valorUnitario = FormatNumber(wsdetalleVenta.tarifa / igv_y, 2) '-->Precio o tarifa, sin igv 8.47 + 1.53
                        'wsdetalleVenta.igv = FormatNumber((wsdetalleVenta.tarifa / igv_y) * igv_x, 2) '-->Igv del precio unitario
                        wsdetalleVenta.total = FormatNumber((wsdetalleVenta.tarifa / igv_y) * wsdetalleVenta.cantidad, 2) '--> total de la linea del detalle (Pero sin impuestos)
                        wsdetalleVenta.igv = FormatNumber((wsdetalleVenta.tarifa) * wsdetalleVenta.cantidad / igv_y * igv_x, 2) '--> total de la linea del detalle (Pero sin impuestos)
                        wsdetalleVenta.codigoAfectacionIgv = "10" '-->Gravado - Operacion onerosa - Afectacion al igv (Cat. 7)
                        wsdetalleVenta.codigoTipoPrecio = "01" '-->Precio Unitario (incluye Igv) -Tipo de precio de venta unitario (Cat. 16)
                        'totalValor += wsdetalleVenta.total
                    Else 'Operacion no gravada o exonerada
                        If venta.TipoAfectacion = 2 Then
                            intTipoVenta = 2
                            wsdetalleVenta.valorUnitario = FormatNumber(wsdetalleVenta.tarifa, 2) '-->Precio o tarifa, sin igv
                            wsdetalleVenta.igv = 0
                            wsdetalleVenta.total = FormatNumber(wsdetalleVenta.tarifa * wsdetalleVenta.cantidad, 2) '--> total de la linea del detalle (Pero sin impuestos)
                            wsdetalleVenta.codigoAfectacionIgv = "20" '-->Exonerado - Operacion Onerosa - Afectacion al igv (Cat. 7)
                            wsdetalleVenta.codigoTipoPrecio = "01" '-->Precio Unitario (incluye Igv) - Tipo de precio de venta unitario (Cat. 16)
                        Else
                            intTipoVenta = 3
                            wsdetalleVenta.valorUnitario = FormatNumber(wsdetalleVenta.tarifa, 2) '-->Precio o tarifa, sin igv
                            wsdetalleVenta.igv = 0
                            wsdetalleVenta.total = FormatNumber(wsdetalleVenta.tarifa * wsdetalleVenta.cantidad, 2) '--> total de la linea del detalle (Pero sin impuestos)
                            wsdetalleVenta.codigoAfectacionIgv = "30" '-->Inafecto - Operacion Onerosa - Afectacion al igv (Cat. 7)
                            wsdetalleVenta.codigoTipoPrecio = "01" '-->Precio Unitario (incluye Igv) - Tipo de precio de venta unitario (Cat. 16)
                        End If
                    End If
                Else
                    intTipoVenta = 4
                    wsdetalleVenta.valorUnitario = 0.0 '-->Precio o tarifa, sin igv
                    wsdetalleVenta.igv = 0.0 '-->Igv del precio unitario
                    wsdetalleVenta.total = 0.0 '--> total de la linea del detalle (Pero sin impuestos)
                    wsdetalleVenta.codigoAfectacionIgv = "11" '-->Gravado - Retiro por premio - Afectacion al igv (Cat. 7)
                    wsdetalleVenta.codigoTipoPrecio = "02" '-->Valor referencial unitario en operaciones no onerosas - Tipo de precio de venta unitario (Cat. 16)
                    'totalOpGratuitas += wsdetalleVenta.tarifa
                    totalOpGratuitas = venta.total
                End If
                lstDetalleVenta.Add(wsdetalleVenta)
            Next
            wsventa.listDetalleVenta = lstDetalleVenta.ToArray()

            '======================================================
            '-->Otros conceptos tributarios. (Cat. 14)
            '======================================================
            '-->Operaciones Gravadas
            Dim totalesMonedaAdiconal As New List(Of InformacionAdicional.TotalMonedaAdicional)
            Dim totalMonedaAdicional As New InformacionAdicional.TotalMonedaAdicional
            If intTipoVenta = 1 Then
                totalMonedaAdicional.codigo = "1001" '--> Segun catalogo 14
                totalMonedaAdicional.nombre = "TOTAL VALOR DE VENTA - OPERACIONES GRAVADAS"
                totalMonedaAdicional.valor = wsventa.montoSubTotal.ToString() '--> (no incluye impuesto)
                totalesMonedaAdiconal.Add(totalMonedaAdicional)
            ElseIf intTipoVenta = 2 Then
                totalMonedaAdicional.codigo = "1003" '--> Segun catalogo 14
                totalMonedaAdicional.nombre = "TOTAL VALOR DE VENTA - OPERACIONES EXONERADAS"
                totalMonedaAdicional.valor = wsventa.montoSubTotal.ToString() '--> (no incluye impuesto)
                totalesMonedaAdiconal.Add(totalMonedaAdicional)
            ElseIf intTipoVenta = 3 Then
                totalMonedaAdicional.codigo = "1002" '--> Segun catalogo 14
                totalMonedaAdicional.nombre = "TOTAL VALOR DE VENTA - OPERACIONES INAFECTAS"
                totalMonedaAdicional.valor = wsventa.montoSubTotal.ToString()
                totalesMonedaAdiconal.Add(totalMonedaAdicional)
            End If
            '-->Operaciones gratuitas
            If totalOpGratuitas > 0 Then
                totalMonedaAdicional = New InformacionAdicional.TotalMonedaAdicional
                totalMonedaAdicional.codigo = "1004" '--> Segun catalogo 14
                totalMonedaAdicional.nombre = "TOTAL VALOR DE VENTA - OPERACIONES GRATUITAS"
                totalMonedaAdicional.valor = totalOpGratuitas.ToString()
                totalesMonedaAdiconal.Add(totalMonedaAdicional)
            End If
            strLog = "(1)" & totalMonedaAdicional.codigo & "-" & totalMonedaAdicional.nombre & "-" & totalMonedaAdicional.valor
            '-->Operaciones Inafectas
            'If (venta.opInafecta > 0) Then
            '    totalMonedaAdicional = New InformacionAdicional.TotalMonedaAdicional
            '    totalMonedaAdicional.codigo = "1002" '--> Segun catalogo 14
            '    totalMonedaAdicional.nombre = "TOTAL VALOR DE VENTA - OPERACIONES INAFECTAS"
            '    totalMonedaAdicional.valor = venta.opInafecta.ToString()
            '    totalesMonedaAdiconal.Add(totalMonedaAdicional)
            'End If
            '-->Operaciones Exneradas
            'If (venta.opInafecta > 0) Then
            '    totalMonedaAdicional = New InformacionAdicional.TotalMonedaAdicional
            '    totalMonedaAdicional.codigo = "1003" '--> Segun catalogo 14
            '    totalMonedaAdicional.nombre = "TOTAL VALOR DE VENTA - OPERACIONES EXONERADAS"
            '    totalMonedaAdicional.valor = venta.opInafecta.ToString()
            '    totalesMonedaAdiconal.Add(totalMonedaAdicional)
            'End If
            '-->Total Descuentos
            'If rbVentaDescuentoGlobal.Checked AndAlso Double.Parse(txtDescuentoGlobal.Text.Trim) > 0 Then
            '    totalMonedaAdicional = New InformacionAdicional.TotalMonedaAdicional
            '    totalMonedaAdicional.codigo = "2005" '--> Segun catalogo 14
            '    'totalMonedaAdicional.nombre = "TOTAL DESCUENTOS"
            '    totalMonedaAdicional.valor = txtDescuentoGlobal.Text.Trim
            '    totalesMonedaAdiconal.Add(totalMonedaAdicional)
            'End If


            '========================================================================
            '-->Elementos adicionales de la Factura y/o Boleta electronica. (Cat. 15)
            '========================================================================
            Dim propiedadesAdicional As New List(Of InformacionAdicional.PropiedadAdicional)
            If Not (venta.isCortesia) Then
                '-->Monto en Letras
                Dim propiedadAdicionale As New InformacionAdicional.PropiedadAdicional
                propiedadAdicionale.codigo = "1000" '-->Segun catalogo 15 (monto en letras)
                propiedadAdicionale.nombre = "MONTO EN LETRAS"
                propiedadAdicionale.value = venta.totalLetras
                propiedadesAdicional.Add(propiedadAdicionale)

                strLog = strLog & "(2)" & propiedadAdicionale.codigo & "--" & propiedadAdicionale.nombre & "--" & propiedadAdicionale.value
            Else
                '-->Transferencia gratuita
                Dim propiedadAdicionale As New InformacionAdicional.PropiedadAdicional
                propiedadAdicionale.codigo = "1002" '-->Segun catalogo 15 (transferencia gratuita)
                propiedadAdicionale.nombre = "TRANSFERENCIA GRATUITA"
                propiedadAdicionale.value = "TRANSFERENCIA GRATUITA DE UN BIEN Y/O SERVICIO PRESTADO GRATUITAMENTE"
                propiedadesAdicional.Add(propiedadAdicionale)

                strLog = strLog & "(2)" & propiedadAdicionale.codigo & "--" & propiedadAdicionale.nombre & "--" & propiedadAdicionale.value
            End If

            '-->Informacion adiconal de tipo monetaria
            Dim infoAdicional As New InformacionAdicional
            infoAdicional.PropiedadesAdicionales = propiedadesAdicional.ToArray()
            infoAdicional.TotalesMonedaAdicional = totalesMonedaAdiconal.ToArray()

            wsventa.informacionAdicional = infoAdicional

            strLog2 = strLog2 & "(3)" & wsventa.informacionAdicional.TotalesMonedaAdicional(0).codigo & "--" & wsventa.informacionAdicional.TotalesMonedaAdicional(0).nombre & "--" & wsventa.informacionAdicional.TotalesMonedaAdicional(0).valor
        Else
            Dim documentoReferencial As New DocumentoReferencia
            documentoReferencial.TipoComprobante = getTipoCompSunat(venta.documentoReferencia.tipoDocumentoID)
            'Dim serie As String = autoCompletSerie(venta.documentoReferencia.numeroDocumento.Split("-")(0).Trim, documentoReferencial.TipoComprobante)
            Dim serie As String = venta.documentoReferencia.numeroDocumento.Split("-")(0).Trim
            Dim correlativo As String = autoCompletCorrelativo(venta.documentoReferencia.numeroDocumento.Split("-")(1).Trim)
            documentoReferencial.NumeroDocumento = serie & "-" & correlativo
            wsventa.documentoReferencia = documentoReferencial
        End If

        'hlamas 15-11-2016
        'dtoVentaCargaContado.ActualizarElectronico(venta.tipoComprobanteID, ObjVentaCargaContado.v_IDFACTURA, strLog, 4)
        'dtoVentaCargaContado.ActualizarElectronico(venta.tipoComprobanteID, ObjVentaCargaContado.v_IDFACTURA, strLog2, 4)

        Return wsventa
    End Function
    ''' <summary>
    ''' Crea el objeto Nota para luego ser enviado al servicio web
    ''' </summary>
    ''' <param name="note">Nueva instancia de la Clase FENote</param>
    ''' <param name="isNotaCredito">True si se trata de una nota de credito, false si es nota de debito</param>
    ''' <returns>Instancia de la Clase Nota</returns>
    Private Shared Function createWSNota(ByVal note As FENota, ByVal isNotaCredito As Boolean, Optional ByVal afectacion As Integer = 1) As Nota
        'Dim wscliente As New feserviceDesarrollo.Cliente
        Dim wscliente As New servicefe.Cliente
        wscliente.numeroDocumento = note.cliente.numeroDocumento
        wscliente.nombres = note.cliente.nombres
        wscliente.direccion = note.cliente.direccion
        wscliente.tipoDocumentoID = getTipoDoctSunat(note.cliente.tipoDocumentoID)

        Dim serie As String = note.documentoReferencia.numeroDocumento.Split("-")(0)
        Dim correlativo As String = autoCompletCorrelativo(note.documentoReferencia.numeroDocumento.Split("-")(1))
        Dim numerocDocumento As String = serie & "-" & correlativo
        Dim documentoReferencia As New DocumentoReferencia
        documentoReferencia.TipoComprobante = getTipoCompSunat(note.documentoReferencia.tipoDocumentoID)
        documentoReferencia.NumeroDocumento = numerocDocumento
        documentoReferencia.FechaDocumento = Convert.ToDateTime(note.documentoReferencia.fechaEmision).ToString("yyyy-MM-dd")

        Dim wsnote As New Nota
        wsnote.cliente = wscliente
        wsnote.documentoReferencia = documentoReferencia
        'wsnote.numeroSerie = autoCompletSerie(note.numeroSerie, documentoReferencia.TipoComprobante)
        wsnote.numeroSerie = note.numeroSerie
        wsnote.numeroCorrelativo = autoCompletCorrelativo(note.numeroCorrelativo)
        wsnote.fechaEmision = Convert.ToDateTime(note.fechaEmison).ToString("yyyy-MM-dd")
        wsnote.codigoTipoNota = note.tipoNota
        wsnote.descripcionTipoNota = note.descripcionTipoNota
        wsnote.tipoComprobanteID = IIf(isNotaCredito, SUNAT_ID_TIPCOM_NOTA_CREDITO, SUNAT_ID_TIPCOM_NOTA_DEBITO)
        wsnote.descripcionSustento = note.descripcionSustento
        wsnote.igv = note.igv.ToString()
        wsnote.subtotal = note.subTotal.ToString()
        wsnote.total = note.total.ToString()
        wsnote.tipoMonedaSoles = note.isMonedaSoles
        wsnote.agenciaID = note.agenciaId
        wsnote.usuarioID = note.usuarioID
        wsnote.usuarioInsercion = note.usuarioInsercion
        wsnote.usuarioModificacion = note.usuarioModificacion
        wsnote.tipoVenta = note.tipoVenta
        '-->Otros conceptos tributarios. (Cat. 14)
        '======================================================
        Dim totalesMonedaAdiconal As New List(Of InformacionAdicional.TotalMonedaAdicional)
        Dim totalMonedaAdicional As New InformacionAdicional.TotalMonedaAdicional
        If afectacion = 1 Then
            '-->Operaciones Gravadas
            totalMonedaAdicional.codigo = "1001" '--> Segun catalogo 14
            totalMonedaAdicional.nombre = "TOTAL VALOR DE VENTA - OPERACIONES GRAVADAS"
            totalMonedaAdicional.valor = wsnote.subtotal.ToString() '--> (no incluye impuesto)
            totalesMonedaAdiconal.Add(totalMonedaAdicional)
        ElseIf afectacion = 2 Then
            '-->Operaciones Exoneradas
            totalMonedaAdicional.codigo = "1003" '--> Segun catalogo 14
            totalMonedaAdicional.nombre = "TOTAL VALOR DE VENTA - OPERACIONES EXONERADAS"
            totalMonedaAdicional.valor = wsnote.subtotal.ToString()
            totalesMonedaAdiconal.Add(totalMonedaAdicional)
        ElseIf afectacion = 3 Then
            '-->Operaciones Exoneradas
            totalMonedaAdicional.codigo = "1002" '--> Segun catalogo 14
            totalMonedaAdicional.nombre = "TOTAL VALOR DE VENTA - OPERACIONES INAFECTAS"
            totalMonedaAdicional.valor = wsnote.subtotal.ToString()
            totalesMonedaAdiconal.Add(totalMonedaAdicional)
        End If

        'totalMonedaAdicional.codigo = "1002" '--> Segun catalogo 14
        'totalMonedaAdicional.nombre = "TOTAL VALOR DE VENTA - OPERACIONES INAFECTAS"
        'totalMonedaAdicional.valor = wsnote.subtotal.ToString()
        'totalesMonedaAdiconal.Add(totalMonedaAdicional)
        '========================================================================
        '-->Elementos adicionales de la Factura y/o Boleta electronica. (Cat. 15)
        '========================================================================
        Dim propiedadesAdicional As New List(Of InformacionAdicional.PropiedadAdicional)
        '-->Monto en Letras
        Dim propiedadAdicionale As New InformacionAdicional.PropiedadAdicional
        propiedadAdicionale.codigo = "1000" '-->Segun catalogo 15 (monto en letras)
        propiedadAdicionale.nombre = "MONTO EN LETRAS"
        propiedadAdicionale.value = note.totalLentras.ToString()
        propiedadesAdicional.Add(propiedadAdicionale)

        '-->Informacion adiconal de tipo monetaria
        Dim infoAdicional As New InformacionAdicional
        infoAdicional.PropiedadesAdicionales = propiedadesAdicional.ToArray()
        infoAdicional.TotalesMonedaAdicional = totalesMonedaAdiconal.ToArray()

        wsnote.informacionAdicional = infoAdicional

        Return wsnote
    End Function
    ''' <summary>
    ''' Relaiza el envio de una factura o boleta electronica a la sunat
    ''' </summary>
    ''' <param name="venta">Class Venta</param>
    ''' <param name="printVenta">Para determinar si se debe imprimir el voucher de venta (true), o no (false)</param>
    ''' <returns>Class Result</returns>
    Public Shared Function sendVentaSunat(venta As FEVenta, dtImpresora As DataTable) As Result
        Try
            Dim wsventa = createWSVenta(venta)
            Dim feServiceClient As New TepsafeserviceClient
            Dim result As Result = feServiceClient.setVenta(TOKEN, wsventa)
            'Actualiza tabla de movimiento
            If result.IsCorrect Then
                Try
                    Dim objFac As New ClsLbTepsa.dtoFACTURA
                    objFac.actualizarEmisonFE(venta.id, venta.tabla)
                Catch
                End Try
            Else
                Try
                    dtoVentaCargaContado.ActualizarElectronico(venta.tipoComprobanteID, venta.id, result.Message, 1)
                Catch ex As Exception
                End Try
            End If
            '-->Realiza la impresion del Tikect
            If Not result.barcode Is Nothing AndAlso Not dtImpresora Is Nothing Then
                venta.numeroSerie = wsventa.numeroSerie
                venta.numeroCorrelativo = wsventa.numeroCorrelativo

                Print(venta, wsventa.tipoComprobanteID, dtImpresora, result)
            Else
                dtoVentaCargaContado.ActualizarElectronico(venta.tipoComprobanteID, venta.id, "Error Codigo de barras", 6)
            End If

            Return result
        Catch ex As Exception
            dtoVentaCargaContado.ActualizarElectronico(venta.tipoComprobanteID, venta.id, ex.Message, 2)
        End Try
    End Function
    ''' <summary>
    ''' Realiza el envio de una nota de credito y/o debito
    ''' </summary>
    ''' <param name="note">Class FENote</param>
    ''' <param name="isNotaCredito">True si se trata de una nota de credito, false si es nota de debito</param>
    ''' <returns>True si la nota fue aceptada, false lo contrario</returns>
    Public Shared Function sendNota(ByVal note As FENota, ByVal isNotaCredito As Boolean, Optional ByVal afectacion As Integer = 1) As Result
        Dim wsnote = createWSNota(note, isNotaCredito, afectacion)

        Dim feServiceClient As New TepsafeserviceClient
        Dim result As Result = feServiceClient.setNota(TOKEN, wsnote)

        'Actualiza tabla de movimiento
        Try
            Dim objFac As New ClsLbTepsa.dtoFACTURA
            objFac.actualizarEmisonFE(note.id, note.tabla)
        Catch
        End Try

        If Not result.IsCorrect Then
            Try
                dtoVentaCargaContado.ActualizarElectronico(IIf(isNotaCredito, 30, 92), note.id, result.Message, 1)
            Catch ex As Exception
            End Try
        End If

        Return result
    End Function
    ''' <summary>
    ''' Realiza el envio de una nota de credito y/o debito, ademas de un nuevo comprobante (Factura/boleta)
    ''' </summary>
    ''' <param name="note">Class FENote</param>
    ''' <param name="isNotaCredito">True si se trata de una nota de credito, false si es nota de debito</param>
    ''' <param name="venta">Class FEVenta</param>
    ''' <returns>True si la nota fue aceptada, false lo contrario</returns>
    Public Shared Function sendNotaVenta(note As FENota, isNotaCredito As Boolean, venta As FEVenta, dtImpresora As DataTable) As Result
        Try
            Dim wsnote = createWSNota(note, isNotaCredito)
            Dim wsventa = createWSVenta(venta)

            Dim feServiceClient As New TepsafeserviceClient
            Dim result As Result = feServiceClient.setNotaVenta(TOKEN, wsnote, wsventa)

            '-->Realiza la impresion del Tikect
            If Not result.barcode Is Nothing AndAlso Not dtImpresora Is Nothing Then
                venta.numeroSerie = wsventa.numeroSerie
                venta.numeroCorrelativo = wsventa.numeroCorrelativo
                Print(venta, wsventa.tipoComprobanteID, dtImpresora, result)
            End If

            If Not result.IsCorrect Then
                Try
                    dtoVentaCargaContado.ActualizarElectronico(venta.tipoComprobanteID, venta.id, result.Message, 1)
                Catch ex As Exception
                End Try
            End If

            Return result
        Catch ex As Exception
            dtoVentaCargaContado.ActualizarElectronico(venta.tipoComprobanteID, venta.id, ex.Message, 2)
        End Try
    End Function
    ''' <summary>
    ''' Realiza la impresion del Voucher
    ''' </summary>
    ''' <param name="venta">Class Venta</param>
    ''' <param name="barcode">Arreglo de bytes del codigo de barras retornado por el web service</param>
    ''' <param name="tipoComprobanteId">Identificador del tipo de comprobante, segun catalogo de la sunat</param>
    Shared Sub Print(ByVal venta As FEVenta, ByVal tipoComprobanteId As String, ByVal dtImpresora As DataTable, ByVal result As Result)
        Try
            If (venta.tipoComprobanteID = TITAN_ID_TIPCOM_BOLETA) Or venta.tipoComprobanteID = TITAN_ID_TIPCOM_EQUIPAJE Then
                venta.cliente.tipoDocumento = getNameTipoDoct(venta.cliente.tipoDocumentoID)
            End If
            If (venta.detalleVenta Is Nothing AndAlso Not result.listDetalleVenta Is Nothing) Then
                Dim listDetalleVenta As New List(Of FEDetalleVenta)
                For Each wsdetalleVenta As DetalleVenta In result.listDetalleVenta
                    Dim fedetalleVenta As New FEDetalleVenta
                    fedetalleVenta.descripcion = wsdetalleVenta.descripcion
                    fedetalleVenta.cantidad = wsdetalleVenta.cantidad
                    fedetalleVenta.tarifa = wsdetalleVenta.tarifa

                    listDetalleVenta.Add(fedetalleVenta)
                Next
                venta.detalleVenta = listDetalleVenta
            End If


            Dim dsfe As New DSFacturacionElectronica
            For Each detalle As FEDetalleVenta In venta.detalleVenta
                dsfe.Boleta.Rows.Add(venta.origen _
                                                , venta.destino _
                                                , venta.remitenete _
                                                , venta.consignado _
                                                , venta.tipoEntrega _
                                                , venta.direccionEntrega _
                                                , detalle.descripcion _
                                                , detalle.cantidad _
                                                , detalle.tarifa _
                                                , IIf(venta.isCortesia, 0, FormatNumber((detalle.tarifa / (VAL_IGV / 100 + 1)) * detalle.cantidad, 2)) _
                                                , venta.opExonerada _
                                                , venta.opInafecta _
                                                , IIf(venta.isCortesia, 0, venta.opGravada) _
                                                , IIf(venta.isCortesia, 0, venta.igv) _
                                                , IIf(venta.isCortesia, 0, venta.total) _
                                                , venta.formaPago _
                                                , venta.fechaEmision _
                                                , venta.agenciaEmision _
                                                , venta.usuarioEmision _
                                                , result.barcode _
                                                , venta.numeroSerie & "- " & venta.numeroCorrelativo _
                                                , venta.cliente.numeroDocumento _
                                                , venta.cliente.nombres _
                                                , venta.cliente.direccion _
                                                , venta.totalLetras _
                                                , venta.cliente.tipoDocumento _
                                                , IIf(venta.isCortesia, venta.total, 0) _
                                                , result.barcode_QR
                                                )
            Next

            Dim pathFileRpt As String = ""
            If (tipoComprobanteId.Equals(SUNAT_ID_TIPCOM_FACTURA)) Then
                pathFileRpt = Application.StartupPath() & "\FacturacionElectronica\Rpts\Factura.rpt"
            ElseIf (tipoComprobanteId.Equals(SUNAT_ID_TIPCOM_BOLETA)) Then
                pathFileRpt = Application.StartupPath() & "\FacturacionElectronica\Rpts\Boleta.rpt"
            ElseIf (tipoComprobanteId.Equals(SUNAT_ID_TIPCOM_TICKET)) Then
                If venta.producto = "EQUIPAJE" Then
                    pathFileRpt = Application.StartupPath() & "\FacturacionElectronica\Rpts\TicketEquipaje.rpt"
                Else
                    pathFileRpt = Application.StartupPath() & "\FacturacionElectronica\Rpts\Ticket.rpt"
                End If
            ElseIf (venta.producto = "PCE") Then
                pathFileRpt = Application.StartupPath() & "\FacturacionElectronica\Rpts\Pce.rpt"
            End If

            If (pathFileRpt <> "") Then
                Dim cryRpt As New ReportDocument
                cryRpt.Load(pathFileRpt, OpenReportMethod.OpenReportByTempCopy)
                cryRpt.SetDataSource(dsfe)

                Dim margins As PageMargins
                margins = cryRpt.PrintOptions.PageMargins
                margins.topMargin = 0

                Try
                    '-->Impresora por default
                    'Dim pdoc As New System.Drawing.Printing.PrintDocument
                    'Dim strDefaultPrinter As String = pdoc.PrinterSettings.PrinterName

                    '-->Recuperando la configuracion de la impresora
                    Dim printerName As String = dtImpresora.Rows(0).Item("impresora")
                    'printerName = "PDF1"
                    cryRpt.PrintOptions.PrinterName = printerName
                    cryRpt.PrintOptions.PaperSize = PaperSize.DefaultPaperSize
                    cryRpt.PrintOptions.ApplyPageMargins(margins)
                    cryRpt.PrintToPrinter(1, False, 0, 0)
                    cryRpt.Close()
                Catch ex As Exception
                    Throw New Exception
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show("Error al intentar imprimir el comprobante." & Chr(13) & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Shared Sub Print(ByVal venta As FEVenta, ByVal tipoComprobanteId As String, ByVal dtImpresora As DataTable, ByVal result As Result, ByVal opcion As Integer)
        Try
            If (venta.tipoComprobanteID = TITAN_ID_TIPCOM_BOLETA) Or venta.tipoComprobanteID = TITAN_ID_TIPCOM_EQUIPAJE Then
                venta.cliente.tipoDocumento = getNameTipoDoct(venta.cliente.tipoDocumentoID)
            End If
            If (venta.detalleVenta Is Nothing AndAlso Not result.listDetalleVenta Is Nothing) Then
                Dim listDetalleVenta As New List(Of FEDetalleVenta)
                For Each wsdetalleVenta As DetalleVenta In result.listDetalleVenta
                    Dim fedetalleVenta As New FEDetalleVenta
                    fedetalleVenta.descripcion = wsdetalleVenta.descripcion
                    fedetalleVenta.cantidad = wsdetalleVenta.cantidad
                    fedetalleVenta.tarifa = wsdetalleVenta.tarifa

                    listDetalleVenta.Add(fedetalleVenta)
                Next
                venta.detalleVenta = listDetalleVenta
            End If


            Dim dsfe As New DSFacturacionElectronica
            For Each detalle As FEDetalleVenta In venta.detalleVenta
                If detalle.descripcion = "EQUIPAJE" And detalle.cantidad = 0 Then Exit For
                dsfe.Boleta.Rows.Add(venta.origen _
                                                , venta.destino _
                                                , venta.remitenete _
                                                , venta.consignado _
                                                , venta.tipoEntrega _
                                                , venta.direccionEntrega _
                                                , detalle.descripcion _
                                                , detalle.cantidad _
                                                , detalle.tarifa _
                                                , IIf(venta.isCortesia, 0, FormatNumber((detalle.tarifa / (VAL_IGV / 100 + 1)) * detalle.cantidad, 2)) _
                                                , venta.opExonerada _
                                                , venta.opInafecta _
                                                , IIf(venta.isCortesia, 0, venta.opGravada) _
                                                , IIf(venta.isCortesia, 0, venta.igv) _
                                                , IIf(venta.isCortesia, 0, venta.total) _
                                                , venta.formaPago _
                                                , venta.fechaEmision _
                                                , venta.agenciaEmision _
                                                , venta.usuarioEmision _
                                                , result.barcode _
                                                , venta.numeroSerie & "- " & venta.numeroCorrelativo _
                                                , venta.cliente.numeroDocumento _
                                                , venta.cliente.nombres _
                                                , venta.cliente.direccion _
                                                , venta.totalLetras _
                                                , venta.cliente.tipoDocumento _
                                                , IIf(venta.isCortesia, venta.total, 0))
            Next

            Dim pathFileRpt As String = ""
            If (tipoComprobanteId.Equals(SUNAT_ID_TIPCOM_FACTURA)) Then
                pathFileRpt = Application.StartupPath() & "\FacturacionElectronica\Rpts\Factura.rpt"
            ElseIf (tipoComprobanteId.Equals(SUNAT_ID_TIPCOM_BOLETA)) Then
                pathFileRpt = Application.StartupPath() & "\FacturacionElectronica\Rpts\Boleta.rpt"
            ElseIf (tipoComprobanteId.Equals(SUNAT_ID_TIPCOM_TICKET)) Then
                If venta.producto = "EQUIPAJE" Then
                    pathFileRpt = Application.StartupPath() & "\FacturacionElectronica\Rpts\TicketEquipaje.rpt"
                Else
                    pathFileRpt = Application.StartupPath() & "\FacturacionElectronica\Rpts\Ticket.rpt"
                End If
            ElseIf (tipoComprobanteId.Equals(SUNAT_ID_TIPCOM_PCE)) Then
                pathFileRpt = Application.StartupPath() & "\FacturacionElectronica\Rpts\Pce.rpt"
            End If

            If (pathFileRpt <> "") Then
                Dim cryRpt As New ReportDocument
                cryRpt.Load(pathFileRpt, OpenReportMethod.OpenReportByTempCopy)
                cryRpt.SetDataSource(dsfe)

                Dim margins As PageMargins
                margins = cryRpt.PrintOptions.PageMargins
                margins.topMargin = 0

                Try
                    '-->Impresora por default
                    'Dim pdoc As New System.Drawing.Printing.PrintDocument
                    'Dim strDefaultPrinter As String = pdoc.PrinterSettings.PrinterName

                    '-->Recuperando la configuracion de la impresora
                    Dim printerName As String = dtImpresora.Rows(0).Item("impresora")
                    'printerName = "PDF1"
                    cryRpt.PrintOptions.PrinterName = printerName
                    cryRpt.PrintOptions.PaperSize = PaperSize.DefaultPaperSize
                    cryRpt.PrintOptions.ApplyPageMargins(margins)
                    cryRpt.PrintToPrinter(1, False, 0, 0)
                    cryRpt.Close()
                Catch ex As Exception
                    Throw New Exception
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show("Error al intentar imprimir el comprobante." & Chr(13) & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Shared Sub Print(ByVal venta As FEVenta, ByVal dtImpresora As DataTable)
        Try
            venta.cliente.tipoDocumento = getNameTipoDoct(venta.cliente.tipoDocumentoID)
            Dim dsfe As New DSFacturacionElectronica
            For Each detalle As FEDetalleVenta In venta.detalleVenta
                If detalle.descripcion <> "TARIFA BASE" Then
                    dsfe.Boleta.Rows.Add(venta.origen _
                                                    , venta.destino _
                                                    , venta.remitenete _
                                                    , venta.consignado _
                                                    , venta.tipoEntrega _
                                                    , venta.direccionEntrega _
                                                    , detalle.descripcion _
                                                    , detalle.bultos _
                                                    , detalle.cantidad _
                                                    , IIf(venta.isCortesia, 0, FormatNumber((detalle.tarifa / (VAL_IGV / 100 + 1)) * detalle.cantidad, 2)) _
                                                    , venta.opExonerada _
                                                    , venta.opInafecta _
                                                    , IIf(venta.isCortesia, 0, venta.opGravada) _
                                                    , IIf(venta.isCortesia, 0, venta.igv) _
                                                    , IIf(venta.isCortesia, 0, venta.total) _
                                                    , venta.formaPago _
                                                    , venta.fechaEmision _
                                                    , venta.agenciaEmision _
                                                    , venta.usuarioEmision _
                                                    , Nothing _
                                                    , venta.numeroCorrelativo _
                                                    , venta.cliente.numeroDocumento _
                                                    , venta.cliente.nombres _
                                                    , venta.direccionFiscal _
                                                    , venta.totalLetras _
                                                    , venta.cliente.tipoDocumento _
                                                    , IIf(venta.isCortesia, venta.total, 0))
                End If
            Next

            Dim pathFileRpt As String = ""
            pathFileRpt = Application.StartupPath() & "\FacturacionElectronica\Rpts\Pce.rpt"

            If (pathFileRpt <> "") Then
                Dim cryRpt As New ReportDocument
                cryRpt.Load(pathFileRpt, OpenReportMethod.OpenReportByTempCopy)
                cryRpt.SetDataSource(dsfe)

                Dim margins As PageMargins
                margins = cryRpt.PrintOptions.PageMargins
                margins.topMargin = 0

                Try
                    '-->Impresora por default
                    'Dim pdoc As New System.Drawing.Printing.PrintDocument
                    'Dim strDefaultPrinter As String = pdoc.PrinterSettings.PrinterName

                    '-->Recuperando la configuracion de la impresora
                    Dim printerName As String = dtImpresora.Rows(0).Item("impresora")
                    'printerName = "PDF1"
                    cryRpt.PrintOptions.PrinterName = printerName
                    cryRpt.PrintOptions.PaperSize = PaperSize.DefaultPaperSize
                    cryRpt.PrintOptions.ApplyPageMargins(margins)
                    cryRpt.PrintToPrinter(1, False, 0, 0)
                    cryRpt.Close()
                Catch ex As Exception
                    Throw New Exception
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show("Error al intentar imprimir el comprobante." & Chr(13) & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Shared Function isAvoidable(Tipo As String, Fecha As String, serie As String, numero As String, motivo As String) As Boolean
        Dim feServiceClient As New TepsafeserviceClient
        Dim documentoBaja As New DocumentoBaja
        documentoBaja.tipoDocumentoID = Tipo
        documentoBaja.fechaEmision = Fecha
        documentoBaja.numeroSerie = serie
        documentoBaja.numeroCorrelativo = numero
        documentoBaja.descripcionMotivo = motivo
        documentoBaja.usuarioModificacion = dtoUSUARIOS.iLOGIN
        Dim result As Result = feServiceClient.setBajaDocumento(TOKEN, documentoBaja)
        'Dim result As Result = feServiceClient.setBajaDocumento(TOKEN, Tipo, Fecha, serie, numero, motivo)
        'Dim result As Result = feServiceClient.setBajaDocumento(TOKEN, "01", "22/02/2017", "B034", "00003633")
        feServiceClient.Close()
        Return result.IsCorrect
    End Function
    ''' <summary>
    ''' Realiza la reimpresion del comprobante
    ''' </summary>
    ''' <param name="feventa">Instancia de la venta</param>
    Shared Function reimprimirComprobante(ByVal feventa As FEVenta) As Result
        feventa.numeroCorrelativo = autoCompletCorrelativo(feventa.numeroCorrelativo)
        Dim dtPrinter As DataTable = buscarPrint()
        Dim tipoComprobante As String = getTipoCompSunat(feventa.tipoComprobanteID)
        Dim feServiceClient As New TepsafeserviceClient
        '-->Realiza la busqueda del detalle del comprobante
        Dim result As Result = feServiceClient.buscarDetalleComprobante(TOKEN, tipoComprobante, feventa.numeroSerie, feventa.numeroCorrelativo)

        If result.IsCorrect AndAlso Not result.barcode Is Nothing Then
            Print(feventa, tipoComprobante, dtPrinter, result)
        End If

        Return result
    End Function

    ''' <summary>
    ''' Busca la impresora para la impresion del comprobante
    ''' </summary>
    ''' <returns>DataTable con los datos de la impresora configurada</returns>
    Shared Function buscarPrint() As DataTable
        Dim db_bd As New BaseDatos
        db_bd.Conectar()
        db_bd.CrearComando("PKG_UTILITARIOS.SP_LOAD_IMPRESION", CommandType.StoredProcedure)
        db_bd.AsignarParametro("iIP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
        db_bd.AsignarParametro("iTipoimpresion", 1, OracleClient.OracleType.Number)
        db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
        db_bd.Desconectar()
        Dim dataTable As DataTable = db_bd.EjecutarDataTable

        Dim NAME_PRINT As String = Nothing
        If dataTable.Rows.Count > 0 Then
            If Not IsDBNull(dataTable.Rows(0).Item("Control_Impresoras")) Then
                NAME_PRINT = dataTable.Rows(0).Item("Control_Impresoras")
            End If
        End If

        '-->Cargo es el nombre por defecto, por si no haya ninguna configurada.
        If (NAME_PRINT Is Nothing) Then _
            NAME_PRINT = "CARGO"

        Dim dtImpresora As New DataTable
        dtImpresora.Columns.Add("impresora")
        dtImpresora.Rows.Add(NAME_PRINT)

        Return dtImpresora
    End Function

    Shared Sub PrintGE(ByVal venta As FEVenta, ByVal dtImpresora As DataTable, ByVal barra() As Byte)
        Try
            venta.cliente.tipoDocumento = getNameTipoDoct(venta.cliente.tipoDocumentoID)
            Dim dsfe As New DSFacturacionElectronica
            For Each detalle As FEDetalleVenta In venta.detalleVenta
                If detalle.descripcion <> "TARIFA BASE" Then
                    dsfe.Boleta.Rows.Add(venta.origen _
                                                    , venta.destino _
                                                    , venta.remitenete _
                                                    , venta.consignado _
                                                    , venta.tipoEntrega _
                                                    , venta.cliente.direccion _
                                                    , detalle.descripcion _
                                                    , detalle.bultos _
                                                    , detalle.cantidad _
                                                    , IIf(venta.isCortesia, 0, FormatNumber((detalle.tarifa / (VAL_IGV / 100 + 1)) * detalle.cantidad, 2)) _
                                                    , venta.opExonerada _
                                                    , venta.opInafecta _
                                                    , IIf(venta.isCortesia, 0, venta.opGravada) _
                                                    , IIf(venta.isCortesia, 0, venta.igv) _
                                                    , IIf(venta.isCortesia, 0, venta.total) _
                                                    , venta.formaPago _
                                                    , venta.fechaEmision _
                                                    , venta.agenciaEmision _
                                                    , venta.usuarioEmision _
                                                    , barra _
                                                    , venta.numeroCorrelativo _
                                                    , venta.cliente.numeroDocumento _
                                                    , venta.cliente.nombres _
                                                    , venta.direccionFiscal _
                                                    , venta.MontoLetras _
                                                    , venta.cliente.tipoDocumento _
                                                    , IIf(venta.isCortesia, venta.total, 0))
                End If
            Next

            Dim pathFileRpt As String = ""
            pathFileRpt = Application.StartupPath() & "\FacturacionElectronica\Rpts\Ge.rpt"

            If (pathFileRpt <> "") Then
                Dim cryRpt As New ReportDocument
                cryRpt.Load(pathFileRpt, OpenReportMethod.OpenReportByTempCopy)
                cryRpt.SetDataSource(dsfe)

                Dim margins As PageMargins
                margins = cryRpt.PrintOptions.PageMargins
                margins.topMargin = 0

                Try
                    '-->Impresora por default
                    'Dim pdoc As New System.Drawing.Printing.PrintDocument
                    'Dim strDefaultPrinter As String = pdoc.PrinterSettings.PrinterName

                    '-->Recuperando la configuracion de la impresora
                    Dim printerName As String = dtImpresora.Rows(0).Item("impresora")
                    'printerName = "PDF1"
                    cryRpt.PrintOptions.PrinterName = printerName
                    cryRpt.PrintOptions.PaperSize = PaperSize.DefaultPaperSize
                    cryRpt.PrintOptions.ApplyPageMargins(margins)
                    cryRpt.PrintToPrinter(1, False, 0, 0)
                    cryRpt.Close()
                Catch ex As Exception
                    Throw New Exception
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show("Error al intentar imprimir el comprobante." & Chr(13) & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
