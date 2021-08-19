Public Class frmCategoriaEquipaje
    Dim blnSalir As Boolean

    Private intInicio As Integer
    Public Property Inicio() As Integer
        Get
            Return intInicio
        End Get
        Set(ByVal value As Integer)
            intInicio = value
        End Set
    End Property

    Private intFin As Integer
    Public Property Fin() As Integer
        Get
            Return intFin
        End Get
        Set(ByVal value As Integer)
            intFin = value
        End Set
    End Property

    Private intTipo As Integer
    Public Property Tipo() As Integer
        Get
            Return intTipo
        End Get
        Set(ByVal value As Integer)
            intTipo = value
        End Set
    End Property


    Private Sub frmCategoriaEquipaje_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not blnSalir Then
            blnSalir = True
            e.Cancel = True
        End If
    End Sub

    Sub ListarCategoria()
        Dim obj As New dtoVentaCargaContado
        Dim dt As DataTable = obj.ListarCategoria(intTipo)
        With Me.cboCategoria
            .ValueMember = "id"
            .DisplayMember = "descripcion"
            .DataSource = dt
            .SelectedValue = 0
        End With
    End Sub

    Sub GenerarCantidad()
        Me.cboBulto.Items.Add(" (SELECCIONE)")
        For i As Integer = intInicio To intFin
            Me.cboBulto.Items.Add(i)
        Next
        Me.cboBulto.SelectedIndex = 0
    End Sub

    Private Sub frmCategoriaEquipaje_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        blnSalir = True
        ListarCategoria()
        GenerarCantidad()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.cboCategoria.SelectedValue = 0 Then
            MessageBox.Show("Seleccione la Categoría", "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboCategoria.Focus()
            Me.cboCategoria.DroppedDown = True
            blnSalir = False
            Return
        End If

        If Me.cboBulto.SelectedIndex = 0 Then
            MessageBox.Show("Seleccione Nº de Bultos", "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboBulto.Focus()
            Me.cboBulto.DroppedDown = True
            blnSalir = False
            Return
        End If


    End Sub
End Class