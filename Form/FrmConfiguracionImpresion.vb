Imports System.IO
Imports System.Drawing.Printing
Public Class FrmConfiguracionImpresion
    Public Documento As Integer
    Public Paginas As Integer
    Public Tamaño As Integer

    Private intImpreso As Integer
    Public Property Impreso() As Integer
        Get
            Return intImpreso
        End Get
        Set(ByVal value As Integer)
            intImpreso = value
        End Set
    End Property

    Private Function SetDefPrinter(ByVal sNombreImpresora As String) As Boolean
        'Parámetro especifica nombre de impresora para poner por defecto.
        'La pongo por defecto y la quito.

        Dim WshNetwork As Object
        Dim pd As New PrintDocument

        WshNetwork = Microsoft.VisualBasic.CreateObject("WScript.Network")

        Try
            WshNetwork.SetDefaultPrinter(sNombreImpresora)
            pd.PrinterSettings.PrinterName = sNombreImpresora
            If pd.PrinterSettings.IsValid Then
                Return True
            Else
                WshNetwork.SetDefaultPrinter(sNombreImpresora)
                Return False
            End If
        Catch exptd As Exception
            'WshNetwork.SetDefaultPrinter(sNombreImpresora)
            Return False
        Finally
            WshNetwork = Nothing
            pd = Nothing
        End Try
    End Function
    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If dtoUSUARIOS.iIDAGENCIAS = 541 Or dtoUSUARIOS.IdRol = 1034 Then
            Dim defecto As New PrinterSettings
            Dim strImpresora As String = defecto.PrinterName
            Using p As New Process
                SetDefPrinter(Me.CboImpresora.Text)
                p.StartInfo.Verb = "Print"
                p.StartInfo.UseShellExecute = True
                p.StartInfo.CreateNoWindow = True
                'p.StartInfo.Arguments = Me.CboImpresora.Text
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                p.StartInfo.FileName = PathSys + "\temp.txt"
                p.Start()
                Me.Close()
                SetDefPrinter(strImpresora)
            End Using
        Else
            Me.Cursor = Cursors.AppStarting
            Dim obj As New Imprimir
            Dim sImpresora = CboImpresora.Text
            Dim bExito As Boolean
            Dim iCopias As Integer = TxtCopias.Value

            obj.EnviarCadenaImpresora(sImpresora, Chr(27) & "SI" & Chr(15))

            For i As Integer = 1 To iCopias
                If RbtPaginas.Checked Then
                    bExito = ImprimirPaginas(TxtDe.Text, Txta.Text)
                Else
                    bExito = obj.EnviarArchivoImpresora(sImpresora, PathSys + "\temp.txt")
                End If
            Next i

            obj.EnviarCadenaImpresora(sImpresora, Chr(27) & "SI" & Chr(18))

            obj = Nothing
            Me.Cursor = Cursors.Default
            Me.Close()

            'hlamas 04-12-2014 si la impresion es correcta 1 caso contrario 0
            Impreso = 0
            If Not bExito Then
                MessageBox.Show("Error en la Impresión", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Impreso = 1
            End If
        End If
    End Sub

    Function ImprimirPaginas(ByVal ini As Integer, ByVal fin As Integer) As Boolean
        Try
            Dim sLinea As String = ""
            Dim pos As Integer = 0, iPagina As Integer = 0, inicio As Integer = 0, final As Integer = 0
            Dim obj As New Imprimir
            Dim archivo As New StreamReader(PathSys + "\temp.txt")

            inicio = Tamaño * (ini - 1) + 1
            final = Tamaño * (fin)
            Dim sImpresora = CboImpresora.Text

            Dim sArchivo As String = PathSys + "\temp2.txt"
            obj.Inicializar(sArchivo)
            obj.Impresora = sImpresora
            Do
                pos += 1
                sLinea = archivo.ReadLine
                If sLinea Is Nothing Then
                    Exit Do
                End If
                If pos >= inicio And pos <= final Then
                    obj.EscribirLinea(sLinea)
                End If
            Loop Until sLinea = Nothing And (pos Mod Tamaño = 0)
            obj.EnviarArchivoImpresora()
            obj.Finalizar()
            archivo.Close()
            Return True

        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return False
        End Try
    End Function

    Private Sub FrmConfiguracionImpresion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim bestado As Boolean = objCONFIGURACION_DOCUMENTARIA.fnIMPRESORAS()
        If bestado Then
            Dim cad As String
            Dim i As Integer = 0
            CboImpresora.Items.Clear()
            For Each cad In objCONFIGURACION_DOCUMENTARIA.arrImpresoras
                i += 1
                If i > 1 Then
                    CboImpresora.Items.Add(cad)
                End If
            Next
            Dim obj As New Imprimir
            Dim sImpresora As String = obj.ObtieneImpresora(Documento, dtoUSUARIOS.IP)
            If sImpresora.Trim.Length = 0 Then
                CboImpresora.SelectedIndex = 0
            Else
                CboImpresora.SelectedItem = sImpresora
            End If
            BtnAceptar.Enabled = True
        Else
            BtnAceptar.Enabled = False
        End If
    End Sub

    Private Sub RbtPaginas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtPaginas.CheckedChanged
        PnlIntervalo.Enabled = True
        TxtDe.Text = 1
        Txta.Text = Paginas
        TxtDe.Focus()
    End Sub

    Private Sub RbtTodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtTodo.CheckedChanged
        PnlIntervalo.Enabled = False
        TxtDe.Text = ""
        Txta.Text = ""
    End Sub

    Private Sub TxtDe_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDe.GotFocus
        TxtDe.SelectAll()
    End Sub

    Private Sub Txta_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txta.GotFocus
        Txta.SelectAll()
    End Sub

    Private Sub TxtDe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDe.KeyPress
        If Not (Asc(e.KeyChar) >= 0 And Asc(e.KeyChar) <= 57) Or (Asc(e.KeyChar) = Keys.Space) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Txta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txta.KeyPress
        If Not (Asc(e.KeyChar) >= 0 And Asc(e.KeyChar) <= 57) Or (Asc(e.KeyChar) = Keys.Space) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtDe_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDe.Validated
        Dim iValor As Integer = IIf(TxtDe.Text.Trim.Length = 0, 0, TxtDe.Text)
        Dim iValor2 As Integer = IIf(Txta.Text.Trim.Length = 0, 0, Txta.Text)

        If Not (iValor >= 1 And iValor <= Paginas) Then
            TxtDe.Text = 1
        End If

        If iValor > iValor2 Then
            Dim aux As Integer = Txta.Text
            Txta.Text = TxtDe.Text
            TxtDe.Text = aux
        End If
    End Sub

    Private Sub Txta_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txta.Validated
        Dim iValor As Integer = IIf(Txta.Text.Trim.Length = 0, 0, Txta.Text)
        Dim iValor2 As Integer = IIf(Txta.Text.Trim.Length = 0, 0, Txta.Text)
        If Not (iValor >= 1 And iValor <= Paginas) Then
            Txta.Text = Paginas
        End If
        If iValor > iValor2 Then
            Dim aux As Integer = Txta.Text
            Txta.Text = TxtDe.Text
            TxtDe.Text = aux
        End If
    End Sub
End Class