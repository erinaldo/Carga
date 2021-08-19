Imports System.Drawing.Printing
Public Class ImprimirTexto
    Structure Datos
        Public x As Integer
        Public y As Integer
        Public texto As String
    End Structure
    Private eLista As Datos
    Private alista As New ArrayList

    Private WithEvents objDocumento As New PrintDocument

    Private strFuente As String

    Public Property Fuente() As String
        Get
            Return strFuente
        End Get
        Set(ByVal value As String)
            strFuente = value
        End Set
    End Property
    Private intTamaño As Integer
    Public Property Tamaño() As Integer
        Get
            Return intTamaño
        End Get
        Set(ByVal value As Integer)
            intTamaño = value
        End Set
    End Property

    Private strImpresora As String
    Public Property Impresora() As String
        Get
            Return strImpresora
        End Get
        Set(ByVal value As String)
            strImpresora = value
        End Set
    End Property
    Private strPapel As String
    Public Property Papel() As String
        Get
            Return strPapel
        End Get
        Set(ByVal value As String)
            strPapel = value
        End Set
    End Property
    Private dAncho As Double
    Public Property Ancho() As Double
        Get
            Return dAncho
        End Get
        Set(ByVal value As Double)
            dAncho = value
        End Set
    End Property

    Private dAlto As Double
    Public Property Alto() As Double
        Get
            Return dAlto
        End Get
        Set(ByVal value As Double)
            dAlto = value
        End Set
    End Property

    Public Sub Imprimir()
        Dim iPapel As Integer
        Dim li_fila As Integer
        Try
            objDocumento.PrinterSettings.PrinterName = Impresora
            iPapel = BuscarPapel()
            If iPapel > -1 Then
                objDocumento.DefaultPageSettings.PaperSize = objDocumento.PrinterSettings.PaperSizes(iPapel)
            End If
            '
            objDocumento.PrintController = New System.Drawing.Printing.StandardPrintController
            objDocumento.Print()
            '
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub objDocumento_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles objDocumento.PrintPage

        Try
            Dim objFuente As New System.Drawing.Font(Fuente, Tamaño)
            Dim objGrafico As System.Drawing.Graphics = e.Graphics

            If strPapel.Length > 0 Then

            End If

            Dim obj As Datos
            For Each obj In alista
                objGrafico.DrawString(obj.texto, objFuente, Brushes.Black, obj.x, obj.y)
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Agregar(ByVal x As Integer, ByVal y As Integer, ByVal texto As String)
        eLista.x = X
        eLista.y = Y
        eLista.texto = Texto

        Asigna(eLista)

    End Sub
    Private Sub Asigna(ByVal value As Datos)
        alista.Add(value)
    End Sub

    Public Sub New()
    End Sub

    Public Sub New(ByVal fuente As String, ByVal tamaño As Integer, ByVal impresora As String, ByVal papel As String, ByVal ancho As Double, ByVal alto As Double)
        Me.Fuente = fuente
        Me.Tamaño = tamaño
        Me.Impresora = impresora
        Me.Papel = papel
        Me.Ancho = Ancho
        Me.Alto = Alto
    End Sub

    Private Function BuscarPapel() As Integer
        Dim i As Integer = 0
        For Each ps As PaperSize In objDocumento.PrinterSettings.PaperSizes
            If ps.PaperName.ToUpper = strPapel.ToUpper Then
                Return i
                Exit Function
            End If
            i += 1
        Next
        Return -1
    End Function
End Class
