Public Class FrmSimuladorCarga
    Dim objSimulador As dtoSimulador
    Dim coll_unidades As New Collection
    Dim coll_agencia As New Collection
    Dim coll_usuarios As New Collection
    Dim coll_salida As New Collection

    Dim iBultos As Integer = 0
    Dim iPeso As Double = 0
    Dim iVolumen As Double = 0
    Dim iSubtotal As Double = 0
    Dim iImpuesto As Double = 0
    Dim iTotal As Double = 0

    Dim iBultos2 As Integer = 0
    Dim iPeso2 As Double = 0
    Dim iVolumen2 As Double = 0
    Dim iSubtotal2 As Double = 0
    Dim iImpuesto2 As Double = 0
    Dim iTotal2 As Double = 0

    'filtros
    Dim coll_origen As New Collection
    Dim coll_destino As New Collection
    
    'salida
    Dim coll_UnidadOrigen As New Collection
    Dim coll_UnidadDestino As New Collection
    Dim coll_Tramo As New Collection

    'Dim cur_lista As New ADODB.Recordset
    Dim cur_lista As New DataTable
    Dim cur_clon As New DataTable

    Dim bInicio As Boolean = True
    Dim bCheck As Boolean
    Dim iControl As Integer
    Dim dNumero As Integer
    Dim dMes As Integer
    Dim _values() As Object
    Dim bNuevo As Boolean = False
    Dim iCapacidad As Double
    Public Shared iBus As Integer
    Public Shared iSalida As Integer
    Dim iCantidad1 As Integer
    Dim bMostrar As Boolean = True
    Dim bNuevo2 As Boolean = True

    Dim bAbierto As Boolean = False
    'Dim dTramo As Double = 0
    Dim bEntrar2 As Boolean = True
    Dim ObjReport As ClsLbTepsa.dtoFrmReport

    Dim iServicio As Integer
    Dim iOri As Integer
    Dim sOri As String
    Dim iDes As Integer
    Dim sDes As String
    Dim bEliminar As Boolean = False
    Dim bTramo As Boolean = False

    Dim bFiltrar As Boolean = False
    Dim iPosicion As Integer = 0
    Dim bActualiza As Boolean = True
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Structure sTramo
        Dim codigo As Integer
        Dim nombre As String
        Dim kilometros As Double
    End Structure
    Dim mTramo() As sTramo

    Private Sub FrmSimuladorCarga_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmSimuladorCarga_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmSimuladorCarga_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MenuStrip1.Items(1).Enabled = False
        MenuStrip1.Items(2).Enabled = False
        MenuStrip1.Items(3).Enabled = False
        MenuStrip1.Items(4).Enabled = False
        MenuStrip1.Items(5).Visible = False
        MenuStrip1.Items(6).Enabled = False

        MenuTab.Items(3).Visible = False
        MenuTab.Items(4).Visible = False
        MenuTab.Items(5).Visible = False

        dtpFecha.Value = Date.Now.ToShortDateString
        dtpFecha2.Value = Date.Now.ToShortDateString

        'StatusStrip1.Visible = False
        ShadowLabel1.Text = "Simulador de Carga"
        MenuTab.Items(0).Text = "Lista"
        MenuTab.Items(1).Text = "Documento"

        cboOperador.SelectedIndex = 0

        dtpInicio.Value = DateAdd(DateInterval.Day, -1, dtpFin.Value)

        bCheck = False
        'StatusStrip1.Visible = False
        cboParcial.SelectedIndex = 0

        ConfiguraGrid()
        dgvDisponibles.Rows.Clear()
        cboTipoDocumento.SelectedIndex = 0

        cboCliente.Items.Add("--TODOS--")
        cboCliente.SelectedIndex = 0

        cboOrigen.Items.Add("--TODOS--")
        cboOrigen.SelectedIndex = 0
        cboDestino.Items.Add("--TODOS--")
        cboDestino.SelectedIndex = 0

        cboAgencia.Items.Add("--TODOS--")
        cboAgencia.SelectedIndex = 0

        objSimulador = New dtoSimulador
        With objSimulador
            If .ListaUnidades2() Then
                'datahelper
                'ModuUtil.LlenarComboIDs(.cur_unidades, cbobus, coll_unidades, -1)
                ModuUtil.LlenarCombo2(.cur_unidades, cbobus, coll_unidades, -1)
            End If
        End With

        With objSimulador
            If .Ciudad2 Then
                'datahelper
                'ModuUtil.LlenarComboIDs(.cur_AgenciaOrigen, cboUnidadOrigen, coll_UnidadOrigen, 0)
                'ModuUtil.LlenarComboIDs(.cur_AgenciaDestino, cboUnidadDestino, coll_UnidadDestino, 0)
                'ModuUtil.LlenarComboIDs(.cur_Tramo, cboTramo, coll_Tramo, 0)
                ModuUtil.LlenarCombo2(.cur_AgenciaOrigen, cboUnidadOrigen, coll_UnidadOrigen, 0)
                ModuUtil.LlenarCombo2(.cur_AgenciaDestino, cboUnidadDestino, coll_UnidadDestino, 0)
                ModuUtil.LlenarCombo2(.cur_Tramo, cboTramo, coll_Tramo, 0)
            End If
        End With

        With objSimulador
            If .ListarUsuarios Then
                'datahelper
                'ModuUtil.LlenarComboIDs(.cur_usuarios, cboUsuario, coll_usuarios, 0)
                ModuUtil.LlenarCombo2(.cur_usuarios, cboUsuario, coll_usuarios, 0)
            End If
        End With

        For i As Integer = 0 To coll_usuarios.Count - 1
            If dtoUSUARIOS.IdLogin = coll_usuarios(i + 1) Then
                cboUsuario.SelectedIndex = i
                GoTo listar
            End If
        Next
        cboUsuario.SelectedIndex = 0

        bIngreso = False
        Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
        Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
        bIngreso = True

        Return
listar:
        Listar()
    End Sub

    Private Function ObtieneUnidad() As Integer
        Dim i As Integer
        Dim sUnidad As String = TxtBus.Text.Trim

        For i = 1 To coll_unidades.Count
            If Val(sUnidad) = coll_unidades(i) Then
                Return i - 1
                Exit Function
            End If
        Next
        Return 0
    End Function

    Private Sub TxtBus_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtBus.Validating
        Dim iUnidad As Short
        If txtBus.Text.Trim.Length > 0 Then
            cbobus.SelectedIndex = ObtieneUnidad()
        End If
    End Sub

    Private Sub cbobus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbobus.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            cboUnidadOrigen.Focus()
        End If
    End Sub

    Private Sub ConfiguraGrid()
        With dgvTramo
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .BackgroundColor = SystemColors.Window
            .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
            .ReadOnly = True
            .ScrollBars = ScrollBars.Both

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersWidth = 10
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")

        End With

        With dgvLista
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .BackgroundColor = SystemColors.Window
            .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
            .ReadOnly = True
            .ScrollBars = ScrollBars.Both

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersWidth = 10
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")


            '    Dim c1 As New DataGridViewTextBoxColumn
            '    With c1
            '        .DisplayIndex = 0
            '        .HeaderText = "Año"
            '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '        .DefaultCellStyle.ForeColor = Color.Black
            '        .ReadOnly = True
            '    End With
            '    .Columns.Add(c1)

            '    Dim c2 As New DataGridViewTextBoxColumn
            '    With c2
            '        .DisplayIndex = 1
            '        .HeaderText = "Mes"
            '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '        .DefaultCellStyle.ForeColor = Color.Black
            '        .ReadOnly = True
            '    End With
            '    .Columns.Add(c2)

            '    Dim c3 As New DataGridViewTextBoxColumn
            '    With c3
            '        .DisplayIndex = 2
            '        .HeaderText = "Número"
            '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '        .DefaultCellStyle.ForeColor = Color.Black
            '        .ReadOnly = True
            '    End With
            '    .Columns.Add(c3)

            '    Dim c4 As New DataGridViewTextBoxColumn
            '    With c4
            '        .DisplayIndex = 3
            '        .HeaderText = "Bus"
            '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '        .DefaultCellStyle.ForeColor = Color.Black
            '        .ReadOnly = True
            '    End With
            '    .Columns.Add(c4)

            '    Dim c5 As New DataGridViewTextBoxColumn
            '    With c5
            '        .DisplayIndex = 4
            '        .HeaderText = "Serie Guia"
            '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '        .DefaultCellStyle.ForeColor = Color.Black
            '        .ReadOnly = True
            '    End With
            '    .Columns.Add(c5)

            '    Dim c6 As New DataGridViewTextBoxColumn
            '    With c6
            '        .DisplayIndex = 5
            '        .HeaderText = "Nº Guía"
            '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '        .DefaultCellStyle.ForeColor = Color.Black
            '        .ReadOnly = True
            '    End With
            '    .Columns.Add(c6)

            '    Dim c7 As New DataGridViewTextBoxColumn
            '    With c7
            '        .DisplayIndex = 6
            '        .HeaderText = "Bus"
            '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '        .DefaultCellStyle.ForeColor = Color.Black
            '        .ReadOnly = True
            '    End With
            '    .Columns.Add(c7)
        End With

        With dgvDisponibles
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .BackgroundColor = SystemColors.Window
            .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
            '.ReadOnly = False
            '.AutoGenerateColumns = False
            .ScrollBars = ScrollBars.Both
            '.DataSource = dtable_Lista_Control_Comprobante
            '.VirtualMode = False

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersWidth = 10
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")

            Dim c1 As New DataGridViewTextBoxColumn
            With c1
                .DisplayIndex = 0
                .HeaderText = "Tipo Doc."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c1)

            Dim c2 As New DataGridViewTextBoxColumn
            With c2
                .DisplayIndex = 1
                .HeaderText = "Nº Doc."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c2)

            Dim c3 As New DataGridViewTextBoxColumn
            With c3
                .DisplayIndex = 2
                .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c3)

            Dim c4 As New DataGridViewTextBoxColumn
            With c4
                .DisplayIndex = 3
                .HeaderText = "Cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c4)

            Dim c15 As New DataGridViewTextBoxColumn
            With c15
                .DisplayIndex = 4
                .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                '.Visible = False
            End With
            .Columns.Add(c15)

            Dim c5 As New DataGridViewTextBoxColumn
            With c5
                .DisplayIndex = 5
                .HeaderText = "Bultos a Simular"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c5)

            Dim c6 As New DataGridViewTextBoxColumn
            With c6
                .DisplayIndex = 6
                .HeaderText = "Saldo Bultos a Simular"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c6)

            Dim c7 As New DataGridViewTextBoxColumn
            With c7
                .DisplayIndex = 7
                .HeaderText = "Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c7)

            Dim c8 As New DataGridViewTextBoxColumn
            With c8
                .DisplayIndex = 8
                .HeaderText = "Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c8)

            Dim c9 As New DataGridViewTextBoxColumn
            With c9
                .DisplayIndex = 9
                .HeaderText = "Subtotal"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c9)

            Dim c10 As New DataGridViewTextBoxColumn
            With c10
                .DisplayIndex = 10
                .HeaderText = "Impuesto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c10)

            Dim c11 As New DataGridViewTextBoxColumn
            With c11
                .DisplayIndex = 11
                .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c11)

            Dim c12 As New DataGridViewTextBoxColumn
            With c12
                .DisplayIndex = 12
                .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c12)

            Dim c13 As New DataGridViewTextBoxColumn
            With c13
                .DisplayIndex = 13
                .HeaderText = "Kilómetros"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c13)

            Dim c14 As New DataGridViewTextBoxColumn
            With c14
                .DisplayIndex = 14
                .HeaderText = "Id"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c14)


            Dim c16 As New DataGridViewTextBoxColumn
            With c16
                .DisplayIndex = 15
                .HeaderText = "Tipo Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c16)

            Dim c17 As New DataGridViewTextBoxColumn
            With c17
                .DisplayIndex = 16
                .HeaderText = "Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c17)

            Dim c18 As New DataGridViewTextBoxColumn
            With c18
                .DisplayIndex = 17
                .HeaderText = "Total Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                '.Visible = False
            End With
            .Columns.Add(c18)

            Dim c19 As New DataGridViewTextBoxColumn
            With c19
                .DisplayIndex = 18
                .HeaderText = "Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                '.Visible = False
            End With
            .Columns.Add(c19)

            Dim c20 As New DataGridViewTextBoxColumn
            With c20
                .DisplayIndex = 19
                .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c20)

            Dim c21 As New DataGridViewTextBoxColumn
            With c21
                .DisplayIndex = 20
                .HeaderText = "Saldo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c21)

            Dim c22 As New DataGridViewTextBoxColumn
            With c22
                .DisplayIndex = 21
                .HeaderText = "Subtotal"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c22)

            Dim c23 As New DataGridViewTextBoxColumn
            With c23
                .DisplayIndex = 22
                .HeaderText = "Impuesto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c23)

            Dim c24 As New DataGridViewTextBoxColumn
            With c24
                .DisplayIndex = 23
                .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c24)

            Dim c25 As New DataGridViewTextBoxColumn
            With c25
                .DisplayIndex = 24
                .HeaderText = "Id Parcial"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c25)

            Dim c26 As New DataGridViewTextBoxColumn
            With c26
                .DisplayIndex = 25
                .HeaderText = "Parcial"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                '.Visible = False
            End With
            .Columns.Add(c26)

            Dim c27 As New DataGridViewTextBoxColumn
            With c27
                .DisplayIndex = 26
                .HeaderText = "Estado Envio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c27)

            Dim c28 As New DataGridViewTextBoxColumn
            With c28
                .DisplayIndex = 27
                .HeaderText = "Cantidad Doc."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c28)

            Dim c29 As New DataGridViewTextBoxColumn
            With c29
                .DisplayIndex = 28
                .HeaderText = "Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c29)

            Dim c30 As New DataGridViewTextBoxColumn
            With c30
                .DisplayIndex = 29
                .HeaderText = "Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c30)

            Dim c31 As New DataGridViewTextBoxColumn
            With c31
                .DisplayIndex = 30
                .HeaderText = "Bultos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c31)

            Dim c32 As New DataGridViewTextBoxColumn
            With c32
                .DisplayIndex = 31
                .HeaderText = "Saldo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c32)

            Dim c33 As New DataGridViewTextBoxColumn
            With c33
                .DisplayIndex = 32
                .HeaderText = "Simulado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c33)

        End With

        With dgvSeleccionados
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .BackgroundColor = SystemColors.Window
            .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
            '.ReadOnly = False
            '.AutoGenerateColumns = False
            .ScrollBars = ScrollBars.Both
            '.DataSource = dtable_Lista_Control_Comprobante
            '.VirtualMode = False

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersWidth = 10
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")

            Dim c1 As New DataGridViewTextBoxColumn
            With c1
                .DisplayIndex = 0
                .HeaderText = "Tipo Doc."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c1)

            Dim c2 As New DataGridViewTextBoxColumn
            With c2
                .DisplayIndex = 1
                .HeaderText = "Nº Doc."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c2)

            Dim c3 As New DataGridViewTextBoxColumn
            With c3
                .DisplayIndex = 2
                .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c3)

            Dim c4 As New DataGridViewTextBoxColumn
            With c4
                .DisplayIndex = 3
                .HeaderText = "Cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c4)

            Dim c15 As New DataGridViewTextBoxColumn
            With c15
                .DisplayIndex = 4
                .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                '.Visible = False
            End With
            .Columns.Add(c15)

            Dim c5 As New DataGridViewTextBoxColumn
            With c5
                .DisplayIndex = 5
                .HeaderText = "Bultos a Simular"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = False
                .MaxInputLength = 5
            End With
            .Columns.Add(c5)

            Dim c6 As New DataGridViewTextBoxColumn
            With c6
                .DisplayIndex = 6
                .HeaderText = "Saldo Bultos a Simular"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c6)

            Dim c7 As New DataGridViewTextBoxColumn
            With c7
                .DisplayIndex = 7
                .HeaderText = "Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c7)

            Dim c8 As New DataGridViewTextBoxColumn
            With c8
                .DisplayIndex = 8
                .HeaderText = "Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c8)

            Dim c9 As New DataGridViewTextBoxColumn
            With c9
                .DisplayIndex = 9
                .HeaderText = "Subtotal"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c9)

            Dim c10 As New DataGridViewTextBoxColumn
            With c10
                .DisplayIndex = 10
                .HeaderText = "Impuesto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c10)

            Dim c11 As New DataGridViewTextBoxColumn
            With c11
                .DisplayIndex = 11
                .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c11)

            Dim c12 As New DataGridViewTextBoxColumn
            With c12
                .DisplayIndex = 12
                .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c12)

            Dim c13 As New DataGridViewTextBoxColumn
            With c13
                .DisplayIndex = 13
                .HeaderText = "Kilómetros"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c13)

            Dim c14 As New DataGridViewTextBoxColumn
            With c14
                .DisplayIndex = 14
                .HeaderText = "Id"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c14)

            Dim c16 As New DataGridViewTextBoxColumn
            With c16
                .DisplayIndex = 15
                .HeaderText = "Tipo Comprob."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c16)

            Dim c17 As New DataGridViewTextBoxColumn
            With c17
                .DisplayIndex = 16
                .HeaderText = "Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c17)

            Dim c18 As New DataGridViewTextBoxColumn
            With c18
                .DisplayIndex = 17
                .HeaderText = "Total Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                '.Visible = False
            End With
            .Columns.Add(c18)

            Dim c19 As New DataGridViewTextBoxColumn
            With c19
                .DisplayIndex = 18
                .HeaderText = "Agencia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                '.Visible = False
            End With
            .Columns.Add(c19)

            Dim c20 As New DataGridViewTextBoxColumn
            With c20
                .DisplayIndex = 19
                .HeaderText = "Cantidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c20)

            Dim c21 As New DataGridViewTextBoxColumn
            With c21
                .DisplayIndex = 20
                .HeaderText = "Saldo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c21)

            Dim c22 As New DataGridViewTextBoxColumn
            With c22
                .DisplayIndex = 21
                .HeaderText = "Subtotal"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c22)

            Dim c23 As New DataGridViewTextBoxColumn
            With c23
                .DisplayIndex = 22
                .HeaderText = "Impuesto"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c23)

            Dim c24 As New DataGridViewTextBoxColumn
            With c24
                .DisplayIndex = 23
                .HeaderText = "Total"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c24)

            Dim c25 As New DataGridViewTextBoxColumn
            With c25
                .DisplayIndex = 24
                .HeaderText = "Id Parcial"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c25)

            Dim c26 As New DataGridViewTextBoxColumn
            With c26
                .DisplayIndex = 25
                .HeaderText = "Parcial"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c26)

            Dim c27 As New DataGridViewTextBoxColumn
            With c27
                .DisplayIndex = 26
                .HeaderText = "Estado Envio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c27)

            Dim c28 As New DataGridViewTextBoxColumn
            With c28
                .DisplayIndex = 27
                .HeaderText = "Cantidad Doc."
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c28)

            Dim c29 As New DataGridViewTextBoxColumn
            With c29
                .DisplayIndex = 28
                .HeaderText = "Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c29)

            Dim c30 As New DataGridViewTextBoxColumn
            With c30
                .DisplayIndex = 29
                .HeaderText = "Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            .Columns.Add(c30)

            Dim c31 As New DataGridViewTextBoxColumn
            With c31
                .DisplayIndex = 30
                .HeaderText = "Bultos"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c31)

            Dim c32 As New DataGridViewTextBoxColumn
            With c32
                .DisplayIndex = 31
                .HeaderText = "Saldo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c32)

            Dim c33 As New DataGridViewTextBoxColumn
            With c33
                .DisplayIndex = 32
                .HeaderText = "Simulado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
            End With
            .Columns.Add(c33)

        End With
    End Sub

    Private Function Registros(ByVal dgv As DataGridView) As Integer
        Return dgv.Rows.Count
    End Function

    Private Sub BtSacar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSacar.Click
        With dgvSeleccionados
            Dim contenido(.ColumnCount - 1) As String
            For Each fila As DataGridViewRow In .SelectedRows
                For columna As Integer = 0 To contenido.Length - 1
                    If (columna >= 5 And columna <= 11) Then
                        If columna = 5 Then
                            contenido(columna) = fila.Cells(19).Value
                        ElseIf columna = 6 Then
                            contenido(columna) = fila.Cells(20).Value

                        ElseIf columna = 7 Then
                            contenido(columna) = fila.Cells(28).Value
                        ElseIf columna = 8 Then
                            contenido(columna) = fila.Cells(29).Value

                        ElseIf columna = 9 Then
                            contenido(columna) = fila.Cells(21).Value
                        ElseIf columna = 10 Then
                            contenido(columna) = fila.Cells(22).Value
                        ElseIf columna = 11 Then
                            contenido(columna) = fila.Cells(23).Value
                        End If
                    ElseIf columna = 24 Or columna = 25 Then
                        If columna = 24 Then
                            Dim sEnvio As String = fila.Cells(26).Value
                            Dim sComprobante As String = fila.Cells(16).Value
                            Dim sTipo As String = fila.Cells(15).Value
                            Dim sUsuario As String = dtoUSUARIOS.IdLogin
                            Dim iCantidad As Integer = fila.Cells(27).Value

                            If objSimulador.Estado_Parcial(sEnvio, sComprobante, sTipo, sUsuario, iCantidad) Then
                                'datahelper
                                'contenido(columna) = objSimulador.cur_parcial.Fields(0).Value
                                contenido(columna) = objSimulador.cur_parcial.Rows(0).Item(0)
                                contenido(columna + 1) = ObtieneParcial(contenido(columna))
                            Else
                                contenido(columna) = 0
                                contenido(columna + 1) = ""
                            End If
                        End If
                    Else
                        contenido(columna) = fila.Cells(columna).Value
                    End If
                Next

                If fila.Cells(12).Value <> 2 Then
                    iBultos2 += fila.Cells(19).Value
                    iPeso2 += fila.Cells(7).Value
                    iVolumen2 += fila.Cells(8).Value
                    iSubtotal2 += fila.Cells(21).Value
                    iImpuesto2 += fila.Cells(22).Value
                    iTotal2 += fila.Cells(23).Value
                End If

                dgvSeleccionados.Rows.Remove(fila)
                If fila.Cells(12).Value <> 2 Then
                    dgvDisponibles.Rows.Add(contenido)
                End If
                iBultos -= fila.Cells(5).Value
                iPeso -= fila.Cells(7).Value
                iVolumen -= fila.Cells(8).Value
                iSubtotal -= fila.Cells(9).Value
                iImpuesto -= fila.Cells(10).Value
                iTotal -= fila.Cells(11).Value
            Next
            lblRegistros1.Text = Registros(dgvDisponibles)
            lblRegistros2.Text = Registros(dgvSeleccionados)

            If iServicio = 2 And Val(txtKilometraje.Text) > 0 Then   'Carguero
                'txtKilometraje.Text = MontoCarguero(iServicio, txtKilometraje.Text) 'CDbl(txtKilometraje.Text) * 2
            End If

            Total()
            Total2()
        End With
        ExcedeLimite()
    End Sub

    Private Sub btnTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTodos.Click
        With dgvDisponibles
            Dim contenido(Me.dgvDisponibles.ColumnCount - 1) As String
            For Each fila As DataGridViewRow In .Rows
                For columna As Integer = 0 To contenido.Length - 1
                    If columna = 5 Or columna = 6 Then
                        If columna = 5 Then
                            If fila.Cells(columna).Value <> fila.Cells(columna + 1).Value Then
                                If fila.Cells(columna + 1).Value > 0 Then
                                    contenido(columna) = fila.Cells(columna + 1).Value
                                Else
                                    contenido(columna) = fila.Cells(columna).Value
                                End If
                            Else
                                contenido(columna) = fila.Cells(columna).Value
                            End If
                        End If
                        If columna = 6 Then
                            contenido(columna) = 0
                        End If
                    Else
                        contenido(columna) = fila.Cells(columna).Value
                    End If
                Next

                iBultos2 = 0
                iPeso2 = 0
                iVolumen2 = 0
                iSubtotal2 = 0
                iImpuesto2 = 0
                iTotal2 = 0

                dgvSeleccionados.Rows.Add(contenido)
                'iBultos += fila.Cells(5).Value
                If fila.Cells(5).Value <> fila.Cells(6).Value Then
                    iBultos += fila.Cells(6).Value
                Else
                    iBultos += fila.Cells(5).Value
                End If

                iPeso += fila.Cells(7).Value
                iVolumen += fila.Cells(8).Value
                iSubtotal += fila.Cells(9).Value
                iImpuesto += fila.Cells(10).Value
                iTotal += fila.Cells(11).Value
            Next

            dgvDisponibles.Rows.Clear()
            bActualiza = False
            cboCliente.SelectedIndex = 0
            bActualiza = True

            lblRegistros1.Text = Registros(dgvDisponibles)
            lblRegistros2.Text = Registros(dgvSeleccionados)
            Total()
            Total2()
        End With
        ExcedeLimite()
    End Sub

    Private Sub btnNinguno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNinguno.Click
        With dgvSeleccionados
            Dim contenido(Me.dgvSeleccionados.ColumnCount - 1) As String
            For Each fila As DataGridViewRow In .Rows
                For columna As Integer = 0 To contenido.Length - 1
                    If columna = 5 Or columna = 6 Or columna = 9 Or columna = 10 Or columna = 11 Then
                        If columna = 5 Then
                            contenido(columna) = fila.Cells(19).Value
                        ElseIf columna = 6 Then
                            contenido(columna) = fila.Cells(20).Value
                        ElseIf columna = 9 Then
                            contenido(columna) = fila.Cells(21).Value
                        ElseIf columna = 10 Then
                            contenido(columna) = fila.Cells(22).Value
                        ElseIf columna = 11 Then
                            contenido(columna) = fila.Cells(23).Value
                        End If
                    ElseIf columna = 24 Or columna = 25 Then
                        If columna = 24 Then
                            Dim sEnvio As String = fila.Cells(26).Value
                            Dim sComprobante As String = fila.Cells(16).Value
                            Dim sTipo As String = fila.Cells(15).Value
                            Dim sUsuario As String = dtoUSUARIOS.IdLogin
                            Dim iCantidad As Integer = fila.Cells(5).Value

                            If objSimulador.Estado_Parcial(sEnvio, sComprobante, sTipo, sUsuario, iCantidad) Then
                                'datahelper
                                'contenido(columna) = objSimulador.cur_parcial.Fields(0).Value
                                contenido(columna) = objSimulador.cur_parcial.Rows(0).Item(0)
                                contenido(columna + 1) = ObtieneParcial(contenido(columna))
                            Else
                                contenido(columna) = 0
                                contenido(columna + 1) = ""
                            End If
                        End If
                    Else
                        contenido(columna) = fila.Cells(columna).Value
                    End If
                Next

                If fila.Cells(12).Value <> 2 Then
                    iBultos2 += fila.Cells(19).Value
                    iPeso2 += fila.Cells(7).Value
                    iVolumen2 += fila.Cells(8).Value
                    iSubtotal2 += fila.Cells(21).Value
                    iImpuesto2 += fila.Cells(22).Value
                    iTotal2 += fila.Cells(23).Value
                End If

                If fila.Cells(12).Value <> 2 Then
                    dgvDisponibles.Rows.Add(contenido)
                End If
                iBultos -= fila.Cells(5).Value
                iPeso -= fila.Cells(7).Value
                iVolumen -= fila.Cells(8).Value
                iSubtotal -= fila.Cells(9).Value
                iImpuesto -= fila.Cells(10).Value
                iTotal -= fila.Cells(11).Value
            Next
            dgvSeleccionados.Rows.Clear()
            lblRegistros1.Text = Registros(dgvDisponibles)
            lblRegistros2.Text = Registros(dgvSeleccionados)
            Total()
            Total2()
        End With
        ExcedeLimite()
    End Sub

    Private Sub Total()
        txtBultos.Text = FormatNumber(iBultos, 0)
        txtPeso.Text = FormatNumber(iPeso, 2)
        txtVolumen.Text = FormatNumber(iVolumen, 2)
        txtTot.Text = FormatNumber(iPeso + iVolumen, 2)

        txtSubtotal.Text = FormatNumber(iSubtotal, 2)
        txtImpuesto.Text = FormatNumber(iImpuesto, 2)
        txtTotal.Text = FormatNumber(iTotal, 2)

        txtSubtotalAcumulado.Text = IIf(Val(txtSubtotal.Text) = 0, "", txtSubtotal.Text)

        Dim isub As Double
        Dim ikil As Double
        Dim ispk As Double

        isub = txtSubtotal.Text

        If Val(txtKilometraje.Text) > 0 Then
            ikil = CDbl(txtKilometraje.Text)
        Else
            ikil = 0
        End If

        If ikil > 0 Then
            ispk = isub / ikil
        Else
            ispk = 0
        End If

        If ispk > 0 Then
            txtSpk.Text = FormatNumber(ispk, 2)
        Else
            txtSpk.Text = ""
        End If

        If Val(txtKilometraje.Text) > 0 Then
            txtKilometraje.Text = FormatNumber(txtKilometraje.Text, 2)
        Else
            txtKilometraje.Text = ""
        End If
    End Sub

    Private Sub txtDocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDocumento.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            btnDocumento_Click(sender, e)
        Else
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Or (e.KeyChar = "-" And InStr(tb.Text, "-") = 0) Then
                e.Handled = False
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub cboTipoDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoDocumento.SelectedIndexChanged
        dgvDisponibles.Rows.Clear()
        If cboCliente.Items.Count > 0 Then
            bActualiza = False
            cboCliente.SelectedIndex = 0
            bActualiza = True
        End If
        lblRegistros1.Text = "0"

        iBultos2 = 0
        iPeso2 = 0
        iVolumen2 = 0
        iSubtotal2 = 0
        iImpuesto2 = 0
        iTotal2 = 0
        Total2()

        Return
        If bInicio = False Then
            If cboTipoDocumento.SelectedIndex = 0 Then
                'datahelper
                'cur_lista.Filter = ADODB.FilterGroupEnum.adFilterNone
                cur_lista = FiltrarDataTable(cur_lista, "", "")
            Else
                'datahelper
                'cur_lista.Filter = "tipo='" & cboTipoDocumento.Text & "'"
                cur_lista = FiltrarDataTable(cur_lista, "tipo='" & cboTipoDocumento.Text & "'", "")
            End If
            Mostrar(dgvDisponibles)
        End If
    End Sub

    Private Sub cboDestino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDestino.SelectedIndexChanged
        'dgvDisponibles.Rows.Clear()
        'lblRegistros1.Text = "0"

        'iBultos2 = 0
        'iPeso2 = 0
        'iVolumen2 = 0
        'iSubtotal2 = 0
        'iImpuesto2 = 0
        'iTotal2 = 0
        'Total2()

        If bEntrar2 = False Then
            bEntrar2 = True
            Return
        End If
        If dgvDisponibles.Rows.Count = 0 Then Return
        If bInicio = False Then
            If cboDestino.SelectedIndex = 0 Then
                'datahelper
                'cur_lista.Filter = ADODB.FilterGroupEnum.adFilterNone
                'cur_lista = FiltrarDataTable(cur_lista, "", "")
                cur_lista = cur_clon
            Else
                'datahelper
                'cur_lista.Filter = "destino='" & cboDestino.Text & "'"
                cur_lista = cur_clon
                cur_lista = FiltrarDataTable(cur_lista, "destino='" & cboDestino.Text & "'", "")
            End If
            Mostrar(dgvDisponibles)
        End If
    End Sub

    Private Sub dtpInicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInicio.ValueChanged
        dgvDisponibles.Rows.Clear()
        If cboCliente.Items.Count > 0 Then
            bActualiza = False
            cboCliente.SelectedIndex = 0
            bActualiza = True
        End If
        lblRegistros1.Text = "0"

        iBultos2 = 0
        iPeso2 = 0
        iVolumen2 = 0
        iSubtotal2 = 0
        iImpuesto2 = 0
        iTotal2 = 0
        Total2()

        Return
        If bInicio = False Then
            'datahelper
            'cur_lista.Filter = "fecha>='" & dtpInicio.Value.ToShortDateString & "' and fecha<='" & dtpFin.Value.ToShortDateString & "' "
            cur_lista = FiltrarDataTable(cur_lista, "fecha>='" & dtpInicio.Value.ToShortDateString & "' and fecha<='" & dtpFin.Value.ToShortDateString & "' ", "")
            Mostrar(dgvDisponibles)
        End If
    End Sub

    Private Sub dtpFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFin.ValueChanged
        dgvDisponibles.Rows.Clear()
        bActualiza = False
        cboCliente.SelectedIndex = 0
        bActualiza = True
        lblRegistros1.Text = "0"

        iBultos2 = 0
        iPeso2 = 0
        iVolumen2 = 0
        iSubtotal2 = 0
        iImpuesto2 = 0
        iTotal2 = 0
        Total2()

        Return
        If bInicio = False Then
            'datahelper
            'cur_lista.Filter = "fecha>='" & dtpInicio.Value.ToShortDateString & "' and fecha<='" & dtpFin.Value.ToShortDateString & "' "
            cur_lista = FiltrarDataTable(cur_lista, "fecha>='" & dtpInicio.Value.ToShortDateString & "' and fecha<='" & dtpFin.Value.ToShortDateString & "' ", "")
            Mostrar(dgvDisponibles)
        End If
    End Sub

    Private Sub cboCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCliente.KeyPress
        If Asc(e.KeyChar) = Keys.Space Then
            cboCliente.SelectedIndex = 0
        End If
    End Sub

    Private Sub cboCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCliente.SelectedIndexChanged
        'dgvDisponibles.Rows.Clear()
        'Return
        If bInicio = False Then
            If bMostrar = False Or bActualiza = False Then Return
            iPosicion = cboCliente.SelectedIndex
            If cboCliente.SelectedIndex > 0 Then
                'cur_lista.Requery()
                'If cur_lista.BOF = False Or cur_lista.EOF = False Then
                'cur_lista.MoveFirst()
                'End If
                'cur_lista.Filter = ADODB.FilterGroupEnum.adFilterNone

                'datahelper
                'cur_lista.Filter = "cliente='" & cboCliente.Text & "' "
                cur_lista = cur_clon
                cur_lista = FiltrarDataTable(cur_lista, "cliente='" & cboCliente.Text & "' ", "")
            Else
                'cur_lista.Requery()

                'datahelper
                'cur_lista.Filter = ADODB.FilterGroupEnum.adFilterNone
                'cur_lista = FiltrarDataTable(cur_lista, "", "")
                cur_lista = cur_clon
            End If
            iBultos2 = 0
            iPeso2 = 0
            iVolumen2 = 0
            iSubtotal2 = 0
            iImpuesto2 = 0
            iTotal2 = 0
            Mostrar(dgvDisponibles)
        End If
    End Sub

    Private Sub Limpiar()
        cbobus.SelectedIndex = 0

        'lbl1.Text = ""
        'lbl2.Text = ""
        'lbl3.Text = ""
        'lbl4.Text = ""
        cboCliente.SelectedIndex = 0
        dtpInicio.Value = DateAdd(DateInterval.Day, -1, dtpFin.Value)
        dtpFin.Value = Date.Now.ToShortDateString

        cboDestino.SelectedIndex = IIf(cboDestino.Items.Count > 0, 0, -1)
        cboTipoDocumento.SelectedIndex = 0

        txtSubtotalAcumulado.Text = ""
        txtKilometraje.Text = ""
        txtSpk.Text = ""
        txtDocumento.Text = ""
        dgvSeleccionados.Rows.Clear()

        txtBultos.Text = ""
        txtPeso.Text = ""
        txtVolumen.Text = ""
        txtTot.Text = ""
        txtSubtotal.Text = ""
        txtImpuesto.Text = ""
        txtTotal.Text = ""

        txtBultos22.Text = ""
        txtPeso22.Text = ""
        txtVolumen22.Text = ""
        txtTot2.Text = ""
        txtSubtotal22.Text = ""
        txtImpuesto22.Text = ""
        txtTotal22.Text = ""

        lblRegistros1.Text = "0"
        lblRegistros2.Text = "0"

        cboOrigen.Enabled = True
        cboDestino.Enabled = True

        cboOrigen.Items.Clear()
        cboDestino.Items.Clear()

        cboOrigen.Items.Add("--TODOS--")
        cboDestino.Items.Add("--TODOS--")

        cboOrigen.SelectedIndex = 0
        cboDestino.SelectedIndex = 0
    End Sub

    Private Sub TxtBus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBus.TextChanged
        If bNuevo Then Return
        Dim iUnidad As Short

        bInicio = True
        cbobus.SelectedIndex = ObtieneUnidad()
        'Limpiar()
        Return
        dgvDisponibles.Rows.Clear()
        dgvSeleccionados.Rows.Clear()

        cboCliente.Items.Clear()
        cboCliente.Items.Add("--TODOS--")
        cboCliente.SelectedIndex = 0

        cboOrigen.Items.Clear()
        cboDestino.Items.Clear()
        cboAgencia.Items.Clear()

        cboOrigen.Items.Add("--TODOS--")
        cboDestino.Items.Add("--TODOS--")
        cboAgencia.Items.Add("--TODOS--")

        cboOrigen.SelectedIndex = 0
        cboDestino.SelectedIndex = 0
        cboAgencia.SelectedIndex = 0

        lblRegistros1.Text = Registros(dgvDisponibles)
        lblRegistros2.Text = Registros(dgvSeleccionados)
        txtKilometraje.Text = ""

        iBultos = 0
        iPeso = 0
        iVolumen = 0
        iSubtotal = 0
        iImpuesto = 0
        iTotal = 0

        iBultos2 = 0
        iPeso2 = 0
        iVolumen2 = 0
        iSubtotal2 = 0
        iImpuesto2 = 0
        iTotal2 = 0

        'lbl1.Text = ""
        'lbl2.Text = ""
        'lbl3.Text = ""
        'lbl4.Text = ""

        'cboSalida.Items.Clear()
        'btnFiltrar.Enabled = False

        Total()

        'If TxtBus.Text.Trim.Length > 0 Then
        'cbobus.SelectedIndex = ObtieneUnidad()
        'Else
        'bInicio = True
        'cbobus.SelectedIndex = 0
        'End If
    End Sub

    Private Sub Mostrar(ByVal dgv As DataGridView)
        Dim i As Integer = 0
        Dim bExiste As Boolean
        'datahelper
        'Dim cur As New ADODB.Recordset
        Dim cur As DataTable
        bMostrar = False
        dgvDisponibles.Rows.Clear()
        cur = cur_lista
        'datahelper
        'If cur.BOF = False Or cur.EOF = False Then
        'cur.MoveFirst()
        'End If

        iBultos2 = 0
        iPeso2 = 0
        iVolumen2 = 0
        iSubtotal2 = 0
        iImpuesto2 = 0
        iTotal2 = 0

        'Do While cur.BOF = False And cur.EOF = False
        '    With dgv
        '        If dgvSeleccionados.Rows.Count > 0 Then
        '            If ExisteDocumento(cur.Fields(15).Value, dgvSeleccionados, 16) Then
        '                bExiste = True
        '            Else
        '                bExiste = False
        '            End If
        '        End If
        '        If Not bExiste Then
        '            .Rows.Add()
        '            .Rows(i).Cells(0).Value = cur.Fields(0).Value
        '            .Rows(i).Cells(1).Value = cur.Fields(1).Value
        '            .Rows(i).Cells(2).Value = CDate(cur.Fields(2).Value).Date.ToShortDateString
        '            .Rows(i).Cells(3).Value = cur.Fields(3).Value
        '            .Rows(i).Cells(4).Value = cur.Fields(4).Value
        '            .Rows(i).Cells(5).Value = cur.Fields(5).Value
        '            .Rows(i).Cells(6).Value = cur.Fields(6).Value
        '            .Rows(i).Cells(7).Value = FormatNumber(cur.Fields(7).Value, 2)
        '            .Rows(i).Cells(8).Value = FormatNumber(cur.Fields(8).Value, 2)
        '            .Rows(i).Cells(9).Value = FormatNumber(cur.Fields(9).Value, 2)
        '            .Rows(i).Cells(10).Value = FormatNumber(cur.Fields(10).Value, 2)
        '            .Rows(i).Cells(11).Value = FormatNumber(cur.Fields(11).Value, 2)
        '            .Rows(i).Cells(13).Value = cur.Fields(12).Value
        '            .Rows(i).Cells(14).Value = cur.Fields(13).Value
        '            .Rows(i).Cells(15).Value = cur.Fields(14).Value
        '            .Rows(i).Cells(16).Value = cur.Fields(15).Value
        '            .Rows(i).Cells(17).Value = cur.Fields(16).Value
        '            .Rows(i).Cells(18).Value = cur.Fields(17).Value
        '            .Rows(i).Cells(19).Value = cur.Fields(18).Value
        '            .Rows(i).Cells(20).Value = cur.Fields(19).Value

        '            .Rows(i).Cells(21).Value = FormatNumber(cur.Fields(20).Value, 2)
        '            .Rows(i).Cells(22).Value = FormatNumber(cur.Fields(21).Value, 2)
        '            .Rows(i).Cells(23).Value = FormatNumber(cur.Fields(22).Value, 2)
        '            .Rows(i).Cells(24).Value = cur.Fields(23).Value
        '            .Rows(i).Cells(25).Value = ObtieneParcial(Val(cur.Fields(23).Value))
        '            .Rows(i).Cells(26).Value = cur.Fields(24).Value
        '            .Rows(i).Cells(27).Value = cur.Fields(25).Value

        '            .Rows(i).Cells(28).Value = cur.Fields(26).Value
        '            .Rows(i).Cells(29).Value = cur.Fields(27).Value

        '            .Rows(i).Cells(30).Value = cur.Fields(28).Value
        '            .Rows(i).Cells(31).Value = cur.Fields(29).Value
        '            .Rows(i).Cells(32).Value = cur.Fields(30).Value


        '            iBultos2 += .Rows(i).Cells(5).Value
        '            iPeso2 += .Rows(i).Cells(7).Value
        '            iVolumen2 += .Rows(i).Cells(8).Value
        '            iSubtotal2 += .Rows(i).Cells(9).Value
        '            iImpuesto2 += .Rows(i).Cells(10).Value
        '            iTotal2 += .Rows(i).Cells(11).Value

        '            If bFiltrar Then
        '                If Not IsDBNull(cur.Fields(3).Value) Then
        '                    If cboCliente.FindStringExact(cur.Fields(3).Value, 0) = -1 Then
        '                        cboCliente.Items.Add(cur.Fields(3).Value)
        '                    End If
        '                End If
        '            End If
        '            i += 1
        '        End If
        '    End With
        '    cur.MoveNext()
        'Loop
        'cur.Requery()

        For Each obj As DataRow In cur.Rows
            With dgv
                If dgvSeleccionados.Rows.Count > 0 Then
                    If ExisteDocumento(obj.Item(15), dgvSeleccionados, 16) Then
                        bExiste = True
                    Else
                        bExiste = False
                    End If
                End If
                If Not bExiste Then
                    .Rows.Add()
                    .Rows(i).Cells(0).Value = obj.Item(0)
                    .Rows(i).Cells(1).Value = obj.Item(1)
                    .Rows(i).Cells(2).Value = CDate(obj.Item(2)).Date.ToShortDateString
                    .Rows(i).Cells(3).Value = obj.Item(3)
                    .Rows(i).Cells(4).Value = obj.Item(4)
                    .Rows(i).Cells(5).Value = obj.Item(5)
                    .Rows(i).Cells(6).Value = obj.Item(6)
                    .Rows(i).Cells(7).Value = FormatNumber(obj.Item(7), 2)
                    .Rows(i).Cells(8).Value = FormatNumber(obj.Item(8), 2)
                    .Rows(i).Cells(9).Value = FormatNumber(obj.Item(9), 2)
                    .Rows(i).Cells(10).Value = FormatNumber(obj.Item(10), 2)
                    .Rows(i).Cells(11).Value = FormatNumber(obj.Item(11), 2)
                    .Rows(i).Cells(13).Value = obj.Item(12)
                    .Rows(i).Cells(14).Value = obj.Item(13)
                    .Rows(i).Cells(15).Value = obj.Item(14)
                    .Rows(i).Cells(16).Value = obj.Item(15)
                    .Rows(i).Cells(17).Value = obj.Item(16)
                    .Rows(i).Cells(18).Value = obj.Item(17)
                    .Rows(i).Cells(19).Value = obj.Item(18)
                    .Rows(i).Cells(20).Value = obj.Item(19)

                    .Rows(i).Cells(21).Value = FormatNumber(obj.Item(20), 2)
                    .Rows(i).Cells(22).Value = FormatNumber(obj.Item(21), 2)
                    .Rows(i).Cells(23).Value = FormatNumber(obj.Item(22), 2)
                    .Rows(i).Cells(24).Value = obj.Item(23)
                    .Rows(i).Cells(25).Value = ObtieneParcial(Val(obj.Item(23)))
                    .Rows(i).Cells(26).Value = obj.Item(24)
                    .Rows(i).Cells(27).Value = obj.Item(25)

                    .Rows(i).Cells(28).Value = obj.Item(26)
                    .Rows(i).Cells(29).Value = obj.Item(27)

                    .Rows(i).Cells(30).Value = obj.Item(28)
                    .Rows(i).Cells(31).Value = obj.Item(29)
                    .Rows(i).Cells(32).Value = obj.Item(30)


                    iBultos2 += .Rows(i).Cells(5).Value
                    iPeso2 += .Rows(i).Cells(7).Value
                    iVolumen2 += .Rows(i).Cells(8).Value
                    iSubtotal2 += .Rows(i).Cells(9).Value
                    iImpuesto2 += .Rows(i).Cells(10).Value
                    iTotal2 += .Rows(i).Cells(11).Value

                    If bFiltrar Then
                        If Not IsDBNull(obj.Item(3)) Then
                            If cboCliente.FindStringExact(obj.Item(3), 0) = -1 Then
                                cboCliente.Items.Add(obj.Item(3))
                            End If
                        End If
                    End If
                    i += 1
                End If
            End With
        Next

        cur_lista = cur
        cboCliente.Sorted = True
        cboCliente.SelectedIndex = iPosicion
        bMostrar = True
        'cur.MoveFirst()
        lblRegistros1.Text = Registros(dgvDisponibles)
        lblRegistros2.Text = Registros(dgvSeleccionados)
        Total2()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FrmSimuladorCarga_MenuGrabar() Handles Me.MenuGrabar
        If dgvSeleccionados.Rows.Count = 0 Then
            MessageBox.Show("No ha seleccionado ningún documento.", "Titán", MessageBoxButtons.OK)
            TxtBus.Focus()
            TxtBus.SelectAll()
            Return
        End If

        If Val(txtSpk.Text) = 0 Then
            MessageBox.Show("El SPK debe tener algún valor.", "Titán", MessageBoxButtons.OK)
            TxtBus.Focus()
            TxtBus.SelectAll()
            Return
        End If

        Grabar()
    End Sub

    Private Sub FrmSimuladorCarga_MenuNuevo() Handles Me.MenuNuevo
        Nuevo()
    End Sub

    Private Sub Listar()
        Dim dFecha1 As Date
        Dim dFecha2 As Date
        Dim iUsuario As Integer

        dFecha1 = dtpFecha.Value.Date
        dFecha2 = dtpFecha2.Value.Date

        'iUsuario = dtoUSUARIOS.IdLogin

        iUsuario = coll_usuarios(cboUsuario.SelectedIndex + 1)

        'objSimulador.Año = iAño
        'objSimulador.Mes = iMes
        objSimulador.Fecha = dFecha1
        objSimulador.Fecha2 = dFecha2

        objSimulador.Usuario = iUsuario
        If objSimulador.Listar() Then
            'datahelper
            'Dim dt As New DataTable
            'Dim dv As New DataView
            'Dim da As New OleDb.OleDbDataAdapter

            'da.Fill(dt, objSimulador.cur_lista)
            'dv = dt.DefaultView

            'dgvLista.Columns.Clear()
            'dgvLista.DataSource = dv
            dgvLista.Columns.Clear()
            dgvLista.DataSource = objSimulador.cur_lista
        End If
        dgvLista.Columns(5).Visible = False

        If dgvLista.Rows.Count = 0 Then
            MenuStrip1.Items(1).Enabled = False 'editar
            MenuStrip1.Items(4).Enabled = False 'eliminar
            MenuStrip1.Items(6).Enabled = False
        Else
            MenuStrip1.Items(0).Enabled = True
            MenuStrip1.Items(1).Enabled = True
            MenuStrip1.Items(3).Enabled = False
            MenuStrip1.Items(4).Enabled = True
            MenuStrip1.Items(6).Enabled = True
        End If
    End Sub

    Private Sub FrmSimuladorCarga_MenuEliminar() Handles Me.MenuEliminar

        Dim iUsuario As Integer = dtoUSUARIOS.IdLogin
        Dim iDocumento As Integer = dgvLista.SelectedRows.Item(0).Index()
        Dim iNumero As Integer = dgvLista.Rows(iDocumento).Cells(1).Value
        Dim iUsuario2 As Integer = dgvLista.Rows(iDocumento).Cells(5).Value

        If iUsuario <> iUsuario2 Then
            MessageBox.Show("No podrá eliminar la simulación", "Titán", MessageBoxButtons.OK)
            Return
        End If

        Dim iResp As Integer
        iResp = MessageBox.Show("¿Está seguro de eliminar la simulación?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If iResp = vbYes Then
            Dim iAño As Integer
            Dim iMes As Integer
            Dim dFecha As String

            dFecha = dgvLista.Rows(iDocumento).Cells(0).Value 'Year(dtoUSUARIOS.m_sFecha)

            objSimulador.Fecha = dFecha
            objSimulador.Usuario = iUsuario
            objSimulador.Numero = iNumero
            objSimulador.Eliminar()
            With objSimulador
                If .ListarUsuarios Then
                    'datahelper
                    'ModuUtil.LlenarComboIDs(.cur_usuarios, cboUsuario, coll_usuarios, 0)
                    ModuUtil.LlenarCombo2(.cur_usuarios, cboUsuario, coll_usuarios, 0)

                    For i As Integer = 0 To coll_usuarios.Count - 1
                        If dtoUSUARIOS.IdLogin = coll_usuarios(i + 1) Then
                            cboUsuario.SelectedIndex = i
                            Exit For
                        End If
                    Next
                End If
            End With
            Listar()
        End If
    End Sub

    Private Sub TabMante_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabMante.SelectedIndexChanged
        If TabMante.SelectedIndex = 0 Then
            If dgvLista.Rows.Count = 0 Then
                MenuStrip1.Items(0).Enabled = True 'editar
                MenuStrip1.Items(1).Enabled = False 'editar
                MenuStrip1.Items(3).Enabled = False
                MenuStrip1.Items(4).Enabled = False 'eliminar
                MenuStrip1.Items(6).Enabled = False
            Else
                MenuStrip1.Items(0).Enabled = True
                MenuStrip1.Items(1).Enabled = True
                MenuStrip1.Items(3).Enabled = False
                MenuStrip1.Items(4).Enabled = True
                MenuStrip1.Items(6).Enabled = True

                iBultos = 0
                iPeso = 0
                iVolumen = 0
                iSubtotal = 0
                iImpuesto = 0
                iTotal = 0

                iBultos2 = 0
                iPeso2 = 0
                iVolumen2 = 0
                iSubtotal2 = 0
                iImpuesto2 = 0
                iTotal2 = 0

            End If
            iControl = 1
        ElseIf iControl <> 100 Then
            lblRegistros1.Text = Registros(dgvDisponibles)
            lblRegistros2.Text = Registros(dgvSeleccionados)
            txtKilometraje.Text = ""

            iBultos = 0
            iPeso = 0
            iVolumen = 0
            iSubtotal = 0
            iImpuesto = 0
            iTotal = 0

            iBultos2 = 0
            iPeso2 = 0
            iVolumen2 = 0
            iSubtotal2 = 0
            iImpuesto2 = 0
            iTotal2 = 0

            Total()
            Total2()

            Nuevo()
        End If
    End Sub

    Private Sub Nuevo()
        If bNuevo Then Return
        iBus = 0
        bNuevo = True
        bNuevo2 = True
        TabMante.SelectedTab = TabDatos
        MenuTab.Items(1).Select()
        iControl = 1
        lblLimite.Visible = False
        lblLimite2.Visible = False

        bInicio = True
        dtpFin.Value = Date.Now.ToShortDateString
        dtpInicio.Value = DateAdd(DateInterval.Day, -1, dtpFin.Value)
        dtpInicio.Checked = True

        MenuStrip1.Items(0).Enabled = False 'nuevo
        MenuStrip1.Items(1).Enabled = False 'editar
        MenuStrip1.Items(3).Enabled = True  'grabar
        MenuStrip1.Items(4).Enabled = False 'eliminar
        MenuStrip1.Items(6).Enabled = False 'eliminar

        cboOrigen.Enabled = True
        cboDestino.Enabled = True
        cboAgencia.Enabled = True

        cboCliente.Items.Clear()

        cboOrigen.Items.Clear()
        cboDestino.Items.Clear()
        cboAgencia.Items.Clear()

        cboOrigen.Items.Add("--TODOS--")
        cboDestino.Items.Add("--TODOS--")
        cboAgencia.Items.Add("--TODOS--")

        cboOrigen.SelectedIndex = 0
        cboDestino.SelectedIndex = 0
        cboAgencia.SelectedIndex = 0

        cboCliente.Items.Add("--TODOS--")
        cboCliente.SelectedIndex = 0

        dgvDisponibles.Rows.Clear()
        dgvSeleccionados.Rows.Clear()

        'grbCabecera.Enabled = True
        cbobus.Enabled = True
        TxtBus.Enabled = True

        cboOperador.SelectedIndex = 0
        txtPeso2.Text = ""
        txtPeso2.Enabled = False

        TxtBus.Text = "-1"
        CargarBus()

        TxtBus.Text = ""
        cbobus.SelectedIndex = 0
        cboParcial.SelectedIndex = 0
        cboTipoDocumento.SelectedIndex = 0

        'cboSalida.Items.Clear()
        bNuevo = False
        'txtSalida.Text = ""
        chkTodo.Checked = False

        dgvTramo.Rows.Clear()

        TxtBus.Focus()
    End Sub

    Private Sub dgvLista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLista.DoubleClick
        FrmSimuladorCarga_MenuEditar()
    End Sub

    Private Sub FrmSimuladorCarga_MenuEditar() Handles Me.MenuEditar
        If dgvLista.Rows.Count = 0 Then Return
        Dim dFecha As String
        Dim iUsuario As Integer
        Dim iSalida As Integer

        bNuevo2 = False
        bInicio = True
        iBultos = 0
        iPeso = 0
        iVolumen = 0
        iSubtotal = 0
        iImpuesto = 0
        iTotal = 0

        iBultos2 = 0
        iPeso2 = 0
        iVolumen2 = 0
        iSubtotal2 = 0
        iImpuesto2 = 0
        iTotal2 = 0

        cboCliente.Items.Clear()
        cboCliente.Items.Add("--TODOS--")
        cboCliente.SelectedIndex = 0

        dgvDisponibles.Columns.Clear()
        dgvSeleccionados.Columns.Clear()
        chkTodo.Checked = False
        ConfiguraGrid()

        bInicio = True
        dtpInicio.Value = DateAdd(DateInterval.Day, -1, dtpFin.Value)
        cboTipoDocumento.SelectedIndex = 0
        cboCliente.SelectedIndex = 0

        Dim iDocumento As Integer = dgvLista.SelectedRows.Item(0).Index()
        dNumero = dgvLista.Rows(iDocumento).Cells(1).Value

        dFecha = dgvLista.Rows(iDocumento).Cells(0).Value 'Year(dtoUSUARIOS.m_sFecha)
        iUsuario = dgvLista.Rows(iDocumento).Cells(5).Value 'dtoUSUARIOS.IdLogin

        objSimulador.Fecha = dFecha
        objSimulador.Usuario = iUsuario
        objSimulador.Numero = dNumero

        iControl = 100
        If IsDBNull(dgvLista.Rows(iDocumento).Cells(2).Value) Then
            If objSimulador.Cargar Then
                With objSimulador
                    Me.Cursor = Cursors.AppStarting
                    btnFiltrar.Enabled = True
                    txtBus.Text = ""
                    cur_lista = objSimulador.cur_lista
                    CargarSeleccionados()
                    Total()

                    MenuStrip1.Items(0).Enabled = False 'nuevo
                    MenuStrip1.Items(1).Enabled = False 'editar
                    MenuStrip1.Items(3).Enabled = True  'grabar
                    MenuStrip1.Items(4).Enabled = False 'eliminar
                    MenuStrip1.Items(6).Enabled = False

                    Me.Cursor = Cursors.Default
                    TabMante.SelectTab(1)
                End With
            End If
        Else
            If objSimulador.Cargar2() Then
                With objSimulador
                    Me.Cursor = Cursors.AppStarting
                    'datahelper
                    'txtBus.Text = .cur_lista.Fields("bus").Value
                    txtBus.Text = .cur_lista.Rows(0).Item("bus")

                    'datahelper
                    'cboUnidadOrigen.SelectedIndex = ObtieneUnidadAgencia(.cur_lista.Fields("origen").Value, 1)
                    'cboUnidadDestino.SelectedIndex = ObtieneUnidadAgencia(.cur_lista.Fields("destino").Value, 2)
                    'txtKilometraje.Text = FormatNumber(.cur_lista.Fields("kilometraje").Value, 2)
                    'txtSpk.Text = FormatNumber(.cur_lista.Fields("spk").Value, 2)
                    cboUnidadOrigen.SelectedIndex = ObtieneUnidadAgencia(.cur_lista.Rows(0).Item("origen"), 1)
                    cboUnidadDestino.SelectedIndex = ObtieneUnidadAgencia(.cur_lista.Rows(0).Item("destinos"), 2)
                    txtKilometraje.Text = FormatNumber(.cur_lista.Rows(0).Item("kilometraje"), 2)
                    txtSpk.Text = FormatNumber(.cur_lista.Rows(0).Item("spk"), 2)

                    cur_lista = objSimulador.cur_lista
                    CargarSeleccionados()

                    'Recupera tramos de simulacion
                    dgvTramo.Rows.Clear()
                    'datahelper
                    'If .cur_Tramo2.BOF = False And .cur_Tramo2.EOF = False Then
                    '    coll_destino.Clear()
                    '    cboDestino.Items.Clear()
                    '    cboDestino.Items.Add("--TODOS--")
                    '    coll_destino.Add(0)
                    '    Do While .cur_Tramo2.BOF = False And .cur_Tramo2.EOF = False
                    '        dgvTramo.Rows.Add()
                    '        dgvTramo.Rows(dgvTramo.Rows.Count - 1).Cells(0).Value = .cur_Tramo2.Fields(0).Value
                    '        dgvTramo.Rows(dgvTramo.Rows.Count - 1).Cells(1).Value = .cur_Tramo2.Fields(1).Value
                    '        dgvTramo.Rows(dgvTramo.Rows.Count - 1).Cells(2).Value = .cur_Tramo2.Fields(2).Value

                    '        If .cur_Tramo2.Fields(0).Value <> coll_UnidadDestino(cboUnidadDestino.SelectedIndex - 1) Then
                    '            cboDestino.Items.Add(.cur_Tramo2.Fields(1).Value())
                    '            coll_destino.Add(.cur_Tramo2.Fields(0).Value())
                    '        End If
                    '        .cur_Tramo2.MoveNext()
                    '    Loop
                    'Else
                    '    objSimulador.EliminaTramoTmp()
                    'End If
                    If .cur_Tramo2.Rows.Count > 0 Then
                        coll_destino.Clear()
                        cboDestino.Items.Clear()
                        cboDestino.Items.Add("--TODOS--")
                        coll_destino.Add(0)
                        For Each row As DataRow In .cur_Tramo2.Rows

                            dgvTramo.Rows.Add()
                            dgvTramo.Rows(dgvTramo.Rows.Count - 1).Cells(0).Value = row(0)
                            dgvTramo.Rows(dgvTramo.Rows.Count - 1).Cells(1).Value = row(1)
                            dgvTramo.Rows(dgvTramo.Rows.Count - 1).Cells(2).Value = row(2)

                            If row(0) <> coll_UnidadDestino(cboUnidadDestino.SelectedIndex - 1) Then
                                cboDestino.Items.Add(row(1))
                                coll_destino.Add(row(0))
                            End If
                        Next
                    Else
                        objSimulador.EliminaTramoTmp()
                    End If


                    txtKilometraje.Text = FormatNumber(txtKilometraje.Text, 2)
                    cboDestino.SelectedIndex = 0

                    bNuevo2 = True

                    If objSimulador.BusDatos(txtBus.Text.Trim, iSalida, 2) Then
                        'datahelper
                        'If objSimulador.cur_documento.BOF = False And objSimulador.cur_documento.EOF = False Then
                        If objSimulador.cur_documento.Rows.Count > 0 Then
                            btnFiltrar.Enabled = True
                            btnFiltrar.Focus()
                        End If
                    Else
                        btnFiltrar.Enabled = False
                    End If

                    Total()

                    iControl = 100
                    MenuStrip1.Items(0).Enabled = False 'nuevo
                    MenuStrip1.Items(1).Enabled = False 'editar
                    MenuStrip1.Items(3).Enabled = True  'grabar
                    MenuStrip1.Items(4).Enabled = False 'eliminar
                    MenuStrip1.Items(6).Enabled = False

                    If iUsuario <> dtoUSUARIOS.IdLogin Then
                        MenuStrip1.Items(3).Enabled = False
                    Else
                        MenuStrip1.Items(3).Enabled = True
                    End If

                    Me.Cursor = Cursors.Default
                    TabMante.SelectTab(1)
                End With
            End If
        End If
        If Val(lbl1.Text) > 0 Then
            iCapacidad = CDbl(Mid(lbl1.Text, 1, lbl1.Text.Length - 3))
        Else
            iCapacidad = 0
        End If
        ExcedeLimite()
    End Sub

    Private Function ExisteDocumento2(ByVal documento As String, ByVal grd As DataGridView, Optional ByVal col As Integer = 1) As Integer
        If grd.Rows.Count > 0 Then
            Dim sSerie As String
            Dim sNumero As String
            Dim iPos As Integer
            Dim sDoc As String

            sDoc = documento.Trim
            iPos = InStr(sDoc, "-")
            If iPos > 0 Then
                sSerie = Mid(sDoc, 1, iPos - 1)
                sNumero = Mid(sDoc, iPos + 1)
                With grd
                    For i As Integer = 0 To .Rows.Count - 1
                        iPos = InStr(grd.Rows(i).Cells(col).Value, "-")
                        If iPos > 0 Then
                            Dim sSerie2 As String
                            Dim sNumero2 As String

                            sSerie2 = Mid(grd.Rows(i).Cells(col).Value, 1, iPos - 1)
                            sNumero2 = Mid(grd.Rows(i).Cells(col).Value, iPos + 1)

                            If Val(sSerie) = Val(sSerie2) And Val(sNumero) = Val(sNumero2) Then
                                Return i
                            End If
                        End If
                    Next
                    Return -1
                End With
            Else
                With grd
                    For i As Integer = 0 To .Rows.Count - 1
                        iPos = InStr(grd.Rows(i).Cells(col).Value, "-")
                        If iPos = 0 Then
                            If Val(documento) = Val(grd.Rows(i).Cells(col).Value) Then
                                Return i
                            End If
                        End If
                    Next
                    Return -1
                End With
            End If
        Else
            Return -1
        End If
    End Function

    Private Sub dgvDisponibles_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDisponibles.CellContentClick

    End Sub

    Private Sub dgvDisponibles_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvDisponibles.MouseDown

        'If e.Button <> Windows.Forms.MouseButtons.Left Or dgvDisponibles.Rows.Count = 0 Then Return

        'ReDim _values(Me.dgvDisponibles.Columns.Count - 1)
        'Dim clickedCell As DataGridViewCell

        'Dim hit As DataGridView.HitTestInfo = _
        'dgvDisponibles.HitTest(e.X, e.Y)

        'If hit.Type = DataGridViewHitTestType.Cell Then
        '    clickedCell = _
        '    dgvDisponibles.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
        'End If

        '' Variable que contiene la fila actual
        ''
        'Dim _currentRow As Int32 = clickedCell.RowIndex

        '' Rellenamos los valores correspondientes a la fila donde
        '' el usuario ha hecho clic.
        ''
        'Dim row As DataGridViewRow = Me.dgvDisponibles.Rows(_currentRow)

        'Dim n As Int32 = 0
        'For Each cell As DataGridViewCell In row.Cells
        '    _values(n) = cell.Value
        '    n += 1
        'Next

        '' Iniciamos la operación Drap & Drop.
        ''
        'Dim dropEffect As DragDropEffects

        'dropEffect = _
        'dgvDisponibles.DoDragDrop(_values, _
        'DragDropEffects.All Or DragDropEffects.Link)

    End Sub

    Private Sub dgvSeleccionados_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSeleccionados.CellContentClick

    End Sub

    Private Sub dgvSeleccionados_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvSeleccionados.DragDrop
        'Me.dgvSeleccionados.Rows.Add(_values)
    End Sub

    Private Sub dgvSeleccionados_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvSeleccionados.DragEnter
        'e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub FrmSimuladorCarga_MenuAyuda() Handles Me.MenuAyuda
        Dim sPath As String = Application.StartupPath.ToString & "\HelpTitan.chm"
        Help.ShowHelp(Me, sPath) ', HelpNavigator.TopicId, "2")
    End Sub

    Private Sub txtDocumento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDocumento.TextChanged

    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        If objSimulador Is Nothing Then Return
        Listar()
    End Sub

    Private Sub dtpFecha2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha2.ValueChanged
        If objSimulador Is Nothing Then Return
        Listar()
    End Sub

    Private Function AgregarDocumento() As Boolean
        Dim objSimulador As New dtoSimulador
        Dim sDocumento As String
        Dim bEstado As Boolean = False

        sDocumento = txtDocumento.Text.Trim
        If objSimulador.Documento(sDocumento, dtoUSUARIOS.IdLogin) Then
            If objSimulador.cur_doc.Rows.Count > 0 Then
                Dim i As Integer = 0
                'Do While objSimulador.cur_doc.BOF = False And objSimulador.cur_doc.EOF = False
                For Each obj As DataRow In objSimulador.cur_doc.Rows
                    With dgvSeleccionados
                        .Rows.Add()
                        i = .Rows.Count - 1
                        bInicio = True
                        .Rows(i).Cells(0).Value = obj.Item(0)
                        .Rows(i).Cells(1).Value = obj.Item(1)
                        .Rows(i).Cells(2).Value = obj.Item(2)
                        .Rows(i).Cells(3).Value = obj.Item(3)
                        .Rows(i).Cells(4).Value = obj.Item(4)
                        .Rows(i).Cells(5).Value = obj.Item(5)
                        .Rows(i).Cells(6).Value = obj.Item(6)
                        .Rows(i).Cells(7).Value = FormatNumber(obj.Item(7), 2)
                        .Rows(i).Cells(8).Value = FormatNumber(obj.Item(8), 2)
                        .Rows(i).Cells(9).Value = FormatNumber(obj.Item(9), 2)
                        .Rows(i).Cells(10).Value = FormatNumber(obj.Item(10), 2)
                        .Rows(i).Cells(11).Value = FormatNumber(obj.Item(11), 2)
                        .Rows(i).Cells(12).Value = 2
                        .Rows(i).Cells(13).Value = obj.Item(13)
                        .Rows(i).Cells(14).Value = obj.Item(14)
                        .Rows(i).Cells(15).Value = obj.Item(15)
                        .Rows(i).Cells(16).Value = obj.Item(16)
                        .Rows(i).Cells(17).Value = obj.Item(17)
                        .Rows(i).Cells(18).Value = obj.Item(18)
                        .Rows(i).Cells(19).Value = obj.Item(19)
                        .Rows(i).Cells(20).Value = obj.Item(20)
                        .Rows(i).Cells(21).Value = obj.Item(21)
                        .Rows(i).Cells(22).Value = obj.Item(22)
                        .Rows(i).Cells(23).Value = obj.Item(23)

                        .Rows(i).Cells(24).Value = obj.Item(24)
                        .Rows(i).Cells(25).Value = ObtieneParcial(Val(obj.Item(24)))
                        .Rows(i).Cells(26).Value = obj.Item(25)
                        .Rows(i).Cells(27).Value = obj.Item(26)

                        .Rows(i).Cells(28).Value = obj.Item(27)
                        .Rows(i).Cells(29).Value = obj.Item(28)

                        .Rows(i).Cells(30).Value = obj.Item(29)
                        .Rows(i).Cells(31).Value = obj.Item(30)

                        iBultos += .Rows(i).Cells(5).Value
                        iPeso += .Rows(i).Cells(7).Value
                        iVolumen += .Rows(i).Cells(8).Value
                        iSubtotal += .Rows(i).Cells(9).Value
                        iImpuesto += .Rows(i).Cells(10).Value
                        iTotal += .Rows(i).Cells(11).Value

                        i += 1
                    End With
                Next
                txtDocumento.Text = ""
                bEstado = True
            Else
                bEstado = False
            End If
        Else
            bEstado = False
            '    If objSimulador.cur_doc.BOF = False And objSimulador.cur_doc.EOF = False Then
            '        Dim i As Integer = 0
            '        Do While objSimulador.cur_doc.BOF = False And objSimulador.cur_doc.EOF = False
            '            With dgvSeleccionados
            '                .Rows.Add()
            '                i = .Rows.Count - 1
            '                bInicio = True
            '                .Rows(i).Cells(0).Value = objSimulador.cur_doc(0).Value
            '                .Rows(i).Cells(1).Value = objSimulador.cur_doc(1).Value
            '                .Rows(i).Cells(2).Value = objSimulador.cur_doc(2).Value
            '                .Rows(i).Cells(3).Value = objSimulador.cur_doc(3).Value
            '                .Rows(i).Cells(4).Value = objSimulador.cur_doc(4).Value
            '                .Rows(i).Cells(5).Value = objSimulador.cur_doc(5).Value
            '                .Rows(i).Cells(6).Value = objSimulador.cur_doc(6).Value
            '                .Rows(i).Cells(7).Value = FormatNumber(objSimulador.cur_doc(7).Value, 2)
            '                .Rows(i).Cells(8).Value = FormatNumber(objSimulador.cur_doc(8).Value, 2)
            '                .Rows(i).Cells(9).Value = FormatNumber(objSimulador.cur_doc(9).Value, 2)
            '                .Rows(i).Cells(10).Value = FormatNumber(objSimulador.cur_doc(10).Value, 2)
            '                .Rows(i).Cells(11).Value = FormatNumber(objSimulador.cur_doc(11).Value, 2)
            '                .Rows(i).Cells(12).Value = 2
            '                .Rows(i).Cells(13).Value = objSimulador.cur_doc(13).Value
            '                .Rows(i).Cells(14).Value = objSimulador.cur_doc(14).Value
            '                .Rows(i).Cells(15).Value = objSimulador.cur_doc(15).Value
            '                .Rows(i).Cells(16).Value = objSimulador.cur_doc(16).Value
            '                .Rows(i).Cells(17).Value = objSimulador.cur_doc(17).Value
            '                .Rows(i).Cells(18).Value = objSimulador.cur_doc(18).Value
            '                .Rows(i).Cells(19).Value = objSimulador.cur_doc(19).Value
            '                .Rows(i).Cells(20).Value = objSimulador.cur_doc(20).Value
            '                .Rows(i).Cells(21).Value = objSimulador.cur_doc(21).Value
            '                .Rows(i).Cells(22).Value = objSimulador.cur_doc(22).Value
            '                .Rows(i).Cells(23).Value = objSimulador.cur_doc(23).Value

            '                .Rows(i).Cells(24).Value = objSimulador.cur_doc(24).Value
            '                .Rows(i).Cells(25).Value = ObtieneParcial(Val(objSimulador.cur_doc(24).Value))
            '                .Rows(i).Cells(26).Value = objSimulador.cur_doc(25).Value
            '                .Rows(i).Cells(27).Value = objSimulador.cur_doc(26).Value

            '                .Rows(i).Cells(28).Value = objSimulador.cur_doc(27).Value
            '                .Rows(i).Cells(29).Value = objSimulador.cur_doc(28).Value

            '                .Rows(i).Cells(30).Value = objSimulador.cur_doc(29).Value
            '                .Rows(i).Cells(31).Value = objSimulador.cur_doc(30).Value

            '                iBultos += .Rows(i).Cells(5).Value
            '                iPeso += .Rows(i).Cells(7).Value
            '                iVolumen += .Rows(i).Cells(8).Value
            '                iSubtotal += .Rows(i).Cells(9).Value
            '                iImpuesto += .Rows(i).Cells(10).Value
            '                iTotal += .Rows(i).Cells(11).Value

            '                i += 1
            '            End With
            '            objSimulador.cur_doc.MoveNext()
            '        Loop
            '        txtDocumento.Text = ""
            '        bEstado = True
            '    Else
            '        bEstado = False
            '    End If
            'Else
            '    bEstado = False
        End If
        lblRegistros1.Text = Registros(dgvDisponibles)
        lblRegistros2.Text = Registros(dgvSeleccionados)
        Total()
        Return bEstado
        Me.Cursor = Cursors.Default
    End Function

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If dgvDisponibles.Rows.Count = 0 Then Return
        Dim iDocumento As Integer = dgvDisponibles.SelectedRows.Item(0).Index()

        If ExisteDocumento(dgvDisponibles.Rows(iDocumento).Cells(1).Value, dgvSeleccionados) Then
            MessageBox.Show("El Documento ya está seleccionado.", "Titán", MessageBoxButtons.OK)
            Return
        End If

        With dgvDisponibles
            Dim contenido(Me.dgvDisponibles.ColumnCount - 1) As String
            For Each fila As DataGridViewRow In .SelectedRows
                For columna As Integer = 0 To contenido.Length - 1
                    If columna = 5 Or columna = 6 Then
                        If columna = 5 Then
                            If fila.Cells(columna).Value <> fila.Cells(columna + 1).Value Then
                                If fila.Cells(columna + 1).Value > 0 Then
                                    contenido(columna) = fila.Cells(columna + 1).Value
                                Else
                                    contenido(columna) = fila.Cells(columna).Value
                                End If
                            Else
                                contenido(columna) = fila.Cells(columna).Value
                            End If
                        End If
                        If columna = 6 Then
                            contenido(columna) = 0
                        End If
                        'ElseIf columna = 19 Or columna = 20 Then
                        '    If columna = 19 Then
                        '        If fila.Cells(columna).Value <> fila.Cells(columna + 1).Value Then
                        '            contenido(columna) = fila.Cells(columna + 1).Value
                        '        Else
                        '            contenido(columna) = fila.Cells(columna).Value
                        '        End If
                        '    End If
                        '    If columna = 20 Then
                        '        contenido(columna) = fila.Cells(columna).Value
                        '    End If

                    Else
                        contenido(columna) = fila.Cells(columna).Value
                    End If
                Next
                iBultos2 -= fila.Cells(5).Value
                iPeso2 -= fila.Cells(7).Value
                iVolumen2 -= fila.Cells(8).Value
                iSubtotal2 -= fila.Cells(9).Value
                iImpuesto2 -= fila.Cells(10).Value
                iTotal2 -= fila.Cells(11).Value

                dgvDisponibles.Rows.Remove(fila)
                dgvSeleccionados.Rows.Add(contenido)
                If fila.Cells(5).Value <> fila.Cells(6).Value Then
                    iBultos += fila.Cells(6).Value
                Else
                    iBultos += fila.Cells(5).Value
                End If
                iPeso += fila.Cells(7).Value
                iVolumen += fila.Cells(8).Value
                iSubtotal += fila.Cells(9).Value
                iImpuesto += fila.Cells(10).Value
                iTotal += fila.Cells(11).Value
            Next
            lblRegistros1.Text = Registros(dgvDisponibles)
            lblRegistros2.Text = Registros(dgvSeleccionados)
            Total()
            Total2()
        End With
        ExcedeLimite()
    End Sub

    Private Sub btnDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDocumento.Click
        If Val(txtDocumento.Text.Trim) > 0 Then
            Me.Cursor = Cursors.AppStarting
            If ExisteDocumento2(txtDocumento.Text.Trim, dgvSeleccionados) = -1 Then
                Dim iCorr As Integer = ExisteDocumento2(txtDocumento.Text.Trim, dgvDisponibles)
                If iCorr >= 0 Then  'en disponible
                    txtDocumento.Text = ""
                    dgvDisponibles.ClearSelection()

                    dgvDisponibles.Rows(iCorr).Selected = True
                    BtnAgregar_Click(sender, e)
                Else
                    If AgregarDocumento() Then
                    Else
                        MessageBox.Show("El Documento no existe.", "Titán", MessageBoxButtons.OK)
                        txtDocumento.Focus()
                        txtDocumento.SelectAll()
                    End If
                End If
            Else    'esta seleccionado
                Dim iCorr As Integer = ExisteDocumento2(txtDocumento.Text.Trim, dgvSeleccionados)
                If iCorr >= 0 Then
                    txtDocumento.Text = ""
                    For i As Integer = 0 To dgvSeleccionados.Rows.Count - 1
                        dgvSeleccionados.Rows(i).Selected = False
                    Next i
                    dgvSeleccionados.Rows(iCorr).Selected = True
                    BtSacar_Click(sender, e)
                End If
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub cboOperador_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOperador.SelectedIndexChanged
        dgvDisponibles.Rows.Clear()
        lblRegistros1.Text = "0"
        If cboOperador.SelectedIndex > 0 Then
            bActualiza = False
            cboCliente.SelectedIndex = 0
            bActualiza = True
            txtPeso2.Enabled = True
            txtPeso2.Focus()
            txtPeso.SelectAll()
        Else
            txtPeso2.Enabled = False
            txtPeso2.Text = ""
        End If

        iBultos2 = 0
        iPeso2 = 0
        iVolumen2 = 0
        iSubtotal2 = 0
        iImpuesto2 = 0
        iTotal2 = 0
        Total2()
    End Sub

    Private Sub txtPeso2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPeso2.GotFocus
        txtPeso2.SelectAll()
    End Sub

    Private Sub txtPeso2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPeso2.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
        Else
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar) Or (e.KeyChar = "." And InStr(txtPeso2.Text, ".") = 0)) Then
                e.Handled = False
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtPeso2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPeso2.TextChanged
        dgvDisponibles.Rows.Clear()
        bActualiza = False
        cboCliente.SelectedIndex = 0
        bActualiza = True
        lblRegistros1.Text = "0"

        iBultos2 = 0
        iPeso2 = 0
        iVolumen2 = 0
        iSubtotal2 = 0
        iImpuesto2 = 0
        iTotal2 = 0
        Total2()

        Return

        'datahelper
        'If bInicio = False Then
        '    If cboOperador.SelectedIndex > 0 Then
        '        Dim iPeso As Double
        '        iPeso = IIf(Val(txtPeso2.Text) = 0, 0, txtPeso2.Text)
        '        If iPeso >= 0 Then
        '            Select Case cboOperador.SelectedIndex
        '                Case 1
        '                    cur_lista.Filter = "peso=" & iPeso & " "
        '                Case 2
        '                    cur_lista.Filter = "peso>" & iPeso & " "
        '                Case 3
        '                    cur_lista.Filter = "peso<" & iPeso & " "
        '                Case 4
        '                    cur_lista.Filter = "peso>=" & iPeso & " "
        '                Case 5
        '                    cur_lista.Filter = "peso<=" & iPeso & " "
        '            End Select
        '        Else
        '            cur_lista.Filter = ADODB.FilterGroupEnum.adFilterNone
        '        End If
        '    Else
        '        cur_lista.Filter = ADODB.FilterGroupEnum.adFilterNone
        '    End If
        '    Mostrar(dgvDisponibles)
        'End If
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        If TxtBus.Text.Trim.Length = 0 Then Return
        Me.Cursor = Cursors.AppStarting
        If cboOrigen.Items.Count <= 1 Then
            If objSimulador.Unidad(txtBus.Text.Trim, 1) Then
                LlenarCombo2(objSimulador.cur_origen, cboOrigen, coll_origen, 0)
                LlenarCombo2(objSimulador.cur_destino, cboDestino, coll_destino, 0)
                'LlenarComboIDs(objSimulador.cur_origen, cboOrigen, coll_origen, 0)
                'LlenarComboIDs(objSimulador.cur_destino, cboDestino, coll_destino, 0)
            End If
        End If

        If dgvTramo.Rows.Count > 0 Then
            'Actualiza tramos temporal
            ActualizaTramoTmp()
        Else
            objSimulador.EliminaTramoTmp()
        End If

        iBultos2 = 0
        iPeso2 = 0
        iVolumen2 = 0
        iSubtotal2 = 0
        iImpuesto2 = 0
        iTotal2 = 0

        cboCliente.Items.Clear()
        cboCliente.Items.Add("--TODOS--")
        cboCliente.SelectedIndex = 0

        bFiltrar = True
        CargarBus()
        bFiltrar = False
        If cboCliente.SelectedIndex > 0 Then
            cboCliente_SelectedIndexChanged(sender, e)
        End If

        Me.Cursor = Cursors.Default

        If dgvDisponibles.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron documentos disponibles.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub CargarBus()
        Dim objSimulador As New dtoSimulador
        Dim sBus As String
        Dim sIni As String
        Dim sFin As String
        Dim iOperador As Integer
        Dim iCantidad As Integer
        Dim iDocumento As Integer
        Dim iOrigen As Integer
        Dim iCiudad1 As Integer
        Dim iCiudad2 As Integer
        Dim iTipo As Integer
        Dim iNuevo As Integer
        Dim iParcial As Integer
        Dim iSalida As Integer
        Dim iUnidad1 As Integer
        Dim iUnidad2 As Integer

        bInicio = True
        If cbobus.SelectedIndex >= 0 Then
            sBus = TxtBus.Text.Trim
            If dtpInicio.Checked Then
                sIni = dtpInicio.Value.ToShortDateString
            Else
                sIni = "01/01/2005"
            End If
            sFin = dtpFin.Value.ToShortDateString
            Select Case cboTipoDocumento.SelectedIndex
                Case 0
                    iDocumento = 100
                Case 1
                    iDocumento = 1
                Case 2
                    iDocumento = 2
                Case 3
                    iDocumento = 3
                Case 4
                    iDocumento = 85
            End Select

            If TxtBus.Text = "-1" Then
                iDocumento = 1000
            End If

            Dim iPeso As Double
            iOperador = cboOperador.SelectedIndex
            If Val(txtPeso2.Text) < 0 Then
                iOperador = 0
                iPeso = 0
            Else
                iPeso = IIf(Val(txtPeso2.Text) = 0, 0, txtPeso2.Text)
            End If

            If cboAgencia.SelectedIndex = -1 Or cboAgencia.Items.Count <= 1 Then
                iOrigen = 0
            Else
                iOrigen = coll_agencia(cboAgencia.SelectedIndex + 1)
            End If

            If cboOrigen.SelectedIndex <= 0 Then
                If cboOrigen.Items.Count > 1 And chkTodo.Checked = False Then
                    iCiudad1 = coll_origen(2)
                Else
                    iCiudad1 = 0
                End If
                'iCiudad1 = IIf(cboOrigen.Items.Count > 1, coll_origen(2), 0)
            Else
                iCiudad1 = coll_origen(cboOrigen.SelectedIndex + 1)
            End If

            If cboDestino.SelectedIndex <= 0 Then
                iCiudad2 = 0
            Else
                iCiudad2 = coll_destino(cboDestino.SelectedIndex + 1)
            End If

            'iTipo = IIf(chkTodo.Checked, 2, 1)
            If chkTodo.Checked Or iCiudad2 > 0 Then
                iTipo = 2
            Else
                iTipo = 1
            End If

            iNuevo = IIf(bNuevo, 1, 0)
            iParcial = cboParcial.SelectedIndex

            If cboUnidadOrigen.SelectedIndex <= 0 Then
                iUnidad1 = 0
            Else
                iUnidad1 = coll_UnidadOrigen(cboUnidadOrigen.SelectedIndex + 1)
            End If

            If cboUnidadDestino.SelectedIndex <= 0 Then
                iUnidad2 = 0
            Else
                iUnidad2 = coll_UnidadDestino(cboUnidadDestino.SelectedIndex + 1)
            End If
            '----
            If objSimulador.ListaUnidadSalida2(sBus, sIni, sFin, iDocumento, iControl, dtoUSUARIOS.IdLogin, iOperador, iPeso, iOrigen, iCiudad1, iCiudad2, iTipo, iNuevo, iParcial, iSalida, iUnidad1, iUnidad2) Then
                'If objSimulador.cur_documento.BOF = False And objSimulador.cur_documento.EOF = False Then
                ''''''
                cur_lista = objSimulador.cur_lista
                cur_clon = cur_lista
                '''''
                'If iControl = 1 Then
                'If IsDBNull(objSimulador.cur_documento.Fields("kilometros").Value) Then
                ' txtKilometraje.Text = "0.00"
                'Else
                '   txtKilometraje.Text = FormatNumber(Convert.ToDouble(objSimulador.cur_documento.Fields("kilometros").Value), 2)
                'End If
                'End If

                Mostrar(dgvDisponibles)
                bInicio = False

            ElseIf txtBus.Text <> "-1" Then
                MessageBox.Show("El Bus no se encuentra creado,activo ni con cierre de bodega en salida.", "Titán", MessageBoxButtons.OK)
            End If
            txtBultos.Text = FormatNumber(iBultos, 0)
            txtPeso.Text = FormatNumber(iPeso, 2)
            txtVolumen.Text = FormatNumber(iVolumen, 2)
            txtTot.Text = FormatNumber(iPeso + iVolumen, 2)
            txtSubtotal.Text = FormatNumber(iSubtotal, 2)
            txtImpuesto.Text = FormatNumber(iImpuesto, 2)
            txtTotal.Text = FormatNumber(iTotal, 2)

            'Dim dt As New DataTable
            'Dim dv As New DataView
            'Dim da As New OleDb.OleDbDataAdapter

            'da.Fill(dt, objSimulador.cur_lista)
            'dv = dt.DefaultView

            'dgvDisponibles.Columns.Clear()
            'dgvDisponibles.DataSource = dv
            lblRegistros1.Text = Registros(dgvDisponibles)
            lblRegistros2.Text = Registros(dgvSeleccionados)
            Total()

        End If
    End Sub

    Private Function ObtieneOrigen() As Integer
        Dim i As Integer
        Dim sUnidad As String = cboAgencia.SelectedValue

        For i = 1 To coll_agencia.Count
            If Val(sUnidad) = coll_agencia(i) Then
                Return i - 1
                Exit Function
            End If
        Next
        Return 0
    End Function

    Private Sub cboAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAgencia.SelectedIndexChanged
        dgvDisponibles.Rows.Clear()
        If cboCliente.Items.Count > 0 Then
            bActualiza = False
            cboCliente.SelectedIndex = 0
            bActualiza = True
        End If
        lblRegistros1.Text = "0"

        iBultos2 = 0
        iPeso2 = 0
        iVolumen2 = 0
        iSubtotal2 = 0
        iImpuesto2 = 0
        iTotal2 = 0
        Total2()

        Return
        If bInicio = False Then
            If cboAgencia.SelectedIndex = 0 Then
                'cur_lista.Filter = ADODB.FilterGroupEnum.adFilterNone
            Else
                'cur_lista.Filter = "agencia='" & cboAgencia.Text & "'"
            End If
            Mostrar(dgvDisponibles)
        End If
    End Sub

    Private Sub cboOrigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOrigen.SelectedIndexChanged, cboParcial.SelectedIndexChanged
        'iBultos2 = 0
        'iPeso2 = 0
        'iVolumen2 = 0
        'iSubtotal2 = 0
        'iImpuesto2 = 0
        'iTotal2 = 0
        'Total2()

        If coll_origen.Count = 0 Then
            Return
        Else
            If cboOrigen.SelectedIndex = 0 Then
                cboAgencia.Items.Clear()
                cboAgencia.Items.Add("--TODOS--")
                cboAgencia.SelectedIndex = 0
                Return
            End If
            With objSimulador
                Dim sUnidad As String = coll_origen(cboOrigen.SelectedIndex + 1)
                If .Agencia(sUnidad) Then
                    'datahelper
                    'ModuUtil.LlenarComboIDs(.cur_agencia, cboAgencia, coll_agencia, 0)
                    ModuUtil.LlenarCombo2(.cur_agencia, cboAgencia, coll_agencia, 0)
                End If
            End With
        End If
    End Sub

    Private Sub Total2()
        txtBultos22.Text = FormatNumber(iBultos2, 0)
        txtPeso22.Text = FormatNumber(iPeso2, 2)
        txtVolumen22.Text = FormatNumber(iVolumen2, 2)
        txtTot2.Text = FormatNumber(iPeso2 + iVolumen2, 2)
        txtSubtotal22.Text = FormatNumber(iSubtotal2, 2)
        txtImpuesto22.Text = FormatNumber(iImpuesto2, 2)
        txtTotal22.Text = FormatNumber(iTotal2, 2)
    End Sub

    Private Sub cboUsuario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUsuario.SelectedIndexChanged
        If objSimulador Is Nothing Then Return
        Listar()
    End Sub

    Private Sub ExcedeLimite()
        Dim iPeso As Double
        iPeso = CDbl(txtPeso.Text) + CDbl(txtVolumen.Text)
        If CDbl(iCapacidad) < iPeso Then
            lblLimite.Visible = True
            lblLimite2.Visible = True
            lblLimite2.Text = FormatNumber(iPeso - iCapacidad, 2) & " Kg."
        Else
            lblLimite.Visible = False
            lblLimite2.Visible = False
            lblLimite2.Text = "0.00"
        End If
    End Sub

    'Private Sub btnSalida_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnSalida.MouseMove
    'Dim tip As New ToolTip
    '   tip.ShowAlways = True
    '  tip.SetToolTip(btnSalida, "Salida de Vehículos")
    'End Sub

    'Private Sub cboSalida_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalida.SelectedIndexChanged
    '    If cboSalida.Items.Count = 0 Or cboSalida.SelectedIndex = -1 Then Return
    '    Dim iSalida As Integer
    '    iSalida = coll_salida(cboSalida.SelectedIndex + 1)
    '    'If bInicio = False Then
    '    'txtSalida.Text = iSalida
    '    'End If

    '    If objSimulador.Unidad(txtBus.Text.Trim, iSalida) Then
    '        LlenarComboIDs(objSimulador.cur_origen, cboOrigen, coll_origen, 0)
    '        LlenarComboIDs(objSimulador.cur_destino, cboDestino, coll_destino, 0)
    '    End If

    '    If objSimulador.BusDatos(txtBus.Text.Trim, iSalida, 1) Then
    '        If objSimulador.cur_documento.BOF = False And objSimulador.cur_documento.EOF = False Then
    '            iCapacidad = objSimulador.cur_documento.Fields(0).Value
    '            lbl1.Text = objSimulador.cur_documento.Fields(0).Value
    '            lbl2.Text = objSimulador.cur_documento.Fields(1).Value
    '            lbl3.Text = objSimulador.cur_documento.Fields(2).Value
    '            lbl4.Text = objSimulador.cur_documento.Fields(3).Value

    '            If bNuevo2 Then
    '                If IsDBNull(objSimulador.cur_documento.Fields("kilometros").Value) Then
    '                    txtKilometraje.Text = "0.00"
    '                Else
    '                    txtKilometraje.Text = FormatNumber(Convert.ToDouble(objSimulador.cur_documento.Fields("kilometros").Value), 2)
    '                End If
    '                If Val(txtSubtotalAcumulado.Text) > 0 Then
    '                    txtSpk.Text = FormatNumber(IIf(Val(txtSubtotalAcumulado.Text) = 0, 0, CDbl(txtSubtotalAcumulado.Text)) / IIf(Val(txtKilometraje.Text) = 0, 0, CDbl(txtKilometraje.Text)), 2)
    '                Else
    '                    txtSpk.Text = ""
    '                End If
    '            End If
    '            btnFiltrar.Enabled = True
    '            btnFiltrar.Focus()
    '        Else
    '            iCapacidad = 0
    '            lbl1.Text = ""
    '            lbl2.Text = ""
    '            lbl3.Text = ""
    '            lbl4.Text = ""
    '            btnFiltrar.Enabled = False
    '        End If
    '    Else
    '        iCapacidad = 0
    '        lbl1.Text = ""
    '        lbl2.Text = ""
    '        lbl3.Text = ""
    '        lbl4.Text = ""
    '        btnFiltrar.Enabled = False
    '    End If
    'End Sub

    Private Sub TxtBus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBus.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If cbobus.SelectedIndex = 0 Then Return
            Me.Cursor = Cursors.AppStarting
            If Val(txtBus.Text.Trim) > 0 Then
                'Recuperar Salidas asociadas al bus
                'If objSimulador.Salida(txtBus.Text.Trim, dtoUSUARIOS.IdLogin) Then
                'LlenarComboIDs(objSimulador.cur_salida, cboSalida, coll_salida, 0)
                'End If

                'If cboSalida.Items.Count = 0 Then
                'Me.Cursor = Cursors.Default
                'Return
                'End If
                'Dim iSalida As Integer
                'iSalida = coll_salida(cboSalida.SelectedIndex + 1)
                If objSimulador.Unidad(txtBus.Text.Trim, iSalida) Then
                    ''''
                    LlenarComboIDs_dt(objSimulador.cur_origen, cboOrigen, coll_origen, 0)
                    LlenarComboIDs_dt(objSimulador.cur_destino, cboDestino, coll_destino, 0)
                    ''''
                End If
                bInicio = False
            Else
                btnFiltrar.Enabled = False
            End If
        Else
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If (IsNumeric(e.KeyChar)) Then
                e.Handled = False
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        End If
        'If cboSalida.Items.Count = 0 Then
        'txtDocumento.Text = ""
        'GroupBox7.Enabled = False
        'Else
        'GroupBox7.Enabled = True
        'End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Function BuscarCombo(ByVal cbo As ComboBox, ByVal item As String) As Long

        For i As Integer = 0 To cbo.Items.Count - 1
            If cbo.Items(i).ToString.Substring(0, 5).Trim = item Then
                Return i
            End If
        Next
        Return -1
    End Function

    'Private Sub btnSalida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalida.Click
    '    Dim frm As New frmsalidavehiculo

    '    frm.iLlamada = 1
    '    frm.ShowDialog()
    '    If iBus > 0 Then
    '        txtBus.Text = iBus
    '    End If
    '    If Val(txtBus.Text.Trim) > 0 Then
    '        'Recuperar Salidas asociadas al bus
    '        cboSalida.Items.Clear()
    '        lbl1.Text = ""
    '        lbl2.Text = ""
    '        lbl3.Text = ""
    '        lbl4.Text = ""

    '        If objSimulador.Salida(txtBus.Text.Trim, dtoUSUARIOS.IdLogin) Then
    '            LlenarComboIDs(objSimulador.cur_salida, cboSalida, coll_salida, 0)
    '        End If

    '        If cboSalida.Items.Count = 0 Then
    '            Me.Cursor = Cursors.Default
    '            'Return
    '        Else
    '            Dim iSalida As Integer
    '            iSalida = coll_salida(cboSalida.SelectedIndex + 1)
    '            If objSimulador.Unidad(txtBus.Text.Trim, iSalida) Then
    '                LlenarComboIDs(objSimulador.cur_origen, cboOrigen, coll_origen, 0)
    '                LlenarComboIDs(objSimulador.cur_destino, cboDestino, coll_destino, 0)
    '            End If
    '            bInicio = False

    '        End If
    '    Else
    '        btnFiltrar.Enabled = False
    '    End If

    '    If cboSalida.Items.Count = 0 Then
    '        'TxtBus.Text = ""
    '        txtDocumento.Text = ""
    '        GroupBox7.Enabled = False
    '    Else
    '        GroupBox7.Enabled = True
    '    End If

    '    Me.Cursor = Cursors.Default


    '    If cboSalida.Items.Count = 0 Then Return
    '    If iBus > 0 And iSalida <> Val(cboSalida.Text.Substring(0, 5).Trim) Then
    '        txtBus.Text = iBus

    '        'Recuperar Salidas asociadas al bus
    '        If objSimulador.Salida(txtBus.Text.Trim, dtoUSUARIOS.IdLogin) Then
    '            LlenarComboIDs(objSimulador.cur_salida, cboSalida, coll_salida, 0)
    '            cboSalida.SelectedIndex = BuscarCombo(cboSalida, iSalida)
    '        End If
    '    End If
    'End Sub

    Private Sub dgvSeleccionados_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvSeleccionados.CellValidating
        Try
            Dim iDocumento As Integer = dgvSeleccionados.SelectedRows.Item(0).Index()
            iCantidad1 = dgvSeleccionados.Rows(iDocumento).Cells(19).Value
        Catch
        End Try
    End Sub

    Private Sub dgvSeleccionados_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSeleccionados.CellValidated
        Try
            If bInicio Then
                bInicio = False
                Return
            End If

            Dim iDocumento As Integer = dgvSeleccionados.SelectedRows.Item(0).Index()
            Dim iCantidad2 As Integer = dgvSeleccionados.Rows(iDocumento).Cells(5).Value
            Dim iTotal2 As Double = dgvSeleccionados.Rows(iDocumento).Cells(11).Value

            If (iCantidad1 < iCantidad2) Then Return

            Dim iSubtotal As Double = dgvSeleccionados.Rows(iDocumento).Cells(21).Value
            Dim iIgv As Double = dgvSeleccionados.Rows(iDocumento).Cells(22).Value
            Dim iTotal As Double = dgvSeleccionados.Rows(iDocumento).Cells(23).Value

            Dim iPeso As Double = dgvSeleccionados.Rows(iDocumento).Cells(28).Value
            Dim iVolumen As Double = dgvSeleccionados.Rows(iDocumento).Cells(29).Value
            Dim iTotalPeso As Double = iPeso+iVolumen

            Dim iSaldo As Integer = iCantidad1 - iCantidad2
            dgvSeleccionados.Rows(iDocumento).Cells(6).Value = iSaldo

            dgvSeleccionados.Rows(iDocumento).Cells(7).Value = FormatNumber(iPeso / iCantidad1 * iCantidad2, 2)
            dgvSeleccionados.Rows(iDocumento).Cells(8).Value = FormatNumber(iVolumen / iCantidad1 * iCantidad2, 2)
            dgvSeleccionados.Rows(iDocumento).Cells(17).Value = FormatNumber(iTotalPeso / iCantidad1 * iCantidad2, 2)

            dgvSeleccionados.Rows(iDocumento).Cells(11).Value = FormatNumber(iTotal / iCantidad1 * iCantidad2, 2)
            dgvSeleccionados.Rows(iDocumento).Cells(9).Value = FormatNumber(CDbl(dgvSeleccionados.Rows(iDocumento).Cells(11).Value) / (1 + dtoUSUARIOS.vImpuesto), 2)
            dgvSeleccionados.Rows(iDocumento).Cells(10).Value = FormatNumber(CDbl(dgvSeleccionados.Rows(iDocumento).Cells(11).Value) - CDbl(dgvSeleccionados.Rows(iDocumento).Cells(9).Value), 2)


            ActualizaTotales()
            ExcedeLimite()

        Catch

        End Try
    End Sub

    Private Sub dgvSeleccionados_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSeleccionados.CellValueChanged
        If bInicio Then Return
        Dim iDocumento As Integer = dgvSeleccionados.SelectedRows.Item(0).Index()
        Dim iCantidad2 As Integer = dgvSeleccionados.Rows(iDocumento).Cells(5).Value

        If Val(iCantidad2) <= 0 Then
            MessageBox.Show("La cantidad de bultos debe ser mayor a 0.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvSeleccionados.Rows(iDocumento).Cells(5).Value = dgvSeleccionados.Rows(iDocumento).Cells(20).Value
        End If

        If Val(iCantidad2) > iCantidad1 Then
            MessageBox.Show("La cantidad de bultos no puede exceder a la del documento.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvSeleccionados.Rows(iDocumento).Cells(5).Value = dgvSeleccionados.Rows(iDocumento).Cells(19).Value
        End If

    End Sub

    Private Function ExisteDocumento(ByVal documento As String, ByVal grd As DataGridView, Optional ByVal col As Integer = 1) As Boolean
        If grd.Rows.Count > 0 Then
            With grd
                For i As Integer = 0 To .Rows.Count - 1
                    If documento = grd.Rows(i).Cells(col).Value Then
                        Return True
                    End If
                Next
                Return False
            End With
        Else
            Return False
        End If
    End Function

    Private Sub ActualizaTotales()
        With dgvSeleccionados
            iSubtotal = 0
            iImpuesto = 0
            iTotal = 0
            iBultos = 0
            iPeso = 0
            iVolumen = 0
            For Each fila As DataGridViewRow In .Rows
                iBultos += fila.Cells(5).Value
                iPeso += fila.Cells(7).Value
                iVolumen += fila.Cells(8).Value
                iSubtotal += fila.Cells(9).Value
                iImpuesto += fila.Cells(10).Value
                iTotal += fila.Cells(11).Value
            Next
            Total()
        End With
    End Sub

    Private Sub FrmSimuladorCarga_MenuImprimir() Handles Me.MenuImprimir
        Me.Cursor = Cursors.AppStarting
        Try
            ObjReport.Dispose()
        Catch

        End Try

        ObjReport = New ClsLbTepsa.dtoFrmReport
        ObjReport.rutaRpt = PathFrmReport
        ObjReport.conectar(rptservice, rptuser, rptpass)

        Dim iDocumento As Integer = dgvLista.SelectedRows.Item(0).Index()
        Dim fecha As String = dgvLista.Rows(iDocumento).Cells(0).Value
        Dim numero As Integer = dgvLista.Rows(iDocumento).Cells(1).Value
        Dim usuario As Integer = dgvLista.Rows(iDocumento).Cells(5).Value

        'fecha = "02/05/2009"


        ObjReport.printrpt(False, "", "rptsimulacion.rpt", _
                       "fec;" & fecha, _
                       "usu;" & usuario, _
                       "num;" & numero)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboUnidadOrigen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboUnidadOrigen.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            cboUnidadDestino.Focus()
        End If
    End Sub

    Private Sub cboUnidadDestino_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboUnidadDestino.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            cboTramo.Focus()
        End If
    End Sub

    Private Sub cboUnidadDestino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUnidadDestino.SelectedIndexChanged
        Dim iKilometraje As Double = 0

        dgvDisponibles.Rows.Clear()
        bActualiza = False
        cboCliente.SelectedIndex = 0
        bActualiza = True

        lblRegistros1.Text = "0"

        iBultos2 = 0
        iPeso2 = 0
        iVolumen2 = 0
        iSubtotal2 = 0
        iImpuesto2 = 0
        iTotal2 = 0
        Total2()

        iKilometraje = 0
        dgvTramo.Rows.Clear()
        If cboTramo.Items.Count > 0 Then
            cboTramo.SelectedIndex = 0
        End If
        If cboUnidadOrigen.SelectedIndex = 0 Or cboUnidadDestino.SelectedIndex = 0 Then
            cboTramo.Enabled = False
            btnFiltrar.Enabled = False
            txtKilometraje.Text = ""
        Else
            cboTramo.Enabled = True
            btnFiltrar.Enabled = True

            bEliminar = False
            cboTramo.SelectedIndex = cboUnidadDestino.SelectedIndex
            With dgvTramo
                .Rows.Add()
                .Rows(.Rows.Count - 1).Cells(0).Value = coll_Tramo(cboTramo.SelectedIndex + 1)
                'Obtiene kilometraje origen-tramo
                iKilometraje = ObtieneKilometraje(coll_UnidadOrigen(cboUnidadOrigen.SelectedIndex + 1), coll_UnidadDestino(cboUnidadDestino.SelectedIndex + 1))
                .Rows(.Rows.Count - 1).Cells(1).Value = cboTramo.Text   'tramo
                .Rows(.Rows.Count - 1).Cells(2).Value = iKilometraje    'kilometraje origen-tramo
            End With

            btnTramo_Click(sender, e)
            bTramo = True
            cboTramo.SelectedIndex = 0
            'iKilometraje = ObtieneKilometraje(coll_UnidadOrigen(cboUnidadOrigen.SelectedIndex + 1), coll_UnidadDestino(cboUnidadDestino.SelectedIndex + 1))
            'txtKilometraje.Text = FormatNumber(iKilometraje, 2)
        End If

        txtKilometraje.Text = FormatNumber(MontoCarguero(iServicio, iKilometraje), 2)

        Total()
        ActualizaComboDestino()
    End Sub

    Private Sub cboTramo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTramo.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If btnTramo.Enabled Then
                btnTramo.Focus()
            Else
                btnFiltrar.Focus()
            End If
        End If
    End Sub

    Private Sub cboTramo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTramo.SelectedIndexChanged
        If cboTramo.SelectedIndex = 0 Then
            btnTramo.Enabled = False
        Else
            btnTramo.Enabled = True
        End If

        If bTramo Then
            Return
        Else
            bTramo = False
        End If
        If cboTramo.SelectedIndex = 0 Then
            dgvTramo.Rows.Clear()
            btnTramo.Enabled = False
        Else
            btnTramo.Enabled = True
        End If
    End Sub

    Private Sub btnSeleccionarContactos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionarContactos.Click
        bAbierto = Not bAbierto
        If bAbierto Then
            Me.dgvTramo.Size = New Size(228, 85)
        Else
            Me.dgvTramo.Size = New Size(228, 20)
        End If
    End Sub

    Private Sub tmrTiempo_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrTiempo.Tick
        tmrTiempo.Enabled = False
        bAbierto = True
        btnSeleccionarContactos_Click(sender, e)
    End Sub
    Private Function ObtieneKilometraje(ByVal origen As Integer, ByVal destino As Integer) As Double
        Dim iKilometraje As Double = 0

        'Obtiene kilometraje entre origen y destino
        If objsalidavehiculodespacho.fnKilometros(origen, destino) Then
            'datahelper
            'iKilometraje = FormatNumber(objsalidavehiculodespacho.cur_kilometros2.Fields(0).Value, 2)
            If objsalidavehiculodespacho.dt_cur_kilometros2.Rows.Count > 0 Then
                iKilometraje = FormatNumber(objsalidavehiculodespacho.dt_cur_kilometros2.Rows(0).Item(0), 2)
            Else
                iKilometraje = 0
            End If

        Else
            iKilometraje = 0
        End If

            Return iKilometraje
    End Function
    Private Function ObtieneUnidadAgencia(ByVal unidad As Integer, ByVal opcion As Integer) As Integer
        Dim i As Integer

        If opcion = 1 Then
            For i = 1 To coll_UnidadOrigen.Count - 1
                If Val(unidad) = coll_UnidadOrigen(i) Then
                    Return i - 1
                    Exit Function
                End If
            Next
            Return 0
        Else
            For i = 1 To coll_UnidadDestino.Count - 1
                If Val(unidad) = coll_UnidadDestino(i) Then
                    Return i - 1
                    Exit Function
                End If
            Next
            Return 0
        End If
    End Function

    Private Function ExisteTramo(ByVal tramo As Integer) As Boolean
        For i As Integer = 0 To dgvTramo.Rows.Count - 1
            If tramo = dgvTramo.Rows(i).Cells(0).Value Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub ActualizaTramoTmp()
        With dgvTramo
            For i As Integer = 0 To .Rows.Count - 1
                objSimulador.Opcion = i
                objSimulador.Tramo = .Rows(i).Cells(0).Value
                objSimulador.Usuario = dtoUSUARIOS.IdLogin
                objSimulador.Kilometraje = .Rows(i).Cells(2).Value

                objSimulador.ActualizaTramoTmp()
            Next
        End With
    End Sub

    Private Sub cboUnidadOrigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUnidadOrigen.SelectedIndexChanged
        Dim iKilometraje As Double = 0

        dgvTramo.Rows.Clear()
        If cboTramo.Items.Count > 0 Then
            cboTramo.SelectedIndex = 0
        End If
        If cboUnidadOrigen.SelectedIndex = 0 Or cboUnidadDestino.SelectedIndex = 0 Then
            cboTramo.Enabled = False
            txtKilometraje.Text = ""
        Else
            cboTramo.Enabled = True

            iKilometraje = ObtieneKilometraje(coll_UnidadOrigen(cboUnidadOrigen.SelectedIndex + 1), coll_UnidadDestino(cboUnidadDestino.SelectedIndex + 1))
            txtKilometraje.Text = iKilometraje

            dgvTramo.Rows.Add()
            dgvTramo.Rows(dgvTramo.Rows.Count - 1).Cells(0).Value = coll_UnidadDestino(cboUnidadDestino.SelectedIndex + 1)
            dgvTramo.Rows(dgvTramo.Rows.Count - 1).Cells(1).Value = cboUnidadDestino.Text
            dgvTramo.Rows(dgvTramo.Rows.Count - 1).Cells(2).Value = iKilometraje
        End If

        If cboUnidadOrigen.SelectedIndex = 0 Then
            cboOrigen.Items.Clear()
            cboOrigen.Items.Add("--TODOS--")
            cboOrigen.SelectedIndex = 0
            coll_origen.Clear()
        Else
            cboOrigen.Items.Clear()
            cboOrigen.Items.Add("--TODOS--")
            cboOrigen.Items.Add(cboUnidadOrigen.Text)
            coll_origen.Clear()
            coll_origen.Add(0)
            coll_origen.Add(coll_UnidadOrigen(cboUnidadOrigen.SelectedIndex + 1), 1)
            cboOrigen.SelectedIndex = 0
        End If

        txtKilometraje.Text = FormatNumber(MontoCarguero(iServicio, iKilometraje), 2)
        Total()
    End Sub

    Private Sub ActualizaComboDestino()
        Dim j As Integer = 0

        cboDestino.Items.Clear()
        cboDestino.Items.Add("--TODOS--")

        coll_destino.Clear()

        coll_destino.Add(0)
        If cboUnidadDestino.SelectedIndex > 0 Then
            cboDestino.Items.Add(cboUnidadDestino.Text)
            coll_destino.Add(coll_UnidadDestino(cboUnidadDestino.SelectedIndex + 1), 1)
            j = 1
        End If

        If dgvTramo.Rows.Count > 0 Then
            For i As Integer = 0 To dgvTramo.Rows.Count - 1
                If dgvTramo.Rows(i).Cells(0).Value <> coll_UnidadDestino(cboUnidadDestino.SelectedIndex + 1) Then
                    cboDestino.Items.Add(dgvTramo.Rows(i).Cells(1).Value)
                    j += 1
                    coll_destino.Add(dgvTramo.Rows(i).Cells(0).Value, j)
                End If
            Next
        End If

        bEntrar2 = False
        cboDestino.SelectedIndex = 0
    End Sub

    Private Sub cbobus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbobus.SelectedIndexChanged
        Dim iKilometraje As Integer = 0
        txtBus.Text = IIf(coll_unidades(cbobus.SelectedIndex + 1) = "-1", txtBus.Text, coll_unidades(cbobus.SelectedIndex + 1))
        If cbobus.SelectedIndex <> 0 Then
            txtBus.Focus()
        End If

        If cbobus.SelectedIndex = 0 Then
            txtDocumento.Text = ""
            GroupBox7.Enabled = False
            If cboUnidadOrigen.Items.Count > 0 Then
                cboUnidadOrigen.SelectedIndex = 0
            End If
            If cboUnidadDestino.Items.Count > 0 Then
                cboUnidadDestino.SelectedIndex = 0
            End If
            cboUnidadOrigen.Enabled = False
            cboUnidadDestino.Enabled = False
            lbl1.Text = ""
            lbl2.Text = ""
        Else
            GroupBox7.Enabled = True
            cboUnidadOrigen.Enabled = True
            cboUnidadDestino.Enabled = True
            chkTodo.Checked = False

            iOri = 0
            iDes = 0
            'Carga datos del bus
            If objSimulador.BusDatos2(txtBus.Text.Trim) Then
                'datahelper
                'If objSimulador.cur_documento.BOF = False And objSimulador.cur_documento.EOF = False Then
                '    lbl1.Text = FormatNumber(objSimulador.cur_documento.Fields(0).Value, 0) & " Kg."
                '    lbl2.Text = objSimulador.cur_documento.Fields(1).Value
                '    iCapacidad = objSimulador.cur_documento.Fields(0).Value
                '    lbl3.Text = objSimulador.cur_documento.Fields(2).Value
                '    iServicio = objSimulador.cur_documento.Fields(2).Value
                If objSimulador.cur_documento.Rows.Count > 0 Then
                    lbl1.Text = FormatNumber(objSimulador.cur_documento.Rows(0).Item(0), 0) & " Kg."
                    lbl2.Text = objSimulador.cur_documento.Rows(0).Item(1)
                    iCapacidad = objSimulador.cur_documento.Rows(0).Item(0)
                    lbl3.Text = objSimulador.cur_documento.Rows(0).Item(2)
                    iServicio = objSimulador.cur_documento.Rows(0).Item(2)


                    If objSimulador.Salida22(txtBus.Text.Trim) Then
                        'datahelper
                        'iOri = objSimulador.cur_salida1.Fields(0).Value
                        'iDes = objSimulador.cur_salida1.Fields(1).Value
                        'sOri = objSimulador.cur_salida1.Fields(2).Value
                        'sDes = objSimulador.cur_salida1.Fields(3).Value
                        iOri = objSimulador.cur_salida1.Rows(0).Item(0)
                        iDes = objSimulador.cur_salida1.Rows(0).Item(1)
                        sOri = objSimulador.cur_salida1.Rows(0).Item(2)
                        sDes = objSimulador.cur_salida1.Rows(0).Item(3)

                        Dim iPos As Integer
                        iPos = cboUnidadOrigen.FindStringExact(sOri)
                        cboUnidadOrigen.SelectedIndex = iPos

                        iPos = cboUnidadDestino.FindStringExact(sDes)
                        cboUnidadDestino.SelectedIndex = iPos

                        'Cargar Tramos
                        dgvTramo.Rows.Clear()
                        iKilometraje = 0

                        'datahelper
                        'If objSimulador.cur_salida2.BOF = False And objSimulador.cur_salida2.EOF = False Then
                        If objSimulador.cur_salida2.Rows.Count > 0 Then
                            Dim iUltimoTramo As Integer
                            cboDestino.Items.Clear()
                            cboDestino.Items.Add("--TODOS--")
                            '
                            coll_destino.Clear()
                            coll_destino.Add(0)
                            '
                            For Each row As DataRow In objSimulador.cur_salida2.Rows
                                With dgvTramo
                                    .Rows.Add()
                                    'datahelper
                                    '.Rows(.Rows.Count - 1).Cells(0).Value = objSimulador.cur_salida2.Fields(0).Value
                                    '.Rows(.Rows.Count - 1).Cells(1).Value = objSimulador.cur_salida2.Fields(1).Value
                                    '.Rows(.Rows.Count - 1).Cells(2).Value = ObtieneKilometraje(coll_UnidadOrigen(cboUnidadOrigen.SelectedIndex + 1), objSimulador.cur_salida2.Fields(0).Value)
                                    'iUltimoTramo = objSimulador.cur_salida2.Fields(0).Value
                                    'iKilometraje += .Rows(.Rows.Count - 1).Cells(2).Value

                                    'If objSimulador.cur_salida2.Fields(0).Value <> coll_UnidadDestino(cboUnidadDestino.SelectedIndex - 1) Then
                                    '    cboDestino.Items.Add(objSimulador.cur_salida2.Fields(1).Value())
                                    '    coll_destino.Add(objSimulador.cur_salida2.Fields(0).Value)
                                    'End If
                                    .Rows(.Rows.Count - 1).Cells(0).Value = row.Item(0)
                                    .Rows(.Rows.Count - 1).Cells(1).Value = row.Item(1)
                                    .Rows(.Rows.Count - 1).Cells(2).Value = ObtieneKilometraje(coll_UnidadOrigen(cboUnidadOrigen.SelectedIndex + 1), row.Item(0))
                                    iUltimoTramo = row.Item(0)
                                    iKilometraje += .Rows(.Rows.Count - 1).Cells(2).Value

                                    If row.Item(0) <> coll_UnidadDestino(cboUnidadDestino.SelectedIndex - 1) Then
                                        cboDestino.Items.Add(row.Item(1))
                                        coll_destino.Add(row.Item(0))
                                    End If

                                End With
                                'Loop
                            Next

                            'datahelper
                            'Do While objSimulador.cur_salida2.BOF = False And objSimulador.cur_salida2.EOF = False
                            '    With dgvTramo
                            '        .Rows.Add()
                            '        .Rows(.Rows.Count - 1).Cells(0).Value = objSimulador.cur_salida2.Fields(0).Value
                            '        .Rows(.Rows.Count - 1).Cells(1).Value = objSimulador.cur_salida2.Fields(1).Value
                            '        .Rows(.Rows.Count - 1).Cells(2).Value = ObtieneKilometraje(coll_UnidadOrigen(cboUnidadOrigen.SelectedIndex + 1), objSimulador.cur_salida2.Fields(0).Value)
                            '        iUltimoTramo = objSimulador.cur_salida2.Fields(0).Value
                            '        iKilometraje += .Rows(.Rows.Count - 1).Cells(2).Value

                            '        If objSimulador.cur_salida2.Fields(0).Value <> coll_UnidadDestino(cboUnidadDestino.SelectedIndex - 1) Then
                            '            cboDestino.Items.Add(objSimulador.cur_salida2.Fields(1).Value())
                            '            coll_destino.Add(objSimulador.cur_salida2.Fields(0).Value)
                            '        End If
                            '    End With
                            '    objSimulador.cur_salida2.MoveNext()
                            'Loop
                            iKilometraje += ObtieneKilometraje(dgvTramo.Rows(dgvTramo.Rows.Count - 1).Cells(0).Value, coll_UnidadDestino(cboUnidadDestino.SelectedIndex + 1))
                            'actualiza destino en tramos para unidades programadas
                            With dgvTramo
                                .Rows.Add()
                                .Rows(.Rows.Count - 1).Cells(0).Value = coll_UnidadDestino(cboUnidadDestino.SelectedIndex + 1)
                                .Rows(.Rows.Count - 1).Cells(1).Value = cboUnidadDestino.Text
                                .Rows(.Rows.Count - 1).Cells(2).Value = ObtieneKilometraje(iUltimoTramo, coll_UnidadDestino(cboUnidadDestino.SelectedIndex + 1))
                            End With

                            'actualiza combo destino de filtro con unidad destino
                            cboDestino.Items.Add(cboUnidadDestino.Text)
                            coll_destino.Add(coll_UnidadDestino(cboUnidadDestino.SelectedIndex + 1))
                            cboDestino.SelectedIndex = 0
                        Else
                            iKilometraje += ObtieneKilometraje(coll_UnidadOrigen(cboUnidadOrigen.SelectedIndex + 1), coll_UnidadDestino(cboUnidadDestino.SelectedIndex + 1))
                        End If
                    Else
                        If iOri > 0 Or iDes > 0 Then
                            iKilometraje += ObtieneKilometraje(coll_UnidadOrigen(cboUnidadOrigen.SelectedIndex + 1), coll_UnidadDestino(cboUnidadDestino.SelectedIndex + 1))
                        Else
                            cboUnidadOrigen.SelectedIndex = 0
                            cboUnidadDestino.SelectedIndex = 0
                        End If
                    End If
                Else
                    lbl1.Text = ""
                    lbl2.Text = ""
                    iCapacidad = 0
                    lbl3.Text = ""
                End If
            Else
                lbl1.Text = ""
                lbl2.Text = ""
            End If
            If iServicio = 4 Or iServicio = 5 Or iServicio = 6 Then
                cboUnidadOrigen.Enabled = False
                cboUnidadDestino.Enabled = False
            Else
                cboUnidadOrigen.Enabled = True
                cboUnidadDestino.Enabled = True
            End If
        End If

        txtKilometraje.Text = FormatNumber(MontoCarguero(iServicio, iKilometraje), 2)
        Total()
    End Sub


    Private Sub btnTramo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTramo.Click
        Dim iKilometraje As Double
        Dim iKilometraje2 As Double

        If Not bEliminar Then
            tmrTiempo.Enabled = False
            tmrTiempo.Enabled = True
            bAbierto = False
            btnSeleccionarContactos_Click(sender, e)
        End If

        With dgvTramo
            If Not bEliminar Then
                'Restricciones
                If .Rows.Count > 0 Then
                    If ExisteTramo(coll_Tramo(cboTramo.SelectedIndex + 1)) Then Return
                End If
                If cboTramo.Text = cboUnidadDestino.Text Then Return

                'Proceso
                Dim sCad As String
                .Rows.Add()
                sCad = coll_Tramo(cboTramo.SelectedIndex + 1)   'id tramo
                .Rows(.Rows.Count - 1).Cells(0).Value = sCad
                'Obtiene kilometraje origen-tramo
                iKilometraje = ObtieneKilometraje(coll_UnidadOrigen(cboUnidadOrigen.SelectedIndex + 1), sCad)
                .Rows(.Rows.Count - 1).Cells(1).Value = cboTramo.Text   'tramo
                .Rows(.Rows.Count - 1).Cells(2).Value = iKilometraje    'kilometraje origen-tramo
            Else
                bEliminar = False
            End If

            ReDim mTramo(0)
            ReDim mTramo(.Rows.Count)
            Dim j As Integer = 0
            For i As Integer = 0 To .Rows.Count - 1
                j += 1
                mTramo(j).codigo = .Rows(i).Cells(0).Value
                mTramo(j).nombre = .Rows(i).Cells(1).Value
                mTramo(j).kilometros = ObtieneKilometraje(coll_UnidadOrigen(cboUnidadOrigen.SelectedIndex + 1), .Rows(i).Cells(0).Value)
                'mTramo(j).kilometros = ObtieneKilometraje(coll_UnidadOrigen(cboUnidadOrigen.SelectedIndex + 1), mTramo(j).codigo)
                'If mTramo(j).codigo = coll_UnidadDestino(cboUnidadDestino.SelectedIndex + 1) Then
                'mTramo(j).kilometros = ObtieneKilometraje(coll_UnidadOrigen(cboUnidadOrigen.SelectedIndex + 1), coll_UnidadDestino(cboUnidadDestino.SelectedIndex + 1))
                'End If
            Next

            Dim m As Array = Ordenar(mTramo)
            .Rows.Clear()
            Dim iTramos As Double = 0
            For i As Integer = 1 To m.Length - 1
                .Rows.Add()
                .Rows(.Rows.Count - 1).Cells(0).Value = mTramo(i).codigo
                .Rows(.Rows.Count - 1).Cells(1).Value = mTramo(i).nombre
                .Rows(.Rows.Count - 1).Cells(2).Value = mTramo(i).kilometros
            Next

            'actualiza kilometraje real
            Dim iOrigen, iDestino As Integer
            iOrigen = coll_UnidadOrigen(cboUnidadOrigen.SelectedIndex + 1)
            iKilometraje = 0
            For i As Integer = 0 To .Rows.Count - 1
                iDestino = .Rows(i).Cells(0).Value
                If iOrigen <> iDestino Then
                    'Obtiene kilometraje origen-tramo
                    iKilometraje2 = ObtieneKilometraje(iOrigen, iDestino)
                    .Rows(i).Cells(2).Value = iKilometraje2    'kilometraje tramo1-tramo2
                    iKilometraje += iKilometraje2
                End If
                iOrigen = iDestino
                If i = .Rows.Count - 1 Then
                    iDestino = coll_UnidadDestino(cboUnidadDestino.SelectedIndex + 1)
                    iKilometraje += ObtieneKilometraje(iOrigen, iDestino)
                End If
            Next

            iKilometraje = ObtieneKilometraje(coll_UnidadOrigen(cboUnidadOrigen.SelectedIndex + 1), coll_UnidadDestino(cboUnidadDestino.SelectedIndex + 1))

            txtKilometraje.Text = FormatNumber(MontoCarguero(iServicio, iKilometraje), 2)
            Total()
            ActualizaComboDestino()
        End With
    End Sub

    Private Sub dgvTramo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTramo.KeyDown
        'If iServicio = 4 Or iServicio = 5 Or iServicio = 6 Then Return
        If dgvTramo.Rows.Count > 0 Then
            If e.KeyCode = Keys.Delete Then
                Dim iDocumento As Integer = dgvTramo.SelectedRows.Item(0).Index()

                If dgvTramo.Rows(iDocumento).Cells(0).Value = coll_UnidadDestino(cboUnidadDestino.SelectedIndex + 1) Then Return
                dgvTramo.Rows.RemoveAt(iDocumento)
                bEliminar = True
                btnTramo_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Grabar()
        Dim iAño As Integer
        Dim iMes As Integer
        Dim dFecha As String
        Dim iUsuario As Integer
        Dim sBus As String
        Dim iNumero As Integer
        Dim iSerie As Integer
        Dim iGuia As Integer
        Dim iSalida As Integer

        Dim iItem As Integer
        Dim iTipo As Integer
        Dim sComprobante As String

        Dim bGrabo As Boolean = False

        Me.Cursor = Cursors.AppStarting

        If iControl = 100 Then
            Dim iDocumento As Integer = dgvLista.SelectedRows.Item(0).Index()
            dFecha = dgvLista.Rows(iDocumento).Cells(0).Value
        Else
            dFecha = dtoUSUARIOS.m_sFecha
        End If

        iUsuario = dtoUSUARIOS.IdLogin
        iNumero = 0
        sBus = txtBus.Text.Trim

        With dgvSeleccionados
            iItem = 0
            objSimulador.Fecha = dFecha
            objSimulador.Bus = sBus

            If iControl = 100 Then
                objSimulador.Numero = dNumero
            Else
                objSimulador.Numero = iNumero
            End If
            objSimulador.Kilometraje = IIf(IsNumeric(txtKilometraje.Text), txtKilometraje.Text, 0)
            objSimulador.Spk = IIf(IsNumeric(txtSpk.Text), txtSpk.Text, 0)
            For i As Integer = 0 To .Rows.Count - 1
                iItem += 1
                iTipo = .Rows(i).Cells(15).Value
                sComprobante = .Rows(i).Cells(16).Value
                If iControl = 1 Then
                    objSimulador.Control = iItem
                Else
                    objSimulador.Control = iControl
                End If
                objSimulador.Item = iItem
                objSimulador.TipoComprobante = iTipo
                objSimulador.IdComprobante = sComprobante
                objSimulador.Usuario = iUsuario

                objSimulador.Salida2 = iSalida

                objSimulador.Cantidad = .Rows(i).Cells(5).Value
                objSimulador.Saldo = .Rows(i).Cells(6).Value

                objSimulador.Subtotal = FormatNumber(.Rows(i).Cells(9).Value, 2)
                objSimulador.Impuesto = FormatNumber(.Rows(i).Cells(10).Value, 2)
                objSimulador.Total = FormatNumber(.Rows(i).Cells(11).Value, 2)

                objSimulador.Origen = coll_UnidadOrigen(cboUnidadOrigen.SelectedIndex + 1)
                objSimulador.Destino = coll_UnidadOrigen(cboUnidadDestino.SelectedIndex + 1)

                objSimulador.Peso = FormatNumber(.Rows(i).Cells(7).Value, 2)
                objSimulador.Volumen = FormatNumber(.Rows(i).Cells(8).Value, 2)

                If objSimulador.Grabar2 Then
                    bGrabo = True
                    'With objSimulador
                    '    If .ListarUsuarios Then
                    '        ModuUtil.LlenarComboIDs(.cur_usuarios, cboUsuario, coll_usuarios, 0)
                    '    End If
                    'End With
                Else
                    bGrabo = False
                End If
            Next
            If bGrabo Then  'actualizar salida
                With objSimulador
                    If .ListarUsuarios Then
                        'datahelper
                        'ModuUtil.LlenarComboIDs(.cur_usuarios, cboUsuario, coll_usuarios, 0)
                        ModuUtil.LlenarCombo2(.cur_usuarios, cboUsuario, coll_usuarios, 0)
                    End If
                End With

                'datahelper
                'Dim iNum As Integer = objSimulador.cur_numero.Fields(0).Value
                Dim iNum As Integer = objSimulador.cur_numero.Rows(0).Item(0)
                With dgvTramo
                    If .Rows.Count > 0 Then
                        For i As Integer = 0 To .Rows.Count - 1
                            With objSimulador
                                .Opcion = i
                                .Fecha = dFecha
                                .Usuario = dtoUSUARIOS.IdLogin
                                .Numero = iNum
                                .Tramo = dgvTramo.Rows(i).Cells(0).Value
                                .Kilometraje = dgvTramo.Rows(i).Cells(2).Value
                                .ActualizaTramo()
                            End With
                        Next i
                    End If
                End With
            End If
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("El registro ha sido actualizado.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TabMante.SelectTab(0)

                    For i As Integer = 0 To coll_usuarios.Count - 1
                        If dtoUSUARIOS.IdLogin = coll_usuarios(i + 1) Then
                            cboUsuario.SelectedIndex = i
                        End If
                    Next
                    Listar()
                End With
    End Sub

    Private Function ObtieneParcial(ByVal id As Integer) As String
        Select Case id
            Case 0
                Return " "
            Case 1
                Return "REAL"
            Case 2
                Return "SIMULADO"
            Case 3
                Return "REAL/SIMULADO"
            Case Else
                Return " "
        End Select
    End Function

    Private Sub chkTodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodo.CheckedChanged
        dgvDisponibles.Rows.Clear()
        bActualiza = False
        cboCliente.SelectedIndex = 0
        bActualiza = True

        lblRegistros1.Text = "0"

        coll_origen.Clear()
        coll_destino.Clear()
        cboOrigen.Items.Clear()
        cboDestino.Items.Clear()

        iBultos2 = 0
        iPeso2 = 0
        iVolumen2 = 0
        iSubtotal2 = 0
        iImpuesto2 = 0
        iTotal2 = 0
        Total2()

        cboOrigen.Items.Add("--TODOS--")
        cboDestino.Items.Add("--TODOS--")
        coll_origen.Add(0)
        coll_destino.Add(0)

        cboOrigen.SelectedIndex = 0
        cboDestino.SelectedIndex = 0
        If chkTodo.Checked Then
            With objSimulador
                If .Ciudad Then
                    'datahelper
                    'ModuUtil.LlenarComboIDs(.cur_origen2, cboOrigen, coll_origen, 0)
                    'ModuUtil.LlenarComboIDs(.cur_destino2, cboDestino, coll_destino, 0)
                    ModuUtil.LlenarCombo2(.cur_origen2, cboOrigen, coll_origen, 0)
                    ModuUtil.LlenarCombo2(.cur_destino2, cboDestino, coll_destino, 0)
                End If
            End With
            'coll_origen2 = coll_origen
            'coll_destino2 = coll_destino
        Else
            If cbobus.SelectedIndex = 0 Then Return
            ActualizaComboOrigenDestino()
            'cboUnidadDestino_SelectedIndexChanged(sender, e)

            'Dim sBus As String = txtBus.Text.Trim
            'If objSimulador.Unidad(sBus, 1) Then
            'LlenarComboIDs(objSimulador.cur_origen, cboOrigen, coll_origen, 0)
            'LlenarComboIDs(objSimulador.cur_destino, cboDestino, coll_destino, 0)
            'End If
        End If
    End Sub

    Private Sub ActualizaComboOrigenDestino()
        'Actualiza Origen
        cboOrigen.Items.Add(cboUnidadOrigen.Text)
        coll_origen.Add(coll_UnidadOrigen(cboUnidadOrigen.SelectedIndex + 1))
        cboOrigen.SelectedIndex = 0

        'Actualiza Destino
        If dgvTramo.Rows.Count > 0 Then
            For i As Integer = 0 To dgvTramo.Rows.Count - 1
                cboDestino.Items.Add(dgvTramo.Rows(i).Cells(1).Value)
                coll_destino.Add(dgvTramo.Rows(i).Cells(0).Value)
            Next
        End If
        cboDestino.SelectedIndex = 0
    End Sub

    Private Sub dgvTramo_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTramo.CellContentClick

    End Sub

    Private Sub dgvSeleccionados_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvSeleccionados.KeyPress

    End Sub

    Private Sub dgvSeleccionados_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSeleccionados.Validated

    End Sub

    Private Sub dgvSeleccionados_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvSeleccionados.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf Validar
    End Sub

    Private Sub Validar(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Validar Fila seleccionada 
        Dim drwFila As DataGridViewCell = dgvSeleccionados.CurrentCell()
        If drwFila.ColumnIndex > 3 Then
            'Si son digitos o si es la tecla borrar
            If Char.IsDigit(e.KeyChar) Or (Asc(e.KeyChar) = 8) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Function Ordenar(ByVal m As Array) As Array
        'metodo la gripe porcina de qqin 
        Dim i, j As Integer
        Dim a As Integer
        Dim b As String
        Dim c As Double
        Dim longitud = m.Length - 1
        For i = 1 To longitud
            For j = 1 To longitud - 1
                If mTramo(j).kilometros > mTramo(j + 1).kilometros Then
                    a = mTramo(j).codigo
                    b = mTramo(j).nombre
                    c = mTramo(j).kilometros
                    mTramo(j).codigo = mTramo(j + 1).codigo
                    mTramo(j).nombre = mTramo(j + 1).nombre
                    mTramo(j).kilometros = mTramo(j + 1).kilometros
                    mTramo(j + 1).codigo = a
                    mTramo(j + 1).nombre = b
                    mTramo(j + 1).kilometros = c
                End If
            Next
        Next i
        Return mTramo
    End Function

    Private Function MontoCarguero(ByVal servicio As Integer, ByVal monto As Double) As Double
        If ExisteCero() Then
            Dim iKilometraje As Double
            iKilometraje = ObtieneKilometraje(coll_UnidadOrigen(cboUnidadOrigen.SelectedIndex + 1), coll_UnidadDestino(cboUnidadDestino.SelectedIndex + 1))
            If servicio = 2 Then   'Carguero
                Return iKilometraje * 2
            Else
                Return iKilometraje
            End If
        Else
            If servicio = 2 Then   'Carguero
                Return monto * 2
            Else
                Return monto
            End If
        End If
    End Function

    Private Function ExisteCero() As Boolean
        With dgvTramo
            For i As Integer = 0 To .Rows.Count - 1
                If Val(.Rows(i).Cells(2).Value) = 0 Then
                    Return True
                End If
            Next
        End With
        Return False
    End Function

    Private Function FiltrarDataTable(ByVal dt As DataTable, ByVal filter As String, ByVal sort As String) As DataTable
        Try
            Dim rows As DataRow()
            Dim dtNew As DataTable

            dtNew = dt.Clone()
            rows = dt.Select(filter, sort)

            For Each dr As DataRow In rows
                dtNew.ImportRow(dr)
            Next
            Return dtNew

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Sub CargarSeleccionados2009()
        'Dim i As Integer = 0
        'dgvSeleccionados.Rows.Clear()
        'If cur_lista.BOF = False And cur_lista.EOF = False Then
        '    Do While cur_lista.BOF = False And cur_lista.EOF = False
        '        With dgvSeleccionados
        '            .Rows.Add()
        '            'CDate(cur_lista.Fields(2).Value).Date.ToShortDateString
        '            .Rows(i).Cells(0).Value = cur_lista.Fields(0).Value
        '            .Rows(i).Cells(1).Value = cur_lista.Fields(1).Value
        '            .Rows(i).Cells(2).Value = CDate(cur_lista.Fields(2).Value).Date.ToShortDateString
        '            .Rows(i).Cells(3).Value = cur_lista.Fields(3).Value
        '            .Rows(i).Cells(4).Value = cur_lista.Fields(4).Value
        '            .Rows(i).Cells(5).Value = cur_lista.Fields(5).Value
        '            .Rows(i).Cells(6).Value = 0 'cur_lista.Fields(6).Value
        '            .Rows(i).Cells(7).Value = FormatNumber(cur_lista.Fields(7).Value, 2)
        '            .Rows(i).Cells(8).Value = FormatNumber(cur_lista.Fields(8).Value, 2)
        '            .Rows(i).Cells(9).Value = FormatNumber(cur_lista.Fields(9).Value, 2)
        '            .Rows(i).Cells(10).Value = FormatNumber(cur_lista.Fields(10).Value, 2)
        '            .Rows(i).Cells(11).Value = FormatNumber(cur_lista.Fields(11).Value, 2)
        '            .Rows(i).Cells(12).Value = cur_lista.Fields(12).Value
        '            .Rows(i).Cells(14).Value = cur_lista.Fields(13).Value
        '            .Rows(i).Cells(15).Value = cur_lista.Fields(14).Value
        '            .Rows(i).Cells(16).Value = cur_lista.Fields(15).Value
        '            .Rows(i).Cells(17).Value = cur_lista.Fields(23).Value
        '            .Rows(i).Cells(18).Value = cur_lista.Fields(24).Value
        '            .Rows(i).Cells(19).Value = cur_lista.Fields(26).Value
        '            .Rows(i).Cells(20).Value = cur_lista.Fields(27).Value
        '            .Rows(i).Cells(21).Value = cur_lista.Fields(28).Value
        '            .Rows(i).Cells(22).Value = cur_lista.Fields(29).Value
        '            .Rows(i).Cells(23).Value = cur_lista.Fields(30).Value
        '            .Rows(i).Cells(24).Value = cur_lista.Fields(33).Value
        '            .Rows(i).Cells(25).Value = ObtieneParcial(Val(cur_lista.Fields(33).Value))
        '            .Rows(i).Cells(26).Value = cur_lista.Fields(34).Value
        '            .Rows(i).Cells(27).Value = cur_lista.Fields(35).Value

        '            .Rows(i).Cells(28).Value = cur_lista.Fields(36).Value
        '            .Rows(i).Cells(29).Value = cur_lista.Fields(37).Value

        '            .Rows(i).Cells(30).Value = cur_lista.Fields(38).Value
        '            .Rows(i).Cells(31).Value = cur_lista.Fields(39).Value
        '            .Rows(i).Cells(32).Value = cur_lista.Fields(40).Value

        '            iBultos += .Rows(i).Cells(5).Value
        '            iPeso += .Rows(i).Cells(7).Value
        '            iVolumen += .Rows(i).Cells(8).Value
        '            iSubtotal += .Rows(i).Cells(9).Value
        '            iImpuesto += .Rows(i).Cells(10).Value
        '            iTotal += .Rows(i).Cells(11).Value

        '            i += 1
        '        End With
        '        cur_lista.MoveNext()
        '    Loop
        '    'cur_lista.MoveFirst()
        '    lblRegistros1.Text = Registros(dgvDisponibles)
        '    lblRegistros2.Text = Registros(dgvSeleccionados)
        '    'bInicio=False
        'End If
    End Sub

    Private Sub CargarSeleccionados()
        Dim i As Integer = 0
        dgvSeleccionados.Rows.Clear()
        If cur_lista.Rows.Count > 0 Then
            For Each obj As DataRow In cur_lista.Rows
                With dgvSeleccionados
                    .Rows.Add()
                    'CDate(cur_lista.Fields(2).Value).Date.ToShortDateString
                    .Rows(i).Cells(0).Value = obj.Item(0)
                    .Rows(i).Cells(1).Value = obj.Item(1)
                    .Rows(i).Cells(2).Value = CDate(obj.Item(2)).Date.ToShortDateString
                    .Rows(i).Cells(3).Value = obj.Item(3)
                    .Rows(i).Cells(4).Value = obj.Item(4)
                    .Rows(i).Cells(5).Value = obj.Item(5)
                    .Rows(i).Cells(6).Value = 0 'cur_lista.Fields(6).Value
                    .Rows(i).Cells(7).Value = FormatNumber(obj.Item(7), 2)
                    .Rows(i).Cells(8).Value = FormatNumber(obj.Item(8), 2)
                    .Rows(i).Cells(9).Value = FormatNumber(obj.Item(9), 2)
                    .Rows(i).Cells(10).Value = FormatNumber(obj.Item(10), 2)
                    .Rows(i).Cells(11).Value = FormatNumber(obj.Item(11), 2)
                    .Rows(i).Cells(12).Value = obj.Item(12)
                    .Rows(i).Cells(14).Value = obj.Item(13)
                    .Rows(i).Cells(15).Value = obj.Item(14)
                    .Rows(i).Cells(16).Value = obj.Item(15)
                    .Rows(i).Cells(17).Value = obj.Item(23)
                    .Rows(i).Cells(18).Value = obj.Item(24)
                    .Rows(i).Cells(19).Value = obj.Item(26)
                    .Rows(i).Cells(20).Value = obj.Item(27)
                    .Rows(i).Cells(21).Value = obj.Item(28)
                    .Rows(i).Cells(22).Value = obj.Item(29)
                    .Rows(i).Cells(23).Value = obj.Item(30)
                    .Rows(i).Cells(24).Value = obj.Item(33)
                    .Rows(i).Cells(25).Value = ObtieneParcial(Val(obj.Item(33)))
                    .Rows(i).Cells(26).Value = obj.Item(34)
                    .Rows(i).Cells(27).Value = obj.Item(35)

                    .Rows(i).Cells(28).Value = obj.Item(36)
                    .Rows(i).Cells(29).Value = obj.Item(37)

                    .Rows(i).Cells(30).Value = obj.Item(38)
                    .Rows(i).Cells(31).Value = obj.Item(39)
                    .Rows(i).Cells(32).Value = obj.Item(40)

                    iBultos += .Rows(i).Cells(5).Value
                    iPeso += .Rows(i).Cells(7).Value
                    iVolumen += .Rows(i).Cells(8).Value
                    iSubtotal += .Rows(i).Cells(9).Value
                    iImpuesto += .Rows(i).Cells(10).Value
                    iTotal += .Rows(i).Cells(11).Value

                    i += 1
                End With
            Next
            'cur_lista.MoveFirst()
            lblRegistros1.Text = Registros(dgvDisponibles)
            lblRegistros2.Text = Registros(dgvSeleccionados)
            'bInicio=False
        End If
    End Sub

    'Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, ExportarToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged, AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
    '    If bIngreso Then
    '        Acceso.VerificaCambio(sender, e)
    '    End If
    'End Sub

    Private Sub TabDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabDatos.Click

    End Sub
End Class