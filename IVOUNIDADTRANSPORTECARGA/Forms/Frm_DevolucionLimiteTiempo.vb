Imports INTEGRACION_LN
Imports System.Data.Odbc
Public Class Frm_DevolucionLimiteTiempo
    Dim objConsultaGeneral As dtoConsultaGeneral2
    Dim coll_Unidad_Agencia_Origen As New Collection
    Dim coll_Unidad_Agencia_Destino As New Collection

    Private obj_DevolucionLimiteTiempo As Cls_DevolucionLimiteTiempo_LN
    Private lcls_Utilitarios As Cls_Utilitarios
    Dim intAgencia As Integer
    Dim intDias As Integer
    Dim utilData As New UtilData_LN
   
#Region "EVENTOS DE COMPONENTES"

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Sub New(ByVal pStr_CboAgenciaDestino As String)
        ' This call is required by the designer.
        InitializeComponent()

        utilData.cargarCombos("t_agencias", cboAgencia, True)
        cboAgencia.SelectedValue = pStr_CboAgenciaDestino
    End Sub

#End Region


    Private Sub Frm_DevolucionLimiteTiempo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'clase para cargar Combo
        F_New()
        ''''''''''''''''''''        
    End Sub

    Private Function F_New() As Integer

        'obj_DevolucionLimiteTiempo = New Cls_DevolucionLimiteTiempo_LN 'refereanciamos la clase a mostrar
        utilData.cargarCombos("t_agencias", cboAgencia, True)
        'obj_DevolucionLimiteTiempo.F_CargarDestino_LN(CboAgenDestino, "t_agencias")

    End Function

    Private Sub ConsultarToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarToolStripMenuItem.Click

        If Val(Me.txtDias.Text) = 0 Then
            MessageBox.Show("Ingrese Nº de Días", "Consultar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtDias.Focus()
            Me.txtDias.SelectAll()
            Return
        End If

        Dim Control As String
        intAgencia = cboAgencia.SelectedValue
        intDias = txtDias.Text
        F_Retrieve(intAgencia, intDias)
    End Sub

    Private Function F_Retrieve(ByVal agencia As Integer, ByVal Dias As Integer) As Integer

        ' Private Function F_Retrieve() As Integer -- prueba

        ' Se hace la Consulta para sacar data de devoluciones con mas de 30 dias

        obj_DevolucionLimiteTiempo = New Cls_DevolucionLimiteTiempo_LN
        Windows.Forms.Cursor.Show()
        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Me.DgvDevolucion.DataSource = Nothing
        Me.DgvDevolucion.DataSource = obj_DevolucionLimiteTiempo.BuscarDevolucion_LN(agencia, Dias)
        'Me.DgvDevolucion.DataSource     obj_DevolucionLimiteTiempo.BuscarDevolucion_LN() -- prueba

        If Me.DgvDevolucion.Rows.Count > 0 Then
            lblCantidadRegistros.Text = Me.DgvDevolucion.Rows.Count
        Else
            Me.lblCantidadRegistros.Text = 0
            MsgBox("No se encontraron Registros", MsgBoxStyle.Information, "Aviso")
        End If
        lcls_Utilitarios = New Cls_Utilitarios
        With lcls_Utilitarios
            .FormatDataGridView(Me.DgvDevolucion)
        End With
        lcls_Utilitarios = Nothing
        Return 1

    End Function
    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ExcelToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelToolStripMenuItem.Click
        If DgvDevolucion.RowCount < 1 Then
            Return
        Else
            Dim lcls_Utilitarios As New Cls_Utilitarios
            With lcls_Utilitarios
                .fnEXCELGrid_ConFormato(Me.DgvDevolucion)
            End With
            lcls_Utilitarios = Nothing
        End If
    End Sub

    Private Sub txtDias_Enter(sender As Object, e As System.EventArgs) Handles txtDias.Enter
        Me.txtDias.SelectAll()
    End Sub

    ' Validando Solo Numeros 
    Private Sub TextDias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDias.KeyPress
        If e.KeyChar.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class

