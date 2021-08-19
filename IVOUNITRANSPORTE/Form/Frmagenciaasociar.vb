'Imports System.Windows.Forms
'Imports System.Data
'Imports System.Data.OleDb
'Imports System.Drawing
'Imports System.Collections
Public Class Frmagenciaasociar
    'Usando las clases 
    Dim classasoagencia As New dtoasociaagencia
#Region "Declarando variables"
    'datahelper
    'Dim rstagencia As New ADODB.Recordset
    Dim rstagencia As DataTable
    Dim dtagencia As New DataTable
    'Dim dvagencia As New DataView
    'Dim dr4 As New OleDb.OleDbDataAdapter
    Public dvseleccionado As New DataView
    Public dtDeleccionado As DataTable
    Public hnd As Long
#End Region

#Region "Eventos"

    Private Sub Frmagenciaasociar_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub Frmagenciaasociar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub Frmagenciaasociar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim dvagenciaclon As New DataView
        ' Para devolver al otro lado. 
        dvagenciaclon = CType(dvagencia, DataView)
        dvagenciaclon.RowFilter = "seleccionar = 1"
        '
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.dvseleccionado = dvagenciaclon
        '
    End Sub
    Private Sub Frmagenciaasociar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim rst_oracle As New ADODB.Recordset
        ShadowLabel1.Text = "Asocia - Agencia"
        Try
            classasoagencia.idunidadtransporte = Modunitransporte.idunidadtrans
            'datahelper
            'rstagencia = classasoagencia.getagenciaasociar
            'dr4.Fill(dtagencia, rstagencia)
            rstagencia = classasoagencia.getagenciaasociar
            dtagencia = rstagencia
            dvagencia = dtagencia.DefaultView
            genera_grilla()
            '

            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)

        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Asignando él valor ")
        End Try
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim filtro As String
        filtro = Me.TextBox1.Text
        If filtro = "" Then
            dvagencia.RowFilter = ""
        Else
            dvagencia.RowFilter = "nombre_agencia like '%" & filtro & "%'"
        End If

        'dvagencia.RowFilter = "seleccionar = 1"
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub

#End Region

#Region "Funciones"
    Sub genera_grilla()
        Dim gmdtruta As New System.Data.DataTable
        Dim gmdvruta As New DataView
        'Configurando la grilla  
        Try
            With DGVagenciasocia
                .AutoGenerateColumns = False 'Las filas no se generen automaticamente de la bd
                ' Creando el data source - Omendoza (Falta recupera el data source)
                .DataSource = dvagencia
                .BackColor = SystemColors.Info
                .BackgroundColor = SystemColors.Info
                .RowHeadersVisible = False
                .BorderStyle = BorderStyle.Fixed3D
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = False
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                '
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                '.SelectionMode = DataGridViewSelectionMode.CellSelect
                .VirtualMode = True
                '.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End With
            'Configura los campos
            Dim tbasocia As New DataGridViewCheckBoxColumn
            With tbasocia   '1
                .HeaderText = "Asocia"
                .Name = "Asocia"
                .DataPropertyName = "seleccionar"
                .Width = 62
                .ThreeState = False
                .TrueValue = 1   'Asociar  
                .FalseValue = 0
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End With
            DGVagenciasocia.Columns.Add(tbasocia)
            '
            Dim chbprincipal As New DataGridViewCheckBoxColumn
            With chbprincipal   '2
                .HeaderText = "Actual"
                .Name = "ACTUAL"
                .DataPropertyName = "ACTUAL"
                .Width = 62
                .ThreeState = False
                .TrueValue = 1   'Asociar  
                .FalseValue = 0
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Visible = False
            End With
            DGVagenciasocia.Columns.Add(chbprincipal)
            '
            Dim dgvtagencia As New DataGridViewTextBoxColumn
            With dgvtagencia   '3
                .DataPropertyName = "nombre_agencia"
                .HeaderText = "Agencia"
                '.DefaultCellStyle.BackColor = SystemColors.Info
                .ReadOnly = True
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            DGVagenciasocia.Columns.Add(dgvtagencia)
            '
            Dim tbidagencia As New DataGridViewTextBoxColumn
            With tbidagencia  '4
                .DataPropertyName = "idagencias"
                .HeaderText = "id agencias"
                .DefaultCellStyle.BackColor = SystemColors.Info
                .ReadOnly = True
                .Visible = False
            End With
            DGVagenciasocia.Columns.Add(tbidagencia)
            '
            Dim tbidunidadtransporte As New DataGridViewTextBoxColumn
            With tbidunidadtransporte '5
                .DataPropertyName = "idagencia_unidad_transporte"
                .HeaderText = "idagencia_unidad_transporte"
                .DefaultCellStyle.BackColor = SystemColors.Info
                .ReadOnly = True
                .Visible = False
            End With
            DGVagenciasocia.Columns.Add(tbidunidadtransporte)

        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Asignando él valor ")
        End Try

    End Sub
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs) 'Configura el shadow label 
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), ClientSize)
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
#End Region
End Class