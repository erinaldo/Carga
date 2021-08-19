Public Class Cls_TarifaSubCuentaEN

    Private _iDTARIFA_SUBCUENTA As String
    Private _ipPersona As String
    Private _iDCLIENTE_SUBCUENTA As String
    Private _IDCENTRO_COSTO As Integer
    Private _IDUNIDAD_AGENCIA As Integer
    Private _IDUNIDAD_AGENCIA_DESTINO As Integer
    Private _PRECIO_X_PESO As Double
    Private _PRECIO_X_VOLUMEN As Double
    Private _PRECIO_X_SOBRE As Double
    Private _MONTO_BASE As Double
    Private _esVigente As Integer
    Private _IDTIPO_MONEDA As Integer
    Private _IP As String
    Private _IDUSUARIO_PERSONAL As Integer
    Private _IDESTADO_REGISTRO As Integer
    Private _FECHA_ACTIVACION As Date
    Private _FECHA_DESACTIVACION As Date
    Private _IDROL_USUARIO As Integer


    Public Property iDTARIFA_SUBCUENTA()

        Get
            Return Me._iDTARIFA_SUBCUENTA
        End Get
        Set(ByVal value)
            Me._iDTARIFA_SUBCUENTA = value
        End Set
    End Property

    Public Property IdPersona()
        Get
            Return Me._ipPersona
        End Get
        Set(ByVal value)
            Me._ipPersona = value
        End Set
    End Property

    Public Property iDCLIENTE_SUBCUENTA()
        Get
            Return Me._iDCLIENTE_SUBCUENTA
        End Get
        Set(ByVal value)
            Me._iDCLIENTE_SUBCUENTA = value
        End Set
    End Property

    Public Property IDCENTRO_COSTO()
        Get
            Return Me._IDCENTRO_COSTO
        End Get
        Set(ByVal value)
            Me._IDCENTRO_COSTO = value
        End Set
    End Property

    Public Property IDUNIDAD_AGENCIA()
        Get
            Return Me._IDUNIDAD_AGENCIA
        End Get
        Set(ByVal value)
            Me._IDUNIDAD_AGENCIA = value
        End Set
    End Property

    Public Property IDUNIDAD_AGENCIA_DESTINO()
        Get
            Return Me._IDUNIDAD_AGENCIA_DESTINO
        End Get
        Set(ByVal value)
            Me._IDUNIDAD_AGENCIA_DESTINO = value
        End Set
    End Property

    Public Property PRECIO_X_PESO()
        Get
            Return Me._PRECIO_X_PESO
        End Get
        Set(ByVal value)
            Me._PRECIO_X_PESO = value
        End Set
    End Property

    Public Property PRECIO_X_VOLUMEN()
        Get
            Return Me._PRECIO_X_VOLUMEN
        End Get
        Set(ByVal value)
            Me._PRECIO_X_VOLUMEN = value
        End Set
    End Property

    Public Property PRECIO_X_SOBRE()
        Get
            Return Me._PRECIO_X_SOBRE
        End Get
        Set(ByVal value)
            Me._PRECIO_X_SOBRE = value
        End Set
    End Property
    Public Property MONTO_BASE()
        Get
            Return Me._MONTO_BASE
        End Get
        Set(ByVal value)
            Me._MONTO_BASE = value
        End Set
    End Property

    Public Property esVigente()
        Get
            Return Me._esVigente
        End Get
        Set(ByVal value)
            Me._esVigente = value
        End Set
    End Property

    Public Property IDTIPO_MONEDA()
        Get
            Return Me._IDTIPO_MONEDA
        End Get
        Set(ByVal value)
            Me._IDTIPO_MONEDA = value
        End Set
    End Property

    Public Property IP()
        Get
            Return Me._IP
        End Get
        Set(ByVal value)
            Me._IP = value
        End Set
    End Property

    Public Property IDUSUARIO_PERSONAL()
        Get
            Return Me._IDUSUARIO_PERSONAL
        End Get
        Set(ByVal value)
            Me._IDUSUARIO_PERSONAL = value
        End Set
    End Property


    Public Property IDESTADO_REGISTRO()
        Get
            Return Me._IDESTADO_REGISTRO
        End Get
        Set(ByVal value)
            Me._IDESTADO_REGISTRO = value
        End Set
    End Property


    Public Property FECHA_ACTIVACION()

        Get
            Return Me._FECHA_ACTIVACION
        End Get
        Set(ByVal value)
            Me._FECHA_ACTIVACION = value
        End Set

    End Property

    Public Property FECHA_DESACTIVACION()

        Get
            Return Me._FECHA_DESACTIVACION
        End Get
        Set(ByVal value)
            Me._FECHA_DESACTIVACION = value
        End Set
    End Property

    Public Property IDROL_USUARIO()

        Get
            Return Me._IDROL_USUARIO
        End Get
        Set(ByVal value)
            Me._IDROL_USUARIO = value
        End Set
    End Property



End Class
