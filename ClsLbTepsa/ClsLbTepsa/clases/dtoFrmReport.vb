Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows
Imports System.Windows.Forms
Imports CrystalDecisions.Shared

Public Class dtoFrmReport
    Implements IDisposable
    Dim MySubReporte As String = ""
    'CLASE PARA CARGAR UN REPORTE BASADO EN SQL SERVER
    Private Shared loginfo As CrystalDecisions.Shared.ConnectionInfo
    Public Shared exportar_mail As Boolean
    Public Shared rutaRpt As String
    Public Shared stillOpen As Boolean
    Public Shared custTitle As String
    Public Shared rpt As New ReportDocument

    Public Sub New()
        Try

        Catch ex As Exception
            MessageBox.Show(ex.InnerException.InnerException.Message)
        End Try
    End Sub

    Public Shared Sub conectar(ByVal servidor As String, ByVal usuario As String, ByVal password As String)
        loginfo = New CrystalDecisions.Shared.ConnectionInfo
        loginfo.ServerName = servidor
        'loginfo.DatabaseName = servidor
        loginfo.IntegratedSecurity = False
        loginfo.UserID = usuario
        loginfo.Password = password
    End Sub
    'Private Shared Function genparlpt(ByRef MyReportDocument As ReportDocument, ByVal ParamArray matriz() As String)
    Private Shared Sub genparlpt(ByRef MyReportDocument As ReportDocument, ByVal ParamArray matriz() As String)


        Dim c As Long, p1, p2 As String, l As Integer
        Dim parametros As New ParameterFields
        For c = 0 To matriz.Length - 1
            l = InStr(matriz(c), ";")
            If l > 0 Then
                p1 = Mid(matriz(c), 1, l - 1)
                p2 = Mid(matriz(c), l + 1, Len(matriz(c)) - l)
                '
                Dim bolPar As New CrystalDecisions.Shared.ParameterValues
                Dim bolpard As New CrystalDecisions.Shared.ParameterDiscreteValue
                '
                bolPar = MyReportDocument.DataDefinition.ParameterFields.Item(p1).CurrentValues
                bolpard.Value = p2
                bolPar.Add(bolpard)
                MyReportDocument.DataDefinition.ParameterFields.Item(p1).ApplyCurrentValues(bolPar)
                '
            End If
        Next

    End Sub
    Public Property SubReporte() As String
        Get
            SubReporte = MySubReporte
        End Get
        Set(ByVal value As String)
            MySubReporte = value
        End Set
    End Property
    Private Shared Function genpar_sub_report(ByVal ReportName As String, ByVal ParamArray matriz() As String) As ParameterFields
        Dim c As Long, p1, p2 As String, l As Integer
        Dim parametros As New ParameterFields

        Dim parametro As New ParameterField
        Dim dVal As New ParameterDiscreteValue

        For c = 0 To matriz.Length - 1
            l = InStr(matriz(c), ";")
            If l > 0 Then
                p1 = Mid(matriz(c), 1, l - 1)
                p2 = Mid(matriz(c), l + 1, Len(matriz(c)) - l)

                parametro = New ParameterField
                dVal = New ParameterDiscreteValue

                parametro.ParameterFieldName = p1
                dVal.Value = p2
                parametro.CurrentValues.Add(dVal)
                parametros.Add(parametro)
            End If
        Next
        For c = 0 To matriz.Length - 1
            l = InStr(matriz(c), ";")
            If l > 0 Then
                p1 = Mid(matriz(c), 1, l - 1)
                p2 = Mid(matriz(c), l + 1, Len(matriz(c)) - l)

                parametro = New ParameterField
                dVal = New ParameterDiscreteValue

                parametro.ParameterFieldName = p1
                dVal.Value = p2
                parametro.ReportName = ReportName
                parametro.CurrentValues.Add(dVal)
                parametros.Add(parametro)
            End If
        Next

        Return (parametros)

    End Function
    Private Shared Function genpar(ByVal ParamArray matriz() As String) As ParameterFields
        Dim c As Long, p1, p2 As String, l As Integer
        Dim parametros As New ParameterFields
        For c = 0 To matriz.Length - 1
            l = InStr(matriz(c), ";")
            If l > 0 Then
                p1 = Mid(matriz(c), 1, l - 1)
                p2 = Mid(matriz(c), l + 1, Len(matriz(c)) - l)
                Dim parametro As New ParameterField
                Dim dVal As New ParameterDiscreteValue
                parametro.ParameterFieldName = p1
                dVal.Value = p2
                parametro.CurrentValues.Add(dVal)
                parametros.Add(parametro)
            End If
        Next

        Return (parametros)

    End Function
    'Private Shared Function logonrpt(ByRef reporte As ReportDocument)
    Private Shared Sub logonrpt(ByRef reporte As ReportDocument)
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        crConnectionInfo = loginfo
        CrTables = reporte.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next

    End Sub

    Public Overloads Shared Sub printrptlpt(ByVal PrintReport As Boolean, ByVal Crit As String, ByVal nombrereporte As String, ByVal ParamArray par() As String)
        'Dim rpt As New ReportDocument
        If rutaRpt.Trim.Length = 0 Then
            rpt.Load(nombrereporte, OpenReportMethod.OpenReportByDefault)
        ElseIf Mid(rutaRpt.Trim, rutaRpt.Trim.Length, 1) = "\" Then
            rpt.Load(rutaRpt & nombrereporte, OpenReportMethod.OpenReportByDefault)
        Else
            rpt.Load(rutaRpt & "\" & nombrereporte, OpenReportMethod.OpenReportByDefault)
        End If

        If par.Length > 0 Then
            genparlpt(rpt, par)
        End If

        'logonrpt(rpt) modificado por ritcher
        'Configurar aquí cualquier opción de exportación 
        Dim opt As New ExportOptions
        opt = rpt.ExportOptions
        'Configurar aquí cualquier opción de impresión 
        Dim prn As PrintOptions
        prn = rpt.PrintOptions
        rpt.PrintOptions.PaperSize = PaperSize.PaperCsheet

        rpt.PrintToPrinter(1, False, 1, 1)



    End Sub


    Public Overloads Shared Sub printrpt(ByVal PrintReport As Boolean, ByVal Crit As String, ByVal nombrereporte As String, ByVal ParamArray par() As String)
        Dim forma As New FrmReport
        'Dim rpt As New ReportDocument
        With forma.CRV
            If par.Length > 0 Then
                .ParameterFieldInfo = genpar(par)
            End If
            If rutaRpt.Trim.Length = 0 Then
                rpt.Load(nombrereporte, OpenReportMethod.OpenReportByDefault)
            ElseIf Mid(rutaRpt.Trim, rutaRpt.Trim.Length, 1) = "\" Then
                rpt.Load(rutaRpt & nombrereporte, OpenReportMethod.OpenReportByDefault)
            Else
                rpt.Load(rutaRpt & "\" & nombrereporte, OpenReportMethod.OpenReportByDefault)
            End If
            logonrpt(rpt)
            'Configurar aquí cualquier opción de exportación 
            Dim opt As New ExportOptions
            opt = rpt.ExportOptions
            'Configurar aquí cualquier opción de impresión 
            Dim prn As PrintOptions
            prn = rpt.PrintOptions
            .ReportSource = rpt
            .ShowPrintButton = True
            If Not Crit.Trim.Length = 0 Then .SelectionFormula = Crit
            'Visualizar el reporte en una ventana nueva 
            forma.Text = custTitle
            If PrintReport = True Then
                .PrintReport()
            Else
                forma.Show()
            End If



        End With

    End Sub

    Public Overloads Shared Sub printrpt(ByVal PrintReport As Boolean, ByVal Crit As String, ByVal nombrereporte As String)
        Dim forma As New FrmReport
        'Dim rpt As New ReportDocument
        With forma.CRV
            If rutaRpt.Trim.Length = 0 Then
                rpt.Load(nombrereporte, OpenReportMethod.OpenReportByDefault)
            ElseIf Mid(rutaRpt.Trim, rutaRpt.Trim.Length, 1) = "\" Then
                rpt.Load(rutaRpt & nombrereporte, OpenReportMethod.OpenReportByDefault)
            Else
                rpt.Load(rutaRpt & "\" & nombrereporte, OpenReportMethod.OpenReportByDefault)
            End If

            logonrpt(rpt)


            'Configurar aquí cualquier opción de exportación 
            Dim opt As New ExportOptions
            opt = rpt.ExportOptions
            'Configurar aquí cualquier opción de impresión
            Dim prn As PrintOptions

            prn = rpt.PrintOptions
            .ReportSource = rpt
            .ShowPrintButton = True
            If Not Crit.Trim.Length = 0 Then .SelectionFormula = Crit
            forma.Text = custTitle
            If PrintReport = True Then
                .PrintReport()
            Else
                forma.Show()
            End If



        End With
    End Sub

#Region "Impresion de Reporte desconectado del servidor"

    Public Overloads Shared Sub CrearXML(ByVal dsReporteResumido As DataSet, ByVal strNombreXML As String)
        Try
            If rutaRpt.Trim.Length <> 0 Then
                If System.IO.File.Exists(rutaRpt & strNombreXML) = False Then
                    If Mid(rutaRpt.Trim, rutaRpt.Trim.Length, 1) = "\" Then
                        dsReporteResumido.WriteXmlSchema(rutaRpt & strNombreXML)
                    End If
                End If

            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region



    Public Overloads Shared Sub printrptB(ByVal PrintReport As Boolean, ByVal Crit As String, ByVal nombrereporte As String, ByVal ParamArray par() As String)
        Dim forma As New FrmReport
        'Dim rpt As New ReportDocument
        With forma.CRV
            If par.Length > 0 Then
                .ParameterFieldInfo = genpar(par)
            End If
            If rutaRpt.Trim.Length = 0 Then
                rpt.Load(nombrereporte, OpenReportMethod.OpenReportByDefault)
            ElseIf Mid(rutaRpt.Trim, rutaRpt.Trim.Length, 1) = "\" Then
                rpt.Load(rutaRpt & nombrereporte, OpenReportMethod.OpenReportByDefault)
            Else
                rpt.Load(rutaRpt & "\" & nombrereporte, OpenReportMethod.OpenReportByDefault)
            End If

            logonrpt(rpt)

            'Configurar aquí cualquier opción de exportación 
            Dim opt As New ExportOptions
            opt = rpt.ExportOptions

            'Configurar aquí cualquier opción de impresión 
            Dim prn As PrintOptions
            prn = rpt.PrintOptions

            .ReportSource = rpt
            If Not Crit.Trim.Length = 0 Then .SelectionFormula = Crit
            'Visualizar el reporte en una ventana nueva 
            forma.Text = custTitle
            If PrintReport = True Then
                .PrintReport()
            Else
                forma.Show()
            End If
        End With
    End Sub

    Public Overloads Shared Sub printrptB(ByVal PrintReport As Boolean, ByVal Crit As String, ByVal nombrereporte As String)
        Dim forma As New FrmReport
        'Dim rpt As New ReportDocument
        With forma.CRV
            If rutaRpt.Trim.Length = 0 Then
                rpt.Load(nombrereporte, OpenReportMethod.OpenReportByDefault)
            ElseIf Mid(rutaRpt.Trim, rutaRpt.Trim.Length, 1) = "\" Then
                rpt.Load(rutaRpt & nombrereporte, OpenReportMethod.OpenReportByDefault)
            Else
                rpt.Load(rutaRpt & "\" & nombrereporte, OpenReportMethod.OpenReportByDefault)
            End If
            logonrpt(rpt)
            'Configurar aquí cualquier opción de exportación 
            Dim opt As New ExportOptions
            opt = rpt.ExportOptions
            'Configurar aquí cualquier opción de impresión
            Dim prn As PrintOptions
            prn = rpt.PrintOptions
            .ReportSource = rpt
            If Not Crit.Trim.Length = 0 Then .SelectionFormula = Crit
            forma.Text = custTitle
            If PrintReport = True Then
                .PrintReport()
            Else
                forma.Show()
            End If



        End With
    End Sub

    Public Overloads Shared Sub printrptXML(ByVal PrintReport As Boolean, ByVal Crit As String, ByVal nombrereporte As String, ByVal ds As DataSet)
        Dim forma As New FrmReport
        'Dim rpt As New ReportDocument
        With forma.CRV

            If rutaRpt.Trim.Length = 0 Then
                rpt.Load(nombrereporte, OpenReportMethod.OpenReportByDefault)
            ElseIf Mid(rutaRpt.Trim, rutaRpt.Trim.Length, 1) = "\" Then
                rpt.Load(rutaRpt & nombrereporte, OpenReportMethod.OpenReportByDefault)
            Else
                rpt.Load(rutaRpt & "\" & nombrereporte, OpenReportMethod.OpenReportByDefault)
            End If
            rpt.SetDataSource(ds)

            'Configurar aquí cualquier opción de exportación 
            Dim opt As New ExportOptions
            opt = rpt.ExportOptions
            'Configurar aquí cualquier opción de impresión 
            Dim prn As PrintOptions
            prn = rpt.PrintOptions
            .ReportSource = rpt
            .ShowPrintButton = True
            If Not Crit.Trim.Length = 0 Then .SelectionFormula = Crit
            'Visualizar el reporte en una ventana nueva 
            forma.Text = custTitle
            If PrintReport = True Then
                .PrintReport()
            Else
                forma.Show()
            End If
        End With
    End Sub


    Public Overloads Shared Sub printrpt_sub_report(ByVal ReportName As String, ByVal PrintReport As Boolean, ByVal Crit As String, ByVal nombrereporte As String, ByVal ParamArray par() As String)
        Try
            Dim forma As New FrmReport
            With forma.CRV
                If par.Length > 0 Then
                    .ParameterFieldInfo = genpar_sub_report(ReportName, par)
                End If
                If rutaRpt.Trim.Length = 0 Then
                    rpt.Load(nombrereporte, OpenReportMethod.OpenReportByDefault)
                ElseIf Mid(rutaRpt.Trim, rutaRpt.Trim.Length, 1) = "\" Then
                    rpt.Load(rutaRpt & nombrereporte, OpenReportMethod.OpenReportByDefault)
                Else
                    rpt.Load(rutaRpt & "\" & nombrereporte, OpenReportMethod.OpenReportByDefault)
                End If
                logonrpt(rpt)
                'Configurar aquí cualquier opción de exportación 
                Dim opt As New ExportOptions
                opt = rpt.ExportOptions
                'Configurar aquí cualquier opción de impresión 
                Dim prn As PrintOptions
                prn = rpt.PrintOptions
                .ReportSource = rpt
                .ShowPrintButton = True
                If Not Crit.Trim.Length = 0 Then .SelectionFormula = Crit
                'Visualizar el reporte en una ventana nueva 
                forma.Text = custTitle
                If PrintReport = True Then
                    .PrintReport()
                Else
                    forma.Show()
                End If
            End With
        Catch e As Exception
            MsgBox(e.ToString)
        End Try
    End Sub

    Public Overloads Shared Sub printrpt_sub_report(ByVal PrintReport As Boolean, ByVal Crit As String, ByVal nombrereporte As String)
        Dim forma As New FrmReport
        'Dim rpt As New ReportDocument
        With forma.CRV
            If rutaRpt.Trim.Length = 0 Then
                rpt.Load(nombrereporte, OpenReportMethod.OpenReportByDefault)
            ElseIf Mid(rutaRpt.Trim, rutaRpt.Trim.Length, 1) = "\" Then
                rpt.Load(rutaRpt & nombrereporte, OpenReportMethod.OpenReportByDefault)
            Else
                rpt.Load(rutaRpt & "\" & nombrereporte, OpenReportMethod.OpenReportByDefault)
            End If
            logonrpt(rpt)
            'Configurar aquí cualquier opción de exportación 
            Dim opt As New ExportOptions
            opt = rpt.ExportOptions
            'Configurar aquí cualquier opción de impresión
            Dim prn As PrintOptions

            prn = rpt.PrintOptions
            .ReportSource = rpt
            .ShowPrintButton = True
            If Not Crit.Trim.Length = 0 Then .SelectionFormula = Crit
            forma.Text = custTitle
            If PrintReport = True Then
                .PrintReport()
            Else
                forma.Show()
            End If



        End With
    End Sub


    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                'Me.Dispose()
                rpt.Close()
            End If

            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
        loginfo = Nothing
    End Sub




#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    Private Shared Sub foreach(p1 As Object)
        Throw New NotImplementedException
    End Sub

End Class

