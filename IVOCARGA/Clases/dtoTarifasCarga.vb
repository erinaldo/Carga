Imports AccesoDatos
Public Class dtoTarifasCarga
#Region "TARIFARIO ORIGEN DESTINO"
    Dim CG_MONTO_BASE As Double
    Dim CG_X_PESO As Double
    Dim CG_X_VOLUMEN As Double

    Dim EC_MONTO_BASE As Double
    Dim EC_X_PESO As Double
    Dim EC_X_VOLUMEN As Double

    Dim PO_MONTO_BASE As Double
    Dim PO_X_PESO As Double
    Dim PO_X_VOLUMEN As Double

    Dim GI_MONTO_BASE As Double
    Dim GI_NORMAL As Double
    Dim GI_TELEFONICO As Double
#End Region
#Region "RECORSET"
    'Private rst_Tarifas_Carga As New ADODB.Recordset
#End Region
#Region "PROPIEDADES"
    Public Property fnCG_MONTO_BASE() As Double
        Get
            Return CG_MONTO_BASE
        End Get
        Set(ByVal value As Double)
            CG_MONTO_BASE = value
        End Set
    End Property

    Public Property fnCG_X_PESO() As Double
        Get
            Return CG_X_PESO
        End Get
        Set(ByVal value As Double)
            CG_X_PESO = value
        End Set
    End Property

    Public Property fnCG_X_VOLUMEN() As Double
        Get
            Return CG_X_VOLUMEN
        End Get
        Set(ByVal value As Double)
            CG_X_VOLUMEN = value
        End Set
    End Property
    Public Property fnEC_MONTO_BASE() As Double
        Get
            Return EC_MONTO_BASE
        End Get
        Set(ByVal value As Double)
            EC_MONTO_BASE = value
        End Set
    End Property
    Public Property fnEC_X_PESO() As Double
        Get
            Return EC_X_PESO
        End Get
        Set(ByVal value As Double)
            EC_X_PESO = value
        End Set
    End Property
    Public Property fnEC_X_VOLUMEN() As Double
        Get
            Return EC_X_VOLUMEN
        End Get
        Set(ByVal value As Double)
            EC_X_VOLUMEN = value
        End Set
    End Property

    Public Property fnPO_MONTO_BASE() As Double
        Get
            Return PO_MONTO_BASE
        End Get
        Set(ByVal value As Double)
            PO_MONTO_BASE = value
        End Set
    End Property
    Public Property fnPO_X_PESO() As Double
        Get
            Return PO_X_PESO
        End Get
        Set(ByVal value As Double)
            PO_X_PESO = value
        End Set
    End Property
    Public Property fnPO_X_VOLUMEN() As Double
        Get
            Return PO_X_VOLUMEN
        End Get
        Set(ByVal value As Double)
            PO_X_VOLUMEN = value
        End Set
    End Property
    Public Property fnGI_MONTO_BASE() As Double
        Get
            Return GI_MONTO_BASE
        End Get
        Set(ByVal value As Double)
            GI_MONTO_BASE = value
        End Set
    End Property
    Public Property fnGI_NORMAL() As Double
        Get
            Return GI_NORMAL
        End Get
        Set(ByVal value As Double)
            GI_NORMAL = value
        End Set
    End Property
    Public Property fnGI_TELEFONICO() As Double
        Get
            Return GI_TELEFONICO
        End Get
        Set(ByVal value As Double)
            GI_TELEFONICO = value
        End Set
    End Property
#End Region
#Region "METODOS"
    'Public Function fnTARIFARIO_PUBLICO_CARGA_2009(ByVal idAgenciaOrigen As Integer, ByVal idAgenciaDestino As Integer) As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOUUTILS.SP_TARIFARIO_PUBLICO_CARGA", 4, 4, 1}
    '        rst_Tarifas_Carga = Nothing
    '        rst_Tarifas_Carga = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If rst_Tarifas_Carga.EOF = False And rst_Tarifas_Carga.BOF = False Then
    '            CG_MONTO_BASE = Format(rst_Tarifas_Carga.Fields.Item(0).Value, "##0.00")
    '            CG_X_PESO = Format(rst_Tarifas_Carga.Fields.Item(1).Value, "##0.00")
    '            CG_X_VOLUMEN = Format(rst_Tarifas_Carga.Fields.Item(2).Value, "##0.00")

    '            EC_MONTO_BASE = Format(rst_Tarifas_Carga.Fields.Item(3).Value, "##0.00")
    '            EC_X_PESO = Format(rst_Tarifas_Carga.Fields.Item(4).Value, "##0.00")
    '            EC_X_VOLUMEN = Format(rst_Tarifas_Carga.Fields.Item(5).Value, "##0.00")

    '            PO_MONTO_BASE = Format(rst_Tarifas_Carga.Fields.Item(6).Value, "##0.00")
    '            PO_X_PESO = Format(rst_Tarifas_Carga.Fields.Item(7).Value, "##0.00")
    '            PO_X_VOLUMEN = Format(rst_Tarifas_Carga.Fields.Item(8).Value, "##0.00")

    '            GI_MONTO_BASE = Format(rst_Tarifas_Carga.Fields.Item(9).Value, "##0.00")
    '            GI_NORMAL = Format(rst_Tarifas_Carga.Fields.Item(10).Value, "##0.00")
    '            GI_TELEFONICO = Format(rst_Tarifas_Carga.Fields.Item(11).Value, "##0.00")
    '            flat = True
    '        Else
    '            flat = False
    '        End If

    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
#End Region
End Class
