Imports INTEGRACION_EN
Imports INTEGRACION_LN
Public Class frmAprobarProducto
    Dim strMensaje As String, strFecha As String
    Dim intID As Integer, intCliente As Integer, intSubcuenta As Integer, intOrigen As Integer, intDestino As Integer, intProducto As Integer, intContado As Integer, fecha As String
    Dim blnSalir As Boolean

    Private Sub frmAprobarProducto_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then e.Cancel = True
    End Sub

    Private Sub frmAprobarProducto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.lblMensaje.Text = strMensaje.ToString.Trim
    End Sub

    Private Sub chkActualizar_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkActualizar.CheckedChanged
        If Me.chkActualizar.Checked Then
            Me.lblMensaje2.Text = "Se actualizará las ventas con fecha " & " " & strFecha.ToString.Trim
        Else
            Me.lblMensaje2.Text = "No se actualizará las ventas"
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Dim dlgRespuesta As DialogResult = MessageBox.Show("¿Está seguro de realizar la Aprobación?", "Aprobar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            AprobarSolicitudProducto()
            blnSalir = True
        Else
            blnSalir = False
        End If
    End Sub

    Sub Cargar(mensaje As String, fecha As String, id As Integer, cliente As Integer, subcuenta As Integer, origen As Integer, destino As Integer, _
               producto As Integer, contado As Integer)
        strMensaje = mensaje
        strFecha = fecha
        intID = id
        intCliente = cliente
        intSubcuenta = subcuenta
        intOrigen = origen
        intDestino = destino
        intProducto = producto
        intContado = contado
    End Sub

    Private Sub AprobarSolicitudProducto()
        Cursor = Cursors.WaitCursor
        Try
            Dim objEN As New Cls_ClienteProducto_EN
            Dim objLN As New Cls_ClienteProducto_LN
            Dim intActualizar As Integer = IIf(Me.chkActualizar.Checked, 1, 0)

            objEN.ID = intID
            objEN.Cliente = intCliente
            objEN.Subcuenta = intSubcuenta
            objEN.Origen = intOrigen
            objEN.Destino = intDestino
            objEN.Producto = intProducto
            objEN.Contado = intContado
            objEN.Fecha = strFecha

            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP
            objLN.AprobarSolicitud(objEN, intActualizar)
            MessageBox.Show("Solicitud Aprobada", "Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        blnSalir = True
    End Sub

    Private Sub frmAprobarProducto_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.chkActualizar.Checked = True
    End Sub
End Class