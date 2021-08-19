Imports INTEGRACION_LN
Imports INTEGRACION_EN

Public Class FrmDesactivarProducto
    Dim intCliente As Integer
    Dim intProducto As Integer
    Dim strCliente As String
    Dim strProducto As String
    Dim blnProductoCuenta As Boolean
    Dim blnSalir As Boolean = True
    Dim intID As Integer

    Private Sub FrmDesactivarProducto_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmDesactivarProducto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim obj As New Cls_ClienteProducto_LN
        Dim intProductoRequiereAprobacion As Integer = 0
        Dim intProductoDefecto As Integer = 0
        Dim intCuentaProductoRequiereAprobacion As Integer

        Dim strMensaje As String = ""
        Dim dt As DataTable = obj.CargarDatosProducto(intCliente, intProducto)
        If dt.Rows.Count > 0 Then
            intProductoRequiereAprobacion = dt.Rows(0).Item("requiere").ToString
            intProductoDefecto = dt.Rows(0).Item("defecto").ToString
            intCuentaProductoRequiereAprobacion = dt.Rows(0).Item("producto_requiere").ToString

            Me.chkDesactivar.Visible = False : Me.chkDesactivar.Checked = False
            Me.chkCancelar.Visible = False : Me.chkCancelar.Checked = False
            If intProductoDefecto = 1 Then 'producto por defecto
                If intCuentaProductoRequiereAprobacion > 0 Then 'si cliente tiene asociado productos que requieren aprobacion
                    strMensaje = Chr(13) & Chr(13) & "Antes de Desactivar el Producto por Defecto, desactive los Productos que requieren aprobación"
                    btnCancelar.Visible = False
                    btnAceptar.Left = 180
                Else
                    If blnProductoCuenta Then
                        strMensaje = "Se Desactivarán:" & Chr(13) & Chr(13)
                        strMensaje &= "Producto seleccionado: " & strProducto & Chr(13)
                        strMensaje &= "Línea de Crédito del Cliente: " & strCliente
                        Me.chkDesactivar.Visible = True : Me.chkDesactivar.Checked = True
                        Me.chkCancelar.Visible = True : Me.chkCancelar.Checked = False
                    Else
                        strMensaje = "Se Desactivará:" & Chr(13) & Chr(13)
                        strMensaje &= "Producto seleccionado: " & strProducto & Chr(13)
                        Me.chkDesactivar.Visible = True : Me.chkDesactivar.Checked = False
                        Me.chkCancelar.Visible = True : Me.chkCancelar.Checked = False
                    End If
                End If
            Else 'producto que requiere aprobacion
                If blnProductoCuenta Then 'si producto esta asociado a nivel de cuenta
                    strMensaje = "Se Desactivará:" & Chr(13) & Chr(13)
                    strMensaje &= "Producto Seleccionado: " & strProducto & Chr(13)
                    strMensaje &= "Línea de Crédito del Cliente: " & strCliente
                    Me.chkDesactivar.Visible = True : Me.chkDesactivar.Checked = True
                    Me.chkCancelar.Visible = True : Me.chkCancelar.Checked = False
                Else
                    strMensaje = "Se Desactivará:" & Chr(13) & Chr(13)
                    strMensaje &= "Producto seleccionado: " & strProducto & Chr(13)
                    Me.chkDesactivar.Checked = False : Me.chkDesactivar.Visible = False
                    Me.chkCancelar.Checked = False : Me.chkCancelar.Visible = False
                End If
            End If
            Me.lblMensaje.Text = strMensaje
        End If
    End Sub

    Sub Cargar(cliente As Integer, producto As Integer, cliente2 As String, producto2 As String, ProductoCuenta As Boolean, ID As Integer)
        intCliente = cliente
        intProducto = producto
        strCliente = cliente2
        strProducto = producto2
        blnProductoCuenta = ProductoCuenta
        intID = ID
    End Sub

    Private Sub chkLineaCredito_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDesactivar.CheckedChanged
        If Me.chkDesactivar.Visible Then
            If chkDesactivar.Checked = False Then
                If Not chkCancelar.Checked Then
                    Me.lblMensaje.Text = "Se Desactivará:" & Chr(13)
                    Me.lblMensaje.Text &= "Producto Seleccionado: " & strProducto & Chr(13) & Chr(13)
                End If
            Else
                chkCancelar.Checked = False
                Me.lblMensaje.Text = "Se Desactivarán:" & Chr(13) & Chr(13)
                Me.lblMensaje.Text &= "Producto Seleccionado: " & strProducto & Chr(13)
                Me.lblMensaje.Text &= "Línea de Crédito del Cliente: " & strCliente
            End If
        End If
    End Sub


    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        If Me.btnCancelar.Visible Then
            If MessageBox.Show("¿Está seguro de Desactivar el Producto para la Venta Crédito?", "Desactivar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Dim intLinea As Integer = 0
                Dim intDefecto As Integer = 0
                'If Me.chkLineaCredito.Visible Then
                If Me.chkDesactivar.Checked Then
                    intLinea = IIf(Me.chkDesactivar.Checked, 1, 0)
                    intDefecto = IIf(Me.chkDesactivar.Checked, 0, 1)
                ElseIf Me.chkCancelar.Checked Then
                    intLinea = IIf(Me.chkCancelar.Checked, 2, 0)
                    intDefecto = IIf(Me.chkCancelar.Checked, 0, 1)
                End If
                Aceptar(intLinea, intDefecto)
            Else
                blnSalir = False
            End If
        Else
            blnSalir = True
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        blnSalir = True
        Close()
    End Sub

    Sub Aceptar(linea As Integer, defecto As Integer)
        Try
            Dim objLN As New Cls_ClienteProducto_LN
            Dim objEN As New Cls_ClienteProducto_EN

            objEN.ID = intID
            objEN.Cliente = intCliente
            objEN.Usuario = dtoUSUARIOS.IdLogin
            objEN.IP = dtoUSUARIOS.IP

            objLN.DesactivarProducto(objEN, linea, defecto)
            blnSalir = True

        Catch ex As Exception
            blnSalir = False
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkCancelar_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkCancelar.CheckedChanged
        If Me.chkCancelar.Visible Then
            If chkCancelar.Checked = False Then
                If Not chkCancelar.Checked Then
                    Me.lblMensaje.Text = "Se Desactivará:" & Chr(13)
                    Me.lblMensaje.Text &= "Producto Seleccionado: " & strProducto & Chr(13) & Chr(13)
                End If
            Else
                chkDesactivar.Checked = False
                Me.lblMensaje.Text = "Se Desactivará:" & Chr(13)
                Me.lblMensaje.Text &= "Producto Seleccionado: " & strProducto & Chr(13) & Chr(13)
                Me.lblMensaje.Text &= "Se Cancelará:" & Chr(13)
                Me.lblMensaje.Text &= "Línea de Crédito del Cliente: " & strCliente
            End If
        End If
    End Sub
End Class