Public Class dtoCONTROL_INGRESOS
    Dim MyIDUSUARIO_PERSONAL As Long
    Dim MyDESCRIPCION As String
    Dim MyNODO As Long
    Dim MyIDFORMULARIO As Long
    Dim MyFORMULARIO As String
    Dim MyVISIBLE As Long
    Public Property IDFORMULARIO() As Long

        Get
            IDFORMULARIO = MyIDFORMULARIO
        End Get
        Set(ByVal value As Long)
            MyIDFORMULARIO = Value
        End Set
    End Property
    Public Property NODO() As Long

        Get
            NODO = MyNODO
        End Get
        Set(ByVal value As Long)
            MyNODO = value
        End Set
    End Property
    Public Property VISIBLE() As Long

        Get
            VISIBLE = MyVISIBLE
        End Get
        Set(ByVal value As Long)
            MyVISIBLE = Value
        End Set
    End Property
    Public Property DESCRIPCION() As String

        Get
            DESCRIPCION = MyDESCRIPCION
        End Get
        Set(ByVal value As String)
            MyDESCRIPCION = Value
        End Set
    End Property
    Public Property FORMULARIO() As String

        Get
            FORMULARIO = MyFORMULARIO
        End Get
        Set(ByVal value As String)
            MyFORMULARIO = Value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONAL() As Long

        Get
            IDUSUARIO_PERSONAL = MyIDUSUARIO_PERSONAL
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONAL = value
        End Set
    End Property
    'Public Function SP_LIST_FORMULARIO_USUARIO_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As DataView
    '    Dim cmd As New System.Data.OracleClient.OracleCommand
    '    cmd.Connection = cnn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = "PKG_IVOCONTROL_INGRESOS.SP_LIST_FORMULARIO_USUARIO"
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '    cmd.Parameters.Add(New OracleClient.OracleParameter("CUR_LIST_FORMULARIO_USUARIO", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '    Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '    Dim ds As New DataSet
    '    daora.Fill(ds)
    '    Try
    '        SP_LIST_FORMULARIO_USUARIO_2009 = ds.Tables(0).DefaultView
    '        Return SP_LIST_FORMULARIO_USUARIO_2009
    '    Catch
    '        Throw
    '    End Try
    'End Function
    'Public Sub SP_IN_USUARIO_FORMULARIO_2009(ByVal cnn As OracleClient.OracleConnection)
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "PKG_IVOCONTROL_INGRESOS.SP_IN_USUARIO_FORMULARIO"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_IDUSUARIO_PERSONAL", OracleClient.OracleType.Number)).Value = IDUSUARIO_PERSONAL
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_VISIBLE", OracleClient.OracleType.Number)).Value = VISIBLE
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_DESCRIPCION", OracleClient.OracleType.VarChar)).Value = DESCRIPCION
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NODO", OracleClient.OracleType.Number)).Value = 0
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_FORMULARIO", OracleClient.OracleType.VarChar)).Value = FORMULARIO
    '        cmd.ExecuteNonQuery()
    '    Catch
    '        Throw
    '    End Try
    'End Sub
End Class
