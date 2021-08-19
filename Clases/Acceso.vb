Imports AccesoDatos
Public Class Acceso
    Shared Sub Asignar(ByVal frm As Form)  'raiz
        G_fila = ObtieneFila()
        G_lista(G_Fila, 1).form = frm.Name
        Hnd = frm.Handle
        G_lista(G_Fila, 1).id = Hnd 'frm.Handle
    End Sub

    Shared Sub Asignar(ByVal frm As Form, ByVal id As Long)  'hojas
        'Dim x As Integer = ObtieneColumna(fila)
        'G_lista(G_Fila, x).form = frm.Name

        Dim iFila As Integer = ObtieneFila(id)
        Dim x As Integer = ObtieneColumna(iFila)
        G_lista(iFila, x).form = frm.Name
        G_lista(iFila, x).id = frm.Handle
    End Sub

    Private Shared Function ObtieneColumna(ByVal fila As Integer) As Integer
        For x As Integer = 1 To G_Lista.GetLength(1) - 1
            If IsNothing(G_lista(fila, x).form) Then
                Return x
            End If
        Next
    End Function

    Private Shared Function ObtieneFila(ByVal id As Long) As Long
        For y As Integer = 1 To G_lista.GetLength(0) - 1
            If G_lista(y, 1).id = id Then
                Return y
            End If
        Next
    End Function
    Private Shared Function ObtieneFila() As Integer
        For y As Integer = 1 To G_lista.GetLength(0) - 1
            If IsNothing(G_lista(y, 1).form) Then
                Return y
            End If
        Next
    End Function
    Shared Function ObtieneFila(ByVal frm As Form, Optional ByVal hnd As Long = 0) As Integer
        Dim iHnd As Long
        If hnd = 0 Then
            iHnd = frm.Handle
        Else
            iHnd = hnd
        End If
        For y As Integer = 1 To G_lista.GetLength(0) - 1
            For x As Integer = 1 To G_lista.GetLength(1) - 1
                If frm.Name = G_lista(y, x).form And iHnd = G_lista(y, x).id Then
                    Return y
                End If
            Next
        Next
    End Function
    Shared Sub Eliminar(ByVal frm As Form, ByVal fila As Integer)
        For x As Integer = 1 To G_lista.GetLength(1) - 1
            If frm.Name = G_lista(G_Fila, x).form Then
                G_lista(G_Fila, x).form = Nothing
                G_lista(G_Fila, x).id = 0
                Return
            End If
        Next
    End Sub

    Private Shared Function ObtieneFamilia(ByVal fila As Integer) As String
        Dim s As String = ""
        For x As Integer = 1 To G_Lista.GetLength(1) - 1
            If Not IsNothing(G_lista(G_Fila, x).form) Then
                s = s & ObtienePlantilla(G_lista(G_Fila, x).form) & "-"
            End If
        Next
        If s.Trim.Length = 0 Then
            s = ""
        Else
            s = s.Substring(0, s.Length - 1)
        End If
        Return s
    End Function

    Private Shared Function ObtienePlantilla(ByVal objeto As String) As String
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOACCESO.SP_OBTIENE_PLANTILLA", CommandType.StoredProcedure)
            db.AsignarParametro("vi_objeto", objeto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0).Item(0)) Then
                    Return ""
                Else
                    Return dt.Rows(0).Item(0)
                End If
            Else
                Return ""
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function
    Shared Function ObtieneConfiguracion(ByVal rol As Integer, ByVal fila As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            Dim familia As String = ObtieneFamilia(fila)
            db.Conectar()
            db.CrearComando("PKG_IVOACCESO.SP_OBTIENE_CONFIGURACION", CommandType.StoredProcedure)
            db.AsignarParametro("ni_rol", rol, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_familia", familia, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Private Shared Function ControlBuscar(ByVal Nombre As String, ByVal Contenedor As Control, ByVal nombre2 As String, ByVal estado As Integer) As Control
        Dim ctrControl As Control = Nothing
        Dim sName As String = "", sName2 As String
        Dim iPosicion As Integer = 0

        For Each ctrBuscado As Control In Contenedor.Controls
            If ctrBuscado.ToString.Substring(0, 1).ToUpper = "M" Then
                Dim a As Integer = 1
            End If
            If ctrBuscado.Name.ToUpper = Nombre.ToUpper Then
                ctrControl = ctrBuscado
                If nombre2.Trim.Length > 0 Then 'objeto(coleccion)
                    For Each obj As Object In CType(ctrControl, ToolStrip).Items
                        'If CType(obj, ToolStrip) Is "ToolStripMenuItem" Then
                        sName = CType(obj, ToolStripMenuItem).Name
                        'End If
                        iPosicion = nombre2.IndexOf("-")
                        sName2 = nombre2.Substring(iPosicion + 1).Trim
                        If sName.ToUpper = sName2.ToUpper Then
                            ctrControl = Nothing
                            CType(obj, ToolStripMenuItem).Enabled = estado
                            CType(obj, ToolStripMenuItem).Tag = estado
                            Exit For
                        End If
                    Next
                    If Not IsNothing(ctrControl) Then
                        ctrControl = Nothing
                        Exit For
                    End If
                End If
                Exit For
            End If

            If ctrBuscado.HasChildren Then
                ctrControl = ControlBuscar(Nombre, ctrBuscado, nombre2, estado)
                If Not ctrControl Is Nothing Then
                    Exit For
                End If
            End If
        Next
        Return ctrControl
    End Function


    Shared Function TieneAcceso(ByVal rol As Integer, ByVal fila As Integer) As Boolean
        Dim db As New BaseDatos
        Try
            Dim familia As String = ObtieneFamilia(fila)
            db.Conectar()
            db.CrearComando("PKG_IVOACCESO.SP_GET_ESTADO_ROL_CLASE", CommandType.StoredProcedure)
            db.AsignarParametro("ni_rol", rol, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_familia", familia, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim dt As DataTable = db.EjecutarDataTable
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)(0)
            Else
                Return True
                'Return False
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function ListarRol(ByVal usuario As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOACCESO.SP_LISTAR_ROL_111", CommandType.StoredProcedure)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Function

    Shared Sub VerificaCambio(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim tipo As String = sender.GetType.Name.ToUpper
            If sender.GetType.Name.ToUpper = "ToolStripMenuItem".ToUpper Then
                If CType(sender, ToolStripItem).Enabled Then
                    If Not (IsNothing(CType(sender, ToolStripItem).Tag)) Then
                        If Not (CType(sender, ToolStripItem).Tag.ToString.Length = 0) AndAlso CType(sender, ToolStripItem).Tag = 0 Then
                            CType(sender, ToolStripItem).Enabled = False
                        End If
                    End If
                    'ElseIf Not (CType(sender, ToolStripItem).Enabled) Then
                    '    If CType(sender, ToolStripItem).Tag = 1 Then
                    '        CType(sender, ToolStripItem).Enabled = True
                    '    End If
                End If
            ElseIf sender.GetType.Name.ToUpper = "button".ToUpper Then
                If CType(sender, Button).Enabled Then
                    If Not (IsNothing(CType(sender, Button).Tag)) Then
                        If Not (CType(sender, Button).Tag.ToString.Length = 0) AndAlso CType(sender, Button).Tag = 0 Then
                            CType(sender, Button).Enabled = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Shared Function SiRol(ByVal rol As Integer, ByVal frm As Form, ByVal bloque As Integer, Optional ByVal subbloque As Integer = 1) As Boolean
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOACCESO.SP_GET_ROL_BLOQUE", CommandType.StoredProcedure)
            db.AsignarParametro("ni_rol", rol, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_frm", frm.Name, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_bloque", bloque, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_subbloque", subbloque, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_datos", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                Return ds.Tables(0).Rows(0)(0)
            Else
                Return True
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Message)
        Finally
            db.Desconectar()
        End Try
    End Function
    Shared Sub AplicaConfiguracion2(ByVal dt As DataTable, ByVal contexto As ContextMenuStrip)
        Dim iEstado As Integer = 0
        Dim sControl As String
        Dim iPosicion As Integer = 0
        For Each row As DataRow In dt.Rows
            iEstado = row.Item("estado")
            sControl = row("control")

            iPosicion = sControl.IndexOf("-")
            sControl = sControl.Substring(iPosicion + 1)

            For Each t As ToolStripMenuItem In contexto.Items
                If t.Name = sControl Then
                    t.Enabled = iEstado
                End If
            Next
        Next
    End Sub
    Shared Sub AplicaConfiguracion(ByVal dt As DataTable, ByVal frm As Form, Optional ByVal contexto As ContextMenuStrip = Nothing)
        Dim obj As New Control
        Dim iEstado As Integer = 0
        Dim sControl As String, sControl2 As String
        Dim iPosicion As Integer = 0
        For Each row As DataRow In dt.Rows
            iEstado = row.Item("estado")
            sControl = row("control")
            If sControl.ToUpper = "btnaceptar".ToUpper Then
                Dim aa As Byte = 0
            End If

            iPosicion = sControl.IndexOf("-")
            If iPosicion > -1 Then
                sControl2 = sControl
                sControl = sControl.Substring(0, iPosicion)
            Else
                sControl2 = ""
            End If

            'MessageBox.Show(sControl)

            If sControl.ToUpper.Trim = "CONTEXTMENUSTRIP" Then
                If Not contexto Is Nothing Then
                    Dim s As String = sControl2.Trim.ToUpper.Substring(iPosicion + 1)
                    For Each t As ToolStripMenuItem In contexto.Items
                        If t.Name.Trim.ToUpper = s Then
                            t.Enabled = iEstado
                        End If
                    Next
                End If
            Else
                obj = ControlBuscar(sControl, frm, sControl2, iEstado)
                If Not (obj Is Nothing) Then
                    If iEstado = 0 Then
                        obj.Enabled = iEstado
                        obj.Tag = iEstado
                    End If
                End If
            End If
        Next
    End Sub
End Class
