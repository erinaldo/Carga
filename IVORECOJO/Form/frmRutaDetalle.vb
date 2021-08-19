Public Class frmRutaDetalle
    Private intRuta As Integer
    Public Property Ruta() As Integer
        Get
            Return intRuta
        End Get
        Set(ByVal value As Integer)
            intRuta = value
        End Set
    End Property

    Private strRutaDescripcion As String
    Public Property RutaDescripcion() As String
        Get
            Return strRutaDescripcion
        End Get
        Set(ByVal value As String)
            strRutaDescripcion = value
        End Set
    End Property

    Sub Configurardgv()
        With dgv
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .HeaderText = "id" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_id_det As New DataGridViewTextBoxColumn
            With col_id_det
                .Name = "id_det" : .DataPropertyName = "id_det" : .DisplayIndex = x : .HeaderText = "id_det" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_departamento As New DataGridViewTextBoxColumn
            With col_departamento
                .Name = "departamento" : .DataPropertyName = "departamento"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Departamento"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_provincia As New DataGridViewTextBoxColumn
            With col_provincia
                .Name = "provincia" : .DataPropertyName = "provincia"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Provincia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_distrito As New DataGridViewTextBoxColumn
            With col_distrito
                .Name = "distrito" : .DataPropertyName = "distrito"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Distrito"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_iddepartamento As New DataGridViewTextBoxColumn
            With col_iddepartamento
                .Name = "iddepartamento" : .DataPropertyName = "iddepartamento" : .DisplayIndex = x : .HeaderText = "iddepartamento" : .Visible = False
            End With

            x += +1
            Dim col_idprovincia As New DataGridViewTextBoxColumn
            With col_idprovincia
                .Name = "idprovincia" : .DataPropertyName = "idprovincia" : .DisplayIndex = x : .HeaderText = "idprovincia" : .Visible = False
            End With

            x += +1
            Dim col_iddistrito As New DataGridViewTextBoxColumn
            With col_iddistrito
                .Name = "iddistrito" : .DataPropertyName = "iddistrito" : .DisplayIndex = x : .HeaderText = "iddistrito" : .Visible = False
            End With

            .Columns.AddRange(col_id, col_id_det, col_departamento, col_provincia, col_distrito, col_iddepartamento, col_idprovincia, col_iddistrito)
        End With
    End Sub

    Private Sub frmRutaDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim obj As New DtoRecojo
        Dim dt As DataTable = obj.ListarRutaDetalle(Ruta)
        Me.dgv.DataSource = dt
        Me.Configurardgv()

        Me.lblRuta.Text = RutaDescripcion
    End Sub
End Class