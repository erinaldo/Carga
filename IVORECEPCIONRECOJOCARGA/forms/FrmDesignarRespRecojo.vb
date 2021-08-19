Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports System
Imports System.Drawing
Imports System.IO
Imports ADOSERVERLib
Public Class FrmDesignarRespRecojo
    Inherits FrmPlantillasolrecojocarga
    Dim ClaseSolAsignamovil As New dtoSolAsignamovil
    Dim ClaseSolcomun As New dtosolicitudcomun    
#Region " DECLARACION VARIABLES "
    'Declarando el usuario 
    Dim usuario As Integer
    'Declaracion de Recordset
    Dim rstAgencia, rstSolCarga, rstunitransporte, rstruta As ADODB.Recordset
    'Declaracion de Data Adapters
    Dim dr4 As New OleDb.OleDbDataAdapter
    'Private DataAdapterGenerics As New OleDbDataAdapter
    'Declaracion de DataTables
    Dim dtAgencia, dtSolCarga, dtunitransporte, dt_dvgruta, dtruta As New System.Data.DataTable
    Dim dtRutasClon As New DataTable
    ' Declarando Data View 
    Dim dvAgencia, dvSolCarga, dvunitransporte, dv_dvgruta, dvruta As New DataView
    'Declarando Data row View 
    Dim drvAgencia, drvunitransporte, drvruta, drv_dgvruta As DataRowView
    ' Declarando variables de uso general 
    Dim filtro As String = ""
    Dim idagencia As Integer
    Dim fec_solicitud As Date
    Dim fila As Integer
    'Variable de los campos definidos por campos DataGridViewTextBoxColumn
    Dim tbNrosolicitud, tbidagencia, tbidcliente, tbidfecharecojo, tbidpersona As New DataGridViewTextBoxColumn
    Dim tbrazonsocial, tbidirecosignado, tbdireccion, tbhoraini, tbhorafin, tbnropaquetes As New DataGridViewTextBoxColumn
    Dim tbpesokg, tbvolumen, tbobservacion As New DataGridViewTextBoxColumn
    Dim tbidestadorecogo As New DataGridViewTextBoxColumn
    ' , ColCalidad, ColCant, ColEspe, ColAncho, ColLargo, ColNroLot, ColTotal, ColDscAnc, ColDscLar As TextBox
    ' Declare a variable of type BindingManagerBase named bindingManager.
    Dim bindingManager As BindingManagerBase
    'probando la variable 
    Dim drg As DataRowView    
#End Region
    Private Sub FrmDesignarRespRecojo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Se debe ocultar las demas con las que no se trabajan 
            MenuTab.Items(1).Enabled = False
            MenuTab.Items(2).Enabled = False
            MenuTab.Items(3).Enabled = False
            MenuTab.Items(4).Enabled = False
            MenuTab.Items(1).Visible = False
            MenuTab.Items(2).Visible = False
            MenuTab.Items(3).Visible = False
            MenuTab.Items(4).Visible = False
            'Menu del datawievgrid 
            ToolStripMenuItem2.Visible = False
            ToolStripMenuItem2.Enabled = False
            'No tiene que aparecer el boton nuevo 
            NuevoToolStripMenuItem1.Visible = False

            'Desactivando Cancelar
            CancelarToolStripMenuItem.Enabled = False
            CancelarToolStripMenuItem.Visible = False
            'Configura opcion de busqueda 
            TxtBusca.Visible = False
            '
            MenuTab.Items(0).Text = "Asigna móvil"
            ' Creando la fecha por defecto de la pc
            Dim today As DateTime = System.DateTime.Today
            ShadowLabel1.Text = "Asignando Móvil -  Recojo de Carga"
            ' Recuperando el combo a la agencia  
            usuario = dtoUSUARIOS.IdLogin
            ' Recupera el combo de agencias, usando una clase   
            rstAgencia = ClaseSolcomun.get_combo()
            dr4.Fill(dtAgencia, rstAgencia)
            dvAgencia = dtAgencia.DefaultView
            dvAgencia.AllowNew = False
            'recuperando la ruta 
            rstruta = rstAgencia.NextRecordset
            dr4.Fill(dtruta, rstruta)
            'Recupera la unidad de transporte 
            rstunitransporte = rstAgencia.NextRecordset
            dr4.Fill(dtunitransporte, rstunitransporte)
            dvunitransporte = dtunitransporte.DefaultView
            dvunitransporte.AllowNew = False

            '
            ' Ojo que falta poner còdigo cuando sale un error - Omendoza 
            '

            ' Filtro debe hacer con datawiev o datatable (Propio de net) 
            filtro = "idusuario_personal = " & Trim(usuario)
            dvAgencia.RowFilter = filtro
            ' Recupera agencia  
            'LlenaComboE(rstAgencia, dtAgencia, dvAgencia, CmbAgencia, "nombre_agencia")
            dvAgencia = CargarCombo(CmbAgencia, dtAgencia, "TIPO_DIRECCION", "IDTIPO_DIRECCION", 3)
            ' Recupera Ruta
            'LlenaComboE(rstruta, dtruta, dvruta, cmbruta, "nombre_ruta_entrega_recojo")
            dvruta = CargarCombo(cmbruta, dtruta, "nombre_ruta_entrega_recojo", "idruta_entrega_recojo", 0)
            ' Ocultando label del padre  
            LabeloSCAR.Visible = False
            'Recupera la grilla en función de la agencia y la fecha 
            ' Configurando la fecha 
            'DataPickerMasked1.Text = today.ToString("dd/MM/yyyy") --> Temporalmente desea 
            DateTimePicker1.Value = today.ToString("dd/MM/yyyy")
            'Recuperando valor del combo, y lo coloca en idagencia  
            recupera_agencia()
            '

            Call GrillaMante()
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Asignando él valor ")
        End Try
    End Sub
    Sub GrillaMante()
        Dim gmdtruta As New System.Data.DataTable
        Dim gmdvruta As New DataView
        'Copiando la ruta 
        gmdvruta = dtRutasClon.DefaultView
        'Recupera las rutas disponibles 
        gmdvruta.RowFilter = "idruta_entrega_recojo <> 0"
        dvruta.RowFilter = ""
        'Configurando la grilla 
        With DataGridViewPlt
            .AutoGenerateColumns = False 'Las filas no se generen automaticamente de la bd
            ' Creando el data source 
            .DataSource = dvSolCarga
            .BackColor = SystemColors.Info
            .BackgroundColor = SystemColors.Info
            .RowHeadersVisible = False
            .BorderStyle = BorderStyle.Fixed3D
            .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
            '.Visible = False
            ' Pintando la linea 
            '.CurrentRow.DefaultCellStyle.BackColor = Color.White
            '.CurrentRow.DefaultCellStyle.ForeColor = Color.Black
            'Ancho del data grid
            .Width = 705
            ' aplicando las coordenadas respectivas 
            .Location = New Point(.Location.X, 18)
            .Location = New Point(.Location.Y, 60)
            '.GridLineStyle = DataGridLineStyle.Solid
            '.ParentRowsVisible = False
            '.AllowNavigation = True
            '.ReadOnly = False
            '.AllowSorting = True
        End With
        With tbNrosolicitud  '0
            .DataPropertyName = "idsolicitud_recojo_carga"
            .HeaderText = "Nº solicitud"
            .DefaultCellStyle.BackColor = SystemColors.Info
            .Width = 80
            .ReadOnly = True
            .Frozen = True
        End With  '1
        Dim Colaprobado As New DataGridViewCheckBoxColumn
        With Colaprobado
            .HeaderText = "¿Aprobado?"
            .Name = "APROBADO"
            .DataPropertyName = "APROBADO"
            .Width = 62
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            .Frozen = True
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        End With
        Dim tbunidadtransporte As New DataGridViewComboBoxColumn
        With tbunidadtransporte  '2
            .DataPropertyName = "idunidad_transporte"
            .HeaderText = "Móvil"
            .DataSource = dvunitransporte
            .DisplayMember = "nro_unidad_transporte"
            .ValueMember = "idunidad_transporte"
            .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        End With

        Dim tbrutaentrega As New DataGridViewComboBoxColumn
        With tbrutaentrega '3            
            .DataPropertyName = "idruta_entrega_recojo"
            .HeaderText = "Ruta"
            .DataSource = gmdvruta
            .DisplayMember = "nombre_ruta_entrega_recojo"
            .ValueMember = "idruta_entrega_recojo"
            .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        End With

        With tbidpersona '4
            .DataPropertyName = "idpersona"
            .HeaderText = "Código cliente"
            .Width = 0
            .Visible = False
            .ReadOnly = True
        End With
        With tbrazonsocial '5
            .DataPropertyName = "razon_social"
            .HeaderText = "Cliente"
            .Width = 120
            .Resizable = DataGridViewTriState.True
        End With
        With tbidirecosignado '6
            .DataPropertyName = "iddireccion_consignado"
            .HeaderText = "Código dirección"
            .Visible = False
            .ReadOnly = True
        End With
        With tbdireccion '7
            .DataPropertyName = "direccion"
            .HeaderText = "Dirección"
            .Resizable = DataGridViewTriState.True
            .Width = 120
        End With
        With tbhoraini '8
            .DataPropertyName = "hora_ini"
            .HeaderText = "Hora listo"
            .DefaultCellStyle.Format = "HH:mm"
            .DefaultCellStyle.Alignment = HorizontalAlignment.Center
            .Width = 60
        End With
        With tbhorafin ' 9 
            .DataPropertyName = "hora_fin"
            .HeaderText = "Hora cierre"
            .DefaultCellStyle.Format = "HH:mm"
            .DefaultCellStyle.Alignment = HorizontalAlignment.Center
            .Width = 60
        End With
        With tbnropaquetes  '10
            .DataPropertyName = "nro_paquetes"
            .HeaderText = "Nº paquetes"
            .Width = 70
            .DefaultCellStyle.Format = "###,###,##0"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End With
        With tbpesokg  '11
            .DataPropertyName = "peso_kg"
            .HeaderText = "Peso"
            .Width = 70
            .DefaultCellStyle.Format = "###,###,###.00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        With tbvolumen   '12
            .DataPropertyName = "volumen"
            .HeaderText = "Volumen"
            .Width = 70
            .DefaultCellStyle.Format = "###,###,###.00"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With        '
        With tbidestadorecogo   '13
            .DataPropertyName = "idestado_recojo"
            .HeaderText = "Estado"
            .Width = 60
        End With
        'DataGridView1.Columns.AddRange{Nrosolicitud,nombcltecall,idagenciatb,idfecharecojotb,idpersonatb,razonsocialtb,
        'idirecosignadotb,'direcciontb,'horainitb,'horafintb,'nropaquetestb,'pesokgtb,'volumentb,'observaciontb,'idestadorecogotb}
        DataGridViewPlt.Columns.Add(tbNrosolicitud)
        DataGridViewPlt.Columns.Add(Colaprobado)
        DataGridViewPlt.Columns.Add(tbunidadtransporte)
        'DataGridViewPlt.Columns.Add(Colidruta_entrega_recojo)
        DataGridViewPlt.Columns.Add(tbrutaentrega)
        DataGridViewPlt.Columns.Add(tbidpersona)
        DataGridViewPlt.Columns.Add(tbrazonsocial)
        DataGridViewPlt.Columns.Add(tbidirecosignado)
        DataGridViewPlt.Columns.Add(tbdireccion)
        DataGridViewPlt.Columns.Add(tbhoraini)
        DataGridViewPlt.Columns.Add(tbhorafin)
        DataGridViewPlt.Columns.Add(tbnropaquetes)
        DataGridViewPlt.Columns.Add(tbpesokg)
        DataGridViewPlt.Columns.Add(tbvolumen)
        DataGridViewPlt.Columns.Add(tbidestadorecogo)
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        filtro = ""
        If CheckBox1.Checked = False Then 'Llenar el combo para la agencia que esta asociado al usuario .
            filtro = "idusuario_personal = " & Trim(usuario)
            dvAgencia.RowFilter = filtro
        End If
        If CheckBox1.Checked = True Then 'Llenar el combo para todos las agencias            
            dvAgencia.RowFilter = filtro
        End If
        recupera_agencia()
    End Sub
    Sub recupera_agencia()
        Dim posicion As Integer
        posicion = CmbAgencia.SelectedIndex()
        If posicion >= 0 Then
            drvAgencia = dvAgencia.Item(posicion)
            idagencia = IIf(IsDBNull(drvAgencia("idagencias")) = True, "0", drvAgencia("idagencias").ToString)
        End If
        ' Recupera la ruta 
        recupera_ruta()
        '
        Call recupera_solcitud()        
    End Sub
    Sub recupera_solcitud()
        Dim ls_fecha_recojo As String
        ls_fecha_recojo = DateTimePicker1.Value.ToString()
        'Recuperando la nueva solicitud 
        rstSolCarga = Nothing
        dtSolCarga.Clear()
        ClaseSolAsignamovil.idagencia = idagencia
        ClaseSolAsignamovil.fecharecojo = ls_fecha_recojo
        rstSolCarga = ClaseSolAsignamovil.Get_solicitud_movil
        If rstSolCarga.Fields.Count >= 0 Then
            dr4.Fill(dtSolCarga, rstSolCarga)
            dvSolCarga = dtSolCarga.DefaultView
            dvSolCarga.AllowNew = True
        End If
    End Sub
    Sub recupera_ruta()
        Try
            'rstruta = Nothing
            'dtunitransagencia.Clear()
            'ClaseSolcomun.idagencia = idagencia
            'rstunitransagencia = ClaseSolcomun.get_unidad_trans_x_agencia
            'If rstunitransagencia.Fields.Count >= 0 Then
            dr4.Fill(dtruta, rstruta)
            dvruta = dtruta.DefaultView
            'Para q' no afecte nada se copia el parametro.  
            dtRutasClon = dtruta.Copy
            dvruta.AllowNew = True
            'End If
            'llenando el combo 
            'LlenaComboE(rstruta, dtruta, dvruta, cmbruta, "nombre_ruta_entrega_recojo")
            dvruta = CargarCombo(cmbruta, dtruta, "nombre_ruta_entrega_recojo", "idruta_entrega_recojo", 0)
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Asignando él valor ")
        End Try
    End Sub
    Private Sub DateTimePicker1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.TextChanged
        Call recupera_solcitud()
    End Sub
    Private Sub CmbAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbAgencia.SelectedIndexChanged
        recupera_agencia()
    End Sub
    Private Sub cmbruta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbruta.SelectedIndexChanged
        Dim liruta, posicion As Integer
        posicion = cmbruta.SelectedIndex()
        If posicion >= 0 Then
            drvruta = dvruta.Item(posicion)
            liruta = IIf(IsDBNull(drvruta("idruta_entrega_recojo")) = True, "0", drvruta("idruta_entrega_recojo").ToString)
        End If
        If liruta = 0 Then
            dvSolCarga.RowFilter = ""
        Else
            dvSolCarga.RowFilter = "idruta_entrega_recojo = " & Trim(liruta)
        End If
    End Sub
End Class