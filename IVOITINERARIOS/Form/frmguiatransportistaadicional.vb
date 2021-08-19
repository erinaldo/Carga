Public Class frmguiatransportistaadicional
#Region "Variables"
    Dim odba As New OleDb.OleDbDataAdapter
    ' 
    Dim clase As New dtoguiatrans_dctosadiciona
    '
    Dim rsttipodctos As New ADODB.Recordset
    Dim dttipodctos As New DataTable
    Dim dvtipodctos As New DataView
    Dim bIngreso As Boolean = False
    Public hnd As Long
#End Region
#Region "Eventos y procedimientos"

    Private Sub frmguiatransportistaadicional_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frmguiatransportistaadicional_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    '
    Private Sub frmguiatransportistaadicional_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Llenado documento ' No existe procedimiento en la base de datos 
        'rsttipodctos = clase.Lista()
        'odba.Fill(dttipodctos, rsttipodctos)
        'dvtipodctos = dttipodctos.DefaultView
        'grilla()

        Try
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize)
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Sub grilla()
        Try
            dgvdctosadicional.Columns.Clear()
            With dgvdctosadicional
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AllowUserToOrderColumns = False
                .BackgroundColor = Color.White
                '.Font = New System.Drawing.Font("Tahoma", 14.0!, FontStyle.Bold)
                '.DataSource =    ' Omendoza como no tiene nada 
                '.VirtualMode = True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                '.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EAF")
                '.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            End With
            ' 
            ' Seleccionando la columna 
            '
            Dim col0 As New DataGridViewComboBoxColumn '0
            With col0  '0
                .DataSource = dvtipodctos
                .Name = "IDTIPO_COMPROBANTE"
                .DataPropertyName = "IDTIPO_COMPROBANTE"
                .DisplayMember = "TIPO_COMPROBANTE"
                .ValueMember = "IDTIPO_COMPROBANTE"
                .HeaderText = "Comprobante"
            End With
            dgvdctosadicional.Columns.Add(col0)
            '
            Dim col1 As New DataGridViewTextBoxColumn '1
            With col1 '1 
                .DataPropertyName = "nro_comprobante"
                .HeaderText = "Nº Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            End With
            dgvdctosadicional.Columns.Add(col1)
            '            
            Dim col2 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn 'DataGridViewTextBoxColumn   '2
            With col2
                .DataPropertyName = "cantidad"
                .HeaderText = "cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
                .Mask = "####0"
            End With
            dgvdctosadicional.Columns.Add(col2)
            Dim col3 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn ' DataGridViewTextBoxColumn '3
            With col3
                .DataPropertyName = "peso"
                .HeaderText = "peso"
                .Mask = "####,###,###.00"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            End With
            dgvdctosadicional.Columns.Add(col3)
            '
            Dim col4 As New Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn ' 4
            With col4
                .DataPropertyName = "volumen"
                .HeaderText = "volumen"
                .Mask = "####,###,###.00"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            End With
            dgvdctosadicional.Columns.Add(col4)
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema de seguridad")
        End Try
    End Sub
#End Region
    Private Sub Btnanadir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnanadir.Click
        Me.dgvdctosadicional.Rows.Add()
    End Sub
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Me.dgvdctosadicional.Rows.Remove(dgvdctosadicional.CurrentRow)
    End Sub
End Class