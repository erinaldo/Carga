Imports INTEGRACION_EN
Imports System.Data.OracleClient
Public Class Cls_BuscarTarifaCliente_AD
    'Private iOracle_Cmd As New OracleCommand

    'Public Function Buscar_LC_ClienteAD_1(ByVal iPersona As String) As String
    '    Try

    '        Dim lStr_Retorno As String
    '        Dim vStrFuncion As String = ""
    '        iOracle_Cmd = New OracleCommand
    '        iOracle_Cmd.Connection = Conexion()
    '        vStrFuncion = "SELECT (F_VALIDA_LC_CLIENTE_2('" & iPersona & "')) FROM DUAL"
    '        iOracle_Cmd.CommandText = vStrFuncion
    '        iOracle_Cmd.CommandType = CommandType.Text
    '        lStr_Retorno = iOracle_Cmd.ExecuteScalar()


    '        Return lStr_Retorno
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    Finally
    '        iOracle_Cmd.Connection.Close()
    '    End Try
    'End Function


    'Public Function Buscar_LC_ClienteAD(ByVal iPersona As String) As String
    '    Try
    '        Dim lStr_Retorno As String
    '        Dim vStrFuncion As String = ""
    '        iOracle_Cmd = New OracleCommand
    '        iOracle_Cmd.Connection = Conexion()
    '        vStrFuncion = "SELECT (F_VALIDA_LC_CLIENTE_1('" & iPersona & "')) FROM DUAL"
    '        iOracle_Cmd.CommandText = vStrFuncion
    '        iOracle_Cmd.CommandType = CommandType.Text
    '        lStr_Retorno = iOracle_Cmd.ExecuteScalar()
    '        Return lStr_Retorno
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    Finally
    '        iOracle_Cmd.Connection.Close()
    '    End Try
    'End Function

    'Public Function Buscar_TarifaClienteAD(ByVal iiOrigen As String, ByVal iiDestino As String, ByVal iiPersona As String) As DataTable
    '    Try
    '        Dim dt As DataTable = New DataTable()
    '        Dim da As OracleDataAdapter = New OracleDataAdapter()

    '        iOracle_Cmd.Connection = Conexion()
    '        iOracle_Cmd.CommandType = CommandType.StoredProcedure 'indicamos que es un procedure
    '        iOracle_Cmd.Parameters.Clear()
    '        iOracle_Cmd.CommandText = "SP_BUSCAR_TARIFA_CARGA_I"
    '        iOracle_Cmd.Parameters.Add("xi_Origen", OracleType.VarChar).Value = iiOrigen
    '        iOracle_Cmd.Parameters.Add("xi_destino", OracleType.VarChar).Value = iiDestino
    '        iOracle_Cmd.Parameters.Add("xi_Persona", OracleType.VarChar).Value = iiPersona

    '        Dim prm1 As New OracleParameter("cor_buscar", OracleType.Cursor)
    '        prm1.Direction = ParameterDirection.Output
    '        iOracle_Cmd.Parameters.Add(prm1)
    '        da.SelectCommand = iOracle_Cmd
    '        da.Fill(dt)
    '        iOracle_Cmd.Connection.Close()
    '        Return dt
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    Finally
    '        iOracle_Cmd.Connection.Close()
    '    End Try
    'End Function

    'Function F_EditarTarifaClienteAD(ByVal objTarifaCargaCliente_EN As Cls_TarifaCargaCliente_EN) As String

    '    Dim lOracle_Transaction As OracleTransaction
    '    Dim lStr_Mensaje As String = ""

    '    iOracle_Cmd.Connection = Conexion()
    '    lOracle_Transaction = iOracle_Cmd.Connection.BeginTransaction()
    '    iOracle_Cmd.Transaction = lOracle_Transaction
    '    Try
    '        iOracle_Cmd.CommandType = CommandType.StoredProcedure
    '        iOracle_Cmd.CommandText = "PKG_IVOPERSONA.SP_INSUPD_TARIFA_CLIENTE_RGT1"
    '        With objTarifaCargaCliente_EN

    '            iOracle_Cmd.Parameters.Clear()
    '            iOracle_Cmd.Parameters.Add("iicentro_costo", OracleType.Int32).Value = .iDCENTRO_COSTO
    '            iOracle_Cmd.Parameters.Add("iCONTROL", OracleType.VarChar).Value = 2
    '            iOracle_Cmd.Parameters.Add("iIDTARIFAS_CARGA_CLIENTE", OracleType.VarChar).Value = .IDTARIFAS_CARGA_CLIENTE
    '            iOracle_Cmd.Parameters.Add("iCODIGOPERSONA", OracleType.VarChar).Value = .iCODIGOPERSONA
    '            iOracle_Cmd.Parameters.Add("iIDUNIDAD_AGENCIA", OracleType.Int32).Value = .iUnidad_Agencia
    '            iOracle_Cmd.Parameters.Add("iIDUNIDAD_AGENCIA_DESTINO", OracleType.Int32).Value = .iUnidad_Agencia_Destino
    '            iOracle_Cmd.Parameters.Add("iCG_MONTO_BASE", OracleType.Number).Value = .iCG_MONTO_BASE
    '            iOracle_Cmd.Parameters.Add("iCG_X_PESO", OracleType.Number).Value = .iCG_X_PESO
    '            iOracle_Cmd.Parameters.Add("iCG_X_VOLUMEN", OracleType.Number).Value = .iCG_X_VOLUMEN
    '            iOracle_Cmd.Parameters.Add("iEC_MONTO_BASE", OracleType.Number).Value = .iEC_MONTO_BASE
    '            iOracle_Cmd.Parameters.Add("iEC_X_PESO", OracleType.Number).Value = .iEC_X_PESO
    '            iOracle_Cmd.Parameters.Add("iEC_X_VOLUMEN", OracleType.Number).Value = .iEC_X_VOLUMEN
    '            iOracle_Cmd.Parameters.Add("iPO_MONTO_BASE", OracleType.Number).Value = .iPO_MONTO_BASE
    '            iOracle_Cmd.Parameters.Add("iPO_X_PESO", OracleType.Number).Value = .iPO_X_PESO
    '            iOracle_Cmd.Parameters.Add("iPO_X_VOLUMEN", OracleType.Number).Value = .iPO_X_VOLUMEN
    '            iOracle_Cmd.Parameters.Add("iGI_MONTO_BASE", OracleType.Number).Value = .iGI_MONTO_BASE
    '            iOracle_Cmd.Parameters.Add("iGI_NORMAL", OracleType.Number).Value = .iGI_NORMAL
    '            iOracle_Cmd.Parameters.Add("iGI_TELEFONICO", OracleType.Number).Value = .iGI_TELEFONICO
    '            iOracle_Cmd.Parameters.Add("iFECHA_ACTIVACION", OracleType.DateTime).Value = .iFECHA_ACTIVACION
    '            iOracle_Cmd.Parameters.Add("iFECHA_DESACTIVACION", OracleType.DateTime).Value = .iFECHA_DESACTIVACION
    '            iOracle_Cmd.Parameters.Add("iES_VIGENTE", OracleType.Int32).Value = .iES_VIGENTE
    '            iOracle_Cmd.Parameters.Add("iIDESTADO_REGISTRO", OracleType.Int32).Value = .iIDESTADO_REGISTRO
    '            iOracle_Cmd.Parameters.Add("iIDUSUARIO_PERSONAL", OracleType.Int32).Value = .iIDUSUARIO_PERSONAL
    '            iOracle_Cmd.Parameters.Add("iIDROL_USUARIO", OracleType.Int32).Value = .iIDROL_USUARIO
    '            iOracle_Cmd.Parameters.Add("iIP", OracleType.VarChar).Value = .iIP
    '            iOracle_Cmd.Parameters.Add("iCG_X_Sobre", OracleType.Number).Value = .iCG_X_Sobre
    '            Dim prm1 As New OracleParameter("oCUR_CONTROL", OracleType.Cursor)
    '            prm1.Direction = ParameterDirection.Output
    '            iOracle_Cmd.Parameters.Add(prm1)
    '        End With
    '        iOracle_Cmd.ExecuteNonQuery()
    '        lOracle_Transaction.Commit()

    '    Catch ex As Exception
    '        lStr_Mensaje = ex.Message.ToString
    '        lOracle_Transaction.Rollback()
    '        Return lStr_Mensaje
    '    Finally
    '        iOracle_Cmd.Connection.Close()
    '    End Try
    '    Return lStr_Mensaje

    'End Function



End Class
