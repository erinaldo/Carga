Imports INTEGRACION_EN
Imports AccesoDatos
Public Class Cls_TarifaPublica_AD
    Public Sub F_InsTarifaArticulo_AD(ByVal tarifaAticulo As Cls_TarifaArticulo)
        Try
            Dim db_bd As New BaseDatos
            db_bd.Conectar()
            db_bd.CrearComando("PKG_TARIFA_PUBLICA.SP_INSERTAR_ARTICULO", CommandType.StoredProcedure)
            db_bd.AsignarParametro("v_idtarifa_publica", tarifaAticulo.tarifaPublica.idTarifaPublica, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idTarifa_Articulo", tarifaAticulo.idTarifaArticulo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_tipoTarifa", tarifaAticulo.idTipoTarifa, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_procesos", tarifaAticulo.idProcesos, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idArticulo", tarifaAticulo.idArticulo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_importe", tarifaAticulo.importe, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("v_Origen", tarifaAticulo.tarifaPublica.UnidadOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Destino", tarifaAticulo.tarifaPublica.UnidadDestino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Usuario", tarifaAticulo.idUsuario, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_ip", tarifaAticulo.ip, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_fechaActivacion", tarifaAticulo.fechaActivacion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_tipo_entrega", tarifaAticulo.TipoEntrega, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("cur_tarifaArticulo", OracleClient.OracleType.Cursor)

            db_bd.Desconectar()
            Dim ds As New DataSet
            ds = db_bd.EjecutarDataSet()

            If (ds.Tables(0).Rows.Count > 0) Then
                tarifaAticulo.tarifaPublica.idTarifaPublica = ds.Tables(0).Rows(0).Item(0)
            End If

        Catch ex As Exception
            Throw New Excepcion(ex.Message)
        End Try
    End Sub
    Public Function GrabarSolicitud(ByVal tarifaCargo As Cls_TarifaCargo) As String
        Dim lStr_Mensaje As String = ""
        Try
            Dim db_bd As New BaseDatos
            db_bd.Conectar()
            db_bd.CrearComando("PKG_TARIFA_PUBLICA.sp_grabar_solicitud", CommandType.StoredProcedure)
            db_bd.AsignarParametro("v_idtarifa_publica", tarifaCargo.tarifaPublica.idTarifaPublica, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idTarifa_Cargo", tarifaCargo.idTarifaCargo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_tipoTarifa", tarifaCargo.idTipoTarifa, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_procesos", tarifaCargo.idProcesos, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_base", tarifaCargo.Base, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("v_peso", tarifaCargo.Peso, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("v_volumen", tarifaCargo.Volumen, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("v_sobre", tarifaCargo.Sobre, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("v_fleteMinimo", tarifaCargo.FleteMinimoPeso, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("v_PesoMin", tarifaCargo.PesoMinimo, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("v_fleteMinimoVol", tarifaCargo.FleteMinimoVol, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("v_VolMin", tarifaCargo.VolumenMinimo, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("v_tipoVisibilidad", tarifaCargo.tipoVisibilidad, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Origen", tarifaCargo.tarifaPublica.UnidadOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Destino", tarifaCargo.tarifaPublica.UnidadDestino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Usuario", tarifaCargo.idUsuario, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_ip", tarifaCargo.ip, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_fechaActivacion", tarifaCargo.fechaActivacion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_ciudad", tarifaCargo.Ciudad, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("cur_tarifaPublica", OracleClient.OracleType.Cursor)

            db_bd.Desconectar()
            db_bd.EjecutarDataSet()

        Catch ex As Exception
            lStr_Mensaje = (ex.Message)
            Return lStr_Mensaje
        End Try
        Return lStr_Mensaje

    End Function
    Public Function BuscarTarifarioPublico_AD(ByVal iOrigen As String, ByVal iDestino As String, ByVal iVisibilidad As String, _
                                              ByVal iiProducto As String, ByVal tipoTarifa As String, TipoEntrega As Integer, ciudad As Integer) As DataSet
        Try
            Dim db_bd As New BaseDatos
            db_bd.Conectar()
            db_bd.CrearComando("PKG_TARIFA_PUBLICA.SP_Buscar", CommandType.StoredProcedure)
            db_bd.AsignarParametro("v_idOrigen", iOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idDestino", iDestino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idProducto", iiProducto, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_tipoVisibilidad", iVisibilidad, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idTipo_tarifa", tipoTarifa, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_tipo_entrega", TipoEntrega, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("cur_tarifas", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_tarifasArticulos", OracleClient.OracleType.Cursor)

            db_bd.Desconectar()
            Dim dsConsulta As New DataSet
            dsConsulta = db_bd.EjecutarDataSet()

            Return dsConsulta
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Sub Anular_Tarifa_AD(ByVal idTarifa_cargo As Long, ByVal idUsuario As Integer, ByVal ip As String)
        Try
            Dim db_bd As New BaseDatos
            db_bd.Conectar()
            db_bd.CrearComando("PKG_TARIFA_PUBLICA.SP_ANULAR_TARIFA", CommandType.StoredProcedure)
            db_bd.AsignarParametro("v_idTarifa_cargo", idTarifa_cargo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idUsuario", idUsuario, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_ip", ip, OracleClient.OracleType.VarChar)

            db_bd.Desconectar()
            db_bd.EjecutarDataSet()

        Catch ex As Exception
            Throw New Excepcion(ex.Message)
        End Try
    End Sub
    Public Sub Anular_TarifaArticulo_AD(ByVal idTarifa_Articulo As Long, ByVal idUsuario As Integer, ByVal ip As String)
        Try
            Dim db_bd As New BaseDatos
            db_bd.Conectar()
            db_bd.CrearComando("PKG_TARIFA_PUBLICA.SP_ANULAR_TARIFA_ARTICULO", CommandType.StoredProcedure)
            db_bd.AsignarParametro("v_idtarifa_articulo", idTarifa_Articulo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idUsuario", idUsuario, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_ip", ip, OracleClient.OracleType.VarChar)

            db_bd.Desconectar()
            db_bd.EjecutarDataSet()

        Catch ex As Exception
            Throw New Excepcion(ex.Message)
        End Try
    End Sub

    Public Function F_InsTarifarioPublico_AD(ByVal tarifaCargo As Cls_TarifaCargo) As String
        Dim lStr_Mensaje As String = ""
        Try
            Dim db_bd As New BaseDatos
            db_bd.Conectar()
            db_bd.CrearComando("PKG_TARIFA_PUBLICA.SP_INSERTAR", CommandType.StoredProcedure)
            db_bd.AsignarParametro("v_idtarifa_publica", tarifaCargo.tarifaPublica.idTarifaPublica, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_idTarifa_Cargo", tarifaCargo.idTarifaCargo, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_tipoTarifa", tarifaCargo.idTipoTarifa, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_procesos", tarifaCargo.idProcesos, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_base", tarifaCargo.Base, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("v_peso", tarifaCargo.Peso, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("v_volumen", tarifaCargo.Volumen, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("v_sobre", tarifaCargo.Sobre, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("v_fleteMinimo", tarifaCargo.FleteMinimoPeso, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("v_PesoMin", tarifaCargo.PesoMinimo, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("v_fleteMinimoVol", tarifaCargo.FleteMinimoVol, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("v_VolMin", tarifaCargo.VolumenMinimo, OracleClient.OracleType.Number)
            db_bd.AsignarParametro("v_tipoVisibilidad", tarifaCargo.tipoVisibilidad, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Origen", tarifaCargo.tarifaPublica.UnidadOrigen, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Destino", tarifaCargo.tarifaPublica.UnidadDestino, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("v_Usuario", tarifaCargo.idUsuario, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_ip", tarifaCargo.ip, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("v_fechaActivacion", tarifaCargo.fechaActivacion, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_ciudad", tarifaCargo.Ciudad, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("cur_tarifaPublica", OracleClient.OracleType.Cursor)

            db_bd.Desconectar()
            db_bd.EjecutarDataSet()

        Catch ex As Exception
            lStr_Mensaje = (ex.Message)
            Return lStr_Mensaje
        End Try
        Return lStr_Mensaje

    End Function

    Function GrabarSolicitud(id As Integer, oficina As Integer, ciudad As Integer, observacion As String, _
                             usuario As Integer, ip As String) As Integer
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_TARIFA_PUBLICA.sp_grabar_solicitud", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_oficina", oficina, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_id", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0).Rows(0).Item("id").ToString

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Sub GrabarSolicitudDetalle(id As Integer, id_cab As Integer, origen As Integer, destino As Integer, producto As Integer, tipo_tarifa As Integer, _
                                    tipo_visibilidad As Integer, peso As Double, volumen As Double, sobre As Double, base As Double, _
                                    peso_minimo As Double, flete_minimo As Double, volumen_minimo As Double, flete_volumen_minimo As Double, _
                                    usuario As Integer, ip As String, estado As Integer)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_TARIFA_PUBLICA.sp_grabar_solicitud_detalle", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_id_cab", id_cab, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_producto", producto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_tarifa", tipo_tarifa, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_visibilidad", tipo_visibilidad, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_peso", peso, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_volumen", volumen, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_sobre", sobre, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_base", base, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_peso_minimo", peso_minimo, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_flete_minimo", flete_minimo, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_volumen_minimo", volumen_minimo, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_flete_volumen_minimo", flete_volumen_minimo, OracleClient.OracleType.Number)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1).ToString)
                End If
            End If

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Function ListarSolicitud(inicio As String, fin As String, ciudad As Integer, estado As Integer) As DataTable
        Try
            Dim db_bd As New BaseDatos
            db_bd.Conectar()
            db_bd.CrearComando("PKG_TARIFA_PUBLICA.sp_listar_solicitud_tarifa", CommandType.StoredProcedure)
            db_bd.AsignarParametro("vi_inicio", inicio, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("vi_fin", fin, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)

            db_bd.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            db_bd.Desconectar()
            Dim ds As New DataSet
            ds = db_bd.EjecutarDataSet()
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Function ListarSolicitud(id As Integer) As DataTable
        Try
            Dim db_bd As New BaseDatos
            db_bd.Conectar()
            db_bd.CrearComando("PKG_TARIFA_PUBLICA.sp_listar_solicitud_tarifa", CommandType.StoredProcedure)
            db_bd.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)

            db_bd.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("co_error", OracleClient.OracleType.Cursor)

            db_bd.Desconectar()
            Dim ds As New DataSet
            ds = db_bd.EjecutarDataSet()
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(1).Rows(0).Item(1).ToString)
                End If
            End If
            Return ds.Tables(0)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Sub AnularSolicitud(id As Integer, usuario As Integer, ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_TARIFA_PUBLICA.sp_anular_solicitud", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1).ToString)
                End If
            End If

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Function ExisteTarifa(ciudad As Integer, origen As Integer, destino As Integer, producto As Integer, tipo_tarifa As Integer, tipo_visibilidad As Integer) As Boolean
        Dim flag As Integer = 0
        Try
            Dim db_bd As New BaseDatos
            Dim ls_mensaje As String
            '
            'conecta con la Bd
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            ls_mensaje = "select PKG_TARIFA_PUBLICA.sf_get_existe_tarifa(" & ciudad & "," & origen & "," & destino & "," & producto & "," & tipo_tarifa & "," & _
                                                                         tipo_visibilidad & ") from dual"
            db_bd.CrearComando(ls_mensaje, CommandType.Text)
            '
            flag = db_bd.EjecutarEscalar()

            db_bd.Desconectar()
            ' 
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try

        If flag = 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub AprobarSolicitud(id As Integer, observacion As String, estado As Integer, usuario As Integer, ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_TARIFA_PUBLICA.sp_aprobar_solicitud", CommandType.StoredProcedure)
            db.AsignarParametro("ni_id", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_observacion", observacion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_estado", estado, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1).ToString)
                End If
            End If
            'Return ds.Tables(0).Rows(0).Item("id").ToString

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try

    End Sub

    Sub GrabarTarifa(ciudad As Integer, origen As Integer, destino As Integer, producto As Integer, tipo_tarifa As Integer, tipo_visibilidad As Integer, _
                     peso As Double, volumen As Double, sobre As Double, base As Double, peso_minimo As Double, flete_minimo As Double, _
                     volumen_minimo As Double, flete_minimo_volumen As Double, _
                     usuario As Integer, ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_TARIFA_PUBLICA.sp_grabar_tarifa", CommandType.StoredProcedure)
            db.AsignarParametro("ni_ciudad", ciudad, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_origen", origen, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_destino", destino, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_producto", producto, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_tarifa", tipo_tarifa, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_tipo_visibilidad", tipo_visibilidad, OracleClient.OracleType.Int32)

            db.AsignarParametro("ni_peso", peso, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_volumen", volumen, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_sobre", sobre, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_base", base, OracleClient.OracleType.Number)

            db.AsignarParametro("ni_peso_minimo", peso_minimo, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_flete_minimo", flete_minimo, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_volumen_minimo", volumen_minimo, OracleClient.OracleType.Number)
            db.AsignarParametro("ni_flete_minimo_volumen", flete_minimo_volumen, OracleClient.OracleType.Number)

            db.AsignarParametro("ni_usuario", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)

            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                    Throw New Exception(ds.Tables(0).Rows(0).Item(1).ToString)
                End If
            End If
            'Return ds.Tables(0).Rows(0).Item("id").ToString

        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub
End Class
