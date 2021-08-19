Imports AccesoDatos
Public Class dtoCONTROLACCESOS
#Region "ARRAY DATOS"
    'Public rst_Control_Accesos As ADODB.Recordset
    'Public rst_Control_Tab As ADODB.Recordset

    Public dt_Control_Tab As DataTable

    'Public rst_Lista_Frm As ADODB.Recordset
    Public rst_Lista_Frm As DataTable

    'Public rst_Lista_Frm_Roles As ADODB.Recordset
    Public rst_Lista_Frm_Roles As DataTable

    'Public rst_Lista_Procesos As ADODB.Recordset
    'Public rst_Lista_COntroles As ADODB.Recordset

    Public dt_Lista_COntroles As DataTable
#End Region
#Region "VARIABLES"
    Public strRoles As String
#End Region
#Region "METODOS"
    ' Mod 17/09/2009 El formulario FrmControlEspeciesValoradas se ha quitado del proyecto no se usa) 
    'Public Sub ControlEspeciesValoradas_2009(ByVal pFrm As FrmControlEspeciesValoradas)
    '    Try

    '        Dim varSP_OBJECT() As Object = {"PKG_IVOCONTROLACCESOS.SP_FILTRO_ACCESOS_TOOL", 6, 2, 1, pFrm.Name, 2}
    '        rst_Control_Accesos = Nothing
    '        rst_Control_Accesos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If rst_Control_Accesos.EOF = False And rst_Control_Accesos.BOF = False Then
    '            pFrm.NuevoToolStripMenuItem1.Enabled = Int(rst_Control_Accesos.Fields.Item("NUEVO").Value)
    '            pFrm.EdicionToolStripMenuItem.Enabled = Int(rst_Control_Accesos.Fields.Item("EDITAR").Value)
    '            pFrm.GrabarToolStripMenuItem.Enabled = Int(rst_Control_Accesos.Fields.Item("GRABAR").Value)
    '            pFrm.WordToolStripMenuItem.Enabled = Int(rst_Control_Accesos.Fields.Item("EXPORTAR_WORK").Value)
    '            pFrm.ExcelToolStripMenuItem.Enabled = Int(rst_Control_Accesos.Fields.Item("EXPORTAR_EXCEL").Value)
    '            pFrm.PDFToolStripMenuItem.Enabled = Int(rst_Control_Accesos.Fields.Item("EXPORTAR_PDF").Value)
    '            pFrm.EmailToolStripMenuItem.Enabled = Int(rst_Control_Accesos.Fields.Item("EXPORTAR_EMAIL").Value)
    '            pFrm.ImprimirToolStripMenuItem.Enabled = Int(rst_Control_Accesos.Fields.Item("IMPRIMIR").Value)
    '            pFrm.EliminarToolStripMenuItem.Enabled = Int(rst_Control_Accesos.Fields.Item("ELIMINAR").Value)
    '            pFrm.CancelarToolStripMenuItem.Enabled = Int(rst_Control_Accesos.Fields.Item("CANCELAR").Value)
    '            pFrm.AyudaToolStripMenuItem1.Enabled = Int(rst_Control_Accesos.Fields.Item("AYUDA").Value)
    '        End If
    '        rst_Control_Tab = rst_Control_Accesos.NextRecordset
    '        If rst_Control_Tab.EOF = False And rst_Control_Tab.EOF = False Then
    '            Dim i As Integer
    '            Dim str As String
    '            str = "TAB_0"
    '            For i = 0 To pFrm.MenuTab.Items.Count - 1
    '                'pFrm.MenuTab.Items(i).Enabled = Int(rst_Control_Tab.Fields.Item(str & i.ToString()).Value)
    '            Next
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
    '    End Try
    'End Sub
    'Public Sub ControlAccesosUsuarios2009(ByVal pFrm As FrmPlantillaJ)
    'Try
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOCONTROLACCESOS.SP_FILTRO_ACCESOS_TOOL", 6, 2, 1, pFrm.Name, 2}
    '    rst_Control_Accesos = Nothing
    '    rst_Control_Accesos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    If rst_Control_Accesos.EOF = False And rst_Control_Accesos.BOF = False Then
    '        pFrm.NuevoToolStripMenuItem1.Enabled = Int(rst_Control_Accesos.Fields.Item("NUEVO").Value)
    '        pFrm.EdicionToolStripMenuItem.Enabled = Int(rst_Control_Accesos.Fields.Item("EDITAR").Value)
    '        pFrm.GrabarToolStripMenuItem.Enabled = Int(rst_Control_Accesos.Fields.Item("GRABAR").Value)
    '        pFrm.WordToolStripMenuItem.Enabled = Int(rst_Control_Accesos.Fields.Item("EXPORTAR_WORK").Value)
    '        pFrm.ExcelToolStripMenuItem.Enabled = Int(rst_Control_Accesos.Fields.Item("EXPORTAR_EXCEL").Value)
    '        pFrm.PDFToolStripMenuItem.Enabled = Int(rst_Control_Accesos.Fields.Item("EXPORTAR_PDF").Value)
    '        pFrm.EmailToolStripMenuItem.Enabled = Int(rst_Control_Accesos.Fields.Item("EXPORTAR_EMAIL").Value)
    '        pFrm.ImprimirToolStripMenuItem.Enabled = Int(rst_Control_Accesos.Fields.Item("IMPRIMIR").Value)
    '        pFrm.EliminarToolStripMenuItem.Enabled = Int(rst_Control_Accesos.Fields.Item("ELIMINAR").Value)
    '        pFrm.CancelarToolStripMenuItem.Enabled = Int(rst_Control_Accesos.Fields.Item("CANCELAR").Value)
    '        pFrm.AyudaToolStripMenuItem1.Enabled = Int(rst_Control_Accesos.Fields.Item("AYUDA").Value)
    '    End If
    '    rst_Control_Tab = rst_Control_Accesos.NextRecordset
    '    If rst_Control_Tab.EOF = False And rst_Control_Tab.EOF = False Then
    '        Dim i As Integer
    '        Dim str As String
    '        str = "TAB_0"
    '        For i = 0 To pFrm.MenuTab.Items.Count - 1
    '            'pFrm.MenuTab.Items(i).Enabled = Int(rst_Control_Tab.Fields.Item(str & i.ToString()).Value)
    '        Next
    '    End If
    'Catch ex As Exception
    '    MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
    'End Try
    'End Sub

    'Public Function Listar_Form2009() As ADODB.Recordset
    'Try
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOCONTROLACCESOS.SP_LISTAR_FRM", 4, 1, 1}
    '    rst_Lista_Frm = Nothing
    '    rst_Lista_Frm = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    'Listar_Form = rst_Lista_Frm
    'Catch ex As Exception
    '    MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
    'End Try
    'Return rst_Lista_Frm
    'End Function
    Public Function Listar_Form() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCONTROLACCESOS.SP_LISTAR_FRM", CommandType.StoredProcedure)
            db.AsignarParametro("icontrol", 1, OracleClient.OracleType.Int16)
            db.AsignarParametro("cur_control", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function Listar_Formulario_Roles2009(ByVal strFilter As String) As ADODB.Recordset
    'Try
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOCONTROLACCESOS.SP_FILTRO_FORMULARIOS_ROLES", 6, 1, 1, strFilter, 2}
    '    rst_Lista_Frm_Roles = Nothing
    '    rst_Lista_Frm_Roles = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    'Catch ex As Exception
    '    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
    'End Try
    'Return rst_Lista_Frm_Roles
    'End Function
    Public Function Listar_Formulario_Roles(ByVal strFilter As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCONTROLACCESOS.SP_FILTRO_FORMULARIOS_ROLES", CommandType.StoredProcedure)
            db.AsignarParametro("idControl", 1, OracleClient.OracleType.Int32)
            db.AsignarParametro("iFiltro", strFilter, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_Formularios_Roles", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            rst_Lista_Frm_Roles = ds.Tables(0)
            Return rst_Lista_Frm_Roles

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function LISTAR_PROCESOS2009() As ADODB.Recordset
    'Try
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOCONTROLACCESOS.SP_LISTAR_PROCESOS", 4, 1, 1}
    '    rst_Lista_Procesos = Nothing
    '    rst_Lista_Procesos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    'Catch ex As Exception
    '    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
    'End Try
    'Return rst_Lista_Procesos
    'End Function
    Public Function LISTAR_PROCESOS() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCONTROLACCESOS.SP_LISTAR_PROCESOS", CommandType.StoredProcedure)
            db.AsignarParametro("icontrol", 1, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_control", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function


    'Public Function SP_LISTAR_FORM_TAB_TOOL2009(ByVal idFrom As Integer, ByVal idRol As Integer) As Boolean
    'Dim flag As Boolean
    'Try
    '    flag = True
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOCONTROLACCESOS.SP_LISTAR_FORM_TAB_TOOL", 6, idFrom, 1, idRol, 1}
    '    rst_Lista_Frm_Roles = Nothing
    '    rst_Control_Tab = Nothing
    '    rst_Lista_COntroles = Nothing
    '    rst_Lista_Frm_Roles = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    'rst_Lista_COntroles = rst_Lista_Frm_Roles.NextRecordset
    '    'rst_Control_Tab = rst_Lista_Frm_Roles.NextRecordset
    '    'If rst_Lista_Frm_Roles.EOF = False And rst_Lista_Frm_Roles.BOF = False Then
    '    'End If
    '    If rst_Lista_COntroles.EOF = False And rst_Lista_COntroles.BOF = False Then
    '        dtoToolBar.NUEVO = Int(rst_Lista_COntroles.Fields.Item(0).Value.ToString)
    '        dtoToolBar.EDITAR = Int(rst_Lista_COntroles.Fields.Item(1).Value.ToString)
    '        dtoToolBar.GRABAR = Int(rst_Lista_COntroles.Fields.Item(2).Value.ToString)
    '        dtoToolBar.CANCELAR = Int(rst_Lista_COntroles.Fields.Item(3).Value.ToString)
    '        dtoToolBar.EXPORTAR_WORK = Int(rst_Lista_COntroles.Fields.Item(4).Value.ToString)
    '        dtoToolBar.EXPORTAR_EXCEL = Int(rst_Lista_COntroles.Fields.Item(5).Value.ToString)
    '        dtoToolBar.EXPORTAR_PDF = Int(rst_Lista_COntroles.Fields.Item(6).Value.ToString)
    '        dtoToolBar.EMAIL = Int(rst_Lista_COntroles.Fields.Item(7).Value.ToString)
    '        dtoToolBar.IMPRIMIR = Int(rst_Lista_COntroles.Fields.Item(8).Value.ToString)
    '        dtoToolBar.AYUDA = Int(rst_Lista_COntroles.Fields.Item(9).Value.ToString)
    '        dtoToolBar.ELIMINAR = Int(rst_Lista_COntroles.Fields.Item(10).Value.ToString)
    '    End If
    '    If rst_Control_Tab.EOF = False And rst_Control_Tab.BOF = False Then
    '        dtoTabControl.TAB_01 = Int(rst_Control_Tab.Fields.Item(0).Value.ToString)
    '        dtoTabControl.TAB_02 = Int(rst_Control_Tab.Fields.Item(1).Value.ToString)
    '        dtoTabControl.TAB_03 = Int(rst_Control_Tab.Fields.Item(2).Value.ToString)
    '        dtoTabControl.TAB_04 = Int(rst_Control_Tab.Fields.Item(3).Value.ToString)
    '        dtoTabControl.TAB_05 = Int(rst_Control_Tab.Fields.Item(4).Value.ToString)
    '        dtoTabControl.TAB_06 = Int(rst_Control_Tab.Fields.Item(5).Value.ToString)
    '        dtoTabControl.TAB_07 = Int(rst_Control_Tab.Fields.Item(6).Value.ToString)
    '        dtoTabControl.TAB_08 = Int(rst_Control_Tab.Fields.Item(7).Value.ToString)
    '        dtoTabControl.TAB_09 = Int(rst_Control_Tab.Fields.Item(8).Value.ToString)
    '        dtoTabControl.TAB_10 = Int(rst_Control_Tab.Fields.Item(9).Value.ToString)
    '    End If
    'Catch ex As Exception
    '    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
    '    flag = False
    'End Try
    'Return flag
    'End Function

    Public Function SP_LISTAR_FORM_TAB_TOOL(ByVal idFrom As Integer, ByVal idRol As Integer) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCONTROLACCESOS.SP_LISTAR_FORM_TAB_TOOL", CommandType.StoredProcedure)
            db.AsignarParametro("iIDFORMULARIO", idFrom, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDROL_USUARIO", idRol, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_roles", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_tool", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_tab_control", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_Err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            rst_Lista_Frm_Roles = ds.Tables(0)
            dt_Lista_COntroles = ds.Tables(1)
            dt_Control_Tab = ds.Tables(2)
            If dt_Lista_COntroles.Rows.Count > 0 Then
                dtoToolBar.NUEVO = Int(dt_Lista_COntroles.Rows(0).Item(0).ToString)
                dtoToolBar.EDITAR = Int(dt_Lista_COntroles.Rows(0).Item(1).ToString)
                dtoToolBar.GRABAR = Int(dt_Lista_COntroles.Rows(0).Item(2).ToString)
                dtoToolBar.CANCELAR = Int(dt_Lista_COntroles.Rows(0).Item(3).ToString)
                dtoToolBar.EXPORTAR_WORK = Int(dt_Lista_COntroles.Rows(0).Item(4).ToString)
                dtoToolBar.EXPORTAR_EXCEL = Int(dt_Lista_COntroles.Rows(0).Item(5).ToString)
                dtoToolBar.EXPORTAR_PDF = Int(dt_Lista_COntroles.Rows(0).Item(6).ToString)
                dtoToolBar.EMAIL = Int(dt_Lista_COntroles.Rows(0).Item(7).ToString)
                dtoToolBar.IMPRIMIR = Int(dt_Lista_COntroles.Rows(0).Item(8).ToString)
                dtoToolBar.AYUDA = Int(dt_Lista_COntroles.Rows(0).Item(9).ToString)
                dtoToolBar.ELIMINAR = Int(dt_Lista_COntroles.Rows(0).Item(10).ToString)
            End If
            If dt_Control_Tab.Rows.Count > 0 Then
                dtoTabControl.TAB_01 = Int(dt_Control_Tab.Rows(0).Item(0).ToString)
                dtoTabControl.TAB_02 = Int(dt_Control_Tab.Rows(0).Item(1).ToString)
                dtoTabControl.TAB_03 = Int(dt_Control_Tab.Rows(0).Item(2).ToString)
                dtoTabControl.TAB_04 = Int(dt_Control_Tab.Rows(0).Item(3).ToString)
                dtoTabControl.TAB_05 = Int(dt_Control_Tab.Rows(0).Item(4).ToString)
                dtoTabControl.TAB_06 = Int(dt_Control_Tab.Rows(0).Item(5).ToString)
                dtoTabControl.TAB_07 = Int(dt_Control_Tab.Rows(0).Item(6).ToString)
                dtoTabControl.TAB_08 = Int(dt_Control_Tab.Rows(0).Item(7).ToString)
                dtoTabControl.TAB_09 = Int(dt_Control_Tab.Rows(0).Item(8).ToString)
                dtoTabControl.TAB_10 = Int(dt_Control_Tab.Rows(0).Item(9).ToString)
            End If
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try

    End Function

    '    Public Function GRABAR2009(ByVal t As dtoCONTROLTAB, ByVal v As dtoCONTROLTOOLBAR, ByVal f As dtoFORMULARIOS) As Boolean
    'Dim flag As Boolean
    'Try
    '    flag = True
    '    Dim varSP_OBJECT() As Object = {"PKG_IVOCONTROLACCESOS.SP_INSUPD_FORM_TAB_CONTROL", 50, dtoForm.IDCONTROL, 1, f.IDFORMULARIO, 1, strRoles, 2, t.TAB_01, 1, t.TAB_02, 1, t.TAB_03, 1, t.TAB_04, 1, t.TAB_05, 1, t.TAB_06, 1, t.TAB_07, 1, t.TAB_08, 1, t.TAB_09, 1, t.TAB_10, 1, v.NUEVO, 1, v.EDITAR, 1, v.GRABAR, 1, v.CANCELAR, 1, v.EXPORTAR_WORK, 1, v.EXPORTAR_EXCEL, 1, v.EXPORTAR_PDF, 1, v.EMAIL, 1, v.IMPRIMIR, 1, v.AYUDA, 1, v.ELIMINAR, 1}
    '    rst_Lista_COntroles = Nothing
    '    rst_Lista_COntroles = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '    If rst_Lista_COntroles.EOF = False And rst_Lista_COntroles.BOF = False Then
    '        MsgBox(rst_Lista_COntroles.Fields.Item(0).Value, 64, "Seguridad Sistema")
    '    Else
    '        MsgBox("Error en Grabacion", MsgBoxStyle.Critical, "Seguridad Sistema")
    '        flag = False
    '    End If
    'Catch ex As Exception
    '    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
    'End Try
    'Return flag
    'End Function

    Public Function GRABAR(ByVal t As dtoCONTROLTAB, ByVal v As dtoCONTROLTOOLBAR, ByVal f As dtoFORMULARIOS) As Boolean
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOCONTROLACCESOS.SP_INSUPD_FORM_TAB_CONTROL", CommandType.StoredProcedure)
            db.AsignarParametro("iControl", dtoForm.IDCONTROL, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDFORMULARIO", f.IDFORMULARIO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iRoles", strRoles, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iTAB_01", t.TAB_01, OracleClient.OracleType.Int32)
            db.AsignarParametro("iTAB_02", t.TAB_02, OracleClient.OracleType.Int32)
            db.AsignarParametro("iTAB_03", t.TAB_03, OracleClient.OracleType.Int32)
            db.AsignarParametro("iTAB_04", t.TAB_04, OracleClient.OracleType.Int32)
            db.AsignarParametro("iTAB_05", t.TAB_05, OracleClient.OracleType.Int32)
            db.AsignarParametro("iTAB_06", t.TAB_06, OracleClient.OracleType.Int32)
            db.AsignarParametro("iTAB_07", t.TAB_07, OracleClient.OracleType.Int32)
            db.AsignarParametro("iTAB_08", t.TAB_08, OracleClient.OracleType.Int32)
            db.AsignarParametro("iTAB_09", t.TAB_09, OracleClient.OracleType.Int32)
            db.AsignarParametro("iTAB_10", t.TAB_10, OracleClient.OracleType.Int32)
            db.AsignarParametro("iNUEVO", v.NUEVO, OracleClient.OracleType.Int32)
            db.AsignarParametro("iEDITAR", v.EDITAR, OracleClient.OracleType.Int32)
            db.AsignarParametro("iGRABAR", v.GRABAR, OracleClient.OracleType.Int32)
            db.AsignarParametro("iCANCELAR", v.CANCELAR, OracleClient.OracleType.Int32)
            db.AsignarParametro("iEXPORTAR_WORK", v.EXPORTAR_WORK, OracleClient.OracleType.Int32)
            db.AsignarParametro("iEXPORTAR_EXCEL", v.EXPORTAR_EXCEL, OracleClient.OracleType.Int32)
            db.AsignarParametro("iEXPORTAR_PDF", v.EXPORTAR_PDF, OracleClient.OracleType.Int32)
            db.AsignarParametro("iEXPORTAR_EMAIL", v.EMAIL, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIMPRIMIR", v.IMPRIMIR, OracleClient.OracleType.Int32)
            db.AsignarParametro("iAYUDA", v.AYUDA, OracleClient.OracleType.Int32)
            db.AsignarParametro("iELIMINAR", v.ELIMINAR, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur_MSG", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_Datos_Form", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_Err", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Dim ds As DataSet = db.EjecutarDataSet
            dt_Lista_COntroles = ds.Tables(0)
            If dt_Lista_COntroles.Rows.Count > 0 Then
                MsgBox(dt_Lista_COntroles.Rows(0).Item(0), 64, "Seguridad Sistema")
                Return True
            Else
                MsgBox("Error en Grabacion", MsgBoxStyle.Critical, "Seguridad Sistema")
                Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

#End Region
End Class
