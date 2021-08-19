Imports INTEGRACION_LN
Public Class frmHuella
    Dim huella As New Huella

    Public plantilla() As Byte 'plantilla raw y hsq
    Public plantilla2(400) As Byte 'plantilla secugen
    Public imagen2 As Image

    Public imagen() As Byte
    Dim blnLectorAutomatico As Boolean, aDispositivo As ArrayList

    Public aParametro() As String
    Public intCalidadHuella As Integer
    Public intProblema As Integer = 0
    Public strMotivo As String = ""

    Dim blnExito As Boolean

#Region "Propiedades"
    Private strNumeroDocumento As String
    Public Property NumeroDocumento() As String
        Get
            Return strNumeroDocumento
        End Get
        Set(ByVal value As String)
            strNumeroDocumento = value
        End Set
    End Property

    Private strConsignado As String
    Public Property Consignado() As String
        Get
            Return strConsignado
        End Get
        Set(ByVal value As String)
            strConsignado = value
        End Set
    End Property

    Private dblMonto As Double
    Public Property Monto() As Double
        Get
            Return dblMonto
        End Get
        Set(ByVal value As Double)
            dblMonto = value
        End Set
    End Property

    Private blnSeguro As Boolean
    Public Property Seguro() As Boolean
        Get
            Return blnSeguro
        End Get
        Set(ByVal value As Boolean)
            blnSeguro = value
        End Set
    End Property

    Private intTipo As Integer
    Public Property Tipo() As Integer
        Get
            Return intTipo
        End Get
        Set(ByVal value As Integer)
            intTipo = value
        End Set
    End Property

    Private intComprobante As Integer
    Public Property Comprobante() As Integer
        Get
            Return intComprobante
        End Get
        Set(ByVal value As Integer)
            intComprobante = value
        End Set
    End Property

#End Region

    Private Sub frmHuella_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If blnExito Then
            huella.CerrarDispositivo()
        End If
    End Sub

    Private Sub frmHuella_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F10 Then
            Inicializar()
        End If
    End Sub

    Private Sub frmHuella_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.lblConsignado.Text = NumeroDocumento & " " & Consignado
        Me.lblMonto.Text = Format(Monto, "###,###,###0.00")
        Me.lblSeguro.Text = IIf(Seguro, "SI", "NO")

        Inicializar()
    End Sub

    Sub ObtenerDispositivo(ByRef aDispositivo As ArrayList, ByRef exito As Boolean)
        Try
            Dim lista As ArrayList = huella.ObtenerDispositivo()
            If lista.Count > 0 Then
                aDispositivo = lista
                exito = True
            Else
                aDispositivo = Nothing
                exito = False
                VisualizaMensaje("No se encontró dispositivo")
                Desactivar()
            End If
        Catch ex As Exception
            VisualizaMensaje(huella.MostrarError(ex.Message))
        End Try
    End Sub

    Sub ObtenerInfoDispositivo()
        Try
            huella.ObtenerInfoDispositivo()
        Catch ex As Exception
            VisualizaMensaje(huella.MostrarError(ex.Message))
        End Try
    End Sub

    Sub AbrirDispositivo()
        Try
            huella.AbrirDispositivo(0)
        Catch ex As Exception
            VisualizaMensaje(huella.MostrarError(ex.Message))
        End Try
    End Sub

    Sub LectorAutomatico()
        Try
            blnLectorAutomatico = aParametro(4) = 1
            If blnLectorAutomatico Then
                Me.btnCapturar.Enabled = False
                huella.LectorAutomatico(True, Me.Handle.ToInt32)
            Else
                Me.btnCapturar.Enabled = True
                huella.LectorAutomatico(False, 0)
            End If
        Catch ex As Exception
            VisualizaMensaje(huella.MostrarError(ex.Message))
        End Try
    End Sub

    Sub ListarParametros()
        Try
            Dim obj As New Cls_Huella_LN
            Dim dt As DataTable = obj.ListarParametro()
            If dt.Rows.Count > 0 Then
                Dim intCodigo As Integer
                ReDim aParametro(dt.Rows.Count)
                For Each row As DataRow In dt.Rows
                    intCodigo = Convert.ToInt32((row("codigo").ToString))
                    aParametro(intCodigo) = row("valor").ToString
                Next
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Listar Parametros", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Protected Overrides Sub WndProc(ByRef msg As Message)
        Dim blnActivo As Boolean
        huella.HuellaCapturada(msg, blnActivo)
        If blnActivo Then
            CapturarHuella()
        End If
        MyBase.WndProc(msg)
    End Sub

    Private Sub btnCapturarHuella_Click(sender As System.Object, e As System.EventArgs) Handles btnCapturar.Click
        CapturarHuella()
    End Sub

    Sub CapturarHuella()
        Try
            Cursor = Cursors.WaitCursor
            Dim calidad As Integer = 0
            VisualizaMensaje("Capturando Huella...")
            Dim intTipoCaptura As Integer, intTiempo As Integer, intCalidad As Integer
            intTipoCaptura = aParametro(3)
            ReDim imagen(huella.Ancho * huella.Alto)

            If intTipoCaptura = 1 Then
                intTiempo = aParametro(6)
                intCalidad = aParametro(5)
                huella.CapturarHuella(imagen, intTiempo, picHuella.Handle.ToInt32, intCalidad)
            Else
                huella.CapturarHuella(imagen)
                huella.MostrarHuella(imagen, picHuella, 1)
                picHuella.SizeMode = PictureBoxSizeMode.StretchImage
            End If

            huella.ObtieneCalidad(huella.Ancho, huella.Alto, imagen, calidad)
            progreso.Value = calidad
            Me.lblCalidad.Text = calidad & "%"

            huella.CrearPlantilla(imagen, plantilla, 1, aParametro(13), aParametro(14), aParametro(15), aParametro(16))
            huella.CrearPlantilla(imagen, plantilla2, 2)

            Dim intCalidadOK As Integer = aParametro(9)
            If calidad >= intCalidadOK Then
                VisualizaMensaje("Huella Capturada")
                Me.btnVerificar.Enabled = True
                Me.btnHuella.Enabled = False
                Me.btnVerificar.Focus()
            Else
                VisualizaMensaje("Calidad de Huella Insuficiente")
                Me.btnVerificar.Enabled = False
                Me.btnHuella.Enabled = True
            End If
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            VisualizaMensaje(huella.MostrarError(ex.Message))
            Me.btnVerificar.Enabled = False
            Me.btnHuella.Enabled = True
        End Try
    End Sub

    Sub VisualizaMensaje(mensaje As String)
        barra.Text = mensaje
        barra.Refresh()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Dim pic As New PictureBox
        huella.MostrarHuella(imagen, pic, 1)
        imagen2 = pic.Image
        intCalidadHuella = Me.progreso.Value
    End Sub

    Private Sub btnVerificar_Click(sender As System.Object, e As System.EventArgs) Handles btnVerificar.Click
        Try
            Dim plantillaBD() As Byte
            Dim intNivelSeguridad As Integer = aParametro(8)
            Dim blnCoinciden As Boolean

            'Dim dr As OracleClient.OracleDataReader = Nothing
            Dim dt As New DataTable
            huella.CargarHuella(NumeroDocumento, dt)
            'If dr.HasRows Then
            If dt.Rows.Count > 0 Then
                'While dr.Read
                For Each row As DataRow In dt.Rows
                    plantillaBD = Nothing
                    'plantillaBD = dr(0)
                    plantillaBD = row(0)
                    If plantillaBD Is Nothing Then
                        blnCoinciden = True
                        'Exit While
                        Exit For
                    Else
                        'convierte plantillabd wsq a plantilla secugen
                        Dim buffer(400) As Byte
                        Dim ancho As Integer = 0
                        Dim altura As Integer = 0
                        Dim pixel As Integer = 0
                        Dim ppi As Integer = 0
                        Dim flag As Integer = 0
                        Dim longitud As Integer = 120000

                        Dim err As Integer = huella.WsqtoTemplate(buffer, ancho, altura, pixel, ppi, flag, plantillaBD, longitud)

                        huella.VerificarPlantilla(plantilla2, buffer, intNivelSeguridad, blnCoinciden)
                        If blnCoinciden Then
                            'Exit While
                            Exit For
                        End If
                    End If
                    'End While
                Next
            Else
                blnCoinciden = True
            End If

            If blnCoinciden Then
                huella.LectorAutomatico(False, 0)
                Me.btnVerificar.Enabled = False
                Me.btnAceptar.Enabled = True
                Me.btnAceptar.Focus()
                VisualizaMensaje("Verificación Correcta")
            Else
                Me.btnAceptar.Enabled = False
                Me.btnCancelar.Focus()
                VisualizaMensaje("Verificación Incorrecta")
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            VisualizaMensaje(huella.MostrarError(ex.Message))
        End Try
    End Sub

    Sub Desactivar()
        huella.LectorAutomatico(False, 0)
        Me.btnCapturar.Enabled = False
    End Sub

    Sub Inicializar()
        picHuella.Image = Nothing
        Me.progreso.Value = 0
        Me.lblCalidad.Text = ""
        Me.btnAceptar.Enabled = False
        Me.btnVerificar.Enabled = False
        Me.btnHuella.Enabled = False
        If NumeroDocumento.Trim.Length = 8 Then
            ObtenerDispositivo(aDispositivo, blnExito) 'obtiene dispositivo
            If blnExito Then 'se encontro el dispositivo lector de huellas
                ListarParametros() 'carga los parametros de la captura de huella
                AbrirDispositivo() 'abre el dispositivo
                ObtenerInfoDispositivo() 'obtiene informacion del dispositivo
                LectorAutomatico() 'verifica si captura de huella es manual o automatica
                VisualizaMensaje("Listo")
            End If
        Else
            Me.btnCapturar.Enabled = False
            Me.btnAceptar.Enabled = False
            Me.btnVerificar.Enabled = False
            Me.btnHuella.Enabled = False
            VisualizaMensaje("Ingrese Nº Documento del Consignado")
        End If
    End Sub

    Private Sub btnHuella_Click(sender As System.Object, e As System.EventArgs) Handles btnHuella.Click
        Dim frm As New frmAceptarsinHuella
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            intProblema = 1
            strMotivo = frm.txtMotivo.Text.Trim
            Me.btnAceptar_Click(Nothing, Nothing)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim plantillaBD() As Byte
        Dim cadena As String = ""
        NumeroDocumento = "18857367"
        Dim dt As New DataTable
        huella.CargarHuella(NumeroDocumento, dt)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                plantillaBD = Nothing
                plantillaBD = row(0)
                cadena = String.Join(",", plantillaBD)

                Dim strArchivo As String = Application.StartupPath & "\a.wsq"
                huella.EscribirArchivo(strArchivo, plantillaBD)

            Next
            MsgBox(cadena)
        End If
    End Sub

End Class