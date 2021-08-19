Public Class frmAtenderEntrega
    Dim blnSalir As Boolean

    Private strDocumento As String
    Public Property Documento() As String
        Get
            Return strDocumento
        End Get
        Set(ByVal value As String)
            strDocumento = value
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

    Private Sub frmAtenderEntrega_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            e.Cancel = True
            blnSalir = True
        End If
    End Sub

    Private Sub frmAtenderEntrega_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.lblDocumento.Text = Documento
        Me.lblConsignado.Text = Consignado
        blnSalir = True
    End Sub

    Private Sub frmAtenderEntrega_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.btnCancelar.Focus()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        'Dim dlgRespuesta As DialogResult
        'dlgRespuesta = MessageBox.Show("¿Está Seguro de Atender la Carga?", "Atender", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        'If dlgRespuesta = vbNo Then
        'blnSalir = False
        'End If
    End Sub
End Class