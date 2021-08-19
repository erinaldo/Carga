Public Class FrmControl_Impresoras
    Dim col_Tipo_Impresoras As New Collection
    'datahelper
    'Dim rst_cur_datos As New ADODB.Recordset
    Dim rst_cur_datos As DataTable
    Dim objControl_Impresora As New dtoControl_Impresora
    Dim bIngreso As Boolean = False
    Public hnd As Long
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Try
            If Me.txtNombreImpresora.Text = "" Or Me.txtNombreImpresora.Text = " " Then
                MsgBox("Debe Poner Un Nombre de Impresora...", MsgBoxStyle.Information, "Seguridad Sistema")
                Return
            End If
            objControl_Impresora.v_Idtipo_Impresora = Int(col_Tipo_Impresoras.Item(cmbTipo_Impresora.SelectedIndex.ToString()))
            objControl_Impresora.v_Control_Inpresoras = Me.txtNombreImpresora.Text
            If MsgBox("Esta seguro de realizar esta Operacion..", MsgBoxStyle.YesNoCancel, "Seguridad Sistema") = MsgBoxResult.Yes Then
                If objControl_Impresora.v_IdControl_Inpresoras = 0 Then
                    objControl_Impresora.v_control = 1
                    'datahelper
                    'rst_cur_datos = objControl_Impresora.fnINSUP_CONTRO_IMPRESORAS()
                    'If rst_cur_datos.EOF = False And rst_cur_datos.BOF = False Then
                    '    MsgBox(rst_cur_datos.Fields.Item("MSGBOX").Value, MsgBoxStyle.Information, "Seguridad Sistema")
                    'End If
                    rst_cur_datos = objControl_Impresora.fnINSUP_CONTRO_IMPRESORAS()
                    If rst_cur_datos.Rows.Count > 0 Then
                        MsgBox(rst_cur_datos.Rows(0).Item("MSGBOX"), MsgBoxStyle.Information, "Seguridad Sistema")
                    End If
                Else
                    If Int(objControl_Impresora.v_IdControl_Inpresoras.ToString()) > 0 Then
                        objControl_Impresora.v_control = 0
                        rst_cur_datos = objControl_Impresora.fnINSUP_CONTRO_IMPRESORAS()
                        If rst_cur_datos.Rows.Count > 0 Then
                            MsgBox(rst_cur_datos.Rows(0).Item("MSGBOX"), MsgBoxStyle.Information, "Seguridad Sistema")
                        End If
                        'datahelper
                        'rst_cur_datos = objControl_Impresora.fnINSUP_CONTRO_IMPRESORAS()
                        'If rst_cur_datos.EOF = False And rst_cur_datos.BOF = False Then
                        '    MsgBox(rst_cur_datos.Fields.Item("MSGBOX").Value, MsgBoxStyle.Information, "Seguridad Sistema")
                        'End If
                    Else
                        MsgBox("Revice sus Datos No puede Realizar esta Operacoion...", MsgBoxStyle.Information, "Seguridad Sistema")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub FrmControl_Impresoras_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmControl_Impresoras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            objControl_Impresora.v_IdControl_Inpresoras = "0"
            objControl_Impresora.v_Idtipo_Impresora = 1
            'datahelper
            'rst_cur_datos = objControl_Impresora.fnGetTipo_Impresora()
            'If rst_cur_datos.BOF = False And rst_cur_datos.EOF = False Then
            '    objControl_Impresora.v_Idtipo_Impresora = rst_cur_datos.Fields.Item("IMPRESION").Value
            '    objControl_Impresora.v_Control_Inpresoras = rst_cur_datos.Fields.Item("Control_Impresoras").Value
            '    objControl_Impresora.v_IdControl_Inpresoras = rst_cur_datos.Fields.Item("Idcontrol_Impresoras").Value
            '    Me.txtNombreImpresora.Text = objControl_Impresora.v_Control_Inpresoras
            'End If
            'ModuUtil.LlenarComboIDs(rst_cur_datos.NextRecordset, cmbTipo_Impresora, col_Tipo_Impresoras, objControl_Impresora.v_Idtipo_Impresora)

            Dim ds As DataSet = objControl_Impresora.fnGetTipo_Impresora()
            rst_cur_datos = ds.Tables(0)
            If rst_cur_datos.Rows.Count > 0 Then
                objControl_Impresora.v_Idtipo_Impresora = rst_cur_datos.Rows(0).Item("IMPRESION")
                objControl_Impresora.v_Control_Inpresoras = rst_cur_datos.Rows(0).Item("Control_Impresoras")
                objControl_Impresora.v_IdControl_Inpresoras = rst_cur_datos.Rows(0).Item("Idcontrol_Impresoras")
                Me.txtNombreImpresora.Text = objControl_Impresora.v_Control_Inpresoras
            End If
            ModuUtil.LlenarCombo2(ds.Tables(1), cmbTipo_Impresora, col_Tipo_Impresoras, objControl_Impresora.v_Idtipo_Impresora)

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub btnPredeterminado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPredeterminado.Click
        Try
            txtNombreImpresora.Text = "PRNZEBRA"
        Catch ex As Exception
        End Try
    End Sub
End Class