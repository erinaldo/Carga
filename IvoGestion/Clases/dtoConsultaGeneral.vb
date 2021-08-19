Imports AccesoDatos
Imports System.Data

Public Class dtoConsultaGeneral

    Private sDocumento As String
    Private iTipoDocumento As Integer

    Public curId As DataTable

    'Public curVenta As New ADODB.Recordset
    Public curVenta As DataTable

    'Public curDocumento As New ADODB.Recordset
    Public curDocumento As DataTable

    'Public curCliente As New ADODB.Recordset
    Public curCliente As DataTable

    'Public curEmail As New ADODB.Recordset
    Public curEmail As DataTable

    'Public curCel As New ADODB.Recordset
    Public curCel As DataTable

    'Public curPrefactura As New ADODB.Recordset
    Public curPrefactura As DataTable

    'Public curFactura As New ADODB.Recordset
    Public curFactura As DataTable

    'Public curBultos As New ADODB.Recordset
    Public curBultos As DataTable

    Public curArticulo As DataTable

    Dim dr As DataRow
    Dim dc As DataColumn

    Public WriteOnly Property Documento() As String
        Set(ByVal value As String)
            sDocumento = value
        End Set
    End Property

    Public WriteOnly Property Tipo() As Integer
        Set(ByVal value As Integer)
            iTipoDocumento = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal documento As String)
        sDocumento = documento
    End Sub

    Private Function ObtieneTipoDocumento() As Integer
        Dim iPosicion As Integer

        iPosicion = InStr(sDocumento, "-")
        If iPosicion = 0 Then
            iTipoDocumento = 2
        Else
            iTipoDocumento = 1
        End If
    End Function

    Public Function ObtenerDocumento() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOGENERAL.SP_OBTENER_IDDOCUMENTO", CommandType.StoredProcedure) 'GORDITO
            db.AsignarParametro("documento", sDocumento, OracleClient.OracleType.VarChar)
            'db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_Temp", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            curId = ds.Tables(0)
            Return True
        Catch ex As Exception
            'Throw New Exception(ex.Excepcion)
        End Try
    End Function

    'Public Function Ejecutar1(iComprobante As Integer, iCliente As Integer, iPrefactura As Integer, iFacturado As Integer, iTipo As Integer) As Boolean
    '    Try
    '        Dim db As New BaseDatos
    '        db.Conectar()
    '        db.CrearComando("PKG_IVOGENERAL.SP_CONSULTA_VENTAS_1_dh_2", CommandType.StoredProcedure)
    '        db.AsignarParametro("iComprobante", iComprobante, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("iCliente", iCliente, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("iPrefactura", iPrefactura, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("iFacturado", iFacturado, OracleClient.OracleType.Int32)
    '        db.AsignarParametro("iTipo", iTipo, OracleClient.OracleType.Int32)

    '        db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
    '        db.AsignarParametro("cur_documento", OracleClient.OracleType.Cursor)
    '        db.AsignarParametro("cur_cliente", OracleClient.OracleType.Cursor)
    '        db.AsignarParametro("cur_email", OracleClient.OracleType.Cursor)
    '        db.AsignarParametro("cur_movil", OracleClient.OracleType.Cursor)
    '        db.AsignarParametro("cur_prefactura", OracleClient.OracleType.Cursor)
    '        db.AsignarParametro("cur_factura", OracleClient.OracleType.Cursor)
    '        db.AsignarParametro("cur_bultos", OracleClient.OracleType.Cursor)
    '        db.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
    '        db.Desconectar()
    '        Dim ds As DataSet = db.EjecutarDataSet

    '        If IsNothing(curVenta) Then
    '            curVenta = New DataTable
    '            CrearColumnasVentas()
    '        End If
    '        CargarColumnasVentas(ds.Tables(0))

    '        If curVenta.Rows.Count > 0 Then

    '            If IsNothing(curDocumento) Then
    '                curDocumento = New DataTable
    '                CrearColumnasDocumentos()
    '            End If
    '            CargarColumnasDocumentos(ds.Tables(1))

    '            If IsNothing(curCliente) Then
    '                curCliente = New DataTable
    '                CrearColumnasCliente()
    '            End If
    '            CargarColumnasCliente(ds.Tables(2))

    '            If IsNothing(curEmail) Then
    '                curEmail = New DataTable
    '                CrearColumnasMail()
    '            End If
    '            CargarColumnasMail(ds.Tables(3))

    '            If IsNothing(curCel) Then
    '                curCel = New DataTable
    '                CrearColumnasCel()
    '            End If
    '            CargarColumnasCel(ds.Tables(4))

    '            If IsNothing(curPrefactura) Then
    '                curPrefactura = New DataTable
    '                CrearColumnasPrefactura()
    '            End If
    '            CargarColumnasPrefactura(ds.Tables(5))

    '            If IsNothing(curFactura) Then
    '                curFactura = New DataTable
    '                CrearColumnasFactura()
    '            End If
    '            CargarColumnasFactura(ds.Tables(6))

    '            If IsNothing(curBultos) Then
    '                curBultos = New DataTable
    '                CrearColumnasBultos()
    '            End If
    '            CargarColumnasBultos(ds.Tables(7))
    '            'curDocumento = ds.Tables(1)
    '            'curCliente = ds.Tables(2)
    '            'curEmail = ds.Tables(3)
    '            'curCel = ds.Tables(4)
    '            'curPrefactura = ds.Tables(5)
    '            'curFactura = ds.Tables(6)
    '            'curBultos = ds.Tables(7)
    '        End If
    '        Return True

    '    Catch ex As Excepcion
    '        Throw New Exception(ex.Excepcion)
    '    End Try
    'End Function

    Public Function Ejecutar() As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("SP_CONSULTA_VENTAS", CommandType.StoredProcedure)
            db.AsignarParametro("documento", sDocumento, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_documento", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            curVenta = ds.Tables(0)
            If curVenta.Rows.Count > 0 Then
                curDocumento = ds.Tables(1)
            End If
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Private Function CrearColumnasArticulo()
        dc = New DataColumn
        dc.ColumnName = "Nombre_Articulo"
        curArticulo.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Precio_x_Articulo"
        curArticulo.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Cantidad_Articulos"
        curArticulo.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Total"
        curArticulo.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Peso"
        curArticulo.Columns.Add(dc)
    End Function

    Private Function CrearColumnasVentas()
        dc = New DataColumn
        dc.ColumnName = "Fecha_Factura"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Tipo_Documento"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Forma_Pago"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Numero_Documento"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Razon_Social"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Remitente"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Direccion1"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Direccion2"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Contacto"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Descuento"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Memo"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Origen"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Destino"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Agencia_Origen"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Agencia_Destino"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Tipo_Tarjeta"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Numero_Tarjeta"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Consignado"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Cantidad_X_Peso"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Total_Peso"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Cantidad_X_Volumen"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Total_Volumen"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Cantidad_X_Sobre"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Total_Peso_X_Articulo"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Cantidad_X_Articulo"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Precio_X_Peso"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Precio_X_Volumen"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Precio_X_Sobre"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Cantidad_Total"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Subtotal"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Impuesto"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Total"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Monto_Base"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Monto_Descuento"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Sub_Total_Ca"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "IdFactura"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Estado"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Funcionario"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Tipo"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Nro"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Subcuenta"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Entrega"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "IdTipo_Comprobante"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "IdEstado_Envio"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Recepcion"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Cargo"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "CargoFecha"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "IdPersona"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "NroBoleto"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "IdProcesos"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Tipo_Carga"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Tipo_Tarifa"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "dt"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "monto_entrega_domicilio"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "subcuenta_origen"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "monto_fuera_zona"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "monto_devolucion_cargo"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "cargos"
        curVenta.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "referencia"
        curVenta.Columns.Add(dc)

    End Function
    Private Function CrearColumnasDocumentos()
        dc = New DataColumn
        dc.ColumnName = "Id_Guias_Envio_Doc"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "IdGuias_Envio"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "IdTipo_Comprobante"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Nro_Serie"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Nro_Docu"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "IdUsuario_Personal"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "IdUsuario_Personalmod"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "IdRol_Usuario"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "IdRol_Usuariomod"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Ip"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "IpMod"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Fecha_Registro"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Fecha_Actualizacion"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "IdEstado_Registro"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Fecha"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Monto_Tipo_Cambio"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Monto_Sub_Total"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Monto_Impuesto"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Total_Costo"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Obs"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "IdTipo_Moneda"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Porcen"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Tipo_Monto"
        curDocumento.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Ind_Procedencia"
        curDocumento.Columns.Add(dc)
    End Function
    Private Function CrearColumnasCliente()
        dc = New DataColumn
        dc.ColumnName = "Gerente_General"
        curCliente.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Representante_Legal"
        curCliente.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "E_mail"
        curCliente.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Telefono"
        curCliente.Columns.Add(dc)
    End Function
    Private Function CrearColumnasMail()
        dc = New DataColumn
        dc.ColumnName = "E_Mail"
        curEmail.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "IdPersona"
        curEmail.Columns.Add(dc)
    End Function
    Private Function CrearColumnasCel()
        dc = New DataColumn
        dc.ColumnName = "IdTipo_Comunicacion"
        curCel.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Nro_Movil"
        curCel.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Tipo_Comunicacion"
        curCel.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "IdPersona"
        curCel.Columns.Add(dc)
    End Function
    Private Function CrearColumnasPrefactura()
        dc = New DataColumn
        dc.ColumnName = "Nro_Prefactura"
        curPrefactura.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Fecha_Registro"
        curPrefactura.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Estado"
        curPrefactura.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Fecha_Factura"
        curPrefactura.Columns.Add(dc)
    End Function
    Private Function CrearColumnasFactura()
        dc = New DataColumn
        dc.ColumnName = "Nro_Documento"
        curFactura.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Fecha_Factura"
        curFactura.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Estado_Registro"
        curFactura.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Nombre_Corto"
        curFactura.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "IdPersona"
        curFactura.Columns.Add(dc)
    End Function
    Private Function CrearColumnasBultos()
        dc = New DataColumn
        dc.ColumnName = "IdTipo_Comprobante"
        curBultos.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "IdComprobante"
        curBultos.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "GT"
        curBultos.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Nro_Bus"
        curBultos.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Manual1"
        curBultos.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "PDT1"
        curBultos.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "Manual2"
        curBultos.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "PDT2"
        curBultos.Columns.Add(dc)
    End Function

    Private Function CargarColumnasVentas(dtVenta As DataTable)
        dr = curVenta.NewRow
        dr("Fecha_Factura") = dtVenta.Rows(0).Item("Fecha_Factura")
        dr("Tipo_Documento") = dtVenta.Rows(0).Item("Tipo_Documento")
        dr("Forma_Pago") = dtVenta.Rows(0).Item("Forma_Pago")
        dr("Numero_Documento") = dtVenta.Rows(0).Item("Numero_Documento")
        dr("Razon_Social") = dtVenta.Rows(0).Item("Razon_Social")
        dr("Remitente") = dtVenta.Rows(0).Item("Remitente")
        dr("Direccion1") = dtVenta.Rows(0).Item("Direccion1")
        dr("Direccion2") = dtVenta.Rows(0).Item("Direccion2")
        dr("Contacto") = dtVenta.Rows(0).Item("Contacto")
        dr("Descuento") = dtVenta.Rows(0).Item("Descuento")
        dr("Memo") = dtVenta.Rows(0).Item("Memo")
        dr("Origen") = dtVenta.Rows(0).Item("Origen")
        dr("Destino") = dtVenta.Rows(0).Item("Destino")
        dr("Agencia_Origen") = dtVenta.Rows(0).Item("Agencia_Origen")
        dr("Agencia_Destino") = dtVenta.Rows(0).Item("Agencia_Destino")
        dr("Tipo_Tarjeta") = dtVenta.Rows(0).Item("Tipo_Tarjeta")
        dr("Numero_Tarjeta") = dtVenta.Rows(0).Item("Numero_Tarjeta")
        dr("Consignado") = dtVenta.Rows(0).Item("Consignado")
        dr("Cantidad_X_Peso") = dtVenta.Rows(0).Item("Cantidad_X_Peso")
        dr("Total_Peso") = dtVenta.Rows(0).Item("Total_Peso")
        dr("Cantidad_X_Volumen") = dtVenta.Rows(0).Item("Cantidad_X_Volumen")
        dr("Total_Volumen") = dtVenta.Rows(0).Item("Total_Volumen")
        dr("Cantidad_X_Sobre") = dtVenta.Rows(0).Item("Cantidad_X_Sobre")
        dr("Total_Peso_X_Articulo") = dtVenta.Rows(0).Item("Total_Peso_X_Articulo")
        dr("Cantidad_X_Articulo") = dtVenta.Rows(0).Item("Cantidad_X_Articulo")
        dr("Precio_X_Peso") = dtVenta.Rows(0).Item("Precio_X_Peso")
        dr("Precio_X_Volumen") = dtVenta.Rows(0).Item("Precio_X_Volumen")
        dr("Precio_X_Sobre") = dtVenta.Rows(0).Item("Precio_X_Sobre")
        dr("Cantidad_Total") = dtVenta.Rows(0).Item("Cantidad_Total")
        dr("Subtotal") = dtVenta.Rows(0).Item("Subtotal")
        dr("Impuesto") = dtVenta.Rows(0).Item("Impuesto")
        dr("Total") = dtVenta.Rows(0).Item("Total")
        dr("Monto_Base") = dtVenta.Rows(0).Item("Monto_Base")
        dr("Monto_Descuento") = dtVenta.Rows(0).Item("Monto_Descuento")
        dr("Sub_Total_Ca") = dtVenta.Rows(0).Item("Sub_Total_Ca")
        dr("IdFactura") = dtVenta.Rows(0).Item("IdFactura")
        dr("Estado") = dtVenta.Rows(0).Item("Estado")
        dr("Funcionario") = dtVenta.Rows(0).Item("Funcionario")
        dr("Tipo") = dtVenta.Rows(0).Item("Tipo")
        dr("Nro") = dtVenta.Rows(0).Item("Nro")
        dr("Subcuenta") = dtVenta.Rows(0).Item("Subcuenta")
        dr("Entrega") = dtVenta.Rows(0).Item("Entrega")
        dr("IdTipo_Comprobante") = dtVenta.Rows(0).Item("IdTipo_Comprobante")
        dr("IdEstado_Envio") = dtVenta.Rows(0).Item("IdEstado_Envio")
        dr("Recepcion") = dtVenta.Rows(0).Item("Recepcion")
        dr("Cargo") = dtVenta.Rows(0).Item("Cargo")
        dr("CargoFecha") = dtVenta.Rows(0).Item("CargoFecha")
        dr("IdPersona") = dtVenta.Rows(0).Item("IdPersona")
        dr("NroBoleto") = dtVenta.Rows(0).Item("NroBoleto")
        dr("IdProcesos") = dtVenta.Rows(0).Item("IdProcesos")
        dr("Tipo_Carga") = dtVenta.Rows(0).Item("Tipo_Carga")
        dr("Tipo_Tarifa") = dtVenta.Rows(0).Item("Tipo_Tarifa")
        dr("dt") = dtVenta.Rows(0).Item("dt")
        dr("monto_entrega_domicilio") = dtVenta.Rows(0).Item("monto_entrega_domicilio")
        dr("subcuenta_origen") = dtVenta.Rows(0).Item("subcuenta_origen")
        dr("monto_fuera_zona") = dtVenta.Rows(0).Item("monto_fuera_zona")
        dr("monto_devolucion_cargo") = dtVenta.Rows(0).Item("monto_devolucion_cargo")
        dr("cargos") = dtVenta.Rows(0).Item("cargos")
        dr("referencia") = dtVenta.Rows(0).Item("referencia")
        curVenta.Rows.Add(dr)
    End Function
    Private Function CargarColumnasDocumentos(dtDocumento As DataTable)
        If dtDocumento.Rows.Count > 0 Then
            For index As Integer = 0 To dtDocumento.Rows.Count - 1
                dr = curDocumento.NewRow
                dr("Id_Guias_Envio_Doc") = dtDocumento.Rows(index).Item("Id_Guias_Envio_Doc")
                dr("IdGuias_Envio") = dtDocumento.Rows(index).Item("IdGuias_Envio")
                dr("IdTipo_Comprobante") = dtDocumento.Rows(index).Item("IdTipo_Comprobante")
                dr("Nro_Serie") = dtDocumento.Rows(index).Item("Nro_Serie")
                dr("Nro_Docu") = dtDocumento.Rows(index).Item("Nro_Docu")
                dr("IdUsuario_Personal") = dtDocumento.Rows(index).Item("IdUsuario_Personal")
                dr("IdUsuario_Personalmod") = dtDocumento.Rows(index).Item("IdUsuario_Personalmod")
                dr("IdRol_Usuario") = dtDocumento.Rows(index).Item("IdRol_Usuario")
                dr("IdRol_Usuariomod") = dtDocumento.Rows(index).Item("IdRol_Usuariomod")
                dr("Ip") = dtDocumento.Rows(index).Item("Ip")
                dr("IpMod") = dtDocumento.Rows(index).Item("IpMod")
                dr("Fecha_Registro") = dtDocumento.Rows(index).Item("Fecha_Registro")
                dr("Fecha_Actualizacion") = dtDocumento.Rows(index).Item("Fecha_Actualizacion")
                dr("IdEstado_Registro") = dtDocumento.Rows(index).Item("IdEstado_Registro")
                dr("Fecha") = dtDocumento.Rows(index).Item("Fecha")
                dr("Monto_Tipo_Cambio") = dtDocumento.Rows(index).Item("Monto_Tipo_Cambio")
                dr("Monto_Sub_Total") = dtDocumento.Rows(index).Item("Monto_Sub_Total")
                dr("Monto_Impuesto") = dtDocumento.Rows(index).Item("Monto_Impuesto")
                dr("Total_Costo") = dtDocumento.Rows(index).Item("Total_Costo")
                dr("Obs") = dtDocumento.Rows(index).Item("Obs")
                dr("IdTipo_Moneda") = dtDocumento.Rows(index).Item("IdTipo_Moneda")
                dr("Porcen") = dtDocumento.Rows(index).Item("Porcen")
                dr("Tipo_Monto") = dtDocumento.Rows(index).Item("Tipo_Monto")
                dr("Ind_Procedencia") = dtDocumento.Rows(index).Item("Ind_Procedencia")
                curDocumento.Rows.Add(dr)
            Next
        Else
            dr = curDocumento.NewRow
            dr("Id_Guias_Envio_Doc") = 0
            dr("IdGuias_Envio") = 0
            dr("IdTipo_Comprobante") = 0
            dr("Nro_Serie") = 0
            dr("Nro_Docu") = 0
            dr("IdUsuario_Personal") = 0
            dr("IdUsuario_Personalmod") = 0
            dr("IdRol_Usuario") = 0
            dr("IdRol_Usuariomod") = 0
            dr("Ip") = ""
            dr("IpMod") = ""
            dr("Fecha_Registro") = ""
            dr("Fecha_Actualizacion") = ""
            dr("IdEstado_Registro") = 0
            dr("Fecha") = ""
            dr("Monto_Tipo_Cambio") = 0
            dr("Monto_Sub_Total") = 0
            dr("Monto_Impuesto") = 0
            dr("Total_Costo") = 0
            dr("Obs") = ""
            dr("IdTipo_Moneda") = 0
            dr("Porcen") = 0
            dr("Tipo_Monto") = ""
            dr("Ind_Procedencia") = 0
            curDocumento.Rows.Add(dr)
        End If
    End Function
    Private Function CargarColumnasCliente(dtCliente As DataTable)
        If dtCliente.Rows.Count Then
            dr = curCliente.NewRow
            dr("Gerente_General") = dtCliente.Rows(0).Item("Gerente_General")
            dr("Representante_Legal") = dtCliente.Rows(0).Item("Representante_Legal")
            dr("E_mail") = dtCliente.Rows(0).Item("E_mail")
            dr("Telefono") = dtCliente.Rows(0).Item("Telefono")
            curCliente.Rows.Add(dr)
        Else
            dr = curCliente.NewRow
            dr("Gerente_General") = ""
            dr("Representante_Legal") = ""
            dr("E_mail") = ""
            dr("Telefono") = ""
            curCliente.Rows.Add(dr)
        End If
    End Function
    Private Function CargarColumnasMail(dtMail As DataTable)
        If dtMail.Rows.Count > 0 Then
            dr = curEmail.NewRow
            dr("E_Mail") = dtMail.Rows(0).Item("E_Mail")
            dr("IdPersona") = dtMail.Rows(0).Item("IdPersona")
            curEmail.Rows.Add(dr)
        Else
            dr = curEmail.NewRow
            dr("E_Mail") = ""
            dr("IdPersona") = 0
            curEmail.Rows.Add(dr)
        End If
    End Function
    Private Function CargarColumnasCel(dtCel As DataTable)
        If dtCel.Rows.Count > 0 Then
            dr = curCel.NewRow
            dr("IdTipo_Comunicacion") = dtCel.Rows(0).Item("IdTipo_Comunicacion")
            dr("Nro_Movil") = dtCel.Rows(0).Item("Nro_Movil")
            dr("Tipo_Comunicacion") = dtCel.Rows(0).Item("Tipo_Comunicacion")
            dr("IdPersona") = dtCel.Rows(0).Item("IdPersona")
            curCel.Rows.Add(dr)
        Else
            dr = curCel.NewRow
            dr("IdTipo_Comunicacion") = 0
            dr("Nro_Movil") = ""
            dr("Tipo_Comunicacion") = ""
            dr("IdPersona") = 0
            curCel.Rows.Add(dr)
        End If
    End Function
    Private Function CargarColumnasArticulo(dtArticulo As DataTable)
        If dtArticulo.Rows.Count > 0 Then
            For Each row As DataRow In dtArticulo.Rows
                dr = curArticulo.NewRow
                dr("Nombre_Articulo") = row.Item("Nombre_Articulo")
                dr("Precio_x_Articulo") = row.Item("Precio_x_Articulo")
                dr("Cantidad_Articulos") = row.Item("Cantidad_Articulos")
                dr("Total") = row.Item("Total")
                dr("Peso") = row.Item("Peso")
                curArticulo.Rows.Add(dr)
            Next
        Else
            dr = curArticulo.NewRow
            dr("Nombre_Articulo") = ""
            dr("Precio_x_Articulo") = ""
            dr("Cantidad_Articulos") = ""
            dr("Total") = ""
            dr("Peso") = ""
            curArticulo.Rows.Add(dr)
        End If

        'If dtArticulo.Rows.Count > 0 Then
        '    dr = curArticulo.NewRow
        '    dr("Nombre_Articulo") = dtArticulo.Rows(0).Item("Nombre_Articulo")
        '    dr("Precio_x_Articulo") = dtArticulo.Rows(0).Item("Precio_x_Articulo")
        '    dr("Cantidad_Articulos") = dtArticulo.Rows(0).Item("Cantidad_Articulos")
        '    dr("Total") = dtArticulo.Rows(0).Item("Total")
        '    curArticulo.Rows.Add(dr)
        'Else
        '    dr = curArticulo.NewRow
        '    dr("Nombre_Articulo") = ""
        '    dr("Precio_x_Articulo") = ""
        '    dr("Cantidad_Articulos") = ""
        '    dr("Total") = ""
        '    curArticulo.Rows.Add(dr)
        'End If
    End Function

    Private Function CargarColumnasPrefactura(dtPrefactura As DataTable)
        If dtPrefactura.Rows.Count > 0 Then
            dr = curPrefactura.NewRow
            dr("Nro_Prefactura") = dtPrefactura.Rows(0).Item("Nro_Prefactura")
            dr("Fecha_Registro") = dtPrefactura.Rows(0).Item("Fecha_Registro")
            dr("Estado") = dtPrefactura.Rows(0).Item("Estado")
            dr("Fecha_Factura") = dtPrefactura.Rows(0).Item("Fecha_Factura")
            curPrefactura.Rows.Add(dr)
        Else
            dr = curPrefactura.NewRow
            dr("Nro_Prefactura") = ""
            dr("Fecha_Registro") = ""
            dr("Estado") = ""
            dr("Fecha_Factura") = ""
            curPrefactura.Rows.Add(dr)
        End If
    End Function
    Private Function CargarColumnasFactura(dtFactura As DataTable)
        Dim blnOk As Boolean = False

        If dtFactura.Rows.Count > 0 And dtFactura.Columns.Count > 1 Then
            For index As Integer = 0 To dtFactura.Rows.Count - 1
                dr = curFactura.NewRow
                dr("Nro_Documento") = dtFactura.Rows(index).Item("Nro_Documento")
                dr("Fecha_Factura") = dtFactura.Rows(index).Item("Fecha_Factura")
                dr("Estado_Registro") = dtFactura.Rows(index).Item("Estado_Registro")
                dr("Nombre_Corto") = dtFactura.Rows(index).Item("Nombre_Corto")
                dr("IdPersona") = dtFactura.Rows(index).Item("IdPersona")
                curFactura.Rows.Add(dr)
                blnOk = True
            Next
        End If

        If blnOk = False Then
            dr = curFactura.NewRow
            dr("Nro_Documento") = ""
            dr("Fecha_Factura") = ""
            dr("Estado_Registro") = ""
            dr("Nombre_Corto") = ""
            dr("IdPersona") = 0
            curFactura.Rows.Add(dr)
        End If
    End Function
    Private Function CargarColumnasBultos(dtBultos As DataTable)
        If dtBultos.Rows.Count > 0 Then
            For index As Integer = 0 To dtBultos.Rows.Count - 1
                dr = curBultos.NewRow
                dr("IdTipo_Comprobante") = dtBultos.Rows(index).Item("IdTipo_Comprobante")
                dr("IdComprobante") = dtBultos.Rows(index).Item("IdComprobante")
                dr("GT") = dtBultos.Rows(index).Item("GT")
                dr("Nro_Bus") = dtBultos.Rows(index).Item("Nro_Bus")
                dr("Manual1") = dtBultos.Rows(index).Item("Manual1")
                dr("PDT1") = dtBultos.Rows(index).Item("PDT1")
                dr("Manual2") = dtBultos.Rows(index).Item("Manual2")
                dr("PDT2") = dtBultos.Rows(index).Item("PDT2")
                curBultos.Rows.Add(dr)
            Next
        Else
            dr = curBultos.NewRow
            dr("IdTipo_Comprobante") = 0
            dr("IdComprobante") = 0
            dr("GT") = 0
            dr("Nro_Bus") = 0
            dr("Manual1") = 0
            dr("PDT1") = 0
            dr("Manual2") = 0
            dr("PDT2") = 0
            curBultos.Rows.Add(dr)
        End If
    End Function

    Function Ejecutar1(ByVal iComprobante As Integer, ByVal iCliente As Integer, ByVal iPrefactura As Integer, ByVal iFacturado As Integer, ByVal iTipo As Integer) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            '06-01-20014
            'db.CrearComando("PKG_IVOGENERAL.SP_CONSULTA_VENTAS_1_dh_2", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOGENERAL.SP_CONSULTA_VENTAS_DH_car", CommandType.StoredProcedure)
            db.AsignarParametro("iComprobante", iComprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("iCliente", iCliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("iPrefactura", iPrefactura, OracleClient.OracleType.Int32)
            db.AsignarParametro("iFacturado", iFacturado, OracleClient.OracleType.Int32)
            db.AsignarParametro("iTipo", iTipo, OracleClient.OracleType.Int32)

            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_documento", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_cliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_email", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_movil", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_prefactura", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_factura", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_bultos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet

            If IsNothing(curVenta) Then
                curVenta = New DataTable
                CrearColumnasVentas()
            End If
            CargarColumnasVentas(ds.Tables(0))

            If curVenta.Rows.Count > 0 Then
                If IsNothing(curDocumento) Then
                    curDocumento = New DataTable
                    CrearColumnasDocumentos()
                End If
                CargarColumnasDocumentos(ds.Tables(1))

                If IsNothing(curCliente) Then
                    curCliente = New DataTable
                    CrearColumnasCliente()
                End If
                CargarColumnasCliente(ds.Tables(2))

                If IsNothing(curEmail) Then
                    curEmail = New DataTable
                    CrearColumnasMail()
                End If
                CargarColumnasMail(ds.Tables(3))

                If IsNothing(curCel) Then
                    curCel = New DataTable
                    CrearColumnasCel()
                End If
                CargarColumnasCel(ds.Tables(4))

                If IsNothing(curPrefactura) Then
                    curPrefactura = New DataTable
                    CrearColumnasPrefactura()
                End If
                CargarColumnasPrefactura(ds.Tables(5))

                If IsNothing(curFactura) Then
                    curFactura = New DataTable
                    CrearColumnasFactura()
                End If
                CargarColumnasFactura(ds.Tables(6))

                If IsNothing(curBultos) Then
                    curBultos = New DataTable
                    CrearColumnasBultos()
                End If
                CargarColumnasBultos(ds.Tables(7))
                'curDocumento = ds.Tables(1)
                'curCliente = ds.Tables(2)
                'curEmail = ds.Tables(3)
                'curCel = ds.Tables(4)
                'curPrefactura = ds.Tables(5)
                'curFactura = ds.Tables(6)
                'curBultos = ds.Tables(7)
            End If
            Return True

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function


    Function EjecutarConsultaDocumento(ByVal iComprobante As Integer, ByVal iCliente As Integer, ByVal iPrefactura As Integer, ByVal iFacturado As Integer, ByVal iTipo As Integer) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            '06-01-20014
            'db.CrearComando("PKG_IVOGENERAL.SP_CONSULTA_VENTAS_1_dh_2", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOGENERAL.SP_CONSULTA_DOCUMENTO_1", CommandType.StoredProcedure)
            db.AsignarParametro("iComprobante", iComprobante, OracleClient.OracleType.Int32)
            db.AsignarParametro("iCliente", iCliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("iPrefactura", iPrefactura, OracleClient.OracleType.Int32)
            db.AsignarParametro("iFacturado", iFacturado, OracleClient.OracleType.Int32)
            db.AsignarParametro("iTipo", iTipo, OracleClient.OracleType.Int32)

            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_documento", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_cliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_email", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_movil", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_prefactura", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_factura", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_bultos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_articulo", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet

            If IsNothing(curVenta) Then
                curVenta = New DataTable
                CrearColumnasVentas()
            End If
            CargarColumnasVentas(ds.Tables(0))

            If curVenta.Rows.Count > 0 Then
                If IsNothing(curDocumento) Then
                    curDocumento = New DataTable
                    CrearColumnasDocumentos()
                End If
                CargarColumnasDocumentos(ds.Tables(1))

                If IsNothing(curCliente) Then
                    curCliente = New DataTable
                    CrearColumnasCliente()
                End If
                CargarColumnasCliente(ds.Tables(2))

                If IsNothing(curEmail) Then
                    curEmail = New DataTable
                    CrearColumnasMail()
                End If
                CargarColumnasMail(ds.Tables(3))

                If IsNothing(curCel) Then
                    curCel = New DataTable
                    CrearColumnasCel()
                End If
                CargarColumnasCel(ds.Tables(4))

                If IsNothing(curPrefactura) Then
                    curPrefactura = New DataTable
                    CrearColumnasPrefactura()
                End If
                CargarColumnasPrefactura(ds.Tables(5))

                If IsNothing(curFactura) Then
                    curFactura = New DataTable
                    CrearColumnasFactura()
                End If
                CargarColumnasFactura(ds.Tables(6))

                If IsNothing(curBultos) Then
                    curBultos = New DataTable
                    CrearColumnasBultos()
                End If
                CargarColumnasBultos(ds.Tables(7))

                If IsNothing(curArticulo) Then
                    curArticulo = New DataTable
                    CrearColumnasArticulo()
                End If
                CargarColumnasArticulo(ds.Tables(8))

                'curDocumento = ds.Tables(1)
                'curCliente = ds.Tables(2)
                'curEmail = ds.Tables(3)
                'curCel = ds.Tables(4)
                'curPrefactura = ds.Tables(5)
                'curFactura = ds.Tables(6)
                'curBultos = ds.Tables(7)
            End If
            Return True

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function


End Class
