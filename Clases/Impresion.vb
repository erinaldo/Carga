Imports System.Drawing.Printing
Imports System.Drawing
Imports System.Collections
Imports System.Windows.Forms
Public Class Impresion
    Public Enum Separadores
        Ninguno = 0
        Derecha = 1
        Izquierda
        Ambos
    End Enum
    Private Const BUF_SALLINEA = "SAL", _
                  BUF_IMPRIMIR = "IMP", _
                  BUF_IMPRIMIRTAB = "IMT", _
                  BUF_MARCO = "MAR", _
                  BUF_RELLENO = "REL"
    Private Structure SColumna
        Public Tamaño As Single
        Public Alineacion As ContentAlignment
        Public Marco As Boolean
        Public Relleno As Brush
        Public Separador As Separadores
        Public FuenteNombre As String
        Public FuenteTamaño As Integer
        Public FuenteEstilo As FontStyle
    End Structure


    Private Pagina As Integer

    Private WithEvents DocImprimir As New PrintDocument
    Private VP As New PrintPreviewDialog
    Private ge As System.Drawing.Printing.PrintPageEventArgs

    Private mX As Single
    Private mY As Single
    Private mMasDatos As Boolean
    Private mMarco As Boolean
    Private MRelleno As Boolean
    Private mFuente As Font

    Private mFuenteNombre As String
    Private mFuenteTamaño As Integer
    Private mFuenteEstilo As FontStyle
    Private mFuenteEspacio As Single


    Private mTabla As New ArrayList
    Private Buf As New ArrayList



    Dim MargenIzquierdo As Single
    Dim MargenSuperior As Single
    Dim MargenDerecho As Single

    Dim sz As SizeF
    Dim Iniciando As Boolean, DeltaTab As Integer

    Event InicioImpresion()
    Event FinImpresion()
    Event Titulos()
    Event Cuerpo()

    Public Property X() As Single
        Get
            X = mX
        End Get
        Set(ByVal Value As Single)
            mX = Value
        End Set
    End Property

    Public Property Y() As Single
        Get
            Y = mY
        End Get
        Set(ByVal Value As Single)
            mY = Value
        End Set
    End Property

    Public Property MasDatos() As Boolean
        Get
            MasDatos = mMasDatos
        End Get
        Set(ByVal Value As Boolean)
            mMasDatos = Value
        End Set
    End Property

    WriteOnly Property Marco() As Boolean
        Set(ByVal Value As Boolean)
            mMarco = Value
        End Set
    End Property

    WriteOnly Property Relleno() As Boolean
        Set(ByVal Value As Boolean)
            MRelleno = Value
        End Set
    End Property


    Private Sub DocImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocImprimir.PrintPage

        ge = e
        If Iniciando Then
            MargenDerecho = e.MarginBounds.Right
            MargenIzquierdo = e.MarginBounds.Left
            MargenSuperior = e.MarginBounds.Top
            mFuenteNombre = "Arial"
            mFuenteTamaño = 12
            mFuenteEstilo = FontStyle.Regular
            EstablecerFuente()
            DeltaTab = 0
            Iniciando = False
        End If

        mY = MargenSuperior
        mX = MargenIzquierdo

        RaiseEvent Titulos()
        If Buf.Count > 0 Then ProcesarBuffer()

        RaiseEvent Cuerpo()
        e.HasMorePages = mMasDatos Or Buf.Count > 0
    End Sub
    ' Inicia la Generación del Reporte con los parámetros que se hallan definido
    Public Sub GenerarReporte(Optional ByVal LandScape As Boolean = False, Optional ByVal Tipo As String = "Carta")
        Dim pd As New PrintDialog
        Dim ps As PaperSize, psActivo As PaperSize
        For Each ps In DocImprimir.PrinterSettings.PaperSizes
            If Tipo.ToLower = ps.PaperName.ToString.ToLower Then
                psActivo = ps
                Exit For
            End If
        Next
        DocImprimir.DefaultPageSettings.Landscape = LandScape
        If Not psActivo Is Nothing Then DocImprimir.DefaultPageSettings.PaperSize = psActivo
        pd.Document = DocImprimir
        pd.ShowNetwork = True
        pd.ShowDialog()

        '        VP.MdiParent = fPrncpal
        VP.Document = DocImprimir
        VP.ShowDialog()
    End Sub

    Private Sub ProcesarBuffer()
        Dim Comm As String, Cont As Integer, a As Integer, Obj As Object
        For Each Obj In Buf
            If InList(Obj.GetType.Name, "String", "Boolean") Then
                Comm = CType(Obj, String)
                Select Case Comm.Substring(0, 3)
                    Case BUF_SALLINEA
                        SalLinea()
                    Case BUF_IMPRIMIR
                        If Not Imprimir(Comm.Substring(3, Comm.Length - 5), True) Then
                            For a = 1 To Cont
                                Buf.RemoveAt(0)
                            Next
                            Exit Sub
                        End If
                    Case BUF_IMPRIMIRTAB
                        If Not ImprimirTab(Comm.Substring(3, Comm.Length - 5), True) Then Exit For
                        DeltaTab = DeltaTab + 1
                    Case BUF_MARCO
                        mMarco = Comm.Substring(3, 1)
                    Case BUF_RELLENO
                        MRelleno = Comm.Substring(3, 1)
                End Select
            End If
            If Obj.GetType.Name = "Font" Then
                Dim f As Font
                f = CType(Obj, Font)
                mFuenteNombre = f.Name
                mFuenteTamaño = f.Size
                mFuenteEstilo = f.Style
                EstablecerFuente()
            End If
            Cont = Cont + 1
        Next
        DeltaTab = 0
        For a = 1 To Cont
            Buf.RemoveAt(0)
        Next
    End Sub
    Public Function Imprimir(ByVal ParamArray Texto() As Object) As Boolean
        Dim s As Object, Contc As Integer, NoSaltar As Boolean
        Contc = UBound(Texto)
        NoSaltar = False
        If mY >= ge.MarginBounds.Bottom Then
            Buf.Add(mFuente)
            Buf.Add(BUF_MARCO & IIf(mMarco, "1", "0"))
            Buf.Add(BUF_RELLENO & IIf(MRelleno, "1", "0"))
            For Each s In Texto
                Contc = Contc - 1
                If Contc < 0 And VarType(s) = vbBoolean Then
                    NoSaltar = s
                End If
                Buf.Add(BUF_IMPRIMIR & s & ControlChars.CrLf)
            Next s
            If Not NoSaltar Then Buf.Add(BUF_SALLINEA & ControlChars.CrLf)
            Imprimir = False
            Exit Function
        End If
        For Each s In Texto
            Contc = Contc - 1
            If Contc < 0 And VarType(s) = VariantType.Boolean Then
                NoSaltar = s
            Else
                sz = ge.Graphics.MeasureString(s, mFuente)
                If MRelleno Then ge.Graphics.FillRectangle(Brushes.LightGray, mX, mY, sz.Width, mFuente.Height)
                ge.Graphics.DrawString(s, mFuente, Brushes.Black, mX, mY)
                If mMarco Then ge.Graphics.DrawRectangle(New Pen(Color.Black, 1), mX, mY, sz.Width, mFuente.Height)
                mX = mX + ge.Graphics.MeasureString(s, mFuente).Width
            End If
        Next
        If Not NoSaltar Then
            mY = mY + mFuente.Height ' mFuente.GetHeight(ge.Graphics)
            mX = MargenIzquierdo
        End If
        Imprimir = mY < ge.MarginBounds.Bottom
    End Function
    Public Function ImprimirTab(ByVal ParamArray Texto() As Object) As Boolean
        Dim s As Object
        Dim sz As SizeF
        Dim Col As SColumna, Lapiz As Pen
        Dim cont As Integer, ancho As Single, Alineacion As ContentAlignment, Marco As Boolean, Relleno As Brush, Separador As Separadores
        'Dim alto As Single
        Dim NoSaltar As Boolean, Contc As Integer
        Dim mXO As Single, lFuente As Font, MaxHeight As Integer, Altura As Single
        '        cont = mTabla.Count
        Lapiz = New Pen(Color.Black, 0.5)
        cont = DeltaTab
        Contc = UBound(Texto)
        NoSaltar = False
        If mY >= ge.MarginBounds.Bottom Then
            Buf.Add(mFuente)
            Buf.Add(BUF_MARCO & IIf(mMarco, "1", "0"))
            Buf.Add(BUF_RELLENO & IIf(MRelleno, "1", "0"))
            For Each s In Texto
                Contc = Contc - 1
                If Contc < 0 And VarType(s) = vbBoolean Then
                    NoSaltar = s
                End If
                Buf.Add(BUF_IMPRIMIRTAB & s & ControlChars.CrLf)
            Next s
            If Not NoSaltar Then Buf.Add(BUF_SALLINEA & ControlChars.CrLf)
            ImprimirTab = False
            Exit Function
        End If
        MaxHeight = 0
        For Each s In Texto
            Contc = Contc - 1
            If Contc < 0 And VarType(s) = VariantType.Boolean Then
                NoSaltar = s
            Else
                If cont < mTabla.Count Then
                    Col = mTabla.Item(cont)
                    ancho = Col.Tamaño
                    Alineacion = Col.Alineacion
                    Marco = Col.Marco
                    Relleno = Col.Relleno
                    Separador = Col.Separador
                    lFuente = New Font(Col.FuenteNombre, Col.FuenteTamaño, Col.FuenteEstilo)
                Else
                    ancho = sz.Width
                    Alineacion = ContentAlignment.MiddleLeft
                    Marco = False
                    Relleno = Brushes.White
                    Separador = 0
                    lFuente = mFuente
                End If
                sz = ge.Graphics.MeasureString(s, lFuente)
                mXO = mX
                Altura = lFuente.Height
                Select Case Alineacion
                    Case ContentAlignment.MiddleRight, ContentAlignment.BottomRight, ContentAlignment.TopRight
                        mX += ancho - sz.Width
                    Case ContentAlignment.MiddleCenter, ContentAlignment.BottomCenter, ContentAlignment.TopCenter
                        mX += (ancho - sz.Width) / 2
                    Case Else
                        mX += 1
                End Select
                If Not Relleno Is Brushes.White Then ge.Graphics.FillRectangle(Relleno, mXO, mY, ancho, Altura)
                ge.Graphics.DrawString(s, lFuente, Brushes.Black, mX, mY)
                If Marco Then
                    ge.Graphics.DrawRectangle(Lapiz, mXO, mY, ancho, Altura)
                Else
                    Select Case Separador
                        Case Separadores.Derecha
                            ge.Graphics.DrawLine(Lapiz, mXO + ancho - 0, mY, mXO + ancho - 0, mY + Altura)
                        Case Separadores.Izquierda
                            ge.Graphics.DrawLine(Lapiz, mXO, mY, mXO, mY + Altura)
                        Case Separadores.Ambos
                            ge.Graphics.DrawLine(Lapiz, mXO, mY, mXO, mY + Altura)
                            ge.Graphics.DrawLine(Lapiz, mXO + ancho - 0, mY, mXO + ancho - 0, mY + Altura)
                    End Select
                End If
                If cont < mTabla.Count Then mX = mXO + ancho
                cont += 1
                If MaxHeight < Altura Then MaxHeight = Altura
            End If
        Next
        Lapiz.Dispose()
        If Not NoSaltar Then
            mY = mY + MaxHeight
            mX = MargenIzquierdo
            DeltaTab = 0
        Else
            DeltaTab = cont
        End If
        ImprimirTab = mY < ge.MarginBounds.Bottom
    End Function
    ' Dibuja una linea que cubre el ancho de la página
    Public Overloads Sub LineaL(ByVal Alto As Integer)
        Dim p As Pen
        p = New Pen(Color.Black, Alto)
        ge.Graphics.DrawLine(p, MargenIzquierdo, mY, MargenDerecho, mY)
        mY = mY + Alto
    End Sub
    ' Dibuja una línea con un ancho determinado
    Public Overloads Sub LineaL(ByVal Alto As Integer, ByVal Ancho As Integer)
        Dim p As Pen
        p = New Pen(Color.Black, Alto)
        ge.Graphics.DrawLine(p, MargenIzquierdo, mY, MargenIzquierdo + Ancho, mY)
        mY = mY + Alto
    End Sub
    ' Dibuja una línea con un ancho determinado, desde un punto inicial
    Public Overloads Sub LineaL(ByVal Alto As Integer, ByVal Ancho As Integer, ByVal Origen As Integer)
        Dim p As Pen
        p = New Pen(Color.Black, Alto)
        ge.Graphics.DrawLine(p, Origen, mY, Origen + Ancho, mY)
        mY = mY + Alto
    End Sub

    Public Sub SalLinea(Optional ByVal Lineas As Integer = 1)
        Dim a As Integer
        For a = 1 To Lineas
            Imprimir()
        Next
        DeltaTab = 0
    End Sub

#Region "Fuentes"
    ' Define la Fuente Actual de Trabajo
    Public Overloads Sub Fuente(ByVal Nombre As String, ByVal Tamaño As Integer, ByVal Estilo As FontStyle)
        mFuenteNombre = Nombre
        mFuenteTamaño = Tamaño
        mFuenteEstilo = Estilo
        EstablecerFuente()
    End Sub

    Public Overloads Sub Fuente(ByVal Nombre As String, ByVal Tamaño As Integer)
        mFuenteNombre = Nombre
        mFuenteTamaño = Tamaño
        EstablecerFuente()
    End Sub

    Public Overloads Sub Fuente(ByVal Nombre As String)
        mFuenteNombre = Nombre
        EstablecerFuente()
    End Sub

    Public Overloads Sub Fuente(ByVal Tamaño As Integer)
        mFuenteTamaño = Tamaño
        EstablecerFuente()
    End Sub
    Public Overloads Sub Fuente(ByVal Estilo As FontStyle)
        mFuenteEstilo = Estilo
        EstablecerFuente()
    End Sub
    Private Sub EstablecerFuente()
        mFuente = New Font(mFuenteNombre, mFuenteTamaño, mFuenteEstilo)
        sz = ge.Graphics.MeasureString(" ", mFuente)
        mFuenteEspacio = sz.Width
    End Sub
#End Region

    ' Imprime un Pie de Página para la página Actual
    Public Sub PiePagina(ByVal Cadena As String)
        Dim AX As Single, AY As Single
        AX = mX
        AY = mY
        mY = ge.MarginBounds.Bottom + 50
        ge.Graphics.DrawString(Cadena, mFuente, Brushes.Black, MargenIzquierdo, mY)
        mX = AX
        mY = AY
    End Sub
    ' Define una Columna para una tabla
    Public Overloads Sub DefCol(ByVal Tamaño As Single)
        Dim Columna As SColumna
        Columna.Tamaño = Tamaño
        Columna.Alineacion = ContentAlignment.MiddleLeft
        Columna.Marco = False
        Columna.Relleno = Brushes.White
        Columna.FuenteNombre = mFuenteNombre
        Columna.FuenteTamaño = mFuenteTamaño
        Columna.FuenteEstilo = mFuenteEstilo
        mTabla.Add(Columna)
    End Sub
    ' Define una Columna para una tabla
    Public Overloads Sub DefCol(ByVal Tamaño As Single, ByVal Alineacion As ContentAlignment)
        Dim Columna As SColumna
        Columna.Tamaño = Tamaño
        Columna.Alineacion = Alineacion
        Columna.Marco = False
        Columna.Relleno = Brushes.White
        Columna.FuenteNombre = mFuenteNombre
        Columna.FuenteTamaño = mFuenteTamaño
        Columna.FuenteEstilo = mFuenteEstilo
        mTabla.Add(Columna)
    End Sub
    ' Define una Columna para una tabla
    Public Overloads Sub DefCol(ByVal Tamaño As Single, ByVal Alineacion As ContentAlignment, ByVal Separador As Separadores)
        Dim Columna As SColumna
        Columna.Tamaño = Tamaño
        Columna.Alineacion = Alineacion
        Columna.Marco = False
        Columna.Separador = Separador
        Columna.Relleno = Brushes.White
        Columna.FuenteNombre = mFuenteNombre
        Columna.FuenteTamaño = mFuenteTamaño
        Columna.FuenteEstilo = mFuenteEstilo
        mTabla.Add(Columna)
    End Sub
    ' Define una Columna para una tabla
    Public Overloads Sub DefCol(ByVal Tamaño As Single, ByVal Alineacion As ContentAlignment, ByVal Marco As Boolean)
        Dim Columna As SColumna
        Columna.Tamaño = Tamaño
        Columna.Alineacion = Alineacion
        Columna.Marco = Marco
        Columna.Relleno = Brushes.White
        Columna.FuenteNombre = mFuenteNombre
        Columna.FuenteTamaño = mFuenteTamaño
        Columna.FuenteEstilo = mFuenteEstilo
        mTabla.Add(Columna)
    End Sub
    Public Overloads Sub DefCol(ByVal Tamaño As Single, ByVal Alineacion As ContentAlignment, ByVal Marco As Boolean, ByVal Relleno As Brush)
        Dim Columna As SColumna
        Columna.Tamaño = Tamaño
        Columna.Alineacion = Alineacion
        Columna.Marco = Marco
        Columna.Relleno = Relleno
        Columna.FuenteNombre = mFuenteNombre
        Columna.FuenteTamaño = mFuenteTamaño
        Columna.FuenteEstilo = mFuenteEstilo
        mTabla.Add(Columna)
    End Sub
    Public Overloads Sub DefCol(ByVal Tamaño As Single, ByVal Alineacion As ContentAlignment, ByVal Marco As Boolean, ByVal Relleno As Brush, ByVal Nombre As String, ByVal TamañoFuente As Integer, ByVal Estilo As FontStyle)
        Dim Columna As SColumna
        Columna.Tamaño = Tamaño
        Columna.Alineacion = Alineacion
        Columna.Marco = Marco
        Columna.Relleno = Relleno
        Columna.FuenteNombre = Nombre
        Columna.FuenteTamaño = TamañoFuente
        Columna.FuenteEstilo = Estilo
        mTabla.Add(Columna)
    End Sub
    Public Overloads Sub DefCol(ByVal Tamaño As Single, ByVal Alineacion As ContentAlignment, ByVal Marco As Boolean, ByVal Fuente As Font)
        Dim Columna As SColumna
        Columna.Tamaño = Tamaño
        Columna.Alineacion = Alineacion
        Columna.Marco = Marco
        Columna.Relleno = Brushes.White
        Columna.FuenteNombre = Fuente.Name
        Columna.FuenteTamaño = Fuente.Size
        Columna.FuenteEstilo = Fuente.Style
        mTabla.Add(Columna)
    End Sub
    Public Overloads Sub DefCol(ByVal Tamaño As Single, ByVal Alineacion As ContentAlignment, ByVal Separador As Separadores, ByVal Fuente As Font)
        Dim Columna As SColumna
        Columna.Tamaño = Tamaño
        Columna.Alineacion = Alineacion
        Columna.Separador = Separador
        Columna.Marco = False
        Columna.Relleno = Brushes.White
        Columna.FuenteNombre = Fuente.Name
        Columna.FuenteTamaño = Fuente.Size
        Columna.FuenteEstilo = Fuente.Style
        mTabla.Add(Columna)
    End Sub
    Public Overloads Sub DefCol(ByVal Tamaño As Single, ByVal Alineacion As ContentAlignment, ByVal Marco As Boolean, ByVal Relleno As Brush, ByVal Fuente As Font)
        Dim Columna As SColumna
        Columna.Tamaño = Tamaño
        Columna.Alineacion = Alineacion
        Columna.Marco = Marco
        Columna.Relleno = Relleno
        Columna.FuenteNombre = Fuente.Name
        Columna.FuenteTamaño = Fuente.Size
        Columna.FuenteEstilo = Fuente.Style
        mTabla.Add(Columna)
    End Sub
    Public Overloads Sub ModCol(ByVal Indice As Integer, ByVal Alineacion As ContentAlignment)
        Dim Columna As SColumna, Incio As Integer, Fnal As Integer, a As Integer
        If Indice > mTabla.Count Then Exit Sub
        If Indice = 0 Then
            Incio = 0
            Fnal = mTabla.Count - 1
        Else
            Incio = Indice - 1
            Fnal = Indice - 1
        End If
        For a = Incio To Fnal
            Columna = mTabla(a)
            Columna.alineacion = Alineacion
            mTabla.Item(a) = Columna
        Next

    End Sub
    Public Overloads Sub ModCol(ByVal Indice As Integer, ByVal Marco As Boolean)
        Dim Columna As SColumna, Incio As Integer, Fnal As Integer, a As Integer
        If Indice > mTabla.Count Then Exit Sub
        If Indice = 0 Then
            Incio = 0
            Fnal = mTabla.Count - 1
        Else
            Incio = Indice - 1
            Fnal = Indice - 1
        End If
        For a = Incio To Fnal
            Columna = mTabla(a)
            Columna.Marco = Marco
            mTabla.Item(a) = Columna
        Next

    End Sub
    Public Overloads Sub ModCol(ByVal Indice As Integer, ByVal Relleno As Brush)
        Dim Columna As SColumna, Incio As Integer, Fnal As Integer, a As Integer
        If Indice > mTabla.Count Then Exit Sub
        If Indice = 0 Then
            Incio = 0
            Fnal = mTabla.Count - 1
        Else
            Incio = Indice - 1
            Fnal = Indice - 1
        End If
        For a = Incio To Fnal
            Columna = mTabla(a)
            Columna.Relleno = Relleno
            mTabla.Item(a) = Columna
        Next
    End Sub
    Public Overloads Sub ModCol(ByVal Indice As Integer, ByVal Separador As Separadores)
        Dim Columna As SColumna, Incio As Integer, Fnal As Integer, a As Integer
        If Indice > mTabla.Count Then Exit Sub
        If Indice = 0 Then
            Incio = 0
            Fnal = mTabla.Count - 1
        Else
            Incio = Indice - 1
            Fnal = Indice - 1
        End If
        For a = Incio To Fnal
            Columna = mTabla(a)
            Columna.Separador = Separador
            mTabla.Item(a) = Columna
        Next
    End Sub
    Public Overloads Sub ModColF(ByVal Indice As Integer, ByVal Nombre As String, ByVal Tamaño As Integer, ByVal Estilo As FontStyle)
        Dim Columna As SColumna, Incio As Integer, Fnal As Integer, a As Integer
        If Indice > mTabla.Count Then Exit Sub
        If Indice = 0 Then
            Incio = 0
            Fnal = mTabla.Count - 1
        Else
            Incio = Indice - 1
            Fnal = Indice - 1
        End If
        For a = Incio To Fnal
            Columna = mTabla(a)
            Columna.FuenteNombre = Nombre
            Columna.FuenteTamaño = Tamaño
            Columna.FuenteEstilo = Estilo
            mTabla.Item(a) = Columna
        Next

    End Sub
    Public Overloads Sub ModColF(ByVal Indice As Integer, ByVal Tamaño As Integer, ByVal Estilo As FontStyle)
        Dim Columna As SColumna
        If Indice > mTabla.Count Then Exit Sub
        Columna = mTabla(Indice - 1)
        Columna.FuenteTamaño = Tamaño
        Columna.FuenteEstilo = Estilo
        mTabla.Item(Indice - 1) = Columna
    End Sub
    Public Overloads Sub ModColF(ByVal Indice As Integer, ByVal Estilo As FontStyle)
        Dim Columna As SColumna, Incio As Integer, Fnal As Integer, a As Integer
        If Indice > mTabla.Count Then Exit Sub
        If Indice = 0 Then
            Incio = 0
            Fnal = mTabla.Count - 1
        Else
            Incio = Indice - 1
            Fnal = Indice - 1
        End If
        For a = Incio To Fnal
            Columna = mTabla(a)
            Columna.FuenteEstilo = Estilo
            mTabla.Item(a) = Columna
        Next
    End Sub

    Public Sub ResetCols()
        mTabla.Clear()
    End Sub
    ' Permite Incluir imágenes en el documento
    Public Sub Imagen(ByVal Imagen As Image)
        ge.Graphics.DrawImage(Imagen, mX, mY)
    End Sub
    Public Sub Imagen(ByVal Imagen As Image, ByVal X As Single, ByVal Y As Single)
        ge.Graphics.DrawImage(Imagen, X, Y)
    End Sub
    Public Sub Imagen(ByVal Imagen As Image, ByVal X As Single, ByVal Y As Single, ByVal W As Single, ByVal H As Single)
        ge.Graphics.DrawImage(Imagen, X, Y, W, H)
    End Sub
    Public Sub ImagenWH(ByVal Imagen As Image, ByVal W As Single, ByVal H As Single)
        ge.Graphics.DrawImage(Imagen, X, Y, W, H)
    End Sub

    Public Sub New()
        Iniciando = True
    End Sub

    Private Sub DocImprimir_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles DocImprimir.BeginPrint
        RaiseEvent InicioImpresion()
    End Sub

    Private Sub DocImprimir_EndPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles DocImprimir.EndPrint
        RaiseEvent FinImpresion()
    End Sub
    Public Function InList(ByVal Valor As Object, ByVal ParamArray Lista() As Object) As Boolean
        Dim a As Integer
        InList = False
        For a = 0 To UBound(Lista)
            If Valor = Lista(a) Then
                InList = True
                Exit Function
            End If
        Next a
    End Function

End Class
