Imports System.Data.OracleClient
Imports System.Windows.Forms
Module ModConexion
    'Dim cadena_conexion = "data source=" + rptservice + "; user id=titan; password=titan"

    'Dim cadena_conexionSQL = "Data Source=POSEIDON\PRODUCCION;Initial Catalog=OFITESO;User Id=sa;Password=OFISIS;"
    Dim cadena_conexionSQL = "Data Source=192.168.50.45;Initial Catalog=BD_FINA;User Id=sa;Password=303tslErp;"
    Dim cadena_conexionSQLPlan = "Data Source=192.168.50.45;Initial Catalog=BD_PLAN;User Id=sa;Password=303tslErp;"
    Dim cadena_conexionSQLMarcacion = "Data Source=POSEIDON\PRODUCCION;Initial Catalog=OFITESO;User Id=sa;Password=OFISIS;"

    Public cnnSQL As New System.Data.SqlClient.SqlConnection(cadena_conexionSQL)  '-- Tepsa
    Public cnnSQLPlan As New System.Data.SqlClient.SqlConnection(cadena_conexionSQLPlan)  '-- Tepsa
    Public cnnSQLMarcacion As New System.Data.SqlClient.SqlConnection(cadena_conexionSQLMarcacion)  '-- Tepsa

    Public dt_0 As DataTable

    Public oracon As Object ' ejemplo de conexion a datos 

    Public VOPASAJES As Object
    Public VOITINERARIOS As Object
    Public VOLIQUIDACIONES As Object
    Public VOREPORTES As Object
    Public VOUNIDADTRANSPORTE As Object
    Public VOCARGA As Object
    Public VOCONCESIONARIO As Object
    Public VOPERSONA As Object


    Public flagBusquedas As Integer = 0

End Module