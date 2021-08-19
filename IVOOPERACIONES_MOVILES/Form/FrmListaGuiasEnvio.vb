Public Class FrmListaGuiasEnvio
    Public CODIGO_Solitud As String = "000"
    'Dim daControl_FAC As New OleDb.OleDbDataAdapter
    Dim dtControl_FAC As New System.Data.DataTable
    Dim dvControl_FAC As System.Data.DataView

    Dim bformatImage As Boolean = True
    Dim ObjEntrega_Recojo As New dtoEntrega_Recojo
    Dim id_columEstado As Integer = 3
    Dim IDGRIESTADO_REG As Integer
    Dim bIngreso As Boolean = False
    Public hnd As Long
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub FrmListaGuiasEnvio_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmListaGuiasEnvio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Load_Grid()
            If ObjEntrega_Recojo.fnSP_LISTA_GUIAS_ENVIO(1, CODIGO_Solitud) = True Then
                'Mod.02/10/2009 -->Omendoza - Pasando al datahelper -  
                'rst = ObjEntrega_Recojo.cur_datos
                ' daControl_FAC.Fill(dtControl_FAC, rst)
                '
                dtControl_FAC.Clear()
                dtGridViewGuias.Refresh()
                '
                dtControl_FAC = ObjEntrega_Recojo.dt_cur_datos
                '
                dvControl_FAC = dtControl_FAC.DefaultView
                bformatImage = True
                dtGridViewGuias.DataSource = dvControl_FAC
                dtGridViewGuias.Refresh()
                dtGridViewGuias.Update()
                lbNroRegistro.Text = dvControl_FAC.Count
                If dvControl_FAC.Count = 0 Then
                    MsgBox("No Se han Encontrado Ningún documento para esta busqueda..., en toda la Base de datos", MsgBoxStyle.Information, "Seguridad Sistema")
                End If
            End If
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub Load_Grid()
        Try
            With dtGridViewGuias
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
                .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            End With
            Dim idEstadoImage As New DataGridViewImageColumn
            With idEstadoImage
                .DataPropertyName = "imagen"
                .HeaderText = "CL"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                .DisplayIndex = 0
                .Visible = True
                '.ValuesAreIcons = True
                '.InheritedStyle.BackColor = Color.Transparent
                .Image = bmActivo
            End With
            dtGridViewGuias.Columns.Add(idEstadoImage)

            Dim colID As New DataGridViewTextBoxColumn
            With colID
                .DisplayIndex = 1
                .DataPropertyName = "Idguias_Envio"
                .HeaderText = "Idguias_Envio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = False
            End With
            dtGridViewGuias.Columns.Add(colID)

            Dim Nro_Guia As New DataGridViewTextBoxColumn
            With Nro_Guia
                .DisplayIndex = 2
                .DataPropertyName = "Nro_Guia"
                .HeaderText = "Nro_Guia"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewGuias.Columns.Add(Nro_Guia)
             
            Dim Fecha_Registro As New DataGridViewTextBoxColumn
            With Fecha_Registro
                .DisplayIndex = 3
                .DataPropertyName = "Fecha_Registro"
                .HeaderText = "Fecha_Registro"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewGuias.Columns.Add(Fecha_Registro)

            Dim Razon_Social As New DataGridViewTextBoxColumn
            With Razon_Social
                .DisplayIndex = 4
                .DataPropertyName = "Razon_Social"
                .HeaderText = "Razon_Social"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewGuias.Columns.Add(Razon_Social)


            Dim Origen As New DataGridViewTextBoxColumn
            With Origen
                .DisplayIndex = 5
                .DataPropertyName = "Origen"
                .HeaderText = "Origen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewGuias.Columns.Add(Origen)

            Dim Destino As New DataGridViewTextBoxColumn
            With Destino
                .DisplayIndex = 6
                .DataPropertyName = "Destino"
                .HeaderText = "Destino"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewGuias.Columns.Add(Destino)

            Dim Total_Peso As New DataGridViewTextBoxColumn
            With Total_Peso
                .DisplayIndex = 7
                .DataPropertyName = "Total_Peso"
                .HeaderText = "Total_Peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewGuias.Columns.Add(Total_Peso)

            Dim Total_Volumen As New DataGridViewTextBoxColumn
            With Total_Volumen
                .DisplayIndex = 8
                .DataPropertyName = "Total_Volumen"
                .HeaderText = "Total_Volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.ForeColor = Color.Black
                .ReadOnly = True
                .Visible = True
            End With
            dtGridViewGuias.Columns.Add(Total_Volumen)

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

End Class