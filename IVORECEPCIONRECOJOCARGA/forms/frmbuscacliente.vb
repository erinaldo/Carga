'Imports System.Windows.Forms
'Imports System.Data.OleDb
'Imports System.Data
'Imports System.Text.RegularExpressions
'Imports System
'Imports System.Drawing
'Imports System.IO
'Imports ADOSERVERLib
Public Class frmbuscacliente
#Region "Clases "
    Dim ClaseSolReco As New dtoSolicitudRecojoCarga
    ' Creando la busqueda 
    Dim clasebusqueda As New dtoSolRecojoBusqueda
#End Region
#Region " DECLARACION VARIABLES "
    'Declaracion de Recordset
    'datahelper
    'Dim rstcliente, rstdireccion, rstcontacto As ADODB.Recordset
    Dim rstcliente, rstdireccion, rstcontacto As DataTable

    'Declaracion de Data Adapters
    'Dim odda_cliente As New OleDb.OleDbDataAdapter
    'Declaracion de DataTables
    Dim dtcliente, dtdireccion, dtcontacto As New System.Data.DataTable
    ' Declarando Data View 
    Dim dvcliente, dvdireccion, dvcontacto As New DataView
    'Declarando Data row View 
    Dim drvcliente As DataRowView
    ' Declarando variables de uso general 
    Dim filtro As String = ""    
    'Crean OledbDataAdapter 
    'Dim dr4 As New OleDb.OleDbDataAdapter
    'Creando un nuevo objeto 
    Dim dgvc_agencia As System.Windows.Forms.DataGridViewCell
    Dim cargaunicavez As Boolean
    Public hnd As Long
#End Region
#Region "DECLARANDO GRILLA"
    Dim DataGridTableStylew As New DataGridTableStyle()
    Dim DataGridTableStyle1 As New DataGridTextBoxColumn()
    Dim DataGridTableStyle2 As New DataGridTextBoxColumn()
    ' Declare a variable of type BindingManagerBase named bindingManager.
    Dim bindingManager As BindingManagerBase
#End Region

    Private Sub frmbuscacliente_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub frmbuscacliente_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub frmbuscacliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim busquedaclte As String
            ' Recupera el combo de agencias, usando una clase   
            Select Case ModSolRecojoCarga.busquedapor
                Case 0 'Cliente 
                    cargaunicavez = True
                    'Inicializando variables 
                    ModSolRecojoCarga.idcliente = Nothing
                    ModSolRecojoCarga.scliente = Nothing
                    btnAdd.Visible = False
                    '
                    ShadowLabel1.Text = "Clientes"
                    busquedaclte = TextBox1.Text
                    If busquedaclte = "" Then
                        cargaunicavez = False
                    End If
                    busquedaclte = IIf(busquedaclte <> "", busquedaclte, "%")
                    clasebusqueda.busquedacondicicionclte = busquedaclte
                    'Cargando los clientes
                    busquedaclientes()
                    '
                    If dvcliente.Count = 1 Then 'Encontro un solo item recupera 
                        Devolver_busqueda()
                        ' Invocando al tema de direcciones 
                        Me.Close()
                    End If
                Case 1 'Direccion 
                    'Inicializando variables  
                    btnAdd.Visible = True
                    ModSolRecojoCarga.idcontacto = Nothing
                    ModSolRecojoCarga.scontacto = Nothing
                    ModSolRecojoCarga.idireccion = Nothing
                    ModSolRecojoCarga.sdireccion = Nothing
                    ShadowLabel1.Text = "Direcciones"
                    clasebusqueda.Idcliente = ModSolRecojoCarga.idcliente
                    clasebusqueda.Idpais = ModSolRecojoCarga.idpais
                    clasebusqueda.Iddepartamento = ModSolRecojoCarga.iddpto
                    clasebusqueda.Idprovincia = ModSolRecojoCarga.idprov
                    'datahelper
                    'rstdireccion = clasebusqueda.BusquedaDireccion_agencia
                    'dr4.Fill(dtdireccion, rstdireccion)
                    rstdireccion = clasebusqueda.BusquedaDireccion_agencia
                    dtdireccion = rstdireccion
                    dvdireccion = dtdireccion.DefaultView
                    dvdireccion.AllowNew = False
                    'Creando la grilla de busqueda 
                    If dvdireccion.Count() = 0 Then
                        ' Abriendo ventana para registrar nuevos contactos 
                        Dim a As New FrmMantClteCarga
                        Dim resultado As DialogResult
                        '
                        ModSolRecojoCarga.idagencia = ModSolRecojoCarga.idagencia
                        ModSolRecojoCarga.bcancelar = True  'Desactivando el control 

                        'resultado = a.ShowDialog()

                        Acceso.Asignar(a, Me.hnd)
                        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                            resultado = a.ShowDialog()
                        Else
                            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        Me.Close()
                        Exit Sub
                    End If
                    Grilla_direccion()
                    If dvdireccion.Count() = 1 Then
                        'Recupera la fila dirección 
                        recupera_fila_direccion() 'Recupera contacto mendozita
                        Trae_contacto()
                        Me.Close()
                    End If
                Case 2 'Contacto 
                    btnAdd.Visible = True
                    ModSolRecojoCarga.idcontacto = Nothing
                    ModSolRecojoCarga.scontacto = Nothing
                    ShadowLabel1.Text = "Contacto"
                    clasebusqueda.Idcliente = ModSolRecojoCarga.idcliente
                    clasebusqueda.Iddireccion = ModSolRecojoCarga.idireccion
                    'datahelper
                    'rstcontacto = clasebusqueda.Busquedacontacto
                    'odda_cliente.Fill(dtcontacto, rstcontacto)
                    rstcontacto = clasebusqueda.Busquedacontacto
                    dtcontacto = rstcontacto
                    dvcontacto = dtcontacto.DefaultView
                    If dvcontacto.Count() = 0 Then
                        ' Abriendo ventana para registrar nuevos contactos 
                        Dim a As New FrmMantClteCarga
                        Dim resultado As DialogResult
                        '
                        ModSolRecojoCarga.idagencia = ModSolRecojoCarga.idagencia
                        ModSolRecojoCarga.bcancelar = True  'Desactivando el control 
                        'resultado = a.ShowDialog()
                        Acceso.Asignar(a, Me.hnd)
                        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                            resultado = a.ShowDialog()
                        Else
                            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        Me.Close()
                        Exit Sub
                    End If
                    grilla_contacto()
                    If dvcontacto.Count() = 1 Then
                        'Recupera la fila dirección 
                        recupera_fila_contacto()
                        Me.Close()
                    End If
            End Select

            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
        Catch ex As Exception
            MessageBox.Show(G_Mje, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Sub Grilla_cliente()
        'Creando una variable temporal 
        'Dim TempColumn As DataGridTextBoxColumn
        ' Llena una grilla una vez insertado el dataview(dw)
        'Limpiando datagrid 
        'DataGridView1.ClearSelection()
        'Configurando la grilla 
        With DataGridView1
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .BackgroundColor = Color.White
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False  'Para que no incremente la fila
            .AutoGenerateColumns = False ''Las filas no se generen automaticamente de la bd
            ' Asignando el dataview  
            .DataSource = dvcliente
            '
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            .RowHeadersVisible = False
            .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect            
        End With
        'Creando los campos del tipo DataGridViewTextBoxColumn
        Dim dgvtbcrazonsocial As New DataGridViewTextBoxColumn
        With dgvtbcrazonsocial '0
            .DataPropertyName = "RAZON_SOCIAL"
            .HeaderText = "Razon Social"
            .ToolTipText = "Razón Social"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridView1.Columns.Add(dgvtbcrazonsocial)
        '
        Dim dgvtbcidcliente As New DataGridViewTextBoxColumn
        With dgvtbcidcliente '1
            .HeaderText = "Código"
            .Name = "IDPERSONA"
            .DataPropertyName = "idpersona"
            .ReadOnly = True
            .Visible = False
        End With
        DataGridView1.Columns.Add(dgvtbcidcliente)
        '
        Dim dgvtbcapellido_paterno As New DataGridViewTextBoxColumn
        With dgvtbcapellido_paterno '2
            .DataPropertyName = "apellido_paterno"
            .HeaderText = "Apellido paterno"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = False
        End With
        DataGridView1.Columns.Add(dgvtbcapellido_paterno)
        '
        Dim dgvtbcapellido_materno As New DataGridViewTextBoxColumn
        With dgvtbcapellido_materno '3
            .DataPropertyName = "apellido_materno"
            .HeaderText = "Apellido materno"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
            .Visible = False
        End With
        DataGridView1.Columns.Add(dgvtbcapellido_materno)
        '
        Dim dgvtbcnombre As New DataGridViewTextBoxColumn
        With dgvtbcnombre '4
            .DataPropertyName = "nompre_persona"
            .HeaderText = "Nombre"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = False
        End With
        DataGridView1.Columns.Add(dgvtbcnombre)
        '
        Dim dgvtbctipoidentidad As New DataGridViewTextBoxColumn
        With dgvtbctipoidentidad '5
            .DataPropertyName = "tipo_doc_identidad"
            .HeaderText = "Documento identidad"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridView1.Columns.Add(dgvtbctipoidentidad)
        '
        Dim dgvtbcnu_docusuna As New DataGridViewTextBoxColumn
        With dgvtbcnu_docusuna '6
            .DataPropertyName = "nu_docu_suna"
            .HeaderText = "Número documento"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridView1.Columns.Add(dgvtbcnu_docusuna)
    End Sub
    Sub Grilla_direccion()
        With DataGridView1
            .AllowUserToAddRows = False  'Para que no incremente la fila
            .AutoGenerateColumns = False ''Las filas no se generen automaticamente de la bd
            .DataSource = dvdireccion
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .BackgroundColor = Color.White
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            .RowHeadersVisible = False
            .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect 'La linea que se esta posicionando. 
        End With
        Dim dgvtbcnom_contacto As New DataGridViewTextBoxColumn
        With dgvtbcnom_contacto
            .DataPropertyName = "nom_contacto"
            .HeaderText = "Nombres y Apellidos"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridView1.Columns.Add(dgvtbcnom_contacto)
        '
        Dim dgvtbcidcontacto As New DataGridViewTextBoxColumn        
        With dgvtbcidcontacto
            .Visible = False
            .Width = 0
            .DataPropertyName = "idcontacto_persona"
            .HeaderText = "Código contacto"
        End With
        DataGridView1.Columns.Add(dgvtbcidcontacto)
        '
        Dim dgvtbciddireccion_consignado As New DataGridViewTextBoxColumn
        With dgvtbciddireccion_consignado
            .Visible = False
            .DataPropertyName = "iddireccion_consignado"
            .HeaderText = "Direccion consignado"
            .ReadOnly = True            
        End With
        DataGridView1.Columns.Add(dgvtbciddireccion_consignado)
        '
        Dim dgvtbcdireccion As New DataGridViewTextBoxColumn
        With dgvtbcdireccion
            .DataPropertyName = "direccion"
            .HeaderText = "Dirección"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        DataGridView1.Columns.Add(dgvtbcdireccion)
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim cadena, qrybusqueda As String
        'filtro = Me.TextBox1.Text
        Select Case ModSolRecojoCarga.busquedapor
            Case 0 'Cliente 
                ''''dvcliente.RowFilter = "" ' "razon_social like '%" & Me.TextBox1.Text & "%'"
                If Me.TextBox1.Text = "" Then
                    'Debe volver a llamar a la bd
                    If cargaunicavez Then
                        clasebusqueda.busquedacondicicionclte = "%"
                        busquedaclientes()
                        cargaunicavez = False
                    End If
                End If
                cadena = CType(Me.TextBox1.Text, String)
                qrybusqueda = "razon_social like '%" & cadena & "%' Or " 'apellido_paterno like '%" & cadena & "%' or "
                'qrybusqueda = qrybusqueda + " apellido_materno like '%" & cadena & "%' or nompre_persona like '%" & cadena & "%' or "
                qrybusqueda = qrybusqueda + " nu_docu_suna like '%" & cadena & "%'"
                dvcliente.RowFilter = qrybusqueda
            Case 1 'Direccion 
                dvdireccion.RowFilter = "direccion like '% " & Me.TextBox1.Text & "%'"
            Case 2 'Contacto 


        End Select
    End Sub
    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        MsgBox("Llamar formulario cliente")
    End Sub
    Private Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Select Case ModSolRecojoCarga.busquedapor
            Case 0
                ModSolRecojoCarga.idcliente = Nothing
                ModSolRecojoCarga.scliente = Nothing
            Case 1
                ModSolRecojoCarga.idireccion = Nothing
                ModSolRecojoCarga.sdireccion = Nothing
            Case 2
                ModSolRecojoCarga.idcontacto = Nothing
                ModSolRecojoCarga.scontacto = Nothing
        End Select
        Me.Close()
    End Sub
    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        'Dim drowgrid As New DataGridViewRow        
        'Dim lidcliente As Integer
        'Dim lcliente As String
        'Dim frminvoca As New FrmSolicitaRecojoCarga_new
        'Solo invoca a esta funcion 
        Devolver_busqueda()
        'Select Case ModSolRecojoCarga.busquedapor
        '    Case 0  'Cliente 
        '        bindingManager = BindingContext(dvcliente)
        '        ' Pasando los valores a la ventana que invoco 
        '        Dim curDataRow As DataRow = GetCurrentDataRow()
        '        'frminvoca.
        '        lidcliente = curDataRow(0)
        '        lcliente = curDataRow(1)
        '        'Verificando si tiene una direccion, recupera la dirección 
        '        clasebusqueda.Idcliente = lidcliente
        '        rstdireccion = clasebusqueda.BusquedaDireccion
        '        dr4.Fill(dtdireccion, rstdireccion)
        '        dvdireccion = dtdireccion.DefaultView
        '        If dvdireccion.Count = 1 Then
        '            recupera_fila_direccion()
        '        End If
        '        ModSolRecojoCarga.idcliente = lidcliente
        '        ModSolRecojoCarga.scliente = lcliente
        '    Case 1 'Direccion 
        '        recupera_fila_direccion()
        'End Select
        Me.Close()
    End Sub
    Private Function GetCurrentDataRow() As DataRow
        ' Declare a variable of type DataRow named sourceTableDataRow.
        Dim sourceTableDataRow As DataRow
        ' Cast the BindingManagerBase's Current(row) as a DataRowView.
        ' Cast the DataRowView as a DataRow.
        ' Assign the resulting reference to the sourceTableDataRow variable
        ' which is now a pointer to the original row the source table.
        sourceTableDataRow = CType(CType(bindingManager.Current, DataRowView).Row, DataRow)
        ' Return a reference (pointer) to the source DataRow.
        Return sourceTableDataRow
    End Function
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs) 'Configura el shadow label 
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), ClientSize)
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Private Sub recupera_fila_direccion()
        Dim lidcontacto, lidireccion As Integer
        Dim lcontacto, ldireccion As String
        Try
            ' Recupera la direccion 
            bindingManager = BindingContext(dvdireccion)
            Dim curDataRow As DataRow = GetCurrentDataRow()
            lidcontacto = curDataRow(0)
            lcontacto = curDataRow(1)
            lidireccion = curDataRow(2)
            ldireccion = curDataRow(3)
            ModSolRecojoCarga.idireccion = lidireccion
            ModSolRecojoCarga.sdireccion = ldireccion
            '  
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub recupera_fila_contacto()        
        Dim lidcontacto As Integer
        Dim lcontacto As String
        Try
            ' Recupera la direccion 
            bindingManager = BindingContext(dvcontacto)
            Dim curDataRow As DataRow = GetCurrentDataRow()
            lidcontacto = curDataRow(0)
            lcontacto = curDataRow(1)
            ModSolRecojoCarga.idcontacto = lidcontacto
            ModSolRecojoCarga.scontacto = lcontacto
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Recuperado los valores
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = CInt(Keys.Escape) Then
            'SendKeys.Send("{Tab}")
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
            Return True            
        End If
        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            Devolver_busqueda()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub Devolver_busqueda()
        Dim dgvr As DataGridViewRow = Me.DataGridView1.CurrentRow()
        Dim lidcliente As Integer
        Dim lcliente, ls_cadena As String
        '
        Me.DialogResult = Windows.Forms.DialogResult.OK

        ' Código devuelta 
        If Not Me.DataGridView1.CurrentRow() Is Nothing Then
            Select Case ModSolRecojoCarga.busquedapor
                Case 0 'Cliente 
                    ' Pasando los valores a la ventana que invoco 
                    'lidcliente = CType(dgvr.Cells("IDPERSONA").Value, Integer)
                    lidcliente = CType(dgvr.Cells(1).Value, Integer)
                    lcliente = dgvr.Cells(0).Value.ToString()
                    ls_cadena = dgvr.Cells(5).Value.ToString()
                    ls_cadena = ls_cadena + " - " + dgvr.Cells(6).Value.ToString()
                    lcliente = lcliente + " (" + ls_cadena + ")"
                    '
                    ModSolRecojoCarga.idcliente = lidcliente
                    ModSolRecojoCarga.scliente = lcliente
                    ' Se debe traer la dirección 
                    Trae_direccion()
                Case 1 'Direccion 
                    recupera_fila_direccion()
                    Trae_contacto()
                Case 2 'Contacto 
                    recupera_fila_contacto()
            End Select
        Else
            MessageBox.Show("No hay ningun registro filtrado por seleccionar.", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Private Sub Trae_direccion()
        Dim lfrm_busqueda As New frmbuscacliente
        Dim lidcliente As Integer
        lidcliente = ModSolRecojoCarga.idcliente
        'Recupera el cliente a buscar 
        ModSolRecojoCarga.busquedapor = 1  'Direccion 
        ModSolRecojoCarga.idcliente = lidcliente
        lfrm_busqueda.TextBox1.Text = ""
        'lfrm_busqueda.ShowDialog()

        Acceso.Asignar(lfrm_busqueda, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            lfrm_busqueda.ShowDialog()
        Else
            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
    Private Sub busquedaclientes()
        ''''''''''   
        'Recuperando una nueva busqueda
        rstcliente = Nothing
        dtcliente.Clear()
        dvcliente = Nothing
        ' Limpiando y volviendo a crear 
        DataGridView1.Columns.Clear()
        '
        'datahelper
        'rstcliente = clasebusqueda.BusquedaCliente
        'dr4.Fill(dtcliente, rstcliente)
        rstcliente = clasebusqueda.BusquedaCliente.Tables(0)
        dtcliente = rstcliente
        dvcliente = dtcliente.DefaultView
        dvcliente.AllowNew = False
        ' Filtro debe hacer con datawiev o datatable (Propio de net) 
        'filtro = Me.TextBox1.Text
        'dvcliente.RowFilter = "razon_social like '%" & filtro & "%'"
        'Creando la grilla de busqueda 
        '
        Grilla_cliente()
        '
    End Sub
    Sub grilla_contacto()
        DataGridView1.Columns.Clear()
        With DataGridView1
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .BackgroundColor = Color.White
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False  'Para que no incremente la fila
            .AutoGenerateColumns = False ''Las filas no se generen automaticamente de la bd            
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .VirtualMode = True
            .RowHeadersVisible = False
            .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoResizeColumns()
            '           
            .DataSource = dvcontacto
        End With
        '
        Dim dgvtbcidcontacto As New DataGridViewTextBoxColumn
        With dgvtbcidcontacto   '0 
            .Visible = False
            .Width = 0
            .DataPropertyName = "idcontacto_persona"
            .HeaderText = "Código contacto"
            .ReadOnly = True
            .Visible = False
        End With
        DataGridView1.Columns.Add(dgvtbcidcontacto)
        '
        Dim dgvnom_contacto As New DataGridViewTextBoxColumn
        With dgvnom_contacto   '1
            .DataPropertyName = "nom_contacto"
            .HeaderText = "Encargado"
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Resizable = DataGridViewTriState.True
        End With
        DataGridView1.Columns.Add(dgvnom_contacto)
    End Sub
    Sub Trae_contacto()
        Dim lidcliente, liddireccion As Integer
        lidcliente = ModSolRecojoCarga.idcliente
        liddireccion = ModSolRecojoCarga.idireccion
        Dim lfrm_busqueda As New frmbuscacliente
        'Recupera el cliente a buscar 
        ModSolRecojoCarga.busquedapor = 2  'Contacto 
        ModSolRecojoCarga.idcliente = lidcliente
        ModSolRecojoCarga.iddireccion_consignado = liddireccion
        lfrm_busqueda.TextBox1.Text = ""
        'lfrm_busqueda.ShowDialog()  ' mendozita

        Acceso.Asignar(lfrm_busqueda, Me.hnd)
        If Acceso.TieneAcceso(G_Rol, G_Fila) Then
            lfrm_busqueda.ShowDialog()
        Else
            MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
End Class
