Public Class FrmConsulDespa
    Dim ObjDESPACHO_RECEPCION As New ClsLbTepsa.dtoDESPACHO_RECEPCION
    Dim ObjValida As New ClsLbTepsa.dtoValida
    Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub FrmConsulDespa_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmConsulDespa_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub FrmConsulDespa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.ShadowLabel1.Text = "Consulta de Bultos Ingresados"
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(3).Enabled = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False
            Me.MenuStrip1.Items(6).Visible = False
            '
            'ObjGeneral.FN_L_UNIDAD_agencia_(VOCONTROLUSUARIO, Me.CBIDUNIDAD_AGENCIA_DESTINO)
            'ObjGeneral.FN_L_UNIDAD_agencia_(VOCONTROLUSUARIO, Me.CBIDUNIDAD_AGENCIA)
            '
            ObjGeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA_DESTINO)
            ObjGeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA)
            '
            Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndex = -1
            CBIDUNIDAD_AGENCIA.SelectedIndex = -1
            '
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Sub FORMAT_GRILLA1()
        DGV1.Columns.Clear()
        With DGV1
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            'Datahelper
            .DataSource = ObjDESPACHO_RECEPCION.SP_L_V_L_SALIDA_VEHICULO()
            '
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        Dim FECHA_SALIDA As New DataGridViewTextBoxColumn

        With FECHA_SALIDA
            .HeaderText = "FECHA_SALIDA"
            .Name = "FECHA_SALIDA"
            .DataPropertyName = "FECHA_SALIDA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim TIPO_SERVICIO As New DataGridViewTextBoxColumn

        With TIPO_SERVICIO
            .HeaderText = "TIPO_SERVICIO"
            .Name = "TIPO_SERVICIO"
            .DataPropertyName = "TIPO_SERVICIO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim HORA_SALIDA As New DataGridViewTextBoxColumn

        With HORA_SALIDA
            .HeaderText = "HORA_SALIDA"
            .Name = "HORA_SALIDA"
            .DataPropertyName = "HORA_SALIDA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim NOMBRE_UNIDAD_ORI As New DataGridViewTextBoxColumn

        With NOMBRE_UNIDAD_ORI
            .HeaderText = "NOMBRE_UNIDAD_ORI"
            .Name = "NOMBRE_UNIDAD_ORI"
            .DataPropertyName = "NOMBRE_UNIDAD_ORI"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DESTINO As New DataGridViewTextBoxColumn

        With DESTINO
            .HeaderText = "DESTINO"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim IDNRO_SALIDA As New DataGridViewTextBoxColumn

        With IDNRO_SALIDA
            .HeaderText = "IDNRO_SALIDA"
            .Name = "IDNRO_SALIDA"
            .DataPropertyName = "IDNRO_SALIDA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim ESTADO As New DataGridViewTextBoxColumn

        With ESTADO
            .HeaderText = "ESTADO"
            .Name = "ESTADO"
            .DataPropertyName = "ESTADO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim NRO_UNIDAD_TRANSPORTE As New DataGridViewTextBoxColumn
        With NRO_UNIDAD_TRANSPORTE
            .HeaderText = "NRO_UNIDAD_TRANSPORTE"
            .Name = "NRO_UNIDAD_TRANSPORTE"
            .DataPropertyName = "NRO_UNIDAD_TRANSPORTE"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim Idunidad_Agencia_Destino As New DataGridViewTextBoxColumn
        With Idunidad_Agencia_Destino
            .HeaderText = "Idunidad_Agencia_Destino"
            .Name = "Idunidad_Agencia_Destino"
            .DataPropertyName = "Idunidad_Agencia_Destino"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = False
        End With

        Dim TOTAL_PESO As New DataGridViewTextBoxColumn
        With TOTAL_PESO
            .HeaderText = "T. Peso"
            .Name = "TOTAL_PESO"
            .DataPropertyName = "TOTAL_PESO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = True
        End With

        Dim CANTIDAD As New DataGridViewTextBoxColumn
        With CANTIDAD
            .HeaderText = "Bultos"
            .Name = "CANTIDAD"
            .DataPropertyName = "CANTIDAD"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = True
        End With

        With DGV1
            .Columns.AddRange( _
            FECHA_SALIDA, _
            TIPO_SERVICIO, _
            HORA_SALIDA, _
            NRO_UNIDAD_TRANSPORTE, _
            NOMBRE_UNIDAD_ORI, _
            DESTINO, _
            IDNRO_SALIDA, _
            TOTAL_PESO, _
            CANTIDAD, _
            ESTADO, _
            Idunidad_Agencia_Destino _
            )
        End With
    End Sub



    Private Sub BtnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        Try
            If Len(Me.TXTNRO_UNIDAD_TRANSPORTE.Text.Trim) = 0 Then
                ObjDESPACHO_RECEPCION.NRO_UNIDAD_TRANSPORTE = 0
            Else
                ObjDESPACHO_RECEPCION.NRO_UNIDAD_TRANSPORTE = Me.TXTNRO_UNIDAD_TRANSPORTE.Text
            End If

            ObjDESPACHO_RECEPCION.FECHA_INI = Me.DTPFECHA_INI.Value.ToShortDateString
            ObjDESPACHO_RECEPCION.FECHA_FINAL = Me.DTPFECHA_FINAL.Value.ToShortDateString


            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
                ObjDESPACHO_RECEPCION.IDUNIDAD_AGENCIA = Me.CBIDUNIDAD_AGENCIA.SelectedValue
            Else
                ObjDESPACHO_RECEPCION.IDUNIDAD_AGENCIA = 0
            End If


            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                ObjDESPACHO_RECEPCION.IDUNIDAD_AGENCIA_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
            Else
                ObjDESPACHO_RECEPCION.IDUNIDAD_AGENCIA_DESTINO = 0
            End If

            FORMAT_GRILLA1()

        Catch ex As System.Data.OracleClient.OracleException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Seguridad del Sistema...")

        End Try

        
    End Sub

    Private Sub _KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNRO_UNIDAD_TRANSPORTE.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.TXTNRO_UNIDAD_TRANSPORTE.Focus()
        End If
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(ObjValida.SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTNRO_UNIDAD_TRANSPORTE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTNRO_UNIDAD_TRANSPORTE.TextChanged
        Me.DGV1.DataSource = Nothing
        Me.DGV2.DataSource = Nothing
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub DGV1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellContentClick

    End Sub

    Private Sub DGV1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellEnter
        Try
            With ObjDESPACHO_RECEPCION
                .IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS
                .FECHA_INI = Me.DTPFECHA_INI.Value.ToShortDateString
                .FECHA_FINAL = Me.DTPFECHA_FINAL.Value.ToShortDateString
                .IDUNIDAD_AGENCIA_DESTINO = Me.DGV1.CurrentRow.Cells("Idunidad_Agencia_Destino").Value

                .NRO_SALIDA = Me.DGV1.CurrentRow.Cells("idnro_salida").Value

                FORMAT_GRILLA2()
                DGV3.DataSource = Nothing
            End With
        Catch ex As System.Data.OracleClient.OracleException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Seguridad del Sistema...")
        Catch se As System.Exception
            MsgBox(se.ToString, MsgBoxStyle.Exclamation, "Seguridad del Sistema...")
        End Try
    End Sub
    Sub FORMAT_GRILLA2()
        DGV2.Columns.Clear()
        With DGV2
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            'datahelper
            .DataSource = ObjDESPACHO_RECEPCION.SP_L_V_L_DESPACHOS()
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim IMAGEN As New DataGridViewImageColumn
        With IMAGEN
            .HeaderText = "E."
            '.Name = "CODIGO_BARRA"
            .DataPropertyName = "IMAGEN"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Image = bmActivo
        End With

        Dim FECHA_GUIA As New DataGridViewTextBoxColumn

        With FECHA_GUIA
            .HeaderText = "Fecha. Documeto"
            .Name = "FECHA_GUIA"
            .DataPropertyName = "FECHA_GUIA"
            .Width = 80
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim NRO_GUIA As New DataGridViewTextBoxColumn

        With NRO_GUIA
            .HeaderText = "NRO_GUIA"
            .Name = "NRO_GUIA"
            .DataPropertyName = "NRO_GUIA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim IDCOMPROBANTE As New DataGridViewTextBoxColumn

        With IDCOMPROBANTE
            .HeaderText = "IDCOMPROBANTE"
            .Name = "IDCOMPROBANTE"
            .DataPropertyName = "IDCOMPROBANTE"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = False
        End With
        Dim IDTIPO_COMPROBANTE As New DataGridViewTextBoxColumn

        With IDTIPO_COMPROBANTE
            .HeaderText = "IDTIPO_COMPROBANTE"
            .Name = "IDTIPO_COMPROBANTE"
            .DataPropertyName = "IDTIPO_COMPROBANTE"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = False
        End With
        Dim IDAGENCIAS As New DataGridViewTextBoxColumn

        With IDAGENCIAS
            .HeaderText = "IDAGENCIAS"
            .Name = "IDAGENCIAS"
            .DataPropertyName = "IDAGENCIAS"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = False
        End With
        Dim IDUNIDAD_AGENCIA As New DataGridViewTextBoxColumn

        With IDUNIDAD_AGENCIA
            .HeaderText = "IDUNIDAD_AGENCIA"
            .Name = "IDUNIDAD_AGENCIA"
            .DataPropertyName = "IDUNIDAD_AGENCIA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = False
        End With
        Dim ORIGEN As New DataGridViewTextBoxColumn

        With ORIGEN
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim IDAGENCIAS_DESTINO As New DataGridViewTextBoxColumn

        With IDAGENCIAS_DESTINO
            .HeaderText = "IDAGENCIAS_DESTINO"
            .Name = "IDAGENCIAS_DESTINO"
            .DataPropertyName = "IDAGENCIAS_DESTINO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = False
        End With
        Dim IDUNIDAD_AGENCIA_DESTI As New DataGridViewTextBoxColumn

        With IDUNIDAD_AGENCIA_DESTI
            .HeaderText = "IDUNIDAD_AGENCIA_DESTI"
            .Name = "IDUNIDAD_AGENCIA_DESTI"
            .DataPropertyName = "IDUNIDAD_AGENCIA_DESTI"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = False
        End With
        Dim DESTINO As New DataGridViewTextBoxColumn

        With DESTINO
            .HeaderText = "DESTINO"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim RECEPCIONADO As New DataGridViewTextBoxColumn
        With RECEPCIONADO
            .HeaderText = "Recepcionado"
            .Name = "RECEPCIONADO"
            .DataPropertyName = "RECEPCIONADO"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim DESPACHADO As New DataGridViewTextBoxColumn
        With DESPACHADO
            .HeaderText = "Despachado"
            .Name = "DESPACHADO"
            .DataPropertyName = "DESPACHADO"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim PENDIENTE As New DataGridViewTextBoxColumn
        With PENDIENTE
            .HeaderText = "Pendiente"
            .Name = "PENDIENTE"
            .DataPropertyName = "PENDIENTE"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim CANTIDAD_ENTRE_DOMI As New DataGridViewTextBoxColumn
        With CANTIDAD_ENTRE_DOMI
            .HeaderText = "Entregado Domicilio"
            .Name = "CANTIDAD_ENTRE_DOMI"
            .DataPropertyName = "CANTIDAD_ENTRE_DOMI"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim CANTIDAD_PENDI_DOMI As New DataGridViewTextBoxColumn
        With CANTIDAD_PENDI_DOMI
            .HeaderText = "Por Entregar Domicilio"
            .Name = "CANTIDAD_PENDI_DOMI"
            .DataPropertyName = "CANTIDAD_PENDI_DOMI"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim IDESTADO_ENVIO As New DataGridViewTextBoxColumn
        With IDESTADO_ENVIO
            .HeaderText = "IDESTADO_ENVIO"
            .Name = "IDESTADO_ENVIO"
            .DataPropertyName = "IDESTADO_ENVIO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = False
        End With

        Dim TOTAL_VOLUMEN As New DataGridViewTextBoxColumn
        With TOTAL_VOLUMEN
            .HeaderText = "T. Vol"
            .Name = "TOTAL_VOLUMEN"
            .DataPropertyName = "TOTAL_VOLUMEN"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Width = 50
            .Visible = True
        End With

        Dim TOTAL_PESO As New DataGridViewTextBoxColumn
        With TOTAL_PESO
            .HeaderText = "T. Peso"
            .Name = "TOTAL_PESO"
            .DataPropertyName = "TOTAL_PESO"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Width = 50
            .Visible = True
        End With

        Dim SOBRES As New DataGridViewTextBoxColumn
        With SOBRES
            .HeaderText = "T. Sobres"
            .Name = "SOBRES"
            .DataPropertyName = "SOBRES"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Width = 50
            .Visible = True
        End With

        Dim NRO_GUIA_TRANSPORTISTA As New DataGridViewTextBoxColumn
        With NRO_GUIA_TRANSPORTISTA
            .HeaderText = "Guia Transpor."
            .Name = "NRO_GUIA_TRANSPORTISTA"
            .DataPropertyName = "NRO_GUIA_TRANSPORTISTA"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            '.DefaultCellStyle.Format = "N0"
            '.DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Width = 100
            .Visible = True
        End With

        With DGV2
            .Columns.AddRange( _
            IMAGEN, _
            IDESTADO_ENVIO, _
            IDTIPO_COMPROBANTE, _
            IDCOMPROBANTE, _
            FECHA_GUIA, _
            NRO_GUIA, _
            IDAGENCIAS, _
            IDUNIDAD_AGENCIA, _
            ORIGEN, _
            IDAGENCIAS_DESTINO, _
            IDUNIDAD_AGENCIA_DESTI, _
            DESTINO, _
            SOBRES, _
            TOTAL_PESO, _
            TOTAL_VOLUMEN, _
            RECEPCIONADO, _
            DESPACHADO, _
            PENDIENTE, _
            CANTIDAD_ENTRE_DOMI, _
            CANTIDAD_PENDI_DOMI, _
            NRO_GUIA_TRANSPORTISTA _
            )
        End With
    End Sub

    Private Sub DGV2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV2.CellContentClick

    End Sub

    Private Sub DGV2_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV2.CellEnter
        Try
            With ObjDESPACHO_RECEPCION
                .IDTIPO_COMPROBANTE = Me.DGV2.CurrentRow.Cells("IDTIPO_COMPROBANTE").Value
                .IDCOMPROBANTE = Me.DGV2.CurrentRow.Cells("IDCOMPROBANTE").Value
                FORMAT_GRILLA3()
            End With
        Catch ex As System.Data.OracleClient.OracleException
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Seguridad del Sistema...")
        Catch se As System.Exception
            MsgBox(se.ToString, MsgBoxStyle.Exclamation, "Seguridad del Sistema...")
        End Try
    End Sub
    Sub FORMAT_GRILLA3()
        dgv3.Columns.Clear()
        With dgv3
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            'datahelper
            .DataSource = ObjDESPACHO_RECEPCION.SP_L_V_L_BULTOS()
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim IMAGEN As New DataGridViewImageColumn
        With IMAGEN
            .HeaderText = "E."
            '.Name = "CODIGO_BARRA"
            .DataPropertyName = "IMAGEN"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Image = bmActivo
        End With

        Dim CODIGO_BARRA As New DataGridViewTextBoxColumn
        With CODIGO_BARRA
            .HeaderText = "CODIGO_BARRA"
            .Name = "CODIGO_BARRA"
            .DataPropertyName = "CODIGO_BARRA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim IDCOMPROBANTE As New DataGridViewTextBoxColumn

        With IDCOMPROBANTE
            .HeaderText = "IDCOMPROBANTE"
            .Name = "IDCOMPROBANTE"
            .DataPropertyName = "IDCOMPROBANTE"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = False
        End With
        Dim IDTIPO_COMPROBANTE As New DataGridViewTextBoxColumn

        With IDTIPO_COMPROBANTE
            .HeaderText = "IDTIPO_COMPROBANTE"
            .Name = "IDTIPO_COMPROBANTE"
            .DataPropertyName = "IDTIPO_COMPROBANTE"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = False
        End With
        Dim FECHA_REGISTRO As New DataGridViewTextBoxColumn

        With FECHA_REGISTRO
            .HeaderText = "FECHA_REGISTRO"
            .Name = "FECHA_REGISTRO"
            .DataPropertyName = "FECHA_REGISTRO"
            .Width = 120
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim IP As New DataGridViewTextBoxColumn

        With IP
            .HeaderText = "IP"
            .Name = "IP"
            .DataPropertyName = "IP"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn

        With ESTADO_REGISTRO
            .HeaderText = "ESTADO_REGISTRO"
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim IDESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With IDESTADO_REGISTRO
            .HeaderText = "IDESTADO_REGISTRO"
            .Name = "IDESTADO_REGISTRO"
            .DataPropertyName = "IDESTADO_REGISTRO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .Visible = False
        End With


        With dgv3
            .Columns.AddRange( _
            IMAGEN, _
            CODIGO_BARRA, _
            IDCOMPROBANTE, _
            IDTIPO_COMPROBANTE, _
            FECHA_REGISTRO, _
            IP, _
            ESTADO_REGISTRO, _
            IDESTADO_REGISTRO _
            )
        End With
    End Sub

    Private Sub DGV3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.CellContentClick

    End Sub

    Private Sub DGV3_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGV3.CellFormatting

        Try

            If Me.DGV3.RowCount <= 0 Then Exit Sub
            If e.ColumnIndex = 0 Then
                If e.RowIndex >= 0 Then
                    If Not IsDBNull(Me.DGV3.Rows(e.RowIndex).Cells("IDESTADO_REGISTRO").Value) Then
                        Select Case Me.DGV3.Rows(e.RowIndex).Cells("IDESTADO_REGISTRO").Value
                            Case 18
                                e.Value = C_RECEPCIONADO
                            Case 19
                                e.Value = C_DESPACHADO
                            Case 41
                                e.Value = C_DESPACHO_PARCIAL
                            Case 20
                                e.Value = C_LLEGADA
                            Case 40
                                e.Value = C_LLEGADA_PARCIAL
                            Case 25
                                e.Value = C_PERDIDO
                            Case 21
                                e.Value = C_ENTREGADO
                            Case 22
                                e.Value = C_CARGO
                            Case Else
                                e.Value = bmpNoImagen
                        End Select
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Seguridad Sistema...")
        End Try
    End Sub

    Private Sub DGV2_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGV2.CellFormatting

        Try

            If Me.DGV2.RowCount <= 0 Then Exit Sub
            If e.ColumnIndex = 0 Then
                If e.RowIndex >= 0 Then
                    If Not IsDBNull(Me.DGV2.Rows(e.RowIndex).Cells("IDESTADO_ENVIO").Value) Then
                        Select Case Me.DGV2.Rows(e.RowIndex).Cells("IDESTADO_ENVIO").Value
                            Case 18
                                e.Value = C_RECEPCIONADO
                            Case 19
                                e.Value = C_DESPACHADO
                            Case 41
                                e.Value = C_DESPACHO_PARCIAL
                            Case 20
                                e.Value = C_LLEGADA
                            Case 40
                                e.Value = C_LLEGADA_PARCIAL
                            Case 25
                                e.Value = C_PERDIDO
                            Case 21
                                e.Value = C_ENTREGADO
                            Case 22
                                e.Value = C_CARGO
                            Case Else
                                e.Value = bmpNoImagen
                        End Select
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Seguridad Sistema...")
        End Try
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub DGV1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGV1.RowsAdded
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.DGV1), 0)
    End Sub

    Private Sub DGV1_RowStateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles DGV1.RowStateChanged
        Me.lblRegistros.Text = FormatNumber(NumeroRegistro(Me.DGV1), 0)
    End Sub

    Private Sub DGV2_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGV2.RowsAdded
        Me.LblRegistros2.Text = FormatNumber(NumeroRegistro(Me.DGV2), 0)
    End Sub

    Private Sub DGV2_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGV2.RowsRemoved
        Me.LblRegistros2.Text = FormatNumber(NumeroRegistro(Me.DGV2), 0)
    End Sub

    Private Sub DGV3_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGV3.RowsAdded
        Me.LblRegistros3.Text = FormatNumber(NumeroRegistro(Me.DGV3), 0)
    End Sub

    Private Sub DGV3_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGV3.RowsRemoved
        Me.LblRegistros3.Text = FormatNumber(NumeroRegistro(Me.DGV3), 0)
    End Sub

    Private Sub DTPFECHA_INI_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHA_INI.ValueChanged
        Me.DGV1.DataSource = Nothing
        Me.DGV2.DataSource = Nothing
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHA_FINAL_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHA_FINAL.ValueChanged
        Me.DGV1.DataSource = Nothing
        Me.DGV2.DataSource = Nothing
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA.SelectedIndexChanged
        Me.DGV1.DataSource = Nothing
        Me.DGV2.DataSource = Nothing
        Me.DGV3.DataSource = Nothing
    End Sub

    Private Sub CBIDUNIDAD_AGENCIA_DESTINO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndexChanged
        Me.DGV1.DataSource = Nothing
        Me.DGV2.DataSource = Nothing
        Me.DGV3.DataSource = Nothing
    End Sub
End Class