Public Class FrmCheckPoint
    Dim daControl_FAC As New OleDb.OleDbDataAdapter
    Dim dtControl_FAC As New System.Data.DataTable
    Dim dvControl_FAC As System.Data.DataView
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub FrmCheckPoint_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmCheckPoint_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmCheckPoint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fnLoadGrid()
            dtControl_FAC.Clear()
            DataGridViewCheckPoint.Refresh()
            'Mod.14/09/2009 -->Omendoza - Pasando al datahelper   
            'daControl_FAC.Fill(dtControl_FAC, ObjEntregaCarga.fnSP_LIST_CHECK_POINT())
            'dvControl_FAC = dtControl_FAC.DefaultView
            Dim ldt_tmp As New DataTable
            ldt_tmp = ObjEntregaCarga.fnSP_LIST_CHECK_POINT()
            dvControl_FAC = ldt_tmp.DefaultView
            'bformatImage = True
            DataGridViewCheckPoint.DataSource = dvControl_FAC
            DataGridViewCheckPoint.Refresh()
            'lbNroRegistro1.Text = dvControl_FAC.Count

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub
    Public Function fnLoadGrid() As Boolean
        Try
            With DataGridViewCheckPoint
                '    .AllowUserToAddRows = False
                '    .AllowUserToDeleteRows = False
                '    .AllowUserToOrderColumns = True
                .BackgroundColor = SystemColors.Window
                .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
                .ReadOnly = True
                '    .AutoGenerateColumns = False
                '    '.DataSource = dtable_Lista_Control_Comprobante
                '    .VirtualMode = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersWidth = 10
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With


            Dim IDVAR As New DataGridViewTextBoxColumn
            With IDVAR
                .DisplayIndex = 0
                .DataPropertyName = "ID_VAR"
                .HeaderText = "PK"

                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            DataGridViewCheckPoint.Columns.Add(IDVAR)

            Dim FECHA As New DataGridViewTextBoxColumn
            With FECHA
                .DisplayIndex = 1
                .DataPropertyName = "Fecha"
                .HeaderText = "FECHA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DataGridViewCheckPoint.Columns.Add(FECHA)


            Dim HORA As New DataGridViewTextBoxColumn
            With HORA
                .DisplayIndex = 2
                .DataPropertyName = "HORA"
                .HeaderText = "HORA"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DataGridViewCheckPoint.Columns.Add(HORA)

            Dim CIUDAD As New DataGridViewTextBoxColumn
            With CIUDAD
                .DisplayIndex = 3
                .DataPropertyName = "Nombre_Unidad"
                .HeaderText = "CIUDAD"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DataGridViewCheckPoint.Columns.Add(CIUDAD)


            Dim OBS As New DataGridViewTextBoxColumn
            With OBS
                .DisplayIndex = 5
                .DataPropertyName = "OBS"
                .HeaderText = "OBS"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            DataGridViewCheckPoint.Columns.Add(OBS)


        Catch ex As Exception

        End Try

        Return False
    End Function
    Protected Overrides Function ProcessCmdKey(ByRef msg As Windows.Forms.Message, ByVal KeyData As Windows.Forms.Keys) As Boolean
        Dim blnCancel As Boolean = True
        Dim flat As Boolean = True
        Try
            Dim var As Integer = msg.WParam.ToInt32
            If msg.WParam.ToInt32 = Keys.Escape Then
                Close()
            Else
                flat = MyBase.ProcessCmdKey(msg, KeyData)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flat
    End Function
End Class