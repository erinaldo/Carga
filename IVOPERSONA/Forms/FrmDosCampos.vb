'Imports System.Data.OracleClient
'Imports System.Data.OleDb
'Imports System.Drawing
Public Class FrmDosCampos
    '
    Dim obj_dto_ubigeo As New ClsLbTepsa.Dto_Ubigeo
    '
    Public dtPaisFinal As New DataTable
    Public dtDepartamentoFinal As New DataTable
    Public dtProvinciaFinal As New DataTable
    Public dtDistritoFinal As New DataTable
    Public PaisSeleccionado As Integer
    Public DepartamentoSeleccionado As Integer
    Public ProvinciaSeleccionado As Integer
    Public DistritoSeleccionado As Integer

    'Dim dr3 As New OracleDataAdapter
    Public rst As DataTable
    Public rs As DataTable
    'Dim dr4 As New OleDbDataAdapter
    Dim dtCampo1 As New System.Data.DataTable
    Dim dtCampo2 As New System.Data.DataTable
    Dim dtCampo3 As New System.Data.DataTable
    Dim dtCampo4 As New System.Data.DataTable

    Dim dvCampo1 As DataView
    Dim dvCampo2 As DataView
    Dim dvCampo3 As DataView
    Dim dvCampo4 As DataView

    Dim dtPaisG As New System.Data.DataTable
    Dim dtDepartamentoG As New System.Data.DataTable
    Dim dtProvinciaG As New System.Data.DataTable
    Dim dtDistritoG As New System.Data.DataTable

    Dim dvPaisG As DataView
    Dim dvDepartamentoG As DataView
    Dim dvProvinciaG As DataView
    Dim dvDistritoG As DataView

    Dim Fact As Integer
    Private _Nombre As String
    Private _SPLista As String
    Private _SPGraba As String
    Private _campo1 As String
    Private _campo2 As String
    Private _campo3 As String
    Private _campo4 As String
    Private _NombreCampo1 As String
    Private _NombreCampo2 As String
    Private _NombreCampo3 As String
    Private _NombreCampo4 As String
    Private _NombreCampo5 As String
    Private _NombreCampo6 As String
    Private _NombreCampo7 As String
    Private _NombreCampo8 As String

    Private _DataGeneral() As String
    'Private rstCampo1 As ADODB.Recordset
    'Private rstCampo2 As ADODB.Recordset
    'Private rstCampo3 As ADODB.Recordset
    'Private rstCampo4 As ADODB.Recordset

    Private rstcampo1 As DataTable

    'Para los Combos:
    Dim dtPaisDepartamento As New DataTable
    Dim dtPaisProvincia As New DataTable
    Dim dtPaisDistrito As New DataTable
    Dim dtDepartamentoProvincia As New DataTable
    Dim dtDepartamentoDistrito As New DataTable
    Dim dtProvincia As New DataTable

    Dim dvPaisDepartamento As New DataView
    Dim dvPaisProvincia As New DataView
    Dim dvPaisDistrito As New DataView
    Dim dvDepartamentoProvincia As New DataView
    Dim dvDepartamentoDistrito As New DataView
    Dim dvProvincia As New DataView
    '
    Private InsertA As Integer
    'Public Sub New(ByVal Nombre As String, ByVal SPLista As String, ByVal SPGraba As String, ByVal Campo1 As String, ByVal Campo2 As String, ByVal NombreCampo1 As String, ByVal NombreCampo2 As String, Optional ByVal Campo3 As String = "", Optional ByVal Campo4 As String = "", Optional ByVal NombreCampo3 As String = "", Optional ByVal NombreCampo4 As String = "")

    Dim bIngreso As Boolean = False
    Public hnd As Long
    Public Sub New(ByVal ParamArray DataGeneral() As String)
        MyBase.new()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        _DataGeneral = DataGeneral
        _Nombre = DataGeneral(0)
        _SPLista = DataGeneral(1)
        _SPGraba = DataGeneral(2)
        _campo1 = DataGeneral(3)
        _campo2 = DataGeneral(4)
        _campo3 = DataGeneral(5)
        _campo4 = DataGeneral(6)
        _NombreCampo1 = DataGeneral(17)
        _NombreCampo2 = DataGeneral(18)
        _NombreCampo3 = DataGeneral(19)
        _NombreCampo4 = DataGeneral(20)
        _NombreCampo5 = DataGeneral(21)
        _NombreCampo6 = DataGeneral(22)
        _NombreCampo7 = DataGeneral(23)
        _NombreCampo8 = DataGeneral(24)

        InsertA = CType(DataGeneral(UBound(_DataGeneral) - 4), Integer)
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub CargaDatos()
        'datahelper
        'Dim ObjUnd As Object() = {_SPLista, 0}
        'rstCampo1 = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd)
        'rstCampo2 = rstCampo1.NextRecordset
        'rstCampo3 = rstCampo1.NextRecordset
        'rstCampo4 = rstCampo1.NextRecordset
        '
        'dtCampo1.Clear()
        'dtCampo2.Clear()
        'dtCampo3.Clear()
        'dtCampo4.Clear()

        'dr4.Fill(dtCampo1, rstCampo1)
        'dr4.Fill(dtCampo2, rstCampo2)
        'dr4.Fill(dtCampo3, rstCampo3)
        'dr4.Fill(dtCampo4, rstCampo4)
        '
        Dim ds As New DataSet
        '
        ds = obj_dto_ubigeo.cargar_datos(_SPLista)
        '
        dtCampo1 = ds.Tables(0)
        dtCampo2 = ds.Tables(1)
        dtCampo3 = ds.Tables(2)
        dtCampo4 = ds.Tables(3)
        '
        dvCampo1 = dtCampo1.DefaultView
        dvCampo2 = dtCampo2.DefaultView
        dvCampo3 = dtCampo3.DefaultView
        dvCampo4 = dtCampo4.DefaultView

        'Para los Combos:
        dtPaisDepartamento = dtCampo1.Copy
        dtPaisProvincia = dtCampo1.Copy
        dtPaisDistrito = dtCampo1.Copy
        dtDepartamentoProvincia = dtCampo2.Copy
        dtDepartamentoDistrito = dtCampo2.Copy
        dtProvincia = dtCampo3.Copy

        dvPaisDepartamento = dtPaisDepartamento.DefaultView
        dvPaisProvincia = dtPaisProvincia.DefaultView
        dvPaisDistrito = dtPaisDistrito.DefaultView
        dvDepartamentoProvincia = dtDepartamentoProvincia.DefaultView
        dvDepartamentoDistrito = dtDepartamentoDistrito.DefaultView
        dvProvincia = dtProvincia.DefaultView
    End Sub

    Private Sub FrmDosCampos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub
    Private Sub FrmDosCampos_ClickTabPage1() Handles Me.ClickTabPage1
        'Me.SelectMenu(0)
    End Sub
    Private Sub FrmDosCampos_ClickTabPage2() Handles Me.ClickTabPage2
        Me.SelectMenu(1)
        Me.txtCampoUno.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
    End Sub
    Private Sub FrmDosCampos_ClickTabPage3() Handles Me.ClickTabPage3
        Me.SelectMenu(2)
        Me.txtIDDepartamento.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
    End Sub
    Private Sub FrmDosCampos_ClickTabPage4() Handles Me.ClickTabPage4
        Me.SelectMenu(3)
        Me.txtIDProvincia.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
    End Sub
    Private Sub FrmDosCampos_ClickTabPage5() Handles Me.ClickTabPage5
        Me.SelectMenu(4)
        Me.txtIDDistrito.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE1")
    End Sub
    Private Sub FrmDosCampos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Me.DialogResult = Windows.Forms.DialogResult.OK
        'Call GrillasCombos()
    End Sub

    Private Sub FrmDosCampos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call GrillasCombos()

            SplitContainer2.Panel1Collapsed = False
            ShadowLabel1.Text = _Nombre
            MenuTab.Items(0).Text = "LISTA GENERAL"
            MenuTab.Items(1).Text = _DataGeneral(UBound(_DataGeneral) - 3)
            MenuTab.Items(2).Text = _DataGeneral(UBound(_DataGeneral) - 2)
            MenuTab.Items(3).Text = _DataGeneral(UBound(_DataGeneral) - 1)
            MenuTab.Items(4).Text = _DataGeneral(UBound(_DataGeneral))
            MenuTab.Items(2).Visible = False
            MenuTab.Items(3).Visible = False
            MenuTab.Items(4).Visible = False
            Call Funciones.HabilitarMenu(MenuTab)
            Call CargaDatos()
            Fact = 0
            Call CargaTreeCampos()
            MyTreeView.Nodes(0).Checked = True

            'Llenando los combos.
            cmbPaisDepartamento.DataSource = dvPaisDepartamento
            cmbPaisDepartamento.DisplayMember = "PAIS"
            cmbPaisDepartamento.ValueMember = "IDPAIS"

            cmbPaisProvincia.DataSource = dvPaisProvincia
            cmbPaisProvincia.DisplayMember = "PAIS"
            cmbPaisProvincia.ValueMember = "IDPAIS"

            cmbPaisDistrito.DataSource = dvPaisDistrito
            cmbPaisDistrito.DisplayMember = "PAIS"
            cmbPaisDistrito.ValueMember = "IDPAIS"

            cmbDepartamentoProvincia.DataSource = dvDepartamentoProvincia
            cmbDepartamentoProvincia.DisplayMember = "DEPARTAMENTO"
            cmbDepartamentoProvincia.ValueMember = "IDDEPARTAMENTO"

            cmbDepartamentoDistrito.DataSource = dvDepartamentoDistrito
            cmbDepartamentoDistrito.DisplayMember = "DEPARTAMENTO"
            cmbDepartamentoDistrito.ValueMember = "IDDEPARTAMENTO"

            cmbProvincia.DataSource = dvProvincia
            cmbProvincia.DisplayMember = "PROVINCIA"
            cmbProvincia.ValueMember = "IDPROVINCIA"

            If InsertA = 1 Then
                Me.MyTreeView.Nodes(0).Checked = True
                Me.MenuStrip1.Items(0).PerformClick()
            End If
            If InsertA = 2 Then
                Me.MyTreeView.Nodes(1).Checked = True
                Me.MenuStrip1.Items(0).PerformClick()
            End If
            If InsertA = 3 Then
                Me.MyTreeView.Nodes(2).Checked = True
                Me.MenuStrip1.Items(0).PerformClick()
            End If
            If InsertA = 4 Then
                Me.MyTreeView.Nodes(3).Checked = True
                Me.MenuStrip1.Items(0).PerformClick()
            End If
            '

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub GrillaMantePais()
        For i As Integer = 0 To DataGridLista.Columns.Count - 1
            'MessageBox.Show(DataGridLista.Columns.Count)
            'MessageBox.Show(DataGridLista.Columns.Item(DataGridLista.Columns.Count - 1).Name)
            DataGridLista.Columns.Remove(DataGridLista.Columns.Item(DataGridLista.Columns.Count - 1).Name)
        Next
        dvPaisG = dtPaisG.DefaultView
        With DataGridLista
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .BackgroundColor = Color.White
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = dvPaisG 'dtCampo1
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            .RowHeadersVisible = False
            .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .HeaderText = _NombreCampo1
            .Name = "CAMPO1"
            .DataPropertyName = _DataGeneral(3) '_campo1
            .ReadOnly = True
            .ToolTipText = "Identificador del cliente en la Base de Datos"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .HeaderText = _NombreCampo2
            .Name = "CAMPO2"
            .DataPropertyName = _DataGeneral(4) '_campo2
            .ToolTipText = "Código del Cliente"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        DataGridLista.Columns.AddRange(col1, col2)

    End Sub

    Sub GrillaManteDepartamento()

        For i As Integer = 0 To DataGridLista.Columns.Count - 1
            'MessageBox.Show(DataGridLista.Columns.Count)
            'MessageBox.Show(DataGridLista.Columns.Item(DataGridLista.Columns.Count - 1).Name)
            DataGridLista.Columns.Remove(DataGridLista.Columns.Item(DataGridLista.Columns.Count - 1).Name)
        Next
        dvDepartamentoG = dtDepartamentoG.DefaultView
        With DataGridLista
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .BackgroundColor = Color.White
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = dvDepartamentoG 'dtCampo2
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            .RowHeadersVisible = False
            .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .HeaderText = _NombreCampo3
            .Name = "CAMPO1"
            .DataPropertyName = _DataGeneral(5)
            .ReadOnly = True
            .ToolTipText = "Identificador del cliente en la Base de Datos"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .HeaderText = _NombreCampo2
            .Name = "CAMPO2"
            .DataPropertyName = _DataGeneral(6)
            .ToolTipText = "Código del Cliente"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .HeaderText = _NombreCampo4
            .Name = "CAMPO3"
            .DataPropertyName = _DataGeneral(7)
            .ToolTipText = "Código del Cliente"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .HeaderText = "IDPAIS"
            .Name = "CAMPO4"
            .DataPropertyName = "IDPAIS"
            .ToolTipText = "Código del Cliente"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        DataGridLista.Columns.AddRange(col1, col2, col3, col4)
        DataGridLista.Columns(3).Visible = False

    End Sub

    Sub GrillaManteProvincia()

        For i As Integer = 0 To DataGridLista.Columns.Count - 1
            'MessageBox.Show(DataGridLista.Columns.Count)
            'MessageBox.Show(DataGridLista.Columns.Item(DataGridLista.Columns.Count - 1).Name)
            DataGridLista.Columns.Remove(DataGridLista.Columns.Item(DataGridLista.Columns.Count - 1).Name)
        Next
        dvProvinciaG = dtProvinciaG.DefaultView
        With DataGridLista
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .BackgroundColor = Color.White
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = dvProvinciaG 'dtCampo3
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            .RowHeadersVisible = False
            .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .HeaderText = _NombreCampo5
            .Name = "CAMPO1"
            .DataPropertyName = _DataGeneral(8)
            .ReadOnly = True
            .ToolTipText = "Identificador del cliente en la Base de Datos"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .HeaderText = _NombreCampo2
            .Name = "CAMPO2"
            .DataPropertyName = _DataGeneral(9)
            .ToolTipText = "Código del Cliente"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .HeaderText = _NombreCampo4
            .Name = "CAMPO3"
            .DataPropertyName = _DataGeneral(10)
            .ToolTipText = "Código del Cliente"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .HeaderText = _NombreCampo6
            .Name = "CAMPO4"
            .DataPropertyName = _DataGeneral(11)
            .ToolTipText = "Código del Cliente"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .HeaderText = "IDPAIS"
            .Name = "CAMPO5"
            .DataPropertyName = "IDPAIS"
            .ToolTipText = "Código del Cliente"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col6 As New DataGridViewTextBoxColumn
        With col6
            .HeaderText = "IDDEPARTAMENTO"
            .Name = "CAMPO6"
            .DataPropertyName = "IDDEPARTAMENTO"
            .ToolTipText = "Código del Cliente"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        DataGridLista.Columns.AddRange(col1, col2, col3, col4, col5, col6)
        DataGridLista.Columns(4).Visible = False
        DataGridLista.Columns(5).Visible = False
    End Sub

    Sub GrillaManteDistrito()

        For i As Integer = 0 To DataGridLista.Columns.Count - 1
            'MessageBox.Show(DataGridLista.Columns.Count)
            'MessageBox.Show(DataGridLista.Columns.Item(DataGridLista.Columns.Count - 1).Name)
            DataGridLista.Columns.Remove(DataGridLista.Columns.Item(DataGridLista.Columns.Count - 1).Name)
        Next
        dvDistritoG = dtDistritoG.DefaultView
        With DataGridLista
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .BackgroundColor = Color.White
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = dvDistritoG 'dtCampo4
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            .RowHeadersVisible = False
            .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim col1 As New DataGridViewTextBoxColumn
        With col1
            .HeaderText = _NombreCampo7
            .Name = "CAMPO1"
            .DataPropertyName = _DataGeneral(12)
            .ReadOnly = True
            .ToolTipText = "Identificador del cliente en la Base de Datos"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim col2 As New DataGridViewTextBoxColumn
        With col2
            .HeaderText = _NombreCampo2
            .Name = "CAMPO2"
            .DataPropertyName = _DataGeneral(13)
            .ToolTipText = "Código del Cliente"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col3 As New DataGridViewTextBoxColumn
        With col3
            .HeaderText = _NombreCampo4
            .Name = "CAMPO3"
            .DataPropertyName = _DataGeneral(14)
            .ToolTipText = "Código del Cliente"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col4 As New DataGridViewTextBoxColumn
        With col4
            .HeaderText = _NombreCampo6
            .Name = "CAMPO4"
            .DataPropertyName = _DataGeneral(15)
            .ToolTipText = "Código del Cliente"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col5 As New DataGridViewTextBoxColumn
        With col5
            .HeaderText = _NombreCampo8
            .Name = "CAMPO5"
            .DataPropertyName = _DataGeneral(16)
            .ToolTipText = "Código del Cliente"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col6 As New DataGridViewTextBoxColumn
        With col6
            .HeaderText = "IDPAIS"
            .Name = "CAMPO6"
            .DataPropertyName = "IDPAIS"
            .ToolTipText = "Código del Cliente"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col7 As New DataGridViewTextBoxColumn
        With col7
            .HeaderText = "IDDEPARTAMENTO"
            .Name = "CAMPO7"
            .DataPropertyName = "IDDEPARTAMENTO"
            .ToolTipText = "Código del Cliente"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim col8 As New DataGridViewTextBoxColumn
        With col8
            .HeaderText = "IDPROVINCIA"
            .Name = "CAMPO8"
            .DataPropertyName = "IDPROVINCIA"
            .ToolTipText = "Código del Cliente"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        DataGridLista.Columns.AddRange(col1, col2, col3, col4, col5, col6, col7, col8)
        DataGridLista.Columns(5).Visible = False
        DataGridLista.Columns(6).Visible = False
        DataGridLista.Columns(7).Visible = False
    End Sub

    Sub Edicion()
        Try
            'Dim filarow As Integer
            'Dim DrUnd As DataRowView
            'filarow = DataGridLista.CurrentRow.Index
            'If filarow >= 0 Then
            '    TabMante.SelectedIndex = 1
            '    DrUnd = dvCampo1.Item(DataGridLista.CurrentRow.Index)
            '    txtCampoUno.Text = DrUnd(_campo1).ToString
            '    txtCampoDos.Text = DrUnd(_campo2).ToString
            '    txtCampoDos.Focus()
            'End If
            If MyTreeView.Nodes(0).Checked = True Then
                'MessageBox.Show("Paises")
                Dim dvrw As DataGridViewRow = Me.DataGridLista.CurrentRow
                txtCampoUno.Text = dvrw.Cells("CAMPO1").Value.ToString
                txtCampoDos.Text = dvrw.Cells("CAMPO2").Value.ToString
                SelectMenu(1)
                txtCampoDos.Focus()
                SplitContainer2.Panel1Collapsed = True
                NuevoToolStripMenuItem.Enabled = False
                EdicionToolStripMenuItem.Enabled = False
                CancelarToolStripmenuItem.Enabled = True
                CancelarToolStripmenuItem.Visible = True
                GrabarToolStripMenuItem.Enabled = True 'Colocar en todos los formualrios esto, luego de dshabilitarlos.
                EliminarToolStripMenuItem.Enabled = False
                ExportarToolStripMenuItem.Enabled = False
                ImprimirToolStripMenuItem.Enabled = False
            End If
            If MyTreeView.Nodes(1).Checked = True Then
                'MessageBox.Show("Departamentos")
                Dim dvrw As DataGridViewRow = Me.DataGridLista.CurrentRow
                Me.txtIDDepartamento.Text = dvrw.Cells("CAMPO1").Value.ToString
                Me.txtDepartamento.Text = dvrw.Cells("CAMPO3").Value.ToString
                cmbPaisDepartamento.SelectedValue = CType(dvrw.Cells("CAMPO4").Value, Integer)
                SelectMenu(2)
                txtDepartamento.Focus()
                SplitContainer2.Panel1Collapsed = True
                NuevoToolStripMenuItem.Enabled = False
                EdicionToolStripMenuItem.Enabled = False
                CancelarToolStripmenuItem.Enabled = True
                CancelarToolStripmenuItem.Visible = True
                GrabarToolStripMenuItem.Enabled = True 'Colocar en todos los formualrios esto, luego de dshabilitarlos.
                EliminarToolStripMenuItem.Enabled = False
                ExportarToolStripMenuItem.Enabled = False
                ImprimirToolStripMenuItem.Enabled = False
            End If
            If MyTreeView.Nodes(2).Checked = True Then
                Dim dvrw As DataGridViewRow = Me.DataGridLista.CurrentRow
                If IsDBNull(dvrw.Cells("CAMPO1").Value) Or IsDBNull(dvrw.Cells("CAMPO4").Value) Then
                    MessageBox.Show("No existe la Provincia", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Me.cmbPaisProvincia.SelectedValue = CType(dvrw.Cells("CAMPO5").Value, Integer)
                    Me.cmbDepartamentoProvincia.SelectedValue = CType(dvrw.Cells("CAMPO6").Value, Integer)
                    Me.txtIDProvincia.Text = CType(dvrw.Cells("CAMPO1").Value, Integer)
                    Me.txtProvincia.Text = CType(dvrw.Cells("CAMPO4").Value, String)
                    SelectMenu(3)
                    SplitContainer2.Panel1Collapsed = True
                    NuevoToolStripMenuItem.Enabled = False
                    EdicionToolStripMenuItem.Enabled = False
                    CancelarToolStripmenuItem.Enabled = True
                    CancelarToolStripmenuItem.Visible = True
                    GrabarToolStripMenuItem.Enabled = True 'Colocar en todos los formualrios esto, luego de dshabilitarlos.
                    EliminarToolStripMenuItem.Enabled = False
                    ExportarToolStripMenuItem.Enabled = False
                    ImprimirToolStripMenuItem.Enabled = False
                End If
            End If
            If MyTreeView.Nodes(3).Checked = True Then
                Dim dvrw As DataGridViewRow = Me.DataGridLista.CurrentRow
                If IsDBNull(dvrw.Cells("CAMPO1").Value) Or IsDBNull(dvrw.Cells("CAMPO5").Value) Then
                    MessageBox.Show("No existe el Distrito", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Me.cmbPaisDistrito.SelectedValue = CType(dvrw.Cells("CAMPO6").Value, Integer)
                    Me.cmbDepartamentoDistrito.SelectedValue = CType(dvrw.Cells("CAMPO7").Value, Integer)
                    Me.cmbProvincia.SelectedValue = CType(dvrw.Cells("CAMPO8").Value, Integer)
                    Me.txtIDDistrito.Text = CType(dvrw.Cells("CAMPO1").Value, Integer)
                    Me.txtDistrito.Text = CType(dvrw.Cells("CAMPO5").Value, String)
                    SelectMenu(4)
                    SplitContainer2.Panel1Collapsed = True
                    NuevoToolStripMenuItem.Enabled = False
                    EdicionToolStripMenuItem.Enabled = False
                    CancelarToolStripmenuItem.Enabled = True
                    CancelarToolStripmenuItem.Visible = True
                    GrabarToolStripMenuItem.Enabled = True 'Colocar en todos los formualrios esto, luego de dshabilitarlos.
                    EliminarToolStripMenuItem.Enabled = False
                    ExportarToolStripMenuItem.Enabled = False
                    ImprimirToolStripMenuItem.Enabled = False
                End If
            End If
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmDosCampos_MenuCancelar() Handles Me.MenuCancelar
        SplitContainer2.Panel1Collapsed = False

        SelectMenu(0)
        SplitContainer2.Panel1Collapsed = False
        NuevoToolStripMenuItem.Enabled = True
        EdicionToolStripMenuItem.Enabled = True
        CancelarToolStripmenuItem.Enabled = False
        CancelarToolStripmenuItem.Visible = False
        GrabarToolStripMenuItem.Enabled = False
        EliminarToolStripMenuItem.Enabled = True
        ExportarToolStripMenuItem.Enabled = True
        ImprimirToolStripMenuItem.Enabled = True

    End Sub

    Private Sub FrmRutas_MenuEditar() Handles Me.MenuEditar
        Fact = 2
        Call Edicion()
        'Codigo de Edicion de la Plantilla
        'SelectMenu(1)
        'SplitContainer2.Panel1Collapsed = True
        'NuevoToolStripMenuItem.Enabled = False
        'EdicionToolStripMenuItem.Enabled = False
        'CancelarToolStripmenuItem.Enabled = True
        'CancelarToolStripmenuItem.Visible = True
        'GrabarToolStripMenuItem.Enabled = True 'Colocar en todos los formualrios esto, luego de dshabilitarlos.
        'EliminarToolStripMenuItem.Enabled = False
        'ExportarToolStripMenuItem.Enabled = False
        'ImprimirToolStripMenuItem.Enabled = False
    End Sub

    Private Sub FrmDosCampos_MenuExEMail() Handles Me.MenuExEMail
        Try
            Dim MyMail As New Net.Mail.MailMessage
            Dim smtp As New System.Net.Mail.SmtpClient
            MyMail.From = New System.Net.Mail.MailAddress("evizcarra@tepsa.com.pe")
            MyMail.To.Add("rvasquez@tepsa.com.pe")
            MyMail.Subject = "Prueba de Correo"
            MyMail.Body = "Prueba de Correo RVC"
            smtp.Host = "192.168.200.2"
            'SmtpMail.SmtpServer = "192.168.50.1"
            smtp.Send(MyMail)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub

    'Private Sub FrmRutas_MenuGrabar2009() Handles Me.MenuGrabar
    'If MyTreeView.Nodes(0).Checked = True Then
    '    'Dim fil As Integer
    '    'Dim dr As DataRowView
    '    Try
    '        'El fact indica si es Insercion o Actualizacion.
    '        Dim ObjUnd As Object() = {_SPGraba, 8, Fact, 1, CType(txtCampoUno.Text, Integer), 1, txtCampoDos.Text, 2}
    '        rst = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd)
    '        rstCampo1 = rst.NextRecordset()
    '        Call GrillasCombos()
    '        For i As Integer = 0 To Me.DataGridLista.RowCount - 1
    '            If Me.DataGridLista.Rows(i).Cells("CAMPO2").Value.ToString = txtCampoDos.Text Then
    '                'MessageBox.Show("Inserto")
    '                PaisSeleccionado = CType(Me.DataGridLista.Rows(i).Cells("CAMPO1").Value, Integer)
    '            End If
    '        Next
    '        Me.MyTreeView.Nodes(0).Checked = False
    '        Me.MyTreeView.Nodes(0).Checked = True
    '        Me.DialogResult = Windows.Forms.DialogResult.OK
    '        Call GrillasCombos()
    '        PaisSeleccionado = PaisSeleccionado

    '    Catch Qex As Exception
    '        MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End If

    'If MyTreeView.Nodes(1).Checked = True Then
    '    Try
    '        Dim pais As Integer
    '        pais = cmbPaisDepartamento.SelectedValue
    '        'El fact indica si es Insercion o Actualizacion.
    '        Dim ObjUndDepto As Object() = {"PKG_IVOPERSONA.SP_INSUPD_DEPARTAMENTO", 10, Fact, 1, CType(txtIDDepartamento.Text, Integer), 1, pais, 1, txtDepartamento.Text, 2}
    '        rst = VOCONTROLUSUARIO.fnSQLQuery(ObjUndDepto)
    '        rstCampo1 = rst.NextRecordset()
    '        Call GrillasCombos()
    '        For i As Integer = 0 To Me.DataGridLista.RowCount - 1
    '            If Me.DataGridLista.Rows(i).Cells("CAMPO3").Value.ToString = Me.txtDepartamento.Text Then
    '                'MessageBox.Show("Inserto")
    '                PaisSeleccionado = CType(Me.DataGridLista.Rows(i).Cells("CAMPO4").Value, Integer)
    '                DepartamentoSeleccionado = CType(Me.DataGridLista.Rows(i).Cells("CAMPO1").Value, Integer)
    '            End If
    '        Next
    '        Me.MyTreeView.Nodes(1).Checked = False
    '        Me.MyTreeView.Nodes(1).Checked = True
    '        Me.DialogResult = Windows.Forms.DialogResult.OK
    '        Call GrillasCombos()
    '        PaisSeleccionado = PaisSeleccionado
    '        DepartamentoSeleccionado = DepartamentoSeleccionado
    '        'MessageBox.Show(PaisSeleccionado & " " & DepartamentoSeleccionado)

    '    Catch Qex As Exception
    '        MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End If

    'If MyTreeView.Nodes(2).Checked = True Then
    '    Try
    '        Dim pais As Integer
    '        Dim departamento As Integer
    '        pais = cmbPaisProvincia.SelectedValue
    '        departamento = cmbDepartamentoProvincia.SelectedValue
    '        'El fact indica si es Insercion o Actualizacion.
    '        Dim ObjUndDepto As Object() = {"PKG_IVOPERSONA.SP_INSUPD_PROVINCIA", 12, Fact, 1, CType(txtIDProvincia.Text, Integer), 1, departamento, 1, pais, 1, txtProvincia.Text, 2}
    '        rst = VOCONTROLUSUARIO.fnSQLQuery(ObjUndDepto)
    '        rstCampo1 = rst.NextRecordset()
    '        Call GrillasCombos()
    '        For i As Integer = 0 To Me.DataGridLista.RowCount - 1
    '            If Me.DataGridLista.Rows(i).Cells("CAMPO4").Value.ToString = Me.txtProvincia.Text Then
    '                'MessageBox.Show("Inserto")
    '                PaisSeleccionado = CType(Me.DataGridLista.Rows(i).Cells("CAMPO5").Value, Integer)
    '                DepartamentoSeleccionado = CType(Me.DataGridLista.Rows(i).Cells("CAMPO6").Value, Integer)
    '                ProvinciaSeleccionado = CType(Me.DataGridLista.Rows(i).Cells("CAMPO1").Value, Integer)
    '            End If
    '        Next
    '        Me.MyTreeView.Nodes(2).Checked = False
    '        Me.MyTreeView.Nodes(2).Checked = True
    '        Me.DialogResult = Windows.Forms.DialogResult.OK
    '        Call GrillasCombos()
    '        PaisSeleccionado = PaisSeleccionado
    '        DepartamentoSeleccionado = DepartamentoSeleccionado
    '        ProvinciaSeleccionado = ProvinciaSeleccionado
    '        'MessageBox.Show(PaisSeleccionado & " " & DepartamentoSeleccionado & " " & ProvinciaSeleccionado)

    '    Catch Qex As Exception
    '        MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End If

    'If MyTreeView.Nodes(3).Checked = True Then
    '    'MessageBox.Show("Distritos")
    '    Try
    '        Dim pais As Integer
    '        Dim departamento As Integer
    '        Dim provincia As Integer
    '        pais = cmbPaisDistrito.SelectedValue
    '        departamento = cmbDepartamentoDistrito.SelectedValue
    '        provincia = cmbProvincia.SelectedValue
    '        'El fact indica si es Insercion o Actualizacion.
    '        Dim ObjUndDepto As Object() = {"PKG_IVOPERSONA.SP_INSUPD_DISTRITO", 14, Fact, 1, CType(txtIDDistrito.Text, Integer), 1, provincia, 1, departamento, 1, pais, 1, txtDistrito.Text, 2}
    '        rst = VOCONTROLUSUARIO.fnSQLQuery(ObjUndDepto)
    '        rstCampo1 = rst.NextRecordset()
    '        Call GrillasCombos()
    '        For i As Integer = 0 To Me.DataGridLista.RowCount - 1
    '            If Me.DataGridLista.Rows(i).Cells("CAMPO5").Value.ToString = Me.txtDistrito.Text Then
    '                'MessageBox.Show("Inserto")
    '                PaisSeleccionado = CType(Me.DataGridLista.Rows(i).Cells("CAMPO6").Value, Integer)
    '                DepartamentoSeleccionado = CType(Me.DataGridLista.Rows(i).Cells("CAMPO7").Value, Integer)
    '                ProvinciaSeleccionado = CType(Me.DataGridLista.Rows(i).Cells("CAMPO8").Value, Integer)
    '                DistritoSeleccionado = CType(Me.DataGridLista.Rows(i).Cells("CAMPO1").Value, Integer)
    '            End If
    '        Next
    '        'MessageBox.Show(DistritoSeleccionado.ToString)
    '        Me.MyTreeView.Nodes(3).Checked = False
    '        Me.MyTreeView.Nodes(3).Checked = True
    '        Me.DialogResult = Windows.Forms.DialogResult.OK
    '        Call GrillasCombos()
    '        PaisSeleccionado = PaisSeleccionado
    '        DepartamentoSeleccionado = DepartamentoSeleccionado
    '        ProvinciaSeleccionado = ProvinciaSeleccionado
    '        DistritoSeleccionado = DistritoSeleccionado

    '        MessageBox.Show(dtDistritoFinal.Rows.Count)
    '        'MessageBox.Show(PaisSeleccionado & " " & DepartamentoSeleccionado & " " & ProvinciaSeleccionado & " " & DistritoSeleccionado)

    '    Catch Qex As Exception
    '        MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End If

    'Call CargaDatos()

    'cmbPaisDepartamento.DataSource = dvPaisDepartamento
    'cmbPaisDepartamento.DisplayMember = "PAIS"
    'cmbPaisDepartamento.ValueMember = "IDPAIS"

    'cmbPaisProvincia.DataSource = dvPaisProvincia
    'cmbPaisProvincia.DisplayMember = "PAIS"
    'cmbPaisProvincia.ValueMember = "IDPAIS"

    'cmbPaisDistrito.DataSource = dvPaisDistrito
    'cmbPaisDistrito.DisplayMember = "PAIS"
    'cmbPaisDistrito.ValueMember = "IDPAIS"

    'cmbDepartamentoProvincia.DataSource = dvDepartamentoProvincia
    'cmbDepartamentoProvincia.DisplayMember = "DEPARTAMENTO"
    'cmbDepartamentoProvincia.ValueMember = "IDDEPARTAMENTO"

    'cmbDepartamentoDistrito.DataSource = dvDepartamentoDistrito
    'cmbDepartamentoDistrito.DisplayMember = "DEPARTAMENTO"
    'cmbDepartamentoDistrito.ValueMember = "IDDEPARTAMENTO"

    'cmbProvincia.DataSource = dvProvincia
    'cmbProvincia.DisplayMember = "PROVINCIA"
    'cmbProvincia.ValueMember = "IDPROVINCIA"



    'SelectMenu(0)
    'SplitContainer2.Panel1Collapsed = False
    'NuevoToolStripMenuItem.Enabled = True
    'EdicionToolStripMenuItem.Enabled = True
    'CancelarToolStripmenuItem.Enabled = False
    'CancelarToolStripmenuItem.Visible = False
    'GrabarToolStripMenuItem.Enabled = False
    'EliminarToolStripMenuItem.Enabled = True
    'ExportarToolStripMenuItem.Enabled = True
    'ImprimirToolStripMenuItem.Enabled = True
    'End Sub

    Private Sub FrmDosCampos_MenuImprimir() Handles Me.MenuImprimir
        Dim a As New ClsPrint
        a.Titulo = "CLIENTES CARGA"
        a.DGV = Me.DataGridLista
        Dim MyReport As New Reportes
        'MyReport.MdiParent = FrmContenedor
        MyReport.MdiParent = Principal
        MyReport.pd.Document = a
        MyReport.pd.Dock = DockStyle.Fill
        MyReport.WindowState = FormWindowState.Maximized
        '
        'FrmContenedor.SplitContainer1.Panel2.Controls.Add(MyReport)
        'Principal.Panel1.Controls.Add(MyReport)
        '
        MyReport.Show()
        MyReport.BringToFront()
    End Sub

    Private Sub FrmRutas_MenuNuevo() Handles Me.MenuNuevo
        Fact = 1
        If MyTreeView.Nodes(0).Checked = True Then
            MenuTab.Items(1).PerformClick()
            txtCampoUno.Text = 0
            txtCampoDos.Text = ""
            txtCampoDos.Focus()
        End If

        If MyTreeView.Nodes(1).Checked = True Then
            MenuTab.Items(2).PerformClick()
            txtIDDepartamento.Text = 0
            txtDepartamento.Text = ""
            txtDepartamento.Focus()
        End If

        If MyTreeView.Nodes(2).Checked = True Then
            MenuTab.Items(3).PerformClick()
            txtIDProvincia.Text = 0
            txtProvincia.Text = ""
            txtProvincia.Focus()
        End If

        If MyTreeView.Nodes(3).Checked = True Then
            MenuTab.Items(4).PerformClick()
            txtIDDistrito.Text = 0
            txtDistrito.Text = ""
            txtDistrito.Focus()
        End If

        SplitContainer2.Panel1Collapsed = True
        NuevoToolStripMenuItem.Enabled = False
        EdicionToolStripMenuItem.Enabled = False
        CancelarToolStripmenuItem.Enabled = True
        CancelarToolStripmenuItem.Visible = True
        GrabarToolStripMenuItem.Enabled = True
        EliminarToolStripMenuItem.Enabled = False
        ExportarToolStripMenuItem.Enabled = False
        ImprimirToolStripMenuItem.Enabled = False

    End Sub

    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        If Me.MyTreeView.Nodes(0).Checked = True Then
            If Len(Trim(Me.txtBuscar.Text)) > 0 Then
                dvCampo1.RowFilter = _DataGeneral(4) & " LIKE '%" & Me.txtBuscar.Text & "%'"
            Else
                dvCampo1.RowFilter = ""
            End If
        End If

        If Me.MyTreeView.Nodes(1).Checked = True Then
            If Len(Trim(Me.txtBuscar.Text)) > 0 Then
                dvCampo2.RowFilter = _DataGeneral(7) & " LIKE '%" & Me.txtBuscar.Text & "%'"
            Else
                dvCampo2.RowFilter = ""
            End If
        End If

        If Me.MyTreeView.Nodes(2).Checked = True Then
            If Len(Trim(Me.txtBuscar.Text)) > 0 Then
                dvCampo3.RowFilter = _DataGeneral(11) & " LIKE '%" & Me.txtBuscar.Text & "%'"
            Else
                dvCampo3.RowFilter = ""
            End If
        End If

        If Me.MyTreeView.Nodes(3).Checked = True Then
            If Len(Trim(Me.txtBuscar.Text)) > 0 Then
                dvCampo4.RowFilter = _DataGeneral(16) & " LIKE '%" & Me.txtBuscar.Text & "%'"
            Else
                dvCampo4.RowFilter = ""
            End If
        End If
    End Sub

    Public Sub CargaTreeCampos()
        MyTreeView.CheckBoxes = True
        If Len(Trim(_DataGeneral(UBound(_DataGeneral) - 3))) <> 0 Then
            Me.MyTreeView.Nodes.Add(_DataGeneral(UBound(_DataGeneral) - 3))
        End If
        If Len(Trim(_DataGeneral(UBound(_DataGeneral) - 2))) <> 0 Then
            Me.MyTreeView.Nodes.Add(_DataGeneral(UBound(_DataGeneral) - 2))
        End If
        If Len(Trim(_DataGeneral(UBound(_DataGeneral) - 1))) <> 0 Then
            Me.MyTreeView.Nodes.Add(_DataGeneral(UBound(_DataGeneral) - 1))
        End If
        If Len(Trim(_DataGeneral(UBound(_DataGeneral)))) <> 0 Then
            Me.MyTreeView.Nodes.Add(_DataGeneral(UBound(_DataGeneral)))
        End If
    End Sub

    Private Sub MyTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles MyTreeView.AfterSelect
        'MessageBox.Show(e.Node.Text)

        If e.Node.Text = _DataGeneral(UBound(_DataGeneral) - 3) Then
            e.Node.Checked = True
        End If
        If e.Node.Text = _DataGeneral(UBound(_DataGeneral) - 2) Then
            e.Node.Checked = True
        End If
        If e.Node.Text = _DataGeneral(UBound(_DataGeneral) - 1) Then
            e.Node.Checked = True
        End If
        If e.Node.Text = _DataGeneral(UBound(_DataGeneral)) Then
            e.Node.Checked = True
        End If        
    End Sub

    Private Sub MyTreeView_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles MyTreeView.AfterCheck
        If e.Node.Checked = True Then
            'MessageBox.Show(e.Node.Text)
            If e.Node.Text = _DataGeneral(UBound(_DataGeneral) - 3) Then
                Me.MyTreeView.Nodes(1).Checked = False
                Me.MyTreeView.Nodes(2).Checked = False
                Me.MyTreeView.Nodes(3).Checked = False
                MenuTab.Items(1).Visible = True
                MenuTab.Items(2).Visible = False
                MenuTab.Items(3).Visible = False
                MenuTab.Items(4).Visible = False
                Call GrillaMantePais()
                Me.SelectMenu(0)
            End If
            If e.Node.Text = _DataGeneral(UBound(_DataGeneral) - 2) Then
                Me.MyTreeView.Nodes(0).Checked = False
                Me.MyTreeView.Nodes(2).Checked = False
                Me.MyTreeView.Nodes(3).Checked = False
                MenuTab.Items(1).Visible = False
                MenuTab.Items(2).Visible = True
                MenuTab.Items(3).Visible = False
                MenuTab.Items(4).Visible = False
                Call GrillaManteDepartamento()
                Me.SelectMenu(0)
            End If
            If e.Node.Text = _DataGeneral(UBound(_DataGeneral) - 1) Then
                Me.MyTreeView.Nodes(0).Checked = False
                Me.MyTreeView.Nodes(1).Checked = False
                Me.MyTreeView.Nodes(3).Checked = False
                MenuTab.Items(1).Visible = False
                MenuTab.Items(2).Visible = False
                MenuTab.Items(3).Visible = True
                MenuTab.Items(4).Visible = False
                Call GrillaManteProvincia()
                Me.SelectMenu(0)
            End If
            If e.Node.Text = _DataGeneral(UBound(_DataGeneral)) Then
                Me.MyTreeView.Nodes(0).Checked = False
                Me.MyTreeView.Nodes(1).Checked = False
                Me.MyTreeView.Nodes(2).Checked = False
                MenuTab.Items(1).Visible = False
                MenuTab.Items(2).Visible = False
                MenuTab.Items(3).Visible = False
                MenuTab.Items(4).Visible = True
                Call GrillaManteDistrito()
                Me.SelectMenu(0)
            End If
        End If        
    End Sub
    Private Sub cmbPaisProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPaisProvincia.SelectedIndexChanged
        Dim filCb As Integer
        Dim drc As DataRowView
        Dim valor As String
        filCb = cmbPaisProvincia.SelectedIndex 'Obtiene el Index del Item Seleccionado
        If filCb >= 0 Then
            drc = dvPaisProvincia.Item(filCb)
            valor = IIf(IsDBNull(drc("PAIS")) = True, "0", drc("PAIS").ToString)
            dvDepartamentoProvincia.RowFilter = "PAIS = '" & valor & "'"
        Else
            dvDepartamentoProvincia.RowFilter = "PAIS = ''"
        End If
    End Sub

    Private Sub cmbPaisDistrito_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPaisDistrito.SelectedIndexChanged
        Dim filCb As Integer
        Dim drc As DataRowView
        Dim valor As String
        filCb = cmbPaisDistrito.SelectedIndex 'Obtiene el Index del Item Seleccionado
        If filCb >= 0 Then
            drc = dvPaisDistrito.Item(filCb)
            valor = IIf(IsDBNull(drc("PAIS")) = True, "0", drc("PAIS").ToString)
            dvDepartamentoDistrito.RowFilter = "PAIS = '" & valor & "'"
        Else
            dvDepartamentoDistrito.RowFilter = "PAIS = ''"
        End If
    End Sub

    Private Sub cmbDepartamentoDistrito_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDepartamentoDistrito.SelectedIndexChanged
        Dim filCb As Integer
        Dim drc As DataRowView
        Dim valor As String
        filCb = cmbDepartamentoDistrito.SelectedIndex 'Obtiene el Index del Item Seleccionado
        If filCb >= 0 Then
            drc = dvDepartamentoDistrito.Item(filCb)
            valor = IIf(IsDBNull(drc("DEPARTAMENTO")) = True, "0", drc("DEPARTAMENTO").ToString)
            dvProvincia.RowFilter = "DEPARTAMENTO = '" & valor & "'"
        Else
            dvProvincia.RowFilter = "DEPARTAMENTO = ''"
        End If
    End Sub

    Private Sub FrmDosCampos_MenuSalir() Handles Me.MenuSalir
        Me.Close()
    End Sub

    Private Sub GrillasCombos()
        'datahelper
        'Dim rstPais As ADODB.Recordset
        'Dim rstDepartamento As ADODB.Recordset
        'Dim rstProvincia As ADODB.Recordset
        'Dim rstDistrito As ADODB.Recordset

        dtPaisG.Clear()
        dtDepartamentoG.Clear()
        dtProvinciaG.Clear()
        dtDistritoG.Clear()

        'datahelper
        'Dim MyObject() As Object = {"PKG_IVOPERSONA.SP_GRILLASUBICACION_II", 0}
        'rstPais = VOCONTROLUSUARIO.fnSQLQuery(MyObject)
        'rstDepartamento = rstPais.NextRecordset
        'rstProvincia = rstPais.NextRecordset
        'rstDistrito = rstPais.NextRecordset
        'Dim da As New OleDbDataAdapter
        'da.Fill(dtPaisG, rstPais)
        'da.Fill(dtDepartamentoG, rstDepartamento)
        'da.Fill(dtProvinciaG, rstProvincia)
        'da.Fill(dtDistritoG, rstDistrito)
        '
        Dim ds As New DataSet
        ds = obj_dto_ubigeo.FN_Grilla_Ubicacion_II()
        '

        dtPaisG = ds.Tables(0)
        dtDepartamentoG = ds.Tables(1)
        dtProvinciaG = ds.Tables(2)
        dtDistritoG = ds.Tables(3)

        dtPaisFinal.Clear()
        dtDepartamentoFinal.Clear()
        dtProvinciaFinal.Clear()
        dtDistritoFinal.Clear()

        dtPaisFinal = dtPaisG.Copy
        dtDepartamentoFinal = dtDepartamentoG.Copy
        dtProvinciaFinal = dtProvinciaG.Copy
        dtDistritoFinal = dtDistritoG.Copy

    End Sub

    Private Sub FrmRutas_MenuGrabar() Handles Me.MenuGrabar
        If MyTreeView.Nodes(0).Checked = True Then
            Try
                'Dim ObjUnd As Object() = {_SPGraba, 8, Fact, 1, CType(txtCampoUno.Text, Integer), 1, txtCampoDos.Text, 2}
                'rst = VOCONTROLUSUARIO.fnSQLQuery(ObjUnd)
                'rstCampo1 = rst.NextRecordset()

                'Grabar
                obj_dto_ubigeo.Fact = 1
                obj_dto_ubigeo.idpais = CType(txtCampoUno.Text, Integer)
                obj_dto_ubigeo.pais = txtCampoDos.Text
                '
                rst = obj_dto_ubigeo.grabar_pais(_SPGraba)

                Call GrillasCombos()
                For i As Integer = 0 To Me.DataGridLista.RowCount - 1
                    If Me.DataGridLista.Rows(i).Cells("CAMPO2").Value.ToString = txtCampoDos.Text Then
                        PaisSeleccionado = CType(Me.DataGridLista.Rows(i).Cells("CAMPO1").Value, Integer)
                    End If
                Next
                Me.MyTreeView.Nodes(0).Checked = False
                Me.MyTreeView.Nodes(0).Checked = True
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Call GrillasCombos()
                PaisSeleccionado = PaisSeleccionado

            Catch Qex As Exception
                MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

        If MyTreeView.Nodes(1).Checked = True Then
            Try
                Dim pais As Integer
                pais = cmbPaisDepartamento.SelectedValue

                '
                'Modificado por datahelper 
                '

                'Dim ObjUndDepto As Object() = {"PKG_IVOPERSONA.SP_INSUPD_DEPARTAMENTO", 10, Fact, 1, CType(txtIDDepartamento.Text, Integer), 1, pais, 1, txtDepartamento.Text, 2}
                'rst = VOCONTROLUSUARIO.fnSQLQuery(ObjUndDepto)
                'rstCampo1 = rst.NextRecordset()
                'Dim db As New BaseDatos
                'db.Conectar()
                'db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_DEPARTAMENTO", CommandType.StoredProcedure)
                'db.AsignarParametro("iCONTROL", Fact, OracleClient.OracleType.Int32)
                'db.AsignarParametro("iIDDEPARTAMENTO", CType(txtIDDepartamento.Text, Integer), OracleClient.OracleType.Int32)
                'db.AsignarParametro("iIDPAIS", pais, OracleClient.OracleType.Int32)
                'db.AsignarParametro("iDEPARTAMENTO", txtDepartamento.Text, OracleClient.OracleType.VarChar)
                'db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
                'db.Desconectar()
                'Dim ds As DataSet = db.EjecutarDataSet
                'rst = ds.Tables(0)
                '
                'Grabar Departamento
                obj_dto_ubigeo.Fact = 1
                obj_dto_ubigeo.idpais = pais
                obj_dto_ubigeo.iddepartamento = CType(txtIDDepartamento.Text, Integer)
                obj_dto_ubigeo.departamento = txtDepartamento.Text
                rst = obj_dto_ubigeo.grabar_departamento
                '
                Call GrillasCombos()
                For i As Integer = 0 To Me.DataGridLista.RowCount - 1
                    If Me.DataGridLista.Rows(i).Cells("CAMPO3").Value.ToString = Me.txtDepartamento.Text Then
                        PaisSeleccionado = CType(Me.DataGridLista.Rows(i).Cells("CAMPO4").Value, Integer)
                        DepartamentoSeleccionado = CType(Me.DataGridLista.Rows(i).Cells("CAMPO1").Value, Integer)
                    End If
                Next
                Me.MyTreeView.Nodes(1).Checked = False
                Me.MyTreeView.Nodes(1).Checked = True
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Call GrillasCombos()
                PaisSeleccionado = PaisSeleccionado
                DepartamentoSeleccionado = DepartamentoSeleccionado
            Catch Qex As Exception
                MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        If MyTreeView.Nodes(2).Checked = True Then
            Try
                Dim pais As Integer
                Dim departamento As Integer
                pais = cmbPaisProvincia.SelectedValue
                departamento = cmbDepartamentoProvincia.SelectedValue
                'datahelper
                'Dim ObjUndDepto As Object() = {"PKG_IVOPERSONA.SP_INSUPD_PROVINCIA", 12, Fact, 1, CType(txtIDProvincia.Text, Integer), 1, departamento, 1, pais, 1, txtProvincia.Text, 2}
                'rst = VOCONTROLUSUARIO.fnSQLQuery(ObjUndDepto)
                'rstCampo1 = rst.NextRecordset()
                'Dim db As New BaseDatos
                'db.Conectar()
                'db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_PROVINCIA", CommandType.StoredProcedure)
                'db.AsignarParametro("iCONTROL", Fact, OracleClient.OracleType.Int32)
                'db.AsignarParametro("iIDPROVINCIA", CType(txtIDProvincia.Text, Integer), OracleClient.OracleType.Int32)
                'db.AsignarParametro("iIDDEPARTAMENTO", departamento, OracleClient.OracleType.Int32)
                'db.AsignarParametro("iIDPAIS", pais, OracleClient.OracleType.Int32)
                'db.AsignarParametro("iPROVINCIA", txtProvincia.Text, OracleClient.OracleType.VarChar)
                'db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
                'db.Desconectar()
                'Dim ds As DataSet = db.EjecutarDataSet
                'rst = ds.Tables(0)
                '

                obj_dto_ubigeo.Fact = 1
                obj_dto_ubigeo.idprovincia = CType(txtIDProvincia.Text, Integer)
                obj_dto_ubigeo.provincia = txtProvincia.Text
                '
                obj_dto_ubigeo.idpais = pais
                obj_dto_ubigeo.iddepartamento = departamento
                rst = obj_dto_ubigeo.grabar_provincia()
                ' 
                Call GrillasCombos()
                For i As Integer = 0 To Me.DataGridLista.RowCount - 1
                    If Me.DataGridLista.Rows(i).Cells("CAMPO4").Value.ToString = Me.txtProvincia.Text Then
                        PaisSeleccionado = CType(Me.DataGridLista.Rows(i).Cells("CAMPO5").Value, Integer)
                        DepartamentoSeleccionado = CType(Me.DataGridLista.Rows(i).Cells("CAMPO6").Value, Integer)
                        ProvinciaSeleccionado = CType(Me.DataGridLista.Rows(i).Cells("CAMPO1").Value, Integer)
                    End If
                Next
                Me.MyTreeView.Nodes(2).Checked = False
                Me.MyTreeView.Nodes(2).Checked = True
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Call GrillasCombos()
                PaisSeleccionado = PaisSeleccionado
                DepartamentoSeleccionado = DepartamentoSeleccionado
                ProvinciaSeleccionado = ProvinciaSeleccionado
            Catch Qex As Exception
                MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        If MyTreeView.Nodes(3).Checked = True Then
            Try
                Dim pais As Integer
                Dim departamento As Integer
                Dim provincia As Integer
                pais = cmbPaisDistrito.SelectedValue
                departamento = cmbDepartamentoDistrito.SelectedValue
                provincia = cmbProvincia.SelectedValue
                'datahelper
                'Dim ObjUndDepto As Object() = {"PKG_IVOPERSONA.SP_INSUPD_DISTRITO", 14, Fact, 1, CType(txtIDDistrito.Text, Integer), 1, provincia, 1, departamento, 1, pais, 1, txtDistrito.Text, 2}
                'rst = VOCONTROLUSUARIO.fnSQLQuery(ObjUndDepto)
                'rstCampo1 = rst.NextRecordset()
                'Dim db As New BaseDatos
                'db.Conectar()
                'db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_DISTRITO", CommandType.StoredProcedure)
                'db.AsignarParametro("iCONTROL", Fact, OracleClient.OracleType.Int32)
                'db.AsignarParametro("iIDDISTRITO", CType(txtIDDistrito.Text, Integer), OracleClient.OracleType.Int32)
                'db.AsignarParametro("iIDPROVINCIA", provincia, OracleClient.OracleType.Int32)
                'db.AsignarParametro("iIDDEPARTAMENTO", departamento, OracleClient.OracleType.Int32)
                'db.AsignarParametro("iIDPAIS", pais, OracleClient.OracleType.Int32)
                'db.AsignarParametro("iDISTRITO", txtDistrito.Text, OracleClient.OracleType.VarChar)
                'db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
                'db.Desconectar()
                'Dim ds As DataSet = db.EjecutarDataSet
                'rst = ds.Tables(0)

                obj_dto_ubigeo.Fact = 1
                obj_dto_ubigeo.iddistrito = CType(txtIDDistrito.Text, Integer)
                obj_dto_ubigeo.distrito = txtDistrito.Text
                '
                obj_dto_ubigeo.idpais = pais
                obj_dto_ubigeo.iddepartamento = departamento
                obj_dto_ubigeo.idprovincia = provincia
                rst = obj_dto_ubigeo.grabar_distrito()
                Call GrillasCombos()
                For i As Integer = 0 To Me.DataGridLista.RowCount - 1
                    If Me.DataGridLista.Rows(i).Cells("CAMPO5").Value.ToString = Me.txtDistrito.Text Then
                        PaisSeleccionado = CType(Me.DataGridLista.Rows(i).Cells("CAMPO6").Value, Integer)
                        DepartamentoSeleccionado = CType(Me.DataGridLista.Rows(i).Cells("CAMPO7").Value, Integer)
                        ProvinciaSeleccionado = CType(Me.DataGridLista.Rows(i).Cells("CAMPO8").Value, Integer)
                        DistritoSeleccionado = CType(Me.DataGridLista.Rows(i).Cells("CAMPO1").Value, Integer)
                    End If
                Next
                Me.MyTreeView.Nodes(3).Checked = False
                Me.MyTreeView.Nodes(3).Checked = True
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Call GrillasCombos()
                PaisSeleccionado = PaisSeleccionado
                DepartamentoSeleccionado = DepartamentoSeleccionado
                ProvinciaSeleccionado = ProvinciaSeleccionado
                DistritoSeleccionado = DistritoSeleccionado
                'MessageBox.Show(dtDistritoFinal.Rows.Count)
            Catch Qex As Exception
                MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        Call CargaDatos()

        cmbPaisDepartamento.DataSource = dvPaisDepartamento
        cmbPaisDepartamento.DisplayMember = "PAIS"
        cmbPaisDepartamento.ValueMember = "IDPAIS"

        cmbPaisProvincia.DataSource = dvPaisProvincia
        cmbPaisProvincia.DisplayMember = "PAIS"
        cmbPaisProvincia.ValueMember = "IDPAIS"

        cmbPaisDistrito.DataSource = dvPaisDistrito
        cmbPaisDistrito.DisplayMember = "PAIS"
        cmbPaisDistrito.ValueMember = "IDPAIS"

        cmbDepartamentoProvincia.DataSource = dvDepartamentoProvincia
        cmbDepartamentoProvincia.DisplayMember = "DEPARTAMENTO"
        cmbDepartamentoProvincia.ValueMember = "IDDEPARTAMENTO"

        cmbDepartamentoDistrito.DataSource = dvDepartamentoDistrito
        cmbDepartamentoDistrito.DisplayMember = "DEPARTAMENTO"
        cmbDepartamentoDistrito.ValueMember = "IDDEPARTAMENTO"

        cmbProvincia.DataSource = dvProvincia
        cmbProvincia.DisplayMember = "PROVINCIA"
        cmbProvincia.ValueMember = "IDPROVINCIA"
        SelectMenu(0)
        SplitContainer2.Panel1Collapsed = False
        NuevoToolStripMenuItem.Enabled = True
        EdicionToolStripMenuItem.Enabled = True
        CancelarToolStripmenuItem.Enabled = False
        CancelarToolStripmenuItem.Visible = False
        GrabarToolStripMenuItem.Enabled = False
        EliminarToolStripMenuItem.Enabled = True
        ExportarToolStripMenuItem.Enabled = True
        ImprimirToolStripMenuItem.Enabled = True
    End Sub

    Private Sub FrmDosCampos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Sub VerificaCambio(ByVal sender As Object, ByVal e As EventArgs) Handles NuevoToolStripMenuItem.EnabledChanged, EdicionToolStripMenuItem.EnabledChanged, GrabarToolStripMenuItem.EnabledChanged, EliminarToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged, AyudaToolStripMenuItem.EnabledChanged, ImprimirToolStripMenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub DataGridLista_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridLista.CellContentClick

    End Sub
End Class

