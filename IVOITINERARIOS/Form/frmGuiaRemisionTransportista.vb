Public Class frmGuiaRemisionTransportista

    'Instancia de Clase de Programcion de Vehiculo
    Dim objGuiaRemisionTransportista As New dtoGuiaRemisionTransportista

    'Variable para obtener el listado de Unidad de Agencia
    Dim dsListaUnidadOrigen As DataSet
    Dim dsListaUnidadDestino As DataSet
    Dim dsAgenciaOrigen As DataSet

    'Variable para obtener los datos generales para la generación de guías de transportistas
    Dim dsDatosGenerales As DataSet

    'Variable para obtener el listado de Guía de Remisión de Transportista
    Dim dsListaGuiaRemision As DataSet

    'Variable para Seleccionar la Unidad Origen en la Ficha de Consulta
    Dim blnUnidadOk As Boolean = False

    '-------------------------------------------------------------------------------------------------------
    '------------------------ Pestaña de Listado de Guía de Remisión Transportista  ------------------------
    '-------------------------------------------------------------------------------------------------------
    Private Sub frmGuiaRemisionTransportista_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.WindowState = FormWindowState.Maximized
            NuevoToolStripMenuItem.Visible = True
            EdicionToolStripMenuItem.Visible = True
            AnularToolStripMenuItem.Visible = True
            ImprimirToolStripMenuItem.Visible = True
            ConsultarToolStripMenuItem.Visible = True

            GrabarToolStripMenuItem.Visible = False
            CancelarToolStripmenuItem.Visible = False
            ExportarToolStripMenuItem.Visible = False
            ImprimirToolStripMenuItem.Visible = True
            ReporteToolStripMenuItem.Visible = False
            CierreComisionesToolStripMenuItem.Visible = False

            TCGuiaRemisionTransportista.Controls.RemoveAt(1)

            dsListaUnidadOrigen = objGuiaRemisionTransportista.fncListarUnidadOrigen()
            dsListaUnidadDestino = objGuiaRemisionTransportista.fncListarUnidadOrigen()

            cboUnidadAgenciaDestino.DataSource = dsListaUnidadDestino.Tables(0)
            cboUnidadAgenciaDestino.DisplayMember = "Nombre_Unidad"
            cboUnidadAgenciaDestino.ValueMember = "IdUnidad_Agencia"
            cboUnidadAgenciaDestino.SelectedValue = 0

            cboUnidadAgenciaOrigen.DataSource = dsListaUnidadOrigen.Tables(0)
            cboUnidadAgenciaOrigen.DisplayMember = "Nombre_Unidad"
            cboUnidadAgenciaOrigen.ValueMember = "IdUnidad_Agencia"
            cboUnidadAgenciaOrigen.SelectedValue = dtoUSUARIOS.IdUnidadAgenciaReal

            objGuiaRemisionTransportista.UnidadAgenciaOrigen = cboUnidadAgenciaOrigen.SelectedValue

            dsAgenciaOrigen = objGuiaRemisionTransportista.fncListarAgenciaOrigen
            cboAgenciaOrigen.DataSource = dsAgenciaOrigen.Tables(0)
            cboAgenciaOrigen.DisplayMember = "Nombre_Agencia"
            cboAgenciaOrigen.ValueMember = "IdAgencias"
            cboAgenciaOrigen.SelectedValue = dtoUSUARIOS.IdAgenciaReal

            blnUnidadOk = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboUnidadAgenciaOrigen_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboUnidadAgenciaOrigen.SelectedIndexChanged
        Try
            If blnUnidadOk = True Then
                objGuiaRemisionTransportista.UnidadAgenciaOrigen = cboUnidadAgenciaOrigen.SelectedValue

                dsAgenciaOrigen = objGuiaRemisionTransportista.fncListarAgenciaOrigen
                cboAgenciaOrigen.DataSource = dsAgenciaOrigen.Tables(0)
                cboAgenciaOrigen.DisplayMember = "Nombre_Agencia"
                cboAgenciaOrigen.ValueMember = "IdAgencias"
                cboAgenciaOrigen.SelectedIndex = 0

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ConsultarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ConsultarToolStripMenuItem.Click
        Try

            objGuiaRemisionTransportista.UnidadAgenciaOrigen = cboUnidadAgenciaOrigen.SelectedValue
            objGuiaRemisionTransportista.UnidadAgenciaDestino = cboUnidadAgenciaDestino.SelectedValue
            objGuiaRemisionTransportista.AgenciaOrigen = cboAgenciaOrigen.SelectedValue
            objGuiaRemisionTransportista.FechaInicio = dtpFechaSalida.Value.ToShortDateString
            objGuiaRemisionTransportista.FechaFinal = dtpFechaSalida.Value.ToShortDateString

            dsListaGuiaRemision = objGuiaRemisionTransportista.fncListarGuiaRemision

            If Not IsNothing(dsListaGuiaRemision) Then
                dgdListadoGuiasRemision.Columns.Clear()
                fncAgregarColumnasGuiaRemision()
                dgdListadoGuiasRemision.DataSource = dsListaGuiaRemision.Tables(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub fncAgregarColumnasGuiaRemision()
        Try
            Dim IdGuiaTransportista As New DataGridViewTextBoxColumn
            With IdGuiaTransportista
                .HeaderText = "IdGuia_Transportista"
                .Name = "IdGuia_Transportista"
                .DataPropertyName = "IdGuia_Transportista"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim IdAgenciaOrigen As New DataGridViewTextBoxColumn
            With IdAgenciaOrigen
                .HeaderText = "IdAgencias"
                .Name = "IdAgencias"
                .DataPropertyName = "IdAgencias"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim NombreAgenciaOrigen As New DataGridViewTextBoxColumn
            With NombreAgenciaOrigen
                .HeaderText = "Nombre de Agencia"
                .Name = "Nombre_Agencia"
                .DataPropertyName = "Nombre_Agencia"
                .Width = 150
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            Dim IdAgenciaDestino As New DataGridViewTextBoxColumn
            With IdAgenciaDestino
                .HeaderText = "IdAgencias_Destino"
                .Name = "IdAgencias_Destino"
                .DataPropertyName = "IdAgencias_Destino"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim SerieGuiaTransportista As New DataGridViewTextBoxColumn
            With SerieGuiaTransportista
                .HeaderText = "Serie Guía"
                .Name = "Serie_Guia_Transportista"
                .DataPropertyName = "Serie_Guia_Transportista"
                .Width = 85
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
            End With

            Dim NroGuiaTransportista As New DataGridViewTextBoxColumn
            With NroGuiaTransportista
                .HeaderText = "Nro Guía"
                .Name = "Nro_Guia_Transportista"
                .DataPropertyName = "Nro_Guia_Transportista"
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
            End With

            Dim IdUnidadAgenciaOrigen As New DataGridViewTextBoxColumn
            With IdUnidadAgenciaOrigen
                .HeaderText = "IdUnidad_Agencia"
                .Name = "IdUnidad_Agencia"
                .DataPropertyName = "IdUnidad_Agencia"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim NombreUnidadAgenciaOrigen As New DataGridViewTextBoxColumn
            With NombreUnidadAgenciaOrigen
                .HeaderText = "Origen"
                .Name = "Origen"
                .DataPropertyName = "Origen"
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            Dim CodigoIataOrigen As New DataGridViewTextBoxColumn
            With CodigoIataOrigen
                .HeaderText = "Cod. Iata"
                .Name = "Codigo_Iata_Origen"
                .DataPropertyName = "Codigo_Iata_Origen"
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
            End With

            Dim IdUnidadAgenciaDestino As New DataGridViewTextBoxColumn
            With IdUnidadAgenciaDestino
                .HeaderText = "IdUnidad_Agencia_Destino"
                .Name = "IdUnidad_Agencia_Destino"
                .DataPropertyName = "IdUnidad_Agencia_Destino"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim NombreUnidadAgenciaDestino As New DataGridViewTextBoxColumn
            With NombreUnidadAgenciaDestino
                .HeaderText = "Destino"
                .Name = "Destino"
                .DataPropertyName = "Destino"
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            Dim CodigoIataDestino As New DataGridViewTextBoxColumn
            With CodigoIataDestino
                .HeaderText = "Cod. Iata"
                .Name = "Codigo_Iata_Destino"
                .DataPropertyName = "Codigo_Iata_Destino"
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
            End With

            Dim NroSalida As New DataGridViewTextBoxColumn
            With NroSalida
                .HeaderText = "Nro. Salida"
                .Name = "Nro_Salida"
                .DataPropertyName = "Nro_Salida"
                .Width = 90
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
            End With

            Dim FechaSalida As New DataGridViewTextBoxColumn
            With FechaSalida
                .HeaderText = "Fecha de Salida"
                .Name = "Fecha_Salida"
                .DataPropertyName = "Fecha_Salida"
                .Width = 110
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
            End With

            Dim HoraSalida As New DataGridViewTextBoxColumn
            With HoraSalida
                .HeaderText = "Hora de Salida"
                .Name = "Hora_Salida"
                .DataPropertyName = "Hora_Salida"
                .Width = 110
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
            End With

            Dim IdUnidadTransporte As New DataGridViewTextBoxColumn
            With IdUnidadTransporte
                .HeaderText = "IdUnidad_Transporte"
                .Name = "IdUnidad_Transporte"
                .DataPropertyName = "IdUnidad_Transporte"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim NroUnidadTransprte As New DataGridViewTextBoxColumn
            With NroUnidadTransprte
                .HeaderText = "Nro. Transporte"
                .Name = "Nro_Unidad_Transporte"
                .DataPropertyName = "Nro_Unidad_Transporte"
                .Width = 120
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
            End With

            Dim IdTipoServicio As New DataGridViewTextBoxColumn
            With IdTipoServicio
                .HeaderText = "IdTipo_Servicio"
                .Name = "IdTipo_Servicio"
                .DataPropertyName = "IdTipo_Servicio"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim TipoServicio As New DataGridViewTextBoxColumn
            With TipoServicio
                .HeaderText = "Tipo de Servicio"
                .Name = "Tipo_Servicio"
                .DataPropertyName = "Tipo_Servicio"
                .Width = 120
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim IdChofer As New DataGridViewTextBoxColumn
            With IdChofer
                .HeaderText = "IdUsuario_Personal_Piloto"
                .Name = "IdUsuario_Personal_Piloto"
                .DataPropertyName = "IdUsuario_Personal_Piloto"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim IdEstadoBus As New DataGridViewTextBoxColumn
            With IdEstadoBus
                .HeaderText = "Estado_Bus"
                .Name = "Estado_Bus"
                .DataPropertyName = "Estado_Bus"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim EstadoBus As New DataGridViewTextBoxColumn
            With EstadoBus
                .HeaderText = "Estado Bus"
                .Name = "Estado_Registro"
                .DataPropertyName = "Estado_Registro"
                .Width = 115
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            dgdListadoGuiasRemision.Columns.AddRange(IdGuiaTransportista, IdAgenciaOrigen, NombreAgenciaOrigen, IdAgenciaDestino, SerieGuiaTransportista, NroGuiaTransportista, IdUnidadAgenciaOrigen, NombreUnidadAgenciaOrigen, CodigoIataOrigen, IdUnidadAgenciaDestino, NombreUnidadAgenciaDestino, CodigoIataDestino, NroSalida, FechaSalida, HoraSalida, IdUnidadTransporte, NroUnidadTransprte, IdTipoServicio, TipoServicio, IdChofer, IdEstadoBus, EstadoBus)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        Try
            NuevoToolStripMenuItem.Visible = False
            EdicionToolStripMenuItem.Visible = False
            AnularToolStripMenuItem.Visible = False
            ImprimirToolStripMenuItem.Visible = False
            ConsultarToolStripMenuItem.Visible = False

            GrabarToolStripMenuItem.Visible = True
            CancelarToolStripmenuItem.Visible = True

            TCGuiaRemisionTransportista.Controls.RemoveAt(0)
            TCGuiaRemisionTransportista.TabPages.Add(TPGenerarGuiaRemision)

            objGuiaRemisionTransportista.Operacion = 1

            'fncCargarDatosGenerales()

            'fncCrearColumnasCiudades()

            'fncAgregarColumnasCiudades()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EdicionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EdicionToolStripMenuItem.Click
        Try


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub fncCargarDatosGenerales()
        Try
            objGuiaRemisionTransportista.IdTipo_Comprobante = 8
            dsDatosGenerales = objGuiaRemisionTransportista.fncObtenerCorrelativoGuiaRemision

            If Not IsNothing(dsDatosGenerales) Then
                If dsDatosGenerales.Tables(0).Rows.Count > 0 Then

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class