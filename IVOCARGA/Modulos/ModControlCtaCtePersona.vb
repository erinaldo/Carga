Imports AccesoDatos
Module ModControlCtaCtePersona
    'Dim daControl_CtaCte As New OleDb.OleDbDataAdapter
    Dim dtControl_CtaCte As New System.Data.DataTable
    Dim dvControl_CtaCte As New System.Data.DataView
    'Dim rstCurrendata As New ADODB.Recordset
    'Public Function fnESTADO_CTACTE_PERSONA_2009(ByVal dtGridView As DataGridView, ByVal iIDPERSONA As Integer, ByVal NroPagina As Integer, ByVal iTamPAG As Integer, ByVal Cliente_NroPaginas As TextBox, ByVal Nro_Total_Reg As TextBox) As Boolean
    'Dim flag As Boolean = False
    'Try
    '    rst = Nothing
    '    'Dim varSP_OBJECT() As Object = {"PKG_IVOUUTILS.SP_ESTADO_CTACTE_PERSONA", 4, iIDPERSONA, 1}
    '    Dim varSP_OBJECT() As Object = {"PKG_UTILITARIOS.SP_KARDEX_GUIAS_ENVIO", 8, iIDPERSONA, 1, NroPagina, 1, iTamPAG, 1}
    '    rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    If True Then
    '        dtControl_CtaCte.Clear()
    '        daControl_CtaCte.Fill(dtControl_CtaCte, rst)
    '        dvControl_CtaCte = dtControl_CtaCte.DefaultView
    '        dtGridView.DataSource = dvControl_CtaCte
    '        flag = True
    '        rstCurrendata = rst.NextRecordset

    '        If rstCurrendata.State = 1 Then
    '            Cliente_NroPaginas.Text = Int(rstCurrendata.Fields.Item(0).Value)
    '            Nro_Total_Reg.Text = Int(rstCurrendata.Fields.Item(1).Value)
    '        Else
    '            Cliente_NroPaginas.Text = 0
    '            Nro_Total_Reg.Text = 0
    '        End If

    '    Else
    '        dtControl_CtaCte.Clear()
    '        'MsgBox("No existe Resultados Para esta Busqueda...", MsgBoxStyle.Information, "Seguridad Sistema")
    '    End If
    'Catch ex As Exception
    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    'End Try
    'Return flag
    'End Function
    Public Function fnESTADO_CTACTE_PERSONA(ByVal dtGridView As DataGridView, ByVal iIDPERSONA As Integer, ByVal NroPagina As Integer, ByVal iTamPAG As Integer, ByVal Cliente_NroPaginas As TextBox, ByVal Nro_Total_Reg As TextBox) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_UTILITARIOS.SP_KARDEX_GUIAS_ENVIO", CommandType.StoredProcedure)
            db.AsignarParametro("v_idpersona", iIDPERSONA, OracleClient.OracleType.Int32)
            db.AsignarParametro("v_NroPag", NroPagina, OracleClient.OracleType.Number)
            db.AsignarParametro("v_TAM_PAG", iTamPAG, OracleClient.OracleType.Number)
            db.AsignarParametro("cur_Lista_Guias", OracleClient.OracleType.Cursor)
            '
            db.AsignarParametro("cur_Datos_Generales", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet
            ds = db.EjecutarDataSet
            dtGridView.DataSource = ds.Tables(0).DefaultView
            If ds.Tables(1).Rows.Count > 0 Then
                Cliente_NroPaginas.Text = Int(ds.Tables(1).Rows(0).Item(0))
                Nro_Total_Reg.Text = Int(ds.Tables(1).Rows(0).Item(1))
            Else
                Cliente_NroPaginas.Text = 0
                Nro_Total_Reg.Text = 0
            End If
            Return True

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function fnCLOSE() As Boolean
        'daControl_CtaCte = Nothing
        'dtControl_CtaCte = Nothing
        'dvControl_CtaCte = Nothing
    End Function
    'Public Function fnActualizaKardex_Doc_2009(ByVal iIDPERSONA As Integer) As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        rst = Nothing
    '        Dim varSP_OBJECT() As Object = {"PKG_UTILITARIOS.SP_ACTUALIZA_KARDEX_DOC", 4, iIDPERSONA, 1}
    '        rst = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If rst.State = 1 Then
    '            MsgBox(rst.Fields.Item(0).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '            flag = True
    '        Else
    '            flag = False
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    '
End Module
