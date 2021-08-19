Public Class FrmRecepcionGuias
    Dim daControl_Guia As New OleDb.OleDbDataAdapter
    Dim dtControl_Guia As New System.Data.DataTable
    Dim dvControl_Guia As New System.Data.DataView
    Private ObjReport As ClsLbTepsa.dtoFrmReport
    Dim bIngreso As Boolean = False
    Dim intContador As Integer = 0
    Public hnd As Long

    Private Sub FrmRecepcionGuias_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.txtNroGuia.Focus()
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub
    Private Sub FrmRecepcionGuias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ' Me.Height = 250
            intContador = 0
            txtFechaRecepcion.Text = dtoUSUARIOS.m_sFecha
            'ModuUtil.Formato_GridView(dtGridViewGuias)
            '  dtControl_Guia.Clear()
            '07/09/2009 - Cambiado por data-helper
            If objRecepcionGuias.fnTIPO_COMPROBANTE() = True Then
                ModuUtil.LlenarComboIDs_dt(objRecepcionGuias.dt_cur_Tipo_Documento, cmbTipoDocumento, objRecepcionGuias.coll_Tipo_Documento, 3)
            End If
            '
            Formato_GridView(dtGridViewDocumentos)
            Formato_GridView(dtGridViewArt)

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub RecepcionGuias()
        Try

            'bloque
            'If fnValidar_Rol("17") = True Or fnValidar_Rol("18") = True Or fnValidar_Rol("19") = True Then
            If Acceso.SiRol(G_Rol, Me, 1) Then
                txtNroGuia.Text = RellenoRight(13, txtNroGuia.Text)
                objRecepcionGuias.iIdestado_Registro = 22
                objRecepcionGuias.iNro_Guia = LTrim(txtNroGuia.Text)
                objRecepcionGuias.fecha_Cargo = Me.txtFechaRecepcion.Text

                If objRecepcionGuias.fnRECEPCION_GUIAS_CARGO(dtGridViewDocumentos, dtGridViewArt) = True Then
                    txtCliente.Text = objRecepcionGuias.iCliente
                    txtNroRuc.Text = objRecepcionGuias.iNroRuc
                    txtFecha_Guia.Text = objRecepcionGuias.iFecha_Guia
                    txtFecha_Cargo.Text = objRecepcionGuias.iFecha_Cargo
                    txtOrigen.Text = objRecepcionGuias.iOrigen
                    TxtDestino.Text = objRecepcionGuias.iDestino
                    txtEstado.Text = objRecepcionGuias.iEstado


                    txtPrecio_Vol.Text = objRecepcionGuias.iPrecio_Vol
                    txtPrecio_Peso.Text = objRecepcionGuias.iPrecio_Peso
                    txtPrecio_Sobre.Text = objRecepcionGuias.iPrecio_Sobre

                    txtTota_Peso.Text = objRecepcionGuias.iTotal_Peso
                    txtTota_Vol.Text = objRecepcionGuias.iTotal_Vol
                    txtTota_Sobre.Text = "" 'objRecepcionGuias.iTotal_Sobre

                    txtPieza_Peso.Text = objRecepcionGuias.iCantidad_Peso
                    txtPieza_Vol.Text = objRecepcionGuias.iCantidad_Vol
                    txtPieza_Sobre.Text = objRecepcionGuias.iCantidad_Sobre
                    '07/09/2009 - 
                    Dim ldb_total_peso As Double = CType(objRecepcionGuias.iTotal_Peso, Double)
                    Dim ldb_precio_peso As Double = CType(objRecepcionGuias.iPrecio_Peso, Double)
                    Dim ldb_total_volumen As Double = CType(objRecepcionGuias.iTotal_Vol, Double)
                    Dim ldb_precio_volumen As Double = CType(objRecepcionGuias.iPrecio_Vol, Double)
                    Dim ldb_Monto_Base As Double = CType(objRecepcionGuias.iMonto_Base, Double)
                    Dim ldb_cantidad_sobre As Double = CType(objRecepcionGuias.iCantidad_Sobre, Double)
                    '
                    txtSubTotal_Peso.Text = Format(ldb_total_peso * ldb_precio_peso, "##,###,###.000")
                    txtSubTotal_Vol.Text = Format(ldb_total_volumen * ldb_precio_volumen, "##,###,###.000")
                    txtSubTotal_Sobre.Text = Format(ldb_cantidad_sobre * ldb_Monto_Base, "##,###,###.000")


                    txtMonto_Base.Text = objRecepcionGuias.iMonto_Base
                    txtSub_Total.Text = objRecepcionGuias.iTotal_Costo - objRecepcionGuias.iMonto_Impuesto
                    txtMonto_IGV.Text = objRecepcionGuias.iMonto_Impuesto
                    txtCosto_Total.Text = objRecepcionGuias.iTotal_Costo

                    If objRecepcionGuias.iOpcion = 1 Then
                        intContador += 1
                        Me.lblContador.Text = intContador
                    End If

                    'dtControl_Guia.Clear()
                    'daControl_Guia.Fill(dtControl_Guia, objRecepcionGuias.cur_Datos)
                    'dvControl_Guia = dtControl_Guia.DefaultView
                    'dtGridViewGuias.DataSource = dvControl_Guia
                Else
                    txtCliente.Text = ""
                    txtNroRuc.Text = ""
                    txtFecha_Guia.Text = ""
                    txtFecha_Cargo.Text = ""
                    txtOrigen.Text = ""
                    TxtDestino.Text = ""
                    txtEstado.Text = ""
                    txtCosto_Total.Text = ""
                    txtPrecio_Sobre.Text = ""
                    txtPrecio_Vol.Text = ""
                    txtPrecio_Peso.Text = ""

                    txtTota_Peso.Text = ""
                    txtTota_Vol.Text = ""
                    txtTota_Sobre.Text = ""

                    txtPieza_Peso.Text = ""
                    txtPieza_Vol.Text = ""
                    txtPieza_Sobre.Text = ""

                    txtSubTotal_Peso.Text = ""
                    txtSubTotal_Vol.Text = ""
                    txtSubTotal_Sobre.Text = ""

                    txtMonto_Base.Text = ""
                    txtSub_Total.Text = ""
                    txtMonto_IGV.Text = ""

                    'If dtGridViewDocumentos.RowCount > 1 Then
                    '    dtGridViewDocumentos.Rows().Clear()
                    'End If

                    'If dtGridViewArt.RowCount > 1 Then
                    '    dtGridViewArt.Rows().Clear()
                    'End If
                End If
                If Me.txtFechaRecepcion.Enabled And Me.txtFechaRecepcion.Visible Then
                    Me.txtFechaRecepcion.Focus()
                End If
                Me.txtNroGuia.Focus()
            Else
                MsgBox("No Tiene Permiso para realizar la operación", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Function RellenoRight(ByVal Nro As Integer, ByVal texto As String) As String
        Dim cCount As Integer = Len(texto)
        Dim sNewCadena As String = texto
        If Nro = cCount Then
            Return texto
        End If
        Try
            Dim i As Integer
            For i = 1 To Nro - cCount
                sNewCadena = "0" & sNewCadena
            Next
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return sNewCadena
    End Function

    Private Sub txtNroGuia_Enter(sender As Object, e As System.EventArgs) Handles txtNroGuia.Enter
        txtNroGuia.SelectAll()
    End Sub

    Private Sub txtNroGuia_GotFocus(sender As Object, e As System.EventArgs) Handles txtNroGuia.GotFocus
        txtNroGuia.SelectAll()
    End Sub

    Private Sub txtNroGuia_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNroGuia.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                RecepcionGuias()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub dtFechaRecepcion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFechaRecepcion.ValueChanged
        Try
            txtFechaRecepcion.Text = dtFechaRecepcion.Text
        Catch ex As Exception

        End Try
    End Sub
    Public Sub RptRecepcion_Guias()
        Try
            ObjReport.Dispose()
        Catch

        End Try
        ObjReport = New ClsLbTepsa.dtoFrmReport

        Try
            Dim objFrm As New FrmFechas()
            'If objFrm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Acceso.Asignar(objFrm, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                If objFrm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ObjReport.rutaRpt = PathFrmReport   ' Modificado 
                    ObjReport.conectar("tepsa", "titan", "titan")
                    ObjReport.printrpt(False, "", "RptRecepcionGuias.rpt", "FECHAINICIO;" & objFrm.sInicio, "FECHAFINAL;" & objFrm.sFinal)
                End If
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            objFrm = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        RptRecepcion_Guias()
    End Sub
    Private Sub numericTextboxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroGuia.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
                'ElseIf e.KeyChar = "." Then
                'If Not (tb.SelectedText = "." Or IsNumeric(tb.Text & e.KeyChar)) Then
                'e.Handled = True
                'End If
                'ElseIf e.KeyChar = "-" Then
                'If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
                'e.Handled = True
                'End If
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean = True
        Dim flat As Boolean = True
        Try
            Dim var As Integer = msg.WParam.ToInt32
            If msg.WParam.ToInt32 = Keys.Enter Then
                If txtNroGuia.Focused = True Then
                    RecepcionGuias()
                End If
            ElseIf msg.WParam.ToInt32 = Keys.F1 Then
                If txtNroGuia.Focused = True Then
                    RecepcionGuias()
                End If
            ElseIf msg.WParam.ToInt32 = Keys.F6 Then
                RptRecepcion_Guias()
            ElseIf msg.WParam.ToInt32 = Keys.F5 Then 'Nuevo
                dtControl_Guia.Clear()
            ElseIf msg.WParam.ToInt32 = Keys.F12 Then
                Close()
            Else
                flat = MyBase.ProcessCmdKey(msg, KeyData)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flat

    End Function

    Private Sub FrmRecepcionGuias_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch

        End Try
    End Sub

    Private Sub FrmRecepcionGuias_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub txtNroGuia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNroGuia.TextChanged

    End Sub
End Class
