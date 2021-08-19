Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data
Public Class FrmDetaItinerarios
    Dim _DvRuta, _DvAge1, _DvAge2 As DataView
    Dim drc As DataRowView
    Dim valor, valor2, filtro, filtro2 As String
    Dim filcb, icb, icb2 As Integer
    Public AgeOri As Integer = 0
    Public hnd As Long

    Public Sub New(ByVal dvruta As DataView, ByVal dvage1 As DataView, ByVal dvage2 As DataView)
        MyBase.new()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        _DvRuta = dvruta
        _DvAge1 = dvage1
        _DvAge2 = dvage2
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.ColorTranslator.FromHtml("#507EAF"), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SwFlgDet = 0
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TxtHorViaje.Text = "" Then
            MessageBox.Show("Hora de Viaje no especificada", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        drc = _DvRuta.Item(CbRuta.SelectedIndex)
        SwDetRuta = drc("idrutas")
        AgeOri = drc("idunidad_agencia_destino")
        SwDetAge1 = CbAge1.SelectedIndex
        SwDetAge2 = CbAge2.SelectedIndex
        SwFlgDet = 1
        Me.Close()
    End Sub

    Private Sub CbRuta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbRuta.SelectedIndexChanged
        filcb = CbRuta.SelectedIndex
        If filcb >= 0 Then
            drc = _DvRuta.Item(filcb)
            valor = IIf(IsDBNull(drc("idunidad_agencia")) = True, "0", drc("idunidad_agencia").ToString)
            valor2 = IIf(IsDBNull(drc("idunidad_agencia_destino")) = True, "0", drc("idunidad_agencia_destino").ToString)
            _DvAge1.RowFilter = "idunidad_agencia = " & valor
            _DvAge2.RowFilter = "idunidad_agencia = " & valor2
            TxtHorViaje.Text = drc("horas_de_viaje").ToString
        Else
            _DvAge1.RowFilter = "idunidad_agencia = 0"
            _DvAge2.RowFilter = "idunidad_agencia = 0"
            TxtHorViaje.Text = ""
        End If
    End Sub

    Private Sub FrmDetaItinerarios_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmDetaItinerarios_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmDetaItinerarios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            LlenaCombo2(_DvRuta, CbRuta, "nombre_ruta")
            LlenaCombo2(_DvAge1, CbAge1, "nombre_agencia")
            LlenaCombo2(_DvAge2, CbAge2, "nombre_agencia")
            _DvRuta.RowFilter = "idunidad_agencia = " & Convert.ToString(SwDetRuta)
            If _DvRuta.Count > 0 Then
                drc = _DvRuta.Item(0)
                TxtHorViaje.Text = drc("horas_de_viaje").ToString
                valor = IIf(IsDBNull(drc("idunidad_agencia")) = True, "0", drc("idunidad_agencia").ToString)
                valor2 = IIf(IsDBNull(drc("idunidad_agencia_destino")) = True, "0", drc("idunidad_agencia_destino").ToString)
                _DvAge1.RowFilter = "idunidad_agencia = " & valor
                _DvAge2.RowFilter = "idunidad_agencia = " & valor2
            Else
                _DvAge1.RowFilter = "idunidad_agencia = 0"
                _DvAge2.RowFilter = "idunidad_agencia = 0"
            End If

            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub BtnAyuRut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAyuRut.Click
        filtro = _DvRuta.RowFilter
        icb = CbRuta.SelectedIndex
        _DvRuta.RowFilter = ""
        DtAyuRut = _DvRuta.ToTable
        Dim Ayuda As New FrmRutas
        Ayuda.ShowDialog()
        _DvRuta = DtAyuRut.Copy.DefaultView
        LlenaCombo2(_DvRuta, CbRuta, "nombre_ruta")
        _DvRuta.RowFilter = filtro
        CbRuta.SelectedIndex = icb
    End Sub

    Private Sub BtnAyuAge1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAyuAge1.Click
        filtro = _DvAge1.RowFilter
        filtro2 = _DvAge2.RowFilter
        icb = CbAge1.SelectedIndex
        icb2 = CbAge2.SelectedIndex
        _DvAge1.RowFilter = ""
        _DvAge2.RowFilter = ""
        DtAyuRut = _DvAge1.ToTable
        Dim Ayuda As New FrmAgencias
        Ayuda.ShowDialog()
        _DvAge1 = DtAyuRut.Copy.DefaultView
        _DvAge2 = DtAyuRut.Copy.DefaultView
        LlenaCombo2(_DvAge1, CbAge1, "nombre_agencia")
        LlenaCombo2(_DvAge2, CbAge2, "nombre_agencia")
        _DvAge1.RowFilter = filtro
        _DvAge2.RowFilter = filtro2
        CbAge1.SelectedIndex = icb
        CbAge1.SelectedIndex = icb2
    End Sub

    Private Sub BtnAyuAge2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAyuAge2.Click
        filtro = _DvAge1.RowFilter
        filtro2 = _DvAge2.RowFilter
        icb = CbAge1.SelectedIndex
        icb2 = CbAge2.SelectedIndex
        _DvAge1.RowFilter = ""
        _DvAge2.RowFilter = ""
        DtAyuRut = _DvAge1.ToTable
        Dim Ayuda As New FrmAgencias
        Ayuda.ShowDialog()
        _DvAge1 = DtAyuRut.Copy.DefaultView
        _DvAge2 = DtAyuRut.Copy.DefaultView
        LlenaCombo2(_DvAge1, CbAge1, "nombre_agencia")
        LlenaCombo2(_DvAge2, CbAge2, "nombre_agencia")
        _DvAge1.RowFilter = filtro
        _DvAge2.RowFilter = filtro2
        CbAge1.SelectedIndex = icb
        CbAge1.SelectedIndex = icb2
    End Sub
End Class
