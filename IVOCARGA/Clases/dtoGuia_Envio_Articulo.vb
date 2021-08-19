Imports AccesoDatos
Public Class dtoGuia_Envio_Articulo
#Region "VARIABLES"
    Public iMETRO_CUBICO As Double
    Public iCONTROL As Integer
    Public iIDGUIAS_ENVIO_ARTICULOS As Integer
    Public iIDTIPO_COMPROBANTE As Integer
    Public iPESO As Double
    Public iIDGUIAS_ENVIO As Integer
    Public iIDARTICULOS As Integer
    Public iCANTIDAD_ARTICULOS As Integer
    Public iPRECIO_X_ARTICULO As Double
    Public iIGV As Double
    Public iDESCUENTO As Double
    Public iPENALIDAD As Double
    Public iIP As String
    Public iIDUSUARIO_PERSONAL As Integer
    Public iIDROL_USUARIO As Integer
    Public iIDESTADO_REGISTRO As Integer
    'hlamas 04-10-2019
    Public iTOTAL_ARTICULO As Double

#End Region

#Region "RECORSET"
    'Public cur_datos As New ADODB.Recordset
    'Public cur_Error As New ADODB.Recordset
#End Region
#Region "METODOS"

    'Public Function fnINSTUPD_GENVIO_ARTICULOS_RGT_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_INSTUPD_GENVIO_ARTICULOS", 28, iCONTROL, 1, iIDGUIAS_ENVIO_ARTICULOS, 1, iIDGUIAS_ENVIO, 1, iIDARTICULOS, 1, iCANTIDAD_ARTICULOS, 1, iPRECIO_X_ARTICULO, 3, iIGV, 3, iDESCUENTO, 3, iPENALIDAD, 3, iIP, 2, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, iIDESTADO_REGISTRO, 1}
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_INSTUPD_GENVIO_ARTI_rgtii", 33, iCONTROL, 1, iIDGUIAS_ENVIO_ARTICULOS, 1, iIDGUIAS_ENVIO.ToString, 2, iIDARTICULOS, 1, iCANTIDAD_ARTICULOS, 1, iPRECIO_X_ARTICULO, 3, iIGV, 3, iDESCUENTO, 3, iPENALIDAD, 3, iIP, 2, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, iIDESTADO_REGISTRO, 1, iPESO, 3, iMETRO_CUBICO, 3}
    '        objLOG.fnLog("[dtoGuia_Envio_Articulo.fnINSTUPD_GENVIO_ARTICULOS] " & fnLoagObj(varSP_OBJECT))
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        If cur_datos.State = 1 Then
    '            flat = True
    '        Else
    '            cur_Error = cur_datos.NextRecordset
    '            If cur_Error.State = 1 Then
    '                MsgBox(cur_Error.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '            End If
    '        End If

    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    Public Function fnINSTUPD_GENVIO_ARTICULOS_RGT()
        Try
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet

            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOCARGA.SP_INSTUPD_GENVIO_ARTI_RGTII", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            db_bd.AsignarParametro("iCONTROL", iCONTROL, OracleClient.OracleType.Int16)
            '
            db_bd.AsignarParametro("iIDGUIAS_ENVIO_ARTICULOS", iIDGUIAS_ENVIO_ARTICULOS, OracleClient.OracleType.Int32)
            '
            db_bd.AsignarParametro("xiIDGUIAS_ENVIO", iIDGUIAS_ENVIO.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDARTICULOS", iIDARTICULOS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iCANTIDAD_ARTICULOS", iCANTIDAD_ARTICULOS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iPRECIO_X_ARTICULO", iPRECIO_X_ARTICULO, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("iIGV", iIGV, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("iDESCUENTO", iIGV, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("iPENALIDAD", iPENALIDAD, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("iIP", iIP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDUSUARIO_PERSONAL", iIDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDROL_USUARIO", iIDROL_USUARIO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDESTADO_REGISTRO", iIDESTADO_REGISTRO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iTOTAL_PESO", iPESO, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("iMETRO_CUBICO", iMETRO_CUBICO, OracleClient.OracleType.Number)
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Error", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            ' Ejecuta lo que se ha recuperado, como estaba en el procedimiento actual  
            lds_tmp = db_bd.EjecutarDataSet()
            '
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                Exit Function
            End If
            '
            If lds_tmp.Tables(1).Rows.Count > 0 Then
                If IsDBNull(lds_tmp.Tables(1).Rows(0)(0)) = False Then
                    MsgBox(CType(lds_tmp.Tables(1).Rows(0)(0), String), MsgBoxStyle.Information, "Seguridad Sistema")
                End If
            End If
            ' 
            '--
            'Manejo de errores 
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnINSTUPD_GENVIO_ARTICULOS_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        'Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_INSTUPD_GENVIO_ARTICULOS", 28, iCONTROL, 1, iIDGUIAS_ENVIO_ARTICULOS, 1, iIDGUIAS_ENVIO, 1, iIDARTICULOS, 1, iCANTIDAD_ARTICULOS, 1, iPRECIO_X_ARTICULO, 3, iIGV, 3, iDESCUENTO, 3, iPENALIDAD, 3, iIP, 2, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, iIDESTADO_REGISTRO, 1}
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_INSTUPD_GENVIO_ARTICULOS", 28, iCONTROL, 1, iIDGUIAS_ENVIO_ARTICULOS, 1, iIDGUIAS_ENVIO.ToString, 2, iIDARTICULOS, 1, iCANTIDAD_ARTICULOS, 1, iPRECIO_X_ARTICULO, 3, iIGV, 3, iDESCUENTO, 3, iPENALIDAD, 3, iIP, 2, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, iIDESTADO_REGISTRO, 1}
    '        objLOG.fnLog("[dtoGuia_Envio_Articulo.fnINSTUPD_GENVIO_ARTICULOS] " & fnLoagObj(varSP_OBJECT))
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        If cur_datos.State = 1 Then
    '            flat = True
    '        Else
    '            cur_Error = cur_datos.NextRecordset
    '            If cur_Error.State = 1 Then
    '                MsgBox(cur_Error.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '            End If
    '        End If

    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    'Public Function fnINSTUPD_FACBOL_ARTICULOS_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCARGA.SP_INSTUPD_FACBOL_ARTICULOS", 32, iCONTROL, 1, iIDGUIAS_ENVIO_ARTICULOS.ToString, 2, iIDTIPO_COMPROBANTE, 1, iPESO, 3, iIDGUIAS_ENVIO.ToString, 2, iIDARTICULOS, 1, iCANTIDAD_ARTICULOS, 1, iPRECIO_X_ARTICULO, 3, iIGV, 3, iDESCUENTO, 3, iPENALIDAD, 3, iIP, 2, iIDUSUARIO_PERSONAL, 1, iIDROL_USUARIO, 1, iIDESTADO_REGISTRO, 1}
    '        objLOG.fnLog("[dtoGuia_Envio_Articulo.fnINSTUPD_GENVIO_ARTICULOS] " & fnLoagObj(varSP_OBJECT))
    '        cur_datos = Nothing
    '        cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        If cur_datos.State = 1 Then
    '            flat = True
    '        Else
    '            cur_Error = cur_datos.NextRecordset
    '            If cur_Error.State = 1 Then
    '                MsgBox(cur_Error.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '            End If
    '        End If

    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    Public Function fnINSTUPD_FACBOL_ARTICULOS()
        Try
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOCARGA.SP_INSTUPD_FACBOL_ARTICULOS", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iCONTROL", iCONTROL, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iIDGUIAS_ENVIO_ARTICULOS", iIDGUIAS_ENVIO_ARTICULOS.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("xiIDTIPO_COMPROBANTE", iIDTIPO_COMPROBANTE, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("iPESO", iPESO, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("xiIDCOMPROBANTE", iIDGUIAS_ENVIO.ToString, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDARTICULOS", iIDARTICULOS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iCANTIDAD_ARTICULOS", iCANTIDAD_ARTICULOS, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iPRECIO_X_ARTICULO", iPRECIO_X_ARTICULO, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("iIGV", iIGV, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("iDESCUENTO", iDESCUENTO, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("iPENALIDAD", iPENALIDAD, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("iIP", iIP, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIDUSUARIO_PERSONAL", iIDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDROL_USUARIO", iIDROL_USUARIO, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("iIDESTADO_REGISTRO", iIDESTADO_REGISTRO, OracleClient.OracleType.Int32)
            '
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Datos", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Error", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            ' Ejecuta lo que se ha recuperado, como estaba en el procedimiento actual  
            Dim lds_tmp As New DataSet
            '
            lds_tmp = db_bd.EjecutarDataSet()
            If lds_tmp.Tables(0).Rows.Count > 0 Then
                Exit Function
            End If
            '
            If lds_tmp.Tables(1).Rows.Count > 0 Then
                If IsDBNull(db_bd.EjecutarDataSet.Tables(1).Rows(0)(0)) = False Then
                    MsgBox(CType(db_bd.EjecutarDataSet.Tables(1).Rows(0)(0), String), MsgBoxStyle.Information, "Seguridad Sistema")
                End If
            End If
            ' 
            '--
            'Manejo de errores 
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class
