Imports AccesoDatos
Public Class dtoRecepcionGuias
#Region "VARIABLES"
    Public iNro_Guia As String
    Public iIdestado_Registro As Integer
    Public fecha_Cargo As String
    '------------------------------

    Public iOpcion As Integer
    Public iCliente As String
    Public iNroRuc As String
    Public iFecha_Guia As String
    Public iFecha_Cargo As String
    Public iOrigen As String
    Public iDestino As String
    Public iEstado As String
    Public iTotal_Costo As String

    Public iPrecio_Peso As String
    Public iPrecio_Vol As String
    Public iPrecio_Sobre As String

    Public iTotal_Peso As String
    Public iTotal_Vol As String
    Public iTotal_Sobre As String

    Public iCantidad_Peso As String
    Public iCantidad_Vol As String
    Public iCantidad_Sobre As String

    Public iMonto_Impuesto As String
    Public iMonto_Base As String


    'Public cur_Datos As New ADODB.Recordset
    'Public curr_error As New ADODB.Recordset
    'Public cur_Tipo_Documento As New ADODB.Recordset
    Public coll_Tipo_Documento As New Collection
#End Region
#Region "Datatables"   'Cursores pasados a datatable 
    Public dt_cur_Tipo_Documento As New DataTable
    Public dt_cur_Datos As New DataTable
    Public dt_curr_error As New DataTable
    'Public dt_rstCurrenDoc As New DataTable
    Public dt_rstCurrenArt As New DataTable

#End Region


    'Dim daControl_Doc As New OleDb.OleDbDataAdapter
    Dim dtControl_Doc As New System.Data.DataTable
    Dim dvControl_Doc As New System.Data.DataView

    'Dim rstCurrenDoc As New ADODB.Recordset
    'Dim rstCurrenArt As New ADODB.Recordset
    'Dim daControl_Art As New OleDb.OleDbDataAdapter

    Dim dtControl_Art As New System.Data.DataTable
    Dim dvControl_Art As New System.Data.DataView



#Region "METODOS"
    'Public Function fnRECEPCION_GUIAS_CARGO_2009(ByVal dtGrigView_Doc As DataGridView, ByVal dtGrigView_Art As DataGridView) As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOGUIAS_ENVIO.SP_RECEPCION_GUIAS_CARGO", 14, iNro_Guia, 2, iIdestado_Registro, 1, fecha_Cargo, 2, dtoUSUARIOS.IdLogin, 1, dtoUSUARIOS.IdRol, 1, dtoUSUARIOS.IP, 2}
    '        objLOG.fnLog("[dtoRecepcionGuias.fnRECEPCION_GUIAS_CARGO] " & fnLoagObj(varSP_OBJECT))
    '        cur_Datos = Nothing
    '        curr_error = Nothing
    '        cur_Datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)

    '        If cur_Datos.EOF = False And cur_Datos.BOF = False Then
    '            If Int(cur_Datos.Fields.Item(0).Value.ToString) = 0 Then
    '                MsgBox(cur_Datos.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '                iCliente = ""
    '                'iNroRuc = cur_Datos.Fields.Item(3).Value.ToString
    '                iFecha_Guia = ""
    '                iFecha_Cargo = ""
    '                iOrigen = ""
    '                iDestino = ""
    '                iEstado = ""
    '                iTotal_Costo = "0.00"

    '            ElseIf Int(cur_Datos.Fields.Item(0).Value.ToString) = 1 Then
    '                MsgBox(cur_Datos.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '                iCliente = cur_Datos.Fields.Item("Razon_Social").Value.ToString
    '                iNroRuc = cur_Datos.Fields.Item("Nu_Docu_Suna").Value.ToString
    '                iFecha_Guia = cur_Datos.Fields.Item("FECHA_GUIA").Value.ToString
    '                iFecha_Cargo = cur_Datos.Fields.Item("Fecha_Cargos").Value.ToString
    '                iOrigen = cur_Datos.Fields.Item("Origen").Value.ToString
    '                iDestino = cur_Datos.Fields.Item("Destino").Value.ToString
    '                iEstado = cur_Datos.Fields.Item("Estado_Registro").Value.ToString



    '                iPrecio_Peso = cur_Datos.Fields.Item("Precio_Peso").Value.ToString
    '                iPrecio_Vol = cur_Datos.Fields.Item("Precio_Vol").Value.ToString
    '                iPrecio_Sobre = cur_Datos.Fields.Item("Precio_Sobre").Value.ToString

    '                iTotal_Peso = cur_Datos.Fields.Item("Total_Peso").Value.ToString
    '                iTotal_Vol = cur_Datos.Fields.Item("Total_Vol").Value.ToString
    '                'iTotal_Sobre = cur_Datos.Fields.Item("Total_Sobre").Value.ToString

    '                iCantidad_Peso = cur_Datos.Fields.Item("Cantidad_Peso").Value.ToString
    '                iCantidad_Vol = cur_Datos.Fields.Item("Cantidad_Vol").Value.ToString
    '                iCantidad_Sobre = cur_Datos.Fields.Item("Cantidad_Sobre").Value.ToString

    '                iMonto_Base = cur_Datos.Fields.Item("Monto_Base").Value.ToString
    '                iMonto_Impuesto = cur_Datos.Fields.Item("Monto_Impuesto").Value.ToString
    '                iTotal_Costo = cur_Datos.Fields.Item("Total_Costo").Value.ToString

    '                rstCurrenDoc = cur_Datos.NextRecordset
    '                rstCurrenArt = cur_Datos.NextRecordset

    '                dtControl_Doc.Clear()
    '                daControl_Doc.Fill(dtControl_Doc, rstCurrenDoc)
    '                dvControl_Doc = dtControl_Doc.DefaultView
    '                dtGrigView_Doc.DataSource = dvControl_Doc


    '                dtControl_Art.Clear()
    '                daControl_Art.Fill(dtControl_Art, rstCurrenArt)
    '                dvControl_Art = dtControl_Art.DefaultView
    '                dtGrigView_Art.DataSource = dvControl_Art

    '                flat = True
    '            Else
    '                iCliente = cur_Datos.Fields.Item("Razon_Social").Value.ToString
    '                iNroRuc = cur_Datos.Fields.Item("Nu_Docu_Suna").Value.ToString
    '                iFecha_Guia = cur_Datos.Fields.Item("FECHA_GUIA").Value.ToString
    '                iFecha_Cargo = cur_Datos.Fields.Item("Fecha_Cargos").Value.ToString
    '                iOrigen = cur_Datos.Fields.Item("Origen").Value.ToString
    '                iDestino = cur_Datos.Fields.Item("Destino").Value.ToString
    '                iEstado = cur_Datos.Fields.Item("Estado_Registro").Value.ToString

    '                iPrecio_Peso = cur_Datos.Fields.Item("Precio_Peso").Value.ToString
    '                iPrecio_Vol = cur_Datos.Fields.Item("Precio_Vol").Value.ToString
    '                iPrecio_Sobre = cur_Datos.Fields.Item("Precio_Sobre").Value.ToString

    '                iTotal_Peso = cur_Datos.Fields.Item("Total_Peso").Value.ToString
    '                iTotal_Vol = cur_Datos.Fields.Item("Total_Vol").Value.ToString
    '                'iTotal_Sobre = cur_Datos.Fields.Item("Total_Sobre").Value.ToString

    '                iCantidad_Peso = cur_Datos.Fields.Item("Cantidad_Peso").Value.ToString
    '                iCantidad_Vol = cur_Datos.Fields.Item("Cantidad_Vol").Value.ToString
    '                iCantidad_Sobre = cur_Datos.Fields.Item("Cantidad_Sobre").Value.ToString

    '                iMonto_Base = cur_Datos.Fields.Item("Monto_Base").Value.ToString
    '                iMonto_Impuesto = cur_Datos.Fields.Item("Monto_Impuesto").Value.ToString
    '                iTotal_Costo = cur_Datos.Fields.Item("Total_Costo").Value.ToString

    '                rstCurrenDoc = cur_Datos.NextRecordset
    '                rstCurrenArt = cur_Datos.NextRecordset

    '                dtControl_Doc.Clear()
    '                daControl_Doc.Fill(dtControl_Doc, rstCurrenDoc)
    '                dvControl_Doc = dtControl_Doc.DefaultView
    '                dtGrigView_Doc.DataSource = dvControl_Doc


    '                dtControl_Art.Clear()
    '                daControl_Art.Fill(dtControl_Art, rstCurrenArt)
    '                dvControl_Art = dtControl_Art.DefaultView

    '                dtGrigView_Art.DataSource = dvControl_Art


    '                flat = True
    '            End If
    '        End If
    '    Catch ex As Exception
    '        flat = False
    '        curr_error = cur_Datos.NextRecordset
    '        If curr_error.EOF = False And curr_error.BOF = False Then
    '            MsgBox(curr_error.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        Else
    '            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        End If
    '    End Try
    '    Return flat
    'End Function
    Public Function fnRECEPCION_GUIAS_CARGO(ByVal dtGrigView_Doc As DataGridView, ByVal dtGrigView_Art As DataGridView) As Boolean
        Dim flat As Boolean = False
        'Try
        Dim db_bd As New BaseDatos
        Dim lds_tmp As New DataSet
        'conecta con la Bd
        db_bd.Conectar()
        '-- Invocando  al procedimiento almacenado 
        db_bd.CrearComando("PKG_IVOGUIAS_ENVIO.SP_RECEPCION_GUIAS_CARGO", CommandType.StoredProcedure)
        'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
        db_bd.AsignarParametro("iNro_Guia", iNro_Guia, OracleClient.OracleType.VarChar)
        db_bd.AsignarParametro("iIdestado_Registro", iIdestado_Registro, OracleClient.OracleType.Int32)
        db_bd.AsignarParametro("fecha_Cargo", fecha_Cargo, OracleClient.OracleType.VarChar)
        db_bd.AsignarParametro("iIdusuario_Personalmod", dtoUSUARIOS.IdLogin, OracleClient.OracleType.Int32)
        db_bd.AsignarParametro("iIdrol_Usuariomod", dtoUSUARIOS.IdRol, OracleClient.OracleType.Int32)
        db_bd.AsignarParametro("iIp", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
        'Variables de salidas 
        db_bd.AsignarParametro("cur_Datos", OracleClient.OracleType.Cursor)
        db_bd.AsignarParametro("cur_Documentos", OracleClient.OracleType.Cursor)
        db_bd.AsignarParametro("cur_Articulos", OracleClient.OracleType.Cursor)
        db_bd.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
        'Desconectar 
        db_bd.Desconectar()
        '
        lds_tmp = db_bd.EjecutarDataSet
        '
        dt_cur_Datos = lds_tmp.Tables(0)
        '
        iOpcion = 0
        If lds_tmp.Tables(0).Rows.Count > 0 Then
            If Int(lds_tmp.Tables(0).Rows(0).Item(0).ToString) = 0 Then
                MsgBox(lds_tmp.Tables(0).Rows(0).Item(1).ToString, MsgBoxStyle.Information, "Seguridad Sistema")
                iCliente = ""
                'iNroRuc = cur_Datos.Fields.Item(3).Value.ToString
                iFecha_Guia = ""
                iFecha_Cargo = ""
                iOrigen = ""
                iDestino = ""
                iEstado = ""
                iTotal_Costo = "0.00"

            ElseIf Int(lds_tmp.Tables(0).Rows(0).Item(0).ToString) = 1 Then
                MsgBox(lds_tmp.Tables(0).Rows(0).Item(1).ToString, MsgBoxStyle.Information, "Seguridad Sistema")
                iCliente = lds_tmp.Tables(0).Rows(0).Item("Razon_Social").ToString
                iNroRuc = lds_tmp.Tables(0).Rows(0).Item("Nu_Docu_Suna").ToString
                '
                iFecha_Guia = lds_tmp.Tables(0).Rows(0).Item("FECHA_GUIA").ToString
                iFecha_Cargo = lds_tmp.Tables(0).Rows(0).Item("Fecha_Cargos").ToString
                iOrigen = lds_tmp.Tables(0).Rows(0).Item("Origen").ToString
                iDestino = lds_tmp.Tables(0).Rows(0).Item("Destino").ToString
                iEstado = lds_tmp.Tables(0).Rows(0).Item("Estado_Registro").ToString
                '
                iPrecio_Peso = lds_tmp.Tables(0).Rows(0).Item("Precio_Peso").ToString
                iPrecio_Vol = lds_tmp.Tables(0).Rows(0).Item("Precio_Vol").ToString
                iPrecio_Sobre = lds_tmp.Tables(0).Rows(0).Item("Precio_Sobre").ToString

                iTotal_Peso = lds_tmp.Tables(0).Rows(0).Item("Total_Peso").ToString
                iTotal_Vol = lds_tmp.Tables(0).Rows(0).Item("Total_Vol").ToString
                'iTotal_Sobre = cur_Datos.Fields.Item("Total_Sobre").Value.ToString

                iCantidad_Peso = lds_tmp.Tables(0).Rows(0).Item("Cantidad_Peso").ToString
                iCantidad_Vol = lds_tmp.Tables(0).Rows(0).Item("Cantidad_Vol").ToString
                iCantidad_Sobre = lds_tmp.Tables(0).Rows(0).Item("Cantidad_Sobre").ToString

                iMonto_Base = lds_tmp.Tables(0).Rows(0).Item("Monto_Base").ToString
                iMonto_Impuesto = lds_tmp.Tables(0).Rows(0).Item("Monto_Impuesto").ToString
                iTotal_Costo = lds_tmp.Tables(0).Rows(0).Item("Total_Costo").ToString
                '
                dtControl_Doc = lds_tmp.Tables(1)  'dt_rstCurrenDoc = lds_tmp.Tables(1)
                dtControl_Art = lds_tmp.Tables(2)  'dt_rstCurrenArt = lds_tmp.Tables(2)
                '
                dtControl_Doc.Clear()
                'daControl_Doc.Fill(dtControl_Doc, rstCurrenDoc)
                dvControl_Doc = dtControl_Doc.DefaultView
                dtGrigView_Doc.DataSource = dvControl_Doc
                '
                'dtControl_Art.Clear()
                'daControl_Art.Fill(dtControl_Art, rstCurrenArt)
                '
                dvControl_Art = dtControl_Art.DefaultView
                dtGrigView_Art.DataSource = dvControl_Art

                flat = True
            Else
                iOpcion = 1
                iCliente = lds_tmp.Tables(0).Rows(0).Item("Razon_Social").ToString
                iNroRuc = lds_tmp.Tables(0).Rows(0).Item("Nu_Docu_Suna").ToString
                iFecha_Guia = lds_tmp.Tables(0).Rows(0).Item("FECHA_GUIA").ToString
                iFecha_Cargo = lds_tmp.Tables(0).Rows(0).Item("Fecha_Cargos").ToString
                iOrigen = lds_tmp.Tables(0).Rows(0).Item("Origen").ToString
                iDestino = lds_tmp.Tables(0).Rows(0).Item("Destino").ToString
                iEstado = lds_tmp.Tables(0).Rows(0).Item("Estado_Registro").ToString
                '
                iPrecio_Peso = lds_tmp.Tables(0).Rows(0).Item("Precio_Peso").ToString
                iPrecio_Vol = lds_tmp.Tables(0).Rows(0).Item("Precio_Vol").ToString
                iPrecio_Sobre = lds_tmp.Tables(0).Rows(0).Item("Precio_Sobre").ToString
                '
                iTotal_Peso = lds_tmp.Tables(0).Rows(0).Item("Total_Peso").ToString
                iTotal_Vol = lds_tmp.Tables(0).Rows(0).Item("Total_Vol").ToString

                iCantidad_Peso = lds_tmp.Tables(0).Rows(0).Item("Cantidad_Peso").ToString
                iCantidad_Vol = lds_tmp.Tables(0).Rows(0).Item("Cantidad_Vol").ToString
                iCantidad_Sobre = lds_tmp.Tables(0).Rows(0).Item("Cantidad_Sobre").ToString

                iMonto_Base = lds_tmp.Tables(0).Rows(0).Item("Monto_Base").ToString
                iMonto_Impuesto = lds_tmp.Tables(0).Rows(0).Item("Monto_Impuesto").ToString
                iTotal_Costo = lds_tmp.Tables(0).Rows(0).Item("Total_Costo").ToString
                '
                dtControl_Doc = lds_tmp.Tables(1)  'dt_rstCurrenDoc = lds_tmp.Tables(1)
                dtControl_Art = lds_tmp.Tables(2)  'dt_rstCurrenArt = lds_tmp.Tables(2)
                '
                'dtControl_Doc.Clear()
                'daControl_Doc.Fill(dtControl_Doc, rstCurrenDoc)
                dvControl_Doc = dtControl_Doc.DefaultView
                dtGrigView_Doc.DataSource = dvControl_Doc
                'Verificar'

                'dtControl_Art.Clear()
                'daControl_Art.Fill(dtControl_Art, rstCurrenArt)
                dvControl_Art = dt_rstCurrenArt.DefaultView
                dtGrigView_Art.DataSource = dvControl_Art
                '
                flat = True
                Return flat
            End If
        End If
        'Catch ex As Exception
        '    flat = False
        '    'curr_error = cur_Datos.NextRecordset
        '    'If curr_error.EOF = False And curr_error.BOF = False Then
        '    '    MsgBox(curr_error.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        '    'Else
        '    '    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        '    'End If
        'End Try
        Return flat
    End Function
    'Public Function fnTIPO_COMPROBANTE_2009() As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOUUTILS.SP_TIPO_COMPROBANTE", 2}
    '        objLOG.fnLog("[dtoRecepcionGuias.fnTIPO_COMPROBANTE] " & fnLoagObj(varSP_OBJECT))
    '        cur_Tipo_Documento = Nothing
    '        cur_Tipo_Documento = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If cur_Tipo_Documento.EOF = False And cur_Tipo_Documento.BOF = False Then
    '            flat = True
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    Public Function fnTIPO_COMPROBANTE() As Boolean
        Dim flat As Boolean = False
        Try
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOUUTILS.SP_TIPO_COMPROBANTE", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            'Sin Parametros de Ingresos  
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            '
            If ldt_tmp.Rows.Count > 0 Then
                dt_cur_Tipo_Documento = ldt_tmp
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
        Return flat
    End Function

#End Region
End Class
