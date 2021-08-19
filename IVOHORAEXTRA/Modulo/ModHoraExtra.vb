Imports System.Data.OleDb
Imports System.IO
Imports Renci.SshNet
Imports Renci.SshNet.Sftp
Imports System.Linq
Imports INTEGRACION_LN
Imports System.Data.SqlClient

Module ModHoraExtra
#Region "Conexion"

    Dim host As String = "192.168.50.2"
    Dim username As String = "root"
    Dim password As String = "tepsajp"
    Dim ruta As String = "c:\backup"
    Dim RutaPlanilla As String = "/elpino/personal"
    Dim RutaContabilidad As String = "/elpino/conta"
    Dim conexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties='dBASE 5.0';Data Source=" & ruta
    Dim strArchivo() As String = {"PE092019.DBF", "PE602019.DBF"}
    'Dim strArchivo() As String = {"unix1.dbf", "unix2.dbf"}
    Dim strArchivoTitan() As String = {"unix1.dbf", "unix2.dbf"}
    'Dim strArchivoUnix() As String = {"unix1.dbf", "unix2.dbf"}
    Dim strArchivoUnix() As String = {"PE092019.DBF", "PE602019.DBF"}
#End Region

#Region "Importar desde Unix"
    Sub ImportarData(Optional ByVal archivo() As String = Nothing)
        Dim sftp As New SftpClient(host, username, password)
        sftp.Connect()

        If Not Directory.Exists(ruta) Then
            Directory.CreateDirectory(ruta)
        End If

        If IsNothing(archivo) Then
            For Each ftpfile As Renci.SshNet.Sftp.SftpFile In sftp.ListDirectory(RutaPlanilla)
                If ftpfile.IsRegularFile Then
                    If GrabarDBF(ftpfile.Name.ToUpper) Then
                        Dim fs As New FileStream(ruta & "\" & ftpfile.Name, FileMode.Create)
                        sftp.DownloadFile(ftpfile.FullName, fs)
                        fs.Close()
                    End If
                End If
            Next
            For Each ftpfile As Renci.SshNet.Sftp.SftpFile In sftp.ListDirectory(RutaContabilidad)
                If ftpfile.IsRegularFile Then
                    If GrabarDBF(ftpfile.Name.ToUpper) Then
                        Dim fs As New FileStream(ruta & "\" & ftpfile.Name, FileMode.Create)
                        sftp.DownloadFile(ftpfile.FullName, fs)
                        fs.Close()
                    End If
                End If
            Next
        Else
            For Each ftpfile As Renci.SshNet.Sftp.SftpFile In sftp.ListDirectory(RutaPlanilla)
                If ftpfile.IsRegularFile Then
                    For i As Integer = 0 To archivo.Length - 1
                        If ftpfile.Name.ToUpper = archivo(i).ToUpper Then
                            Dim fs As New FileStream(ruta & "\" & ftpfile.Name, FileMode.Create)
                            sftp.DownloadFile(ftpfile.FullName, fs)
                            fs.Close()
                        End If
                    Next
                End If
            Next
        End If
        sftp.Disconnect()
    End Sub
    Function GrabarDBF(ByVal tabla As String) As Boolean
        If tabla.Trim.ToUpper = "CTM15.DBF" Or tabla.Trim.ToUpper = "PEMAST01.DBF" Or tabla.Trim.ToUpper = "PEMAST02.DBF" Or tabla.Trim.ToUpper = "PERS_DSC.DBF" Or _
        tabla.Trim.ToUpper = "PEHORA38.DBF" Or tabla.Trim.ToUpper = "PEFERI05.DBF" Or tabla.Trim.ToUpper = "PERCAP17.DBF" Or tabla.Trim.ToUpper = "PE092019.DBF" Or _
        tabla.Trim.ToUpper = "PECONC07.DBF" Or tabla.Trim.ToUpper = "PEVACA23.DBF" Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "Exportar a Unix"
    Sub ExportarData()
        Try
            'ImportarData(strArchivo) 'importar tabla de asistencia
            Dim blnEfectivo As Boolean = False
            Dim obj As New Cls_HoraExtra_LN
            Dim strCodigo As String = ""
            Dim strFechaServidor As String = Format(FechaServidor, "Short Date")
            Dim strPeriodoActual As String = PeriodoActual()
            'strPeriodoActual = "20191112"
            Dim intRegistro As Integer = 0
            Dim dt As DataTable
            dt = obj.ListarCompensado(1) 'bolsa de he compensadas en efectivo
            If dt.Rows.Count > 0 Then
                intRegistro += 1
                Dim dtEfectivo As New DataTable
                Dim h1 As Double, h2 As Double, h3 As Double, h4 As Double
                Dim he1 As Double, he2 As Double, he3 As Double, he4 As Double
                Dim strPeriodo As String = "", strFecha As String = ""
                CrearColumna(dtEfectivo)
                For Each row As DataRow In dt.Rows
                    Dim cod As String = row("codigo")
                    If row("periodo") = strPeriodoActual Then
                        'graba he compensadas en efectivo en archivo importado
                        If (strCodigo.Length > 0 And strCodigo <> row("codigo")) Or (strPeriodo.Length > 0 And strPeriodo <> row("periodo")) Or _
                            (strFecha.Length > 0 And strFecha <> Format(row("fecha"), "dd/MM/yyyy")) Then
                            ActualizarColumna(dtEfectivo, strPeriodo, strCodigo, strFecha, he1, he2, he3, h4)
                            GrabarHoraExtraEfectivo(dtEfectivo)
                            he1 = 0 : he2 = 0 : he3 = 0 : he4 = 0
                            dtEfectivo.Rows.Clear()
                        End If
                        'totaliza he compensadas en efectivo
                        TotalizarHoraExtraEfectivo(row("tipo_dia"), row("horas"), h1, h2, h3, h4, row("obrero"))
                        he1 += h1
                        he2 += h2
                        he3 += h3
                        he4 += h4
                        strPeriodo = row("periodo")
                        strCodigo = row("codigo")
                        strFecha = row("fecha")
                    End If
                Next
                If strPeriodo = strPeriodoActual Then
                    ActualizarColumna(dtEfectivo, strPeriodo, strCodigo, strFecha, he1, he2, he3, h4)
                    GrabarHoraExtraEfectivo(dtEfectivo)
                    blnEfectivo = True
                End If
            End If

            Dim blnDescanso As Boolean = False
            dt = obj.ListarCompensado(2) 'bolsa de he compensadas con descanso fisico
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    'graba he compensadas con descanso fisico en archivo importado
                    GrabarHoraExtraCompensado(row("periodo"), row("codigo"), row("horas"), row("fecha"))
                Next
                blnDescanso = True
            End If

            If blnEfectivo Or blnDescanso Then
                'If File.Exists(ruta & "\" & strArchivoTitan(0)) Then 'elimina archivo titan
                '    File.Delete(ruta & "\" & strArchivoTitan(0))
                'End If
                'FileSystem.Rename(ruta & "\" & strArchivo(0), ruta & "\" & strArchivoTitan(0)) 'renombra archivo importado a archivo titan

                'Dim sftp As New SftpClient(host, username, password) 'coneccion a servidor sftp
                'sftp.Connect()

                'Dim strNuevo As String = strArchivoUnix(0).Trim.Substring(0, 5) & "old.dbf"
                'Try
                '    sftp.DeleteFile(RutaPlanilla & "/" & strNuevo) 'elimina archivo old
                'Catch ex As Exception
                'End Try
                'sftp.RenameFile(RutaPlanilla & "/" & strArchivoUnix(0), RutaPlanilla & "/" & strNuevo) 'renombra archivo produccion a old

                'Dim fs As System.IO.Stream = System.IO.File.OpenRead(ruta & "\" & strArchivoTitan(0)) 'abre archivo titan
                'sftp.UploadFile(fs, RutaPlanilla & "/" & strArchivoTitan(0), True) 'sube archivo titan

                'fs.Close()
                'sftp.Disconnect()
                'sftp.Dispose()

                If blnEfectivo Then
                    Cls_HoraExtra_LN.ActualizarCompensado(1, strPeriodoActual)
                End If
            End If

            If blnDescanso Then
                'If File.Exists(ruta & "\" & strArchivoTitan(1)) Then 'elimina archivo titan
                '    File.Delete(ruta & "\" & strArchivoTitan(1))
                'End If
                'FileSystem.Rename(ruta & "\" & strArchivo(1), ruta & "\" & strArchivoTitan(1)) 'renombra archivo importado a archivo titan

                'Dim sftp As New SftpClient(host, username, password) 'coneccion a servidor sftp
                'sftp.Connect()

                'Dim strNuevo As String = strArchivoUnix(1).Trim.Substring(0, 5) & "old.dbf"
                'Try
                '    sftp.DeleteFile(RutaPlanilla & "/" & strNuevo) 'elimina archivo old
                'Catch ex As Exception
                'End Try
                'sftp.RenameFile(RutaPlanilla & "/" & strArchivoUnix(1), RutaPlanilla & "/" & strNuevo) 'renombra archivo produccion a old

                'Dim fs As System.IO.Stream = System.IO.File.OpenRead(ruta & "\" & strArchivoTitan(1)) 'abre archivo titan
                'sftp.UploadFile(fs, RutaPlanilla & "/" & strArchivoTitan(1), True) 'sube archivo titan

                'fs.Close()
                'sftp.Disconnect()
                'sftp.Dispose()

                Cls_HoraExtra_LN.ActualizarCompensado(2, strPeriodoActual)
            End If


            'Renombrar un fichero.
            'sftp.RenameFile("/path/archivo.txt", "/path/archivo_renombrado.txt")

            ' Eliminar un fichero.
            'sftp.DeleteFile("/path/archivo_renombrado.txt")

            'sftp.s()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    Sub CrearColumna(ByRef dt As DataTable)
        Dim col As DataColumn
        col = New DataColumn
        col.ColumnName = "periodo"
        col.DataType = Type.GetType("System.String")
        col.AllowDBNull = True
        dt.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "codigo"
        col.DataType = Type.GetType("System.String")
        col.AllowDBNull = True
        dt.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "fecha"
        col.DataType = Type.GetType("System.String")
        col.AllowDBNull = True
        dt.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "concepto"
        col.DataType = Type.GetType("System.String")
        col.AllowDBNull = True
        dt.Columns.Add(col)

        col = New DataColumn
        col.ColumnName = "cantidad"
        col.DataType = Type.GetType("System.Double")
        col.AllowDBNull = True
        dt.Columns.Add(col)
    End Sub

    Sub ActualizarColumna(ByRef dt As DataTable, ByVal periodo As String, ByVal codigo As String, ByVal fecha As String, ByVal h1 As Double, ByVal h2 As Double, ByVal h3 As Double, ByVal h4 As Double)
        If h1 > 0 Then dt.Rows.Add(periodo, codigo, fecha, "302", h1)
        If h2 > 0 Then dt.Rows.Add(periodo, codigo, fecha, "342", h2)
        If h3 > 0 Then dt.Rows.Add(periodo, codigo, fecha, "304", h3)
        If h4 > 0 Then dt.Rows.Add(periodo, codigo, fecha, "303", h4)
    End Sub
#End Region

#Region "Actualizar en Titan"
    'Sub ActualizarData()
    '    Try
    '        Dim dt As DataTable, dtHorario As DataTable, dtAsistencia As DataTable
    '        Dim obj As New Cls_HoraExtra_LN
    '        Dim intID As Integer, intIDHorario As Integer, intOpcion As Integer
    '        Dim strTipoVia As String, strVia As String, strNumero As String, strInterior As String, strTipoZona As String, strZona As String, strDireccion As String
    '        Dim intRegistro As Integer = 0

    '        Dim strPlanilla As String, strPeriodo As String, strGlosa As String
    '        strPlanilla = PeriodoActual()
    '        'strPeriodo = strPlanilla & strTipoPlanilla
    '        strPeriodo = strPlanilla

    '        Dim strTemp As String
    '        dt = CargarTrabajador()
    '        For Each row As DataRow In dt.Rows
    '            strTipoVia = "" & row("tipo_via")
    '            strVia = "" & row("via")
    '            strNumero = "" & row("numero")
    '            strInterior = "" & row("interior")
    '            strTipoZona = "" & row("tipo_zona")
    '            strZona = "" & row("zona")
    '            strDireccion = ObtieneDireccion(strTipoVia, strVia, strNumero, strInterior, strTipoZona, strZona)
    '            Dim dt2 As DataTable = obj.GrabarTrabajador(row("codigo"), "" & row("nombres"), row("cargo"), row("centro_costo"), row("area"), row("remuneracion"), row("horario"), row("situacion"), row("cap"), _
    '                                                        "" & row("fecha_ingreso"), _
    '                                                        strTipoVia, strVia, strNumero, strInterior, strTipoZona, strZona, strDireccion, "" & row("numero_documento"))
    '            intID = dt2.Rows(0).Item("id")
    '            If intID > 0 Then
    '                intOpcion = dt2.Rows(0).Item("opcion")
    '                If intOpcion = 1 Then 'graba horario si el trabajador es nuevo
    '                    dtHorario = CargarHorario(row("horario"))
    '                    For Each rowh As DataRow In dtHorario.Rows
    '                        intIDHorario = obj.GrabarHorario(rowh("codigo"),
    '                        "" & rowh("inilun"), "" & rowh("finlun"), IIf(rowh("lun"), 0, 1), "" & rowh("inimar"), "" & rowh("finmar"), IIf(rowh("mar"), 0, 1), _
    '                        "" & rowh("inimie"), "" & rowh("finmie"), IIf(rowh("mie"), 0, 1), "" & rowh("inijue"), "" & rowh("finjue"), IIf(rowh("jue"), 0, 1), "" & rowh("inivie"), "" & rowh("finvie"), IIf(rowh("vie"), 0, 1), _
    '                        "" & rowh("inisab"), "" & rowh("finsab"), IIf(rowh("sab"), 0, 1), "" & rowh("inidom"), "" & rowh("findom"), IIf(rowh("dom"), 0, 1))
    '                        obj.GrabarTrabajadorHorario(intID, intIDHorario)
    '                    Next
    '                End If
    '                'asistencia
    '                Dim intRepetido As Integer = 0
    '                Dim strFechaFin As String = Format(FechaServidor, "Short Date")
    '                strFechaFin = DateAdd(DateInterval.Day, -1, CDate(strFechaFin))
    '                'dtAsistencia = GetMarcacion(row("codigo"), "26/10/2018", strFecha)
    '                Dim strFechaInicio As String = PeriodoActual(1)
    '                dtAsistencia = GetMarcacion(row("codigo"), strFechaInicio, strFechaFin)
    '                If row("codigo") = "12532" Then
    '                    Dim a As Integer = 1
    '                End If
    '                For Each rowi As DataRow In dtAsistencia.Rows
    '                    intRegistro += 1
    '                    strGlosa = "Asist. Normal " & rowi("hora1") & "-" & rowi("hora2")
    '                    If rowi("hora1") = rowi("hora2") Then
    '                        intRepetido = 1
    '                    Else
    '                        intRepetido = 0
    '                    End If
    '                    obj.GrabarAsistencia(strPeriodo, rowi("fecha"), rowi("codigo"), "300", 1, strGlosa, intRepetido)
    '                Next
    '                'dtAsistencia = CargarAsistencia("26/07/2018", row("codigo"))
    '                'For Each rowi As DataRow In dtAsistencia.Rows
    '                '    intRegistro += 1
    '                '    obj.GrabarAsistencia(rowi("planilla"), rowi("fecha"), rowi("codigo"), rowi("concepto"), rowi("valor"), IIf(IsDBNull(rowi("glosa")), "", rowi("glosa")), intRegistro)
    '                'Next
    '            End If
    '            strTemp = row("codigo")
    '        Next
    '        obj.EliminarAsistencia()

    '        'feriado
    '        'dt = CargarFeriado()
    '        'For Each row As DataRow In dt.Rows
    '        'obj.GrabarFeriado(row("fecha"), row("descripcion"), row("estado"))
    '        'Next

    '        'vacaciones
    '        intRegistro = 0
    '        Dim strFechaServidor As String = Format(FechaServidor, "Short Date")
    '        strPlanilla = CDate(strFechaServidor).Year & CDate(strFechaServidor).Month.ToString.PadLeft(2, "0")
    '        dt = CargarVacaciones(strPlanilla)
    '        For Each row As DataRow In dt.Rows
    '            intRegistro += 1
    '            obj.GrabarVacaciones(row("codigo"), row("inicio"), row("fin"), row("periodo"), intRegistro)
    '        Next
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Sub ActualizarData()
        Try
            Dim dt As DataTable, dtHorario As DataTable, dtAsistencia As DataTable
            Dim obj As New Cls_HoraExtra_LN
            Dim intID As Integer, intIDHorario As Integer, intOpcion As Integer
            Dim strTipoVia As String, strVia As String, strNumero As String, strInterior As String, strTipoZona As String, strZona As String, strDireccion As String
            Dim intRegistro As Integer = 0
            Dim strInicio As String, strFin As String
            Dim hi1 As String, hf1 As String, hi2 As String, hf2 As String, hi3 As String, hf3 As String, hi4 As String, hf4 As String, hi5 As String, hf5 As String
            Dim hi6 As String, hf6 As String, hi7 As String, hf7 As String
            Dim lista() As Integer = New Integer(7) {0, 0, 0, 0, 0, 0, 0, 0}
            Dim strHorario As String

            Dim strPlanilla As String, strPeriodo As String, strGlosa As String

            strPlanilla = PeriodoActual()
            'strPeriodo = strPlanilla & strTipoPlanilla
            strPeriodo = strPlanilla

            strInicio = "01/" & strPeriodo.Substring(4, 2) & "/" & strPeriodo.Substring(0, 4)
            strFin = "07/" & strPeriodo.Substring(4, 2) & "/" & strPeriodo.Substring(0, 4)

            Dim strTemp As String
            dt = CargarTrabajador(strPeriodo.Substring(0, 6))
            For Each row As DataRow In dt.Rows
                'strTipoVia = "" & row("tipo_via")
                'strVia = "" & row("via")
                'strNumero = "" & row("numero")
                'strInterior = "" & row("interior")
                'strTipoZona = "" & row("tipo_zona")
                'strZona = "" & row("zona")
                'strDireccion = ObtieneDireccion(strTipoVia, strVia, strNumero, strInterior, strTipoZona, strZona)
                strDireccion = row("direccion")
                Dim dt2 As DataTable = obj.GrabarTrabajador(Trim(row("codigo")), "" & row("nombres"), row("cargo"), "" & row("centro_costo"), row("area"), row("remuneracion"), row("horario"), row("situacion"), row("cap"), _
                                                            "" & row("fecha_ingreso"), _
                                                            strTipoVia, strVia, strNumero, strInterior, strTipoZona, strZona, strDireccion, "" & row("numero_documento"))
                intID = dt2.Rows(0).Item("id")
                If intID > 0 Then
                    intOpcion = dt2.Rows(0).Item("opcion")
                    If intOpcion = 1 Then 'graba horario si el trabajador es nuevo
                        dtHorario = CargarHorario(row("codigo"), strInicio, strFin)
                        If dtHorario.Rows.Count > 0 Then
                            strHorario = dtHorario.Rows(0).Item("horario")
                            For Each rowh As DataRow In dtHorario.Rows
                                Select Case rowh("ds")
                                    Case 1
                                        lista(1) = 1
                                        hi1 = rowh("inicio")
                                        hf1 = rowh("fin")
                                    Case 2
                                        lista(2) = 1
                                        hi2 = rowh("inicio")
                                        hf2 = rowh("fin")
                                    Case 3
                                        lista(3) = 1
                                        hi3 = rowh("inicio")
                                        hf3 = rowh("fin")
                                    Case 4
                                        lista(4) = 1
                                        hi4 = rowh("inicio")
                                        hf4 = rowh("fin")
                                    Case 5
                                        lista(5) = 1
                                        hi5 = rowh("inicio")
                                        hf5 = rowh("fin")
                                    Case 6
                                        lista(6) = 1
                                        hi6 = rowh("inicio")
                                        hf6 = rowh("fin")
                                    Case 7
                                        lista(7) = 1
                                        hi7 = rowh("inicio")
                                        hf7 = rowh("fin")
                                End Select
                            Next
                            intIDHorario = obj.GrabarHorario(strHorario.ToString.Trim,
                            "" & hi1, "" & hf1, lista(1), "" & hi2, "" & hf2, lista(2), "" & hi3, "" & hf3, lista(3), "" & hi4, "" & hf4, lista(4), "" & hi5, "" & hf5, lista(5), _
                            "" & hi6, "" & hf6, lista(6), "" & hi7, "" & hf7, lista(7))
                            obj.GrabarTrabajadorHorario(intID, intIDHorario)
                        End If
                    End If

                    'asistencia
                    Dim intRepetido As Integer = 0
                    Dim strFechaFin As String = Format(FechaServidor, "Short Date")
                    strFechaFin = DateAdd(DateInterval.Day, -1, CDate(strFechaFin))
                    'dtAsistencia = GetMarcacion(row("codigo"), "26/10/2018", strFecha)
                    Dim strFechaInicio As String = PeriodoActual(1)
                    dtAsistencia = GetMarcacion(row("codigo"), strFechaInicio, strFechaFin)
                    If row("codigo") = "12810" Then
                        Dim a As Integer = 1
                    End If
                    For Each rowi As DataRow In dtAsistencia.Rows
                        intRegistro += 1
                        strGlosa = "Asist. Normal " & rowi("hora1") & "-" & rowi("hora2")
                        If rowi("hora1") = rowi("hora2") Then
                            intRepetido = 1
                        Else
                            intRepetido = 0
                        End If
                        obj.GrabarAsistencia(strPeriodo, rowi("fecha"), rowi("codigo"), "300", 1, strGlosa, intRepetido)
                    Next
                End If
                strTemp = row("codigo")
            Next
            obj.EliminarAsistencia()

            'vacaciones
            intRegistro = 0
            Dim strFechaServidor As String = Format(FechaServidor, "Short Date")
            'strPlanilla = CDate(strFechaServidor).Year & CDate(strFechaServidor).Month.ToString.PadLeft(2, "0")
            'Dim strInicio As String, strFin As String
            Dim intAño As Integer, intMes As Integer

            intAño = CDate(strFechaServidor).Year
            intMes = CDate(strFechaServidor).Month
            strInicio = "01/" & intMes.ToString.PadLeft(2, "0") & "/" & intAño
            strFin = UltimoDiaMesAño(intMes, intAño).ToString.PadLeft(2, "0") & "/" & intMes.ToString.PadLeft(2, "0") & "/" & intAño
            dt = CargarVacaciones(strInicio, strFin)
            For Each row As DataRow In dt.Rows
                intRegistro += 1
                obj.GrabarVacaciones(row("codigo"), row("inicio"), row("fin"), strPeriodo.Substring(0, 6), intRegistro)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Function ObtieneDireccion(ByVal tipo_via As String, ByVal via As String, ByVal numero As String, ByVal interior As String, ByVal tipo_zona As String, ByVal zona As String) As String
        Dim strDireccion As String = ""
        If tipo_via.Trim.Length > 0 Then
            Select Case tipo_via
                Case "01" : strDireccion = "AVENIDA"
                Case "02" : strDireccion = "JIRON"
                Case "03" : strDireccion = "CALLE"
                Case "04" : strDireccion = "PASAJE"
                Case "05" : strDireccion = "ALAMEDA"
                Case "06" : strDireccion = "MALECON"
                Case "07" : strDireccion = "OVALO"
                Case "08" : strDireccion = "PARQUE"
                Case "09" : strDireccion = "PLAZA"
                Case "10" : strDireccion = "CARRETERA"
                Case "13" : strDireccion = "TROCHA"
                Case "14" : strDireccion = "CAMINO RURAL"
                Case "15" : strDireccion = "BAJADA"
                Case "16" : strDireccion = "PASEO"
                Case "19" : strDireccion = "PLAZUELA"
                Case "20" : strDireccion = "PORTAL"
                Case "21" : strDireccion = "CAMINO AFIRMADO"
                Case "22" : strDireccion = "TROCHA CARROZABLE"
                Case "99" : strDireccion = "OTROS"
            End Select
        End If
        strDireccion &= " " & via.Trim & " " & numero.Trim & " " & interior.Trim & " "

        If tipo_zona.Trim.Length > 0 Then
            Select Case tipo_zona
                Case "01" : strDireccion &= "URBANIZACION"
                Case "02" : strDireccion &= "PUEBLO JOVEN"
                Case "03" : strDireccion &= "UNIDAD VECINAL"
                Case "04" : strDireccion &= "CONJUNTO HABITACIONAL"
                Case "05" : strDireccion &= "ASENTAMIENTO HUMANO"
                Case "06" : strDireccion &= "COOPERATIVA"
                Case "07" : strDireccion &= "RESIDENCIAL"
                Case "08" : strDireccion &= "ZONA INDUSTRIAL"
                Case "09" : strDireccion &= "GRUPO"
                Case "10" : strDireccion &= "CASERIO"
                Case "11" : strDireccion &= "FUNDO"
                Case "99" : strDireccion &= "OTROS"
            End Select
            strDireccion &= " " & zona.Trim
        End If
        Return strDireccion.Trim
    End Function
    Function CargarTrabajador() As DataTable
        Dim dt As New DataTable
        Using cnn As New OleDbConnection(conexion)
            cnn.ResetState()
            cnn.Open()

            Dim sql As String
            Dim cmd As OleDbCommand = cnn.CreateCommand()
            sql = "select a.codtra01 as codigo,a.apepat01+' '+a.apemat01+' '+a.nombre01 as nombres,c.descri as cargo,d.nomcco15 as centro_costo,e.deslar17 as area, "
            sql = sql & "b.totbas02+iif(a.nrohij01>0,93,0)+65 as remuneracion,b.tpohor02 as horario,b.codcap02 as cap,a.sittra01 as situacion,'' as horas, b.totbas02*0 as costo, "
            sql = sql & "a.fecing01 as fecha_ingreso,a.tpovia01 as tipo_via,nomvia01 as via,numviv01 as numero,numint01 as interior,tpozon01 as tipo_zona,"
            sql = sql & "nomzon01 as zona,a.doctra01 as numero_documento "
            sql = sql & "from pemast01 a,pemast02 b,pers_dsc c,ctm15 d,percap17 as e "
            'sql = sql & "where b.codcap02='" & dtoUSUARIOS.CentroCosto & "' and "
            sql = sql & "where "
            sql = sql & "a.codtra01=b.codtra02 and c.coddes=b.tpocar02 and val(b.cencos02)=d.codcco15 and b.codcap02=e.codcap17 and c.codtab='120' order by 1"
            cmd.CommandText = sql
            Dim da As New OleDbDataAdapter(cmd)
            da.Fill(dt)
            cnn.Close()
            Return dt
        End Using
    End Function

    Function CargarTrabajador(ByVal periodo As String) As DataTable
        ' Usa una conexión con el ofisis 
        Dim dt As New DataTable()
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.CommandTimeout = 0
        cmd.Connection = cnnSQLPlan
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "PR_A_LISTAR_TRABAJADOR"
        If cnnSQLPlan.State = ConnectionState.Closed Then cnnSQL.Open()
        cmd.Parameters.Add(New SqlClient.SqlParameter("@P_PERIODO", SqlDbType.VarChar)).Value = periodo
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        Return dt
    End Function

    'Function CargarHorario(ByVal horario As String) As DataTable
    '    Using cnn As New OleDbConnection(conexion)
    '        cnn.ResetState()
    '        cnn.Open()

    '        Dim sql As String
    '        sql = "select a.codhor38 as codigo, diadom38 as dom,dialun38 as lun,diamar38 as mar,diamie38 as mie,diajue38 as jue,diavie38 as vie,diasab38 as sab,"
    '        sql = sql & "inilun38 as inilun,inimar38 as inimar,inimie38 as inimie,inijue38 as inijue,inivie38 as inivie,inisab38 as inisab,inidom38 as inidom,"
    '        sql = sql & "finlun38 as finlun,finmar38 as finmar,finmie38 as finmie,finjue38 as finjue,finvie38 as finvie,finsab38 as finsab,findom38 as findom "
    '        sql = sql & "from pehora38 a "
    '        sql = sql & "where a.codhor38='" & horario & "' "
    '        Dim cmd As OleDbCommand = cnn.CreateCommand()
    '        cmd.CommandText = sql
    '        Dim da As New OleDbDataAdapter(cmd)
    '        Dim dt As New DataTable
    '        da.Fill(dt)
    '        cnn.Close()
    '        Return dt
    '    End Using
    'End Function

    Function CargarHorario(ByVal codigo As String, ByVal inicio As String, ByVal fin As String) As DataTable
        'Usa una conexión con la marcacion del reloj
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.CommandTimeout = 0
        cmd.Connection = cnnSQLMarcacion
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "sp_cargar_horario"
        If cnnSQLMarcacion.State = ConnectionState.Closed Then cnnSQLMarcacion.Open()
        cmd.Parameters.Add(New SqlClient.SqlParameter("@P_CODIGO", SqlDbType.VarChar)).Value = codigo
        cmd.Parameters.Add(New SqlClient.SqlParameter("@P_INICIO", SqlDbType.VarChar)).Value = inicio
        cmd.Parameters.Add(New SqlClient.SqlParameter("@P_FIN", SqlDbType.VarChar)).Value = fin
        Dim dr As SqlDataReader = cmd.ExecuteReader
        Dim dt As New DataTable
        dt.Load(dr)
        Try
            Return dt
        Catch
            Throw
        End Try

        ''Usa una conexión con el PYS
        'Dim dt As New DataTable()
        'Dim cmd As New System.Data.SqlClient.SqlCommand
        'cmd.CommandTimeout = 0
        'cmd.Connection = cnnSQLPlan
        'cmd.CommandType = CommandType.StoredProcedure
        'cmd.CommandText = "PR_A_LISTAR_HORARIO"
        'If cnnSQLPlan.State = ConnectionState.Closed Then cnnSQL.Open()
        'cmd.Parameters.Add(New SqlClient.SqlParameter("@P_CODIGO", SqlDbType.VarChar)).Value = horario
        'Dim da As New SqlDataAdapter(cmd)
        'da.Fill(dt)
        'Return dt
    End Function

    Function CargarFeriado() As DataTable
        Using cnn As New OleDbConnection(conexion)
            cnn.ResetState()
            cnn.Open()

            Dim sql As String
            sql = "select fecfer05 as fecha,desfer05 as descripcion, a.flgpag05 as estado "
            sql = sql & "from peferi05 a "
            sql = sql & "where year(a.fecfer05)='" & Now.Year & "'"
            Dim cmd As OleDbCommand = cnn.CreateCommand()
            cmd.CommandText = sql
            Dim da As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            cnn.Close()
            Return dt
        End Using
    End Function
    'Function CargarVacaciones(ByVal periodo As String) As DataTable
    '    Using cnn As New OleDbConnection(conexion)
    '        cnn.ResetState()
    '        cnn.Open()

    '        Dim sql As String
    '        sql = "select codtra23 as codigo,inivac23 as inicio,finvac23 as fin,meseje23 as periodo "
    '        sql = sql & "from pevaca23 a "
    '        sql = sql & "where a.meseje23='" & periodo & "'"
    '        Dim cmd As OleDbCommand = cnn.CreateCommand()
    '        cmd.CommandText = sql
    '        Dim da As New OleDbDataAdapter(cmd)
    '        Dim dt As New DataTable
    '        da.Fill(dt)
    '        cnn.Close()
    '        Return dt
    '    End Using
    'End Function

    Function CargarVacaciones(ByVal inicio As String, ByVal fin As String) As DataTable
        'Usa una conexión con el PYS
        Dim dt As New DataTable()
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.CommandTimeout = 0
        cmd.Connection = cnnSQLPlan
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "PR_A_LISTAR_VACACIONES"
        If cnnSQLPlan.State = ConnectionState.Closed Then cnnSQLPlan.Open()
        cmd.Parameters.Add(New SqlClient.SqlParameter("@P_INICIO", SqlDbType.VarChar)).Value = inicio
        cmd.Parameters.Add(New SqlClient.SqlParameter("@P_FIN", SqlDbType.VarChar)).Value = fin
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        Return dt
    End Function

    Function CargarAsistencia(ByVal fecha As String, ByVal codigo As String) As DataTable
        Dim dt As New DataTable
        Using cnn As New OleDbConnection(conexion)
            cnn.ResetState()
            cnn.Open()

            Dim sql As String
            Dim cmd As OleDbCommand = cnn.CreateCommand()
            sql = "select a.numpla09 as planilla,a.fecmov09 as fecha,a.codtra09 as codigo, a.codcon09 as concepto,a.cantid09 as valor,a.glosas09 as glosa "
            sql = sql & "from pe092019 a "
            '300 normal 301 tardanza 324 descanso 355 falta 399 falta asistencia
            'sql = sql & "where str(a.fecmov09)='" & fecha & "' and a.codtra09='" & codigo & "' and a.codcon09 in ('300','302','303','304','342') "
            sql = sql & "where a.codtra09='" & codigo & "' and a.codcon09 in ('300','301','306','314','324','355','399') and "
            sql = sql & "a.fecmov09>=#" & Format(CDate(fecha), "MM-dd-yyyy") & "# "
            'sql = sql & "where a.codcon09='300' and a.fecmov09>=#" & Format(CDate(fecha), "MM-dd-yyyy") & "# "
            sql = sql & "order by 2"
            cmd.CommandText = sql
            Dim da As New OleDbDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
            cnn.Close()
            Return dt
        End Using
    End Function
    Function CargarHHEE(ByVal inicio As String, ByVal fin As String) As DataTable
        Dim dt As New DataTable
        Using cnn As New OleDbConnection(conexion)
            cnn.ResetState()
            cnn.Open()

            Dim sql As String
            Dim cmd As OleDbCommand = cnn.CreateCommand()
            'sql = "select 1 as opcion, b.codact02 as tipo,sum(a.cantid09) as valor "
            'sql = sql & "from pe092018 a,pemast01 p,pemast02 b,percap17 e "
            'sql = sql & "where a.codtra09=p.codtra01 and p.codtra01=b.codtra02 and b.codcap02=e.codcap17 and "
            'sql = sql & "a.codcon09 in ('302','303','304','342') and val(p.codtra01)<30000 and "
            'sql = sql & "a.fecmov09>=#" & Format(CDate(inicio), "MM-dd-yyyy") & "# and "
            'sql = sql & "a.fecmov09<=#" & Format(CDate(fin), "MM-dd-yyyy") & "# "
            'sql = sql & "group by b.codact02 "
            'sql = sql & "union all "
            'sql = sql & "select 2 as opcion,b.codact02 as tipo,sum(a.cantid09) as valor "
            'sql = sql & "from pe092018 a,pemast01 p,pemast02 b,percap17 e "
            'sql = sql & "where a.codtra09=p.codtra01 and p.codtra01=b.codtra02 and b.codcap02=e.codcap17 and "
            'sql = sql & "a.codcon09 in ('302','303','304','342') and val(p.codtra01)>30000 and "
            'sql = sql & "a.fecmov09>=#" & Format(CDate(inicio), "MM-dd-yyyy") & "# and "
            'sql = sql & "a.fecmov09<=#" & Format(CDate(fin), "MM-dd-yyyy") & "# "
            'sql = sql & "group by b.codact02 "
            'sql = sql & "order by 1"
            'sql = "select e.deslar17 as cap,sum(a.cantid09) as valor "
            'sql = sql & "from pe092018 a,pemast01 p,pemast02 b,percap17 e "
            'sql = sql & "where a.codtra09=p.codtra01 and p.codtra01=b.codtra02 and b.codcap02=e.codcap17 and "
            'sql = sql & "a.codcon09 in ('302','303','304','342') and "
            'sql = sql & "a.fecmov09>=#" & Format(CDate(inicio), "MM-dd-yyyy") & "# and "
            'sql = sql & "a.fecmov09<=#" & Format(CDate(fin), "MM-dd-yyyy") & "# "
            'sql = sql & "group by e.deslar17 "
            'sql = sql & "order by 1"
            sql = "select e.deslar17 as cap,a.fecmov09 as fecha,a.codtra09 as codigo,a.codcon09 as concepto,a.cantid09 as valor,a.nomusr09 as usuario "
            sql = sql & "from pe092019 a,pemast01 p,pemast02 b,percap17 e "
            sql = sql & "where a.codtra09=p.codtra01 and p.codtra01=b.codtra02 and b.codcap02=e.codcap17 and "
            sql = sql & "a.codcon09 in ('302','303','304','342') and "
            sql = sql & "a.fecmov09>=#" & Format(CDate(inicio), "MM-dd-yyyy") & "# and "
            sql = sql & "a.fecmov09<=#" & Format(CDate(fin), "MM-dd-yyyy") & "# "
            sql = sql & "order by 1,2,3"
            cmd.CommandText = sql
            Dim da As New OleDbDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
            cnn.Close()
            Return dt
        End Using
    End Function
#End Region

#Region "Leer de Titan"
    Function ListarTrabajadores(ByVal codigo As String) As DataTable
        Dim obj As New Cls_HoraExtra_LN

        Dim dt As DataTable = obj.ListarTrabajador(codigo)
        Return dt
    End Function
    Function ListarTrabajadores(ByVal cap As Integer) As DataTable
        Dim obj As New Cls_HoraExtra_LN

        Dim dt As DataTable = obj.ListarTrabajador(cap)
        Return dt
    End Function
    Function ListarHorario(ByVal horario As String, ByVal codigo As String) As DataTable
        Dim obj As New Cls_HoraExtra_LN

        Dim dt As DataTable = obj.ListarHorario(horario, codigo)
        Return dt
    End Function
    Function EsFeriado(ByVal fecha As String) As Boolean
        Dim obj As New Cls_HoraExtra_LN
        Return obj.EsFeriado(fecha)
    End Function
    Function ListarAsistencia(ByVal fecha As String, ByVal codigo As String) As DataTable
        Dim obj As New Cls_HoraExtra_LN

        Dim dt As DataTable = obj.ListarAsistencia(fecha, codigo)
        Return dt
    End Function
    Sub MostrarHorario(ByVal dia As Integer, ByVal lblIngreso As Label, ByVal lblSalida As Label, ByVal dtHorario As DataTable)
        Select Case dia
            Case 0
                lblIngreso.Text = dtHorario.Rows(0).Item("inidom").ToString.Trim
                lblSalida.Text = dtHorario.Rows(0).Item("findom").ToString.Trim
            Case 1
                lblIngreso.Text = dtHorario.Rows(0).Item("inilun").ToString.Trim
                lblSalida.Text = dtHorario.Rows(0).Item("finlun").ToString.Trim
            Case 2
                lblIngreso.Text = dtHorario.Rows(0).Item("inimar").ToString.Trim
                lblSalida.Text = dtHorario.Rows(0).Item("finmar").ToString.Trim
            Case 3
                lblIngreso.Text = dtHorario.Rows(0).Item("inimie").ToString.Trim
                lblSalida.Text = dtHorario.Rows(0).Item("finmie").ToString.Trim
            Case 4
                lblIngreso.Text = dtHorario.Rows(0).Item("inijue").ToString.Trim
                lblSalida.Text = dtHorario.Rows(0).Item("finjue").ToString.Trim
            Case 5
                lblIngreso.Text = dtHorario.Rows(0).Item("inivie").ToString.Trim
                lblSalida.Text = dtHorario.Rows(0).Item("finvie").ToString.Trim
            Case 6
                lblIngreso.Text = dtHorario.Rows(0).Item("inisab").ToString.Trim
                lblSalida.Text = dtHorario.Rows(0).Item("finsab").ToString.Trim
        End Select
    End Sub
#End Region

#Region "X"
    Function GrabarHorariox(ByVal horario As String) As Integer
        Using cnn As New OleDbConnection(conexion)
            cnn.ResetState()
            cnn.Open()

            Dim sql As String
            sql = "select a.codhor38 as codigo, diadom38 as dom,dialun38 as lun,diamar38 as mar,diamie38 as mie,diajue38 as jue,diavie38 as vie,diasab38 as sab,"
            sql = sql & "inilun38 as inilun,inimar38 as inimar,inimie38 as inimie,inijue38 as inijue,inivie38 as inivie,inisab38 as inisab,inidom38 as inidom,"
            sql = sql & "finlun38 as finlun,finmar38 as finmar,finmie38 as finmie,finjue38 as finjue,finvie38 as finvie,finsab38 as finsab,findom38 as findom "
            sql = sql & "from pehora38 a "
            sql = sql & "where a.codhor38='" & horario & "' "
            Dim cmd As OleDbCommand = cnn.CreateCommand()
            cmd.CommandText = sql
            Dim da As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            cnn.Close()

            'actualizar data
            Dim obj As New Cls_HoraExtra_LN
            Dim intID As Integer
            For Each row As DataRow In dt.Rows
                intID = obj.GrabarHorario(row("codigo"), _
                "" & row("inilun"), "" & row("finlun"), IIf(row("lun"), 0, 1), "" & row("inimar"), "" & row("finmar"), IIf(row("mar"), 0, 1), _
                "" & row("inimie"), "" & row("finmie"), IIf(row("mie"), 0, 1), "" & row("inijue"), "" & row("finjue"), IIf(row("jue"), 0, 1), "" & row("inivie"), "" & row("finvie"), IIf(row("vie"), 0, 1), _
                "" & row("inisab"), "" & row("finsab"), IIf(row("sab"), 0, 1), "" & row("inidom"), "" & row("findom"), IIf(row("dom"), 0, 1))
            Next
            Return intID
        End Using
    End Function
    Function EsFeriadox(ByVal fecha As String) As Boolean
        Using cnn As New OleDbConnection(conexion)
            cnn.ResetState()
            cnn.Open()

            Dim sql As String
            sql = "select count(*) as numero "
            sql = sql & "from peferi05 a "
            sql = sql & "where str(a.fecfer05)='" & fecha & "' and a.flgpag05='S'"
            Dim cmd As OleDbCommand = cnn.CreateCommand()
            cmd.CommandText = sql
            Dim da As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            cnn.Close()
            Return CType(dt.Rows(0).Item(0).ToString, Integer) = 1
        End Using
    End Function
    Sub ListarTrabajadoresx(ByRef dt As DataTable)
        Using cnn As New OleDbConnection(conexion)
            cnn.ResetState()
            cnn.Open()

            Dim sql As String
            Dim cmd As OleDbCommand = cnn.CreateCommand()
            sql = "select a.codtra01 as codigo,a.apepat01+' '+a.apemat01+' '+a.nombre01 as nombres,c.descri as cargo,d.nomcco15 as centro_costo, "
            sql = sql & "b.totbas02+iif(a.nrohij01>0,93,0)+65 as remuneracion,b.tpohor02 as horario,'' as horas, b.totbas02*0 as costo "
            sql = sql & "from pemast01 a,pemast02 b,pers_dsc c,ctm15 d "
            sql = sql & "where a.sittra01='11' and b.codcap02='" & dtoUSUARIOS.CentroCosto & "' and "
            sql = sql & "a.codtra01=b.codtra02 and c.coddes=b.tpocar02 and val(b.cencos02)=d.codcco15 and c.codtab='120'"
            cmd.CommandText = sql

            Dim da As New OleDbDataAdapter(cmd)
            da.Fill(dt)
            cnn.Close()
        End Using
    End Sub
    Function ListarTrabajadorx(ByVal codigo As String) As DataTable
        Dim dt As New DataTable
        Using cnn As New OleDbConnection(conexion)
            cnn.ResetState()
            cnn.Open()

            Dim sql As String
            Dim cmd As OleDbCommand = cnn.CreateCommand()
            sql = "select a.codtra01 as codigo,a.apepat01+' '+a.apemat01+' '+a.nombre01 as nombres,c.descri as cargo,d.nomcco15 as centro_costo,e.deslar17 as area,"
            sql = sql & "b.totbas02+iif(a.nrohij01>0,93,0)+65 as remuneracion,b.tpohor02 as horario,'' as horas, b.totbas02*0 as costo "
            sql = sql & "from pemast01 a,pemast02 b,pers_dsc c,ctm15 d, percap17 as e "
            sql = sql & "where a.sittra01='11' and a.codtra01='" & codigo & "' and "
            sql = sql & "a.codtra01=b.codtra02 and c.coddes=b.tpocar02 and val(b.cencos02)=d.codcco15 and c.codtab='120' and b.codcap02=e.codcap17"
            cmd.CommandText = sql

            Dim da As New OleDbDataAdapter(cmd)
            da.Fill(dt)
            cnn.Close()
            Return dt
        End Using
    End Function
    Function ListarHorariox(ByVal horario As String) As DataTable
        Using cnn As New OleDbConnection(conexion)
            cnn.ResetState()
            cnn.Open()

            Dim sql As String
            sql = "select a.codhor38 as codigo, diadom38 as dom,dialun38 as lun,diamar38 as mar,diamie38 as mie,diajue38 as jue,diavie38 as vie,diasab38 as sab,"
            sql = sql & "inilun38 as inilun,inimar38 as inimar,inimie38 as inimie,inijue38 as inijue,inivie38 as inivie,inisab38 as inisab,inidom38 as inidom,"
            sql = sql & "finlun38 as finlun,finmar38 as finmar,finmie38 as finmie,finjue38 as finjue,finvie38 as finvie,finsab38 as finsab,findom38 as findom "
            sql = sql & "from pehora38 a "
            sql = sql & "where a.codhor38='" & horario & "' "
            Dim cmd As OleDbCommand = cnn.CreateCommand()
            cmd.CommandText = sql
            Dim da As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            cnn.Close()
            Return dt
        End Using
    End Function
    Function ListarAsistenciax(ByVal fecha As String, ByVal codigo As String) As DataTable
        Dim dt As New DataTable
        Using cnn As New OleDbConnection(conexion)
            cnn.ResetState()
            cnn.Open()

            Dim sql As String
            Dim cmd As OleDbCommand = cnn.CreateCommand()
            sql = "select a.codcon09 as concepto,a.cantid09 as valor,a.glosas09 as glosa "
            sql = sql & "from pe092019 a "
            'sql = sql & "where str(a.fecmov09)='" & fecha & "' and a.codtra09='" & codigo & "' and a.codcon09 in ('300','302','303','304','342') "
            sql = sql & "where str(a.fecmov09)='" & fecha & "' and a.codtra09='" & codigo & "' and a.codcon09='300' "
            sql = sql & "order by 1"
            cmd.CommandText = sql

            Dim da As New OleDbDataAdapter(cmd)
            da.Fill(dt)
            cnn.Close()
            Return dt
        End Using
    End Function
    Function PeriodoActual(Optional ByVal opcion As Integer = 0) As String
        Dim strPeriodo As String
        Dim strFechaServidor As String = Format(FechaServidor, "Short Date")
        'strPeriodo = Cls_HoraExtra_LN.PeriodoActual(strFechaServidor)

        Dim intDia As Integer, intMes As Integer, intAño As Integer
        intDia = CDate(strFechaServidor).Day
        intMes = CDate(strFechaServidor).Month
        intAño = CDate(strFechaServidor).Year

        Dim dt As DataTable = ListarTipoControl(19, 0)
        Dim intCorte As Integer = dt.Rows(0).Item("valor")
        If opcion = 0 Then
            If intDia > intCorte Then
                If intMes = 12 Then
                    intMes = 1
                    intAño = intAño + 1
                Else
                    intMes = intMes + 1
                End If
            End If
            strPeriodo = intAño.ToString & intMes.ToString.PadLeft(2, "0") & "12"
        Else
            If intDia <= intCorte Then
                If intMes = 1 Then
                    intMes = 12
                    intAño = intAño - 1
                Else
                    intMes = intMes - 1
                End If
            End If
            intDia = 26
            strPeriodo = intDia.ToString.PadLeft(2, "0") & "/" & intMes.ToString.PadLeft(2, "0") & "/" & intAño.ToString
        End If
        Return strPeriodo
    End Function
#End Region

#Region "Asistencia"

    Sub TotalizarHoraExtraEfectivo(ByVal dia As Integer, ByVal cantidad As String, ByRef h1 As Double, ByRef h2 As Double, ByRef h3 As Double, ByVal h4 As Double, ByVal obrero As Integer)
        Dim strCantidad As String = cantidad
        Dim dblCantidad As Double
        Dim intHoras As Integer, intMinutos As Integer
        Dim he1 As Double, he2 As Double, he3 As Double, he4 As Double

        intHoras = cantidad.Substring(0, 2)
        intMinutos = cantidad.Substring(3, 2)
        dblCantidad = intHoras + IIf(intMinutos = 30, 0.5, 0)
        If dia = 1 Then
            If obrero = 1 Then
                he4 = dblCantidad
            Else
                If dblCantidad <= 2 Then
                    he1 = dblCantidad
                Else
                    he1 = 2
                    he2 = dblCantidad - 2
                End If
            End If
        Else
            he3 = dblCantidad
        End If
        h1 = he1
        h2 = he2
        h3 = he3
        h4 = he4
    End Sub

    Sub TotalizarHoraExtra(ByVal dt As DataTable, ByRef hh1 As Double, ByRef hh2 As Double, ByRef hh3 As Double, ByRef hh4 As Double)
        Dim dblEfectivo As Double, dblDescanso As Double, dblHoras As Double
        Dim intTipo As Integer
        Dim h1 As Double = 0, h2 As Double = 0, h3 As Double = 0, h4 As Double = 0
        Dim he1 As Double = 0, he2 As Double = 0, he3 As Double = 0, he4 As Double = 0
        Dim intObrero As Integer

        For Each row As DataRow In dt.Rows
            h1 = 0 : h2 = 0 : h3 = 0 : h4 = 0
            dblEfectivo = row("efectivo")
            intTipo = row("tipo")
            intObrero = row("obrero")
            If intTipo = 1 Then
                If intObrero = 0 Then
                    If dblEfectivo <= 2 Then
                        h1 = dblEfectivo
                    Else
                        h1 = 2
                        h2 = dblEfectivo - 2
                    End If
                Else
                    h4 = dblEfectivo
                End If
            Else
                h3 = dblEfectivo
            End If
            he1 += h1
            he2 += h2
            he3 += h3
            he4 += h4
        Next
        hh1 = he1
        hh2 = he2
        hh3 = he3
        hh4 += he4
    End Sub

    Sub GrabarHoraExtraEfectivo(ByVal dt As DataTable)
        Dim strConcepto As String, strGlosa As String = "Horas Extras enviadas por Titan"
        Dim strPeriodo As String
        Dim strPlanilla As String = "12"
        Dim intHoras As Integer, intMinutos As Integer
        Dim dblCantidad As Double
        Dim strfecha As String = Format(FechaServidor, "Short Date")
        Dim strCantidad As String
        Dim intPosicion As Integer
        Dim intRegistro As Integer = 0

        'strPeriodo = Format(CDate(fecha), "yyyyMM") & strPlanilla
        Using cnn As New OleDbConnection(conexion)
            cnn.ResetState()
            If cnn.State = ConnectionState.Closed Then cnn.Open()
            Dim sql As String

            'hlamas 26-11-2019
            Dim obj As New Cls_HoraExtra_LN
            For Each row As DataRow In dt.Rows
                If row("cantidad") > 0 Then
                    intRegistro += 1
                    intMinutos = 0 : intHoras = 0
                    strCantidad = row("cantidad").ToString
                    intPosicion = strCantidad.IndexOf(".")
                    intHoras = strCantidad.PadLeft(2, "0").Substring(0, 2)
                    If intPosicion > 0 Then
                        intMinutos = strCantidad.Substring(intPosicion + 1).PadLeft(2, "0")
                    End If
                    dblCantidad = intHoras + IIf(intMinutos = 5, 0.5, 0)

                    Dim cmd As OleDbCommand = cnn.CreateCommand()
                    sql = "select numpla09 as periodo,cantid09 as cantidad from pe092019 where numpla09='" & row("periodo") & "' and "
                    sql = sql & "codtra09='" & row("codigo") & "' and codcon09='" & row("concepto") & "' and NOMUSR09='TITAN' and "
                    sql = sql & "str(fecmov09)='" & row("fecha") & "'"
                    cmd.CommandText = sql
                    cmd.CommandType = CommandType.Text
                    Dim reader As Data.OleDb.OleDbDataReader = cmd.ExecuteReader
                    If Not reader.HasRows Then
                        sql = "insert into pe092019 (numpla09,codtra09,fecmov09,codcon09,cantid09,undmed09,ingdes09,fecdig09,glosas09,nomusr09) "
                        sql = sql & "values('" & row("periodo") & "','" & row("codigo") & "','" & row("fecha") & "','" & row("concepto") & "'," & row("cantidad") & ",2,1,'" & row("fecha") & "', '" & strGlosa & "','TITAN')"
                    Else
                        reader.Read()
                        Dim strCantidad2 As String = reader.Item("cantidad").ToString
                        intPosicion = strCantidad2.IndexOf(".")
                        Dim intHoras2 As Integer = 0
                        Dim intMinutos2 As Integer = 0
                        Dim dblCantidad2 As Double

                        intHoras2 = strCantidad2.PadLeft(2, "0").Substring(0, 2)
                        If intPosicion > 0 Then
                            intMinutos2 = strCantidad2.Substring(intPosicion + 1).PadLeft(2, "0")
                        End If
                        dblCantidad2 = intHoras2 + IIf(intMinutos2 = 5, 0.5, 0)
                        dblCantidad2 += dblCantidad

                        sql = "update pe092019 set "
                        sql = sql & "fecmov09='" & strfecha & "',cantid09=" & dblCantidad2 & ",glosas09='" & strGlosa & "' "
                        sql = sql & "where numpla09='" & row("periodo") & "' and codtra09='" & row("codigo") & "' "
                        sql = sql & "and codcon09='" & row("concepto") & "' and nomusr09='TITAN' and "
                        sql = sql & "str(fecmov09)='" & row("fecha") & "'"
                    End If
                    reader.Close()

                    'sql = "select a.codcon09 as concepto,a.cantid09 as valor,a.glosas09 as glosa "
                    'sql = sql & "from pe092018 a "
                    'sql = sql & "where str(a.fecmov09)='" & fecha & "' and a.codtra09='" & codigo & "' and a.codcon09 in ('300','302','303','304','342') "
                    'sql = sql & "where str(a.fecmov09)='" & fecha & "' and a.codtra09='" & codigo & "' and a.codcon09='300' "
                    'sql = sql & "order by 1"
                    '3 piloto 1 empleado
                    '2 quincena
                    cmd.CommandText = sql
                    cmd.CommandType = CommandType.Text
                    Dim intFilas As Integer = cmd.ExecuteNonQuery()

                    'Actualiza HHEE en nueva tabla
                    obj.GrabarHoraExtra(row("periodo"), row("fecha"), row("codigo"), row("concepto"), row("cantidad"), intRegistro)
                End If
            Next
            If cnn.State = ConnectionState.Open Then cnn.Close()
        End Using
    End Sub

    Sub GrabarHoraExtraCompensado(ByVal periodo As String, ByVal codigo As String, ByVal cantidad As String, ByVal fecha As String)
        Dim intHoras As Integer, intMinutos As Integer
        Dim dblCantidad As Double
        Dim strGlosa As String = "Horas Extras enviadas por Titan"
        'Dim strfecha As String = Format(FechaServidor, "Short Date")
        Dim strFecha As String = fecha
        Dim intFilas As Integer
        'Dim strPeriodo As String
        'Dim strPlanilla As String = "12"

        'strPeriodo = Format(CDate(fecha), "yyyyMM") & strPlanilla
        intHoras = cantidad.Substring(0, 2)
        intMinutos = cantidad.Substring(3, 2)
        dblCantidad = intHoras + IIf(intMinutos = 30, 0.5, 0)

        'hlamas 26-11-2019
        Dim obj As New Cls_HoraExtra_LN
        Using cnn As New OleDbConnection(conexion)
            cnn.ResetState()
            If cnn.State = ConnectionState.Closed Then cnn.Open()
            Dim sql As String
            Dim cmd As OleDbCommand = cnn.CreateCommand()
            sql = "select numpla09 as periodo,cantid09 as cantidad from pe092019 where numpla09='" & periodo & "' and "
            sql = sql & "codtra09='" & codigo & "' and codcon09='398' and nomusr09='TITAN' and "
            sql = sql & "str(fecmov09)='" & fecha & "'"
            cmd.CommandText = sql
            cmd.CommandType = CommandType.Text
            Dim reader2 As Data.OleDb.OleDbDataReader = cmd.ExecuteReader
            If Not reader2.HasRows Then
                sql = "insert into pe092019 (numpla09,codtra09,fecmov09,codcon09,cantid09,undmed09,fecdig09,glosas09,nomusr09) "
                sql = sql & "values('" & periodo & "','" & codigo & "','" & strFecha & "','398'," & dblCantidad & ",3,'" & strFecha & "', '" & strGlosa & "','TITAN')"
            Else
                reader2.Read()
                Dim strCantidad2 As String = reader2.Item("cantidad").ToString
                Dim intPosicion As Integer = strCantidad2.IndexOf(".")
                Dim intHoras2 As Integer = 0
                Dim intMinutos2 As Integer = 0
                Dim dblCantidad2 As Double

                intHoras2 = strCantidad2.PadLeft(2, "0").Substring(0, 2)
                If intPosicion > 0 Then
                    intMinutos2 = strCantidad2.Substring(intPosicion + 1).PadLeft(2, "0")
                End If
                dblCantidad2 = intHoras2 + IIf(intMinutos2 = 5, 0.5, 0)
                dblCantidad2 += dblCantidad

                sql = "update pe092019 set "
                sql = sql & "fecmov09='" & strFecha & "',cantid09=" & dblCantidad2 & " "
                sql = sql & "where numpla09='" & periodo & "' and codtra09='" & codigo & "' and codcon09='398' and nomusr09='TITAN' and "
                sql = sql & "str(fecmov09)='" & fecha & "'"
            End If
            reader2.Close()
            cmd.CommandText = sql
            cmd.CommandType = CommandType.Text
            intFilas = cmd.ExecuteNonQuery()

            'Actualiza HHEE en nueva tabla
            obj.GrabarHoraExtra(periodo, strFecha, codigo, 398, dblCantidad, 0)

            If cnn.State = ConnectionState.Open Then cnn.Close()
        End Using
    End Sub

    Sub actualizar()
        Using cnn As New OleDbConnection(conexion)
            cnn.ResetState()
            If cnn.State = ConnectionState.Closed Then cnn.Open()
            Dim sql As String
            Dim cmd As OleDbCommand = cnn.CreateCommand()
            Dim cmd2 As OleDbCommand = cnn.CreateCommand()
            'sql = "delete from pe092018 where numpla09='20190112' and ingdes09<>'1'"
            'sql = "update pe092018 set fecmov09='18/01/2019' "
            'sql = sql & "where numpla09='20190112' and codtra09='10670' and codcon09='302' and str(fecmov09)='11/01/2019' and undmed09='3' "
            'sql = "delete from pe092018 where numpla09='20181212' and codtra09='10633' and codcon09='306' and str(fecmov09)='21/12/2018'"


            'sql = "update pe092018 set numpla09='20181012',fecmov09='26/09/2018' where numpla09='20180912' and codtra09='11774' and codcon09='304'"
            'sql = "update pe092018 set numpla09='20181012',fecmov09='26/09/2018' where numpla09='20180912' and codtra09='11784' and codcon09='304'"
            'sql = "update pe092018 set numpla09='20181012',fecmov09='26/09/2018' where numpla09='20180912' and codtra09='11917' and codcon09='302'"
            'sql = "update pe092018 set numpla09='20181012',fecmov09='26/09/2018' where numpla09='20180912' and codtra09='11917' and codcon09='342'"
            'sql = "update pe092018 set numpla09='20181012',fecmov09='26/09/2018' where numpla09='20180912' and codtra09='11917' and codcon09='304'"

            'sql = "update pe092018 set cantid09=15.5 where numpla09='20181012' and codtra09='10633' and codcon09='302'"
            'sql = "update pe092018 set numpla09='20181112',fecmov09='01/11/2018' where numpla09='20181012' and codtra09='10500' and codcon09='304'"
            '

            'sql = "update pe092018 set nomusr09='achachai' where numpla09='20181012' and codtra09='11774' and codcon09='302' and str(fecdig09)='12/09/2018'"
            'sql = "update pe092018 set cantid09=10.50 where numpla09='20180912' and codtra09='10670' and codcon09='302'"
            'sql = "update pe092018 set cantid09=2.00 where numpla09='20180912' and codtra09='11729' and codcon09='302'"
            'sql = "update pe092018 set cantid09=14.00 where numpla09='20180912' and codtra09='11774' and codcon09='302'"
            'sql = "update pe092018 set cantid09=2.00 where numpla09='20180912' and codtra09='11843' and codcon09='398'"
            'sql = "update pe092018 set cantid09=3.00 where numpla09='20180912' and codtra09='11894' and codcon09='302'"
            'sql = "update pe092018 set cantid09=12.50 where numpla09='20180912' and codtra09='12375' and codcon09='302'"
            'sql = "update pe092018 set cantid09=6.00 where numpla09='20180912' and codtra09='12376' and codcon09='302'"
            'sql = "delete from pe092018 where numpla09='20181012' and codtra09='10633' and codcon09='306' and str(fecmov09)='22/10/2018'"
            'sql = "delete from pe092018 where numpla09='20181012' and codtra09='10513' and codcon09='302'"
            'sql = "update pe092018 set cantid09=3.00 where numpla09='20180912' and codtra09='11386' and codcon09='302'"
            'sql = "update pe092018 set cantid09=6.00 where numpla09='20180912' and codtra09='12363' and codcon09='30230
            'sql = "update pe092018 set cantid09=20.00 where numpla09='20180912' and codtra09='11888' and codcon09='302'"
            'sql = "update pe092018 set cantid09=10.00 where numpla09='20180912' and codtra09='11888' and codcon09='342'"

            'sql = "insert into pe092018 (numpla09,codtra09,fecmov09,codcon09,cantid09,undmed09,fecdig09,glosas09,nomusr09) "
            'sql = sql & "values ('20190112','12482','19/01/2019','342',2.5,'3','19/01/2019','Horas Extras enviadas por Titan','TITAN')"

            'sql = "select * from pe092018 where numpla09='20190112' order by codtra09"
            'cmd.CommandText = sql
            'cmd.CommandType = CommandType.Text
            'Dim rd As OleDbDataReader = cmd.ExecuteReader
            'If rd.HasRows Then
            '    While rd.Read
            '        sql = "insert into pe092019 (numpla09,codtra09,fecmov09,codcon09,cantid09,undmed09,fecdig09,glosas09,nomusr09) "
            '        sql = sql & "values ('20190112','" & rd("codtra09") & "','" & rd("fecmov09") & "','" & rd("codcon09") & "'," & rd("cantid09") & ",3,'" & rd("fecmov09") & "','Horas Extras enviadas por Titan','TITAN')"
            '        cmd2.CommandText = sql
            '        cmd2.CommandType = CommandType.Text
            '        Dim intFilas As Integer = cmd2.ExecuteNonQuery()
            '    End While
            'End If

            'sql = "delete from pe092019 where numpla09='20191012' and codtra09='10633' and codcon09='306' and str(fecmov09)='15/10/2019'"
            'sql = "delete from pe092019 where numpla09='20190912' and codtra09='10179' and codcon09='303' and str(fecmov09)='01/09/2019'"
            'sql = "insert into pe092019 (numpla09,codtra09,fecmov09,codcon09,cantid09,undmed09,fecdig09,glosas09,nomusr09) "
            'sql = sql & "values ('20191012','10179','01/10/2019','303',3.5,'3','01/10/2019','Horas Extras enviadas por Titan','TITAN')"
            sql = "update pe092019 set numpla09='20191112' where codtra09='11784' and codcon09='304' and numpla09='20191012' and nomusr09='TITAN'"

            cmd.CommandText = sql
            cmd.CommandType = CommandType.Text
            Dim intFilas As Integer = cmd.ExecuteNonQuery()
            If cnn.State = ConnectionState.Open Then cnn.Close()
        End Using
    End Sub
#End Region

#Region "Importar desde Reloj"
    Public Function GetMarcacion(ByVal codigo As String, ByVal inicio As String, ByVal fin As String) As DataTable
        'Usa una conexión con la marcacion del reloj
        Dim cmd As New System.Data.SqlClient.SqlCommand
        cmd.CommandTimeout = 0
        cmd.Connection = cnnSQLMarcacion
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "sp_get_marcacion"
        If cnnSQLMarcacion.State = ConnectionState.Closed Then cnnSQLMarcacion.Open()
        cmd.Parameters.Add(New SqlClient.SqlParameter("@P_CODIGO", SqlDbType.VarChar)).Value = codigo
        cmd.Parameters.Add(New SqlClient.SqlParameter("@P_INICIO", SqlDbType.VarChar)).Value = inicio
        cmd.Parameters.Add(New SqlClient.SqlParameter("@P_FIN", SqlDbType.VarChar)).Value = fin
        Dim dr As SqlDataReader = cmd.ExecuteReader
        Dim dt As New DataTable
        dt.Load(dr)
        Try
            Return dt
        Catch
            Throw
        End Try
    End Function
#End Region

End Module
