Imports PrinterTxt
Public Class FrmIngreAnaBulto
    Dim objgeneral As New ClsLbTepsa.dtoGENERAL
    Dim ObjValida As New ClsLbTepsa.dtoValida
    Dim ObjIngre_Carga_Alma As New ClsLbTepsa.dtoIngre_Carga_Alma
    Dim dvIdTIPO_COMPROBANTE As DataView
    Dim dvDATOS_PERSONA As DataView
    Dim dv_SELEC_VENTA_UBICA As DataView
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub FrmIngreAnaBulto_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmIngreAnaBulto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MenuStrip1.Items(0).Visible = False
        Me.MenuStrip1.Items(1).Visible = False
        Me.MenuStrip1.Items(2).Visible = False

        Me.MenuStrip1.Items(3).Visible = True 'grabar
        Me.MenuStrip1.Items(3).Enabled = True 'grabar
        Me.MenuStrip1.Items(4).Visible = False
        Me.MenuStrip1.Items(5).Visible = False
        Me.MenuStrip1.Items(6).Visible = False 'imprimir
        Me.MenuStrip1.Items(7).Visible = False 'ayuda
        Me.MenuStrip1.Items(8).Visible = True 'salir


        MenuTab.Items(0).Text = "Ingreso a Anaquel"
        MenuTab.Items(1).Text = "Consulta de Ingresos"
        MenuTab.Items(2).Text = "Consulta General"
        MenuTab.Items(3).Text = "Impresion de Etiquetas"

        Me.CBIDAGENCIAS.Enabled = False
        Me.CBIDAGENCIAS1.Enabled = False
        Me.CBIDAGENCIAS2.Enabled = False



        'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
        'dvIdTIPO_COMPROBANTE = objgeneral.FN_cmb_l_tipo_comprobante(cnn, Me.cbidtipo_comprobante)
        dvIdTIPO_COMPROBANTE = objgeneral.FN_cmb_l_tipo_comprobante(Me.cbidtipo_comprobante)
        cbidtipo_comprobante.DataSource = Nothing
        dvIdTIPO_COMPROBANTE.RowFilter = "IDTIPO_COMPROBANTE IN (1,2,3)"
        cbidtipo_comprobante.DataSource = dvIdTIPO_COMPROBANTE
        cbidtipo_comprobante.DisplayMember = "TIPO_COMPROBANTE"
        cbidtipo_comprobante.ValueMember = "IDTIPO_COMPROBANTE"

        'objgeneral.FN_cmb_Listar_agencias(cnn, CBIDAGENCIAS)
        objgeneral.FN_cmb_Listar_agencias(CBIDAGENCIAS)
        CBIDAGENCIAS.SelectedValue = dtoUSUARIOS.iIDAGENCIAS

        ObjIngre_Carga_Alma.IDAGENCIAS = CBIDAGENCIAS.SelectedValue
        'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
        'ObjIngre_Carga_Alma.sp_cb_l_almacenes(Me.CBIDALMA, cnn)
        ObjIngre_Carga_Alma.sp_cb_l_almacenes(Me.CBIDALMA)
        CBIDALMA.SelectedValue = 1

        ObjIngre_Carga_Alma.IDALMA = CBIDALMA.SelectedValue
        ObjIngre_Carga_Alma.sp_cb_l_areas(Me.CBIDAREA)
        CBIDAREA.SelectedValue = 1

        ObjIngre_Carga_Alma.IDAREA = CBIDAREA.SelectedValue
        'ObjIngre_Carga_Alma.sp_cb_l_ANAQUELES(Me.CBIDANA, cnn)
        ObjIngre_Carga_Alma.sp_cb_l_ANAQUELES(Me.CBIDANA)

        CBIDANA.SelectedValue = 1
        ''''''''''''''''''''''''''''''''
        'Mod.14/10/2009 -->Omendoza - Pasando al datahelper -  
        objgeneral.FN_cmb_Listar_agencias_todos(CBIDAGENCIAS1)
        '
        CBIDAGENCIAS1.SelectedValue = dtoUSUARIOS.iIDAGENCIAS
        ObjIngre_Carga_Alma.IDAGENCIAS = CBIDAGENCIAS1.SelectedValue
        'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
        'ObjIngre_Carga_Alma.sp_cb_l_almacenes_TODOS(Me.CBIDALMA1, cnn)
        ObjIngre_Carga_Alma.sp_cb_l_almacenes_TODOS(Me.CBIDALMA1)
        '
        CBIDALMA1.SelectedValue = 1
        ObjIngre_Carga_Alma.IDALMA = CBIDALMA1.SelectedValue
        'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
        ObjIngre_Carga_Alma.sp_cb_l_areas_TODOS(Me.CBIDAREA1)
        CBIDAREA1.SelectedValue = 1
        ObjIngre_Carga_Alma.IDAREA = CBIDAREA1.SelectedValue
        'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
        ObjIngre_Carga_Alma.sp_cb_l_ANAQUELES_TODOS(Me.CBIDANA1)
        CBIDANA1.SelectedValue = 1

        ''''''''''''''''''''''''''''''''
        'Mod.14/10/2009 -->Omendoza - Pasando al datahelper -  
        objgeneral.FN_cmb_Listar_agencias_todos(CBIDAGENCIAS2)
        CBIDAGENCIAS2.SelectedValue = dtoUSUARIOS.iIDAGENCIAS
        ObjIngre_Carga_Alma.IDAGENCIAS = CBIDAGENCIAS2.SelectedValue
        'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
        'ObjIngre_Carga_Alma.sp_cb_l_almacenes_TODOS(Me.CBIDALMA2, cnn)
        ObjIngre_Carga_Alma.sp_cb_l_almacenes_TODOS(Me.CBIDALMA2)
        CBIDALMA2.SelectedValue = 1
        ObjIngre_Carga_Alma.IDALMA = CBIDALMA2.SelectedValue
        'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
        ObjIngre_Carga_Alma.sp_cb_l_areas_TODOS(Me.CBIDAREA2)
        CBIDAREA2.SelectedValue = 1
        ObjIngre_Carga_Alma.IDAREA = CBIDAREA2.SelectedValue
        'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
        ObjIngre_Carga_Alma.sp_cb_l_ANAQUELES_TODOS(Me.CBIDANA2)
        CBIDANA2.SelectedValue = 1
'
        Dim cadenas As String
        cadenas = ObjIngre_Carga_Alma.IDAGENCIAS
        While (Len(cadenas) < 3)
            cadenas = "0" + cadenas
        End While

        Me.MBIDINGRE_ANAQUELES.Text = cadenas

        Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 4) + CStr(CBIDALMA.SelectedValue) + Mid(Me.MBIDINGRE_ANAQUELES.Text, 6, 12)
        Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 6) + CStr(CBIDAREA.SelectedValue) + Mid(Me.MBIDINGRE_ANAQUELES.Text, 9, 8)
        Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 9) + CStr(CBIDANA.SelectedValue) + Mid(Me.MBIDINGRE_ANAQUELES.Text, 13, 5)

        Try
            'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
            'ObjIngre_Carga_Alma.SP_SELEC_T_ALMA_ANAQUELES(cnn)
            ObjIngre_Carga_Alma.SP_SELEC_T_ALMA_ANAQUELES()
            '
            Label9.Text = "(C" + CStr(ObjIngre_Carga_Alma.MAX_COLUM) + ",F" + CStr(ObjIngre_Carga_Alma.MAX_FILA) + ")"
        Catch ec As System.Data.OracleClient.OracleException
            MsgBox("Código: " + ec.Code.ToString + Chr(13) + "Descripción: " + ec.ToString, MsgBoxStyle.Exclamation, "Seguridad del sistema")
        End Try

        Me.TxtFILA.Text = "00"
        Me.TxtCOLUM.Text = "00"

        Try
            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub CBIDALMA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBIDALMA.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.CBIDAREA.Focus()
        End If
    End Sub




    Private Sub CBIDALMA_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBIDALMA.SelectedValueChanged
        Dim cadenaIDALMA As String
        Try
            Me.CBIDAREA.DataSource = Nothing
            Me.CBIDANA.DataSource = Nothing
            If Not CBIDALMA.SelectedValue = Nothing Then
                ObjIngre_Carga_Alma.IDALMA = CBIDALMA.SelectedValue
                cadenaIDALMA = CBIDALMA.SelectedValue
                ObjIngre_Carga_Alma.sp_cb_l_areas(Me.CBIDAREA)
                Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 4) + cadenaIDALMA + "    " + Mid(Me.MBIDINGRE_ANAQUELES.Text, 13, 7)
            End If
            Me.CBIDAREA.SelectedIndex = -1
            Me.CBIDANA.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CBIDAREA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBIDAREA.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.CBIDANA.Focus()
        End If
    End Sub

    Private Sub CBIDAREA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDAREA.SelectedIndexChanged

    End Sub

    Private Sub CBIDAREA_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBIDAREA.SelectedValueChanged
        Dim cadenaIDAREA As String
        Try
            Me.CBIDANA.DataSource = Nothing
            If Not CBIDAREA.SelectedValue = Nothing Then
                ObjIngre_Carga_Alma.IDAREA = CBIDAREA.SelectedValue
                'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
                'ObjIngre_Carga_Alma.sp_cb_l_ANAQUELES(Me.CBIDANA,CNN)
                ObjIngre_Carga_Alma.sp_cb_l_ANAQUELES(Me.CBIDANA)
                '
                cadenaIDAREA = CStr(CBIDAREA.SelectedValue)
                While (Len(cadenaIDAREA.Trim) < 2)
                    cadenaIDAREA = "0" + cadenaIDAREA.Trim
                End While
                Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 6) + cadenaIDAREA.Trim + "  " + Mid(Me.MBIDINGRE_ANAQUELES.Text, 13, 7)
            End If
            Me.CBIDANA.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CBIDANA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBIDANA.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.TxtCOLUM.Focus()
        End If
    End Sub

    Private Sub CBIDANA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDANA.SelectedIndexChanged

    End Sub

    Private Sub CBIDANA_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBIDANA.SelectedValueChanged
        Dim cadenaIDANA As String
        Try
            If Not CBIDANA.SelectedValue = Nothing Then
                ObjIngre_Carga_Alma.IDANA = CBIDANA.SelectedValue
                cadenaIDANA = CBIDANA.SelectedValue
                While (Len(cadenaIDANA.Trim) < 2)
                    cadenaIDANA = "0" + cadenaIDANA
                End While
                Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 9) + cadenaIDANA + Mid(Me.MBIDINGRE_ANAQUELES.Text, 13, 7)
                Try
                    'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
                    'ObjIngre_Carga_Alma.SP_SELEC_T_ALMA_ANAQUELES(cnn)
                    ObjIngre_Carga_Alma.SP_SELEC_T_ALMA_ANAQUELES()
                    Label9.Text = "(C" + CStr(ObjIngre_Carga_Alma.MAX_COLUM) + ",F" + CStr(ObjIngre_Carga_Alma.MAX_FILA) + ")"
                Catch ec As System.Data.OracleClient.OracleException
                    MsgBox("Código: " + ec.Code.ToString + Chr(13) + "Descripción: " + ec.ToString, MsgBoxStyle.Exclamation, "Seguridad del sistema")
                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtCOLUM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCOLUM.GotFocus
        Me.TxtCOLUM.SelectionStart = 0
        Me.TxtCOLUM.SelectionLength = Len(TxtCOLUM.Text)


    End Sub

    Private Sub TxtCOLUM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCOLUM.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.TxtFILA.Focus()
        End If

        'Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        'KeyAscii = CShort(objValida.SoloNumeros(KeyAscii))
        'If KeyAscii = 0 Then
        '    e.Handled = True
        'End If

    End Sub

    Private Sub TxtCOLUM_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCOLUM.LostFocus
        Dim cadenas As String
        cadenas = TxtCOLUM.Text.Trim
        While (Len(cadenas) < 2)
            cadenas = "0" + cadenas
        End While
        Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 12) + cadenas + Mid(Me.MBIDINGRE_ANAQUELES.Text, 15, 5)
    End Sub

    Private Sub TxtCOLUM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCOLUM.TextChanged


    End Sub

    Private Sub TxtFILA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFILA.GotFocus

        Me.TxtFILA.SelectionStart = 0
        Me.TxtFILA.SelectionLength = Len(TxtFILA.Text)
    End Sub

    Private Sub TxtFILA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFILA.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.TxtCODIGO_BARRA.Focus()
        End If
        'Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        'KeyAscii = CShort(objValida.SoloNumeros(KeyAscii))
        'If KeyAscii = 0 Then
        '    e.Handled = True
        'End If

    End Sub

    Private Sub TxtFILA_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFILA.LostFocus
        Dim cadenas As String
        cadenas = TxtFILA.Text.Trim
        While (Len(cadenas) < 2)
            cadenas = "0" + cadenas
        End While
        Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 15) + cadenas + Mid(Me.MBIDINGRE_ANAQUELES.Text, 18, 2)
    End Sub

    Private Sub TxtFILA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFILA.TextChanged

    End Sub
    Private Sub Grabar()

        poner_ceros_solamente()

        If ObjValida.NO_SELECCIONADO_ITEM(Me.CBIDAGENCIAS, Me) = False Then Exit Sub
        If ObjValida.NO_SELECCIONADO_ITEM(Me.CBIDALMA, Me) = False Then Exit Sub
        If ObjValida.NO_SELECCIONADO_ITEM(Me.CBIDAREA, Me) = False Then Exit Sub
        If ObjValida.NO_SELECCIONADO_ITEM(Me.CBIDANA, Me) = False Then Exit Sub


        If ObjValida.NUMERO_NO_CERO(Me.TxtCOLUM, Me) = False Then Exit Sub
        If ObjValida.NUMERO_NO_NEGATIVO(Me.TxtCOLUM, Me) = False Then Exit Sub
        If ObjValida.NUMERO_ENTERO(Me.TxtCOLUM, Me) = False Then Exit Sub

        If ObjValida.NUMERO_NO_CERO(Me.TxtFILA, Me) = False Then Exit Sub
        If ObjValida.NUMERO_NO_NEGATIVO(Me.TxtFILA, Me) = False Then Exit Sub
        If ObjValida.NUMERO_ENTERO(Me.TxtFILA, Me) = False Then Exit Sub
        If TxtCOLUM.Text > ObjIngre_Carga_Alma.MAX_COLUM Then
            MsgBox("La COLUMNA no puede ser mayor que la COLUMNA máxima del Anaquel", MsgBoxStyle.Exclamation, "Seguridad del sistema")
            Exit Sub
        End If
        If TxtFILA.Text > ObjIngre_Carga_Alma.MAX_FILA Then
            MsgBox("La FILA no puede ser mayor que la FILA máxima del Anaquel", MsgBoxStyle.Exclamation, "Seguridad del sistema")
            Exit Sub
        End If

        Dim numero_a_validar As String



        numero_a_validar = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 3) + _
        Mid(Me.MBIDINGRE_ANAQUELES.Text, 5, 1) + _
        Mid(Me.MBIDINGRE_ANAQUELES.Text, 7, 2) + _
        Mid(Me.MBIDINGRE_ANAQUELES.Text, 10, 2) + _
        Mid(Me.MBIDINGRE_ANAQUELES.Text, 13, 2) + _
        Mid(Me.MBIDINGRE_ANAQUELES.Text, 16, 2) + _
        Mid(Me.MBIDINGRE_ANAQUELES.Text, 19, 1)

        MBIDINGRE_ANAQUELES.Text = Mid(MBIDINGRE_ANAQUELES.Text, 1, Len(MBIDINGRE_ANAQUELES.Text) - 1) + CStr(ObjValida.recupera_digto_checkeo(numero_a_validar))

        If Not IsNumeric(Mid(Me.MBIDINGRE_ANAQUELES.Text, Len(Me.MBIDINGRE_ANAQUELES.Text), 1)) Then
            MsgBox("El digito de checkeo es incorrecto...", MsgBoxStyle.Exclamation, "Seguridad del sistema...")
            Exit Sub
        End If

        numero_a_validar = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 3) + _
       Mid(Me.MBIDINGRE_ANAQUELES.Text, 5, 1) + _
       Mid(Me.MBIDINGRE_ANAQUELES.Text, 7, 2) + _
       Mid(Me.MBIDINGRE_ANAQUELES.Text, 10, 2) + _
       Mid(Me.MBIDINGRE_ANAQUELES.Text, 13, 2) + _
       Mid(Me.MBIDINGRE_ANAQUELES.Text, 16, 2) + _
       Mid(Me.MBIDINGRE_ANAQUELES.Text, 19, 1)

        'If objValida.valida_digto_checkeo(numero_a_validar) = False Then
        '    MsgBox("El digito de checkeo es incorrecto...", MsgBoxStyle.Exclamation, "Seguridad del sistema...")
        '    Exit Sub
        'End If



        Try
            With ObjIngre_Carga_Alma
                .IDAGENCIAS = Me.CBIDAGENCIAS.SelectedValue
                .IDALMA = Me.CBIDALMA.SelectedValue
                .IDAREA = Me.CBIDAREA.SelectedValue
                .IDANA = Me.CBIDANA.SelectedValue
                .CODIGO_BARRA = Me.TxtCODIGO_BARRA.Text
                .COLUM = Me.TxtCOLUM.Text
                .FILA = Me.TxtFILA.Text
                .IDUSUARIO_PERSONAL = dtoUSUARIOS.iIDUSUARIO_PERSONAL
                .IDUSUARIO_PERSONAL_MOD = dtoUSUARIOS.iIDUSUARIO_PERSONAL
                .IP = dtoUSUARIOS.IP
                .IPMOD = dtoUSUARIOS.IP
                .FECHA_REGISTRO = "NULL"
                .FECHA_ACTUALIZACION = "NULL"
                .IDROL = dtoUSUARIOS.m_iIdRol
                .IDROL_MOD = dtoUSUARIOS.m_iIdRol
                .IDESTADO_REGISTRO = 1  'Por defecto estará activo 
                'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
                '.SP_IN_T_INGRE_ANAQUELES(cnn)
                .SP_IN_T_INGRE_ANAQUELES()
            End With

            Me.TxtCOLUM.SelectionStart = 0
            Me.TxtCOLUM.SelectionLength = Len(TxtCOLUM.Text)


            Me.TxtFILA.SelectionStart = 0
            Me.TxtFILA.SelectionLength = Len(TxtFILA.Text)

            TxtCOLUM.Focus()

            Me.TxtCODIGO_BARRA.Text = ""

        Catch ec As System.Data.OracleClient.OracleException
            MsgBox("Código: " + ec.Code.ToString + Chr(13) + "Descripción: " + ec.ToString, MsgBoxStyle.Exclamation, "Seguridad del sistema")


        End Try

    End Sub

    Private Sub MBIDINGRE_ANAQUELES_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MBIDINGRE_ANAQUELES.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(objValida.NingunDato(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub MBIDINGRE_ANAQUELES_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MBIDINGRE_ANAQUELES.KeyDown
        If e.KeyCode = Keys.Enter Then

            Me.TxtCODIGO_BARRA.Focus()

        End If
    End Sub

    Private Sub MBIDINGRE_ANAQUELES_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles MBIDINGRE_ANAQUELES.MaskInputRejected

    End Sub

    Private Sub FrmIngreAnaBulto_MenuGrabar() Handles Me.MenuGrabar
        grabar()
    End Sub

    Private Sub TxtCODIGO_BARRA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCODIGO_BARRA.GotFocus

        Me.TxtCODIGO_BARRA.SelectionStart = 0
        Me.TxtCODIGO_BARRA.SelectionLength = Len(TxtCODIGO_BARRA.Text)
    End Sub

    Private Sub TxtCODIGO_BARRA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCODIGO_BARRA.KeyPress
        If e.KeyChar = Chr(13) Then
            grabar()
        End If
    End Sub
    Private Sub TabMante_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabMante.SelectedIndexChanged
        'Select Case TabMante.SelectedIndex
        '    Case 0


        '        Me.Height = 548
        '        Me.Width = 843

        '        Panel1.Left = 5
        '        Panel1.Top = 8

        '        Panel1.Width = 824
        '        Panel1.Height = 420

        '    Case 1


        '        Me.Height = 548
        '        Me.Width = 843

        '        Panel1.Left = 5
        '        Panel1.Top = 8

        '        Panel1.Width = 824
        '        Panel1.Height = 420

        'End Select
    End Sub
    Private Sub cambiartamanio()
        'Me.Height = 548
        'Me.Width = 843

        'Panel1.Left = 5
        'Panel1.Top = 8

        'Panel1.Width = 824
        'Panel1.Height = 420


    End Sub
    Sub FORMAT_GRILLA1()
        dgv1.Columns.Clear()

        With dgv1
            '.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            '.Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = dv_SELEC_VENTA_UBICA
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim CODI_UBI As New DataGridViewTextBoxColumn
        With CODI_UBI
            .HeaderText = "Ubicación"
            .Name = "CODI_UBI"
            .DataPropertyName = "CODI_UBI"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim CODI_BARRA As New DataGridViewTextBoxColumn
        With CODI_BARRA
            .HeaderText = "Cód. Barra"
            .Name = "CODIGO_BARRA"
            .DataPropertyName = "CODIGO_BARRA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ALMA As New DataGridViewTextBoxColumn
        With ALMA
            .HeaderText = "Almacén"
            .Name = "ALMA"
            .DataPropertyName = "ALMA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim AREA As New DataGridViewTextBoxColumn
        With AREA
            .HeaderText = "Area"
            .Name = "AREA"
            .DataPropertyName = "AREA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ANA As New DataGridViewTextBoxColumn
        With ANA
            .HeaderText = "Anaquel"
            .Name = "ANA"
            .DataPropertyName = "ANA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim COLUM As New DataGridViewTextBoxColumn
        With COLUM
            .HeaderText = "Colum."
            .Name = "COLUM"
            .DataPropertyName = "COLUM"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
        End With
        Dim FILA As New DataGridViewTextBoxColumn
        With FILA
            .HeaderText = "Fila"
            .Name = "FILA"
            .DataPropertyName = "FILA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
        End With
        With dgv1
            .Columns.AddRange(CODI_UBI, CODI_BARRA, ALMA, AREA, ANA, COLUM, FILA)
        End With
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        Me.dgv1.DataSource = Nothing
        ObjIngre_Carga_Alma.SERIE_FACTURA = IIf(Mid(Me.MTBNro_factura.Text, 1, 3).Trim = "", 0, Mid(Me.MTBNro_factura.Text, 1, 3))
        ObjIngre_Carga_Alma.NRO_FACTURA = IIf(Mid(Me.MTBNro_factura.Text, 5, 10).Trim = "", 0, Mid(Me.MTBNro_factura.Text, 5, 13))
        ObjIngre_Carga_Alma.IDTIPO_COMPROBANTE = Me.cbidtipo_comprobante.SelectedValue
        'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
        'dvDATOS_PERSONA = ObjIngre_Carga_Alma.SP_SELEC_VENTA(cnn)
        dvDATOS_PERSONA = ObjIngre_Carga_Alma.SP_SELEC_VENTA()


        If dvDATOS_PERSONA.Table.Rows.Count > 0 Then
            If Not dvDATOS_PERSONA.Table.Rows(0).IsNull("RAZON_SOCIAL") Then lrazon_social.Text = dvDATOS_PERSONA.Table.Rows(0)("RAZON_SOCIAL") Else lrazon_social.Text = ""
            If Not dvDATOS_PERSONA.Table.Rows(0).IsNull("NOMBRES") Then LNOMBRES.Text = dvDATOS_PERSONA.Table.Rows(0)("NOMBRES") Else LNOMBRES.Text = ""
            If Not dvDATOS_PERSONA.Table.Rows(0).IsNull("NOMBRE_AGENCIA") Then LNOMBRE_AGENCIA.Text = dvDATOS_PERSONA.Table.Rows(0)("NOMBRE_AGENCIA") Else LNOMBRE_AGENCIA.Text = ""
            If Not dvDATOS_PERSONA.Table.Rows(0).IsNull("NOMBRE_AGENCIA_DESTI") Then LNOMBRE_AGENCIA_DESTI.Text = dvDATOS_PERSONA.Table.Rows(0)("NOMBRE_AGENCIA_DESTI") Else LNOMBRE_AGENCIA_DESTI.Text = ""
            If Not dvDATOS_PERSONA.Table.Rows(0).IsNull("FECHA_LLEGADA") Then lfecha_llegada.Text = dvDATOS_PERSONA.Table.Rows(0)("FECHA_LLEGADA") Else lfecha_llegada.Text = ""
            If Not dvDATOS_PERSONA.Table.Rows(0).IsNull("NRO_UNIDAD_TRANSPORTE") Then lnro_unidad_transporte.Text = dvDATOS_PERSONA.Table.Rows(0)("NRO_UNIDAD_TRANSPORTE") Else lnro_unidad_transporte.Text = ""
            If Not dvDATOS_PERSONA.Table.Rows(0).IsNull("TOTAL_PESO") Then ltotal_peso.Text = dvDATOS_PERSONA.Table.Rows(0)("TOTAL_PESO") Else ltotal_peso.Text = ""
            If Not dvDATOS_PERSONA.Table.Rows(0).IsNull("TOTAL_VOLUMEN") Then ltotal_volumen.Text = dvDATOS_PERSONA.Table.Rows(0)("TOTAL_VOLUMEN") Else ltotal_volumen.Text = ""
            If Not dvDATOS_PERSONA.Table.Rows(0).IsNull("CANTIDAD_SOBRES") Then Me.lnro_sobres.Text = dvDATOS_PERSONA.Table.Rows(0)("CANTIDAD_SOBRES") Else Me.lnro_sobres.Text = ""
            If Not dvDATOS_PERSONA.Table.Rows(0).IsNull("BULTOS") Then ltotal_bultos.Text = dvDATOS_PERSONA.Table.Rows(0)("BULTOS") Else ltotal_bultos.Text = ""



            ObjIngre_Carga_Alma.IDFACTURA = dvDATOS_PERSONA.Table.Rows(0)("idfactura")

            dv_SELEC_VENTA_UBICA = New DataView
            'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
            'dv_SELEC_VENTA_UBICA = ObjIngre_Carga_Alma.SP_SELEC_VENTA_UBICA(cnn)
            dv_SELEC_VENTA_UBICA = ObjIngre_Carga_Alma.SP_SELEC_VENTA_UBICA()
'
            FORMAT_GRILLA1()


        Else
            lrazon_social.Text = ""
            LNOMBRES.Text = ""
            LNOMBRE_AGENCIA.Text = ""
            LNOMBRE_AGENCIA_DESTI.Text = ""
            lfecha_llegada.Text = ""
            lnro_unidad_transporte.Text = ""
            ltotal_peso.Text = ""
            ltotal_volumen.Text = ""
            Me.lnro_sobres.Text = ""
            ltotal_bultos.Text = ""
        End If

    End Sub
    Private Sub MBIDINGRE_ANAQUELES_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MBIDINGRE_ANAQUELES.TextChanged
        Me.TxtCOLUM.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 13, 2)
        If Len(Me.TxtCOLUM.Text.Trim) = 0 Then
            Me.TxtCOLUM.Text = "00"
        End If
        Me.TxtFILA.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 16, 2)
        If Len(Me.TxtFILA.Text.Trim) = 0 Then
            Me.TxtFILA.Text = "00"
        End If
    End Sub
    Private Sub poner_ceros()
        Dim cadena As String, cadena_principal As String

        cadena_principal = Me.MBIDINGRE_ANAQUELES.Text

        'cadena = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 3)
        cadena = Me.CBIDAGENCIAS.SelectedValue
        While Len(cadena.Trim) < 3
            cadena = "0" + cadena.Trim
        End While
        Me.MBIDINGRE_ANAQUELES.Text = cadena + Mid(Me.MBIDINGRE_ANAQUELES.Text, 4, 16)



        cadena = Mid(cadena_principal, 5, 1)
        While Len(cadena.Trim) < 1
            cadena = "0" + cadena.Trim
        End While
        Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 4) + cadena + Mid(Me.MBIDINGRE_ANAQUELES.Text, 6, 14)



        cadena = Mid(cadena_principal, 7, 2)
        While Len(cadena.Trim) < 2
            cadena = "0" + cadena.Trim
        End While
        Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 6) + cadena + Mid(Me.MBIDINGRE_ANAQUELES.Text, 9, 11)



        cadena = Mid(cadena_principal, 10, 2)
        While Len(cadena.Trim) < 2
            cadena = "0" + cadena.Trim
        End While
        Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 9) + cadena + Mid(Me.MBIDINGRE_ANAQUELES.Text, 12, 8)



        cadena = Mid(cadena_principal, 13, 2)
        While Len(cadena.Trim) < 2
            cadena = "0" + cadena.Trim
        End While
        Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 12) + cadena + Mid(Me.MBIDINGRE_ANAQUELES.Text, 15, 5)



        cadena = Mid(cadena_principal, 16, 2)
        While Len(cadena.Trim) < 2
            cadena = "0" + cadena.Trim
        End While
        Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 15) + cadena + Mid(Me.MBIDINGRE_ANAQUELES.Text, 18, 2)



        cadena = Mid(cadena_principal, 19, 1)
        Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 18) + cadena


        Me.CBIDALMA.SelectedIndex = -1
        Me.CBIDAREA.SelectedIndex = -1
        Me.CBIDANA.SelectedIndex = -1

        Dim LngCodigo As Long
        cadena_principal = Me.MBIDINGRE_ANAQUELES.Text
        Try
            Me.CBIDAREA.DataSource = Nothing
            Me.CBIDANA.DataSource = Nothing
            LngCodigo = CLng(Mid(cadena_principal, 5, 1))
            CBIDALMA.SelectedValue = LngCodigo
            If Not CBIDALMA.SelectedValue = Nothing Then
                ObjIngre_Carga_Alma.IDALMA = CBIDALMA.SelectedValue
                ObjIngre_Carga_Alma.sp_cb_l_areas(Me.CBIDAREA)
                'Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 4) + CStr(CBIDALMA.SelectedValue) + Mid(Me.MBIDINGRE_ANAQUELES.Text, 6, 12)
            End If
        Catch ex As Exception

        End Try


        Me.CBIDANA.DataSource = Nothing
        LngCodigo = CLng(Mid(cadena_principal, 7, 2))
        CBIDAREA.SelectedValue = LngCodigo
        Try
            If Not CBIDAREA.SelectedValue = Nothing Then
                ObjIngre_Carga_Alma.IDAREA = CBIDAREA.SelectedValue
                'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
                'ObjIngre_Carga_Alma.sp_cb_l_ANAQUELES(Me.CBIDANA, cnn)
                ObjIngre_Carga_Alma.sp_cb_l_ANAQUELES(Me.CBIDANA)
                '
                'Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 6) + CStr(CBIDAREA.SelectedValue) + Mid(Me.MBIDINGRE_ANAQUELES.Text, 9, 8)
            End If
        Catch ex As Exception

        End Try


        LngCodigo = CLng(Mid(cadena_principal, 10, 2))
        CBIDANA.SelectedValue = LngCodigo
        Try
            If Not CBIDANA.SelectedValue = Nothing Then
                ObjIngre_Carga_Alma.IDANA = CBIDANA.SelectedValue
                'Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 9) + CStr(CBIDANA.SelectedValue) + Mid(Me.MBIDINGRE_ANAQUELES.Text, 13, 5)
                Try
                    'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
                    'ObjIngre_Carga_Alma.SP_SELEC_T_ALMA_ANAQUELES(cnn)
                    ObjIngre_Carga_Alma.SP_SELEC_T_ALMA_ANAQUELES()
                    '
                    Label9.Text = "(C" + CStr(ObjIngre_Carga_Alma.MAX_COLUM) + ",F" + CStr(ObjIngre_Carga_Alma.MAX_FILA) + ")"
                Catch ec As System.Data.OracleClient.OracleException
                    MsgBox("Código: " + ec.Code.ToString + Chr(13) + "Descripción: " + ec.ToString, MsgBoxStyle.Exclamation, "Seguridad del sistema")
                End Try
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub poner_ceros_solamente()
        Dim cadena As String, cadena_principal As String

        cadena_principal = Me.MBIDINGRE_ANAQUELES.Text

        'cadena = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 3)
        cadena = Me.CBIDAGENCIAS.SelectedValue
        While Len(cadena.Trim) < 3
            cadena = "0" + cadena.Trim
        End While
        Me.MBIDINGRE_ANAQUELES.Text = cadena + Mid(Me.MBIDINGRE_ANAQUELES.Text, 4, 16)



        cadena = Mid(cadena_principal, 5, 1)
        Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 4) + cadena + Mid(Me.MBIDINGRE_ANAQUELES.Text, 6, 14)



        cadena = Mid(cadena_principal, 7, 2)
        While Len(cadena.Trim) < 2
            cadena = "0" + cadena.Trim
        End While
        Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 6) + cadena + Mid(Me.MBIDINGRE_ANAQUELES.Text, 9, 11)



        cadena = Mid(cadena_principal, 10, 2)
        While Len(cadena.Trim) < 2
            cadena = "0" + cadena.Trim
        End While
        Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 9) + cadena + Mid(Me.MBIDINGRE_ANAQUELES.Text, 12, 8)



        cadena = Mid(cadena_principal, 13, 2)
        While Len(cadena.Trim) < 2
            cadena = "0" + cadena.Trim
        End While
        Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 12) + cadena + Mid(Me.MBIDINGRE_ANAQUELES.Text, 15, 5)



        cadena = Mid(cadena_principal, 16, 2)
        While Len(cadena.Trim) < 2
            cadena = "0" + cadena.Trim
        End While
        Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 15) + cadena + Mid(Me.MBIDINGRE_ANAQUELES.Text, 18, 2)



        cadena = Mid(cadena_principal, 19, 1)
        Me.MBIDINGRE_ANAQUELES.Text = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 18) + cadena




    End Sub
    Private Sub MBIDINGRE_ANAQUELES_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MBIDINGRE_ANAQUELES.LostFocus

        poner_ceros()

        Dim numero_a_validar As String = Mid(Me.MBIDINGRE_ANAQUELES.Text, 1, 3) + _
        Mid(Me.MBIDINGRE_ANAQUELES.Text, 5, 1) + _
        Mid(Me.MBIDINGRE_ANAQUELES.Text, 7, 2) + _
        Mid(Me.MBIDINGRE_ANAQUELES.Text, 10, 2) + _
        Mid(Me.MBIDINGRE_ANAQUELES.Text, 13, 2) + _
        Mid(Me.MBIDINGRE_ANAQUELES.Text, 16, 2) + _
        Mid(Me.MBIDINGRE_ANAQUELES.Text, 19, 1)

        MBIDINGRE_ANAQUELES.Text = Mid(MBIDINGRE_ANAQUELES.Text, 1, Len(MBIDINGRE_ANAQUELES.Text) - 1) + CStr(objValida.recupera_digto_checkeo(numero_a_validar))



    End Sub


    Private Sub CBIDALMA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDALMA.SelectedIndexChanged

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDAREA1.SelectedIndexChanged

    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click

    End Sub

    Private Sub CBIDAGENCIAS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDAGENCIAS.SelectedIndexChanged

    End Sub

    Private Sub CBIDALMA1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDALMA1.SelectedIndexChanged

    End Sub

    Private Sub CBIDALMA1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBIDALMA1.SelectedValueChanged
        Try
            Me.CBIDAREA1.DataSource = Nothing
            Me.CBIDANA1.DataSource = Nothing
            If Not CBIDALMA1.SelectedValue = Nothing Then
                ObjIngre_Carga_Alma.IDALMA = CBIDALMA1.SelectedValue
                'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
                ObjIngre_Carga_Alma.sp_cb_l_areas_TODOS(Me.CBIDAREA1)
            End If
            Me.CBIDAREA1.SelectedIndex = -1
            Me.CBIDANA1.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CBIDAREA1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBIDAREA1.SelectedValueChanged
        Try
            Me.CBIDANA1.DataSource = Nothing
            If Not CBIDAREA1.SelectedValue = Nothing Then
                ObjIngre_Carga_Alma.IDAREA = CBIDAREA1.SelectedValue
                'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
                ObjIngre_Carga_Alma.sp_cb_l_ANAQUELES_TODOS(Me.CBIDANA1)
            End If
            Me.CBIDANA1.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCargarClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarClientes.Click
        If Not IsNothing(Me.CBIDAGENCIAS1.SelectedValue) Then
            ObjIngre_Carga_Alma.IDAGENCIAS = Me.CBIDAGENCIAS1.SelectedValue
        Else
            ObjIngre_Carga_Alma.IDAGENCIAS = 0
        End If

        If Not IsNothing(Me.CBIDALMA1.SelectedValue) Then
            ObjIngre_Carga_Alma.IDALMA = Me.CBIDALMA1.SelectedValue
        Else
            ObjIngre_Carga_Alma.IDALMA = 0
        End If

        If Not IsNothing(Me.CBIDANA1.SelectedValue) Then
            ObjIngre_Carga_Alma.IDANA = Me.CBIDANA1.SelectedValue
        Else
            ObjIngre_Carga_Alma.IDANA = 0
        End If
        If Not IsNothing(Me.CBIDAREA1.SelectedValue) Then
            ObjIngre_Carga_Alma.IDAREA = Me.CBIDAREA1.SelectedValue
        Else
            ObjIngre_Carga_Alma.IDAREA = 0
        End If

        'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
        'dgv2.DataSource = ObjIngre_Carga_Alma.SP_RECU_INGRE_ALMA(cnn)
        dgv2.DataSource = ObjIngre_Carga_Alma.SP_RECU_INGRE_ALMA()
        format2()

    End Sub
    Private Sub format2()
        dgv2.Columns.Clear()

        With dgv2
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            '.DataSource = dv_SELEC_VENTA_UBICA
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        Dim NRO_FACTURA As New DataGridViewTextBoxColumn
        With NRO_FACTURA
            .HeaderText = "Nro. Documento"
            .Name = "NRO_FACTURA"
            .DataPropertyName = "NRO_FACTURA"
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim FECHA As New DataGridViewTextBoxColumn
        With FECHA
            .HeaderText = "FECHA"
            .Name = "FECHA_FACTURA"
            .DataPropertyName = "FECHA_FACTURA"
            .Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim CODI_UBI As New DataGridViewTextBoxColumn
        With CODI_UBI
            .HeaderText = "Ubicación"
            .Name = "CODI_UBI"
            .DataPropertyName = "CODI_UBI"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim CODI_BARRA As New DataGridViewTextBoxColumn
        With CODI_BARRA
            .HeaderText = "Cód. Barra"
            .Name = "CODIGO_BARRA"
            .DataPropertyName = "CODIGO_BARRA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ALMA As New DataGridViewTextBoxColumn
        With ALMA
            .HeaderText = "Almacén"
            .Name = "ALMA"
            .DataPropertyName = "ALMA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim AREA As New DataGridViewTextBoxColumn
        With AREA
            .HeaderText = "Area"
            .Name = "AREA"
            .DataPropertyName = "AREA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ANA As New DataGridViewTextBoxColumn
        With ANA
            .HeaderText = "Anaquel"
            .Name = "ANA"
            .DataPropertyName = "ANA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim COLUM As New DataGridViewTextBoxColumn
        With COLUM
            .HeaderText = "Colum."
            .Name = "COLUM"
            .DataPropertyName = "COLUM"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
        End With
        Dim FILA As New DataGridViewTextBoxColumn
        With FILA
            .HeaderText = "Fila"
            .Name = "FILA"
            .DataPropertyName = "FILA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0"
            .ReadOnly = True
        End With
        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "RAZON_SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim nombre_agencia_ori As New DataGridViewTextBoxColumn
        With nombre_agencia_ori
            .HeaderText = "Agencia Origen"
            .Name = "nombre_agencia_ori"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "nombre_agencia_ori"
            .Width = 150
            .ReadOnly = True
        End With
        Dim nombre_agencia_desti As New DataGridViewTextBoxColumn
        With nombre_agencia_desti
            .HeaderText = "Agencia Destino"
            .Name = "nombre_agencia_desti"
            .Width = 150
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "nombre_agencia_desti"

            .ReadOnly = True
        End With
        Dim nombres As New DataGridViewTextBoxColumn
        With nombres
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "Consignado"
            .Name = "nombres"
            .DataPropertyName = "nombres"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        'tipo_comprobante
        Dim tipo_comprobante As New DataGridViewTextBoxColumn
        With tipo_comprobante
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "Tipo Comprobante"
            .Name = "tipo_comprobante"
            .DataPropertyName = "tipo_comprobante"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        '08/08/2009 - Agrega campos  'Fecha Registro  
        Dim Fecha_Registro As New DataGridViewTextBoxColumn
        With Fecha_Registro
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "Fecha Registro"
            .Name = "Fecha_Registro"
            .DataPropertyName = "Fecha_Registro"
            '.Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        '
        Dim cantidad_total As New DataGridViewTextBoxColumn
        With cantidad_total
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "Cant. Total"
            .Name = "cantidad_total"
            .DataPropertyName = "cantidad_total"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
        End With
        '       
        Dim total_peso As New DataGridViewTextBoxColumn
        With total_peso
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "Tot. Peso"
            .Name = "total_peso"
            .DataPropertyName = "total_peso"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
        End With
        '
        Dim total_costo As New DataGridViewTextBoxColumn
        With total_costo
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "Tot. Costo"
            .Name = "total_costo"
            .DataPropertyName = "total_costo"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
        End With
        '
        Dim tipo_entrega As New DataGridViewTextBoxColumn
        With tipo_entrega
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "Tipo Entrega"
            .Name = "tipo_entrega"
            .DataPropertyName = "tipo_entrega"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ReadOnly = True
        End With
        '
        Dim direccion_consignado As New DataGridViewTextBoxColumn
        With direccion_consignado
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "Dir. Consignado"
            .Name = "direccion_consignado"
            .DataPropertyName = "direccion_consignado"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ReadOnly = True
        End With
        '
        Dim descripcion As New DataGridViewTextBoxColumn
        With descripcion
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "Descripción"
            .Name = "descripcion"
            .DataPropertyName = "descripcion"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ReadOnly = True
        End With
        '
        Dim telefono As New DataGridViewTextBoxColumn
        With telefono
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "telefono"
            .Name = "telefono"
            .DataPropertyName = "telefono"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
        End With
        '
        Dim ciudad_ori_iata As New DataGridViewTextBoxColumn
        With ciudad_ori_iata
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "Origen"
            .Name = "ciudad_ori_iata"
            .DataPropertyName = "ciudad_ori_iata"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
        End With
        '
        Dim ciudad_des_iata As New DataGridViewTextBoxColumn
        With ciudad_des_iata
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "Destino"
            .Name = "ciudad_des_iata"
            .DataPropertyName = "ciudad_des_iata"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .ReadOnly = True
        End With
        '
        With dgv2
            .Columns.AddRange(nombre_agencia_desti, nombre_agencia_ori, RAZON_SOCIAL, nombres, FECHA, tipo_comprobante, ciudad_ori_iata, ciudad_des_iata, NRO_FACTURA, direccion_consignado, telefono, CODI_UBI, CODI_BARRA, ALMA, AREA, ANA, COLUM, FILA, Fecha_Registro, cantidad_total, total_peso, total_costo, descripcion)
        End With





        'With dgv2
        '    .Columns.AddRange(nombre_agencia_desti, nombre_agencia_ori, RAZON_SOCIAL, nombres, FECHA, tipo_comprobante, NRO_FACTURA, direccion_consignado, telefono, CODI_UBI, CODI_BARRA, ALMA, AREA, ANA, COLUM, FILA, Fecha_Registro, cantidad_total, total_peso, total_costo, descripcion)
        'End With
    End Sub

    Private Sub CBIDAGENCIAS1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDAGENCIAS1.SelectedIndexChanged

    End Sub

    Private Sub TabLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabLista.Click

    End Sub

    Private Sub TxtCODIGO_BARRA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCODIGO_BARRA.TextChanged

    End Sub

    Private Sub BIMPRI_ETI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BIMPRI_ETI.Click
        If validar() = False Then Exit Sub
        '
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
            'prn.Nombre_impresora = "\\mvara\PRNZEBRA"
            prn.Nombre_impresora = "PRNZEBRA"
            Dim EXISTE As Boolean = prn.SetearImpresora()
            '
            Dim prn_idagencias As String
            Dim prn_idalma As String
            Dim prn_idarea As String
            Dim prn_idana As String
            Dim prn_fila As String
            Dim prn_colum As String

            prn_idagencias = Me.CBIDAGENCIAS2.SelectedValue
            prn_idagencias = prn_idagencias.ToString.Trim
            While Len(prn_idagencias) < 3
                prn_idagencias = "0" + prn_idagencias
            End While
            '
            prn_idalma = Me.CBIDALMA2.SelectedValue
            prn_idalma = prn_idalma.ToString.Trim
            '
            prn_idarea = Me.CBIDAREA2.SelectedValue
            prn_idarea = prn_idarea.ToString.Trim
            While Len(prn_idarea) < 2
                prn_idarea = "0" + prn_idarea
            End While
            '
            prn_idana = Me.CBIDANA2.SelectedValue
            prn_idana = prn_idana.ToString.Trim
            While Len(prn_idana) < 2
                prn_idana = "0" + prn_idana
            End While
            '
            ObjIngre_Carga_Alma.IDANA = Me.CBIDALMA2.SelectedValue
            'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
            ObjIngre_Carga_Alma.SP_SELEC_T_ANAQUELES()
            '
            For i As Integer = CInt(Me.TxtCOLUM_INI.Text) To CInt(Me.TxtCOLUM_FINAL.Text)

                prn_colum = Trim(CStr(i))

                While Len(prn_colum) < 2
                    prn_colum = "0" + prn_colum
                End While
                For j As Integer = Me.txtFILA_INI.Text To Me.TxtFILA_FINAL.Text
                    prn_fila = Trim(CStr(j))
                    While Len(prn_fila) < 2
                        prn_fila = "0" + prn_fila
                    End While
                    Me.imprimir_etiquetas(prn_idagencias + prn_idalma + prn_idarea + prn_idana + prn_colum + prn_fila, _
                 Me.CBIDANA2.Text, _
                Me.CBIDALMA2.Text, _
                 prn_fila, _
                 prn_colum, _
                 Me.CBIDAGENCIAS2.Text)
                Next
            Next
            prn.FinDoc()
        Catch ex As Exception
            flag = False
        End Try
    End Sub
    Function imprimir_etiquetas(ByVal P_CODIGO_BARRA As String, _
    ByVal P_ANAQUEL As String, _
ByVal P_ALMACEN As String, _
ByVal P_FILA As String, _
ByVal P_COLUMNA As String, _
    ByVal P_AGENCIA As String)
        Dim flag As Boolean = True


        Try
            Dim xIMPRESORA As Integer
            xIMPRESORA = fnSeleccionImpresion()

            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.fnGetHora()
            prn.Nombre_impresora = "PRNZEBRA"

            Dim EXISTE As Boolean = prn.SetearImpresora()
            'Dim SQLQuery As Object() = {"select  Valor,anaquel,fila,columna from T_Etiquetas where valor >= '51101060101'", 2}
            'Dim SQLQuery As Object() = {"select  Valor,anaquel,fila,columna from T_Etiquetas where ANAQUEL='F'", 2}

            'Dim SQLQuery As Object() = {"select  Valor,anaquel,fila,columna from T_Etiquetas where valor =  '051101120101'", 2}

            '15/10/2009 - Estaba activo SE COMENTA 
            '
            'Dim SQLQuery As Object() = {"select  Valor,anaquel,fila,columna from T_Etiquetas where valor = '051201010101'", 2}
            'ObjVentaCargaContado.Cur_CODIGOBARRAS = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)

            '*******************************************************
            '******** Codigo de barra de Unicacion Original ********
            '*******************************************************
            'prn.EscribeLinea("<STX><ESC>C0<ETX>")
            'prn.EscribeLinea("<STX><ESC>k<ETX>")
            'prn.EscribeLinea("<STX><SI>N60<ETX>")
            'prn.EscribeLinea("<STX><SI>L197<ETX>")
            'prn.EscribeLinea("<STX><SI>S20<ETX>")
            'prn.EscribeLinea("<STX><SI>d0<ETX>")
            'prn.EscribeLinea("<STX><SI>h0,0;<ETX>")
            'prn.EscribeLinea("<STX><SI>l8<ETX>")
            'prn.EscribeLinea("<STX><SI>I3<ETX>")
            'prn.EscribeLinea("<STX><SI>F20<ETX>")
            'prn.EscribeLinea("<STX><SI>D0<ETX>")
            'prn.EscribeLinea("<STX><SI>t0<ETX>")
            'prn.EscribeLinea("<STX><SI>W394<ETX>")
            'prn.EscribeLinea("<STX><SI>g1,567<ETX>")
            'prn.EscribeLinea("<STX><ESC>P<ETX>")
            'prn.EscribeLinea("<STX>E*;F*;<ETX>")
            'prn.EscribeLinea("<STX>L1;<ETX>")
            'prn.EscribeLinea("<STX>D0;<ETX>")
            'prn.EscribeLinea("<STX>H0;o165,10;f3;c25;h15;w15;d3,AG: " & P_AGENCIA & ";<ETX>")
            'prn.EscribeLinea("<STX>D1;<ETX>")
            'prn.EscribeLinea("<STX>H1;o130,10;f3;c25;h9;w15;d3,ALM: " & P_ALMACEN & "  " & P_FILA & "/" & P_COLUMNA & ";<ETX>")
            'prn.EscribeLinea("<STX>H2;o82,10;f3;c25;h13;w12;d3," & P_ANAQUEL & "  ;<ETX>")
            ''prn.EscribeLinea("<STX>H2;o82,10;f3;c25;h13;w12;d3,Area: " & objCODBARRAALMACEN.v_AREA & "  ;<ETX>")
            'prn.EscribeLinea("<STX>B3;o96,160;f3;c7,0,2;h69;w2;r0;i1;d3," & P_CODIGO_BARRA & ";<ETX>")
            'prn.EscribeLinea("<STX>H4;o14,10;f3;c25;h7;w7;d3," & dtoUSUARIOS.m_sFecha & ";<ETX>")
            'prn.EscribeLinea("<STX>H5;o14,200;f3;c25;h7;w7;d3," & HoraActual & ";<ETX>")
            'prn.EscribeLinea("<STX>H6;o14,300;f3;c25;h7;w7;d3,TEPSAC;<ETX>")
            ''prn.EscribeLinea("<STX>H7;o102,96;f3;c25;h17;w16;d3," & ObjCODIGOBARRA.Destino & ";<ETX>")
            'prn.EscribeLinea("<STX>R<ETX>")
            'prn.EscribeLinea("<STX><ESC>E*<CAN><ETX>")
            'prn.EscribeLinea("<STX><RS>1<US>1<ETB><ETX>")
            'prn.EscribeLinea(cadena)
            '*******************************************************

            If xIMPRESORA = 3 Then
                prn.EscribeLinea("N")
                prn.EscribeLinea("N")
                prn.EscribeLinea("A30,14,0,4,1,1,N,""" & "AGE: " & P_AGENCIA & """")
                prn.EscribeLinea("A30,47,0,4,1,1,N,""" & "ALM: " & P_ALMACEN & "  " & P_FILA & "/" & P_COLUMNA & """")
                'prn.EscribeLinea("A317,47,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
                prn.EscribeLinea("A30,110,0,3,1,1,N,""" & P_ANAQUEL & "-  """)
                prn.EscribeLinea("A30,163,0,1,1,1,N,""" & dtoUSUARIOS.m_sFecha & """")
                prn.EscribeLinea("A321,163,0,1,1,1,N,""TEPSAC""")
                prn.EscribeLinea("A205,163,0,1,1,1,N,""" & HoraActual & """")
                'prn.EscribeLinea("A89,94,0,4,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
                prn.EscribeLinea("B148,83,0,E30,2,2,59,B,""" & P_CODIGO_BARRA & """")
                prn.EscribeLinea("P1")
                prn.EscribeLinea("N")
                prn.EscribeLinea(cadena)
                'ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
                prn.FinDoc()
            ElseIf xIMPRESORA = 1 Or xIMPRESORA = 4 Then
                Dim strEmpresa As String = "TEPSAC"
                prn.EscribeLinea("^XA")
                prn.EscribeLinea("^PW400")
                prn.EscribeLinea("^FT30,34^A0N,28,28^FH\^FD " & "AGE: " & P_AGENCIA & "^FS")
                prn.EscribeLinea("^FT30,67^A0N,28,28^FH\^FD " & "ALM: " & P_ALMACEN & "  " & P_FILA & "/" & P_COLUMNA & "^FS")
                prn.EscribeLinea("^FT30,110^A0N,28,28^FH\^FD " & P_ANAQUEL & " - " & "^FS")
                prn.EscribeLinea("^FT30,200^A0N,28,28^FH\^FD " & dtoUSUARIOS.m_sFecha & "^FS")
                prn.EscribeLinea("^FT321,200^A0N,28,28^FH\^FD " & strEmpresa & "^FS")
                prn.EscribeLinea("^FT205,200^A0N,28,28^FH\^FD " & HoraActual & "^FS")

                'prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & ObjCODIGOBARRA.CodigoBarra & "^FS")
                prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & P_CODIGO_BARRA & "^FS")

                'prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & ObjCODIGOBARRA.CodigoBarra & "^FS")

                prn.EscribeLinea("^PQ1,0,1,Y")
                prn.EscribeLinea("^XZ")
                prn.EscribeLinea(cadena)
            End If

        Catch ex As Exception
            flag = False
        End Try

    End Function

    Private Sub CBIDALMA2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBIDALMA2.SelectedIndexChanged

    End Sub

    Private Sub CBIDALMA2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBIDALMA2.SelectedValueChanged
        Try
            Me.CBIDAREA2.DataSource = Nothing
            Me.CBIDANA2.DataSource = Nothing
            If Not CBIDALMA2.SelectedValue = Nothing Then
                ObjIngre_Carga_Alma.IDALMA = CBIDALMA2.SelectedValue
                'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
                ObjIngre_Carga_Alma.sp_cb_l_areas_TODOS(Me.CBIDAREA2)
            End If
            Me.CBIDAREA2.SelectedIndex = -1
            Me.CBIDANA2.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CBIDAREA2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBIDAREA2.SelectedValueChanged
        Try
            Me.CBIDANA2.DataSource = Nothing
            If Not CBIDAREA2.SelectedValue = Nothing Then
                ObjIngre_Carga_Alma.IDAREA = CBIDAREA2.SelectedValue
                'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
                ObjIngre_Carga_Alma.sp_cb_l_ANAQUELES_TODOS(Me.CBIDANA2)
            End If
            Me.CBIDANA2.SelectedIndex = -1
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CBIDANA2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBIDANA2.SelectedValueChanged

        Try
            If Not CBIDANA2.SelectedValue = Nothing Then
                ObjIngre_Carga_Alma.IDANA = CBIDANA2.SelectedValue

                Try
                    'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
                    'ObjIngre_Carga_Alma.SP_SELEC_T_ALMA_ANAQUELES(cnn)
                    ObjIngre_Carga_Alma.SP_SELEC_T_ALMA_ANAQUELES()
                    '
                    Label34.Text = "(C" + CStr(ObjIngre_Carga_Alma.MAX_COLUM) + ",F" + CStr(ObjIngre_Carga_Alma.MAX_FILA) + ")"
                Catch ec As System.Data.OracleClient.OracleException
                    MsgBox("Código: " + ec.Code.ToString + Chr(13) + "Descripción: " + ec.ToString, MsgBoxStyle.Exclamation, "Seguridad del sistema")
                End Try
            Else
                Label34.Text = ""
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Function validar() As Boolean
        validar = False

        If ObjValida.CB_SELECT_VALUE(Me.CBIDAGENCIAS2, Me) = False Then Exit Function
        If ObjValida.CB_SELECT_VALUE(Me.CBIDALMA2, Me) = False Then Exit Function
        If ObjValida.CB_SELECT_VALUE(Me.CBIDAREA2, Me) = False Then Exit Function
        If ObjValida.CB_SELECT_VALUE(Me.CBIDANA2, Me) = False Then Exit Function

        If ObjValida.NO_BLANCO(Me.TxtCOLUM_INI, Me) = False Then Exit Function
        If ObjValida.NO_BLANCO(Me.TxtCOLUM_FINAL, Me) = False Then Exit Function
        If ObjValida.NO_BLANCO(Me.txtFILA_INI, Me) = False Then Exit Function
        If ObjValida.NO_BLANCO(Me.TxtFILA_FINAL, Me) = False Then Exit Function

        If ObjValida.NUMERO_NO_CERO(Me.TxtCOLUM_INI, Me) = False Then Exit Function
        If ObjValida.NUMERO_NO_CERO(Me.TxtCOLUM_FINAL, Me) = False Then Exit Function
        If ObjValida.NUMERO_NO_CERO(Me.txtFILA_INI, Me) = False Then Exit Function
        If ObjValida.NUMERO_NO_CERO(Me.TxtFILA_FINAL, Me) = False Then Exit Function

        If ObjValida.NUMERO_NO_NEGATIVO(Me.TxtCOLUM_INI, Me) = False Then Exit Function
        If ObjValida.NUMERO_NO_NEGATIVO(Me.TxtCOLUM_FINAL, Me) = False Then Exit Function
        If ObjValida.NUMERO_NO_NEGATIVO(Me.txtFILA_INI, Me) = False Then Exit Function
        If ObjValida.NUMERO_NO_NEGATIVO(Me.TxtFILA_FINAL, Me) = False Then Exit Function

        If ObjValida.NUMERO_ENTERO(Me.TxtCOLUM_INI, Me) = False Then Exit Function
        If ObjValida.NUMERO_ENTERO(Me.TxtCOLUM_FINAL, Me) = False Then Exit Function
        If ObjValida.NUMERO_ENTERO(Me.txtFILA_INI, Me) = False Then Exit Function
        If ObjValida.NUMERO_ENTERO(Me.TxtFILA_FINAL, Me) = False Then Exit Function

        If Not CBIDANA2.SelectedValue = Nothing Then
            ObjIngre_Carga_Alma.IDANA = CBIDANA2.SelectedValue

            Try
                'Mod.13/10/2009 -->Omendoza - Pasando al datahelper -  
                'ObjIngre_Carga_Alma.SP_SELEC_T_ALMA_ANAQUELES(cnn)
                ObjIngre_Carga_Alma.SP_SELEC_T_ALMA_ANAQUELES()
                '
            Catch ec As System.Data.OracleClient.OracleException
                MsgBox("Código: " + ec.Code.ToString + Chr(13) + "Descripción: " + ec.ToString, MsgBoxStyle.Exclamation, "Seguridad del sistema")
            End Try

        End If
        If Me.TxtCOLUM_FINAL.Text > ObjIngre_Carga_Alma.MAX_FILA Then
            MsgBox("El valor no puede ser mayor que el máximo...", MsgBoxStyle.Critical, "Seguridad del Sistema...")
            Me.TxtCOLUM_FINAL.Focus()
            Exit Function
        End If

        If Me.TxtCOLUM_FINAL.Text > ObjIngre_Carga_Alma.MAX_COLUM Then
            MsgBox("El valor no puede ser mayor que el máximo...", MsgBoxStyle.Critical, "Seguridad del Sistema...")
            Me.TxtCOLUM_FINAL.Focus()
            Exit Function
        End If

        If Me.TxtCOLUM_INI.Text > Me.TxtCOLUM_FINAL.Text Then
            MsgBox("El valor inicial no puede ser mayor que el final...", MsgBoxStyle.Critical, "Seguridad del Sistema...")
            Me.TxtCOLUM_INI.Focus()
            Exit Function
        End If

        If Me.txtFILA_INI.Text > Me.TxtFILA_FINAL.Text Then
            MsgBox("El valor inicial puede ser mayor que el final...", MsgBoxStyle.Critical, "Seguridad del Sistema...")
            Me.txtFILA_INI.Focus()
            Exit Function
        End If


        validar = True
    End Function

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub
End Class
