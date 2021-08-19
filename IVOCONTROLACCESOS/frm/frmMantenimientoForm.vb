Public Class frmMantenimientoForm
    Private Sub frmMantenimientoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If dtoForm.IDCONTROL = 2 Then
                Me.lbCODIFGO.Text = dtoForm.IDFORMULARIO
                Me.txtNombreForm.Text = dtoForm.NOMBRE_FORMULARIO
                Me.txtEtiqueta.Text = dtoForm.ETIQUETA_FORMULARIO
                'datahelper
                'ModuUtil.LlenarComboIDs(dtoCONTROL_ACCESOS.LISTAR_PROCESOS(), cmbProcesos, ModVOCONTROLACCESOS.coll_TipoProcesos, dtoForm.IDMODULO_SISTEMA)
                ModuUtil.LlenarCombo2(dtoCONTROL_ACCESOS.LISTAR_PROCESOS(), cmbProcesos, ModVOCONTROLACCESOS.coll_TipoProcesos, dtoForm.IDMODULO_SISTEMA)
                If dtoForm.ESTADO_REGISTRO = 1 Then
                    Me.ChboxEstado.Checked = True
                Else
                    Me.ChboxEstado.Checked = False
                End If
                'IDROL_USUARIO = Int(rst_datos_Form.Fields.Item(5).Value.ToString)
            Else
                'datahelper
                'ModuUtil.LlenarComboIDs(dtoCONTROL_ACCESOS.LISTAR_PROCESOS(), cmbProcesos, ModVOCONTROLACCESOS.coll_TipoProcesos, dtoForm.IDMODULO_SISTEMA)
                ModuUtil.LlenarCombo2(dtoCONTROL_ACCESOS.LISTAR_PROCESOS(), cmbProcesos, ModVOCONTROLACCESOS.coll_TipoProcesos, dtoForm.IDMODULO_SISTEMA)
                Me.lbCODIFGO.Text = "T000"
                Me.txtNombreForm.Text = ""
                Me.txtEtiqueta.Text = ""
                Me.ChboxEstado.Checked = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If Trim(txtNombreForm.Text.ToString()) <> "" Then
                ErrorProvider1.SetError(txtNombreForm, "")
                If Me.txtEtiqueta.Text <> "" Then
                    ErrorProvider1.SetError(txtEtiqueta, "")
                    If ChboxEstado.Checked = True Then
                        dtoForm.ESTADO_REGISTRO = 1
                    Else
                        dtoForm.ESTADO_REGISTRO = 0
                    End If
                    dtoForm.ETIQUETA_FORMULARIO = Me.txtEtiqueta.Text
                    If dtoForm.IDCONTROL = 1 Then
                        dtoForm.IDFORMULARIO = 250 ' auto generico
                    Else
                        dtoForm.IDFORMULARIO = Me.lbCODIFGO.Text
                    End If
                    dtoForm.IDMODULO_SISTEMA = Int(coll_TipoProcesos.Item(cmbProcesos.SelectedIndex.ToString()))
                    dtoForm.NOMBRE_FORMULARIO = Me.txtNombreForm.Text
                    dtoForm.IDROL_USUARIO = 1
                    dtoForm.InsUpdateFormulario()
                    'datahelper
                    'If dtoForm.rst_datos_Form.EOF = False And dtoForm.rst_datos_Form.BOF = False Then
                    If dtoForm.rst_datos_Form1.Rows.Count > 0 Then
                        MsgBox("Actualizado Corerctamente", MsgBoxStyle.Information, "Seguridad Sistema")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If
                Else
                    ErrorProvider1.SetError(txtEtiqueta, "Debe Ingresar una Etiqueta para este Campo")
                End If
            Else
                ErrorProvider1.SetError(txtNombreForm, "Debe Ingresar el nombre del Formulario")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
End Class