Imports System.Threading
Public Class FrmAsignacionRecojo
#Region "Variables Publicas"
    Public hnd As Long
    Dim bSeleccion As Boolean = False
    Dim dFechaHora, sFechaHora As String
    Dim bInicio As Boolean = True
    Dim aLista(0) As sLista
    Dim ds, dsRuta, dsRuta2 As DataSet
    Dim sFechaServidor As String
    Dim celda As New DataGridViewComboBoxCell
    Dim celda2 As New DataGridViewComboBoxCell
    Dim iEntra As Integer = 0, iEntra2 As Integer = 0
    Dim bIngreso As Boolean = False
    Dim blnTodoOk As Boolean = False
    Dim comboPendiente As ComboBox
    Dim combo As ComboBox
    Structure sLista
        Dim check As Integer
        Dim recojo As Integer
        Dim old As Byte
        Dim estado As Integer
    End Structure
    Structure sRecojoReprogramado
        Dim recojo As Integer
        Dim ruta As Integer
    End Structure

    Dim mre As ManualResetEvent
    Dim nuestroThread As Thread
    Dim nuestroThreadStart As New ThreadStart(AddressOf ActualizacionesBackground)
    Dim CallFuncionGenerar As New MethodInvoker(AddressOf Me.Buscarrecojo)

    Dim mre2 As ManualResetEvent
    Dim nuestroThread2 As Thread
    Dim nuestroThreadStart2 As New ThreadStart(AddressOf ActualizacionesBackground2)
    Dim CallFuncionGenerar2 As New MethodInvoker(AddressOf Me.ListarRecojopendiente)
    Dim seg1 As Integer = 15000

#End Region
#Region "Formato"
    Sub FormatoDgvRecojo()
        With DgvRecojo
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            '.RowHeadersVisible = True
            .RowHeadersWidth = 20
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim col_seleccion As New DataGridViewCheckBoxColumn
            With col_seleccion
                .HeaderText = "Sel."
                .Name = "sel"
                '.DataPropertyName = "id_persona"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 35
                .SortMode = DataGridViewColumnSortMode.Automatic
                .FalseValue = 0
                .TrueValue = 1
            End With

            Dim col_id_persona As New DataGridViewTextBoxColumn
            With col_id_persona
                .HeaderText = "id cliente"
                .Name = "id_persona"
                .DataPropertyName = "id_persona"
                .Visible = False
            End With

            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .HeaderText = "Cliente"
                .Name = "cliente"
                .DataPropertyName = "cliente"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 300
            End With

            Dim col_id_direccion As New DataGridViewTextBoxColumn
            With col_id_direccion
                .HeaderText = "id direccion"
                .Name = "id_direccion"
                .DataPropertyName = "id_direccion"
                .Visible = False
            End With

            Dim col_direccion As New DataGridViewTextBoxColumn
            With col_direccion
                .HeaderText = "Dirección"
                .Name = "direccion"
                .DataPropertyName = "direccion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                '.Width = 350
            End With

            Dim col_hora_listo As New DataGridViewTextBoxColumn
            With col_hora_listo
                .HeaderText = "Hora Listo"
                .Name = "hora_listo"
                .DataPropertyName = "hora_listo"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 54
            End With

            Dim col_hora_cierre As New DataGridViewTextBoxColumn
            With col_hora_cierre
                .HeaderText = "Hora Cierre"
                .Name = "hora_cierre"
                .DataPropertyName = "hora_cierre"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 54
            End With

            Dim col_id_checkpoint As New DataGridViewTextBoxColumn
            With col_id_checkpoint
                .HeaderText = "id checkpoint"
                .Name = "id_checkpoint"
                .DataPropertyName = "id_checkpoint"
                .Visible = False
            End With

            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .HeaderText = "Estado"
                .Name = "estado"
                .DataPropertyName = "estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_id_tipo_recojo As New DataGridViewTextBoxColumn
            With col_id_tipo_recojo
                .HeaderText = "id tipo recojo"
                .Name = "id_tipo_recojo"
                .DataPropertyName = "id_tipo_recojo"
                .Visible = False
            End With

            Dim col_tipo_recojo As New DataGridViewTextBoxColumn
            With col_tipo_recojo
                .HeaderText = "Tipo Recojo"
                .Name = "tipo_recojo"
                .DataPropertyName = "tipo_recojo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 58
            End With

            Dim col_contacto As New DataGridViewTextBoxColumn
            With col_contacto
                .HeaderText = "Contacto"
                .Name = "contacto"
                .DataPropertyName = "contacto"
                .Visible = False
            End With

            Dim col_id_tipo_cliente As New DataGridViewTextBoxColumn
            With col_id_tipo_cliente
                .HeaderText = "id tipo cliente"
                .Name = "id_tipo_cliente"
                .DataPropertyName = "id_tipo_cliente"
                .Visible = False
            End With

            'hlamas 08-01-2019
            'Dim col_tipo_ruta As New DataGridViewTextBoxColumn
            'With col_tipo_ruta
            '    .HeaderText = "Tipo Ruta"
            '    .Name = "tipo_ruta"
            '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            '    .SortMode = DataGridViewColumnSortMode.Automatic
            '    .DataPropertyName = "tipo_ruta"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '    .ReadOnly = True
            'End With

            Dim col_ruta As New DataGridViewComboBoxColumn
            With col_ruta
                .HeaderText = "Ruta"
                .Name = "ruta"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DataPropertyName = "id_ruta_unidad_transporte"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DisplayStyleForCurrentCellOnly = True

                Dim obj As New DtoRecojo
                obj.Fecha = Me.DtpFecha.Text
                obj.Ciudad = dtoUSUARIOS.m_idciudad
                dsRuta2 = obj.ListarRuta(1)
                .DataSource = dsRuta2.Tables(0)
                .DisplayMember = "ruta"
                .ValueMember = "id_ruta_unidad_transporte"
                .Width = 150
            End With

            Dim col_id_recojo As New DataGridViewTextBoxColumn
            With col_id_recojo
                .HeaderText = "Nº"
                .Name = "id_recojo"
                .DataPropertyName = "id_recojo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            End With

            Dim col_departamento As New DataGridViewTextBoxColumn
            With col_departamento
                .HeaderText = "departamento"
                .Name = "departamento"
                .DataPropertyName = "departamento"
                .Visible = False
            End With

            Dim col_provincia As New DataGridViewTextBoxColumn
            With col_provincia
                .HeaderText = "provincia"
                .Name = "provincia"
                .DataPropertyName = "provincia"
                .Visible = False
            End With

            Dim col_distrito As New DataGridViewTextBoxColumn
            With col_distrito
                .HeaderText = "distrito"
                .Name = "distrito"
                .DataPropertyName = "distrito"
                .Visible = False
            End With

            Dim col_movil As New DataGridViewTextBoxColumn
            With col_movil
                .HeaderText = "Móvil"
                .Name = "movil"
                .DataPropertyName = "movil"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_id_movil As New DataGridViewTextBoxColumn
            With col_id_movil
                .HeaderText = "id movil"
                .Name = "id_movil"
                .DataPropertyName = "id_movil"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Visible = False
            End With

            Dim col_id_ruta As New DataGridViewTextBoxColumn
            With col_id_ruta
                .HeaderText = "id_ruta"
                .Name = "id_ruta"
                .DataPropertyName = "id_ruta"
                .Visible = False
            End With

            Dim col_chofer As New DataGridViewTextBoxColumn
            With col_chofer
                .HeaderText = "Chofer"
                .Name = "chofer"
                .DataPropertyName = "chofer"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .HeaderText = "id_estado"
                .Name = "id_estado"
                .DataPropertyName = "id_estado"
                .Visible = False
            End With

            Dim col_incidencia As New DataGridViewTextBoxColumn
            With col_incidencia
                .HeaderText = "Incidencia"
                .Name = "incidencia"
                .DataPropertyName = "incidencia"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 56
            End With

            Dim col_parcial As New DataGridViewTextBoxColumn
            With col_parcial
                .HeaderText = "Parcial"
                .Name = "parcial"
                .DataPropertyName = "parcial"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 56
            End With

            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .HeaderText = "Peso"
                .Name = "peso"
                .DataPropertyName = "peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim col_volumen As New DataGridViewTextBoxColumn
            With col_volumen
                .HeaderText = "Volumen"
                .Name = "volumen"
                .DataPropertyName = "volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .HeaderText = "Observación"
                .Name = "observacion"
                .DataPropertyName = "observacion"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim col_producto As New DataGridViewTextBoxColumn
            With col_producto
                .HeaderText = "producto"
                .Name = "producto"
                .DataPropertyName = "producto"
                .Visible = False
            End With

            Dim col_coordenada As New DataGridViewTextBoxColumn
            With col_coordenada
                .HeaderText = "Coordenada GPS"
                .Name = "coordenada"
                .DataPropertyName = "coordenada"
                .Visible = True
            End With

            Dim col_tiempo As New DataGridViewTextBoxColumn
            With col_tiempo
                .HeaderText = "tiempo"
                .Name = "tiempo"
                .DataPropertyName = "tiempo"
                .Visible = False
            End With

            'hlamas 08-01-2019
            '.Columns.AddRange(col_seleccion, col_id_recojo, col_id_persona, col_cliente, col_id_direccion, col_direccion, _
            'col_hora_listo, col_hora_cierre, col_id_tipo_cliente, col_tipo_ruta, col_ruta, col_movil, col_chofer, col_id_checkpoint, col_estado, col_id_tipo_recojo, _
            'col_tipo_recojo, col_contacto, col_departamento, col_provincia, _
            'col_distrito, col_id_movil, col_id_ruta_unidad_transporte, col_id_estado, _
            'col_peso, col_volumen, col_incidencia, col_parcial, col_observacion)
            .Columns.AddRange(col_seleccion, col_id_recojo, col_id_persona, col_cliente, col_id_direccion, col_direccion, _
            col_hora_listo, col_hora_cierre, col_id_tipo_cliente, col_ruta, col_movil, col_chofer, col_id_checkpoint, col_estado, col_id_tipo_recojo, _
            col_tipo_recojo, col_contacto, col_departamento, col_provincia, _
            col_distrito, col_id_movil, col_id_ruta, col_id_estado, _
            col_peso, col_volumen, col_incidencia, col_parcial, col_observacion, col_producto, col_coordenada, col_tiempo)
        End With
    End Sub

    Sub FormatoDgvRecojoPendiente()
        With DgvRecojoPendiente
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 6.8!, FontStyle.Regular)
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Black

            Dim col_seleccion As New DataGridViewCheckBoxColumn
            With col_seleccion
                .HeaderText = "Sel."
                .Name = "sel"
                '.DataPropertyName = "id_persona"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 35
                .SortMode = DataGridViewColumnSortMode.Automatic
                .FalseValue = 0
                .TrueValue = 1
            End With

            Dim col_id_persona As New DataGridViewTextBoxColumn
            With col_id_persona
                .HeaderText = "id cliente"
                .Name = "id_persona"
                .DataPropertyName = "id_persona"
                .Visible = False
            End With

            Dim col_cliente As New DataGridViewTextBoxColumn
            With col_cliente
                .HeaderText = "Cliente"
                .Name = "cliente"
                .DataPropertyName = "cliente"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 300
            End With

            Dim col_id_direccion As New DataGridViewTextBoxColumn
            With col_id_direccion
                .HeaderText = "id direccion"
                .Name = "id_direccion"
                .DataPropertyName = "id_direccion"
                .Visible = False
            End With

            Dim col_direccion As New DataGridViewTextBoxColumn
            With col_direccion
                .HeaderText = "Dirección"
                .Name = "direccion"
                .DataPropertyName = "direccion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_hora_listo As New DataGridViewTextBoxColumn
            With col_hora_listo
                .HeaderText = "Hora Listo"
                .Name = "hora_listo"
                .DataPropertyName = "hora_listo"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 54
            End With

            Dim col_hora_cierre As New DataGridViewTextBoxColumn
            With col_hora_cierre
                .HeaderText = "Hora Cierre"
                .Name = "hora_cierre"
                .DataPropertyName = "hora_cierre"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 54
            End With

            Dim col_id_checkpoint As New DataGridViewTextBoxColumn
            With col_id_checkpoint
                .HeaderText = "id checkpoint"
                .Name = "id_checkpoint"
                .DataPropertyName = "id_checkpoint"
                .Visible = False
            End With

            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .HeaderText = "Estado"
                .Name = "estado"
                .DataPropertyName = "estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_id_tipo_recojo As New DataGridViewTextBoxColumn
            With col_id_tipo_recojo
                .HeaderText = "id tipo recojo"
                .Name = "id_tipo_recojo"
                .DataPropertyName = "id_tipo_recojo"
                .Visible = False
            End With

            Dim col_tipo_recojo As New DataGridViewTextBoxColumn
            With col_tipo_recojo
                .HeaderText = "Tipo Recojo"
                .Name = ""
                .DataPropertyName = "tipo_recojo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 58
            End With

            Dim col_contacto As New DataGridViewTextBoxColumn
            With col_contacto
                .HeaderText = "Contacto"
                .Name = "contacto"
                .DataPropertyName = "contacto"
                .Visible = False
            End With

            Dim col_id_tipo_cliente As New DataGridViewTextBoxColumn
            With col_id_tipo_cliente
                .HeaderText = "id tipo cliente"
                .Name = "id_tipo_cliente"
                .DataPropertyName = "id_tipo_cliente"
                .Visible = False
            End With

            'hlamas 08-01-2019
            'Dim col_tipo_ruta As New DataGridViewTextBoxColumn
            'With col_tipo_ruta
            '    .HeaderText = "Tipo Ruta"
            '    .Name = "tipo_ruta"
            '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            '    .SortMode = DataGridViewColumnSortMode.Automatic
            '    .DataPropertyName = "tipo_ruta"
            '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '    .ReadOnly = True
            'End With

            Dim col_ruta As New DataGridViewComboBoxColumn
            With col_ruta
                .HeaderText = "Ruta"
                .Name = "ruta"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DataPropertyName = "id_ruta_unidad_transporte"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DisplayStyleForCurrentCellOnly = True

                Dim obj As New DtoRecojo
                obj.Fecha = Me.DtpFecha.Text
                obj.Ciudad = dtoUSUARIOS.m_idciudad
                dsRuta = obj.ListarRuta(1)
                .DataSource = dsRuta.Tables(0)
                .DisplayMember = "ruta"
                .ValueMember = "id_ruta_unidad_transporte"
                .Width = 150
            End With

            Dim col_id_recojo As New DataGridViewTextBoxColumn
            With col_id_recojo
                .HeaderText = "Nº"
                .Name = "id_recojo"
                .DataPropertyName = "id_recojo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            End With

            Dim col_departamento As New DataGridViewTextBoxColumn
            With col_departamento
                .HeaderText = "departamento"
                .Name = "departamento"
                .DataPropertyName = "departamento"
                .Visible = False
            End With

            Dim col_provincia As New DataGridViewTextBoxColumn
            With col_provincia
                .HeaderText = "provincia"
                .Name = "provincia"
                .DataPropertyName = "provincia"
                .Visible = False
            End With

            Dim col_distrito As New DataGridViewTextBoxColumn
            With col_distrito
                .HeaderText = "distrito"
                .Name = "distrito"
                .DataPropertyName = "distrito"
                .Visible = False
            End With

            Dim col_movil As New DataGridViewTextBoxColumn
            With col_movil
                .HeaderText = "Móvil"
                .Name = "movil"
                .DataPropertyName = "movil"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_id_movil As New DataGridViewTextBoxColumn
            With col_id_movil
                .HeaderText = "id movil"
                .Name = "id_movil"
                .DataPropertyName = "id_movil"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Visible = False
            End With

            Dim col_id_ruta As New DataGridViewTextBoxColumn
            With col_id_ruta
                .HeaderText = "id_ruta"
                .Name = "id_ruta"
                .DataPropertyName = "id_ruta"
                .Visible = False
            End With

            Dim col_chofer As New DataGridViewTextBoxColumn
            With col_chofer
                .HeaderText = "Chofer"
                .Name = "chofer"
                .DataPropertyName = "chofer"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
            End With

            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .HeaderText = "id_estado"
                .Name = "id_estado"
                .DataPropertyName = "id_estado"
                .Visible = False
            End With

            Dim col_peso As New DataGridViewTextBoxColumn
            With col_peso
                .HeaderText = "Peso"
                .Name = "peso"
                .DataPropertyName = "peso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Format = "#,###,###,###0.00"
            End With

            Dim col_volumen As New DataGridViewTextBoxColumn
            With col_volumen
                .HeaderText = "Volumen"
                .Name = "volumen"
                .DataPropertyName = "volumen"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .DefaultCellStyle.Format = "#,###,###,###0.00"
            End With

            Dim col_parcial As New DataGridViewTextBoxColumn
            With col_parcial
                .HeaderText = "Parcial"
                .Name = "parcial"
                .DataPropertyName = "parcial"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .Width = 56
            End With

            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .HeaderText = "Observación"
                .Name = "observacion"
                .DataPropertyName = "observacion"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            Dim col_tiempo As New DataGridViewTextBoxColumn
            With col_tiempo
                .HeaderText = "tiempo"
                .Name = "tiempo"
                .DataPropertyName = "tiempo"
                .Visible = False
            End With

            Dim col_destino As New DataGridViewTextBoxColumn
            With col_destino
                .HeaderText = "Destino"
                .Name = "destino"
                .DataPropertyName = "destino"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .ReadOnly = True
                .SortMode = DataGridViewColumnSortMode.Automatic
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            'hlamas 08-01-2019
            '.Columns.AddRange(col_seleccion, col_id_recojo, col_id_persona, col_cliente, col_id_direccion, col_direccion, _
            'col_hora_listo, col_hora_cierre, col_id_tipo_cliente, col_tipo_ruta, col_ruta, col_movil, col_chofer, col_id_checkpoint, col_estado, col_id_tipo_recojo, _
            'col_tipo_recojo, col_contacto, col_departamento, col_provincia, _
            'col_distrito, col_id_movil, col_id_ruta_unidad_transporte, col_id_estado, _
            'col_peso, col_volumen, col_parcial, col_observacion)
            .Columns.AddRange(col_seleccion, col_id_recojo, col_id_persona, col_cliente, col_id_direccion, col_direccion, _
            col_hora_listo, col_hora_cierre, col_id_tipo_cliente, col_ruta, col_movil, col_chofer, col_id_checkpoint, col_estado, col_id_tipo_recojo, _
            col_tipo_recojo, col_contacto, col_departamento, col_provincia, _
            col_distrito, col_id_movil, col_id_ruta, col_id_estado, _
            col_peso, col_volumen, col_parcial, col_observacion, col_tiempo, col_destino)
        End With
    End Sub
#End Region

#Region "Procedimiento"
    Public Sub ActualizacionesBackground()
        Dim w As WaitHandle = mre
        While True
            w.WaitOne()
            If Me.IsHandleCreated Then
                Me.BeginInvoke(CallFuncionGenerar)
            End If
            Thread.Sleep(15000)
        End While
    End Sub

    Public Sub ActualizacionesBackground2()
        Dim w As WaitHandle = mre2
        While True
            w.WaitOne()
            If Me.IsHandleCreated Then
                Me.BeginInvoke(CallFuncionGenerar2)
            End If
            Thread.Sleep(15000)
        End While
    End Sub

    Private Sub DgvRecojo_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvRecojo.CellEndEdit
        mre.Set()
        tiempo.Enabled = False
        If combo IsNot Nothing Then
            RemoveHandler combo.SelectedIndexChanged, New EventHandler(AddressOf SelectedIndexChanged)
            iEntra2 = 0
        End If
    End Sub
    Private Sub DgvRecojo_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvRecojo.RowValidated
        Try
            If Me.DgvRecojo.Rows.Count > 0 Then
                If Me.CboEstado.SelectedValue = 0 Then
                    Dim iEstado As Integer = 0
                    For Each row As DataGridViewRow In Me.DgvRecojo.Rows
                        If CType(row.Cells(0).Value, Boolean) Then
                            iEstado = row.Cells("id_estado").Value
                            Exit For
                        End If
                    Next
                    Me.ActivarDesactivar(iEstado)
                Else
                    Me.ActivarDesactivar(Me.CboEstado.SelectedValue)
                End If
            End If

            Dim sfecha As String = FechaServidor()
            SeleccionaRecojoFueraHora()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Function Actualizar(ByVal fecha As String, Optional ByVal opcion As Integer = 0) As String
        Dim obj As New DtoRecojo
        Try
            obj.Fecha = fecha
            obj.Usuario = dtoUSUARIOS.IdLogin
            obj.Ip = dtoUSUARIOS.IP '"192.168.50.52"
            Dim sFechaHora As String = obj.ActualizarRuta
            Return sFechaHora
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            obj = Nothing
        End Try
    End Function

    Function CargarRecojo(ByVal fecha As String, ByVal tipo As Integer, ByVal estado As Integer, ByVal ruta As Integer, ByVal situacion As Integer, ByVal dgv As DataGridView, Optional ByVal opcion As Integer = 0, Optional ByVal tiporuta As Integer = 0) As DataTable
        Try
            Dim obj As New DtoRecojo
            obj.Fecha = fecha
            obj.Tiporecojo = tipo
            obj.Estado = estado
            obj.Ruta = ruta
            obj.Situacion = situacion
            obj.Ciudad = dtoUSUARIOS.m_idciudad
            Dim ds As DataSet = obj.ListarRecojo(opcion, tiporuta)
            blnTodoOk = False
            If ds.Tables(0).Rows.Count > 0 Then
                dgv.DataSource = ds.Tables(0).DefaultView
                blnTodoOk = True
            Else
                dgv.DataSource = Nothing
            End If
            SeleccionaRecojoFueraHora()
            Return ds.Tables(1)

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
#End Region

    Private Sub DgvRecojo_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvRecojo.CurrentCellDirtyStateChanged
        DgvRecojo.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DgvRecojo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DgvRecojo.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If DgvRecojo.Rows.Count > 0 And Me.CboEstado.SelectedValue > 0 And Me.CboEstado.SelectedValue <> RECOJO.ATENDIDO And Me.CboEstado.SelectedValue <> RECOJO.CANCELADO Then
                'Me.Cursor = Cursors.AppStarting
                ContextMenuStrip1.Show(sender, e.X, e.Y)
                'Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub FrmAsignacionRecojo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'tiempo.Enabled = False
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmAsignacionRecojo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'th = Nothing 'Vacia el hilo.
        'th2 = Nothing

        nuestroThread = Nothing
        nuestroThread2 = Nothing
        nuestroThreadStart = Nothing
        nuestroThreadStart2 = Nothing
        GC.Collect()
    End Sub

    'Protected Overrides ReadOnly Property CreateParams As CreateParams
    '    Get
    '        Dim cp As New CreateParams
    '        cp.ExStyle = cp.ExStyle Or &H2000000
    '        Return cp
    '    End Get
    'End Property

    Private Sub FrmAsignacionRecojo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            bInicio = True
            Me.CheckForIllegalCrossThreadCalls = False
            Try
                mre = New ManualResetEvent(True)
                nuestroThread = New Thread(nuestroThreadStart)
                nuestroThread.IsBackground = True
                nuestroThread.Name = "nuestroThread"
                nuestroThread.Start()
            Catch ex As Exception
            End Try

            Try
                mre2 = New ManualResetEvent(True)
                nuestroThread2 = New Thread(nuestroThreadStart2)
                nuestroThread2.IsBackground = True
                nuestroThread2.Name = "nuestroThread2"
                nuestroThread2.Start()
            Catch ex As Exception
            End Try

            'dFechaHora = DtpFecha.Value
            InicioRecojo()
            bInicio = False

            sFechaHora = Me.DtpFecha.Text
            'dFechaHora = dFechaHora.Substring(0, 20) & IIf(dFechaHora.Substring(20, 1).ToUpper = "A", "am", "pm")

            Me.FormatoDgvRecojo()
            Me.FormatoDgvRecojoPendiente()

            'hlamas 08-01-2019
            'Me.CargarRecojo(Me.DtpFecha.Text, Me.CboTipoRecojo.SelectedIndex + 1, Me.CboEstado.SelectedValue, Me.CboRuta.SelectedValue, Me.DgvRecojo, Me.CboTipoRuta.SelectedValue)
            Me.CargarRecojo(Me.DtpFecha.Text, Me.CboTipoRecojo.SelectedIndex, Me.CboEstado.SelectedValue, Me.CboRuta.SelectedValue, Me.cboSituacion.SelectedIndex, Me.DgvRecojo)

            Dim sFechaServidor As String = Me.Actualizar(Me.DtpFecha.Text)
            Me.CargarRecojo(sFechaHora, 0, 1, 0, 0, Me.DgvRecojoPendiente, 1)

            'tiempo.Interval = 1
            'tiempo.Enabled = True

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MnuContextSelTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuContextSelTodo.Click
        Try
            Dim obj As New DtoRecojo
            SeleccionarCheckDgv(Me.DgvRecojo, 0, 1)
            Me.ActivarDesactivar(Me.CboEstado.SelectedValue)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MnuContextSelEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuContextSelEliminar.Click
        Try
            SeleccionarCheckDgv(Me.DgvRecojo, 0, 0)
            Me.ActivarDesactivar(Me.CboEstado.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub CopiarGrid(ByVal dgv As DataGridView)
        Dim i As Integer = 0
        For Each row As DataGridViewRow In dgv.Rows
            i += 1
            aLista(i).check = row.Cells(0).Value
            aLista(i).recojo = row.Cells("id_recojo").Value
            aLista(i).old = 1
            aLista(i).estado = row.Cells("id_checkpoint").Value
        Next
    End Sub

    Function ActualizarProgramacion(ByVal programacion As Integer, ByVal fecha As String, ByVal ruta As Integer, ByVal recojo As Integer) As DataTable
        Try
            Dim obj As New DtoRecojo
            obj.Usuario = dtoUSUARIOS.IdLogin
            obj.Ip = dtoUSUARIOS.IP '"192.168.50.52"
            Return obj.ActualizarProgramacion(programacion, fecha, ruta, recojo)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Sub ToolSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolSalir.Click
        Me.Close()
    End Sub

    Function ExisteCheck(ByVal dgv As DataGridView) As Boolean
        For Each row As DataGridViewRow In dgv.Rows
            If Not IsNothing(row.Cells(0).Value) Then
                If row.Cells(0).Value = 1 Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Function NumeroCheck(ByVal dgv As DataGridView, ByVal estado As Integer) As Integer
        Dim i As Integer = 0
        For Each row As DataGridViewRow In dgv.Rows
            If Not IsNothing(row.Cells(0).Value) Then
                If Not (estado = 2 And IsDBNull(row.Cells("ruta").Value)) Then
                    If row.Cells(0).Value = 1 Then
                        i += 1
                    End If
                End If
            End If
        Next
        Return i
    End Function

    Private Sub DgvRecojo_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvRecojo.CellContentClick
        If e.ColumnIndex <> 0 Then Return
        If IsDBNull(Me.DgvRecojo.Rows(e.RowIndex).Cells("ruta").Value) Or Me.DgvRecojo.Rows(e.RowIndex).Cells("ruta").Value = 0 Then
            MessageBox.Show("Seleccione una Ruta", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DgvRecojo.Rows(e.RowIndex).Cells(0).Value = 0
            Me.DgvRecojo.RefreshEdit()
            Me.DgvRecojo.CurrentCell = Me.DgvRecojo.Rows(e.RowIndex).Cells("ruta")
            Return
        End If

        Try
            Dim iEstado As Integer
            If IsDBNull(DgvRecojo.Rows(e.RowIndex).Cells(0).Value) Then
                iEstado = 2
            Else
                iEstado = DgvRecojo.Rows(e.RowIndex).Cells(0).Value
            End If

            If Me.CboEstado.SelectedValue = 0 Or Me.CboEstado.SelectedValue = RECOJO.ATENDIDO Then
                MnuContextSelEliminar_Click(sender, e)
            End If

            SeleccionarCheckDgv(CType(sender, DataGridView).CurrentRow, 0, iEstado)
            DgvRecojo_RowValidated(sender, e)

            'If iEstado = 1 Then
            '    tiempo3.Enabled = False
            'Else
            '    tiempo3.Enabled = True
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolAprobar.Click
        Try
            Dim iNum As Integer = Me.NumeroCheck(Me.DgvRecojo, RECOJO.APROBADO)
            Dim frm As New FrmEstadoRecojo
            frm.iNum = iNum
            frm.iEstado = RECOJO.APROBADO
            frm.Text = "Aprobar"
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.Yes Then
                'Me.Cursor = Cursors.AppStarting
                CambiarEstado(Me.DgvRecojo, RECOJO.APROBADO, frm.TxtObservacion.Text.Trim)
                MessageBox.Show(IIf(iNum = 1, "Recojo", "Recojos") & IIf(iNum = 1, " Aprobado", " Aprobados"), "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                BtnBuscar_Click(sender, e)
                'Me.Cursor = Cursors.Default
            End If

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function CambiarEstado(ByVal dgv As DataGridView, ByVal estado As Integer, ByVal observacion As String) As Boolean
        Try
            Dim obj As New DtoRecojo
            Dim blnProcesar As Boolean
            Dim blnGrabo As Boolean = False
            For Each row As DataGridViewRow In dgv.Rows
                If Not IsNothing(row.Cells(0).Value) Then
                    If row.Cells(0).Value = 1 Then
                        blnProcesar = True
                        'If Not ((estado = RECOJO.APROBADO Or estado = RECOJO.ENCURSO) And IsDBNull(row.Cells("ruta").Value)) Then
                        If estado = RECOJO.APROBADO Or estado = RECOJO.ENCURSO Then
                            If IsDBNull(row.Cells("ruta").Value) Or row.Cells("ruta").Value = 0 Then
                                blnProcesar = False
                            End If
                        End If
                        If blnProcesar Then
                            obj.Recojo = row.Cells("id_recojo").Value
                            obj.Observacion = observacion
                            obj.Estado = estado
                            obj.Usuario = dtoUSUARIOS.IdLogin
                            obj.Ip = dtoUSUARIOS.IP '"192.168.50.52"
                            obj.CambiarEstado()
                            blnGrabo = True
                        End If
                    End If
                End If
            Next
            Return blnGrabo
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function


    Private Sub DgvRecojoPendiente_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvRecojoPendiente.CellContentClick
        If e.ColumnIndex <> 0 Then Return
        'If Me.DgvRecojoPendiente.Rows(e.RowIndex).Cells("ruta").Value = 0 Then
        '    MessageBox.Show("Seleccione una Ruta", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Me.DgvRecojoPendiente.Rows(e.RowIndex).Cells(0).Value = 0
        '    Me.DgvRecojoPendiente.RefreshEdit()
        '    Me.DgvRecojoPendiente.CurrentCell = Me.DgvRecojoPendiente.Rows(e.RowIndex).Cells("ruta")
        '    Return
        'End If
        Try
            Dim iEstado As Integer
            If IsDBNull(DgvRecojoPendiente.Rows(e.RowIndex).Cells(0).Value) Then
                iEstado = 2
            Else
                iEstado = DgvRecojoPendiente.Rows(e.RowIndex).Cells(0).Value
            End If

            SeleccionarCheckDgv(CType(sender, DataGridView).CurrentRow, 0, iEstado)
            'DgvRecojo_RowValidated(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DgvRecojoPendiente_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvRecojoPendiente.CellEndEdit
        mre2.Set()
        Tiempo2.Enabled = False
        If comboPendiente IsNot Nothing Then
            RemoveHandler comboPendiente.SelectedValueChanged, New EventHandler(AddressOf SelectedValueChanged)
            iEntra2 = 0
        End If
    End Sub

    Private Sub DgvRecojoPendiente_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvRecojoPendiente.CurrentCellDirtyStateChanged
        DgvRecojoPendiente.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Function RecojoRuta(ByVal dgv As DataGridView) As Boolean
        For Each row As DataGridViewRow In dgv.Rows
            If Not IsNothing(row.Cells(0).Value) Then
                If row.Cells(0).Value = 1 AndAlso Not (IsDBNull(row.Cells("ruta").Value)) Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Private Sub DgvRecojoPendiente_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DgvRecojoPendiente.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If DgvRecojoPendiente.Rows.Count = 0 Or Not Me.ExisteCheck(DgvRecojoPendiente) Then
                Me.ContextMenuStrip2.Items(0).Visible = False
                Me.ContextMenuStrip2.Items(1).Visible = False
                Me.ContextMenuStrip2.Items(2).Visible = False
                Me.ContextMenuStrip2.Items(3).Visible = False
                If DgvRecojoPendiente.Rows.Count = 0 Then
                    Me.ContextMenuStrip2.Items(4).Visible = False
                    Me.ContextMenuStrip2.Items(5).Visible = False
                Else
                    Me.ContextMenuStrip2.Items(4).Visible = True
                    Me.ContextMenuStrip2.Items(5).Visible = True
                End If
            Else
                'If IsDBNull(Me.DgvRecojoPendiente.CurrentRow.Cells("ruta").Value) Then
                If Not Me.RecojoRuta(Me.DgvRecojoPendiente) Then
                    Me.ContextMenuStrip2.Items(0).Visible = False
                    Me.ContextMenuStrip2.Items(1).Visible = False
                Else
                    Me.ContextMenuStrip2.Items(0).Visible = True
                    'Me.ContextMenuStrip2.Items(1).Visible = True
                    Me.ContextMenuStrip2.Items(2).Visible = True
                    Me.ContextMenuStrip2.Items(3).Visible = True
                End If
            End If

            'Me.Cursor = Cursors.AppStarting
            ContextMenuStrip2.Show(sender, e.X, e.Y)
            'Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub AprobarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AprobarToolStripMenuItem.Click
        Try
            Dim iNum As Integer = Me.NumeroCheck(Me.DgvRecojoPendiente, RECOJO.APROBADO)
            Dim frm As New FrmEstadoRecojo
            frm.iNum = iNum
            frm.iEstado = RECOJO.APROBADO
            frm.Text = "Aprobar"
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.Yes Then
                'Me.Cursor = Cursors.AppStarting
                Dim blnCambio As Boolean = CambiarEstado(Me.DgvRecojoPendiente, RECOJO.APROBADO, frm.TxtObservacion.Text.Trim)
                If blnCambio Then
                    MessageBox.Show(IIf(iNum = 1, "Recojo", "Recojos") & IIf(iNum = 1, " Aprobado", " Aprobados"), "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.CargarRecojo(Me.DtpFecha.Text, 0, 1, 0, 0, Me.DgvRecojoPendiente, 1)
                    BtnBuscar_Click(sender, e)
                Else
                    MessageBox.Show(IIf(iNum = 1, "El Recojo", "Los Recojos") & IIf(iNum = 1, " no fue Aprobado", " no fueron Aprobados"), "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                'Me.Cursor = Cursors.Default
            End If
            'tiempo.Enabled = True

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub CancelarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelarToolStripMenuItem.Click
        Try
            Dim iNum As Integer = Me.NumeroCheck(Me.DgvRecojoPendiente, RECOJO.CANCELADO)
            Dim frm As New FrmEstadoRecojo
            frm.iNum = iNum
            frm.iEstado = RECOJO.CANCELADO
            frm.Text = "Cancelar"
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.Yes Then
                'Me.Cursor = Cursors.AppStarting
                Dim blnCambio As Boolean = CambiarEstado(Me.DgvRecojoPendiente, RECOJO.CANCELADO, frm.TxtObservacion.Text.Trim)
                If blnCambio Then
                    MessageBox.Show(IIf(iNum = 1, "Recojo", "Recojos") & IIf(iNum = 1, " Cancelado", " Cancelados"), "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.CargarRecojo(Me.DtpFecha.Text, 0, 1, 0, 0, Me.DgvRecojoPendiente, 1)
                    BtnBuscar_Click(sender, e)
                Else
                    MessageBox.Show(IIf(iNum = 1, "El Recojo", "Los Recojos") & IIf(iNum = 1, " no fue Cancelado", " no fueron Cancelados"), "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
            'tiempo.Enabled = True

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Try
            Me.Cursor = Cursors.AppStarting
            BuscarRecojo()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BuscarRecojo()
        Dim iCol As Integer, iFil As Integer
        If DgvRecojo.Rows.Count > 0 Then
            DgvRecojo.Rows(0).Selected = True
            iCol = DgvRecojo.CurrentCell.ColumnIndex
            iFil = DgvRecojo.CurrentCell.RowIndex

            ReDim aLista(DgvRecojo.Rows.Count)
            CopiarGrid(Me.DgvRecojo)
        End If

        'hlamas 08-01-2019
        'Me.CargarRecojo(Me.DtpFecha.Text, Me.CboTipoRecojo.SelectedIndex, Me.CboEstado.SelectedValue, Me.CboRuta.SelectedValue, Me.DgvRecojo, 0, Me.CboTipoRuta.SelectedValue)
        Me.CargarRecojo(Me.DtpFecha.Text, Me.CboTipoRecojo.SelectedIndex, Me.CboEstado.SelectedValue, Me.CboRuta.SelectedValue, Me.cboSituacion.SelectedIndex, Me.DgvRecojo, 0)

        If DgvRecojo.Rows.Count > 0 Then
            ActualizarGrid(Me.DgvRecojo)
            If iFil < DgvRecojo.Rows.Count Then
                DgvRecojo.CurrentCell = DgvRecojo(iCol, iFil)
            Else
                iFil = DgvRecojo.Rows.Count - 1
                DgvRecojo.CurrentCell = DgvRecojo(iCol, iFil)
            End If
        End If
        'MsgBox("")

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFecha.ValueChanged
        If bInicio Then Return
        sFechaVigente = Me.DtpFecha.Text
        Me.DgvRecojo.DataSource = Nothing
        Me.DgvRecojoPendiente.DataSource = Nothing
        FormatoDgvRecojo()
        FormatoDgvRecojoPendiente()
        Me.BtnBuscar_Click(sender, e)
    End Sub

    Private Sub CboTipoRecojo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoRecojo.SelectedIndexChanged
        If bInicio Then Return
        Me.BtnBuscar_Click(sender, e)
    End Sub

    Private Sub CboRuta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboRuta.SelectedIndexChanged, cboSituacion.SelectedIndexChanged
        If bInicio Then Return
        Me.BtnBuscar_Click(sender, e)
    End Sub

    Private Sub ToolCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCancelar.Click
        Try
            Dim iNum As Integer = Me.NumeroCheck(Me.DgvRecojo, RECOJO.CANCELADO)
            Dim frm As New FrmEstadoRecojo
            frm.iNum = iNum
            frm.iEstado = RECOJO.CANCELADO
            frm.Text = "Cancelar"
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.Yes Then
                'Me.Cursor = Cursors.AppStarting
                Dim blnCambio As Boolean = CambiarEstado(Me.DgvRecojo, RECOJO.CANCELADO, frm.TxtObservacion.Text.Trim)
                If blnCambio Then
                    MessageBox.Show(IIf(iNum = 1, "Recojo", "Recojos") & IIf(iNum = 1, " Cancelado", " Cancelados"), "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    BtnBuscar_Click(sender, e)
                    Me.ActivarDesactivar(Me.CboEstado.SelectedValue)
                Else
                    MessageBox.Show(IIf(iNum = 1, "El Recojo", "Los Recojos") & IIf(iNum = 1, " no fue Cancelado", " no fueron Cancelados"), "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                'Me.Cursor = Cursors.Default
            End If

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SeleccionarTodoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeleccionarTodoToolStripMenuItem.Click
        Try
            Dim obj As New DtoRecojo
            SeleccionarCheckDgv(Me.DgvRecojoPendiente, 0, 1)
            Me.ActivarDesactivar(Me.CboEstado.SelectedValue)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EliminarSelecciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarSelecciónToolStripMenuItem.Click
        Try
            SeleccionarCheckDgv(Me.DgvRecojoPendiente, 0, 0)
            Me.ActivarDesactivar(Me.CboEstado.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DgvRecojoPendiente_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DgvRecojoPendiente.RowsRemoved
        Me.LblNumero2.Text = Me.DgvRecojoPendiente.Rows.Count
    End Sub

    Private Sub DgvRecojoPendiente_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DgvRecojoPendiente.RowsAdded
        'If blnTodoOk = True Then
        Me.LblNumero2.Text = Me.DgvRecojoPendiente.Rows.Count
        'End If
    End Sub

    Private Sub DgvRecojo_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DgvRecojo.RowsAdded
        Me.LblNumero1.Text = Me.DgvRecojo.Rows.Count
    End Sub

    Private Sub DgvRecojo_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DgvRecojo.RowsRemoved
        Me.LblNumero1.Text = Me.DgvRecojo.Rows.Count
    End Sub

    Function Registros(ByVal dgv As DataGridView, ByRef lista() As Integer, Optional ByVal estado As Boolean = True) As Integer
        Dim i As Integer = 0
        For Each row As DataGridViewRow In dgv.Rows
            If CType(row.Cells(0).Value, Boolean) = estado Then
                If row.Cells("ruta").Value > 0 Then
                    i += 1
                    ReDim Preserve lista(i)
                    lista(i) = row.Cells("id_recojo").Value
                End If
            End If
        Next
        Return i
    End Function

    Function Registros(ByVal dgv As DataGridView, Optional ByVal estado As Boolean = True) As Integer
        Dim i As Integer = 0
        For Each row As DataGridViewRow In dgv.Rows
            If CType(row.Cells(0).Value, Boolean) = estado Then
                If Not (IsDBNull(row.Cells("ruta").Value) Or row.Cells("ruta").Value = 0) Then
                    i += 1
                    ReDim Preserve aRecojo(i)
                    aRecojo(i).recojo = row.Cells("id_recojo").Value
                    aRecojo(i).ruta = row.Cells("ruta").Value
                    aRecojo(i).tipo = row.Cells("id_tipo_cliente").Value
                End If
            End If
        Next
        Return i
    End Function

    Function TipoDiferente(ByVal dgv As DataGridView, Optional ByVal estado As Boolean = True) As Boolean
        Dim bTipoDiferente As Boolean = False
        Dim iTipo As Integer = 0
        For Each row As DataGridViewRow In dgv.Rows
            If CType(row.Cells(0).Value, Boolean) = estado Then
                If Not IsDBNull(row.Cells("ruta").Value) And iTipo > 0 Then
                    If iTipo <> row.Cells("id_tipo_cliente").Value Then
                        bTipoDiferente = True
                        Exit For
                    End If
                End If
                iTipo = row.Cells("id_tipo_cliente").Value
            End If
        Next
        Return bTipoDiferente
    End Function

    Private Sub ReprogramarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReprogramarToolStripMenuItem.Click
        Try
            Dim bCambio As Boolean = False
            With Me.DgvRecojoPendiente
                Dim j As Integer
                ReDim aRecojo(0)
                Dim i As Integer = Me.Registros(Me.DgvRecojoPendiente)
                For Each row As DataGridViewRow In .Rows
                    If CType(row.Cells(0).Value, Boolean) And Not (IsDBNull(row.Cells("ruta").Value)) Then
                        j += 1
                        Dim frm As New FrmRecojoReprogramado
                        frm.Inicio(i, j)
                        frm.iRecojo = row.Cells("id_recojo").Value
                        frm.iTipo = row.Cells("id_tipo_cliente").Value
                        frm.sFecha = Me.DtpFecha.Text
                        frm.sHoraInicio = row.Cells("hora_listo").Value 'row.Cells("hora_listo").Value.ToString.Substring(0, 5) & IIf(row.Cells("hora_listo").Value.ToString.Substring(6, 1).ToUpper = "A", " am", " pm")
                        frm.sHoraFin = row.Cells("hora_cierre").Value 'row.Cells("hora_cierre").Value.ToString.Substring(0, 5) & IIf(row.Cells("hora_cierre").Value.ToString.Substring(6, 1).ToUpper = "A", " am", " pm")
                        frm.sCliente = row.Cells("cliente").Value
                        frm.sDireccion = row.Cells("direccion").Value
                        frm.iRuta = row.Cells("ruta").Value
                        If TipoDiferente(Me.DgvRecojoPendiente) Then
                            frm.BtnSiaTodo.Enabled = False
                        End If
                        frm.ShowDialog()
                        If frm.bCambio Then
                            bCambio = frm.bCambio
                        End If
                        If frm.DialogResult = Windows.Forms.DialogResult.Cancel Then
                            Return
                        ElseIf frm.DialogResult = Windows.Forms.DialogResult.OK Then
                            Exit For
                        End If
                    End If
                Next
                If bCambio Then
                    Me.CargarRecojo(Me.DtpFecha.Text, 0, 1, 0, 0, Me.DgvRecojoPendiente, 1)
                    Me.ActivarDesactivar(Me.CboEstado.SelectedValue)
                End If
                'tiempo.Enabled = True

            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ToolReprogramar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReprogramar.Click
        Try
            Dim bCambio As Boolean = False
            With Me.DgvRecojo
                Dim j As Integer
                ReDim aRecojo(0)
                Dim i As Integer = Me.Registros(Me.DgvRecojo)
                For Each row As DataGridViewRow In .Rows
                    If CType(row.Cells(0).Value, Boolean) Then
                        j += 1
                        Dim frm As New FrmRecojoReprogramado
                        frm.Inicio(i, j)
                        frm.iRecojo = row.Cells("id_recojo").Value
                        frm.iTipo = row.Cells("id_tipo_cliente").Value
                        frm.sFecha = Me.DtpFecha.Text
                        frm.sHoraInicio = row.Cells("hora_listo").Value 'row.Cells("hora_listo").Value.ToString.Substring(0, 5) & IIf(row.Cells("hora_listo").Value.ToString.Substring(6, 1).ToUpper = "A", " am", " pm")
                        frm.sHoraFin = row.Cells("hora_cierre").Value 'row.Cells("hora_cierre").Value.ToString.Substring(0, 5) & IIf(row.Cells("hora_cierre").Value.ToString.Substring(6, 1).ToUpper = "A", " am", " pm")
                        frm.sCliente = row.Cells("cliente").Value
                        frm.sDireccion = row.Cells("direccion").Value
                        frm.iRuta = row.Cells("ruta").Value
                        If TipoDiferente(Me.DgvRecojo) Then
                            frm.BtnSiaTodo.Enabled = False
                        End If
                        frm.ShowDialog()
                        If frm.bCambio Then
                            bCambio = frm.bCambio
                        End If
                        If frm.DialogResult = Windows.Forms.DialogResult.Cancel Then
                            Return
                        ElseIf frm.DialogResult = Windows.Forms.DialogResult.OK Then
                            Exit For
                        End If
                    End If
                Next
                If bCambio Then
                    BtnBuscar_Click(sender, e)
                    Me.ActivarDesactivar(Me.CboEstado.SelectedValue)
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ActivarDesactivar(ByVal estado As Integer)
        Me.ToolAprobar.Enabled = False
        Me.ToolCancelar.Enabled = False
        Me.ToolReprogramar.Enabled = False
        Me.ToolCancelar.Enabled = False
        Me.ToolAsociar.Enabled = False
        Me.ToolAtender.Enabled = False
        Me.ToolLlegada.Enabled = False

        Select Case estado
            Case RECOJO.PENDIENTE
                If Me.ExisteCheck(Me.DgvRecojo) Then
                    Me.ToolAprobar.Enabled = True
                    Me.ToolCancelar.Enabled = True
                End If
            Case RECOJO.APROBADO
                If Me.ExisteCheck(Me.DgvRecojo) Then
                    Me.ToolReprogramar.Enabled = True
                    Me.ToolCancelar.Enabled = True
                    Me.ToolLlegada.Enabled = True
                End If
            Case RECOJO.ENCURSO
                If Me.ExisteCheck(Me.DgvRecojo) Then
                    Me.ToolAtender.Enabled = True
                End If
                'Case RECOJO.ATENDIDO
                '    If Me.ExisteCheck(Me.DgvRecojo) Then
                '        Me.ToolAsociar.Enabled = True
                '    End If
                'Case RECOJO.COMPLETADO
                '    If Me.ExisteCheck(Me.DgvRecojo) Then
                '        Me.ToolAsociar.Enabled = True
                '    End If

        End Select
    End Sub

    Private Sub ToolAtender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolAtender.Click
        Dim bCambio As Boolean = False
        Dim frm As New FrmAtender
        With Me.DgvRecojo
            Dim j, lista(0) As Integer
            Dim i As Integer = Me.Registros(Me.DgvRecojo, lista)
            For Each row As DataGridViewRow In Me.DgvRecojo.Rows
                If CType(row.Cells(0).Value, Boolean) Then
                    j += 1
                    frm.Inicio(row.Cells("id_recojo").Value, row.Cells("id_persona").Value, row.Cells("cliente").Value, row.Cells("contacto").Value, _
                    row.Cells("direccion").Value, row.Cells("producto").Value, lista, i, j)
                    frm.ShowDialog()
                    If frm.DialogResult = Windows.Forms.DialogResult.Cancel Then
                        Return
                    ElseIf frm.DialogResult = Windows.Forms.DialogResult.OK Then
                        If frm.bCambio Then
                            bCambio = frm.bCambio
                        End If
                        Exit For
                    End If
                    If frm.bCambio Then
                        bCambio = frm.bCambio
                    End If
                End If
            Next
            If bCambio Then
                BtnBuscar_Click(sender, e)
                Me.ActivarDesactivar(Me.CboEstado.SelectedValue)
            End If
        End With
    End Sub

    'Private Sub ToolAsociar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolAsociar.Click
    '    Dim frm As New FrmRecojoGuiaEnvio
    '    frm.Inicio(Me.DgvRecojo)
    '    frm.ShowDialog()
    '    If frm.bCambio2 Then
    '        BtnBuscar_Click(sender, e)
    '        Me.ActivarDesactivar(Me.CboEstado.SelectedValue)
    '    End If
    'End Sub

    Private Sub Tiempo2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tiempo2.Tick
        mre2.Set()
        Tiempo2.Enabled = False
        'If tiempo.Enabled = False Then
        '    tiempo.Enabled = True
        'End If
        'BtnBuscar_Click(Nothing, Nothing)
    End Sub

    Sub InicioRecojo()
        Me.CboTipoRecojo.Items.Add("(TODO)")
        Me.CboTipoRecojo.Items.Add("POR DEMANDA")
        Me.CboTipoRecojo.Items.Add("PROGRAMADO")
        Me.CboTipoRecojo.SelectedIndex = 0

        Me.cboSituacion.Items.Add("(TODO)")
        Me.cboSituacion.Items.Add("EN TIEMPO")
        Me.cboSituacion.Items.Add("FUERA DE TIEMPO")
        Me.cboSituacion.SelectedIndex = 0

        Dim obj As New DtoRecojo
        obj.Fecha = Me.DtpFecha.Text
        ds = obj.Inicio()

        CboEstado.DataSource = ds.Tables(0)
        CboEstado.ValueMember = "id_checkpoint_recojo"
        CboEstado.DisplayMember = "check_point_recojo"
        CboEstado.SelectedValue = 2

        CboRuta.DataSource = ds.Tables(1)
        CboRuta.ValueMember = "id_ruta_unidad_transporte"
        CboRuta.DisplayMember = "ruta"
        CboRuta.SelectedValue = 0

        'hlamas 08-01-2019
        'CboTipoRuta.DataSource = ds.Tables(2)
        'CboTipoRuta.ValueMember = "idprocesos"
        'CboTipoRuta.DisplayMember = "procesos"
        'CboTipoRuta.SelectedValue = 0
    End Sub

    Private Sub CboEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboEstado.SelectedIndexChanged
        If bInicio Then Return
        Me.BtnBuscar_Click(sender, e)
        EliminarSelecciónToolStripMenuItem_Click(sender, e)
    End Sub

    'hlamas 08-01-2019
    'Private Sub CboTipoRuta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoRuta.SelectedIndexChanged
    '    If bInicio Then Return
    '    If Not IsReference(Me.CboTipoRuta.SelectedValue) Then
    '        ds.Tables(1).DefaultView.RowFilter = "tipo=" & Me.CboTipoRuta.SelectedValue & " or tipo=0"
    '        Me.BtnBuscar_Click(sender, e)
    '    End If
    'End Sub
    Private Sub DgvRecojo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvRecojo.DoubleClick
        Try
            If DgvRecojo.Rows.Count > 0 Then
                If DgvRecojo.CurrentRow.Cells("id_estado").Value = RECOJO.ATENDIDO Or DgvRecojo.CurrentRow.Cells("id_estado").Value = RECOJO.COMPLETADO Then
                    'Me.Cursor = Cursors.AppStarting
                    MnuContextSelEliminar_Click(sender, e)

                    SeleccionarCheckDgv(CType(sender, DataGridView).CurrentRow, 0, 1)
                    Dim ee As DataGridViewCellEventArgs
                    ee = Nothing
                    DgvRecojo_RowValidated(sender, ee)

                    'ToolAsociar_Click(sender, e)
                    'Me.Cursor = Cursors.Default
                End If
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub tiempo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tiempo.Tick
    '    Try
    '        Dim sFechaHora As String = Me.Actualizar(Me.DtpFecha.Text)
    '        Dim iCol, iFil As Integer
    '        If DgvRecojoPendiente.Rows.Count > 0 Then
    '            iCol = DgvRecojoPendiente.CurrentCell.ColumnIndex
    '            iFil = DgvRecojoPendiente.CurrentCell.RowIndex

    '            ReDim aLista(DgvRecojoPendiente.Rows.Count)
    '            CopiarGrid(Me.DgvRecojoPendiente)
    '        End If
    '        Me.CargarRecojo(Me.DtpFecha.Text, 0, 1, 0, Me.DgvRecojoPendiente, 1)

    '        If DgvRecojoPendiente.Rows.Count > 0 Then
    '            If DgvRecojoPendiente.Rows.Count > 0 Then
    '                DgvRecojoPendiente.CurrentCell = DgvRecojoPendiente(iCol, iFil)
    '            End If
    '            Dim s As String = ""
    '            Dim n As Integer
    '            ActualizarGrid(Me.DgvRecojoPendiente, n, s)
    '            If n > 0 Then
    '                Dim frm As New FrmMensaje
    '                Dim cad As String = ""
    '                If n > 0 Then
    '                    cad = "Se " & IIf(n = 1, "ha", "han") & _
    '                    " Registrado " & n & IIf(n = 1, _
    '                    " Recojo", " Recojos") & vbCrLf & s
    '                End If
    '                'If m > 0 Then
    '                '    If n > 0 Then
    '                '        cad &= vbCrLf
    '                '    End If
    '                '    cad &= "Se " & IIf(m = 1, "ha", "han") & _
    '                '    " Cancelado " & m & IIf(m = 1, _
    '                '    " Recojo", " Recojos") & vbCrLf & t
    '                'End If

    '                frm.LblMensaje.Text = cad
    '                frm.Owner = Me
    '                frm.Show()
    '            End If
    '        End If
    '        SeleccionaRecojoFueraHora(sFechaHora)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Sub ActualizarGrid(ByVal dgv As DataGridView)
        Dim iCheck As Integer
        Dim iRecojo As Integer
        Dim iLista As Integer
        Dim bExiste As Boolean

        For Each row As DataGridViewRow In dgv.Rows
            iRecojo = row.Cells("id_recojo").Value
            bExiste = False
            Dim i As Integer
            For i = 1 To aLista.Length - 1
                iLista = aLista(i).recojo
                If iRecojo = iLista Then
                    iCheck = aLista(i).check
                    row.Cells(0).Value = iCheck
                    bExiste = True
                    Exit For
                End If
            Next
        Next
        dgv.RefreshEdit()
    End Sub

    Sub EnviarAlerta(ByVal dt As DataTable)
        Dim a, b, c, d As Integer
        Dim aa As String = "", bb As String = "", cc As String = "", dd As String = ""
        For Each row As DataRow In dt.Rows
            Select Case row.Item("modificado")
                Case 1
                    a += 1
                    aa &= row.Item("id_recojo")
                Case 2
                    b += 1
                    bb &= row.Item("id_recojo")
                Case 3
                    c += 1
                    cc &= row.Item("id_recojo")
                Case 4
                    d += 1
                    dd &= row.Item("id_recojo")
            End Select
        Next

        If a > 0 Or b > 0 Or c > 0 Or d > 0 Then
            If a > 0 Then
                Dim cad As String = ""
                cad = IIf(a = 1, "Se ha Registrado " & a & " Recojo" & vbCrLf & aa, "Se han Registrado " & a & " Recojos")
                Dim frm As New FrmMensaje
                frm.LblMensaje.Text = cad
                frm.Owner = Me
                frm.sFecha = Me.DtpFecha.Text
                frm.iModificado = 1
                Me.tiempo.Enabled = False
                frm.Show()
                Return
            End If
            If b > 0 Then
                Dim cad As String = ""
                cad = IIf(b = 1, "Se ha Modificado " & b & " Recojo" & vbCrLf & bb, "Se han Modificado " & b & " Recojos")
                Dim frm As New FrmMensaje
                frm.LblMensaje.Text = cad
                frm.Owner = Me
                frm.sFecha = Me.DtpFecha.Text
                frm.iModificado = 2
                Me.tiempo.Enabled = False
                frm.Show()
                Return
            End If
            If c > 0 Then
                Dim cad As String = ""
                cad = IIf(c = 1, "Se ha Reprogramado " & c & " Recojo" & vbCrLf & cc, "Se han Reprogramado " & c & " Recojos")
                Dim frm As New FrmMensaje
                frm.LblMensaje.Text = cad
                frm.Owner = Me
                frm.sFecha = Me.DtpFecha.Text
                frm.iModificado = 3
                Me.tiempo.Enabled = False
                frm.Show()
                Return
            End If
            If d > 0 Then
                Dim cad As String = ""
                cad = IIf(d = 1, "Se ha Cancelado " & d & " Recojo" & vbCrLf & dd, "Se han Cancelado " & d & " Recojos")
                Dim frm As New FrmMensaje
                frm.LblMensaje.Text = cad
                frm.Owner = Me
                frm.sFecha = Me.DtpFecha.Text
                frm.iModificado = 4
                Me.tiempo.Enabled = False
                frm.Show()
                Return
            End If
        End If
    End Sub

    Sub ListarRecojopendiente()
        Try
            Dim sFechaHora As String = Me.Actualizar(Me.DtpFecha.Text)
            Dim iCol, iFil As Integer

            'DgvRecojoPendiente.Rows(0).Selected = True
            If DgvRecojoPendiente.Rows.Count > 0 Then

                iCol = DgvRecojoPendiente.CurrentCell.ColumnIndex
                iFil = DgvRecojoPendiente.CurrentCell.RowIndex

                ReDim aLista(DgvRecojoPendiente.Rows.Count)
                CopiarGrid(Me.DgvRecojoPendiente)
            End If
            Dim dt As DataTable = Me.CargarRecojo(Me.DtpFecha.Text, 0, 1, 0, 0, Me.DgvRecojoPendiente, 1)

            If DgvRecojoPendiente.Rows.Count > 0 Then
                If DgvRecojoPendiente.Rows.Count > 0 Then
                    DgvRecojoPendiente.CurrentCell = DgvRecojoPendiente(iCol, iFil)
                End If

                ActualizarGrid(Me.DgvRecojoPendiente)
            End If

            If dt.Rows.Count > 0 Then
                Me.EnviarAlerta(dt)
            End If

            Dim sfecha As String = FechaServidor() 'Me.DtpFecha.Value
            'SeleccionaRecojoFueraHora()

            'tiempo.Interval = 10000

            'MsgBox("")
        Catch ex As Exception
            Throw (New Exception(ex.Message))
        End Try
    End Sub

    Private Sub tiempo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tiempo.Tick
        mre.Set()
        tiempo.Enabled = False
    End Sub

    Sub SeleccionaRecojoFueraHora()
        With Me.DgvRecojo
            If .Rows.Count > 0 Then
                Dim intTiempo As Integer
                For Each row As DataGridViewRow In .Rows
                    intTiempo = row.Cells("tiempo").Value
                    If intTiempo = 0 Or intTiempo = 10 Then
                        row.DefaultCellStyle.BackColor = Color.White
                        row.DefaultCellStyle.ForeColor = Color.Red
                    ElseIf intTiempo = 1 Then
                        row.DefaultCellStyle.BackColor = Color.White
                        row.DefaultCellStyle.ForeColor = Color.Green
                    ElseIf intTiempo = 100 Then
                        row.DefaultCellStyle.BackColor = Color.White
                        row.DefaultCellStyle.ForeColor = Color.Gray
                    Else
                        row.DefaultCellStyle.BackColor = Color.White
                        row.DefaultCellStyle.ForeColor = Color.Black
                    End If
                Next
            End If
        End With

        With Me.DgvRecojoPendiente
            If .Rows.Count > 0 Then
                Dim intTiempo As Integer
                For Each row As DataGridViewRow In .Rows
                    intTiempo = row.Cells("tiempo").Value
                    If intTiempo = 0 Or intTiempo = 10 Then
                        row.DefaultCellStyle.BackColor = Color.White
                        row.DefaultCellStyle.ForeColor = Color.Red
                    ElseIf intTiempo = 1 Then
                        row.DefaultCellStyle.BackColor = Color.White
                        row.DefaultCellStyle.ForeColor = Color.Green
                    Else
                        row.DefaultCellStyle.BackColor = Color.White
                        row.DefaultCellStyle.ForeColor = Color.Black
                    End If
                Next
            End If
        End With

        'Return
        'With Me.DgvRecojo
        '    If .Rows.Count > 0 Then
        '        For Each row As DataGridViewRow In .Rows
        '            If row.Cells("id_checkpoint").Value = RECOJO.PENDIENTE Or _
        '                row.Cells("id_checkpoint").Value = RECOJO.APROBADO Then
        '                Dim FechaHoraActual As String = row.Cells("hora_cierre").Value
        '                If Convert.ToDateTime(FechaHoraActual) < FechaHora Then
        '                    row.DefaultCellStyle.BackColor = Color.White
        '                    row.DefaultCellStyle.ForeColor = Color.Red
        '                Else
        '                    row.DefaultCellStyle.BackColor = Color.White
        '                    row.DefaultCellStyle.ForeColor = Color.Black
        '                End If
        '            End If
        '        Next
        '    End If
        'End With

        'With Me.DgvRecojoPendiente
        '    If .Rows.Count > 0 Then
        '        For Each row As DataGridViewRow In .Rows
        '            If row.Cells("id_checkpoint").Value = RECOJO.PENDIENTE Or _
        '                row.Cells("id_checkpoint").Value = RECOJO.APROBADO Then
        '                Dim FechaHoraActual As String = row.Cells("hora_cierre").Value
        '                If Convert.ToDateTime(FechaHoraActual) < FechaHora Then
        '                    row.DefaultCellStyle.BackColor = Color.White
        '                    row.DefaultCellStyle.ForeColor = Color.Red
        '                Else
        '                    row.DefaultCellStyle.BackColor = Color.White
        '                    row.DefaultCellStyle.ForeColor = Color.Black
        '                End If
        '            End If
        '        Next
        '    End If
        'End With
    End Sub

    Private Sub FrmAsignacionRecojo_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DgvRecojoPendiente_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DgvRecojoPendiente.EditingControlShowing
        If Not TypeOf e.Control Is ComboBox Then Return
        comboPendiente = CType(e.Control, ComboBox)
        If (comboPendiente IsNot Nothing) Then
            'RemoveHandler comboPendiente.SelectedValueChanged, New EventHandler(AddressOf SelectedValueChanged)
            AddHandler comboPendiente.SelectedValueChanged, New EventHandler(AddressOf SelectedValueChanged)
            iEntra2 = 1
        End If
    End Sub

    Private Sub DgvRecojoPendiente_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DgvRecojoPendiente.CellBeginEdit
        If DgvRecojo.Columns(e.ColumnIndex).Name = "ruta" Then
            mre2.Reset()
            Tiempo2.Enabled = True
            iEntra2 = 1
            Dim obj As New DtoRecojo
            obj.Fecha = Me.DtpFecha.Text
            dsRuta = obj.ListarRuta(1, Me.DgvRecojoPendiente.CurrentRow.Cells("id_tipo_cliente").Value)
            celda = DgvRecojoPendiente.CurrentRow.Cells("ruta")
            celda.DataSource = dsRuta.Tables(0)
            DgvRecojoPendiente.RefreshEdit()
            DgvRecojoPendiente.Refresh()
        End If
    End Sub

    Private Sub DgvRecojo_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DgvRecojo.EditingControlShowing
        If Not TypeOf e.Control Is ComboBox Then Return
        'Dim cellComboBox As DataGridViewComboBoxEditingControl = DirectCast(e.Control, DataGridViewComboBoxEditingControl)
        'AddHandler cellComboBox.SelectedIndexChanged, AddressOf SelectedValueChanged
        'dsRuta2.Tables(0).DefaultView.RowFilter = "id_tipo=" & Me.DgvRecojo.CurrentRow.Cells("id_tipo_cliente").Value

        combo = CType(e.Control, ComboBox)
        If (combo IsNot Nothing) Then
            'RemoveHandler combo.SelectedIndexChanged, New EventHandler(AddressOf SelectedIndexChanged)
            AddHandler combo.SelectedIndexChanged, New EventHandler(AddressOf SelectedIndexChanged)
            'iEntra = 1
        End If
    End Sub

    Private Sub DgvRecojo_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DgvRecojo.CellBeginEdit
        If DgvRecojo.Columns(e.ColumnIndex).Name = "ruta" Then
            mre.Reset()
            tiempo.Enabled = True
            Dim obj As New DtoRecojo
            obj.Fecha = Me.DtpFecha.Text
            dsRuta2 = obj.ListarRuta(1, Me.DgvRecojo.CurrentRow.Cells("id_tipo_cliente").Value)
            celda2 = DgvRecojo.CurrentRow.Cells("ruta")
            celda2.DataSource = dsRuta2.Tables(0)
            DgvRecojo.RefreshEdit()
            DgvRecojo.Refresh()
        End If
    End Sub

    Private Sub SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        'If iEntra = 0 Then Return
        'iEntra = 0
        Try
            Dim cbo As ComboBox = CType(sender, ComboBox)
            If Not (IsReference(cbo.SelectedValue)) Then
                If cbo.SelectedIndex = 0 Then
                    MessageBox.Show("Seleccione una Ruta", "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DgvRecojo.RefreshEdit()
                    Return
                End If
                Dim iProgramacion As Integer '= IIf(IsDBNull(DgvRecojo.CurrentRow.Cells("id_ruta_unidad_transporte").Value), 0, DgvRecojo.CurrentRow.Cells("id_ruta_unidad_transporte").Value)
                Dim sFecha As String = Me.DtpFecha.Text
                Dim iRuta As Integer = cbo.SelectedValue
                Dim iRecojo As Integer = Me.DgvRecojo.CurrentRow.Cells("id_recojo").Value
                If dsRuta.Tables(0).Rows.Count > 0 Then
                    iRuta = dsRuta.Tables(0).Rows(cbo.SelectedIndex).Item("id_ruta")
                    iProgramacion = dsRuta.Tables(0).Rows(cbo.SelectedIndex).Item("id_ruta_unidad_transporte")
                End If

                If Not DtoRecojo.RecojoRuta(iRecojo, iProgramacion) Then
                    Dim iEstado As Integer = Me.DgvRecojo.CurrentRow.Cells("id_estado").Value
                    If iEstado = RECOJO.APROBADO Then 'aprobado
                        Dim s As String = ""
                        s = "El Recojo está Aprobado." & vbCrLf & vbCrLf
                        s &= "¿Desea Reasignarlo a otra Ruta?"
                        Dim dlg As DialogResult = MessageBox.Show(s, "Recojos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                        If dlg = Windows.Forms.DialogResult.No Then
                            Me.DgvRecojo.RefreshEdit()
                            Return
                        End If
                    End If

                    'asigna recojo a ruta seleccionada
                    Dim dt As DataTable = Me.ActualizarProgramacion(iProgramacion, sFecha, iRuta, iRecojo)

                    Dim col As DataGridViewTextBoxCell = TryCast(DgvRecojo("movil", DgvRecojo.CurrentRow.Index), DataGridViewTextBoxCell)
                    Dim sMovil As String = dt.Rows(0).Item(0).ToString
                    col.Value = sMovil

                    Dim col1 As DataGridViewTextBoxCell = TryCast(DgvRecojo("chofer", DgvRecojo.CurrentRow.Index), DataGridViewTextBoxCell)
                    Dim sChofer As String = dt.Rows(0).Item(1).ToString
                    col1.Value = sChofer

                    Dim col2 As DataGridViewTextBoxCell = TryCast(DgvRecojo("id_ruta", DgvRecojo.CurrentRow.Index), DataGridViewTextBoxCell)
                    Dim iProg As Integer = dt.Rows(0).Item(2).ToString
                    col2.Value = iProg

                    'Dim col2 As DataGridViewTextBoxCell = TryCast(DgvRecojo("id_ruta_unidad_transporte", DgvRecojo.CurrentRow.Index), DataGridViewTextBoxCell)
                    'Dim iProg As Integer = dt.Rows(0).Item(2).ToString
                    'col2.Value = iProg
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim combo As DataGridViewComboBoxCell = Me.DgvRecojo.Rows(Me.DgvRecojo.CurrentCell.RowIndex).Cells("ruta")
            combo.Value = 0
            Me.DgvRecojo.CurrentCell = Me.DgvRecojo(10, Me.DgvRecojo.CurrentCell.RowIndex)
            If Tiempo2.Enabled = False Then
                Tiempo2.Enabled = True
            End If
            Me.DgvRecojo.CurrentCell = Me.DgvRecojo(10, Me.DgvRecojo.CurrentCell.RowIndex)
            'Dim combo As DataGridViewComboBoxCell = Me.DgvRecojo.Rows(Me.DgvRecojo.CurrentCell.RowIndex).Cells("ruta")
            'combo.Value = DBNull.Value
            'BuscarRecojo()
        End Try
    End Sub

    Private Sub ToolLlegada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolLlegada.Click
        Try
            Dim iNum As Integer = Me.NumeroCheck(Me.DgvRecojo, RECOJO.ENCURSO)
            Dim frm As New FrmEstadoRecojo
            frm.iNum = iNum
            frm.iEstado = RECOJO.ENCURSO
            frm.Text = "Llegada Móvil"
            frm.ShowDialog()
            If frm.DialogResult = Windows.Forms.DialogResult.Yes Then
                'Me.Cursor = Cursors.AppStarting
                Dim blnCambio As Boolean = CambiarEstado(Me.DgvRecojo, RECOJO.ENCURSO, frm.TxtObservacion.Text.Trim)
                If blnCambio Then
                    MessageBox.Show(IIf(iNum = 1, "Recojo", "Recojos") & IIf(iNum = 1, " En Curso", " En Curso"), "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    BtnBuscar_Click(sender, e)
                    Me.ActivarDesactivar(Me.CboEstado.SelectedValue)
                Else
                    MessageBox.Show(IIf(iNum = 1, "El Recojo", "Los Recojos") & IIf(iNum = 1, " no está en Curso", " no están en Curso"), "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                'Me.Cursor = Cursors.Default
            End If

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'Try
        '    Me.Cursor = Cursors.AppStarting
        '    Actualizar(Me.DtpFecha.Text)
        '    Me.Cursor = Cursors.Default
        '    MessageBox.Show("Se Realizó la Actualización.", "Recojos", MessageBoxButtons.OK)
        '    BtnBuscar_Click(sender, e)
        'Catch ex As Exception
        '    Me.Cursor = Cursors.Default
        '    MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub DgvRecojoPendiente_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvRecojoPendiente.RowValidated
        Dim sfecha As String = FechaServidor()
        SeleccionaRecojoFueraHora()
    End Sub

    Private Sub DgvRecojoPendiente_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvRecojoPendiente.RowLeave
        If comboPendiente IsNot Nothing Then
            RemoveHandler comboPendiente.SelectedValueChanged, New EventHandler(AddressOf SelectedValueChanged)
            iEntra2 = 0
        End If
    End Sub

    Private Sub DgvRecojo_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvRecojo.RowLeave
        If combo IsNot Nothing Then
            RemoveHandler combo.SelectedIndexChanged, New EventHandler(AddressOf SelectedIndexChanged)
            iEntra = 1
        End If
    End Sub

    Private Sub DgvRecojo_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvRecojo.RowEnter
        If DgvRecojo.Rows.Count > 0 Then
            iEntra = 0
            If DgvRecojo.Rows(e.RowIndex).Cells("id_checkpoint").Value = RECOJO.APROBADO Then
                'DgvRecojo.Rows(e.RowIndex).ReadOnly = False
                DgvRecojo.Rows(e.RowIndex).Cells("ruta").ReadOnly = False
            Else
                DgvRecojo.Rows(e.RowIndex).Cells("ruta").ReadOnly = True
            End If
        End If
    End Sub

    Private Sub SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            'If iEntra2 = 0 Then Return
            'iEntra2 = 0
            Dim cbo As ComboBox = CType(sender, ComboBox)
            If Not (IsReference(cbo.SelectedValue)) Then
                Dim iProgramacion As Integer '= IIf(IsDBNull(DgvRecojoPendiente.CurrentRow.Cells("id_ruta_unidad_transporte").Value), 0, DgvRecojoPendiente.CurrentRow.Cells("id_ruta_unidad_transporte").Value)
                Dim sFecha As String = Me.DtpFecha.Text
                Dim iRuta As Integer '= cbo.SelectedValue
                Dim iRecojo As Integer = Me.DgvRecojoPendiente.CurrentRow.Cells("id_recojo").Value
                If dsRuta.Tables(0).Rows.Count > 0 Then
                    iRuta = dsRuta.Tables(0).Rows(cbo.SelectedIndex).Item("id_ruta")
                    iProgramacion = dsRuta.Tables(0).Rows(cbo.SelectedIndex).Item("id_ruta_unidad_transporte")
                End If

                Dim iEstado As Integer = Me.DgvRecojoPendiente.CurrentRow.Cells("id_estado").Value
                If iEstado = RECOJO.APROBADO Then 'aprobado
                    Dim s As String = ""
                    s = "El Recojo está Aprobado." & vbCrLf & vbCrLf
                    s &= "¿Desea Reasignarlo a otra Ruta?"
                    Dim dlg As DialogResult = MessageBox.Show(s, "Recojos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If dlg = Windows.Forms.DialogResult.No Then
                        Me.DgvRecojoPendiente.RefreshEdit()
                        Return
                    End If
                End If

                Dim dt As DataTable = Me.ActualizarProgramacion(iProgramacion, sFecha, iRuta, iRecojo)

                Dim col As DataGridViewTextBoxCell = TryCast(DgvRecojoPendiente("movil", DgvRecojoPendiente.CurrentRow.Index), DataGridViewTextBoxCell)
                Dim sMovil As String = dt.Rows(0).Item(0).ToString
                col.Value = sMovil

                Dim col1 As DataGridViewTextBoxCell = TryCast(DgvRecojoPendiente("chofer", DgvRecojoPendiente.CurrentRow.Index), DataGridViewTextBoxCell)
                Dim sChofer As String = dt.Rows(0).Item(1).ToString
                col1.Value = sChofer

                Dim col2 As DataGridViewTextBoxCell = TryCast(DgvRecojoPendiente("id_ruta", DgvRecojoPendiente.CurrentRow.Index), DataGridViewTextBoxCell)
                Dim iProg As Integer = dt.Rows(0).Item(2).ToString
                col2.Value = iProg

                'hlamas 08-01-2019
                'Dim col3 As DataGridViewTextBoxCell = TryCast(DgvRecojoPendiente("tipo_ruta", DgvRecojoPendiente.CurrentRow.Index), DataGridViewTextBoxCell)
                'Dim sTipo As String = dt.Rows(0).Item(3).ToString
                'col3.Value = sTipo
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Recojos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim combo As DataGridViewComboBoxCell = Me.DgvRecojoPendiente.Rows(Me.DgvRecojoPendiente.CurrentCell.RowIndex).Cells("ruta")
            combo.Value = 0
            Me.DgvRecojoPendiente.CurrentCell = Me.DgvRecojoPendiente(10, Me.DgvRecojoPendiente.CurrentCell.RowIndex)
            If tiempo.Enabled = False Then
                tiempo.Enabled = True
            End If
            Me.DgvRecojoPendiente.CurrentCell = Me.DgvRecojoPendiente(9, Me.DgvRecojoPendiente.CurrentCell.RowIndex)
            'tiempo_Tick(Nothing, Nothing)
            'Me.DgvRecojoPendiente.CurrentCell = Me.DgvRecojoPendiente(10, Me.DgvRecojoPendiente.CurrentCell.RowIndex)
            'Me.DgvRecojoPendiente.CurrentCell = Me.DgvRecojoPendiente(9, Me.DgvRecojoPendiente.CurrentCell.RowIndex)
        End Try
    End Sub
End Class
