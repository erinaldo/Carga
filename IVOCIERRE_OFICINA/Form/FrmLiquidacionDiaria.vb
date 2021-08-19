Imports System.Data.Odbc
Imports INTEGRACION_LN

Public Class FrmLiquidacionDiaria

    Property hnd As Long
    Dim IDLiquidacionOficina As Integer
    Dim dtCounter As DataTable
    Dim dtCounter3 As DataTable
    Dim DTCounterCargaDesasociadas As DataTable
    Dim dtCounterCargaAsociadas As DataTable
    Dim TabGastos As TabPage
    Dim bAperturado As Boolean
    Dim bEliminar As Boolean = False


    '--> 17/01/2014 - jabanto
    Dim liquidacionSisvyr As New dtoLiquiOficinaSisVyr
    Dim IDLIQUIDACION As Integer = 0
    Dim idAgencia As Integer = ObtieneTipoDocumento(dtoUSUARIOS.iIDAGENCIAS)
    Dim fechaLiquidacion As String
    Dim ds As DataSet

    'hlamas 03-05-2018
    Dim intLlamada As Integer = 0
    Dim dtCaja As DataTable

    Private Sub FrmLiquidacionDiaria_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            '--->04/01/2017 - jabanto
            For i As Integer = 0 To LstPasajes2.Items.Count() - 1
                '**
                Dim drv As DataRowView = LstPasajes2.Items(i)
                Dim login As String = drv.Item(4).ToString
                Dim obj As New dtoCierreOficina
                obj.OficinaXUsuariosPasajes(2, IDLiquidacionOficina, login, 0, 0, 0, _
                       0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, dtoUSUARIOS.m_iIdAgencia, 0)
                '**
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmLiquidacionDiaria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LimpiarCerrar()

            '-->Valida si la agencia tiene asociado el codigo de agencia del sisvyr - 22/01/2014 jabanto
            If String.IsNullOrEmpty(dtoUSUARIOS.codAgenciaSisvyr) Then
                MessageBox.Show("La Agencia no tiene asociado el código de la Agencia del sisvyr", "Liquidación Oficina", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                Exit Sub
            End If

            Me.Cursor = Cursors.AppStarting
            FormateardgvComprobanteCierre()

            Dim obj As New dtoCierreOficina
            ds = obj.Inicio(dtoUSUARIOS.IdLogin, dtoUSUARIOS.iIDAGENCIAS, dtoUSUARIOS.m_sFecha, 1)

            If ds.Tables(0).Rows.Count > 0 Then
                fechaLiquidacion = ds.Tables(0).DefaultView.Item(0).Row(1)

                TabLiquidacion.Enabled = True
                IDLiquidacionOficina = ds.Tables(0).Rows(0)("ID_Oficina_Liquidacion").ToString()
                LblCodLiquidacion.Text = IDLiquidacionOficina
                LblFecha.Text = ds.Tables(0).Rows(0)("Fecha_Apertura")
                LblEstado.Text = "ABIERTA"

                With Me.CboTipoMovimiento
                    .DataSource = ds.Tables(1)
                    .DisplayMember = "Movimiento"
                    .ValueMember = "IDTipoMovimiento"
                    .SelectedValue = 0
                End With

                With Me.CboDestino
                    .DataSource = ds.Tables(2)
                    .DisplayMember = "NOMBRE_UNIDAD"
                    .ValueMember = "IDUNIDAD_AGENCIA"
                    .SelectedValue = 0
                End With

                With Me.CboPiloto
                    .DataSource = ds.Tables(3)
                    .DisplayMember = "nombre"
                    .ValueMember = "idusuario_personal"
                    .SelectedValue = 0
                End With

                With Me.cboCaja
                    .DataSource = ds.Tables(5)
                    .DisplayMember = "usuario"
                    .ValueMember = "id"
                    .SelectedValue = 0
                End With

                With Me.DgvGastosLiquidacion
                    Me.FormatoDgvGastosLiquidacion()
                    .DataSource = ds.Tables(6)
                End With

                'Carga
                '*****************
                LblTotalPagoCargaTarjVISA.Text = ds.Tables(8).Rows(0)("VISA")
                LblTotalPagoCargaTarjMASTER.Text = ds.Tables(8).Rows(0)("MASTERCARD")
                'Pasaje
                '******************
                LblPagoPasajesTarjVISA.Text = ds.Tables(8).Rows(0)("TARJETA_VISA_PASAJE")
                LblPagoPasajesTarjMASTER.Text = ds.Tables(8).Rows(0)("TARJETA_MASTER_PASAJE")
                '******************
                LblTotalDevoCarga.Text = IIf(IsDBNull(ds.Tables(7).Rows(0)("DEVOLUCION_DE_CARGA")), 0, ds.Tables(7).Rows(0)("DEVOLUCION_DE_CARGA")) 'ID:1
                LblTotalOtrosIngresos.Text = IIf(IsDBNull(ds.Tables(7).Rows(0)("TOTAL_OTROS_INGRESOS")), 0, ds.Tables(7).Rows(0)("TOTAL_OTROS_INGRESOS")) 'ID:2
                TotalGastosReciboCaja.Text = IIf(IsDBNull(ds.Tables(7).Rows(0)("GASTOS_CON_RECIBO_DE_CAJA")), 0, ds.Tables(7).Rows(0)("GASTOS_CON_RECIBO_DE_CAJA")) 'ID:3
                lblPagoPeajeFueraDelCounter.Text = IIf(IsDBNull(ds.Tables(7).Rows(0)("PAGO_PEAJE_FUERA_DEL_COUNT")), 0, ds.Tables(7).Rows(0)("PAGO_PEAJE_FUERA_DEL_COUNT")) 'ID:6
                LblTotalTranfBancaria.Text = IIf(IsDBNull(ds.Tables(7).Rows(0)("TRANSFERENCIA_BANCARIA")), 0, ds.Tables(7).Rows(0)("TRANSFERENCIA_BANCARIA")) 'ID:7                 
                '******************
                Me.FormatoDgvListado()

                ListarCajas()

                Dim dt As DataTable = ds.Tables(9)

                DTCounterCargaDesasociadas = dt.Copy
                Dim ss As Integer = DTCounterCargaDesasociadas.Rows.Count
                '=======CARGA=====
                If DTCounterCargaDesasociadas IsNot Nothing Then
                    With Me.LstCarga1
                        .DataSource = DTCounterCargaDesasociadas
                        .DisplayMember = "nombre"
                        .ValueMember = "idusuario_personal"
                    End With
                End If


                '=================

                'dtCounter = DTCounterCargaDesasociadas.Copy
                ''dtCounter.Merge(dtCounterPsjesDesasociadas)
                'For Each row As DataRow In dtCounterPsjesDesasociadas.Rows
                '    dr = dtCounter.NewRow
                '    dr("idliqui_turnos") = row.Item("idliqui_turnos")
                '    dr("idusuario_personal") = row.Item("idusuario_personal")
                '    dr("nombre") = row.Item("nombre")
                '    dtCounter.Rows.Add(dr)
                'Next
                '--------Counter Desasociadas----
                'Me.ListaCounterPsjesDesasociadas() 'Pasaje
                '-->busca las liquidacion cerrada, pendientes por asociar a la liquidacion de oficina. - jabanto
                'dtCounterPsjesDesasociadas = liquidacionSisvyr.buscarLiquidacionCerradasXAsociar(fechaLiquidacion, dtoUSUARIOS.codAgenciaSisvyr).Tables(0) 'Pasaje

                '-->Busca liquidaciones asociadas a una liquidacion de oficina
                'dtCounterPsjesAsociadas = obj.ListaCounterPsjesAsociadas(IDLiquidacionOficina, LblFecha.Text, dtoUSUARIOS.m_iIdAgencia)

                'If Not IsNothing(dtCounterPsjesDesasociadas) Then
                '    '=====PASAJE====
                '    Dim Login1 As String, Login2 As String
                '    For i As Integer = 0 To dtCounterPsjesAsociadas.Rows.Count - 1
                '        Login1 = dtCounterPsjesAsociadas.Rows(i)("login")

                '        For x As Integer = 0 To dtCounterPsjesDesasociadas.Rows.Count - 1
                '            Login2 = dtCounterPsjesDesasociadas.Rows(x)("login")
                '            If Trim(Login1) = Trim(Login2) Then
                '                dtCounterPsjesDesasociadas.Rows(x).Delete()
                '                dtCounterPsjesDesasociadas.AcceptChanges()
                '                Exit For
                '            End If
                '        Next
                '    Next

                '    With Me.LstPasajes1
                '        .DataSource = dtCounterPsjesDesasociadas
                '        .DisplayMember = "NOMBRE"
                '        .ValueMember = "IDUSUARIO_PERSONAL"
                '    End With
                '    '===============
                'Else
                '    MessageBox.Show("No se recuperaron Counter de Pasajes porque el Id Concesionario es Cero", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                '    Me.Cursor = Cursors.Default
                '    Return
                'End If


                '========COUNTER ASOCIADAS==============
                'Me.ListaCounterPsjesAsociadas() 'Pasaje                
                dtCounterCargaAsociadas = obj.ListarCounterAsociadas(IDLiquidacionOficina, dtoUSUARIOS.iIDAGENCIAS, LblFecha.Text)
                dtCounterCargaDesasociadas2 = dtCounterCargaAsociadas.Copy
                'dtCounter2 = dtCounterCargaAsociadas.Copy
                'dtCounter.Merge(dtCounterPsjesDesasociadas)
                'For Each row As DataRow In dtCounterPsjesAsociadas.Rows
                '    dr = dtCounter2.NewRow
                '    dr("idliqui_turnos") = row.Item("idliqui_turnos")
                '    dr("idusuario_personal") = row.Item("idusuario_personal")
                '    dr("nombre") = row.Item("nombre")
                '    dtCounter2.Rows.Add(dr)
                'Next

                '=====CARGA
                With Me.LstCarga2
                    .DataSource = dtCounterCargaAsociadas
                    .DisplayMember = "nombre"
                    .ValueMember = "idusuario_personal"
                End With
                '=====

                '=====PASAJE--Comparacion si esta tranferido no Mostrar en LstPasajes2
                'Dim transferencia As Integer
                'For i As Integer = 0 To dtCounterPsjesAsociadas.Rows.Count - 1
                '    For r As Integer = 0 To dtCounterPsjesAsociadas.Rows.Count - 1
                '        transferencia = dtCounterPsjesAsociadas.Rows(r)("Transferencia")
                '        If transferencia = 1 Then
                '            dtCounterPsjesAsociadas.Rows(r).Delete()
                '            dtCounterPsjesAsociadas.AcceptChanges()
                '            Exit For
                '        End If
                '    Next
                'Next


                'With Me.LstPasajes2
                '    dtCounterPsjesDesasociadas2 = dtCounterPsjesAsociadas.Copy
                '    .DataSource = dtCounterPsjesAsociadas
                '    .DisplayMember = "nombre"
                '    .ValueMember = "idusuario_personal"
                'End With
                'If dtCounterPsjesAsociadas.Rows.Count > 0 Then
                '    Me.BtnTransferencia.Enabled = True
                'End If
                '=====

                Dim dtlistadoUsuario As DataTable = obj.ListadoUsuario(LblFecha.Text, LblCodLiquidacion.Text, dtoUSUARIOS.m_iIdAgencia)
                With DgvListado
                    .DataSource = dtlistadoUsuario
                End With

                CboFechaLiquidacion.Text = ds.Tables(0).Rows(0)("Fecha_Apertura").ToString
                Me.BtnBuscar_Click(sender, e)

                Me.TabGastos = TabLiquidacion.TabPages(4)
                Me.TabLiquidacion.Controls.RemoveAt(4)
                Me.TabLiquidacion.SelectTab(3)
                Me.bAperturado = True
                Me.Cursor = Cursors.Default
            Else 'If ds.Tables(4).Rows.Count = 0 Then
                Me.Cursor = Cursors.Default

                Me.TabGastos = TabLiquidacion.TabPages(4)
                Me.TabLiquidacion.Controls.RemoveAt(4)
                Me.TabLiquidacion.TabPages(1).Parent = Nothing
                Me.bAperturado = False
                Me.TabLiquidacion.SelectTab(2)
                MessageBox.Show("No se ha Aperturado ninguna Liquidacion de Oficina para Liquidar, debe aperturar una Liquidacion", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            Me.bTrasferencia = False
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmLiquidacionDiaria_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'If Asc(e.KeyChar) = Keys.Enter Then
        '    SendKeys.Send("{TAB}")
        'End If
    End Sub

    Private Sub CboTipoMovimiento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboTipoMovimiento.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub CboTipoMovimiento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoMovimiento.SelectedIndexChanged
        Try
            If Not IsReference(CboTipoMovimiento.SelectedValue) Then
                If Not bEditar Then Me.Limpiar()
                If CboTipoMovimiento.SelectedValue = 1 Then
                    TxtCodigoPeaje.Enabled = True
                    TxtMonto.Enabled = True
                    If bEditar Then
                        Me.CboDestino.Enabled = False
                        Me.CboPiloto.Enabled = False
                    Else
                        Me.CboDestino.Enabled = True
                        Me.CboPiloto.Enabled = True
                    End If
                    Me.TxtNroBus.Enabled = True
                    Me.TxtObservaciones.Enabled = True
                    Me.Enabilitar("TxtCodigoPeaje", "TxtMonto", "CboDestino", "TxtNroBus", "CboPiloto", "TxtObservaciones") 'Diferente Del Texto Ingresado
                    Me.TxtCodigoPeaje.Focus()
                    'Texto Negrita
                    Me.TextoNegrita("lblCodPeaje", "LblMonto", "LblNroBus", "LblObservaciones", "LblDestino", "LblPiloto") 'Igual al Texto Ingresado    

                ElseIf CboTipoMovimiento.SelectedValue = 2 Then
                    TxtNroDocumento.Enabled = True
                    TxtMonto.Enabled = True
                    TxtObservaciones.Enabled = True
                    Me.Enabilitar("TxtNroDocumento", "TxtMonto", "TxtObservaciones", "", "", "")
                    TxtNroDocumento.Focus()
                    'Texto Negrita
                    Me.TextoNegrita("LblNroDocumento", "LblMonto", "LblObservaciones", "", "", "")

                ElseIf CboTipoMovimiento.SelectedValue = 3 Then
                    TxtMonto.Enabled = True
                    TxtContacto.Enabled = True
                    TxtObservaciones.Enabled = True
                    Me.Enabilitar("TxtMonto", "TxtContacto", "TxtObservaciones", "", "", "")
                    TxtMonto.Focus()
                    'Texto Negrita
                    Me.TextoNegrita("LblMonto", "LblContTepsa", "LblObservaciones", "", "", "")

                ElseIf CboTipoMovimiento.SelectedValue = 4 Then
                    TxtMonto.Enabled = True
                    TxtContacto.Enabled = True
                    TxtObservaciones.Enabled = True
                    Me.Enabilitar("TxtMonto", "TxtContacto", "TxtObservaciones", "", "", "")
                    TxtMonto.Focus()
                    'Texto Negrita
                    Me.TextoNegrita("LblMonto", "LblContTepsa", "LblObservaciones", "", "", "")

                ElseIf CboTipoMovimiento.SelectedValue = 6 Then
                    TxtNroDocumento.Enabled = True
                    TxtMonto.Enabled = True
                    TxtContacto.Enabled = True
                    TxtObservaciones.Enabled = True
                    Me.Enabilitar("TxtMonto", "TxtContacto", "TxtObservaciones", "TxtNroDocumento", "", "")
                    TxtNroDocumento.Focus()
                    'Texto Negrita
                    Me.TextoNegrita("LblMonto", "LblContTepsa", "LblObservaciones", "LblNroDocumento", "", "")

                ElseIf CboTipoMovimiento.SelectedValue = 7 Then
                    Me.TxtNroOperacion.Enabled = True
                    Me.TxtMonto.Enabled = True
                    Me.TxtDesositante.Enabled = True
                    Me.TxtContacto.Enabled = True
                    Me.TxtObservaciones.Enabled = True
                    Me.Enabilitar("TxtNroOperacion", "TxtMonto", "TxtDesositante", "TxtContacto", "TxtObservaciones", "")
                    Me.TxtNroOperacion.Focus()
                    'Texto Negrita
                    Me.TextoNegrita("LblNroOperacion", "LblMonto", "LblDepositante", "LblContTepsa", "LblObservaciones", "")

                ElseIf CboTipoMovimiento.SelectedValue = 8 Then
                    Me.TxtNroDocumento.Enabled = True
                    Me.TxtMonto.Enabled = True
                    Me.TxtObservaciones.Enabled = True
                    Me.Enabilitar("TxtNroDocumento", "TxtMonto", "", "", "", "TxtObservaciones")
                    Me.TxtNroDocumento.Focus()
                    'Texto Negrita
                    Me.TextoNegrita("LblNroDocumento", "LblMonto", "LblObservaciones", "", "", "")

                ElseIf CboTipoMovimiento.SelectedValue = 9 Then
                    Me.TxtMonto.Enabled = True
                    Me.TxtObservaciones.Enabled = True
                    Me.Enabilitar("", "TxtMonto", "", "", "", "TxtObservaciones")
                    Me.TxtMonto.Focus()
                    'Texto Negrita
                    Me.TextoNegrita("LblMonto", "LblObservaciones", "", "", "", "")

                ElseIf CboTipoMovimiento.SelectedValue = 10 Then
                    Me.TxtNroDocumento.Enabled = True
                    Me.TxtMonto.Enabled = True
                    Me.TxtObservaciones.Enabled = True
                    Me.Enabilitar("TxtNroDocumento", "TxtMonto", "", "", "", "TxtObservaciones")
                    Me.TxtNroDocumento.Focus()
                    'Texto Negrita
                    Me.TextoNegrita("LblNroDocumento", "LblMonto", "LblObservaciones", "", "", "")

                ElseIf CboTipoMovimiento.SelectedValue = 0 Then
                    Me.Limpiar()
                Else
                    TxtNroOperacion.Enabled = True
                    TxtMonto.Enabled = True
                    TxtDesositante.Enabled = True
                    TxtContacto.Enabled = True
                    TxtObservaciones.Enabled = True
                    Me.Enabilitar("TxtNroOperacion", "TxtMonto", "TxtDesositante", "TxtContacto", "TxtObservaciones", "")
                    TxtNroOperacion.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Try
            Me.Cursor = Cursors.AppStarting
            'agregado 07052012
            ListarCaja(1)
            lblEstadoCaja.Text = ""
            If Me.dgvListaCaja.Rows.Count > 0 Then
                If Me.dgvListaCaja.Rows(0).Cells("Estado").Value = "CERRADA" Then
                    BtnNuevo.Enabled = False
                    BtnCancelar.Enabled = False
                    BtnGuardar.Enabled = False
                    BtnModificar.Enabled = False
                    BtnEliminar.Enabled = False
                Else
                    BtnNuevo.Enabled = True
                    BtnCancelar.Enabled = True
                    BtnGuardar.Enabled = True
                    BtnModificar.Enabled = False
                    BtnEliminar.Enabled = False
                End If
            Else
                BtnNuevo.Enabled = False
                BtnCancelar.Enabled = False
                BtnGuardar.Enabled = False
                BtnModificar.Enabled = False
                BtnEliminar.Enabled = False
            End If
            '-------------

            CboTipoMovimiento.Enabled = True
            CboTipoMovimiento.SelectedValue = 0
            Me.cboCaja.Enabled = True
            Me.cboCaja.SelectedValue = 0

            Me.Limpiar()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Dim IDGastosLiquidacion As Integer
    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        Try
            Me.Cursor = Cursors.AppStarting
            bEditar = True
            Dim s As Object
            Dim ee As New System.Windows.Forms.DataGridViewCellEventArgs(2, 0)
            CboTipoMovimiento_SelectedIndexChanged(sender, e)
            BtnGuardar.Enabled = True
            BtnEliminar.Enabled = False
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Try
            bEliminar = True
            BtnGuardar_Click(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim iOpcion As Integer = 0
        Try
            Me.Cursor = Cursors.AppStarting
            Dim obj As New dtoCierreOficina
            If Not validar() Then
                Me.Cursor = Cursors.Default
                Return
            End If

            If bEliminar Then
                iOpcion = 3
                If (MessageBox.Show("Se va a eliminar los datos Ingresados, ¿Desea continuar?", "Titán", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Cancel) Then
                    Me.Cursor = Cursors.Default
                    Return
                End If
            ElseIf Not bEditar Then
                IDGastosLiquidacion = 0
                iOpcion = 1
                If (MessageBox.Show("Se va a Registrar los datos Ingresados, ¿Desea continuar?", "Titán", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Cancel) Then
                    Me.Cursor = Cursors.Default
                    Return
                End If
            ElseIf bEditar Then
                iOpcion = 2
                If (MessageBox.Show("Se va a modificar los datos Ingresados, ¿Desea continuar?", "Titán", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Cancel) Then
                    Me.Cursor = Cursors.Default
                    Return
                End If
            End If
            Dim intNegocio As Integer = IIf(Me.cboCaja.Text.Trim.Substring(0, 5) = "CARGA", 2, 1)
            If obj.GrabacionGastosLiquidacion(IDGastosLiquidacion, IDLiquidacionOficina, CboTipoMovimiento.SelectedValue, iOpcion, _
                                  TxtNroDocumento.Text.Trim, TxtCodigoPeaje.Text.Trim, _
                                  TxtNroOperacion.Text.Trim, Val(TxtMonto.Text.Trim), TxtNroBus.Text.Trim, _
                                  CboDestino.SelectedValue, CboPiloto.SelectedValue, TxtDesositante.Text.Trim, _
                                  TxtContacto.Text.Trim, TxtObservaciones.Text.Trim, _
                                  LblFecha.Text, Me.cboCaja.SelectedValue, dtoUSUARIOS.IdLogin, intNegocio, dtoUSUARIOS.iIDAGENCIAS, intNegocio) = True Then

                MessageBox.Show("Registrado Correctamente", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'Me.GastoLiquidacion(IDLiquidacionOficina)
                'Dim obj As New dtoCierreOficina
                Dim ds As DataSet = obj.ListaGastoLiquidacion(dtoUSUARIOS.m_iIdAgencia, LblFecha.Text, IDLiquidacionOficina, dtoUSUARIOS.IdLogin) 'Usuario_Creacion
                With DgvGastosLiquidacion
                    .DataSource = ds.Tables(0)
                End With
                '*****************
                LblTotalDevoCarga.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("DEVOLUCION_DE_CARGA")), 0, ds.Tables(1).Rows(0)("DEVOLUCION_DE_CARGA")) 'ID:1
                LblTotalOtrosIngresos.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("TOTAL_OTROS_INGRESOS")), 0, ds.Tables(1).Rows(0)("TOTAL_OTROS_INGRESOS")) 'ID:2
                TotalGastosReciboCaja.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("GASTOS_CON_RECIBO_DE_CAJA")), 0, ds.Tables(1).Rows(0)("GASTOS_CON_RECIBO_DE_CAJA")) 'ID:3
                lblPagoPeajeFueraDelCounter.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("PAGO_PEAJE_FUERA_DEL_COUNT")), 0, ds.Tables(1).Rows(0)("PAGO_PEAJE_FUERA_DEL_COUNT")) 'ID:6
                LblTotalTranfBancaria.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("TRANSFERENCIA_BANCARIA")), 0, ds.Tables(1).Rows(0)("TRANSFERENCIA_BANCARIA")) 'ID:7   
                bEditar = False
                bEliminar = False
                Me.desactivar()

                '----
                Me.BtnGuardar.Enabled = False
                Me.BtnModificar.Enabled = True
                Me.BtnEliminar.Enabled = True
                Me.CboTipoMovimiento.Enabled = False
                Me.cboCaja.Enabled = False
                '----
                Me.BtnBuscar_Click(Nothing, Nothing)
                Me.TabGastos = TabLiquidacion.TabPages("PagListado")
                Me.TabLiquidacion.SelectTab("PagListado")
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Cursor = Cursors.AppStarting
        'BtnCancelar.Enabled = False
        BtnGuardar.Enabled = False
        CboTipoMovimiento.SelectedValue = 0
        CboTipoMovimiento.Enabled = False

        Me.cboCaja.SelectedValue = 0
        Me.cboCaja.Enabled = False

        Me.TxtNroBus.Enabled = False
        Me.TxtObservaciones.Enabled = False
        TxtNroDocumento.Enabled = False
        TxtMonto.Enabled = False
        TxtContacto.Enabled = False

        Me.CboDestino.Enabled = False
        Me.CboPiloto.Enabled = False

        bEditar = False
        bEliminar = False
        TabLiquidacion.SelectTab(0)
        Me.Cursor = Cursors.Default
    End Sub



#Region "Validaciones"
    'Funcion Valida Solo [Numero]
    Public Function ValidaNumero(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[0-9\b]") '("^\d+$")  

        If re.IsMatch(txtStr.ToString()) Then
            ValidaNumero = True
        Else
            ValidaNumero = False
        End If
    End Function

    'Funcion Valida Solo [Texto]
    Public Function ValidaTexto(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[ A-ZñÑa-z\b]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            ValidaTexto = True
        Else
            ValidaTexto = False
        End If
    End Function

    'Funcion valida [Letra y Numero]
    Public Function ValidaNroTexto(ByRef txtStr As String) As Boolean
        Dim re As System.Text.RegularExpressions.Regex
        re = New System.Text.RegularExpressions.Regex("[ A-ZñÑa-z0-9\b]") '("^\d+$")
        If re.IsMatch(txtStr.ToString()) Then
            ValidaNroTexto = True
        Else
            ValidaNroTexto = False
        End If
    End Function


    Private Sub TxtNroOperacion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroOperacion.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not Me.ValidaNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtNroDocumento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroDocumento.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub TxtMonto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMonto.KeyPress
        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If Asc(e.KeyChar) = Keys.Enter Then
                SendKeys.Send(vbTab)
            Else
                If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
                    e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
                ElseIf e.KeyChar = "." Then
                    If Not (tb.SelectedText = ".") Then
                        e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
                    End If
                ElseIf e.KeyChar = "-" Then
                    If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
                        e.Handled = True
                    End If
                ElseIf Not Char.IsControl(e.KeyChar) Then
                    e.Handled = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Venta Contado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TxtCodigoPeaje_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoPeaje.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not Me.ValidaNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtNroBus_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroBus.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        Else
            If Not Me.ValidaNumero(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub
#End Region

    Function validar() As Boolean
        If Me.cboCaja.SelectedValue = 0 Then
            MessageBox.Show("Seleccione la caja de donde ingresó o salió el efectivo", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboCaja.Focus()
            Me.cboCaja.DroppedDown = True
            Me.Cursor = Cursors.Default
            Return False
        End If

        If CboTipoMovimiento.SelectedValue = 0 Then
            MessageBox.Show("Debe seleccionar un tipo de movimiento a registrar", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CboTipoMovimiento.Focus()
            Me.Cursor = Cursors.Default
            Return False
        End If

        '----
        If CboTipoMovimiento.SelectedValue = 1 Then
            If Val(TxtCodigoPeaje.Text.Trim) = 0 Then
                MessageBox.Show("Debe ingresar el Codigo del Peaje", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtCodigoPeaje.Focus()
                Return False
            End If

            If Val(TxtMonto.Text.Trim) = 0 Then
                MessageBox.Show("Debe ingresar el Monto del Peaje", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtMonto.Focus()
                Return False
            End If

            If CboDestino.SelectedValue = 0 Then
                MessageBox.Show("Debe seleccionar el Destino del Peaje.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CboDestino.Focus()
                Me.Cursor = Cursors.Default
                Return False
            End If

            If Val(TxtNroBus.Text.Trim) = 0 Then
                MessageBox.Show("Debe ingresar el Nro de Bus al que se asigno el Peaje.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtNroBus.Focus()
                Return False
            End If

            If CboPiloto.SelectedValue = 0 Then
                MessageBox.Show("Debe seleccionar el Piloto a quien se pago el Peaje.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CboPiloto.Focus()
                Me.Cursor = Cursors.Default
                Return False
            End If
            Return True


        ElseIf CboTipoMovimiento.SelectedValue = 2 Then
            If Val(TxtNroDocumento.Text.Trim) = 0 Then
                MessageBox.Show("Deve Ingresar el numero de la Boleta/Factura que se esta devolviendo", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtNroDocumento.Focus()
                Return False
            End If

            If Val(TxtMonto.Text.Trim) = 0 Then
                MessageBox.Show("Debe ingresar el monto al que asciende el ingreso adicional a la caja de la liquidacion", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtMonto.Focus()
                Return False
            End If
            Return True
        ElseIf CboTipoMovimiento.SelectedValue = 3 Then
            If Val(TxtMonto.Text.Trim) = 0 Then
                MessageBox.Show("Debe ingresar el monto al que asciende el Gasto con Recibo de Caja", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtMonto.Focus()
                Return False
            End If

            If TxtContacto.Text.Trim.Length = 0 Then
                MessageBox.Show("Debe ingresar la persona q autorizo este Gasto.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtContacto.Focus()
                Return False
            End If
            Return True
        ElseIf CboTipoMovimiento.SelectedValue = 6 Then
            If Val(TxtNroDocumento.Text.Trim) = 0 Then
                MessageBox.Show("Debe ingresar el numero de Documento ", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtNroOperacion.Focus()
                Return False
            End If

            If Val(TxtMonto.Text.Trim) = 0 Then
                MessageBox.Show("Debe ingresar el Monto ", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtMonto.Focus()
                Return False
            End If
            Return True
        ElseIf CboTipoMovimiento.SelectedValue = 7 Then
            If Val(TxtNroOperacion.Text.Trim) = 0 Then
                MessageBox.Show("Debe ingresar el numero de la operacion Bancaria o Transferencia ", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtNroOperacion.Focus()
                Return False
            End If

            If Val(TxtMonto.Text.Trim) = 0 Then
                MessageBox.Show("Debe ingresar el Monto al que asciende la Transferencia", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtMonto.Focus()
                Return False
            End If

            If TxtDesositante.Text.Trim.Length = 0 Then
                MessageBox.Show("Debe ingresar los datos de la persona y/o empresa que realizo el deposito", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtDesositante.Focus()
                Return False
            End If
            Return True
        ElseIf CboTipoMovimiento.SelectedValue = 8 Then
            If Val(TxtNroDocumento.Text.Trim) = 0 Then
                MessageBox.Show("Deve Ingresar el numero de la Boleta/Factura que se esta devolviendo", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtNroDocumento.Focus()
                Return False
            End If

            If Val(TxtMonto.Text.Trim) = 0 Then
                MessageBox.Show("Debe ingresar el monto al que asciende la Carga Devuelta", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.TxtMonto.Focus()
                Return False
            End If
            Return True
        End If
        Return True
    End Function

    Sub FormatoDgvUsuarios()
        With DgvUsrCajasAperturadas
            .Columns.Clear()
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .AllowUserToResizeColumns = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .RowHeadersWidth = 20
            .ReadOnly = True
        End With

        Dim NombreUsuario As New DataGridViewTextBoxColumn
        With NombreUsuario
            .HeaderText = "UsuarioSistema"
            .DataPropertyName = "USUARIO"
            .Name = "USUARIO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim FechaLiqui As New DataGridViewTextBoxColumn
        With FechaLiqui
            .HeaderText = "FechaLiq"
            .DataPropertyName = "FECHALIQ"
            .Name = "FECHALIQ"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim HoraLiqui As New DataGridViewTextBoxColumn
        With HoraLiqui
            .HeaderText = "HoraLiq"
            .DataPropertyName = "HORALIQ"
            .Name = "HORALIQ"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim FechaActual As New DataGridViewTextBoxColumn
        With FechaActual
            .HeaderText = "Estado"
            .DataPropertyName = "ESTADOLIQ"
            .Name = "ESTADOLIQ"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With
        Dim id As New DataGridViewTextBoxColumn
        With id
            .HeaderText = "id"
            .DataPropertyName = "id"
            .Name = "id"
            .Visible = False
        End With
        Dim negocio As New DataGridViewTextBoxColumn
        With negocio
            .HeaderText = "negocio"
            .DataPropertyName = "negocio"
            .Name = "negocio"
            .Visible = False
        End With

        DgvUsrCajasAperturadas.Columns.AddRange(NombreUsuario, FechaLiqui, HoraLiqui, FechaActual, id, negocio)
    End Sub

    Sub FormatoDgvGastosLiquidacion()
        With DgvGastosLiquidacion
            .Columns.Clear()
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            '.AllowUserToOrderColumns = True
            '.AllowUserToDeleteRows = False
            '.AllowUserToAddRows = False
            '.AutoGenerateColumns = False
            '.AllowUserToResizeColumns = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .RowHeadersWidth = 20
            .ReadOnly = True
        End With

        Dim IDGastoLiquidacion As New DataGridViewTextBoxColumn
        With IDGastoLiquidacion
            .HeaderText = "IDGastoLiquidacion"
            .DataPropertyName = "IDGastoLiquidacion"
            .Name = "IDGastoLiquidacion"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
        End With

        Dim Movimiento As New DataGridViewTextBoxColumn
        With Movimiento
            .HeaderText = "Movimiento"
            .DataPropertyName = "Movimiento"
            .Name = "Movimiento"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim Monto As New DataGridViewTextBoxColumn
        With Monto
            .HeaderText = "Monto"
            .DataPropertyName = "Monto"
            .Name = "Monto"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim NroDocumento As New DataGridViewTextBoxColumn
        With NroDocumento
            .HeaderText = "Nro Documento"
            .DataPropertyName = "NroDocumento"
            .Name = "NroDocumento"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim CodPeaje As New DataGridViewTextBoxColumn
        With CodPeaje
            .HeaderText = "Cod Peaje"
            .DataPropertyName = "CodPeaje"
            .Name = "CodPeaje"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim NroOperacion As New DataGridViewTextBoxColumn
        With NroOperacion
            .HeaderText = "Nro Operacion"
            .DataPropertyName = "NroOperacion"
            .Name = "NroOperacion"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        Dim NroBus As New DataGridViewTextBoxColumn
        With NroBus
            .HeaderText = "Nro Bus"
            .DataPropertyName = "NroBus"
            .Name = "NroBus"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        End With

        '------
        Dim idtipoliquidaciondiaria As New DataGridViewTextBoxColumn
        With idtipoliquidaciondiaria
            .HeaderText = "idtipoliquidaciondiaria"
            .DataPropertyName = "idtipoliquidaciondiaria"
            .Name = "idtipoliquidaciondiaria"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
        End With

        Dim destino As New DataGridViewTextBoxColumn
        With destino
            .HeaderText = "destino"
            .DataPropertyName = "destino"
            .Name = "destino"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
        End With

        Dim piloto As New DataGridViewTextBoxColumn
        With piloto
            .HeaderText = "piloto"
            .DataPropertyName = "piloto"
            .Name = "piloto"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
        End With

        Dim depositante As New DataGridViewTextBoxColumn
        With depositante
            .HeaderText = "depositante"
            .DataPropertyName = "depositante"
            .Name = "depositante"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
        End With

        Dim contacto As New DataGridViewTextBoxColumn
        With contacto
            .HeaderText = "contacto"
            .DataPropertyName = "contacto"
            .Name = "contacto"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
        End With

        Dim observaciones As New DataGridViewTextBoxColumn
        With observaciones
            .HeaderText = "observaciones"
            .DataPropertyName = "observaciones"
            .Name = "observaciones"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = True
        End With

        Dim caja As New DataGridViewTextBoxColumn
        With caja
            .HeaderText = "caja"
            .DataPropertyName = "caja"
            .Name = "caja"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
        End With

        DgvGastosLiquidacion.Columns.AddRange(IDGastoLiquidacion, Movimiento, Monto, NroDocumento, CodPeaje, NroOperacion, NroBus, _
                                              idtipoliquidaciondiaria, destino, piloto, depositante, contacto, observaciones, caja)
    End Sub

    Sub FormatoDgvListaCaja()
        With dgvListaCaja
            .Columns.Clear()
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .AllowUserToResizeColumns = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            '.RowHeadersWidth = 20
            .ReadOnly = True
        End With

        Dim ID_Oficina_Liquidacion As New DataGridViewTextBoxColumn
        With ID_Oficina_Liquidacion
            .HeaderText = "N° Liquidacion"
            .DataPropertyName = "ID_Oficina_Liquidacion"
            .Name = "ID_Oficina_Liquidacion"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = True
        End With

        Dim Usuario_Creacion As New DataGridViewTextBoxColumn
        With Usuario_Creacion
            .HeaderText = "Usuario_Creacion"
            .DataPropertyName = "Usuario_Creacion"
            .Name = "Usuario_Creacion"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
        End With

        Dim Usuario As New DataGridViewTextBoxColumn
        With Usuario
            .HeaderText = "Usuario"
            .DataPropertyName = "Usuario_Apertura"
            .Name = "Usuario_Apertura"
            .Width = 200
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim Usuario_Modificacion As New DataGridViewTextBoxColumn
        With Usuario_Modificacion
            .HeaderText = "Usuario_Modificacion"
            .DataPropertyName = "Usuario_Modificacion"
            .Name = "Usuario_Modificacion"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
        End With

        Dim UsuarioCierre As New DataGridViewTextBoxColumn
        With UsuarioCierre
            .HeaderText = "Usuario"
            .DataPropertyName = "Usuario_Cierre"
            .Name = "Usuario_Cierre"
            .Width = 200
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
        End With

        Dim Fecha_Liquidacion As New DataGridViewTextBoxColumn
        With Fecha_Liquidacion
            .HeaderText = "Fecha Liquidación"
            .DataPropertyName = "Fecha_Apertura"
            .Name = "Fecha_Apertura"
            .Width = 145
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim Fecha_Cierre As New DataGridViewTextBoxColumn
        With Fecha_Cierre
            .HeaderText = "Fecha_Cierre"
            .DataPropertyName = "Fecha_Cierre"
            .Name = "Fecha_Cierre"
            .Width = 145
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
        End With

        Dim Estado As New DataGridViewTextBoxColumn
        With Estado
            .HeaderText = "Estado"
            .DataPropertyName = "Estado"
            .Name = "Estado"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim total_efectivo As New DataGridViewTextBoxColumn
        With total_efectivo
            .HeaderText = "total_efectivo"
            .DataPropertyName = "total_efectivo"
            .Name = "total_efectivo"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .Visible = False
        End With

        Dim total_pce As New DataGridViewTextBoxColumn
        With total_pce
            .HeaderText = "total_pce"
            .DataPropertyName = "total_pce"
            .Name = "total_pce"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
        End With

        Dim total_tarjeta As New DataGridViewTextBoxColumn
        With total_tarjeta
            .HeaderText = "total_tarjeta"
            .DataPropertyName = "total_tarjeta"
            .Name = "total_tarjeta"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
        End With

        dgvListaCaja.Columns.AddRange(ID_Oficina_Liquidacion, Usuario_Creacion, Usuario, Usuario_Modificacion, UsuarioCierre, Fecha_Liquidacion, Fecha_Cierre, Estado, total_efectivo, total_pce, total_tarjeta)
    End Sub

    Sub FormatoDgvListado()
        With DgvListado
            .Columns.Clear()
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .AllowUserToResizeColumns = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .RowHeadersWidth = 20
            .ReadOnly = True
        End With

        Dim IDLiquiTurno As New DataGridViewTextBoxColumn
        With IDLiquiTurno
            .HeaderText = "IDLiquiTurno"
            .DataPropertyName = "IDLiquiTurno"
            .Name = "IDLiquiTurno"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
        End With

        Dim IDOficinaLiquidacion As New DataGridViewTextBoxColumn
        With IDOficinaLiquidacion
            .HeaderText = "IDOficinaLiquidacion"
            .DataPropertyName = "IDOficinaLiquidacion"
            .Name = "IDOficinaLiquidacion"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
        End With

        Dim idusuario_personal As New DataGridViewTextBoxColumn
        With idusuario_personal
            .HeaderText = "id_usuario_personal"
            .DataPropertyName = "id_usuario_personal"
            .Name = "id_usuario_personal"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
        End With

        Dim Tipo As New DataGridViewTextBoxColumn
        With Tipo
            .HeaderText = "Tipo"
            .DataPropertyName = "Tipo"
            .Name = "Tipo"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim Counter As New DataGridViewTextBoxColumn
        With Counter
            .HeaderText = "Counters"
            .DataPropertyName = "nombre"
            .Name = "nombre"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim EfectivoIngresado As New DataGridViewTextBoxColumn
        With EfectivoIngresado
            .HeaderText = "efectivo_ingresado"
            .DataPropertyName = "efectivo_ingresado"
            .Name = "efectivo_ingresado"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
        End With
        DgvListado.Columns.AddRange(IDLiquiTurno, IDOficinaLiquidacion, idusuario_personal, Tipo, Counter, EfectivoIngresado)
    End Sub

    Sub FormatoDgvGastosXCounter()
        With DgvGastosXCounter
            .Columns.Clear()
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .AllowUserToResizeColumns = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            '.RowHeadersWidth = 20
            .ReadOnly = True
        End With

        Dim TIPO_MOVIMIENTO As New DataGridViewTextBoxColumn
        With TIPO_MOVIMIENTO
            .HeaderText = "Tipo_Movimiento"
            .DataPropertyName = "TIPO_MOVIMIENTO"
            .Name = "TIPO_MOVIMIENTO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim MONTO As New DataGridViewTextBoxColumn
        With MONTO
            .HeaderText = "Monto"
            .DataPropertyName = "MONTO"
            .Name = "MONTO"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Width = 65
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim NRO_DOCUMENTO As New DataGridViewTextBoxColumn
        With NRO_DOCUMENTO
            .HeaderText = "Nro_Documento"
            .DataPropertyName = "NRO_DOCUMENTO"
            .Name = "NRO_DOCUMENTO"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim CODIGO_PEAJE As New DataGridViewTextBoxColumn
        With CODIGO_PEAJE
            .HeaderText = "Codigo_Peaje"
            .DataPropertyName = "CODIGO_PEAJE"
            .Name = "CODIGO_PEAJE"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim CUENTA_BANCARIA As New DataGridViewTextBoxColumn
        With CUENTA_BANCARIA
            .HeaderText = "Cuenta_Bancaria"
            .DataPropertyName = "CUENTA_BANCARIA"
            .Name = "CUENTA_BANCARIA"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim DESTINO As New DataGridViewTextBoxColumn
        With DESTINO
            .HeaderText = "Destino"
            .DataPropertyName = "DESTINO"
            .Name = "DESTINO"
            ' .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim DEPOSITANTE As New DataGridViewTextBoxColumn
        With DEPOSITANTE
            .HeaderText = "Depositante"
            .DataPropertyName = "DEPOSITANTE"
            .Name = "DEPOSITANTE"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim CONTACTO As New DataGridViewTextBoxColumn
        With CONTACTO
            .HeaderText = "Contacto"
            .DataPropertyName = "CONTACTO"
            .Name = "CONTACTO"
            ' .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim NRO_BUS As New DataGridViewTextBoxColumn
        With NRO_BUS
            .HeaderText = "Nro_Bus"
            .DataPropertyName = "NRO_BUS"
            .Name = "NRO_BUS"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Width = 55
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim PILOTO As New DataGridViewTextBoxColumn
        With PILOTO
            .HeaderText = "Piloto"
            .DataPropertyName = "PILOTO"
            .Name = "PILOTO"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Width = 250
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        Dim OBSERVACIONES As New DataGridViewTextBoxColumn
        With OBSERVACIONES
            .HeaderText = "Observaciones"
            .DataPropertyName = "OBSERVACIONES"
            .Name = "OBSERVACIONES"
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Width = 350
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        End With

        DgvGastosXCounter.Columns.AddRange(TIPO_MOVIMIENTO, MONTO, NRO_DOCUMENTO, CODIGO_PEAJE, CUENTA_BANCARIA, DESTINO, DEPOSITANTE, CONTACTO, NRO_BUS, PILOTO, OBSERVACIONES)
    End Sub

    Sub Limpiar()
        For Each obj As Control In Me.GrpContenedor.Controls
            If TypeOf obj Is TextBox Then
                obj.Text = ""
                obj.Enabled = False
            End If
        Next
        CboDestino.SelectedValue = 0
        CboPiloto.SelectedValue = 0
        Me.cboCaja.Enabled = True
        'Me.lblEstadoCaja.Text = ""
        Me.CboTipoMovimiento.Enabled = True
    End Sub

    'DESACTIVAR TODOS LOS CONTROLES UNA VEZ 
    Sub desactivar()
        For Each obj As Control In Me.GrpContenedor.Controls
            If TypeOf obj Is TextBox Then
                obj.Enabled = False
            End If
        Next
    End Sub

    'CONTROL .ENABLE = FALSE
    Sub Enabilitar(ByVal Control1 As String, ByVal Control2 As String, ByVal Control3 As String, ByVal Control4 As String, ByVal Control5 As String, ByVal Control6 As String)
        For Each obj As Control In Me.GrpContenedor.Controls
            If TypeOf obj Is TextBox Or TypeOf obj Is ComboBox Then
                If obj.Name <> Control1 And obj.Name <> Control2 And obj.Name <> Control3 And obj.Name <> Control4 And obj.Name <> Control5 And obj.Name <> Control6 And obj.Name <> "CboTipoMovimiento" And obj.Name <> "cboCaja" Then
                    obj.Enabled = False
                End If
            End If
        Next
    End Sub

    Sub TextoNegrita(ByVal Control1 As String, ByVal Control2 As String, ByVal Control3 As String, ByVal Control4 As String, ByVal Control5 As String, ByVal Control6 As String)
        For Each obj As Control In Me.GrpContenedor.Controls
            If TypeOf obj Is Label Then
                If obj.Name = Control1 Or obj.Name = Control2 Or obj.Name = Control3 Or obj.Name = Control4 Or obj.Name = Control5 Or obj.Name = Control6 Then
                    obj.Font = New Font("Arial", 8, FontStyle.Bold)
                Else
                    obj.Font = New Font("Arial", 8, FontStyle.Regular)
                    'Microsoft Sans Serif, 8.25pt
                End If

            End If
        Next
    End Sub

    Dim bEditar As Boolean
    Private Sub DgvGastosLiquidacion_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DgvGastosLiquidacion.DoubleClick
        Try
            Me.Cursor = Cursors.AppStarting
            If DgvGastosLiquidacion.Rows.Count > 0 Then
                intLlamada = 1
                ListarCaja(2)
                Dim row As Integer = DgvGastosLiquidacion.SelectedRows.Item(0).Index
                '-----            
                IDGastosLiquidacion = DgvGastosLiquidacion.Rows(row).Cells("IDGastoLiquidacion").Value
                Me.cboCaja.SelectedValue = DgvGastosLiquidacion.Rows(row).Cells("caja").Value
                CboTipoMovimiento.SelectedValue = IIf(IsDBNull(DgvGastosLiquidacion.Rows(row).Cells("idtipoliquidaciondiaria").Value), 0, DgvGastosLiquidacion.Rows(row).Cells("idtipoliquidaciondiaria").Value)
                TxtCodigoPeaje.Text = IIf(IsDBNull(DgvGastosLiquidacion.Rows(row).Cells("CodPeaje").Value), "", DgvGastosLiquidacion.Rows(row).Cells("CodPeaje").Value)
                TxtMonto.Text = IIf(IsDBNull(DgvGastosLiquidacion.Rows(row).Cells("Monto").Value), "", DgvGastosLiquidacion.Rows(row).Cells("Monto").Value)
                TxtNroDocumento.Text = IIf(IsDBNull(DgvGastosLiquidacion.Rows(row).Cells("NroDocumento").Value), "", DgvGastosLiquidacion.Rows(row).Cells("NroDocumento").Value)
                TxtNroOperacion.Text = IIf(IsDBNull(DgvGastosLiquidacion.Rows(row).Cells("NroOperacion").Value), "", DgvGastosLiquidacion.Rows(row).Cells("NroOperacion").Value)
                RemoveHandler CboTipoMovimiento.SelectedIndexChanged, AddressOf CboTipoMovimiento_SelectedIndexChanged
                CboDestino.SelectedValue = IIf(IsDBNull(DgvGastosLiquidacion.Rows(row).Cells("destino").Value), 0, DgvGastosLiquidacion.Rows(row).Cells("destino").Value)
                AddHandler CboTipoMovimiento.SelectedIndexChanged, AddressOf CboTipoMovimiento_SelectedIndexChanged
                CboDestino.Enabled = False
                TxtNroBus.Text = IIf(IsDBNull(DgvGastosLiquidacion.Rows(row).Cells("NroBus").Value), "", DgvGastosLiquidacion.Rows(row).Cells("NroBus").Value)
                CboPiloto.SelectedValue = IIf(IsDBNull(DgvGastosLiquidacion.Rows(row).Cells("piloto").Value), 0, DgvGastosLiquidacion.Rows(row).Cells("piloto").Value)
                CboPiloto.Enabled = False
                TxtDesositante.Text = IIf(IsDBNull(DgvGastosLiquidacion.Rows(row).Cells("depositante").Value), "", DgvGastosLiquidacion.Rows(row).Cells("depositante").Value)
                TxtContacto.Text = IIf(IsDBNull(DgvGastosLiquidacion.Rows(row).Cells("contacto").Value), "", DgvGastosLiquidacion.Rows(row).Cells("contacto").Value)
                TxtObservaciones.Text = IIf(IsDBNull(DgvGastosLiquidacion.Rows(row).Cells("observaciones").Value), "", DgvGastosLiquidacion.Rows(row).Cells("observaciones").Value)
                '----- 
                If Me.dgvListaCaja.Rows(0).Cells("Estado").Value = "CERRADA" Then
                    BtnNuevo.Enabled = False
                    BtnModificar.Enabled = False 'xxx
                    BtnEliminar.Enabled = False
                    BtnGuardar.Enabled = False
                Else
                    BtnNuevo.Enabled = True
                    BtnModificar.Enabled = True 'xxx
                    BtnEliminar.Enabled = True
                    BtnGuardar.Enabled = False
                End If

                TabLiquidacion.SelectTab(1)
                Me.desactivar()
                Me.cboCaja.Enabled = False
                Me.CboTipoMovimiento.Enabled = False

                cboCaja_SelectedIndexChanged(Nothing, Nothing)
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Dim dtCounter2 As DataTable
    Private Sub BtnSeleccion1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        '    If Lst1.SelectedItems.Count > 0 Then
        '        If lst2.SelectedItems.Count = 0 Then
        '            dtCounter2 = New DataTable
        '            dtCounter2.Columns.Add(New DataColumn("idliqui_turnos", GetType(Integer)))
        '            dtCounter2.Columns.Add(New DataColumn("idusuario_personal", GetType(Integer)))
        '            dtCounter2.Columns.Add(New DataColumn("nombre", GetType(String)))
        '        End If

        '        Dim dr As DataRow
        '        dr = dtCounter2.NewRow
        '        dr("idliqui_turnos") = dtCounter.Rows(Lst1.SelectedIndex)("idliqui_turnos")
        '        dr("idusuario_personal") = Lst1.SelectedValue
        '        dr("nombre") = Lst1.Text
        '        dtCounter2.Rows.Add(dr)

        '        With Me.lst2
        '            .DataSource = dtCounter2
        '            .DisplayMember = "nombre"
        '            .ValueMember = "idusuario_personal"
        '        End With

        '        Dim obj As New dtoCierreOficina
        '        obj.AsociarOficina(1, IDLiquidacionOficina, dtCounter.Rows(Lst1.SelectedIndex)("idliqui_turnos"))
        '        Me.AsociarOficinaPasajes(IDLiquidacionOficina, dtCounter.Rows(Lst1.SelectedIndex)("idliqui_turnos"))

        '        dtCounter.Rows.RemoveAt(Lst1.SelectedIndex)
        '        With Me.Lst1
        '            .DataSource = dtCounter
        '            .DisplayMember = "nombre"
        '            .ValueMember = "idusuario_personal"
        '        End With
        '    Else
        '        MessageBox.Show("No hay cajas cerradas para selecionar", "Titán", MessageBoxButtons.OK)
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Try
            Me.Cursor = Cursors.AppStarting
            Me.FormatoDgvListaCaja()
            Dim obj As New dtoCierreOficina
            Dim ds As DataSet = obj.ListaCaja(dtoUSUARIOS.iIDAGENCIAS, CboFechaLiquidacion.Value.Date)
            dgvListaCaja.DataSource = ds.Tables(0)

            BtnNuevo_Click(sender, e)

            Dim a As String = LblTotalDevoCarga.Text
            If dgvListaCaja.Rows.Count > 0 Then
                If Me.dgvListaCaja.Rows(0).Cells("Estado").Value = "CERRADA" Then
                    Me.btnCerrarLiquidacion.Enabled = False
                    Me.btnAbrirLiquidacion.Enabled = True
                Else
                    '--------Counter Desasociadas----
                    Dim dt As DataTable = ds.Tables(1)
                    DTCounterCargaDesasociadas = dt.Copy

                    Dim ss As Integer = DTCounterCargaDesasociadas.Rows.Count
                    '=======CARGA=====
                    If DTCounterCargaDesasociadas IsNot Nothing Then
                        With Me.LstCarga1
                            .DataSource = DTCounterCargaDesasociadas
                            .DisplayMember = "nombre"
                            .ValueMember = "idusuario_personal"
                        End With
                    End If

                    '========COUNTER ASOCIADAS==============
                    dtCounterCargaAsociadas = obj.ListarCounterAsociadas(IDLiquidacionOficina, dtoUSUARIOS.iIDAGENCIAS, CboFechaLiquidacion.Value.Date)
                    dtCounterCargaDesasociadas2 = dtCounterCargaAsociadas.Copy

                    '=====CARGA
                    With Me.LstCarga2
                        .DataSource = dtCounterCargaAsociadas
                        .DisplayMember = "nombre"
                        .ValueMember = "idusuario_personal"
                    End With
                    '=====

                    '-----------Counter de Pasaje Desasociada----------------------
                    'Me.ListaCounterPsjesDesasociadas() 'Pasaje
                    'dtCounterPsjesDesasociadas = liquidacionSisvyr.buscarLiquidacionCerradasXAsociar(CboFechaLiquidacion.Value.Date, dtoUSUARIOS.codAgenciaSisvyr).Tables(0) 'Pasaje

                    'dtCounterPsjesAsociadas = obj.ListaCounterPsjesAsociadas(IDLiquidacionOficina, CboFechaLiquidacion.Value.Date, dtoUSUARIOS.m_iIdAgencia)

                    'If Not IsNothing(dtCounterPsjesDesasociadas) Then
                    '    '=====PASAJE====
                    '    Dim Login1 As String, Login2 As String
                    '    For i As Integer = 0 To dtCounterPsjesAsociadas.Rows.Count - 1
                    '        Login1 = dtCounterPsjesAsociadas.Rows(i)("login")

                    '        For x As Integer = 0 To dtCounterPsjesDesasociadas.Rows.Count - 1
                    '            Login2 = dtCounterPsjesDesasociadas.Rows(x)("login")
                    '            If Trim(Login1) = Trim(Login2) Then
                    '                dtCounterPsjesDesasociadas.Rows(x).Delete()
                    '                dtCounterPsjesDesasociadas.AcceptChanges()
                    '                Exit For
                    '            End If
                    '        Next
                    '    Next

                    '    With Me.LstPasajes1
                    '        .DataSource = dtCounterPsjesDesasociadas
                    '        .DisplayMember = "nombre"
                    '        .ValueMember = "idusuario_personal"
                    '    End With
                    'Else
                    '    MessageBox.Show("No se recuperaron Counter de Pasajes porque el Id Concesionario es Cero", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    '    Me.Cursor = Cursors.Default
                    '    Return
                    'End If


                    ''=====PASAJE--Comparacion si esta tranferido no Mostrar en LstPasajes2
                    'Dim transferencia As Integer
                    'For i As Integer = 0 To dtCounterPsjesAsociadas.Rows.Count
                    '    For r As Integer = 0 To dtCounterPsjesAsociadas.Rows.Count - 1
                    '        transferencia = dtCounterPsjesAsociadas.Rows(r)("Transferencia")
                    '        If transferencia = 1 Then
                    '            dtCounterPsjesAsociadas.Rows(r).Delete()
                    '            dtCounterPsjesAsociadas.AcceptChanges()
                    '            Exit For
                    '        End If
                    '    Next
                    'Next


                    'With Me.LstPasajes2
                    '    dtCounterPsjesDesasociadas2 = dtCounterPsjesAsociadas.Copy
                    '    .DataSource = dtCounterPsjesAsociadas
                    '    .DisplayMember = "nombre"
                    '    .ValueMember = "idusuario_personal"
                    'End With
                    'If dtCounterPsjesAsociadas.Rows.Count > 0 Then
                    '    Me.BtnTransferencia.Enabled = True
                    'End If
                    '=====

                    Dim dtlistadoUsuario As DataTable = obj.ListadoUsuario(CboFechaLiquidacion.Value.Date, IDLiquidacionOficina, dtoUSUARIOS.m_iIdAgencia)
                    With DgvListado
                        .DataSource = dtlistadoUsuario
                    End With

                    Me.btnCerrarLiquidacion.Enabled = True
                    Me.btnAbrirLiquidacion.Enabled = False
                End If

                'Me.btnAbrirLiquidacionDiaria.Enabled = True
                Me.BtnPrv.Enabled = True

                If LstCarga2.Items.Count <= 0 And LstPasajes2.Items.Count <= 0 Then
                    BtnTransferencia.Enabled = False
                Else
                    BtnTransferencia.Enabled = True
                End If
            Else
                Me.btnAbrirLiquidacionDiaria.Enabled = False
                Me.BtnPrv.Enabled = False
                Me.btnAbrirLiquidacion.Enabled = False
                Me.btnCerrarLiquidacion.Enabled = False
                BtnTransferencia.Enabled = False

                LstCarga1.DataSource = Nothing
                LstCarga2.DataSource = Nothing
                LstPasajes1.DataSource = Nothing
                LstPasajes2.DataSource = Nothing
                'Limpiando Datos
                LblTotalPagoCargaTarjVISA.Text = 0
                LblTotalPagoCargaTarjMASTER.Text = 0
                LblPagoPasajesTarjVISA.Text = 0
                LblPagoPasajesTarjMASTER.Text = 0
                LblTotalTranfBancaria.Text = 0
                lblPagoPeajeFueraDelCounter.Text = 0
                LblTotalDevoCarga.Text = 0
                TotalGastosReciboCaja.Text = 0
                LblTotalOtrosIngresos.Text = 0
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ConsultaUsrTransferencia(ByVal RowIndex As Integer)
        Dim obj As New dtoCierreOficina
        Dim dtlistadoUsuario As DataTable = obj.ListadoUsuario(CboFechaLiquidacion.Text, dgvListaCaja.Rows(RowIndex).Cells("ID_OFICINA_LIQUIDACION").Value, dtoUSUARIOS.m_iIdAgencia)
        With DgvListado
            Me.FormatoDgvListado()
            .DataSource = dtlistadoUsuario
        End With
    End Sub

    Private Sub dgvListaCaja_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaCaja.CellEnter
        If Me.dgvListaCaja.Rows.Count > 0 Then
            Me.GastoLiquidacion(dgvListaCaja.Rows(e.RowIndex).Cells("ID_OFICINA_LIQUIDACION").Value, e.RowIndex)

            'If Me.dgvListaCaja.Rows(e.RowIndex).Cells("Estado").Value = "ABIERTA" Then
            '    Me.ConsultaUsrTransferencia(e.RowIndex)
            'End If
            If Me.dgvListaCaja.Rows(e.RowIndex).Cells("Estado").Value = "CERRADA" Then
                LstCarga1.DataSource = Nothing
                LstCarga2.DataSource = Nothing
                LstPasajes1.DataSource = Nothing
                LstPasajes2.DataSource = Nothing
                Me.ConsultaUsrTransferencia(e.RowIndex)
                Me.btnCerrarLiquidacion.Enabled = False
                Me.btnAbrirLiquidacion.Enabled = True
                Me.BtnTransferencia.Enabled = False
            Else
                Me.btnAbrirLiquidacion.Enabled = False
                Me.btnCerrarLiquidacion.Enabled = True
            End If
        End If
    End Sub

    Sub GastoLiquidacion(ByVal ID_OFICINA_LIQUIDACION As Integer, ByVal rowIndex As Integer)
        Dim obj As New dtoCierreOficina
        Dim ds As DataSet = obj.ListaGastoLiquidacion(dtoUSUARIOS.m_iIdAgencia, CboFechaLiquidacion.Text, _
                                                 ID_OFICINA_LIQUIDACION, dgvListaCaja.Rows(rowIndex).Cells("Usuario_Creacion").Value) 'Usuario_Creacion
        With DgvGastosLiquidacion
            Me.FormatoDgvGastosLiquidacion()
            .DataSource = ds.Tables(0)
        End With
        '*****************                  
        LblTotalDevoCarga.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("DEVOLUCION_DE_CARGA")), 0, ds.Tables(1).Rows(0)("DEVOLUCION_DE_CARGA")) 'ID:1
        LblTotalOtrosIngresos.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("TOTAL_OTROS_INGRESOS")), 0, ds.Tables(1).Rows(0)("TOTAL_OTROS_INGRESOS")) 'ID:2
        TotalGastosReciboCaja.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("GASTOS_CON_RECIBO_DE_CAJA")), 0, ds.Tables(1).Rows(0)("GASTOS_CON_RECIBO_DE_CAJA")) 'ID:3
        lblPagoPeajeFueraDelCounter.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("PAGO_PEAJE_FUERA_DEL_COUNT")), 0, ds.Tables(1).Rows(0)("PAGO_PEAJE_FUERA_DEL_COUNT")) 'ID:6
        LblTotalTranfBancaria.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("TRANSFERENCIA_BANCARIA")), 0, ds.Tables(1).Rows(0)("TRANSFERENCIA_BANCARIA")) 'ID:7        

        '--TARJETAS--
        LblTotalPagoCargaTarjVISA.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("VISA_CARGA")), 0, ds.Tables(1).Rows(0)("VISA_CARGA")) '
        LblTotalPagoCargaTarjMASTER.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("MASTERCARD_CARGA")), 0, ds.Tables(1).Rows(0)("MASTERCARD_CARGA")) '
        LblPagoPasajesTarjVISA.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("TARJETA_VISA_PASAJE")), 0, ds.Tables(1).Rows(0)("TARJETA_VISA_PASAJE")) '
        LblPagoPasajesTarjMASTER.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("TARJETA_MASTER_PASAJE")), 0, ds.Tables(1).Rows(0)("TARJETA_MASTER_PASAJE")) '
    End Sub

    Private Sub BtnPrv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrv.Click
        Try
            Me.Cursor = Cursors.AppStarting
            'Dim iResp As Integer
            If Not Me.dgvListaCaja.Rows.Count > 0 Then
                Me.Cursor = Cursors.Default
                Return
            End If

            Dim row As Integer = dgvListaCaja.SelectedRows.Item(0).Index

            Dim iIDliquidacion As Integer = dgvListaCaja.Rows(row).Cells("ID_Oficina_Liquidacion").Value
            Dim iDocumento As Integer = 1 'dgvListaCaja.Rows(row).Cells("Idtipo_Comprobante").Value
            '--------------------------------
            Me.imprime(iDocumento, iIDliquidacion)
            '--------------------------------
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    'Funciones para imprimir
    Dim ObjRptGuiaEnvio As New dtoRptGuiaEnvio()
    Public Sub imprime(ByVal documento As Integer, ByVal IDLiquidacion As Integer)
        Dim obj As New Imprimir
        Try
            Dim ldt_cur_datos_venta As New DataTable
            Dim dtGastosLiquidacion As New DataTable
            Dim lds_tmp As New DataSet
            Dim row As Integer = dgvListaCaja.SelectedRows.Item(0).Index
            '
            Dim flag As Boolean = False
            Dim iSubTotal As Double = 0, iImpuesto As Double = 0, iTotal As Double = 0


            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim objImprimir As New ImprimirTexto()
            Dim sImpresora As String = ""
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0
            '


            Dim dt As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 37)

            If dt.Rows.Count = 0 Then
                flag = False
            Else
                If IsDBNull(dt.Rows(0).Item("impresora")) Then
                    flag = False
                Else
                    sImpresora = dt.Rows(0).Item("impresora")
                    iTamaño = dt.Rows(0).Item("tamano")
                    iSuperior = dt.Rows(0).Item("superior")
                    Iizquierda = dt.Rows(0).Item("izquierda")
                    flag = True
                End If
            End If

            obj = New Imprimir
            obj.Inicializar()
            obj.Superior = iSuperior
            obj.Izquierda = Iizquierda
            obj.Impresora = sImpresora

            Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
            Dim iLong As Integer = IIf(iTamaño = 0, 76, iTamaño)

            y = iLong * pagina + 4
            y += 1
            i += 1

            Dim iLinea As Integer = 0

            iLinea = Len("RESUMEN DE LIQUIDACION DE OFICINA " & dtoUSUARIOS.m_iNombreAgencia)
            obj.EscribirLinea(y - 3, (124 - iLinea) / 2, "RESUMEN DE LIQUIDACION DE OFICINA " & dtoUSUARIOS.m_iNombreAgencia)

            obj.EscribirLinea(y - 1, 10, "FECHA LIQUID : " & dgvListaCaja.Rows(row).Cells("Fecha_Apertura").Value)
            obj.EscribirLinea(y - 1, 60, "US. APERTURA.: " & dgvListaCaja.Rows(row).Cells("Usuario_Apertura").Value)
            obj.EscribirLinea(y, 10, "FECHA CIERRE : " & dgvListaCaja.Rows(row).Cells("Fecha_Cierre").Value)
            obj.EscribirLinea(y, 60, "US. CIERRE.  : " & dgvListaCaja.Rows(row).Cells("Usuario_Cierre").Value)

            If dgvListaCaja.Rows(row).Cells("Estado").Value = "CERRADA" Then
                obj.EscribirLinea(y + 1, 10, "REIMPRESION ")
            End If

            If DgvListado.Rows.Count > 0 Then
                Me.bTrasferencia = True
            End If

            Dim iOpcion As Integer
            If bTrasferencia Then
                iOpcion = 1
            Else
                iOpcion = 1
                '    MessageBox.Show("Realizar la Transferencia para ", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Question)
                '    Return
            End If

            lds_tmp = ObjVentaCargaContado.ListaDatosLiquidacion(dtoUSUARIOS.m_iIdAgencia, IDLiquidacion, CboFechaLiquidacion.Text, iOpcion)
            ldt_cur_datos_venta = lds_tmp.Tables(0).Copy
            dtGastosLiquidacion = lds_tmp.Tables(1).Copy
            '----------------------------------------------------------------------------------
            Dim objCierreOficina As New dtoCierreOficina
            Dim s As Integer = 5
            Dim totalFacturaCarga As Double, totalBoletaCarga As Double, totalPCECarga As Double, TotalMontoTarjeVisa As Double, TotalMontoTarjeMaster As Double
            Dim totalFacturaPsje As Double, totalBoletaPsje As Double, totalPCEPsje As Double, TotalCredito As Double, totalDevolucionCarga As Double
            Dim totalEncomiendaCortesia As Double
            Dim TotalOtrosIngresos As Double, TotalOtrosIngresosTarjeta As Double
            Dim NCCarga As Double
            Dim NCBoleta As Double, NCFactura As Double

            '====PASAJE=======
            obj.EscribirLinea(y + 3, 10, "VENTA PASAJE")
            obj.EscribirLinea(y + 4, 10, "------------")

            Dim dtListaTotalesPsjes As DataSet = objCierreOficina.PrevistaReporte(iOpcion, IDLiquidacion, CboFechaLiquidacion.Text, dtoUSUARIOS.m_iIdAgencia)
            If iOpcion = 0 Then
                For Each fila As DataRow In dtListaTotalesPsjes.Tables(0).Rows
                    If Len(fila.Item("USUARIO")) > 40 Then
                        fila.Item("USUARIO") = fila.Item("USUARIO").ToString.Substring(0, 40)
                    End If
                    obj.EscribirLinea(y + s, 10, fila.Item("USUARIO")) 'cambio 

                    If Trim(fila.Item("montoefectivo").ToString) = "" Then
                        iLinea = Len("0.00")
                        obj.EscribirLinea(y + s, 71 - iLinea, "0.00")
                    Else
                        iLinea = Len(FormatNumber(Format(fila.Item("montoefectivo"), "###,###,###.00"), 2))
                        obj.EscribirLinea(y + s, 71 - iLinea, FormatNumber(Format(fila.Item("montoefectivo"), "###,###,###.00"), 2))
                    End If

                    totalFacturaPsje += IIf(IsDBNull(fila.Item("montoefectivo")), 0, fila.Item("montoefectivo"))
                    s += 1
                Next
            Else
                For Each fila As DataRow In dtListaTotalesPsjes.Tables(1).Rows
                    If Len(fila.Item("USUARIO")) > 40 Then
                        fila.Item("USUARIO") = fila.Item("USUARIO").ToString.Substring(0, 40)
                    End If
                    obj.EscribirLinea(y + s, 10, fila.Item("USUARIO")) 'cambio 

                    If Trim(fila.Item("montoefectivo").ToString) = "" Then
                        iLinea = Len("0.00")
                        obj.EscribirLinea(y + s, 71 - iLinea, "0.00")
                    Else
                        iLinea = Len(FormatNumber(Format(fila.Item("montoefectivo"), "###,###,###.00"), 2))
                        obj.EscribirLinea(y + s, 71 - iLinea, FormatNumber(Format(fila.Item("montoefectivo"), "###,###,###.00"), 2))
                    End If
                    totalFacturaPsje += IIf(IsDBNull(fila.Item("montoefectivo")), 0, fila.Item("montoefectivo"))
                    s += 1
                Next
            End If


            obj.EscribirLinea(y + s + 1, 10, "Total")
            obj.EscribirLinea(y + s, 10, "-----------------------------------")
            obj.EscribirLinea(y + s, 61, "-----------")
            iLinea = Len(IIf(totalFacturaPsje = 0, "0.00", FormatNumber(Format(totalFacturaPsje, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 1, 71 - iLinea, IIf(totalFacturaPsje = 0, "0.00", FormatNumber(Format(totalFacturaPsje, "###,###,###.00"), 2)))


            obj.EscribirLinea(y + s + 3, 10, "VENTA CARGA")
            obj.EscribirLinea(y + s + 3, 61, "Factura")
            obj.EscribirLinea(y + s + 3, 79, "Boleta")
            obj.EscribirLinea(y + s + 3, 93, "PCE")
            obj.EscribirLinea(y + s + 3, 103, "Credito")
            obj.EscribirLinea(y + s + 4, 10, "------------")


            s += 5
            For Each fila As DataRow In ldt_cur_datos_venta.Rows
                obj.EscribirLinea(y + s, 10, fila.Item("NOMBRE")) 'cambio 

                If Trim(fila.Item("TOTAL_MONTO_FACTU").ToString) = "" Then
                    iLinea = Len("0.00")
                    obj.EscribirLinea(y + s, 71 - iLinea, "0.00")
                Else
                    iLinea = Len(FormatNumber(Format(fila.Item("TOTAL_MONTO_FACTU"), "###,###,###.00"), 2))
                    obj.EscribirLinea(y + s, 71 - iLinea, FormatNumber(Format(fila.Item("TOTAL_MONTO_FACTU"), "###,###,###.00"), 2))
                End If

                If Trim(fila.Item("TOTAL_MONTO_BOLE").ToString) = "" Then
                    iLinea = Len("0.00")
                    obj.EscribirLinea(y + s, 86 - iLinea, "0.00")
                Else
                    iLinea = Len(FormatNumber(Format(fila.Item("TOTAL_MONTO_BOLE"), "###,###,###.00"), 2))
                    obj.EscribirLinea(y + s, 86 - iLinea, FormatNumber(Format(fila.Item("TOTAL_MONTO_BOLE"), "###,###,###.00"), 2))
                End If

                If Trim(fila.Item("TOTAL_MONTO_PAGO_ENTRE").ToString) = "" Then
                    iLinea = Len("0.00")
                    obj.EscribirLinea(y + s, 99 - iLinea, "0.00")
                Else
                    iLinea = Len(FormatNumber(Format(fila.Item("TOTAL_MONTO_PAGO_ENTRE"), "###,###,###.00"), 2))
                    obj.EscribirLinea(y + s, 99 - iLinea, FormatNumber(Format(fila.Item("TOTAL_MONTO_PAGO_ENTRE"), "###,###,###.00"), 2))
                End If

                If Trim(fila.Item("total_Credito").ToString) = "" Then
                    iLinea = Len("0.00")
                    obj.EscribirLinea(y + s, 112 - iLinea, "0.00")
                Else
                    iLinea = Len(FormatNumber(Format(fila.Item("total_Credito"), "###,###,###.00"), 2))
                    obj.EscribirLinea(y + s, 112 - iLinea, FormatNumber(Format(fila.Item("total_Credito"), "###,###,###.00"), 2))
                End If

                totalFacturaCarga += IIf(IsDBNull(fila.Item("TOTAL_MONTO_FACTU")), 0, fila.Item("TOTAL_MONTO_FACTU"))
                totalBoletaCarga += IIf(IsDBNull(fila.Item("TOTAL_MONTO_BOLE")), 0, fila.Item("TOTAL_MONTO_BOLE"))
                totalPCECarga += IIf(IsDBNull(fila.Item("TOTAL_MONTO_PAGO_ENTRE")), 0, fila.Item("TOTAL_MONTO_PAGO_ENTRE"))
                TotalMontoTarjeVisa += IIf(IsDBNull(fila.Item("total_monto_tarje_Visa")), 0, fila.Item("total_monto_tarje_Visa"))
                TotalMontoTarjeMaster += IIf(IsDBNull(fila.Item("total_monto_tarje_Master")), 0, fila.Item("total_monto_tarje_Master"))
                TotalCredito += IIf(IsDBNull(fila.Item("total_Credito")), 0, fila.Item("total_Credito"))
                totalDevolucionCarga += IIf(IsDBNull(fila.Item("Total_DevolucionCarga")), 0, fila.Item("Total_DevolucionCarga"))
                totalEncomiendaCortesia += IIf(IsDBNull(fila.Item("Total_Encomiendas_Cortesia")), 0, fila.Item("Total_Encomiendas_Cortesia"))
                NCCarga += IIf(IsDBNull(fila.Item("nc")), 0, fila.Item("nc"))
                NCBoleta += IIf(IsDBNull(fila.Item("pagonc_boleta")), 0, fila.Item("pagonc_boleta"))
                NCFactura += IIf(IsDBNull(fila.Item("pagonc_factura")), 0, fila.Item("pagonc_factura"))

                TotalOtrosIngresos += IIf(IsDBNull(fila.Item("total_monto_otros")), 0, fila.Item("total_monto_otros"))
                TotalOtrosIngresosTarjeta += IIf(IsDBNull(fila.Item("total_monto_tarjeta_otros")), 0, fila.Item("total_monto_tarjeta_otros"))

                s += 1
            Next

            obj.EscribirLinea(y + s + 1, 10, "Total")
            obj.EscribirLinea(y + s, 10, "-----------------------------------")
            obj.EscribirLinea(y + s, 61, "-----------")
            obj.EscribirLinea(y + s, 75, "-----------")
            obj.EscribirLinea(y + s, 89, "----------")
            obj.EscribirLinea(y + s, 103, "----------")
            iLinea = Len(IIf(totalFacturaCarga = 0, "0.00", FormatNumber(Format(totalFacturaCarga, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 1, 71 - iLinea, IIf(totalFacturaCarga = 0, "0.00", FormatNumber(Format(totalFacturaCarga, "###,###,###.00"), 2))) '  ,967.50
            iLinea = Len(IIf(totalBoletaCarga = 0, "0.00", FormatNumber(Format(totalBoletaCarga, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 1, 86 - iLinea, IIf(totalBoletaCarga = 0, "0.00", FormatNumber(Format(totalBoletaCarga, "###,###,###.00"), 2)))
            iLinea = Len(IIf(totalPCECarga = 0, "0.00", FormatNumber(Format(totalPCECarga, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 1, 99 - iLinea, IIf(totalPCECarga = 0, "0.00", FormatNumber(Format(totalPCECarga, "###,###,###.00"), 2)))
            iLinea = Len(IIf(TotalCredito = 0, "0.00", FormatNumber(Format(TotalCredito, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 1, 112 - iLinea, IIf(TotalCredito = 0, "0.00", FormatNumber(Format(TotalCredito, "###,###,###.00"), 2)))


            Dim iReciboCajaPrepagada As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", ""))
            Dim iDelivery As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("DELIVERY")), 0, dtGastosLiquidacion.Rows(0).Item("DELIVERY"))
            Dim iOtrosIngresos As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS")), 0, dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS"))
            Dim iVentaSegurosPaxfre As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TOTAL_SEGURO_PAXFRE")), 0, dtGastosLiquidacion.Rows(0).Item("TOTAL_SEGURO_PAXFRE"))
            Dim iVentaSegurosPaxNor As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TOTAL_SEGURO_PAXNOR")), 0, dtGastosLiquidacion.Rows(0).Item("TOTAL_SEGURO_PAXNOR"))
            'Dim iTotalVentaSeguros As Double = iVentaSegurosPaxfre + iVentaSegurosPaxNor
            Dim poolVentaTotal As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("POOL_TOTAL_VENTA")), 0, dtGastosLiquidacion.Rows(0).Item("POOL_TOTAL_VENTA"))
            'Dim poolVentaVisa As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("POOL_VENTA_VISA")), 0, dtGastosLiquidacion.Rows(0).Item("POOL_VENTA_VISA"))
            Dim pagoEfectivoTotal As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(PAGO_EFECTIVO)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(PAGO_EFECTIVO)", ""))
            Dim poolVentaMAstercard As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("POOL_VENTA_MASTERCARD")), 0, dtGastosLiquidacion.Rows(0).Item("POOL_VENTA_MASTERCARD"))


            poolVentaMAstercard = 0

            TotalOtrosIngresosTarjeta = 0
            TotalOtrosIngresos = 0
            iOtrosIngresos += TotalOtrosIngresos + TotalOtrosIngresosTarjeta

            obj.EscribirLinea(y + s + 3, 10, "OTROS INGRESOS")
            obj.EscribirLinea(y + s + 4, 10, "------------")
            obj.EscribirLinea(y + s + 5, 10, "Recibo. Caja Prepagada")
            iLinea = Len(IIf(iReciboCajaPrepagada = 0, "0.00", FormatNumber(Format(iReciboCajaPrepagada, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 5, 71 - iLinea, IIf(iReciboCajaPrepagada = 0, "0.00", FormatNumber(Format(iReciboCajaPrepagada, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 6, 10, "Delivery")
            iLinea = Len(IIf(iDelivery = 0, "0.00", FormatNumber(Format(iDelivery, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 6, 71 - iLinea, IIf(iDelivery = 0, "0.00", FormatNumber(Format(iDelivery, "###,###,###.00"), 2))) '

            obj.EscribirLinea(y + s + 7, 10, "Otros Ingresos (Fotocopias, etc.)") '2 
            iLinea = Len(IIf(iOtrosIngresos = 0, "0.00", FormatNumber(Format(iOtrosIngresos, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 7, 71 - iLinea, IIf(iOtrosIngresos = 0, "0.00", FormatNumber(Format(iOtrosIngresos, "###,###,###.00"), 2)))

            '-->End Begin - jabanto 20/10/2016
            'obj.EscribirLinea(y + s + 8, 10, "Venta de Seguros ") '2 
            'iLinea = Len(IIf(iTotalVentaSeguros = 0, "0.00", FormatNumber(Format(iTotalVentaSeguros, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 8, 71 - iLinea, IIf(iTotalVentaSeguros = 0, "0.00", FormatNumber(Format(iTotalVentaSeguros, "###,###,###.00"), 2)))

            '-->Begin - jabanto 20/10/2016
            'obj.EscribirLinea(y + s + 8, 10, "Venta Pool - Pasajes") '2 
            'iLinea = Len(IIf(poolVentaTotal = 0, "0.00", FormatNumber(Format(poolVentaTotal, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 8, 71 - iLinea, IIf(poolVentaTotal = 0, "0.00", FormatNumber(Format(poolVentaTotal, "###,###,###.00"), 2)))
            poolVentaTotal = 0

            obj.EscribirLinea(y + s + 9, 10, "------------------------------")
            obj.EscribirLinea(y + s + 9, 61, "------------")
            obj.EscribirLinea(y + s + 10, 10, "Total")

            Dim iTotalIngresos As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", "") +
                                             IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("DELIVERY")), 0, dtGastosLiquidacion.Rows(0).Item("DELIVERY")) +
                                             IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS")), 0, dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS")) +
                                             TotalOtrosIngresos + TotalOtrosIngresosTarjeta +
                                             poolVentaTotal) '+iTotalVentaSeguros)

            iLinea = Len(IIf(iTotalIngresos = 0, "0.00", FormatNumber(Format(iTotalIngresos, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 10, 71 - iLinea, IIf(iTotalIngresos = 0, "0.00", FormatNumber(Format(iTotalIngresos, "###,###,###.00"), 2)))

            'hlamas 14-06-2017
            'se agrega pagos con nota de credito referencial, los montos ya estan cargados en el efectivo
            Dim intFilas As Integer, intFilasNC As Integer = 12
            If NCBoleta > 0 Then
                intFilas = 4
                iLinea = Len(Trim(IIf(NCBoleta = 0, "0.00", FormatNumber(Format(NCBoleta, "###,###,###.00"), 2))))
                obj.EscribirLinea(y + s + intFilasNC, 10, "NC. Boleta")
                obj.EscribirLinea(y + s + intFilasNC, 71 - iLinea, IIf(NCBoleta = 0, "0.00", FormatNumber(Format(NCBoleta, "###,###,###.00"), 2)))
            End If
            If NCFactura > 0 Then
                intFilas += 4
                intFilasNC += IIf(NCBoleta > 0, 1, 0)
                obj.EscribirLinea(y + s + intFilasNC, 10, "NC. Factura")
                iLinea = Len(Trim(IIf(NCFactura = 0, "0.00", FormatNumber(Format(NCFactura, "###,###,###.00"), 2))))
                obj.EscribirLinea(y + s + intFilasNC, 71 - iLinea, IIf(NCFactura = 0, "0.00", FormatNumber(Format(NCFactura, "###,###,###.00"), 2)))
            End If
            If NCBoleta + NCFactura > 0 Then
                obj.EscribirLinea(y + s + intFilasNC + 1, 61, "------------")
                obj.EscribirLinea(y + s + intFilasNC + 2, 10, "Total")
                iLinea = Len(Trim(IIf(NCBoleta + NCFactura = 0, "0.00", FormatNumber(Format(NCBoleta + NCFactura, "###,###,###.00"), 2))))
                obj.EscribirLinea(y + s + intFilasNC + 2, 71 - iLinea, IIf(NCBoleta + NCFactura = 0, "0.00", FormatNumber(Format(NCBoleta + NCFactura, "###,###,###.00"), 2)))
                If NCBoleta > 0 And NCFactura > 0 Then
                    intFilas -= 3
                End If
            End If

            '====EGRESOS================================
            Dim VentaPasajeCredito As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CREDITO)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CREDITO)", ""))
            Dim VentaPasajePrepagado As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_PREPAGADOS)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_PREPAGADOS)", ""))
            Dim VentaPasajeCortesia As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CORTESIA)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CORTESIA)", ""))
            Dim NCPasaje As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(NC)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(NC)", ""))

            obj.EscribirLinea(y + s + 12 + intFilas, 10, "EGRESOS")
            obj.EscribirLinea(y + s + 13 + intFilas, 10, "--------------")
            obj.EscribirLinea(y + s + 14 + intFilas, 10, "Venta Pasaje Credito")
            iLinea = Len(IIf(VentaPasajeCredito = 0, "0.00", FormatNumber(Format(VentaPasajeCredito, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 14 + intFilas, 71 - iLinea, IIf(VentaPasajeCredito = 0, "0.00", FormatNumber(Format(VentaPasajeCredito, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 15 + intFilas, 10, "Venta Pasaje Prepagados")
            iLinea = Len(IIf(VentaPasajePrepagado = 0, "0.00", FormatNumber(Format(VentaPasajePrepagado, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 15 + intFilas, 71 - iLinea, IIf(VentaPasajePrepagado = 0, "0.00", FormatNumber(Format(VentaPasajePrepagado, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 16 + intFilas, 10, "Venta Pasaje Cortesia")
            iLinea = Len(IIf(VentaPasajeCortesia = 0, "0.00", FormatNumber(Format(VentaPasajeCortesia, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 16 + intFilas, 71 - iLinea, IIf(VentaPasajeCortesia = 0, "0.00", FormatNumber(Format(VentaPasajeCortesia, "###,###,###.00"), 2)))

            'New
            obj.EscribirLinea(y + s + 17 + intFilas, 10, "Venta Carga Cortesia") 'carga
            iLinea = Len(IIf(totalEncomiendaCortesia = 0, "0.00", FormatNumber(Format(totalEncomiendaCortesia, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 17 + intFilas, 71 - iLinea, IIf(totalEncomiendaCortesia = 0, "0.00", FormatNumber(Format(totalEncomiendaCortesia, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 18 + intFilas, 10, "Venta Carga PCE")
            iLinea = Len(IIf(totalPCECarga = 0, "0.00", FormatNumber(Format(totalPCECarga, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 18 + intFilas, 71 - iLinea, IIf(totalPCECarga = 0, "0.00", FormatNumber(Format(totalPCECarga, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 19 + intFilas, 10, "Venta Carga Credito")
            iLinea = Len(IIf(TotalCredito = 0, "0.00", FormatNumber(Format(TotalCredito, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 19 + intFilas, 71 - iLinea, IIf(TotalCredito = 0, "0.00", FormatNumber(Format(TotalCredito, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 20 + intFilas, 10, "Venta Seguros Pasajero Frecuente")
            iLinea = Len(IIf(iVentaSegurosPaxfre = 0, "0.00", FormatNumber(Format(iVentaSegurosPaxfre, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 20 + intFilas, 71 - iLinea, IIf(iVentaSegurosPaxfre = 0, "0.00", FormatNumber(Format(iVentaSegurosPaxfre, "###,###,###.00"), 2)))


            obj.EscribirLinea(y + s + 21 + intFilas, 10, "------------------------------")
            obj.EscribirLinea(y + s + 21 + intFilas, 61, "------------")
            obj.EscribirLinea(y + s + 22 + intFilas, 10, "Total")
            Dim itotalEgreso1 As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CREDITO)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CREDITO)", "")) + _
                              IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_PREPAGADOS)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_PREPAGADOS)", "")) + _
                              IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CORTESIA)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CORTESIA)", "")) + _
                              IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(NC)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(NC)", "")) + _
                              FormatNumber(totalPCECarga, 2) + TotalCredito + totalEncomiendaCortesia + iVentaSegurosPaxfre
            'Abs(nc) + _

            iLinea = Len(IIf(itotalEgreso1 = 0, "0.00", FormatNumber(Format(itotalEgreso1, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 22 + intFilas, 71 - iLinea, IIf(itotalEgreso1 = 0, "0.00", FormatNumber(Format(itotalEgreso1, "###,###,###.00"), 2)))

            Dim iTarjetaVisaPasaje As Double, iTarjetaMasterCard As Double
            If iOpcion = 0 Then
                iTarjetaVisaPasaje = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(TARJETA_VISA_PASAJE)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(TARJETA_VISA_PASAJE)", ""))
                iTarjetaMasterCard = 0
            Else
                iTarjetaVisaPasaje = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(TARJETA_VISA_PASAJE)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(TARJETA_VISA_PASAJE)", ""))
                iTarjetaMasterCard = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(TARJETA_MASTER_PASAJE)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(TARJETA_MASTER_PASAJE)", ""))
            End If


            obj.EscribirLinea(y + s + 24, 10, "PagoEfectivo")
            iLinea = Len(IIf(pagoEfectivoTotal = 0, "0.00", FormatNumber(Format(pagoEfectivoTotal, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 24, 71 - iLinea, IIf(pagoEfectivoTotal = 0, "0.00", FormatNumber(Format(pagoEfectivoTotal, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 25 + intFilas, 10, "TC. Visa Pasaje")
            iLinea = Len(IIf(iTarjetaVisaPasaje = 0, "0.00", FormatNumber(Format(iTarjetaVisaPasaje, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 25 + intFilas, 71 - iLinea, IIf(iTarjetaVisaPasaje = 0, "0.00", FormatNumber(Format(iTarjetaVisaPasaje, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 26 + intFilas, 10, "TC. Master Pasaje")
            iLinea = Len(IIf(iTarjetaMasterCard = 0, "0.00", FormatNumber(Format(iTarjetaMasterCard + poolVentaMAstercard, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 26 + intFilas, 71 - iLinea, IIf(iTarjetaMasterCard = 0, "0.00", FormatNumber(Format(iTarjetaMasterCard + poolVentaMAstercard, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 27 + intFilas, 10, "TC. Visa Carga")
            iLinea = Len(IIf(TotalMontoTarjeVisa = 0, "0.00", FormatNumber(Format(TotalMontoTarjeVisa, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 27 + intFilas, 71 - iLinea, IIf(TotalMontoTarjeVisa = 0, "0.00", FormatNumber(Format(TotalMontoTarjeVisa, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 28 + intFilas, 10, "TC. Mastercarga")
            iLinea = Len(IIf(TotalMontoTarjeMaster = 0, "0.00", FormatNumber(Format(TotalMontoTarjeMaster, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 28 + intFilas, 71 - iLinea, IIf(TotalMontoTarjeMaster = 0, "0.00", FormatNumber(Format(TotalMontoTarjeMaster, "###,###,###.00"), 2)))



            'obj.EscribirLinea(y + s + 28, 10, "Pool - TC. Visa Pasajes")
            'iLinea = Len(IIf(poolVentaVisa = 0, "0.00", FormatNumber(Format(poolVentaVisa, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 28, 71 - iLinea, IIf(poolVentaVisa = 0, "0.00", FormatNumber(Format(poolVentaVisa, "###,###,###.00"), 2)))

            'obj.EscribirLinea(y + s + 29, 10, "Pool - TC. Master Pasajes")
            'iLinea = Len(IIf(poolVentaMAstercard = 0, "0.00", FormatNumber(Format(poolVentaMAstercard, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 29, 71 - iLinea, IIf(poolVentaMAstercard = 0, "0.00", FormatNumber(Format(poolVentaMAstercard, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 29 + intFilas, 10, "------------------------------")
            obj.EscribirLinea(y + s + 29 + intFilas, 61, "------------")
            obj.EscribirLinea(y + s + 30 + intFilas, 10, "Total")
            Dim iTotalEgreso2 As Double = (TotalMontoTarjeVisa + TotalMontoTarjeMaster + iTarjetaVisaPasaje + iTarjetaMasterCard + pagoEfectivoTotal + poolVentaMAstercard)

            'New
            Dim iTotalGeneralMaster As Double = (TotalMontoTarjeMaster + iTarjetaMasterCard + poolVentaMAstercard)
            Dim iTotalGeneralVisa As Double = (TotalMontoTarjeVisa + iTarjetaVisaPasaje)
            obj.EscribirLinea(y + s + 29 + intFilas, 75, "-----------")
            obj.EscribirLinea(y + s + 29 + intFilas, 89, "------------------")
            obj.EscribirLinea(y + s + 28 + intFilas, 75, "Total Visa")
            obj.EscribirLinea(y + s + 28 + intFilas, 89, "Total Master Card")

            'iLinea = Len(IIf(iTotalGeneralVisa = 0, "0.00", FormatNumber(Format(iTotalGeneralVisa, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 27, 80 - iLinea, IIf(iTotalGeneralVisa = 0, "0.00", FormatNumber(Format(iTotalGeneralVisa, "###,###,###.00"), 2)))

            'iLinea = Len(IIf(iTotalGeneralMaster = 0, "0.00", FormatNumber(Format(iTotalGeneralMaster, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 27, 99 - iLinea, IIf(iTotalGeneralMaster = 0, "0.00", FormatNumber(Format(iTotalGeneralMaster, "###,###,###.00"), 2)))


            '---
            iLinea = Len(IIf(iTotalGeneralVisa = 0, "0.00", FormatNumber(Format(iTotalGeneralVisa, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 30 + intFilas, 78 - iLinea, IIf(iTotalGeneralVisa = 0, "0.00", Format(iTotalGeneralVisa, "###,###,###.00")))

            '---
            iLinea = Len(IIf(iTotalGeneralMaster = 0, "0.00", FormatNumber(Format(iTotalGeneralMaster, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 30 + intFilas, 99 - iLinea, IIf(iTotalGeneralMaster = 0, "0.00", FormatNumber(Format(iTotalGeneralMaster, "###,###,###.00"), 2)))
            '--


            iLinea = Len(IIf(iTotalEgreso2 = 0, "0.00", FormatNumber(Format(iTotalEgreso2, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 30 + intFilas, 71 - iLinea, IIf(iTotalEgreso2 = 0, "0.00", FormatNumber(Format(iTotalEgreso2, "###,###,###.00"), 2)))


            Dim iDevolucionesPasajes As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(DEVOLUCIONES_PASAJES)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(DEVOLUCIONES_PASAJES)", ""))
            obj.EscribirLinea(y + s + 33 + intFilas, 10, "Devoluciones Pasaje")
            iLinea = Len(IIf(iDevolucionesPasajes = 0, "0.00", FormatNumber(Format(iDevolucionesPasajes, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 33 + intFilas, 71 - iLinea, IIf(iDevolucionesPasajes = 0, "0.00", FormatNumber(Format(iDevolucionesPasajes, "###,###,###.00"), 2)))

            'New
            'obj.EscribirLinea(y + s + 29, 10, "Devoluciones Carga")
            'iLinea = Len(IIf(totalDevolucionCarga = 0, "0.00", FormatNumber(Format(totalDevolucionCarga, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 29, 71 - iLinea, IIf(totalDevolucionCarga = 0, "0.00", FormatNumber(Format(totalDevolucionCarga, "###,###,###.00"), 2))) 'p2
            Dim DEVOLUCION_DE_CARGA As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("DEVOLUCION_DE_CARGA")), 0, (dtGastosLiquidacion.Rows(0).Item("DEVOLUCION_DE_CARGA")))
            obj.EscribirLinea(y + s + 34 + intFilas, 10, "Devoluciones Carga") '
            iLinea = Len(IIf(DEVOLUCION_DE_CARGA = 0, "0.00", FormatNumber(Format(DEVOLUCION_DE_CARGA, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 34 + intFilas, 71 - iLinea, IIf(DEVOLUCION_DE_CARGA = 0, "0.00", FormatNumber(Format(DEVOLUCION_DE_CARGA, "###,###,###.00"), 2))) 'Carga

            obj.EscribirLinea(y + s + 35 + intFilas, 10, "------------------------------")
            obj.EscribirLinea(y + s + 35 + intFilas, 61, "------------")
            obj.EscribirLinea(y + s + 36 + intFilas, 10, "Total")
            Dim iTotalEgreso3 As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(DEVOLUCIONES_PASAJES)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(DEVOLUCIONES_PASAJES)", ""))

            iLinea = Len(IIf(iTotalEgreso3 = 0, "0.00", FormatNumber(Format(iTotalEgreso3, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 36 + intFilas, 71 - iLinea, IIf(iTotalEgreso3 = 0, "0.00", FormatNumber(Format(iTotalEgreso3, "###,###,###.00"), 2)))


            '============================================================
            Dim TRANSFERENCIA_BANCARIA As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TRANSFERENCIA_BANCARIA")), 0, (dtGastosLiquidacion.Rows(0).Item("TRANSFERENCIA_BANCARIA")))
            Dim Gastos_Varios As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("GASTOS_VARIOS")), 0, (dtGastosLiquidacion.Rows(0).Item("GASTOS_VARIOS")))
            Dim PAGO_PEAJE_FUERA_DEL_COUNT As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("PAGO_PEAJE_FUERA_DEL_COUNT")), 0, (dtGastosLiquidacion.Rows(0).Item("PAGO_PEAJE_FUERA_DEL_COUNT")))
            Dim GASTOS_CON_RECIBO_DE_CAJA As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("GASTOS_CON_RECIBO_DE_CAJA")), 0, (dtGastosLiquidacion.Rows(0).Item("GASTOS_CON_RECIBO_DE_CAJA")))
            Dim PAGO_GIROS As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("PAGO_GIROS")), 0, (dtGastosLiquidacion.Rows(0).Item("PAGO_GIROS")))

            obj.EscribirLinea(y + s + 38 + intFilas, 10, "Transferencia Bancarias")
            iLinea = Len(IIf(TRANSFERENCIA_BANCARIA = 0, "0.00", FormatNumber(Format(TRANSFERENCIA_BANCARIA, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 38 + intFilas, 71 - iLinea, IIf(TRANSFERENCIA_BANCARIA = 0, "0.00", FormatNumber(Format(TRANSFERENCIA_BANCARIA, "###,###,###.00"), 2)))

            'obj.EscribirLinea(y + s + 34, 10, "Encomiendas Cortesia") 'carga
            'iLinea = Len(IIf(totalEncomiendaCortesia = 0, "0.00", FormatNumber(Format(totalEncomiendaCortesia, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 34, 71 - iLinea, IIf(totalEncomiendaCortesia = 0, "0.00", FormatNumber(Format(totalEncomiendaCortesia, "###,###,###.00"), 2)))

            'obj.EscribirLinea(y + s + 35, 10, "Devoluciones de Encomiendas") '
            'iLinea = Len(IIf(DEVOLUCION_DE_CARGA = 0, "0.00", FormatNumber(Format(DEVOLUCION_DE_CARGA, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 35, 71 - iLinea, IIf(DEVOLUCION_DE_CARGA = 0, "0.00", FormatNumber(Format(DEVOLUCION_DE_CARGA, "###,###,###.00"), 2))) 'Carga

            obj.EscribirLinea(y + s + 39 + intFilas, 10, "Gastos Varios")
            iLinea = Len(IIf(Gastos_Varios = 0, "0.00", FormatNumber(Format(Gastos_Varios, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 39 + intFilas, 71 - iLinea, IIf(Gastos_Varios = 0, "0.00", FormatNumber(Format(Gastos_Varios, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 40 + intFilas, 10, "Peajes(Inc. Fuera del Counter)") '
            iLinea = Len(IIf(PAGO_PEAJE_FUERA_DEL_COUNT = 0, "0.00", FormatNumber(Format(PAGO_PEAJE_FUERA_DEL_COUNT, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 40 + intFilas, 71 - iLinea, IIf(PAGO_PEAJE_FUERA_DEL_COUNT = 0, "0.00", FormatNumber(Format(PAGO_PEAJE_FUERA_DEL_COUNT, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 41 + intFilas, 10, "Giros Pagados") '
            iLinea = Len(IIf(PAGO_GIROS = 0, "0.00", FormatNumber(Format(PAGO_GIROS, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 41 + intFilas, 71 - iLinea, IIf(PAGO_GIROS = 0, "0.00", FormatNumber(Format(PAGO_GIROS, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 42 + intFilas, 10, "Gastos con Recibos de Caja") '
            iLinea = Len(IIf(GASTOS_CON_RECIBO_DE_CAJA = 0, "0.00", FormatNumber(Format(GASTOS_CON_RECIBO_DE_CAJA, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 42 + intFilas, 71 - iLinea, IIf(GASTOS_CON_RECIBO_DE_CAJA = 0, "0.00", FormatNumber(Format(GASTOS_CON_RECIBO_DE_CAJA, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 43 + intFilas, 10, "------------------------------")
            obj.EscribirLinea(y + s + 43 + intFilas, 61, "------------")
            obj.EscribirLinea(y + s + 44 + intFilas, 10, "Total")
            Dim iTotalEgreso4 As Double = (TRANSFERENCIA_BANCARIA + _
                                           DEVOLUCION_DE_CARGA + _
                                           Gastos_Varios + _
                                           PAGO_PEAJE_FUERA_DEL_COUNT + _
                                           GASTOS_CON_RECIBO_DE_CAJA + _
                                           PAGO_GIROS
                                           )

            iLinea = Len(IIf(iTotalEgreso4 = 0, "0.00", FormatNumber(Format(iTotalEgreso4, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 44, 71 - iLinea, IIf(iTotalEgreso4 = 0, "0.00", FormatNumber(Format(iTotalEgreso4, "###,###,###.00"), 2)))

            'Nota de Credito
            obj.EscribirLinea(y + s + 46 + intFilas, 10, "NC Carga") '
            iLinea = Len(IIf(NCCarga = 0, "0.00", FormatNumber(Format(NCCarga, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 46 + intFilas, 71 - iLinea, IIf(NCCarga = 0, "0.00", FormatNumber(Format(NCCarga, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 47 + intFilas, 10, "NC Pasaje") '
            iLinea = Len(IIf(NCPasaje = 0, "0.00", FormatNumber(Format(NCPasaje, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 47 + intFilas, 71 - iLinea, IIf(NCPasaje = 0, "0.00", FormatNumber(Format(NCPasaje, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 48 + intFilas, 10, "------------------------------")
            obj.EscribirLinea(y + s + 48 + intFilas, 61, "------------")
            obj.EscribirLinea(y + s + 49 + intFilas, 10, "Total")
            iLinea = Len(IIf(NCCarga + NCPasaje = 0, "0.00", FormatNumber(Format(NCCarga + NCPasaje, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 49 + intFilas, 71 - iLinea, IIf(NCCarga + NCPasaje = 0, "0.00", FormatNumber(Format(NCCarga + NCPasaje, "###,###,###.00"), 2)))


            Dim iTotalGeneralIngresos As Double = totalFacturaPsje + totalBoletaPsje + totalPCEPsje + totalFacturaCarga + totalBoletaCarga + totalPCECarga + TotalCredito + iTotalIngresos
            Dim iTotalEgresos As Double = itotalEgreso1 + iTotalEgreso2 + iTotalEgreso3 + iTotalEgreso4
            Dim iSaldoDepositar As Double = (totalFacturaPsje + totalBoletaPsje + totalPCEPsje + totalFacturaCarga + totalBoletaCarga + totalPCECarga + TotalCredito + iTotalIngresos) - (itotalEgreso1 + iTotalEgreso2 + iTotalEgreso3 + iTotalEgreso4)

            obj.EscribirLinea(y + s + 51 + intFilas, 10, "-----------------------------")
            obj.EscribirLinea(y + s + 51 + intFilas, 61, "------------")
            obj.EscribirLinea(y + s + 52 + intFilas, 10, "Total Ingresos")
            iLinea = Len(IIf(iTotalGeneralIngresos = 0, "0.00", FormatNumber(Format(iTotalGeneralIngresos, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 52 + intFilas, 71 - iLinea, IIf(iTotalGeneralIngresos = 0, "0.00", FormatNumber(Format(iTotalGeneralIngresos, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 53 + intFilas, 10, "Total Egresos")
            iLinea = Len(IIf(iTotalEgresos = 0, "0.00", FormatNumber(Format(iTotalEgresos, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 53 + intFilas, 71 - iLinea, IIf(iTotalEgresos = 0, "0.00", FormatNumber(Format(iTotalEgresos, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 54 + intFilas, 10, "Saldo a Depositar")
            iLinea = Len(IIf(iSaldoDepositar = 0, "0.00", FormatNumber(Format(iSaldoDepositar, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 54 + intFilas, 71 - iLinea, IIf(iSaldoDepositar = 0, "0.00", FormatNumber(Format(iSaldoDepositar, "###,###,###.00"), 2)))



            obj.Comprimido = True
            obj.Preliminar = True
            obj.Tamaño = iLong
            obj.ReglaVertical = False
            obj.Imprimir()
            obj.Finalizar()

            Dim frm As New FrmPreview
            frm.WindowState = FormWindowState.Maximized
            frm.Tamaño = iLong
            frm.Documento = 1
            frm.Text = "Factura"
            frm.ShowDialog()

            objImprimir = Nothing
            objImpresora = Nothing
        Catch ex As Exception
            obj.Finalizar()
            Throw New Exception(ex.Message)
        End Try
    End Sub

#Region "Consultas v&R"
    'Dim cnn As OdbcConnection '-> Conexion Mysql 
    Dim cnn As System.Data.OracleClient.OracleConnection '-> Conexion ORACLE 
    'Sub ConexionPasajes()
    '    'cnn = New System.Data.Odbc.OdbcConnection("DRIVER={MySQL ODBC 3.51 Driver};SERVER=192.168.200.241;DATABASE=Tepsa;UID=ventas;PWD=10913035110;OPTION=18475")
    '    '--> Conexio a la Base de datos del sisvyr (oracle) data source=sanluis;user id=titan;password=titan;
    '    'cnn = New System.Data.Odbc.OdbcConnection("DRIVER={MySQL ODBC 3.51 Driver};SERVER=192.168.200.241;DATABASE=VYR;UID=vyr;PWD=ventas5110;")
    '    cnn = New System.Data.OracleClient.OracleConnection("data source=VYR; password=ventas5110; user id=vyr")
    'End Sub
    'CONSULTA LAS CAJAS CERRADAS EN EL DIA DE LIQUIDACION APERTURADO DE ACUERDO A LA OFICINA QUE APERTURO
    'PERO NO ASOCIADAS A NINGUNA LIQUIDACION 
    Dim dtCounterPsjesDesasociadas As DataTable
    'Sub ListaCounterPsjesDesasociadas()
    '    Dim IDConcesionario As Integer = ObtieneTipoDocumento(dtoUSUARIOS.iIDAGENCIAS)
    '    If IDConcesionario <> 0 Then
    '        Dim fecha As Date = CboFechaLiquidacion.Value.Year.ToString & " - " & CboFechaLiquidacion.Value.Month.ToString & " - " & CboFechaLiquidacion.Value.Day.ToString
    '        'Strings.Right(LblFecha.Text, 4) & "-" & Mid(LblFecha.Text, 4, 2) & "-" & Strings.Left(LblFecha.Text, 2) 'dtoUSUARIOS.m_sFecha
    '        Me.ConexionPasajes()
    '        Dim sql As String
    '        sql = "select L.idLiquidacionTurno as idliqui_turnos,L.idUsuarioSistema as idusuario_personal,L.EfectivoIngresado,"
    '        sql = sql & "(L.TotalVentaContado + L.TotalPrepagado  + L.TotalCredito  + L.TotalCortesia ) MontoEfectivo,"
    '        sql = sql & "U.UsuarioSistema as Login, concat(U.ApellidoPaterno, ' ', U.ApellidoMaterno, ' ', U.Nombres,' [Psjes]') Nombre,"
    '        sql = sql & "L.CantidadVentaContado CANTCONTADO,L.TotalVentaContado TOTVTACONTADO,L.CantidadPrepagado CANTPREPA,"
    '        sql = sql & "L.TotalPrepagado TOTPREPA,L.CantidadCredito CANTCRED, L.TotalCredito TOTCRED,"
    '        sql = sql & "L.CantidadCortesia CANTCORTE, L.TotalCortesia TOTCORTE,L.CantidadReciboCajaPrepaga CANTRECIBO,"
    '        sql = sql & "L.TotalReciboCajaPrepagados TOTRECIBO,L.CantidadCobradoVoucher CANTTC, L.TotalCobradoVoucher TOTTC,"
    '        sql = sql & "L.CantidadPeajes CANTPEAJES, L.TotalPeajes TOTPEAJES,L.CantidadDevolucionPasajes CANTDEVPSJES,"
    '        sql = sql & "L.TotalDevolucionPasajes TOTDEVPSJES,L.TotalGastosVarios TOTGASTOS "
    '        sql = sql & "from LiquidacionTurno L, UsuariosSistema U "
    '        sql = sql & "where L.idUsuarioSistema = U.idUsuarioSistema and L.FechaDiaLiquidacion='" & fecha.ToString("yyyy/MM/dd") & "' and "
    '        sql = sql & "L.idConcesionario=" & IDConcesionario & " and L.LiquidacionEstado = 1  order by Nombre" 'and idLiquidacionOficina=0

    '        dtCounterPsjesDesasociadas = ObtieneDT(sql)

    '    Else
    '        MessageBox.Show("El Id Concesionario no puede ser cero (0)", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '    End If
    'End Sub

    Dim dtCounterPsjesAsociadas As DataTable

    Dim dtCajasAperturadasPsjes As DataTable
    'Sub ListaCajasAperturadasPsjes()
    '    Dim IDConcesionario As Integer = ObtieneTipoDocumento(dtoUSUARIOS.iIDAGENCIAS)
    '    Dim fecha As Date = dtoUSUARIOS.m_sFecha
    '    Me.ConexionPasajes()
    '    Dim sql As String
    '    '17/01/2014 - JABANTO
    '    sql = "SELECT u.c_apepat||' '||u.c_apemat||' '||u.c_nombre||' [Psjes]' As Usuario"
    '    sql += "    ,to_char(l.d_fecliq,'dd/mm/yyyy') As fechaLiq "
    '    sql += "    ,TO_CHAR(l.audfecins,'HH:MI:SS') AS horaLiq "
    '    sql += "    ,DECODE(L.N_ESTLIQ,1,'ABIERTO',0,'CERRADO') As estadoLiq "
    '    sql += "FROM VRTLIQUIDACION l  "
    '    sql += "    INNER JOIN VRMUSUARIO u ON (u.usuario_id=l.usuario_id) "
    '    sql += "WHERE l.d_fecliq='" & fecha.ToString("dd/MM/yyyy") & "' "
    '    sql += "    AND l.c_Estreg='A' "
    '    'sql += "   AND l.agencia_id=46 " '--> Pendiente por pasar parametro



    '    '"01/11/2012"        
    '    'concat(RIGHT(L.FECHALIQ,2),'/',Substring(L.FECHALIQ,6,2), '/', LEFT(L.FECHALIQ,4)) FECHALIQ

    '    'sql = "select concat(ApellidoPaterno, ' ', ApellidoMaterno, ' ', Nombres, ' [Psjes]') USUARIO,"
    '    'sql = sql & "DATE_FORMAT(L.FECHALIQ,'%d/%m/%Y') FECHALIQ, TIME_FORMAT(L.HORALIQ,'%H:%i:%s') HORALIQ, IF(L.LiquidacionEstado=1,""CERRADO"",""ABIERTO"") ESTADOLIQ "
    '    'sql = sql & "from (select "
    '    'sql = sql & "idLiquidacionTurno, left(FechaLiquidacion, 10) FECHALIQ,"
    '    'sql = sql & "right(FechaLiquidacion, 8) HORALIQ, idUsuarioSistema, LiquidacionEstado "
    '    'sql = sql & "from LiquidacionTurno "
    '    'sql = sql & "where idConcesionario='" & IDConcesionario & "' and FechaDiaLiquidacion='" & fecha.ToString("yyyy/MM/dd") & "') L "
    '    'sql = sql & "inner join UsuariosSistema U "
    '    'sql = sql & "on (L.idUsuarioSistema = U.idUsuarioSistema)"
    '    dtCajasAperturadasPsjes = ObtieneDT(sql)
    'End Sub

    'OBTIENE LOS TOTALES POR CUNTER DE ACUERDO A LA LIQUIDACION DE OFICINA ASOCIADA    
    'Sub ListaTotalesPsjes(ByVal IDLiquidacion As Integer)
    '    Me.ConexionPasajes() 
    '    Dim sql As String
    '    sql = "SELECT concat(ApellidoPaterno, ' ', ApellidoMaterno,  ' ', Nombres) USUARIO, L.* "
    '    sql = sql & "FROM (select "
    '    sql = sql & "idLiquidacionOficina IDLIQOFI, idLiquidacionTurno IDLIQTURNO, EfectivoIngresado EFEINGRE,"
    '    sql = sql & "CantidadVentaContado CANTCONTADO, TotalVentaContado TOTVTACONTADO,"
    '    sql = sql & "CantidadPrepagado CANTPREPA, TotalPrepagado TOTPREPA,"
    '    sql = sql & "CantidadCredito CANTCRED, TotalCredito TOTCRED,"
    '    sql = sql & "CantidadCortesia CANTCORTE, TotalCortesia TOTCORTE,"
    '    sql = sql & "CantidadReciboCajaPrepaga CANTRECIBO, TotalReciboCajaPrepagados TOTRECIBO,"
    '    sql = sql & "CantidadCobradoVoucher CANTTC, TotalCobradoVoucher TOTTC,"
    '    sql = sql & "CantidadPeajes CANTPEAJES, TotalPeajes TOTPEAJES,"
    '    sql = sql & "CantidadDevolucionPasajes CANTDEVPSJES, TotalDevolucionPasajes TOTDEVPSJES,"
    '    sql = sql & "TotalGastosVarios TOTGASTOS, left(FechaLiquidacion, 10) FECHACIERRE,"
    '    sql = sql & "RIGHT(FechaLiquidacion, 8) HORACIERRE, FechaDiaLiquidacion, idUsuarioSistema "
    '    sql = sql & "from LiquidacionTurno "
    '    sql = sql & "where idLiquidacionOficina='" & IDLiquidacion & "') L "
    '    sql = sql & "inner join UsuariosSistema U on (L.idUsuarioSistema = U.idUsuarioSistema) "
    '    sql = sql & "ORDER BY FECHACIERRE, HORACIERRE"
    '    dtListaTotalesPsjes = ObtieneDT(sql)
    'End Sub

#Region "TRANSFERENCIA DATOS PASAJES"
    Function ActualizaEstadoCTRCONTABLE(ByVal IDCounter As String)
        'Me.ConexionPasajes()
        Dim IDConcesionario As Integer = ObtieneTipoDocumento(dtoUSUARIOS.iIDAGENCIAS)
        Dim Fecha As String = Strings.Right(LblFecha.Text, 4) & "-" & Mid(LblFecha.Text, 4, 2) & "-" & Strings.Left(LblFecha.Text, 2) '"yyyy/MM/dd --21/01/2012
        Dim SqlUpdate As String = String.Empty
        SqlUpdate = "Update VtaPasajes "
        SqlUpdate = SqlUpdate & "Set CtrContable = 1 "
        SqlUpdate = SqlUpdate & "Where FechaActualizacion LIKE '" & Fecha & "%' and "
        SqlUpdate = SqlUpdate & "CtrContable = 0 and NroBoleto <> '' and "
        SqlUpdate = SqlUpdate & "idConcesionario = " & IDConcesionario & " and idUsuarioSistema in (" & IDCounter & ")"
        ActualizaDatos(SqlUpdate)
    End Function

    'Function ConsultaPase_pasajes(ByVal IDCounter As String) As DataTable
    '    'Me.ConexionPasajes()
    '    Dim IDConcesionario As Integer = ObtieneTipoDocumento(dtoUSUARIOS.iIDAGENCIAS)
    '    Dim Fecha As String = Strings.Right(LblFecha.Text, 4) & "-" & Mid(LblFecha.Text, 4, 2) & "-" & Strings.Left(LblFecha.Text, 2) '"yyyy/MM/dd --21/01/2012
    '    Dim sql As String

    '    sql = "SELECT "
    '    sql = sql & "B.idVenta,B.idClase,B.idItinerario,B.idCliente,B.RUC, B.Razon,"
    '    sql = sql & "B.Empresa,B.tipoDocEmpresa,B.idPasajero,B.DNI,B.tipoDocPasajero,"
    '    sql = sql & "B.apepatpas,B.apematpas,B.Nombrepas,B.Nombre1Pas,cast(B.FechaNacimiento as char) FechaNacimiento,"
    '    sql = sql & "B.OficinaVenta,B.idRuta,B.Origen,B.Destino,B.OficinaEmbarque,"
    '    sql = sql & "B.Serie,B.Numero,B.SerieRef,B.NumeroRef,B.NroControl,B.Asiento,"
    '    sql = sql & "cast(B.FechaPartida as char) FechaPartida,left(cast(B.HoraPartida as char),5) HoraPartida,left(cast(B.FechaLlegada as char),5) FechaLlegada ,left(cast(B.HoraLlegada as char),5) HoraLlegada,"
    '    sql = sql & "B.MontoBase,B.Recargo,B.Descuento,B.ACuenta,B.Penalidad,"
    '    sql = sql & "B.ConceptoPenalidad,B.NetoPagado,B.TipoDevolucion,B.idFormaPago,"
    '    sql = sql & "B.TipoTarjeta,cast(B.FechaVenta as char) FechaVenta,cast(B.HoraVenta as char) HoraVenta,B.idUsuarioSistema,"
    '    sql = sql & "B.UsuarioSistema,B.apepatUsuario,B.apematUsuario,B.nombreUsuario,"
    '    sql = sql & "B.Sexo,B.TipoTransaccion,B.Flags,B.TipoOperacion,"
    '    sql = sql & "B.CodigoCuenta,B.idTipoComprobante,B.RUC_AGENCIA "
    '    'sql = sql & "B.EfectivoIngresado " g
    '    sql = sql & "from ("
    '    sql = sql & "SELECT "
    '    sql = sql & "V.idVenta,V.idClase,V.idItinerario,V.idCliente,if(C.idTipoDocumento=8 and "
    '    sql = sql & "V.TipoOperacion<>'X',C.NroDocumento, 'null') as RUC,"
    '    sql = sql & "if(V.`TipoOperacion`='X', 'null', if(length(trim(C.RazonSocial))>0,"
    '    sql = sql & "trim(C.RazonSocial),'null')) as Razon,"
    '    sql = sql & "if(C.Empresa=0, 0, C.Empresa) Empresa,if(C.Empresa=0, 0, C.idTipoDocumento) tipoDocEmpresa,"
    '    sql = sql & "V.idPasajero,if(V.`TipoOperacion`='X', 'null',if(length(trim(P.NroDocumento))=0,"
    '    sql = sql & "'null',P.NroDocumento)) as DNI,"
    '    sql = sql & "P.idTipoDocumento tipoDocPasajero,trim(P.ApellidoPaterno) apepatpas,"
    '    sql = sql & "if(length(trim(P.ApellidoMaterno))=0,'null',trim(P.ApellidoMaterno)) apematpas,"
    '    sql = sql & "if(instr(trim(P.Nombres), ' ')=0,trim(P.Nombres),LEFT(trim(P.Nombres),"
    '    sql = sql & "INSTR(trim(P.Nombres), ' '))) Nombrepas,"
    '    sql = sql & "if(instr(trim(P.Nombres), ' ')=0,'null',substring(trim(P.Nombres),"
    '    sql = sql & "instr(trim(P.Nombres), ' ')+1,length(trim(P.Nombres)))) Nombre1Pas,"
    '    sql = sql & "ifnull(if(length(P.FechaNacimiento)<=0,'null',concat(right(P.FechaNacimiento, 2),"
    '    sql = sql & "'/', substring(P.FechaNacimiento, 6, 2),'/', left(P.FechaNacimiento, 4))), 'null') FechaNacimiento,"
    '    sql = sql & "if(CO.codConcesionario>5000, cast(CO.codConcesionario as unsigned),"
    '    sql = sql & "cast(5000+CO.codConcesionario as unsigned)) as OficinaVenta, V.idRuta,"
    '    sql = sql & "if(R.codCiudadOrigen>5000, cast(R.codCiudadOrigen as unsigned),"
    '    sql = sql & "cast(5000+R.codCiudadOrigen as unsigned)) Origen,"
    '    sql = sql & "if(R.codCiudadDestino>5000, cast(R.codCiudadDestino as unsigned),"
    '    sql = sql & "cast(5000+R.codCiudadDestino as unsigned)) Destino,"
    '    sql = sql & "if(A.codAgencia>5000, cast(A.codAgencia as unsigned), cast(5000+A.codAgencia as unsigned)) as OficinaEmbarque,"
    '    sql = sql & "left(V.NroBoleto, 3) Serie, right(V.NroBoleto, 7) Numero,"
    '    sql = sql & "if(V.NroBoletoRef='', 'null', left(V.NroBoletoRef, 3)) SerieRef, if(V.NroBoletoRef='',"
    '    sql = sql & "'null', right(V.NroBoletoRef, 7)) NumeroRef, V.NroControl,"
    '    sql = sql & "IF(V.`TipoOperacion`='X', 0, V.NroAsiento) as Asiento,"
    '    sql = sql & "concat(right(V.FechaPartida, 2), '/', substring(V.FechaPartida, 6,2),'/',"
    '    sql = sql & "left(V.FechaPartida, 4)) FechaPartida, left(cast(V.HoraPartida as char),5) HoraPartida, "
    '    sql = sql & "concat(right(V.FechaLlegada, 2), '/', substring(V.FechaLlegada, 6,2),'/', left(V.FechaLlegada, 4)) FechaLlegada, left(cast(V.HoraLlegada as char),5) HoraLlegada,"
    '    sql = sql & "if(V.`TipoOperacion`='X', 0, V.MontoBase) as MontoBase,"
    '    sql = sql & "if(V.`TipoOperacion`='X', 0,  (V.Recargo)) as Recargo,"
    '    sql = sql & "if(V.`TipoOperacion`='X', 0,  (V.Descuento)) as Descuento,"
    '    sql = sql & "if(V.`TipoOperacion`='X', 0, V.ACuenta) as ACuenta,"
    '    sql = sql & "if(V.`TipoOperacion`='X', 0, V.Penalidad) as Penalidad,"
    '    sql = sql & "if(length(V.ConceptoPenalidad)=0, 'null', V.ConceptoPenalidad) ConceptoPenalidad,"
    '    sql = sql & "if(V.`TipoOperacion`='X', 0,"
    '    sql = sql & "if(V.`ConceptoPenalidad`='P' or V.`ConceptoPenalidad`='R', V.Penalidad,"
    '    sql = sql & "(V.`MontoBase`+V.`Recargo`-V.`ACuenta`-V.`Descuento`))) as NetoPagado,"
    '    sql = sql & "if(V.`TipoOperacion`='D' and V.`ConceptoPenalidad`='A',"
    '    sql = sql & "100-(V.`Penalidad`*100/V.MontoBase), 0) as TipoDevolucion,"
    '    sql = sql & "V.idFormaPago, if(length(V.TipoTarjeta)=0, 'null', V.TipoTarjeta) TipoTarjeta,"
    '    sql = sql & "concat(right(left(cast(V.FechaActualizacion as char), 10), 2), '/',"
    '    sql = sql & "substring(cast(V.FechaActualizacion as char), 6, 2), '/',"
    '    sql = sql & "left(left(cast(V.FechaActualizacion as char), 10), 4)) FechaVenta,"
    '    sql = sql & "substring(V.FechaActualizacion, 12, 8) as HoraVenta, V.idUsuarioSistema,"
    '    sql = sql & "U.UsuarioSistema, U.ApellidoPaterno apepatUsuario,"
    '    sql = sql & "if(length(U.ApellidoMaterno)=0, 'null', U.ApellidoMaterno) apematUsuario, U.Nombres nombreUsuario,"
    '    sql = sql & "if(length(U.Sexo)=0, 'null', U.Sexo) Sexo,"
    '    sql = sql & "V.TipoTransaccion, V.Flags, if(length(V.TipoOperacion)=0, 'null', V.TipoOperacion) TipoOperacion,"
    '    sql = sql & "IF(C.CodigoCuenta='-', 0, CAST(C.CodigoCuenta AS UNSIGNED)) CodigoCuenta,"
    '    sql = sql & "V.idTipoComprobante, if(V.codigoCuenta is null or V.codigoCuenta='', 'null',V.codigoCuenta) RUC_AGENCIA "
    '    'sql = sql & "T.EfectivoIngresado " g
    '    sql = sql & "FROM ("
    '    sql = sql & "select * from VtaPasajes "
    '    sql = sql & "where NroBoleto<>'' and idTipoComprobante in (2,11) and NroBoleto<>NroBoletoRef "
    '    sql = sql & "and FechaActualizacion BETWEEN '" & Fecha & " 00:00:00 " & "' and '" & Fecha & " 23:59:59' "
    '    sql = sql & "and TipoTransaccion<>'W' and ACuenta=0 and CtrContable=0 and idUsuarioSistema in(" & IDCounter & ") and idConcesionario=" & IDConcesionario & " "
    '    sql = sql & "union all "
    '    sql = sql & "select * from VtaPasajes "
    '    sql = sql & "where NroBoleto<>'' and idTipoComprobante=2 and NroBoleto<>NroBoletoRef "
    '    sql = sql & "and FechaActualizacion BETWEEN '" & Fecha & " 00:00:00 " & "' and '" & Fecha & " 23:59:59' "
    '    sql = sql & "and Acuenta>0 and (MontoBase+Recargo-Descuento-ACuenta)>0 and CtrContable=0 and idUsuarioSistema in(" & IDCounter & ") and  idConcesionario=" & IDConcesionario & " "
    '    sql = sql & "union all "
    '    sql = sql & "select * from VtaPasajes "
    '    sql = sql & "where NroBoleto<>'' and idTipoComprobante=2 and NroBoleto=NroBoletoRef "
    '    sql = sql & "and FechaActualizacion BETWEEN '" & Fecha & " 00:00:00 " & "' and '" & Fecha & " 23:59:59' "
    '    sql = sql & "and TipoOperacion='D' and TipoTransaccion = 'A' and CtrContable=0 and idUsuarioSistema in(" & IDCounter & ") and idConcesionario=" & IDConcesionario & ") V "
    '    sql = sql & "INNER JOIN Clientes C ON (V.idCliente = C.idCliente) "
    '    sql = sql & "INNER JOIN Clientes P ON (V.idPasajero = P.idCliente) "
    '    sql = sql & "INNER JOIN Rutas R ON (V.idRuta = R.idRuta) "
    '    sql = sql & "INNER JOIN Agencias A ON (V.idPuntoEmbarque = A.idAgencia) "
    '    sql = sql & "INNER JOIN UsuariosSistema U ON (V.idUsuarioSistema = U.idUsuarioSistema) "
    '    'sql = sql & "INNER JOIN LiquidacionTurno T ON (V.idUsuarioSistema = T.idUsuarioSistema)" 'g
    '    sql = sql & "INNER JOIN Concesionarios CO ON (V.idConcesionario = CO.idConcesionario) "
    '    'sql = sql & "where T.FechaLiquidacion BETWEEN '" & Fecha & " 00:00:00 " & "' and '" & Fecha & " 23:59:59' " 'g
    '    sql = sql & "UNION ALL "
    '    sql = sql & "SELECT "
    '    sql = sql & "V.idVenta, V.idClase, V.idItinerario, V.idCliente,  if(C.idTipoDocumento=8 and "
    '    sql = sql & "V.TipoOperacion<>'X',C.NroDocumento, 'null') as RUC,"
    '    sql = sql & "if(V.`TipoOperacion`='X', 'null', if(length(trim(C.RazonSocial))>0,"
    '    sql = sql & "trim(C.RazonSocial),'null')) as Razon, C.Empresa,"
    '    sql = sql & "if(C.Empresa=0, 0, C.idTipoDocumento) tipoDocEmpresa,"
    '    sql = sql & "V.idPasajero, if(V.`TipoOperacion`='X', 'null', if(length(P.NroDocumento)=0, 'null',"
    '    sql = sql & "P.NroDocumento)) as DNI, "
    '    sql = sql & "P.idTipoDocumento tipoDocPasajero, trim(P.ApellidoPaterno) apepatpas,"
    '    sql = sql & "if(length(trim(P.ApellidoMaterno))=0, 'null', trim(P.ApellidoMaterno)) apematpas,"
    '    sql = sql & "if(instr(trim(P.Nombres), ' ')=0, trim(P.Nombres), LEFT(trim(P.Nombres),"
    '    sql = sql & "INSTR(trim(P.Nombres), ' '))) Nombrepas,"
    '    sql = sql & "if(instr(trim(P.Nombres), ' ')=0, 'null',substring(trim(P.Nombres),"
    '    sql = sql & "instr(trim(P.Nombres), ' ')+1, length(trim(P.Nombres)))) Nombre1Pas,"
    '    sql = sql & "ifnull(if(length(P.FechaNacimiento)<=0, '', concat(right(P.FechaNacimiento, 2), '/',"
    '    sql = sql & "substring(P.FechaNacimiento, 6, 2), '/', left(P.FechaNacimiento, 4))), 'null') FechaNacimiento,"
    '    sql = sql & "if(CO.codConcesionario>5000, cast(CO.codConcesionario as unsigned),"
    '    sql = sql & "cast(5000+CO.codConcesionario as unsigned)) as OficinaVenta, V.idRuta,"
    '    sql = sql & "if(R.codCiudadOrigen>5000, cast(R.codCiudadOrigen as unsigned),"
    '    sql = sql & "cast(5000+R.codCiudadOrigen as unsigned)) Origen,"
    '    sql = sql & "if(R.codCiudadDestino>5000, cast(R.codCiudadDestino as unsigned),"
    '    sql = sql & "cast(5000+R.codCiudadDestino as unsigned)) Destino,"
    '    sql = sql & "0 OficinaEmbarque, left(V.NroBoleto, 3) Serie, right(V.NroBoleto, 7) Numero,"
    '    sql = sql & "if(V.NroBoletoRef='', 'null', left(V.NroBoletoRef, 3)) SerieRef, if(V.NroBoletoRef='',"
    '    sql = sql & "'null', right(V.NroBoletoRef, 7)) NumeroRef, V.NroControl,"
    '    sql = sql & "IF(V.`TipoOperacion`='X', 0, V.NroAsiento) as Asiento,"
    '    sql = sql & "concat(right(V.FechaPartida, 2), '/', substring(V.FechaPartida, 6,2),'/', left(V.FechaPartida, 4)) FechaPartida, "
    '    sql = sql & "left(cast(V.HoraPartida as char),5) HoraPartida, concat(right(V.FechaLlegada, 2), '/', substring(V.FechaLlegada, 6,2),'/', left(V.FechaLlegada, 4)) FechaLlegada, "
    '    sql = sql & "left(cast(V.HoraLlegada as char),5) HoraLlegada,"
    '    sql = sql & "if(V.`TipoOperacion`='X', 0, V.MontoBase) as MontoBase,"
    '    sql = sql & "if(V.`TipoOperacion`='X', 0,  (V.Recargo)) as Recargo,"
    '    sql = sql & "if(V.`TipoOperacion`='X', 0,  (V.Descuento)) as Descuento,"
    '    sql = sql & "if(V.`TipoOperacion`='X', 0, V.ACuenta) as ACuenta,"
    '    sql = sql & "if(V.`TipoOperacion`='X', 0, V.Penalidad) as Penalidad,"
    '    sql = sql & "if(length(V.ConceptoPenalidad)=0, 'null', V.ConceptoPenalidad) ConceptoPenalidad,"
    '    sql = sql & "if(V.`TipoOperacion`='X', 0,"
    '    sql = sql & "if(V.ConceptoPenalidad='P' or V.ConceptoPenalidad='R', V.Penalidad,"
    '    sql = sql & "(V.MontoBase+V.Recargo-V.ACuenta-V.Descuento))) as NetoPagado,"
    '    sql = sql & "if(V.TipoOperacion='D' and V.ConceptoPenalidad='A', 100-(V.Penalidad*100/V.MontoBase),0) as TipoDevolucion,"
    '    sql = sql & "V.idFormaPago, if(length(V.TipoTarjeta)=0, 'null', TipoTarjeta),"
    '    sql = sql & "concat(right(left(cast(V.FechaActualizacion as char), 10), 2), '/',"
    '    sql = sql & "substring(cast(V.FechaActualizacion as char), 6, 2), '/',"
    '    sql = sql & "left(left(cast(V.FechaActualizacion as char), 10), 4)) FechaVenta,"
    '    sql = sql & "substring(V.FechaActualizacion, 12, 8) as HoraVenta, V.idUsuarioSistema,"
    '    sql = sql & "U.UsuarioSistema, U.ApellidoPaterno apepatUsuario,"
    '    sql = sql & "if(length(U.ApellidoMaterno)=0, 'null', U.ApellidoMaterno) apematUsuario, U.Nombres nombreUsuario,"
    '    sql = sql & "if(length(U.Sexo)=0, 'null', U.Sexo) Sexo, V.TipoTransaccion, V.Flags,"
    '    sql = sql & "if(length(V.TipoOperacion)=0, 'null', V.TipoOperacion) TipoOperacion,"
    '    sql = sql & "IF(C.CodigoCuenta='-', 0, CAST(C.CodigoCuenta AS UNSIGNED)) CodigoCuenta,"
    '    sql = sql & "V.idTipoComprobante, if(V.codigoCuenta is null or V.codigoCuenta='', 'null',V.codigoCuenta) RUC_AGENCIA "
    '    'sql = sql & "T.EfectivoIngresado "
    '    sql = sql & "FROM ("
    '    sql = sql & "select * from VtaPasajes "
    '    sql = sql & "where NroBoleto<>'' and idTipoComprobante in (2,11) and NroBoleto<>NroBoletoRef "
    '    sql = sql & "and FechaActualizacion BETWEEN '" & Fecha & " 00:00:00 " & "' and '" & Fecha & " 23:59:59' "
    '    sql = sql & "AND TipoTransaccion='W' and CtrContable=0 and idUsuarioSistema in(" & IDCounter & ") and idConcesionario=" & IDConcesionario & " "
    '    sql = sql & ") V "
    '    sql = sql & "INNER JOIN Clientes C ON (V.idCliente = C.idCliente) "
    '    sql = sql & "INNER JOIN Clientes P ON (V.idPasajero = P.idCliente) "
    '    sql = sql & "INNER JOIN Rutas R ON (V.idRuta = R.idRuta) "
    '    sql = sql & "INNER JOIN UsuariosSistema U ON (V.idUsuarioSistema = U.idUsuarioSistema) "
    '    'sql = sql & "INNER JOIN LiquidacionTurno T ON (V.idUsuarioSistema = T.idUsuarioSistema)" 'g
    '    sql = sql & "INNER JOIN Concesionarios CO ON (V.idConcesionario = CO.idConcesionario) "
    '    ' sql = sql & "where T.FechaLiquidacion BETWEEN '" & Fecha & " 00:00:00 " & "' and '" & Fecha & " 23:59:59' " 'g
    '    '//-- DEVOLUCIONES FECHA ABIERTA
    '    sql = sql & "UNION ALL "
    '    sql = sql & "SELECT "
    '    sql = sql & "V.idVenta, V.idClase, V.idItinerario, V.idCliente,  if(C.idTipoDocumento=8 and V.TipoOperacion<>'X',C.NroDocumento, 'null') as RUC,"
    '    sql = sql & "if(V.`TipoOperacion`='X', 'null', if(length(trim(C.RazonSocial))>0, trim(C.RazonSocial),'null')) as Razon, C.Empresa,"
    '    sql = sql & "if(C.Empresa=0, 0, C.idTipoDocumento) tipoDocEmpresa,"
    '    sql = sql & "V.idPasajero, if(V.`TipoOperacion`='X', 'null', if(length(P.NroDocumento)=0, 'null', P.NroDocumento)) as DNI,"
    '    sql = sql & "P.idTipoDocumento tipoDocPasajero, trim(P.ApellidoPaterno) apepatpas,"
    '    sql = sql & "if(length(trim(P.ApellidoMaterno))=0, 'null', trim(P.ApellidoMaterno)) apematpas,"
    '    sql = sql & " if(instr(trim(P.Nombres), ' ')=0, trim(P.Nombres), LEFT(trim(P.Nombres), INSTR(trim(P.Nombres), ' '))) Nombrepas,"
    '    sql = sql & "if(instr(trim(P.Nombres), ' ')=0, 'null',substring(trim(P.Nombres), instr(trim(P.Nombres), ' ')+1, length(trim(P.Nombres)))) Nombre1Pas,"
    '    sql = sql & "ifnull(if(length(P.FechaNacimiento)<=0, '', concat(right(P.FechaNacimiento, 2), '/', substring(P.FechaNacimiento, 6, 2), '/', left(P.FechaNacimiento, 4))), 'null') FechaNacimiento,"
    '    sql = sql & "if(CO.codConcesionario>5000, cast(CO.codConcesionario as unsigned), cast(5000+CO.codConcesionario as unsigned)) as OficinaVenta, V.idRuta,"
    '    sql = sql & "if(R.codCiudadOrigen>5000, cast(R.codCiudadOrigen as unsigned), cast(5000+R.codCiudadOrigen as unsigned)) Origen,"
    '    sql = sql & "if(R.codCiudadDestino>5000, cast(R.codCiudadDestino as unsigned), cast(5000+R.codCiudadDestino as unsigned)) Destino,"
    '    sql = sql & "0 OficinaEmbarque, left(V.NroBoleto, 3) Serie, right(V.NroBoleto, 7) Numero,"
    '    sql = sql & "if(V.NroBoletoRef='', 'null', left(V.NroBoletoRef, 3)) SerieRef, if(V.NroBoletoRef='', 'null', right(V.NroBoletoRef, 7)) NumeroRef, V.NroControl,"
    '    sql = sql & "IF(V.`TipoOperacion`='X', 0, V.NroAsiento) as Asiento,"
    '    sql = sql & "concat(right(V.FechaPartida, 2), '/', substring(V.FechaPartida, 6,2),'/', left(V.FechaPartida, 4)) FechaPartida,"
    '    sql = sql & "left(V.HoraPartida, 5) HoraPartida, cast(V.FechaLlegada as char) FechaLlegada, left(V.HoraLlegada, 5) HoraLlegada,"
    '    sql = sql & "if(V.`TipoOperacion`='X', 0, V.MontoBase) as MontoBase,"
    '    sql = sql & "if(V.`TipoOperacion`='X', 0,  (V.Recargo)) as Recargo,"
    '    sql = sql & "if(V.`TipoOperacion`='X', 0,  (V.Descuento)) as Descuento,"
    '    sql = sql & "if(V.`TipoOperacion`='X', 0, V.ACuenta) as ACuenta,"
    '    sql = sql & "if(V.`TipoOperacion`='X', 0, V.Penalidad) as Penalidad, if(length(V.ConceptoPenalidad)=0, 'null', V.ConceptoPenalidad) ConceptoPenalidad,"
    '    sql = sql & "if(V.`TipoOperacion`='X', 0,"
    '    sql = sql & "if(V.ConceptoPenalidad='P' or V.ConceptoPenalidad='R', V.Penalidad,  (V.MontoBase+V.Recargo-V.ACuenta-V.Descuento))) as NetoPagado,"
    '    sql = sql & "if(V.TipoOperacion='D' and V.ConceptoPenalidad='A', 100-(V.Penalidad*100/V.MontoBase), 0) as TipoDevolucion,"
    '    sql = sql & "V.idFormaPago, if(length(V.TipoTarjeta)=0, 'null', TipoTarjeta),"
    '    sql = sql & "concat(right(left(cast(V.FechaActualizacion as char), 10), 2), '/', substring(cast(V.FechaActualizacion as char), 6, 2), '/', left(left(cast(V.FechaActualizacion as char), 10), 4)) FechaVenta,"
    '    sql = sql & "substring(V.FechaActualizacion, 12, 8) as HoraVenta, V.idUsuarioSistema, U.UsuarioSistema, U.ApellidoPaterno apepatUsuario,"
    '    sql = sql & "if(length(U.ApellidoMaterno)=0, 'null', U.ApellidoMaterno) apematUsuario, U.Nombres nombreUsuario,"
    '    sql = sql & "if(length(U.Sexo)=0, 'null', U.Sexo) Sexo, V.TipoTransaccion, V.Flags, if(length(V.TipoOperacion)=0, 'null', V.TipoOperacion) TipoOperacion,"
    '    sql = sql & "IF(C.CodigoCuenta='-', 0, CAST(C.CodigoCuenta AS UNSIGNED)) CodigoCuenta, V.idTipoComprobante, if(V.codigoCuenta is null or V.codigoCuenta='', 'null', V.codigoCuenta) RUC_AGENCIA "
    '    'sql = sql & "T.EfectivoIngresado "
    '    sql = sql & "FROM "
    '    sql = sql & "("
    '    sql = sql & "select * from VtaPasajes where "
    '    sql = sql & "FechaActualizacion BETWEEN '" & Fecha & " 00:00:00 " & "' and '" & Fecha & " 23:59:59' "
    '    sql = sql & "and NroBoleto=NroBoletoRef and TipoOperacion='D' and TipoTransaccion='A' and FechaPartida='0000-00-00' "
    '    sql = sql & "and idPuntoEmbarque=0 and CtrContable=0 in(" & IDCounter & ") and idConcesionario=" & IDConcesionario & " "
    '    sql = sql & ") V "
    '    sql = sql & "INNER JOIN Clientes C ON (V.idCliente = C.idCliente) "
    '    sql = sql & "INNER JOIN Clientes P ON (V.idPasajero = P.idCliente) "
    '    sql = sql & "INNER JOIN Rutas R ON (V.idRuta = R.idRuta) "
    '    'sql = sql & "INNER JOIN LiquidacionTurno T ON (V.idUsuarioSistema = T.idUsuarioSistema) " 'g
    '    sql = sql & "INNER JOIN UsuariosSistema U ON (V.idUsuarioSistema = U.idUsuarioSistema) "
    '    sql = sql & "INNER JOIN Concesionarios CO ON (V.idConcesionario = CO.idConcesionario) "
    '    'sql = sql & "where T.FechaLiquidacion BETWEEN '" & Fecha & " 00:00:00 " & "' and '" & Fecha & " 23:59:59' " 'g
    '    sql = sql & ") as B "
    '    sql = sql & "ORDER BY "
    '    sql = sql & "B.FechaVenta, B.OficinaVenta, B.Serie, B.Numero"
    '    Dim dt = ObtieneDT(sql)
    '    Return dt
    'End Function

    Function TranferenciaGastos(ByVal IDCounter As String) As DataTable
        'Me.ConexionPasajes()
        Dim IDConcesionario As Integer = ObtieneTipoDocumento(dtoUSUARIOS.iIDAGENCIAS)
        Dim Fecha As String = Strings.Right(LblFecha.Text, 4) & "-" & Mid(LblFecha.Text, 4, 2) & "-" & Strings.Left(LblFecha.Text, 2)
        Dim sql As String

        sql = "select "
        sql = sql & "US.UsuarioSistema,"
        sql = sql & "glt.IdGastosLiquidacionPorTurno, glt.idTipoLiquidacionPorTurno IDTIPOLIQUIDACIONDIARIA,"
        sql = sql & "glt.NroDocumento NRO_DOCUMENTO,"
        sql = sql & "cast(glt.Cuenta as char) CODIGO_PEAJE,"
        sql = sql & "glt.Monto MONTO,"
        sql = sql & "glt.NroBus NRO_BUS,"
        sql = sql & "glt.Destino DESTINO,"
        sql = sql & "if(glt.Piloto='--Seleccione--', '', glt.Piloto) PILOTO,"
        sql = sql & "glt.Remitente DEPOSITANTE,"
        sql = sql & "glt.Consignado CONTACTO,"
        sql = sql & "glt.Descripcion OBSERVACIONES,"
        sql = sql & "CAST(left(glt.FechaRegistro, 10) AS char) FECHA_REGISTRO,"
        sql = sql & "CAST(right(glt.FechaRegistro, 8) AS char) HORA_REGISTRO,"
        sql = sql & "CAST(left(glt.FechaActualizacion, 10) AS char) FECHA_ACTUALIZACION,"
        sql = sql & "CAST(right(glt.FechaActualizacion, 8) AS char) HORA_ACTUALIZACION,"
        sql = sql & "glt.EstadoGasto ESTADO,"
        sql = sql & "CAST(concat(right(left(FechaActualizacion, 10), 2),'/', substr(left(FechaActualizacion, 10), 6, 2),'/', left(left(FechaActualizacion, 10), 4))  AS char) FECHA_OPERACION,"
        sql = sql & "if(C.codConcesionario<5000, cast(5000+C.codConcesionario as unsigned), cast(C.codConcesionario as unsigned)) IDAGENCIA_UNIX "
        sql = sql & "from GastosLiquidacionPorTurno glt "
        sql = sql & "inner join UsuariosSistema US on (glt.idUsuarioSistema = US.idUsuarioSistema) "
        sql = sql & "inner join Concesionarios C on (US.idConcesionario = C.idConcesionario) "
        sql = sql & "where glt.FechaRegistro like '" & Fecha & "%' and glt.idUsuarioSistema in(" & IDCounter & ")"   ''2012-02-16%' "
        sql = sql & "and C.idConcesionario=" & IDConcesionario
        Dim dt = ObtieneDT(sql)
        Return dt
    End Function
#End Region


    Function ObtieneDT(ByVal sql As String) As DataTable
        Try
            'Dim cmd As New OdbcCommand
            'cmd.CommandText = sql
            'cmd.CommandType = CommandType.Text
            'If cnn.State = ConnectionState.Closed Then
            '    Me.ConexionPasajes()
            'End If
            'cmd.Connection = cnn
            'Dim da As New OdbcDataAdapter(cmd)

            If (cnn.State = ConnectionState.Closed) Then
                cnn.Open()
            End If
            Dim da As New System.Data.OracleClient.OracleDataAdapter(sql, cnn)
            Dim dt As New DataTable
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            If (cnn.State = ConnectionState.Closed) Then cnn.Close()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cnn.Close()
        End Try


    End Function

    Function ActualizaDatos(ByVal UpdateSql As String) As Integer
        Dim cmd As New OdbcCommand
        Dim iRows As Integer = 0
        cmd.CommandText = UpdateSql
        cmd.CommandType = CommandType.Text
        If IsNothing(cnn) Then
            'Me.ConexionPasajes()
        End If
        If cnn.State = ConnectionState.Closed Then
            cnn.Open()
        End If
        'cmd.Connection = cnn
        iRows = cmd.ExecuteNonQuery()
        Return iRows
    End Function

    Function ObtieneTipoDocumento(ByVal tipo As Integer)
        Dim valor As Integer = 0
        Dim obj As New dtoCierreOficina
        Dim dt As DataTable = obj.Concesionario(tipo)
        If Not IsDBNull(dt) Then
            If dt.Rows.Count = 1 Then
                If Not IsDBNull(dt.Rows(0).Item("IdAgencia_Concesionarios")) Then
                    valor = dt.Rows(0)("IdAgencia_Concesionarios")
                End If
            End If
        End If
        Return valor
    End Function
#End Region


    Private Sub BtnCerrarLiquidacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarLiquidacion.Click

        Dim Sql As String = String.Empty
        Dim strMensaje As String = String.Empty
        Dim IDConcesionario As Integer = ObtieneTipoDocumento(dtoUSUARIOS.iIDAGENCIAS)
        Dim dtLiquidacion As DataTable = Nothing
        Dim dsValidar As DataSet = Nothing
        Dim dtIngresos As DataTable = Nothing
        Dim dtGastos As DataTable = Nothing
        Dim dtCounterCarga As DataTable = Nothing
        Dim dtComprobante As DataTable = Nothing
        Dim dtError As DataTable = Nothing
        Dim obj As New dtoCierreOficina
        Try
            BtnBuscar_Click(sender, e)
            Me.Cursor = Cursors.AppStarting
            '-->busca todas las liquidaciones de una determinada Agencia, para validar si existen liquidaciones pendiente por cerrar.
            'dtLiquidacion = liquidacionSisvyr.buscarEstadoLiquidaciones(CboFechaLiquidacion.Value.ToString("dd/MM/yyyy"), dtoUSUARIOS.codAgenciaSisvyr).Tables(0)
            'If Not dtLiquidacion Is Nothing Then
            '    If dtLiquidacion.Rows.Count > 0 Then
            '        For NroLiquidacion As Integer = 0 To dtLiquidacion.Rows.Count - 1
            '            If dtLiquidacion.Rows(NroLiquidacion).Item("estado") = 1 Then
            '                If strMensaje = "" Then
            '                    strMensaje = "Usuario : " & dtLiquidacion.Rows(NroLiquidacion).Item("Usuario").ToString.Substring(0, Len(dtLiquidacion.Rows(NroLiquidacion).Item("Usuario").ToString) - 7)
            '                Else
            '                    strMensaje = strMensaje & vbCrLf & "Usuario : " & dtLiquidacion.Rows(NroLiquidacion).Item("Usuario").ToString.Substring(0, Len(dtLiquidacion.Rows(NroLiquidacion).Item("Usuario").ToString) - 7)
            '                End If
            '            End If
            '        Next
            '        If strMensaje <> "" Then
            '            MessageBox.Show("Existen Liquidaciones de Turno Aperturadas en el Sistema VYR Pendientes por Cerrar: " & vbCrLf & vbCrLf & strMensaje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '            Me.Cursor = Cursors.Default
            '            Return
            '        End If
            '    Else
            '        If MessageBox.Show("No Existen Cajas Aperturadas para el cierre de Oficina " & vbCrLf & "¿Desea Continuar con el Cierre de la Liquidación de oficina?", "Titán", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then
            '            Me.Cursor = Cursors.Default
            '            Return
            '        End If
            '    End If
            'Else
            '    Me.Cursor = Cursors.Default
            '    Return
            'End If

            'dtCounterCarga = obj.ValidarCierreCajaCarga(CboFechaLiquidacion.Value.Date, dtoUSUARIOS.iIDAGENCIAS)
            Dim ds As DataSet = obj.ValidarCierreCajaCarga(CboFechaLiquidacion.Value.Date, dtoUSUARIOS.iIDAGENCIAS)
            dtCounterCarga = ds.Tables(0)
            dtComprobante = ds.Tables(1)
            If dtComprobante.Rows.Count > 0 Then
                Dim strCadena As String = "", strGlosa As String = ""
                For Each row As DataRow In dtComprobante.Rows
                    strCadena = strCadena & row.Item("usuario") & " " & row.Item("comprobante") & " " & row.Item("total") & Chr(13)
                Next
                'strGlosa = "Existen Comprobantes sin Liquidar" & Chr(13) & "¿Está Seguro de continuar con el Cierre de Oficina?" & Chr(13) & Chr(13)
                strGlosa = "Existen Comprobantes sin Liquidar" & Chr(13) & "Para continuar con el Cierre de Oficina, los comprobantes deben estar liquidados" & Chr(13) & Chr(13)
                strGlosa = strGlosa & strCadena

                MessageBox.Show(strGlosa, "Comprobantes sin Liquidar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Cursor = Cursors.Default
                Return

                'Dim dlgRespuesta As DialogResult
                'dlgRespuesta = MessageBox.Show(strGlosa, "Comprobantes sin Liquidar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                'If dlgRespuesta = Windows.Forms.DialogResult.No Then
                '    Me.Cursor = Cursors.Default
                '    Return
                'End If
            End If

            If Not IsDBNull(dtCounterCarga) Then
                If dtCounterCarga.Rows.Count > 0 Then
                    For iCounter As Integer = 0 To dtCounterCarga.Rows.Count - 1
                        If dtCounterCarga.Rows(iCounter).Item("ESTADO") = 0 Then
                            If strMensaje = "" Then
                                strMensaje = "Usuario : " & dtCounterCarga.Rows(iCounter).Item("USUARIO").ToString.Substring(0, Len(dtCounterCarga.Rows(iCounter).Item("USUARIO").ToString) - 7)
                            Else
                                strMensaje = strMensaje & vbCrLf & "Usuario : " & dtCounterCarga.Rows(iCounter).Item("USUARIO").ToString.Substring(0, Len(dtCounterCarga.Rows(iCounter).Item("USUARIO").ToString) - 7)
                            End If
                        End If
                    Next
                    If strMensaje <> "" Then
                        MessageBox.Show("Existen Liquidaciones de Turno de Carga Aperturadas Pendientes por Cerrar: " & vbCrLf & vbCrLf & strMensaje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Cursor = Cursors.Default
                        Return
                    End If
                Else
                    If MessageBox.Show("¿Esta Seguro Que No Existen Cajas Aperturadas de Carga?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                        Me.Cursor = Cursors.Default
                        Return
                    End If
                End If
            End If

            If LstCarga1.Items.Count > 0 Then
                For iCounterCarga As Integer = 0 To LstCarga1.Items.Count - 1
                    LstCarga1.SelectedIndex = iCounterCarga
                    If strMensaje = "" Then
                        strMensaje = "Usuario : " & LstCarga1.Text.Substring(0, Len(LstCarga1.Text) - 7)
                    Else
                        strMensaje = strMensaje & vbCrLf & "Usuario : " & LstCarga1.Text.Substring(0, Len(LstCarga1.Text) - 7)
                    End If
                Next
                If strMensaje <> "" Then
                    MessageBox.Show("Existen Counter de Carga No Asociados a la Liquidación: " & vbCrLf & vbCrLf & strMensaje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Cursor = Cursors.Default
                    Return
                End If
            End If

            'If LstPasajes1.Items.Count > 0 Then
            '    For iCounterPasaje As Integer = 0 To LstPasajes1.Items.Count - 1
            '        LstPasajes1.SelectedIndex = iCounterPasaje
            '        If strMensaje = "" Then
            '            strMensaje = "Usuario : " & LstPasajes1.Text.Substring(0, Len(LstPasajes1.Text) - 7)
            '        Else
            '            strMensaje = strMensaje & vbCrLf & "Usuario : " & LstPasajes1.Text.Substring(0, Len(LstPasajes1.Text) - 7)
            '        End If
            '    Next
            '    If strMensaje <> "" Then
            '        MessageBox.Show("Existen Counter de Pasajes No Asociados a la Liquidación: " & vbCrLf & vbCrLf & strMensaje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        Me.Cursor = Cursors.Default
            '        Return
            '    End If
            'End If

            If LstCarga2.Items.Count > 0 Then
                For iCounterCarga As Integer = 0 To LstCarga2.Items.Count - 1
                    LstCarga2.SelectedIndex = iCounterCarga
                    If strMensaje = "" Then
                        strMensaje = "Usuario : " & LstCarga2.Text.Substring(0, Len(LstCarga2.Text) - 7)
                    Else
                        strMensaje = strMensaje & vbCrLf & "Usuario : " & LstCarga2.Text.Substring(0, Len(LstCarga2.Text) - 7)
                    End If
                Next
                If strMensaje <> "" Then
                    MessageBox.Show("Existen Counter de Carga Asociadas Pendiente de Transferencia: " & vbCrLf & vbCrLf & strMensaje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Cursor = Cursors.Default
                    Return
                End If
            End If

            'If LstPasajes2.Items.Count > 0 Then
            '    For iCounterPasaje As Integer = 0 To LstPasajes2.Items.Count - 1
            '        LstPasajes2.SelectedIndex = iCounterPasaje
            '        If strMensaje = "" Then
            '            strMensaje = "Usuario : " & LstPasajes2.Text.Substring(0, Len(LstPasajes2.Text) - 7)
            '        Else
            '            strMensaje = strMensaje & vbCrLf & "Usuario : " & LstPasajes2.Text.Substring(0, Len(LstPasajes2.Text) - 7)
            '        End If
            '    Next
            '    If strMensaje <> "" Then
            '        MessageBox.Show("Existen Counter de Pasajes Asociadas Pendiente de Transferencia: " & vbCrLf & vbCrLf & strMensaje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        Me.Cursor = Cursors.Default
            '        Return
            '    End If
            'End If

            dsValidar = obj.ValidarCierreLiquidacion(dgvListaCaja.Rows(dgvListaCaja.SelectedRows.Item(0).Index).Cells("ID_Oficina_Liquidacion").Value, CboFechaLiquidacion.Value.Date, dtoUSUARIOS.iIDAGENCIAS)
            dtIngresos = dsValidar.Tables(0)
            dtGastos = dsValidar.Tables(1)
            dtError = dsValidar.Tables(2)

            If Not dtError Is Nothing Then
                If dtError.Rows(0).Item(0).ToString = "" Then
                    Dim TotalIngreso As Double = 0
                    Dim TotalGasto As Double = 0
                    Dim TotalGastoXCounter As Double = 0
                    Dim blnOk As Boolean = False

                    If dtIngresos.Rows.Count > 0 Then
                        For iValidar As Integer = 0 To dtIngresos.Rows.Count - 1
                            TotalIngreso = 0
                            TotalGasto = 0
                            TotalGastoXCounter = 0
                            blnOk = False

                            For iGastos As Integer = 0 To dtGastos.Rows.Count - 1
                                If dtIngresos.Rows(iValidar).Item("IdUsuario_Personal").ToString() = dtGastos.Rows(iGastos).Item("IdUsuario_Personal").ToString() Then
                                    TotalGasto = Convert.ToDouble(dtGastos.Rows(iGastos).Item("Monto_Gastos_Varios").ToString) + Convert.ToDouble(dtGastos.Rows(iGastos).Item("Monto_Pago_Giros").ToString) + Convert.ToDouble(dtGastos.Rows(iGastos).Item("Monto_Peajes").ToString)
                                    TotalGastoXCounter = Convert.ToDouble(dtGastos.Rows(iGastos).Item("Monto_Efectivo_Gastos").ToString)
                                    blnOk = True
                                End If
                            Next

                            If blnOk = False Then
                                TotalGasto = 0
                            End If

                            TotalIngreso = Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Contado").ToString) + _
                                           Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_MasterCard").ToString) + _
                                           Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Visa").ToString) + _
                                           Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Efectivo_Credito").ToString) + _
                                           Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_CajaPrepagados").ToString) + _
                                           Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Delivery").ToString) - _
                                           TotalGasto - _
                                           Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Total_Porc80").ToString) - _
                                           Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Total_Porc100").ToString) - _
                                           Convert.ToDouble(dtIngresos.Rows(iValidar).Item("nc").ToString) - _
                                           Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_MasterCard").ToString) - _
                                           Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Visa").ToString) - _
                            Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Credito").ToString)
                            TotalIngreso += +dtIngresos.Rows(iValidar).Item("Monto_Efectivo_seguro")
                            If Math.Round(TotalIngreso, 2) <> Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Efectivo_Ingresado").ToString), 2) And TotalIngreso > 0 Then
                                If strMensaje = "" Then
                                    strMensaje = "Usuario : " & dtIngresos.Rows(iValidar).Item("Nombre_Personal")
                                Else
                                    strMensaje = strMensaje & vbCrLf & "Usuario : " & dtIngresos.Rows(iValidar).Item("Nombre_Personal")
                                End If

                                If Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Cortesia").ToString)) <> Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Efectivo_Cortesia").ToString)) Then
                                    strMensaje = strMensaje & " Diferencia Cortesia : S/. " & (Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Cortesia").ToString)) - Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Efectivo_Cortesia").ToString))).ToString
                                End If

                                If Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Prepagado").ToString)) <> Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Efectivo_Prepagado").ToString)) Then
                                    strMensaje = strMensaje & " Diferencia Prepagado : S/. " & (Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Prepagado").ToString)) - Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Efectivo_Prepagado").ToString))).ToString
                                End If

                                If Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Credito").ToString)) <> Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Efectivo_Credito").ToString)) Then
                                    strMensaje = strMensaje & " Diferencia Crédito : S/. " & (Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Credito").ToString)) - Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Efectivo_Credito").ToString))).ToString
                                End If

                                If Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_CajaPrepagados").ToString)) <> Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Efectivo_CajaPrepagada").ToString)) Then
                                    strMensaje = strMensaje & " Diferencia Recibos de Caja : S/. " & (Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_CajaPrepagados").ToString)) - Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Efectivo_CajaPrepagada").ToString))).ToString
                                End If

                                If Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Visa").ToString) + Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_MasterCard").ToString)) <> Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Efectivo_Tarjeta").ToString)) Then
                                    strMensaje = strMensaje & " Diferencia Tarjetas : S/. " & (Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Visa").ToString) + Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_MasterCard").ToString)) - Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Efectivo_Tarjeta").ToString))).ToString
                                End If

                                If Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Contado").ToString)) <> Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Efectivo_Contado").ToString)) Then
                                    strMensaje = strMensaje & " Diferencia Contado : S/. " & (Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Contado").ToString)) - Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Efectivo_Contado").ToString))).ToString
                                End If

                                If Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Total_Porc80").ToString) + Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Total_Porc100").ToString)) <> Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Efectivo_Devolucion").ToString)) Then
                                    strMensaje = strMensaje & " Diferencia Devoluciones : S/. " & (Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Total_Porc80").ToString) + Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Total_Porc100").ToString)) - Math.Round(Convert.ToDouble(dtIngresos.Rows(iValidar).Item("Monto_Efectivo_Devolucion").ToString))).ToString
                                End If

                                If Math.Round(TotalGasto) <> Math.Round(TotalGastoXCounter) Then
                                    strMensaje = strMensaje & " Diferencia Gastos : S/. " & (Math.Round(TotalGasto) - Math.Round(TotalGastoXCounter)).ToString
                                End If
                            End If
                        Next
                        If strMensaje <> "" Then
                            MessageBox.Show("Las Liquidaciones de los Siguientes Usuarios Tienen Diferencias : " & vbCrLf & vbCrLf & strMensaje, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.Cursor = Cursors.Default
                            Return
                        End If
                    End If
                Else
                    MessageBox.Show("Mensaje: " & dtError.Rows(0).Item(0).ToString, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Cursor = Cursors.Default
                    Return
                End If
            Else
                MessageBox.Show("Mensaje: " & dtError.Rows(0).Item(0).ToString, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Cursor = Cursors.Default
                Return
            End If

            If MessageBox.Show("¿Desea realizar el cierre de Oficina?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim Dt As DataTable = Me.Totales()
                obj.CierreLiquidacion(IDLiquidacionOficina, iTotalFactura + iTotalBoleta + iTotalIngreso, 0, 0, dtoUSUARIOS.IdLogin)

                If Dt IsNot Nothing Then
                    For i As Integer = 0 To Dt.Rows.Count - 1
                        iTotalFactura = Dt.Rows(i)("total_monto_factu")
                        iTotalBoleta = Dt.Rows(i)("total_monto_bole")
                        iTotalPceFacturas = Dt.Rows(i)("total_monto_pago_entre")
                        iTotalIngreso = Dt.Rows(i)("total_ingreso")
                        iTotalEgreso = Dt.Rows(i)("total_egreso")
                        obj.DetalleLiquidacion(IDLiquidacionOficina, Dt.Rows(i)("idusuario_personal"), iTotalFactura, iTotalPceFacturas, iTotalBoleta, _
                                               iTotalPceBoletas, iTotalIngreso, iTotalEgreso)
                    Next
                End If

                Dim intPortavalor As Integer = dtoUSUARIOS.Portavalor
                If intPortavalor = 2 Then
                    'Me.lblFechaCierre.Text = "30/07/2017"
                    Me.dgvComprobanteCierre.Rows.Clear()
                    Dim dblTotalEfectivoCierre As Double
                    Dim intUsuario As Integer, strUsuario As String
                    Dim obj2 As New Cls_LiquidacionValor_LN

                    obj2.AnularLiquidacionRemesa(Me.CboFechaLiquidacion.Value.ToShortDateString, dtoUSUARIOS.iIDAGENCIAS, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)

                    intUsuario = 0
                    strUsuario = "X"

                    Dim ds2 As DataSet = obj2.ListarComprobante(dtoUSUARIOS.iIDAGENCIAS, Me.CboFechaLiquidacion.Value.ToShortDateString, intUsuario, dtoUSUARIOS.Unidad)
                    If ds2.Tables(0).Rows.Count > 0 Then
                        MostrarComprobante(ds2.Tables(0), 1)
                    End If
                    Dim objVYR As New dtoValor
                    Dim dt2 As DataTable = objVYR.LeerVenta(dtoUSUARIOS.codAgenciaSisvyr, Me.CboFechaLiquidacion.Value.ToShortDateString, strUsuario)
                    If dt2.Rows.Count > 0 Then
                        MostrarComprobante(dt2, 2)
                    End If

                    Dim strFecha As String
                    strFecha = Me.CboFechaLiquidacion.Value.ToShortDateString
                    'dblTotalEfectivoCierre = TotalGrid(Me.dgvComprobanteCierre, "efectivo")
                    dblTotalEfectivoCierre = MontoEfectivo(IDLiquidacionOficina, dtoUSUARIOS.iIDAGENCIAS, strFecha)
                    Me.lblTotalEfectivoCierre.Text = Format(dblTotalEfectivoCierre, "###,###,###0.00")

                    Dim dblTotalEfectivo As Double, dblTC As Double, dblRetiroSoles As Double, dblRetiroDolar As Double
                    Dim intComprobante As Integer, intId As Integer, intIdSoles As Integer, intIdDolar As Integer
                    Dim strComprobante As String, strTipo As String, dblMonto As Double, intUnidad As Integer
                    Dim strCodigoSoles As String, strCodigoDolar As String

                    dblTotalEfectivo = CType(Me.lblTotalEfectivoCierre.Text, Double)
                    dblTC = CType(Cls_LiquidacionValor_LN.ObtieneTipoCambio(CDate(strFecha).ToShortDateString), Double)
                    dblRetiroSoles = dblTotalEfectivo
                    dblRetiroDolar = 0

                    Dim dt3 As DataTable = obj2.CerrarCaja(strFecha, dtoUSUARIOS.iIDAGENCIAS, dtoUSUARIOS.IdLogin, dblTotalEfectivo, dblTC, _
                                   dblRetiroSoles, 0, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
                    If dt3.Rows.Count > 0 Then
                        intId = CType(dt3.Rows(0).Item("id").ToString, Integer)
                        For Each row As DataGridViewRow In Me.dgvComprobanteCierre.Rows
                            intComprobante = row.Cells("id").Value
                            strComprobante = row.Cells("comprobante").Value
                            strTipo = row.Cells("tipo").Value
                            intUnidad = IIf(row.Cells("unidad").Value = "CARGA", 1, 2)
                            dblMonto = row.Cells("efectivo").Value
                            obj2.GrabarComprobante(intId, intComprobante, strComprobante, strTipo, dblMonto, intUnidad, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dblRetiroSoles)
                        Next
                        If dblRetiroSoles > 0 Then
                            GrabarRemesa(1, dblRetiroSoles, dt3)
                        End If
                    End If
                Else 'con portavalor externo
                    Dim strFecha As String, dblMonto As Double, intUsuario As Integer
                    strFecha = Me.CboFechaLiquidacion.Value.ToShortDateString
                    Dim obj2 As New dtoCierreOficina
                    For Each row As DataGridViewRow In DgvListado.Rows
                        intUsuario = row.Cells("id_usuario_personal").Value
                        dblMonto = MontoEfectivo(IDLiquidacionOficina, dtoUSUARIOS.iIDAGENCIAS, strFecha, intUsuario)
                        obj2.GrabarOficinaValor(strFecha, dtoUSUARIOS.iIDAGENCIAS, intUsuario, dblMonto, IDLiquidacionOficina, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                    Next
                End If
            End If

            BtnBuscar_Click(sender, e)
            ListarCajas()
            LimpiarCerrar()

            Me.TabLiquidacion.Controls.Remove(Me.TabLiquidacion.TabPages("PagIngresoDatos"))
            'If tabFueraZona.TabPages.IndexOf(tabAceptacion) > -1 Then
            'Me.tabGasto.TabPages.Remove(tabGasto.TabPages("tabResumen"))
            'Me.TabLiquidacion.TabPages(1).Parent = Nothing

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub LimpiarCerrar()
        Me.dgvComprobanteCierre.Rows.Clear()
        Me.txtRetiroSolesCierre.Text = "0.00"
    End Sub

    Sub GrabarRemesa(ByVal moneda As Integer, ByVal monto As Double, ByVal dt As DataTable)
        Dim obj As New Cls_LiquidacionValor_LN
        Dim strFecha As String, intMoneda As Integer, dblMonto As Double, strComprobante As String
        Dim intPortavalor As Integer, strObservacion As String, intBanco As Integer, intCuentaCorriente As Integer
        Dim intID As Integer, intIDAnterior As Integer, intIDDetAnterior As Integer
        Dim strDni As String, strNombres As String, strCodigo As String

        intID = 0 : intIDAnterior = 0
        'strFecha = CDate(FechaServidor()).ToShortDateString
        strFecha = Me.CboFechaLiquidacion.Value.ToShortDateString
        intMoneda = moneda
        dblMonto = monto
        strComprobante = ""
        intPortavalor = dtoUSUARIOS.IdLogin : strDni = dtoUSUARIOS.DNI : strNombres = dtoUSUARIOS.NameLogin : strCodigo = ""
        strObservacion = "" : intBanco = 0 : intCuentaCorriente = 0

        intID = obj.GrabarRemesa(intID, strFecha, dtoUSUARIOS.iIDAGENCIAS, intMoneda, dblMonto, strComprobante,
                         intPortavalor, strDni, strNombres, strCodigo, _
                         strObservacion, intBanco, intCuentaCorriente, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)

        Dim intIdPreliquidacion As Integer
        With dt
            For Each row As DataRow In dt.Rows
                intIdPreliquidacion = row.Item("soles")
                intIDDetAnterior = 0 'row.Item("id_det")
                obj.GrabarRemesa(intID, intIdPreliquidacion, intIDAnterior, intIDDetAnterior, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
            Next
        End With
    End Sub

    Sub MostrarComprobante(ByVal dt As DataTable, ByVal unidad As Integer)
        With Me.dgvComprobanteCierre
            Dim blnProcesa As Boolean
            Dim intFila As Integer = .Rows.Count - 1
            Dim dblTotal As Double
            Dim obj As New Cls_LiquidacionValor_LN
            For Each row As DataRow In dt.Rows
                blnProcesa = True
                dblTotal = 0
                If unidad = 2 Then
                    Dim intExiste As Integer = obj.ExisteComprobante(row.Item("id"), 2, row.Item("opcion"))
                    If intExiste = 1 Then
                        blnProcesa = False
                    Else
                        If row.Item("total") = 0 Then
                            dblTotal = obj.ComprobanteOriginal(row.Item("id"), 2)
                        End If
                    End If
                End If
                If blnProcesa Then
                    intFila += 1
                    .Rows.Add()
                    .Rows(intFila).Cells("id_unidad").Value = row.Item("id_unidad")
                    .Rows(intFila).Cells("unidad").Value = row.Item("unidad")
                    .Rows(intFila).Cells("usuario").Value = dtoUSUARIOS.NameLogin
                    .Rows(intFila).Cells("tipo").Value = row.Item("tipo")
                    .Rows(intFila).Cells("comprobante").Value = row.Item("comprobante")
                    If dblTotal = 0 Then
                        .Rows(intFila).Cells("total").Value = row.Item("total")
                        .Rows(intFila).Cells("efectivo").Value = row.Item("efectivo")
                    Else
                        .Rows(intFila).Cells("total").Value = dblTotal
                        .Rows(intFila).Cells("efectivo").Value = dblTotal
                    End If
                    .Rows(intFila).Cells("id").Value = row.Item("id")
                    .Rows(intFila).Cells("id_usuario").Value = dtoUSUARIOS.IdLogin
                End If
            Next
        End With
    End Sub

    Function TotalGrid(ByVal dgv As DataGridView, ByVal columna As String, Optional ByVal fila As Integer = -1) As Double
        Dim dblMonto As Double = 0
        For Each row As DataGridViewRow In dgv.Rows
            If fila = -1 Then
                dblMonto += row.Cells(columna).Value
            Else
                If row.Index <> fila Then
                    dblMonto += row.Cells(columna).Value
                End If
            End If
        Next
        Return dblMonto
    End Function

    Sub FormateardgvComprobanteCierre()
        With dgvComprobanteCierre
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
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id_unidad As New DataGridViewTextBoxColumn
            With col_id_unidad
                .Name = "id_unidad" : .DataPropertyName = "id_unidad" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_unidad"
            End With

            x += +1
            Dim col_unidad As New DataGridViewTextBoxColumn
            With col_unidad
                .Name = "unidad" : .DataPropertyName = "unidad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Unidad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_comprobante As New DataGridViewTextBoxColumn
            With col_comprobante
                .Name = "comprobante" : .DataPropertyName = "comprobante"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Comprobante"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_total As New DataGridViewTextBoxColumn
            With col_total
                .Name = "total" : .DataPropertyName = "total"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Monto Total" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_efectivo As New DataGridViewTextBoxColumn
            With col_efectivo
                .Name = "efectivo" : .DataPropertyName = "efectivo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Monto" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id"
                .DisplayIndex = x : .HeaderText = "id" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_id_usuario As New DataGridViewTextBoxColumn
            With col_id_usuario
                .Name = "id_usuario" : .DataPropertyName = "id_usuario"
                .DisplayIndex = x : .HeaderText = "id_usuario" : .Visible = False
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id_unidad, col_unidad, col_tipo, col_comprobante, col_total, col_efectivo, col_id_usuario, col_id, col_usuario)
        End With
    End Sub

    Dim iTotalFactura As Double
    Dim iTotalBoleta As Double
    Dim iTotalPceFacturas As Double
    Dim iTotalPceBoletas As Double
    Dim iTotalIngreso As Double
    Dim iTotalEgreso As Double

    Function Totales() As DataTable
        Dim dtTotales As DataSet = ObjVentaCargaContado.ListaDatosLiquidacion(dtoUSUARIOS.m_iIdAgencia, IDLiquidacionOficina, CboFechaLiquidacion.Text, 1)
        Dim dt As DataTable = dtTotales.Tables(0).Copy
        iTotalFactura = IIf(IsDBNull(dt.Compute("sum(TOTAL_MONTO_FACTU)", "")), 0, dt.Compute("sum(TOTAL_MONTO_FACTU)", ""))
        iTotalBoleta = IIf(IsDBNull(dt.Compute("sum(TOTAL_MONTO_BOLE)", "")), 0, dt.Compute("sum(TOTAL_MONTO_BOLE)", ""))
        iTotalIngreso = IIf(IsDBNull(dt.Compute("sum(total_ingreso)", "")), 0, dt.Compute("sum(total_ingreso)", ""))
        iTotalEgreso = IIf(IsDBNull(dt.Compute("sum(total_egreso)", "")), 0, dt.Compute("sum(total_egreso)", ""))
        Return dt
    End Function

    '*****COUNTER CARGA********
    Dim dtCounterCargaDesasociadas2 As DataTable 'DTCounterCargaDesasociadas
    Private Sub BtnSeleccioncarga1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSeleccioncarga1.Click
        Try
            Me.Cursor = Cursors.AppStarting
            If LstCarga1.Items.Count > 0 Then
                If LstCarga2.SelectedItems.Count = 0 Then
                    dtCounterCargaDesasociadas2 = New DataTable
                    dtCounterCargaDesasociadas2.Columns.Add(New DataColumn("idliqui_turnos", GetType(Integer)))
                    dtCounterCargaDesasociadas2.Columns.Add(New DataColumn("idusuario_personal", GetType(Integer)))
                    dtCounterCargaDesasociadas2.Columns.Add(New DataColumn("nombre", GetType(String)))
                End If

                Dim dr As DataRow
                dr = dtCounterCargaDesasociadas2.NewRow
                dr("idliqui_turnos") = DTCounterCargaDesasociadas.Rows(LstCarga1.SelectedIndex)("idliqui_turnos")
                dr("idusuario_personal") = LstCarga1.SelectedValue
                dr("nombre") = LstCarga1.Text
                dtCounterCargaDesasociadas2.Rows.Add(dr)

                With Me.LstCarga2
                    .DataSource = dtCounterCargaDesasociadas2
                    .DisplayMember = "nombre"
                    .ValueMember = "idusuario_personal"
                End With


                Dim obj As New dtoCierreOficina
                obj.AsociarOficina(1, IDLiquidacionOficina, DTCounterCargaDesasociadas.Rows(LstCarga1.SelectedIndex)("idliqui_turnos"))

                DTCounterCargaDesasociadas.Rows.RemoveAt(LstCarga1.SelectedIndex)
                With Me.LstCarga1
                    .DataSource = DTCounterCargaDesasociadas
                    .DisplayMember = "nombre"
                    .ValueMember = "idusuario_personal"
                End With
                BtnTransferencia.Enabled = True
            Else
                Me.Cursor = Cursors.Default
                MessageBox.Show("No hay cajas cerradas para selecionar", "Titán", MessageBoxButtons.OK)
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnSeleccioncarga2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSeleccioncarga2.Click
        Try
            Me.Cursor = Cursors.AppStarting

            If LstCarga1.Items.Count > 0 Then
                'MessageBox.Show("Deseas Agregar todas las cajas para esta liquidacion", "Titán", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

                For i As Integer = 0 To LstCarga1.Items.Count() - 1
                    If LstCarga2.SelectedItems.Count = 0 Then
                        dtCounterCargaDesasociadas2 = New DataTable
                        dtCounterCargaDesasociadas2.Columns.Add(New DataColumn("idliqui_turnos", GetType(Integer)))
                        dtCounterCargaDesasociadas2.Columns.Add(New DataColumn("idusuario_personal", GetType(Integer)))
                        dtCounterCargaDesasociadas2.Columns.Add(New DataColumn("nombre", GetType(String)))
                    End If

                    Dim dr As DataRow
                    dr = dtCounterCargaDesasociadas2.NewRow
                    dr("idliqui_turnos") = DTCounterCargaDesasociadas.Rows(i)("idliqui_turnos")
                    dr("idusuario_personal") = DTCounterCargaDesasociadas.Rows(i)("idusuario_personal")
                    dr("nombre") = DTCounterCargaDesasociadas.Rows(i)("nombre")
                    dtCounterCargaDesasociadas2.Rows.Add(dr)

                    'dtCounterPsjesDesasociadas2 = dtCounterPsjesDesasociadas.Copy
                    With Me.LstCarga2
                        .DataSource = dtCounterCargaDesasociadas2
                        .DisplayMember = "nombre"
                        .ValueMember = "idusuario_personal"
                    End With

                    'ASOCIAR OFICINA
                    Dim obj As New dtoCierreOficina
                    obj.AsociarOficina(1, IDLiquidacionOficina, dtCounterCargaDesasociadas2.Rows(i)("idliqui_turnos"))

                    'ASOCIAR OFICINA PASAJES X COUNTER
                    'For i As Integer = 0 To dtCounterPsjesDesasociadas2.Rows.Count - 1 'MODIFICAR
                    '    Dim obj As New dtoCierreOficina
                    '    Me.AsociarOficinaPasajes(IDLiquidacionOficina, dtCounterPsjesDesasociadas.Rows(i)("idliqui_turnos"))
                    'Next
                Next
                DTCounterCargaDesasociadas = Nothing
                With Me.LstCarga1
                    .DataSource = DTCounterCargaDesasociadas
                    .DisplayMember = "nombre"
                    .ValueMember = "idusuario_personal"
                End With
                BtnTransferencia.Enabled = True
            Else
                MessageBox.Show("No hay cajas cerradas para selecionar", "Titán", MessageBoxButtons.OK)
            End If
            Me.Cursor = Cursors.Default
            ' Lst1.Items.Clear()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnSeleccionCarga3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSeleccionCarga3.Click
        Try
            Me.Cursor = Cursors.AppStarting
            If LstCarga2.Enabled = False Then
                Me.Cursor = Cursors.Default
                Return
            End If

            If LstCarga2.Items.Count > 0 Then
                If LstCarga1.SelectedItems.Count = 0 Then
                    DTCounterCargaDesasociadas = New DataTable
                    DTCounterCargaDesasociadas.Columns.Add(New DataColumn("idliqui_turnos", GetType(Integer)))
                    DTCounterCargaDesasociadas.Columns.Add(New DataColumn("idusuario_personal", GetType(Integer)))
                    DTCounterCargaDesasociadas.Columns.Add(New DataColumn("nombre", GetType(String)))
                End If

                Dim dr As DataRow
                dr = DTCounterCargaDesasociadas.NewRow
                dr("idliqui_turnos") = dtCounterCargaDesasociadas2.Rows(LstCarga2.SelectedIndex)("idliqui_turnos")
                dr("idusuario_personal") = LstCarga2.SelectedValue
                dr("nombre") = LstCarga2.Text
                DTCounterCargaDesasociadas.Rows.Add(dr)

                With Me.LstCarga2
                    .DataSource = dtCounterCargaDesasociadas2
                    .DisplayMember = "nombre"
                    .ValueMember = "idusuario_personal"
                End With

                Dim obj As New dtoCierreOficina
                obj.AsociarOficina(2, IDLiquidacionOficina, dtCounterCargaDesasociadas2.Rows(LstCarga2.SelectedIndex)("idliqui_turnos"))

                dtCounterCargaDesasociadas2.Rows.RemoveAt(LstCarga2.SelectedIndex)
                With Me.LstCarga1
                    .DataSource = DTCounterCargaDesasociadas
                    .DisplayMember = "nombre"
                    .ValueMember = "idusuario_personal"
                End With

                If LstCarga2.Items.Count <= 0 And LstPasajes2.Items.Count <= 0 Then
                    BtnTransferencia.Enabled = False
                Else
                    BtnTransferencia.Enabled = True
                End If
            Else
                If LstPasajes2.Items.Count <= 0 Then
                    BtnTransferencia.Enabled = False
                End If
                MessageBox.Show("No hay cajas cerradas para selecionar", "Titán", MessageBoxButtons.OK)
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnSeleccionCarga4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSeleccionCarga4.Click
        Try
            Me.Cursor = Cursors.AppStarting
            If LstCarga2.Enabled = False Then
                Me.Cursor = Cursors.Default
                Return
            End If

            If LstCarga2.Items.Count > 0 Then
                For i As Integer = 0 To LstCarga2.Items.Count() - 1
                    If LstCarga1.SelectedItems.Count = 0 Then
                        DTCounterCargaDesasociadas = New DataTable
                        DTCounterCargaDesasociadas.Columns.Add(New DataColumn("idliqui_turnos", GetType(Integer)))
                        DTCounterCargaDesasociadas.Columns.Add(New DataColumn("idusuario_personal", GetType(Integer)))
                        DTCounterCargaDesasociadas.Columns.Add(New DataColumn("nombre", GetType(String)))
                    End If

                    Dim dr As DataRow
                    dr = DTCounterCargaDesasociadas.NewRow
                    dr("idliqui_turnos") = dtCounterCargaDesasociadas2.Rows(i)("idliqui_turnos")
                    dr("idusuario_personal") = dtCounterCargaDesasociadas2.Rows(i)("idusuario_personal")
                    dr("nombre") = dtCounterCargaDesasociadas2.Rows(i)("nombre")
                    DTCounterCargaDesasociadas.Rows.Add(dr)

                    With Me.LstCarga1
                        .DataSource = DTCounterCargaDesasociadas
                        .DisplayMember = "nombre"
                        .ValueMember = "idusuario_personal"
                    End With

                    'ASOCIAR OFICINA
                    Dim obj As New dtoCierreOficina
                    obj.AsociarOficina(2, 0, dtCounterCargaDesasociadas2.Rows(i)("idliqui_turnos"))

                    'ASOCIAR OFICINA PASAJES X COUNTER
                    'For i As Integer = 0 To dtCounterPsjesDesasociadas2.Rows.Count - 1 'MODIFICAR
                    '    Dim obj As New dtoCierreOficina
                    '    Me.AsociarOficinaPasajes(IDLiquidacionOficina, dtCounterPsjesDesasociadas.Rows(i)("idliqui_turnos"))
                    'Next
                Next
                dtCounterCargaDesasociadas2 = Nothing
                With Me.LstCarga2
                    .DataSource = dtCounterCargaDesasociadas2
                    .DisplayMember = "nombre"
                    .ValueMember = "idusuario_personal"
                End With

                If LstCarga2.Items.Count <= 0 And LstPasajes2.Items.Count <= 0 Then
                    BtnTransferencia.Enabled = False
                Else
                    BtnTransferencia.Enabled = True
                End If
            Else
                If LstPasajes2.Items.Count <= 0 Then
                    BtnTransferencia.Enabled = False
                End If
                MessageBox.Show("No hay cajas cerradas para selecionar", "Titán", MessageBoxButtons.OK)
            End If
            ' Lst1.Items.Clear()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*****COUNTER PASAJES******
    Dim dtCounterPsjesDesasociadas2 As DataTable 'dtCounterPsjesDesasociadas

    Private Sub BtnSeleccionPsje1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSeleccionPsje1.Click
        Try
            Me.Cursor = Cursors.AppStarting
            If LstPasajes1.Items.Count > 0 Then
                If LstPasajes2.SelectedItems.Count = 0 Then
                    dtCounterPsjesDesasociadas2 = New DataTable
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("idliqui_turnos", GetType(Integer)))
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("idusuario_personal", GetType(Integer)))
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("EfectivoIngresado", GetType(Double)))
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("MontoEfectivo", GetType(Double)))
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("Login", GetType(String)))
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("nombre", GetType(String)))
                    '--
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("CANTCONTADO", GetType(Integer)))
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("TOTVTACONTADO", GetType(Double)))
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("CANTPREPA", GetType(Integer)))
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("TOTPREPA", GetType(Double)))
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("CANTCRED", GetType(Integer)))
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("TOTCRED", GetType(Double)))
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("CANTCORTE", GetType(Integer)))
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("TOTCORTE", GetType(Double)))
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("CANTRECIBO", GetType(Integer)))
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("TOTRECIBO", GetType(Double)))
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("CANTTC", GetType(Integer)))
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("TOTTC", GetType(Double)))
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("CANTPEAJES", GetType(Integer)))
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("TOTPEAJES", GetType(Double)))
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("CANTDEVPSJES", GetType(Integer)))
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("TOTDEVPSJES", GetType(Double)))
                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("TOTGASTOS", GetType(Double)))

                    dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("idliq_sisvyr", GetType(Integer)))                    
                End If

                Dim dr As DataRow
                dr = dtCounterPsjesDesasociadas2.NewRow
                dr("idliqui_turnos") = dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("idliqui_turnos")
                dr("idusuario_personal") = LstPasajes1.SelectedValue
                dr("EfectivoIngresado") = dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("EfectivoIngresado")
                dr("MontoEfectivo") = dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("MontoEfectivo")
                dr("Login") = dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("Login")
                dr("nombre") = LstPasajes1.Text
                dr("CANTCONTADO") = dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("CANTCONTADO")
                dr("TOTVTACONTADO") = dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("TOTVTACONTADO")
                dr("CANTPREPA") = dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("CANTPREPA")
                dr("TOTPREPA") = dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("TOTPREPA")
                dr("CANTCRED") = dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("CANTCRED")
                dr("TOTCRED") = dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("TOTCRED")
                dr("CANTCORTE") = dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("CANTCORTE")
                dr("TOTCORTE") = dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("TOTCORTE")
                dr("CANTRECIBO") = dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("CANTRECIBO")
                dr("TOTRECIBO") = dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("TOTRECIBO")
                dr("CANTTC") = dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("CANTTC")
                dr("TOTTC") = dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("TOTTC")
                dr("CANTPEAJES") = dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("CANTPEAJES")
                dr("TOTPEAJES") = dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("TOTPEAJES")
                dr("CANTDEVPSJES") = dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("CANTDEVPSJES")
                dr("TOTDEVPSJES") = dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("TOTDEVPSJES")
                dr("TOTGASTOS") = dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("TOTGASTOS")

                dr("idliq_sisvyr") = dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("idliqui_turnos")
                
                dtCounterPsjesDesasociadas2.Rows.Add(dr)

                With Me.LstPasajes2
                    .DataSource = dtCounterPsjesDesasociadas2
                    .DisplayMember = "nombre"
                    .ValueMember = "idusuario_personal"
                    BtnTransferencia.Enabled = True
                End With

                '**
                Dim obj As New dtoCierreOficina
                obj.OficinaXUsuariosPasajes(1, IDLiquidacionOficina, dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("Login"), _
                                            dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("MontoEfectivo"), _
                                            dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("EfectivoIngresado"),
                                            LblFecha.Text, _
                                            dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("CANTCONTADO"), _
                                            dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("TOTVTACONTADO"), _
                                            dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("CANTPREPA"), _
                                            dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("TOTPREPA"), _
                                            dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("CANTCRED"), _
                                            dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("TOTCRED"), _
                                            dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("CANTCORTE"), _
                                            dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("TOTCORTE"), _
                                            dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("CANTRECIBO"), _
                                            dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("TOTRECIBO"), _
                                            dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("CANTTC"), _
                                            dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("TOTTC"), _
                                            dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("CANTPEAJES"), _
                                            dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("TOTPEAJES"), _
                                            dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("CANTDEVPSJES"), _
                                            dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("TOTDEVPSJES"), _
                                            dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("TOTGASTOS"), _
                                            dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("idusuario_personal"), _
                                            dtoUSUARIOS.m_iIdAgencia, _
                                            dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("idliqui_turnos"))
                '**
                '-------
                dtCounterPsjesDesasociadas.Rows.RemoveAt(LstPasajes1.SelectedIndex)
                With Me.LstPasajes1
                    .DataSource = dtCounterPsjesDesasociadas
                    .DisplayMember = "nombre"
                    .ValueMember = "idusuario_personal"
                End With

                'ASOCIAR OFICINA X COUNTER                
                'Me.AsociarOficinaPasajes(IDLiquidacionOficina, dtCounterPsjesDesasociadas.Rows(LstPasajes1.SelectedIndex)("idliqui_turnos"))
            Else
                MessageBox.Show("No hay cajas cerradas para selecionar", "Titán", MessageBoxButtons.OK)
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnSeleccionPsje2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSeleccionPsje2.Click
        Try


            Me.Cursor = Cursors.AppStarting
            If LstPasajes1.Items.Count > 0 Then
                'MessageBox.Show("Deseas Agregar todas las cajas para esta liquidacion", "Titán", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

                For i As Integer = 0 To LstPasajes1.Items.Count() - 1
                    If LstPasajes2.SelectedItems.Count = 0 Then
                        dtCounterPsjesDesasociadas2 = New DataTable
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("idliqui_turnos", GetType(Integer)))
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("idusuario_personal", GetType(Integer)))
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("EfectivoIngresado", GetType(Double)))
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("MontoEfectivo", GetType(Double)))
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("Login", GetType(String)))
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("nombre", GetType(String)))
                        '--
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("CANTCONTADO", GetType(Integer)))
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("TOTVTACONTADO", GetType(Double)))
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("CANTPREPA", GetType(Integer)))
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("TOTPREPA", GetType(Double)))
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("CANTCRED", GetType(Integer)))
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("TOTCRED", GetType(Double)))
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("CANTCORTE", GetType(Integer)))
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("TOTCORTE", GetType(Double)))
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("CANTRECIBO", GetType(Integer)))
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("TOTRECIBO", GetType(Double)))
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("CANTTC", GetType(Integer)))
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("TOTTC", GetType(Double)))
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("CANTPEAJES", GetType(Integer)))
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("TOTPEAJES", GetType(Double)))
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("CANTDEVPSJES", GetType(Integer)))
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("TOTDEVPSJES", GetType(Double)))
                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("TOTGASTOS", GetType(Double)))

                        dtCounterPsjesDesasociadas2.Columns.Add(New DataColumn("idliq_sisvyr", GetType(Integer)))
                        
                    End If

                    Dim dr As DataRow
                    dr = dtCounterPsjesDesasociadas2.NewRow
                    dr("idliqui_turnos") = dtCounterPsjesDesasociadas.Rows(i)("idliqui_turnos")
                    dr("idusuario_personal") = dtCounterPsjesDesasociadas.Rows(i)("idusuario_personal")
                    dr("EfectivoIngresado") = dtCounterPsjesDesasociadas.Rows(i)("EfectivoIngresado")
                    dr("MontoEfectivo") = dtCounterPsjesDesasociadas.Rows(i)("MontoEfectivo")
                    dr("Login") = dtCounterPsjesDesasociadas.Rows(i)("Login")
                    dr("nombre") = dtCounterPsjesDesasociadas.Rows(i)("nombre")
                    dr("CANTCONTADO") = dtCounterPsjesDesasociadas.Rows(i)("CANTCONTADO")
                    dr("TOTVTACONTADO") = dtCounterPsjesDesasociadas.Rows(i)("TOTVTACONTADO")
                    dr("CANTPREPA") = dtCounterPsjesDesasociadas.Rows(i)("CANTPREPA")
                    dr("TOTPREPA") = dtCounterPsjesDesasociadas.Rows(i)("TOTPREPA")
                    dr("CANTCRED") = dtCounterPsjesDesasociadas.Rows(i)("CANTCRED")
                    dr("TOTCRED") = dtCounterPsjesDesasociadas.Rows(i)("TOTCRED")
                    dr("CANTCORTE") = dtCounterPsjesDesasociadas.Rows(i)("CANTCORTE")
                    dr("TOTCORTE") = dtCounterPsjesDesasociadas.Rows(i)("TOTCORTE")
                    dr("CANTRECIBO") = dtCounterPsjesDesasociadas.Rows(i)("CANTRECIBO")
                    dr("TOTRECIBO") = dtCounterPsjesDesasociadas.Rows(i)("TOTRECIBO")
                    dr("CANTTC") = dtCounterPsjesDesasociadas.Rows(i)("CANTTC")
                    dr("TOTTC") = dtCounterPsjesDesasociadas.Rows(i)("TOTTC")
                    dr("CANTPEAJES") = dtCounterPsjesDesasociadas.Rows(i)("CANTPEAJES")
                    dr("TOTPEAJES") = dtCounterPsjesDesasociadas.Rows(i)("TOTPEAJES")
                    dr("CANTDEVPSJES") = dtCounterPsjesDesasociadas.Rows(i)("CANTDEVPSJES")
                    dr("TOTDEVPSJES") = dtCounterPsjesDesasociadas.Rows(i)("TOTDEVPSJES")
                    dr("TOTGASTOS") = dtCounterPsjesDesasociadas.Rows(i)("TOTGASTOS")

                    dr("idliq_sisvyr") = dtCounterPsjesDesasociadas.Rows(i)("idliqui_turnos")
                    
                    dtCounterPsjesDesasociadas2.Rows.Add(dr)

                    'dtCounterPsjesDesasociadas2 = dtCounterPsjesDesasociadas.Copy
                    With Me.LstPasajes2
                        .DataSource = dtCounterPsjesDesasociadas2
                        .DisplayMember = "nombre"
                        .ValueMember = "idusuario_personal"
                    End With


                    '**
                    Dim obj As New dtoCierreOficina
                    obj.OficinaXUsuariosPasajes(1, IDLiquidacionOficina, dtCounterPsjesDesasociadas.Rows(i)("Login"), _
                                                dtCounterPsjesDesasociadas.Rows(i)("MontoEfectivo"), _
                                                dtCounterPsjesDesasociadas.Rows(i)("EfectivoIngresado"),
                                                LblFecha.Text, _
                                                dtCounterPsjesDesasociadas.Rows(i)("CANTCONTADO"), _
                                                dtCounterPsjesDesasociadas.Rows(i)("TOTVTACONTADO"), _
                                                dtCounterPsjesDesasociadas.Rows(i)("CANTPREPA"), _
                                                dtCounterPsjesDesasociadas.Rows(i)("TOTPREPA"), _
                                                dtCounterPsjesDesasociadas.Rows(i)("CANTCRED"), _
                                                dtCounterPsjesDesasociadas.Rows(i)("TOTCRED"), _
                                                dtCounterPsjesDesasociadas.Rows(i)("CANTCORTE"), _
                                                dtCounterPsjesDesasociadas.Rows(i)("TOTCORTE"), _
                                                dtCounterPsjesDesasociadas.Rows(i)("CANTRECIBO"), _
                                                dtCounterPsjesDesasociadas.Rows(i)("TOTRECIBO"), _
                                                dtCounterPsjesDesasociadas.Rows(i)("CANTTC"), _
                                                dtCounterPsjesDesasociadas.Rows(i)("TOTTC"), _
                                                dtCounterPsjesDesasociadas.Rows(i)("CANTPEAJES"), _
                                                dtCounterPsjesDesasociadas.Rows(i)("TOTPEAJES"), _
                                                dtCounterPsjesDesasociadas.Rows(i)("CANTDEVPSJES"), _
                                                dtCounterPsjesDesasociadas.Rows(i)("TOTDEVPSJES"), _
                                                dtCounterPsjesDesasociadas.Rows(i)("TOTGASTOS"), _
                                                dtCounterPsjesDesasociadas.Rows(i)("idusuario_personal"), _
                                                dtoUSUARIOS.m_iIdAgencia, _
                                                dtCounterPsjesDesasociadas.Rows(i)("idliqui_turnos"))
                    '**

                    '-------

                    'ASOCIAR OFICINA PASAJES X COUNTER
                    'For i As Integer = 0 To dtCounterPsjesDesasociadas2.Rows.Count - 1 'MODIFICAR
                    '    Dim obj As New dtoCierreOficina
                    '    Me.AsociarOficinaPasajes(IDLiquidacionOficina, dtCounterPsjesDesasociadas.Rows(i)("idliqui_turnos"))
                    'Next
                Next
                dtCounterPsjesDesasociadas = Nothing
                With Me.LstPasajes1
                    .DataSource = dtCounterPsjesDesasociadas
                    .DisplayMember = "nombre"
                    .ValueMember = "idusuario_personal"
                End With
                BtnTransferencia.Enabled = True
            Else
                MessageBox.Show("No hay cajas cerradas para seleccionar", "Titán", MessageBoxButtons.OK)
            End If
            ' Lst1.Items.Clear()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnSeleccionPsje3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSeleccionPsje3.Click
        Try
            Me.Cursor = Cursors.AppStarting
            If LstPasajes2.Enabled = False Then
                Me.Cursor = Cursors.Default
                Return
            End If

            If LstPasajes2.Items.Count > 0 Then

                If LstPasajes1.SelectedItems.Count = 0 Then
                    dtCounterPsjesDesasociadas = New DataTable
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("idliqui_turnos", GetType(Integer)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("idusuario_personal", GetType(Integer)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("EfectivoIngresado", GetType(Double)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("MontoEfectivo", GetType(Double)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("Login", GetType(String)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("nombre", GetType(String)))
                    '--
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("CANTCONTADO", GetType(Integer)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("TOTVTACONTADO", GetType(Double)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("CANTPREPA", GetType(Integer)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("TOTPREPA", GetType(Double)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("CANTCRED", GetType(Integer)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("TOTCRED", GetType(Double)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("CANTCORTE", GetType(Integer)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("TOTCORTE", GetType(Double)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("CANTRECIBO", GetType(Integer)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("TOTRECIBO", GetType(Double)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("CANTTC", GetType(Integer)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("TOTTC", GetType(Double)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("CANTPEAJES", GetType(Integer)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("TOTPEAJES", GetType(Double)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("CANTDEVPSJES", GetType(Integer)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("TOTDEVPSJES", GetType(Double)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("TOTGASTOS", GetType(Double)))
                End If

                Dim dr As DataRow
                dr = dtCounterPsjesDesasociadas.NewRow
                dr("idliqui_turnos") = dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("idliqui_turnos")
                dr("idusuario_personal") = LstPasajes2.SelectedValue
                dr("EfectivoIngresado") = dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("EfectivoIngresado")
                dr("MontoEfectivo") = dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("MontoEfectivo")
                dr("Login") = dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("Login")
                dr("nombre") = LstPasajes2.Text
                dr("CANTCONTADO") = dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("CANTCONTADO")
                dr("TOTVTACONTADO") = dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("TOTVTACONTADO")
                dr("CANTPREPA") = dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("CANTPREPA")
                dr("TOTPREPA") = dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("TOTPREPA")
                dr("CANTCRED") = dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("CANTCRED")
                dr("TOTCRED") = dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("TOTCRED")
                dr("CANTCORTE") = dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("CANTCORTE")
                dr("TOTCORTE") = dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("TOTCORTE")
                dr("CANTRECIBO") = dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("CANTRECIBO")
                dr("TOTRECIBO") = dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("TOTRECIBO")
                dr("CANTTC") = dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("CANTTC")
                dr("TOTTC") = dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("TOTTC")
                dr("CANTPEAJES") = dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("CANTPEAJES")
                dr("TOTPEAJES") = dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("TOTPEAJES")
                dr("CANTDEVPSJES") = dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("CANTDEVPSJES")
                dr("TOTDEVPSJES") = dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("TOTDEVPSJES")
                dr("TOTGASTOS") = dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("TOTGASTOS")

                dtCounterPsjesDesasociadas.Rows.Add(dr)

                With Me.LstPasajes2
                    .DataSource = dtCounterPsjesDesasociadas2
                    .DisplayMember = "nombre"
                    .ValueMember = "idusuario_personal"
                End With

                '**
                Dim obj As New dtoCierreOficina
                obj.OficinaXUsuariosPasajes(2, IDLiquidacionOficina, dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("Login"), 0, 0, 0, _
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, dtoUSUARIOS.m_iIdAgencia, 0)
                '**

                dtCounterPsjesDesasociadas2.Rows.RemoveAt(LstPasajes2.SelectedIndex)
                With Me.LstPasajes1
                    .DataSource = dtCounterPsjesDesasociadas
                    .DisplayMember = "nombre"
                    .ValueMember = "idusuario_personal"
                End With

                'DESASOCIAR OFICINA X COUNTER
                'Dim obj As New dtoCierreOficina
                'Me.DesasociarOficinaPasajes(IDLiquidacionOficina, dtCounterPsjesDesasociadas2.Rows(LstPasajes2.SelectedIndex)("idliqui_turnos"))
                ''---
                'obj.Transferencia_InsDel(2, LstPasajes2.SelectedValue, dtoUSUARIOS.m_sFecha, dtoUSUARIOS.iIDAGENCIAS, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                ''---
                If LstCarga2.Items.Count <= 0 And LstPasajes2.Items.Count <= 0 Then
                    BtnTransferencia.Enabled = False
                Else
                    BtnTransferencia.Enabled = True
                End If
            Else
                If LstCarga2.Items.Count <= 0 Then
                    BtnTransferencia.Enabled = False
                End If
                MessageBox.Show("No hay cajas cerradas para selecionar", "Titán", MessageBoxButtons.OK)
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnSeleccionPsje4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSeleccionPsje4.Click
        Me.Cursor = Cursors.AppStarting
        If LstPasajes2.Items.Count > 0 Then
            If Not LstPasajes2.Enabled Then
                Me.Cursor = Cursors.Default
                Return
            End If

            For i As Integer = 0 To LstPasajes2.Items.Count() - 1
                If LstPasajes1.Items.Count = 0 Then
                    dtCounterPsjesDesasociadas = New DataTable
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("idliqui_turnos", GetType(Integer)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("idusuario_personal", GetType(Integer)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("EfectivoIngresado", GetType(Double)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("MontoEfectivo", GetType(Double)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("Login", GetType(String)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("nombre", GetType(String)))
                    '
                    '--
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("CANTCONTADO", GetType(Integer)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("TOTVTACONTADO", GetType(Double)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("CANTPREPA", GetType(Integer)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("TOTPREPA", GetType(Double)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("CANTCRED", GetType(Integer)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("TOTCRED", GetType(Double)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("CANTCORTE", GetType(Integer)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("TOTCORTE", GetType(Double)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("CANTRECIBO", GetType(Integer)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("TOTRECIBO", GetType(Double)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("CANTTC", GetType(Integer)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("TOTTC", GetType(Double)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("CANTPEAJES", GetType(Integer)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("TOTPEAJES", GetType(Double)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("CANTDEVPSJES", GetType(Integer)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("TOTDEVPSJES", GetType(Double)))
                    dtCounterPsjesDesasociadas.Columns.Add(New DataColumn("TOTGASTOS", GetType(Double)))

                End If

                Dim dr As DataRow
                dr = dtCounterPsjesDesasociadas.NewRow
                dr("idliqui_turnos") = dtCounterPsjesDesasociadas2.Rows(i)("idliqui_turnos")
                dr("idusuario_personal") = dtCounterPsjesDesasociadas2.Rows(i)("idusuario_personal")
                dr("EfectivoIngresado") = dtCounterPsjesDesasociadas2.Rows(i)("EfectivoIngresado")
                dr("MontoEfectivo") = dtCounterPsjesDesasociadas2.Rows(i)("MontoEfectivo")
                dr("Login") = dtCounterPsjesDesasociadas2.Rows(i)("Login")
                dr("nombre") = dtCounterPsjesDesasociadas2.Rows(i)("nombre")
                dr("CANTCONTADO") = dtCounterPsjesDesasociadas2.Rows(i)("CANTCONTADO")
                dr("TOTVTACONTADO") = dtCounterPsjesDesasociadas2.Rows(i)("TOTVTACONTADO")
                dr("CANTPREPA") = dtCounterPsjesDesasociadas2.Rows(i)("CANTPREPA")
                dr("TOTPREPA") = dtCounterPsjesDesasociadas2.Rows(i)("TOTPREPA")
                dr("CANTCRED") = dtCounterPsjesDesasociadas2.Rows(i)("CANTCRED")
                dr("TOTCRED") = dtCounterPsjesDesasociadas2.Rows(i)("TOTCRED")
                dr("CANTCORTE") = dtCounterPsjesDesasociadas2.Rows(i)("CANTCORTE")
                dr("TOTCORTE") = dtCounterPsjesDesasociadas2.Rows(i)("TOTCORTE")
                dr("CANTRECIBO") = dtCounterPsjesDesasociadas2.Rows(i)("CANTRECIBO")
                dr("TOTRECIBO") = dtCounterPsjesDesasociadas2.Rows(i)("TOTRECIBO")
                dr("CANTTC") = dtCounterPsjesDesasociadas2.Rows(i)("CANTTC")
                dr("TOTTC") = dtCounterPsjesDesasociadas2.Rows(i)("TOTTC")
                dr("CANTPEAJES") = dtCounterPsjesDesasociadas2.Rows(i)("CANTPEAJES")
                dr("TOTPEAJES") = dtCounterPsjesDesasociadas2.Rows(i)("TOTPEAJES")
                dr("CANTDEVPSJES") = dtCounterPsjesDesasociadas2.Rows(i)("CANTDEVPSJES")
                dr("TOTDEVPSJES") = dtCounterPsjesDesasociadas2.Rows(i)("TOTDEVPSJES")
                dr("TOTGASTOS") = dtCounterPsjesDesasociadas2.Rows(i)("TOTGASTOS")

                dtCounterPsjesDesasociadas.Rows.Add(dr)

                'dtCounterPsjesDesasociadas2 = dtCounterPsjesDesasociadas.Copy
                With Me.LstPasajes1
                    .DataSource = dtCounterPsjesDesasociadas
                    .DisplayMember = "nombre"
                    .ValueMember = "idusuario_personal"
                End With

                '**
                Dim obj As New dtoCierreOficina
                obj.OficinaXUsuariosPasajes(2, IDLiquidacionOficina, dtCounterPsjesDesasociadas2.Rows(i)("Login"), 0, 0, 0, _
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, dtoUSUARIOS.m_iIdAgencia, 0)
                '**

                'ASOCIAR OFICINA PASAJES X COUNTER
                'For i As Integer = 0 To dtCounterPsjesDesasociadas2.Rows.Count - 1 'MODIFICAR
                '    Dim obj As New dtoCierreOficina
                '    Me.AsociarOficinaPasajes(IDLiquidacionOficina, dtCounterPsjesDesasociadas.Rows(i)("idliqui_turnos"))
                'Next
            Next
            dtCounterPsjesDesasociadas2 = Nothing
            With Me.LstPasajes2
                .DataSource = dtCounterPsjesDesasociadas2
                .DisplayMember = "nombre"
                .ValueMember = "idusuario_personal"
            End With
            If LstCarga2.Items.Count <= 0 And LstPasajes2.Items.Count <= 0 Then
                BtnTransferencia.Enabled = False
            Else
                BtnTransferencia.Enabled = True
            End If
        Else
            If LstCarga2.Items.Count <= 0 Then
                BtnTransferencia.Enabled = False
            End If
            MessageBox.Show("No hay cajas cerradas para selecionar", "Titán", MessageBoxButtons.OK)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Dim bTrasferencia As Boolean = False

    Private Sub BtnTransferencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTransferencia.Click
        Dim j As Integer = 0
        Try
            BtnTransferencia.Enabled = False
            LstPasajes2.Enabled = False
            LstCarga2.Enabled = False

            Dim IDCounters As String = ""
            'Dim IDLiquidaciones As String = ""
            Dim obj As New dtoCierreOficina

            '======USUARIOS PASAJES====================
            If LstPasajes2.SelectedItems.Count > 0 Then
                If MessageBox.Show("¿Desea realizar la transferencia?", "Titán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.AppStarting
                    For i As Integer = 0 To dtCounterPsjesDesasociadas2.Rows.Count - 1
                        Dim IDLiquidaciones As Long = dtCounterPsjesDesasociadas2.Rows(i)("idliq_sisvyr")

                        '========>IMPLEMENTADO el 22/01/2014 - jabanto
                        Dim dsConsulta As DataSet = liquidacionSisvyr.buscarVentasTrans(IDLiquidaciones) '-->Obtiene las ventas y gastos a transferir del sisvyr al titan.
                        Dim dtVentas As DataTable = dsConsulta.Tables(0) '-->Pasa las ventas al DataTable dtVentas
                        Dim dtGastos As DataTable = dsConsulta.Tables(1) '-->Pasa los gastos al DataTable dtGastos
                        Dim dtLiquidacion As DataTable = dsConsulta.Tables(2) '-->Pasa datos de la liquidacion de pasajes

                        '-->Realiza la transferencia de las ventas al titan a la tabla temporal denominada vrttrans_ventas_tmp
                        For Each row As DataRow In dtVentas.Rows
                            j += 1
                            If j = 34 Then
                                j = 0
                            End If
                            liquidacionSisvyr.transfiereVentasTmp_Titan(row("idVenta"),
                                                                        row("idPasajero"),
                                                                        IIf(IsDBNull(row("apellidoPartenoPax")), "", row("apellidoPartenoPax")),
                                                                        IIf(IsDBNull(row("apellidoMaternoPx")), "", row("apellidoMaternoPx")),
                                                                        IIf(IsDBNull(row("NombrePax1")), "", row("NombrePax1")),
                                                                        IIf(IsDBNull(row("NombrePax2")), "", row("NombrePax2")),
                                                                        IIf(IsDBNull(row("documentoPax")), "", row("documentoPax")),
                                                                        row("tipoDocPax"),
                                                                        row("idTipoComprobante"),
                                                                        row("idFormaPago"),
                                                                        row("idTipoFormaPago"),
                                                                        IIf(IsDBNull(row("nroAsiento")), 0, row("nroAsiento")),
                                                                        row("MontoBase"),
                                                                        IIf(IsDBNull(row("recargo")), 0.0, row("recargo")),
                                                                        IIf(IsDBNull(row("descuento")), 0.0, row("descuento")),
                                                                        IIf(IsDBNull(row("penalidad")), 0.0, row("penalidad")),
                                                                        row("montoTotal"),
                                                                        IIf(IsDBNull(row("montoEfectivo_mixto")), 0.0, row("montoEfectivo_mixto")),
                                                                        IIf(IsDBNull(row("montoTarjeta_mixto")), 0.0, row("montoTarjeta_mixto")),
                                                                        IIf(IsDBNull(row("idClase")), 0, row("idClase")),
                                                                        row("codigoAgenciaVenta"),
                                                                        IIf(IsDBNull(row("codigoAgenciaEmbarque")), "", row("codigoAgenciaEmbarque")),
                                                                        IIf(IsDBNull(row("idOpeTarjeta")), 0, row("idOpeTarjeta")),
                                                                        row("serie"),
                                                                        row("numeroBoleto"),
                                                                        IIf(IsDBNull(row("serieRef")), "", row("serieRef")),
                                                                        IIf(IsDBNull(row("numeroBoletoRef")), "", row("numeroBoletoRef")),
                                                                        IIf(IsDBNull(row("idCliente")), 0, row("idCliente")),
                                                                        IIf(IsDBNull(row("ruc")), "", row("ruc")),
                                                                        IIf(IsDBNull(row("razonSocial")), "", row("razonSocial")),
                                                                        row("fechaVenta"),
                                                                        IIf(IsDBNull(row("horaVenta")), "", row("horaVenta")),
                                                                        IIf(IsDBNull(row("fechaViaje")), "", row("fechaViaje")),
                                                                        IIf(IsDBNull(row("horaSalida")), "", row("horaSalida")),
                                                                        IIf(IsDBNull(row("idUnidadOrigen")), 0, row("idUnidadOrigen")),
                                                                        IIf(IsDBNull(row("idUnidadDestino")), 0, row("idUnidadDestino")),
                                                                        IIf(IsDBNull(row("codigoAgenciaOrigen")), "", row("codigoAgenciaOrigen")),
                                                                        IIf(IsDBNull(row("codigoAgenciaDestino")), "", row("codigoAgenciaDestino")),
                                                                        row("idUsuarioPersonal"),
                                                                        row("loginUsuario"),
                                                                        IIf(IsDBNull(row("apepatUsuario")), "", row("apepatUsuario")),
                                                                        IIf(IsDBNull(row("apematUsuario")), "", row("apematUsuario")),
                                                                        IIf(IsDBNull(row("nombreUsuario")), "", row("nombreUsuario")),
                                                                        IIf(IsDBNull(row("codigoCuenta")), "", row("codigoCuenta")),
                                                                        row("idTipomovimiento"),
                                                                        IIf(IsDBNull(row("porcentajeDevo")), 0.0, row("porcentajeDevo")),
                                                                        row("esFechaAbierta"),
                                                                        IIf(IsDBNull(row("idPromocion")), 0, row("idPromocion")),
                                                                        row("idLiquidacion"),
                                                                        IIf(IsDBNull(row("igv")), 0.0, row("igv")),
                                                                        IIf(IsDBNull(row("imppagdif")), 0.0, row("imppagdif"))
                                                                        )
                        Next


                        '-->Realiza la transferencia de los gastos del sisvyr al titan a la tabla t_gastosliquidacion_diaria
                        For Each row As DataRow In dtGastos.Rows
                            liquidacionSisvyr.transfiereGastos_titan(LblCodLiquidacion.Text,
                                                                     row("idGasto"),
                                                                     row("idTipoGasto"),
                                                                     row("monto"),
                                                                     IIf(IsDBNull(row("numeroDocumento")), "", row("numeroDocumento")),
                                                                     IIf(IsDBNull(row("nombrePiloto")), "", row("nombrePiloto")),
                                                                     IIf(IsDBNull(row("codigoBus")), "", row("codigoBus")),
                                                                     IIf(IsDBNull(row("consignado")), "", row("consignado")),
                                                                     IIf(IsDBNull(row("observaciones")), "", row("observaciones")),
                                                                     IIf(IsDBNull(row("horaRegistro")), "", row("horaRegistro")),
                                                                     IIf(IsDBNull(row("horaActualizacion")), "", row("horaActualizacion")),
                                                                     row("fechaOperacion"),
                                                                     row("login"), row("idLiquidacion")
                                                                     )
                        Next

                        If (dtLiquidacion.Rows.Count > 0) Then
                            '--> implementado 30/06/2014 
                            '--> Modificado 06/11/2014 (jabanto)
                            '--> REALIZA LA TRANSFERENCIA DE LOS MONTOS DE LAS VENTAS DE LOS SEGUROS.
                            Dim idUsuario As Integer = dtLiquidacion.Rows(0).Item("USUARIO_ID")
                            Dim idAgencia As Integer = dtLiquidacion.Rows(0).Item("AGENCIA_ID")
                            Dim fechaLiquidacion As String = dtLiquidacion.Rows(0).Item("D_FECLIQ")
                            Dim liqVentaSeguro As New dtoLiquiOficinaVentaSeguro
                            Dim dtvetaSeguro As DataTable = liqVentaSeguro.buscarVentas(idAgencia, fechaLiquidacion, idUsuario).Tables(0)
                            If (dtvetaSeguro.Rows.Count > 0) Then
                                Dim cantidadPaxFree As Integer = 0
                                Dim cantidadPaxNor As Integer = 0
                                Dim totalPaxFree As Double = 0.0
                                Dim totalPaxNor As Double = 0.0
                                For Each row As DataRow In dtvetaSeguro.Rows
                                    If (row("tipoPax") = "S") Then '--Pasajeros frecuentes
                                        cantidadPaxFree = row("cantidad")
                                        totalPaxFree = row("monto")
                                    Else '-->No frecuentes
                                        cantidadPaxNor = row("cantidad")
                                        totalPaxNor = row("monto")
                                    End If
                                Next
                                '-->actualiza cantidades y montos en la tabla t_liqui_turno_pasaje TITAN.
                                liquidacionSisvyr.actuliazaVentaSeguros(IDLiquidaciones, cantidadPaxFree, cantidadPaxNor, totalPaxFree, totalPaxNor)
                            End If
                        End If

                        '-->Ventas del pool - jabanto 19/10/2016
                        Dim dataSet As DataSet = liquidacionSisvyr.buscarVentasPool(IDLiquidaciones)
                        If (dataSet.Tables(0).Rows.Count > 0) Then
                            Dim cantidadEfectivo As Integer = dataSet.Tables(0).Rows(0)("C_EFE")
                            Dim cantidadVisa As Integer = dataSet.Tables(0).Rows(0)("C_VISA")
                            Dim cantidadMastercard As Integer = dataSet.Tables(0).Rows(0)("C_MASTERCARD")
                            Dim montoEfectivo As Double = dataSet.Tables(0).Rows(0)("M_EFE")
                            Dim montoVisa As Double = dataSet.Tables(0).Rows(0)("M_VISA")
                            Dim montoMastercad As Double = dataSet.Tables(0).Rows(0)("M_MASTERCARD")

                            liquidacionSisvyr.actualizarVentasPool_Titan(IDLiquidaciones, cantidadEfectivo, cantidadVisa, cantidadMastercard, montoEfectivo, montoVisa, montoMastercad)
                        End If
                    Next

                    '====>Realiza el proceso de transferencia de la tabla temporal vrttrans_ventas_tmp a la t_venta_pasajes, ambas tablas son de titan.
                    Dim dtProceso As DataTable = liquidacionSisvyr.procesarVentasTransferidas_titan(LblFecha.Text, dtoUSUARIOS.codAgenciaSisvyr).Tables(1) '-->implementado 23/01/2014 - jabanto
                    If dtProceso.Rows.Count > 0 Then
                        If Not IsDBNull(dtProceso.Rows(0).Item(0)) Then
                            MessageBox.Show(dtProceso.Rows(0)("MsjeError"), "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.Cursor = Cursors.Default
                            Return
                        End If
                    End If

                    '-->Actualiza el estado de las liquidacion de turno
                    For i As Integer = 0 To dtCounterPsjesDesasociadas2.Rows.Count - 1
                        obj.ActualizarEstadoPasaje(LblCodLiquidacion.Text, LblFecha.Text, dtCounterPsjesDesasociadas2.Rows(i)("Login"))
                    Next

                    '-->Actualiza el campo fecha transferencia (d_fectra) en las tabla vrtvenpas en el Sisvyr
                    For i As Integer = 0 To dtCounterPsjesDesasociadas2.Rows.Count - 1
                        Dim IDLiquidacion As Long = dtCounterPsjesDesasociadas2.Rows(i)("idliq_sisvyr")
                        liquidacionSisvyr.actualizaFechaTransSisvyr(IDLiquidacion)
                    Next
                End If
            End If

            '====USUARIOS CARGA========================
            IDCounters = ""
            If LstCarga2.Items.Count > 0 Then
                For i As Integer = 0 To dtCounterCargaDesasociadas2.Rows.Count - 1
                    If IDCounters = "" Then
                        IDCounters = dtCounterCargaDesasociadas2.Rows(i)(1)
                    Else
                        IDCounters &= "," & dtCounterCargaDesasociadas2.Rows(i)(1)
                    End If
                Next

                '--estado transferencia Carga  =1
                For x As Integer = 0 To dtCounterCargaDesasociadas2.Rows.Count - 1
                    obj.ActualizarEstadoCarga(LblCodLiquidacion.Text, CboFechaLiquidacion.Value.Date, dtCounterCargaDesasociadas2.Rows(x)("idusuario_personal"))
                Next

            End If

            '********************
            Dim dtlistadoUsuario As DataTable = obj.ListadoUsuario(CboFechaLiquidacion.Value.Date, LblCodLiquidacion.Text, dtoUSUARIOS.m_iIdAgencia)
            With DgvListado
                .DataSource = dtlistadoUsuario
            End With
            BtnTransferencia.Enabled = False
            LstPasajes2.Enabled = False
            LstCarga2.Enabled = False
            '********************

            MessageBox.Show("Se completo la Transferencia", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '--------
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



#Region "PREVISTA FICHA(SELECCION)"

    Private Sub BtnPrvPasajes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrvPasajes.Click
        Try
            If DgvListado.Rows.Count <= 0 Then
                Return
            End If

            Me.Cursor = Cursors.AppStarting
            Dim row As Integer = DgvListado.SelectedRows.Item(0).Index
            Dim iIDliquidacion As Integer = Convert.ToInt32(DgvListado.Rows(row).Cells("IDOficinaLiquidacion").Value)
            Dim iDocumento As Integer = 1
            If DgvListado.Rows(row).Cells("Tipo").Value = "Psjes" Then
                Me.DetallePasajes()
            Else
                Me.DetalleCarga(iDocumento, iIDliquidacion)
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'VISUALIZA LOS GASTOS X COUNTER
    Private Sub DgvListado_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DgvListado.DoubleClick
        Try
            If DgvListado.Rows.Count <= 0 Then
                Return
            End If

            Me.Cursor = Cursors.AppStarting
            Dim obj As New dtoCierreOficina

            ' If Not bAperturado Then
            LblFecha.Text = CboFechaLiquidacion.Text
            ' End If

            Dim row As Integer = DgvListado.SelectedRows.Item(0).Index 'IDLiquiTurno
            Dim dtgastos As DataTable = obj.Gastos(DgvListado.Rows(row).Cells("IDOficinaLiquidacion").Value, LblFecha.Text, DgvListado.Rows(row).Cells("id_usuario_personal").Value, DgvListado.Rows(row).Cells("IDLiquiTurno").Value)

            If dtgastos.Rows.Count <= 0 Then
                MessageBox.Show("No tiene Gastos ingresados", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Me.FormatoDgvGastosXCounter()
                With DgvGastosXCounter
                    .DataSource = dtgastos
                End With

                If Not bAperturado Then
                    Me.TabLiquidacion.Controls.Add(TabGastos)
                    Me.TabLiquidacion.SelectTab(3)
                Else
                    Me.TabLiquidacion.Controls.Add(TabGastos)
                    Me.TabLiquidacion.SelectTab(4)
                End If

                LblNombre.Text = DgvListado.Rows(row).Cells("nombre").Value
                LblMontoGasto.Text = dtgastos.Compute("sum(MONTO)", "")
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'DETALLE X COUNTER PASAJES
    Sub DetallePasajes()
        If DgvListado.Rows.Count > 0 Then
            Dim objCierre As New dtoCierreOficina
            Dim row As Integer = DgvListado.SelectedRows.Item(0).Index
            'If Not bAperturado Then
            LblFecha.Text = CboFechaLiquidacion.Value.Date
            'End If

            Dim dtDetalle As DataSet = objCierre.Detalle(LblFecha.Text, LblFecha.Text, DgvListado.Rows(row).Cells("id_usuario_personal").Value, DgvListado.Rows(row).Cells("IDOficinaLiquidacion").Value, dtoUSUARIOS.m_iIdAgencia)

            Dim flag As Boolean = False
            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim objImprimir As New ImprimirTexto()
            Dim sImpresora As String = ""
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0
            '

            Dim obj As New Imprimir
            Dim dt As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 37)

            If dt.Rows.Count = 0 Then
                flag = False
            Else
                If IsDBNull(dt.Rows(0).Item("impresora")) Then
                    flag = False
                Else
                    sImpresora = dt.Rows(0).Item("impresora")
                    iTamaño = dt.Rows(0).Item("tamano")
                    iSuperior = dt.Rows(0).Item("superior")
                    Iizquierda = dt.Rows(0).Item("izquierda")
                    flag = True
                End If
            End If

            obj = New Imprimir
            obj.Inicializar()
            obj.Superior = iSuperior
            obj.Izquierda = Iizquierda
            obj.Impresora = sImpresora


            Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
            Dim iLong As Integer = IIf(iTamaño = 0, 71, iTamaño)

            y = iLong * pagina + 4
            y += 1
            i += 1

            Dim irow As Integer = dgvListaCaja.SelectedRows.Item(0).Index
            obj.EscribirLinea(y - 4, 35, "LIQUIDACION DIARIA DE VENTAS POR TURNO  " & dtoUSUARIOS.m_iNombreAgencia)
            obj.EscribirLinea(y - 3, 9, "FECHA LIQUID : " & dgvListaCaja.Rows(irow).Cells("Fecha_Apertura").Value)
            obj.EscribirLinea(y - 1, 9, "REPRESENTANTES DE VENTAS")
            obj.EscribirLinea(y - 1, 45, DgvListado.Rows(row).Cells("nombre").Value)

            obj.EscribirLinea(y, 9, "ESPECIES VALORADAS UTILIZADAS")
            obj.EscribirLinea(y, 45, "Serie") ': obj.EscribirLinea(y + 1, 30, dtDetalle.Tables(5).Rows(0).Item("Serie"))
            obj.EscribirLinea(y, 60, "Del") ': obj.EscribirLinea(y + 1, 45, dtDetalle.Tables(5).Rows(0).Item("Del"))
            obj.EscribirLinea(y, 75, "Al") ': obj.EscribirLinea(y + 1, 60, dtDetalle.Tables(5).Rows(0).Item("Al"))
            obj.EscribirLinea(y, 90, "Cant") ' : obj.EscribirLinea(y + 1, 75, dtDetalle.Tables(5).Rows(0).Item("cant"))
            obj.EscribirLinea(y, 100, "Corte") ' : obj.EscribirLinea(y + 1, 85, "0")


            Dim Conta As Integer = 1
            For x As Integer = 0 To dtDetalle.Tables(5).Rows.Count - 1
                'If dtDetalle.Tables(5).Rows(x).Item("Serie") <> 200 Then -->Comentado 23/01/2014
                If dtDetalle.Tables(5).Rows(x).Item("idProcesos") <> 66 Then '-->para diferencia los tipos de comprobante boletos con recivos d ecaja 23/01/2014 - jabanto
                    obj.EscribirLinea(y + Conta, 9, "Boleto de Viaje")
                    obj.EscribirLinea(y + Conta, 45, dtDetalle.Tables(5).Rows(x).Item("Serie"))
                    obj.EscribirLinea(y + Conta, 60, dtDetalle.Tables(5).Rows(x).Item("Del"))
                    obj.EscribirLinea(y + Conta, 75, dtDetalle.Tables(5).Rows(x).Item("Al"))
                    obj.EscribirLinea(y + Conta, 90, dtDetalle.Tables(5).Rows(x).Item("cant"))
                    obj.EscribirLinea(y + Conta, 100, "0")
                Else
                    obj.EscribirLinea(y + Conta, 9, "Recibos de Caja")
                    obj.EscribirLinea(y + Conta, 45, dtDetalle.Tables(5).Rows(x).Item("Serie"))
                    obj.EscribirLinea(y + Conta, 60, dtDetalle.Tables(5).Rows(x).Item("Del"))
                    obj.EscribirLinea(y + Conta, 75, dtDetalle.Tables(5).Rows(x).Item("Al"))
                    obj.EscribirLinea(y + Conta, 90, dtDetalle.Tables(5).Rows(x).Item("cant"))
                    obj.EscribirLinea(y + Conta, 100, "0")
                End If
                Conta += 1
            Next

            '----------------------------------------------------------------------------------
            Dim s As Integer = 4
            Dim iLinea As Integer = 0
            'Dim totalFacturaCarga As Double, totalBoletaCarga As Double, totalPCECarga As Double
            'Dim totalFacturaPsje As Double, totalBoletaPsje As Double, totalPCEPsje As Double

            Dim iTotalEfectivo As Double = IIf(IsDBNull(DgvListado.Rows(row).Cells("efectivo_ingresado").Value), 0, DgvListado.Rows(row).Cells("efectivo_ingresado").Value)

            iLinea = Len("0.00")
            obj.EscribirLinea(y + s + 1, 9, "Reg Tip.Cambio (US$ a S/.)") : obj.EscribirLinea(y + s + 1, 62 - iLinea, "0.00")
            iLinea = Len("0.00")
            obj.EscribirLinea(y + s + 2, 9, "Registro Efectivo Dolares") : obj.EscribirLinea(y + s + 2, 62 - iLinea, "0.00")

            iLinea = Len(IIf(iTotalEfectivo = 0, "0.00", FormatNumber(Format(iTotalEfectivo, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 3, 9, "Registro Efectivo Soles") : obj.EscribirLinea(y + s + 3, 62 - iLinea, IIf(iTotalEfectivo = 0, "0.00", FormatNumber(Format(iTotalEfectivo, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 4, 9, "--------------------------") : obj.EscribirLinea(y + s + 4, 51, "-----------")
            obj.EscribirLinea(y + s + 5, 9, "T.Efectivo (Soles y Dolares)")

            obj.EscribirLinea(y + s + 5, 62 - iLinea, IIf(iTotalEfectivo = 0, "0.00", FormatNumber(Format(iTotalEfectivo, "###,###,###.00"), 2)))


            '**********
            Dim MASTER_CARD As Double = IIf(IsDBNull(dtDetalle.Tables(0).Rows(0).Item("MASTER_CARD")), 0, dtDetalle.Tables(0).Rows(0).Item("MASTER_CARD"))
            Dim VISA As Double = IIf(IsDBNull(dtDetalle.Tables(0).Rows(0).Item("VISA")), 0, dtDetalle.Tables(0).Rows(0).Item("VISA"))
            Dim POOL_MONTO_MASTER_CARD As Double = IIf(IsDBNull(dtDetalle.Tables(11).Rows(0).Item("poolMonMastercard")), 0, dtDetalle.Tables(11).Rows(0).Item("poolMonMastercard"))
            'Dim POOL_MONO_VISA As Double = IIf(IsDBNull(dtDetalle.Tables(11).Rows(0).Item("poolMonVisa")), 0, dtDetalle.Tables(11).Rows(0).Item("poolMonVisa"))
            Dim PAGO_EFETIVO As Double = IIf(IsDBNull(dtDetalle.Tables(0).Rows(0).Item("PAGO_EFECTIVO")), 0, dtDetalle.Tables(0).Rows(0).Item("PAGO_EFECTIVO"))
            Dim NC As Double = IIf(IsDBNull(dtDetalle.Tables(0).Rows(0).Item("NC")), 0, dtDetalle.Tables(0).Rows(0).Item("NC"))

            Dim cantidadPagoEfectivo As Integer = 0
            'Dim montoPagoefectivo As Double = 0.0

            iLinea = Len(IIf(MASTER_CARD = 0, "0.00", FormatNumber(Format(MASTER_CARD + POOL_MONTO_MASTER_CARD, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 8, 9, "Monto Tarjeta Master Card") : obj.EscribirLinea(y + s + 8, 62 - iLinea, IIf(MASTER_CARD = 0, "0.00", FormatNumber(Format(MASTER_CARD + POOL_MONTO_MASTER_CARD, "###,###,###.00"), 2)))
            iLinea = Len(IIf(VISA = 0, "0.00", FormatNumber(Format(VISA, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 9, 9, "Monto Tarjeta Visa") : obj.EscribirLinea(y + s + 9, 62 - iLinea, IIf(VISA = 0, "0.00", FormatNumber(Format(VISA, "###,###,###.00"), 2)))

            '-->End begin - jabanto 14/06/2019
            iLinea = Len(Trim(cantidadPagoEfectivo))
            iLinea = Len(IIf(VISA = 0, "0.00", FormatNumber(Format(PAGO_EFETIVO, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 10, 9, "Monto PagoEfectivo") : obj.EscribirLinea(y + s + 10, 62 - iLinea, IIf(PAGO_EFETIVO = 0, "0.00", FormatNumber(Format(PAGO_EFETIVO, "###,###,###.00"), 2)))

            '----
            'iLinea = Len(IIf(POOL_MONTO_MASTER_CARD = 0, "0.00", FormatNumber(Format(POOL_MONTO_MASTER_CARD, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 10, 9, "Venta Pool - Master Card") : obj.EscribirLinea(y + s + 10, 62 - iLinea, IIf(POOL_MONTO_MASTER_CARD = 0, "0.00", FormatNumber(Format(POOL_MONTO_MASTER_CARD, "###,###,###.00"), 2)))
            'iLinea = Len(IIf(POOL_MONO_VISA = 0, "0.00", FormatNumber(Format(POOL_MONO_VISA, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 11, 9, "Venta Pool - Visa") : obj.EscribirLinea(y + s + 11, 62 - iLinea, IIf(POOL_MONO_VISA = 0, "0.00", FormatNumber(Format(POOL_MONO_VISA, "###,###,###.00"), 2)))
            '----

            'POOL_MONTO_MASTER_CARD = 0
            'POOL_MONO_VISA = 0

            obj.EscribirLinea(y + s + 11, 9, "----------------------") : obj.EscribirLinea(y + s + 11, 51, "-----------")
            obj.EscribirLinea(y + s + 12, 9, "Mont. Cobrado T.(VOUCHER)")
            Dim iTotalTarjeta As Double = MASTER_CARD + VISA + PAGO_EFETIVO + POOL_MONTO_MASTER_CARD
            iLinea = Len(IIf(iTotalTarjeta = 0, "0.00", FormatNumber(Format(iTotalTarjeta, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 12, 62 - iLinea, IIf(iTotalTarjeta = 0, "0.00", FormatNumber(Format(iTotalTarjeta, "###,###,###.00"), 2)))

            '**********
            Dim CantVentaContado As Integer = IIf(IsDBNull(dtDetalle.Tables(1).Rows(0).Item("Cant")), 0, dtDetalle.Tables(1).Rows(0).Item("Cant"))
            Dim CantCortesia As Integer = IIf(IsDBNull(dtDetalle.Tables(2).Rows(0).Item("Cant")), 0, dtDetalle.Tables(2).Rows(0).Item("Cant"))
            Dim CantPrepagados As Integer = IIf(IsDBNull(dtDetalle.Tables(3).Rows(0).Item("Cant")), 0, dtDetalle.Tables(3).Rows(0).Item("Cant"))
            Dim CantCreditos As Integer = IIf(IsDBNull(dtDetalle.Tables(4).Rows(0).Item("Cant")), 0, dtDetalle.Tables(4).Rows(0).Item("Cant"))
            Dim MontoVentaContado As Double = IIf(IsDBNull(dtDetalle.Tables(1).Rows(0).Item("MontoVentaContado")), 0, dtDetalle.Tables(1).Rows(0).Item("MontoVentaContado"))
            Dim MontoCortesia As Double = IIf(IsDBNull(dtDetalle.Tables(2).Rows(0).Item("MontoCortesia")), 0, dtDetalle.Tables(2).Rows(0).Item("MontoCortesia"))
            Dim monto_Prepagados As Double = IIf(IsDBNull(dtDetalle.Tables(3).Rows(0).Item("monto_Prepagados")), 0, dtDetalle.Tables(3).Rows(0).Item("monto_Prepagados"))
            Dim monto_Creditos As Double = IIf(IsDBNull(dtDetalle.Tables(4).Rows(0).Item("monto_Creditos")), 0, dtDetalle.Tables(4).Rows(0).Item("monto_Creditos"))

            '-->Venta de seguros
            Dim dtVentaSeguros As DataTable = dtDetalle.Tables(11)
            Dim cantVentaSeguroPaxFree As Integer = IIf(IsDBNull(dtVentaSeguros.Rows(0).Item("cantidadPaxFre")), 0, dtVentaSeguros.Rows(0).Item("cantidadPaxFre"))
            Dim cantVentaSeguroPaxNromal As Integer = IIf(IsDBNull(dtVentaSeguros.Rows(0).Item("cantidadPaxNormal")), 0, dtVentaSeguros.Rows(0).Item("cantidadPaxNormal"))
            Dim montoVentaSeguroPaxFree As Double = IIf(IsDBNull(dtVentaSeguros.Rows(0).Item("totalPaxFre")), 0, dtVentaSeguros.Rows(0).Item("totalPaxFre"))
            Dim montoVentaSeguroPaxNormal As Double = IIf(IsDBNull(dtVentaSeguros.Rows(0).Item("totalPaxNormal")), 0, dtVentaSeguros.Rows(0).Item("totalPaxNormal"))
            'Dim totalVentaSeguros As Double = montoVentaSeguroPaxFree + montoVentaSeguroPaxNormal
            'Dim cantTotalVentaSeguro As Integer = cantVentaSeguroPaxFree + cantVentaSeguroPaxNromal

            obj.EscribirLinea(y + s + 15, 9, "DETALLE DE LIQUIDACION")
            obj.EscribirLinea(y + s + 16, 9, "Tipo") : obj.EscribirLinea(y + s + 16, 54, "Cantidad") : obj.EscribirLinea(y + s + 16, 75, "Monto")
            iLinea = Len(Trim(CantVentaContado))
            obj.EscribirLinea(y + s + 17, 9, "Venta al Contado") : obj.EscribirLinea(y + s + 17, 62 - iLinea, CantVentaContado)
            iLinea = Len(IIf(MontoVentaContado = 0, "0.00", FormatNumber(Format(MontoVentaContado, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 17, 80 - iLinea, IIf(MontoVentaContado = 0, "0.00", FormatNumber(Format(MontoVentaContado, "###,###,###.00"), 2)))

            iLinea = Len(Trim(CantCortesia))
            obj.EscribirLinea(y + s + 18, 9, "Cortesia") : obj.EscribirLinea(y + s + 18, 62 - iLinea, CantCortesia)
            iLinea = Len(IIf(MontoCortesia = 0, "0.00", FormatNumber(Format(MontoCortesia, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 18, 80 - iLinea, IIf(MontoCortesia = 0, "0.00", FormatNumber(Format(MontoCortesia, "###,###,###.00"), 2)))

            iLinea = Len(Trim(CantPrepagados))
            obj.EscribirLinea(y + s + 19, 9, "Prepagados") : obj.EscribirLinea(y + s + 19, 62 - iLinea, CantPrepagados)
            iLinea = Len(IIf(monto_Prepagados = 0, "0.00", FormatNumber(Format(monto_Prepagados, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 19, 80 - iLinea, IIf(monto_Prepagados = 0, "0.00", FormatNumber(Format(monto_Prepagados, "###,###,###.00"), 2)))

            iLinea = Len(Trim(CantCreditos))
            obj.EscribirLinea(y + s + 20, 9, "Creditos") : obj.EscribirLinea(y + s + 20, 62 - iLinea, CantCreditos)
            iLinea = Len(IIf(monto_Creditos = 0, "0.00", FormatNumber(Format(monto_Creditos, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 20, 80 - iLinea, IIf(monto_Creditos = 0, "0.00", FormatNumber(Format(monto_Creditos, "###,###,###.00"), 2)))

            '-->End Begin - jabanto 19/10/2016
            'iLinea = Len(Trim(cantTotalVentaSeguro))
            'obj.EscribirLinea(y + s + 19, 9, "Venta de Seguros") : obj.EscribirLinea(y + s + 19, 62 - iLinea, cantTotalVentaSeguro)
            'iLinea = Len(IIf(totalVentaSeguros = 0, "0.00", FormatNumber(Format(totalVentaSeguros, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 19, 80 - iLinea, IIf(totalVentaSeguros = 0, "0.00", FormatNumber(Format(totalVentaSeguros, "###,###,###.00"), 2)))

            '--> Bergin - jabanto 19/10/2016
            Dim pool_cantidad_efectivo As Integer = IIf(IsDBNull(dtDetalle.Tables(11).Rows(0).Item("poolCanEfectivo")), 0, dtDetalle.Tables(11).Rows(0).Item("poolCanEfectivo"))
            Dim pool_monto_efectivo As Double = IIf(IsDBNull(dtDetalle.Tables(11).Rows(0).Item("poolMonEfectivo")), 0, dtDetalle.Tables(11).Rows(0).Item("poolMonEfectivo"))
            'iLinea = Len(Trim(pool_cantidad_efectivo))
            'obj.EscribirLinea(y + s + 21, 9, "Venta Pool - Efectivo") : obj.EscribirLinea(y + s + 21, 62 - iLinea, pool_cantidad_efectivo)
            'iLinea = Len(IIf(pool_monto_efectivo = 0, "0.00", FormatNumber(Format(pool_monto_efectivo, "###,###,###.00"), 2)))
            'obj.EscribirLinea(y + s + 21, 80 - iLinea, IIf(pool_monto_efectivo = 0, "0.00", FormatNumber(Format(pool_monto_efectivo, "###,###,###.00"), 2)))

            pool_monto_efectivo = 0
            pool_cantidad_efectivo = 0

            obj.EscribirLinea(y + s + 21, 9, "----------------------") : obj.EscribirLinea(y + s + 22, 51, "-----------") : obj.EscribirLinea(y + s + 22, 70, "-----------")
            obj.EscribirLinea(y + s + 22, 9, "Total")

            iLinea = Len(Trim(CantVentaContado + CantCortesia + CantPrepagados + CantCreditos + pool_cantidad_efectivo))
            obj.EscribirLinea(y + s + 23, 62 - iLinea, CantVentaContado + CantCortesia + CantPrepagados + CantCreditos + pool_cantidad_efectivo)

            Dim iTotalDetalle As Double = (MontoVentaContado + MontoCortesia + monto_Prepagados + monto_Creditos + pool_monto_efectivo)
            iLinea = Len(IIf(iTotalDetalle = 0, "0.00", FormatNumber(Format(iTotalDetalle, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 23, 80 - iLinea, IIf(iTotalDetalle = 0, "0.00", FormatNumber(Format(iTotalDetalle, "###,###,###.00"), 2)))



            '***********
            Dim cantCajaPrepagado As Integer = IIf(IsDBNull(dtDetalle.Tables(6).Rows(0).Item("Cant")), 0, dtDetalle.Tables(6).Rows(0).Item("Cant"))
            Dim cantDelivery As Integer = IIf(IsDBNull(dtDetalle.Tables(6).Rows(1).Item("Cant")), 0, dtDetalle.Tables(6).Rows(1).Item("Cant"))
            Dim MontoCajaPrepagados As Double = IIf(IsDBNull(dtDetalle.Tables(6).Rows(0).Item("MontoCajaPrepagados")), 0, dtDetalle.Tables(6).Rows(0).Item("MontoCajaPrepagados"))
            Dim iDelivery As Double = IIf(IsDBNull(dtDetalle.Tables(6).Rows(1).Item("MontoCajaPrepagados")), 0, dtDetalle.Tables(6).Rows(1).Item("MontoCajaPrepagados"))

            obj.EscribirLinea(y + s + 26, 9, "OTROS INGRESOS")
            obj.EscribirLinea(y + s + 27, 9, "Concepto") : obj.EscribirLinea(y + s + 27, 54, "Cantidad") : obj.EscribirLinea(y + s + 27, 75, "Monto")

            iLinea = Len(Trim(cantDelivery))
            obj.EscribirLinea(y + s + 28, 9, "Delivery") : obj.EscribirLinea(y + s + 28, 62 - iLinea, cantDelivery)
            iLinea = Len(IIf(iDelivery = 0, "0.00", FormatNumber(Format(iDelivery, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 28, 80 - iLinea, IIf(iDelivery = 0, "0.00", FormatNumber(Format(iDelivery, "###,###,###.00"), 2))) '

            iLinea = Len(Trim(cantCajaPrepagado))
            obj.EscribirLinea(y + s + 29, 9, "Recibos de Caja Prepagados") : obj.EscribirLinea(y + s + 29, 62 - iLinea, cantCajaPrepagado)
            iLinea = Len(IIf(MontoCajaPrepagados = 0, "0.00", FormatNumber(Format(MontoCajaPrepagados, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 29, 80 - iLinea, IIf(MontoCajaPrepagados = 0, "0.00", FormatNumber(Format(MontoCajaPrepagados, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 30, 9, "----------------------") : obj.EscribirLinea(y + s + 30, 51, "-----------") : obj.EscribirLinea(y + s + 30, 70, "-----------")

            iLinea = Len(Trim(cantCajaPrepagado))
            obj.EscribirLinea(y + s + 31, 9, "Total") : obj.EscribirLinea(y + s + 31, 62 - iLinea, cantCajaPrepagado + cantDelivery)
            iLinea = Len(IIf(MontoCajaPrepagados + iDelivery = 0, "0.00", FormatNumber(Format(MontoCajaPrepagados + iDelivery, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 31, 80 - iLinea, IIf(MontoCajaPrepagados + iDelivery = 0, "0.00", FormatNumber(Format(MontoCajaPrepagados + iDelivery, "###,###,###.00"), 2)))


            Dim CANTGASTOS_VARIOS As Integer = 0
            Dim CANTPEAJE As Integer = 0
            Dim CANTPAGOS_GIROS As Integer = 0
            Dim GASTOS_VARIOS As Double = 0
            Dim PEAJES As Double = 0
            Dim PAGO_GIROS As Double = 0
            '*********
            If dtDetalle.Tables(9).Rows.Count > 0 Then
                CANTGASTOS_VARIOS = IIf(IsDBNull(dtDetalle.Tables(9).Rows(0).Item("CANTGASTOS_VARIOS")), 0, dtDetalle.Tables(9).Rows(0).Item("CANTGASTOS_VARIOS"))
                CANTPEAJE = IIf(IsDBNull(dtDetalle.Tables(9).Rows(0).Item("CANTPEAJE")), 0, dtDetalle.Tables(9).Rows(0).Item("CANTPEAJE"))
                CANTPAGOS_GIROS = IIf(IsDBNull(dtDetalle.Tables(9).Rows(0).Item("CANTPAGOS_GIROS")), 0, dtDetalle.Tables(9).Rows(0).Item("CANTPAGOS_GIROS"))
                GASTOS_VARIOS = IIf(IsDBNull(dtDetalle.Tables(9).Rows(0).Item("GASTOS_VARIOS")), 0, dtDetalle.Tables(9).Rows(0).Item("GASTOS_VARIOS"))
                PEAJES = IIf(IsDBNull(dtDetalle.Tables(9).Rows(0).Item("PEAJES")), 0, dtDetalle.Tables(9).Rows(0).Item("PEAJES"))
                PAGO_GIROS = IIf(IsDBNull(dtDetalle.Tables(9).Rows(0).Item("PAGO_GIROS")), 0, dtDetalle.Tables(9).Rows(0).Item("PAGO_GIROS"))
            End If


            obj.EscribirLinea(y + s + 33, 9, "EGRESOS")
            obj.EscribirLinea(y + s + 34, 9, "Concepto") : obj.EscribirLinea(y + s + 34, 54, "Cantidad") : obj.EscribirLinea(y + s + 34, 75, "Monto")

            iLinea = Len(Trim(CANTGASTOS_VARIOS))
            obj.EscribirLinea(y + s + 35, 9, "Gastos Varios") : obj.EscribirLinea(y + s + 35, 62 - iLinea, CANTGASTOS_VARIOS)
            iLinea = Len(IIf(GASTOS_VARIOS = 0, "0.00", FormatNumber(Format(GASTOS_VARIOS, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 35, 80 - iLinea, IIf(GASTOS_VARIOS = 0, "0.00", FormatNumber(Format(GASTOS_VARIOS, "###,###,###.00"), 2)))

            iLinea = Len(Trim(CANTPEAJE))
            obj.EscribirLinea(y + s + 36, 9, "Peajes") : obj.EscribirLinea(y + s + 36, 62 - iLinea, CANTPEAJE)
            iLinea = Len(IIf(PEAJES = 0, "0.00", FormatNumber(Format(PEAJES, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 36, 80 - iLinea, IIf(PEAJES = 0, "0.00", FormatNumber(Format(PEAJES, "###,###,###.00"), 2)))

            iLinea = Len(Trim(CANTPAGOS_GIROS))
            obj.EscribirLinea(y + s + 37, 9, "Pago de Giros") : obj.EscribirLinea(y + s + 37, 62 - iLinea, CANTPAGOS_GIROS)
            iLinea = Len(IIf(PAGO_GIROS = 0, "0.00", FormatNumber(Format(PAGO_GIROS, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 37, 80 - iLinea, IIf(PAGO_GIROS = 0, "0.00", FormatNumber(Format(PAGO_GIROS, "###,###,###.00"), 2)))

            iLinea = Len(Trim(cantVentaSeguroPaxFree))
            obj.EscribirLinea(y + s + 38, 9, "Venta de Seguros Pasajero Frecuente") : obj.EscribirLinea(y + s + 38, 62 - iLinea, cantVentaSeguroPaxFree)
            iLinea = Len(IIf(montoVentaSeguroPaxFree = 0, "0.00", FormatNumber(Format(montoVentaSeguroPaxFree, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 38, 80 - iLinea, IIf(montoVentaSeguroPaxFree = 0, "0.00", FormatNumber(Format(montoVentaSeguroPaxFree, "###,###,###.00"), 2)))


            obj.EscribirLinea(y + s + 39, 9, "----------------------") : obj.EscribirLinea(y + s + 39, 51, "-----------") : obj.EscribirLinea(y + s + 39, 70, "-----------")
            obj.EscribirLinea(y + s + 40, 9, "Total")

            iLinea = Len(Trim(CANTGASTOS_VARIOS + CANTPEAJE + CANTPAGOS_GIROS + cantVentaSeguroPaxFree))
            obj.EscribirLinea(y + s + 40, 62 - iLinea, CANTGASTOS_VARIOS + CANTPEAJE + CANTPAGOS_GIROS + cantVentaSeguroPaxFree)

            Dim iTotalGastos As Double = GASTOS_VARIOS + PEAJES + PAGO_GIROS + montoVentaSeguroPaxFree
            iLinea = Len(IIf(iTotalGastos = 0, "0.00", FormatNumber(Format(iTotalGastos, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 40, 80 - iLinea, IIf(iTotalGastos = 0, "0.00", FormatNumber(Format(iTotalGastos, "###,###,###.00"), 2)))

            '**************
            Dim Porc100 As Double = IIf(IsDBNull(dtDetalle.Tables(7).Rows(0).Item("Total_Porc100")), 0, dtDetalle.Tables(7).Rows(0).Item("Total_Porc100"))
            Dim Porc80 As Double = IIf(IsDBNull(dtDetalle.Tables(7).Rows(0).Item("Total_Porc80")), 0, dtDetalle.Tables(7).Rows(0).Item("Total_Porc80"))
            Dim cant_Porc80 As Integer = IIf(IsDBNull(dtDetalle.Tables(7).Rows(0).Item("cant_Porc80")), 0, dtDetalle.Tables(7).Rows(0).Item("cant_Porc80"))
            Dim cant_Porc100 As Integer = IIf(IsDBNull(dtDetalle.Tables(7).Rows(0).Item("cant_Porc100")), 0, dtDetalle.Tables(7).Rows(0).Item("cant_Porc100"))

            obj.EscribirLinea(y + s + 42, 9, "DEVOLUCIONES")
            obj.EscribirLinea(y + s + 43, 9, "Nro Documento") : obj.EscribirLinea(y + s + 43, 54, "Cantidad") : obj.EscribirLinea(y + s + 43, 75, "Monto")

            iLinea = Len(Trim(cant_Porc80))
            obj.EscribirLinea(y + s + 44, 9, "Dev.Pasajes 80") : obj.EscribirLinea(y + s + 44, 62 - iLinea, cant_Porc80)
            iLinea = Len(IIf(Porc80 = 0, "0.00", FormatNumber(Format(Porc80, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 44, 80 - iLinea, IIf(Porc80 = 0, "0.00", FormatNumber(Format(Porc80, "###,###,###.00"), 2)))

            iLinea = Len(Trim(cant_Porc100))
            obj.EscribirLinea(y + s + 45, 9, "Dev.Pasajes 100") : obj.EscribirLinea(y + s + 45, 62 - iLinea, cant_Porc100)
            iLinea = Len(IIf(Porc100 = 0, "0.00", FormatNumber(Format(Porc100, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 45, 80 - iLinea, IIf(Porc100 = 0, "0.00", FormatNumber(Format(Porc100, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 46, 9, "----------------------") : obj.EscribirLinea(y + s + 46, 51, "-----------") : obj.EscribirLinea(y + s + 46, 70, "-----------")
            obj.EscribirLinea(y + s + 47, 9, "Total")

            iLinea = Len(Trim(cant_Porc80 + cant_Porc100))
            obj.EscribirLinea(y + s + 47, 62 - iLinea, cant_Porc80 + cant_Porc100)

            Dim iTotalDevoluciones As Double = Porc100 + Porc80
            iLinea = Len(FormatNumber(Format(iTotalDevoluciones, "###,###,###.00"), 2))
            obj.EscribirLinea(y + s + 47, 80 - iLinea, IIf(iTotalDevoluciones = 0, "0.00", FormatNumber(Format(iTotalDevoluciones, "###,###,###.00"), 2)))

            'Dim SaldoEntregar As Double = (MontoVentaContado + MontoCajaPrepagados + iDelivery + totalVentaSeguros) - (iTotalGastos + iTotalDevoluciones + iTotalTarjeta)
            Dim SaldoEntregar As Double = (MontoVentaContado + MontoCajaPrepagados + iDelivery + (pool_monto_efectivo + 0 + 0)) - (iTotalGastos + iTotalDevoluciones + iTotalTarjeta + NC)
            iLinea = Len(IIf(SaldoEntregar = 0, "0.00", FormatNumber(Format(SaldoEntregar, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 49, 9, "SALDO A ENTREGAR") : obj.EscribirLinea(y + s + 49, 62 - iLinea, IIf(SaldoEntregar = 0, "0.00", FormatNumber(Format(SaldoEntregar, "###,###,###.00"), 2)))

            Dim Diferencia As Double = SaldoEntregar - iTotalEfectivo
            iLinea = Len(IIf(Diferencia = 0, "0.00", FormatNumber(Format(Diferencia, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 50, 9, "DIFERENCIA") : obj.EscribirLinea(y + s + 50, 62 - iLinea, IIf(Diferencia = 0, "0.00", FormatNumber(Format(Diferencia, "###,###,###.00"), 2)))



            obj.Comprimido = True
            obj.Preliminar = True
            obj.Tamaño = iLong
            obj.ReglaVertical = False
            obj.Imprimir()
            obj.Finalizar()

            Dim frm As New FrmPreview
            frm.WindowState = FormWindowState.Normal
            frm.Tamaño = iLong
            frm.Documento = 1
            frm.Text = "Factura"
            frm.ShowDialog()
            'Else
            '    MessageBox.Show("El Documento no tiene asociado una impresora.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
            objImprimir = Nothing
            objImpresora = Nothing
        End If
    End Sub

    'DETALLE X COUNTER CARGA
    Sub DetalleCarga(ByVal documento As Integer, ByVal IDLiquidacion As Integer)
        Dim obj As New Imprimir
        Try
            Dim ldt_cur_datos_venta As New DataTable
            Dim dtGastosLiquidacion As New DataTable
            Dim lds_tmp As New DataSet
            Dim row As Integer = DgvListado.SelectedRows.Item(0).Index
            '
            Dim flag As Boolean = False
            Dim iSubTotal As Double = 0, iImpuesto As Double = 0, iTotal As Double = 0


            Dim objImpresora As New dtoCONFIGURACION_DOCUMENTARIA
            Dim objImprimir As New ImprimirTexto()
            Dim sImpresora As String = ""
            Dim iTamaño As Integer = 0, iSuperior As Integer = 0, Iizquierda As Integer = 0
            '


            Dim dt As DataTable = objImpresora.ObtieneConfiguracion(dtoUSUARIOS.IP, dtoUSUARIOS.m_iIdAgencia, 37)

            If dt.Rows.Count = 0 Then
                flag = False
            Else
                If IsDBNull(dt.Rows(0).Item("impresora")) Then
                    flag = False
                Else
                    sImpresora = dt.Rows(0).Item("impresora")
                    iTamaño = dt.Rows(0).Item("tamano")
                    iSuperior = dt.Rows(0).Item("superior")
                    Iizquierda = dt.Rows(0).Item("izquierda")
                    flag = True
                End If
            End If

            obj = New Imprimir
            obj.Inicializar()
            obj.Superior = iSuperior
            obj.Izquierda = Iizquierda
            obj.Impresora = sImpresora

            Dim y As Integer = 0, i As Integer = 0, pagina As Integer = 0
            Dim iLong As Integer = IIf(iTamaño = 0, 75, iTamaño)

            y = iLong * pagina + 4
            y += 1
            i += 1

            'If Not bAperturado Then
            LblFecha.Text = CboFechaLiquidacion.Value.Date
            'End If
            lds_tmp = ObjVentaCargaContado.ListaDatosAperturaCarga(DgvListado.Rows(row).Cells("id_usuario_personal").Value, dtoUSUARIOS.m_iIdAgencia, DgvListado.Rows(row).Cells("IDOficinaLiquidacion").Value, LblFecha.Text)
            ldt_cur_datos_venta = lds_tmp.Tables(0).Copy
            dtGastosLiquidacion = lds_tmp.Tables(1).Copy
            '----------------------------------------------------------------------------------
            Dim objCierreOficina As New dtoCierreOficina
            Dim s As Integer = 5
            Dim totalFacturaCarga As Double, totalBoletaCarga As Double, totalPCECarga As Double, TotalMontoTarjeVisa As Double, TotalMontoTarjeMaster As Double
            Dim totalFacturaPsje As Double, totalBoletaPsje As Double, totalPCEPsje As Double, TotalCredito As Double, totalDevolucionCarga As Double
            Dim totalEncomiendaCortesia As Double
            Dim nc As Double
            Dim NCBoleta As Double, NCFactura As Double

            Dim irow As Integer = dgvListaCaja.SelectedRows.Item(0).Index
            obj.EscribirLinea(y - 4, 35, "LIQUIDACION DIARIA DE VENTAS POR TURNO  " & dtoUSUARIOS.m_iNombreAgencia)
            obj.EscribirLinea(y - 3, 10, "FECHA : " & dgvListaCaja.Rows(irow).Cells("Fecha_Apertura").Value)
            obj.EscribirLinea(y - 1, 10, "REPRESENTANTES DE VENTAS")
            obj.EscribirLinea(y - 1, 45, DgvListado.Rows(row).Cells("nombre").Value)

            obj.EscribirLinea(y, 10, "ESPECIES VALORADAS UTILIZADAS")
            obj.EscribirLinea(y, 45, "Serie")
            obj.EscribirLinea(y, 60, "Del")
            obj.EscribirLinea(y, 75, "Al")
            obj.EscribirLinea(y, 90, "Cant")
            obj.EscribirLinea(y, 100, "Corte")


            Dim Conta As Integer = 1
            For x As Integer = 0 To lds_tmp.Tables(2).Rows.Count - 1
                If lds_tmp.Tables(2).Rows(x).Item("idtipo_comprobante") = 2 Then
                    obj.EscribirLinea(y + Conta, 10, "Boleta")
                    obj.EscribirLinea(y + Conta, 45, lds_tmp.Tables(2).Rows(x).Item("Serie"))
                    obj.EscribirLinea(y + Conta, 60, lds_tmp.Tables(2).Rows(x).Item("Del"))
                    obj.EscribirLinea(y + Conta, 75, lds_tmp.Tables(2).Rows(x).Item("Al"))
                    obj.EscribirLinea(y + Conta, 90, lds_tmp.Tables(2).Rows(x).Item("cant"))
                    obj.EscribirLinea(y + Conta, 100, "0")
                Else
                    obj.EscribirLinea(y + Conta, 10, "Factura")
                    obj.EscribirLinea(y + Conta, 45, lds_tmp.Tables(2).Rows(x).Item("Serie"))
                    obj.EscribirLinea(y + Conta, 60, lds_tmp.Tables(2).Rows(x).Item("Del"))
                    obj.EscribirLinea(y + Conta, 75, lds_tmp.Tables(2).Rows(x).Item("Al"))
                    obj.EscribirLinea(y + Conta, 90, lds_tmp.Tables(2).Rows(x).Item("cant"))
                    obj.EscribirLinea(y + Conta, 100, "0")
                End If
                Conta += 1
            Next

            obj.EscribirLinea(y + s + 1, 10, "VENTA CARGA")
            obj.EscribirLinea(y + s + 1, 60, "Factura")
            obj.EscribirLinea(y + s + 1, 75, "Boleta")
            obj.EscribirLinea(y + s + 1, 90, "PCE")
            obj.EscribirLinea(y + s + 1, 100, "Credito")
            obj.EscribirLinea(y + s + 2, 10, "------------")

            s += 3
            Dim iLinea As Integer = 0

            For Each fila As DataRow In ldt_cur_datos_venta.Rows
                obj.EscribirLinea(y + s, 10, fila.Item("NOMBRE")) 'cambio 

                If Trim(fila.Item("TOTAL_MONTO_FACTU").ToString) = "" Then
                    iLinea = Len(Trim("0.00"))
                    obj.EscribirLinea(y + s, 67 - iLinea, "0.00")
                Else
                    iLinea = Len(Trim(FormatNumber(Format(fila.Item("TOTAL_MONTO_FACTU"), "###,###,###.00"), 2)))
                    obj.EscribirLinea(y + s, 67 - iLinea, FormatNumber(Format(fila.Item("TOTAL_MONTO_FACTU"), "###,###,###.00"), 2))
                End If

                If Trim(fila.Item("TOTAL_MONTO_BOLE").ToString) = "" Then
                    iLinea = Len(Trim("0.00"))
                    obj.EscribirLinea(y + s, 81 - iLinea, "0.00")
                Else
                    iLinea = Len(Trim(FormatNumber(Format(fila.Item("TOTAL_MONTO_BOLE"), "###,###,###.00"), 2)))
                    obj.EscribirLinea(y + s, 81 - iLinea, FormatNumber(Format(fila.Item("TOTAL_MONTO_BOLE"), "###,###,###.00"), 2))
                End If

                If Trim(fila.Item("TOTAL_MONTO_PAGO_ENTRE").ToString) = "" Then
                    iLinea = Len(Trim("0.00"))
                    obj.EscribirLinea(y + s, 94 - iLinea, "0.00")
                Else
                    iLinea = Len(Trim(FormatNumber(Format(fila.Item("TOTAL_MONTO_PAGO_ENTRE"), "###,###,###.00"), 2)))
                    obj.EscribirLinea(y + s, 94 - iLinea, FormatNumber(Format(fila.Item("TOTAL_MONTO_PAGO_ENTRE"), "###,###,###.00"), 2))
                End If

                If Trim(fila.Item("total_Credito").ToString) = "" Then
                    iLinea = Len(Trim("0.00"))
                    obj.EscribirLinea(y + s, 108 - iLinea, "0.00")
                Else
                    iLinea = Len(Trim(FormatNumber(Format(fila.Item("total_Credito"), "###,###,###.00"), 2)))
                    obj.EscribirLinea(y + s, 108 - iLinea, FormatNumber(Format(fila.Item("total_Credito"), "###,###,###.00"), 2))
                End If

                totalFacturaCarga += IIf(IsDBNull(fila.Item("TOTAL_MONTO_FACTU")), 0, fila.Item("TOTAL_MONTO_FACTU"))
                totalBoletaCarga += IIf(IsDBNull(fila.Item("TOTAL_MONTO_BOLE")), 0, fila.Item("TOTAL_MONTO_BOLE"))
                totalPCECarga += IIf(IsDBNull(fila.Item("TOTAL_MONTO_PAGO_ENTRE")), 0, fila.Item("TOTAL_MONTO_PAGO_ENTRE"))
                TotalMontoTarjeVisa += IIf(IsDBNull(fila.Item("total_monto_tarje_Visa")), 0, fila.Item("total_monto_tarje_Visa"))
                TotalMontoTarjeMaster += IIf(IsDBNull(fila.Item("total_monto_tarje_Master")), 0, fila.Item("total_monto_tarje_Master"))
                TotalCredito += IIf(IsDBNull(fila.Item("total_Credito")), 0, fila.Item("total_Credito"))
                totalDevolucionCarga += IIf(IsDBNull(fila.Item("Total_DevolucionCarga")), 0, fila.Item("Total_DevolucionCarga"))
                totalEncomiendaCortesia += IIf(IsDBNull(fila.Item("Total_Encomiendas_Cortesia")), 0, fila.Item("Total_Encomiendas_Cortesia"))
                nc += IIf(IsDBNull(fila.Item("nc")), 0, fila.Item("nc"))
                NCBoleta += IIf(IsDBNull(fila.Item("pagonc_boleta")), 0, fila.Item("pagonc_boleta"))
                NCFactura += IIf(IsDBNull(fila.Item("pagonc_factura")), 0, fila.Item("pagonc_factura"))
                s += 1
            Next



            obj.EscribirLinea(y + s + 1, 10, "Total")
            obj.EscribirLinea(y + s, 10, "-----------------------------------")
            obj.EscribirLinea(y + s, 56, "-----------")
            obj.EscribirLinea(y + s, 70, "-----------")
            obj.EscribirLinea(y + s, 84, "----------")
            obj.EscribirLinea(y + s, 99, "----------")

            iLinea = Len(Trim(IIf(totalFacturaCarga = 0, "0.00", FormatNumber(Format(totalFacturaCarga, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 1, 67 - iLinea, IIf(totalFacturaCarga = 0, "0.00", FormatNumber(Format(totalFacturaCarga, "###,###,###.00"), 2)))

            iLinea = Len(Trim(IIf(totalBoletaCarga = 0, "0.00", FormatNumber(Format(totalBoletaCarga, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 1, 81 - iLinea, IIf(totalBoletaCarga = 0, "0.00", FormatNumber(Format(totalBoletaCarga, "###,###,###.00"), 2)))

            iLinea = Len(Trim(IIf(totalPCECarga = 0, "0.00", FormatNumber(Format(totalPCECarga, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 1, 94 - iLinea, IIf(totalPCECarga = 0, "0.00", FormatNumber(Format(totalPCECarga, "###,###,###.00"), 2)))

            iLinea = Len(Trim(IIf(TotalCredito = 0, "0.00", FormatNumber(Format(TotalCredito, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 1, 108 - iLinea, IIf(TotalCredito = 0, "0.00", FormatNumber(Format(TotalCredito, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 3, 10, "OTROS INGRESOS")
            obj.EscribirLinea(y + s + 4, 10, "---------------")
            'obj.EscribirLinea(y + s + 5, 10, "Recibo. Caja Prepagada")
            ' obj.EscribirLinea(y + s + 5, 61, IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", "")))

            'Dim iDelivery As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("DELIVERY")), 0, dtGastosLiquidacion.Rows(0).Item("DELIVERY"))
            'obj.EscribirLinea(y + s + 5, 10, "Delivery")
            'obj.EscribirLinea(y + s + 5, 61, IIf(iDelivery = 0, "0.00", FormatNumber(Format(iDelivery, "###,###,###.00"), 2))) '

            Dim iTotalOtrosIngresos As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS")), 0, dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS"))
            obj.EscribirLinea(y + s + 5, 10, "Otros Ingresos (Fotocopias, etc.)") '2 

            iLinea = Len(Trim(IIf(iTotalOtrosIngresos = 0, "0.00", FormatNumber(Format(iTotalOtrosIngresos, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 5, 67 - iLinea, IIf(iTotalOtrosIngresos = 0, "0.00", FormatNumber(Format(iTotalOtrosIngresos, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 6, 10, "------------------------------")
            obj.EscribirLinea(y + s + 6, 56, "------------")
            obj.EscribirLinea(y + s + 7, 10, "Total")

            'IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("DELIVERY")), 0, dtGastosLiquidacion.Rows(0).Item("DELIVERY")) + _
            Dim iTotalIngresos As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS")), 0, dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS"))  'IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", "") + _

            iLinea = Len(Trim(IIf(iTotalIngresos = 0, "0.00", FormatNumber(Format(iTotalIngresos, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 7, 67 - iLinea, IIf(iTotalIngresos = 0, "0.00", FormatNumber(Format(iTotalIngresos, "###,###,###.00"), 2)))

            'hlamas 14-06-2017
            'se agrega pagos con nota de credito referencial, los montos ya estan cargados en el efectivo
            Dim intFilas As Integer, intFilasNC As Integer = 9
            If NCBoleta > 0 Then
                intFilas = 4
                iLinea = Len(Trim(IIf(NCBoleta = 0, "0.00", FormatNumber(Format(NCBoleta, "###,###,###.00"), 2))))
                obj.EscribirLinea(y + s + intFilasNC, 10, "NC. Boleta")
                obj.EscribirLinea(y + s + intFilasNC, 67 - iLinea, IIf(NCBoleta = 0, "0.00", FormatNumber(Format(NCBoleta, "###,###,###.00"), 2)))
            End If
            If NCFactura > 0 Then
                intFilas += 4
                intFilasNC += IIf(NCBoleta > 0, 1, 0)
                obj.EscribirLinea(y + s + intFilasNC, 10, "NC. Factura")
                iLinea = Len(Trim(IIf(NCFactura = 0, "0.00", FormatNumber(Format(NCFactura, "###,###,###.00"), 2))))
                obj.EscribirLinea(y + s + intFilasNC, 67 - iLinea, IIf(NCFactura = 0, "0.00", FormatNumber(Format(NCFactura, "###,###,###.00"), 2)))
            End If
            If NCBoleta + NCFactura > 0 Then
                obj.EscribirLinea(y + s + intFilasNC + 1, 56, "------------")
                obj.EscribirLinea(y + s + intFilasNC + 2, 10, "Total")
                iLinea = Len(Trim(IIf(NCBoleta + NCFactura = 0, "0.00", FormatNumber(Format(NCBoleta + NCFactura, "###,###,###.00"), 2))))
                obj.EscribirLinea(y + s + intFilasNC + 2, 67 - iLinea, IIf(NCBoleta + NCFactura = 0, "0.00", FormatNumber(Format(NCBoleta + NCFactura, "###,###,###.00"), 2)))
                If NCBoleta > 0 And NCFactura > 0 Then
                    intFilas -= 3
                End If
            End If

            '====EGRESOS================================
            obj.EscribirLinea(y + s + 9 + intFilas, 10, "EGRESOS")
            obj.EscribirLinea(y + s + 10 + intFilas, 10, "--------------")

            obj.EscribirLinea(y + s + 11 + intFilas, 10, "Venta Carga PCE")
            iLinea = Len(Trim(IIf(totalPCECarga = 0, "0.00", FormatNumber(Format(totalPCECarga, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 11 + intFilas, 67 - iLinea, IIf(totalPCECarga = 0, "0.00", FormatNumber(Format(totalPCECarga, "###,###,###.00"), 2)))


            obj.EscribirLinea(y + s + 12 + intFilas, 10, "Venta Carga Credito")
            iLinea = Len(Trim(IIf(TotalCredito = 0, "0.00", FormatNumber(Format(TotalCredito, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 12 + intFilas, 67 - iLinea, IIf(TotalCredito = 0, "0.00", FormatNumber(Format(TotalCredito, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 13 + intFilas, 10, "------------------------------")
            obj.EscribirLinea(y + s + 13 + intFilas, 56, "------------")
            obj.EscribirLinea(y + s + 14 + intFilas, 10, "Total")
            Dim itotalEgreso1 As Double = FormatNumber(totalPCECarga, 2) + TotalCredito ' + Abs(nc)
            iLinea = Len(Trim(IIf(itotalEgreso1 = 0, "0.00", FormatNumber(Format(itotalEgreso1, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 14 + intFilas, 67 - iLinea, IIf(itotalEgreso1 = 0, "0.00", FormatNumber(Format(itotalEgreso1, "###,###,###.00"), 2)))



            obj.EscribirLinea(y + s + 16 + intFilas, 10, "TC. Visa Carga")
            iLinea = Len(Trim(IIf(TotalMontoTarjeVisa = 0, "0.00", FormatNumber(Format(TotalMontoTarjeVisa, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 16 + intFilas, 67 - iLinea, IIf(TotalMontoTarjeVisa = 0, "0.00", FormatNumber(Format(TotalMontoTarjeVisa, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 17 + intFilas, 10, "TC. Master Carga")
            iLinea = Len(Trim(IIf(TotalMontoTarjeMaster = 0, "0.00", FormatNumber(Format(TotalMontoTarjeMaster, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 17 + intFilas, 67 - iLinea, IIf(TotalMontoTarjeMaster = 0, "0.00", FormatNumber(Format(TotalMontoTarjeMaster, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 18 + intFilas, 10, "------------------------------")
            obj.EscribirLinea(y + s + 18 + intFilas, 56, "------------")
            obj.EscribirLinea(y + s + 19 + intFilas, 10, "Total")
            Dim iTotalEgreso2 As Double = (TotalMontoTarjeVisa + TotalMontoTarjeMaster)
            iLinea = Len(Trim(IIf(iTotalEgreso2 = 0, "0.00", FormatNumber(Format(iTotalEgreso2, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 19 + intFilas, 67 - iLinea, IIf(iTotalEgreso2 = 0, "0.00", FormatNumber(Format(iTotalEgreso2, "###,###,###.00"), 2)))


            obj.EscribirLinea(y + s + 21 + intFilas, 10, "Devoluciones Carga")
            iLinea = Len(Trim(IIf(totalDevolucionCarga = 0, "0.00", FormatNumber(Format(totalDevolucionCarga, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 21 + intFilas, 67 - iLinea, IIf(totalDevolucionCarga = 0, "0.00", FormatNumber(Format(totalDevolucionCarga, "###,###,###.00"), 2))) 'p2
            obj.EscribirLinea(y + s + 22 + intFilas, 10, "------------------------------")
            obj.EscribirLinea(y + s + 22 + intFilas, 56, "------------")
            obj.EscribirLinea(y + s + 23 + intFilas, 10, "Total")
            Dim iTotalEgreso3 As Double = totalDevolucionCarga
            iLinea = Len(Trim(IIf(iTotalEgreso3 = 0, "0.00", FormatNumber(Format(iTotalEgreso3, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 23 + intFilas, 67 - iLinea, IIf(iTotalEgreso3 = 0, "0.00", FormatNumber(Format(iTotalEgreso3, "###,###,###.00"), 2)))

            '============================================================
            'Dim TRANSFERENCIA_BANCARIA As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TRANSFERENCIA_BANCARIA")), 0, (dtGastosLiquidacion.Rows(0).Item("TRANSFERENCIA_BANCARIA")))
            ' Dim DEVOLUCION_DE_CARGA As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("DEVOLUCION_DE_CARGA")), 0, (dtGastosLiquidacion.Rows(0).Item("DEVOLUCION_DE_CARGA")))
            'Dim Gastos_Varios As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("GASTOS_VARIOS")), 0, (dtGastosLiquidacion.Rows(0).Item("GASTOS_VARIOS")))
            'Dim PAGO_PEAJE_FUERA_DEL_COUNT As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("PAGO_PEAJE_FUERA_DEL_COUNT")), 0, (dtGastosLiquidacion.Rows(0).Item("PAGO_PEAJE_FUERA_DEL_COUNT")))
            'Dim GASTOS_CON_RECIBO_DE_CAJA As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("GASTOS_CON_RECIBO_DE_CAJA")), 0, (dtGastosLiquidacion.Rows(0).Item("GASTOS_CON_RECIBO_DE_CAJA")))
            'Dim PAGO_GIROS As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("PAGO_GIROS")), 0, (dtGastosLiquidacion.Rows(0).Item("PAGO_GIROS")))

            'obj.EscribirLinea(y + s + 33, 10, "Transferencia Bancarias") '
            'obj.EscribirLinea(y + s + 33, 61, TRANSFERENCIA_BANCARIA)


            obj.EscribirLinea(y + s + 25 + intFilas, 10, "Encomiendas Cortesia") 'carga
            iLinea = Len(Trim(IIf(totalEncomiendaCortesia = 0, "0.00", FormatNumber(Format(totalEncomiendaCortesia, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 25 + intFilas, 67 - iLinea, IIf(totalEncomiendaCortesia = 0, "0.00", FormatNumber(Format(totalEncomiendaCortesia, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 26 + intFilas, 10, "------------------------------")
            obj.EscribirLinea(y + s + 26 + intFilas, 56, "------------")
            obj.EscribirLinea(y + s + 27 + intFilas, 10, "Total")
            Dim iTotalEgreso4 As Double = (totalEncomiendaCortesia)
            iLinea = Len(Trim(IIf(iTotalEgreso4 = 0, "0.00", FormatNumber(Format(iTotalEgreso4, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 27 + intFilas, 67 - iLinea, IIf(iTotalEgreso4 = 0, "0.00", FormatNumber(Format(iTotalEgreso4, "###,###,###.00"), 2)))


            Dim iTotalOtrosEgresos As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_EGRESOS")), 0, dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_EGRESOS"))
            obj.EscribirLinea(y + s + 29 + intFilas, 10, "OTROS EGRESOS") '2 
            iLinea = Len(Trim(IIf(iTotalOtrosEgresos = 0, "0.00", FormatNumber(Format(iTotalOtrosEgresos, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 29 + intFilas, 67 - iLinea, IIf(iTotalOtrosEgresos = 0, "0.00", FormatNumber(Format(iTotalOtrosEgresos, "###,###,###.00"), 2)))
            obj.EscribirLinea(y + s + 30 + intFilas, 10, "------------------------------")
            obj.EscribirLinea(y + s + 30 + intFilas, 56, "------------")
            obj.EscribirLinea(y + s + 31 + intFilas, 10, "Total")
            obj.EscribirLinea(y + s + 31 + intFilas, 67 - iLinea, IIf(iTotalOtrosEgresos = 0, "0.00", FormatNumber(Format(iTotalOtrosEgresos, "###,###,###.00"), 2)))


            Dim iTotalGeneralIngresos2 As Double = totalFacturaPsje + totalBoletaPsje + totalPCEPsje + totalFacturaCarga + totalBoletaCarga + totalPCECarga + TotalCredito + iTotalIngresos
            Dim iTotalEgresos As Double = itotalEgreso1 + iTotalEgreso2 + iTotalEgreso3 + iTotalEgreso4 + iTotalOtrosEgresos
            Dim iTotalSaldoDepositar As Double = (totalFacturaPsje + totalBoletaPsje + totalPCEPsje + totalFacturaCarga + totalBoletaCarga + totalPCECarga + iTotalIngresos + TotalCredito) - (itotalEgreso1 + iTotalEgreso2 + iTotalEgreso3 + iTotalEgreso4 + iTotalOtrosEgresos)
            obj.EscribirLinea(y + s + 33 + intFilas, 10, "-----------------------------")
            obj.EscribirLinea(y + s + 33 + intFilas, 56, "------------")
            obj.EscribirLinea(y + s + 34 + intFilas, 10, "Total Ingresos")
            iLinea = Len(Trim(IIf(iTotalGeneralIngresos2 = 0, "0.00", FormatNumber(Format(iTotalGeneralIngresos2, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 34 + intFilas, 67 - iLinea, IIf(iTotalGeneralIngresos2 = 0, "0.00", FormatNumber(Format(iTotalGeneralIngresos2, "###,###,###.00"), 2)))

            obj.EscribirLinea(y + s + 35 + intFilas, 10, "Total Egresos")
            iLinea = Len(Trim(IIf(iTotalEgresos = 0, "0.00", FormatNumber(Format(iTotalEgresos, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 35 + intFilas, 67 - iLinea, IIf(iTotalEgresos = 0, "0.00", FormatNumber(Format(iTotalEgresos, "###,###,###.00"), 2)))


            obj.EscribirLinea(y + s + 36 + intFilas, 10, "Saldo a Entregar")
            iLinea = Len(Trim(IIf(iTotalSaldoDepositar = 0, "0.00", FormatNumber(Format(iTotalSaldoDepositar, "###,###,###.00"), 2))))
            obj.EscribirLinea(y + s + 36 + intFilas, 67 - iLinea, IIf(iTotalSaldoDepositar = 0, "0.00", FormatNumber(Format(iTotalSaldoDepositar, "###,###,###.00"), 2)))

            obj.Comprimido = True
            obj.Preliminar = True
            obj.Tamaño = iLong
            obj.ReglaVertical = False
            obj.Imprimir()
            obj.Finalizar()

            Dim frm As New FrmPreview
            frm.WindowState = FormWindowState.Maximized
            frm.Tamaño = iLong
            frm.Documento = 1
            frm.Text = "Factura"
            frm.ShowDialog()

            objImprimir = Nothing
            objImpresora = Nothing
        Catch ex As Exception
            obj.Finalizar()
            Throw New Exception(ex.Message)
        End Try
    End Sub

#End Region

    Private Sub TabLiquidacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabLiquidacion.SelectedIndexChanged
        If TabLiquidacion.TabPages.Count = 5 Then
            If TabLiquidacion.SelectedIndex = 0 Or TabLiquidacion.SelectedIndex = 1 Or TabLiquidacion.SelectedIndex = 2 Or TabLiquidacion.SelectedIndex = 3 Then
                Me.TabGastos = TabLiquidacion.TabPages(4)
                Me.TabLiquidacion.Controls.RemoveAt(4)
            End If
        ElseIf TabLiquidacion.TabPages.Count = 4 Then
            If Not bAperturado Then
                If TabLiquidacion.SelectedIndex = 0 Or TabLiquidacion.SelectedIndex = 1 Or TabLiquidacion.SelectedIndex = 2 Then
                    Me.TabGastos = TabLiquidacion.TabPages(3)
                    Me.TabLiquidacion.Controls.RemoveAt(3)
                End If
            End If
        End If

        If intLlamada = 0 Then
            If TabLiquidacion.SelectedIndex = 1 Then
                BtnNuevo_Click(Nothing, Nothing)
            End If
        Else
            intLlamada = 0
        End If
    End Sub

    Sub ListarCajas()
        Dim obj As New dtoCierreOficina
        Dim ds As DataSet = obj.Inicio(dtoUSUARIOS.IdLogin, dtoUSUARIOS.iIDAGENCIAS, dtpFecha.Value.ToShortDateString)
        '--->Lista el estado de cajas (Carga y VyR)
        Dim dr As DataRow
        Dim dtCounterCargaCajaAperturadas As DataTable = ds.Tables(5)
        With Me.DgvUsrCajasAperturadas
            Me.FormatoDgvUsuarios()
            'Me.ListaCajasAperturadasPsjes()
            'For Each row As DataRow In dtCajasAperturadasPsjes.Rows
            Dim dtEstadoCajas As New DataTable

            '-->Obtiene el estado de las cajas del SisVyr - jabanto
            'dtEstadoCajas = liquidacionSisvyr.buscarEstadoLiquidaciones(dtoUSUARIOS.m_sFecha, dtoUSUARIOS.codAgenciaSisvyr).Tables(0)
            'dtEstadoCajas = liquidacionSisvyr.buscarEstadoLiquidaciones(dtpFecha.Value.ToShortDateString, dtoUSUARIOS.codAgenciaSisvyr).Tables(0)
            For Each row As DataRow In dtEstadoCajas.Rows
                dr = dtCounterCargaCajaAperturadas.NewRow
                dr("USUARIO") = row.Item("USUARIO")
                dr("FECHALIQ") = row.Item("FECHALIQ")
                dr("HORALIQ") = row.Item("HORALIQ")
                dr("ESTADOLIQ") = row.Item("ESTADOLIQ")
                dr("ID") = row.Item("ID")
                dtCounterCargaCajaAperturadas.Rows.Add(dr)
            Next
            .DataSource = dtCounterCargaCajaAperturadas
        End With
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        ListarCajas()
    End Sub

    Private Sub btnAbrirLiquidacionDiaria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrirLiquidacionDiaria.Click
        Try
            If Not Acceso.SiRol(G_Rol, Me, 2) Then
                MessageBox.Show("No tiene acceso.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está seguro de abrir la liquidación diaria?", "Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.AppStarting
                Dim obj As New dtoCierreOficina
                Dim intId As Integer = Me.DgvUsrCajasAperturadas.CurrentRow.Cells("id").Value
                Dim strFecha As String = Me.DgvUsrCajasAperturadas.CurrentRow.Cells("fechaliq").Value
                Dim intNegocio As Integer = IIf(IsDBNull(DgvUsrCajasAperturadas.CurrentRow.Cells("NEGOCIO").Value), 0, DgvUsrCajasAperturadas.CurrentRow.Cells("NEGOCIO").Value)
                If intNegocio = 1 Then
                    obj.AbrirLiquidacion(intId, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP)
                Else
                    obj.AbrirLiquidacionPasaje(intId, strFecha, dtoUSUARIOS.iIDAGENCIAS)
                End If
                ListarCajas()

                Dim dtlistadoUsuario As DataTable = obj.ListadoUsuario(LblFecha.Text, LblCodLiquidacion.Text, dtoUSUARIOS.m_iIdAgencia)
                With DgvListado
                    .DataSource = dtlistadoUsuario
                End With

                If DTCounterCargaDesasociadas IsNot Nothing Then
                    With Me.LstCarga1
                        .DataSource = DTCounterCargaDesasociadas
                        .DisplayMember = "nombre"
                        .ValueMember = "idusuario_personal"
                    End With
                End If

                dtCounterCargaAsociadas = obj.ListarCounterAsociadas(IDLiquidacionOficina, dtoUSUARIOS.iIDAGENCIAS, LblFecha.Text)
                With Me.LstCarga2
                    .DataSource = dtCounterCargaAsociadas
                    .DisplayMember = "nombre"
                    .ValueMember = "idusuario_personal"
                End With

                ListarCaja(1)

                Me.BtnBuscar_Click(Nothing, Nothing)

                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarCaja(ByVal opcion As Integer)
        Dim obj As New dtoCierreOficina
        dtCaja = obj.ListarCaja(Me.CboFechaLiquidacion.Value.ToShortDateString, dtoUSUARIOS.iIDAGENCIAS, opcion)
        With Me.cboCaja
            .DataSource = dtCaja
            .DisplayMember = "usuario"
            .ValueMember = "id"
            .SelectedValue = 0
        End With
    End Sub

    Private Sub btnAbrirLiquidacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrirLiquidacion.Click
        Try
            If Not Acceso.SiRol(G_Rol, Me, 1) Then
                MessageBox.Show("No tiene acceso.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim dlgRespuesta As DialogResult
            dlgRespuesta = MessageBox.Show("¿Está seguro de abrir la liquidación de Oficina?", "Titan", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.AppStarting
                Dim obj As New dtoCierreOficina
                Dim intId As Integer = Me.dgvListaCaja.CurrentRow.Cells("ID_Oficina_Liquidacion").Value
                Dim strFecha As String = Me.dgvListaCaja.CurrentRow.Cells("Fecha_Apertura").Value
                obj.AbrirLiquidacionOficina(intId, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, strFecha, dtoUSUARIOS.IdRol)
                Me.BtnBuscar_Click(Nothing, Nothing)
                ListarCajas()
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DgvUsrCajasAperturadas_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvUsrCajasAperturadas.RowEnter
        Dim obj As New dtoCierreOficina
        Dim intOficinaCerrada As Integer = obj.EstadoLiquidacionOficina(dtpFecha.Value.ToShortDateString, dtoUSUARIOS.iIDAGENCIAS)
        Me.btnAbrirLiquidacionDiaria.Enabled = DgvUsrCajasAperturadas.Rows(e.RowIndex).Cells("ESTADOLIQ").Value = "CERRADO" And intOficinaCerrada = 0 ' And Not IsDBNull(DgvUsrCajasAperturadas.Rows(e.RowIndex).Cells("NEGOCIO").Value)
    End Sub

    Private Sub TxtNroDocumento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNroDocumento.TextChanged

    End Sub

    Private Sub TxtNroOperacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNroOperacion.TextChanged

    End Sub

    Private Sub TxtObservaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtObservaciones.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            Me.BtnGuardar.Focus()
        End If
    End Sub

    Private Sub TxtObservaciones_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtObservaciones.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtObservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtObservaciones.TextChanged

    End Sub

    Private Sub TxtCodigoPeaje_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoPeaje.TextChanged

    End Sub

    Private Sub TxtMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMonto.TextChanged

    End Sub

    Private Sub CboDestino_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboDestino.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub CboDestino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDestino.SelectedIndexChanged

    End Sub

    Private Sub CboPiloto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboPiloto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub CboPiloto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboPiloto.SelectedIndexChanged

    End Sub

    Private Sub TxtNroBus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNroBus.TextChanged

    End Sub

    Private Sub TxtDesositante_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDesositante.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub TxtDesositante_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDesositante.TextChanged

    End Sub

    Private Sub TxtContacto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtContacto.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub TxtContacto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtContacto.TextChanged

    End Sub

    Private Sub CboFechaLiquidacion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboFechaLiquidacion.ValueChanged
        Me.dgvComprobanteCierre.Rows.Clear()
        Me.txtRetiroSolesCierre.Text = "0.00"
    End Sub
    Public Function MontoEfectivo(ByVal IDLiquidacion As Integer, ByVal agencia As Integer, ByVal fecha As String) As Double
        Dim obj As New Imprimir
        Try
            Dim ldt_cur_datos_venta As New DataTable
            Dim dtGastosLiquidacion As New DataTable
            Dim lds_tmp As New DataSet
            Dim flag As Boolean = False
            Dim iSubTotal As Double = 0, iImpuesto As Double = 0, iTotal As Double = 0

            lds_tmp = ObjVentaCargaContado.ListaDatosLiquidacion(agencia, IDLiquidacion, fecha, 1)
            ldt_cur_datos_venta = lds_tmp.Tables(0).Copy
            dtGastosLiquidacion = lds_tmp.Tables(1).Copy

            '----------------------------------------------------------------------------------
            Dim objCierreOficina As New dtoCierreOficina
            Dim s As Integer = 5
            Dim totalFacturaCarga As Double, totalBoletaCarga As Double, totalPCECarga As Double, TotalMontoTarjeVisa As Double, TotalMontoTarjeMaster As Double
            Dim totalFacturaPsje As Double
            Dim totalBoletaPsje As Double, totalPCEPsje As Double, TotalCredito As Double, totalDevolucionCarga As Double
            Dim totalEncomiendaCortesia As Double
            Dim TotalOtrosIngresos As Double, TotalOtrosIngresosTarjeta As Double
            Dim NCCarga As Double
            Dim NCBoleta As Double, NCFactura As Double

            '====PASAJE=======
            'Me.ListaTotalesPsjes(IDLiquidacion)
            Dim dtListaTotalesPsjes As DataSet = objCierreOficina.PrevistaReporte(1, IDLiquidacion, fecha, agencia)
            For Each fila As DataRow In dtListaTotalesPsjes.Tables(1).Rows
                totalFacturaPsje += IIf(IsDBNull(fila.Item("montoefectivo")), 0, fila.Item("montoefectivo"))
            Next

            s += 5
            For Each fila As DataRow In ldt_cur_datos_venta.Rows
                totalFacturaCarga += IIf(IsDBNull(fila.Item("TOTAL_MONTO_FACTU")), 0, fila.Item("TOTAL_MONTO_FACTU"))
                totalBoletaCarga += IIf(IsDBNull(fila.Item("TOTAL_MONTO_BOLE")), 0, fila.Item("TOTAL_MONTO_BOLE"))
                totalPCECarga += IIf(IsDBNull(fila.Item("TOTAL_MONTO_PAGO_ENTRE")), 0, fila.Item("TOTAL_MONTO_PAGO_ENTRE"))
                TotalMontoTarjeVisa += IIf(IsDBNull(fila.Item("total_monto_tarje_Visa")), 0, fila.Item("total_monto_tarje_Visa"))
                TotalMontoTarjeMaster += IIf(IsDBNull(fila.Item("total_monto_tarje_Master")), 0, fila.Item("total_monto_tarje_Master"))
                TotalCredito += IIf(IsDBNull(fila.Item("total_Credito")), 0, fila.Item("total_Credito"))
                totalDevolucionCarga += IIf(IsDBNull(fila.Item("Total_DevolucionCarga")), 0, fila.Item("Total_DevolucionCarga"))
                totalEncomiendaCortesia += IIf(IsDBNull(fila.Item("Total_Encomiendas_Cortesia")), 0, fila.Item("Total_Encomiendas_Cortesia"))
                NCCarga += IIf(IsDBNull(fila.Item("nc")), 0, fila.Item("nc"))
                NCBoleta += IIf(IsDBNull(fila.Item("pagonc_boleta")), 0, fila.Item("pagonc_boleta"))
                NCFactura += IIf(IsDBNull(fila.Item("pagonc_factura")), 0, fila.Item("pagonc_factura"))

                TotalOtrosIngresos += IIf(IsDBNull(fila.Item("total_monto_otros")), 0, fila.Item("total_monto_otros"))
                TotalOtrosIngresosTarjeta += IIf(IsDBNull(fila.Item("total_monto_tarjeta_otros")), 0, fila.Item("total_monto_tarjeta_otros"))
            Next

            Dim iReciboCajaPrepagada As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", ""))
            Dim iDelivery As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("DELIVERY")), 0, dtGastosLiquidacion.Rows(0).Item("DELIVERY"))
            Dim iOtrosIngresos As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS")), 0, dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS"))
            Dim iVentaSegurosPaxfre As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TOTAL_SEGURO_PAXFRE")), 0, dtGastosLiquidacion.Rows(0).Item("TOTAL_SEGURO_PAXFRE"))
            Dim iVentaSegurosPaxNor As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TOTAL_SEGURO_PAXNOR")), 0, dtGastosLiquidacion.Rows(0).Item("TOTAL_SEGURO_PAXNOR"))
            Dim iTotalVentaSeguros As Double = iVentaSegurosPaxfre + iVentaSegurosPaxNor
            Dim poolVentaTotal As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("POOL_TOTAL_VENTA")), 0, dtGastosLiquidacion.Rows(0).Item("POOL_TOTAL_VENTA"))
            Dim poolVentaVisa As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("POOL_VENTA_VISA")), 0, dtGastosLiquidacion.Rows(0).Item("POOL_VENTA_VISA"))
            Dim poolVentaMAstercard As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("POOL_VENTA_MASTERCARD")), 0, dtGastosLiquidacion.Rows(0).Item("POOL_VENTA_MASTERCARD"))

            TotalOtrosIngresosTarjeta = 0
            TotalOtrosIngresos = 0
            iOtrosIngresos += TotalOtrosIngresos + TotalOtrosIngresosTarjeta
            poolVentaTotal = 0

            Dim iTotalIngresos As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", "") +
                                             IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("DELIVERY")), 0, dtGastosLiquidacion.Rows(0).Item("DELIVERY")) +
                                             IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS")), 0, dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS"))) +
                                         iTotalVentaSeguros + TotalOtrosIngresos + TotalOtrosIngresosTarjeta + poolVentaTotal


            '====EGRESOS================================
            Dim VentaPasajeCredito As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CREDITO)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CREDITO)", ""))
            Dim VentaPasajePrepagado As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_PREPAGADOS)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_PREPAGADOS)", ""))
            Dim VentaPasajeCortesia As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CORTESIA)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CORTESIA)", ""))
            Dim NCPasaje As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(NC)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(NC)", ""))

            Dim itotalEgreso1 As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CREDITO)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CREDITO)", "")) + _
                              IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_PREPAGADOS)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_PREPAGADOS)", "")) + _
                              IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CORTESIA)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CORTESIA)", "")) + _
                              IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(NC)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(NC)", "")) + _
                              FormatNumber(totalPCECarga, 2) + TotalCredito + totalEncomiendaCortesia + iVentaSegurosPaxfre

            Dim iTarjetaVisaPasaje As Double, iTarjetaMasterCard As Double
            iTarjetaVisaPasaje = dtListaTotalesPsjes.Tables(0).Compute("sum(TARJETA_VISA_PASAJE)", "")
            iTarjetaMasterCard = dtListaTotalesPsjes.Tables(0).Compute("sum(TARJETA_MASTER_PASAJE)", "")

            iTarjetaVisaPasaje = iTarjetaVisaPasaje ' + poolVentaVisa
            iTarjetaMasterCard = iTarjetaMasterCard ' + poolVentaMAstercard

            poolVentaVisa = 0
            poolVentaMAstercard = 0

            Dim iTotalEgreso2 As Double = (TotalMontoTarjeVisa + TotalMontoTarjeMaster + iTarjetaVisaPasaje + iTarjetaMasterCard + poolVentaVisa + poolVentaMAstercard)
            Dim iTotalGeneralMaster As Double = (TotalMontoTarjeMaster + iTarjetaMasterCard + poolVentaMAstercard)
            Dim iTotalGeneralVisa As Double = (TotalMontoTarjeVisa + iTarjetaVisaPasaje + poolVentaVisa)
            Dim iDevolucionesPasajes As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(DEVOLUCIONES_PASAJES)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(DEVOLUCIONES_PASAJES)", ""))
            Dim DEVOLUCION_DE_CARGA As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("DEVOLUCION_DE_CARGA")), 0, (dtGastosLiquidacion.Rows(0).Item("DEVOLUCION_DE_CARGA")))
            Dim iTotalEgreso3 As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(DEVOLUCIONES_PASAJES)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(DEVOLUCIONES_PASAJES)", ""))

            '============================================================
            Dim TRANSFERENCIA_BANCARIA As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TRANSFERENCIA_BANCARIA")), 0, (dtGastosLiquidacion.Rows(0).Item("TRANSFERENCIA_BANCARIA")))
            Dim Gastos_Varios As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("GASTOS_VARIOS")), 0, (dtGastosLiquidacion.Rows(0).Item("GASTOS_VARIOS")))
            Dim PAGO_PEAJE_FUERA_DEL_COUNT As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("PAGO_PEAJE_FUERA_DEL_COUNT")), 0, (dtGastosLiquidacion.Rows(0).Item("PAGO_PEAJE_FUERA_DEL_COUNT")))
            Dim GASTOS_CON_RECIBO_DE_CAJA As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("GASTOS_CON_RECIBO_DE_CAJA")), 0, (dtGastosLiquidacion.Rows(0).Item("GASTOS_CON_RECIBO_DE_CAJA")))
            Dim PAGO_GIROS As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("PAGO_GIROS")), 0, (dtGastosLiquidacion.Rows(0).Item("PAGO_GIROS")))

            Dim iTotalEgreso4 As Double = (TRANSFERENCIA_BANCARIA +
                                           DEVOLUCION_DE_CARGA +
                                           Gastos_Varios +
                                           PAGO_PEAJE_FUERA_DEL_COUNT +
                                           GASTOS_CON_RECIBO_DE_CAJA +
                                           PAGO_GIROS
                                           )

            Dim iTotalGeneralIngresos As Double = totalFacturaPsje + totalBoletaPsje + totalPCEPsje + totalFacturaCarga + totalBoletaCarga + totalPCECarga + TotalCredito + iTotalIngresos
            Dim iTotalEgresos As Double = itotalEgreso1 + iTotalEgreso2 + iTotalEgreso3 + iTotalEgreso4
            Dim iSaldoDepositar As Double = (totalFacturaPsje + totalBoletaPsje + totalPCEPsje + totalFacturaCarga + totalBoletaCarga + totalPCECarga + TotalCredito + iTotalIngresos) - (itotalEgreso1 + iTotalEgreso2 + iTotalEgreso3 + iTotalEgreso4)

            Return iSaldoDepositar

        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function MontoEfectivo(ByVal IDLiquidacion As Integer, ByVal agencia As Integer, ByVal fecha As String, ByVal usuario As Integer) As Double
        Dim obj As New Imprimir
        Try
            Dim ldt_cur_datos_venta As New DataTable
            Dim dtGastosLiquidacion As New DataTable
            Dim lds_tmp As New DataSet
            Dim flag As Boolean = False
            Dim iSubTotal As Double = 0, iImpuesto As Double = 0, iTotal As Double = 0

            If usuario > 0 Then
                lds_tmp = ObjVentaCargaContado.ListaDatosLiquidacionUsuario(agencia, IDLiquidacion, fecha, 1, usuario)
            Else
                lds_tmp = ObjVentaCargaContado.ListaDatosLiquidacion(agencia, IDLiquidacion, fecha, 1)
            End If
            ldt_cur_datos_venta = lds_tmp.Tables(0).Copy
            dtGastosLiquidacion = lds_tmp.Tables(1).Copy

            '----------------------------------------------------------------------------------
            Dim objCierreOficina As New dtoCierreOficina
            Dim s As Integer = 5
            Dim totalFacturaCarga As Double, totalBoletaCarga As Double, totalPCECarga As Double, TotalMontoTarjeVisa As Double, TotalMontoTarjeMaster As Double
            Dim totalFacturaPsje As Double
            Dim totalBoletaPsje As Double, totalPCEPsje As Double, TotalCredito As Double, totalDevolucionCarga As Double
            Dim totalEncomiendaCortesia As Double
            Dim TotalOtrosIngresos As Double, TotalOtrosIngresosTarjeta As Double
            Dim NCCarga As Double
            Dim NCBoleta As Double, NCFactura As Double

            '====PASAJE=======
            'Me.ListaTotalesPsjes(IDLiquidacion)
            Dim dtListaTotalesPsjes As DataSet
            If usuario > 0 Then
                dtListaTotalesPsjes = objCierreOficina.PrevistaReporteUsuario(1, IDLiquidacion, fecha, agencia, usuario)
            Else
                dtListaTotalesPsjes = objCierreOficina.PrevistaReporte(1, IDLiquidacion, fecha, agencia)
            End If
            For Each fila As DataRow In dtListaTotalesPsjes.Tables(1).Rows
                totalFacturaPsje += IIf(IsDBNull(fila.Item("montoefectivo")), 0, fila.Item("montoefectivo"))
            Next

            s += 5
            For Each fila As DataRow In ldt_cur_datos_venta.Rows
                totalFacturaCarga += IIf(IsDBNull(fila.Item("TOTAL_MONTO_FACTU")), 0, fila.Item("TOTAL_MONTO_FACTU"))
                totalBoletaCarga += IIf(IsDBNull(fila.Item("TOTAL_MONTO_BOLE")), 0, fila.Item("TOTAL_MONTO_BOLE"))
                totalPCECarga += IIf(IsDBNull(fila.Item("TOTAL_MONTO_PAGO_ENTRE")), 0, fila.Item("TOTAL_MONTO_PAGO_ENTRE"))
                TotalMontoTarjeVisa += IIf(IsDBNull(fila.Item("total_monto_tarje_Visa")), 0, fila.Item("total_monto_tarje_Visa"))
                TotalMontoTarjeMaster += IIf(IsDBNull(fila.Item("total_monto_tarje_Master")), 0, fila.Item("total_monto_tarje_Master"))
                TotalCredito += IIf(IsDBNull(fila.Item("total_Credito")), 0, fila.Item("total_Credito"))
                totalDevolucionCarga += IIf(IsDBNull(fila.Item("Total_DevolucionCarga")), 0, fila.Item("Total_DevolucionCarga"))
                totalEncomiendaCortesia += IIf(IsDBNull(fila.Item("Total_Encomiendas_Cortesia")), 0, fila.Item("Total_Encomiendas_Cortesia"))
                NCCarga += IIf(IsDBNull(fila.Item("nc")), 0, fila.Item("nc"))
                NCBoleta += IIf(IsDBNull(fila.Item("pagonc_boleta")), 0, fila.Item("pagonc_boleta"))
                NCFactura += IIf(IsDBNull(fila.Item("pagonc_factura")), 0, fila.Item("pagonc_factura"))

                TotalOtrosIngresos += IIf(IsDBNull(fila.Item("total_monto_otros")), 0, fila.Item("total_monto_otros"))
                TotalOtrosIngresosTarjeta += IIf(IsDBNull(fila.Item("total_monto_tarjeta_otros")), 0, fila.Item("total_monto_tarjeta_otros"))
            Next

            Dim iReciboCajaPrepagada As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", ""))
            Dim iDelivery As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("DELIVERY")), 0, dtGastosLiquidacion.Rows(0).Item("DELIVERY"))
            Dim iOtrosIngresos As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS")), 0, dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS"))
            Dim iVentaSegurosPaxfre As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TOTAL_SEGURO_PAXFRE")), 0, dtGastosLiquidacion.Rows(0).Item("TOTAL_SEGURO_PAXFRE"))
            Dim iVentaSegurosPaxNor As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TOTAL_SEGURO_PAXNOR")), 0, dtGastosLiquidacion.Rows(0).Item("TOTAL_SEGURO_PAXNOR"))
            Dim iTotalVentaSeguros As Double = iVentaSegurosPaxfre + iVentaSegurosPaxNor
            Dim poolVentaTotal As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("POOL_TOTAL_VENTA")), 0, dtGastosLiquidacion.Rows(0).Item("POOL_TOTAL_VENTA"))
            Dim poolVentaVisa As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("POOL_VENTA_VISA")), 0, dtGastosLiquidacion.Rows(0).Item("POOL_VENTA_VISA"))
            Dim poolVentaMAstercard As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("POOL_VENTA_MASTERCARD")), 0, dtGastosLiquidacion.Rows(0).Item("POOL_VENTA_MASTERCARD"))

            TotalOtrosIngresosTarjeta = 0
            TotalOtrosIngresos = 0
            iOtrosIngresos += TotalOtrosIngresos + TotalOtrosIngresosTarjeta
            poolVentaTotal = 0

            Dim iTotalIngresos As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(RECIBO_CAJA_PREPAGADA)", "") +
                                             IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("DELIVERY")), 0, dtGastosLiquidacion.Rows(0).Item("DELIVERY")) +
                                             IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS")), 0, dtGastosLiquidacion.Rows(0).Item("TOTAL_OTROS_INGRESOS"))) +
                                         iTotalVentaSeguros + TotalOtrosIngresos + TotalOtrosIngresosTarjeta + poolVentaTotal


            '====EGRESOS================================
            Dim VentaPasajeCredito As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CREDITO)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CREDITO)", ""))
            Dim VentaPasajePrepagado As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_PREPAGADOS)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_PREPAGADOS)", ""))
            Dim VentaPasajeCortesia As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CORTESIA)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CORTESIA)", ""))
            Dim NCPasaje As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(NC)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(NC)", ""))

            Dim itotalEgreso1 As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CREDITO)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CREDITO)", "")) + _
                              IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_PREPAGADOS)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_PREPAGADOS)", "")) + _
                              IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CORTESIA)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(VENTA_PASAJE_CORTESIA)", "")) + _
                              IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(NC)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(NC)", "")) + _
                              FormatNumber(totalPCECarga, 2) + TotalCredito + totalEncomiendaCortesia + iVentaSegurosPaxfre

            Dim iTarjetaVisaPasaje As Double, iTarjetaMasterCard As Double
            iTarjetaVisaPasaje = dtListaTotalesPsjes.Tables(0).Compute("sum(TARJETA_VISA_PASAJE)", "")
            iTarjetaMasterCard = dtListaTotalesPsjes.Tables(0).Compute("sum(TARJETA_MASTER_PASAJE)", "")

            iTarjetaVisaPasaje = iTarjetaVisaPasaje ' + poolVentaVisa
            iTarjetaMasterCard = iTarjetaMasterCard ' + poolVentaMAstercard

            poolVentaVisa = 0
            poolVentaMAstercard = 0

            Dim iTotalEgreso2 As Double = (TotalMontoTarjeVisa + TotalMontoTarjeMaster + iTarjetaVisaPasaje + iTarjetaMasterCard + poolVentaVisa + poolVentaMAstercard)
            Dim iTotalGeneralMaster As Double = (TotalMontoTarjeMaster + iTarjetaMasterCard + poolVentaMAstercard)
            Dim iTotalGeneralVisa As Double = (TotalMontoTarjeVisa + iTarjetaVisaPasaje + poolVentaVisa)
            Dim iDevolucionesPasajes As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(DEVOLUCIONES_PASAJES)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(DEVOLUCIONES_PASAJES)", ""))
            Dim DEVOLUCION_DE_CARGA As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("DEVOLUCION_DE_CARGA")), 0, (dtGastosLiquidacion.Rows(0).Item("DEVOLUCION_DE_CARGA")))
            Dim iTotalEgreso3 As Double = IIf(IsDBNull(dtListaTotalesPsjes.Tables(0).Compute("sum(DEVOLUCIONES_PASAJES)", "")), 0, dtListaTotalesPsjes.Tables(0).Compute("sum(DEVOLUCIONES_PASAJES)", ""))

            '============================================================
            Dim TRANSFERENCIA_BANCARIA As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("TRANSFERENCIA_BANCARIA")), 0, (dtGastosLiquidacion.Rows(0).Item("TRANSFERENCIA_BANCARIA")))
            Dim Gastos_Varios As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("GASTOS_VARIOS")), 0, (dtGastosLiquidacion.Rows(0).Item("GASTOS_VARIOS")))
            Dim PAGO_PEAJE_FUERA_DEL_COUNT As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("PAGO_PEAJE_FUERA_DEL_COUNT")), 0, (dtGastosLiquidacion.Rows(0).Item("PAGO_PEAJE_FUERA_DEL_COUNT")))
            Dim GASTOS_CON_RECIBO_DE_CAJA As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("GASTOS_CON_RECIBO_DE_CAJA")), 0, (dtGastosLiquidacion.Rows(0).Item("GASTOS_CON_RECIBO_DE_CAJA")))
            Dim PAGO_GIROS As Double = IIf(IsDBNull(dtGastosLiquidacion.Rows(0).Item("PAGO_GIROS")), 0, (dtGastosLiquidacion.Rows(0).Item("PAGO_GIROS")))

            Dim iTotalEgreso4 As Double = (TRANSFERENCIA_BANCARIA +
                                           DEVOLUCION_DE_CARGA +
                                           Gastos_Varios +
                                           PAGO_PEAJE_FUERA_DEL_COUNT +
                                           GASTOS_CON_RECIBO_DE_CAJA +
                                           PAGO_GIROS
                                           )

            Dim iTotalGeneralIngresos As Double = totalFacturaPsje + totalBoletaPsje + totalPCEPsje + totalFacturaCarga + totalBoletaCarga + totalPCECarga + TotalCredito + iTotalIngresos
            Dim iTotalEgresos As Double = itotalEgreso1 + iTotalEgreso2 + iTotalEgreso3 + iTotalEgreso4
            Dim iSaldoDepositar As Double = (totalFacturaPsje + totalBoletaPsje + totalPCEPsje + totalFacturaCarga + totalBoletaCarga + totalPCECarga + TotalCredito + iTotalIngresos) - (itotalEgreso1 + iTotalEgreso2 + iTotalEgreso3 + iTotalEgreso4)

            Return iSaldoDepositar

        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Sub cboCaja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCaja.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            SendKeys.Send(vbTab)
        End If
    End Sub

    Private Sub cboCaja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCaja.SelectedIndexChanged
        If IsReference(cboCaja.SelectedValue) Then Return
        Dim intCerrado As Integer
        If Me.cboCaja.SelectedValue = 0 Then
            intCerrado = 2
        Else
            intCerrado = dtCaja.Rows(cboCaja.SelectedIndex).Item("cerrado")
        End If
        If intCerrado = 0 Then
            Me.BtnNuevo.Enabled = False
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
            Me.BtnGuardar.Enabled = False
            Me.lblEstadoCaja.Text = "ABIERTO"
        ElseIf intCerrado = 1 Then
            If Me.cboCaja.Enabled Then 'nuevo
                Me.BtnNuevo.Enabled = True
                Me.BtnModificar.Enabled = False
                Me.BtnEliminar.Enabled = False
                Me.BtnGuardar.Enabled = True
            Else 'modificar
                Me.BtnNuevo.Enabled = True
                Me.BtnModificar.Enabled = True
                Me.BtnEliminar.Enabled = True
                Me.BtnGuardar.Enabled = False
            End If
            Me.lblEstadoCaja.Text = "CERRADO"
        Else
            Me.lblEstadoCaja.Text = ""
        End If
    End Sub
End Class