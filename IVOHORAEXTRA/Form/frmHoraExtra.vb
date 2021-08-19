Imports INTEGRACION_LN

Public Class frmHoraExtra
#Region "Publico"
    Const intColumnaFija As Integer = 9
    Const intColumnaFijaAprobacion As Integer = 10
    Dim dtTrabajador As DataTable
    Dim dtPlanificacion As New DataTable()
    Dim dtHora As New DataTable
    Dim dtSolicitud As DataTable

    Dim blnNuevo As Boolean = True
    Dim blnNuevoSolicitud As Boolean = True

    'Solicitud
    Dim blnNuevoRegistro As Boolean = True
    Dim blnDescansoSolicitud As Boolean = False
    Dim blnFeriadoSolicitud As Boolean = False

    Dim blnEditarAutorizacion As Boolean 'Autorizacion

    'Aprobacion solicitud
    Dim blnEditarAprobacion As Boolean
    Dim tabAprobacionPlanificacion As TabPage, tabAprobacionSolicitud As TabPage, tabAprobacionSolicitudCompensado As TabPage

    'Aprobacion planificacion
    Dim blnEditarAprobarPlan As Boolean

    Dim strFechaOriginal As String

    'Compensacion
    Dim intFilaCompensacion As Integer = -1
    Dim blnEditarCompensacion As Boolean = False

    'Perfil
    Dim intPerfil As Integer
    Dim lista() As Arbol = Nothing

    'Aprobacion compensacion
    Dim intOperacion As Integer
    Dim blnEditarAprobacionSolicitud As Boolean

    'Solicitud compensacion
    Dim blnEditarSolicitudCompensacion As Boolean

    'hlamas 17-06-2019
    Dim intExonerado As Integer = 0

    Structure Arbol
        Dim nodo As TreeNode
        Dim nivel As Integer
        Dim id As Integer
        Dim id2 As Integer
        Dim pk As Integer
    End Structure
#End Region

    Sub ConfigurardgvPlanificacion()
        With dgvPlanificacion
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            '.VirtualMode = True
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
                .Frozen = True
            End With

            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Frozen = True
            End With

            x += +1
            Dim col_nombres As New DataGridViewTextBoxColumn
            With col_nombres
                .Name = "nombres" : .DataPropertyName = "nombres"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Trabajador"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Frozen = True
            End With

            x += +1
            Dim col_cargo As New DataGridViewTextBoxColumn
            With col_cargo
                .Name = "cargo" : .DataPropertyName = "cargo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cargo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Frozen = True
            End With

            x += +1
            Dim col_centro_costo As New DataGridViewTextBoxColumn
            With col_centro_costo
                .Name = "centro_costo" : .DataPropertyName = "centro_costo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Centro Costo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Frozen = True
            End With

            x += +1
            Dim col_remuneracion As New DataGridViewTextBoxColumn
            With col_remuneracion
                .Name = "remuneracion" : .DataPropertyName = "remuneracion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Remuneración" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
                .Frozen = True
            End With

            x += +1
            Dim col_horario As New DataGridViewTextBoxColumn
            With col_horario
                .Name = "horario" : .DataPropertyName = "horario"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Horario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Frozen = True
            End With

            x += +1
            Dim col_horas As New DataGridViewTextBoxColumn
            With col_horas
                .Name = "horas" : .DataPropertyName = "horas"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Horas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Frozen = True
            End With

            x += +1
            Dim col_costo As New DataGridViewTextBoxColumn
            With col_costo
                .Name = "costo" : .DataPropertyName = "costo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Costo" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "0.00"
                .ValueType = Type.GetType("System.Double")
                .Frozen = True
            End With

            x += +1
            Dim col_cap As New DataGridViewTextBoxColumn
            With col_cap
                .Name = "cap" : .DataPropertyName = "cap"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cap"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Frozen = True
            End With


            .Columns.AddRange(col_id, col_codigo, col_nombres, col_cargo, col_centro_costo, col_remuneracion, col_horario, col_horas, col_costo)
        End With
    End Sub
    Sub ConfigurardgvLista()
        With dgvLista
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
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Planificación"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .Width = 105
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
            End With

            x += +1
            Dim col_fecha_inicio As New DataGridViewTextBoxColumn
            With col_fecha_inicio
                .Name = "fecha_inicio" : .DataPropertyName = "fecha_inicio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Inicio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_fecha_fin As New DataGridViewTextBoxColumn
            With col_fecha_fin
                .Name = "fecha_fin" : .DataPropertyName = "fecha_fin"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Fin"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_area As New DataGridViewTextBoxColumn
            With col_area
                .Name = "area" : .DataPropertyName = "area"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Area"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_usuario As New DataGridViewTextBoxColumn
            With col_usuario
                .Name = "usuario" : .DataPropertyName = "usuario"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Usuario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_horas As New DataGridViewTextBoxColumn
            With col_horas
                .Name = "horas" : .DataPropertyName = "horas"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Horas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
            End With

            x += +1
            Dim col_costo As New DataGridViewTextBoxColumn
            With col_costo
                .Name = "costo" : .DataPropertyName = "costo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Costo" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "0.00"
                .ReadOnly = True
                .ValueType = Type.GetType("System.Double")
            End With

            x += +1
            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .Name = "id_estado" : .DataPropertyName = "id_estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_aprobado As New DataGridViewTextBoxColumn
            With col_aprobado
                .Name = "aprobado" : .DataPropertyName = "aprobado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "aprobado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
            End With

            x += +1
            Dim col_desaprobado As New DataGridViewTextBoxColumn
            With col_desaprobado
                .Name = "desaprobado" : .DataPropertyName = "desaprobado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "desaprobado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
            End With

            x += +1
            Dim col_cerrado As New DataGridViewCheckBoxColumn
            With col_cerrado
                '.Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = True : .HeaderText = "id_estado"
                .HeaderText = "Cerrado"
                .Name = "cerrado"
                .DataPropertyName = "cerrado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.Automatic
                .FalseValue = 0
                .TrueValue = 1
                '.ThreeState = True
                .ReadOnly = False : .DisplayIndex = x
            End With

            .Columns.AddRange(col_id, col_fecha_inicio, col_fecha_fin, col_area, col_usuario, col_horas, col_costo, col_id_estado, col_estado, col_aprobado, col_desaprobado, col_cerrado)
        End With
    End Sub
    Sub ConfigurardgvSolicitud()
        With dgvSolicitud
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_inicio As New DataGridViewTextBoxColumn
            With col_inicio
                .Name = "inicio" : .DataPropertyName = "inicio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Hora Inicio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_fin As New DataGridViewTextBoxColumn
            With col_fin
                .Name = "fin" : .DataPropertyName = "fin"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Hora Fin"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_horas As New DataGridViewTextBoxColumn
            With col_horas
                .Name = "horas" : .DataPropertyName = "horas"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Horas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_actividad As New DataGridViewTextBoxColumn
            With col_actividad
                .Name = "actividad" : .DataPropertyName = "actividad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Actividad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_nombres As New DataGridViewTextBoxColumn
            With col_nombres
                .Name = "nombres" : .DataPropertyName = "nombres"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Nombres"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_area As New DataGridViewTextBoxColumn
            With col_area
                .Name = "area" : .DataPropertyName = "area"
                .DisplayIndex = x : .Visible = False : .HeaderText = "area"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "codigo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_centro_costo As New DataGridViewTextBoxColumn
            With col_centro_costo
                .Name = "centro_costo" : .DataPropertyName = "centro_costo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "centro_costo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_cargo As New DataGridViewTextBoxColumn
            With col_cargo
                .Name = "cargo" : .DataPropertyName = "cargo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "cargo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_ingreso As New DataGridViewTextBoxColumn
            With col_ingreso
                .Name = "ingreso" : .DataPropertyName = "ingreso"
                .DisplayIndex = x : .Visible = False : .HeaderText = "ingreso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_salida As New DataGridViewTextBoxColumn
            With col_salida
                .Name = "salida" : .DataPropertyName = "salida"
                .DisplayIndex = x : .Visible = False : .HeaderText = "salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_asistencia_ingreso As New DataGridViewTextBoxColumn
            With col_asistencia_ingreso
                .Name = "asistencia_ingreso" : .DataPropertyName = "asistencia_ingreso"
                .DisplayIndex = x : .Visible = False : .HeaderText = "asistencia_ingreso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_asistencia_salida As New DataGridViewTextBoxColumn
            With col_asistencia_salida
                .Name = "asistencia_salida" : .DataPropertyName = "asistencia_salida"
                .DisplayIndex = x : .Visible = False : .HeaderText = "asistencia_salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id, col_fecha, col_inicio, col_fin, col_horas, col_actividad, col_nombres, col_area, col_codigo, _
                              col_centro_costo, col_cargo, col_ingreso, col_salida, col_asistencia_ingreso, col_asistencia_salida)
        End With
    End Sub
    Sub ConfigurardgvListaSolicitud()
        With dgvListaSolicitud
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_nombres As New DataGridViewTextBoxColumn
            With col_nombres
                .Name = "nombres" : .DataPropertyName = "nombres"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nombres"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_cargo As New DataGridViewTextBoxColumn
            With col_cargo
                .Name = "cargo" : .DataPropertyName = "cargo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Cargo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_centro_costo As New DataGridViewTextBoxColumn
            With col_centro_costo
                .Name = "centro_costo" : .DataPropertyName = "centro_costo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Centro Costo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_area As New DataGridViewTextBoxColumn
            With col_area
                .Name = "area" : .DataPropertyName = "area"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Area"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_ingreso As New DataGridViewTextBoxColumn
            With col_ingreso
                .Name = "ingreso" : .DataPropertyName = "ingreso"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Ingreso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_salida As New DataGridViewTextBoxColumn
            With col_salida
                .Name = "salida" : .DataPropertyName = "salida"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_asistencia_ingreso As New DataGridViewTextBoxColumn
            With col_asistencia_ingreso
                .Name = "asistencia_ingreso" : .DataPropertyName = "asistencia_ingreso"
                .DisplayIndex = x : .Visible = False : .HeaderText = "asistencia_ingreso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_asistencia_salida As New DataGridViewTextBoxColumn
            With col_asistencia_salida
                .Name = "asistencia_salida" : .DataPropertyName = "asistencia_salida"
                .DisplayIndex = x : .Visible = False : .HeaderText = "asistencia_salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_horas As New DataGridViewTextBoxColumn
            With col_horas
                .Name = "horas" : .DataPropertyName = "horas"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Horas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .Name = "id_estado" : .DataPropertyName = "id_estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_horario As New DataGridViewTextBoxColumn
            With col_horario
                .Name = "horario" : .DataPropertyName = "horario"
                .DisplayIndex = x : .Visible = False : .HeaderText = "horario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_remuneracion As New DataGridViewTextBoxColumn
            With col_remuneracion
                .Name = "remuneracion" : .DataPropertyName = "remuneracion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "remuneracion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_costo As New DataGridViewTextBoxColumn
            With col_costo
                .Name = "costo" : .DataPropertyName = "costo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "costo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_horas_efectivo As New DataGridViewTextBoxColumn
            With col_horas_efectivo
                .Name = "horas_efectivo" : .DataPropertyName = "horas_efectivo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "horas_efectivo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_tipo_dia As New DataGridViewTextBoxColumn
            With col_tipo_dia
                .Name = "tipo_dia" : .DataPropertyName = "tipo_dia" : .DisplayIndex = x : .Visible = False : .HeaderText = "tipo_dia"
            End With

            .Columns.AddRange(col_id, col_fecha, col_codigo, col_nombres, col_cargo, col_centro_costo, col_area, _
                              col_ingreso, col_salida, col_asistencia_ingreso, col_asistencia_salida, col_horas, _
                              col_estado, col_id_estado, col_horario, col_remuneracion, col_costo, col_horas_efectivo, col_tipo_dia)
        End With
    End Sub
    Sub ConfigurardgvListaAutorizacion()
        With dgvListaAutorizacion
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_nombres As New DataGridViewTextBoxColumn
            With col_nombres
                .Name = "nombres" : .DataPropertyName = "nombres"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nombres"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_cargo As New DataGridViewTextBoxColumn
            With col_cargo
                .Name = "cargo" : .DataPropertyName = "cargo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Cargo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_centro_costo As New DataGridViewTextBoxColumn
            With col_centro_costo
                .Name = "centro_costo" : .DataPropertyName = "centro_costo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Centro Costo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_area As New DataGridViewTextBoxColumn
            With col_area
                .Name = "area" : .DataPropertyName = "area"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Area"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_ingreso As New DataGridViewTextBoxColumn
            With col_ingreso
                .Name = "ingreso" : .DataPropertyName = "ingreso"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Ingreso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_salida As New DataGridViewTextBoxColumn
            With col_salida
                .Name = "salida" : .DataPropertyName = "salida"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_asistencia_ingreso As New DataGridViewTextBoxColumn
            With col_asistencia_ingreso
                .Name = "asistencia_ingreso" : .DataPropertyName = "asistencia_ingreso"
                .DisplayIndex = x : .Visible = False : .HeaderText = "asistencia_ingreso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_asistencia_salida As New DataGridViewTextBoxColumn
            With col_asistencia_salida
                .Name = "asistencia_salida" : .DataPropertyName = "asistencia_salida"
                .DisplayIndex = x : .Visible = False : .HeaderText = "asistencia_salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_horas As New DataGridViewTextBoxColumn
            With col_horas
                .Name = "horas" : .DataPropertyName = "horas"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Horas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .Name = "id_estado" : .DataPropertyName = "id_estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_horario As New DataGridViewTextBoxColumn
            With col_horario
                .Name = "horario" : .DataPropertyName = "horario"
                .DisplayIndex = x : .Visible = False : .HeaderText = "horario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_remuneracion As New DataGridViewTextBoxColumn
            With col_remuneracion
                .Name = "remuneracion" : .DataPropertyName = "remuneracion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "remuneracion"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_costo As New DataGridViewTextBoxColumn
            With col_costo
                .Name = "costo" : .DataPropertyName = "costo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "costo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_horas_efectivo As New DataGridViewTextBoxColumn
            With col_horas_efectivo
                .Name = "horas_efectivo" : .DataPropertyName = "horas_efectivo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "horas_efectivo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_tipo_dia As New DataGridViewTextBoxColumn
            With col_tipo_dia
                .Name = "tipo_dia" : .DataPropertyName = "tipo_dia" : .DisplayIndex = x : .Visible = False : .HeaderText = "tipo_dia"
            End With

            x += +1
            Dim col_fecha_solicitud As New DataGridViewTextBoxColumn
            With col_fecha_solicitud
                .Name = "fecha_solicitud" : .DataPropertyName = "fecha_solicitud" : .DisplayIndex = x : .Visible = False : .HeaderText = "fecha_solicitud"
            End With

            x += +1
            Dim col_tipo_compensacion As New DataGridViewTextBoxColumn
            With col_tipo_compensacion
                .Name = "tipo_compensacion" : .DataPropertyName = "tipo_compensacion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Tipo Compensación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id, col_fecha, col_codigo, col_nombres, col_cargo, col_centro_costo, col_area, _
                              col_ingreso, col_salida, col_asistencia_ingreso, col_asistencia_salida, col_horas, _
                              col_estado, col_id_estado, col_horario, col_remuneracion, col_costo, col_horas_efectivo, col_tipo_dia, col_fecha_solicitud, col_tipo_compensacion)
        End With
    End Sub
    Sub ConfigurardgvSobretiempoAutorizacion()
        With dgvSobretiempoAutorizacion
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            '.VirtualMode = True
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_inicio As New DataGridViewTextBoxColumn
            With col_inicio
                .Name = "inicio" : .DataPropertyName = "inicio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Hora Inicio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_fin As New DataGridViewTextBoxColumn
            With col_fin
                .Name = "fin" : .DataPropertyName = "fin"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Hora Fin"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_horas As New DataGridViewTextBoxColumn
            With col_horas
                .Name = "horas" : .DataPropertyName = "horas"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Horas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_actividad As New DataGridViewTextBoxColumn
            With col_actividad
                .Name = "actividad" : .DataPropertyName = "actividad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Actividad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_nombres As New DataGridViewTextBoxColumn
            With col_nombres
                .Name = "nombres" : .DataPropertyName = "nombres"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Nombres"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_area As New DataGridViewTextBoxColumn
            With col_area
                .Name = "area" : .DataPropertyName = "area"
                .DisplayIndex = x : .Visible = False : .HeaderText = "area"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "codigo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_centro_costo As New DataGridViewTextBoxColumn
            With col_centro_costo
                .Name = "centro_costo" : .DataPropertyName = "centro_costo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "centro_costo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_cargo As New DataGridViewTextBoxColumn
            With col_cargo
                .Name = "cargo" : .DataPropertyName = "cargo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "cargo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_ingreso As New DataGridViewTextBoxColumn
            With col_ingreso
                .Name = "ingreso" : .DataPropertyName = "ingreso"
                .DisplayIndex = x : .Visible = False : .HeaderText = "ingreso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_salida As New DataGridViewTextBoxColumn
            With col_salida
                .Name = "salida" : .DataPropertyName = "salida"
                .DisplayIndex = x : .Visible = False : .HeaderText = "salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_asistencia_ingreso As New DataGridViewTextBoxColumn
            With col_asistencia_ingreso
                .Name = "asistencia_ingreso" : .DataPropertyName = "asistencia_ingreso"
                .DisplayIndex = x : .Visible = False : .HeaderText = "asistencia_ingreso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_asistencia_salida As New DataGridViewTextBoxColumn
            With col_asistencia_salida
                .Name = "asistencia_salida" : .DataPropertyName = "asistencia_salida"
                .DisplayIndex = x : .Visible = False : .HeaderText = "asistencia_salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id, col_fecha, col_inicio, col_fin, col_horas, col_actividad, col_nombres, col_area, col_codigo, _
                              col_centro_costo, col_cargo, col_ingreso, col_salida, col_asistencia_ingreso, col_asistencia_salida)
        End With
    End Sub
    Sub ConfigurardgvListaAprobacion(ByVal opcion As Integer)
        With dgvListaAprobacion
            If opcion = 1 Then
                'utilitario.FormatDataGridView(dgv1)
                .Columns.Clear()
                '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
                '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
                .AllowUserToResizeColumns = False
                .AllowUserToResizeRows = False
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = True
                .DefaultCellStyle.WrapMode = DataGridViewTriState.False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                '.VirtualMode = True
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ScrollBars = ScrollBars.Both
                .ReadOnly = True
                '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
                '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
                '.DefaultCellStyle.SelectionForeColor = Color.Blacks
                '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

                Dim x As Integer = 0
                Dim col_id As New DataGridViewTextBoxColumn
                With col_id
                    .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
                End With

                x += +1
                Dim col_fecha_solicitud As New DataGridViewTextBoxColumn
                With col_fecha_solicitud
                    .Name = "fecha_solicitud" : .DataPropertyName = "fecha_solicitud"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Solicitud"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_fecha As New DataGridViewTextBoxColumn
                With col_fecha
                    .Name = "fecha" : .DataPropertyName = "fecha"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_codigo As New DataGridViewTextBoxColumn
                With col_codigo
                    .Name = "codigo" : .DataPropertyName = "codigo"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_nombres As New DataGridViewTextBoxColumn
                With col_nombres
                    .Name = "nombres" : .DataPropertyName = "nombres"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Nombres"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_cargo As New DataGridViewTextBoxColumn
                With col_cargo
                    .Name = "cargo" : .DataPropertyName = "cargo"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "Cargo"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_centro_costo As New DataGridViewTextBoxColumn
                With col_centro_costo
                    .Name = "centro_costo" : .DataPropertyName = "centro_costo"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "Centro Costo"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_area As New DataGridViewTextBoxColumn
                With col_area
                    .Name = "area" : .DataPropertyName = "area"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Area"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_ingreso As New DataGridViewTextBoxColumn
                With col_ingreso
                    .Name = "ingreso" : .DataPropertyName = "ingreso"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "Ingreso"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_salida As New DataGridViewTextBoxColumn
                With col_salida
                    .Name = "salida" : .DataPropertyName = "salida"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "Salida"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_asistencia_ingreso As New DataGridViewTextBoxColumn
                With col_asistencia_ingreso
                    .Name = "asistencia_ingreso" : .DataPropertyName = "asistencia_ingreso"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "asistencia_ingreso"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_asistencia_salida As New DataGridViewTextBoxColumn
                With col_asistencia_salida
                    .Name = "asistencia_salida" : .DataPropertyName = "asistencia_salida"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "asistencia_salida"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_horas As New DataGridViewTextBoxColumn
                With col_horas
                    .Name = "horas" : .DataPropertyName = "horas"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Horas"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_estado As New DataGridViewTextBoxColumn
                With col_estado
                    .Name = "estado" : .DataPropertyName = "estado"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_id_estado As New DataGridViewTextBoxColumn
                With col_id_estado
                    .Name = "id_estado" : .DataPropertyName = "id_estado"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_horario As New DataGridViewTextBoxColumn
                With col_horario
                    .Name = "horario" : .DataPropertyName = "horario"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "horario"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_remuneracion As New DataGridViewTextBoxColumn
                With col_remuneracion
                    .Name = "remuneracion" : .DataPropertyName = "remuneracion"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "remuneracion"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_costo As New DataGridViewTextBoxColumn
                With col_costo
                    .Name = "costo" : .DataPropertyName = "costo"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "Costo" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "0.00"
                    .ValueType = Type.GetType("System.Double")
                End With

                x += +1
                Dim col_horas_efectivo As New DataGridViewTextBoxColumn
                With col_horas_efectivo
                    .Name = "horas_efectivo" : .DataPropertyName = "horas_efectivo"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "horas_efectivo"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With

                x += +1
                Dim col_tipo_dia As New DataGridViewTextBoxColumn
                With col_tipo_dia
                    .Name = "tipo_dia" : .DataPropertyName = "tipo_dia" : .DisplayIndex = x : .Visible = False : .HeaderText = "tipo_dia"
                End With

                x += +1
                Dim col_tipo_compensacion As New DataGridViewTextBoxColumn
                With col_tipo_compensacion
                    .Name = "tipo_compensacion" : .DataPropertyName = "tipo_compensacion"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Compensación"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                .Columns.AddRange(col_id, col_fecha, col_fecha_solicitud, col_codigo, col_nombres, col_cargo, col_centro_costo, col_area, _
                                  col_ingreso, col_salida, col_asistencia_ingreso, col_asistencia_salida, col_horas, _
                                  col_estado, col_id_estado, col_horario, col_remuneracion, col_costo, col_horas_efectivo, col_tipo_dia, col_tipo_compensacion)
            ElseIf opcion = 2 Then
                'utilitario.FormatDataGridView(dgv1)
                .Columns.Clear()
                '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
                '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
                .AllowUserToResizeColumns = False
                .AllowUserToResizeRows = False
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = True
                .DefaultCellStyle.WrapMode = DataGridViewTriState.False
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                '.VirtualMode = True
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ScrollBars = ScrollBars.Both
                .ReadOnly = True
                '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
                '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
                '.DefaultCellStyle.SelectionForeColor = Color.Blacks
                '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

                Dim x As Integer = 0
                Dim col_id As New DataGridViewTextBoxColumn
                With col_id
                    .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Planificación"
                    '.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Width = 105
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End With

                x += +1
                Dim col_fecha_inicio As New DataGridViewTextBoxColumn
                With col_fecha_inicio
                    .Name = "fecha_inicio" : .DataPropertyName = "fecha_inicio"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Inicio"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_fecha_fin As New DataGridViewTextBoxColumn
                With col_fecha_fin
                    .Name = "fecha_fin" : .DataPropertyName = "fecha_fin"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Fin"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_area As New DataGridViewTextBoxColumn
                With col_area
                    .Name = "area" : .DataPropertyName = "area"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "Area"
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
                Dim col_horas As New DataGridViewTextBoxColumn
                With col_horas
                    .Name = "horas" : .DataPropertyName = "horas"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Horas"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With

                x += +1
                Dim col_costo As New DataGridViewTextBoxColumn
                With col_costo
                    .Name = "costo" : .DataPropertyName = "costo"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Costo" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "0.00"
                    .ValueType = Type.GetType("System.Double")
                End With

                x += +1
                Dim col_id_estado As New DataGridViewTextBoxColumn
                With col_id_estado
                    .Name = "id_estado" : .DataPropertyName = "id_estado"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With

                x += +1
                Dim col_estado As New DataGridViewTextBoxColumn
                With col_estado
                    .Name = "estado" : .DataPropertyName = "estado"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_aprobado As New DataGridViewLinkColumn
                With col_aprobado
                    '.Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = True : .HeaderText = "id_estado"
                    .HeaderText = "Aprobar"
                    .Name = "aprobado"
                    .DataPropertyName = "aprobado"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    '.SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    '.FalseValue = 0
                    '.TrueValue = 1
                    '.ThreeState = True
                    .ReadOnly = False : .DisplayIndex = x
                End With

                x += +1
                Dim col_desaprobado As New DataGridViewLinkColumn
                With col_desaprobado
                    '.Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = True : .HeaderText = "id_estado"
                    .HeaderText = "Desaprobar"
                    .Name = "desaprobado"
                    .DataPropertyName = "desaprobado"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    '.SortMode = DataGridViewColumnSortMode.NotSortable
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    '.FalseValue = 0
                    '.TrueValue = 1
                    '.ThreeState = True
                    .ReadOnly = False : .DisplayIndex = x
                End With

                x += +1
                Dim col_cerrado As New DataGridViewTextBoxColumn
                With col_cerrado
                    .Name = "cerrado" : .DataPropertyName = "cerrado"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "Cerrado"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With

                .Columns.AddRange(col_id, col_fecha_inicio, col_fecha_fin, col_area, col_usuario, col_horas, col_costo, col_id_estado, col_estado, _
                                  col_aprobado, col_desaprobado, col_cerrado)
            Else
                'utilitario.FormatDataGridView(dgv1)
                .Columns.Clear()
                '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
                '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
                '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
                .AllowUserToResizeColumns = False
                .AllowUserToResizeRows = False
                .AllowUserToOrderColumns = True
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .AutoGenerateColumns = True
                .DefaultCellStyle.WrapMode = DataGridViewTriState.False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                '.VirtualMode = True
                .RowHeadersVisible = False
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ScrollBars = ScrollBars.Both
                .ReadOnly = True
                '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
                '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
                '.DefaultCellStyle.SelectionForeColor = Color.Blacks
                '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

                Dim x As Integer = 0
                Dim col_id As New DataGridViewTextBoxColumn
                With col_id
                    .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
                End With

                x += +1
                Dim col_fecha_solicitud As New DataGridViewTextBoxColumn
                With col_fecha_solicitud
                    .Name = "fecha_solicitud" : .DataPropertyName = "fecha_solicitud"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Solicitud"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_codigo As New DataGridViewTextBoxColumn
                With col_codigo
                    .Name = "codigo" : .DataPropertyName = "codigo"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_nombres As New DataGridViewTextBoxColumn
                With col_nombres
                    .Name = "nombres" : .DataPropertyName = "nombres"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Nombres"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_area As New DataGridViewTextBoxColumn
                With col_area
                    .Name = "area" : .DataPropertyName = "area"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Area"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_horas As New DataGridViewTextBoxColumn
                With col_horas
                    .Name = "horas" : .DataPropertyName = "horas"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Horas"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_tipo_compensacion As New DataGridViewTextBoxColumn
                With col_tipo_compensacion
                    .Name = "tipo_compensacion" : .DataPropertyName = "tipo_compensacion"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Compensación"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_horas_total As New DataGridViewTextBoxColumn
                With col_horas_total
                    .Name = "horas_total" : .DataPropertyName = "horas_total"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "Nº Horas"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_horas_compensadas As New DataGridViewTextBoxColumn
                With col_horas_compensadas
                    .Name = "horas_compensadas" : .DataPropertyName = "horas_compensadas"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "Horas Compensadas"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_saldo As New DataGridViewTextBoxColumn
                With col_saldo
                    .Name = "saldo" : .DataPropertyName = "saldo"
                    .DisplayIndex = x : .Visible = False : .HeaderText = "Nº Horas"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_estado As New DataGridViewTextBoxColumn
                With col_estado
                    .Name = "estado" : .DataPropertyName = "estado"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_fecha_aprobacion As New DataGridViewTextBoxColumn
                With col_fecha_aprobacion
                    .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aprobación"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_fecha_noaprobacion As New DataGridViewTextBoxColumn
                With col_fecha_noaprobacion
                    .Name = "fecha_noaprobacion" : .DataPropertyName = "fecha_noaprobacion"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Desaprobación"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_observaciones As New DataGridViewTextBoxColumn
                With col_observaciones
                    .Name = "observaciones" : .DataPropertyName = "observaciones"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Observación"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_observacion_noaprobacion As New DataGridViewTextBoxColumn
                With col_observacion_noaprobacion
                    .Name = "observacion_noaprobacion" : .DataPropertyName = "observacion_noaprobacion"
                    .DisplayIndex = x : .Visible = True : .HeaderText = "Observación Desaprobación"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With

                x += +1
                Dim col_cargo As New DataGridViewTextBoxColumn
                With col_cargo
                    .Name = "cargo" : .DataPropertyName = "cargo" : .DisplayIndex = x : .Visible = False : .HeaderText = "cargo"
                End With

                x += +1
                Dim col_centro_costo As New DataGridViewTextBoxColumn
                With col_centro_costo
                    .Name = "centro_costo" : .DataPropertyName = "centro_costo" : .DisplayIndex = x : .Visible = False : .HeaderText = "centro_costo"
                End With

                x += +1
                Dim col_id_estado As New DataGridViewTextBoxColumn
                With col_id_estado
                    .Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado"
                End With

                x += +1
                Dim col_efectivo As New DataGridViewTextBoxColumn
                With col_efectivo
                    .Name = "efectivo" : .DataPropertyName = "efectivo" : .DisplayIndex = x : .Visible = False : .HeaderText = "efectivo"
                End With

                x += +1
                Dim col_descanso As New DataGridViewTextBoxColumn
                With col_descanso
                    .Name = "descanso" : .DataPropertyName = "descanso" : .DisplayIndex = x : .Visible = False : .HeaderText = "descanso"
                End With

                x += +1
                Dim col_id_2 As New DataGridViewTextBoxColumn
                With col_id_2
                    .Name = "id_2" : .DataPropertyName = "id_2" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_2"
                End With

                x += +1
                Dim col_id_2_det As New DataGridViewTextBoxColumn
                With col_id_2_det
                    .Name = "id_2_det" : .DataPropertyName = "id_2_det" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_2_det"
                End With

                x += +1
                Dim col_idtipo_compensacion As New DataGridViewTextBoxColumn
                With col_idtipo_compensacion
                    .Name = "idtipo_compensacion" : .DataPropertyName = "idtipo_compensacion" : .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo_compensacion"
                End With

                .Columns.AddRange(col_id, col_fecha_solicitud, col_codigo, col_nombres, col_area, col_horas, col_tipo_compensacion, _
                                  col_horas_total, col_horas_compensadas, col_saldo, col_estado, col_fecha_aprobacion, col_fecha_noaprobacion, _
                                  col_observaciones, col_observacion_noaprobacion, col_cargo, col_centro_costo, _
                                  col_id_estado, col_efectivo, col_descanso, col_id_2, col_id_2_det, col_idtipo_compensacion)
            End If
        End With
    End Sub
    Sub ConfigurardgvSobretiempoAprobacion()
        With dgvSobretiempoAprobacion
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            '.VirtualMode = True
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_inicio As New DataGridViewTextBoxColumn
            With col_inicio
                .Name = "inicio" : .DataPropertyName = "inicio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Hora Inicio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_fin As New DataGridViewTextBoxColumn
            With col_fin
                .Name = "fin" : .DataPropertyName = "fin"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Hora Fin"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_horas As New DataGridViewTextBoxColumn
            With col_horas
                .Name = "horas" : .DataPropertyName = "horas"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Horas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_actividad As New DataGridViewTextBoxColumn
            With col_actividad
                .Name = "actividad" : .DataPropertyName = "actividad"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Actividad"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_nombres As New DataGridViewTextBoxColumn
            With col_nombres
                .Name = "nombres" : .DataPropertyName = "nombres"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Nombres"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_area As New DataGridViewTextBoxColumn
            With col_area
                .Name = "area" : .DataPropertyName = "area"
                .DisplayIndex = x : .Visible = False : .HeaderText = "area"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "codigo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_centro_costo As New DataGridViewTextBoxColumn
            With col_centro_costo
                .Name = "centro_costo" : .DataPropertyName = "centro_costo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "centro_costo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_cargo As New DataGridViewTextBoxColumn
            With col_cargo
                .Name = "cargo" : .DataPropertyName = "cargo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "cargo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_ingreso As New DataGridViewTextBoxColumn
            With col_ingreso
                .Name = "ingreso" : .DataPropertyName = "ingreso"
                .DisplayIndex = x : .Visible = False : .HeaderText = "ingreso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_salida As New DataGridViewTextBoxColumn
            With col_salida
                .Name = "salida" : .DataPropertyName = "salida"
                .DisplayIndex = x : .Visible = False : .HeaderText = "salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_asistencia_ingreso As New DataGridViewTextBoxColumn
            With col_asistencia_ingreso
                .Name = "asistencia_ingreso" : .DataPropertyName = "asistencia_ingreso"
                .DisplayIndex = x : .Visible = False : .HeaderText = "asistencia_ingreso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_asistencia_salida As New DataGridViewTextBoxColumn
            With col_asistencia_salida
                .Name = "asistencia_salida" : .DataPropertyName = "asistencia_salida"
                .DisplayIndex = x : .Visible = False : .HeaderText = "asistencia_salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id, col_fecha, col_inicio, col_fin, col_horas, col_actividad, col_nombres, col_area, col_codigo, _
                              col_centro_costo, col_cargo, col_ingreso, col_salida, col_asistencia_ingreso, col_asistencia_salida)
        End With
    End Sub
    Sub ConfigurardgvAprobarPlan()
        With dgvAprobarPlan
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            '.VirtualMode = True
            .RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
            End With

            x += +1
            Dim col_id_det As New DataGridViewTextBoxColumn
            With col_id_det
                .Name = "id_det" : .DataPropertyName = "id_det" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_det"
            End With

            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_nombres As New DataGridViewTextBoxColumn
            With col_nombres
                .Name = "nombres" : .DataPropertyName = "nombres"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nombres"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_hora_inicio As New DataGridViewTextBoxColumn
            With col_hora_inicio
                .Name = "hora_inicio" : .DataPropertyName = "hora_inicio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Hora Inicio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_hora_fin As New DataGridViewTextBoxColumn
            With col_hora_fin
                .Name = "hora_fin" : .DataPropertyName = "hora_fin"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Hora Fin"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_horas As New DataGridViewTextBoxColumn
            With col_horas
                .Name = "horas" : .DataPropertyName = "horas"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Horas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
            End With

            x += +1
            Dim col_costo As New DataGridViewTextBoxColumn
            With col_costo
                .Name = "costo" : .DataPropertyName = "costo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Costo" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "0.00"
                .ValueType = Type.GetType("System.Double")
                .ReadOnly = True
            End With

            x += +1
            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .Name = "id_estado" : .DataPropertyName = "id_estado"
                .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .ReadOnly = True
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_aprobado As New DataGridViewLinkColumn
            With col_aprobado
                '.Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = True : .HeaderText = "id_estado"
                .HeaderText = "Aprobar"
                .Name = "aprobado"
                .DataPropertyName = "aprobado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.Automatic
                '.FalseValue = 0
                '.TrueValue = 1
                '.ThreeState = True
                .ReadOnly = False : .DisplayIndex = x
            End With

            x += +1
            Dim col_desaprobado As New DataGridViewLinkColumn
            With col_desaprobado
                '.Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = True : .HeaderText = "id_estado"
                .HeaderText = "Desaprobar"
                .Name = "desaprobado"
                .DataPropertyName = "desaprobado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.Automatic
                '.FalseValue = 0
                '.TrueValue = 1
                '.ThreeState = True
                .ReadOnly = False : .DisplayIndex = x
            End With

            .Columns.AddRange(col_id, col_id_det, col_codigo, col_nombres, col_fecha, col_horas, col_costo, col_id_estado, col_estado, col_aprobado, col_desaprobado)
        End With
    End Sub
    Sub Configurardgv1()
        With dgv1
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo" : .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_nombres As New DataGridViewTextBoxColumn
            With col_nombres
                .Name = "nombres" : .DataPropertyName = "nombres"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Trabajador"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_codigo, col_nombres)
        End With
    End Sub
    Sub ConfigurardgvHe()
        With dgvHe
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo" : .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_nombres As New DataGridViewTextBoxColumn
            With col_nombres
                .Name = "nombres" : .DataPropertyName = "nombres"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Trabajador"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_area As New DataGridViewTextBoxColumn
            With col_area
                .Name = "area" : .DataPropertyName = "area"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Area"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_horas As New DataGridViewTextBoxColumn
            With col_horas
                .Name = "horas" : .DataPropertyName = "horas" : .DefaultCellStyle.Format = "0.00"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Horas Extras"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            x += +1
            Dim col_efectivo As New DataGridViewTextBoxColumn
            With col_efectivo
                .Name = "efectivo" : .DataPropertyName = "efectivo" : .DefaultCellStyle.Format = "0.00"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Efectivo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            x += +1
            Dim col_descanso As New DataGridViewTextBoxColumn
            With col_descanso
                .Name = "descanso" : .DataPropertyName = "descanso" : .DefaultCellStyle.Format = "0.00"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Descanso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            x += +1
            Dim col_saldo As New DataGridViewTextBoxColumn
            With col_saldo
                .Name = "saldo" : .DataPropertyName = "saldo" : .DefaultCellStyle.Format = "0.00"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Saldo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            x += +1
            Dim col_tipo As New DataGridViewTextBoxColumn
            With col_tipo
                .Name = "tipo" : .DataPropertyName = "tipo" : .DisplayIndex = x : .Visible = False : .HeaderText = "tipo"
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_fecha_compensacion As New DataGridViewTextBoxColumn
            With col_fecha_compensacion
                .Name = "fecha_compensacion" : .DataPropertyName = "fecha_compensacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Compensación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_fecha_aceptacion As New DataGridViewTextBoxColumn
            With col_fecha_aceptacion
                .Name = "fecha_aceptacion" : .DataPropertyName = "fecha_aceptacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aceptación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_fecha_envio As New DataGridViewTextBoxColumn
            With col_fecha_envio
                .Name = "fecha_envio" : .DataPropertyName = "fecha_envio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Envío"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_obrero As New DataGridViewTextBoxColumn
            With col_obrero
                .Name = "obrero" : .DataPropertyName = "obrero" : .DisplayIndex = x : .Visible = False : .HeaderText = "obrero"
            End With

            .Columns.AddRange(col_codigo, col_nombres, col_area, col_fecha, col_horas, col_efectivo, col_descanso, col_saldo, col_tipo, col_estado, col_fecha_compensacion, col_fecha_aceptacion, col_fecha_envio, col_obrero)
        End With
    End Sub
    Sub ConfigurardgvHe2()
        With dgvHe2
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo" : .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_nombres As New DataGridViewTextBoxColumn
            With col_nombres
                .Name = "nombres" : .DataPropertyName = "nombres"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Trabajador"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_area As New DataGridViewTextBoxColumn
            With col_area
                .Name = "area" : .DataPropertyName = "area"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Area"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_he2 As New DataGridViewTextBoxColumn
            With col_he2
                .Name = "he2" : .DataPropertyName = "he2" : .DefaultCellStyle.Format = "0.00"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Nº Horas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            x += +1
            Dim col_ingreso As New DataGridViewTextBoxColumn
            With col_ingreso
                .Name = "ingreso" : .DataPropertyName = "ingreso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Ingreso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_salida As New DataGridViewTextBoxColumn
            With col_salida
                .Name = "salida" : .DataPropertyName = "salida"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_asistencia_ingreso As New DataGridViewTextBoxColumn
            With col_asistencia_ingreso
                .Name = "asistencia_ingreso" : .DataPropertyName = "asistencia_ingreso"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Asis. Ingreso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_asistencia_salida As New DataGridViewTextBoxColumn
            With col_asistencia_salida
                .Name = "asistencia_salida" : .DataPropertyName = "asistencia_salida"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Asis. Salida"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_hora_inicio As New DataGridViewTextBoxColumn
            With col_hora_inicio
                .Name = "hora_inicio" : .DataPropertyName = "hora_inicio"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Hora Inicio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_hora_fin As New DataGridViewTextBoxColumn
            With col_hora_fin
                .Name = "hora_fin" : .DataPropertyName = "hora_fin"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Hora Fin"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado"
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_fecha_registro As New DataGridViewTextBoxColumn
            With col_fecha_registro
                .Name = "fecha_registro" : .DataPropertyName = "fecha_registro"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Registro"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_fecha_autorizacion As New DataGridViewTextBoxColumn
            With col_fecha_autorizacion
                .Name = "fecha_autorizacion" : .DataPropertyName = "fecha_autorizacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Autorización"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_fecha_aprobacion As New DataGridViewTextBoxColumn
            With col_fecha_aprobacion
                .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aprobación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_fecha_noautorizacion As New DataGridViewTextBoxColumn
            With col_fecha_noautorizacion
                .Name = "fecha_noautorizacion" : .DataPropertyName = "fecha_noautorizacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Desautorización"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_fecha_noaprobacion As New DataGridViewTextBoxColumn
            With col_fecha_noaprobacion
                .Name = "fecha_noaprobacion" : .DataPropertyName = "fecha_noaprobacion"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Desaprobación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_codigo, col_nombres, col_area, col_fecha, col_he2, col_ingreso, col_salida, col_asistencia_ingreso, col_asistencia_salida, _
                              col_hora_inicio, col_hora_fin, col_id_estado, col_estado, col_fecha_registro, col_fecha_autorizacion, col_fecha_aprobacion, col_fecha_noautorizacion, col_fecha_noaprobacion)
        End With
    End Sub
    Sub ConfigurardgvListaCompensacion()
        With dgvListaCompensacion
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo" : .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_nombres As New DataGridViewTextBoxColumn
            With col_nombres
                .Name = "nombres" : .DataPropertyName = "nombres" : .DisplayIndex = x : .Visible = True : .HeaderText = "Nombres"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_horas As New DataGridViewTextBoxColumn
            With col_horas
                .Name = "horas" : .DataPropertyName = "horas" : .DisplayIndex = x : .Visible = True : .HeaderText = "Horas por Compensar"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado"
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id, col_codigo, col_nombres, col_horas, col_id_estado, col_estado)
        End With
    End Sub
    Sub ConfigurardgvDetalleCompensacion()
        With dgvDetalleCompensacion
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha" : .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_horas As New DataGridViewTextBoxColumn
            With col_horas
                .Name = "horas" : .DataPropertyName = "horas" : .DisplayIndex = x : .Visible = True : .HeaderText = "Horas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_horas_compensadas As New DataGridViewTextBoxColumn
            With col_horas_compensadas
                .Name = "horas_compensadas" : .DataPropertyName = "horas_compensadas" : .DisplayIndex = x : .Visible = True : .HeaderText = "Horas Compensadas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_saldo As New DataGridViewTextBoxColumn
            With col_saldo
                .Name = "saldo" : .DataPropertyName = "saldo" : .DisplayIndex = x : .Visible = True : .HeaderText = "Horas por Compensar"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado"
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id, col_fecha, col_horas, col_horas_compensadas, col_saldo, col_id_estado, col_estado)
        End With
    End Sub
    Sub ConfigurardgvDetCompensacion()
        With dgvDetCompensacion
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha" : .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_tipo_compensacion As New DataGridViewTextBoxColumn
            With col_tipo_compensacion
                .Name = "tipo_compensacion" : .DataPropertyName = "tipo_compensacion" : .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Compensación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_idtipo_compensacion As New DataGridViewTextBoxColumn
            With col_idtipo_compensacion
                .Name = "idtipo_compensacion" : .DataPropertyName = "idtipo_compensacion" : .DisplayIndex = x : .Visible = False : .HeaderText = "idtipo_compensacion"
            End With

            x += +1
            Dim col_horas As New DataGridViewTextBoxColumn
            With col_horas
                .Name = "horas" : .DataPropertyName = "horas" : .DisplayIndex = x : .Visible = True : .HeaderText = "Horas Compensadas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion" : .DisplayIndex = x : .Visible = True : .HeaderText = "Observación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_id_estado As New DataGridViewTextBoxColumn
            With col_id_estado
                .Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_estado"
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_fecha_aceptacion As New DataGridViewTextBoxColumn
            With col_fecha_aceptacion
                .Name = "fecha_aceptacion" : .DataPropertyName = "fecha_aceptacion" : .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aceptación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_usuario_aceptacion As New DataGridViewTextBoxColumn
            With col_usuario_aceptacion
                .Name = "usuario_aceptacion" : .DataPropertyName = "usuario_aceptacion" : .DisplayIndex = x : .Visible = False
            End With

            x += +1
            Dim col_ip_aceptacion As New DataGridViewTextBoxColumn
            With col_ip_aceptacion
                .Name = "ip_aceptacion" : .DataPropertyName = "ip_aceptacion" : .DisplayIndex = x : .Visible = False
            End With

            x += +1
            Dim col_rol_aceptacion As New DataGridViewTextBoxColumn
            With col_rol_aceptacion
                .Name = "rol_aceptacion" : .DataPropertyName = "rol_aceptacion" : .DisplayIndex = x : .Visible = False
            End With

            x += +1
            Dim col_fecha_envio As New DataGridViewTextBoxColumn
            With col_fecha_envio
                .Name = "fecha_envio" : .DataPropertyName = "fecha_envio" : .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Envío"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .ReadOnly = True
            End With

            x += +1
            Dim col_usuario_envio As New DataGridViewTextBoxColumn
            With col_usuario_envio
                .Name = "usuario_envio" : .DataPropertyName = "usuario_envio" : .DisplayIndex = x : .Visible = False
            End With

            x += +1
            Dim col_ip_envio As New DataGridViewTextBoxColumn
            With col_ip_envio
                .Name = "ip_envio" : .DataPropertyName = "ip_envio" : .DisplayIndex = x : .Visible = False
            End With


            .Columns.AddRange(col_id, col_fecha, col_tipo_compensacion, col_idtipo_compensacion, col_horas, col_observacion, col_id_estado, _
                              col_estado, col_fecha_aceptacion, col_usuario_aceptacion, col_ip_aceptacion, col_rol_aceptacion, col_fecha_envio, _
                              col_usuario_envio, col_ip_envio)
        End With
    End Sub
    Sub ConfigurardgvCompensacionSolicitud()
        With dgvCompensacionSolicitud
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.ReadOnly = True
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .ReadOnly = True
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha" : .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .ReadOnly = True
            End With

            x += +1
            Dim col_tipo_compensacion As New DataGridViewTextBoxColumn
            With col_tipo_compensacion
                .Name = "tipo_compensacion" : .DataPropertyName = "tipo_compensacion" : .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Compensación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .ReadOnly = True
            End With

            x += +1
            Dim col_horas As New DataGridViewTextBoxColumn
            With col_horas
                .Name = "horas" : .DataPropertyName = "horas" : .DisplayIndex = x : .Visible = True : .HeaderText = "Horas Compensadas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .ReadOnly = True
            End With

            x += +1
            Dim col_observacion As New DataGridViewTextBoxColumn
            With col_observacion
                .Name = "observacion" : .DataPropertyName = "observacion" : .DisplayIndex = x : .Visible = True : .HeaderText = "Observación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .ReadOnly = True
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .ReadOnly = True
            End With

            x += +1
            Dim col_id_estado As New DataGridViewCheckBoxColumn
            With col_id_estado
                '.Name = "id_estado" : .DataPropertyName = "id_estado" : .DisplayIndex = x : .Visible = True : .HeaderText = "id_estado"
                .HeaderText = "Aceptado"
                .Name = "id_estado"
                .DataPropertyName = "id_estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                '.SortMode = DataGridViewColumnSortMode.NotSortable
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.Automatic
                .FalseValue = 0
                .TrueValue = 1
                '.ThreeState = True
                .ReadOnly = False : .DisplayIndex = x
            End With

            x += +1
            Dim col_fecha_aceptacion As New DataGridViewTextBoxColumn
            With col_fecha_aceptacion
                .Name = "fecha_aceptacion" : .DataPropertyName = "fecha_aceptacion" : .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aceptación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .ReadOnly = True
            End With

            x += +1
            Dim col_fecha_envio As New DataGridViewTextBoxColumn
            With col_fecha_envio
                .Name = "fecha_envio" : .DataPropertyName = "fecha_envio" : .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Envío"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .ReadOnly = True
            End With

            .Columns.AddRange(col_id, col_fecha, col_tipo_compensacion, col_horas, col_observacion, col_estado, col_id_estado, _
                              col_fecha_aceptacion, col_fecha_envio)
        End With
    End Sub
    Sub ConfigurardgvListaMantenimiento()
        With dgvListaMantenimiento
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.ReadOnly = True
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .ReadOnly = True
            End With

            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo" : .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .ReadOnly = True
            End With

            x += +1
            Dim col_nombres As New DataGridViewTextBoxColumn
            With col_nombres
                .Name = "nombres" : .DataPropertyName = "nombres" : .DisplayIndex = x : .Visible = True : .HeaderText = "Nombres"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .ReadOnly = True
            End With

            x += +1
            Dim col_cargo As New DataGridViewTextBoxColumn
            With col_cargo
                .Name = "cargo" : .DataPropertyName = "cargo"
                .DisplayIndex = x : .Visible = True : .HeaderText = "Cargo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_centro_costo As New DataGridViewTextBoxColumn
            With col_centro_costo
                .Name = "centro_costo" : .DataPropertyName = "centro_costo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Centro Costo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_remuneracion As New DataGridViewTextBoxColumn
            With col_remuneracion
                .Name = "remuneracion" : .DataPropertyName = "remuneracion"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Remuneración" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "###,###,###0.00"
            End With

            x += +1
            Dim col_horario As New DataGridViewTextBoxColumn
            With col_horario
                .Name = "horario" : .DataPropertyName = "horario"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Horario"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_horas As New DataGridViewTextBoxColumn
            With col_horas
                .Name = "horas" : .DataPropertyName = "horas"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Horas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            x += +1
            Dim col_costo As New DataGridViewTextBoxColumn
            With col_costo
                .Name = "costo" : .DataPropertyName = "costo"
                .DisplayIndex = x : .Visible = False : .HeaderText = "Costo" : .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight : .DefaultCellStyle.Format = "0.00"
            End With

            x += +1
            Dim col_obrero As New DataGridViewTextBoxColumn
            With col_obrero
                .Name = "obrero" : .DataPropertyName = "obrero" : .DisplayIndex = x : .Visible = False : .HeaderText = "obrero"
            End With

            .Columns.AddRange(col_id, col_codigo, col_nombres, col_cargo, col_centro_costo, col_remuneracion, col_horario, col_horas, col_costo, col_obrero)
        End With
    End Sub
    Sub ConfigurardgvMantenimiento()
        With dgvHorarioMantenimiento
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.ReadOnly = True
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .ReadOnly = True
            End With

            x += +1
            Dim col_dia As New DataGridViewTextBoxColumn
            With col_dia
                .Name = "dia" : .DataPropertyName = "dia" : .DisplayIndex = x : .Visible = True : .HeaderText = "Día"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .ReadOnly = True
            End With

            x += +1
            Dim col_inicio As New DataGridViewTextBoxColumn
            With col_inicio
                .Name = "inicio" : .DataPropertyName = "inicio" : .DisplayIndex = x : .Visible = True : .HeaderText = "Hora Inicio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .ReadOnly = True
            End With

            x += +1
            Dim col_fin As New DataGridViewTextBoxColumn
            With col_fin
                .Name = "fin" : .DataPropertyName = "fin" : .DisplayIndex = x : .Visible = True : .HeaderText = "Hora Fin"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .ReadOnly = True
            End With

            x += +1
            Dim col_descanso As New DataGridViewTextBoxColumn
            With col_descanso
                .Name = "descanso" : .DataPropertyName = "descanso" : .DisplayIndex = x : .Visible = True : .HeaderText = "Descanso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .ReadOnly = True
            End With

            x += +1
            Dim col_iddescanso As New DataGridViewTextBoxColumn
            With col_iddescanso
                .Name = "iddescanso" : .DataPropertyName = "iddescanso" : .DisplayIndex = x : .Visible = False : .HeaderText = "iddescanso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .ReadOnly = True
            End With

            .Columns.AddRange(col_id, col_dia, col_inicio, col_fin, col_descanso, col_iddescanso)
        End With
    End Sub
    Sub ConfigurardgvTrabajador(ByVal nivel As Integer)
        With dgvTrabajador
            'utilitario.FormatDataGridView(dgv1)
            .Columns.Clear()
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
            '.Font = New Font("tahoma", 7.0!, FontStyle.Regular)
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = True
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            '.VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            '.ReadOnly = True
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False : .HeaderText = "id"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .ReadOnly = True
            End With

            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo" : .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .ReadOnly = True
            End With

            x += +1
            Dim col_nombres As New DataGridViewTextBoxColumn
            With col_nombres
                .Name = "nombres" : .DataPropertyName = "nombres" : .DisplayIndex = x : .Visible = True : .HeaderText = "Nombres"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft : .ReadOnly = True
            End With

            Dim col_id_usuario As New DataGridViewTextBoxColumn
            With col_id_usuario
                .Name = "id_usuario" : .DataPropertyName = "id_usuario" : .DisplayIndex = x : .Visible = False : .HeaderText = "id_usuario"
            End With

            .Columns.AddRange(col_id, col_codigo, col_nombres, col_id_usuario)
        End With
    End Sub
    Sub ConfigurardgvListaSolicitud2()
        With dgvListaSolicitud2
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
            '.RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False
            End With

            x += +1
            Dim col_id_det As New DataGridViewTextBoxColumn
            With col_id_det
                .Name = "id_det" : .DataPropertyName = "id_det" : .DisplayIndex = x : .Visible = False
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha" : .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_codigo As New DataGridViewTextBoxColumn
            With col_codigo
                .Name = "codigo" : .DataPropertyName = "codigo" : .DisplayIndex = x : .Visible = True : .HeaderText = "Código"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_nombres As New DataGridViewTextBoxColumn
            With col_nombres
                .Name = "nombres" : .DataPropertyName = "nombres" : .DisplayIndex = x : .Visible = True : .HeaderText = "Nombres"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_horas As New DataGridViewTextBoxColumn
            With col_horas
                .Name = "horas" : .DataPropertyName = "horas" : .DisplayIndex = x : .Visible = True : .HeaderText = "Horas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_horas_compensadas As New DataGridViewTextBoxColumn
            With col_horas_compensadas
                .Name = "horas_compensadas" : .DataPropertyName = "horas_compensadas" : .DisplayIndex = x : .Visible = True : .HeaderText = "Horas Compensadas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_saldo As New DataGridViewTextBoxColumn
            With col_saldo
                .Name = "saldo" : .DataPropertyName = "saldo" : .DisplayIndex = x : .Visible = True : .HeaderText = "Horas por Compensar"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_efectivo As New DataGridViewTextBoxColumn
            With col_efectivo
                .Name = "efectivo" : .DataPropertyName = "efectivo" : .DisplayIndex = x : .Visible = True : .HeaderText = "Efectivo"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_descanso As New DataGridViewTextBoxColumn
            With col_descanso
                .Name = "descanso" : .DataPropertyName = "descanso" : .DisplayIndex = x : .Visible = True : .HeaderText = "Descanso"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado" : .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_observaciones As New DataGridViewTextBoxColumn
            With col_observaciones
                .Name = "observaciones" : .DataPropertyName = "observaciones" : .DisplayIndex = x : .Visible = False : .HeaderText = "observaciones"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            Dim col_idestado As New DataGridViewTextBoxColumn
            With col_idestado
                .Name = "idestado" : .DataPropertyName = "idestado" : .DisplayIndex = x : .Visible = False
            End With

            .Columns.AddRange(col_id, col_id_det, col_fecha, col_codigo, col_nombres, col_horas, col_horas_compensadas, col_saldo, col_efectivo, col_descanso, col_estado, col_observaciones, col_idestado)
        End With
    End Sub
    Sub ConfigurardgvDetalleSolicitud2()
        With dgvDetalleSolicitud2
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
            '.RowHeadersVisible = False
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
            .ReadOnly = True
            '.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            '.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 179)
            '.DefaultCellStyle.SelectionForeColor = Color.Blacks
            '.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF

            Dim x As Integer = 0
            Dim col_id As New DataGridViewTextBoxColumn
            With col_id
                .Name = "id" : .DataPropertyName = "id" : .DisplayIndex = x : .Visible = False
            End With

            x += +1
            Dim col_fecha As New DataGridViewTextBoxColumn
            With col_fecha
                .Name = "fecha" : .DataPropertyName = "fecha" : .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Solicitud"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_horas As New DataGridViewTextBoxColumn
            With col_horas
                .Name = "horas" : .DataPropertyName = "horas" : .DisplayIndex = x : .Visible = True : .HeaderText = "Horas"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_idtipo_compensacion As New DataGridViewTextBoxColumn
            With col_idtipo_compensacion
                .Name = "idtipo_compensacion" : .DataPropertyName = "idtipo_compensacion" : .DisplayIndex = x : .Visible = False
            End With

            x += +1
            Dim col_tipo_compensacion As New DataGridViewTextBoxColumn
            With col_tipo_compensacion
                .Name = "tipo_compensacion" : .DataPropertyName = "tipo_compensacion" : .DisplayIndex = x : .Visible = True : .HeaderText = "Tipo Compensación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_idestado As New DataGridViewTextBoxColumn
            With col_idestado
                .Name = "idestado" : .DataPropertyName = "idestado" : .DisplayIndex = x : .Visible = False
            End With

            x += +1
            Dim col_estado As New DataGridViewTextBoxColumn
            With col_estado
                .Name = "estado" : .DataPropertyName = "estado" : .DisplayIndex = x : .Visible = True : .HeaderText = "Estado"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_fecha_aprobacion As New DataGridViewTextBoxColumn
            With col_fecha_aprobacion
                .Name = "fecha_aprobacion" : .DataPropertyName = "fecha_aprobacion" : .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Aprobación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_fecha_noaprobacion As New DataGridViewTextBoxColumn
            With col_fecha_noaprobacion
                .Name = "fecha_noaprobacion" : .DataPropertyName = "fecha_noaprobacion" : .DisplayIndex = x : .Visible = True : .HeaderText = "Fecha Desaprobación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_observaciones As New DataGridViewTextBoxColumn
            With col_observaciones
                .Name = "observaciones" : .DataPropertyName = "observaciones" : .DisplayIndex = x : .Visible = True : .HeaderText = "Observación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            x += +1
            Dim col_observacion_noaprobacion As New DataGridViewTextBoxColumn
            With col_observacion_noaprobacion
                .Name = "observacion_noaprobacion" : .DataPropertyName = "observacion_noaprobacion" : .DisplayIndex = x : .Visible = True : .HeaderText = "Observación Desaprobación"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells : .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            .Columns.AddRange(col_id, col_fecha, col_horas, col_idtipo_compensacion, col_tipo_compensacion, col_idestado, col_estado, col_fecha_aprobacion, col_fecha_noaprobacion, col_observaciones, col_observacion_noaprobacion)
        End With
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Try
            Cursor = Cursors.WaitCursor
            Me.dgvPlanificacion.DataSource = Nothing
            Me.ConfigurardgvPlanificacion()
            dtPlanificacion.Rows.Clear()
            dtHora.Rows.Clear()

            dtPlanificacion = ListarTrabajadores(dtoUSUARIOS.IdLogin)

            AgregarFecha(dgvPlanificacion)
            ConfigurarColumna(1)
            SeteaColumna(dgvPlanificacion)
            Me.Total()

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub SeteaColumna(ByVal dgv As DataGridView)
        With dgv
            For Each row As DataGridViewRow In dgv.Rows
                row.Cells("costo").Value = DBNull.Value
            Next
        End With
    End Sub

    Sub AgregarFecha(ByVal dgv As DataGridView, Optional ByVal opcion As Integer = 0)
        Dim datFecha As Date
        Dim intDias As Integer
        Dim col As DataColumn
        Dim intColumnas As Integer

        If opcion = 0 Then
            intColumnas = intColumnaFija
            intDias = DateDiff(DateInterval.Day, CDate(Me.dtpInicio.Value.ToShortDateString), CDate(Me.dtpFin.Value.ToShortDateString))
            datFecha = DateAdd(DateInterval.Day, -1, CDate(Me.dtpInicio.Value.ToShortDateString))
        Else
            intColumnas = intColumnaFijaAprobacion
            intDias = DateDiff(DateInterval.Day, CDate(Me.lblInicioAprobarPlan.Text), CDate(Me.lblFinAprobarPlan.Text))
            datFecha = DateAdd(DateInterval.Day, -1, CDate(Me.lblInicioAprobarPlan.Text))
        End If

        If dtPlanificacion.Columns.Count > intColumnas Then
            For i As Integer = dtPlanificacion.Columns.Count - 1 To intColumnas Step -1
                dtPlanificacion.Columns.RemoveAt(i)
            Next
        End If

        For i As Integer = 1 To intDias + 1
            datFecha = DateAdd(DateInterval.Day, 1, datFecha)
            col = New DataColumn
            col.Caption = datFecha
            col.ColumnName = "hora" & i
            col.DataType = Type.GetType("System.String")
            col.AllowDBNull = True
            dtPlanificacion.Columns.Add(col)

            col = New DataColumn
            col.Caption = datFecha
            col.ColumnName = "costo" & i
            col.DataType = Type.GetType("System.Double")
            col.AllowDBNull = True
            dtPlanificacion.Columns.Add(col)
        Next
        dgv.DataSource = dtPlanificacion
    End Sub

    Sub ConfigurarColumna(ByVal opcion As Integer)
        If Me.dgvPlanificacion.Rows.Count = 0 Then Return
        Dim intDias As Integer = DateDiff(DateInterval.Day, CDate(Me.dtpInicio.Value.ToShortDateString), CDate(Me.dtpFin.Value.ToShortDateString))
        Dim intColGrid As Integer = intColumnaFija - 1
        Dim intOpcion As Integer
        intOpcion = IIf(Me.rbtHora.Checked, 1, 2)
        For i As Integer = 1 To intDias + 1
            intColGrid += 2
            If intOpcion = 1 Then
                Me.dgvPlanificacion.Columns(intColGrid - 1).Visible = True
                Me.dgvPlanificacion.Columns(intColGrid - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.dgvPlanificacion.Columns(intColGrid).Visible = False
            Else
                Me.dgvPlanificacion.Columns(intColGrid - 1).Visible = False
                Me.dgvPlanificacion.Columns(intColGrid).Visible = True
                Me.dgvPlanificacion.Columns(intColGrid).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.dgvPlanificacion.Columns(intColGrid).DefaultCellStyle.Format = "0.00"
            End If
            RemoveHandler dgvPlanificacion.CellValueChanged, AddressOf dgvPlanificacion_CellValueChanged
            Me.dgvPlanificacion.Columns(intColGrid - 1).HeaderText = dtPlanificacion.Columns(intColGrid - 1).Caption
            Me.dgvPlanificacion.Columns(intColGrid).HeaderText = dtPlanificacion.Columns(intColGrid).Caption
            AddHandler dgvPlanificacion.CellValueChanged, AddressOf dgvPlanificacion_CellValueChanged
        Next
    End Sub

    Private Sub dgvPlanificacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPlanificacion.DoubleClick
        Try
            With Me.dgvPlanificacion
                Dim intColumna As Integer = CType(sender, DataGridView).CurrentCell.ColumnIndex
                If intColumna >= intColumnaFija Then
                    Cursor = Cursors.AppStarting
                    Dim frm As New frmHoraExtraPlan
                    frm.Fecha = .Columns(intColumna).HeaderText
                    frm.Codigo = .CurrentRow.Cells("codigo").Value
                    frm.Horario = .CurrentRow.Cells("horario").Value
                    frm.Trabajador = .CurrentRow.Cells("nombres").Value
                    frm.Remuneracion = .CurrentRow.Cells("remuneracion").Value
                    If blnNuevo Then
                        frm.Estado = 1
                    Else
                        frm.Estado = Me.dgvLista.CurrentRow.Cells("id_estado").Value
                    End If
                    Dim dtHoraClon As DataTable
                    Dim rows() As DataRow
                    dtHoraClon = dtHora.Copy
                    If dtHora.Rows.Count > 0 Then
                        Try
                            dtHoraClon = dtHoraClon.Select("fecha='" & frm.Fecha & "' and codigo='" & frm.Codigo & "'").CopyToDataTable
                        Catch ex As Exception
                            Dim s As String = ex.Message
                            dtHoraClon.Rows.Clear()
                        End Try
                        dtHoraClon.AcceptChanges()
                    End If
                    frm.Color = Me.dgvPlanificacion(.CurrentCell.ColumnIndex, .CurrentRow.Index).Style.BackColor
                    frm.dtHora = dtHoraClon
                    frm.ShowDialog()
                    Cursor = Cursors.Default
                    If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                        Aceptar(frm)
                    End If
                End If
            End With
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub AgregarHora(ByVal dt As DataTable, ByVal codigo As String)
        Static i As Integer
        i = i + 1
        With dt
            If dtHora.Rows.Count > 0 Then
                Dim col(1) As Object
                col(0) = Me.dgvPlanificacion.Columns(Me.dgvPlanificacion.CurrentCell.ColumnIndex).HeaderText 'dt.Rows(0).Item("fecha")
                col(1) = codigo
                EliminarFila(col(0), col(1))
            End If
            With dtHora
                If i = 1 Then
                    dt.Merge(dtHora, True)
                    dtHora = dt.Clone
                End If
                For Each row1 As DataRow In dt.Rows
                    dtHora.ImportRow(row1)
                Next
            End With
        End With
    End Sub

    Sub Aceptar(ByVal frm As frmHoraExtraPlan)
        Dim strColumna As String
        Dim intColumna As Integer
        With Me.dgvPlanificacion
            If Me.rbtHora.Checked Then
                intColumna = .CurrentCell.ColumnIndex
                strColumna = .Columns(intColumna).Name
                .CurrentRow.Cells(strColumna).Value = frm.lblTotalHoras.Text
                .CurrentRow.Cells(strColumna).Style.BackColor = Color.White
                .CurrentRow.Cells(strColumna).Style.ForeColor = Color.Black

                intColumna = .CurrentCell.ColumnIndex + 1
                strColumna = .Columns(intColumna).Name
                .CurrentRow.Cells(strColumna).Value = frm.lblTotalCosto.Text
                .CurrentRow.Cells(strColumna).Style.BackColor = Color.White
                .CurrentRow.Cells(strColumna).Style.ForeColor = Color.Black
            Else
                intColumna = .CurrentCell.ColumnIndex
                strColumna = .Columns(intColumna - 1).Name
                .CurrentRow.Cells(strColumna).Value = frm.lblTotalHoras.Text
                .CurrentRow.Cells(strColumna).Style.BackColor = Color.White
                .CurrentRow.Cells(strColumna).Style.ForeColor = Color.Black

                intColumna = .CurrentCell.ColumnIndex
                strColumna = .Columns(intColumna).Name
                .CurrentRow.Cells(strColumna).Value = frm.lblTotalCosto.Text
                .CurrentRow.Cells(strColumna).Style.BackColor = Color.White
                .CurrentRow.Cells(strColumna).Style.ForeColor = Color.Black
            End If
            Dim dt As DataTable = dtPlanificacion
            AgregarHora(frm.dtHora, frm.Codigo)
        End With
    End Sub

    Private Sub rbtHora_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtHora.CheckedChanged
        ConfigurarColumna(1)
    End Sub

    Sub EliminarFila(ByVal fecha As String, ByVal codigo As String)
        For Each row As DataRow In dtHora.Rows
            If row.Item("fecha") = fecha And row.Item("codigo") = codigo Then
                row.Delete()
            End If
        Next
        dtHora.AcceptChanges()
        Dim dt As DataTable = dtPlanificacion
    End Sub

    Private Sub dgvPlanificacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvPlanificacion.KeyDown
        If e.KeyCode = Keys.Delete Then
            If Me.dgvPlanificacion.Rows.Count > 0 Then
                If Me.dgvPlanificacion.CurrentCell.ColumnIndex < intColumnaFija Then Return
                If Me.dgvPlanificacion.CurrentRow.Cells(Me.dgvPlanificacion.CurrentCell.ColumnIndex).Value.ToString.Trim.Length = 0 Then Return
                Dim color As Color = Me.dgvPlanificacion.CurrentRow.Cells(Me.dgvPlanificacion.CurrentCell.ColumnIndex).Style.BackColor
                If Not color = Drawing.Color.Silver Then
                    Dim strCodigo As String, strMensaje As String, strFecha As String, strTrabajador As String
                    strCodigo = Me.dgvPlanificacion.CurrentRow.Cells("codigo").Value
                    strFecha = Me.dgvPlanificacion.Columns(Me.dgvPlanificacion.CurrentCell.ColumnIndex).HeaderText
                    strTrabajador = Me.dgvPlanificacion.CurrentRow.Cells("codigo").Value & " " & Me.dgvPlanificacion.CurrentRow.Cells("nombres").Value
                    strMensaje = "Está seguro de eliminar la planificación con" & Chr(13) & Chr(13) & "Fecha : " & strFecha & Chr(13) & "Trabajador : " & strTrabajador & "?"
                    Dim dlgRepuesta As DialogResult
                    dlgRepuesta = MessageBox.Show(strMensaje, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If dlgRepuesta = Windows.Forms.DialogResult.Yes Then
                        EliminarFila(strFecha, strCodigo)
                        If Me.rbtHora.Checked Then
                            Me.dgvPlanificacion.CurrentRow.Cells(Me.dgvPlanificacion.CurrentCell.ColumnIndex).Value = DBNull.Value
                            Me.dgvPlanificacion.CurrentRow.Cells(Me.dgvPlanificacion.CurrentCell.ColumnIndex).Style.BackColor = Drawing.Color.White

                            Me.dgvPlanificacion.CurrentRow.Cells(Me.dgvPlanificacion.CurrentCell.ColumnIndex + 1).Value = DBNull.Value
                            Me.dgvPlanificacion.CurrentRow.Cells(Me.dgvPlanificacion.CurrentCell.ColumnIndex + 1).Style.BackColor = Drawing.Color.White
                        Else
                            Me.dgvPlanificacion.CurrentRow.Cells(Me.dgvPlanificacion.CurrentCell.ColumnIndex).Value = DBNull.Value
                            Me.dgvPlanificacion.CurrentRow.Cells(Me.dgvPlanificacion.CurrentCell.ColumnIndex).Style.BackColor = Drawing.Color.White

                            Me.dgvPlanificacion.CurrentRow.Cells(Me.dgvPlanificacion.CurrentCell.ColumnIndex - 1).Value = DBNull.Value
                            Me.dgvPlanificacion.CurrentRow.Cells(Me.dgvPlanificacion.CurrentCell.ColumnIndex - 1).Style.BackColor = Drawing.Color.White
                        End If
                        Subtotal()
                        Total()
                    End If
                End If
            End If
        End If
    End Sub

    Sub Subtotal()
        With Me.dgvPlanificacion
            Dim dblCosto As Double
            Dim intMinutos As Integer, intHoras As Integer
            dblCosto = 0 : intHoras = 0 : intMinutos = 0
            For col As Integer = intColumnaFija To dgvPlanificacion.Columns.Count - 1
                If dgvPlanificacion.Columns(col).Name.Trim.Substring(0, 5) = "costo" Then
                    If Not (IsDBNull(dgvPlanificacion.Rows(dgvPlanificacion.CurrentCell.RowIndex).Cells(col).Value)) Then
                        dblCosto = dblCosto + dgvPlanificacion.Rows(dgvPlanificacion.CurrentCell.RowIndex).Cells(col).Value
                    End If
                Else
                    If Not (IsDBNull(dgvPlanificacion.Rows(dgvPlanificacion.CurrentCell.RowIndex).Cells(col).Value)) Then
                        If dgvPlanificacion.Rows(dgvPlanificacion.CurrentCell.RowIndex).Cells(col).Value.ToString.Trim.Length > 0 Then
                            intHoras = intHoras + dgvPlanificacion.Rows(dgvPlanificacion.CurrentCell.RowIndex).Cells(col).Value.ToString.Substring(0, 2)
                            intMinutos = intMinutos + dgvPlanificacion.Rows(dgvPlanificacion.CurrentCell.RowIndex).Cells(col).Value.ToString.Substring(3, 2)
                        End If
                    End If
                End If
            Next
            If intMinutos >= 60 Then
                Do While intMinutos >= 60
                    intMinutos = intMinutos - 60
                    intHoras = intHoras + 1
                Loop
            End If
            If intHoras + intMinutos > 0 Then
                .CurrentRow.Cells("horas").Value = Format(intHoras, "00") & ":" & Format(intMinutos, "00")
            Else
                .CurrentRow.Cells("horas").Value = DBNull.Value
            End If
            If dblCosto > 0 Then
                .CurrentRow.Cells("costo").Value = Format(dblCosto, "0.00")
            Else
                .CurrentRow.Cells("costo").Value = DBNull.Value
            End If
        End With
    End Sub

    Sub Total()
        Dim dblCosto As Double
        Dim strHoras As String

        strHoras = SumaHoras(Me.dgvPlanificacion, "horas")
        dblCosto = SumaGrid2(Me.dgvPlanificacion, "costo")

        Me.lblHoras.Text = strHoras
        Me.lblCosto.Text = Format(dblCosto, "###,###,###0.00")

        Me.tsbGrabar.Enabled = strHoras.Trim <> "00:00"
    End Sub

    Sub TotalAprobacion()
        Dim dblCosto As Double
        Dim strHoras As String

        strHoras = SumaHoras(Me.dgvAprobarPlan, "horas")
        dblCosto = SumaGrid2(Me.dgvAprobarPlan, "costo")

        Me.lblHorasAprobarPlan.Text = strHoras
        Me.lblCostoAprobarPlan.Text = Format(dblCosto, "###,###,###0.00")

        'Me.tsbGrabar.Enabled = strHoras.Trim <> "00:00"
    End Sub

    Private Sub dgvPlanificacion_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPlanificacion.CellValueChanged
        If e.ColumnIndex > intColumnaFija Then
            Subtotal()
            Total()
        End If
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Sub Grabar()
        Try
            Cursor = Cursors.AppStarting
            Dim intID As Integer, intIdDet As Integer
            Dim rowsHora() As DataRow
            Dim strHoras As String, strHoras25 As String, strHoras35 As String, strHoras100 As String
            Dim dblCosto As Double, dblCosto25 As Double, dblCosto35 As Double, dblCosto100 As Double
            strHoras = Me.lblHoras.Text.Trim
            dblCosto = CType(Me.lblCosto.Text, Double)

            Dim obj As New Cls_HoraExtra_LN
            If blnNuevo Then
                intID = 0
            Else
                intID = Me.dgvLista.CurrentRow.Cells("id").Value
            End If
            intID = obj.GrabarPlanificacion(intID, Me.dtpInicio.Value.ToShortDateString, Me.dtpFin.Value.ToShortDateString, dtoUSUARIOS.CentroCosto, _
                                            dtoUSUARIOS.IdLogin, strHoras, dblCosto, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
            With dtPlanificacion
                For Each row As DataRow In dtPlanificacion.Rows
                    row.Item("costo") = IIf(IsDBNull(row.Item("costo")), 0, row.Item("costo"))
                    If row("horas").ToString.Trim.Length > 0 Then
                        intIdDet = obj.GrabarPlanificacionDetalle(intID, row("codigo"), row("nombres"), row("cargo"), _
                                                       row("centro_costo"), row("remuneracion"), _
                                                       row("horario"), row("horas"), row("costo"))
                        rowsHora = dtHora.Select("codigo='" & row("codigo") & "'")
                        For Each rowi As DataRow In rowsHora
                            strHoras25 = "" & rowi("hora25")
                            strHoras35 = "" & rowi("hora35")
                            strHoras100 = "" & rowi("hora100")
                            dblCosto25 = IIf(IsDBNull(rowi("costo25")), 0, rowi("costo25"))
                            dblCosto35 = IIf(IsDBNull(rowi("costo35")), 0, rowi("costo35"))
                            dblCosto100 = IIf(IsDBNull(rowi("costo100")), 0, rowi("costo100"))
                            obj.GrabarPlanificacionDetalle2(intID, intIdDet, rowi("fecha"), rowi("inicio"), rowi("fin"), rowi("id_tipo_dia"), rowi("id_motivo"), _
                                                            rowi("id_compensacion"), rowi("actividad"), rowi("hora"), rowi("costo"), _
                                                            "" & rowi("ingreso"), "" & rowi("salida"), _
                                                            strHoras25, dblCosto25, strHoras35, dblCosto35, strHoras100, dblCosto100, rowi("id_estado"))
                        Next
                    End If
                Next
            End With
            Me.tabPlanificacionDetalle.SelectedIndex = 0
            Me.btnConsultarLista_Click(Nothing, Nothing)
            Me.btnConsultarLista.Focus()

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnConsultarLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarLista.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_HoraExtra_LN
            Dim dt As DataTable

            'dt = obj.ListarPlanificacion(Me.dtpInicioLista.Value.ToShortDateString, Me.dtpFinLista.Value.ToShortDateString, dtoUSUARIOS.CentroCosto, Me.cboEstado.SelectedIndex, -1)
            dt = obj.ListarPlanificacionCab(Me.dtpInicioLista.Value.ToShortDateString, Me.dtpFinLista.Value.ToShortDateString, dtoUSUARIOS.IdLogin, Me.cboEstado.SelectedIndex, -1)
            Me.dgvLista.DataSource = dt
            Me.tsbEditar.Enabled = Me.dgvLista.Rows.Count > 0
            If Me.dgvLista.Rows.Count > 0 Then
                Me.tsbAnular.Enabled = Me.dgvLista.CurrentRow.Cells("id_estado").Value = 1
            Else
                Me.tsbAnular.Enabled = False
            End If
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub EditarPlanificacion()
        With Me.dgvLista
            blnNuevo = False
            Me.btnActualizar.Enabled = False
            Me.dtpInicio.Enabled = False
            Me.dtpFin.Enabled = False
            Dim dt As DataTable, dt2 As DataTable, dt3 As New DataTable
            Me.dtpInicio.Value = .CurrentRow.Cells("fecha_inicio").Value
            Me.dtpFin.Value = .CurrentRow.Cells("fecha_fin").Value

            dtPlanificacion = ListarTrabajadores(dtoUSUARIOS.IdLogin)
            AgregarFecha(dgvPlanificacion)
            ConfigurarColumna(1)
            SeteaColumna(dgvPlanificacion)

            Dim obj As New Cls_HoraExtra_LN
            dt = obj.ListarPlanificacion(.CurrentRow.Cells("id").Value)
            Dim rowi() As DataRow
            For Each row As DataRow In dt.Rows
                rowi = dtPlanificacion.Select("codigo='" & row("codigo") & "'")
                If rowi.Length > 0 Then
                    rowi(0).Item("horas") = row("horas")
                    rowi(0).Item("costo") = row("costo")

                    Dim strFecha As String = Me.dtpInicio.Value.ToShortDateString
                    Dim strFecha2 As String = "01/01/2018"
                    Dim strColumna As String
                    Dim intDia As Integer
                    dt2 = obj.ListarPlanificacionDetalle(row("id"))
                    dt3.Merge(dt2, True)
                    Dim dblCosto As Double = 0
                    Dim intMinutos As Integer = 0, intHoras As Integer = 0
                    Dim strHoras As String = ""
                    For Each rowi2 As DataRow In dt2.Rows
                        If CType(strFecha2, Date) <> rowi2("fecha") And strFecha2 <> "01/01/2018" Then
                            intDia = Integer.Parse(DateDiff(DateInterval.Day, CType(strFecha, Date), CType(strFecha2, Date))) + 1
                            If dblCosto > 0 Then
                                strColumna = "costo" & intDia
                                rowi(0).Item(strColumna) = dblCosto
                                dblCosto = 0
                            End If
                            If intMinutos >= 60 Then
                                Do While intMinutos >= 60
                                    intMinutos = intMinutos - 60
                                    intHoras = intHoras + 1
                                Loop
                            End If
                            strHoras = Format(intHoras, "00") & ":" & Format(intMinutos, "00")
                            strColumna = "hora" & intDia
                            rowi(0).Item(strColumna) = strHoras
                            intHoras = 0 : intMinutos = 0
                        End If
                        strFecha2 = rowi2("fecha")
                        dblCosto += rowi2("costo")
                        intHoras += Val(rowi2("hora").ToString.Substring(0, 2))
                        intMinutos += Val(rowi2("hora").ToString.Substring(3, 2))
                    Next
                    intDia = Integer.Parse(DateDiff(DateInterval.Day, CType(strFecha, Date), CType(strFecha2, Date))) + 1
                    If dblCosto > 0 Then
                        strColumna = "costo" & intDia
                        rowi(0).Item(strColumna) = dblCosto
                    End If
                    If intMinutos >= 60 Then
                        Do While intMinutos >= 60
                            intMinutos = intMinutos - 60
                            intHoras = intHoras + 1
                        Loop
                    End If
                    strHoras = Format(intHoras, "00") & ":" & Format(intMinutos, "00")
                    strColumna = "hora" & intDia
                    rowi(0).Item(strColumna) = strHoras
                End If
            Next
            Total()
            dgvPlanificacion.Columns("id").Visible = False

            Dim dt4 As DataTable
            dt4 = obj.ListarPlanificacionDetalle2(.CurrentRow.Cells("id").Value)
            dtHora = dt4

            Me.tabPlanificacionDetalle.SelectedIndex = 1
            For Each row2 As DataRow In dt3.Rows
                Dim intFila As Integer
                Dim strColumna As String
                Dim intDia As Integer
                Dim strFecha As String, strFecha2 As String
                Dim intEstado As Integer

                strFecha = Me.dtpInicio.Value.ToShortDateString
                strFecha2 = Format(row2.Item("fecha"), "dd/MM/yyyy")

                intDia = Integer.Parse(DateDiff(DateInterval.Day, CType(strFecha, Date), CType(strFecha2, Date))) + 1
                intFila = ValorGrid(Me.dgvPlanificacion, "codigo", row2.Item("codigo").ToString)
                intEstado = row2.Item("estado")

                If row2.Item("hora") <> "00:00" Then
                    strColumna = "hora" & intDia
                    If intEstado = 2 Then
                        Me.dgvPlanificacion.Rows(intFila).Cells(strColumna).Style.BackColor = Color.Silver
                    ElseIf intEstado = 3 Then
                        Me.dgvPlanificacion.Rows(intFila).Cells(strColumna).Style.BackColor = Color.Red
                        Me.dgvPlanificacion.Rows(intFila).Cells(strColumna).Style.ForeColor = Color.White
                    End If
                End If
                If row2.Item("costo") > 0 Then
                    strColumna = "costo" & intDia
                    If intEstado = 2 Then
                        Me.dgvPlanificacion.Rows(intFila).Cells(strColumna).Style.BackColor = Color.Silver
                    ElseIf intEstado = 3 Then
                        Me.dgvPlanificacion.Rows(intFila).Cells(strColumna).Style.BackColor = Color.Red
                        Me.dgvPlanificacion.Rows(intFila).Cells(strColumna).Style.ForeColor = Color.White
                    End If
                End If
            Next
        End With
    End Sub

    Sub EditarSolicitud()
        With Me.dgvListaSolicitud
            blnNuevoSolicitud = False
            blnNuevoRegistro = False
            'Me.txtCodigo.Enabled = False
            Me.dtpFechaSolicitud.Enabled = False

            Me.lblNombresSolicitud.Text = .CurrentRow.Cells("nombres").Value
            Me.lblArea.Text = .CurrentRow.Cells("area").Value
            'Me.txtCodigoListaSolicitud.Text = .CurrentRow.Cells("codigo").Value
            Me.lblCentroCosto.Text = .CurrentRow.Cells("centro_costo").Value
            Me.lblCargo.Text = .CurrentRow.Cells("cargo").Value

            Me.dtpFechaSolicitud.Value = .CurrentRow.Cells("fecha").Value
            Me.lblIngresoHorarioSolicitud.Text = "" & .CurrentRow.Cells("ingreso").Value
            Me.lblSalidaHorarioSolicitud.Text = "" & .CurrentRow.Cells("salida").Value
            Me.lblIngresoAsistenciaSolicitud.Text = IIf(IsDBNull(.CurrentRow.Cells("asistencia_ingreso").Value), "", .CurrentRow.Cells("asistencia_ingreso").Value)
            Me.lblSalidaAsistenciaSolicitud.Text = IIf(IsDBNull(.CurrentRow.Cells("asistencia_salida").Value), "", .CurrentRow.Cells("asistencia_salida").Value)

            Dim obj As New Cls_HoraExtra_LN
            Dim dt As DataTable = obj.ListarSolicitud(.CurrentRow.Cells("id").Value)
            dtSolicitud = dt.Copy
            dgvSolicitud.DataSource = dtSolicitud
            MostrarSolicitud(0)

            Me.tabSolicitudDetalle.SelectedIndex = 1
            If .CurrentRow.Cells("id_estado").Value = 1 Then
                Me.dtpInicioSolicitud.Enabled = True
                Me.dtpFinSolicitud.Enabled = True
                Me.txtActividadSolicitud.Enabled = True
                Me.btnAgregarSolicitud.Enabled = True
                Me.btnNuevoSolicitud.Enabled = True
                Me.btnEliminarSolicitud.Enabled = True
                Me.tsbGrabar.Enabled = True
            Else
                Me.dtpInicioSolicitud.Enabled = False
                Me.dtpFinSolicitud.Enabled = False
                Me.txtActividadSolicitud.Enabled = False
                Me.btnAgregarSolicitud.Enabled = False
                Me.btnNuevoSolicitud.Enabled = False
                Me.btnEliminarSolicitud.Enabled = False
                Me.tsbGrabar.Enabled = False
            End If
        End With
    End Sub

    Sub EditarAutorizacion()
        blnEditarAutorizacion = True
        With Me.dgvListaAutorizacion
            Me.lblFechaAutorizacion.Text = .CurrentRow.Cells("fecha").Value
            Me.lblTrabajadorAutorizacion.Text = .CurrentRow.Cells("codigo").Value & " " & .CurrentRow.Cells("nombres").Value
            Me.lblAreaAutorizacion.Text = .CurrentRow.Cells("area").Value
            Me.lblCentroCostoAutorizacion.Text = .CurrentRow.Cells("centro_costo").Value
            Me.lblCargoAutorizacion.Text = .CurrentRow.Cells("cargo").Value
            Me.lblHorarioAutorizacion.Text = .CurrentRow.Cells("ingreso").Value & "-" & .CurrentRow.Cells("salida").Value
            Me.lblAsistenciaAutorizacion.Text = .CurrentRow.Cells("asistencia_ingreso").Value & "-" & .CurrentRow.Cells("asistencia_salida").Value
            Me.lblHorasAutorizacion.Text = .CurrentRow.Cells("horas").Value

            'Me.cboHorasAutorizacion.Items.Clear()
            'Me.cboHorasAutorizacion.Items.Add("00:00")
            'For i As Integer = 1 To Val(.CurrentRow.Cells("horas").Value)
            '    Me.cboHorasAutorizacion.Items.Add(Format(i, "00") + ":00")
            '    If i < Val(.CurrentRow.Cells("horas").Value) Then
            '        Me.cboHorasAutorizacion.Items.Add(Format(i, "00") + ":30")
            '    End If
            'Next
            'Me.cboHorasAutorizacion.SelectedIndex = Me.cboHorasAutorizacion.Items.Count - 1

            'Obtiene Tipo dia
            Dim dtHorario As DataTable
            Dim strFecha As String = .CurrentRow.Cells("fecha").Value
            Dim strHorario As String = .CurrentRow.Cells("horario").Value
            Dim blnFeriado As Boolean = EsFeriado(strFecha)
            dtHorario = ModHoraExtra.ListarHorario(strHorario, .CurrentRow.Cells("codigo").Value)
            Dim intDia As Integer = CType(strFecha, Date).DayOfWeek
            Dim blnDescanso As Boolean = dtHorario.Rows(0).Item(intDia) = 1
            Dim intTipoDia As Integer
            If blnDescanso Or blnFeriado Then
                intTipoDia = 2
                Me.lblTipoDiaAutorizacion.Text = "DOBLE"
            Else
                intTipoDia = 1
                Me.lblTipoDiaAutorizacion.Text = "SIMPLE"
            End If
            Dim dblRemuneracion As Double = .CurrentRow.Cells("remuneracion").Value

            Dim obj As New Cls_HoraExtra_LN
            Dim dt As DataTable = obj.ListarSolicitud(.CurrentRow.Cells("id").Value)
            dgvSobretiempoAutorizacion.DataSource = dt

            'Dim dblCosto As Double = CalculaSobretiempo(dt, "horas", dblRemuneracion, intTipoDia)
            'Me.lblCostoAutorizacion.Text = Format(dblCosto, "0.00")
        End With
        Me.pnlAutorizacion.Enabled = True
        Me.tabAutorizacionDetalle.SelectedIndex = 1
    End Sub

    Function CalculaSobretiempo(ByVal dt As DataTable, ByVal columna As String, ByVal remuneracion As Double, ByVal TipoDia As Integer) As Double
        Dim intHoras As Integer, intMinutos As Integer
        Dim dblTiempo As Double, dblCosto As Double, dblRemuneracion As Double

        dblRemuneracion = remuneracion / 240
        For i As Integer = 0 To dt.Rows.Count - 1
            intHoras = CType(dt.Rows(i)(columna).ToString.Substring(0, 2), Integer)
            intMinutos = CType(dt.Rows(i)(columna).ToString.Substring(3, 2), Integer)
            dblTiempo += intHoras + (intMinutos / 60)
        Next
        If TipoDia = 1 Then
            If dblTiempo <= 2 Then
                dblCosto = dblTiempo * dblRemuneracion * 0.25
            Else
                dblCosto = (2 * dblRemuneracion * 0.25) + ((dblTiempo - 2) * dblRemuneracion * 0.35)
            End If
        Else
            dblCosto = dblTiempo * dblRemuneracion * 1
        End If
        Return dblCosto
    End Function

    'Function CalculaSobretiempo(ByVal remuneracion As Double, ByVal TipoDia As Integer) As Double
    '    Dim intHoras As Integer, intMinutos As Integer
    '    Dim dblTiempo As Double, dblCosto As Double, dblRemuneracion As Double

    '    dblRemuneracion = remuneracion / 240
    '    intHoras = CType(Me.cboHorasAutorizacion.Text.Substring(0, 2), Integer)
    '    intMinutos = CType(Me.cboHorasAutorizacion.Text.Substring(3, 2), Integer)
    '    dblTiempo += intHoras + (intMinutos / 60)
    '    If TipoDia = 1 Then
    '        If dblTiempo <= 2 Then
    '            dblCosto = dblTiempo * dblRemuneracion * 0.25
    '        Else
    '            dblCosto = (2 * dblRemuneracion * 0.25) + ((dblTiempo - 2) * dblRemuneracion * 0.35)
    '        End If
    '    Else
    '        dblCosto = dblTiempo * dblRemuneracion * 1
    '    End If
    '    Return dblCosto
    'End Function

    Private Sub tsbEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbEditar.Click
        Try
            Cursor = Cursors.WaitCursor
            If tabHoraExtra.SelectedTab Is tabHoraExtra.TabPages("tabPlanificacion") Then
                'If Me.tabHoraExtra.SelectedIndex = 0 Then
                Me.EditarPlanificacion()
            ElseIf tabHoraExtra.SelectedTab Is tabHoraExtra.TabPages("tabSolicitud") Then
                'ElseIf Me.tabHoraExtra.SelectedIndex = 1 Then
                Me.EditarSolicitud()
            ElseIf tabHoraExtra.SelectedTab Is tabHoraExtra.TabPages("tabAutorizacion") Then
                'ElseIf Me.tabHoraExtra.SelectedIndex = 2 Then
                Me.EditarAutorizacion()
            ElseIf tabHoraExtra.SelectedTab Is tabHoraExtra.TabPages("tabAprobacion") Then
                'ElseIf Me.tabHoraExtra.SelectedIndex = 3 Then
                If Me.rbtSolicitud.Checked Then
                    Me.EditarAprobacion()
                ElseIf Me.rbtPlanificacion.Checked Then
                    Me.EditarAprobarPlanificacion()
                Else
                    Me.EditarAprobacionSolicitud()
                End If
            ElseIf tabHoraExtra.SelectedTab Is tabHoraExtra.TabPages("tabCompensacion") Then
                'ElseIf Me.tabHoraExtra.SelectedIndex = 4 Then
                If tabCompensacionDetalle.SelectedTab Is tabCompensacionDetalle.TabPages("tabListaCompensacion") Then
                    EditarCompensacion()
                ElseIf tabCompensacionDetalle.SelectedTab Is tabCompensacionDetalle.TabPages("tabSolicitud2") Then
                    If Me.tabSolicitar2.SelectedTab Is Me.tabSolicitar2.TabPages("tabListaSolicitud2") Then
                        EditarSolicitudCompensacion()
                    End If
                End If
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub EditarCompensacion()
        blnEditarCompensacion = True
        intFilaCompensacion = -1
        Dim obj As New Cls_HoraExtra_LN
        btnConsultarCompensacionDetalle_Click(Nothing, Nothing)
        Me.tabCompensacionDetalle.SelectedIndex = 1
    End Sub

    Sub Limpiar()
        Me.btnActualizar.Enabled = True
        Me.dtpInicio.Enabled = True
        Me.dtpFin.Enabled = True

        Me.dtpInicio.Value = Now
        Me.dtpFin.Value = Me.dtpInicio.Value

        Me.dgvPlanificacion.DataSource = Nothing
        Me.ConfigurardgvPlanificacion()

        dtPlanificacion.Rows.Clear()
        dtHora.Rows.Clear()

        Me.rbtHora.Checked = True

        'AgregarFecha()
        ConfigurarColumna(1)
        SeteaColumna(dgvPlanificacion)

        Total()
    End Sub

    Private Sub tabPlanificacionDetalle_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabPlanificacionDetalle.SelectedIndexChanged
        With Me.tabPlanificacionDetalle
            If tabPlanificacionDetalle.SelectedIndex = 0 Then
                Me.tsbNuevo.Enabled = True
                Me.tsbGrabar.Enabled = False
                If Me.dgvLista.Rows.Count > 0 Then
                    Me.tsbEditar.Enabled = True
                    Me.tsbAnular.Enabled = Me.dgvLista.CurrentRow.Cells("id_estado").Value = 1
                Else
                    Me.tsbEditar.Enabled = False
                    Me.tsbAnular.Enabled = False
                End If
            ElseIf tabPlanificacionDetalle.SelectedIndex = 1 Then
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                If blnNuevo Then
                    Me.tsbGrabar.Enabled = Me.dgvPlanificacion.Rows.Count > 0
                Else
                    Me.tsbGrabar.Enabled = Me.dgvLista.CurrentRow.Cells("id_estado").Value = 1 AndAlso Me.dgvPlanificacion.Rows.Count > 0
                End If
                Me.tsbAnular.Enabled = False
                Me.btnActualizar.Focus()
            End If
        End With
    End Sub

    Private Sub dgvLista_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.CellContentClick
        Try
            If e.ColumnIndex <> 11 Then Return
            Dim dlgRespuesta As DialogResult
            Dim strMensaje As String
            Dim intEstado As Integer = dgvLista.Rows(e.RowIndex).Cells("id_estado").Value
            If intEstado = 2 Then
                dgvLista.Rows(e.RowIndex).Cells("id_estado").Value = 2
                dgvLista.RefreshEdit()
                Return
            End If
            Dim intCerrado As Integer = dgvLista.Rows(e.RowIndex).Cells("cerrado").Value
            Dim strMensaje2 As String = IIf(intCerrado = 0, "cerrar", "abrir")

            strMensaje = "¿Está seguro de " & strMensaje2 & " la planificación Nº " & Me.dgvLista.Rows(e.RowIndex).Cells("id").Value & "?"
            dlgRespuesta = MessageBox.Show(strMensaje, "Planificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Dim obj As New Cls_HoraExtra_LN
                obj.CerrarPlanificacion(Me.dgvLista.Rows(e.RowIndex).Cells("id").Value, IIf(intCerrado = 0, 1, 0), dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
                dgvLista.Rows(e.RowIndex).Cells("cerrado").Value = IIf(intCerrado = 0, 1, 0)
            Else
                dgvLista.Rows(e.RowIndex).Cells("cerrado").Value = intCerrado
            End If
            dgvLista.RefreshEdit()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.btnConsultarLista_Click(Nothing, Nothing)
        End Try
    End Sub

    Private Sub dgvLista_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.CellContentDoubleClick
        Try
            If e.ColumnIndex <> 11 Then Return
            Dim dlgRespuesta As DialogResult
            Dim strMensaje As String
            Dim intEstado As Integer = dgvLista.Rows(e.RowIndex).Cells("id_estado").Value
            If intEstado = 2 Then
                dgvLista.Rows(e.RowIndex).Cells("id_estado").Value = 2
                dgvLista.RefreshEdit()
                Return
            End If
            Dim intCerrado As Integer = dgvLista.Rows(e.RowIndex).Cells("cerrado").Value
            Dim strMensaje2 As String = IIf(intCerrado = 0, "cerrar", "abrir")

            strMensaje = "¿Está seguro de " & strMensaje2 & " la planificación Nº " & Me.dgvLista.Rows(e.RowIndex).Cells("id").Value & "?"
            dlgRespuesta = MessageBox.Show(strMensaje, "Planificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                Dim obj As New Cls_HoraExtra_LN
                obj.CerrarPlanificacion(Me.dgvLista.Rows(e.RowIndex).Cells("id").Value, IIf(intCerrado = 0, 1, 0), dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
                dgvLista.Rows(e.RowIndex).Cells("cerrado").Value = IIf(intCerrado = 0, 1, 0)
            Else
                dgvLista.Rows(e.RowIndex).Cells("cerrado").Value = intCerrado
            End If
            dgvLista.RefreshEdit()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.btnConsultarLista_Click(Nothing, Nothing)
        End Try

    End Sub

    Private Sub dgvLista_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLista.CurrentCellDirtyStateChanged
        'dgvLista.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub dgvLista_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLista.DoubleClick
        If Me.dgvLista.Rows.Count > 0 Then
            Me.tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        blnNuevo = True
        If tabHoraExtra.SelectedTab Is tabHoraExtra.TabPages("tabPlanificacion") Then
            'If Me.tabHoraExtra.SelectedIndex = 0 Then
            Limpiar()
            Me.tabPlanificacionDetalle.SelectedIndex = 1
        ElseIf tabHoraExtra.SelectedTab Is tabHoraExtra.TabPages("tabSolicitud") Then
            'ElseIf Me.tabHoraExtra.SelectedIndex = 1 Then
            'blnNuevoSolicitud = True
            blnNuevoRegistro = True
            'Me.txtCodigo.Enabled = True
            Me.dtpFechaSolicitud.Value = FechaServidor()
            Me.dtpFechaSolicitud.Enabled = True
            Me.dtpInicioSolicitud.Enabled = True
            Me.dtpFinSolicitud.Enabled = True
            Me.txtActividadSolicitud.Enabled = True
            Me.btnAgregarSolicitud.Enabled = True
            LimpiarSolicitud(3)
            dtpFechaSolicitud_ValueChanged(Nothing, Nothing)
            RemoveHandler tabSolicitudDetalle.SelectedIndexChanged, AddressOf tabSolicitudDetalle_SelectedIndexChanged
            Me.tabSolicitudDetalle.SelectedIndex = 1
            AddHandler tabSolicitudDetalle.SelectedIndexChanged, AddressOf tabSolicitudDetalle_SelectedIndexChanged
            Accion()
            Me.tsbNuevo.Enabled = False
        End If
    End Sub

    Sub Anular(ByVal id As Integer)
        Dim obj As New Cls_HoraExtra_LN
        obj.AnularPlanificacion(id, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
    End Sub

    Sub AnularSolicitud(ByVal id As Integer, ByVal perfil As Integer, ByVal estado As Integer, ByVal opcion As Integer)
        Dim obj As New Cls_HoraExtra_LN
        obj.AnularSolicitud(id, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol, perfil, estado, opcion)
    End Sub

    Private Sub tsbAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAnular.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim dlgRespuesta As DialogResult
            If tabHoraExtra.SelectedTab Is tabHoraExtra.TabPages("tabPlanificacion") Then
                'If Me.tabHoraExtra.SelectedIndex = 0 Then
                dlgRespuesta = MessageBox.Show("¿Está seguro de anular la planificación?", "Anular Planificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                    Anular(Me.dgvLista.CurrentRow.Cells("id").Value)
                    Me.btnConsultarLista_Click(Nothing, Nothing)
                    Limpiar()
                End If
            ElseIf tabHoraExtra.SelectedTab Is tabHoraExtra.TabPages("tabSolicitud") Then
                'ElseIf Me.tabHoraExtra.SelectedIndex = 1 Then
                dlgRespuesta = MessageBox.Show("¿Está seguro de anular la solicitud?", "Anular Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                    AnularSolicitud(Me.dgvListaSolicitud.CurrentRow.Cells("id").Value, intPerfil, Me.dgvListaSolicitud.CurrentRow.Cells("id_estado").Value, 0)
                    Me.btnConsultarListaSolicitud_Click(Nothing, Nothing)
                End If
            ElseIf tabHoraExtra.SelectedTab Is tabHoraExtra.TabPages("tabAprobacion") Then
                Dim frm As New frmAnularAprobacion
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    AnularAprobacion(frm)
                End If
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub MostrarTrabajador(ByVal dt As DataTable)
        With dt
            Me.lblNombresSolicitud.Text = dt.Rows(0).Item("nombres")
            Me.lblArea.Text = dt.Rows(0).Item("area")
            Me.lblCargo.Text = dt.Rows(0).Item("cargo")
            Me.lblCentroCosto.Text = dt.Rows(0).Item("centro_costo")
        End With
    End Sub

    Private Sub txtCodigo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.Enter
        Me.txtCodigo.SelectAll()
    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        Try
            If Asc(e.KeyChar) = Keys.Enter Then
                If Me.txtCodigo.Enabled = False Then Return
                If Me.txtCodigo.Text.Trim.Length = 0 Then Return
                Cursor = Cursors.WaitCursor
                intExonerado = 0
                Dim strCodigo As String = Me.txtCodigo.Text.Trim
                dtTrabajador = ModHoraExtra.ListarTrabajadores(strCodigo)
                If dtTrabajador.Rows.Count > 0 Then
                    MostrarTrabajador(dtTrabajador)
                    dtpFechaSolicitud_ValueChanged(Nothing, Nothing)
                    Me.btnConsultarListaSolicitud.Focus()
                    intExonerado = dtTrabajador.Rows(0).Item("exonerado")

                    Me.btnCerrarSolicitud.Enabled = True
                    Me.tsbNuevo.Enabled = True
                    Me.tabSolicitudDetalle.Enabled = True
                    Me.txtCodigo.Enabled = False
                    Cursor = Cursors.Default
                Else
                    Cursor = Cursors.Default
                    Me.btnCerrarSolicitud.Enabled = False
                    Me.tsbNuevo.Enabled = False
                    Me.tabSolicitudDetalle.Enabled = False
                    MessageBox.Show("El Trabajador con código " & strCodigo & " no existe", "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                If Not (ValidaNumero(e.KeyChar)) Then
                    e.Handled = True
                End If
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpFechaSolicitud_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaSolicitud.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.dtpInicioSolicitud.Focus()
        End If
    End Sub

    Private Sub dtpInicioSolicitud_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpInicioSolicitud.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.dtpFinSolicitud.Focus()
        End If
    End Sub

    Private Sub dtpFinSolicitud_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFinSolicitud.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.txtActividadSolicitud.Focus()
        End If
    End Sub

    Private Sub tabSolicitudDetalle_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabSolicitudDetalle.SelectedIndexChanged
        If tabSolicitudDetalle.SelectedIndex = 0 Then
            blnNuevoSolicitud = True
            Me.tsbNuevo.Enabled = True
            Me.tsbGrabar.Enabled = False
            If Me.dgvListaSolicitud.Rows.Count > 0 Then
                Me.tsbEditar.Enabled = True
                If intPerfil = 1 Then
                    Me.tsbAnular.Enabled = Me.dgvListaSolicitud.CurrentRow.Cells("id_estado").Value < 3
                Else
                    Me.tsbAnular.Enabled = Me.dgvListaSolicitud.CurrentRow.Cells("id_estado").Value = 1
                End If
            Else
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            End If
            ElseIf tabSolicitudDetalle.SelectedIndex = 1 Then
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
                If blnNuevoSolicitud Then
                    Me.tsbGrabar.Enabled = False
                    blnNuevoRegistro = True
                    Me.tsbNuevo_Click(Nothing, Nothing)
                Else
                    Me.tsbGrabar.Enabled = True
                End If
                TotalSolicitud()
                Me.txtCodigo.Focus()
            Else
                Me.tsbGrabar.Enabled = False
                Me.tsbNuevo.Enabled = False
                Me.tsbEditar.Enabled = False
                Me.tsbAnular.Enabled = False
            End If
    End Sub

    Private Sub dtpFechaSolicitud_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaSolicitud.ValueChanged
        If IsNothing(dtTrabajador) Then Return
        If Me.txtCodigo.Text.Trim.Length = 0 Then Return

        LimpiarSolicitud(2)
        dtSolicitud.Rows.Clear()
        Me.dgvSolicitud.DataSource = Nothing
        Me.ConfigurardgvSolicitud()

        Dim strCodigo As String = Me.txtCodigo.Text.Trim
        Dim dtHorario As DataTable = ModHoraExtra.ListarHorario(dtTrabajador.Rows(0).Item("horario"), strCodigo)
        Dim intDia As Integer = CType(Me.dtpFechaSolicitud.Value.ToShortDateString, Date).DayOfWeek
        MostrarHorario(intDia, Me.lblIngresoHorarioSolicitud, Me.lblSalidaHorarioSolicitud, dtHorario)

        Dim dtAsistencia As DataTable = ListarAsistencia(Me.dtpFechaSolicitud.Value.ToShortDateString, strCodigo)
        MostrarAsistencia(dtAsistencia)

        EstadoFeriado()

        blnDescansoSolicitud = dtHorario.Rows(0).Item(intDia) = 1
        blnFeriadoSolicitud = EsFeriado(Me.dtpFechaSolicitud.Value.ToShortDateString)
    End Sub

    Sub MostrarAsistencia(ByVal dt As DataTable)
        If dt.Rows.Count > 0 Then
            Dim strGlosa As String, strInicio As String, strFin As String
            Dim intConcepto As Integer
            Dim strConcepto As String
            Dim intExiste As Integer
            Dim row() As DataRow
            row = dt.Select("concepto='300'")
            If row.Length > 0 Then
                intConcepto = 300
                intExiste = 1
            End If
            If intExiste >= 0 Then
                row = dt.Select("concepto='301'")
                If row.Length > 0 Then
                    intConcepto = 301
                    intExiste = 1
                Else
                    row = dt.Select("concepto='300'")
                End If
            End If
            If intExiste = 0 Then
                row = dt.Select("concepto='314'")
                If row.Length > 0 Then
                    intConcepto = 314
                    intExiste = 1
                End If
            End If
            If intExiste = 0 Then
                row = dt.Select("concepto='324'")
                If row.Length > 0 Then
                    intConcepto = 324
                    intExiste = 1
                End If
            End If
            If intExiste = 0 Then
                row = dt.Select("concepto='355'")
                If row.Length > 0 Then
                    intConcepto = 355
                    intExiste = 1
                End If
            End If
            If intExiste = 0 Then
                row = dt.Select("concepto='306'")
                If row.Length > 0 Then
                    intConcepto = 306
                    intExiste = 1
                End If
            End If
            If intExiste = 0 Then
                row = dt.Select("concepto='399'")
                If row.Length > 0 Then
                    intConcepto = 399
                    intExiste = 1
                End If
            End If
            'strConcepto = "" & row(0).Item("concepto")
            strInicio = "" : strFin = ""
            If intExiste = 1 Then
                If intConcepto = 300 Then
                    strGlosa = row(0).Item("glosa").ToString.Substring(13, 12).Trim
                    strInicio = strGlosa.Substring(0, 5)
                    strFin = strGlosa.Substring(6, 5)
                Else
                    strGlosa = row(0).Item("glosa").ToString.Trim
                End If
            Else
                strGlosa = row(0).Item("glosa").ToString.Trim
            End If
            Me.lblIngresoAsistenciaSolicitud.Text = strInicio
            Me.lblSalidaAsistenciaSolicitud.Text = strFin
            If intConcepto = 300 Then
                If lblIngresoAsistenciaSolicitud.Text.Trim = lblSalidaAsistenciaSolicitud.Text.Trim Then
                    strGlosa = "FALTA MARCACION"
                    intConcepto = 399
                Else
                    strGlosa = "ASISTENCIA NORMAL"
                End If
            ElseIf intConcepto = 301 Then
                strGlosa = "TARDANZA"
            ElseIf intConcepto = 314 Then
                strGlosa = "PERMISO"
            ElseIf intConcepto = 324 Then
                strGlosa = "DESCANSO"
            ElseIf intConcepto = 355 Then
                strGlosa = "VACACIONES"
            ElseIf intConcepto = 306 Then
                strGlosa = "FALTA"
            ElseIf intConcepto = 399 Then
                strGlosa = "FALTA MARCACION"
            End If
            Me.lblMensaje.Text = strGlosa
            Me.lblMensaje.Tag = intConcepto
        Else
            If dtoUSUARIOS.marcador = 1 Then
                Me.lblMensaje.Text = "FALTA"
                Me.lblMensaje.Tag = 306
            Else
                If Cls_HoraExtra_LN.TieneAsistencia(Me.dtpFechaSolicitud.Value.ToShortDateString) Then
                    Me.lblMensaje.Text = "ASISTENCIA NORMAL"
                    Me.lblMensaje.Tag = 0
                Else
                    Me.lblMensaje.Text = ""
                    Me.lblMensaje.Tag = 306
                End If
            End If
        End If
    End Sub

    Private Sub tabHoraExtra_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabHoraExtra.SelectedIndexChanged
        If tabHoraExtra.SelectedTab Is tabHoraExtra.TabPages("tabPlanificacion") Then
            Me.tsbNuevo.Enabled = Me.tabPlanificacionDetalle.SelectedIndex = 0
        ElseIf tabHoraExtra.SelectedTab Is tabHoraExtra.TabPages("tabSolicitud") Then
            'If tabHoraExtra.SelectedIndex = 1 Then
            Me.txtCodigo.Text = ""
            Me.txtCodigo.Enabled = True
            Me.cboEstadoCompensacionSolicitud.SelectedIndex = 1
            Me.dgvListaSolicitud.DataSource = Nothing
            Me.dgvCompensacionSolicitud.DataSource = Nothing
            Me.ConfigurardgvListaSolicitud()
            Me.ConfigurardgvSolicitud()
            Me.ConfigurardgvCompensacionSolicitud()
            LimpiarSolicitud(4)
            CrearColumnas(dtSolicitud, 1)
            Me.tabSolicitudDetalle.SelectedIndex = 0
            Me.btnConsultarListaSolicitud.Focus()
        ElseIf tabHoraExtra.SelectedTab Is tabHoraExtra.TabPages("tabAutorizacion") Then
            'ElseIf tabHoraExtra.SelectedIndex = 2 Then
            LimpiarAutorizacion(1)
        ElseIf tabHoraExtra.SelectedTab Is tabHoraExtra.TabPages("tabAprobacion") Then
            'ElseIf tabHoraExtra.SelectedIndex = 3 Then
            LimpiarAprobacion(1)
        ElseIf tabHoraExtra.SelectedTab Is tabHoraExtra.TabPages("tabCompensacion") Then
            'ElseIf tabHoraExtra.SelectedIndex = 4 Then
            LimpiarCompensacion()
        ElseIf tabHoraExtra.SelectedTab Is tabHoraExtra.TabPages("tabMantenimiento") Then
            'ElseIf tabHoraExtra.SelectedIndex = 5 Then
            LimpiarMantenimiento()
        ElseIf tabHoraExtra.SelectedTab Is tabHoraExtra.TabPages("tabConfiguracion") Then
            LimpiarConfiguracion()
            AsignarTrabajador()
        ElseIf tabHoraExtra.SelectedTab Is tabHoraExtra.TabPages("tabConsulta") Then
            'ElseIf tabHoraExtra.SelectedIndex = 5 Then
            LimpiarConsulta()
        End If
    End Sub

    Sub LimpiarConfiguracion()
        Me.tsbNuevo.Enabled = False
        Me.tsbEditar.Enabled = False
        Me.tsbGrabar.Enabled = False
        Me.tsbAnular.Enabled = False
    End Sub

    Sub LimpiarConsulta()
        Me.tsbNuevo.Enabled = False
        Me.tsbEditar.Enabled = False
        Me.tsbGrabar.Enabled = False
        Me.tsbAnular.Enabled = False

        Me.ConfigurardgvHe()
        ConfigurardgvHe2()
        Me.dtpInicioHe.Value = DateAdd(DateInterval.Month, -1, Me.dtpFinHe.Value)
        Me.cboEstadoHe.SelectedIndex = 0

        Me.dtpInicioHE2.Value = DateAdd(DateInterval.Month, -1, Me.dtpFinHE2.Value)
        Me.cboEstadoHe2.SelectedIndex = 0
    End Sub

    Sub LimpiarCompensacion()
        intFilaCompensacion = -1
        Me.tsbNuevo.Enabled = False
        Me.tsbEditar.Enabled = False
        Me.tsbGrabar.Enabled = False
        Me.tsbAnular.Enabled = False
        dtpFinCompensacionDetalle.Value = Now
        dtpInicioCompensacionDetalle.Value = "01/01/" & dtpFinCompensacionDetalle.Value.Year.ToString

        dtpInicioListaSolicitud2.Value = "01/01/" & dtpFinCompensacionDetalle.Value.Year.ToString

        If tabCompensacionDetalle.SelectedIndex = 0 Then
            Me.tsbEditar.Enabled = Me.dgvListaCompensacion.Rows.Count > 0
        Else
            Me.tsbEditar.Enabled = False
        End If
        Me.cboEstadoCompensacion.SelectedIndex = 1
        Me.cboEstadoCompensacionDetalle.SelectedIndex = 1

        cboEstadoListaSolicitud2.SelectedIndex = 1

        Me.cboTipoCompensacionSolicitud2.SelectedIndex = 0
        Me.cboEstadoSolicitud2.SelectedIndex = 1
    End Sub

    Sub LimpiarAutorizacion(Optional ByVal opcion As Integer = 0)
        Me.tsbNuevo.Enabled = False
        Me.tsbEditar.Enabled = False
        Me.tsbGrabar.Enabled = False
        Me.tsbAnular.Enabled = False

        Me.lblFechaAutorizacion.Text = ""
        Me.lblTrabajadorAutorizacion.Text = ""
        Me.lblCargoAutorizacion.Text = ""
        Me.lblAreaAutorizacion.Text = ""
        Me.lblCentroCostoAutorizacion.Text = ""
        Me.lblHorarioAutorizacion.Text = ""
        Me.lblAsistenciaAutorizacion.Text = ""
        Me.lblHorasAutorizacion.Text = ""

        Me.dgvSobretiempoAutorizacion.DataSource = Nothing
        ConfigurardgvSobretiempoAutorizacion()

        Me.pnlAutorizacion.Enabled = False
        Me.rbtSiAutorizacion.Checked = True
        Me.txtNoAutorizacion.Text = ""
        Me.lblTipoDiaAutorizacion.Text = ""
        Me.cboTipoCompensacionAutorizacion.SelectedIndex = 0
        'Me.lblCostoAutorizacion.Text = ""

        If tabAutorizacionDetalle.SelectedIndex = 0 Then
            Me.tsbEditar.Enabled = Me.dgvListaAutorizacion.Rows.Count > 0
            If opcion = 1 Then
                Me.btnConsultarListaAutorizacion_Click(Nothing, Nothing)
            End If
        ElseIf tabAutorizacionDetalle.SelectedIndex = 1 Then
            If Me.dgvListaAutorizacion.Rows.Count > 0 Then
                Me.pnlAutorizacion.Enabled = True
            End If
        End If
    End Sub

    Sub LimpiarSolicitud(ByVal opcion As Integer)
        If opcion = 0 Then
            Me.dtpInicioSolicitud.Value = Now
            Me.dtpFinSolicitud.Value = Now
            Me.cboEstadoSolicitud.SelectedIndex = 1
            Me.txtActividadSolicitud.Text = ""
        End If
        If opcion = 1 Then
            Me.lblNombresSolicitud.Text = ""
            Me.lblArea.Text = ""
            'Me.txtCodigo.Text = ""
            Me.lblCentroCosto.Text = ""
            Me.lblCargo.Text = ""

            Me.btnCerrarSolicitud.Enabled = False
            Me.tsbNuevo.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
            Me.tabSolicitudDetalle.Enabled = False
        End If
        If opcion = 2 Then
            'Me.dtpFechaSolicitud.Value = Now
            Me.lblIngresoHorarioSolicitud.Text = "0:00"
            Me.lblSalidaHorarioSolicitud.Text = "0:00"
            Me.lblIngresoAsistenciaSolicitud.Text = "0:00"
            Me.lblSalidaAsistenciaSolicitud.Text = "0:00"
            Me.dtpInicioSolicitud.Value = Now
            Me.dtpFinSolicitud.Value = Now
            'Me.cboEstadoSolicitud.SelectedIndex = 1
            Me.txtActividadSolicitud.Text = ""
        End If
        If opcion = 3 Then
            'Me.lblNombresSolicitud.Text = ""
            'Me.lblArea.Text = ""
            'Me.txtCodigo.Text = ""
            'Me.lblCentroCosto.Text = ""
            'Me.lblCargo.Text = ""

            Me.dtpFechaSolicitud.Value = Now
            Me.lblIngresoHorarioSolicitud.Text = "0:00"
            Me.lblSalidaHorarioSolicitud.Text = "0:00"
            Me.lblIngresoAsistenciaSolicitud.Text = "0:00"
            Me.lblSalidaAsistenciaSolicitud.Text = "0:00"
            Me.dtpInicioSolicitud.Value = Now
            Me.dtpFinSolicitud.Value = Now
            'Me.cboEstadoSolicitud.SelectedIndex = 1
            Me.txtActividadSolicitud.Text = ""
            Me.dgvSolicitud.DataSource = Nothing
            Me.ConfigurardgvSolicitud()
        End If
        If opcion = 4 Then
            Me.lblNombresSolicitud.Text = ""
            Me.lblArea.Text = ""
            'Me.txtCodigo.Text = ""
            Me.lblCentroCosto.Text = ""
            Me.lblCargo.Text = ""

            Me.dtpFechaSolicitud.Value = Now
            Me.lblIngresoHorarioSolicitud.Text = "0:00"
            Me.lblSalidaHorarioSolicitud.Text = "0:00"
            Me.lblIngresoAsistenciaSolicitud.Text = "0:00"
            Me.lblSalidaAsistenciaSolicitud.Text = "0:00"
            Me.dtpInicioSolicitud.Value = Now
            Me.dtpFinSolicitud.Value = Now
            Me.cboEstadoSolicitud.SelectedIndex = 1
            Me.txtActividadSolicitud.Text = ""
            Me.dgvSolicitud.DataSource = Nothing
            Me.ConfigurardgvSolicitud()

            Me.tabSolicitudDetalle.Enabled = False
            Me.btnCerrarSolicitud.Enabled = False
            Me.tsbNuevo.Enabled = False
            Me.tsbEditar.Enabled = False
            Me.tsbAnular.Enabled = False
            Me.txtCodigo.Focus()
        End If
    End Sub

    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
        If blnNuevoSolicitud Then
            Me.LimpiarSolicitud(1)
        End If
    End Sub

    Private Sub txtActividadSolicitud_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtActividadSolicitud.Enter
        Me.txtActividadSolicitud.SelectAll()
    End Sub

    Private Sub txtActividadSolicitud_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtActividadSolicitud.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            Me.btnAgregarSolicitud.Focus()
        End If
    End Sub

    Private Sub txtActividadSolicitud_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtActividadSolicitud.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub

    Function ValidarSolicitud() As Boolean
        Dim blnOK As Boolean = True

        If Me.txtCodigo.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese el Código de Trabajador", "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtCodigo.Focus()
            blnOK = False
            Return blnOK
        End If

        If Me.lblNombresSolicitud.Text.Trim.Length = 0 Then
            MessageBox.Show("El Código de Trabajador no es válido", "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtCodigo.Focus()
            blnOK = False
            Return blnOK
        End If

        Dim obj As Object = Me.lblMensaje.Tag
        If IsNothing(obj) Then obj = 0

        If CDate(dtpFechaSolicitud.Value.ToShortDateString) > CDate(FechaServidor(1)) Then
            MessageBox.Show("La fecha de sobretiempo no debe ser mayor a la fecha actual", "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpFechaSolicitud.Focus()
            blnOK = False
            Return blnOK
        End If

        If dtoUSUARIOS.marcador = 1 And intExonerado = 0 Then
            If (obj = 300 Or obj = 324 Or obj = 355 Or obj = 306) And Me.lblFeriado.Text <> "FERIADO" Then
                If Me.lblIngresoAsistenciaSolicitud.Text = "0:00" And lblSalidaAsistenciaSolicitud.Text = "0:00" Then
                    MessageBox.Show("El trabajador no tiene asistencia", "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.dtpFechaSolicitud.Focus()
                    blnOK = False
                    Return blnOK
                End If
                If Me.lblIngresoAsistenciaSolicitud.Text.Trim = "" And lblSalidaAsistenciaSolicitud.Text.Trim = "" Then
                    MessageBox.Show("El trabajador no tiene asistencia", "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.dtpFechaSolicitud.Focus()
                    blnOK = False
                    Return blnOK
                End If
            End If
            If lblHorasSolicitud.Text = "00:00" Then
                MessageBox.Show("El sobretiempo debe ser a partir de 1 hora", "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dtpInicioSolicitud.Focus()
                blnOK = False
                Return blnOK
            End If
        End If

        If Me.dtpInicioSolicitud.Value = Me.dtpFinSolicitud.Value Then
            MessageBox.Show("La Hora inicio no puede ser igual a la Hora fin", "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpInicioSolicitud.Focus()
            blnOK = False
            Return blnOK
        End If

        If Me.dtpInicio.Value > Me.dtpFin.Value Then
            MessageBox.Show("La Hora inicio no puede ser mayor a la Hora fin", "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpInicioSolicitud.Focus()
            blnOK = False
            Return blnOK
        End If

        'If DateDiff(DateInterval.Minute, Me.dtpInicioSolicitud.Value, Me.dtpFinSolicitud.Value) < 30 Then
        'If lblHorasSolicitud.Text = "00:00" Then
        '    MessageBox.Show("El sobretiempo debe ser a partir de 30 minutos", "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Me.dtpInicioSolicitud.Focus()
        '    blnOK = False
        '    Return blnOK
        'End If

        Dim fecha1 As Date, fecha2 As Date, fechahorario1 As Date, fechahorario2 As Date
        blnOK = True
        If Me.lblFeriado.Text <> "FERIADO" Then
            If Me.lblIngresoHorarioSolicitud.Text.Trim.Length > 0 And Me.lblSalidaHorarioSolicitud.Text.Trim.Length > 0 Then
                fecha1 = Me.dtpInicioSolicitud.Value
                fecha2 = Me.dtpFinSolicitud.Value
                fechahorario1 = Me.dtpInicioSolicitud.Value.ToShortDateString & " " & Format(CType(Me.lblIngresoHorarioSolicitud.Text, Date), "HH:mm")
                fechahorario2 = Me.dtpInicioSolicitud.Value.ToShortDateString & " " & Format(CType(Me.lblSalidaHorarioSolicitud.Text, Date), "HH:mm")
                If fecha1 <> fechahorario1 Then
                    If fecha1 < fechahorario1 Then
                        If fecha2 <= fechahorario1 Then
                            blnOK = True
                        Else
                            blnOK = False
                        End If
                    ElseIf fecha1 > fechahorario1 Then
                        If fecha1 >= fechahorario2 Then
                            blnOK = True
                        Else
                            blnOK = False
                        End If
                    End If
                Else
                    blnOK = False
                End If
            End If
            If Not blnOK Then
                MessageBox.Show("El trabajador no puede realizar sobretiempo dentro de su horario", "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dtpInicioSolicitud.Focus()
            End If
        End If

        If blnOK Then
            If obj <> 0 And obj <> 399 And dtoUSUARIOS.marcador = 1 and intExonerado=0 Then
                If Me.lblIngresoAsistenciaSolicitud.Text.Trim.Length > 0 And Me.lblSalidaAsistenciaSolicitud.Text.Trim.Length > 0 Then
                    fecha1 = Me.dtpInicioSolicitud.Value
                    fecha2 = Me.dtpFinSolicitud.Value
                    fechahorario1 = Me.dtpInicioSolicitud.Value.ToShortDateString & " " & Format(CType(Me.lblIngresoAsistenciaSolicitud.Text, Date), "HH:mm")
                    fechahorario2 = Me.dtpInicioSolicitud.Value.ToShortDateString & " " & Format(CType(Me.lblSalidaAsistenciaSolicitud.Text, Date), "HH:mm")
                    If fecha1 >= fechahorario1 And fecha2 <= fechahorario2 Then
                        blnOK = True
                    Else
                        blnOK = False
                    End If
                End If
                If Not blnOK Then
                    MessageBox.Show("El trabajador no puede realizar sobretiempo fuera de su asistencia", "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.dtpInicioSolicitud.Focus()
                End If
            End If
            If blnOK Then
                Dim fechagrid1 As Date, fechagrid2 As Date
                With Me.dgvSolicitud
                    Dim blnPasa As Boolean
                    For Each row As DataGridViewRow In .Rows
                        blnPasa = True
                        If Not blnNuevoRegistro Then
                            If .CurrentCell.RowIndex = row.Index Then
                                blnPasa = False
                            End If
                        End If
                        If blnPasa Then
                            fechagrid1 = Me.dtpInicioSolicitud.Value.ToShortDateString & " " & Format(CType(row.Cells("inicio").Value, Date), "HH:mm")
                            fechagrid2 = Me.dtpInicioSolicitud.Value.ToShortDateString & " " & Format(CType(row.Cells("fin").Value, Date), "HH:mm")
                            If fecha1 <> fechagrid1 Then
                                If fecha1 < fechagrid1 Then
                                    If fecha2 <= fechagrid1 Then
                                        blnOK = True
                                    Else
                                        blnOK = False
                                        Exit For
                                    End If
                                ElseIf fecha1 > fechagrid1 Then
                                    If fecha1 >= fechagrid2 Then
                                        blnOK = True
                                    Else
                                        blnOK = False
                                        Exit For
                                    End If
                                Else
                                    blnOK = False
                                    Exit For
                                End If
                            Else
                                blnOK = False
                                Exit For
                            End If
                        End If
                    Next
                    If Not blnOK Then
                        MessageBox.Show("El horario de sobretiempo ya existe", "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.dtpInicioSolicitud.Focus()
                    End If
                End With
            End If
        End If
        If blnOK Then
            If Me.txtActividadSolicitud.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese el detalle de las actividades realizadas", "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtActividadSolicitud.Text = ""
                Me.txtActividadSolicitud.Focus()
                blnOK = False
                Return blnOK
            End If
        End If
        Return blnOK
    End Function

    Private Sub btnAgregarSolicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarSolicitud.Click
        If ValidarSolicitud() Then
            AgregarSolicitud()
            TotalSolicitud()
        End If
    End Sub

    Sub CrearColumnas(ByRef dt As DataTable, ByVal opcion As Integer)
        With dt
            If opcion = 1 Then
                dt = New DataTable
                dt.Columns.Add("id", Type.GetType("System.Int32"))
                dt.Columns.Add("fecha", Type.GetType("System.String"))
                dt.Columns.Add("inicio", Type.GetType("System.String"))
                dt.Columns.Add("fin", Type.GetType("System.String"))
                dt.Columns.Add("horas", Type.GetType("System.String"))
                dt.Columns.Add("actividad", Type.GetType("System.String"))
                dt.Columns.Add("nombres", Type.GetType("System.String"))
                dt.Columns.Add("area", Type.GetType("System.String"))
                dt.Columns.Add("codigo", Type.GetType("System.String"))
                dt.Columns.Add("centro_costo", Type.GetType("System.String"))
                dt.Columns.Add("cargo", Type.GetType("System.String"))
                dt.Columns.Add("ingreso", Type.GetType("System.String"))
                dt.Columns.Add("salida", Type.GetType("System.String"))
                dt.Columns.Add("asistencia_ingreso", Type.GetType("System.String"))
                dt.Columns.Add("asistencia_salida", Type.GetType("System.String"))
            End If
        End With
    End Sub

    Sub AgregarSolicitud()
        Dim intFila As Integer
        With dtSolicitud
            If Me.dgvSolicitud.Rows.Count > 0 Then
                intFila = Me.dgvSolicitud.CurrentCell.RowIndex
            End If
            Dim row As DataRow
            row = dtSolicitud.NewRow
            row.Item("id") = 0
            row.Item("fecha") = Me.dtpFechaSolicitud.Value.ToShortDateString
            row.Item("inicio") = dtpInicioSolicitud.Text
            row.Item("fin") = dtpFinSolicitud.Text
            row.Item("horas") = Me.lblHorasSolicitud.Text
            row.Item("actividad") = Me.txtActividadSolicitud.Text.Trim
            row.Item("nombres") = Me.lblNombresSolicitud.Text.Trim
            row.Item("area") = Me.lblArea.Text.Trim
            row.Item("codigo") = Me.txtCodigo.Text.Trim
            row.Item("centro_costo") = Me.lblCentroCosto.Text.Trim
            row.Item("cargo") = Me.lblCargo.Text.Trim
            row.Item("ingreso") = Me.lblIngresoHorarioSolicitud.Text
            row.Item("salida") = Me.lblSalidaHorarioSolicitud.Text
            row.Item("asistencia_ingreso") = Me.lblIngresoAsistenciaSolicitud.Text
            row.Item("asistencia_salida") = Me.lblSalidaAsistenciaSolicitud.Text
            If Not blnNuevoRegistro Then
                Dim rows() As DataRow
                rows = dtSolicitud.Select("inicio='" & strFechaOriginal & "'")
                rows(0).Delete()
                dtSolicitud.AcceptChanges()
            End If
            dtSolicitud.Rows.Add(row)
            dtSolicitud.DefaultView.Sort = "inicio"
            dtSolicitud.AcceptChanges()
            Me.dgvSolicitud.DataSource = dtSolicitud
            strFechaOriginal = dtpInicioSolicitud.Text
            'blnNuevoRegistro = False
            Me.dgvSolicitud.CurrentCell = Me.dgvSolicitud(1, intFila)
            Me.btnNuevoSolicitud_Click(Nothing, Nothing)
            'Me.dtpInicioSolicitud.Focus()
        End With
    End Sub

    Private Sub dtpInicioSolicitud_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInicioSolicitud.ValueChanged, dtpFinSolicitud.ValueChanged
        Try
            Dim strInicio As String = CType(Me.dtpInicioSolicitud.Value, Date).ToShortDateString
            Dim strFin As String = CType(Me.dtpFinSolicitud.Value, Date).ToShortDateString
            If CDate(strInicio).ToShortDateString <> CDate(Me.dtpFechaSolicitud.Value.ToShortDateString) Then
                Me.dtpInicioSolicitud.Value = dtpFechaSolicitud.Value.ToShortDateString & " " & Format(Me.dtpInicioSolicitud.Value, "HH:mm")
            End If
            If CDate(strFin).ToShortDateString <> CDate(Me.dtpFechaSolicitud.Value.ToShortDateString) Then
                Me.dtpFinSolicitud.Value = Me.dtpFechaSolicitud.Value.ToShortDateString & " " & Format(Me.dtpFinSolicitud.Value, "HH:mm")
            End If

            Dim strFinSolicitud As String = Me.dtpFinSolicitud.Text
            Dim datFinSolicitud As Date = Me.dtpFinSolicitud.Value
            Dim intMinutos As Integer, intHoras As Integer

            intHoras = DateDiff(DateInterval.Hour, Me.dtpInicioSolicitud.Value, datFinSolicitud)
            intMinutos = DateDiff(DateInterval.Minute, Me.dtpInicioSolicitud.Value, datFinSolicitud)

            If strFinSolicitud = "00:00" Then
                datFinSolicitud = DateAdd(DateInterval.Day, 1, datFinSolicitud)
                intHoras = DateDiff(DateInterval.Hour, Me.dtpInicioSolicitud.Value, datFinSolicitud)
                intMinutos = DateDiff(DateInterval.Minute, Me.dtpInicioSolicitud.Value, datFinSolicitud)
            End If

            intMinutos = intMinutos - (intHoras * 60)
            'Si el dia es feriado o descanso
            If blnDescansoSolicitud Or blnFeriadoSolicitud Then
                'si sobretiempo excede a 5 h 45' se le descuenta 45' de refrigerio
                If intHoras >= 5 Then
                    If intHoras = 5 Then
                        If intMinutos >= 45 Then
                            intMinutos = 0
                        End If
                    Else
                        'intHoras = intHoras - 1
                        Dim intDiferencia As Integer = intMinutos - 45
                        If intDiferencia < 0 Then
                            intHoras = intHoras - 1
                            intMinutos = 60 - Math.Abs(intDiferencia)
                        Else
                            intMinutos = intDiferencia
                        End If
                    End If
                End If
            End If
            If intMinutos > 0 Then
                If intMinutos < 30 Then
                    intMinutos = 0
                ElseIf intMinutos > 30 Then
                    intMinutos = 30
                End If
            End If
            Me.lblHorasSolicitud.Text = Format(intHoras, "00") & ":" & Format(intMinutos, "00")
        Catch
        End Try
    End Sub

    Sub MostrarSolicitud(ByVal fila As Integer)
        With Me.dgvSolicitud
            Me.lblNombresSolicitud.Text = .Rows(fila).Cells("nombres").Value
            Me.lblArea.Text = .Rows(fila).Cells("area").Value
            Me.txtCodigo.Text = .Rows(fila).Cells("codigo").Value
            Me.lblCentroCosto.Text = .Rows(fila).Cells("centro_costo").Value
            Me.lblCargo.Text = .Rows(fila).Cells("cargo").Value
            RemoveHandler Me.dtpFechaSolicitud.ValueChanged, AddressOf Me.dtpFechaSolicitud_ValueChanged
            Me.dtpFechaSolicitud.Value = .Rows(fila).Cells("fecha").Value
            AddHandler Me.dtpFechaSolicitud.ValueChanged, AddressOf Me.dtpFechaSolicitud_ValueChanged

            Me.lblIngresoHorarioSolicitud.Text = "" & .Rows(fila).Cells("ingreso").Value
            Me.lblSalidaHorarioSolicitud.Text = "" & .Rows(fila).Cells("salida").Value
            Me.lblIngresoAsistenciaSolicitud.Text = "" & .Rows(fila).Cells("asistencia_ingreso").Value
            Me.lblSalidaAsistenciaSolicitud.Text = "" & .Rows(fila).Cells("asistencia_salida").Value

            Me.dtpInicioSolicitud.Text = .Rows(fila).Cells("inicio").Value
            Me.dtpFinSolicitud.Text = .Rows(fila).Cells("fin").Value
            Me.txtActividadSolicitud.Text = .Rows(fila).Cells("actividad").Value

            strFechaOriginal = Format(CType(.Rows(fila).Cells("inicio").Value, Date), "HH:mm")
        End With
    End Sub

    Private Sub dgvSolicitud_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSolicitud.RowEnter
        If IsNothing(dgvSolicitud.CurrentRow) Then Return
        blnNuevoRegistro = False
        MostrarSolicitud(e.RowIndex)
        Me.dtpInicioSolicitud.Focus()
        Accion()
    End Sub

    Private Sub dgvSolicitud_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvSolicitud.RowsAdded
        Me.btnEliminarSolicitud.Enabled = True
        Me.tsbGrabar.Enabled = True
        Me.btnNuevoSolicitud.Enabled = True
    End Sub

    Private Sub dgvSolicitud_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvSolicitud.RowsRemoved
        Me.btnEliminarSolicitud.Enabled = Me.dgvSolicitud.Rows.Count > 0
        Me.tsbGrabar.Enabled = Me.dgvSolicitud.Rows.Count > 0
        Me.btnNuevoSolicitud.Enabled = Me.dgvSolicitud.Rows.Count > 0
    End Sub

    Sub TotalSolicitud()
        Me.lblTotalHorasSolicitud.Text = SumaHoras(Me.dgvSolicitud, "horas")
    End Sub

    Sub Eliminar()
        With Me.dgvSolicitud
            dtSolicitud.Rows(.CurrentCell.RowIndex).Delete()
            dtSolicitud.AcceptChanges()
        End With
    End Sub

    Private Sub btnEliminarSolicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarSolicitud.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está seguro de eliminar el item?", "Horas Extras", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            Eliminar()
            TotalSolicitud()
            Me.btnNuevoSolicitud_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btnNuevoSolicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoSolicitud.Click
        blnNuevoRegistro = True
        If blnNuevoSolicitud Then
            LimpiarSolicitud(0)
            Me.dtpInicioSolicitud.Focus()
        Else
            LimpiarSolicitud(0)
            Me.dtpInicioSolicitud.Focus()
        End If
        Accion()
    End Sub

    Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
        If tabHoraExtra.SelectedTab Is tabHoraExtra.TabPages("tabPlanificacion") Then
            'If Me.tabHoraExtra.SelectedIndex = 0 Then
            Dim blnOk As Boolean = True
            If blnNuevo Then
                Dim obj As New Cls_HoraExtra_LN
                blnOk = obj.ValidarPlanificacion(dtoUSUARIOS.CentroCosto, Me.dtpInicio.Value.ToShortDateString, Me.dtpFin.Value.ToShortDateString)
            End If
            If blnOk Then
                Grabar()
            Else
                MessageBox.Show("Ya existe una Planificación entre las fechas " & Me.dtpInicio.Value.ToShortDateString & " y " & Me.dtpFin.Value.ToShortDateString, "Grabar Planificación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dtpInicio.Focus()
            End If
        ElseIf tabHoraExtra.SelectedTab Is tabHoraExtra.TabPages("tabSolicitud") Then
            'ElseIf Me.tabHoraExtra.SelectedIndex = 1 Then
            GrabarSolicitud()
        ElseIf tabHoraExtra.SelectedTab Is tabHoraExtra.TabPages("tabCompensacion") Then
            'ElseIf Me.tabHoraExtra.SelectedIndex = 4 Then
            GrabarCompensacion()
        End If
    End Sub

    Sub GrabarSolicitud()
        Try
            If lblTotalHorasSolicitud.Text = "00:00" Or lblTotalHorasSolicitud.Text = "00:30" Then
                MessageBox.Show("El sobretiempo debe ser a partir de 1 hora", "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dtpInicioSolicitud.Focus()
                Return
            End If

            Dim frmUsuarioConfirmar As New frmUsuarioValor
            frmUsuarioConfirmar.lblAgencia.Text = dtoUSUARIOS.m_iNombreAgencia
            frmUsuarioConfirmar.txtUsuario.Text = ""
            frmUsuarioConfirmar.intLLamada = 1
            frmUsuarioConfirmar.ShowDialog()
            If frmUsuarioConfirmar.Resultado = 0 Then
                Return
            End If
            Dim intUsuario As Integer = frmUsuarioConfirmar.IDUsuario
            Dim intRol As Integer = frmUsuarioConfirmar.cboRol.SelectedValue
            'Me.txtCodigo.Text = ""
            Me.txtCodigo.Focus()

            Cursor = Cursors.AppStarting
            Dim intID As Integer, intIdDet As Integer
            Dim strHoras As String
            strHoras = Me.lblHorasSolicitud.Text.Trim

            Dim obj As New Cls_HoraExtra_LN
            If blnNuevoSolicitud Then
                intID = 0
            Else
                intID = Me.dgvListaSolicitud.CurrentRow.Cells("id").Value
            End If
            intID = obj.GrabarSolicitud(intID, Me.txtCodigo.Text.Trim, Me.lblNombresSolicitud.Text.Trim, Me.lblCargo.Text.Trim, Me.lblCentroCosto.Text.Trim, _
                                        Me.lblArea.Text.Trim, Me.dtpFechaSolicitud.Text, Me.lblIngresoHorarioSolicitud.Text, _
                                        Me.lblSalidaHorarioSolicitud.Text, Me.lblIngresoAsistenciaSolicitud.Text, _
                                        Me.lblSalidaAsistenciaSolicitud.Text, dtTrabajador.Rows(0).Item("horario"), dtTrabajador.Rows(0).Item("remuneracion"), _
                                        Me.lblTotalHorasSolicitud.Text.Trim, intUsuario, dtoUSUARIOS.IP, intRol, dtoUSUARIOS.iIDAGENCIAS, dtoUSUARIOS.marcador)
            With dtSolicitud
                For Each row As DataRow In dtSolicitud.Rows
                    obj.GrabarSolicitudDetalle(intID, row("inicio"), row("fin"), row("horas"), row("actividad"))
                Next
            End With
            Me.tabSolicitudDetalle.SelectedIndex = 0
            Me.btnConsultarListaSolicitud_Click(Nothing, Nothing)
            Me.btnConsultarLista.Focus()

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnConsultarListaSolicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarListaSolicitud.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_HoraExtra_LN
            Dim dt As DataTable

            dt = obj.ListarSolicitud(Me.dtpInicioListaSolicitud.Value.ToShortDateString, Me.dtpFinListaSolicitud.Value.ToShortDateString, Me.txtCodigo.Text.Trim, Me.cboEstadoSolicitud.SelectedIndex, 0)
            Me.dgvListaSolicitud.DataSource = dt
            Me.tsbEditar.Enabled = Me.dgvListaSolicitud.Rows.Count > 0
            If Me.dgvListaSolicitud.Rows.Count > 0 Then
                Me.tsbAnular.Enabled = Me.dgvListaSolicitud.CurrentRow.Cells("id_estado").Value = 1
            End If
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvListaSolicitud_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvListaSolicitud.DoubleClick
        If Me.dgvListaSolicitud.Rows.Count > 0 Then
            tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btnConsultarListaAutorizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarListaAutorizacion.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_HoraExtra_LN
            Dim dt As DataTable

            'dt = obj.ListarSolicitud(Me.dtpInicioListaAutorizacion.Value.ToShortDateString, Me.dtpFinListaAutorizacion.Value.ToShortDateString, "", Me.cboEstadoAutorizacion.SelectedIndex, dtoUSUARIOS.CentroCosto)
            dt = obj.ListarSolicitud(Me.dtpInicioListaAutorizacion.Value.ToShortDateString, Me.dtpFinListaAutorizacion.Value.ToShortDateString, Me.cboEstadoAutorizacion.SelectedIndex, dtoUSUARIOS.IdLogin)
            Me.dgvListaAutorizacion.DataSource = dt
            Me.tsbEditar.Enabled = Me.dgvListaAutorizacion.Rows.Count > 0
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tabAutorizacionDetalle_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabAutorizacionDetalle.SelectedIndexChanged
        If tabAutorizacionDetalle.SelectedIndex = 0 Then
            Me.tsbEditar.Enabled = Me.dgvListaAutorizacion.Rows.Count > 0
            blnEditarAutorizacion = False
        Else
            Me.tsbEditar.Enabled = False
            If blnEditarAutorizacion = False Then
                If Me.dgvListaAutorizacion.Rows.Count > 0 Then
                    LimpiarAutorizacion()
                    tsbEditar_Click(Nothing, Nothing)
                Else
                    LimpiarAutorizacion()
                End If
            End If
        End If
    End Sub

    Private Sub dgvListaAutorizacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvListaAutorizacion.DoubleClick
        If Me.dgvListaAutorizacion.Rows.Count > 0 Then
            Me.tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub rbtSiAutorizacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiAutorizacion.CheckedChanged
        Me.txtNoAutorizacion.Text = ""
        Me.txtNoAutorizacion.Enabled = False
        Me.btnAceptarAutorizacion.Focus()
    End Sub

    Private Sub rbtNoAutorizacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoAutorizacion.CheckedChanged
        Me.txtNoAutorizacion.Text = ""
        Me.txtNoAutorizacion.Enabled = True
        Me.txtNoAutorizacion.Focus()
    End Sub

    Private Sub btnAceptarAutorizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarAutorizacion.Click
        If Not Me.rbtNoAutorizacion.Checked Then
            If Me.cboTipoCompensacionAutorizacion.SelectedIndex = 0 Then
                MessageBox.Show("Seleccione el Tipo de Compensación", "Autorizar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboTipoCompensacionAutorizacion.Focus()
                Me.cboTipoCompensacionAutorizacion.DroppedDown = True
                Return
            End If
        End If

        If Me.rbtNoAutorizacion.Checked AndAlso Me.txtNoAutorizacion.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese el Motivo", "Autorizar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNoAutorizacion.Text = ""
            Me.txtNoAutorizacion.Focus()
            Return
        End If

        If Me.cboTipoCompensacionAutorizacion.SelectedIndex = 1 Then
            Dim strPeriodoActual As String = PeriodoActual()
            Dim strPeriodo As String = Cls_HoraExtra_LN.PeriodoActual(lblFechaAutorizacion.Text)
            If strPeriodoActual <> strPeriodo Then
                MessageBox.Show("No puede autorizar HHEE en efectivo fuera de su período", "Autorizar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboTipoCompensacionAutorizacion.Focus()
                Me.cboTipoCompensacionAutorizacion.DroppedDown = True
                Return
            End If
        End If

        Autorizar()
    End Sub

    Sub Autorizar()
        Try
            If Me.rbtSiAutorizacion.Checked Then
                Dim strMensaje As String = "¿Está Seguro de Autorizar la Solicitud?"
                Dim intRespuesta As DialogResult = MessageBox.Show(strMensaje, "Autorizar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If intRespuesta = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Me.AutorizarSolicitud(2, 0, "", Me.lblTipoDiaAutorizacion.Text.Substring(0, 1))
                    'Me.AutorizarSolicitud(2, CType(Me.lblCostoAutorizacion.Text, Double), Me.cboHorasAutorizacion.Text, Me.lblTipoDiaAutorizacion.Text.Substring(0, 1))
                    MessageBox.Show("Solicitud Autorizada", "Autorizar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.btnConsultarListaAutorizacion_Click(Nothing, Nothing)
                    tabAutorizacionDetalle.SelectedTab = tabAutorizacionDetalle.TabPages("tabListaAutorizacion")
                    Cursor = Cursors.Default
                End If
            Else
                If MessageBox.Show("¿Está Seguro de no autorizar la Solicitud?", "Autorizar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Me.AutorizarSolicitud(4)
                    MessageBox.Show("Solicitud no Autorizada", "Autorizar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.btnConsultarListaAutorizacion_Click(Nothing, Nothing)
                    tabAutorizacionDetalle.SelectedTab = tabAutorizacionDetalle.TabPages("tabListaAutorizacion")
                    Cursor = Cursors.Default
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub GrabarHECompensacion()
        Dim obj As New Cls_HoraExtra_LN
        Dim intSolicitud As Integer = Me.dgvListaAprobacion.CurrentRow.Cells("id").Value
        Dim strCodigo As String = Me.lblTrabajadorAprobacion.Text.Substring(0, 5).Trim
        Dim strNombres As String = Me.lblTrabajadorAprobacion.Text.Substring(5).Trim
        'Dim strHorasEfectivo As String = Me.lblHorasEfectivoAprobacion.Text
        'Dim strHorasCompensacion As String = Me.lblHorasDescansoAprobacion.Text
        Dim strHorasCompensacion As String = Me.lblHorasAprobacion.Text
        Dim intTipoCompensacion As Integer = IIf(lblTipoCompensacionAprobacion.Text.Trim = "EFECTIVO", 1, 2)

        If strHorasCompensacion <> "00:00" Then
            obj.GrabarHECompensada(strCodigo, Me.lblFechaAprobacion.Text, strHorasCompensacion, strNombres, intSolicitud, intTipoCompensacion, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)

            Dim dt As DataTable
            dt = obj.ListarHECompensada(strCodigo)
            Dim strHorasTotal As String = SumaHoras(dt, "saldo")
            Cls_HoraExtra_LN.GrabarHECompensada(strCodigo, strHorasTotal)
        End If
    End Sub

    Sub AutorizarSolicitud(ByVal estado As Integer, Optional ByVal costo As Double = 0, Optional ByVal HorasEfectivo As String = "", Optional ByVal TipoDia As String = "")
        Dim obj As New Cls_HoraExtra_LN

        Dim intID As Integer = Me.dgvListaAutorizacion.CurrentRow.Cells("id").Value
        Dim strObservacion As String = IIf(estado = 2, "", Me.txtNoAutorizacion.Text.Trim)
        Dim intTipoDia As Integer, intTipoCompensacion As Integer
        If TipoDia.Trim.Length > 0 Then
            intTipoDia = IIf(TipoDia.Substring(0, 1) = "S", 1, 2)
        Else
            intTipoDia = 0
        End If
        intTipoCompensacion = Me.cboTipoCompensacionAutorizacion.SelectedIndex

        obj.AutorizarSolicitud(intID, estado, strObservacion, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol, costo, HorasEfectivo, intTipoDia, intTipoCompensacion)
    End Sub

    Sub LimpiarAprobacion(Optional ByVal opcion As Integer = 0)
        Me.tsbNuevo.Enabled = False
        Me.tsbEditar.Enabled = False
        Me.tsbGrabar.Enabled = False
        Me.tsbAnular.Enabled = False

        Me.lblFechaAprobacion.Text = ""
        Me.lblTrabajadorAprobacion.Text = ""
        Me.lblCargoAprobacion.Text = ""
        Me.lblAreaAprobacion.Text = ""
        Me.lblCentroCostoAprobacion.Text = ""
        Me.lblHorarioAprobacion.Text = ""
        Me.lblAsistenciaAprobacion.Text = ""
        Me.lblHorasAprobacion.Text = ""
        'Me.lblHorasEfectivoAprobacion.Text = ""
        'Me.lblHorasDescansoAprobacion.Text = ""

        Me.dgvSobretiempoAprobacion.DataSource = Nothing
        ConfigurardgvSobretiempoAprobacion()

        Me.pnlAprobacion.Enabled = False
        Me.rbtSiAprobacion.Checked = True
        Me.txtNoAprobacion.Text = ""
        Me.lblTipoDiaAprobacion.Text = ""
        Me.lblTipoCompensacionAprobacion.Text = ""
        'Me.lblCostoAprobacion.Text = ""
        Me.pnlAprobacionSolicitud.Enabled = False
        Me.rbtSiAprobacionSolicitud.Checked = True
        Me.txtNoAprobacionSolicitud.Text = ""
        Me.lblTipoCompensacionAprobacion2.Text = ""
        lblHorasCompensarAprobacion2.Text = ""

        If tabAprobacionDetalle.SelectedIndex = 0 Then
            Me.tsbEditar.Enabled = Me.dgvListaAprobacion.Rows.Count > 0
            If opcion = 1 Then
                Me.btnConsultarListaAprobacion_Click(Nothing, Nothing)
            End If
        ElseIf tabAprobacionDetalle.SelectedIndex = 1 Then
            If Me.dgvListaAprobacion.Rows.Count > 0 Then
                If tabAprobacionDetalle.SelectedTab Is tabAprobacionDetalle.TabPages("tabAprobar") Then
                    Me.pnlAprobacion.Enabled = True
                ElseIf tabAprobacionDetalle.SelectedTab Is tabAprobacionDetalle.TabPages("tabAprobarSolicitud") Then
                    Me.pnlAprobacionSolicitud.Enabled = True
                End If
            End If
        End If
    End Sub

    Sub LimpiarAprobarPlan(Optional ByVal opcion As Integer = 0)
        Me.tsbNuevo.Enabled = False
        Me.tsbEditar.Enabled = False
        Me.tsbGrabar.Enabled = False
        Me.tsbAnular.Enabled = False

        Me.lblInicioAprobarPlan.Text = ""
        Me.lblFinAprobarPlan.Text = ""
        Me.lblHorasAprobarPlan.Text = ""
        Me.lblCostoAprobarPlan.Text = ""

        'Me.pnlAprobarPlan.Enabled = False
        'Me.rbtSiAprobarPlan.Checked = True
        'Me.txtObservacionAprobarPlan.Text = ""
        Me.dgvAprobarPlan.DataSource = Nothing

        If tabAprobacionDetalle.SelectedIndex = 0 Then
            Me.tsbEditar.Enabled = Me.dgvListaAprobacion.Rows.Count > 0
            If opcion = 1 Then
                Me.btnConsultarListaAprobacion_Click(Nothing, Nothing)
            End If
        ElseIf tabAprobacionDetalle.SelectedIndex = 1 Then
            'If Me.dgvListaAprobacion.Rows.Count > 0 Then
            'Me.pnlAprobarPlan.Enabled = True
            'End If
        End If
    End Sub

    Private Sub btnConsultarListaAprobacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarListaAprobacion.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_HoraExtra_LN
            Dim dt As DataTable
            If Me.rbtSolicitud.Checked Then
                'dt = obj.ListarSolicitud(Me.dtpInicioListaAprobacion.Value.ToShortDateString, Me.dtpFinListaAprobacion.Value.ToShortDateString, "", Me.cboEstadoAprobacion.SelectedIndex, dtoUSUARIOS.CentroCosto)
                dt = obj.ListarSolicitud(Me.dtpInicioListaAprobacion.Value.ToShortDateString, Me.dtpFinListaAprobacion.Value.ToShortDateString, Me.cboEstadoAprobacion.SelectedIndex, dtoUSUARIOS.IdLogin)
            ElseIf Me.rbtPlanificacion.Checked Then
                'dt = obj.ListarPlanificacion(Me.dtpInicioListaAprobacion.Value.ToShortDateString, Me.dtpFinListaAprobacion.Value.ToShortDateString, 0, Me.cboEstadoAprobacion.SelectedIndex, 1)
                dt = obj.ListarPlanificacionCab(Me.dtpInicioListaAprobacion.Value.ToShortDateString, Me.dtpFinListaAprobacion.Value.ToShortDateString, dtoUSUARIOS.IdLogin, Me.cboEstadoAprobacion.SelectedIndex, 1)
            Else
                dt = obj.ListarSolicitudCompensado(Me.dtpInicioListaAprobacion.Value.ToShortDateString, Me.dtpFinListaAprobacion.Value.ToShortDateString, Me.cboEstadoAprobacion.SelectedIndex, dtoUSUARIOS.IdLogin)
            End If
            Me.dgvListaAprobacion.DataSource = dt
            Me.tsbEditar.Enabled = Me.dgvListaAprobacion.Rows.Count > 0
            If Me.dgvListaAprobacion.Rows.Count = 0 Then
                Me.tsbAnular.Enabled = False
            End If
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub EditarAprobacion()
        blnEditarAprobacion = True
        With Me.dgvListaAprobacion
            Me.lblFechaAprobacion.Text = .CurrentRow.Cells("fecha").Value
            Me.lblTrabajadorAprobacion.Text = .CurrentRow.Cells("codigo").Value & " " & .CurrentRow.Cells("nombres").Value
            Me.lblAreaAprobacion.Text = .CurrentRow.Cells("area").Value
            Me.lblCentroCostoAprobacion.Text = .CurrentRow.Cells("centro_costo").Value
            Me.lblCargoAprobacion.Text = .CurrentRow.Cells("cargo").Value
            Me.lblHorarioAprobacion.Text = .CurrentRow.Cells("ingreso").Value & "-" & .CurrentRow.Cells("salida").Value
            Me.lblAsistenciaAprobacion.Text = .CurrentRow.Cells("asistencia_ingreso").Value & "-" & .CurrentRow.Cells("asistencia_salida").Value
            Me.lblHorasAprobacion.Text = .CurrentRow.Cells("horas").Value
            'Me.lblHorasEfectivoAprobacion.Text = .CurrentRow.Cells("horas_efectivo").Value
            'Me.lblHorasDescansoAprobacion.Text = Format(Val(Me.lblHorasAprobacion.Text.Substring(0, 2)) - Val(.CurrentRow.Cells("horas_efectivo").Value.Substring(0, 2)), "00") & ":00"

            'Obtiene Tipo dia
            Dim dtHorario As DataTable
            Dim strFecha As String = .CurrentRow.Cells("fecha").Value
            Dim strHorario As String = .CurrentRow.Cells("horario").Value
            Dim blnFeriado As Boolean = EsFeriado(strFecha)
            dtHorario = ModHoraExtra.ListarHorario(strHorario, .CurrentRow.Cells("codigo").Value)
            Dim intDia As Integer = CType(strFecha, Date).DayOfWeek
            Dim blnDescanso As Boolean = dtHorario.Rows(0).Item(intDia) = 1
            Dim intTipoDia As Integer
            If blnDescanso Or blnFeriado Then
                intTipoDia = 2
                Me.lblTipoDiaAprobacion.Text = "DOBLE"
            Else
                intTipoDia = 1
                Me.lblTipoDiaAprobacion.Text = "SIMPLE"
            End If
            Me.lblTipoCompensacionAprobacion.Text = .CurrentRow.Cells("tipo_compensacion").Value

            Dim dblRemuneracion As Double = .CurrentRow.Cells("remuneracion").Value
            Dim obj As New Cls_HoraExtra_LN
            Dim dt As DataTable = obj.ListarSolicitud(.CurrentRow.Cells("id").Value)
            dgvSobretiempoAprobacion.DataSource = dt

            'Dim dblCosto As Double = CalculaSobretiempo(dt, "horas", dblRemuneracion, intTipoDia)
            'Dim dblCosto As Double = .CurrentRow.Cells("costo").Value
            'Me.lblCostoAprobacion.Text = Format(dblCosto, "0.00")
        End With
        Me.pnlAprobacion.Enabled = Me.dgvListaAprobacion.CurrentRow.Cells("id_estado").Value = 2
        Me.tabAprobacionDetalle.SelectedIndex = 1
    End Sub

    Private Sub tabAprobacionDetalle_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabAprobacionDetalle.SelectedIndexChanged
        If tabAprobacionDetalle.SelectedTab.Name = "tabAprobarPlanificacion" Then
            Me.tsbEditar.Enabled = False
            blnEditarAprobacion = False
            blnEditarAprobarPlan = False
            blnEditarAprobacionSolicitud = False
        ElseIf tabAprobacionDetalle.SelectedTab.Name = "tabAprobar" Then
            Me.tsbEditar.Enabled = False
            blnEditarAprobacion = False
            blnEditarAprobarPlan = False
            blnEditarAprobacionSolicitud = False
            'Me.pnlAprobarPlan.Enabled = False
            If Me.rbtSolicitud.Checked Then
                If blnEditarAprobacion = False Then
                    If Me.dgvListaAprobacion.Rows.Count > 0 Then
                        LimpiarAprobacion()
                        tsbEditar_Click(Nothing, Nothing)
                    Else
                        LimpiarAprobacion()
                    End If
                End If
            ElseIf Me.rbtPlanificacion.Checked Then
                If blnEditarAprobarPlan = False Then
                    LimpiarAprobarPlan()
                    If Me.dgvListaAprobacion.Rows.Count > 0 Then
                        tsbEditar_Click(Nothing, Nothing)
                    Else
                        LimpiarAprobarPlan()
                    End If
                    ConfigurardgvAprobarPlan()
                End If
            Else
                If blnEditarAprobacionSolicitud = False Then
                    If Me.dgvListaAprobacion.Rows.Count > 0 Then
                        LimpiarAprobacion()
                        tsbEditar_Click(Nothing, Nothing)
                    Else
                        LimpiarAprobacion()
                    End If
                End If
            End If
        ElseIf tabAprobacionDetalle.SelectedTab.Name = "tabAprobarSolicitud" Then
            Me.tsbEditar.Enabled = False
            blnEditarAprobacion = False
            blnEditarAprobarPlan = False
            blnEditarAprobacionSolicitud = False
            If Me.rbtSolicitud.Checked Then
                If blnEditarAprobacionSolicitud = False Then
                    If Me.dgvListaAprobacion.Rows.Count > 0 Then
                        LimpiarAprobacion()
                        tsbEditar_Click(Nothing, Nothing)
                    Else
                        LimpiarAprobacion()
                    End If
                End If
            ElseIf Me.rbtPlanificacion.Checked Then
                If blnEditarAprobarPlan = False Then
                    LimpiarAprobarPlan()
                    If Me.dgvListaAprobacion.Rows.Count > 0 Then
                        tsbEditar_Click(Nothing, Nothing)
                    Else
                        LimpiarAprobarPlan()
                    End If
                    ConfigurardgvAprobarPlan()
                End If
            Else
                If blnEditarAprobacionSolicitud = False Then
                    If Me.dgvListaAprobacion.Rows.Count > 0 Then
                        LimpiarAprobacion()
                        tsbEditar_Click(Nothing, Nothing)
                    Else
                        LimpiarAprobacion()
                    End If
                End If
            End If
        Else
            Me.tsbEditar.Enabled = Me.dgvListaAprobacion.Rows.Count > 0
        End If
    End Sub

    Sub Aprobar()
        Try
            If Me.rbtSiAprobacion.Checked Then
                Dim strMensaje As String = "¿Está Seguro de Aprobar la Solicitud?"
                Dim intRespuesta As DialogResult = MessageBox.Show(strMensaje, "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If intRespuesta = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Me.AprobarSolicitud(3)
                    MessageBox.Show("Solicitud Aprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    GrabarHECompensacion()
                    Me.btnConsultarListaAprobacion_Click(Nothing, Nothing)
                    tabAprobacionDetalle.SelectedTab = tabAprobacionDetalle.TabPages("tabListaAprobacion")
                    Cursor = Cursors.Default
                End If
            Else
                If MessageBox.Show("¿Está Seguro de desaprobar la Solicitud?", "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Me.AprobarSolicitud(5)
                    MessageBox.Show("Solicitud Desaprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.btnConsultarListaAprobacion_Click(Nothing, Nothing)
                    tabAprobacionDetalle.SelectedTab = tabAprobacionDetalle.TabPages("tabListaAprobacion")
                    Cursor = Cursors.Default
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub AprobarSolicitud(ByVal estado As Integer)
        Dim obj As New Cls_HoraExtra_LN

        Dim intID As Integer = Me.dgvListaAprobacion.CurrentRow.Cells("id").Value
        Dim strObservacion As String = IIf(estado = 3, "", Me.txtNoAprobacion.Text.Trim)

        obj.AprobarSolicitud(intID, estado, strObservacion, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
    End Sub

    Private Sub btnAceptarAprobacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarAprobacion.Click
        If Me.rbtNoAprobacion.Checked AndAlso Me.txtNoAprobacion.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese el Motivo", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNoAprobacion.Text = ""
            Me.txtNoAprobacion.Focus()
            Return
        End If

        If Me.lblTipoCompensacionAprobacion.Text = "EFECTIVO" Then
            Dim strPeriodoActual As String = PeriodoActual()
            Dim strPeriodo As String = Cls_HoraExtra_LN.PeriodoActual(lblFechaAprobacion.Text)
            If strPeriodoActual <> strPeriodo Then
                MessageBox.Show("No puede aprobar HHEE en efectivo fuera de su período", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnAceptarAprobacion.Focus()
                Return
            End If
        End If

        Aprobar()
    End Sub

    Private Sub dgvListaAprobacion_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaAprobacion.CellContentClick
        If e.ColumnIndex <> 9 And e.ColumnIndex <> 10 Then Return

        With Me.dgvListaAprobacion
            Dim intId As String = .Rows(e.RowIndex).Cells("id").Value.ToString
            If .Rows(e.RowIndex).Cells("id_estado").Value = 1 Then
                Dim strMensaje As String
                strMensaje = "Nº Planificación : " & intId & Chr(13)
                If e.ColumnIndex = 9 Then
                    strMensaje &= "¿Está seguro de Aprobar?"
                    Dim dlgRespuesta As DialogResult
                    dlgRespuesta = MessageBox.Show(strMensaje, "Aprobar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If dlgRespuesta = Windows.Forms.DialogResult.OK Then
                        AprobarSolicitudPlan(2)
                        .Rows(e.RowIndex).Cells("id_estado").Value = 2
                        .Rows(e.RowIndex).Cells("estado").Value = "APROBADO"
                        Me.btnConsultarListaAprobacion_Click(Nothing, Nothing)
                        Me.btnConsultarListaAprobacion.Focus()
                    End If
                Else
                    strMensaje &= "¿Está seguro de Desaprobar?"
                    Dim blnExito As Boolean = False
                    Do
                        Dim strValor As String = InputBox(strMensaje, "Desaprobar", "Ingrese el motivo")
                        If Not String.IsNullOrEmpty(strValor) Then
                            If strValor.ToUpper = "INGRESE EL MOTIVO" Then
                                MessageBox.Show("Ingrese el motivo", "Desaprobar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                blnExito = True
                                If strValor.Trim.Length > 100 Then
                                    strValor = strValor.Trim.Substring(0, 100)
                                End If
                                AprobarSolicitudPlan(3)
                                .Rows(e.RowIndex).Cells("id_estado").Value = 3
                                .Rows(e.RowIndex).Cells("estado").Value = "DESAPROBADO"
                                Me.btnConsultarListaAprobacion_Click(Nothing, Nothing)
                                Me.btnConsultarListaAprobacion.Focus()
                            End If
                        Else
                            blnExito = True
                        End If
                    Loop Until blnExito
                End If
            Else
                Dim strMensaje As String = IIf(.Rows(e.RowIndex).Cells("id_estado").Value = 2, "Aprobado", "Desaprobado")
                MessageBox.Show("El Nº de Planificación " & intId & " ya se encuentra " & strMensaje, "Aprobar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End With
    End Sub

    Private Sub dgvListaAprobacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvListaAprobacion.DoubleClick
        If Me.dgvListaAprobacion.Rows.Count > 0 Then
            Me.tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub dgvLista_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.RowEnter
        Me.tsbAnular.Enabled = dgvLista.Rows(e.RowIndex).Cells("id_estado").Value = 1
    End Sub

    Sub LlenarLista(ByVal opcion As Integer, ByVal cbo As ComboBox, ByVal fila As Integer)
        cbo.Items.Clear()
        If opcion = 1 Then
            cbo.Items.Add("(TODO)")
            cbo.Items.Add("PENDIENTE")
            cbo.Items.Add("AUTORIZADO")
            cbo.Items.Add("APROBADO")
            cbo.Items.Add("NO AUTORIZADO")
            cbo.Items.Add("DESAPROBADO")
        ElseIf opcion = 2 Then
            cbo.Items.Add("(TODO)")
            cbo.Items.Add("PENDIENTE")
            cbo.Items.Add("APROBADO")
            cbo.Items.Add("DESAPROBADO")
        Else
            cbo.Items.Add("(TODO)")
            cbo.Items.Add("PENDIENTE")
            cbo.Items.Add("APROBADO")
            cbo.Items.Add("DESAPROBADO")
        End If
        cbo.SelectedIndex = fila
        'cbo.Enabled = False
    End Sub

    Private Sub rbtPlanificacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtPlanificacion.CheckedChanged, rbtSolicitud.CheckedChanged, rbtSolicitudCompensado.CheckedChanged
        If IsNothing(tabAprobacionPlanificacion) And IsNothing(tabAprobacionSolicitud) And IsNothing(tabAprobacionSolicitudCompensado) Then Return
        Me.cboEstadoAprobacion.SelectedIndex = 2
        If rbtPlanificacion.Checked Then
            ConfigurardgvListaAprobacion(2)
            Me.LlenarLista(2, cboEstadoAprobacion, 1)
            If tabAprobacionDetalle.TabPages.IndexOf(tabAprobacionSolicitud) > -1 Then
                tabAprobacionDetalle.TabPages.Remove(tabAprobacionDetalle.TabPages("tabAprobar"))
            End If
            If tabAprobacionDetalle.TabPages.IndexOf(tabAprobacionSolicitudCompensado) > -1 Then
                tabAprobacionDetalle.TabPages.Remove(tabAprobacionDetalle.TabPages("tabAprobarSolicitud"))
            End If
            If tabAprobacionDetalle.TabPages.IndexOf(tabAprobacionPlanificacion) = -1 Then
                tabAprobacionDetalle.TabPages.Add(tabAprobacionPlanificacion)
            End If
        ElseIf Me.rbtSolicitud.Checked Then
            ConfigurardgvListaAprobacion(1)
            Me.LlenarLista(1, cboEstadoAprobacion, 2)
            If tabAprobacionDetalle.TabPages.IndexOf(tabAprobacionPlanificacion) > -1 Then
                tabAprobacionDetalle.TabPages.Remove(tabAprobacionDetalle.TabPages("tabAprobarPlanificacion"))
            End If
            If tabAprobacionDetalle.TabPages.IndexOf(tabAprobacionSolicitudCompensado) > -1 Then
                tabAprobacionDetalle.TabPages.Remove(tabAprobacionDetalle.TabPages("tabAprobarSolicitud"))
            End If
            If tabAprobacionDetalle.TabPages.IndexOf(tabAprobacionSolicitud) = -1 Then
                tabAprobacionDetalle.TabPages.Add(tabAprobacionSolicitud)
            End If
        Else
            ConfigurardgvListaAprobacion(3)
            Me.LlenarLista(3, cboEstadoAprobacion, 1)
            If tabAprobacionDetalle.TabPages.IndexOf(tabAprobacionSolicitud) > -1 Then
                tabAprobacionDetalle.TabPages.Remove(tabAprobacionDetalle.TabPages("tabAprobar"))
            End If
            If tabAprobacionDetalle.TabPages.IndexOf(tabAprobacionPlanificacion) > -1 Then
                tabAprobacionDetalle.TabPages.Remove(tabAprobacionDetalle.TabPages("tabAprobarPlanificacion"))
            End If
            If tabAprobacionDetalle.TabPages.IndexOf(tabAprobacionSolicitudCompensado) = -1 Then
                tabAprobacionDetalle.TabPages.Add(tabAprobacionSolicitudCompensado)
            End If
        End If
        Me.btnConsultarListaAprobacion_Click(Nothing, Nothing)
    End Sub

    Sub EditarAprobarPlanificacion()
        With Me.dgvListaAprobacion
            blnEditarAprobarPlan = True
            'blnNuevo = False
            'Me.btnActualizar.Enabled = False
            'Me.dtpInicioAprobarPlan.Enabled = False
            'Me.dtpFinAprobarPlan.Enabled = False
            'Me.lblAreaAprobarPlan.Text = .CurrentRow.Cells("area").Value

            Me.lblInicioAprobarPlan.Text = .CurrentRow.Cells("fecha_inicio").Value
            Me.lblFinAprobarPlan.Text = .CurrentRow.Cells("fecha_fin").Value
            Dim obj As New Cls_HoraExtra_LN
            Dim dt As DataTable = obj.ListarPlanAprobacion(.CurrentRow.Cells("id").Value)
            dgvAprobarPlan.DataSource = dt
            'TotalAprobacion()
        End With
        Me.tabAprobacionDetalle.SelectedIndex = 1
    End Sub

    'Private Sub btnAceptarAprobarPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.rbtNoAprobarPlan.Checked AndAlso Me.txtObservacionAprobarPlan.Text.Trim.Length = 0 Then
    '        MessageBox.Show("Ingrese el Motivo", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Me.txtObservacionAprobarPlan.Text = ""
    '        Me.txtObservacionAprobarPlan.Focus()
    '        Return
    '    End If
    '    AprobarPlan()
    'End Sub

    'Sub AprobarPlan()
    '    Try
    '        If Me.rbtSiAprobarPlan.Checked Then
    '            Dim strMensaje As String = "¿Está Seguro de Aprobar la Solicitud?"
    '            Dim intRespuesta As DialogResult = MessageBox.Show(strMensaje, "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
    '            If intRespuesta = Windows.Forms.DialogResult.Yes Then
    '                Cursor = Cursors.WaitCursor
    '                Me.AprobarSolicitudPlan(2)
    '                MessageBox.Show("Solicitud Aprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                Me.btnConsultarListaAprobacion_Click(Nothing, Nothing)
    '                tabAprobacionDetalle.SelectedTab = tabAprobacionDetalle.TabPages("tabListaAprobacion")
    '                Cursor = Cursors.Default
    '            End If
    '        Else
    '            If MessageBox.Show("¿Está Seguro de desaprobar la Solicitud?", "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
    '                Me.AprobarSolicitudPlan(3)
    '                MessageBox.Show("Solicitud Desaprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                Me.btnConsultarListaAprobacion_Click(Nothing, Nothing)
    '                tabAprobacionDetalle.SelectedTab = tabAprobacionDetalle.TabPages("tabListaAprobacion")
    '                Cursor = Cursors.Default
    '            End If
    '        End If

    '    Catch ex As Exception
    '        Cursor = Cursors.Default
    '        MessageBox.Show(ex.Message, "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Sub AprobarSolicitudPlan(ByVal estado As Integer)
        Dim obj As New Cls_HoraExtra_LN

        Dim intID As Integer = Me.dgvListaAprobacion.CurrentRow.Cells("id").Value
        Dim strObservacion As String = IIf(estado = 2, "", Me.txtNoAprobacion.Text.Trim)

        obj.AprobarSolicitudPlan(intID, estado, strObservacion, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
    End Sub

    Private Sub rbtSiAprobacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiAprobacion.CheckedChanged
        Me.txtNoAprobacion.Text = ""
        Me.txtNoAprobacion.Enabled = False
        Me.btnAceptarAprobacion.Focus()
    End Sub

    Private Sub rbtNoAprobacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoAprobacion.CheckedChanged
        Me.txtNoAprobacion.Text = ""
        Me.txtNoAprobacion.Enabled = True
        Me.txtNoAprobacion.Focus()
    End Sub

    'Private Sub rbtSiAprobarPlan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.txtObservacionAprobarPlan.Text = ""
    '    Me.txtObservacionAprobarPlan.Enabled = False
    '    Me.btnAceptarAprobarPlan.Focus()
    'End Sub

    'Private Sub rbtNoAprobarPlan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.txtObservacionAprobarPlan.Text = ""
    '    Me.txtObservacionAprobarPlan.Enabled = True
    '    Me.txtObservacionAprobarPlan.Focus()
    'End Sub

    Private Sub rbtCosto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtCosto.CheckedChanged
        ConfigurarColumna(2)
    End Sub

    Private Sub btnConsultar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar1.Click
        Dim obj As New Cls_HoraExtra_LN
        Dim dt As DataTable = obj.ListarPlanReal(Me.dtpInicioConsulta.Value.ToShortDateString, Me.dtpFinConsulta.Value.ToShortDateString)
        Me.dgv1.DataSource = dt

        Dim dblPlanificado As Double = 0, dblReal As Double = 0
        Dim c As Integer = -1
        For Each col As DataGridViewColumn In dgv1.Columns
            c += 1
            If c >= 2 Then
                If c Mod 2 = 0 Then
                    col.HeaderText = "Planificado"
                    dblPlanificado += SumaGrid2(dgv1, col.Name)
                Else
                    col.HeaderText = "Real"
                    dblReal += SumaGrid2(dgv1, col.Name)
                End If
                col.DefaultCellStyle.Format = "0.00"
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        Me.lblMontoPlanificado.Text = Format(dblPlanificado, "###,###,###0.00")
        Me.lblMontoReal.Text = Format(dblReal, "###,###,###0.00")

        Me.lblEficiencia.Text = Format(dblPlanificado / IIf(dblReal = 0, 1, dblReal) * 100, "###,###,###0.00")
        Me.lblVariacion.Text = Format(dblPlanificado - dblReal, "###,###,###0.00")
    End Sub

    Private Sub dgv1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles dgv1.Paint
        Try
            If Me.dgv1.Columns.Count < 3 Then Return
            Me.dgv1.ColumnHeadersHeight = 38
            'Dim monthes As String() = {"", "Febrero", "Marzo"}
            Dim intNumero As Integer = DateDiff("D", Me.dtpInicioConsulta.Value.ToShortDateString, Me.dtpFinConsulta.Value.ToShortDateString)
            Dim lista(intNumero) As String
            Dim i As Integer = 0
            Dim fecha As Date = dtpInicioConsulta.Value.ToShortDateString
            While fecha <= dtpFinConsulta.Value.ToShortDateString
                lista(i) = fecha.ToShortDateString
                i += 1
                fecha = DateAdd("D", 1, fecha)
            End While

            Dim j As Integer = 0
            i = -1
            While j < (lista.Length + 1) * 2
                Dim r1 As Rectangle = Me.dgv1.GetCellDisplayRectangle(j, -1, True)
                r1.X += 1
                r1.Y += 1
                r1.Width = r1.Width * 2 - 2
                r1.Height = r1.Height / 2 - 2
                r1.Height -= 5
                e.Graphics.FillRectangle(New SolidBrush(Me.dgv1.RowsDefaultCellStyle.BackColor), r1)
                If j >= 2 Then
                    i += 1
                    Dim format As New StringFormat()
                    format.Alignment = StringAlignment.Center
                    format.LineAlignment = StringAlignment.Center
                    e.Graphics.DrawString(lista(i), Me.dgv1.ColumnHeadersDefaultCellStyle.Font, _
                                          New SolidBrush(Me.dgv1.ColumnHeadersDefaultCellStyle.ForeColor), r1, format)
                End If
                j += 2
            End While
        Catch
        End Try
    End Sub

    Private Sub dgv1_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dgv1.Scroll
        Dim rtHeader As Rectangle = Me.dgv1.DisplayRectangle
        rtHeader.Height = Me.dgv1.ColumnHeadersHeight / 2
        Me.dgv1.Invalidate(rtHeader)
    End Sub

    Private Sub btnConsultarCompensacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarCompensacion.Click
        Dim obj As New Cls_HoraExtra_LN
        Dim dt As DataTable = obj.ListarHECompensada(Me.cboEstadoCompensacion.SelectedIndex, dtoUSUARIOS.IdLogin)
        Me.dgvListaCompensacion.DataSource = dt
        If Me.tabCompensacionDetalle.SelectedIndex = 0 Then
            Me.tsbEditar.Enabled = Me.dgvListaCompensacion.Rows.Count > 0
        End If
    End Sub

    Private Sub btnCerrarSolicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarSolicitud.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está seguro de cerrar la sesión?", "Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            dtpFinListaSolicitud.Value = Now
            dtpInicioListaSolicitud.Value = DateAdd(DateInterval.Month, -1, dtpFinListaSolicitud.Value)
            Me.dgvListaSolicitud.DataSource = Nothing

            Me.dtpInicioCompensacionSolicitud.Value = DateAdd(DateInterval.Month, 1, Now)
            Me.dtpFinCompensacionSolicitud.Value = Now
            cboEstadoCompensacionSolicitud.SelectedIndex = 0
            Me.dgvCompensacionSolicitud.DataSource = Nothing
            Me.ConfigurardgvCompensacionSolicitud()

            Me.cboEstadoSolicitud.SelectedIndex = 1
            Me.tabSolicitudDetalle.SelectedIndex = 0
            Me.txtCodigo.Enabled = True
            Me.txtCodigo.Text = ""
            Me.LimpiarSolicitud(4)
            Me.txtCodigo.Focus()
        End If
    End Sub

    Private Sub btnConsultarCompensacionDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarCompensacionDetalle.Click
        intFilaCompensacion = -1
        Dim obj As New Cls_HoraExtra_LN
        Dim dt As DataTable = obj.ListarHECompensada(Me.dgvListaCompensacion.CurrentRow.Cells("id").Value, _
                                                     Me.dtpInicioCompensacionDetalle.Value.ToShortDateString, _
                                                     Me.dtpFinCompensacionDetalle.Value.ToShortDateString, Me.cboEstadoCompensacionDetalle.SelectedIndex)
        Me.dgvDetalleCompensacion.DataSource = dt
        If Me.dgvDetalleCompensacion.Rows.Count = 0 Then
            Me.dgvDetCompensacion.Rows.Clear()
            Me.tsbGrabar.Enabled = False
        Else
            If Me.dgvDetCompensacion.Rows.Count > 0 Then
                Me.tsbGrabar.Enabled = Me.dgvDetalleCompensacion.CurrentRow.Cells("id_estado").Value = 1
                Me.btnEliminarCompensacion.Enabled = Me.dgvDetCompensacion.CurrentRow.Cells("id_estado").Value = 1 And Me.dgvDetalleCompensacion.CurrentRow.Cells("id_estado").Value = 1
            Else
                Me.tsbGrabar.Enabled = False
            End If
        End If
        TotalCompensacion()
    End Sub

    Private Sub dgvListaCompensacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvListaCompensacion.DoubleClick
        If Me.dgvListaCompensacion.Rows.Count > 0 Then
            Me.tsbEditar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub dgvDetalleCompensacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetalleCompensacion.DoubleClick
        If Me.dgvDetalleCompensacion.Rows.Count > 0 Then
            If Me.dgvDetalleCompensacion.CurrentRow.Cells("saldo").Value <> "00:00" Then
                Dim frm As New frmHoraExtraCompensar
                frm.ID = Me.dgvListaCompensacion.CurrentRow.Cells("id").Value
                frm.IDDet = Me.dgvDetalleCompensacion.CurrentRow.Cells("id").Value

                frm.dgv = dgvDetCompensacion
                frm.Codigo = Me.dgvListaCompensacion.CurrentRow.Cells("codigo").Value
                frm.Horas = Me.dgvDetalleCompensacion.CurrentRow.Cells("saldo").Value
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    'If Not ExisteValorGrid(Me.dgvDetCompensacion, 1, frm.dtpFecha.Value.ToShortDateString) Then
                    AceptarCompensacion(frm)
                    Me.btnEliminarCompensacion.Enabled = Me.dgvDetCompensacion.CurrentRow.Cells("id_estado").Value = 1
                    SubtotalCompensacion()
                    'Else
                    'MessageBox.Show("La fecha ya está compensada", "Compensación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'End If
                End If
            End If
        End If
    End Sub

    Sub TotalCompensacion()
        Dim strHoras As String, strHorasCompensadas As String, strHorasSinCompensar As String

        strHoras = SumaHoras(Me.dgvDetalleCompensacion, "horas")
        strHorasCompensadas = SumaHoras(Me.dgvDetalleCompensacion, "horas_compensadas")
        strHorasSinCompensar = SumaHoras(Me.dgvDetalleCompensacion, "saldo")

        Me.lblHoras1.Text = strHoras
        Me.lblHoras2.Text = strHorasCompensadas
        Me.lblHoras3.Text = strHorasSinCompensar
    End Sub

    Sub SubtotalCompensacion(Optional ByVal fila As Integer = -1)
        Dim intHoras As Integer, intMinutos As Integer, intHorasC As Integer, intMinutosC As Integer
        Dim dblHorasSaldo As Double, dblHorasCompensadas As Double, dblSaldo As Double
        Dim strHoras As String, strHorasCompensadas As String, strHorasSaldo As String, strSaldo As String
        Dim intPosicion As Integer

        strHorasCompensadas = SumaHoras(Me.dgvDetCompensacion, "horas")
        intHorasC = Val(strHorasCompensadas.Substring(0, 2))
        intMinutosC = Val(strHorasCompensadas.Substring(3, 2))

        If fila = -1 Then
            strHoras = Me.dgvDetalleCompensacion.CurrentRow.Cells("horas").Value
        Else
            strHoras = Me.dgvDetalleCompensacion.Rows(fila).Cells("horas").Value
        End If
        intHoras = Val(strHoras.Substring(0, 2))
        intMinutos = Val(strHoras.Substring(3, 2))

        dblHorasSaldo = intHoras + IIf(intMinutos = 0, 0, 0.5)
        dblHorasCompensadas = intHorasC + IIf(intMinutosC = 0, 0, 0.5)
        dblSaldo = dblHorasSaldo - dblHorasCompensadas

        strSaldo = dblSaldo
        strSaldo = Replace(strSaldo, ".5", ".3")
        intPosicion = InStr(strSaldo, ".")
        If intPosicion = 0 Then
            strSaldo = strSaldo & ".0"
            intPosicion = InStr(strSaldo, ".")
        End If
        strHorasSaldo = strSaldo.Substring(0, intPosicion - 1).PadLeft(2, "0") & ":" & strSaldo.Substring(intPosicion).PadRight(2, "0")

        If fila = -1 Then
            Me.dgvDetalleCompensacion.CurrentRow.Cells("horas_compensadas").Value = strHorasCompensadas
            Me.dgvDetalleCompensacion.CurrentRow.Cells("saldo").Value = strHorasSaldo
        Else
            Me.dgvDetalleCompensacion.Rows(fila).Cells("horas_compensadas").Value = strHorasCompensadas
            Me.dgvDetalleCompensacion.Rows(fila).Cells("saldo").Value = strHorasSaldo
        End If

        TotalCompensacion()
    End Sub

    Sub AceptarCompensacion(ByVal frm As frmHoraExtraCompensar)
        Dim intFila As Integer
        With Me.dgvDetCompensacion
            .Rows.Add()
            intFila = .Rows.Count - 1
            .Rows(intFila).Cells("id").Value = 0
            .Rows(intFila).Cells("fecha").Value = frm.dtpFecha.Value.ToShortDateString
            .Rows(intFila).Cells("tipo_compensacion").Value = frm.cboTipoCompensacion.Text
            .Rows(intFila).Cells("idtipo_compensacion").Value = frm.cboTipoCompensacion.SelectedIndex
            .Rows(intFila).Cells("horas").Value = frm.cboHoras.Text
            .Rows(intFila).Cells("observacion").Value = frm.txtObservacion.Text.Trim
            .Rows(intFila).Cells("id_estado").Value = 1 'frm.cboTipoCompensacion.SelectedIndex
            .Rows(intFila).Cells("estado").Value = "PENDIENTE" 'IIf(frm.cboTipoCompensacion.SelectedIndex = 1, "PENDIENTE", "ACEPTADO")
        End With
    End Sub

    Private Sub tabCompensacionDetalle_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabCompensacionDetalle.SelectedIndexChanged
        If Me.tabCompensacionDetalle.SelectedIndex = 0 Then
            blnEditarCompensacion = False
            Me.btnConsultarCompensacion_Click(Nothing, Nothing)
            Me.tsbEditar.Enabled = Me.dgvListaCompensacion.Rows.Count > 0
            Me.tsbGrabar.Enabled = False
        ElseIf Me.tabCompensacionDetalle.SelectedIndex = 1 Then
            Me.tsbEditar.Enabled = False
            If Me.dgvDetCompensacion.Rows.Count > 0 Then
                Me.tsbGrabar.Enabled = Me.dgvListaCompensacion.CurrentRow.Cells("horas").Value <> "00:00"
            Else
                Me.btnConsultarCompensacionDetalle.Enabled = False
            End If
            If Me.dgvListaCompensacion.Rows.Count > 0 Then
                Me.btnConsultarCompensacionDetalle.Enabled = True
                If blnEditarCompensacion = False Then
                    Me.tsbEditar_Click(Nothing, Nothing)
                End If
            Else
                Me.tsbGrabar.Enabled = False
            End If
        ElseIf Me.tabCompensacionDetalle.SelectedIndex = 2 Then
            Me.tsbEditar.Enabled = Me.dgvListaSolicitud2.Rows.Count > 0
            Me.tsbGrabar.Enabled = False
            Me.tabSolicitar2.SelectedIndex = 0
            btnConsultarListaSolicitud2.Focus()
        End If
    End Sub

    Private Sub btnEliminarCompensacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarCompensacion.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está seguro de eliminar el item?", "Compensación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            With Me.dgvDetCompensacion
                .Rows.RemoveAt(.CurrentCell.RowIndex)
                SubtotalCompensacion()
            End With
        End If
    End Sub

    Private Sub dgvDetCompensacion_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetCompensacion.RowEnter
        If IsNothing(dgvDetCompensacion.Rows(e.RowIndex).Cells("id_estado").Value) Then Return
        Me.btnEliminarCompensacion.Enabled = Me.dgvDetalleCompensacion.CurrentRow.Cells("id_estado").Value = 1 And Me.dgvDetCompensacion.Rows(e.RowIndex).Cells("id_estado").Value = 1
    End Sub

    Private Sub dgvDetCompensacion_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvDetCompensacion.RowsAdded
        Me.btnEliminarCompensacion.Enabled = True
        Me.tsbGrabar.Enabled = True
    End Sub

    Private Sub dgvDetCompensacion_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvDetCompensacion.RowsRemoved
        Me.btnEliminarCompensacion.Enabled = Me.dgvDetCompensacion.Rows.Count > 0
        Me.tsbGrabar.Enabled = Me.dgvDetCompensacion.Rows.Count > 0
    End Sub

    Sub ListarCompensacionDet(ByVal id As Integer)
        Dim obj As New Cls_HoraExtra_LN
        With Me.dgvDetCompensacion
            .Rows.Clear()
            Dim dt As DataTable = obj.ListarHECompensadaDet(id)
            If dt.Rows.Count > 0 Then
                Dim intFila As Integer
                For Each row As DataRow In dt.Rows
                    .Rows.Add()
                    intFila = .Rows.Count - 1
                    .Rows(intFila).Cells("id").Value = row.Item("id")
                    .Rows(intFila).Cells("fecha").Value = Format(row.Item("fecha"), "dd/MM/yyyy")
                    .Rows(intFila).Cells("tipo_compensacion").Value = row.Item("tipo_compensacion")
                    .Rows(intFila).Cells("idtipo_compensacion").Value = row.Item("idtipo_compensacion")
                    .Rows(intFila).Cells("horas").Value = row.Item("horas")
                    .Rows(intFila).Cells("observacion").Value = row.Item("observacion")
                    .Rows(intFila).Cells("id_estado").Value = row.Item("id_estado")
                    .Rows(intFila).Cells("estado").Value = row.Item("estado")
                    If IsDBNull(row.Item("fecha_aceptacion")) Then
                        .Rows(intFila).Cells("fecha_aceptacion").Value = ""
                    Else
                        .Rows(intFila).Cells("fecha_aceptacion").Value = Format(row.Item("fecha_aceptacion"), "dd/MM/yyyy")
                    End If
                    If IsDBNull(row.Item("fecha_envio")) Then
                        .Rows(intFila).Cells("fecha_envio").Value = ""
                    Else
                        .Rows(intFila).Cells("fecha_envio").Value = Format(row.Item("fecha_envio"), "dd/MM/yyyy")
                    End If
                Next
            End If
        End With
    End Sub

    Sub GrabarCompensacion()
        Try
            Cursor = Cursors.AppStarting
            Dim intID As Integer, intIdDet As Integer, intRegistro As Integer
            Dim strHorasCompensadas As String, strSaldo As String
            strHorasCompensadas = Me.dgvDetalleCompensacion.CurrentRow.Cells("horas_compensadas").Value
            strSaldo = Me.dgvDetalleCompensacion.CurrentRow.Cells("saldo").Value

            Dim obj As New Cls_HoraExtra_LN
            intID = Me.dgvListaCompensacion.CurrentRow.Cells("id").Value
            intIdDet = Me.dgvDetalleCompensacion.CurrentRow.Cells("id").Value
            With Me.dgvDetCompensacion
                intRegistro = 0
                For Each row As DataGridViewRow In .Rows
                    obj.GrabarHECompensada(intID, intIdDet, row.Cells("fecha").Value, row.Cells("idtipo_compensacion").Value, row.Cells("horas").Value, row.Cells("observacion").Value, _
                                           strHorasCompensadas, strSaldo, intRegistro, row.Cells("id_estado").Value, _
                                           row.Cells("usuario_aceptacion").Value, row.Cells("fecha_aceptacion").Value, row.Cells("ip_aceptacion").Value, row.Cells("rol_aceptacion").Value, _
                                           row.Cells("usuario_envio").Value, row.Cells("fecha_envio").Value, row.Cells("ip_envio").Value)
                    intRegistro += 1
                Next
                Dim dt As DataTable
                Dim strCodigo As String = Me.dgvListaCompensacion.CurrentRow.Cells("codigo").Value
                dt = obj.ListarHECompensada(strCodigo)
                Dim strHorasTotal As String = SumaHoras(dt, "saldo")
                Cls_HoraExtra_LN.GrabarHECompensada(strCodigo, strHorasTotal)
            End With
            Me.btnConsultarCompensacionDetalle_Click(Nothing, Nothing)
            If Me.lblHoras3.Text = "00:00" Then
                Me.tabCompensacionDetalle.SelectedIndex = 0
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnConsultarCompensacionSolicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarCompensacionSolicitud.Click
        Dim obj As New Cls_HoraExtra_LN
        Dim dt As DataTable = obj.ListarHECompensadaDet(Me.dtpInicioCompensacionSolicitud.Value.ToShortDateString, _
                                                      Me.dtpFinCompensacionSolicitud.Value.ToShortDateString, _
                                                      Me.txtCodigo.Text.Trim, _
                                                      Me.cboEstadoCompensacionSolicitud.SelectedIndex)
        Me.dgvCompensacionSolicitud.DataSource = dt
    End Sub

    Sub AceptarCompensacion()
        Dim frmUsuarioConfirmar As New frmUsuarioValor
        frmUsuarioConfirmar.lblAgencia.Text = dtoUSUARIOS.m_iNombreAgencia
        frmUsuarioConfirmar.txtUsuario.Text = ""
        frmUsuarioConfirmar.intLLamada = 1
        frmUsuarioConfirmar.ShowDialog()
        If frmUsuarioConfirmar.Resultado = 0 Then
            Return
        End If
        Dim intUsuario As Integer = frmUsuarioConfirmar.IDUsuario
        Dim intRol As Integer = frmUsuarioConfirmar.cboRol.SelectedValue

        Dim obj As New Cls_HoraExtra_LN
        obj.AceptarCompensacion(dgvCompensacionSolicitud.CurrentRow.Cells("id").Value, intUsuario, dtoUSUARIOS.IP, intRol)
    End Sub

    Private Sub dgvCompensacionSolicitud_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCompensacionSolicitud.CellContentClick
        If e.ColumnIndex <> 5 Then Return
        Dim dlgRespuesta As DialogResult
        Dim strMensaje As String
        Dim intEstado As Integer = dgvCompensacionSolicitud.Rows(e.RowIndex).Cells("id_estado").Value

        If intEstado = 0 Then
            dgvCompensacionSolicitud.Rows(e.RowIndex).Cells("id_estado").Value = 1
            dgvCompensacionSolicitud.RefreshEdit()
            Return
        End If

        If dgvCompensacionSolicitud.Rows(e.RowIndex).Cells("tipo_compensacion").Value = "EFECTIVO" Then
            Dim strPeriodoActual As String = PeriodoActual()
            Dim strPeriodo As String = Cls_HoraExtra_LN.PeriodoActual(dgvCompensacionSolicitud.Rows(e.RowIndex).Cells("fecha").Value)
            If strPeriodoActual <> strPeriodo Then
                MessageBox.Show("No puede autorizar HHEE en efectivo fuera de su período", "Aceptar Compensación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnConsultarCompensacionSolicitud.Focus()
                dgvCompensacionSolicitud.Rows(e.RowIndex).Cells("id_estado").Value = 0
                dgvCompensacionSolicitud.RefreshEdit()
                Return
            End If
        End If

        'If intEstado = 0 Then
        Dim frm As New frmHoraExtraConvenio
        frm.id = dgvCompensacionSolicitud.Rows(e.RowIndex).Cells("id").Value
        frm.WindowState = FormWindowState.Maximized
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            AceptarCompensacion()
            btnConsultarCompensacionSolicitud_Click(Nothing, Nothing)
        Else
            dgvCompensacionSolicitud.Rows(e.RowIndex).Cells("id_estado").Value = 0
            dgvCompensacionSolicitud.RefreshEdit()
        End If
        'End If
        Return

        If intEstado = 1 Then
            dlgRespuesta = MessageBox.Show("Está seguro de aceptar la compensación?", "Aceptar Compensación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                AceptarCompensacion()
                btnConsultarCompensacionSolicitud_Click(Nothing, Nothing)
            Else
                dgvCompensacionSolicitud.Rows(e.RowIndex).Cells("id_estado").Value = 0
                dgvCompensacionSolicitud.RefreshEdit()
            End If
        End If
    End Sub

    Private Sub dgvCompensacionSolicitud_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCompensacionSolicitud.CellContentDoubleClick
        If e.ColumnIndex <> 5 Then Return
        Dim dlgRespuesta As DialogResult
        Dim strMensaje As String
        Dim intEstado As Integer = dgvCompensacionSolicitud.Rows(e.RowIndex).Cells("id_estado").Value

        If intEstado = 0 Then
            dgvCompensacionSolicitud.Rows(e.RowIndex).Cells("id_estado").Value = 1
            dgvCompensacionSolicitud.RefreshEdit()
        End If

        If intEstado = 1 Then
            dlgRespuesta = MessageBox.Show("Está seguro de aceptar la compensación?", "Aceptar Compensación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                AceptarCompensacion()
                btnConsultarCompensacionSolicitud_Click(Nothing, Nothing)
            Else
                dgvCompensacionSolicitud.Rows(e.RowIndex).Cells("id_estado").Value = 0
                dgvCompensacionSolicitud.RefreshEdit()
            End If
        End If
    End Sub

    Private Sub dgvCompensacionSolicitud_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCompensacionSolicitud.CurrentCellDirtyStateChanged
        dgvCompensacionSolicitud.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Sub AprobarPlanDetalle(ByVal id As Integer, ByVal id_det As Integer, ByVal fecha As String)
        Dim obj As New Cls_HoraExtra_LN
        obj.AprobarSolicitudPlanDet(id, id_det, fecha, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
    End Sub

    Sub DesaprobarPlanDetalle(ByVal id As Integer, ByVal id_det As Integer, ByVal fecha As String, ByVal motivo As String)
        Dim obj As New Cls_HoraExtra_LN
        obj.DesaprobarPlanDet(id, id_det, fecha, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol, motivo)
    End Sub

    Private Sub dgvAprobarPlan_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAprobarPlan.CellContentClick
        If e.ColumnIndex <> 9 And e.ColumnIndex <> 10 Then Return

        With Me.dgvAprobarPlan
            If .Rows(e.RowIndex).Cells("id_estado").Value = 1 Then
                Dim intId As String = .Rows(e.RowIndex).Cells("id").Value.ToString
                Dim intIdDet As String = .Rows(e.RowIndex).Cells("id_det").Value.ToString
                Dim strCodigo As String = .Rows(e.RowIndex).Cells("codigo").Value.ToString
                Dim strTrabajador As String = .Rows(e.RowIndex).Cells("nombres").Value.ToString
                Dim strFecha As String = Format(.Rows(e.RowIndex).Cells("fecha").Value, "dd/MM/yyyy")
                Dim strHoras As String = .Rows(e.RowIndex).Cells("horas").Value.ToString
                Dim strCosto As String = .Rows(e.RowIndex).Cells("costo").Value.ToString

                Dim strMensaje As String
                strMensaje = strTrabajador & Chr(13)
                strMensaje &= "Fecha : " & strFecha & "  " & "Horas : " & strHoras & "  " & "Costo : " & strCosto & Chr(13) & Chr(13)
                If e.ColumnIndex = 9 Then
                    strMensaje &= "¿Está seguro de aprobarlo?"
                    Dim dlgRespuesta As DialogResult
                    dlgRespuesta = MessageBox.Show(strMensaje, "Aprobar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If dlgRespuesta = Windows.Forms.DialogResult.OK Then
                        AprobarPlanDetalle(intId, intIdDet, strFecha)
                        .Rows(e.RowIndex).Cells("id_estado").Value = 2
                        .Rows(e.RowIndex).Cells("estado").Value = "APROBADO"
                        btnConsultarListaAprobacion_Click(Nothing, Nothing)
                    End If
                Else
                    strMensaje &= "¿Está seguro de Desaprobarlo?"
                    Dim blnExito As Boolean = False
                    Do
                        Dim strValor As String = InputBox(strMensaje, "Desaprobar", "Ingrese el motivo")
                        If Not String.IsNullOrEmpty(strValor) Then
                            If strValor.ToUpper = "INGRESE EL MOTIVO" Then
                                MessageBox.Show("Ingrese el motivo", "Desaprobar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                blnExito = True
                                If strValor.Trim.Length > 100 Then
                                    strValor = strValor.Trim.Substring(0, 100)
                                End If
                                DesaprobarPlanDetalle(intId, intIdDet, strFecha, strValor)
                                .Rows(e.RowIndex).Cells("id_estado").Value = 3
                                .Rows(e.RowIndex).Cells("estado").Value = "DESAPROBADO"
                            End If
                        Else
                            blnExito = True
                        End If
                    Loop Until blnExito
                End If
            Else
                Dim strMensaje As String = IIf(.Rows(e.RowIndex).Cells("id_estado").Value = 2, "Aprobado", "Desaprobado")
                MessageBox.Show("El Item ya se encuentra " & strMensaje, "Aprobar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End With

        'If e.ColumnIndex <> 8 Then Return
        'Dim intEstado As Integer = dgvAprobarPlan.Rows(e.RowIndex).Cells("id_estado").Value
        'If intEstado > 1 Then
        '    dgvAprobarPlan.Rows(e.RowIndex).Cells("id_estado").Value = dgvAprobarPlan.Rows(e.RowIndex).Cells("aprobado").Value
        '    dgvAprobarPlan.RefreshEdit()
        'End If
    End Sub

    Private Sub btnConsultarMantenimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarMantenimiento.Click
        Dim obj As New Cls_HoraExtra_LN
        Dim dt As DataTable = obj.ListarTrabajador(dtoUSUARIOS.IdLogin)
        Me.dgvListaMantenimiento.DataSource = dt
        Me.tsbEditar.Enabled = Me.dgvListaMantenimiento.Rows.Count > 0
        If Me.dgvListaMantenimiento.Rows.Count = 0 Then
            Me.grbHorarioMantenimiento.Enabled = False
        End If
    End Sub

    Sub LimpiarMantenimiento()
        Me.grbHorarioMantenimiento.Enabled = False
    End Sub

    Sub ListarHorario(ByVal id As Integer)
        Dim obj As New Cls_HoraExtra_LN
        Dim intID As Integer

        Dim dt As DataTable = obj.ListarHorario(id)
        Me.dgvHorarioMantenimiento.DataSource = dt
    End Sub

    Private Sub dgvListaMantenimiento_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaMantenimiento.RowEnter
        Try
            Cursor = Cursors.WaitCursor
            RemoveHandler Me.chkObrero.CheckedChanged, AddressOf Me.chkObrero_CheckedChanged
            Me.chkObrero.Checked = Me.dgvListaMantenimiento.Rows(e.RowIndex).Cells("obrero").Value
            AddHandler Me.chkObrero.CheckedChanged, AddressOf Me.chkObrero_CheckedChanged

            Dim intID As Integer
            intID = Me.dgvListaMantenimiento.Rows(e.RowIndex).Cells("id").Value
            ListarHorario(intID)
            Me.grbHorarioMantenimiento.Enabled = Me.dgvHorarioMantenimiento.Rows.Count > 0
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvHorarioMantenimiento_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHorarioMantenimiento.RowEnter
        With Me.dgvHorarioMantenimiento
            Dim strInicio As String, strFin As String
            If IsDBNull(.Rows(e.RowIndex).Cells("inicio").Value) Then
                strInicio = Me.dtpInicioMantenimiento.Value.ToShortDateString & " " & "00:00"
                Me.dtpInicioMantenimiento.Enabled = False
                Me.dtpFinMantenimiento.Enabled = False
            Else
                strInicio = Me.dtpInicioMantenimiento.Value.ToShortDateString & " " & Format(CType(.Rows(e.RowIndex).Cells("inicio").Value, Date), "HH:mm")
            End If
            If IsDBNull(.Rows(e.RowIndex).Cells("fin").Value) Then
                strFin = Me.dtpInicioMantenimiento.Value.ToShortDateString & " " & "00:00"
            Else
                strFin = Me.dtpFinMantenimiento.Value.ToShortDateString & " " & Format(CType(.Rows(e.RowIndex).Cells("fin").Value, Date), "HH:mm")
            End If
            Me.dtpInicioMantenimiento.Value = strInicio
            Me.dtpFinMantenimiento.Value = strFin
            RemoveHandler chkDescansoMantenimiento.CheckedChanged, AddressOf chkDescansoMantenimiento_CheckedChanged
            Me.chkDescansoMantenimiento.Checked = .Rows(e.RowIndex).Cells("iddescanso").Value
            AddHandler chkDescansoMantenimiento.CheckedChanged, AddressOf chkDescansoMantenimiento_CheckedChanged
            If Me.chkDescansoMantenimiento.Checked Then
                Me.dtpInicioMantenimiento.Enabled = False
                Me.dtpFinMantenimiento.Enabled = False
            Else
                Me.dtpInicioMantenimiento.Enabled = True
                Me.dtpFinMantenimiento.Enabled = True
            End If
        End With
    End Sub

    Private Sub chkDescansoMantenimiento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDescansoMantenimiento.CheckedChanged
        If chkDescansoMantenimiento.Checked Then
            Me.dtpInicioMantenimiento.Value = Me.dtpInicioMantenimiento.Value.ToShortDateString & " " & "00:00"
            Me.dtpFinMantenimiento.Value = Me.dtpFinMantenimiento.Value.ToShortDateString & " " & "00:00"
            Me.dtpInicioMantenimiento.Enabled = False
            Me.dtpFinMantenimiento.Enabled = False
        Else
            Me.dtpInicioMantenimiento.Value = Me.dtpInicioMantenimiento.Value.ToShortDateString & " " & Me.dgvHorarioMantenimiento.CurrentRow.Cells("inicio").Value
            Me.dtpFinMantenimiento.Value = Me.dtpFinMantenimiento.Value.ToShortDateString & " " & Me.dgvHorarioMantenimiento.CurrentRow.Cells("fin").Value
            Me.dtpInicioMantenimiento.Enabled = True
            Me.dtpFinMantenimiento.Enabled = True
        End If
    End Sub

    Private Sub btnGrabarMantenimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabarMantenimiento.Click
        Try
            If Me.chkDescansoMantenimiento.Checked = False Then
                If Me.dtpInicioMantenimiento.Value = Me.dtpFinMantenimiento.Value Then
                    MessageBox.Show("La Hora inicio no puede ser igual a la Hora fin", "Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.dtpInicioMantenimiento.Focus()
                    Return
                End If
                If Me.dtpInicioMantenimiento.Value > Me.dtpFinMantenimiento.Value Then
                    MessageBox.Show("La Hora inicio no puede ser mayor a la Hora fin", "Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.dtpInicioMantenimiento.Focus()
                    Return
                End If
                If DateDiff(DateInterval.Minute, Me.dtpInicioMantenimiento.Value, Me.dtpFinMantenimiento.Value) < 60 Then
                    MessageBox.Show("El Rango Horario debe ser a partir de 1 hora", "Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.dtpInicioMantenimiento.Focus()
                    Return
                End If
            End If

            Cursor = Cursors.WaitCursor
            Dim intDia As Integer
            Dim strInicio As String, strFin As String
            Select Case Me.dgvHorarioMantenimiento.CurrentRow.Cells("dia").Value.ToString.Trim.Substring(0, 3).ToUpper
                Case "LUN"
                    intDia = 1
                Case "MAR"
                    intDia = 2
                Case "MIE"
                    intDia = 3
                Case "JUE"
                    intDia = 4
                Case "VIE"
                    intDia = 5
                Case "SAB"
                    intDia = 6
                Case "DOM"
                    intDia = 7
            End Select
            strInicio = IIf(Me.dtpInicioMantenimiento.Text = "00:00", "", Me.dtpInicioMantenimiento.Text)
            strFin = IIf(Me.dtpFinMantenimiento.Text = "00:00", "", Me.dtpFinMantenimiento.Text)
            Dim obj As New Cls_HoraExtra_LN
            obj.GrabarTrabajadorHorario(Me.dgvListaMantenimiento.CurrentRow.Cells("id").Value, Me.dgvHorarioMantenimiento.CurrentRow.Cells("id").Value, _
                                        strInicio, strFin, _
                                        IIf(Me.chkDescansoMantenimiento.Checked, 1, 0), intDia)
            Dim intFila As Integer = Me.dgvHorarioMantenimiento.CurrentCell.RowIndex
            Dim intID As Integer = Me.dgvListaMantenimiento.CurrentRow.Cells("id").Value
            ListarHorario(intID)
            Me.dgvHorarioMantenimiento.CurrentCell = Me.dgvHorarioMantenimiento(1, intFila)
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtpInicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInicio.ValueChanged
        Me.dgvPlanificacion.DataSource = Nothing
        Me.ConfigurardgvPlanificacion()
        dtPlanificacion.Rows.Clear()
        dtHora.Rows.Clear()
        Total()
    End Sub

    Private Sub dgvListaSolicitud_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaSolicitud.RowEnter
        If intPerfil = 1 Then
            Me.tsbAnular.Enabled = Me.dgvListaSolicitud.Rows(e.RowIndex).Cells("id_estado").Value < 3
        Else
            Me.tsbAnular.Enabled = Me.dgvListaSolicitud.Rows(e.RowIndex).Cells("id_estado").Value = 1
        End If
    End Sub

    Private Sub frmHoraExtra_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ControlaAcceso()
    End Sub

    Sub ControlaAcceso()
        Dim opcion(8) As Integer
        If Acceso.SiRol(G_Rol, Me, 1, 1) Then 'jefe de area
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabAprobacion"))
            'Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabSolicitud"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabConfiguracion"))
            opcion(1) = 1 : opcion(2) = 1 : opcion(3) = 1 : opcion(4) = 0 : opcion(5) = 1 : opcion(6) = 1 : opcion(7) = 1
            intPerfil = 1
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 2) Then 'gerente
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabPlanificacion"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabSolicitud"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabAutorizacion"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabCompensacion"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabMantenimiento"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabConfiguracion"))
            opcion(1) = 0 : opcion(2) = 0 : opcion(3) = 0 : opcion(4) = 1 : opcion(5) = 0 : opcion(6) = 1 : opcion(7) = 1
            intPerfil = 2
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 3) Then 'trabajador
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabPlanificacion"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabAutorizacion"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabAprobacion"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabCompensacion"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabMantenimiento"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabConsulta"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabConfiguracion"))
            opcion(1) = 0 : opcion(2) = 1 : opcion(3) = 0 : opcion(4) = 0 : opcion(5) = 0 : opcion(6) = 0 : opcion(7) = 0
            intPerfil = 3
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 4) Then 'sistemas
            opcion(1) = 1 : opcion(2) = 1 : opcion(3) = 1 : opcion(4) = 1 : opcion(5) = 1 : opcion(6) = 1 : opcion(7) = 1 : opcion(8) = 1
            intPerfil = 4
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 5) Then 'direccion
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabPlanificacion"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabSolicitud"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabAutorizacion"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabAprobacion"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabCompensacion"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabMantenimiento"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabConfiguracion"))
            opcion(1) = 0 : opcion(2) = 0 : opcion(3) = 0 : opcion(4) = 0 : opcion(5) = 0 : opcion(6) = 0 : opcion(7) = 1
            intPerfil = 5
        ElseIf Acceso.SiRol(G_Rol, Me, 1, 6) Then 'administra
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabPlanificacion"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabSolicitud"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabAutorizacion"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabAprobacion"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabCompensacion"))
            Me.tabHoraExtra.TabPages.Remove(tabHoraExtra.TabPages("tabMantenimiento"))
            opcion(1) = 0 : opcion(2) = 0 : opcion(3) = 0 : opcion(4) = 0 : opcion(5) = 0 : opcion(6) = 0 : opcion(7) = 1 : opcion(8) = 1
            intPerfil = 6
        End If

        For i As Integer = 1 To opcion.Length - 1
            Select Case i
                Case 1
                    If opcion(i) = 1 Then
                        'planificacion
                        dtpInicioLista.Value = DateAdd(DateInterval.Month, -1, dtpFinLista.Value)
                        Me.lblNombres.Text = dtoUSUARIOS.NameLogin
                        Me.lblDepartamento.Text = IIf(dtoUSUARIOS.CentroCosto = "0", "", dtoUSUARIOS.CentroCosto) & " " & dtoUSUARIOS.CentroCostoDescripcion
                        ConfigurardgvLista()
                        ConfigurardgvPlanificacion()
                        cboEstado.SelectedIndex = 1
                    End If
                Case 2
                    If opcion(i) = 1 Then
                        'solicitud
                        dtpInicioListaSolicitud.Value = DateAdd(DateInterval.Month, -3, dtpFinListaSolicitud.Value)
                        Me.cboEstadoSolicitud.SelectedIndex = 1

                        Me.cboEstadoCompensacionSolicitud.SelectedIndex = 0
                        Me.dtpInicioCompensacionSolicitud.Value = DateAdd(DateInterval.Month, -1, Now)
                        Me.dtpFinCompensacionSolicitud.Value = Now
                    End If
                Case 3
                    If opcion(i) = 1 Then
                        'autorizacion
                        blnEditarAutorizacion = False
                        ConfigurardgvListaAutorizacion()
                        dtpInicioListaAutorizacion.Value = DateAdd(DateInterval.Month, -1, dtpFinListaAutorizacion.Value)
                        Me.cboEstadoAutorizacion.SelectedIndex = 1
                        ConfigurardgvSobretiempoAutorizacion()
                    End If
                Case 4
                    If opcion(i) = 1 Then
                        'aprobacion
                        blnEditarAprobacion = False
                        blnEditarAprobacionSolicitud = False
                        blnEditarSolicitudCompensacion = False
                        ConfigurardgvListaAprobacion(1)
                        dtpInicioListaAprobacion.Value = DateAdd(DateInterval.Month, -1, dtpFinListaAprobacion.Value)
                        Me.cboEstadoAprobacion.SelectedIndex = 2
                        ConfigurardgvSobretiempoAprobacion()
                        tabAprobacionSolicitud = tabAprobacionDetalle.TabPages("tabAprobar")
                        tabAprobacionPlanificacion = tabAprobacionDetalle.TabPages("tabAprobarPlanificacion")
                        tabAprobacionSolicitudCompensado = tabAprobacionDetalle.TabPages("tabAprobarSolicitud")

                        blnEditarAprobarPlan = False
                        Me.rbtPlanificacion.Checked = True
                        ConfigurardgvAprobarPlan()
                    End If
                Case 5
                    If opcion(1) = 1 Then
                        ConfigurardgvListaCompensacion()
                        ConfigurardgvDetalleCompensacion()
                        ConfigurardgvDetCompensacion()
                        ConfigurardgvCompensacionSolicitud()
                        ConfigurardgvListaSolicitud2()
                        ConfigurardgvDetalleSolicitud2()
                    End If
                Case 6
                    If opcion(i) = 1 Then
                        'mantenimiento
                        ConfigurardgvListaMantenimiento()
                        ConfigurardgvMantenimiento()
                    End If
                Case 7
                    If opcion(i) = 1 Then
                        'consultas
                        Configurardgv1()
                        ConfigurardgvHe()
                        ConfigurardgvHe2()
                        ListarArea(Me.cboAreaHe, dtoUSUARIOS.IdLogin, intPerfil)
                        ListarArea(Me.cboAreaHE2, dtoUSUARIOS.IdLogin, intPerfil)
                    End If
            End Select
        Next
    End Sub

    Sub Accion()
        Me.lblAccion.Text = IIf(blnNuevoRegistro, "AGREGANDO", "MODIFICANDO")
    End Sub

    'Private Sub tiempo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tiempo.Tick
    '    Try
    '        If intPerfil = 3 Then
    '            tiempo.Enabled = False
    '            tiempo.Interval = 1800000
    '            ImportarData("PE092018.DBF")
    '            tiempo.Enabled = True
    '        Else
    '            tiempo.Enabled = False
    '        End If
    '    Catch ex As Exception
    '        If tiempo.Enabled = False Then
    '            tiempo.Enabled = True
    '        End If
    '    End Try
    'End Sub

    Sub EstadoFeriado()
        Dim blnFeriado As Boolean = EsFeriado(Me.dtpFechaSolicitud.Value.ToShortDateString)
        Me.lblFeriado.Text = IIf(blnFeriado, "FERIADO", "")
    End Sub

    Private Sub dgvDetalleCompensacion_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalleCompensacion.RowEnter
        If Me.dgvDetalleCompensacion.Rows.Count = 0 Then Return
        If intFilaCompensacion = e.RowIndex Then Return
        Dim intId As Integer
        intId = Me.dgvDetalleCompensacion.Rows(e.RowIndex).Cells("id").Value
        Me.ListarCompensacionDet(intId)
        Me.tsbGrabar.Enabled = Me.dgvDetalleCompensacion.Rows(e.RowIndex).Cells("id_estado").Value = 1 And Me.dgvDetCompensacion.Rows.Count > 0
        If Me.dgvDetCompensacion.Rows.Count > 0 Then
            Me.btnEliminarCompensacion.Enabled = Me.dgvDetalleCompensacion.Rows(e.RowIndex).Cells("id_estado").Value = 1 And Me.dgvDetCompensacion.CurrentRow.Cells("id_estado").Value = 1
        End If
        intFilaCompensacion = e.RowIndex

        SubtotalCompensacion(intFilaCompensacion)
    End Sub

    Sub ListarArea(ByVal cbo As ComboBox, ByVal usuario As Integer, ByVal perfil As Integer)
        With cbo
            Dim obj As New Cls_HoraExtra_LN
            Dim dt As DataTable = obj.ListarArea(usuario, perfil)
            .DisplayMember = "descripcion"
            .ValueMember = "id"
            .DataSource = dt
            If perfil = 1 Then
                '.SelectedValue = dtoUSUARIOS.CentroCosto
                '.Enabled = False
            End If
        End With
    End Sub

    Sub TotalHe()
        Dim dblHe As Double, dblEfectivo As Double, dblDescanso As Double, dblSaldo As Double

        dblHe = SumaGrid2(Me.dgvHe, "horas")
        dblEfectivo = SumaGrid2(Me.dgvHe, "efectivo")
        dblDescanso = SumaGrid2(Me.dgvHe, "descanso")
        dblSaldo = SumaGrid2(Me.dgvHe, "saldo")

        Me.lblHe.Text = Format(dblHe, "###,###,###0.00")
        Me.lblEfectivo.Text = Format(dblEfectivo, "###,###,###0.00")
        Me.lblDescanso.Text = Format(dblDescanso, "###,###,###0.00")
        Me.lblSaldo.Text = Format(dblSaldo, "###,###,###0.00")
    End Sub

    Private Sub btnConsultarHe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarHe.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_HoraExtra_LN
            Dim strCodigo As String = IIf(Me.cboTrabajadorHe.SelectedValue = 0, "", Me.cboTrabajadorHe.SelectedValue)
            Dim dt As DataTable = obj.ListarHHEE(dtpInicioHe.Value.ToShortDateString, Me.dtpFinHe.Value.ToShortDateString, Me.cboAreaHe.SelectedValue, strCodigo, dtoUSUARIOS.IdLogin, intPerfil, Me.cboEstadoHe.SelectedIndex - 1)
            Me.dgvHe.DataSource = dt
            TotalHe()

            Dim h1 As Double, h2 As Double, h3 As Double, h4 As Double
            TotalizarHoraExtra(dt, h1, h2, h3, h4)
            Me.lbl25.Text = Format(h1, "0.00")
            Me.lbl35.Text = Format(h2, "0.00")
            Me.lbl100.Text = Format(h3, "0.00")
            Me.lbl150.Text = Format(h4, "0.00")
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ListarTrabajador(ByVal area As Integer, ByVal inicio As String, ByVal fin As String, ByVal estado As Integer)
        Dim obj As New Cls_HoraExtra_LN
        Dim dt As DataTable = obj.ListarTrabajador(area, inicio, fin, estado)
        With Me.cboTrabajadorHe
            .DisplayMember = "nombres"
            .ValueMember = "codigo"
            .DataSource = dt
            .SelectedValue = 0
        End With
    End Sub

    Sub ListarTrabajadorSolicitud(ByVal area As Integer, ByVal inicio As String, ByVal fin As String, ByVal estado As Integer)
        Dim obj As New Cls_HoraExtra_LN
        Dim dt As DataTable = obj.ListarTrabajadorSolicitud(area, inicio, fin, estado)
        With Me.cboTrabajadorHE2
            .DisplayMember = "nombres"
            .ValueMember = "codigo"
            .DataSource = dt
            .SelectedValue = 0
        End With
    End Sub

    Private Sub cboAreaHe_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAreaHe.SelectedIndexChanged
        Me.ListarTrabajador(Me.cboAreaHe.SelectedValue, Me.dtpInicioHe.Value.ToShortDateString, Me.dtpFinHe.Value.ToShortDateString, Me.cboEstadoHe.SelectedIndex - 1)
    End Sub

    Private Sub dtpInicioHe_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInicioHe.ValueChanged
        'Me.ListarTrabajador(Me.cboAreaHe.SelectedValue, Me.dtpInicioHe.Value.ToShortDateString, Me.dtpFinHe.Value.ToShortDateString, Me.cboEstadoHe.SelectedIndex - 1)
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim dt As DataTable
    '    dt = CargarHHEE("26/07/2018", "25/08/2018")
    '    Me.dgv.DataSource = dt
    'End Sub

    Function ObtieneItem(ByVal lista As Array, ByVal id As Integer) As Integer
        For Each obj As Arbol In lista
            If Not IsNothing(obj.id) Then
                If obj.pk = id Then
                    Return obj.id2
                End If
            End If
        Next
        Return 0
    End Function

    Function ObtienePadre(ByVal lista As Array, ByVal id As Integer, ByVal nivel As Integer, ByVal id2 As Integer) As TreeNode
        Dim intNivel As Integer = nivel - 1
        For Each obj As Arbol In lista
            If Not IsNothing(obj.id) Then
                If obj.id = id And obj.nivel = intNivel Then
                    If nivel = 3 Then
                        If obj.id2 = id2 Then
                            Return obj.nodo
                        End If
                    Else
                        Return obj.nodo
                    End If
                End If
            End If
        Next
        Return Nothing
    End Function

    Sub AsignarTrabajador()
        Dim i As Integer = 0, intNivel As Integer, intID As Integer, intID2 As Integer
        With treeTrabajador
            Dim item1 As Integer = 0
            .Nodes.Clear()
            .Nodes.Add("0", "NIVEL")
            .Nodes(0).SelectedImageIndex = 0
            .Nodes(0).ImageIndex = 0

            Dim nodo As New TreeNode, nodo1 As New TreeNode, nodo2 As New TreeNode
            Dim obj As New Cls_HoraExtra_LN
            Dim dt As DataTable = obj.ListarUsuarioArea
            For Each row As DataRow In dt.Rows
                intNivel = row.Item("nivel")
                If intNivel = 1 Then
                    nodo = .Nodes(0).Nodes.Add(row("id_cap"), row.Item("cap"))
                    nodo.Tag = row("pk")
                    intID = row("id")
                    intID2 = row("padre")
                ElseIf intNivel = 2 Then
                    nodo = ObtienePadre(lista, row("padre"), intNivel, row("id"))
                    nodo = nodo.Nodes.Add(row("id_cap"), row.Item("cap"))
                    nodo.Tag = row("pk")
                    intID = row("id")
                    intID2 = row("padre")
                ElseIf intNivel = 3 Then
                    nodo = ObtienePadre(lista, row("padre"), intNivel, row("id"))
                    If Not IsNothing(nodo) Then
                        nodo = nodo.Nodes.Add(row("id_cap"), row.Item("cap"))
                        nodo.Tag = row("pk")
                        intID = row("id")
                        intID2 = row("padre")
                    End If
                End If
                i += 1
                ReDim Preserve lista(i)
                lista(i).nodo = nodo
                lista(i).id = intID
                lista(i).nivel = intNivel
                lista(i).id2 = intID2
                lista(i).pk = nodo.Tag
            Next
            .Nodes(0).Expand()
        End With
    End Sub

    Sub ListarUsuarioArea(ByVal cap As Integer, ByVal nivel As Integer, ByVal id As Integer)
        Dim obj As New Cls_HoraExtra_LN
        Dim dt As DataTable = obj.ListarUsuarioArea(cap, nivel, id)
        Me.dgvTrabajador.DataSource = dt
    End Sub

    Private Sub treeTrabajador_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles treeTrabajador.AfterSelect
        Dim intCap As Integer, intId As Integer, intNivel As Integer
        With treeTrabajador
            intCap = .SelectedNode.Name
            intNivel = .SelectedNode.Level
            intId = ObtieneItem(lista, .SelectedNode.Tag)
            Me.ListarUsuarioArea(intCap, intNivel, intId)
            Me.ConfigurardgvTrabajador(intNivel)
        End With
    End Sub

    Sub GrabarAreaTrabajador(ByVal codigo As String, ByVal area As Integer)
        Dim obj As New Cls_HoraExtra_LN
        obj.GrabarAreaTrabajador(codigo, area)
    End Sub

    Private Sub dgvTrabajador_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvTrabajador.DoubleClick
        If Me.treeTrabajador.SelectedNode.Level = 3 Or Me.treeTrabajador.SelectedNode.Level = 0 Then
            If Me.dgvTrabajador.Rows.Count > 0 Then
                Dim frm As New frmAreaTrabajador
                If Me.treeTrabajador.SelectedNode.Level = 3 Then
                    frm.Abuelo = treeTrabajador.SelectedNode.Parent.Parent.Name
                    frm.Padre = treeTrabajador.SelectedNode.Parent.Name
                    frm.Hijo = treeTrabajador.SelectedNode.Name
                End If
                frm.ShowDialog()
                If frm.DialogResult = Windows.Forms.DialogResult.OK Then
                    GrabarAreaTrabajador(Me.dgvTrabajador.CurrentRow.Cells("codigo").Value, frm.cboNivel3.SelectedValue)
                    Dim intCap As Integer, intNivel As Integer, intId As Integer
                    intCap = treeTrabajador.SelectedNode.Name
                    intNivel = treeTrabajador.SelectedNode.Level
                    intId = ObtieneItem(lista, treeTrabajador.SelectedNode.Tag)
                    Me.ListarUsuarioArea(intCap, intNivel, intId)
                    Me.ConfigurardgvTrabajador(intNivel)
                End If
            End If
        End If
    End Sub

    Private Sub btnConsultarHe2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarHe2.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim obj As New Cls_HoraExtra_LN
            Dim strCodigo As String = IIf(Me.cboTrabajadorHE2.SelectedValue = 0, "", Me.cboTrabajadorHE2.SelectedValue)
            Dim dt As DataTable = obj.ListarHHEESolicitud(dtpInicioHE2.Value.ToShortDateString, Me.dtpFinHE2.Value.ToShortDateString, Me.cboAreaHE2.SelectedValue, strCodigo, dtoUSUARIOS.IdLogin, intPerfil, Me.cboEstadoHe2.SelectedIndex)
            Me.dgvHe2.DataSource = dt
            TotalHe2(dt)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboAreaHE2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAreaHE2.SelectedIndexChanged
        Me.ListarTrabajadorSolicitud(Me.cboAreaHE2.SelectedValue, Me.dtpInicioHE2.Value.ToShortDateString, Me.dtpFinHE2.Value.ToShortDateString, Me.cboEstadoHe2.SelectedIndex)
    End Sub

    Sub TotalHe2(ByVal dt As DataTable)
        Dim dblHe As Double, dblPendiente As Double, dblAutorizado As Double, dblAprobado As Double, dblNoautorizado As Double, dblDesaprobado As Double

        dblHe = SumaGrid2(Me.dgvHe2, "he2")
        dblPendiente = IIf(IsDBNull(dt.Compute("sum(he2)", "id_estado=1")), 0, dt.Compute("sum(he2)", "id_estado=1"))
        dblAutorizado = IIf(IsDBNull(dt.Compute("sum(he2)", "id_estado=2")), 0, dt.Compute("sum(he2)", "id_estado=2"))
        dblAprobado = IIf(IsDBNull(dt.Compute("sum(he2)", "id_estado=3")), 0, dt.Compute("sum(he2)", "id_estado=3"))
        dblNoautorizado = IIf(IsDBNull(dt.Compute("sum(he2)", "id_estado=4")), 0, dt.Compute("sum(he2)", "id_estado=4"))
        dblDesaprobado = IIf(IsDBNull(dt.Compute("sum(he2)", "id_estado=5")), 0, dt.Compute("sum(he2)", "id_estado=5"))

        Me.lblHeTotal.Text = Format(dblHe, "###,###,###0.00")
        Me.lblPendiente.Text = Format(dblPendiente, "###,###,###0.00")
        Me.lblAutorizado.Text = Format(dblAutorizado, "###,###,###0.00")
        Me.lblAprobado.Text = Format(dblAprobado, "###,###,###0.00")
        Me.lblNoautorizado.Text = Format(dblNoautorizado, "###,###,###0.00")
        Me.lblDesaprobado.Text = Format(dblDesaprobado, "###,###,###0.00")
    End Sub

    Private Sub chkObrero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkObrero.CheckedChanged
        Try
            Dim intObrero As Integer, intFila As Integer
            Dim strMensaje As String
            Dim strTrabajador As String, strCodigo As String
            Dim dlgRespuesta As DialogResult

            intObrero = IIf(Me.chkObrero.Checked, 1, 0)
            strCodigo = Me.dgvListaMantenimiento.CurrentRow.Cells("codigo").Value
            strTrabajador = Me.dgvListaMantenimiento.CurrentRow.Cells("nombres").Value
            strMensaje = "¿Está seguro de que el trabajador " & strTrabajador & IIf(intObrero = 0, " es Empleado", " es Obrero") & "?"
            dlgRespuesta = MessageBox.Show(strMensaje, "Mantenimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                intFila = Me.dgvListaMantenimiento.CurrentCell.RowIndex
                Dim obj As New Cls_HoraExtra_LN
                obj.GrabarObrero(strCodigo, intObrero)
                btnConsultarMantenimiento_Click(Nothing, Nothing)
                Me.dgvListaMantenimiento.CurrentCell = Me.dgvListaMantenimiento(1, intFila)
            Else
                intObrero = IIf(intObrero = 0, 1, 0)
                RemoveHandler Me.chkObrero.CheckedChanged, AddressOf Me.chkObrero_CheckedChanged
                Me.chkObrero.Checked = intObrero
                AddHandler Me.chkObrero.CheckedChanged, AddressOf Me.chkObrero_CheckedChanged
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub EditarSolicitudCompensacion()
        blnEditarSolicitudCompensacion = True

        Dim dblEfectivo As Double = 0, dblDescanso As Double = 0, dblEfectivo2 As Double = 0, dblDescanso2 As Double = 0
        dblEfectivo = Cls_HoraExtra_LN.ValorHE(Me.dgvListaSolicitud2.CurrentRow.Cells("efectivo").Value)
        dblDescanso = Cls_HoraExtra_LN.ValorHE(Me.dgvListaSolicitud2.CurrentRow.Cells("descanso").Value)

        Dim obj As New Cls_HoraExtra_LN
        Dim dt As DataTable = obj.ListarHECompensadaDet(Me.dgvListaSolicitud2.CurrentRow.Cells("id").Value, Me.dgvListaSolicitud2.CurrentRow.Cells("id_det").Value)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If row("tipo") = 1 Then
                    dblEfectivo2 += row("horas")
                End If
                If row("tipo") = 2 Then
                    dblDescanso2 += row("horas")
                End If
            Next
        End If
        dblEfectivo = IIf(dblEfectivo - dblEfectivo2 < 0, dblEfectivo, dblEfectivo - dblEfectivo2)
        dblDescanso = IIf(dblDescanso - dblDescanso2 < 0, dblDescanso, dblDescanso - dblDescanso2)
        Me.lblEfectivoSolicitud2.Text = Cls_HoraExtra_LN.ValorCadena(dblEfectivo)
        Me.lblDescansoSolicitud2.Text = Cls_HoraExtra_LN.ValorCadena(dblDescanso)

        'Me.lblEfectivoSolicitud2.Text = Me.dgvListaSolicitud2.CurrentRow.Cells("efectivo").Value
        'Me.lblDescansoSolicitud2.Text = Me.dgvListaSolicitud2.CurrentRow.Cells("descanso").Value
        'Me.lblTotalSolicitud2.Text = Me.dgvListaSolicitud2.CurrentRow.Cells("saldo").Value

        Me.lblTotalSolicitud2.Text = Cls_HoraExtra_LN.ValorCadena(dblEfectivo + dblDescanso)
        Me.txtObservacionesSolicitud2.Text = Me.dgvListaSolicitud2.CurrentRow.Cells("observaciones").Value.ToString.Trim
        Me.cboHorasSolicitud2.Items.Clear()
        Me.cboHorasSolicitud2.Items.Add("(SELECCIONE)")
        Me.cboHorasSolicitud2.SelectedIndex = 0

        Me.ListarSolicitudCompensado(dgvListaSolicitud2.CurrentRow.Cells("id").Value, dgvListaSolicitud2.CurrentRow.Cells("id_det").Value, Me.cboEstadoSolicitud2.SelectedIndex)

        Me.tabSolicitar2.SelectedIndex = 1
    End Sub

    Sub EstadoSolicitud(ByVal opcion As Integer)
        dgvDetalleSolicitud2.Enabled = True
        cboEstadoSolicitud2.Enabled = True
        If opcion = 0 Then
            Me.btnModificarSolicitud2.Enabled = False
            Me.btnGrabarSolicitud2.Enabled = False
            Me.btnCancelarSolicitud2.Enabled = False
            Me.btnAnularSolicitud2.Enabled = False
            Me.cboTipoCompensacionSolicitud2.Enabled = False
            Me.cboHorasSolicitud2.Enabled = False
            Me.txtObservacionesSolicitud2.Enabled = False
            'Me.txtObservacionesSolicitud2.Text = ""
            Me.cboTipoCompensacionSolicitud2.SelectedIndex = 0
            If Me.dgvListaSolicitud2.Rows.Count > 0 Then
                Me.btnNuevoSolicitud2.Enabled = Me.dgvListaSolicitud2.CurrentRow.Cells("idestado").Value = 1
                Me.cboHorasSolicitud2.SelectedIndex = IIf(Me.cboHorasSolicitud2.Items.Count > 0, 0, -1)
            Else
                Me.btnNuevoSolicitud2.Enabled = True
                Me.btnNuevoSolicitud2.Enabled = False
                cboEstadoSolicitud2.Enabled = False
                Me.cboHorasSolicitud2.SelectedIndex = -1
            End If
        ElseIf opcion = 1 Then
            Me.btnNuevoSolicitud2.Enabled = False
            Me.btnModificarSolicitud2.Enabled = False
            Me.btnGrabarSolicitud2.Enabled = True
            Me.btnCancelarSolicitud2.Enabled = True
            Me.btnAnularSolicitud2.Enabled = False
            Me.cboTipoCompensacionSolicitud2.Enabled = True
            Me.cboHorasSolicitud2.Enabled = True
            Me.txtObservacionesSolicitud2.Enabled = True
            Me.txtObservacionesSolicitud2.Text = ""
            Me.cboTipoCompensacionSolicitud2.SelectedIndex = 0
            Me.cboHorasSolicitud2.SelectedIndex = 0
            dgvDetalleSolicitud2.Enabled = False
        ElseIf opcion = 2 Then
            Me.btnNuevoSolicitud2.Enabled = False
            Me.btnModificarSolicitud2.Enabled = False
            Me.btnGrabarSolicitud2.Enabled = True
            Me.btnCancelarSolicitud2.Enabled = True
            Me.btnAnularSolicitud2.Enabled = False
            Me.cboTipoCompensacionSolicitud2.Enabled = True
            Me.cboHorasSolicitud2.Enabled = True
            Me.txtObservacionesSolicitud2.Enabled = True
            dgvDetalleSolicitud2.Enabled = False
            'Me.txtObservacionesSolicitud2.Text = ""
        ElseIf opcion = 3 Then
            Me.btnNuevoSolicitud2.Enabled = True
            Me.btnModificarSolicitud2.Enabled = True
            Me.btnGrabarSolicitud2.Enabled = False
            Me.btnCancelarSolicitud2.Enabled = False
            Me.btnAnularSolicitud2.Enabled = True
            Me.cboTipoCompensacionSolicitud2.Enabled = False
            Me.cboHorasSolicitud2.Enabled = False
            Me.txtObservacionesSolicitud2.Enabled = False
            'Me.txtObservacionesSolicitud2.Text = ""
        ElseIf opcion = 4 Then
            Me.btnNuevoSolicitud2.Enabled = True
            If Me.dgvDetalleSolicitud2.Rows.Count > 0 Then
                MostrarSolicitudCompensado(Me.dgvDetalleSolicitud2.CurrentCell.RowIndex)
                Me.btnModificarSolicitud2.Enabled = Me.dgvDetalleSolicitud2.CurrentRow.Cells("idestado").Value = 1
                Me.btnAnularSolicitud2.Enabled = Me.dgvDetalleSolicitud2.CurrentRow.Cells("idestado").Value = 1
            Else
                Me.btnModificarSolicitud2.Enabled = False
                Me.btnAnularSolicitud2.Enabled = False
                cboTipoCompensacionSolicitud2.SelectedIndex = 0
                cboHorasSolicitud2.SelectedIndex = 0
                Me.txtObservacionesSolicitud2.Text = ""
            End If
            Me.btnGrabarSolicitud2.Enabled = False
            Me.btnCancelarSolicitud2.Enabled = False
            Me.cboTipoCompensacionSolicitud2.Enabled = False
            Me.cboHorasSolicitud2.Enabled = False
            Me.txtObservacionesSolicitud2.Enabled = False
        Else
            Me.btnNuevoSolicitud2.Enabled = True
            If Me.dgvDetalleSolicitud2.Rows.Count > 0 Then
                MostrarSolicitudCompensado(Me.dgvDetalleSolicitud2.CurrentCell.RowIndex)
                Me.btnModificarSolicitud2.Enabled = Me.dgvDetalleSolicitud2.CurrentRow.Cells("idestado").Value = 1
                Me.btnAnularSolicitud2.Enabled = Me.dgvDetalleSolicitud2.CurrentRow.Cells("idestado").Value = 1
            Else
                Me.btnModificarSolicitud2.Enabled = False
                Me.btnAnularSolicitud2.Enabled = False
            End If

            Me.btnGrabarSolicitud2.Enabled = False
            Me.btnCancelarSolicitud2.Enabled = False
            Me.cboTipoCompensacionSolicitud2.Enabled = False
            Me.cboHorasSolicitud2.Enabled = False
            Me.txtObservacionesSolicitud2.Enabled = False
            Me.txtObservacionesSolicitud2.Text = ""
        End If
    End Sub

    Private Sub tabSolicitar2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabSolicitar2.SelectedIndexChanged
        If Me.tabSolicitar2.SelectedTab Is Me.tabSolicitar2.TabPages("tabListaSolicitud2") Then
            Me.tsbEditar.Enabled = Me.dgvListaSolicitud2.Rows.Count > 0
        Else
            EstadoSolicitud(0)
            Me.tsbEditar.Enabled = False
            blnEditarSolicitudCompensacion = False
            If blnEditarSolicitudCompensacion = False Then
                If Me.dgvListaSolicitud2.Rows.Count > 0 Then
                    EditarSolicitudCompensacion()
                End If
            End If
        End If
    End Sub

    Private Sub btnConsultarListaSolicitud2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarListaSolicitud2.Click
        Dim obj As New Cls_HoraExtra_LN
        Dim dt As DataTable = obj.ListarHECompensadaDet(Me.dtpInicioListaSolicitud2.Value.ToShortDateString, Me.dtpFinListaSolicitud2.Value.ToShortDateString, dtoUSUARIOS.IdLogin, Me.cboEstadoListaSolicitud2.SelectedIndex)
        Me.dgvListaSolicitud2.DataSource = dt
        Me.tsbEditar.Enabled = Me.dgvListaSolicitud2.Rows.Count > 0
    End Sub

    Private Sub dgvListaSolicitud2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvListaSolicitud2.DoubleClick
        If Me.dgvListaSolicitud2.Rows.Count > 0 Then
            EditarSolicitudCompensacion()
        End If
    End Sub

    Private Sub btnGrabarSolicitud2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabarSolicitud2.Click
        If Me.cboTipoCompensacionSolicitud2.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione Tipo de Compensación", "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboTipoCompensacionSolicitud2.DroppedDown = True
            Me.cboTipoCompensacionSolicitud2.Focus()
            Return
        End If

        If Me.cboHorasSolicitud2.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione Horas a Compensar", "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboHorasSolicitud2.DroppedDown = True
            Me.cboHorasSolicitud2.Focus()
            Return
        End If

        If Me.cboTipoCompensacionSolicitud2.SelectedIndex = 1 Then
            If Me.cboHorasSolicitud2.Text = Me.lblEfectivoSolicitud2.Text Then
                MessageBox.Show("Las Horas a compensar no pueden ser igual a las horas en efectivo", "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboHorasSolicitud2.Focus()
                Me.cboHorasSolicitud2.DroppedDown = True
                Return
            End If
        End If

        If Me.cboTipoCompensacionSolicitud2.SelectedIndex = 2 Then
            If Me.cboHorasSolicitud2.Text = Me.lblDescansoSolicitud2.Text Then
                MessageBox.Show("Las Horas a compensar no pueden ser igual a las horas de descanso", "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.cboHorasSolicitud2.Focus()
                Me.cboHorasSolicitud2.DroppedDown = True
                Return
            End If
        End If

        If Me.txtObservacionesSolicitud2.Text.Length > 0 Then
            If Me.txtObservacionesSolicitud2.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese la Observación", "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtObservacionesSolicitud2.Focus()
                Return
            End If
        End If

        GrabarSolicitudCompensada()
        Me.cboEstadoSolicitud2_SelectedIndexChanged(Nothing, Nothing)
        EstadoSolicitud(3)
        intOperacion = 0
    End Sub

    Sub GrabarSolicitudCompensada()
        Try
            Dim obj As New Cls_HoraExtra_LN
            With Me.dgvListaSolicitud2.CurrentRow
                Dim intId As Integer, intId2 As Integer, intIDDet2 As Integer
                If intOperacion = 2 Then
                    intId = Me.dgvDetalleSolicitud2.CurrentRow.Cells("id").Value
                End If
                intId2 = .Cells("id").Value
                intIDDet2 = .Cells("id_det").Value
                obj.GrabarSolicitudCompensado(intId, intId2, intIDDet2, Me.cboHorasSolicitud2.Text, Me.cboTipoCompensacionSolicitud2.SelectedIndex, _
                                              dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol, Me.txtObservacionesSolicitud2.Text.Trim)
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Sub ListarSolicitudCompensado(ByVal id As Integer, ByVal id_det As Integer, ByVal estado As Integer)
        Dim obj As New Cls_HoraExtra_LN
        Dim dt As DataTable = obj.ListarSolicitudCompensado(id, id_det, estado)
        Me.dgvDetalleSolicitud2.DataSource = dt
    End Sub

    Sub MostrarSolicitudCompensado(ByVal fila As Integer)
        With Me.dgvDetalleSolicitud2
            Me.cboTipoCompensacionSolicitud2.SelectedIndex = .Rows(fila).Cells("idtipo_compensacion").Value

            Dim strHoras As String = .Rows(fila).Cells("horas").Value
            Dim intHoras As Integer, intMinutos As Integer
            intHoras = Val(strHoras.Substring(0, 2))
            intMinutos = Val(strHoras.Substring(3, 2))
            Me.cboHorasSolicitud2.Items.Clear()
            Me.cboHorasSolicitud2.Items.Add("(SELECCIONE)")
            For i As Integer = 1 To intHoras
                Me.cboHorasSolicitud2.Items.Add(Format(i, "00") + ":00")
                If i < intHoras Then
                    Me.cboHorasSolicitud2.Items.Add(Format(i, "00") + ":30")
                End If
            Next
            If intMinutos > 0 Then
                Me.cboHorasSolicitud2.Items.Add(Format(intHoras, "00") + ":30")
            End If
            Me.cboHorasSolicitud2.Text = strHoras
            'Me.cboHorasSolicitud2.Text = .Rows(fila).Cells("horas").Value

            Me.txtObservacionesSolicitud2.Text = .Rows(fila).Cells("observaciones").Value
        End With
    End Sub

    Private Sub dgvDetalleSolicitud2_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalleSolicitud2.RowEnter
        MostrarSolicitudCompensado(e.RowIndex)
        Me.btnModificarSolicitud2.Enabled = Me.dgvDetalleSolicitud2.Rows(e.RowIndex).Cells("idestado").Value = 1
        Me.btnAnularSolicitud2.Enabled = Me.dgvDetalleSolicitud2.Rows(e.RowIndex).Cells("idestado").Value = 1
    End Sub

    Private Sub cboEstadoSolicitud2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstadoSolicitud2.SelectedIndexChanged
        If dgvListaSolicitud2.Rows.Count = 0 Then Return
        Me.ListarSolicitudCompensado(dgvListaSolicitud2.CurrentRow.Cells("id").Value, dgvListaSolicitud2.CurrentRow.Cells("id_det").Value, Me.cboEstadoSolicitud2.SelectedIndex)
        If Me.dgvDetalleSolicitud2.Rows.Count = 0 Then
            EstadoSolicitud(0)
        End If
    End Sub

    Private Sub btnNuevoSolicitud2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoSolicitud2.Click
        Dim strHoras As String = Me.lblTotalSolicitud2.Text
        Dim intHoras As Integer, intMinutos As Integer
        intHoras = Val(strHoras.Substring(0, 2))
        intMinutos = Val(strHoras.Substring(3, 2))
        Me.cboHorasSolicitud2.Items.Clear()
        Me.cboHorasSolicitud2.Items.Add("(SELECCIONE)")
        For i As Integer = 1 To intHoras
            Me.cboHorasSolicitud2.Items.Add(Format(i, "00") + ":00")
            If i < intHoras Then
                Me.cboHorasSolicitud2.Items.Add(Format(i, "00") + ":30")
            End If
        Next
        If intMinutos > 0 Then
            Me.cboHorasSolicitud2.Items.Add(Format(intHoras, "00") + ":30")
        End If
        Me.cboHorasSolicitud2.Text = strHoras

        EstadoSolicitud(1)
        Me.cboTipoCompensacionSolicitud2.Focus()
        Me.cboTipoCompensacionSolicitud2.DroppedDown = True
        intOperacion = 1
    End Sub

    Private Sub btnModificarSolicitud2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarSolicitud2.Click
        EstadoSolicitud(2)
        Me.cboTipoCompensacionSolicitud2.Focus()
        Me.cboTipoCompensacionSolicitud2.DroppedDown = True
        intOperacion = 2
    End Sub

    Private Sub btnCancelarSolicitud2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarSolicitud2.Click
        EstadoSolicitud(4)
        Me.btnNuevoSolicitud2.Focus()
        intOperacion = 0
    End Sub

    Sub AnularSolicitudCompensado(ByVal id As Integer)
        Dim obj As New Cls_HoraExtra_LN
        obj.AnularSolicitudCompensado(id, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
    End Sub

    Private Sub btnAnularSolicitud2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnularSolicitud2.Click
        Dim dlgRespuesta As DialogResult
        dlgRespuesta = MessageBox.Show("¿Está seguro de anular la solicitud?", "Anular", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
            AnularSolicitudCompensado(Me.dgvDetalleSolicitud2.CurrentRow.Cells("id").Value)
            Me.cboEstadoSolicitud2_SelectedIndexChanged(Nothing, Nothing)
            EstadoSolicitud(5)
            intOperacion = 0
        End If
    End Sub

    Sub EditarAprobacionSolicitud()
        blnEditarAprobacionSolicitud = True
        With Me.dgvListaAprobacion
            Me.lblFechaAprobacion2.Text = .CurrentRow.Cells("fecha_solicitud").Value
            Me.lblTrabajadorAprobacion2.Text = .CurrentRow.Cells("codigo").Value & " " & .CurrentRow.Cells("nombres").Value
            Me.lblAreaAprobacion2.Text = .CurrentRow.Cells("area").Value
            Me.lblCentroCostoAprobacion2.Text = .CurrentRow.Cells("centro_costo").Value
            Me.lblCargoAprobacion2.Text = .CurrentRow.Cells("cargo").Value
            Me.lblObservaciones2.Text = .CurrentRow.Cells("observaciones").Value

            Me.lblHorasAprobacion2.Text = .CurrentRow.Cells("horas_total").Value
            Me.lblHorasCompensadasAprobacion2.Text = .CurrentRow.Cells("horas_compensadas").Value
            Me.lblHorasporCompensarAprobacion2.Text = .CurrentRow.Cells("saldo").Value
            Me.lblEfectivoAprobacion2.Text = .CurrentRow.Cells("efectivo").Value
            Me.lblDescansoAprobacion2.Text = .CurrentRow.Cells("descanso").Value
            Me.lblTipoCompensacionAprobacion2.Text = .CurrentRow.Cells("tipo_compensacion").Value
            Me.lblHorasCompensarAprobacion2.Text = .CurrentRow.Cells("horas").Value

        End With
        Me.pnlAprobacionSolicitud.Enabled = Me.dgvListaAprobacion.CurrentRow.Cells("id_estado").Value = 1
        Me.tabAprobacionDetalle.SelectedIndex = 1
    End Sub

    Private Sub txtObservacionesSolicitud2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtObservacionesSolicitud2.Enter
        Me.txtObservacionesSolicitud2.SelectAll()
    End Sub

    Private Sub txtObservacionesSolicitud2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacionesSolicitud2.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            Me.btnGrabarSolicitud2.Focus()
        End If
    End Sub

    Private Sub txtObservacionesSolicitud2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacionesSolicitud2.KeyUp
        If e.Modifiers And e.Control Then
            If e.KeyCode = 13 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnAceptarAprobacionSolicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarAprobacionSolicitud.Click
        If Me.rbtNoAprobacionSolicitud.Checked AndAlso Me.txtNoAprobacionSolicitud.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese el Motivo", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNoAprobacionSolicitud.Text = ""
            Me.txtNoAprobacionSolicitud.Focus()
            Return
        End If

        AprobarSolicitud()
    End Sub

    Sub AprobarSolicitud()
        Try
            If Me.rbtSiAprobacionSolicitud.Checked Then
                Dim strMensaje As String = "¿Está Seguro de Aprobar la Solicitud?"
                Dim intRespuesta As DialogResult = MessageBox.Show(strMensaje, "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If intRespuesta = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Me.AprobarSolicitudCompensado(2)
                    MessageBox.Show("Solicitud Aprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.btnConsultarListaAprobacion_Click(Nothing, Nothing)
                    tabAprobacionDetalle.SelectedTab = tabAprobacionDetalle.TabPages("tabListaAprobacion")
                    Cursor = Cursors.Default
                End If
            Else
                If MessageBox.Show("¿Está Seguro de desaprobar la Solicitud?", "Aprobar Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Me.AprobarSolicitudCompensado(3)
                    MessageBox.Show("Solicitud Desaprobada", "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.btnConsultarListaAprobacion_Click(Nothing, Nothing)
                    tabAprobacionDetalle.SelectedTab = tabAprobacionDetalle.TabPages("tabListaAprobacion")
                    Cursor = Cursors.Default
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Aprobar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub AprobarSolicitudCompensado(ByVal estado As Integer)
        Dim obj As New Cls_HoraExtra_LN

        Dim intID As Integer = Me.dgvListaAprobacion.CurrentRow.Cells("id").Value
        Dim intID_2 As Integer = Me.dgvListaAprobacion.CurrentRow.Cells("id_2").Value
        Dim intID_2_Det As Integer = Me.dgvListaAprobacion.CurrentRow.Cells("id_2_det").Value
        Dim strHoras As String = Me.dgvListaAprobacion.CurrentRow.Cells("horas").Value
        Dim intTipoCompensacion As Integer = Me.dgvListaAprobacion.CurrentRow.Cells("idtipo_compensacion").Value
        Dim strHorasTotal As String = lblHorasporCompensarAprobacion2.Text
        Dim strObservacion As String = IIf(estado = 2, "", Me.txtNoAprobacionSolicitud.Text.Trim)

        obj.AprobarSolicitudCompensado(intID, estado, strObservacion, intID_2, intID_2_Det, strHoras, intTipoCompensacion, strHorasTotal, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
    End Sub

    Private Sub rbtSiAprobacionSolicitud_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSiAprobacionSolicitud.CheckedChanged
        Me.txtNoAprobacionSolicitud.Text = ""
        Me.txtNoAprobacionSolicitud.Enabled = False
        Me.btnAceptarAprobacionSolicitud.Focus()
    End Sub

    Private Sub rbtNoAprobacionSolicitud_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNoAprobacionSolicitud.CheckedChanged
        Me.txtNoAprobacionSolicitud.Text = ""
        Me.txtNoAprobacionSolicitud.Enabled = True
        Me.txtNoAprobacionSolicitud.Focus()
    End Sub

    Private Sub dgvDetCompensacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetCompensacion.DoubleClick
        With Me.dgvDetCompensacion
            If .Rows.Count > 0 Then
                Dim intId As Integer = dgvListaCompensacion.CurrentRow.Cells("id").Value
                Dim intIdDet As Integer = dgvDetalleCompensacion.CurrentRow.Cells("id").Value
                Dim intIdDet2 As Integer = .CurrentRow.Cells("id").Value
                Dim strHora As String = .CurrentRow.Cells("horas").Value
                Dim intEstado As Integer = .CurrentRow.Cells("id_estado").Value
                If intId > 0 AndAlso intEstado < 3 Then
                    Dim strMensaje As String = "¿Está seguro de Anular la Compensación?"
                    Dim dlgRespuesta As DialogResult
                    dlgRespuesta = MessageBox.Show(strMensaje, "Anular Compensación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If dlgRespuesta = Windows.Forms.DialogResult.Yes Then
                        AnularCompensacion(intId, intIdDet, intIdDet2, strHora)
                        btnConsultarCompensacionDetalle_Click(Nothing, Nothing)
                    End If
                End If
            End If
        End With
    End Sub

    Sub AnularCompensacion(ByVal id As Integer, ByVal id_det As Integer, ByVal id_det2 As Integer, ByVal hora As String)
        Dim obj As New Cls_HoraExtra_LN
        obj.AnularCompensacion(id, id_det, id_det2, hora, dtoUSUARIOS.IdLogin, dtoUSUARIOS.IP, dtoUSUARIOS.IdRol)
    End Sub

    Private Sub dgvListaAprobacion_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaAprobacion.RowEnter
        Me.tsbAnular.Enabled = False
        If Me.rbtSolicitud.Checked Then
            If e.RowIndex >= 0 Then
                If Me.dgvListaAprobacion.Rows(e.RowIndex).Cells("id_estado").Value = 2 Then
                    Me.tsbAnular.Enabled = True
                End If
            End If
        End If
    End Sub

    Sub AnularAprobacion(ByVal frm As frmAnularAprobacion)
        Dim obj As New Cls_HoraExtra_LN
        Dim intOpcion As Integer
        Dim intPerfil As Integer

        intOpcion = IIf(frm.rbtAutorizacion.Checked, 1, 2)
        If intOpcion = 1 Then
            intPerfil = 2
        Else
            intPerfil = 0
        End If

        AnularSolicitud(Me.dgvListaAprobacion.CurrentRow.Cells("id").Value, intPerfil, Me.dgvListaAprobacion.CurrentRow.Cells("id_estado").Value, 1)
        Me.btnConsultarListaAprobacion_Click(Nothing, Nothing)
    End Sub

    Private Sub dgvDetalleCompensacion_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalleCompensacion.CellContentClick

    End Sub
End Class