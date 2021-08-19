Imports AccesoDatos
Public Class dtoCalculadora
    Private iPeso As Double
    Public Property Peso() As Double
        Get
            Return iPeso
        End Get
        Set(ByVal value As Double)
            iPeso = value
        End Set
    End Property
    Private iVolumen As Double
    Public Property Volumen() As Double
        Get
            Return iVolumen
        End Get
        Set(ByVal value As Double)
            iVolumen = value
        End Set
    End Property
    Private iBase As Double
    Public Property Base() As Double
        Get
            Return iBase
        End Get
        Set(ByVal value As Double)
            iBase = value
        End Set
    End Property
    Private iSobre As Double
    Public Property Sobre() As Double
        Get
            Return iSobre
        End Get
        Set(ByVal value As Double)
            iSobre = value
        End Set
    End Property

    Public Sub ObtieneSeguro(ByVal monto As Double, ByRef tipo As Integer, ByRef porcen As Double)
        Dim db_bd As New BaseDatos
        Dim lobj_tmp As New Object
        Try
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOCARGA_ASEGURADA.SP_RECUPERA_MONTO_PORCE", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input
            db_bd.AsignarParametro("MONTO", monto, OracleClient.OracleType.Double)
            'Variables de salidas 
            db_bd.AsignarParametro("TIPO", OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("oP_porcen_carga_ase", OracleClient.OracleType.Double)
            '
            db_bd.EjecutarComando()
            '
            If db_bd.Parametros.Length > 0 Then
                tipo = IIf(db_bd.Parametros(1) Is DBNull.Value, 0, db_bd.Parametros(1))
                porcen = IIf(db_bd.Parametros(2) Is DBNull.Value, 0, db_bd.Parametros(2))
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
    End Sub

    Public Function TarifaPublica(ByVal origen As Integer, ByVal destino As Integer, ByVal producto As Integer, ByVal tarifa As Integer, ByVal entrega As Integer) As DataTable
        Dim flat As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOGUIAS_ENVIO.SP_TARIFA_PUBLICA_CARGA3", CommandType.StoredProcedure)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA", origen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDUNIDAD_AGENCIA_DESTINO", destino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_producto", producto, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_tarifa", tarifa, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("cur_Tarifa_Publica_Carga", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_condicion", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            db_bd.Desconectar()
            Dim ds As DataSet = db_bd.EjecutarDataSet()
            If ds.Tables(0).Rows.Count = 1 And ds.Tables(0).Rows(0).Item(0) = 1 Then
                If tarifa = 0 Then
                    iPeso = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_X_PESO")), 0, ds.Tables(0).Rows(0).Item("CG_X_PESO"))
                    iVolumen = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_X_VOLUMEN")), 0, ds.Tables(0).Rows(0).Item("CG_X_VOLUMEN"))
                    iBase = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_MONTO_BASE")), 0, ds.Tables(0).Rows(0).Item("CG_MONTO_BASE"))
                    iSobre = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CG_X_SOBRE")), 0, ds.Tables(0).Rows(0).Item("CG_X_SOBRE"))

                    If producto = 6 Then        'carga acompañada
                        If entrega = 1 Then
                            iBase = 0
                        End If
                    ElseIf producto = 7 Then    'pyme
                        iBase = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("PY_BASE_CONTADO")), 0, ds.Tables(0).Rows(0).Item("PY_BASE_CONTADO"))
                        iPeso = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("PY_PESO_CONTADO")), 0, ds.Tables(0).Rows(0).Item("PY_PESO_CONTADO"))
                        iVolumen = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("PY_VOLUMEN_CONTADO")), 0, ds.Tables(0).Rows(0).Item("PY_VOLUMEN_CONTADO"))
                        iSobre = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("PY_SOBRE_CONTADO")), 0, ds.Tables(0).Rows(0).Item("PY_SOBRE_CONTADO"))
                    ElseIf producto = 8 Then    'masiva
                        iBase = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("MA48_BASE_CONTADO")), 0, ds.Tables(0).Rows(0).Item("MA48_BASE_CONTADO"))
                        iPeso = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("MA48_PESO_CONTADO")), 0, ds.Tables(0).Rows(0).Item("MA48_PESO_CONTADO"))
                        iVolumen = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("MA48_VOLUMEN_CONTADO")), 0, ds.Tables(0).Rows(0).Item("MA48_VOLUMEN_CONTADO"))
                        iSobre = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("MA48_SOBRE_CONTADO")), 0, ds.Tables(0).Rows(0).Item("MA48_SOBRE_CONTADO"))
                        iBase = 0
                    End If
                Else
                    If producto = 8 Then        'masiva
                        iBase = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("MA24_BASE_CONTADO")), 0, ds.Tables(0).Rows(0).Item("MA24_BASE_CONTADO"))
                        iPeso = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("MA24_PESO_CONTADO")), 0, ds.Tables(0).Rows(0).Item("MA24_PESO_CONTADO"))
                        iVolumen = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("MA24_VOLUMEN_CONTADO")), 0, ds.Tables(0).Rows(0).Item("MA24_VOLUMEN_CONTADO"))
                        iSobre = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("MA24_SOBRE_CONTADO")), 0, ds.Tables(0).Rows(0).Item("MA24_SOBRE_CONTADO"))
                        iBase = 0
                    Else
                        iPeso = 0
                        iVolumen = 0
                        iBase = 0
                        iSobre = 0
                    End If
                End If
            End If
            Return ds.Tables(1)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
End Class
