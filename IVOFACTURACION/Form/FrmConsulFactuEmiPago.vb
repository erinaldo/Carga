' Por la manipulación del background 
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Reflection
Imports AccesoDatos
Public Class FrmConsulFactuEmiPago
    Dim dvfacturas_pagos As DataView
    Dim dvListar_facturas As DataView

    Dim DVGUIAS As DataView
    Dim DVPREFACTURAS As DataView
    Dim DVFACTURAS_ As DataView
    Dim DVPAGOS As DataView
    Dim DVCTA_CORRIENTE As DataView
    '
    Dim Colllistar_persona_todos As New Collection
    Dim Iwinlistar_persona_todos As New AutoCompleteStringCollection
    '
    Dim ObjPersona As New ClsLbTepsa.dtoPersona
    Dim objgeneral As New ClsLbTepsa.dtoGENERAL
    '
    Dim dvlistar_persona_todos As New DataView
    Dim dvlistar_tipo_moneda As New DataView
    '
    Dim dvlistar_forma_pago As New DataView
    Dim ill_nro_meses_lc As Long
    '24/04/2009 - Variable de control para que no vuelva a leer la cta corriente 
    Dim lb_lee_cta_corriente As Boolean
    Dim lb_lee_parte_contar As Boolean = False
    Dim lb_lee_campo As Boolean = True
    '
    Private ObjReport As ClsLbTepsa.dtoFrmReport '
    Dim bIngreso As Boolean = False
    Public hnd As Long
#Region "Control TAB"
    Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem

        'Firstly we'll define some parameters.
        'En primer lugar vamos a definir algunos parametros 
        Dim CurrentTab As TabPage = TabControl1.TabPages(e.Index)
        Dim ItemRect As Rectangle = TabControl1.GetTabRect(e.Index)
        Dim FillBrush As New SolidBrush(Color.Transparent) 'SolidBrush(Color.Red)
        Dim TextBrush As New SolidBrush(Color.Black)
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center

        'If we are currently painting the Selected TabItem we'll 
        'change the brush colors and inflate the rectangle.
        'Si en estos momentos la selección de pintura TabItem vamos a cambiar el pincel y los colores 'inflar' en el rectángulo.
        '
        If CBool(e.State And DrawItemState.Selected) Then
            FillBrush.Color = Color.Transparent  'Color.White
            TextBrush.Color = Color.Black        'Color.Red 
            ItemRect.Inflate(2, 2)
        End If

        'Set up rotation for left and right aligned tabs
        '
        'Establecer la rotación de la izquierda y alineado a la derecha pestañas
        '
        If TabControl1.Alignment = TabAlignment.Left Or TabControl1.Alignment = TabAlignment.Right Then
            Dim RotateAngle As Single = 90
            If TabControl1.Alignment = TabAlignment.Left Then RotateAngle = 270
            Dim cp As New PointF(ItemRect.Left + (ItemRect.Width \ 2), ItemRect.Top + (ItemRect.Height \ 2))
            e.Graphics.TranslateTransform(cp.X, cp.Y)
            e.Graphics.RotateTransform(RotateAngle)
            ItemRect = New Rectangle(-(ItemRect.Height \ 2), -(ItemRect.Width \ 2), ItemRect.Height, ItemRect.Width)
        End If

        'Next we'll paint the TabItem with our Fill Brush
        'Siguiente nos TabItem la pintura con pincel, llene nuestro
        e.Graphics.FillRectangle(FillBrush, ItemRect)

        'Now draw the text.
        'Ahora dibuja el texto 
        e.Graphics.DrawString(CurrentTab.Text, e.Font, TextBrush, RectangleF.op_Implicit(ItemRect), sf)

        'Reset any Graphics rotation
        'Restablecer cualquier gráfica rotación
        e.Graphics.ResetTransform()

        'Finally, we should Dispose of our brushes.
        'Finalmente, se debería disponer de nuestros cepillos.
        FillBrush.Dispose()
        TextBrush.Dispose()
    End Sub
#End Region
    '#Region " InterOP "
    '    '<StructLayout(LayoutKind.Sequential)> _
    '    Private Structure NMHDR
    '        Public HWND As Int32
    '        Public idFrom As Int32
    '        Public code As Int32
    '        '
    '        Public Overloads Function ToString() As String
    '            Return String.Format("Hwnd: {0}, ControlID: {1}, Code: {2}", HWND, idFrom, code)
    '        End Function
    '    End Structure

    '    Private Const TCN_FIRST As Int32 = &HFFFFFFFFFFFFFDDA&
    '    Private Const TCN_SELCHANGING As Int32 = (TCN_FIRST - 2)

    '    Private Const WM_USER As Int32 = &H400&
    '    Private Const WM_NOTIFY As Int32 = &H4E&
    '    Private Const WM_REFLECT As Int32 = WM_USER + &H1C00&

    '#End Region
    '#Region "Definicion del fondo"

    '    'BackColor Manipulation 
    '    Private m_Backcolor As Color = Color.Empty


    'As well as exposing the property to the Designer we want it to behave just like any other 
    'controls BackColor property so we need some clever manipulation.
    'Así como la exposición de la propiedad a los que el diseñador desea que se comporte como cualquier otro

    '   <Browsable(True), _
    'Description("The background color used to display text and graphics in a control.") > 
    'El color de fondo usado para mostrar texto y gráficos en un control.'
    'The background color used to display text and graphics in a control.

    '    Public Overrides Property BackColor() As Color
    '        Get
    '            If m_Backcolor.Equals(Color.Empty) Then
    '                If Parent Is Nothing Then
    '                    Return Control.DefaultBackColor
    '                Else
    '                    Return Parent.BackColor
    '                End If
    '            End If
    '            Return m_Backcolor
    '        End Get
    '        Set(ByVal Value As Color)
    '            If m_Backcolor.Equals(Value) Then Return
    '            m_Backcolor = Value
    '            Invalidate()
    '            'Let the Tabpages know that the backcolor has changed.
    '            MyBase.OnBackColorChanged(EventArgs.Empty)
    '        End Set
    '    End Property
    '#End Region


    'Public Delegate Sub SelectedTabPageChangeEventHandler(ByVal sender As Object, ByVal e As TabPageChangeEventArgs)
    'Protected Overrides Sub OnParentBackColorChanged(ByVal e As System.EventArgs)
    '    MyBase.OnParentBackColorChanged(e)
    '    Invalidate()
    'End Sub

    'Protected Overrides Sub OnSelectedIndexChanged(ByVal e As System.EventArgs)
    '    MyBase.OnSelectedIndexChanged(e)
    '    Invalidate()
    'End Sub

    'Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
    '    MyBase.OnPaint(e)
    '    e.Graphics.Clear(BackColor)
    '    Dim r As Rectangle = Me.ClientRectangle
    '    If Me.TabControl1.TabCount <= 0 Then Return
    '    'Draw a custom background for Transparent TabPages
    '    r = Me.TabControl1.SelectedTab.Bounds
    '    Dim sf As New StringFormat
    '    sf.Alignment = StringAlignment.Center
    '    sf.LineAlignment = StringAlignment.Center
    '    Dim DrawFont As New Font(Font.FontFamily, 24, FontStyle.Regular, GraphicsUnit.Pixel)
    '    ControlPaint.DrawStringDisabled(e.Graphics, "Micks Ownerdraw TabControl", DrawFont, BackColor, RectangleF.op_Implicit(r), sf)
    '    DrawFont.Dispose()
    '    'Draw a border around TabPage
    '    r.Inflate(3, 3)
    '    Dim tp As TabPage = Me.TabControl1.TabPages(Me.TabControl1.SelectedIndex)
    '    Dim PaintBrush As New SolidBrush(tp.BackColor)
    '    e.Graphics.FillRectangle(PaintBrush, r)
    '    ControlPaint.DrawBorder(e.Graphics, r, PaintBrush.Color, ButtonBorderStyle.Outset)
    '    'Draw the Tabs
    '    For index As Integer = 0 To Me.TabControl1.TabCount - 1
    '        tp = Me.TabControl1.TabPages(index)
    '        r = Me.TabControl1.GetTabRect(index)
    '        Dim bs As ButtonBorderStyle = ButtonBorderStyle.Outset
    '        If index = Me.TabControl1.SelectedIndex Then bs = ButtonBorderStyle.Inset
    '        PaintBrush.Color = tp.BackColor
    '        e.Graphics.FillRectangle(PaintBrush, r)
    '        ControlPaint.DrawBorder(e.Graphics, r, PaintBrush.Color, bs)
    '        PaintBrush.Color = tp.ForeColor

    '        'Set up rotation for left and right aligned tabs
    '        If Me.TabControl1.Alignment = Me.TabControl1.Alignment.Left Or Me.TabControl1.Alignment = Me.TabControl1.Right Then
    '            Dim RotateAngle As Single = 90
    '            If Me.TabControl1.Alignment = Me.TabControl1.Left Then RotateAngle = 270
    '            Dim cp As New PointF(r.Left + (r.Width \ 2), r.Top + (r.Height \ 2))
    '            e.Graphics.TranslateTransform(cp.X, cp.Y)
    '            e.Graphics.RotateTransform(RotateAngle)
    '            r = New Rectangle(-(r.Height \ 2), -(r.Width \ 2), r.Height, r.Width)
    '        End If
    '        'Draw the Tab Text
    '        If tp.Enabled Then
    '            e.Graphics.DrawString(tp.Text, Font, PaintBrush, RectangleF.op_Implicit(r), sf)
    '        Else
    '            ControlPaint.DrawStringDisabled(e.Graphics, tp.Text, Font, tp.BackColor, RectangleF.op_Implicit(r), sf)
    '        End If

    '        e.Graphics.ResetTransform()

    '    Next
    '    PaintBrush.Dispose()
    'End Sub

    '<Description("Occurs as a tab is being changed.")> _
    'Public Event SelectedIndexChanging As SelectedTabPageChangeEventHandler

    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    '    If m.Msg = (WM_REFLECT + WM_NOTIFY) Then
    '        Dim hdr As NMHDR = DirectCast(Marshal.PtrToStructure(m.LParam, GetType(NMHDR)), NMHDR)
    '        If hdr.code = TCN_SELCHANGING Then
    '            Dim tp As TabPage = TestTab(Me.PointToClient(Cursor.Position))
    '            If Not tp Is Nothing Then
    '                Dim e As New TabPageChangeEventArgs(Me.TabControl1.SelectedTab, tp)
    '                RaiseEvent SelectedIndexChanging(Me, e)
    '                If e.Cancel OrElse tp.Enabled = False Then
    '                    m.Result = New IntPtr(1)
    '                    Return
    '                End If
    '            End If
    '        End If
    '    End If
    '    MyBase.WndProc(m)
    'End Sub

    'Private Function TestTab(ByVal pt As Point) As TabPage
    '    For index As Integer = 0 To Me.TabControl1.TabCount - 1
    '        If Me.TabControl1.GetTabRect(index).Contains(pt.X, pt.Y) Then
    '            Return Me.TabControl1.TabPages(index)
    '        End If
    '    Next
    '    Return Nothing
    'End Function


    Private Sub contar()
        Try
            'If Not dvListar_facturas Is Nothing Then
            '    Me.lblfactu_cabe.Text = Format(dvListar_facturas.Table.Rows.Count, "###,###,###")

            'Else
            '    lblfactu_cabe.Text = ""
            'End If

            'If Not dvfacturas_pagos Is Nothing Then
            '    Me.lblfactu_deta.Text = Format(dvfacturas_pagos.Table.Rows.Count, "###,###,###")
            'Else
            '    lblfactu_deta.Text = ""
            'End If
            '
            Me.lblguias.Text = "0"
            Me.lblprefacturas.Text = "0"
            Me.lblfacturas.Text = "0"
            Me.lab_pagos.Text = "0"
            Me.Lab_cta_corriente.Text = "0"
            '
            Me.Lab_Nro_guia_envio.Text = "0"
            Me.Lab_pendiente_x_facturar.Text = "0"
            Me.Lab_pendiente_x_cobrar.Text = "0"
            Me.Lab_cobranza.Text = "0"
            Me.lab_nro_cta_corriente.Text = "0"
            Me.Lab_registro_detalle.Text = "0"
            '
            If lb_lee_parte_contar = False Then
                If Not DVGUIAS Is Nothing Then
                    Me.Lab_Nro_guia_envio.Text = Format(DVGUIAS.Table.Rows.Count, "###,###,##0")
                    ' lblguias.Text = Format(DVGUIAS.Table.Rows.Count, "###,###,###")                
                    lbltotal_guias.Text = 0
                    For j As Integer = 0 To DVGUIAS.Table.Rows.Count - 1
                        lbltotal_guias.Text = Format(CDbl(lbltotal_guias.Text) + DVGUIAS.Table.Rows(j)("TOTAL_COSTO"), "###,###,###.00")
                    Next

                Else
                    lbltotal_guias.Text = ""
                    Me.Lab_Nro_guia_envio.Text = "0"
                End If

                If Not DVPREFACTURAS Is Nothing Then
                    'lblprefacturas.Text = Format(DVPREFACTURAS.Table.Rows.Count, "###,###,###")
                    Me.Lab_pendiente_x_facturar.Text = Format(DVPREFACTURAS.Table.Rows.Count, "###,###,##0")
                    '
                    lbltotal_prefacturas.Text = 0
                    For j As Integer = 0 To DVPREFACTURAS.Table.Rows.Count - 1
                        lbltotal_prefacturas.Text = Format(CDbl(lbltotal_prefacturas.Text) + DVPREFACTURAS.Table.Rows(j)("TOTAL_COSTO"), "###,###,###.00")
                    Next
                Else
                    lblprefacturas.Text = ""
                    lbltotal_prefacturas.Text = ""
                    Me.Lab_pendiente_x_facturar.Text = "0"
                End If

                If Not DVFACTURAS_ Is Nothing Then
                    'lblfacturas.Text = Format(DVFACTURAS_.Table.Rows.Count, "###,###,###")
                    Me.Lab_pendiente_x_cobrar.Text = Format(DVFACTURAS_.Table.Rows.Count, "###,###,##0")
                    '
                    lbltotal_facturas.Text = 0
                    For j As Integer = 0 To DVFACTURAS_.Table.Rows.Count - 1
                        lbltotal_facturas.Text = Format(CDbl(lbltotal_facturas.Text) + DVFACTURAS_.Table.Rows(j)("SALDO"), "###,###,###.00")
                    Next
                Else
                    lbltotal_facturas.Text = ""
                    lblfacturas.Text = ""
                    Me.Lab_pendiente_x_cobrar.Text = "0"
                End If

                If Not DVPAGOS Is Nothing Then
                    ' lab_pagos.Text = Format(DVPAGOS.Table.Rows.Count, "###,###,###")
                    Me.Lab_cobranza.Text = Format(DVPAGOS.Table.Rows.Count, "###,###,##0")
                    lbltotal_pagoS.Text = "0"  'Format(DVPAGOS.Table.Rows.Count, "###,###,###.00")
                    '
                    For j As Integer = 0 To DVPAGOS.Table.Rows.Count - 1
                        lbltotal_pagoS.Text = Format(CDbl(lbltotal_pagoS.Text) + DVPAGOS.Table.Rows(j)("IM_DETA"), "###,###,###.00")
                    Next
                Else
                    lbltotal_pagoS.Text = "0"
                    lab_pagos.Text = ""
                    Me.Lab_cobranza.Text = "0"
                End If
                '
            End If
            If Not DVCTA_CORRIENTE Is Nothing Then
                'Lab_cta_corriente.Text = Format(DVCTA_CORRIENTE.Table.Rows.Count, "###,###,###")
                Me.lab_nro_cta_corriente.Text = Format(DVCTA_CORRIENTE.Table.Rows.Count, "###,###,##0")
                Me.Lab_registro_detalle.Text = Format(Me.DGV_cta_corriente_det.Rows.Count, "###,###,##0")
                'lbltotal_pagoS.Text = 0
                Dim ldb_saldo As Double = 0.0
                Me.txt_saldo_cliente.Text = "0"
                For j As Integer = 0 To DVCTA_CORRIENTE.Table.Rows.Count - 1
                    If IsDBNull(DVCTA_CORRIENTE.Table.Rows(j)("SALDO")) = True Then
                        ldb_saldo = 0
                    Else
                        ldb_saldo = DVCTA_CORRIENTE.Table.Rows(j)("SALDO")
                    End If
                    '    lbltotal_pagoS.Text = Format(CDbl(lbltotal_pagoS.Text) + DVCTA_CORRIENTE.Table.Rows(j)("SALDO"), "###,###,###.00")
                    Me.txt_saldo_cliente.Text = Format(CDbl(Me.txt_saldo_cliente.Text) + ldb_saldo, "###,###,###.00")
                Next
            Else
                Me.Lab_cta_corriente.Text = "0"
                Me.lab_nro_cta_corriente.Text = "0"
                'Lab_cta_corriente.Text = ""
                'lblpagos.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Me.Cursor = Cursors.AppStarting
            listar_facturas()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Public Sub listar_facturas()
        Try
            Dim ObjFactura As New ClsLbTepsa.dtoFACTURA

            If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                ObjFactura.IDPERSONA = 0 ' Recupera para todos los clientes 

                ' MsgBox("Seleccione un cliente...", MsgBoxStyle.Exclamation, "Seguridad del sistema")
                ' Exit Sub
            Else

                ObjFactura.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
            End If
            'If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjFactura.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_INICIO = "NULL"
            'If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjFactura.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_FINAL = "NULL"
            ' Mod. 22/11/2008 --> 
            ObjFactura.FECHA_INICIO = Me.DTPFECHAinicioFACTURA.Value.ToShortDateString
            ObjFactura.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString
            ObjFactura.idfuncionarioNegocio = Me.cmb_funcionario.SelectedValue
            '
            If Not IsNothing(Me.cbidtipo_moneda.SelectedValue) Then
                ObjFactura.IDTIPO_MONEDA = Me.cbidtipo_moneda.SelectedValue
            Else
                ObjFactura.IDTIPO_MONEDA = 0
            End If
            'Solo para que el usuario no salga un error 
            Try
                If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
                    ObjFactura.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
                Else
                    ObjFactura.IDUSUARIO_PERSONAL = 0
                End If
            Catch ex As Exception
                Me.cmbUsuarios.SelectedValue = 0
                Me.cmbUsuarios.Text = ""
                ObjFactura.IDUSUARIO_PERSONAL = 0
            End Try
            '
            If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                ObjFactura.IDAGENCIAS = Me.cmbAgencia.SelectedValue
            Else
                ObjFactura.IDAGENCIAS = 0
            End If

            If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
                ObjFactura.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
            Else
                ObjFactura.IDFORMA_PAGO = 0
            End If

            If Not IsNothing(Me.cmb_tipo_facturacion.SelectedValue) Then
                ObjFactura.IDTIPO_FACTURACION = Me.cmb_tipo_facturacion.SelectedValue
            Else
                ObjFactura.IDTIPO_FACTURACION = -1
            End If
            'Por defecto debe aparecer el campo en ambas 
            lb_lee_cta_corriente = False
            Me.rb_ambas_ctacorriente.Checked = True
            'dvListar_facturas = ObjFactura.FN_ConsulFactuEmi_movi(cnn)
            'FORMAT_GRILLA3()
            ObjFactura.Producto = Me.cmbProducto.SelectedValue

            Dim ds As New DataSet
            'datahelper
            'ds = ObjFactura.sp_list_deta_linea_credito(cnn)
            ds = ObjFactura.sp_list_deta_linea_credito()
            DVGUIAS = ds.Tables(0).DefaultView
            DVPREFACTURAS = ds.Tables(1).DefaultView
            DVFACTURAS_ = ds.Tables(2).DefaultView
            DVPAGOS = ds.Tables(3).DefaultView
            DVCTA_CORRIENTE = ds.Tables(4).DefaultView

            FORMAT_DGVGUIAS()
            FORMAT_DGVPREFACTURAS()
            FORMAT_DGVFACTURAS()
            FORMAT_DGVPAGOS()
            FORMAT_DGV_cuenta_corriente()
            ' 
            DGVGUIAS.DataSource = DVGUIAS
            DGVPREFACTURAS.DataSource = DVPREFACTURAS
            DGVFACTURAS.DataSource = DVFACTURAS_
            DGVPAGOS.DataSource = DVPAGOS
            DGV_cuenta_corriente.DataSource = DVCTA_CORRIENTE
            '
            contar()
            '
            'dgv4.DataSource = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub

    Private Sub DGV3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub FrmConsulFactuEmiPago_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmConsulFactuEmiPago_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    'Private Sub DGV3_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    Dim obj As New ClsLbTepsa.dtoFACTURA
    '    With obj
    '        .IDFACTURA = dvListar_facturas.Table.Rows(DGV3.CurrentRow.Index)("IDFACTURA")
    '        dvfacturas_pagos = .SP_LISTA_PAGO_FACTU(cnn)
    '        Call FORMAT_GRILLA4()
    '        contar()
    '    End With
    'End Sub

    'Sub FORMAT_GRILLA4()
    '    dgv4.Columns.Clear()

    '    With dgv4
    '        .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    '        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
    '        .AllowUserToOrderColumns = True
    '        .AllowUserToDeleteRows = False
    '        .AllowUserToAddRows = False
    '        .AutoGenerateColumns = False
    '        .DataSource = dvfacturas_pagos
    '        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
    '        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        .VirtualMode = True
    '        .RowHeadersVisible = True
    '        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    End With

    '    Dim FE_OPER As New DataGridViewTextBoxColumn
    '    With FE_OPER
    '        .HeaderText = "FECHA"
    '        .Name = "FE_OPER"
    '        .DataPropertyName = "FE_OPER"
    '        .Width = 80
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With


    '    Dim CO_BANC As New DataGridViewTextBoxColumn
    '    With CO_BANC
    '        .HeaderText = "CODIGO"
    '        .Name = "CO_BANC"
    '        .DataPropertyName = "CO_BANC"
    '        .Width = 50
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With


    '    Dim NU_COMP_BANC As New DataGridViewTextBoxColumn
    '    With NU_COMP_BANC
    '        .HeaderText = "NUMERO"
    '        .Name = "NU_COMP_BANC"
    '        .DataPropertyName = "NU_COMP_BANC"
    '        .Width = 50
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With

    '    Dim IM_DETA As New DataGridViewTextBoxColumn
    '    With IM_DETA
    '        .HeaderText = "IMPORTE"
    '        .Name = "IM_DETA"
    '        .DataPropertyName = "IM_DETA"
    '        .Width = 50
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .ReadOnly = True
    '    End With


    '    With dgv4

    '        .Columns.AddRange(FE_OPER, CO_BANC, NU_COMP_BANC, IM_DETA)

    '    End With
    'End Sub
    'Sub FORMAT_GRILLA3()
    '    DGV3.Columns.Clear()

    '    With DGV3
    '        .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    '        .Font = New Font("Arial", 8.0!, FontStyle.Regular)
    '        .AllowUserToOrderColumns = True
    '        .AllowUserToDeleteRows = False
    '        .AllowUserToAddRows = False
    '        .AutoGenerateColumns = False
    '        .DataSource = dvListar_facturas
    '        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
    '        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        .VirtualMode = True
    '        .RowHeadersVisible = True
    '        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '    End With


    '    Dim ANIO_FACTURA As New DataGridViewTextBoxColumn
    '    With ANIO_FACTURA
    '        .HeaderText = "ANIO_FACTURA"
    '        .Name = "ANIO_FACTURA"
    '        .DataPropertyName = "ANIO_FACTURA"
    '        .Width = 4
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim CODIGO_CLIENTE As New DataGridViewTextBoxColumn
    '    With CODIGO_CLIENTE
    '        .HeaderText = "CODIGO_CLIENTE"
    '        .Name = "CODIGO_CLIENTE"
    '        .DataPropertyName = "CODIGO_CLIENTE"
    '        .Width = 20
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim DESTINATARIO As New DataGridViewTextBoxColumn
    '    With DESTINATARIO
    '        .HeaderText = "DESTINATARIO"
    '        .Name = "DESTINATARIO"
    '        .DataPropertyName = "DESTINATARIO"
    '        .Width = 182
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim DESTINO As New DataGridViewTextBoxColumn
    '    With DESTINO
    '        .HeaderText = "DESTINO"
    '        .Name = "DESTINO"
    '        .DataPropertyName = "DESTINO"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .ReadOnly = True
    '    End With
    '    Dim DIA_FACTURA As New DataGridViewTextBoxColumn
    '    With DIA_FACTURA
    '        .HeaderText = "DIA_FACTURA"
    '        .Name = "DIA_FACTURA"
    '        .DataPropertyName = "DIA_FACTURA"
    '        .Width = 2
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim DIRECCION_PERSONA As New DataGridViewTextBoxColumn
    '    With DIRECCION_PERSONA
    '        .HeaderText = "DIRECCION_PERSONA"
    '        .Name = "DIRECCION_PERSONA"
    '        .DataPropertyName = "DIRECCION_PERSONA"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .ReadOnly = True
    '    End With
    '    Dim DIREC_DESTI As New DataGridViewTextBoxColumn
    '    With DIREC_DESTI
    '        .HeaderText = "DIREC_DESTI"
    '        .Name = "DIREC_DESTI"
    '        .DataPropertyName = "DIREC_DESTI"
    '        .Width = 200
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim DIREC_REMI As New DataGridViewTextBoxColumn
    '    With DIREC_REMI
    '        .HeaderText = "DIREC_REMI"
    '        .Name = "DIREC_REMI"
    '        .DataPropertyName = "DIREC_REMI"
    '        .Width = 200
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim DSCTO As New DataGridViewTextBoxColumn
    '    With DSCTO
    '        .HeaderText = "DSCTO"
    '        .Name = "DSCTO"
    '        .DataPropertyName = "DSCTO"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .Width = 80
    '        .ReadOnly = True
    '    End With
    '    Dim FECHA As New DataGridViewTextBoxColumn
    '    With FECHA
    '        .HeaderText = "FECHA"
    '        .Name = "FECHA"
    '        .DataPropertyName = "FECHA"
    '        .Width = 80
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
    '    With ESTADO_REGISTRO
    '        .HeaderText = "ESTADO_REGISTRO"
    '        .Name = "ESTADO_REGISTRO"
    '        .DataPropertyName = "ESTADO_REGISTRO"
    '        .Width = 100
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
    '    With NOMBRE_AGENCIA
    '        .HeaderText = "NOMBRE_AGENCIA"
    '        .Name = "NOMBRE_AGENCIA"
    '        .DataPropertyName = "NOMBRE_AGENCIA"
    '        .Width = 100
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim FORMA_PAGO As New DataGridViewTextBoxColumn
    '    With FORMA_PAGO
    '        .HeaderText = "FORMA_PAGO"
    '        .Name = "FORMA_PAGO"
    '        .DataPropertyName = "FORMA_PAGO"
    '        .Width = 50
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim IDAGENCIAS As New DataGridViewTextBoxColumn
    '    With IDAGENCIAS
    '        .HeaderText = "IDAGENCIAS"
    '        .Name = "IDAGENCIAS"
    '        .DataPropertyName = "IDAGENCIAS"
    '        .Width = 50
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .ReadOnly = True
    '    End With
    '    Dim IDFACTURA As New DataGridViewTextBoxColumn
    '    With IDFACTURA
    '        .HeaderText = "IDFACTURA"
    '        .Name = "IDFACTURA"
    '        .DataPropertyName = "IDFACTURA"
    '        .Width = 50
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .ReadOnly = True
    '        .Visible = False   'Agregado por omendoza 11/02/2007
    '    End With
    '    Dim IDFORMA_PAGO As New DataGridViewTextBoxColumn
    '    With IDFORMA_PAGO
    '        .HeaderText = "IDFORMA_PAGO"
    '        .Name = "IDFORMA_PAGO"
    '        .DataPropertyName = "IDFORMA_PAGO"
    '        .Width = 50
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .ReadOnly = True
    '    End With
    '    Dim IDTIPO_MONEDA As New DataGridViewTextBoxColumn
    '    With IDTIPO_MONEDA
    '        .HeaderText = "IDTIPO_MONEDA"
    '        .Name = "IDTIPO_MONEDA"
    '        .DataPropertyName = "IDTIPO_MONEDA"
    '        .Width = 50
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .ReadOnly = True
    '    End With
    '    Dim IDUSUARIO_PERSONAL As New DataGridViewTextBoxColumn
    '    With IDUSUARIO_PERSONAL
    '        .HeaderText = "IDUSUARIO_PERSONAL"
    '        .Name = "IDUSUARIO_PERSONAL"
    '        .DataPropertyName = "IDUSUARIO_PERSONAL"
    '        .Width = 50
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .ReadOnly = True
    '    End With
    '    Dim MEMO As New DataGridViewTextBoxColumn
    '    With MEMO
    '        .HeaderText = "MEMO"
    '        .Name = "MEMO"
    '        .DataPropertyName = "MEMO"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .ReadOnly = True
    '    End With
    '    Dim MES_FACTURA As New DataGridViewTextBoxColumn
    '    With MES_FACTURA
    '        .HeaderText = "MES_FACTURA"
    '        .Name = "MES_FACTURA"
    '        .DataPropertyName = "MES_FACTURA"
    '        .Width = 10
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .ReadOnly = True
    '    End With
    '    Dim MONTO_IMPUESTO As New DataGridViewTextBoxColumn
    '    With MONTO_IMPUESTO
    '        .HeaderText = "MONTO_IMPUESTO"
    '        .Name = "MONTO_IMPUESTO"
    '        .DataPropertyName = "MONTO_IMPUESTO"
    '        .Width = 50
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .ReadOnly = True
    '    End With
    '    Dim NRO_FACTURA As New DataGridViewTextBoxColumn
    '    With NRO_FACTURA
    '        .HeaderText = "NRO_FACTURA"
    '        .Name = "NRO_FACTURA"
    '        .DataPropertyName = "NRO_FACTURA"
    '        .Width = 70
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '    End With
    '    Dim ORIGEN As New DataGridViewTextBoxColumn
    '    With ORIGEN
    '        .HeaderText = "ORIGEN"
    '        .Name = "ORIGEN"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DataPropertyName = "ORIGEN"

    '        .ReadOnly = True
    '    End With
    '    Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
    '    With RAZON_SOCIAL
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .HeaderText = "RAZON_SOCIAL"
    '        .Name = "RAZON_SOCIAL"
    '        .DataPropertyName = "RAZON_SOCIAL"
    '        .Width = 200
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim REFE As New DataGridViewTextBoxColumn
    '    With REFE
    '        .HeaderText = "REFE"
    '        .Name = "REFE"
    '        .DataPropertyName = "REFE"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .ReadOnly = True
    '    End With
    '    Dim REMITENTE As New DataGridViewTextBoxColumn
    '    With REMITENTE
    '        .HeaderText = "REMITENTE"
    '        .Name = "REMITENTE"
    '        .DataPropertyName = "REMITENTE"
    '        .Width = 182
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim SERIE_FACTURA As New DataGridViewTextBoxColumn
    '    With SERIE_FACTURA
    '        .HeaderText = "SERIE_FACTURA"
    '        .Name = "SERIE_FACTURA"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DataPropertyName = "SERIE_FACTURA"
    '        .Width = 30
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
    '    With SIMBOLO_MONEDA
    '        .HeaderText = "SIMBOLO_MONEDA"
    '        .Name = "SIMBOLO_MONEDA"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DataPropertyName = "SIMBOLO_MONEDA"
    '        .Width = 30
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim SUB_TOTAL As New DataGridViewTextBoxColumn
    '    With SUB_TOTAL
    '        .HeaderText = "SUB_TOTAL"
    '        .Name = "SUB_TOTAL"
    '        .DataPropertyName = "SUB_TOTAL"
    '        .Width = 50
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .ReadOnly = True
    '    End With
    '    Dim LOGIN As New DataGridViewTextBoxColumn
    '    With LOGIN
    '        .HeaderText = "LOGIN"
    '        .Name = "LOGIN"
    '        .DataPropertyName = "LOGIN"
    '        .Width = 50
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
    '    With TOTAL_COSTO
    '        .HeaderText = "TOTAL_COSTO"
    '        .Name = "TOTAL_COSTO"
    '        .DataPropertyName = "TOTAL_COSTO"
    '        .Width = 50
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
    '        .DefaultCellStyle.Format = "N2"
    '        .DefaultCellStyle.NullValue = "0,00"
    '        .ReadOnly = True
    '    End With
    '    Dim NRO_PREFACTURA As New DataGridViewTextBoxColumn
    '    With NRO_PREFACTURA
    '        .HeaderText = "NRO_PREFACTURA"
    '        .Name = "NRO_PREFACTURA"
    '        .DataPropertyName = "NRO_PREFACTURA"
    '        .Width = 100
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With
    '    'Creado por Omendoza 11-02-2007 
    '    Dim l_fecha_cargo As New DataGridViewTextBoxColumn
    '    With l_fecha_cargo
    '        .HeaderText = "Fecha Cargo"
    '        .Name = "fecha_cargo"
    '        .DataPropertyName = "fecha_cargo"
    '        '.Width = 18
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
    '        .Visible = True
    '        .ReadOnly = True
    '    End With
    '    '
    '    Dim l_fecha_vencimiento As New DataGridViewTextBoxColumn
    '    With l_fecha_vencimiento
    '        .HeaderText = "Fecha Vencimiento"
    '        .Name = "FECHA_VENCIMIENTO"
    '        .DataPropertyName = "FECHA_VENCIMIENTO"
    '        '.Width = 18
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
    '        .Visible = True
    '        .ReadOnly = True
    '    End With
    '    '
    '    Dim l_idpersona As New DataGridViewTextBoxColumn
    '    With l_idpersona
    '        .HeaderText = "IDPERSONA"
    '        .Name = "IDPERSONA"
    '        .DataPropertyName = "IDPERSONA"
    '        .Width = 18
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .Visible = False
    '        .ReadOnly = True
    '    End With
    '    '
    '    Dim l_idestado_factura As New DataGridViewTextBoxColumn
    '    With l_idestado_factura
    '        .HeaderText = "idestado_factura"
    '        .Name = "idestado_factura"
    '        .DataPropertyName = "idestado_factura"
    '        .Width = 18
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .Visible = False
    '        .ReadOnly = True
    '    End With

    '    Dim MES_CORRESPONDE As New DataGridViewTextBoxColumn
    '    With MES_CORRESPONDE
    '        .HeaderText = "Mes Corresponde"
    '        .Name = "mes_CORRESPONDE"
    '        .DataPropertyName = "mes_CORRESPONDE"
    '        .Width = 80
    '        .SortMode = DataGridViewColumnSortMode.NotSortable
    '        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
    '        .ReadOnly = True
    '    End With


    '    '
    '    With DGV3
    '        .Columns.AddRange(NOMBRE_AGENCIA, LOGIN, RAZON_SOCIAL, SERIE_FACTURA, NRO_FACTURA, MES_CORRESPONDE, FECHA, NRO_PREFACTURA, FORMA_PAGO, SIMBOLO_MONEDA, SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, ESTADO_REGISTRO, l_idpersona, l_idestado_factura, IDFACTURA, l_fecha_cargo, l_fecha_vencimiento)
    '    End With
    'End Sub

    Private Sub FrmConsulFactuEmiti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim ls_fecha_inicio_lc As String
            Dim ldvg_get_funcionario As New DataView

            contar()
            Me.ShadowLabel1.Text = "Consulta de Cuenta Corriente"
            Me.MenuStrip1.Items(0).Visible = False
            Me.MenuStrip1.Items(1).Visible = False
            Me.MenuStrip1.Items(2).Visible = False
            Me.MenuStrip1.Items(3).Visible = False
            Me.MenuStrip1.Items(4).Visible = False
            Me.MenuStrip1.Items(5).Visible = False
            Me.MenuStrip1.Items(7).Text = "Resumen Cta. Cte"
            Me.MenuStrip1.Items(7).Visible = True

            'datahelper
            'objgeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago, VOCONTROLUSUARIO)
            'objgeneral.FNLISTAR_TIPO_MONEDA(dvlistar_tipo_moneda, Me.cbidtipo_moneda, VOCONTROLUSUARIO)
            objgeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago)
            objgeneral.FNLISTAR_TIPO_MONEDA(dvlistar_tipo_moneda, Me.cbidtipo_moneda)
            '
            'datahelper
            'objgeneral.FN_cmb_Listar_agencias(cnn, Me.cmbAgencia)
            objgeneral.FN_cmb_Listar_agencias(Me.cmbAgencia)
            'datahelper
            'objgeneral.sp_listar_t_tipo_facturacion(cnn, Me.cmb_tipo_facturacion)
            objgeneral.sp_listar_t_tipo_facturacion(Me.cmb_tipo_facturacion)
            '
            Me.cmb_tipo_facturacion.SelectedValue = -1 ' Por defecto no selecciona nada 
            '
            ObjPersona.CODIGO_CLIENTE = "NULL"
            ObjPersona.IDTIPO_PERSONA = 0
            ObjPersona.IDPERSONA = 0
            '-- Recupera el número de dìas para analizar la linea de crèdito 
            'datahelper
            'objgeneral.get_nro_meses_linea_credito(cnn)
            objgeneral.get_nro_meses_linea_credito()
            '--
            ill_nro_meses_lc = objgeneral.nro_meses_linea_cred  '-- Control a nivel de BD.
            ls_fecha_inicio_lc = objgeneral.fecha_inicio_lc
            'Me.lab_mensaje.Text = "Antes de " + CType(ill_nro_meses_lc, String) + " mes(es), Inicia el " + ls_fecha_inicio_lc
            '
            'datahelper
            'dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
            ObjProcesos.fnCargar_iWin_r(Me.txtidpersona, dvlistar_persona_todos, Colllistar_persona_todos, Iwinlistar_persona_todos, 0)
            'Recupera los funcionarios de negocios 
            'datahelper
            'ldvg_get_funcionario = objgeneral.FN_cmb_L_FUNCIONARIOS(cnn, Me.cmb_funcionario)

            'hlamas 06-01-2014
            'ldvg_get_funcionario = objgeneral.FN_cmb_L_FUNCIONARIOS(Me.cmb_funcionario)
            ldvg_get_funcionario = objgeneral.CarteraResponsable(Me.cmb_funcionario, "", "", 3)

            Me.cbidforma_pago.SelectedIndex = -1
            Me.cbidtipo_moneda.SelectedIndex = -1
            Me.cmbAgencia.SelectedIndex = -1
            Me.cmbUsuarios.SelectedIndex = -1
            '
            Me.lblguias.Text = "0"
            Me.lblprefacturas.Text = "0"
            Me.lblfacturas.Text = "0"
            Me.lab_pagos.Text = "0"
            Me.Lab_cta_corriente.Text = "0"
            '
            Me.Lab_funcionario.Text = ""
            '
            lb_lee_cta_corriente = False
            Me.rb_ambas_ctacorriente.Checked = True
            '
            FORMAT_DGVGUIAS()
            FORMAT_DGVPREFACTURAS()
            FORMAT_DGVFACTURAS()
            FORMAT_DGVPAGOS()
            FORMAT_DGV_cuenta_corriente()
            FORMAT_DGV_cuenta_corriente_deta()
            '
            Me.rd_imprime_pantalla.Checked = True
            '

            'hlamas 03-10-2013
            Dim obj As New dtoVentaCargaContado
            With Me.cmbProducto
                .DataSource = obj.ListarProducto(2, 1)
                .ValueMember = "idprocesos"
                .DisplayMember = "procesos"
                .SelectedValue = 0
            End With

            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub cmbAgencia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'dgv4.DataSource = Nothing
        'DGV3.DataSource = Nothing
    End Sub
    Private Sub cmbAgencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbAgencia.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cmbUsuarios.Focus()
        End If
    End Sub
    Private Sub cmbAgencia_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectionChangeCommitted
        Dim p_id_rol_usuario, p_idagencia As Int64
        p_id_rol_usuario = 0
        If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
            p_idagencia = CType(Me.cmbAgencia.SelectedValue, Int64)
            'datahelper
            'objgeneral.FN_cmb_LISTAR_USUARIOS_AGENCIAS(cnn, Me.cmbUsuarios, p_id_rol_usuario, p_idagencia)
            objgeneral.FN_cmb_LISTAR_USUARIOS_AGENCIAS(Me.cmbUsuarios, p_id_rol_usuario, p_idagencia)
        Else
            cmbUsuarios.DataSource = Nothing
        End If
        Me.cmbUsuarios.SelectedIndex = -1

    End Sub

    Private Sub FrmConsulFactuEmiti_MenuImprimir() Handles Me.MenuImprimir
        Dim ObjFactura As New ClsLbTepsa.dtoFACTURA
        Try
            ObjReport.Dispose()
        Catch

        End Try
        '
        ObjReport = New ClsLbTepsa.dtoFrmReport
        '
        With ObjFactura
            If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                ObjFactura.IDPERSONA = 0
            Else
                ObjFactura.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
            End If
            '
            ObjFactura.idfuncionarioNegocio = Me.cmb_funcionario.SelectedValue
            '
            If Not (IsNothing(Me.cmb_tipo_facturacion.SelectedValue) And Me.cmb_tipo_facturacion.Text = "") Then
                ObjFactura.IDTIPO_FACTURACION = Me.cmb_tipo_facturacion.SelectedValue
            Else
                ObjFactura.IDTIPO_FACTURACION = -1
            End If
            '
            ObjReport.rutaRpt = PathFrmReport
            ObjReport.conectar(rptservice, rptuser, rptpass)
            '
            If Me.RadB_Saldo.Checked = True Then
                ObjReport.printrptB(False, "", "FAC062_1.RPT", _
                "P_IDPERSONA;" & .IDPERSONA, _
                "NI_IDFUNCIONARIO;" & .idfuncionarioNegocio, _
                "NI_TIPO_FACTURACION;" & .IDTIPO_FACTURACION)
            End If
            '
            If Me.radB_linea_credito.Checked = True Then
                ObjReport.printrptB(False, "", "FAC036.rpt", _
                    "p_idusuario_personal;" & ObjFactura.IDUSUARIO_PERSONAL, _
                    "p_idtipo_facturacion;" & ObjFactura.IDTIPO_FACTURACION)
            End If
            '
            If Me.rd_imprime_pantalla.Checked = True Then
                'para la persona 
                Dim ll_idpersona, ll_idfuncionario, ll_tipo_facturacion As Long
                Dim ls_fecha_incial, ls_fecha_final As String
                '
                If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Or Me.txtidpersona.Text = "" Then
                    ll_idpersona = 0
                Else
                    ll_idpersona = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                End If
                '
                ls_fecha_incial = Me.DTPFECHAinicioFACTURA.Text
                ls_fecha_final = Me.DTPFECHAFINALFACTURA.Text
                '   
                If Not IsNothing(Me.cmb_funcionario.SelectedValue) Then
                    ll_idfuncionario = Me.cmb_funcionario.SelectedValue
                Else
                    ll_idfuncionario = -1
                End If
                '
                If Not IsNothing(Me.cmb_tipo_facturacion.SelectedValue) Then
                    ll_tipo_facturacion = Me.cmb_tipo_facturacion.SelectedValue
                Else
                    ll_tipo_facturacion = -1
                End If
                '
                Select Case Me.TabControl1.SelectedIndex
                    Case 0 ' GE Pendiente 
                        ObjReport.printrptB(False, "", "fac063.rpt", _
                           "P_IDPERSONA;" & ll_idpersona, _
                           "P_FECHA_INCIAL;" & ls_fecha_incial, _
                           "P_FECHA_FINAL;" & ls_fecha_final, _
                           "NI_IDFUNCIONARIO;" & ll_idfuncionario, _
                           "NI_IDTIPO_FACTURACION;" & ll_tipo_facturacion)
                    Case 1 ' Pre-Factura Pendiente 
                        ObjReport.printrptB(False, "", "fac064.rpt", _
                            "P_IDPERSONA;" & ll_idpersona, _
                            "P_FECHA_INCIAL;" & ls_fecha_incial, _
                            "P_FECHA_FINAL;" & ls_fecha_final, _
                            "NI_IDFUNCIONARIO;" & ll_idfuncionario, _
                            "NI_IDTIPO_FACTURACION;" & ll_tipo_facturacion)
                    Case 2 'Facturas x cobrar 
                        ObjReport.printrptB(False, "", "fac065.rpt", _
                            "P_IDPERSONA;" & ll_idpersona, _
                            "P_FECHA_INCIAL;" & ls_fecha_incial, _
                            "P_FECHA_FINAL;" & ls_fecha_final, _
                            "NI_IDFUNCIONARIO;" & ll_idfuncionario, _
                            "NI_IDTIPO_FACTURACION;" & ll_tipo_facturacion)
                    Case 3 ' Cobranzas 
                        ObjReport.printrptB(False, "", "fac066.rpt", _
                            "P_IDPERSONA;" & ll_idpersona, _
                            "P_FECHA_INCIAL;" & ls_fecha_incial, _
                            "P_FECHA_FINAL;" & ls_fecha_final, _
                            "NI_IDFUNCIONARIO;" & ll_idfuncionario, _
                            "NI_IDTIPO_FACTURACION;" & ll_tipo_facturacion)
                    Case 4 ' Cuenta corriente 
                        Dim ll_seleccion As Long
                        If Me.rb_vencido_ctacorriente.Checked = True Then
                            ll_seleccion = -1
                        End If
                        If Me.rb_por_vencer_ctacorriente.Checked = True Then
                            ll_seleccion = 1
                        End If
                        If Me.rb_ambas_ctacorriente.Checked = True Then
                            ll_seleccion = 0
                        End If
                        If Me.RbtLegal.Checked Then
                            ll_seleccion = 2
                        End If
                        '
                        ObjReport.printrptB(False, "", "fac067.rpt", _
                            "P_IDPERSONA;" & ll_idpersona, _
                            "NI_IDFUNCIONARIO;" & ll_idfuncionario, _
                            "NI_IDTIPO_FACTURACION;" & ll_tipo_facturacion, _
                            "NI_SELECCION;" & ll_seleccion)
                End Select
            End If
            '
        End With
        '
        '
        'Select Case Me.TabMante.SelectedIndex
        '    Case 0
        '        Try
        '            'If Me.DGV3.RowCount <= 0 Then
        '            '    MsgBox("No existen registro", MsgBoxStyle.Exclamation, "Seguridad del Sistema")
        '            '    Exit Sub
        '            'End If
        '            Dim ObjFactura As New ClsLbTepsa.dtoFACTURA

        '            If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
        '                ObjFactura.IDPERSONA = 0
        '            Else

        '                ObjFactura.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
        '            End If
        '            'If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjFactura.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_INICIO = "NULL"
        '            If Me.DTPFECHAinicioFACTURA.Enabled = True Then ObjFactura.FECHA_FINAL = Me.DTPFECHAinicioFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_FINAL = "NULL"
        '            If Not IsNothing(Me.cbidtipo_moneda.SelectedValue) Then
        '                ObjFactura.IDTIPO_MONEDA = Me.cbidtipo_moneda.SelectedValue
        '            Else
        '                ObjFactura.IDTIPO_MONEDA = 0
        '            End If
        '            If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
        '                ObjFactura.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
        '            Else
        '                ObjFactura.IDUSUARIO_PERSONAL = 0
        '            End If
        '            If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
        '                ObjFactura.IDAGENCIAS = cmbAgencia.SelectedValue
        '            Else
        '                ObjFactura.IDAGENCIAS = 0
        '            End If

        '            If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
        '                ObjFactura.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
        '            Else
        '                ObjFactura.IDFORMA_PAGO = 0
        '            End If
        '            With ObjFactura

        '                '.IDFACTURA = Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index)("IDFACTURA")

        '                'Try ObjReport.Dispose() Catch End Try ObjReport = New ClsLbTepsa.dtoFrmReport
        '                ObjReport.rutaRpt = PathFrmReport
        '                ObjReport.conectar(rptservice, rptuser, rptpass)

        '                Dim PREFACTURA As String


        '                'If Not Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index).IsNull("NRO_PREFACTURA") Then

        '                '    If Not Trim(Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index)("NRO_PREFACTURA")) = "" Then
        '                '        PREFACTURA = "Prefactura Nro.:" & Me.dvListar_facturas.Table.Rows(Me.DGV3.CurrentRow.Index)("NRO_PREFACTURA")
        '                '    Else
        '                '        PREFACTURA = ""
        '                '    End If
        '                'Else
        '                '    PREFACTURA = ""
        '                'End If



        '                ObjReport.printrptB(False, "", "CC010.RPT", _
        '                "P_IDPERSONA;" & .IDPERSONA, _
        '                "P_FECHA_FINAL;" & .FECHA_FINAL)


        'End With
        'Catch ex As Exception
        'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        'End Try
        '    End Select
        ''''''''''



    End Sub

    Private Sub FrmConsulFactuEmiti_MenuSalir() Handles Me.MenuSalir
        Close()
    End Sub

    Private Sub txtidpersona_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'dgv4.DataSource = Nothing
        'DGV3.DataSource = Nothing
    End Sub
    Private Sub txtidpersona_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtidpersona.Enter
        limpiar_grilla()
    End Sub

    Private Sub txtidpersona_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtidpersona.KeyUp        
        Try
            If e.KeyCode = 13 Then '
                If Not Iwinlistar_persona_todos.IndexOf(txtidpersona.Text) = -1 Then
                    Me.Cursor = Cursors.AppStarting
                    With ObjPersona
                        .IDPERSONA = Int(Colllistar_persona_todos.Item(Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                        .IDTIPO_PERSONA = 0
                        .CODIGO_CLIENTE = "NULL"
                        'datahelper
                        'ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, .IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                        ObjPersona.FNLISTAR_PERSONA(.IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                        Me.txtCodigoCliente.Text = .CODIGO_CLIENTE
                        'Me.txt_saldo_cliente.Text = Format(.Saldo_cliente, "###,###,###.00")
                        Me.txt_saldo_cliente.Text = "0.0"
                        Me.txt_saldo.Text = Format(.Saldo_cliente, "###,###,###.00")

                        Dim db As New BaseDatos
                        db.Conectar()
                        db.CrearComando("select sf_get_saldo_linea_credito(" & .IDPERSONA & ") from dual", CommandType.Text)
                        Dim iSaldo As Double = db.EjecutarEscalar()
                        Me.txt_saldo.Text = Format(iSaldo, "###,###,###.00")
                        db.Desconectar()

                        Me.txt_linea_credito.Text = Format(.Linea_Credito, "###,###,###.00")
                        If .idfuncionarioNegocio = 0 Then
                            Me.cmb_funcionario.SelectedValue = -10
                        Else
                            Me.cmb_funcionario.SelectedValue = .idfuncionarioNegocio
                        End If
                        'idfuncionarioNegocio()
                        '
                        'Me.DTPFECHAINICIOFACTURA.Focus()
                        '.Saldo_cliente
                        '
                        '21/11/2008 - Modifica el valor 
                        ' No recupera 16/03/2009
                        'Try
                        '    listar_facturas()
                        'Catch ex As Exception
                        '    '
                        'End Try

                        '    '
                    End With
                    'Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
                Else
                    Me.txtCodigoCliente.Text = ""
                    Me.cmb_funcionario.SelectedValue = -10 'Codigo de cliente sin funcionarios 
                End If
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub txtidpersona_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
            Me.txtidpersona.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub
    Private Sub txtCodigoCliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.GotFocus
        'dgv4.DataSource = Nothing
        'DGV3.DataSource = Nothing
    End Sub

    Private Sub txtCodigoCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCliente.KeyPress
        Try
            '
            Dim tb As TextBox = CType(sender, TextBox)
            'Dim chr As Char = e.KeyChar
            If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
            '
            If e.KeyChar = Chr(13) Then

                ObjPersona.CODIGO_CLIENTE = Trim(Me.txtCodigoCliente.Text)
                ObjPersona.IDTIPO_PERSONA = 0
                ObjPersona.IDPERSONA = 0

                If Len(ObjPersona.CODIGO_CLIENTE) = 0 Then
                    Me.txtCodigoCliente.Text = ""
                    Me.txtidpersona.Text = ""
                    Exit Sub
                End If

                'datahelper
                'If ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE).Count = 1 Then
                If ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE).Count = 1 Then
                Me.txtidpersona.Text = ObjPersona.RAZON_SOCIAL
                Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
                txtidpersona.Focus()
            Else
                MsgBox("No existe el cliente", MsgBoxStyle.Information, "Segurdiad del Sistema")
                Me.txtidpersona.Text = ""
            End If
            '21/11/2008 - Modifica el valor 
            Try
                listar_facturas()
            Catch ex As Exception
                '
            End Try
            End If
        Catch EX As Exception
            MsgBox(EX.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub txtCodigoCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
            Me.txtidpersona.Text = ""
            Me.txtCodigoCliente.Text = ""
        End If
    End Sub
    Private Sub txtCodigoCliente_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.Enter
        If lb_lee_campo = True Then
            limpiar_grilla()
        End If
    End Sub
    Private Sub txtCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.TextChanged
        If lb_lee_campo = True Then
            limpiar_grilla()
        End If

    End Sub

    Private Sub DTPFECHAINICIOFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'dgv4.DataSource = Nothing
        'DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            DTPFECHAinicioFACTURA.Focus()
        End If
    End Sub

    Private Sub DTPFECHAINICIOFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAinicioFACTURA.ValueChanged
        'hlamas 06-01-2014
        'objgeneral.CarteraResponsable(Me.cmb_funcionario, Me.DTPFECHAinicioFACTURA.Text, Me.DTPFECHAFINALFACTURA.Text, 1)
    End Sub

    Private Sub DTPFECHAFINALFACTURA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'dgv4.DataSource = Nothing
        'DGV3.DataSource = Nothing
    End Sub

    Private Sub DTPFECHAFINALFACTURA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPFECHAinicioFACTURA.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cbidtipo_moneda.Focus()
        End If
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged
        Dim ls_mensaje As String
        Dim ld_fecha As String

        Try
            'DateDiff(DateInterval.Month,ctype(DTPFECHAFINALFACTURA.Value,Date),
            '= DateValue(DTPFECHAFINALFACTURA.Value)
            '
            ld_fecha = DateAdd(DateInterval.Month, -ill_nro_meses_lc, CType(DTPFECHAinicioFACTURA.Value, Date))
            '
            ' DTPFECHAFINALFACTURA.Value
            'Me.lab_mensaje.Text = "Antes de " + CType(ill_nro_meses_lc, String) + " mes(es), Inicia el " + "01/" + Mid(CType(ld_fecha, String), 4, 7)
            'hlamas 06-01-2014
            'objgeneral.CarteraResponsable(Me.cmb_funcionario, Me.DTPFECHAinicioFACTURA.Text, Me.DTPFECHAFINALFACTURA.Text, 1)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub cbidtipo_moneda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'dgv4.DataSource = Nothing
        'DGV3.DataSource = Nothing
    End Sub

    Private Sub cbidtipo_moneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidtipo_moneda.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                Me.cbidforma_pago.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub cbidforma_pago_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'dgv4.DataSource = Nothing
        'DGV3.DataSource = Nothing
    End Sub
    Private Sub cbidforma_pago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbidforma_pago.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.cmbAgencia.Focus()
        End If
    End Sub

    Private Sub cmbUsuarios_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'dgv4.DataSource = Nothing
        'DGV3.DataSource = Nothing
    End Sub


    Private Sub cmbUsuarios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbUsuarios.KeyPress
        If e.KeyChar = Chr(13) Then
            Me.Button3.Focus()
        End If
    End Sub
    Private Sub CargoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargoToolStripMenuItem.Click
        'Implementado por Omendoza 10-02-2007 
        'Rol (15) CREDITO Y COBRANZA
        Dim flag As Boolean
        Dim l_idpersona, l_idfactura, l_idestado_factura As Long
        Dim s_razon_social, s_serie_factura, s_nro_factura As String

        Try
            'bloque
            If Acceso.SiRol(G_Rol, Me, 1) Then
                'If fnValidar_Rol("15") Then
                flag = True
            End If
            If flag = False Then
                MsgBox("Usted no tiene Acceso", MsgBoxStyle.Information, "Seguridad Sistema")
                Exit Sub
            End If
            'Recuperando los datos 
            Dim dgrv0 As DataGridViewRow
            '
            'dgrv0 = Me.DGV3.CurrentRow()
            l_idpersona = CType(dgrv0.Cells("IDPERSONA").Value, Long)
            l_idfactura = CType(dgrv0.Cells("IDFACTURA").Value, Long)
            s_razon_social = CType(dgrv0.Cells("RAZON_SOCIAL").Value, String)
            s_serie_factura = CType(dgrv0.Cells("SERIE_FACTURA").Value, String)
            s_nro_factura = CType(dgrv0.Cells("NRO_FACTURA").Value, String)
            l_idestado_factura = CType(dgrv0.Cells("idestado_factura").Value, Long)
            If l_idestado_factura = 2 Then
                MsgBox("La factura está anulada, no puede actualizar la fecha de cargo", MsgBoxStyle.Information, "Facturación")
                Exit Sub
            End If
            If l_idestado_factura = 3 Then
                MsgBox("La factura está eliminada, no puede actualizar la fecha de cargo", MsgBoxStyle.Information, "Facturación")
                Exit Sub
            End If
            '
            Dim a As New frmcargofactura
            a.txtcomprobante.Text = s_serie_factura + " - " + s_nro_factura
            a.txtidfactura.Text = l_idfactura
            a.txtrazon_social.Text = s_razon_social
            a.txtidpersona.Text = l_idpersona
            'a.ShowDialog()

            Acceso.Asignar(a, Me.hnd)
            If Acceso.TieneAcceso(G_Rol, G_Fila) Then
                a.ShowDialog()
                If a.brefrescar Then
                    listar_facturas()
                End If
            Else
                MessageBox.Show("No tiene acceso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Seguridad Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub FrmConsulFacturados_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            ObjReport.Dispose()
        Catch
        End Try
    End Sub

    Private Sub rbcobra_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub rblistmovimensu_Enter(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub rbcobra_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtCodigoCliente.GotFocus, _
    txtidpersona.GotFocus, _
 _
    DTPFECHAinicioFACTURA.GotFocus, _
    cbidtipo_moneda.GotFocus, _
    cbidforma_pago.GotFocus, _
    cmbAgencia.GotFocus, _
    cmbUsuarios.GotFocus
        limpiar()
    End Sub
    Private Sub limpiar()

        'DGV3.DataSource = Nothing
        Try
            'dgv4.DataSource = Nothing
            If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                txtCodigoCliente.Text = ""
                txtidpersona.Text = ""
            Else
                With ObjPersona
                    .IDPERSONA = Int(Colllistar_persona_todos.Item(Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                    .IDTIPO_PERSONA = 0
                    .CODIGO_CLIENTE = "NULL"
                    'datahelper
                    'ObjPersona.FNLISTAR_PERSONA(VOCONTROLUSUARIO, .IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                    ObjPersona.FNLISTAR_PERSONA(.IDTIPO_PERSONA, .IDPERSONA, .CODIGO_CLIENTE)
                    Me.txtCodigoCliente.Text = .CODIGO_CLIENTE
                End With
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtidpersona_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtidpersona.TextChanged
        limpiar_grilla()
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbltotal_pagoS.Click

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbltotal_facturas.Click

    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub



    Private Sub Panel4_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub Panel5_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub



    Private Sub Panel6_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub
    Sub FORMAT_DGVGUIAS()
        DGVGUIAS.Columns.Clear()


        With DGVGUIAS
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            '.DataSource = DVGUIAS 
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .ScrollBars = ScrollBars.Both

        End With

        Dim LOGIN As New DataGridViewTextBoxColumn
        With LOGIN
            .HeaderText = "LOGIN"
            .Name = "LOGIN"
            .DataPropertyName = "LOGIN"
            '.Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim LOGIN_FUNCIONARIO As New DataGridViewTextBoxColumn
        With LOGIN_FUNCIONARIO
            .HeaderText = "FUNCIONARIO"
            .Name = "LOGIN_FUNCIONARIO"
            .DataPropertyName = "LOGIN_FUNCIONARIO"
            '.Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim ANIO_FACTURA As New DataGridViewTextBoxColumn
        With ANIO_FACTURA
            .HeaderText = "ANIO_FACTURA"
            .Name = "ANIO_FACTURA"
            .DataPropertyName = "ANIO_FACTURA"
            '.Width = 4
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim CODIGO_CLIENTE As New DataGridViewTextBoxColumn
        With CODIGO_CLIENTE
            .HeaderText = "CODIGO CLIENTE"
            .Name = "CODIGO_CLIENTE"
            .DataPropertyName = "CODIGO_CLIENTE"
            '.Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim DESTINATARIO As New DataGridViewTextBoxColumn
        With DESTINATARIO
            .HeaderText = "DESTINATARIO"
            .Name = "DESTINATARIO"
            .DataPropertyName = "DESTINATARIO"
            '.Width = 182
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim DESTINO As New DataGridViewTextBoxColumn
        With DESTINO
            .HeaderText = "DESTINO"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim ORIGEN As New DataGridViewTextBoxColumn
        With ORIGEN
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim DIA_FACTURA As New DataGridViewTextBoxColumn
        With DIA_FACTURA
            .HeaderText = "DIA FACTURA"
            .Name = "DIA_FACTURA"
            .DataPropertyName = "DIA_FACTURA"
            '.Width = 2
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim DIRECCION_PERSONA As New DataGridViewTextBoxColumn
        With DIRECCION_PERSONA
            .HeaderText = "DIRECCION PERSONA"
            .Name = "DIRECCION_PERSONA"
            .DataPropertyName = "DIRECCION_PERSONA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim DIREC_DESTI As New DataGridViewTextBoxColumn
        With DIREC_DESTI
            .HeaderText = "DIREC DESTI"
            .Name = "DIREC_DESTI"
            .DataPropertyName = "DIREC_DESTI"
            '.Width = 200
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim DIREC_REMI As New DataGridViewTextBoxColumn
        With DIREC_REMI
            .HeaderText = "DIREC REMI"
            .Name = "DIREC_REMI"
            .DataPropertyName = "DIREC_REMI"
            '.Width = 200
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim DSCTO As New DataGridViewTextBoxColumn
        With DSCTO
            .HeaderText = "DSCTO"
            .Name = "DSCTO"
            .DataPropertyName = "DSCTO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim FECHA As New DataGridViewTextBoxColumn
        With FECHA
            .HeaderText = "FECHA"
            .Name = "FECHA"
            .DataPropertyName = "FECHA"
            '.Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim FECHA_GUIA As New DataGridViewTextBoxColumn
        With FECHA_GUIA
            .HeaderText = "FECHA GUIA"
            .Name = "FECHA_GUIA"
            .DataPropertyName = "FECHA_GUIA"
            '.Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim FECHA_PREFACTURA As New DataGridViewTextBoxColumn
        With FECHA_PREFACTURA
            .HeaderText = "FECHA_PREFACTURA"
            .Name = "FECHA_PREFACTURA"
            .DataPropertyName = "FECHA_PREFACTURA"
            '.Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO
            .HeaderText = "ESTADO REGISTRO"
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
            '.Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim ESTADO_ENVIO As New DataGridViewTextBoxColumn
        With ESTADO_ENVIO
            .HeaderText = "ESTADO_ENVIO"
            .Name = "ESTADO_ENVIO"
            .DataPropertyName = "ESTADO_ENVIO"
            '.Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
        With NOMBRE_AGENCIA
            .HeaderText = "NOMBRE AGENCIA"
            .Name = "NOMBRE_AGENCIA"
            .DataPropertyName = "NOMBRE_AGENCIA"
            '.Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim FORMA_PAGO As New DataGridViewTextBoxColumn
        With FORMA_PAGO
            .HeaderText = "FORMA PAGO"
            .Name = "FORMA_PAGO"
            .DataPropertyName = "FORMA_PAGO"
            '.Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim IDAGENCIAS As New DataGridViewTextBoxColumn
        With IDAGENCIAS
            .HeaderText = "IDAGENCIAS"
            .Name = "IDAGENCIAS"
            .DataPropertyName = "IDAGENCIAS"
            '.Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim IDFACTURA As New DataGridViewTextBoxColumn
        With IDFACTURA
            .HeaderText = "IDFACTURA"
            .Name = "IDFACTURA"
            .DataPropertyName = "IDFACTURA"
            '.Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
            .Visible = False   'Agregado por omendoza 11/02/2007
        End With
        Dim IDFORMA_PAGO As New DataGridViewTextBoxColumn
        With IDFORMA_PAGO
            .HeaderText = "IDFORMA_PAGO"
            .Name = "IDFORMA_PAGO"
            .DataPropertyName = "IDFORMA_PAGO"
            '.Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim IDTIPO_MONEDA As New DataGridViewTextBoxColumn
        With IDTIPO_MONEDA
            .HeaderText = "IDTIPO_MONEDA"
            .Name = "IDTIPO_MONEDA"
            .DataPropertyName = "IDTIPO_MONEDA"
            '.Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim IDUSUARIO_PERSONAL As New DataGridViewTextBoxColumn
        With IDUSUARIO_PERSONAL
            .HeaderText = "IDUSUARIO_PERSONAL"
            .Name = "IDUSUARIO_PERSONAL"
            .DataPropertyName = "IDUSUARIO_PERSONAL"
            '.Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim MEMO As New DataGridViewTextBoxColumn
        With MEMO
            .HeaderText = "MEMO"
            .Name = "MEMO"
            .DataPropertyName = "MEMO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim MES_FACTURA As New DataGridViewTextBoxColumn
        With MES_FACTURA
            .HeaderText = "MES_FACTURA"
            .Name = "MES_FACTURA"
            .DataPropertyName = "MES_FACTURA"
            '.Width = 10
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim MONTO_IMPUESTO As New DataGridViewTextBoxColumn
        With MONTO_IMPUESTO
            .HeaderText = "IMPUESTO"
            .Name = "MONTO_IMPUESTO"
            .DataPropertyName = "MONTO_IMPUESTO"
            '.Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim NRO_FACTURA As New DataGridViewTextBoxColumn
        With NRO_FACTURA
            .HeaderText = "Nº FACTURA"
            .Name = "NRO_FACTURA"
            .DataPropertyName = "NRO_FACTURA"
            '.Width = 70
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "RAZON SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim REFE As New DataGridViewTextBoxColumn
        With REFE
            .HeaderText = "REFE"
            .Name = "REFE"
            .DataPropertyName = "REFE"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim REMITENTE As New DataGridViewTextBoxColumn
        With REMITENTE
            .HeaderText = "REMITENTE"
            .Name = "REMITENTE"
            .DataPropertyName = "REMITENTE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SERIE_FACTURA As New DataGridViewTextBoxColumn
        With SERIE_FACTURA
            .HeaderText = "SERIE FACTURA"
            .Name = "SERIE_FACTURA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "SERIE_FACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim NRO_GUIA As New DataGridViewTextBoxColumn
        With NRO_GUIA
            .HeaderText = "Nº GUIA"
            .Name = "NRO_GUIA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "NRO_GUIA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim NRO_PREFACTURA As New DataGridViewTextBoxColumn
        With NRO_PREFACTURA
            .HeaderText = "Nº PREFACTURA"
            .Name = "NRO_PREFACTURA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "NRO_PREFACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
        With SIMBOLO_MONEDA
            .HeaderText = "SIMBOLO_MONEDA"
            .Name = "SIMBOLO_MONEDA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "SIMBOLO_MONEDA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SUB_TOTAL As New DataGridViewTextBoxColumn
        With SUB_TOTAL
            .HeaderText = "SUB TOTAL"
            .Name = "SUB_TOTAL"
            .DataPropertyName = "SUB_TOTAL"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
        With TOTAL_COSTO
            .HeaderText = "TOTAL GUIAS"
            .Name = "TOTAL_COSTO"
            .DataPropertyName = "TOTAL_COSTO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim SALDO As New DataGridViewTextBoxColumn
        With (SALDO)
            .HeaderText = "SALDO"
            .Name = "SALDO1"
            .DataPropertyName = "SALDO1"
            '.Width = 50
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With


        'Creado por Omendoza 11-02-2007 
        Dim l_fecha_cargo As New DataGridViewTextBoxColumn
        With l_fecha_cargo
            .HeaderText = "Fecha Cargo"
            .Name = "fecha_cargo"
            .DataPropertyName = "fecha_cargo"
            '.Width = 18
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = True
            .ReadOnly = True
        End With
        '
        Dim l_fecha_vencimiento As New DataGridViewTextBoxColumn
        With l_fecha_vencimiento
            .HeaderText = "Fecha Vencimiento"
            .Name = "FECHA_VENCIMIENTO"
            .DataPropertyName = "FECHA_VENCIMIENTO"
            '.Width = 18
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = True
            .ReadOnly = True
        End With
        '
        Dim l_idpersona As New DataGridViewTextBoxColumn
        With l_idpersona
            .HeaderText = "IDPERSONA"
            .Name = "IDPERSONA"
            .DataPropertyName = "IDPERSONA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
            .ReadOnly = True
        End With
        '
        Dim l_idestado_factura As New DataGridViewTextBoxColumn
        With l_idestado_factura
            .HeaderText = "idestado_factura"
            .Name = "idestado_factura"
            .DataPropertyName = "idestado_factura"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
            .ReadOnly = True
        End With

        Dim MES_CORRESPONDE As New DataGridViewTextBoxColumn
        With MES_CORRESPONDE
            .HeaderText = "Mes Corresponde"
            .Name = "mes_CORRESPONDE"
            .DataPropertyName = "mes_CORRESPONDE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        '
        Dim SALDO_CLIENTE As New DataGridViewTextBoxColumn
        With SALDO_CLIENTE
            .HeaderText = "SALDO Cliente"
            .Name = "SALDO_CLIENTE"
            .DataPropertyName = "SALDO_CLIENTE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Visible = False
        End With
        '
        Dim LINEA_CREDITO As New DataGridViewTextBoxColumn
        With LINEA_CREDITO
            .HeaderText = "Línea de Crédito"
            .Name = "LINEA_CREDITO"
            .DataPropertyName = "LINEA_CREDITO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Visible = False
        End With
        '
        With DGVGUIAS
            .Columns.AddRange(CODIGO_CLIENTE, RAZON_SOCIAL, FECHA_GUIA, NRO_GUIA, ORIGEN, DESTINO, SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, LOGIN_FUNCIONARIO, ESTADO_REGISTRO, ESTADO_ENVIO, SALDO_CLIENTE, LINEA_CREDITO)
        End With
    End Sub
    Sub FORMAT_DGVPREFACTURAS()
        DGVPREFACTURAS.Columns.Clear()
        With DGVPREFACTURAS
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            '.DataSource = DVPREFACTURAS  
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
        End With
        '
        Dim LOGIN As New DataGridViewTextBoxColumn
        With LOGIN
            .HeaderText = "LOGIN"
            .Name = "LOGIN"
            .DataPropertyName = "LOGIN"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim LOGIN_FUNCIONARIO As New DataGridViewTextBoxColumn
        With LOGIN_FUNCIONARIO
            .HeaderText = "LOGIN_FUNCIONARIO"
            .Name = "LOGIN_FUNCIONARIO"
            .DataPropertyName = "LOGIN_FUNCIONARIO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
        End With

        Dim ANIO_FACTURA As New DataGridViewTextBoxColumn
        With ANIO_FACTURA
            .HeaderText = "ANIO_FACTURA"
            .Name = "ANIO_FACTURA"
            .DataPropertyName = "ANIO_FACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim CODIGO_CLIENTE As New DataGridViewTextBoxColumn
        With CODIGO_CLIENTE
            .HeaderText = "CODIGO_CLIENTE"
            .Name = "CODIGO_CLIENTE"
            .DataPropertyName = "CODIGO_CLIENTE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DESTINATARIO As New DataGridViewTextBoxColumn
        With DESTINATARIO
            .HeaderText = "DESTINATARIO"
            .Name = "DESTINATARIO"
            .DataPropertyName = "DESTINATARIO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DESTINO As New DataGridViewTextBoxColumn
        With DESTINO
            .HeaderText = "DESTINO"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim ORIGEN As New DataGridViewTextBoxColumn
        With ORIGEN
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim DIA_FACTURA As New DataGridViewTextBoxColumn
        With DIA_FACTURA
            .HeaderText = "DIA_FACTURA"
            .Name = "DIA_FACTURA"
            .DataPropertyName = "DIA_FACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DIRECCION_PERSONA As New DataGridViewTextBoxColumn
        With DIRECCION_PERSONA
            .HeaderText = "DIRECCION_PERSONA"
            .Name = "DIRECCION_PERSONA"
            .DataPropertyName = "DIRECCION_PERSONA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim DIREC_DESTI As New DataGridViewTextBoxColumn
        With DIREC_DESTI
            .HeaderText = "DIREC_DESTI"
            .Name = "DIREC_DESTI"
            .DataPropertyName = "DIREC_DESTI"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DIREC_REMI As New DataGridViewTextBoxColumn
        With DIREC_REMI
            .HeaderText = "DIREC_REMI"
            .Name = "DIREC_REMI"
            .DataPropertyName = "DIREC_REMI"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DSCTO As New DataGridViewTextBoxColumn
        With DSCTO
            .HeaderText = "DSCTO"
            .Name = "DSCTO"
            .DataPropertyName = "DSCTO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim FECHA As New DataGridViewTextBoxColumn
        With FECHA
            .HeaderText = "FECHA"
            .Name = "FECHA"
            .DataPropertyName = "FECHA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FECHA_GUIA As New DataGridViewTextBoxColumn
        With FECHA_GUIA
            .HeaderText = "FECHA_GUIA"
            .Name = "FECHA_GUIA"
            .DataPropertyName = "FECHA_GUIA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FECHA_PREFACTURA As New DataGridViewTextBoxColumn
        With FECHA_PREFACTURA
            .HeaderText = "FECHA_PREFACTURA"
            .Name = "FECHA_PREFACTURA"
            .DataPropertyName = "FECHA_PREFACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO
            .HeaderText = "ESTADO_REGISTRO"
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ESTADO_ENVIO As New DataGridViewTextBoxColumn
        With ESTADO_ENVIO
            .HeaderText = "ESTADO_ENVIO"
            .Name = "ESTADO_ENVIO"
            .DataPropertyName = "ESTADO_ENVIO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
        With NOMBRE_AGENCIA
            .HeaderText = "NOMBRE_AGENCIA"
            .Name = "NOMBRE_AGENCIA"
            .DataPropertyName = "NOMBRE_AGENCIA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FORMA_PAGO As New DataGridViewTextBoxColumn
        With FORMA_PAGO
            .HeaderText = "FORMA_PAGO"
            .Name = "FORMA_PAGO"
            .DataPropertyName = "FORMA_PAGO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim IDAGENCIAS As New DataGridViewTextBoxColumn
        With IDAGENCIAS
            .HeaderText = "IDAGENCIAS"
            .Name = "IDAGENCIAS"
            .DataPropertyName = "IDAGENCIAS"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim IDFACTURA As New DataGridViewTextBoxColumn
        With IDFACTURA
            .HeaderText = "IDFACTURA"
            .Name = "IDFACTURA"
            .DataPropertyName = "IDFACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .Visible = False   'Agregado por omendoza 11/02/2007
        End With
        Dim IDFORMA_PAGO As New DataGridViewTextBoxColumn
        With IDFORMA_PAGO
            .HeaderText = "IDFORMA_PAGO"
            .Name = "IDFORMA_PAGO"
            .DataPropertyName = "IDFORMA_PAGO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDTIPO_MONEDA As New DataGridViewTextBoxColumn
        With IDTIPO_MONEDA
            .HeaderText = "IDTIPO_MONEDA"
            .Name = "IDTIPO_MONEDA"
            .DataPropertyName = "IDTIPO_MONEDA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDUSUARIO_PERSONAL As New DataGridViewTextBoxColumn
        With IDUSUARIO_PERSONAL
            .HeaderText = "IDUSUARIO_PERSONAL"
            .Name = "IDUSUARIO_PERSONAL"
            .DataPropertyName = "IDUSUARIO_PERSONAL"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim MEMO As New DataGridViewTextBoxColumn
        With MEMO
            .HeaderText = "MEMO"
            .Name = "MEMO"
            .DataPropertyName = "MEMO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim MES_FACTURA As New DataGridViewTextBoxColumn
        With MES_FACTURA
            .HeaderText = "MES_FACTURA"
            .Name = "MES_FACTURA"
            .DataPropertyName = "MES_FACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim MONTO_IMPUESTO As New DataGridViewTextBoxColumn
        With MONTO_IMPUESTO
            .HeaderText = "MONTO_IMPUESTO"
            .Name = "MONTO_IMPUESTO"
            .DataPropertyName = "MONTO_IMPUESTO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim NRO_FACTURA As New DataGridViewTextBoxColumn
        With NRO_FACTURA
            .HeaderText = "NRO_FACTURA"
            .Name = "NRO_FACTURA"
            .DataPropertyName = "NRO_FACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "RAZON_SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim REFE As New DataGridViewTextBoxColumn
        With REFE
            .HeaderText = "REFE"
            .Name = "REFE"
            .DataPropertyName = "REFE"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim REMITENTE As New DataGridViewTextBoxColumn
        With REMITENTE
            .HeaderText = "REMITENTE"
            .Name = "REMITENTE"
            .DataPropertyName = "REMITENTE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SERIE_FACTURA As New DataGridViewTextBoxColumn
        With SERIE_FACTURA
            .HeaderText = "SERIE_FACTURA"
            .Name = "SERIE_FACTURA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "SERIE_FACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim NRO_GUIA As New DataGridViewTextBoxColumn
        With NRO_GUIA
            .HeaderText = "NRO_GUIA"
            .Name = "NRO_GUIA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "NRO_GUIA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim NRO_PREFACTURA As New DataGridViewTextBoxColumn
        With NRO_PREFACTURA
            .HeaderText = "NRO_PREFACTURA"
            .Name = "NRO_PREFACTURA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "NRO_PREFACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
        With SIMBOLO_MONEDA
            .HeaderText = "SIMBOLO_MONEDA"
            .Name = "SIMBOLO_MONEDA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "SIMBOLO_MONEDA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SUB_TOTAL As New DataGridViewTextBoxColumn
        With SUB_TOTAL
            .HeaderText = "SUB_TOTAL"
            .Name = "SUB_TOTAL"
            .DataPropertyName = "SUB_TOTAL"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
        With TOTAL_COSTO
            .HeaderText = "TOTAL_COSTO"
            .Name = "TOTAL_COSTO"
            .DataPropertyName = "TOTAL_COSTO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim SALDO As New DataGridViewTextBoxColumn
        With SALDO
            .HeaderText = "SALDO"
            .Name = "SALDO"
            .DataPropertyName = "SALDO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With


        'Creado por Omendoza 11-02-2007 
        Dim l_fecha_cargo As New DataGridViewTextBoxColumn
        With l_fecha_cargo
            .HeaderText = "FECHA CARGO"
            .Name = "fecha_cargo"
            .DataPropertyName = "fecha_cargo"
            '.Width = 18
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = True
            .ReadOnly = True
        End With
        '
        Dim l_fecha_vencimiento As New DataGridViewTextBoxColumn
        With l_fecha_vencimiento
            .HeaderText = "FECHA VENCIMIENTO"
            .Name = "FECHA_VENCIMIENTO"
            .DataPropertyName = "FECHA_VENCIMIENTO"
            '.Width = 18
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = True
            .ReadOnly = True
        End With
        '
        Dim l_idpersona As New DataGridViewTextBoxColumn
        With l_idpersona
            .HeaderText = "IDPERSONA"
            .Name = "IDPERSONA"
            .DataPropertyName = "IDPERSONA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
            .ReadOnly = True
        End With
        '
        Dim l_idestado_factura As New DataGridViewTextBoxColumn
        With l_idestado_factura
            .HeaderText = "idestado_factura"
            .Name = "idestado_factura"
            .DataPropertyName = "idestado_factura"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
            .ReadOnly = True
        End With
        '
        Dim MES_CORRESPONDE As New DataGridViewTextBoxColumn
        With MES_CORRESPONDE
            .HeaderText = "Mes Corresponde"
            .Name = "mes_CORRESPONDE"
            .DataPropertyName = "mes_CORRESPONDE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        '
        Dim SALDO_CLIENTE As New DataGridViewTextBoxColumn
        With SALDO_CLIENTE
            .HeaderText = "SALDO Cliente"
            .Name = "SALDO_CLIENTE"
            .DataPropertyName = "SALDO_CLIENTE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Visible = False
        End With
        '
        Dim LINEA_CREDITO As New DataGridViewTextBoxColumn
        With LINEA_CREDITO
            .HeaderText = "Línea de Crédito"
            .Name = "LINEA_CREDITO"
            .DataPropertyName = "LINEA_CREDITO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Visible = False
        End With
        '
        With DGVPREFACTURAS
            .Columns.AddRange(CODIGO_CLIENTE, RAZON_SOCIAL, FECHA_PREFACTURA, NRO_PREFACTURA, SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, LOGIN_FUNCIONARIO, ESTADO_REGISTRO, SALDO_CLIENTE, LINEA_CREDITO)
        End With

    End Sub
    Sub FORMAT_DGVFACTURAS()
        '
        DGVFACTURAS.Columns.Clear()
        With DGVFACTURAS
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            '.DataSource = DVFACTURAS_ 
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
        End With
        '
        Dim LOGIN As New DataGridViewTextBoxColumn
        With LOGIN
            .HeaderText = "LOGIN"
            .Name = "LOGIN"
            .DataPropertyName = "LOGIN"
            '.Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With

        Dim LOGIN_FUNCIONARIO As New DataGridViewTextBoxColumn
        With LOGIN_FUNCIONARIO
            .HeaderText = "FUNCIONARIO"
            .Name = "LOGIN_FUNCIONARIO"
            .DataPropertyName = "LOGIN_FUNCIONARIO"
            '.Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
            .Visible = False
        End With
        '
        Dim ANIO_FACTURA As New DataGridViewTextBoxColumn
        With ANIO_FACTURA
            .HeaderText = "AÑO FACTURA"
            .Name = "ANIO_FACTURA"
            .DataPropertyName = "ANIO_FACTURA"
            '.Width = 4
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim CODIGO_CLIENTE As New DataGridViewTextBoxColumn
        With CODIGO_CLIENTE
            .HeaderText = "CODIGO CLIENTE"
            .Name = "CODIGO_CLIENTE"
            .DataPropertyName = "CODIGO_CLIENTE"
            '.Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim DESTINATARIO As New DataGridViewTextBoxColumn
        With DESTINATARIO
            .HeaderText = "DESTINATARIO"
            .Name = "DESTINATARIO"
            .DataPropertyName = "DESTINATARIO"
            '.Width = 182
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim DESTINO As New DataGridViewTextBoxColumn
        With DESTINO
            .HeaderText = "DESTINO"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With

        Dim ORIGEN As New DataGridViewTextBoxColumn
        With ORIGEN
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim DIA_FACTURA As New DataGridViewTextBoxColumn
        With DIA_FACTURA
            .HeaderText = "DIA FACTURA"
            .Name = "DIA_FACTURA"
            .DataPropertyName = "DIA_FACTURA"
            '.Width = 2
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim DIRECCION_PERSONA As New DataGridViewTextBoxColumn
        With DIRECCION_PERSONA
            .HeaderText = "DIRECCION PERSONA"
            .Name = "DIRECCION_PERSONA"
            .DataPropertyName = "DIRECCION_PERSONA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim DIREC_DESTI As New DataGridViewTextBoxColumn
        With DIREC_DESTI
            .HeaderText = "DIRECCION DESTINO"
            .Name = "DIREC_DESTI"
            .DataPropertyName = "DIREC_DESTI"
            '.Width = 200
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim DIREC_REMI As New DataGridViewTextBoxColumn
        With DIREC_REMI
            .HeaderText = "DIRECCION REMITENTE"
            .Name = "DIREC_REMI"
            .DataPropertyName = "DIREC_REMI"
            '.Width = 200
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim DSCTO As New DataGridViewTextBoxColumn
        With DSCTO
            .HeaderText = "DESCUENTO"
            .Name = "DSCTO"
            .DataPropertyName = "DSCTO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            '.Width = 80
            .ReadOnly = True
        End With
        Dim FECHA As New DataGridViewTextBoxColumn
        With FECHA
            .HeaderText = "FECHA"
            .Name = "FECHA"
            .DataPropertyName = "FECHA"
            '.Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim FECHA_GUIA As New DataGridViewTextBoxColumn
        With FECHA_GUIA
            .HeaderText = "FECHA_GUIA"
            .Name = "FECHA_GUIA"
            .DataPropertyName = "FECHA_GUIA"
            '.Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim FECHA_PREFACTURA As New DataGridViewTextBoxColumn
        With FECHA_PREFACTURA
            .HeaderText = "FECHA_PREFACTURA"
            .Name = "FECHA_PREFACTURA"
            .DataPropertyName = "FECHA_PREFACTURA"
            '.Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO
            .HeaderText = "ESTADO REGISTRO"
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
            '.Width = 100
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ESTADO_ENVIO As New DataGridViewTextBoxColumn
        With ESTADO_ENVIO
            .HeaderText = "ESTADO ENVIO"
            .Name = "ESTADO_ENVIO"
            .DataPropertyName = "ESTADO_ENVIO"
            '.Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
        With NOMBRE_AGENCIA
            .HeaderText = "NOMBRE_AGENCIA"
            .Name = "NOMBRE_AGENCIA"
            .DataPropertyName = "NOMBRE_AGENCIA"
            '.Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim FORMA_PAGO As New DataGridViewTextBoxColumn
        With FORMA_PAGO
            .HeaderText = "FORMA_PAGO"
            .Name = "FORMA_PAGO"
            .DataPropertyName = "FORMA_PAGO"
            '.Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim IDAGENCIAS As New DataGridViewTextBoxColumn
        With IDAGENCIAS
            .HeaderText = "IDAGENCIAS"
            .Name = "IDAGENCIAS"
            .DataPropertyName = "IDAGENCIAS"
            '.Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim IDFACTURA As New DataGridViewTextBoxColumn
        With IDFACTURA
            .HeaderText = "IDFACTURA"
            .Name = "IDFACTURA"
            .DataPropertyName = "IDFACTURA"
            '.Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
            .Visible = False   'Agregado por omendoza 11/02/2007
        End With
        Dim IDFORMA_PAGO As New DataGridViewTextBoxColumn
        With IDFORMA_PAGO
            .HeaderText = "IDFORMA_PAGO"
            .Name = "IDFORMA_PAGO"
            .DataPropertyName = "IDFORMA_PAGO"
            '.Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim IDTIPO_MONEDA As New DataGridViewTextBoxColumn
        With IDTIPO_MONEDA
            .HeaderText = "IDTIPO_MONEDA"
            .Name = "IDTIPO_MONEDA"
            .DataPropertyName = "IDTIPO_MONEDA"
            '.Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim IDUSUARIO_PERSONAL As New DataGridViewTextBoxColumn
        With IDUSUARIO_PERSONAL
            .HeaderText = "IDUSUARIO_PERSONAL"
            .Name = "IDUSUARIO_PERSONAL"
            .DataPropertyName = "IDUSUARIO_PERSONAL"
            '.Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim MEMO As New DataGridViewTextBoxColumn
        With MEMO
            .HeaderText = "MEMO"
            .Name = "MEMO"
            .DataPropertyName = "MEMO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim MES_FACTURA As New DataGridViewTextBoxColumn
        With MES_FACTURA
            .HeaderText = "MES_FACTURA"
            .Name = "MES_FACTURA"
            .DataPropertyName = "MES_FACTURA"
            '.Width = 10
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim MONTO_IMPUESTO As New DataGridViewTextBoxColumn
        With MONTO_IMPUESTO
            .HeaderText = "IMPUESTO"
            .Name = "MONTO_IMPUESTO"
            .DataPropertyName = "MONTO_IMPUESTO"
            '.Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim NRO_FACTURA As New DataGridViewTextBoxColumn
        With NRO_FACTURA
            .HeaderText = "Nº FACTURA"
            .Name = "NRO_FACTURA"
            .DataPropertyName = "NRO_FACTURA"
            '.Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "RAZON SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            '.Width = 190
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim REFE As New DataGridViewTextBoxColumn
        With REFE
            .HeaderText = "REFE"
            .Name = "REFE"
            .DataPropertyName = "REFE"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim REMITENTE As New DataGridViewTextBoxColumn
        With REMITENTE
            .HeaderText = "REMITENTE"
            .Name = "REMITENTE"
            .DataPropertyName = "REMITENTE"
            '.Width = 182
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim SERIE_FACTURA As New DataGridViewTextBoxColumn
        With SERIE_FACTURA
            .HeaderText = "SERIE_FACTURA"
            .Name = "SERIE_FACTURA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "SERIE_FACTURA"
            '.Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim NRO_GUIA As New DataGridViewTextBoxColumn
        With NRO_GUIA
            .HeaderText = "NRO GUIA"
            .Name = "NRO_GUIA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "NRO_GUIA"
            '.Width = 130
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim NRO_PREFACTURA As New DataGridViewTextBoxColumn
        With NRO_PREFACTURA
            .HeaderText = "NRO_PREFACTURA"
            .Name = "NRO_PREFACTURA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "NRO_PREFACTURA"
            '.Width = 130
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
        With SIMBOLO_MONEDA
            .HeaderText = "SIMBOLO_MONEDA"
            .Name = "SIMBOLO_MONEDA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "SIMBOLO_MONEDA"
            '.Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim SUB_TOTAL As New DataGridViewTextBoxColumn
        With SUB_TOTAL
            .HeaderText = "SUB TOTAL"
            .Name = "SUB_TOTAL"
            .DataPropertyName = "SUB_TOTAL"
            '.Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
        With TOTAL_COSTO
            .HeaderText = "TOTAL FACTURA"
            .Name = "TOTAL_COSTO"
            .DataPropertyName = "TOTAL_COSTO"
            '.Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim SALDO As New DataGridViewTextBoxColumn
        With SALDO
            .HeaderText = "SALDO"
            .Name = "SALDO"
            .DataPropertyName = "SALDO"
            '.Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        'Creado por Omendoza 11-02-2007 
        Dim l_fecha_cargo As New DataGridViewTextBoxColumn
        With l_fecha_cargo
            .HeaderText = "FECHA CARGO"
            .Name = "fecha_cargo"
            .DataPropertyName = "fecha_cargo"
            '.Width = 18
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = True
            .ReadOnly = True
        End With
        '
        Dim l_fecha_vencimiento As New DataGridViewTextBoxColumn
        With l_fecha_vencimiento
            .HeaderText = "FECHA VENCIMIENTO"
            .Name = "FECHA_VENCIMIENTO"
            .DataPropertyName = "FECHA_VENCIMIENTO"
            '.Width = 18
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = True
            .ReadOnly = True
        End With
        '
        Dim l_idpersona As New DataGridViewTextBoxColumn
        With l_idpersona
            .HeaderText = "IDPERSONA"
            .Name = "IDPERSONA"
            .DataPropertyName = "IDPERSONA"
            '.Width = 18
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = False
            .ReadOnly = True
        End With
        '
        Dim l_idestado_factura As New DataGridViewTextBoxColumn
        With l_idestado_factura
            .HeaderText = "idestado_factura"
            .Name = "idestado_factura"
            .DataPropertyName = "idestado_factura"
            '.Width = 18
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = False
            .ReadOnly = True
        End With

        Dim MES_CORRESPONDE As New DataGridViewTextBoxColumn
        With MES_CORRESPONDE
            .HeaderText = "Mes Corresponde"
            .Name = "mes_CORRESPONDE"
            .DataPropertyName = "mes_CORRESPONDE"
            '.Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        '
        Dim SALDO_CLIENTE As New DataGridViewTextBoxColumn
        With SALDO_CLIENTE
            .HeaderText = "SALDO Cliente"
            .Name = "SALDO_CLIENTE"
            .DataPropertyName = "SALDO_CLIENTE"
            '.Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Visible = False
        End With
        '
        Dim LINEA_CREDITO As New DataGridViewTextBoxColumn
        With LINEA_CREDITO
            .HeaderText = "Línea de Crédito"
            .Name = "LINEA_CREDITO"
            .DataPropertyName = "LINEA_CREDITO"
            '.Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = False
        End With
        '
        With DGVFACTURAS
            .Columns.AddRange(CODIGO_CLIENTE, RAZON_SOCIAL, FECHA, NRO_FACTURA, SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, SALDO, LOGIN_FUNCIONARIO, ESTADO_REGISTRO, SALDO_CLIENTE, LINEA_CREDITO)
        End With

    End Sub
    Sub FORMAT_DGVPAGOS()
        DGVPAGOS.Columns.Clear()
        With DGVPAGOS
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            '.DataSource = DVPAGOS 
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
        End With
        '
        Dim LOGIN As New DataGridViewTextBoxColumn
        With LOGIN
            .HeaderText = "LOGIN"
            .Name = "LOGIN"
            .DataPropertyName = "LOGIN"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        '
        Dim LOGIN_FUNCIONARIO As New DataGridViewTextBoxColumn
        With LOGIN_FUNCIONARIO
            .HeaderText = "FUNCIONARIO"
            .Name = "LOGIN_FUNCIONARIO"
            .DataPropertyName = "LOGIN_FUNCIONARIO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
        End With
        '
        Dim ANIO_FACTURA As New DataGridViewTextBoxColumn
        With ANIO_FACTURA
            .HeaderText = "ANIO_FACTURA"
            .Name = "ANIO_FACTURA"
            .DataPropertyName = "ANIO_FACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim CODIGO_CLIENTE As New DataGridViewTextBoxColumn
        With CODIGO_CLIENTE
            .HeaderText = "CODIGO CLIENTE"
            .Name = "CODIGO_CLIENTE"
            .DataPropertyName = "CODIGO_CLIENTE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DESTINATARIO As New DataGridViewTextBoxColumn
        With DESTINATARIO
            .HeaderText = "DESTINATARIO"
            .Name = "DESTINATARIO"
            .DataPropertyName = "DESTINATARIO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DESTINO As New DataGridViewTextBoxColumn
        With DESTINO
            .HeaderText = "DESTINO"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        Dim ORIGEN As New DataGridViewTextBoxColumn
        With ORIGEN
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim DIA_FACTURA As New DataGridViewTextBoxColumn
        With DIA_FACTURA
            .HeaderText = "DIA_FACTURA"
            .Name = "DIA_FACTURA"
            .DataPropertyName = "DIA_FACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DIRECCION_PERSONA As New DataGridViewTextBoxColumn
        With DIRECCION_PERSONA
            .HeaderText = "DIRECCION_PERSONA"
            .Name = "DIRECCION_PERSONA"
            .DataPropertyName = "DIRECCION_PERSONA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim DIREC_DESTI As New DataGridViewTextBoxColumn
        With DIREC_DESTI
            .HeaderText = "DIREC_DESTI"
            .Name = "DIREC_DESTI"
            .DataPropertyName = "DIREC_DESTI"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DIREC_REMI As New DataGridViewTextBoxColumn
        With DIREC_REMI
            .HeaderText = "DIREC_REMI"
            .Name = "DIREC_REMI"
            .DataPropertyName = "DIREC_REMI"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DSCTO As New DataGridViewTextBoxColumn
        With DSCTO
            .HeaderText = "DSCTO"
            .Name = "DSCTO"
            .DataPropertyName = "DSCTO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        Dim FECHA As New DataGridViewTextBoxColumn
        With FECHA
            .HeaderText = "FECHA"
            .Name = "FECHA"
            .DataPropertyName = "FECHA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim NU_COMP_BANC As New DataGridViewTextBoxColumn
        With NU_COMP_BANC
            .HeaderText = "Nº OPERACION"
            .Name = "NU_COMP_BANC"
            .DataPropertyName = "NU_COMP_BANC"
            '.Width = 100
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FE_OPER As New DataGridViewTextBoxColumn
        With FE_OPER
            .HeaderText = "FECHA OPERACION"
            .Name = "FE_OPER"
            .DataPropertyName = "FE_OPER"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim CO_BANC As New DataGridViewTextBoxColumn
        With CO_BANC
            .HeaderText = "OPERACION"
            .Name = "CO_BANC"
            .DataPropertyName = "CO_BANC"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FECHA_GUIA As New DataGridViewTextBoxColumn
        With FECHA_GUIA
            .HeaderText = "FECHA GUIA"
            .Name = "FECHA_GUIA"
            .DataPropertyName = "FECHA_GUIA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FECHA_PREFACTURA As New DataGridViewTextBoxColumn
        With FECHA_PREFACTURA
            .HeaderText = "FECHA_PREFACTURA"
            .Name = "FECHA_PREFACTURA"
            .DataPropertyName = "FECHA_PREFACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO
            .HeaderText = "ESTADO REGISTRO"
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ESTADO_ENVIO As New DataGridViewTextBoxColumn
        With ESTADO_ENVIO
            .HeaderText = "ESTADO ENVIO"
            .Name = "ESTADO_ENVIO"
            .DataPropertyName = "ESTADO_ENVIO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
        With NOMBRE_AGENCIA
            .HeaderText = "NOMBRE_AGENCIA"
            .Name = "NOMBRE_AGENCIA"
            .DataPropertyName = "NOMBRE_AGENCIA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FORMA_PAGO As New DataGridViewTextBoxColumn
        With FORMA_PAGO
            .HeaderText = "FORMA_PAGO"
            .Name = "FORMA_PAGO"
            .DataPropertyName = "FORMA_PAGO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim IDAGENCIAS As New DataGridViewTextBoxColumn
        With IDAGENCIAS
            .HeaderText = "IDAGENCIAS"
            .Name = "IDAGENCIAS"
            .DataPropertyName = "IDAGENCIAS"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim IDFACTURA As New DataGridViewTextBoxColumn
        With IDFACTURA
            .HeaderText = "IDFACTURA"
            .Name = "IDFACTURA"
            .DataPropertyName = "IDFACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .Visible = False   'Agregado por omendoza 11/02/2007
        End With
        Dim IDFORMA_PAGO As New DataGridViewTextBoxColumn
        With IDFORMA_PAGO
            .HeaderText = "IDFORMA_PAGO"
            .Name = "IDFORMA_PAGO"
            .DataPropertyName = "IDFORMA_PAGO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDTIPO_MONEDA As New DataGridViewTextBoxColumn
        With IDTIPO_MONEDA
            .HeaderText = "IDTIPO_MONEDA"
            .Name = "IDTIPO_MONEDA"
            .DataPropertyName = "IDTIPO_MONEDA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IM_DETA As New DataGridViewTextBoxColumn
        With IM_DETA
            .HeaderText = "ABONO"
            .Name = "IM_DETA"
            .DataPropertyName = "IM_DETA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDUSUARIO_PERSONAL As New DataGridViewTextBoxColumn
        With IDUSUARIO_PERSONAL
            .HeaderText = "IDUSUARIO_PERSONAL"
            .Name = "IDUSUARIO_PERSONAL"
            .DataPropertyName = "IDUSUARIO_PERSONAL"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim MEMO As New DataGridViewTextBoxColumn
        With MEMO
            .HeaderText = "MEMO"
            .Name = "MEMO"
            .DataPropertyName = "MEMO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim MES_FACTURA As New DataGridViewTextBoxColumn
        With MES_FACTURA
            .HeaderText = "MES_FACTURA"
            .Name = "MES_FACTURA"
            .DataPropertyName = "MES_FACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim MONTO_IMPUESTO As New DataGridViewTextBoxColumn
        With MONTO_IMPUESTO
            .HeaderText = "IMPUESTO"
            .Name = "MONTO_IMPUESTO"
            .DataPropertyName = "MONTO_IMPUESTO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim NRO_FACTURA As New DataGridViewTextBoxColumn
        With NRO_FACTURA
            .HeaderText = "Nº FACTURA"
            .Name = "NRO_FACTURA"
            .DataPropertyName = "NRO_FACTURA"
            '.Width = 70
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "RAZON SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim REFE As New DataGridViewTextBoxColumn
        With REFE
            .HeaderText = "REFE"
            .Name = "REFE"
            .DataPropertyName = "REFE"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Dim REMITENTE As New DataGridViewTextBoxColumn
        With REMITENTE
            .HeaderText = "REMITENTE"
            .Name = "REMITENTE"
            .DataPropertyName = "REMITENTE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SERIE_FACTURA As New DataGridViewTextBoxColumn
        With SERIE_FACTURA
            .HeaderText = "SERIE_FACTURA"
            .Name = "SERIE_FACTURA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "SERIE_FACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim NRO_GUIA As New DataGridViewTextBoxColumn
        With NRO_GUIA
            .HeaderText = "NRO_GUIA"
            .Name = "NRO_GUIA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "NRO_GUIA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim NRO_PREFACTURA As New DataGridViewTextBoxColumn
        With NRO_PREFACTURA
            .HeaderText = "NRO_PREFACTURA"
            .Name = "NRO_PREFACTURA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "NRO_PREFACTURA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
        With SIMBOLO_MONEDA
            .HeaderText = "SIMBOLO_MONEDA"
            .Name = "SIMBOLO_MONEDA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DataPropertyName = "SIMBOLO_MONEDA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SUB_TOTAL As New DataGridViewTextBoxColumn
        With SUB_TOTAL
            .HeaderText = "SUB TOTAL"
            .Name = "SUB_TOTAL"
            .DataPropertyName = "SUB_TOTAL"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With

        Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
        With TOTAL_COSTO
            .HeaderText = "TOTAL FACTURA"
            .Name = "TOTAL_COSTO"
            .DataPropertyName = "TOTAL_COSTO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim SALDO As New DataGridViewTextBoxColumn
        With SALDO
            .HeaderText = "SALDO"
            .Name = "SALDO"
            .DataPropertyName = "SALDO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With


        'Creado por Omendoza 11-02-2007 
        Dim l_fecha_cargo As New DataGridViewTextBoxColumn
        With l_fecha_cargo
            .HeaderText = "Fecha Cargo"
            .Name = "fecha_cargo"
            .DataPropertyName = "fecha_cargo"
            '.Width = 18
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = True
            .ReadOnly = True
        End With
        '
        Dim l_fecha_vencimiento As New DataGridViewTextBoxColumn
        With l_fecha_vencimiento
            .HeaderText = "Fecha Vencimiento"
            .Name = "FECHA_VENCIMIENTO"
            .DataPropertyName = "FECHA_VENCIMIENTO"
            '.Width = 18
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = True
            .ReadOnly = True
        End With
        '
        Dim l_idpersona As New DataGridViewTextBoxColumn
        With l_idpersona
            .HeaderText = "IDPERSONA"
            .Name = "IDPERSONA"
            .DataPropertyName = "IDPERSONA"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
            .ReadOnly = True
        End With
        '
        Dim l_idestado_factura As New DataGridViewTextBoxColumn
        With l_idestado_factura
            .HeaderText = "idestado_factura"
            .Name = "idestado_factura"
            .DataPropertyName = "idestado_factura"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Visible = False
            .ReadOnly = True
        End With

        Dim MES_CORRESPONDE As New DataGridViewTextBoxColumn
        With MES_CORRESPONDE
            .HeaderText = "Mes Corresponde"
            .Name = "mes_CORRESPONDE"
            .DataPropertyName = "mes_CORRESPONDE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SALDO_CLIENTE As New DataGridViewTextBoxColumn
        With SALDO_CLIENTE
            .HeaderText = "SALDO Cliente"
            .Name = "SALDO_CLIENTE"
            .DataPropertyName = "SALDO_CLIENTE"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Visible = False
        End With
        '
        Dim LINEA_CREDITO As New DataGridViewTextBoxColumn
        With LINEA_CREDITO
            .HeaderText = "Línea de Crédito"
            .Name = "LINEA_CREDITO"
            .DataPropertyName = "LINEA_CREDITO"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Visible = False
        End With


        With DGVPAGOS
            '.Columns.AddRange(LOGIN, CODIGO_CLIENTE, RAZON_SOCIAL, FECHA, NRO_FACTURA, SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, SALDO, LOGIN_FUNCIONARIO, FE_OPER, CO_BANC, NU_COMP_BANC, IM_DETA, ESTADO_REGISTRO)
            .Columns.AddRange(CODIGO_CLIENTE, RAZON_SOCIAL, FECHA, NRO_FACTURA, SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, LOGIN_FUNCIONARIO, FE_OPER, CO_BANC, NU_COMP_BANC, IM_DETA, ESTADO_REGISTRO, SALDO_CLIENTE, LINEA_CREDITO)
        End With
    End Sub
    Sub FORMAT_DGV_cuenta_corriente()
        DGV_cuenta_corriente.Columns.Clear()
        '
        With DGV_cuenta_corriente
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            '.DataSource = DVPAGOS 
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
        End With
        '
        Dim CODIGO_CLIENTE As New DataGridViewTextBoxColumn
        With CODIGO_CLIENTE
            .HeaderText = "CODIGO CLIENTE"
            .Name = "CODIGO_CLIENTE"
            .DataPropertyName = "CODIGO_CLIENTE"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        '
        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "RAZON SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            '.Width = 280
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        '
        Dim FECHA As New DataGridViewTextBoxColumn
        With FECHA
            .HeaderText = "FECHA"
            .Name = "FECHA"
            .DataPropertyName = "FECHA"
            '.Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        '
        Dim fecha_vencimiento As New DataGridViewTextBoxColumn
        With fecha_vencimiento
            .HeaderText = "FEC. VENCIMIENTO"
            .Name = "fecha_vencimiento"
            .DataPropertyName = "fecha_vencimiento"
            '.Width = 80
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        '
        Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
        With TOTAL_COSTO
            .HeaderText = "TOTAL FACTURA"
            .Name = "TOTAL_COSTO"
            .DataPropertyName = "TOTAL_COSTO"
            '.Width = 50
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        '
        Dim IM_DETA As New DataGridViewTextBoxColumn
        With IM_DETA
            .HeaderText = "COBRANZA"
            .Name = "IM_DETA"
            .DataPropertyName = "IM_DETA"
            '.Width = 50
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        '
        Dim a_cuenta As New DataGridViewTextBoxColumn
        With a_cuenta
            .HeaderText = "A CUENTA"
            .Name = "a_cuenta"
            '.Width = 100
            '.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DataPropertyName = "a_cuenta"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Visible = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        '
        Dim SALDO As New DataGridViewTextBoxColumn
        With SALDO
            .HeaderText = "SALDO"
            .Name = "SALDO"
            .DataPropertyName = "SALDO"
            '.Width = 100
            '
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            '
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        '
        Dim NRO_FACTURA As New DataGridViewTextBoxColumn
        With NRO_FACTURA
            .HeaderText = "NRO FACTURA"
            .Name = "NRO_FACTURA"
            .DataPropertyName = "NRO_FACTURA"
            '.Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        '
        Dim SALDO_CLIENTE As New DataGridViewTextBoxColumn
        With SALDO_CLIENTE
            .HeaderText = "SALDO Cliente"
            .Name = "SALDO_CLIENTE"
            .DataPropertyName = "SALDO_CLIENTE"
            '.Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = False
        End With
        '
        Dim LINEA_CREDITO As New DataGridViewTextBoxColumn
        With LINEA_CREDITO
            .HeaderText = "Línea de Crédito"
            .Name = "LINEA_CREDITO"
            .DataPropertyName = "LINEA_CREDITO"
            '.Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Visible = False
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        '
        Dim LOGIN_FUNCIONARIO As New DataGridViewTextBoxColumn
        With LOGIN_FUNCIONARIO
            .HeaderText = "Funcionario de Negocio"
            .Name = "LOGIN_FUNCIONARIO"
            .DataPropertyName = "LOGIN_FUNCIONARIO"
            '.Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Visible = False
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        '
        Dim IDPERSONA As New DataGridViewTextBoxColumn
        With IDPERSONA
            .HeaderText = "Id. Persona"
            .Name = "idpersona"
            .DataPropertyName = "idpersona"
            '.Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Visible = False
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        '
        With DGV_cuenta_corriente
            '.Columns.AddRange(CODIGO_CLIENTE, RAZON_SOCIAL, FECHA, NRO_FACTURA, fecha_vencimiento, TOTAL_COSTO, IM_DETA, SALDO)
            .Columns.AddRange(CODIGO_CLIENTE, RAZON_SOCIAL, TOTAL_COSTO, a_cuenta, SALDO, SALDO_CLIENTE, LINEA_CREDITO, LOGIN_FUNCIONARIO, IDPERSONA)
        End With
    End Sub
    Sub FORMAT_DGV_cuenta_corriente_deta()
        '
        Me.DGV_cta_corriente_det.Columns.Clear()
        '
        With DGV_cta_corriente_det
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            '.DataSource = DVPAGOS 
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ScrollBars = ScrollBars.Both
        End With
        '
        Dim CODIGO_CLIENTE As New DataGridViewTextBoxColumn
        With CODIGO_CLIENTE
            .HeaderText = "CODIGO CLIENTE"
            .Name = "CODIGO_CLIENTE"
            .DataPropertyName = "CODIGO_CLIENTE"
            '.Width = 100
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        '
        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .HeaderText = "RAZON SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            '.Width = 200
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        '
        Dim FECHA As New DataGridViewTextBoxColumn
        With FECHA
            .HeaderText = "FECHA"
            .Name = "FECHA"
            .DataPropertyName = "FECHA"
            '.Width = 80
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With
        '
        Dim fecha_vencimiento As New DataGridViewTextBoxColumn
        With fecha_vencimiento
            .HeaderText = "FEC. VENCIMIENTO"
            .Name = "fecha_vencimiento"
            .DataPropertyName = "fecha_vencimiento"
            '.Width = 80
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        '
        Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
        With TOTAL_COSTO
            .HeaderText = "TOTAL FACTURA"
            .Name = "TOTAL_COSTO"
            .DataPropertyName = "TOTAL_COSTO"
            '.Width = 50
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        '
        Dim IM_DETA As New DataGridViewTextBoxColumn
        With IM_DETA
            .HeaderText = "COBRADO"
            .Name = "IM_DETA"
            .DataPropertyName = "IM_DETA"
            '.Width = 50
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        '
        Dim a_cuenta As New DataGridViewTextBoxColumn
        With a_cuenta
            .HeaderText = "A CUENTA"
            .Name = "a_cuenta"
            .DataPropertyName = "a_cuenta"
            '.Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .ReadOnly = True
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = True
        End With
        '
        Dim SALDO As New DataGridViewTextBoxColumn
        With SALDO
            .HeaderText = "SALDO"
            .Name = "SALDO"
            .DataPropertyName = "SALDO"
            '.Width = 50
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim NRO_FACTURA As New DataGridViewTextBoxColumn
        With NRO_FACTURA
            .HeaderText = "NRO FACTURA"
            .Name = "NRO_FACTURA"
            .DataPropertyName = "NRO_FACTURA"
            '.Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            '.SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        '
        Dim SALDO_CLIENTE As New DataGridViewTextBoxColumn
        With SALDO_CLIENTE
            .HeaderText = "SALDO CLIENTE"
            .Name = "SALDO_CLIENTE"
            .DataPropertyName = "SALDO_CLIENTE"
            '.Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = False
        End With
        '
        Dim LINEA_CREDITO As New DataGridViewTextBoxColumn
        With LINEA_CREDITO
            .HeaderText = "LINEA DE CREDITO"
            .Name = "LINEA_CREDITO"
            .DataPropertyName = "LINEA_CREDITO"
            '.Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = False
        End With
        '
        Dim LOGIN_FUNCIONARIO As New DataGridViewTextBoxColumn
        With LOGIN_FUNCIONARIO
            .HeaderText = "FUNCIONARIO DE NEGOCIO"
            .Name = "LOGIN_FUNCIONARIO"
            .DataPropertyName = "LOGIN_FUNCIONARIO"
            '.Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = False
        End With
        '
        Dim IDPERSONA As New DataGridViewTextBoxColumn
        With IDPERSONA
            .HeaderText = "Id. Persona"
            .Name = "idpersona"
            .DataPropertyName = "idpersona"
            '.Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = False
        End With
        Dim IDFACTURA As New DataGridViewTextBoxColumn
        With IDFACTURA
            .HeaderText = "Id. Factura"
            .Name = "idfactura"
            .DataPropertyName = "idfactura"
            '.Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Visible = False
        End With
        '
        With DGV_cta_corriente_det
            '.Columns.AddRange(CODIGO_CLIENTE, RAZON_SOCIAL, FECHA, NRO_FACTURA, fecha_vencimiento, TOTAL_COSTO, IM_DETA, SALDO)
            .Columns.AddRange(NRO_FACTURA, FECHA, fecha_vencimiento, TOTAL_COSTO, a_cuenta, SALDO, IDFACTURA)
        End With
    End Sub
    Private Sub cbidtipo_moneda_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbidtipo_moneda.Leave
        Try
            If Me.cbidtipo_moneda.SelectedValue <= 0 And Me.cbidtipo_moneda.Text <> "" Then
                MsgBox("El tipo de moneda ingresado no existe", MsgBoxStyle.Exclamation, "Sistema de Seguridad")
                Me.cbidtipo_moneda.Text = ""
                Me.cbidtipo_moneda.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub cbidforma_pago_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbidforma_pago.Leave
        Try
            If Me.cbidforma_pago.SelectedValue <= 0 And Me.cbidforma_pago.Text <> "" Then
                MsgBox("La forma de pago no existe.", MsgBoxStyle.Exclamation, "Sistema de Seguridad")
                Me.cbidforma_pago.Text = ""
                Me.cbidforma_pago.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Sub limpiar_grilla()
        Try
            '
            DVPREFACTURAS = Nothing
            DVPAGOS = Nothing
            DVFACTURAS_ = Nothing
            DVGUIAS = Nothing
            DVCTA_CORRIENTE = Nothing

            '
            DGVGUIAS.Columns.Clear()
            DGVFACTURAS.Columns.Clear()
            DGVPAGOS.Columns.Clear()            
            ' 
            DGVPREFACTURAS.Columns.Clear()
            Me.DGV_cuenta_corriente.Columns.Clear()
            Me.DGV_cta_corriente_det.Columns.Clear()
            '            
            'txt_linea_credito.Text = ""
            lbltotal_pagoS.Text = ""
            lbltotal_facturas.Text = ""
            lbltotal_prefacturas.Text = ""
            lbltotal_guias.Text = ""
            txt_saldo_cliente.Text = ""
            'Me.txt_funcionario.Text = "" ' No existe 
            '            
            Me.txt_saldo_cliente.Text = "0.0"
            'Me.txt_saldo.Text = "0.0"
            Me.Lab_funcionario.Text = ""
            '
            Me.lblguias.Text = "0"
            Me.lblprefacturas.Text = "0"
            Me.lblfacturas.Text = "0"
            Me.lab_pagos.Text = "0"
            Me.Lab_cta_corriente.Text = "0"
            '
            Me.Lab_Nro_guia_envio.Text = "0"
            Me.Lab_pendiente_x_facturar.Text = "0"
            Me.Lab_pendiente_x_cobrar.Text = "0"
            Me.Lab_cobranza.Text = "0"
            Me.Lab_cta_corriente.Text = "0"
            '
            Me.Lab_registro_detalle.Text = "0"
            '
            DVPREFACTURAS = New DataView
            DVPAGOS = New DataView
            DVFACTURAS_ = New DataView
            DVGUIAS = New DataView
            DVCTA_CORRIENTE = New DataView
            '
            DGVGUIAS.DataSource = DVGUIAS
            DGVPREFACTURAS.DataSource = DVPREFACTURAS
            DGVFACTURAS.DataSource = DVFACTURAS_
            DGVPAGOS.DataSource = DVPAGOS
            Me.DGV_cuenta_corriente.DataSource = DVCTA_CORRIENTE
            Me.DGV_cta_corriente_det.DataSource = DVCTA_CORRIENTE

            '
            FORMAT_DGVGUIAS()
            FORMAT_DGVPREFACTURAS()
            FORMAT_DGVFACTURAS()
            FORMAT_DGVPAGOS()
            FORMAT_DGV_cuenta_corriente()
            FORMAT_DGV_cuenta_corriente_deta()

        Catch ex As Exception
            '
        End Try
    End Sub
    Private Sub cmb_funcionario_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_funcionario.Enter
        '
        lb_lee_campo = False
        Me.txtCodigoCliente.Text = ""
        Me.txtidpersona.Text = ""
        lb_lee_campo = True
        '
        limpiar_grilla()
    End Sub
    Private Sub DTPFECHAinicioFACTURA_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAinicioFACTURA.Enter
        limpiar_grilla()
    End Sub
    Private Sub DTPFECHAFINALFACTURA_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFECHAFINALFACTURA.Enter
        limpiar_grilla()
    End Sub
    Private Sub cmb_tipo_facturacion_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_tipo_facturacion.Enter
        limpiar_grilla()
    End Sub
    Private Sub RadB_Saldo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadB_Saldo.CheckedChanged
        Try
            If Me.RadB_Saldo.Checked = True Then
                Me.radB_linea_credito.Checked = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub radB_linea_credito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radB_linea_credito.CheckedChanged
        Try
            If radB_linea_credito.Checked = True Then
                Me.RadB_Saldo.Checked = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub DGVFACTURAS_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVFACTURAS.CellEnter
        Try
            If DGVFACTURAS.Rows.Count < 1 Then
                Exit Sub
            End If
            get_datos_cabecera()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub DGVGUIAS_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVGUIAS.CellEnter
        Try
            If DGVGUIAS.Rows.Count < 1 Then
                Exit Sub
            End If
            get_datos_cabecera()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub DGVPAGOS_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVPAGOS.CellEnter
        Try
            If DGVPAGOS.Rows.Count < 1 Then
                Exit Sub
            End If
            get_datos_cabecera()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub DGVPREFACTURAS_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVPREFACTURAS.CellEnter
        Try
            If DGVPREFACTURAS.Rows.Count < 1 Then
                Exit Sub
            End If
            get_datos_cabecera()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub DGV_cuenta_corriente_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_cuenta_corriente.CellEnter
        Try
            If DGV_cuenta_corriente.Rows.Count < 1 Then
                Exit Sub
            End If
            get_datos_cabecera()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub rb_por_vencer_ctacorriente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_por_vencer_ctacorriente.CheckedChanged
        Try
            If rb_por_vencer_ctacorriente.Checked = True Then                
                lb_lee_cta_corriente = True
                rb_vencido_ctacorriente.Checked = False
                rb_ambas_ctacorriente.Checked = False
                recupera_cta_corriente_x_fecha_vencimiento(1)
                lb_lee_cta_corriente = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub rb_vencido_ctacorriente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_vencido_ctacorriente.CheckedChanged
        Try
            If rb_vencido_ctacorriente.Checked = True Then
                lb_lee_cta_corriente = True
                rb_por_vencer_ctacorriente.Checked = False
                rb_ambas_ctacorriente.Checked = False
                recupera_cta_corriente_x_fecha_vencimiento(-1)
                lb_lee_cta_corriente = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Private Sub rb_ambas_ctacorriente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_ambas_ctacorriente.CheckedChanged
        Try
            If rb_ambas_ctacorriente.Checked = True Then

                'If Me.DGV_cuenta_corriente.Rows.Count < 1 Then
                'Exit Sub
                'End If
                lb_lee_cta_corriente = True
                rb_por_vencer_ctacorriente.Checked = False
                rb_vencido_ctacorriente.Checked = False
                recupera_cta_corriente_x_fecha_vencimiento(0)
                lb_lee_cta_corriente = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
#Region "Procedimiento y funciones"
    'me.TabControl1.ind
    Sub get_datos_cabecera()
        Dim ldtgvr_fila As DataGridViewRow
        Dim ll_fila As Long
        Dim SLab_funcionario As String
        Dim slinea_credito, Ssaldo_cliente As Double
        Try
            ' Inicializando valores
            SLab_funcionario = ""
            slinea_credito = 0
            Ssaldo_cliente = 0
            Select Case Me.TabControl1.SelectedIndex
                Case 0  'Guias Envio 
                    ll_fila = Me.DGVGUIAS.Rows.Count
                    If ll_fila < 1 Then
                        Exit Select
                    End If
                    ldtgvr_fila = Me.DGVGUIAS.CurrentRow()
                    If IsDBNull(ldtgvr_fila.Cells("LOGIN_FUNCIONARIO").Value) = True Then
                        SLab_funcionario = "Sin Funcionario"
                    Else
                        SLab_funcionario = CType(ldtgvr_fila.Cells("LOGIN_FUNCIONARIO").Value, String)
                    End If
                    slinea_credito = CType(ldtgvr_fila.Cells("LINEA_CREDITO").Value, String)
                    Ssaldo_cliente = CType(ldtgvr_fila.Cells("SALDO_CLIENTE").Value, String)
                Case 1  'Prefactura 
                    ll_fila = Me.DGVPREFACTURAS.Rows.Count
                    If ll_fila < 1 Then
                        Exit Select
                    End If
                    ldtgvr_fila = Me.DGVPREFACTURAS.CurrentRow()
                    '
                    If IsDBNull(ldtgvr_fila.Cells("LOGIN_FUNCIONARIO").Value) = True Then
                        SLab_funcionario = "Sin Funcionario"
                    Else
                        SLab_funcionario = CType(ldtgvr_fila.Cells("LOGIN_FUNCIONARIO").Value, String)
                    End If
                    slinea_credito = CType(ldtgvr_fila.Cells("LINEA_CREDITO").Value, String)
                    Ssaldo_cliente = CType(ldtgvr_fila.Cells("SALDO_CLIENTE").Value, String)
                Case 2  'Factura
                    ll_fila = Me.DGVFACTURAS.Rows.Count
                    If ll_fila < 1 Then
                        Exit Select
                    End If
                    ldtgvr_fila = Me.DGVFACTURAS.CurrentRow()
                    If IsDBNull(ldtgvr_fila.Cells("LOGIN_FUNCIONARIO").Value) = True Then
                        SLab_funcionario = "Sin Funcionario"
                    Else
                        SLab_funcionario = CType(ldtgvr_fila.Cells("LOGIN_FUNCIONARIO").Value, String)
                    End If
                    slinea_credito = CType(ldtgvr_fila.Cells("LINEA_CREDITO").Value, String)
                    Ssaldo_cliente = CType(ldtgvr_fila.Cells("SALDO_CLIENTE").Value, String)
                Case 3  'Pagos  
                    ll_fila = Me.DGVPAGOS.Rows.Count
                    If ll_fila < 1 Then
                        Exit Select
                    End If
                    ldtgvr_fila = Me.DGVPAGOS.CurrentRow()
                    If IsDBNull(ldtgvr_fila.Cells("LOGIN_FUNCIONARIO").Value) = True Then
                        SLab_funcionario = "Sin Funcionario"
                    Else
                        SLab_funcionario = CType(ldtgvr_fila.Cells("LOGIN_FUNCIONARIO").Value, String)
                    End If
                    slinea_credito = CType(ldtgvr_fila.Cells("LINEA_CREDITO").Value, String)
                    Ssaldo_cliente = CType(ldtgvr_fila.Cells("SALDO_CLIENTE").Value, String)
                Case 4  'Cuenta corriente 
                    ll_fila = Me.DGV_cuenta_corriente.Rows.Count
                    If ll_fila < 1 Then
                        Exit Select
                    End If
                    ldtgvr_fila = Me.DGV_cuenta_corriente.CurrentRow()
                    If IsDBNull(ldtgvr_fila.Cells("LOGIN_FUNCIONARIO").Value) = True Then
                        SLab_funcionario = "Sin Funcionario"
                    Else
                        SLab_funcionario = CType(ldtgvr_fila.Cells("LOGIN_FUNCIONARIO").Value, String)
                    End If

                    slinea_credito = CType(ldtgvr_fila.Cells("LINEA_CREDITO").Value, String)
                    'Ssaldo_cliente = CType(ldtgvr_fila.Cells("SALDO_CLIENTE").Value, String)
                    'Recupera los datos del detalle 
                    Dim lid_persona As Long
                    Dim objfactura As New ClsLbTepsa.dtoFACTURA
                    Dim ds As New DataSet
                    Dim ldv_cta_corriente_det As New DataView
                    lid_persona = CType(DGV_cuenta_corriente.CurrentRow.Cells("IDPERSONA").Value, Long)
                    '
                    objfactura.IDPERSONA = lid_persona
                    Dim ll_seleccion As Long
                    'Para ver que caso 
                    ll_seleccion = 0
                    If Me.rb_ambas_ctacorriente.Checked = True Then
                        ll_seleccion = 0
                    End If
                    If Me.RbtLegal.Checked Then
                        ll_seleccion = 2
                    End If
                    If Me.rb_por_vencer_ctacorriente.Checked = True Then
                        ll_seleccion = 1
                    End If
                    If Me.rb_vencido_ctacorriente.Checked = True Then
                        ll_seleccion = -1
                    End If
                    '
                    Me.Lab_registro_detalle.Text = "0"
                    objfactura.idseleccion = ll_seleccion
                    'datahelper
                    'ds = objfactura.sp_get_detalle_cuenta_corriente(cnn)
                    ds = objfactura.sp_get_detalle_cuenta_corriente()
                    ldv_cta_corriente_det = ds.Tables(0).DefaultView
                    FORMAT_DGV_cuenta_corriente_deta()
                    DGV_cta_corriente_det.DataSource = ldv_cta_corriente_det                    
                    '
            End Select
            'Pasando 
            Me.Lab_funcionario.Text = SLab_funcionario
            '
            Me.txt_linea_credito.Text = Format(slinea_credito, "###,###,###.00")
            '
            'Me.txt_saldo.Text = Format(Ssaldo_cliente, "###,###,###.00")
            '
            Me.Lab_registro_detalle.Text = DGV_cta_corriente_det.Rows.Count
            '
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
    Sub recupera_cta_corriente_x_fecha_vencimiento(ByVal al_seleccion As Long)
        Try
            If lb_lee_cta_corriente = True Then
                Dim ObjFactura As New ClsLbTepsa.dtoFACTURA

                If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                    ObjFactura.IDPERSONA = 0 ' Recupera para todos los clientes 
                Else

                    ObjFactura.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
                End If
                'If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjFactura.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_INICIO = "NULL"
                'If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjFactura.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_FINAL = "NULL"
                ' Mod. 22/11/2008 --> 
                ObjFactura.idfuncionarioNegocio = Me.cmb_funcionario.SelectedValue
                '
                If Not IsNothing(Me.cmb_tipo_facturacion.SelectedValue) Then
                    ObjFactura.IDTIPO_FACTURACION = Me.cmb_tipo_facturacion.SelectedValue
                Else
                    ObjFactura.IDTIPO_FACTURACION = -1
                End If
                '
                ObjFactura.idseleccion = al_seleccion
                '
                Me.DGV_cuenta_corriente.Columns.Clear()
                Me.DGV_cta_corriente_det.Columns.Clear()
                Dim ds As New DataSet
                'Recupera la fecha de vencimiento 
                'datahelper
                'ds = ObjFactura.sp_get_cuenta_corriente_x_Fecha_vencimiento(cnn)
                ds = ObjFactura.sp_get_cuenta_corriente_x_Fecha_vencimiento()
                DVCTA_CORRIENTE = ds.Tables(0).DefaultView
                '
                FORMAT_DGV_cuenta_corriente()
                FORMAT_DGV_cuenta_corriente_deta()
                ' 
                DGV_cuenta_corriente.DataSource = DVCTA_CORRIENTE
                '                
                'loco
                lb_lee_parte_contar = True
                contar()
                lb_lee_parte_contar = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub
#End Region

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If Me.TabControl1.SelectedIndex = 4 Then
            Me.MenuStrip1.Items(7).Visible = True
        Else
            Me.MenuStrip1.Items(7).Visible = True
        End If
    End Sub

    Private Sub TabControl1_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        ' 
        rd_imprime_pantalla.Checked = True
        'RadB_Saldo.Checked = False
        'radB_linea_credito.Checked = False
        '
        'Me.RadB_Saldo.Checked = True
        Select Case e.TabPageIndex
            Case 0
                Me.rd_imprime_pantalla.Text = "Guías Envío Pendiente"
            Case 1
                Me.rd_imprime_pantalla.Text = "Pre-Factura Pendiente"
            Case 2
                Me.rd_imprime_pantalla.Text = "Factura Pendiente"
            Case 3
                Me.rd_imprime_pantalla.Text = "Cobranzas"
            Case 4
                Me.rd_imprime_pantalla.Text = "Cuenta corriente"
        End Select
    End Sub

    Sub ControlaAcceso(ByVal sender As Object, ByVal e As EventArgs) Handles AyudaToolStripMenuItem.EnabledChanged, CancelarToolStripmenuItem.EnabledChanged
        If bIngreso Then
            Acceso.VerificaCambio(sender, e)
        End If
    End Sub

    Private Sub DGV_cta_corriente_det_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV_cta_corriente_det.DoubleClick
        Me.Cursor = Cursors.AppStarting
        Dim frm As New LblNc
        frm.sFactura = DGV_cta_corriente_det.CurrentRow.Cells(0).Value
        frm.sFecha = DGV_cta_corriente_det.CurrentRow.Cells(1).Value
        frm.iTotal = DGV_cta_corriente_det.CurrentRow.Cells(3).Value
        frm.iAcuenta = DGV_cta_corriente_det.CurrentRow.Cells(4).Value
        frm.iSaldo = DGV_cta_corriente_det.CurrentRow.Cells(5).Value
        frm.iFactura = DGV_cta_corriente_det.CurrentRow.Cells("idfactura").Value
        frm.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub RbtLegal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtLegal.CheckedChanged
        Try
            If RbtLegal.Checked = True Then
                lb_lee_cta_corriente = True
                rb_por_vencer_ctacorriente.Checked = False
                rb_ambas_ctacorriente.Checked = False
                rb_vencido_ctacorriente.Checked = False
                recupera_cta_corriente_x_fecha_vencimiento(2)
                lb_lee_cta_corriente = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Sistema de Seguridad")
        End Try
    End Sub

    Private Sub FrmConsulFactuEmiPago_MenuAyuda() Handles Me.MenuAyuda
        Resumen()
    End Sub

    Sub Resumen()
        Dim ObjFactura As New ClsLbTepsa.dtoFACTURA
        Try
            ObjReport.Dispose()
        Catch
        End Try

        If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
            ObjFactura.IDPERSONA = 0
        Else
            ObjFactura.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
        End If

        ObjReport.rutaRpt = PathFrmReport
        ObjReport.conectar(rptservice, rptuser, rptpass)
        ObjReport.printrptB(False, "", "cc011.rpt", _
        "CLI;" & ObjFactura.IDPERSONA)
    End Sub

    Private Sub DTPFECHAFINALFACTURA_ValueChanged_1(sender As System.Object, e As System.EventArgs) Handles DTPFECHAFINALFACTURA.ValueChanged

    End Sub
End Class
