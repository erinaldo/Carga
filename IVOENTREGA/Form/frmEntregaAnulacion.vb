Public Class frmEntregaAnulacion
#Region "Propiedades"
    Private strDocumento As String
    Public Property Documento() As String
        Get
            Return strDocumento
        End Get
        Set(ByVal value As String)
            strDocumento = value
        End Set
    End Property

#End Region

    Private Sub frmEntregaAnulacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.lblMensaje.Text = "¿Está Seguro de Anular el Documento " & Documento & "?" & Chr(13) & Chr(13) & _
        "La anulación revertirá el estado del documento a Llegada"

    End Sub

    Private Sub frmEntregaAnulacion_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.txtMotivo.Focus()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If txtMotivo.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese el Motivo de la Anulación", "Anular", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = Windows.Forms.DialogResult.None
            Me.txtMotivo.Text = ""
            Me.txtMotivo.Focus()
        End If
    End Sub
End Class