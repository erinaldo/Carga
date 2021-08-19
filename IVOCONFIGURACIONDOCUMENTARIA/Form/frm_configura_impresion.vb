'Imports System.Data.OleDb
Public Class frm_configura_impresion
    Private iForm As Integer
    Public hnd As Long
    'Dim da As New OleDbDataAdapter
    Dim dTable As New DataTable()
    Dim dv As New DataView
    'Dim bestado As Boolean = True
    'Dim f As DataRow
    'Private Sub frmPrueba_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    InitConexion()
    '    bestado = objCONFIGURACION_DOCUMENTARIA.fnsp_INCREMENTAR_NRO_DOCUMENTO
    '    If bestado = True Then
    '        da.Fill(dTable, objCONFIGURACION_DOCUMENTARIA.rst_Correlativo)
    '    End If
    'End Sub
    Public sImp As String
    Public iTamaño As Integer
    Public iSuperior As Integer
    Public iIzquierda As Integer

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        bControl = False
        Me.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.Tag = 1 Then
            bControl = True
            sIPMAQUINA = lstIP.SelectedValue
        ElseIf Me.Tag = 2 Then
            bControl = True
            If lstIP.Text.Trim = "(Ninguna)" Then
                sImpresora = ""
                For i As Integer = 1 To 3
                    mParametros(i) = 0
                Next
            Else
                sImpresora = lstIP.Text
                mParametros(1) = IIf(Me.NudTamaño.Value = 0, 0, Me.NudTamaño.Value)
                mParametros(2) = IIf(Me.NudSuperior.Value = 0, 0, Me.NudSuperior.Value)
                mParametros(3) = IIf(Me.NudIzquierda.Value = 0, 0, Me.NudIzquierda.Value)
            End If
        End If
        Me.Close()
    End Sub

    Private Sub frm_configura_impresion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frmPrueba_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim bestado As Boolean
            bControl = False

            If Me.Tag = 1 Then
                bestado = objCONFIGURACION_DOCUMENTARIA.fnLISTAR_IP()
                If bestado = True Then
                    dTable.Clear()
                    'datahelper
                    'da.Fill(dTable, objCONFIGURACION_DOCUMENTARIA.rst_Listar_IP)
                    dTable = objCONFIGURACION_DOCUMENTARIA.rst_Listar_IP
                    dv = dTable.DefaultView
                    lstIP.DataSource = dv
                    lstIP.ValueMember = dTable.Columns(0).ColumnName
                End If
            ElseIf Me.Tag = 2 Then
                bestado = objCONFIGURACION_DOCUMENTARIA.fnIMPRESORAS()
                If bestado Then
                    Dim cad As String
                    lstIP.Items.Clear()
                    For Each cad In objCONFIGURACION_DOCUMENTARIA.arrImpresoras
                        lstIP.Items.Add(cad)
                    Next
                    lstIP.SelectedIndex = 0
                Else
                    Button1.Enabled = False
                End If
            End If

            lstIP.SelectedItem = sImp
            Me.NudTamaño.Value = iTamaño
            Me.NudSuperior.Value = iSuperior
            Me.NudIzquierda.Value = iIzquierda

            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        'InitConexion()
    End Sub


End Class