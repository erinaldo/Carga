Public Class FrmMensaje
    Public sFecha As String
    Public iModificado As Integer
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.Top + Me.Height < Screen.PrimaryScreen.WorkingArea.Height Then
            Timer1.Enabled = False
            Me.Opacity = 1
            'Timer2.Enabled = True
        End If

        Me.Top = Me.Top - 3
        Me.Opacity = Me.Opacity + (Me.Opacity / 100)
    End Sub

    Sub Actualiza()
        Try
            Dim obj As New DtoRecojo
            obj.ActualizarModificado(sFecha, iModificado)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub FrmMensaje_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FrmMensaje_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Visible = False
            Me.ShowInTaskbar = False
            Me.Left = Screen.PrimaryScreen.WorkingArea.Width - (Me.Width)
            Me.Top = Screen.PrimaryScreen.WorkingArea.Height
            Me.Opacity = 0.5
            Me.Actualiza()
            Me.Visible = True
            Timer1.Enabled = True
        Catch ex As Exception
            Timer1.Enabled = False
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Timer2.Interval = 50
        If Me.Top - 25 > Screen.PrimaryScreen.WorkingArea.Height Then
            Timer2.Enabled = False
            Me.Opacity = 0
        End If

        Me.Top = Me.Top + 3
        Me.Opacity = Me.Opacity - (Me.Opacity / 100)
    End Sub

    Private Sub FrmMensaje_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Cursor = Cursors.Default
    End Sub
End Class