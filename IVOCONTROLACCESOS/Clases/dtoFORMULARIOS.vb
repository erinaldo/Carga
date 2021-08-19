Imports AccesoDatos
Public Class dtoFORMULARIOS
#Region "VARIABLES"
    'Recusros y Array de Datos
    'Public rst_datos_Form As ADODB.Recordset
    Public rst_datos_Form1 As DataTable
    'Public rst_MSG As ADODB.Recordset
    'Public rst_ERR As ADODB.Recordset
    '------------------------------------------------------------
    Public IDCONTROL As Integer
    Public IDFORMULARIO As Integer
    Public NOMBRE_FORMULARIO As String
    Public ESTADO_REGISTRO As Integer
    Public IDROL_USUARIO As Integer
    Public IDMODULO_SISTEMA As Integer
    Public ETIQUETA_FORMULARIO As String
#End Region
#Region "PROPIEDADES"

#End Region
#Region "METODOS"
    Public Function Listar_Datos_Form2009(ByVal strFiltro As String) As ADODB.Recordset
        'Try
        '    Dim varSP_OBJECT As Object() = {"PKG_IVOCONTROLACCESOS.SP_LISTAR_FORMULARIOS", 16, 1, 1, strFiltro, 2}
        '    rst_datos_Form = Nothing
        '    rst_datos_Form = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        '    If rst_datos_Form.EOF = False And rst_datos_Form.BOF = False Then
        '        '  rst_datos_Form.MoveFirst()
        '        IDFORMULARIO = Int(rst_datos_Form.Fields.Item(0).Value.ToString)
        '        NOMBRE_FORMULARIO = rst_datos_Form.Fields.Item(1).Value.ToString
        '        ETIQUETA_FORMULARIO = rst_datos_Form.Fields.Item(2).Value.ToString
        '        IDMODULO_SISTEMA = Int(rst_datos_Form.Fields.Item(3).Value.ToString)
        '        ESTADO_REGISTRO = Int(rst_datos_Form.Fields.Item(4).Value.ToString)
        '        IDROL_USUARIO = Int(rst_datos_Form.Fields.Item(5).Value.ToString)
        '    Else
        '        MsgBox("no Existen resulatdos para esta Busqueda, Revice sus Datos", MsgBoxStyle.Critical, "Seguridad Sistema")
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
        'End Try
        'Return rst_datos_Form
    End Function

    Public Function Listar_Datos_Form(ByVal strFiltro As String)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCONTROLACCESOS.SP_LISTAR_FORMULARIOS", CommandType.StoredProcedure)
            db.AsignarParametro("icontrol", 1, OracleClient.OracleType.Int32)
            db.AsignarParametro("iFiltro", strFiltro, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_control", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_Err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            Dim rst_datos_Form As DataTable = ds.Tables(0)
            If rst_datos_Form.Rows.Count > 0 Then
                IDFORMULARIO = Int(rst_datos_Form.Rows(0).Item(0).ToString)
                NOMBRE_FORMULARIO = rst_datos_Form.Rows(0).Item(1).ToString
                ETIQUETA_FORMULARIO = rst_datos_Form.Rows(0).Item(2).ToString
                IDMODULO_SISTEMA = Int(rst_datos_Form.Rows(0).Item(3).ToString)
                ESTADO_REGISTRO = Int(rst_datos_Form.Rows(0).Item(4).ToString)
                IDROL_USUARIO = Int(rst_datos_Form.Rows(0).Item(5).ToString)
            Else
                Throw New Exception("No se encontraron Registros.")
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Sub InsUpdateFormulario2009()
        'Try
        '    Dim varSP_OBJECT As Object() = {"PKG_IVOCONTROLACCESOS.SP_INSUPD_FORMULARIO", 16, IDCONTROL, 1, IDFORMULARIO, 1, NOMBRE_FORMULARIO, 2, ESTADO_REGISTRO, 1, IDROL_USUARIO, 1, IDMODULO_SISTEMA, 1, ETIQUETA_FORMULARIO, 2}
        '    rst_datos_Form = Nothing
        '    rst_MSG = Nothing
        '    rst_MSG = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        '    rst_datos_Form = rst_MSG.NextRecordset
        '    rst_ERR = rst_MSG.NextRecordset
        '    If rst_MSG.EOF = False And rst_MSG.BOF = False Then
        '        MsgBox(rst_MSG.Fields.Item(0).Value.ToString, 64, "Seguridad Sistema")
        '        ' rst_datos_Form = rst_MSG.NextRecordset
        '    Else
        '        If rst_ERR.EOF = False And rst_ERR.BOF = False Then
        '            rst_ERR.MoveFirst()
        '            MsgBox(rst_ERR.Fields(1).Value.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema")

        '        Else
        '            MsgBox("Revice sus Datos No se Realizado la Operacion", MsgBoxStyle.Exclamation, "Seguridad Sistema")
        '        End If

        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
        'End Try
    End Sub

    Public Sub InsUpdateFormulario()
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCONTROLACCESOS.SP_INSUPD_FORMULARIO", CommandType.StoredProcedure)
            db.AsignarParametro("iControl", IDCONTROL, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDFORMULARIO", IDFORMULARIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iNOMRBRE_FORMULARIO", NOMBRE_FORMULARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iESTADO_REGISTRO", ESTADO_REGISTRO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDROL_USUARIO", IDROL_USUARIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDMODULO_SISTEMA", IDMODULO_SISTEMA, OracleClient.OracleType.Int32)
            db.AsignarParametro("iETIQUETA_FORMULARIO", ETIQUETA_FORMULARIO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_MSG", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_Datos_Form", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_Err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            rst_datos_Form1 = ds.Tables(1)

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try

        'Try
        '    Dim varSP_OBJECT As Object() = {"PKG_IVOCONTROLACCESOS.SP_INSUPD_FORMULARIO", 16, IDCONTROL, 1, IDFORMULARIO, 1, NOMBRE_FORMULARIO, 2, ESTADO_REGISTRO, 1, IDROL_USUARIO, 1, IDMODULO_SISTEMA, 1, ETIQUETA_FORMULARIO, 2}
        '    rst_datos_Form = Nothing
        '    rst_MSG = Nothing
        '    rst_MSG = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
        '    rst_datos_Form = rst_MSG.NextRecordset
        '    rst_ERR = rst_MSG.NextRecordset
        '    If rst_MSG.EOF = False And rst_MSG.BOF = False Then
        '        MsgBox(rst_MSG.Fields.Item(0).Value.ToString, 64, "Seguridad Sistema")
        '        ' rst_datos_Form = rst_MSG.NextRecordset
        '    Else
        '        If rst_ERR.EOF = False And rst_ERR.BOF = False Then
        '            rst_ERR.MoveFirst()
        '            MsgBox(rst_ERR.Fields(1).Value.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema")

        '        Else
        '            MsgBox("Revice sus Datos No se Realizado la Operacion", MsgBoxStyle.Exclamation, "Seguridad Sistema")
        '        End If

        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
        'End Try
    End Sub

#End Region
#Region "INTERFACES"

#End Region
End Class
