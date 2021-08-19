Public Class frmProgramacionVehiculo

    'Instancia de Clase de Programcion de Vehiculo
    Dim objSalidaVehiculo As New dtoProgramacionVehiculo

    'Variable para obtener el listado de salida de vehiculos
    Dim dsListaUnidadOrigen As DataSet
    Dim dsListaSalidaBus As DataSet

    'Variable para obtener los datos generales para la salida de vehiculos
    Dim dsDatosGenerales As DataSet

    'Variable para obtener las ciudades de origen y destino de la salida de vehiculos
    Dim dsCiudades As DataSet
    Dim dtCiudadOrigen As DataTable
    Dim dtCiudadDestino As DataTable
    Dim dtCiudadIntermedia As DataTable

    'Variable para obtener las ciudades de destino de la ruta seleccionada
    Dim dtCiudadesViaje As DataTable
    Dim dcColumna As DataColumn
    Dim drFila As DataRow

    'Variable para Seleccionar la Unidad Origen en la Ficha de Consulta
    Dim blnUnidadOk As Boolean = False

    'Variable para Seleccionar los buses, servicios, rutas y pilotos en la ficha de programacion de buses
    Dim blnTodoOk As Boolean = False

    Private Sub frmProgramacionVehiculo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.WindowState = FormWindowState.Maximized
            NuevoToolStripMenuItem.Visible = True
            EdicionToolStripMenuItem.Visible = True
            AnularToolStripMenuItem.Visible = True
            GrabarToolStripMenuItem.Visible = False
            CancelarToolStripmenuItem.Visible = False
            ExportarToolStripMenuItem.Visible = False
            ImprimirToolStripMenuItem.Visible = False
            ConsultarToolStripMenuItem.Visible = False
            ReporteToolStripMenuItem.Visible = False
            CierreComisionesToolStripMenuItem.Visible = False

            TCProgramacionBuses.Controls.RemoveAt(1)

            objSalidaVehiculo.UnidadAgenciaOrigen = dtoUSUARIOS.IdUnidadAgenciaReal
            objSalidaVehiculo.FechaSalida = dtpFechaSalida.Value.ToShortDateString

            dsListaUnidadOrigen = objSalidaVehiculo.fncListarUnidadOrigen()

            If Not IsNothing(dsListaUnidadOrigen) Then
                If dsListaUnidadOrigen.Tables(0).Rows.Count > 0 Then
                    cboUnidadAgenciaOrigen.DataSource = dsListaUnidadOrigen.Tables(0)
                    cboUnidadAgenciaOrigen.DisplayMember = "Nombre_Unidad"
                    cboUnidadAgenciaOrigen.ValueMember = "IdUnidad_Agencia"
                    cboUnidadAgenciaOrigen.SelectedValue = dtoUSUARIOS.IdUnidadAgenciaReal
                    blnUnidadOk = True
                Else
                    MessageBox.Show("No existen ciudades registradas", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Return
                End If
            Else
                MessageBox.Show("No existen ciudades registradas", "Titan", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Return
            End If

            fncListarProgramacionBuses()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub fncListarProgramacionBuses()
        Try
            dsListaSalidaBus = objSalidaVehiculo.fncListarSalidaVehiculo

            If Not IsNothing(dsListaSalidaBus) Then
                dgdListadoBuses.Columns.Clear()
                fncAgregarColumnasSalidaBuses()
                dgdListadoBuses.DataSource = dsListaSalidaBus.Tables(0)
            End If
            
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub fncAgregarColumnasSalidaBuses()
        Try
            Dim IdRutaHorario As New DataGridViewTextBoxColumn
            With IdRutaHorario
                .HeaderText = "IDRUTA_HORARIO"
                .Name = "RUTA_HORARIO"
                .DataPropertyName = "RUTA_HORARIO"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim NroSalida As New DataGridViewTextBoxColumn
            With NroSalida
                .HeaderText = "NRO. SALIDA"
                .Name = "NRO_SALIDA"
                .DataPropertyName = "NRO_SALIDA"
                .Width = 90
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim IdUnidadAgenciaOrigen As New DataGridViewTextBoxColumn
            With IdUnidadAgenciaOrigen
                .HeaderText = "UNIDAD AGENCIA ORIGEN"
                .Name = "IDUNIDAD_AGENCIA_ORIGEN"
                .DataPropertyName = "IDUNIDAD_AGENCIA_ORIGEN"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
                .Visible = False
            End With

            Dim IdUnidadAgenciaDestino As New DataGridViewTextBoxColumn
            With IdUnidadAgenciaDestino
                .HeaderText = "UNIDAD AGENCIA DESTINO"
                .Name = "IDUNIDAD_AGENCIA_DESTINO"
                .DataPropertyName = "IDUNIDAD_AGENCIA_DESTINO"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
                .Visible = False
            End With

            Dim Destino As New DataGridViewTextBoxColumn
            With Destino
                .HeaderText = "DESTINO"
                .Name = "DESTINO"
                .DataPropertyName = "DESTINO"
                .Width = 130
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim IdTipoServicio As New DataGridViewTextBoxColumn
            With IdTipoServicio
                .HeaderText = "IDTIPO_SERVICIO"
                .Name = "IDTIPO_SERVICIO"
                .DataPropertyName = "IDTIPO_SERVICIO"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim TipoServicio As New DataGridViewTextBoxColumn
            With TipoServicio
                .HeaderText = "TIPO DE SERVICIO"
                .Name = "TIPO_SERVICIO"
                .DataPropertyName = "TIPO_SERVICIO"
                .Width = 130
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim FechaSalida As New DataGridViewTextBoxColumn
            With FechaSalida
                .HeaderText = "FECHA DE SALIDA"
                .Name = "FECHA_SALIDA"
                .DataPropertyName = "FECHA_SALIDA"
                .Width = 130
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim HoraSalida As New DataGridViewTextBoxColumn
            With HoraSalida
                .HeaderText = "HORA DE SALIDA"
                .Name = "HORA_SALIDA"
                .DataPropertyName = "HORA_SALIDA"
                .Width = 120
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim IdUnidadTransporte As New DataGridViewTextBoxColumn
            With IdUnidadTransporte
                .HeaderText = "IDUNIDAD_TRANSPORTE"
                .Name = "IDUNIDAD_TRANSPORTE"
                .DataPropertyName = "IDUNIDAD_TRANSPORTE"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
                .Visible = False
            End With

            Dim NroUnidadTransporte As New DataGridViewTextBoxColumn
            With NroUnidadTransporte
                .HeaderText = "UNID. DE TRANSPORTE"
                .Name = "NRO_UNIDAD_TRANSPORTE"
                .DataPropertyName = "NRO_UNIDAD_TRANSPORTE"
                .Width = 140
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim MarcaBus As New DataGridViewTextBoxColumn
            With MarcaBus
                .HeaderText = "MARCA DE BUS"
                .Name = "MARCA_BUS"
                .DataPropertyName = "MARCA_BUS"
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim PlacaBus As New DataGridViewTextBoxColumn
            With PlacaBus
                .HeaderText = "PLACA DE BUS"
                .Name = "PLACA_BUS"
                .DataPropertyName = "PLACA_BUS"
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim IdEstadoRegistro As New DataGridViewTextBoxColumn
            With IdEstadoRegistro
                .HeaderText = "IDESTADO_REGISTRO"
                .Name = "IDESTADO_REGISTRO"
                .DataPropertyName = "ESTADO"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim Estado As New DataGridViewTextBoxColumn
            With Estado
                .HeaderText = "ESTADO DE REGISTRO"
                .Name = "ESTADO_REGISTRO"
                .DataPropertyName = "ESTADO_REGISTRO"
                .Width = 150
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            Dim UsuarioChofer As New DataGridViewTextBoxColumn
            With UsuarioChofer
                .HeaderText = "USUARIO CHOFER"
                .Name = "USUARIO_CHOFER"
                .DataPropertyName = "USUARIO_CHOFER"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
                .Visible = False
            End With

            Dim NroLicencia As New DataGridViewTextBoxColumn
            With NroLicencia
                .HeaderText = "NRO. LICENCIA"
                .Name = "NRO_LICENCIA"
                .DataPropertyName = "NRO_LICENCIA"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
                .Visible = False
            End With

            Dim RucTercero As New DataGridViewTextBoxColumn
            With RucTercero
                .HeaderText = "RUC TERCERO"
                .Name = "RUC_TERCERO"
                .DataPropertyName = "RUC_TERCERO"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
                .Visible = False
            End With

            Dim NombreTercero As New DataGridViewTextBoxColumn
            With NombreTercero
                .HeaderText = "NOMBRE TERCERO"
                .Name = "NOM_TERCERO"
                .DataPropertyName = "NOM_TERCERO"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
                .Visible = False
            End With

            Dim FechaLlegada As New DataGridViewTextBoxColumn
            With FechaLlegada
                .HeaderText = "FECHA LLEGADA"
                .Name = "FECHA_LLEGADA"
                .DataPropertyName = "FECHA_LLEGADA"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
                .Visible = False
            End With

            Dim Margen As New DataGridViewTextBoxColumn
            With Margen
                .HeaderText = "MARGEN"
                .Name = "MARGEN"
                .DataPropertyName = "MARGEN"
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .ReadOnly = True
            End With

            dgdListadoBuses.Columns.AddRange(IdRutaHorario, NroSalida, IdUnidadAgenciaOrigen, IdUnidadAgenciaDestino, Destino, IdTipoServicio, TipoServicio, FechaSalida, HoraSalida, IdUnidadTransporte, NroUnidadTransporte, MarcaBus, PlacaBus, IdEstadoRegistro, Estado, UsuarioChofer, NroLicencia, RucTercero, NombreTercero, FechaLlegada, Margen)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    '----------------------------------------------------------------------------------------
    '------------------------ Pestaña de Listado de Salida de Buses  ------------------------
    '----------------------------------------------------------------------------------------
    Private Sub cboUnidadAgenciaOrigen_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboUnidadAgenciaOrigen.SelectedIndexChanged
        Try
            If blnUnidadOk = True Then
                objSalidaVehiculo.UnidadAgenciaOrigen = cboUnidadAgenciaOrigen.SelectedValue
                objSalidaVehiculo.FechaSalida = dtpFechaSalida.Value.ToShortDateString
                fncListarProgramacionBuses()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dtpFechaSalida_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaSalida.ValueChanged
        Try
            objSalidaVehiculo.UnidadAgenciaOrigen = cboUnidadAgenciaOrigen.SelectedValue
            objSalidaVehiculo.FechaSalida = dtpFechaSalida.Value.ToShortDateString
            fncListarProgramacionBuses()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        Try
            NuevoToolStripMenuItem.Visible = False
            EdicionToolStripMenuItem.Visible = False
            AnularToolStripMenuItem.Visible = False
            GrabarToolStripMenuItem.Visible = True
            CancelarToolStripmenuItem.Visible = True

            TCProgramacionBuses.Controls.RemoveAt(0)
            TCProgramacionBuses.TabPages.Add(TPGenerarSalidaBuses)

            objSalidaVehiculo.Operacion = 1

            fncCargarDatosGenerales()

            fncCrearColumnasCiudades()

            fncAgregarColumnasCiudades()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EdicionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EdicionToolStripMenuItem.Click
        Try
            If dgdListadoBuses.Rows.Count <= 0 Then
                MessageBox.Show("No existen registros de buses creados para ser editados", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Return
            End If

            NuevoToolStripMenuItem.Visible = False
            EdicionToolStripMenuItem.Visible = False
            AnularToolStripMenuItem.Visible = False
            GrabarToolStripMenuItem.Visible = True
            CancelarToolStripmenuItem.Visible = True

            TCProgramacionBuses.Controls.RemoveAt(0)
            TCProgramacionBuses.TabPages.Add(TPGenerarSalidaBuses)

            objSalidaVehiculo.Operacion = 2

            fncCargarDatosGenerales()

            cboBus.SelectedValue = dgdListadoBuses.Rows(dgdListadoBuses.CurrentRow.Index).Cells("IDUNIDAD_TRANSPORTE").Value

            Select Case cboServicio.SelectedValue
                Case 4, 5, 6, 9, 10, 11
                    cboRuta.SelectedValue = dgdListadoBuses.Rows(dgdListadoBuses.CurrentRow.Index).Cells("RUTA_HORARIO").Value

                    If dgdListadoBuses.Rows(dgdListadoBuses.CurrentRow.Index).Cells("USUARIO_CHOFER").Value = -666 Then
                        cboPiloto.SelectedValue = 0
                    Else
                        cboPiloto.SelectedValue = dgdListadoBuses.Rows(dgdListadoBuses.CurrentRow.Index).Cells("USUARIO_CHOFER").Value
                    End If
                Case 2
                    cboRuta.SelectedValue = 0
                    cboCiudadOrigen.SelectedValue = dgdListadoBuses.Rows(dgdListadoBuses.CurrentRow.Index).Cells("IDUNIDAD_AGENCIA_ORIGEN").Value
                    cboCiudadDestino.SelectedValue = dgdListadoBuses.Rows(dgdListadoBuses.CurrentRow.Index).Cells("IDUNIDAD_AGENCIA_DESTINO").Value

                    If dgdListadoBuses.Rows(dgdListadoBuses.CurrentRow.Index).Cells("USUARIO_CHOFER").Value = -666 Then
                        cboPiloto.SelectedValue = 0
                    Else
                        cboPiloto.SelectedValue = dgdListadoBuses.Rows(dgdListadoBuses.CurrentRow.Index).Cells("USUARIO_CHOFER").Value
                    End If
                Case 3
                    cboRuta.SelectedValue = 0
                    cboCiudadOrigen.SelectedValue = dgdListadoBuses.Rows(dgdListadoBuses.CurrentRow.Index).Cells("IDUNIDAD_AGENCIA_ORIGEN").Value
                    cboCiudadDestino.SelectedValue = dgdListadoBuses.Rows(dgdListadoBuses.CurrentRow.Index).Cells("IDUNIDAD_AGENCIA_DESTINO").Value
                    cboPiloto.SelectedValue = 0

                    txtRucTercero.Text = dgdListadoBuses.Rows(dgdListadoBuses.CurrentRow.Index).Cells("RUC_TERCERO").Value
                    txtEmpresaTercero.Text = dgdListadoBuses.Rows(dgdListadoBuses.CurrentRow.Index).Cells("NOM_TERCERO").Value
                    txtMarcaTercero.Text = dgdListadoBuses.Rows(dgdListadoBuses.CurrentRow.Index).Cells("MARCA_BUS").Value
                    txtPlacaTercero.Text = dgdListadoBuses.Rows(dgdListadoBuses.CurrentRow.Index).Cells("PLACA_BUS").Value
                    txtLicenciaTercero.Text = dgdListadoBuses.Rows(dgdListadoBuses.CurrentRow.Index).Cells("NRO_LICENCIA").Value
            End Select

            dtpFechaSalidaBus.Value = dgdListadoBuses.Rows(dgdListadoBuses.CurrentRow.Index).Cells("FECHA_SALIDA").Value
            dtpFechaLlegadaBus.Value = dgdListadoBuses.Rows(dgdListadoBuses.CurrentRow.Index).Cells("FECHA_LLEGADA").Value
            txtHoraSalida.Text = dgdListadoBuses.Rows(dgdListadoBuses.CurrentRow.Index).Cells("HORA_SALIDA").Value

            fncCrearColumnasCiudades()
            fncAgregarColumnasCiudades()

            objSalidaVehiculo.SalidaBus = dgdListadoBuses.Rows(dgdListadoBuses.CurrentRow.Index).Cells("NRO_SALIDA").Value

            If Not IsNothing(dtCiudadesViaje) Then
                dtCiudadesViaje = objSalidaVehiculo.fncListarRutaBus.Tables(0)
                dtCiudadesViaje.DefaultView.Sort = "KILOMETROS"
                dgdCiudades.DataSource = dtCiudadesViaje.DefaultView

                For Index As Integer = 0 To dtCiudadesViaje.Rows.Count - 1
                    If Convert.ToInt32(dtCiudadesViaje.Rows(Index).Item("DESTINO_FINAL").ToString) = 1 Then
                        lblDatoKilometro.Text = dtCiudadesViaje.Rows(Index).Item("KILOMETROS").ToString
                        Exit For
                    End If
                Next
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub fncCargarDatosGenerales()
        Try
            blnTodoOk = False
            dsDatosGenerales = objSalidaVehiculo.fncListarDatosGeneralesBuses

            lblDatoMarca.Text = ""
            lblDatoPlaca.Text = ""
            lblDatoLicencia.Text = ""

            If Not IsNothing(dsDatosGenerales) Then
                'Deben ser 4 table: 0 = Buses, 1 = Servicios, 2 = Rutas, 3 = Pilotos
                If dsDatosGenerales.Tables.Count > 0 Then
                    If dsDatosGenerales.Tables(0).Rows.Count > 0 Then
                        cboBus.DataSource = dsDatosGenerales.Tables(0)
                        cboBus.DisplayMember = "Nro_Unidad_Transporte"
                        cboBus.ValueMember = "IdUnidad_Transporte"
                        cboBus.SelectedIndex = 0
                    Else
                        MessageBox.Show("No existen buses registrados", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If

                    If dsDatosGenerales.Tables(1).Rows.Count > 0 Then
                        cboServicio.DataSource = dsDatosGenerales.Tables(1)
                        cboServicio.DisplayMember = "Tipo_Servicio"
                        cboServicio.ValueMember = "IdTipo_Servicio"
                        cboServicio.SelectedIndex = 0
                    Else
                        MessageBox.Show("No existen servicios para el bus seleccionado", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If

                    If dsDatosGenerales.Tables(2).Rows.Count > 0 Then
                        cboRuta.DataSource = dsDatosGenerales.Tables(2)
                        cboRuta.DisplayMember = "Nombre_Ruta"
                        cboRuta.ValueMember = "IdRutas"
                        cboRuta.SelectedIndex = 1
                    Else
                        MessageBox.Show("No existen rutas para el bus seleccionado", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If

                    If dsDatosGenerales.Tables(3).Rows.Count > 0 Then
                        cboPiloto.DataSource = dsDatosGenerales.Tables(3)
                        cboPiloto.DisplayMember = "Nombre"
                        cboPiloto.ValueMember = "IdUsuario_Personal"
                        cboPiloto.SelectedIndex = 0
                    Else
                        MessageBox.Show("No existen rutas para el bus seleccionado", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If
            End If

            dsCiudades = objSalidaVehiculo.fncListarUnidadOrigen()

            If Not IsNothing(dsCiudades) Then
                If dsCiudades.Tables(0).Rows.Count > 0 Then
                    dtCiudadOrigen = dsCiudades.Tables(0).Copy
                    dtCiudadDestino = dsCiudades.Tables(0).Copy
                    dtCiudadIntermedia = dsCiudades.Tables(0).Copy

                    cboCiudadOrigen.DataSource = dtCiudadOrigen
                    cboCiudadOrigen.DisplayMember = "Nombre_Unidad"
                    cboCiudadOrigen.ValueMember = "IdUnidad_Agencia"
                    cboCiudadOrigen.SelectedIndex = 0

                    cboCiudadDestino.DataSource = dtCiudadDestino
                    cboCiudadDestino.DisplayMember = "Nombre_Unidad"
                    cboCiudadDestino.ValueMember = "IdUnidad_Agencia"
                    cboCiudadDestino.SelectedIndex = 0

                    cboCiudadIntermedia.DataSource = dtCiudadIntermedia
                    cboCiudadIntermedia.DisplayMember = "Nombre_Unidad"
                    cboCiudadIntermedia.ValueMember = "IdUnidad_Agencia"
                    cboCiudadIntermedia.SelectedIndex = 0
                End If
            End If

            blnTodoOk = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub fncCrearColumnasCiudades()
        Try
            dtCiudadesViaje = New DataTable

            dcColumna = New DataColumn
            dcColumna.ColumnName = "SELECCION"
            dtCiudadesViaje.Columns.Add(dcColumna)

            dcColumna = New DataColumn
            dcColumna.ColumnName = "IDUNIDAD_AGENCIA_DESTINO"
            dtCiudadesViaje.Columns.Add(dcColumna)

            dcColumna = New DataColumn
            dcColumna.ColumnName = "DESTINO"
            dtCiudadesViaje.Columns.Add(dcColumna)

            dcColumna = New DataColumn
            dcColumna.ColumnName = "KILOMETROS"
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dtCiudadesViaje.Columns.Add(dcColumna)

            dcColumna = New DataColumn
            dcColumna.ColumnName = "FECHA_LLEGADA"
            dtCiudadesViaje.Columns.Add(dcColumna)

            dcColumna = New DataColumn
            dcColumna.ColumnName = "HORA_LLEGADA"
            dtCiudadesViaje.Columns.Add(dcColumna)

            dcColumna = New DataColumn
            dcColumna.ColumnName = "HORAS_VIAJE"
            dtCiudadesViaje.Columns.Add(dcColumna)

            dcColumna = New DataColumn
            dcColumna.ColumnName = "DESTINO_FINAL"
            dtCiudadesViaje.Columns.Add(dcColumna)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub fncAgregarColumnasCiudades()
        Try
            Dim Seleccione As New DataGridViewCheckBoxColumn
            With Seleccione
                .HeaderText = "SELECCION"
                .Name = "SELECCION"
                .DataPropertyName = "SELECCION"
                .ThreeState = False
                .TrueValue = True
                .FalseValue = False
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = False
            End With

            Dim IdUnidadAgenciaDestino As New DataGridViewTextBoxColumn
            With IdUnidadAgenciaDestino
                .HeaderText = "IDUNIDAD_AGENCIA_DESTINO"
                .Name = "IDUNIDAD_AGENCIA_DESTINO"
                .DataPropertyName = "IDUNIDAD_AGENCIA_DESTINO"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .Visible = False
            End With

            Dim UnidadAgenciaDestino As New DataGridViewTextBoxColumn
            With UnidadAgenciaDestino
                .HeaderText = "DESTINO"
                .Name = "DESTINO"
                .DataPropertyName = "DESTINO"
                .Width = 120
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
            End With

            Dim Kilometros As New DataGridViewTextBoxColumn
            With Kilometros
                .HeaderText = "KILOMETROS"
                .Name = "KILOMETROS"
                .DataPropertyName = "KILOMETROS"
                .Width = 90
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
            End With

            Dim FechaLlegada As New DataGridViewTextBoxColumn
            With FechaLlegada
                .HeaderText = "FECHA LLEGADA"
                .Name = "FECHA_LLEGADA"
                .DataPropertyName = "FECHA_LLEGADA"
                .Width = 120
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
            End With

            Dim HoraLlegada As New DataGridViewTextBoxColumn
            With HoraLlegada
                .HeaderText = "HORA LLEGADA"
                .Name = "HORA_LLEGADA"
                .DataPropertyName = "HORA_LLEGADA"
                .Width = 120
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
            End With

            Dim HorasViaje As New DataGridViewTextBoxColumn
            With HorasViaje
                .HeaderText = "HORAS DE VIAJE"
                .Name = "HORAS_VIAJE"
                .DataPropertyName = "HORAS_VIAJE"
                .Width = 115
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
            End With

            Dim DestinoFinal As New DataGridViewCheckBoxColumn
            With DestinoFinal
                .HeaderText = "DESTINO FINAL"
                .Name = "DESTINO_FINAL"
                .DataPropertyName = "DESTINO_FINAL"
                .Width = 100
                .ThreeState = False
                .TrueValue = True
                .FalseValue = False
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
            End With

            dgdCiudades.Columns.AddRange(Seleccione, IdUnidadAgenciaDestino, UnidadAgenciaDestino, Kilometros, FechaLlegada, HoraLlegada, HorasViaje, DestinoFinal)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgdListadoBuses_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles dgdListadoBuses.MouseDown
        Dim iEstado As Integer = 0
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                If Me.dgdListadoBuses.Rows.Count > 0 Then

                    iEstado = dgdListadoBuses.Rows(dgdListadoBuses.CurrentRow.Index).Cells("IDESTADO_REGISTRO").Value

                    Select Case iEstado
                        Case 73
                            TSMI_AperturaBodega.Enabled = False
                            TSMI_CierreBodega.Enabled = True
                        Case 39
                            TSMI_AperturaBodega.Enabled = True
                            TSMI_CierreBodega.Enabled = False
                        Case 35
                            TSMI_AperturaBodega.Enabled = False
                            TSMI_CierreBodega.Enabled = False
                        Case 36
                            TSMI_AperturaBodega.Enabled = False
                            TSMI_CierreBodega.Enabled = False
                        Case 37, 38
                            TSMI_AperturaBodega.Enabled = False
                            TSMI_CierreBodega.Enabled = False
                    End Select

                    CMSEstados.Show(sender, e.X, e.Y)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TSMI_AperturaBodega_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_AperturaBodega.Click
        Try
            objSalidaVehiculo.SalidaBus = dgdListadoBuses.Rows(dgdListadoBuses.CurrentRow.Index).Cells("NRO_SALIDA").Value
            objSalidaVehiculo.Estado = 73
            objSalidaVehiculo.fncActualizarEstadoBus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TSMI_CierreBodega_Click(sender As System.Object, e As System.EventArgs) Handles TSMI_CierreBodega.Click
        Try
            objSalidaVehiculo.SalidaBus = dgdListadoBuses.Rows(dgdListadoBuses.CurrentRow.Index).Cells("NRO_SALIDA").Value
            objSalidaVehiculo.Estado = 39
            objSalidaVehiculo.fncActualizarEstadoBus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '-------------------------------------------------------------------------------------------
    '------------------------ Pestaña de Generación de Salida de Buses  ------------------------
    '-------------------------------------------------------------------------------------------
    Private Sub CancelarToolStripmenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CancelarToolStripmenuItem.Click
        Try
            TCProgramacionBuses.Controls.RemoveAt(0)
            TCProgramacionBuses.TabPages.Add(TPListaBuses)
            NuevoToolStripMenuItem.Visible = True
            EdicionToolStripMenuItem.Visible = True
            AnularToolStripMenuItem.Visible = True
            GrabarToolStripMenuItem.Visible = False
            CancelarToolStripmenuItem.Visible = False

            fncLimpiarVariables()

            fncListarProgramacionBuses()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboBus_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboBus.SelectedIndexChanged
        Dim iTipoServicio As Integer = 0
        Try
            If blnTodoOk = True Then
                If Not IsNothing(dsDatosGenerales) Then

                    If dsDatosGenerales.Tables(1).Rows.Count > 0 Then
                        iTipoServicio = IIf(IsDBNull(dsDatosGenerales.Tables(0).Rows(cboBus.SelectedIndex).Item("IdTipo_Servicio")) = True, 0, Convert.ToInt32(dsDatosGenerales.Tables(0).Rows(cboBus.SelectedIndex).Item("IdTipo_Servicio").ToString))
                    End If

                    If iTipoServicio = cboServicio.SelectedValue Then
                        cboServicio.SelectedValue = iTipoServicio
                        Return
                    Else
                        cboServicio.SelectedValue = iTipoServicio
                    End If

                    Select Case cboServicio.SelectedValue
                        Case 4, 5, 6, 9, 10, 11 'El tipo de Servicio 4 = Presidencial, 5 = Premier, 6 = Clasico, 9 = Presidencial Cama, 10 = Presidencial 40, 11 = Tepsa Suite
                            cboRuta.SelectedValue = -1
                            cboRuta.Enabled = True

                            cboCiudadOrigen.SelectedValue = 0
                            cboCiudadOrigen.Enabled = False

                            cboCiudadDestino.SelectedValue = 0
                            cboCiudadDestino.Enabled = False

                            cboPiloto.Enabled = True

                            lblDatoMarca.Text = IIf(IsDBNull(dsDatosGenerales.Tables(0).Rows(cboBus.SelectedIndex).Item("Modelo_Movil")) = True, "", dsDatosGenerales.Tables(0).Rows(cboBus.SelectedIndex).Item("Modelo_Movil").ToString)
                            lblDatoPlaca.Text = IIf(IsDBNull(dsDatosGenerales.Tables(0).Rows(cboBus.SelectedIndex).Item("Placa")) = True, "", dsDatosGenerales.Tables(0).Rows(cboBus.SelectedIndex).Item("Placa").ToString)

                            txtRucTercero.Text = ""
                            txtEmpresaTercero.Text = ""
                            txtMarcaTercero.Text = ""
                            txtPlacaTercero.Text = ""
                            txtLicenciaTercero.Text = ""

                            txtRucTercero.Enabled = False
                            txtEmpresaTercero.Enabled = False
                            txtMarcaTercero.Enabled = False
                            txtPlacaTercero.Enabled = False
                            txtLicenciaTercero.Enabled = False

                            cboRuta.Focus()

                        Case 2 'El tipo de Servicio 2 = Carguero
                            cboRuta.SelectedValue = 0
                            cboRuta.Enabled = False

                            cboCiudadOrigen.SelectedValue = dtoUSUARIOS.m_idciudad
                            cboCiudadOrigen.Enabled = True

                            cboCiudadDestino.SelectedValue = 0
                            cboCiudadDestino.Enabled = True

                            cboPiloto.Enabled = True

                            lblDatoMarca.Text = IIf(IsDBNull(dsDatosGenerales.Tables(0).Rows(cboBus.SelectedIndex).Item("Modelo_Movil")) = True, "", dsDatosGenerales.Tables(0).Rows(cboBus.SelectedIndex).Item("Modelo_Movil").ToString)
                            lblDatoPlaca.Text = IIf(IsDBNull(dsDatosGenerales.Tables(0).Rows(cboBus.SelectedIndex).Item("Placa")) = True, "", dsDatosGenerales.Tables(0).Rows(cboBus.SelectedIndex).Item("Placa").ToString)

                            txtRucTercero.Text = ""
                            txtEmpresaTercero.Text = ""
                            txtMarcaTercero.Text = ""
                            txtPlacaTercero.Text = ""
                            txtLicenciaTercero.Text = ""

                            txtRucTercero.Enabled = False
                            txtEmpresaTercero.Enabled = False
                            txtMarcaTercero.Enabled = False
                            txtPlacaTercero.Enabled = False
                            txtLicenciaTercero.Enabled = False

                            cboRuta.Focus()

                        Case 3 'El tipo de Servicio 3 = Tercero
                            cboRuta.SelectedValue = 0
                            cboRuta.Enabled = False

                            cboCiudadOrigen.SelectedValue = dtoUSUARIOS.m_idciudad
                            cboCiudadOrigen.Enabled = True

                            cboCiudadDestino.SelectedValue = 0
                            cboCiudadDestino.Enabled = True

                            cboPiloto.SelectedValue = 0
                            cboPiloto.Enabled = False

                            lblDatoMarca.Text = ""
                            lblDatoPlaca.Text = ""

                            txtRucTercero.Enabled = True
                            txtEmpresaTercero.Enabled = True
                            txtMarcaTercero.Enabled = True
                            txtPlacaTercero.Enabled = True
                            txtLicenciaTercero.Enabled = True

                            txtRucTercero.Focus()
                    End Select

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboRuta_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboRuta.SelectedIndexChanged
        Try
            If blnTodoOk = True Then
                If Not IsNothing(dsDatosGenerales) Then

                    If dsDatosGenerales.Tables(2).Rows.Count > 0 Then
                        txtHoraSalida.Text = IIf(IsDBNull(dsDatosGenerales.Tables(2).Rows(cboRuta.SelectedIndex).Item("hora")) = True, "00:00", dsDatosGenerales.Tables(2).Rows(cboRuta.SelectedIndex).Item("hora").ToString)
                        cboCiudadOrigen.SelectedValue = IIf(IsDBNull(dsDatosGenerales.Tables(2).Rows(cboRuta.SelectedIndex).Item("IdUnidad_Agencia")) = True, 0, Convert.ToInt32(dsDatosGenerales.Tables(2).Rows(cboRuta.SelectedIndex).Item("IdUnidad_Agencia").ToString))
                        cboCiudadDestino.SelectedValue = IIf(IsDBNull(dsDatosGenerales.Tables(2).Rows(cboRuta.SelectedIndex).Item("IdUnidad_Agencia_Destino")) = True, 0, Convert.ToInt32(dsDatosGenerales.Tables(2).Rows(cboRuta.SelectedIndex).Item("IdUnidad_Agencia_Destino").ToString))
                    End If

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dtpFechaLlegadaBus_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaLlegadaBus.ValueChanged
        Try
            If dtpFechaLlegadaBus.Value.Date < dtpFechaSalidaBus.Value.Date Then
                MessageBox.Show("La fecha de llegada del bus no puede ser menor a la fecha de salida del bus", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                dtpFechaLlegadaBus.Value = Date.Now
            End If

            If cboCiudadDestino.Text.Trim <> "(SELECCIONE)" Then
                If Not IsNothing(dtCiudadesViaje) Then
                    If dtCiudadesViaje.Rows.Count > 0 Then
                        For Index As Integer = 0 To dtCiudadesViaje.Rows.Count - 1
                            If Convert.ToBoolean(dtCiudadesViaje.Rows(Index).Item("DESTINO_FINAL").ToString) = True Then
                                dtCiudadesViaje.Rows(Index).Item("FECHA_LLEGADA") = dtpFechaLlegadaBus.Value.ToShortDateString
                                dtCiudadesViaje.Rows(Index).Item("HORA_LLEGADA") = txtHoraSalida.Text

                                dgdCiudades.Columns.Clear()
                                fncAgregarColumnasCiudades()
                                dgdCiudades.DataSource = dtCiudadesViaje
                            End If
                        Next
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboCiudadDestino_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCiudadDestino.SelectedIndexChanged
        Dim blnKMEncontrado = False
        Dim dsKm As DataSet
        Try
            If blnTodoOk = True Then

                If cboCiudadOrigen.SelectedValue = cboCiudadDestino.SelectedValue And cboCiudadOrigen.Text.Trim <> "(SELECCIONE)" And cboCiudadDestino.Text.Trim <> "(SELECCIONE)" Then
                    MessageBox.Show("La ciudad de destino no puede ser igual a la ciudad de origen", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    dtCiudadesViaje.Rows.Clear()
                    dgdCiudades.Columns.Clear()
                    fncAgregarColumnasCiudades()
                    Return
                End If

                If Not IsNothing(dtCiudadesViaje) Then
                    If dtCiudadesViaje.Rows.Count >= 0 Then
                        If cboCiudadDestino.Text.Trim <> "(SELECCIONE)" Then
                            dtCiudadesViaje.Rows.Clear()

                            drFila = dtCiudadesViaje.NewRow
                            drFila("SELECCION") = False
                            drFila("IDUNIDAD_AGENCIA_DESTINO") = cboCiudadDestino.SelectedValue
                            drFila("DESTINO") = cboCiudadDestino.Text

                            If cboCiudadDestino.Enabled = False Then
                                If IsDBNull(dsDatosGenerales.Tables(2).Rows(cboRuta.SelectedIndex).Item("Nrokilometros")) = True Then
                                    drFila("KILOMETROS") = "0.00"
                                Else
                                    drFila("KILOMETROS") = Convert.ToDouble(dsDatosGenerales.Tables(2).Rows(cboRuta.SelectedIndex).Item("Nrokilometros").ToString)
                                End If

                                If IsDBNull(dsDatosGenerales.Tables(2).Rows(cboRuta.SelectedIndex).Item("Horas_De_Viaje")) = True Then
                                    drFila("HORAS_VIAJE") = "00:00"
                                Else
                                    drFila("HORAS_VIAJE") = dsDatosGenerales.Tables(2).Rows(cboRuta.SelectedIndex).Item("Horas_De_Viaje").ToString
                                End If
                            ElseIf cboCiudadDestino.Enabled = True Then
                                For Index As Integer = 0 To dsDatosGenerales.Tables(2).Rows.Count - 1
                                    If cboCiudadOrigen.Text & "-" & cboCiudadDestino.Text = dsDatosGenerales.Tables(2).Rows(Index).Item("Nombre_Ruta").ToString.Substring(0, dsDatosGenerales.Tables(2).Rows(Index).Item("Nombre_Ruta").ToString.Length - 9).Trim Then
                                        If IsDBNull(dsDatosGenerales.Tables(2).Rows(Index).Item("Nrokilometros")) = True Then
                                            drFila("KILOMETROS") = "0.00"
                                        Else
                                            drFila("KILOMETROS") = Convert.ToDouble(dsDatosGenerales.Tables(2).Rows(Index).Item("Nrokilometros").ToString)
                                        End If

                                        If IsDBNull(dsDatosGenerales.Tables(2).Rows(Index).Item("Horas_De_Viaje")) = True Then
                                            drFila("HORAS_VIAJE") = "00:00"
                                        Else
                                            drFila("HORAS_VIAJE") = dsDatosGenerales.Tables(2).Rows(Index).Item("Horas_De_Viaje").ToString
                                        End If

                                        blnKMEncontrado = True
                                        Exit For
                                    End If
                                Next

                                If blnKMEncontrado = False Then
                                    objSalidaVehiculo.UnidadAgenciaDestino = cboCiudadDestino.SelectedValue
                                    dsKm = objSalidaVehiculo.fncObtenerKilometroHoraViaje

                                    If Not IsNothing(dsKm) Then
                                        If dsKm.Tables(0).Rows.Count = 1 Then
                                            drFila("KILOMETROS") = Convert.ToDouble(dsKm.Tables(0).Rows(0).Item("Nrokilometros").ToString)
                                            drFila("HORAS_VIAJE") = dsKm.Tables(0).Rows(0).Item("Horas_De_Viaje").ToString
                                        End If
                                    End If

                                End If
                            End If

                            drFila("FECHA_LLEGADA") = dtpFechaLlegadaBus.Value.ToShortDateString
                            drFila("HORA_LLEGADA") = txtHoraSalida.Text
                            drFila("DESTINO_FINAL") = True

                            dtCiudadesViaje.Rows.Add(drFila)

                            If Not IsNothing(dtCiudadesViaje) Then
                                If dtCiudadesViaje.Rows.Count > 0 Then
                                    dgdCiudades.Columns.Clear()
                                    fncAgregarColumnasCiudades()
                                    dgdCiudades.DataSource = dtCiudadesViaje
                                End If
                            End If

                            lblDatoKilometro.Text = dtCiudadesViaje.Rows(0).Item("Kilometros").ToString
                        Else
                            dtCiudadesViaje.Rows.Clear()
                            dgdCiudades.Columns.Clear()
                            fncAgregarColumnasCiudades()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboPiloto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPiloto.SelectedIndexChanged
        Try
            If blnTodoOk = True Then
                If Not IsNothing(dsDatosGenerales) Then

                    If dsDatosGenerales.Tables(3).Rows.Count > 0 Then
                        lblDatoLicencia.Text = IIf(IsDBNull(dsDatosGenerales.Tables(3).Rows(cboPiloto.SelectedIndex).Item("Nro_Licencia")) = True, 0, dsDatosGenerales.Tables(3).Rows(cboPiloto.SelectedIndex).Item("Nro_Licencia").ToString)
                    End If

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Dim blnKMEncontrado = False
        Dim dsKm As DataSet
        Dim dvCiudad As DataView
        Try
            If dtCiudadesViaje.Rows.Count = 0 Then
                MessageBox.Show("Debe de agregar el destino final antes de las ciudades intermedias del recorrdio del bus", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Return
            End If

            If dtCiudadesViaje.Rows.Count > 0 Then
                For Index As Integer = 0 To dtCiudadesViaje.Rows.Count - 1
                    If dtCiudadesViaje.Rows(Index).Item("DESTINO").ToString = cboCiudadIntermedia.Text Then
                        MessageBox.Show("La ciudad de " & cboCiudadIntermedia.Text & " ya es parte del recorrido del bus seleccione otra ciudad", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Return
                    End If
                Next
            End If

            drFila = dtCiudadesViaje.NewRow
            drFila("SELECCION") = False
            drFila("IDUNIDAD_AGENCIA_DESTINO") = cboCiudadIntermedia.SelectedValue
            drFila("DESTINO") = cboCiudadIntermedia.Text

            For Index As Integer = 0 To dsDatosGenerales.Tables(2).Rows.Count - 1
                If cboCiudadOrigen.Text & "-" & cboCiudadIntermedia.Text = dsDatosGenerales.Tables(2).Rows(Index).Item("Nombre_Ruta").ToString.Substring(0, dsDatosGenerales.Tables(2).Rows(Index).Item("Nombre_Ruta").ToString.Length - 9).Trim Then
                    If IsDBNull(dsDatosGenerales.Tables(2).Rows(Index).Item("Nrokilometros")) = True Then
                        drFila("KILOMETROS") = "0.00"
                    Else
                        drFila("KILOMETROS") = Convert.ToDouble(dsDatosGenerales.Tables(2).Rows(Index).Item("Nrokilometros").ToString)
                    End If

                    If IsDBNull(dsDatosGenerales.Tables(2).Rows(Index).Item("Horas_De_Viaje")) = True Then
                        drFila("HORAS_VIAJE") = "00:00"
                    Else
                        drFila("HORAS_VIAJE") = dsDatosGenerales.Tables(2).Rows(Index).Item("Horas_De_Viaje").ToString
                    End If

                    blnKMEncontrado = True
                    Exit For
                End If
            Next

            If blnKMEncontrado = False Then
                objSalidaVehiculo.UnidadAgenciaDestino = cboCiudadIntermedia.SelectedValue
                dsKm = objSalidaVehiculo.fncObtenerKilometroHoraViaje

                If Not IsNothing(dsKm) Then
                    If dsKm.Tables(0).Rows.Count = 1 Then
                        drFila("KILOMETROS") = Convert.ToDouble(dsKm.Tables(0).Rows(0).Item("Nrokilometros").ToString)
                        drFila("HORAS_VIAJE") = dsKm.Tables(0).Rows(0).Item("Horas_De_Viaje").ToString
                    End If
                End If

            End If

            drFila("FECHA_LLEGADA") = dtpFechaLlegadaBus.Value.ToShortDateString
            drFila("HORA_LLEGADA") = txtHoraSalida.Text
            drFila("DESTINO_FINAL") = False

            dtCiudadesViaje.Rows.Add(drFila)

            If Not IsNothing(dtCiudadesViaje) Then
                If dtCiudadesViaje.Rows.Count > 0 Then
                    dgdCiudades.Columns.Clear()
                    fncAgregarColumnasCiudades()
                    dtCiudadesViaje.DefaultView.Sort = "KILOMETROS"
                    dgdCiudades.DataSource = dtCiudadesViaje.DefaultView
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnQuitar_Click(sender As System.Object, e As System.EventArgs) Handles btnQuitar.Click
        Dim dtCopiaCiudadesViaje As DataTable
        Try
            dtCopiaCiudadesViaje = dtCiudadesViaje.Copy

            For IndexGrid As Integer = 0 To dtCopiaCiudadesViaje.Rows.Count - 1
                If Convert.ToBoolean(dtCopiaCiudadesViaje.Rows(IndexGrid).Item("SELECCION")) = True And Convert.ToBoolean(dtCopiaCiudadesViaje.Rows(IndexGrid).Item("DESTINO_FINAL")) = False Then
                    For IndexTabla As Integer = 0 To dtCiudadesViaje.Rows.Count - 1
                        If dtCiudadesViaje.Rows(IndexTabla).Item("DESTINO").ToString.Trim = dtCopiaCiudadesViaje.Rows(IndexGrid).Item("DESTINO").ToString.Trim Then
                            dtCiudadesViaje.Rows.RemoveAt(IndexTabla)
                            Exit For
                        End If
                    Next
                ElseIf Convert.ToBoolean(dtCopiaCiudadesViaje.Rows(IndexGrid).Item("SELECCION")) = True And Convert.ToBoolean(dtCopiaCiudadesViaje.Rows(IndexGrid).Item("DESTINO_FINAL")) = True Then
                    MessageBox.Show("El destino final del recorrido del bus no se puede eliminar, solo se cambia de destino cuando:" & vbCrLf & "1. Seleccionar una nueva ruta" & vbCrLf & "2. Cambie de bus y tipo de servicio", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            Next

            If Not IsNothing(dtCiudadesViaje) Then
                If dtCiudadesViaje.Rows.Count > 0 Then
                    dgdCiudades.Columns.Clear()
                    fncAgregarColumnasCiudades()
                    dtCiudadesViaje.DefaultView.Sort = "KILOMETROS"
                    dgdCiudades.DataSource = dtCiudadesViaje.DefaultView
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GrabarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GrabarToolStripMenuItem.Click
        Dim dsNroSalida As DataSet = Nothing
        Dim dsRutaCiudad As DataSet = Nothing
        Try
            If cboBus.Text.Trim.ToUpper = "(SELECCIONE)" Then
                MessageBox.Show("Seleccione el bus para generar la programación del bus", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                cboBus.Focus()
                Return
            End If

            If cboServicio.Text.Trim.ToUpper = "(SELECCIONE)" Then
                MessageBox.Show("El bus seleccionado no tiene tipo de servicio, verifique el tipo de servicio", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                cboBus.Focus()
                Return
            End If

            Select Case cboServicio.SelectedValue
                Case 4, 5, 6, 9, 10, 11
                    If cboRuta.Text.Trim.ToUpper = "(SELECCIONE)" Or cboRuta.Text.Trim.ToUpper = "RUTA NO ESTABLECIDA" Then
                        MessageBox.Show("Seleccione la ruta para generar la programación del bus", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        cboRuta.Focus()
                        Return
                    ElseIf cboPiloto.Text.Trim.ToUpper = "(SELECCIONE)" Then
                        MessageBox.Show("Seleccione el piloto para generar la programación del bus", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        cboPiloto.Focus()
                        Return
                    End If
                Case 2
                    If cboPiloto.Text.Trim.ToUpper = "(SELECCIONE)" Then
                        MessageBox.Show("Seleccione el piloto para generar la programación del bus", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        cboPiloto.Focus()
                        Return
                    ElseIf cboCiudadOrigen.Text.Trim.ToUpper = "(SELECCIONE)" Then
                        MessageBox.Show("Debe elegir la ciudad origen para generar la programación del bus", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        cboCiudadOrigen.Focus()
                        Return
                    ElseIf cboCiudadDestino.Text.Trim.ToUpper = "(SELECCIONE)" Then
                        MessageBox.Show("Debe elegir la ciudad destino para generar la programación del bus", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        cboCiudadDestino.Focus()
                        Return
                    End If
                Case 3
                    If cboCiudadOrigen.Text.Trim.ToUpper = "(SELECCIONE)" Then
                        MessageBox.Show("Debe elegir la ciudad origen para generar la programación del bus", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        cboCiudadOrigen.Focus()
                        Return
                    ElseIf cboCiudadDestino.Text.Trim.ToUpper = "(SELECCIONE)" Then
                        MessageBox.Show("Debe elegir la ciudad destino para generar la programación del bus", "Salida Vehículo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        cboCiudadDestino.Focus()
                        Return
                    End If
            End Select

            'Validación de la hora de partida de los buses
            If Mid(Trim(txtHoraSalida.Text), 1, 2) > "23" Or Mid(Trim(txtHoraSalida.Text), 4, 2) > "59" Then
                MessageBox.Show("Hora Incorrecta.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtHoraSalida.Focus()
                Exit Sub
            ElseIf Mid(Trim(txtHoraSalida.Text), 1, 2) > "23" Or Mid(Trim(txtHoraSalida.Text), 4, 2) = "" Then
                MessageBox.Show("Hora Incorrecta.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtHoraSalida.Focus()
                Exit Sub
            ElseIf Val(Mid(Trim(txtHoraSalida.Text), 1, 2)) & Val(Mid(Trim(txtHoraSalida.Text), 4, 2)) = 0 Then
                txtHoraSalida.Text = "00:00"
            Else
                txtHoraSalida.Text = Long.Parse(Mid(Trim(txtHoraSalida.Text), 1, 2)).ToString("00") & ":" & Long.Parse(Mid(Trim(txtHoraSalida.Text), 4, 2)).ToString("00")
            End If

            'Variables para Insertar la programación del bus
            'Unidad Transporte
            objSalidaVehiculo.UnidadTransporte = cboBus.SelectedValue

            'Ruta de bus
            If cboRuta.SelectedValue = 0 Then
                objSalidaVehiculo.RutaHorario = -666 'Cuando no Existe una ruta horario
            Else
                objSalidaVehiculo.RutaHorario = cboRuta.SelectedValue 'Cuando se selecciona una ruta horario
            End If

            'Fecha y Hora de Salida
            objSalidaVehiculo.FechaSalida = dtpFechaSalidaBus.Value.ToShortDateString
            objSalidaVehiculo.HoraSalida = txtHoraSalida.Text

            'Tipo de Servicio del bus
            objSalidaVehiculo.TipoServicio = cboServicio.SelectedValue

            'Ciudad de Origen y Destino del Bus
            objSalidaVehiculo.UnidadAgenciaOrigen = cboCiudadOrigen.SelectedValue
            objSalidaVehiculo.UnidadAgenciaDestino = cboCiudadDestino.SelectedValue

            'Piloto del Bus
            Select Case cboServicio.SelectedValue
                Case 2, 4, 5, 6, 9, 10, 11
                    'Datos del Piloto y Bus de Tepsa
                    objSalidaVehiculo.UsuarioChofer = cboPiloto.SelectedValue
                    objSalidaVehiculo.NombreTercero = "Null"
                    objSalidaVehiculo.RucTercero = "Null"
                    objSalidaVehiculo.NumeroLicencia = lblDatoLicencia.Text.Trim
                    objSalidaVehiculo.MarcaBus = lblDatoMarca.Text.Trim
                    objSalidaVehiculo.PlacaBus = lblDatoPlaca.Text.Trim
                Case 3
                    'Datos del Tercero
                    objSalidaVehiculo.UsuarioChofer = -666
                    objSalidaVehiculo.NombreTercero = txtEmpresaTercero.Text.Trim
                    objSalidaVehiculo.RucTercero = txtRucTercero.Text.Trim
                    objSalidaVehiculo.NumeroLicencia = txtLicenciaTercero.Text.Trim
                    objSalidaVehiculo.MarcaBus = txtMarcaTercero.Text.Trim
                    objSalidaVehiculo.PlacaBus = txtPlacaTercero.Text.Trim
            End Select

            'Fecha de Llegada
            objSalidaVehiculo.FechaLlegada = dtpFechaLlegadaBus.Value.ToShortDateString

            'Kilometros de recorrido de la ruta y margen de horas
            objSalidaVehiculo.MargenError = lblDatoMargen.Text.Trim
            objSalidaVehiculo.Kilometros = lblDatoKilometro.Text.Trim

            'Insertar la programacion del bus para el despacho de la carga
            If objSalidaVehiculo.Operacion = 1 Then
                objSalidaVehiculo.SalidaBus = 0
                dsNroSalida = objSalidaVehiculo.fncInsertarProgramacionBus()

                If Not IsNothing(dsNroSalida) Then
                    If dsNroSalida.Tables(0).Rows.Count = 1 Then
                        If Convert.ToInt32(dsNroSalida.Tables(0).Rows(0).Item("Codigo").ToString) <> 1 Then
                            MessageBox.Show(dsNroSalida.Tables(0).Rows(0).Item("Mensaje").ToString, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Return
                        End If

                        objSalidaVehiculo.SalidaBus = Convert.ToInt32(dsNroSalida.Tables(0).Rows(0).Item("IdProgramacion").ToString)

                        For Index As Integer = 0 To dtCiudadesViaje.Rows.Count - 1
                            objSalidaVehiculo.UnidadAgenciaDestino = Convert.ToInt32(dtCiudadesViaje.Rows(Index).Item("IDUNIDAD_AGENCIA_DESTINO").ToString)
                            If Convert.ToBoolean(dtCiudadesViaje.Rows(Index).Item("DESTINO_FINAL").ToString) = True Then
                                objSalidaVehiculo.AgenciaFinal = 1
                            Else
                                objSalidaVehiculo.AgenciaFinal = 0
                            End If
                            objSalidaVehiculo.MargenError = lblDatoMargen.Text.Trim
                            objSalidaVehiculo.Kilometros = Convert.ToInt32(dtCiudadesViaje.Rows(Index).Item("KILOMETROS").ToString)
                            objSalidaVehiculo.HorasViaje = dtCiudadesViaje.Rows(Index).Item("HORAS_VIAJE").ToString
                            dsRutaCiudad = objSalidaVehiculo.fncInsertarDestinoBus()
                        Next

                        If Not IsNothing(dsRutaCiudad) Then
                            If dsRutaCiudad.Tables(0).Rows.Count = 1 Then
                                MessageBox.Show(dsRutaCiudad.Tables(0).Rows(0).Item("Mensaje").ToString, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                fncLimpiarVariables()
                                cboBus.Focus()
                            End If
                        End If
                    End If
                End If
            ElseIf objSalidaVehiculo.Operacion = 2 Then
                Dim dsCiudadGuia As DataSet = Nothing
                Dim strMensaje As String = String.Empty
                Dim blnCiudadEncontrada As Boolean = False
                Dim blnMostarMensaje As Boolean = False

                'Obtiene las Ciudades de las Guias de Transportista asociadas a la Salida del Bus
                dsCiudadGuia = objSalidaVehiculo.fncListarCiudadesGuiaTransportista()

                If Not IsNothing(dsCiudadGuia) Then
                    If dsCiudadGuia.Tables(0).Rows.Count > 0 Then
                        'Verificar si las ciudades de las rutas son las mismas
                        For IndexCiudad As Integer = 0 To dsCiudadGuia.Tables(0).Rows.Count - 1

                            blnCiudadEncontrada = False
                            For Index As Integer = 0 To dtCiudadesViaje.Rows.Count - 1
                                If Convert.ToInt32(dsCiudadGuia.Tables(0).Rows(IndexCiudad).Item("IdUnidad_Agencia_Destino").ToString) = Convert.ToInt32(dtCiudadesViaje.Rows(Index).Item("IdUnidad_Agencia_Destino").ToString) Then
                                    blnCiudadEncontrada = True
                                    Exit For
                                End If
                            Next

                            If blnCiudadEncontrada = False Then
                                If strMensaje = "" Then
                                    strMensaje = "- " & dsCiudadGuia.Tables(0).Rows(IndexCiudad).Item("Nombre_Unidad").ToString
                                Else
                                    strMensaje = strMensaje & vbCrLf & "- " & dsCiudadGuia.Tables(0).Rows(IndexCiudad).Item("Nombre_Unidad").ToString
                                End If
                                blnMostarMensaje = True
                            End If
                        Next

                        If blnMostarMensaje = True Then
                            MessageBox.Show("No se puede actualizar la programación del bus, porque existen guías de transportista para los siguientes destinos: " & vbCrLf & vbCrLf & strMensaje & vbCrLf & vbCrLf & "que no estan considerados en la nueva programación de la ruta", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Return
                        End If
                    End If
                End If

                dsNroSalida = objSalidaVehiculo.fncInsertarProgramacionBus()

                If Not IsNothing(dsNroSalida) Then
                    If dsNroSalida.Tables(0).Rows.Count = 1 Then

                        If Convert.ToInt32(dsNroSalida.Tables(0).Rows(0).Item("Codigo").ToString) <> 1 Then
                            MessageBox.Show(dsNroSalida.Tables(0).Rows(0).Item("Mensaje").ToString, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Return
                        End If

                        For Index As Integer = 0 To dtCiudadesViaje.Rows.Count - 1
                            objSalidaVehiculo.UnidadAgenciaDestino = Convert.ToInt32(dtCiudadesViaje.Rows(Index).Item("IDUNIDAD_AGENCIA_DESTINO").ToString)
                            If Convert.ToBoolean(dtCiudadesViaje.Rows(Index).Item("DESTINO_FINAL")) = True Then
                                objSalidaVehiculo.AgenciaFinal = 1
                            Else
                                objSalidaVehiculo.AgenciaFinal = 0
                            End If
                            objSalidaVehiculo.MargenError = lblDatoMargen.Text.Trim
                            objSalidaVehiculo.Kilometros = Convert.ToInt32(dtCiudadesViaje.Rows(Index).Item("KILOMETROS").ToString)
                            objSalidaVehiculo.HorasViaje = dtCiudadesViaje.Rows(Index).Item("HORAS_VIAJE").ToString
                            dsRutaCiudad = objSalidaVehiculo.fncInsertarDestinoBus()
                        Next

                        If Not IsNothing(dsRutaCiudad) Then
                            If dsRutaCiudad.Tables(0).Rows.Count = 1 Then
                                MessageBox.Show(dsRutaCiudad.Tables(0).Rows(0).Item("Mensaje").ToString, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                fncLimpiarVariables()
                                CancelarToolStripmenuItem_Click(sender, e)
                            End If
                        End If

                    End If
                End If


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub fncLimpiarVariables()
        objSalidaVehiculo.UnidadTransporte = 0
        objSalidaVehiculo.RutaHorario = 0
        objSalidaVehiculo.FechaSalida = ""
        objSalidaVehiculo.HoraSalida = ""
        objSalidaVehiculo.TipoServicio = 0
        objSalidaVehiculo.UnidadAgenciaOrigen = 0
        objSalidaVehiculo.UnidadAgenciaDestino = 0
        objSalidaVehiculo.UsuarioChofer = 0
        objSalidaVehiculo.NombreTercero = ""
        objSalidaVehiculo.RucTercero = ""
        objSalidaVehiculo.NumeroLicencia = ""
        objSalidaVehiculo.MarcaBus = ""
        objSalidaVehiculo.PlacaBus = ""
        objSalidaVehiculo.FechaLlegada = ""
        objSalidaVehiculo.MargenError = ""
        objSalidaVehiculo.Kilometros = 0
        objSalidaVehiculo.SalidaBus = 0
        objSalidaVehiculo.AgenciaFinal = 0
        objSalidaVehiculo.HorasViaje = ""
        dgdCiudades.DataSource = Nothing
        dtCiudadesViaje = Nothing

        blnTodoOk = False

        cboBus.SelectedIndex = 0
        cboServicio.SelectedIndex = 0
        cboRuta.SelectedIndex = 1
        cboPiloto.SelectedIndex = 0
        cboCiudadOrigen.SelectedIndex = 0
        cboCiudadDestino.SelectedIndex = 0
        cboCiudadIntermedia.SelectedIndex = 0

        objSalidaVehiculo.UnidadAgenciaOrigen = cboUnidadAgenciaOrigen.SelectedValue
        objSalidaVehiculo.FechaSalida = dtpFechaSalida.Value.ToShortDateString
    End Sub

    




End Class