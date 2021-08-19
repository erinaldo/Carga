Imports INTEGRACION_LN

Public Class frmHojaRuta
    Private intCiudad As Integer
    Public Property Ciudad() As Integer
        Get
            Return intCiudad
        End Get
        Set(ByVal value As Integer)
            intCiudad = value
        End Set
    End Property

    Private strFecha As String
    Public Property Fecha() As String
        Get
            Return strFecha
        End Get
        Set(ByVal value As String)
            strFecha = value
        End Set
    End Property
    Private intResponsable As Integer
    Public Property Responsable() As Integer
        Get
            Return intResponsable
        End Get
        Set(ByVal value As Integer)
            intResponsable = value
        End Set
    End Property
    Private strCiudad As String
    Public Property NombreCiudad() As String
        Get
            Return strCiudad
        End Get
        Set(ByVal value As String)
            strCiudad = value
        End Set
    End Property
    Private strResponsable As String
    Public Property NombreResponsable() As String
        Get
            Return strResponsable
        End Get
        Set(ByVal value As String)
            strResponsable = value
        End Set
    End Property

    Private intReparto As Integer
    Public Property Reparto() As Integer
        Get
            Return intReparto
        End Get
        Set(ByVal value As Integer)
            intReparto = value
        End Set
    End Property

    Private strHoraSalida As String
    Public Property HoraSalida() As String
        Get
            Return strHoraSalida
        End Get
        Set(ByVal value As String)
            strHoraSalida = value
        End Set
    End Property


    Sub Formateardgv()
        With dgv
            'utilitario.FormatDataGridView(dgv1)
            'Cls_Utilitarios.FormatDataGridView(dgvLista)
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
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Comprobante" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .Name = "cliente" : .DataPropertyName = "cliente"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Razón Social"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
            x += +1
            Dim col_fecha_reparto As New DataGridViewTextBoxColumn
            With col_fecha_reparto
                .Name = "fecha_reparto" : .DataPropertyName = "fecha_reparto"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Hora Reparto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "t"
            End With
            x += +1
            Dim col_fecha_entrega As New DataGridViewTextBoxColumn
            With col_fecha_entrega
                .Name = "fecha_entrega" : .DataPropertyName = "fecha_entrega"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Hora Entrega"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "t"
            End With
            x += +1
            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .Name = "peso" : .DataPropertyName = "peso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_cantidad As New DataGridViewTextBoxColumn
            With col_cantidad
                .Name = "cantidad" : .DataPropertyName = "cantidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto Cobrado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,###.00"
            End With
            .Columns.AddRange(col_comprobante, col_cliente, col_fecha_reparto, col_fecha_entrega, col_peso, col_cantidad, col_total)
        End With
    End Sub
    Private Sub frmHojaRuta_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Formateardgv()
        Me.lblCiudad.Text = NombreCiudad
        Me.lblFecha.Text = Fecha
        Me.lblResponsable.Text = NombreResponsable
        Me.lblHoraSalida.Text = HoraSalida

        Dim obj As New Cls_Gasto_LN
        Me.dgv.DataSource = obj.ListarReparto(Ciudad, Fecha, Responsable, Reparto)
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Close()
    End Sub
End Class