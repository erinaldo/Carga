Public Class FrmMigrarGuias
    Dim dt As New DataTable
    Dim CnnDbf As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\;Extended Properties=dBASE IV;User ID=Admin;Password=")
    Private Sub FrmMigrarGuias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim ruta As String
        Dim archivo As String
        Dim da As New OleDb.OleDbDataAdapter
        dt = New DataTable

        Try
            OFD.Multiselect = False
            OFD.FileName = "*.dbf"
            OFD.ShowDialog()
            OFD.Filter = "Achivos dbf(*.dbf)|.dbf"

            TBRUTA.Text = OFD.FileName

            ruta = OFD.FileName

            For i As Integer = CInt(OFD.FileName.Length) - 1 To 0 Step -1
                ruta = Mid(OFD.FileName, 1, i)
                archivo = Mid(OFD.FileName, i + 1, OFD.FileName.Length - i)
                If Mid(OFD.FileName, i, 1) = "\" Then
                    Exit For
                End If
            Next
            CnnDbf = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & ruta & ";Extended Properties=dBASE IV;User ID=Admin;Password=")
            OFD.InitialDirectory = ruta

            CnnDbf.Open()

            Dim SQL As String

            SQL = "SELECT * FROM " & Mid(archivo, 1, Len(archivo) - 4)

            da = New OleDb.OleDbDataAdapter(SQL, CnnDbf)

            da.Fill(dt)

            dgv1.DataSource = dt.DefaultView
            Label1.Text = CStr(dt.Rows.Count) + " Registros encontrados"
        Catch ex As OleDb.OleDbException
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try

    End Sub

    Private Sub FrmMigrarGuias_MenuSalir() Handles Me.MenuSalir
        Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim OBJGUIAS As New ClsLbTepsa.dtoguias


        pb.Minimum = 0
        pb.Maximum = dt.Rows.Count - 1
        pb.Visible = True
        For i As Integer = 0 To dt.Rows.Count - 1
            With OBJGUIAS
                .IDDIRECCION_REMITENTE = 0
                .IDTEFONO_REMITENTE = 0
                .IDTEFONO_CONSIGNADO = 0
                .IDCONTACTO_DESTINATARIO = 0
                .CANTIDAD_X_UNIDAD_ARTI = 0
                If dt.Rows(i).IsNull("IMPIGV06") Then .MONTO_IMPUESTO = 0 Else .MONTO_IMPUESTO = dt.Rows(i)("IMPIGV06")
                .PRECIO_X_VOLUMEN = 0
                .CANTIDAD_X_UNIDAD_VOLUMEN = 0
                .NRO_REF_GUIA = 0
                .LIQUIDADO = 0
                .IDCIERRES_LIQUIDACIONES = 0
                .CARGO = 0
                .IDTIPO_COMPROBANTE = 0
                .IDTIPO_MONEDA = 0
                .FACTURADO = 0
                .TOTAL_ARTICULO = 0
                .ID_REMITENTE = 0
                .IDCENTRO_COSTO = 0
                .PRECIO_X_PESO = 0
                .IMPUESTO = 0
                .IDGUIAS_ENVIO_REF = 0
                .IDGUIAS_ENVIO = 0
                If dt.Rows(i).IsNull("FECEMI06") Then .FECHA_GUIA = "NULL" Else .FECHA_GUIA = dt.Rows(i)("FECEMI06")
                If dt.Rows(i).IsNull("NUMGUI06") Then .NRO_GUIA = 0 Else .NRO_GUIA = dt.Rows(i)("NUMGUI06")
                If dt.Rows(i).IsNull("OFIORI06") Then .IDUNIDAD_AGENCIA = 0 Else .IDUNIDAD_AGENCIA = dt.Rows(i)("OFIORI06")
                If dt.Rows(i).IsNull("OFIDES06") Then .IDUNIDAD_AGENCIA_DESTINO = 0 Else .IDUNIDAD_AGENCIA_DESTINO = dt.Rows(i)("OFIDES06")
                .IDPERSONA = 0
                .IDAGENCIAS = 0
                .IDDIRECCION_DESTINATARIO = 0
                .IDCONTACTO_REMITENTE = 0
                .IDTIPO_ENTREGA_CARGA = 0
                .IDFORMA_PAGO = 0
                .IDTARIFAS_CARGA_CLIENTE = 0
                .IDTARIFAS_CARGA = 0
                .FECHA_DESPACHO = Now
                .FECHA_RECEPCION_DESTINO = Now
                .FECHA_ENTREGA = Now
                .FECHA_CARGOS = Now
                .IDCIUDAD_TRANSITO = 0
                .TOTAL_PESO = 0
                If dt.Rows(i).IsNull("CANTID06") Then .CANTIDAD = 0 Else .CANTIDAD = dt.Rows(i)("CANTID06")
                .TOTAL_VOLUMEN = 0
                .MONTO_BASE = 0
                .PRECIO_X_UNIDAD = 0
                .NOMBRE_RECOJO = 0
                .NOMBRE_ENTREGA = 0
                .DOC_ENTREGA = 0
                .FECHA_RECOJO = Now
                .IDARTICULOS = 11
                .IDUSUARIO_PERSONALMOD = 11
                .IDROL_USUARIO = 11
                .IDROL_USUARIOMOD = 11
                .IP = "192.168.1.190"
                .IPMOD = "192.168.1.190"
                .IDESTADO_REGISTRO = 0
                .FECHA_REGISTRO = Now
                .FECHA_ACTUALIZACION = Now
                .IDUSUARIO_PERSONAL = 56
                If dt.Rows(i).IsNull("IMPGIR06") Then .TOTAL_COSTO = 0 Else .TOTAL_COSTO = dt.Rows(i)("IMPGIR06")
                .IDPREFACTURA = 0
                .IDFACTURA_CREDITO = 0
                .IDUSUARIO_REVISION = 11
                .IDROL_REVISION = 11
                .FECHA_REVISION = Now
                If dt.Rows(i).IsNull("NSERIE06") Then .SERIE_GUIA_ENVIO = 0 Else .SERIE_GUIA_ENVIO = dt.Rows(i)("NSERIE06")
                .IDIMPUESTO = 0
            End With
            pb.Value = i
        Next
        pb.Visible = False
    End Sub
End Class
