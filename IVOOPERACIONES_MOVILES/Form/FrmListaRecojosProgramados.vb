Public Class FrmListaRecojosProgramados

    'Dim daRecojos As New OleDb.OleDbDataAdapter
    Dim dtRecojos As New System.Data.DataTable
    Dim dvRecojos As System.Data.DataView
    Dim bIngreso As Boolean = False
    Public hnd As Long
    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        Try
            fnFiltrar()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub fnFiltrar()
        Try
            'bloque
            'If fnValidar_Rol("31") = True Then
            If Acceso.SiRol(G_Rol, Me, 1) Then
                Dim iControl As Integer = 0
                Dim idProgramacion_Recojo As String = "0"
                For i As Integer = 0 To DataGridView.Rows.Count - 1
                    If DataGridView.Item(0, i).Value = 1 Then
                        idProgramacion_Recojo = DataGridView.Item(1, i).Value
                        ObjFiltrosEntregaRecojos.fnSP_ASOCIACION_RECOJO(idProgramacion_Recojo)
                        iControl = iControl + 1
                    End If
                Next
                If iControl > 0 Then
                    MsgBox("Asociado Correctamente..." & iControl.ToString & " Registros ", MsgBoxStyle.Information, "Seguridad Sistema")
                    Close()
                Else
                    MsgBox(" No existen Ningun Resultado para esta Operacion", MsgBoxStyle.Information, "Seguridad Sistema")
                End If
            Else
                MsgBox("No tiene Acceso, Solo el Responsable de Movil de la Ciudad...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub fnMarcarTodos()
        Try
            
            For i As Integer = 0 To DataGridView.Rows.Count - 1
                DataGridView.Item(0, i).Value = 1
            Next
        Catch ex As Exception
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub fnDesMarcarTodos()
        Try
            For i As Integer = 0 To DataGridView.Rows.Count - 1
                DataGridView.Item(1, i).Value = 0
            Next

        Catch ex As Exception
            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub FrmListaRecojosProgramados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmListaRecojosProgramados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dtFechaInicio.Text = dtoUSUARIOS.m_sFecha
            fnLoadGrid()
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
        End Try
    End Sub
    Private Sub fnLoadGrid()
        With DataGridView
            '    .AllowUserToAddRows = False
            '    .AllowUserToDeleteRows = False
            '    .AllowUserToOrderColumns = True
            .BackgroundColor = SystemColors.Window
            .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
            .ReadOnly = False
            '    .AutoGenerateColumns = False
            '    '.DataSource = dtable_Lista_Control_Comprobante
            '    .VirtualMode = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersWidth = 10
            ' .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
        End With

        Dim colSelecion As New DataGridViewCheckBoxColumn
        With colSelecion
            '.DataPropertyName = "Selecion"
            '.HeaderText = "Sel"
            '.DisplayIndex = 1
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ''.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            '.ReadOnly = False 
            .DisplayIndex = 0
            .DataPropertyName = "PIVOD"
            .HeaderText = "Sel"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .ReadOnly = False
            .Visible = True
        End With
        DataGridView.Columns.Add(colSelecion)

        Dim colID As New DataGridViewTextBoxColumn
        With colID
            .DisplayIndex = 1
            .DataPropertyName = "idprogramacion_recojos"
            .HeaderText = "IDCOMPROBANTE"

            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .ReadOnly = True
            .Visible = False
        End With
        DataGridView.Columns.Add(colID)

        Dim Razon_Social As New DataGridViewTextBoxColumn
        With Razon_Social
            .DisplayIndex = 2
            .DataPropertyName = "Razon_Social"
            .HeaderText = "Razon_Social"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .ReadOnly = True
            .Visible = True
        End With
        DataGridView.Columns.Add(Razon_Social)

        Dim Dia_Semana As New DataGridViewTextBoxColumn
        With Dia_Semana
            .DisplayIndex = 3
            .DataPropertyName = "Dia_Semana"
            .HeaderText = "DIA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .ReadOnly = True
            .Visible = True
        End With
        DataGridView.Columns.Add(Dia_Semana)

        Dim HORA_RECOJO As New DataGridViewTextBoxColumn
        With HORA_RECOJO
            .DisplayIndex = 4
            .DataPropertyName = "HORA_RECOJO"
            .HeaderText = "HORA_RECOJO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .ReadOnly = True
            .Visible = True
        End With
        DataGridView.Columns.Add(HORA_RECOJO)

        Dim peso_kg As New DataGridViewTextBoxColumn
        With peso_kg
            .DisplayIndex = 5
            .DataPropertyName = "peso_kg"
            .HeaderText = "PESO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .ReadOnly = True
            .Visible = True
        End With
        DataGridView.Columns.Add(peso_kg)


        Dim volumen_m3 As New DataGridViewTextBoxColumn
        With volumen_m3
            .DisplayIndex = 6
            .DataPropertyName = "volumen_m3"
            .HeaderText = "VOLUMEN"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .ReadOnly = True
            .Visible = True
        End With
        DataGridView.Columns.Add(volumen_m3)

        Dim nro_paquetes As New DataGridViewTextBoxColumn
        With nro_paquetes
            .DisplayIndex = 7
            .DataPropertyName = "nro_paquetes"
            .HeaderText = "NRO BULTOS"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .ReadOnly = True
            .Visible = True
        End With
        DataGridView.Columns.Add(nro_paquetes)


        Dim Nombres As New DataGridViewTextBoxColumn
        With Nombres
            .DisplayIndex = 8
            .DataPropertyName = "Nombres"
            .HeaderText = "CONTACTO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .ReadOnly = True
            .Visible = True
        End With
        DataGridView.Columns.Add(Nombres)

        Dim Direccion As New DataGridViewTextBoxColumn
        With Direccion
            .DisplayIndex = 9
            .DataPropertyName = "Direccion"
            .HeaderText = "Direccion"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .ReadOnly = True
            .Visible = True
        End With
        DataGridView.Columns.Add(Nombres)
        DataGridView.Columns.Add(Nombres)

        Dim observacion As New DataGridViewTextBoxColumn
        With observacion
            .DisplayIndex = 10
            .DataPropertyName = "observacion"
            .HeaderText = "OBS"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .ReadOnly = True
            .Visible = True
        End With
        DataGridView.Columns.Add(observacion)

        Dim destino As New DataGridViewTextBoxColumn
        With destino
            .DisplayIndex = 11
            .DataPropertyName = "destino"
            .HeaderText = "DESTINO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .ReadOnly = True
            .Visible = True
        End With
        DataGridView.Columns.Add(destino)


        Dim Responsable As New DataGridViewTextBoxColumn
        With Responsable
            .DisplayIndex = 12
            .DataPropertyName = "Responsable"
            .HeaderText = "RESPONSABLE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.ForeColor = Color.Black
            .ReadOnly = True
            .Visible = True
        End With
        DataGridView.Columns.Add(Responsable)
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        fnBuscar()
    End Sub
    Private Function fnBuscar() As Boolean
        Try
            dtRecojos.Clear()
            'daRecojos.Fill(dtRecojos, ObjFiltrosEntregaRecojos.fnSP_RECOJOS_PROGRAMADOS(dtFechaInicio.Text))
            '
            dtRecojos = ObjFiltrosEntregaRecojos.fnSP_RECOJOS_PROGRAMADOS(dtFechaInicio.Text)
            '
            dvRecojos = dtRecojos.DefaultView
            DataGridView.DataSource = dvRecojos
            DataGridView.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            If DataGridView.Rows.Count = 0 Then
                MsgBox("No existen ninguna Solicitud Programada para este Dia...", MsgBoxStyle.Information, "Seguridad Sistema")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return False
    End Function

    Private Sub DataGridView_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                ContextMenuStrip1.Show(sender, e.X, e.Y)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Private Sub SeleccionTodosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeleccionTodosToolStripMenuItem.Click
        fnMarcarTodos()
    End Sub
    Private Sub FilttrarAsignacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilttrarAsignacionToolStripMenuItem.Click
        Try
            fnFiltrar()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Private Sub DesmarcarTodosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesmarcarTodosToolStripMenuItem.Click
        fnDesMarcarTodos()
    End Sub
End Class