
Public Class frmActualizarPagosCliente
    Dim colCliente As New Collection
    Dim autoCliente As New AutoCompleteStringCollection

    Sub Actualizar(cliente As String)
        Dim intRegistros As Integer = 0
        Try
            Dim obj As New dtoCuentaCorriente
            Dim dr As System.Data.SqlClient.SqlDataReader = obj.ObtienePagosCliente(cnnSQL, cliente)
            Dim intOpcion As Integer
            Dim str6 As String, str7 As String, str8 As String, str9 As String
            Do
                Do While dr.Read
                    intOpcion = dr(0)
                    If intOpcion = 1 Or intOpcion = 2 Then
                        str8 = IIf(IsDBNull(dr(8)), "", dr(8))
                        str9 = IIf(IsDBNull(dr(9)), "", dr(9))
                        obj.ActualizaHistoricoPagos(dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), str8, str9, dr(10), _
                        dr(11), dr(12), dr(13), dr(14), dr(15), dr(16), dr(17), dr(18), dr(19), dr(20), _
                        dr(21), dr(22), dr(0))
                    ElseIf intOpcion = 3 Then
                        str6 = IIf(IsDBNull(dr(6)), "", dr(6))
                        str7 = IIf(IsDBNull(dr(7)), "", dr(7))
                        obj.ActualizaHistoricoPagos(dr(1), dr(2), dr(3), dr(4), "", "", dr(5), str6, str7, dr(8), _
                        dr(9), dr(10), dr(11), dr(12), dr(13), dr(14), dr(15), dr(16), dr(17), dr(18), _
                        dr(19), dr(20), dr(0))
                    ElseIf intOpcion = 4 Then
                        obj.ActualizaHistoricoPagos(dr(1), dr(2), dr(3), dr(4), dr(5), "", dr(6), dr(7), dr(8), dr(9), _
                        dr(10), dr(11), dr(12), dr(13), dr(14), dr(15), dr(16), dr(17), dr(18), dr(19), _
                        dr(20), dr(21), dr(0))
                    ElseIf intOpcion = 5 Then
                        obj.ActualizaHistoricoPagos(dr(1), dr(2), dr(3), dr(4), "", "", dr(5), dr(6), dr(7), dr(8), _
                        dr(9), dr(10), dr(11), dr(12), dr(13), dr(14), dr(15), dr(16), dr(17), dr(18), _
                        dr(19), dr(20), dr(0))
                    End If
                    intRegistros += 1
                    If intRegistros = 79 Then
                        Dim a As Integer = 1
                    End If
                Loop
                dr.NextResult()
            Loop While dr.NextResult
            cnnSQL.Close()

            If intRegistros > 0 Then 'se exportaron pagos del ofisys
                dtoCuentaCorriente.ActualizaCuentaCorriente(cliente)
            End If

            Cursor = Cursors.Default
            Me.Text = "Actualizar Pagos del Cliente"
            MessageBox.Show("Se Realizó la Actualización", "Actualizar Pagos", MessageBoxButtons.OK)
        Catch ex As Exception
            Me.Text = "Actualizar Pagos del Cliente"
            Cursor = Cursors.Default
            cnnSQL.Close()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmActualizarPagosCliente_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim obj As New dtoCuentaCorriente
        Dim dt As DataTable = obj.ListarCliente

        Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
        ObjProcesos.fnCargar_iWin_r(Me.txtCliente, dt.DefaultView, colCliente, autoCliente, 0)
    End Sub

    Private Sub txtCliente_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Not autoCliente.IndexOf(txtCliente.Text) = -1 Then
                Dim ObjPersona As New ClsLbTepsa.dtoPersona
                With ObjPersona
                    .IDPERSONA = Int(colCliente.Item(autoCliente.IndexOf(Me.txtCliente.Text).ToString))
                    .IDTIPO_PERSONA = 0
                    .CODIGO_CLIENTE = "NULL"
                    'Datahelper
                    ObjPersona.FNLISTAR_PERSONA(.IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                    Me.txtCodigoCliente.Text = .CODIGO_CLIENTE
                End With
            Else
                Me.txtCodigoCliente.Text = ""
            End If
        End If
    End Sub

    Private Sub txtCliente_LostFocus(sender As Object, e As System.EventArgs) Handles txtCliente.LostFocus
        If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
            Me.txtCliente.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub

    Private Sub txtCodigoCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCliente.KeyPress
        Try
            If Asc(e.KeyChar) = Keys.Enter Then
                If Me.txtCodigoCliente.Text.Trim.Length > 0 Then
                    Dim obj As New dtoCarga
                    Dim strCodigoCliente As String = Me.txtCodigoCliente.Text.Trim
                    Dim dt As DataTable = obj.ObtieneCliente(strCodigoCliente)
                    If dt.Rows.Count > 0 Then
                        Me.txtCliente.Text = dt.Rows(0).Item("cliente")
                    Else
                        MessageBox.Show("El Cliente no Existe", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCodigoCliente_LostFocus(sender As Object, e As System.EventArgs) Handles txtCodigoCliente.LostFocus
        If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
            Me.txtCliente.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        Dim dlgRespuesta As DialogResult = MessageBox.Show("¿Está Seguro de Realizar la Actualización?", "Actualizar Pagos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            If autoCliente.IndexOf(Me.txtCliente.Text) = -1 Then
                MessageBox.Show("Seleccione el Cliente", "Actualizar Pagos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtCliente.Focus()
                Return
            End If

            Cursor = Cursors.AppStarting
            Me.Text = Me.Text & Space(15) & "Procesando..."
            Dim strCliente As String = Me.txtCodigoCliente.Text.Trim
            Actualizar(strCliente)
            'Me.btnCancelar.Enabled = False
            'hilo.RunWorkerAsync()
        End If
    End Sub

    'Private Sub hilo_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles hilo.DoWork
    '    Dim strCliente As String = Me.txtCodigoCliente.Text.Trim
    '    Actualizar(strCliente)
    'End Sub

    'Private Sub hilo_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles hilo.RunWorkerCompleted
    '    Cursor = Cursors.Default
    '    Me.btnCancelar.Enabled = True
    'End Sub
End Class