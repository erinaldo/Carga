Public Class FrmConsulFactuCompartivo_sin_notacred
#Region "Variable Privadas"
    Private ObjReport As ClsLbTepsa.dtoFrmReport '
    Dim bIngreso As Boolean = False
    Public hnd As Long
#End Region
#Region "Variable contexto"
    Dim dvListar_facturas As New DataView
    Dim Colllistar_persona_todos As New Collection
    Dim Iwinlistar_persona_todos As New AutoCompleteStringCollection
#End Region


#Region "Eventos"

    Private Sub FrmConsulFactuCompartivo_sin_notacred_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmConsulFactuCompartivo_sin_notacred_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Me.ShadowLabel1.Text = "Cuadro de Facturación Crédito y Cobranzas x G.E."
            pl_formulario = 2

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True


        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    '    Public Overrides Sub FrmConsulFactuEmiti_MenuImprimir() Handles Me.MenuImprimir
    '        Try
    '            ObjReport.Dispose()
    '        Catch

    '        End Try

    '        ObjReport = New ClsLbTepsa.dtoFrmReport

    '        Select Case Me.TabMante.SelectedIndex
    '            Case 0
    '                Try
    '                    If Me.DGV3.RowCount <= 0 Then
    '                        MsgBox("No existen registro", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
    '                        Exit Sub
    '                    End If
    '                    Dim ObjFactura As New ClsLbTepsa.dtoFACTURA
    '                    Dim p_titulo As String

    '                    If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
    '                        ObjFactura.IDPERSONA = 0
    '                        p_titulo = ""
    '                    Else

    '                        ObjFactura.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
    '                        p_titulo = "Cliente: " & Me.txtidpersona.Text
    '                    End If
    '                    If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjFactura.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_INICIO = "NULL"
    '                    If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjFactura.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_FINAL = "NULL"
    '                    '
    '                    With ObjFactura

    '                        .IDFACTURA = Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index)("IDFACTURA")

    '                        'Try ObjReport.Dispose() Catch End Try ObjReport = New ClsLbTepsa.dtoFrmReport
    '                        ObjReport.rutaRpt = PathFrmReport
    '                        ObjReport.conectar(rptservice, rptuser, rptpass)

    '                        Dim PREFACTURA As String


    '                        If Not Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index).IsNull("NRO_PREFACTURA") Then

    '                            If Not Trim(Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index)("NRO_PREFACTURA")) = "" Then
    '                                PREFACTURA = "Prefactura Nro.:" & Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index)("NRO_PREFACTURA")
    '                            Else
    '                                PREFACTURA = ""
    '                            End If
    '                        Else
    '                            PREFACTURA = ""
    '                        End If

    '                        ObjReport.printrpt_sub_report("GE101_2.rpt", False, "", "GE100.rpt", _
    '                        "p_idpersona;" & .IDPERSONA, _
    '                        "p_rango_fecha;" & "(Desde el " & .FECHA_INICIO & " hasta el " & .FECHA_FINAL & ")", _
    '"p_titulo;" & p_titulo, _
    '                        "p_fecha_inicial;" & .FECHA_INICIO, _
    '                        "p_fecha_final;" & .FECHA_FINAL)

    '                    End With
    '                Catch ex As Exception
    '                    MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '                End Try
    '        End Select
    '    End Sub
#End Region

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)

    End Sub
End Class
