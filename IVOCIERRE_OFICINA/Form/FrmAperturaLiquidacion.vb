Public Class FrmAperturaLiquidacion

    Property hnd As Long    
    Private Sub FrmAperturaLiquidacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim obj As New dtoCierreOficina
            Dim ds As DataSet = obj.ListarAgencia()
            With Me.CboOficina
                .DisplayMember = "Nombre_Unidad"
                .ValueMember = "Idunidad_Agencia"
                .DataSource = ds.Tables(0)
                .SelectedValue = dtoUSUARIOS.iIDAGENCIAS
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnApertura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApertura.Click
        Try
            If Not validar() Then
                Return
            End If

            Dim obj As New dtoCierreOficina
            obj.Aperturar(CboFechaApertura.Text, CboOficina.SelectedValue, dtoUSUARIOS.IdLogin, _
                        dtoUSUARIOS.IP, 1)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Function validar() As Boolean
        Dim obj As New dtoCierreOficina

        If Convert.ToDateTime(CboFechaApertura.Text).Date > Convert.ToDateTime(dtoUSUARIOS.m_sFecha).Date Then
            MessageBox.Show("La Fecha de apertura de la liquidacion no puede ser mayor a la de hoy ", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        Dim ds As DataSet = obj.ListarAperturaOficina(dtoUSUARIOS.IdLogin, CboOficina.SelectedValue, CboFechaApertura.Text)
        If ds.Tables(0).Rows.Count > 0 Then
            If Convert.ToInt32(ds.Tables(0).Rows(0)("CERRADO").ToString) = 0 Then
                MessageBox.Show("Existe una liquidacion con fecha : " & ds.Tables(0).Rows(0)("Fecha_Apertura") & " Creada Por : [" & ds.Tables(0).Rows(0)("usuario_creacion") & "] que aun no esta cerrada, no puede aperturar Otra Liquidacion", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else
                MessageBox.Show("Existe una liquidacion con fecha : " & ds.Tables(0).Rows(0)("Fecha_Apertura") & " Creada Por : [" & ds.Tables(0).Rows(0)("usuario_creacion") & "] que se encuentra cerrada, no puede aperturar Otra Liquidacion", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
        End If
        Return True

        'If ds.Tables(0).Rows.Count > 0 Then
        '    MessageBox.Show("La Oficina ya esta aperturada", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return False
        'End If


    End Function

End Class