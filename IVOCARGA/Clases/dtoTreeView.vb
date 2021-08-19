Public Class dtoTreeView
    Public Class Datos
        Private strDestino As String
        Public Property Destino() As String
            Get
                Return strDestino
            End Get
            Set(ByVal value As String)
                strDestino = value
            End Set
        End Property

        Private strProducto As String
        Public Property Producto() As String
            Get
                Return strProducto
            End Get
            Set(ByVal value As String)
                strProducto = value
            End Set
        End Property

        Private strSegmento As String
        Public Property Segmento() As String
            Get
                Return strSegmento
            End Get
            Set(ByVal value As String)
                strSegmento = value
            End Set
        End Property

        Private strCliente As String
        Public Property Cliente() As String
            Get
                Return strCliente
            End Get
            Set(ByVal value As String)
                strCliente = value
            End Set
        End Property

        Private strFecha As String
        Public Property Fecha() As String
            Get
                Return strFecha
            End Get
            Set(ByVal value As String)
                strFecha = value
            End Set
        End Property

        Private dblPeso1 As Double
        Public Property Peso1() As Double
            Get
                Return dblPeso1
            End Get
            Set(ByVal value As Double)
                dblPeso1 = value
            End Set
        End Property

        Private intEnvios1 As Integer
        Public Property Envios1() As Integer
            Get
                Return intEnvios1
            End Get
            Set(ByVal value As Integer)
                intEnvios1 = value
            End Set
        End Property

        Private dblPeso2 As Double
        Public Property Peso2() As Double
            Get
                Return dblPeso2
            End Get
            Set(ByVal value As Double)
                dblPeso2 = value
            End Set
        End Property

        Private intEnvios2 As Integer
        Public Property Envios2() As Integer
            Get
                Return intEnvios2
            End Get
            Set(ByVal value As Integer)
                intEnvios2 = value
            End Set
        End Property

        Sub New(kg As Double, envios As Integer)
            'dblKg = kg
            'intEnvios = envios
        End Sub

        Sub New()

        End Sub
    End Class

    Public Structure Familia

        Private _padre As Datos
        Public Property Padre() As Datos
            Get
                Return Me._padre
            End Get
            Set(ByVal value As Datos)
                Me._padre = value
            End Set
        End Property

        Private _hijos As Generic.List(Of Datos)
        Public ReadOnly Property Hijos() As Generic.List(Of Datos)
            Get
                Return Me._hijos
            End Get
        End Property

        Public Sub New(ByVal padre As Datos)
            Me._padre = padre
            Me._hijos = New Generic.List(Of Datos)
        End Sub
    End Structure
End Class
