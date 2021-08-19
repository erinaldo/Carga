Imports System.Data.SqlClient
Imports AccesoDatos
Public Class dtoCuentaCorriente
    Function ListarCliente()
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("demo_pkg.sp_listar_cliente", CommandType.StoredProcedure)
            db.AsignarParametro("co_cliente", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarLineaCredito(inicio As String, fin As String, estado As Integer, cliente As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("demo_pkg.sp_listar_linea_credito", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarGEFacturadas(inicio As String, fin As String, inicio2 As String, fin2 As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("demo_pkg.sp_listar_ge_facturada", CommandType.StoredProcedure)
            db.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_inicio2", inicio2, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fin2", fin2, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Function ObtienePagosCliente(ByVal cnnSQL As System.Data.SqlClient.SqlConnection, cliente As String) As SqlDataReader
        ' Usa una conexión con el ofisis 
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.CommandTimeout = 0
        cmd.Connection = cnnSQL
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "PR_A_PAGOS"
        If cnnSQL.State = ConnectionState.Closed Then cnnSQL.Open()
        cmd.Parameters.Add(New SqlClient.SqlParameter("@IICOD_EMPR", SqlDbType.Int)).Value = 1
        cmd.Parameters.Add(New SqlClient.SqlParameter("@ISCOD_TIEN", SqlDbType.VarChar)).Value = "CL"
        'Dim daora As New System.Data.SqlClient.SqlDataAdapter(cmd)
        Dim dr As SqlDataReader = cmd.ExecuteReader
        'daora.Fill(dt)
        Try
            Return dr
        Catch
            Throw
        End Try
    End Function

    Sub ActualizaHistoricoPagos(campo1 As String, campo2 As String, campo3 As String, campo4 As String, campo5 As String, campo6 As String, _
                                campo7 As Integer, campo8 As String, campo9 As String, campo10 As String, campo11 As String, campo12 As String, _
                                campo13 As Double, campo14 As Double, campo15 As Double, campo16 As String, campo17 As String, campo18 As String, _
                                campo19 As Double, campo20 As Double, campo21 As String, campo22 As String, opcion As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("demo_pkg.sp_actualizar_historico_pagos", CommandType.StoredProcedure)
            db.AsignarParametro("campo1", campo1, OracleClient.OracleType.VarChar)
            db.AsignarParametro("campo2", campo2, OracleClient.OracleType.VarChar)
            db.AsignarParametro("campo3", campo3, OracleClient.OracleType.VarChar)
            db.AsignarParametro("campo4", campo4, OracleClient.OracleType.VarChar)
            db.AsignarParametro("campo5", campo5, OracleClient.OracleType.VarChar)
            db.AsignarParametro("campo6", campo6, OracleClient.OracleType.VarChar)
            db.AsignarParametro("campo7", campo7, OracleClient.OracleType.Int32)
            db.AsignarParametro("campo8", campo8, OracleClient.OracleType.VarChar)
            db.AsignarParametro("campo9", campo9, OracleClient.OracleType.VarChar)
            db.AsignarParametro("campo10", campo10, OracleClient.OracleType.VarChar)
            db.AsignarParametro("campo11", campo11, OracleClient.OracleType.VarChar)
            db.AsignarParametro("campo12", campo12, OracleClient.OracleType.VarChar)
            db.AsignarParametro("campo13", campo13, OracleClient.OracleType.Number)
            db.AsignarParametro("campo14", campo14, OracleClient.OracleType.Number)
            db.AsignarParametro("campo15", campo15, OracleClient.OracleType.Number)
            db.AsignarParametro("campo16", campo16, OracleClient.OracleType.VarChar)
            db.AsignarParametro("campo17", campo17, OracleClient.OracleType.VarChar)
            db.AsignarParametro("campo18", campo18, OracleClient.OracleType.VarChar)
            db.AsignarParametro("campo19", campo19, OracleClient.OracleType.Number)
            db.AsignarParametro("campo20", campo20, OracleClient.OracleType.Number)
            db.AsignarParametro("campo21", campo21, OracleClient.OracleType.VarChar)
            db.AsignarParametro("campo22", campo22, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    Throw New Exception(dt.Rows(0).Item(1))
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Shared Sub ActualizaCuentaCorriente(cliente As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("demo_pkg.sp_actualiza_ctacte", CommandType.StoredProcedure)
            db.AsignarParametro("vi_cliente", cliente, OracleClient.OracleType.VarChar)
            db.EjecutarComando()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'db.Desconectar()
        End Try
    End Sub

    Function ListarDeudaCliente(cliente As Integer, estado As Integer, usuario As Integer, ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("demo_pkg.sp_listar_deuda", CommandType.StoredProcedure)
            'db.AsignarParametro("ni_cliente", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_usuario", estado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_ip", estado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

End Class
