Imports System.Data.OracleClient
Public Class dto_CargaAcompañada
    Dim cnn As New OracleConnection("data source=SISVYR; password=ventas5110; user id=vyr") '==>Produccion
    'Dim cnn As New OracleConnection("data source=VYR; password=ventas5110; user id=vyr") '==>Desarrollo
    Dim dataAdapter As OracleDataAdapter

    Public Function ObtenerBoleto(ByVal boleto As String) As DataTable
        With command("sp_cargar_boleto")
            .Parameters.Add(New OracleClient.OracleParameter("vi_boleto", OracleClient.OracleType.NVarChar)).Value = boleto
            .Parameters.Add(New OracleClient.OracleParameter("co_boleto", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
        End With

        Dim dt As New DataTable
        dataAdapter.Fill(dt)

        Return dt
    End Function
    Public Function BuscarBoleto(ByVal boleto As String) As DataTable
        With command("sp_buscar_boleto")
            .Parameters.Add(New OracleClient.OracleParameter("vi_boleto", OracleClient.OracleType.NVarChar)).Value = boleto
            .Parameters.Add(New OracleClient.OracleParameter("co_boleto", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
        End With

        Dim dt As New DataTable
        dataAdapter.Fill(dt)

        Return dt
    End Function

    Public Function ListarPuntoDesembarque(ByVal itinerario As String) As DataTable
        With command("sp_listar_punto_desembarque")
            .Parameters.Add(New OracleClient.OracleParameter("ni_itinerario", OracleClient.OracleType.NVarChar)).Value = itinerario
            .Parameters.Add(New OracleClient.OracleParameter("co_lista", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
        End With

        Dim dt As New DataTable
        dataAdapter.Fill(dt)

        Return dt
    End Function


    Private Function command(ByVal commandContex As String)

        Dim cmd As New OracleCommand
        cnn.Open() '-->Abre la conexión
        cmd.Connection = cnn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = commandContex
        dataAdapter = New OracleDataAdapter(cmd)
        cnn.Close() '-->Cierra la conexión
        Return cmd
    End Function
End Class
