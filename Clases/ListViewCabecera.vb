Public Class ListViewCabecera
    Public m_sNombre As String
    Public m_sTamanio As Integer
    Public m_iAliniacion As Integer 'Left =0 , Right=1 ' Center=2
    Public m_iTipoDato As Integer '0 imagen,1 integer , 2 decimal 3 string 4 fecha, 5 object     
    Public Property Nombre() As String
        Get
            Return m_sNombre
        End Get
        Set(ByVal Value As String)
            m_sNombre = Value
        End Set
    End Property
    Public Property Tamanio() As Integer
        Get
            Return m_sTamanio
        End Get
        Set(ByVal Value As Integer)
            m_sTamanio = Value
        End Set
    End Property
    Public Property Aliniacion() As Integer
        Get
            Return m_iAliniacion
        End Get
        Set(ByVal Value As Integer)
            m_iAliniacion = Value
        End Set
    End Property
    Public Property TipoDato() As Integer
        Get
            Return m_iTipoDato
        End Get
        Set(ByVal Value As Integer)
            If Value >= 0 And Value < 5 Then
                m_iTipoDato = Value
            Else
                m_iTipoDato = 5
            End If
        End Set
    End Property
    Public Sub New(ByVal Nombre As String, ByVal _
        Tamanio As String, ByVal Aliniacion As Integer, ByVal TipoDato As Integer)
        m_sNombre = Nombre
        m_sTamanio = Tamanio
        m_iAliniacion = Aliniacion
        m_iTipoDato = TipoDato
    End Sub
End Class
