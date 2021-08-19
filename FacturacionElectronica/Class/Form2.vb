Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class Form2
    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        'Dim ventafe As New Ventafe
        'ventafe.numero = "FA01-00000320"
        'ventafe.origen = "LIMA"
        'ventafe.destino = "CAJAMARCA"
        'ventafe.remitenete = "WALTER ABANTO ABANTO"
        'ventafe.consignado = "JOSE ABANTO ABANTO"
        'ventafe.tipoEntrega = "DOMICILIO"
        'ventafe.direccion = "AV. SEPARADORA INDUSTRIAL 1524 - ATE"
        'ventafe.opExonerada = 0
        'ventafe.opInafecta = 0
        'ventafe.opGravada = 637.29
        'ventafe.igv = 114.71
        'ventafe.importeTotal = 752
        'ventafe.formaPago = "EFECTIVO"
        'ventafe.fechaEmision = Now
        'ventafe.agenciaEmision = "LIMA JAVIAER PRADO TERM"
        'ventafe.usuarioEmision = "MARIELA SALGADO SUAREZ"
        'ventafe.isFactura = True
        'ventafe.montoLetras = "SON SETECIENTOS CINCUENTA Y DOS 00/100 SOLES"
        'ventafe.ruc = "20502324927"
        'ventafe.razonSocial = "TRANSPORTES EL PINO SAC"
        'ventafe.direccionFiscal = "AV. MANUEL ECHEANDIA 303 - SAN LUIS"

        'Dim listDetallefe As New List(Of DetalleVentafe)
        'Dim detallefe As New DetalleVentafe
        'detallefe.descripcion = "TARIFA BASE"
        'detallefe.peso = 0
        'detallefe.tarifa = 8
        'detallefe.subTotal = 8
        'listDetallefe.Add(detallefe)
        'detallefe = New DetalleVentafe
        'detallefe.descripcion = "SERVICIO DE TRASLADO DE BULTOS (T=TIPO 1)"
        'detallefe.peso = 280
        'detallefe.tarifa = 1.3
        'detallefe.subTotal = 364
        'listDetallefe.Add(detallefe)
        'detallefe = New DetalleVentafe
        'detallefe.descripcion = "ENTREGA A DOMICILIO"
        'detallefe.peso = 0
        'detallefe.tarifa = 60
        'detallefe.subTotal = 60
        'listDetallefe.Add(detallefe)
        'detallefe = New DetalleVentafe
        'detallefe.descripcion = "FUERA DE ZONA"
        'detallefe.peso = 0
        'detallefe.tarifa = 80
        'detallefe.subTotal = 80
        'listDetallefe.Add(detallefe)
        'detallefe = New DetalleVentafe
        'detallefe.descripcion = "DEVOLUCION DE CARGOS"
        'detallefe.peso = 0
        'detallefe.tarifa = 10
        'detallefe.subTotal = 10
        'listDetallefe.Add(detallefe)
        'detallefe = New DetalleVentafe
        'detallefe.descripcion = "CARGA ASEGURADA"
        'detallefe.peso = 0
        'detallefe.tarifa = 120
        'detallefe.subTotal = 120
        'listDetallefe.Add(detallefe)

        'ventafe.detalleVenta = listDetallefe

        'Dim result = VentafeManager.sendVentaSunat()
        'If (result.IsCorrect) Then
        '    ventafe.codigoBarras = result.barcode
        '    VentafeManager.Print(ventafe)
        'End If




        'Dim pathFileRpt As String = Application.StartupPath() & "\FacturacionElectronica\Boleta.rpt"
        'Dim cryRpt As New ReportDocument
        'cryRpt.Load(pathFileRpt, OpenReportMethod.OpenReportByTempCopy)

        'Dim margins As PageMargins
        'margins = cryRpt.PrintOptions.PageMargins
        'margins.topMargin = 0

        'cryRpt.PrintOptions.PrinterName = "EPSON TM-T20II Receipt"
        'cryRpt.PrintOptions.PaperSize = PaperSize.DefaultPaperSize
        'cryRpt.PrintOptions.ApplyPageMargins(margins)
        'cryRpt.PrintToPrinter(1, False, 0, 0)

        'cryRpt.Close()



    End Sub
End Class