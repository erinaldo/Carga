Imports System.IO
Public Class FrmPreview
    Private intImpreso As Integer
    Public Property Impreso() As Integer
        Get
            Return intImpreso
        End Get
        Set(ByVal value As Integer)
            intImpreso = value
        End Set
    End Property

    Dim archivo As New StreamReader(PathSys + "\temp.txt")
    'Dim archivo As New StreamReader("d:\temp.txt")

    'sArchivo = "d:\temp.txt"

    Dim pos As Integer = 0, iPagina As Integer = 0, iPaginas As Integer = 0
    Dim lista() As String

    Public Documento As Integer
    Public Tamaño As Integer = 66

    Private Sub FrmPreview_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        File.Delete(PathSys + "\temp.txt")
        File.Delete(PathSys + "\temp2.txt")

        'File.Delete("c:\temp.txt")
        'File.Delete("c:\temp2.txt")
    End Sub

    Private Sub FrmPreview_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Carga()
        Catch ex As Exception
            archivo.Close()
            archivo = Nothing
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Texto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Texto.KeyDown
        If e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Back Or e.KeyCode = Keys.Enter Then
            e.Handled = True
        End If
        If e.Control Then
            If e.KeyCode = Keys.V Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Texto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Texto.KeyPress
        e.Handled = True
    End Sub

    Private Sub pagina_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles pagina.KeyDown
        e.Handled = True
    End Sub

    Private Sub pagina_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles pagina.KeyPress
        e.Handled = True
    End Sub

    Sub Carga()
        Dim sLinea As String = ""
        Do
            pos += 1
            sLinea = archivo.ReadLine
            If sLinea Is Nothing Then
                Exit Do
            End If
            If pos > 0 Then
                Texto.Text = Texto.Text & IIf(pos > 1, ControlChars.CrLf, "") & sLinea
            End If
            If pos Mod (Tamaño) = 0 Then
                iPagina += 1
                ReDim Preserve lista(iPagina)
                lista(iPagina) = Texto.Text
                Texto.Text = ""
                pos = 0
            End If
        Loop Until sLinea = Nothing And (pos Mod Tamaño = 0)
        iPaginas = iPagina
        iPagina = 1
        Dim sender As New ToolStripButton
        sender.Name = "ini"
        Dim e As System.EventArgs
        VisualizaPagina(sender, e)

        Texto.Visible = True
        archivo.Close()
    End Sub

    Function CrearPagina() As RichTextBox
        Dim txt As New RichTextBox
        txt.Dock = DockStyle.Fill
        iPagina += 1
        txt.Tag = iPagina
        Me.Panel1.Controls.Add(txt)
        Return txt
    End Function

    Private Sub VisualizaPagina(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ini.Click, ant.Click, sig.Click, fin.Click
        Select Case CType(sender, ToolStripButton).Name
            Case "ini"
                iPagina = 1
            Case "ant"
                iPagina -= 1
            Case "sig"
                iPagina += 1
            Case "fin"
                iPagina = iPaginas
        End Select

        If iPaginas = 1 And iPagina = 1 Then
            ini.Enabled = False
            ant.Enabled = False
            sig.Enabled = False
            fin.Enabled = False
        ElseIf iPagina = 1 Then
            ini.Enabled = False
            ant.Enabled = False
            sig.Enabled = True
            fin.Enabled = True
        ElseIf iPagina = iPaginas Then
            fin.Enabled = False
            sig.Enabled = False
            ini.Enabled = True
            ant.Enabled = True
        Else
            fin.Enabled = True
            sig.Enabled = True
            ini.Enabled = True
            ant.Enabled = True
        End If

        pagina.Text = iPagina & "/" & iPaginas
        Texto.Text = ""
        Texto.Text = lista(iPagina)
    End Sub

    Private Sub Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Imprimir.Click
        Dim frm As New FrmConfiguracionImpresion
        frm.Documento = Documento
        frm.Paginas = iPaginas
        frm.Tamaño = Tamaño
        frm.ShowDialog()
        Impreso = frm.Impreso
        'MessageBox.Show(Impreso)
    End Sub

    Private Sub salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salir.Click
        Me.Close()
    End Sub

    Private Sub prueba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Using p As New Process
            p.StartInfo.FileName = "c:\temp.txt"
            p.StartInfo.Verb = "print"
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            p.StartInfo.UseShellExecute = True
            'p.StartInfo.Arguments =
            p.Start()
        End Using
    End Sub
End Class