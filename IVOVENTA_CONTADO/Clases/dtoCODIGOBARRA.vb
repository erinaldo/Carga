Imports AccesoDatos
Public Class dtoCODIGOBARRA
#Region "Variables"
    Public clinte As String
    Public Cantidad As String
    Public NroDOC As String
    Public Origen As String
    Public Destino As String
    Public Destino2 As String
    Public CodigoBarra As String
    Public Fecha As String
    Public HoraImpresion As String
    Public AGEDOM As String
    'Public rstHoras As New ADODB.Recordset
    Public id As Integer
    Public tipo As Integer
    Public peso As Double
    Public AgenciaEmbarque As String
    Public AgenciaDesembarque As String
    Public asiento As Integer
    Public TotalBoleto As Double
    Public FechaPartida As String
    Public HoraPartida As String
    Public categoria As String
#End Region

#Region "Metodos"
    'Public Function fnGetHora_2009() As String
    '    Try
    '        Dim SQLQuery As Object() = {"select to_char(sysdate,'HH:Mi AM') hora from dual", 2}
    '        rstHoras = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If rstHoras.State = 1 Then
    '            If rstHoras.BOF = False And rstHoras.EOF = False Then
    '                HoraImpresion = rstHoras.Fields.Item("hora").Value.ToString
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        HoraImpresion = Now
    '    End Try
    '    Return HoraImpresion
    'End Function
    Public Function fnGetHora() As String
        Dim db_bd As New BaseDatos
        Try
            Dim ls_sql As String
            'conecta con la Bd
            ls_sql = "select PKG_GENERICO.sf_get_hora_servidor from  dual"
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando(ls_sql, CommandType.Text)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            ' No tiens 
            'Variables de salidas 
            'No existe parametros de salida 
            HoraImpresion = db_bd.EjecutarEscalar()
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
        Return HoraImpresion
    End Function
    'Public Sub sp_etiqueta_generada2009()
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_IVOGUIAS_ENVIO.sp_etiqueta_generada", 6, tipo, 1, id.ToString, 2}
    '        VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '    Catch
    '    End Try
    'End Sub
    Public Sub sp_etiqueta_generada()
        Dim db_bd As New BaseDatos
        Try
            Dim ls_tmp As String
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOGUIAS_ENVIO.sp_etiqueta_generada", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            'db_bd.AsignarParametro("ni_idtipo_comprobante", tipo, OracleClient.OracleType.Int32)
            'db_bd.AsignarParametro("ni_idcomprobante", id, OracleClient.OracleType.Int32)
            '
            db_bd.AsignarParametro("vi_tipo", tipo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("vi_documento", id, OracleClient.OracleType.Int32)
            '
            'Variables de salidas 
            'No existe parametros de salida 
            ls_tmp = db_bd.EjecutarEscalar
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
    End Sub

#End Region
End Class
