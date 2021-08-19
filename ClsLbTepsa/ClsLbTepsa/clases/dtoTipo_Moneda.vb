Public Class dtoTipo_Moneda
#Region "VARIABLES"
    Dim MyIDTIPO_MONEDA As Integer
    Dim MySIMBOLO_MONEDA As String
    Dim MyDESCRIPCION As String
    Dim MyES_MONEDA_NACIONAL As Integer
    Dim MyIDUSUARIO_PERSONAL As Integer
    Dim MyIDROL_USUARIO As Integer
    Dim MyIP As String
    Dim MyFECHA_REGISTRO As String
    Dim MyIDUSUARIO_PERSONALMOD As Integer
    Dim MyIDROL_USUARIOMOD As Integer
    Dim MyIPMOD As String
    Dim MyFECHA_ACTUALIZACION As String
#End Region
#Region "PROPIEDADES"
    Public Property IDTIPO_MONEDA() As Integer
        Get
            IDTIPO_MONEDA = MyIDTIPO_MONEDA
        End Get
        Set(ByVal value As Integer)
            MyIDTIPO_MONEDA = Value
        End Set
    End Property
    Public Property SIMBOLO_MONEDA() As String
        Get
            SIMBOLO_MONEDA = MySIMBOLO_MONEDA
        End Get
        Set(ByVal value As String)
            MySIMBOLO_MONEDA = Value
        End Set
    End Property
    Public Property DESCRIPCION() As String
        Get
            DESCRIPCION = MyDESCRIPCION
        End Get
        Set(ByVal value As String)
            MyDESCRIPCION = Value
        End Set
    End Property
    Public Property ES_MONEDA_NACIONAL() As Integer
        Get
            ES_MONEDA_NACIONAL = MyES_MONEDA_NACIONAL
        End Get
        Set(ByVal value As Integer)
            MyES_MONEDA_NACIONAL = Value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONAL() As Integer
        Get
            IDUSUARIO_PERSONAL = MyIDUSUARIO_PERSONAL
        End Get
        Set(ByVal value As Integer)
            MyIDUSUARIO_PERSONAL = Value
        End Set
    End Property
    Public Property IDROL_USUARIO() As Integer
        Get
            IDROL_USUARIO = MyIDROL_USUARIO
        End Get
        Set(ByVal value As Integer)
            MyIDROL_USUARIO = Value
        End Set
    End Property
    Public Property IP() As String
        Get
            IP = MyIP
        End Get
        Set(ByVal value As String)
            MyIP = Value
        End Set
    End Property
    Public Property FECHA_REGISTRO() As String
        Get
            FECHA_REGISTRO = MyFECHA_REGISTRO
        End Get
        Set(ByVal value As String)
            MyFECHA_REGISTRO = Value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONALMOD() As Integer
        Get
            IDUSUARIO_PERSONALMOD = MyIDUSUARIO_PERSONALMOD
        End Get
        Set(ByVal value As Integer)
            MyIDUSUARIO_PERSONALMOD = Value
        End Set
    End Property
    Public Property IDROL_USUARIOMOD() As Integer
        Get
            IDROL_USUARIOMOD = MyIDROL_USUARIOMOD
        End Get
        Set(ByVal value As Integer)
            MyIDROL_USUARIOMOD = Value
        End Set
    End Property
    Public Property IPMOD() As String
        Get
            IPMOD = MyIPMOD
        End Get
        Set(ByVal value As String)
            MyIPMOD = Value
        End Set
    End Property
    Public Property FECHA_ACTUALIZACION() As String
        Get
            FECHA_ACTUALIZACION = MyFECHA_ACTUALIZACION
        End Get
        Set(ByVal value As String)
            MyFECHA_ACTUALIZACION = Value
        End Set
    End Property
#End Region
#Region "METODOS"
#End Region
End Class
