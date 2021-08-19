Public Class dtoVERSIONES_TITAN
    Dim MyIDVERSION_TITAN As Long
    Dim MyFECHA As String
    Dim MyVERSION As String
    Dim MyVERSION_ULTIMO As String
    Dim MyVIGENTE As Long
    Public Property VERSION_ULTIMO() As String

        Get
            VERSION_ULTIMO = MyVERSION_ULTIMO
        End Get
        Set(ByVal value As String)
            MyVERSION_ULTIMO = value
        End Set
    End Property
    Public Property VERSION() As String

        Get
            VERSION = MyVERSION
        End Get
        Set(ByVal value As String)
            MyVERSION = Value
        End Set
    End Property
    Public Property IDVERSION_TITAN() As Long

        Get
            IDVERSION_TITAN = MyIDVERSION_TITAN
        End Get
        Set(ByVal value As Long)
            MyIDVERSION_TITAN = Value
        End Set
    End Property
    Public Property FECHA() As String

        Get
            FECHA = MyFECHA
        End Get
        Set(ByVal value As String)
            MyFECHA = Value
        End Set
    End Property
    Public Property VIGENTE() As Long

        Get
            VIGENTE = MyVIGENTE
        End Get
        Set(ByVal value As Long)
            MyVIGENTE = Value
        End Set
    End Property
End Class
