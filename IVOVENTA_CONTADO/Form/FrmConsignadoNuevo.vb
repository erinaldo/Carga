Public Class FrmConsignadoNuevo
    Public IDUnidadDestino As Integer
    Public IDPersona As Integer
    Public IDConsignado As String
    Public IDComprobante As Integer
    Public IDTipoComprobante As Integer
    Public IDTipoDocumento As Integer

    Dim bSalir As Boolean = True

    Private intOpcion As Integer
    Public Property Opcion() As Integer
        Get
            Return intOpcion
        End Get
        Set(ByVal value As Integer)
            intOpcion = value
        End Set
    End Property

    Private Sub FrmConsignado_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not bSalir Then
            bSalir = True
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmConsignado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If Me.txtapeMConsig.Focused Then
                BtnAceptar.Focus()
            Else
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub FrmConsignadoNuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim obj As New dtoVentaCargaContado
        Dim ds As New DataSet
        ds = obj.TipoDocumento()

        With CboTipoDocumento
            .DataSource = ds.Tables(0)
            .DisplayMember = "tipo_doc_identidad"
            .ValueMember = "idtipo_doc_identidad"
            .SelectedValue = 3
        End With

        If Opcion = 1 Then
            If IDTipoDocumento > 0 Then
                Me.CboTipoDocumento.SelectedValue = IDTipoDocumento
            End If
        End If
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        Try
            Dim obj As New dtrecojo
            Dim snum As String = Me.TxtNumero.Text
            Dim iExiste As Integer = 0

            If CboTipoDocumento.SelectedValue = 9 Then
                MessageBox.Show("Seleccione Tipo de Documento", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CboTipoDocumento.Focus()
                bSalir = False
                Return
            End If

            If CboTipoDocumento.SelectedValue = 1 Then
                If Not fnValidarRUC(TxtNumero.Text) Then
                    MessageBox.Show("El RUC no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtNumero.Focus()
                    bSalir = False
                    Return
                End If

                Dim objContacto As New dtoVentaCargaContado
                Dim dt As DataTable = objContacto.ListarContacto(TxtNumero.Text.Trim)
                If dt.Rows.Count > 0 Then
                    iExiste = 1
                    IDConsignado = dt.Rows(0).Item("id_consignado")
                End If

            Else
                If TxtNumero.Text.Length < 6 Then
                    MessageBox.Show("El Nº de Documento no es Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtNumero.Focus()
                    bSalir = False
                    Return
                Else
                    Dim objContacto As New dtoVentaCargaContado
                    Dim dt As DataTable = objContacto.ListarContacto(TxtNumero.Text.Trim)
                    If dt.Rows.Count > 0 Then
                        iExiste = 1
                        IDConsignado = dt.Rows(0).Item("id_consignado")
                    End If
                End If
            End If


            If Me.txtTelefono.Text.Trim.Length > 0 Then
                If Me.txtTelefono.Text.Trim.Length < 6 Or Val(Me.txtTelefono.Text.Trim.Substring(0, 1)) < 2 Then
                    MessageBox.Show("Ingrese un Número de Teléfono Válido.", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtTelefono.Text = txtTelefono.Text.Trim()
                    txtTelefono.Focus()
                    bSalir = False
                    Return
                End If
            End If

            If Me.TxtConsignado.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese " & IIf(CboTipoDocumento.SelectedValue = 1, "Razón Social del Cliente", "Nombres del Cliente"), "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtConsignado.Text = TxtConsignado.Text.Trim()
                TxtConsignado.Focus()
                bSalir = False
                Return
            End If

            If CboTipoDocumento.SelectedValue <> 1 Then
                If Me.txtapePConsig.Text.Trim.Length = 0 Then
                    MessageBox.Show("Ingrese Apellido Paterno", "Titán", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtapePConsig.Text = txtapePConsig.Text.Trim()
                    txtapePConsig.Focus()
                    bSalir = False
                    Return
                End If
            End If

            Cursor = Cursors.AppStarting
            If CboTipoDocumento.SelectedValue = 9 Or CboTipoDocumento.Text.Trim = "" Then txtTelefono.Text = "@"
            'IDConsignado &= 0 & ";"
            'IDConsignado = 0

            If Opcion = 0 Then
                Dim obj2 As New dtoVentaCargaContado
                obj2.GrabarConsignado(
                                        IDConsignado,
                                        IDComprobante,
                                        IDTipoComprobante,
                                        IDUnidadDestino,
                                        IDPersona,
                                        dtoUSUARIOS.IdLogin,
                                        dtoUSUARIOS.IdRol,
                                        dtoUSUARIOS.IP,
                                        TxtConsignado.Text.Trim,
                                        TxtConsignado.Text.Trim,
                                        txtapePConsig.Text.Trim,
                                        txtapeMConsig.Text.Trim,
                                        TxtNumero.Text.Trim,
                                        CboTipoDocumento.SelectedValue,
                                        txtTelefono.Text.Trim,
                                        iExiste
                                        )
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CboTipoDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboTipoDocumento.SelectedIndexChanged
        If Not IsReference(Me.CboTipoDocumento.SelectedValue) Then
            Me.TxtNumero.Enabled = True
            If Me.CboTipoDocumento.SelectedValue = 1 Then
                Me.TxtNumero.MaxLength = 11
                Me.LblConsignado.Text = "Raz. Soc."
                Me.LblApePat.Visible = False
                Me.lblApeMat.Visible = False
                Me.txtapePConsig.Visible = False
                Me.txtapeMConsig.Visible = False
                Me.LblConsignado.Top = 50
                Me.TxtConsignado.Top = 47
                Me.txtapePConsig.Text = ""
                Me.txtapeMConsig.Text = ""
                Me.GrbConsignado.Enabled = True
            Else
                Me.LblConsignado.Text = "Nombres"
                Me.LblConsignado.Top = 39
                Me.TxtConsignado.Top = 37
                Me.LblApePat.Visible = True
                Me.lblApeMat.Visible = True
                Me.txtapePConsig.Visible = True
                Me.txtapeMConsig.Visible = True

                If Me.CboTipoDocumento.SelectedValue = 3 Then
                    Me.TxtNumero.MaxLength = 8
                ElseIf Me.CboTipoDocumento.SelectedValue = 9 Then
                    Me.TxtNumero.Text = ""
                    Me.TxtNumero.Enabled = False
                    Me.txtTelefono.Focus()
                Else
                    Me.TxtNumero.MaxLength = 20
                End If
            End If
            Me.TxtConsignado.Text = Me.TxtConsignado.Text.Trim
        End If
    End Sub

    Private Sub TxtNumero_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNumero.Enter
        TxtNumero.SelectAll()
    End Sub

    Private Sub TxtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumero.KeyPress
        If Not ValidarNumero(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtConsignado_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtConsignado.Enter
        TxtConsignado.SelectAll()
    End Sub

    Private Sub TxtConsignado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtConsignado.KeyPress
        'If Not ValidarLetraNumero(e.KeyChar) Then
        '    e.Handled = True
        'End If
        If Me.CboTipoDocumento.SelectedValue = 1 Then
            If Not ValidarLetraNumero(e.KeyChar) Then
                e.Handled = True
            End If
        Else
            If Not ValidarLetra(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub
End Class