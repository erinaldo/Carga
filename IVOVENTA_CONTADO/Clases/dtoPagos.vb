Imports AccesoDatos
Public Class dtoPagos
#Region "VARIABLES"
    Public v_control As Integer = 1
    Public v_idtipo_moneda As Integer
    Public v_monto_afecto As Double
    Public v_billete_pago As Double
    Public v_diferencia_pago As Double
    Public v_idfactura_contado As Integer
    Public v_monto_cambio As Double
#End Region

#Region "METODOS"
    'Public Function fnGrabarPagos_2009() As Boolean
    '    Dim flag As Boolean = False
    '    If v_monto_afecto <= 0 Then
    '        Return False
    '    End If
    '    Try

    '        Dim varSP_OBJECT As Object() = {"PKG_IVOVENTACARGA.SP_INSUPD_PAGOS", 16, v_control, 1, v_idtipo_moneda, 1, v_monto_afecto, 3, v_billete_pago, 3, v_diferencia_pago, 3, CType(v_idfactura_contado, String), 2, v_monto_cambio, 3}
    '        Dim rstControl As New ADODB.Recordset
    '        rstControl = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If rstControl.State = 1 Then
    '            If rstControl.EOF = False And rstControl.BOF = False Then
    '                flag = True
    '            End If
    '        End If
    '        rstControl = Nothing
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnGrabarPagos() As Boolean
        Dim flag As Boolean = False
        If v_monto_afecto <= 0 Then
            Return False
        End If
        '
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOVENTACARGA.SP_INSUPD_PAGOS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_control", v_control, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idtipo_moneda", v_idtipo_moneda, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_monto_afecto", v_monto_afecto, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_billete_pago", v_billete_pago, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_diferencia_pago", v_diferencia_pago, OracleClient.OracleType.Double)
            db_bd.AsignarParametro("v_idfactura_contado", v_idfactura_contado, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_monto_cambio", v_monto_cambio, OracleClient.OracleType.Double)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            lds_tmp = db_bd.EjecutarDataSet
            '
            If lds_tmp.Tables(0).Rows.Count > 1 Then
                flag = True
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
#End Region
End Class
